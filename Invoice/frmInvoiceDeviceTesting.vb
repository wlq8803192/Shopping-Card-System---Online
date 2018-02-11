Public Class frmInvoiceDeviceTesting

    Private Sub frmInvoiceDeviceTesting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For Each sPort As String In IO.Ports.SerialPort.GetPortNames
            Me.cbbPort.Items.Add(sPort)
        Next
        If My.Settings.InvoiceDevicePort = "" OrElse Me.cbbPort.Items.IndexOf(My.Settings.InvoiceDevicePort) = -1 Then
            Me.cbbPort.SelectedIndex = Me.cbbPort.Items.Count - 1
        Else
            Me.cbbPort.SelectedIndex = Me.cbbPort.Items.IndexOf(My.Settings.InvoiceDevicePort)
        End If
    End Sub

    Private Sub cbbPort_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbPort.SelectedIndexChanged
        If My.Settings.InvoiceDevicePort = Me.cbbPort.Text Then
            Me.btnWebTesting.Enabled = True
        Else
            Me.btnWebTesting.Enabled = False
        End If
        Me.btnSave.Enabled = False
    End Sub

    Private Sub btnMachineTesting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMachineTesting.Click
        Me.Cursor = Cursors.WaitCursor
        Dim objInvoice As Object = Nothing
        Try
            objInvoice = CreateObject("PZHPrj.ComDLL")
        Catch ex As Exception
            MessageBox.Show("联机测试失败！动态链接库""PZHPrj.dll""未注册！    " & Chr(13) & Chr(13) & "请联系当地IT进行注册（命令：regsvr32 \%PATHNAME%\PZHPrj.dll）    ", "联机测试失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            objInvoice = Nothing
            Me.Cursor = Cursors.Default
            Return
        End Try

        Dim sResult As String = objInvoice.InitReader(CInt(Me.cbbPort.Text.Substring(3)))
        If sResult = "0" Then
            MessageBox.Show("联机测试成功。    ", "联机测试成功", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.btnWebTesting.Enabled = True
            Me.btnSave.Enabled = (My.Settings.InvoiceDevicePort <> Me.cbbPort.Text)
        Else
            MessageBox.Show("联机测试失败！错误代码：" & sResult & "。    " & Chr(13) & Chr(13) & "请联系当地IT检查如下事项：    " & Chr(13) & Chr(13) & "1. 开票器是否已正确连接；    " & Chr(13) & "2. 驱动程序是否已正确安装；    " & Chr(13) & "3. 连接端口是否已正确选择。    ", "联机测试失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.btnMachineTesting.Enabled = False
            Me.btnWebTesting.Enabled = False
        End If

        sResult = objInvoice.GetCurrUserInfo()
        objInvoice = Nothing
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnWebTesting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWebTesting.Click
        Me.Cursor = Cursors.WaitCursor
        frmMain.blInvoiceDeviceOK = False

        Dim objInvoice As Object = Nothing
        Try
            objInvoice = CreateObject("PZHPrj.ComDLL")
        Catch ex As Exception
            MessageBox.Show("联网测试失败！动态链接库""PZHPrj.dll""未注册！    " & Chr(13) & Chr(13) & "请联系当地IT进行注册（命令：regsvr32 \%PATHNAME%\PZHPrj.dll）    ", "联网测试失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            objInvoice = Nothing
            Me.Cursor = Cursors.Default
            Return
        End Try

        Dim sResult As String = objInvoice.InitReader(CInt(Me.cbbPort.Text.Substring(3)))
        If sResult <> "0" Then
            MessageBox.Show("联网测试失败！错误代码：" & sResult & "。    " & Chr(13) & Chr(13) & "请联系当地IT检查如下事项：    " & Chr(13) & Chr(13) & "1. 开票器是否已正确连接；    " & Chr(13) & "2. 驱动程序是否已正确安装；    " & Chr(13) & "3. 连接端口是否已正确选择。    ", "联网测试失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.btnMachineTesting.Enabled = False
            Me.btnWebTesting.Enabled = False
            objInvoice = Nothing
            Me.Cursor = Cursors.Default
            Return
        End If

        sResult = objInvoice.SendData()
        If sResult = "0" Then
            MessageBox.Show("联网测试成功。    ", "联网测试成功", MessageBoxButtons.OK, MessageBoxIcon.Information)
            frmMain.blInvoiceDeviceOK = True
        Else
            MessageBox.Show("联网测试失败！   " & Chr(13) & Chr(13) & "请联系当地IT检查外网网络设置。    ", "联网测试失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
        objInvoice = Nothing
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        My.Settings.InvoiceDevicePort = Me.cbbPort.Text
        My.Settings.Save()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class