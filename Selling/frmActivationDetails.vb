Public Class frmActivationDetails

    Public dvCard As DataView
    Private blSkipDeal As Boolean = True, blCanReactivate As Boolean = True

    Private Sub frmActivationDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        blCanReactivate = (frmMain.dtAllowedRight.Select("RightName='SalesBillReactivate'").Length > 0)

        With Me.cbbFilter
            .Items.Add("（所有状态）")
            If dvCard.Table.Select("ActivationState='等待激活'").Length > 0 Then .Items.Add("等待激活")
            If dvCard.Table.Select("ActivationState='正在激活'").Length > 0 Then .Items.Add("正在激活")
            If dvCard.Table.Select("ActivationState='激活失败'").Length > 0 Then .Items.Add("激活失败")
            If dvCard.Table.Select("ActivationState='激活成功'").Length > 0 Then .Items.Add("激活成功")
            If dvCard.Table.Select("ActivationState='已被撤销激活'").Length > 0 Then .Items.Add("已被撤销激活")
            If dvCard.Table.Select("ActivationState='等待取消'").Length > 0 Then .Items.Add("等待取消")
            If dvCard.Table.Select("ActivationState='已被取消'").Length > 0 Then .Items.Add("等待取消")
            .SelectedIndex = 0
        End With
        Me.pnlFilter.Visible = (Me.cbbFilter.Items.Count > 2)

        With Me.dgvCard
            .DataSource = dvCard
            .Columns(0).Visible = False
            With .Columns(1)
                .HeaderText = "卡类型"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                If dvCard.Table.Select("Len(RowType)>3").Length > 0 Then
                    .Width = 105
                Else
                    .Width = 50
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End If
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
                .Visible = (dvCard.Table.Select("RowType='正常卡'").Length < dvCard.Count)
            End With
            With .Columns(2)
                .HeaderText = "行号"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 45
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Resizable = DataGridViewTriState.False
                .Visible = (dvCard.Table.Compute("Max(RowID)", "") > 1)
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
                .HeaderText = "面值"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(5)
                .HeaderText = "激活者"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .Visible = (dvCard.Table.Select("Isnull(ActivatorName,'')<>''").Length > 0)
            End With
            With .Columns(6)
                .HeaderText = "提交时间"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Format = "yyyy\/MM\/dd HH:mm:ss"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .Visible = Me.dgvCard.Columns(5).Visible
            End With
            With .Columns(7)
                .HeaderText = "重新激活者"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .Visible = (dvCard.Table.Select("Isnull(ReactivatorName,'')<>''").Length > 0)
            End With
            With .Columns(8)
                .HeaderText = "提交时间"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Format = "yyyy\/MM\/dd HH:mm:ss"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .Visible = Me.dgvCard.Columns(7).Visible
            End With
            With .Columns(9)
                .HeaderText = "CUL激活时间"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Format = "yyyy\/MM\/dd HH:mm:ss"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .Visible = (dvCard.Table.Select("CULActivatedTime Is Not Null").Length > 0)
            End With
            With .Columns(10)
                .HeaderText = "激活状态"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(11)
                .HeaderText = "状态原因"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .Visible = (dvCard.Table.Select("Isnull(StateReason,'')<>''").Length > 0)
            End With
            Dim newCheckColumn As New DataGridViewCheckBoxColumn()
            newCheckColumn.DataPropertyName = "Reactivate"
            .Columns.RemoveAt(12)
            .Columns.Insert(12, newCheckColumn)
            With .Columns(12)
                .HeaderText = "重新激活"
                .Width = 65
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .Visible = (blCanReactivate AndAlso dvCard.Table.Select("ActivationState='激活失败'").Length > 0)
            End With
        End With

        Dim iGridWidth As Integer = 0, iMaxGridHeight As Integer = 0, iAvailableGridHeight As Integer = 0
        For Each column As DataGridViewColumn In Me.dgvCard.Columns
            column.Name = dvCard.Table.Columns(column.Index).ColumnName
            If column.Visible Then iGridWidth += column.Width
        Next
        iGridWidth += IIf(ToolStripManager.VisualStylesEnabled, 2, 4)

        iMaxGridHeight = (dvCard.Count + 1) * 24 + IIf(ToolStripManager.VisualStylesEnabled, 0, 2)
        If My.Computer.Screen.WorkingArea.Width < iGridWidth + 30 Then
            Me.Width = My.Computer.Screen.WorkingArea.Width
            iMaxGridHeight += 17
        Else
            Me.Width = iGridWidth + 30
        End If
        With Me.dgvCard.Columns("ActivationState")
            .MinimumWidth = .Width
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        If dvCard.Table.Select("ActivationState='激活失败'").Length > 0 Then
            Me.grbRemarks.Visible = True
            If blCanReactivate Then
                Me.chbSelectAll.Visible = (dvCard.Table.Select("ActivationState='激活失败'").Length > 1)
            Else
                Me.rtbRemarks.Clear()
                Me.rtbRemarks.AppendText("存在激活失败的购物卡！这些购物卡虽然已提交到CUL，但激活未能成功。您本人不具有重新激活购物卡的权限，请找具有权限的人重新激活这些首次激活失败的购物卡。")
            End If
            iAvailableGridHeight = My.Computer.Screen.WorkingArea.Height - 175
        Else
            Me.grbRemarks.Visible = False : Me.btnReactivate.Visible = False
            iAvailableGridHeight = My.Computer.Screen.WorkingArea.Height - 109
        End If

        If iMaxGridHeight < iAvailableGridHeight Then
            Me.dgvCard.Height = iMaxGridHeight
            Me.Height = iMaxGridHeight + IIf(Me.grbRemarks.Visible, 175, 109)
        Else
            If My.Computer.Screen.WorkingArea.Width < iGridWidth + 30 Then iAvailableGridHeight -= 17
            iAvailableGridHeight = Int(iAvailableGridHeight / 24) * 24
            If My.Computer.Screen.WorkingArea.Width < iGridWidth + 30 Then iAvailableGridHeight += 17
            Me.dgvCard.Height = iAvailableGridHeight
            Me.Height = iAvailableGridHeight + IIf(Me.grbRemarks.Visible, 175, 109)
        End If
        If dvCard.Count > Me.dgvCard.DisplayedRowCount(False) Then Me.Width += 20

        Me.Location = New Point(Int((My.Computer.Screen.WorkingArea.Width - Me.Width) / 2), Int((My.Computer.Screen.WorkingArea.Height - Me.Height) / 2))

        blSkipDeal = False
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub dgvCard_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCard.CellContentClick
        If e.RowIndex = -1 OrElse Not blCanReactivate OrElse Me.dgvCard.Columns(e.ColumnIndex).Name <> "Reactivate" OrElse Me.dgvCard("ActivationState", e.RowIndex).Value.ToString <> "激活失败" Then Return
        Dim drCard As DataRow = dvCard.Table.Select("SalesBillDetailID=" & Me.dgvCard("SalesBillDetailID", e.RowIndex).Value.ToString & " And CardNo='" & Me.dgvCard("CardNo", e.RowIndex).Value.ToString & "'")(0)
        drCard("Reactivate") = Not drCard("Reactivate")
        Me.btnReactivate.Enabled = (dvCard.Table.Select("Reactivate=1").Length > 0)
        blSkipDeal = True
        If dvCard.Table.Select("Reactivate=1").Length = 0 Then
            Me.chbSelectAll.CheckState = CheckState.Unchecked
        ElseIf dvCard.Table.Select("Reactivate=1").Length = dvCard.Table.Select("ActivationState='激活失败'").Length Then
            Me.chbSelectAll.CheckState = CheckState.Checked
        Else
            Me.chbSelectAll.CheckState = CheckState.Indeterminate
        End If
        blSkipDeal = False
    End Sub

    Private Sub dgvCard_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvCard.CellFormatting
        Select Case Me.dgvCard.Columns(e.ColumnIndex).Name
            Case "ActivationState", "StateReason"
                If Me.dgvCard("ActivationState", e.RowIndex).Value.ToString = "等待激活" Then
                    e.CellStyle.ForeColor = Color.Green
                    e.CellStyle.SelectionForeColor = Color.LightGreen
                ElseIf Me.dgvCard("ActivationState", e.RowIndex).Value.ToString = "正在激活" Then
                    e.CellStyle.ForeColor = Color.SteelBlue
                    e.CellStyle.SelectionForeColor = Color.LightBlue
                ElseIf Me.dgvCard("ActivationState", e.RowIndex).Value.ToString = "激活失败" OrElse Me.dgvCard("ActivationState", e.RowIndex).Value.ToString = "已被撤销激活" Then
                    e.CellStyle.ForeColor = Color.Red
                    e.CellStyle.SelectionForeColor = Color.Red
                End If
            Case "Reactivate"
                If Me.dgvCard("ActivationState", e.RowIndex).Value.ToString <> "激活失败" Then
                    e.CellStyle.Padding = New Padding(30)
                End If
        End Select
    End Sub

    Private Sub chbSelectAll_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbSelectAll.CheckStateChanged
        If blSkipDeal Then Return

        For Each drCard As DataRow In dvCard.Table.Select("ActivationState='激活失败'")
            drCard("Reactivate") = IIf(Me.chbSelectAll.CheckState = CheckState.Checked, 1, 0)
        Next
        Me.btnReactivate.Enabled = (Me.chbSelectAll.CheckState = CheckState.Checked)
    End Sub

    Private Sub chbSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbSelectAll.Click
        If Me.chbSelectAll.CheckState = CheckState.Checked Then
            Me.chbSelectAll.CheckState = CheckState.Unchecked
        Else
            Me.chbSelectAll.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub cbbFilter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbFilter.SelectedIndexChanged
        If blSkipDeal Then Return

        If Me.cbbFilter.SelectedIndex = 0 Then
            dvCard.RowFilter = ""
        Else
            dvCard.RowFilter = "ActivationState='" & Me.cbbFilter.Text & "'"
        End If
    End Sub

    Private Sub btnReactivate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReactivate.Click
        Dim sOldRowFilter As String = dvCard.RowFilter
        dvCard.RowFilter = "Reactivate=1"
        Me.dgvCard.FirstDisplayedScrollingColumnIndex = Me.dgvCard.Columns("Reactivate").Index

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在重新激活已选择的购物卡……"

        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法重新激活。请检查数据库连接。"
            dvCard.RowFilter = sOldRowFilter
            Me.Cursor = Cursors.Default : Return
        End If

        If DB.ModifyTable("Select SalesBillDetailID,CardNo,FaceValue Into #tempCard From PendingActivationList Where 1=2") = -1 Then
            frmMain.statusText.Text = "重新激活失败！"
            dvCard.RowFilter = sOldRowFilter
            Me.Cursor = Cursors.Default : DB.Close() : Return
        End If

        Dim dtCard As DataTable = dvCard.ToTable(False, "SalesBillDetailID", "CardNo", "FaceValue")
        If DB.BulkCopyTable("#tempCard", dtCard) = -1 Then
            frmMain.statusText.Text = "重新激活失败！"
            dvCard.RowFilter = sOldRowFilter
            Me.Cursor = Cursors.Default : DB.Close() : Return
        End If
        dtCard.Dispose() : dtCard = Nothing

        Dim dtResult As DataTable = DB.GetDataTable("Exec ReactivateCard @SalesBillID=" & frmSelling.sSalesBillID & ",@OperatorName='" & frmMain.sLoginUserRealName.Replace("'", "''") & "',@SSID=" & frmMain.sSSID)
        If dtResult Is Nothing Then
            frmMain.statusText.Text = "重新激活失败！"
            dvCard.RowFilter = sOldRowFilter
            Me.Cursor = Cursors.Default : DB.Close() : Return
        End If

        Select Case dtResult.Rows(0)("Result").ToString
            Case "AlreadyActivated"
                MessageBox.Show("已有他人重新激活了您选择的卡！    " & Chr(13) & Chr(13) & "请在 5 分钟后再查看" & IIf(dvCard.Count = 1, "该卡", "这些卡") & "的激活状态。    ", "卡已被他人激活！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.chbSelectAll.Visible = False : Me.btnReactivate.Enabled = False
            Case "OK"
                For Each drCard As DataRowView In dvCard
                    drCard("ReactivatorName") = frmMain.sLoginUserRealName
                    drCard("ReactivatedTime") = dtResult.Rows(0)("ReactivatedTime")
                    drCard("ActivationState") = "正在激活"
                    drCard("StateReason") = DBNull.Value
                    drCard.Row.AcceptChanges()
                Next
                With Me.dgvCard
                    With .Columns("ReactivatorName")
                        .Visible = True
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    End With
                    With .Columns("ReactivatedTime")
                        .Visible = True
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    End With
                End With

                With frmSelling
                    Dim dtSource As DataTable = CType(.dgvNormalCard.DataSource, DataTable)
                    For Each drCard As DataRow In dtSource.Rows
                        If drCard("ActivationState").ToString = "激活失败" Then
                            drCard("ActivationState") = "正在激活"
                            drCard("StateReason") = DBNull.Value
                            drCard.AcceptChanges()
                            .dgvNormalCard.Columns("StateReason").Visible = False
                        End If
                    Next

                    dtSource = CType(.dgvRebateCard.DataSource, DataTable)
                    For Each drCard As DataRow In dtSource.Rows
                        If drCard("ActivationState").ToString = "激活失败" Then
                            drCard("ActivationState") = "正在激活"
                            drCard("StateReason") = DBNull.Value
                            drCard.AcceptChanges()
                            .dgvRebateCard.Columns("StateReason").Visible = False
                        End If
                    Next
                    dtSource = Nothing

                    If .drSalesBill("SalesBillState") = 2 Then
                        .drSalesBill("SalesBillState") = 1
                        .drSalesBill.AcceptChanges()
                        .lblSalesBillState.Text = "已提交到CUL，正在激活"
                        .theTip.SetToolTip(.lblSalesBillState, "")
                        If frmSalesBillManagement.IsHandleCreated Then
                            Try
                                Dim currentSalesBill As DataRow = frmSalesBillManagement.dvSalesBill.Table.Rows.Find(frmSelling.drSalesBill("SalesBillID").ToString)
                                currentSalesBill("SalesBillState") = "正在激活"
                                currentSalesBill.AcceptChanges()
                                currentSalesBill = Nothing
                            Catch
                            End Try
                        End If
                    End If
                End With

                MessageBox.Show("已经将您刚才选择的购物卡重新提交到CUL激活。    " & Chr(13) & Chr(13) & "请于 5 分钟后重新打开该窗口，查看重新激活结果。    ", "重新激活已经提交。", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.chbSelectAll.Visible = False : Me.btnReactivate.Enabled = False
            Case Else
                MessageBox.Show("重新激活购物卡时出现错误！下面是数据库的内部错误提示：    " & Chr(13) & Chr(13) & dtResult.Rows(0)("ErrorInfo").ToString & Space(4) & Chr(13) & Chr(13) & "请放弃激活，在关闭窗口后重试。如果仍有问题，请联系软件开发人员。    ", "重新激活失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                frmMain.statusText.Text = "重新激活失败！"
        End Select

        dvCard.RowFilter = sOldRowFilter
        dtResult.Dispose() : dtResult = Nothing
        DB.Close()
        Me.Cursor = Cursors.Default
    End Sub
End Class