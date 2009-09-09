Public Class frmMonitor

    Private WithEvents COMPort As New Rs232

    Private Sub tmrPoll_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrPoll.Tick
        If COMPort.IsOpen Then
            COMPort.Write("Q1" & vbCr)
        End If
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        COMPort.Open(1, 2400, 8, Rs232.DataParity.Parity_None, Rs232.DataStopBit.StopBit_1, 4096)

    End Sub

    Private Sub COMPort_CommEvent(ByVal Source As Rs232, ByVal Mask As Rs232.EventMasks) Handles COMPort.CommEvent
        If (Mask Or Rs232.EventMasks.RxChar) <> 0 Then
            MsgBox(COMPort.Read(20))
        End If
    End Sub

End Class
