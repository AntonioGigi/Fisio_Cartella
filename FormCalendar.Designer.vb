<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCalendar
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
        Me.monthCalendar = New System.Windows.Forms.MonthCalendar()
        Me.dgvAppointments = New System.Windows.Forms.DataGridView()
        Me.btnAddAppointment = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        CType(Me.dgvAppointments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        ' monthCalendar
        '
        Me.monthCalendar.Location = New System.Drawing.Point(24, 42)
        Me.monthCalendar.BackColor = System.Drawing.Color.White
        Me.monthCalendar.MaxSelectionCount = 1
        Me.monthCalendar.Name = "monthCalendar"
        Me.monthCalendar.TabIndex = 0
        '
        ' dgvAppointments
        '
        Me.dgvAppointments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAppointments.Location = New System.Drawing.Point(320, 24)
        Me.dgvAppointments.Name = "dgvAppointments"
        Me.dgvAppointments.ReadOnly = False
        Me.dgvAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAppointments.RowHeadersWidth = 51
        Me.dgvAppointments.RowTemplate.Height = 29
        Me.dgvAppointments.Size = New System.Drawing.Size(760, 570)
        Me.dgvAppointments.TabIndex = 1
        '
        ' btnAddAppointment
        '
        Me.btnAddAppointment.Location = New System.Drawing.Point(24, 250)
        Me.btnAddAppointment.Name = "btnAddAppointment"
        Me.btnAddAppointment.Size = New System.Drawing.Size(250, 42)
        Me.btnAddAppointment.TabIndex = 2
        Me.btnAddAppointment.Text = "Aggiungi appuntamento"
        Me.btnAddAppointment.UseVisualStyleBackColor = True
        '
        ' btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(24, 304)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(250, 42)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Elimina elemento"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        ' FormCalendar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1100, 650)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAddAppointment)
        Me.Controls.Add(Me.dgvAppointments)
        Me.Controls.Add(Me.monthCalendar)
        Me.Name = "FormCalendar"
        Me.Text = "Calendario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.dgvAppointments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents monthCalendar As System.Windows.Forms.MonthCalendar
    Private WithEvents dgvAppointments As System.Windows.Forms.DataGridView
    Private WithEvents btnAddAppointment As System.Windows.Forms.Button
    Private WithEvents btnDelete As System.Windows.Forms.Button
End Class
