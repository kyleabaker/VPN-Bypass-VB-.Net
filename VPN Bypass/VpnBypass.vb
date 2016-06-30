Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Threading

Public Class VpnBypass
    Dim VpnBypassWindowState As FormWindowState = FormWindowState.Normal
    Dim WithEvents dt As System.Windows.Threading.DispatcherTimer

    '============================================================
    ' DOMAINS
    '============================================================

    ' Add
    Private Sub BtnAddDomain_Click(sender As Object, e As EventArgs)
        Dim domain = TextBoxDomain.Text.ToLower()
        Dim opts As Hashtable = New Hashtable
        opts.Add("nslookup", "true") 'TODO set this from ui settings

        Dim domainNode As TreeNode = VpnBypassImpl.getNewTreeNode(domain, opts)

        If TreeViewDomains.Nodes.ContainsKey(domain) = False Then
            VpnBypassImpl.log("Adding domain to list: " + domain)
            VpnBypassImpl.addDomain(domainNode)
            VpnBypassImpl.addDomainIp(domainNode)
            VpnBypassImpl.applyRoutes(domainNode)
            FileIO.saveDomainList()
            FileIO.saveSpecificDomainList(domainNode)

            ' Refresh Routed IP list
            Route.print()
        End If

        TextBoxDomain.ForeColor = Color.LightGray
        TextBoxDomain.Text = "example.com"
        BtnAddDomain.Enabled = False
    End Sub

    Private Sub TextBoxDomain_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = vbCr.ToCharArray() Then
            BtnAddDomain_Click(sender, e)
        End If
    End Sub

    ' Remove
    Private Sub BtnRemoveDomain_Click(sender As Object, e As EventArgs)
        Dim selectedNode As TreeNode = TreeViewDomains.SelectedNode
        If selectedNode.Parent Is Nothing Then
            Dim domainNode As TreeNode = selectedNode
            Dim domain As String = domainNode.Name
            VpnBypassImpl.log("Removing domain from list: " + domain)
            VpnBypassImpl.deleteRoutes(domainNode)

            domainNode.Remove()
            FileIO.saveDomainList()
            FileIO.deleteSpecificDomainList(domainNode)

            ' Refresh Routed IP list
            Route.print()
        End If
    End Sub

    ' Update
    Private Sub BtnForceUpdateRoutes_Click(sender As Object, e As EventArgs) Handles BtnForceUpdateRoutes.Click, Button1.Click
        VpnBypassImpl.log("Forced update at: " & DateTime.Now)
        NSLookUp.all()
        Notify.setBalloonTip("VPN Bypass has successfully refreshed and updated all specified IP routes.")
        VpnBypassImpl.log("")
    End Sub

    Private Sub UpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateToolStripMenuItem.Click
        BtnForceUpdateRoutes_Click(sender, e)
    End Sub

    ' Enable
    Private Sub BtnEnableAllRoutes_Click(sender As Object, e As EventArgs) Handles BtnEnableAllRoutes.Click
        VpnBypassImpl.log("Enable all routes at: " & DateTime.Now)
        VpnBypassImpl.applyRoutes()
        Notify.setBalloonTip("VPN Bypass has successfully enabled all specified IP routes.")
        VpnBypassImpl.log("")
    End Sub

    Private Sub EnableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnableToolStripMenuItem.Click
        BtnEnableAllRoutes_Click(sender, e)
    End Sub

    ' Disable
    Private Sub BtnDisableAllRoutes_Click(sender As Object, e As EventArgs) Handles BtnDisableAllRoutes.Click
        VpnBypassImpl.log("Disable all routes at: " & DateTime.Now)
        VpnBypassImpl.deleteRoutes()
        Notify.setBalloonTip("VPN Bypass has successfully disabled all specified IP routes.")
        VpnBypassImpl.log("")
    End Sub

    Private Sub DisableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisableToolStripMenuItem.Click
        BtnDisableAllRoutes_Click(sender, e)
    End Sub

    ' Add domain textbox behavior
    Private Sub TextBoxDomain_TextChanged(sender As Object, e As EventArgs)
        If TextBoxDomain.Text() = "" Then
            BtnAddDomain.Enabled = False
        ElseIf TextBoxDomain.Text() IsNot "example.com" And Not TextBoxDomain.ForeColor = Color.LightGray Then
            BtnAddDomain.Enabled = True
        End If
    End Sub

    Private Sub TextBoxDomain_GotFocus(sender As Object, e As EventArgs)
        If TextBoxDomain.Text() = "example.com" And TextBoxDomain.ForeColor() = Color.LightGray Then
            TextBoxDomain.ForeColor = Color.Black
            TextBoxDomain.Text = ""
        End If
    End Sub

    Private Sub TextBoxDomain_LostFocus(sender As Object, e As EventArgs)
        If TextBoxDomain.Text() = "" Then
            TextBoxDomain.ForeColor = Color.LightGray
            TextBoxDomain.Text = "example.com"
        End If
    End Sub

    Private Sub TreeViewDomains_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeViewDomains.AfterSelect
        Dim selectedNode As TreeNode = TreeViewDomains.SelectedNode
        If selectedNode IsNot Nothing Then
            If selectedNode.Parent Is Nothing Then
                BtnRemoveDomain.Enabled = True
            Else
                BtnRemoveDomain.Enabled = False
            End If
        Else
            BtnRemoveDomain.Enabled = False
        End If
    End Sub

    '============================================================
    'SETTINGS
    '============================================================

    Private Sub TextBox_IpAddress_TextChanged(sender As Object, e As EventArgs) Handles TextBox_IpAddress.TextChanged

    End Sub

    Private Sub TextBox_IpAddress_GotFocus(sender As Object, e As EventArgs) Handles TextBox_IpAddress.GotFocus
        If TextBox_IpAddress.Text() = "Override Host IP" Then
            TextBox_IpAddress.ForeColor = Color.Black
            TextBox_IpAddress.Text = ""
        End If
    End Sub

    Private Sub TextBox_IpAddress_LostFocus(sender As Object, e As EventArgs) Handles TextBox_IpAddress.LostFocus
        If TextBox_IpAddress.Text() = "" Then
            TextBox_IpAddress.ForeColor = Color.LightGray
            TextBox_IpAddress.Text = "Override Host IP"
        End If
    End Sub

    Private Sub TextBox_DefaultGateway_TextChanged(sender As Object, e As EventArgs) Handles TextBox_DefaultGateway.TextChanged

    End Sub

    Private Sub TextBox_DefaultGateway_GotFocus(sender As Object, e As EventArgs) Handles TextBox_DefaultGateway.GotFocus
        If TextBox_DefaultGateway.Text() = "Override Gateway" Then
            TextBox_DefaultGateway.ForeColor = Color.Black
            TextBox_DefaultGateway.Text = ""
        End If
    End Sub

    Private Sub TextBox_DefaultGateway_LostFocus(sender As Object, e As EventArgs) Handles TextBox_DefaultGateway.LostFocus
        If TextBox_DefaultGateway.Text() = "" Then
            TextBox_DefaultGateway.ForeColor = Color.LightGray
            TextBox_DefaultGateway.Text = "Override Gateway"
        End If
    End Sub

    Private Sub TextBox_SubnetMask_TextChanged(sender As Object, e As EventArgs) Handles TextBox_SubnetMask.TextChanged

    End Sub

    Private Sub TextBox_SubnetMask_GotFocus(sender As Object, e As EventArgs) Handles TextBox_SubnetMask.GotFocus
        If TextBox_SubnetMask.Text() = "Override Subnet Mask" Then
            TextBox_SubnetMask.ForeColor = Color.Black
            TextBox_SubnetMask.Text = ""
        End If
    End Sub

    Private Sub TextBox_SubnetMask_LostFocus(sender As Object, e As EventArgs) Handles TextBox_SubnetMask.LostFocus
        If TextBox_SubnetMask.Text() = "" Then
            TextBox_SubnetMask.ForeColor = Color.LightGray
            TextBox_SubnetMask.Text = "Override Subnet Mask"
        End If
    End Sub

    Private Sub BtnApplySettings_Click(sender As Object, e As EventArgs) Handles BtnApplySettings.Click
        If TextBox_IpAddress.Text() = "Override Host Ip" Then
            NetworkInfo.hostIp = Val_IpAddress.Text()
        Else
            NetworkInfo.hostIp = TextBox_IpAddress.Text()
        End If

        If TextBox_DefaultGateway.Text() = "Override Gateway" Then
            NetworkInfo.gatewayIp = Val_DefaultGateway.Text()
        Else
            NetworkInfo.gatewayIp = TextBox_DefaultGateway.Text()
        End If

        If TextBox_SubnetMask.Text() = "Override Subnet Mask" Then
            NetworkInfo.subnetMaskIp = Val_SubnetMask.Text()
        Else
            NetworkInfo.subnetMaskIp = TextBox_SubnetMask.Text()
        End If
    End Sub

    '============================================================
    ' FORM
    '============================================================

    ' Track resize changes
    Private Sub VpnBypass_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Notify.setBalloonTip("VPN Bypass is still running in the background. To exit, right click the system tray icon and click 'Exit'.")
            Me.Hide()
        Else
            VpnBypassWindowState = Me.WindowState
        End If
    End Sub

    ' Load
    Private Sub VpnBypass_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        VpnBypassImpl.log("Startup at: " & DateTime.Now + vbCrLf)

        ' Log Adapter Info for debugging
        NetworkInfo.getAdapterInfo()

        ' Process mapped routes
        Route.print()

        ' Open domain list
        VpnBypassImpl.log("Opening saved domain lists...")
        FileIO.openDomainList()
        VpnBypassImpl.log("Startup complete." + vbCrLf)

        ' Setup scheduled hourly update task
        schedule()

        ' Add System Tray Icon
        Notify.setSystemTrayIcon()

        ' Version
        Me.LblVersion.Text = "version " + Me.ProductVersion
    End Sub

    Private Sub VpnBypass_Closing(sender As Object, e As FormClosingEventArgs) Handles Me.Closing
        Select Case e.CloseReason
            Case CloseReason.ApplicationExitCall
                ' The user perfromed an action that caused your code to call Application.Exit.
                ' You could go either way here but I'd suggest that you shouldn't be calling Application.Exit
                ' if you don't actually want the application to exit.  In that case close the main form instead.
                e.Cancel = False
            Case CloseReason.FormOwnerClosing
                ' This form Is a modeless dialogue, which you shouldn't be minimising to the system tray anyway.
                e.Cancel = False
            Case CloseReason.MdiFormClosing
                ' This form Is an MDI child form, which you shouldn't be minimising to the system tray anyway.
                e.Cancel = False
            Case CloseReason.None
                ' If the reason can't be determined then something funky is going on so I'd suggest you let the form close.
                e.Cancel = False
            Case CloseReason.TaskManagerClosing
                ' The user pressed the End Task button on the Applications tab (Not the Processes tab) of the Task Manager.
                ' You could go either way here too.  It really depends on your app And if you don't want the user to be able to exit
                ' this way.  I'd suggest letting the form close but there would definitely be legitimate reasons for preventing it.
                e.Cancel = False
            Case CloseReason.UserClosing
                ' The user clicked the Close button on the title bar, pressed Alt+F4, selected Close from the
                ' system menu Or performed some action that caused your code to call the form's Close method.
                ' Don't let the form close.
                e.Cancel = True
                Me.Hide()
            Case CloseReason.WindowsShutDown
                ' Windows Is shutting down.
                ' Definitely let the form close Or you'll prevent Windows shutting down normally.
                e.Cancel = False
        End Select
    End Sub

    '============================================================
    ' SYSTEM TRAY
    '============================================================

    ' Show/Hide App from System Tray
    Private Sub NotifyIcon_DoubleClick(sender As Object, e As EventArgs) Handles NotifyIcon.DoubleClick
        If Me.Visible = True Then
            Me.Hide()
        Else
            Me.Show()
            Me.WindowState = VpnBypassWindowState
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Me.Show()
        Me.WindowState = VpnBypassWindowState
        Me.TabControlVpnBypass.SelectedTab = Me.TabSettings
    End Sub

    Private Sub ToolStripMenuItemExit_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemExit.Click
        VpnBypassImpl.log("Closed at: " & DateTime.Now)
        Application.Exit()
    End Sub

    '============================================================
    ' SCHEDULE
    '============================================================

    ' Schedule start
    Public Sub schedule()
        dt = New System.Windows.Threading.DispatcherTimer()
        dt.Interval = New TimeSpan(0, 1, 0, 0, 0)
        dt.Start()
    End Sub

    ' Schedule event
    Private Sub dt_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles dt.Tick
        VpnBypassImpl.log("Scheduled update at: " & DateTime.Now)
        NSLookUp.all()
        VpnBypassImpl.log("")
    End Sub
End Class
