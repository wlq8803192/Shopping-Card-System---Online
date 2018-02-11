Public Class frmUser

    Private drUser As DataRow, dtArea As DataTable, dtRole As DataTable, dtRight As DataTable, dvRoleRight As DataView, dtControllableArea As DataTable, dvCityBusinessType As DataView, dtAllowedRole As DataTable
    Private blIsNewUser As Boolean = False, blIsReadOnly As Boolean = False, blSkipDeal As Boolean = True, blCanselectArea As Boolean = True, blCanSelectBusinessType As Boolean = True, sHRNumberErrorInfo As String = ""
    Private sLocationID As String = "", sLocationType As String = "", sRoleID As String = "", sControllableRoles As String = "", sOldName As String = ""
    Public sUserID As String = "-1"

    Private Sub frmUser_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.btnSave.Enabled Then
            Me.btnSave.Select()
            Dim bAnswer As Windows.Forms.DialogResult = MessageBox.Show("当前窗口内容已更改，但未保存。    " & Chr(13) & Chr(13) & "是否在关闭窗口前保存这些更改？    " & Chr(13) & Chr(13) & "   是    -   保存更改并退出" & Chr(13) & "   否    -   放弃更改并退出" & Chr(13) & "  取消   -   取消关闭", "请确认保存更改：", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

            If bAnswer = Windows.Forms.DialogResult.Yes Then
                e.Cancel = Not Me.SaveChanges
            ElseIf bAnswer = Windows.Forms.DialogResult.Cancel Then
                e.Cancel = True
            ElseIf frmMain.statusText.Text.IndexOf("无法") = -1 Then
                frmMain.statusText.Text = "就绪。"
            End If
        ElseIf frmMain.statusText.Text.IndexOf("无法") = -1 Then
            frmMain.statusText.Text = "就绪。"
        End If
    End Sub

    Private Sub frmUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DB As New DataBase()
        DB.Open(True)
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打开用户窗口。请检查数据库连接。"
            Me.Close() : Return
        End If

        dtArea = DB.GetDataTable("Select * From AreaList")
        If dtArea Is Nothing Then
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开窗口。请联系软件开发人员。"
            DB.Close() : Me.Close() : Return
        End If

        dtRole = DB.GetDataTable("Select * From RoleList Order By RoleCode")
        If dtRole Is Nothing Then
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开窗口。请联系软件开发人员。"
            DB.Close() : Me.Close() : Return
        End If

        dtRight = DB.GetDataTable("Select * From RightList Order By RightID")
        If dtRole Is Nothing Then
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开窗口。请联系软件开发人员。"
            DB.Close() : Me.Close() : Return
        End If
        Try
            dtRight.Select("RightName='SalesBillRecharge'")(0).Delete()
            dtRight.Select("RightName='TransferCard'")(0).Delete()
            dtRight.Select("RightName='AffirmTransferCard'")(0).Delete()
            dtRight.AcceptChanges()
        Catch
        End Try

        Try
            dvRoleRight = DB.GetDataTable("Select * From RoleRight").DefaultView
        Catch
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开窗口。请联系软件开发人员。"
            DB.Close() : Me.Close() : Return
        End Try

        Try
            dvCityBusinessType = DB.GetDataTable("Select C.CityID,C.BusinessTypeID,B.BusinessTypeCode,B.BusinessTypeCode+' '+Rtrim(Ltrim(Isnull(B.BusinessTypeChineseName,'')+' '+Isnull(B.BusinessTypeEnglishName,''))) As BusinessTypeFullName  From CityBusinessType As C Inner Join BusinessType As B On C.BusinessTypeID=B.BusinessTypeID Where B.IsInnerType=0").DefaultView
            dvCityBusinessType.Sort = "BusinessTypeCode"
        Catch
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开窗口。请联系软件开发人员。"
            DB.Close() : Me.Close() : Return
        End Try

        sControllableRoles = dtRole.Select("RoleID=" & frmMain.sLoginRoleID)(0)("ControllableRoles").ToString
        Try
            If sUserID = "-1" Then
                If sControllableRoles = "" Then
                    MessageBox.Show("因为您所属的职位不能创建任何职位的用户，所以您不能创建用户！    ", "没法创建用户！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    frmMain.statusText.Text = "因为您所属的职位不能创建任何职位的用户，所以您不能创建用户！"
                    DB.Close() : Me.Close() : Return
                End If
                blIsNewUser = True
                drUser = DB.GetDataTable("Exec UserSingle -1").Rows.Add
                If frmUserManagerment.IsHandleCreated Then
                    sLocationID = frmUserManagerment.trvArea.SelectedNode.Name : sLocationType = frmUserManagerment.trvArea.SelectedNode.SelectedImageKey
                    sRoleID = frmUserManagerment.cbbRole.SelectedValue.ToString
                    If sControllableRoles.IndexOf("|" & sRoleID & "|") = -1 Then
                        sRoleID = ""
                        For Each drRole As DataRow In dtRole.Select("AcceptAreas Like '%|" & sLocationType & "|%'", "RoleCode")
                            If sControllableRoles.IndexOf("|" & drRole("RoleID").ToString & "|") > -1 Then
                                sRoleID = drRole("RoleID").ToString
                                Exit For
                            End If
                        Next
                    End If
                    If sRoleID = "" Then sLocationID = ""
                End If

                If sLocationID = "" Then
                    For Each drArea As DataRow In frmMain.dtLoginStructure.Rows
                        sLocationID = drArea("AreaID").ToString : sLocationType = drArea("AreaType").ToString
                        For Each drRole As DataRow In dtRole.Select("AcceptAreas Like '%|" & sLocationType & "|%'")
                            If sControllableRoles.IndexOf("|" & drRole("RoleID").ToString & "|") > -1 Then
                                sRoleID = drRole("RoleID").ToString
                                Exit For
                            End If
                        Next
                        If sRoleID <> "" Then Exit For
                    Next
                End If

                If sRoleID = "" Then
                    MessageBox.Show("因为不存在您所能分配的职位的位置，所以您不能创建用户！    " & Chr(13) & Chr(13) & "请先创建位置，然后再创建用户。    ", "没法创建用户！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    frmMain.statusText.Text = "因为不存在您所能分配的职位的位置，所以您不能创建用户！"
                    DB.Close() : Me.Close() : Return
                End If
                drUser("UserID") = -1
                drUser("LocationID") = sLocationID
                drUser("RoleID") = sRoleID
                If sRoleID = 6 Then '指导店长
                    drUser("AreaID") = dtArea.Select("AreaID=" & sLocationID)(0)("ParentAreaID")
                Else
                    drUser("AreaID") = sLocationID
                End If
                drUser("ControllableAreas") = "All"
                drUser("ControllableBusinessTypes") = "All"
                drUser("IsLogin") = 0
                drUser("UserState") = 0
                drUser("NeedChangePassword") = 1
                drUser("NeedResetPassword") = 0
                drUser("Sex") = 1
                drUser("JoinDate") = "2000/1/1"
                Me.NameStandardization()
            Else
                Dim dtUser As DataTable = DB.GetDataTable("Exec UserSingle " & sUserID)
                If dtUser.Rows.Count = 0 Then
                    MessageBox.Show("您所要打开的用户已经不存在（可能被删除或移位）！    ", "用户不存在！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If frmUserManagerment.IsHandleCreated Then
                        Try
                            frmUserManagerment.dvUser.Table.Rows.Find(sUserID).Delete()
                        Catch
                        End Try
                    End If
                    frmMain.statusText.Text = "用户不存在！"
                    dtUser.Dispose() : dtUser = Nothing
                    DB.Close() : Me.Close() : Return
                Else
                    drUser = dtUser.Copy.Rows(0)
                    sLocationID = drUser("LocationID").ToString
                    sLocationType = dtArea.Select("AreaID=" & sLocationID)(0)("AreaType").ToString
                    sRoleID = drUser("RoleID").ToString
                End If
                dtUser.Dispose() : dtUser = Nothing
            End If
        Catch
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开用户窗口。请联系软件开发人员。"
            DB.Close() : Me.Close() : Return
        End Try

        DB.Close()

        Me.FillRight(Me.trvRight.Nodes, "255")
        Me.FillUser()
        Me.trvRight.Nodes(0).EnsureVisible()

        If sUserID <> "-1" Then
            Me.Text = "用户 User: " & Me.txbAreaCode.Text & Me.txbUserCode.Text & " " & Me.txbLoginName.Text
            If frmUserManagerment.IsHandleCreated Then
                Try
                    With frmUserManagerment
                        If .trvArea.SelectedNode Is Nothing OrElse .trvArea.SelectedNode.Name <> sLocationID Then
                            If .trvArea.SelectedNode IsNot Nothing Then
                                .trvArea.SelectedNode.BackColor = SystemColors.Window
                                .trvArea.SelectedNode.ForeColor = SystemColors.ControlText
                            End If
                            .trvArea.SelectedNode = .trvArea.Nodes.Find(sLocationID, True)(0)
                            .trvArea.SelectedNode.BackColor = SystemColors.Highlight
                            .trvArea.SelectedNode.ForeColor = SystemColors.HighlightText
                            .trvArea.SelectedNode.EnsureVisible()
                        End If
                        Dim userRow As DataRow = .dvUser.Table.Rows.Find(sUserID)

                        userRow("UserCode") = Me.txbAreaCode.Text & Me.txbUserCode.Text
                        userRow("LoginName") = Me.txbLoginName.Text.Trim
                        userRow("AreaName") = Me.txbLocation.Text.Substring(5)
                        userRow("RoleName") = Me.txbRole.Text.Substring(3)
                        If Me.txbUserChineseName.Text.Trim <> "" Then userRow("UserChineseName") = Me.txbUserChineseName.Text.Trim
                        If Me.txbUserEnglishName.Text.Trim <> "" Then userRow("UserEnglishName") = Me.txbUserEnglishName.Text.Trim
                        Select Case drUser("UserState")
                            Case 0
                                userRow("StateDescription") = "等待审核 Pending"
                            Case 1
                                userRow("StateDescription") = "审核失败 Not Approved"
                            Case 2
                                userRow("StateDescription") = "审核成功 Approved"
                            Case Else
                                userRow("StateDescription") = "停止使用 Blocked"
                        End Select
                        userRow("UserState") = drUser("UserState")
                        userRow("LocationID") = sLocationID
                        userRow("RoleID") = sRoleID
                        userRow.EndEdit() : userRow.AcceptChanges()
                        If .cbbState.SelectedIndex <> 0 AndAlso .cbbState.SelectedIndex <> userRow("UserState") + 1 Then .cbbState.SelectedIndex = 0
                        For Each dr As DataGridViewRow In .dgvList.Rows
                            If dr.Cells("UserID").Value.ToString = sUserID Then
                                dr.Cells(1).Selected = True
                                dr.Selected = True
                                Exit For
                            End If
                        Next
                    End With
                Catch
                End Try
            End If
        End If

        If sUserID <> "-1" AndAlso frmMain.dtAllowedRight.Select("RightName In ('UserValidate','UserModifyBefore','UserModifyAfter','UserStop')").Length = 0 Then
            blIsReadOnly = True
            Me.Text = Me.Text & " (只读 Readonly)"
        End If

        blSkipDeal = False
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub txbLoginName_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbLoginName.DoubleClick
        If Not Me.txbLoginName.ReadOnly Then Me.txbLoginName.SelectAll()
    End Sub

    Private Sub txbLoginName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbLoginName.KeyDown
        If Me.txbLoginName.ReadOnly Then Return
        If e.KeyCode = Keys.Enter Then
            Me.cbbLocation.Select()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txbLoginName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbLoginName.Leave
        If Me.txbLoginName.Text <> Me.txbLoginName.Text.Trim Then Me.txbLoginName.Text = Me.txbLoginName.Text.Trim
        If drUser("LoginName").ToString <> Me.txbLoginName.Text Then
            If Me.txbLoginName.Text = "" Then
                Me.txbLoginName.Text = drUser("LoginName").ToString
                Return
            End If
            drUser("LoginName") = Me.txbLoginName.Text
            Me.CheckChanges()
        End If
    End Sub

    Private Sub cbbLocation_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbbLocation.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txbLoginName.Select()
            Me.txbLoginName.SelectAll()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub cbbLocation_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbLocation.Leave
        If Me.cbbLocation.Tag IsNot Nothing Then
            Me.cbbLocation.Tag = Nothing
            blSkipDeal = True
            Dim sText As String = Me.cbbLocation.Text
            Me.cbbLocation.Text = ""
            blSkipDeal = False
            Me.cbbLocation.Text = sText '引发检查
        End If
        Me.cbbLocation.Tag = Nothing
    End Sub

    Private Sub cbbLocation_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbLocation.TextChanged
        If blSkipDeal Then Return
        If Me.cbbLocation.Tag IsNot Nothing Then Return '当用户正在使用键盘输入时不引发

        blSkipDeal = True
        Dim sNewLocationID As String = Me.cbbLocation.SelectedAreaID, sNewLocationType As String, sNewRoleID As String = ""
        If sNewLocationID = "" Then
            Me.cbbLocation.Text = Me.txbLocation.Text
            sNewLocationID = sLocationID
        End If
        If sNewLocationID = sLocationID Then blSkipDeal = False : Return

        sNewLocationType = Me.cbbLocation.Text.Substring(0, 1)
        If sNewLocationType = sLocationType Then
            sNewRoleID = sRoleID
        Else
            For Each drRole As DataRow In dtRole.Select("AcceptAreas Like '%|" & sNewLocationType & "|%'")
                If sControllableRoles.IndexOf("|" & drRole("RoleID").ToString & "|") > -1 Then
                    sNewRoleID = drRole("RoleID").ToString
                    Exit For
                End If
            Next
            If sNewRoleID = "" Then
                MessageBox.Show("因为您不能在目前所选的位置下分配任何职位，所以当前选择是无效的！    " & Chr(13) & Chr(13) & "位置： " & Me.cbbLocation.Text & Space(4) & Chr(13) & Chr(13) & "系统即将自动恢复到原来的位置。    ", "位置选择无效！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.cbbLocation.Text = Me.txbLocation.Text
                blSkipDeal = False : Return
            End If
        End If

        If sNewRoleID <> sRoleID Then
            dtAllowedRole.Rows.Clear()
            For Each drRole In dtRole.Select("AcceptAreas Like '%|" & sNewLocationType & "|%'", "RoleCode")
                If sControllableRoles.IndexOf("|" & drRole("RoleID").ToString & "|") > -1 Then
                    dtAllowedRole.Rows.Add(drRole("RoleID"), Trim(drRole("RoleCode").ToString & " " & drRole("RoleChineseName").ToString & " " & drRole("RoleEnglishName").ToString))
                End If
            Next
            dtAllowedRole.AcceptChanges()
            Me.cbbRole.SelectedValue = sNewRoleID
            sRoleID = sNewRoleID : Me.SetRightAllowed()
        End If

        If sNewRoleID = 6 Then '指导店长
            drUser("AreaID") = dtArea.Select("AreaID=" & sNewLocationID)(0)("ParentAreaID")
        Else
            drUser("AreaID") = sNewLocationID
        End If
        drUser("ControllableAreas") = "All"

        blCanselectArea = True
        dtControllableArea.Rows.Clear()
        Dim sAreaType As String = dtArea.Select("AreaID=" & drUser("AreaID").ToString)(0)("AreaType").ToString, drArea As DataRow
        If sAreaType = "S" Then
            drArea = dtArea.Select("AreaID=" & drUser("AreaID").ToString)(0)
            dtControllableArea.Rows.Add(drArea("AreaID"), (drArea("AreaType").ToString & drArea("AreaCode").ToString & " " & drArea("AreaChineseName").ToString & " " & drArea("AreaEnglishName").ToString).Trim)
        Else
            For Each drArea In dtArea.Select("ParentAreaID=" & drUser("AreaID").ToString, "AreaCode")
                dtControllableArea.Rows.Add(drArea("AreaID"), (drArea("AreaType").ToString & drArea("AreaCode").ToString & " " & drArea("AreaChineseName").ToString & " " & drArea("AreaEnglishName").ToString).Trim)
            Next
        End If
        dtControllableArea.AcceptChanges()
        If dtControllableArea.Rows.Count = 1 Then blCanselectArea = False
        Me.SetControllableAreas()

        drUser("ControllableBusinessTypes") = "All"
        blCanSelectBusinessType = True
        If sNewLocationType = "C" OrElse sNewLocationType = "S" Then
            Dim sCityID As String = sNewLocationID
            If sNewLocationType = "S" Then
                sCityID = dtArea.Select("AreaID=" & sNewLocationID)(0)("ParentAreaID").ToString
            End If
            dvCityBusinessType.RowFilter = "CityID=" & sCityID
            Me.cklBusinessType.Items.Clear()
            If dvCityBusinessType.Count = 0 Then
                Me.cklBusinessType.Items.Add("(没有商业类型 No Business Type)", True)
                Me.cbbBusinessType1.Text = "(没有商业类型 No Business Type)"
                blCanSelectBusinessType = False
            Else
                If dvCityBusinessType.Count > 1 Then
                    Me.cklBusinessType.Items.Add("(所有商业类型 All Business Types)", True)
                End If
                For Each drType As DataRowView In dvCityBusinessType
                    Me.cklBusinessType.Items.Add(drType("BusinessTypeFullName").ToString, True)
                Next
                If Me.cklBusinessType.CheckedItems.Count = 1 Then
                    Me.cbbBusinessType1.Text = Me.cklBusinessType.CheckedItems(0).ToString.Substring(3)
                Else
                    Me.cbbBusinessType1.Text = "(所有商业类型 All Business Types)"
                End If
            End If
            Me.cklBusinessType.Height = (IIf(Me.cklBusinessType.Items.Count <= 20, Me.cklBusinessType.Items.Count, 20) * 16) + 4
            Me.cklBusinessType.Top = Me.cbbBusinessType1.Top - Me.cklBusinessType.Height
            Me.cbbBusinessType1.Visible = True
            Me.cbbBusinessType2.Visible = False
        Else
            Me.cbbBusinessType1.Visible = False
            Me.cbbBusinessType2.Visible = True
            Me.cbbBusinessType2.SelectedIndex = 0
        End If
        If blCanSelectBusinessType Then
            Me.cbbBusinessType1.BackColor = SystemColors.Window
            Me.cbbBusinessType2.BackColor = SystemColors.Window
            Me.cklBusinessType.BackColor = SystemColors.Window
        Else
            Me.cbbBusinessType1.BackColor = SystemColors.Control
            Me.cbbBusinessType2.BackColor = SystemColors.Control
            Me.cklBusinessType.BackColor = SystemColors.Control
        End If
        Me.cklBusinessType.CheckOnClick = blCanSelectBusinessType

        Me.txbAreaCode.Text = Me.cbbLocation.Text.Substring(0, 4)
        If Me.Text.IndexOf(": " & Me.txbAreaCode.Text) > -1 Then
            Me.txbUserCode.Text = drUser("UserCode").ToString
        Else
            Me.txbUserCode.Text = ""
        End If
        Me.txbLocation.Text = Me.cbbLocation.Text
        sLocationID = sNewLocationID : sLocationType = sNewLocationType : sRoleID = sNewRoleID
        drUser("LocationID") = sLocationID : drUser("RoleID") = sRoleID
        If sUserID = "-1" Then Me.NameStandardization()
        Me.CheckChanges()
        blSkipDeal = False
    End Sub

    Private Sub txbHRNumber_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbHRNumber.DoubleClick
        If Not txbHRNumber.ReadOnly Then Me.txbHRNumber.SelectAll()
    End Sub

    Private Sub txbHRNumber_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbHRNumber.KeyDown
        If Me.txbHRNumber.ReadOnly Then Return
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then Return
        If e.KeyCode >= Keys.A AndAlso e.KeyCode <= Keys.Z Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then Me.txbTel.Select() : Me.txbTel.SelectAll() : e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbHRNumber_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbHRNumber.Leave
        If Me.txbHRNumber.ReadOnly OrElse Me.txbHRNumber.Text.Trim = "" OrElse Me.txbHRNumber.Text.Trim = drUser("HRNumber").ToString Then Return
        If Me.txbHRNumber.Text <> Me.txbHRNumber.Text.Trim Then Me.txbHRNumber.Text = Me.txbHRNumber.Text.Trim
        drUser("HRNumber") = Me.txbHRNumber.Text
        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正从数据库中检索员工信息……"
        frmMain.statusMain.Refresh()
        Dim DB As New DataBase
        DB.Open()

        If DB.IsConnected Then
            Dim dtUser As DataTable = DB.GetDataTable("Exec GetUserHRInfo '" & Me.txbHRNumber.Text.Replace("'", "''") & "'")
            If dtUser Is Nothing Then
                frmMain.statusText.Text = "系统因在检索数据时出错而无法检索员工信息。请联系软件开发人员。"
            ElseIf dtUser.Rows.Count = 0 Then
                MessageBox.Show("从Payroll系统中找不到此员工！    ", "员工编号无效！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                sHRNumberErrorInfo = "从Payroll系统中找不到此员工！"
                frmMain.statusText.Text = sHRNumberErrorInfo
            ElseIf "|正式|试用|".IndexOf("|" & dtUser.Rows(0)("EmployeeState").ToString & "|") = -1 Then
                MessageBox.Show("员工状态无效！不能为此员工建立账号！    " & Chr(13) & Chr(13) & "当前的员工状态：" & dtUser.Rows(0)("EmployeeState").ToString, "员工状态无效！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                sHRNumberErrorInfo = "员工状态无效！不能为此员工建立账号！"
                frmMain.statusText.Text = sHRNumberErrorInfo
            Else
                blSkipDeal = True
                sHRNumberErrorInfo = ""
                drUser("HRNumber") = Me.txbHRNumber.Text
                drUser("UserChineseName") = dtUser.Rows(0)("UserChineseName").ToString
                drUser("UserEnglishName") = dtUser.Rows(0)("UserEnglishName").ToString
                drUser("Sex") = dtUser.Rows(0)("Sex").ToString
                Try
                    drUser("JoinDate") = dtUser.Rows(0)("JoinDate").ToString
                Catch
                    drUser("JoinDate") = "2010/01/01"
                End Try
                drUser("Tel") = dtUser.Rows(0)("Tel").ToString

                Me.txbUserChineseName.Text = drUser("UserChineseName").ToString
                Me.txbUserEnglishName.Text = drUser("UserEnglishName").ToString
                If drUser("Sex") Then
                    Me.rdbMan.Checked = True : Me.rdbFemale.Checked = False
                Else
                    Me.rdbMan.Checked = False : Me.rdbFemale.Checked = True
                End If
                Me.dtpJoinDate.Value = drUser("JoinDate")
                Me.txbJoinDate.Text = Format(drUser("JoinDate"), "yyyy\/MM\/dd")
                Me.txbTel.Text = drUser("Tel").ToString

                Me.CheckChanges()
                blSkipDeal = False
                frmMain.statusText.Text = "就绪。"
            End If

            If dtUser IsNot Nothing Then dtUser.Dispose() : dtUser = Nothing
        Else
            frmMain.statusText.Text = "系统因连接不到数据库而无法检索员工信息。请检查数据库连接。"
        End If

        DB.Close()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txbHRNumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbHRNumber.TextChanged
        If blSkipDeal Then Return

        sHRNumberErrorInfo = "员工编号是用于检查用户合法性的必要信息之一，所以不能为空！"
        If Me.txbUserChineseName.Text <> "" Then
            blSkipDeal = True
            drUser("UserChineseName") = DBNull.Value
            drUser("UserEnglishName") = DBNull.Value
            drUser("Sex") = 1
            drUser("JoinDate") = DBNull.Value
            drUser("Tel") = DBNull.Value
            Me.txbUserChineseName.Text = ""
            Me.txbUserEnglishName.Text = ""
            Me.rdbMan.Checked = True : Me.rdbFemale.Checked = False
            Me.txbJoinDate.Text = ""
            Me.txbTel.Text = ""
            blSkipDeal = False
        End If
        Me.CheckChanges()
    End Sub

    Private Sub txbUserChineseName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbUserChineseName.Leave
        'If Me.txbUserChineseName.Text <> Me.txbUserChineseName.Text.Trim Then Me.txbUserChineseName.Text = Me.txbUserChineseName.Text.Trim
        'If drUser("UserChineseName").ToString <> Me.txbUserChineseName.Text Then
        '    drUser("UserChineseName") = Me.txbUserChineseName.Text
        '    Me.CheckChanges()
        'End If
    End Sub

    Private Sub txbUserEnglishName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbUserEnglishName.Leave
        'If Me.txbUserEnglishName.Text <> Me.txbUserEnglishName.Text.Trim Then Me.txbUserEnglishName.Text = Me.txbUserEnglishName.Text.Trim
        'If drUser("UserEnglishName").ToString <> Me.txbUserEnglishName.Text Then
        '    drUser("UserEnglishName") = Me.txbUserEnglishName.Text
        '    Me.CheckChanges()
        'End If
    End Sub

    Private Sub rdbMan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbMan.CheckedChanged
        'If blSkipDeal Then Return
        'drUser("Sex") = IIf(Me.rdbMan.Checked, 1, 0)
        'Me.CheckChanges()
    End Sub

    Private Sub dtpJoinDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpJoinDate.ValueChanged
        'If blSkipDeal Then Return
        'drUser("JoinDate") = Me.dtpJoinDate.Value
        'Me.txbJoinDate.Text = Format(Me.dtpJoinDate.Value, "yyyy\/MM\/dd")
        'blSkipDeal = True
        'Me.dtpLeavedDate.MinDate = Me.dtpJoinDate.Value
        'Me.dtpLeavedDate.Value = Today()
        'blSkipDeal = False
        'Me.CheckChanges()
    End Sub

    Private Sub txbTel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbTel.KeyDown
        If Me.txbTel.ReadOnly Then Return
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then Return
        If e.Shift AndAlso e.KeyCode <> Keys.D0 AndAlso e.KeyCode <> Keys.D9 Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then Me.txbHRNumber.Select() : Me.txbHRNumber.SelectAll() : e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        If (e.Shift AndAlso (e.KeyCode = Keys.D9 OrElse e.KeyCode = Keys.D0)) OrElse e.KeyCode = Keys.OemMinus OrElse e.KeyCode = Keys.Subtract OrElse e.KeyCode = Keys.Space Then Return
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbTel_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbTel.Leave
        If Me.txbTel.Text <> Me.txbTel.Text.Trim Then Me.txbTel.Text = Me.txbTel.Text.Trim
        If drUser("Tel").ToString <> Me.txbTel.Text Then
            drUser("Tel") = Me.txbTel.Text
            Me.CheckChanges()
        End If
    End Sub

    Private Sub chbLeaved_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbLeaved.CheckedChanged
        If blSkipDeal Then Return

        If Me.chbLeaved.Checked Then
            'Me.dtpJoinDate.Visible = False
            'Me.txbJoinDate.Visible = True
            Me.txbLeavedDate.Visible = False
            Me.txbLeavedDate.Text = Format(Me.dtpLeavedDate.Value, "yyyy\/MM\/dd")
            Me.dtpLeavedDate.Visible = True
            drUser("LeavedDate") = Me.dtpLeavedDate.Value
        Else
            'Me.dtpJoinDate.Visible = True
            'Me.txbLeavedDate.Visible = False
            Me.txbLeavedDate.Text = "（在职）"
            Me.txbLeavedDate.Visible = True
            Me.dtpLeavedDate.Visible = False
            drUser("LeavedDate") = DBNull.Value
        End If
        Me.CheckChanges()
    End Sub

    Private Sub dtpLeavedDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpLeavedDate.ValueChanged
        If blSkipDeal Then Return
        drUser("LeavedDate") = Me.dtpLeavedDate.Value
        Me.txbLeavedDate.Text = Format(Me.dtpLeavedDate.Value, "yyyy\/MM\/dd")
        Me.CheckChanges()
    End Sub

    Private Sub rtbRemarks_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles rtbRemarks.Leave
        If Me.rtbRemarks.Text <> Me.rtbRemarks.Text.Trim Then Me.rtbRemarks.Text = Me.rtbRemarks.Text.Trim
        If drUser("Remarks").ToString <> Me.rtbRemarks.Text Then
            drUser("Remarks") = Me.rtbRemarks.Text
            Me.CheckChanges()
        End If
    End Sub

    Private Sub rdbPending_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbPending.CheckedChanged
        If blSkipDeal OrElse Not Me.rdbPending.Checked Then Return
        Me.txbFailureReason.BackColor = SystemColors.Control
        If frmMain.dtAllowedRight.Select("RightName='UserModifyBefore'").Length = 0 Then
            Me.txbLoginName.ReadOnly = True : Me.txbLoginName.BackColor = SystemColors.Window : Me.txbLoginName.BackColor = SystemColors.Control
            Me.txbLocation.Visible = True : Me.cbbLocation.Visible = False
            Me.rdbNormal.Enabled = False : Me.rdbStopped.Enabled = False
            Me.txbRole.Visible = True : Me.cbbRole.Visible = False
            blCanselectArea = False
            Me.cbbArea.BackColor = SystemColors.Control
            Me.cklArea.BackColor = SystemColors.Control
            blCanSelectBusinessType = False
            Me.cbbBusinessType1.BackColor = SystemColors.Control
            Me.cbbBusinessType2.BackColor = SystemColors.Control
            Me.cklBusinessType.BackColor = SystemColors.Control
        Else
            Me.txbLoginName.ReadOnly = False : Me.txbLoginName.BackColor = SystemColors.Window
            Me.txbLocation.Visible = False : Me.cbbLocation.Visible = True
            Me.rdbNormal.Enabled = Not blIsNewUser : Me.rdbStopped.Enabled = Not blIsNewUser
            Me.txbRole.Visible = False : Me.cbbRole.Visible = True
            If dtControllableArea.Rows.Count > 1 Then
                blCanselectArea = True
                Me.cbbArea.BackColor = SystemColors.Window
                Me.cklArea.BackColor = SystemColors.Window
            End If
            blCanSelectBusinessType = True
            Me.cbbBusinessType1.BackColor = SystemColors.Window
            Me.cbbBusinessType2.BackColor = SystemColors.Window
            Me.cklBusinessType.BackColor = SystemColors.Window
        End If
        Me.cklArea.CheckOnClick = blCanselectArea
        Me.cklBusinessType.CheckOnClick = blCanSelectBusinessType
        Me.rdbNormal.Enabled = False : Me.rdbStopped.Enabled = False : Me.btnResetPassword.Enabled = False
        drUser("UserState") = 0 : drUser("StateReason") = "" : Me.CheckChanges()
    End Sub

    Private Sub rdbApproved_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbApproved.CheckedChanged
        If blSkipDeal OrElse Not Me.rdbApproved.Checked Then Return
        Me.txbFailureReason.BackColor = SystemColors.Control
        Me.txbLocation.Visible = True : Me.cbbLocation.Visible = False
        Me.txbRole.Visible = True : Me.cbbRole.Visible = False
        If frmMain.dtAllowedRight.Select("RightName='UserModifyAfter'").Length = 0 Then
            Me.txbLoginName.ReadOnly = True : Me.txbLoginName.BackColor = SystemColors.Window : Me.txbLoginName.BackColor = SystemColors.Control
            blCanselectArea = False
            Me.cbbArea.BackColor = SystemColors.Control
            Me.cklArea.BackColor = SystemColors.Control
            blCanSelectBusinessType = False
            Me.cbbBusinessType1.BackColor = SystemColors.Control
            Me.cbbBusinessType2.BackColor = SystemColors.Control
            Me.cklBusinessType.BackColor = SystemColors.Control
        Else
            Me.txbLoginName.ReadOnly = False : Me.txbLoginName.BackColor = SystemColors.Window
            If dtControllableArea.Rows.Count > 1 Then
                blCanselectArea = True
                Me.cbbArea.BackColor = SystemColors.Window
                Me.cklArea.BackColor = SystemColors.Window
            End If
            blCanSelectBusinessType = True
            Me.cbbBusinessType1.BackColor = SystemColors.Window
            Me.cbbBusinessType2.BackColor = SystemColors.Window
            Me.cklBusinessType.BackColor = SystemColors.Window
        End If
        Me.cklArea.CheckOnClick = blCanselectArea
        Me.cklBusinessType.CheckOnClick = blCanSelectBusinessType
        drUser("UserState") = 2 : drUser("StateReason") = "" : Me.CheckChanges()
        If blIsNewUser Then Return
        If frmMain.dtAllowedRight.Select("RightName='UserStop'").Length = 0 Then
            Me.rdbNormal.Enabled = False : Me.rdbStopped.Enabled = False
        Else
            Me.rdbNormal.Enabled = True : Me.rdbStopped.Enabled = True
        End If
        If drUser("UserState", DataRowVersion.Original) = 2 AndAlso (drUser("NeedChangePassword") OrElse drUser("NeedResetPassword")) Then Me.btnResetPassword.Enabled = True
    End Sub

    Private Sub rdbFailure_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbFailure.CheckedChanged
        Me.txbFailureReason.ReadOnly = Not Me.rdbFailure.Checked
        If blSkipDeal OrElse Not Me.rdbFailure.Checked Then Return
        Me.txbFailureReason.BackColor = SystemColors.Window
        If frmMain.dtAllowedRight.Select("RightName='UserModifyBefore'").Length = 0 Then
            Me.txbLoginName.ReadOnly = True : Me.txbLoginName.BackColor = SystemColors.Window : Me.txbLoginName.BackColor = SystemColors.Control
            Me.txbLocation.Visible = True : Me.cbbLocation.Visible = False
            Me.rdbNormal.Enabled = False : Me.rdbStopped.Enabled = False
            Me.txbRole.Visible = True : Me.cbbRole.Visible = False
            blCanselectArea = False
            Me.cbbArea.BackColor = SystemColors.Control
            Me.cklArea.BackColor = SystemColors.Control
            blCanSelectBusinessType = False
            Me.cbbBusinessType1.BackColor = SystemColors.Control
            Me.cbbBusinessType2.BackColor = SystemColors.Control
            Me.cklBusinessType.BackColor = SystemColors.Control
        Else
            Me.txbLoginName.ReadOnly = False : Me.txbLoginName.BackColor = SystemColors.Window
            Me.txbLocation.Visible = False : Me.cbbLocation.Visible = True
            Me.rdbNormal.Enabled = True : Me.rdbStopped.Enabled = True
            Me.txbRole.Visible = False : Me.cbbRole.Visible = True
            If dtControllableArea.Rows.Count > 1 Then
                blCanselectArea = True
                Me.cbbArea.BackColor = SystemColors.Window
                Me.cklArea.BackColor = SystemColors.Window
            End If
            blCanSelectBusinessType = True
            Me.cbbBusinessType1.BackColor = SystemColors.Window
            Me.cbbBusinessType2.BackColor = SystemColors.Window
            Me.cklBusinessType.BackColor = SystemColors.Window
        End If
        Me.cklArea.CheckOnClick = blCanselectArea
        Me.cklBusinessType.CheckOnClick = blCanSelectBusinessType
        Me.rdbNormal.Enabled = False : Me.rdbStopped.Enabled = False : Me.btnResetPassword.Enabled = False
        drUser("UserState") = 1 : drUser("StateReason") = Me.txbFailureReason.Text.Trim : Me.CheckChanges()
        Me.txbFailureReason.Select() : Me.txbFailureReason.SelectAll()
    End Sub

    Private Sub txbFailureReason_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbFailureReason.Leave
        If Me.txbFailureReason.Text <> Me.txbFailureReason.Text.Trim Then Me.txbFailureReason.Text = Me.txbFailureReason.Text.Trim
        If drUser("StateReason").ToString <> Me.txbFailureReason.Text Then
            drUser("StateReason") = Me.txbFailureReason.Text
            Me.CheckChanges()
        End If
    End Sub

    Private Sub rdbNormal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbNormal.CheckedChanged
        Me.txbStoppedReason.ReadOnly = Me.rdbNormal.Checked
        If blSkipDeal Then Return
        Me.txbStoppedReason.BackColor = IIf(Me.rdbNormal.Checked, SystemColors.Control, SystemColors.Window)
        If Me.rdbNormal.Checked Then
            drUser("UserState") = 2
            drUser("StateReason") = DBNull.Value
            If frmMain.dtAllowedRight.Select("RightName='UserModifyAfter'").Length > 0 Then
                Me.txbLoginName.ReadOnly = False : Me.txbLoginName.BackColor = SystemColors.Window
                If Not drUser("IsLogin") Then
                    Me.txbLocation.Visible = False : Me.cbbLocation.Visible = True
                    Me.txbRole.Visible = False : Me.cbbRole.Visible = True
                End If

                If dtControllableArea.Rows.Count > 1 Then
                    blCanselectArea = True
                    Me.cbbArea.BackColor = SystemColors.Window
                    Me.cklArea.BackColor = SystemColors.Window
                End If

                blCanSelectBusinessType = True
                Me.cbbBusinessType1.BackColor = SystemColors.Window
                Me.cbbBusinessType2.BackColor = SystemColors.Window
                Me.cklBusinessType.BackColor = SystemColors.Window
            End If

            If frmMain.dtAllowedRight.Select("RightName Like 'UserModify%'").Length > 0 Then
                Me.txbHRNumber.ReadOnly = False
                Me.txbHRNumber.BackColor = SystemColors.Window
                'Me.txbUserChineseName.ReadOnly = False
                'Me.txbUserChineseName.BackColor = SystemColors.Window
                'Me.txbUserEnglishName.ReadOnly = False
                'Me.txbUserEnglishName.BackColor = SystemColors.Window
                'Me.rdbMan.Enabled = True
                'Me.rdbFemale.Enabled = True
                'Me.dtpJoinDate.Visible = Not Me.chbLeaved.Checked
                'Me.txbJoinDate.Visible = Me.chbLeaved.Checked
                Me.txbTel.ReadOnly = False
                Me.txbTel.BackColor = SystemColors.Window
                Me.chbLeaved.Enabled = True
                Me.dtpLeavedDate.Visible = Me.chbLeaved.Checked
                Me.txbLeavedDate.Visible = Not Me.chbLeaved.Checked
                Me.rtbRemarks.ReadOnly = False
                Me.rtbRemarks.BackColor = SystemColors.Window
            End If

            If Not drUser("IsLogin") AndAlso frmMain.dtAllowedRight.Select("RightName='UserStop'").Length > 0 Then
                Me.rdbPending.Enabled = True : Me.rdbFailure.Enabled = True
            End If

            If sUserID <> "-1" AndAlso drUser("UserState", DataRowVersion.Original) = 2 AndAlso (drUser("NeedChangePassword") OrElse drUser("NeedResetPassword")) Then Me.btnResetPassword.Enabled = True
        Else
            drUser("UserState") = 3
            If Me.txbStoppedReason.Text <> "" Then drUser("StateReason") = Me.txbStoppedReason.Text
            Me.txbLoginName.ReadOnly = True : Me.txbLoginName.BackColor = SystemColors.Window : Me.txbLoginName.BackColor = SystemColors.Control
            Me.txbLocation.Visible = True : Me.cbbLocation.Visible = False
            Me.txbHRNumber.ReadOnly = True : Me.txbHRNumber.BackColor = SystemColors.Window : Me.txbHRNumber.BackColor = SystemColors.Control
            'Me.txbUserChineseName.ReadOnly = True : Me.txbUserChineseName.BackColor = SystemColors.Window : Me.txbUserChineseName.BackColor = SystemColors.Control
            'Me.txbUserEnglishName.ReadOnly = True : Me.txbUserEnglishName.BackColor = SystemColors.Window : Me.txbUserEnglishName.BackColor = SystemColors.Control
            'Me.rdbMan.Enabled = False
            'Me.rdbFemale.Enabled = False
            'Me.dtpJoinDate.Visible = False
            'Me.txbJoinDate.Visible = True
            Me.txbTel.ReadOnly = True : Me.txbTel.BackColor = SystemColors.Window : Me.txbTel.BackColor = SystemColors.Control
            Me.chbLeaved.Enabled = False
            Me.dtpLeavedDate.Visible = False
            Me.txbLeavedDate.Visible = True
            Me.rtbRemarks.ReadOnly = True : Me.rtbRemarks.BackColor = SystemColors.Window : Me.rtbRemarks.BackColor = SystemColors.Control
            Me.rdbPending.Enabled = False : Me.rdbFailure.Enabled = False
            Me.txbRole.Visible = True : Me.cbbRole.Visible = False
            blCanselectArea = False
            Me.cbbArea.BackColor = SystemColors.Control
            Me.cklArea.BackColor = SystemColors.Control
            blCanSelectBusinessType = False
            Me.cbbBusinessType1.BackColor = SystemColors.Control
            Me.cbbBusinessType2.BackColor = SystemColors.Control
            Me.cklBusinessType.BackColor = SystemColors.Control
            Me.btnResetPassword.Enabled = False
            Me.txbStoppedReason.Select() : Me.txbStoppedReason.SelectAll()
        End If
        Me.cklArea.CheckOnClick = blCanselectArea
        Me.cklBusinessType.CheckOnClick = blCanSelectBusinessType
        Me.CheckChanges()
    End Sub

    Private Sub txbStoppedReason_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbStoppedReason.Leave
        If Me.txbStoppedReason.ReadOnly Then Return
        If Me.txbStoppedReason.Text <> Me.txbStoppedReason.Text.Trim Then Me.txbStoppedReason.Text = Me.txbStoppedReason.Text.Trim
        If drUser("StateReason").ToString <> Me.txbStoppedReason.Text Then
            If Me.txbLoginName.Text = "" Then
                drUser("StateReason") = DBNull.Value
            Else
                drUser("StateReason") = Me.txbStoppedReason.Text
            End If
            Me.CheckChanges()
        End If
    End Sub

    Private Sub cbbRole_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbRole.SelectedIndexChanged
        If blSkipDeal Then Return
        sRoleID = Me.cbbRole.SelectedValue.ToString : drUser("RoleID") = sRoleID
        Me.SetRightAllowed()

        If sRoleID = 6 Then '指导店长
            drUser("AreaID") = dtArea.Select("AreaID=" & sLocationID)(0)("ParentAreaID")
        Else
            drUser("AreaID") = sLocationID
        End If
        drUser("ControllableAreas") = "All"
        blCanselectArea = True
        dtControllableArea.Rows.Clear()
        Dim sAreaType As String = dtArea.Select("AreaID=" & drUser("AreaID").ToString)(0)("AreaType").ToString, drArea As DataRow
        If sAreaType = "S" Then
            drArea = dtArea.Select("AreaID=" & drUser("AreaID").ToString)(0)
            dtControllableArea.Rows.Add(drArea("AreaID"), (drArea("AreaType").ToString & drArea("AreaCode").ToString & " " & drArea("AreaChineseName").ToString & " " & drArea("AreaEnglishName").ToString).Trim)
        Else
            For Each drArea In dtArea.Select("ParentAreaID=" & drUser("AreaID").ToString, "AreaCode")
                dtControllableArea.Rows.Add(drArea("AreaID"), (drArea("AreaType").ToString & drArea("AreaCode").ToString & " " & drArea("AreaChineseName").ToString & " " & drArea("AreaEnglishName").ToString).Trim)
            Next
        End If
        dtControllableArea.AcceptChanges()
        If dtControllableArea.Rows.Count = 1 Then blCanselectArea = False
        blSkipDeal = True : Me.SetControllableAreas() : blSkipDeal = False
        Me.txbRole.Text = Me.cbbRole.Text
        If sUserID = "-1" Then Me.NameStandardization()
        Me.CheckChanges()
    End Sub

    Private Sub cbbArea_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbArea.DropDown
        If blSkipDeal Then Return
        blSkipDeal = True
        Me.cbbArea.DroppedDown = True
        If Me.cklArea.Visible Then
            Me.cklArea.Visible = False
        Else
            Me.cklArea.Visible = True
            Me.cklArea.Select()
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
        If blCanselectArea Then
            blSkipDeal = True
            Dim sItem As String = Me.cklArea.Items(e.Index).ToString
            If sItem.IndexOf("(所有") = 0 Then
                For iItem As Integer = 1 To Me.cklArea.Items.Count - 1
                    Me.cklArea.SetItemChecked(iItem, e.NewValue = CheckState.Checked)
                Next
            ElseIf Me.cklArea.Items(0).ToString.IndexOf("(所有") = 0 Then
                If e.NewValue = CheckState.Unchecked Then
                    Me.cklArea.SetItemChecked(0, False)
                Else
                    Me.cklArea.SetItemChecked(0, Me.cklArea.CheckedItems.Count = Me.cklArea.Items.Count - 2)
                End If
            End If
            blSkipDeal = False
            If Me.cklArea.CheckedItems.Count + IIf(e.NewValue = CheckState.Checked, 1, -1) = Me.cklArea.Items.Count Then '全选
                drUser("ControllableAreas") = "All"
                Me.cbbArea.Text = Me.cklArea.Items(0).ToString
            ElseIf Me.cklArea.CheckedItems.Count + IIf(e.NewValue = CheckState.Checked, 1, -1) = 0 Then
                drUser("ControllableAreas") = ""
                Me.cbbArea.Text = "(无 Nothing)"
            Else
                Dim sAreaIDs As String = "|", sAreaNames As String = ""
                For iItem As Integer = 1 To Me.cklArea.Items.Count - 1
                    If (iItem = e.Index AndAlso e.NewValue = CheckState.Checked) OrElse (iItem <> e.Index AndAlso Me.cklArea.GetItemChecked(iItem)) Then
                        sAreaIDs = sAreaIDs & dtControllableArea.Rows(iItem - 1)("AreaID").ToString & "|"
                        If sAreaNames = "" Then sAreaNames = Me.cklArea.Items(iItem).ToString.Substring(5)
                    End If
                Next
                drUser("ControllableAreas") = sAreaIDs
                Me.cbbArea.Text = sAreaNames & IIf(Me.cklArea.CheckedItems.Count + IIf(e.NewValue = CheckState.Checked, 1, -1) = 1, "", ", ...")
            End If
            Me.CheckChanges()
        Else
            e.NewValue = e.CurrentValue
        End If
    End Sub

    Private Sub cklArea_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cklArea.Leave
        If Me.cklArea.CheckedItems.Count = 0 Then
            Me.cklArea.SetItemChecked(0, True)
        End If
        Dim controlBounds As Rectangle = Me.cbbArea.Bounds
        controlBounds.Offset(Me.cbbArea.Width - 17, 0)
        controlBounds.Width = 17
        If Not controlBounds.Contains(Me.PointToClient(Control.MousePosition)) Then Me.cklArea.Visible = False : Me.cbbArea.SelectionLength = 0 '鼠标点在点在下拉箭头之外
        controlBounds = Nothing
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub cbbBusinessType1_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbBusinessType1.DropDown
        If blSkipDeal Then Return
        blSkipDeal = True
        Me.cbbBusinessType1.DroppedDown = True
        If Me.cklBusinessType.Visible Then
            Me.cklBusinessType.Visible = False
            Me.cbbBusinessType1.Text = sOldName
        Else
            Me.cklBusinessType.Visible = True
            Me.cklBusinessType.Select()
            For bItem As Byte = 0 To Me.cklBusinessType.Items.Count - 1
                If Me.cklBusinessType.GetItemChecked(bItem) Then Me.cklBusinessType.SetSelected(bItem, True) : Exit For
            Next
        End If
        blSkipDeal = False
    End Sub

    Private Sub cbbBusinessType1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbBusinessType1.Enter
        sOldName = Me.cbbBusinessType1.Text
    End Sub

    Private Sub cbbBusinessType1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbbBusinessType1.KeyPress
        e.Handled = True
        Me.cbbBusinessType1.SelectAll()
    End Sub

    Private Sub cbbBusinessType1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbBusinessType1.Leave
        Me.cbbBusinessType1.SelectionLength = 0
    End Sub

    Private Sub cbbBusinessType1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cbbBusinessType1.MouseDown, cbbBusinessType1.MouseUp
        My.Computer.Clipboard.Clear()
        If Me.cbbBusinessType1.Text = "" Then
            Me.cbbBusinessType1.Text = sOldName
            Me.cbbBusinessType1.SelectAll()
        End If
    End Sub

    Private Sub cklBusinessType_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles cklBusinessType.ItemCheck
        If blSkipDeal Then Return
        If blCanSelectBusinessType Then
            blSkipDeal = True
            Dim sItem As String = Me.cklBusinessType.Items(e.Index).ToString
            If sItem.IndexOf("(所有商业类型") = 0 Then
                For iItem As Integer = 1 To Me.cklBusinessType.Items.Count - 1
                    Me.cklBusinessType.SetItemChecked(iItem, e.NewValue = CheckState.Checked)
                Next
            ElseIf Me.cklBusinessType.Items(0).ToString.IndexOf("(所有商业类型") = 0 Then
                If e.NewValue = CheckState.Unchecked Then
                    Me.cklBusinessType.SetItemChecked(0, False)
                Else
                    Me.cklBusinessType.SetItemChecked(0, Me.cklBusinessType.CheckedItems.Count = Me.cklBusinessType.Items.Count - 2)
                End If
            End If
            blSkipDeal = False
            If Me.cklBusinessType.CheckedItems.Count + IIf(e.NewValue = CheckState.Checked, 1, -1) = Me.cklBusinessType.Items.Count Then '全选
                drUser("ControllableBusinessTypes") = "All"
                Me.cbbBusinessType1.Text = Me.cklBusinessType.Items(0).ToString
            ElseIf Me.cklBusinessType.CheckedItems.Count + IIf(e.NewValue = CheckState.Checked, 1, -1) = 0 Then
                drUser("ControllableBusinessTypes") = ""
                Me.cbbBusinessType1.Text = "(没有商业类型 No Business Type)"
            Else
                Dim sBusinessTypeIDs As String = "|", sName As String = ""
                For iItem As Integer = 1 To Me.cklBusinessType.Items.Count - 1
                    If (iItem = e.Index AndAlso e.NewValue = CheckState.Checked) OrElse (iItem <> e.Index AndAlso Me.cklBusinessType.GetItemChecked(iItem)) Then
                        sBusinessTypeIDs = sBusinessTypeIDs & dvCityBusinessType(iItem - 1)("BusinessTypeID").ToString & "|"
                        If sName = "" Then sName = Me.cklBusinessType.Items(iItem).ToString.Substring(3)
                    End If
                Next
                drUser("ControllableBusinessTypes") = sBusinessTypeIDs
                Me.cbbBusinessType1.Text = sName & IIf(Me.cklBusinessType.CheckedItems.Count + IIf(e.NewValue = CheckState.Checked, 1, -1) = 1, "", ", ...")
            End If
            Me.CheckChanges()
        Else
            e.NewValue = e.CurrentValue
        End If
    End Sub

    Private Sub cklBusinessType_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cklBusinessType.Leave
        Dim controlBounds As Rectangle = Me.cbbBusinessType1.Bounds
        controlBounds.Offset(Me.cbbBusinessType1.Width - 17, 0)
        controlBounds.Width = 17
        If Not controlBounds.Contains(Me.PointToClient(Control.MousePosition)) Then Me.cklBusinessType.Visible = False : Me.cbbBusinessType1.SelectionLength = 0
        controlBounds = Nothing
    End Sub

    Private Sub txbLoginName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbLoginName.TextChanged, txbUserChineseName.TextChanged, txbUserEnglishName.TextChanged, txbTel.TextChanged, txbFailureReason.TextChanged, txbStoppedReason.TextChanged
        If blSkipDeal Then Return
        Me.CheckChanges()
    End Sub

    Private Sub btnResetPassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetPassword.Click
        Me.theTip.Active = False
        If drUser("UserCode").ToString = "999" OrElse sUserID = "160" Then 'National IT
            MessageBox.Show("该用户是测试用户，请不要修改密码！    " & Chr(13) & "Please don't change this testing user's password!    ", "修改密码失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If drUser("NeedResetPassword") AndAlso _
           MessageBox.Show("重置密码将清除原来的密码并由系统产生新的随机密码。    " & Chr(13) & _
                           "Resetting password will clear the old password and the system will build a new random one.    " & Chr(13) & Chr(13) & _
                           "是否继续 Do you want to continue?", "请确认重置密码 Please confirm to reset password:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Return
        End If

        Dim sPassword As String = Me.GetRandomPassword(), DB As New DataBase, dtResult As DataTable
        DB.Open(True)
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法重置用户的密码！"
            Return
        End If

        dtResult = DB.GetDataTable("Exec PasswordResetting " & sUserID & ",'" & SecurityText.EncryptData(sPassword) & "'," & frmMain.sSSID)
        If dtResult Is Nothing Then
            DB.Close()
            frmMain.statusText.Text = "系统因出现内部错误而无法重置用户的密码！"
            Return
        ElseIf dtResult.Rows(0)("Result").ToString <> "OK" Then
            If dtResult.Rows(0)("Result").ToString = "Failure" Then
                MessageBox.Show("系统发现已有人刚刚使用过当前密码正确地登录进系统，所以不允许您重置密码！    " & Chr(13) & "System rejected resetting the password since it had been used to login system by someone.    ", "系统拒绝重置密码 Requirement rejected!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.btnResetPassword.Enabled = False
            Else
                MessageBox.Show("重置密码时出现错误！下面是数据库的内部错误提示：    " & Chr(13) & Chr(13) & dtResult.Rows(0)("Reason").ToString & Space(4) & Chr(13) & Chr(13) & "请放弃重置密码，在关闭窗口后重试。如果仍有问题，请联系软件开发人员。    ", "重置密码失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            frmMain.statusText.Text = "重置密码失败！"
            dtResult.Dispose() : dtResult = Nothing
            DB.Close() : Return
        End If

        drUser("NeedChangePassword") = 1 : drUser("NeedResetPassword") = 0 : drUser("ResettingInfo") = ""
        dtResult.Dispose() : dtResult = Nothing : DB.Close()
        With frmResetPassword
            .Text = "重置密码成功 Resetting password successfully."
            .lblPromptChinese.Text = "该用户原来的密码已被清除，并被重置成由系统自动生成的随机密码。"
            .lblPromptEnglish.Text = "A new random password has been built to replace the old one."
            .lblUserName.Text = Me.txbAreaCode.Text & Me.txbUserCode.Text & " " & Me.txbLoginName.Text
            .lblPassword.Text = sPassword
            .rtbNamePassword.SelectionColor = Color.Black
            .rtbNamePassword.AppendText("用户名 User Name: ")
            .rtbNamePassword.SelectionColor = Color.Blue
            .rtbNamePassword.SelectionFont = New Font(.rtbNamePassword.Font, FontStyle.Bold)
            .rtbNamePassword.AppendText(Me.txbAreaCode.Text & Me.txbUserCode.Text & " " & Me.txbLoginName.Text)
            .rtbNamePassword.SelectionColor = Color.Black
            .rtbNamePassword.SelectionFont = New Font(.rtbNamePassword.Font, FontStyle.Regular)
            .rtbNamePassword.AppendText(Chr(10))
            .rtbNamePassword.AppendText("密  码 Password : ")
            .rtbNamePassword.SelectionColor = Color.Blue
            .rtbNamePassword.SelectionFont = New Font(.rtbNamePassword.Font, FontStyle.Bold)
            .rtbNamePassword.AppendText(sPassword)
            .rtbNamePassword.SelectionColor = Color.Black
            .rtbNamePassword.SelectionFont = New Font(.rtbNamePassword.Font, FontStyle.Regular)
            .rtbNamePassword.AppendText(Chr(10) & Chr(13))
            .ShowDialog()
            .Dispose()
        End With
        Me.theTip.SetToolTip(Me.btnResetPassword, "")
        If frmUserManagerment.IsHandleCreated Then
            Try
                Dim drUser As DataRow = frmUserManagerment.dvUser.Table.Rows.Find(sUserID)
                drUser("NeedResetPassword") = DBNull.Value
                drUser.AcceptChanges()
            Catch
            End Try
        End If
    End Sub

    Private Sub btnResetPassword_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResetPassword.MouseEnter
        If drUser("ResettingInfo").ToString <> "" Then
            Me.theTip.Active = True
        End If
    End Sub

    Private Sub btnResetPassword_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResetPassword.MouseLeave
        Me.theTip.Active = False
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Me.SaveChanges() AndAlso (Not Me.rdbApproved.Enabled OrElse Me.rdbApproved.Checked) Then Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub FillRight(ByVal tncCurrent As TreeNodeCollection, ByVal sParentID As String)
        Try
            Dim newNode As TreeNode

            For Each dr As DataRow In dtRight.Select("ParentRightID=" & sParentID)
                newNode = New TreeNode
                tncCurrent.Add(newNode)
                newNode.Name = dr("RightID").ToString
                newNode.Text = dr("EnglishDescription").ToString
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

    Private Sub FillUser()
        Me.txbAreaCode.Text = frmMain.dtLoginStructure.Select("AreaID=" & sLocationID)(0)("AreaCode").ToString
        Me.txbUserCode.Text = drUser("UserCode").ToString

        Me.txbLoginName.Text = drUser("LoginName").ToString
        If sUserID = frmMain.sLoginUserID OrElse (sUserID <> "-1" AndAlso (blIsReadOnly OrElse drUser("UserState") = 3 OrElse _
           (drUser("UserState") < 2 AndAlso frmMain.dtAllowedRight.Select("RightName='UserModifyBefore'").Length = 0) OrElse _
           (drUser("UserState") = 2 AndAlso frmMain.dtAllowedRight.Select("RightName In ('UserValidate','UserModifyAfter')").Length = 0))) Then
            Me.txbLoginName.ReadOnly = True
            Me.txbLoginName.BackColor = SystemColors.Window
            Me.txbLoginName.BackColor = SystemColors.Control
        Else
            Me.txbLoginName.ReadOnly = False
            Me.txbLoginName.BackColor = SystemColors.Window
        End If

        Me.txbLocation.Text = frmMain.dtLoginStructure.Select("AreaID=" & sLocationID)(0)("AreaFullName").ToString
        Me.cbbLocation.Text = Me.txbLocation.Text
        If drUser("UserState") > 1 OrElse sUserID = frmMain.sLoginUserID OrElse (sUserID <> "-1" AndAlso frmMain.dtAllowedRight.Select("RightName='UserModifyBefore'").Length = 0) Then
            Me.cbbLocation.Visible = False
            Me.txbLocation.Visible = True
        Else
            Me.cbbLocation.Visible = True
            Me.txbLocation.Visible = False
        End If
        frmDropDownArea.mainControl = Me.cbbLocation

        Me.txbHRNumber.Text = drUser("HRNumber").ToString
        Me.txbUserChineseName.Text = drUser("UserChineseName").ToString
        Me.txbUserEnglishName.Text = drUser("UserEnglishName").ToString
        If drUser("Sex") Then
            Me.rdbMan.Checked = True : Me.rdbFemale.Checked = False
        Else
            Me.rdbMan.Checked = False : Me.rdbFemale.Checked = True
        End If
        Me.dtpJoinDate.MinDate = "1900/1/1"
        Me.dtpJoinDate.MaxDate = Today()
        If drUser("JoinDate").ToString = "" OrElse Not IsDate(drUser("JoinDate").ToString) Then drUser("JoinDate") = "2000-1-1"
        Me.dtpJoinDate.Value = drUser("JoinDate")
        Me.txbJoinDate.Text = Format(drUser("JoinDate"), "yyyy\/MM\/dd")
        Me.txbTel.Text = drUser("Tel").ToString
        Me.dtpLeavedDate.MinDate = drUser("JoinDate")
        Me.dtpLeavedDate.MaxDate = Today()
        If IsDate(drUser("LeavedDate").ToString) Then
            Me.chbLeaved.Checked = True
            Me.dtpLeavedDate.Value = drUser("LeavedDate")
            Me.txbLeavedDate.Text = Format(drUser("LeavedDate"), "yyyy\/MM\/dd")
        Else
            Me.chbLeaved.Checked = False
            Me.dtpLeavedDate.Value = Today()
            Me.dtpLeavedDate.Visible = False
            Me.txbLeavedDate.Text = "（在职）"
            Me.txbLeavedDate.Visible = True
        End If
        Me.rtbRemarks.AppendText(drUser("Remarks").ToString)
        If sUserID <> "-1" AndAlso (blIsReadOnly OrElse drUser("UserState") = 3 OrElse frmMain.dtAllowedRight.Select("RightName Like 'UserModify%'").Length = 0) Then
            Me.txbHRNumber.ReadOnly = True : Me.txbHRNumber.BackColor = SystemColors.Window : Me.txbHRNumber.BackColor = SystemColors.Control
            'Me.txbUserChineseName.ReadOnly = True : Me.txbUserChineseName.BackColor = SystemColors.Window : Me.txbUserChineseName.BackColor = SystemColors.Control
            'Me.txbUserEnglishName.ReadOnly = True : Me.txbUserEnglishName.BackColor = SystemColors.Window : Me.txbUserEnglishName.BackColor = SystemColors.Control
            'Me.rdbMan.Enabled = False
            'Me.rdbFemale.Enabled = False
            'Me.dtpJoinDate.Visible = False
            'Me.txbJoinDate.Visible = True
            Me.txbTel.ReadOnly = True : Me.txbTel.BackColor = SystemColors.Window : Me.txbTel.BackColor = SystemColors.Control
            Me.chbLeaved.Enabled = False
            Me.dtpLeavedDate.Visible = False
            Me.txbLeavedDate.Visible = True
            Me.rtbRemarks.ReadOnly = True : Me.rtbRemarks.BackColor = SystemColors.Window : Me.rtbRemarks.BackColor = SystemColors.Control
        Else
            Me.txbHRNumber.ReadOnly = False
            Me.txbHRNumber.BackColor = SystemColors.Window
            'Me.txbUserChineseName.ReadOnly = False
            'Me.txbUserChineseName.BackColor = SystemColors.Window
            'Me.txbUserEnglishName.ReadOnly = False
            'Me.txbUserEnglishName.BackColor = SystemColors.Window
            'Me.rdbMan.Enabled = True
            'Me.rdbFemale.Enabled = True
            'Me.dtpJoinDate.Visible = Not Me.chbLeaved.Checked
            'Me.txbJoinDate.Visible = Me.chbLeaved.Checked
            Me.txbTel.ReadOnly = False
            Me.txbTel.BackColor = SystemColors.Window
            Me.chbLeaved.Enabled = (sUserID <> "-1")
            Me.dtpLeavedDate.Visible = Me.chbLeaved.Checked
            Me.txbLeavedDate.Visible = Not Me.chbLeaved.Checked
            Me.rtbRemarks.ReadOnly = False
            Me.rtbRemarks.BackColor = SystemColors.Window
        End If

        Select Case drUser("UserState")
            Case 0
                Me.rdbPending.Checked = True
            Case 1
                Me.rdbFailure.Checked = True
                Me.txbFailureReason.Text = drUser("StateReason").ToString
            Case Else
                Me.rdbApproved.Checked = True
        End Select
        If sUserID = "-1" OrElse sUserID = frmMain.sLoginUserID OrElse frmMain.dtAllowedRight.Select("RightName='UserValidate'").Length = 0 OrElse sControllableRoles.IndexOf("|" & sRoleID & "|") = -1 Then
            Me.rdbApproved.Enabled = False
            Me.rdbFailure.Enabled = False
            Me.txbFailureReason.ReadOnly = True
            Me.txbFailureReason.BackColor = SystemColors.Window
            Me.txbFailureReason.BackColor = SystemColors.Control
        Else
            Me.rdbApproved.Enabled = True
            Me.rdbFailure.Enabled = True
            Me.txbFailureReason.ReadOnly = Not Me.rdbFailure.Checked
            Me.txbFailureReason.BackColor = SystemColors.Window
            Me.txbFailureReason.BackColor = IIf(Me.rdbFailure.Checked, SystemColors.Window, SystemColors.Control)
        End If
        If drUser("IsLogin") Then
            Me.rdbPending.Enabled = False
            Me.rdbFailure.Enabled = False
        End If

        If drUser("UserState") = 3 Then
            Me.rdbStopped.Checked = True
            Me.txbStoppedReason.Text = drUser("StateReason").ToString
            Me.rdbPending.Enabled = False
            Me.rdbFailure.Enabled = False
        Else
            Me.rdbNormal.Checked = True
        End If
        If drUser("UserState") < 2 OrElse sUserID = frmMain.sLoginUserID OrElse frmMain.dtAllowedRight.Select("RightName='UserStop'").Length = 0 OrElse sControllableRoles.IndexOf("|" & sRoleID & "|") = -1 Then
            Me.rdbNormal.Enabled = False
            Me.rdbStopped.Enabled = False
            Me.txbStoppedReason.ReadOnly = True
            Me.txbStoppedReason.BackColor = SystemColors.Window
            Me.txbStoppedReason.BackColor = SystemColors.Control
        Else
            Me.rdbNormal.Enabled = True
            Me.rdbStopped.Enabled = True
            Me.txbStoppedReason.ReadOnly = Me.rdbNormal.Checked
            Me.txbStoppedReason.BackColor = SystemColors.Window
            Me.txbStoppedReason.BackColor = IIf(Me.rdbStopped.Checked, SystemColors.Window, SystemColors.Control)
        End If

        Me.lblCreator.Text = drUser("Creator").ToString
        If IsDate(drUser("CreatedTime").ToString) Then Me.lblCreatedTime.Text = Format(drUser("CreatedTime"), "yyyy\/MM\/dd HH:mm:ss")
        Me.lblModifier.Text = drUser("Modifier").ToString
        If IsDate(drUser("ModifiedTime").ToString) Then Me.lblModifiedTime.Text = Format(drUser("ModifiedTime"), "yyyy\/MM\/dd HH:mm:ss")
        Me.lblAuditor.Text = drUser("Auditor").ToString
        If IsDate(drUser("ValidatedTime").ToString) Then Me.lblValidatedTime.Text = Format(drUser("ValidatedTime"), "yyyy\/MM\/dd HH:mm:ss")

        Dim drRole As DataRow = dtRole.Select("RoleID=" & sRoleID)(0)
        Me.txbRole.Text = Trim(drRole("RoleCode").ToString & " " & drRole("RoleChineseName").ToString & " " & drRole("RoleEnglishName").ToString)
        dtAllowedRole = New DataTable
        dtAllowedRole.Columns.Add("RoleID", System.Type.GetType("System.Byte"))
        dtAllowedRole.Columns.Add("RoleFullName", System.Type.GetType("System.String"))
        For Each drRole In dtRole.Select("AcceptAreas Like '%|" & sLocationType & "|%'", "RoleCode")
            If sControllableRoles.IndexOf("|" & drRole("RoleID").ToString & "|") > -1 Then
                dtAllowedRole.Rows.Add(drRole("RoleID"), Trim(drRole("RoleCode").ToString & " " & drRole("RoleChineseName").ToString & " " & drRole("RoleEnglishName").ToString))
            End If
        Next
        dtAllowedRole.AcceptChanges()
        Me.cbbRole.DataSource = dtAllowedRole
        Me.cbbRole.ValueMember = "RoleID"
        Me.cbbRole.DisplayMember = "RoleFullName"
        If dtAllowedRole.Select("RoleID=" & sRoleID).Length > 0 Then
            Me.cbbRole.SelectedValue = sRoleID
        End If
        If drUser("UserState") > 1 OrElse sUserID = frmMain.sLoginUserID OrElse (sUserID <> "-1" AndAlso frmMain.dtAllowedRight.Select("RightName='UserModifyBefore'").Length = 0) Then
            Me.cbbRole.Visible = False
            Me.txbRole.Visible = True
        Else
            Me.cbbRole.Visible = True
            Me.txbRole.Visible = False
        End If

        Me.SetRightAllowed()

        If sUserID <> "-1" AndAlso (blIsReadOnly OrElse drUser("UserState") = 3 OrElse sUserID = frmMain.sLoginUserID OrElse _
          (drUser("UserState") < 2 AndAlso frmMain.dtAllowedRight.Select("RightName='UserModifyBefore'").Length = 0) OrElse _
          (drUser("UserState") = 2 AndAlso frmMain.dtAllowedRight.Select("RightName='UserModifyAfter'").Length = 0)) Then
            blCanselectArea = False : blCanSelectBusinessType = False
        Else
            blCanselectArea = True : blCanSelectBusinessType = True
        End If

        dtControllableArea = New DataTable
        dtControllableArea.Columns.Add("AreaID", System.Type.GetType("System.Int16"))
        dtControllableArea.Columns.Add("AreaFullName", System.Type.GetType("System.String"))
        Dim sAreaType As String = dtArea.Select("AreaID=" & drUser("AreaID").ToString)(0)("AreaType").ToString, drArea As DataRow
        If sAreaType = "S" Then
            drArea = dtArea.Select("AreaID=" & drUser("AreaID").ToString)(0)
            dtControllableArea.Rows.Add(drArea("AreaID"), (drArea("AreaType").ToString & drArea("AreaCode").ToString & " " & drArea("AreaChineseName").ToString & " " & drArea("AreaEnglishName").ToString).Trim)
        Else
            For Each drArea In dtArea.Select("ParentAreaID=" & drUser("AreaID").ToString, "AreaCode")
                dtControllableArea.Rows.Add(drArea("AreaID"), (drArea("AreaType").ToString & drArea("AreaCode").ToString & " " & drArea("AreaChineseName").ToString & " " & drArea("AreaEnglishName").ToString).Trim)
            Next
        End If
        dtControllableArea.AcceptChanges()
        If dtControllableArea.Rows.Count = 1 Then blCanselectArea = False
        Me.SetControllableAreas()

        If sLocationType = "C" OrElse sLocationType = "S" Then
            Dim sCityID As String = sLocationID, sBusinessTypes = drUser("ControllableBusinessTypes").ToString
            If sLocationType = "S" Then
                sCityID = dtArea.Select("AreaID=" & sLocationID)(0)("ParentAreaID").ToString
            End If
            dvCityBusinessType.RowFilter = "CityID=" & sCityID
            If dvCityBusinessType.Count = 0 Then
                Me.cklBusinessType.Items.Add("(没有商业类型 No Business Type)", True)
                Me.cbbBusinessType1.Text = "(没有商业类型 No Business Type)"
                blCanSelectBusinessType = False
            Else
                For Each drType As DataRowView In dvCityBusinessType
                    Me.cklBusinessType.Items.Add(drType("BusinessTypeFullName").ToString, (sBusinessTypes = "All" OrElse sBusinessTypes.IndexOf("|" & drType("BusinessTypeID").ToString & "|") > -1))
                Next
                If dvCityBusinessType.Count > 1 Then
                    Me.cklBusinessType.Items.Insert(0, "(所有商业类型 All Business Types)")
                    If Me.cklBusinessType.CheckedItems.Count = dvCityBusinessType.Count Then
                        Me.cklBusinessType.SetItemChecked(0, True)
                    End If
                End If
                If Me.cklBusinessType.CheckedItems.Count = 0 Then
                    Me.cbbBusinessType1.Text = "(没有商业类型 No Business Type)"
                ElseIf Me.cklBusinessType.CheckedItems.Count = 1 Then
                    Me.cbbBusinessType1.Text = Me.cklBusinessType.CheckedItems(0).ToString.Substring(3)
                ElseIf Me.cklBusinessType.CheckedItems.Count = Me.cklBusinessType.Items.Count Then
                    Me.cbbBusinessType1.Text = "(所有商业类型 All Business Types)"
                Else
                    Me.cbbBusinessType1.Text = Me.cklBusinessType.CheckedItems(0).ToString.Substring(3) & ", ..."
                End If
            End If
            Me.cklBusinessType.Height = (IIf(Me.cklBusinessType.Items.Count <= 20, Me.cklBusinessType.Items.Count, 20) * 16) + 4
            Me.cklBusinessType.Top = Me.cbbBusinessType1.Top - Me.cklBusinessType.Height
            Me.cbbBusinessType1.Visible = True
            Me.cbbBusinessType2.Visible = False
        Else
            Me.cbbBusinessType1.Visible = False
            Me.cbbBusinessType2.Visible = True
            Me.cbbBusinessType2.SelectedIndex = 0
        End If
        If blCanSelectBusinessType Then
            Me.cbbBusinessType1.BackColor = SystemColors.Window
            Me.cbbBusinessType2.BackColor = SystemColors.Window
            Me.cklBusinessType.BackColor = SystemColors.Window
        Else
            Me.cbbBusinessType1.BackColor = SystemColors.Control
            Me.cbbBusinessType2.BackColor = SystemColors.Control
            Me.cklBusinessType.BackColor = SystemColors.Control
        End If
        Me.cklBusinessType.CheckOnClick = blCanSelectBusinessType

        If frmMain.dtAllowedRight.Select("RightName='UserResetPassword'").Length > 0 AndAlso drUser("UserState") = 2 AndAlso (drUser("NeedResetPassword") OrElse drUser("NeedChangePassword")) AndAlso sControllableRoles.IndexOf("|" & sRoleID & "|") > -1 Then
            Me.btnResetPassword.Enabled = True
            If drUser("ResettingInfo").ToString <> "" Then
                Me.theTip.SetToolTip(Me.btnResetPassword, "来自下面用户的重置密码请求： " & Chr(13) & "The requirement of resetting password from: " & Chr(13) & "--------------------------------------------" & Chr(13) & drUser("ResettingInfo").ToString)
                Dim newPosition As Point = Me.PointToScreen(Me.btnResetPassword.Location)
                newPosition = New Point(newPosition.X + Me.btnResetPassword.Width / 2, newPosition.Y + Me.btnResetPassword.Height / 2)
                Windows.Forms.Cursor.Position = newPosition
            End If
        Else
            Me.btnResetPassword.Enabled = False
        End If
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
        Me.trvRight.ExpandAll()
    End Sub

    Private Sub SetControllableAreas()
        Me.cklArea.Items.Clear()
        If dtControllableArea.Rows.Count = 1 Then
            Me.cklArea.Items.Add(dtControllableArea.Rows(0)("AreaFullName").ToString, True)
            Me.cbbArea.Text = Me.cklArea.Items(0).ToString.Substring(5)
        Else
            Dim sAreaType As String = dtArea.Select("AreaID=" & drUser("AreaID").ToString)(0)("AreaType").ToString, sControllableAreas As String = ""
            Select Case sAreaType
                Case "H"
                    sAreaType = "(所有大区 All Territories)"
                Case "T"
                    sAreaType = "(所有小区 All Regions)"
                Case "R"
                    sAreaType = "(所有城市 All Cities)"
                Case "C"
                    sAreaType = "(所有门店 All Stores)"
            End Select
            Me.cklArea.Items.Add(sAreaType, drUser("ControllableAreas").ToString = "All")
            For Each dr As DataRow In dtControllableArea.Rows
                Me.cklArea.Items.Add(dr("AreaFullName").ToString, drUser("ControllableAreas").ToString = "All" OrElse drUser("ControllableAreas").ToString.IndexOf("|" & dr("AreaID").ToString & "|") > -1)
                If sControllableAreas = "" AndAlso drUser("ControllableAreas").ToString.IndexOf("|" & dr("AreaID").ToString & "|") > -1 Then sControllableAreas = dr("AreaFullName").ToString.Substring(5)
            Next
            If drUser("ControllableAreas").ToString = "All" Then
                Me.cbbArea.Text = sAreaType
            Else
                Me.cbbArea.Text = sControllableAreas & IIf(Me.cklArea.CheckedItems.Count = 1, "", ", ...")
            End If
        End If
        If blCanselectArea Then
            Me.cbbArea.BackColor = SystemColors.Window
            Me.cklArea.BackColor = SystemColors.Window
            Me.cklArea.CheckOnClick = True
        Else
            Me.cbbArea.BackColor = SystemColors.Control
            Me.cklArea.BackColor = SystemColors.Control
            Me.cklArea.CheckOnClick = False
        End If
        Me.cklArea.Height = IIf(Me.cklArea.Items.Count < 21, Me.cklArea.Items.Count, 20) * 16 + 4
        Me.cklArea.Top = Me.cbbArea.Top - Me.cklArea.Height
    End Sub

    Private Function GetRandomPassword() As String
        Dim saCharaters() = New String() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
        Dim sPassword As String = ""
        For bIndex As Byte = 0 To 7
            Randomize()
            sPassword = sPassword & saCharaters(CInt(Int(((saCharaters.Length - 1) * Rnd()))))
        Next
        Return sPassword
    End Function

    Private Sub NameStandardization()
        Dim sAreaName As String = "", sPositionName As String = "", sStardandName As String = Me.txbLoginName.Text
        sAreaName = frmMain.dtLoginStructure.Rows.Find(drUser("AreaID").ToString)("AreaEnglishName").ToString
        If sAreaName.LastIndexOf(" ") > -1 Then sAreaName = sAreaName.Substring(0, sAreaName.LastIndexOf(" "))
        Select Case drUser("RoleID")
            Case 6 '指导店长
                sPositionName = "Store Manager Pilot"
            Case 7 '城市财务经理
                sPositionName = "JV"
            Case 9 '城市经理
                sPositionName = "City SC Manager"
            Case 11 '店长
                sPositionName = "Store Manager"
            Case 12 '门店主管
                sPositionName = "SC Chief"
            Case 14 '售卡员
                sPositionName = "SC Counter Staff"
            Case 16 '门店绩效经理
                sPositionName = "Reporting"
            Case 22 '小区购物卡经理
                sPositionName = "Regional SC Manager"
        End Select

        If sPositionName = "" Then
            If sStardandName.IndexOf("Store Manager Pilot") = 0 OrElse sStardandName.IndexOf("JV") = 0 OrElse sStardandName.IndexOf("City SC Manager") = 0 OrElse sStardandName.IndexOf("Store Manager") = 0 OrElse sStardandName.IndexOf("SC Chief") = 0 OrElse sStardandName.IndexOf("SC Counter Staff") = 0 OrElse sStardandName.IndexOf("Reporting") = 0 OrElse sStardandName.IndexOf("Regional SC Manager") = 0 Then sStardandName = ""
        Else
            Dim iCount As Int16 = 0
            Do
                sStardandName = sPositionName & IIf(iCount = 0, " ", " " & iCount.ToString & " ") & sAreaName
                If frmUserManagerment.dvUser.Table.Select("LocationID=" & drUser("LocationID").ToString & " And LoginName='" & sStardandName.Replace("''", "''") & "'").Length = 0 Then
                    Exit Do
                Else
                    iCount += 1
                End If
            Loop
        End If

        drUser("LoginName") = sStardandName
        Me.txbLoginName.Text = sStardandName
        Me.CheckChanges()
    End Sub

    Private Sub CheckChanges()
        If sUserID = "-1" Then Me.btnSave.Enabled = True : Return

        If drUser.RowState = DataRowState.Modified Then
            For bColumn As Byte = 0 To drUser.Table.Columns.Count - 1
                If drUser(bColumn).ToString <> drUser(bColumn, DataRowVersion.Original).ToString Then
                    Me.btnSave.Enabled = True : Return
                End If
            Next
        End If

        drUser.AcceptChanges()
        Me.btnSave.Enabled = False
    End Sub

    Private Function SaveChanges() As Boolean
        Me.btnSave.Select()
        If drUser("LoginName").ToString = "" Then
            MessageBox.Show("用户登录名称不能为空！    ", "请输入登录名称。", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.txbLoginName.Select()
            Me.btnSave.Enabled = False
            Return False
        End If

        If sHRNumberErrorInfo <> "" OrElse drUser("HRNumber").ToString = "" Then
            Select Case sHRNumberErrorInfo
                Case "从Payroll系统中找不到此员工！"
                    MessageBox.Show("从Payroll系统中找不到此员工！    ", "员工编号无效！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Case "员工状态无效！不能为此员工建立账号！"
                    MessageBox.Show("员工状态无效！不能为此员工建立账号！    ", "员工状态无效！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Case Else
                    MessageBox.Show("员工编号是用于检查用户合法性的必要信息之一，所以不能为空！    " & Chr(13) & Chr(13) & "（注意：总部将不定期到公司HR系统检查该员工是否存在。若不存在，该登录名将被停用！）    ", "请输入员工编号名称。", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Select
            frmMain.statusText.Text = sHRNumberErrorInfo
            Me.txbHRNumber.Select() : Me.txbHRNumber.SelectAll()
            Me.btnSave.Enabled = False
            Return False
        End If

        If drUser("UserChineseName").ToString & drUser("UserEnglishName").ToString = "" Then
            MessageBox.Show("员工姓名是用于检查用户合法性的必要信息之一，所以至少需要一个中文名称或英文名称！    " & Chr(13) & Chr(13) & "（注意：总部将不定期到公司HR系统检查该员工是否存在。若不存在，该登录名将被停用！）    ", "请输入员工姓名。", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.txbUserChineseName.Select()
            Me.btnSave.Enabled = False
            Return False
        End If

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在保存用户……"
        frmMain.statusMain.Refresh()

        Dim DB As New DataBase, sSQL As String = "", dtResult As DataTable
        DB.Open(True)
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "保存用户失败！"
            Me.Cursor = Cursors.Default
            Return False
        End If

        If sUserID = "-1" Then
            sSQL = "Exec UserInsertion @LoginName='" & drUser("LoginName").ToString.Replace("'", "''") & "',@LocationID=" & sLocationID & ",@AreaID=" & drUser("AreaID").ToString & ",@RoleID=" & sRoleID & ",@ControllableAreas='" & drUser("ControllableAreas").ToString & "',"
            If drUser("ControllableBusinessTypes").ToString <> "" Then sSQL = sSQL & "@ControllableBusinessTypes='" & drUser("ControllableBusinessTypes").ToString & "',"
            If drUser("UserChineseName").ToString <> "" Then sSQL = sSQL & "@UserChineseName='" & drUser("UserChineseName").ToString.Replace("'", "''") & "',"
            If drUser("UserEnglishName").ToString <> "" Then sSQL = sSQL & "@UserEnglishName='" & drUser("UserEnglishName").ToString.Replace("'", "''") & "',"
            If drUser("HRNumber").ToString <> "" Then sSQL = sSQL & "@HRNumber='" & drUser("HRNumber").ToString & "',"
            If drUser("Sex") = 0 Then sSQL = sSQL & "@Sex=0,"
            If drUser("JoinDate") <> CDate("2000/1/1") Then sSQL = sSQL & "@JoinDate='" & Format(drUser("JoinDate"), "yyyy\/MM\/dd") & "',"
            If drUser("Tel").ToString <> "" Then sSQL = sSQL & "@Tel='" & drUser("Tel").ToString & "',"
            If drUser("Remarks").ToString <> "" Then sSQL = sSQL & "@Remarks='" & drUser("Remarks").ToString.Replace("'", "''") & "',"
            sSQL = sSQL & "@SSID=" & frmMain.sSSID
            dtResult = DB.GetDataTable(sSQL)
            DB.Close()
            If dtResult Is Nothing Then
                frmMain.statusText.Text = "保存用户失败！"
                Me.Cursor = Cursors.Default
                Return False
            ElseIf dtResult.Rows(0)("Result").ToString = "OK" Then
                sUserID = dtResult.Rows(0)("UserID").ToString
                drUser("UserID") = sUserID : drUser("UserCode") = dtResult.Rows(0)("UserCode").ToString : drUser("Creator") = frmMain.sLoginUserRealName : drUser("CreatedTime") = dtResult.Rows(0)("CreatedTime") : drUser.AcceptChanges()
                dtResult.Dispose() : dtResult = Nothing
                Me.txbUserCode.Text = drUser("UserCode").ToString
                If frmMain.dtAllowedRight.Select("RightName='UserValidate'").Length > 0 Then Me.rdbApproved.Enabled = True
                Me.lblCreator.Text = frmMain.sLoginUserRealName
                Me.lblCreatedTime.Text = Format(drUser("CreatedTime"), "yyyy\/MM\/dd HH:mm:ss")
                Me.Text = "用户 User: " & Me.txbAreaCode.Text & Me.txbUserCode.Text & " " & Me.txbLoginName.Text
                If frmUserManagerment.IsHandleCreated Then
                    With frmUserManagerment
                        If .trvArea.SelectedNode Is Nothing OrElse .trvArea.SelectedNode.Name <> sLocationID Then
                            If .trvArea.SelectedNode IsNot Nothing Then
                                .trvArea.SelectedNode.BackColor = SystemColors.Window
                                .trvArea.SelectedNode.ForeColor = SystemColors.ControlText
                            End If
                            .trvArea.SelectedNode = .trvArea.Nodes.Find(sLocationID, True)(0)
                            .trvArea.SelectedNode.BackColor = SystemColors.Highlight
                            .trvArea.SelectedNode.ForeColor = SystemColors.HighlightText
                            .trvArea.SelectedNode.EnsureVisible()
                        End If
                        If .cbbRole.SelectedValue <> 255 AndAlso .cbbRole.SelectedValue <> sRoleID Then .cbbRole.SelectedIndex = 0
                        If .cbbState.SelectedIndex > 1 Then .cbbState.SelectedIndex = 0
                        If .dvUser.Table.Rows.Find(sUserID) Is Nothing Then
                            Dim newUser As DataRowView = .dvUser.AddNew
                            newUser("UserID") = sUserID
                            newUser("UserCode") = Me.txbAreaCode.Text & Me.txbUserCode.Text
                            newUser("LoginName") = Me.txbLoginName.Text.Trim
                            newUser("AreaName") = Me.txbLocation.Text.Substring(5)
                            newUser("RoleName") = Me.txbRole.Text.Substring(3)
                            If Me.txbUserChineseName.Text.Trim <> "" Then newUser("UserChineseName") = Me.txbUserChineseName.Text.Trim
                            If Me.txbUserEnglishName.Text.Trim <> "" Then newUser("UserEnglishName") = Me.txbUserEnglishName.Text.Trim
                            newUser("LoginTimes") = 0
                            newUser("StateDescription") = "等待审核 Pending"
                            newUser("SortCode") = frmMain.dtLoginStructure.Rows.Find(sLocationID)("SortCode")
                            newUser("UserState") = 0
                            newUser("LocationID") = sLocationID
                            newUser("RoleID") = sRoleID
                            newUser("IsLogin") = 0
                            newUser.EndEdit() : newUser.Row.AcceptChanges()
                        End If
                        For Each column As DataGridViewColumn In .dgvList.Columns
                            If column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells Then
                                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                            End If
                        Next
                        For Each dr As DataGridViewRow In .dgvList.Rows
                            If dr.Cells("UserID").Value.ToString = sUserID Then
                                dr.Cells(1).Selected = True
                                dr.Selected = False
                                dr.Selected = True
                                Exit For
                            End If
                        Next
                    End With
                End If
                frmMain.statusText.Text = "保存用户成功。"
                Me.Cursor = Cursors.Default
                Me.btnSave.Enabled = False
                MessageBox.Show("用户已经建立，但还未通过审核。用户只有在审核后方可用于登录系统。    " & Chr(13) & _
                                "User had been created but not validated yet. User is unable to login system until validation.    " & Chr(13) & Chr(13) & _
                                IIf(Me.rdbApproved.Enabled, "请审核该用户 Please validate this user right now.    ", "请找相应主管审核该用户 Please ask corresponding manager to validate this user.    "), "用户建立成功。", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            Else
                Select Case dtResult.Rows(0)(0).ToString
                    Case "AreaMissing"
                        MessageBox.Show("当前位置无效！请选择其他位置。    ", "位置无效！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.cbbLocation.Select() : Me.cbbLocation.SelectAll() : Me.btnSave.Enabled = False
                    Case "RoleMissing"
                        MessageBox.Show("当前职位无效！请选择其他职位。    ", "职位无效！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.cbbRole.Select() : Me.btnSave.Enabled = False
                    Case "NoSpace"
                        MessageBox.Show("当前位置的用户空间已满（最多 10,000 个用户）！请选择其他位置。    ", "位置用户空间已满！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.cbbLocation.Select() : Me.cbbLocation.SelectAll() : Me.btnSave.Enabled = False
                    Case "LoginNameUsed"
                        MessageBox.Show("该登录名称在当前位置下已经存在！请修改登录名称。    " & Chr(13) & "The Login Name is already existing in current location! Please change it.    ", "登录名称重复 Login Name repeated!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txbLoginName.Select() : Me.txbLoginName.SelectAll() : Me.btnSave.Enabled = False
                    Case Else
                        MessageBox.Show("保存用户时出现错误！下面是数据库的内部错误提示：    " & Chr(13) & Chr(13) & dtResult.Rows(0)("ErrorInfo").ToString & Space(4) & Chr(13) & Chr(13) & "请放弃保存，在关闭窗口后重试。如果仍有问题，请联系软件开发人员。    ", "保存用户失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End Select
                dtResult.Dispose() : dtResult = Nothing
                frmMain.statusText.Text = "保存用户失败！"
                Me.Cursor = Cursors.Default
                Return False
            End If
        Else
            Dim sPassword As String = ""
            If drUser("LoginName").ToString <> drUser("LoginName", DataRowVersion.Original).ToString Then sSQL = "@LoginName='" & drUser("LoginName").ToString.Replace("'", "''") & "',"
            If drUser("LocationID").ToString <> drUser("LocationID", DataRowVersion.Original).ToString Then sSQL = sSQL & "@LocationID=" & drUser("LocationID").ToString & ","
            If drUser("AreaID").ToString <> drUser("AreaID", DataRowVersion.Original).ToString Then sSQL = sSQL & "@AreaID=" & drUser("AreaID").ToString & ","
            If drUser("RoleID").ToString <> drUser("RoleID", DataRowVersion.Original).ToString Then sSQL = sSQL & "@RoleID=" & drUser("RoleID").ToString & ","
            If drUser("ControllableAreas").ToString <> drUser("ControllableAreas", DataRowVersion.Original).ToString Then sSQL = sSQL & "@ControllableAreas='" & drUser("ControllableAreas").ToString & "',"
            If drUser("ControllableBusinessTypes").ToString <> drUser("ControllableBusinessTypes", DataRowVersion.Original).ToString Then sSQL = sSQL & "@ControllableBusinessTypes='" & drUser("ControllableBusinessTypes").ToString & "',"
            If drUser("UserChineseName").ToString <> drUser("UserChineseName", DataRowVersion.Original).ToString Then sSQL = sSQL & "@UserChineseName='" & drUser("UserChineseName").ToString.Replace("'", "''") & "',"
            If drUser("UserEnglishName").ToString <> drUser("UserEnglishName", DataRowVersion.Original).ToString Then sSQL = sSQL & "@UserEnglishName='" & drUser("UserEnglishName").ToString.Replace("'", "''") & "',"
            If drUser("UserState").ToString <> drUser("UserState", DataRowVersion.Original).ToString Then sSQL = sSQL & "@UserState=" & drUser("UserState").ToString & ","
            If drUser("StateReason").ToString <> drUser("StateReason", DataRowVersion.Original).ToString Then sSQL = sSQL & "@StateReason='" & drUser("StateReason").ToString.Replace("'", "''") & "',"
            If drUser("UserState") = 2 AndAlso drUser("UserState", DataRowVersion.Original) < 2 Then
                sPassword = Me.GetRandomPassword()
                sSQL = sSQL & "@Password='" & SecurityText.EncryptData(sPassword) & "',"
            End If
            If drUser("HRNumber").ToString <> drUser("HRNumber", DataRowVersion.Original).ToString Then sSQL = sSQL & "@HRNumber='" & drUser("HRNumber").ToString & "',"
            If drUser("Sex").ToString <> drUser("Sex", DataRowVersion.Original).ToString Then sSQL = sSQL & "@Sex=" & IIf(drUser("Sex"), "1", "0") & ","
            If drUser("JoinDate").ToString <> drUser("JoinDate", DataRowVersion.Original).ToString Then sSQL = sSQL & "@JoinDate='" & Format(drUser("JoinDate"), "yyyy\/MM\/dd") & "',"
            If drUser("Tel").ToString <> drUser("Tel", DataRowVersion.Original).ToString Then sSQL = sSQL & "@Tel='" & drUser("Tel").ToString & "',"
            If drUser("LeavedDate").ToString <> drUser("LeavedDate", DataRowVersion.Original).ToString Then
                If drUser("LeavedDate").ToString = "" Then
                    sSQL = sSQL & "@LeavedDate='',"
                Else
                    sSQL = sSQL & "@LeavedDate='" & Format(drUser("LeavedDate"), "yyyy\/MM\/dd") & "',"
                End If
            End If
            If drUser("Remarks").ToString <> drUser("Remarks", DataRowVersion.Original).ToString Then sSQL = sSQL & "@Remarks='" & drUser("Remarks").ToString.Replace("'", "''") & "',"
            If sSQL = "" Then
                DB.Close() : Me.btnSave.Enabled = False
                frmMain.statusText.Text = "用户未被修改，不必保存。"
                Me.Cursor = Cursors.Default : Return True
            End If
            sSQL = "Exec UserUpdate @UserID=" & sUserID & "," & sSQL & "@SSID=" & frmMain.sSSID
            dtResult = DB.GetDataTable(sSQL)
            DB.Close()
            If dtResult Is Nothing Then
                frmMain.statusText.Text = "保存用户失败！"
                Me.Cursor = Cursors.Default
                Return False
            ElseIf dtResult.Rows(0)("Result").ToString = "OK" Then
                If dtResult.Rows(0)("UserCode").ToString <> "" Then
                    drUser("UserCode") = dtResult.Rows(0)("UserCode").ToString
                    Me.txbUserCode.Text = drUser("UserCode").ToString
                End If
                drUser("Modifier") = frmMain.sLoginUserRealName
                drUser("ModifiedTime") = dtResult.Rows(0)("ModifiedTime")
                Me.lblModifier.Text = drUser("Modifier").ToString
                Me.lblModifiedTime.Text = Format(drUser("ModifiedTime"), "yyyy\/MM\/dd HH:mm:ss")
                If drUser("UserState").ToString <> drUser("UserState", DataRowVersion.Original).ToString AndAlso (drUser("UserState") <> 3 OrElse drUser("UserState", DataRowVersion.Original) <> 3) Then
                    If drUser("UserState") = 0 Then
                        drUser("Auditor") = DBNull.Value
                        drUser("ValidatedTime") = DBNull.Value
                        Me.lblAuditor.Text = ""
                        Me.lblValidatedTime.Text = ""
                    Else
                        drUser("Auditor") = frmMain.sLoginUserRealName
                        drUser("ValidatedTime") = dtResult.Rows(0)("ModifiedTime")
                        Me.lblAuditor.Text = drUser("Auditor").ToString
                        Me.lblValidatedTime.Text = Format(drUser("ValidatedTime"), "yyyy\/MM\/dd HH:mm:ss")
                    End If
                End If
                drUser.AcceptChanges()
                dtResult.Dispose() : dtResult = Nothing
                Me.Text = "用户 User: " & Me.txbAreaCode.Text & Me.txbUserCode.Text & " " & Me.txbLoginName.Text
                If frmUserManagerment.IsHandleCreated Then
                    With frmUserManagerment
                        If .trvArea.SelectedNode Is Nothing OrElse .trvArea.SelectedNode.Name <> sLocationID Then
                            If .trvArea.SelectedNode IsNot Nothing Then
                                .trvArea.SelectedNode.BackColor = SystemColors.Window
                                .trvArea.SelectedNode.ForeColor = SystemColors.ControlText
                            End If
                            .trvArea.SelectedNode = .trvArea.Nodes.Find(sLocationID, True)(0)
                            .trvArea.SelectedNode.BackColor = SystemColors.Highlight
                            .trvArea.SelectedNode.ForeColor = SystemColors.HighlightText
                            .trvArea.SelectedNode.EnsureVisible()
                        End If
                        Dim userRow As DataRow = .dvUser.Table.Rows.Find(sUserID)
                        userRow("UserCode") = Me.txbAreaCode.Text & Me.txbUserCode.Text
                        userRow("LoginName") = Me.txbLoginName.Text.Trim
                        userRow("AreaName") = Me.txbLocation.Text.Substring(5)
                        userRow("RoleName") = Me.txbRole.Text.Substring(3)
                        If Me.txbUserChineseName.Text.Trim <> "" Then userRow("UserChineseName") = Me.txbUserChineseName.Text.Trim
                        If Me.txbUserEnglishName.Text.Trim <> "" Then userRow("UserEnglishName") = Me.txbUserEnglishName.Text.Trim
                        Select Case drUser("UserState")
                            Case 0
                                userRow("StateDescription") = "等待审核 Pending"
                            Case 1
                                userRow("StateDescription") = "审核失败 Not Approved"
                            Case 2
                                userRow("StateDescription") = "审核成功 Approved"
                            Case Else
                                userRow("StateDescription") = "停止使用 Blocked"
                        End Select
                        userRow("SortCode") = frmMain.dtLoginStructure.Rows.Find(sLocationID)("SortCode")
                        userRow("UserState") = drUser("UserState")
                        userRow("LocationID") = sLocationID
                        userRow("RoleID") = sRoleID
                        userRow.EndEdit() : userRow.AcceptChanges()
                        If userRow("UserState") = 3 AndAlso userRow("NeedResetPassword").ToString = "Yes" Then
                            userRow("NeedResetPassword") = DBNull.Value
                            userRow.EndEdit() : userRow.AcceptChanges()
                            .dgvList.Columns("NeedResetPassword").Visible = (.dvUser.ToTable.Compute("Count(UserID)", "NeedResetPassword='Yes'") > 0)
                        End If
                        For Each column As DataGridViewColumn In .dgvList.Columns
                            If column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells Then
                                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                            End If
                        Next
                        If .cbbRole.SelectedValue <> 255 AndAlso .cbbRole.SelectedValue <> sRoleID Then .cbbRole.SelectedIndex = 0
                        If .cbbState.SelectedIndex <> 0 AndAlso .cbbState.SelectedIndex <> userRow("UserState") + 1 Then .cbbState.SelectedIndex = 0
                        For Each dr As DataGridViewRow In .dgvList.Rows
                            If dr.Cells("UserID").Value.ToString = sUserID Then
                                dr.Cells(1).Selected = True
                                dr.Selected = False
                                dr.Selected = True
                                Exit For
                            End If
                        Next
                    End With
                End If
                Me.btnSave.Enabled = False
                frmMain.statusText.Text = "保存用户成功。"
                Me.Cursor = Cursors.Default
                If sPassword <> "" Then
                    If frmMain.dtAllowedRight.Select("RightName='UserResetPassword'").Length > 0 Then
                        Me.btnResetPassword.Enabled = True
                    End If
                    With frmResetPassword
                        .lblUserName.Text = Me.txbAreaCode.Text & Me.txbUserCode.Text & " " & Me.txbLoginName.Text
                        .lblPassword.Text = sPassword
                        .rtbNamePassword.SelectionColor = Color.Black
                        .rtbNamePassword.AppendText("用户名 User Name: ")
                        .rtbNamePassword.SelectionColor = Color.Blue
                        .rtbNamePassword.SelectionFont = New Font(.rtbNamePassword.Font, FontStyle.Bold)
                        .rtbNamePassword.AppendText(Me.txbAreaCode.Text & Me.txbUserCode.Text & " " & Me.txbLoginName.Text)
                        .rtbNamePassword.SelectionColor = Color.Black
                        .rtbNamePassword.SelectionFont = New Font(.rtbNamePassword.Font, FontStyle.Regular)
                        .rtbNamePassword.AppendText(Chr(10))
                        .rtbNamePassword.AppendText("密  码 Password : ")
                        .rtbNamePassword.SelectionColor = Color.Blue
                        .rtbNamePassword.SelectionFont = New Font(.rtbNamePassword.Font, FontStyle.Bold)
                        .rtbNamePassword.AppendText(sPassword)
                        .rtbNamePassword.SelectionColor = Color.Black
                        .rtbNamePassword.SelectionFont = New Font(.rtbNamePassword.Font, FontStyle.Regular)
                        .rtbNamePassword.AppendText(Chr(10) & Chr(13))
                        .ShowDialog()
                        .Dispose()
                    End With
                Else
                    MessageBox.Show("保存用户成功。    ", "保存用户成功。", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                Return True
            Else
                Select Case dtResult.Rows(0)(0).ToString
                    Case "UserDeleted"
                        MessageBox.Show("该用户已被其他人删除！不再可修改。    " & Chr(13) & Chr(13) & "请关闭该窗口。    ", "用户已被其他人删除！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Case "UserStopped"
                        MessageBox.Show("该用户已被其他人停用！不再可修改。    " & Chr(13) & Chr(13) & "请关闭该窗口然后重新打开以查看最新状态。    ", "用户已被其他人停用！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Case "AlreadyStopped"
                        MessageBox.Show("该用户已被其他人停用！您无须再停用。    " & Chr(13) & Chr(13) & "请关闭该窗口然后重新打开以查看最新状态。    ", "用户已被其他人停用！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Case "AlreadyValidated"
                        MessageBox.Show("该用户已被其他人审核！您无须再审核。    " & Chr(13) & Chr(13) & "请关闭该窗口然后重新打开以查看最新状态。    ", "用户已被其他人审核！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Case "AlreadyLogin"
                        MessageBox.Show("该用户已登录过系统！您再也不能取消它的审核状态。    " & Chr(13) & Chr(13) & "请关闭该窗口然后重新打开以查看最新状态。    ", "用户已登录过系统！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Case "Can not change Area or Role"
                        MessageBox.Show("该用户已被其他人审核！您再也不能修改它的位置或职位。    " & Chr(13) & Chr(13) & "请关闭该窗口然后重新打开以查看最新状态。    ", "用户已被其他人审核！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Case "AreaMissing"
                        MessageBox.Show("当前位置无效！请选择其他位置。    ", "位置无效！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.cbbLocation.Select() : Me.cbbLocation.SelectAll()
                    Case "NoSpace"
                        MessageBox.Show("当前位置的用户空间已满（最多 10,000 个用户）！请选择其他位置。    ", "位置用户空间已满！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.cbbLocation.Select() : Me.cbbLocation.SelectAll()
                    Case "RoleMissing"
                        MessageBox.Show("当前职位无效！请选择其他职位。    ", "职位无效！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.cbbRole.Select()
                    Case "LoginNameUsed"
                        MessageBox.Show("该登录名称在当前位置下已经存在！请修改登录名称。    " & Chr(13) & "The Login Name is already existing in current location! Please change it.    ", "登录名称重复 Login Name repeated!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txbLoginName.Select() : Me.txbLoginName.SelectAll()
                    Case Else
                        MessageBox.Show("保存用户时出现错误！下面是数据库的内部错误提示：    " & Chr(13) & Chr(13) & dtResult.Rows(0)("ErrorInfo").ToString & Space(4) & Chr(13) & Chr(13) & "请放弃保存，在关闭窗口后重试。如果仍有问题，请联系软件开发人员。    ", "保存用户失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End Select
                dtResult.Dispose() : dtResult = Nothing
                Me.btnSave.Enabled = False
                frmMain.statusText.Text = "保存用户失败！"
                Me.Cursor = Cursors.Default
                Return False
            End If
        End If
    End Function
End Class