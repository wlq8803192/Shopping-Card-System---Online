Imports System.Runtime.InteropServices

Public Class frmPosition
    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=False)> _
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Int16, ByVal wParam As Int16, ByVal lParam As Int16) As IntPtr
        '让滚动条始终处在左边
    End Function

    Private dtRole As DataTable, dtRight As DataTable, dvRoleRight As DataView
    Private sRoleID As String = "0", blIsReadOnly As Boolean = False, blSkipDeal As Boolean = True, sOldName As String = "", blNeedResetRoleList As Boolean = True

    Private Sub frmRole_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Enter
        If VisualStyles.VisualStyleInformation.IsSupportedByOS AndAlso VisualStyles.VisualStyleInformation.IsEnabledByUser Then
            If Not Me.imlXP.Equals(Me.trvRight.ImageList) Then Me.trvRight.ImageList = Me.imlXP
        Else
            If Not Me.imlCS.Equals(Me.trvRight.ImageList) Then Me.trvRight.ImageList = Me.imlCS
        End If
        Me.trvRight.ExpandAll()
        If Me.trvRight.SelectedNode Is Nothing Then Me.trvRight.SelectedNode = Me.trvRight.Nodes(0)
        Me.trvRight.SelectedNode.EnsureVisible()
        SendMessage(Me.trvRight.Handle, 276, 6, 0)
    End Sub

    Private Sub frmRole_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.btnSave.Enabled Then
            Me.btnSave.Select()
            blSkipDeal = True
            Me.dgvRole.CurrentRow.Selected = True
            blSkipDeal = False
            Dim bAnswer As Windows.Forms.DialogResult = MessageBox.Show("当前窗口内容已更改，但未保存。    " & Chr(13) & Chr(13) & "是否在关闭窗口前保存这些更改？    " & Chr(13) & Chr(13) & "   是    -   保存更改并退出" & Chr(13) & "   否    -   放弃更改并退出" & Chr(13) & "  取消   -   取消关闭", "请确认保存更改：", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

            If bAnswer = Windows.Forms.DialogResult.Yes Then
                If Me.SaveChanges Then Me.Dispose() Else e.Cancel = True
            ElseIf bAnswer = Windows.Forms.DialogResult.No Then
                Me.Dispose()
            Else
                e.Cancel = True
            End If
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub frmRole_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DB As New DataBase()
        DB.Open(True)
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打开窗口。请检查数据库连接。"
            Me.Close() : Return
        End If

        dtRole = DB.GetDataTable("Select * From RoleList Order By RoleCode")
        If dtRole Is Nothing Then
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开窗口。请联系软件开发人员。"
            DB.Close() : Me.Close() : Return
        End If

        dtRight = DB.GetDataTable("Select * From RightList Order By RightID")
        Try
            dtRight.Select("RightName='SalesBillRecharge'")(0).Delete()
            dtRight.Select("RightName='TransferCard'")(0).Delete()
            dtRight.Select("RightName='AffirmTransferCard'")(0).Delete()
            dtRight.AcceptChanges()
        Catch
        End Try

        If dtRole Is Nothing Then
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开窗口。请联系软件开发人员。"
            DB.Close() : Me.Close() : Return
        End If

        Try
            dvRoleRight = DB.GetDataTable("Select * From RoleRight").DefaultView
        Catch
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开窗口。请联系软件开发人员。"
            DB.Close() : Me.Close() : Return
        End Try

        DB.Close()

        Me.FillRight(Me.trvRight.Nodes, "255")
        Me.trvRight.ExpandAll()
        Me.trvRight.SelectedNode = Me.trvRight.Nodes(0)
        Me.trvRight.SelectedNode.EnsureVisible()

        With Me.dgvRole
            .DataSource = dtRole
            .Columns(0).Visible = False
            With .Columns(1)
                .HeaderText = "Code"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.ForeColor = SystemColors.ControlText
                .DefaultCellStyle.SelectionForeColor = SystemColors.ControlText
                .DefaultCellStyle.BackColor = SystemColors.Control
                .DefaultCellStyle.SelectionBackColor = SystemColors.Control
                .ReadOnly = True
                .Width = 35
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With
            With .Columns(2)
                .HeaderText = "Chinese Name"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Resizable = DataGridViewTriState.True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns(3)
                .HeaderText = "English Name"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            .Columns(4).Visible = False
            .Columns(5).Visible = False
            .Columns(6).Visible = False
        End With
        If Me.dgvRole.CurrentRow IsNot Nothing Then Me.dgvRole.CurrentRow.Selected = False
        blSkipDeal = False
        Me.dgvRole.Rows(0).Selected = True

        blIsReadOnly = (frmMain.dtAllowedRight.Select("RightName='RoleMaintance'").Length = 0)

        Me.btnAdd.Enabled = Not blIsReadOnly
        Me.cklArea.CheckOnClick = Not blIsReadOnly
        Me.cklRole.CheckOnClick = Not blIsReadOnly
        If blIsReadOnly Then Me.Text = Me.Text & " (只读 Readonly)"
    End Sub

    Private Sub dgvRole_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvRole.CellBeginEdit
        If e.RowIndex = 0 Then
            If e.ColumnIndex = 2 Then
                frmMain.statusText.Text = "系统管理员是系统内置角色，不可修改名称。"
            Else
                frmMain.statusText.Text = "You can not change the name since ""Administrator"" is the system's built-in role!"
            End If
            frmMain.statusMain.Refresh()
            e.Cancel = True
        ElseIf blIsReadOnly Then
            If e.ColumnIndex = 2 Then
                frmMain.statusText.Text = "您无权修改名称。"
            Else
                frmMain.statusText.Text = "You can not change the name since you have no authority!"
            End If
            frmMain.statusMain.Refresh()
            e.Cancel = True
        Else
            frmMain.statusText.Text = "就绪。"
            Me.dgvRole.CurrentRow.Selected = False
        End If
    End Sub

    Private Sub dgvRole_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRole.CellDoubleClick
        If e.ColumnIndex > 1 AndAlso Me.dgvRole.CurrentCell.ColumnIndex = e.ColumnIndex AndAlso Me.dgvRole.CurrentCell.RowIndex = e.RowIndex Then
            Me.dgvRole.BeginEdit(True)
        End If
    End Sub

    Private Sub dgvRole_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvRole.CellFormatting
        If e.RowIndex = 0 Then
            e.CellStyle.BackColor = SystemColors.Control
        End If
    End Sub

    Private Sub dgvRole_CellMouseEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRole.CellMouseEnter
        If Not blIsReadOnly AndAlso e.RowIndex > 0 Then
            If e.ColumnIndex = 2 Then
                frmMain.statusText.Text = "双击该单元格可修改该名称。"
            ElseIf e.ColumnIndex = 3 Then
                frmMain.statusText.Text = "Double-click this cell to change the name."
            Else
                frmMain.statusText.Text = "就绪。"
            End If
        End If
    End Sub

    Private Sub dgvRole_CellParsing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellParsingEventArgs) Handles dgvRole.CellParsing
        Dim sName As String = e.Value.ToString.Trim
        If sName = "" Then
            e.Value = sOldName : e.ParsingApplied = True : Return
        ElseIf sName <> e.Value.ToString Then
            e.Value = sName : e.ParsingApplied = True
        End If
        If sName = sOldName Then Return
        If e.ColumnIndex = 2 Then
            If dtRole.Select("RoleChineseName='" & sName.Replace("'", "''") & "'").Length > 0 Then
                MessageBox.Show("该名称已经存在！该次修改无效。    ", "名称重复！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                e.Value = sOldName : e.ParsingApplied = True : Return
            End If
        Else
            If dtRole.Select("RoleEnglishName='" & sName.Replace("'", "''") & "'").Length > 0 Then
                MessageBox.Show("No effective for this modification since this name is already existing!    ", "Name Repeated!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                e.Value = sOldName : e.ParsingApplied = True : Return
            End If
        End If
        blNeedResetRoleList = True
        Me.btnSave.Enabled = True
    End Sub

    Private Sub dgvRole_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvRole.EditingControlShowing
        sOldName = Me.dgvRole.CurrentCell.Value.ToString
        Dim editingTextBox As TextBox = CType(Me.dgvRole.EditingControl, TextBox)
        If Me.dgvRole.CurrentCell.ColumnIndex = 2 Then
            editingTextBox.ImeMode = Windows.Forms.ImeMode.NoControl
        Else
            editingTextBox.ImeMode = Windows.Forms.ImeMode.Disable
        End If
        editingTextBox.MaxLength = 50
    End Sub

    Private Sub dgvRole_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvRole.Leave
        blSkipDeal = True
        Me.dgvRole.CurrentRow.Selected = True
        blSkipDeal = False
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub dgvRole_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvRole.MouseMove
        If Not blIsReadOnly AndAlso Me.dgvRole.HitTest(Me.dgvRole.PointToClient(Control.MousePosition).X, Me.dgvRole.PointToClient(Control.MousePosition).Y).RowIndex < 1 Then
            frmMain.statusText.Text = "就绪。"
        End If
    End Sub

    Private Sub dgvRole_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvRole.SelectionChanged
        If blSkipDeal Then Return
        sRoleID = Me.dgvRole("RoleID", Me.dgvRole.CurrentRow.Index).Value.ToString
        Me.SetAcceptAreas()
        Me.SetControllableRoles()
        Me.SetRightAllowed()
        If Not blIsReadOnly Then
            Me.btnDelete.Enabled = (sRoleID <> "0")
            Me.btnUp.Enabled = (Me.dgvRole.CurrentRow.Index > 1)
            Me.btnDown.Enabled = (Me.dgvRole.CurrentRow.Index <> 0 AndAlso Me.dgvRole.CurrentRow.Index <> Me.dgvRole.RowCount - 1)
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        blSkipDeal = True
        Dim newRole As DataRow = dtRole.Rows.Add(), sName As String = "新角色", bNo As Byte = 0
        sRoleID = (dtRole.Compute("Max(RoleID)", "") + 1).ToString
        If sRoleID = "255" Then
            sRoleID = "1"
            Do While dtRole.Select("RoleID=" & sRoleID).Length > 0
                sRoleID = (CByte(sRoleID) + 1).ToString
            Loop
        End If
        newRole("RoleID") = sRoleID
        newRole("RoleCode") = Format(Me.dgvRole.RowCount - 1, "00")
        newRole("UserQTY") = 0
        Do While dtRole.Select("RoleChineseName='" & sName & "'").Length > 0
            bNo += 1
            sName = "新角色 (" & bNo.ToString & ")"
        Loop
        newRole("RoleChineseName") = sName
        sName = "New Role" : bNo = 0
        Do While dtRole.Select("RoleEnglishName='" & sName & "'").Length > 0
            bNo += 1
            sName = "New Role (" & bNo.ToString & ")"
        Loop
        newRole("RoleEnglishName") = sName
        newRole.EndEdit()
        If Me.dgvRole.RowCount = 100 Then Me.btnAdd.Enabled = False
        Me.btnDelete.Enabled = True
        Me.btnUp.Enabled = (Me.dgvRole.RowCount > 2)
        Me.btnDown.Enabled = False
        Me.CheckChanges()
        blNeedResetRoleList = True
        blSkipDeal = False
        Me.dgvRole.Select()
        Me.dgvRole(2, Me.dgvRole.RowCount - 1).Selected = True
        Me.dgvRole.BeginEdit(True)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim currentRole As DataRow = dtRole.Select("RoleID=" & sRoleID)(0)
        If currentRole("UserQTY") > 0 Then
            MessageBox.Show("当前角色已被使用，不能删除该角色！    " & Chr(13) & Chr(13) & "请将使用该角色的所有用户改成其他角色，然后再尝试删除该角色。    ", "不能删除角色！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.btnDelete.Enabled = False
        Else
            dvRoleRight.RowFilter = "RoleID=" & sRoleID
            For Each dr As DataRowView In dvRoleRight
                dr.Delete()
            Next
            For Each dr As DataRow In dtRole.Select("RoleCode>'" & currentRole("RoleCode").ToString & "'")
                dr("RoleCode") = Format(CByte(dr("RoleCode").ToString) - 1, "00")
            Next
            For Each dr As DataRow In dtRole.Select("ControllableRoles Like '%|" & sRoleID & "|%'")
                dr("ControllableRoles") = dr("ControllableRoles").ToString.Replace("|" & sRoleID & "|", "|")
            Next
            currentRole.Delete()
            currentRole.EndEdit()
            If Me.dgvRole.CurrentRow Is Nothing OrElse Me.dgvRole.CurrentRow.Index = 0 Then Me.dgvRole.Rows(Me.dgvRole.RowCount - 1).Selected = True
            Me.dgvRole.CurrentRow.Selected = True
            Me.CheckChanges()
            blNeedResetRoleList = True
        End If
        Me.dgvRole.Select()
    End Sub

    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
        Dim bRowIndex As Byte = Me.dgvRole.CurrentRow.Index, sPreviousRoleID As String = Me.dgvRole("RoleID", bRowIndex - 1).Value.ToString, sRoleCode As String = Me.dgvRole("RoleCode", bRowIndex).Value.ToString
        dtRole.Select("RoleID=" & sRoleID)(0)("RoleCode") = Format(CByte(sRoleCode) - 1, "00")
        dtRole.Select("RoleID=" & sPreviousRoleID)(0)("RoleCode") = sRoleCode
        blSkipDeal = True
        Me.dgvRole.Sort(Me.dgvRole.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
        Me.dgvRole(1, bRowIndex - 1).Selected = True
        Me.dgvRole.Rows(bRowIndex - 1).Selected = True
        Me.btnDown.Enabled = True
        blSkipDeal = False
        Me.CheckChanges()
        blNeedResetRoleList = True
        Me.dgvRole.Select()
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        Dim bRowIndex As Byte = Me.dgvRole.CurrentRow.Index, sNextRoleID As String = Me.dgvRole("RoleID", bRowIndex + 1).Value.ToString, sRoleCode As String = Me.dgvRole("RoleCode", bRowIndex).Value.ToString
        dtRole.Select("RoleID=" & sRoleID)(0)("RoleCode") = Format(CByte(sRoleCode) + 1, "00")
        dtRole.Select("RoleID=" & sNextRoleID)(0)("RoleCode") = sRoleCode
        blSkipDeal = True
        Me.dgvRole.Sort(Me.dgvRole.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
        Me.dgvRole(1, bRowIndex + 1).Selected = True
        Me.dgvRole.Rows(bRowIndex + 1).Selected = True
        Me.btnUp.Enabled = True
        blSkipDeal = False
        Me.CheckChanges()
        blNeedResetRoleList = True
        Me.dgvRole.Select()
    End Sub

    Private Sub cbbArea_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbArea.DropDown
        If blSkipDeal Then Return
        blSkipDeal = True
        Me.cbbArea.DroppedDown = True
        If Me.cklArea.Visible Then
            Me.cklArea.Visible = False
            Me.cbbArea.Text = sOldName
        Else
            Me.cklArea.Visible = True
            Me.cklArea.Select()
            For bItem As Byte = 0 To 4
                If Me.cklArea.GetItemChecked(bItem) Then Me.cklArea.SetSelected(bItem, True) : Exit For
            Next
        End If
        blSkipDeal = False
    End Sub

    Private Sub cbbArea_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbArea.Enter
        sOldName = Me.cbbArea.Text
    End Sub

    Private Sub cbbArea_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbbArea.KeyPress
        e.Handled = True
        Me.cbbArea.SelectAll()
    End Sub

    Private Sub cbbArea_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbArea.Leave
        Me.cbbArea.SelectionLength = 0
    End Sub

    Private Sub cbbArea_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cbbArea.MouseDown, cbbArea.MouseUp
        My.Computer.Clipboard.Clear()
        If Me.cbbArea.Text = "" Then
            Me.cbbArea.Text = sOldName
            Me.cbbArea.SelectAll()
        End If
    End Sub

    Private Sub cklArea_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles cklArea.ItemCheck
        If blSkipDeal Then Return
        If Me.dgvRole.CurrentRow.Index = 0 Then
            frmMain.statusText.Text = "系统管理员是系统内置角色，不可修改适用区域。"
            frmMain.statusMain.Refresh()
            e.NewValue = e.CurrentValue
        ElseIf blIsReadOnly Then
            frmMain.statusText.Text = "您无权修改适用区域。"
            frmMain.statusMain.Refresh()
            e.NewValue = e.CurrentValue
        Else
            Dim blChecked As Boolean, sTypes As String = "|"
            For bItem As Byte = 0 To 4
                blChecked = False
                If bItem = e.Index Then
                    If e.NewValue = CheckState.Checked Then blChecked = True
                ElseIf Me.cklArea.GetItemChecked(bItem) Then
                    blChecked = True
                End If
                If blChecked Then
                    Select Case bItem
                        Case 0
                            sTypes = sTypes & "H|"
                        Case 1
                            sTypes = sTypes & "T|"
                        Case 2
                            sTypes = sTypes & "R|"
                        Case 3
                            sTypes = sTypes & "C|"
                        Case Else
                            sTypes = sTypes & "S|"
                    End Select
                End If
            Next
            If sTypes = "|" Then sTypes = ""
            dtRole.Select("RoleID=" & sRoleID)(0)("AcceptAreas") = sTypes
            Me.SetAcceptAreas()
            Me.CheckChanges()
        End If
    End Sub

    Private Sub cklArea_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cklArea.Leave
        Dim controlBounds As Rectangle = Me.cbbArea.Bounds
        controlBounds.Offset(Me.cbbArea.Width - 17, 0)
        controlBounds.Width = 17
        If Not controlBounds.Contains(Me.PointToClient(Control.MousePosition)) Then Me.cklArea.Visible = False : Me.cbbArea.SelectionLength = 0
        controlBounds = Nothing
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub cbbRole_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbRole.DropDown
        If blSkipDeal Then Return
        blSkipDeal = True
        Me.cbbRole.DroppedDown = True
        If Me.cklRole.Visible Then
            Me.cklRole.Visible = False
            Me.cbbRole.Text = sOldName
        Else
            If blNeedResetRoleList Then Me.SetControllableRoles()
            Me.cklRole.Visible = True
            Me.cklRole.Select()
            For bItem As Byte = 0 To Me.cklRole.Items.Count - 1
                If Me.cklRole.GetItemChecked(bItem) Then Me.cklRole.SetSelected(bItem, True) : Exit For
            Next
        End If
        blSkipDeal = False
    End Sub

    Private Sub cbbRole_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbRole.Enter
        sOldName = Me.cbbRole.Text
    End Sub

    Private Sub cbbRole_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbbRole.KeyPress
        e.Handled = True
        Me.cbbRole.SelectAll()
    End Sub

    Private Sub cbbRole_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbRole.Leave
        Me.cbbRole.SelectionLength = 0
    End Sub

    Private Sub cbbRole_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cbbRole.MouseDown, cbbRole.MouseUp
        My.Computer.Clipboard.Clear()
        If Me.cbbRole.Text = "" Then
            Me.cbbRole.Text = sOldName
            Me.cbbRole.SelectAll()
        End If
    End Sub

    Private Sub cklRole_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles cklRole.ItemCheck
        If blSkipDeal Then Return
        If Me.dgvRole.CurrentRow.Index = 0 Then
            frmMain.statusText.Text = "系统管理员是系统内置角色，不可修改可分配职位。"
            frmMain.statusMain.Refresh()
            e.NewValue = e.CurrentValue
        ElseIf blIsReadOnly Then
            frmMain.statusText.Text = "您无权修改可分配职位。"
            frmMain.statusMain.Refresh()
            e.NewValue = e.CurrentValue
        Else
            Dim sRoleIDs As String = Me.dgvRole("ControllableRoles", Me.dgvRole.CurrentRow.Index).Value.ToString, sRole As String = Me.dgvRole("RoleID", e.Index + 1).Value.ToString
            If e.NewValue = CheckState.Checked Then
                If sRoleIDs.IndexOf("|" & sRole & "|") = -1 Then sRoleIDs = sRoleIDs & sRole & "|"
                If sRoleIDs.IndexOf("|") <> 0 Then sRoleIDs = "|" & sRoleIDs
            Else
                sRoleIDs = sRoleIDs.Replace("|" & sRole & "|", "|")
                If sRoleIDs = "|" Then sRoleIDs = ""
            End If
            dtRole.Select("RoleID=" & sRoleID)(0)("ControllableRoles") = sRoleIDs
            Me.SetControllableRoles()
            Me.CheckChanges()
        End If
    End Sub

    Private Sub cklRole_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cklRole.Leave
        Dim controlBounds As Rectangle = Me.cbbRole.Bounds
        controlBounds.Offset(Me.cbbRole.Width - 17, 0)
        controlBounds.Width = 17
        If Not controlBounds.Contains(Me.PointToClient(Control.MousePosition)) Then Me.cklRole.Visible = False : Me.cbbRole.SelectionLength = 0
        controlBounds = Nothing
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub trvRight_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles trvRight.Leave
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub trvRight_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles trvRight.MouseMove
        If blIsReadOnly OrElse sRoleID = 0 Then Return
        frmMain.statusText.Text = "就绪。"
        Dim hoverNode As TreeNode = Me.trvRight.GetNodeAt(Me.trvRight.PointToClient(Control.MousePosition))
        If hoverNode IsNot Nothing AndAlso hoverNode.ImageKey <> "Object" Then
            Dim bounds As Rectangle = hoverNode.Bounds
            bounds = Rectangle.Inflate(bounds, 18, 0) '扩大范围以包含图标
            bounds.Width = bounds.Width - 18
            If bounds.Contains(Me.trvRight.PointToClient(Control.MousePosition)) Then
                bounds = Rectangle.Inflate(bounds, 0, -3) '仅包含图标
                bounds.Width = 12 '仅包含图标
                If bounds.Contains(Me.trvRight.PointToClient(Control.MousePosition)) Then
                    If hoverNode.ImageKey.IndexOf("Yes") = 0 Then
                        frmMain.statusText.Text = "点击复选框（取消勾选）将禁止此项权限。"
                    Else
                        frmMain.statusText.Text = "点击复选框（勾选）将允许此项权限。"
                    End If
                Else
                    If hoverNode.ImageKey.IndexOf("Yes") = 0 Then
                        frmMain.statusText.Text = "双击此项权限将禁止权限。"
                    Else
                        frmMain.statusText.Text = "双击此项权限将允许权限。"
                    End If
                End If
            Else
                frmMain.statusText.Text = "就绪。"
            End If
        End If
        hoverNode = Nothing
    End Sub

    Private Sub trvRight_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles trvRight.NodeMouseClick
        If e.Button <> Windows.Forms.MouseButtons.Left OrElse e.Node.ImageKey = "Object" Then Return
        Dim bounds As Rectangle = e.Node.Bounds
        bounds = Rectangle.Inflate(bounds, 18, -3) '扩大范围以包含图标
        bounds.Width = 12 '仅包含图标
        If bounds.Contains(Me.trvRight.PointToClient(Control.MousePosition)) Then
            If sRoleID = 0 Then
                frmMain.statusText.Text = "系统管理员是系统内置角色，不可修改权限设置。"
            ElseIf blIsReadOnly Then
                frmMain.statusText.Text = "您不能修改权限！因为您只有浏览的权限但没有修改的权限。"
            ElseIf e.Node.ImageKey = "Yes" Then
                Me.DisabledRight(e.Node)
                frmMain.statusText.Text = "点击复选框（勾选）将允许此项权限。"
            Else
                Me.EnabledRight(e.Node)
                frmMain.statusText.Text = "点击复选框（取消勾选）将禁止此项权限。"
            End If
        End If
        bounds = Nothing
    End Sub

    Private Sub trvRight_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles trvRight.NodeMouseDoubleClick
        If e.Button <> Windows.Forms.MouseButtons.Left OrElse e.Node.ImageKey = "Object" Then Return
        If e.Node.Bounds.Contains(Me.trvRight.PointToClient(Control.MousePosition)) Then
            If sRoleID = 0 Then
                frmMain.statusText.Text = "系统管理员是系统内置角色，不可修改权限设置。"
            ElseIf blIsReadOnly Then
                frmMain.statusText.Text = "您不能修改权限！因为您只有浏览的权限但没有修改的权限。"
            ElseIf e.Node.ImageKey = "Yes" Then
                Me.DisabledRight(e.Node)
                frmMain.statusText.Text = "双击此项权限将允许权限。"
            Else
                Me.EnabledRight(e.Node)
                frmMain.statusText.Text = "双击此项权限将禁止权限。"
            End If
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Me.SaveChanges()
    End Sub

    Private Sub FillRight(ByVal tncCurrent As TreeNodeCollection, ByVal sParentID As String)
        Try
            Dim newNode As TreeNode

            For Each dr As DataRow In dtRight.Select("ParentRightID=" & sParentID)
                newNode = New TreeNode
                tncCurrent.Add(newNode)
                newNode.Name = dr("RightID").ToString
                newNode.Text = dr("ChineseDescription").ToString & " " & dr("EnglishDescription").ToString
                If dr("IsFinalRight") Then
                    newNode.ImageKey = "No"
                Else
                    newNode.ImageKey = "Object"
                End If
                newNode.SelectedImageKey = newNode.ImageKey

                sParentID = dr("RightID").ToString
                Me.FillRight(tncCurrent(tncCurrent.Count - 1).Nodes, sParentID)
            Next
        Catch
            MessageBox.Show("初始化分类结构树时失败！", "初始化分类结构树时失败！")
        End Try
    End Sub

    Private Sub SetAcceptAreas()
        blSkipDeal = True
        Dim sTypes As String = Me.dgvRole("AcceptAreas", Me.dgvRole.CurrentRow.Index).Value.ToString, sNames As String = ""
        If sTypes.IndexOf("|H|") = -1 Then
            Me.cklArea.SetItemChecked(0, False)
        Else
            Me.cklArea.SetItemChecked(0, True)
            sNames = "HO; "
        End If
        If sTypes.IndexOf("|T|") = -1 Then
            Me.cklArea.SetItemChecked(1, False)
        Else
            Me.cklArea.SetItemChecked(1, True)
            sNames = sNames & "Territory; "
        End If
        If sTypes.IndexOf("|R|") = -1 Then
            Me.cklArea.SetItemChecked(2, False)
        Else
            Me.cklArea.SetItemChecked(2, True)
            sNames = sNames & "Region; "
        End If
        If sTypes.IndexOf("|C|") = -1 Then
            Me.cklArea.SetItemChecked(3, False)
        Else
            Me.cklArea.SetItemChecked(3, True)
            sNames = sNames & "City; "
        End If
        If sTypes.IndexOf("|S|") = -1 Then
            Me.cklArea.SetItemChecked(4, False)
        Else
            Me.cklArea.SetItemChecked(4, True)
            sNames = sNames & "Store; "
        End If
        If sNames = "" Then
            sNames = "(Nothing)"
        Else
            sNames = sNames.Substring(0, sNames.Length - 2)
        End If
        sOldName = sNames
        Me.cbbArea.Text = sNames
        blSkipDeal = False
    End Sub

    Private Sub SetControllableRoles()
        blSkipDeal = True
        Dim sRoleIDs As String = Me.dgvRole("ControllableRoles", Me.dgvRole.CurrentRow.Index).Value.ToString, blChecked As Boolean = False, sRoleNames As String = ""
        If blNeedResetRoleList Then
            Me.cklRole.Items.Clear()
            For Each dr As DataRow In dtRole.Select("RoleID>0", "RoleCode")
                blChecked = (sRoleIDs.IndexOf("|" & dr("RoleID").ToString & "|") > -1)
                Me.cklRole.Items.Add(dr("RoleChineseName").ToString & " " & dr("RoleEnglishName").ToString, blChecked)
                If blChecked Then
                    sRoleNames = sRoleNames & dr("RoleEnglishName").ToString & "; "
                End If
            Next
            Me.cklRole.Height = (IIf(Me.cklRole.Items.Count <= 20, Me.cklRole.Items.Count, 20) * 16) + 4
            blNeedResetRoleList = False
        Else
            Dim bIndex As Byte = 0
            For Each dr As DataRow In dtRole.Select("RoleID>0", "RoleCode")
                blChecked = (sRoleIDs.IndexOf("|" & dr("RoleID").ToString & "|") > -1)
                Me.cklRole.SetItemChecked(bIndex, blChecked)
                If blChecked Then
                    sRoleNames = sRoleNames & dr("RoleEnglishName").ToString & "; "
                End If
                bIndex += 1
            Next
        End If
        If sRoleNames = "" Then
            sRoleNames = "(Nothing)"
        Else
            sRoleNames = sRoleNames.Substring(0, sRoleNames.Length - 2)
        End If
        sOldName = sRoleNames
        Me.cbbRole.Text = sRoleNames
        blSkipDeal = False
    End Sub

    Private Sub SetRightAllowed()
        For Each nodeObject As TreeNode In Me.trvRight.Nodes
            For Each node As TreeNode In nodeObject.Nodes
                node.ImageKey = "No"
                node.SelectedImageKey = "No"
            Next
        Next

        Dim nodeAllowed As TreeNode
        dvRoleRight.RowFilter = "RoleID=" & sRoleID
        For Each dr As DataRowView In dvRoleRight
            If Me.trvRight.Nodes.Find(dr("RightID").ToString, True).Length = 1 Then
                nodeAllowed = Me.trvRight.Nodes.Find(dr("RightID").ToString, True)(0)
                nodeAllowed.ImageKey = "Yes"
                nodeAllowed.SelectedImageKey = "Yes"
            End If
        Next
    End Sub

    Private Sub EnabledRight(ByVal node As TreeNode)
        Dim newRight As DataRowView = dvRoleRight.AddNew
        newRight("RoleID") = sRoleID
        newRight("RightID") = node.Name
        newRight.EndEdit()
        node.ImageKey = "Yes"
        node.SelectedImageKey = "Yes"
        Dim sRightName As String = dtRight.Select("RightID=" & node.Name)(0)("RightName").ToString, sBrowseRightName As String = ""
        Select Case sRightName
            Case "RoleMaintance"
                sBrowseRightName = "RoleBrowse"
            Case "AreaMaintance"
                sBrowseRightName = "AreaBrowse"
            Case "BusinessTypeMaintance"
                sBrowseRightName = "BusinessTypeBrowse"
            Case "InvoiceItemMaintance"
                sBrowseRightName = "InvoiceItemBrowse"
            Case "InvoiceLayoutModification"
                sBrowseRightName = "InvoiceLayoutBrowse"
            Case "CityConfigModify", "CityConfigValidate"
                sBrowseRightName = "CityConfigBrowse"
            Case "UserValidate", "UserModifyBefore", "UserModifyAfter", "UserResetPassword", "UserStop", "UserDeleteBefore", "UserDeleteAfter"
                sBrowseRightName = "UserBrowse"
            Case "CustomerDelete"
                sBrowseRightName = "CustomerBrowse"
            Case "ContractValidate", "ContractModify", "ContractStop", "ContractDelete"
                sBrowseRightName = "ContractBrowse"
            Case "SalesBillRebateModify", "SalesBillRebateValidate", "SalesBillSalesmanAdjust", "SalesBillDelete"
                sBrowseRightName = "SalesBillBrowse"
                'Case "CardActivate", "PaymentConfirm"
                '    sBrowseRightName = "ActivationView"
            Case "ReportOutput"
                sBrowseRightName = "ReportBrowse"
        End Select
        If sBrowseRightName <> "" Then
            Dim sBrowseRightID As String = dtRight.Select("RightName='" & sBrowseRightName & "'")(0)("RightID").ToString
            dvRoleRight.RowFilter = "RoleID=" & sRoleID & " And RightID=" & sBrowseRightID
            If dvRoleRight.Count = 0 Then
                node = Me.trvRight.Nodes.Find(sBrowseRightID, True)(0)
                newRight = dvRoleRight.AddNew
                newRight("RoleID") = sRoleID
                newRight("RightID") = node.Name
                newRight.EndEdit()
                node.ImageKey = "Yes"
                node.SelectedImageKey = "Yes"
            End If
        End If
        Me.CheckChanges()
    End Sub

    Private Sub DisabledRight(ByVal node As TreeNode)
        dvRoleRight.RowFilter = "RoleID=" & sRoleID & " And RightID=" & node.Name
        dvRoleRight(0).Delete()
        node.ImageKey = "No"
        node.SelectedImageKey = "No"
        Dim sRightName As String = dtRight.Select("RightID=" & node.Name)(0)("RightName").ToString, sOtherRightNames As String = ""
        Select Case sRightName
            Case "RoleBrowse"
                sOtherRightNames = "RoleMaintance"
            Case "AreaBrowse"
                sOtherRightNames = "AreaMaintance"
            Case "BusinessTypeBrowse"
                sOtherRightNames = "BusinessTypeMaintance"
            Case "InvoiceItemBrowse"
                sOtherRightNames = "InvoiceItemMaintance"
            Case "InvoiceLayoutBrowse"
                sOtherRightNames = "InvoiceLayoutModification"
            Case "CityConfigBrowse"
                sOtherRightNames = "CityConfigModify,CityConfigValidate"
            Case "UserBrowse"
                sOtherRightNames = "UserValidate,UserModifyBefore,UserModifyAfter,UserResetPassword,UserStop,UserDeleteBefore,UserDeleteAfter"
            Case "CustomerBrowse"
                sOtherRightNames = "CustomerDelete"
            Case "ContractBrowse"
                sOtherRightNames = "ContractValidate,ContractModify,ContractStop,ContractDelete"
            Case "SalesBillBrowse"
                sOtherRightNames = "SalesBillRebateModify,SalesBillRebateValidate,SalesBillSalesmanAdjust,SalesBillDelete"
                'Case "ActivationView"
                '    sOtherRightNames = "CardActivate,PaymentConfirm"
            Case "ReportBrowse"
                sOtherRightNames = "ReportOutput"
        End Select
        If sOtherRightNames <> "" Then
            Dim saOtherRightNames() As String = sOtherRightNames.Split(","), sRightID As String
            For bItem As Byte = 0 To saOtherRightNames.Length - 1
                sRightID = dtRight.Select("RightName='" & saOtherRightNames(bItem) & "'")(0)("RightID")
                dvRoleRight.RowFilter = "RoleID=" & sRoleID & " And RightID=" & sRightID
                If dvRoleRight.Count > 0 Then
                    node = Me.trvRight.Nodes.Find(sRightID, True)(0)
                    node.ImageKey = "No"
                    node.SelectedImageKey = "No"
                    dvRoleRight(0).Delete()
                End If
            Next
        End If
        Me.CheckChanges()
    End Sub

    Private Sub CheckChanges()
        Dim blChanged As Boolean = False
        If dtRole.GetChanges() IsNot Nothing Then blChanged = True
        If dvRoleRight.Table.GetChanges() IsNot Nothing Then blChanged = True
        Me.btnSave.Enabled = blChanged
    End Sub

    Private Function SaveChanges() As Boolean
        Me.btnSave.Select()
        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在保存更改……"
        frmMain.statusMain.Refresh()

        Dim DB As New DataBase
        DB.Open(True)
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法保存更改！请检查数据库连接。"
            Me.Cursor = Cursors.Default
            Return False
        End If

        Dim drRole As DataRow, sRoleName As String, sRightName As String
        For Each dr As DataRow In dvRoleRight.Table.Select("", "", DataViewRowState.Deleted)
            If DB.ModifyTable("Delete From RoleRight Where RoleID=" & dr("RoleID", DataRowVersion.Original).ToString & " And RightID=" & dr("RightID", DataRowVersion.Original).ToString) = -1 Then
                DB.Close()
                frmMain.statusText.Text = "保存更改失败！"
                Me.Cursor = Cursors.Default
                Return False
            Else
                drRole = dtRole.Select("RoleID=" & dr("RoleID", DataRowVersion.Original).ToString, "", DataViewRowState.OriginalRows)(0)
                sRoleName = (drRole("RoleChineseName", DataRowVersion.Original).ToString & " " & drRole("RoleEnglishName", DataRowVersion.Original).ToString).Trim
                sRightName = dtRight.Select("RightID=" & dr("RightID", DataRowVersion.Original).ToString)(0)("RightName").ToString
                DB.ModifyTable("Exec OperationLogInsert " & frmMain.sSSID & ",'Disallow Right: " & sRightName.Replace("'", "''") & " From Position: " & sRoleName.Replace("'", "''") & "','Role'," & dr("RoleID", DataRowVersion.Original).ToString)
                dr.AcceptChanges()
            End If
        Next

        For Each dr As DataRow In dtRole.Select("", "", DataViewRowState.Deleted)
            If DB.ModifyTable("Delete From RoleList Where RoleID=" & dr("RoleID", DataRowVersion.Original).ToString & " And UserQTY=0") = -1 Then
                DB.Close()
                frmMain.statusText.Text = "保存更改失败！"
                Me.Cursor = Cursors.Default
                Return False
            Else
                DB.ModifyTable("Exec OperationLogInsert " & frmMain.sSSID & ",'Delete Position: " & (dr("RoleChineseName", DataRowVersion.Original).ToString & " " & dr("RoleEnglishName", DataRowVersion.Original).ToString).Trim.Replace("'", "''") & "','Role'," & dr("RoleID", DataRowVersion.Original).ToString)
                dr.AcceptChanges()
            End If
        Next

        Dim sSQL As String = ""
        For Each dr As DataRow In dtRole.Select("", "", DataViewRowState.ModifiedCurrent)
            sSQL = ""
            If dr("RoleCode").ToString <> dr("RoleCode", DataRowVersion.Original).ToString Then sSQL = "RoleCode='" & dr("RoleCode").ToString & "',"
            If dr("RoleChineseName").ToString <> dr("RoleChineseName", DataRowVersion.Original).ToString Then sSQL = sSQL & "RoleChineseName='" & dr("RoleChineseName").ToString.Replace("'", "''") & "',"
            If dr("RoleEnglishName").ToString <> dr("RoleEnglishName", DataRowVersion.Original).ToString Then sSQL = sSQL & "RoleEnglishName='" & dr("RoleEnglishName").ToString.Replace("'", "''") & "',"
            If dr("AcceptAreas").ToString <> dr("AcceptAreas", DataRowVersion.Original).ToString Then sSQL = sSQL & "AcceptAreas='" & dr("AcceptAreas").ToString & "',"
            If dr("ControllableRoles").ToString <> dr("ControllableRoles", DataRowVersion.Original).ToString Then sSQL = sSQL & "ControllableRoles='" & dr("ControllableRoles").ToString & "',"
            If sSQL <> "" Then
                sSQL = "Update RoleList Set " & sSQL.Substring(0, sSQL.Length - 1) & " Where RoleID=" & dr("RoleID").ToString
                If DB.ModifyTable(sSQL) = -1 Then
                    DB.Close()
                    frmMain.statusText.Text = "保存更改失败！"
                    Me.Cursor = Cursors.Default
                    Return False
                Else
                    DB.ModifyTable("Exec OperationLogInsert " & frmMain.sSSID & ",'Update Position: " & (dr("RoleChineseName").ToString & " " & dr("RoleEnglishName").ToString).Trim.Replace("'", "''") & "','Role'," & dr("RoleID").ToString)
                    dr.AcceptChanges()
                End If
            End If
        Next

        For Each dr As DataRow In dtRole.Select("", "", DataViewRowState.Added)
            If DB.ModifyTable("Insert Into RoleList Values (" & dr("RoleID").ToString & ",'" & dr("RoleCode").ToString & "','" & dr("RoleChineseName").ToString.Replace("'", "''") & "','" & dr("RoleEnglishName").ToString.Replace("'", "''") & "','" & dr("AcceptAreas").ToString & "','" & dr("ControllableRoles").ToString & "',0)") = -1 Then
                DB.Close()
                frmMain.statusText.Text = "保存更改失败！"
                Me.Cursor = Cursors.Default
                Return False
            Else
                DB.ModifyTable("Exec OperationLogInsert " & frmMain.sSSID & ",'Create Position: " & (dr("RoleChineseName").ToString & " " & dr("RoleEnglishName").ToString).Trim.Replace("'", "''") & "','Role'," & dr("RoleID").ToString)
                dr.AcceptChanges()
            End If
        Next

        For Each dr As DataRow In dvRoleRight.Table.Select("", "", DataViewRowState.Added)
            If DB.ModifyTable("Insert Into RoleRight Values (" & dr("RoleID").ToString & "," & dr("RightID").ToString & ")") = -1 Then
                DB.Close()
                frmMain.statusText.Text = "保存更改失败！"
                Me.Cursor = Cursors.Default
                Return False
            Else
                drRole = dtRole.Select("RoleID=" & dr("RoleID").ToString)(0)
                sRoleName = (drRole("RoleChineseName").ToString & " " & drRole("RoleEnglishName").ToString).Trim
                sRightName = dtRight.Select("RightID=" & dr("RightID").ToString)(0)("RightName").ToString
                DB.ModifyTable("Exec OperationLogInsert " & frmMain.sSSID & ",'Allow Right: " & sRightName.Replace("'", "''") & " Into Position: " & sRoleName.Replace("'", "''") & "','Role'," & dr("RoleID").ToString)
                dr.AcceptChanges()
            End If
        Next

        DB.Close()

        dtRole.AcceptChanges()
        dvRoleRight.Table.AcceptChanges()
        Me.btnSave.Enabled = False
        Me.dgvRole.Select()
        frmMain.statusText.Text = "保存更改成功。"
        Me.Cursor = Cursors.Default
        Return True
    End Function
End Class