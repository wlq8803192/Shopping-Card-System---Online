
'modify code 008:
'date;2013/11/5
'auther:Hyron bjy 
'remark:新增积分兑换支付方式，用于一般销售单，不可开发票，不可混合支付

Public Class frmModifyPaymentInfo

    Public dmPayableAMT As Decimal = 0
    Private sPaymentTermName As String = "", sMediaNo As String = "", sPayerName As String = ""

    Private Sub frmModifyPaymentInfo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        sPaymentTermName = Me.cbbPaymentTerm.Text
        sMediaNo = Me.txbMediaNo.Text
        sPayerName = Me.txbPayerName.Text
        If sPayerName = "" Then sPayerName = frmSelling.txbCustomerName.Text
        Me.btnOK.Enabled = False
    End Sub

    Private Sub cbbPaymentTerm_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbPaymentTerm.SelectedIndexChanged
        Select Case Me.cbbPaymentTerm.Text
            Case "现金"
                Me.lblMediaNo.Text = "卡/账/支票号："
                Me.lblPayerName.Text = "付款单位："
            Case "银行卡"
                Me.lblMediaNo.Text = "银行卡卡号："
                Me.lblPayerName.Text = "持卡人姓名："
            Case "转账", "转账_后付"
                Me.lblMediaNo.Text = "转账账号："
                Me.lblPayerName.Text = "付款单位："
                'modify code 008:start-------------------------------------------------------------------------
            Case "积分兑换"
                Me.lblMediaNo.Text = "兑换号："
                Me.lblPayerName.Text = "付款单位："
                'modify code 008:end-------------------------------------------------------------------------
            Case Else
                Me.lblMediaNo.Text = "支票号："
                Me.lblPayerName.Text = "付款单位："
        End Select

        'modify code 008:start-------------------------------------------------------------------------
        If Me.cbbPaymentTerm.Text = "积分兑换" Then
            '    Me.txbPayerName.Enabled = False
            'Else
            Me.txbPayerName.Enabled = True
        End If
        'modify code 008:end-------------------------------------------------------------------------

        If Me.cbbPaymentTerm.Text = "现金" Then
            Me.pnlExtra.Enabled = False
        Else
            Me.pnlExtra.Enabled = True
            Me.txbMediaNo.Select() : Me.txbMediaNo.SelectAll()
            If Me.cbbPaymentTerm.Text = sPaymentTermName Then
                Me.txbMediaNo.Text = sMediaNo
                Me.txbPayerName.Text = sPayerName
                'modify code 008:start-------------------------------------------------------------------------
                Me.txbPayerName.ReadOnly = False
            ElseIf Me.cbbPaymentTerm.Text = "积分兑换" Then
                Me.txbMediaNo.Text = ""
                'Me.txbPayerName.Text = "中移电子商务有限公司"
                Me.txbPayerName.Text = ""
                'modify code 008:end-------------------------------------------------------------------------
            ElseIf sPaymentTermName = "银行卡" OrElse Me.txbPayerName.Text = "" OrElse Me.txbPayerName.Text = frmSelling.txbBuyerName.Text Then
                Me.txbPayerName.Text = frmSelling.txbCustomerName.Text
                If Me.txbMediaNo.Text = sMediaNo Then Me.txbMediaNo.Text = ""
            ElseIf Me.cbbPaymentTerm.Text = "银行卡" Then
                Me.txbPayerName.Text = frmSelling.txbBuyerName.Text
                If Me.txbMediaNo.Text = sMediaNo Then Me.txbMediaNo.Text = ""
            End If
        End If
    End Sub

    Private Sub txbMediaNo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbMediaNo.DoubleClick
        Me.txbMediaNo.SelectAll()
    End Sub

    Private Sub txbMediaNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbMediaNo.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then Me.txbPayerName.Select() : Me.txbPayerName.SelectAll() : e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbMediaNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbMediaNo.Leave
        If Me.txbMediaNo.Text <> Me.txbMediaNo.Text.Trim Then Me.txbMediaNo.Text = Me.txbMediaNo.Text.Trim
    End Sub

    Private Sub txbPayerName_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbPayerName.DoubleClick
        Me.txbPayerName.SelectAll()
    End Sub

    Private Sub txbPayerName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbPayerName.KeyDown
        If e.KeyCode = Keys.Enter Then Me.txbMediaNo.Select() : Me.txbMediaNo.SelectAll() : e.SuppressKeyPress = True : Return
    End Sub

    Private Sub txbPayerName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbPayerName.Leave
        If Me.txbPayerName.Text <> Me.txbPayerName.Text.Trim Then Me.txbPayerName.Text = Me.txbPayerName.Text.Trim
        If Me.txbPayerName.Text = "" Then Me.txbPayerName.Text = sPayerName
    End Sub

    Private Sub cbbPaymentTerm_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbPaymentTerm.TextChanged, txbMediaNo.TextChanged, txbPayerName.TextChanged, txbPaymentAMT.TextChanged
        If sPaymentTermName = Me.cbbPaymentTerm.Text Then
            If Me.cbbPaymentTerm.Text = "现金" Then
                Me.btnOK.Enabled = False
            Else
                Me.btnOK.Enabled = (sMediaNo <> Me.txbMediaNo.Text.Trim OrElse sPayerName <> Me.txbPayerName.Text.Trim)
            End If
        Else
            Me.btnOK.Enabled = True
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim dmTotalCardCost As Decimal = frmSelling.drSalesBill("CardCost"), dmCash As Decimal = 0
        For Each drPayment As DataGridViewRow In frmSelling.dgvPayment.Rows
            If Not drPayment.Selected AndAlso drPayment.Cells("PaymentTerm").Value < IIf(frmSelling.blHaveThreeMedia, 1, 2) Then
                dmCash = dmCash + drPayment.Cells("PaymentAMT").Value
            End If
        Next
        If (frmSelling.blHaveThreeMedia AndAlso Me.cbbPaymentTerm.Text = "现金") OrElse (Not frmSelling.blHaveThreeMedia AndAlso (Me.cbbPaymentTerm.Text = "现金" OrElse Me.cbbPaymentTerm.Text = "银行卡")) Then
            dmCash = dmCash + CDec(Me.txbPaymentAMT.Text)
        End If

        If frmSelling.blHaveThreeMedia Then
            If (Me.cbbPaymentTerm.Text = "现金") AndAlso ((frmSelling.drSalesBill("CustomerType") = 0 AndAlso dmTotalCardCost < dmCash AndAlso dmPayableAMT - dmTotalCardCost >= 50000) OrElse (frmSelling.drSalesBill("CustomerType") = 1 AndAlso dmTotalCardCost < dmCash AndAlso dmPayableAMT - dmTotalCardCost >= 5000)) Then
                If frmSelling.drSalesBill("CustomerType") = 0 Then
                    MessageBox.Show("应国家政策规定，个人客户一次性购卡超过（含） 50,000 元时，不能使用现金支付。    " & IIf(dmTotalCardCost = 0, "", Chr(13) & Chr(13) & "（现金只可用来支付卡成本。）    ") & Chr(13) & Chr(13) & "请使用银行卡、转账或支票方式。    ", "支付方式不合法！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    MessageBox.Show("应国家政策规定，公司客户一次性购卡超过（含） 5,000 元时，不能使用现金支付。    " & IIf(dmTotalCardCost = 0, "", Chr(13) & Chr(13) & "（现金只可用来支付卡成本。）    ") & Chr(13) & Chr(13) & "请使用银行卡、转账或支票方式。    ", "支付方式不合法！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
                Me.cbbPaymentTerm.Select()
                Return
            End If
        Else
            If (Me.cbbPaymentTerm.Text = "现金" OrElse Me.cbbPaymentTerm.Text = "银行卡") AndAlso ((frmSelling.drSalesBill("CustomerType") = 0 AndAlso dmTotalCardCost < dmCash AndAlso dmPayableAMT - dmTotalCardCost >= 50000) OrElse (frmSelling.drSalesBill("CustomerType") = 1 AndAlso dmTotalCardCost < dmCash AndAlso dmPayableAMT - dmTotalCardCost >= 5000)) Then
                If frmSelling.drSalesBill("CustomerType") = 0 Then
                    MessageBox.Show("应国家政策规定，个人客户一次性购卡超过（含） 50,000 元时，不能使用现金或银行卡支付。    " & IIf(dmTotalCardCost = 0, "", Chr(13) & Chr(13) & "（现金或银行卡只可用来支付卡成本。）    ") & Chr(13) & Chr(13) & "请使用转账或支票方式。    ", "支付方式不合法！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    MessageBox.Show("应国家政策规定，公司客户一次性购卡超过（含） 5,000 元时，不能使用现金或银行卡支付。    " & IIf(dmTotalCardCost = 0, "", Chr(13) & Chr(13) & "（现金或银行卡只可用来支付卡成本。）    ") & Chr(13) & Chr(13) & "请使用转账或支票方式。    ", "支付方式不合法！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
                Me.cbbPaymentTerm.Select()
                Return
            End If
        End If

        If Me.cbbPaymentTerm.Text = "银行卡" Then
            If Me.txbMediaNo.Text = "" Then
                MessageBox.Show("当付款方式是""银行卡""时，银行卡卡号不能为空！请输入银行卡卡号。    ", "银行卡卡号不能为空！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txbMediaNo.Select() : Return
            ElseIf Not IsNumeric(Me.txbMediaNo.Text) Then
                MessageBox.Show("银行卡卡号必须由数字组成！请重新输入银行卡卡号。    ", "银行卡卡号必须由数字组成！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txbMediaNo.Select() : Me.txbMediaNo.SelectAll() : Return
            ElseIf Me.txbMediaNo.Text.Length < 10 Then
                MessageBox.Show("银行卡卡号位数不应低于 10 位！请重新输入银行卡卡号。    ", "银行卡卡号位数不应低于 10 位！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txbMediaNo.Select() : Me.txbMediaNo.SelectAll() : Return
            ElseIf Me.txbMediaNo.Text <> BankCardNo.GetFullCardNo(Me.txbMediaNo.Text.Substring(0, Me.txbMediaNo.Text.Length - 1)) AndAlso MessageBox.Show("这可能是一张无效的银行卡！    " & Chr(13) & Chr(13) & "您是否确认该卡的卡号正确无误？    ", "该银行卡卡号可能无效！", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Me.txbMediaNo.Select() : Me.txbMediaNo.SelectAll() : Return
            ElseIf Me.txbPayerName.Text = "" Then
                MessageBox.Show("当付款方式是""银行卡""时，付款单位不能为空！请输入付款单位。    ", "付款单位不能为空！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txbPayerName.Select() : Return
            End If
        ElseIf Me.cbbPaymentTerm.Text.IndexOf("转账") = 0 Then
            If Me.txbMediaNo.Text = "" Then
                MessageBox.Show("当付款方式是""转账""时，转账账号不能为空！请输入转账账号。    ", "转账账号不能为空！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txbMediaNo.Select() : Return
            ElseIf Me.txbPayerName.Text = "" Then
                MessageBox.Show("当付款方式是""转账""时，付款单位不能为空！请输入付款单位。    ", "付款单位不能为空！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txbPayerName.Select() : Return
            End If
        ElseIf Me.cbbPaymentTerm.Text.IndexOf("支票") = 0 Then
            If Me.txbMediaNo.Text = "" Then
                MessageBox.Show("当付款方式是""支票""时，支票号不能为空！请输入支票号。    ", "支票号不能为空！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txbMediaNo.Select() : Return
            ElseIf Me.txbPayerName.Text = "" Then
                MessageBox.Show("当付款方式是""支票""时，付款单位不能为空！请输入付款单位。    ", "付款单位不能为空！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txbPayerName.Select() : Return
            End If
            'modify code 008:start-------------------------------------------------------------------------
        ElseIf Me.cbbPaymentTerm.Text = "积分兑换" Then
            If Me.txbMediaNo.Text.Trim = "" Then
                MessageBox.Show("当付款方式是""积分兑换""时，顾客手机号/兑换号不能为空！请输入顾客手机号/兑换号。    ", "顾客手机号/兑换号不能为空！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txbMediaNo.Select() : Return
            Else
                'If Not IsNumeric(Me.txbMediaNo.Text.Trim) Then
                '    MessageBox.Show("当付款方式是""积分兑换""时，顾客手机号/兑换号为数字！请重新输入。    ", "顾客手机号/兑换号输入错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '    Me.txbMediaNo.Select() : Return
                'End If
            End If
            If Me.txbPayerName.Text = "" Then
                MessageBox.Show("当付款方式是""积分兑换""时，付款单位不能为空！请输入付款单位。    ", "付款单位不能为空！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txbPayerName.Select() : Return
            End If
            'modify code 008:end-------------------------------------------------------------------------
        End If

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在保存对付款信息的修改……"
        frmMain.statusMain.Refresh()

        Dim DB As New DataBase()
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法保存对付款信息的修改。请检查数据库连接。"
            Me.Cursor = Cursors.Default : Return
        End If

        Dim sSQL As String = "Exec ModifyPaymentInfo @SalesBillID=" & frmSelling.sSalesBillID & ",@RowID=" & frmSelling.dgvPayment("RowID", frmSelling.dgvPayment.CurrentRow.Index).Value.ToString & ","
        Select Case Me.cbbPaymentTerm.Text
            Case "银行卡"
                sSQL = sSQL & "@PaymentTerm=1,@MediaNo='" & Me.txbMediaNo.Text.Substring(0, 6) & StrDup(Me.txbMediaNo.Text.Length - 10, "*") & Me.txbMediaNo.Text.Substring(Me.txbMediaNo.Text.Length - 4, 4) & "',@PayerName='" & Me.txbPayerName.Text.Replace("'", "''") & "',"
            Case "转账"
                sSQL = sSQL & "@PaymentTerm=2,@MediaNo='" & Me.txbMediaNo.Text & "',@PayerName='" & Me.txbPayerName.Text.Replace("'", "''") & "',"
            Case "支票"
                sSQL = sSQL & "@PaymentTerm=3,@MediaNo='" & Me.txbMediaNo.Text & "',@PayerName='" & Me.txbPayerName.Text.Replace("'", "''") & "',"
            Case "支票＋保证金"
                sSQL = sSQL & "@PaymentTerm=4,@MediaNo='" & Me.txbMediaNo.Text & "',@PayerName='" & Me.txbPayerName.Text.Replace("'", "''") & "',"
            Case "转账_后付"
                sSQL = sSQL & "@PaymentTerm=5,@MediaNo='" & Me.txbMediaNo.Text & "',@PayerName='" & Me.txbPayerName.Text.Replace("'", "''") & "',"
            Case "支票_后付"
                sSQL = sSQL & "@PaymentTerm=6,@MediaNo='" & Me.txbMediaNo.Text & "',@PayerName='" & Me.txbPayerName.Text.Replace("'", "''") & "',"
                'modify code 008:start------------------------------------------------------------------------- 
            Case "积分兑换"
                sSQL = sSQL & "@PaymentTerm=7,@MediaNo='" & Me.txbMediaNo.Text & "',@PayerName='" & Me.txbPayerName.Text.Replace("'", "''") & "',"
                'modify code 008:end-------------------------------------------------------------------------
        End Select
        sSQL = sSQL & "@OperatorName='" & frmMain.sLoginUserRealName.Replace("'", "''") & "',@SSID=" & frmMain.sSSID

        Dim dtResult As DataTable = DB.GetDataTable(sSQL)
        DB.Close()

        If dtResult Is Nothing Then
            frmMain.statusText.Text = "保存对付款信息的修改失败！"
        ElseIf dtResult.Rows(0)("Result").ToString = "Error" Then
            MessageBox.Show("保存对付款信息的修改时出现错误！下面是数据库的内部错误提示：    " & Chr(13) & Chr(13) & dtResult.Rows(0)("ErrorInfo").ToString & Space(4) & Chr(13) & Chr(13) & "请放弃保存，在关闭窗口后重试。如果仍有问题，请联系软件开发人员。    ", "保存销售单失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "保存对付款信息的修改失败！"
        ElseIf dtResult.Rows(0)("Result").ToString <> "OK" Then
            frmSelling.dgvPayment.Select()
            Select Case dtResult.Rows(0)("Result").ToString
                Case "SalesBillDeleted"
                    MessageBox.Show("当前销售单已被取消！修改无效。    ", "修改付款信息无效！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    frmSelling.ResetInterfaceWhenSalesBillDeleted(dtResult.Rows(0))
                    frmMain.statusText.Text = "当前销售单已被取消！"
                Case "SalesBillCancelled"
                    MessageBox.Show("当前销售单已被申请取消！修改无效。    ", "修改付款信息无效！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    frmSelling.ResetInterfaceWhenSalesBillCancelled(dtResult.Rows(0))
                    frmMain.statusText.Text = "当前销售单已被申请取消！"
                Case "AlreadyValidated"
                    MessageBox.Show("当前付款单已被财务部门确认到账！再不可以修改它的付款信息。    ", "修改付款信息失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    With frmSelling
                        With .dgvPayment.CurrentRow
                            .Cells("PaymentTerm").Value = dtResult.Rows(0)("PaymentTerm")
                            .Cells("MediaNo").Value = dtResult.Rows(0)("MediaNo")
                            .Cells("PayerName").Value = dtResult.Rows(0)("PayerName")
                            .Cells("ValidationState").Value = "已经确认"
                            .Cells("AuditorName").Value = dtResult.Rows(0)("AuditorName")
                            .Cells("ValidatedTime").Value = dtResult.Rows(0)("ValidatedTime")
                        End With
                        With .dgvPayment.Columns("AuditorName")
                            .Visible = True
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        End With
                        With .dgvPayment.Columns("ValidatedTime")
                            .Visible = True
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        End With
                        .btnModifyPaymentInfo.Visible = False
                    End With

                    frmMain.statusText.Text = "当前付款单已被财务部门确认到账！"
            End Select

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Else
            If Me.cbbPaymentTerm.Text = "银行卡" Then Me.txbMediaNo.Text = Me.txbMediaNo.Text.Substring(0, 6) & StrDup(Me.txbMediaNo.Text.Length - 10, "*") & Me.txbMediaNo.Text.Substring(Me.txbMediaNo.Text.Length - 4, 4)
            frmMain.statusText.Text = "保存对付款信息的修改成功。"
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If

        If dtResult IsNot Nothing Then dtResult.Dispose() : dtResult = Nothing
        Me.Cursor = Cursors.Default
    End Sub
End Class