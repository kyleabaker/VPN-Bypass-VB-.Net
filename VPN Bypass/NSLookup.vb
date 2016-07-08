Imports System.Net

Module NSLookUp
    ' Permform NSLookUp on all saved domains
    Public Sub all()
        VpnBypassForm.ProgressBar.Maximum = VpnBypassForm.TreeViewDomains.Nodes.Count
        VpnBypassForm.ProgressBar.Value = 0
        VpnBypassForm.ProgressBar.Visible = True

        For Each domainNode As TreeNode In VpnBypassForm.TreeViewDomains.Nodes
            VpnBypassForm.ProgressBar.Value += 1

            Dim domain As String = domainNode.Name

            ' Build list of previously saved ip's for this domain
            Dim oldIpNodes As TreeNode = New TreeNode()
            For Each ipNode As TreeNode In domainNode.Nodes
                Dim clone = ipNode.Clone()
                oldIpNodes.Nodes.Add(clone)
            Next

            ' Build list of ip's currently associated with this domain
            Dim newIpNodes As TreeNode = NSLookUp.one(domainNode)

            ' Remove old ip's from ip table
            For Each ipNode As TreeNode In oldIpNodes.Nodes
                Dim ip As String = ipNode.Name
                Dim opts As Hashtable = ipNode.Tag
                Dim age As Long = DateDiff(DateInterval.Hour, opts.Item("date"), Date.Now.ToUniversalTime) ' Age in hours, over 12 will be removed.

                ' Checks for removal
                Dim isPermanent As Boolean = opts.Item("permanent").ToString.Equals("true")
                Dim isInNewList As Boolean = newIpNodes.Nodes.ContainsKey(ip)
                Dim isExpired As Boolean = age > 24L

                ' If its not permanent, is expired now, and not in this new list
                If isPermanent = False And isExpired = True And isInNewList = False Then
                    VpnBypassImpl.log("NSLookUp Domain: " + domain + "; Remove: " + ip)
                    VpnBypassImpl.removeDomainIp(domainNode, ipNode)
                    Route.delete(ipNode)
                End If
            Next

            ' Add new ip's to ip table
            For Each ipNode As TreeNode In newIpNodes.Nodes
                Dim ip As String = ipNode.Name
                If oldIpNodes.Nodes.ContainsKey(ip) = False Then 'TODO Make sure individual ip isn't covered by existing IP Range
                    VpnBypassImpl.log("NSLookUp Domain: " + domain + "; Add: " + ip)
                    VpnBypassImpl.addDomainIp(domainNode, ipNode)
                    Route.add(ipNode)
                Else
                    ' Update date on ip node
                    VpnBypassImpl.updateDomainIp(domainNode, ipNode)
                End If
            Next

            ' Save changes
            FileIO.saveSpecificDomainList(domainNode)
        Next

        VpnBypassForm.ProgressBar.Visible = False

        ' Refresh Routed IP list
        Route.print()
    End Sub

    ' Permform NSLookUp on a specific domain
    Public Function one(domainNode As TreeNode) As TreeNode
        Dim domain As String = domainNode.Name
        Dim domainOpts As Hashtable = domainNode.Tag
        Dim ipNodes As TreeNode = New TreeNode()
        Dim retries As Integer = 1 'TODO set this from ui

        ' If this is an IP address and not a domain, return an empty list of ipNodes
        If IPv4.isValid(domainNode) = True Then
            Return ipNodes
        End If

        ' If this domain has nslookup disabled, return empty list of ipNodes
        If domainOpts.Item("nslookup").ToString = "false" Then
            Return ipNodes
        End If

        ' Attempt to process nslookup...
        For iter As Integer = 0 To retries - 1 Step 1
            ' .Net DNS Lookup
            ipNodes = doNetDnsLookup(ipNodes, domain)

            ' Windows Shell NsLookup
            ipNodes = doWindowsShellNsLookup(ipNodes, domain)

            ' JHSoftware DNS Lookup
            ipNodes = doJhsDnsLookup(ipNodes, domain)
        Next iter

        Return ipNodes
    End Function

    ' Perform DNS Lookup using OOTB .Net libraries.
    Private Function doNetDnsLookup(ipNodes As TreeNode, domain As String) As TreeNode
        Try
            Dim iphostentry As IPHostEntry = System.Net.Dns.GetHostEntry(domain)
            Dim addresses As IPAddress() = iphostentry.AddressList

            For Each address As IPAddress In addresses
                Dim ip As String = address.ToString
                If ipNodes.Nodes.ContainsKey(ip) = False Then
                    ' Create new default options for IP
                    Dim opts As Hashtable = New Hashtable
                    opts.Add("cidr", "32")
                    opts.Add("subnetMask", "255.255.255.255")
                    opts.Add("permanent", "false")

                    Dim ipNode As TreeNode = VpnBypassImpl.getNewTreeNode(ip, opts)
                    ipNodes.Nodes.Add(ipNode)
                End If
            Next

            iphostentry = New IPHostEntry
        Catch e As Exception
            'Console.WriteLine(e.Message) 'Debug purposes only
        End Try

        Return ipNodes
    End Function

    ' Windows system nslookup, perform DNS Lookup and parse output
    Private Function doWindowsShellNsLookup(ipNodes As TreeNode, domain As String) As TreeNode
        Try
            Dim process As New Process
            Dim startInfo As New ProcessStartInfo("nslookup", " " + domain + " 8.8.8.8") ' Google's DNS Server
            startInfo.UseShellExecute = False
            startInfo.RedirectStandardOutput = True
            startInfo.CreateNoWindow = True
            process.StartInfo = startInfo
            process.Start()

            ' Capture output
            Dim response As String
            Using sr As System.IO.StreamReader = process.StandardOutput
                response = sr.ReadToEnd()
            End Using
            process.Close()

            ' Parse response to select only associated ip's
            If response.IndexOf("Addresses:") > -1 Then
                response = response.Substring(response.IndexOf("Addresses:") + 10)
                If response.IndexOf("Aliases:") > -1 Then
                    response = response.Substring(0, response.IndexOf("Aliases:"))
                End If
                Dim ipList As String() = response.Split(vbCrLf.ToCharArray)
                For Each ipRaw As String In ipList
                    Dim ip = ipRaw.Replace(vbCrLf.ToCharArray, "").Replace(vbTab.ToCharArray, "").Trim()

                    ' Create new default options for IP
                    Dim opts As Hashtable = New Hashtable
                    opts.Add("cidr", "32")
                    opts.Add("subnetMask", "255.255.255.255")
                    opts.Add("permanent", "false")

                    Dim ipNode As TreeNode = VpnBypassImpl.getNewTreeNode(ip, opts)
                    If Not ip = "" And IPv4.isValid(ipNode) = True Then
                        If ipNodes.Nodes.ContainsKey(ip) = False Then
                            ipNodes.Nodes.Add(ipNode)
                        End If
                    ElseIf Not ip = "" And IPv6.isValid(ipNode) Then
                        ' log ipv6 since it's not supported current.
                        Console.WriteLine("Windows nslookup IPv6 skipped: " + ip) 'Debug purposes only
                    ElseIf Not ip = "" Then
                        Console.WriteLine("Windows nslookup ip failed: " + ip) 'Debug purposes only
                    End If
                Next
            End If
        Catch e As Exception
            'Console.WriteLine(e.Message) 'Debug purposes only
        End Try

        Return ipNodes
    End Function

    ' JHSoftware DNS Lookup
    Private Function doJhsDnsLookup(ipNodes As TreeNode, domain As String) As TreeNode
        Try
            Dim JhsOptions = New JHSoftware.DnsClient.RequestOptions()
            JhsOptions.DnsServers = {
                        System.Net.IPAddress.Parse("8.8.8.8"), ' Google's DNS Servers
                        System.Net.IPAddress.Parse("8.8.4.4"),
                        System.Net.IPAddress.Parse("208.67.222.222"), ' OpenDNS Servers
                        System.Net.IPAddress.Parse("208.67.220.220")
                    }
            Dim jhsIpAddresses = JHSoftware.DnsClient.LookupHost(domain, JHSoftware.DnsClient.IPVersion.IPv4, JhsOptions)
            For Each jhsIpAddress In jhsIpAddresses
                Dim ip As String = jhsIpAddress.ToString
                If ipNodes.Nodes.ContainsKey(ip) = False Then
                    ' Create new default options for IP
                    Dim opts As Hashtable = New Hashtable
                    opts.Add("cidr", "32")
                    opts.Add("subnetMask", "255.255.255.255")
                    opts.Add("permanent", "false")

                    Dim ipNode As TreeNode = VpnBypassImpl.getNewTreeNode(ip, opts)
                    ipNodes.Nodes.Add(ipNode)
                End If
            Next
        Catch e As Exception
            'Console.WriteLine(e.Message) 'Debug purposes only
        End Try

        Return ipNodes
    End Function
End Module
