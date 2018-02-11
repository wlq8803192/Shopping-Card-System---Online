'modify code 001:
'date;2013/7/19 
'auther:Hyron zyx 
'remark:银商报表下载，月销售明细报表追加，日统计、日明细报表变更

'modify code 002:
'date;2013/9/23 
'auther:Hyron zyx 
'remark:银商报表下载，预付卡商户、分店积分兑换福卡日、月报表

'modify code 010:
'date;2013/12/24 
'auther:Hyron bjy 
'remark:银商报表下载，联名卡返现消费明细日报表-门店/JV/总部、联名卡返现消费统计日/月报表-门店/JV/总部、联名卡帐户余额变动报表（日报表）-总部

'modify code 013:
'date;2014/2/17 
'auther:Hyron bjy 
'remark:增加礼品卡激活报表9张

'modify code 024:
'date;2014/5/27
'auther:Hyron bjy 
'remark:更改数据库连接获取方式为webservice

'modify code 037:
'date;2014/8/7
'auther:Carreofour Eros
'remark:更改银商报表下载为web

Public Class frmCULReport

    Private dtMerchant As DataTable, sPath As String = "", blHaveReports As Boolean = False, blSkipDeal As Boolean = True, sRemarks As String
    'modify code 001:start-------------------------------------------------------------------------
    '家乐福总部售卡虚拟门店（102210054111029）
    Private HO_MERCHANT_NO As String = "102210054111029"
    Private HO_CORPORAT_NO As String = "086021541111289"
    Private blHaveGiftCardReports As Boolean = False
    'modify code 001:end-------------------------------------------------------------------------
    'modify code 010:start-------------------------------------------------------------------------
    Private blHaveMemberCardReports As Boolean = False
    'modify code 010:end-------------------------------------------------------------------------

    Private Sub frmCULReport_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.trvDate.Select()
        If Me.trvDate.SelectedNode IsNot Nothing Then
            Me.trvDate.SelectedNode.BackColor = SystemColors.Window
            Me.trvDate.SelectedNode.ForeColor = SystemColors.ControlText
        End If
    End Sub

    Private Sub frmCULReport_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        If Me.trvDate.SelectedNode IsNot Nothing Then
            Me.trvDate.SelectedNode.BackColor = SystemColors.Highlight
            Me.trvDate.SelectedNode.ForeColor = SystemColors.HighlightText
        End If

        If Me.trvMerchant.SelectedNode IsNot Nothing Then
            Me.trvMerchant.SelectedNode.BackColor = SystemColors.Highlight
            Me.trvMerchant.SelectedNode.ForeColor = SystemColors.HighlightText
        End If
    End Sub

    Private Sub frmCULReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DB As New DataBase()
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打开""银商报表下载""窗口。请检查数据库连接。"
            Me.Close() : Return
        End If

        dtMerchant = DB.GetDataTable("Exec GetCULMerchant " & frmMain.sLoginUserID)
        DB.Close()
        If dtMerchant Is Nothing Then
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开""银商报表下载""窗口。请联系软件开发人员。"
            Me.Close() : Return
        ElseIf dtMerchant.Rows.Count = 0 Then
            MessageBox.Show("系统因找不到对应的银商公司店铺而无法打开""银商报表下载""窗口。    " & Chr(13) & Chr(13) & "请联系总部添加相应的银商公司店铺。    ", "找不到银商公司店铺！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "系统因找不到对应的银商公司店铺而无法打开""银商报表下载""窗口。请联系总部添加相应的银商公司店铺。"
            Me.Close() : Return
        End If

        Dim sYear As String = "", sPreviousYear As String = "", sMonth As String = "", sPreviousMonth As String = "", dtDate As Date = Today(), nodeYear As TreeNode = Nothing, nodeMonth As TreeNode = Nothing
        For iDay As Integer = DateDiff(DateInterval.Day, CDate("2011-7-1"), Today()) - 1 To 0 Step -1
            dtDate = DateAdd(DateInterval.Day, -1, dtDate)
            sYear = Year(dtDate).ToString
            If sYear <> sPreviousYear Then
                nodeYear = Me.trvDate.Nodes.Add(sYear, "年 Year: " & sYear)
                sPreviousMonth = ""
                sPreviousYear = sYear
            End If
            sMonth = Format(Month(dtDate), "00")
            If sMonth <> sPreviousMonth Then
                nodeMonth = nodeYear.Nodes.Add(sYear & sMonth, "月 Month: " & sMonth)
                sPreviousMonth = sMonth
            End If
            nodeMonth.Nodes.Add(Format(dtDate, "yyyyMMdd"), "日期 Date: " & Format(dtDate, "yyyy\/MM\/dd"))
        Next
        Me.trvDate.Refresh()

        If frmMain.sLoginAreaType = "S" Then
            Me.trvMerchant.Nodes.Add(dtMerchant.Rows(0)("CorporatNo").ToString, dtMerchant.Rows(0)("CorporatNo").ToString & "-" & dtMerchant.Rows(0)("CorporatName").ToString).Tag = "No"
            Me.trvMerchant.Nodes(0).Nodes.Add(dtMerchant.Rows(0)("MerchantNo").ToString, dtMerchant.Rows(0)("MerchantNo").ToString & "-" & dtMerchant.Rows(0)("MerchantName").ToString).Tag = "Yes"
        Else
            Dim sPreviousCorporatNo As String = "", sCorporatNo As String = "", nodeIssuer As TreeNode = Nothing
            For Each drMerchant As DataRow In dtMerchant.Rows
                'modify code 001:start-------------------------------------------------------------------------
                '非总部用户登录，将不会显示家乐福总部售卡虚拟门店
                If HO_MERCHANT_NO = drMerchant("MerchantNo").ToString And frmMain.sLoginAreaType <> "H" Then
                    Continue For
                End If
                'modify code 001:end-------------------------------------------------------------------------
                sCorporatNo = drMerchant("CorporatNo").ToString
                If sCorporatNo <> sPreviousCorporatNo Then
                    nodeIssuer = Me.trvMerchant.Nodes.Add(sCorporatNo, sCorporatNo & "-" & drMerchant("CorporatName").ToString)
                    If drMerchant("TotalMerchants") = drMerchant("AvailableMerchants") Then
                        nodeIssuer.Tag = "Yes"
                    Else
                        nodeIssuer.Tag = "No"
                    End If
                    sPreviousCorporatNo = sCorporatNo
                End If
                nodeIssuer.Nodes.Add(drMerchant("MerchantNo").ToString, drMerchant("MerchantNo").ToString & "-" & drMerchant("MerchantName").ToString).Tag = "Yes"
            Next
        End If
        Me.trvMerchant.Refresh()

        Dim iHalfHeight As Integer = (Me.splLeft.Height - 55) / 2, iDateHeight As Integer = Me.trvDate.GetNodeCount(True) * 18 + 4, iMerchantHeight As Integer = Me.trvMerchant.GetNodeCount(True) * 18 + 4
        Try
            If iDateHeight < iHalfHeight Then
                Me.splLeft.SplitterDistance = iDateHeight + 25
            ElseIf iMerchantHeight < iHalfHeight Then
                Me.splLeft.SplitterDistance = Me.splLeft.Height - iMerchantHeight - 30
            Else
                Me.splLeft.SplitterDistance = Me.splLeft.Height / 2 - 2
            End If
        Catch
        End Try
        If Me.trvMerchant.VisibleCount = 1 Then
            Try
                Me.splLeft.SplitterDistance -= 18
            Catch
            End Try
        End If
        blSkipDeal = False
    End Sub

    Private Sub splMain_SplitterMoved(ByVal sender As Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles splMain.SplitterMoved, splLeft.SplitterMoved
        Me.trvDate.Select()
    End Sub

    Private Sub trvDate_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvDate.AfterSelect
        If Me.trvDate.SelectedNode.Name.Length = 4 Then
            Me.trvDate.SelectedNode = Me.trvDate.SelectedNode.Nodes(0)
            Return
        End If

        If blSkipDeal OrElse Me.trvMerchant.SelectedNode Is Nothing Then Return
        Me.CreateReportList()
    End Sub

    Private Sub trvDate_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles trvDate.Enter
        If Me.trvDate.SelectedNode IsNot Nothing Then
            Me.trvDate.SelectedNode.BackColor = SystemColors.Window
            Me.trvDate.SelectedNode.ForeColor = SystemColors.ControlText
        End If
    End Sub

    Private Sub trvDate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles trvDate.Leave
        If Me.trvDate.SelectedNode IsNot Nothing Then
            Me.trvDate.SelectedNode.BackColor = SystemColors.Highlight
            Me.trvDate.SelectedNode.ForeColor = SystemColors.HighlightText
        End If
    End Sub

    Private Sub trvMerchant_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvMerchant.AfterSelect
        If Me.trvMerchant.SelectedNode.Tag.ToString = "No" Then
            Me.trvMerchant.SelectedNode = Me.trvMerchant.SelectedNode.Nodes(0)
            Return
        End If

        If blSkipDeal OrElse Me.trvDate.SelectedNode Is Nothing Then Return
        Me.CreateReportList()
    End Sub

    Private Sub trvMerchant_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles trvMerchant.Enter
        If Me.trvMerchant.SelectedNode IsNot Nothing Then
            Me.trvMerchant.SelectedNode.BackColor = SystemColors.Window
            Me.trvMerchant.SelectedNode.ForeColor = SystemColors.ControlText
        End If
    End Sub

    Private Sub trvMerchant_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles trvMerchant.Leave
        If Me.trvMerchant.SelectedNode IsNot Nothing Then
            Me.trvMerchant.SelectedNode.BackColor = SystemColors.Highlight
            Me.trvMerchant.SelectedNode.ForeColor = SystemColors.HighlightText
        End If
    End Sub

    'modify code 037:start-------------------------------------------------------------------------
    ''modify code 001、002、010、013:start-------------------------------------------------------------------------
    ''新增控件添加linkclciked事件
    'Private Sub LMS207_MONTH_IssuerId_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles _
    '            LMS207_MONTH_IssuerId.LinkClicked, LMS102B_CorporatNo_BYMER.LinkClicked, LMS102B_CorporatNo.LinkClicked, LMS102C_IssuerId_BYMER.LinkClicked, LMS102C_IssuerId.LinkClicked, _
    '            LMS207_MONTH_USER_IssuerId.LinkClicked, LMS102B_CorporatNo_BYMER_MerchantNo.LinkClicked, LMS102B_CorporatNo_MerchantNo.LinkClicked, LMS102C_IssuerId_MerchantNo.LinkClicked, _
    '            LMS207_MONTH_USER_IssuerId_MerchantNo.LinkClicked, LMS207_IssuerId.LinkClicked, LMS207_LIST_WEB_IssuerId.LinkClicked, LMS002C_IssuerId.LinkClicked, LMS002B_CorporatNo.LinkClicked, _
    '            LMS001B_CorporatNo.LinkClicked, LMS001C_IssuerId.LinkClicked, LMS002C_IssuerId_BYMER.LinkClicked, LMS207_CARDLIST_IssuerId.LinkClicked, LMS207_USER_IssuerId.LinkClicked, LMS207_CARDTYPE_IssuerId_MerchantNo.LinkClicked, _
    '            LMS207_LIST_WEB_IssuerId_MerchantNo.LinkClicked, LMS002B_CorporatNo_MerchantNo.LinkClicked, LMS001B_CorporatNo_MerchantNo.LinkClicked, LMS002C_IssuerId_MerchantNo.LinkClicked, LMS207_USER_IssuerId_MerchantNo.LinkClicked, _
    '            voucher_IssuerId_301_M.LinkClicked, voucher_IssuerId_302_M.LinkClicked, VOUCHER301_IssuerId_M.LinkClicked, VOUCHER302_IssuerId_M.LinkClicked, Voucher207_list_IssuerId.LinkClicked, Voucher001B_IssuerId.LinkClicked, voucher_IssuerId_301.LinkClicked, voucher_IssuerId_302.LinkClicked, voucher_IssuerId_303.LinkClicked, _
    '            Voucher001B_IssuerId_MerchantNo.LinkClicked, VOUCHER301_IssuerId.LinkClicked, VOUCHER302_IssuerId.LinkClicked, VOUCHER303_IssuerId.LinkClicked, LMS302_C4P_MerchantNo.LinkClicked, LMS301_C4P_MerchantNo.LinkClicked, _
    '            LMS301_MONTH_C4P_MerchantNo.LinkClicked, LMS302_MONTH_C4P_MerchantNo.LinkClicked, LMS301_C4P_MerchantNo.LinkClicked, LMS302_C4P_MerchantNo.LinkClicked, _
    '            LMS207_MONTH_POS_IssuerId_MerchantNo.LinkClicked, LMS207_LIST_POS_IssuerId.LinkClicked, LMS207_LIST_C4PDS_issuerId_merchantNo.LinkClicked, LMS207_C4PDS_issuerId_merchantNo.LinkClicked, _
    '            Voucher001B_CorporatNo_MerchantNo_N.LinkClicked, Voucher001B_CorporatNo_N.LinkClicked, LMS301_IssuerId_N.LinkClicked, LMS302_IssuerId_N.LinkClicked, LMS301_MONTH_IssuerId_N.LinkClicked, LMS302_MONTH_IssuerId_N.LinkClicked, _
    '            LMS207_MONTH_C4PDS_IssuerId_merchantNo.LinkClicked, LMS207_LIST_C4PDS_issuerId.LinkClicked, LMS207_C4PDS_issuerId.LinkClicked, LMS207_MONTH_C4PDS_IssuerId.LinkClicked, LMS207_MONTH_C4PDS.LinkClicked, LMS207_LIST_C4PDS.LinkClicked, LMS207_C4PDS.LinkClicked, LMS207_LIST_POS_IssuerId_MerchantNo.LinkClicked, LMS207_POS_IssuerId_MerchantNo.LinkClicked, _
    '            LMS207_LIST_JFDH_IssuerId.LinkClicked, LMS207_LIST_JFDH_IssuerId_MerchantNo.LinkClicked, LMS207_MONTH_JFDH_IssuerId.LinkClicked, LMS207_MONTH_JFDH_IssuerId_MerchantNo.LinkClicked, _
    '            CSM001C_C4PLMK.LinkClicked, CSM002C_C4PLMK.LinkClicked, CSM303_C4PLMK.LinkClicked, _
    '            CSM001B_C4PLMK_issuerID.LinkClicked, CSM002B_C4PLMK_issuerID.LinkClicked, _
    '            CSM001B_C4PLMK_issuerID_merchantNo.LinkClicked, CSM002B_C4PLMK_issuerID_merchantNo.LinkClicked, _
    '            CSM102C_C4PLMK.LinkClicked, CSM102B_C4PLMK_issuerID.LinkClicked, CSM102B_C4PLMK_issuerID_merchantNo.LinkClicked, _
    '            LMS207_LIST_C4PDS_JH.LinkClicked, LMS207_C4PDS_JH.LinkClicked, LMS207_MONTH_C4PDS_JH.LinkClicked, _
    '            LMS207_LIST_C4PDS_issuerId_JH.LinkClicked, LMS207_C4PDS_issuerId_JH.LinkClicked, LMS207_MONTH_C4PDS_IssuerId_JH.LinkClicked, _
    '            LMS207_LIST_C4PDS_issuerId_merchantNo_JH.LinkClicked, LMS207_C4PDS_issuerId_merchantNo_JH.LinkClicked, LMS207_MONTH_C4PDS_IssuerId_merchantNo_JH.LinkClicked
    '    'modify code 001:end-------------------------------------------------------------------------

    '    Dim theLink As LinkLabel = CType(sender, LinkLabel), sReportURL As String = sPath & theLink.Text, sTargetFile As String = "", saveDialog As New SaveFileDialog
    '    sRemarks = Me.trvMerchant.SelectedNode.Text & "|" & Me.trvDate.SelectedNode.Text & "|"
    '    For Each theControl As Control In theLink.Parent.Controls
    '        If theControl.Name.IndexOf("Label") = 0 Then
    '            sRemarks = sRemarks & theControl.Text
    '            Exit For
    '        End If
    '    Next
    '    Me.DownloadReport(sPath & theLink.Text)
    '    theLink.LinkVisited = True
    'End Sub

    'Private Sub CreateReportList()
    '    Me.Cursor = Cursors.WaitCursor
    '    For Each myControl As Control In Me.flpReport.Controls
    '        myControl.Visible = False
    '    Next

    '    'modify code 024:start-------------------------------------------------------------------------
    '    'sPath = "http://10.132.203.180/CULReports/" : blHaveReports = False
    '    sPath = frmMain.sCulReportConnection : blHaveReports = False
    '    'modify code 024:end-------------------------------------------------------------------------
    '    Dim sDate As String = "", sIssuerId As String = "", sCorporatNo As String = "", sMerchantNo As String = "", bReports As Byte = 0
    '    If Me.trvDate.SelectedNode.Name.Length = 6 Then '月
    '        Me.pnlTitleMonthly.Visible = True
    '        Me.pnlLineMonthly.Visible = True

    '        Me.pnlTitleDaily.Visible = False
    '        Me.pnlLineDaily.Visible = False
    '        Me.flpIssuerDaily.Visible = False
    '        Me.flpIssuerDailyPaperCard.Visible = False
    '        Me.flpIssuerDailyGiftCard.Visible = False
    '        Me.flpMerchantDaily.Visible = False
    '        Me.flpMerchantDailyPaperCard.Visible = False
    '        Me.flpMerchantDailyGiftCard.Visible = False

    '        sDate = Format(DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, CDate(Me.trvDate.SelectedNode.Name.Insert(4, "/") & "/01"))), "yyyyMMdd")
    '        Me.lblTitleMonthly.Text = "日期： " & sDate.Substring(0, 4) & "/" & sDate.Substring(4, 2) & "/01-" & sDate.Substring(0, 4) & "/" & sDate.Substring(4, 2) & "/" & sDate.Substring(6, 2) & Space(2)
    '        If sDate = Me.trvDate.SelectedNode.Nodes(0).Name Then
    '            If Me.trvMerchant.SelectedNode.Level = 0 Then '发卡机构
    '                Me.lblTitleMonthly.Text = Me.lblTitleMonthly.Text & "公司： " & Me.trvMerchant.SelectedNode.Text

    '                Me.flpIssuerMonthly.Visible = True
    '                For Each childControl As Control In Me.flpIssuerMonthly.Controls
    '                    childControl.Visible = False
    '                Next
    '                Me.flpMerchantMonthly.Visible = False
    '                Me.flpMerchantMonthlyGiftCard.Visible = False
    '                Me.Refresh()

    '                sCorporatNo = Me.trvMerchant.SelectedNode.Name
    '                sIssuerId = dtMerchant.Select("CorporatNo='" & sCorporatNo & "'")(0)("IssuerId").ToString
    '                sPath = sPath & sDate & "/" & sCorporatNo & "/"

    '                Me.LMS207_MONTH_IssuerId.Text = "LMS207_MONTH_" & sIssuerId & ".xls"
    '                Me.CheckFileExists(Me.LMS207_MONTH_IssuerId)
    '                Me.LMS301_MONTH_IssuerId_N.Text = "LMS301_MONTH_" & sIssuerId & "_N.xls"
    '                Me.CheckFileExists(Me.LMS301_MONTH_IssuerId_N)
    '                Me.LMS207_MONTH_USER_IssuerId.Text = "LMS207_MONTH_USER_" & sIssuerId & ".xls"
    '                Me.CheckFileExists(Me.LMS207_MONTH_USER_IssuerId)
    '                Me.LMS102C_IssuerId.Text = "LMS102C_" & sIssuerId & ".xls"
    '                Me.CheckFileExists(Me.LMS102C_IssuerId)
    '                Me.LMS302_MONTH_IssuerId_N.Text = "LMS302_MONTH_" & sIssuerId & "_N.xls"
    '                Me.CheckFileExists(Me.LMS302_MONTH_IssuerId_N)
    '                Me.LMS102B_CorporatNo_BYMER.Text = "LMS102B_" & sCorporatNo & "_BYMER.xls"
    '                Me.CheckFileExists(Me.LMS102B_CorporatNo_BYMER)
    '                Me.LMS102B_CorporatNo.Text = "LMS102B_" & sCorporatNo & ".xls"
    '                Me.CheckFileExists(Me.LMS102B_CorporatNo)
    '                Me.LMS102C_IssuerId_BYMER.Text = "LMS102C_" & sIssuerId & "_BYMER.xls"
    '                Me.CheckFileExists(Me.LMS102C_IssuerId_BYMER)
    '                'modify code 002:start-------------------------------------------------------------------------
    '                Me.LMS207_MONTH_JFDH_IssuerId.Text = "LMS207_MONTH_JFDH_" & sIssuerId & ".xls"
    '                Me.CheckFileExists(Me.LMS207_MONTH_JFDH_IssuerId)
    '                'modify code 002:end-------------------------------------------------------------------------
    '                Me.pnlNoIssuerMonthly.Visible = Not blHaveReports

    '                blHaveReports = False
    '                Me.voucher_IssuerId_301_M.Text = "voucher_" & sIssuerId & "_301_M.txt"
    '                Me.CheckFileExists(Me.voucher_IssuerId_301_M)
    '                Me.voucher_IssuerId_302_M.Text = "voucher_" & sIssuerId & "_302_M.txt"
    '                Me.CheckFileExists(Me.voucher_IssuerId_302_M)
    '                Me.VOUCHER301_IssuerId_M.Text = "VOUCHER301_" & sIssuerId & "_M.xls"
    '                Me.CheckFileExists(Me.VOUCHER301_IssuerId_M)
    '                Me.VOUCHER302_IssuerId_M.Text = "VOUCHER302_" & sIssuerId & "_M.xls"
    '                Me.CheckFileExists(Me.VOUCHER302_IssuerId_M)
    '                Me.flpIssuerMonthlyPaperCard.Visible = blHaveReports
    '                'modify code 001:start-------------------------------------------------------------------------
    '                blHaveReports = False
    '                'JV礼品卡月销售报表:
    '                Me.LMS207_MONTH_C4PDS_IssuerId.Text = "LMS207_MONTH_C4PDS_" & sIssuerId & ".xls"
    '                Me.CheckFileExists(Me.LMS207_MONTH_C4PDS_IssuerId)
    '                'modify code 001:end-------------------------------------------------------------------------
    '                'modify code 013:start-------------------------------------------------------------------------
    '                'JV礼品卡月销售激活报表:
    '                Me.LMS207_MONTH_C4PDS_IssuerId_JH.Text = "LMS207_MONTH_C4PDS_" & sIssuerId & "_JH.xls"
    '                Me.CheckFileExists(Me.LMS207_MONTH_C4PDS_IssuerId_JH)
    '                'modify code 013:end-------------------------------------------------------------------------
    '                Me.flpIssuerMonthlyGiftCard.Visible = blHaveReports

    '            Else '分店
    '                'modify code 001:start-------------------------------------------------------------------------
    '                '总部虚拟分店
    '                If HO_MERCHANT_NO = Me.trvMerchant.SelectedNode.Name Then
    '                    Me.lblTitleMonthly.Text = Me.lblTitleMonthly.Text & "总部： " & Me.trvMerchant.SelectedNode.Text

    '                    sPath = sPath & sDate & "/" & HO_CORPORAT_NO & "/"

    '                    'modify code 010:start-------------------------------------------------------------------------
    '                    '总部礼品卡月销售报表:
    '                    blHaveReports = False
    '                    blHaveGiftCardReports = False
    '                    Me.LMS207_MONTH_C4PDS.Text = "LMS207_MONTH_C4PDS.xls"
    '                    Me.CheckFileExists(Me.LMS207_MONTH_C4PDS)
    '                    'modify code 013:start-------------------------------------------------------------------------
    '                    '总部礼品卡月销售激活报表:
    '                    Me.LMS207_MONTH_C4PDS_JH.Text = "LMS207_MONTH_C4PDS_JH.xls"
    '                    Me.CheckFileExists(Me.LMS207_MONTH_C4PDS_JH)
    '                    'modify code 013:end-------------------------------------------------------------------------
    '                    Me.flpMonthlyGiftCard.Visible = blHaveReports
    '                    blHaveGiftCardReports = blHaveReports

    '                    'If Not blHaveReports Then
    '                    '    Me.flpMerchantMonthly.Visible = True
    '                    '    For Each childControl As Control In Me.flpMerchantMonthly.Controls
    '                    '        childControl.Visible = False
    '                    '    Next
    '                    '    Me.pnlNoMerchantMonthly.Visible = True
    '                    'End If
    '                    If Not blHaveGiftCardReports Then
    '                        Me.flpMerchantMonthly.Visible = True
    '                        For Each childControl As Control In Me.flpMerchantMonthly.Controls
    '                            childControl.Visible = False
    '                        Next
    '                        Me.pnlNoMerchantMonthly.Visible = True
    '                    End If
    '                    'modify code 010:end-------------------------------------------------------------------------
    '                Else
    '                    'modify code 001:end-------------------------------------------------------------------------
    '                    Me.lblTitleMonthly.Text = Me.lblTitleMonthly.Text & "分店： " & Me.trvMerchant.SelectedNode.Text

    '                    Me.flpIssuerMonthly.Visible = False
    '                    Me.flpIssuerMonthlyPaperCard.Visible = False
    '                    Me.flpMerchantMonthly.Visible = True
    '                    For Each childControl As Control In Me.flpMerchantMonthly.Controls
    '                        childControl.Visible = False
    '                    Next
    '                    Me.Refresh()

    '                    sCorporatNo = Me.trvMerchant.SelectedNode.Parent.Name
    '                    sIssuerId = dtMerchant.Select("CorporatNo='" & sCorporatNo & "'")(0)("IssuerId").ToString
    '                    sMerchantNo = Me.trvMerchant.SelectedNode.Name
    '                    sPath = sPath & sDate & "/" & sCorporatNo & "/"

    '                    Me.LMS301_MONTH_C4P_MerchantNo.Text = "LMS301_MONTH_C4P_" & sMerchantNo & ".xls"
    '                    Me.CheckFileExists(Me.LMS301_MONTH_C4P_MerchantNo)
    '                    Me.LMS302_MONTH_C4P_MerchantNo.Text = "LMS302_MONTH_C4P_" & sMerchantNo & ".xls"
    '                    Me.CheckFileExists(Me.LMS302_MONTH_C4P_MerchantNo)
    '                    Me.LMS102B_CorporatNo_BYMER_MerchantNo.Text = "LMS102B_" & sCorporatNo & "_BYMER_" & sMerchantNo & ".xls"
    '                    Me.CheckFileExists(Me.LMS102B_CorporatNo_BYMER_MerchantNo)
    '                    Me.LMS102B_CorporatNo_MerchantNo.Text = "LMS102B_" & sCorporatNo & "_" & sMerchantNo & ".xls"
    '                    Me.CheckFileExists(Me.LMS102B_CorporatNo_MerchantNo)
    '                    Me.LMS102C_IssuerId_MerchantNo.Text = "LMS102C_" & sIssuerId & "_" & sMerchantNo & ".xls"
    '                    Me.CheckFileExists(Me.LMS102C_IssuerId_MerchantNo)
    '                    Me.LMS207_MONTH_USER_IssuerId_MerchantNo.Text = "LMS207_MONTH_USER_" & sIssuerId & "_" & sMerchantNo & ".xls"
    '                    Me.CheckFileExists(Me.LMS207_MONTH_USER_IssuerId_MerchantNo)
    '                    'modify code 002:start-------------------------------------------------------------------------
    '                    Me.LMS207_MONTH_JFDH_IssuerId_MerchantNo.Text = "LMS207_MONTH_JFDH_" & sIssuerId & "_" & sMerchantNo & ".xls"
    '                    Me.CheckFileExists(Me.LMS207_MONTH_JFDH_IssuerId_MerchantNo)
    '                    'modify code 002:end-------------------------------------------------------------------------
    '                    Me.pnlNoMerchantMonthly.Visible = Not blHaveReports

    '                    blHaveReports = False
    '                    'modify code 001:start-------------------------------------------------------------------------
    '                    blHaveGiftCardReports = False
    '                    Me.LMS207_MONTH_POS_IssuerId_MerchantNo.Text = "LMS207_MONTH_POS_" & sCorporatNo & "_" & sMerchantNo & ".xls"
    '                    Me.CheckFileExists(Me.LMS207_MONTH_POS_IssuerId_MerchantNo)
    '                    If blHaveReports Then
    '                        blHaveGiftCardReports = True
    '                    End If
    '                    '分店礼品卡月销售报表:
    '                    Me.LMS207_MONTH_C4PDS_IssuerId_merchantNo.Text = "LMS207_MONTH_C4PDS_" & sIssuerId & "_" & sMerchantNo & ".xls"
    '                    Me.CheckFileExists(Me.LMS207_MONTH_C4PDS_IssuerId_merchantNo)
    '                    'modify code 013:start-------------------------------------------------------------------------
    '                    '分店礼品卡月销售激活报表:
    '                    Me.LMS207_MONTH_C4PDS_IssuerId_merchantNo_JH.Text = "LMS207_MONTH_C4PDS_" & sIssuerId & "_" & sMerchantNo & "_JH.xls"
    '                    Me.CheckFileExists(Me.LMS207_MONTH_C4PDS_IssuerId_merchantNo_JH)
    '                    'modify code 013:end-------------------------------------------------------------------------
    '                    If blHaveReports Then
    '                        blHaveGiftCardReports = True
    '                    End If
    '                    Me.flpMerchantMonthlyGiftCard.Visible = blHaveGiftCardReports
    '                    'modify code 001:end-------------------------------------------------------------------------

    '                End If
    '            End If
    '        Else
    '            Me.lblTitleMonthly.Text = Me.lblTitleMonthly.Text & IIf(Me.trvMerchant.SelectedNode.Level = 0, "公司： ", "分店： ") & Me.trvMerchant.SelectedNode.Text

    '            Me.flpIssuerMonthly.Visible = False
    '            Me.flpIssuerMonthlyPaperCard.Visible = False
    '            Me.flpMerchantMonthly.Visible = True
    '            Me.LMS301_MONTH_C4P_MerchantNo.Parent.Visible = False
    '            Me.LMS302_MONTH_C4P_MerchantNo.Parent.Visible = False
    '            Me.LMS102B_CorporatNo_BYMER_MerchantNo.Parent.Visible = False
    '            Me.LMS102B_CorporatNo_MerchantNo.Parent.Visible = False
    '            Me.LMS102C_IssuerId_MerchantNo.Parent.Visible = False
    '            Me.LMS207_MONTH_USER_IssuerId_MerchantNo.Parent.Visible = False
    '            Me.pnlNoMerchantMonthly.Visible = True
    '            Me.flpMerchantMonthlyGiftCard.Visible = False
    '        End If
    '    Else '日
    '        Me.pnlTitleDaily.Visible = True
    '        Me.pnlLineDaily.Visible = True

    '        Me.pnlTitleMonthly.Visible = False
    '        Me.pnlLineMonthly.Visible = False
    '        Me.flpIssuerMonthly.Visible = False
    '        Me.flpIssuerMonthlyPaperCard.Visible = False
    '        Me.flpMerchantMonthly.Visible = False
    '        Me.flpMerchantMonthlyGiftCard.Visible = False

    '        sDate = Me.trvDate.SelectedNode.Name
    '        Me.lblTitleDaily.Text = "日期： " & sDate.Substring(0, 4) & "/" & sDate.Substring(4, 2) & "/" & sDate.Substring(6, 2) & Space(2)
    '        If Me.trvMerchant.SelectedNode.Level = 0 Then '发卡机构
    '            Me.lblTitleDaily.Text = Me.lblTitleDaily.Text & "公司： " & Me.trvMerchant.SelectedNode.Text

    '            Me.flpIssuerDaily.Visible = True
    '            For Each childControl As Control In Me.flpIssuerDaily.Controls
    '                childControl.Visible = False
    '            Next
    '            Me.flpMerchantDaily.Visible = False
    '            Me.flpMerchantDailyPaperCard.Visible = False
    '            Me.flpMerchantDailyGiftCard.Visible = False
    '            Me.Refresh()

    '            sCorporatNo = Me.trvMerchant.SelectedNode.Name
    '            sIssuerId = dtMerchant.Select("CorporatNo='" & sCorporatNo & "'")(0)("IssuerId").ToString
    '            sPath = sPath & sDate & "/" & sCorporatNo & "/"

    '            Me.LMS207_IssuerId.Text = "LMS207_" & sIssuerId & ".xls"
    '            Me.CheckFileExists(Me.LMS207_IssuerId)
    '            Me.LMS301_IssuerId_N.Text = "LMS301_" & sIssuerId & "_N.xls"
    '            Me.CheckFileExists(Me.LMS301_IssuerId_N)
    '            Me.LMS207_LIST_WEB_IssuerId.Text = "LMS207_LIST_WEB_" & sIssuerId & ".xls"
    '            Me.CheckFileExists(Me.LMS207_LIST_WEB_IssuerId)
    '            Me.LMS207_CARDLIST_IssuerId.Text = "LMS207_CARDLIST_" & sIssuerId & ".xls"
    '            Me.CheckFileExists(Me.LMS207_CARDLIST_IssuerId)
    '            Me.LMS207_USER_IssuerId.Text = "LMS207_USER_" & sIssuerId & ".xls"
    '            Me.CheckFileExists(Me.LMS207_USER_IssuerId)
    '            Me.LMS002C_IssuerId.Text = "LMS002C_" & sIssuerId & ".xls"
    '            Me.CheckFileExists(Me.LMS002C_IssuerId)
    '            Me.LMS302_IssuerId_N.Text = "LMS302_" & sIssuerId & "_N.xls"
    '            Me.CheckFileExists(Me.LMS302_IssuerId_N)
    '            Me.LMS002B_CorporatNo.Text = "LMS002B_" & sCorporatNo & ".xls"
    '            Me.CheckFileExists(Me.LMS002B_CorporatNo)
    '            Me.LMS001B_CorporatNo.Text = "LMS001B_" & sCorporatNo & ".xls"
    '            Me.CheckFileExists(Me.LMS001B_CorporatNo)
    '            Me.LMS001C_IssuerId.Text = "LMS001C_" & sIssuerId & ".xls"
    '            Me.CheckFileExists(Me.LMS001C_IssuerId)
    '            Me.LMS002C_IssuerId_BYMER.Text = "LMS002C_" & sIssuerId & "_BYMER.xls"
    '            Me.CheckFileExists(Me.LMS002C_IssuerId_BYMER)
    '            'modify code 002:start-------------------------------------------------------------------------
    '            Me.LMS207_LIST_JFDH_IssuerId.Text = "LMS207_LIST_JFDH_" & sIssuerId & ".xls"
    '            Me.CheckFileExists(Me.LMS207_LIST_JFDH_IssuerId)
    '            'modify code 002:end-------------------------------------------------------------------------
    '            Me.pnlNoIssuerDaily.Visible = Not blHaveReports

    '            blHaveReports = False
    '            Me.Voucher207_list_IssuerId.Text = "Voucher207_list_" & sIssuerId & ".xls"
    '            Me.CheckFileExists(Me.Voucher207_list_IssuerId)
    '            Me.Voucher001B_IssuerId.Text = "Voucher001B_" & sIssuerId & ".xls"
    '            Me.CheckFileExists(Me.Voucher001B_IssuerId)
    '            Me.Voucher001B_CorporatNo_N.Text = "Voucher001B_" & sCorporatNo & "_N.xls"
    '            Me.CheckFileExists(Me.Voucher001B_CorporatNo_N)
    '            Me.voucher_IssuerId_301.Text = "voucher_" & sIssuerId & "_301.txt"
    '            Me.CheckFileExists(Me.voucher_IssuerId_301)
    '            Me.voucher_IssuerId_302.Text = "voucher_" & sIssuerId & "_302.txt"
    '            Me.CheckFileExists(Me.voucher_IssuerId_302)
    '            Me.voucher_IssuerId_303.Text = "voucher_" & sIssuerId & "_303.txt"
    '            Me.CheckFileExists(Me.voucher_IssuerId_303)
    '            Me.VOUCHER301_IssuerId.Text = "VOUCHER301_" & sIssuerId & ".xls"
    '            Me.CheckFileExists(Me.VOUCHER301_IssuerId)
    '            Me.VOUCHER302_IssuerId.Text = "VOUCHER302_" & sIssuerId & ".xls"
    '            Me.CheckFileExists(Me.VOUCHER302_IssuerId)
    '            Me.VOUCHER303_IssuerId.Text = "VOUCHER303_" & sIssuerId & ".xls"
    '            Me.CheckFileExists(Me.VOUCHER303_IssuerId)
    '            Me.flpIssuerDailyPaperCard.Visible = blHaveReports

    '            blHaveReports = False
    '            'modify code 001:start-------------------------------------------------------------------------
    '            blHaveGiftCardReports = False
    '            Me.LMS207_LIST_POS_IssuerId.Text = "LMS207_LIST_POS_" & sIssuerId & ".xls"
    '            Me.CheckFileExists(Me.LMS207_LIST_POS_IssuerId)
    '            If blHaveReports Then
    '                blHaveGiftCardReports = True
    '            End If
    '            'JV礼品卡日销售明细报表
    '            Me.LMS207_LIST_C4PDS_issuerId.Text = "LMS207_LIST_C4PDS_" & sIssuerId & ".xls"
    '            Me.CheckFileExists(Me.LMS207_LIST_C4PDS_issuerId)
    '            'modify code 013:start-------------------------------------------------------------------------
    '            'JV礼品卡日销售明细激活报表
    '            Me.LMS207_LIST_C4PDS_issuerId_JH.Text = "LMS207_LIST_C4PDS_" & sIssuerId & "_JH.xls"
    '            Me.CheckFileExists(Me.LMS207_LIST_C4PDS_issuerId_JH)
    '            'modify code 013:end-------------------------------------------------------------------------
    '            If blHaveReports Then
    '                blHaveGiftCardReports = True
    '            End If
    '            'JV礼品卡日销售统计报表
    '            Me.LMS207_C4PDS_issuerId.Text = "LMS207_C4PDS_" & sIssuerId & ".xls"
    '            Me.CheckFileExists(Me.LMS207_C4PDS_issuerId)
    '            'modify code 013:start-------------------------------------------------------------------------
    '            'JV礼品卡日销售统计激活报表
    '            Me.LMS207_C4PDS_issuerId_JH.Text = "LMS207_C4PDS_" & sIssuerId & "_JH.xls"
    '            Me.CheckFileExists(Me.LMS207_C4PDS_issuerId_JH)
    '            'modify code 013:end-------------------------------------------------------------------------
    '            If blHaveReports Then
    '                blHaveGiftCardReports = True
    '            End If
    '            Me.flpIssuerDailyGiftCard.Visible = blHaveGiftCardReports
    '            'modify code 001:end-------------------------------------------------------------------------

    '            'modify code 010:start-------------------------------------------------------------------------
    '            blHaveReports = False
    '            'JV联名卡返现消费明细日报表:
    '            Me.CSM001B_C4PLMK_issuerID.Text = "CSM001B_C4PLMK_" & sIssuerId & ".xls"
    '            Me.CheckFileExists(Me.CSM001B_C4PLMK_issuerID)
    '            'JV联名卡返现消费统计日报表:
    '            Me.CSM002B_C4PLMK_issuerID.Text = "CSM002B_C4PLMK_" & sIssuerId & ".xls"
    '            Me.CheckFileExists(Me.CSM002B_C4PLMK_issuerID)
    '            Me.flpIssuerDailyMemberCard.Visible = blHaveReports

    '            blHaveReports = False
    '            'JV联名卡返现消费统计月报表:
    '            Me.CSM102B_C4PLMK_issuerID.Text = "CSM102B_C4PLMK_" & sIssuerId & ".xls"
    '            Me.CheckFileExists(Me.CSM102B_C4PLMK_issuerID)
    '            Me.flpIssuerMonthlyMemberCard.Visible = blHaveReports
    '            'modify code 010:end-------------------------------------------------------------------------

    '        Else '分店
    '            'modify code 001:start-------------------------------------------------------------------------
    '            '总部虚拟分店
    '            If HO_MERCHANT_NO = Me.trvMerchant.SelectedNode.Name Then
    '                Me.lblTitleDaily.Text = Me.lblTitleDaily.Text & "总部： " & Me.trvMerchant.SelectedNode.Text

    '                sPath = sPath & sDate & "/" & HO_CORPORAT_NO & "/"

    '                'modify code 010:start-------------------------------------------------------------------------
    '                blHaveReports = False
    '                blHaveGiftCardReports = False
    '                '总部礼品卡日销售明细报表
    '                Me.LMS207_LIST_C4PDS.Text = "LMS207_LIST_C4PDS.xls"
    '                Me.CheckFileExists(Me.LMS207_LIST_C4PDS)
    '                'modify code 013:start-------------------------------------------------------------------------
    '                '总部礼品卡日销售明细激活报表
    '                Me.LMS207_LIST_C4PDS_JH.Text = "LMS207_LIST_C4PDS_JH.xls"
    '                Me.CheckFileExists(Me.LMS207_LIST_C4PDS_JH)
    '                'modify code 013:end-------------------------------------------------------------------------
    '                '总部礼品卡日销售统计报表
    '                Me.LMS207_C4PDS.Text = "LMS207_C4PDS.xls"
    '                Me.CheckFileExists(Me.LMS207_C4PDS)
    '                'modify code 013:start-------------------------------------------------------------------------
    '                '总部礼品卡日销售统计激活报表
    '                Me.LMS207_C4PDS_JH.Text = "LMS207_C4PDS_JH.xls"
    '                Me.CheckFileExists(Me.LMS207_C4PDS_JH)
    '                'modify code 013:end-------------------------------------------------------------------------
    '                Me.flpDailyGiftCard.Visible = blHaveReports
    '                blHaveGiftCardReports = blHaveReports

    '                blHaveReports = False
    '                blHaveMemberCardReports = False
    '                '总部联名卡返现消费明细日报表:
    '                Me.CSM001C_C4PLMK.Text = "CSM001C_C4PLMK.xls"
    '                Me.CheckFileExists(Me.CSM001C_C4PLMK)
    '                '总部联名卡返现消费统计日报表:
    '                Me.CSM002C_C4PLMK.Text = "CSM002C_C4PLMK.xls"
    '                Me.CheckFileExists(Me.CSM002C_C4PLMK)
    '                '总部联名卡帐户余额变动报表:
    '                Me.CSM303_C4PLMK.Text = "CSM303_C4PLMK.xls"
    '                Me.CheckFileExists(Me.CSM303_C4PLMK)
    '                Me.flpDailyMemberCard.Visible = blHaveReports

    '                '总部联名卡返现消费统计月报表:
    '                blHaveReports = False
    '                Me.CSM102C_C4PLMK.Text = "CSM102C_C4PLMK.xls"
    '                Me.CheckFileExists(Me.CSM102C_C4PLMK)
    '                Me.flpMonthlyMemberCard.Visible = blHaveReports

    '                blHaveMemberCardReports = Me.flpDailyMemberCard.Visible And Me.flpMonthlyMemberCard.Visible

    '                'If Not blHaveReports Then
    '                '    Me.flpMerchantDaily.Visible = True
    '                '    For Each childControl As Control In Me.flpMerchantDaily.Controls
    '                '        childControl.Visible = False
    '                '    Next
    '                '    Me.pnlNoMerchantDaily.Visible = True
    '                'End If
    '                If Not blHaveGiftCardReports And Not blHaveMemberCardReports Then
    '                    Me.flpMerchantDaily.Visible = True
    '                    For Each childControl As Control In Me.flpMerchantDaily.Controls
    '                        childControl.Visible = False
    '                    Next
    '                    Me.pnlNoMerchantDaily.Visible = True
    '                End If
    '                'modify code 010:end-------------------------------------------------------------------------
    '            Else
    '                'modify code 001:end-------------------------------------------------------------------------
    '                Me.lblTitleDaily.Text = Me.lblTitleDaily.Text & "分店： " & Me.trvMerchant.SelectedNode.Text

    '                Me.flpIssuerDaily.Visible = False
    '                Me.flpIssuerDailyPaperCard.Visible = False
    '                Me.flpIssuerDailyGiftCard.Visible = False
    '                Me.flpMerchantDaily.Visible = True
    '                For Each childControl As Control In Me.flpMerchantDaily.Controls
    '                    childControl.Visible = False
    '                Next
    '                Me.Refresh()

    '                sCorporatNo = Me.trvMerchant.SelectedNode.Parent.Name
    '                sIssuerId = dtMerchant.Select("CorporatNo='" & sCorporatNo & "'")(0)("IssuerId").ToString
    '                sMerchantNo = Me.trvMerchant.SelectedNode.Name
    '                sPath = sPath & sDate & "/" & sCorporatNo & "/"

    '                Me.LMS207_CARDTYPE_IssuerId_MerchantNo.Text = "LMS207_CARDTYPE_" & sIssuerId & "_" & sMerchantNo & ".xls"
    '                Me.CheckFileExists(Me.LMS207_CARDTYPE_IssuerId_MerchantNo)
    '                Me.LMS207_LIST_WEB_IssuerId_MerchantNo.Text = "LMS207_LIST_WEB_" & sIssuerId & "_" & sMerchantNo & ".xls"
    '                Me.CheckFileExists(Me.LMS207_LIST_WEB_IssuerId_MerchantNo)
    '                Me.LMS002B_CorporatNo_MerchantNo.Text = "LMS002B_" & sCorporatNo & "_" & sMerchantNo & ".xls"
    '                Me.CheckFileExists(Me.LMS002B_CorporatNo_MerchantNo)
    '                Me.LMS001B_CorporatNo_MerchantNo.Text = "LMS001B_" & sCorporatNo & "_" & sMerchantNo & ".xls"
    '                Me.CheckFileExists(Me.LMS001B_CorporatNo_MerchantNo)
    '                Me.LMS002C_IssuerId_MerchantNo.Text = "LMS002C_" & sIssuerId & "_" & sMerchantNo & ".xls"
    '                Me.CheckFileExists(Me.LMS002C_IssuerId_MerchantNo)
    '                Me.LMS207_USER_IssuerId_MerchantNo.Text = "LMS207_USER_" & sIssuerId & "_" & sMerchantNo & ".xls"
    '                Me.CheckFileExists(Me.LMS207_USER_IssuerId_MerchantNo)
    '                Me.LMS301_C4P_MerchantNo.Text = "LMS301_C4P_" & sMerchantNo & ".xls"
    '                Me.CheckFileExists(Me.LMS301_C4P_MerchantNo)
    '                Me.LMS302_C4P_MerchantNo.Text = "LMS302_C4P_" & sMerchantNo & ".xls"
    '                Me.CheckFileExists(Me.LMS302_C4P_MerchantNo)
    '                'modify code 002:start-------------------------------------------------------------------------
    '                Me.LMS207_LIST_JFDH_IssuerId_MerchantNo.Text = "LMS207_LIST_JFDH_" & sIssuerId & "_" & sMerchantNo & ".xls"
    '                Me.CheckFileExists(Me.LMS207_LIST_JFDH_IssuerId_MerchantNo)
    '                'modify code 002:end-------------------------------------------------------------------------
    '                Me.pnlNoMerchantDaily.Visible = Not blHaveReports

    '                blHaveReports = False
    '                Me.Voucher001B_IssuerId_MerchantNo.Text = "Voucher001B_" & sIssuerId & "_" & sMerchantNo & ".xls"
    '                Me.CheckFileExists(Me.Voucher001B_IssuerId_MerchantNo)
    '                Me.Voucher001B_CorporatNo_MerchantNo_N.Text = "Voucher001B_" & sCorporatNo & "_" & sMerchantNo & "_N.xls"
    '                Me.CheckFileExists(Me.Voucher001B_CorporatNo_MerchantNo_N)
    '                Me.flpMerchantDailyPaperCard.Visible = blHaveReports

    '                blHaveReports = False
    '                'modify code 001:start-------------------------------------------------------------------------
    '                blHaveGiftCardReports = False
    '                Me.LMS207_LIST_POS_IssuerId_MerchantNo.Text = "LMS207_LIST_POS_" & sIssuerId & "_" & sMerchantNo & ".xls"
    '                Me.CheckFileExists(Me.LMS207_LIST_POS_IssuerId_MerchantNo)
    '                If blHaveReports Then
    '                    blHaveGiftCardReports = True
    '                End If
    '                Me.LMS207_POS_IssuerId_MerchantNo.Text = "LMS207_POS_" & sIssuerId & "_" & sMerchantNo & ".xls"
    '                Me.CheckFileExists(Me.LMS207_POS_IssuerId_MerchantNo)
    '                If blHaveReports Then
    '                    blHaveGiftCardReports = True
    '                End If
    '                '分店礼品卡日销售明细报表
    '                Me.LMS207_LIST_C4PDS_issuerId_merchantNo.Text = "LMS207_LIST_C4PDS_" & sIssuerId & "_" & sMerchantNo & ".xls"
    '                Me.CheckFileExists(Me.LMS207_LIST_C4PDS_issuerId_merchantNo)
    '                'modify code 013:start-------------------------------------------------------------------------
    '                '分店礼品卡日销售明细激活报表
    '                Me.LMS207_LIST_C4PDS_issuerId_merchantNo_JH.Text = "LMS207_LIST_C4PDS_" & sIssuerId & "_" & sMerchantNo & "_JH.xls"
    '                Me.CheckFileExists(Me.LMS207_LIST_C4PDS_issuerId_merchantNo_JH)
    '                'modify code 013:end-------------------------------------------------------------------------
    '                If blHaveReports Then
    '                    blHaveGiftCardReports = True
    '                End If
    '                '分店礼品卡日销售统计报表
    '                Me.LMS207_C4PDS_issuerId_merchantNo.Text = "LMS207_C4PDS_" & sIssuerId & "_" & sMerchantNo & ".xls"
    '                Me.CheckFileExists(Me.LMS207_C4PDS_issuerId_merchantNo)
    '                'modify code 013:start-------------------------------------------------------------------------
    '                '分店礼品卡日销售统计激活报表
    '                Me.LMS207_C4PDS_issuerId_merchantNo_JH.Text = "LMS207_C4PDS_" & sIssuerId & "_" & sMerchantNo & "_JH.xls"
    '                Me.CheckFileExists(Me.LMS207_C4PDS_issuerId_merchantNo_JH)
    '                'modify code 013:end-------------------------------------------------------------------------
    '                If blHaveReports Then
    '                    blHaveGiftCardReports = True
    '                End If
    '                Me.flpMerchantDailyGiftCard.Visible = blHaveGiftCardReports
    '                'modify code 001:end-------------------------------------------------------------------------

    '                'modify code 010:start-------------------------------------------------------------------------
    '                blHaveReports = False
    '                '分店联名卡返现消费明细日报表:
    '                Me.CSM001B_C4PLMK_issuerID_merchantNo.Text = "CSM001B_C4PLMK_" & sIssuerId & "_" & sMerchantNo & ".xls"
    '                Me.CheckFileExists(Me.CSM001B_C4PLMK_issuerID_merchantNo)
    '                '分店联名卡返现消费统计日报表:
    '                Me.CSM002B_C4PLMK_issuerID_merchantNo.Text = "CSM002B_C4PLMK_" & sIssuerId & "_" & sMerchantNo & ".xls"
    '                Me.CheckFileExists(Me.CSM002B_C4PLMK_issuerID_merchantNo)
    '                Me.flpMerchantDailyMemberCard.Visible = blHaveReports

    '                blHaveReports = False
    '                '分店联名卡返现消费统计月报表:
    '                Me.CSM102B_C4PLMK_issuerID_merchantNo.Text = "CSM102B_C4PLMK_" & sIssuerId & "_" & sMerchantNo & ".xls"
    '                Me.CheckFileExists(Me.CSM102B_C4PLMK_issuerID_merchantNo)
    '                Me.flpMerchantMonthlyMemberCard.Visible = blHaveReports
    '                'modify code 010:end-------------------------------------------------------------------------

    '            End If
    '        End If
    '    End If
    '    Me.Cursor = Cursors.Default
    'End Sub

    'Private Sub CheckFileExists(ByRef theLink As LinkLabel)
    '    Dim myRequest As System.Net.WebRequest, myResponse As System.Net.WebResponse = Nothing, sURL As String = sPath & theLink.Text, blExists As Boolean = False, iLength As Long = 0
    '    Try
    '        myRequest = System.Net.WebRequest.Create(sURL)
    '        myRequest.Proxy = Nothing
    '        myRequest.Timeout = 10000
    '        myResponse = myRequest.GetResponse()
    '        iLength = myResponse.ContentLength
    '        blExists = True
    '    Catch
    '    Finally
    '        Try
    '            myResponse.Close()
    '            myRequest = Nothing
    '        Catch
    '        End Try
    '    End Try

    '    If blExists Then
    '        theLink.LinkVisited = False
    '        theLink.Parent.Controls(theLink.Name & "_Size").Text = "(" & Format(Int((iLength + 1023) / 1024), "#,0") & "KB)"
    '        theLink.Parent.Visible = True : blHaveReports = True
    '        theLink.Parent.Refresh()
    '    Else
    '        theLink.Parent.Visible = False
    '    End If
    'End Sub

    'Private Sub DownloadReport(ByVal sReportURL As String)
    '    Dim startInfo As New ProcessStartInfo("IExplore.exe")
    '    startInfo.CreateNoWindow = True
    '    startInfo.WindowStyle = ProcessWindowStyle.Hidden
    '    startInfo.Arguments = sReportURL
    '    Dim myProcess As Process = Process.Start(startInfo)
    '    myProcess.Close()
    '    myProcess.Dispose()
    '    myProcess = Nothing
    '    ReportingLog.InsertLog("银商报表下载", sReportURL, sRemarks)
    'End Sub

    Private Sub CreateReportList()
        Dim strHeaders As String = "Content-Type: application/x-www-form-urlencoded" & vbCrLf
        Dim strPostdata As String = ""
        Dim sDate As String = "", sIssuerId As String = "", sCorporatNo As String = "", sMerchantNo As String = "", sStoreName As String = "", sDept As String = ""
        sDate = trvDate.SelectedNode.Name
        If (trvMerchant.SelectedNode.Level > 0) Then
            sCorporatNo = trvMerchant.SelectedNode.Parent.Name
        Else
            sCorporatNo = trvMerchant.SelectedNode.Name
        End If

        sMerchantNo = IIf(trvMerchant.SelectedNode.Level = 0, "0", trvMerchant.SelectedNode.Name)
        sIssuerId = dtMerchant.Select("CorporatNo='" & sCorporatNo & "'")(0)("IssuerId").ToString
        If (sMerchantNo = "0") Then
            sStoreName = dtMerchant.Select("CorporatNo='" & sCorporatNo & "'")(0)("CorporatName").ToString
        Else
            sStoreName = dtMerchant.Select("MerchantNo='" & sMerchantNo & "'")(0)("MerchantName").ToString
        End If
        If sMerchantNo = HO_MERCHANT_NO Then
            sDept = "HO"
            sCorporatNo = HO_CORPORAT_NO
        Else
            sDept = IIf(trvMerchant.SelectedNode.Level = 0, "JV", "Store")
        End If
        strPostdata = String.Format("QueryDate={0}", sDate)
        strPostdata += String.Format("&CorporatNo={0}", sCorporatNo)
        strPostdata += String.Format("&MerchantNo={0}", sMerchantNo)
        strPostdata += String.Format("&IssuerId={0}", sIssuerId)
        strPostdata += String.Format("&strStoreName={0}", sStoreName)
        strPostdata += String.Format("&Dept={0}", sDept)
        Dim bPostdata() As Byte = System.Text.Encoding.UTF8.GetBytes(strPostdata)
        WebBrowserCUL.Navigate(frmMain.sCULReportWeb, Nothing, bPostdata, strHeaders)
        WebBrowserCUL.IsWebBrowserContextMenuEnabled = False
    End Sub
    'modify code 037:end-------------------------------------------------------------------------
End Class