Imports System.Data.SqlClient

'modify code 018:
'date;2014/4/1
'auther:Hyron bjy 
'remark:通过webservice查询报表

Public Class frmDailyRep2
    Private fs_area_id As String, fs_area_type As String

    Private Sub frmDailyRep2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        sSQL = "select r.areaenglishname as RegionName,b.CULActivatedDate,c.areaenglishname as CityName,a.areaenglishname as StoreName,"
        sSQL = sSQL + "  count(b.salesbillid) as DealsQTY, sum(b.CardQTY) as CardQTY, sum(b.ChargedAMT) AS ChargedAMT,"
        sSQL = sSQL + "   sum(b.ChargedAMT) / sum(b.CardQTY) as AvgValue,sum(rebateSalesAMT) as Discount"
        sSQL = sSQL + "  from salesbilllist as b WITH(NOLOCK) "
        sSQL = sSQL + "  join arealist as a WITH(NOLOCK) on b.storeid=a.areaid "
        sSQL = sSQL + "  join arealist as c WITH(NOLOCK) on a.parentareaid=c.areaid "
        sSQL = sSQL + "  join areascope(" + frmMain.sLoginUserID + ") as s on s.areaid=b.storeid "
        sSQL = sSQL + "  join arealist as r WITH(NOLOCK) on c.parentareaid =r.areaid "
        sSQL = sSQL + "  join arealist as t WITH(NOLOCK) on r.parentareaid =t.areaid "
        sSQL = sSQL + " where b.CULActivatedDate between '" + dtpFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTo.Value.ToString("yyyy-MM-dd") + "' "
        sSQL = sSQL + " and b.salesbilltype = 0  and salesbillstate < 9 "

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

        sSQL = sSQL + "  group by r.areaenglishname,b.CULActivatedDate,c.areaenglishname,a.areaenglishname"


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

        Me.dsDailyRep2.tbRep.Rows.Clear()

        Dim i As Int32
        For i = 0 To dt.Rows.Count - 1
            Dim dr As DataRow
            dr = Me.dsDailyRep2.tbRep.NewRow
            dr("SalesDate") = dt.Rows(i)("CULActivatedDate")
            dr("RegionName") = dt.Rows(i)("RegionName")
            dr("CityName") = dt.Rows(i)("CityName")
            dr("StoreName") = dt.Rows(i)("StoreName")
            dr("ChargedAMT") = dt.Rows(i)("ChargedAMT")
            dr("CardQTY") = dt.Rows(i)("CardQTY")
            dr("AvgValue") = dt.Rows(i)("AvgValue")
            dr("Discount") = dt.Rows(i)("Discount")
            Me.dsDailyRep2.tbRep.Rows.Add(dr)
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