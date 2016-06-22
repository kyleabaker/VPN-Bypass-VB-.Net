Imports System.Net.NetworkInformation

Module NetworkInfo
    Dim hostIp As String = "0.0.0.0"
    Dim subNetMaskIp As String = "0.0.0.0"
    Dim gatewayIp As String = "0.0.0.0"

    Public Sub GetIpAddress()
        Dim hostname As String = System.Net.Dns.GetHostName()
        Dim iphe As System.Net.IPHostEntry = Net.Dns.GetHostEntry(hostname)
        Dim ipaddress_v4 As String = hostIp

        For Each ipheal As System.Net.IPAddress In iphe.AddressList
            If ipheal.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                ipaddress_v4 = ipheal.ToString()
            End If
        Next

        VpnBypass.Val_IpAddress.Text = ipaddress_v4
    End Sub

    Public Sub GetDefaultGateway()
        Dim myNetworkAdapters() As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces
        Dim myAdapterProps As IPInterfaceProperties = Nothing
        Dim myGateways As GatewayIPAddressInformationCollection = Nothing

        For Each adapter As NetworkInterface In myNetworkAdapters
            myAdapterProps = adapter.GetIPProperties

            myGateways = myAdapterProps.GatewayAddresses

            For Each Gateway As GatewayIPAddressInformation In myGateways
                gatewayIp = Gateway.Address.ToString
            Next
        Next

        VpnBypass.Val_DefaultGateway.Text = gatewayIp
    End Sub

    Public Sub GetSubnetMask()
        Dim hostname As String = System.Net.Dns.GetHostName()
        Dim iphe As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(hostname)

        For Each ipheal As System.Net.IPAddress In iphe.AddressList
            If ipheal.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                subNetMaskIp = ipheal.MapToIPv4.Broadcast.ToString()
            End If
        Next

        VpnBypass.Val_NetMask.Text = subNetMaskIp
    End Sub

    Public Sub AddRoute(ip As String)
        Dim cmd = "route -p add " + ip + " mask " + subNetMaskIp + " " + gatewayIp
        Console.WriteLine(cmd)
    End Sub
End Module
