Imports System.Drawing
Imports System.IO

Public Module Theme
    Public ReadOnly PrimaryColor As Color = Color.FromArgb(37, 99, 235)
    Public ReadOnly SecondaryColor As Color = Color.FromArgb(30, 41, 59)
    Public ReadOnly DangerColor As Color = Color.FromArgb(220, 53, 69)
    Public ReadOnly NeutralButtonColor As Color = Color.FromArgb(100, 116, 139)
    Public ReadOnly AccentColor As Color = Color.FromArgb(244, 208, 63)
    Public ReadOnly TextColor As Color = Color.FromArgb(240, 240, 240)
    Public ReadOnly MutedText As Color = Color.FromArgb(200, 200, 200)
    Public ReadOnly DefaultFontName As String = "Segoe UI"
    Public ReadOnly SurfaceColor As Color = Color.FromArgb(248, 250, 252)
    Public ReadOnly BorderColor As Color = Color.FromArgb(214, 220, 228)

    Public Sub ApplyTheme(frm As Form)
        Try
            frm.BackgroundImage = Nothing
            frm.BackColor = SurfaceColor
            frm.ForeColor = PrimaryColor
            frm.Font = New Font(DefaultFontName, 9.5!, FontStyle.Regular)
            For Each ctrl As Control In frm.Controls
                ApplyControlTheme(ctrl)
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ApplyControlTheme(ctrl As Control)
        Try
            If TypeOf ctrl Is Button Then
                Dim b = DirectCast(ctrl, Button)
                Dim buttonColor = NeutralButtonColor
                Dim buttonText = (b.Text & " " & b.Name).ToLowerInvariant()
                If buttonText.Contains("elimina") OrElse buttonText.Contains("delete") Then
                    buttonColor = DangerColor
                ElseIf buttonText.Contains("cerca") OrElse buttonText.Contains("nuovo") OrElse buttonText.Contains("aggiungi") OrElse buttonText.Contains("accedi") Then
                    buttonColor = PrimaryColor
                End If
                b.BackColor = buttonColor
                b.ForeColor = TextColor
                b.FlatStyle = FlatStyle.Flat
                b.FlatAppearance.BorderSize = 0
                b.Font = New Font(DefaultFontName, 9.5!, FontStyle.Bold)
                b.MinimumSize = New Size(0, 36)
                b.Padding = New Padding(12, 6, 12, 6)
                b.Cursor = Cursors.Hand
                If b.Tag Is Nothing Then
                    b.Tag = buttonColor
                    AddHandler b.MouseEnter, Sub(sender As Object, e As EventArgs)
                                                 Dim hovered = DirectCast(sender, Button)
                                                 hovered.BackColor = ControlPaint.Dark(DirectCast(hovered.Tag, Color), 0.12F)
                                             End Sub
                    AddHandler b.MouseLeave, Sub(sender As Object, e As EventArgs)
                                                 Dim normal = DirectCast(sender, Button)
                                                 normal.BackColor = DirectCast(normal.Tag, Color)
                                             End Sub
                End If
            ElseIf TypeOf ctrl Is Label Then
                Dim l = DirectCast(ctrl, Label)
                l.ForeColor = PrimaryColor
                If l.Name.ToLowerInvariant().Contains("treatment") OrElse l.Name.ToLowerInvariant().Contains("welcome") OrElse l.Name.ToLowerInvariant().Contains("title") Then
                    l.Font = New Font(DefaultFontName, 11.0!, FontStyle.Bold)
                Else
                    l.Font = New Font(DefaultFontName, 9.5!, FontStyle.Regular)
                End If
            ElseIf TypeOf ctrl Is TextBox Then
                Dim t = DirectCast(ctrl, TextBox)
                t.BackColor = Color.FromArgb(255, 255, 255)
                t.ForeColor = Color.Black
                t.Font = New Font(DefaultFontName, 9.5!, FontStyle.Regular)
                t.BorderStyle = BorderStyle.FixedSingle
                t.Padding = New Padding(8, 4, 8, 4)
            ElseIf TypeOf ctrl Is DataGridView Then
                Dim d = DirectCast(ctrl, DataGridView)
                d.BackgroundColor = Color.FromArgb(250, 250, 250)
                d.ForeColor = Color.Black
                d.EnableHeadersVisualStyles = False
                d.ColumnHeadersDefaultCellStyle.BackColor = SecondaryColor
                d.ColumnHeadersDefaultCellStyle.ForeColor = TextColor
                d.ColumnHeadersDefaultCellStyle.Font = New Font(DefaultFontName, 9.0!, FontStyle.Bold)
                d.ColumnHeadersDefaultCellStyle.Padding = New Padding(6, 4, 6, 4)
                d.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                d.ColumnHeadersHeight = 36
                d.RowHeadersVisible = False
                d.GridColor = BorderColor
                d.BackgroundColor = Color.White
                d.BorderStyle = BorderStyle.FixedSingle
                d.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
                d.RowTemplate.Height = 32
                d.DefaultCellStyle.Font = New Font(DefaultFontName, 9.5!, FontStyle.Regular)
                d.DefaultCellStyle.Padding = New Padding(6, 3, 6, 3)
                d.DefaultCellStyle.SelectionBackColor = Color.FromArgb(218, 233, 250)
                d.DefaultCellStyle.SelectionForeColor = Color.FromArgb(35, 45, 60)
                d.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 249, 252)
                d.RowsDefaultCellStyle.BackColor = Color.White
                d.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                d.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
                d.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            ElseIf TypeOf ctrl Is Panel Then
                Dim p = DirectCast(ctrl, Panel)
                p.BackColor = PrimaryColor
            End If

            ' Ricorsione per child
            For Each child As Control In ctrl.Controls
                ApplyControlTheme(child)
            Next
        Catch ex As Exception
        End Try
    End Sub
End Module
