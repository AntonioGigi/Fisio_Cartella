Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class FormClinicalRecord
    Inherits Form

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property PatientId As Integer

    ' Colori tema
    Private colorPrimary As Color = Color.FromArgb(74, 101, 114)
    Private colorText As Color = Color.FromArgb(60, 60, 60)

    ' Controlli visivi (NOTA: WithEvents è fondamentale affinché i tasti funzionino)
    Private lblPatientName As New Label()
    Private WithEvents btnEditPatient As New Button()
    Private txtAnamnesi As New TextBox()
    Private WithEvents btnSaveAnamnesi As New Button()
    Private dgvSedute As New DataGridView()

    Public Sub New()
        Me.SuspendLayout()

        ' Impostazioni Finestra
        Me.Text = "Cartella Clinica"
        Me.Size = New Size(750, 600)
        Me.MinimumSize = New Size(600, 450)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.BackColor = Color.White
        Me.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)

        ' Nome Paziente (Titolo grande)
        lblPatientName.Location = New Point(20, 20)
        lblPatientName.AutoSize = True
        lblPatientName.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
        lblPatientName.ForeColor = colorPrimary

        ' Bottone Modifica Dati (Migliorato esteticamente e allineato)
        btnEditPatient.Text = "✎ Modifica Dati"
        btnEditPatient.Location = New Point(590, 20)
        btnEditPatient.Size = New Size(120, 32)
        btnEditPatient.FlatStyle = FlatStyle.Flat
        btnEditPatient.FlatAppearance.BorderSize = 0
        btnEditPatient.BackColor = Color.FromArgb(230, 235, 240)
        btnEditPatient.ForeColor = colorPrimary
        btnEditPatient.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnEditPatient.Cursor = Cursors.Hand
        btnEditPatient.Anchor = AnchorStyles.Top Or AnchorStyles.Right

        ' Sezione Anamnesi
        Dim lblAnamnesi As New Label() With {.Text = "Anamnesi / Note cliniche:", .Location = New Point(20, 65), .AutoSize = True, .ForeColor = colorText}

        txtAnamnesi.Location = New Point(20, 90)
        txtAnamnesi.Size = New Size(570, 120)
        txtAnamnesi.Multiline = True
        txtAnamnesi.ScrollBars = ScrollBars.Vertical
        txtAnamnesi.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

        ' Pulsante Salva Anamnesi
        btnSaveAnamnesi.Text = "Salva Modifiche"
        btnSaveAnamnesi.Location = New Point(600, 90)
        btnSaveAnamnesi.Size = New Size(110, 120)
        btnSaveAnamnesi.FlatStyle = FlatStyle.Flat
        btnSaveAnamnesi.FlatAppearance.BorderSize = 0
        btnSaveAnamnesi.BackColor = colorPrimary
        btnSaveAnamnesi.ForeColor = Color.White
        btnSaveAnamnesi.Cursor = Cursors.Hand
        btnSaveAnamnesi.Anchor = AnchorStyles.Top Or AnchorStyles.Right

        ' Sezione Sedute Recenti
        Dim lblSedute As New Label() With {.Text = "Sedute Recenti:", .Location = New Point(20, 230), .AutoSize = True, .ForeColor = colorText}
        dgvSedute.Location = New Point(20, 255)
        dgvSedute.Size = New Size(690, 280)
        dgvSedute.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ImpostaStileGriglia(dgvSedute)

        ' Aggiunta controlli al form
        Me.Controls.AddRange(New Control() {
            lblPatientName, btnEditPatient, lblAnamnesi, txtAnamnesi, btnSaveAnamnesi,
            lblSedute, dgvSedute
        })

        Me.ResumeLayout(False)
    End Sub

    Private Sub ImpostaStileGriglia(dgv As DataGridView)
        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = False
        dgv.ReadOnly = True
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.BackgroundColor = Color.White
        dgv.BorderStyle = BorderStyle.FixedSingle
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv.RowHeadersVisible = False
    End Sub
    Private Sub FormClinicalRecord_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CaricaDatiPaziente()
        CaricaTabelle()
    End Sub

    Private Sub CaricaDatiPaziente()
        Try
            Dim dt = DBHelper.GetAllPatients()
            Dim rows = dt.Select("Id = " & PatientId)

            If rows.Length > 0 Then
                Dim row = rows(0)
                lblPatientName.Text = row("FirstName").ToString() & " " & row("LastName").ToString()
                txtAnamnesi.Text = row("Anamnesis").ToString()
            End If
        Catch ex As Exception
            MessageBox.Show("Errore caricamento paziente: " & ex.Message)
        End Try
    End Sub

    Private Sub CaricaTabelle()
        Try
            Dim dtSedute = DBHelper.GetTreatmentsByPatient(PatientId)
            dgvSedute.DataSource = dtSedute

            If dgvSedute.Columns.Contains("Id") Then dgvSedute.Columns("Id").Visible = False
            If dgvSedute.Columns.Contains("TreatmentDate") Then
                dgvSedute.Columns("TreatmentDate").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"
                dgvSedute.Columns("TreatmentDate").HeaderText = "Data Seduta"
            End If
            If dgvSedute.Columns.Contains("Notes") Then dgvSedute.Columns("Notes").HeaderText = "Note"
            If dgvSedute.Columns.Contains("Progress") Then dgvSedute.Columns("Progress").HeaderText = "Progresso"

        Catch ex As Exception
            MessageBox.Show("Errore nel caricamento delle sedute: " & ex.Message)
        End Try
    End Sub

    ' Evento di click del tasto Modifica Dati Anagrafici
    Private Sub btnEditPatient_Click(sender As Object, e As EventArgs) Handles btnEditPatient.Click
        Dim f As New FormEditPatient()
        f.PatientId = Me.PatientId

        If f.ShowDialog() = DialogResult.OK Then
            ' Ricarica in tempo reale il nome se è stato modificato
            CaricaDatiPaziente()
        End If
    End Sub

    ' Evento di click del tasto Salva Anamnesi
    Private Sub btnSaveAnamnesi_Click(sender As Object, e As EventArgs) Handles btnSaveAnamnesi.Click
        Try
            Dim nuovaAnamnesi = txtAnamnesi.Text.Trim()
            DBHelper.UpdatePatientAnamnesis(PatientId, nuovaAnamnesi)
            MessageBox.Show("Anamnesi aggiornata con successo!", "Salvato", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Errore durante il salvataggio: " & ex.Message, "Errore DB", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class