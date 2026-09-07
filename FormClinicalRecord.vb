Partial Public Class FormClinicalRecord
    Public PatientId As Integer

    Private Sub FormClinicalRecord_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Theme.ApplyTheme(Me)
        If PatientId <= 0 Then Return
        LoadPatient()
        Try
            AddHandler Session.DataChanged, AddressOf LoadPatient
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadPatient()
        Try
            Dim patients = DBHelper.GetAllPatients()
            For Each r As DataRow In patients.Rows
                If Convert.ToInt32(r("Id")) = PatientId Then
                    lblPatientName.Text = $"{r("FirstName")} {r("LastName")}"
                    txtAnamnesis.Text = If(r.Item("Anamnesis") IsNot DBNull.Value, r.Item("Anamnesis").ToString(), "")
                    Exit For
                End If
            Next
            ' load clinical records
            Dim dtRec = DBHelper.GetClinicalRecordsByPatient(PatientId)
            dgvRecords.DataSource = dtRec
            dgvRecords.AutoResizeColumns()
            ' load treatments
            Dim dtTreat = DBHelper.GetTreatmentsByPatient(PatientId)
            dgvTreatments.DataSource = dtTreat
            dgvTreatments.AutoResizeColumns()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnAddTreatment_Click(sender As Object, e As EventArgs) Handles btnAddTreatment.Click
        Dim f As New FormAddTreatment()
        f.PatientId = PatientId
        If f.ShowDialog() = DialogResult.OK Then
            LoadPatient()
        End If
    End Sub
End Class
