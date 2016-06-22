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
        Me.TabControlVpnBypass = New System.Windows.Forms.TabControl()
        Me.TabVpnBypass = New System.Windows.Forms.TabPage()
        Me.TreeViewDomains = New System.Windows.Forms.TreeView()
        Me.TextBoxDomain = New System.Windows.Forms.TextBox()
        Me.BtnRemoveDomain = New System.Windows.Forms.Button()
        Me.BtnAddDomain = New System.Windows.Forms.Button()
        Me.TabSettings = New System.Windows.Forms.TabPage()
        Me.Val_NetMask = New System.Windows.Forms.Label()
        Me.Val_DefaultGateway = New System.Windows.Forms.Label()
        Me.Val_IpAddress = New System.Windows.Forms.Label()
        Me.Lbl_NetMask = New System.Windows.Forms.Label()
        Me.Lbl_DefaultGateway = New System.Windows.Forms.Label()
        Me.Lbl_IpAddress = New System.Windows.Forms.Label()
        Me.BtnDeleteRoutes = New System.Windows.Forms.Button()
        Me.BtnUpdate = New System.Windows.Forms.Button()
        Me.TabDebug = New System.Windows.Forms.TabPage()
        Me.TextBoxDebug = New System.Windows.Forms.TextBox()
        Me.TabControlVpnBypass.SuspendLayout()
        Me.TabVpnBypass.SuspendLayout()
        Me.TabSettings.SuspendLayout()
        Me.TabDebug.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControlVpnBypass
        '
        Me.TabControlVpnBypass.Controls.Add(Me.TabVpnBypass)
        Me.TabControlVpnBypass.Controls.Add(Me.TabSettings)
        Me.TabControlVpnBypass.Controls.Add(Me.TabDebug)
        Me.TabControlVpnBypass.Location = New System.Drawing.Point(10, 12)
        Me.TabControlVpnBypass.Name = "TabControlVpnBypass"
        Me.TabControlVpnBypass.SelectedIndex = 0
        Me.TabControlVpnBypass.Size = New System.Drawing.Size(368, 221)
        Me.TabControlVpnBypass.TabIndex = 0
        '
        'TabVpnBypass
        '
        Me.TabVpnBypass.Controls.Add(Me.TreeViewDomains)
        Me.TabVpnBypass.Controls.Add(Me.TextBoxDomain)
        Me.TabVpnBypass.Controls.Add(Me.BtnRemoveDomain)
        Me.TabVpnBypass.Controls.Add(Me.BtnAddDomain)
        Me.TabVpnBypass.Location = New System.Drawing.Point(4, 22)
        Me.TabVpnBypass.Name = "TabVpnBypass"
        Me.TabVpnBypass.Padding = New System.Windows.Forms.Padding(3)
        Me.TabVpnBypass.Size = New System.Drawing.Size(360, 195)
        Me.TabVpnBypass.TabIndex = 0
        Me.TabVpnBypass.Text = "Domains"
        Me.TabVpnBypass.UseVisualStyleBackColor = True
        '
        'TreeViewDomains
        '
        Me.TreeViewDomains.Location = New System.Drawing.Point(6, 6)
        Me.TreeViewDomains.Name = "TreeViewDomains"
        Me.TreeViewDomains.Size = New System.Drawing.Size(348, 145)
        Me.TreeViewDomains.TabIndex = 6
        '
        'TextBoxDomain
        '
        Me.TextBoxDomain.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxDomain.Location = New System.Drawing.Point(6, 157)
        Me.TextBoxDomain.Name = "TextBoxDomain"
        Me.TextBoxDomain.Size = New System.Drawing.Size(214, 29)
        Me.TextBoxDomain.TabIndex = 4
        Me.TextBoxDomain.Text = "domain.tld"
        '
        'BtnRemoveDomain
        '
        Me.BtnRemoveDomain.Location = New System.Drawing.Point(293, 157)
        Me.BtnRemoveDomain.Name = "BtnRemoveDomain"
        Me.BtnRemoveDomain.Size = New System.Drawing.Size(61, 31)
        Me.BtnRemoveDomain.TabIndex = 3
        Me.BtnRemoveDomain.Text = "Remove"
        Me.BtnRemoveDomain.UseVisualStyleBackColor = True
        '
        'BtnAddDomain
        '
        Me.BtnAddDomain.Location = New System.Drawing.Point(226, 157)
        Me.BtnAddDomain.Name = "BtnAddDomain"
        Me.BtnAddDomain.Size = New System.Drawing.Size(61, 31)
        Me.BtnAddDomain.TabIndex = 2
        Me.BtnAddDomain.Text = "Add"
        Me.BtnAddDomain.UseVisualStyleBackColor = True
        '
        'TabSettings
        '
        Me.TabSettings.Controls.Add(Me.Val_NetMask)
        Me.TabSettings.Controls.Add(Me.Val_DefaultGateway)
        Me.TabSettings.Controls.Add(Me.Val_IpAddress)
        Me.TabSettings.Controls.Add(Me.Lbl_NetMask)
        Me.TabSettings.Controls.Add(Me.Lbl_DefaultGateway)
        Me.TabSettings.Controls.Add(Me.Lbl_IpAddress)
        Me.TabSettings.Location = New System.Drawing.Point(4, 22)
        Me.TabSettings.Name = "TabSettings"
        Me.TabSettings.Padding = New System.Windows.Forms.Padding(3)
        Me.TabSettings.Size = New System.Drawing.Size(360, 195)
        Me.TabSettings.TabIndex = 1
        Me.TabSettings.Text = "Settings"
        Me.TabSettings.UseVisualStyleBackColor = True
        '
        'Val_NetMask
        '
        Me.Val_NetMask.AutoSize = True
        Me.Val_NetMask.Location = New System.Drawing.Point(113, 62)
        Me.Val_NetMask.Name = "Val_NetMask"
        Me.Val_NetMask.Size = New System.Drawing.Size(40, 13)
        Me.Val_NetMask.TabIndex = 5
        Me.Val_NetMask.Text = "0.0.0.0"
        '
        'Val_DefaultGateway
        '
        Me.Val_DefaultGateway.AutoSize = True
        Me.Val_DefaultGateway.Location = New System.Drawing.Point(113, 39)
        Me.Val_DefaultGateway.Name = "Val_DefaultGateway"
        Me.Val_DefaultGateway.Size = New System.Drawing.Size(40, 13)
        Me.Val_DefaultGateway.TabIndex = 4
        Me.Val_DefaultGateway.Text = "0.0.0.0"
        '
        'Val_IpAddress
        '
        Me.Val_IpAddress.AutoSize = True
        Me.Val_IpAddress.Location = New System.Drawing.Point(113, 17)
        Me.Val_IpAddress.Name = "Val_IpAddress"
        Me.Val_IpAddress.Size = New System.Drawing.Size(40, 13)
        Me.Val_IpAddress.TabIndex = 3
        Me.Val_IpAddress.Text = "0.0.0.0"
        '
        'Lbl_NetMask
        '
        Me.Lbl_NetMask.AutoSize = True
        Me.Lbl_NetMask.Location = New System.Drawing.Point(9, 62)
        Me.Lbl_NetMask.Name = "Lbl_NetMask"
        Me.Lbl_NetMask.Size = New System.Drawing.Size(53, 13)
        Me.Lbl_NetMask.TabIndex = 2
        Me.Lbl_NetMask.Text = "Net Mask"
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
        'BtnDeleteRoutes
        '
        Me.BtnDeleteRoutes.Location = New System.Drawing.Point(259, 235)
        Me.BtnDeleteRoutes.Name = "BtnDeleteRoutes"
        Me.BtnDeleteRoutes.Size = New System.Drawing.Size(109, 32)
        Me.BtnDeleteRoutes.TabIndex = 2
        Me.BtnDeleteRoutes.Text = "Remove Routes"
        Me.BtnDeleteRoutes.UseVisualStyleBackColor = True
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Location = New System.Drawing.Point(144, 235)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(109, 32)
        Me.BtnUpdate.TabIndex = 3
        Me.BtnUpdate.Text = "Update IP Table"
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'TabDebug
        '
        Me.TabDebug.Controls.Add(Me.TextBoxDebug)
        Me.TabDebug.Location = New System.Drawing.Point(4, 22)
        Me.TabDebug.Name = "TabDebug"
        Me.TabDebug.Size = New System.Drawing.Size(360, 195)
        Me.TabDebug.TabIndex = 2
        Me.TabDebug.Text = "Debug"
        Me.TabDebug.UseVisualStyleBackColor = True
        '
        'TextBoxDebug
        '
        Me.TextBoxDebug.Location = New System.Drawing.Point(3, 3)
        Me.TextBoxDebug.Multiline = True
        Me.TextBoxDebug.Name = "TextBoxDebug"
        Me.TextBoxDebug.Size = New System.Drawing.Size(351, 189)
        Me.TextBoxDebug.TabIndex = 0
        Me.TextBoxDebug.WordWrap = False
        '
        'VpnBypass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(387, 280)
        Me.Controls.Add(Me.BtnUpdate)
        Me.Controls.Add(Me.BtnDeleteRoutes)
        Me.Controls.Add(Me.TabControlVpnBypass)
        Me.Name = "VpnBypass"
        Me.Text = "VPN Bypass"
        Me.TabControlVpnBypass.ResumeLayout(False)
        Me.TabVpnBypass.ResumeLayout(False)
        Me.TabVpnBypass.PerformLayout()
        Me.TabSettings.ResumeLayout(False)
        Me.TabSettings.PerformLayout()
        Me.TabDebug.ResumeLayout(False)
        Me.TabDebug.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControlVpnBypass As TabControl
    Friend WithEvents TabVpnBypass As TabPage
    Friend WithEvents BtnRemoveDomain As Button
    Friend WithEvents BtnAddDomain As Button
    Friend WithEvents TabSettings As TabPage
    Friend WithEvents Lbl_NetMask As Label
    Friend WithEvents Lbl_DefaultGateway As Label
    Friend WithEvents Lbl_IpAddress As Label
    Friend WithEvents TextBoxDomain As TextBox
    Friend WithEvents BtnDeleteRoutes As Button
    Friend WithEvents Val_IpAddress As Label
    Friend WithEvents Val_NetMask As Label
    Friend WithEvents Val_DefaultGateway As Label
    Friend WithEvents TreeViewDomains As TreeView
    Friend WithEvents BtnUpdate As Button
    Friend WithEvents TabDebug As TabPage
    Friend WithEvents TextBoxDebug As TextBox
End Class
