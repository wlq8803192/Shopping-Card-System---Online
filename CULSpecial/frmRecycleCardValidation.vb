Public Class frmRecycleCardValidation

    'modify code 033:
    'date;2014/7/24
    'auther:Hyron bjy 
    'remark:更改特殊操作用户登录验证方式为guid

    'modify code 047:
    'date;2014/5/11
    'auther:Hyron qm 
    'remark:实名制卡特殊操作

    'modify code 063:
    'date;2016/07/18
    'auther:QP
    'remark:修正实名制卡解除绑定关系问题

    Private dvCULParameter As DataView, dtList As DataTable, currentRow As DataRow

    'modify code 033:start-------------------------------------------------------------------------
    Dim guIDClass As C4ShoppingCardService.GuIDClass
    'modify code 033:end-------------------------------------------------------------------------

    Private Sub frmRecycleCardValidation_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub frmRecycleCardValidation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打开购物卡回收确认窗口。请检查数据库连接。"
            Me.Close() : Return
        End If

        Try
            dtList = DB.GetDataTable("Exec GetCULRecycleValidating " & frmMain.sLoginUserID).Copy
        Catch
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开购物卡回收确认窗口。请联系软件开发人员。"
            DB.Close() : Me.Close() : Return
        End Try
        DB.Close()

        frmMain.statusText.Text = "就绪。"

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

            'modify code 050:start-------------------------------------------------------------------------
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), frmMain.signCardBin & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
            'modify code 050:end-------------------------------------------------------------------------
        Next
        dvCULParameter.RowFilter = ""
        dvCULParameter.Table.AcceptChanges()

        dtList.DefaultView.Sort = "RequestedTime"
        With Me.dgvList
            .DataSource = dtList
            Dim newColumn As New DataGridViewCheckBoxColumn
            newColumn.DataPropertyName = "Selected"
            .Columns.RemoveAt(0)
            .Columns.Insert(0, newColumn)
            With .Columns(0)
                .HeaderText = "选择"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 40
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(1)
                .HeaderText = "批号"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Width = 40
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(2)
                .HeaderText = "行号"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Width = 40
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(3)
                .HeaderText = "卡号"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 125
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(4)
                .HeaderText = "卡状态"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 82
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(5)
                .HeaderText = "余额"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(6)
                .HeaderText = "申请门店"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(7)
                .HeaderText = "申请者"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(8)
                .HeaderText = "申请时间"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Format = "yyyy\/MM\/dd HH:mm:ss"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(9)
                .HeaderText = "处理状态"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 82
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .MinimumWidth = .Width
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(10)
                .HeaderText = "失败原因"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .MinimumWidth = .Width
                .Resizable = DataGridViewTriState.False
                .Visible = False
            End With
            .Columns(11).Visible = False

            For bColumn As Byte = 0 To dtList.Columns.Count - 1
                .Columns(bColumn).Name = dtList.Columns(bColumn).ColumnName
            Next
        End With

        If dtList.Rows.Count = 0 Then
            Me.lblNothing.Visible = True
            Me.chbSelectAll.Enabled = False
            Me.btnHistory.Select()
            Me.btnCancel.Text = "关闭(&C)"
        Else
            Dim iGridWidth As Integer = 0, iMaxGridHeight As Integer = 0, iAvailableGridHeight As Integer = 0
            For Each column As DataGridViewColumn In Me.dgvList.Columns
                If column.Visible Then iGridWidth += column.Width
            Next
            iGridWidth += IIf(ToolStripManager.VisualStylesEnabled, 2, 4)

            Me.lblSummary.Text = "（共 " & Format(Me.dgvList.RowCount, "#,0") & " 张 " & Format(dtList.Compute("Sum(Balance)", ""), "#,0.00").Replace(".00", "") & " 元）"

            iMaxGridHeight = (IIf(Me.dgvList.RowCount < 7, 7, Me.dgvList.RowCount) + 1) * 24 + IIf(ToolStripManager.VisualStylesEnabled, 0, 2)
            If My.Computer.Screen.WorkingArea.Width < iGridWidth + 33 Then
                Me.Width = My.Computer.Screen.WorkingArea.Width
                iMaxGridHeight += 17
            Else
                Me.Width = iGridWidth + 33
            End If
            With Me.dgvList.Columns("RequestedStoreName")
                .MinimumWidth = .Width
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            Me.dgvList.Columns("OperationState").Visible = False

            iAvailableGridHeight = My.Computer.Screen.WorkingArea.Height - 116
            If iMaxGridHeight < iAvailableGridHeight Then
                Me.Height = iMaxGridHeight + 116
            Else
                If My.Computer.Screen.WorkingArea.Width < iGridWidth + 30 Then iAvailableGridHeight -= 17
                iAvailableGridHeight = Int(iAvailableGridHeight / 24) * 24
                If My.Computer.Screen.WorkingArea.Width < iGridWidth + 30 Then iAvailableGridHeight += 17
                Me.Height = iAvailableGridHeight + 116
            End If
            If Me.dgvList.RowCount > Me.dgvList.DisplayedRowCount(False) Then Me.Width += 20

            Me.Location = New Point(Int((My.Computer.Screen.WorkingArea.Width - Me.Width) / 2), Int((My.Computer.Screen.WorkingArea.Height - Me.Height) / 2))

            Me.dgvList.Select()
            Me.dgvList.Rows(0).Selected = True
        End If
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub dgvList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvList.CellContentClick
        If e.ColumnIndex <> 0 OrElse e.RowIndex = -1 Then Return
        If currentRow("Finished") Then
            frmMain.statusText.Text = "该回收申请记录已经被处理过，不可撤销！"
        Else
            currentRow("Selected") = Not currentRow("Selected")

            Dim iSelected As Integer = dtList.Select("Selected=1").Length
            Me.btnExcute.Enabled = (iSelected > 0)
            If iSelected = 0 Then
                Me.chbSelectAll.CheckState = CheckState.Unchecked
            ElseIf iSelected < dtList.Rows.Count Then
                Me.chbSelectAll.CheckState = CheckState.Indeterminate
            Else
                Me.chbSelectAll.CheckState = CheckState.Checked
            End If
            frmMain.statusText.Text = "就绪。"
        End If
    End Sub

    Private Sub dgvList_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvList.CellFormatting
        If Me.dgvList("Finished", e.RowIndex).Value Then e.CellStyle.BackColor = SystemColors.Control
        If Me.dgvList.Columns(e.ColumnIndex).Name = "OperationState" OrElse Me.dgvList.Columns(e.ColumnIndex).Name = "OperationReason" Then
            Select Case Me.dgvList("OperationState", e.RowIndex).Value.ToString
                Case "回收失败！"
                    e.CellStyle.ForeColor = Color.Red
                    e.CellStyle.SelectionForeColor = Color.Red
                Case "CUL故障！"
                    e.CellStyle.ForeColor = Color.Maroon
                    e.CellStyle.SelectionForeColor = Color.Yellow
            End Select
        End If
    End Sub

    Private Sub dgvList_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvList.Leave
        If Me.dgvList.CurrentCell IsNot Nothing Then Me.dgvList.CurrentCell.Selected = False
        If Me.dgvList.CurrentRow IsNot Nothing Then Me.dgvList.CurrentRow.Selected = False
    End Sub

    Private Sub dgvList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvList.SelectionChanged
        If Me.dgvList.CurrentRow IsNot Nothing Then
            currentRow = dtList.Select("BatchID=" & Me.dgvList("BatchID", Me.dgvList.CurrentRow.Index).Value.ToString & " And RowID=" & Me.dgvList("RowID", Me.dgvList.CurrentRow.Index).Value.ToString)(0)
        Else
            currentRow = Nothing
        End If
    End Sub

    Private Sub chbSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbSelectAll.Click
        If Me.chbSelectAll.CheckState = CheckState.Checked Then
            For Each dr As DataRow In dtList.Select("Finished=0")
                dr("Selected") = 0
            Next
        Else
            For Each dr As DataRow In dtList.Select("Finished=0")
                dr("Selected") = 1
            Next
        End If
        Me.btnExcute.Enabled = (dtList.Select("Selected=1 And Finished=0").Length > 0)
        Dim iSelected As Integer = dtList.Select("Selected=1").Length
        If iSelected = 0 Then
            Me.chbSelectAll.CheckState = CheckState.Unchecked
        ElseIf iSelected < dtList.Rows.Count Then
            Me.chbSelectAll.CheckState = CheckState.Indeterminate
        Else
            Me.chbSelectAll.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub btnExcute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcute.Click
        Dim iCard As Integer = 0, iCards As Integer = dtList.Compute("Count(RowID)", "Selected=1 And Finished=0"), dmAmount As Decimal = dtList.Compute("Sum(Balance)", "Selected=1 And Finished=0")
        If MessageBox.Show("您本次选择要提交到CUL执行回收操作的记录汇总信息如下：    " & Chr(13) & Chr(13) & _
                           "即将回收的卡数： " & Format(iCards, "#,0") & " 张    " & Chr(13) & Chr(13) & _
                           "涉及的回收金额： " & Format(dmAmount, "#,0.00").Replace(".00", "") & " 元    " & Chr(13) & Chr(13) & _
                           "请注意：回收操作一旦提交，便不可撤消！    " & Chr(13) & Chr(13) & _
                           "如果您确认上面信息正确无误，请按""确定""按钮继续。    ", _
                           "请确认执行回收操作：", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Cancel Then Return
        Me.Refresh()

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在提交回收申请记录到CUL执行回收操作……"

        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法进行回收操作。请检查数据库连接。"
            Me.Cursor = Cursors.Default : Return
        End If

        Dim c4Service As C4ShoppingCardService.C4ShoppingCardService = Nothing, irecClass As C4ShoppingCardService.IrecClass = Nothing, codeMsg As C4ShoppingCardService.CodeMsg = Nothing
        Try
            c4Service = New C4ShoppingCardService.C4ShoppingCardService()
            irecClass = New C4ShoppingCardService.IrecClass
        Catch ex As Exception
            MessageBox.Show("因为CUL系统故障，无法进行回收操作！ 下面是CUL系统的内部错误提示：    " & Chr(13) & Chr(13) & ex.Message & Space(4), "出现CUL系统故障！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "因为CUL系统故障，无法进行回收操作！"
            If c4Service IsNot Nothing Then c4Service.Dispose() : c4Service = Nothing
            DB.Close() : Me.Cursor = Cursors.Default : Return
        End Try

        frmMain.statusRate.Visible = True
        frmMain.statusRate.Text = ""
        frmMain.statusProgress.Visible = True
        frmMain.statusProgress.Value = 0
        frmMain.statusMain.Refresh()

        Dim sMerchantNo As String, sFailureReason As String, sSQL As String, iSucessfully As Integer = 0
        Me.dgvList.Columns("OperationState").Visible = True
        For iRow As Integer = 0 To Me.dgvList.RowCount - 1
            If Me.dgvList("Selected", iRow).Value AndAlso Not Me.dgvList("Finished", iRow).Value Then
                sFailureReason = ""
                Me.dgvList("OperationState", iRow).Selected = True
                Me.dgvList.Rows(iRow).Selected = False
                Me.dgvList.Rows(iRow).Selected = True

                iCard += 1
                frmMain.statusText.Text = "正在提交回收申请记录到CUL执行回收操作……"
                frmMain.statusRate.Text = "(" & iCard.ToString & "/" & iCards.ToString & ")"
                frmMain.statusProgress.Value = Int((iCard / iCards) * 100)
                frmMain.statusMain.Refresh()

                currentRow("OperationState") = "正在回收……"
                currentRow("OperationReason") = DBNull.Value
                Me.dgvList.FirstDisplayedScrollingColumnIndex = Me.dgvList.Columns("OperationState").Index
                Me.dgvList.Refresh()

                sMerchantNo = dvCULParameter.Table.Select("CULCardBin='" & currentRow("CardNo").ToString.Substring(4, 5) & "'")(0)("CULStoreCode").ToString
                Try
                    irecClass.MerchantNo = sMerchantNo
                    irecClass.UserID = sMerchantNo
                    irecClass.CardNoFrom = currentRow("CardNo").ToString
                    irecClass.CardNoTo = currentRow("CardNo").ToString
                    'modify code 033:start-------------------------------------------------------------------------
                    guIDClass = New C4ShoppingCardService.GuIDClass
                    guIDClass.GuID = frmMain.sGuID
                    codeMsg = c4Service.irec(irecClass, guIDClass)
                    'modify code 033:end-------------------------------------------------------------------------

                    If codeMsg.Code = "MZ" Then
                        currentRow("OperationState") = "回收成功。"
                        iSucessfully += 1
                        'modify code 047:start-------------------------------------------------------------------------
                        If DB.ModifyTable("update SignCardListNew set CardType='非实名制卡' where CardNo='" & currentRow("CardNo").ToString & "'", False) = -1 Then
                            MessageBox.Show(currentRow("CardNo").ToString & vbCrLf & "实名制卡回收已成功，但系统在保存结果时出错。    " & Chr(13) & Chr(13) & "请不要对该卡做重复确认，请及时通知National IT。    ", "回收卡成功但保存结果失败！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            'modify code 063:start-------------------------------------------------------------------------
                            DB.ModifyTable("delete SignCardListCount where CardNo = '" & currentRow("CardNo").ToString & "'")
                            'modify code 063:end-------------------------------------------------------------------------
                        End If
                        'modify code 047:end-------------------------------------------------------------------------
                    Else
                        sFailureReason = codeMsg.Msg
                        currentRow("OperationState") = "回收失败！"
                        currentRow("OperationReason") = sFailureReason
                        Me.dgvList.Columns("OperationReason").Visible = True
                        Me.dgvList.Columns("OperationReason").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        Me.dgvList.Columns("OperationReason").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        Me.dgvList.FirstDisplayedScrollingColumnIndex = Me.dgvList.Columns("OperationReason").Index
                        Me.dgvList.Refresh()
                    End If

                    sSQL = "Exec CULRecycleCardValidate @BatchID=" & currentRow("BatchID").ToString & ",@RowID=" & currentRow("RowID").ToString & ",@CardNo='" & currentRow("CardNo").ToString & "',"
                    If sFailureReason <> "" Then sSQL = sSQL & "@OperationState=1,@OperationReason='" & sFailureReason.Replace("'", "''") & "',"
                    sSQL = sSQL & "@AuditorName='" & frmMain.sLoginUserRealName.Replace("'", "''") & "',@SSID=" & frmMain.sSSID

                    DB.ModifyTable(sSQL)
                    currentRow("Finished") = 1
                    currentRow.AcceptChanges()
                Catch ex As Exception
                    If currentRow("OperationState").ToString = "正在回收……" Then
                        For iAfter As Integer = iRow To Me.dgvList.RowCount - 2
                            currentRow("OperationState") = "CUL故障！"
                            currentRow("OperationReason") = ex.Message
                        Next
                        Me.dgvList.Columns("OperationReason").Visible = True
                        Me.dgvList.Columns("OperationReason").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        Me.dgvList.Columns("OperationReason").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        Me.dgvList.FirstDisplayedScrollingColumnIndex = Me.dgvList.Columns("OperationReason").Index
                        Exit For
                    Else
                        currentRow("Finished") = 1
                        currentRow.AcceptChanges()
                    End If
                End Try
            End If
        Next

        c4Service.Dispose() : c4Service = Nothing
        DB.Close()

        frmMain.statusText.Text = "就绪。"
        frmMain.statusRate.Text = ""
        frmMain.statusRate.Visible = False
        frmMain.statusProgress.Value = 0
        frmMain.statusProgress.Visible = False

        Me.btnExcute.Enabled = (dtList.Select("Selected=1 And Finished=0").Length > 0)
        If Me.btnExcute.Enabled Then
            frmMain.statusText.Text = "提交回收申请记录到CUL执行回收操作时出现故障，请检查故障原因。"
            MessageBox.Show("提交回收申请记录到CUL执行回收操作时出现故障，请检查故障原因。    ", "回收时出现故障！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf iSucessfully = 0 Then
            frmMain.statusText.Text = "已经将回收记录提交到CUL系统，但没有卡换成功！"
            MessageBox.Show("已经将回收记录提交到CUL系统，但没有卡换成功！    ", "回收失败！", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf iSucessfully < iCards Then
            frmMain.statusText.Text = "已经将回收记录提交到CUL系统，但部分成功，部分卡失败！"
            MessageBox.Show("已经将回收记录提交到CUL系统，但部分成功，部分卡失败！    ", "回收部分失败！", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            frmMain.statusText.Text = "已经将回收记录提交到CUL系统，并且" & IIf(iSucessfully = 1, "", "全部") & "回收成功。"
            MessageBox.Show("已经将回收记录提交到CUL系统，并且" & IIf(iSucessfully = 1, "", "全部") & "回收成功。    ", "回收成功。", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistory.Click
        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在打开购物卡""回收""历史记录窗口……"
        frmMain.statusMain.Refresh()

        frmRecycleCardHistory.blBalanceVisible = True
        If frmRecycleCardHistory.ShowDialog() = Windows.Forms.DialogResult.Ignore Then Me.btnHistory.Enabled = False
        frmRecycleCardHistory.Dispose()

        Me.Cursor = Cursors.Default
    End Sub
End Class