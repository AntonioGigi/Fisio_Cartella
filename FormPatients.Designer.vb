<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormPatients
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
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.dgvPatients = New System.Windows.Forms.DataGridView()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.lblTreatments = New System.Windows.Forms.Label()
        Me.dgvTreatments = New System.Windows.Forms.DataGridView()
        Me.btnAddTreatment = New System.Windows.Forms.Button()
        Me.btnDeleteTreatment = New System.Windows.Forms.Button()
        CType(Me.dgvPatients, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        ' dgvPatients
        '
        Me.dgvPatients.AllowUserToAddRows = False
        Me.dgvPatients.AllowUserToDeleteRows = False
        Me.dgvPatients.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.txtSearch.Location = New System.Drawing.Point(12, 12)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(620, 28)
        Me.txtSearch.TabIndex = 0
        Me.txtSearch.PlaceholderText = "Cerca per nome, cognome o CF"
        '
        ' btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(644, 12)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(110, 28)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Cerca"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        ' dgvPatients
        '
        Me.dgvPatients.Location = New System.Drawing.Point(12, 58)
        Me.dgvPatients.Name = "dgvPatients"
        Me.dgvPatients.ReadOnly = True
        Me.dgvPatients.RowHeadersWidth = 51
        Me.dgvPatients.RowTemplate.Height = 29
        Me.dgvPatients.Size = New System.Drawing.Size(960, 285)
        Me.dgvPatients.TabIndex = 0
        '
        ' btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(12, 405)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(120, 38)
        Me.btnNew.TabIndex = 1
        Me.btnNew.Text = "Nuovo"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        ' btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(144, 405)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(120, 38)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "Elimina"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        ' btnDeleteTreatment
        '
        Me.btnDeleteTreatment.Location = New System.Drawing.Point(552, 405)
        Me.btnDeleteTreatment.Name = "btnDeleteTreatment"
        Me.btnDeleteTreatment.Size = New System.Drawing.Size(190, 38)
        Me.btnDeleteTreatment.TabIndex = 7
        Me.btnDeleteTreatment.Text = "Elimina seduta selezionata"
        Me.btnDeleteTreatment.UseVisualStyleBackColor = True
        '
        ' btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(276, 405)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(120, 38)
        Me.btnRefresh.TabIndex = 3
        Me.btnRefresh.Text = "Aggiorna"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        ' lblTreatments
        '
        Me.lblTreatments.AutoSize = True
        Me.lblTreatments.Location = New System.Drawing.Point(12, 370)
        Me.lblTreatments.Name = "lblTreatments"
        Me.lblTreatments.Size = New System.Drawing.Size(180, 22)
        Me.lblTreatments.TabIndex = 4
        Me.lblTreatments.Text = "Sedute recenti"
        '
        ' dgvTreatments
        '
        Me.dgvTreatments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTreatments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTreatments.Location = New System.Drawing.Point(12, 465)
        Me.dgvTreatments.Name = "dgvTreatments"
        Me.dgvTreatments.ReadOnly = True
        Me.dgvTreatments.RowHeadersWidth = 51
        Me.dgvTreatments.RowTemplate.Height = 29
        Me.dgvTreatments.Size = New System.Drawing.Size(960, 200)
        Me.dgvTreatments.TabIndex = 5
        '
        ' btnAddTreatment
        '
        Me.btnAddTreatment.Location = New System.Drawing.Point(408, 405)
        Me.btnAddTreatment.Name = "btnAddTreatment"
        Me.btnAddTreatment.Size = New System.Drawing.Size(130, 38)
        Me.btnAddTreatment.TabIndex = 6
        Me.btnAddTreatment.Text = "Aggiungi seduta"
        Me.btnAddTreatment.UseVisualStyleBackColor = True
        '
        ' FormPatients
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 690)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.btnDeleteTreatment)
        Me.Controls.Add(Me.btnAddTreatment)
        Me.Controls.Add(Me.dgvTreatments)
        Me.Controls.Add(Me.lblTreatments)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.dgvPatients)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Name = "FormPatients"
        Me.Text = "Pazienti"
        CType(Me.dgvPatients, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTreatments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
        Me.PerformLayout()

    End Sub

    Private WithEvents txtSearch As System.Windows.Forms.TextBox
    Private WithEvents btnSearch As System.Windows.Forms.Button
    Private WithEvents dgvPatients As System.Windows.Forms.DataGridView
    Private WithEvents btnNew As System.Windows.Forms.Button
    Private WithEvents btnDelete As System.Windows.Forms.Button
    Private WithEvents btnRefresh As System.Windows.Forms.Button
    Private lblTreatments As System.Windows.Forms.Label
    Private WithEvents dgvTreatments As System.Windows.Forms.DataGridView
    Private WithEvents btnAddTreatment As System.Windows.Forms.Button
    Private WithEvents btnDeleteTreatment As System.Windows.Forms.Button
End Class
