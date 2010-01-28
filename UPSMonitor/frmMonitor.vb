Public Class frmMonitor

    Private WithEvents COMPort As New Rs232
    Private bWaiting As Boolean, bShuttingDown As Boolean
    Public Delegate Sub InvokeDelegate()
    Private strLogFilePath As String

    Private Sub tmrPoll_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrPoll.Tick
        Static strOldStatus As String

        If COMPort.IsOpen Then
            If Not bWaiting Then

                COMPort.Write("Q1" & vbCr)
                bWaiting = True

            Else

                Dim strBuff As String = ""

                Do While InStr(strBuff, vbCr, CompareMethod.Text) = 0
                    COMPort.Read(1)
                    strBuff = strBuff & COMPort.InputStreamString()
                Loop

                txtVoltageIn.Text = "VIn = " & Mid(strBuff, 2, 5) & " v"
                txtVoltageOut.Text = "VOut = " & Mid(strBuff, 14, 5) & " v"
                txtLoadPcnt.Text = "Load = " & Mid(strBuff, 20, 3) & "%"
                txtFreq.Text = "Freq = " & Mid(strBuff, 24, 4) & " Hz"
                txtVoltageBatt.Text = "VBatt = " & Mid(strBuff, 29, 4) & " v"
                txtTemp.Text = "Temp = " & Mid(strBuff, 34, 4) & " ºC"

                If strBuff.Substring(41, 1) = "1" Then
                    txtStatus.Text = "UPS Failure"
                ElseIf strBuff.Substring(39, 1) = "1" Then
                    txtStatus.Text = "Battery Low"
                    If Not bShuttingDown Then
                        System.Diagnostics.Process.Start("shutdown", "/f /p /d 6:12")
                        bShuttingDown = True
                    End If
                ElseIf strBuff.Substring(38, 1) = "1" Then
                    txtStatus.Text = "Power Failed"
                ElseIf strBuff.Substring(40, 1) = "1" Then
                    txtStatus.Text = "UPS in Boost/Buck Mode"
                Else
                    txtStatus.Text = "UPS & Power OK"
                End If

                If strOldStatus <> txtStatus.Text Then
                    strOldStatus = txtStatus.Text
                    Call mLogEvent(txtStatus.Text)
                    NotifyIcon1.Text = "UPSMonitor: " & txtStatus.Text
                End If

                bWaiting = False

                End If
        End If
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub NotifyIcon1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.DoubleClick
        Me.Visible = True
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub frmMonitor_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Visible = False
        End If
    End Sub

    Private Sub frmMonitor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        COMPort.Open(1, 2400, 8, Rs232.DataParity.Parity_None, Rs232.DataStopBit.StopBit_1, 4096)
        NotifyIcon1.Icon = Me.Icon
        NotifyIcon1.Text = "UPSMonitor"
        strLogFilePath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\UPSMonitor\Events.log"
        Call mLogEvent("Starting Up")
        Me.BeginInvoke(New InvokeDelegate(AddressOf Me.HideForm))
    End Sub

    Private Sub HideForm()
        Me.Visible = False
    End Sub

    Private Sub frmMonitor_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If MsgBox("Are you sure you want to close UPSMonitor?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then e.Cancel = True
        End If

        If Not e.Cancel Then mLogEvent("Shutting Down (Reason: " & e.CloseReason & ")")
    End Sub

    Private Sub mLogEvent(ByVal strEvent As String)
        Dim mFile As System.IO.StreamWriter
        Dim strLine As String

        strLine = Format(Now, "yyyyMMdd hhmmss") & ": " & strEvent
        mFile = System.IO.File.AppendText(strLogFilePath)
        mFile.WriteLine(strLine)
        mFile.Close()

    End Sub
End Class
