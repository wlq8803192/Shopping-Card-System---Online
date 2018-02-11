
'modify code 018:
'date;2014/4/1
'auther:Hyron bjy 
'remark:通过webservice查询报表

Public Class frmFishReport1

    Private Sub frmFishReport1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ReportViewer1.ShowBackButton = False
        ReportViewer1.ShowDocumentMapButton = False
        ReportViewer1.ShowFindControls = True
        ReportViewer1.ShowRefreshButton = False

        cbx_year.Text = Today.Year.ToString()
    End Sub

    Private Sub cb_query_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_query.Click
        'modify code 018:start-------------------------------------------------------------------------
        'Dim DB As New DataBaseReport()
        'DB.Open()
        'If Not DB.IsConnected Then
        '    frmMain.statusText.Text = "系统因连接不到数据库而无法打开窗口。请检查数据库连接。"
        '    Me.Close() : Return
        'End If

        Dim ld_from_year As Date = New Date(Convert.ToInt16(cbx_year.Text), 1, 1)
        Dim ld_next_year As Date = New Date(Convert.ToInt16(cbx_year.Text) + 1, 1, 1)


        Dim sSQL As String
        '把个人都归为小鱼
        sSQL = "select StoreName,"
        sSQL = sSQL + "sum(CustomerSum) as TotalSales,"
        sSQL = sSQL + "sum(Debits) as TotalDebits,"
        sSQL = sSQL + "sum(case when CustomerSum >= 100000 and customerid is not null then CustomerSum else 0 end) as BigFishSales,"
        sSQL = sSQL + "sum(case when CustomerSum >= 100000 and customerid is not null then Debits else 0 end) as BigFishDebits,"
        sSQL = sSQL + "sum(case when CustomerSum >= 30000 and CustomerSum < 100000 and customerid is not null then CustomerSum else 0 end) as MiddleFishSales,"
        sSQL = sSQL + "sum(case when CustomerSum >= 30000 and CustomerSum < 100000 and customerid is not null then Debits else 0 end) as MiddleFishDebits,"
        sSQL = sSQL + "sum(case when CustomerSum < 30000 or customerid is null then CustomerSum else 0 end) as SmallFishSales,"
        sSQL = sSQL + "sum(case when CustomerSum < 30000 or customerid is null then Debits else 0 end) as SmallFishDebits"
        sSQL = sSQL + " from "
        sSQL = sSQL + "(select a.AreaEnglishName as StoreName,b.CustomerID,"
        sSQL = sSQL + "    sum (b.ChargedAMT) as CustomerSum,count(salesbillid) as Debits "
        sSQL = sSQL + "   from salesbilllist as b join arealist as a on b.storeid=a.areaid "
        sSQL = sSQL + "		join areascope(" + frmMain.sLoginUserID + ") as s on s.areaid=b.storeid               "
        sSQL = sSQL + " where b.CULActivatedDate >='" + ld_from_year.ToString("yyyy-MM-dd") + "' and b.CULActivatedDate <'" + ld_next_year.ToString("yyyy-MM-dd") + "' "
        sSQL = sSQL + " and b.salesbilltype = 0  and b.salesbillstate < 9 "
        sSQL = sSQL + "group by a.AreaEnglishName,b.CustomerID) tb "
        sSQL = sSQL + "group by StoreName"

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



        Me.dsFishReport1.tbRep.Rows.Clear()
        Dim i As Int32
        For i = 0 To dt.Rows.Count - 1
            Dim dr As DataRow
            dr = Me.dsFishReport1.tbRep.NewRow
            dr("StoreName") = dt.Rows(i)("StoreName")
            dr("TotalSales") = dt.Rows(i)("TotalSales")
            dr("TotalDebits") = dt.Rows(i)("TotalDebits")
            dr("BigFishSales") = dt.Rows(i)("BigFishSales")
            dr("BigFishDebits") = dt.Rows(i)("BigFishDebits")
            dr("MiddleFishSales") = dt.Rows(i)("MiddleFishSales")
            dr("MiddleFishDebits") = dt.Rows(i)("MiddleFishDebits")
            dr("SmallFishSales") = dt.Rows(i)("SmallFishSales")
            dr("SmallFishDebits") = dt.Rows(i)("SmallFishDebits")

            Me.dsFishReport1.tbRep.Rows.Add(dr)
        Next

        Me.ReportViewer1.RefreshReport()
        ReportingLog.InsertLog("系统报表", Me.Text, sSQL)
    End Sub
End Class