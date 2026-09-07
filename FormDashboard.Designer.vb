<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDashboard
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
        Me.lblWelcome = New System.Windows.Forms.Label()
        Me.btnPatients = New System.Windows.Forms.Button()
        Me.btnUsers = New System.Windows.Forms.Button()
        Me.btnCalendar = New System.Windows.Forms.Button()
        Me.btnInvoices = New System.Windows.Forms.Button()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.tlpButtons = New System.Windows.Forms.TableLayoutPanel()
        Me.SuspendLayout()
        '
        ' lblWelcome
        '
        Me.lblWelcome.AutoSize = True
        Me.lblWelcome.Location = New System.Drawing.Point(24, 20)
        Me.lblWelcome.Name = "lblWelcome"
        Me.lblWelcome.Size = New System.Drawing.Size(200, 28)
        Me.lblWelcome.TabIndex = 0
        Me.lblWelcome.Text = "Benvenuto"
        Me.lblWelcome.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        '
        ' btnPatients
        '
        Me.btnPatients.Name = "btnPatients"
        Me.btnPatients.Text = "Pazienti"
        Me.btnPatients.TabIndex = 1
        Me.btnPatients.UseVisualStyleBackColor = True
        Me.btnPatients.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnPatients.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        '
        ' btnUsers
        '
        Me.btnUsers.Name = "btnUsers"
        Me.btnUsers.Text = "Utenti"
        Me.btnUsers.TabIndex = 2
        Me.btnUsers.UseVisualStyleBackColor = True
        Me.btnUsers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnUsers.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        '
        ' btnCalendar
        '
        Me.btnCalendar.Name = "btnCalendar"
        Me.btnCalendar.Text = "Calendario"
        Me.btnCalendar.TabIndex = 3
        Me.btnCalendar.UseVisualStyleBackColor = True
        Me.btnCalendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCalendar.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        '
        ' btnInvoices
        '
        Me.btnInvoices.Name = "btnInvoices"
        Me.btnInvoices.Text = "Fatturazione"
        Me.btnInvoices.TabIndex = 4
        Me.btnInvoices.UseVisualStyleBackColor = True
        Me.btnInvoices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnInvoices.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        '
        ' btnLogout
        '
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.TabIndex = 5
        Me.btnLogout.UseVisualStyleBackColor = True
        Me.btnLogout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnLogout.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        '
        ' tlpButtons
        '
        Me.tlpButtons.Location = New System.Drawing.Point(120, 120)
        Me.tlpButtons.Name = "tlpButtons"
        Me.tlpButtons.ColumnCount = 3
        Me.tlpButtons.RowCount = 2
        Me.tlpButtons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpButtons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpButtons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56.0!))
        Me.tlpButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56.0!))
        Me.tlpButtons.Size = New System.Drawing.Size(760, 220)
        Me.tlpButtons.TabIndex = 6
        Me.tlpButtons.Controls.Add(Me.btnPatients, 0, 0)
        Me.tlpButtons.Controls.Add(Me.btnUsers, 1, 0)
        Me.tlpButtons.Controls.Add(Me.btnInvoices, 2, 0)
        Me.tlpButtons.Controls.Add(Me.btnCalendar, 0, 1)
        Me.tlpButtons.Controls.Add(Me.btnLogout, 2, 1)
        '
        ' FormDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 600)
        Me.Controls.Add(Me.tlpButtons)
        Me.Controls.Add(Me.lblWelcome)
        Me.Name = "FormDashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dashboard"
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Private lblWelcome As System.Windows.Forms.Label
    Private btnPatients As System.Windows.Forms.Button
    Private btnUsers As System.Windows.Forms.Button
    Private btnCalendar As System.Windows.Forms.Button
    Private btnInvoices As System.Windows.Forms.Button
    Private btnLogout As System.Windows.Forms.Button
    Private tlpButtons As System.Windows.Forms.TableLayoutPanel
End Class
