Module Notify
    Public Sub setSystemTrayIcon()
        VpnBypass.NotifyIcon.Icon = VpnBypass.Icon
    End Sub

    Public Sub setBalloonTip(message As String)
        VpnBypass.NotifyIcon.BalloonTipIcon = ToolTipIcon.Info
        VpnBypass.NotifyIcon.BalloonTipTitle = "VPN Bypass"
        VpnBypass.NotifyIcon.BalloonTipText = message
        VpnBypass.NotifyIcon.ShowBalloonTip(20000)
    End Sub
End Module
