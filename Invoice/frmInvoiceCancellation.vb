Public Class frmInvoiceCancellation

    Private Sub frmInvoiceCancellation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txbInvoiceNo.Select()
        Me.txbInvoiceNo.SelectAll()
    End Sub

    Private Sub txbInvoiceNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbInvoiceNo.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If Me.txbInvoiceNo.SelectedText.Length > 0 AndAlso Me.txbInvoiceNo.SelectedText.Length = Me.txbInvoiceNo.Text.Length Then Me.txbInvoiceNo.Text = ""
            Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbInvoiceNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbInvoiceNo.TextChanged
        Me.btnOK.Enabled = (Me.txbInvoiceNo.Text.Trim <> "")
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim sInvoiceNo As String = Me.txbInvoiceNo.Text.Trim
        Me.txbInvoiceNo.Text = sInvoiceNo
        If Not IsNumeric(sInvoiceNo) OrElse sInvoiceNo.Length <> 8 Then
            MessageBox.Show("发票号码必须是由 8 位数字组成！    ", "发票号码非法！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.txbInvoiceNo.Select() : Me.txbInvoiceNo.SelectAll()
            Me.btnOK.Enabled = False : Return
        End If

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在作废发票……"
        frmMain.statusMain.Refresh()

        Dim objInvoice As Object = Nothing, sResult As String = ""
        Try
            objInvoice = CreateObject("PZHPrj.ComDLL")
            sResult = objInvoice.InvalidRegistry(sInvoiceNo, frmMain.sLoginUserRealName)
            If sResult = "0" Then
                sResult = objInvoice.SendData()
                If sResult = "0" Then
                    frmMain.statusText.Text = "就绪。"
                Else
                    MessageBox.Show("发票已作废，但未能将数据及时传送到税务局服务器！下面是具体的错误提示：    " & Chr(13) & Chr(13) & sResult.Substring(sResult.IndexOf(",") + 1) & "    " & Chr(13) & Chr(13) & "如多次发生类似故障，请联系当地IT检查外网网络设置。    ", "未将发票作废数据及时传送到税务局服务器！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    frmMain.statusText.Text = "未将发票作废数据及时传送到税务局服务器！"
                End If
            Else
                MessageBox.Show("作废发票时出现错误！错误代码：" & sResult & "。    ", "无法作废当前的发票号码！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                frmMain.statusText.Text = "作废发票失败！"
            End If
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MessageBox.Show("作废发票时出现错误，下面是具体的错误提示：    " & Chr(13) & Chr(13) & ex.Message & Space(4), "作废发票失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "作废发票失败！"
        End Try
        objInvoice = Nothing
        Me.Cursor = Cursors.Default
    End Sub
End Class