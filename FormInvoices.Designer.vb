<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormInvoices
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.dgvMonthly = New System.Windows.Forms.DataGridView()
        Me.dgvServices = New System.Windows.Forms.DataGridView()
        Me.lblGross = New System.Windows.Forms.Label()
        Me.lblNet = New System.Windows.Forms.Label()
        Me.numTax = New System.Windows.Forms.NumericUpDown()
        Me.lblTax = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        ' dgvMonthly
        '
        Me.dgvMonthly.Location = New System.Drawing.Point(24, 24)
        Me.dgvMonthly.Name = "dgvMonthly"
        Me.dgvMonthly.ReadOnly = True
        Me.dgvMonthly.RowHeadersWidth = 51
        Me.dgvMonthly.RowTemplate.Height = 29
        Me.dgvMonthly.Size = New System.Drawing.Size(620, 210)
        Me.dgvMonthly.TabIndex = 0
        '
        ' dgvServices
        '
        Me.dgvServices.Location = New System.Drawing.Point(24, 270)
        Me.dgvServices.Name = "dgvServices"
        Me.dgvServices.ReadOnly = True
        Me.dgvServices.RowHeadersWidth = 51
        Me.dgvServices.RowTemplate.Height = 29
        Me.dgvServices.Size = New System.Drawing.Size(940, 330)
        Me.dgvServices.TabIndex = 1

        Me.lblTax.AutoSize = True
        Me.lblTax.Location = New System.Drawing.Point(700, 42)
        Me.lblTax.Name = "lblTax"
        Me.lblTax.Size = New System.Drawing.Size(120, 20)
        Me.lblTax.Text = "Aliquota tasse (%)"

        Me.numTax.Location = New System.Drawing.Point(700, 70)
        Me.numTax.Name = "numTax"
        Me.numTax.Size = New System.Drawing.Size(120, 27)
        Me.numTax.DecimalPlaces = 2
        Me.numTax.Increment = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numTax.Value = New Decimal(New Integer() {0, 0, 0, 0})

        Me.lblGross.AutoSize = True
        Me.lblGross.Location = New System.Drawing.Point(700, 130)
        Me.lblGross.Name = "lblGross"
        Me.lblGross.Size = New System.Drawing.Size(120, 20)
        Me.lblGross.Text = "Totale lordo: 0"

        Me.lblNet.AutoSize = True
        Me.lblNet.Location = New System.Drawing.Point(700, 165)
        Me.lblNet.Name = "lblNet"
        Me.lblNet.Size = New System.Drawing.Size(120, 20)
        Me.lblNet.Text = "Totale netto: 0"
        '
        ' FormInvoices
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 640)
        Me.Controls.Add(Me.dgvServices)
        Me.Controls.Add(Me.dgvMonthly)
        Me.Controls.Add(Me.lblTax)
        Me.Controls.Add(Me.numTax)
        Me.Controls.Add(Me.lblGross)
        Me.Controls.Add(Me.lblNet)
        Me.Name = "FormInvoices"
        Me.Text = "Fatturazione"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
    Private WithEvents dgvMonthly As System.Windows.Forms.DataGridView
    Private WithEvents dgvServices As System.Windows.Forms.DataGridView
    Private lblGross As System.Windows.Forms.Label
    Private lblNet As System.Windows.Forms.Label
    Private WithEvents numTax As System.Windows.Forms.NumericUpDown
    Private lblTax As System.Windows.Forms.Label
End Class
