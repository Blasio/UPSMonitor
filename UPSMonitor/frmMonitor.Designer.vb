<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMonitor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.txtVoltageIn = New System.Windows.Forms.TextBox
        Me.txtVoltageOut = New System.Windows.Forms.TextBox
        Me.txtLoadPcnt = New System.Windows.Forms.TextBox
        Me.txtFreq = New System.Windows.Forms.TextBox
        Me.txtVoltageBatt = New System.Windows.Forms.TextBox
        Me.txtTemp = New System.Windows.Forms.TextBox
        Me.txtStatus = New System.Windows.Forms.TextBox
        Me.tmrPoll = New System.Windows.Forms.Timer(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.SuspendLayout()
        '
        'txtVoltageIn
        '
        Me.txtVoltageIn.Location = New System.Drawing.Point(12, 12)
        Me.txtVoltageIn.Name = "txtVoltageIn"
        Me.txtVoltageIn.Size = New System.Drawing.Size(100, 20)
        Me.txtVoltageIn.TabIndex = 0
        '
        'txtVoltageOut
        '
        Me.txtVoltageOut.Location = New System.Drawing.Point(12, 38)
        Me.txtVoltageOut.Name = "txtVoltageOut"
        Me.txtVoltageOut.Size = New System.Drawing.Size(100, 20)
        Me.txtVoltageOut.TabIndex = 3
        '
        'txtLoadPcnt
        '
        Me.txtLoadPcnt.Location = New System.Drawing.Point(12, 64)
        Me.txtLoadPcnt.Name = "txtLoadPcnt"
        Me.txtLoadPcnt.Size = New System.Drawing.Size(100, 20)
        Me.txtLoadPcnt.TabIndex = 4
        '
        'txtFreq
        '
        Me.txtFreq.Location = New System.Drawing.Point(12, 90)
        Me.txtFreq.Name = "txtFreq"
        Me.txtFreq.Size = New System.Drawing.Size(100, 20)
        Me.txtFreq.TabIndex = 5
        '
        'txtVoltageBatt
        '
        Me.txtVoltageBatt.Location = New System.Drawing.Point(12, 116)
        Me.txtVoltageBatt.Name = "txtVoltageBatt"
        Me.txtVoltageBatt.Size = New System.Drawing.Size(100, 20)
        Me.txtVoltageBatt.TabIndex = 6
        '
        'txtTemp
        '
        Me.txtTemp.Location = New System.Drawing.Point(12, 142)
        Me.txtTemp.Name = "txtTemp"
        Me.txtTemp.Size = New System.Drawing.Size(100, 20)
        Me.txtTemp.TabIndex = 7
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(12, 168)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(159, 20)
        Me.txtStatus.TabIndex = 8
        '
        'tmrPoll
        '
        Me.tmrPoll.Enabled = True
        Me.tmrPoll.Interval = 1000
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'frmMonitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(181, 194)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.txtTemp)
        Me.Controls.Add(Me.txtVoltageBatt)
        Me.Controls.Add(Me.txtFreq)
        Me.Controls.Add(Me.txtLoadPcnt)
        Me.Controls.Add(Me.txtVoltageOut)
        Me.Controls.Add(Me.txtVoltageIn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMonitor"
        Me.Text = "UPSMonitor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtVoltageIn As System.Windows.Forms.TextBox
    Friend WithEvents txtVoltageOut As System.Windows.Forms.TextBox
    Friend WithEvents txtLoadPcnt As System.Windows.Forms.TextBox
    Friend WithEvents txtFreq As System.Windows.Forms.TextBox
    Friend WithEvents txtVoltageBatt As System.Windows.Forms.TextBox
    Friend WithEvents txtTemp As System.Windows.Forms.TextBox
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents tmrPoll As System.Windows.Forms.Timer
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon

End Class
