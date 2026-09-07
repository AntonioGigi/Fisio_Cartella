Public Class FormDashboard
    Private Sub FormDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Session.IsAuthenticated() Then
            MessageBox.Show("Accesso non autorizzato. Effettua il login.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
            Return
        End If

        lblWelcome.Text = $"Benvenuto, {Session.CurrentUser}"
        ModernizzaDashboard()
        AddHandler Me.Resize, AddressOf FormDashboard_Resize
        ' registra handler dinamicamente (designer non usa WithEvents)
        AddHandler btnPatients.Click, AddressOf btnPatients_Click
        AddHandler btnUsers.Click, AddressOf btnUsers_Click
        AddHandler btnCalendar.Click, AddressOf btnCalendar_Click
        AddHandler btnInvoices.Click, AddressOf btnInvoices_Click
        AddHandler btnLogout.Click, AddressOf btnLogout_Click
    End Sub

    Private Sub ModernizzaDashboard()
        ' Palette moderna ispirata a Fluent/Material Design.
        Dim formBackground = Color.FromArgb(251, 251, 252)
        Dim textColor = Color.FromArgb(32, 33, 36)
        Dim accentColor = Color.FromArgb(79, 70, 229)
        Dim cardColor = Color.FromArgb(243, 244, 246)
        Dim hoverColor = Color.FromArgb(229, 231, 235)
        Dim cardBorder = Color.FromArgb(226, 232, 240)

        BackColor = formBackground
        ForeColor = textColor
        Font = New Font("Segoe UI", 9.5!, FontStyle.Regular)
        MinimumSize = New Size(820, 560)

        ' Titolo della dashboard.
        lblWelcome.Text = $"Benvenuto, {Session.CurrentUser}"
        lblWelcome.AutoSize = True
        lblWelcome.Font = New Font("Segoe UI", 20.0!, FontStyle.Regular)
        lblWelcome.ForeColor = Color.FromArgb(55, 81, 145)
        lblWelcome.Location = New Point(32, 28)

        ' Griglia centrale: tre card per riga, centrate e responsive.
        tlpButtons.AutoSize = False
        tlpButtons.GrowStyle = TableLayoutPanelGrowStyle.FixedSize
        tlpButtons.ColumnCount = 3
        tlpButtons.RowCount = 2
        tlpButtons.Size = New Size(840, 300)
        tlpButtons.Padding = New Padding(4)
        tlpButtons.BackColor = formBackground
        tlpButtons.ColumnStyles.Clear()
        tlpButtons.RowStyles.Clear()
        For i As Integer = 0 To 2
            tlpButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333!))
        Next
        For i As Integer = 0 To 1
            tlpButtons.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0!))
        Next

        For Each control As Control In tlpButtons.Controls
            If TypeOf control Is Button Then
                Dim card = DirectCast(control, Button)
                Dim normalColor = cardColor
                Dim isActive = card.Name.ToLowerInvariant().Contains("settings") OrElse card.Text.ToLowerInvariant().Contains("impostazioni")

                card.FlatStyle = FlatStyle.Flat
                card.FlatAppearance.BorderSize = 0
                card.FlatAppearance.MouseDownBackColor = hoverColor
                card.UseVisualStyleBackColor = False
                card.BackColor = If(isActive, accentColor, normalColor)
                card.ForeColor = If(isActive, Color.White, textColor)
                card.Font = New Font("Segoe UI", 12.0!, FontStyle.Regular)
                card.TextAlign = ContentAlignment.MiddleCenter
                card.Padding = New Padding(18, 14, 18, 14)
                card.Margin = New Padding(10)
                card.Dock = DockStyle.Fill
                card.MinimumSize = New Size(220, 120)
                card.Cursor = Cursors.Hand

                ' Bordo sottile neutro per simulare una card senza usare colori di sistema.
                card.FlatAppearance.BorderColor = cardBorder

                Dim caption = card.Text
                Select Case card.Name
                    Case "btnPatients"
                        caption = "♙" & Environment.NewLine & "Pazienti"
                    Case "btnUsers"
                        caption = "♙" & Environment.NewLine & "Utenti"
                    Case "btnInvoices"
                        caption = "▤" & Environment.NewLine & "Fatturazione"
                    Case "btnCalendar"
                        caption = "▦" & Environment.NewLine & "Calendario"
                    Case "btnLogout"
                        caption = "⏻" & Environment.NewLine & "Logout"
                End Select
                card.Text = caption

                Dim baseColor = card.BackColor
                Dim overColor = If(isActive, ControlPaint.Light(accentColor, 0.08F), hoverColor)
                AddHandler card.MouseEnter, Sub(sender As Object, e As EventArgs)
                                                 DirectCast(sender, Button).BackColor = overColor
                                             End Sub
                AddHandler card.MouseLeave, Sub(sender As Object, e As EventArgs)
                                                 DirectCast(sender, Button).BackColor = baseColor
                                             End Sub
            End If
        Next

        CenterButtonsPanel()
    End Sub

    Private Sub btnPatients_Click(sender As Object, e As EventArgs)
        Try
            Dim f As New FormPatients()
            f.ShowDialog()
        Catch ex As Exception
            MessageBox.Show($"Errore durante l'apertura della finestra Pazienti:\n{ex.ToString()}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUsers_Click(sender As Object, e As EventArgs)
        Dim f As New FormUsers()
        f.ShowDialog()
    End Sub

    Private Sub btnCalendar_Click(sender As Object, e As EventArgs)
        Dim f As New FormCalendar()
        f.ShowDialog()
    End Sub


    Private Sub btnInvoices_Click(sender As Object, e As EventArgs)
        Dim f As New FormInvoices()
        f.ShowDialog()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs)
        Session.CurrentUser = Nothing
        ' Torna al login
        Dim login As New Form1()
        login.Show()
        Me.Close()
    End Sub

    Private Sub FormDashboard_Resize(sender As Object, e As EventArgs)
        CenterButtonsPanel()
    End Sub

    Private Sub CenterButtonsPanel()
        Try
            If tlpButtons Is Nothing Then Return
            Dim x = Math.Max(24, (Me.ClientSize.Width - tlpButtons.Width) \ 2)
            Dim y = Math.Max(56, (Me.ClientSize.Height - tlpButtons.Height) \ 2)
            tlpButtons.Location = New Point(x, y)
        Catch ex As Exception
        End Try
    End Sub
End Class
