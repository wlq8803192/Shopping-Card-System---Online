Public Class frmSalesBillManagement

    'modify code 038:
    'date;2014/9/24
    'auther:Hyron bjy 
    'remark:返点比率0.0->0.00

    'modify code 046:
    'date;2015/4/1
    'auther:Hyron zyx 
    'remark:新增销售单类型---实名制卡销售单

    'modify code 054:
    'date;2016/02/15
    'auther:BJY 
    'remark:增加65卡销售单，65/61使用新返点规则，去除051的一般销售单售卖65卡功能

    'modify code 057:
    'date;2016/05/13
    'auther:BJY 
    'remark:修正总部售卡员无法看到对账报表问题

    Private dtLoaded As DataTable, blSkipDeal As Boolean = True, blCanDelete As Boolean = True, blCanAdjust As Boolean = True, blCanValidate As Boolean = True, sRowFilter As String
    Public dvSalesBill As DataView

    Private Sub frmSalesBillManagement_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If frmMain.statusText.Text.IndexOf("无法") = -1 Then frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub frmSalesBillManagement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        blCanDelete = (frmMain.dtAllowedRight.Select("RightName='SalesBillDelete'").Length > 0)
        blCanAdjust = (frmMain.dtAllowedRight.Select("RightName='SalesBillSalesmanAdjust'").Length > 0)
        blCanValidate = (frmMain.dtAllowedRight.Select("RightName='SalesBillRebateValidate'").Length > 0)

        Dim DB As New DataBase()
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打开""销售单管理""窗口。请检查数据库连接。"
            Me.Close() : Return
        End If

        Dim sStoreID As String = frmMain.dtLoginStructure.Select("AreaType='S'")(0)("AreaID").ToString, sSalesDate As String = ""
        If "|34|272|".IndexOf(frmMain.dtLoginStructure.Rows.Find(sStoreID)("ParentAreaID").ToString) > -1 Then '大连联名卡
            'modify code 040:start-------------------------------------------------------------------------
            'Me.cbbSalesBillType.Items.Add("6. 联名卡销售单 Co-brand Card Bill")
            Me.cbbSalesBillType.Items.Add("8. 联名卡销售单 Co-brand Card Bill")
            'modify code 040:end-------------------------------------------------------------------------
        End If
        Try
            sSalesDate = Format(DB.GetDataTable("Select GETDATE()").Rows(0)(0), "yyyy\/MM\/dd")

            'modify code 057:start-------------------------------------------------------------------------
            'If frmMain.sLoginRoleID = "14" Then '售卡员
            If frmMain.sLoginRoleID = "14" OrElse frmMain.sLoginRoleID = "28" Then '售卡员/总部售卡员
                'modify code 057:end-------------------------------------------------------------------------
                dvSalesBill = DB.GetDataTable("Exec GetSalesBillList @LoginUserID=" & frmMain.sLoginUserID & ",@SalesDate='" & sSalesDate & "'").DefaultView
                dvSalesBill.Table.PrimaryKey = New DataColumn() {dvSalesBill.Table.Columns("SalesBillID")}
                dvSalesBill.RowFilter = "SalesBillState<>'等待取消' And SalesBillState<>'已撤销激活'"
                Me.btnCheckAccount.Visible = True
                Me.btnCheckAccount.Enabled = (dvSalesBill.Count > 0)
                dvSalesBill.RowFilter = ""
            Else
                dvSalesBill = DB.GetDataTable("Exec GetSalesBillList @LoginUserID=" & frmMain.sLoginUserID).DefaultView
                dvSalesBill.Table.PrimaryKey = New DataColumn() {dvSalesBill.Table.Columns("SalesBillID")}
                dvSalesBill.Table.Merge(DB.GetDataTable("Exec GetSalesBillList @LoginUserID=" & frmMain.sLoginUserID & ",@StoreID=" & sStoreID & ",@SalesDate='" & sSalesDate & "'"))
                Me.lblTitle.Visible = False
                Me.pnlOnlyInvalid.Visible = True
                If frmMain.sLoginRoleID = "12" Then 'AndAlso frmMain.dtLoginStructure.Rows.Find(frmMain.sLoginAreaID)("ParentAreaID").ToString = "20" Then '北京的门店购物卡主管
                    dvSalesBill.RowFilter = "SalesBillState<>'等待取消' And SalesBillState<>'已撤销激活'"
                    Me.btnCheckAccount.Text = "购物卡盘点报表"
                    Me.btnCheckAccount.Visible = True
                    Me.btnCheckAccount.Enabled = (dvSalesBill.Count > 0)
                End If
                dvSalesBill.RowFilter = "(RebateState='等待审核' Or RebateState='审核失败') And SalesBillState<>'等待取消' And SalesBillState<>'已撤销激活'"
                If dvSalesBill.Count > 0 Then
                    Me.chbOnlyInvalid.Checked = True
                    Me.pnlConditions.Enabled = False
                    Me.btnCheckAccount.Enabled = False
                Else
                    dvSalesBill.RowFilter = ""
                End If
            End If

            If frmMain.dtAllowedRight.Select("RightName='SalesBillSalesmanAdjust'").Length > 0 AndAlso frmMain.dvMediumFish Is Nothing Then
                Dim sCityID As String = ""
                If frmMain.sLoginAreaType = "S" Then
                    frmMain.dvMediumFish = DB.GetDataTable("Select AreaID,UserID As SalesmanID,UserCode,Isnull(UserChineseName,UserEnglishName) As SalesmanName From UserList Where AreaID=" & sStoreID & " And RoleID=19 And UserState=2").DefaultView
                Else
                    frmMain.dvMediumFish = DB.GetDataTable("Select U.AreaID,U.UserID As SalesmanID,U.UserCode,Isnull(U.UserChineseName,U.UserEnglishName) As SalesmanName From UserList AS U Join AreaScope(" & frmMain.sLoginUserID & ") As S On U.AreaID=S.AreaID Where U.RoleID=19 And U.UserState=2").DefaultView
                End If
                frmMain.dvMediumFish.Sort = "UserCode"
                If frmMain.sLoginAreaType = "S" Then
                    sCityID = frmMain.dtLoginStructure.Rows.Find(sStoreID)("ParentAreaID").ToString
                ElseIf frmMain.sLoginAreaType = "C" Then
                    sCityID = frmMain.sLoginAreaID
                End If
                If sCityID <> "" Then
                    frmMain.dvBigFish = DB.GetDataTable("Select AreaID,UserID As SalesmanID ,UserCode,Isnull(UserChineseName,UserEnglishName) As SalesmanName From UserList Where AreaID=" & sCityID & " And RoleID=10 And UserState=2").DefaultView
                Else
                    frmMain.dvBigFish = DB.GetDataTable("Select U.AreaID,U.UserID As SalesmanID,U.UserCode,Isnull(U.UserChineseName,U.UserEnglishName) As SalesmanName From UserList AS U Join AreaScope(" & frmMain.sLoginUserID & ") As S On U.AreaID=S.AreaID Where U.RoleID=10 And U.UserState=2").DefaultView
                End If
                frmMain.dvBigFish.Sort = "UserCode"
            End If
        Catch
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开""销售单管理""窗口。请联系软件开发人员。"
            DB.Close() : Me.Close() : Return
        End Try
        DB.Close()

        dtLoaded = New DataTable
        dtLoaded.Columns.Add("StoreID", System.Type.GetType("System.Int16"))
        dtLoaded.Columns.Add("SalesDate", System.Type.GetType("System.DateTime"))
        dtLoaded.Columns.Add("LoadedTime", System.Type.GetType("System.DateTime"))
        dtLoaded.Columns.Add("IsRefreshed", System.Type.GetType("System.Boolean"))
        dtLoaded.Rows.Add(sStoreID, sSalesDate, Now(), 0)
        dtLoaded.AcceptChanges()

        Me.dtpSalesDate.Value = sSalesDate
        Me.dtpSalesDate.MaxDate = sSalesDate
        Me.cbbSalesBillType.SelectedIndex = 0
        Me.cbbSalesBillState.SelectedIndex = 0

        sRowFilter = "StoreID=" & sStoreID & " And SalesDate='" & sSalesDate & "'"
        dvSalesBill.Sort = "SalesBillCode"
        With Me.dgvList
            .DataSource = dvSalesBill
            .Columns(0).Visible = False
            With .Columns(1)
                .HeaderText = "销售单号" & Chr(13) & "Bill Code"
                .Width = 85
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(2)
                .HeaderText = "销售日期" & Chr(13) & "Sales Date"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Format = "yyyy\/MM\/dd"
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(3)
                .HeaderText = "销售单类型" & Chr(13) & "Bill Type"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(4)
                .HeaderText = "客户名称" & Chr(13) & "Customer Name"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .MinimumWidth = .Width
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(5)
                .HeaderText = "所属门店" & Chr(13) & "Store Name"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(6)
                .HeaderText = "业务员" & Chr(13) & "Salesman"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(7)
                .HeaderText = "购物卡数量" & Chr(13) & "Card QTY"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Format = "#,0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(8)
                .HeaderText = "充值金额" & Chr(13) & "Charged AMT"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(9)
                .HeaderText = "应付金额" & Chr(13) & "Payable AMT"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(10)
                .HeaderText = "是否返点" & Chr(13) & "With Discount?"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(11)
                .HeaderText = "返点 %" & Chr(13) & "Discount %"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                'modify code 038:start-------------------------------------------------------------------------
                '.DefaultCellStyle.Format = "#,0.0 %"
                .DefaultCellStyle.Format = "#,0.00 %"
                'modify code 038:end-------------------------------------------------------------------------
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(12)
                .HeaderText = "返点金额" & Chr(13) & "Discount AMT"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(13)
                .HeaderText = "返点状态" & Chr(13) & "Discount State"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(14)
                .HeaderText = "销售单状态" & Chr(13) & "Bill State"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(15)
                .HeaderText = "建单" & Chr(13) & "Creator"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(16)
                .HeaderText = "建单时间" & Chr(13) & "Created Time"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Format = "HH:mm:ss"
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            .Columns(17).Visible = False
            .Columns(18).Visible = False
            .Columns(19).Visible = False
            .Columns(20).Visible = False
            .Columns(21).Visible = False
            .Columns(22).Visible = False
            .Columns(23).Visible = False
            .Columns(24).Visible = False
            .Columns(25).Visible = False
        End With
        For bColumn As Byte = 0 To dvSalesBill.Table.Columns.Count - 1
            Me.dgvList.Columns(bColumn).Name = dvSalesBill.Table.Columns(bColumn).ColumnName
        Next

        Me.InitArea(Me.trvArea.Nodes, frmMain.dtLoginStructure.Rows(0)("ParentAreaID").ToString)
        Me.trvArea.ExpandAll()
        Me.trvArea.SelectedNode = Nothing
        Dim firstStore As TreeNode = Me.trvArea.Nodes.Find(sStoreID, True)(0)
        Me.trvArea.SelectedNode = Me.trvArea.Nodes.Find(sStoreID, True)(0)
        Me.trvArea.SelectedNode.EnsureVisible()
        Me.btnAdd.Enabled = (frmMain.dtAllowedRight.Select("RightName='SalesBillNormalCreate'").Length > 0)
        blSkipDeal = False
        If frmMain.sLoginAreaType = "S" OrElse Me.chbOnlyInvalid.Checked Then
            Me.Split.Panel1.Controls.Remove(Me.btnSearch)
            Me.Split.Panel2.Controls.Add(Me.btnSearch)
            Me.btnSearch.Location = New Point(Me.btnOpen.Location)
            Me.btnOpen.Location = New Point(Me.btnOpen.Left + Me.btnSearch.Width + 30, Me.btnOpen.Top)
            Me.btnAdd.Location = New Point(Me.btnAdd.Left + Me.btnSearch.Width + 30, Me.btnAdd.Top)
            Me.btnDelete.Location = New Point(Me.btnDelete.Left + Me.btnSearch.Width + 30, Me.btnDelete.Top)
            Me.btnAdjustSalesman.Location = New Point(Me.btnAdjustSalesman.Left + Me.btnSearch.Width + 30, Me.btnAdjustSalesman.Top)
            Me.btnValidateDiscount.Location = New Point(Me.btnValidateDiscount.Left + Me.btnSearch.Width + 30, Me.btnValidateDiscount.Top)
            Me.Split.Panel1Collapsed = True
        End If
        Me.SummaryInfo()
    End Sub

    Private Sub InitArea(ByVal tncCurrent As TreeNodeCollection, ByVal sParentID As String)
        Try
            Dim newNode As TreeNode
            Dim drRows() As DataRow = frmMain.dtLoginStructure.Select("ParentAreaID=" & sParentID, "SortCode")

            For Each dr As DataRow In drRows
                newNode = New TreeNode
                newNode.Name = dr("AreaID").ToString
                newNode.Text = dr("AreaFullName").ToString
                newNode.ImageKey = dr("AreaType").ToString
                newNode.SelectedImageKey = dr("AreaType").ToString
                tncCurrent.Add(newNode)
                sParentID = dr("AreaID").ToString
                Me.InitArea(tncCurrent(tncCurrent.Count - 1).Nodes, sParentID)
            Next
        Catch
            MessageBox.Show("初始化分类结构树时失败！", "初始化分类结构树时失败！")
        End Try
    End Sub

    Private Sub Split_SplitterMoved(ByVal sender As Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles Split.SplitterMoved
        Me.trvArea.Select()
    End Sub

    Private Sub trvArea_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvArea.AfterSelect
        If blSkipDeal Then Return
        If Me.trvArea.SelectedNode.ImageKey <> "S" Then
            Try
                Me.trvArea.SelectedNode = Me.trvArea.SelectedNode.Nodes(0)
            Catch
            End Try
            Return
        End If
        If Me.trvArea.SelectedNode.ImageKey <> "S" Then Return

        Dim sStoreID As String = Me.trvArea.SelectedNode.Name, sSalesDate As String = Format(Me.dtpSalesDate.Value, "yyyy\/MM\/dd")
        If "|34|272|".IndexOf(frmMain.dtLoginStructure.Rows.Find(sStoreID)("ParentAreaID").ToString) > -1 Then '大连联名卡
            If Me.cbbSalesBillType.Items.IndexOf("6. 联名卡销售单 Co-brand Card Bill") = -1 Then Me.cbbSalesBillType.Items.Add("6. 联名卡销售单 Co-brand Card Bill")
        ElseIf Me.cbbSalesBillType.Items.IndexOf("6. 联名卡销售单 Co-brand Card Bill") > -1 Then
            blSkipDeal = True
            Me.cbbSalesBillType.Items.Remove("6. 联名卡销售单 Co-brand Card Bill")
            Me.cbbSalesBillType.SelectedIndex = 0
            Me.lblSalesBillType.Text = "（所有类型 All Types）"
            blSkipDeal = False
        End If
        If dtLoaded.Select("StoreID=" & sStoreID & " And SalesDate='" & sSalesDate & "'").Length = 0 Then
            Me.Cursor = Cursors.WaitCursor
            frmMain.statusText.Text = "正在检索销售单……"
            frmMain.statusMain.Refresh()
            Dim DB As New DataBase, dtList As DataTable
            DB.Open()
            If Not DB.IsConnected Then
                frmMain.statusText.Text = "系统因连接不到数据库而无法检索销售单。请检查数据库连接。"
            Else
                dtList = DB.GetDataTable("Exec GetSalesBillList @LoginUserID=" & frmMain.sLoginUserID & ",@StoreID=" & sStoreID & ",@SalesDate='" & sSalesDate & "'")
                If dtList Is Nothing Then
                    frmMain.statusText.Text = "系统因在检索数据时出错而无法找到销售单。请联系软件开发人员。"
                Else
                    dvSalesBill.Table.Merge(dtList.Copy)
                    dtLoaded.Rows.Add(sStoreID, sSalesDate, Now(), 0) : dtLoaded.AcceptChanges()
                    dtList.Dispose() : dtList = Nothing : DB.Close()
                End If
            End If
            Me.Cursor = Cursors.Default
        End If

        Me.dgvList.Columns(0).Visible = False
        Me.SetRowFilter()
        If dvSalesBill.Count = 0 Then
            Me.cbbSalesBillType.SelectedIndex = 0
            Me.cbbSalesBillState.SelectedIndex = 0
            If dvSalesBill.Count > 0 Then
                With Me.dgvList.Columns("CustomerName")
                    .MinimumWidth = 2
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .MinimumWidth = .Width
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End With
                If Me.dgvList.CurrentRow Is Nothing AndAlso Me.dgvList.RowCount > 0 Then Me.dgvList(1, 0).Selected = True : Me.dgvList.Rows(0).Selected = True
            End If
        End If

        If Me.dgvList.CurrentRow IsNot Nothing Then
            blSkipDeal = True
            Me.dgvList.CurrentRow.Selected = False
            blSkipDeal = False
            Me.dgvList.CurrentRow.Selected = True
        End If
        Me.SummaryInfo()
    End Sub

    Private Sub trvArea_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles trvArea.Enter
        If Me.trvArea.SelectedNode IsNot Nothing Then
            Me.trvArea.SelectedNode.BackColor = SystemColors.Window
            Me.trvArea.SelectedNode.ForeColor = SystemColors.ControlText
        End If
    End Sub

    Private Sub trvArea_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles trvArea.Leave
        If Me.trvArea.SelectedNode IsNot Nothing Then
            Me.trvArea.SelectedNode.BackColor = SystemColors.Highlight
            Me.trvArea.SelectedNode.ForeColor = SystemColors.HighlightText
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim sSalesBillID As String = ""
        If frmSearchSalesBill.ShowDialog = Windows.Forms.DialogResult.OK Then
            sSalesBillID = frmSearchSalesBill.dgvList("SalesBillID", frmSearchSalesBill.dgvList.CurrentRow.Index).Value.ToString
        End If
        frmSearchSalesBill.Dispose()

        If sSalesBillID <> "" Then
            If frmSelling.IsHandleCreated Then
                frmSelling.Activate()
                frmSelling.WindowState = FormWindowState.Maximized
                If frmSelling.sSalesBillID <> sSalesBillID Then
                    If frmSelling.blIsChanged Then
                        Dim bAnswer As DialogResult = MessageBox.Show("是否在打开销售单之前，先保存当前销售单？    ", "当前销售单未保存！", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                        If bAnswer = Windows.Forms.DialogResult.Cancel OrElse (bAnswer = Windows.Forms.DialogResult.Yes AndAlso Not frmSelling.SaveChanges()) Then
                            Me.Activate()
                            frmMain.statusText.Text = "因为存在未保存销售单，所以不能打开销售单。"
                            Return
                        End If
                    End If
                    frmSelling.sSalesBillID = sSalesBillID
                    frmSelling.LoadSalesBill()
                End If
            Else
                Me.Cursor = Cursors.WaitCursor
                frmMain.statusText.Text = "正在打开销售单……"
                frmMain.statusMain.Refresh()

                frmSelling.Text = "查看销售单"
                frmSelling.sSalesBillID = sSalesBillID
                frmSelling.Show()
                If frmSelling.IsHandleCreated Then
                    frmSelling.MdiParent = frmMain
                    frmSelling.WindowState = FormWindowState.Maximized
                    frmSelling.Activate()
                End If

                If frmMain.statusText.Text.IndexOf("……") > -1 Then frmMain.statusText.Text = "就绪。"
                Me.Cursor = Cursors.Default
            End If

            If frmSelling.IsHandleCreated Then
                If frmSelling.dgvNormalCard.CurrentRow IsNot Nothing Then frmSelling.dgvNormalCard.CurrentRow.Selected = False
                If frmSelling.dgvRebateCard.CurrentRow IsNot Nothing Then frmSelling.dgvRebateCard.CurrentRow.Selected = False
                If frmSelling.dgvPayment.CurrentRow IsNot Nothing Then frmSelling.dgvPayment.CurrentRow.Selected = False
            End If
        End If
    End Sub

    Private Sub chbOnlyInvalid_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbOnlyInvalid.CheckedChanged
        Me.btnRefresh.Enabled = Not Me.chbOnlyInvalid.Checked
        If blSkipDeal Then Return

        Me.pnlConditions.Enabled = Not Me.chbOnlyInvalid.Checked
        If Me.chbOnlyInvalid.Checked Then
            dvSalesBill.RowFilter = "(RebateState='等待审核' Or RebateState='审核失败') And SalesBillState<>'等待取消' And SalesBillState<>'已撤销激活'"
            Me.btnCheckAccount.Enabled = False
        Else
            dvSalesBill.RowFilter = sRowFilter
            Me.btnCheckAccount.Enabled = (dvSalesBill.ToTable.Select("SalesBillState<>'等待取消' And SalesBillState<>'已撤销激活'").Length > 0)
        End If
        With Me.dgvList.Columns("CustomerName")
            .MinimumWidth = 2
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .MinimumWidth = .Width
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        blSkipDeal = True
        If frmMain.sLoginAreaType <> "S" Then
            If Me.chbOnlyInvalid.Checked Then
                Me.Split.Panel1Collapsed = True
                Me.Split.Panel1.Controls.Remove(Me.btnSearch)
                Me.Split.Panel2.Controls.Add(Me.btnSearch)
                Me.btnSearch.Location = New Point(Me.btnOpen.Location)
                Me.btnOpen.Location = New Point(Me.btnOpen.Left + Me.btnSearch.Width + 30, Me.btnOpen.Top)
                Me.btnAdd.Location = New Point(Me.btnAdd.Left + Me.btnSearch.Width + 30, Me.btnAdd.Top)
                Me.btnDelete.Location = New Point(Me.btnDelete.Left + Me.btnSearch.Width + 30, Me.btnDelete.Top)
                Me.btnAdjustSalesman.Location = New Point(Me.btnAdjustSalesman.Left + Me.btnSearch.Width + 30, Me.btnAdjustSalesman.Top)
                Me.btnValidateDiscount.Location = New Point(Me.btnValidateDiscount.Left + Me.btnSearch.Width + 30, Me.btnValidateDiscount.Top)
            Else
                Me.Split.Panel1Collapsed = False
                Me.Split.Panel2.Controls.Remove(Me.btnSearch)
                Me.Split.Panel1.Controls.Add(Me.btnSearch)
                Me.btnSearch.Location = New Point(12, Me.btnOpen.Top)
                Me.btnOpen.Location = New Point(Me.btnOpen.Left - Me.btnSearch.Width - 30, Me.btnOpen.Top)
                Me.btnAdd.Location = New Point(Me.btnAdd.Left - Me.btnSearch.Width - 30, Me.btnAdd.Top)
                Me.btnDelete.Location = New Point(Me.btnDelete.Left - Me.btnSearch.Width - 30, Me.btnDelete.Top)
                Me.btnAdjustSalesman.Location = New Point(Me.btnAdjustSalesman.Left - Me.btnSearch.Width - 30, Me.btnAdjustSalesman.Top)
                Me.btnValidateDiscount.Location = New Point(Me.btnValidateDiscount.Left - Me.btnSearch.Width - 30, Me.btnValidateDiscount.Top)
            End If
        End If
        blSkipDeal = False
        Me.btnSearch.Top = Me.btnOpen.Top
        Me.SummaryInfo()
    End Sub

    Private Sub lblOnly1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblOnly1.Click, lblOnly2.Click
        Me.chbOnlyInvalid.Checked = Not Me.chbOnlyInvalid.Checked
    End Sub

    Private Sub dtpSalesDate_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpSalesDate.CloseUp
        Me.btnOpen.Enabled = False : Me.btnDelete.Enabled = False : Me.btnAdjustSalesman.Enabled = False : Me.btnValidateDiscount.Enabled = False

        Dim sStoreID As String = Me.trvArea.SelectedNode.Name, sSalesDate As String = Format(Me.dtpSalesDate.Value, "yyyy\/MM\/dd")
        If dtLoaded.Select("StoreID=" & sStoreID & " And SalesDate='" & sSalesDate & "'").Length = 0 Then
            Me.Cursor = Cursors.WaitCursor
            frmMain.statusText.Text = "正在检索销售单……"
            frmMain.statusMain.Refresh()
            Dim DB As New DataBase, dtList As DataTable
            DB.Open()
            If Not DB.IsConnected Then
                frmMain.statusText.Text = "系统因连接不到数据库而无法检索销售单。请检查数据库连接。"
            Else
                dtList = DB.GetDataTable("Exec GetSalesBillList @LoginUserID=" & frmMain.sLoginUserID & ",@StoreID=" & sStoreID & ",@SalesDate='" & sSalesDate & "'")
                If dtList Is Nothing Then
                    frmMain.statusText.Text = "系统因在检索数据时出错而无法找到销售单。请联系软件开发人员。"
                Else
                    dvSalesBill.Table.Merge(dtList.Copy)
                    dtLoaded.Rows.Add(sStoreID, sSalesDate, Now(), 0) : dtLoaded.AcceptChanges()
                    dtList.Dispose() : dtList = Nothing : DB.Close()
                End If
            End If
            Me.Cursor = Cursors.Default
        End If

        Me.SetRowFilter()
        If dvSalesBill.Count = 0 Then
            Me.cbbSalesBillType.SelectedIndex = 0
            Me.cbbSalesBillState.SelectedIndex = 0
            If dvSalesBill.Count > 0 Then
                With Me.dgvList.Columns("CustomerName")
                    .MinimumWidth = 2
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .MinimumWidth = .Width
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End With
                If Me.dgvList.CurrentRow Is Nothing AndAlso Me.dgvList.RowCount > 0 Then Me.dgvList(1, 0).Selected = True : Me.dgvList.Rows(0).Selected = True
                Me.SummaryInfo()
            End If
        End If
    End Sub

    Private Sub dtpSalesDate_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpSalesDate.Enter
        If Me.dtpSalesDate.MaxDate < Today Then Me.dtpSalesDate.MaxDate = Today
    End Sub

    Private Sub cbbSalesBillType_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbSalesBillType.DropDown
        Me.lblSalesBillType.BackColor = SystemColors.Window
        Me.lblSalesBillType.ForeColor = SystemColors.ControlText
    End Sub

    Private Sub cbbSalesBillType_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbSalesBillType.DropDownClosed
        Me.lblSalesBillType.BackColor = SystemColors.Highlight
        Me.lblSalesBillType.ForeColor = SystemColors.HighlightText
    End Sub

    Private Sub cbbSalesBillType_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbSalesBillType.Enter
        If Me.cbbSalesBillType.DroppedDown = False Then
            Me.lblSalesBillType.BackColor = SystemColors.Highlight
            Me.lblSalesBillType.ForeColor = SystemColors.HighlightText
        Else
            Me.lblSalesBillType.BackColor = SystemColors.Window
            Me.lblSalesBillType.ForeColor = SystemColors.ControlText
        End If
    End Sub

    Private Sub cbbSalesBillType_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbSalesBillType.Leave
        Me.lblSalesBillType.BackColor = SystemColors.Window
        Me.lblSalesBillType.ForeColor = SystemColors.ControlText
    End Sub

    Private Sub cbbSalesBillType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbSalesBillType.SelectedIndexChanged
        If blSkipDeal Then Return

        Select Case Me.cbbSalesBillType.SelectedIndex
            Case 0
                Me.lblSalesBillType.Text = "（所有类型 All Types）"
            Case 1
                Me.lblSalesBillType.Text = "一般销售单 Normal Sales Bill"
            Case 2
                Me.lblSalesBillType.Text = "没有返点的销售单 No Discount"
            Case 3
                Me.lblSalesBillType.Text = "城市返点的销售单 With Normal Discount"
            Case 4
                Me.lblSalesBillType.Text = "不用审核的城市返点 Don't Need Validate"
            Case 5
                Me.lblSalesBillType.Text = "需要审核的城市返点 Need Validate"
            Case 6
                Me.lblSalesBillType.Text = "等待审核的城市返点 Waiting to Validate"
            Case 7
                Me.lblSalesBillType.Text = "城市返点审核失败 Validated Failure"
            Case 8
                Me.lblSalesBillType.Text = "城市返点审核成功 Validated Sucessfully"
            Case 9
                Me.lblSalesBillType.Text = "合同返点的销售单 Contract Discount"
            Case 10
                Me.lblSalesBillType.Text = "合同结余返点的销售单 Contract Balance"
            Case 11
                Me.lblSalesBillType.Text = "退货销售单 Returned Sales Bill"
            Case 12
                Me.lblSalesBillType.Text = "活动卡销售单 Marketing Promotion"
            Case 13
                Me.lblSalesBillType.Text = "公关卡销售单 PR Card"
            Case 14
                Me.lblSalesBillType.Text = "员工销售单 Employee Bill"
                'modify code 040:start-------------------------------------------------------------------------
                'Case 15
                '    Me.lblSalesBillType.Text = "联名卡销售单 Co-brand Card Bill"
            Case 15
                Me.lblSalesBillType.Text = "线下提卡销售单 Internet Selling"
                'modify code 046:start-------------------------------------------------------------------------
                '添加实名制
            Case 16
                Me.lblSalesBillType.Text = "实名制卡销售单 SignCard Sales Bill"
                'modify code 054:start-------------------------------------------------------------------------
            Case 17
                Me.lblSalesBillType.Text = "通卖非实名卡销售单 CrossSelling Non RealName Card"
                'Case 16
                'Case 17
            Case 18
                Me.lblSalesBillType.Text = "联名卡销售单 Co-brand Card Bill"
                'modify code 040,046,054:end-------------------------------------------------------------------------
        End Select

        Me.SetRowFilter()
    End Sub

    Private Sub lblSalesBillType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSalesBillType.Click
        Me.cbbSalesBillType.Select()
        Me.cbbSalesBillType.DroppedDown = True
    End Sub

    Private Sub lblSalesBillType_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblSalesBillType.EnabledChanged
        Me.lblSalesBillType.BackColor = IIf(Me.lblSalesBillType.Enabled, SystemColors.Window, SystemColors.Control)
    End Sub

    Private Sub cbbSalesBillState_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbSalesBillState.SelectedIndexChanged
        If blSkipDeal Then Return
        Me.SetRowFilter()
    End Sub

    Private Sub dgvList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvList.CellDoubleClick
        If e.RowIndex > -1 Then Me.btnOpen.PerformClick()
    End Sub

    Private Sub dgvList_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvList.CellFormatting
        If Me.dgvList("SalesBillState", e.RowIndex).Value.ToString = "等待取消" Then
            e.CellStyle.BackColor = Color.WhiteSmoke
            e.CellStyle.SelectionBackColor = SystemColors.GradientInactiveCaption
            e.CellStyle.ForeColor = Color.Orange
            e.CellStyle.SelectionForeColor = Color.Yellow
        Else
            If Me.dgvList.Columns(e.ColumnIndex).Name = "RebateState" Then
                Select Case e.Value.ToString
                    Case "等待审核"
                        e.CellStyle.ForeColor = Color.Green
                        e.CellStyle.SelectionForeColor = Color.LightGreen
                    Case "审核失败"
                        e.CellStyle.ForeColor = Color.Red
                        e.CellStyle.SelectionForeColor = Color.Red
                End Select
            ElseIf Me.dgvList.Columns(e.ColumnIndex).Name = "SalesBillState" Then
                Select Case e.Value.ToString
                    Case "等待激活"
                        e.CellStyle.ForeColor = Color.Green
                        e.CellStyle.SelectionForeColor = Color.LightGreen
                    Case "正在激活"
                        e.CellStyle.ForeColor = Color.SteelBlue
                        e.CellStyle.SelectionForeColor = Color.LightBlue
                    Case "部分激活"
                        e.CellStyle.ForeColor = Color.Chocolate
                        e.CellStyle.SelectionForeColor = Color.PeachPuff
                    Case "激活失败", "已撤销激活", "已被取消"
                        e.CellStyle.ForeColor = Color.Red
                        e.CellStyle.SelectionForeColor = Color.Red
                End Select
            End If
        End If
    End Sub

    Private Sub dgvList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvList.SelectionChanged
        If Me.dgvList.CurrentRow Is Nothing Then Return
        Me.btnOpen.Enabled = True
        Me.btnDelete.Enabled = (blCanDelete AndAlso Me.dgvList("SalesBillState", Me.dgvList.CurrentRow.Index).Value.ToString = "等待取消")
        Me.btnAdjustSalesman.Enabled = (blCanAdjust AndAlso Me.dgvList("SalesBillState", Me.dgvList.CurrentRow.Index).Value.ToString <> "等待取消" AndAlso Me.dgvList("SalesBillState", Me.dgvList.CurrentRow.Index).Value.ToString <> "已撤销激活" AndAlso Me.dgvList("SalesBillType", Me.dgvList.CurrentRow.Index).Value.ToString = "一般销售单" AndAlso (Me.dgvList("PayableAMT", Me.dgvList.CurrentRow.Index).Value > 0) AndAlso (frmMain.sLoginRoleID <> "14" OrElse Not Me.dgvList("SalesmanChanged", Me.dgvList.CurrentRow.Index).Value))
        Me.btnValidateDiscount.Enabled = (blCanValidate AndAlso Me.dgvList("SalesBillState", Me.dgvList.CurrentRow.Index).Value.ToString <> "等待取消" AndAlso Me.dgvList("SalesBillState", Me.dgvList.CurrentRow.Index).Value.ToString <> "已撤销激活" AndAlso (Me.dgvList("RebateState", Me.dgvList.CurrentRow.Index).Value.ToString = "等待审核" OrElse Me.dgvList("RebateState", Me.dgvList.CurrentRow.Index).Value.ToString = "审核失败"))
        If frmMain.statusText.Text.IndexOf("销售单") = -1 Then frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        If frmSelling.IsHandleCreated Then
            frmSelling.Activate()
            frmSelling.WindowState = FormWindowState.Maximized
            If frmSelling.sSalesBillID <> Me.dgvList("SalesBillID", Me.dgvList.CurrentRow.Index).Value.ToString Then
                If frmSelling.blIsChanged Then
                    Dim bAnswer As DialogResult = MessageBox.Show("是否在打开销售单之前，先保存当前销售单？    ", "当前销售单未保存！", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                    If bAnswer = Windows.Forms.DialogResult.Cancel OrElse (bAnswer = Windows.Forms.DialogResult.Yes AndAlso Not frmSelling.SaveChanges()) Then
                        Me.Activate()
                        frmMain.statusText.Text = "因为存在未保存销售单，所以不能打开销售单。"
                        Return
                    End If
                End If
                frmSelling.sSalesBillID = Me.dgvList("SalesBillID", Me.dgvList.CurrentRow.Index).Value.ToString
                'modify code 044:start-------------------------------------------------------------------------
                If "线下提卡销售单" = Me.dgvList("SalesBillType", Me.dgvList.CurrentRow.Index).Value.ToString Then
                    frmSelling.bNewSalesBillType = 6
                End If
                'modify code 044:end-------------------------------------------------------------------------
                'modify code 046:start-------------------------------------------------------------------------
                If "实名制卡销售单" = Me.dgvList("SalesBillType", Me.dgvList.CurrentRow.Index).Value.ToString Then
                    frmSelling.bNewSalesBillType = 7
                End If
                'modify code 046:end-------------------------------------------------------------------------
                'modify code 054:start-------------------------------------------------------------------------
                If "通卖非实名卡销售单" = Me.dgvList("SalesBillType", Me.dgvList.CurrentRow.Index).Value.ToString Then
                    frmSelling.bNewSalesBillType = 8
                End If
                'modify code 054:end-------------------------------------------------------------------------
                frmSelling.LoadSalesBill()
            End If
        Else
            Me.Cursor = Cursors.WaitCursor
            frmMain.statusText.Text = "正在打开销售单……"
            frmMain.statusMain.Refresh()

            frmSelling.Text = "查看销售单"
            frmSelling.sSalesBillID = Me.dgvList("SalesBillID", Me.dgvList.CurrentRow.Index).Value.ToString
            'modify code 044:start-------------------------------------------------------------------------
            If "线下提卡销售单" = Me.dgvList("SalesBillType", Me.dgvList.CurrentRow.Index).Value.ToString Then
                frmSelling.bNewSalesBillType = 6
            End If
            'modify code 044:end-------------------------------------------------------------------------
            'modify code 046:start-------------------------------------------------------------------------
            If "实名制卡销售单" = Me.dgvList("SalesBillType", Me.dgvList.CurrentRow.Index).Value.ToString Then
                frmSelling.bNewSalesBillType = 7
            End If
            'modify code 046:end-------------------------------------------------------------------------
            'modify code 054:start-------------------------------------------------------------------------
            If "通卖非实名卡销售单" = Me.dgvList("SalesBillType", Me.dgvList.CurrentRow.Index).Value.ToString Then
                frmSelling.bNewSalesBillType = 8
            End If
            'modify code 054:end-------------------------------------------------------------------------
            frmSelling.Show()
            If frmSelling.IsHandleCreated Then
                frmSelling.MdiParent = frmMain
                frmSelling.WindowState = FormWindowState.Maximized
                frmSelling.Activate()
                frmSelling.btnModifyPaymentInfo.Visible = False
            End If

            If frmMain.statusText.Text.IndexOf("……") > -1 Then frmMain.statusText.Text = "就绪。"
            Me.Cursor = Cursors.Default
        End If

        If frmSelling.IsHandleCreated Then
            If frmSelling.dgvNormalCard.CurrentRow IsNot Nothing Then frmSelling.dgvNormalCard.CurrentRow.Selected = False
            If frmSelling.dgvRebateCard.CurrentRow IsNot Nothing Then frmSelling.dgvRebateCard.CurrentRow.Selected = False
            If frmSelling.dgvPayment.CurrentRow IsNot Nothing Then frmSelling.dgvPayment.CurrentRow.Selected = False
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If frmMain.dtAllowedRight.Select("RightName='SalesBillNormalCreate'").Length = 0 Then
            MessageBox.Show("对不起！您没有创建一般销售单的权限。    " & Chr(13) & "Sorry, you have no right to create sales bill.    ", "您无权创建一般销售单 No right to create sales bill!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            'frmMain.menuNewSalesBill.Enabled = False
            Me.btnAdd.Enabled = False : Return
        End If

        If frmSelling.IsHandleCreated Then
            frmSelling.Activate()
            frmSelling.WindowState = FormWindowState.Maximized
            If frmSelling.blIsChanged Then
                Dim bAnswer As DialogResult = MessageBox.Show("是否在新建销售单之前，先保存当前销售单？    ", "当前销售单未保存！", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                If bAnswer = Windows.Forms.DialogResult.Cancel OrElse (bAnswer = Windows.Forms.DialogResult.Yes AndAlso Not frmSelling.SaveChanges()) Then
                    Me.Activate()
                    frmMain.statusText.Text = "因为存在未保存销售单，所以不能新建销售单。"
                    Return
                End If
            End If

            frmSelling.cbbSalesBillType.Items(0) = "一般销售单"
            'modify code 040:start-------------------------------------------------------------------------
            frmSelling.bNewSalesBillType = 0
            'modify code 040:end-------------------------------------------------------------------------
            frmSelling.sSalesBillID = "-1"
            frmSelling.sCustomerID = ""
            frmSelling.blUsedOldCard = False
            frmSelling.ReCreateSalesBill()
        Else
            Me.Cursor = Cursors.WaitCursor
            frmMain.statusText.Text = "正在打开销售单窗口……"
            frmMain.statusMain.Refresh()

            frmSelling.Show()
            If frmSelling.IsHandleCreated Then
                frmSelling.MdiParent = frmMain
                frmSelling.WindowState = FormWindowState.Maximized
                frmSelling.Activate()
            End If

            If frmMain.statusText.Text.IndexOf("……") > -1 Then frmMain.statusText.Text = "就绪。"
            Me.Cursor = Cursors.Default
        End If

        If frmSelling.IsHandleCreated Then
            If frmSelling.dgvNormalCard.CurrentRow IsNot Nothing Then frmSelling.dgvNormalCard.CurrentRow.Selected = False
            If frmSelling.dgvRebateCard.CurrentRow IsNot Nothing Then frmSelling.dgvRebateCard.CurrentRow.Selected = False
            If frmSelling.dgvPayment.CurrentRow IsNot Nothing Then frmSelling.dgvPayment.CurrentRow.Selected = False
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If frmMain.dtAllowedRight.Select("RightName='SalesBillDelete'").Length = 0 Then
            MessageBox.Show("对不起！您没有确认取消销售单的权限。    " & Chr(13) & "Sorry, you have no right to approve to cancell sales bill.    ", "您无权确认取消销售单 No right to approve cancellation!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            blCanDelete = False
            Me.btnDelete.Enabled = False : Return
        End If

        If Not frmSelling.IsHandleCreated OrElse frmSelling.sSalesBillID <> Me.dgvList("SalesBillID", Me.dgvList.CurrentRow.Index).Value.ToString Then
            Me.Cursor = Cursors.WaitCursor
            frmMain.statusText.Text = "正在检索销售单……"
            frmMain.statusMain.Refresh()

            Dim DB As New DataBase()
            DB.Open()
            If Not DB.IsConnected Then
                frmMain.statusText.Text = "系统因连接不到数据库而无法确认取消销售单。请检查数据库连接。"
                Me.Cursor = Cursors.Default : Return
            End If

            Try
                frmConfirmcancelSalesBill.drSalesBill = DB.GetDataTable("Exec SalesBillSingle " & Me.dgvList("SalesBillID", Me.dgvList.CurrentRow.Index).Value.ToString).Rows(0)
            Catch ex As Exception
                frmMain.statusText.Text = "系统因在检索数据时出错而无法确认取消销售单。请联系软件开发人员。"
                DB.Close() : Me.Cursor = Cursors.Default : Return
            End Try
            DB.Close()
            frmMain.statusText.Text = "就绪。"
            frmMain.statusMain.Refresh()
            Me.Cursor = Cursors.Default
        Else
            frmConfirmcancelSalesBill.drSalesBill = frmSelling.drSalesBill
        End If

        frmConfirmcancelSalesBill.ShowDialog()
        frmConfirmcancelSalesBill.Dispose()
    End Sub

    Private Sub btnAdjustSalesman_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjustSalesman.Click
        If frmMain.dtAllowedRight.Select("RightName='SalesBillSalesmanAdjust'").Length = 0 Then
            MessageBox.Show("对不起！您没有调整销售单的负责业务员的权限。    " & Chr(13) & "Sorry, you have no right to adjust the responsible salesman for sales bill.    ", "您无权调整业务员 No right to adjust salesman!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            blCanAdjust = False
            Me.btnAdjustSalesman.Enabled = False : Return
        End If

        Dim sStoreID As String = Me.dgvList("StoreID", Me.dgvList.CurrentRow.Index).Value.ToString, sCityID As String = frmMain.dtLoginStructure.Rows.Find(sStoreID)("ParentAreaID").ToString
        frmMain.dvMediumFish.RowFilter = "AreaID=" & sStoreID
        frmMain.dvBigFish.RowFilter = "AreaID=" & sCityID

        frmAdjustSalesman.currentSalesBill = dvSalesBill.Table.Rows.Find(Me.dgvList("SalesBillID", Me.dgvList.CurrentRow.Index).Value.ToString)
        frmAdjustSalesman.ShowDialog()
        frmAdjustSalesman.Dispose()

        blSkipDeal = True
        Me.dgvList.CurrentRow.Selected = False
        blSkipDeal = False
        Me.dgvList.CurrentRow.Selected = True
    End Sub

    Private Sub btnValidateDiscount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidateDiscount.Click
        If Me.dgvList("NormalRebateApprovableRoleID", Me.dgvList.CurrentRow.Index).Value.ToString <> frmMain.sLoginRoleID Then
            If frmMain.dtAllowedRight.Select("RightName='SalesBillRebateValidate'").Length = 0 Then
                MessageBox.Show("对不起！您没有审核销售单返点的权限。    " & Chr(13) & "Sorry, you have no right to validate the discount of sales bill.    ", "您无权审核返点 No right to validate discount!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                blCanValidate = False
                Me.btnValidateDiscount.Enabled = False
            Else
                MessageBox.Show("对不起，该销售单的返点只能由""" & Me.dgvList("NormalRebateApprovableRoleName", Me.dgvList.CurrentRow.Index).Value.ToString & """人员审核。    " & Chr(13) & Chr(13) & "您不是""" & Me.dgvList("NormalRebateApprovableRoleName", Me.dgvList.CurrentRow.Index).Value.ToString & """，所以不能审核该返点。    ", "您无权审核该销售单返点！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.btnValidateDiscount.Enabled = False
            End If
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在打开""审核销售单返点""窗口……"
        frmMain.statusMain.Refresh()

        frmValidateDiscount.currentSalesBill = dvSalesBill.Table.Rows.Find(Me.dgvList("SalesBillID", Me.dgvList.CurrentRow.Index).Value.ToString)
        frmValidateDiscount.ShowDialog()
        frmValidateDiscount.Dispose()
        If Me.dgvList.CurrentRow IsNot Nothing Then
            blSkipDeal = True
            Me.dgvList.CurrentRow.Selected = False
            blSkipDeal = False
            Me.dgvList.CurrentRow.Selected = True
        Else
            Me.btnOpen.Enabled = False : Me.btnAdjustSalesman.Enabled = False : Me.btnValidateDiscount.Enabled = False
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnCheckAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckAccount.Click
        Me.Cursor = Cursors.WaitCursor
        If Me.btnCheckAccount.Text.IndexOf("对账报表") = 0 Then
            frmMain.statusText.Text = "正在打开""对账报表""……"
            frmMain.statusMain.Refresh()

            With frmCheckAccount
                .dtpFrom.Value = dvSalesBill.ToTable.Compute("Min(CreatedTime)", "")
                .dtpTo.Value = dvSalesBill.ToTable.Compute("Max(CreatedTime)", "")
                .dtpFrom.MinDate = .dtpFrom.Value
                .dtpFrom.MaxDate = .dtpTo.Value
                .dtpTo.MinDate = .dtpFrom.Value
                .dtpTo.MaxDate = .dtpTo.Value
                .ShowDialog()
                .Dispose()
            End With
        Else
            frmMain.statusText.Text = "正在打开""购物卡盘点报表""……"
            frmMain.statusMain.Refresh()

            frmCardCycle.ShowDialog()
            frmCardCycle.Dispose()
        End If
        If frmMain.statusText.Text.IndexOf("无法") = -1 Then frmMain.statusText.Text = "就绪。"
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Me.btnOpen.Enabled = False : Me.btnDelete.Enabled = False : Me.btnAdjustSalesman.Enabled = False : Me.btnValidateDiscount.Enabled = False

        Dim drLoad As DataRow, sStoreID As String = Me.trvArea.SelectedNode.Name, sSalesDate As String = Format(Me.dtpSalesDate.Value, "yyyy\/MM\/dd"), sRowFilter As String = "StoreID=" & sStoreID & " And SalesDate='" & Format(Me.dtpSalesDate.Value, "yyyy\/MM\/dd") & "'"
        drLoad = dtLoaded.Select("StoreID=" & sStoreID & " And SalesDate='" & sSalesDate & "'")(0)
        If DateDiff(DateInterval.Minute, drLoad("LoadedTime"), Now()) < 5 Then
            If drLoad("IsRefreshed") = 0 Then
                MessageBox.Show("距离该店该日的数据下载时间还不足 5 分钟。    " & Chr(13) & Chr(13) & "数据下载时间： " & Format(drLoad("LoadedTime"), "HH:mm") & Chr(13) & Chr(13) & "请在数据下载时间的 5 分钟后再刷新。    ", "刷新不能过于频繁！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("距离该店该日的上次刷新时间还不足 5 分钟。    " & Chr(13) & Chr(13) & "上次刷新时间： " & Format(drLoad("LoadedTime"), "HH:mm") & Chr(13) & Chr(13) & "请在上次刷新时间的 5 分钟后再刷新。    ", "刷新不能过于频繁！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在刷新销售单……"
        frmMain.statusMain.Refresh()
        Dim DB As New DataBase, dtList As DataTable
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法刷新销售单。请检查数据库连接。"
        Else
            dtList = DB.GetDataTable("Exec GetSalesBillList @LoginUserID=" & frmMain.sLoginUserID & ",@StoreID=" & sStoreID & ",@SalesDate='" & sSalesDate & "'")
            If dtList Is Nothing Then
                frmMain.statusText.Text = "系统因在检索数据时出错而无法找到销售单。请联系软件开发人员。"
            Else
                dvSalesBill.RowFilter = "1=2"
                For Each drSalesBill As DataRowView In dvSalesBill
                    drSalesBill.Delete()
                    drSalesBill.Row.AcceptChanges()
                Next
                dvSalesBill.Table.Merge(dtList.Copy)
                dvSalesBill.RowFilter = sRowFilter
                drLoad("LoadedTime") = Now() : drLoad("IsRefreshed") = 1 : drLoad.AcceptChanges()
                dtList.Dispose() : dtList = Nothing : DB.Close()
            End If
        End If
        Me.Cursor = Cursors.Default

        If dvSalesBill.Count = 0 Then
            blSkipDeal = True
            Me.cbbSalesBillType.SelectedIndex = 0
            Me.cbbSalesBillState.SelectedIndex = 0
            blSkipDeal = False
        End If

        With Me.dgvList.Columns("CustomerName")
            .MinimumWidth = 2
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .MinimumWidth = .Width
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        If Me.dgvList.CurrentRow Is Nothing AndAlso Me.dgvList.RowCount > 0 Then Me.dgvList(1, 0).Selected = True : Me.dgvList.Rows(0).Selected = True

        Me.SummaryInfo()
    End Sub

    Private Sub SetRowFilter()
        Me.btnOpen.Enabled = False : Me.btnDelete.Enabled = False : Me.btnAdjustSalesman.Enabled = False : Me.btnValidateDiscount.Enabled = False

        Dim sStoreID As String = Me.trvArea.SelectedNode.Name, sSalesDate As String = Format(Me.dtpSalesDate.Value, "yyyy\/MM\/dd")
        sRowFilter = "StoreID=" & sStoreID & " And SalesDate='" & Format(Me.dtpSalesDate.Value, "yyyy\/MM\/dd") & "'"

        Select Case Me.cbbSalesBillType.SelectedIndex
            Case 1
                sRowFilter = sRowFilter & " And SalesBillType='一般销售单'"
            Case 2
                sRowFilter = sRowFilter & " And RebateMode='没有返点'"
            Case 3
                sRowFilter = sRowFilter & " And RebateMode='城市返点'"
            Case 4
                sRowFilter = sRowFilter & " And RebateMode='城市返点' And RebateState='不用审核'"
            Case 5
                sRowFilter = sRowFilter & " And Isnull(NormalRebateApprovableRoleID,255)<>255"
            Case 6
                Me.lblSalesBillType.Text = "等待审核城市返点 Waiting to Validate"
                sRowFilter = sRowFilter & " And RebateState='等待审核'"
            Case 7
                Me.lblSalesBillType.Text = "城市返点审核失败 Validated Failure"
                sRowFilter = sRowFilter & " And RebateState='审核失败'"
            Case 8
                Me.lblSalesBillType.Text = "城市返点审核成功 Validated Sucessfully"
                sRowFilter = sRowFilter & " And RebateState='审核成功'"
            Case 9
                Me.lblSalesBillType.Text = "合同返点的销售单 Contract Discount"
                sRowFilter = sRowFilter & " And RebateMode='合同返点'"
            Case 10
                Me.lblSalesBillType.Text = "合同结余返点的销售单 Contract Discount"
                sRowFilter = sRowFilter & " And RebateMode='合同结余'"
            Case 11
                sRowFilter = sRowFilter & " And SalesBillType='退货销售单'"
            Case 12
                sRowFilter = sRowFilter & " And SalesBillType='活动卡销售单'"
            Case 13
                sRowFilter = sRowFilter & " And SalesBillType='公关卡销售单'"
            Case 14
                sRowFilter = sRowFilter & " And SalesBillType='员工销售单'"
                'modify code 040:start-------------------------------------------------------------------------
                'Case 15
                '    sRowFilter = sRowFilter & " And SalesBillType='联名卡销售单'"
            Case 15
                sRowFilter = sRowFilter & " And SalesBillType='线下提卡销售单'"
                'modify code 046:start-------------------------------------------------------------------------
                '添加实名制
            Case 16
                sRowFilter = sRowFilter & " And SalesBillType='实名制卡销售单'"
                'modify code 054:start-------------------------------------------------------------------------
            Case 17
                sRowFilter = sRowFilter & " And SalesBillType='通卖非实名卡销售单'"
                'Case 16
                'Case 17
            Case 18
                sRowFilter = sRowFilter & " And SalesBillType='联名卡销售单'"
                'modify code 040,046,054:end-------------------------------------------------------------------------
        End Select

        Select Case Me.cbbSalesBillState.SelectedIndex
            Case 1
                sRowFilter = sRowFilter & " And SalesBillState='等待激活'"
            Case 2
                sRowFilter = sRowFilter & " And SalesBillState='正在激活'"
            Case 3
                sRowFilter = sRowFilter & " And SalesBillState='激活失败'"
            Case 4
                sRowFilter = sRowFilter & " And SalesBillState='部分激活'"
            Case 5
                sRowFilter = sRowFilter & " And SalesBillState='全部激活'"
            Case 6
                sRowFilter = sRowFilter & " And SalesBillState='等待取消'"
            Case 7
                sRowFilter = sRowFilter & " And SalesBillState='已撤销激活'"
        End Select
        dvSalesBill.RowFilter = sRowFilter

        With Me.dgvList.Columns("CustomerName")
            .MinimumWidth = 2
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .MinimumWidth = .Width
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        If Me.dgvList.CurrentRow Is Nothing AndAlso Me.dgvList.RowCount > 0 Then Me.dgvList(1, 0).Selected = True : Me.dgvList.Rows(0).Selected = True
        Me.btnCheckAccount.Enabled = (dvSalesBill.ToTable.Select("SalesBillState<>'等待取消' And SalesBillState<>'已撤销激活'").Length > 0)
        Me.SummaryInfo()
    End Sub

    Private Sub SummaryInfo()
        If dvSalesBill.Count = 0 Then
            frmMain.statusText.Text = "未发现销售单。"
        Else
            Dim dvTemp As DataView = dvSalesBill.ToTable.DefaultView
            dvTemp.RowFilter = "SalesBillState<>'等待取消' And SalesBillState<>'已撤销激活'"
            Dim dtSalesBill As DataTable = dvTemp.ToTable
            dvTemp.Dispose() : dvTemp = Nothing
            Dim sInfo As String = "共 " & Format(dtSalesBill.Rows.Count, "#,0") & " 张销售单 -- 卡数："
            Try
                sInfo = sInfo & Format(dtSalesBill.Compute("SUM(CardQTY)", ""), "#,0") & " 张；充值金额："
            Catch
                sInfo = sInfo & "0 张；充值金额："
            End Try
            Try
                sInfo = sInfo & Format(dtSalesBill.Compute("SUM(ChargedAMT)", ""), "#,0.00") & " 元（含返点金额："
            Catch
                sInfo = sInfo & "0 元（含返点金额："
            End Try
            Try
                sInfo = sInfo & Format(dtSalesBill.Compute("SUM(RebateSalesAMT)", ""), "#,0.00") & " 元）；应付金额："
            Catch
                sInfo = sInfo & "0 元）；应付金额："
            End Try
            Try
                sInfo = sInfo & Format(dtSalesBill.Compute("SUM(PayableAMT)", ""), "#,0.00") & " 元。"
            Catch
                sInfo = sInfo & "0 元。"
            End Try
            dtSalesBill.Dispose() : dtSalesBill = Nothing
            frmMain.statusText.Text = sInfo
        End If
    End Sub
End Class