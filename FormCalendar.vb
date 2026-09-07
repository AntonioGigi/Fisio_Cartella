Imports System.Data

Public Class FormCalendar
    Private Sub FormCalendar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Theme.ApplyTheme(Me)
        LoadAppointmentsForDate(monthCalendar.SelectionStart)
        ' Assicura che il calendario si aggiorni quando i dati cambiano
        Try
            AddHandler Session.DataChanged, Sub() LoadAppointmentsForDate(monthCalendar.SelectionStart)
        Catch ex As Exception
        End Try
        AddHandler dgvAppointments.SelectionChanged, AddressOf dgvAppointments_SelectionChanged
        AddHandler dgvAppointments.CellDoubleClick, AddressOf dgvAppointments_CellDoubleClick
        AddHandler dgvAppointments.CurrentCellDirtyStateChanged, AddressOf dgvAppointments_CurrentCellDirtyStateChanged
        AddHandler dgvAppointments.CellContentClick, AddressOf dgvAppointments_CellContentClick
        LayoutCalendar()
    End Sub

    Private Sub FormCalendar_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        LayoutCalendar()
    End Sub

    Private Sub LayoutCalendar()
        If dgvAppointments Is Nothing OrElse monthCalendar Is Nothing Then Return
        Dim margin = 24
        Dim leftWidth = Math.Max(260, ClientSize.Width \ 4)
        monthCalendar.Location = New Point(margin, 42)
        dgvAppointments.Location = New Point(leftWidth + margin, margin)
        dgvAppointments.Size = New Size(Math.Max(420, ClientSize.Width - leftWidth - (margin * 2)), Math.Max(300, ClientSize.Height - (margin * 2)))
        btnAddAppointment.Location = New Point(margin, 250)
        btnDelete.Location = New Point(margin, 304)
    End Sub

    Private Sub monthCalendar_DateChanged(sender As Object, e As DateRangeEventArgs) Handles monthCalendar.DateChanged
        LoadAppointmentsForDate(e.Start)
    End Sub

    Private Sub dgvAppointments_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs)
        If dgvAppointments.IsCurrentCellDirty Then
            dgvAppointments.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub dgvAppointments_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        Try
            If e.RowIndex < 0 OrElse dgvAppointments.Columns(e.ColumnIndex).Name <> "PaidCheck" Then Return
            dgvAppointments.CommitEdit(DataGridViewDataErrorContexts.Commit)
            Dim row = dgvAppointments.Rows(e.RowIndex)
            Dim idObj = row.Cells("Id").Value
            Dim typeValue = row.Cells("Type").Value
            If idObj Is Nothing OrElse IsDBNull(idObj) OrElse typeValue Is Nothing OrElse typeValue.ToString() <> "Appointment" Then Return
            Dim paidBool = Convert.ToBoolean(row.Cells("PaidCheck").EditedFormattedValue)
            DBHelper.UpdateAppointmentPaid(Convert.ToInt32(idObj), paidBool)
            If Not String.IsNullOrEmpty(DBHelper.LastError) Then
                MessageBox.Show(DBHelper.LastError, "Errore aggiornamento pagamento", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show($"Errore aggiornamento pagamento:\n{ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadAppointmentsForDate(d As DateTime)
        Dim dtApp As DataTable = DBHelper.GetAppointmentsByDate(d)
        Dim dtTreat As DataTable = DBHelper.GetTreatmentsByDate(d)
        ' Ensure treatments table has Paid column so merge schema matches
        If Not dtTreat.Columns.Contains("Paid") Then
            dtTreat.Columns.Add("Paid", GetType(Integer)).DefaultValue = 0
        End If
        If Not dtTreat.Columns.Contains("Price") Then
            dtTreat.Columns.Add("Price", GetType(Double)).DefaultValue = 0.0
        End If
        ' Remove any primary key constraints to avoid PK conflicts when merging
        Try
            If dtApp.PrimaryKey IsNot Nothing AndAlso dtApp.PrimaryKey.Length > 0 Then
                dtApp.PrimaryKey = New DataColumn() {}
            End If
        Catch ex As Exception
        End Try
        Try
            If dtTreat.PrimaryKey IsNot Nothing AndAlso dtTreat.PrimaryKey.Length > 0 Then
                dtTreat.PrimaryKey = New DataColumn() {}
            End If
        Catch ex As Exception
        End Try

        ' Merge treatments into appointments table using dtApp schema to avoid DataType conflicts
        Try
            Dim merged As DataTable = dtApp.Clone()
            ' Import appointments rows
            For Each r As DataRow In dtApp.Rows
                merged.ImportRow(r)
            Next
            ' Import treatment rows converting types where necessary
            For Each tr As DataRow In dtTreat.Rows
                Dim nr As DataRow = merged.NewRow()
                For Each col As DataColumn In merged.Columns
                    If dtTreat.Columns.Contains(col.ColumnName) Then
                        Dim val = tr(col.ColumnName)
                        If val Is Nothing OrElse IsDBNull(val) Then
                            nr(col.ColumnName) = DBNull.Value
                        Else
                            Try
                                ' Try direct conversion to target type
                                nr(col.ColumnName) = Convert.ChangeType(val, col.DataType)
                            Catch ex As Exception
                                ' Fallback: use string representation for mismatched types
                                Try
                                    nr(col.ColumnName) = val.ToString()
                                Catch
                                    nr(col.ColumnName) = DBNull.Value
                                End Try
                            End Try
                        End If
                    Else
                        ' Column not present in source treatments: set DBNull
                        nr(col.ColumnName) = DBNull.Value
                    End If
                Next
                merged.Rows.Add(nr)
            Next
            dtApp = merged
        Catch ex As Exception
            ' If merging fails, fallback to simple merge which may still throw elsewhere
            Try
                dtApp.Merge(dtTreat)
            Catch ex2 As Exception
            End Try
        End Try
        ' Sort by StartDate
        dtApp.DefaultView.Sort = "StartDate ASC"

        If dgvAppointments.Columns.Contains("PaidCheck") Then
            dgvAppointments.Columns.Remove("PaidCheck")
        End If
        dgvAppointments.DataSource = dtApp.DefaultView
        dgvAppointments.AutoResizeColumns()
        If dgvAppointments.Columns.Contains("StartDate") Then dgvAppointments.Columns("StartDate").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"
        If dgvAppointments.Columns.Contains("EndDate") Then dgvAppointments.Columns("EndDate").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"
        For Each column As DataGridViewColumn In dgvAppointments.Columns
            column.ReadOnly = True
        Next
        If dgvAppointments.Columns.Contains("Id") Then dgvAppointments.Columns("Id").Visible = False
        If dgvAppointments.Columns.Contains("Paid") Then dgvAppointments.Columns("Paid").Visible = False
        If dgvAppointments.Columns.Contains("Type") Then dgvAppointments.Columns("Type").Visible = False
        ' La colonna checkbox è indipendente dal DataView: il valore viene
        ' salvato esplicitamente in DB quando cambia.
        Dim paidCheck As New DataGridViewCheckBoxColumn()
        paidCheck.Name = "PaidCheck"
        paidCheck.HeaderText = "Pagato"
        paidCheck.ReadOnly = False
        dgvAppointments.Columns.Add(paidCheck)
        For Each row As DataGridViewRow In dgvAppointments.Rows
            If row.IsNewRow Then Continue For
            Dim typeValue = row.Cells("Type").Value
            Dim isAppointment = typeValue IsNot Nothing AndAlso typeValue.ToString() = "Appointment"
            Dim paidValue = row.Cells("Paid").Value
            row.Cells("PaidCheck").Value = isAppointment AndAlso paidValue IsNot Nothing AndAlso Not IsDBNull(paidValue) AndAlso Convert.ToInt32(paidValue) <> 0
            row.Cells("PaidCheck").ReadOnly = Not isAppointment
        Next
        ' Aggiorna i giorni evidenziati nel monthCalendar per il mese selezionato
        Try
            Dim firstOfMonth = New DateTime(d.Year, d.Month, 1)
            Dim endOfMonth = firstOfMonth.AddMonths(1)
            Dim dates = DBHelper.GetEventDatesBetween(firstOfMonth, endOfMonth)
            monthCalendar.RemoveAllBoldedDates()
            For Each dt0 As DateTime In dates
                monthCalendar.AddBoldedDate(dt0)
            Next
            monthCalendar.UpdateBoldedDates()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnAddAppointment_Click(sender As Object, e As EventArgs) Handles btnAddAppointment.Click
        ' Apri dialog per aggiungere appuntamento
        Dim f As New FormAddAppointment()
        ' Imposta data iniziale sul giorno selezionato
        Try
            f.InitialStartDate = New DateTime(monthCalendar.SelectionStart.Year, monthCalendar.SelectionStart.Month, monthCalendar.SelectionStart.Day, 9, 0, 0)
            f.InitialEndDate = f.InitialStartDate.AddHours(1)
        Catch ex As Exception
        End Try
        If f.ShowDialog() = DialogResult.OK Then
            LoadAppointmentsForDate(monthCalendar.SelectionStart)
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvAppointments.CurrentRow Is Nothing Then Return
        Try
            Dim row = dgvAppointments.CurrentRow
            Dim idObj = row.Cells("Id").Value
            If idObj Is Nothing OrElse IsDBNull(idObj) Then Return
            Dim id = Convert.ToInt32(idObj)
            Dim typeValue = row.Cells("Type").Value
            Dim isTreatment = typeValue IsNot Nothing AndAlso typeValue.ToString() = "Treatment"
            Dim itemName = If(isTreatment, "seduta", "appuntamento")
            If MessageBox.Show($"Eliminare la {itemName} selezionata?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return

            If isTreatment Then
                DBHelper.DeleteTreatment(id)
            Else
                DBHelper.DeleteAppointment(id)
            End If
            LoadAppointmentsForDate(monthCalendar.SelectionStart)
        Catch ex As Exception
            MessageBox.Show($"Errore durante l'eliminazione:\n{ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvAppointments_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Return
        Try
            Dim row = dgvAppointments.Rows(e.RowIndex)
            Dim typeCol = If(row.Cells("Type") IsNot Nothing, row.Cells("Type").Value, Nothing)
            Dim idObj = If(row.Cells("Id") IsNot Nothing, row.Cells("Id").Value, Nothing)
            If idObj Is Nothing Then Return
            Dim id = Convert.ToInt32(idObj)
            Dim title = "Elimina elemento"
            Dim msg = "Eliminare l'elemento selezionato?"
            If MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If typeCol IsNot Nothing AndAlso typeCol.ToString() = "Treatment" Then
                    DBHelper.DeleteTreatment(id)
                Else
                    DBHelper.DeleteAppointment(id)
                End If
                LoadAppointmentsForDate(monthCalendar.SelectionStart)
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub dgvAppointments_SelectionChanged(sender As Object, e As EventArgs)
        ' no-op to ensure selection changed handler exists
    End Sub
End Class
