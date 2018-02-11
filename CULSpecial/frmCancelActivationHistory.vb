Public Class frmCancelActivationHistory

    Private dvList As DataView, dtState As DataTable, blSkipDeal As Boolean = True, blCanBrowseSalesBill = True

    Private Sub frmCancelActivationHistory_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub frmCancelActivationHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        blCanBrowseSalesBill = (frmMain.dtAllowedRight.Select("RightName='SalesBillBrowse'").Length > 0)

        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打开购物卡""激活撤销""历史记录窗口。请检查数据库连接。"
            Me.Close() : Return
        End If

        Try
            dvList = DB.GetDataTable("Exec GetCULCancelActivationHistory " & frmMain.sLoginUserID).DefaultView
        Catch
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开购物卡""激活撤销""历史记录窗口。请联系软件开发人员。"
            DB.Close() : Me.Close() : Return
        End Try
        DB.Close()

        frmMain.statusText.Text = "就绪。"
        If dvList.Count = 0 Then
            MessageBox.Show("还未发现任何购物卡""激活撤销""历史记录。    ", "没有历史记录。", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = Windows.Forms.DialogResult.Ignore
            Return
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
        dtState.Rows.Add(1, "没有通过")
        dtState.Rows.Add(3, "已确认但撤销失败")
        dtState.Rows.Add(4, "已确认且撤销成功")
        dtState.AcceptChanges()
        dtState.DefaultView.Sort = "OperationState"
        With Me.cbbState
            .DataSource = dtState
            .ValueMember = "OperationState"
            .DisplayMember = "StateDescription"
            .SelectedIndex = 4
        End With

        dvList.Sort = "RequestedTime Desc"
        dvList.RowFilter = "OperationState=0"
        With Me.dgvList
            .DataSource = dvList
            With .Columns(0)
                .HeaderText = "批号"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Width = 40
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(1)
                .HeaderText = "行号"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Width = 40
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(2)
                .HeaderText = "卡号"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Width = 125
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(3)
                .HeaderText = "卡状态"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Width = 50
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(4)
                .HeaderText = "余额"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Width = 60
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            Dim linkColomn As New DataGridViewLinkColumn
            linkColomn.DataPropertyName = "SalesBillCode"
            .Columns.RemoveAt(5)
            .Columns.Insert(5, linkColomn)
            With .Columns(5)
                .HeaderText = "销售单号"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 90
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(6)
                .HeaderText = "面值"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Width = 60
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(7)
                .HeaderText = "卡类型"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Width = 50
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(8)
                .HeaderText = "申请原因"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(9)
                .HeaderText = "申请门店"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(10)
                .HeaderText = "申请者"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(11)
                .HeaderText = "申请时间"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Format = "yyyy\/MM\/dd HH:mm:ss"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(12)
                .HeaderText = "确认者"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(13)
                .HeaderText = "确认时间"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Format = "yyyy\/MM\/dd HH:mm:ss"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
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
            .Columns.RemoveAt(14)
            .Columns.Insert(14, newColumn)
            With .Columns(14)
                .HeaderText = "处理状态"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(15)
                .HeaderText = "失败原因"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .MinimumWidth = .Width
                .DefaultCellStyle.ForeColor = Color.Red
                .DefaultCellStyle.SelectionForeColor = Color.Red
                .Resizable = DataGridViewTriState.False
            End With
            .Columns(16).Visible = False
            .Columns(17).Visible = False
            .Columns(18).Visible = False

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

        Dim dtTemp As DataTable = dvList.ToTable
        If dvList.Count = 0 Then
            Me.lblTitle.Text = "购物卡""激活撤销""历史记录："
        Else
            Me.lblTitle.Text = "购物卡""激活撤销""历史记录（共 " & Format(dvList.Count, "#,0") & " 张次 " & Format(dtTemp.Compute("Sum(FaceValue)", ""), "#,0.00").Replace(".00", "") & " 元）："
        End If
        Me.dgvList.Columns("AuditorName").Visible = (dtTemp.Select("Isnull(AuditorName,'')<>''").Length > 0)
        Me.dgvList.Columns("ValidatedTime").Visible = Me.dgvList.Columns("AuditorName").Visible
        Me.dgvList.Columns("OperationReason").Visible = (dtTemp.Select("Isnull(OperationReason,'')<>''").Length > 0)

        Dim iGridWidth As Integer = 0, iMaxGridHeight As Integer = 0, iAvailableGridHeight As Integer = 0
        For Each column As DataGridViewColumn In Me.dgvList.Columns
            If column.Visible Then
                If column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells Then
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                ElseIf column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill Then
                    column.MinimumWidth = 2
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    column.MinimumWidth = column.Width
                End If
                iGridWidth += column.Width
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
            Me.Height = iAvailableGridHeight + 135 - 24
        End If
        If Me.dgvList.RowCount > Me.dgvList.DisplayedRowCount(False) Then Me.Width += 20

        If iMaxGridHeight < iAvailableGridHeight Then
            Me.Location = New Point(Int((My.Computer.Screen.WorkingArea.Width - Me.Width) / 2), Int((My.Computer.Screen.WorkingArea.Height - Me.Height) / 2))
        Else
            Me.Location = New Point(Int((My.Computer.Screen.WorkingArea.Width - Me.Width) / 2), 0)
        End If
    End Sub

    Private Sub dgvList_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvList.CellContentClick
        If e.RowIndex = -1 Then Return
        If Me.dgvList.Columns(e.ColumnIndex).Name = "SalesBillCode" Then
            If blCanBrowseSalesBill Then
                If frmMain.dtAllowedRight.Select("RightName='SalesBillBrowse'").Length = 0 Then
                    MessageBox.Show("对不起！您没有浏览销售单的权限。    " & Chr(13) & "Sorry, you have no right to browse sales bill.    ", "您无权浏览销售单 No right to browse sales bill!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    blCanBrowseSalesBill = False
                    frmMain.statusText.Text = "对不起！您没有浏览销售单的权限。"
                Else
                    With frmSelling
                        If .IsHandleCreated Then
                            .Activate()
                            .WindowState = FormWindowState.Maximized
                            If .sSalesBillID <> Me.dgvList("SalesBillID", Me.dgvList.CurrentRow.Index).Value.ToString Then
                                If .blIsChanged Then
                                    Dim bAnswer As DialogResult = MessageBox.Show("是否在打开销售单之前，先保存当前销售单？    ", "当前销售单未保存！", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                                    If bAnswer = Windows.Forms.DialogResult.Cancel OrElse (bAnswer = Windows.Forms.DialogResult.Yes AndAlso Not .SaveChanges()) Then
                                        Me.Activate()
                                        frmMain.statusText.Text = "因为存在未保存销售单，所以不能打开销售单。"
                                        Return
                                    End If
                                End If
                                .sSalesBillID = Me.dgvList("SalesBillID", Me.dgvList.CurrentRow.Index).Value.ToString
                                .LoadSalesBill()
                            End If
                        Else
                            Me.Cursor = Cursors.WaitCursor
                            frmMain.statusText.Text = "正在打开销售单……"
                            frmMain.statusMain.Refresh()

                            .sSalesBillID = Me.dgvList("SalesBillID", Me.dgvList.CurrentRow.Index).Value.ToString
                            .Show()
                            If .IsHandleCreated Then
                                .MdiParent = frmMain
                                .WindowState = FormWindowState.Maximized
                                .Activate()
                            End If

                            If frmMain.statusText.Text.IndexOf("……") > -1 Then frmMain.statusText.Text = "就绪。"
                            Me.Cursor = Cursors.Default
                        End If

                        If .IsHandleCreated Then
                            If .dgvNormalCard.CurrentRow IsNot Nothing Then .dgvNormalCard.CurrentRow.Selected = False
                            If .dgvRebateCard.CurrentRow IsNot Nothing Then .dgvRebateCard.CurrentRow.Selected = False
                            If .dgvPayment.CurrentRow IsNot Nothing Then .dgvPayment.CurrentRow.Selected = False
                        End If

                        .btnOK.Enabled = False
                        .btnPrintTicket.Enabled = False
                        .btnPrintInvoice.Enabled = False
                        .btnViewActivation.Enabled = True
                        .btnNewSalesBill.Enabled = False
                    End With
                End If
            Else
                frmMain.statusText.Text = "对不起！您没有浏览销售单的权限。"
            End If
        End If
    End Sub

    Private Sub dgvList_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvList.CellFormatting
        If Me.dgvList.Columns(e.ColumnIndex).GetType.Name = "DataGridViewLinkColumn" Then
            If Me.dgvList.CurrentRow IsNot Nothing AndAlso Me.dgvList.CurrentRow.Index = e.RowIndex AndAlso Me.dgvList.CurrentRow.Selected Then
                CType(Me.dgvList(e.ColumnIndex, e.RowIndex), DataGridViewLinkCell).LinkColor = Color.Yellow
            Else
                CType(Me.dgvList(e.ColumnIndex, e.RowIndex), DataGridViewLinkCell).LinkColor = Color.Blue
            End If
        ElseIf Me.dgvList.Columns(e.ColumnIndex).Name = "OperationState" AndAlso (e.Value.ToString.IndexOf("失败") > -1 OrElse e.Value.ToString.IndexOf("没有通过") > -1) Then
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
        ElseIf sCardNo.IndexOf("2336") <> 0 AndAlso sCardNo.Length < 17 Then
            Me.lblCardError.Text = "（卡号位数不足 17 位！）"
        ElseIf sCardNo.IndexOf("2336") = 0 AndAlso sCardNo.Length < 19 Then
            Me.lblCardError.Text = "（卡号位数不足 19 位！）"
        ElseIf sCardNo.IndexOf("2336") = 0 AndAlso sCardNo <> ShoppingCardNo.GetFullCardNo(sCardNo.Substring(0, 18)) Then
            Me.lblCardError.Text = "（卡号校验码错误！）"
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
        Dim bAnswer As DialogResult = Windows.Forms.DialogResult.No
        If dvList.Table.Select("BatchID=" & Me.dgvList("BatchID", Me.dgvList.CurrentRow.Index).Value.ToString).Length = 1 Then
            bAnswer = MessageBox.Show("您确实想删除该卡""" & Me.dgvList("CardNo", Me.dgvList.CurrentRow.Index).Value.ToString & """的激活撤销申请吗？    " & Chr(13) & Chr(13) & "（只能删除由您自己添加的且未被确认的激活撤销记录。）    ", "请确认删除激活撤销申请：", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        ElseIf dvList.Table.Select("BatchID=" & Me.dgvList("BatchID", Me.dgvList.CurrentRow.Index).Value.ToString & " And OperationState>1").Length > 0 Then
            MessageBox.Show("由于删除激活撤销申请时将删除同一批次的所有购物卡的申请，    " & Chr(13) & _
                            "但当前卡所在的批次的其它购物卡的处理状态并不一致。    " & Chr(13) & Chr(13) & _
                            "所以不能删除当前卡及同一批次的其它卡的激活撤销申请！    ", _
                            "不能删除激活撤销申请！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.btnDelete.Enabled = False
        Else
            bAnswer = MessageBox.Show("删除当前卡的激活撤销申请时将同时删除所在批次的其它购物卡的申请。    " & Chr(13) & Chr(13) & _
                                      "所以，您即将删除当前卡所在批次共 " & Format(dvList.Table.Select("BatchID=" & Me.dgvList("BatchID", Me.dgvList.CurrentRow.Index).Value.ToString).Length, "#,0") & " 张（次）购物卡的撤销申请。    " & Chr(13) & Chr(13) & _
                                      "您是否确认删除所在批次的购物卡的激活撤销申请？    ", _
                                      "请确认删除激活撤销申请：", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        End If
        If bAnswer = Windows.Forms.DialogResult.No Then Return
        Me.Refresh()

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在删除激活撤销记录……"
        frmMain.statusMain.Refresh()

        Dim DB As New DataBase
        DB.Open()
        If DB.IsConnected Then
            Dim dtResult As DataTable = DB.GetDataTable("Exec CULCancelActivationDelete " & Me.dgvList("BatchID", Me.dgvList.CurrentRow.Index).Value.ToString & "," & frmMain.sSSID), blDeleted As Boolean = True
            DB.Close()
            If dtResult Is Nothing Then
                frmMain.statusText.Text = "删除激活撤销记录失败！"
                blDeleted = False
            Else
                Select Case dtResult.Rows(0)("Result").ToString
                    Case "AlreadyDeleted"
                        frmMain.statusText.Text = "当前激活撤销记录已被他人删除。"
                    Case "AlreadyValidated"
                        MessageBox.Show("当前激活撤销记录已被他人确认！您已不能删除它。    ", "不能删除激活撤销记录！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        frmMain.statusText.Text = "当前激活撤销记录已被他人确认！您已不能删除它。"
                        blDeleted = False
                    Case "OK"
                        frmMain.statusText.Text = "删除激活撤销申请记录成功。"
                    Case Else
                        MessageBox.Show("删除激活撤销记录时出现错误！下面是数据库的内部错误提示：    " & Chr(13) & Chr(13) & dtResult.Rows(0)("ErrorInfo").ToString & Space(4) & Chr(13) & Chr(13) & "请放弃保存，在关闭窗口后重试。如果仍有问题，请联系软件开发人员。    ", "删除激活撤销记录失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        frmMain.statusText.Text = "删除激活撤销记录失败！"
                        blDeleted = False
                End Select
            End If

            If blDeleted Then
                Dim dvCULParameter As DataView = frmMain.dtLoginStructure.Copy.DefaultView, sBatchID As String = Me.dgvList("BatchID", Me.dgvList.CurrentRow.Index).Value.ToString

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
                    dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "86" & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
                    dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "92" & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
                    dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "94" & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()

                    dvCULParameter.Table.Rows.Add(drCUL("AreaID"), frmMain.signCardBin & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
                Next
                dvCULParameter.RowFilter = ""
                dvCULParameter.Table.AcceptChanges()

                Dim dtCard As New DataTable(), dvCard As DataView, iSucesses As Integer = 0
                dtCard.Columns.Add("CardNo", System.Type.GetType("System.String"))
                For Each drCard As DataRow In dvList.Table.Select("BatchID=" & sBatchID)
                    dtCard.Rows.Add(drCard("CardNo").ToString).AcceptChanges()
                    drCard.Delete() : drCard.AcceptChanges()
                Next
                dvCard = dtCard.DefaultView

                dvCard.RowFilter = "CardNo Like '2%'"
                If dvCard.Count > 0 Then iSucesses = ShoppingCardOperation.CRFCardAutoFreeze(False, dvCULParameter.Table, dvCard.ToTable(True, "CardNo"))
                dvCard.RowFilter = "CardNo Not Like '2%'"
                If dvCard.Count > 0 Then iSucesses += ShoppingCardOperation.PaperCardAutoFreeze(False, dvCULParameter.Table, dvCard.ToTable(True, "CardNo"))
                If iSucesses = 0 Then
                    MessageBox.Show("系统在对已取消激活撤销申请的购物卡执行自动解冻时失败！    " & Chr(13) & Chr(13) & "为确保这" & IIf(dtCard.Rows.Count = 1, "张", "些") & "购物卡能被正常使用，请您手工执行解冻操作。    ", "购物卡自动解冻失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf iSucesses < dtCard.Rows.Count Then
                    MessageBox.Show("系统在对已取消激活撤销申请的购物卡执行自动解冻时部分失败！    " & Chr(13) & Chr(13) & "为确保这" & IIf(dtCard.Rows.Count - iSucesses = 1, "张", "些") & "购物卡能被正常使用，请您手工执行解冻操作。    ", "购物卡自动解冻失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
                dvCULParameter.Dispose() : dvCULParameter = Nothing
                dtCard.Dispose() : dtCard = Nothing : dvCard.Dispose() : dvCard = Nothing

                If Me.dgvList.CurrentRow IsNot Nothing Then
                    Me.dgvList.CurrentRow.Selected = False
                    Me.dgvList.CurrentRow.Selected = True
                ElseIf Me.dgvList.RowCount > 0 Then
                    Me.dgvList.Rows(0).Selected = False
                    Me.dgvList.Rows(0).Selected = True
                Else
                    Me.btnDelete.Enabled = False
                End If
            End If
        Else
            frmMain.statusText.Text = "系统因连接不到数据库而无法删除激活撤销申请记录。请检查数据库连接。"
        End If
        Me.Cursor = Cursors.Default
    End Sub
End Class