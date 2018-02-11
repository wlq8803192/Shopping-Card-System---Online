Public Class frmNewBatchInvoice

    Private Sub txbInvoiceCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbInvoiceCode.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then Me.txbStartInvoiceNo.Select() : Me.txbStartInvoiceNo.SelectAll() : e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If Me.txbInvoiceCode.SelectedText.Length > 0 AndAlso Me.txbInvoiceCode.SelectedText.Length = Me.txbInvoiceCode.Text.Length Then Me.txbInvoiceCode.Text = ""
            Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbStartInvoiceNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbStartInvoiceNo.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then Me.txbEndInvoiceNo.Select() : Me.txbEndInvoiceNo.SelectAll() : e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If Me.txbStartInvoiceNo.SelectedText.Length > 0 AndAlso Me.txbStartInvoiceNo.SelectedText.Length = Me.txbStartInvoiceNo.Text.Length Then Me.txbStartInvoiceNo.Text = ""
            Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbEndInvoiceNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbEndInvoiceNo.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then Me.txbInvoiceCode.Select() : Me.txbInvoiceCode.SelectAll() : e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If Me.txbEndInvoiceNo.SelectedText.Length > 0 AndAlso Me.txbEndInvoiceNo.SelectedText.Length = Me.txbEndInvoiceNo.Text.Length Then Me.txbEndInvoiceNo.Text = ""
            Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbInvoiceCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbInvoiceCode.TextChanged, txbStartInvoiceNo.TextChanged, txbEndInvoiceNo.TextChanged
        Me.lblStatus.Text = ""
        Me.btnOK.Enabled = (Me.txbInvoiceCode.Text.Trim <> "" AndAlso Me.txbStartInvoiceNo.Text.Trim <> "" AndAlso Me.txbEndInvoiceNo.Text.Trim <> "")
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim sInvoiceCode As String = Me.txbInvoiceCode.Text.Trim, sStartInvoiceNo As String = Me.txbStartInvoiceNo.Text.Trim, sEndInvoiceNo As String = Me.txbEndInvoiceNo.Text.Trim
        Me.txbInvoiceCode.Text = sInvoiceCode : Me.txbStartInvoiceNo.Text = sStartInvoiceNo : Me.txbEndInvoiceNo.Text = sEndInvoiceNo
        If Not IsNumeric(sInvoiceCode) OrElse sInvoiceCode.Length <> 12 Then
            MessageBox.Show("发票代码必须是由 12 位数字组成！    ", "发票代码非法！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.txbInvoiceCode.Select() : Me.txbInvoiceCode.SelectAll()
            Me.btnOK.Enabled = False : Return
        End If

        If Not IsNumeric(sStartInvoiceNo) OrElse sStartInvoiceNo.Length <> 8 Then
            MessageBox.Show("开始发票号码必须是由 8 位数字组成！    ", "开始发票号码非法！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.txbStartInvoiceNo.Select() : Me.txbStartInvoiceNo.SelectAll()
            Me.btnOK.Enabled = False : Return
        End If

        If Not IsNumeric(sEndInvoiceNo) OrElse sEndInvoiceNo.Length <> 8 Then
            MessageBox.Show("结束发票号码必须是由 8 位数字组成！    ", "结束发票号码非法！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.txbEndInvoiceNo.Select() : Me.txbEndInvoiceNo.SelectAll()
            Me.btnOK.Enabled = False : Return
        End If

        If sStartInvoiceNo > sEndInvoiceNo Then
            Me.txbStartInvoiceNo.Text = sEndInvoiceNo
            Me.txbEndInvoiceNo.Text = sStartInvoiceNo
            sStartInvoiceNo = Me.txbStartInvoiceNo.Text
            sEndInvoiceNo = Me.txbEndInvoiceNo.Text
        End If

        Me.Cursor = Cursors.WaitCursor
        Me.lblStatus.ForeColor = Color.Blue
        Me.lblStatus.Text = "正在从税务局服务器下载发票信息……"
        Me.Refresh()

        Dim objInvoice As Object = Nothing, sResult As String = ""
        Try
            objInvoice = CreateObject("PZHPrj.ComDLL")
            sResult = objInvoice.GetNetInv(sInvoiceCode, sStartInvoiceNo, sEndInvoiceNo)
            'If sResult = "0" Then
            sResult = objInvoice.SelectInvoice(sInvoiceCode, sStartInvoiceNo)
            If sResult = "0" Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                Me.lblStatus.ForeColor = Color.Red
                Me.lblStatus.Text = "无法选择使用该批发票！"
                MessageBox.Show("下载发票信息成功，但在选择使用该批发票时出现错误！错误代码：" & sResult & "。    ", "无法选择使用该批发票！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            'Else
            'Me.lblStatus.ForeColor = Color.Red
            'Me.lblStatus.Text = "无法从税务局服务器下载发票信息！"
            'MessageBox.Show("从税务局服务器下载发票信息时出现错误！错误代码：" & sResult & "。    " & Chr(13) & Chr(13) & "请检查输入的发票代码/号码是否有误，或者开票器是否已正确连接。    ", "无法从税务局服务器下载发票信息！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            'Me.txbInvoiceCode.Select() : Me.txbInvoiceCode.SelectAll()
            'End If
        Catch ex As Exception
            Me.lblStatus.ForeColor = Color.Red
            Me.lblStatus.Text = "无法从税务局服务器下载发票信息！"
            MessageBox.Show("从税务局服务器下载发票信息时出现错误，下面是具体的错误提示：    " & Chr(13) & Chr(13) & ex.Message & Space(4), "无法从税务局服务器下载发票信息！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
        objInvoice = Nothing
        Me.Cursor = Cursors.Default
    End Sub
End Class