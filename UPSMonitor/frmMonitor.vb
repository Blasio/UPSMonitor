Public Class frmMonitor

    Private WithEvents COMPort As New Rs232
    Private bWaiting As Boolean

    Private Sub tmrPoll_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrPoll.Tick

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
                txtStatus.Text = strBuff

                bWaiting = False
            End If
        End If
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        COMPort.Open(1, 2400, 8, Rs232.DataParity.Parity_None, Rs232.DataStopBit.StopBit_1, 4096)

    End Sub

End Class
