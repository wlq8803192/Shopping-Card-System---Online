
'modify code 055:
'date;2016/03/25
'auther:BJY 
'remark:对账报表导出去除Excel格式

'modify code 056:
'date;2016/03/25
'auther:BJY 
'remark:对账报表付款方式显示明细

'modify code 071:
'date;2017/03/31
'auther:Qipeng
'remark:对账报表修改

Public Class frmCheckAccount

    Dim sStartTime As String = "", sEndTime As String = ""

    Private Sub frmCheckAccount_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'modify code 055:start-------------------------------------------------------------------------
        For Each re In Me.ReportViewer1.LocalReport.ListRenderingExtensions()
            If re.Name = "Excel" Then
                Dim fi As System.Reflection.FieldInfo = re.GetType().GetField("m_isVisible", Reflection.BindingFlags.Instance + Reflection.BindingFlags.NonPublic)
                fi.SetValue(re, False)
            End If
        Next
        'modify code 055:end-------------------------------------------------------------------------
        Me.btnQuery.PerformClick()
    End Sub

    Private Sub dtpFrom_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFrom.ValueChanged, dtpTo.ValueChanged
        Me.btnQuery.Enabled = True
    End Sub

    Private Sub btnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        Dim sStart As String = Format(Me.dtpFrom.Value, "yyyy\/MM\/dd HH:mm") & ":00", sEnd As String = Format(Me.dtpTo.Value, "yyyy\/MM\/dd HH:mm") & ":00"
        If sStart > sEnd Then
            Me.dtpFrom.Value = CDate(sEnd)
            Me.dtpTo.Value = CDate(sStart)
            sStart = Format(Me.dtpFrom.Value, "yyyy\/MM\/dd HH:mm") & ":00"
            sEnd = Format(Me.dtpTo.Value, "yyyy\/MM\/dd HH:mm") & ":00"
        End If
        sEnd = Format(DateAdd(DateInterval.Minute, 1, CDate(sEnd)), "yyyy\/MM\/dd HH:mm") & ":00"
        If sStart = sStartTime AndAlso sEnd = sEndTime Then
            Me.btnQuery.Enabled = False
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        Me.lblStatus.ForeColor = Color.Blue
        Me.lblStatus.Text = "正在生成报表……"

        Dim DB As New DataBase()
        DB.Open()
        If Not DB.IsConnected Then
            Me.lblStatus.ForeColor = Color.Red
            Me.lblStatus.Text = "系统因连接不到数据库而无法生成报表。请检查数据库连接。"
            frmMain.statusText.Text = "系统因连接不到数据库而无法生成报表。请检查数据库连接。"
            Return
        End If

        Dim dtHeader As DataTable = DB.GetDataTable("Exec GetSalesmanCheckingHeader " & frmMain.sLoginUserID & ", '" & sStart & "','" & sEnd & "'")
        If dtHeader Is Nothing Then
            Me.lblStatus.ForeColor = Color.Red
            Me.lblStatus.Text = "系统因在检索数据时出错而无法生成报表。请联系软件开发人员。"
            frmMain.statusText.Text = "系统因在检索数据时出错而无法生成报表。请联系软件开发人员。"
            DB.Close() : Return
        End If
        Dim dtPayment As DataTable = DB.GetDataTable("Exec GetSalesmanPayment " & frmMain.sLoginUserID & ", '" & sStart & "','" & sEnd & "'")
        If dtPayment Is Nothing Then
            Me.lblStatus.ForeColor = Color.Red
            Me.lblStatus.Text = "系统因在检索数据时出错而无法生成报表。请联系软件开发人员。"
            frmMain.statusText.Text = "系统因在检索数据时出错而无法生成报表。请联系软件开发人员。"
            dtHeader.Dispose() : dtHeader = Nothing
            DB.Close() : Return
        End If
        dtPayment = dtPayment.DefaultView.ToTable(True, "PaymentID", "PaymentTerm", "PaymentAMT", "GuarantyByCash")
        'modify code 056:start-------------------------------------------------------------------------
        'Dim dtDetails As DataTable = DB.GetDataTable("Exec GetSalesmanCheckingReport " & frmMain.sLoginUserID & ", '" & sStart & "','" & sEnd & "'")
        Dim dtDetails As DataTable = DB.GetDataTable("Exec GetSalesmanCheckingReport_D " & frmMain.sLoginUserID & ", '" & sStart & "','" & sEnd & "'")
        'modify code 056:end-------------------------------------------------------------------------
        DB.Close()
        If dtDetails Is Nothing Then
            Me.lblStatus.ForeColor = Color.Red
            Me.lblStatus.Text = "系统因在检索数据时出错而无法生成报表。请联系软件开发人员。"
            frmMain.statusText.Text = "系统因在检索数据时出错而无法生成报表。请联系软件开发人员。"
            dtHeader.Dispose() : dtHeader = Nothing
            dtPayment.Dispose() : dtPayment = Nothing
            Me.Close() : Return
        End If

        Dim drHeader As DataRow = Me.DsCheckAccountHeader.dtCheckAccountHeader.Rows.Add()
        drHeader("StoreName") = frmMain.dtLoginStructure.Rows.Find(frmMain.sLoginAreaID)("AreaName")
        drHeader("InsidSalesmanName") = frmMain.sLoginUserRealName
        drHeader("SalesDate") = Format(frmSalesBillManagement.dtpSalesDate.Value, "yyyy\/MM\/dd")
        drHeader("SalesPeriod") = "从 " & Format(Me.dtpFrom.Value, "HH:mm") & " 到 " & Format(Me.dtpTo.Value, "HH:mm")

        Dim dtTemp As DataTable = dtDetails.DefaultView.ToTable(True, "SalesBillCode", "SalesBillType", "CardCost"), sValue As String = Format(dtTemp.Rows.Count, "#,0") & " 笔 （一般销售单："
        Try
            sValue = sValue & Format(dtTemp.Select("SalesBillType='一般销售单'").Length, "#,0") & " 笔；退货销售单："
        Catch
            sValue = sValue & "0 笔；退货销售单："
        End Try
        Try
            sValue = sValue & Format(dtTemp.Select("SalesBillType='退货销售单'").Length, "#,0") & " 笔；活动卡销售单："
        Catch
            sValue = sValue & "0 笔；活动卡销售单："
        End Try
        Try
            sValue = sValue & Format(dtTemp.Select("SalesBillType='活动卡销售单'").Length, "#,0") & " 笔；员工销售单：" '公关卡销售单："
        Catch
            sValue = sValue & "0 笔；员工销售单：" '公关卡销售单："
        End Try
        'Try
        '    sValue = sValue & Format(dtTemp.Select("SalesBillType='公关卡销售单'").Length, "#,0") & " 笔；员工销售单："
        'Catch
        '    sValue = sValue & "0 笔；员工销售单："
        'End Try
        If "|34|272|".IndexOf(frmMain.dtLoginStructure.Rows.Find(frmMain.sLoginAreaID)("ParentAreaID").ToString) > -1 Then '大连联名卡
            Try
                sValue = sValue & Format(dtTemp.Select("SalesBillType='员工销售单'").Length, "#,0") & " 笔；实名制卡销售单："
            Catch
                sValue = sValue & "0 笔；实名制卡销售单："
            End Try
            'Try
            '    sValue = sValue & Format(dtTemp.Select("SalesBillType='联名卡销售单'").Length, "#,0") & " 笔；实名制卡销售单："
            'Catch
            '    sValue = sValue & "0 笔；实名制卡销售单："
            'End Try
        Else
            Try
                sValue = sValue & Format(dtTemp.Select("SalesBillType='员工销售单'").Length, "#,0") & " 笔；实名制卡销售单："
            Catch
                sValue = sValue & "0 笔；实名制卡销售单："
            End Try
        End If

        'modify code 071:start-------------------------------------------------------------------------
        Try
            sValue = sValue & Format(dtTemp.Select("SalesBillType='实名制卡销售单'").Length, "#,0") & " 笔；非实名制卡销售单："
        Catch
            sValue = sValue & "0 笔；非实名制卡销售单："
        End Try
        Try
            sValue = sValue & Format(dtTemp.Select("SalesBillType='通卖非实名卡销售单'").Length, "#,0") & " 笔）"
        Catch
            sValue = sValue & "0 笔）"
        End Try
        'modify code 071:end-------------------------------------------------------------------------

        drHeader("SalesBillCount") = sValue

        sValue = Format(dtHeader.Rows(0)("CardQTY"), "#,0") & " 张 （正常卡："
        Try
            sValue = sValue & Format(dtDetails.Compute("Sum(CardQTY)", "SalesBillType In ('一般销售单','员工销售单','联名卡销售单') And PaymentTermName<> '（返点卡）'"), "#,0") & " 张；返点卡："
        Catch
            sValue = sValue & " 0 张；返点卡："
        End Try
        Try
            sValue = sValue & Format(dtDetails.Compute("Sum(CardQTY)", "PaymentTermName='（返点卡）'"), "#,0") & " 张；退货卡："
        Catch
            sValue = sValue & " 0 张；退货卡："
        End Try
        Try
            sValue = sValue & Format(dtDetails.Compute("Sum(CardQTY)", "PaymentTermName='（退货卡）'"), "#,0") & " 张；活动卡："
        Catch
            sValue = sValue & " 0 张；活动卡："
        End Try
        Try
            sValue = sValue & Format(dtDetails.Compute("Sum(CardQTY)", "SalesBillType='活动卡销售单'"), "#,0") & " 张；实名制卡："
        Catch
            sValue = sValue & " 0 张；实名制卡："
        End Try

        'modify code 071:start-------------------------------------------------------------------------
        Try
            sValue = sValue & Format(dtDetails.Compute("Sum(CardQTY)", "SalesBillType='实名制卡销售单'"), "#,0") & " 张；非实名制卡："
        Catch
            sValue = sValue & " 0 张；非实名制卡："
        End Try
        Try
            sValue = sValue & Format(dtDetails.Compute("Sum(CardQTY)", "SalesBillType='通卖非实名卡销售单'"), "#,0") & " 张）"
        Catch
            sValue = sValue & " 0 张）"
        End Try
        'modify code 071:end-------------------------------------------------------------------------

        'Try
        '    sValue = sValue & Format(dtDetails.Compute("Sum(CardQTY)", "SalesBillType='公关卡销售单'"), "#,0") & " 张）"
        'Catch
        '    sValue = sValue & " 0 张）"
        'End Try
        drHeader("CardQTY") = sValue

        sValue = Format(dtDetails.Compute("Sum(RowChargedAMT)", ""), "#,0.00") & " 元 （正常卡："
        Try
            sValue = sValue & Format(dtDetails.Compute("Sum(RowChargedAMT)", "SalesBillType In ('一般销售单','员工销售单','联名卡销售单') And PaymentTermName<>'（返点卡）'"), "#,0.00") & " 元；返点卡："
        Catch
            sValue = sValue & " 0 元；返点卡："
        End Try
        Try
            sValue = sValue & Format(dtDetails.Compute("Sum(RowChargedAMT)", "PaymentTermName='（返点卡）'"), "#,0.00") & " 元；退货卡："
        Catch
            sValue = sValue & " 0 元；退货卡："
        End Try
        Try
            sValue = sValue & Format(dtDetails.Compute("Sum(RowChargedAMT)", "PaymentTermName='（退货卡）'"), "#,0.00") & " 元；活动卡："
        Catch
            sValue = sValue & " 0 元；活动卡："
        End Try
        Try
            sValue = sValue & Format(dtDetails.Compute("Sum(RowChargedAMT)", "SalesBillType='活动卡销售单'"), "#,0.00") & " 元；实名制卡："
        Catch
            sValue = sValue & " 0 元；实名制卡："
        End Try

        'modify code 071:start-------------------------------------------------------------------------
        Try
            sValue = sValue & Format(dtDetails.Compute("Sum(RowChargedAMT)", "SalesBillType='实名制卡销售单'"), "#,0.00") & " 元；非实名制卡："
        Catch
            sValue = sValue & " 0 元；非实名制卡："
        End Try
        Try
            sValue = sValue & Format(dtDetails.Compute("Sum(RowChargedAMT)", "SalesBillType='通卖非实名卡销售单'"), "#,0.00") & " 元）"
        Catch
            sValue = sValue & " 0 元）"
        End Try
        'modify code 071:end-------------------------------------------------------------------------

        'Try
        '    sValue = sValue & Format(dtDetails.Compute("Sum(RowChargedAMT)", "SalesBillType='公关卡销售单'"), "#,0.00") & " 元）"
        'Catch
        '    sValue = sValue & " 0 元）"
        'End Try
        drHeader("ChargedAMT") = sValue

        Try
            sValue = Format(dtPayment.Compute("Sum(PaymentAMT)", ""), "#,0.00") & " 元 （现金："
        Catch
            sValue = "0.00 元 （现金："
        End Try
        Try
            sValue = sValue & Format(dtPayment.Compute("Sum(PaymentAMT)", "PaymentTerm=0"), "#,0.00") & " 元；银行卡："
        Catch
            sValue = sValue & "0.00 元；银行卡："
        End Try
        Try
            sValue = sValue & Format(dtPayment.Compute("Sum(PaymentAMT)", "PaymentTerm=1"), "#,0.00") & " 元；转账："
        Catch
            sValue = sValue & "0.00 元；转账："
        End Try
        Try
            sValue = sValue & Format(dtPayment.Compute("Sum(PaymentAMT)", "PaymentTerm=2"), "#,0.00") & " 元；支票："
        Catch
            sValue = sValue & "0.00 元；支票："
        End Try
        Try
            sValue = sValue & Format(dtPayment.Compute("Sum(PaymentAMT)", "PaymentTerm=3"), "#,0.00") & " 元"
        Catch
            sValue = sValue & "0.00 元"
        End Try
        Try
            sValue = sValue & "；保证金：" & Format(dtPayment.Compute("Sum(PaymentAMT)", "PaymentTerm=3 And GuarantyByCash=1"), "#,0.00") & " 元）"
        Catch
            sValue = sValue & "）"
        End Try
        If dtTemp.Compute("Sum(CardCost)", "") > 0 Then
            sValue = sValue & "    卡成本：" & Format(dtTemp.Compute("Sum(CardCost)", ""), "#,0.00") & " 元"
        End If
        drHeader("PaymentAMT") = sValue

        Me.DsCheckAccountHeader.dtCheckAccountDetails.Clear()
        Me.DsCheckAccountHeader.dtCheckAccountDetails.Merge(dtDetails.Copy)
        Me.DsCheckAccountHeader.dtCheckAccountDetails.DefaultView.Sort = "SalesBillType,SalesBillCode"
        dtTemp.Dispose() : dtTemp = Nothing
        dtHeader.Dispose() : dtHeader = Nothing
        dtPayment.Dispose() : dtPayment = Nothing
        dtDetails.Dispose() : dtDetails = Nothing

        Me.ReportViewer1.RefreshReport()
        ReportingLog.InsertLog("对账报表", "", Format(Me.dtpFrom.Value, "yyyy\/MM\/dd HH:mm") & " - " & Format(Me.dtpTo.Value, "yyyy\/MM\/dd HH:mm"))
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent
        Me.ReportViewer1.ZoomPercent = 100

        sStartTime = sStart : sEndTime = sEnd
        frmMain.statusText.Text = "就绪。"
        Me.btnQuery.Enabled = False
        Me.lblStatus.ForeColor = Color.Blue
        Me.lblStatus.Text = ""
        Me.Cursor = Cursors.Default
    End Sub
End Class