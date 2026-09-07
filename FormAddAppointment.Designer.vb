<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAddAppointment
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
        Me.cbPatients = New System.Windows.Forms.ComboBox()
        Me.cbPaymentMode = New System.Windows.Forms.ComboBox()
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.lblPrice = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.lblPayment = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        ' cbPatients
        '
        Me.cbPatients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPatients.FormattingEnabled = True
        Me.cbPatients.Location = New System.Drawing.Point(16, 16)
        Me.cbPatients.Name = "cbPatients"
        Me.cbPatients.Size = New System.Drawing.Size(360, 28)
        Me.cbPatients.TabIndex = 0
        '
        ' dtpStart
        '
        Me.dtpStart.Location = New System.Drawing.Point(16, 56)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(200, 27)
        Me.dtpStart.TabIndex = 1
        '
        ' dtpEnd
        '
        Me.dtpEnd.Location = New System.Drawing.Point(216, 56)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(160, 27)
        Me.dtpEnd.TabIndex = 2
        '
        ' cbPaymentMode
        '
        Me.cbPaymentMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPaymentMode.FormattingEnabled = True
        Me.cbPaymentMode.Items.AddRange(New Object() {"Per prestazione", "Per ora"})
        Me.cbPaymentMode.Location = New System.Drawing.Point(16, 100)
        Me.cbPaymentMode.Name = "cbPaymentMode"
        Me.cbPaymentMode.Size = New System.Drawing.Size(200, 28)
        Me.cbPaymentMode.TabIndex = 3

        ' txtPrice
        '
        Me.txtPrice.Location = New System.Drawing.Point(240, 100)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(120, 27)
        Me.txtPrice.TabIndex = 4
        '
        ' lblPrice
        '
        Me.lblPrice.AutoSize = True
        Me.lblPrice.Location = New System.Drawing.Point(240, 80)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(40, 20)
        Me.lblPrice.TabIndex = 4
        Me.lblPrice.Text = "Prezzo"
        '
        ' lblPayment
        '
        Me.lblPayment.AutoSize = True
        Me.lblPayment.Location = New System.Drawing.Point(16, 80)
        Me.lblPayment.Name = "lblPayment"
        Me.lblPayment.Size = New System.Drawing.Size(88, 20)
        Me.lblPayment.TabIndex = 5
        Me.lblPayment.Text = "Tipo pagamento"
        '
        ' txtNotes
        '
        Me.txtNotes.Location = New System.Drawing.Point(16, 140)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(360, 80)
        Me.txtNotes.TabIndex = 5
        '
        ' lblNotes
        '
        Me.lblNotes.AutoSize = True
        Me.lblNotes.Location = New System.Drawing.Point(16, 120)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(44, 20)
        Me.lblNotes.TabIndex = 6
        Me.lblNotes.Text = "Note"
        '
        ' btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(16, 232)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(94, 32)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Salva"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        ' FormAddAppointment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 280)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lblNotes)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.lblPrice)
        Me.Controls.Add(Me.txtPrice)
        Me.Controls.Add(Me.cbPaymentMode)
        Me.Controls.Add(Me.lblPayment)
        Me.Controls.Add(Me.dtpEnd)
        Me.Controls.Add(Me.dtpStart)
        Me.Controls.Add(Me.cbPatients)
        Me.Name = "FormAddAppointment"
        Me.Text = "Nuovo appuntamento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Private WithEvents cbPatients As System.Windows.Forms.ComboBox
    Private WithEvents dtpStart As System.Windows.Forms.DateTimePicker
    Private WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
    Private WithEvents cbPaymentMode As System.Windows.Forms.ComboBox
    Private WithEvents txtPrice As System.Windows.Forms.TextBox
    Private lblPrice As System.Windows.Forms.Label
    Private lblPayment As System.Windows.Forms.Label
    Private WithEvents txtNotes As System.Windows.Forms.TextBox
    Private lblNotes As System.Windows.Forms.Label
    Private WithEvents btnSave As System.Windows.Forms.Button
End Class
