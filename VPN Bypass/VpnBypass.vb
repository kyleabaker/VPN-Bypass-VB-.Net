Imports System.IO
Imports System.Net
Imports System.Net.NetworkInformation

Public Class VpnBypass
    Dim IpRoutingList As ArrayList = New ArrayList()

    Private Sub BtnAddDomain_Click(sender As Object, e As EventArgs) Handles BtnAddDomain.Click
        Dim domain = TextBoxDomain.Text.ToLower
        AddDomain(domain)
        SaveDomainList()
    End Sub

    Private Sub BtnRemoveDomain_Click(sender As Object, e As EventArgs) Handles BtnRemoveDomain.Click
        Dim selectedNode As TreeNode = TreeViewDomains.SelectedNode
        Console.WriteLine("Selected node: " + selectedNode.Text())
        If selectedNode.Parent Is Nothing Then
            Console.WriteLine("Removing selected domain from list: " + selectedNode.Text())
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Determine current IP address
        GetIpAddress()

        ' Determine current Default Gateway
        GetDefaultGateway()

        ' Determine Subnet Mask
        GetSubnetMask()

        ' Open domain list
        OpenDomainList()
    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        NSLookUp.NSLookUpAll()
        VpnBypassImpl.ApplyRoutes()
    End Sub

    Private Sub BtnDeleteRoutes_Click(sender As Object, e As EventArgs) Handles BtnDeleteRoutes.Click
        'DeleteRoutes()
    End Sub
End Class
