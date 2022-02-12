Public Class frmTimer
    Private _exTime As ExecutionTimer


    Public Sub New(ByVal exTimer As ExecutionTimer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _exTime = exTimer
        txt.Text = _exTime.GetExecutionTime.TotalSeconds
        Timer.Start()
    End Sub

    Private Sub Timer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer.Tick
        If _exTime.IsRunning = True Then
            txt.Text = _exTime.GetExecutionTime.TotalSeconds & " ms"
            cmdOK.Enabled = False
        Else
            txt.Text = _exTime.WriteStringOutput
            Timer.Stop()
            cmdOK.Enabled = True
        End If
    End Sub

    Private Sub cmdOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Me.Close()
    End Sub
End Class