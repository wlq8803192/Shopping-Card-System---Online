Imports System.Runtime.InteropServices

'modify code 025:
'date;2014/6/4
'auther:Hyron bjy 
'remark:FSM客户信息接口

'modify code 029:
'date;2014/6/26
'auther:Hyron bjy 
'remark:当前城市下创建第一个客户时BUG修正

Public Class frmCustomerManagement
    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=False)> _
   Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Int16, ByVal wParam As Int16, ByVal lParam As Int16) As IntPtr
        '让滚动条始终处在左边
    End Function

    Private blSkipDeal As Boolean = True, sStoreID As String, sControllableBusinessTypes As String = ""
    Private blCanDelete As Boolean = True, blCanSelling As Boolean = True, blCanCreateContract As Boolean = True, blCanBrowseContract As Boolean = True
    Private dvBusinessType As DataView
    Public dvCustomer As DataView, iSearchNo As Integer = -1

    Private Sub frmCustomerManagement_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If frmMain.statusText.Text.IndexOf("无法") = -1 Then frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub frmCustomerManagement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DB As New DataBase()
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打开""客户管理""窗口。请检查数据库连接。"
            Me.Close() : Return
        End If

        'modify code 025:start-------------------------------------------------------------------------
        '当用户所属区域无门店时BUG修正
        'sStoreID = frmMain.dtLoginStructure.Select("AreaType='S'")(0)("AreaID").ToString
        If frmMain.dtLoginStructure.Select("AreaType='S'").Length > 0 Then
            sStoreID = frmMain.dtLoginStructure.Select("AreaType='S'")(0)("AreaID").ToString
        Else
            MessageBox.Show("此用户还没有分配的门店，因此不能使用此功能。请先为此用户分配门店。") : Me.Close() : Return
        End If
        'modify code 025:end-------------------------------------------------------------------------
        Try
            sControllableBusinessTypes = DB.GetDataTable("Select ControllableBusinessTypes From UserList Where UserID=" & frmMain.sLoginUserID).Rows(0)(0).ToString

            If frmMain.sLoginAreaType = "S" Then
                dvBusinessType = DB.GetDataTable("Select * From CityBusinessTypeView Where CityID=" & frmMain.dtLoginStructure.Rows(0)("ParentAreaID").ToString).DefaultView
            Else
                dvBusinessType = DB.GetDataTable("Select * From CityBusinessTypeView AS C Join AreaScope(" & frmMain.sLoginUserID & ") AS S ON C.CityID=S.AreaID").DefaultView
            End If

            If frmMain.sLoginRoleID = "14" Then '售卡员
                dvCustomer = DB.GetDataTable("Select *, Convert(int,-1) As SearchNo From CustomerView Where CreatorID=" & frmMain.sLoginUserID).DefaultView
            ElseIf sControllableBusinessTypes = "" OrElse sControllableBusinessTypes = "All" Then
                dvCustomer = DB.GetDataTable("Select *, Convert(int,-1) As SearchNo From CustomerView Where StoreID=" & sStoreID).DefaultView
            Else
                dvCustomer = DB.GetDataTable("Select *, Convert(int,-1) As SearchNo From CustomerView Where StoreID=" & sStoreID & " And '" & sControllableBusinessTypes & "' Like '%|'+Convert(varchar(10),BusinessTypeID)+'|%'").DefaultView
            End If
            dvCustomer.Table.PrimaryKey = New DataColumn() {dvCustomer.Table.Columns("CustomerID")}
        Catch
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开""客户管理""窗口。请联系软件开发人员。"
            DB.Close() : Me.Close() : Return
        End Try
        DB.Close()

        Dim allTypes As DataRowView = dvBusinessType.AddNew()
        allTypes("CityID") = -1 : allTypes("BusinessTypeID") = -1 : allTypes("BusinessTypeFullName") = "(所有商业类型 All Business Types)"
        allTypes.EndEdit() : allTypes.Row.AcceptChanges() : allTypes = Nothing

        dvBusinessType.Sort = "BusinessTypeCode"
        dvBusinessType.RowFilter = "CityID=-1"
        With Me.cbbBusinessType
            .DataSource = dvBusinessType
            .ValueMember = "BusinessTypeID"
            .DisplayMember = "BusinessTypeFullName"
            .SelectedIndex = 0
        End With

        dvCustomer.Sort = "CustomerCode"
        dvCustomer.RowFilter = "StoreID=-1"
        With Me.dgvList
            .DataSource = dvCustomer
            .Columns(0).Visible = False
            With .Columns(1)
                .HeaderText = "编号 Code"
                .Width = 85
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(2)
                .HeaderText = "中文名称 Chinese Name"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(3)
                .HeaderText = "英文名称 English Name"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(4)
                .HeaderText = "拼音码 Pinyin Code"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(5)
                .HeaderText = "所属门店 Store Belongs"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(6)
                .HeaderText = "商业类型 Business Type"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(7)
                .HeaderText = "业务员 Salesman"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(8)
                .HeaderText = "Sales Bill Count"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "#,0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(9)
                .HeaderText = "Contract Count"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "#,0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            Dim linkColomn As New DataGridViewLinkColumn
            linkColomn.DataPropertyName = "ValidContractCode"
            .Columns.RemoveAt(10)
            .Columns.Insert(10, linkColomn)
            With .Columns(10)
                .HeaderText = "Effective Contract"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            linkColomn = New DataGridViewLinkColumn
            linkColomn.DataPropertyName = "InvalidContractCode"
            .Columns.RemoveAt(11)
            .Columns.Insert(11, linkColomn)
            With .Columns(11)
                .HeaderText = "Ineffective Contract"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(12)
                .HeaderText = "状态 State"
                .MinimumWidth = 120
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            .Columns(13).Visible = False
            .Columns(14).Visible = False
            .Columns(15).Visible = False
            .Columns(16).Visible = False
            .Columns(17).Visible = False
            .Columns(18).Visible = False
            .Columns(19).Visible = False
            .Columns(20).Visible = False
            .Columns(21).Visible = False
        End With
        For bColumn As Byte = 0 To dvCustomer.Table.Columns.Count - 1
            Me.dgvList.Columns(bColumn).Name = dvCustomer.Table.Columns(bColumn).ColumnName
        Next

        Me.InitArea(Me.trvArea.Nodes, frmMain.dtLoginStructure.Rows(0)("ParentAreaID").ToString)
        Me.trvArea.ExpandAll()
        Me.trvArea.SelectedNode = Nothing
        blSkipDeal = False
        Dim firstStore As TreeNode = Me.trvArea.Nodes.Find(sStoreID, True)(0)
        firstStore.Tag = "Loaded"
        Me.trvArea.SelectedNode = firstStore
        firstStore.EnsureVisible()
        If frmMain.sLoginAreaType = "S" Then
            Me.Split.Panel1.Controls.Remove(Me.btnSearch)
            Me.Split.Panel2.Controls.Add(Me.btnSearch)
            Me.btnSearch.Location = New Point(Me.btnOpen.Location)
            Me.btnOpen.Location = New Point(Me.btnOpen.Left + Me.btnSearch.Width + 30, Me.btnOpen.Top)
            Me.btnAdd.Location = New Point(Me.btnAdd.Left + Me.btnSearch.Width + 30, Me.btnAdd.Top)
            Me.btnDelete.Location = New Point(Me.btnDelete.Left + Me.btnSearch.Width + 30, Me.btnDelete.Top)
            Me.Split.Panel1Collapsed = True
        Else
            SendMessage(Me.trvArea.Handle, 276, 6, 0)
        End If

        Me.btnAdd.Enabled = (frmMain.dtAllowedRight.Select("RightName='CustomerCreate'").Length > 0)
        blCanDelete = (frmMain.dtAllowedRight.Select("RightName='CustomerDelete'").Length > 0)
        blCanBrowseContract = (frmMain.dtAllowedRight.Select("RightName Like 'Contract%' And RightName<>'ContractCreate'").Length > 0)
        blCanCreateContract = (frmMain.dtAllowedRight.Select("RightName='ContractCreate'").Length > 0)
        blCanSelling = (frmMain.dtAllowedRight.Select("RightName='SalesBillNormalCreate'").Length > 0)
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

        sStoreID = Me.trvArea.SelectedNode.Name
        If Me.trvArea.SelectedNode.Tag Is Nothing Then
            Me.Cursor = Cursors.WaitCursor
            frmMain.statusText.Text = "正在检索客户……"
            frmMain.statusMain.Refresh()
            Dim DB As New DataBase, dtList As DataTable
            DB.Open()
            If Not DB.IsConnected Then
                frmMain.statusText.Text = "系统因连接不到数据库而无法检索客户。请检查数据库连接。"
            Else
                If sControllableBusinessTypes = "" OrElse sControllableBusinessTypes = "All" Then
                    dtList = DB.GetDataTable("Select *, Convert(int,-1) As SearchNo From CustomerView Where StoreID=" & sStoreID)
                Else
                    dtList = DB.GetDataTable("Select *, Convert(int,-1) As SearchNo From CustomerView Where StoreID=" & sStoreID & " And '" & sControllableBusinessTypes & "' Like '%|'+Convert(varchar(10),BusinessTypeID)+'|%'")
                End If
                If dtList Is Nothing Then
                    frmMain.statusText.Text = "系统因在检索数据时出错而无法找到客户。请联系软件开发人员。"
                Else
                    dvCustomer.Table.Merge(dtList.Copy, False)
                    Me.trvArea.SelectedNode.Tag = "Loaded"
                    dtList.Dispose() : dtList = Nothing : DB.Close()
                End If
            End If
            Me.Cursor = Cursors.Default
        End If

        blSkipDeal = True
        Dim sOldBusinessTypeID As String = Me.cbbBusinessType.SelectedValue.ToString
        dvBusinessType.RowFilter = "CityID=-1 Or CityID=" & frmMain.dtLoginStructure.Select("AreaID=" & sStoreID)(0)("ParentAreaID").ToString
        Me.cbbBusinessType.SelectedValue = sOldBusinessTypeID
        If Me.cbbBusinessType.SelectedIndex = -1 Then Me.cbbBusinessType.SelectedIndex = 0

        Me.btnOpen.Enabled = False : Me.btnDelete.Enabled = False : Me.btnSelling.Enabled = False : Me.btnCreateContract.Enabled = False
        Dim sRowFilter As String = "StoreID=" & sStoreID
        If Me.cbbBusinessType.SelectedValue <> -1 Then sRowFilter = sRowFilter & " And BusinessTypeID=" & Me.cbbBusinessType.SelectedValue.ToString
        dvCustomer.RowFilter = sRowFilter
        If Me.dgvList.CurrentRow Is Nothing AndAlso Me.dgvList.RowCount > 0 Then Me.dgvList(1, 0).Selected = True : Me.dgvList.Rows(0).Selected = True
        blSkipDeal = False
        frmMain.statusText.Text = "共 " & Format(dvCustomer.Count, "#,0") & " 个客户。"
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
        If frmMain.sLoginAreaType = "S" Then
            Dim sOldRowFilter As String = dvCustomer.RowFilter, sRowFilter As String = "StoreID=" & sStoreID
            If Me.cbbBusinessType.SelectedValue <> -1 Then sRowFilter = sRowFilter & " And BusinessTypeID=" & Me.cbbBusinessType.SelectedValue.ToString
            If sOldRowFilter <> sRowFilter Then dvCustomer.RowFilter = sRowFilter
        End If

        If frmSearchCustomer.ShowDialog() = Windows.Forms.DialogResult.OK AndAlso Me.dgvList.RowCount > 1 Then
            MessageBox.Show("共找到 " & Format(Me.dgvList.RowCount, "#,0") & " 个客户。请看下面客户列表。    " & IIf(Me.dgvList.RowCount = 500, Chr(13) & Chr(13) & "注意：一次最多只能找到 500 个客户。    ", ""), "查找结束。", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        frmSearchCustomer.Dispose()
    End Sub

    Private Sub cbbBusinessType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbBusinessType.SelectedIndexChanged
        If blSkipDeal Then Return

        Me.btnOpen.Enabled = False : Me.btnDelete.Enabled = False : Me.btnSelling.Enabled = False : Me.btnCreateContract.Enabled = False
        If Me.trvArea.SelectedNode Is Nothing Then
            Me.trvArea.Select()
            Me.trvArea.SelectedNode = Me.trvArea.Nodes.Find(sStoreID, True)(0)
            Me.cbbBusinessType.Select()
        End If
        Dim sRowFilter As String = "StoreID=" & Me.trvArea.SelectedNode.Name
        If Me.cbbBusinessType.SelectedValue <> -1 Then sRowFilter = sRowFilter & " And BusinessTypeID=" & Me.cbbBusinessType.SelectedValue.ToString
        dvCustomer.RowFilter = sRowFilter
        If Me.dgvList.CurrentRow Is Nothing AndAlso Me.dgvList.RowCount > 0 Then Me.dgvList(1, 0).Selected = True : Me.dgvList.Rows(0).Selected = True
        frmMain.statusText.Text = "共 " & Format(dvCustomer.Count, "#,0") & " 个客户。"
    End Sub

    Private Sub dgvList_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvList.CellContentClick
        If e.RowIndex = -1 Then Return
        Dim sContractID As String = "", sContractCode As String = ""
        If Me.dgvList.Columns(e.ColumnIndex).Name = "ValidContractCode" AndAlso Me.dgvList(e.ColumnIndex, e.RowIndex).Value.ToString <> "" Then
            sContractID = Me.dgvList("ValidContractID", e.RowIndex).Value.ToString
            sContractCode = Me.dgvList("ValidContractCode", e.RowIndex).Value.ToString
        ElseIf Me.dgvList.Columns(e.ColumnIndex).Name = "InvalidContractCode" AndAlso Me.dgvList(e.ColumnIndex, e.RowIndex).Value.ToString <> "" Then
            sContractID = Me.dgvList("InvalidContractID", e.RowIndex).Value.ToString
            sContractCode = Me.dgvList("InvalidContractCode", e.RowIndex).Value.ToString
        End If

        If sContractID <> "" Then
            If blCanBrowseContract Then
                If frmMain.dtAllowedRight.Select("RightName='ContractBrowse'").Length = 0 Then
                    MessageBox.Show("对不起！您没有浏览合同的权限。    " & Chr(13) & "Sorry, you have no right to browse contract.    ", "您无权浏览合同 No right to browse contract!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    blCanBrowseContract = False
                    frmMain.statusText.Text = "对不起！您没有浏览合同的权限。"
                Else
                    Me.Cursor = Cursors.WaitCursor
                    frmMain.statusText.Text = "正在打开合同""" & sContractCode & " " & Me.dgvList("CustomerChineseName", e.RowIndex).Value.ToString & """……"
                    frmMain.statusMain.Refresh()

                    frmContract.sContractID = sContractID
                    frmContract.ShowDialog()
                    frmContract.Dispose()

                    Me.dgvList.Select()
                    Me.Cursor = Cursors.Default
                End If
            Else
                frmMain.statusText.Text = "对不起！您没有浏览合同的权限。"
            End If
        End If
    End Sub

    Private Sub dgvList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvList.CellDoubleClick
        If e.RowIndex = -1 Then Return
        If (Me.dgvList.Columns(e.ColumnIndex).Name = "ValidContractCode" OrElse Me.dgvList.Columns(e.ColumnIndex).Name = "InvalidContractCode") AndAlso Me.dgvList(e.ColumnIndex, e.RowIndex).Value.ToString <> "" Then Return

        Me.btnOpen.PerformClick()
    End Sub

    Private Sub dgvList_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvList.CellFormatting
        If Me.dgvList.Columns(e.ColumnIndex).GetType.Name = "DataGridViewLinkColumn" Then
            If Me.dgvList.CurrentRow IsNot Nothing AndAlso Me.dgvList.CurrentRow.Index = e.RowIndex AndAlso Me.dgvList.CurrentRow.Selected Then
                CType(Me.dgvList(e.ColumnIndex, e.RowIndex), DataGridViewLinkCell).LinkColor = Color.Yellow
            Else
                CType(Me.dgvList(e.ColumnIndex, e.RowIndex), DataGridViewLinkCell).LinkColor = Color.Blue
            End If
        End If
    End Sub

    Private Sub dgvList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvList.SelectionChanged
        If Me.dgvList.CurrentRow Is Nothing Then Return
        Me.btnOpen.Enabled = True
        'modify code 029:start-------------------------------------------------------------------------
        'Me.btnDelete.Enabled = (blCanDelete AndAlso Me.dgvList("SalesBillCount", Me.dgvList.CurrentRow.Index).Value + Me.dgvList("ContractCount", Me.dgvList.CurrentRow.Index).Value = 0)
        Me.btnDelete.Enabled = (blCanDelete AndAlso Not IsDBNull(Me.dgvList("SalesBillCount", Me.dgvList.CurrentRow.Index).Value) AndAlso Not IsDBNull(Me.dgvList("ContractCount", Me.dgvList.CurrentRow.Index).Value) AndAlso Me.dgvList("SalesBillCount", Me.dgvList.CurrentRow.Index).Value + Me.dgvList("ContractCount", Me.dgvList.CurrentRow.Index).Value = 0)
        'modify code 029:end-------------------------------------------------------------------------
        Me.btnSelling.Enabled = blCanSelling : Me.btnCreateContract.Enabled = (blCanCreateContract AndAlso Me.dgvList("InvalidContractCode", Me.dgvList.CurrentRow.Index).Value.ToString = "")
        If frmMain.statusText.Text.IndexOf("个客户") = -1 Then frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        Dim openingRow As DataRow = dvCustomer.Table.Rows.Find(Me.dgvList("CustomerID", Me.dgvList.CurrentRow.Index).Value.ToString)

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在打开客户""" & openingRow("CustomerCode").ToString & " " & openingRow("CustomerChineseName").ToString & """……"
        frmMain.statusMain.Refresh()

        frmCustomer.sCustomerID = openingRow("CustomerID").ToString
        frmCustomer.ShowDialog()
        frmCustomer.Dispose()

        openingRow = Nothing
        Me.dgvList.Select()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If frmMain.dtAllowedRight.Select("RightName='CustomerCreate'").Length = 0 Then
            MessageBox.Show("对不起，您无权限创建新客户。    " & Chr(13) & _
                            "Sorry, you have no right to create new Customer.    ", "无权限创建客户 No right to create Customer!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'frmMain.menuNewCustomer.Enabled = False
            Me.btnAdd.Enabled = False : Return
        End If

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在打开客户窗口……"
        frmMain.statusMain.Refresh()

        frmCustomer.ShowDialog()
        frmCustomer.Dispose()

        Me.dgvList.Select()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If frmMain.dtAllowedRight.Select("RightName='CustomerDelete'").Length = 0 Then
            MessageBox.Show("对不起，您无权限删除客户。    " & Chr(13) & _
                            "Sorry, you have no right to delete Customer.    ", "无权限删除客户 No right to delete Customer!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            blCanDelete = False
            Me.btnDelete.Enabled = False : Return
        End If

        Dim deletingRow As DataRow = dvCustomer.Table.Rows.Find(Me.dgvList("CustomerID", Me.dgvList.CurrentRow.Index).Value.ToString)
        If deletingRow("SalesBillCount") + deletingRow("ContractCount") > 0 Then
            MessageBox.Show("该客户已被使用，再也不能删除！    " & Chr(13) & "You can not delete this Customer since it had been used .    ", "不能删除该客户 The Customer can not be delete!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.btnDelete.Enabled = False : deletingRow = Nothing : Return
        End If

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在删除客户""" & deletingRow("CustomerCode").ToString & " " & deletingRow("CustomerChineseName").ToString & """……"
        frmMain.statusMain.Refresh()

        Dim DB As New DataBase()
        DB.Open()
        If DB.IsConnected Then
            Dim dtResult As DataTable = DB.GetDataTable("Exec CustomerDeletion " & deletingRow("CustomerID").ToString & "," & frmMain.sSSID)
            If dtResult Is Nothing Then
                frmMain.statusText.Text = "系统因在检索数据时出错而无法删除客户。请联系软件开发人员。"
            Else
                Select Case dtResult.Rows(0)(0).ToString
                    Case "AlreadyDeleted"
                        MessageBox.Show("该客户已被其他用户删除。 The Customer had been deleted by someone else.    ", "客户已被他人删除！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        deletingRow.Delete() : deletingRow.AcceptChanges()
                        frmMain.statusText.Text = "该客户已被其他用户删除。"
                    Case "AlreadyUsed"
                        MessageBox.Show("该客户已被使用，再也不能删除！    " & Chr(13) & "You can not delete this Customer since it had been used.    ", "不能删除该客户 The Customer can not be delete!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        deletingRow("SalesBillCount") = dtResult.Rows(0)("SalesBillCount") : deletingRow("ContractCount") = dtResult.Rows(0)("ContractCount") : deletingRow.AcceptChanges()
                        Me.btnDelete.Enabled = False
                        frmMain.statusText.Text = "该客户已被使客（登录过系统），再也不能删除！"
                    Case "OK"
                        deletingRow.Delete() : deletingRow.AcceptChanges()
                        frmMain.statusText.Text = "删除客户成功。"
                    Case Else
                        MessageBox.Show("删除客户时出现错误！下面是数据库的内部错误提示：    " & Chr(13) & Chr(13) & dtResult.Rows(0)("Reason").ToString & Space(4) & Chr(13) & Chr(13) & "请放弃删除，在关闭窗口后重试。如果仍有问题，请联系软件开发人员。    ", "删除客户失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        frmMain.statusText.Text = "删除客户失败！"
                End Select
                dtResult.Dispose() : dtResult = Nothing
            End If
        Else
            frmMain.statusText.Text = "系统因连接不到数据库而无法删除客户。请检查数据库连接。"
        End If

        DB.Close() : deletingRow = Nothing
        If Me.dgvList.CurrentRow IsNot Nothing Then
            Me.dgvList.CurrentRow.Selected = True
        Else
            Me.btnOpen.Enabled = False : Me.btnDelete.Enabled = False : Me.btnSelling.Enabled = False : Me.btnCreateContract.Enabled = False
        End If
        Me.dgvList.Select()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnSelling_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelling.Click
        If frmMain.dtAllowedRight.Select("RightName='SalesBillNormalCreate'").Length = 0 Then
            MessageBox.Show("对不起！您没有创建销售单的权限。    " & Chr(13) & "Sorry, you have no right to create sales bill.    ", "您无权创建销售单 No right to create sales bill!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            'frmMain.menuNewSalesBill.Enabled = False
            blCanSelling = False : Me.btnSelling.Enabled = False : Return
        End If

        If frmSelling.IsHandleCreated Then
            frmSelling.Activate()
            If frmSelling.blIsChanged Then
                Dim bAnswer As DialogResult = MessageBox.Show("是否在新建销售单之前，先保存当前销售单？    ", "当前销售单未保存！", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                If bAnswer = Windows.Forms.DialogResult.Cancel OrElse (bAnswer = Windows.Forms.DialogResult.Yes AndAlso Not frmSelling.SaveChanges()) Then
                    Me.Activate()
                    frmMain.statusText.Text = "因为存在未保存销售单，所以不能新建销售单。"
                Else
                    frmSelling.sCustomerID = Me.dgvList("CustomerID", Me.dgvList.CurrentRow.Index).Value.ToString
                    frmSelling.ReCreateSalesBill()
                End If
            Else
                frmSelling.cbbSalesBillType.Items(0) = "一般销售单"
                frmSelling.sCustomerID = Me.dgvList("CustomerID", Me.dgvList.CurrentRow.Index).Value.ToString
                frmSelling.bNewSalesBillType = 0
                frmSelling.blUsedOldCard = False
                frmSelling.ReCreateSalesBill()
            End If
        Else
            Me.Cursor = Cursors.WaitCursor
            frmMain.statusText.Text = "正在打开销售单窗口……"
            frmMain.statusMain.Refresh()

            frmSelling.sCustomerID = Me.dgvList("CustomerID", Me.dgvList.CurrentRow.Index).Value.ToString
            frmSelling.Show()
            If frmSelling.IsHandleCreated Then
                frmSelling.MdiParent = frmMain
                frmSelling.WindowState = FormWindowState.Maximized
                frmSelling.Activate()
                If frmSelling.dgvNormalCard.CurrentRow IsNot Nothing Then frmSelling.dgvNormalCard.CurrentRow.Selected = False
                If frmSelling.dgvRebateCard.CurrentRow IsNot Nothing Then frmSelling.dgvRebateCard.CurrentRow.Selected = False
                If frmSelling.dgvPayment.CurrentRow IsNot Nothing Then frmSelling.dgvPayment.CurrentRow.Selected = False
            End If

            If frmMain.statusText.Text.IndexOf("……") > -1 Then frmMain.statusText.Text = "就绪。"
            Me.Cursor = Cursors.Default
            End If
    End Sub

    Private Sub btnCreateContract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateContract.Click
        If frmMain.dtAllowedRight.Select("RightName='ContractCreate'").Length = 0 Then
            MessageBox.Show("对不起，您无权限创建合同。    " & Chr(13) & _
                            "Sorry, you have no right to create contract.    ", "无权限创建合同 No right to create contract!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            blCanCreateContract = False
            Me.btnCreateContract.Enabled = False : Return
        End If

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在打开合同窗口……"
        frmMain.statusMain.Refresh()

        frmContract.sCustomerID = Me.dgvList("CustomerID", Me.dgvList.CurrentRow.Index).Value.ToString
        frmContract.ShowDialog()
        frmContract.Dispose()

        Me.dgvList.Select()
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub UpdateCustomer(ByVal drCustomer As DataRow)
        Dim customerRow As DataRow = dvCustomer.Table.Rows.Find(drCustomer("CustomerID").ToString)
        If customerRow Is Nothing Then Return

        customerRow("CustomerCode") = drCustomer("StoreCode").ToString & drCustomer("CustomerCode").ToString
        customerRow("CustomerChineseName") = drCustomer("CustomerChineseName").ToString
        customerRow("CustomerEnglishName") = drCustomer("CustomerEnglishName")
        customerRow("PinYinCode") = drCustomer("PinYinCode").ToString
        customerRow("StoreName") = drCustomer("StoreFullName").ToString.Substring(5)
        customerRow("BusinessTypeName") = drCustomer("BusinessTypeFullName").ToString.Substring(3)
        If drCustomer("SalesmanID") = -1 Then
            CustomerRow("SalesmanName") = "(没有负责业务员 No responsible Salesman)"
        Else
            CustomerRow("SalesmanName") = drCustomer("SalesmanName").ToString
        End If
        If drCustomer("ValidContractCode").ToString = "" Then
            customerRow("ValidContractCode") = DBNull.Value
        Else
            customerRow("ValidContractCode") = drCustomer("ValidContractCode").ToString
        End If
        If drCustomer("InvalidContractCode").ToString = "" Then
            customerRow("InvalidContractCode") = DBNull.Value
        Else
            customerRow("InvalidContractCode") = drCustomer("InvalidContractCode").ToString
        End If
        If drCustomer("Stopped") Then
            customerRow("StateDescription") = "停止使用 Blocked"
        Else
            customerRow("StateDescription") = "正常 Actived"
        End If
        customerRow("CityID") = drCustomer("CityID")
        customerRow("StoreID") = drCustomer("StoreID")
        customerRow("BusinessTypeID") = drCustomer("BusinessTypeID")
        customerRow("SalesmanID") = drCustomer("SalesmanID")
        customerRow("ValidContractID") = drCustomer("ValidContractID")
        customerRow("InvalidContractID") = drCustomer("InvalidContractID")
        customerRow("Stopped") = drCustomer("Stopped")
        customerRow.EndEdit() : customerRow.AcceptChanges()
        If Me.dgvList.CurrentRow IsNot Nothing AndAlso Me.dgvList("CustomerID", Me.dgvList.CurrentRow.Index).Value.ToString = drCustomer("CustomerID").ToString Then
            Me.dgvList.CurrentRow.Selected = False
            Me.dgvList.CurrentRow.Selected = True
        End If
    End Sub
End Class