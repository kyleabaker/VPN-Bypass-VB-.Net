Imports System.IO

Module FileIO
    Dim fileExt As String = ".txt"
    Dim fileVpnBypass As String = "vpnbypass-"
    Dim fileDomain As String = fileVpnBypass + "domain-"
    Dim fileDomains As String = fileVpnBypass + "domains"
    Dim fileSeparator As String = "\"

    ' Open Domain List
    Public Sub openDomainList()
        Dim domainListPath = Application.StartupPath() + fileSeparator + fileDomains + fileExt

        If (File.Exists(domainListPath) = True) Then
            Try
                Using sr As New StreamReader(domainListPath)
                    Dim content As String() = Strings.Split(sr.ReadToEnd(), vbCrLf)

                    For Each row In content
                        If row IsNot "" Then
                            Dim domainInfo As String() = row.Split(",")
                            Dim domain As String = domainInfo(0) 'TODO add graceful error/defaults handling for short array
                            Dim nslookup As String = domainInfo(1)

                            ' Ensure nslookup option is defined
                            If nslookup = "" Then
                                nslookup = "true"
                            End If

                            Dim opts As Hashtable = New Hashtable
                            opts.Add("nslookup", nslookup)

                            Dim domainNode As TreeNode = VpnBypassImpl.getNewTreeNode(domain, opts)
                            VpnBypassImpl.addDomain(domainNode)
                            VpnBypassImpl.log(domain)

                            ' Read in stored list of ip's for this domain
                            openSpecificDomainList(domainNode)
                        End If
                    Next
                End Using
            Catch e As Exception
                VpnBypassImpl.log("Failed to read domain list from file: " + domainListPath)
                VpnBypassImpl.log(e.Message)
            End Try
        Else
            VpnBypassImpl.log("Domain list file not found: " + domainListPath)
        End If

    End Sub

    ' Save Domain List
    Public Sub saveDomainList()
        Dim domainListPath = Application.StartupPath() + fileSeparator + fileDomains + fileExt

        ' Create output string
        Dim domainListOut As String = ""
        For Each domainNode As TreeNode In VpnBypassForm.TreeViewDomains.Nodes
            Dim domain As String = domainNode.Name
            Dim opts As Hashtable = domainNode.Tag
            Dim nslookup As String = opts.Item("nslookup").ToString()

            If domainListOut IsNot "" Then
                domainListOut += vbCrLf
            End If
            domainListOut += domain + "," + nslookup
        Next

        Try
            Using sw As New StreamWriter(domainListPath)
                sw.Write(domainListOut)
            End Using
        Catch e As Exception
            VpnBypassImpl.log("Failed to write domain list to file: " + domainListPath)
            VpnBypassImpl.log(e.Message)
        End Try
    End Sub

    ' Open Domain's IP List
    Public Sub openSpecificDomainList(domainNode As TreeNode)
        Dim domain As String = domainNode.Name
        Dim domainListPath = Application.StartupPath() + fileSeparator + fileDomain + domain + fileExt

        If File.Exists(domainListPath) = True Then
            Try
                Using sr As New StreamReader(domainListPath)
                    Dim content As String() = Strings.Split(sr.ReadToEnd(), vbCrLf)
                    Dim isDomainFullyEnabled As Boolean = True

                    For Each row In content
                        Dim ipInfo As String() = row.Split(",")
                        Dim ip As String = IPv4.getIpAddressFromIpCidr(ipInfo(0)) 'TODO add graceful error/defaults handling for short array
                        Dim cidr As String = IPv4.getCidrFromIpCidr(ipInfo(0))
                        Dim subnetMask As String = ipInfo(1)
                        Dim permanent As String = ipInfo(2)

                        ' Ensure cidr and subnet mask are defined
                        If cidr = "" And IPv4.isValid(subnetMask) Then
                            cidr = IPv4.getCidrFromSubnetMask(subnetMask)
                        ElseIf subnetMask = "" And IPv4.isCidr(cidr) = True Then
                            subnetMask = IPv4.getSubnetMaskFromCidr(cidr)
                        ElseIf cidr = "" And subnetMask = "" Then
                            cidr = "32"
                            subnetMask = "255.255.255.255"
                        End If

                        ' Ensure permanent option is defined
                        If permanent = "" Then
                            permanent = "False"
                        End If

                        Dim opts As Hashtable = New Hashtable
                        opts.Add("cidr", cidr)
                        opts.Add("subnetMask", subnetMask)
                        opts.Add("permanent", permanent)

                        Dim ipNode As TreeNode = VpnBypassImpl.getNewTreeNode(ip, opts)
                        VpnBypassImpl.addDomainIp(domainNode, ipNode)
                        VpnBypassImpl.log("- " + ip)

                        ' Check if IP is already routed on import
                        If Route.isRouted(ipNode) = False Then
                            isDomainFullyEnabled = False
                        End If
                    Next

                    ' If all domain ip's are already routed, mark domain as enabled
                    If isDomainFullyEnabled = True Then
                        domainNode.ImageKey = "enabled"
                        domainNode.SelectedImageKey = "enabled"
                    End If
                End Using
            Catch e As Exception
                VpnBypassImpl.log("Failed to read specific domain ip list file: " + domainListPath)
                VpnBypassImpl.log(e.Message)
            End Try
        Else
            VpnBypassImpl.log("Specific domain list file not found: " + domainListPath)
        End If
    End Sub

    ' Save Domain's IP List
    Public Sub saveSpecificDomainList(domainNode As TreeNode)
        Dim domain As String = domainNode.Name
        Dim domainListPath = Application.StartupPath() + fileSeparator + fileDomain + domain + fileExt

        ' Build output string
        Dim domainIpListOut As String = ""
        For Each ipNode As TreeNode In domainNode.Nodes
            Dim ip As String = ipNode.Name
            Dim opts As Hashtable = ipNode.Tag
            Dim cidr As String = opts.Item("cidr").ToString()
            Dim subnetMask As String = opts.Item("subnetMask").ToString()
            Dim permanent As String = opts.Item("permanent").ToString()

            ' Save ip with or without cidr?
            If Not cidr = "" Then
                ip += "/" + cidr
            End If

            If domainIpListOut IsNot "" Then
                domainIpListOut += vbCrLf
            End If
            domainIpListOut += ip + "," + subnetMask + "," + permanent
        Next

        Try
            Using sw As New StreamWriter(domainListPath)
                sw.Write(domainIpListOut)
            End Using
        Catch e As Exception
            VpnBypassImpl.log("Failed to write specific domain ip list to file: " + domainListPath)
            VpnBypassImpl.log(e.Message)
        End Try
    End Sub

    ' Delete Domain's IP List
    Public Sub deleteSpecificDomainList(domainNode As TreeNode)
        Dim domain As String = domainNode.Name
        Dim domainListPath = Application.StartupPath() + fileSeparator + fileDomain + domain + fileExt

        If File.Exists(domainListPath) = True Then
            File.Delete(domainListPath)
        End If
    End Sub

    ' Write message to application log file
    Public Sub log(message)
        Dim logPath = Application.StartupPath() + fileSeparator + fileVpnBypass + "log" + fileExt

        ' Create or append to the log file
        Try
            My.Computer.FileSystem.WriteAllText(logPath, message + vbCrLf, True)
        Catch e As Exception
            ' Shouldn't log back to FileIO since it failed, only console.
            Console.WriteLine("Failed to write to log file: " + logPath)
            Console.WriteLine(e.Message)
        End Try
    End Sub
End Module
