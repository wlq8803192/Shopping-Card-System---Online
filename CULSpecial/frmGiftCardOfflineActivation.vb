Public Class frmGiftCardOfflineActivation

    Private dvCULParameter As DataView, sCardNo As String = ""

    Private Sub frmGiftCardOfflineActivation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        If sValue <> "" AndAlso Me.lblCardNoError.Text = "" AndAlso Me.txbBarcode.Text <> "" AndAlso Me.lblBarcodeError.Text = "" Then
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
        If Me.txbCardNo.Text.Trim <> "" AndAlso Me.txbBarcode.Text <> "" AndAlso Me.lblBarcodeError.Text = "" Then
            Me.btnExcute.Enabled = True
        Else
            Me.btnExcute.Enabled = False
        End If
    End Sub

    Private Sub txbBarcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbBarcode.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then
            If Me.btnExcute.Enabled Then Me.btnExcute.Select()
            e.SuppressKeyPress = True : Return
        End If
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

        If Me.txbCardNo.Text <> "" AndAlso Me.lblCardNoError.Text = "" AndAlso Me.txbBarcode.Text <> "" AndAlso Me.lblBarcodeError.Text = "" Then
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
        If Me.txbCardNo.Text <> "" AndAlso Me.lblCardNoError.Text = "" AndAlso Me.txbBarcode.Text <> "" AndAlso Me.lblBarcodeError.Text = "" Then
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

            Me.grbResult.Visible = False
            Me.lblStatus.Text = "正在到CUL系统对该卡执行激活操作……"
            Me.lblResult.Text = ""

            Me.btnCancel.Text = "取消(&C)"

            Me.txbCardNo.Select()
        Else
            Me.Cursor = Cursors.Default
            Me.grbResult.Visible = True
            Me.lblStatus.ForeColor = SystemColors.ControlText
            Me.lblStatus.Text = "正在到CUL系统对该卡执行激活操作……"
            Me.Refresh()

            Dim sMerchantNo As String = dvCULParameter.Table.Select("CULCardBin='" & sCardNo.Substring(4, 5) & "'")(0)("CULStoreCode").ToString
            Dim c4Service As C4ShoppingCardService.C4ShoppingCardService = Nothing
            Try
                c4Service = New C4ShoppingCardService.C4ShoppingCardService
                Dim offlineactivateClass As New C4ShoppingCardService.OfflineActiveClass

                offlineactivateClass.MerchantNo = sMerchantNo
                offlineactivateClass.UserID = sMerchantNo
                offlineactivateClass.CardNo = sCardNo
                offlineactivateClass.Ean = Me.txbBarcode.Text

                Dim offlineactivateData As C4ShoppingCardService.OfflineActiveDataClass = c4Service.offlineActiveC4p(offlineactivateClass)
                If offlineactivateData.Code = "00" Then
                    Dim blIsSaved As Boolean = False, sDecimalSeparator As String = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
                    Dim sActivatedTime As String = offlineactivateData.TxnDate.Insert(4, "/").Insert(7, "/") & " " & offlineactivateData.TxnTime.Insert(2, ":").Insert(5, ":"), sPosBatchNo As String = offlineactivateData.PosBatchNo, sPosRefNo As String = offlineactivateData.PosRefNo, sReferenceNo As String = offlineactivateData.RetriRefNo
                    Dim dmFaceValue As Decimal = CDec(offlineactivateData.CardPrice.Replace(".", sDecimalSeparator)), dmPrice As Decimal = CDec(offlineactivateData.SalePrice.Replace(".", sDecimalSeparator))
                    Dim DB As New DataBase
                    DB.Open()
                    If DB.IsConnected AndAlso DB.ModifyTable("Exec CULOfflineActivateGiftCard '" & sCardNo & "','" & Me.txbBarcode.Text & "','" & sActivatedTime & "','" & sReferenceNo & "'," & dmFaceValue.ToString & "," & dmPrice.ToString & ",'" & frmMain.sLoginUserRealName.Replace("'", "''") & "'," & frmMain.sSSID) > -1 Then blIsSaved = True
                    DB.Close()

                    Me.txbCardNo.ReadOnly = True
                    Me.txbCardNo.BackColor = SystemColors.Window
                    Me.txbCardNo.BackColor = SystemColors.Control
                    Me.txbBarcode.ReadOnly = True
                    Me.txbBarcode.BackColor = SystemColors.Window
                    Me.txbBarcode.BackColor = SystemColors.Control

                    Me.lblStatus.Text = "礼品卡离线激活成功" & IIf(blIsSaved, "", "（但保存操作记录到后台数据库失败！）") & "。以下是该卡的激活信息："
                    Dim sPrice As String = Format(dmPrice, "#,0.00"), sCost As String = Format(dmPrice - dmFaceValue, "#,0.00"), sFaceValue As String = Format(dmFaceValue, "#,0.00")
                    If sPrice.IndexOf(".00") > 0 AndAlso sCost.IndexOf(".00") > 0 AndAlso sFaceValue.IndexOf(".00") > 0 Then
                        sPrice = sPrice.Replace(".00", "")
                        sCost = sCost.Replace(".00", "")
                        sFaceValue = sFaceValue.Replace(".00", "")
                    End If
                    sFaceValue = StrDup(Len(sPrice) - Len(sFaceValue), " ") & sFaceValue
                    sCost = StrDup(Len(sPrice) - Len(sCost), " ") & sCost
                    Me.lblResult.Text = "激活时间：" & sActivatedTime & Chr(13) & "参 考 号：" & sReferenceNo & Chr(13) & "面    值：" & sFaceValue & " 元" & Chr(13) & "成    本：" & sCost & " 元" & Chr(13) & "售    价：" & sPrice & " 元"

                    Me.btnExcute.Text = "开始新的操作(&S)"
                    Me.btnCancel.Text = "关闭(&C)"
                    Me.btnHistory.Enabled = True
                Else
                    Me.lblStatus.ForeColor = Color.Red
                    Me.lblStatus.Text = "礼品卡离线激活失败！下面是来自CUL的失败原因提示："
                    Me.lblResult.Text = offlineactivateData.Msg
                    Me.btnExcute.Enabled = False
                End If

                offlineactivateClass = Nothing
                offlineactivateData = Nothing
            Catch ex As Exception
                Me.lblStatus.ForeColor = Color.Red
                Me.lblStatus.Text = "礼品卡离线激活失败！因为执行操作时出现错误，下面是具体的错误提示："
                Me.lblResult.Text = ex.Message
            Finally
                If c4Service IsNot Nothing Then c4Service.Dispose() : c4Service = Nothing
            End Try

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub btnHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistory.Click
        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在打开礼品卡""离线激活""历史记录窗口……"
        frmMain.statusMain.Refresh()

        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打开礼品卡""离线激活""历史记录窗口。请检查数据库连接。"
            Me.Cursor = Cursors.Default : Return
        End If

        Dim dtHistory As DataTable
        If frmMain.sLoginAreaType = "S" Then
            dtHistory = DB.GetDataTable("Select H.CardNo,H.Barcode,H.ActivatedTime,H.ReferenceNo,H.FaceValue,H.Price-H.FaceValue As CardCost,H.Price,H.OperatorName,H.OperationTime From CULGiftCardOfflineActivation As H Join UserList As U On H.OperatorID=U.UserID Where U.AreaID=" & frmMain.sLoginAreaID)
        Else
            dtHistory = DB.GetDataTable("Select H.CardNo,H.Barcode,H.ActivatedTime,H.ReferenceNo,H.FaceValue,H.Price-H.FaceValue As CardCost,H.Price,H.OperatorName,H.OperationTime From CULGiftCardOfflineActivation As H Join UserList As U On H.OperatorID=U.UserID Join AreaScope(" & frmMain.sLoginUserID & ") As S On U.AreaID=S.AreaID")
        End If
        DB.Close()

        If dtHistory Is Nothing Then
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开购物卡""紧急扣款""历史记录窗口。请联系软件开发人员。"
            Me.Cursor = Cursors.Default : Return
        End If

        frmMain.statusText.Text = "就绪。"
        If dtHistory.Rows.Count = 0 Then
            MessageBox.Show("还未发现任何礼品卡""离线激活""历史记录。    ", "没有历史记录。", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dtHistory.Dispose() : dtHistory = Nothing
            Me.btnHistory.Enabled = False
            Me.Cursor = Cursors.Default : Return
        End If

        dtHistory.DefaultView.Sort = "OperationTime Desc"
        With frmCULOperationHistory
            .Text = "礼品卡""离线激活""历史记录"
            .lblTitle.Text = "礼品卡""离线激活""历史记录："
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
                    .HeaderText = "交易激活时间"
                    .SortMode = DataGridViewColumnSortMode.Automatic
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Format = "yyyy\/MM\/dd HH:mm:ss"
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
                    .HeaderText = "操作者"
                    .SortMode = DataGridViewColumnSortMode.Automatic
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(8)
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
End Class