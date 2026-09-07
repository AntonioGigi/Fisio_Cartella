Partial Public Class FormAddTreatment
    Public PatientId As Integer
    Public InitialDate As DateTime = DateTime.MinValue
    Private Sub FormAddTreatment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Theme.ApplyTheme(Me)
        dtpDate.Format = DateTimePickerFormat.Custom
        dtpDate.CustomFormat = "yyyy-MM-dd HH:mm"
        If InitialDate <> DateTime.MinValue Then
            Try
                dtpDate.Value = InitialDate
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim notes = txtNotes.Text
        Dim progress = txtProgress.Text
        DBHelper.InsertTreatment(PatientId, dtpDate.Value, notes, progress)
        If Not String.IsNullOrEmpty(DBHelper.LastError) Then
            MessageBox.Show($"Errore durante l'inserimento della seduta:\n{DBHelper.LastError}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
End Class
