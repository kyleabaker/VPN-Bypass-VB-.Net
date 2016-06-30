Imports System.Text.RegularExpressions

Module IPv4
    ' Return CIDR by converting Subnet Mask
    Public Function getCidrFromSubnetMask(subnetMask As String) As String
        Dim cidr As String = ""

        Select Case subnetMask
            '    Subnet Mask       CIDR Prefix    Total IP's     Usable IP's    Number of Class C networks
            Case "255.255.255.255" '/32           1              1              1/256th
                cidr = "32"
            Case "255.255.255.254" '/31           2              0              1/128th
                cidr = "31"
            Case "255.255.255.252" '/30           4              2              1/64th
                cidr = "30"
            Case "255.255.255.248" '/29           8              6              1/32nd
                cidr = "29"
            Case "255.255.255.240" '/28           16             14             1/16th
                cidr = "28"
            Case "255.255.255.224" '/27           32             30             1/8th
                cidr = "27"
            Case "255.255.255.192" '/26           64             62             1/4th
                cidr = "26"
            Case "255.255.255.128" '/25           128            126            1 half
                cidr = "25"
            Case "255.255.255.0"   '/24           256            254            1
                cidr = "24"
            Case "255.255.254.0"   '/23           512            510            2
                cidr = "23"
            Case "255.255.252.0"   '/22           1024           1022           4
                cidr = "22"
            Case "255.255.248.0"   '/21           2048           2046           8
                cidr = "21"
            Case "255.255.240.0"   '/20           4096           4094           16
                cidr = "20"
            Case "255.255.224.0"   '/19           8192           8190           32
                cidr = "19"
            Case "255.255.192.0"   '/18           16,384         16,382         64
                cidr = "18"
            Case "255.255.128.0"   '/17           32,768         32,766         128
                cidr = "17"
            Case "255.255.0.0"     '/16           65,536         65,534         256
                cidr = "16"
            Case "255.254.0.0"     '/15           131,072        131,070        512
                cidr = "15"
            Case "255.252.0.0"     '/14           262,144        262,142        1024
                cidr = "14"
            Case "255.248.0.0"     '/13           524,288        524,286        2048
                cidr = "13"
            Case "255.240.0.0"     '/12           1,048,576      1,048,574      4096
                cidr = "12"
            Case "255.224.0.0"     '/11           2,097,152      2,097,150      8192
                cidr = "11"
            Case "255.192.0.0"     '/10           4,194,304      4,194,302      16,384
                cidr = "10"
            Case "255.128.0.0"     '/9            8,388,608      8,388,606      32,768
                cidr = "9"
            Case "255.0.0.0"       '/8            16,777,216     16,777,214     65,536
                cidr = "8"
            Case "254.0.0.0"       '/7            33,554,432     33,554,430     131,072
                cidr = "7"
            Case "252.0.0.0"       '/6            67,108,864     67,108,862     262,144
                cidr = "6"
            Case "248.0.0.0"       '/5            134,217,728    134,217,726    1,048,576
                cidr = "5"
            Case "240.0.0.0"       '/4            268,435,456    268,435,454    2,097,152
                cidr = "4"
            Case "224.0.0.0"       '/3            536,870,912    536,870,910    4,194,304
                cidr = "3"
            Case "192.0.0.0"       '/2            1,073,741,824  1,073,741,822  8,388,608
                cidr = "2"
            Case "128.0.0.0"       '/1            2,147,483,648  2,147,483,646  16,777,216
                cidr = "1"
            Case "0.0.0.0"         '/0            4,294,967,296  4,294,967,294  33,554,432
                cidr = "0"
        End Select

        Return cidr
    End Function

    ' Return Subnet Mask by converting CIDR
    Public Function getSubnetMaskFromCidr(cidr As String) As String
        Dim subnetMask As String = ""

        Select Case cidr
            '    CIDR Prefix    Subnet Mask       Total IP's     Usable IP's    Number of Class C networks
            Case "32"           '255.255.255.255  1              1              1/256th
                subnetMask = "255.255.255.255"
            Case "31"           '255.255.255.254  2              0              1/128th
                subnetMask = "255.255.255.254"
            Case "30"           '255.255.255.252  4              2              1/64th
                subnetMask = "255.255.255.252"
            Case "29"           '255.255.255.248  8              6              1/32nd
                subnetMask = "255.255.255.248"
            Case "28"           '255.255.255.240  16             14             1/16th
                subnetMask = "255.255.255.240"
            Case "27"           '255.255.255.224  32             30             1/8th
                subnetMask = "255.255.255.224"
            Case "26"           '255.255.255.192  64             62             1/4th
                subnetMask = "255.255.255.192"
            Case "25"           '255.255.255.128  128            126            1 half
                subnetMask = "255.255.255.128"
            Case "24"           '255.255.255.0    256            254            1
                subnetMask = "255.255.255.0"
            Case "23"           '255.255.254.0    512            510            2
                subnetMask = "255.255.254.0"
            Case "22"           '255.255.252.0    1024           1022           4
                subnetMask = "255.255.252.0"
            Case "21"           '255.255.248.0    2048           2046           8
                subnetMask = "255.255.248.0"
            Case "20"           '255.255.240.0    4096           4094           16
                subnetMask = "255.255.240.0"
            Case "19"           '255.255.224.0    8192           8190           32
                subnetMask = "255.255.224.0"
            Case "18"           '255.255.192.0    16,384         16,382         64
                subnetMask = "255.255.192.0"
            Case "17"           '255.255.128.0    32,768         32,766         128
                subnetMask = "255.255.128.0"
            Case "16"           '255.255.0.0      65,536         65,534         256
                subnetMask = "255.255.0.0"
            Case "15"           '255.254.0.0      131,072        131,070        512
                subnetMask = "255.254.0.0"
            Case "14"           '255.252.0.0      262,144        262,142        1024
                subnetMask = "255.252.0.0"
            Case "13"           '255.248.0.0      524,288        524,286        2048
                subnetMask = "255.248.0.0"
            Case "12"           '255.240.0.0      1,048,576      1,048,574      4096
                subnetMask = "255.240.0.0"
            Case "11"           '255.224.0.0      2,097,152      2,097,150      8192
                subnetMask = "255.224.0.0"
            Case "10"           '255.192.0.0      4,194,304      4,194,302      16,384
                subnetMask = "255.192.0.0"
            Case "9"            '255.128.0.0      8,388,608      8,388,606      32,768
                subnetMask = "255.128.0.0"
            Case "8"            '255.0.0.0        16,777,216     16,777,214     65,536
                subnetMask = "255.0.0.0"
            Case "7"            '254.0.0.0        33,554,432     33,554,430     131,072
                subnetMask = "254.0.0.0"
            Case "6"            '252.0.0.0        67,108,864     67,108,862     262,144
                subnetMask = "252.0.0.0"
            Case "5"            '248.0.0.0        134,217,728    134,217,726    1,048,576
                subnetMask = "248.0.0.0"
            Case "4"            '240.0.0.0        268,435,456    268,435,454    2,097,152
                subnetMask = "240.0.0.0"
            Case "3"            '224.0.0.0        536,870,912    536,870,910    4,194,304
                subnetMask = "224.0.0.0"
            Case "2"            '192.0.0.0        1,073,741,824  1,073,741,822  8,388,608
                subnetMask = "192.0.0.0"
            Case "1"            '128.0.0.0        2,147,483,648  2,147,483,646  16,777,216
                subnetMask = "128.0.0.0"
            Case "0"            '0.0.0.0          4,294,967,296  4,294,967,294  33,554,432
                subnetMask = "0.0.0.0"
        End Select

        Return subnetMask
    End Function

    ' Return whether or not the specified cidr is valid by attempting to convert to subnet mask.
    Public Function isCidr(cidr As String) As Boolean
        Return getSubnetMaskFromCidr(cidr).Length > 0
    End Function

    ' Returns CIDR from IP/CIDR format
    Public Function getCidrFromIpCidr(ipCidr As String) As String
        Dim cidr As String = ""

        ' First check to see if we even have an ip/cidr notation
        If ipCidr.IndexOf("/") > -1 Then
            ' Contains CIDR
            Dim re As Regex = New Regex("^(?:(?:(?:[0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}(?:[0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5]))\/([0-9]{1,2})$")
            If re.IsMatch(ipCidr) = True Then
                Dim groups As GroupCollection = re.Match(ipCidr).Groups
                cidr = groups.Item(1).ToString
            End If
        End If

        Return cidr
    End Function

    ' Returns IP address from IP/CIDR format
    Public Function getIpAddressFromIpCidr(ipCidr As String) As String
        Dim ip As String = ""

        ' First check to see if the ip/cidr is just an ip with no cidr
        If isValid(ipCidr) = True Then
            ' IPv4
            ip = ipCidr
        ElseIf ipCidr.IndexOf("/") > -1 Then
            ' Contains CIDR
            Dim re As Regex = New Regex("^((?:(?:[0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}(?:[0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5]))\/(?:[0-9]{1,2})$")
            If re.IsMatch(ipCidr) = True Then
                Dim groups As GroupCollection = re.Match(ipCidr).Groups
                ip = groups.Item(1).ToString
            End If
        End If

        Return ip
    End Function

    ' Check if IP Address is valid IPv4. Pulls ip from node and forwards to next overload.
    Public Function isValid(node As TreeNode) As Boolean
        ' Check if node has any children (ip nodes do not have any children)
        If node.Nodes.Count = 0 Then
            Dim ip As String = node.Name
            Return isValid(ip)
        End If
        Return False
    End Function

    ' Check if IP Address is valid IPv4.
    Public Function isValid(ip As String) As Boolean
        Dim re As Regex = New Regex("^(?:(?:[0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}(?:[0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$")
        Return re.IsMatch(ip)
    End Function
End Module
