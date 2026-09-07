<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormTreatments
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
        Me.dgvPatients = New System.Windows.Forms.DataGridView()
        Me.dgvTreatments = New System.Windows.Forms.DataGridView()
        Me.lblAnamnesis = New System.Windows.Forms.Label()
        Me.txtAnamnesis = New System.Windows.Forms.TextBox()
        Me.lblEvaluation = New System.Windows.Forms.Label()
        Me.txtEvaluation = New System.Windows.Forms.TextBox()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.btnSaveTreatment = New System.Windows.Forms.Button()
        CType(Me.dgvPatients, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTreatments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        ' dgvPatients
        '
        Me.dgvPatients.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPatients.Location = New System.Drawing.Point(12, 12)
        Me.dgvPatients.Name = "dgvPatients"
        Me.dgvPatients.ReadOnly = True
        Me.dgvPatients.RowHeadersWidth = 51
        Me.dgvPatients.RowTemplate.Height = 29
        Me.dgvPatients.Size = New System.Drawing.Size(260, 376)
        Me.dgvPatients.TabIndex = 0
        '
        ' dgvTreatments
        '
        Me.dgvTreatments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvTreatments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTreatments.Location = New System.Drawing.Point(290, 200)
        Me.dgvTreatments.Name = "dgvTreatments"
        Me.dgvTreatments.ReadOnly = True
        Me.dgvTreatments.RowHeadersWidth = 51
        Me.dgvTreatments.RowTemplate.Height = 29
        Me.dgvTreatments.Size = New System.Drawing.Size(298, 188)
        Me.dgvTreatments.TabIndex = 1
        '
        ' lblAnamnesis
        '
        Me.lblAnamnesis.AutoSize = True
        Me.lblAnamnesis.Location = New System.Drawing.Point(290, 12)
        Me.lblAnamnesis.Name = "lblAnamnesis"
        Me.lblAnamnesis.Size = New System.Drawing.Size(76, 20)
        Me.lblAnamnesis.TabIndex = 2
        Me.lblAnamnesis.Text = "Anamnesi"
        '
        ' txtAnamnesis
        '
        Me.txtAnamnesis.Location = New System.Drawing.Point(290, 36)
        Me.txtAnamnesis.Multiline = True
        Me.txtAnamnesis.Name = "txtAnamnesis"
        Me.txtAnamnesis.Size = New System.Drawing.Size(298, 76)
        Me.txtAnamnesis.TabIndex = 3
        '
        ' lblEvaluation
        '
        Me.lblEvaluation.AutoSize = True
        Me.lblEvaluation.Location = New System.Drawing.Point(290, 120)
        Me.lblEvaluation.Name = "lblEvaluation"
        Me.lblEvaluation.Size = New System.Drawing.Size(73, 20)
        Me.lblEvaluation.TabIndex = 4
        Me.lblEvaluation.Text = "Valutazione"
        '
        ' txtEvaluation
        '
        Me.txtEvaluation.Location = New System.Drawing.Point(290, 144)
        Me.txtEvaluation.Multiline = True
        Me.txtEvaluation.Name = "txtEvaluation"
        Me.txtEvaluation.Size = New System.Drawing.Size(298, 48)
        Me.txtEvaluation.TabIndex = 5
        '
        ' lblNotes
        '
        Me.lblNotes.AutoSize = True
        Me.lblNotes.Location = New System.Drawing.Point(12, 392)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(39, 20)
        Me.lblNotes.TabIndex = 6
        Me.lblNotes.Text = "Note"
        Me.lblNotes.Visible = False
        '
        ' txtNotes
        '
        Me.txtNotes.Location = New System.Drawing.Point(12, 392)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(100, 20)
        Me.txtNotes.TabIndex = 7
        Me.txtNotes.Visible = False
        '
        ' btnSaveTreatment
        '
        Me.btnSaveTreatment.Location = New System.Drawing.Point(490, 12)
        Me.btnSaveTreatment.Name = "btnSaveTreatment"
        Me.btnSaveTreatment.Size = New System.Drawing.Size(98, 32)
        Me.btnSaveTreatment.TabIndex = 8
        Me.btnSaveTreatment.Text = "Salva"
        Me.btnSaveTreatment.UseVisualStyleBackColor = True
        '
        ' FormTreatments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(610, 400)
        Me.Controls.Add(Me.btnSaveTreatment)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.lblNotes)
        Me.Controls.Add(Me.txtEvaluation)
        Me.Controls.Add(Me.lblEvaluation)
        Me.Controls.Add(Me.txtAnamnesis)
        Me.Controls.Add(Me.lblAnamnesis)
        Me.Controls.Add(Me.dgvTreatments)
        Me.Controls.Add(Me.dgvPatients)
        Me.Name = "FormTreatments"
        Me.Text = "Trattamenti"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.dgvPatients, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTreatments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Private dgvPatients As System.Windows.Forms.DataGridView
    Private dgvTreatments As System.Windows.Forms.DataGridView
    Private lblAnamnesis As System.Windows.Forms.Label
    Private txtAnamnesis As System.Windows.Forms.TextBox
    Private lblEvaluation As System.Windows.Forms.Label
    Private txtEvaluation As System.Windows.Forms.TextBox
    Private lblNotes As System.Windows.Forms.Label
    Private txtNotes As System.Windows.Forms.TextBox
    Private WithEvents btnSaveTreatment As System.Windows.Forms.Button
End Class
