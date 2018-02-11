Public Class frmCardActivation

    'modify code 054:
    'date;2016/02/15
    'auther:BJY 
    'remark:增加65卡销售单，65/61使用新返点规则，去除051的一般销售单售卖65卡功能

    'modify code 059:
    'date;2016/06/24
    'auther:BJY 
    'remark:付款抵扣合同，如全额抵扣，允许保存销售单，且记录支付金额为0的支付方式

    'modify code 068:
    'date;2016/12/26
    'auther:QP
    'remark:修正激活卡片时更新合同的当次返点金额,历史返点金额

    'modify code 059:start-------------------------------------------------------------------------
    'Private sProcedureName As String = "GetActivationList", sSummaryInfo As String = "", sRowFilter As String = "", sTimerType As String = "DoubleClick", bClicks As Byte = 0, sSalesDateError As String = "", sSelectedSalesBillDetailID As String = ""
    Private sProcedureName As String = "GetActivationList_29504", sSummaryInfo As String = "", sRowFilter As String = "", sTimerType As String = "DoubleClick", bClicks As Byte = 0, sSalesDateError As String = "", sSelectedSalesBillDetailID As String = ""
    'modify code 059:end-------------------------------------------------------------------------
    Private dvLoaded As DataView, dtToday As Date, dvCard As DataView, dtCity As DataTable, dtStore As DataTable, dvSalesman As DataView, currentRow As DataRow
    Private blCanActivate As Boolean = False, blCanBrowseSalesBill As Boolean = True, blCardFilterFormClosing As Boolean = False

    Public blSkipDeal As Boolean = True, dvList As DataView

    Private Declare Function LockWindowUpdate Lib "user32" (ByVal hwndLock As Long) As Long

    Private Sub frmCardActivation_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If blCardFilterFormClosing Then
            sTimerType = "ReselectCardFilterForm"
            Me.theTimer.Interval = 200
            Me.theTimer.Enabled = True
            Return
        End If

        If Me.dgvList.CurrentRow IsNot Nothing Then
            sTimerType = "ReselectRow"
            Me.theTimer.Interval = 100
            Me.theTimer.Enabled = True
        End If
    End Sub

    Private Sub frmCardActivation_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.btnActivate.Enabled AndAlso MessageBox.Show("您已经选择了若干等待激活的记录，但还未提交。    " & Chr(13) & Chr(13) & "是否放弃提交而关闭窗口？    ", "是否放弃提交？", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
            Return
        End If

        'If dvList.Table.Select("SalesBillType='员工销售单' And PaymentTermName='（返点卡）' And ActivationState='等待激活'").Length > 0 Then
        '    If MessageBox.Show("发现符合激活条件的员工返点卡！    " & Chr(13) & Chr(13) & "一旦员工返点卡符合激活条件，应被立即激活！    " & Chr(13) & Chr(13) & "是否现在就去激活这些返点卡？    ", "是否激活员工返点卡？", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        '        Me.Refresh()
        '        blSkipDeal = True

        '        Me.cbbSalesBillType.Text = "员工销售单"
        '        Me.cbbPaymentTerm.Text = "（返点卡）"
        '        Me.cbbActivationState.SelectedIndex = 0

        '        blSkipDeal = False
        '        Call LockWindowUpdate(Me.dgvList.Handle)
        '        Me.SetRowFilter()
        '        Call LockWindowUpdate(0)

        '        e.Cancel = True
        '        Return
        '    End If
        'End If

        Me.Dispose()
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub frmCardActivation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If frmMain.dtLoginStructure.Select("AreaType='S'").Length = 0 Then
            MessageBox.Show("没有门店，不能打开""购物卡激活""窗口！    " & Chr(13) & Chr(13) & "请找系统管理员建立门店。    ", "未发现门店！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close() : Return
        End If

        Dim dvArea As DataView = frmMain.dtLoginStructure.Copy.DefaultView, drAll As DataRow
        dvArea.Sort = "SortCode"
        If frmMain.dtAllowedRight.Select("RightName='MKCardActivate'").Length > 0 Then '总部金融服务部总监或总部购物卡经理
            Me.Text = "市场活动卡激活 Maketing Activity Card Activation"
            blCanActivate = True
            blCanBrowseSalesBill = True

            dvArea.RowFilter = "AreaType='C'"
            drAll = dvArea.Table.Rows.Add(-2)
            drAll("AreaName") = "（所有城市）" : drAll("AreaType") = "C" : drAll("SortCode") = ""
            dtCity = dvArea.ToTable(False, "AreaID", "AreaName")
            For Each drCity As DataRow In dtCity.Select("AreaID>0")
                If frmMain.dtLoginStructure.Select("ParentAreaID=" & drCity("AreaID").ToString).Length = 0 Then drCity.Delete()
            Next
            dtCity.AcceptChanges()

            With Me.cbbCity
                .DataSource = dtCity
                .ValueMember = "AreaID"
                .DisplayMember = "AreaName"
                .SelectedIndex = 0
            End With

            Me.pnlCity.Visible = True
            With Me.cbbSalesBillType
                .Items.Add("活动卡销售单")
                .SelectedIndex = 0
            End With
            Me.pnlSalesBillType.Visible = False
            Me.pnlSalesman.Visible = False
            Me.pnlSalesDate.Left = 263

            sProcedureName = "GetActivationList_MKT"
        Else
            With Me.cbbSalesBillType
                .Items.Add("（所有类型）")
                .Items.Add("一般销售单")
                .Items.Add("退货销售单")
                '.Items.Add("活动卡销售单")
                .Items.Add("公关卡销售单")
                '.Items.Add("员工销售单")
                .Items.Add("实名制卡销售单")
                'modify code 054:start-------------------------------------------------------------------------
                .Items.Add("通卖非实名卡销售单")
                'modify code 054:end-------------------------------------------------------------------------
                .Items.Add("线下提卡销售单")
                If frmMain.dtLoginStructure.Rows.Find("34") IsNot Nothing OrElse _
                    frmMain.dtLoginStructure.Rows.Find("272") IsNot Nothing OrElse _
                    "|34|272|".IndexOf("|" & frmMain.dtLoginStructure.Rows.Find(frmMain.sLoginAreaID)("ParentAreaID").ToString & "|") > -1 Then '大连联名卡
                    .Items.Add("联名卡销售单")
                End If
                .SelectedIndex = 0
            End With

            blCanActivate = (frmMain.dtAllowedRight.Select("RightName='CardActivate'").Length > 0)
            blCanBrowseSalesBill = (frmMain.dtAllowedRight.Select("RightName='SalesBillBrowse'").Length > 0)
        End If

        dvArea.RowFilter = "AreaType='S'"
        If dvArea.Count > 1 Then
            drAll = dvArea.Table.Rows.Add(-1)
            drAll("AreaName") = "（所有门店）" : drAll("AreaType") = "S" : drAll("SortCode") = ""
        End If
        dtStore = dvArea.ToTable(False, "AreaID", "AreaName")
        dtStore.AcceptChanges()
        dvArea.Dispose() : dvArea = Nothing

        With Me.cbbStore
            .DataSource = dtStore
            .ValueMember = "AreaID"
            .DisplayMember = "AreaName"
            .SelectedIndex = 0
        End With

        If dtStore.Rows.Count = 1 Then
            Me.pnlStore.Visible = False
        Else
            Me.pnlSalesDate.Left = 263
        End If

        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打开""购物卡激活""窗口。请检查数据库连接。"
            Me.Close() : Return
        End If

        If blCanActivate Then '先将新销售单移入对应的Pending表
            Try
                DB.ModifyTable("Exec MoveNew2Pending " & frmMain.sLoginUserID)
            Catch
            End Try
        End If

        Try
            Dim sSQL As String = "Exec " & sProcedureName & " "
            If dtStore.Rows.Count = 1 Then
                sSQL = sSQL & "@StoreID=" & dtStore.Rows(0)("AreaID").ToString
            Else
                sSQL = sSQL & "@LoginUserID=" & frmMain.sLoginUserID
            End If
            dvList = DB.GetDataTable(sSQL & ",@GetAllUnfinished=1").DefaultView '先取得所有未完全激活的记录
            dvList.Table.PrimaryKey = New DataColumn() {dvList.Table.Columns("SalesBillDetailID")}
            dvList.Table.Merge(DB.GetDataTable(sSQL)) '再取得一周的记录
            dvCard = DB.GetDataTable("Exec GetCardRowActivation -1").DefaultView
            dvCard.Sort = "SalesBillDetailID,CardNo"
            dtToday = DB.GetDataTable("Select Convert(datetime, Convert(varchar(10), GETDATE(), 101))").Rows(0)(0)
            DB.Close()
        Catch
            frmMain.statusText.Text = "系统因在检索数据时出错而无法执行激活操作。请联系软件开发人员。"
            DB.Close() : Me.Close()
            Return
        End Try

        dvList.Sort = "StoreCode,SalesDate,CreatorName,SalesBillCode,RowType,RowID"
        Dim dtSalesman As DataTable = dvList.ToTable(True, "StoreID", "CreatorID", "CreatorName")
        Dim allSalesman As DataRow = dtSalesman.Rows.Add()
        dtSalesman.Rows.Remove(allSalesman)
        dtSalesman.Rows.InsertAt(allSalesman, 0)
        allSalesman(0) = -1 : allSalesman(1) = -1 : allSalesman(2) = "（所有售卡员）"
        dtSalesman.AcceptChanges()
        dvSalesman = New DataView(dtSalesman.Copy)
        dtSalesman.Dispose() : dtSalesman = Nothing

        If Not blCanActivate Then
            dvList.RowFilter = "ActivationState='等待激活'"
            For Each dr As DataRowView In dvList
                dr("ActivationState") = "不可激活"
                dr("StateReason") = "没有激活权限"
            Next
            Me.Text = Me.Text & " (只读 Readonly)"
        End If
        dvList.Table.AcceptChanges()

        dvLoaded = New DataView(New DataTable())
        dvLoaded.Table.Columns.Add("StoreID", System.Type.GetType("System.Int16"))
        dvLoaded.Table.Columns.Add("SalesDate", System.Type.GetType("System.DateTime"))
        dvLoaded.Table.Columns.Add("LoadedTime", System.Type.GetType("System.DateTime"))
        dvLoaded.Table.Columns.Add("IsRefreshed", System.Type.GetType("System.Boolean"))
        Dim drLoaded As DataRowView
        For Each drStore As DataRow In dtStore.Rows
            For bDay As Byte = 0 To 6
                drLoaded = dvLoaded.AddNew
                drLoaded("StoreID") = drStore("AreaID")
                drLoaded("SalesDate") = DateAdd(DateInterval.Day, -bDay, dtToday)
                drLoaded("LoadedTime") = Now()
                drLoaded("IsRefreshed") = 0
                drLoaded.EndEdit() : drLoaded.Row.AcceptChanges()
            Next
        Next

        With Me.cbbSalesDate
            .Items.Add("（所有日期）")
            .Items.Add("（最近一周）")
            For bDay As Byte = 0 To 6
                .Items.Add(Format(DateAdd(DateInterval.Day, -bDay, dtToday), "yyyy\/MM\/dd"))
            Next
            .Items.Add("选择其它日期…")
            .SelectedIndex = 1
        End With

        If dvSalesman.Count = 2 Then dvSalesman.RowFilter = "CreatorID<>-1"
        With Me.cbbSalesman
            .DataSource = dvSalesman
            .ValueMember = "CreatorID"
            .DisplayMember = "CreatorName"
            .SelectedIndex = 0
        End With

        Me.cbbPaymentTerm.SelectedIndex = 0
        Me.cbbActivationState.SelectedIndex = 0

        dvList.RowFilter = ""
        Dim dtTemp As DataTable = dvList.ToTable
        With Me.dgvList
            .DataSource = dvList
            .Columns(0).Visible = False
            .Columns(1).Visible = False
            .Columns(2).Visible = False
            .Columns(3).Visible = False
            .Columns(4).Visible = False
            .Columns(5).Visible = False
            .Columns(6).Visible = False
            .Columns(7).Visible = False
            .Columns(8).Visible = False
            .Columns(9).Visible = False
            .Columns(10).Visible = False
            .Columns(11).Visible = False
            .Columns(12).Visible = False
            .Columns(13).Visible = False
            .Columns(14).Visible = False
            .Columns(15).Visible = False
            With .Columns(16)
                .HeaderText = "门店"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 40
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
                .Visible = (Me.pnlCity.Visible OrElse Me.pnlStore.Visible)
            End With
            Dim linkColumn As New DataGridViewLinkColumn
            linkColumn.DataPropertyName = "SalesBillCode"
            .Columns.RemoveAt(17)
            .Columns.Insert(17, linkColumn)
            With .Columns(17)
                .HeaderText = "销售单号"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 90
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(18)
                .HeaderText = "销售单类型"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 90
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
                .Visible = Me.pnlSalesBillType.Visible
            End With
            With .Columns(19)
                .HeaderText = "销售时间"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Format = "yyyy\/MM\/dd HH:mm:ss"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 120
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(20)
                .HeaderText = "售卡员"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(21)
                .HeaderText = "整单应收金额"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(22)
                .HeaderText = "整单应充金额"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(23)
                .HeaderText = "付款方式"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(24)
                .HeaderText = "付款分配"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .Visible = (dtTemp.Select("Isnull(PaymentDescription,'')<>''").Length > 0)
            End With
            With .Columns(25)
                .HeaderText = "转账/支票号"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .Visible = (dtTemp.Select("Isnull(MediaNo,'')<>''").Length > 0)
            End With
            With .Columns(26)
                .HeaderText = "付款单位"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .Visible = Me.dgvList.Columns(25).Visible
            End With
            With .Columns(27)
                .HeaderText = "到账状态"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .Visible = (dtTemp.Select("Isnull(PaymentValidationState,'')<>''").Length > 0)
            End With
            With .Columns(28)
                .HeaderText = "开始卡号"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 125
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(29)
                .HeaderText = "结束卡号"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 125
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(30)
                .HeaderText = "数量"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Format = "#,0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(31)
                .HeaderText = "面值"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(32)
                .HeaderText = "单行应收金额"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(33)
                .HeaderText = "单行应充金额"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(34)
                .HeaderText = "已激活金额"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(35)
                .HeaderText = "未激活金额"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .Visible = (dtTemp.Select("RowActivatedAMT>0 And RowActivatedAMT<RowChargedAMT").Length > 0)
            End With
            With .Columns(36)
                .HeaderText = "激活状态"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .MinimumWidth = .Width
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(37)
                .HeaderText = "状态说明"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .MinimumWidth = .Width
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Resizable = DataGridViewTriState.False
                .Visible = (dtTemp.Select("Isnull(StateReason,'')<>''").Length > 0)
            End With
            With .Columns(38)
                .HeaderText = "激活者"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .Visible = (dtTemp.Select("Isnull(ActivatorName,'')<>''").Length > 0)
            End With
            With .Columns(39)
                .HeaderText = "提交时间"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 120
                .DefaultCellStyle.Format = "yyyy\/MM\/dd HH:mm:ss"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
                .Visible = Me.dgvList.Columns(38).Visible
            End With
            With .Columns(40)
                .HeaderText = "已选激活金额"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.BackColor = SystemColors.Info
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .Visible = False
            End With
            With .Columns(41)
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
            With .Columns(42)
                .HeaderText = "状态说明"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.BackColor = SystemColors.Info
                .DefaultCellStyle.ForeColor = Color.Red
                .DefaultCellStyle.SelectionForeColor = Color.Red
                .DefaultCellStyle.Font = New Font(Me.dgvList.Font, FontStyle.Bold)
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .Visible = False
            End With
            .Columns(43).Visible = False

            For Each column As DataGridViewColumn In .Columns
                column.Name = dvList.Table.Columns(column.Index).ColumnName
            Next
        End With
        dtTemp.Dispose() : dtTemp = Nothing

        With Me.dgvCard
            .DataSource = dvCard
            .Columns(0).Visible = False
            Dim newCheckColumn As New DataGridViewCheckBoxColumn()
            newCheckColumn.DataPropertyName = "Selected"
            .Columns.RemoveAt(1)
            .Columns.Insert(1, newCheckColumn)
            With .Columns(1)
                .HeaderText = "选择"
                .Width = 40
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(2)
                .HeaderText = "卡号"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 128
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(3)
                .HeaderText = "面值"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,0.00"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(4)
                .HeaderText = "激活状态"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 60
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(5)
                .HeaderText = "状态说明"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .Visible = False
            End With
            With .Columns(6)
                .HeaderText = "CUL激活时间"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Format = "yyyy\/MM\/dd HH:mm:ss"
                .Width = 120
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
                .Visible = False
            End With
            .Columns(7).Visible = False

            For Each column As DataGridViewColumn In .Columns
                column.Name = dvCard.Table.Columns(column.Index).ColumnName
            Next
        End With

        If Not ToolStripManager.VisualStylesEnabled Then
            Me.dgvList.Top -= 2
            Me.dgvList.Height += 2
            Me.dgvCard.Top -= 2
            Me.dgvCard.Height += 2
        End If

        Me.dgvList.Select()
        blSkipDeal = False
        Me.cbbSalesDate.SelectedIndex = 0
        If Not blCanActivate Then
            Me.cbbSalesDate.SelectedIndex = 1
            Me.cbbActivationState.SelectedIndex = Me.cbbActivationState.Items.Count - 1
        End If

        Me.SummaryInfo()
    End Sub

    Private Sub cbbCity_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbCity.SelectedIndexChanged
        If blSkipDeal Then Return
        blSkipDeal = True

        Dim dvArea As DataView = frmMain.dtLoginStructure.Copy.DefaultView, drAll As DataRow
        dvArea.Sort = "SortCode"
        If Me.cbbCity.SelectedValue = -2 Then
            dvArea.RowFilter = "AreaType='S' Or AreaID=-1"
        Else
            dvArea.RowFilter = "ParentAreaID=" & Me.cbbCity.SelectedValue.ToString & " Or AreaID=-1"
        End If
        If dvArea.Count > 1 Then
            drAll = dvArea.Table.Rows.Add(-1)
            drAll("AreaName") = "（所有门店）" : drAll("AreaType") = "S" : drAll("SortCode") = ""
        End If
        dtStore = dvArea.ToTable(False, "AreaID", "AreaName")
        dtStore.AcceptChanges()
        dvArea.Dispose() : dvArea = Nothing

        With Me.cbbStore
            .DataSource = dtStore
            .ValueMember = "AreaID"
            .DisplayMember = "AreaName"
            .SelectedIndex = 0
        End With
        blSkipDeal = False

        Me.GetActivationList()
    End Sub

    Private Sub cbbStore_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbStore.SelectedIndexChanged
        If blSkipDeal Then Return
        Me.GetActivationList()
    End Sub

    Private Sub cbbSalesBillType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbSalesBillType.SelectedIndexChanged
        If blSkipDeal Then Return
        Call LockWindowUpdate(Me.dgvList.Handle)
        Me.SetRowFilter()
        Call LockWindowUpdate(0)
    End Sub

    Private Sub cbbSalesDate_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbSalesDate.Enter
        If Me.pnlSalesDate.Visible Then Me.pnlSalesDate.Visible = False
    End Sub

    Private Sub cbbSalesDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbbSalesDate.KeyDown
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
            sSalesDateError = ""
            If dtToday < Today Then
                Me.mtcSalesDate.MaxDate = Today
            Else
                Me.mtcSalesDate.MaxDate = dtToday
            End If
            Me.pnlSalesDate.Visible = True
            Me.mtcSalesDate.Select()
            Dim dtSelectedDate As Date = Me.mtcSalesDate.SelectionStart
            Me.mtcSalesDate.SetDate(DateAdd(DateInterval.Day, -1, dtSelectedDate))
            Me.mtcSalesDate.SetDate(dtSelectedDate)
            frmMain.statusText.Text = "请按回车或重新单击已选择的日期来确定日期。"
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub cbbSalesDate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbSalesDate.SelectedIndexChanged
        If blSkipDeal Then Return

        blSkipDeal = True
        If Me.cbbSalesDate.SelectedIndex = 0 Then
            If Me.cbbActivationState.SelectedIndex > 9 Then Me.cbbActivationState.SelectedIndex = 0
            If Me.cbbActivationState.Items.IndexOf("3. 全部激活") > -1 Then Me.cbbActivationState.Items.Remove("3. 全部激活")
            If Me.cbbActivationState.Items.IndexOf("4. 所有状态") > -1 Then Me.cbbActivationState.Items.Remove("4. 所有状态")
        Else
            If Me.cbbActivationState.Items.IndexOf("3. 全部激活") = -1 Then Me.cbbActivationState.Items.Add("3. 全部激活")
            If Me.cbbActivationState.Items.IndexOf("4. 所有状态") = -1 Then Me.cbbActivationState.Items.Add("4. 所有状态")
        End If
        blSkipDeal = False

        sSalesDateError = ""
        If Me.cbbSalesDate.Text = "选择其它日期…" Then
            If dtToday < Today Then
                Me.mtcSalesDate.MaxDate = Today
            Else
                Me.mtcSalesDate.MaxDate = dtToday
            End If
            Me.pnlSalesDate.Visible = True
            Me.mtcSalesDate.Select()
            sTimerType = "SetDate"
            Me.theTimer.Interval = 100
            Me.theTimer.Enabled = True
            frmMain.statusText.Text = "请按回车来确定已选择的日期或双击日期来选择并确定日期。"
            Return
        End If
        If Me.cbbSalesDate.SelectedIndex = -1 Then Return

        If Me.cbbStore.SelectedValue <> -1 AndAlso IsDate(Me.cbbSalesDate.Text) Then
            If CDate(Me.cbbSalesDate.Text) = dtToday Then
                Me.btnRefresh.Visible = True
            Else
                Try
                    Me.btnRefresh.Visible = (dvList.Table.Compute("Sum(InactivatedAMT)", "StoreID=" & Me.cbbStore.SelectedValue.ToString & " And SalesDate='" & Me.cbbSalesDate.Text & "'") > 0)
                Catch
                    Me.btnRefresh.Visible = False
                End Try
            End If
        Else
            Me.btnRefresh.Visible = False
        End If

        Call LockWindowUpdate(Me.dgvList.Handle)
        Me.SetRowFilter()
        Call LockWindowUpdate(0)
    End Sub

    Private Sub cbbSalesDate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbbSalesDate.Validating
        If sSalesDateError <> "" Then
            frmMain.statusText.Text = sSalesDateError
            e.Cancel = True
        End If
    End Sub

    Private Sub mtcSalesDate_DateChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles mtcSalesDate.DateChanged
        If Me.mtcSalesDate.Visible = False Then Return
        Me.cbbSalesDate.Text = Format(Me.mtcSalesDate.SelectionStart, "yyyy\/MM\/dd")
    End Sub

    Private Sub mtcSalesDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mtcSalesDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cbbSalesDate.Select()
            Me.GetActivationList()
        End If
    End Sub

    Private Sub mtcSalesDate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles mtcSalesDate.Leave
        Me.pnlSalesDate.Visible = False
    End Sub

    Private Sub mtcSalesDate_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mtcSalesDate.MouseDown
        If e.Button <> Windows.Forms.MouseButtons.Left Then Return
        Dim theR As Rectangle = Me.mtcSalesDate.Bounds
        theR.Offset(0, 35)
        If Not theR.Contains(Me.mtcSalesDate.PointToClient(MousePosition)) Then theR = Nothing : Return
        theR = Nothing

        bClicks += 1
        If bClicks = 2 Then
            Me.cbbSalesDate.Select()
            Me.GetActivationList()
        End If
        sTimerType = "DoubleClick"
        Me.theTimer.Interval = 500
        Me.theTimer.Enabled = True
    End Sub

    Private Sub cbbSalesman_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbSalesman.SelectedIndexChanged, cbbPaymentTerm.SelectedIndexChanged
        If blSkipDeal Then Return
        Call LockWindowUpdate(Me.dgvList.Handle)
        Me.SetRowFilter()
        Call LockWindowUpdate(0)
    End Sub

    Private Sub cbbActivationState_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbActivationState.DropDown
        Me.lblActivationState.BackColor = SystemColors.Window
        Me.lblActivationState.ForeColor = SystemColors.ControlText
    End Sub

    Private Sub cbbActivationState_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbActivationState.DropDownClosed
        Me.lblActivationState.BackColor = SystemColors.Highlight
        Me.lblActivationState.ForeColor = SystemColors.HighlightText
    End Sub

    Private Sub cbbActivationState_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbActivationState.Enter
        If Me.cbbActivationState.DroppedDown = False Then
            Me.lblActivationState.BackColor = SystemColors.Highlight
            Me.lblActivationState.ForeColor = SystemColors.HighlightText
        Else
            Me.lblActivationState.BackColor = SystemColors.Window
            Me.lblActivationState.ForeColor = SystemColors.ControlText
        End If
    End Sub

    Private Sub cbbActivationState_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbActivationState.Leave
        Me.lblActivationState.BackColor = SystemColors.Window
        Me.lblActivationState.ForeColor = SystemColors.ControlText
    End Sub

    Private Sub cbbActivationState_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbActivationState.SelectedIndexChanged
        Dim sText As String = Me.cbbActivationState.Text.Trim
        If sText.IndexOf(" ") > -1 Then sText = sText.Substring(sText.IndexOf(" ") + 1)
        Me.lblActivationState.Text = sText

        If blSkipDeal Then Return
        Call LockWindowUpdate(Me.dgvList.Handle)
        Me.SetRowFilter()
        Call LockWindowUpdate(0)
    End Sub

    Private Sub lblActivationState_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblActivationState.Click
        Me.cbbActivationState.Select()
        Me.cbbActivationState.DroppedDown = True
    End Sub

    Private Sub lblActivationState_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblActivationState.EnabledChanged
        Me.lblActivationState.BackColor = IIf(Me.lblActivationState.Enabled, SystemColors.Window, SystemColors.Control)
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        dvLoaded.RowFilter = "StoreID=" & Me.cbbStore.SelectedValue.ToString & " And SalesDate='" & Me.cbbSalesDate.Text & "'"

        If DateDiff(DateInterval.Minute, dvLoaded(0)("LoadedTime"), Now()) < 5 Then
            If dvLoaded(0)("IsRefreshed") = 0 Then
                MessageBox.Show("距离该店该日的数据下载时间还不足 5 分钟。    " & Chr(13) & Chr(13) & "数据下载时间： " & Format(dvLoaded(0)("LoadedTime"), "HH:mm") & Chr(13) & Chr(13) & "请在数据下载时间的 5 分钟后再刷新。    ", "刷新不能过于频繁！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("距离该店该日的上次刷新时间还不足 5 分钟。    " & Chr(13) & Chr(13) & "上次刷新时间： " & Format(dvLoaded(0)("LoadedTime"), "HH:mm") & Chr(13) & Chr(13) & "请在上次刷新时间的 5 分钟后再刷新。    ", "刷新不能过于频繁！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            Return
        End If

        Try
            If dvList.Table.Compute("Sum(FinalPendingAMT)", "StoreID=" & Me.cbbStore.SelectedValue.ToString & " And SalesDate='" & Me.cbbSalesDate.Text & "'") > 0 Then
                If MessageBox.Show("注意：刷新销售单将清除您在该店该日所做的选择！     " & Chr(13) & Chr(13) & "门店： " & Me.cbbStore.Text & Space(4) & Chr(13) & "日期： " & Me.cbbSalesDate.Text & Space(4) & Chr(13) & Chr(13) & "您是否确认刷新该店该日的销售单？    ", "请确认刷新销售单：", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then Return
            End If
        Catch
        End Try

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在刷新销售单（店： " & Me.cbbStore.Text & "  日期： " & Me.cbbSalesDate.Text & "）……"
        frmMain.statusMain.Refresh()

        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法刷新销售单。请检查数据库连接。"
            Me.Cursor = Cursors.Default
            Return
        End If

        If blCanActivate Then
            Try '先将新销售单移入对应的Pending表
                If DB.GetDataTable("Exec MoveNew2Pending " & frmMain.sLoginUserID).Rows(0)(0).ToString = "Busy" AndAlso CDate(Me.cbbSalesDate.Text) = dtToday Then
                    MessageBox.Show("对不起，系统繁忙！请五分钟后再刷新。    ", "系统繁忙！", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch
            End Try
        End If

        Try
            Dim sSQL As String = "Exec " & sProcedureName & " @StoreID=" & Me.cbbStore.SelectedValue.ToString
            sSQL = sSQL & ",@SalesDate='" & Me.cbbSalesDate.Text & "'"
            Dim dtList = DB.GetDataTable(sSQL).Copy

            Dim sSalesBillDetailID As String = ""
            If Me.dgvList.CurrentRow IsNot Nothing Then sSalesBillDetailID = Me.dgvList("SalesBillDetailID", Me.dgvList.CurrentRow.Index).Value.ToString

            blSkipDeal = True
            For Each drList As DataRow In dvList.Table.Select("StoreID=" & Me.cbbStore.SelectedValue.ToString & " And SalesDate='" & Me.cbbSalesDate.Text & "'", "", DataViewRowState.CurrentRows)
                drList("NewSelectedAMT") = drList("SelectedAMT") : drList("PendingAMT") = 0 : drList("OperationResult") = DBNull.Value : drList("ResultReason") = DBNull.Value : drList("FinalPendingAMT") = 0 : drList.AcceptChanges()
                For Each drCard As DataRow In dvCard.Table.Select("SalesBillDetailID=" & drList("SalesBillDetailID").ToString, "", DataViewRowState.CurrentRows)
                    drCard.Delete()
                    If drCard.RowState = DataRowState.Deleted Then drCard.AcceptChanges()
                Next
            Next
            Me.dgvList.Columns("PendingAMT").Visible = False
            Me.dgvList.Columns("OperationResult").Visible = False
            Me.dgvList.Columns("ResultReason").Visible = False
            Me.chbDisplaySelected.Checked = False
            Me.chbDisplaySelected.Visible = False
            blSkipDeal = False

            If dtList.Rows.Count = 0 Then
                MessageBox.Show("今日还没有销售单！    ", "没有销售单！", MessageBoxButtons.OK, MessageBoxIcon.Information)
                frmMain.statusText.Text = "今日还没有销售单！"
            Else
                If Not blCanActivate Then
                    For Each dr As DataRow In dtList.Select("ActivationState='等待激活'")
                        dr("ActivationState") = "不可激活"
                        dr("StateReason") = "没有激活权限"
                    Next
                End If
                dtList.AcceptChanges()
                blSkipDeal = True
                dvList.Table.Merge(dtList.Copy, False)
                blSkipDeal = False

                Me.dgvList.Select()
                If sSalesBillDetailID <> "" AndAlso dvList.Table.Select("SalesBillDetailID=" & sSalesBillDetailID).Length > 0 Then
                    For Each drList As DataGridViewRow In Me.dgvList.Rows
                        If drList.Cells("SalesBillDetailID").Value.ToString = sSalesBillDetailID Then
                            blSkipDeal = True
                            If Me.dgvList.CurrentCell IsNot Nothing Then
                                drList.Cells(Me.dgvList.CurrentCell.ColumnIndex).Selected = True
                            Else
                                drList.Cells("ActivationState").Selected = True
                            End If
                            drList.Selected = False
                            blSkipDeal = False
                            drList.Selected = True
                            Exit For
                        End If
                    Next
                ElseIf dvList.Count > 0 Then
                    blSkipDeal = True
                    Me.dgvList("ActivationState", 0).Selected = True
                    Me.dgvList.Rows(0).Selected = False
                    blSkipDeal = False
                    Me.dgvList.Rows(0).Selected = True
                End If
                Me.SummaryInfo()
            End If
            dtList.Dispose() : dtList = Nothing
            dvLoaded(0)("LoadedTime") = Now : dvLoaded(0)("IsRefreshed") = 1 : dvLoaded(0).Row.AcceptChanges()
        Catch
            frmMain.statusText.Text = "系统因在检索数据时出错而无法刷新销售单。请联系软件开发人员。"
        End Try

        Me.chbDisplaySelected.Visible = (dvList.Table.Select("FinalPendingAMT>0").Length > 0)
        Me.btnActivate.Enabled = Me.chbDisplaySelected.Visible

        DB.Close()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub theTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles theTimer.Tick
        Me.theTimer.Enabled = False
        If sTimerType = "DoubleClick" Then
            bClicks = 0
        ElseIf sTimerType = "SetDate" Then
            blSkipDeal = True
            Me.mtcSalesDate.Select()
            Dim dtSelectedDate As Date = Me.mtcSalesDate.SelectionStart
            Me.mtcSalesDate.SetDate(DateAdd(DateInterval.Day, -1, dtSelectedDate))
            Me.mtcSalesDate.SetDate(dtSelectedDate)
            blSkipDeal = False
        ElseIf sTimerType = "ReselectRow" Then
            Me.dgvList.Focus() : Me.dgvList.Select()
            blSkipDeal = True
            Me.dgvList.CurrentRow.Selected = False
            blSkipDeal = False
            Me.dgvList.CurrentRow.Selected = True
            frmMain.statusText.Text = sSummaryInfo & "。"
        ElseIf sTimerType = "ReselectCardFilterForm" Then
            blCardFilterFormClosing = False
        Else
            blSkipDeal = True
            Me.dgvList.CurrentRow.Selected = True
            blSkipDeal = False
        End If
    End Sub

    Private Sub dgvList_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvList.CellContentClick
        If e.RowIndex = -1 OrElse Me.dgvList.Columns(e.ColumnIndex).Name <> "SalesBillCode" Then Return
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
    End Sub

    Private Sub dgvList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvList.CellDoubleClick
        If Me.chbSelectAllCards.Visible = False OrElse e.RowIndex = -1 OrElse Me.dgvList.Columns(e.ColumnIndex).Name = "SalesBillCode" Then Return

        If Me.chbSelectAllCards.CheckState = CheckState.Checked Then
            If dvCard.ToTable.Select("NeedActivate=0").Length > 0 Then
                Me.chbSelectAllCards.CheckState = CheckState.Indeterminate
            Else
                Me.chbSelectAllCards.CheckState = CheckState.Unchecked
            End If
        Else
            Me.chbSelectAllCards.CheckState = CheckState.Checked
        End If

        If dvCard.Count > 0 Then
            Me.dgvCard.Select()
            Me.dgvCard(1, Me.dgvCard.CurrentRow.Index).Selected = True
        End If
    End Sub

    Private Sub dgvList_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvList.CellFormatting
        Try
            If Me.dgvList.Columns(e.ColumnIndex).GetType.Name = "DataGridViewLinkColumn" Then
                If Me.dgvList.CurrentRow IsNot Nothing AndAlso Me.dgvList.CurrentRow.Index = e.RowIndex AndAlso Me.dgvList.CurrentRow.Selected Then
                    CType(Me.dgvList(e.ColumnIndex, e.RowIndex), DataGridViewLinkCell).LinkColor = Color.Yellow
                Else
                    CType(Me.dgvList(e.ColumnIndex, e.RowIndex), DataGridViewLinkCell).LinkColor = Color.Blue
                End If
            ElseIf Me.dgvList.Columns(e.ColumnIndex).Name = "ActivationState" OrElse Me.dgvList.Columns(e.ColumnIndex).Name = "StateReason" Then
                Select Case Me.dgvList("ActivationState", e.RowIndex).Value.ToString
                    Case "等待激活"
                        e.CellStyle.ForeColor = Color.Blue
                        e.CellStyle.SelectionForeColor = Color.Yellow
                    Case "不可激活"
                        e.CellStyle.ForeColor = Color.Orange
                        e.CellStyle.SelectionForeColor = Color.Orange
                    Case "正在激活"
                        e.CellStyle.ForeColor = Color.Green
                        e.CellStyle.SelectionForeColor = Color.LightGreen
                    Case "激活失败"
                        e.CellStyle.ForeColor = Color.Red
                        e.CellStyle.SelectionForeColor = Color.Red
                    Case "部分激活"
                        e.CellStyle.ForeColor = Color.Maroon
                        e.CellStyle.SelectionForeColor = Color.Maroon
                End Select
            ElseIf Me.dgvList.Columns(e.ColumnIndex).Name = "PaymentValidationState" AndAlso e.Value.ToString = "等待JV确认" Then
                e.CellStyle.ForeColor = Color.Blue
                e.CellStyle.SelectionForeColor = Color.Yellow
            ElseIf Me.dgvList.Columns(e.ColumnIndex).Name = "PendingAMT" AndAlso e.Value.ToString <> "" AndAlso e.Value > 0 Then
                e.CellStyle.ForeColor = Color.Green
                e.CellStyle.SelectionForeColor = Color.LightGreen
                e.CellStyle.Font = New Font(e.CellStyle.Font, FontStyle.Bold)
            End If
        Catch
        End Try
    End Sub

    Private Sub dgvList_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvList.ColumnHeaderMouseClick
        If sSelectedSalesBillDetailID <> "" AndAlso (Me.dgvList.CurrentRow Is Nothing OrElse currentRow("SalesBillDetailID").ToString <> sSelectedSalesBillDetailID) Then
            For Each drList As DataGridViewRow In Me.dgvList.Rows
                If drList.Cells("SalesBillDetailID").Value.ToString = sSelectedSalesBillDetailID Then
                    blSkipDeal = True
                    If Me.dgvList.CurrentCell IsNot Nothing Then
                        drList.Cells(Me.dgvList.CurrentCell.ColumnIndex).Selected = True
                    Else
                        drList.Cells("ActivationState").Selected = True
                    End If
                    drList.Selected = False
                    blSkipDeal = False
                    drList.Selected = True
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub dgvList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvList.DataError
        e.Cancel = True
    End Sub

    Private Sub dgvList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvList.KeyDown
        If e.Alt Then Return
        If e.Control OrElse (e.KeyCode >= Keys.A AndAlso e.KeyCode <= Keys.Z) OrElse (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            With frmSearchSalesBillDetail
                If Not e.Control Then
                    .sKeyCode = e.KeyCode.ToString
                    If e.KeyCode >= Keys.A AndAlso e.KeyCode <= Keys.Z Then
                        If (My.Computer.Keyboard.CapsLock AndAlso My.Computer.Keyboard.ShiftKeyDown) OrElse (Not My.Computer.Keyboard.CapsLock AndAlso Not My.Computer.Keyboard.ShiftKeyDown) Then .sKeyCode = .sKeyCode.ToLower
                    Else
                        .rdbByMediaNo.Checked = True
                    End If
                End If
            End With
            Me.SearchSalesBillDetail()
        End If
    End Sub

    Private Sub dgvList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvList.SelectionChanged
        If blSkipDeal Then Return

        If Me.dgvList.CurrentRow Is Nothing Then
            Dim mouseLocation As Point = Me.dgvList.PointToClient(Control.MousePosition)
            If Me.dgvList.HitTest(mouseLocation.X, mouseLocation.Y).RowIndex = -1 Then
                If currentRow IsNot Nothing Then sSelectedSalesBillDetailID = currentRow("SalesBillDetailID").ToString
                Return
            Else
                sSelectedSalesBillDetailID = ""
            End If

            Me.chbDisplaySelected.Checked = False
            If Me.dgvList.CurrentRow Is Nothing Then
                dvCard.RowFilter = "1=2"
                Me.lklFilter.Visible = False
                Me.chbSelectAllCards.Visible = False
                Return
            End If
        End If

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在检索购物卡列表……"
        frmMain.statusMain.Refresh()

        Call LockWindowUpdate(Me.Handle)

        Dim sSalesBillDetailID As String = Me.dgvList("SalesBillDetailID", Me.dgvList.CurrentRow.Index).Value.ToString, sStartCardNo As String = Me.dgvList("StartCardNo", Me.dgvList.CurrentRow.Index).Value.ToString, iCardQTY As Integer = Me.dgvList("CardQTY", Me.dgvList.CurrentRow.Index).Value - 1
        Dim drCard As DataRowView, blCanSelect As Boolean = False, blError As Boolean = False
        If sStartCardNo.IndexOf("2") = 0 Then
            sStartCardNo = sStartCardNo.Substring(0, 18)
            If sStartCardNo.Substring(4, 2) = "94" Then
                Me.lblCardTitle.Text = "活动卡列表："
            ElseIf sStartCardNo.Substring(4, 2) = "92" Then
                Me.lblCardTitle.Text = IIf(Me.dgvList("PaymentTermName", Me.dgvList.CurrentRow.Index).Value.ToString.IndexOf("返点卡") > -1, "营销卡列表：", "公关卡列表：")
            Else
                Me.lblCardTitle.Text = "磁条卡列表："
            End If
        ElseIf sStartCardNo.IndexOf("94") = 0 Then
            Me.lblCardTitle.Text = "活动券列表："
        ElseIf sStartCardNo.IndexOf("92") = 0 Then
            Me.lblCardTitle.Text = IIf(Me.dgvList("PaymentTermName", Me.dgvList.CurrentRow.Index).Value.ToString.IndexOf("返点卡") > -1, "营销券列表：", "公关券列表：")
        ElseIf sStartCardNo.Substring(5, 1) = "8" OrElse sStartCardNo.Substring(5, 3) = "100" Then
            Me.lblCardTitle.Text = "条码卡列表："
        Else
            Me.lblCardTitle.Text = "充值券列表："
        End If

        dvCard.RowFilter = "SalesBillDetailID=" & sSalesBillDetailID
        currentRow = dvList.Table.Rows.Find(sSalesBillDetailID)
        If dvCard.Count = 0 Then
            Dim DB As New DataBase
            DB.Open()
            If DB.IsConnected Then
                Try
                    Dim dtCard As DataTable = DB.GetDataTable("Exec GetCardRowActivation " & sSalesBillDetailID).Copy
                    DB.Close()
                    dvCard.Table.Merge(dtCard)

                    If dvCard.Count <> iCardQTY + 1 Then
                        Dim sCardNo As String
                        For iCard As Integer = 0 To iCardQTY
                            If sStartCardNo.IndexOf("2") = 0 Then
                                sCardNo = ShoppingCardNo.GetFullCardNo((CLng(sStartCardNo) + iCard).ToString)
                            Else
                                sCardNo = (CLng(sStartCardNo) + iCard).ToString
                            End If
                            If dvCard.ToTable.Select("CardNo='" & sCardNo & "'").Length = 0 Then
                                drCard = dvCard.AddNew()
                                drCard("SalesBillDetailID") = sSalesBillDetailID
                                drCard("Selected") = 0
                                drCard("CardNo") = sCardNo
                                drCard("FaceValue") = Me.dgvList("FaceValue", Me.dgvList.CurrentRow.Index).Value
                                drCard("ActivationState") = "等待激活"
                                drCard("NeedActivate") = 1
                                drCard.EndEdit()
                            End If
                        Next
                    End If
                Catch
                    frmMain.statusText.Text = "系统因在检索数据时出错而无法检索购物卡列表。请联系软件开发人员。"
                    blError = True
                End Try
            Else
                frmMain.statusText.Text = "系统因连接不到数据库而无法检索购物卡列表。请检查数据库连接。"
                blError = True
            End If
        End If

        blSkipDeal = True
        Dim iSelected As Integer = dvCard.ToTable.Select("Selected=1").Length
        If iSelected = 0 Then
            Me.chbSelectAllCards.CheckState = CheckState.Unchecked
        ElseIf iSelected = dvCard.Count Then
            Me.chbSelectAllCards.CheckState = CheckState.Checked
        Else
            Me.chbSelectAllCards.CheckState = CheckState.Indeterminate
        End If
        blSkipDeal = False

        blCanSelect = (dvCard.Table.Select("SalesBillDetailID=" & sSalesBillDetailID & " And NeedActivate=1").Length > 0)
        If blCanSelect Then
            Me.dgvCard.Columns("Selected").Visible = True
            If currentRow("ActivationState").ToString = "不可激活" Then
                Me.lklFilter.Visible = False
                Me.chbSelectAllCards.Visible = False
                If Not blError Then
                    Select Case currentRow("StateReason").ToString
                        Case "没有激活权限"
                            frmMain.statusText.Text = "您没有权限激活该行购物卡。"
                        Case "返点未通过审核"
                            frmMain.statusText.Text = "因为返点未通过审核，所以暂不能激活该行返点卡。"
                        Case "正常卡未全部激活"
                            frmMain.statusText.Text = "返点卡必须等到所在销售单的正常卡已经被激活之后才可以被激活。"
                        Case "JV未确认到账"
                            frmMain.statusText.Text = "因为所在付款单还未被JV确认到账，所以暂不能激活该行购物卡。"
                    End Select
                End If
            Else
                Me.lklFilter.Visible = (dvCard.Count > 10)
                Me.chbSelectAllCards.Visible = True
                If Not blError Then
                    If Me.chbSelectAllCards.CheckState = CheckState.Unchecked Then
                        frmMain.statusText.Text = "请在右边的购物卡列表中选择您想要激活的购物卡，或者双击该行选择激活该行" & IIf(dvCard.Count = 1, "", "的所有") & "购物卡。"
                    ElseIf Me.chbSelectAllCards.CheckState = CheckState.Checked Then
                        frmMain.statusText.Text = "请在右边的购物卡列表中选择您想要激活的购物卡，或者双击该行取消选择激活该行" & IIf(dvCard.Count = 1, "", "的所有") & "购物卡。"
                    Else
                        frmMain.statusText.Text = "请在右边的购物卡列表中选择您想要激活的购物卡，或者双击该行选择激活该行剩余的未被选择的购物卡。"
                    End If
                End If
            End If
        Else
            Me.lklFilter.Visible = False
            Me.chbSelectAllCards.Visible = False
            Me.dgvCard.Columns("Selected").Visible = False
            If Not blError Then frmMain.statusText.Text = "该行购物卡已经提交到CUL激活，不能再次选择或取消选择。"
        End If

        Me.dgvCard.Columns("FaceValue").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Me.dgvCard.Columns("FaceValue").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        If dvCard.ToTable.Select("Isnull(StateReason,'')<>''").Length > 0 Then
            Me.dgvCard.Columns("StateReason").Visible = True
            Me.dgvCard.Columns("StateReason").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.dgvCard.Columns("StateReason").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Else
            Me.dgvCard.Columns("StateReason").Visible = False
        End If
        Me.dgvCard.Columns("CULActivatedTime").Visible = (dvCard.ToTable.Compute("Count(CardNo)", "CULActivatedTime Is Not Null") > 0)

        Me.splitHorizontal.Panel2Collapsed = True
        Me.dgvCard.Height = Me.dgvList.Height
        Dim iWith As Integer = 0, blAlreadyAdjustWidth As Boolean = False
        For Each column As DataGridViewColumn In Me.dgvCard.Columns
            If column.Visible Then iWith += column.Width
        Next
        Try
            Me.splitVertical.SplitterDistance = Me.splitVertical.Width - iWith - 23 - IIf(ToolStripManager.VisualStylesEnabled, 0, 2)
        Catch
        End Try
        If Me.dgvCard.RowCount > Me.dgvCard.DisplayedRowCount(False) Then
            Try
                Me.splitVertical.SplitterDistance = Me.splitVertical.Width - iWith - 40 - IIf(ToolStripManager.VisualStylesEnabled, 0, 2)
                blAlreadyAdjustWidth = True
            Catch
            End Try
        End If

        If blCanSelect AndAlso Me.chbSelectAllCards.Visible = False Then
            Me.rtbRemarks.Clear()
            If currentRow("ActivationState").ToString = "不可激活" Then
                If currentRow("StateReason").ToString = "没有激活权限" Then
                    Me.rtbRemarks.AppendText("您只有查看购物卡激活状态的权限，但无激活购物卡的权限。")
                ElseIf currentRow("StateReason").ToString = "JV未确认到账" Then
                    Me.rtbRemarks.AppendText("因为所在付款单还未被JV确认到账，所以您暂不能激活该行购物卡。")
                ElseIf currentRow("RebateState") < 2 Then
                    Me.rtbRemarks.AppendText("该行购物卡是给予非合同客户的返点卡。并且，所在销售单的总体返点已经超过所在城市的返点标准。所以，必须满足下面条件才能激活这些卡： " & Chr(13) & Chr(13))
                    Me.rtbRemarks.AppendText("1、所在销售单的返点必须先经过相关人员审核；" & Chr(13))
                    Me.rtbRemarks.AppendText("2、所在销售单的所有正常卡（付费卡）必须先于返点卡之前激活。" & Chr(13) & Chr(13))
                    Me.rtbRemarks.AppendText("由于目前该单仍未通过审核" & IIf(Me.dgvList("RebateState", Me.dgvList.CurrentRow.Index).Value = 1, "（审核失败）", "") & "，所以暂不能激活这些返点卡。")
                ElseIf currentRow("RebateMode") = 1 Then
                    Me.rtbRemarks.AppendText("该行购物卡是给予非合同客户的返点卡。并且，")
                    If currentRow("RebateState") = 2 Then
                        Me.rtbRemarks.AppendText("所在销售单的总体返点在所在城市的返点标准之内。")
                    Else
                        Me.rtbRemarks.AppendText("所在销售单的返点已通过审核（批准）。")
                    End If
                    Me.rtbRemarks.AppendText("但是，由于所在销售单的正常卡（付费卡）还未完全激活，所以暂不能激活这些返点卡。" & Chr(13) & Chr(13))
                    Me.rtbRemarks.AppendText("请在激活所在销售单的所有正常卡后，再来激活这些返点卡。")
                ElseIf currentRow("RebateMode") = 4 Then
                    Me.rtbRemarks.AppendText("该行购物卡是给予内部员工的返点卡。内部员工返点卡必须在所在销售单的正常卡全部激活后才能激活。请先激活正常卡。")
                Else
                    Me.rtbRemarks.AppendText("该行购物卡是给予合同客户的返点卡。合同返点卡必须在所在销售单的正常卡全部激活后才能激活。请先激活正常卡。")
                End If
            Else
                If currentRow("PaymentTermName").ToString.IndexOf("（") = -1 Then Me.rtbRemarks.AppendText("当付款方式为""" & currentRow("PaymentTermName").ToString & """时，")
                Me.rtbRemarks.AppendText("您只能查看该行购物卡的激活状态，但无权限激活该行购物卡。")
            End If

            Me.splitHorizontal.Panel2Collapsed = False
            Me.dgvCard.Height += 6
            Dim iHight As Integer = Me.rtbRemarks.GetPositionFromCharIndex(Me.rtbRemarks.TextLength).Y + 52
            Try
                Me.splitHorizontal.SplitterDistance = Me.splitHorizontal.Height - iHight
            Catch
            End Try

            If Not blAlreadyAdjustWidth AndAlso Me.dgvCard.RowCount > Me.dgvCard.DisplayedRowCount(False) Then
                Try
                    Me.splitVertical.SplitterDistance = Me.splitVertical.Width - iWith - 40 - IIf(ToolStripManager.VisualStylesEnabled, 0, 2)
                    blAlreadyAdjustWidth = True
                Catch
                End Try
            End If
        End If

        If Not Me.dgvList.CurrentRow.Selected Then
            sTimerType = "SelectRow"
            Me.theTimer.Interval = 100
            Me.theTimer.Enabled = True
        End If

        Call LockWindowUpdate(0)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub lklFilter_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lklFilter.LinkClicked
        blCardFilterFormClosing = True
        Dim dvTemp As DataView = dvCard.ToTable(False, "Selected", "CardNo", "NeedActivate").DefaultView
        dvTemp.RowFilter = "NeedActivate=1"
        With frmCardFilter
            .dtAvailable = dvTemp.ToTable(False, "Selected", "CardNo")
            .dmFaceValue = dvCard(0)("FaceValue")
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Refresh()
                If Me.dgvList.Columns("OperationResult").Visible OrElse dvList.Table.Select("Isnull(OperationResult,'')<>''").Length > 0 Then
                    blSkipDeal = True
                    If Me.dgvList.Columns("PendingAMT").Visible Then
                        Me.dgvList("PendingAMT", Me.dgvList.CurrentRow.Index).Selected = True
                    Else
                        Me.dgvList("ActivationState", Me.dgvList.CurrentRow.Index).Selected = True
                    End If
                    blSkipDeal = False
                    Dim sSalesBillDetailID As String = currentRow("SalesBillDetailID").ToString

                    For Each dr As DataRow In dvList.Table.Select("PendingAMT>0")
                        If dr("ResultReason").ToString.IndexOf("销售单已被") = 0 Then
                            dr.Delete() : dr.AcceptChanges()
                        Else
                            dr("PendingAMT") = dr("FinalPendingAMT")
                            dr("OperationResult") = DBNull.Value
                            dr("ResultReason") = DBNull.Value
                            If dr("PendingAMT") = 0 Then dr.AcceptChanges()
                        End If
                    Next
                    Me.dgvList.Columns("OperationResult").Visible = False
                    Me.dgvList.Columns("ResultReason").Visible = False

                    If Me.dgvList.CurrentRow Is Nothing OrElse Me.dgvList("SalesBillDetailID", Me.dgvList.CurrentRow.Index).Value.ToString <> sSalesBillDetailID Then
                        If dvList.Table.Select("FinalPendingAMT>0").Length = 0 Then
                            Me.btnActivate.Enabled = False
                            Me.chbDisplaySelected.Checked = False
                            Me.chbDisplaySelected.Visible = False
                        End If
                        Return
                    End If
                End If

                Dim drCard As DataRow
                For Each dr As DataRow In .dtAvailable.Select("Selected=1")
                    drCard = dvCard.Table.Select("SalesBillDetailID=" & currentRow("SalesBillDetailID").ToString & " And CardNo='" & dr("CardNo").ToString & "'")(0)
                    drCard("Selected") = 0 : drCard.EndEdit()
                Next
                For Each dr As DataRow In .dtCard.Select("")
                    drCard = dvCard.Table.Select("SalesBillDetailID=" & currentRow("SalesBillDetailID").ToString & " And CardNo='" & dr("CardNo").ToString & "'")(0)
                    drCard("Selected") = 1 : drCard.EndEdit()
                Next

                Dim dmRowPendingAMT As Decimal = 0, dmSalesBillPendingAMT As Decimal = 0
                Try
                    dmRowPendingAMT = dvCard.ToTable.Compute("Sum(FaceValue)", "NeedActivate=1 And Selected=1")
                Catch
                End Try
                blSkipDeal = True
                currentRow("PendingAMT") = dmRowPendingAMT : currentRow("FinalPendingAMT") = dmRowPendingAMT : currentRow.EndEdit()
                blSkipDeal = False

                Try
                    dmSalesBillPendingAMT = dvList.Table.Compute("Sum(FinalPendingAMT)", "SalesBillID=" & currentRow("SalesBillID").ToString)
                Catch
                End Try
                Dim blNeedReset As Boolean = False
                For Each drList As DataRow In dvList.Table.Select("SalesBillID=" & currentRow("SalesBillID").ToString)
                    drList("NewSelectedAMT") = drList("SelectedAMT") + dmSalesBillPendingAMT
                    If currentRow("RowType") = 0 AndAlso drList("RowType") = 2 AndAlso drList("RebateState") > 1 Then '已审核过的返点卡行
                        If drList("NormalSalesAMT") <= currentRow("NewSelectedAMT") Then
                            drList("ActivationState") = "等待激活"
                            drList("StateReason") = DBNull.Value
                        Else
                            drList("ActivationState") = "不可激活"
                            drList("StateReason") = "正常卡未全部激活"
                            For Each drCard In dvCard.Table.Select("SalesBillDetailID=" & drList("SalesBillDetailID").ToString & " And Selected=1")
                                drCard("Selected") = 0
                            Next
                            drList("PendingAMT") = 0 : drList("FinalPendingAMT") = 0
                            blNeedReset = True
                        End If
                    End If
                    drList.EndEdit()
                Next
                If blNeedReset Then
                    Try
                        dmSalesBillPendingAMT = dvList.Table.Compute("Sum(FinalPendingAMT)", "SalesBillID=" & currentRow("SalesBillID").ToString)
                    Catch
                    End Try
                    For Each drList As DataRow In dvList.Table.Select("SalesBillID=" & currentRow("SalesBillID").ToString)
                        drList("NewSelectedAMT") = drList("SelectedAMT") + dmSalesBillPendingAMT : drList.EndEdit()
                        If drList("FinalPendingAMT") = 0 Then drList.AcceptChanges()
                    Next
                End If

                If Me.dgvList.CurrentRow IsNot Nothing AndAlso currentRow("SalesBillDetailID").ToString <> Me.dgvList("SalesBillDetailID", Me.dgvList.CurrentRow.Index).Value.ToString Then
                    blSkipDeal = True
                    Me.dgvList.CurrentRow.Selected = False
                    blSkipDeal = False
                    Me.dgvList.CurrentRow.Selected = True
                End If

                If dvList.ToTable.Select("PendingAMT>0").Length = 0 Then
                    If Me.dgvList.CurrentCell IsNot Nothing AndAlso Me.dgvList.Columns(Me.dgvList.CurrentCell.ColumnIndex).Name = "PendingAMT" Then
                        blSkipDeal = True
                        Me.dgvList("ActivationState", Me.dgvList.CurrentCell.RowIndex).Selected = True
                        blSkipDeal = False
                    End If
                    Me.dgvList.Columns("PendingAMT").Visible = False
                    Me.dgvList.Columns("OperationResult").Visible = False
                    Me.dgvList.Columns("ResultReason").Visible = False
                Else
                    Me.dgvList.Columns("PendingAMT").Visible = True
                End If

                If dvList.Table.Select("FinalPendingAMT>0").Length > 0 Then
                    Me.btnActivate.Enabled = True
                    Me.chbDisplaySelected.Visible = True
                Else
                    Me.btnActivate.Enabled = False
                    Me.chbDisplaySelected.Checked = False
                    Me.chbDisplaySelected.Visible = False
                End If

                blSkipDeal = True
                Dim iSelected As Integer = dvCard.ToTable.Select("Selected=1").Length
                If iSelected = 0 Then
                    Me.chbSelectAllCards.CheckState = CheckState.Unchecked
                ElseIf iSelected = dvCard.Count Then
                    Me.chbSelectAllCards.CheckState = CheckState.Checked
                Else
                    Me.chbSelectAllCards.CheckState = CheckState.Indeterminate
                End If
                blSkipDeal = False

                Dim dtCurrent As DataTable = dvList.ToTable(False, "RowPayableAMT", "FinalPendingAMT"), dmPendingChargedAMT As Decimal = 0, dmPendingPayableAMT As Decimal = 0
                Try
                    dmPendingChargedAMT = dtCurrent.Compute("Sum(FinalPendingAMT)", "")
                Catch
                End Try
                If dmPendingChargedAMT > 0 Then
                    Try
                        dmPendingPayableAMT = dtCurrent.Compute("Sum(RowPayableAMT)", "FinalPendingAMT>0")
                    Catch
                    End Try
                End If
                dtCurrent.Dispose() : dtCurrent = Nothing

                frmMain.statusText.Text = sSummaryInfo & "；已选择 -- 收款： " & Format(dmPendingPayableAMT, "#,0.00").Replace(".00", "") & " 元，充值： " & Format(dmPendingChargedAMT, "#,0.00").Replace(".00", "") & " 元。"
            End If
            .Dispose()
        End With
        dvTemp.Dispose() : dvTemp = Nothing
    End Sub

    Private Sub lklFilter_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lklFilter.MouseLeave
        Me.theTip.Active = True
    End Sub

    Private Sub chbSelectAllCards_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbSelectAllCards.CheckStateChanged
        If blSkipDeal Then Return

        If Me.dgvList.Columns("OperationResult").Visible OrElse dvList.Table.Select("Isnull(OperationResult,'')<>''").Length > 0 Then
            blSkipDeal = True
            If Me.dgvList.Columns("PendingAMT").Visible Then
                Me.dgvList("PendingAMT", Me.dgvList.CurrentRow.Index).Selected = True
            Else
                Me.dgvList("ActivationState", Me.dgvList.CurrentRow.Index).Selected = True
            End If
            blSkipDeal = False
            Dim sSalesBillDetailID As String = currentRow("SalesBillDetailID").ToString

            For Each dr As DataRow In dvList.Table.Select("PendingAMT>0")
                If dr("ResultReason").ToString.IndexOf("销售单已被") = 0 Then
                    dr.Delete() : dr.AcceptChanges()
                Else
                    dr("PendingAMT") = dr("FinalPendingAMT")
                    dr("OperationResult") = DBNull.Value
                    dr("ResultReason") = DBNull.Value
                    If dr("PendingAMT") = 0 Then dr.AcceptChanges()
                End If
            Next
            Me.dgvList.Columns("OperationResult").Visible = False
            Me.dgvList.Columns("ResultReason").Visible = False

            If Me.dgvList.CurrentRow Is Nothing OrElse Me.dgvList("SalesBillDetailID", Me.dgvList.CurrentRow.Index).Value.ToString <> sSalesBillDetailID Then
                If dvList.Table.Select("FinalPendingAMT>0").Length = 0 Then
                    Me.btnActivate.Enabled = False
                    Me.chbDisplaySelected.Checked = False
                    Me.chbDisplaySelected.Visible = False
                End If
                Return
            End If
        End If

        Dim bSelected As Byte = IIf(Me.chbSelectAllCards.CheckState = CheckState.Checked, 1, 0)

        For Each drCard As DataRow In dvCard.Table.Select("SalesBillDetailID=" & currentRow("SalesBillDetailID").ToString & " And NeedActivate=1")
            drCard("Selected") = bSelected : drCard.EndEdit()
        Next

        Dim dmRowPendingAMT As Decimal = 0, dmSalesBillPendingAMT As Decimal = 0
        Try
            dmRowPendingAMT = dvCard.ToTable.Compute("Sum(FaceValue)", "NeedActivate=1 And Selected=1")
        Catch
        End Try
        blSkipDeal = True
        currentRow("PendingAMT") = dmRowPendingAMT : currentRow("FinalPendingAMT") = dmRowPendingAMT : currentRow.EndEdit()
        blSkipDeal = False

        Try
            dmSalesBillPendingAMT = dvList.Table.Compute("Sum(FinalPendingAMT)", "SalesBillID=" & currentRow("SalesBillID").ToString)
        Catch
        End Try
        Dim blNeedReset As Boolean = False
        For Each drList As DataRow In dvList.Table.Select("SalesBillID=" & currentRow("SalesBillID").ToString)
            drList("NewSelectedAMT") = drList("SelectedAMT") + dmSalesBillPendingAMT
            If currentRow("RowType") = 0 AndAlso drList("RowType") = 2 AndAlso drList("RebateState") > 1 Then '已审核过的返点卡行
                If drList("NormalSalesAMT") <= currentRow("NewSelectedAMT") Then
                    drList("ActivationState") = "等待激活"
                    drList("StateReason") = DBNull.Value
                Else
                    drList("ActivationState") = "不可激活"
                    drList("StateReason") = "正常卡未全部激活"
                    For Each drCard In dvCard.Table.Select("SalesBillDetailID=" & drList("SalesBillDetailID").ToString & " And Selected=1")
                        drCard("Selected") = 0
                    Next
                    drList("PendingAMT") = 0 : drList("FinalPendingAMT") = 0
                    blNeedReset = True
                End If
            End If
            drList.EndEdit()
        Next
        If blNeedReset Then
            Try
                dmSalesBillPendingAMT = dvList.Table.Compute("Sum(FinalPendingAMT)", "SalesBillID=" & currentRow("SalesBillID").ToString)
            Catch
            End Try
            For Each drList As DataRow In dvList.Table.Select("SalesBillID=" & currentRow("SalesBillID").ToString)
                drList("NewSelectedAMT") = drList("SelectedAMT") + dmSalesBillPendingAMT : drList.EndEdit()
                If drList("FinalPendingAMT") = 0 Then drList.AcceptChanges()
            Next
        End If

        If Me.dgvList.CurrentRow IsNot Nothing AndAlso currentRow("SalesBillDetailID").ToString <> Me.dgvList("SalesBillDetailID", Me.dgvList.CurrentRow.Index).Value.ToString Then
            blSkipDeal = True
            Me.dgvList.CurrentRow.Selected = False
            blSkipDeal = False
            Me.dgvList.CurrentRow.Selected = True
        End If

        If dvList.ToTable.Select("PendingAMT>0").Length = 0 Then
            If Me.dgvList.CurrentCell IsNot Nothing AndAlso Me.dgvList.Columns(Me.dgvList.CurrentCell.ColumnIndex).Name = "PendingAMT" Then
                blSkipDeal = True
                Me.dgvList("ActivationState", Me.dgvList.CurrentCell.RowIndex).Selected = True
                blSkipDeal = False
            End If
            Me.dgvList.Columns("PendingAMT").Visible = False
            Me.dgvList.Columns("OperationResult").Visible = False
            Me.dgvList.Columns("ResultReason").Visible = False
        Else
            Me.dgvList.Columns("PendingAMT").Visible = True
        End If

        If dvList.Table.Select("FinalPendingAMT>0").Length > 0 Then
            Me.btnActivate.Enabled = True
            Me.chbDisplaySelected.Visible = True
        Else
            Me.btnActivate.Enabled = False
            Me.chbDisplaySelected.Checked = False
            Me.chbDisplaySelected.Visible = False
        End If

        Dim dtCurrent As DataTable = dvList.ToTable(False, "RowPayableAMT", "FinalPendingAMT"), dmPendingChargedAMT As Decimal = 0, dmPendingPayableAMT As Decimal = 0
        Try
            dmPendingChargedAMT = dtCurrent.Compute("Sum(FinalPendingAMT)", "")
        Catch
        End Try
        If dmPendingChargedAMT > 0 Then
            Try
                dmPendingPayableAMT = dtCurrent.Compute("Sum(RowPayableAMT)", "FinalPendingAMT>0")
            Catch
            End Try
        End If
        dtCurrent.Dispose() : dtCurrent = Nothing

        frmMain.statusText.Text = sSummaryInfo & "；已选择 -- 收款： " & Format(dmPendingPayableAMT, "#,0.00").Replace(".00", "") & " 元，充值： " & Format(dmPendingChargedAMT, "#,0.00").Replace(".00", "") & " 元。"
    End Sub

    Private Sub chbSelectAllCards_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbSelectAllCards.Click
        If Me.chbSelectAllCards.CheckState = CheckState.Checked Then
            If dvCard.ToTable.Select("NeedActivate=0").Length > 0 Then
                Me.chbSelectAllCards.CheckState = CheckState.Indeterminate
            Else
                Me.chbSelectAllCards.CheckState = CheckState.Unchecked
            End If
        Else
            Me.chbSelectAllCards.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub dgvCard_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCard.CellContentClick
        If e.ColumnIndex <> 1 OrElse e.RowIndex = -1 Then Return

        If Me.dgvList.Columns("OperationResult").Visible OrElse dvList.Table.Select("Isnull(OperationResult,'')<>''").Length > 0 Then
            blSkipDeal = True
            If Me.dgvList.Columns("PendingAMT").Visible Then
                Me.dgvList("PendingAMT", Me.dgvList.CurrentRow.Index).Selected = True
            Else
                Me.dgvList("ActivationState", Me.dgvList.CurrentRow.Index).Selected = True
            End If
            blSkipDeal = False
            Dim sSalesBillDetailID As String = currentRow("SalesBillDetailID").ToString

            For Each dr As DataRow In dvList.Table.Select("PendingAMT>0")
                If dr("ResultReason").ToString.IndexOf("销售单已被") = 0 Then
                    dr.Delete() : dr.AcceptChanges()
                Else
                    dr("PendingAMT") = dr("FinalPendingAMT")
                    dr("OperationResult") = DBNull.Value
                    dr("ResultReason") = DBNull.Value
                    dr.EndEdit()
                    If dr("PendingAMT") = 0 Then dr.AcceptChanges()
                End If
            Next
            Me.dgvList.Columns("OperationResult").Visible = False
            Me.dgvList.Columns("ResultReason").Visible = False

            If Me.dgvList.CurrentRow Is Nothing OrElse Me.dgvList("SalesBillDetailID", Me.dgvList.CurrentRow.Index).Value.ToString <> sSalesBillDetailID Then
                If dvList.Table.Select("FinalPendingAMT>0").Length = 0 Then
                    Me.btnActivate.Enabled = False
                    Me.chbDisplaySelected.Checked = False
                    Me.chbDisplaySelected.Visible = False
                End If
                Return
            End If
        End If

        If Me.chbSelectAllCards.Visible = False Then
            Select Case currentRow("StateReason").ToString
                Case "没有激活权限"
                    frmMain.statusText.Text = "您没有权限激活该行购物卡。"
                Case "返点未通过审核", "正常卡未全部激活"
                    frmMain.statusText.Text = "该卡目前不可选择激活，因为所在销售单的" & currentRow("StateReason").ToString & "。"
                Case "JV未确认到账"
                    frmMain.statusText.Text = "该卡目前不可选择激活，因为所在付款单还未被JV确认到账。"
            End Select
            Return
        ElseIf Not Me.dgvCard("NeedActivate", e.RowIndex).Value Then
            frmMain.statusText.Text = "该购物卡已经提交到CUL激活，不能再次选择或取消选择。"
            Return
        End If

        Dim drCard As DataRow = dvCard.Table.Select("SalesBillDetailID=" & currentRow("SalesBillDetailID").ToString & " And CardNo='" & Me.dgvCard("CardNo", e.RowIndex).Value.ToString & "'")(0)
        drCard("Selected") = IIf(drCard("Selected"), 0, 1) : drCard.EndEdit()

        Dim dmRowPendingAMT As Decimal = 0, dmSalesBillPendingAMT As Decimal = 0
        Try
            dmRowPendingAMT = dvCard.ToTable.Compute("Sum(FaceValue)", "NeedActivate=1 And Selected=1")
        Catch
        End Try
        blSkipDeal = True
        currentRow("PendingAMT") = dmRowPendingAMT : currentRow("FinalPendingAMT") = dmRowPendingAMT : currentRow.EndEdit()
        blSkipDeal = False

        Try
            dmSalesBillPendingAMT = dvList.Table.Compute("Sum(FinalPendingAMT)", "SalesBillID=" & currentRow("SalesBillID").ToString)
        Catch
        End Try
        Dim blNeedReset As Boolean = False
        For Each drList As DataRow In dvList.Table.Select("SalesBillID=" & currentRow("SalesBillID").ToString)
            drList("NewSelectedAMT") = drList("SelectedAMT") + dmSalesBillPendingAMT
            If currentRow("RowType") = 0 AndAlso drList("RowType") = 2 AndAlso drList("RebateState") > 1 Then '已审核过的返点卡行
                If drList("NormalSalesAMT") <= currentRow("NewSelectedAMT") Then
                    drList("ActivationState") = "等待激活"
                    drList("StateReason") = DBNull.Value
                Else
                    drList("ActivationState") = "不可激活"
                    drList("StateReason") = "正常卡未全部激活"
                    For Each drCard In dvCard.Table.Select("SalesBillDetailID=" & drList("SalesBillDetailID").ToString & " And Selected=1")
                        drCard("Selected") = 0
                    Next
                    drList("PendingAMT") = 0 : drList("FinalPendingAMT") = 0
                    blNeedReset = True
                End If
            End If
            drList.EndEdit()
        Next
        If blNeedReset Then
            Try
                dmSalesBillPendingAMT = dvList.Table.Compute("Sum(FinalPendingAMT)", "SalesBillID=" & currentRow("SalesBillID").ToString)
            Catch
            End Try
            For Each drList As DataRow In dvList.Table.Select("SalesBillID=" & currentRow("SalesBillID").ToString)
                drList("NewSelectedAMT") = drList("SelectedAMT") + dmSalesBillPendingAMT : drList.EndEdit()
                If drList("FinalPendingAMT") = 0 Then drList.AcceptChanges()
            Next
        End If

        If Me.dgvList.CurrentRow IsNot Nothing AndAlso currentRow("SalesBillDetailID").ToString <> Me.dgvList("SalesBillDetailID", Me.dgvList.CurrentRow.Index).Value.ToString Then
            blSkipDeal = True
            Me.dgvList.CurrentRow.Selected = False
            blSkipDeal = False
            Me.dgvList.CurrentRow.Selected = True
        End If

        If dvList.ToTable.Select("PendingAMT>0").Length = 0 Then
            If Me.dgvList.CurrentCell IsNot Nothing AndAlso Me.dgvList.Columns(Me.dgvList.CurrentCell.ColumnIndex).Name = "PendingAMT" Then
                blSkipDeal = True
                Me.dgvList("ActivationState", Me.dgvList.CurrentCell.RowIndex).Selected = True
                blSkipDeal = False
            End If
            Me.dgvList.Columns("PendingAMT").Visible = False
            Me.dgvList.Columns("OperationResult").Visible = False
            Me.dgvList.Columns("ResultReason").Visible = False
        Else
            Me.dgvList.Columns("PendingAMT").Visible = True
        End If

        blSkipDeal = True
        Dim iSelected As Integer = dvCard.ToTable.Select("Selected=1").Length
        If iSelected = 0 Then
            Me.chbSelectAllCards.CheckState = CheckState.Unchecked
        ElseIf iSelected = dvCard.Count Then
            Me.chbSelectAllCards.CheckState = CheckState.Checked
        Else
            Me.chbSelectAllCards.CheckState = CheckState.Indeterminate
        End If
        blSkipDeal = False

        If dvList.Table.Select("FinalPendingAMT>0").Length > 0 Then
            Me.btnActivate.Enabled = True
            Me.chbDisplaySelected.Visible = True
        Else
            Me.btnActivate.Enabled = False
            Me.chbDisplaySelected.Checked = False
            Me.chbDisplaySelected.Visible = False
        End If

        Dim dtCurrent As DataTable = dvList.ToTable(False, "RowPayableAMT", "FinalPendingAMT"), dmPendingChargedAMT As Decimal = 0, dmPendingPayableAMT As Decimal = 0
        Try
            dmPendingChargedAMT = dtCurrent.Compute("Sum(FinalPendingAMT)", "")
        Catch
        End Try
        If dmPendingChargedAMT > 0 Then
            Try
                dmPendingPayableAMT = dtCurrent.Compute("Sum(RowPayableAMT)", "FinalPendingAMT>0")
            Catch
            End Try
        End If
        dtCurrent.Dispose() : dtCurrent = Nothing

        frmMain.statusText.Text = sSummaryInfo & "；已选择 -- 收款： " & Format(dmPendingPayableAMT, "#,0.00").Replace(".00", "") & " 元，充值： " & Format(dmPendingChargedAMT, "#,0.00").Replace(".00", "") & " 元。"
    End Sub

    Private Sub dgvCard_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvCard.CellFormatting
        Try
            If Me.chbSelectAllCards.Visible = False OrElse Me.dgvCard("NeedActivate", e.RowIndex).Value.ToString = "False" Then
                e.CellStyle.BackColor = SystemColors.Control
                e.CellStyle.SelectionBackColor = SystemColors.GradientInactiveCaption
            End If
            If Me.dgvCard.Columns(e.ColumnIndex).Name = "ActivationState" OrElse Me.dgvCard.Columns(e.ColumnIndex).Name = "StateReason" Then
                Select Case Me.dgvCard("ActivationState", e.RowIndex).Value.ToString
                    Case "正在激活"
                        e.CellStyle.ForeColor = Color.Green
                        If Me.chbSelectAllCards.Visible = False OrElse Me.dgvCard("NeedActivate", e.RowIndex).Value.ToString = "False" Then
                            e.CellStyle.SelectionForeColor = Color.Green
                        Else
                            e.CellStyle.SelectionForeColor = Color.LightGreen
                        End If
                    Case "激活失败"
                        e.CellStyle.ForeColor = Color.Red
                        e.CellStyle.SelectionForeColor = Color.Red
                End Select
            End If
        Catch
        End Try
    End Sub

    Private Sub chbDisplaySelected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbDisplaySelected.CheckedChanged
        Dim sSalesBillDetailID As String = ""
        If Me.dgvList.CurrentRow IsNot Nothing Then sSalesBillDetailID = Me.dgvList("SalesBillDetailID", Me.dgvList.CurrentRow.Index).Value.ToString

        blSkipDeal = True
        If Me.chbDisplaySelected.Checked Then
            Me.tlpConditions.Enabled = False
            dvList.RowFilter = "PendingAMT>0"
        Else
            Me.tlpConditions.Enabled = True
            dvList.RowFilter = sRowFilter
        End If

        Dim dtTemp As DataTable = dvList.ToTable
        With Me.dgvList
            .Columns("PaymentDescription").Visible = (dtTemp.Select("Isnull(PaymentDescription,'')<>''").Length > 0)
            .Columns("MediaNo").Visible = (dtTemp.Select("Isnull(MediaNo,'')<>''").Length > 0)
            .Columns("PayerName").Visible = .Columns("MediaNo").Visible
            .Columns("PaymentValidationState").Visible = (dtTemp.Select("Isnull(PaymentValidationState,'')<>''").Length > 0)
            .Columns("InactivatedAMT").Visible = (dtTemp.Select("RowActivatedAMT>0 And RowActivatedAMT<RowChargedAMT").Length > 0)
            .Columns("ActivatorName").Visible = (dtTemp.Select("Isnull(ActivatorName,'')<>''").Length > 0)
            .Columns("ActivatedTime").Visible = .Columns("ActivatorName").Visible
            .Columns("StateReason").Visible = (dtTemp.Select("Isnull(StateReason,'')<>''").Length > 0)
            .Columns("PendingAMT").Visible = (dtTemp.Select("PendingAMT>0").Length > 0)
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
        blSkipDeal = False

        Me.dgvList.Select()
        If sSalesBillDetailID <> "" AndAlso dtTemp.Select("SalesBillDetailID=" & sSalesBillDetailID).Length > 0 Then
            For Each drList As DataGridViewRow In Me.dgvList.Rows
                If drList.Cells("SalesBillDetailID").Value.ToString = sSalesBillDetailID Then
                    blSkipDeal = True
                    If Me.dgvList.CurrentCell IsNot Nothing Then
                        drList.Cells(Me.dgvList.CurrentCell.ColumnIndex).Selected = True
                    Else
                        drList.Cells("ActivationState").Selected = True
                    End If
                    drList.Selected = False
                    blSkipDeal = False
                    drList.Selected = True
                    Exit For
                End If
            Next
        ElseIf dvList.Count > 0 Then
            blSkipDeal = True
            Me.dgvList("ActivationState", 0).Selected = True
            Me.dgvList.Rows(0).Selected = False
            blSkipDeal = False
            Me.dgvList.Rows(0).Selected = True
        Else
            dvCard.RowFilter = "1=2"
            Me.chbSelectAllCards.Visible = False
            Dim iWith As Integer = 0
            For Each column As DataGridViewColumn In Me.dgvCard.Columns
                If column.Visible Then iWith += column.Width
            Next
            Try
                Me.splitVertical.SplitterDistance = Me.splitVertical.Width - iWith - 23
            Catch
            End Try
        End If
        dtTemp.Dispose() : dtTemp = Nothing

        If Me.chbDisplaySelected.Checked Then
            Me.dgvList.Columns("PendingAMT").Visible = True
            Me.dgvList.FirstDisplayedScrollingColumnIndex = Me.dgvList.Columns("PendingAMT").Index
        End If

        Me.SummaryInfo()
    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Me.SearchSalesBillDetail()
    End Sub

    Private Sub btnActivate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActivate.Click
        Me.SaveChanges()
    End Sub

    Private Sub SummaryInfo()
        Dim dmSalesBillPayableAMT As Decimal = 0, dmSalesBillChargedAMT As Decimal = 0, dmSelectedPayableAMT As Decimal = 0, dmSelectedChargedAMT As Decimal = 0, dmPendingPayableAMT As Decimal = 0, dmPendingChargedAMT As Decimal = 0

        Dim dtCurrent As DataTable = dvList.ToTable(False, "RowPayableAMT", "RowChargedAMT", "RowSelectedAMT", "FinalPendingAMT", "ActivationState")
        Try
            dmSalesBillPayableAMT = dtCurrent.Compute("Sum(RowPayableAMT)", "")
        Catch
        End Try
        Try
            dmSalesBillChargedAMT = dtCurrent.Compute("Sum(RowChargedAMT)", "")
        Catch
        End Try
        Try
            dmSelectedChargedAMT = dtCurrent.Compute("Sum(RowSelectedAMT)", "")
        Catch
        End Try
        Try
            dmSelectedPayableAMT = dtCurrent.Compute("Sum(RowPayableAMT)", "ActivationState<>'不可激活' And ActivationState<>'等待激活'")
        Catch
        End Try
        Try
            dmPendingChargedAMT = dtCurrent.Compute("Sum(FinalPendingAMT)", "")
        Catch
        End Try
        Try
            dmPendingPayableAMT = dtCurrent.Compute("Sum(RowPayableAMT)", "FinalPendingAMT>0")
        Catch
        End Try
        dtCurrent.Dispose() : dtCurrent = Nothing

        sSummaryInfo = "总计 -- 收款： " & Format(dmSalesBillPayableAMT, "#,0.00").Replace(".00", "") & " 元，充值： " & Format(dmSalesBillChargedAMT, "#,0.00").Replace(".00", "") & " 元"
        If dmSelectedChargedAMT > 0 Then sSummaryInfo = sSummaryInfo & "；已完成 -- 收款： " & Format(dmSelectedPayableAMT, "#,0.00").Replace(".00", "") & " 元，充值： " & Format(dmSelectedChargedAMT, "#,0.00").Replace(".00", "") & " 元"
        If dmPendingChargedAMT = 0 Then
            frmMain.statusText.Text = sSummaryInfo & "。"
        Else
            frmMain.statusText.Text = sSummaryInfo & "；已选择 -- 收款： " & Format(dmPendingPayableAMT, "#,0.00").Replace(".00", "") & " 元，充值： " & Format(dmPendingChargedAMT, "#,0.00").Replace(".00", "") & " 元。"
        End If
    End Sub

    Private Sub GetActivationList()
        Dim iNeedGetDataStores As Int16 = 0, sStoreID As String = "", sSalesDate As String = Me.cbbSalesDate.Text
        If Me.cbbSalesDate.SelectedIndex > 1 Then
            If Me.cbbStore.SelectedValue = -1 Then
                For Each drStore As DataRow In dtStore.Select("AreaID<>-1")
                    sStoreID = drStore("AreaID").ToString
                    dvLoaded.RowFilter = "StoreID=" & sStoreID & " And SalesDate='" & sSalesDate & "'"
                    If dvLoaded.Count = 0 Then iNeedGetDataStores += 1
                    If iNeedGetDataStores > 1 Then Exit For
                Next
            Else
                sStoreID = Me.cbbStore.SelectedValue.ToString
                dvLoaded.RowFilter = "StoreID=" & sStoreID & " And SalesDate='" & sSalesDate & "'"
                If dvLoaded.Count = 0 Then iNeedGetDataStores = 1
            End If
        End If

        Call LockWindowUpdate(Me.dgvList.Handle)

        If iNeedGetDataStores > 0 Then
            Me.Cursor = Cursors.Default
            frmMain.statusText.Text = "正在检索""" & sSalesDate & """的销售单……"
            frmMain.statusMain.Refresh()

            Dim DB As New DataBase
            DB.Open()
            If Not DB.IsConnected Then
                sSalesDateError = "系统因连接不到数据库而无法检索购物卡列表。请在检查数据库连接后，重新输入该日期重试。"
                frmMain.statusText.Text = sSalesDateError
                Me.cbbSalesDate.Select()
                Me.cbbSalesDate.SelectionStart = 0 : Me.cbbSalesDate.SelectionLength = 10
                Me.cbbSalesDate.DroppedDown = True
                Me.Cursor = Cursors.Default
                Call LockWindowUpdate(0)
                Return
            End If

            If blCanActivate Then '先将新销售单移入对应的Pending表
                Try
                    DB.ModifyTable("Exec MoveNew2Pending " & frmMain.sLoginUserID)
                Catch
                End Try
            End If

            Try
                Dim sSQL As String = "Exec " & sProcedureName & " "
                If iNeedGetDataStores = 1 Then
                    sSQL = sSQL & "@StoreID=" & sStoreID
                Else
                    sSQL = sSQL & "@LoginUserID=" & frmMain.sLoginUserID
                End If
                sSQL = sSQL & ",@SalesDate='" & sSalesDate & "'"
                Dim dtList = DB.GetDataTable(sSQL).Copy
                If dtList.Rows.Count = 0 Then
                    Call LockWindowUpdate(0)
                    MessageBox.Show("该日不存在任何销售单！    ", "没有销售单！", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    If Not blCanActivate Then
                        For Each dr As DataRow In dtList.Select("ActivationState='等待激活'")
                            dr("ActivationState") = "不可激活"
                            dr("StateReason") = "没有激活权限"
                        Next
                    End If
                    dtList.AcceptChanges()
                    dvList.Table.Merge(dtList.Copy, True)

                    Dim dtNewSalesman As DataTable = dvList.ToTable(True, "StoreID", "CreatorID", "CreatorName")
                    For Each drSalesman As DataRow In dtNewSalesman.Rows
                        If dvSalesman.Table.Select("CreatorID=" & drSalesman("CreatorID").ToString).Length = 0 Then
                            dvSalesman.Table.Rows.Add(drSalesman("StoreID"), drSalesman("CreatorID"), drSalesman("CreatorName")).AcceptChanges()
                        End If
                    Next
                    dtNewSalesman.Dispose() : dtNewSalesman = Nothing
                End If
                dtList.Dispose() : dtList = Nothing
            Catch
                sSalesDateError = "系统因在检索数据时出错而无法检索""" & sSalesDate & """的销售单。请联系软件开发人员。请从销售日期列表中选择另一个现有项。"
                frmMain.statusText.Text = sSalesDateError
                Me.cbbSalesDate.Select()
                Me.cbbSalesDate.SelectionStart = 0 : Me.cbbSalesDate.SelectionLength = 10
                Me.cbbSalesDate.DroppedDown = True
                Me.Cursor = Cursors.Default
                Call LockWindowUpdate(0)
                Return
            End Try

            If dtToday < CDate(sSalesDate) Then
                dtToday = CDate(sSalesDate)
                blSkipDeal = True
                With Me.cbbSalesDate
                    .Items.Clear()
                    .Items.Add("（所有日期）")
                    .Items.Add("（最近一周）")
                    For bDay As Byte = 0 To 6
                        .Items.Add(Format(DateAdd(DateInterval.Day, -bDay, dtToday), "yyyy\/MM\/dd"))
                    Next
                    .Items.Add("选择其它日期…")
                    .Text = sSalesDate
                End With
                blSkipDeal = False
            End If

            Dim drLoaded As DataRowView
            If iNeedGetDataStores = 1 Then
                drLoaded = dvLoaded.AddNew
                drLoaded("StoreID") = sStoreID
                drLoaded("SalesDate") = sSalesDate
                drLoaded("LoadedTime") = Now
                drLoaded("IsRefreshed") = 0
                drLoaded.EndEdit() : drLoaded.Row.AcceptChanges()
            Else
                For Each drStore As DataRow In dtStore.Rows
                    sStoreID = drStore("AreaID").ToString
                    dvLoaded.RowFilter = "StoreID=" & sStoreID & " And SalesDate='" & sSalesDate & "'"
                    If dvLoaded.Count = 0 Then
                        drLoaded = dvLoaded.AddNew
                        drLoaded("StoreID") = sStoreID
                        drLoaded("SalesDate") = sSalesDate
                        drLoaded.EndEdit() : drLoaded.Row.AcceptChanges()
                    End If
                Next
            End If
            Me.Cursor = Cursors.Default
        End If

        blSkipDeal = True
        If Me.cbbStore.SelectedValue = -1 Then
            dvSalesman.RowFilter = ""
        Else
            dvSalesman.RowFilter = "CreatorID=-1 Or StoreID=" & Me.cbbStore.SelectedValue.ToString
        End If
        If dvSalesman.Count = 2 Then
            If Me.cbbStore.SelectedValue = -1 Then
                dvSalesman.RowFilter = "CreatorID<>-1"
            Else
                dvSalesman.RowFilter = "StoreID=" & Me.cbbStore.SelectedValue.ToString
            End If
        End If
        Me.cbbSalesman.SelectedIndex = 0
        blSkipDeal = False

        If Me.cbbStore.SelectedValue <> -1 AndAlso IsDate(Me.cbbSalesDate.Text) Then
            If CDate(Me.cbbSalesDate.Text) = dtToday Then
                Me.btnRefresh.Visible = True
            Else
                Try
                    Me.btnRefresh.Visible = (dvList.Table.Compute("Sum(InactivatedAMT)", "StoreID=" & Me.cbbStore.SelectedValue.ToString & " And SalesDate='" & Me.cbbSalesDate.Text & "'") > 0)
                Catch
                    Me.btnRefresh.Visible = False
                End Try
            End If
        Else
            Me.btnRefresh.Visible = False
        End If

        Me.SetRowFilter()
        Call LockWindowUpdate(0)
    End Sub

    Private Sub SetRowFilter()
        Dim sOldRowFilter As String = sRowFilter
        sRowFilter = ""

        If Me.pnlCity.Visible AndAlso Me.cbbCity.SelectedValue <> -2 Then sRowFilter = "(CityID=" & Me.cbbCity.SelectedValue.ToString & ")"

        If Me.pnlStore.Visible AndAlso Me.cbbStore.SelectedValue <> -1 Then sRowFilter = IIf(sRowFilter = "", "", sRowFilter & " And ") & "(StoreID=" & Me.cbbStore.SelectedValue.ToString & ")"

        If Me.pnlSalesBillType.Visible AndAlso Me.cbbSalesBillType.Text <> "（所有类型）" Then sRowFilter = IIf(sRowFilter = "", "", sRowFilter & " And ") & "(SalesBillType='" & Me.cbbSalesBillType.Text & "')"

        If Me.cbbSalesDate.SelectedIndex = 1 Then
            sRowFilter = IIf(sRowFilter = "", "", sRowFilter & " And ") & "(SalesDate>= '" & Format(DateAdd(DateInterval.Day, -6, dtToday), "yyyy\/MM\/dd") & "' And SalesDate<= '" & Format(dtToday, "yyyy\/MM\/dd") & "')"
        ElseIf Me.cbbSalesDate.SelectedIndex = -1 OrElse Me.cbbSalesDate.SelectedIndex > 1 Then
            sRowFilter = IIf(sRowFilter = "", "", sRowFilter & " And ") & "(SalesDate='" & Me.cbbSalesDate.Text & "')"
        End If

        If Me.cbbSalesman.SelectedIndex > 0 Then sRowFilter = IIf(sRowFilter = "", "", sRowFilter & " And ") & "(CreatorID=" & Me.cbbSalesman.SelectedValue.ToString & ")"

        If Me.cbbPaymentTerm.SelectedIndex > 0 Then
            Select Case Me.cbbPaymentTerm.Text
                Case "现金/银行卡"
                    sRowFilter = IIf(sRowFilter = "", "", sRowFilter & " And ") & "(PaymentTermName='现金' Or PaymentTermName='银行卡')"
                Case "转账/支票"
                    sRowFilter = IIf(sRowFilter = "", "", sRowFilter & " And ") & "(PaymentTermName='转账' Or PaymentTermName='支票')"
                Case Else
                    sRowFilter = IIf(sRowFilter = "", "", sRowFilter & " And ") & "(PaymentTermName='" & Me.cbbPaymentTerm.Text & "')"
            End Select
        End If

        Select Case Me.cbbActivationState.SelectedIndex
            Case 0
                sRowFilter = IIf(sRowFilter = "", "", sRowFilter & " And ") & "(ActivationState<>'不可激活') And (RowSelectedAMT<RowChargedAMT)" '可以激活
            Case 1
                sRowFilter = IIf(sRowFilter = "", "", sRowFilter & " And ") & "(ActivationState<>'不可激活') And (RowSelectedAMT=0)" '等待激活
            Case 2
                sRowFilter = IIf(sRowFilter = "", "", sRowFilter & " And ") & "(ActivationState<>'不可激活') And (RowSelectedAMT<RowChargedAMT And RowSelectedAMT>0)" '部分未激活
            Case 3
                sRowFilter = IIf(sRowFilter = "", "", sRowFilter & " And ") & "(ActivationState<>'全部激活')" '未全部激活
            Case 4
                sRowFilter = IIf(sRowFilter = "", "", sRowFilter & " And ") & "(ActivationState<>'不可激活') And (RowSelectedAMT=0)" '等待激活
            Case 5
                sRowFilter = IIf(sRowFilter = "", "", sRowFilter & " And ") & "(ActivationState<>'不可激活') And (RowSelectedAMT<RowChargedAMT And RowSelectedAMT>0)" '部分未激活
            Case 6
                sRowFilter = IIf(sRowFilter = "", "", sRowFilter & " And ") & "(ActivationState='不可激活')" '不可激活
            Case 7
                sRowFilter = IIf(sRowFilter = "", "", sRowFilter & " And ") & "(Substring(CardStates,2,1)='1')" '正在激活
            Case 8
                sRowFilter = IIf(sRowFilter = "", "", sRowFilter & " And ") & "(Substring(CardStates,3,2)='11')" '部分失败
            Case 9
                sRowFilter = IIf(sRowFilter = "", "", sRowFilter & " And ") & "(Substring(CardStates,3,2)='10')" '全部失败
            Case 10
                sRowFilter = IIf(sRowFilter = "", "", sRowFilter & " And ") & "(ActivationState='全部激活')" '全部激活
        End Select

        If sRowFilter = sOldRowFilter Then Return

        Dim sSalesBillDetailID As String = ""
        If Me.dgvList.CurrentRow IsNot Nothing Then sSalesBillDetailID = Me.dgvList("SalesBillDetailID", Me.dgvList.CurrentRow.Index).Value.ToString
        blSkipDeal = True
        dvList.RowFilter = sRowFilter
        Dim dtTemp As DataTable = dvList.ToTable
        With Me.dgvList
            .Columns("PaymentDescription").Visible = (dtTemp.Select("Isnull(PaymentDescription,'')<>''").Length > 0)
            .Columns("MediaNo").Visible = (dtTemp.Select("Isnull(MediaNo,'')<>''").Length > 0)
            .Columns("PayerName").Visible = .Columns("MediaNo").Visible
            .Columns("PaymentValidationState").Visible = (dtTemp.Select("Isnull(PaymentValidationState,'')<>''").Length > 0)
            .Columns("InactivatedAMT").Visible = (dtTemp.Select("RowActivatedAMT>0 And RowActivatedAMT<RowChargedAMT").Length > 0)
            .Columns("ActivatorName").Visible = (dtTemp.Select("Isnull(ActivatorName,'')<>''").Length > 0)
            .Columns("ActivatedTime").Visible = .Columns("ActivatorName").Visible
            .Columns("StateReason").Visible = (dtTemp.Select("Isnull(StateReason,'')<>''").Length > 0)
            .Columns("PendingAMT").Visible = (dtTemp.Select("PendingAMT>0").Length > 0)
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
        blSkipDeal = False

        If dvList.Count > 0 Then Me.dgvList.Select()
        If sSalesBillDetailID <> "" AndAlso dtTemp.Select("SalesBillDetailID=" & sSalesBillDetailID).Length > 0 Then
            For Each drList As DataGridViewRow In Me.dgvList.Rows
                If drList.Cells("SalesBillDetailID").Value.ToString = sSalesBillDetailID Then
                    blSkipDeal = True
                    If Me.dgvList.CurrentCell IsNot Nothing Then
                        drList.Cells(Me.dgvList.CurrentCell.ColumnIndex).Selected = True
                    Else
                        drList.Cells("ActivationState").Selected = True
                    End If
                    drList.Selected = False
                    blSkipDeal = False
                    drList.Selected = True
                    Exit For
                End If
            Next
        ElseIf dvList.Count > 0 Then
            blSkipDeal = True
            Me.dgvList("ActivationState", 0).Selected = True
            Me.dgvList.Rows(0).Selected = False
            blSkipDeal = False
            Me.dgvList.Rows(0).Selected = True
        Else
            dvCard.RowFilter = "1=2"
            Me.chbSelectAllCards.Visible = False
        End If
        dtTemp.Dispose() : dtTemp = Nothing

        Me.SummaryInfo()
    End Sub

    Private Sub SearchSalesBillDetail()
        Me.chbDisplaySelected.Checked = False
        blSkipDeal = True
        Dim iSelectedIndex As Integer = Me.cbbStore.SelectedIndex
        Me.cbbStore.SelectedIndex = -1
        blSkipDeal = False
        Me.cbbStore.SelectedIndex = iSelectedIndex

        With frmSearchSalesBillDetail
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim sOldRowFilter As String = sRowFilter
                sRowFilter = ""

                If .rdbByPayerName.Checked Then
                    sRowFilter = "PayerName Like '%" & .txbPayerName.Text.Trim.Replace("'", "''") & "%'"
                ElseIf .rdbByMediaNo.Checked Then
                    sRowFilter = "MediaNo Like '%" & .txbMediaNo.Text.Trim.Replace("'", "''") & "%'"
                Else
                    sRowFilter = "SalesBillCode='" & .txbSalesBillCode.Text.Trim.Replace("'", "''") & "'"
                End If

                If sRowFilter = sOldRowFilter Then Return

                dvList.RowFilter = sRowFilter
                Dim dtTemp As DataTable = dvList.ToTable
                With Me.dgvList
                    .Columns("PaymentDescription").Visible = (dtTemp.Select("Isnull(PaymentDescription,'')<>''").Length > 0)
                    .Columns("MediaNo").Visible = (dtTemp.Select("Isnull(MediaNo,'')<>''").Length > 0)
                    .Columns("PayerName").Visible = .Columns("MediaNo").Visible
                    .Columns("PaymentValidationState").Visible = (dtTemp.Select("Isnull(PaymentValidationState,'')<>''").Length > 0)
                    .Columns("InactivatedAMT").Visible = (dtTemp.Select("RowActivatedAMT>0 And RowActivatedAMT<RowChargedAMT").Length > 0)
                    .Columns("ActivatorName").Visible = (dtTemp.Select("Isnull(ActivatorName,'')<>''").Length > 0)
                    .Columns("ActivatedTime").Visible = .Columns("ActivatorName").Visible
                    .Columns("StateReason").Visible = (dtTemp.Select("Isnull(StateReason,'')<>''").Length > 0)
                    .Columns("PendingAMT").Visible = (dtTemp.Select("PendingAMT>0").Length > 0)
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
        If Me.dgvList.Columns("OperationResult").Visible OrElse dvList.Table.Select("Isnull(OperationResult,'')<>''").Length > 0 Then
            blSkipDeal = True
            If Me.dgvList.Columns("PendingAMT").Visible Then
                Me.dgvList("PendingAMT", Me.dgvList.CurrentRow.Index).Selected = True
            Else
                Me.dgvList("ActivationState", Me.dgvList.CurrentRow.Index).Selected = True
            End If
            blSkipDeal = False

            For Each dr As DataRow In dvList.Table.Select("PendingAMT>0")
                If dr("ResultReason").ToString.IndexOf("销售单已被") = 0 Then
                    dr.Delete() : dr.AcceptChanges()
                Else
                    dr("PendingAMT") = dr("FinalPendingAMT")
                    dr("OperationResult") = DBNull.Value
                    dr("ResultReason") = DBNull.Value
                    If dr("PendingAMT") = 0 Then dr.AcceptChanges()
                End If
            Next
            Me.dgvList.Columns("OperationResult").Visible = False
            Me.dgvList.Columns("ResultReason").Visible = False
        End If

        Me.chbDisplaySelected.Checked = True
        blSkipDeal = True
        Me.dgvList("PendingAMT", 0).Selected = True
        Me.dgvList.Rows(0).Selected = False
        blSkipDeal = False
        Me.dgvList.Rows(0).Selected = True
        For Each drList As DataRow In dvList.Table.Select("Isnull(ResultReason,'')<>''")
            drList("ResultReason") = DBNull.Value
        Next
        Me.dgvList.Columns("ResultReason").Visible = False
        Me.dgvList.FirstDisplayedScrollingColumnIndex = Me.dgvList.Columns("PendingAMT").Index
        frmMain.statusText.Text = "就绪。"

        Dim sPrompt As String = "您本次选择要激活的销售单汇总信息如下：    " & Chr(13) & Chr(13)
        Dim dtCurrent As DataTable = dvList.ToTable(True, "SalesBillID")
        Dim iSalesBillCount As Integer = dtCurrent.Rows.Count
        dtCurrent = dvList.ToTable(False, "RowPayableAMT", "FinalPendingAMT")
        Dim iCardQTY As Integer = dvCard.Table.Compute("COUNT(CardNo)", "Selected=1 And NeedActivate=1"), dmPayableAMT As Decimal = dtCurrent.Compute("Sum(RowPayableAMT)", ""), dmPendingAMT As Decimal = dtCurrent.Compute("Sum(FinalPendingAMT)", "")
        Dim bLen As Byte, blWithDot As Boolean = (dmPayableAMT <> CLng(dmPayableAMT) OrElse dmPendingAMT <> CLng(dmPendingAMT))
        bLen = Format(dmPayableAMT, IIf(blWithDot, "#,0.00", "#,0")).Length
        If bLen < Format(dmPendingAMT, IIf(blWithDot, "#,0.00", "#,0")).Length Then bLen = Format(dmPendingAMT, IIf(blWithDot, "#,0.00", "#,0")).Length
        sPrompt = sPrompt & "涉及的销售单总数： " & String.Format("{0," & bLen & ":#,0}", iSalesBillCount) & " 笔    " & Chr(13)
        sPrompt = sPrompt & "应收到的付款金额： " & String.Format("{0," & bLen & ":#,0" & IIf(blWithDot, ".00", "") & "}", dmPayableAMT) & " 元    " & Chr(13)
        sPrompt = sPrompt & "即将激活购物卡数： " & String.Format("{0," & bLen & ":#,0}", iCardQTY) & " 张    " & Chr(13)
        sPrompt = sPrompt & "即将提交激活金额： " & String.Format("{0," & bLen & ":#,0" & IIf(blWithDot, ".00", "") & "}", dmPendingAMT) & " 元    " & Chr(13) & Chr(13)
        sPrompt = sPrompt & "请注意：激活操作一旦提交，便不可撤消！    " & Chr(13) & Chr(13)
        sPrompt = sPrompt & "如果您确认上面信息正确无误，请按""确定""按钮继续。    "

        If MessageBox.Show(sPrompt, "请确认激活：", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Cancel Then Return False
        Me.Refresh()

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在提交激活记录……"

        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法提交激活记录。请检查数据库连接。"
            Me.Cursor = Cursors.Default
            Return False
        End If

        frmMain.statusRate.Visible = True
        frmMain.statusRate.Text = ""
        frmMain.statusProgress.Visible = True
        frmMain.statusProgress.Value = 0
        frmMain.statusMain.Refresh()

        Dim sSalesBillDetailID As String = "", sCardRowFilter As String = "", blOK As Boolean = True, blPartSuccessfully As Boolean = False, iSucessfully As Integer = 0, sSQL As String = "", iRows As Integer = Me.dgvList.RowCount - 1, dtCard As DataTable = Nothing, dtResult As DataTable = Nothing

        If DB.ModifyTable("Select SalesBillDetailID,CardNo,FaceValue Into #tempCard From PendingActivationList Where 1=2") = -1 Then
            frmMain.statusText.Text = "提交激活记录失败！"
            blOK = False
        Else
            Me.dgvList.Columns("OperationResult").Visible = True
            Try
                For iRow As Integer = 0 To iRows
                    If Me.dgvList("FinalPendingAMT", iRow).Value = 0 Then Continue For

                    blSkipDeal = True
                    Me.dgvList("PendingAMT", iRow).Selected = True
                    Me.dgvList.Rows(iRow).Selected = False
                    blSkipDeal = False
                    Me.dgvList.Rows(iRow).Selected = True

                    frmMain.statusText.Text = "正在提交激活记录……"
                    frmMain.statusRate.Text = "(" & (iRow + 1).ToString & "/" & (iRows + 1).ToString & ")"
                    frmMain.statusProgress.Value = Int(((iRow + 1) / (iRows + 1)) * 100)
                    frmMain.statusMain.Refresh()

                    Call LockWindowUpdate(Me.Handle)
                    sSalesBillDetailID = Me.dgvList("SalesBillDetailID", iRow).Value.ToString
                    currentRow = dvList.Table.Rows.Find(sSalesBillDetailID)
                    currentRow("OperationResult") = "正在提交……"
                    Me.dgvList.Columns("OperationResult").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    Me.dgvList.Columns("OperationResult").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Me.dgvList.FirstDisplayedScrollingColumnIndex = Me.dgvList.Columns("OperationResult").Index
                    Call LockWindowUpdate(0)
                    Me.Activate() : Me.Refresh()

                    blPartSuccessfully = False

Submit_Again:
                    Call LockWindowUpdate(Me.Handle)
                    dvCard.RowFilter = "SalesBillDetailID=" & sSalesBillDetailID & " And Selected=1 And NeedActivate=1"
                    sCardRowFilter = dvCard.RowFilter
                    dtCard = dvCard.ToTable(False, "SalesBillDetailID", "CardNo", "FaceValue")
                    dvCard.RowFilter = "1=2"
                    If DB.ModifyTable("Delete From #tempCard") = -1 OrElse DB.BulkCopyTable("#tempCard", dtCard) = -1 Then
                        currentRow("OperationResult") = "提交失败！"
                        Me.dgvList.Columns("ResultReason").Visible = True
                        If My.Computer.Network.IsAvailable Then
                            currentRow("ResultReason") = "数据库内部错误！"
                        Else
                            currentRow("ResultReason") = "连接不到数据库（网络中断）！"
                        End If
                        Me.dgvList.Columns("ResultReason").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        Me.dgvList.Columns("ResultReason").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        Me.dgvList.FirstDisplayedScrollingColumnIndex = Me.dgvList.Columns("ResultReason").Index
                        frmMain.statusText.Text = "提交操作已停止！"
                        blOK = False
                        Exit For
                    End If
                    dtCard.Rows.Clear()
                    dtCard.AcceptChanges()

                    'modify code 068:start-------------------------------------------------------------------------
                    sSQL = "Exec " & IIf(Me.dgvList("StartCardNo", iRow).Value.ToString.IndexOf("2") = 0, "ActivateCard_29509", "ActivatePaperCard") & " @SalesBillDetailID=" & sSalesBillDetailID & ",@SalesBillID=" & currentRow("SalesBillID").ToString & ",@OldRowSelectedAMT=" & currentRow("RowSelectedAMT").ToString & ",@PendingAMT=" & currentRow("FinalPendingAMT").ToString & ","
                    'modify code 068:end-------------------------------------------------------------------------

                    If currentRow("RowType") = 0 Then
                        sSQL = sSQL & "@OldPaymentTerm=" & currentRow("PaymentTerm").ToString & ","
                        If currentRow("PaymentDescription").ToString <> "" Then sSQL = sSQL & "@OldPaymentDescription='" & currentRow("PaymentDescription").ToString & "',"
                        If currentRow("MediaNo").ToString <> "" Then sSQL = sSQL & "@OldMediaNo='" & currentRow("MediaNo").ToString.Replace("'", "''") & "',"
                        If currentRow("PayerName").ToString <> "" Then sSQL = sSQL & "@OldPayerName='" & currentRow("PayerName").ToString.Replace("'", "''") & "',"
                    End If
                    sSQL = sSQL & "@OperatorName='" & frmMain.sLoginUserRealName.Replace("'", "''") & "',@SSID=" & frmMain.sSSID

                    dtResult = DB.GetDataTable(sSQL)
                    If dtResult Is Nothing Then
                        currentRow("OperationResult") = "提交失败！"
                        currentRow("ResultReason") = "数据库内部错误！"
                        Me.dgvList.Columns("ResultReason").Visible = True
                        Me.dgvList.Columns("ResultReason").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        Me.dgvList.Columns("ResultReason").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        Me.dgvList.FirstDisplayedScrollingColumnIndex = Me.dgvList.Columns("ResultReason").Index
                        blOK = False
                        Continue For
                    ElseIf dtResult.Rows(0)("Result").ToString <> "OK" Then
                        Select Case dtResult.Rows(0)("Result").ToString
                            Case "SalesBillDeleted", "SalesBillCancelled"
                                For Each drList As DataRow In dvList.Table.Select("SalesBillID=" & currentRow("SalesBillID").ToString)
                                    drList("NewSelectedAMT") = drList("SelelectedAMT")
                                    drList("OperationResult") = "提交失败！"
                                    drList("ResultReason") = "销售单已被" & IIf(dtResult.Rows(0)("Result").ToString = "SalesBillDeleted", "删除！", "取消！")
                                    drList("FinalPendingAMT") = 0
                                    drList.AcceptChanges()
                                    For Each drCard As DataRow In dvCard.Table.Select(sCardRowFilter)
                                        drCard("Selected") = 0
                                        drCard("NeedActivate") = 0
                                        drCard.AcceptChanges()
                                    Next
                                Next
                            Case "CardActivated"
                                Dim drCard As DataRow = Nothing, dmFinalPendingAMT As Decimal = 0
                                dmPendingAMT = currentRow("FinalPendingAMT")
                                dmFinalPendingAMT = dmPendingAMT
                                For Each dr As DataRow In dtResult.Rows
                                    drCard = dvCard.Table.Select("SalesBillDetailID=" & sSalesBillDetailID & " And CardNo='" & dr("CardNo").ToString & "'")(0)
                                    If drCard("Selected") AndAlso drCard("NeedActivate") Then dmFinalPendingAMT = dmFinalPendingAMT - drCard("FaceValue")
                                    drCard("Selected") = 1
                                    drCard("ActivationState") = dr("ActivationState")
                                    drCard("StateReason") = dr("StateReason")
                                    drCard("CULActivatedTime") = dr("CULActivatedTime")
                                    drCard("NeedActivate") = 0
                                    drCard.AcceptChanges()
                                Next
                                currentRow("RowSelectedAMT") = dtResult.Rows(0)("RowSelectedAMT") : currentRow("FinalPendingAMT") = dmFinalPendingAMT
                                Dim dmSalesBillPendingAMT As Decimal = dvList.Table.Compute("Sum(FinalPendingAMT)", "SalesBillID=" & currentRow("SalesBillID").ToString)
                                For Each drList As DataRow In dvList.Table.Select("SalesBillID=" & currentRow("SalesBillID").ToString)
                                    drList("SelectedAMT") = dtResult.Rows(0)("SelectedAMT")
                                    drList("NewSelectedAMT") = drList("SelectedAMT") + dmSalesBillPendingAMT
                                    If currentRow("RowType") = 0 AndAlso drList("RowType") = 2 AndAlso drList("RebateState") > 1 Then '已审核过的返点卡行
                                        If drList("NormalSalesAMT") <= currentRow("NewSelectedAMT") Then
                                            drList("ActivationState") = "等待激活"
                                            drList("StateReason") = DBNull.Value
                                        End If
                                    End If
                                    If drList("FinalPendingAMT") = 0 Then drList.AcceptChanges()
                                Next

                                currentRow("ActivatorName") = dtResult.Rows(0)("ActivatorName").ToString
                                currentRow("ActivatedTime") = dtResult.Rows(0)("ActivatedTime")
                                Me.dgvList.Columns("ActivatorName").Visible = True
                                Me.dgvList.Columns("ActivatorName").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                                Me.dgvList.Columns("ActivatorName").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                Me.dgvList.Columns("ActivatedTime").Visible = True
                                If currentRow("FinalPendingAMT") = 0 Then
                                    currentRow("OperationResult") = "提交失败！"
                                    currentRow("ResultReason") = "已由他人提交！"
                                    currentRow.AcceptChanges()
                                Else
                                    blPartSuccessfully = (dmPendingAMT > dmFinalPendingAMT)
                                    GoTo Submit_Again
                                End If
                            Case "PaymentChanged"
                                currentRow("PaymentTerm") = dtResult.Rows(0)("PaymentTerm")
                                Select Case currentRow("PaymentTerm")
                                    Case 0
                                        currentRow("PaymentTermName") = "现金"
                                    Case 1
                                        currentRow("PaymentTermName") = "银行卡"
                                    Case 2
                                        currentRow("PaymentTermName") = "转账"
                                    Case 3
                                        currentRow("PaymentTermName") = "支票"
                                    Case Else
                                        currentRow("PaymentTermName") = "（混合付款）"
                                End Select
                                currentRow("PaymentDescription") = dtResult.Rows(0)("PaymentDescription")
                                currentRow("MediaNo") = dtResult.Rows(0)("MediaNo")
                                currentRow("PayerName") = dtResult.Rows(0)("PayerName")
                                currentRow("FinalPendingAMT") = 0
                                Dim dmSalesBillPendingAMT As Decimal = dvList.Table.Compute("Sum(FinalPendingAMT)", "SalesBillID=" & currentRow("SalesBillID").ToString), blNeedReset As Boolean = False
                                For Each drList As DataRow In dvList.Table.Select("SalesBillID=" & currentRow("SalesBillID").ToString)
                                    drList("NewSelectedAMT") = drList("SelectedAMT") + dmSalesBillPendingAMT
                                    If currentRow("RowType") = 0 AndAlso drList("RowType") = 2 AndAlso drList("RebateState") > 1 AndAlso drList("PendingAMT") > 0 Then '已审核过的返点卡行
                                        If drList("NormalSalesAMT") > currentRow("NewSelectedAMT") Then
                                            drList("ActivationState") = "不可激活"
                                            drList("StateReason") = "正常卡未全部激活"
                                            For Each drCard As DataRow In dvCard.Table.Select(sCardRowFilter)
                                                drCard("Selected") = 0
                                            Next
                                            drList("FinalPendingAMT") = 0
                                            blNeedReset = True
                                        End If
                                    End If
                                    If drList("FinalPendingAMT") = 0 Then drList.AcceptChanges()
                                Next
                                If blNeedReset Then
                                    Try
                                        dmSalesBillPendingAMT = dvList.Table.Compute("Sum(FinalPendingAMT)", "SalesBillID=" & currentRow("SalesBillID").ToString)
                                    Catch
                                    End Try
                                    For Each drList As DataRow In dvList.Table.Select("SalesBillID=" & currentRow("SalesBillID").ToString)
                                        drList("NewSelectedAMT") = drList("SelectedAMT") + dmSalesBillPendingAMT
                                        If drList("FinalPendingAMT") = 0 Then drList.AcceptChanges()
                                    Next
                                End If

                                For Each drCard As DataRow In dvCard.Table.Select(sCardRowFilter)
                                    drCard("Selected") = 0
                                Next
                                currentRow("OperationResult") = "提交失败！"
                                currentRow("ResultReason") = "付款信息发生变化！"
                                currentRow.AcceptChanges()
                            Case Else
                                currentRow("OperationResult") = "提交失败！"
                                currentRow("ResultReason") = "数据库内部错误！"
                                Me.dgvList.Columns("ResultReason").Visible = True
                                Me.dgvList.Columns("ResultReason").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                                Me.dgvList.Columns("ResultReason").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                Me.dgvList.FirstDisplayedScrollingColumnIndex = Me.dgvList.Columns("ResultReason").Index
                                blOK = False
                                MessageBox.Show("提交激活记录时出现错误！下面是数据库的内部错误提示：    " & Chr(13) & Chr(13) & dtResult.Rows(0)("ErrorInfo").ToString & Space(4) & Chr(13) & Chr(13) & "请放弃提交，在关闭窗口后重试。如果仍有问题，请联系软件开发人员。    ", "提交激活记录失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                frmMain.statusText.Text = "提交激活记录失败！"
                                Exit For
                        End Select
                        Me.dgvList.Columns("ResultReason").Visible = True
                        Me.dgvList.Columns("ResultReason").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        Me.dgvList.Columns("ResultReason").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        Me.dgvList.FirstDisplayedScrollingColumnIndex = Me.dgvList.Columns("ResultReason").Index
                    Else
                        Dim dmSalesBillPendingAMT As Decimal = currentRow("NewSelectedAMT") - currentRow("SelectedAMT") - currentRow("FinalPendingAMT")
                        currentRow("RowSelectedAMT") = currentRow("RowSelectedAMT") + currentRow("FinalPendingAMT") : currentRow("FinalPendingAMT") = 0
                        For Each drList As DataRow In dvList.Table.Select("SalesBillID=" & currentRow("SalesBillID").ToString)
                            drList("SelectedAMT") = drList("SelectedAMT") + currentRow("PendingAMT")
                            If drList("SelectedAMT") = drList("ChargedAMT") Then
                                drList("CardStates") = "01" & drList("CardStates").ToString.Substring(2)
                            Else
                                drList("CardStates") = "11" & drList("CardStates").ToString.Substring(2)
                            End If
                            drList("NewSelectedAMT") = drList("SelectedAMT") + dmSalesBillPendingAMT
                            If drList("FinalPendingAMT") = 0 Then drList.AcceptChanges()
                        Next

                        For Each drCard As DataRow In dvCard.Table.Select(sCardRowFilter)
                            drCard("ActivationState") = "正在激活"
                            drCard("NeedActivate") = 0
                            drCard.AcceptChanges()
                        Next

                        If currentRow("ActivationState").ToString = "等待激活" Then currentRow("ActivationState") = "正在激活"
                        currentRow("ActivatorName") = frmMain.sLoginUserRealName
                        currentRow("ActivatedTime") = dtResult.Rows(0)("ActivatedTime")
                        Me.dgvList.Columns("ActivatorName").Visible = True
                        Me.dgvList.Columns("ActivatorName").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        Me.dgvList.Columns("ActivatorName").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        Me.dgvList.Columns("ActivatedTime").Visible = True
                        If blPartSuccessfully Then
                            currentRow("OperationResult") = "部分成功，部分失败！"
                            currentRow("ResultReason") = "部分卡激活已由他人提交！"
                            Me.dgvList.Columns("ResultReason").Visible = True
                            Me.dgvList.Columns("ResultReason").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            Me.dgvList.Columns("ResultReason").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                            Me.dgvList.FirstDisplayedScrollingColumnIndex = Me.dgvList.Columns("ResultReason").Index
                        Else
                            currentRow("OperationResult") = "提交成功。"
                        End If
                        currentRow.AcceptChanges()

                        iSucessfully += 1
                    End If

                    Call LockWindowUpdate(0)
                    Me.Activate() : Me.Refresh()
                Next

                If dtResult IsNot Nothing Then dtResult.Dispose() : dtResult = Nothing
                For iColumn As Int16 = Me.dgvList.Columns.Count - 1 To 0 Step -1
                    If Me.dgvList.Columns(iColumn).Visible = True Then
                        Me.dgvList.FirstDisplayedScrollingColumnIndex = iColumn
                        Exit For
                    End If
                Next
                If blOK Then
                    blSkipDeal = True
                    Me.dgvList.CurrentRow.Selected = False
                    Me.dgvList("OperationResult", 0).Selected = True
                    Me.dgvList.Rows(0).Selected = False
                    blSkipDeal = False
                    Me.dgvList.Rows(0).Selected = True
                    frmMain.statusText.Text = "提交激活记录完成。"
                    If iSucessfully > 0 Then MessageBox.Show("已经将您刚才所选的购物卡发送到银商CUL系统激活。    " & Chr(13) & Chr(13) & "您可在大约 5 分钟后刷新窗口查看激活结果。    ", "提交激活记录完成。", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf sCardRowFilter <> "" Then
                    dvCard.RowFilter = sCardRowFilter
                End If
            Catch
                dvCard.RowFilter = sCardRowFilter
                currentRow("OperationResult") = "提交失败！"
                currentRow("ResultReason") = "数据库内部错误！"
                Me.dgvList.Columns("ResultReason").Visible = True
                Me.dgvList.Columns("ResultReason").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                Me.dgvList.Columns("ResultReason").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dgvList.FirstDisplayedScrollingColumnIndex = Me.dgvList.Columns("ResultReason").Index
                blOK = False
                frmMain.statusText.Text = "提交激活记录失败！"
            Finally
                If dtCard IsNot Nothing Then dtCard.Dispose() : dtCard = Nothing
            End Try
        End If

        DB.Close()

        frmMain.statusRate.Text = ""
        frmMain.statusRate.Visible = False
        frmMain.statusProgress.Value = 0
        frmMain.statusProgress.Visible = False

        Me.Cursor = Cursors.Default
        Me.btnActivate.Enabled = Not blOK
        Me.chbDisplaySelected.Checked = False
        Return blOK
    End Function
End Class
