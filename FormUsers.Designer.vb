<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormUsers
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
        Me.dgvUsers = New System.Windows.Forms.DataGridView()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnChangePassword = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSetRole = New System.Windows.Forms.Button()
        CType(Me.dgvUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        ' dgvUsers
        '
        Me.dgvUsers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUsers.Location = New System.Drawing.Point(12, 12)
        Me.dgvUsers.Name = "dgvUsers"
        Me.dgvUsers.ReadOnly = True
        Me.dgvUsers.RowHeadersWidth = 51
        Me.dgvUsers.RowTemplate.Height = 29
        Me.dgvUsers.Size = New System.Drawing.Size(560, 300)
        Me.dgvUsers.TabIndex = 0
        '
        ' btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(12, 325)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(94, 29)
        Me.btnNew.TabIndex = 1
        Me.btnNew.Text = "Nuovo"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        ' btnChangePassword
        '
        Me.btnChangePassword.Location = New System.Drawing.Point(112, 325)
        Me.btnChangePassword.Name = "btnChangePassword"
        Me.btnChangePassword.Size = New System.Drawing.Size(142, 29)
        Me.btnChangePassword.TabIndex = 2
        Me.btnChangePassword.Text = "Cambia password"
        Me.btnChangePassword.UseVisualStyleBackColor = True
        '
        ' btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(260, 325)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(94, 29)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Elimina"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        ' btnSetRole
        '
        Me.btnSetRole.Location = New System.Drawing.Point(360, 325)
        Me.btnSetRole.Name = "btnSetRole"
        Me.btnSetRole.Size = New System.Drawing.Size(120, 29)
        Me.btnSetRole.TabIndex = 4
        Me.btnSetRole.Text = "Imposta ruolo"
        Me.btnSetRole.UseVisualStyleBackColor = True
        '
        ' FormUsers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(820, 500)
        Me.Controls.Add(Me.btnSetRole)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnChangePassword)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.dgvUsers)
        Me.Name = "FormUsers"
        Me.Text = "Gestione utenti"
        CType(Me.dgvUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents dgvUsers As System.Windows.Forms.DataGridView
    Private WithEvents btnNew As System.Windows.Forms.Button
    Private WithEvents btnChangePassword As System.Windows.Forms.Button
    Private WithEvents btnDelete As System.Windows.Forms.Button
    Private WithEvents btnSetRole As System.Windows.Forms.Button
End Class
