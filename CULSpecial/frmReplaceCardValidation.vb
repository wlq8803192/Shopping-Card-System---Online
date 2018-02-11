Public Class frmReplaceCardValidation

    'modify code 020:
    'date;2014/5/9
    'auther:Hyron bjy 
    'remark:商银通卡号位数增加到20位

    'modify code 021:
    'date;2014/5/15
    'auther:Hyron bjy 
    'remark:培训模式下，换卡时，不检查卡Bin，使用固定的测试MerchantNo和UserID

    'modify code 033:
    'date;2014/7/24
    'auther:Hyron bjy 
    'remark:更改特殊操作用户登录验证方式为guid

    'modify code 036:
    'date;2014/8/26
    'auther:Hyron bjy 
    'remark:增加三种换卡功能

    'modify code 045:
    'date;2015/3/17
    'auther:Hyron zyx 
    'remark:86条码卡换84磁条卡，86条码卡换60磁条卡

    'modify code 047:
    'date;2014/5/11
    'auther:Hyron qm 
    'remark:实名制卡特殊操作

    'modify code 050:
    'date;2015/11/1
    'auther:Hyron wzh 
    'remark:增加旧实名制卡和新实名制卡操作

    'modify code 051:
    'date;2016/01/08
    'auther:BJY 
    'remark:增加通卖卡65888

    'modify code 063:
    'date;2016/07/18
    'auther:QP
    'remark:修正实名制卡解除绑定关系问题

    Private dvCULParameter As DataView, dtList As DataTable, currentRow As DataRow

    'modify code 021:start-------------------------------------------------------------------------
    Private clsForCulTest As New ForCulTest
    'modify code 021:end-------------------------------------------------------------------------

    'modify code 033:start-------------------------------------------------------------------------
    Dim guIDClass As C4ShoppingCardService.GuIDClass
    'modify code 033:end-------------------------------------------------------------------------

    Private Sub frmReplaceCardValidation_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub frmReplaceCardValidation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打开购物卡换卡确认窗口。请检查数据库连接。"
            Me.Close() : Return
        End If

        Try
            dtList = DB.GetDataTable("Exec GetCULReplaceValidating " & frmMain.sLoginUserID).Copy
        Catch
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开购物卡换卡确认窗口。请联系软件开发人员。"
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
        For Each drCUL As DataRow In frmMain.dtLoginStructure.Select("ParentAreaID=33") '青岛市
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "71866", drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "72866", drCUL("CULStoreCode")).EndEdit()
        Next
        For Each drCUL As DataRow In frmMain.dtLoginStructure.Select("ParentAreaID=52") '郑州市
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "35601", drCUL("CULStoreCode")).EndEdit()
        Next
        For Each drCUL As DataRow In frmMain.dtLoginStructure.Select("ParentAreaID=39") '长沙市
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "73608", drCUL("CULStoreCode")).EndEdit()
        Next
        For Each drCUL As DataRow In frmMain.dtLoginStructure.Select("ParentAreaID=59") '海口市
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "11020", drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "11100", drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "11200", drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "11300", drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "11500", drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "11066", drCUL("CULStoreCode")).EndEdit()
        Next
        For Each drCUL As DataRow In dvCULParameter.Table.Select("CULCardBin Like '84%'")
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "60" & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "92" & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "94" & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
            'modify code 045:start-------------------------------------------------------------------------
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "86" & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
            'modify code 045:end-------------------------------------------------------------------------
            'modify code 050:start-------------------------------------------------------------------------
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), frmMain.signCardBin & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
            'modify code 050:end-------------------------------------------------------------------------
        Next
        dvCULParameter.RowFilter = ""
        dvCULParameter.Table.AcceptChanges()

        dtList.PrimaryKey = New DataColumn() {dtList.Columns("OperationID")}
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
                .HeaderText = "原卡号"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                'modify code 020:start-------------------------------------------------------------------------
                '.Width = 125
                .Width = 145
                'modify code 020:end-------------------------------------------------------------------------
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(2)
                .HeaderText = "原卡类型"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 60
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(3)
                .HeaderText = "原卡余额"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(4)
                .HeaderText = "发卡门店"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(5)
                .HeaderText = "新卡号"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 125
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(6)
                .HeaderText = "新卡面值"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(7)
                .HeaderText = "申请原因"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(8)
                .HeaderText = "申请门店"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .MinimumWidth = .Width
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(9)
                .HeaderText = "申请者"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(10)
                .HeaderText = "申请时间"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Format = "yyyy\/MM\/dd HH:mm:ss"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(11)
                .HeaderText = "处理状态"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 82
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .MinimumWidth = .Width
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(12)
                .HeaderText = "失败原因"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .MinimumWidth = .Width
                .Resizable = DataGridViewTriState.False
                .Visible = False
            End With
            .Columns(13).Visible = False
            .Columns(14).Visible = False
            .Columns(15).Visible = False

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

            iMaxGridHeight = (IIf(Me.dgvList.RowCount < 7, 7, Me.dgvList.RowCount) + 1) * 24 + IIf(ToolStripManager.VisualStylesEnabled, 0, 2)
            If My.Computer.Screen.WorkingArea.Width < iGridWidth + 33 Then
                Me.Width = My.Computer.Screen.WorkingArea.Width
                iMaxGridHeight += 17
            Else
                Me.Width = iGridWidth + 33
            End If
            With Me.dgvList.Columns("RequestedReason")
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
            frmMain.statusText.Text = "该换卡申请记录已经被处理过，不可撤销！"
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
        If Me.dgvList.Columns(e.ColumnIndex).Name = "SourceCardType" AndAlso e.Value.ToString <> "家乐福卡" Then
            e.CellStyle.ForeColor = Color.Blue
            e.CellStyle.SelectionForeColor = Color.Yellow
        ElseIf Me.dgvList.Columns(e.ColumnIndex).Name = "OperationState" OrElse Me.dgvList.Columns(e.ColumnIndex).Name = "OperationReason" Then
            Select Case Me.dgvList("OperationState", e.RowIndex).Value.ToString
                Case "换卡失败！"
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
            currentRow = dtList.Rows.Find(Me.dgvList("OperationID", Me.dgvList.CurrentRow.Index).Value.ToString)
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
        Dim dvTemp As DataView = dtList.Copy.DefaultView
        dvTemp.RowFilter = "Selected=1 And Finished=0"
        dvTemp = dvTemp.ToTable(False, "SourceCardNo", "TargetBalance").DefaultView
        Dim iCard As Integer = 0, iCards As Integer = dvTemp.ToTable(True, "SourceCardNo").Rows.Count, dmAmount As Decimal = dvTemp.Table.Compute("Sum(TargetBalance)", "")
        dvTemp.Dispose() : dvTemp = Nothing

        If MessageBox.Show("您本次选择要提交到CUL执行换卡操作的记录汇总信息如下：    " & Chr(13) & Chr(13) & _
                           "即将换卡的卡数： " & Format(iCards, "#,0") & " 张    " & Chr(13) & Chr(13) & _
                           "涉及的换卡金额： " & Format(dmAmount, "#,0.00").Replace(".00", "") & " 元    " & Chr(13) & Chr(13) & _
                           "请注意：换卡操作一旦提交，便不可撤消！    " & Chr(13) & Chr(13) & _
                           "如果您确认上面信息正确无误，请按""确定""按钮继续。    ", _
                           "请确认执行换卡操作：", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Cancel Then Return
        Me.Refresh()
        iCards = dtList.Compute("Count(OperationID)", "Selected=1 And Finished=0")

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在提交换卡申请记录到CUL执行换卡操作……"

        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法进行换卡操作。请检查数据库连接。"
            Me.Cursor = Cursors.Default : Return
        End If

        Dim c4Service As C4ShoppingCardService.C4ShoppingCardService = Nothing, irecClass As C4ShoppingCardService.IrecClass = Nothing, islvClass As C4ShoppingCardService.IslvClass = Nothing, IcDestoryClass As C4ShoppingCardService.IcDestoryClass = Nothing, codeMsg As C4ShoppingCardService.CodeMsg = Nothing
        'modify code 036:start-------------------------------------------------------------------------
        Dim DestoryClass As C4ShoppingCardService.DestoryClass = Nothing
        'modify code 036:end-------------------------------------------------------------------------
        'modify code 045:start-------------------------------------------------------------------------
        Dim vidvvClass As C4ShoppingCardService.VIdvvClass = Nothing
        Dim vstatusClass As C4ShoppingCardService.VStatusClass = Nothing
        Dim vcodeMsg As C4ShoppingCardService.VCodeMsg = Nothing
        'modify code 045:end-------------------------------------------------------------------------
        Try
            c4Service = New C4ShoppingCardService.C4ShoppingCardService()
            irecClass = New C4ShoppingCardService.IrecClass()
            islvClass = New C4ShoppingCardService.IslvClass()
            IcDestoryClass = New C4ShoppingCardService.IcDestoryClass()
            'modify code 036:start-------------------------------------------------------------------------
            DestoryClass = New C4ShoppingCardService.DestoryClass()
            'modify code 036:end-------------------------------------------------------------------------
            'modify code 045:start-------------------------------------------------------------------------
            vidvvClass = New C4ShoppingCardService.VIdvvClass()
            vstatusClass = New C4ShoppingCardService.VStatusClass()
            'modify code 045:end-------------------------------------------------------------------------
        Catch ex As Exception
            MessageBox.Show("因为CUL系统故障，无法进行换卡操作！ 下面是CUL系统的内部错误提示：    " & Chr(13) & Chr(13) & ex.Message & Space(4), "出现CUL系统故障！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "因为CUL系统故障，无法进行换卡操作！"
            If c4Service IsNot Nothing Then c4Service.Dispose() : c4Service = Nothing
            DB.Close() : Me.Cursor = Cursors.Default : Return
        End Try

        frmMain.statusRate.Visible = True
        frmMain.statusRate.Text = ""
        frmMain.statusProgress.Visible = True
        frmMain.statusProgress.Value = 0
        frmMain.statusMain.Refresh()

        Dim sMerchantNo As String, sFailureReason As String, dtNewEffectiveDate As Date, sSQL As String, iSucessfully As Integer = 0, blSourceCardRecycleOK As Boolean, blSingleOK As Boolean
        Me.dgvList.Columns("OperationState").Visible = True
        For iRow As Integer = 0 To Me.dgvList.RowCount - 1
            If Me.dgvList("Selected", iRow).Value AndAlso Not Me.dgvList("Finished", iRow).Value Then
                sFailureReason = "" : blSourceCardRecycleOK = False : blSingleOK = False
                Me.dgvList("OperationState", iRow).Selected = True
                Me.dgvList.Rows(iRow).Selected = False
                Me.dgvList.Rows(iRow).Selected = True

                iCard += 1
                frmMain.statusText.Text = "正在提交换卡申请记录到CUL执行换卡操作……"
                frmMain.statusRate.Text = "(" & iCard.ToString & "/" & iCards.ToString & ")"
                frmMain.statusProgress.Value = Int((iCard / iCards) * 100)
                frmMain.statusMain.Refresh()

                currentRow("OperationState") = "正在换卡……"
                currentRow("OperationReason") = DBNull.Value
                Me.dgvList.FirstDisplayedScrollingColumnIndex = Me.dgvList.Columns("OperationState").Index
                Me.dgvList.Refresh()

                'modify code 021:start-------------------------------------------------------------------------
                'sMerchantNo = dvCULParameter.Table.Select("CULCardBin='" & currentRow("TargetCardNo").ToString.Substring(4, 5) & "'")(0)("CULStoreCode").ToString
                'If My.Settings.IsInTraining Then
                'sMerchantNo = clsForCulTest.sTestMerchantNo
                'Else
                sMerchantNo = dvCULParameter.Table.Select("CULCardBin='" & currentRow("TargetCardNo").ToString.Substring(4, 5) & "'")(0)("CULStoreCode").ToString
                'End If
                'modify code 021:end-------------------------------------------------------------------------
                Try
                    'modify code 021:start-------------------------------------------------------------------------

                    'modify code 033:start-------------------------------------------------------------------------
                    guIDClass = New C4ShoppingCardService.GuIDClass
                    guIDClass.GuID = frmMain.sGuID
                    'modify code 033:end-------------------------------------------------------------------------

                    'If My.Settings.IsInTraining Then
                    '    irecClass.MerchantNo = sMerchantNo
                    '    irecClass.UserID = clsForCulTest.sTestUserID
                    '    irecClass.CardNoFrom = currentRow("TargetCardNo").ToString
                    '    irecClass.CardNoTo = currentRow("TargetCardNo").ToString
                    '    'modify code 033:start-------------------------------------------------------------------------
                    '    codeMsg = c4Service.irec(irecClass, guIDClass) '先回收目标卡
                    '    'modify code 033:end-------------------------------------------------------------------------
                    '    If codeMsg.Code = "MZ" Then '回收目标卡成功
                    '        'modify code 050:start-------------------------------------------------------------------------
                    '        'If currentRow("SourceCardType") = "家乐福卡" Then
                    '        If currentRow("SourceCardType") = "家乐福卡" OrElse currentRow("SourceCardType") = "旧实名制卡" OrElse currentRow("SourceCardType") = "实名制卡" Then
                    '            'modify code 050:end-------------------------------------------------------------------------
                    '            irecClass.MerchantNo = sMerchantNo
                    '            irecClass.UserID = clsForCulTest.sTestUserID
                    '            irecClass.CardNoFrom = currentRow("SourceCardNo").ToString.Trim
                    '            irecClass.CardNoTo = currentRow("SourceCardNo").ToString.Trim
                    '            'modify code 033:start-------------------------------------------------------------------------
                    '            codeMsg = c4Service.irec(irecClass, guIDClass) '再回收源卡
                    '            'modify code 033:end-------------------------------------------------------------------------
                    '            If codeMsg.Code = "MZ" Then blSourceCardRecycleOK = True '回收源卡成功
                    '            'modify code 045:start-------------------------------------------------------------------------
                    '        ElseIf currentRow("SourceCardType") = "86卡" Then
                    '            '券先解冻再激活撤消
                    '            vstatusClass.Type = "ICUK"
                    '            vstatusClass.UserID = sMerchantNo
                    '            vstatusClass.MerchantNo = sMerchantNo
                    '            vstatusClass.VTypeId = currentRow("SourceCardNo").ToString.Trim.Substring(0, 8)
                    '            vstatusClass.VSeqNoFrom = currentRow("SourceCardNo").Substring(8)
                    '            vstatusClass.VSeqNoTo = currentRow("SourceCardNo").Substring(8)

                    '            vcodeMsg = c4Service.vstat(vstatusClass, guIDClass)
                    '            If vcodeMsg.Code = "01" Then
                    '                vidvvClass.MerchantNo = sMerchantNo
                    '                vidvvClass.UserID = sMerchantNo
                    '                vidvvClass.VTypeId = currentRow("SourceCardNo").ToString.Trim.Substring(0, 8)
                    '                vidvvClass.VSeqNoFrom = currentRow("SourceCardNo").Substring(8)
                    '                vidvvClass.VSeqNoTo = currentRow("SourceCardNo").Substring(8)
                    '                vidvvClass.VNumber = "1"
                    '                vidvvClass.VAmount = Format(currentRow("SourceBalance"), "0.00")
                    '                vidvvClass.VTotalAmount = Format(currentRow("SourceBalance"), "0.00")
                    '                vcodeMsg = c4Service.vidvv(vidvvClass, guIDClass)
                    '                If vcodeMsg.Code = "01" Then blSourceCardRecycleOK = True '回收源卡成功
                    '            End If
                    '            'modify code 045:end-------------------------------------------------------------------------
                    '        Else
                    '            'modify code 036:start-------------------------------------------------------------------------
                    '            If currentRow("SourceCardType") = "中行卡" Or currentRow("SourceCardType") = "保龙仓卡" Then
                    '                DestoryClass.MerchantNo = sMerchantNo
                    '                DestoryClass.UserID = clsForCulTest.sTestUserID
                    '                DestoryClass.CardNo = currentRow("SourceCardNo").ToString.Trim
                    '                codeMsg = c4Service.DestoryCard(DestoryClass, guIDClass).CodeMsg '销卡（中行卡或保龙仓卡）
                    '            Else
                    '                IcDestoryClass.MerchantNo = sMerchantNo
                    '                IcDestoryClass.UserID = clsForCulTest.sTestUserID
                    '                IcDestoryClass.IcType = IIf(currentRow("SourceCardType") = "商银通卡", "SYT", "SMT")
                    '                IcDestoryClass.CardNo = currentRow("SourceCardNo").ToString.Trim
                    '                'modify code 033:start-------------------------------------------------------------------------
                    '                codeMsg = c4Service.icDestoryCard(IcDestoryClass, guIDClass).CodeMsg '销卡（商银通卡或斯玛特卡）
                    '                'modify code 033:end-------------------------------------------------------------------------
                    '            End If
                    '            'modify code 036:end-------------------------------------------------------------------------
                    '            If codeMsg.Code = "OZ" Then blSourceCardRecycleOK = True '销卡成功
                    '        End If
                    '        If blSourceCardRecycleOK Then '回收源卡/销卡成功
                    '            'modify code 050:start-------------------------------------------------------------------------

                    '            ''modify code 047:start-------------------------------------------------------------------------
                    '            ''islvClass.MerchantNo = sMerchantNo
                    '            ''islvClass.UserID = clsForCulTest.sTestUserID
                    '            ''islvClass.CardNoFrom = currentRow("TargetCardNo").ToString
                    '            ''islvClass.CardNoTo = currentRow("TargetCardNo").ToString
                    '            ''islvClass.Amount = Format(currentRow("TargetBalance"), "0.00")
                    '            ''islvClass.TotalAmount = Format(currentRow("TargetBalance"), "0.00")
                    '            ''dtNewEffectiveDate = DateAdd(DateInterval.Day, -1, CDate(Format(DateAdd(DateInterval.Month, 3, Today()), "yyyy\/MM\/dd").Substring(0, 8) & "01"))
                    '            ''If dtNewEffectiveDate < currentRow("SourceEffectiveDate") Then dtNewEffectiveDate = currentRow("SourceEffectiveDate")
                    '            ''islvClass.ExpiredDate = Format(dtNewEffectiveDate, "yyyyMMdd").Substring(2, 4)
                    '            ' ''modify code 033:start-------------------------------------------------------------------------
                    '            ''codeMsg = c4Service.islv(islvClass, guIDClass) '对目标卡进行充值
                    '            ' ''modify code 033:end-------------------------------------------------------------------------
                    '            ''If codeMsg.Code = "HZ" Then blSingleOK = True '充值成功
                    '            'Dim dtResult As DataTable
                    '            'dtResult = DB.GetDataTable("select * from SignCardList where CardType='实名制卡' and CardNo='" & currentRow("SourceCardNo").ToString & "'")
                    '            'If currentRow("SourceCardType") = "家乐福卡" AndAlso dtResult.Rows.Count > 0 Then
                    '            '    Dim islvBySignUnSignBean As New C4ShoppingCardService.IslvBySignUnSignBean
                    '            '    Dim orderCardInfos(0) As C4ShoppingCardService.OrderCardInfo
                    '            '    Dim islvBySignUnSignData As C4ShoppingCardService.IslvBySignUnSignData

                    '            '    islvBySignUnSignBean.MerchantNo = sMerchantNo
                    '            '    islvBySignUnSignBean.UserID = clsForCulTest.sTestUserID
                    '            '    islvBySignUnSignBean.TotalAmount = Format(currentRow("TargetBalance"), "0.00")
                    '            '    islvBySignUnSignBean.DiscountAmount = "0.00"
                    '            '    islvBySignUnSignBean.SignFlag = "S"

                    '            '    orderCardInfos(0) = New C4ShoppingCardService.OrderCardInfo
                    '            '    orderCardInfos(0).CardNoFrom = currentRow("TargetCardNo").ToString
                    '            '    orderCardInfos(0).CardNoTo = currentRow("TargetCardNo").ToString
                    '            '    orderCardInfos(0).CardNum = "1"
                    '            '    orderCardInfos(0).CardAmount = Format(currentRow("TargetBalance"), "0.00")
                    '            '    dtNewEffectiveDate = DateAdd(DateInterval.Day, -1, CDate(Format(DateAdd(DateInterval.Month, 3, Today()), "yyyy\/MM\/dd").Substring(0, 8) & "01"))
                    '            '    If dtNewEffectiveDate < currentRow("SourceEffectiveDate") Then dtNewEffectiveDate = currentRow("SourceEffectiveDate")
                    '            '    orderCardInfos(0).ExpiredDate = Format(dtNewEffectiveDate, "yyyyMMdd").Substring(2, 4)
                    '            '    islvBySignUnSignBean.OrderCardInfos = orderCardInfos

                    '            '    islvBySignUnSignData = c4Service.islvBySignUnSign(islvBySignUnSignBean, guIDClass)
                    '            '    If islvBySignUnSignData.Code = "HZ" Then blSingleOK = True '充值成功
                    '            'Else
                    '            '    islvClass.MerchantNo = sMerchantNo
                    '            '    islvClass.UserID = clsForCulTest.sTestUserID
                    '            '    islvClass.CardNoFrom = currentRow("TargetCardNo").ToString
                    '            '    islvClass.CardNoTo = currentRow("TargetCardNo").ToString
                    '            '    islvClass.Amount = Format(currentRow("TargetBalance"), "0.00")
                    '            '    islvClass.TotalAmount = Format(currentRow("TargetBalance"), "0.00")
                    '            '    dtNewEffectiveDate = DateAdd(DateInterval.Day, -1, CDate(Format(DateAdd(DateInterval.Month, 3, Today()), "yyyy\/MM\/dd").Substring(0, 8) & "01"))
                    '            '    If dtNewEffectiveDate < currentRow("SourceEffectiveDate") Then dtNewEffectiveDate = currentRow("SourceEffectiveDate")
                    '            '    islvClass.ExpiredDate = Format(dtNewEffectiveDate, "yyyyMMdd").Substring(2, 4)
                    '            '    'modify code 033:start-------------------------------------------------------------------------
                    '            '    codeMsg = c4Service.islv(islvClass, guIDClass) '对目标卡进行充值
                    '            '    'modify code 033:end-------------------------------------------------------------------------
                    '            '    If codeMsg.Code = "HZ" Then blSingleOK = True '充值成功
                    '            'End If
                    '            ''modify code 047:end-------------------------------------------------------------------------

                    '            islvClass.MerchantNo = sMerchantNo
                    '            islvClass.UserID = clsForCulTest.sTestUserID
                    '            islvClass.CardNoFrom = currentRow("TargetCardNo").ToString
                    '            islvClass.CardNoTo = currentRow("TargetCardNo").ToString
                    '            islvClass.Amount = Format(currentRow("TargetBalance"), "0.00")
                    '            islvClass.TotalAmount = Format(currentRow("TargetBalance"), "0.00")
                    '            dtNewEffectiveDate = DateAdd(DateInterval.Day, -1, CDate(Format(DateAdd(DateInterval.Month, 3, Today()), "yyyy\/MM\/dd").Substring(0, 8) & "01"))
                    '            If dtNewEffectiveDate < currentRow("SourceEffectiveDate") Then dtNewEffectiveDate = currentRow("SourceEffectiveDate")
                    '            islvClass.ExpiredDate = Format(dtNewEffectiveDate, "yyyyMMdd").Substring(2, 4)
                    '            'modify code 033:start-------------------------------------------------------------------------
                    '            codeMsg = c4Service.islv(islvClass, guIDClass) '对目标卡进行充值
                    '            'modify code 033:end-------------------------------------------------------------------------
                    '            If codeMsg.Code = "HZ" Then blSingleOK = True '充值成功

                    '            'modify code 050:end-------------------------------------------------------------------------
                    '        End If
                    '    End If
                    'Else
                    irecClass.MerchantNo = sMerchantNo
                    irecClass.UserID = sMerchantNo
                    irecClass.CardNoFrom = currentRow("TargetCardNo").ToString
                    irecClass.CardNoTo = currentRow("TargetCardNo").ToString
                    'modify code 033:start-------------------------------------------------------------------------
                    codeMsg = c4Service.irec(irecClass, guIDClass) '先回收目标卡
                    'modify code 033:end-------------------------------------------------------------------------
                    If codeMsg.Code = "MZ" Then '回收目标卡成功
                        sMerchantNo = dvCULParameter.Table.Select("CULCardBin='" & currentRow("TargetCardNo").ToString.Substring(4, 5) & "'")(0)("CULStoreCode").ToString
                        'modify code 050:start-------------------------------------------------------------------------
                        ''modify code 045:start-------------------------------------------------------------------------
                        'If currentRow("SourceCardType") = "家乐福卡" Then
                        ''modify code 045:end-------------------------------------------------------------------------
                        'modify code 051:start-------------------------------------------------------------------------
                        'If currentRow("SourceCardType") = "家乐福卡" OrElse currentRow("SourceCardType") = "旧实名制卡" OrElse currentRow("SourceCardType") = "实名制卡" Then
                        If currentRow("SourceCardType") = "家乐福卡" OrElse currentRow("SourceCardType") = "旧实名制卡" OrElse currentRow("SourceCardType") = "实名制卡" OrElse currentRow("SourceCardType") = "65卡" Then
                            'modify code 051:end-------------------------------------------------------------------------
                            'modify code 050:end-------------------------------------------------------------------------
                            irecClass.MerchantNo = sMerchantNo
                            irecClass.UserID = sMerchantNo
                            irecClass.CardNoFrom = currentRow("SourceCardNo").ToString.Trim
                            irecClass.CardNoTo = currentRow("SourceCardNo").ToString.Trim
                            'modify code 033:start-------------------------------------------------------------------------
                            codeMsg = c4Service.irec(irecClass, guIDClass) '再回收源卡
                            'modify code 033:end-------------------------------------------------------------------------
                            If codeMsg.Code = "MZ" Then blSourceCardRecycleOK = True '回收源卡成功
                            'modify code 045:start-------------------------------------------------------------------------
                        ElseIf currentRow("SourceCardType") = "86卡" Then
                            '券先解冻再激活撤消
                            vstatusClass.Type = "ICUK"
                            vstatusClass.UserID = sMerchantNo
                            vstatusClass.MerchantNo = sMerchantNo
                            vstatusClass.VTypeId = currentRow("SourceCardNo").ToString.Trim.Substring(0, 8)
                            vstatusClass.VSeqNoFrom = currentRow("SourceCardNo").Substring(8)
                            vstatusClass.VSeqNoTo = currentRow("SourceCardNo").Substring(8)

                            vcodeMsg = c4Service.vstat(vstatusClass, guIDClass)
                            If vcodeMsg.Code = "01" Then
                                vidvvClass.MerchantNo = sMerchantNo
                                vidvvClass.UserID = sMerchantNo
                                vidvvClass.VTypeId = currentRow("SourceCardNo").ToString.Trim.Substring(0, 8)
                                vidvvClass.VSeqNoFrom = currentRow("SourceCardNo").Substring(8)
                                vidvvClass.VSeqNoTo = currentRow("SourceCardNo").Substring(8)
                                vidvvClass.VNumber = "1"
                                vidvvClass.VAmount = Format(currentRow("SourceBalance"), "0.00")
                                vidvvClass.VTotalAmount = Format(currentRow("SourceBalance"), "0.00")
                                vcodeMsg = c4Service.vidvv(vidvvClass, guIDClass)
                                If vcodeMsg.Code = "01" Then blSourceCardRecycleOK = True '回收源卡成功
                            End If
                            'modify code 045:end-------------------------------------------------------------------------
                        Else
                            'modify code 036:start-------------------------------------------------------------------------
                            If currentRow("SourceCardType") = "中行卡" Or currentRow("SourceCardType") = "保龙仓卡" Then
                                DestoryClass.MerchantNo = sMerchantNo
                                DestoryClass.UserID = sMerchantNo
                                DestoryClass.CardNo = currentRow("SourceCardNo").ToString.Trim
                                codeMsg = c4Service.DestoryCard(DestoryClass, guIDClass).CodeMsg '销卡（中行卡或保龙仓卡）
                            Else
                                IcDestoryClass.MerchantNo = sMerchantNo
                                IcDestoryClass.UserID = sMerchantNo
                                IcDestoryClass.IcType = IIf(currentRow("SourceCardType") = "商银通卡", "SYT", "SMT")
                                IcDestoryClass.CardNo = currentRow("SourceCardNo").ToString.Trim
                                'modify code 033:start-------------------------------------------------------------------------
                                codeMsg = c4Service.icDestoryCard(IcDestoryClass, guIDClass).CodeMsg '销卡（商银通卡或斯玛特卡）
                                'modify code 033:end-------------------------------------------------------------------------
                            End If
                            'modify code 036:end-------------------------------------------------------------------------
                            If codeMsg.Code = "OZ" Then blSourceCardRecycleOK = True '销卡成功
                        End If
                        If blSourceCardRecycleOK Then '回收源卡/销卡成功
                            'modify code 050:start-------------------------------------------------------------------------

                            ''modify code 047:start-------------------------------------------------------------------------
                            ''sMerchantNo = dvCULParameter.Table.Select("CULCardBin='" & currentRow("TargetCardNo").ToString.Substring(4, 5) & "'")(0)("CULStoreCode").ToString
                            ''islvClass.MerchantNo = sMerchantNo
                            ''islvClass.UserID = sMerchantNo
                            ''islvClass.CardNoFrom = currentRow("TargetCardNo").ToString
                            ''islvClass.CardNoTo = currentRow("TargetCardNo").ToString
                            ''islvClass.Amount = Format(currentRow("TargetBalance"), "0.00")
                            ''islvClass.TotalAmount = Format(currentRow("TargetBalance"), "0.00")
                            ''dtNewEffectiveDate = DateAdd(DateInterval.Day, -1, CDate(Format(DateAdd(DateInterval.Month, 3, Today()), "yyyy\/MM\/dd").Substring(0, 8) & "01"))
                            ''If dtNewEffectiveDate < currentRow("SourceEffectiveDate") Then dtNewEffectiveDate = currentRow("SourceEffectiveDate")
                            ''islvClass.ExpiredDate = Format(dtNewEffectiveDate, "yyyyMMdd").Substring(2, 4)
                            ' ''modify code 033:start-------------------------------------------------------------------------
                            ''codeMsg = c4Service.islv(islvClass, guIDClass) '对目标卡进行充值
                            ' ''modify code 033:end-------------------------------------------------------------------------
                            ''If codeMsg.Code = "HZ" Then blSingleOK = True '充值成功

                            'Dim dtResult As DataTable
                            'dtResult = DB.GetDataTable("select * from SignCardList where CardType='实名制卡' and CardNo='" & currentRow("SourceCardNo").ToString & "'")
                            'If currentRow("SourceCardType") = "家乐福卡" AndAlso dtResult.Rows.Count > 0 Then
                            '    Dim islvBySignUnSignBean As New C4ShoppingCardService.IslvBySignUnSignBean
                            '    Dim orderCardInfos(0) As C4ShoppingCardService.OrderCardInfo
                            '    Dim islvBySignUnSignData As C4ShoppingCardService.IslvBySignUnSignData

                            '    islvBySignUnSignBean.MerchantNo = sMerchantNo
                            '    islvBySignUnSignBean.UserID = sMerchantNo
                            '    islvBySignUnSignBean.TotalAmount = Format(currentRow("TargetBalance"), "0.00")
                            '    islvBySignUnSignBean.DiscountAmount = "0.00"
                            '    islvBySignUnSignBean.SignFlag = "S"

                            '    orderCardInfos(0) = New C4ShoppingCardService.OrderCardInfo
                            '    orderCardInfos(0).CardNoFrom = currentRow("TargetCardNo").ToString
                            '    orderCardInfos(0).CardNoTo = currentRow("TargetCardNo").ToString
                            '    orderCardInfos(0).CardNum = "1"
                            '    orderCardInfos(0).CardAmount = Format(currentRow("TargetBalance"), "0.00")
                            '    dtNewEffectiveDate = DateAdd(DateInterval.Day, -1, CDate(Format(DateAdd(DateInterval.Month, 3, Today()), "yyyy\/MM\/dd").Substring(0, 8) & "01"))
                            '    If dtNewEffectiveDate < currentRow("SourceEffectiveDate") Then dtNewEffectiveDate = currentRow("SourceEffectiveDate")
                            '    orderCardInfos(0).ExpiredDate = Format(dtNewEffectiveDate, "yyyyMMdd").Substring(2, 4)
                            '    islvBySignUnSignBean.OrderCardInfos = orderCardInfos

                            '    islvBySignUnSignData = c4Service.islvBySignUnSign(islvBySignUnSignBean, guIDClass)
                            '    If islvBySignUnSignData.Code = "HZ" Then blSingleOK = True '充值成功
                            'Else
                            '    sMerchantNo = dvCULParameter.Table.Select("CULCardBin='" & currentRow("TargetCardNo").ToString.Substring(4, 5) & "'")(0)("CULStoreCode").ToString
                            '    islvClass.MerchantNo = sMerchantNo
                            '    islvClass.UserID = sMerchantNo
                            '    islvClass.CardNoFrom = currentRow("TargetCardNo").ToString
                            '    islvClass.CardNoTo = currentRow("TargetCardNo").ToString
                            '    islvClass.Amount = Format(currentRow("TargetBalance"), "0.00")
                            '    islvClass.TotalAmount = Format(currentRow("TargetBalance"), "0.00")
                            '    dtNewEffectiveDate = DateAdd(DateInterval.Day, -1, CDate(Format(DateAdd(DateInterval.Month, 3, Today()), "yyyy\/MM\/dd").Substring(0, 8) & "01"))
                            '    If dtNewEffectiveDate < currentRow("SourceEffectiveDate") Then dtNewEffectiveDate = currentRow("SourceEffectiveDate")
                            '    islvClass.ExpiredDate = Format(dtNewEffectiveDate, "yyyyMMdd").Substring(2, 4)
                            '    'modify code 033:start-------------------------------------------------------------------------
                            '    codeMsg = c4Service.islv(islvClass, guIDClass) '对目标卡进行充值
                            '    'modify code 033:end-------------------------------------------------------------------------
                            '    If codeMsg.Code = "HZ" Then blSingleOK = True '充值成功
                            'End If
                            ''modify code 047:end-------------------------------------------------------------------------

                            sMerchantNo = dvCULParameter.Table.Select("CULCardBin='" & currentRow("TargetCardNo").ToString.Substring(4, 5) & "'")(0)("CULStoreCode").ToString
                            islvClass.MerchantNo = sMerchantNo
                            islvClass.UserID = sMerchantNo
                            islvClass.CardNoFrom = currentRow("TargetCardNo").ToString
                            islvClass.CardNoTo = currentRow("TargetCardNo").ToString
                            islvClass.Amount = Format(currentRow("TargetBalance"), "0.00")
                            islvClass.TotalAmount = Format(currentRow("TargetBalance"), "0.00")
                            dtNewEffectiveDate = DateAdd(DateInterval.Day, -1, CDate(Format(DateAdd(DateInterval.Month, 3, Today()), "yyyy\/MM\/dd").Substring(0, 8) & "01"))
                            If dtNewEffectiveDate < currentRow("SourceEffectiveDate") Then dtNewEffectiveDate = currentRow("SourceEffectiveDate")
                            islvClass.ExpiredDate = Format(dtNewEffectiveDate, "yyyyMMdd").Substring(2, 4)
                            'modify code 033:start-------------------------------------------------------------------------
                            codeMsg = c4Service.islv(islvClass, guIDClass) '对目标卡进行充值
                            'modify code 033:end-------------------------------------------------------------------------
                            If codeMsg.Code = "HZ" Then blSingleOK = True '充值成功

                            'modify code 050:end-------------------------------------------------------------------------
                        End If
                    End If
                    'End If
                    'modify code 021:end-------------------------------------------------------------------------

                    If blSingleOK Then
                        currentRow("OperationState") = "换卡成功。"
                        iSucessfully += 1
                        'modify code 047:start-------------------------------------------------------------------------
                        If DB.ModifyTable("update SignCardListNew set OperationDes='',CardNo='" & currentRow("TargetCardNo").ToString.Trim & "' where CardType='实名制卡' and CardNo='" & currentRow("SourceCardNo").ToString.Trim & "'", False) = -1 Then
                            MessageBox.Show(currentRow("SourceCardNo").ToString.Trim & vbCrLf & "实名制卡换卡已成功，但系统在保存结果时出错。    " & Chr(13) & Chr(13) & "请不要对该卡做重复确认，请及时通知National IT。    ", "换卡成功但保存结果失败！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            'modify code 063:start-------------------------------------------------------------------------
                            DB.ModifyTable("delete SignCardListCount where CardNo = '" & currentRow("SourceCardNo").ToString & "'")
                            'modify code 063:end-------------------------------------------------------------------------
                        End If
                        'modify code 047:end-------------------------------------------------------------------------
                    Else
                        'modify code 045:start-------------------------------------------------------------------------
                        'sFailureReason = codeMsg.Msg
                        If currentRow("SourceCardType") = "86卡" Then
                            sFailureReason = vcodeMsg.Msg
                        Else
                            sFailureReason = codeMsg.Msg
                        End If
                        'modify code 045:end-------------------------------------------------------------------------
                        currentRow("OperationState") = "换卡失败！"
                        currentRow("OperationReason") = sFailureReason
                        Me.dgvList.Columns("OperationReason").Visible = True
                        Me.dgvList.Columns("OperationReason").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        Me.dgvList.Columns("OperationReason").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        Me.dgvList.FirstDisplayedScrollingColumnIndex = Me.dgvList.Columns("OperationReason").Index
                        Me.dgvList.Refresh()
                    End If

                    sSQL = "Exec CULReplaceCardValidate @OperationID=" & currentRow("OperationID").ToString & ","
                    If sFailureReason = "" Then
                        sSQL = sSQL & "@TargetEffectiveDate='" & Format(dtNewEffectiveDate, "yyyy\/MM\/dd") & "',"
                    Else
                        sSQL = sSQL & "@OperationState=3,@OperationReason='" & sFailureReason.Replace("'", "''") & "',"
                    End If
                    sSQL = sSQL & "@AuditorName='" & frmMain.sLoginUserRealName.Replace("'", "''") & "',@SSID=" & frmMain.sSSID

                    Dim bTime As Byte = 0
                    Do
                        If DB.ModifyTable(sSQL, False) = 0 Then
                            Exit Do
                        ElseIf bTime = 3 Then
                            MessageBox.Show("换卡已成功，但系统在保存结果时出错。    " & Chr(13) & Chr(13) & "请不要对该卡做重复确认，请及时通知National IT。    ", "换卡成功但保存结果失败！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Do
                        Else
                            MessageBox.Show("换卡已成功，但系统在保存结果时出错。    " & Chr(13) & Chr(13) & "请重试一次。    ", "请重试保存结果：", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            bTime += 1
                            DB.Close()
                            DB.Open()
                        End If
                    Loop While True

                    currentRow("Finished") = 1
                    currentRow.AcceptChanges()
                Catch ex As Exception
                    If currentRow("OperationState").ToString = "正在换卡……" Then
                        For iAfter As Integer = iRow To Me.dgvList.RowCount - 1
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
            frmMain.statusText.Text = "提交换卡申请记录到CUL执行换卡操作时出现故障，请检查故障原因。"
            MessageBox.Show("提交换卡申请记录到CUL执行换卡操作时出现故障，请检查故障原因。    ", "换卡时出现故障！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf iSucessfully = 0 Then
            frmMain.statusText.Text = "已经将换卡记录提交到CUL系统，但换卡失败！"
            MessageBox.Show("已经将换卡记录提交到CUL系统，但没有卡换成功！    ", "换卡失败！", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf iSucessfully < iCards Then
            frmMain.statusText.Text = "已经将换卡记录提交到CUL系统，但部分成功，部分卡失败！"
            MessageBox.Show("已经将换卡记录提交到CUL系统，但部分成功，部分卡失败！    ", "换卡部分失败！", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            frmMain.statusText.Text = "已经将换卡记录提交到CUL系统，并且" & IIf(iSucessfully = 1, "", "全部") & "换卡成功。"
            MessageBox.Show("已经将换卡记录提交到CUL系统，并且" & IIf(iSucessfully = 1, "", "全部") & "换卡成功。    ", "换卡成功。", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistory.Click
        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在打开购物卡""换卡""历史记录窗口……"
        frmMain.statusMain.Refresh()

        If frmReplaceCardHistory.ShowDialog() = Windows.Forms.DialogResult.Ignore Then Me.btnHistory.Enabled = False
        frmReplaceCardHistory.Dispose()

        Me.Cursor = Cursors.Default
    End Sub
End Class