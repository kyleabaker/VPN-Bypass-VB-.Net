Imports System.IO

Module FileIO
    Public Sub OpenDomainList()
        Dim domainListPath = Application.StartupPath() + "\vpnbypass-domains.txt"
        Dim fs As FileStream

        ' Create or open the domain list
        If File.Exists(domainListPath) = False Then
            fs = File.Create(domainListPath)
        Else
            fs = File.Open(domainListPath, FileMode.Open)
        End If

        Try
            Using sr As New StreamReader(fs)
                Dim domains As String() = Strings.Split(sr.ReadToEnd(), vbCrLf)

                For Each domain In domains
                    If domain IsNot "" Then
                        AddDomain(domain)
                        Console.WriteLine(domain)

                        ' Read in stored list of ip's for this domain
                        OpenSpecificDomainList(domain)
                    End If
                Next
            End Using
        Catch e As Exception
            Console.WriteLine("Failed to read domain list file.")
            Console.WriteLine(e.Message)
        End Try

        ' Close file
        fs.Close()
    End Sub

    Public Sub SaveDomainList()
        Dim domainListPath = Application.StartupPath() + "\vpnbypass-domains.txt"
        Dim fs As FileStream

        ' Create or open the domain list
        If File.Exists(domainListPath) = False Then
            fs = File.Create(domainListPath)
        Else
            fs = File.Open(domainListPath, FileMode.Open)
        End If

        Try
            Using sr As New StreamReader(fs)
                'TODO Dim domain As String
                'domain = sr.ReadToEnd()
                'Console.WriteLine(domain)
            End Using
        Catch e As Exception
            Console.WriteLine("Failed to read domain list file.")
            Console.WriteLine(e.Message)
        End Try

        ' Close file
        fs.Close()
    End Sub

    Public Sub OpenSpecificDomainList(domain As String)
        Dim domainListPath = Application.StartupPath() + "\vpnbypass-domain-" + domain + ".txt"
        Dim fs As FileStream

        ' Create or open the domain list
        If File.Exists(domainListPath) = False Then
            fs = File.Create(domainListPath)
        Else
            fs = File.OpenRead(domainListPath)
        End If

        Try
            Using sr As New StreamReader(fs)
                Dim domainIps As String() = Strings.Split(sr.ReadToEnd(), vbCrLf)

                For Each ip In domainIps
                    VpnBypassImpl.AddDomainIp(domain, ip)
                    Console.WriteLine(ip)
                Next
            End Using
        Catch e As Exception
            Console.WriteLine("Failed to read specific domain ip list file: " + domainListPath)
            Console.WriteLine(e.Message)
        End Try

        ' Close file
        fs.Close()
    End Sub

    Public Sub SaveSpecificDomainList(domain As String, ipList As ArrayList)
        Dim domainListPath = Application.StartupPath() + "\vpnbypass-domain-" + domain + ".txt"
        Dim fs As FileStream

        ' Build output string
        Dim domainIpListOut As String = ""
        For Each ip In ipList
            If domainIpListOut IsNot "" Then
                domainIpListOut += vbCrLf
            End If
            domainIpListOut += ip
        Next

        ' Create or open the domain list
        fs = File.Create(domainListPath)

        Try
            Using sw As New StreamWriter(fs)
                sw.Write(domainIpListOut)
                sw.Close()
            End Using
        Catch e As Exception
            Console.WriteLine("Failed to write specific domain ip list to file: " + domainListPath)
            Console.WriteLine(e.Message)
        End Try

        ' Close file
        fs.Close()
    End Sub
End Module
