
'modify code 018:
'date;2014/4/1
'auther:Hyron bjy 
'remark:通过webservice查询报表

Public Class frmMonthRep3
    Private fs_area_id As String, fs_area_type As String

    Private Sub frmMonthRep3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ReportViewer1.ShowBackButton = False
        ReportViewer1.ShowDocumentMapButton = False
        ReportViewer1.ShowFindControls = True
        ReportViewer1.ShowRefreshButton = False

        cbx_year.Text = Today.Year.ToString()
        cbx_month.Text = Today.Month.ToString()
    End Sub

    Private Sub cb_query_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_query.Click
        'modify code 018:start-------------------------------------------------------------------------
        'Dim DB As New DataBaseReport()
        'DB.Open()
        'If Not DB.IsConnected Then
        '    frmMain.statusText.Text = "系统因连接不到数据库而无法打开窗口。请检查数据库连接。"
        '    Me.Close() : Return
        'End If
        Dim ld_from_month As Date = New Date(Convert.ToInt16(cbx_year.Text), Convert.ToInt16(cbx_month.Text), 1)
        Dim ld_to_month As Date = ld_from_month.AddMonths(1)

        Dim ld_from_year As Date = New Date(Convert.ToInt16(cbx_year.Text), 1, 1)


        Dim sSQL As String
        sSQL = " select b.TerritoryName,b.RegionName,b.CityName,b.StoreName,a.M_CardQTY,a.M_AMT,a.M_Discount,b.Y_CardQTY,b.Y_DailyAMT,b.Y_Discount from "
        sSQL = sSQL + "(select t.areaenglishname as TerritoryName,r.areaenglishname as RegionName,c.areaenglishname as CityName,a.areaenglishname as StoreName,"
        sSQL = sSQL + "  sum(b.CardQTY) as M_CardQTY, sum(b.ChargedAMT) AS M_AMT,"
        sSQL = sSQL + "  sum(rebateSalesAMT) as M_Discount "
        sSQL = sSQL + "  from salesbilllist as b"
        sSQL = sSQL + "  join arealist as a on b.storeid=a.areaid "
        sSQL = sSQL + "  join arealist as c on a.parentareaid=c.areaid "
        sSQL = sSQL + "  join areascope(" + frmMain.sLoginUserID + ") as s on s.areaid=b.storeid"
        sSQL = sSQL + "  join arealist as r on c.parentareaid =r.areaid"
        sSQL = sSQL + "  join arealist as t on r.parentareaid =t.areaid"
        sSQL = sSQL + " where b.CULActivatedDate >='" + ld_from_month.ToString("yyyy-MM-dd") + "' and b.CULActivatedDate <'" + ld_to_month.ToString("yyyy-MM-dd") + "' "
        sSQL = sSQL + " and b.salesbilltype = 0  and b.salesbillstate < 9 "
        If fs_area_type = "H" Then
            sSQL = sSQL + ""
        ElseIf fs_area_type = "T" Then
            sSQL = sSQL + " and t.AreaID = " + fs_area_id + " "
        ElseIf fs_area_type = "R" Then
            sSQL = sSQL + " and r.AreaID = " + fs_area_id + " "
        ElseIf fs_area_type = "C" Then
            sSQL = sSQL + " and c.AreaID = " + fs_area_id + " "
        ElseIf fs_area_type = "S" Then
            sSQL = sSQL + " and a.AreaID = " + fs_area_id + " "
        End If
        sSQL = sSQL + "  group by t.areaenglishname,r.areaenglishname,c.areaenglishname,a.areaenglishname) as a full join "

        sSQL = sSQL + "(select t.areaenglishname as TerritoryName,r.areaenglishname as RegionName,c.areaenglishname as CityName,a.areaenglishname as StoreName,"
        sSQL = sSQL + "  sum(b.CardQTY) as Y_CardQTY, sum(b.ChargedAMT) AS Y_DailyAMT,"
        sSQL = sSQL + "  sum(rebateSalesAMT) as Y_Discount "
        sSQL = sSQL + "  from salesbilllist as b"
        sSQL = sSQL + "  join arealist as a on b.storeid=a.areaid "
        sSQL = sSQL + "  join arealist as c on a.parentareaid=c.areaid "
        sSQL = sSQL + "  join areascope(" + frmMain.sLoginUserID + ") as s on s.areaid=b.storeid"
        sSQL = sSQL + "  join arealist as r on c.parentareaid =r.areaid"
        sSQL = sSQL + "  join arealist as t on r.parentareaid =t.areaid"
        sSQL = sSQL + " where b.CULActivatedDate >='" + ld_from_year.ToString("yyyy-MM-dd") + "' and b.CULActivatedDate <'" + ld_to_month.ToString("yyyy-MM-dd") + "' "
        sSQL = sSQL + " and b.salesbilltype = 0  and b.salesbillstate < 9 "
        If fs_area_type = "H" Then
            sSQL = sSQL + ""
        ElseIf fs_area_type = "T" Then
            sSQL = sSQL + " and t.AreaID = " + fs_area_id + " "
        ElseIf fs_area_type = "R" Then
            sSQL = sSQL + " and r.AreaID = " + fs_area_id + " "
        ElseIf fs_area_type = "C" Then
            sSQL = sSQL + " and c.AreaID = " + fs_area_id + " "
        ElseIf fs_area_type = "S" Then
            sSQL = sSQL + " and a.AreaID = " + fs_area_id + " "
        End If
        sSQL = sSQL + "  group by t.areaenglishname,r.areaenglishname,c.areaenglishname,a.areaenglishname) as b "
        sSQL = sSQL + " on a.TerritoryName = b.TerritoryName and a.RegionName = b.RegionName and a.CityName = b.CityName and a.StoreName = b.StoreName "
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



        Me.dsMonthRep3.tbRep.Rows.Clear()
        Dim i As Int32
        For i = 0 To dt.Rows.Count - 1
            Dim dr As DataRow
            dr = Me.dsMonthRep3.tbRep.NewRow
            dr("TerritoryName") = dt.Rows(i)("TerritoryName")
            dr("RegionName") = dt.Rows(i)("RegionName")
            dr("CityName") = dt.Rows(i)("CityName")
            dr("StoreName") = dt.Rows(i)("StoreName")
            dr("M_AMT") = dt.Rows(i)("M_AMT")
            dr("M_CardQTY") = dt.Rows(i)("M_CardQTY")
            dr("M_Discount") = dt.Rows(i)("M_Discount")
            dr("Y_DailyAMT") = dt.Rows(i)("Y_DailyAMT")
            dr("Y_CardQTY") = dt.Rows(i)("Y_CardQTY")
            dr("Y_Discount") = dt.Rows(i)("Y_Discount")


            Me.dsMonthRep3.tbRep.Rows.Add(dr)
        Next

        Me.ReportViewer1.RefreshReport()
        ReportingLog.InsertLog("系统报表", Me.Text, sSQL)
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        frmSelArea.fs_showlevel = "All"
        If frmSelArea.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtArea.Text = frmSelArea.trvArea.SelectedNode.Text
            fs_area_id = frmSelArea.trvArea.SelectedNode.Name
            fs_area_type = frmSelArea.trvArea.SelectedNode.ImageKey
        End If

    End Sub
End Class