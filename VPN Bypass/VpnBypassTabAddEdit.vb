Module VpnBypassTabAddEdit
    '============================================================
    ' Common private functions
    '============================================================

    ' General show Add/Edit tab
    Private Sub show()
        VpnBypassForm.TabControl.SelectedTab = VpnBypassForm.TabAddEdit
    End Sub

    ' Show Add tab
    Private Sub showAdd()
        VpnBypassForm.TabAddEdit.Text = "Add"
        show()
    End Sub

    ' Show Edit tab
    Private Sub showEdit()
        VpnBypassForm.TabAddEdit.Text = "Edit"
        show()
    End Sub

    ' Hide Add/Edit tab (by selecting domain tab instead)
    Private Sub hide()
        reset()
        VpnBypassForm.TabControl.SelectedTab = VpnBypassForm.TabDomains
    End Sub

    ' Reset fields
    Private Sub reset()
        ' Domain name
        VpnBypassForm.TextBoxDomainAddEdit.Text = "example.com"
        VpnBypassForm.TextBoxDomainAddEdit.ForeColor = Color.LightGray

        ' Refresh DNS combo
        VpnBypassForm.ComboBoxRefreshDnsAddEdit.SelectedIndex = 0

        ' Default domain subnet mask
        VpnBypassForm.TextBoxSubnetMaskAddEdit.Text = "Leave blank to use default"
        VpnBypassForm.TextBoxSubnetMaskAddEdit.ForeColor = Color.LightGray

        ' Purge Expired IP's combo
        VpnBypassForm.ComboBoxPurgeExpiredIpsAddEdit.SelectedIndex = 0

        ' Add/Edit button
        VpnBypassForm.ButtonAddDomainAddEdit.Text = "Add"
        VpnBypassForm.ButtonAddDomainAddEdit.Enabled = False
    End Sub

    ' Set domain fields
    Private Sub setDomainFields(domain As String, refresh As String, subnetMask As String, purgeExpired As String)
        ' Reset tab/fields for clean start
        reset()

        ' Set domain text if its specified
        If Not domain = vbEmpty Then
            VpnBypassForm.TextBoxDomainAddEdit.Text = domain
            VpnBypassForm.TextBoxDomainAddEdit.ForeColor = Color.LightGray
        End If

        ' Set refresh dns preference if its specified
        If Not refresh = vbEmpty Then
            VpnBypassForm.ComboBoxRefreshDnsAddEdit.SelectedText = refresh
        End If

        ' Set subnet mask if its specified
        If Not subnetMask = vbEmpty Then
            VpnBypassForm.TextBoxSubnetMaskAddEdit.Text = subnetMask
            VpnBypassForm.TextBoxSubnetMaskAddEdit.ForeColor = Color.LightGray
        End If

        ' Set purge expired preference if its specified
        If Not purgeExpired = vbEmpty Then
            VpnBypassForm.ComboBoxPurgeExpiredIpsAddEdit.SelectedText = purgeExpired
        End If
    End Sub

    ' Set ip address fields
    Private Sub setIpAddressFields()
        'TODO
    End Sub

    ' Set focus on TextBoxDomain form
    Private Sub focus()
        VpnBypassForm.TextBoxDomainAddEdit.Focus()
    End Sub

    ' Clear first input field and set focus on TextBoxDomain form
    Private Sub focusReset()
        VpnBypassForm.TextBoxDomainAddEdit.Text = ""
        VpnBypassForm.TextBoxDomainAddEdit.ForeColor = Color.Black
        focus()
    End Sub

    ' Reset domain menu to default/enabled/visible
    Private Sub resetMenu()
        ' Reset domain section
        VpnBypassForm.DomainToolStripMenuItem.Visible = True
        VpnBypassForm.AddToolStripMenuItem.Visible = True
        VpnBypassForm.RemoveToolStripMenuItem.Visible = True
        VpnBypassForm.EditToolStripMenuItem.Visible = True

        VpnBypassForm.AddToolStripMenuItem.Enabled = True
        VpnBypassForm.RemoveToolStripMenuItem.Enabled = True
        VpnBypassForm.EditToolStripMenuItem.Enabled = True

        VpnBypassForm.RemoveToolStripMenuItem.Text = "Remove 'example.com'"
        VpnBypassForm.EditToolStripMenuItem.Text = "Edit 'example.com'"

        ' Reset separator
        VpnBypassForm.ToolStripSeparator1.Visible = True

        ' Reset ip section
        VpnBypassForm.DNSIPToolStripMenuItem.Visible = True
        VpnBypassForm.AddToolStripMenuItem1.Visible = True
        VpnBypassForm.RemoveToolStripMenuItem1.Visible = True
        VpnBypassForm.EditToolStripMenuItem1.Visible = True

        VpnBypassForm.AddToolStripMenuItem1.Enabled = True
        VpnBypassForm.RemoveToolStripMenuItem1.Enabled = True
        VpnBypassForm.EditToolStripMenuItem1.Enabled = True

        VpnBypassForm.AddToolStripMenuItem1.Text = "Add to 'example.com'"
        VpnBypassForm.RemoveToolStripMenuItem1.Text = "Remove '0.0.0.0'"
        VpnBypassForm.EditToolStripMenuItem1.Text = "Edit '0.0.0.0'"

        ' Reset separator
        VpnBypassForm.ToolStripSeparator2.Visible = True

        ' Reset enable/disable all
        VpnBypassForm.EnableexamplecomToolStripMenuItem.Visible = True
        VpnBypassForm.DisableexamplecomToolStripMenuItem.Visible = True

        VpnBypassForm.EnableexamplecomToolStripMenuItem.Enabled = True
        VpnBypassForm.DisableexamplecomToolStripMenuItem.Enabled = True

        VpnBypassForm.EnableexamplecomToolStripMenuItem.Text = "Enable 'example.com'"
        VpnBypassForm.DisableexamplecomToolStripMenuItem.Text = "Disable 'example.com'"
    End Sub

    ' Return selected domain node (or domain node of selected ip)
    Private Function getDomainNode() As TreeNode
        Dim selectedNode As TreeNode = VpnBypassForm.TreeViewDomains.SelectedNode
        Dim domainNode As TreeNode = New TreeNode

        ' Check if a list item was selected
        If selectedNode IsNot Nothing Then
            ' Check if selected item is domain or IP node
            If selectedNode.Parent Is Nothing Then
                ' Domain selected
                domainNode = selectedNode
            Else
                ' IP Child node selected
                Dim ipNode As TreeNode = selectedNode
                domainNode = ipNode.Parent
            End If
        Else
            ' No list item was selected. Nothing to do.
        End If

        Return domainNode
    End Function

    ' Return selected ip node
    Private Function getIpNode() As TreeNode
        Dim selectedNode As TreeNode = VpnBypassForm.TreeViewDomains.SelectedNode
        Dim ipNode As TreeNode = New TreeNode

        ' Check if a list item was selected
        If selectedNode IsNot Nothing Then
            ' Check if selected item is domain or IP node
            If selectedNode.Parent Is Nothing Then
                ' Domain selected. Nothing to do.
            Else
                ' IP Child node selected
                ipNode = selectedNode
            End If
        Else
            ' No list item was selected. Nothing to do.
        End If

        Return ipNode
    End Function

    '============================================================
    ' Public action functions
    '============================================================

    ' Initialize add/edit form elements that don't have defaults set
    Public Sub init()
        VpnBypassForm.ComboBoxRefreshDnsAddEdit.SelectedIndex = 0
        VpnBypassForm.ComboBoxPurgeExpiredIpsAddEdit.SelectedIndex = 0
    End Sub

    ' Domain textbox changed
    Public Sub doDomainTextboxChanged()
        If VpnBypassForm.TextBoxDomainAddEdit.Text() = "" Then
            VpnBypassForm.ButtonAddDomainAddEdit.Enabled = False
        ElseIf VpnBypassForm.TextBoxDomainAddEdit.Text() IsNot "example.com" And Not VpnBypassForm.TextBoxDomainAddEdit.ForeColor = Color.LightGray Then
            VpnBypassForm.ButtonAddDomainAddEdit.Enabled = True
        End If
    End Sub

    ' Domain textbox got focus
    Public Sub doDomainTextboxGotFocus()
        If VpnBypassForm.TextBoxDomainAddEdit.Text() = "example.com" And VpnBypassForm.TextBoxDomainAddEdit.ForeColor() = Color.LightGray Then
            VpnBypassForm.TextBoxDomainAddEdit.ForeColor = Color.Black
            VpnBypassForm.TextBoxDomainAddEdit.Text = ""
        End If
    End Sub

    ' Domain textbox lost focus
    Public Sub doDomainTextboxLostFocus()
        If VpnBypassForm.TextBoxDomainAddEdit.Text() = "" Then
            VpnBypassForm.TextBoxDomainAddEdit.ForeColor = Color.LightGray
            VpnBypassForm.TextBoxDomainAddEdit.Text = "example.com"
        End If
    End Sub

    ' Subnet Mask textbox got focus
    Public Sub doSubnetMaskTextboxGotFocus()
        If VpnBypassForm.TextBoxSubnetMaskAddEdit.Text() = "Leave blank to use default" And VpnBypassForm.TextBoxSubnetMaskAddEdit.ForeColor() = Color.LightGray Then
            VpnBypassForm.TextBoxSubnetMaskAddEdit.Text = ""
            VpnBypassForm.TextBoxSubnetMaskAddEdit.ForeColor = Color.Black
        End If
    End Sub

    ' Subnet Mask textbox lost focus
    Public Sub doSubnetMaskTextboxLostFocus()
        If VpnBypassForm.TextBoxSubnetMaskAddEdit.Text() = "" Then
            VpnBypassForm.TextBoxSubnetMaskAddEdit.Text = "Leave blank to use default"
            VpnBypassForm.TextBoxSubnetMaskAddEdit.ForeColor = Color.LightGray
        End If
    End Sub

    ' Actions to apply when domain menu opens
    Public Sub doMenuOpen()
        Dim selectedNode As TreeNode = VpnBypassForm.TreeViewDomains.SelectedNode

        ' Check if a list item was selected
        If selectedNode IsNot Nothing Then
            ' Check if selected item is domain or IP node
            If selectedNode.Parent Is Nothing Then
                ' Domain selected, set selected domain name and hide remove/edit ip menu options
                Dim domainNode As TreeNode = selectedNode
                Dim domain As String = domainNode.Name

                ' Set domain options
                VpnBypassForm.RemoveToolStripMenuItem.Text = "Remove '" + domain + "'"
                VpnBypassForm.EditToolStripMenuItem.Text = "Edit '" + domain + "'"

                ' Set ip options, hide remove/edit
                VpnBypassForm.AddToolStripMenuItem1.Text = "Add to '" + domain + "'"
                VpnBypassForm.RemoveToolStripMenuItem1.Visible = False
                VpnBypassForm.EditToolStripMenuItem1.Visible = False

                ' Set enable/disable options
                VpnBypassForm.EnableexamplecomToolStripMenuItem.Text = "Enable '" + domain + "'"
                VpnBypassForm.DisableexamplecomToolStripMenuItem.Text = "Disable '" + domain + "'"
            Else
                ' IP Child node selected, set domain name and selected ip address
                Dim ipNode As TreeNode = selectedNode
                Dim ip As String = ipNode.Name
                Dim domainNode As TreeNode = ipNode.Parent
                Dim domain As String = domainNode.Name

                ' Set domain options
                VpnBypassForm.RemoveToolStripMenuItem.Text = "Remove '" + domain + "'"
                VpnBypassForm.EditToolStripMenuItem.Text = "Edit '" + domain + "'"

                ' Set ip options
                VpnBypassForm.AddToolStripMenuItem1.Text = "Add to '" + domain + "'"
                VpnBypassForm.RemoveToolStripMenuItem1.Text = "Remove '" + ip + "'"
                VpnBypassForm.EditToolStripMenuItem1.Text = "Edit '" + ip + "'"

                ' Set enable/disable options
                VpnBypassForm.EnableexamplecomToolStripMenuItem.Text = "Enable '" + domain + "'"
                VpnBypassForm.DisableexamplecomToolStripMenuItem.Text = "Disable '" + domain + "'"
            End If
        Else
            ' No list item was selected. Show minimal add domain, enable/disable all. 
            ' Hide remove/edit domain, only allow add
            VpnBypassForm.RemoveToolStripMenuItem.Visible = False
            VpnBypassForm.EditToolStripMenuItem.Visible = False

            ' Hide separator
            VpnBypassForm.ToolStripSeparator1.Visible = False

            ' Hide ip address menu options
            VpnBypassForm.DNSIPToolStripMenuItem.Visible = False
            VpnBypassForm.AddToolStripMenuItem1.Visible = False
            VpnBypassForm.RemoveToolStripMenuItem1.Visible = False
            VpnBypassForm.EditToolStripMenuItem1.Visible = False

            ' Hide separator
            VpnBypassForm.ToolStripSeparator2.Visible = False

            ' Hide enable/disable
            VpnBypassForm.EnableexamplecomToolStripMenuItem.Visible = False
            VpnBypassForm.DisableexamplecomToolStripMenuItem.Visible = False
        End If
    End Sub

    ' Actions to apply when domain menu closes
    Public Sub doMenuClose()
        resetMenu()
    End Sub

    ' Add new domain tab
    Public Sub doMenuAddDomain()
        showAdd()
        reset()
        focusReset()
    End Sub

    ' Remove selected domain
    Public Sub doMenuRemoveDomain()
        Dim selectedNode As TreeNode = VpnBypassForm.TreeViewDomains.SelectedNode
        If selectedNode IsNot Nothing Then
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
        End If
    End Sub

    ' Edit selected domain
    Public Sub doMenuEditDomain()
        Dim domainNode As TreeNode = getDomainNode()
        Dim domain As String = domainNode.Name
        Dim opts As Hashtable = domainNode.Tag
        Dim refresh As String = opts.Item("nslookup").ToString()
        Dim subnetMask As String = opts.Item("subnetMask").ToString() 'TODO
        Dim purgeExpired As String = opts.Item("purgeExpired").ToString()

        showEdit()
        setDomainFields(domain, refresh, subnetMask, purgeExpired)
        focus()
    End Sub

    ' Add IP to domain
    Public Sub doMenuAddIpAddress()
        'TODO
    End Sub

    ' Remove IP from routes table and domain node
    Public Sub doMenuRemoveIpAddress()
        Dim domainNode As TreeNode = getDomainNode()
        Dim ipNode As TreeNode = getIpNode()
        Route.delete(ipNode)
        VpnBypassImpl.removeDomainIp(domainNode, ipNode)
    End Sub

    ' Edit IP on domain
    Public Sub doMenuEditIpAddress()
        'TODO
    End Sub

    ' Apply/enable selected domain routes
    Public Sub doMenuEnableDomain()
        Dim domainNode As TreeNode = getDomainNode()
        VpnBypassImpl.applyRoutes(domainNode)
    End Sub

    ' Delete/disable selected domain routes
    Public Sub doMenuDisableDomain()
        Dim domainNode As TreeNode = getDomainNode()
        VpnBypassImpl.deleteRoutes(domainNode)
    End Sub

    ' Add from Add/Edit tab
    Public Sub ButtonAdd()
        Dim domain = VpnBypassForm.TextBoxDomainAddEdit.Text.ToLower()
        Dim opts As Hashtable = New Hashtable
        'TODO set subnet mask from ui settings
        opts.Add("nslookup", "true") 'TODO set this from ui settings

        Dim domainNode As TreeNode = VpnBypassImpl.getNewTreeNode(domain, opts)

        If VpnBypassForm.TreeViewDomains.Nodes.ContainsKey(domain) = False Then
            VpnBypassImpl.log("Adding domain to list: " + domain)
            VpnBypassImpl.addDomain(domainNode)
            VpnBypassImpl.addDomainIp(domainNode)
            VpnBypassImpl.applyRoutes(domainNode)
            FileIO.saveDomainList()
            FileIO.saveSpecificDomainList(domainNode)

            ' Refresh Routed IP list
            Route.print()
        End If

        ' Hide add/edit tab after adding/editing
        hide()
    End Sub

    ' Cancel Add/Edit tab
    Public Sub ButtonCancel()
        reset()
        hide()
    End Sub
End Module
