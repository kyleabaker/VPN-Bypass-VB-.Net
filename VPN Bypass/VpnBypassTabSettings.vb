Module VpnBypassTabSettings
    '============================================================
    ' Common private functions
    '============================================================

    '============================================================
    ' Public action functions
    '============================================================

    ' Initialize settings form elements that don't have defaults set
    Public Sub init()
        'TODO
    End Sub

    ' IP Address changed
    Public Sub doIpAddressChanged()
        'TODO
    End Sub

    ' IP Address got focus
    Public Sub doIpAddressGotFocus()
        If VpnBypassForm.TextBox_IpAddress.Text() = "Override Host IP" Then
            VpnBypassForm.TextBox_IpAddress.ForeColor = Color.Black
            VpnBypassForm.TextBox_IpAddress.Text = ""
        End If
    End Sub

    ' IP Address lost focus
    Public Sub doIpAddressLostFocus()
        If VpnBypassForm.TextBox_IpAddress.Text() = "" Then
            VpnBypassForm.TextBox_IpAddress.ForeColor = Color.LightGray
            VpnBypassForm.TextBox_IpAddress.Text = "Override Host IP"
        End If
    End Sub

    ' Default Gateway changed
    Public Sub doDefaultGatewayChanged()
        'TODO
    End Sub

    ' Default Gateway got focus
    Public Sub doDefaultGatewayGotFocus()
        If VpnBypassForm.TextBox_DefaultGateway.Text() = "Override Gateway" Then
            VpnBypassForm.TextBox_DefaultGateway.ForeColor = Color.Black
            VpnBypassForm.TextBox_DefaultGateway.Text = ""
        End If
    End Sub

    ' Default Gateway lost focus
    Public Sub doDefaultGatewayLostFocus()
        If VpnBypassForm.TextBox_DefaultGateway.Text() = "" Then
            VpnBypassForm.TextBox_DefaultGateway.ForeColor = Color.LightGray
            VpnBypassForm.TextBox_DefaultGateway.Text = "Override Gateway"
        End If
    End Sub

    ' Subnet Mask changed
    Public Sub doSubnetMaskChanged()
        'TODO
    End Sub

    ' Subnet Mask got focus
    Public Sub doSubnetMaskGotFocus()
        If VpnBypassForm.TextBox_SubnetMask.Text() = "Override Subnet Mask" Then
            VpnBypassForm.TextBox_SubnetMask.ForeColor = Color.Black
            VpnBypassForm.TextBox_SubnetMask.Text = ""
        End If
    End Sub

    ' Subnet Mask lost focus
    Public Sub doSubnetMaskLostFocus()
        If VpnBypassForm.TextBox_SubnetMask.Text() = "" Then
            VpnBypassForm.TextBox_SubnetMask.ForeColor = Color.LightGray
            VpnBypassForm.TextBox_SubnetMask.Text = "Override Subnet Mask"
        End If
    End Sub

    ' Apply Settings
    Public Sub doApply()
        If VpnBypassForm.TextBox_IpAddress.Text() = "Override Host Ip" Then
            NetworkInfo.hostIp = VpnBypassForm.Val_IpAddress.Text()
        Else
            NetworkInfo.hostIp = VpnBypassForm.TextBox_IpAddress.Text()
        End If

        If VpnBypassForm.TextBox_DefaultGateway.Text() = "Override Gateway" Then
            NetworkInfo.gatewayIp = VpnBypassForm.Val_DefaultGateway.Text()
        Else
            NetworkInfo.gatewayIp = VpnBypassForm.TextBox_DefaultGateway.Text()
        End If

        If VpnBypassForm.TextBox_SubnetMask.Text() = "Override Subnet Mask" Then
            NetworkInfo.subnetMaskIp = VpnBypassForm.Val_SubnetMask.Text()
        Else
            NetworkInfo.subnetMaskIp = VpnBypassForm.TextBox_SubnetMask.Text()
        End If
    End Sub
End Module
