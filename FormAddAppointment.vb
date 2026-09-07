Partial Public Class FormAddAppointment
    Public AppointmentCreated As Boolean = False
    Public InitialStartDate As DateTime = DateTime.MinValue
    Public InitialEndDate As DateTime = DateTime.MinValue
    Private Sub FormAddAppointment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Theme.ApplyTheme(Me)
        ' carica pazienti
        Dim dt = DBHelper.GetAllPatients()
        cbPatients.DisplayMember = "FirstName"
        cbPatients.ValueMember = "Id"
        ' create a combined name column
        If dt.Columns.Contains("FirstName") AndAlso dt.Columns.Contains("LastName") Then
            dt.Columns.Add("DisplayName", GetType(String), "FirstName + ' ' + LastName")
            cbPatients.DisplayMember = "DisplayName"
        End If
        cbPatients.DataSource = dt
        dtpStart.Format = DateTimePickerFormat.Custom
        dtpStart.CustomFormat = "yyyy-MM-dd HH:mm"
        dtpEnd.Format = DateTimePickerFormat.Custom
        dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm"
        ' Se è stata passata una data iniziale, impostala
        If InitialStartDate <> DateTime.MinValue Then
            Try
                dtpStart.Value = InitialStartDate
            Catch ex As Exception
            End Try
        End If
        If InitialEndDate <> DateTime.MinValue Then
            Try
                dtpEnd.Value = InitialEndDate
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If cbPatients.SelectedValue Is Nothing Then
            MessageBox.Show("Seleziona un paziente.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim pid = Convert.ToInt32(cbPatients.SelectedValue)
        Dim s = dtpStart.Value
        Dim en = dtpEnd.Value
        Dim price = 0D
        Decimal.TryParse(txtPrice.Text, price)
        Dim notes = txtNotes.Text
        Dim paymentMode = If(cbPaymentMode.SelectedItem IsNot Nothing, cbPaymentMode.SelectedItem.ToString(), "Per prestazione")
        Dim serviceType = ""
        DBHelper.InsertAppointment(pid, s, en, price, notes, paymentMode, serviceType)
        If Not String.IsNullOrEmpty(DBHelper.LastError) Then
            MessageBox.Show($"Errore durante l'inserimento appuntamento:\n{DBHelper.LastError}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Me.AppointmentCreated = True
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
End Class
