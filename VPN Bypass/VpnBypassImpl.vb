Module VpnBypassImpl
    Public Sub AddDomain(domain As String)
        If domain IsNot "" And VpnBypass.TreeViewDomains.Nodes.ContainsKey(domain) = False Then
            VpnBypass.TreeViewDomains.Nodes.Add(domain, domain)
        End If
    End Sub

    Public Sub AddDomainIp(domain As String, ip As String)
        If ip IsNot "" And domain IsNot "" Then
            Dim branch = VpnBypass.TreeViewDomains.Nodes.Find(domain, True)
            branch(0).Nodes.Add(ip)
        End If
    End Sub

    Public Sub ApplyRoutes()

    End Sub

    Public Sub DeleteRoutes()

    End Sub
End Module
