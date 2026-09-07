Public Class FormRegister
    Public MakeAdmin As Boolean = False
    Private Sub FormRegister_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Theme.ApplyTheme(Me)
    End Sub

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Dim username = txtUsername.Text.Trim()
        Dim password = txtPassword.Text
        Dim confirm = txtConfirm.Text
        If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) Then
            MessageBox.Show("Inserisci username e password.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If password <> confirm Then
            MessageBox.Show("Le password non coincidono.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim passwordError As String = Nothing
        If Not PasswordPolicy.Validate(password, username, passwordError) Then
            MessageBox.Show(passwordError & Environment.NewLine & Environment.NewLine & PasswordPolicy.RequirementsText(), "Password non sicura", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        ' ruolo di default user, se MakeAdmin è true crea admin
        Dim role = If(MakeAdmin, "admin", "user")
        If Not DBHelper.CreateUser(username, password, role) Then
            MessageBox.Show(DBHelper.LastError, "Impossibile creare l'utente", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        MessageBox.Show("Registrazione completata. Effettua il login.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub
End Class
