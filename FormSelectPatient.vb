Imports System.Data

Public Class FormSelectPatient
    Public SelectedPatientId As Integer = -1

    Private Sub FormSelectPatient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Theme.ApplyTheme(Me)
        LoadPatients()
    End Sub

    Private Sub LoadPatients()
        Dim dt As DataTable = DBHelper.GetAllPatients()
        dgvPatients.DataSource = dt
        dgvPatients.AutoResizeColumns()
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If dgvPatients.CurrentRow Is Nothing Then
            MessageBox.Show("Seleziona un paziente.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim idObj = dgvPatients.CurrentRow.Cells("Id").Value
        If idObj Is Nothing Then Return
        SelectedPatientId = Convert.ToInt32(idObj)
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
