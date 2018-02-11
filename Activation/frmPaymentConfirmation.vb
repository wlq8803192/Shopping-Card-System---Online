Public Class frmPaymentConfirmation

    Private blSkipDeal As Boolean = True, sTimerType As String = "DoubleClick", sReceivedDateError As String = "", bClicks As Byte = 0, sRowFileter As String = "", sSummaryInfo As String = ""
    Private dtStore As DataTable, dvLoaded As DataView, dtToday As Date, blCanBrowseSalesBill As Boolean = True
    Public dvList As DataView

    Private Sub frmPaymentConfirmation_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.btnSave.Enabled AndAlso MessageBox.Show("您已经确认了若干付款单，但还未保存。    " & Chr(13) & Chr(13) & "是否放弃保存而关闭窗口？    ", "是否放弃保存？", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then e.Cancel = True
        If frmMain.statusText.Text.IndexOf("无法") = -1 Then frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub frmPaymentConfirmation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If frmMain.dtLoginStructure.Select("AreaType='S'").Length = 0 Then
            MessageBox.Show("没有门店，不能打开""转账/支票""到账确认窗口！    " & Chr(13) & Chr(13) & "请找系统管理员建立门店。    ", "未发现门店！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close() : Return
        End If

        blCanBrowseSalesBill = (frmMain.dtAllowedRight.Select("RightName='SalesBillBrowse'").Length > 0)

        Dim dvStore As DataView = frmMain.dtLoginStructure.Copy.DefaultView
        dvStore.RowFilter = "AreaType='S'"
        If dvStore.Count > 1 Then
            Dim allStore As DataRow = dvStore.Table.Rows.Add(-1)
            allStore("AreaName") = "（所有门店）" : allStore("AreaType") = "S" : allStore("SortCode") = ""
        End If
        dvStore.Sort = "SortCode"
        dtStore = dvStore.ToTable(False, "AreaID", "AreaName")
        dtStore.AcceptChanges()
        dvStore.Dispose() : dvStore = Nothing

        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打开""转账/支票""到账确认窗口。请检查数据库连接。"
            Me.Close() : Return
        End If

        Try '先将新销售单移入对应的Pending表
            DB.ModifyTable("Exec MoveNew2Pending " & frmMain.sLoginUserID)
        Catch
        End Try

        Try
            Dim sSQL As String = "Exec GetPaymentList "
            If dtStore.Rows.Count = 1 Then
                sSQL = sSQL & "@StoreID=" & dtStore.Rows(0)("AreaID").ToString
            Else
                sSQL = sSQL & "@LoginUserID=" & frmMain.sLoginUserID
            End If
            dvList = DB.GetDataTable(sSQL & ",@GetAllUnconfirmed=1").DefaultView '先取得所有未完全激活的记录
            dvList.Table.PrimaryKey = New DataColumn() {dvList.Table.Columns("PaymentID")}
            dvList.Table.Merge(DB.GetDataTable(sSQL)) '半个月的记录
            dtToday = DB.GetDataTable("Select Convert(datetime, Convert(varchar(10), GETDATE(), 101))").Rows(0)(0)
            DB.Close()
        Catch
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开""转账/支票""到账确认窗口。请联系软件开发人员。"
            DB.Close() : Me.Close()
            Return
        End Try

        dvLoaded = New DataView(New DataTable())
        dvLoaded.Table.Columns.Add("StoreID", System.Type.GetType("System.Int16"))
        dvLoaded.Table.Columns.Add("ReceivedDate", System.Type.GetType("System.DateTime"))
        dvLoaded.Table.Columns.Add("LoadedTime", System.Type.GetType("System.DateTime"))
        dvLoaded.Table.Columns.Add("IsRefreshed", System.Type.GetType("System.Boolean"))
        Dim drLoaded As DataRowView
        For Each drStore As DataRow In dtStore.Rows
            For bDay As Byte = 0 To 14
                drLoaded = dvLoaded.AddNew
                drLoaded("StoreID") = drStore("AreaID")
                drLoaded("ReceivedDate") = DateAdd(DateInterval.Day, -bDay, dtToday)
                drLoaded("LoadedTime") = Now()
                drLoaded("IsRefreshed") = 0
                drLoaded.EndEdit() : drLoaded.Row.AcceptChanges()
            Next
        Next

        With Me.cbbStore
            .DataSource = dtStore
            .ValueMember = "AreaID"
            .DisplayMember = "AreaName"
            .SelectedIndex = 0
        End With

        With Me.cbbReceivedDate
            .Items.Add("（所有日期）")
            .Items.Add("（最近半个月）")
            For bDay As Byte = 0 To 14
                .Items.Add(Format(DateAdd(DateInterval.Day, -bDay, dtToday), "yyyy\/MM\/dd"))
            Next
            .Items.Add("选择其它日期…")
            .MaxDropDownItems = .Items.Count
            .SelectedIndex = 1
        End With

        Me.cbbPaymentTerm.SelectedIndex = 0
        Me.cbbConfirmationState.SelectedIndex = 0

        dvList.RowFilter = ""
        sRowFileter = ""
        Dim dtTemp As DataTable = dvList.ToTable
        With Me.dgvList
            .DataSource = dvList
            .Columns(0).Visible = False
            .Columns(1).Visible = False
            .Columns(2).Visible = False
            With .Columns(3)
                .HeaderText = "门店"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Width += 0
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
            End With
            Dim linkColumn As New DataGridViewLinkColumn
            linkColumn.DataPropertyName = "SalesBillCode"
            .Columns.RemoveAt(4)
            .Columns.Insert(4, linkColumn)
            With .Columns(4)
                .HeaderText = "销售单号"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 90
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(5)
                .HeaderText = "客户名称"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .MinimumWidth = .Width
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(6)
                .HeaderText = "付款方式"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 60
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(7)
                .HeaderText = "付款单位"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .MinimumWidth = .Width
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(8)
                .HeaderText = "转账/支票号"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(9)
                .HeaderText = "金额"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,0.00"
                .MinimumWidth = 50
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(10)
                .HeaderText = "开单日期"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Format = "yyyy\/MM\/dd"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 70
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(11)
                .HeaderText = "等待天数"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,0"
                .MinimumWidth = 50
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            Dim checkColomn As New DataGridViewCheckBoxColumn
            checkColomn.DataPropertyName = "IsValidated"
            .Columns.RemoveAt(12)
            .Columns.Insert(12, checkColomn)
            With .Columns(12)
                .HeaderText = "确认状态"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 70
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(13)
                .HeaderText = "确认者"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .Visible = (dtTemp.Select("Isnull(AuditorName,'')<>''").Length > 0)
            End With
            With .Columns(14)
                .HeaderText = "确认时间"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Width = 120
                .DefaultCellStyle.Format = "yyyy\/MM\/dd HH:mm:ss"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
                .Visible = Me.dgvList.Columns(13).Visible
            End With
            With .Columns(15)
                .HeaderText = "备注"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .Visible = (dtTemp.Select("Isnull(Remarks,'')<>''").Length > 0)
            End With
            With .Columns(16)
                .HeaderText = "处理状态"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.BackColor = SystemColors.Info
                .DefaultCellStyle.ForeColor = Color.Green
                .DefaultCellStyle.SelectionForeColor = Color.LightGreen
                .DefaultCellStyle.Font = New Font(Me.dgvList.Font, FontStyle.Bold)
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .Visible = False
            End With
            With .Columns(17)
                .HeaderText = "状态说明"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.BackColor = SystemColors.Info
                .DefaultCellStyle.Font = New Font(Me.dgvList.Font, FontStyle.Bold)
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .Visible = False
            End With
        End With
        dtTemp.Dispose() : dtTemp = Nothing
        For Each column As DataGridViewColumn In Me.dgvList.Columns
            column.Name = dvList.Table.Columns(column.Index).ColumnName
        Next

        'If Not ToolStripManager.VisualStylesEnabled Then
        '    Me.dgvList.Top -= 2
        '    Me.dgvList.Height += 2
        'End If

        Me.dgvList.Select()
        blSkipDeal = False
        Me.cbbReceivedDate.SelectedIndex = 0
        Me.SummaryInfo()
    End Sub

    Private Sub cbbStore_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbStore.SelectedIndexChanged
        If blSkipDeal Then Return
        Me.GetPaymentList()
    End Sub

    Private Sub cbbReceivedDate_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbReceivedDate.Enter
        If Me.pnlReceivedDate.Visible Then Me.pnlReceivedDate.Visible = False
    End Sub

    Private Sub cbbReceivedDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbbReceivedDate.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Escape Then Return
        If e.KeyCode = Keys.Up OrElse e.KeyCode = Keys.Down Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        Dim blShowCalendar As Boolean = False
        If e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then
            blShowCalendar = True
        ElseIf (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            blShowCalendar = True
        ElseIf e.KeyCode = Keys.OemQuestion OrElse e.KeyCode = Keys.Divide Then
            blShowCalendar = True
        End If
        If blShowCalendar Then
            sReceivedDateError = ""
            If dtToday < Today Then
                Me.mtcReceivedDate.MaxDate = Today
            Else
                Me.mtcReceivedDate.MaxDate = dtToday
            End If
            Me.pnlReceivedDate.Visible = True
            Me.mtcReceivedDate.Select()
            Dim dtSelectedDate As Date = Me.mtcReceivedDate.SelectionStart
            Me.mtcReceivedDate.SetDate(DateAdd(DateInterval.Day, -1, dtSelectedDate))
            Me.mtcReceivedDate.SetDate(dtSelectedDate)
            frmMain.statusText.Text = "请按回车或重新单击已选择的日期来确定日期。"
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub cbbReceivedDate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbReceivedDate.SelectedIndexChanged
        If blSkipDeal Then Return

        blSkipDeal = True
        Me.cbbConfirmationState.Items.Clear()
        If Me.cbbReceivedDate.SelectedIndex = 0 Then
            Me.cbbConfirmationState.Items.Add("未确认到账")
            Me.cbbConfirmationState.SelectedIndex = 0
        Else
            Me.cbbConfirmationState.Items.Add("（全部）")
            Me.cbbConfirmationState.Items.Add("未确认到账")
            Me.cbbConfirmationState.Items.Add("已确认到账")
            Me.cbbConfirmationState.SelectedIndex = 1
        End If
        blSkipDeal = False

        sReceivedDateError = ""
        If Me.cbbReceivedDate.Text = "选择其它日期…" Then
            If dtToday < Today Then
                Me.mtcReceivedDate.MaxDate = Today
            Else
                Me.mtcReceivedDate.MaxDate = dtToday
            End If
            Me.pnlReceivedDate.Visible = True
            Me.mtcReceivedDate.Select()
            sTimerType = "SetDate"
            Me.theTimer.Interval = 100
            Me.theTimer.Enabled = True
            frmMain.statusText.Text = "请按回车来确定已选择的日期或双击日期来选择并确定日期。"
            Return
        End If
        If Me.cbbReceivedDate.SelectedIndex = -1 Then Return

        If Me.cbbStore.SelectedValue <> -1 AndAlso IsDate(Me.cbbReceivedDate.Text) Then
            If CDate(Me.cbbReceivedDate.Text) = dtToday Then
                Me.btnRefresh.Visible = True
            Else
                Try
                    Me.btnRefresh.Visible = (dvList.Table.Compute("Count(PaymentID)", "StoreID=" & Me.cbbStore.SelectedValue.ToString & " And ReceivedDate='" & Me.cbbReceivedDate.Text & "' And Isnull(AuditorName,'')=''") > 0)
                Catch
                    Me.btnRefresh.Visible = False
                End Try
            End If
        Else
            Me.btnRefresh.Visible = False
        End If

        Me.SetRowFilter()
    End Sub

    Private Sub cbbReceivedDate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbbReceivedDate.Validating
        If sReceivedDateError <> "" Then
            frmMain.statusText.Text = sReceivedDateError
            e.Cancel = True
        End If
    End Sub

    Private Sub mtcReceivedDate_DateChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles mtcReceivedDate.DateChanged
        If Me.mtcReceivedDate.Visible = False Then Return
        Me.cbbReceivedDate.Text = Format(Me.mtcReceivedDate.SelectionStart, "yyyy\/MM\/dd")
    End Sub

    Private Sub mtcReceivedDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mtcReceivedDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cbbReceivedDate.Select()
            Me.GetPaymentList()
        End If
    End Sub

    Private Sub mtcReceivedDate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles mtcReceivedDate.Leave
        Me.pnlReceivedDate.Visible = False
    End Sub

    Private Sub mtcReceivedDate_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mtcReceivedDate.MouseDown
        If e.Button <> Windows.Forms.MouseButtons.Left Then Return
        Dim theR As Rectangle = Me.mtcReceivedDate.Bounds
        theR.Offset(0, 35)
        If Not theR.Contains(Me.mtcReceivedDate.PointToClient(MousePosition)) Then theR = Nothing : Return
        theR = Nothing

        bClicks += 1
        If bClicks = 2 Then
            Me.cbbReceivedDate.Select()
            Me.GetPaymentList()
        End If
        sTimerType = "DoubleClick"
        Me.theTimer.Interval = 500
        Me.theTimer.Enabled = True
    End Sub

    Private Sub cbbPaymentTerm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbPaymentTerm.SelectedIndexChanged
        If blSkipDeal Then Return
        Me.SetRowFilter()
    End Sub

    Private Sub cbbConfirmationState_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbConfirmationState.SelectedIndexChanged
        If blSkipDeal Then Return
        Me.SetRowFilter()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        dvLoaded.RowFilter = "StoreID=" & Me.cbbStore.SelectedValue.ToString & " And ReceivedDate='" & Me.cbbReceivedDate.Text & "'"

        If DateDiff(DateInterval.Minute, dvLoaded(0)("LoadedTime"), Now()) < 5 Then
            If dvLoaded(0)("IsRefreshed") = 0 Then
                MessageBox.Show("距离该店该日的数据下载时间还不足 5 分钟。    " & Chr(13) & Chr(13) & "数据下载时间： " & Format(dvLoaded(0)("LoadedTime"), "HH:mm") & Chr(13) & Chr(13) & "请在数据下载时间的 5 分钟后再刷新。    ", "刷新不能过于频繁！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("距离该店该日的上次刷新时间还不足 5 分钟。    " & Chr(13) & Chr(13) & "上次刷新时间： " & Format(dvLoaded(0)("LoadedTime"), "HH:mm") & Chr(13) & Chr(13) & "请在上次刷新时间的 5 分钟后再刷新。    ", "刷新不能过于频繁！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            Return
        End If

        Try
            If dvList.Table.Compute("Count(PaymentID)", "StoreID=" & Me.cbbStore.SelectedValue.ToString & " And ReceivedDate='" & Me.cbbReceivedDate.Text & "' And IsValidated=1 And Isnull(AuditorName,'')=''") > 0 Then
                If MessageBox.Show("注意：刷新付款单将清除您在该店该日所做的未保存的确认！     " & Chr(13) & Chr(13) & "门店： " & Me.cbbStore.Text & Space(4) & Chr(13) & "日期： " & Me.cbbReceivedDate.Text & Space(4) & Chr(13) & Chr(13) & "您是否确认刷新该店该日的付款单？    ", "请确认刷新付款单：", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then Return
            End If
        Catch
        End Try

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在刷新付款单（店： " & Me.cbbStore.Text & "  日期： " & Me.cbbReceivedDate.Text & "）……"
        frmMain.statusMain.Refresh()

        blSkipDeal = True
        Dim iSelectedIndex As Integer = Me.cbbStore.SelectedIndex
        Me.cbbStore.SelectedIndex = -1
        blSkipDeal = False
        Me.cbbStore.SelectedIndex = iSelectedIndex

        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法刷新付款单。请检查数据库连接。"
            Me.Cursor = Cursors.Default
            Return
        End If

        Try '先将新销售单移入对应的Pending表
            If DB.GetDataTable("Exec MoveNew2Pending " & frmMain.sLoginUserID).Rows(0)(0).ToString = "Busy" AndAlso CDate(Me.cbbReceivedDate.Text) = dtToday Then
                MessageBox.Show("对不起，系统繁忙！请五分钟后再刷新。    ", "系统繁忙！", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch
        End Try

        Try
            Dim dtList = DB.GetDataTable("Exec GetPaymentList @StoreID=" & Me.cbbStore.SelectedValue.ToString & ",@ReceivedDate='" & Me.cbbReceivedDate.Text & "'").Copy

            blSkipDeal = True
            Me.dgvList.Columns("OperationResult").Visible = False
            Me.dgvList.Columns("ResultReason").Visible = False
            Me.chbDisplaySelected.Checked = False
            Me.chbDisplaySelected.Visible = False
            blSkipDeal = False

            If dtList.Rows.Count = 0 Then
                MessageBox.Show("今日还没有付款方式为""转账""或""支票""的付款单！    ", "没有付款方式为""转账""或""支票""的付款单！", MessageBoxButtons.OK, MessageBoxIcon.Information)
                frmMain.statusText.Text = "今日还没有付款方式为""转账""或""支票""的付款单！"
            Else
                dvList.Table.Merge(dtList.Copy, False)

                Me.dgvList.Select()
                Me.dgvList("IsValidated", 0).Selected = True
                Me.dgvList.Rows(0).Selected = True
                Me.SummaryInfo()
            End If
            dtList.Dispose() : dtList = Nothing
            dvLoaded(0)("LoadedTime") = Now : dvLoaded(0)("IsRefreshed") = 1 : dvLoaded(0).Row.AcceptChanges()
        Catch
            frmMain.statusText.Text = "系统因在检索数据时出错而无法刷新付款单。请联系软件开发人员。"
        End Try

        Me.chbDisplaySelected.Visible = (dvList.Table.Select("IsValidated=1 And Isnull(AuditorName,'')=''").Length > 0)
        Me.btnSave.Enabled = Me.chbDisplaySelected.Visible

        DB.Close()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgvList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvList.CellContentClick
        If (Me.dgvList.Columns(e.ColumnIndex).Name <> "SalesBillCode" AndAlso Me.dgvList.Columns(e.ColumnIndex).Name <> "IsValidated") OrElse e.RowIndex = -1 Then Return

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
        Else
            If Me.dgvList.Columns("OperationResult").Visible OrElse dvList.Table.Select("Isnull(OperationResult,'')<>''").Length > 0 Then
                For Each dr As DataRow In dvList.Table.Select("Isnull(OperationResult,'')<>''")
                    If dr("ResultReason").ToString.IndexOf("销售单已被") = 0 OrElse dr("ResultReason").ToString.IndexOf("付款方式已被") = 0 Then
                        dr.Delete()
                    Else
                        dr("OperationResult") = DBNull.Value
                        dr("ResultReason") = DBNull.Value
                    End If
                    dr.AcceptChanges()
                Next
                Me.dgvList.Columns("OperationResult").Visible = False
                Me.dgvList.Columns("ResultReason").Visible = False

                If dvList.Table.Select("IsValidated=1 And Isnull(AuditorName,'')<>''").Length = 0 Then
                    Me.btnSave.Enabled = False
                    Me.chbDisplaySelected.Checked = False
                    Me.chbDisplaySelected.Visible = False
                End If
                Return
            End If

            If Me.dgvList("IsValidated", e.RowIndex).Value AndAlso Me.dgvList("AuditorName", e.RowIndex).Value.ToString <> "" Then
                MessageBox.Show("该张付款单已被确认且已保存，再也不能取消对该付款单的到账确认！    ", "不能取消确认！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                frmMain.statusText.Text = "不能取消对该付款单的到账确认。"
                Return
            End If

            If frmMain.sLoginAreaID = "21" AndAlso (dvList(e.RowIndex)("MediaNo").ToString = "0000000" OrElse dvList(e.RowIndex)("MediaNo").ToString = "０００００００" OrElse dvList(e.RowIndex)("MediaNo").ToString.IndexOf("废单") > -1) Then '上海JV专用
                MessageBox.Show("上海JV请注意：    " & Chr(13) & Chr(13) & "该张付款单的" & IIf(dvList(e.RowIndex)("PaymentTerm").ToString = "转账", "账号", "支票号") & "不合法！请不要确认该单。    ", IIf(dvList(e.RowIndex)("PaymentTerm").ToString = "转账", "账号", "支票号") & "不合法！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                frmMain.statusText.Text = IIf(dvList(e.RowIndex)("PaymentTerm").ToString = "转账", "账号", "支票号") & "不合法！请不要确认该付款单。"
                Return
            End If

            dvList(e.RowIndex)("IsValidated") = Not dvList(e.RowIndex)("IsValidated")
            dvList(e.RowIndex).EndEdit()
            If dvList.Table.Select("IsValidated=1 And Isnull(AuditorName,'')=''").Length = 0 Then
                Me.btnSave.Enabled = False
                Me.chbDisplaySelected.Visible = False
            Else
                Me.btnSave.Enabled = True
                Me.chbDisplaySelected.Visible = True
            End If

            Dim dtTemp As DataTable = dvList.ToTable(False, "PaymentAMT", "IsValidated", "AuditorName")
            If dtTemp.Compute("Sum(PaymentAMT)", "IsValidated=1 And Isnull(AuditorName,'')=''").ToString = "" Then
                frmMain.statusText.Text = sSummaryInfo & "。"
            Else
                frmMain.statusText.Text = sSummaryInfo & "；准备确认付款单数：" & Format(dtTemp.Compute("Count(PaymentAMT)", "IsValidated=1 And Isnull(AuditorName,'')=''"), "#,0") & " 张，准备确认付款金额：" & Format(dtTemp.Compute("Sum(PaymentAMT)", "IsValidated=1 And Isnull(AuditorName,'')=''"), "#,0.00").Replace(".00", "") & " 元。"
            End If
            dtTemp.Dispose() : dtTemp = Nothing
        End If
    End Sub

    Private Sub dgvList_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvList.CellFormatting
        If Me.dgvList.Columns(e.ColumnIndex).Name = "AuditorName" AndAlso Me.dgvList(e.ColumnIndex, e.RowIndex).Value.ToString <> "" Then Me.dgvList.Rows(e.RowIndex).DefaultCellStyle.BackColor = SystemColors.Control
        If Me.dgvList.Columns(e.ColumnIndex).GetType.Name = "DataGridViewLinkColumn" Then
            If Me.dgvList.CurrentRow IsNot Nothing AndAlso Me.dgvList.CurrentRow.Index = e.RowIndex AndAlso Me.dgvList.CurrentRow.Selected Then
                CType(Me.dgvList(e.ColumnIndex, e.RowIndex), DataGridViewLinkCell).LinkColor = Color.Yellow
            Else
                CType(Me.dgvList(e.ColumnIndex, e.RowIndex), DataGridViewLinkCell).LinkColor = Color.Blue
            End If
        ElseIf Me.dgvList.Columns(e.ColumnIndex).Name = "Remarks" Then
            If e.Value.ToString.IndexOf("已确认") = 0 Then
                e.CellStyle.ForeColor = Color.Red
                e.CellStyle.SelectionForeColor = Color.Brown
            Else
                e.CellStyle.ForeColor = Color.Green
                e.CellStyle.SelectionForeColor = SystemColors.Info
            End If
        ElseIf Me.dgvList.Columns(e.ColumnIndex).Name = "PayerName" AndAlso Me.dgvList("CustomerName", e.RowIndex).Value.ToString <> "（个人客户）" AndAlso Me.dgvList("CustomerName", e.RowIndex).Value.ToString <> Me.dgvList("PayerName", e.RowIndex).Value.ToString Then
            e.CellStyle.ForeColor = Color.Red
            e.CellStyle.SelectionForeColor = Color.Brown
        End If
    End Sub

    Private Sub dgvList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvList.KeyDown
        If e.Alt Then Return
        If e.Control OrElse (e.KeyCode >= Keys.A AndAlso e.KeyCode <= Keys.Z) OrElse (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            With frmSearchPayment
                If Not e.Control Then
                    .sKeyCode = e.KeyCode.ToString
                    If e.KeyCode >= Keys.A AndAlso e.KeyCode <= Keys.Z Then
                        If (My.Computer.Keyboard.CapsLock AndAlso My.Computer.Keyboard.ShiftKeyDown) OrElse (Not My.Computer.Keyboard.CapsLock AndAlso Not My.Computer.Keyboard.ShiftKeyDown) Then .sKeyCode = .sKeyCode.ToLower
                    Else
                        .rdbByMediaNo.Checked = True
                    End If
                End If
            End With
            Me.SearchPayment()
        End If
    End Sub

    Private Sub chbDisplaySelected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbDisplaySelected.CheckedChanged
        If Me.chbDisplaySelected.Checked Then
            Me.pnlConditions.Enabled = False
            dvList.RowFilter = "IsValidated=1 And (Isnull(AuditorName,'')='' Or Isnull(OperationResult,'')<>'')"
        Else
            Me.pnlConditions.Enabled = True
            dvList.RowFilter = sRowFileter
        End If

        Dim dtTemp As DataTable = dvList.ToTable
        With Me.dgvList
            .Columns("AuditorName").Visible = (dtTemp.Select("Isnull(AuditorName,'')<>''").Length > 0)
            .Columns("ValidatedTime").Visible = .Columns("AuditorName").Visible
            .Columns("OperationResult").Visible = (dtTemp.Select("Isnull(OperationResult,'')<>''").Length > 0)
            .Columns("ResultReason").Visible = (dtTemp.Select("Isnull(ResultReason,'')<>''").Length > 0)
        End With
        For Each column As DataGridViewColumn In Me.dgvList.Columns
            If column.Visible Then
                If column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells Then
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                ElseIf column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill Then
                    column.MinimumWidth = 2
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    column.MinimumWidth = column.Width
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End If
            End If
        Next
        dtTemp.Dispose() : dtTemp = Nothing

        Me.dgvList.Select()
        If Me.chbDisplaySelected.Checked Then Me.dgvList.FirstDisplayedScrollingColumnIndex = Me.dgvList.Columns("IsValidated").Index

        Me.SummaryInfo()
    End Sub

    Private Sub theTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles theTimer.Tick
        Me.theTimer.Enabled = False
        If sTimerType = "DoubleClick" Then
            bClicks = 0
        Else
            blSkipDeal = True
            Me.mtcReceivedDate.Select()
            Dim dtSelectedDate As Date = Me.mtcReceivedDate.SelectionStart
            Me.mtcReceivedDate.SetDate(DateAdd(DateInterval.Day, -1, dtSelectedDate))
            Me.mtcReceivedDate.SetDate(dtSelectedDate)
            blSkipDeal = False
        End If
    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Me.SearchPayment()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Me.SaveChanges()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub SummaryInfo()
        Dim dtTemp As DataTable = dvList.ToTable(False, "PaymentAMT", "IsValidated", "AuditorName")
        If dtTemp.Rows.Count = 0 Then
            sSummaryInfo = "没有任何付款单。"
            frmMain.statusText.Text = sSummaryInfo
        Else
            sSummaryInfo = "总计 -- 付款单数： " & Format(dtTemp.Rows.Count, "#,0") & " 张，付款金额： " & Format(dtTemp.Compute("Sum(PaymentAMT)", ""), "#,0.00").Replace(".00", "") & " 元"
            If dtTemp.Compute("Sum(PaymentAMT)", "Isnull(AuditorName,'')<>''").ToString <> "" Then
                sSummaryInfo = sSummaryInfo & "；已确认付款单数：" & Format(dtTemp.Compute("Count(PaymentAMT)", "Isnull(AuditorName,'')<>''"), "#,0") & " 张，已确认付款金额： " & Format(dtTemp.Compute("Sum(PaymentAMT)", "Isnull(AuditorName,'')<>''"), "#,0.00").Replace(".00", "") & " 元"
            End If
            If dtTemp.Compute("Sum(PaymentAMT)", "IsValidated=1 And Isnull(AuditorName,'')=''").ToString = "" Then
                frmMain.statusText.Text = sSummaryInfo & "。"
            Else
                frmMain.statusText.Text = sSummaryInfo & "；准备确认付款单数：" & Format(dtTemp.Compute("Count(PaymentAMT)", "IsValidated=1 And Isnull(AuditorName,'')=''"), "#,0") & " 张，准备确认付款金额：" & Format(dtTemp.Compute("Sum(PaymentAMT)", "IsValidated=1 And Isnull(AuditorName,'')=''"), "#,0.00").Replace(".00", "") & " 元。"
            End If
        End If
        dtTemp.Dispose() : dtTemp = Nothing
    End Sub

    Private Sub SetRowFilter()
        Dim sOldRowFileter As String = sRowFileter
        sRowFileter = ""

        If Me.cbbStore.Items.Count > 1 AndAlso Me.cbbStore.SelectedValue <> -1 Then sRowFileter = "(StoreID=" & Me.cbbStore.SelectedValue.ToString & ")"

        If Me.cbbReceivedDate.SelectedIndex = 1 Then
            sRowFileter = IIf(sRowFileter = "", "", sRowFileter & " And ") & "(ReceivedDate>= '" & Format(DateAdd(DateInterval.Day, -14, dtToday), "yyyy\/MM\/dd") & "' And ReceivedDate<= '" & Format(dtToday, "yyyy\/MM\/dd") & "')"
        ElseIf Me.cbbReceivedDate.SelectedIndex = -1 OrElse Me.cbbReceivedDate.SelectedIndex > 1 Then
            sRowFileter = IIf(sRowFileter = "", "", sRowFileter & " And ") & "(ReceivedDate='" & Me.cbbReceivedDate.Text & "')"
        End If

        If Me.cbbPaymentTerm.SelectedIndex > 0 Then sRowFileter = IIf(sRowFileter = "", "", sRowFileter & " And ") & "(PaymentTerm='" & Me.cbbPaymentTerm.Text & "')"

        Select Case Me.cbbConfirmationState.Text
            Case "未确认到账"
                sRowFileter = IIf(sRowFileter = "", "", sRowFileter & " And ") & "(Isnull(AuditorName,'')='')"
            Case "已确认到账"
                sRowFileter = IIf(sRowFileter = "", "", sRowFileter & " And ") & "(Isnull(AuditorName,'')<>'')"
        End Select

        If sRowFileter = sOldRowFileter Then Return

        dvList.RowFilter = sRowFileter
        Dim dtTemp As DataTable = dvList.ToTable
        With Me.dgvList
            .Columns("AuditorName").Visible = (dtTemp.Select("Isnull(AuditorName,'')<>''").Length > 0)
            .Columns("ValidatedTime").Visible = .Columns("AuditorName").Visible
            .Columns("Remarks").Visible = (dtTemp.Select("Isnull(Remarks,'')<>''").Length > 0)
            .Columns("OperationResult").Visible = (dtTemp.Select("Isnull(OperationResult,'')<>''").Length > 0)
            .Columns("ResultReason").Visible = (dtTemp.Select("Isnull(ResultReason,'')<>''").Length > 0)
        End With
        For Each column As DataGridViewColumn In Me.dgvList.Columns
            If column.Visible Then
                If column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells Then
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                ElseIf column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill Then
                    column.MinimumWidth = 2
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    column.MinimumWidth = column.Width
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End If
            End If
        Next
        dtTemp.Dispose() : dtTemp = Nothing

        If dvList.Count > 0 Then Me.dgvList.Select()
        Me.SummaryInfo()
    End Sub

    Private Sub GetPaymentList()
        Dim iNeedGetDataStores As Int16 = 0, sStoreID As String = "", sReceivedDate As String = Me.cbbReceivedDate.Text
        If Me.cbbReceivedDate.SelectedIndex > 1 Then
            If Me.cbbStore.SelectedValue = -1 Then
                For Each drStore As DataRow In dtStore.Select("AreaID<>-1")
                    sStoreID = drStore("AreaID").ToString
                    dvLoaded.RowFilter = "StoreID=" & sStoreID & " And ReceivedDate='" & sReceivedDate & "'"
                    If dvLoaded.Count = 0 Then iNeedGetDataStores += 1
                    If iNeedGetDataStores > 1 Then Exit For
                Next
            Else
                sStoreID = Me.cbbStore.SelectedValue.ToString
                dvLoaded.RowFilter = "StoreID=" & sStoreID & " And ReceivedDate='" & sReceivedDate & "'"
                If dvLoaded.Count = 0 Then iNeedGetDataStores = 1
            End If
        End If

        If iNeedGetDataStores > 0 Then
            Me.Cursor = Cursors.Default
            frmMain.statusText.Text = "正在检索""" & sReceivedDate & """的付款单……"
            frmMain.statusMain.Refresh()

            Dim DB As New DataBase
            DB.Open()
            If Not DB.IsConnected Then
                sReceivedDateError = "系统因连接不到数据库而无法检索付款单。请在检查数据库连接后，重新输入该日期重试。"
                frmMain.statusText.Text = sReceivedDateError
                Me.cbbReceivedDate.Select()
                Me.cbbReceivedDate.SelectionStart = 0 : Me.cbbReceivedDate.SelectionLength = 10
                Me.cbbReceivedDate.DroppedDown = True
                Me.Cursor = Cursors.Default
                Return
            End If

            Try '先将新销售单移入对应的Pending表
                DB.ModifyTable("Exec MoveNew2Pending " & frmMain.sLoginUserID)
            Catch
            End Try

            Try
                Dim sSQL As String = "Exec GetPaymentList "
                If iNeedGetDataStores = 1 Then
                    sSQL = sSQL & "@StoreID=" & sStoreID
                Else
                    sSQL = sSQL & "@LoginUserID=" & frmMain.sLoginUserID
                End If
                sSQL = sSQL & ",@ReceivedDate='" & sReceivedDate & "'"
                Dim dtList = DB.GetDataTable(sSQL).Copy
                If dtList.Rows.Count = 0 Then
                    MessageBox.Show("该日不存在任何付款单！    ", "没有付款单！", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    dvList.Table.Merge(dtList.Copy, True)
                End If
                dtList.Dispose() : dtList = Nothing
            Catch
                sReceivedDateError = "系统因在检索数据时出错而无法检索""" & sReceivedDate & """的付款单。请联系软件开发人员。请从付款日期列表中选择另一个现有项。"
                frmMain.statusText.Text = sReceivedDateError
                Me.cbbReceivedDate.Select()
                Me.cbbReceivedDate.SelectionStart = 0 : Me.cbbReceivedDate.SelectionLength = 10
                Me.cbbReceivedDate.DroppedDown = True
                Me.Cursor = Cursors.Default
                Return
            End Try

            If dtToday < CDate(sReceivedDate) Then
                dtToday = CDate(sReceivedDate)
                blSkipDeal = True
                With Me.cbbReceivedDate
                    .Items.Clear()
                    .Items.Add("（所有日期）")
                    .Items.Add("（最近半个月）")
                    For bDay As Byte = 0 To 14
                        .Items.Add(Format(DateAdd(DateInterval.Day, -bDay, dtToday), "yyyy\/MM\/dd"))
                    Next
                    .Items.Add("选择其它日期…")
                    .Text = sReceivedDate
                End With
                blSkipDeal = False
            End If

            Dim drLoaded As DataRowView
            If iNeedGetDataStores = 1 Then
                drLoaded = dvLoaded.AddNew
                drLoaded("StoreID") = sStoreID
                drLoaded("ReceivedDate") = sReceivedDate
                drLoaded("LoadedTime") = Now
                drLoaded("IsRefreshed") = 0
                drLoaded.EndEdit() : drLoaded.Row.AcceptChanges()
            Else
                For Each drStore As DataRow In dtStore.Rows
                    sStoreID = drStore("AreaID").ToString
                    dvLoaded.RowFilter = "StoreID=" & sStoreID & " And ReceivedDate='" & sReceivedDate & "'"
                    If dvLoaded.Count = 0 Then
                        drLoaded = dvLoaded.AddNew
                        drLoaded("StoreID") = sStoreID
                        drLoaded("ReceivedDate") = sReceivedDate
                        drLoaded.EndEdit() : drLoaded.Row.AcceptChanges()
                    End If
                Next
            End If
            Me.Cursor = Cursors.Default
        End If

        If Me.cbbStore.SelectedValue <> -1 AndAlso IsDate(Me.cbbReceivedDate.Text) Then
            If CDate(Me.cbbReceivedDate.Text) = dtToday Then
                Me.btnRefresh.Visible = True
            Else
                Try
                    Me.btnRefresh.Visible = (dvList.Table.Compute("Count(PaymentID)", "StoreID=" & Me.cbbStore.SelectedValue.ToString & " And ReceivedDate='" & Me.cbbReceivedDate.Text & "' And Isnull(AuditorName,'')=''") > 0)
                Catch
                    Me.btnRefresh.Visible = False
                End Try
            End If
        Else
            Me.btnRefresh.Visible = False
        End If

        Me.SetRowFilter()
    End Sub

    Private Sub SearchPayment()
        Me.chbDisplaySelected.Checked = False
        blSkipDeal = True
        Dim iSelectedIndex As Integer = Me.cbbStore.SelectedIndex
        Me.cbbStore.SelectedIndex = -1
        blSkipDeal = False
        Me.cbbStore.SelectedIndex = iSelectedIndex

        With frmSearchPayment
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim sOldRowFileter As String = sRowFileter
                sRowFileter = ""
                If Me.cbbStore.SelectedValue <> -1 Then
                    sRowFileter = "(StoreID=" & Me.cbbStore.SelectedValue.ToString & ") And "
                End If

                If .rdbByPayerName.Checked Then
                    sRowFileter = sRowFileter & "(PayerName Like '%" & .txbPayerName.Text.Trim.Replace("'", "''") & "%')"
                ElseIf .rdbByMediaNo.Checked Then
                    sRowFileter = sRowFileter & "(MediaNo Like '%" & .txbMediaNo.Text.Trim.Replace("'", "''") & "%')"
                ElseIf .rdbByPaymentAMT.Checked Then
                    sRowFileter = sRowFileter & "(PaymentAMT=" & .txbPaymentAMT.Text.Trim.Replace(",", "") & ")"
                Else
                    sRowFileter = sRowFileter & "(SalesBillCode='" & .txbSalesBillCode.Text.Trim.Replace("'", "''") & "')"
                End If

                If sRowFileter = sOldRowFileter Then Return

                dvList.RowFilter = sRowFileter
                Dim dtTemp As DataTable = dvList.ToTable
                With Me.dgvList
                    .Columns("AuditorName").Visible = (dtTemp.Select("Isnull(AuditorName,'')<>''").Length > 0)
                    .Columns("ValidatedTime").Visible = .Columns("AuditorName").Visible
                    .Columns("Remarks").Visible = (dtTemp.Select("Isnull(Remarks,'')<>''").Length > 0)
                    .Columns("OperationResult").Visible = (dtTemp.Select("Isnull(OperationResult,'')<>''").Length > 0)
                    .Columns("ResultReason").Visible = (dtTemp.Select("Isnull(ResultReason,'')<>''").Length > 0)
                End With
                For Each column As DataGridViewColumn In Me.dgvList.Columns
                    If column.Visible Then
                        If column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells Then
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        ElseIf column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill Then
                            column.MinimumWidth = 2
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                            column.MinimumWidth = column.Width
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        End If
                    End If
                Next
                dtTemp.Dispose() : dtTemp = Nothing

                If dvList.Count > 0 Then Me.dgvList.Select()
                Me.SummaryInfo()
            End If
            .Dispose()
        End With
    End Sub

    Private Function SaveChanges() As Boolean
        Me.chbDisplaySelected.Checked = True
        Me.dgvList("IsValidated", 0).Selected = True
        Me.dgvList.Rows(0).Selected = True
        For Each drList As DataRow In dvList.Table.Select("Isnull(ResultReason,'')<>''")
            drList("ResultReason") = DBNull.Value
        Next
        Me.dgvList.Columns("ResultReason").Visible = False
        Me.dgvList.FirstDisplayedScrollingColumnIndex = Me.dgvList.Columns("IsValidated").Index
        frmMain.statusText.Text = "就绪。"

        Dim dtResult As DataTable = dvList.ToTable(False, "PaymentAMT")
        If MessageBox.Show("您本次准备要确认的付款单汇总信息如下：    " & Chr(13) & Chr(13) & _
                           "准备确认付款单数： " & Format(dtResult.Rows.Count, "#,0") & " 张    " & Chr(13) & _
                           "准备确认付款金额： " & Format(dtResult.Compute("Sum(PaymentAMT)", ""), "#,0.00").Replace(".00", "") & " 元    " & Chr(13) & Chr(13) & _
                           "请注意：到账确认一旦保存，便不可撤消！    " & Chr(13) & Chr(13) & _
                           "如果您确认上面信息正确无误，请按""确定""按钮继续。   ", _
                           "请确认保存：", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Cancel Then

            dtResult.Dispose() : dtResult = Nothing
            Return False
        End If
        dtResult.Dispose() : dtResult = Nothing

        Me.Refresh()

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在保存到账确认……"

        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法保存到账确认。请检查数据库连接。"
            Me.Cursor = Cursors.Default
            Return False
        End If

        frmMain.statusRate.Visible = True
        frmMain.statusRate.Text = ""
        frmMain.statusProgress.Visible = True
        frmMain.statusProgress.Value = 0
        frmMain.statusMain.Refresh()

        Dim paymentRow As DataRow, blOK As Boolean = True, iSucessfully As Integer = 0, iRows As Integer = Me.dgvList.RowCount - 1

        Me.dgvList.Columns("OperationResult").Visible = True
        For iRow As Integer = 0 To iRows
            If Me.dgvList("AuditorName", iRow).Value.ToString <> "" Then Continue For

            Me.dgvList("IsValidated", iRow).Selected = True
            Me.dgvList.Rows(iRow).Selected = True

            paymentRow = dvList.Table.Rows.Find(Me.dgvList("PaymentID", iRow).Value)
            frmMain.statusText.Text = "正在保存到账确认……"
            frmMain.statusRate.Text = "(" & (iRow + 1).ToString & "/" & (iRows + 1).ToString & ")"
            frmMain.statusProgress.Value = Int(((iRow + 1) / (iRows + 1)) * 100)
            frmMain.statusMain.Refresh()

            Me.dgvList("OperationResult", iRow).Value = "正在保存……"
            Me.dgvList.Columns("OperationResult").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.dgvList.Columns("OperationResult").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Me.dgvList.FirstDisplayedScrollingColumnIndex = Me.dgvList.Columns("OperationResult").Index
            Me.Refresh()

            dtResult = DB.GetDataTable("Exec ConfirmPayment " & paymentRow("PaymentID").ToString & "," & paymentRow("SalesBillID").ToString & "," & IIf(paymentRow("PaymentTerm").ToString = "转账", "2", "3") & "," & paymentRow("PaymentAMT").ToString & ",'" & paymentRow("MediaNo").ToString & "','" & paymentRow("PayerName").ToString.Replace("'", "''") & "','" & frmMain.sLoginUserRealName.Replace("'", "''") & "'," & frmMain.sSSID)
            If dtResult Is Nothing Then
                paymentRow("OperationResult") = "保存失败！"
                paymentRow("ResultReason") = "数据库内部错误！"
                Me.dgvList.Columns("ResultReason").Visible = True
                Me.dgvList.Columns("ResultReason").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                Me.dgvList.Columns("ResultReason").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvList.FirstDisplayedScrollingColumnIndex = Me.dgvList.Columns("ResultReason").Index
                blOK = False
                Continue For
            ElseIf dtResult.Rows(0)("Result").ToString <> "OK" Then
                Select Case dtResult.Rows(0)("Result").ToString
                    Case "SalesBillDeleted", "SalesBillCancelled"
                        paymentRow("OperationResult") = "保存失败！"
                        paymentRow("ResultReason") = "销售单已被" & IIf(dtResult.Rows(0)("Result").ToString = "SalesBillDeleted", "取消！", "申请取消！")
                        paymentRow.AcceptChanges()
                    Case "PaymentChanged"
                        Select Case dtResult.Rows(0)("PaymentTerm")
                            Case 0
                                paymentRow("PaymentTerm") = "现金"
                                paymentRow("MediaNo") = DBNull.Value
                                paymentRow("PayerName") = DBNull.Value
                                paymentRow("ResultReason") = "付款方式已被改为""现金"""
                            Case 1
                                paymentRow("PaymentTerm") = "银行卡"
                                paymentRow("MediaNo") = DBNull.Value
                                paymentRow("PayerName") = DBNull.Value
                                paymentRow("ResultReason") = "付款方式已被改为""银行卡"""
                            Case 2
                                paymentRow("PaymentTerm") = "转账"
                                paymentRow("MediaNo") = dtResult.Rows(0)("MediaNo").ToString
                                paymentRow("PayerName") = dtResult.Rows(0)("PayerName").ToString
                                paymentRow("ResultReason") = "付款信息发生变化！"
                            Case Else
                                paymentRow("PaymentTerm") = "支票"
                                paymentRow("MediaNo") = dtResult.Rows(0)("MediaNo").ToString
                                paymentRow("PayerName") = dtResult.Rows(0)("PayerName").ToString
                                paymentRow("ResultReason") = "付款信息发生变化！"
                        End Select
                        paymentRow("PaymentAMT") = dtResult.Rows(0)("PaymentAMT")
                        paymentRow("OperationResult") = "保存失败！"
                        paymentRow.AcceptChanges()
                    Case "AlreadyConfirmed"
                        paymentRow("AuditorName") = dtResult.Rows(0)("AuditorName").ToString
                        paymentRow("ValidatedTime") = dtResult.Rows(0)("ValidatedTime")
                        Me.dgvList.Columns("AuditorName").Visible = True
                        Me.dgvList.Columns("AuditorName").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        Me.dgvList.Columns("AuditorName").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        Me.dgvList.Columns("ValidatedTime").Visible = True
                        paymentRow("OperationResult") = "提交失败！"
                        paymentRow("ResultReason") = "已由他人提交！"
                        paymentRow.AcceptChanges()
                    Case Else
                        paymentRow("OperationResult") = "保存失败！"
                        paymentRow("ResultReason") = "数据库内部错误！"
                        Me.dgvList.Columns("ResultReason").Visible = True
                        Me.dgvList.Columns("ResultReason").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        Me.dgvList.Columns("ResultReason").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        Me.dgvList.FirstDisplayedScrollingColumnIndex = Me.dgvList.Columns("ResultReason").Index
                        blOK = False
                        MessageBox.Show("保存到账确认时出现错误！下面是数据库的内部错误提示：    " & Chr(13) & Chr(13) & dtResult.Rows(0)("ErrorInfo").ToString & Space(4) & Chr(13) & Chr(13) & "请放弃保存，在关闭窗口后重试。如果仍有问题，请联系软件开发人员。    ", "保存到账确认失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        frmMain.statusText.Text = "保存到账确认失败！"
                        Exit For
                End Select
                Me.dgvList.Columns("ResultReason").Visible = True
                Me.dgvList.Columns("ResultReason").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                Me.dgvList.Columns("ResultReason").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvList.FirstDisplayedScrollingColumnIndex = Me.dgvList.Columns("ResultReason").Index
            Else
                paymentRow("AuditorName") = frmMain.sLoginUserRealName
                paymentRow("ValidatedTime") = dtResult.Rows(0)("ValidatedTime")
                Me.dgvList.Columns("AuditorName").Visible = True
                Me.dgvList.Columns("AuditorName").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                Me.dgvList.Columns("AuditorName").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvList.Columns("ValidatedTime").Visible = True
                paymentRow("OperationResult") = "保存成功。"
                paymentRow.AcceptChanges()

                iSucessfully += 1
            End If
        Next

        If dtResult IsNot Nothing Then dtResult.Dispose() : dtResult = Nothing
        If iSucessfully > 0 Then
            Me.dgvList("OperationResult", 0).Selected = True
            Me.dgvList.Rows(0).Selected = True
            If iSucessfully = Me.dgvList.RowCount Then
                frmMain.statusText.Text = "保存到账确认成功。"
                MessageBox.Show("保存到账确认成功。    ", "保存到账确认成功。", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                frmMain.statusText.Text = "保存到账确认部分成功，部分失败。"
                MessageBox.Show("保存到账确认部分成功，部分失败。    ", "保存到账确认部分成功。", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        ElseIf blOK Then
            frmMain.statusText.Text = "保存到账确认失败！"
            MessageBox.Show("保存到账确认失败！    ", "保存到账确认失败！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        frmMain.statusRate.Text = ""
        frmMain.statusRate.Visible = False
        frmMain.statusProgress.Value = 0
        frmMain.statusProgress.Visible = False
        DB.Close()

        Me.Cursor = Cursors.Default
        Me.btnSave.Enabled = Not blOK
        Me.chbDisplaySelected.Checked = False
        Return blOK
    End Function
End Class
