Imports System.ComponentModel

Public Class VpnBypassForm
    Dim WithEvents dt As System.Windows.Threading.DispatcherTimer

    '============================================================
    ' DOMAINS TAB / DOMAIN CONTEXT MENU
    '============================================================

    ' Show/Hide menu options based on selected list item
    Private Sub ContextMenuStripDomains_Opening(sender As Object, e As CancelEventArgs) Handles ContextMenuStripDomains.Opening
        VpnBypassTabAddEdit.doMenuOpen()
    End Sub

    ' Reset menu options when closed
    Private Sub ContextMenuStripDomains_Closed(sender As Object, e As ToolStripDropDownClosedEventArgs) Handles ContextMenuStripDomains.Closed
        VpnBypassTabAddEdit.doMenuClose()
    End Sub

    ' Menu add domain
    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        VpnBypassTabAddEdit.doMenuAddDomain()
    End Sub

    ' Menu remove domain
    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        VpnBypassTabAddEdit.doMenuRemoveDomain()
    End Sub

    ' Menu edit domain
    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        VpnBypassTabAddEdit.doMenuEditDomain()
    End Sub

    ' Menu add ip
    Private Sub AddToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem1.Click
        VpnBypassTabAddEdit.doMenuAddIpAddress()
    End Sub

    ' Menu remove ip
    Private Sub RemoveToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem1.Click
        VpnBypassTabAddEdit.doMenuRemoveIpAddress()
    End Sub

    ' Menu edit ip
    Private Sub EditToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem1.Click
        VpnBypassTabAddEdit.doMenuEditIpAddress()
    End Sub

    ' Menu enable domain
    Private Sub EnableexamplecomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnableexamplecomToolStripMenuItem.Click
        VpnBypassTabAddEdit.doMenuEnableDomain()
    End Sub

    ' Menu disable domain
    Private Sub DisableexamplecomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisableexamplecomToolStripMenuItem.Click
        VpnBypassTabAddEdit.doMenuDisableDomain()
    End Sub

    '============================================================
    ' ADD/EDIT TAB
    '============================================================

    ' Domain textbox changed, enable/disable Add button
    Private Sub TextBoxDomainAddEdit_TextChanged(sender As Object, e As EventArgs) Handles TextBoxDomainAddEdit.TextChanged
        'TODO VpnBypassTabAddEdit.doDomainTextboxChanged()
        If Me.TextBoxDomainAddEdit.Text() = "" Then
            Me.ButtonAddDomainAddEdit.Enabled = False
        ElseIf Me.TextBoxDomainAddEdit.Text() IsNot "example.com" And Not Me.TextBoxDomainAddEdit.ForeColor = Color.LightGray Then
            Me.ButtonAddDomainAddEdit.Enabled = True
        End If
    End Sub

    ' Domain textbox focused
    Private Sub TextBoxDomainAddEdit_GotFocus(sender As Object, e As EventArgs) Handles TextBoxDomainAddEdit.GotFocus
        VpnBypassTabAddEdit.doDomainTextboxGotFocus()
    End Sub

    ' Domain textbox lost focus
    Private Sub TextBoxDomainAddEdit_LostFocus(sender As Object, e As EventArgs) Handles TextBoxDomainAddEdit.LostFocus
        VpnBypassTabAddEdit.doDomainTextboxLostFocus()
    End Sub

    ' Subnet mask textbox focus
    Private Sub TextBoxSubnetMask_GotFocus(sender As Object, e As EventArgs) Handles TextBoxSubnetMaskAddEdit.GotFocus
        VpnBypassTabAddEdit.doSubnetMaskTextboxGotFocus()
    End Sub

    ' Subnet mask textbox lost focus
    Private Sub TextBoxSubnetMask_LostFocus(sender As Object, e As EventArgs) Handles TextBoxSubnetMaskAddEdit.LostFocus
        VpnBypassTabAddEdit.doSubnetMaskTextboxLostFocus()
    End Sub

    ' Add button
    Private Sub ButtonAddDomainAddEdit_Click(sender As Object, e As EventArgs) Handles ButtonAddDomainAddEdit.Click
        VpnBypassTabAddEdit.ButtonAdd()
    End Sub

    ' Domain 'ENTER' keypress
    Private Sub TextBoxDomain_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxDomainAddEdit.KeyPress
        If e.KeyChar = vbCr.ToCharArray() Then
            VpnBypassTabAddEdit.ButtonAdd()
        End If
    End Sub

    ' Cancel button
    Private Sub ButtonCancelDomainAddEdit_Click(sender As Object, e As EventArgs) Handles ButtonCancelDomainAddEdit.Click
        VpnBypassTabAddEdit.ButtonCancel()
    End Sub

    '============================================================
    'SETTINGS
    '============================================================

    ' IP Address override textbox changed
    Private Sub TextBox_IpAddress_TextChanged(sender As Object, e As EventArgs) Handles TextBox_IpAddress.TextChanged
        VpnBypassTabSettings.doIpAddressChanged()
    End Sub

    ' IP Address override textbox focus
    Private Sub TextBox_IpAddress_GotFocus(sender As Object, e As EventArgs) Handles TextBox_IpAddress.GotFocus
        VpnBypassTabSettings.doIpAddressGotFocus()
    End Sub

    ' IP Address override textbox lost focus
    Private Sub TextBox_IpAddress_LostFocus(sender As Object, e As EventArgs) Handles TextBox_IpAddress.LostFocus
        VpnBypassTabSettings.doIpAddressLostFocus()
    End Sub

    ' Default Gateway override textbox changed
    Private Sub TextBox_DefaultGateway_TextChanged(sender As Object, e As EventArgs) Handles TextBox_DefaultGateway.TextChanged
        VpnBypassTabSettings.doDefaultGatewayChanged()
    End Sub

    ' Default Gateway override textbox focus
    Private Sub TextBox_DefaultGateway_GotFocus(sender As Object, e As EventArgs) Handles TextBox_DefaultGateway.GotFocus
        VpnBypassTabSettings.doDefaultGatewayGotFocus()
    End Sub

    ' Default Gateway override textbox lost focus
    Private Sub TextBox_DefaultGateway_LostFocus(sender As Object, e As EventArgs) Handles TextBox_DefaultGateway.LostFocus
        VpnBypassTabSettings.doDefaultGatewayLostFocus()
    End Sub

    ' Subnet Mask override textbox changed
    Private Sub TextBox_SubnetMask_TextChanged(sender As Object, e As EventArgs) Handles TextBox_SubnetMask.TextChanged
        VpnBypassTabSettings.doSubnetMaskChanged()
    End Sub

    ' Subnet Mask override textbox focus
    Private Sub TextBox_SubnetMask_GotFocus(sender As Object, e As EventArgs) Handles TextBox_SubnetMask.GotFocus
        VpnBypassTabSettings.doSubnetMaskGotFocus()
    End Sub

    ' Subnet Mask override textbox lost focus
    Private Sub TextBox_SubnetMask_LostFocus(sender As Object, e As EventArgs) Handles TextBox_SubnetMask.LostFocus
        VpnBypassTabSettings.doSubnetMaskLostFocus()
    End Sub

    ' Apply override options on settings tab
    Private Sub BtnApplySettings_Click(sender As Object, e As EventArgs) Handles BtnApplySettings.Click
        VpnBypassTabSettings.doApply()
    End Sub

    '============================================================
    ' GLOBAL FOOTER BUTTONS
    '============================================================

    ' Update button
    Private Sub BtnForceUpdateRoutes_Click(sender As Object, e As EventArgs) Handles BtnForceUpdateRoutes.Click
        VpnBypassImpl.log("Forced update at: " & DateTime.Now)
        NSLookUp.all()
        Notify.setBalloonTip("VPN Bypass has successfully refreshed and updated all specified IP routes.")
        VpnBypassImpl.log("")
    End Sub

    ' Update menu
    Private Sub UpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateToolStripMenuItem.Click
        BtnForceUpdateRoutes_Click(sender, e)
    End Sub

    ' Enable button
    Private Sub BtnEnableAllRoutes_Click(sender As Object, e As EventArgs) Handles BtnEnableAllRoutes.Click
        VpnBypassImpl.log("Enable all routes at: " & DateTime.Now)
        VpnBypassImpl.applyRoutes()
        Notify.setBalloonTip("VPN Bypass has successfully enabled all specified IP routes.")
        VpnBypassImpl.log("")
    End Sub

    ' Enable menu
    Private Sub EnableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnableToolStripMenuItem.Click
        BtnEnableAllRoutes_Click(sender, e)
    End Sub

    ' Disable button
    Private Sub BtnDisableAllRoutes_Click(sender As Object, e As EventArgs) Handles BtnDisableAllRoutes.Click
        VpnBypassImpl.log("Disable all routes at: " & DateTime.Now)
        VpnBypassImpl.deleteRoutes()
        Notify.setBalloonTip("VPN Bypass has successfully disabled all specified IP routes.")
        VpnBypassImpl.log("")
    End Sub

    ' Disable menu
    Private Sub DisableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisableToolStripMenuItem.Click
        BtnDisableAllRoutes_Click(sender, e)
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
            Notify.setWindowState(Me.WindowState)
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

        ' Initialize Add/Edit tab
        VpnBypassTabAddEdit.init()

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
        Notify.toggle()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Me.Show()
        Me.WindowState = Notify.getWindowState()
        Me.TabControl.SelectedTab = Me.TabSettings
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
