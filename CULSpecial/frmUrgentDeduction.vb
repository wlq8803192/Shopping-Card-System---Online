Public Class frmUrgentDeduction

    'modify code 033:
    'date;2014/7/24
    'auther:Hyron bjy 
    'remark:更改特殊操作用户登录验证方式为guid

    Private dvCULParameter As DataView, sCardNo As String = "", blSkipDeal As Boolean = False

    'modify code 033:start-------------------------------------------------------------------------
    Dim guIDClass As C4ShoppingCardService.GuIDClass
    'modify code 033:end-------------------------------------------------------------------------

    Private Sub frmUrgentDeduction_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "60" & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "92" & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "94" & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
        Next
        dvCULParameter.RowFilter = ""
        dvCULParameter.Table.AcceptChanges()
    End Sub

    Private Sub txbCardNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbCardNo.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then Me.txbAmount.Select() : Me.txbAmount.SelectAll() : e.SuppressKeyPress = True : Return
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
            ElseIf dvCULParameter.Table.Select("CULCardBin='" & sValue.Substring(4, 5) & "'").Length = 0 Then
                Me.lblCardNoError.Text = "（无权操作该卡段！）"
            Else
                sCardNo = sValue
            End If
        End If

        If sValue <> "" AndAlso Me.lblCardNoError.Text = "" AndAlso Me.txbAmount.Text <> "" AndAlso IsNumeric(Me.txbAmount.Text) AndAlso Me.txbReason.Text.Trim <> "" Then
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
        If Me.txbCardNo.Text.Trim <> "" AndAlso Me.txbAmount.Text <> "" AndAlso IsNumeric(Me.txbAmount.Text) AndAlso Me.txbReason.Text.Trim <> "" Then
            Me.btnExcute.Enabled = True
        Else
            Me.btnExcute.Enabled = False
        End If
    End Sub

    Private Sub txbAmount_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbAmount.Enter
        blSkipDeal = True
        Me.txbAmount.Text = Me.txbAmount.Text.Replace(",", "")
        blSkipDeal = False
    End Sub

    Private Sub txbAmount_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbAmount.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then Me.txbReason.Select() : Me.txbReason.SelectAll() : e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If Me.txbAmount.SelectedText = Me.txbAmount.Text Then Me.txbAmount.Text = ""
            Return
        End If
        If e.KeyCode = Keys.OemPeriod OrElse e.KeyCode = Keys.Decimal Then
            If Me.txbAmount.SelectedText.IndexOf(".") > -1 OrElse Me.txbAmount.Text.IndexOf(".") = -1 Then Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbAmount_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbAmount.Leave
        If Me.txbAmount.ReadOnly Then Return
        blSkipDeal = True
        If Me.txbAmount.Text <> "" AndAlso IsNumeric(Me.txbAmount.Text) Then Me.txbAmount.Text = Format(CDec(Me.txbAmount.Text), "#,0.00")
        blSkipDeal = False
    End Sub

    Private Sub txbAmount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbAmount.TextChanged
        If blSkipDeal Then Return

        If Me.lblCardNoError.Text = "" AndAlso Me.txbAmount.Text <> "" AndAlso IsNumeric(Me.txbAmount.Text) AndAlso Me.txbReason.Text.Trim <> "" Then
            Me.btnExcute.Enabled = True
        Else
            Me.btnExcute.Enabled = False
        End If
    End Sub

    Private Sub txbReason_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbReason.Leave
        If Me.txbReason.Text <> Me.txbReason.Text.Trim Then Me.txbReason.Text = Me.txbReason.Text.Trim
    End Sub

    Private Sub txbReason_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbReason.TextChanged
        If Me.lblCardNoError.Text = "" AndAlso Me.txbAmount.Text <> "" AndAlso IsNumeric(Me.txbAmount.Text) AndAlso Me.txbReason.Text.Trim <> "" Then
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
            Me.txbAmount.ReadOnly = False
            Me.txbAmount.BackColor = SystemColors.Window
            Me.txbAmount.Text = ""
            Me.txbReason.ReadOnly = False
            Me.txbReason.BackColor = SystemColors.Window
            Me.txbReason.Text = ""

            Me.grbResult.Visible = False
            Me.lblResult.Text = "正在到CUL系统查询该卡的状态及可用余额……"
            Me.lblError.Text = ""

            Me.btnCancel.Text = "取消(&C)"

            Me.txbCardNo.Select()
        Else
            Me.Cursor = Cursors.Default
            Me.grbResult.Visible = True
            Me.lblResult.ForeColor = SystemColors.ControlText
            Me.Refresh()

            Dim sMerchantNo As String = dvCULParameter.Table.Select("CULCardBin='" & sCardNo.Substring(4, 5) & "'")(0)("CULStoreCode").ToString
            Dim dtTemp As DataTable = ShoppingCardOperation.GetCRFCardState(sMerchantNo, sCardNo, sCardNo)
            If dtTemp.Rows(0)("CardNo").ToString = "Error" Then
                Me.lblResult.ForeColor = Color.Red
                Me.lblResult.Text = "紧急扣款失败！因为在查询卡状态时发生错误，下面是具体的错误提示："
                Me.lblError.Text = dtTemp.Rows(0)("StoreName").ToString
            ElseIf dtTemp.Rows(0)("CardState").ToString <> "已激活" OrElse dtTemp.Rows(0)("Balance").ToString = "" OrElse Not IsNumeric(dtTemp.Rows(0)("Balance").ToString) OrElse dtTemp.Rows(0)("Balance") < CDec(Me.txbAmount.Text) Then
                Me.lblResult.ForeColor = Color.Red
                Me.lblResult.Text = "紧急扣款失败！被紧急扣款的购物卡必须是已激活的卡且必须有足够的余额可供扣款！"
                Me.lblError.Text = "状态：" & dtTemp.Rows(0)("CardState").ToString & Chr(13) & Chr(13) & "余额："
                If dtTemp.Rows(0)("Balance").ToString = "" OrElse Not IsNumeric(dtTemp.Rows(0)("Balance").ToString) Then
                    Me.lblError.Text = Me.lblError.Text & "0.00 元"
                Else
                    Me.lblError.Text = Me.lblError.Text & Format(dtTemp.Rows(0)("Balance"), "#,0.00") & " 元"
                End If
                Me.btnExcute.Enabled = False
            Else
                Me.lblResult.Text = "正在到CUL系统对该卡进行扣款操作……"
                Me.Refresh()

                Dim c4Service As C4ShoppingCardService.C4ShoppingCardService = Nothing
                Try
                    c4Service = New C4ShoppingCardService.C4ShoppingCardService
                    Dim idadClass As New C4ShoppingCardService.IdadClass

                    idadClass.MerchantNo = sMerchantNo
                    idadClass.UserID = sMerchantNo
                    idadClass.CardNo = sCardNo
                    idadClass.RMerchantNo = dtTemp.Rows(0)("StoreName").ToString.Substring(0, 15)
                    idadClass.Amount = CDec(Me.txbAmount.Text)

                    'modify code 033:start-------------------------------------------------------------------------
                    guIDClass = New C4ShoppingCardService.GuIDClass
                    guIDClass.GuID = frmMain.sGuID
                    Dim codeMsg As C4ShoppingCardService.CodeMsg = c4Service.idad(idadClass, guIDClass)
                    'modify code 033:end-------------------------------------------------------------------------
                    If codeMsg.Code = "JZ" Then
                        Dim DB As New DataBase
                        DB.Open()
                        If DB.IsConnected Then
                            DB.ModifyTable("Exec CULDeductPayment '" & sCardNo & "'," & CDec(Me.txbAmount.Text).ToString & "," & (dtTemp.Rows(0)("Balance") - CDec(Me.txbAmount.Text)).ToString & ",'" & Me.txbReason.Text.Trim.Replace("'", "''") & "','" & dtTemp.Rows(0)("StoreName").ToString.Substring(0, 15) & "','" & frmMain.sLoginUserRealName.Replace("'", "''") & "'," & frmMain.sSSID)
                        End If
                        DB.Close()

                        Me.txbCardNo.ReadOnly = True
                        Me.txbCardNo.BackColor = SystemColors.Window
                        Me.txbCardNo.BackColor = SystemColors.Control
                        Me.txbAmount.ReadOnly = True
                        Me.txbAmount.BackColor = SystemColors.Window
                        Me.txbAmount.BackColor = SystemColors.Control
                        Me.txbReason.ReadOnly = True
                        Me.txbReason.BackColor = SystemColors.Window
                        Me.txbReason.BackColor = SystemColors.Control

                        Me.lblResult.Text = "紧急扣款成功。以下是该卡的扣款信息："
                        Me.lblError.Text = "  发卡门店：" & dtTemp.Rows(0)("StoreName").ToString.Substring(dtTemp.Rows(0)("StoreName").ToString.IndexOf("-") + 1) & Chr(13) & Chr(13) & "购物卡状态：" & dtTemp.Rows(0)("CardState").ToString & Chr(13) & Chr(13) & "扣款前余额：" & Format(dtTemp.Rows(0)("Balance"), "#,0.00") & " 元" & Chr(13) & Chr(13) & "扣款后余额：" & Format(dtTemp.Rows(0)("Balance") - CDec(Me.txbAmount.Text), "#,0.00") & " 元"

                        Me.btnExcute.Text = "开始新的操作(&S)"
                        Me.btnCancel.Text = "关闭(&C)"
                        Me.btnHistory.Enabled = True
                    Else
                        Me.lblResult.ForeColor = Color.Red
                        Me.lblResult.Text = "紧急扣款失败！下面是来自CUL的失败原因提示："
                        Me.lblError.Text = codeMsg.Msg
                        Me.btnExcute.Enabled = False
                    End If

                    idadClass = Nothing
                    codeMsg = Nothing
                Catch ex As Exception
                    Me.lblResult.ForeColor = Color.Red
                    Me.lblResult.Text = "紧急扣款失败！因为执行操作时出现错误，下面是具体的错误提示："
                    Me.lblError.Text = ex.Message
                Finally
                    If c4Service IsNot Nothing Then c4Service.Dispose() : c4Service = Nothing
                End Try
            End If

            dtTemp.Dispose() : dtTemp = Nothing
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub btnHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistory.Click
        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在打开购物卡""紧急扣款""历史记录窗口……"
        frmMain.statusMain.Refresh()

        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打开购物卡""紧急扣款""历史记录窗口。请检查数据库连接。"
            Me.Cursor = Cursors.Default : Return
        End If

        Dim dtHistory As DataTable
        If frmMain.sLoginAreaType = "S" Then
            dtHistory = DB.GetDataTable("Select H.CardNo,H.DeductionAmount,H.BalanceAfter,H.OperationReason,H.IssueStoreName,H.OperationStoreName,H.OperatorName,H.OperationTime From CULDeduction As H Join UserList As U On H.OperatorID=U.UserID Where U.AreaID=" & frmMain.sLoginAreaID)
        Else
            dtHistory = DB.GetDataTable("Select H.CardNo,H.DeductionAmount,H.BalanceAfter,H.OperationReason,H.IssueStoreName,H.OperationStoreName,H.OperatorName,H.OperationTime From CULDeduction As H Join UserList As U On H.OperatorID=U.UserID Join AreaScope(" & frmMain.sLoginUserID & ") As S On U.AreaID=S.AreaID")
        End If
        DB.Close()

        If dtHistory Is Nothing Then
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开购物卡""紧急扣款""历史记录窗口。请联系软件开发人员。"
            Me.Cursor = Cursors.Default : Return
        End If

        frmMain.statusText.Text = "就绪。"
        If dtHistory.Rows.Count = 0 Then
            MessageBox.Show("还未发现任何购物卡""紧急扣款""历史记录。    ", "没有历史记录。", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dtHistory.Dispose() : dtHistory = Nothing
            Me.btnHistory.Enabled = False
            Me.Cursor = Cursors.Default : Return
        End If

        dtHistory.DefaultView.Sort = "OperationTime Desc"
        With frmCULOperationHistory
            .Text = "购物卡""紧急扣款""历史记录"
            .lblTitle.Text = "购物卡""紧急扣款""历史记录："
            With .dgvList
                .DataSource = dtHistory
                With .Columns(0)
                    .HeaderText = "购物卡号"
                    .SortMode = DataGridViewColumnSortMode.Automatic
                    .Width = 125
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "扣款金额"
                    .SortMode = DataGridViewColumnSortMode.Automatic
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Format = "#,0.00"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "扣款后余额"
                    .SortMode = DataGridViewColumnSortMode.Automatic
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Format = "#,0.00"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = """紧急扣款""原因"
                    .SortMode = DataGridViewColumnSortMode.Automatic
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .MinimumWidth = .Width
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "发卡门店"
                    .SortMode = DataGridViewColumnSortMode.Automatic
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "扣款门店"
                    .SortMode = DataGridViewColumnSortMode.Automatic
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "操作者"
                    .SortMode = DataGridViewColumnSortMode.Automatic
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
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