Imports System.Text.RegularExpressions

Module Route
    Dim routes As Hashtable = New Hashtable

    ' Windows system nslookup, add specified route
    Public Sub add(ipNode As TreeNode)
        ' Check if already added
        If isRouted(ipNode) = False Then
            Dim ip As String = ipNode.Name
            Dim opts As Hashtable = ipNode.Tag
            Dim subnetMask As String = opts.Item("subnetMask").ToString

            Dim cmd = "C:\Windows\System32\ROUTE.exe -p add " + ip + " mask " + subnetMask + " " + NetworkInfo.gatewayIp
            VpnBypassImpl.log(cmd)

            ' Run shell command to add
            Shell(cmd, vbHide, True)
        End If
    End Sub

    ' Windows system nslookup, delete specified route
    Public Sub delete(ipNode As TreeNode)
        ' Check if exists in ip table
        If isRouted(ipNode) = True Then
            Dim ip As String = ipNode.Name

            Dim cmd = "C:\Windows\System32\ROUTE.exe delete " + ip
            VpnBypassImpl.log(cmd)

            ' Run shell command to delete
            Shell(cmd, vbHide, True)
        End If
    End Sub

    ' Windows system nslookup, perform print of DNS Lookup and parse output
    Public Sub print()
        ' Reset routes so we can insert a current list
        routes.Clear()

        Try
            Dim process As New Process
            Dim startInfo As New ProcessStartInfo("route", " print")
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

            VpnBypassImpl.log("C:\Windows\System32\ROUTE.exe print")
            VpnBypassImpl.log(response)

            ' Parse response to select only associated ip's
            If response.IndexOf("Persistent Routes:") > -1 Then
                response = response.Substring(response.IndexOf("Persistent Routes:"))
                response = response.Substring(response.IndexOf("Metric") + 6)
                response = response.Substring(0, response.IndexOf("===="))

                Dim ipList As String() = response.Split(vbCrLf.ToCharArray)
                For Each ipRow As String In ipList
                    Dim cleanRow = ipRow.Replace(vbTab.ToCharArray, "").Trim()
                    If Not cleanRow = "" Then
                        Dim re As Regex = New Regex("^([0-9.]+)(?: +)([0-9.]+)(?: +)([0-9.]+)(?: +)([0-9.,]+)$")
                        If re.IsMatch(cleanRow) = True Then
                            Dim groups As GroupCollection = re.Match(cleanRow).Groups
                            Dim networkAddress = groups.Item(1).ToString
                            Dim netmask = groups.Item(2).ToString
                            Dim gatewayAddress = groups.Item(3).ToString
                            Dim metric = groups.Item(4).ToString

                            ' Create CIDR based on subnet mask
                            Dim cidr As String = IPv4.getCidrFromSubnetMask(netmask)

                            ' Create IP node to reference later
                            Dim opts As Hashtable = New Hashtable
                            opts.Add("cidr", cidr)
                            opts.Add("subnetMask", netmask)
                            opts.Add("gatewayIp", gatewayAddress)
                            opts.Add("metric", metric)
                            Dim ipNode As TreeNode = VpnBypassImpl.getNewTreeNode(networkAddress, opts)

                            ' Add ip to routes list if it's not a duplicate
                            If routes.ContainsKey(networkAddress) = False Then
                                routes.Add(networkAddress, ipNode)
                            End If
                        End If
                    End If
                Next
            End If
        Catch e As Exception
            Console.WriteLine(e.Message) 'Debug purposes only
        End Try
    End Sub

    ' Determine whether or not ip is already routed
    Public Function isRouted(ipNode As TreeNode) As Boolean
        Dim ip As String = ipNode.Name
        Return routes.ContainsKey(ip)
    End Function
End Module
