Imports System.Data
Imports System.Data.OleDb

'modify code 018:
'date;2014/4/1
'auther:Hyron bjy 
'remark:通过webservice查询报表

Public Class frmColumnMonth1
    Private fs_area_id As String, fs_area_type As String

    Private Sub frmColumnMonth1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        sSQL = "select a.AreaEnglishName as StoreName,"
        sSQL = sSQL + "(case  when cl.CustomerChineseName is NULL then '个人' else cl.CustomerChineseName end) as CustomerName,"
        sSQL = sSQL + " sum(case datepart(month,CULActivatedDate) when 1 then ChargedAMT else 0 end) as Amt_Jan, "
        sSQL = sSQL + "    sum(case datepart(month,CULActivatedDate) when 2 then ChargedAMT else 0 end) as Amt_Feb,"
        sSQL = sSQL + "    sum(case datepart(month,CULActivatedDate) when 3 then ChargedAMT else 0 end) as Amt_Mar,"
        sSQL = sSQL + "    sum(case datepart(month,CULActivatedDate) when 4 then ChargedAMT else 0 end) as Amt_Apr,"
        sSQL = sSQL + "    sum(case datepart(month,CULActivatedDate) when 5 then ChargedAMT else 0 end) as Amt_May,"
        sSQL = sSQL + "    sum(case datepart(month,CULActivatedDate) when 6 then ChargedAMT else 0 end) as Amt_Jun,"
        sSQL = sSQL + "    sum(case datepart(month,CULActivatedDate) when 7 then ChargedAMT else 0 end) as Amt_Jul,"
        sSQL = sSQL + "    sum(case datepart(month,CULActivatedDate) when 8 then ChargedAMT else 0 end) as Amt_Aug,"
        sSQL = sSQL + "    sum(case datepart(month,CULActivatedDate) when 9 then ChargedAMT else 0 end) as Amt_Sep,"
        sSQL = sSQL + "    sum(case datepart(month,CULActivatedDate) when 10 then ChargedAMT else 0 end) as Amt_Oct,"
        sSQL = sSQL + "    sum(case datepart(month,CULActivatedDate) when 11 then ChargedAMT else 0 end) as Amt_Nov,"
        sSQL = sSQL + "    sum(case datepart(month,CULActivatedDate) when 12 then ChargedAMT else 0 end) as Amt_Dec,"
        sSQL = sSQL + "    sum (ChargedAMT) as CustomerSum"
        sSQL = sSQL + "   from salesbilllist as b join arealist as a on b.storeid=a.areaid "
        sSQL = sSQL + "		join arealist as c on a.parentareaid=c.areaid join areascope(" + frmMain.sLoginUserID + ") as s on s.areaid=b.storeid         "
        sSQL = sSQL + "   join arealist as r on c.parentareaid =r.areaid "
        sSQL = sSQL + "   join arealist as t on r.parentareaid =t.areaid "
        sSQL = sSQL + "        left join customerlist as cl on b.customerid = cl.customerid "
        sSQL = sSQL + " where b.CULActivatedDate >='" + ld_from_year.ToString("yyyy-MM-dd") + "' and b.CULActivatedDate <'" + ld_next_year.ToString("yyyy-MM-dd") + "'"
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

        sSQL = sSQL + "group by a.AreaEnglishName,(case  when cl.CustomerChineseName is NULL then '个人' else cl.CustomerChineseName end)"
        sSQL = sSQL + "order by CustomerSum desc"
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



        Me.dsRepColumnMonth1.tbRep.Rows.Clear()
        Dim i As Int32
        For i = 0 To dt.Rows.Count - 1
            Dim dr As DataRow
            dr = Me.dsRepColumnMonth1.tbRep.NewRow
            dr("StoreName") = dt.Rows(i)("StoreName")
            dr("CustomerName") = dt.Rows(i)("CustomerName")
            dr("CustomerSum") = dt.Rows(i)("CustomerSum")
            dr("Amt_Jan") = dt.Rows(i)("Amt_Jan")
            dr("Amt_Feb") = dt.Rows(i)("Amt_Feb")
            dr("Amt_Mar") = dt.Rows(i)("Amt_Mar")
            dr("Amt_Apr") = dt.Rows(i)("Amt_Apr")
            dr("Amt_May") = dt.Rows(i)("Amt_May")
            dr("Amt_Jun") = dt.Rows(i)("Amt_Jun")
            dr("Amt_Jul") = dt.Rows(i)("Amt_Jul")
            dr("Amt_Aug") = dt.Rows(i)("Amt_Aug")
            dr("Amt_Sep") = dt.Rows(i)("Amt_Sep")
            dr("Amt_Oct") = dt.Rows(i)("Amt_Oct")
            dr("Amt_Nov") = dt.Rows(i)("Amt_Nov")
            dr("Amt_Dec") = dt.Rows(i)("Amt_Dec")


            Me.dsRepColumnMonth1.tbRep.Rows.Add(dr)
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