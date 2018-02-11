Public Class frmGiftCardCancellationRequirement

    'modify code 012:
    'date;2014/2/13
    'auther:Hyron bjy 
    'remark:礼品卡激活撤销界面增加卡所属城市卡费显示

    'modify code 033:
    'date;2014/7/24
    'auther:Hyron bjy 
    'remark:更改特殊操作用户登录验证方式为guid

    Private dvCULParameter As DataView, sCardNo As String = "", sPrice As String, sCost As String, sFaceValue As String, sPrintedTime As String, blChecked As Boolean = False, dmFaceValue As Decimal, dmPrice As Decimal

    'modify code 012:start-------------------------------------------------------------------------
    Private dtCardCostManage As DataTable
    'modify code 012:end-------------------------------------------------------------------------

    'modify code 033:start-------------------------------------------------------------------------
    Dim guIDClass As C4ShoppingCardService.GuIDClass
    'modify code 033:end-------------------------------------------------------------------------

    Private Sub frmGiftCardCancellationRequirement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dvCULParameter = frmMain.dtLoginStructure.Copy.DefaultView
        dvCULParameter.RowFilter = "AreaType='S'"
        dvCULParameter = dvCULParameter.ToTable(False, "AreaID", "CULCardBin", "CULStoreCode").DefaultView
        dvCULParameter.RowFilter = "CULCardBin Like '%|%'"
        For Each drCUL As DataRowView In dvCULParameter
            Dim saCardBins() As String = drCUL("CULCardBin").ToString.Split("|")
            For bIndex As Byte = 0 To saCardBins.Length - 1
                dvCULParameter.Table.Rows.Add(drCUL("AreaID"), saCardBins(bIndex), drCUL("CULStoreCode")).EndEdit()
            Next
        Next
        For Each drCUL As DataRow In dvCULParameter.Table.Select("CULCardBin Like '84%'")
            drCUL("CULCardBin") = "60" & drCUL("CULCardBin").ToString.Substring(2, 3)
            drCUL.EndEdit()
        Next
        dvCULParameter.RowFilter = ""
        dvCULParameter.Table.AcceptChanges()

        Me.dtpActivatedDate.MinDate = "2013-1-1" : Me.dtpActivatedDate.MaxDate = Today
        Me.dtpActivatedDate.Value = Today

        'modify code 012:start-------------------------------------------------------------------------
        GetCardCostByCityID()
        'modify code 012:end-------------------------------------------------------------------------

        txbReferenceNo.Enabled = False
    End Sub

    Private Sub txbCardNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbCardNo.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then Me.txbBarcode.Select() : Me.txbBarcode.SelectAll() : e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If Me.txbCardNo.SelectedText = Me.txbCardNo.Text Then Me.txbCardNo.Text = ""
            Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbCardNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbCardNo.Leave
        If Me.txbCardNo.ReadOnly Then Return
        If Me.txbCardNo.Text <> Me.txbCardNo.Text.Trim Then Me.txbCardNo.Text = Me.txbCardNo.Text.Trim
        Dim sValue As String = Me.txbCardNo.Text

        If sValue <> "" AndAlso sValue <> sCardNo Then
            If Not IsNumeric(sValue) Then
                Me.lblCardNoError.Text = "（卡号只能由数字组成！）"
            ElseIf sValue.Length < 19 Then
                Me.lblCardNoError.Text = "（卡号位数不足 19 位！）"
            ElseIf sValue <> ShoppingCardNo.GetFullCardNo(sValue.Substring(0, 18)) Then
                Me.lblCardNoError.Text = "（卡号校验码错误！）"
            ElseIf sValue.IndexOf("233660") <> 0 AndAlso sValue.IndexOf("233680888") <> 0 Then
                Me.lblCardNoError.Text = "（该卡不是礼品卡！）"
            ElseIf dvCULParameter.Table.Select("CULCardBin='" & sValue.Substring(4, 5) & "'").Length = 0 Then
                Me.lblCardNoError.Text = "（无权操作该卡段！）"
            Else
                sCardNo = sValue

                '获取交易参考号
                Dim electService As InternetElects.Service = Nothing, sMerchantNo As String
                Try
                    electService = New InternetElects.Service()
                    sMerchantNo = dvCULParameter.Table.Select("CULCardBin='" & sValue.Substring(4, 5) & "'")(0)("CULStoreCode").ToString

                    Dim list As New List(Of InternetElects.CtqyMultiCardInfo)
                    Dim cmci As New InternetElects.CtqyMultiCardInfo()
                    cmci.cardNo = sValue
                    list.Add(cmci)

                    Dim cmc As New InternetElects.CtqyMultiCardBean()
                    cmc.merchantNo = sMerchantNo
                    cmc.userId = sMerchantNo
                    cmc.cardInfos = list.ToArray
                    cmc.isVerifyPassword = "N"
                    cmc.queryType = "H"
                    cmc.isPager = "N"
                    cmc.pageNo = "1"
                    cmc.pageSize = "1000000"

                    Dim cmd As New InternetElects.CtqyMultiDataClass()
                    cmd = electService.CtqyMultiCardData(cmc)
                    If cmd.code = "00" AndAlso cmd.cardTxns.Length > 0 Then
                        If cmd.cardTxns(0).rrn <> "" Then
                            txbReferenceNo.Text = cmd.cardTxns(0).rrn
                        Else
                            Me.lblCardNoError.ForeColor = Color.Red
                            Me.lblCardNoError.Text = "该卡号没有找到对应交易参考号，请手动录入！"
                        End If
                    Else
                        Me.lblCardNoError.ForeColor = Color.Red
                        Me.lblCardNoError.Text = "该卡号没有交易参考号，请手动录入！"
                    End If
                Catch ex As Exception
                    Me.lblCardNoError.ForeColor = Color.Red
                    Me.lblCardNoError.Text = "获取交易参考号操作时出现错误！"
                Finally
                    If electService IsNot Nothing Then electService.Dispose() : electService = Nothing
                End Try
            End If
        End If

        If sValue <> "" AndAlso Me.lblCardNoError.Text = "" AndAlso Me.txbBarcode.Text <> "" AndAlso Me.lblBarcodeError.Text = "" AndAlso Me.txbReferenceNo.Text <> "" AndAlso Me.lblReferenceNoError.Text = "" AndAlso Me.txbReason.Text.Trim <> "" Then
            Me.btnRequest.Enabled = True
        Else
            If Me.lblCardNoError.Text <> "" Then
                Me.txbCardNo.Select()
                Me.txbCardNo.SelectAll()
            End If
            Me.btnRequest.Enabled = False
        End If
    End Sub

    Private Sub txbCardNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbCardNo.TextChanged
        Me.lblCardNoError.Text = ""
        If Me.txbCardNo.Text.Trim <> "" AndAlso Me.txbBarcode.Text <> "" AndAlso Me.lblBarcodeError.Text = "" AndAlso Me.txbReferenceNo.Text <> "" AndAlso Me.lblReferenceNoError.Text = "" AndAlso Me.txbReason.Text.Trim <> "" Then
            Me.btnRequest.Enabled = True
        Else
            Me.btnRequest.Enabled = False
        End If
        'modify code 012:start-------------------------------------------------------------------------
        If Me.txbCardNo.Text.Trim.Length = 19 Then
            Me.txbCardCost.Text = "0.00"
            If dtCardCostManage.Rows.Count > 0 Then
                For Each drCardCostManage As DataRow In dtCardCostManage.Rows
                    If drCardCostManage("StoreID").ToString = dvCULParameter.Table.Select("CULCardBin='" & Me.txbCardNo.Text.Trim.Substring(4, 5) & "'")(0)("AreaID").ToString Then
                        Me.txbCardCost.Text = Format(drCardCostManage("CardCost"), "#0.00")
                        Exit For
                    End If
                Next
            End If
        End If
        'modify code 012:end-------------------------------------------------------------------------
    End Sub

    Private Sub txbBarcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbBarcode.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then Me.dtpActivatedDate.Select() : e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If Me.txbBarcode.SelectedText = Me.txbBarcode.Text Then Me.txbBarcode.Text = ""
            Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbBarcode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbBarcode.Leave
        If Me.txbBarcode.ReadOnly Then Return
        If Me.txbBarcode.Text <> Me.txbBarcode.Text.Trim Then Me.txbBarcode.Text = Me.txbBarcode.Text.Trim
        Dim sValue As String = Me.txbBarcode.Text

        If sValue <> "" Then
            If Not IsNumeric(sValue) Then
                Me.lblBarcodeError.Text = "（商品条形码只能由数字组成！）"
            ElseIf sValue.Length < 13 Then
                Me.lblBarcodeError.Text = "（商品条形码位数不足 13 位！）"
            End If
        End If

        If Me.txbCardNo.Text <> "" AndAlso Me.lblCardNoError.Text = "" AndAlso Me.txbBarcode.Text <> "" AndAlso Me.lblBarcodeError.Text = "" AndAlso Me.txbReferenceNo.Text <> "" AndAlso Me.lblReferenceNoError.Text = "" AndAlso Me.txbReason.Text.Trim <> "" Then
            Me.btnRequest.Enabled = True
        Else
            If Me.lblBarcodeError.Text <> "" Then
                Me.txbBarcode.Select()
                Me.txbBarcode.SelectAll()
            End If
            Me.btnRequest.Enabled = False
        End If
    End Sub

    Private Sub txbBarcode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbBarcode.TextChanged
        Me.lblBarcodeError.Text = ""
        If Me.txbCardNo.Text <> "" AndAlso Me.lblCardNoError.Text = "" AndAlso Me.txbBarcode.Text <> "" AndAlso Me.lblBarcodeError.Text = "" AndAlso Me.txbReferenceNo.Text <> "" AndAlso Me.lblReferenceNoError.Text = "" AndAlso Me.txbReason.Text.Trim <> "" Then
            Me.btnRequest.Enabled = True
        Else
            Me.btnRequest.Enabled = False
        End If
    End Sub

    Private Sub txbReferenceNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbReferenceNo.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        'modify code 012:start-------------------------------------------------------------------------
        'If e.KeyCode = Keys.Enter Then Me.txbReason.Select() : Me.txbReason.SelectAll() : e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then Me.txbCardCost.Select() : Me.txbCardCost.SelectAll() : e.SuppressKeyPress = True : Return
        'modify code 012:end-------------------------------------------------------------------------
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If Me.txbReferenceNo.SelectedText = Me.txbReferenceNo.Text Then Me.txbReferenceNo.Text = ""
            Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbReferenceNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbReferenceNo.Leave
        If Me.txbReferenceNo.ReadOnly Then Return
        If Me.txbReferenceNo.Text <> Me.txbReferenceNo.Text.Trim Then Me.txbReferenceNo.Text = Me.txbReferenceNo.Text.Trim
        Dim sValue As String = Me.txbReferenceNo.Text

        If sValue <> "" Then
            If Not IsNumeric(sValue) Then
                Me.lblReferenceNoError.Text = "（交易参考号只能由数字组成！）"
            ElseIf sValue.Length < 12 Then
                Me.lblReferenceNoError.Text = "（交易参考号位数不足 12 位！）"
            End If
        End If

        If Me.txbCardNo.Text <> "" AndAlso Me.lblCardNoError.Text = "" AndAlso Me.txbBarcode.Text <> "" AndAlso Me.lblBarcodeError.Text = "" AndAlso Me.txbReferenceNo.Text <> "" AndAlso Me.lblReferenceNoError.Text = "" AndAlso Me.txbReason.Text.Trim <> "" Then
            Me.btnRequest.Enabled = True
        Else
            If Me.lblReferenceNoError.Text <> "" Then
                Me.txbReferenceNo.Select()
                Me.txbReferenceNo.SelectAll()
            End If
            Me.btnRequest.Enabled = False
        End If
    End Sub

    Private Sub txbReferenceNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbReferenceNo.TextChanged
        Me.lblReferenceNoError.Text = ""
        If Me.txbCardNo.Text <> "" AndAlso Me.lblCardNoError.Text = "" AndAlso Me.txbBarcode.Text <> "" AndAlso Me.lblBarcodeError.Text = "" AndAlso Me.txbReferenceNo.Text <> "" AndAlso Me.lblReferenceNoError.Text = "" AndAlso Me.txbReason.Text.Trim <> "" Then
            Me.btnRequest.Enabled = True
        Else
            Me.btnRequest.Enabled = False
        End If
    End Sub

    Private Sub txbReason_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbReason.KeyDown
        If e.KeyCode = Keys.Enter AndAlso Me.btnRequest.Enabled Then Me.btnRequest.Select() : e.SuppressKeyPress = True
    End Sub

    Private Sub txbReason_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbReason.Leave
        If Me.txbReason.Text <> Me.txbReason.Text.Trim Then Me.txbReason.Text = Me.txbReason.Text.Trim
        If Me.txbReason.Text = "" Then
            Me.txbReason.Select()
            Me.txbReason.SelectAll()
        End If
    End Sub

    Private Sub txbReason_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbReason.TextChanged
        If Me.txbCardNo.Text <> "" AndAlso Me.lblCardNoError.Text = "" AndAlso Me.txbBarcode.Text <> "" AndAlso Me.lblBarcodeError.Text = "" AndAlso Me.txbReferenceNo.Text <> "" AndAlso Me.lblReferenceNoError.Text = "" AndAlso Me.txbReason.Text.Trim <> "" Then
            Me.btnRequest.Enabled = True
        Else
            Me.btnRequest.Enabled = False
        End If
    End Sub

    Private Sub btnRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRequest.Click
        If Me.btnRequest.Text.IndexOf("开始") > -1 Then
            Me.txbCardNo.ReadOnly = False
            Me.txbCardNo.BackColor = SystemColors.Window
            Me.txbCardNo.Text = ""
            Me.txbBarcode.ReadOnly = False
            Me.txbBarcode.BackColor = SystemColors.Window
            Me.txbBarcode.Text = ""
            Me.dtpActivatedDate.Enabled = True
            Me.txbReferenceNo.ReadOnly = False
            Me.txbReferenceNo.BackColor = SystemColors.Window
            Me.txbReferenceNo.Text = ""
            'modify code 012:start-------------------------------------------------------------------------
            Me.txbCardCost.ReadOnly = False
            Me.txbCardCost.BackColor = SystemColors.Window
            Me.txbCardCost.Text = ""
            'modify code 012:end-------------------------------------------------------------------------
            Me.txbReason.ReadOnly = False
            Me.txbReason.BackColor = SystemColors.Window
            Me.txbReason.Text = ""

            Me.grbResult.Visible = False
            Me.lblStatus.Text = "正在到CUL系统检查该卡是否可以激活撤销……"
            Me.lblResult.Text = ""

            Me.btnRequest.Text = "申请激活撤销(&E)"
            Me.btnRequest.Enabled = False
            Me.pnlPrinting.Visible = False
            Me.btnCancel.Text = "取消(&C)"

            blChecked = False
            Me.txbCardNo.Select()
        Else
            Me.Cursor = Cursors.Default
            Me.grbResult.Visible = True
            Me.lblStatus.ForeColor = SystemColors.ControlText

            If Not blChecked Then
                Me.lblStatus.Text = "正在到CUL系统检查该卡是否可以激活撤销……"
                Me.Refresh()

                Dim sMerchantNo As String = dvCULParameter.Table.Select("CULCardBin='" & sCardNo.Substring(4, 5) & "'")(0)("CULStoreCode").ToString, sDecimalSeparator As String = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
                Dim c4Service As C4ShoppingCardService.C4ShoppingCardService = Nothing
                Try
                    c4Service = New C4ShoppingCardService.C4ShoppingCardService
                    Dim inactiveClass As New C4ShoppingCardService.InactiveClass

                    inactiveClass.MerchantNo = sMerchantNo
                    inactiveClass.UserID = sMerchantNo
                    inactiveClass.CardNo = sCardNo
                    inactiveClass.Ean = Me.txbBarcode.Text
                    inactiveClass.TxnTime = Format(Me.dtpActivatedDate.Value, "yyyyMMdd")
                    inactiveClass.RefNo = Me.txbReferenceNo.Text
                    inactiveClass.OpeType = "CHECK"

                    'modify code 033:start-------------------------------------------------------------------------
                    guIDClass = New C4ShoppingCardService.GuIDClass
                    guIDClass.GuID = frmMain.sGuID
                    Dim inactiveData As C4ShoppingCardService.InactiveDataClass = c4Service.inactive(inactiveClass, guIDClass)
                    'modify code 033:end-------------------------------------------------------------------------
                    If inactiveData.Code = "25" Then
                        blChecked = True
                        dmFaceValue = CDec(inactiveData.CardPrice.Replace(".", sDecimalSeparator))
                        dmPrice = CDec(inactiveData.SaleAmount.Replace(".", sDecimalSeparator))

                        Me.txbCardNo.ReadOnly = True
                        Me.txbCardNo.BackColor = SystemColors.Window
                        Me.txbCardNo.BackColor = SystemColors.Control
                        Me.txbBarcode.ReadOnly = True
                        Me.txbBarcode.BackColor = SystemColors.Window
                        Me.txbBarcode.BackColor = SystemColors.Control
                        Me.dtpActivatedDate.Enabled = False
                        Me.txbReferenceNo.ReadOnly = True
                        Me.txbReferenceNo.BackColor = SystemColors.Window
                        Me.txbReferenceNo.BackColor = SystemColors.Control
                        'modify code 012:start-------------------------------------------------------------------------
                        Me.txbCardCost.ReadOnly = True
                        Me.txbCardCost.BackColor = SystemColors.Window
                        Me.txbCardCost.BackColor = SystemColors.Control
                        'modify code 012:end-------------------------------------------------------------------------
                        Me.txbReason.ReadOnly = True
                        Me.txbReason.BackColor = SystemColors.Window
                        Me.txbReason.BackColor = SystemColors.Control

                        sPrice = Format(dmPrice, "#,0.00") : sCost = Format(dmPrice - dmFaceValue, "#,0.00") : sFaceValue = Format(dmFaceValue, "#,0.00")
                        If sPrice.IndexOf(".00") > 0 AndAlso sCost.IndexOf(".00") > 0 AndAlso sFaceValue.IndexOf(".00") > 0 Then
                            sPrice = sPrice.Replace(".00", "")
                            sCost = sCost.Replace(".00", "")
                            sFaceValue = sFaceValue.Replace(".00", "")
                        End If
                        sFaceValue = StrDup(Len(sPrice) - Len(sFaceValue), " ") & sFaceValue
                        'modify code 012:start-------------------------------------------------------------------------
                        'sCost = StrDup(Len(sPrice) - Len(sCost), " ") & sCost
                        sCost = Me.txbCardCost.Text.Trim
                        'Me.lblResult.Text = "面值：" & sFaceValue & " 元" & Chr(13) & "成本：" & sCost & " 元" & Chr(13) & "售价：" & sPrice & " 元"
                        Me.lblResult.Text = "面值：" & sFaceValue & " 元" & Chr(13) & "卡费：" & sCost & " 元" & Chr(13) & "售价：" & sPrice & " 元"
                        'modify code 012:end-------------------------------------------------------------------------
                    Else
                        Me.lblStatus.ForeColor = Color.Red
                        Me.lblStatus.Text = "此礼品卡不可以进行激活撤销！下面是来自CUL的原因提示："
                        Me.lblResult.Text = inactiveData.Msg
                        Me.btnRequest.Enabled = False
                    End If

                    inactiveClass = Nothing : inactiveData = Nothing
                Catch ex As Exception
                    Me.lblStatus.ForeColor = Color.Red
                    Me.lblStatus.Text = "检查礼品卡失败！下面是具体的错误提示："
                    Me.lblResult.Text = ex.Message
                Finally
                    If c4Service IsNot Nothing Then c4Service.Dispose() : c4Service = Nothing
                End Try
            End If

            If blChecked Then
                Me.lblStatus.Text = "正在保存激活撤销申请记录……"
                Me.Refresh()

                Dim DB As New DataBase
                DB.Open()
                If DB.IsConnected Then
                    'modify code 012:start-------------------------------------------------------------------------
                    'Dim dtResult As DataTable = DB.GetDataTable("Exec CULGiftCardCancelActivationRequest '" & sCardNo & "','" & Me.txbBarcode.Text & "','" & Format(Me.dtpActivatedDate.Value, "yyyy\/MM\/dd") & "','" & Me.txbReferenceNo.Text & "'," & dmFaceValue.ToString & "," & dmPrice.ToString & ",'" & Me.txbReason.Text.Trim.Replace("'", "''") & "','" & frmMain.sLoginUserRealName.Replace("'", "''") & "'," & frmMain.sSSID)
                    Dim dtResult As DataTable = DB.GetDataTable("Exec CULGiftCardCancelActivationRequest '" & sCardNo & "','" & Me.txbBarcode.Text & "','" & Format(Me.dtpActivatedDate.Value, "yyyy\/MM\/dd") & "','" & Me.txbReferenceNo.Text & "'," & dmFaceValue.ToString & "," & dmPrice.ToString & ",'" & Me.txbReason.Text.Trim.Replace("'", "''") & "','" & frmMain.sLoginUserRealName.Replace("'", "''") & "'," & frmMain.sSSID & "," & Me.txbCardCost.Text.Trim)
                    'modify code 012:end-------------------------------------------------------------------------
                    If dtResult Is Nothing Then
                        Me.lblStatus.ForeColor = Color.Red
                        Me.lblStatus.Text = "保存激活撤销申请记录时出现数据库内部错误！"
                    ElseIf dtResult.Rows(0)("Result").ToString = "Failure" Then
                        Me.lblStatus.ForeColor = Color.Red
                        Me.lblStatus.Text = "保存激活撤销申请记录失败！失败原因：" & dtResult.Rows(0)("FailureReason").ToString
                    ElseIf dtResult.Rows(0)("Result").ToString = "Error" Then
                        Me.lblStatus.ForeColor = Color.Red
                        Me.lblStatus.Text = "保存激活撤销申请记录时出现错误！"
                        MessageBox.Show("系统无法保存激活撤销申请记录！下面是数据库的内部错误提示：    " & Chr(13) & Chr(13) & dtResult.Rows(0)("ErrorInfo").ToString & Space(4) & Chr(13) & Chr(13) & "请重试。如果仍有问题，请联系软件开发人员。    ", "保存购物卡换卡申请时出现数据库内部错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        Me.lblStatus.Text = "为确保礼品卡不被消费，正对礼品卡执行冻结操作……"
                        Me.Refresh()

                        Dim dtCard As New DataTable()
                        dtCard.Columns.Add("CardNo", System.Type.GetType("System.String"))
                        dtCard.Rows.Add(sCardNo).AcceptChanges()
                        If ShoppingCardOperation.CRFCardAutoFreeze(True, dvCULParameter.Table, dtCard) = 0 Then
                            Me.lblStatus.Text = "礼品卡激活撤销申请成功（但自动冻结失败，请手工冻结！）。以下是该卡的价格信息："
                        Else
                            Me.lblStatus.Text = "礼品卡激活撤销申请成功。以下是该卡的价格信息："
                        End If

                        Me.pnlPrinting.Visible = True
                        Me.btnCancel.Text = "关闭(&C)"
                        Me.btnRequest.Text = "开始新的操作(&S)"
                        Me.btnHistory.Enabled = True
                        dtCard.Dispose() : dtCard = Nothing
                    End If

                    If dtResult IsNot Nothing Then dtResult.Dispose() : dtResult = Nothing
                Else
                    Me.lblStatus.ForeColor = Color.Red
                    Me.lblStatus.Text = "系统因连接不到数据库而无法保存激活撤销申请记录！请检查数据库连接。"
                End If
                DB.Close()
            End If

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If My.Settings.GiftCardCancellationPrinter = "" Then
            frmConfigTicket.Text = "未指定礼品卡激活撤销凭证打印机，请先指定打印机："
            Me.btnConfig.PerformClick()
            If My.Settings.GiftCardCancellationPrinter = "" Then Return
        End If

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在打印礼品卡激活撤销凭证……"
        frmMain.statusMain.Refresh()

        Dim DB As New DataBase()
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打印礼品卡激活撤销凭证。请检查数据库连接。"
            Me.Activate() : Me.Cursor = Cursors.Default : Return
        End If

        Try
            Dim CancellationForm As New System.Drawing.Printing.PrintDocument, PrintStandard As New System.Drawing.Printing.StandardPrintController()
            CancellationForm.PrintController = PrintStandard '不出现打印窗口
            CancellationForm.DocumentName = "GiftCardCancellation_" & Me.txbCardNo.Text
            CancellationForm.PrinterSettings.PrinterName = My.Settings.GiftCardCancellationPrinter
            AddHandler CancellationForm.PrintPage, AddressOf CancellationForm_PrintPage

            CancellationForm.Print() : CancellationForm.Dispose()

            Try
                sPrintedTime = Format(DB.GetDataTable("Select GetDate()").Rows(0)(0), "yyyy\/MM\/dd HH:mm:ss")
                DB.ModifyTable("Exec OperationLogInsert " & frmMain.sSSID & ",'Print Gift Card Activation Cancellation Form (CardNo: " & sCardNo & ")','GiftCard',NULL")
            Catch
            End Try
            frmMain.statusText.Text = "就绪。"
        Catch ex As Exception
            MessageBox.Show("打印礼品卡激活撤销凭证时发生如下错误：    " & Chr(13) & Chr(13) & ex.Message & "    ", "打印礼品卡激活撤销凭证出错！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "打印礼品卡激活撤销凭证出错！"
        End Try

        DB.Close()
        Me.Activate() : Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfig.Click
        If Printing.PrinterSettings.InstalledPrinters.Count = 0 Then
            MessageBox.Show("您的电脑未发现打印机！请先安装打印机。    ", "未发现打印机！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "未发现打印机！"
            Return
        End If

        With frmConfigTicket
            .Text = "请选择用于打印礼品卡激活撤销凭证的打印机："
            For Each sPrinter As String In Printing.PrinterSettings.InstalledPrinters
                .cbbPrinter.Items.Add(sPrinter)
            Next
            If My.Settings.GiftCardCancellationPrinter <> "" AndAlso .cbbPrinter.Items.IndexOf(My.Settings.GiftCardCancellationPrinter) > -1 Then
                .cbbPrinter.SelectedIndex = .cbbPrinter.Items.IndexOf(My.Settings.GiftCardCancellationPrinter)
                If .Text.IndexOf("不再可用") > -1 Then
                    .cbbPrinter.Items(.cbbPrinter.Items.IndexOf(My.Settings.GiftCardCancellationPrinter)) = My.Settings.GiftCardCancellationPrinter & "（不可用）"
                End If
            Else
                Dim printDoc As New Printing.PrintDocument
                .cbbPrinter.SelectedIndex = .cbbPrinter.Items.IndexOf(printDoc.PrinterSettings.PrinterName)
                printDoc.Dispose() : printDoc = Nothing
            End If

            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                My.Settings.GiftCardCancellationPrinter = .cbbPrinter.Text
                My.Settings.Save()
            End If

            .Dispose()
        End With
    End Sub

    Private Sub btnHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistory.Click
        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在打开礼品卡""激活撤销""历史记录窗口……"
        frmMain.statusMain.Refresh()

        If frmGiftCardCancellationHistory.ShowDialog() = Windows.Forms.DialogResult.Ignore Then Me.btnHistory.Enabled = False
        frmGiftCardCancellationHistory.Dispose()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CancellationForm_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        e.Graphics.PageUnit = GraphicsUnit.Millimeter

        Dim titleFont As New Font("宋体", 16), drawFont As New Font("宋体", 10), footFont As New Font("宋体", 9, FontStyle.Italic), blackPen As New Pen(Color.Black, 0.2), drawBrush As New SolidBrush(Color.Black)
        Dim titleFormat As New StringFormat, rightFormat As New StringFormat, drawFormat As New StringFormat
        titleFormat.Alignment = StringAlignment.Center
        rightFormat.Alignment = StringAlignment.Far
        drawFormat.Alignment = StringAlignment.Near
        drawFormat.FormatFlags = StringFormatFlags.NoWrap

        Dim sPrintingText As String = "家乐福礼品卡激活撤销凭证"
        If My.Settings.IsInTraining Then sPrintingText = sPrintingText & "（培训使用，非有效凭证）"
        e.Graphics.DrawString(sPrintingText, titleFont, drawBrush, New Rectangle(0, 3, 200, 20), titleFormat)

        e.Graphics.DrawLine(blackPen, 0, 15, 200, 15)
        e.Graphics.DrawString("礼品卡信息如下：", drawFont, drawBrush, New Rectangle(10, 20, 80, 10), drawFormat)
        e.Graphics.DrawLine(blackPen, 10, 24, 38, 24)
        e.Graphics.DrawString("卡号      ：" & Me.txbCardNo.Text, drawFont, drawBrush, New Rectangle(10, 30, 80, 10), drawFormat)
        e.Graphics.DrawString("条形码    ：" & Me.txbBarcode.Text, drawFont, drawBrush, New Rectangle(10, 35, 80, 10), drawFormat)
        e.Graphics.DrawString("面值      ：" & sFaceValue & " 元", drawFont, drawBrush, New Rectangle(10, 40, 80, 10), drawFormat)
        'modify code 012:start-------------------------------------------------------------------------
        'e.Graphics.DrawString("卡成本    ：" & sCost & " 元", drawFont, drawBrush, New Rectangle(10, 45, 80, 10), drawFormat)
        e.Graphics.DrawString("卡费      ：" & sCost & " 元", drawFont, drawBrush, New Rectangle(10, 45, 80, 10), drawFormat)
        'modify code 012:end-------------------------------------------------------------------------
        e.Graphics.DrawString("售价      ：" & sPrice & " 元", drawFont, drawBrush, New Rectangle(10, 50, 80, 10), drawFormat)
        e.Graphics.DrawString("交易日期  ：" & Format(Me.dtpActivatedDate.Value, "yyyy\/MM\/dd"), drawFont, drawBrush, New Rectangle(10, 55, 80, 10), drawFormat)
        e.Graphics.DrawString("交易参考号：" & Me.txbReferenceNo.Text, drawFont, drawBrush, New Rectangle(10, 60, 80, 10), drawFormat)
        e.Graphics.DrawString("撤销原因  ：" & Me.txbReason.Text, drawFont, drawBrush, New Rectangle(10, 65, 180, 10), drawFormat)

        e.Graphics.DrawString("此卡可以激活撤销。应退金额：" & sPrice & " 元。", drawFont, drawBrush, New Rectangle(10, 90, 80, 10), drawFormat)
        e.Graphics.DrawString("客户签名：", drawFont, drawBrush, New Rectangle(105, 105, 20, 10), drawFormat)
        e.Graphics.DrawString("销售签名：", drawFont, drawBrush, New Rectangle(153, 105, 20, 10), drawFormat)

        e.Graphics.DrawLine(blackPen, 0, 116, 200, 116)

        e.Graphics.DrawString("门店：" & frmMain.dtLoginStructure.Rows.Find(frmMain.sLoginAreaID)("AreaName").ToString & "  " & _
                              "操作：" & frmMain.sLoginUserRealName & "  " & _
                              "打印时间：" & sPrintedTime, footFont, drawBrush, New Rectangle(0, 123, 200, 10), drawFormat)

        e.HasMorePages = False
    End Sub

    'modify code 012:start-------------------------------------------------------------------------
    Private Sub txbCardCost_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbCardCost.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then Me.txbReason.Select() : Me.txbReason.SelectAll() : e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If Me.txbCardCost.SelectedText = Me.txbCardCost.Text Then Me.txbCardCost.Text = ""
            Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub GetCardCostByCityID()
        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法获取当前卡费。请检查数据库连接。"
            Me.Close() : Return
        End If

        Try
            dtCardCostManage = DB.GetDataTable("Select A.AreaID as StoreID,P.CardCost From CardCostManage P " _
                                               & " Inner Join AreaList A on A.ParentAreaID = P.CityID " _
                                               & " Inner Join AreaScope(" & frmMain.sLoginUserID & ") AS S On A.AreaID=S.AreaID " _
                                               & " where P.CardType = '60'").Copy
            DB.Close()
        Catch ex As Exception
            DB.Close()
        End Try
    End Sub

    'modify code 012:end-------------------------------------------------------------------------

End Class