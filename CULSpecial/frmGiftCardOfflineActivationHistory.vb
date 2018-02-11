Public Class frmGiftCardOfflineActivationHistory

    Private dvList As DataView, dtState As DataTable, dvCULParameter As DataView, blSkipDeal As Boolean = True

    Private Sub frmGiftCardOfflineActivationHistory_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub frmGiftCardOfflineActivationHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打开礼品卡""离线激活""历史记录窗口。请检查数据库连接。"
            Me.Close() : Return
        End If

        Try
            dvList = DB.GetDataTable("Exec GetCULGiftCardOfflineActivationHistory " & frmMain.sLoginUserID).DefaultView
        Catch
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开礼品卡""离线激活""历史记录窗口。请联系软件开发人员。"
            DB.Close() : Me.Close() : Return
        End Try
        DB.Close()

        frmMain.statusText.Text = "就绪。"
        If dvList.Count = 0 Then
            MessageBox.Show("还未发现任何礼品卡""离线激活""历史记录。    ", "没有历史记录。", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = Windows.Forms.DialogResult.Ignore : Return
        End If

        Dim dtTemp As DataTable = dvList.ToTable(True, "StoreName")
        If dtTemp.Rows.Count > 1 Then Me.cbbStore.Items.Add("（全部）")
        For Each dr As DataRow In dtTemp.Select("", "StoreName")
            Me.cbbStore.Items.Add(dr(0).ToString)
        Next
        Me.cbbStore.SelectedIndex = 0
        If Me.cbbStore.Items.Count = 1 Then Me.pnlStore.Visible = False

        dtTemp = dvList.ToTable(True, "RequestedDate")
        If dtTemp.Rows.Count > 1 Then Me.cbbDate.Items.Add("（全部）")
        For Each dr As DataRow In dtTemp.Select("", "RequestedDate Desc")
            Me.cbbDate.Items.Add(dr(0).ToString)
        Next
        Me.cbbDate.SelectedIndex = 0

        dtTemp.Dispose() : dtTemp = Nothing

        dtState = New DataTable
        dtState.Columns.Add("OperationState", System.Type.GetType("System.Int16"))
        dtState.Columns.Add("StateDescription", System.Type.GetType("System.String"))
        dtState.Rows.Add(-1, "（全部）")
        dtState.Rows.Add(0, "等待确认")
        'dtState.Rows.Add(1, "确认失败")
        'dtState.Rows.Add(2, "确认成功")
        dtState.Rows.Add(3, "激活失败")
        dtState.Rows.Add(4, "激活成功")
        dtState.AcceptChanges()
        dtState.DefaultView.Sort = "OperationState"
        With Me.cbbState
            .DataSource = dtState
            .ValueMember = "OperationState"
            .DisplayMember = "StateDescription"
            .SelectedIndex = 3
        End With

        dvList.Sort = "RequestedTime Desc"
        dvList.RowFilter = ""
        With Me.dgvList
            .DataSource = dvList
            With .Columns(0)
                .HeaderText = "卡号"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 125
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(1)
                .HeaderText = "条形码"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 85
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(2)
                .HeaderText = "卡面值"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(3)
                .HeaderText = "卡成本"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(4)
                .HeaderText = "收款金额"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(5)
                .HeaderText = "家乐福收银小票信息"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .MinimumWidth = .Width
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(6)
                .HeaderText = "申请门店"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .MinimumWidth = .Width
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
                .Width = 120
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(9)
                .HeaderText = "确认者"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(10)
                .HeaderText = "确认时间"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Format = "yyyy\/MM\/dd HH:mm:ss"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 120
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
            End With
            Dim newColumn As New DataGridViewComboBoxColumn
            With newColumn
                .DataPropertyName = "OperationState"
                .DataSource = dtState
                .ValueMember = "OperationState"
                .DisplayMember = "StateDescription"
                .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
            End With
            .Columns.RemoveAt(11)
            .Columns.Insert(11, newColumn)
            With .Columns(11)
                .HeaderText = "处理状态"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(12)
                .HeaderText = "失败原因"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .MinimumWidth = .Width
                .DefaultCellStyle.ForeColor = Color.Red
                .DefaultCellStyle.SelectionForeColor = Color.Red
                .Resizable = DataGridViewTriState.False
                .Visible = False
            End With
            .Columns(13).Visible = False
            .Columns(14).Visible = False
            .Columns(15).Visible = False

            For bColumn As Byte = 0 To dvList.Table.Columns.Count - 1
                .Columns(bColumn).Name = dvList.Table.Columns(bColumn).ColumnName
            Next
        End With

        blSkipDeal = False
        Me.cbbState.SelectedIndex = 1
        If dvList.Count = 0 Then Me.cbbState.SelectedIndex = 0

        Me.dgvList.Select()
        Me.txbCardNo.Select()
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub cbbStore_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbStore.SelectedIndexChanged, cbbDate.SelectedIndexChanged, cbbState.SelectedIndexChanged
        If blSkipDeal Then Return
        Dim sRowFilter As String = ""
        If Me.cbbStore.SelectedIndex > 0 Then sRowFilter = "StoreName='" & Me.cbbStore.Text.Replace("'", "''") & "'"
        If Me.cbbDate.SelectedIndex > 0 Then sRowFilter = IIf(sRowFilter = "", "", sRowFilter & " And ") & "RequestedDate='" & Me.cbbDate.Text & "'"
        If Me.cbbState.SelectedIndex > 0 Then sRowFilter = IIf(sRowFilter = "", "", sRowFilter & " And ") & "OperationState=" & Me.cbbState.SelectedValue.ToString
        dvList.RowFilter = sRowFilter

        With Me.dgvList.Columns("StoreName")
            .MinimumWidth = 2
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .MinimumWidth = .Width
        End With
        With Me.dgvList.Columns("OperationReason")
            .MinimumWidth = 2
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .MinimumWidth = .Width
        End With

        Dim dtTemp As DataTable = dvList.ToTable
        Dim iGridWidth As Integer = 0, iMaxGridHeight As Integer = 0, iAvailableGridHeight As Integer = 0
        For bColumn As Byte = 0 To dtTemp.Columns.Count - 4 '不包括最后三列
            If dvList.Count > 0 Then Me.dgvList.Columns(bColumn).Visible = (dtTemp.Select(Me.dgvList.Columns(bColumn).Name & " Is not NULL").Length > 0)
            If Me.dgvList.Columns(bColumn).Visible Then
                If Me.dgvList.Columns(bColumn).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells Then
                    Me.dgvList.Columns(bColumn).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    Me.dgvList.Columns(bColumn).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End If
                iGridWidth += Me.dgvList.Columns(bColumn).Width
            End If
        Next
        iGridWidth += IIf(ToolStripManager.VisualStylesEnabled, 2, 4)

        Me.dgvList.Columns("StoreName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.dgvList.Columns("OperationReason").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        iMaxGridHeight = (IIf(Me.dgvList.RowCount < 7, 7, Me.dgvList.RowCount) + 1) * 24 + IIf(ToolStripManager.VisualStylesEnabled, 0, 2)
        If My.Computer.Screen.WorkingArea.Width < iGridWidth + 33 Then
            Me.Width = My.Computer.Screen.WorkingArea.Width
            iMaxGridHeight += 17
        Else
            Me.Width = iGridWidth + 34
        End If
        With Me.dgvList.Columns("OperationReason")
            .MinimumWidth = .Width
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        iAvailableGridHeight = My.Computer.Screen.WorkingArea.Height - 135
        If iMaxGridHeight < iAvailableGridHeight Then
            Me.Height = iMaxGridHeight + 135
        Else
            If My.Computer.Screen.WorkingArea.Width < iGridWidth + 30 Then iAvailableGridHeight -= 17
            iAvailableGridHeight = Int(iAvailableGridHeight / 24) * 24
            If My.Computer.Screen.WorkingArea.Width < iGridWidth + 30 Then iAvailableGridHeight += 17
            Me.Height = iAvailableGridHeight + 135
        End If
        If Me.dgvList.RowCount > Me.dgvList.DisplayedRowCount(False) Then Me.Width += 20

        Me.Location = New Point(Int((My.Computer.Screen.WorkingArea.Width - Me.Width) / 2), Int((My.Computer.Screen.WorkingArea.Height - Me.Height) / 2))
    End Sub

    Private Sub dgvList_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvList.CellFormatting
        If Me.dgvList.Columns(e.ColumnIndex).Name = "OperationState" AndAlso e.Value.ToString.IndexOf("失败") > -1 Then
            e.CellStyle.ForeColor = Color.Red
            e.CellStyle.SelectionForeColor = Color.Red
        End If
    End Sub

    Private Sub dgvList_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvList.Leave
        If Me.dgvList.CurrentRow Is Nothing Then Return

        Dim clickedControl As Control = Me.GetChildAtPoint(Me.PointToClient(Control.MousePosition))
        If clickedControl Is Nothing OrElse clickedControl.Name <> "btnDelete" Then
            Me.dgvList.CurrentRow.Selected = False
            Me.btnDelete.Enabled = False
        End If
        clickedControl = Nothing
    End Sub

    Private Sub dgvList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvList.SelectionChanged
        frmMain.statusText.Text = "就绪。"
        Me.btnDelete.Enabled = (Me.dgvList.CurrentRow IsNot Nothing AndAlso Me.dgvList("OperationState", Me.dgvList.CurrentRow.Index).Value < 2 AndAlso Me.dgvList("RequestorID", Me.dgvList.CurrentRow.Index).Value.ToString = frmMain.sLoginUserID)
    End Sub

    Private Sub txbCardNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbCardNo.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter AndAlso Me.btnSearch.Enabled Then Me.btnSearch.PerformClick() : e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If Me.txbCardNo.SelectedText = Me.txbCardNo.Text Then Me.txbCardNo.Text = ""
            Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbCardNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbCardNo.TextChanged
        Me.lblCardError.Text = ""
        Me.btnSearch.Enabled = (Me.txbCardNo.Text.Trim <> "")
    End Sub

    Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If Me.txbCardNo.Text <> Me.txbCardNo.Text.Trim Then Me.txbCardNo.Text = Me.txbCardNo.Text.Trim
        Dim sCardNo As String = Me.txbCardNo.Text

        If Not IsNumeric(sCardNo) Then
            Me.lblCardError.Text = "（卡号只能由数字组成！）"
        ElseIf sCardNo.Length < 19 Then
            Me.lblCardError.Text = "（卡号位数不足 19 位！）"
        ElseIf sCardNo <> ShoppingCardNo.GetFullCardNo(sCardNo.Substring(0, 18)) Then
            Me.lblCardError.Text = "（卡号校验码错误！）"
        ElseIf sCardNo.IndexOf("233660") <> 0 Then
            Me.lblCardError.Text = "（该卡不是礼品卡！）"
        End If

        If Me.lblCardError.Text = "" Then
            Me.Cursor = Cursors.WaitCursor
            Dim blFound As Boolean = False
            For Each drCard As DataGridViewRow In Me.dgvList.Rows
                If drCard.Cells("CardNo").Value.ToString.Trim = sCardNo Then
                    blFound = True
                    Me.dgvList.Select()
                    drCard.Selected = True
                    Me.dgvList.FirstDisplayedScrollingRowIndex = drCard.Index
                    Exit For
                End If
            Next
            If Not blFound Then
                MessageBox.Show("未找到该卡号！    ", "未找到卡号！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.txbCardNo.Select()
                Me.txbCardNo.SelectAll()
            End If
            Me.Cursor = Cursors.Default
        Else
            Me.txbCardNo.Select()
            Me.txbCardNo.SelectAll()
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MessageBox.Show("您确实想删除该卡""" & Me.dgvList("CardNo", Me.dgvList.CurrentRow.Index).Value.ToString & """的离线激活申请吗？    " & Chr(13) & Chr(13) & "（只能删除由您自己添加的且未被确认的离线激活申请记录。）    ", "请确认删除离线激活申请：", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then Return

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在删除离线激活申请记录……"
        frmMain.statusMain.Refresh()

        Dim currentRow As DataRow = dvList.Table.Select("OperationID=" & Me.dgvList("OperationID", Me.dgvList.CurrentRow.Index).Value.ToString)(0)
        Dim DB As New DataBase
        DB.Open()
        If DB.IsConnected Then
            Dim dtResult As DataTable = DB.GetDataTable("Exec CULOfflineActivateGiftCardDelete " & currentRow("OperationID").ToString & "," & frmMain.sSSID)
            DB.Close()
            If dtResult Is Nothing Then
                frmMain.statusText.Text = "删除离线激活申请记录失败！"
            ElseIf dtResult.Rows(0)("Result").ToString = "AlreadyValidated" Then
                frmMain.statusText.Text = "当前离线激活申请记录已被他人确认过，您已无法删除它。"
            ElseIf dtResult.Rows(0)("Result").ToString = "Error" Then
                MessageBox.Show("删除离线激活申请记录时出现错误！下面是数据库的内部错误提示：    " & Chr(13) & Chr(13) & dtResult.Rows(0)("ErrorInfo").ToString & Space(4) & Chr(13) & Chr(13) & "请放弃保存，在关闭窗口后重试。如果仍有问题，请联系软件开发人员。    ", "删除离线激活申请记录失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                frmMain.statusText.Text = "删除离线激活申请记录失败！"
            Else
                currentRow.Delete() : currentRow.AcceptChanges()
                If Me.dgvList.CurrentRow IsNot Nothing Then
                    Me.dgvList.CurrentRow.Selected = False
                    Me.dgvList.CurrentRow.Selected = True
                End If
                frmMain.statusText.Text = "删除离线激活申请记录成功。"
            End If
            If dtResult IsNot Nothing Then dtResult.Dispose() : dtResult = Nothing
        Else
            frmMain.statusText.Text = "系统因连接不到数据库而无法删除离线激活申请记录。请检查数据库连接。"
        End If
        Me.Cursor = Cursors.Default
    End Sub
End Class