Public Class frmCustomer

    'modify code 025:
    'date;2014/6/4
    'auther:Hyron bjy 
    'remark:FSM客户信息接口

    Private drStore As DataRow, dtStore As DataTable, dvBusinessType As DataView, dvSalesMan As DataView
    Private blSkipDeal As Boolean = True, blCanModifyNecessary As Boolean = True, blCanModifyOptional As Boolean = True, blCanStopUser As Boolean = True, blIsReadOnly = False, sCityName As String = "", bClicks As Byte = 0
    Public drCustomer As DataRow, sCustomerID As String = "-1", sCustomerNameFromOthers As String = "", blAlreadyChanged As Boolean = False, blFromSalesBill As Boolean = False
    'modify code 025:start-------------------------------------------------------------------------
    Private dvCustomer As DataView, dtCustomer As DataTable, sFSMCustomerID As String = "", sFSMCustomerChineseName As String = ""
    Private dtCityFSMCustomer As DataTable
    'modify code 025:end-------------------------------------------------------------------------

    Private Sub frmCusotmer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
        ElseIf blCanModifyOptional AndAlso (drCustomer("ValidContractID").ToString <> "" OrElse drCustomer("InvalidContractID").ToString <> "") AndAlso (drCustomer("Linkman1").ToString & drCustomer("Linkman2").ToString = "" OrElse drCustomer("Tel1").ToString & drCustomer("MP1").ToString & drCustomer("Tel2").ToString & drCustomer("MP2").ToString = "") Then
            MessageBox.Show("合同客户必须至少指明一个联系人和电话！    ", "请完善联系信息！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            If drCustomer("Linkman1").ToString & drCustomer("Linkman2").ToString = "" Then
                Me.txbLinkman1.Select()
            ElseIf drCustomer("Linkman1").ToString <> "" Then
                Me.txbTel1.Select()
            Else
                Me.txbTel2.Select()
            End If
            e.Cancel = True
        ElseIf frmMain.statusText.Text.IndexOf("无法") = -1 Then
            If frmCustomerManagement.IsHandleCreated AndAlso frmCustomerManagement.dvCustomer.RowFilter.IndexOf("SearchNo") > -1 Then
                frmMain.statusText.Text = "共找到 " & Format(frmCustomerManagement.dvCustomer.Count, "#,0") & " 个客户。"
            Else
                frmMain.statusText.Text = "就绪。"
            End If
        End If
    End Sub

    Private Sub frmCusotmer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DB As New DataBase()
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打开客户窗口。请检查数据库连接。"
            Me.Close() : Return
        End If

        Try
            If frmMain.sLoginAreaType = "S" Then sCityName = DB.GetDataTable("Select Isnull(AreaChineseName,'')+' '+Isnull(AreaEnglishName,'') From AreaList Where AreaID=" & frmMain.dtLoginStructure.Rows.Find(frmMain.sLoginAreaID)("ParentAreaID").ToString).Rows(0)(0).ToString.Trim

            'modify code 025:start-------------------------------------------------------------------------
            Me.pnlShortKeys.Height = 63
            Me.Panel2.Height = 58
            Me.Panel3.Height = 59
            'modify code 025:end-------------------------------------------------------------------------

            If sCustomerID = "-1" Then
                drCustomer = DB.GetDataTable("Exec CustomerSingle -1").Rows.Add
                drCustomer("CustomerID") = -1 : drCustomer("AllowNoCredentials") = 0 : drCustomer("CompanyCredentialsType") = Me.cbbCompanyCredentialsType.Items(1) : drCustomer("Stopped") = 0 : drCustomer("IsUsed") = 0
                'modify code 025:start-------------------------------------------------------------------------
                Me.DisableInput()
                Me.pnlShortKeys.Height = 215
                Me.Panel2.Height = 211
                Me.Panel3.Height = 212
                'modify code 025:end-------------------------------------------------------------------------
                Me.btnSave.Enabled = True
            ElseIf drCustomer Is Nothing Then
                Dim dtCustomer As DataTable = DB.GetDataTable("Exec CustomerSingle " & sCustomerID)
                If dtCustomer.Rows.Count = 0 Then
                    MessageBox.Show("您所要打开的客户已经不存在（可能被删除或移位）！    ", "客户不存在！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If frmCustomerManagement.IsHandleCreated Then
                        Try
                            frmCustomerManagement.dvCustomer.Table.Rows.Find(sCustomerID).Delete()
                        Catch
                        End Try
                    End If
                    sCustomerID = "" : blAlreadyChanged = True
                    frmMain.statusText.Text = "客户不存在！"
                    dtCustomer.Dispose() : dtCustomer = Nothing
                    DB.Close() : Me.Close() : Return
                Else
                    drCustomer = dtCustomer.Copy.Rows(0)
                    dtCustomer.Dispose() : dtCustomer = Nothing
                    If frmCustomerManagement.IsHandleCreated Then frmCustomerManagement.UpdateCustomer(drCustomer)
                End If
            End If
        Catch
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开客户窗口。请联系软件开发人员。"
            DB.Close() : Me.Close() : Return
        End Try

        If drCustomer("IsUsed") Then
            blCanModifyNecessary = (frmMain.dtAllowedRight.Select("RightName='CustomerNecessaryModify'").Length > 0)
            blCanModifyOptional = (frmMain.dtAllowedRight.Select("RightName='CustomerOptionalModify'").Length > 0)
            blCanStopUser = (frmMain.dtAllowedRight.Select("RightName='CustomerStop'").Length > 0)
            If drCustomer("Stopped") AndAlso Not blCanStopUser Then  '如果客户已终止且当前登录用户不能取消终止
                blCanModifyNecessary = False : blCanModifyOptional = False
            End If
        Else '如果是新建或未使用，等同于新建权限
            blCanModifyNecessary = (frmMain.dtAllowedRight.Select("RightName='CustomerCreate'").Length > 0 OrElse frmMain.dtAllowedRight.Select("RightName='CustomerNecessaryModify'").Length > 0)
            blCanModifyOptional = (blCanModifyNecessary OrElse frmMain.dtAllowedRight.Select("RightName='CustomerOptionalModify'").Length > 0)
            blCanStopUser = False
        End If

        Dim dvTemp As DataView = frmMain.dtLoginStructure.Copy.DefaultView
        dvTemp.RowFilter = "AreaType='S'"
        dvTemp.Sort = "SortCode"
        dtStore = dvTemp.ToTable(True, "AreaID", "AreaFullName", "ParentAreaID")
        dvTemp.Dispose() : dvTemp = Nothing
        dtStore.Columns.Add("IsLoaded", System.Type.GetType("System.Boolean"))
        dtStore.PrimaryKey = New DataColumn() {dtStore.Columns("AreaID")}
        dtStore.AcceptChanges()
        If blCanModifyNecessary Then
            If sCustomerID = "-1" Then
                If frmCustomerManagement.IsHandleCreated AndAlso frmCustomerManagement.trvArea.SelectedNode IsNot Nothing Then
                    drCustomer("StoreID") = frmCustomerManagement.trvArea.SelectedNode.Name
                Else
                    drCustomer("StoreID") = dtStore.Rows(0)("AreaID")
                End If
                drCustomer("CityID") = frmMain.dtLoginStructure.Rows.Find(drCustomer("StoreID").ToString)("ParentAreaID").ToString
                drStore = dtStore.Rows.Find(drCustomer("StoreID").ToString)
                drCustomer("StoreCode") = drStore("AreaFullName").ToString.Substring(1, 3)
                drCustomer("StoreFullName") = drStore("AreaFullName").ToString
                If sCustomerNameFromOthers <> "" Then
                    'If frmMain.sLoginAreaID <> "0" Then
                    '    Dim sCustomerName As String = "", sChar As String
                    '    For bChar As Int16 = 0 To sCustomerNameFromOthers.Trim.Length - 1
                    '        sChar = sCustomerNameFromOthers.Trim.Substring(bChar, 1)
                    '        If sChar = "(" OrElse sChar = "（" OrElse sChar = ")" OrElse sChar = "）" Then
                    '            sCustomerName = sCustomerName & sChar
                    '        Else
                    '            sChar = System.Text.RegularExpressions.Regex.Replace(sChar, "[^\u4e00-\u9fa5]+$", "")
                    '            sCustomerName = sCustomerName & sChar
                    '        End If
                    '    Next
                    '    If sCustomerName <> "" Then drCustomer("CustomerChineseName") = sCustomerName
                    'Else
                    drCustomer("CustomerChineseName") = sCustomerNameFromOthers.Trim
                    'modify code 025:start-------------------------------------------------------------------------
                    If sCustomerNameFromOthers.Trim <> "" Then EnableInput()
                    'modify code 025:end-------------------------------------------------------------------------
                    'End If
                End If
            Else
                drStore = dtStore.Rows.Find(drCustomer("StoreID").ToString)
            End If

            Try
                dvBusinessType = DB.GetDataTable("Select C.CityID,C.BusinessTypeID,B.BusinessTypeCode+' '+Rtrim(Ltrim(Isnull(B.BusinessTypeChineseName,'')+' '+Isnull(B.BusinessTypeEnglishName,''))) As BusinessTypeFullName  From CityBusinessType As C Inner Join BusinessType As B On C.BusinessTypeID=B.BusinessTypeID Where B.IsInnerType=0 And C.CityID=" & drStore("ParentAreaID").ToString).DefaultView
                dvBusinessType.Sort = "BusinessTypeFullName"
                dvSalesMan = DB.GetDataTable("Exec GetSalesmanList " & frmMain.sLoginUserID).DefaultView
                Dim newRow As DataRowView = dvSalesMan.AddNew()
                newRow("SalesmanID") = -1
                newRow("SalesmanFullName") = "(没有负责业务员 No responsible Salesman)"
                newRow.EndEdit() : newRow.Row.AcceptChanges()
                newRow = dvSalesMan.AddNew()
                newRow("SalesmanID") = -2
                newRow("UserCode") = "ZZZZZZZZ"
                newRow("SalesmanFullName") = "(其他业务员 Other Salesman)"
                newRow.EndEdit() : newRow.Row.AcceptChanges()
                newRow = Nothing
                dvSalesMan.Sort = "UserCode"
                For Each dr As DataRow In dtStore.Select("ParentAreaID=" & drStore("ParentAreaID").ToString)
                    dr("IsLoaded") = 1
                    dr.AcceptChanges()
                Next
            Catch
                frmMain.statusText.Text = "系统因在检索数据时出错而无法打开客户窗口。请联系软件开发人员。"
                DB.Close() : Me.Close() : Return
            End Try

            If sCustomerID = "-1" Then
                If frmCustomerManagement.IsHandleCreated AndAlso frmCustomerManagement.cbbBusinessType.SelectedValue <> -1 Then
                    drCustomer("BusinessTypeID") = frmCustomerManagement.cbbBusinessType.SelectedValue
                    drCustomer("BusinessTypeFullName") = dvBusinessType.Table.Select("BusinessTypeID=" & drCustomer("BusinessTypeID"))(0)("BusinessTypeFullName").ToString
                ElseIf dvBusinessType.Count > 0 Then
                    drCustomer("BusinessTypeID") = dvBusinessType(0)("BusinessTypeID")
                    drCustomer("BusinessTypeFullName") = dvBusinessType(0)("BusinessTypeFullName").ToString
                End If
                drCustomer("SalesmanID") = dvSalesMan(IIf(frmMain.sLoginRoleID = "10", 1, 0))("SalesmanID")
                drCustomer("SalesmanFullName") = dvSalesMan(IIf(frmMain.sLoginRoleID = "10", 1, 0))("SalesmanFullName").ToString
                drCustomer("BalanceRebateAMT") = 0
            End If

            With Me.cbbStore
                .DataSource = dtStore
                .ValueMember = "AreaID"
                .DisplayMember = "AreaFullName"
                .SelectedValue = drCustomer("StoreID")
            End With

            With Me.cbbBusinessType
                .DataSource = dvBusinessType
                .ValueMember = "BusinessTypeID"
                .DisplayMember = "BusinessTypeFullName"
                .SelectedValue = drCustomer("BusinessTypeID")
                If .SelectedIndex = -1 Then Me.lblBusinessType.Visible = True
            End With

            With Me.cbbSalesman
                .DataSource = dvSalesMan
                .ValueMember = "SalesmanID"
                .DisplayMember = "SalesmanFullName"
                .SelectedValue = drCustomer("SalesmanID")
                If .SelectedIndex = -1 Then Me.lblSalesman.Visible = True
            End With

            Me.rdbStopped.Enabled = False : Me.txbReason.Enabled = False
        Else
            drStore = dtStore.Rows.Find(drCustomer("StoreID").ToString)
        End If

        If frmMain.sLoginAreaType <> "S" Then
            sCityName = frmMain.dtLoginStructure.Rows.Find(frmMain.dtLoginStructure.Rows.Find(drCustomer("StoreID").ToString)("ParentAreaID").ToString)("AreaFullName").ToString.Substring(5)
        End If
        If sCustomerID = "-1" Then drCustomer("CityName") = sCityName

        DB.Close()

        If blFromSalesBill AndAlso (drCustomer("IsUsed") OrElse drCustomer("CreatorID").ToString <> frmMain.sLoginUserID) Then
            blCanModifyNecessary = False
            blCanModifyOptional = False
            blCanStopUser = False
        End If

        Me.FillCustomer()
        If sCustomerID = "-1" Then Me.cbbBusinessType.SelectedIndex = -1
        If sCustomerID <> "-1" AndAlso frmCustomerManagement.IsHandleCreated Then
            With frmCustomerManagement
                If .dvCustomer.ToTable.Select("CustomerID=" & sCustomerID).Length = 0 Then
                    If .trvArea.SelectedNode Is Nothing OrElse .trvArea.SelectedNode.Name <> drCustomer("StoreID").ToString Then
                        If .trvArea.SelectedNode IsNot Nothing Then
                            .trvArea.SelectedNode.BackColor = SystemColors.Window
                            .trvArea.SelectedNode.ForeColor = SystemColors.ControlText
                        End If
                        .trvArea.SelectedNode = .trvArea.Nodes.Find(drCustomer("StoreID").ToString, True)(0)
                        .trvArea.SelectedNode.BackColor = SystemColors.Highlight
                        .trvArea.SelectedNode.ForeColor = SystemColors.HighlightText
                        .trvArea.SelectedNode.EnsureVisible()
                    End If
                End If
                Dim CustomerRow As DataRow = .dvCustomer.Table.Rows.Find(sCustomerID)
                If CustomerRow Is Nothing Then
                    MessageBox.Show("您所要打开的客户已经不存在（可能被删除或移位）！    ", "客户不存在！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If frmCustomerManagement.IsHandleCreated Then
                        Try
                            frmCustomerManagement.dvCustomer.Table.Rows.Find(sCustomerID).Delete()
                        Catch
                        End Try
                    End If
                    sCustomerID = ""
                    frmMain.statusText.Text = "客户不存在！"
                    Me.Close() : Return
                End If

                If .cbbBusinessType.SelectedValue <> -1 AndAlso .cbbBusinessType.SelectedValue.ToString <> drCustomer("BusinessTypeID").ToString Then .cbbBusinessType.SelectedIndex = 0
                If .dgvList.CurrentRow Is Nothing OrElse .dgvList("CustomerID", .dgvList.CurrentRow.Index).Value.ToString <> sCustomerID Then
                    For Each dr As DataGridViewRow In .dgvList.Rows
                        If dr.Cells("CustomerID").Value.ToString = sCustomerID Then
                            dr.Cells(1).Selected = True
                            dr.Selected = True
                            Exit For
                        End If
                    Next
                End If
            End With
        End If

        If sCustomerID <> "-1" AndAlso Not blCanModifyNecessary AndAlso Not blCanModifyOptional AndAlso Not blCanStopUser Then
            blIsReadOnly = True
            Me.Text = Me.Text & " (只读 Readonly)"
        Else
            Me.Button1.Text = My.Settings.F1
            Me.Button2.Text = My.Settings.F2
            Me.Button3.Text = My.Settings.F3
            Me.Button4.Text = My.Settings.F4
            Me.Button5.Text = My.Settings.F5
            Me.Button6.Text = My.Settings.F6
            Me.Button7.Text = My.Settings.F7
            Me.Button8.Text = My.Settings.F8
            Me.Button9.Text = My.Settings.F9
            Me.Button10.Text = My.Settings.F10
        End If

        blSkipDeal = False
        If sCustomerNameFromOthers = "" Then
            frmMain.statusText.Text = "就绪。"
        Else
            frmMain.statusText.Text = "请创建客户："
        End If

        Me.txbCustomerChineseName.Select() : Me.txbCustomerChineseName.SelectAll()

        'modify code 025:start-------------------------------------------------------------------------
        Try
            GetCityFSMCustomer()
        Catch
        End Try
        'modify code 025:end-------------------------------------------------------------------------

    End Sub

    Private Sub FillCustomer()
        Me.txbStoreCode.Text = drCustomer("StoreCode").ToString
        Me.txbCustomerCode.Text = drCustomer("CustomerCode").ToString
        Me.txbPinYinCode.Text = drCustomer("PinYinCode").ToString
        Me.txbCustomerChineseName.Text = drCustomer("CustomerChineseName").ToString
        Me.txbCustomerEnglishName.Text = drCustomer("CustomerEnglishName").ToString
        If Not blCanModifyNecessary Then
            Me.txbCustomerChineseName.ReadOnly = True
            Me.txbCustomerChineseName.BackColor = SystemColors.Window
            Me.txbCustomerChineseName.BackColor = IIf(Me.txbCustomerChineseName.ReadOnly, SystemColors.Control, SystemColors.Window)
            Me.txbCustomerEnglishName.ReadOnly = True
            Me.txbCustomerEnglishName.BackColor = SystemColors.Window
            Me.txbCustomerEnglishName.BackColor = IIf(Me.txbCustomerEnglishName.ReadOnly, SystemColors.Control, SystemColors.Window)
        End If

        Me.txbStore.Text = drCustomer("StoreFullName").ToString
        Me.txbBusinessType.Text = drCustomer("BusinessTypeFullName").ToString
        If drCustomer("SalesmanID") = -2 Then
            Me.txbSalesman.Text = drCustomer("SalesmanName").ToString
            Me.txbOtherSalesman.Text = drCustomer("SalesmanName").ToString
        Else
            Me.txbSalesman.Text = drCustomer("SalesmanFullName").ToString
        End If
        If blCanModifyNecessary Then
            If drCustomer("SalesmanID") = -2 Then
                Me.pnlOtherSalesman.Visible = True
                Me.txbOtherSalesman.Text = drCustomer("SalesmanName").ToString
            Else
                Me.pnlOtherSalesman.Visible = False
            End If
        Else
            Me.txbStore.Visible = True : Me.cbbStore.Visible = False
            Me.txbBusinessType.Visible = True : Me.cbbBusinessType.Visible = False
            Me.txbSalesman.Visible = True : Me.cbbSalesman.Visible = False
            Me.pnlOtherSalesman.Visible = False
        End If

        If drCustomer("AllowNoCredentials") OrElse drCustomer("CompanyCredentialsType").ToString = "" Then
            Me.cbbCompanyCredentialsType.SelectedIndex = 0
        Else
            Me.cbbCompanyCredentialsType.Text = drCustomer("CompanyCredentialsType").ToString
            Me.txbCompanyCredentialsNo.Text = drCustomer("CompanyCredentialsNo").ToString
        End If
        Me.txbCompanyCredentialsType.Text = Me.cbbCompanyCredentialsType.Text
        If Not blCanModifyOptional OrElse drCustomer("AllowNoCredentials") Then
            Me.cbbCompanyCredentialsType.Visible = False
            Me.txbCompanyCredentialsType.Visible = True
        End If
        If Not blCanModifyOptional OrElse Me.txbCompanyCredentialsType.Text = "（没有证件）" Then
            Me.txbCompanyCredentialsNo.ReadOnly = True
            Me.txbCompanyCredentialsNo.BackColor = SystemColors.Window
            Me.txbCompanyCredentialsNo.BackColor = SystemColors.Control
        End If
        Me.chbAllowNoCredentials.Checked = drCustomer("AllowNoCredentials")
        Me.chbAllowNoCredentials.AutoCheck = (Not blFromSalesBill AndAlso (frmMain.sLoginRoleID = "6" OrElse frmMain.sLoginRoleID = "22")) '仅限领航店长
        Me.chbAllowNoCredentials.Enabled = (Not blFromSalesBill AndAlso (blCanModifyOptional OrElse frmMain.sLoginRoleID = "6" OrElse frmMain.sLoginRoleID = "22")) '仅限领航店长

        Me.txbLinkman1.Text = drCustomer("Linkman1").ToString
        Me.txbPosition1.Text = drCustomer("Position1").ToString
        Me.txbTel1.Text = drCustomer("Tel1").ToString
        Me.txbMP1.Text = drCustomer("MP1").ToString
        Me.txbEMail1.Text = drCustomer("EMail1").ToString
        Me.txbLinkman2.Text = drCustomer("Linkman2").ToString
        Me.txbPosition2.Text = drCustomer("Position2").ToString
        Me.txbTel2.Text = drCustomer("Tel2").ToString
        Me.txbMP2.Text = drCustomer("MP2").ToString
        Me.txbEMail2.Text = drCustomer("EMail2").ToString
        Me.txbPostCode.Text = drCustomer("PostCode").ToString
        Me.txbFax.Text = drCustomer("Fax").ToString
        Me.txbCityName.Text = drCustomer("CityName").ToString
        Me.txbCompanyAddress.Text = drCustomer("CompanyAddress").ToString
        Me.rtbRemarks.AppendText(drCustomer("Remarks").ToString)
        If Not blCanModifyOptional Then
            Me.txbLinkman1.ReadOnly = True : Me.txbLinkman1.BackColor = SystemColors.Window : Me.txbLinkman1.BackColor = SystemColors.Control
            Me.txbPosition1.ReadOnly = True : Me.txbPosition1.BackColor = SystemColors.Window : Me.txbPosition1.BackColor = SystemColors.Control
            Me.txbTel1.ReadOnly = True : Me.txbTel1.BackColor = SystemColors.Window : Me.txbTel1.BackColor = SystemColors.Control
            Me.txbMP1.ReadOnly = True : Me.txbMP1.BackColor = SystemColors.Window : Me.txbMP1.BackColor = SystemColors.Control
            Me.txbEMail1.ReadOnly = True : Me.txbEMail1.BackColor = SystemColors.Window : Me.txbEMail1.BackColor = SystemColors.Control
            Me.txbLinkman2.ReadOnly = True : Me.txbLinkman2.BackColor = SystemColors.Window : Me.txbLinkman2.BackColor = SystemColors.Control
            Me.txbPosition2.ReadOnly = True : Me.txbPosition2.BackColor = SystemColors.Window : Me.txbPosition2.BackColor = SystemColors.Control
            Me.txbTel2.ReadOnly = True : Me.txbTel2.BackColor = SystemColors.Window : Me.txbTel2.BackColor = SystemColors.Control
            Me.txbMP2.ReadOnly = True : Me.txbMP2.BackColor = SystemColors.Window : Me.txbMP2.BackColor = SystemColors.Control
            Me.txbEMail2.ReadOnly = True : Me.txbEMail2.BackColor = SystemColors.Window : Me.txbEMail2.BackColor = SystemColors.Control
            Me.txbPostCode.ReadOnly = True : Me.txbPostCode.BackColor = SystemColors.Window : Me.txbPostCode.BackColor = SystemColors.Control
            Me.txbFax.ReadOnly = True : Me.txbFax.BackColor = SystemColors.Window : Me.txbFax.BackColor = SystemColors.Control
            Me.txbCityName.ReadOnly = True : Me.txbCityName.BackColor = SystemColors.Window : Me.txbCityName.BackColor = SystemColors.Control
            Me.txbCompanyAddress.ReadOnly = True : Me.txbCompanyAddress.BackColor = SystemColors.Window : Me.txbCompanyAddress.BackColor = SystemColors.Control
            Me.rtbRemarks.ReadOnly = True : Me.rtbRemarks.BackColor = SystemColors.Window : Me.rtbRemarks.BackColor = SystemColors.Control
        End If

        If drCustomer("Stopped") Then
            Me.rdbStopped.Checked = True
            Me.rdbNormal.Enabled = blCanStopUser
            Me.txbReason.Text = drCustomer("StoppedReason").ToString
        Else
            Me.rdbStopped.Enabled = blCanStopUser
            Me.rdbNormal.Checked = True
        End If

        Me.lblCreator.Text = drCustomer("Creator").ToString
        If drCustomer("CreatedTime").ToString <> "" Then Me.lblCreatedTime.Text = Format(drCustomer("CreatedTime"), "yyyy\/MM\/dd HH:mm:ss")
        Me.lblModifier.Text = drCustomer("Modifier").ToString
        If drCustomer("ModifiedTime").ToString <> "" Then Me.lblModifiedTime.Text = Format(drCustomer("ModifiedTime"), "yyyy\/MM\/dd HH:mm:ss")

        If sCustomerID <> "-1" Then
            Me.Text = "客户 Customer: " & Me.txbStoreCode.Text & Me.txbCustomerCode.Text & " " & Me.txbCustomerChineseName.Text
        End If
    End Sub

    Private Sub txbCustomerChineseName_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbCustomerChineseName.DoubleClick
        If Me.txbCustomerChineseName.ReadOnly = False Then Me.txbCustomerChineseName.SelectAll()
    End Sub

    Private Sub txbCustomerChineseName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbCustomerChineseName.KeyDown
        Me.pnlWarning.Visible = False
        If Me.txbCustomerChineseName.ReadOnly Then Return
        If e.KeyCode = Keys.Enter Then Me.txbCustomerEnglishName.Select() : Me.txbCustomerEnglishName.SelectAll() : e.SuppressKeyPress = True : Return
        If Me.pnlShortKeys.Visible = False Then Me.pnlShortKeys.Visible = True
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then Return
        If e.Shift AndAlso (e.KeyCode = Keys.D9 OrElse e.KeyCode = Keys.D0) Then Return
        If e.KeyCode = Keys.ProcessKey AndAlso e.KeyCode <> e.KeyData Then Return
        If e.KeyCode >= Keys.F1 AndAlso e.KeyCode <= Keys.F10 Then
            CType(Me.pnlButtons.Controls("Button" & e.KeyCode.ToString.Substring(1)), Button).PerformClick()
            e.SuppressKeyPress = True : Return
        End If
        'If frmMain.sLoginAreaID <> "0" Then
        '    If e.KeyCode <> Keys.ProcessKey AndAlso Not e.Shift Then Me.pnlWarning.Visible = True
        '    e.SuppressKeyPress = True
        'End If
    End Sub

    Private Sub txbCustomerChineseName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txbCustomerChineseName.KeyPress
        'If Me.txbCustomerChineseName.ReadOnly Then Return
        'If frmMain.sLoginAreaID = "0" Then Return
        'If My.Computer.Keyboard.CtrlKeyDown Then Return

        'Me.pnlWarning.Visible = False
        'Dim sChar As String = e.KeyChar
        'If AscW(sChar) = 8 Then Return 'Backspace
        'If sChar = "（" OrElse sChar = "）" Then Return
        'sChar = System.Text.RegularExpressions.Regex.Replace(sChar, "[^\u4e00-\u9fa5]+$", "")
        'If sChar <> "" Then Return
        'Me.pnlWarning.Visible = True
        'e.Handled = True
    End Sub

    'modify code 025:start-------------------------------------------------------------------------
    Private Sub txbCustomerChineseName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbCustomerChineseName.KeyUp
        If sCustomerID = "-1" Then
            Me.ListCustomer()
        End If

        If Me.txbCustomerChineseName.Text.Length > 0 Then
            EnableInput()
        Else
            DisableInput()
        End If
    End Sub
    'modify code 025:end-------------------------------------------------------------------------

    Private Sub txbCustomerChineseName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbCustomerChineseName.Leave
        If Me.txbCustomerChineseName.ReadOnly Then Return
        Me.pnlWarning.Visible = False

        Dim clickedControl As Control = Me.pnlControls.GetChildAtPoint(Me.pnlControls.PointToClient(Control.MousePosition))
        If clickedControl IsNot Nothing AndAlso (clickedControl.Parent.Name = "pnlButtons" OrElse clickedControl.Parent.Name = "pnlControls") Then Return

        'modify code 025:start-------------------------------------------------------------------------
        clickedControl = Me.Panel3.GetChildAtPoint(Me.Panel3.PointToClient(Control.MousePosition))
        If clickedControl IsNot Nothing AndAlso clickedControl.Parent.Name = "Panel3" Then Return

        If dvCustomer IsNot Nothing AndAlso dvCustomer.Count = 1 AndAlso Me.txbCustomerChineseName.Text.Equals(dvCustomer.Item(0).Item("CustomerChineseName").ToString, StringComparison.OrdinalIgnoreCase) Then
            'Dim bAnswer As Windows.Forms.DialogResult = MessageBox.Show("已找到唯一匹配的客户信息，是否直接使用？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            'If bAnswer = Windows.Forms.DialogResult.Yes Then
            '    GetCustomerInfo(dvCustomer.Item(0).Item("FSMCustomerID").ToString)
            '    Me.pnlShortKeys.Visible = False
            'Else
            '    sFSMCustomerID = ""
            '    sFSMCustomerChineseName = ""
            'End If
            MessageBox.Show("已找到唯一匹配的客户信息，将直接使用此客户信息。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            GetCustomerInfo(dvCustomer.Item(0).Item("FSMCustomerID").ToString)
            Me.pnlShortKeys.Visible = False
        End If
        'modify code 025:end-------------------------------------------------------------------------

        If Me.txbCustomerChineseName.Text <> Me.txbCustomerChineseName.Text.Trim Then Me.txbCustomerChineseName.Text = Me.txbCustomerChineseName.Text.Trim
        If drCustomer("CustomerChineseName").ToString <> Me.txbCustomerChineseName.Text Then
            'If frmMain.sLoginAreaID <> "0" Then
            '    Dim sName As String = Me.txbCustomerChineseName.Text, sChar As String
            '    For bChar As Byte = 0 To sName.Length - 1
            '        sChar = sName.Substring(bChar, 1)
            '        If sChar = "（" OrElse sChar = "）" Then Continue For
            '        sChar = System.Text.RegularExpressions.Regex.Replace(sChar, "[^\u4e00-\u9fa5]+$", "")
            '        If sChar <> "" Then Continue For
            '        MessageBox.Show("总部金额服务部的最新规定：    " & Chr(13) & Chr(13) & "客户中文名称只能由汉字及括号""（）""组成！不能包含数字、字母及其它符号！    " & Chr(13) & Chr(13) & "有疑问请咨询总部金额服务部。    ", "客户中文名称包括非法字符！", MessageBoxButtons.OK, MessageBoxIcon.Stop) '''''''
            '        Me.txbCustomerChineseName.Focus() : Me.txbCustomerChineseName.Select() : Me.txbCustomerChineseName.SelectAll()
            '        Return
            '    Next
            'End If
            drCustomer("CustomerChineseName") = Me.txbCustomerChineseName.Text
            Me.CheckChanges()
        End If
        Me.pnlShortKeys.Visible = False
    End Sub

    Private Sub txbCustomerChineseName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbCustomerChineseName.TextChanged
        'modify code 025:start-------------------------------------------------------------------------
        If sFSMCustomerChineseName <> "" AndAlso Me.txbCustomerChineseName.Text <> sFSMCustomerChineseName Then
            sFSMCustomerID = ""
            sFSMCustomerChineseName = ""

            Me.cbbCompanyCredentialsType.SelectedIndex = 1
            Me.txbCompanyCredentialsNo.Text = ""
            Me.cbbBusinessType.SelectedValue = -1
            Me.txbLinkman1.Text = ""
            Me.txbPosition1.Text = ""
            Me.txbTel1.Text = ""
            Me.txbMP1.Text = ""
            Me.txbEMail1.Text = ""
            Me.txbLinkman2.Text = ""
            Me.txbPosition2.Text = ""
            Me.txbTel2.Text = ""
            Me.txbMP2.Text = ""
            Me.txbEMail2.Text = ""
        End If
        'modify code 025:end-------------------------------------------------------------------------
        Me.txbInvoiceTitle.Text = Me.txbCustomerChineseName.Text
        If Not blSkipDeal Then Me.CheckChanges()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked, LinkLabel2.LinkClicked, LinkLabel3.LinkClicked, LinkLabel4.LinkClicked, LinkLabel5.LinkClicked, LinkLabel6.LinkClicked, LinkLabel7.LinkClicked, LinkLabel8.LinkClicked, LinkLabel9.LinkClicked, LinkLabel10.LinkClicked
        Me.SetLocution(CType(sender, Control).Name.Substring(9))
        Me.txbCustomerChineseName.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click, Button10.Click
        Dim theButton As Button = CType(sender, Button)
        If theButton.Text = "" OrElse theButton.Text = "<未定义>" Then
            Me.SetLocution(theButton.Name.Substring(6))
            Me.txbCustomerChineseName.Focus()
        Else
            Dim bStart As Byte = Me.txbCustomerChineseName.SelectionStart, sLeft As String = Me.txbCustomerChineseName.Text.Substring(0, bStart), sMid As String = theButton.Text, sRight As String = Me.txbCustomerChineseName.Text.Substring(bStart + Me.txbCustomerChineseName.SelectionLength)
            If (sLeft & sMid & sRight).Length > Me.txbCustomerChineseName.MaxLength Then
                Me.txbCustomerChineseName.Focus()
            Else
                Me.txbCustomerChineseName.Text = sLeft & sMid & sRight
                Me.txbCustomerChineseName.Select()
                Me.txbCustomerChineseName.SelectionLength = 0
                Me.txbCustomerChineseName.SelectionStart = bStart + sMid.Length
            End If
        End If
    End Sub

    Private Sub pcbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pcbClose.Click
        'modify code 025:start-------------------------------------------------------------------------
        If Me.txbCustomerChineseName.Text <> Me.txbCustomerChineseName.Text.Trim Then Me.txbCustomerChineseName.Text = Me.txbCustomerChineseName.Text.Trim
        If drCustomer("CustomerChineseName").ToString <> Me.txbCustomerChineseName.Text Then
            drCustomer("CustomerChineseName") = Me.txbCustomerChineseName.Text
            Me.CheckChanges()
        End If
        'modify code 025:end-------------------------------------------------------------------------
        Me.pnlShortKeys.Visible = False
        Me.txbCustomerChineseName.Focus()
    End Sub

    Private Sub txbCustomerEnglishName_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbCustomerEnglishName.DoubleClick
        If Me.txbCustomerEnglishName.ReadOnly = False Then Me.txbCustomerEnglishName.SelectAll()
    End Sub

    Private Sub txbCustomerEnglishName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbCustomerEnglishName.KeyDown
        If Me.txbCustomerEnglishName.ReadOnly Then Return
        If e.KeyCode = Keys.Enter Then Me.txbCustomerChineseName.Select() : Me.txbCustomerChineseName.SelectAll() : e.SuppressKeyPress = True : Return
    End Sub

    Private Sub txbCustomerEnglishName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbCustomerEnglishName.Leave
        If Me.txbCustomerEnglishName.Text <> Me.txbCustomerEnglishName.Text.Trim Then Me.txbCustomerEnglishName.Text = Me.txbCustomerEnglishName.Text.Trim
        If drCustomer("CustomerEnglishName").ToString <> Me.txbCustomerEnglishName.Text Then
            drCustomer("CustomerEnglishName") = Me.txbCustomerEnglishName.Text
            Me.CheckChanges()
        End If
    End Sub

    Private Sub cbbStore_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbbStore.KeyDown
        If e.KeyCode = Keys.Enter Then Me.cbbBusinessType.Select() : e.SuppressKeyPress = True
    End Sub

    Private Sub cbbStore_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbStore.SelectedIndexChanged
        If blSkipDeal Then Return

        drStore = dtStore.Rows.Find(Me.cbbStore.SelectedValue.ToString)
        If drStore("IsLoaded").ToString <> "True" Then
            frmMain.Cursor = Cursors.WaitCursor
            frmMain.statusText.Text = "正在检索门店数据……"
            frmMain.statusMain.Refresh()
            Dim DB As New DataBase, dtTemp As DataTable = Nothing, blError As Boolean = False
            DB.Open()
            If DB.IsConnected Then
                Try
                    dtTemp = DB.GetDataTable("Select C.CityID,C.BusinessTypeID,B.BusinessTypeCode+' '+Rtrim(Ltrim(Isnull(B.BusinessTypeChineseName,'')+' '+Isnull(B.BusinessTypeEnglishName,''))) As BusinessTypeFullName  From CityBusinessType As C Inner Join BusinessType As B On C.BusinessTypeID=B.BusinessTypeID Where B.IsInnerType=0 And C.CityID=" & drStore("ParentAreaID").ToString).Copy
                    dvBusinessType.Table.Merge(dtTemp.Copy)
                    dtTemp = DB.GetDataTable("Select LocationID AS CityID,UserID As SalesmanID,UserCode,UserCode+' '+LoginName AS SalesmanFullName From UserView Where RoleID=10 And UserState=2 And LocationID=" & drStore("ParentAreaID").ToString)
                    dvSalesMan.Table.Merge(dtTemp.Copy)
                    Dim noSalesman As DataRowView = dvSalesMan.AddNew()
                    noSalesman("SalesmanID") = -1
                    noSalesman("SalesmanFullName") = "(没有负责业务员 No responsible Salesman)"
                    noSalesman.EndEdit() : noSalesman.Row.AcceptChanges()
                    dvSalesMan.Sort = "UserCode"
                    For Each dr As DataRow In dtStore.Select("ParentAreaID=" & drStore("ParentAreaID").ToString)
                        dr("IsLoaded") = 1 : dr.AcceptChanges()
                    Next
                    dtTemp.Dispose() : dtTemp = Nothing
                Catch
                    frmMain.statusText.Text = "系统在检索门店数据出现数据库内部错误。请联系软件开发人员。"
                    blError = True
                End Try
            Else
                frmMain.statusText.Text = "系统因连接不到数据库而无法检索门店数据。请检查数据库连接。"
                blError = True
            End If

            frmMain.Cursor = Cursors.Default
            If blError Then
                blSkipDeal = True
                Me.cbbStore.SelectedValue = drCustomer("StoreID")
                blSkipDeal = False
                Return
            Else
                frmMain.statusText.Text = "就绪。"
            End If
        End If

        dvBusinessType.RowFilter = "CityID=" & drStore("ParentAreaID").ToString
        dvSalesMan.RowFilter = "(SalesmanID < 0) Or (LocationID In (" & drStore("ParentAreaID").ToString & "," & drStore("AreaID").ToString & "))"
        drCustomer("CityID") = drStore("ParentAreaID") : drCustomer("StoreID") = drStore("AreaID").ToString
        If frmMain.sLoginAreaType <> "S" Then
            sCityName = frmMain.dtLoginStructure.Rows.Find(frmMain.dtLoginStructure.Rows.Find(drCustomer("StoreID").ToString)("ParentAreaID").ToString)("AreaFullName").ToString.Substring(5)
            drCustomer("CityName") = sCityName
            Me.txbCityName.Text = sCityName
        End If

        drCustomer("StoreCode") = drStore("AreaFullName").ToString.Substring(1, 3) : Me.txbStoreCode.Text = drCustomer("StoreCode").ToString
        drCustomer("StoreFullName") = drStore("AreaFullName").ToString : Me.txbStore.Text = Me.cbbStore.Text
        If Me.Text.IndexOf(": " & Me.txbStoreCode.Text) > -1 Then
            Me.txbCustomerCode.Text = drCustomer("CustomerCode").ToString
        Else
            Me.txbCustomerCode.Text = ""
        End If
        Me.CheckChanges()
    End Sub

    Private Sub cbbBusinessType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbbBusinessType.KeyDown
        If e.KeyCode = Keys.Enter Then Me.cbbSalesman.Select() : e.SuppressKeyPress = True
    End Sub

    Private Sub cbbBusinessType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbBusinessType.SelectedIndexChanged
        If blSkipDeal Then Return

        Me.lblBusinessType.Visible = False
        Me.txbBusinessType.Text = Me.cbbBusinessType.Text
        'modify code 025:start-------------------------------------------------------------------------
        'drCustomer("BusinessTypeID") = Me.cbbBusinessType.SelectedValue
        'drCustomer("BusinessTypeFullName") = Me.cbbBusinessType.Text
        If Not Me.cbbBusinessType.SelectedValue Is Nothing Then
            drCustomer("BusinessTypeID") = Me.cbbBusinessType.SelectedValue
            drCustomer("BusinessTypeFullName") = Me.cbbBusinessType.Text
        Else
            drCustomer("BusinessTypeID") = DBNull.Value
            drCustomer("BusinessTypeFullName") = DBNull.Value
        End If
        'modify code 025:end-------------------------------------------------------------------------
        Me.CheckChanges()
    End Sub

    Private Sub cbbSalesman_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbbSalesman.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.txbOtherSalesman.Visible Then
                Me.txbOtherSalesman.Select() : Me.txbOtherSalesman.SelectAll()
            Else
                Me.cbbStore.Select()
            End If
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub cbbSalesman_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbSalesman.SelectedIndexChanged
        If blSkipDeal Then Return

        Me.lblSalesman.Visible = False
        Me.txbSalesman.Text = Me.cbbSalesman.Text
        drCustomer("SalesmanID") = Me.cbbSalesman.SelectedValue
        If drCustomer("SalesmanID") = -2 Then
            Me.pnlOtherSalesman.Visible = True
            Me.txbSalesman.Text = Me.txbOtherSalesman.Text.Trim
            drCustomer("SalesmanName") = Me.txbOtherSalesman.Text.Trim
            Me.txbOtherSalesman.Select() : Me.txbOtherSalesman.SelectAll()
        Else
            Me.pnlOtherSalesman.Visible = False
            Me.txbSalesman.Text = Me.cbbSalesman.Text
            If drCustomer("SalesmanID") = -1 Then
                drCustomer("SalesmanName") = Me.cbbSalesman.Text
            Else
                drCustomer("SalesmanName") = Me.cbbSalesman.Text.Substring(Me.cbbSalesman.Text.IndexOf(" ") + 1)
            End If
            drCustomer("SalesmanFullName") = Me.cbbSalesman.Text
        End If
        Me.CheckChanges()
    End Sub

    Private Sub txbOtherSalesman_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbOtherSalesman.KeyDown
        If Me.txbOtherSalesman.ReadOnly Then Return
        If e.KeyCode = Keys.Enter Then Me.cbbStore.Select() : e.SuppressKeyPress = True
    End Sub

    Private Sub txbOtherSalesman_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbOtherSalesman.Leave
        If Me.txbOtherSalesman.Text <> Me.txbOtherSalesman.Text.Trim Then Me.txbOtherSalesman.Text = Me.txbOtherSalesman.Text.Trim
        If drCustomer("SalesmanName").ToString <> Me.txbOtherSalesman.Text Then
            drCustomer("SalesmanName") = Me.txbOtherSalesman.Text
            Me.txbSalesman.Text = Me.txbOtherSalesman.Text
            Me.CheckChanges()
        End If
    End Sub

    Private Sub cbbCompanyCredentialsType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbbCompanyCredentialsType.KeyDown
        If Me.txbCompanyCredentialsNo.ReadOnly Then Return
        If e.KeyCode = Keys.Enter Then Me.txbCompanyCredentialsNo.Select() : Me.txbCompanyCredentialsNo.SelectAll()
    End Sub

    Private Sub cbbCompanyCredentialsType_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbCompanyCredentialsType.Leave
        If Me.cbbCompanyCredentialsType.SelectedIndex = 0 Then Return
        If Me.cbbCompanyCredentialsType.Text <> Me.txbCompanyCredentialsType.Text.Trim Then
            blSkipDeal = True
            Me.cbbCompanyCredentialsType.Text = Me.cbbCompanyCredentialsType.Text.Trim
            Me.txbCompanyCredentialsType.Text = Me.cbbCompanyCredentialsType.Text
            blSkipDeal = False
        End If
        If Me.cbbCompanyCredentialsType.Text = "" Then Me.cbbCompanyCredentialsType.SelectedIndex = 0
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub cbbCompanyCredentialsType_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cbbCompanyCredentialsType.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            bClicks += 1
            Me.theTimer.Enabled = True
            If bClicks = 2 Then
                Me.cbbCompanyCredentialsType.SelectionStart = 0
                Me.cbbCompanyCredentialsType.SelectionLength = Me.cbbCompanyCredentialsType.Text.Length
                bClicks = 0
            End If
        End If
    End Sub

    Private Sub cbbCompanyCredentialsType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbCompanyCredentialsType.SelectedIndexChanged, cbbCompanyCredentialsType.TextChanged
        If blSkipDeal OrElse drCustomer("CompanyCredentialsType").ToString = Me.cbbCompanyCredentialsType.Text.Trim Then Return
        blSkipDeal = True
        Me.txbCompanyCredentialsType.Text = Me.cbbCompanyCredentialsType.Text.Trim
        If Me.cbbCompanyCredentialsType.SelectedIndex = 0 Then
            drCustomer("CompanyCredentialsType") = DBNull.Value
            drCustomer("CompanyCredentialsNo") = DBNull.Value
            Me.txbCompanyCredentialsNo.ReadOnly = True
            Me.txbCompanyCredentialsNo.BackColor = SystemColors.Window
            Me.txbCompanyCredentialsNo.BackColor = SystemColors.Control
        Else
            drCustomer("CompanyCredentialsType") = Me.txbCompanyCredentialsType.Text
            If sCustomerID <> "-1" AndAlso drCustomer("CompanyCredentialsType").ToString = drCustomer("CompanyCredentialsType", DataRowVersion.Original).ToString Then
                drCustomer("CompanyCredentialsNo") = drCustomer("CompanyCredentialsNo", DataRowVersion.Original).ToString
            Else
                drCustomer("CompanyCredentialsNo") = DBNull.Value
            End If
            If Me.txbCompanyCredentialsNo.ReadOnly Then
                Me.txbCompanyCredentialsNo.ReadOnly = False
                Me.txbCompanyCredentialsNo.BackColor = SystemColors.Window
            End If
        End If
        Me.txbCompanyCredentialsNo.Text = drCustomer("CompanyCredentialsNo").ToString
        blSkipDeal = False
        Me.CheckChanges()
    End Sub

    Private Sub theTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles theTimer.Tick
        Me.theTimer.Enabled = False
        bClicks = 0
    End Sub

    Private Sub txbCompanyCredentialsNo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbCompanyCredentialsNo.Enter
        If Me.txbCompanyCredentialsNo.ReadOnly Then Return
        If Me.cbbCompanyCredentialsType.Text = "" Then
            Me.cbbCompanyCredentialsType.Select()
            frmMain.statusText.Text = "请先选择或输入证件类型。"
        Else
            frmMain.statusText.Text = "就绪。"
        End If
    End Sub

    Private Sub txbCompanyCredentialsNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbCompanyCredentialsNo.KeyDown
        If Me.txbCompanyCredentialsNo.ReadOnly Then Return
        If e.KeyCode = Keys.Enter Then Me.cbbCompanyCredentialsType.Select() : e.SuppressKeyPress = True : Return
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then Return
        If e.Shift AndAlso e.KeyCode <> Keys.D0 AndAlso e.KeyCode <> Keys.D9 Then e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        If (e.KeyCode >= Keys.A AndAlso e.KeyCode <= Keys.Z) Then Return
        If (e.Shift AndAlso (e.KeyCode = Keys.D9 OrElse e.KeyCode = Keys.D0)) OrElse e.KeyCode = Keys.OemMinus OrElse e.KeyCode = Keys.Subtract OrElse e.KeyCode = Keys.Space Then Return
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbCompanyCredentialsNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbCompanyCredentialsNo.TextChanged
        If Me.txbCompanyCredentialsNo.ReadOnly OrElse drCustomer("CompanyCredentialsNo").ToString = Me.txbCompanyCredentialsNo.Text.Trim Then Return
        If Me.txbCompanyCredentialsNo.Text <> Me.txbCompanyCredentialsNo.Text.Trim Then Me.txbCompanyCredentialsNo.Text = Me.txbCompanyCredentialsNo.Text.Trim
        drCustomer("CompanyCredentialsNo") = Me.txbCompanyCredentialsNo.Text
        Me.CheckChanges()
    End Sub

    Private Sub chbAllowNoCredentials_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbAllowNoCredentials.CheckedChanged
        If blSkipDeal Then Return

        blSkipDeal = True
        If Me.chbAllowNoCredentials.Checked Then
            drCustomer("AllowNoCredentials") = 1
            drCustomer("CompanyCredentialsType") = DBNull.Value
            drCustomer("CompanyCredentialsNo") = DBNull.Value
            Me.cbbCompanyCredentialsType.SelectedIndex = 0
            Me.cbbCompanyCredentialsType.Visible = False
            Me.txbCompanyCredentialsType.Text = Me.cbbCompanyCredentialsType.Text
            Me.txbCompanyCredentialsType.Visible = True
            Me.txbCompanyCredentialsNo.Text = ""
            Me.txbCompanyCredentialsNo.ReadOnly = True
            Me.txbCompanyCredentialsNo.BackColor = SystemColors.Window
            Me.txbCompanyCredentialsNo.BackColor = SystemColors.Control
        Else
            drCustomer("AllowNoCredentials") = 0
            If sCustomerID <> "-1" Then
                drCustomer("CompanyCredentialsType") = drCustomer("CompanyCredentialsType", DataRowVersion.Original)
                drCustomer("CompanyCredentialsNo") = drCustomer("CompanyCredentialsNo", DataRowVersion.Original)
            End If
            If drCustomer("CompanyCredentialsType").ToString = "" Then
                Me.cbbCompanyCredentialsType.SelectedIndex = 0
            Else
                Me.cbbCompanyCredentialsType.Text = drCustomer("CompanyCredentialsType").ToString
            End If
            Me.txbCompanyCredentialsType.Text = Me.cbbCompanyCredentialsType.Text
            Me.txbCompanyCredentialsNo.Text = drCustomer("CompanyCredentialsNo").ToString
            If blCanModifyOptional Then
                Me.cbbCompanyCredentialsType.Visible = True
                Me.txbCompanyCredentialsType.Visible = False
                If drCustomer("CompanyCredentialsType").ToString <> "" Then
                    Me.txbCompanyCredentialsNo.ReadOnly = False
                    Me.txbCompanyCredentialsNo.BackColor = SystemColors.Window
                End If
            End If
        End If
        blSkipDeal = False

        Me.CheckChanges()
    End Sub

    Private Sub chbAllowNoCredentials_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbAllowNoCredentials.Click
        If frmMain.sLoginRoleID <> "6" AndAlso frmMain.sLoginRoleID <> "22" Then
            MessageBox.Show("对不起！只有领航店长才有权限允许客户是否可以无证购卡！    ", "非领航店长无权操作该选项！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.chbAllowNoCredentials.Enabled = False
        End If
    End Sub

    Private Sub chbAllowNoCredentials_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbAllowNoCredentials.MouseEnter
        Me.theTip.Active = True
    End Sub

    Private Sub chbAllowNoCredentials_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbAllowNoCredentials.MouseLeave
        Me.theTip.Active = False
    End Sub

    Private Sub lblAllowNoCredentials_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAllowNoCredentials.Click
        If Not Me.chbAllowNoCredentials.Enabled AndAlso frmMain.sLoginRoleID <> "22" Then Return
        If frmMain.sLoginRoleID <> "6" Then
            MessageBox.Show("对不起！只有领航店长才有权限允许客户是否可以无证购卡！    ", "非领航店长无权操作该选项！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.chbAllowNoCredentials.Enabled = False
        Else
            Me.chbAllowNoCredentials.Checked = Not Me.chbAllowNoCredentials.Checked
        End If
    End Sub

    Private Sub lblAllowNoCredentials_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblAllowNoCredentials.MouseEnter
        Me.theTip.Active = True
    End Sub

    Private Sub lblAllowNoCredentials_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblAllowNoCredentials.MouseLeave
        Me.theTip.Active = False
    End Sub

    Private Sub txbLinkman1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbLinkman1.KeyDown
        If Me.txbLinkman1.ReadOnly Then Return
        If e.KeyCode = Keys.Enter Then Me.txbPosition1.Select() : Me.txbPosition1.SelectAll() : e.SuppressKeyPress = True
    End Sub

    Private Sub txbLinkman1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbLinkman1.Leave
        If Me.txbLinkman1.Text <> Me.txbLinkman1.Text.Trim Then Me.txbLinkman1.Text = Me.txbLinkman1.Text.Trim
        If drCustomer("Linkman1").ToString <> Me.txbLinkman1.Text Then
            drCustomer("Linkman1") = Me.txbLinkman1.Text
            If Me.txbLinkman1.Text = "" Then
                drCustomer("Position1") = "" : Me.txbPosition1.Text = ""
                drCustomer("Tel1") = "" : Me.txbTel1.Text = ""
                drCustomer("MP1") = "" : Me.txbMP1.Text = ""
                drCustomer("EMail1") = "" : Me.txbEMail1.Text = ""
            End If
            Me.CheckChanges()
        End If
        If blCanModifyOptional Then
            If Me.ActiveControl IsNot Nothing AndAlso Me.txbLinkman1.Text = "" Then
                Dim sName As String = Me.ActiveControl.Name
                Select Case sName
                    Case "txbLinkman1", "txbPosition1", "txbTel1", "txbMP1", "txbEMail1"
                    Case Else
                        frmMain.statusText.Text = "就绪。"
                End Select
            Else
                frmMain.statusText.Text = "就绪。"
            End If
        End If
    End Sub

    Private Sub txbPosition1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbPosition1.Enter
        If Not Me.txbPosition1.ReadOnly AndAlso Me.txbLinkman1.Text.Trim = "" Then
            frmMain.statusText.Text = "请先输入联系人姓名。"
            Me.txbLinkman1.Select()
        Else
            frmMain.statusText.Text = "就绪。"
        End If
    End Sub

    Private Sub txbPosition1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbPosition1.KeyDown
        If Me.txbPosition1.ReadOnly Then Return
        If e.KeyCode = Keys.Enter Then Me.txbTel1.Select() : Me.txbTel1.SelectAll() : e.SuppressKeyPress = True
    End Sub

    Private Sub txbPosition1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbPosition1.Leave
        If Me.txbPosition1.Text <> Me.txbPosition1.Text.Trim Then Me.txbPosition1.Text = Me.txbPosition1.Text.Trim
        If drCustomer("Position1").ToString <> Me.txbPosition1.Text Then
            drCustomer("Position1") = Me.txbPosition1.Text
            Me.CheckChanges()
        End If
    End Sub

    Private Sub txbTel1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbTel1.Enter
        If Not Me.txbTel1.ReadOnly AndAlso Me.txbLinkman1.Text.Trim = "" Then
            frmMain.statusText.Text = "请先输入联系人姓名。"
            Me.txbLinkman1.Select()
        Else
            frmMain.statusText.Text = "就绪。"
        End If
    End Sub

    Private Sub txbTel1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbTel1.KeyDown
        If Me.txbTel1.ReadOnly Then Return
        If e.KeyCode = Keys.Enter Then Me.txbMP1.Select() : Me.txbMP1.SelectAll() : e.SuppressKeyPress = True : Return
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then Return
        If e.Shift AndAlso e.KeyCode <> Keys.D0 AndAlso e.KeyCode <> Keys.D9 Then e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        If (e.Shift AndAlso (e.KeyCode = Keys.D9 OrElse e.KeyCode = Keys.D0)) OrElse e.KeyCode = Keys.OemMinus OrElse e.KeyCode = Keys.Subtract OrElse e.KeyCode = Keys.Space Then Return
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbTel1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbTel1.Leave
        If Me.txbTel1.Text <> Me.txbTel1.Text.Trim Then Me.txbTel1.Text = Me.txbTel1.Text.Trim
        If drCustomer("Tel1").ToString <> Me.txbTel1.Text Then
            drCustomer("Tel1") = Me.txbTel1.Text
            Me.CheckChanges()
        End If
    End Sub

    Private Sub txbMP1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbMP1.Enter
        If Not Me.txbMP1.ReadOnly AndAlso Me.txbLinkman1.Text.Trim = "" Then
            frmMain.statusText.Text = "请先输入联系人姓名。"
            Me.txbLinkman1.Select()
        Else
            frmMain.statusText.Text = "就绪。"
        End If
    End Sub

    Private Sub txbMP1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbMP1.KeyDown
        If Me.txbMP1.ReadOnly Then Return
        If e.KeyCode = Keys.Enter Then Me.txbEMail1.Select() : Me.txbEMail1.SelectAll() : e.SuppressKeyPress = True : Return
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then Return
        If e.Shift AndAlso e.KeyCode <> Keys.D0 AndAlso e.KeyCode <> Keys.D9 Then e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        If (e.Shift AndAlso (e.KeyCode = Keys.D9 OrElse e.KeyCode = Keys.D0)) OrElse e.KeyCode = Keys.OemMinus OrElse e.KeyCode = Keys.Subtract OrElse e.KeyCode = Keys.Space Then Return
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbMP1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbMP1.Leave
        If Me.txbMP1.Text <> Me.txbMP1.Text.Trim Then Me.txbMP1.Text = Me.txbMP1.Text.Trim
        If drCustomer("MP1").ToString <> Me.txbMP1.Text Then
            drCustomer("MP1") = Me.txbMP1.Text
            Me.CheckChanges()
        End If
    End Sub

    Private Sub txbEMail1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbEMail1.Enter
        If Not Me.txbEMail1.ReadOnly AndAlso Me.txbLinkman1.Text.Trim = "" Then
            frmMain.statusText.Text = "请先输入联系人姓名。"
            Me.txbLinkman1.Select()
        Else
            frmMain.statusText.Text = "就绪。"
        End If
    End Sub

    Private Sub txbEMail1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbEMail1.KeyDown
        If Me.txbEMail1.ReadOnly Then Return
        If e.KeyCode = Keys.Enter Then Me.txbLinkman2.Select() : Me.txbLinkman2.SelectAll() : e.SuppressKeyPress = True
    End Sub

    Private Sub txbEMail1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbEMail1.Leave
        If Me.txbEMail1.Text <> Me.txbEMail1.Text.Trim Then Me.txbEMail1.Text = Me.txbEMail1.Text.Trim
        If drCustomer("EMail1").ToString <> Me.txbEMail1.Text Then
            drCustomer("EMail1") = Me.txbEMail1.Text
            Me.CheckChanges()
        End If
    End Sub

    Private Sub txbLinkman2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbLinkman2.KeyDown
        If Me.txbLinkman2.ReadOnly Then Return
        If e.KeyCode = Keys.Enter Then Me.txbPosition2.Select() : Me.txbPosition2.SelectAll() : e.SuppressKeyPress = True
    End Sub

    Private Sub txbLinkman2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbLinkman2.Leave
        If Me.txbLinkman2.Text <> Me.txbLinkman2.Text.Trim Then Me.txbLinkman2.Text = Me.txbLinkman2.Text.Trim
        If drCustomer("Linkman2").ToString <> Me.txbLinkman2.Text Then
            drCustomer("Linkman2") = Me.txbLinkman2.Text
            If Me.txbLinkman2.Text = "" Then
                drCustomer("Position2") = "" : Me.txbPosition2.Text = ""
                drCustomer("Tel2") = "" : Me.txbTel2.Text = ""
                drCustomer("MP2") = "" : Me.txbMP2.Text = ""
                drCustomer("EMail2") = "" : Me.txbEMail2.Text = ""
            End If
            Me.CheckChanges()
        End If
        If blCanModifyOptional Then
            If Me.ActiveControl IsNot Nothing AndAlso Me.txbLinkman2.Text = "" Then
                Dim sName As String = Me.ActiveControl.Name
                Select Case sName
                    Case "txbLinkman2", "txbPosition2", "txbTel2", "txbMP2", "txbEMail2"
                    Case Else
                        frmMain.statusText.Text = "就绪。"
                End Select
            Else
                frmMain.statusText.Text = "就绪。"
            End If
        End If
    End Sub

    Private Sub txbPosition2_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbPosition2.Enter
        If Not Me.txbPosition2.ReadOnly AndAlso Me.txbLinkman2.Text.Trim = "" Then
            frmMain.statusText.Text = "请先输入联系人姓名。"
            Me.txbLinkman2.Select()
        Else
            frmMain.statusText.Text = "就绪。"
        End If
    End Sub

    Private Sub txbPosition2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbPosition2.KeyDown
        If Me.txbPosition2.ReadOnly Then Return
        If e.KeyCode = Keys.Enter Then Me.txbTel2.Select() : Me.txbTel2.SelectAll() : e.SuppressKeyPress = True
    End Sub

    Private Sub txbPosition2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbPosition2.Leave
        If Me.txbPosition2.Text <> Me.txbPosition2.Text.Trim Then Me.txbPosition2.Text = Me.txbPosition2.Text.Trim
        If drCustomer("Position2").ToString <> Me.txbPosition2.Text Then
            drCustomer("Position2") = Me.txbPosition2.Text
            Me.CheckChanges()
        End If
    End Sub

    Private Sub txbTel2_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbTel2.Enter
        If Not Me.txbTel2.ReadOnly AndAlso Me.txbLinkman2.Text.Trim = "" Then
            frmMain.statusText.Text = "请先输入联系人姓名。"
            Me.txbLinkman2.Select()
        Else
            frmMain.statusText.Text = "就绪。"
        End If
    End Sub

    Private Sub txbTel2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbTel2.KeyDown
        If Me.txbTel2.ReadOnly Then Return
        If e.KeyCode = Keys.Enter Then Me.txbMP2.Select() : Me.txbMP2.SelectAll() : e.SuppressKeyPress = True : Return
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then Return
        If e.Shift AndAlso e.KeyCode <> Keys.D0 AndAlso e.KeyCode <> Keys.D9 Then e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        If (e.Shift AndAlso (e.KeyCode = Keys.D9 OrElse e.KeyCode = Keys.D0)) OrElse e.KeyCode = Keys.OemMinus OrElse e.KeyCode = Keys.Subtract OrElse e.KeyCode = Keys.Space Then Return
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbTel2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbTel2.Leave
        If Me.txbTel2.Text <> Me.txbTel2.Text.Trim Then Me.txbTel2.Text = Me.txbTel2.Text.Trim
        If drCustomer("Tel2").ToString <> Me.txbTel2.Text Then
            drCustomer("Tel2") = Me.txbTel2.Text
            Me.CheckChanges()
        End If
    End Sub

    Private Sub txbMP2_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbMP2.Enter
        If Not Me.txbMP2.ReadOnly AndAlso Me.txbLinkman2.Text.Trim = "" Then
            frmMain.statusText.Text = "请先输入联系人姓名。"
            Me.txbLinkman2.Select()
        Else
            frmMain.statusText.Text = "就绪。"
        End If
    End Sub

    Private Sub txbMP2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbMP2.KeyDown
        If Me.txbMP2.ReadOnly Then Return
        If e.KeyCode = Keys.Enter Then Me.txbEMail2.Select() : Me.txbEMail2.SelectAll() : e.SuppressKeyPress = True : Return
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then Return
        If e.Shift AndAlso e.KeyCode <> Keys.D0 AndAlso e.KeyCode <> Keys.D9 Then e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        If (e.Shift AndAlso (e.KeyCode = Keys.D9 OrElse e.KeyCode = Keys.D0)) OrElse e.KeyCode = Keys.OemMinus OrElse e.KeyCode = Keys.Subtract OrElse e.KeyCode = Keys.Space Then Return
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbMP2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbMP2.Leave
        If Me.txbMP2.Text <> Me.txbMP2.Text.Trim Then Me.txbMP2.Text = Me.txbMP2.Text.Trim
        If drCustomer("MP2").ToString <> Me.txbMP2.Text Then
            drCustomer("MP2") = Me.txbMP2.Text
            Me.CheckChanges()
        End If
    End Sub

    Private Sub txbEMail2_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbEMail2.Enter
        If Not Me.txbEMail2.ReadOnly AndAlso Me.txbLinkman2.Text.Trim = "" Then
            frmMain.statusText.Text = "请先输入联系人姓名。"
            Me.txbLinkman2.Select()
        Else
            frmMain.statusText.Text = "就绪。"
        End If
    End Sub

    Private Sub txbEMail2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbEMail2.KeyDown
        If Me.txbEMail2.ReadOnly Then Return
        If e.KeyCode = Keys.Enter Then Me.txbPostCode.Select() : Me.txbPostCode.SelectAll() : e.SuppressKeyPress = True
    End Sub

    Private Sub txbEMail2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbEMail2.Leave
        If Me.txbEMail2.Text <> Me.txbEMail2.Text.Trim Then Me.txbEMail2.Text = Me.txbEMail2.Text.Trim
        If drCustomer("EMail2").ToString <> Me.txbEMail2.Text Then
            drCustomer("EMail2") = Me.txbEMail2.Text
            Me.CheckChanges()
        End If
    End Sub

    Private Sub txbPostCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbPostCode.KeyDown
        If Me.txbPostCode.ReadOnly Then Return
        If e.KeyCode = Keys.Enter Then Me.txbFax.Select() : Me.txbFax.SelectAll() : e.SuppressKeyPress = True : Return
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbPostCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbPostCode.Leave
        If Me.txbPostCode.Text <> Me.txbPostCode.Text.Trim Then Me.txbPostCode.Text = Me.txbPostCode.Text.Trim
        If drCustomer("PostCode").ToString <> Me.txbPostCode.Text Then
            drCustomer("PostCode") = Me.txbPostCode.Text
            Me.CheckChanges()
        End If
    End Sub

    Private Sub txbFax_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbFax.KeyDown
        If Me.txbFax.ReadOnly Then Return
        If e.KeyCode = Keys.Enter Then Me.txbCityName.Select() : Me.txbCityName.SelectAll() : e.SuppressKeyPress = True : Return
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then Return
        If e.Shift AndAlso e.KeyCode <> Keys.D0 AndAlso e.KeyCode <> Keys.D9 Then e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        If (e.Shift AndAlso (e.KeyCode = Keys.D9 OrElse e.KeyCode = Keys.D0)) OrElse e.KeyCode = Keys.OemMinus OrElse e.KeyCode = Keys.Subtract OrElse e.KeyCode = Keys.Space Then Return
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbFax_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbFax.Leave
        If Me.txbFax.Text <> Me.txbFax.Text.Trim Then Me.txbFax.Text = Me.txbFax.Text.Trim
        If drCustomer("Fax").ToString <> Me.txbFax.Text Then
            drCustomer("Fax") = Me.txbFax.Text
            Me.CheckChanges()
        End If
    End Sub

    Private Sub txbCityName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbCityName.KeyDown
        If Me.txbCityName.ReadOnly Then Return
        If e.KeyCode = Keys.Enter Then Me.txbCompanyAddress.Select() : Me.txbCompanyAddress.SelectAll() : e.SuppressKeyPress = True
    End Sub

    Private Sub txbCityName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbCityName.Leave
        If Me.txbCityName.Text <> Me.txbCityName.Text.Trim Then Me.txbCityName.Text = Me.txbCityName.Text.Trim
        If Me.txbCityName.Text = "" Then Me.txbCityName.Text = sCityName
        If drCustomer("CityName").ToString <> Me.txbCityName.Text Then
            drCustomer("CityName") = Me.txbCityName.Text
            Me.CheckChanges()
        End If
    End Sub

    Private Sub txbCompanyAddress_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbCompanyAddress.KeyDown
        If Me.txbCompanyAddress.ReadOnly Then Return
        If e.KeyCode = Keys.Enter Then Me.txbLinkman1.Select() : Me.txbLinkman1.SelectAll() : e.SuppressKeyPress = True
    End Sub

    Private Sub txbCompanyAddress_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbCompanyAddress.Leave
        If Me.txbCompanyAddress.Text <> Me.txbCompanyAddress.Text.Trim Then Me.txbCompanyAddress.Text = Me.txbCompanyAddress.Text.Trim
        If drCustomer("CompanyAddress").ToString <> Me.txbCompanyAddress.Text Then
            drCustomer("CompanyAddress") = Me.txbCompanyAddress.Text
            Me.CheckChanges()
        End If
    End Sub

    Private Sub rtbRemarks_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles rtbRemarks.Leave
        If Me.rtbRemarks.Text <> Me.rtbRemarks.Text.Trim Then Me.rtbRemarks.Text = Me.rtbRemarks.Text.Trim
        If drCustomer("Remarks").ToString <> Me.rtbRemarks.Text Then
            drCustomer("Remarks") = Me.rtbRemarks.Text
            Me.CheckChanges()
        End If
    End Sub

    Private Sub rdbNormal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbNormal.CheckedChanged
        Me.txbReason.ReadOnly = Me.rdbNormal.Checked
        If blSkipDeal Then Return

        If Me.rdbNormal.Checked Then
            If blCanModifyNecessary Then
                Me.txbCustomerChineseName.ReadOnly = False : Me.txbCustomerChineseName.BackColor = SystemColors.Window
                Me.txbCustomerEnglishName.ReadOnly = False : Me.txbCustomerEnglishName.BackColor = SystemColors.Window
                Me.cbbStore.Visible = True : Me.txbStore.Visible = False
                Me.cbbBusinessType.Visible = True : Me.txbBusinessType.Visible = False
                Me.cbbSalesman.Visible = True : Me.txbSalesman.Visible = False
                Me.pnlOtherSalesman.Visible = (Me.cbbSalesman.SelectedValue = -2)
            End If
            If blCanModifyOptional Then
                Me.txbLinkman1.ReadOnly = False : Me.txbLinkman1.BackColor = SystemColors.Window
                Me.txbPosition1.ReadOnly = False : Me.txbPosition1.BackColor = SystemColors.Window
                Me.txbTel1.ReadOnly = False : Me.txbTel1.BackColor = SystemColors.Window
                Me.txbMP1.ReadOnly = False : Me.txbMP1.BackColor = SystemColors.Window
                Me.txbEMail1.ReadOnly = False : Me.txbEMail1.BackColor = SystemColors.Window
                Me.txbLinkman2.ReadOnly = False : Me.txbLinkman2.BackColor = SystemColors.Window
                Me.txbPosition2.ReadOnly = False : Me.txbPosition2.BackColor = SystemColors.Window
                Me.txbTel2.ReadOnly = False : Me.txbTel2.BackColor = SystemColors.Window
                Me.txbMP2.ReadOnly = False : Me.txbMP2.BackColor = SystemColors.Window
                Me.txbEMail2.ReadOnly = False : Me.txbEMail2.BackColor = SystemColors.Window
                Me.txbPostCode.ReadOnly = False : Me.txbPostCode.BackColor = SystemColors.Window
                Me.txbFax.ReadOnly = False : Me.txbFax.BackColor = SystemColors.Window
                Me.txbCompanyAddress.ReadOnly = False : Me.txbCompanyAddress.BackColor = SystemColors.Window
                Me.rtbRemarks.ReadOnly = False : Me.rtbRemarks.BackColor = SystemColors.Window
            End If
            drCustomer("Stopped") = 0
            drCustomer("StoppedReason") = ""
        Else
            Me.txbCustomerChineseName.ReadOnly = True : Me.txbCustomerChineseName.BackColor = SystemColors.Window : Me.txbCustomerChineseName.BackColor = SystemColors.Control
            Me.txbCustomerEnglishName.ReadOnly = True : Me.txbCustomerEnglishName.BackColor = SystemColors.Window : Me.txbCustomerEnglishName.BackColor = SystemColors.Control
            Me.cbbStore.Visible = False : Me.txbStore.Visible = True
            Me.cbbBusinessType.Visible = False : Me.txbBusinessType.Visible = True
            Me.pnlOtherSalesman.Visible = False : Me.cbbSalesman.Visible = False : Me.txbSalesman.Visible = True
            Me.txbLinkman1.ReadOnly = True : Me.txbLinkman1.BackColor = SystemColors.Window : Me.txbLinkman1.BackColor = SystemColors.Control
            Me.txbPosition1.ReadOnly = True : Me.txbPosition1.BackColor = SystemColors.Window : Me.txbPosition1.BackColor = SystemColors.Control
            Me.txbTel1.ReadOnly = True : Me.txbTel1.BackColor = SystemColors.Window : Me.txbTel1.BackColor = SystemColors.Control
            Me.txbMP1.ReadOnly = True : Me.txbMP1.BackColor = SystemColors.Window : Me.txbMP1.BackColor = SystemColors.Control
            Me.txbEMail1.ReadOnly = True : Me.txbEMail1.BackColor = SystemColors.Window : Me.txbEMail1.BackColor = SystemColors.Control
            Me.txbLinkman2.ReadOnly = True : Me.txbLinkman2.BackColor = SystemColors.Window : Me.txbLinkman2.BackColor = SystemColors.Control
            Me.txbPosition2.ReadOnly = True : Me.txbLinkman2.BackColor = SystemColors.Window : Me.txbPosition2.BackColor = SystemColors.Control
            Me.txbTel2.ReadOnly = True : Me.txbTel2.BackColor = SystemColors.Window : Me.txbTel2.BackColor = SystemColors.Control
            Me.txbMP2.ReadOnly = True : Me.txbMP2.BackColor = SystemColors.Window : Me.txbMP2.BackColor = SystemColors.Control
            Me.txbEMail2.ReadOnly = True : Me.txbEMail2.BackColor = SystemColors.Window : Me.txbEMail2.BackColor = SystemColors.Control
            Me.txbPostCode.ReadOnly = True : Me.txbPostCode.BackColor = SystemColors.Window : Me.txbPostCode.BackColor = SystemColors.Control
            Me.txbFax.ReadOnly = True : Me.txbFax.BackColor = SystemColors.Window : Me.txbFax.BackColor = SystemColors.Control
            Me.txbCompanyAddress.ReadOnly = True : Me.txbCompanyAddress.BackColor = SystemColors.Window : Me.txbCompanyAddress.BackColor = SystemColors.Control
            Me.rtbRemarks.ReadOnly = True : Me.rtbRemarks.BackColor = SystemColors.Window : Me.rtbRemarks.BackColor = SystemColors.Control
            drCustomer("Stopped") = 1
            drCustomer("StoppedReason") = Me.txbReason.Text
            Me.txbReason.Select() : Me.txbReason.SelectAll()
        End If
        Me.CheckChanges()
    End Sub

    Private Sub txbReason_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbReason.Leave
        If Me.txbReason.Text <> Me.txbReason.Text.Trim Then Me.txbReason.Text = Me.txbReason.Text.Trim
        If drCustomer("StoppedReason").ToString <> Me.txbReason.Text Then
            drCustomer("StoppedReason") = Me.txbReason.Text
            Me.CheckChanges()
        End If
    End Sub

    Private Sub txbCompanyAddress_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbOtherSalesman.TextChanged, txbLinkman1.TextChanged, txbPosition1.TextChanged, txbTel1.TextChanged, txbMP1.TextChanged, txbEMail1.TextChanged, _
    txbLinkman2.TextChanged, txbPosition2.TextChanged, txbTel2.TextChanged, txbMP2.TextChanged, txbEMail2.TextChanged, txbPinYinCode.TextChanged, txbFax.TextChanged, txbCityName.TextChanged, txbCompanyAddress.TextChanged, rtbRemarks.TextChanged

        If blSkipDeal Then Return
        Me.CheckChanges()
    End Sub

    Private Sub txbCompanyAddress_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbOtherSalesman.DoubleClick, txbCompanyCredentialsNo.DoubleClick, txbLinkman1.DoubleClick, txbPosition1.DoubleClick, txbTel1.DoubleClick, txbMP1.DoubleClick, txbEMail1.DoubleClick, _
   txbLinkman2.DoubleClick, txbPosition2.DoubleClick, txbTel2.DoubleClick, txbMP2.DoubleClick, txbEMail2.DoubleClick, txbPinYinCode.DoubleClick, txbFax.DoubleClick, txbCityName.DoubleClick, txbCompanyAddress.DoubleClick
        Dim theTextBox As TextBox = CType(sender, TextBox)
        If theTextBox.ReadOnly = False Then theTextBox.SelectAll()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Me.SaveChanges() Then Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub SetLocution(ByVal sIndex As String)
        With frmSetLocution
            .Text = "设置快捷键<F" & sIndex & ">对应的惯用语："
            .lblTitle.Text = "请为快捷键<F" & sIndex & ">设置惯用语（限 4 字）："
            Dim theButton As Button = CType(Me.pnlButtons.Controls("Button" & sIndex), Button), sLocution As String = theButton.Text
            If sLocution = "" OrElse sLocution = "<未定义>" Then
                .sOldLocution = ""
                .txbLocution.Text = ""
            Else
                .sOldLocution = sLocution
                .txbLocution.Text = theButton.Text
            End If
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                sLocution = .txbLocution.Text.Trim
                If sLocution = "" Then sLocution = "<未定义>"
                theButton.Text = sLocution
                My.Settings.Item("F" & sIndex) = sLocution
                My.Settings.Save()
            End If
        End With
    End Sub

    Private Sub CheckChanges()
        If sCustomerID = "-1" Then Me.btnSave.Enabled = True : Return

        If drCustomer.RowState = DataRowState.Modified Then
            For bColumn As Byte = 0 To drCustomer.Table.Columns.Count - 1
                If drCustomer(bColumn).ToString <> drCustomer(bColumn, DataRowVersion.Original).ToString Then
                    Me.btnSave.Enabled = True : Return
                End If
            Next
        End If

        drCustomer.AcceptChanges()
        Me.btnSave.Enabled = False
    End Sub

    Private Function SaveChanges() As Boolean
        Me.btnSave.Select()
        If drCustomer("CustomerChineseName").ToString = "" Then
            MessageBox.Show("客户中文名称不能为空！    ", "请输入客户中文名称。", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.txbCustomerChineseName.Select()
            Me.btnSave.Enabled = False
            Return False
        End If

        If blCanModifyNecessary Then
            If dvBusinessType.Count = 0 Then
                MessageBox.Show("该门店所在的城市还没有可用的商业类型，暂不能在该店创建客户。    " & Chr(13) & Chr(13) & "请先给该城市定义商业类型。    ", "不能在当前门店下创建客户。", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.cbbBusinessType.Select()
                Me.btnSave.Enabled = False
                Return False
            End If

            If Me.cbbBusinessType.SelectedIndex = -1 Then
                MessageBox.Show("请指定客户的商业类型！    ", "未指定客户的商业类型！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.cbbBusinessType.Select()
                Return False
            End If

            If drCustomer("SalesmanID") = -2 AndAlso drCustomer("SalesmanName").ToString = "" Then Me.cbbSalesman.SelectedValue = -1
        End If

        If drCustomer("CompanyCredentialsType").ToString <> "" AndAlso drCustomer("CompanyCredentialsNo").ToString = "" Then
            MessageBox.Show("公司证件号码不能为空！请输入公司证件号码。    " & Chr(13) & Chr(13) & "若客户没法提供证件，请选择证件类型为""（没有证件）""。    " & Chr(13) & Chr(13) & "注意！    " & Chr(13) & Chr(13) & "无证件的客户，若无领航店长的批准，每次购卡不得超过 1 万元！    " & Chr(13) & Chr(13) & "请找领航店长批准允许该客户购卡万元（含）以上也无需提供证件。    ", "未输入公司证件号码！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.txbCompanyCredentialsNo.Select()
            Me.btnSave.Enabled = False
            Return False
        End If

        If blCanModifyOptional AndAlso (drCustomer("ValidContractID").ToString <> "" OrElse drCustomer("InvalidContractID").ToString <> "") AndAlso (drCustomer("Linkman1").ToString & drCustomer("Linkman2").ToString = "" OrElse drCustomer("Tel1").ToString & drCustomer("MP1").ToString & drCustomer("Tel2").ToString & drCustomer("MP2").ToString = "") Then
            MessageBox.Show("合同客户必须至少指明一个联系人和电话！    ", "请完善联系信息！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            If drCustomer("Linkman1").ToString & drCustomer("Linkman2").ToString = "" Then
                Me.txbLinkman1.Select()
            ElseIf drCustomer("Linkman1").ToString <> "" Then
                Me.txbTel1.Select()
            Else
                Me.txbTel2.Select()
            End If
            Return False
        End If

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在保存客户……"
        frmMain.statusMain.Refresh()

        Dim DB As New DataBase, sSQL As String = "", dtResult As DataTable
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "保存客户失败！"
            Me.Cursor = Cursors.Default
            Return False
        End If

        If sCustomerID = "-1" Then
            sSQL = "Exec CustomerInsertion @CustomerChineseName='" & drCustomer("CustomerChineseName").ToString.Replace("'", "''") & "',"
            If drCustomer("CustomerEnglishName").ToString <> "" Then sSQL = sSQL & "@CustomerEnglishName='" & drCustomer("CustomerEnglishName").ToString.Replace("'", "''") & "',"
            sSQL = sSQL & "@StoreID=" & drCustomer("StoreID").ToString & ",@BusinessTypeID=" & drCustomer("BusinessTypeID").ToString & ","
            If drCustomer("SalesmanID") = -2 Then
                sSQL = sSQL & "@SalesmanID=-2,@SalesmanName='" & drCustomer("SalesmanName").ToString.Replace("'", "''") & "',"
            ElseIf drCustomer("SalesmanID") > -1 Then
                sSQL = sSQL & "@SalesmanID=" & drCustomer("SalesmanID").ToString & ",@SalesmanName='" & drCustomer("SalesmanName").ToString.Replace("'", "''") & "',"
            End If
            If drCustomer("AllowNoCredentials") Then
                sSQL = sSQL & "@AllowNoCredentials=1,"
            ElseIf drCustomer("CompanyCredentialsNo").ToString <> "" Then
                sSQL = sSQL & "@CompanyCredentialsType='" & drCustomer("CompanyCredentialsType").ToString.Replace("'", "''") & "',@CompanyCredentialsNo='" & drCustomer("CompanyCredentialsNo").ToString.Replace("'", "''") & "',"
            End If
            If drCustomer("Linkman1").ToString <> "" Then sSQL = sSQL & "@Linkman1='" & drCustomer("Linkman1").ToString.Replace("'", "''") & "',"
            If drCustomer("Position1").ToString <> "" Then sSQL = sSQL & "@Position1='" & drCustomer("Position1").ToString.Replace("'", "''") & "',"
            If drCustomer("Tel1").ToString <> "" Then sSQL = sSQL & "@Tel1='" & drCustomer("Tel1").ToString.Replace("'", "''") & "',"
            If drCustomer("MP1").ToString <> "" Then sSQL = sSQL & "@MP1='" & drCustomer("MP1").ToString.Replace("'", "''") & "',"
            If drCustomer("EMail1").ToString <> "" Then sSQL = sSQL & "@EMail1='" & drCustomer("EMail1").ToString.Replace("'", "''") & "',"
            If drCustomer("Linkman2").ToString <> "" Then sSQL = sSQL & "@Linkman2='" & drCustomer("Linkman2").ToString.Replace("'", "''") & "',"
            If drCustomer("Position2").ToString <> "" Then sSQL = sSQL & "@Position2='" & drCustomer("Position2").ToString.Replace("'", "''") & "',"
            If drCustomer("Tel2").ToString <> "" Then sSQL = sSQL & "@Tel2='" & drCustomer("Tel2").ToString.Replace("'", "''") & "',"
            If drCustomer("MP2").ToString <> "" Then sSQL = sSQL & "@MP2='" & drCustomer("MP2").ToString.Replace("'", "''") & "',"
            If drCustomer("EMail2").ToString <> "" Then sSQL = sSQL & "@EMail2='" & drCustomer("EMail2").ToString.Replace("'", "''") & "',"
            If drCustomer("PostCode").ToString <> "" Then sSQL = sSQL & "@PostCode='" & drCustomer("Tel1").ToString & "',"
            If drCustomer("Fax").ToString <> "" Then sSQL = sSQL & "@Fax='" & drCustomer("Fax").ToString.Replace("'", "''") & "',"
            If drCustomer("CityName").ToString <> "" Then sSQL = sSQL & "@CityName='" & drCustomer("CityName").ToString.Replace("'", "''") & "',"
            If drCustomer("CompanyAddress").ToString <> "" Then sSQL = sSQL & "@CompanyAddress='" & drCustomer("CompanyAddress").ToString.Replace("'", "''") & "',"
            If drCustomer("Remarks").ToString <> "" Then sSQL = sSQL & "@Remarks='" & drCustomer("Remarks").ToString.Replace("'", "''") & "',"
            'modify code 025:start-------------------------------------------------------------------------
            'sSQL = sSQL & "@SSID=" & frmMain.sSSID            
            sSQL = sSQL & "@SSID=" & frmMain.sSSID & ","
            sSQL = sSQL & "@FSMCustomerID='" & sFSMCustomerID & "'"
            'modify code 025:end-------------------------------------------------------------------------
            dtResult = DB.GetDataTable(sSQL)
            DB.Close()
            If dtResult Is Nothing Then
                frmMain.statusText.Text = "保存客户失败！"
                Me.Cursor = Cursors.Default
                Return False
            ElseIf dtResult.Rows(0)("Result").ToString = "OK" Then
                sCustomerID = dtResult.Rows(0)("CustomerID").ToString
                drCustomer("CustomerID") = sCustomerID
                drCustomer("CustomerCode") = dtResult.Rows(0)("CustomerCode").ToString
                drCustomer("PinYinCode") = dtResult.Rows(0)("PinYinCode").ToString
                drCustomer("Creator") = frmMain.sLoginUserRealName : drCustomer("CreatorID") = frmMain.sLoginUserID
                drCustomer("CreatedTime") = dtResult.Rows(0)("CreatedTime")
                drCustomer.AcceptChanges()
                dtResult.Dispose() : dtResult = Nothing
                Me.txbCustomerCode.Text = drCustomer("CustomerCode").ToString : Me.txbPinYinCode.Text = drCustomer("PinYinCode").ToString
                Me.lblCreator.Text = frmMain.sLoginUserRealName
                Me.lblCreatedTime.Text = Format(drCustomer("CreatedTime"), "yyyy\/MM\/dd HH:mm:ss")
                Me.Text = "客户 Customer: " & Me.txbStoreCode.Text & Me.txbCustomerCode.Text & " " & Me.txbCustomerChineseName.Text
                If frmCustomerManagement.IsHandleCreated Then
                    With frmCustomerManagement
                        If .trvArea.SelectedNode Is Nothing OrElse .trvArea.SelectedNode.Name <> drCustomer("StoreID").ToString Then
                            If .trvArea.SelectedNode IsNot Nothing Then
                                .trvArea.SelectedNode.BackColor = SystemColors.Window
                                .trvArea.SelectedNode.ForeColor = SystemColors.ControlText
                            End If
                            .trvArea.SelectedNode = .trvArea.Nodes.Find(drCustomer("StoreID").ToString, True)(0)
                            .trvArea.SelectedNode.BackColor = SystemColors.Highlight
                            .trvArea.SelectedNode.ForeColor = SystemColors.HighlightText
                            .trvArea.SelectedNode.EnsureVisible()
                        End If
                        If .cbbBusinessType.SelectedValue <> -1 AndAlso .cbbBusinessType.SelectedValue.ToString <> drCustomer("BusinessTypeID").ToString Then .cbbBusinessType.SelectedIndex = 0
                        If .dvCustomer.Table.Rows.Find(sCustomerID) Is Nothing Then
                            Dim newCustomer As DataRowView = .dvCustomer.AddNew
                            newCustomer("CustomerID") = sCustomerID
                            newCustomer("CustomerCode") = Me.txbStoreCode.Text & Me.txbCustomerCode.Text
                            newCustomer("CustomerChineseName") = Me.txbCustomerChineseName.Text.Trim
                            newCustomer("CustomerEnglishName") = Me.txbCustomerEnglishName.Text.Trim
                            newCustomer("PinYinCode") = Me.txbPinYinCode.Text
                            newCustomer("StoreName") = Me.txbStore.Text.Substring(5)
                            newCustomer("BusinessTypeName") = Me.txbBusinessType.Text.Substring(3)
                            If drCustomer("SalesmanID") = -1 Then
                                newCustomer("SalesmanName") = "(没有负责业务员 No responsible Salesman)"
                            Else
                                newCustomer("SalesmanName") = drCustomer("SalesmanName").ToString
                            End If
                            newCustomer("SalesBillCount") = 0
                            newCustomer("ContractCount") = 0
                            newCustomer("StateDescription") = "正常 Actived"
                            newCustomer("CityID") = drStore("ParentAreaID")
                            newCustomer("StoreID") = drCustomer("StoreID")
                            newCustomer("BusinessTypeID") = drCustomer("BusinessTypeID")
                            newCustomer("SalesmanID") = drCustomer("SalesmanID")
                            newCustomer("Stopped") = 0
                            newCustomer("CreatorID") = frmMain.sLoginUserID
                            newCustomer.EndEdit() : newCustomer.Row.AcceptChanges()
                        End If
                        For Each dr As DataGridViewRow In .dgvList.Rows
                            If dr.Cells("CustomerID").Value.ToString = sCustomerID Then
                                dr.Cells(1).Selected = True
                                dr.Selected = True
                                Exit For
                            End If
                        Next
                    End With
                End If
                frmMain.statusText.Text = "保存客户成功。"
                Me.Cursor = Cursors.Default
                Me.btnSave.Enabled = False
                Me.txbCustomerChineseName.Select() : Me.txbCustomerChineseName.SelectAll()
                Return True
            Else
                Select Case dtResult.Rows(0)(0).ToString
                    Case "StoreMissing"
                        MessageBox.Show("当前门店已不存在！请选择其他门店。    ", "门店无效！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.cbbStore.Select() : Me.btnSave.Enabled = False
                    Case "BusinessTypeMissing"
                        MessageBox.Show("当前商业类型已不存在或无效！请选择其他商业类型。    ", "商业类型无效！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.cbbBusinessType.Select() : Me.btnSave.Enabled = False
                    Case "SalesmanMissing"
                        MessageBox.Show("当前业务员已不存在或无效！请选择其他业务员。    ", "业务员无效！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.cbbSalesman.Select() : Me.btnSave.Enabled = False
                    Case "NoSpace"
                        MessageBox.Show("当前门店的客户空间已满（最多 999,998 个客户）！请选择其他门店。    ", "门店客户空间已满！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.cbbStore.Select() : Me.btnSave.Enabled = False
                    Case "CustomerChineseNameUsed"
                        MessageBox.Show("该客户的中文名称在当前门店所在的城市下已经存在！请修改客户中文名称。    " & Chr(13) & "The Customer Chinese Name is already existing in same city! Please change it.    " & Chr(13) & Chr(13) & "同一个城市下的所有门店的客户的中文名称必须是唯一的。    ", "客户中文名称重复 Customer Chinese Name repeated!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txbCustomerChineseName.Select() : Me.txbCustomerChineseName.SelectAll() : Me.btnSave.Enabled = False
                    Case Else
                        MessageBox.Show("保存客户时出现错误！下面是数据库的内部错误提示：    " & Chr(13) & Chr(13) & dtResult.Rows(0)("ErrorInfo").ToString & Space(4) & Chr(13) & Chr(13) & "请放弃保存，在关闭窗口后重试。如果仍有问题，请联系软件开发人员。    ", "保存客户失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End Select
                dtResult.Dispose() : dtResult = Nothing
                frmMain.statusText.Text = "保存客户失败！"
                Me.Cursor = Cursors.Default
                Return False
            End If
        Else
            If drCustomer("CustomerChineseName").ToString <> drCustomer("CustomerChineseName", DataRowVersion.Original).ToString Then sSQL = "@CustomerChineseName='" & drCustomer("CustomerChineseName").ToString.Replace("'", "''") & "',"
            If drCustomer("CustomerEnglishName").ToString <> drCustomer("CustomerEnglishName", DataRowVersion.Original).ToString Then sSQL = sSQL & "@CustomerEnglishName='" & drCustomer("CustomerEnglishName").ToString.Replace("'", "''") & "',"
            If drCustomer("StoreID").ToString <> drCustomer("StoreID", DataRowVersion.Original).ToString Then sSQL = sSQL & "@StoreID=" & drCustomer("StoreID").ToString & ","
            If drCustomer("BusinessTypeID").ToString <> drCustomer("BusinessTypeID", DataRowVersion.Original).ToString Then sSQL = sSQL & "@BusinessTypeID=" & drCustomer("BusinessTypeID").ToString & ","
            If drCustomer("SalesmanID").ToString <> drCustomer("SalesmanID", DataRowVersion.Original).ToString Then sSQL = sSQL & "@SalesmanID=" & drCustomer("SalesmanID").ToString & ","
            If drCustomer("SalesmanID").ToString <> "-1" AndAlso drCustomer("SalesmanName").ToString <> drCustomer("SalesmanName", DataRowVersion.Original).ToString Then sSQL = sSQL & "@SalesmanName='" & drCustomer("SalesmanName").ToString.Replace("'", "''") & "',"
            If drCustomer("SalesmanID").ToString = "-1" AndAlso drCustomer("SalesmanName", DataRowVersion.Original).ToString <> "" Then sSQL = sSQL & "@SalesmanName='',"
            If drCustomer("Stopped").ToString <> drCustomer("Stopped", DataRowVersion.Original).ToString Then sSQL = sSQL & "@Stopped=" & IIf(drCustomer("Stopped"), "1", "0") & ","
            If drCustomer("StoppedReason").ToString <> drCustomer("StoppedReason", DataRowVersion.Original).ToString Then sSQL = sSQL & "@StoppedReason='" & drCustomer("StoppedReason").ToString.Replace("'", "''") & "',"
            If drCustomer("AllowNoCredentials").ToString <> drCustomer("AllowNoCredentials", DataRowVersion.Original).ToString Then sSQL = sSQL & "@AllowNoCredentials=" & IIf(drCustomer("AllowNoCredentials"), "1", "0") & ","
            If drCustomer("CompanyCredentialsType").ToString <> drCustomer("CompanyCredentialsType", DataRowVersion.Original).ToString Then sSQL = sSQL & "@CompanyCredentialsType='" & drCustomer("CompanyCredentialsType").ToString.Replace("'", "''") & "',"
            If drCustomer("CompanyCredentialsNo").ToString <> drCustomer("CompanyCredentialsNo", DataRowVersion.Original).ToString Then sSQL = sSQL & "@CompanyCredentialsNo='" & drCustomer("CompanyCredentialsNo").ToString.Replace("'", "''") & "',"
            If drCustomer("Linkman1").ToString <> drCustomer("Linkman1", DataRowVersion.Original).ToString Then sSQL = sSQL & "@Linkman1='" & drCustomer("Linkman1").ToString.Replace("'", "''") & "',"
            If drCustomer("Position1").ToString <> drCustomer("Position1", DataRowVersion.Original).ToString Then sSQL = sSQL & "@Position1='" & drCustomer("Position1").ToString.Replace("'", "''") & "',"
            If drCustomer("Tel1").ToString <> drCustomer("Tel1", DataRowVersion.Original).ToString Then sSQL = sSQL & "@Tel1='" & drCustomer("Tel1").ToString.Replace("'", "''") & "',"
            If drCustomer("MP1").ToString <> drCustomer("MP1", DataRowVersion.Original).ToString Then sSQL = sSQL & "@MP1='" & drCustomer("MP1").ToString.Replace("'", "''") & "',"
            If drCustomer("EMail1").ToString <> drCustomer("EMail1", DataRowVersion.Original).ToString Then sSQL = sSQL & "@EMail1='" & drCustomer("EMail1").ToString.Replace("'", "''") & "',"
            If drCustomer("Remarks").ToString <> drCustomer("Remarks", DataRowVersion.Original).ToString Then sSQL = sSQL & "@Remarks='" & drCustomer("Remarks").ToString.Replace("'", "''") & "',"
            If drCustomer("Linkman2").ToString <> drCustomer("Linkman2", DataRowVersion.Original).ToString Then sSQL = sSQL & "@Linkman2='" & drCustomer("Linkman2").ToString.Replace("'", "''") & "',"
            If drCustomer("Position2").ToString <> drCustomer("Position2", DataRowVersion.Original).ToString Then sSQL = sSQL & "@Position2='" & drCustomer("Position2").ToString.Replace("'", "''") & "',"
            If drCustomer("Tel2").ToString <> drCustomer("Tel2", DataRowVersion.Original).ToString Then sSQL = sSQL & "@Tel2='" & drCustomer("Tel2").ToString.Replace("'", "''") & "',"
            If drCustomer("MP2").ToString <> drCustomer("MP2", DataRowVersion.Original).ToString Then sSQL = sSQL & "@MP2='" & drCustomer("MP2").ToString.Replace("'", "''") & "',"
            If drCustomer("EMail2").ToString <> drCustomer("EMail2", DataRowVersion.Original).ToString Then sSQL = sSQL & "@EMail2='" & drCustomer("EMail2").ToString.Replace("'", "''") & "',"
            If drCustomer("PostCode").ToString <> drCustomer("PostCode", DataRowVersion.Original).ToString Then sSQL = sSQL & "@PostCode='" & drCustomer("PostCode").ToString & "',"
            If drCustomer("Fax").ToString <> drCustomer("Fax", DataRowVersion.Original).ToString Then sSQL = sSQL & "@Fax='" & drCustomer("Fax").ToString.Replace("'", "''") & "',"
            If drCustomer("CityName").ToString <> drCustomer("CityName", DataRowVersion.Original).ToString Then sSQL = sSQL & "@CityName='" & drCustomer("CityName").ToString.Replace("'", "''") & "',"
            If drCustomer("CompanyAddress").ToString <> drCustomer("CompanyAddress", DataRowVersion.Original).ToString Then sSQL = sSQL & "@CompanyAddress='" & drCustomer("CompanyAddress").ToString.Replace("'", "''") & "',"
            If drCustomer("Remarks").ToString <> drCustomer("Remarks", DataRowVersion.Original).ToString Then sSQL = sSQL & "@Remarks='" & drCustomer("Remarks").ToString.Replace("'", "''") & "',"
            If sSQL = "" Then
                drCustomer.AcceptChanges()
                DB.Close() : Me.btnSave.Enabled = False
                frmMain.statusText.Text = "客户未被修改，不必保存。"
                Me.Cursor = Cursors.Default : Return True
            End If
            sSQL = "Exec CustomerUpdate @CustomerID=" & sCustomerID & "," & sSQL & "@SSID=" & frmMain.sSSID
            dtResult = DB.GetDataTable(sSQL)
            DB.Close()
            If dtResult Is Nothing Then
                frmMain.statusText.Text = "保存客户失败！"
                Me.Cursor = Cursors.Default
                Return False
            ElseIf dtResult.Rows(0)("Result").ToString = "OK" Then
                If dtResult.Rows(0)("CustomerCode").ToString <> "" Then
                    drCustomer("CustomerCode") = dtResult.Rows(0)("CustomerCode").ToString
                    Me.txbCustomerCode.Text = drCustomer("CustomerCode").ToString
                End If
                If dtResult.Rows(0)("PinYinCode").ToString <> "" Then
                    drCustomer("PinYinCode") = dtResult.Rows(0)("PinYinCode").ToString
                    Me.txbPinYinCode.Text = drCustomer("PinYinCode").ToString
                End If
                drCustomer("Modifier") = frmMain.sLoginUserRealName
                drCustomer("ModifiedTime") = dtResult.Rows(0)("ModifiedTime")
                Me.lblModifier.Text = drCustomer("Modifier").ToString
                Me.lblModifiedTime.Text = Format(drCustomer("ModifiedTime"), "yyyy\/MM\/dd HH:mm:ss")
                dtResult.Dispose() : dtResult = Nothing
                Me.Text = "客户 Customer: " & Me.txbStoreCode.Text & Me.txbCustomerCode.Text & " " & Me.txbCustomerChineseName.Text
                If frmCustomerManagement.IsHandleCreated Then
                    With frmCustomerManagement
                        If .trvArea.SelectedNode Is Nothing OrElse .trvArea.SelectedNode.Name <> drCustomer("StoreID").ToString Then
                            If .trvArea.SelectedNode IsNot Nothing Then
                                .trvArea.SelectedNode.BackColor = SystemColors.Window
                                .trvArea.SelectedNode.ForeColor = SystemColors.ControlText
                            End If
                            .trvArea.SelectedNode = .trvArea.Nodes.Find(drCustomer("StoreID").ToString, True)(0)
                            .trvArea.SelectedNode.BackColor = SystemColors.Highlight
                            .trvArea.SelectedNode.ForeColor = SystemColors.HighlightText
                            .trvArea.SelectedNode.EnsureVisible()
                        End If
                        .UpdateCustomer(drCustomer)
                        If .cbbBusinessType.SelectedValue <> -1 AndAlso .cbbBusinessType.SelectedValue.ToString <> drCustomer("BusinessTypeID").ToString Then .cbbBusinessType.SelectedIndex = 0
                        For Each dr As DataGridViewRow In .dgvList.Rows
                            If dr.Cells("CustomerID").Value.ToString = sCustomerID Then
                                dr.Cells(1).Selected = True
                                dr.Selected = True
                                Exit For
                            End If
                        Next
                    End With
                End If
                If frmSelling.IsHandleCreated AndAlso frmSelling.sSalesBillID = "-1" AndAlso frmSelling.sCustomerID = sCustomerID AndAlso _
                (drCustomer("AllowNoCredentials") <> drCustomer("AllowNoCredentials", DataRowVersion.Original) OrElse _
                 drCustomer("CompanyCredentialsType").ToString <> drCustomer("CompanyCredentialsType", DataRowVersion.Original).ToString OrElse _
                 drCustomer("CompanyCredentialsNo").ToString <> drCustomer("CompanyCredentialsNo", DataRowVersion.Original).ToString) Then
                    With frmSelling
                        If drCustomer("AllowNoCredentials") Then
                            If .cbbCompanyCredentialsType.Items.IndexOf("（特准无需证件）") = -1 Then .cbbCompanyCredentialsType.Items.Insert(0, "（特准无需证件）")
                            .drSalesBill("CompanyCredentialsType") = "（特准无需证件）"
                            .drSalesBill("CompanyCredentialsNo") = DBNull.Value
                        Else
                            If .cbbCompanyCredentialsType.Items.IndexOf("（特准无需证件）") = 0 Then .cbbCompanyCredentialsType.Items.RemoveAt(0)
                            If drCustomer("CompanyCredentialsType").ToString = "" Then
                                .drSalesBill("CompanyCredentialsType") = .cbbCompanyCredentialsType.Items(0)
                                .drSalesBill("CompanyCredentialsNo") = DBNull.Value
                            Else
                                .drSalesBill("CompanyCredentialsType") = drCustomer("CompanyCredentialsType").ToString
                                .drSalesBill("CompanyCredentialsNo") = drCustomer("CompanyCredentialsNo").ToString
                            End If
                        End If

                        .cbbCompanyCredentialsType.Text = .drSalesBill("CompanyCredentialsType").ToString
                        .txbCompanyCredentialsType.Text = .drSalesBill("CompanyCredentialsType").ToString
                        .txbCompanyCredentialsNo.Text = .drSalesBill("CompanyCredentialsNo").ToString
                        If .drSalesBill("CompanyCredentialsType").ToString = "（特准无需证件）" Then
                            .txbCompanyCredentialsNo.ReadOnly = True
                            .txbCompanyCredentialsNo.BackColor = SystemColors.Window
                            .txbCompanyCredentialsNo.BackColor = SystemColors.Control
                        Else
                            .txbCompanyCredentialsNo.ReadOnly = False
                            .txbCompanyCredentialsNo.BackColor = SystemColors.Window
                        End If
                    End With
                End If
                drCustomer.AcceptChanges()
                Me.btnSave.Enabled = False
                MessageBox.Show("客户保存成功。    ", "客户保存成功。", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txbCustomerChineseName.Select() : Me.txbCustomerChineseName.SelectAll()
                frmMain.statusText.Text = "保存客户成功。"
                Me.Cursor = Cursors.Default
                blAlreadyChanged = True
                Return True
            Else
                Select Case dtResult.Rows(0)(0).ToString
                    Case "CustomerDeleted"
                        MessageBox.Show("该客户已被其他人删除！不再可修改。    " & Chr(13) & Chr(13) & "请关闭该窗口。    ", "客户已被其他人删除！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Case "CustomerStopped"
                        MessageBox.Show("该客户已被其他人停用！不再可修改。    " & Chr(13) & Chr(13) & "请关闭该窗口然后重新打开以查看最新状态。    ", "客户已被其他人停用！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Case "AlreadyStopped"
                        MessageBox.Show("该客户已被其他人停用！您无须再停用。    " & Chr(13) & Chr(13) & "请关闭该窗口然后重新打开以查看最新状态。    ", "客户已被其他人停用！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Case "AlreadyReopened"
                        MessageBox.Show("该客户已被其他人重启！您无须再重启。    " & Chr(13) & Chr(13) & "请关闭该窗口然后重新打开以查看最新状态。    ", "客户已被其他人重启！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Case "BusinessTypeMissing"
                        MessageBox.Show("当前商业类型已不存在或无效！请选择其他商业类型。    ", "商业类型无效！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.cbbBusinessType.Select()
                    Case "SalesmanMissing"
                        MessageBox.Show("当前业务员已不存在或无效！请选择其他业务员。    ", "业务员无效！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.cbbSalesman.Select()
                    Case "StoreMissing"
                        MessageBox.Show("当前门店已不存在！请选择其他门店。    ", "门店无效！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.cbbStore.Select()
                    Case "NoSpace"
                        MessageBox.Show("当前门店的客户空间已满（最多 999,998 个客户）！请选择其他门店。    ", "门店客户空间已满！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.cbbStore.Select()
                    Case "CustomerChineseNameUsed"
                        MessageBox.Show("该客户的中文名称在当前门店所在的城市下已经存在！请修改客户中文名称。    " & Chr(13) & "The Customer Chinese Name is already existing in same city! Please change it.    " & Chr(13) & Chr(13) & "同一个城市下的所有门店的客户的中文名称必须是唯一的。    ", "客户中文名称重复 Customer Chinese Name repeated!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txbCustomerChineseName.Select() : Me.txbCustomerChineseName.SelectAll()
                    Case Else
                        MessageBox.Show("保存客户时出现错误！下面是数据库的内部错误提示：    " & Chr(13) & Chr(13) & dtResult.Rows(0)("ErrorInfo").ToString & Space(4) & Chr(13) & Chr(13) & "请放弃保存，在关闭窗口后重试。如果仍有问题，请联系软件开发人员。    ", "保存客户失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End Select
                Me.btnSave.Enabled = (dtResult.Rows(0)(0).ToString <> "Error")
                dtResult.Dispose() : dtResult = Nothing
                frmMain.statusText.Text = "保存客户失败！"
                Me.Cursor = Cursors.Default
                Return False
            End If
        End If
    End Function

    'modify code 025:start-------------------------------------------------------------------------
    Private Sub ListCustomer()
        If dtCityFSMCustomer Is Nothing OrElse dtCityFSMCustomer.Rows.Count = 0 Then
            Return
        End If

        Try
            If Me.txbCustomerChineseName.Text.Trim.Length >= 2 Then
                dtCityFSMCustomer.DefaultView.RowFilter = "CustomerChineseName like '%'+'" & Me.txbCustomerChineseName.Text.Replace(" '", "''") & "'+'%'"
                dvCustomer = SelectDataViewTopCount(dtCityFSMCustomer.DefaultView, 20)
                dvCustomer.Sort = "FSMCustomerID"
                dtCustomer = dvCustomer.ToTable(True, "FSMCustomerID", "CustomerChineseName")
                dgvCustomerList.DataSource = dtCustomer
                dgvCustomerList.Columns(0).Visible = False
            Else
                If dtCustomer IsNot Nothing Then dtCustomer.Clear()
            End If
        Catch
            Return
        End Try

    End Sub

    Private Sub GetCustomerInfo(ByVal sCustomerId As String)
        Dim drvCustomer As DataRowView = dvCustomer.Item(dvCustomer.Find(sCustomerId))

        If drvCustomer Is Nothing Then
            sFSMCustomerID = ""
            sFSMCustomerChineseName = ""
            Return
        Else
            sFSMCustomerID = sCustomerId
            sFSMCustomerChineseName = drvCustomer.Item("CustomerChineseName")
        End If

        With drvCustomer
            drCustomer("CustomerChineseName") = .Item("CustomerChineseName")
            drCustomer("CustomerEnglishName") = .Item("CustomerEnglishName")
            drCustomer("CompanyCredentialsType") = .Item("CompanyCredentialsType")
            drCustomer("CompanyCredentialsNo") = .Item("CompanyCredentialsNo")
            drCustomer("BusinessTypeID") = .Item("BusinessTypeID")
            drCustomer("Linkman1") = .Item("Linkman1")
            drCustomer("Position1") = .Item("Position1")
            drCustomer("Tel1") = .Item("Tel1")
            drCustomer("MP1") = .Item("MP1")
            drCustomer("EMail1") = .Item("EMail1")
            drCustomer("Linkman2") = .Item("Linkman2")
            drCustomer("Position2") = .Item("Position2")
            drCustomer("Tel2") = .Item("Tel2")
            drCustomer("MP2") = .Item("MP2")
            drCustomer("EMail2") = .Item("EMail2")

            Me.txbCustomerChineseName.Text = .Item("CustomerChineseName")
            Me.txbCustomerEnglishName.Text = IIf(DBNull.Value.Equals(.Item("CustomerEnglishName")), "", .Item("CustomerEnglishName"))
            Me.cbbCompanyCredentialsType.Text = IIf(DBNull.Value.Equals(.Item("CompanyCredentialsType")), "", .Item("CompanyCredentialsType"))
            Me.txbCompanyCredentialsNo.Text = IIf(DBNull.Value.Equals(.Item("CompanyCredentialsNo")), "", .Item("CompanyCredentialsNo"))
            Me.cbbBusinessType.SelectedValue = IIf(DBNull.Value.Equals(.Item("BusinessTypeID")), -1, .Item("BusinessTypeID"))
            Me.txbLinkman1.Text = IIf(DBNull.Value.Equals(.Item("Linkman1")), "", .Item("Linkman1"))
            Me.txbPosition1.Text = IIf(DBNull.Value.Equals(.Item("Position1")), "", .Item("Position1"))
            Me.txbTel1.Text = IIf(DBNull.Value.Equals(.Item("Tel1")), "", .Item("Tel1"))
            Me.txbMP1.Text = IIf(DBNull.Value.Equals(.Item("MP1")), "", .Item("MP1"))
            Me.txbEMail1.Text = IIf(DBNull.Value.Equals(.Item("EMail1")), "", .Item("EMail1"))
            Me.txbLinkman2.Text = IIf(DBNull.Value.Equals(.Item("Linkman2")), "", .Item("Linkman2"))
            Me.txbPosition2.Text = IIf(DBNull.Value.Equals(.Item("Position2")), "", .Item("Position2"))
            Me.txbTel2.Text = IIf(DBNull.Value.Equals(.Item("Tel2")), "", .Item("Tel2"))
            Me.txbMP2.Text = IIf(DBNull.Value.Equals(.Item("MP2")), "", .Item("MP2"))
            Me.txbEMail2.Text = IIf(DBNull.Value.Equals(.Item("EMail2")), "", .Item("EMail2"))
        End With
    End Sub

    Private Sub dgvCustomerList_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCustomerList.CellClick

        If e.RowIndex < 0 Or e.ColumnIndex < 0 Then Return

        GetCustomerInfo(dgvCustomerList.Rows(e.RowIndex).Cells(0).Value)

        Me.pnlShortKeys.Visible = False
    End Sub

    Private Sub DisableInput()
        If sCustomerID <> "-1" Then Return
        With Me
            .txbCustomerEnglishName.Enabled = False
            .cbbStore.Enabled = False
            .lblBusinessType.Enabled = False
            .cbbBusinessType.Enabled = False
            .cbbSalesman.Enabled = False
            .txbOtherSalesman.Enabled = False
            .cbbCompanyCredentialsType.Enabled = False
            .txbCompanyCredentialsNo.Enabled = False
            .chbAllowNoCredentials.Enabled = False
            .txbLinkman1.Enabled = False
            .txbPosition1.Enabled = False
            .txbTel1.Enabled = False
            .txbMP1.Enabled = False
            .txbEMail1.Enabled = False
            .txbLinkman2.Enabled = False
            .txbPosition2.Enabled = False
            .txbTel2.Enabled = False
            .txbMP2.Enabled = False
            .txbEMail2.Enabled = False
            .txbPostCode.Enabled = False
            .txbFax.Enabled = False
            .txbCityName.Enabled = False
            .txbCompanyAddress.Enabled = False
            .rtbRemarks.Enabled = False
        End With
    End Sub

    Private Sub EnableInput()
        If sCustomerID <> "-1" Then Return
        With Me
            .txbCustomerEnglishName.Enabled = True
            .cbbStore.Enabled = True
            .lblBusinessType.Enabled = True
            .cbbBusinessType.Enabled = True
            .cbbSalesman.Enabled = True
            .txbOtherSalesman.Enabled = True
            .cbbCompanyCredentialsType.Enabled = True
            .txbCompanyCredentialsNo.Enabled = True
            .chbAllowNoCredentials.Enabled = True
            .txbLinkman1.Enabled = True
            .txbPosition1.Enabled = True
            .txbTel1.Enabled = True
            .txbMP1.Enabled = True
            .txbEMail1.Enabled = True
            .txbLinkman2.Enabled = True
            .txbPosition2.Enabled = True
            .txbTel2.Enabled = True
            .txbMP2.Enabled = True
            .txbEMail2.Enabled = True
            .txbPostCode.Enabled = True
            .txbFax.Enabled = True
            .txbCityName.Enabled = True
            .txbCompanyAddress.Enabled = True
            .rtbRemarks.Enabled = True
        End With
    End Sub

    Private Sub GetCityFSMCustomer()
        Dim mDB As New DataBase(), strSql As String

        mDB.Open()
        If Not mDB.IsConnected Then
            Return
        End If

        strSql = "Select * From FSM_CUSTOMER " _
           & "Where Stopped = 0 " _
           & "and CityID = " & frmMain.dtLoginStructure.Rows.Find(drCustomer("StoreID").ToString)("ParentAreaID").ToString & " " _
           & "and FSMCustomerID not in (select FSMCustomerID from CustomerList where not FSMCustomerID is null and FSMCustomerID <> '') "

        Try
            dtCityFSMCustomer = mDB.GetDataTable(strSql).Copy
            mDB.Close()
        Catch
            mDB.Close()
            Return
        End Try


    End Sub

    Private Function SelectDataViewTopCount(ByVal dvDataView As DataView, ByVal iCount As Integer) As DataView
        Dim dtDataTable As DataTable
        dtDataTable = dvDataView.Table.Clone
        For i As Integer = 0 To dvDataView.Count - 1
            If i > iCount - 1 Then Exit For
            dtDataTable.ImportRow(dvDataView(i).Row)
        Next
        Return New DataView(dtDataTable)
    End Function
    'modify code 025:end-------------------------------------------------------------------------

End Class