Imports System.IO
Imports System.Security.Cryptography

Public Class frmContract

    'modify code 038:
    'date;2014/9/24
    'auther:Hyron bjy 
    'remark:返点比率0.0->0.00

    Private drContract As DataRow, dtBeneficiary As DataTable, dtContractCustomer As DataTable, dtDisplayedCustomer As DataTable, dtDropdownCustomer As DataTable, drCustomer As DataRow, drSelectedCustomer As DataRow, dtStore As DataTable, dvInvoiceItem As DataView, dtApprovableRole As DataTable
    Private dvNewestCityRule As DataView, dvNewestRuleDetails As DataView, dvHistoryCityRule As DataView, dvHistoryRuleDetails As DataView
    Private blSkipDeal As Boolean = True, blCanValidate As Boolean, blCanModify As Boolean, blCanStop As Boolean, blMultiCompanies As Boolean = False, blContentChanged As Boolean = False
    Private errorCell As DataGridViewCell, editingTextBox As TextBox, sErrorInfo As String = "", sOldValue As String = "", dtToday As Date, iOriginalIndex As Int16 = -1
    Private sValidationDescription As String = "", sApprovableRoleChineseNames As String = "", sApprovableRoleEnglishNames As String = ""
    Private sCustomerName As String = "", sCustomerPrompt As String = "", sTimerType As String = "", bClicks As Byte = 0, sCityID As String = "", sCityName As String = "" '仅当登录用户是门店级用户使用

    Public dtContractDetails As DataTable, sCustomerID As String = "", sContractID As String = "-1", iFirstAvailableRowID As Int16 = -1, iSecondAvailableRowID As Int16 = -1

    '合同与客户的关系：
    '1、一个合同必须至少对应一个客户；
    '2、客户可以没有合同，或存在多个合同，但必须符合下面条件：
    '  1）若干个已过期合同（可能未审核、可能已审核）；
    '  2）同一日期下只能存在唯一一个已生效（指已审核且当前日期正处在合同期内）的合同；
    '  3）同一日期下只能存在唯一一个未生效（未审核，或者虽已审核但合同开始日期还未到来）的合同；
    '  4）所有已审核（含已过期）的合同的合同期不能重复。

    Private Sub frmContract_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub frmContract_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DB As New DataBase()
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打开合同窗口。请检查数据库连接。"
            Me.Close() : Return
        End If

        Try
            dtApprovableRole = DB.GetDataTable("Select * From ValidateContractRoleList").Copy
            dtBeneficiary = DB.GetDataTable("Select * From BeneficiaryList Where AreaID=" & frmMain.sLoginAreaID).Copy
            If frmMain.sLoginAreaType = "S" Then
                sCityID = frmMain.dtLoginStructure.Rows.Find(frmMain.sLoginAreaID)("ParentAreaID").ToString
                sCityName = DB.GetDataTable("Select Isnull(AreaChineseName,'')+' '+Isnull(AreaEnglishName,'') From AreaList Where AreaID=" & sCityID).Rows(0)(0).ToString.Trim
                dvInvoiceItem = DB.GetDataTable("Select C.CityID,C.ItemID,I.Content From InvoiceCityItem As C Join InvoiceItemList As I On C.ItemID=I.ItemID Where C.CityID=" & sCityID).DefaultView
            Else
                sCityID = frmMain.dtLoginStructure.Select("AreaType='C'")(0)("AreaID").ToString
                dvInvoiceItem = DB.GetDataTable("Select C.CityID,C.ItemID,I.Content From InvoiceCityItem As C Join InvoiceItemList As I On C.ItemID=I.ItemID Join AreaScope(" & frmMain.sLoginUserID & ") As A On C.CityID=A.AreaID").DefaultView
            End If
            dvInvoiceItem.Sort = "ItemID"

            dtContractCustomer = DB.GetDataTable("Select L.ContractID,L.CustomerID,L.RowID,M.CityID,M.StoreID,M.BusinessTypeID,M.CustomerCode,M.CustomerChineseName,M.CustomerEnglishName,M.Stopped,L.CityRuleID,L.InvoiceTitleCustomerID,L.InvoiceItem From ContractCustomer As L Join CustomerView As M On L.CustomerID=M.CustomerID Where L.ContractID=" & sContractID & " Order By L.RowID").Copy
            dtContractCustomer.Columns.Add("LastValidContractID", System.Type.GetType("System.Int32"))
            dtContractCustomer.Columns.Add("LastValidContractCode", System.Type.GetType("System.String"))
            dtContractCustomer.Columns.Add("LastValidContractStartDate", System.Type.GetType("System.DateTime"))
            dtContractCustomer.Columns.Add("LastValidContractEndDate", System.Type.GetType("System.DateTime"))

            If sContractID = "-1" Then
                drContract = DB.GetDataTable("Exec ContractSingle -1").Rows.Add
                dtToday = Today()
                If sCustomerID = "" Then
                    drContract("StartDate") = dtToday
                    If frmMain.sLoginAreaType = "S" Then drContract("SignPlace") = sCityName
                Else
                    Dim dtCustomer As DataTable = DB.GetDataTable("Exec CustomerSingle " & sCustomerID).Copy
                    If dtCustomer.Rows.Count = 0 Then
                        MessageBox.Show("您选择的客户已经不存在（可能被删除或移位）！    ", "客户不存在！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        If frmCustomerManagement.IsHandleCreated Then
                            Try
                                frmCustomerManagement.dvCustomer.Table.Rows.Find(sCustomerID).Delete()
                            Catch
                            End Try
                        End If
                        frmMain.statusText.Text = "客户不存在！"
                        drContract = Nothing
                        DB.Close() : Me.Close() : Return
                    End If

                    drSelectedCustomer = dtCustomer.Copy.Rows(0)
                    dtCustomer.Dispose() : dtCustomer = Nothing
                    If frmCustomerManagement.IsHandleCreated Then frmCustomerManagement.UpdateCustomer(drSelectedCustomer)

                    If drSelectedCustomer("Stopped") Then
                        MessageBox.Show("您选择的客户已被停止使用，再也不能为该客户创建合同！    " & Chr(13) & Chr(13) & "停用客户： " & drSelectedCustomer("StoreCode").ToString & drSelectedCustomer("CustomerCode").ToString & " " & drSelectedCustomer("CustomerChineseName").ToString & Space(4) & IIf(drSelectedCustomer("StoppedReason").ToString = "", "", Chr(13) & "停用原因： " & drSelectedCustomer("StoppedReason").ToString & Space(4)), "客户已被停止使用！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        frmMain.statusText.Text = "客户已被停止使用！"
                        drContract = Nothing : drSelectedCustomer = Nothing
                        DB.Close() : Me.Close() : Return
                    End If

                    If drSelectedCustomer("InvalidContractID").ToString <> "" Then
                        sContractID = drSelectedCustomer("InvalidContractID").ToString
                        Dim bAnswer As DialogResult = MessageBox.Show("您选择的客户存在未生效合同，不能向该客户创建新的合同！    " & Chr(13) & Chr(13) & _
                                                                      "客户名： " & drSelectedCustomer("StoreCode").ToString & drSelectedCustomer("CustomerCode").ToString & "    " & drSelectedCustomer("CustomerChineseName").ToString & Space(4) & Chr(13) & _
                                                                      "合同号： " & drSelectedCustomer("StoreCode").ToString & drSelectedCustomer("CustomerCode").ToString & drSelectedCustomer("InvalidContractCode").ToString & " （未生效）    " & Chr(13) & _
                                                                      "合同期： " & drSelectedCustomer("InvalidContractPeriod").ToString & Space(4) & Chr(13) & Chr(13) & _
                                                                      "但您可以选择打开该未生效的合同。是否打开？    ", "客户存在未生效合同！", MessageBoxButtons.OK, MessageBoxIcon.Question)
                        frmMain.statusText.Text = "客户存在未生效合同！"
                        drContract = Nothing : drSelectedCustomer = Nothing
                        If bAnswer = Windows.Forms.DialogResult.No Then
                            DB.Close() : Me.Close() : Return
                        Else
                            GoTo Open_Contract
                        End If
                    End If

                    Dim joinedCustomer As DataRow = dtContractCustomer.Rows.Add()
                    sCityID = drSelectedCustomer("CityID").ToString
                    joinedCustomer("CustomerID") = sCustomerID
                    joinedCustomer("RowID") = 1
                    joinedCustomer("CityID") = sCityID
                    joinedCustomer("StoreID") = drSelectedCustomer("StoreID")
                    joinedCustomer("CustomerCode") = drSelectedCustomer("StoreCode").ToString & drSelectedCustomer("CustomerCode").ToString
                    joinedCustomer("CustomerChineseName") = drSelectedCustomer("CustomerChineseName").ToString
                    joinedCustomer("CustomerChineseName") = drSelectedCustomer("CustomerChineseName").ToString
                    joinedCustomer("Stopped") = 0
                    joinedCustomer("InvoiceTitleCustomerID") = sCustomerID

                    If drSelectedCustomer("LastValidContractID").ToString = "" Then
                        joinedCustomer("LastValidContractID") = -1
                        drContract("StartDate") = dtToday
                    Else
                        joinedCustomer("LastValidContractID") = drSelectedCustomer("LastValidContractID")
                        joinedCustomer("LastValidContractCode") = drSelectedCustomer("LastValidContractCode")
                        joinedCustomer("LastValidContractStartDate") = drSelectedCustomer("LastValidContractStartDate")
                        joinedCustomer("LastValidContractEndDate") = drSelectedCustomer("LastValidContractEndDate")
                        drContract("StartDate") = IIf(DateAdd(DateInterval.Day, 1, joinedCustomer("LastValidContractEndDate")) > DateAdd(DateInterval.Day, -7, dtToday), DateAdd(DateInterval.Day, 1, joinedCustomer("LastValidContractEndDate")), DateAdd(DateInterval.Day, -7, dtToday))
                    End If
                    joinedCustomer.EndEdit() : joinedCustomer.AcceptChanges()

                    drContract("MainCustomerID") = sCustomerID : drContract("MainCustomerName") = (drSelectedCustomer("CustomerChineseName").ToString & " " & drSelectedCustomer("CustomerEnglishName").ToString).Trim
                    If frmMain.sLoginAreaType = "S" Then
                        drContract("SignPlace") = sCityName
                    Else
                        drContract("SignPlace") = frmMain.dtLoginStructure.Rows.Find(sCityID)("AreaFullName").ToString.Substring(5)
                    End If
                End If

                drContract("EndDate") = DateAdd(DateInterval.Year, 1, DateAdd(DateInterval.Day, -1, drContract("StartDate")))
                drContract("MaxRebateRate") = 0
                drContract("AppointedDate") = DateAdd(DateInterval.Month, 1, drContract("EndDate"))
                drContract("CalculationMode") = 0
                drContract("PaymentMode") = 0
                drContract("CalculationDay") = 255
                drContract("BNoticeWays") = "传真"
                drContract("ContractState") = 0
                drContract("CreatorID") = frmMain.sLoginUserID
                drContract("ModifierAreaID") = frmMain.sLoginAreaID
                drContract("ModifierRoleID") = frmMain.sLoginRoleID

                If dtBeneficiary.Rows.Count > 0 Then
                    drContract("ACompanyChineseName") = dtBeneficiary.Rows(0)("ACompanyChineseName").ToString
                    drContract("ACompanyEnglishName") = dtBeneficiary.Rows(0)("ACompanyEnglishName").ToString
                    drContract("Beneficiary") = dtBeneficiary.Rows(0)("Beneficiary").ToString
                    drContract("BankAccount") = dtBeneficiary.Rows(0)("BankAccount").ToString
                    drContract("Domiciliation") = dtBeneficiary.Rows(0)("Domiciliation").ToString
                End If

                dtContractDetails = DB.GetDataTable("Select * From ContractDetails Where 1=2").Copy
                dtContractDetails.Rows.Add(-1, 1, 0, DBNull.Value, 0)

                dvNewestCityRule = DB.GetDataTable("Select * From CityRule Where CityID=" & sCityID & " And RuleState=2").DefaultView
                If dvNewestCityRule.Count = 0 Then
                    dvNewestRuleDetails = DB.GetDataTable("Select * From CityRuleDetails Where RuleID=-1").DefaultView
                Else
                    dvNewestRuleDetails = DB.GetDataTable("Select * From CityRuleDetails Where RuleID=" & dvNewestCityRule(0)("RuleID").ToString).DefaultView
                End If

                blCanValidate = False : blCanModify = True : blCanStop = False : blContentChanged = True
            Else
Open_Contract:
                Me.Text = "合同 Contract: "
                Dim dtContract As DataTable = DB.GetDataTable("Exec ContractSingle " & sContractID)
                If dtContract.Rows.Count = 0 Then
                    MessageBox.Show("您所要打开的合同已经不存在（可能被删除）！    ", "合同不存在！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If frmCustomerManagement.IsHandleCreated Then
                        Dim customer As DataRow
                        For Each joinedCustomer As DataRow In dtContractCustomer.Rows
                            Try
                                customer = frmCustomerManagement.dvCustomer.Table.Rows.Find(joinedCustomer("CustomerID"))
                                customer("ValidContractID") = DBNull.Value
                                customer("ValidContractCode") = DBNull.Value
                                customer("InvalidContractID") = DBNull.Value
                                customer("InvalidContractCode") = DBNull.Value
                                customer.AcceptChanges() : customer = Nothing
                            Catch
                            End Try
                        Next
                        If frmCustomerManagement.dgvList.CurrentRow IsNot Nothing Then
                            frmCustomerManagement.dgvList.CurrentRow.Selected = False
                            frmCustomerManagement.dgvList.CurrentRow.Selected = True
                        End If
                    End If

                    If frmContractManagement.IsHandleCreated Then
                        Try
                            frmContractManagement.dvContract.Table.Rows.Find(sContractID).Delete()
                        Catch
                        End Try
                    End If
                    sContractID = ""
                    frmMain.statusText.Text = "合同不存在！"
                    dtContract.Dispose() : dtContract = Nothing
                    DB.Close() : Me.Close() : Return
                End If

                drContract = dtContract.Copy.Rows(0)
                dtContract.Dispose() : dtContract = Nothing
                blMultiCompanies = (dtContractCustomer.Rows.Count > 1)
                dtToday = drContract("Today")

                If dtBeneficiary.Select("ACompanyChineseName='" & drContract("ACompanyChineseName").ToString.Replace("'", "''") & "'").Length = 0 Then
                    dtBeneficiary.Rows.Add(frmMain.sLoginAreaID, drContract("ACompanyChineseName").ToString, drContract("ACompanyEnglishName").ToString, drContract("Beneficiary").ToString, drContract("BankAccount").ToString, drContract("Domiciliation").ToString).AcceptChanges()
                End If

                If dtContractDetails Is Nothing Then dtContractDetails = DB.GetDataTable("Select * From ContractDetails Where ContractID=" & sContractID).Copy
                For Each drDetail As DataRow In dtContractDetails.Rows
                    If drDetail("StartSalesAMT") > 0 Then drDetail("StartSalesAMT") = drDetail("StartSalesAMT")
                    drDetail("RebateRate") = drDetail("RebateRate") * 100
                    drDetail.AcceptChanges()
                Next

                Dim sCityIDs As String = "", sRuleIDs As String = ""
                For Each dr As DataRow In dtContractCustomer.Rows
                    If dr("CityRuleID").ToString <> "" Then sRuleIDs = dr("CityRuleID").ToString & ","
                Next
                If sRuleIDs = "" Then
                    dvHistoryCityRule = DB.GetDataTable("Select * From CityRule Where RuleID=-1").DefaultView
                Else
                    sRuleIDs = sRuleIDs.Substring(0, sRuleIDs.Length - 1)
                    dvHistoryCityRule = DB.GetDataTable("Select * From CityRule Where RuleID In (" & sRuleIDs & ")").DefaultView
                End If
                If dvHistoryCityRule.Count = 0 Then
                    dvHistoryRuleDetails = DB.GetDataTable("Select * From CityRuleDetails Where RuleID=-1").DefaultView
                Else
                    If sRuleIDs = "" Then
                        For Each dr As DataRowView In dvHistoryCityRule
                            sRuleIDs = dr("RuleID").ToString & ","
                        Next
                        sRuleIDs = sRuleIDs.Substring(0, sRuleIDs.Length - 1)
                    End If
                    dvHistoryRuleDetails = DB.GetDataTable("Select * From CityRuleDetails Where RuleID In (" & sRuleIDs & ")").DefaultView
                End If

                For Each dr As DataRow In dtContractCustomer.Rows
                    sCityIDs = dr("CityID").ToString & ","
                Next
                sCityIDs = sCityIDs.Substring(0, sCityIDs.Length - 1)
                dvNewestCityRule = DB.GetDataTable("Select * From CityRule Where CityID In (" & sCityIDs & ") And RuleState=2").DefaultView
                If dvNewestCityRule.Count = 0 Then
                    dvNewestRuleDetails = DB.GetDataTable("Select * From CityRuleDetails Where RuleID=-1").DefaultView
                Else
                    If sRuleIDs = "" Then
                        For Each dr As DataRowView In dvNewestCityRule
                            sRuleIDs = dr("RuleID").ToString & ","
                        Next
                        sRuleIDs = sRuleIDs.Substring(0, sRuleIDs.Length - 1)
                    End If
                    dvNewestRuleDetails = DB.GetDataTable("Select * From CityRuleDetails Where RuleID In (" & sRuleIDs & ")").DefaultView
                End If
                Me.CheckValidation()

                blCanModify = ("|0|1|3|".IndexOf("|" & drContract("ContractState").ToString & "|") > -1 AndAlso frmMain.dtAllowedRight.Select("RightName='ContractModify'").Length > 0)
                If blCanModify Then
                    For Each joinedCustomer As DataRow In dtContractCustomer.Rows
                        sCustomerID = joinedCustomer("CustomerID").ToString
                        drSelectedCustomer = DB.GetDataTable("Exec CustomerSingle " & sCustomerID).Rows(0)
                        If frmCustomerManagement.IsHandleCreated Then frmCustomerManagement.UpdateCustomer(drSelectedCustomer)
                        If drSelectedCustomer("LastValidContractID").ToString = "" Then
                            joinedCustomer("LastValidContractID") = -1
                        Else
                            joinedCustomer("LastValidContractID") = drSelectedCustomer("LastValidContractID")
                            joinedCustomer("LastValidContractCode") = drSelectedCustomer("LastValidContractCode")
                            joinedCustomer("LastValidContractStartDate") = drSelectedCustomer("LastValidContractStartDate")
                            joinedCustomer("LastValidContractEndDate") = drSelectedCustomer("LastValidContractEndDate")
                        End If
                        joinedCustomer.AcceptChanges()
                    Next
                End If
            End If
        Catch
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开合同窗口。请联系软件开发人员。"
            DB.Close() : Me.Close() : Return
        End Try
        DB.Close()

        If dvNewestCityRule IsNot Nothing Then dvNewestCityRule.Sort = "CityFullName"
        If dvNewestRuleDetails IsNot Nothing Then dvNewestRuleDetails.Sort = "RuleID,RowID"
        If dvHistoryCityRule IsNot Nothing Then dvHistoryCityRule.Sort = "CityFullName"
        If dvHistoryRuleDetails IsNot Nothing Then dvHistoryRuleDetails.Sort = "RuleID,RowID"

        dtDisplayedCustomer = New DataTable
        dtDisplayedCustomer.Columns.Add("CustomerID", System.Type.GetType("System.Int32"))
        dtDisplayedCustomer.Columns.Add("RowID", System.Type.GetType("System.Int16"))
        dtDisplayedCustomer.Columns.Add("CustomerCode", System.Type.GetType("System.String"))
        dtDisplayedCustomer.Columns.Add("CustomerName", System.Type.GetType("System.String"))
        dtDisplayedCustomer.Columns.Add("Stopped", System.Type.GetType("System.String"))
        dtDisplayedCustomer.Columns.Add("IsMain", System.Type.GetType("System.String"))
        dtDisplayedCustomer.Columns.Add("Error", System.Type.GetType("System.String"))
        dtDisplayedCustomer.Columns.Add("Delete", System.Type.GetType("System.String"))
        dtDisplayedCustomer.Columns.Add("IsBoth", System.Type.GetType("System.Boolean"))
        dtDisplayedCustomer.DefaultView.Sort = "RowID"

        dtStore = New DataTable()
        dtStore.Columns.Add("StoreID", System.Type.GetType("System.Int16"))
        dtStore.Columns.Add("StoreFullName", System.Type.GetType("System.String"))

        Dim displayedCustomer As DataRow, sStoreID As String
        For Each joinedCustomer As DataRow In dtContractCustomer.Select("", "RowID")
            displayedCustomer = dtDisplayedCustomer.Rows.Add()
            displayedCustomer("CustomerID") = joinedCustomer("CustomerID")
            displayedCustomer("RowID") = joinedCustomer("RowID")
            displayedCustomer("CustomerCode") = joinedCustomer("CustomerCode").ToString
            If joinedCustomer("CustomerChineseName").ToString <> "" AndAlso joinedCustomer("CustomerEnglishName").ToString <> "" Then
                displayedCustomer("CustomerName") = joinedCustomer("CustomerChineseName").ToString & Chr(13) & joinedCustomer("CustomerEnglishName").ToString
                displayedCustomer("IsBoth") = 1
            Else
                displayedCustomer("CustomerName") = joinedCustomer("CustomerChineseName").ToString & joinedCustomer("CustomerEnglishName").ToString
                displayedCustomer("IsBoth") = 0
            End If
            If joinedCustomer("Stopped") Then displayedCustomer("Stopped") = " (Stopped) "
            If joinedCustomer("RowID") = 1 Then displayedCustomer("IsMain") = " (Main Company) "
            displayedCustomer("Delete") = "Delete"
            displayedCustomer.EndEdit() : displayedCustomer.AcceptChanges()

            sStoreID = joinedCustomer("StoreID").ToString
            If dtStore.Select("StoreID=" & sStoreID).Length = 0 Then
                dtStore.Rows.Add(sStoreID, frmMain.dtLoginStructure.Rows.Find(sStoreID)("AreaFullName").ToString).AcceptChanges()
            End If
        Next

        Dim dtCity As DataTable = dtContractCustomer.DefaultView.ToTable(True, "CityID")
        If dtCity.Rows.Count < 1 Then
            dvInvoiceItem.RowFilter = "CityID=" & sCityID
        Else
            Dim sCityIDs As String = ""
            For Each drCity As DataRow In dtCity.Rows
                sCityIDs = sCityIDs & drCity("CityID").ToString & ","
            Next
            sCityIDs = sCityIDs.Substring(0, sCityIDs.Length - 1)
            dvInvoiceItem.RowFilter = "CityID=" & sCityIDs.Replace(",", " And CityID=")
        End If
        dtCity.Dispose() : dtCity = Nothing

        sCustomerID = ""
        Me.FillContract()

        blSkipDeal = False
        frmMain.statusText.Text = "就绪。"
        If sContractID = "-1" Then
            If Me.txbACompanyChineseName.Text = "" Then
                Me.txbACompanyChineseName.Select()
            Else
                Me.txbCustomerName.Select()
            End If
        Else
            Dim mainCustomer As DataRow = dtContractCustomer.Select("RowID=1")(0)
            Me.Text = "合同 Contract: " & Me.txbCustomerCode.Text & Me.txbContractCode.Text & " " & (mainCustomer("CustomerChineseName").ToString & " " & mainCustomer("CustomerEnglishName").ToString).Trim
            If Me.rdbOK.Visible Then
                Me.rdbOK.AutoCheck = False
                Me.rdbOK.Select()
                Me.rdbOK.AutoCheck = True
            Else
                Me.txbContratState.Select() : Me.txbContratState.SelectAll()
            End If
        End If

        If sContractID <> "-1" AndAlso Not blCanValidate AndAlso Not blCanModify AndAlso Not blCanStop Then
            Me.Text = Me.Text & " (只读 Readonly)"
        ElseIf drContract("EndDate") < dtToday Then
            blCanModify = False
            blCanStop = False
            Me.Text = Me.Text & " (已过期 Expired)"
        End If

        sCustomerPrompt = "提示：您可以输入客户编号、客户名称中的部分文字或客户名称拼音码来确定客户。"
        sCustomerID = ""

        Me.Height = My.Computer.Screen.WorkingArea.Height - 25
        Me.Location = New Point(Int((My.Computer.Screen.WorkingArea.Width - Me.Width) / 2), 0)

        If iFirstAvailableRowID <> -1 OrElse iSecondAvailableRowID <> -1 Then
            Me.dgvDetails.DefaultCellStyle.SelectionForeColor = Me.dgvDetails.DefaultCellStyle.ForeColor
            Me.dgvDetails.DefaultCellStyle.SelectionBackColor = IIf(Me.dgvDetails.ReadOnly, SystemColors.Control, SystemColors.Window)
            Me.lblAvailable.Visible = True
            Me.grbDetails.Select()
        End If
    End Sub

    Private Sub theTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles theTimer.Tick
        Me.theTimer.Enabled = False

        Select Case sTimerType
            Case "MultiCustomer"
                If Me.ActiveControl IsNot Nothing AndAlso Me.ActiveControl.Name <> "btnNewCustomer" Then
                    Me.cbbCustomerName.Cursor = Cursors.Arrow
                    Me.cbbCustomerName.Focus() : Me.cbbCustomerName.Select() : Me.cbbCustomerName.SelectAll() : Me.cbbCustomerName.DroppedDown = True
                Else
                    frmMain.statusText.Text = "就绪。"
                End If
            Case "DoubleClick"
                bClicks = 0
            Case "CreateCustomer"
                Me.btnNewCustomer.PerformClick()
            Case "AfterCreatedCustomer"
                Me.txbCustomerName.Focus() : Me.txbCustomerName.Select() : Me.txbCustomerName.SelectAll()
                sCustomerPrompt = "提示：请按右边的""Join""按钮将此新增加的客户添加到乙方公司列表中。"
                frmMain.statusText.Text = sCustomerPrompt
            Case "CheckChanges"
                Me.CheckChanges()
        End Select
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Me.SaveChanges() Then Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If frmMain.dtAllowedRight.Select("RightName='ContractPrint'").Length = 0 Then
            MessageBox.Show("对不起！您没有打印合同文本的权限。    " & Chr(13) & "Sorry, you have no right to print contract text.    ", "您无权打印合同文本 No right to print contract text!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.btnPrint.Enabled = False
            Return
        End If

        MessageBox.Show("对不起，功能未完善，暂不可使用！    ", "暂不可使用此功能。", MessageBoxButtons.OK)
        Return

        'Me.Cursor = Cursors.WaitCursor
        'frmMain.statusText.Text = "正在检查您的电脑是否安装了Microsoft Word……"
        'frmMain.statusMain.Refresh()

        'Dim wordAPP As Object = Nothing
        'Try
        '    wordAPP = GetObject(, "Word.Application")
        'Catch
        'End Try

        'If wordAPP Is Nothing Then
        '    Try
        '        wordAPP = CreateObject("Word.Application")
        '        wordAPP.Visible = False
        '    Catch ex As Exception
        '        If wordAPP Is Nothing Then
        '            MessageBox.Show("您的电脑还未安装 Microsoft Word。因此，您无法使用该功能。    ", "请先安装 Microsoft Word 应用程序。", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '            frmMain.statusText.Text = "您的电脑还未安装 Microsoft Word！"
        '        Else
        '            MessageBox.Show("您电脑上的 Microsoft Word 不能正常使用！因此，您无法使用该功能。    ", "请检查 Microsoft Word 应用程序或重启电脑。", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '            frmMain.statusText.Text = "您电脑上的 Microsoft Word 不能正常使用！"
        '            wordAPP = Nothing
        '        End If
        '        Me.Cursor = Cursors.Default : Return
        '    End Try
        'End If


        'Dim sTemplateFile As String = "", sLocalFileMD5Code As String = "", sRemoteFileMD5Code As String = ""
        'Try
        '    If Not Directory.Exists(Application.StartupPath & "\ContractTemplates") Then Directory.CreateDirectory(Application.StartupPath & "\ContractTemplates")
        '    sTemplateFile = Application.StartupPath & "\ContractTemplates\ContractTemplate.doc"
        '    If File.Exists(sTemplateFile) Then
        '        sLocalFileMD5Code = Me.GetFileMD5Code(sTemplateFile)
        '        If Not My.Computer.Network.IsAvailable Then
        '            MessageBox.Show("系统不能连接到总部服务器检查合同模板文件的版本！     " & Chr(13) & Chr(13) & "请检查网络连接，然后重试。    ", "连接不到总部服务器！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '            frmMain.statusText.Text = "系统不能连接到总部服务器检查合同模板文件的版本！"
        '            wordAPP.Quit() : wordAPP = Nothing
        '            Me.Cursor = Cursors.Default : Return
        '        End If
        '    ElseIf Not My.Computer.Network.IsAvailable Then
        '        MessageBox.Show("系统不能连接到总部服务器下载合同模板文件！     " & Chr(13) & Chr(13) & "请检查网络连接，然后重试。    ", "连接不到总部服务器！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '        frmMain.statusText.Text = "系统不能连接到总部服务器下载合同模板文件！"
        '        wordAPP.Quit() : wordAPP = Nothing
        '        Me.Cursor = Cursors.Default : Return
        '    End If

        '    Dim myWebClient As New Net.WebClient(), blNeedDownload As Boolean = False
        '    myWebClient.Proxy = Nothing
        '    myWebClient.CachePolicy = New Net.Cache.RequestCachePolicy(Net.Cache.RequestCacheLevel.NoCacheNoStore)

        '    If sLocalFileMD5Code <> "" Then
        '        frmMain.statusText.Text = "正在检查合同模板文件的版本……"
        '        frmMain.statusMain.Refresh()
        '        Try
        '            sRemoteFileMD5Code = myWebClient.DownloadString(SecurityText.DecryptData("qfESIwi33U83ObMfQirMJlrPiRIFxKfOfLLpjqnSw84yAzwTfLJfi+JjK1eoOijrV+oF3uIB4IIj7EKwPPYARcBSwIMzg+mGGPQy6jVGHte7kTeM/ia/BEG2Hip0rQRWDJqZiX45SBRboTKKkZOVm/j07X6IwrlYeXgnRq7JCMZ1xvkdiyatH/tTO9pAO1FT"))
        '            sRemoteFileMD5Code = sRemoteFileMD5Code.Substring(sRemoteFileMD5Code.IndexOf(":") + 1).Trim
        '        Catch
        '            sRemoteFileMD5Code = sLocalFileMD5Code
        '        End Try

        '        If sRemoteFileMD5Code <> sLocalFileMD5Code Then
        '            File.Delete(sTemplateFile)
        '            frmMain.statusText.Text = "正在从总部服务器中下载最新版本的合同模板文件……"
        '            blNeedDownload = True
        '        End If
        '    Else
        '        frmMain.statusText.Text = "正在从总部服务器中下载合同模板文件……"
        '        blNeedDownload = True
        '    End If

        '    If blNeedDownload Then
        '        frmMain.statusMain.Refresh()
        '        Try
        '            myWebClient.DownloadFile(SecurityText.DecryptData("qfESIwi33U83ObMfQirMJlrPiRIFxKfOfLLpjqnSw84yAzwTfLJfi+JjK1eoOijrV+oF3uIB4IIj7EKwPPYARcBSwIMzg+mGGPQy6jVGHte7kTeM/ia/BEG2Hip0rQRWzRXMODwBVZZd0lHZMrplXYCO5kFmkWypicIk2batkvfkIodM86vRXygu+4vw7OvE7H1LyjJZ7GqOAkSB4TmBBQ=="), sTemplateFile)
        '        Catch exDownload As Exception
        '            MessageBox.Show("系统试图从总部服务器下载合同模版文件时出错！下面是错误提示：    " & Chr(13) & Chr(13) & exDownload.Message & Space(4), "下载合同模版文件时出错！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '            frmMain.statusText.Text = "下载合同模版文件时出错！"
        '            myWebClient.Dispose() : myWebClient = Nothing
        '            wordAPP.Quit() : wordAPP = Nothing
        '            Me.Cursor = Cursors.Default : Return
        '        End Try
        '    End If

        '    myWebClient.Dispose() : myWebClient = Nothing
        'Catch ex As Exception
        '    MessageBox.Show("系统检查合同模版文件时出错！下面是错误提示：    " & Chr(13) & Chr(13) & ex.Message & Space(4), "检查合同模版文件时出错！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    frmMain.statusText.Text = "检查合同模版文件时出错！"
        '    wordAPP.Quit() : wordAPP = Nothing
        '    Me.Cursor = Cursors.Default : Return
        'End Try

        'If My.Settings.ContractPrinter = "" Then
        '    Me.btnSelectPrinter.PerformClick()
        '    If My.Settings.ContractPrinter = "" Then
        '        wordAPP.Quit() : wordAPP = Nothing
        '        Me.Cursor = Cursors.Default : Return
        '    End If
        'End If

        'frmMain.statusText.Text = "正在打印合同文本……"
        'frmMain.statusMain.Refresh()

        'Try
        '    wordAPP.Windows("Contract Template.doc").Close(False)
        'Catch
        'End Try

        'Try
        '    wordAPP.Documents.Open(sTemplateFile, , , , "c@rr1f0ur")
        '    wordAPP.ActiveDocument.Content.Find.Execute("【家乐福商业公司名称】", , , , , , , , , drContract("Beneficiary").ToString)
        '    wordAPP.ActiveDocument.Content.Find.Execute("【Carrefour Commercial Company】", , , , , , , , , drContract("Beneficiary").ToString)
        '    wordAPP.ActiveDocument.Content.Find.Execute("【客户公司名称】", , , , , , , , , drCustomer("CustomerChineseName").ToString)
        '    wordAPP.ActiveDocument.Content.Find.Execute("【Customer Company】", , , , , , , , , IIf(drCustomer("CustomerEnglishName").ToString = "", drCustomer("CustomerChineseName").ToString, drCustomer("CustomerEnglishName").ToString))
        '    Dim sCityChineseName As String = Me.txbCityName.Text, sCityEnglishName As String = sCityChineseName
        '    If sCityChineseName.IndexOf(" ") > -1 Then sCityChineseName = sCityChineseName.Substring(0, sCityChineseName.IndexOf(" ")).Trim
        '    If sCityChineseName.Substring(sCityChineseName.Length - 1, 1) = "市" Then sCityChineseName = sCityChineseName.Substring(0, sCityChineseName.Length - 1)
        '    If sCityEnglishName.IndexOf(" ") > -1 Then
        '        sCityEnglishName = sCityEnglishName.Substring(sCityEnglishName.IndexOf(" ")).Trim
        '        If sCityEnglishName.Substring(sCityEnglishName.Length - 4, 4).ToUpper = "CITY" Then sCityEnglishName = sCityEnglishName.Substring(0, sCityEnglishName.Length - 4).Trim
        '    End If
        '    wordAPP.ActiveDocument.Content.Find.Execute("【城市】", , , , , , , , , sCityChineseName, 2)
        '    wordAPP.ActiveDocument.Content.Find.Execute("【City Name】", , , , , , , , , sCityEnglishName, 2)
        '    wordAPP.ActiveDocument.Content.Find.Execute("【开始日期】", , , , , , , , , Format(drContract("StartDate"), "yyyy'年'MM'月'dd'日'"), 2)
        '    wordAPP.ActiveDocument.Content.Find.Execute("【结束日期】", , , , , , , , , Format(drContract("EndDate"), "yyyy'年'MM'月'dd'日'"), 2)
        '    Dim culture As New System.Globalization.CultureInfo("en-US")
        '    wordAPP.ActiveDocument.Content.Find.Execute("【Start Date】", , , , , , , , , CDate(drContract("StartDate")).ToString("MMMM d, yyyy", culture), 2)
        '    wordAPP.ActiveDocument.Content.Find.Execute("【End Date】", , , , , , , , , CDate(drContract("EndDate")).ToString("MMMM d, yyyy", culture), 2)
        '    wordAPP.ActiveDocument.Content.Find.Execute("【通知方式】", , , , , , , , , drContract("BNoticeWays").ToString, 2)
        '    wordAPP.ActiveDocument.Content.Find.Execute("【Notice Ways】", , , , , , , , , drContract("BNoticeWays").ToString, 2)
        '    wordAPP.ActiveDocument.Content.Find.Execute("【公司账户名称】", , , , , , , , , drContract("Beneficiary").ToString, 2)
        '    wordAPP.ActiveDocument.Content.Find.Execute("【公司账号】", , , , , , , , , drContract("BankAccount").ToString, 2)
        '    wordAPP.ActiveDocument.Content.Find.Execute("【开户行】", , , , , , , , , drContract("Domiciliation").ToString, 2)
        '    wordAPP.ActiveDocument.Content.Find.Execute("【发票抬头】", , , , , , , , , drContract("InvoiceTitle").ToString, 2)
        '    Dim sInvoiceItems As String = drContract("InvoiceItem").ToString
        '    If sInvoiceItems = "" Then
        '        sInvoiceItems = "任何符合甲方税务政策的发票品项"
        '    ElseIf sInvoiceItems.LastIndexOf("、") > -1 Then
        '        sInvoiceItems = sInvoiceItems.Substring(0, sInvoiceItems.LastIndexOf("、") - 1) & "或" & sInvoiceItems.Substring(sInvoiceItems.LastIndexOf("、"))
        '    End If
        '    wordAPP.ActiveDocument.Content.Find.Execute("【发票品项】", , , , , , , , , sInvoiceItems, 2)

        '    Dim iStart As Integer, iEnd As Integer
        '    wordAPP.Selection.HomeKey(6)
        '    wordAPP.Selection.Find.Execute("<Start>")
        '    iStart = wordAPP.Selection.Start
        '    wordAPP.Selection.MoveDown(5, 1)
        '    wordAPP.Selection.Find.Execute("<Next>")
        '    iEnd = wordAPP.Selection.End
        '    wordAPP.ActiveDocument.Range(iStart, iEnd).Select()
        '    wordAPP.Selection.Find.Execute("<Start>", , , , , , , 0, , "")
        '    iStart = wordAPP.Selection.Start
        '    wordAPP.Selection.Find.Execute("<Next>")
        '    iEnd = wordAPP.Selection.End
        '    wordAPP.ActiveDocument.Range(iStart, iEnd).Select()
        '    wordAPP.Selection.Find.Execute("【Start AMT】", , , , , , , 0, , Format(dtDetails.Rows(0)("EndSalesAMT"), "#,0.00").Replace(".00", ""), 2)
        '    wordAPP.Selection.Find.Execute("<Next>")
        '    iEnd = wordAPP.Selection.End
        '    wordAPP.ActiveDocument.Range(iStart, iEnd).Select()
        '    wordAPP.Selection.Find.Execute("【Start Discount】", , , , , , , 0, , Format(dtDetails.Rows(0)("RebateRate"), "#,0.0"), 2)

        '    Dim sPreviousAMT As String, sPreviousChineseItems As String = "4.1", sPreviousEnglishItems As String = "4.1", sNextAMT As String, sNextDiscount As String, iRow As Int16 = 1
        '    For iRow = 1 To dtDetails.Rows.Count - 3
        '        sPreviousAMT = Format(dtDetails.Rows(iRow)("StartSalesAMT"), "#,0.00").Replace(".00", "")
        '        If iRow > 1 Then
        '            sPreviousChineseItems = sPreviousChineseItems.Replace("和", "、") & "和4." & iRow.ToString
        '            sPreviousEnglishItems = sPreviousEnglishItems.Replace(" and", ",") & " and 4." & iRow.ToString
        '        End If
        '        sNextAMT = Format(dtDetails.Rows(iRow)("EndSalesAMT"), "#,0.00").Replace(".00", "")
        '        sNextDiscount = Format(dtDetails.Rows(iRow)("RebateRate"), "#,0.0")

        '        wordAPP.Selection.HomeKey(6)
        '        wordAPP.Selection.Find.Execute("<Next>")
        '        iStart = wordAPP.Selection.Start
        '        wordAPP.Selection.MoveDown(5, 1)
        '        wordAPP.Selection.Find.Execute("<Previous>")
        '        iEnd = wordAPP.Selection.End
        '        wordAPP.ActiveDocument.Range(iStart, iEnd).Select()
        '        wordAPP.Selection.Copy()
        '        wordAPP.Selection.MoveRight(1, 1)
        '        wordAPP.Selection.PasteAndFormat(16)
        '        wordAPP.ActiveDocument.Range(iStart, iEnd).Select()
        '        wordAPP.Selection.Find.Execute("<Next>", , , , , , , 0, , "")
        '        iStart = wordAPP.Selection.Start
        '        wordAPP.Selection.Find.Execute("<Previous>", , , , , , , 0)
        '        iEnd = wordAPP.Selection.End
        '        wordAPP.ActiveDocument.Range(iStart, iEnd).Select()
        '        wordAPP.Selection.Find.Execute("【Previous AMT】", , , , , , , 0, , sPreviousAMT, 2)
        '        wordAPP.Selection.Find.Execute("<Previous>", , , , , , , 0)
        '        iEnd = wordAPP.Selection.End
        '        wordAPP.ActiveDocument.Range(iStart, iEnd).Select()
        '        wordAPP.Selection.Find.Execute("【Previous Chinese Items】", , , , , , , 0, , sPreviousChineseItems, 2)
        '        wordAPP.Selection.Find.Execute("<Previous>", , , , , , , 0)
        '        iEnd = wordAPP.Selection.End
        '        wordAPP.ActiveDocument.Range(iStart, iEnd).Select()
        '        wordAPP.Selection.Find.Execute("【Previous English Items】", , , , , , , 0, , sPreviousEnglishItems, 2)
        '        wordAPP.Selection.Find.Execute("<Previous>", , , , , , , 0)
        '        iEnd = wordAPP.Selection.End
        '        wordAPP.ActiveDocument.Range(iStart, iEnd).Select()
        '        wordAPP.Selection.Find.Execute("【Next AMT】", , , , , , , 0, , sNextAMT, 2)
        '        wordAPP.Selection.Find.Execute("<Previous>", , , , , , , 0)
        '        iEnd = wordAPP.Selection.End
        '        wordAPP.ActiveDocument.Range(iStart, iEnd).Select()
        '        wordAPP.Selection.Find.Execute("【Next Discount】", , , , , , , 0, , sNextDiscount, 2)
        '        wordAPP.Selection.Find.Execute("<Previous>", , , , , , , 0)
        '        iEnd = wordAPP.Selection.End
        '        wordAPP.ActiveDocument.Range(iStart, iEnd).Select()
        '        wordAPP.Selection.Find.Execute("<Previous>", , , , , , , 0, , "")
        '    Next

        '    sPreviousAMT = Format(dtDetails.Rows(iRow)("StartSalesAMT"), "#,0.00").Replace(".00", "")
        '    sPreviousChineseItems = sPreviousChineseItems.Replace("和", "、") & "和4." & iRow.ToString
        '    sPreviousEnglishItems = sPreviousEnglishItems.Replace(" and", ",") & " and 4." & iRow.ToString
        '    sNextAMT = Format(dtDetails.Rows(iRow)("EndSalesAMT"), "#,0.00").Replace(".00", "")
        '    sNextDiscount = Format(dtDetails.Rows(iRow)("RebateRate"), "#,0.0")

        '    wordAPP.Selection.HomeKey(6)
        '    wordAPP.Selection.Find.Execute("<Next>")
        '    iStart = wordAPP.Selection.Start
        '    wordAPP.Selection.MoveDown(5, 1)
        '    wordAPP.Selection.Find.Execute("<Previous>")
        '    iEnd = wordAPP.Selection.End
        '    wordAPP.ActiveDocument.Range(iStart, iEnd).Select()
        '    wordAPP.Selection.Find.Execute("<Next>", , , , , , , 0, , "")
        '    iStart = wordAPP.Selection.Start
        '    wordAPP.Selection.Find.Execute("<Previous>", , , , , , , 0)
        '    iEnd = wordAPP.Selection.End
        '    wordAPP.ActiveDocument.Range(iStart, iEnd).Select()
        '    wordAPP.Selection.Find.Execute("【Previous AMT】", , , , , , , 0, , sPreviousAMT, 2)
        '    wordAPP.Selection.Find.Execute("<Previous>", , , , , , , 0)
        '    iEnd = wordAPP.Selection.End
        '    wordAPP.ActiveDocument.Range(iStart, iEnd).Select()
        '    wordAPP.Selection.Find.Execute("【Previous Chinese Items】", , , , , , , 0, , sPreviousChineseItems, 2)
        '    wordAPP.Selection.Find.Execute("<Previous>", , , , , , , 0)
        '    iEnd = wordAPP.Selection.End
        '    wordAPP.ActiveDocument.Range(iStart, iEnd).Select()
        '    wordAPP.Selection.Find.Execute("【Previous English Items】", , , , , , , 0, , sPreviousEnglishItems, 2)
        '    wordAPP.Selection.Find.Execute("<Previous>", , , , , , , 0)
        '    iEnd = wordAPP.Selection.End
        '    wordAPP.ActiveDocument.Range(iStart, iEnd).Select()
        '    wordAPP.Selection.Find.Execute("【Next AMT】", , , , , , , 0, , sNextAMT, 2)
        '    wordAPP.Selection.Find.Execute("<Previous>", , , , , , , 0)
        '    iEnd = wordAPP.Selection.End
        '    wordAPP.ActiveDocument.Range(iStart, iEnd).Select()
        '    wordAPP.Selection.Find.Execute("【Next Discount】", , , , , , , 0, , sNextDiscount, 2)
        '    wordAPP.Selection.Find.Execute("<Previous>", , , , , , , 0)
        '    iEnd = wordAPP.Selection.End
        '    wordAPP.ActiveDocument.Range(iStart, iEnd).Select()
        '    wordAPP.Selection.Find.Execute("<Previous>", , , , , , , 0, , "")

        '    iRow += 1
        '    sPreviousAMT = sNextAMT
        '    sPreviousChineseItems = sPreviousChineseItems.Replace("和", "、") & "和4." & iRow.ToString
        '    sPreviousEnglishItems = sPreviousEnglishItems.Replace(" and", ",") & " and 4." & iRow.ToString
        '    sNextDiscount = Format(dtDetails.Rows(iRow)("RebateRate"), "#,0.0")

        '    wordAPP.Selection.HomeKey(6)
        '    wordAPP.Selection.Find.Execute("<Previous>")
        '    iStart = wordAPP.Selection.Start
        '    wordAPP.Selection.MoveDown(5, 1)
        '    wordAPP.Selection.Find.Execute("<End>")
        '    iEnd = wordAPP.Selection.End
        '    wordAPP.ActiveDocument.Range(iStart, iEnd).Select()
        '    wordAPP.Selection.Find.Execute("<Previous>", , , , , , , 0, , "")
        '    iStart = wordAPP.Selection.Start
        '    wordAPP.Selection.Find.Execute("<End>", , , , , , , 0)
        '    wordAPP.ActiveDocument.Range(iStart, iEnd).Select()
        '    wordAPP.Selection.Find.Execute("【Previous AMT】", , , , , , , 0, , sPreviousAMT, 2)
        '    wordAPP.Selection.Find.Execute("<End>", , , , , , , 0)
        '    iEnd = wordAPP.Selection.End
        '    wordAPP.ActiveDocument.Range(iStart, iEnd).Select()
        '    wordAPP.Selection.Find.Execute("【Previous Chinese Items】", , , , , , , 0, , sPreviousChineseItems, 2)
        '    wordAPP.Selection.Find.Execute("<End>", , , , , , , 0)
        '    iEnd = wordAPP.Selection.End
        '    wordAPP.ActiveDocument.Range(iStart, iEnd).Select()
        '    wordAPP.Selection.Find.Execute("【Previous English Items】", , , , , , , 0, , sPreviousEnglishItems, 2)
        '    wordAPP.Selection.Find.Execute("<End>", , , , , , , 0)
        '    iEnd = wordAPP.Selection.End
        '    wordAPP.ActiveDocument.Range(iStart, iEnd).Select()
        '    wordAPP.Selection.Find.Execute("【End Discount】", , , , , , , 0, , sNextDiscount, 2)
        '    wordAPP.Selection.Find.Execute("<End>", , , , , , , 0)
        '    iEnd = wordAPP.Selection.End
        '    wordAPP.ActiveDocument.Range(iStart, iEnd).Select()
        '    wordAPP.Selection.Find.Execute("<End>", , , , , , , 0, , "")

        '    Try
        '        'wordAPP.ActiveDocument.Saveas("D:\Contract Templates\Sample.doc")
        '        wordAPP.ActivePrinter = My.Settings.ContractPrinter
        '        wordAPP.ActiveDocument.PrintOut()
        '        frmMain.statusText.Text = "打印合同文本成功。"
        '    Catch exPrint As Exception
        '        MessageBox.Show("打印合同文本时发生错误！下面是错误提示：    " & Chr(13) & Chr(13) & exPrint.Message & Space(4), "打印合同文本时出错！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '        frmMain.statusText.Text = "打印合同文本时出错！"
        '    End Try
        'Catch ex As Exception
        '    MessageBox.Show("打印合同文本时发生错误！下面是错误提示：    " & Chr(13) & Chr(13) & ex.Message & Space(4), "打印合同文本时出错！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    frmMain.statusText.Text = "打印合同文本时出错！"
        'End Try

        'Try
        '    wordAPP.ActiveDocument.Close(False)
        '    wordAPP.Quit()
        '    wordAPP = Nothing
        'Finally
        '    Me.Cursor = Cursors.Default
        'End Try
    End Sub

    Private Sub btnPrint_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.EnabledChanged
        Me.btnSelectPrinter.Enabled = Me.btnPrint.Enabled
    End Sub

    Private Sub btnSelectPrinter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectPrinter.Click
        If frmMain.dtAllowedRight.Select("RightName='ContractPrint'").Length = 0 Then
            MessageBox.Show("因为您没有打印合同文本的权限，所以您不必要选择打印机。    " & Chr(13) & "Because you have no right to print contract text, so you don't need select printer.    ", "您无须选择打印机 Don't need select printer!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.btnSelectPrinter.Enabled = False
            Return
        End If

        If Printing.PrinterSettings.InstalledPrinters.Count = 0 Then
            MessageBox.Show("您的电脑未发现打印机！请先安装打印机。    ", "未发现打印机！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "未发现打印机！"
            Return
        End If

        With frmConfigTicket
            .Text = "请选择用于打印合同文本的打印机："
            For Each sPrinter As String In Printing.PrinterSettings.InstalledPrinters
                .cbbPrinter.Items.Add(sPrinter)
            Next
            If My.Settings.ContractPrinter <> "" AndAlso .cbbPrinter.Items.IndexOf(My.Settings.ContractPrinter) > -1 Then
                .cbbPrinter.SelectedIndex = .cbbPrinter.Items.IndexOf(My.Settings.ContractPrinter)
                If .Text.IndexOf("不再可用") > -1 Then
                    .cbbPrinter.Items(.cbbPrinter.Items.IndexOf(My.Settings.ContractPrinter)) = My.Settings.ContractPrinter & "（不可用）"
                End If
            Else
                Dim printDoc As New Printing.PrintDocument
                .cbbPrinter.SelectedIndex = .cbbPrinter.Items.IndexOf(printDoc.PrinterSettings.PrinterName)
                printDoc.Dispose() : printDoc = Nothing
            End If

            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                My.Settings.ContractPrinter = .cbbPrinter.Text
                My.Settings.Save()
            End If

            .Dispose()
        End With
    End Sub

    Private Sub rdbFirstOK_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbFirstOK.CheckedChanged
        If blSkipDeal Then Return

        If Me.rdbFirstOK.Checked Then
            drContract("ContractState") = 2 : drContract("StateReason") = DBNull.Value
            Me.CheckChanges()

            blCanModify = False
            Me.ResetControls()
        End If
    End Sub

    Private Sub rdbFirstFailure_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbFirstFailure.CheckedChanged
        Me.txbFirstFailureReason.Enabled = Me.rdbFirstFailure.Checked
        If blSkipDeal Then Return

        If Me.rdbFirstFailure.Checked Then
            drContract("ContractState") = 1
            drContract("StateReason") = Me.txbFirstFailureReason.Text
            Me.CheckChanges()

            blCanModify = (frmMain.dtAllowedRight.Select("RightName='ContractModify'").Length > 0)
            Me.ResetControls()

            Me.txbFirstFailureReason.Select()
            Me.txbFirstFailureReason.SelectAll()
        End If
    End Sub

    Private Sub txbFirstFailureReason_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbFirstFailureReason.DoubleClick
        If Me.txbFirstFailureReason.ReadOnly = True Then Return
        Me.txbFirstFailureReason.SelectAll()
    End Sub

    Private Sub txbFirstFailureReason_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbFirstFailureReason.Leave
        If Me.txbFirstFailureReason.Text <> Me.txbFirstFailureReason.Text.Trim Then Me.txbFirstFailureReason.Text = Me.txbFirstFailureReason.Text.Trim
        If Me.txbFirstFailureReason.Text = "" Then Me.txbFirstFailureReason.Text = drContract("StateReason").ToString
        If drContract("StateReason").ToString <> Me.txbFirstFailureReason.Text Then
            drContract("StateReason") = Me.txbFirstFailureReason.Text
            Me.CheckChanges()
        End If
    End Sub

    Private Sub rdbHOOK_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbHOOK.CheckedChanged
        If blSkipDeal Then Return

        If Me.rdbHOOK.Checked Then
            drContract("ContractState") = 4 : drContract("StateReason") = DBNull.Value
            Me.CheckChanges()

            blCanModify = False
            Me.ResetControls()
        End If
    End Sub

    Private Sub rdbHOFailure_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbHOFailure.CheckedChanged
        Me.txbHOFailureReason.Enabled = Me.rdbHOFailure.Checked
        If blSkipDeal Then Return

        If Me.rdbHOFailure.Checked Then
            drContract("ContractState") = 3
            drContract("StateReason") = Me.txbHOFailureReason.Text
            Me.CheckChanges()

            blCanModify = (frmMain.dtAllowedRight.Select("RightName='ContractModify'").Length > 0)
            Me.ResetControls()

            Me.txbHOFailureReason.Select()
            Me.txbHOFailureReason.SelectAll()
        End If
    End Sub

    Private Sub txbHOFailureReason_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbHOFailureReason.DoubleClick
        If Me.txbHOFailureReason.ReadOnly = True Then Return
        Me.txbHOFailureReason.SelectAll()
    End Sub

    Private Sub txbHOFailureReason_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbHOFailureReason.Leave
        If Me.txbHOFailureReason.Text <> Me.txbHOFailureReason.Text.Trim Then Me.txbHOFailureReason.Text = Me.txbHOFailureReason.Text.Trim
        If Me.txbHOFailureReason.Text = "" Then Me.txbHOFailureReason.Text = drContract("StateReason").ToString
        If drContract("StateReason").ToString <> Me.txbHOFailureReason.Text Then
            drContract("StateReason") = Me.txbHOFailureReason.Text
            Me.CheckChanges()
        End If
    End Sub

    Private Sub rdbOK_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbOK.CheckedChanged
        If blSkipDeal Then Return

        If Me.rdbOK.Checked Then
            drContract("ContractState") = 4 : drContract("StateReason") = DBNull.Value
            Me.CheckChanges()

            blCanModify = False
            Me.ResetControls()
        End If
    End Sub

    Private Sub rdbFailure_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbFailure.CheckedChanged
        Me.txbFailureReason.Enabled = Me.rdbFailure.Checked
        If blSkipDeal Then Return

        If Me.rdbFailure.Checked Then
            drContract("ContractState") = 3
            drContract("StateReason") = Me.txbFailureReason.Text
            Me.CheckChanges()

            blCanModify = (frmMain.dtAllowedRight.Select("RightName='ContractModify'").Length > 0)
            Me.ResetControls()

            Me.txbFailureReason.Select()
            Me.txbFailureReason.SelectAll()
        End If
    End Sub

    Private Sub txbFailureReason_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbFailureReason.DoubleClick
        If Me.txbFailureReason.ReadOnly = True Then Return
        Me.txbFailureReason.SelectAll()
    End Sub

    Private Sub txbFailureReason_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbFailureReason.Leave
        If Me.txbFailureReason.Text <> Me.txbFailureReason.Text.Trim Then Me.txbFailureReason.Text = Me.txbFailureReason.Text.Trim
        If Me.txbFailureReason.Text = "" Then Me.txbFailureReason.Text = drContract("StateReason").ToString
        If drContract("StateReason").ToString <> Me.txbFailureReason.Text Then
            drContract("StateReason") = Me.txbFailureReason.Text
            Me.CheckChanges()
        End If
    End Sub

    Private Sub chbStop_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbStop.CheckedChanged
        If Me.chbStop.Checked Then
            drContract("ContractState") = 5
            drContract("StateReason") = Me.txbStoppedReason.Text

            Me.txbStoppedReason.Enabled = True
            Me.txbStoppedReason.Select()
            Me.txbStoppedReason.SelectAll()

            Me.btnSave.Enabled = (Me.txbStoppedReason.Text <> "")
        Else
            drContract.RejectChanges()

            Me.txbStoppedReason.Enabled = False
            Me.btnSave.Enabled = False
        End If
    End Sub

    Private Sub txbStoppedReason_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbStoppedReason.DoubleClick
        Me.txbStoppedReason.SelectAll()
    End Sub

    Private Sub txbStoppedReason_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbStoppedReason.Leave
        If Me.txbStoppedReason.Text <> Me.txbStoppedReason.Text.Trim Then Me.txbStoppedReason.Text = Me.txbStoppedReason.Text.Trim
        If Me.txbStoppedReason.Text = "" Then Me.txbStoppedReason.Text = drContract("StateReason").ToString
        If drContract("StateReason").ToString <> Me.txbStoppedReason.Text Then
            drContract("StateReason") = Me.txbStoppedReason.Text
            Me.btnSave.Enabled = True
        End If
    End Sub

    Private Sub flpContainer_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles flpContainer.Scroll
        Me.cklInvoiceItem.Visible = False
    End Sub

    Private Sub grbPartyA_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles grbPartyA.Leave
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub txbACompanyChineseName_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbACompanyChineseName.DoubleClick
        If Me.txbACompanyChineseName.ReadOnly = True Then Return
        Me.txbACompanyChineseName.SelectAll()
    End Sub

    Private Sub txbACompanyChineseName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbACompanyChineseName.Leave, cbbACompanyChineseName.Leave
        Dim ACompanyChineseNameControl As Control = CType(sender, Control)
        If ACompanyChineseNameControl.Text <> ACompanyChineseNameControl.Text.Trim Then ACompanyChineseNameControl.Text = ACompanyChineseNameControl.Text.Trim
        If ACompanyChineseNameControl.Text = "" Then ACompanyChineseNameControl.Text = drContract("ACompanyChineseName").ToString
        If drContract("ACompanyChineseName").ToString <> ACompanyChineseNameControl.Text Then
            Me.txbACompanyChineseName.Text = ACompanyChineseNameControl.Text
            drContract("ACompanyChineseName") = ACompanyChineseNameControl.Text
            If drContract("Beneficiary").ToString = "" Then
                Me.txbBeneficiary.Text = ACompanyChineseNameControl.Text
                drContract("Beneficiary") = ACompanyChineseNameControl.Text
            End If
            Me.CheckChanges()
        End If
    End Sub

    Private Sub cbbACompanyChineseName_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cbbACompanyChineseName.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            bClicks += 1
            sTimerType = "DoubleClick"
            Me.theTimer.Interval = 500
            Me.theTimer.Enabled = True
            If bClicks = 2 Then
                Me.cbbACompanyChineseName.SelectionStart = 0
                Me.cbbACompanyChineseName.SelectionLength = Me.cbbACompanyChineseName.Text.Length
                bClicks = 0
            End If
        End If
    End Sub

    Private Sub cbbACompanyChineseName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbACompanyChineseName.SelectedIndexChanged
        If blSkipDeal OrElse Me.cbbACompanyChineseName.SelectedIndex = -1 Then Return
        drContract("ACompanyChineseName") = Me.cbbACompanyChineseName.Text
        drContract("ACompanyEnglishName") = dtBeneficiary.Rows(Me.cbbACompanyChineseName.SelectedIndex)("ACompanyEnglishName").ToString
        drContract("Beneficiary") = dtBeneficiary.Rows(Me.cbbACompanyChineseName.SelectedIndex)("Beneficiary").ToString
        drContract("BankAccount") = dtBeneficiary.Rows(Me.cbbACompanyChineseName.SelectedIndex)("BankAccount").ToString
        drContract("Domiciliation") = dtBeneficiary.Rows(Me.cbbACompanyChineseName.SelectedIndex)("Domiciliation").ToString
        Me.txbACompanyChineseName.Text = drContract("ACompanyChineseName").ToString
        Me.txbACompanyEnglishName.Text = drContract("ACompanyEnglishName").ToString
        Me.txbBeneficiary.Text = drContract("Beneficiary")
        Me.txbBankAccount.Text = drContract("BankAccount").ToString
        Me.txbDomiciliation.Text = drContract("Domiciliation").ToString
        Me.CheckChanges()
    End Sub

    Private Sub txbACompanyEnglishName_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbACompanyEnglishName.DoubleClick
        If Me.txbACompanyEnglishName.ReadOnly = True Then Return
        Me.txbACompanyEnglishName.SelectAll()
    End Sub

    Private Sub txbACompanyEnglishName_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbACompanyEnglishName.Enter
        If drContract("ACompanyChineseName").ToString = "" Then
            frmMain.statusText.Text = "请先输入甲方公司中文名称。"
            If Me.txbACompanyChineseName.Visible = True Then
                Me.txbACompanyChineseName.Select()
            Else
                Me.cbbACompanyChineseName.Select()
            End If
        Else
            frmMain.statusText.Text = "就绪。"
        End If
    End Sub

    Private Sub txbACompanyEnglishName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbACompanyEnglishName.Leave
        If Me.txbACompanyEnglishName.Text <> Me.txbACompanyEnglishName.Text.Trim Then Me.txbACompanyEnglishName.Text = Me.txbACompanyEnglishName.Text.Trim
        If Me.txbACompanyEnglishName.Text = "" Then Me.txbACompanyEnglishName.Text = drContract("ACompanyEnglishName").ToString
        If drContract("ACompanyEnglishName").ToString <> Me.txbACompanyEnglishName.Text Then
            drContract("ACompanyEnglishName") = Me.txbACompanyEnglishName.Text
            Me.CheckChanges()
        End If
    End Sub

    Private Sub txbBeneficiary_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbBeneficiary.DoubleClick
        If Me.txbBeneficiary.ReadOnly = True Then Return
        Me.txbBeneficiary.SelectAll()
    End Sub

    Private Sub txbBeneficiary_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbBeneficiary.Enter
        If drContract("ACompanyChineseName").ToString = "" Then
            frmMain.statusText.Text = "请先输入甲方公司中文名称。"
            If Me.txbACompanyChineseName.Visible = True Then
                Me.txbACompanyChineseName.Select()
            Else
                Me.cbbACompanyChineseName.Select()
            End If
        Else
            frmMain.statusText.Text = "就绪。"
        End If
    End Sub

    Private Sub txbBeneficiary_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbBeneficiary.Leave
        If Me.txbBeneficiary.Text <> Me.txbBeneficiary.Text.Trim Then Me.txbBeneficiary.Text = Me.txbBeneficiary.Text.Trim
        If Me.txbBeneficiary.Text = "" Then Me.txbBeneficiary.Text = drContract("Beneficiary").ToString
        If drContract("Beneficiary").ToString <> Me.txbBeneficiary.Text Then
            Me.txbBeneficiary.Text = Me.txbBeneficiary.Text
            drContract("Beneficiary") = Me.txbBeneficiary.Text
            Me.CheckChanges()
        End If
    End Sub

    Private Sub txbBankAccount_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbBankAccount.DoubleClick
        If Me.txbBankAccount.ReadOnly = True Then Return
        Me.txbBankAccount.SelectAll()
    End Sub

    Private Sub txbBankAccount_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbBankAccount.Enter
        If drContract("Beneficiary").ToString = "" Then
            frmMain.statusText.Text = "请先输入甲方公司账户名称。"
            Me.txbBeneficiary.Select()
        Else
            frmMain.statusText.Text = "就绪。"
        End If
    End Sub

    Private Sub txbBankAccount_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbBankAccount.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbBankAccount_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbBankAccount.Leave
        If Me.txbBankAccount.Text <> Me.txbBankAccount.Text.Trim Then Me.txbBankAccount.Text = Me.txbBankAccount.Text.Trim
        If Me.txbBankAccount.Text = "" Then Me.txbBankAccount.Text = drContract("BankAccount").ToString
        If drContract("BankAccount").ToString <> Me.txbBankAccount.Text Then
            drContract("BankAccount") = Me.txbBankAccount.Text
            Me.CheckChanges()
        End If
    End Sub

    Private Sub txbDomiciliation_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbDomiciliation.DoubleClick
        If Me.txbDomiciliation.ReadOnly = True Then Return
        Me.txbDomiciliation.SelectAll()
    End Sub

    Private Sub txbDomiciliation_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbDomiciliation.Enter
        If drContract("Beneficiary").ToString = "" Then
            frmMain.statusText.Text = "请先输入甲方公司账户名称。"
            Me.txbBeneficiary.Select()
        Else
            frmMain.statusText.Text = "就绪。"
        End If
    End Sub

    Private Sub txbDomiciliation_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbDomiciliation.Leave
        If Me.txbDomiciliation.Text <> Me.txbDomiciliation.Text.Trim Then Me.txbDomiciliation.Text = Me.txbDomiciliation.Text.Trim
        If Me.txbDomiciliation.Text = "" Then Me.txbDomiciliation.Text = drContract("Domiciliation").ToString
        If drContract("Domiciliation").ToString <> Me.txbDomiciliation.Text Then
            drContract("Domiciliation") = Me.txbDomiciliation.Text
            Me.CheckChanges()
        End If
    End Sub

    Private Sub cbbSignPlace_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbSignPlace.Enter, txbSignPlace.Enter
        If drContract("ACompanyChineseName").ToString = "" Then
            frmMain.statusText.Text = "请先输入甲方公司中文名称。"
            If Me.txbACompanyChineseName.Visible = True Then
                Me.txbACompanyChineseName.Select()
            Else
                Me.cbbACompanyChineseName.Select()
            End If
        Else
            frmMain.statusText.Text = "就绪。"
        End If
    End Sub

    Private Sub cbbSignPlace_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbSignPlace.Leave, txbSignPlace.Leave
        If CType(sender, Control).Name = "txbSignPlace" Then Me.cbbSignPlace.Text = Me.txbSignPlace.Text.Trim
        If Me.cbbSignPlace.Text <> Me.cbbSignPlace.Text.Trim Then Me.cbbSignPlace.Text = Me.cbbSignPlace.Text.Trim
        If Me.cbbSignPlace.Text = "" Then Me.cbbSignPlace.Text = drContract("SignPlace").ToString
        If drContract("SignPlace").ToString <> Me.cbbSignPlace.Text Then
            Me.txbSignPlace.Text = Me.cbbSignPlace.Text
            drContract("SignPlace") = Me.cbbSignPlace.Text
            Me.CheckChanges()
        End If
    End Sub

    Private Sub grbPartyB_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles grbPartyB.Leave
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub txbCustomerName_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbCustomerName.DoubleClick
        Me.txbCustomerName.SelectAll()
    End Sub

    Private Sub txbCustomerName_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbCustomerName.Enter, cbbCustomerName.Enter
        sCustomerName = CType(sender, Control).Text
        If sCustomerPrompt = "存在多个相似客户。请选择其中一个。" Then Me.cbbCustomerName.DroppedDown = True
        If frmMain.statusText.Text <> "您还未添加乙方公司，请先输入客户名称，然后添加到乙方公司列表中。" Then frmMain.statusText.Text = sCustomerPrompt
    End Sub

    Private Sub txbCustomerName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbCustomerName.KeyDown, cbbCustomerName.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txbBNoticeWays.Select() : Me.txbBNoticeWays.SelectAll()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txbCustomerName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbCustomerName.TextChanged, cbbCustomerName.TextChanged
        Me.btnViewCustomer.Enabled = False : Me.btnJoin.Enabled = False
    End Sub

    Private Sub txbCustomerName_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txbCustomerName.Validating, cbbCustomerName.Validating
        Dim controlCustomerName As Control = CType(sender, Control)
        If controlCustomerName.Name.IndexOf("cbb") > -1 AndAlso Me.cbbCustomerName.SelectedValue IsNot Nothing AndAlso sCustomerID = Me.cbbCustomerName.SelectedValue.ToString Then Return
        If sCustomerName = controlCustomerName.Text Then Return
        If controlCustomerName.Text <> controlCustomerName.Text.Trim Then controlCustomerName.Text = controlCustomerName.Text.Trim
        Me.btnViewCustomer.Enabled = False : Me.btnJoin.Enabled = False
        If controlCustomerName.Text = "" Then
            sCustomerID = "" : drCustomer = Nothing
            If Me.txbCustomerName.Visible OrElse Me.cbbCustomerName.Items.Count = 0 Then
                If dtContractCustomer.Rows.Count = 0 Then
                    sCustomerPrompt = "提示：您可以输入客户编号、客户名称中的部分文字或客户名称拼音码来确定客户。"
                Else
                    sCustomerPrompt = "提示：如果还需要添加乙方公司，请继续选择其他客户（通过输入客户编号、客户名称中的部分文字或客户名称拼音码来确定客户）。"
                End If
            Else
                sCustomerPrompt = "存在多个相似客户。请选择其中一个。"
            End If
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正从数据库中检索客户……"
        frmMain.statusMain.Refresh()
        Dim DB As New DataBase
        DB.Open()
        If DB.IsConnected Then
            If dtDropdownCustomer IsNot Nothing Then dtDropdownCustomer.Dispose() : dtDropdownCustomer = Nothing
            dtDropdownCustomer = DB.GetDataTable("Exec GetMatchedCustomerWhenCreateContract " & frmMain.sLoginUserID & ",'" & controlCustomerName.Text.Replace("'", "''") & "'")
            If dtDropdownCustomer Is Nothing Then
                If controlCustomerName.Name.IndexOf("cbb") > -1 Then
                    Me.cbbCustomerName.Visible = False
                    Me.txbCustomerName.Visible = True
                    Me.txbCustomerName.Text = Me.cbbCustomerName.Text
                End If
                sCustomerPrompt = "系统因在检索数据时出错而无法检索客户。请联系软件开发人员。"
                frmMain.statusText.Text = sCustomerPrompt
            Else
                Select Case dtDropdownCustomer.Rows.Count
                    Case 0
                        sCustomerID = ""
                        If controlCustomerName.Name.IndexOf("cbb") > -1 Then
                            Me.cbbCustomerName.Visible = False
                            Me.txbCustomerName.Visible = True
                            Me.txbCustomerName.Text = Me.cbbCustomerName.Text
                        End If
                        If frmMain.dtAllowedRight.Select("RightName='CustomerCreate'").Length > 0 AndAlso ((Me.ActiveControl IsNot Nothing AndAlso Me.ActiveControl.Name = "btnNewCustomer") OrElse MessageBox.Show("找不到该客户，是否现在创建该客户？    ", "是否创建客户？", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                            sTimerType = "CreateCustomer"
                            Me.theTimer.Interval = 50
                            Me.theTimer.Enabled = True
                        Else
                            If frmMain.dtAllowedRight.Select("RightName='CustomerCreate'").Length = 0 Then
                                sCustomerPrompt = "找不到该客户，请输入其他的公司名称。"
                            Else
                                sCustomerPrompt = "找不到该客户，请先创建该客户或输入其他的公司名称。"
                            End If
                            frmMain.statusText.Text = sCustomerPrompt
                            Me.txbCustomerName.Select() : Me.txbCustomerName.SelectAll()
                        End If
                    Case 1
                        sCustomerID = dtDropdownCustomer.Rows(0)("CustomerID").ToString : drCustomer = Nothing
                        If controlCustomerName.Name.IndexOf("cbb") > -1 Then
                            Me.cbbCustomerName.Visible = False
                            Me.txbCustomerName.Visible = True
                            Me.txbCustomerName.Text = Me.cbbCustomerName.Text
                            controlCustomerName = Me.txbCustomerName
                        End If
                        Dim dtCustomer As DataTable = DB.GetDataTable("Exec CustomerSingle " & sCustomerID)
                        If dtCustomer Is Nothing Then
                            sCustomerID = ""
                            sCustomerPrompt = "系统因在检索数据时出错而无法检索客户。请联系软件开发人员。"
                            frmMain.statusText.Text = sCustomerPrompt
                        ElseIf dtCustomer.Rows.Count = 0 Then
                            MessageBox.Show("您选择的客户已经不存在（可能被删除或移位）！    ", "客户不存在！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            If frmCustomerManagement.IsHandleCreated Then
                                Try
                                    frmCustomerManagement.dvCustomer.Table.Rows.Find(sCustomerID).Delete()
                                Catch
                                End Try
                            End If
                            sCustomerID = ""
                            sCustomerPrompt = "您选择的客户已经不存在（可能被删除或移位），请输入其他的公司名称。"
                            frmMain.statusText.Text = sCustomerPrompt
                        Else
                            drCustomer = dtCustomer.Copy.Rows(0)
                            dtCustomer.Dispose() : dtCustomer = Nothing
                            If frmCustomerManagement.IsHandleCreated Then frmCustomerManagement.UpdateCustomer(drCustomer)
                            Me.btnViewCustomer.Enabled = (frmMain.dtAllowedRight.Select("RightName Like 'Customer%' And RightName<>'CustomerCreate'").Length > 0)
                            controlCustomerName.Text = dtDropdownCustomer.Rows(0)("CustomerName").ToString
                            sCustomerName = controlCustomerName.Text

                            If drCustomer("Stopped") Then
                                MessageBox.Show("您选择的客户已被停止使用，再也不能将该客户当作合同的乙方公司！    " & Chr(13) & Chr(13) & "停用客户： " & drCustomer("StoreCode").ToString & drCustomer("CustomerCode").ToString & " " & drCustomer("CustomerChineseName").ToString & Space(4) & IIf(drCustomer("StoppedReason").ToString = "", "", Chr(13) & "停用原因： " & drCustomer("StoppedReason").ToString & Space(4)), "客户已被停止使用！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                If controlCustomerName.Text.IndexOf(" （停止使用）") = -1 Then controlCustomerName.Text = controlCustomerName.Text & " （停止使用）"
                                sCustomerPrompt = "您选择的客户已被停止使用，请输入其他的公司名称。"
                                frmMain.statusText.Text = sCustomerPrompt
                            ElseIf drCustomer("InvalidContractID").ToString <> "" Then
                                MessageBox.Show("您选择的客户存在未生效合同，不能将该客户当作新合同的乙方公司！    " & Chr(13) & Chr(13) & _
                                                "客户名： " & drCustomer("StoreCode").ToString & drCustomer("CustomerCode").ToString & "    " & drCustomer("CustomerChineseName").ToString & Space(4) & Chr(13) & _
                                                "合同号： " & drCustomer("InvalidContractCode").ToString & " （未生效）    " & Chr(13) & _
                                                "合同期： " & drCustomer("InvalidContractPeriod").ToString & Space(4), _
                                                "客户存在未生效合同！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                sCustomerPrompt = "您选择的客户存在未生效合同，请输入其他的公司名称。"
                                frmMain.statusText.Text = sCustomerPrompt
                            ElseIf dtContractCustomer.Select("CustomerID=" & sCustomerID).Length = 1 Then
                                sCustomerPrompt = "此客户已经存在于当前的乙方公司列表中，无须再添加。"
                                frmMain.statusText.Text = sCustomerPrompt
                            ElseIf dtContractCustomer.Rows.Count > 0 AndAlso Me.CheckPeriodOverlap(drCustomer) Then
                                MessageBox.Show("您选择的客户存在与当前合同的合同期重叠且已审核的合同，    " & Chr(13) & Chr(13) & "所以不能将该客户当作新合同的乙方公司！    " & Chr(13) & Chr(13) & _
                                                "客户名： " & drCustomer("StoreCode").ToString & drCustomer("CustomerCode").ToString & "    " & drCustomer("CustomerChineseName").ToString & Space(4) & Chr(13) & _
                                                "合同号： " & drCustomer("LastValidContractCode").ToString & " （已审核）    " & Chr(13) & _
                                                "合同期： " & drCustomer("LastValidContractPeriod").ToString & Space(4), _
                                                "客户存在合同期重叠且已审核的合同！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                sCustomerPrompt = "您选择的客户存在与当前合同的合同期重叠且已审核的合同，请输入其他的公司名称。"
                                frmMain.statusText.Text = sCustomerPrompt
                            ElseIf frmMain.dtLoginStructure.Rows.Find(drCustomer("StoreID").ToString) Is Nothing Then
                                MessageBox.Show("对不起，此客户不在您的管理范围之内！    " & Chr(13) & Chr(13) & _
                                                "因此，您无法为该客户创建合同！    " & Chr(13) & Chr(13) & _
                                                "请找有权限管理该客户的其他人员建立合同。    ", _
                                                "客户不在管理范围之内！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                sCustomerPrompt = "此客户不在您的管理范围之内！"
                                frmMain.statusText.Text = sCustomerPrompt
                            Else
                                Me.btnJoin.Enabled = True

                                sCustomerPrompt = "提示：请按右边的""Join""按钮将此客户添加到乙方公司列表中。"
                                frmMain.statusText.Text = sCustomerPrompt
                            End If
                        End If
                    Case Else
                        sCustomerName = controlCustomerName.Text
                        If controlCustomerName.Name.IndexOf("txb") > -1 Then Me.cbbCustomerName.Text = Me.txbCustomerName.Text : Me.cbbCustomerName.Visible = True : Me.txbCustomerName.Visible = False
                        blSkipDeal = True
                        With Me.cbbCustomerName
                            .DataSource = dtDropdownCustomer
                            .ValueMember = "CustomerID"
                            .DisplayMember = "CustomerName"
                            .Visible = True
                        End With
                        Me.cbbCustomerName.Text = sCustomerName
                        blSkipDeal = False
                        sCustomerID = ""
                        sCustomerPrompt = "存在多个相似客户。请选择其中一个。"
                        frmMain.statusText.Text = sCustomerPrompt
                        sTimerType = "MultiCustomer"
                        Me.theTimer.Interval = 50
                        Me.theTimer.Enabled = True
                End Select
            End If

            DB.Close()
        Else
            frmMain.statusText.Text = "系统因连接不到数据库而无法检索客户。请检查数据库连接。"
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cbbCustomerName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbCustomerName.Leave, txbCustomerName.Leave
        If frmMain.statusText.Text <> "您还未添加乙方公司，请先输入客户名称，然后添加到乙方公司列表中。" Then frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub cbbCustomerName_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cbbCustomerName.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            bClicks += 1
            sTimerType = "DoubleClick"
            Me.theTimer.Interval = 500
            Me.theTimer.Enabled = True
            If bClicks = 2 Then
                Me.cbbCustomerName.SelectionStart = 0
                Me.cbbCustomerName.SelectionLength = Me.cbbCustomerName.Text.Length
                bClicks = 0
            End If
        End If
    End Sub

    Private Sub cbbCustomerName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbCustomerName.SelectedIndexChanged
        If blSkipDeal OrElse Me.cbbCustomerName.SelectedValue Is Nothing Then Return
        If sCustomerID = Me.cbbCustomerName.SelectedValue.ToString Then Return
        sCustomerID = Me.cbbCustomerName.SelectedValue.ToString : drCustomer = Nothing
        sCustomerName = Me.cbbCustomerName.Text
        Me.txbCustomerName.Text = Me.cbbCustomerName.Text

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在下载客户资料……"
        frmMain.statusMain.Refresh()
        Dim DB As New DataBase, dtCustomer As DataTable
        DB.Open()
        If DB.IsConnected Then
            dtCustomer = DB.GetDataTable("Exec CustomerSingle " & sCustomerID)
            If dtCustomer Is Nothing Then
                sCustomerID = ""
                sCustomerPrompt = "提示：您可以输入客户编号、客户名称中的部分文字或客户名称拼音码来确定客户。"
                frmMain.statusText.Text = sCustomerPrompt
            ElseIf dtCustomer.Rows.Count = 0 Then
                MessageBox.Show("您选择的客户已经不存在（可能被删除或移位）！    ", "客户不存在！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                If frmCustomerManagement.IsHandleCreated Then
                    Try
                        frmCustomerManagement.dvCustomer.Table.Rows.Find(sCustomerID).Delete()
                    Catch
                    End Try
                End If
                sCustomerID = ""
                sCustomerPrompt = "您选择的客户已经不存在（可能被删除或移位），请输入其他的公司名称。"
                frmMain.statusText.Text = sCustomerPrompt
            Else
                drCustomer = dtCustomer.Copy.Rows(0)
                dtCustomer.Dispose() : dtCustomer = Nothing
                If frmCustomerManagement.IsHandleCreated Then frmCustomerManagement.UpdateCustomer(drCustomer)
                Me.btnViewCustomer.Enabled = (frmMain.dtAllowedRight.Select("RightName Like 'Customer%' And RightName<>'CustomerCreate'").Length > 0)

                If drCustomer("Stopped") Then
                    MessageBox.Show("您选择的客户已被停止使用，再也不能将该客户当作合同的乙方公司！    " & Chr(13) & Chr(13) & "停用客户： " & drCustomer("StoreCode").ToString & drCustomer("CustomerCode").ToString & " " & drCustomer("CustomerChineseName").ToString & Space(4) & IIf(drCustomer("StoppedReason").ToString = "", "", Chr(13) & "停用原因： " & drCustomer("StoppedReason").ToString & Space(4)), "客户已被停止使用！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    sCustomerPrompt = "您选择的客户已被停止使用，请输入其他的公司名称。"
                    frmMain.statusText.Text = sCustomerPrompt
                ElseIf drCustomer("InvalidContractID").ToString <> "" Then
                    MessageBox.Show("您选择的客户存在未生效合同，不能将该客户当作新合同的乙方公司！    " & Chr(13) & Chr(13) & _
                                    "客户名： " & drCustomer("StoreCode").ToString & drCustomer("CustomerCode").ToString & "    " & drCustomer("CustomerChineseName").ToString & Space(4) & Chr(13) & _
                                    "合同号： " & drCustomer("InvalidContractCode").ToString & " （未生效）    " & Chr(13) & _
                                    "合同期： " & drCustomer("InvalidContractPeriod").ToString & Space(4), _
                                    "客户存在未生效合同！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    sCustomerPrompt = "您选择的客户存在未生效合同，请输入其他的公司名称。"
                    frmMain.statusText.Text = sCustomerPrompt
                ElseIf dtContractCustomer.Select("CustomerID=" & sCustomerID).Length = 1 Then
                    sCustomerPrompt = "此客户已经存在于当前的乙方公司列表中，无须再添加。"
                    frmMain.statusText.Text = sCustomerPrompt
                ElseIf dtContractCustomer.Rows.Count > 0 AndAlso Me.CheckPeriodOverlap(drCustomer) Then
                    MessageBox.Show("您选择的客户存在与当前合同的合同期重叠且已审核的合同，    " & Chr(13) & Chr(13) & "所以不能将该客户当作新合同的乙方公司！    " & Chr(13) & Chr(13) & _
                                    "客户名： " & drCustomer("StoreCode").ToString & drCustomer("CustomerCode").ToString & "    " & drCustomer("CustomerChineseName").ToString & Space(4) & Chr(13) & _
                                    "合同号： " & drCustomer("LastValidContractCode").ToString & " （已审核）    " & Chr(13) & _
                                    "合同期： " & drCustomer("LastValidContractPeriod").ToString & Space(4), _
                                    "客户存在合同期重叠且已审核的合同！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    sCustomerPrompt = "您选择的客户存在与当前合同的合同期重叠且已审核的合同，请输入其他的公司名称。"
                    frmMain.statusText.Text = sCustomerPrompt

                Else
                    Me.btnJoin.Enabled = True

                    sCustomerPrompt = "提示：请按右边的""Join""按钮将此客户添加到乙方公司列表中。"
                    frmMain.statusText.Text = sCustomerPrompt
                End If
            End If
            DB.Close()
        Else
            sCustomerPrompt = "系统因连接不到数据库而无法下载客户资料。请检查数据库连接。"
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnNewCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewCustomer.Click
        If frmMain.dtAllowedRight.Select("RightName='CustomerCreate'").Length = 0 Then
            MessageBox.Show("对不起，您无权限创建新客户。    " & Chr(13) & _
                            "Sorry, you have no right to create new Customer.    ", "无权限创建客户 No right to create Customer!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.btnNewCustomer.Enabled = False : Return
        End If

        If frmCustomer.IsHandleCreated Then Return '避免重复打开
        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在打开客户窗口……"
        frmMain.statusMain.Refresh()

        If sCustomerID = "" Then
            If Me.txbCustomerName.Visible Then
                frmCustomer.sCustomerNameFromOthers = Me.txbCustomerName.Text.Trim
            Else
                frmCustomer.sCustomerNameFromOthers = Me.cbbCustomerName.Text.Trim
            End If
        End If
        If frmCustomer.sCustomerNameFromOthers = "" Then frmCustomer.sCustomerNameFromOthers = " "

        frmCustomer.ShowDialog()
        If frmCustomer.sCustomerID = "-1" Then
            If sCustomerName = "" Then
                sCustomerPrompt = "您还未选择乙方公司名称！请先输入乙方公司名称。"
                frmMain.statusText.Text = sCustomerPrompt
            ElseIf sCustomerID = "" Then
                sCustomerPrompt = "找不到该客户，请先创建该客户或" & IIf(Me.txbCustomerName.Visible = True, "输入", "选择") & "其他的公司名称。"
                frmMain.statusText.Text = sCustomerPrompt
            End If
            If Me.txbCustomerName.Visible = True Then
                Me.txbCustomerName.Focus() : Me.txbCustomerName.Select() : Me.txbCustomerName.SelectAll()
            Else
                Me.cbbCustomerName.Focus() : Me.cbbCustomerName.Select() : Me.cbbCustomerName.SelectAll()
            End If
        Else
            drCustomer = frmCustomer.drCustomer.Table.Copy.Rows(0)
            sCustomerID = drCustomer("CustomerID").ToString
            sCustomerName = drCustomer("CustomerChineseName").ToString & IIf(drCustomer("Stopped"), " （已停止使用）", "")

            blSkipDeal = True
            Me.txbCustomerName.Visible = True : Me.cbbCustomerName.Visible = False
            Me.txbCustomerName.Text = sCustomerName
            If drCustomer("Stopped") Then
                MessageBox.Show("您选择的客户已被停止使用，再也不能将该客户当作合同的乙方公司！    " & Chr(13) & Chr(13) & "停用客户： " & drCustomer("StoreCode").ToString & drCustomer("CustomerCode").ToString & " " & drCustomer("CustomerChineseName").ToString & Space(4) & IIf(drCustomer("StoppedReason").ToString = "", "", Chr(13) & "停用原因： " & drCustomer("StoppedReason").ToString & Space(4)), "客户已被停止使用！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                sCustomerPrompt = "您选择的客户已被停止使用，请选择其他客户。"
                frmMain.statusText.Text = sCustomerPrompt
            Else
                Me.btnViewCustomer.Enabled = True : Me.btnJoin.Enabled = True
                sTimerType = "AfterCreatedCustomer"
                Me.theTimer.Interval = 50
                Me.theTimer.Enabled = True
            End If
            blSkipDeal = False
        End If

        frmCustomer.Dispose()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnViewCustomer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnViewCustomer.Click
        If frmMain.dtAllowedRight.Select("RightName Like 'Customer%' And RightName<>'CustomerCreate'").Length = 0 Then
            MessageBox.Show("对不起！您没有浏览客户的权限。    " & Chr(13) & "Sorry, you have no right to browse customer.    ", "您无权浏览客户 No right to browse customer!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.btnViewCustomer.Enabled = False
        End If

        If Me.btnViewCustomer.Enabled = False Then
            If Me.txbCustomerName.Visible Then
                Me.txbCustomerName.Select()
                Me.txbCustomerName.SelectAll()
            Else
                Me.cbbCustomerName.Select()
                Me.cbbCustomerName.SelectAll()
            End If
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在打开客户""" & drCustomer("StoreCode").ToString & drCustomer("CustomerCode").ToString & " " & drCustomer("CustomerChineseName").ToString & """……"
        frmMain.statusMain.Refresh()

        frmCustomer.drCustomer = drCustomer.Table.Copy.Rows(0)
        frmCustomer.sCustomerID = sCustomerID
        frmCustomer.ShowDialog()
        If frmCustomer.drCustomer IsNot Nothing Then drCustomer = frmCustomer.drCustomer.Table.Copy.Rows(0)
        If frmCustomer.blAlreadyChanged Then Me.AfterOpenCustomer(frmCustomer.sCustomerID, drCustomer)
        frmCustomer.Dispose()
        If Me.txbCustomerName.Visible Then
            Me.txbCustomerName.Select()
            Me.txbCustomerName.SelectAll()
        Else
            Me.cbbCustomerName.Select()
            Me.cbbCustomerName.SelectAll()
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnJoin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJoin.Click
        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在将此客户添加到乙方公司列表中……"
        frmMain.statusMain.Refresh()
        Dim sNewCityID = drCustomer("CityID").ToString
        If frmMain.dtAllowedRight.Select("RightName='CityConfigBrowse'").Length > 0 AndAlso sCityID <> sNewCityID AndAlso dvNewestCityRule.Table.Select("CityID=" & sNewCityID).Length = 0 Then
            Dim DB As New DataBase
            DB.Open()
            If DB.IsConnected Then
                Try
                    dvNewestCityRule.Table.Merge(DB.GetDataTable("Select * From CityRule Where CityID=" & sNewCityID & " And RuleState=2"))
                    dvNewestCityRule.RowFilter = "CityID=" & sNewCityID
                    If dvNewestCityRule.Count > 0 Then
                        dvNewestRuleDetails.Table.Merge(DB.GetDataTable("Select * From CityRuleDetails Where RuleID=" & dvNewestCityRule(0)("RuleID").ToString))
                    End If
                Catch
                    frmMain.statusText.Text = "系统因在检索城市返点规则时出错而无法添加客户到乙方公司列表中。请联系软件开发人员。"
                    DB.Close() : Me.Cursor = Cursors.Default : Return
                End Try
            Else
                frmMain.statusText.Text = "系统因连接不到数据库而无法检索城市返点规则。请检查数据库连接。"
                DB.Close() : Me.Cursor = Cursors.Default : Return
            End If
        End If

        blSkipDeal = True
        Dim joinedCustomer As DataRow = dtContractCustomer.Rows.Add(), displayedCustomer As DataRow = dtDisplayedCustomer.Rows.Add(sCustomerID), sStoreID As String = drCustomer("StoreID").ToString
        joinedCustomer("CustomerID") = sCustomerID
        joinedCustomer("RowID") = dtContractCustomer.Rows.Count
        joinedCustomer("CityID") = drCustomer("CityID")
        joinedCustomer("StoreID") = sStoreID
        joinedCustomer("BusinessTypeID") = drCustomer("BusinessTypeID")
        joinedCustomer("CustomerCode") = drCustomer("StoreCode").ToString & drCustomer("CustomerCode").ToString
        joinedCustomer("CustomerChineseName") = drCustomer("CustomerChineseName").ToString
        joinedCustomer("CustomerEnglishName") = drCustomer("CustomerEnglishName").ToString
        joinedCustomer("Stopped") = 0
        joinedCustomer("InvoiceTitleCustomerID") = sCustomerID
        If drCustomer("LastValidContractID").ToString = "" Then
            joinedCustomer("LastValidContractID") = -1
        Else
            joinedCustomer("LastValidContractID") = drCustomer("LastValidContractID")
            joinedCustomer("LastValidContractCode") = drCustomer("LastValidContractCode").ToString
            joinedCustomer("LastValidContractStartDate") = drCustomer("LastValidContractStartDate")
            joinedCustomer("LastValidContractEndDate") = drCustomer("LastValidContractEndDate")
        End If
        joinedCustomer.EndEdit()

        displayedCustomer("RowID") = joinedCustomer("RowID")
        displayedCustomer("CustomerCode") = joinedCustomer("CustomerCode").ToString
        If joinedCustomer("CustomerChineseName").ToString <> "" AndAlso joinedCustomer("CustomerEnglishName").ToString <> "" Then
            displayedCustomer("CustomerName") = joinedCustomer("CustomerChineseName").ToString & Chr(13) & joinedCustomer("CustomerEnglishName").ToString
            displayedCustomer("IsBoth") = 1
        Else
            displayedCustomer("CustomerName") = joinedCustomer("CustomerChineseName").ToString & joinedCustomer("CustomerEnglishName").ToString
            displayedCustomer("IsBoth") = 0
        End If
        If joinedCustomer("RowID") = 1 Then displayedCustomer("IsMain") = " (Main Company) "
        displayedCustomer("Delete") = "Delete"
        displayedCustomer.EndEdit() : displayedCustomer.AcceptChanges()
        Me.ResetCustomerLayout()

        If dtStore.Select("StoreID=" & sStoreID).Length = 0 Then
            dtStore.Rows.Add(sStoreID, frmMain.dtLoginStructure.Rows.Find(sStoreID)("AreaFullName").ToString).AcceptChanges()
        End If

        Me.cklInvoiceTitle.Items.Add(drCustomer("CustomerChineseName").ToString, True)
        Me.ResetInvoiceLayout()

        If joinedCustomer("RowID") = 1 Then
            drContract("MainCustomerID") = sCustomerID : drContract("MainCustomerName") = (drCustomer("CustomerChineseName").ToString & " " & drCustomer("CustomerEnglishName").ToString).Trim
            Me.txbCustomerCode.Text = drCustomer("StoreCode").ToString & drCustomer("CustomerCode").ToString
            Me.ResetContractPeriod(joinedCustomer)
        End If

        If sCityID <> sNewCityID Then
            sCityID = sNewCityID : sValidationDescription = ""
            If joinedCustomer("RowID") = 1 Then Me.ResetSignPlace()
        End If
        Me.ResetInvoiceItems()

        Me.dgvCustomer.Select()
        If Me.txbCustomerName.Visible = True Then
            Me.txbCustomerName.Select() : Me.txbCustomerName.SelectAll()
        Else
            Me.cbbCustomerName.Select() : Me.cbbCustomerName.SelectAll()
        End If
        Me.btnJoin.Enabled = False
        Me.btnCompare.Enabled = (frmMain.dtAllowedRight.Select("RightName='CityConfigBrowse'").Length > 0)
        Me.CheckChanges()

        sCustomerPrompt = "提示：如果还需要添加乙方公司，请继续选择其他客户（通过输入客户编号、客户名称中的部分文字或客户名称拼音码来确定客户）。"
        frmMain.statusText.Text = sCustomerPrompt
        blSkipDeal = False
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgvCustomer_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCustomer.CellContentClick
        If e.RowIndex = -1 Then Return
        If Me.dgvCustomer.Columns(e.ColumnIndex).Name = "CustomerCode" Then
            If frmMain.dtAllowedRight.Select("RightName Like 'Customer%' And RightName<>'CustomerCreate'").Length = 0 Then
                frmMain.statusText.Text = "对不起！您没有浏览销售单的权限。"
            ElseIf Me.dgvCustomer("Error", Me.dgvCustomer.CurrentRow.Index).ToolTipText.IndexOf("不存在") = -1 Then
                Me.Cursor = Cursors.WaitCursor
                Dim openingCustomerID As String = Me.dgvCustomer("CustomerID", Me.dgvCustomer.CurrentRow.Index).Value.ToString, openingCustomer As DataRow = dtContractCustomer.Select("CustomerID=" & openingCustomerID)(0)
                frmMain.statusText.Text = "正在打开客户""" & openingCustomer("CustomerCode").ToString & " " & openingCustomer("CustomerChineseName").ToString & """……"
                frmMain.statusMain.Refresh()

                If drCustomer IsNot Nothing AndAlso openingCustomerID = sCustomerID Then
                    frmCustomer.drCustomer = drCustomer.Table.Copy.Rows(0)
                ElseIf drSelectedCustomer IsNot Nothing AndAlso openingCustomerID = drSelectedCustomer("CustomerID").ToString Then
                    frmCustomer.drCustomer = drSelectedCustomer.Table.Copy.Rows(0)
                End If
                frmCustomer.sCustomerID = openingCustomerID
                frmCustomer.ShowDialog()
                If frmCustomer.drCustomer IsNot Nothing Then drSelectedCustomer = frmCustomer.drCustomer.Table.Copy.Rows(0)
                If frmCustomer.blAlreadyChanged Then Me.AfterOpenCustomer(frmCustomer.sCustomerID, drSelectedCustomer)
                openingCustomer = Nothing
                frmCustomer.Dispose()
                Me.dgvCustomer.Select()
                Me.Cursor = Cursors.Default
            End If
        ElseIf Me.dgvCustomer.Columns(e.ColumnIndex).Name = "Delete" Then
            Dim sSelectedCustomerID As String = Me.dgvCustomer("CustomerID", Me.dgvCustomer.CurrentRow.Index).Value.ToString, joinedCustomer As DataRow = dtContractCustomer.Select("CustomerID=" & sSelectedCustomerID)(0), displayedCustomer As DataRow = dtDisplayedCustomer.Select("CustomerID=" & sSelectedCustomerID)(0)
            If joinedCustomer("RowID") = 1 Then
                If Me.dgvCustomer.RowCount = 1 Then
                    Me.txbCustomerCode.Text = ""
                    drContract("MainCustomerID") = DBNull.Value : drContract("MainCustomerName") = DBNull.Value
                    If sCityName = "" Then
                        sCityID = ""
                        Me.txbSignPlace.Visible = True
                        Me.cbbSignPlace.Visible = False
                    End If
                Else
                    Dim nextCustomer As DataRow = dtContractCustomer.Select("RowID=2")(0)
                    Me.txbCustomerCode.Text = nextCustomer("CustomerCode").ToString
                    drContract("MainCustomerID") = nextCustomer("CustomerID") : drContract("MainCustomerName") = (nextCustomer("CustomerChineseName").ToString & " " & nextCustomer("CustomerEnglishName").ToString).Trim
                    sCityID = nextCustomer("CityID").ToString : Me.ResetSignPlace()
                    dtDisplayedCustomer.Select("RowID=2")(0)("IsMain") = " (Main Company) "
                End If
            End If

            If sCustomerID = sSelectedCustomerID AndAlso displayedCustomer("Error").ToString = "" Then Me.btnJoin.Enabled = True
            displayedCustomer.Delete() : displayedCustomer.AcceptChanges()
            Dim iRowID As Int16 = 1
            For Each displayedCustomer In dtDisplayedCustomer.Select("", "RowID")
                displayedCustomer("RowID") = iRowID
                iRowID += 1
            Next
            Me.ResetCustomerLayout()

            Me.cklInvoiceTitle.Items.RemoveAt(joinedCustomer("RowID") - 1)

            Dim sStoreID As String = joinedCustomer("StoreID").ToString
            If dtContractCustomer.Select("StoreID=" & sStoreID).Length = 1 Then
                blSkipDeal = True
                dtStore.Select("StoreID=" & sStoreID)(0).Delete()
                dtStore.AcceptChanges()
                blSkipDeal = False
                If dtStore.Rows.Count = 0 Then Me.rdbAllStores.Checked = True
            End If

            joinedCustomer.Delete()
            iRowID = 1
            For Each joinedCustomer In dtContractCustomer.Select("", "RowID")
                joinedCustomer("RowID") = iRowID
                iRowID += 1
            Next

            Me.btnCompare.Enabled = (dtDisplayedCustomer.Rows.Count > 0 AndAlso frmMain.dtAllowedRight.Select("RightName='CityConfigBrowse'").Length > 0)

            Me.ResetInvoiceItems()
            Me.ResetInvoiceLayout()
            Me.CheckChanges()

            Me.dgvCustomer.Select()
            If Me.dgvCustomer.RowCount = 0 Then
                If Me.btnJoin.Enabled Then
                    sCustomerPrompt = "提示：请按右边的""Join""按钮将此客户添加到乙方公司列表中。"
                Else
                    sCustomerPrompt = "提示：您可以输入客户编号、客户名称中的部分文字或客户名称拼音码来确定客户。"
                End If
                If Me.txbCustomerName.Visible Then
                    Me.txbCustomerName.Select() : Me.txbCustomerName.SelectAll()
                Else
                    Me.cbbCustomerName.Select() : Me.cbbCustomerName.SelectAll()
                End If
            End If
        End If
    End Sub

    Private Sub dgvCustomer_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvCustomer.CellFormatting
        If Me.dgvCustomer.Columns(e.ColumnIndex).GetType.Name = "DataGridViewLinkColumn" Then
            If Me.dgvCustomer.CurrentRow IsNot Nothing AndAlso Me.dgvCustomer.CurrentRow.Index = e.RowIndex AndAlso Me.dgvCustomer.CurrentRow.Selected Then
                CType(Me.dgvCustomer(e.ColumnIndex, e.RowIndex), DataGridViewLinkCell).LinkColor = Color.Yellow
            Else
                CType(Me.dgvCustomer(e.ColumnIndex, e.RowIndex), DataGridViewLinkCell).LinkColor = Color.Blue
            End If
        End If
        If sContractID <> "-1" Then
            e.CellStyle.BackColor = SystemColors.Control
        End If
    End Sub

    Private Sub dgvCustomer_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCustomer.Enter
        If Me.dgvCustomer.RowCount = 0 Then
            If Me.txbCustomerName.Visible Then
                Me.txbCustomerName.Select() : Me.txbCustomerName.SelectAll()
            Else
                Me.cbbCustomerName.Select() : Me.cbbCustomerName.SelectAll()
            End If
            frmMain.statusText.Text = "您还未添加乙方公司，请先输入客户名称，然后添加到乙方公司列表中。"
        End If
    End Sub

    Private Sub dgvCustomer_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCustomer.Leave
        If sContractID = "-1" Then
            Dim clickedControl As Control = Me.tlpSetMainCompany.GetChildAtPoint(Me.tlpSetMainCompany.PointToClient(Control.MousePosition))
            If clickedControl IsNot Nothing AndAlso clickedControl.Name = "btnSetMainCompany" Then Return
        End If

        If Me.dgvCustomer.CurrentCell IsNot Nothing Then Me.dgvCustomer.CurrentCell.Selected = False
        If Me.dgvCustomer.CurrentRow IsNot Nothing Then Me.dgvCustomer.CurrentRow.Selected = False
        Me.tlpSetMainCompany.Visible = False
    End Sub

    Private Sub dgvCustomer_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCustomer.SelectionChanged
        If sContractID = "-1" AndAlso Me.dgvCustomer.RowCount > 1 Then
            Me.tlpSetMainCompany.Visible = True
            Me.btnSetMainCompany.Enabled = (Me.dgvCustomer("IsMain", Me.dgvCustomer.CurrentRow.Index).Value.ToString = "" AndAlso Me.dgvCustomer("Error", Me.dgvCustomer.CurrentRow.Index).Value.ToString = "")
        End If
    End Sub

    Private Sub btnSetMainCompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetMainCompany.Click
        Dim sSelectedCustomerID As String = Me.dgvCustomer("CustomerID", Me.dgvCustomer.CurrentRow.Index).Value.ToString, joinedCustomer As DataRow = dtContractCustomer.Select("CustomerID=" & sSelectedCustomerID)(0), displayedCustomer As DataRow = dtDisplayedCustomer.Select("CustomerID=" & sSelectedCustomerID)(0)
        Me.txbCustomerCode.Text = joinedCustomer("CustomerCode").ToString
        Me.cklInvoiceTitle.Items.RemoveAt(displayedCustomer("RowID") - 1)
        Me.cklInvoiceTitle.Items.Insert(0, joinedCustomer("CustomerChineseName").ToString)
        Me.cklInvoiceTitle.SetItemChecked(0, True)

        Me.dgvCustomer("IsMain", 0).Value = DBNull.Value
        drContract("MainCustomerID") = joinedCustomer("CustomerID") : drContract("MainCustomerName") = (joinedCustomer("CustomerChineseName").ToString & " " & joinedCustomer("CustomerEnglishName").ToString).Trim
        sCityID = joinedCustomer("CityID").ToString : Me.ResetSignPlace()
        For Each dr As DataRow In dtContractCustomer.Select("CustomerID<>InvoiceTitleCustomerID")
            dr("InvoiceTitleCustomerID") = sSelectedCustomerID
        Next

        joinedCustomer("RowID") = 0 : displayedCustomer("RowID") = 0
        displayedCustomer("IsMain") = " (Main Company) "
        Dim iRowID As Int16 = 2
        For Each dr As DataRow In dtContractCustomer.Select("RowID<>0", "RowID")
            dr("RowID") = iRowID
            iRowID += 1
        Next
        iRowID = 2
        For Each dr In dtDisplayedCustomer.Select("RowID<>0", "RowID")
            dr("RowID") = iRowID
            iRowID += 1
        Next
        joinedCustomer("RowID") = 1 : displayedCustomer("RowID") = 1
        dtDisplayedCustomer.AcceptChanges()
        Me.ResetCustomerLayout()

        Dim sStoreID As String = joinedCustomer("StoreID").ToString, sSelectedStoreID As String = Me.cbbAppointedStore.SelectedValue.ToString
        If sStoreID <> dtStore.Rows(0)("StoreID").ToString Then
            blSkipDeal = True
            Dim drStore As DataRow = dtStore.Select("StoreID=" & sStoreID)(0)
            drStore.Delete() : drStore.AcceptChanges()
            drStore = dtStore.NewRow()
            drStore("StoreID") = sStoreID
            drStore("StoreFullName") = frmMain.dtLoginStructure.Rows.Find(sStoreID)("AreaFullName").ToString
            dtStore.Rows.InsertAt(drStore, 0)
            dtStore.AcceptChanges()
            Me.cbbAppointedStore.SelectedValue = sSelectedStoreID
            blSkipDeal = False
        End If
        Me.CheckChanges()

        Me.dgvCustomer.Select()
        Me.dgvCustomer("CustomerCode", 0).Selected = True : Me.dgvCustomer.Rows(0).Selected = True
    End Sub

    Private Sub txbBNoticeWays_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbBNoticeWays.DoubleClick
        If Me.txbBNoticeWays.ReadOnly = True Then Return
        Me.txbBNoticeWays.SelectAll()
    End Sub

    Private Sub txbBNoticeWays_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbBNoticeWays.Enter
        If Me.dgvCustomer.RowCount = 0 Then
            If Me.txbCustomerName.Visible Then
                Me.txbCustomerName.Select() : Me.txbCustomerName.SelectAll()
            Else
                Me.cbbCustomerName.Select() : Me.cbbCustomerName.SelectAll()
            End If
            frmMain.statusText.Text = "您还未添加乙方公司，请先输入客户名称，然后添加到乙方公司列表中。"
        End If
    End Sub

    Private Sub txbBNoticeWays_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbBNoticeWays.Leave
        If Me.txbBNoticeWays.Text <> Me.txbBNoticeWays.Text.Trim Then Me.txbBNoticeWays.Text = Me.txbBNoticeWays.Text.Trim
        If Me.txbBNoticeWays.Text = "" Then Me.txbBNoticeWays.Text = drContract("BNoticeWays").ToString
        If drContract("BNoticeWays").ToString <> Me.txbBNoticeWays.Text Then
            drContract("BNoticeWays") = Me.txbBNoticeWays.Text
            Me.CheckChanges()
        End If
    End Sub

    Private Sub dtpStartDate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpStartDate.Leave
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub dtpStartDate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpStartDate.Validating
        If Me.dtpStartDate.Value = drContract("StartDate") Then Return
        Dim dtDate As Date = Me.dtpStartDate.Value, sLastDate As String = "", lastContract As DataRow = Nothing, sPossibleDate As String = "", blIsOverLast As Boolean = True
        Try
            sLastDate = Format(CDate(dtContractCustomer.Compute("Max(LastValidContractEndDate)", "")), "yyyy\/MM\/dd")
            lastContract = dtContractCustomer.Select("LastValidContractEndDate='" & sLastDate & "'")(0)
            sPossibleDate = Format(DateAdd(DateInterval.Day, 1, CDate(sLastDate)), "yyyy\/MM\/dd")
        Catch
        End Try
        If sPossibleDate < Format(DateAdd(DateInterval.Day, -7, dtToday), "yyyy\/MM\/dd") Then
            sPossibleDate = Format(DateAdd(DateInterval.Day, -7, dtToday), "yyyy\/MM\/dd")
            blIsOverLast = False
        End If

        If dtDate < CDate(sPossibleDate) Then
            If blIsOverLast Then
                MessageBox.Show("本次合同开始日期不应早于上次合同结束日期！    " & Chr(13) & Chr(13) & _
                                "        上次合同编号： " & lastContract("LastValidContractCode").ToString & Space(4) & Chr(13) & Chr(13) & _
                                "    上次合同结束日期： " & sLastDate & Space(4) & Chr(13) & Chr(13) & _
                                "本次可能最早开始日期： " & sPossibleDate & Space(4) & Chr(13) & Chr(13) & _
                                "系统将自动设置本次合同的开始日期为""" & sPossibleDate & """（可能的最早日期）。    ", "合同开始日期无效！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("系统规定：合同开始日期距离今天最多只能提前一周！    " & Chr(13) & Chr(13) & _
                               "可能最早开始日期： " & sPossibleDate & Space(4) & Chr(13) & Chr(13) & _
                               "系统将自动设置本次合同的开始日期为""" & sPossibleDate & """（可能的最早日期）。    ", "合同开始日期无效！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            Me.dtpStartDate.MinDate = CDate(sPossibleDate)
            e.Cancel = True : Return
        End If

        If dtDate > drContract("EndDate") Then
            sPossibleDate = Format(DateAdd(DateInterval.Day, DateDiff(DateInterval.Day, drContract("StartDate"), drContract("EndDate")), dtDate), "yyyy\/MM\/dd")
            Select Case MessageBox.Show("合同开始日期不应晚于合同结束日期！    " & Chr(13) & Chr(13) & _
                                        "是否想顺延结束日期至： " & sPossibleDate & "？    ", "合同开始日期无效！", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop)
                Case DialogResult.Yes
                    Me.dtpAppointedDate.MinDate = "1753-1-1" : Me.dtpAppointedDate.Value = DateAdd(DateInterval.Day, DateDiff(DateInterval.Day, drContract("EndDate"), CDate(sPossibleDate)), drContract("AppointedDate"))
                    Me.dtpEndDate.MinDate = "1753-1-1" : Me.dtpEndDate.MaxDate = "9998-12-31" : Me.dtpEndDate.Value = CDate(sPossibleDate)
                    drContract("EndDate") = CDate(sPossibleDate)
                    drContract("AppointedDate") = Me.dtpAppointedDate.Value
                Case DialogResult.Cancel
                    Me.dtpStartDate.Value = drContract("StartDate")
            End Select
            e.Cancel = True : Return
        End If

        If sContractID = "-1" AndAlso DateDiff(DateInterval.Day, dtDate, drContract("EndDate")) < 15 Then
            sPossibleDate = Format(DateAdd(DateInterval.Day, DateDiff(DateInterval.Day, drContract("StartDate"), drContract("EndDate")), dtDate), "yyyy\/MM\/dd")
            Select Case MessageBox.Show("系统规定：新合同的合同期不得少于半个月！    " & Chr(13) & Chr(13) & _
                                        "是否想顺延结束日期至： " & sPossibleDate & "？    ", "合同开始日期无效！", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop)
                Case DialogResult.Yes
                    Me.dtpEndDate.MinDate = "1753-1-1" : Me.dtpEndDate.MaxDate = "9998-12-31"
                    Me.dtpEndDate.Value = CDate(sPossibleDate)
                    drContract("EndDate") = CDate(sPossibleDate)
                Case DialogResult.Cancel
                    Me.dtpStartDate.Value = drContract("StartDate")
            End Select
            e.Cancel = True : Return
        End If

        If DateDiff(DateInterval.Day, dtDate, drContract("EndDate")) > 366 Then
            sPossibleDate = Format(DateAdd(DateInterval.Day, 366, dtDate), "yyyy\/MM\/dd")
            MessageBox.Show("系统规定：合同期不得超过一年！    " & Chr(13) & Chr(13) & _
                            "可能最晚结束日期： " & sPossibleDate & Space(4) & Chr(13) & Chr(13) & _
                            "系统将自动设置本次合同的结束日期为""" & sPossibleDate & """（可能的最晚日期）。    ", "合同结束日期已被自动修改！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.dtpEndDate.MaxDate = CDate(sPossibleDate)
            drContract("EndDate") = CDate(sPossibleDate)
        Else
            Me.dtpEndDate.MaxDate = "9998-12-31"
        End If

        drContract("StartDate") = dtDate
        Me.CheckChanges()
    End Sub

    Private Sub dtpStartDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpStartDate.ValueChanged
        Me.txbStartDate.Text = Format(Me.dtpStartDate.Value, "yyyy\/MM\/dd")
    End Sub

    Private Sub dtpEndDate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpEndDate.Leave
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub dtpEndDate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpEndDate.Validating
        If Me.dtpEndDate.Value = drContract("EndDate") Then Return
        Dim dtDate As Date = Me.dtpEndDate.Value
        If dtDate < drContract("StartDate") Then
            MessageBox.Show("合同结束日期不应早于开始日期！    " & Chr(13) & Chr(13) & "请重新输入合同结束日期。    ", "合同结束日期无效！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True : Return
        End If

        If sContractID = "-1" AndAlso DateDiff(DateInterval.Day, drContract("StartDate"), dtDate) < 15 Then
            MessageBox.Show("系统规定：新合同的合同期不得少于半个月！    " & Chr(13) & Chr(13) & "请重新输入合同结束日期。    ", "合同结束日期无效！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True : Return
        End If

        If DateDiff(DateInterval.Day, drContract("StartDate"), dtDate) > 366 Then
            Dim sPossibleDate As String = Format(DateAdd(DateInterval.Day, 366, drContract("StartDate")), "yyyy\/MM\/dd")
            MessageBox.Show("系统规定：合同期不得超过一年！    " & Chr(13) & Chr(13) & _
                            "可能最晚结束日期： " & sPossibleDate & Space(4) & Chr(13) & Chr(13) & _
                            "系统将自动设置本次合同的结束日期为""" & sPossibleDate & """（可能的最晚日期）。    ", "合同结束日期无效！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.dtpEndDate.MaxDate = CDate(sPossibleDate)
            e.Cancel = True : Return
        End If

        If dtDate < dtToday Then
            MessageBox.Show("对于一个有效的合同，其结束日期可能的最早日期是今天（" & Format(dtToday, "yyyy\/MM\/dd") & "）！    " & Chr(13) & Chr(13) & "系统将自动设置本次合同的结束日期为""" & Format(dtToday, "yyyy\/MM\/dd") & """。    ", "合同结束日期无效！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.dtpEndDate.MinDate = dtToday
            e.Cancel = True : Return
        End If
        Me.dtpAppointedDate.MinDate = "1753-1-1" : Me.dtpAppointedDate.Value = DateAdd(DateInterval.Day, DateDiff(DateInterval.Day, drContract("EndDate"), dtDate), drContract("AppointedDate"))
        drContract("EndDate") = dtDate
        drContract("AppointedDate") = Me.dtpAppointedDate.Value

        Me.CheckChanges()
    End Sub

    Private Sub dtpEndDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpEndDate.ValueChanged
        Me.txbEndDate.Text = Format(Me.dtpEndDate.Value, "yyyy\/MM\/dd")
    End Sub

    Private Sub txbMinFaceValue_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbMinFaceValue.Enter
        If Me.txbMinFaceValue.ReadOnly Then Return
        Me.txbMinFaceValue.Text = Me.txbMinFaceValue.Text.Replace(",", "")
    End Sub

    Private Sub txbMinFaceValue_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbMinFaceValue.KeyDown
        If Me.txbMinFaceValue.ReadOnly Then Return
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then Me.txbMaxFaceValue.Select() : Me.txbMaxFaceValue.SelectAll() : e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        If e.KeyCode = Keys.OemPeriod OrElse e.KeyCode = Keys.Decimal Then
            If Me.txbMinFaceValue.SelectedText.IndexOf(".") > -1 OrElse Me.txbMinFaceValue.Text.IndexOf(".") = -1 Then Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbMinFaceValue_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txbMinFaceValue.Validating
        If Me.txbMinFaceValue.ReadOnly Then Return
        If IsNumeric(Me.txbMinFaceValue.Text) Then
            If drContract("MinFaceValue").ToString <> "" AndAlso drContract("MinFaceValue") = CDec(Me.txbMinFaceValue.Text) Then
                Me.txbMinFaceValue.Text = Format(drContract("MinFaceValue"), "#,0.00")
                Return
            End If
        Else
            Me.txbMinFaceValue.Text = ""
            drContract("MinFaceValue") = DBNull.Value
            Return
        End If

        If CDec(Me.txbMinFaceValue.Text) = 0 Then
            MessageBox.Show("最小面值不能为零！    ", "最小面值错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
            Return
        End If

        If drContract("MaxFaceValue").ToString <> "" AndAlso CDec(Me.txbMinFaceValue.Text) > drContract("MaxFaceValue") Then
            MessageBox.Show("最小面值不能大于最大面值！    ", "最小面值错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
            Return
        End If

        drContract("MinFaceValue") = CDec(Me.txbMinFaceValue.Text)
        Me.txbMinFaceValue.Text = Format(drContract("MinFaceValue"), "#,0.00")
        Me.CheckChanges()
    End Sub

    Private Sub txbMaxFaceValue_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbMaxFaceValue.Enter
        If Me.txbMaxFaceValue.ReadOnly Then Return
        Me.txbMaxFaceValue.Text = Me.txbMaxFaceValue.Text.Replace(",", "")
    End Sub

    Private Sub txbMaxFaceValue_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbMaxFaceValue.KeyDown
        If Me.txbMaxFaceValue.ReadOnly Then Return
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then Me.txbMinFaceValue.Select() : Me.txbMinFaceValue.SelectAll() : e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        If e.KeyCode = Keys.OemPeriod OrElse e.KeyCode = Keys.Decimal Then
            If Me.txbMaxFaceValue.SelectedText.IndexOf(".") > -1 OrElse Me.txbMaxFaceValue.Text.IndexOf(".") = -1 Then Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbMaxFaceValue_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txbMaxFaceValue.Validating
        If Me.txbMaxFaceValue.ReadOnly Then Return
        If IsNumeric(Me.txbMaxFaceValue.Text) Then
            If drContract("MaxFaceValue").ToString <> "" AndAlso drContract("MaxFaceValue") = CDec(Me.txbMaxFaceValue.Text) Then
                Me.txbMaxFaceValue.Text = Format(drContract("MaxFaceValue"), "#,0.00")
                Return
            End If
        Else
            Me.txbMaxFaceValue.Text = ""
            drContract("MaxFaceValue") = DBNull.Value
            Return
        End If

        If CDec(Me.txbMaxFaceValue.Text) = 0 Then
            MessageBox.Show("最大面值不能为零！    ", "最大面值错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
            Return
        End If

        If CDec(Me.txbMaxFaceValue.Text) > 1000 Then
            MessageBox.Show("应国家政策规定， 最大面值不能超过 1,000 元！    ", "最大面值超过 1,000 元！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
            Return
        End If

        If drContract("MinFaceValue").ToString <> "" AndAlso CDec(Me.txbMaxFaceValue.Text) < drContract("MinFaceValue") Then
            MessageBox.Show("最大面值不能小于最小面值！    ", "最大面值错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
            Return
        End If

        drContract("MaxFaceValue") = CDec(Me.txbMaxFaceValue.Text)
        Me.txbMaxFaceValue.Text = Format(drContract("MaxFaceValue"), "#,0.00")
        Me.CheckChanges()
    End Sub

    Private Sub txbTotalContractAMT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbTotalContractAMT.Enter
        If Me.txbTotalContractAMT.ReadOnly Then Return
        Me.txbTotalContractAMT.Text = Me.txbTotalContractAMT.Text.Replace(",", "")
    End Sub

    Private Sub txbTotalContractAMT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbTotalContractAMT.KeyDown
        If Me.txbTotalContractAMT.ReadOnly Then Return
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then Me.txbMinContractAMT.Select() : Me.txbMinContractAMT.SelectAll() : e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        If e.KeyCode = Keys.OemPeriod OrElse e.KeyCode = Keys.Decimal Then
            If Me.txbTotalContractAMT.SelectedText.IndexOf(".") > -1 OrElse Me.txbTotalContractAMT.Text.IndexOf(".") = -1 Then Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbTotalContractAMT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txbTotalContractAMT.Validating
        If Me.txbTotalContractAMT.ReadOnly Then Return
        If IsNumeric(Me.txbTotalContractAMT.Text) Then
            If drContract("TotalContractAMT").ToString <> "" AndAlso drContract("TotalContractAMT") = CDec(Me.txbTotalContractAMT.Text) Then
                Me.txbTotalContractAMT.Text = Format(drContract("TotalContractAMT"), "#,0.00")
                Return
            End If
        Else
            Me.txbTotalContractAMT.Text = ""
            drContract("TotalContractAMT") = DBNull.Value
            Me.CheckChanges()
            Return
        End If

        If CDec(Me.txbTotalContractAMT.Text) = 0 Then
            MessageBox.Show("合同总金额不能为零！    ", "合同总金额错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
            Return
        End If

        If drContract("MinContractAMT").ToString <> "" AndAlso CDec(Me.txbTotalContractAMT.Text) < drContract("MinContractAMT") Then
            MessageBox.Show("合同总金额不能小于合同最小总金额！    ", "合同总金额错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
            Return
        End If

        If drContract("MaxContractAMT").ToString <> "" AndAlso CDec(Me.txbTotalContractAMT.Text) > drContract("MaxContractAMT") Then
            MessageBox.Show("合同总金额不能大于合同最大总金额！    ", "合同总金额错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
            Return
        End If

        If drContract("MinAMTPerPurchase").ToString <> "" AndAlso CDec(Me.txbTotalContractAMT.Text) < drContract("MinAMTPerPurchase") Then
            MessageBox.Show("合同总金额不能小于合同单次最低购买金额！    ", "合同总金额错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
            Return
        End If

        drContract("TotalContractAMT") = CDec(Me.txbTotalContractAMT.Text)
        Me.txbTotalContractAMT.Text = Format(drContract("TotalContractAMT"), "#,0.00")
        Me.CheckChanges()
    End Sub

    Private Sub txbMinContractAMT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbMinContractAMT.Enter
        If Me.txbMinContractAMT.ReadOnly Then Return
        Me.txbMinContractAMT.Text = Me.txbMinContractAMT.Text.Replace(",", "")
    End Sub

    Private Sub txbMinContractAMT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbMinContractAMT.KeyDown
        If Me.txbMinContractAMT.ReadOnly Then Return
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then Me.txbMaxContractAMT.Select() : Me.txbMaxContractAMT.SelectAll() : e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        If e.KeyCode = Keys.OemPeriod OrElse e.KeyCode = Keys.Decimal Then
            If Me.txbMinContractAMT.SelectedText.IndexOf(".") > -1 OrElse Me.txbMinContractAMT.Text.IndexOf(".") = -1 Then Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbMinContractAMT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txbMinContractAMT.Validating
        If Me.txbMinContractAMT.ReadOnly Then Return
        If IsNumeric(Me.txbMinContractAMT.Text) Then
            If drContract("MinContractAMT").ToString <> "" AndAlso drContract("MinContractAMT") = CDec(Me.txbMinContractAMT.Text) Then
                Me.txbMinContractAMT.Text = Format(drContract("MinContractAMT"), "#,0.00")
                Return
            End If
        Else
            Me.txbMinContractAMT.Text = ""
            drContract("MinContractAMT") = DBNull.Value
            Me.CheckChanges()
            Return
        End If

        If CDec(Me.txbMinContractAMT.Text) = 0 Then
            MessageBox.Show("合同最小总金额不能为零！    ", "合同最小总金额错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
            Return
        End If

        If drContract("MaxContractAMT").ToString <> "" AndAlso CDec(Me.txbMinContractAMT.Text) > drContract("MaxContractAMT") Then
            MessageBox.Show("合同最小总金额不能大于合同最大总金额！    ", "合同最小总金额错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
            Return
        End If

        If drContract("TotalContractAMT").ToString <> "" AndAlso CDec(Me.txbMinContractAMT.Text) > drContract("TotalContractAMT") Then
            MessageBox.Show("合同最小总金额不能大于合同总金额！    ", "合同最小总金额错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
            Return
        End If

        drContract("MinContractAMT") = CDec(Me.txbMinContractAMT.Text)
        Me.txbMinContractAMT.Text = Format(drContract("MinContractAMT"), "#,0.00")
        Me.CheckChanges()
    End Sub

    Private Sub txbMaxContractAMT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbMaxContractAMT.Enter
        If Me.txbMaxContractAMT.ReadOnly Then Return
        Me.txbMaxContractAMT.Text = Me.txbMaxContractAMT.Text.Replace(",", "")
    End Sub

    Private Sub txbMaxContractAMT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbMaxContractAMT.KeyDown
        If Me.txbMaxContractAMT.ReadOnly Then Return
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then Me.txbMinAMTPerPurchase.Select() : Me.txbMinAMTPerPurchase.SelectAll() : e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        If e.KeyCode = Keys.OemPeriod OrElse e.KeyCode = Keys.Decimal Then
            If Me.txbMaxContractAMT.SelectedText.IndexOf(".") > -1 OrElse Me.txbMaxContractAMT.Text.IndexOf(".") = -1 Then Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbMaxContractAMT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txbMaxContractAMT.Validating
        If Me.txbMaxContractAMT.ReadOnly Then Return
        If IsNumeric(Me.txbMaxContractAMT.Text) Then
            If drContract("MaxContractAMT").ToString <> "" AndAlso drContract("MaxContractAMT") = CDec(Me.txbMaxContractAMT.Text) Then
                Me.txbMaxContractAMT.Text = Format(drContract("MaxContractAMT"), "#,0.00")
                Return
            End If
        Else
            Me.txbMaxContractAMT.Text = ""
            drContract("MaxContractAMT") = DBNull.Value
            Me.CheckChanges()
            Return
        End If

        If CDec(Me.txbMaxContractAMT.Text) = 0 Then
            MessageBox.Show("合同最大总金额不能为零！    ", "合同最大总金额错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
            Return
        End If

        If drContract("MinContractAMT").ToString <> "" AndAlso CDec(Me.txbMaxContractAMT.Text) < drContract("MinContractAMT") Then
            MessageBox.Show("合同最大总金额不能小于合同最小总金额！    ", "合同最大总金额错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
            Return
        End If

        If drContract("TotalContractAMT").ToString <> "" AndAlso CDec(Me.txbMaxContractAMT.Text) < drContract("TotalContractAMT") Then
            MessageBox.Show("合同最大总金额不能小于合同总金额！    ", "合同最大总金额错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
            Return
        End If

        If drContract("MinAMTPerPurchase").ToString <> "" AndAlso CDec(Me.txbMaxContractAMT.Text) < drContract("MinAMTPerPurchase") Then
            MessageBox.Show("合同最大总金额不能小于合同单次最低购买金额！    ", "合同最大总金额错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
            Return
        End If

        drContract("MaxContractAMT") = CDec(Me.txbMaxContractAMT.Text)
        Me.txbMaxContractAMT.Text = Format(drContract("MaxContractAMT"), "#,0.00")
        Me.CheckChanges()
    End Sub

    Private Sub txbMinAMTPerPurchase_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbMinAMTPerPurchase.Enter
        If Me.txbMinAMTPerPurchase.ReadOnly Then Return
        Me.txbMinAMTPerPurchase.Text = Me.txbMinAMTPerPurchase.Text.Replace(",", "")
    End Sub

    Private Sub txbMinAMTPerPurchase_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbMinAMTPerPurchase.KeyDown
        If Me.txbMinAMTPerPurchase.ReadOnly Then Return
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then Me.txbTotalContractAMT.Select() : Me.txbTotalContractAMT.SelectAll() : e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        If e.KeyCode = Keys.OemPeriod OrElse e.KeyCode = Keys.Decimal Then
            If Me.txbMinAMTPerPurchase.SelectedText.IndexOf(".") > -1 OrElse Me.txbMinAMTPerPurchase.Text.IndexOf(".") = -1 Then Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbMinAMTPerPurchase_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txbMinAMTPerPurchase.Validating
        If Me.txbMinAMTPerPurchase.ReadOnly Then Return
        If IsNumeric(Me.txbMinAMTPerPurchase.Text) Then
            If drContract("MinAMTPerPurchase").ToString <> "" AndAlso drContract("MinAMTPerPurchase") = CDec(Me.txbMinAMTPerPurchase.Text) Then
                Me.txbMinAMTPerPurchase.Text = Format(drContract("MinAMTPerPurchase"), "#,0.00")
                Return
            End If
        Else
            Me.txbMinAMTPerPurchase.Text = ""
            drContract("MinAMTPerPurchase") = DBNull.Value
            Return
        End If

        'If Cdec(Me.txbMinAMTPerPurchase.Text) = 0 Then
        '    MessageBox.Show("合同单次最低购买金额不能为零！    ", "合同单次最低购买金额错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    e.Cancel = True
        '    Return
        'End If

        If drContract("MaxContractAMT").ToString <> "" AndAlso CDec(Me.txbMinAMTPerPurchase.Text) > drContract("MaxContractAMT") Then
            MessageBox.Show("合同单次最低购买金额不能大于合同最大总金额！    ", "合同单次最低购买金额错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
            Return
        End If

        drContract("MinAMTPerPurchase") = CDec(Me.txbMinAMTPerPurchase.Text)
        Me.txbMinAMTPerPurchase.Text = Format(drContract("MinAMTPerPurchase"), "#,0.00")
        Me.CheckChanges()
    End Sub

    Private Sub rdbAddition_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbAddition.CheckedChanged
        If blSkipDeal Then Return
        If Me.rdbAddition.Checked Then
            drContract("PaymentMode") = 0
            Me.rdbCalculationBySection.Enabled = True
            Me.rdbEndOfContract.Enabled = True
            Me.rdbMonthly.Enabled = True
        Else
            drContract("PaymentMode") = 1
            Me.rdbEachPurchase.Checked = True
            Me.rdbEndOfContract.Enabled = False
            Me.rdbMonthly.Enabled = False
        End If
        Me.CheckChanges()
    End Sub

    Private Sub rdbCalculationByTotal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbCalculationByTotal.CheckedChanged
        If blSkipDeal Then Return
        If Me.rdbCalculationByTotal.Checked Then
            drContract("CalculationMode") = 0
        Else
            drContract("CalculationMode") = 1
        End If
        Me.CheckChanges()
    End Sub

    Private Sub rdbEndOfContract_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbEndOfContract.CheckedChanged
        If blSkipDeal Then Return
        If Me.rdbEndOfContract.Checked Then
            drContract("CalculationDay") = 0
            Me.CheckChanges()
        End If
        Me.dtpAppointedDate.Enabled = Me.rdbEndOfContract.Checked
    End Sub

    Private Sub dtpAppointedDate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpAppointedDate.Validating
        If Me.dtpAppointedDate.Value = drContract("AppointedDate") Then Return
        If Me.dtpAppointedDate.Value <= Me.dtpEndDate.Value Then
            MessageBox.Show("兑现返点的结束日期不应早于合同的结束日期！    " & Chr(13) & Chr(13) & "系统将自动设置该日期为""" & Format(DateAdd(DateInterval.Day, 1, drContract("EndDate")), "yyyy\/MM\/dd") & """。    ", "兑现返点的结束日期无效！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.dtpAppointedDate.MinDate = DateAdd(DateInterval.Day, 1, drContract("EndDate"))
            e.Cancel = True : Return
        End If

        drContract("AppointedDate") = Me.dtpAppointedDate.Value
        Me.CheckChanges()
    End Sub

    Private Sub dtpAppointedDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpAppointedDate.ValueChanged
        Me.txbAppointedDate.Text = Format(Me.dtpAppointedDate.Value, "yyyy\/MM\/dd")
    End Sub

    Private Sub rdbMonthly_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbMonthly.CheckedChanged
        If blSkipDeal Then Return
        If Me.rdbMonthly.Checked Then
            drContract("CalculationDay") = Me.nudCalculationDay.Value
            Me.CheckChanges()
        End If
        Me.nudCalculationDay.Enabled = Me.rdbMonthly.Checked
    End Sub

    Private Sub nudCalculationDay_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudCalculationDay.Leave
        If drContract("CalculationDay") <> Me.nudCalculationDay.Value Then
            drContract("CalculationDay") = Me.nudCalculationDay.Value
            Me.CheckChanges()
        End If
    End Sub

    Private Sub rdbEachPurchase_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbEachPurchase.CheckedChanged
        If blSkipDeal Then Return
        If Me.rdbEachPurchase.Checked Then
            drContract("CalculationDay") = 255
            Me.CheckChanges()
        End If
    End Sub

    Private Sub dgvDetails_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvDetails.CellFormatting
        If Me.dgvDetails.ReadOnly = True Then
            e.CellStyle.BackColor = SystemColors.Control
            If Me.dgvDetails.Columns(e.ColumnIndex).Name <> "LevelID" AndAlso (e.RowIndex = iFirstAvailableRowID OrElse e.RowIndex = iSecondAvailableRowID) Then
                e.CellStyle.ForeColor = Color.Blue
                e.CellStyle.BackColor = Color.Yellow
                e.CellStyle.SelectionForeColor = Color.Blue
                e.CellStyle.SelectionBackColor = Color.Yellow
            End If
        ElseIf e.ColumnIndex = 2 Then
            If Me.dgvDetails.Rows(e.RowIndex).Selected = False Then
                e.CellStyle.SelectionForeColor = SystemColors.ControlText
                e.CellStyle.SelectionBackColor = SystemColors.Window
            End If
        ElseIf errorCell IsNot Nothing AndAlso e.ColumnIndex = errorCell.ColumnIndex AndAlso e.RowIndex = errorCell.RowIndex Then
            e.CellStyle.ForeColor = Color.Red : e.CellStyle.SelectionForeColor = Color.Red
        End If
    End Sub

    Private Sub dgvDetails_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetails.CellLeave
        If editingTextBox IsNot Nothing Then
            Select Case e.ColumnIndex
                Case 3
                    If editingTextBox.Text <> "" Then editingTextBox.Text = Format(CDec(editingTextBox.Text), "#,0.00")
                Case 4
                    'modify code 038:start-------------------------------------------------------------------------
                    'If editingTextBox.Text <> "" Then editingTextBox.Text = Format(CDec(editingTextBox.Text), "#,0.0")
                    If editingTextBox.Text <> "" Then editingTextBox.Text = Format(CDec(editingTextBox.Text), "#,0.00")
                    'modify code 038:start-------------------------------------------------------------------------
            End Select
            editingTextBox = Nothing
        End If
    End Sub

    Private Sub dgvDetails_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvDetails.CellMouseUp
        If e.Button = Windows.Forms.MouseButtons.Right AndAlso e.ColumnIndex = 1 AndAlso Me.dgvDetails.ReadOnly = False AndAlso (e.RowIndex > 0 OrElse Me.dgvDetails("RebateRate", 0).Value.ToString = "" OrElse Me.dgvDetails("RebateRate", 0).Value <> 0 OrElse Me.dgvDetails("EndSalesAMT", 0).Value.ToString <> "") Then
            blSkipDeal = True
            Me.dgvDetails.EditMode = DataGridViewEditMode.EditProgrammatically
            Me.dgvDetails("StartSalesAMT", e.RowIndex).Selected = True
            Me.dgvDetails.CurrentRow.Selected = True
            blSkipDeal = False
            Me.cmenuDeleteRebateRow.Show(Control.MousePosition)
        End If
    End Sub

    Private Sub dgvDetails_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetails.CellValueChanged
        If blSkipDeal Then Return
        blSkipDeal = True
        Dim sValue As String = Me.dgvDetails(e.ColumnIndex, e.RowIndex).Value.ToString
        sErrorInfo = "" : errorCell = Nothing
        If sValue <> "" AndAlso Not IsNumeric(sValue) Then sValue = ""
        'If sValue = "" AndAlso sOldValue <> "" Then Me.dgvDetails.EndEdit() : Me.dgvDetails(e.ColumnIndex, e.RowIndex).Value = sOldValue : sValue = sOldValue
        frmMain.statusText.Text = "就绪。"

        Select Case e.ColumnIndex
            Case 3
                If sValue = "" Then
                    If e.RowIndex <> Me.dgvDetails.RowCount - 1 Then
                        For iRow As Int16 = Me.dgvDetails.RowCount - 1 To e.RowIndex + 1 Step -1
                            dtContractDetails.Rows(iRow).Delete()
                        Next
                        drContract("MaxRebateRate") = dtContractDetails.Compute("Max(RebateRate)", "")
                        If drContract("MaxRebateRate").ToString = "" Then drContract("MaxRebateRate") = 0 Else drContract("MaxRebateRate") = drContract("MaxRebateRate") / 100
                    End If
                ElseIf e.RowIndex > 0 AndAlso CDec(sValue) <= Me.dgvDetails(3, e.RowIndex - 1).Value Then
                    sErrorInfo = IIf(CDec(sValue) = Me.dgvDetails(3, e.RowIndex - 1).Value, "等", "低") & "于上一行的最大金额"
                ElseIf e.RowIndex < Me.dgvDetails.RowCount - 2 AndAlso CDec(sValue) >= Me.dgvDetails(3, e.RowIndex + 1).Value Then
                    sErrorInfo = IIf(CDec(sValue) = Me.dgvDetails(3, e.RowIndex + 1).Value, "等", "高") & "于下一行的最大金额"
                End If

                If sErrorInfo = "" Then
                    Me.dgvDetails.EndEdit()
                    If e.RowIndex = Me.dgvDetails.RowCount - 1 Then
                        If sValue <> "" Then
                            Dim newItem As DataRow = dtContractDetails.Rows.Add
                            newItem("ContractID") = sContractID
                            newItem("LevelID") = e.RowIndex + 2
                            newItem("StartSalesAMT") = CDec(sValue)
                            newItem.EndEdit() : newItem = Nothing
                            Me.ResetDetialsLayout()
                        End If
                        If Me.dgvDetails("RebateRate", e.RowIndex).Value.ToString = "" OrElse e.RowIndex = Me.dgvDetails.RowCount - 1 Then
                            Me.dgvDetails("RebateRate", e.RowIndex).Selected = True
                            Me.dgvDetails.BeginEdit(True)
                        Else
                            Me.dgvDetails("RebateRate", e.RowIndex + 1).Selected = True
                            Me.dgvDetails.BeginEdit(True)
                        End If
                    Else
                        Me.dgvDetails(2, e.RowIndex + 1).Value = sValue
                        Me.dgvDetails(2, e.RowIndex + 1).Selected = True
                        Me.dgvDetails.BeginEdit(True)
                    End If
                Else
                    errorCell = Me.dgvDetails.CurrentCell
                    MessageBox.Show("该行的最大金额不能" & sErrorInfo & "！    " & Chr(13) & Chr(13) & "请重新输入该行的最大金额。    ", "最大金额错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    frmMain.statusText.Text = "此行的最大金额错误（" & sErrorInfo & "）！请重新输入该行的最大金额。"
                    Me.dgvDetails(4, e.RowIndex).Selected = True : errorCell.Selected = True
                    Me.dgvDetails.BeginEdit(True)
                End If
            Case 4
                If sValue = "" Then
                ElseIf CDec(sValue) > 20 Then
                    sErrorInfo = "大于 20 %"
                ElseIf e.RowIndex > 0 AndAlso Me.dgvDetails(4, e.RowIndex - 1).Value.ToString <> "" AndAlso CDec(sValue) <= Me.dgvDetails(4, e.RowIndex - 1).Value Then
                    sErrorInfo = IIf(CDec(sValue) = Me.dgvDetails(4, e.RowIndex - 1).Value, "等", "低") & "于上一行的返点比率"
                ElseIf e.RowIndex < Me.dgvDetails.RowCount - 1 AndAlso Me.dgvDetails(4, e.RowIndex + 1).Value.ToString <> "" AndAlso CDec(sValue) >= Me.dgvDetails(4, e.RowIndex + 1).Value Then
                    sErrorInfo = IIf(CDec(sValue) = Me.dgvDetails(4, e.RowIndex + 1).Value, "等", "高") & "于下一行的返点比率"
                End If

                If sErrorInfo = "" Then
                    Me.dgvDetails.EndEdit()
                    drContract("MaxRebateRate") = dtContractDetails.Compute("Max(RebateRate)", "")
                    If drContract("MaxRebateRate").ToString = "" Then drContract("MaxRebateRate") = 0 Else drContract("MaxRebateRate") = drContract("MaxRebateRate") / 100
                Else
                    errorCell = Me.dgvDetails.CurrentCell
                    MessageBox.Show("该行的返点比率不能" & sErrorInfo & "！    " & Chr(13) & Chr(13) & "请重新输入该行的返点比率。    ", "返点比率错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    frmMain.statusText.Text = "此行的返点比率错误（" & sErrorInfo & "）！请重新输入该行的返点比率。"
                    Me.dgvDetails(3, e.RowIndex).Selected = True : errorCell.Selected = True
                    Me.dgvDetails.BeginEdit(True)
                End If
        End Select

        If sErrorInfo = "" Then
            sValidationDescription = "" '空白表示未检查合同超过城市返点时由谁审核
            Me.btnCompare.Enabled = (dtDisplayedCustomer.Rows.Count > 0 AndAlso frmMain.dtAllowedRight.Select("RightName='CityConfigBrowse'").Length > 0)
            sTimerType = "CheckChanges"
            Me.theTimer.Interval = 50
            Me.theTimer.Enabled = True
        End If
        blSkipDeal = False
    End Sub

    Private Sub dgvDetails_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvDetails.EditingControlShowing
        editingTextBox = CType(e.Control, TextBox)
        RemoveHandler editingTextBox.KeyDown, AddressOf editingTextBox_KeyDown
        editingTextBox.ImeMode = Windows.Forms.ImeMode.Disable
        editingTextBox.Text = editingTextBox.Text.Replace(",", "")
        sOldValue = editingTextBox.Text
        If Me.dgvDetails.CurrentCell.ColumnIndex = 3 Then
            editingTextBox.MaxLength = 12
        Else
            editingTextBox.MaxLength = 5
        End If
        AddHandler editingTextBox.KeyDown, AddressOf editingTextBox_KeyDown
    End Sub

    Private Sub dgvDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetails.KeyDown
        If e.KeyCode = Keys.Delete AndAlso Me.dgvDetails.ReadOnly = False AndAlso Me.dgvDetails.CurrentRow.Selected = True AndAlso (Me.dgvDetails.CurrentRow.Index > 0 OrElse Me.dgvDetails("RebateRate", 0).Value <> 0 OrElse Me.dgvDetails("EndSalesAMT", 0).Value.ToString <> "") Then Me.menuDeleteRebateRow.PerformClick() : e.SuppressKeyPress = True
    End Sub

    Private Sub dgvDetails_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDetails.Leave
        frmMain.statusText.Text = "就绪。"
        blSkipDeal = True
        If Me.dgvDetails.CurrentCell IsNot Nothing Then Me.dgvDetails.CurrentCell.Selected = False
        If Me.dgvDetails.CurrentRow IsNot Nothing Then Me.dgvDetails.CurrentRow.Selected = False
        blSkipDeal = False
    End Sub

    Private Sub dgvDetails_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDetails.SelectionChanged
        If blSkipDeal OrElse Me.dgvDetails.CurrentCell Is Nothing Then Return
        blSkipDeal = True
        frmMain.statusText.Text = "就绪。"
        Me.dgvDetails.EditMode = DataGridViewEditMode.EditProgrammatically
        If Me.dgvDetails.CurrentCell.ColumnIndex = 1 Then
            Me.dgvDetails("StartSalesAMT", Me.dgvDetails.CurrentRow.Index).Selected = True
            Me.dgvDetails.CurrentRow.Selected = True
            If Me.dgvDetails.ReadOnly = False AndAlso (Me.dgvDetails.CurrentRow.Index > 0 OrElse Me.dgvDetails("RebateRate", 0).Value.ToString = "" OrElse Me.dgvDetails("RebateRate", 0).Value <> 0 OrElse Me.dgvDetails("EndSalesAMT", 0).Value.ToString <> "") Then frmMain.statusText.Text = "提示：按<Delete>键可删除该行。"
        ElseIf Me.dgvDetails.ReadOnly = True Then
            Me.dgvDetails.CurrentRow.Selected = True
        ElseIf Me.dgvDetails.CurrentCell.ColumnIndex = 2 Then
            If Me.dgvDetails.CurrentCell.RowIndex = 0 Then
                frmMain.statusText.Text = "最小金额由系统自动设置（第一行的最小金额固定为零），不必手工输入。"
            Else
                frmMain.statusText.Text = "最小金额由系统自动设置（上一行的最大金额），不必手工输入。"
            End If
        Else
            Me.dgvDetails.EditMode = DataGridViewEditMode.EditOnEnter
            If errorCell IsNot Nothing AndAlso errorCell IsNot Me.dgvDetails.CurrentCell Then
                If errorCell.ColumnIndex = 3 Then
                    frmMain.statusText.Text = "此行的最大金额错误（" & sErrorInfo & "）！请重新输入该行的最大金额。"
                Else
                    frmMain.statusText.Text = "此行的返点比率错误（" & sErrorInfo & "）！请重新输入该行的返点比率。"
                End If
                errorCell.Selected = True
            End If
            Me.dgvDetails.BeginEdit(True)
        End If
        blSkipDeal = False
    End Sub

    Private Sub menuDeleteRebateRow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuDeleteRebateRow.Click
        blSkipDeal = True
        Dim iCurrentRow As Integer = Me.dgvDetails.CurrentRow.Index
        If errorCell IsNot Nothing AndAlso errorCell.RowIndex = iCurrentRow Then errorCell = Nothing : sErrorInfo = ""
        If dtContractDetails.Rows.Count = 1 Then
            dtContractDetails.Rows(0)(2) = 0
            dtContractDetails.Rows(0)(3) = DBNull.Value
            dtContractDetails.Rows(0)(4) = 0
        ElseIf iCurrentRow = 0 Then
            dtContractDetails.Rows(1)(2) = 0
            For iRow As Int16 = 1 To dtContractDetails.Rows.Count - 1
                dtContractDetails.Rows(iRow)(1) = iRow
            Next
            dtContractDetails.Rows(0).Delete()
        ElseIf iCurrentRow = dtContractDetails.Rows.Count - 1 Then
            dtContractDetails.Rows(iCurrentRow - 1)(3) = DBNull.Value
            dtContractDetails.Rows(iCurrentRow).Delete()
        Else
            dtContractDetails.Rows(iCurrentRow - 1)(3) = dtContractDetails.Rows(iCurrentRow + 1)(2)
            For iRow As Int16 = iCurrentRow + 1 To dtContractDetails.Rows.Count - 1
                dtContractDetails.Rows(iRow)(1) = iRow
            Next
            dtContractDetails.Rows(iCurrentRow).Delete()
        End If
        Me.ResetDetialsLayout()

        drContract("MaxRebateRate") = dtContractDetails.Compute("Max(RebateRate)", "")
        If drContract("MaxRebateRate").ToString = "" Then drContract("MaxRebateRate") = 0 Else drContract("MaxRebateRate") = drContract("MaxRebateRate") / 100

        Me.btnCompare.Enabled = (dtDisplayedCustomer.Rows.Count > 0 AndAlso frmMain.dtAllowedRight.Select("RightName='CityConfigBrowse'").Length > 0)
        Me.CheckChanges()
        blSkipDeal = False
        If Me.dgvDetails.CurrentRow IsNot Nothing Then
            Me.dgvDetails(1, Me.dgvDetails.CurrentRow.Index).Selected = True
            Me.dgvDetails.CurrentRow.Selected = True
        End If
    End Sub

    Private Sub editingTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        If e.KeyCode = Keys.OemPeriod OrElse e.KeyCode = Keys.Decimal Then
            If editingTextBox.SelectedText.IndexOf(".") > -1 OrElse editingTextBox.Text.IndexOf(".") = -1 Then Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub btnCompare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompare.Click
        If sContractID = "-1" Then
            If errorCell IsNot Nothing Then
                If errorCell.ColumnIndex = 3 Then
                    MessageBox.Show("不能对比城市返点规则，因为有一行的最大金额错误（" & sErrorInfo & "）！    " & Chr(13) & Chr(13) & "请重新输入该行的最大金额。    ", "不能对比城市返点规则！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    frmMain.statusText.Text = "不能对比城市返点规则，因为有一行的最大金额错误（" & sErrorInfo & "）！请重新输入该行的最大金额。"
                Else
                    MessageBox.Show("不能对比城市返点规则，因为有一行的返点比率错误（" & sErrorInfo & "）！    " & Chr(13) & Chr(13) & "请重新输入该行的返点比率。    ", "不能对比城市返点规则！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    frmMain.statusText.Text = "不能对比城市返点规则，因为有一行的返点比率错误（" & sErrorInfo & "）！请重新输入该行的返点比率。"
                End If
                blSkipDeal = True
                Me.dgvDetails.Select()
                Me.dgvDetails.EditMode = DataGridViewEditMode.EditOnEnter
                errorCell.Selected = True
                Me.dgvDetails.BeginEdit(True)
                blSkipDeal = False
                Me.btnCompare.Enabled = False : Return
            End If

            For Each drRebate As DataGridViewRow In Me.dgvDetails.Rows
                If drRebate.Cells("RebateRate").Value.ToString = "" Then
                    MessageBox.Show("不能对比城市返点规则，因为有一行的返点比率未设置！    " & Chr(13) & Chr(13) & "请设置该行的返点比率。    ", "不能对比城市返点规则！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    frmMain.statusText.Text = "不能对比城市返点规则，因为有一行的返点比率未设置！请设置该行的返点比率。"
                    blSkipDeal = True
                    Me.dgvDetails.Select()
                    Me.dgvDetails.EditMode = DataGridViewEditMode.EditOnEnter
                    drRebate.Cells("RebateRate").Selected = True
                    Me.dgvDetails.BeginEdit(True)
                    blSkipDeal = False
                    Me.btnCompare.Enabled = False : Return
                End If
            Next
        End If

        If sValidationDescription = "" Then Me.CheckValidation()

        If (blContentChanged OrElse drContract("ContractState") = 0) AndAlso dvNewestCityRule.Count = 0 Then
            MessageBox.Show("当前城市还未设置城市返点规则！    " & Chr(13) & Chr(13) & "Current City have no City's Discount Rule now!     ", "没有城市返点规则 No City's Discount Rule!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.btnCompare.Enabled = False
            Return
        End If

        If drContract("ContractState") > 0 AndAlso blContentChanged = False AndAlso dvHistoryCityRule.Count = 0 Then
            MessageBox.Show("合同审核时，当前城市还未设置城市返点规则！    " & Chr(13) & Chr(13) & "No City's Discount Rule when validated this contract!     ", "没有城市返点规则 No City's Discount Rule!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.btnCompare.Enabled = False
            Return
        End If

        With frmContractCityRule
            If blContentChanged OrElse drContract("ContractState") = 0 Then
                .dvCityRule = dvNewestCityRule
                .dvRuleDetails = dvNewestRuleDetails
            Else
                .dvCityRule = dvHistoryCityRule
                .dvRuleDetails = dvHistoryRuleDetails

                If blMultiCompanies Then
                    .lblCityRuleChineseTitle.Text = "在一级审核时的城市返点规则"
                    .lblCityRuleEnglishTitle.Text = "City Discount Rule when first validation:"
                Else
                    .lblCityRuleChineseTitle.Text = "在审核时的城市返点规则"
                    .lblCityRuleEnglishTitle.Text = "City Discount Rule when validation:"
                End If
            End If

            If sValidationDescription.IndexOf("未") = 0 Then
                .lblConclusion.Text = "在城市返点标准范围之内 Within the standard of City's Discount Rule."
            Else
                .lblConclusion.ForeColor = Color.Red
                .lblConclusion.Text = "已超过城市返点标准范围 Already go over the top of City's Discount Rule."
            End If
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub rdbAllStores_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbAllStores.CheckedChanged
        If blSkipDeal Then Return

        If Me.rdbAllStores.Checked Then
            drContract("AppointedStoreID") = DBNull.Value
            Me.CheckChanges()
        End If
    End Sub

    Private Sub rdbAppointedStore_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbAppointedStore.CheckedChanged
        Me.cbbAppointedStore.Enabled = Me.rdbAppointedStore.Checked
        Me.txbAppointedStore.Enabled = Me.rdbAppointedStore.Checked
        If blSkipDeal Then Return

        If Me.rdbAppointedStore.Checked Then
            If dtContractCustomer.Rows.Count = 0 Then
                blSkipDeal = True
                Me.rdbAllStores.Checked = True
                blSkipDeal = False
                MessageBox.Show("您还未添加乙方公司！请先添加乙方公司。    ", "还未添加乙方公司！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                frmMain.statusText.Text = "您还未添加乙方公司！请先添加乙方公司。"
                Me.grbPartyB.Select()
                If Me.txbCustomerName.Visible Then
                    Me.txbCustomerName.Select() : Me.txbCustomerName.SelectAll()
                Else
                    Me.cbbCustomerName.Select() : Me.cbbCustomerName.SelectAll()
                End If
            Else
                Me.txbAppointedStore.Visible = False
                Me.txbAppointedStore.Text = Me.cbbAppointedStore.Text
                Me.cbbAppointedStore.Visible = True
                Me.cbbAppointedStore.Select()

                drContract("AppointedStoreID") = Me.cbbAppointedStore.SelectedValue
                Me.CheckChanges()
            End If
        Else
            Me.cbbAppointedStore.Visible = False
            Me.txbAppointedStore.Visible = True
            Me.txbAppointedStore.Text = ""
        End If
    End Sub

    Private Sub cbbAppointedStore_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbAppointedStore.SelectedIndexChanged
        If blSkipDeal Then Return

        Me.txbAppointedStore.Text = Me.cbbAppointedStore.Text
        drContract("AppointedStoreID") = Me.cbbAppointedStore.SelectedValue
        Me.CheckChanges()
    End Sub

    Private Sub cklInvoiceTitle_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cklInvoiceTitle.Enter
        If Me.dgvCustomer.RowCount = 0 Then
            Me.grbPartyB.Select()
            If Me.txbCustomerName.Visible Then
                Me.txbCustomerName.Select() : Me.txbCustomerName.SelectAll()
            Else
                Me.cbbCustomerName.Select() : Me.cbbCustomerName.SelectAll()
            End If
            frmMain.statusText.Text = "您还未添加乙方公司，请先输入客户名称，然后添加到乙方公司列表中。"
        End If
    End Sub

    Private Sub cklInvoiceTitle_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles cklInvoiceTitle.ItemCheck
        If blSkipDeal Then Return
        If Not blCanModify OrElse dtContractCustomer.Rows.Count = 0 OrElse Me.cklInvoiceTitle.SelectedIndex = 0 Then
            e.NewValue = e.CurrentValue
        Else
            Dim drJoinedCusotmer As DataRow = dtContractCustomer.Select("RowID=" & (e.Index + 1).ToString)(0)
            If e.NewValue = CheckState.Unchecked Then
                drJoinedCusotmer("InvoiceTitleCustomerID") = drContract("MainCustomerID")
            Else
                drJoinedCusotmer("InvoiceTitleCustomerID") = drJoinedCusotmer("CustomerID")
            End If
            Me.CheckChanges()
        End If
    End Sub

    Private Sub cklInvoiceTitle_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cklInvoiceTitle.Leave
        blSkipDeal = True
        Me.cklInvoiceTitle.ClearSelected()
        blSkipDeal = False
    End Sub

    Private Sub cklInvoiceTitle_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cklInvoiceTitle.MouseDown
        If e.Button <> Windows.Forms.MouseButtons.Left OrElse Not blCanModify OrElse dtContractCustomer.Rows.Count = 0 OrElse Me.cklInvoiceTitle.SelectedIndex = 0 Then iOriginalIndex = 0 : Return

        Dim iClicedIndex As Int16 = Me.cklInvoiceTitle.IndexFromPoint(Me.cklInvoiceTitle.PointToClient(Control.MousePosition))
        If iOriginalIndex <> iClicedIndex Then
            Me.cklInvoiceTitle.SetItemChecked(iClicedIndex, Not Me.cklInvoiceTitle.GetItemChecked(iClicedIndex))
            iOriginalIndex = iClicedIndex
        End If
    End Sub

    Private Sub cklInvoiceTitle_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cklInvoiceTitle.SelectedIndexChanged
        If blSkipDeal OrElse Not blCanModify Then Return

        If Me.cklInvoiceTitle.SelectedIndex = 0 Then
            If dtDisplayedCustomer.Rows.Count = 1 Then
                frmMain.statusText.Text = "作为合同唯一的乙方公司，其公司名称是销售时唯一可用的发票抬头，所以该项是必选项。"
            Else
                frmMain.statusText.Text = "作为主公司，其名称是销售时该公司唯一可用的发票抬头，或作为该合同的其它公司的发票抬头，所以该项是必选项。"
            End If
        Else
            frmMain.statusText.Text = "若要在销售时使用自身名称作为发票抬头，请勾选该项；若要使用主公司名称，请不要勾选该项。"
        End If
    End Sub

    Private Sub cbbInvoiceItem_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbInvoiceItem.DropDown
        If blSkipDeal Then Return
        blSkipDeal = True
        Me.cbbInvoiceItem.DroppedDown = True
        If Me.cklInvoiceItem.Visible Then
            Me.cklInvoiceItem.Visible = False
            Me.cbbInvoiceItem.Text = sOldValue
        Else
            Dim theTop As Integer = Me.cbbInvoiceItem.Top, theParent As Control = Me.cbbInvoiceItem.Parent
            Do
                theTop += theParent.Top
                theParent = theParent.Parent
            Loop Until theParent.Name = "frmContract"

            Dim iMaxItems As Int16 = Int((theTop - 4) / 16)
            Me.cklInvoiceItem.Height = (IIf(Me.cklInvoiceItem.Items.Count < iMaxItems, Me.cklInvoiceItem.Items.Count, iMaxItems) * 16) + 4
            Me.cklInvoiceItem.Top = theTop - Me.cklInvoiceItem.Height
            Me.cklInvoiceItem.Visible = True
            Me.cklInvoiceItem.Select()
            For iItem As Integer = 0 To Me.cklInvoiceItem.Items.Count - 1
                If Me.cklInvoiceItem.GetItemChecked(iItem) Then Me.cklInvoiceItem.SetSelected(iItem, True) : Exit For
            Next
        End If
        blSkipDeal = False
    End Sub

    Private Sub cbbInvoiceItem_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbInvoiceItem.Enter
        If Me.dgvCustomer.RowCount = 0 Then
            Me.grbPartyB.Select()
            If Me.txbCustomerName.Visible Then
                Me.txbCustomerName.Select() : Me.txbCustomerName.SelectAll()
            Else
                Me.cbbCustomerName.Select() : Me.cbbCustomerName.SelectAll()
            End If
            frmMain.statusText.Text = "您还未添加乙方公司，请先输入客户名称，然后添加到乙方公司列表中。"
        Else
            sOldValue = Me.cbbInvoiceItem.Text
        End If
    End Sub

    Private Sub cbbInvoiceItem_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbbInvoiceItem.KeyPress
        e.Handled = True
        Me.cbbInvoiceItem.SelectAll()
    End Sub

    Private Sub cbbInvoiceItem_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbInvoiceItem.Leave
        Me.cbbInvoiceItem.SelectionLength = 0
    End Sub

    Private Sub cbbInvoiceItem_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cbbInvoiceItem.MouseDown, cbbInvoiceItem.MouseUp
        My.Computer.Clipboard.Clear()
        If Me.cbbInvoiceItem.Text = "" Then
            Me.cbbInvoiceItem.Text = sOldValue
            Me.cbbInvoiceItem.SelectAll()
        End If
    End Sub

    Private Sub cbbInvoiceItem_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cbbInvoiceItem.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            bClicks += 1
            sTimerType = "DoubleClick"
            Me.theTimer.Interval = 500
            Me.theTimer.Enabled = True
            If bClicks = 2 Then
                Me.cbbInvoiceItem.SelectionStart = 0
                Me.cbbInvoiceItem.SelectionLength = Me.cbbInvoiceItem.Text.Length
                bClicks = 0
            End If
        End If
    End Sub

    Private Sub cklInvoiceItem_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles cklInvoiceItem.ItemCheck
        If blSkipDeal Then Return
        If blCanModify Then
            blSkipDeal = True
            If e.Index = 0 Then
                For iItem As Integer = 1 To Me.cklInvoiceItem.Items.Count - 1
                    Me.cklInvoiceItem.SetItemChecked(iItem, e.NewValue = CheckState.Checked)
                Next
            Else
                If e.NewValue = CheckState.Unchecked Then
                    Me.cklInvoiceItem.SetItemChecked(0, False)
                Else
                    Me.cklInvoiceItem.SetItemChecked(0, Me.cklInvoiceItem.CheckedItems.Count = Me.cklInvoiceItem.Items.Count - 2)
                End If
            End If
            blSkipDeal = False
            If Me.cklInvoiceItem.CheckedItems.Count + IIf(e.NewValue = CheckState.Checked, 1, -1) = Me.cklInvoiceItem.Items.Count Then '全选
                dtContractCustomer.Rows(0)("InvoiceItem") = DBNull.Value
                Me.cbbInvoiceItem.Text = Me.cklInvoiceItem.Items(0).ToString
            ElseIf Me.cklInvoiceItem.CheckedItems.Count + IIf(e.NewValue = CheckState.Checked, 1, -1) = 0 Then
                dtContractCustomer.Rows(0)("InvoiceItem") = DBNull.Value
                Me.cbbInvoiceItem.Text = ""
            Else
                Dim sInvoiceItem As String = ""

                For iItem As Integer = 1 To Me.cklInvoiceItem.Items.Count - 1
                    If (iItem = e.Index AndAlso e.NewValue = CheckState.Checked) OrElse (iItem <> e.Index AndAlso Me.cklInvoiceItem.GetItemChecked(iItem)) Then
                        sInvoiceItem = sInvoiceItem & Me.cklInvoiceItem.Items(iItem).ToString & "、"
                    End If
                Next
                sInvoiceItem = sInvoiceItem.Substring(0, sInvoiceItem.Length - 1)
                dtContractCustomer.Rows(0)("InvoiceItem") = sInvoiceItem
                Me.cbbInvoiceItem.Text = sInvoiceItem
            End If
            Me.CheckChanges()
        Else
            e.NewValue = e.CurrentValue
        End If
    End Sub

    Private Sub cklInvoiceItem_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cklInvoiceItem.Leave
        Dim controlBounds As Rectangle = Me.cbbInvoiceItem.Bounds
        controlBounds.Offset(Me.cbbInvoiceItem.Width - 17, 0)
        controlBounds.Width = 17
        If Not controlBounds.Contains(Me.tlpInvoice.PointToClient(Control.MousePosition)) Then Me.cklInvoiceItem.Visible = False : Me.cbbInvoiceItem.SelectionLength = 0
        controlBounds = Nothing
    End Sub

    Private Sub txbReason_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbFailureReason.TextChanged, txbStoppedReason.TextChanged, txbACompanyChineseName.TextChanged, cbbACompanyChineseName.TextChanged, txbACompanyEnglishName.TextChanged, txbBeneficiary.TextChanged, txbBankAccount.TextChanged, txbDomiciliation.TextChanged, _
        txbSignPlace.TextChanged, txbBNoticeWays.TextChanged, txbMinFaceValue.TextChanged, txbMaxFaceValue.TextChanged, txbTotalContractAMT.TextChanged, txbMinContractAMT.TextChanged, txbMaxContractAMT.TextChanged, txbMinAMTPerPurchase.TextChanged
        If blSkipDeal Then Return
        Me.btnSave.Enabled = True
    End Sub

    Private Sub FillContract()
        If dtDisplayedCustomer.Rows.Count > 0 Then Me.txbCustomerCode.Text = dtDisplayedCustomer.Rows(0)("CustomerCode").ToString
        Me.txbContractCode.Text = drContract("ContractCode").ToString
        If sContractID = "-1" Then
            Me.btnSave.Enabled = True : Me.btnPrint.Enabled = False
        Else
            Me.btnSave.Enabled = False : Me.btnPrint.Enabled = (drContract("ContractState") <> 5 AndAlso drContract("EndDate") >= dtToday AndAlso frmMain.dtAllowedRight.Select("RightName='ContractPrint'").Length > 0)

            If blCanValidate Then
                If blMultiCompanies AndAlso drContract("ModifierAreaID").ToString <> "0" Then '多公司合同且不是由总部人员创建
                    If frmMain.sLoginAreaID = "0" Then '总部审核人员
                        blCanModify = False
                        Me.pnlContractState.Visible = False
                        Me.pnlFirstValidate.Visible = False
                        Me.pnlValidate.Visible = False
                        Me.pnlHOValidate.Visible = True
                        If drContract("ContractState") < 2 Then
                            Me.pnlHOValidation.Enabled = False
                            Me.lblHOChineseRemarks.Text = "此合同包含多家公司，通过初次审核后，还需要通过总部的进一步审核。目前该合同还未通过初次审核，不能进行总部审核。"
                            Me.lblHOEnglishRemarks.Text = "The contract is still not pass the first level validation, so you can not validate it now."
                        Else
                            If drContract("ContractState") = 4 Then
                                Me.rdbHOOK.Checked = True
                            ElseIf drContract("ContractState") = 3 Then
                                Me.rdbHOFailure.Checked = True
                                Me.txbHOFailureReason.Text = drContract("StateReason").ToString
                            End If
                        End If
                    Else
                        Me.pnlFirstValidate.Visible = True
                        If drContract("ContractState") = 2 Then
                            Me.rdbFirstOK.Checked = True
                        ElseIf drContract("ContractState") = 1 Then
                            Me.rdbFirstFailure.Checked = True
                            Me.txbFirstFailureReason.Text = drContract("StateReason").ToString
                        End If
                    End If
                Else
                    Me.pnlContractState.Visible = False
                    Me.pnlFirstValidate.Visible = False
                    Me.pnlHOValidate.Visible = False
                    Me.pnlValidate.Visible = True
                    If drContract("ContractState") = 4 Then
                        Me.rdbOK.Checked = True
                    ElseIf drContract("ContractState") = 3 Then
                        Me.rdbFailure.Checked = True
                        Me.txbFailureReason.Text = drContract("StateReason").ToString
                    End If
                End If
                Me.pnlStop.Visible = False
            Else
                Me.pnlFirstValidate.Visible = False
                Me.pnlHOValidate.Visible = False
                Me.pnlValidate.Visible = False
                Me.pnlContractState.Visible = True
                If drContract("EndDate") >= dtToday Then
                    If drContract("ContractState") = 0 Then
                        Me.txbContratState.Text = "未审核；" & sValidationDescription & "； Not yet validated."
                    ElseIf drContract("ContractState") = 1 Then
                        Me.txbContratState.Text = "初审失败 First Validated failure."
                    ElseIf drContract("ContractState") = 2 Then
                        Me.txbContratState.Text = "初审成功，等待总部复审（多客户合同需总部复审） First Validated OK, wait HO re-validate (multi-companies contract need HO re-validate)."
                    ElseIf drContract("ContractState") = 3 Then
                        Me.txbContratState.Text = "审核失败 Validated failure."
                    ElseIf drContract("ContractState") = 5 Then
                        Me.txbContratState.Text = "已审核但已停用 Validated but already stopped."
                    ElseIf drContract("StartDate") <= dtToday Then
                        Me.txbContratState.Text = "已审核且已生效 Validated and effective."
                    Else
                        Me.txbContratState.Text = "已审核但未生效 Validated but not yet effective."
                    End If
                    Me.btnPrint.Enabled = (frmMain.dtAllowedRight.Select("RightName='ContractPrint'").Length > 0)
                Else
                    If drContract("ContractState") = 0 Then
                        Me.txbContratState.Text = "已过期（未审核） Expired and not yet validated."
                    ElseIf drContract("ContractState") = 1 Then
                        Me.txbContratState.Text = "已过期（初审失败） Expired and first validated failure."
                    ElseIf drContract("ContractState") = 2 Then
                        Me.txbContratState.Text = "'已过期（初审成功） Expired and first validated OK."
                    ElseIf drContract("ContractState") = 3 Then
                        Me.txbContratState.Text = "已过期（审核失败） Expired and validated failure"
                    Else
                        Me.txbContratState.Text = "已过期（已审核） Expired and validated"
                    End If
                End If
                If drContract("ContractState") = 1 OrElse drContract("ContractState") = 3 OrElse drContract("ContractState") = 5 Then '初审失败、复审失败或已停用
                    Me.txbContratState.Width = 299
                    Me.pnlReason.Visible = True
                    Me.txbReason.Text = drContract("StateReason").ToString
                Else
                    Me.txbContratState.Width = 610
                    Me.pnlReason.Visible = False
                End If
                Me.pnlStop.Visible = blCanStop
            End If
        End If

        With Me.cbbACompanyChineseName
            .DataSource = dtBeneficiary
            .ValueMember = "ACompanyChineseName"
            .DisplayMember = "ACompanyChineseName"
        End With
        If frmMain.sLoginAreaType = "S" Then
            Me.cbbSignPlace.Items.Add(sCityName)
        ElseIf dtContractCustomer.Rows.Count > 0 Then
            sCityID = dtContractCustomer.Select("RowID=1")(0)("CityID").ToString
            Me.cbbSignPlace.Items.Add(frmMain.dtLoginStructure.Rows.Find(sCityID)("AreaFullName").ToString.Substring(5))
        End If
        Me.txbACompanyChineseName.Text = drContract("ACompanyChineseName").ToString
        Me.txbACompanyEnglishName.Text = drContract("ACompanyEnglishName").ToString
        Me.txbBeneficiary.Text = drContract("Beneficiary").ToString
        Me.txbBankAccount.Text = drContract("BankAccount").ToString
        Me.txbDomiciliation.Text = drContract("Domiciliation").ToString
        Me.txbSignPlace.Text = drContract("SignPlace").ToString

        If blCanModify Then
            If dtBeneficiary.Rows.Count > 0 Then
                Me.cbbACompanyChineseName.Visible = True
                Me.txbACompanyChineseName.Visible = False
                Me.cbbACompanyChineseName.Text = drContract("ACompanyChineseName").ToString
            End If
            If drContract("SignPlace").ToString <> "" Then
                Me.cbbSignPlace.Visible = True
                Me.txbSignPlace.Visible = False
                Me.cbbSignPlace.Text = drContract("SignPlace").ToString
            End If
        Else
            Me.cbbACompanyChineseName.Visible = False
            Me.txbACompanyChineseName.Visible = True
            Me.txbACompanyChineseName.ReadOnly = True
            Me.txbACompanyChineseName.BackColor = SystemColors.Window
            Me.txbACompanyChineseName.BackColor = SystemColors.Control
            Me.txbACompanyEnglishName.ReadOnly = True
            Me.txbACompanyEnglishName.BackColor = SystemColors.Window
            Me.txbACompanyEnglishName.BackColor = SystemColors.Control
            Me.txbBeneficiary.ReadOnly = True
            Me.txbBeneficiary.BackColor = SystemColors.Window
            Me.txbBeneficiary.BackColor = SystemColors.Control
            Me.txbBankAccount.ReadOnly = True
            Me.txbBankAccount.BackColor = SystemColors.Window
            Me.txbBankAccount.BackColor = SystemColors.Control
            Me.txbDomiciliation.ReadOnly = True
            Me.txbDomiciliation.BackColor = SystemColors.Window
            Me.txbDomiciliation.BackColor = SystemColors.Control
            Me.cbbSignPlace.Visible = False
            Me.txbSignPlace.Visible = True
            Me.txbSignPlace.ReadOnly = True
            Me.txbSignPlace.BackColor = SystemColors.Window
            Me.txbSignPlace.BackColor = SystemColors.Control
        End If

        If sContractID = "-1" Then
            Me.pnlInputCustomer.Visible = True
            Me.btnNewCustomer.Enabled = (frmMain.dtAllowedRight.Select("RightName='CustomerCreate'").Length > 0)
        Else
            Me.dgvCustomer.BackgroundColor = SystemColors.Control
        End If
        With Me.dgvCustomer
            .DataSource = dtDisplayedCustomer
            .Columns(0).Visible = False
            .Columns(1).Visible = False
            Dim linkColumn As New DataGridViewLinkColumn()
            linkColumn.DataPropertyName = "CustomerCode"
            .Columns.RemoveAt(2)
            .Columns.Insert(2, linkColumn)
            With .Columns(2) '客户代码
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(3) '客户名称
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .DefaultCellStyle.Padding = New Padding(2)
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(4) '是否已终止
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.ForeColor = Color.Red
                .DefaultCellStyle.SelectionForeColor = Color.Red
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(5) '主公司
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(6) '错误
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.ForeColor = Color.Red
                .DefaultCellStyle.SelectionForeColor = Color.Red
                .Resizable = DataGridViewTriState.False
            End With
            Dim buttonColumn As New DataGridViewButtonColumn
            With buttonColumn
                .DataPropertyName = "Delete"
                .DefaultCellStyle.ForeColor = SystemColors.ControlText
                .DefaultCellStyle.SelectionForeColor = SystemColors.ControlText
                .DefaultCellStyle.BackColor = SystemColors.Control
                .DefaultCellStyle.SelectionBackColor = SystemColors.Control
                .DefaultCellStyle.Padding = New Padding(1)
            End With
            .Columns.RemoveAt(7)
            .Columns.Insert(7, buttonColumn)
            With .Columns(7) '删除按钮
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.BackColor = SystemColors.Window
                .DefaultCellStyle.SelectionBackColor = SystemColors.Highlight
                .Resizable = DataGridViewTriState.False
            End With
            .Columns(8).Visible = False

            For Each column As DataGridViewColumn In .Columns()
                column.Name = dtDisplayedCustomer.Columns(column.Index).ColumnName
            Next

            If .RowCount > 0 Then .Rows(0).Selected = False
        End With
        Me.txbBNoticeWays.Text = drContract("BNoticeWays").ToString
        If blCanModify Then
            Me.txbBNoticeWays.ReadOnly = False
            Me.txbBNoticeWays.BackColor = SystemColors.Window
        Else
            Me.txbBNoticeWays.ReadOnly = True
            Me.txbBNoticeWays.BackColor = SystemColors.Window
            Me.txbBNoticeWays.BackColor = SystemColors.Control
        End If
        Me.ResetCustomerLayout()

        Me.dtpStartDate.Value = drContract("StartDate")
        Me.txbStartDate.Text = Format(drContract("StartDate"), "yyyy\/MM\/dd") : Me.txbStartDateStopped.Text = Me.txbStartDate.Text
        Me.dtpEndDate.Value = drContract("EndDate")
        Me.txbEndDate.Text = Format(drContract("EndDate"), "yyyy\/MM\/dd") : Me.txbEndDateStopped.Text = Me.txbEndDate.Text
        If drContract("StoppedDate").ToString <> "" Then Me.txbStoppedDate.Text = Format(drContract("StoppedDate"), "yyyy\/MM\/dd")
        If blCanModify Then
            Me.txbStartDate.Visible = False
            Me.dtpStartDate.Visible = True
            Me.txbEndDate.Visible = False
            Me.dtpEndDate.Visible = True
        Else
            Me.txbStartDate.Visible = True
            Me.dtpStartDate.Visible = False
            Me.txbEndDate.Visible = True
            Me.dtpEndDate.Visible = False
        End If
        Me.pnlStoppedPeriod.Visible = (drContract("ContractState") = 5)

        If drContract("MinFaceValue").ToString <> "" Then Me.txbMinFaceValue.Text = Format(drContract("MinFaceValue"), "#,0.00")
        If drContract("MaxFaceValue").ToString <> "" Then Me.txbMaxFaceValue.Text = Format(drContract("MaxFaceValue"), "#,0.00")
        If blCanModify Then
            Me.txbMinFaceValue.ReadOnly = False
            Me.txbMinFaceValue.BackColor = SystemColors.Window
            Me.txbMaxFaceValue.ReadOnly = False
            Me.txbMaxFaceValue.BackColor = SystemColors.Window
        Else
            Me.txbMinFaceValue.ReadOnly = True
            Me.txbMinFaceValue.BackColor = SystemColors.Window
            Me.txbMinFaceValue.BackColor = SystemColors.Control
            Me.txbMaxFaceValue.ReadOnly = True
            Me.txbMaxFaceValue.BackColor = SystemColors.Window
            Me.txbMaxFaceValue.BackColor = SystemColors.Control
        End If

        If drContract("TotalContractAMT").ToString <> "" Then Me.txbTotalContractAMT.Text = Format(drContract("TotalContractAMT"), "#,0.00")
        If drContract("MinContractAMT").ToString <> "" Then Me.txbMinContractAMT.Text = Format(drContract("MinContractAMT"), "#,0.00")
        If drContract("MaxContractAMT").ToString <> "" Then Me.txbMaxContractAMT.Text = Format(drContract("MaxContractAMT"), "#,0.00")
        If drContract("MinAMTPerPurchase").ToString <> "" Then Me.txbMinAMTPerPurchase.Text = Format(drContract("MinAMTPerPurchase"), "#,0.00")
        If blCanModify Then
            Me.txbTotalContractAMT.ReadOnly = False
            Me.txbTotalContractAMT.BackColor = SystemColors.Window
            Me.txbMinContractAMT.ReadOnly = False
            Me.txbMinContractAMT.BackColor = SystemColors.Window
            Me.txbMaxContractAMT.ReadOnly = False
            Me.txbMaxContractAMT.BackColor = SystemColors.Window
            Me.txbMinAMTPerPurchase.ReadOnly = False
            Me.txbMinAMTPerPurchase.BackColor = SystemColors.Window
        Else
            Me.txbTotalContractAMT.ReadOnly = True
            Me.txbTotalContractAMT.BackColor = SystemColors.Window
            Me.txbTotalContractAMT.BackColor = SystemColors.Control
            Me.txbMinContractAMT.ReadOnly = True
            Me.txbMinContractAMT.BackColor = SystemColors.Window
            Me.txbMinContractAMT.BackColor = SystemColors.Control
            Me.txbMaxContractAMT.ReadOnly = True
            Me.txbMaxContractAMT.BackColor = SystemColors.Window
            Me.txbMaxContractAMT.BackColor = SystemColors.Control
            Me.txbMinAMTPerPurchase.ReadOnly = True
            Me.txbMinAMTPerPurchase.BackColor = SystemColors.Window
            Me.txbMinAMTPerPurchase.BackColor = SystemColors.Control
        End If

        If drContract("PaymentMode") = 0 Then
            Me.rdbAddition.Checked = True
            Me.rdbDeduction.Enabled = blCanModify
        Else
            Me.rdbDeduction.Checked = True
            Me.rdbAddition.Enabled = blCanModify
        End If

        If drContract("CalculationMode") = 0 Then
            Me.rdbCalculationByTotal.Checked = True
            Me.rdbCalculationBySection.Enabled = blCanModify
        Else
            Me.rdbCalculationBySection.Checked = True
            Me.rdbCalculationByTotal.Enabled = blCanModify
        End If

        Me.txbAppointedDate.Text = Format(drContract("AppointedDate"), "yyyy\/MM\/dd")
        Me.dtpAppointedDate.Value = drContract("AppointedDate")
        Select Case drContract("CalculationDay")
            Case 0
                Me.rdbEndOfContract.Checked = True
                'Me.txbAppointedDate.Visible = (Not blCanModify)
                'Me.dtpAppointedDate.Visible = blCanModify
                Me.rdbMonthly.Enabled = blCanModify
                Me.rdbEachPurchase.Enabled = blCanModify
            Case 255
                Me.rdbEachPurchase.Checked = True
                Me.rdbEndOfContract.Enabled = blCanModify
                Me.rdbMonthly.Enabled = blCanModify
            Case Else
                Me.rdbMonthly.Checked = True
                Me.txbCalculationDay.Text = drContract("CalculationDay")
                Me.nudCalculationDay.Value = drContract("CalculationDay")
                Me.txbCalculationDay.Visible = (Not blCanModify)
                Me.nudCalculationDay.Visible = blCanModify
                Me.rdbEndOfContract.Enabled = blCanModify
                Me.rdbEachPurchase.Enabled = blCanModify
        End Select

        With Me.dgvDetails
            .DataSource = dtContractDetails
            .Columns(0).Visible = False
            With .Columns(1)
                .HeaderText = "No."
                .Width = 40
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.ForeColor = SystemColors.ControlText
                .DefaultCellStyle.BackColor = SystemColors.Control
                .DefaultCellStyle.SelectionForeColor = SystemColors.ControlText
                .DefaultCellStyle.SelectionBackColor = SystemColors.Control
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ReadOnly = True
            End With
            With .Columns(2)
                .HeaderText = "最小金额 Min AMT(＞)"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,0.00"
                If sContractID = "-1" OrElse blCanModify Then .ToolTipText = "由系统自动设置，不必手工输入。"
                .ReadOnly = True
            End With
            With .Columns(3)
                .HeaderText = "最大金额 Max AMT(≤)"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,0.00"
                If sContractID = "-1" OrElse blCanModify Then .ToolTipText = "请在最后一行保留空白（没有上限）"
            End With
            With .Columns(4)
                .HeaderText = "返点 Disc %"
                .Width = 80
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'modify code 038:start-------------------------------------------------------------------------
                '.DefaultCellStyle.Format = "#,0.0"
                .DefaultCellStyle.Format = "#,0.00"
                'modify code 038:start-------------------------------------------------------------------------
            End With
            .ReadOnly = (Not blCanModify)
            If blCanModify Then
                .EditMode = DataGridViewEditMode.EditOnEnter
                .BackgroundColor = SystemColors.Window
            Else
                .EditMode = DataGridViewEditMode.EditProgrammatically
                .BackgroundColor = SystemColors.Control
            End If

            .Rows(0).Selected = False
        End With
        Me.btnCompare.Enabled = (dtDisplayedCustomer.Rows.Count > 0 AndAlso frmMain.dtAllowedRight.Select("RightName='CityConfigBrowse'").Length > 0)
        Me.ResetDetialsLayout()

        With Me.cbbAppointedStore
            .DataSource = dtStore
            .ValueMember = "StoreID"
            .DisplayMember = "StoreFullName"
            If drContract("AppointedStoreID").ToString <> "" Then .SelectedValue = drContract("AppointedStoreID")
        End With
        If drContract("AppointedStoreID").ToString = "" Then
            Me.rdbAllStores.Checked = True
            Me.txbAppointedStore.Text = ""
        Else
            Me.rdbAppointedStore.Checked = True
            Me.txbAppointedStore.Text = Me.cbbAppointedStore.Text
        End If
        If blCanModify Then
            Me.rdbAllStores.Enabled = True
            Me.rdbAppointedStore.Enabled = True
            Me.cbbAppointedStore.Visible = Me.rdbAppointedStore.Checked
            Me.txbAppointedStore.Visible = Not Me.rdbAppointedStore.Checked
        Else
            Me.rdbAllStores.Enabled = Me.rdbAllStores.Checked
            Me.rdbAppointedStore.Enabled = Me.rdbAppointedStore.Checked
            Me.cbbAppointedStore.Visible = False
            Me.txbAppointedStore.Visible = True
        End If

        With Me.cklInvoiceTitle.Items
            .Clear()
            For Each joinedCustomer As DataRow In dtContractCustomer.Select("", "RowID")
                .Add(joinedCustomer("CustomerChineseName").ToString, joinedCustomer("CustomerID").ToString = joinedCustomer("InvoiceTitleCustomerID").ToString)
            Next
        End With

        dvInvoiceItem.RowFilter = "CityID=" & sCityID
        With Me.cklInvoiceItem.Items
            .Clear()
            .Add("（任何符合家乐福税务政策的发票品项）")
            For Each drItem As DataRowView In dvInvoiceItem
                .Add(drItem("Content").ToString)
            Next
        End With
        Dim sInvoiceItems As String = ""
        If dtContractCustomer.Rows.Count > 0 Then sInvoiceItems = dtContractCustomer.Rows(0)("InvoiceItem").ToString
        If sInvoiceItems = "" Then
            Me.cbbInvoiceItem.Text = "（任何符合家乐福税务政策的发票品项）"
            For iItem As Integer = 0 To Me.cklInvoiceItem.Items.Count - 1
                Me.cklInvoiceItem.SetItemChecked(iItem, True)
            Next
        Else
            Me.cbbInvoiceItem.Text = sInvoiceItems
            Dim saInvoiceItems() As String = sInvoiceItems.ToString.Split("、")
            For iItem As Integer = 0 To saInvoiceItems.Length - 1
                If Me.cklInvoiceItem.Items.IndexOf(saInvoiceItems(iItem)) > -1 Then
                    Me.cklInvoiceItem.SetItemChecked(Me.cklInvoiceItem.Items.IndexOf(saInvoiceItems(iItem)), True)
                End If
            Next
        End If
        Me.ResetInvoiceLayout()

        If blCanModify Then
            Me.cklInvoiceTitle.BackColor = SystemColors.Window
            Me.cbbInvoiceItem.BackColor = SystemColors.Window
            Me.cklInvoiceItem.BackColor = SystemColors.Window
        Else
            Me.cklInvoiceTitle.BackColor = SystemColors.Control
            Me.cbbInvoiceItem.BackColor = SystemColors.Control
            Me.cklInvoiceItem.BackColor = SystemColors.Control
        End If
        Me.cklInvoiceTitle.CheckOnClick = False
        Me.cklInvoiceItem.CheckOnClick = blCanModify

        If sContractID = "-1" Then
            Me.grbOperation.Visible = False
            Me.grbInvoice.Margin = New Padding(12, 0, 8, 10)
        Else
            Me.grbOperation.Visible = True
            Me.lblCreator.Text = drContract("CreatorName").ToString
            If IsDate(drContract("CreatedTime").ToString) Then Me.lblCreatedTime.Text = Format(drContract("CreatedTime"), "yyyy\/MM\/dd HH:mm:ss")
            If drContract("ModifierName").ToString = "" Then
                Me.pnlModifyInfo.Visible = False
            Else
                Me.pnlModifyInfo.Visible = True
                Me.lblModifier.Text = drContract("ModifierName").ToString
                If IsDate(drContract("ModifiedTime").ToString) Then Me.lblModifiedTime.Text = Format(drContract("ModifiedTime"), "yyyy\/MM\/dd HH:mm:ss")
            End If
            If drContract("FirstAuditorName").ToString = "" Then
                Me.pnlFirstValidateInfo.Visible = False
            Else
                Me.pnlFirstValidateInfo.Visible = True
                Me.lblFirstAuditor.Text = drContract("FirstAuditorName").ToString
                If IsDate(drContract("FirstValidatedTime").ToString) Then Me.lblFirstValidatedTime.Text = Format(drContract("FirstValidatedTime"), "yyyy\/MM\/dd HH:mm:ss")
            End If
            If drContract("AuditorName").ToString = "" Then
                Me.pnlValidateTitle.Visible = False
                Me.pnlValidateInfo.Visible = False
            Else
                Me.pnlValidateTitle.Visible = (drContract("FirstAuditorName").ToString <> "")
                Me.pnlValidateInfo.Visible = True
                Me.lblAuditor.Text = drContract("AuditorName").ToString
                If IsDate(drContract("ValidatedTime").ToString) Then Me.lblValidatedTime.Text = Format(drContract("ValidatedTime"), "yyyy\/MM\/dd HH:mm:ss")
            End If
            If drContract("StopperName").ToString = "" Then
                Me.pnlStopInfo.Visible = False
            Else
                Me.pnlStopInfo.Visible = True
                Me.lblStopper.Text = drContract("StopperName").ToString
                If IsDate(drContract("StoppedTime").ToString) Then Me.lblStoppedTime.Text = Format(drContract("StoppedTime"), "yyyy\/MM\/dd HH:mm:ss")
            End If
            Me.grbOperation.Height = Me.tlpOperation.Height + 32

            If frmContractManagement.IsHandleCreated Then
                Dim contractRow As DataRow = frmContractManagement.dvContract.Table.Rows.Find(sContractID)
                sCityID = dtContractCustomer.Rows(0)("CityID").ToString
                contractRow("CustomerName") = (dtContractCustomer.Rows(0)("CustomerChineseName").ToString & " " & dtContractCustomer.Rows(0)("CustomerEnglishName").ToString).Trim
                If frmMain.sLoginAreaType = "S" Then
                    contractRow("CityNameBelongs") = sCityName
                Else
                    contractRow("CityNameBelongs") = frmMain.dtLoginStructure.Rows.Find(sCityID)("AreaFullName").ToString.Substring(5)
                End If
                contractRow("StartDate") = drContract("StartDate")
                contractRow("EndDate") = drContract("EndDate")
                contractRow("StoppedDate") = drContract("StoppedDate")
                If drContract("StoppedDate").ToString = "" Then
                    contractRow("ContractDays") = DateDiff(DateInterval.Day, drContract("StartDate"), drContract("EndDate")) + 1
                Else
                    contractRow("ContractDays") = DateDiff(DateInterval.Day, drContract("StartDate"), drContract("StoppedDate")) + 1
                End If
                contractRow("MaxRebateRate") = drContract("MaxRebateRate") * 100
                contractRow("CalculationMode") = IIf(drContract("CalculationMode") = 0, "按购物总额 by Total Purchase", "按分段金额 by Section of Purchase")
                contractRow("PaymentMode") = IIf(drContract("PaymentMode") = 0, "赠送返点 Addition", "付款抵扣 Deduction")
                If drContract("EndDate") >= dtToday Then
                    If drContract("ContractState") = 0 Then
                        contractRow("ContractStateDescription") = "未审核 Not yet validated"
                    ElseIf drContract("ContractState") = 1 Then
                        contractRow("ContractStateDescription") = "初审失败 First Validated failure"
                    ElseIf drContract("ContractState") = 2 Then
                        contractRow("ContractStateDescription") = "初审成功 First Validated OK"
                    ElseIf drContract("ContractState") = 3 Then
                        contractRow("ContractStateDescription") = "审核失败 Validated failure"
                    ElseIf drContract("ContractState") = 5 Then
                        contractRow("ContractStateDescription") = "已审核但已停用 Validated but already stopped"
                    ElseIf drContract("StartDate") <= dtToday Then
                        contractRow("ContractStateDescription") = "已审核且已生效 Validated and effective"
                    Else
                        contractRow("ContractStateDescription") = "已审核但未生效 Validated but not yet effective"
                    End If
                Else
                    If drContract("ContractState") = 0 Then
                        contractRow("ContractStateDescription") = "已过期（未审核） Expired and not yet validated"
                    ElseIf drContract("ContractState") = 1 Then
                        contractRow("ContractStateDescription") = "已过期（初审失败） Expired and first validated failure"
                    ElseIf drContract("ContractState") = 2 Then
                        contractRow("ContractStateDescription") = "已过期（初审成功） Expired and first validated OK"
                    ElseIf drContract("ContractState") = 3 Then
                        contractRow("ContractStateDescription") = "已过期（审核失败） Expired and validated failure"
                    Else
                        contractRow("ContractStateDescription") = "已过期（已审核） Expired and validated"
                    End If
                End If
                contractRow("ContractState") = drContract("ContractState")
                contractRow.EndEdit() : contractRow.AcceptChanges()
                contractRow = Nothing
            End If
        End If
    End Sub

    Private Sub ResetControls()
        If blCanModify Then
            If dtBeneficiary.Rows.Count > 0 Then
                Me.cbbACompanyChineseName.Visible = True
                Me.txbACompanyChineseName.Visible = False
            Else
                Me.cbbACompanyChineseName.Visible = False
                Me.txbACompanyChineseName.ReadOnly = False
                Me.txbACompanyChineseName.BackColor = SystemColors.Window
                Me.txbACompanyChineseName.Visible = True
            End If
            Me.txbACompanyEnglishName.ReadOnly = False
            Me.txbACompanyEnglishName.BackColor = SystemColors.Window
            Me.txbBeneficiary.ReadOnly = False
            Me.txbBeneficiary.BackColor = SystemColors.Window
            Me.txbBankAccount.ReadOnly = False
            Me.txbBankAccount.BackColor = SystemColors.Window
            Me.txbDomiciliation.ReadOnly = False
            Me.txbDomiciliation.BackColor = SystemColors.Window
            If dtContractCustomer.Rows.Count > 0 Then
                Me.cbbSignPlace.Visible = True
                Me.txbSignPlace.Visible = False
            Else
                Me.cbbSignPlace.Visible = False
                Me.txbSignPlace.Visible = True
                Me.txbSignPlace.ReadOnly = False
                Me.txbSignPlace.BackColor = SystemColors.Window
            End If

            Me.txbBNoticeWays.ReadOnly = False
            Me.txbBNoticeWays.BackColor = SystemColors.Window

            Me.dtpStartDate.Visible = True
            Me.txbStartDate.Visible = False
            Me.dtpEndDate.Visible = True
            Me.txbEndDate.Visible = False

            Me.txbMinFaceValue.ReadOnly = False
            Me.txbMinFaceValue.BackColor = SystemColors.Window
            Me.txbMaxFaceValue.ReadOnly = False
            Me.txbMaxFaceValue.BackColor = SystemColors.Window

            Me.txbTotalContractAMT.ReadOnly = False
            Me.txbTotalContractAMT.BackColor = SystemColors.Window
            Me.txbMinContractAMT.ReadOnly = False
            Me.txbMinContractAMT.BackColor = SystemColors.Window
            Me.txbMaxContractAMT.ReadOnly = False
            Me.txbMaxContractAMT.BackColor = SystemColors.Window
            Me.txbMinAMTPerPurchase.ReadOnly = False
            Me.txbMinAMTPerPurchase.BackColor = SystemColors.Window

            Me.rdbAddition.Enabled = True
            Me.rdbDeduction.Enabled = True

            Me.rdbCalculationByTotal.Enabled = True
            Me.rdbCalculationBySection.Enabled = True

            Me.rdbEndOfContract.Enabled = Me.rdbAddition.Checked
            'Me.dtpAppointedDate.Visible = True
            'Me.txbAppointedDate.Visible = False
            Me.rdbMonthly.Enabled = Me.rdbAddition.Checked
            Me.nudCalculationDay.Visible = True
            Me.txbCalculationDay.Visible = False
            Me.rdbEachPurchase.Enabled = True

            Me.dgvDetails.ReadOnly = False
            Me.dgvDetails.Columns(1).ReadOnly = True
            Me.dgvDetails.Columns(2).ReadOnly = True
            Me.dgvDetails.Columns("StartSalesAMT").ToolTipText = "由系统自动设置，不必手工输入。"
            Me.dgvDetails.Columns("EndSalesAMT").ToolTipText = "请在最后一行保留空白（没有上限）"
            Me.dgvDetails.EditMode = DataGridViewEditMode.EditOnEnter
            Me.dgvDetails.Refresh()

            Me.rdbAllStores.Enabled = True
            Me.rdbAppointedStore.Enabled = True
            If Me.rdbAppointedStore.Checked Then
                Me.cbbAppointedStore.Visible = True
                Me.txbAppointedStore.Visible = False
            End If

            Me.cklInvoiceTitle.BackColor = SystemColors.Window
            Me.cbbInvoiceItem.BackColor = SystemColors.Window
            Me.cklInvoiceItem.BackColor = SystemColors.Window
            Me.cklInvoiceItem.CheckOnClick = True
        Else
            Me.cbbACompanyChineseName.Visible = False
            Me.txbACompanyChineseName.Visible = True
            Me.txbACompanyChineseName.ReadOnly = True
            Me.txbACompanyChineseName.BackColor = SystemColors.Window
            Me.txbACompanyChineseName.BackColor = SystemColors.Control
            Me.txbACompanyEnglishName.ReadOnly = True
            Me.txbACompanyEnglishName.BackColor = SystemColors.Window
            Me.txbACompanyEnglishName.BackColor = SystemColors.Control
            Me.txbBeneficiary.ReadOnly = True
            Me.txbBeneficiary.BackColor = SystemColors.Window
            Me.txbBeneficiary.BackColor = SystemColors.Control
            Me.txbBankAccount.ReadOnly = True
            Me.txbBankAccount.BackColor = SystemColors.Window
            Me.txbBankAccount.BackColor = SystemColors.Control
            Me.txbDomiciliation.ReadOnly = True
            Me.txbDomiciliation.BackColor = SystemColors.Window
            Me.txbDomiciliation.BackColor = SystemColors.Control
            Me.cbbSignPlace.Visible = False
            Me.txbSignPlace.Visible = True
            Me.txbSignPlace.ReadOnly = True
            Me.txbSignPlace.BackColor = SystemColors.Window
            Me.txbSignPlace.BackColor = SystemColors.Control

            Me.txbBNoticeWays.ReadOnly = True
            Me.txbBNoticeWays.BackColor = SystemColors.Window
            Me.txbBNoticeWays.BackColor = SystemColors.Control

            If blCanStop Then
                Me.dtpStartDate.Visible = True
                Me.txbStartDate.Visible = False
                Me.dtpEndDate.Visible = True
                Me.txbEndDate.Visible = False
            Else
                Me.dtpStartDate.Visible = False
                Me.txbStartDate.Visible = True
                Me.dtpEndDate.Visible = False
                Me.txbEndDate.Visible = True
            End If

            Me.txbMinFaceValue.ReadOnly = True
            Me.txbMinFaceValue.BackColor = SystemColors.Window
            Me.txbMinFaceValue.BackColor = SystemColors.Control
            Me.txbMaxFaceValue.ReadOnly = True
            Me.txbMaxFaceValue.BackColor = SystemColors.Window
            Me.txbMaxFaceValue.BackColor = SystemColors.Control

            Me.txbTotalContractAMT.ReadOnly = True
            Me.txbTotalContractAMT.BackColor = SystemColors.Window
            Me.txbTotalContractAMT.BackColor = SystemColors.Control
            Me.txbMinContractAMT.ReadOnly = True
            Me.txbMinContractAMT.BackColor = SystemColors.Window
            Me.txbMinContractAMT.BackColor = SystemColors.Control
            Me.txbMaxContractAMT.ReadOnly = True
            Me.txbMaxContractAMT.BackColor = SystemColors.Window
            Me.txbMaxContractAMT.BackColor = SystemColors.Control
            Me.txbMinAMTPerPurchase.ReadOnly = True
            Me.txbMinAMTPerPurchase.BackColor = SystemColors.Window
            Me.txbMinAMTPerPurchase.BackColor = SystemColors.Control

            Me.rdbAddition.Enabled = Me.rdbAddition.Checked
            Me.rdbDeduction.Enabled = Me.rdbDeduction.Checked

            Me.rdbCalculationByTotal.Enabled = Me.rdbCalculationByTotal.Checked
            Me.rdbCalculationBySection.Enabled = Me.rdbCalculationBySection.Checked

            Me.rdbEndOfContract.Enabled = Me.rdbEndOfContract.Checked
            'If Me.rdbEndOfContract.Checked Then
            '    Me.dtpAppointedDate.Visible = False
            '    Me.txbAppointedDate.Visible = True
            'End If
            Me.rdbMonthly.Enabled = Me.rdbMonthly.Checked
            If Me.rdbMonthly.Checked Then
                Me.nudCalculationDay.Visible = False
                Me.txbCalculationDay.Visible = True
            End If
            Me.rdbEachPurchase.Enabled = Me.rdbEachPurchase.Checked

            Me.dgvDetails.ReadOnly = True
            Me.dgvDetails.Columns("StartSalesAMT").ToolTipText = ""
            Me.dgvDetails.Columns("EndSalesAMT").ToolTipText = ""
            Me.dgvDetails.EditMode = DataGridViewEditMode.EditProgrammatically
            Me.dgvDetails.Refresh()

            Me.rdbAllStores.Enabled = Me.rdbAllStores.Checked
            Me.rdbAppointedStore.Enabled = Me.rdbAppointedStore.Checked
            Me.cbbAppointedStore.Visible = False
            Me.txbAppointedStore.Visible = True

            Me.cklInvoiceTitle.BackColor = SystemColors.Window
            Me.cklInvoiceTitle.BackColor = SystemColors.Control
            Me.cbbInvoiceItem.BackColor = SystemColors.Control
            Me.cklInvoiceItem.BackColor = SystemColors.Control
            Me.cklInvoiceItem.CheckOnClick = False
        End If
    End Sub

    Private Sub ResetCustomerLayout()
        With Me.dgvCustomer
            With .Columns("Stopped") '是否已终止
                If dtDisplayedCustomer.Select("Isnull(Stopped,'')<>''").Length = 0 Then
                    .Visible = False
                Else
                    .Visible = True
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End If
            End With
            With .Columns("IsMain") '主公司
                If dtDisplayedCustomer.Rows.Count < 2 Then
                    .Visible = False
                Else
                    .Visible = True
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End If
            End With
            With .Columns("Error") '错误
                If dtDisplayedCustomer.Select("Isnull(Error,'')<>''").Length = 0 Then
                    .Visible = False
                Else
                    .Visible = True
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End If
            End With
            With .Columns("Delete") '删除按钮
                If sContractID = "-1" Then
                    .Visible = True
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Else
                    .Visible = False
                End If
            End With
        End With
        Me.tlpSetMainCompany.Visible = (sContractID = "-1" AndAlso dtDisplayedCustomer.Rows.Count > 1)

        Dim iGridHeight As Integer = 0
        For Each customerRow As DataGridViewRow In Me.dgvCustomer.Rows()
            If customerRow.Cells("IsBoth").Value Then
                customerRow.Height = 32
                customerRow.Cells("CustomerCode").Style.Padding = New Padding(1, 3, 1, 0)
                If Me.dgvCustomer.Columns("Delete").Visible = True Then customerRow.Cells("Delete").Style.Padding = New Padding(1, 5, 1, 5)
            Else
                customerRow.Height = 24
                customerRow.Cells("CustomerCode").Style.Padding = New Padding(1, 4, 1, 0)
                If Me.dgvCustomer.Columns("Delete").Visible = True Then customerRow.Cells("Delete").Style.Padding = New Padding(1)
            End If
            iGridHeight += customerRow.Height
        Next
        If iGridHeight = 0 Then iGridHeight = 24
        iGridHeight += IIf(ToolStripManager.VisualStylesEnabled, 2, 4)
        Me.pnlCustomer.Height = iGridHeight + 6
        Me.grbPartyB.Height = Me.flpCustomer.Height + 26
    End Sub

    Private Sub ResetDetialsLayout()
        Me.grbDetails.Height = (IIf(Me.dgvDetails.RowCount < 3, 3, Me.dgvDetails.RowCount) + 1) * 24 + IIf(ToolStripManager.VisualStylesEnabled, 0, 2) + 37
    End Sub

    Private Sub ResetInvoiceLayout()
        Me.cklInvoiceTitle.Height = (IIf(Me.cklInvoiceTitle.Items.Count = 0, 1, Me.cklInvoiceTitle.Items.Count) * 16) + 4
        Me.grbInvoice.Height = Me.tlpInvoice.Height + 36
    End Sub

    Private Sub AfterOpenCustomer(ByVal sOpenedCustomerID As String, ByVal openedCustomer As DataRow)
        blSkipDeal = True
        frmMain.statusText.Text = "就绪。"

        If sOpenedCustomerID = "" Then
            sOpenedCustomerID = openedCustomer("CustomerID").ToString
            If frmCustomerManagement.IsHandleCreated Then
                Try
                    frmCustomerManagement.dvCustomer.Table.Rows.Find(sOpenedCustomerID).Delete()
                Catch
                End Try
            End If
            If sContractID = "-1" Then
                MessageBox.Show("当前客户已经不存在（可能被删除或移位）！    ", "当前客户已经不存在！", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                If dtDropdownCustomer IsNot Nothing AndAlso dtDropdownCustomer.Select("CustomerID=" & sOpenedCustomerID).Length > 0 Then
                    dtDropdownCustomer.Select("CustomerID=" & sOpenedCustomerID)(0).Delete()
                    dtDropdownCustomer.AcceptChanges()
                End If

                If sOpenedCustomerID = sCustomerID Then
                    sCustomerID = "" : drCustomer = Nothing
                    Me.btnViewCustomer.Enabled = False : Me.btnJoin.Enabled = False
                    Me.cbbCustomerName.Visible = False
                    Me.txbCustomerName.Visible = True

                    If frmMain.dtAllowedRight.Select("RightName='CustomerCreate'").Length = 0 Then
                        sCustomerPrompt = "找不到该客户，请输入其他的公司名称。"
                    Else
                        sCustomerPrompt = "找不到该客户，请先创建该客户或输入其他的公司名称。"
                    End If
                End If

                If dtDisplayedCustomer.Select("CustomerID=" & sOpenedCustomerID).Length > 0 Then
                    Dim displayedCustomer As DataRow = dtDisplayedCustomer.Select("CustomerID=" & sOpenedCustomerID)(0)
                    displayedCustomer("Error") = " (Error!) "
                    Me.dgvCustomer("Error", displayedCustomer("RowID") - 1).ToolTipText = "客户不存在！"
                    Me.ResetCustomerLayout()
                End If
            End If
        Else
            If dtDropdownCustomer IsNot Nothing AndAlso dtDropdownCustomer.Select("CustomerID=" & sOpenedCustomerID).Length > 0 Then
                dtDropdownCustomer.Select("CustomerID=" & sOpenedCustomerID)(0)("CustomerName") = openedCustomer("CustomerChineseName").ToString & IIf(openedCustomer("Stopped"), " （已停止使用）", "")
                dtDropdownCustomer.AcceptChanges()
            End If

            If sOpenedCustomerID = sCustomerID Then
                Me.txbCustomerName.Text = openedCustomer("CustomerChineseName").ToString & IIf(openedCustomer("Stopped"), " （已停止使用）", "")
                Me.cbbCustomerName.Text = Me.txbCustomerName.Text

                If Me.btnJoin.Enabled Then
                    If openedCustomer("Stopped") Then
                        sCustomerPrompt = "您选择的客户已被停止使用，请输入其他的公司名称。"
                    ElseIf drCustomer("InvalidContractID").ToString <> "" Then
                        sCustomerPrompt = "您选择的客户存在未生效合同，请输入其他的公司名称。"
                    ElseIf dtContractCustomer.Rows.Count > 0 AndAlso Me.CheckPeriodOverlap(openedCustomer) Then
                        sCustomerPrompt = "您选择的客户存在与当前合同的合同期重叠且已审核的合同，请输入其他的公司名称。"
                    End If
                ElseIf dtContractCustomer.Select("CustomerID=" & sOpenedCustomerID).Length = 0 Then
                    Me.btnJoin.Enabled = True
                    sCustomerPrompt = "提示：请按右边的""Join""按钮将此客户添加到乙方公司列表中。"
                End If
            End If

            If dtContractCustomer.Select("CustomerID=" & sOpenedCustomerID).Length > 0 Then
                Dim joinedCustomer As DataRow = dtContractCustomer.Select("CustomerID=" & sOpenedCustomerID)(0), displayedCustomer As DataRow = dtDisplayedCustomer.Select("CustomerID=" & sOpenedCustomerID)(0)
                Dim sOldCityID As String = joinedCustomer("CityID").ToString, sOldLastValidContractID As String = joinedCustomer("LastValidContractID").ToString
                joinedCustomer("CustomerCode") = openedCustomer("StoreCode").ToString & openedCustomer("CustomerCode").ToString
                joinedCustomer("CustomerChineseName") = openedCustomer("CustomerChineseName").ToString
                joinedCustomer("CustomerEnglishName") = openedCustomer("CustomerEnglishName").ToString
                joinedCustomer("Stopped") = openedCustomer("Stopped")
                If openedCustomer("LastValidContractID").ToString = "" Then
                    joinedCustomer("LastValidContractID") = -1
                Else
                    joinedCustomer("LastValidContractID") = openedCustomer("LastValidContractID")
                    joinedCustomer("LastValidContractCode") = openedCustomer("LastValidContractCode").ToString
                    joinedCustomer("LastValidContractStartDate") = openedCustomer("LastValidContractStartDate")
                    joinedCustomer("LastValidContractEndDate") = openedCustomer("LastValidContractEndDate")
                End If
                joinedCustomer.EndEdit()
                If joinedCustomer.RowState = DataRowState.Modified Then joinedCustomer.AcceptChanges()

                displayedCustomer("CustomerCode") = joinedCustomer("CustomerCode").ToString
                If joinedCustomer("CustomerChineseName").ToString <> "" AndAlso joinedCustomer("CustomerEnglishName").ToString <> "" Then
                    displayedCustomer("CustomerName") = joinedCustomer("CustomerChineseName").ToString & Chr(13) & joinedCustomer("CustomerEnglishName").ToString
                    displayedCustomer("IsBoth") = 1
                Else
                    displayedCustomer("CustomerName") = joinedCustomer("CustomerChineseName").ToString & joinedCustomer("CustomerEnglishName").ToString
                    displayedCustomer("IsBoth") = 0
                End If
                displayedCustomer.EndEdit() : displayedCustomer.AcceptChanges()

                Me.cklInvoiceTitle.Items(displayedCustomer("RowID") - 1) = joinedCustomer("CustomerChineseName").ToString

                If sContractID = "-1" Then
                    displayedCustomer("Error") = DBNull.Value
                    If openedCustomer("Stopped") Then
                        displayedCustomer("Error") = " (Error!) "
                        Me.dgvCustomer("Error", displayedCustomer("RowID") - 1).ToolTipText = "客户已被停止使用！" & IIf(openedCustomer("StoppedReason").ToString = "", "", "停用原因：" & Chr(13) & openedCustomer("StoppedReason").ToString)
                    ElseIf openedCustomer("InvalidContractID").ToString <> "" Then
                        displayedCustomer("Error") = " (Error!) "
                        Me.dgvCustomer("Error", displayedCustomer("RowID") - 1).ToolTipText = "客户存在未生效合同！" & Chr(13) & "合同号： " & openedCustomer("InvalidContractCode").ToString & " （未生效）    " & Chr(13) & "合同期： " & openedCustomer("InvalidContractPeriod").ToString
                    ElseIf joinedCustomer("RowID") <> 1 AndAlso Me.CheckPeriodOverlap(openedCustomer) Then
                        displayedCustomer("Error") = " (Error!) "
                        Me.dgvCustomer("Error", displayedCustomer("RowID") - 1).ToolTipText = "客户存在合同期重叠且已审核的合同！" & Chr(13) & "合同号： " & openedCustomer("LastValidContractCode").ToString & Chr(13) & "合同期： " & openedCustomer("LastValidContractPeriod").ToString
                    Else
                        If joinedCustomer("RowID") = 1 AndAlso sOldLastValidContractID <> joinedCustomer("LastValidContractID").ToString Then
                            Me.ResetContractPeriod(joinedCustomer)
                        End If
                        If sOldCityID <> joinedCustomer("CityID").ToString Then
                            If joinedCustomer("RowID") = 1 Then
                                sCityID = joinedCustomer("CityID").ToString
                                Me.ResetSignPlace()
                            End If
                            Me.ResetInvoiceItems()
                        End If
                    End If
                    Me.dgvCustomer("Error", displayedCustomer("RowID") - 1).ToolTipText = ""

                    With Me.dgvCustomer.Columns("Error")
                        If dtDisplayedCustomer.Select("Isnull(Error,'')<>''").Length = 0 Then
                            .Visible = False
                        Else
                            .Visible = True
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        End If
                    End With
                End If
                Me.ResetCustomerLayout()
            End If
        End If
        blSkipDeal = False
    End Sub

    Private Sub ResetContractPeriod(ByVal joinedCustomer As DataRow)
        Me.dtpStartDate.MinDate = "1753-1-1" : Me.dtpStartDate.MaxDate = "9998-12-31"
        Me.dtpEndDate.MinDate = "1753-1-1" : Me.dtpEndDate.MaxDate = "9998-12-31"
        If joinedCustomer("LastValidContractID").ToString = "-1" Then
            drContract("StartDate") = dtToday
        Else
            drContract("StartDate") = IIf(DateAdd(DateInterval.Day, 1, joinedCustomer("LastValidContractEndDate")) > DateAdd(DateInterval.Day, -7, dtToday), DateAdd(DateInterval.Day, 1, joinedCustomer("LastValidContractEndDate")), DateAdd(DateInterval.Day, -7, dtToday))
        End If
        drContract("EndDate") = DateAdd(DateInterval.Year, 1, DateAdd(DateInterval.Day, -1, drContract("StartDate")))
        Me.dtpStartDate.Value = drContract("StartDate")
        Me.dtpEndDate.Value = drContract("EndDate")
    End Sub

    Private Sub ResetSignPlace()
        Dim sSignPlace As String = ""
        If frmMain.sLoginAreaType = "S" Then
            sSignPlace = sCityName
        Else
            sSignPlace = frmMain.dtLoginStructure.Rows.Find(sCityID)("AreaFullName").ToString.Substring(5)
        End If
        If Me.cbbSignPlace.SelectedIndex = 0 OrElse drContract("SignPlace").ToString = "" Then drContract("SignPlace") = sSignPlace
        Me.cbbSignPlace.Items.Clear()
        Me.cbbSignPlace.Items.Add(sSignPlace)
        Me.cbbSignPlace.Text = drContract("SignPlace").ToString
        Me.cbbSignPlace.Visible = True
        Me.txbSignPlace.Text = Me.cbbSignPlace.Text
        Me.txbSignPlace.Visible = False
    End Sub

    Private Sub ResetInvoiceItems()
        If sCityID = "" Then Return
        Dim dtCity As DataTable = dtContractCustomer.DefaultView.ToTable(True, "CityID"), sRowFilter As String = "", iCities As Int16 = dtCity.Rows.Count
        If iCities = 0 Then
            sRowFilter = "CityID=" & sCityID
        ElseIf iCities = 1 Then
            sRowFilter = "CityID=" & dtCity.Rows(0)("CityID").ToString
        Else
            For Each drCity As DataRow In dtCity.Rows
                sRowFilter = sRowFilter & drCity("CityID").ToString & ","
            Next
            sRowFilter = sRowFilter.Substring(0, sRowFilter.Length - 1)
            sRowFilter = "CityID In (" & sRowFilter & ")"
        End If
        dtCity.Dispose() : dtCity = Nothing

        If dvInvoiceItem.RowFilter = sRowFilter Then Return

        dtContractCustomer.Rows(0)("InvoiceItem") = DBNull.Value
        Me.cbbInvoiceItem.Text = "（任何符合家乐福税务政策的发票品项）"
        dvInvoiceItem.RowFilter = sRowFilter
        Dim dtDistinctItem As DataTable = dvInvoiceItem.ToTable(True, "Content"), dtInvoiceItem As DataTable = dvInvoiceItem.ToTable("Content")
        With Me.cklInvoiceItem.Items
            .Clear()
            .Add("（任何符合家乐福税务政策的发票品项）", True)
            For Each drItem As DataRow In dtDistinctItem.Rows
                If dtInvoiceItem.Compute("Count(Content)", "Content='" & drItem("Content").ToString.Replace("'", "''") & "'") = iCities Then .Add(drItem("Content").ToString, True)
            Next
        End With
        dtDistinctItem.Dispose() : dtDistinctItem = Nothing
        dtInvoiceItem.Dispose() : dtInvoiceItem = Nothing
    End Sub

    Private Function CheckPeriodOverlap(ByVal checkingCustomer As DataRow) As Boolean
        If checkingCustomer("LastValidContractID").ToString = "" Then Return False
        If drContract("StartDate") >= checkingCustomer("LastValidContractStartDate") AndAlso drContract("StartDate") <= checkingCustomer("LastValidContractEndDate") Then Return True
        If drContract("EndDate") >= checkingCustomer("LastValidContractStartDate") AndAlso drContract("EndDate") <= checkingCustomer("LastValidContractEndDate") Then Return True
        Return False
    End Function

    Private Sub CheckValidation()
        Dim dvCityRule As DataView, dvRuleDetails As DataView
        If blContentChanged OrElse drContract("ContractState") = 0 Then
            dvCityRule = dvNewestCityRule
            dvRuleDetails = dvNewestRuleDetails
        Else
            dvCityRule = dvHistoryCityRule
            dvRuleDetails = dvHistoryRuleDetails
        End If

        Dim sCityIDs As String = "", sApprovableRoleID As String = "", sApprovableRoleCode As String = "", dmLevelStartAMT As Decimal, drRuleDetail As DataRowView = Nothing
        For Each dr As DataRow In dtContractCustomer.Rows
            sCityIDs = sCityIDs & dr("CityID").ToString & ","
        Next
        If sCityIDs <> "" Then
            sCityIDs = sCityIDs.Substring(0, sCityIDs.Length - 1)
            dvCityRule.RowFilter = "CityID Not In (" & sCityIDs & ")"
            For Each drCityRule As DataRowView In dvCityRule
                dvRuleDetails.RowFilter = "RuleID=" & drCityRule("RuleID").ToString
                For Each drRuleDetail In dvRuleDetails
                    drRuleDetail.Delete()
                Next
                drCityRule.Delete()
            Next
            dvCityRule.Table.AcceptChanges() : dvRuleDetails.Table.AcceptChanges()
        End If
        dvCityRule.RowFilter = ""

        For Each drContractDetail As DataRow In dtContractDetails.Select("RebateRate>0", "LevelID")
            dmLevelStartAMT = drContractDetail("StartSalesAMT") + 0.001
            For Each drCityRule As DataRowView In dvCityRule
                dvRuleDetails.RowFilter = "RuleID=" & drCityRule("RuleID").ToString
                For Each drRuleDetail In dvRuleDetails
                    If drRuleDetail("EndSalesAMT").ToString <> "" AndAlso dmLevelStartAMT > drRuleDetail("StartSalesAMT") AndAlso dmLevelStartAMT <= drRuleDetail("EndSalesAMT") Then
                        Exit For
                    End If
                Next
                If drContractDetail("RebateRate") > drRuleDetail("MaxRebateRate") AndAlso (sApprovableRoleCode = "" OrElse sApprovableRoleCode > drRuleDetail("RoleFullName").ToString.Substring(0, 2)) Then
                    sApprovableRoleID = drRuleDetail("ApprovableRoleID").ToString
                    sApprovableRoleCode = drRuleDetail("RoleFullName").ToString.Substring(0, 2)
                End If
            Next
        Next

        Dim sRoleCode As String = dtApprovableRole.Select("RoleID=" & drContract("ModifierRoleID").ToString)(0)("RoleCode").ToString
        blCanValidate = False : blCanStop = False
        sApprovableRoleChineseNames = "" : sApprovableRoleEnglishNames = ""

        If drContract("ModifierAreaID").ToString = "0" Then '如果合同由总部建立
            Dim d As String = frmMain.sLoginRoleID
            blCanValidate = (frmMain.sLoginRoleID = "18" AndAlso dtApprovableRole.Select("RoleID=" & frmMain.sLoginRoleID & " And CanValidateContract=1").Length > 0)
            sValidationDescription = IIf(sApprovableRoleID = "", "未", "已") & "超过城市返点标准；须由总部金融服务部总监 HO FS Director"
            sApprovableRoleChineseNames = "总部金融服务部总监、"
            sApprovableRoleEnglishNames = "HO FS Director, "
        Else
            If sApprovableRoleCode <> "" AndAlso sRoleCode > sApprovableRoleCode Then
                sRoleCode = "<='" & sApprovableRoleCode & "'"
            Else
                sRoleCode = "<'" & sRoleCode & "'"
            End If
            If sApprovableRoleID = "" Then
                sValidationDescription = "未超过城市返点标准；可由"
            Else
                sValidationDescription = "已超过城市返点标准；须由"
            End If

            For Each drRole As DataRow In dtApprovableRole.Select("RoleCode" & sRoleCode & " And CanValidateContract=1", "RoleCode Desc")
                If frmMain.sLoginRoleID = drRole("RoleID").ToString Then blCanValidate = True
                If drRole("RoleCode").ToString > "04" Then
                    sValidationDescription = sValidationDescription & """" & drRole("RoleName").ToString & """、"
                    sApprovableRoleChineseNames = sApprovableRoleChineseNames & """" & drRole("RoleChineseName").ToString & """、"
                    sApprovableRoleEnglishNames = sApprovableRoleEnglishNames & """" & drRole("RoleEnglishName").ToString & """, "
                End If
            Next
        End If
        blCanStop = (blCanValidate AndAlso frmMain.dtAllowedRight.Select("RightName='ContractStop'").Length > 0) '操作者必须同时具有审核和停用的权限才能停用合同
        If blCanValidate AndAlso drContract("ContractState") > 3 AndAlso drContract("StartDate") <= dtToday Then blCanValidate = False '如果合同已生效或生过效，不再可更改合同审核状态
        If blCanValidate AndAlso blMultiCompanies AndAlso frmMain.sLoginAreaID <> "0" AndAlso drContract("ContractState") > 2 Then blCanValidate = False '如果是初级审核人员但合同已被总部审核人员审核（不管成功或失败），初级审核人员不再可以初审合同
        If blCanStop AndAlso (drContract("ContractState") <> 4 OrElse drContract("StartDate") > dtToday OrElse drContract("EndDate") < dtToday) Then blCanStop = False '当合同未通过审核或未生效或已过期时，不再可以停用合同

        sValidationDescription = sValidationDescription.Substring(0, sValidationDescription.Length - 1) & "审核"
        If sValidationDescription.LastIndexOf("、") > -1 Then sValidationDescription = sValidationDescription.Insert(sValidationDescription.LastIndexOf("、"), "、").Replace("、、", "或")
        sApprovableRoleChineseNames = sApprovableRoleChineseNames.Substring(0, sApprovableRoleChineseNames.Length - 1)
        If sApprovableRoleChineseNames.LastIndexOf("、") > -1 Then sApprovableRoleChineseNames = sApprovableRoleChineseNames.Insert(sApprovableRoleChineseNames.LastIndexOf("、"), "、").Replace("、、", "或")
        sApprovableRoleEnglishNames = sApprovableRoleEnglishNames.Substring(0, sApprovableRoleEnglishNames.Length - 2)
        If sApprovableRoleEnglishNames.LastIndexOf(",") > -1 Then sApprovableRoleEnglishNames = sApprovableRoleEnglishNames.Insert(sApprovableRoleEnglishNames.LastIndexOf(","), ",").Replace(",,", " or")
    End Sub

    Private Sub CheckChanges()
        If sContractID = "-1" Then Me.btnSave.Enabled = True : Return

        Dim blChanged As Boolean = False
        If dtContractCustomer.GetChanges(DataRowState.Modified) IsNot Nothing Then
            For Each joinedCustomer As DataRow In dtContractCustomer.Select("", "", DataViewRowState.ModifiedCurrent)
                blChanged = False
                If joinedCustomer("InvoiceTitleCustomerID").ToString <> joinedCustomer("InvoiceTitleCustomerID", DataRowVersion.Original).ToString OrElse joinedCustomer("InvoiceItem").ToString <> joinedCustomer("InvoiceItem", DataRowVersion.Original).ToString Then
                    blChanged = True : Exit For
                Else
                    joinedCustomer.AcceptChanges()
                End If
            Next
        End If

        If (Not blChanged) AndAlso (dtContractDetails.GetChanges(DataRowState.Modified) IsNot Nothing) Then
            For Each drContractDetail As DataRow In dtContractDetails.Select("", "", DataViewRowState.ModifiedCurrent)
                blChanged = False
                For bColumn As Byte = 0 To dtContractDetails.Columns.Count - 1
                    Try
                        If drContractDetail(bColumn) <> drContractDetail(bColumn, DataRowVersion.Original) Then
                            blChanged = True : Exit For
                        End If
                    Catch
                        If drContractDetail(bColumn).ToString <> drContractDetail(bColumn, DataRowVersion.Original).ToString Then
                            blChanged = True : Exit For
                        End If
                    End Try
                Next
                If blChanged Then
                    Exit For
                Else
                    drContractDetail.AcceptChanges()
                End If
            Next
            blChanged = False
        End If

        If Not blChanged Then
            If dtContractDetails.GetChanges() IsNot Nothing Then
                blChanged = True
            ElseIf drContract.RowState = DataRowState.Modified Then
                For bColumn As Byte = 0 To drContract.Table.Columns.Count - 1
                    Select Case drContract.Table.Columns(bColumn).ColumnName
                        Case "ContractState", "StateReason", "ModifierAreaID", "ModifierRoleID"
                        Case Else
                            Try
                                If drContract(bColumn) <> drContract(bColumn, DataRowVersion.Original) Then
                                    blChanged = True
                                    Exit For
                                End If
                            Catch
                                If drContract(bColumn).ToString <> drContract(bColumn, DataRowVersion.Original).ToString Then
                                    blChanged = True
                                    Exit For
                                End If
                            End Try
                    End Select
                Next
            End If
        End If

        Me.btnPrint.Enabled = (Not blChanged AndAlso frmMain.dtAllowedRight.Select("RightName='ContractPrint'").Length > 0)
        If blChanged Then
            Me.pnlContractState.Visible = False
            Me.pnlFirstValidate.Visible = False
            Me.pnlHOValidate.Visible = False
            Me.pnlValidate.Visible = False
            drContract("ModifierAreaID") = frmMain.sLoginAreaID
            drContract("ModifierRoleID") = frmMain.sLoginRoleID
            blContentChanged = True
        Else
            Me.pnlContractState.Visible = Not blCanValidate
            If blCanValidate Then
                If blMultiCompanies AndAlso drContract("ModifierAreaID").ToString <> "0" Then '多公司合同且不是由总部人员创建
                    If frmMain.sLoginAreaID = "0" Then '总部审核人员
                        Me.pnlHOValidate.Visible = True
                    Else
                        Me.pnlFirstValidate.Visible = True
                    End If
                Else
                    Me.pnlValidate.Visible = True
                End If
            End If
            sValidationDescription = ""
            drContract("ModifierAreaID") = drContract("ModifierAreaID", DataRowVersion.Original)
            drContract("ModifierRoleID") = drContract("ModifierRoleID", DataRowVersion.Original)
            If drContract("ContractState") <> drContract("ContractState", DataRowVersion.Original) OrElse drContract("StateReason").ToString <> drContract("StateReason", DataRowVersion.Original).ToString Then blChanged = True
            If drContract("ContractState") <> drContract("ContractState", DataRowVersion.Original) AndAlso drContract("ContractState", DataRowVersion.Original) <> 2 AndAlso drContract("ContractState") <> 4 Then
                blContentChanged = True
            Else
                blContentChanged = False
            End If
        End If

        If Not blChanged Then drContract.AcceptChanges()
        Me.btnSave.Enabled = blChanged
    End Sub

    Private Function GetFileMD5Code(ByVal sFileName As String) As String
        Dim fstream As New FileStream(sFileName, FileMode.Open, FileAccess.Read)
        Dim dataToHash(fstream.Length - 1) As Byte
        fstream.Read(dataToHash, 0, fstream.Length)
        fstream.Close()

        Dim hashvalue As Byte() = CType(CryptoConfig.CreateFromName("MD5"), HashAlgorithm).ComputeHash(dataToHash)
        Dim sMD5Code As String = ""
        For iByte As Integer = 0 To hashvalue.Length - 1
            sMD5Code += Hex(hashvalue(iByte)).ToLower
        Next
        Return sMD5Code
    End Function

    Private Function SaveChanges() As Boolean
        Me.btnSave.Select()

        If Me.txbACompanyChineseName.Text = "" Then
            MessageBox.Show("甲方公司中文名称不能为空！请先输入甲方公司中文名称。    ", "甲方公司中文名称不能为空！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "甲方公司中文名称不能为空！请先输入甲方公司中文名称。"
            Me.grbPartyA.Select()
            If Me.txbACompanyChineseName.Visible Then
                Me.txbACompanyChineseName.Select()
            Else
                Me.cbbACompanyChineseName.Select()
            End If
            Me.btnSave.Enabled = False : Return False
        End If

        If Me.txbBeneficiary.Text = "" Then
            MessageBox.Show("甲方公司账户名称不能为空！请先输入甲方公司账户名称。    ", "甲方公司账户名称不能为空！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "甲方公司账户名称不能为空！请先输入甲方公司账户名称。"
            Me.grbPartyA.Select()
            Me.txbBeneficiary.Select()
            Me.btnSave.Enabled = False : Return False
        End If

        If Me.txbBankAccount.Text = "" Then
            MessageBox.Show("甲方公司账号不能为空！请先输入甲方公司账号。    ", "甲方公司账号不能为空！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "甲方公司账号不能为空！请先输入甲方公司账号。"
            Me.grbPartyA.Select()
            Me.txbBankAccount.Select()
            Me.btnSave.Enabled = False : Return False
        End If

        If Me.txbDomiciliation.Text = "" Then
            MessageBox.Show("甲方账号开户行不能为空！请先输入甲方账号开户行。    ", "甲方账号开户行不能为空！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "甲方账号开户行不能为空！请先输入甲方账号开户行。"
            Me.grbPartyA.Select()
            Me.txbDomiciliation.Select()
            Me.btnSave.Enabled = False : Return False
        End If

        If Me.dgvCustomer.RowCount = 0 Then
            MessageBox.Show("您还未添加乙方公司！请先添加乙方公司。    ", "还未添加乙方公司！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "您还未添加乙方公司！请先添加乙方公司。"
            Me.grbPartyB.Select()
            If Me.txbCustomerName.Visible Then
                Me.txbCustomerName.Select() : Me.txbCustomerName.SelectAll()
            Else
                Me.cbbCustomerName.Select() : Me.cbbCustomerName.SelectAll()
            End If
            Me.btnSave.Enabled = False : Return False
        End If

        If dtDisplayedCustomer.Select("Isnull(Error,'')<>''").Length > 0 Then
            MessageBox.Show("乙方公司列表中存在目前无法创建合同的客户！    " & Chr(13) & Chr(13) & "请从乙方公司列表中删除这" & IIf(dtDisplayedCustomer.Select("Isnull(Error,'')<>''").Length = 1, "个", "些") & "客户。    ", "存在无法创建合同的客户！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.grbPartyB.Select()
            Me.dgvCustomer.Select()
            For Each displayedCustomer As DataGridViewRow In Me.dgvCustomer.Rows
                If displayedCustomer.Cells("Error").Value.ToString <> "" Then
                    displayedCustomer.Selected = True : Exit For
                End If
            Next
            Me.btnSave.Enabled = False : Return False
        End If

        If Me.txbSignPlace.Text = "" Then
            MessageBox.Show("合同签署地不能为空！请先输入合同签署地。    ", "合同签署地不能为空！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "合同签署地不能为空！请先输入合同签署地。"
            Me.grbPartyA.Select()
            Me.cbbSignPlace.Select()
            Me.btnSave.Enabled = False : Return False
        End If

        If Me.txbBNoticeWays.Text = "" Then
            MessageBox.Show("乙方购卡通知方式不能为空！请先输入乙方购卡通知方式。    ", "乙方购卡通知方式不能为空！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "乙方购卡通知方式不能为空！请先输入乙方购卡通知方式。"
            Me.grbPartyB.Select()
            Me.txbBNoticeWays.Select()
            Me.btnSave.Enabled = False : Return False
        End If

        If Me.txbMinFaceValue.Text = "" Then
            MessageBox.Show("最小面值不能为空！请先输入最小面值。    ", "最小面值不能为空！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "最小面值不能为空！请先输入最小面值。"
            Me.txbMinFaceValue.Select()
            Me.btnSave.Enabled = False : Return False
        End If

        If Me.txbMaxFaceValue.Text = "" Then
            MessageBox.Show("最大面值不能为空！请先输入最大面值。    ", "最大面值不能为空！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "最大面值不能为空！请先输入最大面值。"
            Me.txbMaxFaceValue.Select()
            Me.btnSave.Enabled = False : Return False
        End If

        'If Me.txbTotalContractAMT.Text = "" Then
        '    MessageBox.Show("合同总金额不能为空！请先输入合同总金额。    ", "合同总金额不能为空！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    frmMain.statusText.Text = "合同总金额不能为空！请先输入合同总金额。"
        '    Me.txbTotalContractAMT.Select()
        '    Me.btnSave.Enabled = False : Return False
        'End If

        'If Me.txbMinContractAMT.Text = "" Then
        '    MessageBox.Show("合同最小总金额不能为空！请先输入合同最小总金额。    ", "合同最小总金额不能为空！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    frmMain.statusText.Text = "合同最小总金额不能为空！请先输入合同最小总金额。"
        '    Me.txbMinContractAMT.Select()
        '    Me.btnSave.Enabled = False : Return False
        'End If

        'If Me.txbMaxContractAMT.Text = "" Then
        '    MessageBox.Show("合同最大总金额不能为空！请先输入合同最大总金额。    ", "合同最大总金额不能为空！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    frmMain.statusText.Text = "合同最大总金额不能为空！请先输入合同最大总金额。"
        '    Me.txbMaxContractAMT.Select()
        '    Me.btnSave.Enabled = False : Return False
        'End If

        If Me.txbMinAMTPerPurchase.Text = "" Then
            MessageBox.Show("合同单次最低购买金额不能为空！请先输入合同单次最低购买金额。    ", "合同单次最低购买金额不能为空！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "合同单次最低购买金额不能为空！请先输入合同单次最低购买金额。"
            Me.txbMinAMTPerPurchase.Select()
            Me.btnSave.Enabled = False : Return False
        End If

        If drContract("MaxRebateRate") = 0 Then
            MessageBox.Show("您尚未划分合同的返点比率！请先划分合同的返点比率。    ", "您尚未划分合同的返点比率！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "您尚未划分合同的返点比率！请先划分合同的返点比率。"
            Me.dgvDetails.Select()
            Me.dgvDetails("RebateRate", 0).Selected = True
            Me.dgvDetails.BeginEdit(True)
            Me.btnSave.Enabled = False : Return False
        End If

        If errorCell IsNot Nothing Then
            If errorCell.ColumnIndex = 3 Then
                MessageBox.Show("不能保存合同，因为有一行的最大金额错误（" & sErrorInfo & "）！    " & Chr(13) & Chr(13) & "请重新输入该行的最大金额。    ", "不能保存合同！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                frmMain.statusText.Text = "不能保存合同，因为有一行的最大金额错误（" & sErrorInfo & "）！请重新输入该行的最大金额。"
            Else
                MessageBox.Show("不能保存合同，因为有一行的返点比率错误（" & sErrorInfo & "）！    " & Chr(13) & Chr(13) & "请重新输入该行的返点比率。    ", "不能保存合同！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                frmMain.statusText.Text = "不能保存合同，因为有一行的返点比率错误（" & sErrorInfo & "）！请重新输入该行的返点比率。"
            End If
            blSkipDeal = True
            Me.dgvDetails.Select()
            Me.dgvDetails.EditMode = DataGridViewEditMode.EditOnEnter
            errorCell.Selected = True
            Me.dgvDetails.BeginEdit(True)
            blSkipDeal = False
            Me.btnSave.Enabled = False : Return False
        End If

        For Each drRebate As DataGridViewRow In Me.dgvDetails.Rows
            If drRebate.Cells("RebateRate").Value.ToString = "" Then
                MessageBox.Show("不能保存合同，因为有一行的返点比率未设置！    " & Chr(13) & Chr(13) & "请设置该行的返点比率。    ", "不能保存合同！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                frmMain.statusText.Text = "不能保存合同，因为有一行的返点比率未设置！请设置该行的返点比率。"
                blSkipDeal = True
                Me.dgvDetails.Select()
                Me.dgvDetails.EditMode = DataGridViewEditMode.EditOnEnter
                drRebate.Cells("RebateRate").Selected = True
                Me.dgvDetails.BeginEdit(True)
                blSkipDeal = False
                Me.btnSave.Enabled = False : Return False
            End If
        Next

        If Me.cbbInvoiceItem.Text = "" Then
            MessageBox.Show("还未指定发票品项！请先指定发票品项。    ", "还未指定发票品项！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.cbbInvoiceItem.Select()
            Me.cklInvoiceItem.Visible = True
            Me.btnSave.Enabled = False : Return False
        End If

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在保存合同……"
        frmMain.statusMain.Refresh()

        If dtContractCustomer.GetChanges() IsNot Nothing Then
            Dim sInvoiceItem As String = dtContractCustomer.Rows(0)("InvoiceItem").ToString
            For Each joinedCusotmer As DataRow In dtContractCustomer.Rows
                If joinedCusotmer("InvoiceItem").ToString <> sInvoiceItem Then joinedCusotmer("InvoiceItem") = sInvoiceItem
            Next
        End If

        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法保存合同。请检查数据库连接。"
            Me.Cursor = Cursors.Default
            Return False
        End If

        Dim dtTempDetails As New DataTable, drTempDetail As DataRow, dtResult As DataTable, sSQL As String = ""
        dtTempDetails.Columns.Add("LevelID", System.Type.GetType("System.Byte"))
        dtTempDetails.Columns.Add("StartSalesAMT", System.Type.GetType("System.Decimal"))
        dtTempDetails.Columns.Add("EndSalesAMT", System.Type.GetType("System.Decimal"))
        dtTempDetails.Columns.Add("RebateRate", System.Type.GetType("System.Decimal"))

        If sContractID = "-1" Then '新建合同
            Dim dtTempCustomer As DataTable = dtContractCustomer.DefaultView.ToTable(False, "RowID", "CustomerID", "InvoiceTitleCustomerID", "InvoiceItem")
            If DB.ModifyTable("Select RowID,CustomerID,InvoiceTitleCustomerID,InvoiceItem Into #tempCustomer From ContractCustomer Where 1=2") = -1 Then
                dtTempCustomer.Dispose() : dtTempCustomer = Nothing : DB.Close()
                frmMain.statusText.Text = "保存合同失败！"
                Me.Cursor = Cursors.Default
                Return False
            End If

            If DB.BulkCopyTable("#tempCustomer", dtTempCustomer) = -1 Then
                dtTempCustomer.Dispose() : dtTempCustomer = Nothing : DB.Close()
                frmMain.statusText.Text = "保存合同失败！"
                Me.Cursor = Cursors.Default
                Return False
            End If

            dtTempCustomer.Dispose() : dtTempCustomer = Nothing

            For Each drDetail As DataRow In dtContractDetails.Select("", "LevelID", DataViewRowState.CurrentRows)
                drTempDetail = dtTempDetails.Rows.Add
                drTempDetail("LevelID") = drDetail("LevelID")
                drTempDetail("StartSalesAMT") = drDetail("StartSalesAMT")
                drTempDetail("EndSalesAMT") = drDetail("EndSalesAMT")
                drTempDetail("RebateRate") = drDetail("RebateRate") / 100
            Next

            If DB.ModifyTable("Select LevelID,StartSalesAMT,EndSalesAMT,RebateRate Into #tempContractDetails From ContractDetails Where 1=2") = -1 Then
                dtTempDetails.Dispose() : dtTempDetails = Nothing : DB.Close()
                frmMain.statusText.Text = "保存合同失败！"
                Me.Cursor = Cursors.Default
                Return False
            End If

            If DB.BulkCopyTable("#tempContractDetails", dtTempDetails) = -1 Then
                dtTempDetails.Dispose() : dtTempDetails = Nothing : DB.Close()
                frmMain.statusText.Text = "保存合同失败！"
                Me.Cursor = Cursors.Default
                Return False
            End If

            dtTempDetails.Dispose() : dtTempDetails = Nothing

            sSQL = "Exec ContractInsertion @ACompanyChineseName='" & drContract("ACompanyChineseName").ToString.Replace("'", "''") & "',"
            If drContract("ACompanyEnglishName").ToString <> "" Then sSQL = sSQL & "@ACompanyEnglishName='" & drContract("ACompanyEnglishName").ToString.Replace("'", "''") & "',"
            sSQL = sSQL & "@Beneficiary='" & drContract("Beneficiary").ToString.Replace("'", "''") & "',@BankAccount='" & drContract("BankAccount").ToString & "',@Domiciliation='" & drContract("Domiciliation").ToString.Replace("'", "''") & "',"
            sSQL = sSQL & "@SignPlace='" & drContract("SignPlace").ToString.Replace("'", "''") & "',@MainCustomerName ='" & drContract("MainCustomerName").ToString & "',@BNoticeWays='" & drContract("BNoticeWays").ToString.Replace("'", "''") & "',"
            sSQL = sSQL & "@StartDate='" & Format(drContract("StartDate"), "yyyy\/MM\/dd") & "',@EndDate='" & Format(drContract("EndDate"), "yyyy\/MM\/dd") & "',"
            sSQL = sSQL & "@MinFaceValue=" & drContract("MinFaceValue").ToString & ",@MaxFaceValue=" & drContract("MaxFaceValue").ToString & ","
            If drContract("TotalContractAMT").ToString <> "" Then sSQL = sSQL & "@TotalContractAMT=" & drContract("TotalContractAMT").ToString & ","
            If drContract("MinContractAMT").ToString <> "" Then sSQL = sSQL & "@MinContractAMT=" & drContract("MinContractAMT").ToString & ","
            If drContract("MaxContractAMT").ToString <> "" Then sSQL = sSQL & "@MaxContractAMT=" & drContract("MaxContractAMT").ToString & ","
            sSQL = sSQL & "@MinAMTPerPurchase=" & drContract("MinAMTPerPurchase").ToString & ",@MaxRebateRate=" & drContract("MaxRebateRate").ToString & ","
            If drContract("PaymentMode") <> 0 Then sSQL = sSQL & "@PaymentMode=" & drContract("PaymentMode").ToString & ","
            If drContract("CalculationMode") <> 0 Then sSQL = sSQL & "@CalculationMode=" & drContract("CalculationMode").ToString & ","
            If drContract("CalculationDay") <> 255 Then sSQL = sSQL & "@CalculationDay=" & drContract("CalculationDay").ToString & ","
            sSQL = sSQL & "@AppointedDate='" & Format(drContract("AppointedDate"), "yyyy\/MM\/dd") & "',"
            If drContract("AppointedStoreID").ToString <> "" Then sSQL = sSQL & "@AppointedStoreID=" & drContract("AppointedStoreID").ToString & ","
            sSQL = sSQL & "@OperatorName='" & frmMain.sLoginUserRealName.Replace("'", "''") & "',@SSID=" & frmMain.sSSID

            dtResult = DB.GetDataTable(sSQL)
            If dtResult Is Nothing Then
                DB.Close()
                frmMain.statusText.Text = "保存合同失败！"
                Me.Cursor = Cursors.Default
                Return False
            ElseIf dtResult.Rows(0)("Result").ToString = "OK" Then
                sContractID = dtResult.Rows(0)("ContractID").ToString
                drContract("ContractID") = sContractID : drContract("ContractCode") = dtResult.Rows(0)("ContractCode").ToString
                drContract("CreatorName") = frmMain.sLoginUserRealName : drContract("CreatedTime") = dtResult.Rows(0)("CreatedTime")
                drContract.AcceptChanges()
                For Each joinedCustomer As DataRow In dtContractCustomer.Rows
                    joinedCustomer("ContractID") = sContractID
                Next
                dtContractCustomer.AcceptChanges()
                For Each drDetail As DataRow In dtContractDetails.Rows
                    drDetail("ContractID") = sContractID
                Next
                dtContractDetails.AcceptChanges()

                Me.txbContractCode.Text = drContract("ContractCode").ToString

                If sValidationDescription = "" Then Me.CheckValidation()
                Me.pnlContractState.Visible = True
                Me.txbContratState.Text = "未审核；" & sValidationDescription & "； Not yet validated."

                Me.pnlInputCustomer.Visible = False
                Me.dgvCustomer.Columns("Delete").Visible = False
                Me.grbPartyB.Height = Me.flpCustomer.Height + 26

                blCanModify = (frmMain.dtAllowedRight.Select("RightName='ContractModify'").Length > 0)
                Me.ResetControls()

                Me.grbInvoice.Margin = New Padding(12, 0, 8, 8)
                Me.grbOperation.Visible = True
                Me.lblCreator.Text = frmMain.sLoginUserRealName
                Me.lblCreatedTime.Text = Format(dtResult.Rows(0)("CreatedTime"), "yyyy\/MM\/dd HH:mm:ss")
                Me.grbOperation.Height = Me.tlpOperation.Height + 32

                Dim sContractCode As String = Me.txbCustomerCode.Text & Me.txbContractCode.Text
                Me.Text = "合同 Contract: " & sContractCode & " " & drContract("MainCustomerName").ToString
                If Not blCanModify Then Me.Text = Me.Text & " (只读 Readonly)"

                If frmCustomerManagement.IsHandleCreated Then
                    Dim customer As DataRow
                    For Each joinedCustomer As DataRow In dtContractCustomer.Rows
                        Try
                            customer = frmCustomerManagement.dvCustomer.Table.Rows.Find(joinedCustomer("CustomerID"))
                            customer("InvalidContractID") = sContractID
                            customer("InvalidContractCode") = sContractCode
                            customer.AcceptChanges() : customer = Nothing
                        Catch
                        End Try
                    Next
                    If frmCustomerManagement.dgvList.CurrentRow IsNot Nothing Then
                        frmCustomerManagement.dgvList.CurrentRow.Selected = False
                        frmCustomerManagement.dgvList.CurrentRow.Selected = True
                    End If
                End If

                If frmContractManagement.IsHandleCreated Then
                    Dim newContract As DataRowView = frmContractManagement.dvContract.AddNew
                    newContract("ContractID") = sContractID
                    newContract("ContractCode") = Me.txbCustomerCode.Text & Me.txbContractCode.Text
                    newContract("CustomerName") = drContract("MainCustomerName").ToString
                    If sCityName <> "" Then
                        newContract("CityNameBelongs") = sCityName
                    Else
                        newContract("CityNameBelongs") = frmMain.dtLoginStructure.Rows.Find(sCityID)("AreaFullName").ToString.Substring(5)
                    End If
                    newContract("StartDate") = drContract("StartDate")
                    newContract("EndDate") = drContract("EndDate")
                    newContract("ContractDays") = DateDiff(DateInterval.Day, drContract("StartDate"), drContract("EndDate")) + 1
                    newContract("PaymentMode") = IIf(drContract("PaymentMode") = 0, "赠送返点 Addition", "付款抵扣 Deduction")
                    newContract("CalculationMode") = IIf(drContract("CalculationMode") = 0, "按购物总额 by Total Purchase", "按分段金额 by Section of Purchase")
                    newContract("CalculationDay") = IIf(drContract("CalculationDay") = 0, "合同期满后 End of Contract", IIf(drContract("CalculationDay") = 255, "每次购买 Each Purchase", "每月一次 Monthly"))
                    newContract("MaxRebateRate") = drContract("MaxRebateRate") * 100
                    newContract("ContractStateDescription") = "未审核 Not yet validated"
                    newContract("MainCustomerID") = drContract("MainCustomerID")
                    newContract("ContractState") = 0
                    Dim mainCustomer As DataRow = dtContractCustomer.Select("RowID=1")(0)
                    newContract("CityID") = mainCustomer("CityID")
                    newContract("StoreID") = mainCustomer("CityID")
                    newContract("BusinessTypeID") = mainCustomer("BusinessTypeID")
                    newContract("CreatorID") = frmMain.sLoginUserID
                    newContract.EndEdit() : newContract.Row.AcceptChanges()
                    If (frmContractManagement.cbbCity.SelectedIndex <> 0 AndAlso frmContractManagement.cbbCity.Text <> newContract("CityNameBelongs").ToString) OrElse (frmContractManagement.cbbState.SelectedIndex <> 0 AndAlso frmContractManagement.cbbState.Text <> newContract("ContractStateDescription").ToString) Then
                        frmContractManagement.cbbCity.SelectedIndex = 0
                        frmContractManagement.cbbState.SelectedIndex = 0
                    End If
                    For Each dr As DataGridViewRow In frmContractManagement.dgvList.Rows
                        If dr.Cells("ContractID").Value.ToString = sContractID Then
                            dr.Cells(1).Selected = True
                            dr.Selected = True
                            Exit For
                        End If
                    Next
                    newContract = Nothing
                    With frmContractManagement.dgvList.Columns("CustomerName")
                        .MinimumWidth = 2
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .MinimumWidth = .Width
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    End With
                End If

                blSkipDeal = True
                If Me.dgvCustomer.CurrentCell IsNot Nothing Then Me.dgvCustomer.CurrentCell.Selected = False
                If Me.dgvCustomer.CurrentRow IsNot Nothing Then Me.dgvCustomer.CurrentRow.Selected = False
                If Me.dgvDetails.CurrentCell IsNot Nothing Then Me.dgvDetails.CurrentCell.Selected = False
                If Me.dgvDetails.CurrentRow IsNot Nothing Then Me.dgvDetails.CurrentRow.Selected = False
                blSkipDeal = False

                Me.grbPartyA.Select()
                Me.txbContratState.Select() : Me.txbContratState.SelectAll()
                Me.btnSave.Enabled = False
                Me.btnPrint.Enabled = (frmMain.dtAllowedRight.Select("RightName='ContractPrint'").Length > 0)

                MessageBox.Show("新合同已保存，但未被审核。合同只有在通过审核时方才生效。    " & Chr(13) & _
                           "New contrac had been saved but not validate yet. It is not effective until validation.    " & Chr(13) & Chr(13) & _
                           "请找" & sApprovableRoleChineseNames & "审核该合同。    " & Chr(13) & _
                           "Please let " & sApprovableRoleEnglishNames & " to validate it.    ", _
                           "新合同已保存。", MessageBoxButtons.OK, MessageBoxIcon.Information)

                dtResult.Dispose() : dtResult = Nothing : DB.Close()
                frmMain.statusText.Text = "保存合同成功。"
                Me.Cursor = Cursors.Default
                blContentChanged = False
                Return True
            Else
                If dtResult.Rows(0)("Result").ToString = "CustomerError" Then
                    Dim errorCustomer As DataRow = Nothing
                    For Each drResult As DataRow In dtResult.Rows
                        errorCustomer = dtDisplayedCustomer.Select("CustomerID=" & drResult("CustomerID").ToString)(0)
                        errorCustomer("Error") = " (Error!) "
                        Me.dgvCustomer("Error", errorCustomer("RowID") - 1).ToolTipText = drResult("Reason").ToString
                    Next
                    errorCustomer.AcceptChanges()
                    With Me.dgvCustomer.Columns("Error")
                        .Visible = True
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    End With
                    MessageBox.Show("乙方公司列表中存在目前无法创建合同的客户！    " & Chr(13) & Chr(13) & "请从乙方公司列表中删除这" & IIf(dtDisplayedCustomer.Select("Isnull(Error,'')<>''").Length = 1, "个", "些") & "客户。    ", "存在无法创建合同的客户！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.grbPartyB.Select()
                    Me.dgvCustomer.Select()
                    For Each displayedCustomer As DataGridViewRow In Me.dgvCustomer.Rows
                        If displayedCustomer.Cells("Error").Value.ToString <> "" Then
                            displayedCustomer.Selected = True : Exit For
                        End If
                    Next

                    Me.btnSave.Enabled = False
                Else
                    MessageBox.Show("保存合同时出现错误！下面是数据库的内部错误提示：    " & Chr(13) & Chr(13) & dtResult.Rows(0)("ErrorInfo").ToString & Space(4) & Chr(13) & Chr(13) & "请放弃保存，在关闭窗口后重试。如果仍有问题，请联系软件开发人员。    ", "保存合同失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

                dtResult.Dispose() : dtResult = Nothing : DB.Close()
                frmMain.statusText.Text = "保存合同失败！"
                Me.Cursor = Cursors.Default
                Return False
            End If
        ElseIf Me.pnlFirstValidate.Visible = False AndAlso Me.pnlHOValidate.Visible = False AndAlso Me.pnlValidate.Visible = False AndAlso Me.pnlStop.Visible = False Then '修改合同
            If dtContractCustomer.GetChanges() IsNot Nothing Then
                Dim dtTempCustomer As DataTable = dtContractCustomer.DefaultView.ToTable(False, "ContractID", "CustomerID", "InvoiceTitleCustomerID", "InvoiceItem")
                If DB.ModifyTable("Select ContractID,CustomerID,InvoiceTitleCustomerID,InvoiceItem Into #tempCustomer From ContractCustomer Where 1=2") = -1 Then
                    dtTempCustomer.Dispose() : dtTempCustomer = Nothing : DB.Close()
                    frmMain.statusText.Text = "保存合同失败！"
                    Me.Cursor = Cursors.Default
                    Return False
                End If

                If DB.BulkCopyTable("#tempCustomer", dtTempCustomer) = -1 Then
                    dtTempCustomer.Dispose() : dtTempCustomer = Nothing : DB.Close()
                    frmMain.statusText.Text = "保存合同失败！"
                    Me.Cursor = Cursors.Default
                    Return False
                End If

                dtTempCustomer.Dispose() : dtTempCustomer = Nothing
            End If

            If dtContractDetails.GetChanges() IsNot Nothing Then
                For Each drDetail As DataRow In dtContractDetails.Select("", "LevelID", DataViewRowState.CurrentRows)
                    drTempDetail = dtTempDetails.Rows.Add
                    drTempDetail("LevelID") = drDetail("LevelID")
                    drTempDetail("StartSalesAMT") = drDetail("StartSalesAMT")
                    drTempDetail("EndSalesAMT") = drDetail("EndSalesAMT")
                    drTempDetail("RebateRate") = drDetail("RebateRate") / 100
                Next

                If DB.ModifyTable("Select LevelID,StartSalesAMT,EndSalesAMT,RebateRate Into #tempContractDetails From ContractDetails Where 1=2") = -1 Then
                    dtTempDetails.Dispose() : dtTempDetails = Nothing : DB.Close()
                    frmMain.statusText.Text = "保存合同失败！"
                    Me.Cursor = Cursors.Default
                    Return False
                End If

                If DB.BulkCopyTable("#tempContractDetails", dtTempDetails) = -1 Then
                    dtTempDetails.Dispose() : dtTempDetails = Nothing : DB.Close()
                    frmMain.statusText.Text = "保存合同失败！"
                    Me.Cursor = Cursors.Default
                    Return False
                End If

                dtTempDetails.Dispose() : dtTempDetails = Nothing
            End If

            sSQL = "Exec ContractUpdate @ContractID=" & sContractID & ","
            If drContract("ContractState", DataRowVersion.Original) <> 0 Then sSQL = sSQL & "@OldContractState=" & drContract("ContractState", DataRowVersion.Original).ToString & ","
            If drContract("ModifiedTime").ToString = "" Then
                sSQL = sSQL & "@OldModifiedTime='" & Format(drContract("CreatedTime"), "yyyy\/MM\/dd HH:mm:ss") & "',"
            Else
                sSQL = sSQL & "@OldModifiedTime='" & Format(drContract("ModifiedTime"), "yyyy\/MM\/dd HH:mm:ss") & "',"
            End If
            If drContract("ACompanyChineseName").ToString <> drContract("ACompanyChineseName", DataRowVersion.Original).ToString Then sSQL = sSQL & "@ACompanyChineseName='" & drContract("ACompanyChineseName").ToString.Replace("'", "''") & "',"
            If drContract("ACompanyEnglishName").ToString <> drContract("ACompanyEnglishName", DataRowVersion.Original).ToString Then sSQL = sSQL & "@ACompanyEnglishName='" & drContract("ACompanyEnglishName").ToString.Replace("'", "''") & "',"
            If drContract("Beneficiary").ToString <> drContract("Beneficiary", DataRowVersion.Original).ToString Then sSQL = sSQL & "@Beneficiary='" & drContract("Beneficiary").ToString.Replace("'", "''") & "',"
            If drContract("BankAccount").ToString <> drContract("BankAccount", DataRowVersion.Original).ToString Then sSQL = sSQL & "@BankAccount='" & drContract("BankAccount").ToString.Replace("'", "''") & "',"
            If drContract("Domiciliation").ToString <> drContract("Domiciliation", DataRowVersion.Original).ToString Then sSQL = sSQL & "@Domiciliation='" & drContract("Domiciliation").ToString.Replace("'", "''") & "',"
            If drContract("SignPlace").ToString <> drContract("SignPlace", DataRowVersion.Original).ToString Then sSQL = sSQL & "@SignPlace='" & drContract("SignPlace").ToString.Replace("'", "''") & "',"
            If drContract("BNoticeWays").ToString <> drContract("BNoticeWays", DataRowVersion.Original).ToString Then sSQL = sSQL & "@BNoticeWays='" & drContract("BNoticeWays").ToString.Replace("'", "''") & "',"
            If drContract("StartDate").ToString <> drContract("StartDate", DataRowVersion.Original).ToString Then sSQL = sSQL & "@StartDate='" & Format(drContract("StartDate"), "yyyy\/MM\/dd") & "',"
            If drContract("EndDate").ToString <> drContract("EndDate", DataRowVersion.Original).ToString Then sSQL = sSQL & "@EndDate='" & Format(drContract("EndDate"), "yyyy\/MM\/dd") & "',"
            If drContract("MinFaceValue").ToString <> drContract("MinFaceValue", DataRowVersion.Original).ToString Then sSQL = sSQL & "@MinFaceValue=" & IIf(drContract("MinFaceValue").ToString = "", "NULL", drContract("MinFaceValue").ToString) & ","
            If drContract("MaxFaceValue").ToString <> drContract("MaxFaceValue", DataRowVersion.Original).ToString Then sSQL = sSQL & "@MaxFaceValue=" & IIf(drContract("MaxFaceValue").ToString = "", "NULL", drContract("MaxFaceValue").ToString) & ","
            If drContract("TotalContractAMT").ToString <> drContract("TotalContractAMT", DataRowVersion.Original).ToString Then sSQL = sSQL & "@TotalContractAMT=" & IIf(drContract("TotalContractAMT").ToString = "", "NULL", drContract("TotalContractAMT").ToString) & ","
            If drContract("MinContractAMT").ToString <> drContract("MinContractAMT", DataRowVersion.Original).ToString Then sSQL = sSQL & "@MinContractAMT=" & IIf(drContract("MinContractAMT").ToString = "", "NULL", drContract("MinContractAMT").ToString) & ","
            If drContract("MaxContractAMT").ToString <> drContract("MaxContractAMT", DataRowVersion.Original).ToString Then sSQL = sSQL & "@MaxContractAMT=" & IIf(drContract("MaxContractAMT").ToString = "", "NULL", drContract("MaxContractAMT").ToString) & ","
            If drContract("MinAMTPerPurChase").ToString <> drContract("MinAMTPerPurChase", DataRowVersion.Original).ToString Then sSQL = sSQL & "@MinAMTPerPurChase=" & IIf(drContract("MinAMTPerPurChase").ToString = "", "NULL", drContract("MinAMTPerPurChase").ToString) & ","
            If drContract("MaxRebateRate").ToString <> drContract("MaxRebateRate", DataRowVersion.Original).ToString Then sSQL = sSQL & "@MaxRebateRate=" & IIf(drContract("MaxRebateRate").ToString = "", "NULL", drContract("MaxRebateRate").ToString) & ","
            If drContract("PaymentMode").ToString <> drContract("PaymentMode", DataRowVersion.Original).ToString Then sSQL = sSQL & "@PaymentMode=" & drContract("PaymentMode").ToString & ","
            If drContract("CalculationMode").ToString <> drContract("CalculationMode", DataRowVersion.Original).ToString Then sSQL = sSQL & "@CalculationMode=" & drContract("CalculationMode").ToString & ","
            If drContract("CalculationDay").ToString <> drContract("CalculationDay", DataRowVersion.Original).ToString Then sSQL = sSQL & "@CalculationDay=" & drContract("CalculationDay").ToString & ","
            If drContract("AppointedDate").ToString <> drContract("AppointedDate", DataRowVersion.Original).ToString Then sSQL = sSQL & "@AppointedDate='" & Format(drContract("AppointedDate"), "yyyy\/MM\/dd") & "',"
            If drContract("AppointedStoreID").ToString <> drContract("AppointedStoreID", DataRowVersion.Original).ToString Then sSQL = sSQL & "@AppointedStoreID=" & drContract("AppointedStoreID").ToString & ","
            If dtContractCustomer.GetChanges() IsNot Nothing Then sSQL = sSQL & "@InvoiceInfoUpdated=1,"
            If dtContractDetails.GetChanges() IsNot Nothing Then sSQL = sSQL & "@ContractDetailsUpdated=1,"

            sSQL = sSQL & "@OperatorName='" & frmMain.sLoginUserRealName.Replace("'", "''") & "',@SSID=" & frmMain.sSSID
            dtResult = DB.GetDataTable(sSQL)
            If dtResult Is Nothing Then
                DB.Close()
                frmMain.statusText.Text = "保存合同失败！"
                Me.Cursor = Cursors.Default
                Return False
            ElseIf dtResult.Rows(0)("Result").ToString = "ContractDeleted" Then
                MessageBox.Show("该合同已被他人删除！不再可修改。    " & Chr(13) & Chr(13) & "请关闭该窗口。    ", "合同已被他人删除！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Refresh()
                Me.Text = Me.Text & " (已被删除 Deleted)"
                If frmContractManagement.IsHandleCreated Then
                    Try
                        frmContractManagement.dvContract.Table.Rows.Find(sContractID).Delete()
                    Catch
                    End Try
                End If
                Me.btnSave.Enabled = False : Me.btnPrint.Enabled = False
                Me.flpContainer.Enabled = False
                dtResult.Dispose() : dtResult = Nothing : DB.Close()
                frmMain.statusText.Text = "保存合同失败！"
                Me.Cursor = Cursors.Default
                Return False
            ElseIf dtResult.Rows(0)("Result").ToString = "AlreadyChanged" Then
                MessageBox.Show("本次的修改无效，因为该合同已被他人修改！    " & Chr(13) & Chr(13) & "即将重新加载合同。    ", "保存合同失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Refresh()
                Try
                    Dim updatedContract As DataTable = DB.GetDataTable("Exec ContractSingle " & sContractID).Copy
                    Dim updatedCustomer As DataTable = DB.GetDataTable("Select CustomerID,InvoiceTitleCustomerID,InvoiceItem From ContractCustomer Where ContractID=" & sContractID).Copy, joinedCustomer As DataRow
                    For Each dr As DataRow In updatedCustomer.Rows
                        joinedCustomer = dtContractCustomer.Select("CustomerID=" & dr("CustomerID").ToString)(0)
                        joinedCustomer("InvoiceTitleCustomerID") = dr("InvoiceTitleCustomerID")
                        joinedCustomer("InvoiceItem") = dr("InvoiceItem")
                    Next
                    Dim updatedDetails As DataTable = DB.GetDataTable("Select * From ContractDetails Where ContractID=" & sContractID).Copy
                    For Each drDetail As DataRow In updatedDetails.Rows
                        If drDetail("StartSalesAMT") > 0 Then drDetail("StartSalesAMT") = drDetail("StartSalesAMT")
                        drDetail("RebateRate") = drDetail("RebateRate") * 100
                        drDetail.AcceptChanges()
                    Next
                    drContract = updatedContract.Copy.Rows(0)
                    dtContractDetails = updatedDetails.Copy
                    updatedContract.Dispose() : updatedContract = Nothing
                    updatedCustomer.Dispose() : updatedCustomer = Nothing
                    updatedDetails.Dispose() : updatedDetails = Nothing
                    dtContractCustomer.AcceptChanges()
                Catch
                    drContract.RejectChanges()
                    dtContractCustomer.RejectChanges()
                    dtContractDetails.RejectChanges()
                End Try

                Me.CheckValidation()
                blCanModify = ("|0|1|3|".IndexOf("|" & drContract("ContractState").ToString & "|") > -1 AndAlso frmMain.dtAllowedRight.Select("RightName='ContractModify'").Length > 0)
                Me.FillContract()
                dtResult.Dispose() : dtResult = Nothing : DB.Close()
                frmMain.statusText.Text = "保存合同失败！"
                Me.Cursor = Cursors.Default
                Return False
            ElseIf dtResult.Rows(0)("Result").ToString = "AlreadyValidated" Then
                MessageBox.Show("本次的修改无效，因为该合同已被他人审核！    " & Chr(13) & Chr(13) & "即将重新加载合同。    ", "保存合同失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                drContract.RejectChanges()
                dtContractCustomer.RejectChanges()
                dtContractDetails.RejectChanges()
                drContract("ContractState") = dtResult.Rows(0)("ContractState")
                drContract("StateReason") = dtResult.Rows(0)("StateReason")
                drContract("ModifierName") = dtResult.Rows(0)("ModifierName")
                drContract("ModifiedTime") = dtResult.Rows(0)("ModifiedTime")
                drContract("FirstAuditorName") = dtResult.Rows(0)("FirstAuditorName")
                drContract("FirstValidatedTime") = dtResult.Rows(0)("FirstValidatedTime")
                drContract("AuditorName") = dtResult.Rows(0)("AuditorName")
                drContract("ValidatedTime") = dtResult.Rows(0)("ValidatedTime")
                drContract.AcceptChanges()
                Me.CheckValidation()
                blCanModify = ("|0|1|3|".IndexOf("|" & drContract("ContractState").ToString & "|") > -1 AndAlso frmMain.dtAllowedRight.Select("RightName='ContractModify'").Length > 0)
                Me.FillContract()
                dtResult.Dispose() : dtResult = Nothing : DB.Close()
                frmMain.statusText.Text = "保存合同失败！"
                Me.Cursor = Cursors.Default
                Return False
            ElseIf dtResult.Rows(0)("Result").ToString = "OK" Then
                If drContract("ContractState") <> 0 Then
                    drContract("ContractState") = 0
                    drContract("StateReason") = DBNull.Value
                End If
                drContract("ModifierName") = frmMain.sLoginUserRealName : drContract("ModifiedTime") = dtResult.Rows(0)("ModifiedTime")
                drContract("AuditorName") = DBNull.Value : drContract("ValidatedTime") = DBNull.Value
                drContract.AcceptChanges() : dtContractCustomer.AcceptChanges() : dtContractDetails.AcceptChanges()

                Dim drBeneficiary As DataRow
                If Me.cbbACompanyChineseName.Visible = False OrElse Me.cbbACompanyChineseName.SelectedIndex = -1 Then
                    drBeneficiary = dtBeneficiary.Rows.Add()
                Else
                    drBeneficiary = dtBeneficiary.Rows(Me.cbbACompanyChineseName.SelectedIndex)
                End If
                drBeneficiary("AreaID") = frmMain.sLoginAreaID
                drBeneficiary("ACompanyChineseName") = drContract("ACompanyChineseName").ToString
                drBeneficiary("ACompanyEnglishName") = drContract("ACompanyEnglishName").ToString
                drBeneficiary("Beneficiary") = drContract("Beneficiary").ToString
                drBeneficiary("BankAccount") = drContract("BankAccount").ToString
                drBeneficiary("Domiciliation") = drContract("Domiciliation").ToString
                drBeneficiary.EndEdit() : drBeneficiary.AcceptChanges()
                drContract.AcceptChanges() : dtContractCustomer.AcceptChanges() : dtContractDetails.AcceptChanges()

                If sValidationDescription = "" Then Me.CheckValidation()
                Me.pnlContractState.Visible = True
                Me.txbContratState.Text = "未审核；" & sValidationDescription & "； Not yet validated."

                Me.pnlModifyInfo.Visible = True
                Me.lblModifier.Text = frmMain.sLoginUserRealName
                Me.lblModifiedTime.Text = Format(dtResult.Rows(0)("ModifiedTime"), "yyyy\/MM\/dd HH:mm:ss")
                Me.pnlValidateInfo.Visible = False
                Me.grbOperation.Height = Me.tlpOperation.Height + 32

                If frmContractManagement.IsHandleCreated Then
                    Try
                        Dim contractRow As DataRow = frmContractManagement.dvContract.Table.Rows.Find(sContractID)
                        contractRow("StartDate") = drContract("StartDate")
                        contractRow("EndDate") = drContract("EndDate")
                        contractRow("ContractDays") = DateDiff(DateInterval.Day, drContract("StartDate"), drContract("EndDate")) + 1
                        contractRow("MaxRebateRate") = drContract("MaxRebateRate") * 100
                        contractRow("PaymentMode") = IIf(drContract("PaymentMode") = 0, "赠送返点 Addition", "付款抵扣 Deduction")
                        contractRow("CalculationMode") = IIf(drContract("CalculationMode") = 0, "按购物总额 by Total Purchase", "按分段金额 by Section of Purchase")
                        contractRow("CalculationDay") = IIf(drContract("CalculationDay") = 0, "合同期满后 End of Contract", IIf(drContract("CalculationDay") = 255, "每次购买 Each Purchase", "每月一次 Monthly"))
                        contractRow("ContractStateDescription") = "未审核 Not yet validated"
                        contractRow("ContractState") = drContract("ContractState")
                        contractRow.EndEdit() : contractRow.AcceptChanges()
                        contractRow = Nothing
                    Catch
                    End Try
                End If

                blSkipDeal = True
                If Me.dgvCustomer.CurrentCell IsNot Nothing Then Me.dgvCustomer.CurrentCell.Selected = False
                If Me.dgvCustomer.CurrentRow IsNot Nothing Then Me.dgvCustomer.CurrentRow.Selected = False
                If Me.dgvDetails.CurrentCell IsNot Nothing Then Me.dgvDetails.CurrentCell.Selected = False
                If Me.dgvDetails.CurrentRow IsNot Nothing Then Me.dgvDetails.CurrentRow.Selected = False
                blSkipDeal = False

                Me.grbPartyA.Select()
                Me.txbContratState.Select() : Me.txbContratState.SelectAll()
                Me.btnSave.Enabled = False : Me.btnPrint.Enabled = (frmMain.dtAllowedRight.Select("RightName='ContractPrint'").Length > 0)

                MessageBox.Show("合同已保存，但未被审核。合同只有在通过审核时方才生效。    " & Chr(13) & _
                          "The contrac had been saved but not validate yet. It is not effective until validation.    " & Chr(13) & Chr(13) & _
                          "请找" & sApprovableRoleChineseNames & "审核该合同。    " & Chr(13) & _
                          "Please let " & sApprovableRoleEnglishNames & " to validate it.    ", _
                          "合同已保存。", MessageBoxButtons.OK, MessageBoxIcon.Information)

                dtResult.Dispose() : dtResult = Nothing : DB.Close()
                frmMain.statusText.Text = "保存合同成功。"
                Me.Cursor = Cursors.Default
                blContentChanged = False
                Return True
            Else
                MessageBox.Show("保存合同时出现错误！下面是数据库的内部错误提示：    " & Chr(13) & Chr(13) & dtResult.Rows(0)("ErrorInfo").ToString & Space(4) & Chr(13) & Chr(13) & "请放弃保存，在关闭窗口后重试。如果仍有问题，请联系软件开发人员。    ", "保存合同失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                dtResult.Dispose() : dtResult = Nothing : DB.Close()
                frmMain.statusText.Text = "保存合同失败！"
                Me.Cursor = Cursors.Default
                Return False
            End If
        ElseIf Me.pnlFirstValidate.Visible OrElse Me.pnlHOValidate.Visible OrElse Me.pnlValidate.Visible Then '审核合同
            If drContract("ContractState") = 4 AndAlso drContract("StartDate") <= dtToday Then
                If MessageBox.Show("该合同一旦通过审核，便立即生效，且不可回撤！    " & Chr(13) & _
                                   "Once you approve this contract, it will be effective immediately,    " & Chr(13) & _
                                   "and can't rollback anymore!    " & Chr(13) & Chr(13) & _
                                   "您是否确实想审核该合同？    " & Chr(13) & _
                                   "Do you really want to approve it?    ", "请确认审核合同 Please confirm to approve:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                    frmMain.statusText.Text = "您已经取消保存。 You have cancelled saving."
                    Me.Cursor = Cursors.Default
                    Return False
                End If
                Me.Refresh()
            End If

            If blMultiCompanies = False OrElse drContract("ContractState") < 3 Then '审核或初审合同时
                If DB.ModifyTable("Select ContractID,CustomerID,Convert(smallint,Null) As CityID,CityRuleID,Convert(int, Null) As NewCityRuleID Into #tempCustomer From ContractCustomer Where 1=2") = -1 Then
                    frmMain.statusText.Text = "保存合同审核结果失败！ Saving contract validatation failure!"
                    Me.Cursor = Cursors.Default
                    Return False
                End If
            End If

Execute_Again:
            If blMultiCompanies = False OrElse drContract("ContractState") < 3 Then '审核或初审合同时
                For Each joinedCustomer As DataRow In dtContractCustomer.Rows
                    dvNewestCityRule.RowFilter = "CityID=" & joinedCustomer("CityID").ToString
                    If dvNewestCityRule.Count = 0 Then
                        joinedCustomer("CityRuleID") = DBNull.Value
                    Else
                        joinedCustomer("CityRuleID") = dvNewestCityRule(0)("RuleID")
                    End If
                Next

                Dim dtTempCustomer As DataTable = dtContractCustomer.DefaultView.ToTable(False, "ContractID", "CustomerID", "CityID", "CityRuleID")
                dtTempCustomer.Columns.Add("NewCityRuleID", System.Type.GetType("System.Int32"))
                If DB.BulkCopyTable("#tempCustomer", dtTempCustomer) = -1 Then
                    dtTempCustomer.Dispose() : dtTempCustomer = Nothing : DB.Close()
                    frmMain.statusText.Text = "保存合同审核结果失败！ Saving contract validatation failure!"
                    Me.Cursor = Cursors.Default
                    Return False
                End If

                dtTempCustomer.Dispose() : dtTempCustomer = Nothing
            End If

            sSQL = "Exec ContractValidate @ContractID=" & sContractID & ","
            If drContract("ContractState", DataRowVersion.Original) <> 0 Then sSQL = sSQL & "@OldContractState=" & drContract("ContractState", DataRowVersion.Original).ToString & ","
            If drContract("ModifiedTime").ToString = "" Then
                sSQL = sSQL & "@OldModifiedTime='" & Format(drContract("CreatedTime"), "yyyy\/MM\/dd HH:mm:ss") & "',"
            Else
                sSQL = sSQL & "@OldModifiedTime='" & Format(drContract("ModifiedTime"), "yyyy\/MM\/dd HH:mm:ss") & "',"
            End If
            If drContract("ContractState") <> 4 Then
                sSQL = sSQL & "@ContractState=" & drContract("ContractState").ToString & ","
                If drContract("StateReason").ToString <> "" Then sSQL = sSQL & "@StateReason='" & drContract("StateReason").ToString.Replace("'", "''") & "',"
            End If

            sSQL = sSQL & "@OperatorName='" & frmMain.sLoginUserRealName.Replace("'", "''") & "',@SSID=" & frmMain.sSSID
            dtResult = DB.GetDataTable(sSQL)

            If dtResult Is Nothing Then
                DB.Close()
                frmMain.statusText.Text = "保存合同审核结果失败！ Saving contract validatation failure! "
                Me.Cursor = Cursors.Default
                Return False
            ElseIf dtResult.Rows(0)("Result").ToString = "ContractDeleted" Then
                MessageBox.Show("该合同已被他人删除！不再可审核。请关闭该窗口。    " & Chr(13) & Chr(13) & "The contract had been deleted! Please close the window.    ", "合同已被他人删除！ Contract had deleted!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Refresh()
                Me.Text = Me.Text & " (已被删除 Deleted)"
                If frmContractManagement.IsHandleCreated Then
                    Try
                        frmContractManagement.dvContract.Table.Rows.Find(sContractID).Delete()
                    Catch
                    End Try
                End If
                Me.btnSave.Enabled = False : Me.btnPrint.Enabled = False
                Me.flpContainer.Enabled = False
                dtResult.Dispose() : dtResult = Nothing : DB.Close()
                frmMain.statusText.Text = "保存合同审核结果失败！ Saving contract validatation failure! "
                Me.Cursor = Cursors.Default
                Return False
            ElseIf dtResult.Rows(0)("Result").ToString = "AlreadyChanged" Then
                MessageBox.Show("该合同已被他人修改！即将重新加载合同。请重新审核。    " & Chr(13) & Chr(13) & "The contract had been modified! Please re-validate it after re-load.    ", "合同审核失败！ Contract validation failure!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Refresh()
                Try
                    Dim updatedContract As DataTable = DB.GetDataTable("Exec ContractSingle " & sContractID).Copy
                    Dim updatedCustomer As DataTable = DB.GetDataTable("Select CustomerID,InvoiceTitleCustomerID,InvoiceItem From ContractCustomer Where ContractID=" & sContractID).Copy, joinedCustomer As DataRow
                    For Each dr As DataRow In updatedCustomer.Rows
                        joinedCustomer = dtContractCustomer.Select("CustomerID=" & dr("CustomerID").ToString)(0)
                        joinedCustomer("InvoiceTitleCustomerID") = dr("InvoiceTitleCustomerID")
                        joinedCustomer("InvoiceItem") = dr("InvoiceItem")
                    Next
                    Dim updatedDetails As DataTable = DB.GetDataTable("Select * From ContractDetails Where ContractID=" & sContractID).Copy
                    For Each drDetail As DataRow In updatedDetails.Rows
                        If drDetail("StartSalesAMT") > 0 Then drDetail("StartSalesAMT") = drDetail("StartSalesAMT")
                        drDetail("RebateRate") = drDetail("RebateRate") * 100
                        drDetail.AcceptChanges()
                    Next
                    drContract = updatedContract.Copy.Rows(0)
                    dtContractDetails = updatedDetails.Copy
                    updatedContract.Dispose() : updatedContract = Nothing
                    updatedCustomer.Dispose() : updatedCustomer = Nothing
                    updatedDetails.Dispose() : updatedDetails = Nothing
                    dtContractCustomer.AcceptChanges()
                Catch
                    drContract.RejectChanges()
                    dtContractCustomer.RejectChanges()
                    dtContractDetails.RejectChanges()
                End Try

                Me.CheckValidation()
                blCanModify = ("|0|1|3|".IndexOf("|" & drContract("ContractState").ToString & "|") > -1 AndAlso frmMain.dtAllowedRight.Select("RightName='ContractModify'").Length > 0)
                Me.FillContract()

                dtResult.Dispose() : dtResult = Nothing : DB.Close()
                frmMain.statusText.Text = "保存合同审核结果失败！ Saving contract validatation failure! "
                Me.Cursor = Cursors.Default
                Return False
            ElseIf dtResult.Rows(0)("Result").ToString = "AlreadyValidated" Then
                MessageBox.Show("该合同已被他人审核！    " & Chr(13) & Chr(13) & "The contract had been validated by someone else!    ", "合同已被他人审核！Contract had been validated by someone else!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                drContract.RejectChanges()
                dtContractCustomer.RejectChanges()
                dtContractDetails.RejectChanges()
                drContract("ContractState") = dtResult.Rows(0)("ContractState")
                drContract("StateReason") = dtResult.Rows(0)("StateReason")
                drContract("ModifierName") = dtResult.Rows(0)("ModifierName")
                drContract("ModifiedTime") = dtResult.Rows(0)("ModifiedTime")
                drContract("FirstAuditorName") = dtResult.Rows(0)("FirstAuditorName")
                drContract("FirstValidatedTime") = dtResult.Rows(0)("FirstValidatedTime")
                drContract("AuditorName") = dtResult.Rows(0)("AuditorName")
                drContract("ValidatedTime") = dtResult.Rows(0)("ValidatedTime")
                drContract.AcceptChanges()
                Me.CheckValidation()
                blCanModify = ("|0|1|3|".IndexOf("|" & drContract("ContractState").ToString & "|") > -1 AndAlso frmMain.dtAllowedRight.Select("RightName='ContractModify'").Length > 0)
                Me.FillContract()

                dtResult.Dispose() : dtResult = Nothing : DB.Close()
                frmMain.statusText.Text = "保存合同审核结果失败！ Saving contract validatation failure! "
                Me.Cursor = Cursors.Default
                Return False
            ElseIf dtResult.Rows(0)("Result").ToString = "CityRuleChanged" Then
                Dim sCityIDs As String = "", sRuleIDs As String = "", dtNewestCityRule As DataTable, dtNewestRuleDetails As DataTable
                Try
                    For Each dr As DataRow In dtContractCustomer.Rows
                        sCityIDs = dr("CityID").ToString & ","
                    Next
                    sCityIDs = sCityIDs.Substring(0, sCityIDs.Length - 1)
                    dtNewestCityRule = DB.GetDataTable("Select * From CityRule Where CityID In (" & sCityID & ") And RuleState=2").Copy
                    If dtNewestCityRule.Rows.Count = 0 Then
                        dtNewestRuleDetails = DB.GetDataTable("Select * From CityRuleDetails Where RuleID=-1").Copy
                    Else
                        If sRuleIDs = "" Then
                            For Each dr As DataRow In dtNewestCityRule.Rows
                                sRuleIDs = dr("RuleID").ToString & ","
                            Next
                            sRuleIDs = sRuleIDs.Substring(0, sRuleIDs.Length - 1)
                        End If
                        dtNewestRuleDetails = DB.GetDataTable("Select * From CityRuleDetails Where RuleID In (" & sRuleIDs & ")").Copy
                    End If
                    dvNewestCityRule = dtNewestCityRule.DefaultView : dvNewestRuleDetails = dtNewestRuleDetails.DefaultView
                Catch
                    dtResult.Dispose() : dtResult = Nothing : DB.Close()
                    frmMain.statusText.Text = "保存合同审核结果失败！ Saving contract validatation failure! "
                    Me.Cursor = Cursors.Default
                    Return False
                End Try
                Me.CheckValidation()
                If blCanModify Then
                    GoTo Execute_Again
                Else
                    MessageBox.Show("城市返点规则已发生改变，您不再可审核该合同！    " & Chr(13) & _
                                    "City Discount Rule had been changed, you can not validate this contract anymore.    " & Chr(13) & Chr(13) & _
                                    "请找" & sApprovableRoleChineseNames & "审核该合同。    " & Chr(13) & _
                                    "Please let " & sApprovableRoleEnglishNames & " to validate it.    ", _
                                    "不能审核合同！Can not validate contract!", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.pnlContractState.Visible = True
                    drContract.RejectChanges()
                    If drContract("ContractState") = 0 Then
                        Me.txbContratState.Width = 610
                        Me.txbContratState.Text = "未审核；" & sValidationDescription & "； Not yet validated."
                        Me.pnlReason.Visible = False
                    Else
                        Me.txbContratState.Width = 299
                        Me.txbContratState.Text = "审核失败 Validated failure"
                        Me.pnlReason.Visible = True
                        Me.txbReason.Text = drContract("StateReason").ToString
                    End If
                    If Not blCanModify Then Me.Text = Me.Text & " (只读 Readonly)"
                    Me.btnSave.Enabled = False

                    dtResult.Dispose() : dtResult = Nothing : DB.Close()
                    frmMain.statusText.Text = "保存合同审核结果失败！ Saving contract validatation failure! "
                    Me.Cursor = Cursors.Default
                    Return False
                End If
            ElseIf dtResult.Rows(0)("Result").ToString = "OK" Then
                If Me.pnlFirstValidate.Visible Then
                    drContract("FirstAuditorName") = frmMain.sLoginUserRealName : drContract("FirstValidatedTime") = dtResult.Rows(0)("ValidatedTime")
                Else
                    drContract("AuditorName") = frmMain.sLoginUserRealName : drContract("ValidatedTime") = dtResult.Rows(0)("ValidatedTime")
                End If
                drContract.AcceptChanges()

                If drContract("ContractState") = 4 AndAlso drContract("StartDate") <= dtToday Then
                    Me.pnlValidate.Visible = False
                    Me.pnlContractState.Visible = True
                    Me.txbContratState.Text = "已审核且已生效 Validated and effective"
                    blCanValidate = False
                    blCanStop = (frmMain.dtAllowedRight.Select("RightName='ContractStop'").Length > 0)
                    Me.pnlStop.Visible = blCanStop
                    If Not blCanStop Then Me.Text = Me.Text & " (只读 Readonly)"
                End If

                If Me.pnlFirstValidate.Visible Then
                    Me.pnlFirstValidateInfo.Visible = True
                    Me.lblFirstAuditor.Text = frmMain.sLoginUserRealName
                    Me.lblFirstValidatedTime.Text = Format(dtResult.Rows(0)("ValidatedTime"), "yyyy\/MM\/dd HH:mm:ss")
                Else
                    Me.pnlValidateTitle.Visible = (drContract("FirstAuditorName").ToString <> "")
                    Me.pnlValidateInfo.Visible = True
                    Me.lblAuditor.Text = frmMain.sLoginUserRealName
                    Me.lblValidatedTime.Text = Format(dtResult.Rows(0)("ValidatedTime"), "yyyy\/MM\/dd HH:mm:ss")
                End If
                Me.grbOperation.Height = Me.tlpOperation.Height + 32

                If drContract("ContractState") = 4 AndAlso drContract("StartDate") <= dtToday AndAlso frmCustomerManagement.IsHandleCreated Then
                    Dim customer As DataRow, sContractCode As String = Me.txbCustomerCode.Text & Me.txbContractCode.Text
                    For Each joinedCustomer As DataRow In dtContractCustomer.Rows
                        Try
                            customer = frmCustomerManagement.dvCustomer.Table.Rows.Find(joinedCustomer("CustomerID"))
                            customer("ValidContractID") = sContractID
                            customer("ValidContractCode") = sContractCode
                            customer("InvalidContractID") = DBNull.Value
                            customer("InvalidContractCode") = DBNull.Value
                            customer.AcceptChanges() : customer = Nothing
                        Catch
                        End Try
                    Next
                    If frmCustomerManagement.dgvList.CurrentRow IsNot Nothing Then
                        frmCustomerManagement.dgvList.CurrentRow.Selected = False
                        frmCustomerManagement.dgvList.CurrentRow.Selected = True
                    End If
                End If

                If frmContractManagement.IsHandleCreated Then
                    Try
                        Dim contractRow As DataRow = frmContractManagement.dvContract.Table.Rows.Find(sContractID)
                        If drContract("ContractState") = 1 Then
                            contractRow("ContractStateDescription") = "初审失败 First Validated failure"
                        ElseIf drContract("ContractState") = 2 Then
                            contractRow("ContractStateDescription") = "初审成功 First Validated OK"
                        ElseIf drContract("ContractState") = 3 Then
                            contractRow("ContractStateDescription") = "审核失败 Validated failure"
                        ElseIf drContract("StartDate") <= dtToday Then
                            contractRow("ContractStateDescription") = "已审核且已生效 Validated and effective"
                            contractRow("SalesTimes") = dtResult.Rows(0)("SalesTimes")
                            contractRow("SalesAMT") = dtResult.Rows(0)("SalesAMT")
                            contractRow("RebateAMT") = dtResult.Rows(0)("RebateAMT")
                            contractRow("AverageRebateRate") = dtResult.Rows(0)("AverageRebateRate")
                            contractRow("PaidRebateAMT") = dtResult.Rows(0)("PaidRebateAMT")
                            contractRow("BalanceRebateAMT") = dtResult.Rows(0)("BalanceRebateAMT")
                        Else
                            contractRow("ContractStateDescription") = "已审核但未生效 Validated but not yet effective"
                            contractRow("SalesTimes") = 0
                            contractRow("SalesAMT") = 0
                            contractRow("RebateAMT") = 0
                            contractRow("AverageRebateRate") = 0
                            contractRow("PaidRebateAMT") = 0
                            contractRow("BalanceRebateAMT") = 0
                        End If
                        contractRow("ContractState") = drContract("ContractState")
                        contractRow.EndEdit() : contractRow.AcceptChanges()
                        contractRow = Nothing
                    Catch
                    End Try
                End If

                blSkipDeal = True
                If Me.dgvCustomer.CurrentCell IsNot Nothing Then Me.dgvCustomer.CurrentCell.Selected = False
                If Me.dgvCustomer.CurrentRow IsNot Nothing Then Me.dgvCustomer.CurrentRow.Selected = False
                If Me.dgvDetails.CurrentCell IsNot Nothing Then Me.dgvDetails.CurrentCell.Selected = False
                If Me.dgvDetails.CurrentRow IsNot Nothing Then Me.dgvDetails.CurrentRow.Selected = False
                blSkipDeal = False

                Me.grbPartyA.Select()
                Me.txbContratState.Select() : Me.txbContratState.SelectAll()
                Me.btnSave.Enabled = False

                If drContract("ContractState") = 2 Then
                    MessageBox.Show("保存合同审核结果成功。Contract validation sucessfully.    " & Chr(13) & Chr(13) & "该合同还需总部审核，请联系总部。    " & Chr(13) & "The contract need HO validation, please contact with HO.    ", "保存合同审核结果成功。Contract validation sucessfully.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("保存合同审核结果成功。Contract validation sucessfully.    ", "保存合同审核结果成功。Contract validation sucessfully.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                dtResult.Dispose() : dtResult = Nothing : DB.Close()
                frmMain.statusText.Text = "保存合同审核结果成功。Contract validation sucessfully."
                Me.Cursor = Cursors.Default
                blContentChanged = False
                Return True
            Else
                MessageBox.Show("保存合同审核结果时出现错误！下面是数据库的内部错误提示：    " & Chr(13) & Chr(13) & dtResult.Rows(0)("ErrorInfo").ToString & Space(4) & Chr(13) & Chr(13) & "请放弃保存，在关闭窗口后重试。如果仍有问题，请联系软件开发人员。    ", "保存合同失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                dtResult.Dispose() : dtResult = Nothing : DB.Close()
                frmMain.statusText.Text = "保存合同审核结果失败！ Saving contract validatation failure! "
                Me.Cursor = Cursors.Default
                Return False
            End If
        Else '停用合同
            If MessageBox.Show("注意：合同一旦被停用，便不可撤销！    " & Chr(13) & _
                               "Once you stop this contract, it will be unable to rollback to normal status!     " & Chr(13) & Chr(13) & _
                               "您是否确实想停用该合同？    " & Chr(13) & _
                               "Do you really want to stop it?    ", _
                               "请确认停用合同 Please confirm to stop:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                frmMain.statusText.Text = "您已经取消保存。 You have cancelled saving."
                Me.Cursor = Cursors.Default
                Return False
            End If
            Me.Refresh()

            sSQL = "Exec ContractStop @ContractID=" & sContractID & ",@StateReason='" & drContract("StateReason").ToString.Replace("'", "''") & "',@OperatorName='" & frmMain.sLoginUserRealName.Replace("'", "''") & "',@SSID=" & frmMain.sSSID
            dtResult = DB.GetDataTable(sSQL)

            If dtResult Is Nothing Then
                DB.Close()
                frmMain.statusText.Text = "保存合同停用结果失败！ Saving contract stopping failure! "
                Me.Cursor = Cursors.Default
                Return False
            ElseIf dtResult.Rows(0)("Result").ToString = "Error" Then
                MessageBox.Show("保存合同停用结果时出现错误！下面是数据库的内部错误提示：    " & Chr(13) & Chr(13) & dtResult.Rows(0)("ErrorInfo").ToString & Space(4) & Chr(13) & Chr(13) & "请放弃保存，在关闭窗口后重试。如果仍有问题，请联系软件开发人员。    ", "保存合同失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                dtResult.Dispose() : dtResult = Nothing : DB.Close()
                frmMain.statusText.Text = "保存合同停用结果失败！ Saving contract stopping failure! "
                Me.Cursor = Cursors.Default
                Return False
            Else
                If dtResult.Rows(0)("Result").ToString = "AlreadyStopped" Then
                    drContract("StateReason") = dtResult.Rows(0)("StateReason").ToString
                    drContract("StopperName") = frmMain.sLoginUserRealName
                Else
                    drContract("StopperName") = frmMain.sLoginUserRealName
                End If
                drContract("StoppedTime") = dtResult.Rows(0)("StoppedTime")
                drContract.AcceptChanges()

                Me.txbContratState.Width = 299
                Me.txbContratState.Text = "已审核但已停用 Validated but already stopped"
                Me.pnlReason.Visible = True
                Me.txbReason.Text = drContract("StateReason").ToString
                Me.pnlStop.Visible = False
                blCanStop = False

                Me.pnlStoppedPeriod.Visible = True
                Me.txbStoppedDate.Text = Format(drContract("StoppedTime"), "yyyy\/MM\/dd")

                Me.pnlStopInfo.Visible = True
                Me.lblStopper.Text = drContract("StopperName").ToString
                Me.lblValidatedTime.Text = Format(drContract("StoppedTime"), "yyyy\/MM\/dd HH:mm:ss")
                Me.grbOperation.Height = Me.tlpOperation.Height + 32

                Me.Text = Me.Text & " (只读 Readonly)"

                If frmCustomerManagement.IsHandleCreated Then
                    Dim customer As DataRow
                    For Each joinedCustomer As DataRow In dtContractCustomer.Rows
                        Try
                            customer = frmCustomerManagement.dvCustomer.Table.Rows.Find(joinedCustomer("CustomerID"))
                            customer("ValidContractID") = DBNull.Value
                            customer("ValidContractCode") = DBNull.Value
                            customer.AcceptChanges() : customer = Nothing
                        Catch
                        End Try
                    Next
                    If frmCustomerManagement.dgvList.CurrentRow IsNot Nothing Then
                        frmCustomerManagement.dgvList.CurrentRow.Selected = False
                        frmCustomerManagement.dgvList.CurrentRow.Selected = True
                    End If
                End If

                If frmContractManagement.IsHandleCreated Then
                    Try
                        Dim contractRow As DataRow = frmContractManagement.dvContract.Table.Rows.Find(sContractID)
                        contractRow("StoppedDate") = drContract("StoppedTime")
                        contractRow("ContractStateDescription") = "已审核但已停用 Validated but already stopped"
                        contractRow("ContractState") = drContract("ContractState")
                        contractRow.EndEdit() : contractRow.AcceptChanges()
                        contractRow = Nothing
                        frmContractManagement.dgvList.Columns("StoppedDate").Visible = True
                    Catch
                    End Try
                End If

                blSkipDeal = True
                If Me.dgvCustomer.CurrentCell IsNot Nothing Then Me.dgvCustomer.CurrentCell.Selected = False
                If Me.dgvCustomer.CurrentRow IsNot Nothing Then Me.dgvCustomer.CurrentRow.Selected = False
                If Me.dgvDetails.CurrentCell IsNot Nothing Then Me.dgvDetails.CurrentCell.Selected = False
                If Me.dgvDetails.CurrentRow IsNot Nothing Then Me.dgvDetails.CurrentRow.Selected = False
                blSkipDeal = False

                Me.grbPartyA.Select()
                Me.txbContratState.Select() : Me.txbContratState.SelectAll()
                Me.btnSave.Enabled = False : Me.btnPrint.Enabled = False

                If dtResult.Rows(0)("Result").ToString = "AlreadyStopped" Then
                    MessageBox.Show("该合同已被他人停用。The Contract had been stopped by someone else.    ", "合同已被他人停用。Contract stopped by someone else.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    frmMain.statusText.Text = "该合同已被他人停用。The Contract had been stopped by someone else. "
                Else
                    MessageBox.Show("合同已停用。Contract had been stopped.    ", "合同已停用。Contract had been stopped.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    frmMain.statusText.Text = "合同已停用。Contract had been stopped.."
                End If

                dtResult.Dispose() : dtResult = Nothing : DB.Close()
                Me.Cursor = Cursors.Default
                blContentChanged = False
                Return True
            End If
        End If
    End Function
End Class
