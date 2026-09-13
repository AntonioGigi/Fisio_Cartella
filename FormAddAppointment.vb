Imports System.ComponentModel
Public Class FormNuovoAppuntamento
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property InitialStartDate As DateTime = DateTime.Now
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property InitialEndDate As DateTime = DateTime.Now.AddHours(1)
    Private Sub FormNuovoAppuntamento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Impostazioni opzionali di avvio
        If InitialStartDate <> DateTime.MinValue Then
            dtpInizio.Value = InitialStartDate
        End If

        If InitialEndDate <> DateTime.MinValue Then
            dtpFine.Value = InitialEndDate
        End If
        cboTipoPagamento.Items.Clear()
        cboTipoPagamento.DropDownStyle = ComboBoxStyle.DropDownList
        cboTipoPagamento.Items.AddRange(New String() {"Contanti", "Carta di Credito", "Bonifico", "Assegno", "Pacchetto/ciclo"})
        cboTipoPagamento.SelectedIndex = 0
        CaricaPazienti()
    End Sub
    Private Sub CaricaPazienti()
        Try
            ' Recupera la DataTable usando la stessa classe del FormPatients
            Dim dt As DataTable = DBHelper.GetAllPatients()

            ' Aggiunge una colonna calcolata "NomeCompleto" per la visualizzazione nel menu
            If Not dt.Columns.Contains("NomeCompleto") Then
                dt.Columns.Add("NomeCompleto", GetType(String), "LastName + ' ' + FirstName")
            End If

            ' Binding alla ComboBox
            cboPaziente.DataSource = dt
            cboPaziente.DisplayMember = "NomeCompleto" ' Mostra "Cognome Nome"
            cboPaziente.ValueMember = "Id"             ' Associa l'ID del record
            cboPaziente.SelectedIndex = -1             ' Parte senza selezione attiva
        Catch ex As Exception
            MessageBox.Show("Errore durante il caricamento dei pazienti: " & ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnSalva_Click(sender As Object, e As EventArgs) Handles btnSalva.Click
        ' Validazione dati di base
        If cboPaziente.SelectedValue Is Nothing OrElse cboPaziente.SelectedIndex = -1 Then
            MessageBox.Show("Seleziona un paziente.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim patientId As Integer = Convert.ToInt32(cboPaziente.SelectedValue)
            Dim startDate As DateTime = dtpInizio.Value
            Dim endDate As DateTime = dtpFine.Value
            Dim price As Decimal = 0
            Decimal.TryParse(txtPrezzo.Text, price)
            Dim notes As String = txtNote.Text.Trim()
            Dim paymentMode As String = If(cboTipoPagamento.SelectedItem IsNot Nothing, cboTipoPagamento.SelectedItem.ToString(), "")

            ' 1. Esegui la funzione di salvataggio nel database tramite DBHelper
            ' (usa il nome effettivo del metodo presente nel tuo DBHelper)
            DBHelper.InsertAppointment(patientId, startDate, endDate, price, notes, paymentMode)

            ' 2. FONDAMENTALE: comunica a FormCalendar che il salvataggio è andato a buon fine
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Errore durante il salvataggio: " & ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAnnulla_Click(sender As Object, e As EventArgs) Handles btnAnnulla.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
