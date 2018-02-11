
'modify code 018:
'date;2014/4/1
'auther:Hyron bjy 
'remark:通过webservice查询报表

Public Class frmJVReport

    Private dtReport1 As Date = Today, dtReport2 As Date = Today

    Private Sub frmJVReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me.dtpActivatedDate
            .MinDate = "2011-7-1"
            .MaxDate = DateAdd(DateInterval.Day, -1, Today)
            .Value = .MaxDate
        End With
    End Sub

    Private Sub dtpActivatedDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpActivatedDate.ValueChanged
        Me.btnJVReport1.Enabled = (dtReport1 <> Me.dtpActivatedDate.Value)
        Me.btnJVReport2.Enabled = (dtReport2 <> Me.dtpActivatedDate.Value)
    End Sub

    Private Sub btnJVReport1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJVReport1.Click
        Me.Cursor = Cursors.WaitCursor
        Me.lblStatus.Visible = True
        Me.lblStatus.ForeColor = SystemColors.ActiveCaption
        Me.lblStatus.Text = "正在准备数据，请稍候……"
        Me.Refresh()

        'modify code 018:start-------------------------------------------------------------------------
        'Dim DB As New DataBaseReport()
        'DB.Open()
        'If Not DB.IsConnected Then
        '    Me.lblStatus.ForeColor = Color.Red
        '    Me.lblStatus.Text = "连接不到数据库！请检查网络连接。"
        '    Me.Cursor = Cursors.Default : Return
        'End If

        'Dim dtResult As DataTable = DB.GetDataTable("Exec GetJVReport1 " & frmMain.sLoginAreaID & ",'" & Format(Me.dtpActivatedDate.Value, "yyyy\/MM\/dd") & "'")
        'DB.Close()
        'If dtResult Is Nothing Then
        '    Me.lblStatus.ForeColor = Color.Red
        '    Me.lblStatus.Text = "准备数据时出错！"
        '    Me.Cursor = Cursors.Default : Return
        'End If

        'Dim WS As New ShoppingCardWebService.ReportWebService
        'WS.Timeout = 300000
        'Dim dtResult As DataTable = WS.GetDataTable("Exec GetJVReport1 46,'2014/4/2'")
        Dim WS As New WebService
        'Dim dtResult As DataTable = WS.GetDataTable("Exec GetJVReport1 46,'2014/4/2'")
        'Dim dtResult As DataTable = WS.GetDataTable("select * from arealist")
        Dim dtResult As DataTable = WS.GetDataTable("Exec GetJVReport1 " & frmMain.sLoginAreaID & ",'" & Format(Me.dtpActivatedDate.Value, "yyyy\/MM\/dd") & "'")
        If dtResult Is Nothing Then
            Me.lblStatus.ForeColor = Color.Red
            Me.lblStatus.Text = "准备数据时出错！"
            Me.Cursor = Cursors.Default : Return
        ElseIf dtResult.Rows.Count > 0 AndAlso Not IsNumeric(dtResult.Rows(0)(0)) AndAlso dtResult.Rows(0)(0) = "Error" Then
            Me.lblStatus.ForeColor = Color.Red
            Me.lblStatus.Text = dtResult.Rows(0)(1)
            Me.Cursor = Cursors.Default : Return
        End If
        'modify code 018:end-------------------------------------------------------------------------

        Dim sFileName As String = Me.FileNameSavedAs("JVReport1")
        If sFileName = "" Then Me.Cursor = Cursors.Default : Return

        Me.lblStatus.Text = "正在导出文件，请稍候……"
        Me.Refresh()

        Me.ExportToCSV(dtResult, sFileName)
        dtResult.Dispose() : dtResult = Nothing
        dtReport1 = Me.dtpActivatedDate.Value

        ReportingLog.InsertLog("JV报表1", sFileName, "激活日期：" & Format(Me.dtpActivatedDate.Value, "yyyy\/MM\/dd"))

        Me.btnJVReport1.Enabled = False
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnJVReport2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJVReport2.Click
        Me.Cursor = Cursors.WaitCursor
        Me.lblStatus.Visible = True
        Me.lblStatus.ForeColor = SystemColors.ActiveCaption
        Me.lblStatus.Text = "正在准备数据，请稍候……"
        Me.Refresh()

        'modify code 018:start-------------------------------------------------------------------------
        'Dim DB As New DataBaseReport()
        'DB.Open()
        'If Not DB.IsConnected Then
        '    Me.lblStatus.ForeColor = Color.Red
        '    Me.lblStatus.Text = "连接不到数据库！请检查网络连接。"
        '    Me.Cursor = Cursors.Default : Return
        'End If

        'Dim dtResult As DataTable = DB.GetDataTable("Exec GetJVReport2 " & frmMain.sLoginAreaID & ",'" & Format(Me.dtpActivatedDate.Value, "yyyy\/MM\/dd") & "'")
        'DB.Close()
        'If dtResult Is Nothing Then
        '    Me.lblStatus.ForeColor = Color.Red
        '    Me.lblStatus.Text = "准备数据时出错！"
        '    Me.Cursor = Cursors.Default : Return
        'End If

        Dim WS As New WebService
        Dim dtResult As DataTable = WS.GetDataTable("Exec GetJVReport2 " & frmMain.sLoginAreaID & ",'" & Format(Me.dtpActivatedDate.Value, "yyyy\/MM\/dd") & "'")
        If dtResult Is Nothing Then
            Me.lblStatus.ForeColor = Color.Red
            Me.lblStatus.Text = "准备数据时出错！"
            Me.Cursor = Cursors.Default : Return
        ElseIf dtResult.Rows.Count > 0 AndAlso Not IsNumeric(dtResult.Rows(0)(0)) AndAlso dtResult.Rows(0)(0) = "Error" Then
            Me.lblStatus.ForeColor = Color.Red
            Me.lblStatus.Text = dtResult.Rows(0)(1)
            Me.Cursor = Cursors.Default : Return
        End If
        'modify code 018:end-------------------------------------------------------------------------

        Dim sFileName As String = Me.FileNameSavedAs("JVReport2")
        If sFileName = "" Then Me.Cursor = Cursors.Default : Return

        Me.lblStatus.Text = "正在导出文件，请稍候……"
        Me.Refresh()

        Me.ExportToCSV(dtResult, sFileName)
        dtResult.Dispose() : dtResult = Nothing
        dtReport2 = Me.dtpActivatedDate.Value

        ReportingLog.InsertLog("JV报表2", sFileName, "激活日期：" & Format(Me.dtpActivatedDate.Value, "yyyy\/MM\/dd"))

        Me.btnJVReport2.Enabled = False
        Me.Cursor = Cursors.Default
    End Sub

    Private Function FileNameSavedAs(ByVal sDefaultName As String) As String
Select_Again:
        Dim sFileName As String = "", savedDialog As New SaveFileDialog()
        With savedDialog
            .Filter = "导出Excel (*.csv)|*.csv"
            .FilterIndex = 0
            .RestoreDirectory = True
            .CreatePrompt = False
            .FileName = sDefaultName & "_" + Format(Me.dtpActivatedDate.Value, "yyyyMMdd") & ".csv"
            .Title = "导出文件保存路径："
            If .ShowDialog = Windows.Forms.DialogResult.OK Then sFileName = .FileName
            .Dispose()
        End With
        Me.Refresh()

        If sFileName = "" Then
            Me.lblStatus.ForeColor = SystemColors.ControlText
            Me.lblStatus.Text = "您已取消了导出！"
        ElseIf IO.File.Exists(sFileName) Then
            Try
                IO.File.Delete(sFileName)
            Catch ex As Exception
                MessageBox.Show("无法覆盖原文件，下面是错误提示：    " & Chr(13) & Chr(13) & ex.Message & Space(4) & Chr(13) & Chr(13) & "请另存为其它文件名。    ", "无法覆盖原文件！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                sFileName = ""
                GoTo Select_Again
            End Try
        End If
        savedDialog = Nothing

        Return sFileName
    End Function

    Private Sub ExportToCSV(ByVal dtResult As DataTable, ByVal sFileName As String)
        Dim sw As New IO.StreamWriter(New IO.FileStream(sFileName, IO.FileMode.CreateNew), System.Text.Encoding.GetEncoding("GB2312"))
        Dim sColumns As New System.Text.StringBuilder(), sValues As New System.Text.StringBuilder(), sValue As String

        Try
            For Each column As DataColumn In dtResult.Columns
                sColumns.Append(column.ColumnName & ",")
            Next
            sColumns.Remove(sColumns.Length - 1, 1)
            sw.WriteLine(sColumns)

            For Each dr As DataRow In dtResult.Rows
                sValues.Remove(0, sValues.Length)
                For bColumn As Byte = 0 To dtResult.Columns.Count - 1
                    sValue = dr(bColumn).ToString
                    If IsNumeric(sValue) AndAlso dtResult.Columns(bColumn).DataType.Name.ToLower = "string" Then
                        sValues.Append(sValue.Replace(",", " ") & Chr(9))
                    ElseIf IsDate(sValue) AndAlso dtResult.Columns(bColumn).DataType.Name.ToLower = "datetime" Then
                        sValues.Append(Format(dr(bColumn), "yyyy\/MM\/dd"))
                    Else
                        sValues.Append(sValue.Replace(",", " "))
                    End If
                    sValues.Append(",")
                Next
                sValues.Remove(sValues.Length - 1, 1)
                sw.WriteLine(sValues)
            Next
            sw.Close()
            System.Diagnostics.Process.Start(sFileName)
            Me.lblStatus.ForeColor = SystemColors.ControlText
            Me.lblStatus.Text = "导出文件成功。"
        Catch
            Me.lblStatus.ForeColor = Color.Red
            Me.lblStatus.Text = "导出数据时出错！"
        Finally
            sColumns = Nothing : sValues = Nothing
            sw.Dispose()
            sw = Nothing
        End Try
    End Sub
End Class
