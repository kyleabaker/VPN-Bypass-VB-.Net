<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VpnBypass
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VpnBypass))
        Me.TabControlVpnBypass = New System.Windows.Forms.TabControl()
        Me.TabVpnBypass = New System.Windows.Forms.TabPage()
        Me.TreeViewDomains = New System.Windows.Forms.TreeView()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.TabSettings = New System.Windows.Forms.TabPage()
        Me.Val_PublicIp = New System.Windows.Forms.Label()
        Me.Lbl_PublicIp = New System.Windows.Forms.Label()
        Me.LblVersion = New System.Windows.Forms.Label()
        Me.BtnApplySettings = New System.Windows.Forms.Button()
        Me.TextBox_SubnetMask = New System.Windows.Forms.TextBox()
        Me.TextBox_DefaultGateway = New System.Windows.Forms.TextBox()
        Me.TextBox_IpAddress = New System.Windows.Forms.TextBox()
        Me.Val_SubnetMask = New System.Windows.Forms.Label()
        Me.Val_DefaultGateway = New System.Windows.Forms.Label()
        Me.Val_IpAddress = New System.Windows.Forms.Label()
        Me.Lbl_SubnetMask = New System.Windows.Forms.Label()
        Me.Lbl_DefaultGateway = New System.Windows.Forms.Label()
        Me.Lbl_IpAddress = New System.Windows.Forms.Label()
        Me.TabAddEdit = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TextBoxDomain = New System.Windows.Forms.TextBox()
        Me.BtnAddDomain = New System.Windows.Forms.Button()
        Me.BtnDisableAllRoutes = New System.Windows.Forms.Button()
        Me.BtnForceUpdateRoutes = New System.Windows.Forms.Button()
        Me.BtnEnableAllRoutes = New System.Windows.Forms.Button()
        Me.NotifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EnableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DisableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.BtnRemoveDomain = New System.Windows.Forms.Button()
        Me.ContextMenuStripDomains = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DomainToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DNSIPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.EnableexamplecomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DisableexamplecomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControlVpnBypass.SuspendLayout()
        Me.TabVpnBypass.SuspendLayout()
        Me.TabSettings.SuspendLayout()
        Me.TabAddEdit.SuspendLayout()
        Me.ContextMenuStrip.SuspendLayout()
        Me.ContextMenuStripDomains.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControlVpnBypass
        '
        Me.TabControlVpnBypass.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlVpnBypass.Controls.Add(Me.TabVpnBypass)
        Me.TabControlVpnBypass.Controls.Add(Me.TabAddEdit)
        Me.TabControlVpnBypass.Controls.Add(Me.TabSettings)
        Me.TabControlVpnBypass.Location = New System.Drawing.Point(10, 10)
        Me.TabControlVpnBypass.Name = "TabControlVpnBypass"
        Me.TabControlVpnBypass.SelectedIndex = 0
        Me.TabControlVpnBypass.Size = New System.Drawing.Size(363, 226)
        Me.TabControlVpnBypass.TabIndex = 0
        '
        'TabVpnBypass
        '
        Me.TabVpnBypass.Controls.Add(Me.TreeViewDomains)
        Me.TabVpnBypass.Location = New System.Drawing.Point(4, 22)
        Me.TabVpnBypass.Name = "TabVpnBypass"
        Me.TabVpnBypass.Padding = New System.Windows.Forms.Padding(3)
        Me.TabVpnBypass.Size = New System.Drawing.Size(355, 200)
        Me.TabVpnBypass.TabIndex = 0
        Me.TabVpnBypass.Text = "Domains"
        Me.TabVpnBypass.UseVisualStyleBackColor = True
        '
        'TreeViewDomains
        '
        Me.TreeViewDomains.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeViewDomains.ContextMenuStrip = Me.ContextMenuStripDomains
        Me.TreeViewDomains.HideSelection = False
        Me.TreeViewDomains.ImageKey = "disabled"
        Me.TreeViewDomains.ImageList = Me.ImageList
        Me.TreeViewDomains.Location = New System.Drawing.Point(6, 6)
        Me.TreeViewDomains.Name = "TreeViewDomains"
        Me.TreeViewDomains.SelectedImageIndex = 0
        Me.TreeViewDomains.ShowNodeToolTips = True
        Me.TreeViewDomains.Size = New System.Drawing.Size(343, 188)
        Me.TreeViewDomains.TabIndex = 6
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "child")
        Me.ImageList.Images.SetKeyName(1, "disabled")
        Me.ImageList.Images.SetKeyName(2, "enabled")
        '
        'TabSettings
        '
        Me.TabSettings.Controls.Add(Me.Val_PublicIp)
        Me.TabSettings.Controls.Add(Me.Lbl_PublicIp)
        Me.TabSettings.Controls.Add(Me.LblVersion)
        Me.TabSettings.Controls.Add(Me.BtnApplySettings)
        Me.TabSettings.Controls.Add(Me.TextBox_SubnetMask)
        Me.TabSettings.Controls.Add(Me.TextBox_DefaultGateway)
        Me.TabSettings.Controls.Add(Me.TextBox_IpAddress)
        Me.TabSettings.Controls.Add(Me.Val_SubnetMask)
        Me.TabSettings.Controls.Add(Me.Val_DefaultGateway)
        Me.TabSettings.Controls.Add(Me.Val_IpAddress)
        Me.TabSettings.Controls.Add(Me.Lbl_SubnetMask)
        Me.TabSettings.Controls.Add(Me.Lbl_DefaultGateway)
        Me.TabSettings.Controls.Add(Me.Lbl_IpAddress)
        Me.TabSettings.Location = New System.Drawing.Point(4, 22)
        Me.TabSettings.Name = "TabSettings"
        Me.TabSettings.Padding = New System.Windows.Forms.Padding(3)
        Me.TabSettings.Size = New System.Drawing.Size(355, 200)
        Me.TabSettings.TabIndex = 1
        Me.TabSettings.Text = "Settings"
        Me.TabSettings.UseVisualStyleBackColor = True
        '
        'Val_PublicIp
        '
        Me.Val_PublicIp.AutoSize = True
        Me.Val_PublicIp.Location = New System.Drawing.Point(113, 84)
        Me.Val_PublicIp.Name = "Val_PublicIp"
        Me.Val_PublicIp.Size = New System.Drawing.Size(88, 13)
        Me.Val_PublicIp.TabIndex = 12
        Me.Val_PublicIp.Text = "255.255.255.255"
        '
        'Lbl_PublicIp
        '
        Me.Lbl_PublicIp.AutoSize = True
        Me.Lbl_PublicIp.Location = New System.Drawing.Point(9, 84)
        Me.Lbl_PublicIp.Name = "Lbl_PublicIp"
        Me.Lbl_PublicIp.Size = New System.Drawing.Size(49, 13)
        Me.Lbl_PublicIp.TabIndex = 11
        Me.Lbl_PublicIp.Text = "Public IP"
        '
        'LblVersion
        '
        Me.LblVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblVersion.ForeColor = System.Drawing.Color.DarkGray
        Me.LblVersion.Location = New System.Drawing.Point(250, 184)
        Me.LblVersion.Name = "LblVersion"
        Me.LblVersion.Size = New System.Drawing.Size(100, 13)
        Me.LblVersion.TabIndex = 10
        Me.LblVersion.Text = "version"
        Me.LblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnApplySettings
        '
        Me.BtnApplySettings.Location = New System.Drawing.Point(278, 106)
        Me.BtnApplySettings.Name = "BtnApplySettings"
        Me.BtnApplySettings.Size = New System.Drawing.Size(61, 29)
        Me.BtnApplySettings.TabIndex = 9
        Me.BtnApplySettings.Text = "Apply"
        Me.BtnApplySettings.UseVisualStyleBackColor = True
        '
        'TextBox_SubnetMask
        '
        Me.TextBox_SubnetMask.ForeColor = System.Drawing.Color.LightGray
        Me.TextBox_SubnetMask.Location = New System.Drawing.Point(216, 59)
        Me.TextBox_SubnetMask.Name = "TextBox_SubnetMask"
        Me.TextBox_SubnetMask.Size = New System.Drawing.Size(123, 20)
        Me.TextBox_SubnetMask.TabIndex = 8
        Me.TextBox_SubnetMask.Text = "Override Subnet Mask"
        '
        'TextBox_DefaultGateway
        '
        Me.TextBox_DefaultGateway.ForeColor = System.Drawing.Color.LightGray
        Me.TextBox_DefaultGateway.Location = New System.Drawing.Point(216, 36)
        Me.TextBox_DefaultGateway.Name = "TextBox_DefaultGateway"
        Me.TextBox_DefaultGateway.Size = New System.Drawing.Size(123, 20)
        Me.TextBox_DefaultGateway.TabIndex = 7
        Me.TextBox_DefaultGateway.Text = "Override Gateway"
        '
        'TextBox_IpAddress
        '
        Me.TextBox_IpAddress.ForeColor = System.Drawing.Color.LightGray
        Me.TextBox_IpAddress.Location = New System.Drawing.Point(216, 14)
        Me.TextBox_IpAddress.Name = "TextBox_IpAddress"
        Me.TextBox_IpAddress.Size = New System.Drawing.Size(123, 20)
        Me.TextBox_IpAddress.TabIndex = 6
        Me.TextBox_IpAddress.Text = "Override Host IP"
        Me.TextBox_IpAddress.Visible = False
        '
        'Val_SubnetMask
        '
        Me.Val_SubnetMask.AutoSize = True
        Me.Val_SubnetMask.Location = New System.Drawing.Point(113, 62)
        Me.Val_SubnetMask.Name = "Val_SubnetMask"
        Me.Val_SubnetMask.Size = New System.Drawing.Size(88, 13)
        Me.Val_SubnetMask.TabIndex = 5
        Me.Val_SubnetMask.Text = "255.255.255.255"
        '
        'Val_DefaultGateway
        '
        Me.Val_DefaultGateway.AutoSize = True
        Me.Val_DefaultGateway.Location = New System.Drawing.Point(113, 39)
        Me.Val_DefaultGateway.Name = "Val_DefaultGateway"
        Me.Val_DefaultGateway.Size = New System.Drawing.Size(88, 13)
        Me.Val_DefaultGateway.TabIndex = 4
        Me.Val_DefaultGateway.Text = "255.255.255.255"
        '
        'Val_IpAddress
        '
        Me.Val_IpAddress.AutoSize = True
        Me.Val_IpAddress.Location = New System.Drawing.Point(113, 17)
        Me.Val_IpAddress.Name = "Val_IpAddress"
        Me.Val_IpAddress.Size = New System.Drawing.Size(88, 13)
        Me.Val_IpAddress.TabIndex = 3
        Me.Val_IpAddress.Text = "255.255.255.255"
        '
        'Lbl_SubnetMask
        '
        Me.Lbl_SubnetMask.AutoSize = True
        Me.Lbl_SubnetMask.Location = New System.Drawing.Point(9, 62)
        Me.Lbl_SubnetMask.Name = "Lbl_SubnetMask"
        Me.Lbl_SubnetMask.Size = New System.Drawing.Size(70, 13)
        Me.Lbl_SubnetMask.TabIndex = 2
        Me.Lbl_SubnetMask.Text = "Subnet Mask"
        '
        'Lbl_DefaultGateway
        '
        Me.Lbl_DefaultGateway.AutoSize = True
        Me.Lbl_DefaultGateway.Location = New System.Drawing.Point(9, 39)
        Me.Lbl_DefaultGateway.Name = "Lbl_DefaultGateway"
        Me.Lbl_DefaultGateway.Size = New System.Drawing.Size(86, 13)
        Me.Lbl_DefaultGateway.TabIndex = 1
        Me.Lbl_DefaultGateway.Text = "Default Gateway"
        '
        'Lbl_IpAddress
        '
        Me.Lbl_IpAddress.AutoSize = True
        Me.Lbl_IpAddress.Location = New System.Drawing.Point(9, 17)
        Me.Lbl_IpAddress.Name = "Lbl_IpAddress"
        Me.Lbl_IpAddress.Size = New System.Drawing.Size(58, 13)
        Me.Lbl_IpAddress.TabIndex = 0
        Me.Lbl_IpAddress.Text = "IP Address"
        '
        'TabAddEdit
        '
        Me.TabAddEdit.Controls.Add(Me.Label3)
        Me.TabAddEdit.Controls.Add(Me.Label2)
        Me.TabAddEdit.Controls.Add(Me.Label1)
        Me.TabAddEdit.Controls.Add(Me.TextBox1)
        Me.TabAddEdit.Controls.Add(Me.ComboBox1)
        Me.TabAddEdit.Controls.Add(Me.TextBoxDomain)
        Me.TabAddEdit.Controls.Add(Me.BtnAddDomain)
        Me.TabAddEdit.Location = New System.Drawing.Point(4, 22)
        Me.TabAddEdit.Name = "TabAddEdit"
        Me.TabAddEdit.Size = New System.Drawing.Size(355, 200)
        Me.TabAddEdit.TabIndex = 2
        Me.TabAddEdit.Text = "Add"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Subnet Mask"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Refresh DNS"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Domain"
        '
        'TextBox1
        '
        Me.TextBox1.ForeColor = System.Drawing.Color.LightGray
        Me.TextBox1.Location = New System.Drawing.Point(137, 65)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(209, 20)
        Me.TextBox1.TabIndex = 9
        Me.TextBox1.Text = "Leave blank to use default"
        '
        'ComboBox1
        '
        Me.ComboBox1.DisplayMember = "Yes (default)"
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Yes (default)", "No"})
        Me.ComboBox1.Location = New System.Drawing.Point(137, 38)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(209, 21)
        Me.ComboBox1.TabIndex = 8
        '
        'TextBoxDomain
        '
        Me.TextBoxDomain.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxDomain.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxDomain.ForeColor = System.Drawing.Color.LightGray
        Me.TextBoxDomain.Location = New System.Drawing.Point(137, 12)
        Me.TextBoxDomain.Name = "TextBoxDomain"
        Me.TextBoxDomain.Size = New System.Drawing.Size(209, 20)
        Me.TextBoxDomain.TabIndex = 7
        Me.TextBoxDomain.Text = "example.com"
        '
        'BtnAddDomain
        '
        Me.BtnAddDomain.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAddDomain.Enabled = False
        Me.BtnAddDomain.Location = New System.Drawing.Point(284, 157)
        Me.BtnAddDomain.Name = "BtnAddDomain"
        Me.BtnAddDomain.Size = New System.Drawing.Size(62, 31)
        Me.BtnAddDomain.TabIndex = 5
        Me.BtnAddDomain.Text = "Add"
        Me.BtnAddDomain.UseVisualStyleBackColor = True
        '
        'BtnDisableAllRoutes
        '
        Me.BtnDisableAllRoutes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDisableAllRoutes.Location = New System.Drawing.Point(287, 242)
        Me.BtnDisableAllRoutes.Name = "BtnDisableAllRoutes"
        Me.BtnDisableAllRoutes.Size = New System.Drawing.Size(86, 32)
        Me.BtnDisableAllRoutes.TabIndex = 2
        Me.BtnDisableAllRoutes.Text = "Disable All"
        Me.BtnDisableAllRoutes.UseVisualStyleBackColor = True
        '
        'BtnForceUpdateRoutes
        '
        Me.BtnForceUpdateRoutes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnForceUpdateRoutes.Location = New System.Drawing.Point(10, 242)
        Me.BtnForceUpdateRoutes.Name = "BtnForceUpdateRoutes"
        Me.BtnForceUpdateRoutes.Size = New System.Drawing.Size(86, 32)
        Me.BtnForceUpdateRoutes.TabIndex = 3
        Me.BtnForceUpdateRoutes.Text = "Update All"
        Me.BtnForceUpdateRoutes.UseVisualStyleBackColor = True
        '
        'BtnEnableAllRoutes
        '
        Me.BtnEnableAllRoutes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEnableAllRoutes.Location = New System.Drawing.Point(195, 242)
        Me.BtnEnableAllRoutes.Name = "BtnEnableAllRoutes"
        Me.BtnEnableAllRoutes.Size = New System.Drawing.Size(86, 32)
        Me.BtnEnableAllRoutes.TabIndex = 4
        Me.BtnEnableAllRoutes.Text = "Enable All"
        Me.BtnEnableAllRoutes.UseVisualStyleBackColor = True
        '
        'NotifyIcon
        '
        Me.NotifyIcon.ContextMenuStrip = Me.ContextMenuStrip
        Me.NotifyIcon.Text = "VPN Bypass"
        Me.NotifyIcon.Visible = True
        '
        'ContextMenuStrip
        '
        Me.ContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnableToolStripMenuItem, Me.DisableToolStripMenuItem, Me.UpdateToolStripMenuItem, Me.ToolStripMenuItem2, Me.AboutToolStripMenuItem, Me.ToolStripMenuItemExit})
        Me.ContextMenuStrip.Name = "ContextMenuStrip"
        Me.ContextMenuStrip.Size = New System.Drawing.Size(130, 120)
        '
        'EnableToolStripMenuItem
        '
        Me.EnableToolStripMenuItem.Name = "EnableToolStripMenuItem"
        Me.EnableToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.EnableToolStripMenuItem.Text = "Enable"
        '
        'DisableToolStripMenuItem
        '
        Me.DisableToolStripMenuItem.Name = "DisableToolStripMenuItem"
        Me.DisableToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.DisableToolStripMenuItem.Text = "Disable"
        '
        'UpdateToolStripMenuItem
        '
        Me.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem"
        Me.UpdateToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.UpdateToolStripMenuItem.Text = "Update All"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(126, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'ToolStripMenuItemExit
        '
        Me.ToolStripMenuItemExit.Name = "ToolStripMenuItemExit"
        Me.ToolStripMenuItemExit.Size = New System.Drawing.Size(129, 22)
        Me.ToolStripMenuItemExit.Text = "Exit"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(10, 242)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(86, 32)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Update All"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ProgressBar
        '
        Me.ProgressBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar.Location = New System.Drawing.Point(10, 275)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(363, 8)
        Me.ProgressBar.TabIndex = 5
        Me.ProgressBar.Visible = False
        '
        'BtnRemoveDomain
        '
        Me.BtnRemoveDomain.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRemoveDomain.Enabled = False
        Me.BtnRemoveDomain.Location = New System.Drawing.Point(117, 243)
        Me.BtnRemoveDomain.Name = "BtnRemoveDomain"
        Me.BtnRemoveDomain.Size = New System.Drawing.Size(60, 31)
        Me.BtnRemoveDomain.TabIndex = 6
        Me.BtnRemoveDomain.Text = "Remove"
        Me.BtnRemoveDomain.UseVisualStyleBackColor = True
        '
        'ContextMenuStripDomains
        '
        Me.ContextMenuStripDomains.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DomainToolStripMenuItem, Me.AddToolStripMenuItem, Me.RemoveToolStripMenuItem, Me.EditToolStripMenuItem, Me.DNSIPToolStripMenuItem, Me.AddToolStripMenuItem1, Me.RemoveToolStripMenuItem1, Me.EditToolStripMenuItem1, Me.ToolStripMenuItem1, Me.EnableexamplecomToolStripMenuItem, Me.DisableexamplecomToolStripMenuItem})
        Me.ContextMenuStripDomains.Name = "ContextMenuStrip1"
        Me.ContextMenuStripDomains.Size = New System.Drawing.Size(198, 230)
        '
        'DomainToolStripMenuItem
        '
        Me.DomainToolStripMenuItem.Enabled = False
        Me.DomainToolStripMenuItem.Name = "DomainToolStripMenuItem"
        Me.DomainToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.DomainToolStripMenuItem.Text = "Domain"
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.AddToolStripMenuItem.Text = "Add New"
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.RemoveToolStripMenuItem.Text = "Remove 'example.com'"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.EditToolStripMenuItem.Text = "Edit 'example.com'"
        '
        'DNSIPToolStripMenuItem
        '
        Me.DNSIPToolStripMenuItem.Enabled = False
        Me.DNSIPToolStripMenuItem.Name = "DNSIPToolStripMenuItem"
        Me.DNSIPToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.DNSIPToolStripMenuItem.Text = "DNS IP"
        '
        'AddToolStripMenuItem1
        '
        Me.AddToolStripMenuItem1.Name = "AddToolStripMenuItem1"
        Me.AddToolStripMenuItem1.Size = New System.Drawing.Size(197, 22)
        Me.AddToolStripMenuItem1.Text = "Add to 'example.com'"
        '
        'RemoveToolStripMenuItem1
        '
        Me.RemoveToolStripMenuItem1.Name = "RemoveToolStripMenuItem1"
        Me.RemoveToolStripMenuItem1.Size = New System.Drawing.Size(197, 22)
        Me.RemoveToolStripMenuItem1.Text = "Remove '0.0.0.0'"
        '
        'EditToolStripMenuItem1
        '
        Me.EditToolStripMenuItem1.Name = "EditToolStripMenuItem1"
        Me.EditToolStripMenuItem1.Size = New System.Drawing.Size(197, 22)
        Me.EditToolStripMenuItem1.Text = "Edit '0.0.0.0'"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(194, 6)
        '
        'EnableexamplecomToolStripMenuItem
        '
        Me.EnableexamplecomToolStripMenuItem.Name = "EnableexamplecomToolStripMenuItem"
        Me.EnableexamplecomToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.EnableexamplecomToolStripMenuItem.Text = "Enable 'example.com'"
        '
        'DisableexamplecomToolStripMenuItem
        '
        Me.DisableexamplecomToolStripMenuItem.Name = "DisableexamplecomToolStripMenuItem"
        Me.DisableexamplecomToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.DisableexamplecomToolStripMenuItem.Text = "Disable 'example.com'"
        '
        'VpnBypass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 286)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.BtnRemoveDomain)
        Me.Controls.Add(Me.BtnEnableAllRoutes)
        Me.Controls.Add(Me.BtnForceUpdateRoutes)
        Me.Controls.Add(Me.BtnDisableAllRoutes)
        Me.Controls.Add(Me.TabControlVpnBypass)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(400, 325)
        Me.Name = "VpnBypass"
        Me.Text = "VPN Bypass"
        Me.TabControlVpnBypass.ResumeLayout(False)
        Me.TabVpnBypass.ResumeLayout(False)
        Me.TabSettings.ResumeLayout(False)
        Me.TabSettings.PerformLayout()
        Me.TabAddEdit.ResumeLayout(False)
        Me.TabAddEdit.PerformLayout()
        Me.ContextMenuStrip.ResumeLayout(False)
        Me.ContextMenuStripDomains.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControlVpnBypass As TabControl
    Friend WithEvents TabVpnBypass As TabPage
    Friend WithEvents TabSettings As TabPage
    Friend WithEvents Lbl_SubnetMask As Label
    Friend WithEvents Lbl_DefaultGateway As Label
    Friend WithEvents Lbl_IpAddress As Label
    Friend WithEvents BtnDisableAllRoutes As Button
    Friend WithEvents Val_IpAddress As Label
    Friend WithEvents Val_SubnetMask As Label
    Friend WithEvents Val_DefaultGateway As Label
    Friend WithEvents BtnForceUpdateRoutes As Button
    Friend WithEvents TreeViewDomains As TreeView
    Friend WithEvents BtnEnableAllRoutes As Button
    Friend WithEvents TextBox_SubnetMask As TextBox
    Friend WithEvents TextBox_DefaultGateway As TextBox
    Friend WithEvents TextBox_IpAddress As TextBox
    Friend WithEvents BtnApplySettings As Button
    Friend WithEvents NotifyIcon As NotifyIcon
    Shadows WithEvents ContextMenuStrip As ContextMenuStrip
    Friend WithEvents ToolStripMenuItemExit As ToolStripMenuItem
    Friend WithEvents EnableToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DisableToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UpdateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LblVersion As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents ProgressBar As ProgressBar
    Friend WithEvents Val_PublicIp As Label
    Friend WithEvents Lbl_PublicIp As Label
    Friend WithEvents ImageList As ImageList
    Friend WithEvents TabAddEdit As TabPage
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents TextBoxDomain As TextBox
    Friend WithEvents BtnAddDomain As Button
    Friend WithEvents BtnRemoveDomain As Button
    Friend WithEvents ContextMenuStripDomains As ContextMenuStrip
    Friend WithEvents DomainToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DNSIPToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents RemoveToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents EnableexamplecomToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DisableexamplecomToolStripMenuItem As ToolStripMenuItem
End Class
