Module VpnBypassImpl

    '============================================================
    ' Add/Remove/Update domain list
    '============================================================

    Public Sub addDomain(domainNode As TreeNode)
        Dim domain As String = domainNode.Name
        If domain IsNot "" And VpnBypassForm.TreeViewDomains.Nodes.ContainsKey(domain) = False Then
            domainNode.ImageKey = "disabled"
            domainNode.SelectedImageKey = "disabled"
            VpnBypassForm.TreeViewDomains.Nodes.Add(domainNode)
        End If
    End Sub

    Public Sub addDomainIp(domainNode As TreeNode)
        Dim ipList As TreeNode = NSLookUp.one(domainNode)

        For Each ipNode As TreeNode In ipList.Nodes
            addDomainIp(domainNode, ipNode)
        Next
    End Sub

    Public Sub addDomainIp(domainNode As TreeNode, ipNode As TreeNode)
        Dim domain As String = domainNode.Name
        Dim ip As String = ipNode.Name
        If ip IsNot "" And domain IsNot "" Then
            Dim branch = VpnBypassForm.TreeViewDomains.Nodes.Find(domain, True)
            ipNode.ImageKey = "child"
            ipNode.SelectedImageKey = "child"
            branch(0).Nodes.Add(ipNode)
        End If
    End Sub

    Public Sub updateDomainIp(domainNode As TreeNode, ipNode As TreeNode)
        Dim domain As String = domainNode.Name
        Dim ip As String = ipNode.Name
        If ip IsNot "" And domain IsNot "" Then
            Dim branch = VpnBypassForm.TreeViewDomains.Nodes.Find(domain, True)
            Dim leaf As TreeNode() = branch(0).Nodes.Find(ip, True)
            leaf(0) = ipNode
        End If
    End Sub

    Public Sub removeDomainIp(domainNode As TreeNode, ipNode As TreeNode)
        Dim domain As String = domainNode.Name
        Dim ip As String = ipNode.Name
        If ip IsNot "" And domain IsNot "" Then
            Dim branch = VpnBypassForm.TreeViewDomains.Nodes.Find(domain, True)
            branch(0).Nodes.RemoveByKey(ip)
        End If
    End Sub

    '============================================================
    ' Create new domain/ip node
    '============================================================

    Public Function getNewTreeNode(key As String, opts As Hashtable) As TreeNode
        Dim newNode As TreeNode = New TreeNode()
        newNode.Text = key
        newNode.Name = key
        opts.Add("date", Date.Now.ToUniversalTime())
        newNode.Tag = opts
        Return newNode
    End Function

    '============================================================
    ' Apply/Delete routes in domain list
    '============================================================

    Public Sub applyRoutes()
        VpnBypassForm.ProgressBar.Maximum = VpnBypassForm.TreeViewDomains.Nodes.Count
        VpnBypassForm.ProgressBar.Value = 0
        VpnBypassForm.ProgressBar.Visible = True

        For Each domainNode As TreeNode In VpnBypassForm.TreeViewDomains.Nodes
            VpnBypassForm.ProgressBar.Value += 1
            applyRoutes(domainNode)
        Next

        VpnBypassForm.ProgressBar.Visible = False

        ' Refresh Routed IP list
        Route.print()
    End Sub

    Public Sub applyRoutes(domainNode As TreeNode)
        ' Handle domain with associated IP addresses
        For Each ipNode As TreeNode In domainNode.Nodes
            Route.add(ipNode)
        Next

        ' Handle case where actual IP address was entered instead of domain name
        If IPv4.isValid(domainNode) = True Then
            Route.add(domainNode)
        End If

        ' Update domain icon to reflect enabled state.
        domainNode.ImageKey = "enabled"
        domainNode.SelectedImageKey = "enabled"
    End Sub

    Public Sub deleteRoutes()
        VpnBypassForm.ProgressBar.Maximum = VpnBypassForm.TreeViewDomains.Nodes.Count
        VpnBypassForm.ProgressBar.Value = 0
        VpnBypassForm.ProgressBar.Visible = True

        For Each domainNode As TreeNode In VpnBypassForm.TreeViewDomains.Nodes
            VpnBypassForm.ProgressBar.Value += 1
            deleteRoutes(domainNode)
        Next

        VpnBypassForm.ProgressBar.Visible = False

        ' Refresh Routed IP list
        Route.print()
    End Sub

    Public Sub deleteRoutes(domainNode As TreeNode)
        ' Handle domain with associated IP addresses
        For Each ipNode As TreeNode In domainNode.Nodes
            Route.delete(ipNode)
        Next

        ' Handle case where actual IP address was entered instead of domain name
        If IPv4.isValid(domainNode) = True Then
            Route.delete(domainNode)
        End If

        ' Update domain icon to reflect disabled state.
        domainNode.ImageKey = "disabled"
        domainNode.SelectedImageKey = "disabled"
    End Sub

    '============================================================
    ' Logging
    '============================================================

    Public Sub log(message As String)
        Console.WriteLine(message)
        FileIO.log(message)
    End Sub
End Module
