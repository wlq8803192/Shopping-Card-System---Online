
'modify code 018:
'date;2014/4/1
'auther:Hyron bjy 
'remark:通过webservice查询报表

Public Class frmDailyCustomer

    Private Sub frmDailyCustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dtpFrom.Value = DateTime.Today.AddDays(-1)
        dtpTo.Value = DateTime.Today.AddDays(-1)

    End Sub

    Private Sub cb_query_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_query.Click
        'modify code 018:start-------------------------------------------------------------------------
        'Dim DB As New DataBaseReport()
        'DB.Open()
        'If Not DB.IsConnected Then
        '    frmMain.statusText.Text = "系统因连接不到数据库而无法打开窗口。请检查数据库连接。"
        '    Me.Close() : Return
        'End If


        Dim sSQL As String
        sSQL = "select b.CULActivatedDate, c.areaenglishname as CityName, a.areaenglishname as StoreName,'CustomerChineseName' = (case when t.CustomerChineseName is null then '个人客户' else t.CustomerChineseName end),"
        sSQL = sSQL + "  b.CardQTY,b.ChargedAMT,b.RebateSalesAMT, "
        sSQL = sSQL + "   b.RebateRate as DiscountRate "
        sSQL = sSQL + "  from salesbilllist as b join arealist as a on b.storeid=a.areaid join arealist as c on a.parentareaid=c.areaid join areascope(" + frmMain.sLoginUserID + ") as s on s.areaid=b.storeid "
        sSQL = sSQL + "  left join customerlist as t on b.customerid = t.customerid "

        sSQL = sSQL + " where b.CULActivatedDate between '" + dtpFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTo.Value.ToString("yyyy-MM-dd") + "' "
        sSQL = sSQL + " and b.salesbilltype = 0 and b.salesbillstate < 9 "

        'Dim dt As DataTable

        'dt = DB.GetDataTable(sSQL)
        'If dt Is Nothing Then
        '    frmMain.statusText.Text = "系统因在检索数据时出错而无法打开窗口。请联系软件开发人员。"
        '    DB.Close() : Me.Close() : Return
        'End If
        'DB.Close()

        Dim WS As New WebService
        Dim dt As DataTable = WS.GetDataTable(sSQL)
        If dt Is Nothing Then
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开窗口。请联系软件开发人员。"
            Me.Close() : Return
        End If
        'modify code 018:end-------------------------------------------------------------------------


        Me.dsDailyCusomer.tbRep.Rows.Clear()
        Dim i As Int32
        For i = 0 To dt.Rows.Count - 1
            Dim dr As DataRow
            dr = Me.dsDailyCusomer.tbRep.NewRow
            dr("SalesDate") = dt.Rows(i)("CULActivatedDate")
            dr("CityName") = dt.Rows(i)("CityName")
            dr("StoreName") = dt.Rows(i)("StoreName")
            dr("CustomerName") = dt.Rows(i)("CustomerChineseName")
            dr("CardQTY") = dt.Rows(i)("CardQTY")
            dr("TotalAmount") = dt.Rows(i)("ChargedAMT")
            dr("Discount") = dt.Rows(i)("RebateSalesAMT")
            dr("DiscountRate") = dt.Rows(i)("DiscountRate")
            Me.dsDailyCusomer.tbRep.Rows.Add(dr)
        Next

        Me.ReportViewer1.RefreshReport()
        ReportingLog.InsertLog("系统报表", Me.Text, sSQL)
    End Sub
End Class