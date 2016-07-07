Imports System.Net
Imports System.Net.NetworkInformation

Module NetworkInfo
    Public hostIp As String = "0.0.0.0"
    Public subnetMaskIp As String = "0.0.0.0"
    Public gatewayIp As String = "0.0.0.0"
    Public publicIp As String = "0.0.0.0"

    ' Detect Adapter Info
    Public Sub getAdapterInfo()
        ' Print Adapter info...
        Dim Interfaces As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Dim adapter As NetworkInterface

        Dim myAdapterProps As IPInterfaceProperties = Nothing
        Dim myGateways As GatewayIPAddressInformationCollection = Nothing

        For Each adapter In Interfaces
            If adapter.NetworkInterfaceType = NetworkInterfaceType.Loopback Then
                Continue For
            End If
            VpnBypassImpl.log(adapter.Name)
            VpnBypassImpl.log(adapter.Description)
            myAdapterProps = adapter.GetIPProperties
            myGateways = myAdapterProps.GatewayAddresses
            Dim IPInfo As UnicastIPAddressInformationCollection = adapter.GetIPProperties().UnicastAddresses
            Dim properties As IPInterfaceProperties = adapter.GetIPProperties()

            ' Find adapter IP and Subnet Mask IP's
            For Each IPAddressInfo As UnicastIPAddressInformation In IPInfo
                VpnBypassImpl.log("IP Address  : " & IPAddressInfo.Address.ToString)
                VpnBypassImpl.log("Subnet Mask : " & IPAddressInfo.IPv4Mask.ToString)
                If IPAddressInfo.Address.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                    hostIp = IPAddressInfo.Address.ToString
                    subnetMaskIp = IPAddressInfo.IPv4Mask.ToString

                    VpnBypassForm.Val_IpAddress.Text = hostIp
                    VpnBypassForm.Val_SubnetMask.Text = subnetMaskIp
                End If
            Next

            ' Find adapter Gateway IP's
            For Each Gateway As GatewayIPAddressInformation In myGateways
                VpnBypassImpl.log("Gateway IP  : " & Gateway.Address.ToString)
                If IPv4.isValid(Gateway.Address.ToString) = True Then
                    gatewayIp = Gateway.Address.ToString
                    VpnBypassForm.Val_DefaultGateway.Text = gatewayIp
                End If
            Next

            ' Find adapter DNS IP's
            For Each dnsAddress As System.Net.IPAddress In properties.DnsAddresses
                VpnBypassImpl.log("DNS Address : " & dnsAddress.ToString)
            Next

            VpnBypassImpl.log("")
        Next

        ' Print selected defaults to console
        VpnBypassImpl.log("Selected default configuration based on detected network adapters:")
        VpnBypassImpl.log("IP Address  : " + NetworkInfo.hostIp)
        VpnBypassImpl.log("Gateway IP  : " + NetworkInfo.gatewayIp)
        VpnBypassImpl.log("Subnet Mask : " + NetworkInfo.subnetMaskIp)

        ' Print public IP address
        NetworkInfo.getPublicIpAddress()
        VpnBypassImpl.log("Public IP   : " + NetworkInfo.publicIp + vbCrLf)
    End Sub

    ' Determine Public IP
    Public Sub getPublicIpAddress()
        ' URL options:
        ' - https://duckduckgo.com/?q=what+is+my+ip+address&ia=answer
        ' - http://bot.whatismyipaddress.com/
        ' - https://icanhazip.com/

        Dim wc As WebClient = New WebClient()
        Dim response As String = wc.DownloadString("http://bot.whatismyipaddress.com/")

        ' Regex to parse ip returned mixed in html.
        'Dim re As Regex = New Regex("((?:(?:[0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}(?:[0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5]))(?!\d)")
        'If re.IsMatch(response) = True Then
        '    Dim groups As GroupCollection = re.Match(response).Groups
        '    publicIp = groups.Item(0).ToString
        'End If

        ' Verify ip against IPv4 check
        If IPv4.isValid(response) = True Then
            publicIp = response
        End If

        VpnBypassForm.Val_PublicIp.Text = publicIp
    End Sub
End Module
