Public Class frmGiftCardOfflineActivationRequirement

    'modify code 033:
    'date;2014/7/24
    'auther:Hyron bjy 
    'remark:更改特殊操作用户登录验证方式为guid

    Private dvCULParameter As DataView, sCardNo As String = "", sPrice As String = "", sCost As String = "", sFaceValue As String = "", sActivatedTime As String = "", dmFaceValue As Decimal = 0, dmPrice As Decimal = 0, sPosBatchNo As String = "", sPosRefNo As String = "", sReferenceNo As String = "", sPrintedTime As String

    'modify code 033:start-------------------------------------------------------------------------
    Dim guIDClass As C4ShoppingCardService.GuIDClass
    'modify code 033:end-------------------------------------------------------------------------

    Private Sub frmGiftCardOfflineActivationRequirement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dtpTicketDate.MinDate = "2013/01/01"
        Me.dtpTicketDate.MaxDate = Today

        dvCULParameter = frmMain.dtLoginStructure.Copy.DefaultView
        dvCULParameter.RowFilter = "AreaType='S'"
        dvCULParameter.Sort = "AreaCode"
        For Each drCUL As DataRowView In dvCULParameter
            Me.cbbTicketStoreCode.Items.Add(drCUL("AreaCode").ToString.Substring(1))
        Next
        Me.cbbTicketStoreCode.SelectedIndex = 0
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
            End If
        End If

        If sValue <> "" AndAlso Me.lblCardNoError.Text = "" AndAlso Me.txbBarcode.Text <> "" AndAlso Me.lblBarcodeError.Text = "" Then
            Me.btnQuery.Enabled = True
        Else
            If Me.lblCardNoError.Text <> "" Then
                Me.txbCardNo.Select()
                Me.txbCardNo.SelectAll()
            End If
            Me.btnQuery.Enabled = False
        End If
    End Sub

    Private Sub txbCardNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbCardNo.TextChanged
        Me.lblCardNoError.Text = ""
        If Me.txbCardNo.Text.Trim <> "" AndAlso Me.txbBarcode.Text <> "" AndAlso Me.lblBarcodeError.Text = "" Then
            Me.btnQuery.Enabled = True
        Else
            Me.btnQuery.Enabled = False
        End If
    End Sub

    Private Sub txbBarcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbBarcode.KeyDown, txbTicketPosNo.KeyDown, txbTicketTransNo.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then
            If Me.btnQuery.Enabled Then Me.btnQuery.Select()
            e.SuppressKeyPress = True : Return
        End If
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If Me.txbBarcode.SelectedText = Me.txbBarcode.Text Then Me.txbBarcode.Text = ""
            Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbBarcode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbBarcode.Leave, txbTicketPosNo.Leave, txbTicketTransNo.Leave
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

        If Me.txbCardNo.Text <> "" AndAlso Me.lblCardNoError.Text = "" AndAlso Me.txbBarcode.Text <> "" AndAlso Me.lblBarcodeError.Text = "" Then
            Me.btnQuery.Enabled = True
        Else
            If Me.lblBarcodeError.Text <> "" Then
                Me.txbBarcode.Select()
                Me.txbBarcode.SelectAll()
            End If
            Me.btnQuery.Enabled = False
        End If
    End Sub

    Private Sub txbBarcode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbBarcode.TextChanged, txbTicketPosNo.TextChanged, txbTicketTransNo.TextChanged
        Me.lblBarcodeError.Text = ""
        If Me.txbCardNo.Text <> "" AndAlso Me.lblCardNoError.Text = "" AndAlso Me.txbBarcode.Text <> "" AndAlso Me.lblBarcodeError.Text = "" Then
            Me.btnQuery.Enabled = True
        Else
            Me.btnQuery.Enabled = False
        End If
    End Sub

    Private Sub btnExcute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        If Me.btnQuery.Text.IndexOf("开始") > -1 Then
            Me.txbCardNo.ReadOnly = False
            Me.txbCardNo.BackColor = SystemColors.Window
            Me.txbCardNo.Text = ""
            Me.txbBarcode.ReadOnly = False
            Me.txbBarcode.BackColor = SystemColors.Window
            Me.txbBarcode.Text = ""

            Me.pnlTicketInfo.Visible = False
            Me.dtpTicketDate.Enabled = True
            Me.cbbTicketStoreCode.Enabled = True
            Me.txbTicketPosNo.ReadOnly = False
            Me.txbTicketPosNo.BackColor = SystemColors.Window
            Me.txbTicketPosNo.Text = ""
            Me.txbTicketTransNo.ReadOnly = False
            Me.txbTicketTransNo.BackColor = SystemColors.Window
            Me.txbTicketTransNo.Text = ""

            Me.grbResult.Visible = False
            Me.lblStatus.Text = "正在到CUL系统查询该卡的状态……"
            Me.lblResult.Text = ""

            Me.btnQuery.Text = "查询礼品卡状态(&Q)"
            Me.btnQuery.Enabled = False
            Me.tlpOptional.Visible = False
            Me.btnSave.Enabled = True
            Me.btnCancel.Text = "取消(&C)"

            Me.txbCardNo.Select()
        Else
            Me.Cursor = Cursors.Default
            Me.grbResult.Visible = True
            Me.lblStatus.ForeColor = SystemColors.ControlText
            Me.lblStatus.Text = "正在到CUL系统查询该卡的状态……"
            Me.Refresh()

            Dim sMerchantNo As String = dvCULParameter.Table.Select("CULCardBin='" & sCardNo.Substring(4, 5) & "'")(0)("CULStoreCode").ToString, sDecimalSeparator As String = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
            Dim c4Service As C4ShoppingCardService.C4ShoppingCardService = Nothing
            Try
                c4Service = New C4ShoppingCardService.C4ShoppingCardService
                Dim offlineactivateClass As New C4ShoppingCardService.OfflineActiveClass

                offlineactivateClass.MerchantNo = sMerchantNo
                offlineactivateClass.UserID = sMerchantNo
                offlineactivateClass.CardNo = sCardNo
                offlineactivateClass.Ean = Me.txbBarcode.Text

                'modify code 033:start-------------------------------------------------------------------------
                guIDClass = New C4ShoppingCardService.GuIDClass
                guIDClass.GuID = frmMain.sGuID
                Dim offlineactivateData As C4ShoppingCardService.OfflineActiveDataClass = c4Service.offlineActiveC4p(offlineactivateClass, guIDClass)
                'modify code 033:end-------------------------------------------------------------------------
                If offlineactivateData.Code = "00" Then
                    sActivatedTime = offlineactivateData.TxnDate.Insert(4, "/").Insert(7, "/") & " " & offlineactivateData.TxnTime.Insert(2, ":").Insert(5, ":")
                    sPosBatchNo = offlineactivateData.PosBatchNo
                    sPosRefNo = offlineactivateData.PosRefNo
                    sReferenceNo = offlineactivateData.RetriRefNo
                    dmFaceValue = CDec(offlineactivateData.CardPrice.Replace(".", sDecimalSeparator))
                    dmPrice = CDec(offlineactivateData.SalePrice.Replace(".", sDecimalSeparator))
                    sPrice = Format(dmPrice, "#,0.00")
                    sCost = Format(dmPrice - dmFaceValue, "#,0.00")
                    sFaceValue = Format(dmFaceValue, "#,0.00")
                    If sPrice.IndexOf(".00") > 0 AndAlso sCost.IndexOf(".00") > 0 AndAlso sFaceValue.IndexOf(".00") > 0 Then
                        sPrice = sPrice.Replace(".00", "")
                        sCost = sCost.Replace(".00", "")
                        sFaceValue = sFaceValue.Replace(".00", "")
                    End If
                    sFaceValue = StrDup(Len(sPrice) - Len(sFaceValue), " ") & sFaceValue
                    sCost = StrDup(Len(sPrice) - Len(sCost), " ") & sCost

                    Me.txbCardNo.ReadOnly = True
                    Me.txbCardNo.BackColor = SystemColors.Window
                    Me.txbCardNo.BackColor = SystemColors.Control
                    Me.txbBarcode.ReadOnly = True
                    Me.txbBarcode.BackColor = SystemColors.Window
                    Me.txbBarcode.BackColor = SystemColors.Control

                    Me.lblStatus.Text = "礼品卡已激活，无须申请离线激活。以下是该卡的激活信息："
                    Me.lblResult.Text = "激活时间：" & sActivatedTime & Chr(13) & "参 考 号：" & sReferenceNo & Chr(13) & "面    值：" & sFaceValue & " 元" & Chr(13) & "成    本：" & sCost & " 元" & Chr(13) & "售    价：" & sPrice & " 元"

                    Me.btnQuery.Text = "开始新的操作(&S)"
                    Me.tlpOptional.Visible = True
                    Me.btnSave.Visible = False
                    Me.pnlPrinting.Visible = True
                    Me.btnPrint.Text = "打印激活凭证(&P)"
                    Me.btnCancel.Text = "关闭(&C)"
                ElseIf offlineactivateData.Code = "16" Then
                    sActivatedTime = "" : sPosBatchNo = "" : sPosRefNo = "" : sReferenceNo = ""
                    dmFaceValue = CDec(offlineactivateData.CardPrice.Replace(".", sDecimalSeparator))
                    dmPrice = CDec(offlineactivateData.SalePrice.Replace(".", sDecimalSeparator))
                    sPrice = Format(dmPrice, "#,0.00")
                    sCost = Format(dmPrice - dmFaceValue, "#,0.00")
                    sFaceValue = Format(dmFaceValue, "#,0.00")
                    If sPrice.IndexOf(".00") > 0 AndAlso sCost.IndexOf(".00") > 0 AndAlso sFaceValue.IndexOf(".00") > 0 Then
                        sPrice = sPrice.Replace(".00", "")
                        sCost = sCost.Replace(".00", "")
                        sFaceValue = sFaceValue.Replace(".00", "")
                    End If
                    sFaceValue = StrDup(Len(sPrice) - Len(sFaceValue), " ") & sFaceValue
                    sCost = StrDup(Len(sPrice) - Len(sCost), " ") & sCost

                    Me.txbCardNo.ReadOnly = True
                    Me.txbCardNo.BackColor = SystemColors.Window
                    Me.txbCardNo.BackColor = SystemColors.Control
                    Me.txbBarcode.ReadOnly = True
                    Me.txbBarcode.BackColor = SystemColors.Window
                    Me.txbBarcode.BackColor = SystemColors.Control

                    Me.pnlTicketInfo.Visible = True

                    Me.lblStatus.Text = "礼品卡未激活，可以申请离线激活。以下是该卡的激活信息："
                    Me.lblResult.Text = "面值：" & sFaceValue & " 元" & Chr(13) & "成本：" & sCost & " 元" & Chr(13) & "售价：" & sPrice & " 元"

                    Me.btnQuery.Text = "开始新的操作(&S)"
                    Me.tlpOptional.Visible = True
                    Me.btnSave.Visible = True
                    Me.pnlPrinting.Visible = False
                    Me.btnPrint.Text = "打印申请凭证(&P)"

                    Me.txbTicketPosNo.Select()
                Else
                    Me.lblStatus.ForeColor = Color.Red
                    Me.lblStatus.Text = "礼品卡不可申请离线激活！下面是来自CUL的原因提示："
                    Me.lblResult.Text = offlineactivateData.Msg
                    Me.btnQuery.Enabled = False
                End If

                offlineactivateClass = Nothing
                offlineactivateData = Nothing
            Catch ex As Exception
                Me.lblStatus.ForeColor = Color.Red
                Me.lblStatus.Text = "查询礼品卡的状态失败！因为执行操作时出现错误，下面是具体的错误提示："
                Me.lblResult.Text = ex.Message
            Finally
                If c4Service IsNot Nothing Then c4Service.Dispose() : c4Service = Nothing
            End Try

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Me.txbTicketPosNo.Text = "" Then
            MessageBox.Show("家乐福收银小票机台号不能为空！    ", "未输入机台号！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.txbTicketPosNo.Select()
            Return
        End If

        If Not IsNumeric(Me.txbTicketPosNo.Text) Then
            MessageBox.Show("家乐福收银小票机台号只能由数字组成！    ", "机台号不是数字！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.txbTicketPosNo.Select() : Me.txbTicketPosNo.SelectAll()
            Return
        End If

        Me.txbTicketPosNo.Text = Me.txbTicketPosNo.Text.Trim
        If Me.txbTicketPosNo.Text.Length < Me.txbTicketPosNo.MaxLength Then Me.txbTicketPosNo.Text = StrDup(Me.txbTicketPosNo.MaxLength - Me.txbTicketPosNo.Text.Length, "0") & Me.txbTicketPosNo.Text

        If Me.txbTicketTransNo.Text = "" Then
            MessageBox.Show("家乐福收银小票交易流水号不能为空！    ", "未输入交易流水号！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.txbTicketTransNo.Select()
            Return
        End If

        If Not IsNumeric(Me.txbTicketTransNo.Text) Then
            MessageBox.Show("家乐福收银小票交易流水号只能由数字组成！    ", "交易流水号不是数字！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.txbTicketTransNo.Select() : Me.txbTicketTransNo.SelectAll()
            Return
        End If

        Me.txbTicketTransNo.Text = Me.txbTicketTransNo.Text.Trim
        If Me.txbTicketTransNo.Text.Length < Me.txbTicketTransNo.MaxLength Then Me.txbTicketTransNo.Text = StrDup(Me.txbTicketTransNo.MaxLength - Me.txbTicketTransNo.Text.Length, "0") & Me.txbTicketTransNo.Text

        Me.Cursor = Cursors.WaitCursor
        Me.lblStatus.Text = "正在保存离线激活申请记录……"
        Me.Refresh()

        Dim DB As New DataBase
        DB.Open()
        If DB.IsConnected Then
            Dim dtResult As DataTable = DB.GetDataTable("Exec CULOfflineActivateGiftCardRequest '" & sCardNo & "','" & Me.txbBarcode.Text & "'," & dmFaceValue.ToString & "," & dmPrice.ToString & ",'" & Format(Me.dtpTicketDate.Value, "yyyy\/MM\/dd") & "','" & Me.cbbTicketStoreCode.Text & "','" & Me.txbTicketPosNo.Text & "','" & Me.txbTicketTransNo.Text & "','" & frmMain.sLoginUserRealName.Replace("'", "''") & "'," & frmMain.sSSID)

            If dtResult Is Nothing Then
                Me.lblStatus.ForeColor = Color.Red
                Me.lblStatus.Text = "保存离线激活申请记录时出现数据库内部错误！"
            ElseIf dtResult.Rows(0)("Result").ToString = "Failure" Then
                Me.lblStatus.ForeColor = Color.Red
                Me.lblStatus.Text = "保存离线激活申请记录失败！失败原因：" & dtResult.Rows(0)("FailureReason").ToString
            ElseIf dtResult.Rows(0)("Result").ToString = "Error" Then
                Me.lblStatus.ForeColor = Color.Red
                Me.lblStatus.Text = "保存离线激活申请记录时出现错误！"
                MessageBox.Show("系统无法保存离线激活申请记录！下面是数据库的内部错误提示：    " & Chr(13) & Chr(13) & dtResult.Rows(0)("ErrorInfo").ToString & Space(4) & Chr(13) & Chr(13) & "请重试。如果仍有问题，请联系软件开发人员。    ", "保存购物卡换卡申请时出现数据库内部错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                Me.dtpTicketDate.Enabled = False
                Me.cbbTicketStoreCode.Enabled = False
                Me.txbTicketPosNo.ReadOnly = True
                Me.txbTicketPosNo.BackColor = SystemColors.Window
                Me.txbTicketPosNo.BackColor = SystemColors.Control
                Me.txbTicketTransNo.ReadOnly = True
                Me.txbTicketTransNo.BackColor = SystemColors.Window
                Me.txbTicketTransNo.BackColor = SystemColors.Control

                Me.lblStatus.Text = "离线激活申请记录已保存。"
                Me.btnSave.Enabled = False
                Me.pnlPrinting.Visible = True
                Me.btnHistory.Enabled = True
                Me.btnCancel.Text = "关闭(&C)"
            End If

            If dtResult IsNot Nothing Then dtResult.Dispose() : dtResult = Nothing
        Else
            Me.lblStatus.ForeColor = Color.Red
            Me.lblStatus.Text = "保存离线激活申请记录失败！请重试。"
        End If
        DB.Close()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If My.Settings.GiftCardOfflineActivationPrinter = "" Then
            frmConfigTicket.Text = "未指定礼品卡激活凭证打印机，请先指定打印机："
            Me.btnConfig.PerformClick()
            If My.Settings.GiftCardOfflineActivationPrinter = "" Then Return
        End If

        Dim sTask As String = IIf(sReferenceNo = "", "申请", "激活")
        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在打印礼品卡" & sTask & "凭证……"
        frmMain.statusMain.Refresh()

        Dim DB As New DataBase()
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打印礼品卡" & sTask & "凭证。请检查数据库连接。"
            Me.Activate() : Me.Cursor = Cursors.Default : Return
        End If

        Try
            Dim RequirementForm As New System.Drawing.Printing.PrintDocument, PrintStandard As New System.Drawing.Printing.StandardPrintController()
            RequirementForm.PrintController = PrintStandard '不出现打印窗口
            RequirementForm.DocumentName = "GiftCardOfflineActivation_" & Me.txbCardNo.Text
            RequirementForm.PrinterSettings.PrinterName = My.Settings.GiftCardOfflineActivationPrinter
            If sReferenceNo = "" Then
                AddHandler RequirementForm.PrintPage, AddressOf RequirementForm_PrintPage
            Else
                AddHandler RequirementForm.PrintPage, AddressOf ActivationForm_PrintPage
            End If
            RequirementForm.Print() : RequirementForm.Dispose()

            Try
                sPrintedTime = Format(DB.GetDataTable("Select GetDate()").Rows(0)(0), "yyyy\/MM\/dd HH:mm:ss")
                DB.ModifyTable("Exec OperationLogInsert " & frmMain.sSSID & ",'Print Gift Card " & IIf(sReferenceNo = "", "Activation", "Off-line Activation Requirement") & " Form (CardNo: " & sCardNo & ")','GiftCard',NULL")
            Catch
            End Try
            frmMain.statusText.Text = "就绪。"
        Catch ex As Exception
            MessageBox.Show("打印礼品卡" & sTask & "凭证时发生如下错误：    " & Chr(13) & Chr(13) & ex.Message & "    ", "打印礼品卡" & sTask & "凭证出错！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "打印礼品卡" & sTask & "凭证出错！"
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
            .Text = "请选择用于打印礼品卡激活凭证的打印机："
            For Each sPrinter As String In Printing.PrinterSettings.InstalledPrinters
                .cbbPrinter.Items.Add(sPrinter)
            Next
            If My.Settings.GiftCardOfflineActivationPrinter <> "" AndAlso .cbbPrinter.Items.IndexOf(My.Settings.GiftCardOfflineActivationPrinter) > -1 Then
                .cbbPrinter.SelectedIndex = .cbbPrinter.Items.IndexOf(My.Settings.GiftCardOfflineActivationPrinter)
                If .Text.IndexOf("不再可用") > -1 Then
                    .cbbPrinter.Items(.cbbPrinter.Items.IndexOf(My.Settings.GiftCardOfflineActivationPrinter)) = My.Settings.GiftCardOfflineActivationPrinter & "（不可用）"
                End If
            Else
                Dim printDoc As New Printing.PrintDocument
                .cbbPrinter.SelectedIndex = .cbbPrinter.Items.IndexOf(printDoc.PrinterSettings.PrinterName)
                printDoc.Dispose() : printDoc = Nothing
            End If

            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                My.Settings.GiftCardOfflineActivationPrinter = .cbbPrinter.Text
                My.Settings.Save()
            End If

            .Dispose()
        End With
    End Sub

    Private Sub btnHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistory.Click
        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在打开礼品卡""离线激活""历史记录窗口……"
        frmMain.statusMain.Refresh()

        If frmGiftCardOfflineActivationHistory.ShowDialog() = Windows.Forms.DialogResult.Ignore Then Me.btnHistory.Enabled = False
        frmGiftCardOfflineActivationHistory.Dispose()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub RequirementForm_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        e.Graphics.PageUnit = GraphicsUnit.Millimeter

        Dim titleFont As New Font("宋体", 16), drawFont As New Font("宋体", 10), footFont As New Font("宋体", 9, FontStyle.Italic), blackPen As New Pen(Color.Black, 0.2), drawBrush As New SolidBrush(Color.Black)
        Dim titleFormat As New StringFormat, rightFormat As New StringFormat, drawFormat As New StringFormat
        titleFormat.Alignment = StringAlignment.Center
        rightFormat.Alignment = StringAlignment.Far
        drawFormat.Alignment = StringAlignment.Near
        drawFormat.FormatFlags = StringFormatFlags.NoWrap

        Dim sPrintingText As String = "家乐福礼品卡申请离线激活凭证"
        If My.Settings.IsInTraining Then sPrintingText = sPrintingText & "（培训使用，非有效凭证）"
        e.Graphics.DrawString(sPrintingText, titleFont, drawBrush, New Rectangle(0, 3, 200, 20), titleFormat)

        e.Graphics.DrawLine(blackPen, 0, 15, 200, 15)
        e.Graphics.DrawString("礼品卡信息如下：", drawFont, drawBrush, New Rectangle(10, 20, 80, 10), drawFormat)
        e.Graphics.DrawLine(blackPen, 10, 24, 38, 24)
        e.Graphics.DrawString("卡号      ：" & Me.txbCardNo.Text, drawFont, drawBrush, New Rectangle(10, 30, 80, 10), drawFormat)
        e.Graphics.DrawString("条形码    ：" & Me.txbBarcode.Text, drawFont, drawBrush, New Rectangle(10, 35, 80, 10), drawFormat)
        e.Graphics.DrawString("面值      ：" & sFaceValue & " 元", drawFont, drawBrush, New Rectangle(10, 40, 80, 10), drawFormat)
        e.Graphics.DrawString("卡成本    ：" & sCost & " 元", drawFont, drawBrush, New Rectangle(10, 45, 80, 10), drawFormat)
        e.Graphics.DrawString("售价      ：" & sPrice & " 元", drawFont, drawBrush, New Rectangle(10, 50, 80, 10), drawFormat)
        e.Graphics.DrawString("交易日期  ：" & Format(Me.dtpTicketDate.Value, "yyyy\/MM\/dd"), drawFont, drawBrush, New Rectangle(10, 55, 80, 10), drawFormat)
        e.Graphics.DrawString("交易门店  ：" & Me.cbbTicketStoreCode.Text, drawFont, drawBrush, New Rectangle(10, 60, 80, 10), drawFormat)
        e.Graphics.DrawString("交易机台号：" & Me.txbTicketPosNo.Text, drawFont, drawBrush, New Rectangle(10, 65, 180, 10), drawFormat)
        e.Graphics.DrawString("交易流水号：" & Me.txbTicketTransNo.Text, drawFont, drawBrush, New Rectangle(10, 70, 180, 10), drawFormat)

        e.Graphics.DrawString("此卡已申请离线激活。应激活金额：" & sFaceValue & " 元。", drawFont, drawBrush, New Rectangle(10, 90, 80, 10), drawFormat)
        e.Graphics.DrawString("客户签名：", drawFont, drawBrush, New Rectangle(105, 105, 20, 10), drawFormat)
        e.Graphics.DrawString("销售签名：", drawFont, drawBrush, New Rectangle(153, 105, 20, 10), drawFormat)

        e.Graphics.DrawLine(blackPen, 0, 116, 200, 116)

        e.Graphics.DrawString("门店：" & frmMain.dtLoginStructure.Rows.Find(frmMain.sLoginAreaID)("AreaName").ToString & "  " & _
                              "操作：" & frmMain.sLoginUserRealName & "  " & _
                              "打印时间：" & sPrintedTime, footFont, drawBrush, New Rectangle(0, 123, 200, 10), drawFormat)

        e.HasMorePages = False
    End Sub

    Private Sub ActivationForm_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        e.Graphics.PageUnit = GraphicsUnit.Millimeter

        Dim titleFont As New Font("宋体", 16), drawFont As New Font("宋体", 10), footFont As New Font("宋体", 9, FontStyle.Italic), blackPen As New Pen(Color.Black, 0.2), drawBrush As New SolidBrush(Color.Black)
        Dim titleFormat As New StringFormat, rightFormat As New StringFormat, drawFormat As New StringFormat
        titleFormat.Alignment = StringAlignment.Center
        rightFormat.Alignment = StringAlignment.Far
        drawFormat.Alignment = StringAlignment.Near
        drawFormat.FormatFlags = StringFormatFlags.NoWrap

        Dim sPrintingText As String = "家乐福礼品卡激活凭证"
        If My.Settings.IsInTraining Then sPrintingText = sPrintingText & "（培训使用，非有效凭证）"
        e.Graphics.DrawString(sPrintingText, titleFont, drawBrush, New Rectangle(0, 3, 200, 20), titleFormat)

        e.Graphics.DrawLine(blackPen, 0, 15, 200, 15)
        e.Graphics.DrawString("礼品卡信息如下：", drawFont, drawBrush, New Rectangle(10, 20, 80, 10), drawFormat)
        e.Graphics.DrawLine(blackPen, 10, 24, 38, 24)
        e.Graphics.DrawString("卡号      ：" & Me.txbCardNo.Text, drawFont, drawBrush, New Rectangle(10, 30, 80, 10), drawFormat)
        e.Graphics.DrawString("条形码    ：" & Me.txbBarcode.Text, drawFont, drawBrush, New Rectangle(10, 35, 80, 10), drawFormat)
        e.Graphics.DrawString("面值      ：" & sFaceValue & " 元", drawFont, drawBrush, New Rectangle(10, 40, 80, 10), drawFormat)
        e.Graphics.DrawString("卡成本    ：" & sCost & " 元", drawFont, drawBrush, New Rectangle(10, 45, 80, 10), drawFormat)
        e.Graphics.DrawString("售价      ：" & sPrice & " 元", drawFont, drawBrush, New Rectangle(10, 50, 80, 10), drawFormat)
        e.Graphics.DrawString("交易日期  ：" & Format(CDate(sActivatedTime), "yyyy\/MM\/dd"), drawFont, drawBrush, New Rectangle(10, 55, 80, 10), drawFormat)
        e.Graphics.DrawString("交易参考号：" & sReferenceNo, drawFont, drawBrush, New Rectangle(10, 60, 80, 10), drawFormat)

        e.Graphics.DrawString("此卡已激活。激活金额：" & sFaceValue & " 元。", drawFont, drawBrush, New Rectangle(10, 90, 80, 10), drawFormat)
        e.Graphics.DrawString("客户签名：", drawFont, drawBrush, New Rectangle(105, 105, 20, 10), drawFormat)
        e.Graphics.DrawString("销售签名：", drawFont, drawBrush, New Rectangle(153, 105, 20, 10), drawFormat)

        e.Graphics.DrawLine(blackPen, 0, 116, 200, 116)

        e.Graphics.DrawString("门店：" & frmMain.dtLoginStructure.Rows.Find(frmMain.sLoginAreaID)("AreaName").ToString & "  " & _
                              "操作：" & frmMain.sLoginUserRealName & "  " & _
                              "打印时间：" & sPrintedTime, footFont, drawBrush, New Rectangle(0, 123, 200, 10), drawFormat)

        e.HasMorePages = False
    End Sub
End Class