Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Text.RegularExpressions

Public Class FormEditPatient
    Inherits Form

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property PatientId As Integer

    Private colorPrimary As Color = Color.FromArgb(74, 101, 114)
    Private colorDisabled As Color = Color.FromArgb(220, 220, 220)
    Private colorText As Color = Color.FromArgb(60, 60, 60)

    Private WithEvents txtFirstName As New TextBox()
    Private WithEvents txtLastName As New TextBox()
    Private WithEvents txtPhone As New TextBox()
    Private WithEvents txtEmail As New TextBox()
    Private WithEvents txtCodiceFiscale As New TextBox()
    Private WithEvents btnSave As New Button()
    Private WithEvents btnCancel As New Button()

    Public Sub New()
        Me.SuspendLayout()
        Me.Text = "Modifica Paziente"
        Me.Size = New Size(520, 360) ' Più bassa perché non c'è l'anamnesi qui
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.StartPosition = FormStartPosition.CenterParent
        Me.MaximizeBox = False
        Me.BackColor = Color.White
        Me.Font = New Font("Segoe UI", 9.75F)

        Dim lblNome As New Label() With {.Text = "Nome *", .Location = New Point(25, 20), .AutoSize = True, .ForeColor = colorText}
        txtFirstName.Location = New Point(25, 45)
        txtFirstName.Size = New Size(210, 25)

        Dim lblCognome As New Label() With {.Text = "Cognome *", .Location = New Point(265, 20), .AutoSize = True, .ForeColor = colorText}
        txtLastName.Location = New Point(265, 45)
        txtLastName.Size = New Size(210, 25)

        Dim lblTelefono As New Label() With {.Text = "Telefono", .Location = New Point(25, 90), .AutoSize = True, .ForeColor = colorText}
        txtPhone.Location = New Point(25, 115)
        txtPhone.Size = New Size(210, 25)

        Dim lblEmail As New Label() With {.Text = "Email", .Location = New Point(265, 90), .AutoSize = True, .ForeColor = colorText}
        txtEmail.Location = New Point(265, 115)
        txtEmail.Size = New Size(210, 25)

        Dim lblCF As New Label() With {.Text = "Codice Fiscale", .Location = New Point(25, 160), .AutoSize = True, .ForeColor = colorText}
        txtCodiceFiscale.Location = New Point(25, 185)
        txtCodiceFiscale.Size = New Size(210, 25)
        txtCodiceFiscale.CharacterCasing = CharacterCasing.Upper
        txtCodiceFiscale.MaxLength = 16

        btnCancel.Text = "Annulla"
        btnCancel.Location = New Point(265, 250)
        btnCancel.Size = New Size(100, 36)
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.BackColor = Color.FromArgb(240, 240, 240)

        btnSave.Text = "Salva Dati"
        btnSave.Location = New Point(375, 250)
        btnSave.Size = New Size(100, 36)
        btnSave.FlatStyle = FlatStyle.Flat

        Me.Controls.AddRange(New Control() {lblNome, txtFirstName, lblCognome, txtLastName, lblTelefono, txtPhone, lblEmail, txtEmail, lblCF, txtCodiceFiscale, btnCancel, btnSave})
        Me.ResumeLayout(False)
    End Sub
    Private Sub FormEditPatient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Carica i dati attuali del paziente
            Dim dt = DBHelper.GetAllPatients()
            Dim rows = dt.Select("Id = " & PatientId)

            If rows.Length > 0 Then
                Dim row = rows(0)
                txtFirstName.Text = row("FirstName").ToString()
                txtLastName.Text = row("LastName").ToString()
                txtCodiceFiscale.Text = row("CodiceFiscale").ToString()

                ' Divide i contatti nei rispettivi campi se formattati come "Tel: X | Email: Y"
                Dim contacts = row("Contacts").ToString()
                Dim parts = contacts.Split("|"c)
                For Each part In parts
                    If part.Trim().StartsWith("Tel:") Then txtPhone.Text = part.Replace("Tel:", "").Trim()
                    If part.Trim().StartsWith("Email:") Then txtEmail.Text = part.Replace("Email:", "").Trim()
                Next
            End If
        Catch ex As Exception
        End Try
        UpdateSaveButtonState()
    End Sub

    Private Sub RequiredFields_TextChanged(sender As Object, e As EventArgs) Handles txtFirstName.TextChanged, txtLastName.TextChanged
        UpdateSaveButtonState()
    End Sub

    Private Sub UpdateSaveButtonState()
        Dim canSave As Boolean = Not String.IsNullOrWhiteSpace(txtFirstName.Text) AndAlso Not String.IsNullOrWhiteSpace(txtLastName.Text)
        btnSave.Enabled = canSave
        btnSave.BackColor = If(canSave, colorPrimary, colorDisabled)
        btnSave.ForeColor = If(canSave, Color.White, Color.DimGray)
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

        ' --- 1. CONTROLLO CODICE FISCALE ---
        ' Se è stato inserito qualcosa, controlla che siano esattamente 16 caratteri
        If Not String.IsNullOrEmpty(cf) AndAlso cf.Length <> 16 Then
            MessageBox.Show("Il Codice Fiscale deve essere di 16 caratteri.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCodiceFiscale.Focus() ' Riporta il cursore sulla casella errata
            Return
        End If

        ' --- 2. CONTROLLO EMAIL ---
        ' Se è stata inserita un'email, verifica che abbia la chiocciola e un formato valido
        If Not String.IsNullOrEmpty(email) Then
            Dim emailRegex As New Regex("^[^@\s]+@[^@\s]+\.[^@\s]+$")
            If Not emailRegex.IsMatch(email) Then
                MessageBox.Show("L'indirizzo email inserito non ha un formato valido.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtEmail.Focus() ' Riporta il cursore sulla casella errata
                Return
            End If
        End If

        ' --- 3. SALVATAGGIO ---
        Dim contacts As String = ""
        If Not String.IsNullOrEmpty(phone) Then contacts &= "Tel: " & phone
        If Not String.IsNullOrEmpty(email) Then contacts &= If(contacts.Length > 0, " | ", "") & "Email: " & email

        Try
            DBHelper.UpdatePatient(PatientId, firstName, lastName, cf, contacts)
            MessageBox.Show("Dati anagrafici aggiornati!", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Errore: " & ex.Message, "Errore DB", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class