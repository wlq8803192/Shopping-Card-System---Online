Public Class frmContractManagement

    'modify code 038:
    'date;2014/9/24
    'auther:Hyron bjy 
    'remark:返点比率0.0->0.00

    Private blSkipDeal As Boolean = True, blCanDelete As Boolean = True, sControllableBusinessTypes As String = ""
    Public dvContract As DataView

    Private Sub frmContractManagement_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If frmMain.statusText.Text.IndexOf("无法") = -1 Then frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub frmContractManagement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DB As New DataBase()
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打开""合同管理""窗口。请检查数据库连接。"
            Me.Close() : Return
        End If

        Dim dtCity As DataTable = Nothing
        Try
            If frmMain.sLoginAreaType = "S" Then
                dtCity = DB.GetDataTable("Select Rtrim(Ltrim(Isnull(C.AreaChineseName,'')+' '+Isnull(C.AreaEnglishName,''))) As AreaFullName From AreaList AS C Inner Join AreaList AS S On C.AreaID = S.ParentAreaID Where S.AreaID=" & frmMain.sLoginAreaID)
            Else
                Dim dvTemp As DataView = frmMain.dtLoginStructure.Copy.DefaultView
                dvTemp.RowFilter = "AreaType='C'"
                dvTemp.Sort = "SortCode"
                dtCity = dvTemp.ToTable(True, "AreaFullName")
                For Each drCity As DataRow In dtCity.Rows
                    drCity(0) = drCity(0).ToString.Substring(5)
                    drCity.AcceptChanges()
                Next
                dvTemp.Dispose() : dvTemp = Nothing
            End If
            sControllableBusinessTypes = DB.GetDataTable("Select ControllableBusinessTypes From UserList Where UserID=" & frmMain.sLoginUserID).Rows(0)(0).ToString

            If frmMain.sLoginAreaType = "S" Then
                If frmMain.sLoginRoleID = "14" Then
                    dvContract = DB.GetDataTable("Select * From ContractView Where CreatorID=" & frmMain.sLoginUserID).DefaultView
                ElseIf sControllableBusinessTypes = "All" Then
                    dvContract = DB.GetDataTable("Select * From ContractView Where StoreID=" & frmMain.sLoginAreaID).DefaultView
                Else
                    dvContract = DB.GetDataTable("Select * From ContractView Where StoreID=" & frmMain.sLoginAreaID & " And '" & sControllableBusinessTypes & "' Like '%|'+Convert(varchar(10),BusinessTypeID)+'|%'").DefaultView
                End If
            ElseIf frmMain.sLoginAreaType = "C" Then
                If sControllableBusinessTypes = "All" Then
                    dvContract = DB.GetDataTable("Select * From ContractView Where CityID=" & frmMain.sLoginAreaID).DefaultView
                Else
                    dvContract = DB.GetDataTable("Select * From ContractView Where CityID=" & frmMain.sLoginAreaID & " And '" & sControllableBusinessTypes & "' Like '%|'+Convert(varchar(10),BusinessTypeID)+'|%'").DefaultView
                End If
            Else
                If sControllableBusinessTypes = "All" Then
                    dvContract = DB.GetDataTable("Select C.* From ContractView AS C Join AreaScope(" & frmMain.sLoginUserID & ") AS S ON C.CityID=S.AreaID").DefaultView
                Else
                    dvContract = DB.GetDataTable("Select C.* From ContractView AS C Join AreaScope(" & frmMain.sLoginUserID & ") AS S ON C.CityID=S.AreaID And '" & sControllableBusinessTypes & "' Like '%|'+Convert(varchar(10),C.BusinessTypeID)+'|%'").DefaultView
                End If
            End If

            dvContract.Table.PrimaryKey = New DataColumn() {dvContract.Table.Columns("ContractID")}
            dvContract.Sort = "ContractCode"
        Catch
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开""合同管理""窗口。请联系软件开发人员。"
            DB.Close() : Me.Close() : Return
        End Try
        DB.Close()

        If dtCity.Rows.Count > 1 Then Me.cbbCity.Items.Add("（所有城市 All Cities）")
        For Each drCity As DataRow In dtCity.Rows
            Me.cbbCity.Items.Add(drCity(0).ToString)
        Next
        dtCity.Dispose() : dtCity = Nothing
        Me.cbbCity.SelectedIndex = 0
        If Me.cbbCity.Items.Count = 1 Then
            Me.Label2.Visible = False
            Me.cbbCity.Visible = False
        End If

        Me.cbbState.SelectedIndex = 0

        With Me.dgvList
            .DataSource = dvContract
            .Columns(0).Visible = False
            With .Columns(1)
                .HeaderText = "编号 Code"
                .Width = 85
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(2)
                .HeaderText = "客户名称 Customer Name"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
                .MinimumWidth = .Width
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            With .Columns(3)
                .HeaderText = "所属城市 City Belongs"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(4)
                .HeaderText = "Start Date"
                .DefaultCellStyle.Format = "yyyy\/MM\/dd"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 75
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(5)
                .HeaderText = "End Date"
                .DefaultCellStyle.Format = "yyyy\/MM\/dd"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 75
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(6)
                .HeaderText = "Stopped Date"
                .DefaultCellStyle.Format = "yyyy\/MM\/dd"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 75
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Visible = (dvContract.ToTable(False, "StoppedDate").Select("StoppedDate Is Not Null").Length > 0)
            End With
            With .Columns(7)
                .HeaderText = "Contract Days"
                .DefaultCellStyle.Format = "#,0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(8)
                .HeaderText = "返点方式 Discount Mode"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(9)
                .HeaderText = "计算方式 Calculation Mode"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(10)
                .HeaderText = "返点计算日 Calculation Date"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(11)
                .HeaderText = "Max Rate %"
                'modify code 038:start-------------------------------------------------------------------------
                '.DefaultCellStyle.Format = "#,0.0"
                .DefaultCellStyle.Format = "#,0.00"
                'modify code 038:end-------------------------------------------------------------------------
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(12)
                .HeaderText = "合同状态 Contract Status"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(13)
                .HeaderText = "Purchase Times"
                .DefaultCellStyle.Format = "#,0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(14)
                .HeaderText = "Purchase AMT"
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(15)
                .HeaderText = "Discount AMT"
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(16)
                .HeaderText = "AVG Discount %"
                'modify code 038:start-------------------------------------------------------------------------
                '.DefaultCellStyle.Format = "#,0.0"
                .DefaultCellStyle.Format = "#,0.00"
                'modify code 038:start-------------------------------------------------------------------------
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(17)
                .HeaderText = "Paid Discount AMT"
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(18)
                .HeaderText = "Balance Discount AMT"
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            .Columns(19).Visible = False
            .Columns(20).Visible = False
            .Columns(21).Visible = False
            .Columns(22).Visible = False
            .Columns(23).Visible = False
            .Columns(24).Visible = False
        End With
        For bColumn As Byte = 0 To dvContract.Table.Columns.Count - 1
            Me.dgvList.Columns(bColumn).Name = dvContract.Table.Columns(bColumn).ColumnName
        Next

        Me.btnAdd.Enabled = (frmMain.dtAllowedRight.Select("RightName='ContractCreate'").Length > 0)
        blCanDelete = (frmMain.dtAllowedRight.Select("RightName='ContractDelete'").Length > 0)
        If Me.dgvList.CurrentRow IsNot Nothing Then Me.dgvList.CurrentRow.Selected = False
        blSkipDeal = False
        If frmMain.sLoginRoleID = "15" Then '总部审核
            Me.cbbState.SelectedIndex = 3
        ElseIf frmMain.dtAllowedRight.Select("RightName='ContractValidate'").Length > 0 Then
            Me.cbbState.SelectedIndex = 1
        End If
        If Me.cbbState.SelectedIndex <> 0 AndAlso Me.dgvList.RowCount = 0 Then Me.cbbState.SelectedIndex = 0

        'If frmMain.sLoginRoleID = "15" Then '总部审核
        '    Me.cbbState.SelectedIndex = 3
        '    Me.Label3.Visible = False
        '    Me.cbbState.Visible = False
        'End If

        frmMain.statusText.Text = "共 " & Format(Me.dgvList.RowCount, "#,0") & " 张合同。"
        If Me.dgvList.RowCount > 0 Then Me.dgvList.Rows(0).Selected = True
    End Sub

    Private Sub cbbCity_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbCity.SelectedIndexChanged, cbbState.SelectedIndexChanged
        If blSkipDeal Then Return

        Dim sRowFilter As String = ""
        If Me.cbbCity.SelectedIndex <> 0 Then sRowFilter = "CityNameBelongs='" & Me.cbbCity.Text.Replace("'", "''") & "'"
        If Me.cbbState.SelectedIndex <> 0 Then
            If sRowFilter <> "" Then sRowFilter = sRowFilter & " And "
            sRowFilter = sRowFilter & "ContractStateDescription='" & Me.cbbState.Text & "'"
        End If
        dvContract.RowFilter = sRowFilter
        Me.dgvList.Columns("StoppedDate").Visible = (dvContract.ToTable(False, "StoppedDate").Select("StoppedDate Is Not Null").Length > 0)
        If Me.dgvList.CurrentRow Is Nothing AndAlso Me.dgvList.RowCount > 0 Then Me.dgvList(1, 0).Selected = True : Me.dgvList.Rows(0).Selected = True
        frmMain.statusText.Text = "共 " & Format(dvContract.Count, "#,0") & " 张合同。"
    End Sub

    Private Sub dgvList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvList.CellDoubleClick
        If e.RowIndex > -1 Then Me.btnOpen.PerformClick()
    End Sub

    Private Sub dgvList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvList.SelectionChanged
        If Me.dgvList.CurrentRow Is Nothing Then Return
        Me.btnOpen.Enabled = True : Me.btnDelete.Enabled = blCanDelete
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        Dim openingRow As DataRow = dvContract.Table.Rows.Find(Me.dgvList("ContractID", Me.dgvList.CurrentRow.Index).Value.ToString)

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在打开合同""" & openingRow("ContractCode").ToString & " " & openingRow("CustomerName").ToString & """……"
        frmMain.statusMain.Refresh()

        frmContract.sContractID = openingRow("ContractID").ToString
        frmContract.ShowDialog()
        frmContract.Dispose()

        openingRow = Nothing
        Me.dgvList.Select()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If frmMain.dtAllowedRight.Select("RightName='ContractCreate'").Length = 0 Then
            MessageBox.Show("对不起，您无权限创建新合同。    " & Chr(13) & _
                            "Sorry, you have no right to create new Contract.    ", "无权限创建合同 No right to create Contract!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'frmMain.menuNewContract.Enabled = True
            Me.btnAdd.Enabled = False : Return
        End If

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在打开合同窗口……"
        frmMain.statusMain.Refresh()

        frmContract.ShowDialog()
        frmContract.Dispose()

        Me.dgvList.Select()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If frmMain.dtAllowedRight.Select("RightName='ContractDelete'").Length = 0 Then
            MessageBox.Show("对不起，您无权限删除合同。    " & Chr(13) & _
                            "Sorry, you have no right to delete Contract.    ", "无权限删除合同 No right to delete Contract!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            blCanDelete = False
            Me.btnDelete.Enabled = False : Return
        End If

        Dim deletingRow As DataRow = dvContract.Table.Rows.Find(Me.dgvList("ContractID", Me.dgvList.CurrentRow.Index).Value.ToString)
        If "|2|4|5|".IndexOf("|" & deletingRow("ContractState").ToString & "|") > -1 Then
            MessageBox.Show("该合同已审核，再也不能删除！    " & Chr(13) & "You can not delete this Contract since it had been validated.    ", "不能删除已审核合同 The Contract can not be delete when validated!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.btnDelete.Enabled = False : deletingRow = Nothing : Return
        End If

        If deletingRow("ContractStateDescription").ToString.IndexOf("已过期") = -1 AndAlso _
           MessageBox.Show("您真的想要删除该合同吗？    " & Chr(13) & "Do you realy want to delete this contract?    " & Chr(13) & Chr(13) & _
                           "合同号： " & deletingRow("ContractCode").ToString & Chr(13) & _
                           "客户名： " & deletingRow("CustomerName").ToString & Chr(13) & _
                           "合同期： " & Format(deletingRow("StartDate"), "yyyy\/MM\/dd") & " - " & Format(deletingRow("EndDate"), "yyyy\/MM\/dd"), _
                           "请确认删除合同 Please confirm to delete contract:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            deletingRow = Nothing : Return
        End If


        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在删除合同""" & deletingRow("ContractCode").ToString & " " & deletingRow("CustomerName").ToString & """……"
        frmMain.statusMain.Refresh()

        Dim DB As New DataBase()
        DB.Open()
        If DB.IsConnected Then
            Dim dtResult As DataTable = DB.GetDataTable("Exec ContractDeletion " & deletingRow("ContractID").ToString & "," & frmMain.sSSID)
            If dtResult Is Nothing Then
                frmMain.statusText.Text = "系统因在检索数据时出错而无法删除合同。请联系软件开发人员。"
                deletingRow = Nothing
            Else
                Select Case dtResult.Rows(0)(0).ToString
                    Case "AlreadyDeleted"
                        MessageBox.Show("该合同已被其他用户删除。 The Contract had been deleted by someone else.    ", "合同已被他人删除！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        frmMain.statusText.Text = "该合同已被其他用户删除。"
                    Case "AlreadyValidated"
                        MessageBox.Show("该合同已审核，再也不能删除！    " & Chr(13) & "You can not delete this Contract since it had been validated.    ", "不能删除已审核合同 The Contract can not be delete when validated!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        deletingRow("ContractStateDescription") = dtResult.Rows(0)("ContractStateDescription") : deletingRow("ContractState") = dtResult.Rows(0)("ContractState") : deletingRow.AcceptChanges()
                        If frmCustomerManagement.IsHandleCreated AndAlso deletingRow("ContractStateDescription").ToString = "'已审核且已生效 Validated and effective'" Then
                            Try
                                Dim customer As DataRow = frmCustomerManagement.dvCustomer.Table.Rows.Find(deletingRow("CustomerID").ToString)
                                If customer("InvalidContractID").ToString = deletingRow("ContractID").ToString Then
                                    customer("ValidContractID") = deletingRow("ContractID")
                                    customer("ValidContractCode") = deletingRow("ContractCode")
                                    customer("InvalidContractID") = DBNull.Value
                                    customer("InvalidContractCode") = DBNull.Value
                                    customer.AcceptChanges() : customer = Nothing
                                    If frmCustomerManagement.dgvList.CurrentRow IsNot Nothing Then
                                        frmCustomerManagement.dgvList.CurrentRow.Selected = False
                                        frmCustomerManagement.dgvList.CurrentRow.Selected = True
                                    End If
                                End If
                            Catch
                            End Try
                        End If
                        Me.btnDelete.Enabled = False : deletingRow = Nothing
                        frmMain.statusText.Text = "该合同已被审核，再也不能删除！"
                    Case "OK"
                        frmMain.statusText.Text = "删除合同成功。"
                    Case Else
                        MessageBox.Show("删除合同时出现错误！下面是数据库的内部错误提示：    " & Chr(13) & Chr(13) & dtResult.Rows(0)("Reason").ToString & Space(4) & Chr(13) & Chr(13) & "请放弃删除，在关闭窗口后重试。如果仍有问题，请联系软件开发人员。    ", "删除合同失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        deletingRow = Nothing
                        frmMain.statusText.Text = "删除合同失败！"
                End Select
                dtResult.Dispose() : dtResult = Nothing
            End If
        Else
            frmMain.statusText.Text = "系统因连接不到数据库而无法删除合同。请检查数据库连接。"
        End If

        DB.Close()
        If deletingRow IsNot Nothing Then
            If frmCustomerManagement.IsHandleCreated Then
                Try
                    Dim customer As DataRow = frmCustomerManagement.dvCustomer.Table.Rows.Find(deletingRow("CustomerID").ToString)
                    If customer("InvalidContractID").ToString = deletingRow("ContractID").ToString Then
                        customer("ContractCount") = customer("ContractCount") - 1
                        customer("InvalidContractID") = DBNull.Value
                        customer("InvalidContractCode") = DBNull.Value
                        customer.AcceptChanges() : customer = Nothing
                        If frmCustomerManagement.dgvList.CurrentRow IsNot Nothing Then
                            frmCustomerManagement.dgvList.CurrentRow.Selected = False
                            frmCustomerManagement.dgvList.CurrentRow.Selected = True
                        End If
                    End If
                Catch
                End Try
            End If
            deletingRow.Delete() : deletingRow.AcceptChanges() : deletingRow = Nothing
        End If

        If Me.dgvList.CurrentRow IsNot Nothing Then
            Me.dgvList.CurrentRow.Selected = True
        Else
            Me.btnOpen.Enabled = False : Me.btnDelete.Enabled = False
        End If
        Me.dgvList.Select()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        frmSearchContract.ShowDialog()
        frmSearchContract.Dispose()
    End Sub
End Class