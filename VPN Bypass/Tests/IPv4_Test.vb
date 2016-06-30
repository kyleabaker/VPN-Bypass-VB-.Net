Module IPv4_Test
    Public Sub run()
        VpnBypassImpl.log("IPv4 Test Starting...")

        ' Test IPv4.getCidrFromSubnetMask(subnetMask As String)
        doGetCidrFromSubnetMask()

        ' Test IPv4.getSubnetMaskFromCidr(subnetMask As String)
        doGetSubnetMaskFromCidr()

        ' Test IPv4.isCidr(cidr As String)
        doIsCidr()

        ' Test IPv4.getCidrFromIpCidr(ipCidr As String)
        doGetCidrFromIpCidr()

        ' Test IPv4.getIpAddressFromIpCidr(ipCidr As String)
        doGetIpAddressFromIpCidr()

        ' Test IPv4.isValid(node As TreeNode)
        ' Test IPv4.isValid(ip As String)
        doIsValid()

        VpnBypassImpl.log("IPv4 Test Complete")
    End Sub

    ' Test IPv4.getCidrFromSubnetMask(subnetMask As String)
    Private Sub doGetCidrFromSubnetMask()
        VpnBypassImpl.log("IPv4 Test: Convert Subnet Mask IP to CIDR")

        VpnBypassImpl.log("Testing: IPv4.getCidrFromSubnetMask('255.255.255.255') = '32'")
        If IPv4.getCidrFromSubnetMask("255.255.255.255") = "32" Then
            VpnBypassImpl.log("Pass")
        Else
            VpnBypassImpl.log("Fail")
        End If

        VpnBypassImpl.log("Testing: IPv4.getCidrFromSubnetMask('255.255.255.0') = '24'")
        If IPv4.getCidrFromSubnetMask("255.255.255.0") = "24" Then
            VpnBypassImpl.log("Pass")
        Else
            VpnBypassImpl.log("Fail")
        End If

        VpnBypassImpl.log("Testing: IPv4.getCidrFromSubnetMask('0.0.0.0') = '0'")
        If IPv4.getCidrFromSubnetMask("0.0.0.0") = "0" Then
            VpnBypassImpl.log("Pass")
        Else
            VpnBypassImpl.log("Fail")
        End If

        VpnBypassImpl.log("Testing: IPv4.getCidrFromSubnetMask('1.2.3.4') = '' (empty)")
        If IPv4.getCidrFromSubnetMask("1.2.3.4") = "" Then
            VpnBypassImpl.log("Pass")
        Else
            VpnBypassImpl.log("Fail")
        End If

    End Sub

    ' Test IPv4.getSubnetMaskFromCidr(subnetMask As String)
    Private Sub doGetSubnetMaskFromCidr()
        VpnBypassImpl.log("IPv4 Test: Convert CIDR to Subnet Mask IP")

        VpnBypassImpl.log("Testing: IPv4.getSubnetMaskFromCidr('32') = '255.255.255.255'")
        If IPv4.getSubnetMaskFromCidr("32") = "255.255.255.255" Then
            VpnBypassImpl.log("Pass")
        Else
            VpnBypassImpl.log("Fail")
        End If

        VpnBypassImpl.log("Testing: IPv4.getSubnetMaskFromCidr('24') = '255.255.255.0'")
        If IPv4.getSubnetMaskFromCidr("24") = "255.255.255.0" Then
            VpnBypassImpl.log("Pass")
        Else
            VpnBypassImpl.log("Fail")
        End If

        VpnBypassImpl.log("Testing: IPv4.getSubnetMaskFromCidr('0') = '0.0.0.0'")
        If IPv4.getSubnetMaskFromCidr("0") = "0.0.0.0" Then
            VpnBypassImpl.log("Pass")
        Else
            VpnBypassImpl.log("Fail")
        End If

        VpnBypassImpl.log("Testing: IPv4.getSubnetMaskFromCidr('') = '' (empty)")
        If IPv4.getSubnetMaskFromCidr("") = "" Then
            VpnBypassImpl.log("Pass")
        Else
            VpnBypassImpl.log("Fail")
        End If

    End Sub

    ' Test IPv4.isCidr(cidr As String)
    Private Sub doIsCidr()
        VpnBypassImpl.log("IPv4 Test: Convert CIDR to Subnet Mask IP")

        VpnBypassImpl.log("Testing: IPv4.isCidr('32') = True")
        If IPv4.isCidr("32") = True Then
            VpnBypassImpl.log("Pass")
        Else
            VpnBypassImpl.log("Fail")
        End If

        VpnBypassImpl.log("Testing: IPv4.isCidr('24') = True")
        If IPv4.isCidr("24") = True Then
            VpnBypassImpl.log("Pass")
        Else
            VpnBypassImpl.log("Fail")
        End If

        VpnBypassImpl.log("Testing: IPv4.isCidr('0') = True")
        If IPv4.isCidr("0") = True Then
            VpnBypassImpl.log("Pass")
        Else
            VpnBypassImpl.log("Fail")
        End If

        VpnBypassImpl.log("Testing: IPv4.isCidr('') = False")
        If IPv4.isCidr("") = False Then
            VpnBypassImpl.log("Pass")
        Else
            VpnBypassImpl.log("Fail")
        End If

    End Sub

    ' Test IPv4.getCidrFromIpCidr(ipCidr As String)
    Private Sub doGetCidrFromIpCidr()
        VpnBypassImpl.log("IPv4 Test: Parse CIDR from IP/CIDR format")

        VpnBypassImpl.log("Testing: IPv4.getCidrFromIpCidr('10.0.0.1/32') = '32'")
        If IPv4.getCidrFromIpCidr("10.0.0.1/32") = "32" Then
            VpnBypassImpl.log("Pass")
        Else
            VpnBypassImpl.log("Fail")
        End If

        VpnBypassImpl.log("Testing: IPv4.getCidrFromIpCidr('10.0.0.1/24') = '24'")
        If IPv4.getCidrFromIpCidr("10.0.0.1/24") = "24" Then
            VpnBypassImpl.log("Pass")
        Else
            VpnBypassImpl.log("Fail")
        End If

        VpnBypassImpl.log("Testing: IPv4.getCidrFromIpCidr('10.0.0.1/0') = '0'")
        If IPv4.getCidrFromIpCidr("10.0.0.1/0") = "0" Then
            VpnBypassImpl.log("Pass")
        Else
            VpnBypassImpl.log("Fail")
        End If

        VpnBypassImpl.log("Testing: IPv4.getCidrFromIpCidr('10.0.0.1') = '' (empty)")
        If IPv4.getCidrFromIpCidr("10.0.0.1") = "" Then
            VpnBypassImpl.log("Pass")
        Else
            VpnBypassImpl.log("Fail")
        End If

    End Sub

    ' Test IPv4.getIpAddressFromIpCidr(ipCidr As String)
    Private Sub doGetIpAddressFromIpCidr()
        VpnBypassImpl.log("IPv4 Test: Parse IP from IP/CIDR format")

        VpnBypassImpl.log("Testing: IPv4.getIpAddressFromIpCidr('10.0.0.1/32') = '10.0.0.1'")
        If IPv4.getIpAddressFromIpCidr("10.0.0.1/32") = "10.0.0.1" Then
            VpnBypassImpl.log("Pass")
        Else
            VpnBypassImpl.log("Fail")
        End If

        VpnBypassImpl.log("Testing: IPv4.getIpAddressFromIpCidr('10.0.0.1/24') = '10.0.0.1'")
        If IPv4.getIpAddressFromIpCidr("10.0.0.1/24") = "10.0.0.1" Then
            VpnBypassImpl.log("Pass")
        Else
            VpnBypassImpl.log("Fail")
        End If

        VpnBypassImpl.log("Testing: IPv4.getIpAddressFromIpCidr('10.0.0.1/0') = '10.0.0.1'")
        If IPv4.getIpAddressFromIpCidr("10.0.0.1/0") = "10.0.0.1" Then
            VpnBypassImpl.log("Pass")
        Else
            VpnBypassImpl.log("Fail")
        End If

        VpnBypassImpl.log("Testing: IPv4.getIpAddressFromIpCidr('10.0.0.1') = '10.0.0.1'")
        If IPv4.getIpAddressFromIpCidr("10.0.0.1") = "10.0.0.1" Then
            VpnBypassImpl.log("Pass")
        Else
            VpnBypassImpl.log("Fail")
        End If

    End Sub

    ' Test IPv4.isValid(node As TreeNode)
    ' Test IPv4.isValid(ip As String)
    Private Sub doIsValid()
        ' Test ip node
        VpnBypassImpl.log("IPv4 Test: Test IP Node validity")

        Dim opts1 As Hashtable = New Hashtable
        opts1.Add("cidr", "32")
        opts1.Add("subnetMask", "255.255.255.255")
        opts1.Add("permanent", "false")
        Dim ipNode1 As TreeNode = VpnBypassImpl.getNewTreeNode("10.0.0.1", opts1)

        VpnBypassImpl.log("Testing: IPv4.isValid(ipNode:{'10.0.0.1/32','255.255.255.255','false'}) = True")
        If IPv4.isValid(ipNode1) = True Then
            VpnBypassImpl.log("Pass")
        Else
            VpnBypassImpl.log("Fail")
        End If

        Dim opts2 As Hashtable = New Hashtable
        opts2.Add("cidr", "24")
        opts2.Add("subnetMask", "255.255.255.0")
        opts2.Add("permanent", "false")
        Dim ipNode2 As TreeNode = VpnBypassImpl.getNewTreeNode("192.168.1.1", opts2)

        VpnBypassImpl.log("Testing: IPv4.isValid(ipNode:{'192.168.1.1/24','255.255.255.0','false'}) = True")
        If IPv4.isValid(ipNode2) = True Then
            VpnBypassImpl.log("Pass")
        Else
            VpnBypassImpl.log("Fail")
        End If

        Dim opts3 As Hashtable = New Hashtable
        opts3.Add("cidr", "24")
        opts3.Add("subnetMask", "255.255.255.0")
        opts3.Add("permanent", "false")
        Dim ipNode3 As TreeNode = VpnBypassImpl.getNewTreeNode("192.168.1.256", opts3)

        VpnBypassImpl.log("Testing: IPv4.isValid(ipNode:{'192.168.1.256/24','255.255.255.0','false'}) = False")
        If IPv4.isValid(ipNode3) = False Then
            VpnBypassImpl.log("Pass")
        Else
            VpnBypassImpl.log("Fail")
        End If

        Dim opts4 As Hashtable = New Hashtable
        opts4.Add("cidr", "24")
        opts4.Add("subnetMask", "255.255.255.0")
        opts4.Add("permanent", "false")
        Dim ipNode4 As TreeNode = VpnBypassImpl.getNewTreeNode("not.an.ip.address", opts4)

        VpnBypassImpl.log("Testing: IPv4.isValid(ipNode:{'not.an.ip.address/24','255.255.255.0','false'}) = False")
        If IPv4.isValid(ipNode4) = False Then
            VpnBypassImpl.log("Pass")
        Else
            VpnBypassImpl.log("Fail")
        End If

        ' Test ip string
        VpnBypassImpl.log("IPv4 Test: Test IP string validity")

        VpnBypassImpl.log("Testing: IPv4.isValid('10.0.0.1'}) = True")
        If IPv4.isValid("10.0.0.1") = True Then
            VpnBypassImpl.log("Pass")
        Else
            VpnBypassImpl.log("Fail")
        End If

        VpnBypassImpl.log("Testing: IPv4.isValid('192.168.1.1'}) = True")
        If IPv4.isValid("192.168.1.1") = True Then
            VpnBypassImpl.log("Pass")
        Else
            VpnBypassImpl.log("Fail")
        End If

        VpnBypassImpl.log("Testing: IPv4.isValid('192.168.1.256'}) = False")
        If IPv4.isValid("192.168.1.256") = False Then
            VpnBypassImpl.log("Pass")
        Else
            VpnBypassImpl.log("Fail")
        End If

        VpnBypassImpl.log("Testing: IPv4.isValid('not.an.ip.address'}) = False")
        If IPv4.isValid("not.an.ip.address") = False Then
            VpnBypassImpl.log("Pass")
        Else
            VpnBypassImpl.log("Fail")
        End If

    End Sub

End Module
