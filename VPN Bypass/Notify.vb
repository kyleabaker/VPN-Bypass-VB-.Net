Module Notify
    Public Sub setSystemTrayIcon()
        VpnBypassForm.NotifyIcon.Icon = VpnBypassForm.Icon
    End Sub

    Public Sub setBalloonTip(message As String)
        VpnBypassForm.NotifyIcon.BalloonTipIcon = ToolTipIcon.Info
        VpnBypassForm.NotifyIcon.BalloonTipTitle = "VPN Bypass"
        VpnBypassForm.NotifyIcon.BalloonTipText = message
        VpnBypassForm.NotifyIcon.ShowBalloonTip(20000)
    End Sub
End Module
