Module Notify
    Dim VpnBypassWindowState As FormWindowState = FormWindowState.Normal

    Public Sub setSystemTrayIcon()
        VpnBypassForm.NotifyIcon.Icon = VpnBypassForm.Icon
    End Sub

    Public Sub setBalloonTip(message As String)
        VpnBypassForm.NotifyIcon.BalloonTipIcon = ToolTipIcon.Info
        VpnBypassForm.NotifyIcon.BalloonTipTitle = "VPN Bypass"
        VpnBypassForm.NotifyIcon.BalloonTipText = message
        VpnBypassForm.NotifyIcon.ShowBalloonTip(20000)
    End Sub

    Public Sub toggle()
        If VpnBypassForm.Visible = True Then
            VpnBypassForm.Hide()
        Else
            VpnBypassForm.Show()
            VpnBypassForm.WindowState = VpnBypassWindowState
        End If
    End Sub

    Public Sub setWindowState(windowState As FormWindowState)
        VpnBypassWindowState = windowState
    End Sub

    Public Function getWindowState() As FormWindowState
        Return VpnBypassWindowState
    End Function
End Module
