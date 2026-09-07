Public Class FormUsers
    Private Sub FormUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Theme.ApplyTheme(Me)
        LoadUsers()
        LayoutUsers()
        ' Controllo permessi: solo admin può creare/modificare ruoli/eliminare
        Dim role = DBHelper.GetUserRole(Session.CurrentUser)
        If String.IsNullOrEmpty(role) OrElse Not role.Equals("admin", StringComparison.OrdinalIgnoreCase) Then
            btnNew.Enabled = False
            btnSetRole.Enabled = False
            btnDelete.Enabled = False
        End If
    End Sub

    Private Sub FormUsers_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        LayoutUsers()
    End Sub

    Private Sub LayoutUsers()
        If dgvUsers Is Nothing Then Return
        Dim margin = 12
        Dim width = Math.Max(500, ClientSize.Width - (margin * 2))
        dgvUsers.Location = New Point(margin, margin)
        dgvUsers.Size = New Size(width, Math.Max(180, ClientSize.Height - 82))
        Dim y = dgvUsers.Bottom + 14
        btnNew.Location = New Point(margin, y)
        btnChangePassword.Location = New Point(btnNew.Right + 10, y)
        btnDelete.Location = New Point(btnChangePassword.Right + 10, y)
        btnSetRole.Location = New Point(btnDelete.Right + 10, y)
    End Sub

    Private Sub LoadUsers()
        dgvUsers.DataSource = DBHelper.ListUsers()
        dgvUsers.AutoResizeColumns()
        If dgvUsers.Columns.Contains("Id") Then dgvUsers.Columns("Id").Visible = False
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        If Not IsCurrentUserAdmin() Then Return
        Dim username = Microsoft.VisualBasic.Interaction.InputBox("Username:", "Nuovo utente", "")
        If String.IsNullOrEmpty(username) Then Return
        Dim password = Microsoft.VisualBasic.Interaction.InputBox("Password:", "Nuovo utente", "")
        If String.IsNullOrEmpty(password) Then Return
        Dim role = Microsoft.VisualBasic.Interaction.InputBox("Ruolo (e.g., admin,user):", "Nuovo utente", "user")
        DBHelper.CreateUser(username, password, role)
        LoadUsers()
    End Sub

    Private Sub btnChangePassword_Click(sender As Object, e As EventArgs) Handles btnChangePassword.Click
        If Not IsCurrentUserAdmin() Then Return
        If dgvUsers.CurrentRow Is Nothing Then Return
        Dim username = dgvUsers.CurrentRow.Cells("Username").Value.ToString()
        Dim newPass = Microsoft.VisualBasic.Interaction.InputBox($"Nuova password per {username}:", "Cambia password", "")
        If String.IsNullOrEmpty(newPass) Then Return
        DBHelper.ChangePassword(username, newPass)
        MessageBox.Show("Password aggiornata.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not IsCurrentUserAdmin() Then Return
        If dgvUsers.CurrentRow Is Nothing Then Return
        Dim username = dgvUsers.CurrentRow.Cells("Username").Value.ToString()
        If MessageBox.Show($"Eliminare l'utente {username}?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            DBHelper.DeleteUser(username)
            LoadUsers()
        End If
    End Sub

    Private Sub btnSetRole_Click(sender As Object, e As EventArgs) Handles btnSetRole.Click
        If Not IsCurrentUserAdmin() Then Return
        If dgvUsers.CurrentRow Is Nothing Then Return
        Dim username = dgvUsers.CurrentRow.Cells("Username").Value.ToString()
        Dim role = Microsoft.VisualBasic.Interaction.InputBox($"Ruolo per {username}:", "Imposta ruolo", "user")
        If String.IsNullOrEmpty(role) Then Return
        DBHelper.UpdateUserRole(username, role)
        LoadUsers()
    End Sub

    Private Function IsCurrentUserAdmin() As Boolean
        Dim role = DBHelper.GetUserRole(Session.CurrentUser)
        If role Is Nothing OrElse Not role.Equals("admin", StringComparison.OrdinalIgnoreCase) Then
            MessageBox.Show("Solo un amministratore può gestire gli utenti.", "Accesso negato", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function
End Class
