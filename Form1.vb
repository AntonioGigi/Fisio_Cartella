Imports System
Imports System.IO

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Inizializza DB e tabelle
        DBHelper.InitializeDatabase()
        ' Applica tema
        Theme.ApplyTheme(Me)
        ' Associa handler al pulsante
        AddHandler btnLogin.Click, AddressOf btnLogin_Click
        ' Permetti invio per attivare login
        Me.AcceptButton = btnLogin
        ' Gestione tasto Invio per txtUser/txtPass (in aggiunta ad AcceptButton per robustezza)
        AddHandler txtUser.KeyDown, AddressOf LoginTextBoxes_KeyDown
        AddHandler txtPass.KeyDown, AddressOf LoginTextBoxes_KeyDown
        ' Se non esistono utenti, apri registrazione iniziale per creare admin
        If DBHelper.GetUserCount() = 0 Then
            Dim r0 As New FormRegister()
            r0.MakeAdmin = True
            r0.ShowDialog(Me)
        End If

        ' Miglioramenti estetici: pannello centrale
        Dim card As New Panel()
        card.Size = New Size(380, 300)
        card.Location = New Point((Me.ClientSize.Width - card.Width) \ 2, (Me.ClientSize.Height - card.Height) \ 2)
        card.BackColor = Color.FromArgb(255, 255, 255)
        card.BorderStyle = BorderStyle.None
        ' Sposta i controlli esistenti dentro la card
        For Each c As Control In New List(Of Control) From {lblUser, txtUser, lblPass, txtPass, btnLogin, lblMessage}
            Me.Controls.Remove(c)
            card.Controls.Add(c)
        Next
        ' Regola posizioni relative all'interno del card
        lblUser.Location = New Point(20, 20)
        txtUser.Location = New Point(20, 50)
        lblPass.Location = New Point(20, 95)
        txtPass.Location = New Point(20, 125)
        btnLogin.Location = New Point(20, 170)
        ' Correggi colori per migliore contrasto sul card bianco
        lblUser.ForeColor = Color.Black
        lblPass.ForeColor = Color.Black
        lblMessage.Location = New Point(20, 225)
        Me.Controls.Add(card)
    End Sub

    Private Sub LoginTextBoxes_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnLogin.PerformClick()
        End If
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs)
        Dim username = txtUser.Text.Trim()
        Dim password = txtPass.Text

        If String.IsNullOrEmpty(username) Or String.IsNullOrEmpty(password) Then
            lblMessage.ForeColor = Color.Red
            lblMessage.Text = "Inserisci username e password"
            Return
        End If

        If DBHelper.VerifyUser(username, password) Then
            lblMessage.ForeColor = Color.Green
            lblMessage.Text = "Login effettuato con successo"
            ' Imposta sessione e apre dashboard
            Session.CurrentUser = username
            Session.CurrentUserRole = DBHelper.GetUserRole(username)
            Dim dash As New FormDashboard()
            dash.Show()
            Me.Hide()
        Else
            lblMessage.ForeColor = Color.Red
            lblMessage.Text = "Credenziali non valide"
        End If
    End Sub
End Class
