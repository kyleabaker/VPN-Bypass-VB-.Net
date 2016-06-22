Imports System.Net

Module NSLookUp
    Public Sub NSLookUpAll()
        For Each domainNode As TreeNode In VpnBypass.TreeViewDomains.Nodes
            Dim domain As String = domainNode.Text()

            ' Build list of previously saved ip's for this domain
            Dim oldIpList As ArrayList = New ArrayList
            For Each ipNode As TreeNode In domainNode.Nodes
                oldIpList.Add(ipNode.Text)
            Next

            ' Build list of ip's currently associated with this domain
            Dim newIpList As ArrayList = NSLookUp(domain)

            ' Remove old ip's from ip table
            Dim removeIpList As ArrayList = New ArrayList
            For Each ip As String In oldIpList
                If newIpList.Contains(ip) = False Then
                    removeIpList.Add(ip)
                    Console.WriteLine("Domain: " + domain + "; Remove: " + ip)
                End If
            Next

            ' Add any new ip's to ip table
            FileIO.SaveSpecificDomainList(domain, newIpList)
        Next
    End Sub

    Public Function NSLookUp(domain As String)
        Dim ipList As ArrayList = New ArrayList
        Dim retries As Integer = 10

        For iter As Integer = 0 To retries - 1 Step 1
            Try
                Dim iphostentry As IPHostEntry = System.Net.Dns.GetHostEntry(domain)
                Dim addresses As IPAddress() = iphostentry.AddressList

                For Each address As IPAddress In addresses
                    If ipList.Contains(address.ToString) = False Then
                        ipList.Add(address.ToString)
                    End If
                Next

                iphostentry = New IPHostEntry

                'Threading.Thread.Sleep(5000)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next iter

        Return ipList
    End Function
End Module
