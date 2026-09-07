<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAddTreatment
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.txtProgress = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        ' dtpDate
        '
        Me.dtpDate.CustomFormat = "yyyy-MM-dd HH:mm"
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(16, 16)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(260, 27)
        Me.dtpDate.TabIndex = 0
        '
        ' lblNotes
        '
        Me.lblNotes.AutoSize = True
        Me.lblNotes.Location = New System.Drawing.Point(16, 56)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(44, 20)
        Me.lblNotes.TabIndex = 1
        Me.lblNotes.Text = "Note"
        '
        ' txtNotes
        '
        Me.txtNotes.Location = New System.Drawing.Point(16, 80)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(360, 80)
        Me.txtNotes.TabIndex = 2
        '
        ' lblProgress
        '
        Me.lblProgress.AutoSize = True
        Me.lblProgress.Location = New System.Drawing.Point(16, 168)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(61, 20)
        Me.lblProgress.TabIndex = 3
        Me.lblProgress.Text = "Progress"
        '
        ' txtProgress
        '
        Me.txtProgress.Location = New System.Drawing.Point(16, 192)
        Me.txtProgress.Name = "txtProgress"
        Me.txtProgress.Size = New System.Drawing.Size(360, 27)
        Me.txtProgress.TabIndex = 4
        '
        ' btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(16, 232)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(94, 32)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Salva"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        ' FormAddTreatment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 280)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtProgress)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.lblNotes)
        Me.Controls.Add(Me.dtpDate)
        Me.Name = "FormAddTreatment"
        Me.Text = "Nuova seduta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Private WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Private lblNotes As System.Windows.Forms.Label
    Private txtNotes As System.Windows.Forms.TextBox
    Private lblProgress As System.Windows.Forms.Label
    Private txtProgress As System.Windows.Forms.TextBox
    Private WithEvents btnSave As System.Windows.Forms.Button
End Class
