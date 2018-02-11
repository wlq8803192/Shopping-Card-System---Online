Public Class frmGiftCardCancellation

    Private dvCULParameter As DataView, sCardNo As String = "", sPrice As String, sCost As String, sFaceValue As String, sPrintedTime As String

    Private Sub frmGiftCardCancellation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            ElseIf sValue.IndexOf("233660") <> 0 Then
                Me.lblCardNoError.Text = "（该卡不是礼品卡！）"
            ElseIf dvCULParameter.Table.Select("CULCardBin='" & sValue.Substring(4, 5) & "'").Length = 0 Then
                Me.lblCardNoError.Text = "（无权操作该卡段！）"
            Else
                sCardNo = sValue
            End If
        End If

        If sValue <> "" AndAlso Me.lblCardNoError.Text = "" AndAlso Me.txbBarcode.Text <> "" AndAlso Me.lblBarcodeError.Text = "" AndAlso Me.txbReferenceNo.Text <> "" AndAlso Me.lblReferenceNoError.Text = "" AndAlso Me.txbReason.Text.Trim <> "" Then
            Me.btnExcute.Enabled = True
        Else
            If Me.lblCardNoError.Text <> "" Then
                Me.txbCardNo.Select()
                Me.txbCardNo.SelectAll()
            End If
            Me.btnExcute.Enabled = False
        End If
    End Sub

    Private Sub txbCardNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbCardNo.TextChanged
        Me.lblCardNoError.Text = ""
        If Me.txbCardNo.Text.Trim <> "" AndAlso Me.txbBarcode.Text <> "" AndAlso Me.lblBarcodeError.Text = "" AndAlso Me.txbReferenceNo.Text <> "" AndAlso Me.lblReferenceNoError.Text = "" AndAlso Me.txbReason.Text.Trim <> "" Then
            Me.btnExcute.Enabled = True
        Else
            Me.btnExcute.Enabled = False
        End If
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
            Me.btnExcute.Enabled = True
        Else
            If Me.lblBarcodeError.Text <> "" Then
                Me.txbBarcode.Select()
                Me.txbBarcode.SelectAll()
            End If
            Me.btnExcute.Enabled = False
        End If
    End Sub

    Private Sub txbBarcode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbBarcode.TextChanged
        Me.lblBarcodeError.Text = ""
        If Me.txbCardNo.Text <> "" AndAlso Me.lblCardNoError.Text = "" AndAlso Me.txbBarcode.Text <> "" AndAlso Me.lblBarcodeError.Text = "" AndAlso Me.txbReferenceNo.Text <> "" AndAlso Me.lblReferenceNoError.Text = "" AndAlso Me.txbReason.Text.Trim <> "" Then
            Me.btnExcute.Enabled = True
        Else
            Me.btnExcute.Enabled = False
        End If
    End Sub

    Private Sub txbReferenceNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbReferenceNo.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then Me.txbReason.Select() : Me.txbReason.SelectAll() : e.SuppressKeyPress = True : Return
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
            Me.btnExcute.Enabled = True
        Else
            If Me.lblReferenceNoError.Text <> "" Then
                Me.txbReferenceNo.Select()
                Me.txbReferenceNo.SelectAll()
            End If
            Me.btnExcute.Enabled = False
        End If
    End Sub

    Private Sub txbReferenceNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbReferenceNo.TextChanged
        Me.lblReferenceNoError.Text = ""
        If Me.txbCardNo.Text <> "" AndAlso Me.lblCardNoError.Text = "" AndAlso Me.txbBarcode.Text <> "" AndAlso Me.lblBarcodeError.Text = "" AndAlso Me.txbReferenceNo.Text <> "" AndAlso Me.lblReferenceNoError.Text = "" AndAlso Me.txbReason.Text.Trim <> "" Then
            Me.btnExcute.Enabled = True
        Else
            Me.btnExcute.Enabled = False
        End If
    End Sub

    Private Sub txbReason_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbReason.KeyDown
        If e.KeyCode = Keys.Enter AndAlso Me.btnExcute.Enabled Then Me.btnExcute.Select() : e.SuppressKeyPress = True
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
            Me.btnExcute.Enabled = True
        Else
            Me.btnExcute.Enabled = False
        End If
    End Sub

    Private Sub btnExcute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcute.Click
        If Me.btnExcute.Text.IndexOf("开始") > -1 Then
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
            Me.txbReason.ReadOnly = False
            Me.txbReason.BackColor = SystemColors.Window
            Me.txbReason.Text = ""

            Me.grbResult.Visible = False
            Me.lblStatus.Text = "正在到CUL系统对该卡执行激活撤销……"
            Me.lblResult.Text = ""

            Me.pnlPrinting.Visible = False
            Me.btnCancel.Text = "取消(&C)"

            Me.txbCardNo.Select()
        Else
            Me.Cursor = Cursors.Default
            Me.grbResult.Visible = True
            Me.lblStatus.ForeColor = SystemColors.ControlText
            Me.lblStatus.Text = "正在到CUL系统对该卡执行激活撤销……"
            Me.Refresh()

            Dim sMerchantNo As String = dvCULParameter.Table.Select("CULCardBin='" & sCardNo.Substring(4, 5) & "'")(0)("CULStoreCode").ToString
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
                inactiveClass.OpeType = "INACTIVE"

                Dim inactiveData As C4ShoppingCardService.InactiveDataClass = c4Service.inactive(inactiveClass)
                If inactiveData.Code = "00" Then
                    Dim blIsSaved As Boolean = False, sDecimalSeparator As String = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
                    Dim dmFaceValue As Decimal = CDec(inactiveData.CardPrice.Replace(".", sDecimalSeparator)), dmPrice As Decimal = CDec(inactiveData.SaleAmount.Replace(".", sDecimalSeparator))
                    Dim DB As New DataBase
                    DB.Open()
                    If DB.IsConnected AndAlso DB.ModifyTable("Exec CULCancelGiftCardActivation '" & sCardNo & "','" & Me.txbBarcode.Text & "','" & Format(Me.dtpActivatedDate.Value, "yyyy\/MM\/dd") & "','" & Me.txbReferenceNo.Text & "'," & dmFaceValue.ToString & "," & dmPrice.ToString & ",'" & Me.txbReason.Text.Trim.Replace("'", "''") & "','" & frmMain.sLoginUserRealName.Replace("'", "''") & "'," & frmMain.sSSID) > -1 Then blIsSaved = True
                    DB.Close()

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
                    Me.txbReason.ReadOnly = True
                    Me.txbReason.BackColor = SystemColors.Window
                    Me.txbReason.BackColor = SystemColors.Control

                    Me.lblStatus.Text = "礼品卡激活撤销成功" & IIf(blIsSaved, "", "（但保存操作记录到后台数据库失败！）") & "。以下是该卡的价格信息："
                    sPrice = Format(dmPrice, "#,0.00") : sCost = Format(dmPrice - dmFaceValue, "#,0.00") : sFaceValue = Format(dmFaceValue, "#,0.00")
                    If sPrice.IndexOf(".00") > 0 AndAlso sCost.IndexOf(".00") > 0 AndAlso sFaceValue.IndexOf(".00") > 0 Then
                        sPrice = sPrice.Replace(".00", "")
                        sCost = sCost.Replace(".00", "")
                        sFaceValue = sFaceValue.Replace(".00", "")
                    End If
                    sFaceValue = StrDup(Len(sPrice) - Len(sFaceValue), " ") & sFaceValue
                    sCost = StrDup(Len(sPrice) - Len(sCost), " ") & sCost
                    Me.lblResult.Text = "面值：" & sFaceValue & " 元" & Chr(13) & "成本：" & sCost & " 元" & Chr(13) & "售价：" & sPrice & " 元"

                    Me.btnExcute.Text = "开始新的操作(&S)"
                    Me.pnlPrinting.Visible = True
                    Me.btnCancel.Text = "关闭(&C)"
                    Me.btnHistory.Enabled = True
                Else
                    Me.lblStatus.ForeColor = Color.Red
                    Me.lblStatus.Text = "礼品卡激活撤销失败！下面是来自CUL的失败原因提示："
                    Me.lblResult.Text = inactiveData.Msg
                    Me.btnExcute.Enabled = False
                End If

                inactiveClass = Nothing
                inactiveData = Nothing
            Catch ex As Exception
                Me.lblStatus.ForeColor = Color.Red
                Me.lblStatus.Text = "礼品卡激活撤销失败！因为执行操作时出现错误，下面是具体的错误提示："
                Me.lblResult.Text = ex.Message
            Finally
                If c4Service IsNot Nothing Then c4Service.Dispose() : c4Service = Nothing
            End Try

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

            CancellationForm.Print()
            CancellationForm.Dispose()

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

        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打开礼品卡""激活撤销""历史记录窗口。请检查数据库连接。"
            Me.Cursor = Cursors.Default : Return
        End If

        Dim dtHistory As DataTable
        If frmMain.sLoginAreaType = "S" Then
            dtHistory = DB.GetDataTable("Select H.CardNo,H.Barcode,H.ActivatedDate,H.ReferenceNo,H.FaceValue,H.Price-H.FaceValue As CardCost,H.Price,H.OperationReason,H.OperatorName,H.OperationTime From CULGiftCardCancellation As H Join UserList As U On H.OperatorID=U.UserID Where U.AreaID=" & frmMain.sLoginAreaID)
        Else
            dtHistory = DB.GetDataTable("Select H.CardNo,H.Barcode,H.ActivatedDate,H.ReferenceNo,H.FaceValue,H.Price-H.FaceValue As CardCost,H.Price,H.OperationReason,H.OperatorName,H.OperationTime From CULGiftCardCancellation As H Join UserList As U On H.OperatorID=U.UserID Join AreaScope(" & frmMain.sLoginUserID & ") As S On U.AreaID=S.AreaID")
        End If
        DB.Close()

        If dtHistory Is Nothing Then
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开购物卡""紧急扣款""历史记录窗口。请联系软件开发人员。"
            Me.Cursor = Cursors.Default : Return
        End If

        frmMain.statusText.Text = "就绪。"
        If dtHistory.Rows.Count = 0 Then
            MessageBox.Show("还未发现任何礼品卡""激活撤销""历史记录。    ", "没有历史记录。", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dtHistory.Dispose() : dtHistory = Nothing
            Me.btnHistory.Enabled = False
            Me.Cursor = Cursors.Default : Return
        End If

        dtHistory.DefaultView.Sort = "OperationTime Desc"
        With frmCULOperationHistory
            .Text = "礼品卡""激活撤销""历史记录"
            .lblTitle.Text = "礼品卡""激活撤销""历史记录："
            With .dgvList
                .DataSource = dtHistory
                With .Columns(0)
                    .HeaderText = "礼品卡号"
                    .SortMode = DataGridViewColumnSortMode.Automatic
                    .Width = 125
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "商品条形码"
                    .SortMode = DataGridViewColumnSortMode.Automatic
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "交易激活日期"
                    .SortMode = DataGridViewColumnSortMode.Automatic
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Format = "yyyy\/MM\/dd"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "交易参考号"
                    .SortMode = DataGridViewColumnSortMode.Automatic
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "卡面值"
                    .SortMode = DataGridViewColumnSortMode.Automatic
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Format = "#,0.00"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "卡成本"
                    .SortMode = DataGridViewColumnSortMode.Automatic
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Format = "#,0.00"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "收款金额"
                    .SortMode = DataGridViewColumnSortMode.Automatic
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Format = "#,0.00"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = """激活撤销""原因"
                    .SortMode = DataGridViewColumnSortMode.Automatic
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .MinimumWidth = .Width
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(8)
                    .HeaderText = "操作者"
                    .SortMode = DataGridViewColumnSortMode.Automatic
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(9)
                    .HeaderText = "操作时间"
                    .SortMode = DataGridViewColumnSortMode.Automatic
                    .DefaultCellStyle.Format = "yyyy\/MM\/dd HH:mm:ss"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With

                For bColumn As Byte = 0 To dtHistory.Columns.Count - 1
                    .Columns(bColumn).Name = dtHistory.Columns(bColumn).ColumnName
                Next
            End With
            .ShowDialog()
            .Dispose()
        End With

        dtHistory.Dispose() : dtHistory = Nothing
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
        e.Graphics.DrawString("卡成本    ：" & sCost & " 元", drawFont, drawBrush, New Rectangle(10, 45, 80, 10), drawFormat)
        e.Graphics.DrawString("售价      ：" & sPrice & " 元", drawFont, drawBrush, New Rectangle(10, 50, 80, 10), drawFormat)
        e.Graphics.DrawString("交易日期  ：" & Format(Me.dtpActivatedDate.Value, "yyyy\/MM\/dd"), drawFont, drawBrush, New Rectangle(10, 55, 80, 10), drawFormat)
        e.Graphics.DrawString("交易参考号：" & Me.txbReferenceNo.Text, drawFont, drawBrush, New Rectangle(10, 60, 80, 10), drawFormat)
        e.Graphics.DrawString("撤销原因  ：" & Me.txbReason.Text, drawFont, drawBrush, New Rectangle(10, 65, 180, 10), drawFormat)

        e.Graphics.DrawString("此卡已撤销（余额为零）。应退金额：" & sPrice & " 元。", drawFont, drawBrush, New Rectangle(10, 90, 80, 10), drawFormat)
        e.Graphics.DrawString("客户签名：", drawFont, drawBrush, New Rectangle(105, 105, 20, 10), drawFormat)
        e.Graphics.DrawString("销售签名：", drawFont, drawBrush, New Rectangle(153, 105, 20, 10), drawFormat)

        e.Graphics.DrawLine(blackPen, 0, 116, 200, 116)

        e.Graphics.DrawString("门店：" & frmMain.dtLoginStructure.Rows.Find(frmMain.sLoginAreaID)("AreaName").ToString & "  " & _
                              "操作：" & frmMain.sLoginUserRealName & "  " & _
                              "打印时间：" & sPrintedTime, footFont, drawBrush, New Rectangle(0, 123, 200, 10), drawFormat)

        e.HasMorePages = False
    End Sub
End Class