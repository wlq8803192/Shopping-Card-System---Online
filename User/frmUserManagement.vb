Imports System.Runtime.InteropServices

Public Class frmUserManagerment
    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=False)> _
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Int16, ByVal wParam As Int16, ByVal lParam As Int16) As IntPtr
        '让滚动条始终处在左边
    End Function

    Private dvRole As DataView, dvState As DataView
    Private blSkipDeal As Boolean = True, blFirstLoad As Boolean = True, blCanDelete As Boolean = True, sLocationType As String = "", sControllableRoles As String = "", sLocationIDs As String = ""
    Public dvUser As DataView

    Private Sub frmUserManagerment_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If blFirstLoad Then
            Me.trvArea.ExpandAll()
            Me.trvArea.Nodes(0).EnsureVisible()
            blFirstLoad = False
        End If
        If frmMain.sLoginAreaType <> "S" Then SendMessage(Me.trvArea.Handle, 276, 6, 0)
    End Sub

    Private Sub frmUserManagerment_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If frmMain.statusText.Text.IndexOf("无法") = -1 Then frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub frmUserManagerment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DB As New DataBase()
        DB.Open(True)
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打开""用户管理""窗口。请检查数据库连接。"
            Me.Close() : Return
        End If

        Try
            dvUser = DB.GetDataTable("Select U.* From UserView As U Join AreaScope(" & frmMain.sLoginUserID & ") As S On U.LocationID=S.AreaID").DefaultView
            dvRole = DB.GetDataTable("Select RoleID,RoleCode,Rtrim(Ltrim(Isnull(RoleChineseName,'')+' '+Isnull(RoleEnglishName,''))) As RoleName,AcceptAreas,ControllableRoles From RoleList").DefaultView
        Catch
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开""用户管理""窗口。请联系软件开发人员。"
            DB.Close() : Me.Close() : Return
        End Try
        DB.Close()

        dvUser.Table.PrimaryKey = New DataColumn() {dvUser.Table.Columns("UserID")}
        dvUser.Sort = "SortCode,UserCode"
        dvUser.RowFilter = "1=2"
        With Me.dgvList
            .DataSource = dvUser
            .Columns(0).Visible = False
            With .Columns(1)
                .HeaderText = "编号 Code"
                .Width = 85
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(2)
                .HeaderText = "登录名称 Login Name"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(3)
                .HeaderText = "位置 Location"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(4)
                .HeaderText = "职位 Position"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(5)
                .HeaderText = "Chinese Name"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(6)
                .HeaderText = "English Name"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(7)
                .HeaderText = "Need Reset?"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(8)
                .HeaderText = "Login Times"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,0"
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(9)
                .HeaderText = "Last Login"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Format = "yyyy\/MM\/dd HH:mm:ss"
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            With .Columns(10)
                .HeaderText = "状态 State"
                .MinimumWidth = 110
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With
            .Columns(11).Visible = False
            .Columns(12).Visible = False
            .Columns(13).Visible = False
            .Columns(14).Visible = False
            .Columns(15).Visible = False
        End With
        dvUser.RowFilter = ""

        Dim role As DataRowView = dvRole.AddNew()
        role("RoleID") = 255
        role("RoleCode") = ""
        role("RoleName") = "(所有职位 All Positions)"
        role("AcceptAreas") = "|H|T|R|C|S|"
        role.EndEdit() : role.Row.AcceptChanges() : role = Nothing
        dvRole.Sort = "RoleCode"
        With Me.cbbRole
            .DataSource = dvRole
            .ValueMember = "RoleID"
            .DisplayMember = "RoleName"
            .SelectedIndex = 0
        End With

        sControllableRoles = dvRole.Table.Select("RoleID=" & frmMain.sLoginRoleID)(0)("ControllableRoles").ToString
        Me.cbbState.SelectedIndex = 0
        Me.InitArea(Me.trvArea.Nodes, frmMain.dtLoginStructure.Rows(0)("ParentAreaID").ToString)
        Me.trvArea.ExpandAll()
        Me.trvArea.SelectedNode = Nothing
        blSkipDeal = False
        Me.trvArea.SelectedNode = Me.trvArea.Nodes(0)
        Me.trvArea.SelectedNode.EnsureVisible()
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

        Me.btnAdd.Enabled = (frmMain.dtAllowedRight.Select("RightName='UserCreate'").Length > 0 AndAlso sControllableRoles <> "")
        blCanDelete = (frmMain.dtAllowedRight.Select("RightName Like 'UserDelete%'").Length > 0)
        Me.btnDelete.Enabled = blCanDelete
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

    Private Sub GetChildLocation(ByVal sParentID As String)
        For Each dr As DataRow In frmMain.dtLoginStructure.Select("ParentAreaID=" & sParentID, "SortCode")
            sLocationIDs = sLocationIDs & "," & dr("AreaID").ToString
            Me.GetChildLocation(dr("AreaID").ToString)
        Next
    End Sub

    Private Sub Split_SplitterMoved(ByVal sender As Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles Split.SplitterMoved
        Me.trvArea.Select()
    End Sub

    Private Sub trvArea_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvArea.AfterSelect
        Dim sRowFilter As String = ""
        If Me.chbIncludeDown.Checked Then
            If Not Me.trvArea.SelectedNode.Equals(Me.trvArea.Nodes(0)) Then
                sLocationIDs = Me.trvArea.SelectedNode.Name
                Me.GetChildLocation(sLocationIDs)
                sRowFilter = "LocationID In (" & sLocationIDs & ")"
            End If
        Else
            sRowFilter = "LocationID=" & Me.trvArea.SelectedNode.Name
        End If
        blSkipDeal = True
        If sLocationType = Me.trvArea.SelectedNode.ImageKey Then
            If Me.cbbRole.SelectedValue.ToString <> "255" Then sRowFilter = IIf(sRowFilter = "", "", sRowFilter & " And ") & "RoleID=" & Me.cbbRole.SelectedValue.ToString
        Else
            sLocationType = Me.trvArea.SelectedNode.ImageKey
            If Me.chbIncludeDown.Checked Then
                Select Case sLocationType
                    Case "H"
                        dvRole.RowFilter = ""
                    Case "T"
                        dvRole.RowFilter = "(AcceptAreas Like '%|T|%') Or (AcceptAreas Like '%|R|%') Or (AcceptAreas Like '%|C|%') Or (AcceptAreas Like '%|S|%')"
                    Case "R"
                        dvRole.RowFilter = "(AcceptAreas Like '%|R|%') Or (AcceptAreas Like '%|C|%') Or (AcceptAreas Like '%|S|%')"
                    Case "C"
                        dvRole.RowFilter = "(AcceptAreas Like '%|C|%') Or (AcceptAreas Like '%|S|%')"
                    Case Else
                        dvRole.RowFilter = "(AcceptAreas Like '%|S|%')"
                End Select
            Else
                dvRole.RowFilter = "AcceptAreas Like '%|" & sLocationType & "|%'"
            End If
            Me.cbbRole.SelectedIndex = 0
        End If
        If Me.cbbState.SelectedIndex <> 0 Then
            sRowFilter = IIf(sRowFilter = "", "", sRowFilter & " And ") & "StateDescription='" & Me.cbbState.Text & "'"
        End If

        Me.btnOpen.Enabled = False : Me.btnDelete.Enabled = False
        dvUser.RowFilter = sRowFilter
        dvUser.Sort = "SortCode"
        Me.dgvList.Columns("NeedResetPassword").Visible = (dvUser.ToTable.Compute("Count(UserID)", "NeedResetPassword='Yes'") > 0)
        blSkipDeal = False
        If Me.dgvList.RowCount > 0 Then Me.dgvList(1, 0).Selected = True : Me.dgvList.Rows(0).Selected = False : Me.dgvList.Rows(0).Selected = True
        frmMain.statusText.Text = "共 " & Format(dvUser.Count, "#,0") & " 个用户。"
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

    Private Sub chbIncludeDown_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbIncludeDown.CheckedChanged
        sLocationType = ""
        Dim currentNode As TreeNode = Me.trvArea.SelectedNode
        Me.trvArea.SelectedNode = Nothing
        Me.trvArea.SelectedNode = currentNode
    End Sub

    Private Sub lblIncludeDown1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblIncludeDown1.Click, lblIncludeDown2.Click
        Me.chbIncludeDown.Checked = Not Me.chbIncludeDown.Checked
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        frmSearchUser.ShowDialog()
        frmSearchUser.Dispose()
    End Sub

    Private Sub cbbRole_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbRole.SelectedIndexChanged, cbbState.SelectedIndexChanged
        If blSkipDeal Then Return
        Dim currentNode As TreeNode = Me.trvArea.SelectedNode
        Me.trvArea.SelectedNode = Nothing
        Me.trvArea.SelectedNode = currentNode
    End Sub

    Private Sub dgvList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvList.CellDoubleClick
        If e.RowIndex > -1 Then Me.btnOpen.PerformClick()
    End Sub

    Private Sub dgvList_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvList.ColumnHeaderMouseClick
        If Not Me.dgvList.Columns(e.ColumnIndex).Frozen Then Me.dgvList.FirstDisplayedScrollingColumnIndex = e.ColumnIndex
    End Sub

    Private Sub dgvList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvList.SelectionChanged
        If blSkipDeal Then Return
        If Me.dgvList.CurrentRow Is Nothing Then Return
        If Me.dgvList("UserID", Me.dgvList.CurrentRow.Index).Value.ToString <> "" Then
            Dim currentRow As DataRow = dvUser.Table.Rows.Find(Me.dgvList("UserID", Me.dgvList.CurrentRow.Index).Value.ToString)
            If currentRow("UserID").ToString <> frmMain.sLoginUserID AndAlso sControllableRoles.IndexOf("|" & currentRow("RoleID").ToString & "|") = -1 Then
                Me.btnOpen.Enabled = False
            Else
                Me.btnOpen.Enabled = True
            End If
            currentRow = Nothing
        End If
        Me.btnDelete.Enabled = blCanDelete
        If frmMain.statusText.Text.IndexOf("个用户") = -1 Then frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        Dim openingRow As DataRow = dvUser.Table.Rows.Find(Me.dgvList("UserID", Me.dgvList.CurrentRow.Index).Value.ToString)
        If openingRow("UserID").ToString <> frmMain.sLoginUserID AndAlso sControllableRoles.IndexOf("|" & openingRow("RoleID").ToString & "|") = -1 Then
            MessageBox.Show("对不起，您无权限打开该用户。    " & Chr(13) & _
                            "Sorry, you have no the right to open this user.    ", "无权限打开用户 No right to open user!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.btnOpen.Enabled = False : openingRow = Nothing : Return
        End If

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在打开用户""" & openingRow("UserCode").ToString & " " & openingRow("LoginName").ToString & """……"
        frmMain.statusMain.Refresh()

        frmUser.sUserID = openingRow("UserID").ToString
        frmUser.ShowDialog()
        frmUser.Dispose()

        openingRow = Nothing
        Me.dgvList.Select()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If frmMain.dtAllowedRight.Select("RightName='UserCreate'").Length = 0 OrElse sControllableRoles = "" Then
            MessageBox.Show("对不起，您无权限创建新用户。    " & Chr(13) & _
                            "Sorry, you have no right to create new user.    ", "无权限创建用户 No right to create user!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'frmMain.menuNewUser.Enabled = False
            Me.btnAdd.Enabled = False : Return
        End If

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在打开用户窗口……"
        frmMain.statusMain.Refresh()

        frmUser.ShowDialog()
        frmUser.Dispose()

        Me.dgvList.Select()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim deletingRow As DataRow = dvUser.Table.Rows.Find(Me.dgvList("UserID", Me.dgvList.CurrentRow.Index).Value.ToString)
        If frmMain.dtAllowedRight.Select("RightName Like 'UserDelete%'").Length = 0 OrElse sControllableRoles.IndexOf("|" & deletingRow("RoleID").ToString & "|") = -1 Then
            MessageBox.Show("对不起，您无权限删除用户。    " & Chr(13) & _
                            "Sorry, you have no right to delete user.    ", "无权限删除用户 No right to delete user!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            blCanDelete = False
            Me.btnDelete.Enabled = False : deletingRow = Nothing : Return
        End If

        If deletingRow("IsLogin") Then
            MessageBox.Show("该用户已被使用（登录过系统），再也不能删除！    " & Chr(13) & _
                            "You can not delete this user since it had been used to login system.    " & Chr(13) & Chr(13) & _
                            "如果您不想让该用户继续使用本系统，可以停用该用户。    " & Chr(13) & _
                            "Please block this user if you don't want let this user to login system again.    ", "不能删除该用户 The user can not be delete!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.btnDelete.Enabled = False : deletingRow = Nothing : Return
        End If

        If deletingRow("UserState") = 0 Then
            If frmMain.dtAllowedRight.Select("RightName='UserDeleteBefore'").Length = 0 Then
                MessageBox.Show("该用户未审核，您无权限删除未审核的用户。    " & Chr(13) & "You have no right to delete user before validation.    ", "无权限删除未审核用户 No right to delete user before validation!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.btnDelete.Enabled = False : deletingRow = Nothing : Return
            End If
        Else
            If frmMain.dtAllowedRight.Select("RightName='UserDeleteAfter'").Length = 0 Then
                MessageBox.Show("该用户已审核，您无权限删除已审核的用户。    " & Chr(13) & "You have no right to delete user after validation.    ", "无权限删除已审核用户 No right to delete user after validation!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.btnDelete.Enabled = False : deletingRow = Nothing : Return
            End If
        End If

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在删除用户""" & deletingRow("UserCode").ToString & " " & deletingRow("LoginName").ToString & """……"
        frmMain.statusMain.Refresh()

        Dim DB As New DataBase()
        DB.Open(True)
        If DB.IsConnected Then
            Dim dtResult As DataTable = DB.GetDataTable("Exec UserDeletion " & deletingRow("UserID").ToString & "," & frmMain.sSSID)
            If dtResult Is Nothing Then
                frmMain.statusText.Text = "系统因在检索数据时出错而无法删除用户。请联系软件开发人员。"
            Else
                Select Case dtResult.Rows(0)(0).ToString
                    Case "AlreadyDeleted"
                        MessageBox.Show("该用户已被其他用户删除。 The user had been deleted by someone else.    ", "用户已被他人删除！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        deletingRow.Delete() : deletingRow.AcceptChanges()
                        frmMain.statusText.Text = "该用户已被其他用户删除。"
                    Case "AlreadyLogin"
                        MessageBox.Show("该用户已被使用（登录过系统），再也不能删除！    " & Chr(13) & _
                           "You can not delete this user since it had been used to login system.    " & Chr(13) & Chr(13) & _
                           "如果您不想让该用户继续使用本系统，可以停用该用户。    " & Chr(13) & _
                           "Please block this user if you don't want let this user to login system again.    ", "不能删除该用户 The user can not be delete!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        deletingRow("IsLogin") = 1 : deletingRow.AcceptChanges()
                        Me.btnDelete.Enabled = False
                        frmMain.statusText.Text = "该用户已被使用（登录过系统），再也不能删除！"
                    Case "OK"
                        deletingRow.Delete() : deletingRow.AcceptChanges()
                        frmMain.statusText.Text = "删除用户成功。"
                    Case Else
                        MessageBox.Show("删除用户时出现错误！下面是数据库的内部错误提示：    " & Chr(13) & Chr(13) & dtResult.Rows(0)("Reason").ToString & Space(4) & Chr(13) & Chr(13) & "请放弃删除，在关闭窗口后重试。如果仍有问题，请联系软件开发人员。    ", "删除用户失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        frmMain.statusText.Text = "删除用户失败！"
                End Select
                dtResult.Dispose() : dtResult = Nothing
            End If
        Else
            frmMain.statusText.Text = "系统因连接不到数据库而无法删除用户。请检查数据库连接。"
        End If

        DB.Close() : deletingRow = Nothing
        If Me.dgvList.CurrentRow IsNot Nothing Then
            Me.dgvList.CurrentRow.Selected = True
        Else
            Me.btnOpen.Enabled = False : Me.btnDelete.Enabled = False
        End If
        Me.dgvList.Select()
        Me.Cursor = Cursors.Default
    End Sub
End Class