Public Class frmCardCycle

    Private dtList As DataTable, iCardQTY As Integer, iRealQTY As Integer

    Private Sub frmCardCycle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lblSalesDate.Text = Format(frmSalesBillManagement.dtpSalesDate.Value, "yyyy\/MM\/dd")
        Dim DB As New DataBase()
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打开窗口。请检查数据库连接。"
            Me.Close() : Return
        End If

        Dim dtCard As DataTable = DB.GetDataTable("Exec GetCardCycleCount " & frmMain.sLoginAreaID & ",'" & Me.lblSalesDate.Text & "'")
        DB.Close()
        If dtCard Is Nothing Then
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开窗口。请联系软件开发人员。"
            Me.Close() : Return
        End If

        dtList = New DataTable()
        dtList.Columns.Add("SalesBillType", System.Type.GetType("System.String"))
        dtList.Columns.Add("StartCardNo", System.Type.GetType("System.String"))
        dtList.Columns.Add("EndCardNo", System.Type.GetType("System.String"))
        dtList.Columns.Add("CardQTY", System.Type.GetType("System.Int32"))
        dtList.Columns.Add("FaceValue", System.Type.GetType("System.Decimal"))
        dtList.Columns.Add("CardType", System.Type.GetType("System.String"))

        Dim dmFaceValue As Decimal = 0, sCardNo As String = "", sStartCardNo As String = "", sCardType As String = "", sSalesBillType As String = ""
        For Each drCard As DataRow In dtCard.Select("", "SalesBillType Desc,FaceValue,CardNo,CardType")
            If sCardNo <> "" AndAlso (drCard("FaceValue") <> dmFaceValue OrElse (sCardNo.IndexOf("2") = 0 AndAlso CLng(drCard("CardNo").ToString.Substring(0, 18)) - CLng(sCardNo.Substring(0, 18)) <> 1) OrElse (sCardNo.IndexOf("8") = 0 AndAlso CLng(drCard("CardNo").ToString) - CLng(sCardNo) <> 1) OrElse drCard("CardType").ToString <> sCardType OrElse drCard("SalesBillType").ToString <> sSalesBillType) Then
                dtList.Rows.Add(sSalesBillType, sStartCardNo, sCardNo, iCardQTY, dmFaceValue, sCardType).AcceptChanges()
                iCardQTY = 0
            End If

            iCardQTY += 1
            dmFaceValue = drCard("FaceValue")
            sCardNo = drCard("CardNo").ToString
            sCardType = drCard("CardType").ToString
            sSalesBillType = drCard("SalesBillType").ToString
            If iCardQTY = 1 Then sStartCardNo = sCardNo
        Next
        dtList.Rows.Add(sSalesBillType, sStartCardNo, sCardNo, iCardQTY, dmFaceValue, sCardType).AcceptChanges()

        iCardQTY = dtList.Compute("Sum(CardQTY)", "")
        iRealQTY = dtCard.DefaultView.ToTable(True, "CardNo").Rows.Count
        If iCardQTY = iRealQTY Then
            Me.lblSummary.Text = "（总卡数：" & Format(iCardQTY, "#,0") & " 张）"
        Else
            Me.lblSummary.Text = "（总卡数：" & Format(iCardQTY, "#,0") & " 张  实卡数：" & Format(iRealQTY, "#,0") & " 张）"
        End If
        dtCard.Dispose() : dtCard = Nothing

        Dim iGridWidth As Integer = 0, iGridHeight As Integer = 0
        With Me.dgvList
            .DataSource = dtList
            With .Columns(0)
                .HeaderText = "销售单类型"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width += 2
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                iGridWidth += .Width
            End With
            With .Columns(1)
                .HeaderText = "开始卡号"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                iGridWidth += .Width
            End With
            With .Columns(2)
                .HeaderText = "结束卡号"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                iGridWidth += .Width
            End With
            With .Columns(3)
                .HeaderText = "卡数"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Format = "#,0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                iGridWidth += .Width
            End With
            With .Columns(4)
                .HeaderText = "面值"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                iGridWidth += .Width
            End With
            With .Columns(5)
                .HeaderText = "卡类型"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                iGridWidth += .Width + 2
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
        End With
        iGridWidth += 2

        Dim iMaxDisplayRows As Integer = Int((My.Computer.Screen.WorkingArea.Height - 108) / 24) - 1
        If iMaxDisplayRows < Me.dgvList.RowCount Then
            iGridWidth += 18
            iGridHeight = (iMaxDisplayRows + 1) * 24
        Else
            iGridHeight = (Me.dgvList.RowCount + 1) * 24
        End If
        If Not ToolStripManager.VisualStylesEnabled Then
            iGridWidth += 2
            iGridHeight += 2
        End If

        Me.Size = New Size(iGridWidth + 32, iGridHeight + 108)
        Me.Location = New Point((My.Computer.Screen.WorkingArea.Width - Me.Width) / 2, (My.Computer.Screen.WorkingArea.Height - Me.Height) / 2)
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub dgvList_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvList.Leave
        If Me.dgvList.CurrentRow IsNot Nothing Then Me.dgvList.CurrentRow.Selected = False
    End Sub

    Private Sub btnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim sTargetFile As String = "", saveDialog As New SaveFileDialog
        With saveDialog
            .Title = "导出购物卡盘点报表："
            .Filter = "导出Excel (*.csv)|*.csv"
            .FileName = "CardInventory_" & Me.lblSalesDate.Text.Replace("/", "") & ".csv"
            .RestoreDirectory = False
            .CreatePrompt = False
            .OverwritePrompt = True
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                sTargetFile = .FileName
            End If
            .Dispose()
        End With
        saveDialog = Nothing
        Me.Refresh()

        If sTargetFile = "" Then Return

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在导出文件……"
        frmMain.statusMain.Refresh()

        Dim smWriter As IO.StreamWriter, bColumns As Byte = Me.dgvList.Columns.Count - 1, strLine As New System.Text.StringBuilder()
        Try
            If IO.File.Exists(sTargetFile) Then IO.File.Delete(sTargetFile)
            smWriter = New IO.StreamWriter(New IO.FileStream(sTargetFile, IO.FileMode.CreateNew), System.Text.Encoding.GetEncoding("GB2312"))
            strLine.Append("销售日期：" & Me.lblSalesDate.Text)
            smWriter.WriteLine(strLine)
            strLine.Remove(0, strLine.Length)
            smWriter.WriteLine(strLine)
            For bColumn As Byte = 0 To bColumns
                strLine.Append(Me.dgvList.Columns(bColumn).HeaderText.Replace(Chr(13), " ") & ",")
            Next
            strLine.Remove(strLine.Length - 1, 1)
            smWriter.WriteLine(strLine)
            For Each drCard As DataRow In dtList.Rows
                strLine.Remove(0, strLine.Length)
                For bColumn As Byte = 0 To bColumns
                    If dtList.Columns(bColumn).DataType.Name = "String" AndAlso IsNumeric(drCard(bColumn).ToString) Then
                        strLine.Append(drCard(bColumn).ToString & Chr(9) & ",")
                    Else
                        strLine.Append(drCard(bColumn).ToString & ",")
                    End If
                Next
                strLine.Remove(strLine.Length - 1, 1)
                smWriter.WriteLine(strLine)
            Next
            strLine.Remove(0, strLine.Length)
            smWriter.WriteLine(strLine)
            strLine.Append("总卡数：" & iCardQTY.ToString)
            smWriter.WriteLine(strLine)
            If iRealQTY <> iCardQTY Then
                strLine.Remove(0, strLine.Length)
                strLine.Append("实卡数：" & iRealQTY.ToString)
                smWriter.WriteLine(strLine)
            End If
            smWriter.Close() : smWriter.Dispose() : smWriter = Nothing

            Try
                System.Diagnostics.Process.Start(sTargetFile)
            Catch
            End Try

            frmMain.statusText.Text = "导出成功。"
        Catch ex As Exception
            MessageBox.Show("导出文件时出错！下面是错误提示：    " & ex.Message & Space(4), "导出失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "导出失败！"
        End Try

        Me.Cursor = Cursors.Default
    End Sub
End Class