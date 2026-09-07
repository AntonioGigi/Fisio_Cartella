<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormRegister
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
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblConfirm = New System.Windows.Forms.Label()
        Me.txtConfirm = New System.Windows.Forms.TextBox()
        Me.btnRegister = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        ' lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Location = New System.Drawing.Point(24, 24)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(73, 20)
        Me.lblUsername.TabIndex = 0
        Me.lblUsername.Text = "Username"
        '
        ' txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(24, 50)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(300, 27)
        Me.txtUsername.TabIndex = 1
        '
        ' lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(24, 90)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(70, 20)
        Me.lblPassword.TabIndex = 2
        Me.lblPassword.Text = "Password"
        '
        ' txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(24, 116)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(300, 27)
        Me.txtPassword.TabIndex = 3
        Me.txtPassword.UseSystemPasswordChar = True
        '
        ' lblConfirm
        '
        Me.lblConfirm.AutoSize = True
        Me.lblConfirm.Location = New System.Drawing.Point(24, 156)
        Me.lblConfirm.Name = "lblConfirm"
        Me.lblConfirm.Size = New System.Drawing.Size(125, 20)
        Me.lblConfirm.TabIndex = 4
        Me.lblConfirm.Text = "Conferma Password"
        '
        ' txtConfirm
        '
        Me.txtConfirm.Location = New System.Drawing.Point(24, 182)
        Me.txtConfirm.Name = "txtConfirm"
        Me.txtConfirm.Size = New System.Drawing.Size(300, 27)
        Me.txtConfirm.TabIndex = 5
        Me.txtConfirm.UseSystemPasswordChar = True
        '
        ' btnRegister
        '
        Me.btnRegister.Location = New System.Drawing.Point(24, 225)
        Me.btnRegister.Name = "btnRegister"
        Me.btnRegister.Size = New System.Drawing.Size(120, 36)
        Me.btnRegister.TabIndex = 6
        Me.btnRegister.Text = "Registrati"
        Me.btnRegister.UseVisualStyleBackColor = True
        '
        ' FormRegister
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(360, 280)
        Me.Controls.Add(Me.btnRegister)
        Me.Controls.Add(Me.txtConfirm)
        Me.Controls.Add(Me.lblConfirm)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.lblUsername)
        Me.Name = "FormRegister"
        Me.Text = "Registrazione"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Private lblUsername As System.Windows.Forms.Label
    Private txtUsername As System.Windows.Forms.TextBox
    Private lblPassword As System.Windows.Forms.Label
    Private txtPassword As System.Windows.Forms.TextBox
    Private lblConfirm As System.Windows.Forms.Label
    Private txtConfirm As System.Windows.Forms.TextBox
    Private WithEvents btnRegister As System.Windows.Forms.Button
End Class
