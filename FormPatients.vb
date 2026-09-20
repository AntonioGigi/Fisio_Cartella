Imports System.Data

Public Class FormPatients
    Public Sub New()
        ' Assicurarsi che i controlli siano inizializzati prima di eseguire altro codice
        Try
            InitializeComponent()
        Catch ex As Exception
            MessageBox.Show($"Errore durante InitializeComponent di FormPatients:\n{ex.ToString()}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw
        End Try
    End Sub
    Private Sub FormPatients_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvPatients_SelectionChanged(Nothing, Nothing)
        dgvTreatments_SelectionChanged(Nothing, Nothing)
        Try
            Theme.ApplyTheme(Me)
        Catch ex As Exception
            ' Ignora errori di theming per non bloccare il caricamento
        End Try

        LoadPatients()
        LayoutPatients()
        ' Imposta la selezione dell'intera riga al click
        dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvTreatments.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        ' Nasconde la riga vuota in fondo con l'asterisco
        dgvPatients.AllowUserToAddRows = False
        dgvTreatments.AllowUserToAddRows = False

        ' Registrare l'handler per aggiornamenti dati
        Try
            AddHandler Session.DataChanged, AddressOf LoadPatients
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FormPatients_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        LayoutPatients()
    End Sub

    Private Sub LayoutPatients()
        If dgvPatients Is Nothing OrElse dgvTreatments Is Nothing Then Return
        Dim margin = 12
        Dim contentWidth = Math.Max(500, ClientSize.Width - (margin * 2))
        Dim patientTop = 58
        Dim actionsTop = Math.Max(330, (ClientSize.Height - 120) \ 2)
        Dim patientHeight = Math.Max(220, actionsTop - patientTop - 48)
        dgvPatients.Location = New Point(margin, patientTop)
        dgvPatients.Size = New Size(contentWidth, patientHeight)
        lblTreatments.Location = New Point(margin, actionsTop - 32)
        btnNew.Location = New Point(margin, actionsTop)
        btnDelete.Location = New Point(btnNew.Right + 10, actionsTop)
        btnOpenFolder.Location = New Point(btnDelete.Right + 10, actionsTop)
        btnAddTreatment.Location = New Point(btnOpenFolder.Right + 10, actionsTop)
        btnDeleteTreatment.Location = New Point(btnAddTreatment.Right + 10, actionsTop)
        Dim treatmentsTop = actionsTop + btnNew.Height + 18
        dgvTreatments.Location = New Point(margin, treatmentsTop)
        dgvTreatments.Size = New Size(contentWidth, Math.Max(120, ClientSize.Height - treatmentsTop - margin))
        txtSearch.Location = New Point(margin, 12)
        txtSearch.Width = Math.Max(260, contentWidth - 130)
        btnSearch.Location = New Point(txtSearch.Right + 10, 12)
    End Sub

    Private Sub FormatDateColumn(grid As DataGridView, columnName As String)
        If grid.Columns.Contains(columnName) Then
            grid.Columns(columnName).DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"
        End If
    End Sub

    Private Sub LoadPatients()
        Dim dt As DataTable = DBHelper.GetAllPatients()
        dgvPatients.DataSource = dt
        dgvPatients.AutoResizeColumns()
        Me.dgvPatients.AllowUserToAddRows = False
        If dgvPatients.Columns.Contains("Id") Then dgvPatients.Columns("Id").Visible = False
        ' Selezione prima riga
        If dgvPatients.Rows.Count > 0 Then
            dgvPatients.Rows(0).Selected = True
            LoadTreatmentsForSelected()
        End If
        FormatDateColumn(dgvTreatments, "TreatmentDate")
    End Sub

    Private Sub LoadTreatmentsForSelected()
        Me.dgvPatients.AllowUserToAddRows = False
        Me.dgvTreatments.AllowUserToAddRows = False
        If dgvPatients.CurrentRow Is Nothing Then
            dgvTreatments.DataSource = Nothing
            Return
        End If
        Dim idObj = dgvPatients.CurrentRow.Cells("Id").Value
        If idObj Is Nothing Then
            dgvTreatments.DataSource = Nothing
            Return
        End If
        Dim id = Convert.ToInt32(idObj)
        Dim dt As DataTable = DBHelper.GetTreatmentsByPatient(id)
        If dt.Rows.Count = 0 Then
            dgvTreatments.DataSource = Nothing
            lblTreatments.Text = "Sedute recenti (nessuna — premi 'Aggiungi seduta')"
        Else
            dgvTreatments.DataSource = dt
            dgvTreatments.AutoResizeColumns()
            lblTreatments.Text = "Sedute recenti"
        End If
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Using f As New FormNewPatient()
            ' Se il paziente viene salvato con successo, ricarica la lista
            If f.ShowDialog() = DialogResult.OK Then
                LoadPatients()
            End If
        End Using
    End Sub

    Private Sub dgvPatients_SelectionChanged(sender As Object, e As EventArgs) Handles dgvPatients.SelectionChanged
        Try
            ' 1. Verifica in modo assoluto se c'è un paziente vero selezionato
            Dim pazienteSelezionato As Boolean = False
            If dgvPatients.CurrentRow IsNot Nothing AndAlso Not dgvPatients.CurrentRow.IsNewRow Then
                pazienteSelezionato = True
            End If

            ' 2. SBLOCCA il pulsante (risolve il problema del non poter cliccare)
            If btnOpenFolder IsNot Nothing Then btnOpenFolder.Enabled = True

            ' 3. Mostra o nasconde i bottoni in base alla selezione
            If btnOpenFolder IsNot Nothing Then btnOpenFolder.Visible = pazienteSelezionato
            If btnDelete IsNot Nothing Then btnDelete.Visible = pazienteSelezionato
            If btnAddTreatment IsNot Nothing Then btnAddTreatment.Visible = pazienteSelezionato

            ' 4. Aggiorna la tabella in basso
            If pazienteSelezionato Then
                LoadTreatmentsForSelected()
            Else
                If dgvTreatments IsNot Nothing Then dgvTreatments.DataSource = Nothing
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgvTreatments_SelectionChanged(sender As Object, e As EventArgs) Handles dgvTreatments.SelectionChanged
        Try
            Dim sedutaSelezionata As Boolean = False
            If dgvTreatments.CurrentRow IsNot Nothing AndAlso Not dgvTreatments.CurrentRow.IsNewRow Then
                sedutaSelezionata = True
            End If

            If btnDeleteTreatment IsNot Nothing Then
                btnDeleteTreatment.Enabled = True
                btnDeleteTreatment.Visible = sedutaSelezionata
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgvPatients_DoubleClick(sender As Object, e As EventArgs) Handles dgvPatients.DoubleClick
        If dgvPatients.CurrentRow Is Nothing Then Return
        Dim idObj = dgvPatients.CurrentRow.Cells("Id").Value
        If idObj Is Nothing Then Return
        Dim id = Convert.ToInt32(idObj)
        Dim f As New FormClinicalRecord()
        f.PatientId = id
        f.ShowDialog()
    End Sub

    Private Sub btnAddTreatment_Click(sender As Object, e As EventArgs) Handles btnAddTreatment.Click
        If dgvPatients.CurrentRow Is Nothing Then
            MessageBox.Show("Seleziona un paziente prima di aggiungere una seduta.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim idObj = dgvPatients.CurrentRow.Cells("Id").Value
        If idObj Is Nothing Then Return
        Dim id = Convert.ToInt32(idObj)
        Dim f As New FormAddTreatment()
        f.PatientId = id
        If f.ShowDialog() = DialogResult.OK Then
            LoadTreatmentsForSelected()
        End If
    End Sub

    Private Sub btnDeleteTreatment_Click(sender As Object, e As EventArgs) Handles btnDeleteTreatment.Click
        If dgvTreatments.CurrentRow Is Nothing Then
            MessageBox.Show("Seleziona una seduta da eliminare.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim idObj = dgvTreatments.CurrentRow.Cells("Id").Value
        If idObj Is Nothing Then Return
        Dim id = Convert.ToInt32(idObj)
        If MessageBox.Show("Eliminare la seduta selezionata?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            DBHelper.DeleteTreatment(id)
            LoadTreatmentsForSelected()
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim q = txtSearch.Text.Trim().ToLower()
        If String.IsNullOrEmpty(q) Then
            LoadPatients()
            Return
        End If
        Dim dt = DBHelper.GetAllPatients()
        Dim dv = dt.DefaultView
        ' Escape single quote in query for DataView.RowFilter
        q = q.Replace("'", "''")
        dv.RowFilter = $"FirstName LIKE '%{q}%' OR LastName LIKE '%{q}%' OR CodiceFiscale LIKE '%{q}%'"
        dgvPatients.DataSource = dv.ToTable()
        If dgvPatients.Columns.Contains("Id") Then dgvPatients.Columns("Id").Visible = False
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvPatients.CurrentRow Is Nothing Then Return
        Dim idObj = dgvPatients.CurrentRow.Cells("Id").Value
        If idObj Is Nothing Then Return
        Dim id = Convert.ToInt32(idObj)
        If MessageBox.Show("Eliminare il paziente selezionato?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            DBHelper.DeletePatient(id)
            LoadPatients()
        End If
    End Sub

    Private Sub btnOpenFolder_Click(sender As Object, e As EventArgs) Handles btnOpenFolder.Click
        ' Verifica che ci sia effettivamente una riga selezionata
        If dgvPatients.CurrentRow Is Nothing Then Return

        Dim idObj = dgvPatients.CurrentRow.Cells("Id").Value
        If idObj Is Nothing Then Return

        ' Apre la FormClinicalRecord passando l'ID del paziente
        Dim id = Convert.ToInt32(idObj)
        Dim f As New FormClinicalRecord()
        f.PatientId = id
        f.ShowDialog()
    End Sub
End Class
