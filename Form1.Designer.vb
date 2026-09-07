<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.lblPass = New System.Windows.Forms.Label()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        ' lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(40, 40)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(73, 20)
        Me.lblUser.TabIndex = 0
        Me.lblUser.Text = "Username"
        '
        ' txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(40, 70)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(300, 27)
        Me.txtUser.TabIndex = 1
        '
        ' lblPass
        '
        Me.lblPass.AutoSize = True
        Me.lblPass.Location = New System.Drawing.Point(40, 110)
        Me.lblPass.Name = "lblPass"
        Me.lblPass.Size = New System.Drawing.Size(70, 20)
        Me.lblPass.TabIndex = 2
        Me.lblPass.Text = "Password"
        '
        ' txtPass
        '
        Me.txtPass.Location = New System.Drawing.Point(40, 135)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.Size = New System.Drawing.Size(300, 27)
        Me.txtPass.TabIndex = 3
        Me.txtPass.UseSystemPasswordChar = True
        '
        ' btnLogin
        '
        Me.btnLogin.Location = New System.Drawing.Point(40, 180)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(120, 36)
        Me.btnLogin.TabIndex = 4
        Me.btnLogin.Text = "Accedi"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        ' lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Location = New System.Drawing.Point(40, 230)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(0, 20)
        Me.lblMessage.TabIndex = 5
        '
        ' Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(900, 600)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.txtPass)
        Me.Controls.Add(Me.lblPass)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.lblUser)
        Me.Name = "Form1"
        Me.Text = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Private lblUser As System.Windows.Forms.Label
    Private txtUser As System.Windows.Forms.TextBox
    Private lblPass As System.Windows.Forms.Label
    Private txtPass As System.Windows.Forms.TextBox
    Private btnLogin As System.Windows.Forms.Button
    Private lblMessage As System.Windows.Forms.Label

End Class
