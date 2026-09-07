Partial Public Class FormInvoices
    Private Sub FormInvoices_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Theme.ApplyTheme(Me)
        LoadInvoices()
        LayoutInvoices()
        Try
            AddHandler Session.DataChanged, AddressOf LoadInvoices
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FormInvoices_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        LayoutInvoices()
    End Sub

    Private Sub LayoutInvoices()
        If dgvMonthly Is Nothing OrElse dgvServices Is Nothing Then Return
        Dim margin = 24
        Dim summaryWidth = 270
        dgvMonthly.Location = New Point(margin, margin)
        dgvMonthly.Size = New Size(Math.Max(420, ClientSize.Width - summaryWidth - (margin * 3)), 210)
        dgvServices.Location = New Point(margin, 270)
        dgvServices.Size = New Size(Math.Max(500, ClientSize.Width - (margin * 2)), Math.Max(180, ClientSize.Height - 294))
        lblTax.Location = New Point(dgvMonthly.Right + margin, 42)
        numTax.Location = New Point(dgvMonthly.Right + margin, 70)
        lblGross.Location = New Point(dgvMonthly.Right + margin, 130)
        lblNet.Location = New Point(dgvMonthly.Right + margin, 165)
    End Sub

    Private Sub LoadInvoices()
        Try
            Dim dtMonthly = DBHelper.GetEarningsByMonth()
            dgvMonthly.DataSource = dtMonthly
            dgvMonthly.AutoResizeColumns()
            If Not String.IsNullOrEmpty(DBHelper.LastError) Then
                lblGross.Text = "Errore database: " & DBHelper.LastError.Split({Environment.NewLine}, StringSplitOptions.None)(0)
                lblNet.Text = "Totale non disponibile"
                Return
            End If
            Dim dtServices = DBHelper.GetAllServices()
            dgvServices.DataSource = dtServices
            dgvServices.AutoResizeColumns()
            If dgvServices.Columns.Contains("Id") Then dgvServices.Columns("Id").Visible = False
            If dgvServices.Columns.Contains("Date") Then dgvServices.Columns("Date").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"
            If Not String.IsNullOrEmpty(DBHelper.LastError) Then
                lblGross.Text = "Errore database: " & DBHelper.LastError.Split({Environment.NewLine}, StringSplitOptions.None)(0)
                lblNet.Text = "Totale non disponibile"
                Return
            End If
            ' Calcola totali
            Try
                Dim gross As Decimal = 0
                For Each r As DataRow In dtMonthly.Rows
                    Try
                        gross += Convert.ToDecimal(r("Total"))
                    Catch ex As Exception
            lblGross.Text = "Errore fatturazione: " & ex.Message
            lblNet.Text = "Totale non disponibile"
                    End Try
                Next
                lblGross.Text = $"Totale lordo: {gross:F2}"
                Dim taxPercent = Convert.ToDecimal(numTax.Value) / 100D
                Dim net As Decimal = gross * (1D - taxPercent)
                lblNet.Text = $"Totale netto (dopo {numTax.Value}%): {net:F2}"
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
    End Sub

    Private Sub numTax_ValueChanged(sender As Object, e As EventArgs) Handles numTax.ValueChanged
        LoadInvoices()
    End Sub
End Class

