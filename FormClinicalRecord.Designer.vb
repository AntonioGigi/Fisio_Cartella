<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormClinicalRecord
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
        Me.lblPatientName = New System.Windows.Forms.Label()
        Me.lblAnamnesis = New System.Windows.Forms.Label()
        Me.txtAnamnesis = New System.Windows.Forms.TextBox()
        Me.lblRecords = New System.Windows.Forms.Label()
        Me.dgvRecords = New System.Windows.Forms.DataGridView()
        Me.lblTreatments = New System.Windows.Forms.Label()
        Me.dgvTreatments = New System.Windows.Forms.DataGridView()
        Me.btnAddTreatment = New System.Windows.Forms.Button()
        CType(Me.dgvRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTreatments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        ' lblPatientName
        '
        Me.lblPatientName.AutoSize = True
        Me.lblPatientName.Location = New System.Drawing.Point(12, 12)
        Me.lblPatientName.Name = "lblPatientName"
        Me.lblPatientName.Size = New System.Drawing.Size(75, 20)
        Me.lblPatientName.TabIndex = 0
        Me.lblPatientName.Text = "Paziente"
        '
        ' lblAnamnesis
        '
        Me.lblAnamnesis.AutoSize = True
        Me.lblAnamnesis.Location = New System.Drawing.Point(12, 40)
        Me.lblAnamnesis.Name = "lblAnamnesis"
        Me.lblAnamnesis.Size = New System.Drawing.Size(76, 20)
        Me.lblAnamnesis.TabIndex = 1
        Me.lblAnamnesis.Text = "Anamnesi"
        '
        ' txtAnamnesis
        '
        Me.txtAnamnesis.Location = New System.Drawing.Point(12, 64)
        Me.txtAnamnesis.Multiline = True
        Me.txtAnamnesis.Name = "txtAnamnesis"
        Me.txtAnamnesis.ReadOnly = True
        Me.txtAnamnesis.Size = New System.Drawing.Size(560, 80)
        Me.txtAnamnesis.TabIndex = 2
        '
        ' lblRecords
        '
        Me.lblRecords.AutoSize = True
        Me.lblRecords.Location = New System.Drawing.Point(12, 156)
        Me.lblRecords.Name = "lblRecords"
        Me.lblRecords.Size = New System.Drawing.Size(104, 20)
        Me.lblRecords.TabIndex = 3
        Me.lblRecords.Text = "Cartelle cliniche"
        '
        ' dgvRecords
        '
        Me.dgvRecords.Location = New System.Drawing.Point(12, 180)
        Me.dgvRecords.Name = "dgvRecords"
        Me.dgvRecords.ReadOnly = True
        Me.dgvRecords.RowHeadersWidth = 51
        Me.dgvRecords.RowTemplate.Height = 29
        Me.dgvRecords.Size = New System.Drawing.Size(560, 100)
        Me.dgvRecords.TabIndex = 4
        '
        ' lblTreatments
        '
        Me.lblTreatments.AutoSize = True
        Me.lblTreatments.Location = New System.Drawing.Point(12, 292)
        Me.lblTreatments.Name = "lblTreatments"
        Me.lblTreatments.Size = New System.Drawing.Size(92, 20)
        Me.lblTreatments.TabIndex = 5
        Me.lblTreatments.Text = "Sedute recenti"
        '
        ' dgvTreatments
        '
        Me.dgvTreatments.Location = New System.Drawing.Point(12, 316)
        Me.dgvTreatments.Name = "dgvTreatments"
        Me.dgvTreatments.ReadOnly = True
        Me.dgvTreatments.RowHeadersWidth = 51
        Me.dgvTreatments.RowTemplate.Height = 29
        Me.dgvTreatments.Size = New System.Drawing.Size(460, 120)
        Me.dgvTreatments.TabIndex = 6
        '
        ' btnAddTreatment
        '
        Me.btnAddTreatment.Location = New System.Drawing.Point(484, 316)
        Me.btnAddTreatment.Name = "btnAddTreatment"
        Me.btnAddTreatment.Size = New System.Drawing.Size(88, 32)
        Me.btnAddTreatment.TabIndex = 7
        Me.btnAddTreatment.Text = "Aggiungi"
        Me.btnAddTreatment.UseVisualStyleBackColor = True
        '
        ' FormClinicalRecord
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 460)
        Me.Controls.Add(Me.btnAddTreatment)
        Me.Controls.Add(Me.dgvTreatments)
        Me.Controls.Add(Me.lblTreatments)
        Me.Controls.Add(Me.dgvRecords)
        Me.Controls.Add(Me.lblRecords)
        Me.Controls.Add(Me.txtAnamnesis)
        Me.Controls.Add(Me.lblAnamnesis)
        Me.Controls.Add(Me.lblPatientName)
        Me.Name = "FormClinicalRecord"
        Me.Text = "Cartella Clinica"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.dgvRecords, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTreatments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
    Private lblPatientName As System.Windows.Forms.Label
    Private lblAnamnesis As System.Windows.Forms.Label
    Private txtAnamnesis As System.Windows.Forms.TextBox
    Private lblRecords As System.Windows.Forms.Label
    Private WithEvents dgvRecords As System.Windows.Forms.DataGridView
    Private lblTreatments As System.Windows.Forms.Label
    Private WithEvents dgvTreatments As System.Windows.Forms.DataGridView
    Private WithEvents btnAddTreatment As System.Windows.Forms.Button
End Class
