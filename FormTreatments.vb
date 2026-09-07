Partial Public Class FormTreatments
    Private Sub FormTreatments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Theme.ApplyTheme(Me)
        LoadPatients()
        AddHandler dgvPatients.SelectionChanged, AddressOf dgvPatients_SelectionChanged
        AddHandler btnSaveTreatment.Click, AddressOf btnSaveTreatment_Click
        Try
            AddHandler Session.DataChanged, AddressOf LoadPatients
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadPatients()
        Dim dt As DataTable = DBHelper.GetAllPatients()
        dgvPatients.DataSource = dt
        dgvPatients.AutoResizeColumns()
        If dgvPatients.Rows.Count > 0 Then
            dgvPatients.Rows(0).Selected = True
            LoadTreatmentsForSelected()
        End If
    End Sub

    Private Sub LoadTreatmentsForSelected()
        If dgvPatients.CurrentRow Is Nothing Then
            dgvTreatments.DataSource = Nothing
            txtAnamnesis.Text = ""
            Return
        End If
        Dim idObj = dgvPatients.CurrentRow.Cells("Id").Value
        If idObj Is Nothing Then
            dgvTreatments.DataSource = Nothing
            txtAnamnesis.Text = ""
            Return
        End If
        Dim id = Convert.ToInt32(idObj)
        Dim dt As DataTable = DBHelper.GetTreatmentsByPatient(id)
        dgvTreatments.DataSource = dt
        dgvTreatments.AutoResizeColumns()
        ' carica anamnesi paziente
        Dim patients = DBHelper.GetAllPatients()
        For Each r As DataRow In patients.Rows
            If Convert.ToInt32(r("Id")) = id Then
                txtAnamnesis.Text = If(r.Item("Anamnesis") IsNot DBNull.Value, r.Item("Anamnesis").ToString(), "")
                Exit For
            End If
        Next
    End Sub

    Private Sub dgvPatients_SelectionChanged(sender As Object, e As EventArgs)
        LoadTreatmentsForSelected()
    End Sub

    Private Sub btnSaveTreatment_Click(sender As Object, e As EventArgs)
        If dgvPatients.CurrentRow Is Nothing Then
            MessageBox.Show("Seleziona un paziente.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim id = Convert.ToInt32(dgvPatients.CurrentRow.Cells("Id").Value)
        Dim evaluation = txtEvaluation.Text
        Dim notes = txtNotes.Text
        ' salva trattamento
        DBHelper.InsertTreatment(id, DateTime.Now, notes, evaluation)
        ' aggiorna anamnesi paziente
        DBHelper.UpdatePatientAnamnesis(id, txtAnamnesis.Text)
        MessageBox.Show("Trattamento salvato.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        LoadTreatmentsForSelected()
    End Sub
End Class
