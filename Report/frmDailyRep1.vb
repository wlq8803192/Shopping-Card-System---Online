
'modify code 018:
'date;2014/4/1
'auther:Hyron bjy 
'remark:通过webservice查询报表

Public Class frmDailyRep1

    Private fs_area_id As String, fs_area_type As String
    Private Sub frmDailyRep1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ReportViewer1.ShowBackButton = False
        ReportViewer1.ShowDocumentMapButton = False
        ReportViewer1.ShowFindControls = True
        ReportViewer1.ShowRefreshButton = False

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
        sSQL = "select b.CULActivatedDate, c.areaenglishname as CityName, a.areaenglishname as StoreName,'CustomerChineseName' = (case when cl.CustomerChineseName is null then '个人客户' else cl.CustomerChineseName end),"
        sSQL = sSQL + "  d.rowtype,d.StartCardNo,d.EndCardNo,d.CardQTY,d.FaceValue,d.SelectedAMT,"
        sSQL = sSQL + "   (case b.PayableAMT when 0 then 1 else b.rebateSalesAMT / b.PayableAMT end) as DiscountRate,e.CreatorName,b.salesmanname "
        sSQL = sSQL + "  from salesbilllist as b WITH(NOLOCK) join arealist as a on b.storeid=a.areaid join arealist as c on a.parentareaid=c.areaid join areascope(" + frmMain.sLoginUserID + ") as s on s.areaid=b.storeid "
        sSQL = sSQL + "  join arealist as r WITH(NOLOCK) on c.parentareaid =r.areaid"
        sSQL = sSQL + "  join arealist as t WITH(NOLOCK) on r.parentareaid =t.areaid"
        sSQL = sSQL + "  join salesBillDetails as d WITH(NOLOCK) on b.salesbillid = d.salesbillid "
        sSQL = sSQL + "  join salesBillExtra as e WITH(NOLOCK) on d.salesbillid = e.salesbillid "
        sSQL = sSQL + "  left join customerlist as cl WITH(NOLOCK) on b.customerid = cl.customerid "

        sSQL = sSQL + " where b.CULActivatedDate between '" + dtpFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTo.Value.ToString("yyyy-MM-dd") + "' "
        sSQL = sSQL + " and b.salesbilltype = 0 and b.salesbillstate < 9 "
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

        Me.dsDailyRep1.tbRep.Rows.Clear()
        Dim i As Int32
        For i = 0 To dt.Rows.Count - 1
            Dim dr As DataRow
            dr = Me.dsDailyRep1.tbRep.NewRow
            dr("SalesDate") = dt.Rows(i)("CULActivatedDate")
            dr("CityName") = dt.Rows(i)("CityName")
            dr("StoreName") = dt.Rows(i)("StoreName")
            dr("CustomerChineseName") = dt.Rows(i)("CustomerChineseName")
            dr("StartCardNo") = dt.Rows(i)("StartCardNo")
            dr("EndCardNo") = dt.Rows(i)("EndCardNo")
            dr("FaceValue") = dt.Rows(i)("FaceValue")
            dr("CardQTY") = dt.Rows(i)("CardQTY")
            dr("TotalAmount") = dt.Rows(i)("SelectedAMT")
            If (Convert.ToInt16(dt.Rows(i)("RowType")) = 0) Then
                dr("DiscountRate") = dt.Rows(i)("DiscountRate")
            Else
                dr("DiscountRate") = 0
            End If
            dr("CreatorName") = dt.Rows(i)("CreatorName")
            dr("SalesMan") = dt.Rows(i)("SalesManName")
            Me.dsDailyRep1.tbRep.Rows.Add(dr)
        Next

        Me.ReportViewer1.RefreshReport()
        ReportingLog.InsertLog("系统报表", Me.Text, sSQL)
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        frmSelArea.fs_showlevel = "All"
        If frmSelArea.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtArea.Text = frmSelArea.trvArea.SelectedNode.Text
            fs_area_id = frmSelArea.trvArea.SelectedNode.Name
            fs_area_type = frmSelArea.trvArea.SelectedNode.ImageKey
        End If
    End Sub
End Class