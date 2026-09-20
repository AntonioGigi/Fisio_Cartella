Imports System.Drawing
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class FormNewPatient
    Inherits Form

    ' --- Colori del Design Smorzato ---
    Private colorPrimary As Color = Color.FromArgb(74, 101, 114) ' Blu scuro gestionale
    Private colorDisabled As Color = Color.FromArgb(220, 220, 220) ' Grigio disabilitato
    Private colorText As Color = Color.FromArgb(60, 60, 60) ' Grigio antracite per i testi

    ' --- Dichiarazione dei controlli ---
    Private WithEvents txtFirstName As New TextBox()
    Private WithEvents txtLastName As New TextBox()
    Private WithEvents txtPhone As New TextBox()
    Private WithEvents txtEmail As New TextBox()
    Private WithEvents txtCodiceFiscale As New TextBox()
    Private WithEvents txtAnamnesi As New TextBox()
    Private WithEvents btnSave As New Button()
    Private WithEvents btnCancel As New Button()

    Public Sub New()
        ' Blocca il layout durante la creazione per evitare sfarfallii
        Me.SuspendLayout()

        ' 1. Impostazioni Finestra
        Me.Text = "Nuovo Paziente"
        Me.Size = New Size(520, 480)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.StartPosition = FormStartPosition.CenterParent
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.BackColor = Color.White
        Me.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)

        ' 2. Creazione Riga 1 (Nome e Cognome con asterischi rossi)
        Dim lblNome As New Label() With {.Text = "Nome", .Location = New Point(25, 20), .AutoSize = True, .ForeColor = colorText}
        Dim lblAstNome As New Label() With {.Text = "*", .Location = New Point(lblNome.Right - 5, 20), .AutoSize = True, .ForeColor = Color.Red}
        txtFirstName.Location = New Point(25, 45)
        txtFirstName.Size = New Size(210, 25)

        Dim lblCognome As New Label() With {.Text = "Cognome", .Location = New Point(265, 20), .AutoSize = True, .ForeColor = colorText}
        Dim lblAstCognome As New Label() With {.Text = "*", .Location = New Point(lblCognome.Right + 15, 20), .AutoSize = True, .ForeColor = Color.Red}
        txtLastName.Location = New Point(265, 45)
        txtLastName.Size = New Size(210, 25)

        ' 3. Creazione Riga 2 (Telefono e Email)
        Dim lblTelefono As New Label() With {.Text = "Telefono", .Location = New Point(25, 90), .AutoSize = True, .ForeColor = colorText}
        txtPhone.Location = New Point(25, 115)
        txtPhone.Size = New Size(210, 25)

        Dim lblEmail As New Label() With {.Text = "Email", .Location = New Point(265, 90), .AutoSize = True, .ForeColor = colorText}
        txtEmail.Location = New Point(265, 115)
        txtEmail.Size = New Size(210, 25)

        ' 4. Creazione Riga 3 (Codice Fiscale)
        Dim lblCF As New Label() With {.Text = "Codice Fiscale", .Location = New Point(25, 160), .AutoSize = True, .ForeColor = colorText}
        txtCodiceFiscale.Location = New Point(25, 185)
        txtCodiceFiscale.Size = New Size(210, 25)
        txtCodiceFiscale.CharacterCasing = CharacterCasing.Upper
        txtCodiceFiscale.MaxLength = 16

        ' 5. Creazione Riga 4 (Anamnesi Multiriga)
        Dim lblAnamnesi As New Label() With {.Text = "Anamnesi / Note cliniche", .Location = New Point(25, 230), .AutoSize = True, .ForeColor = colorText}
        txtAnamnesi.Location = New Point(25, 255)
        txtAnamnesi.Size = New Size(450, 80)
        txtAnamnesi.Multiline = True
        txtAnamnesi.ScrollBars = ScrollBars.Vertical

        ' 6. Creazione Pulsanti (Flat Design)
        btnCancel.Text = "Annulla"
        btnCancel.Location = New Point(265, 370)
        btnCancel.Size = New Size(100, 36)
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.FlatAppearance.BorderSize = 0
        btnCancel.BackColor = Color.FromArgb(240, 240, 240)
        btnCancel.ForeColor = Color.Black
        btnCancel.Cursor = Cursors.Hand

        btnSave.Text = "Salva"
btnSave.Location = New Point(375, 370)
btnSave.Size = New Size(100, 36)
btnSave.FlatStyle = FlatStyle.Flat
btnSave.FlatAppearance.BorderSize = 0
btnSave.Cursor = Cursors.Hand

' Aggiunge tutti gli elementi visivi alla finestra in un colpo solo
Me.Controls.AddRange(New Control() {
    lblNome, lblAstNome, txtFirstName,
    lblCognome, lblAstCognome, txtLastName,
    lblTelefono, txtPhone,
    lblEmail, txtEmail,
    lblCF, txtCodiceFiscale,
    lblAnamnesi, txtAnamnesi,
    btnCancel, btnSave
})

' Imposta lo stato iniziale del bottone salva (disabilitato)
UpdateSaveButtonState()

Me.ResumeLayout(False)
End Sub

' --- LOGICA DELLA FINESTRA ---

' Si attiva ogni volta che digiti qualcosa in Nome o Cognome
Private Sub RequiredFields_TextChanged(sender As Object, e As EventArgs) Handles txtFirstName.TextChanged, txtLastName.TextChanged
    UpdateSaveButtonState()
End Sub

' Gestisce il colore e l'attivazione del tasto Salva
Private Sub UpdateSaveButtonState()
    Dim canSave As Boolean = Not String.IsNullOrWhiteSpace(txtFirstName.Text) AndAlso Not String.IsNullOrWhiteSpace(txtLastName.Text)
    btnSave.Enabled = canSave

    If canSave Then
        btnSave.BackColor = colorPrimary
        btnSave.ForeColor = Color.White
    Else
        btnSave.BackColor = colorDisabled
        btnSave.ForeColor = Color.DimGray
    End If
End Sub

Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
    Me.DialogResult = DialogResult.Cancel
    Me.Close()
End Sub

Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
    Dim firstName As String = txtFirstName.Text.Trim()
    Dim lastName As String = txtLastName.Text.Trim()
    Dim cf As String = txtCodiceFiscale.Text.Trim()
    Dim phone As String = txtPhone.Text.Trim()
    Dim email As String = txtEmail.Text.Trim()
    Dim anamnesi As String = txtAnamnesi.Text.Trim()

    ' Controllo Formato CF
    If Not String.IsNullOrEmpty(cf) AndAlso cf.Length < 16 Then
        MessageBox.Show("Il Codice Fiscale deve essere di 16 caratteri.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        txtCodiceFiscale.Focus()
        Return
    End If

    ' Controllo Formato Email
    If Not String.IsNullOrEmpty(email) Then
        Dim emailRegex As New Regex("^[^@\s]+@[^@\s]+\.[^@\s]+$")
        If Not emailRegex.IsMatch(email) Then
            MessageBox.Show("L'indirizzo email inserito non è valido.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmail.Focus()
            Return
        End If
    End If

    ' Prepara i contatti per il database
    Dim contacts As String = ""
    If Not String.IsNullOrEmpty(phone) Then contacts &= "Tel: " & phone
    If Not String.IsNullOrEmpty(email) Then contacts &= If(contacts.Length > 0, " | ", "") & "Email: " & email

    ' Salvataggio reale
    Try
        DBHelper.InsertPatient(firstName, lastName, cf, contacts, anamnesi)
        MessageBox.Show("Paziente registrato con successo!", "Conferma", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.DialogResult = DialogResult.OK
        Me.Close()
    Catch ex As Exception
        MessageBox.Show("Errore durante il salvataggio: " & ex.Message, "Errore DB", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
End Sub

End Class