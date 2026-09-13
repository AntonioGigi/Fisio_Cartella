<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormNuovoAppuntamento
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    ' Controlli dell'interfaccia
    Friend WithEvents tlpRoot As TableLayoutPanel
    Friend WithEvents lblPaziente As Label
    Friend WithEvents cboPaziente As ComboBox
    Friend WithEvents tlpDate As TableLayoutPanel
    Friend WithEvents lblInizio As Label
    Friend WithEvents dtpInizio As DateTimePicker
    Friend WithEvents lblFine As Label
    Friend WithEvents dtpFine As DateTimePicker
    Friend WithEvents tlpPagamentoPrezzo As TableLayoutPanel
    Friend WithEvents lblTipoPagamento As Label
    Friend WithEvents cboTipoPagamento As ComboBox
    Friend WithEvents lblPrezzo As Label
    Friend WithEvents txtPrezzo As TextBox
    Friend WithEvents lblNote As Label
    Friend WithEvents txtNote As TextBox
    Friend WithEvents flpPulsanti As FlowLayoutPanel
    Friend WithEvents btnAnnulla As Button
    Friend WithEvents btnSalva As Button

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.tlpRoot = New System.Windows.Forms.TableLayoutPanel()
        Me.lblPaziente = New System.Windows.Forms.Label()
        Me.cboPaziente = New System.Windows.Forms.ComboBox()
        Me.tlpDate = New System.Windows.Forms.TableLayoutPanel()
        Me.lblInizio = New System.Windows.Forms.Label()
        Me.dtpInizio = New System.Windows.Forms.DateTimePicker()
        Me.lblFine = New System.Windows.Forms.Label()
        Me.dtpFine = New System.Windows.Forms.DateTimePicker()
        Me.tlpPagamentoPrezzo = New System.Windows.Forms.TableLayoutPanel()
        Me.lblTipoPagamento = New System.Windows.Forms.Label()
        Me.cboTipoPagamento = New System.Windows.Forms.ComboBox()
        Me.lblPrezzo = New System.Windows.Forms.Label()
        Me.txtPrezzo = New System.Windows.Forms.TextBox()
        Me.lblNote = New System.Windows.Forms.Label()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.flpPulsanti = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnSalva = New System.Windows.Forms.Button()
        Me.btnAnnulla = New System.Windows.Forms.Button()
        Me.tlpRoot.SuspendLayout()
        Me.tlpDate.SuspendLayout()
        Me.tlpPagamentoPrezzo.SuspendLayout()
        Me.flpPulsanti.SuspendLayout()
        Me.SuspendLayout()
        '
        ' tlpRoot (Contenitore principale)
        '
        Me.tlpRoot.ColumnCount = 1
        Me.tlpRoot.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpRoot.Controls.Add(Me.lblPaziente, 0, 0)
        Me.tlpRoot.Controls.Add(Me.cboPaziente, 0, 1)
        Me.tlpRoot.Controls.Add(Me.tlpDate, 0, 2)
        Me.tlpRoot.Controls.Add(Me.tlpPagamentoPrezzo, 0, 3)
        Me.tlpRoot.Controls.Add(Me.lblNote, 0, 4)
        Me.tlpRoot.Controls.Add(Me.txtNote, 0, 5)
        Me.tlpRoot.Controls.Add(Me.flpPulsanti, 0, 6)
        Me.tlpRoot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpRoot.Location = New System.Drawing.Point(0, 0)
        Me.tlpRoot.Name = "tlpRoot"
        Me.tlpRoot.Padding = New System.Windows.Forms.Padding(18)
        Me.tlpRoot.RowCount = 7
        Me.tlpRoot.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.tlpRoot.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.tlpRoot.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tlpRoot.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tlpRoot.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.tlpRoot.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpRoot.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.tlpRoot.Size = New System.Drawing.Size(430, 430)
        Me.tlpRoot.TabIndex = 0
        '
        ' lblPaziente
        '
        Me.lblPaziente.AutoSize = True
        Me.lblPaziente.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPaziente.ForeColor = System.Drawing.Color.FromArgb(70, 80, 95)
        Me.lblPaziente.Location = New System.Drawing.Point(18, 18)
        Me.lblPaziente.Name = "lblPaziente"
        Me.lblPaziente.Size = New System.Drawing.Size(55, 15)
        Me.lblPaziente.Text = "Paziente"
        '
        ' cboPaziente
        '
        Me.cboPaziente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboPaziente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPaziente.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.cboPaziente.Location = New System.Drawing.Point(21, 43)
        Me.cboPaziente.Name = "cboPaziente"
        Me.cboPaziente.Size = New System.Drawing.Size(388, 25)
        Me.cboPaziente.TabIndex = 0
        '
        ' tlpDate
        '
        Me.tlpDate.ColumnCount = 2
        Me.tlpDate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpDate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpDate.Controls.Add(Me.lblInizio, 0, 0)
        Me.tlpDate.Controls.Add(Me.dtpInizio, 0, 1)
        Me.tlpDate.Controls.Add(Me.lblFine, 1, 0)
        Me.tlpDate.Controls.Add(Me.dtpFine, 1, 1)
        Me.tlpDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpDate.Location = New System.Drawing.Point(18, 76)
        Me.tlpDate.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpDate.Name = "tlpDate"
        Me.tlpDate.RowCount = 2
        Me.tlpDate.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.tlpDate.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpDate.Size = New System.Drawing.Size(394, 60)
        Me.tlpDate.TabIndex = 1
        '
        ' lblInizio
        '
        Me.lblInizio.AutoSize = True
        Me.lblInizio.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblInizio.ForeColor = System.Drawing.Color.FromArgb(70, 80, 95)
        Me.lblInizio.Location = New System.Drawing.Point(0, 0)
        Me.lblInizio.Name = "lblInizio"
        Me.lblInizio.Size = New System.Drawing.Size(74, 15)
        Me.lblInizio.Text = "Inizio seduta"
        '
        ' dtpInizio
        '
        Me.dtpInizio.CustomFormat = "yyyy-MM-dd HH:mm"
        Me.dtpInizio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpInizio.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.dtpInizio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpInizio.Location = New System.Drawing.Point(0, 25)
        Me.dtpInizio.Margin = New System.Windows.Forms.Padding(0, 3, 6, 0)
        Me.dtpInizio.Name = "dtpInizio"
        Me.dtpInizio.Size = New System.Drawing.Size(191, 25)
        Me.dtpInizio.TabIndex = 0
        '
        ' lblFine
        '
        Me.lblFine.AutoSize = True
        Me.lblFine.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblFine.ForeColor = System.Drawing.Color.FromArgb(70, 80, 95)
        Me.lblFine.Location = New System.Drawing.Point(203, 0)
        Me.lblFine.Margin = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblFine.Name = "lblFine"
        Me.lblFine.Size = New System.Drawing.Size(66, 15)
        Me.lblFine.Text = "Fine seduta"
        '
        ' dtpFine
        '
        Me.dtpFine.CustomFormat = "yyyy-MM-dd HH:mm"
        Me.dtpFine.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpFine.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.dtpFine.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFine.Location = New System.Drawing.Point(203, 25)
        Me.dtpFine.Margin = New System.Windows.Forms.Padding(6, 3, 0, 0)
        Me.dtpFine.Name = "dtpFine"
        Me.dtpFine.Size = New System.Drawing.Size(191, 25)
        Me.dtpFine.TabIndex = 1
        '
        ' tlpPagamentoPrezzo
        '
        Me.tlpPagamentoPrezzo.ColumnCount = 2
        Me.tlpPagamentoPrezzo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.tlpPagamentoPrezzo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.tlpPagamentoPrezzo.Controls.Add(Me.lblTipoPagamento, 0, 0)
        Me.tlpPagamentoPrezzo.Controls.Add(Me.cboTipoPagamento, 0, 1)
        Me.tlpPagamentoPrezzo.Controls.Add(Me.lblPrezzo, 1, 0)
        Me.tlpPagamentoPrezzo.Controls.Add(Me.txtPrezzo, 1, 1)
        Me.tlpPagamentoPrezzo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPagamentoPrezzo.Location = New System.Drawing.Point(18, 136)
        Me.tlpPagamentoPrezzo.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpPagamentoPrezzo.Name = "tlpPagamentoPrezzo"
        Me.tlpPagamentoPrezzo.RowCount = 2
        Me.tlpPagamentoPrezzo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.tlpPagamentoPrezzo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPagamentoPrezzo.Size = New System.Drawing.Size(394, 60)
        Me.tlpPagamentoPrezzo.TabIndex = 2
        '
        ' lblTipoPagamento
        '
        Me.lblTipoPagamento.AutoSize = True
        Me.lblTipoPagamento.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipoPagamento.ForeColor = System.Drawing.Color.FromArgb(70, 80, 95)
        Me.lblTipoPagamento.Location = New System.Drawing.Point(0, 0)
        Me.lblTipoPagamento.Name = "lblTipoPagamento"
        Me.lblTipoPagamento.Size = New System.Drawing.Size(95, 15)
        Me.lblTipoPagamento.Text = "Tipo pagamento"
        '
        ' cboTipoPagamento
        '
        Me.cboTipoPagamento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboTipoPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoPagamento.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.cboTipoPagamento.Location = New System.Drawing.Point(0, 25)
        Me.cboTipoPagamento.Margin = New System.Windows.Forms.Padding(0, 3, 6, 0)
        Me.cboTipoPagamento.Name = "cboTipoPagamento"
        Me.cboTipoPagamento.Size = New System.Drawing.Size(230, 25)
        Me.cboTipoPagamento.TabIndex = 0
        '
        ' lblPrezzo
        '
        Me.lblPrezzo.AutoSize = True
        Me.lblPrezzo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPrezzo.ForeColor = System.Drawing.Color.FromArgb(70, 80, 95)
        Me.lblPrezzo.Location = New System.Drawing.Point(242, 0)
        Me.lblPrezzo.Margin = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblPrezzo.Name = "lblPrezzo"
        Me.lblPrezzo.Size = New System.Drawing.Size(62, 15)
        Me.lblPrezzo.Text = "Prezzo (€)"
        '
        ' txtPrezzo
        '
        Me.txtPrezzo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPrezzo.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtPrezzo.Location = New System.Drawing.Point(242, 25)
        Me.txtPrezzo.Margin = New System.Windows.Forms.Padding(6, 3, 0, 0)
        Me.txtPrezzo.Name = "txtPrezzo"
        Me.txtPrezzo.Size = New System.Drawing.Size(152, 25)
        Me.txtPrezzo.TabIndex = 1
        '
        ' lblNote
        '
        Me.lblNote.AutoSize = True
        Me.lblNote.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblNote.ForeColor = System.Drawing.Color.FromArgb(70, 80, 95)
        Me.lblNote.Location = New System.Drawing.Point(18, 196)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Size = New System.Drawing.Size(35, 15)
        Me.lblNote.Text = "Note"
        '
        ' txtNote
        '
        Me.txtNote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNote.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtNote.Location = New System.Drawing.Point(21, 221)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNote.Size = New System.Drawing.Size(388, 88)
        Me.txtNote.TabIndex = 3
        '
        ' flpPulsanti
        '
        Me.flpPulsanti.Controls.Add(Me.btnSalva)
        Me.flpPulsanti.Controls.Add(Me.btnAnnulla)
        Me.flpPulsanti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpPulsanti.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpPulsanti.Location = New System.Drawing.Point(18, 315)
        Me.flpPulsanti.Margin = New System.Windows.Forms.Padding(0)
        Me.flpPulsanti.Name = "flpPulsanti"
        Me.flpPulsanti.Padding = New System.Windows.Forms.Padding(0, 8, 0, 0)
        Me.flpPulsanti.Size = New System.Drawing.Size(394, 48)
        Me.flpPulsanti.TabIndex = 4
        '
        ' btnSalva
        '
        Me.btnSalva.BackColor = System.Drawing.Color.FromArgb(58, 77, 96)
        Me.btnSalva.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalva.FlatAppearance.BorderSize = 0
        Me.btnSalva.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalva.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSalva.ForeColor = System.Drawing.Color.White
        Me.btnSalva.Location = New System.Drawing.Point(289, 8)
        Me.btnSalva.Margin = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnSalva.Name = "btnSalva"
        Me.btnSalva.Size = New System.Drawing.Size(105, 34)
        Me.btnSalva.Text = "Salva"
        Me.btnSalva.UseVisualStyleBackColor = False
        '
        ' btnAnnulla
        '
        Me.btnAnnulla.BackColor = System.Drawing.Color.White
        Me.btnAnnulla.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAnnulla.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 205, 212)
        Me.btnAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAnnulla.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAnnulla.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60)
        Me.btnAnnulla.Location = New System.Drawing.Point(184, 8)
        Me.btnAnnulla.Name = "btnAnnulla"
        Me.btnAnnulla.Size = New System.Drawing.Size(95, 34)
        Me.btnAnnulla.Text = "Annulla"
        Me.btnAnnulla.UseVisualStyleBackColor = False
        '
        ' FormNuovoAppuntamento
        '
        Me.AcceptButton = Me.btnSalva
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(248, 249, 250)
        Me.CancelButton = Me.btnAnnulla
        Me.ClientSize = New System.Drawing.Size(430, 430)
        Me.Controls.Add(Me.tlpRoot)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormNuovoAppuntamento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Nuovo appuntamento"
        Me.tlpRoot.ResumeLayout(False)
        Me.tlpRoot.PerformLayout()
        Me.tlpDate.ResumeLayout(False)
        Me.tlpDate.PerformLayout()
        Me.tlpPagamentoPrezzo.ResumeLayout(False)
        Me.tlpPagamentoPrezzo.PerformLayout()
        Me.flpPulsanti.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
End Class
