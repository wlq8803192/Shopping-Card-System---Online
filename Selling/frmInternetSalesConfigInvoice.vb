
'modify code 040:
'date;2014/11/5
'auther:Hyron bjy 
'remark:新增销售单类型---线下提卡销售单

'modify code 040:start-------------------------------------------------------------------------
Public Class frmInternetSalesConfigInvoice

    Private blSkipDeal As Boolean = False, blNeedCleanInvoiceCodeNo As Boolean = True, editingTextBox As TextBox
    Public sCarrefourName As String, sReceiverTaxNo As String

    Private Sub frmConfigInvoice_ForeColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ForeColorChanged
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub frmConfigInvoice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If frmInternetSalesInvoice.dtInvoiceLayout.Rows(0)("IsLocked") Then
            If Me.Text = "请设置发票版面及打印机：" Then Me.Text = "发票版面及打印机："
            Me.lblTitle.Text = "各打印项目的位置及其可见性（不可修改）："
            Me.dgvInvoice.ReadOnly = True
            Me.dgvInvoice.DefaultCellStyle.BackColor = SystemColors.Control
        ElseIf "|21|272|".IndexOf("|" & frmInternetSalesInvoice.sCityID & "|") > -1 Then '上海
            Me.lblTitle.Text = "上海市门店只需指定发票抬头的位置（将应用于全店的所有机台）："
        ElseIf frmInternetSalesInvoice.sCityID = "24" Then '重庆
            Me.lblTitle.Text = "重庆市门店只需指定发票抬头的位置（将应用于全店的所有机台）："
        ElseIf frmInternetSalesInvoice.sCityID = "27" Then '武汉
            Me.lblTitle.Text = "武汉市门店只需指定发票抬头的位置（将应用于全店的所有机台）："
        End If

        With Me.dgvInvoice
            .DataSource = frmInternetSalesInvoice.dtInvoiceLayout
            .Columns(0).Visible = False
            .Columns(1).Visible = False
            With .Columns(2)
                .HeaderText = ""
                .Width = 30
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.BackColor = SystemColors.Control
                .DefaultCellStyle.ForeColor = SystemColors.ControlText
                .DefaultCellStyle.SelectionBackColor = SystemColors.Control
                .DefaultCellStyle.SelectionForeColor = SystemColors.ControlText
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
            End With
            With .Columns(3)
                .HeaderText = "打印项目"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                If Not Me.dgvInvoice.ReadOnly Then .DefaultCellStyle.BackColor = Color.WhiteSmoke
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
            End With
            With .Columns(4)
                .HeaderText = "字体大小"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(5)
                .HeaderText = "距离左边 (mm)"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(6)
                .HeaderText = "距离上边 (mm)"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            Dim newCheckColumn As New DataGridViewCheckBoxColumn()
            newCheckColumn.DataPropertyName = "IsVisible"
            .Columns.RemoveAt(7)
            .Columns.Insert(7, newCheckColumn)
            With .Columns(7)
                .HeaderText = "是否打印"
                .Width = 60
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                If Not Me.dgvInvoice.ReadOnly Then .DefaultCellStyle.BackColor = Color.WhiteSmoke
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
            End With
            If Not ToolStripManager.VisualStylesEnabled Then
                .Top = .Top - 1
                .Height += 2
            End If
        End With
        For bColumn As Byte = 0 To frmInternetSalesInvoice.dtInvoiceLayout.Columns.Count - 1
            Me.dgvInvoice.Columns(bColumn).Name = frmInternetSalesInvoice.dtInvoiceLayout.Columns(bColumn).ColumnName
        Next

        For Each sPrinter As String In Printing.PrinterSettings.InstalledPrinters
            Me.cbbPrinter.Items.Add(sPrinter)
        Next
        If My.Settings.InvoicePrinter <> "" AndAlso Me.cbbPrinter.Items.IndexOf(My.Settings.InvoicePrinter) > -1 Then
            Me.cbbPrinter.SelectedIndex = Me.cbbPrinter.Items.IndexOf(My.Settings.InvoicePrinter)
            If Me.Text.IndexOf("不再可用") > -1 Then
                Me.cbbPrinter.Items(Me.cbbPrinter.Items.IndexOf(My.Settings.InvoicePrinter)) = My.Settings.InvoicePrinter & "（不可用）"
            End If
        Else
            Dim printDoc As New Printing.PrintDocument
            Me.cbbPrinter.SelectedIndex = Me.cbbPrinter.Items.IndexOf(printDoc.PrinterSettings.PrinterName)
            printDoc.Dispose() : printDoc = Nothing
        End If

        Me.btnOK.Enabled = (Me.cbbPrinter.Text.IndexOf("（不可用）") = -1 AndAlso (Me.cbbPrinter.Text <> My.Settings.InvoicePrinter OrElse frmInternetSalesInvoice.dtInvoiceLayout.GetChanges() IsNot Nothing))
        Me.btnPrintTest.Enabled = (Me.cbbPrinter.Text.IndexOf("（不可用）") = -1)

        Me.dgvInvoice.Select()
        Me.btnCancel.Select()
    End Sub

    Private Sub dgvInvoice_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInvoice.CellContentClick
        If Me.dgvInvoice.ReadOnly Then Return
        If Me.dgvInvoice.Columns(e.ColumnIndex).Name = "IsVisible" Then
            frmMain.statusText.Text = "发票打印项目的可见性只能由总部设置！"
            'Me.dgvInvoice(e.ColumnIndex, e.RowIndex).Value = Not Me.dgvInvoice(e.ColumnIndex, e.RowIndex).Value
        End If
    End Sub

    Private Sub dgvInvoice_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInvoice.CellLeave
        If editingTextBox IsNot Nothing Then
            RemoveHandler editingTextBox.KeyDown, AddressOf Number_KeyDown
            editingTextBox = Nothing
        End If
    End Sub

    Private Sub dgvInvoice_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInvoice.CellValueChanged
        If blSkipDeal OrElse e.RowIndex = -1 Then Return
        If Me.dgvInvoice.Columns(e.ColumnIndex).Name = "FontSize" AndAlso Me.dgvInvoice(e.ColumnIndex, e.RowIndex).Value < 8 Then
            blSkipDeal = True
            Me.dgvInvoice(e.ColumnIndex, e.RowIndex).Value = 8 : Me.dgvInvoice.EndEdit()
            frmMain.statusText.Text = "发票打印项目的最小字号是 8 ！"
            blSkipDeal = False
        End If
        Dim currentRow As DataRow = frmInternetSalesInvoice.dtInvoiceLayout.Rows(e.RowIndex)
        If currentRow.RowState <> DataRowState.Added Then
            Dim blChanged As Boolean = False
            For bColumn As Byte = 4 To 7
                If currentRow(bColumn).ToString <> currentRow(bColumn, DataRowVersion.Original).ToString Then
                    blChanged = True
                    Exit For
                End If
            Next
            If blChanged Then
                Me.btnOK.Enabled = (Me.cbbPrinter.Text.IndexOf("（不可用）") = -1)
            Else
                currentRow.AcceptChanges()
                Me.btnOK.Enabled = (Me.cbbPrinter.Text.IndexOf("（不可用）") = -1 AndAlso (Me.cbbPrinter.Text <> My.Settings.InvoicePrinter OrElse frmInternetSalesInvoice.dtInvoiceLayout.GetChanges() IsNot Nothing))
            End If
        End If
    End Sub

    Private Sub dgvInvoice_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvInvoice.DataError
        e.Cancel = True
    End Sub

    Private Sub dgvInvoice_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvInvoice.EditingControlShowing
        If Me.dgvInvoice.CurrentCell.ReadOnly = False Then
            editingTextBox = CType(e.Control, TextBox)
            editingTextBox.ImeMode = Windows.Forms.ImeMode.Disable
            If Me.dgvInvoice.Columns(Me.dgvInvoice.CurrentCell.ColumnIndex).Name = "FontSize" Then
                editingTextBox.MaxLength = 2
            Else
                editingTextBox.MaxLength = 3
            End If
            AddHandler editingTextBox.KeyDown, AddressOf Number_KeyDown
        End If
    End Sub

    Private Sub dgvInvoice_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvInvoice.Leave
        blSkipDeal = True
        If Me.dgvInvoice.CurrentCell IsNot Nothing Then Me.dgvInvoice.CurrentCell.Selected = False
        If Me.dgvInvoice.CurrentRow IsNot Nothing Then Me.dgvInvoice.CurrentRow.Selected = False
        blSkipDeal = False
    End Sub

    Private Sub dgvInvoice_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvInvoice.SelectionChanged
        If blSkipDeal OrElse Me.dgvInvoice.CurrentCell Is Nothing Then Return
        blSkipDeal = True
        If Me.dgvInvoice.CurrentCell.ColumnIndex = 0 Then
            Me.dgvInvoice("IsVisible", Me.dgvInvoice.CurrentRow.Index).Selected = True
            Me.dgvInvoice.CurrentRow.Selected = True
        ElseIf Me.dgvInvoice.Columns(Me.dgvInvoice.CurrentCell.ColumnIndex).ReadOnly = True Then
            Me.dgvInvoice("IsVisible", Me.dgvInvoice.CurrentRow.Index).Selected = True
            Me.dgvInvoice.CurrentRow.Selected = True
        End If
        blSkipDeal = False
    End Sub

    Private Sub cbbPrinter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbPrinter.SelectedIndexChanged
        If blSkipDeal Then Return
        blNeedCleanInvoiceCodeNo = True
        Me.btnOK.Enabled = (Me.cbbPrinter.Text.IndexOf("（不可用）") = -1 AndAlso (Me.cbbPrinter.Text <> My.Settings.InvoicePrinter OrElse frmInternetSalesInvoice.dtInvoiceLayout.GetChanges() IsNot Nothing))
        Me.btnPrintTest.Enabled = (Me.cbbPrinter.Text.IndexOf("（不可用）") = -1)
    End Sub

    Private Sub btnPrintTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintTest.Click
        Me.Cursor = Cursors.WaitCursor
        If blNeedCleanInvoiceCodeNo Then
            Dim DB As New DataBase
            Try
                DB.Open(True)
                If DB.IsConnected Then
                    DB.ModifyTable("Update InvoiceCodeNo Set LastInvoiceCode=NULL,LastInvoiceNo=NULL Where StoreID=" & frmMain.sLoginAreaID & " And PrinterDevice='" & Me.cbbPrinter.Text.Replace("'", "''") & "'")
                    blNeedCleanInvoiceCodeNo = False
                End If
            Catch
            End Try
            DB.Close()
            frmInternetSalesInvoice.sInvoiceCode = "" : frmInternetSalesInvoice.sInvoiceNo = ""
        End If

        frmMain.statusText.Text = "正在打印测试页……"
        frmMain.statusMain.Refresh()

        Try
            Dim testPrint As New System.Drawing.Printing.PrintDocument, PrintStandard As New System.Drawing.Printing.StandardPrintController()
            testPrint.PrintController = PrintStandard '不出现打印窗口
            testPrint.DocumentName = "InvoiceTestingPage"
            If "|21|24|".IndexOf("|" & frmInternetSalesInvoice.sCityID & "|") > -1 Then '上海/重庆
                AddHandler testPrint.PrintPage, AddressOf testPrintSH_PrintPage
            ElseIf "|27|272|".IndexOf("|" & frmInternetSalesInvoice.sCityID & "|") > -1 Then '武汉/测试城市
                AddHandler testPrint.PrintPage, AddressOf testPrintWH_PrintPage
            Else
                AddHandler testPrint.PrintPage, AddressOf testPrint_PrintPage
            End If
            testPrint.PrinterSettings.PrinterName = Me.cbbPrinter.Text
            testPrint.Print()
            testPrint.Dispose()
            frmMain.statusText.Text = "已经将发票测试页打印到""" & Me.cbbPrinter.Text & """。"
        Catch ex As Exception
            MessageBox.Show("打印测试页时发生如下错误：    " & Chr(13) & Chr(13) & ex.Message & "    ", "打印测试页出错！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "打印测试页出错！"
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If frmInternetSalesInvoice.dtInvoiceLayout.GetChanges() IsNot Nothing AndAlso MessageBox.Show("注意：发票打印版面一旦保存，便不再可修改！    " & Chr(13) & Chr(13) & "请确保所有的设置均已通过测试。是否现在就保存？    ", "请确认保存发票版面设置：", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then Return

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在保存发票设置……"
        frmMain.statusMain.Refresh()

        Dim DB As New DataBase
        DB.Open(True)
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法保存发票版面设置。请检查数据库连接。"
            Me.Cursor = Cursors.Default : Return
        End If

        If My.Settings.InvoicePrinter <> Me.cbbPrinter.Text Then
            My.Settings.InvoicePrinter = Me.cbbPrinter.Text
            My.Settings.Save()
            Dim WMI As New System.Management.ManagementObjectSearcher("SELECT * FROM Win32_Printer"), WMER As System.Management.PropertyDataCollection.PropertyDataEnumerator, ipAddress As Net.IPAddress = Nothing
            Dim sPrinterName As String = "", sPortName As String = "", sSystemName As String = ""
            Try
                For Each WMIOBJ As System.Management.ManagementObject In WMI.Get
                    WMER = WMIOBJ.Properties.GetEnumerator : sPrinterName = "" : sPortName = "" : sSystemName = ""
                    While WMER.MoveNext
                        With WMER.Current
                            If .Name.ToLower = "name" Then sPrinterName = .Value.ToString
                            If .Name.ToLower = "portname" Then sPortName = .Value.ToString
                            If .Name.ToLower = "systemname" Then sSystemName = .Value.ToString
                            If sPrinterName <> "" AndAlso sPortName <> "" AndAlso sSystemName <> "" Then Exit While
                        End With
                    End While
                    If sPrinterName = My.Settings.InvoicePrinter Then Exit For
                Next
                WMI = Nothing
            Catch
                MessageBox.Show("此发票打印机不再可用，请指定另外的打印机。    ", "发票打印机不再可用！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.cbbPrinter.Items.RemoveAt(Me.cbbPrinter.Items.IndexOf(My.Settings.InvoicePrinter))
                Me.btnOK.Enabled = False
                My.Settings.InvoicePrinter = "" : My.Settings.Save()
                Me.Cursor = Cursors.Default : Return
            End Try

            If sPortName.ToUpper.IndexOf("IP_") = 0 Then
                frmInternetSalesInvoice.sInvoicePrinterDevice = sPortName
            ElseIf Net.IPAddress.TryParse(sPortName, ipAddress) Then
                frmInternetSalesInvoice.sInvoicePrinterDevice = "IP_" & sPortName 'Win7环境下的网络打印机本地化为以IP地址为名称的端口名
            ElseIf My.Settings.InvoicePrinter.IndexOf("\\") = 0 Then
                frmInternetSalesInvoice.sInvoicePrinterDevice = My.Settings.InvoicePrinter
            Else '将本地打印机表达成网络打印机的形式
                frmInternetSalesInvoice.sInvoicePrinterDevice = "\\" & sSystemName & "\" & My.Settings.InvoicePrinter
            End If
            Try
                Dim drInvoiceCodeNo As DataRow = DB.GetDataTable("Select LastInvoiceCode,LastInvoiceNo From InvoiceCodeNo Where StoreID=" & frmMain.sLoginAreaID & " And PrinterDevice='" & frmInternetSalesInvoice.sInvoicePrinterDevice.Replace("'", "''") & "'").Rows(0)
                frmInternetSalesInvoice.sInvoiceCode = drInvoiceCodeNo("LastInvoiceCode").ToString
                frmInternetSalesInvoice.sInvoiceNo = (CLng(drInvoiceCodeNo("LastInvoiceNo").ToString) + 1).ToString
                If frmInternetSalesInvoice.sInvoiceNo.Length < drInvoiceCodeNo("LastInvoiceNo").ToString.Length Then frmInternetSalesInvoice.sInvoiceNo = StrDup(drInvoiceCodeNo("LastInvoiceNo").ToString.Length - frmInternetSalesInvoice.sInvoiceNo.Length, "0") & frmInternetSalesInvoice.sInvoiceNo
            Catch
                frmInternetSalesInvoice.sInvoiceCode = "" : frmInternetSalesInvoice.sInvoiceNo = ""
            End Try
        End If

        If frmInternetSalesInvoice.dtInvoiceLayout.GetChanges() IsNot Nothing Then
            For Each drItem As DataRow In frmInternetSalesInvoice.dtInvoiceLayout.Rows
                drItem("IsLocked") = 1
            Next

            If DB.ModifyTable("Delete From InvoiceLayout Where StoreID=" & frmInternetSalesInvoice.sStoreID) = -1 OrElse _
               DB.BulkCopyTable("InvoiceLayout", frmInternetSalesInvoice.dtInvoiceLayout) = -1 Then
                frmMain.statusText.Text = "保存发票设置失败！"
            Else
                DB.ModifyTable("Exec OperationLogInsert " & frmMain.sSSID & ",'Config Invoice Layout','Store'," & frmInternetSalesInvoice.sStoreID)
                frmInternetSalesInvoice.dtInvoiceLayout.AcceptChanges()
                Me.lblTitle.Text = "各打印项目的位置及其可见性（不可修改）："
                Me.dgvInvoice.ReadOnly = True
                Me.dgvInvoice.Columns("ItemName").DefaultCellStyle.BackColor = SystemColors.Control
                Me.dgvInvoice.DefaultCellStyle.BackColor = SystemColors.Control
                Me.dgvInvoice.Columns("IsVisible").DefaultCellStyle.BackColor = SystemColors.Control
                MessageBox.Show("保存发票设置成功。    ", "保存发票设置成功。", MessageBoxButtons.OK, MessageBoxIcon.Information)
                frmMain.statusText.Text = "保存发票设置成功。"
            End If
        End If
        DB.Close()

        Me.Cursor = Cursors.Default
        If frmInternetSalesInvoice.dtInvoiceLayout IsNot Nothing Then Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Number_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If editingTextBox IsNot Nothing AndAlso editingTextBox.SelectedText.Length = editingTextBox.Text.Length Then
                blSkipDeal = True
                CType(sender, DataGridViewTextBoxEditingControl).EditingControlDataGridView.CurrentCell.Value = ""
                blSkipDeal = False
            End If
            Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub testPrint_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        e.Graphics.PageUnit = GraphicsUnit.Millimeter

        Dim drawFont As Font, drawBrush As New SolidBrush(Color.Black), drawFormat As New StringFormat, sText As String = ""
        drawFormat.FormatFlags = StringFormatFlags.NoWrap

        For Each drItem As DataRow In frmInternetSalesInvoice.dtInvoiceLayout.Select("IsVisible=1")
            Select Case drItem("ItemName").ToString
                Case "发票抬头"
                    sText = "××市××××有限公司 （测试版面，非有效发票！）"
                Case "发票品项"
                    sText = "家乐福购物卡"
                Case "计量数量"
                    sText = "1"
                Case "计量单价"
                    sText = Format(frmInternetSalesInvoice.txtBillPayTotalAmount.Text, "#,0.00")
                Case "发票金额"
                    sText = Format(frmInternetSalesInvoice.txtBillPayTotalAmount.Text, "#,0.00")
                Case "大写总额"
                    sText = CapitalDigits.CapitalRMB(frmInternetSalesInvoice.txtBillPayTotalAmount.Text)
                Case "付款方式"
                    sText = "网上付款"
                Case "经手人"
                    sText = frmMain.sLoginUserRealName
                Case "开票日期"
                    sText = Format(Today(), "yyyy-MM-dd")
                Case "订单号"
                    sText = "订单号：" & frmInternetSalesInvoice.txtBillNo.Text.Replace(" ", "")
                Case "购买统计信息（含标题）"
                    sText = "总购买金额：" & Format(frmInternetSalesInvoice.txtBillTotalAmount.Text, "#,0.00") & "  实付金额：" & Format(frmInternetSalesInvoice.txtBillPayTotalAmount.Text, "#,0.00")
            End Select

            drawFont = New Font("宋体", drItem("FontSize"))
            e.Graphics.DrawString(sText, drawFont, drawBrush, drItem("X"), drItem("Y"), drawFormat)
        Next

        e.HasMorePages = False
    End Sub

    Private Sub testPrintSH_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        e.Graphics.PageUnit = GraphicsUnit.Millimeter

        Dim drawFont As New Font("宋体", 10), drawBrush As New SolidBrush(Color.Black), drawFormat As New StringFormat
        drawFormat.FormatFlags = StringFormatFlags.NoWrap
        Dim x As Integer = frmInternetSalesInvoice.dtInvoiceLayout.Rows(0)("X"), y As Integer = frmInternetSalesInvoice.dtInvoiceLayout.Rows(0)("Y")

        If My.Settings.IsInTraining Then
            drawFont = New Font("宋体", 12, FontStyle.Bold)
            x -= 6 : y -= 18
            e.Graphics.DrawString("（培训使用，非有效发票！）", drawFont, drawBrush, x, y, drawFormat)
            drawFont = New Font("宋体", 10)
            x = frmInternetSalesInvoice.dtInvoiceLayout.Rows(0)("X") : y = frmInternetSalesInvoice.dtInvoiceLayout.Rows(0)("Y")
        End If

        x += 13 : y -= 8 '开票日期
        e.Graphics.DrawString(Format(Today(), "yyyy-MM-dd"), drawFont, drawBrush, x, y, drawFormat)
        x += 56 '行业分类
        e.Graphics.DrawString("商业", drawFont, drawBrush, x, y, drawFormat)
        x += 98 '订单号
        drawFormat.Alignment = StringAlignment.Far
        e.Graphics.DrawString("订单号：" & frmInternetSalesInvoice.txtBillNo.Text.Replace(" ", ""), drawFont, drawBrush, x, y, drawFormat)
        x -= 167 : y += 8 '付款单位名称
        drawFormat.Alignment = StringAlignment.Near
        e.Graphics.DrawString("付款单位名称：××市××××有限公司", drawFont, drawBrush, x, y, drawFormat)
        x += 110 '付款单位税号
        e.Graphics.DrawString("付款单位税号：", drawFont, drawBrush, x, y, drawFormat)
        x -= 110 : y += 6 '收款单位名称
        e.Graphics.DrawString("收款单位名称：" & sCarrefourName, drawFont, drawBrush, x, y, drawFormat)
        x += 110 '收款单位税号
        e.Graphics.DrawString("收款单位税号：" & sReceiverTaxNo, drawFont, drawBrush, x, y, drawFormat)
        x -= 110 : y += 6 '标题“商品编号”
        e.Graphics.DrawString("商品编号", drawFont, drawBrush, x, y, drawFormat)
        x += 20 '标题“商品名称”
        e.Graphics.DrawString("商品名称", drawFont, drawBrush, x, y, drawFormat)
        x += 50 '标题“单位”
        e.Graphics.DrawString("单位", drawFont, drawBrush, x, y, drawFormat)
        x += 25 '标题“数量”
        e.Graphics.DrawString("数量", drawFont, drawBrush, x, y, drawFormat)
        x += 25 '标题“单价”
        e.Graphics.DrawString("单价", drawFont, drawBrush, x, y, drawFormat)
        x += 25 '标题“金额”
        e.Graphics.DrawString("金额", drawFont, drawBrush, x, y, drawFormat)
        y += 5 : x -= 125 '发票品项
        e.Graphics.DrawString("家乐福购物卡", drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Center
        x += 79 '数量
        e.Graphics.DrawString("1", drawFont, drawBrush, x, y, drawFormat)
        x += 25 '单价
        e.Graphics.DrawString(Format(frmInternetSalesInvoice.txtBillPayTotalAmount.Text, "#,0.00"), drawFont, drawBrush, x, y, drawFormat)
        x += 25 '总价
        e.Graphics.DrawString(Format(frmInternetSalesInvoice.txtBillPayTotalAmount.Text, "#,0.00"), drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Near
        'y += 5 : x -= 18 '折扣
        'drawFormat.Alignment = StringAlignment.Far
        'e.Graphics.DrawString("折扣：", drawFont, drawBrush, x, y, drawFormat)
        'drawFormat.Alignment = StringAlignment.Center
        'x += 18 '折扣金额
        'drawFormat.Alignment = StringAlignment.Center
        'e.Graphics.DrawString(Format(.drSalesBill("RebateSalesAMT"), "#,0.00"), drawFont, drawBrush, x, y, drawFormat)
        y += 5 : x -= 18 '实付金额
        drawFormat.Alignment = StringAlignment.Far
        e.Graphics.DrawString("实付金额：", drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Center
        x += 18 '实付金额
        drawFormat.Alignment = StringAlignment.Center
        e.Graphics.DrawString(Format(frmInternetSalesInvoice.txtBillPayTotalAmount.Text, "#,0.00"), drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Near
        x -= 149 : y += 40 '大写金额
        e.Graphics.DrawString("合计金额大写（人民币）：" & CapitalDigits.CapitalRMB(frmInternetSalesInvoice.txtBillPayTotalAmount.Text), drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Far
        x += 160 '小写金额
        e.Graphics.DrawString("合计金额小写：" & Format(frmInternetSalesInvoice.txtBillPayTotalAmount.Text, "#,0.00"), drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Near
        x -= 160 : y += 16 '开票人
        e.Graphics.DrawString("开票人：" & frmMain.sLoginUserRealName, drawFont, drawBrush, x, y, drawFormat)
        'x += 35 '收款人
        'e.Graphics.DrawString("收款人：" & .drSalesBill("CreatorName").ToString, drawFont, drawBrush, x, y, drawFormat)
        x += 35 '付款方式
        Dim sText As String = "网上付款"
        e.Graphics.DrawString("付款方式：" & sText, drawFont, drawBrush, x, y, drawFormat)
        x += 35 '标题“开票单位（盖章）”
        e.Graphics.DrawString("开票单位（盖章）：", drawFont, drawBrush, x, y, drawFormat)

        e.HasMorePages = False
    End Sub

    Private Sub testPrintWH_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        e.Graphics.PageUnit = GraphicsUnit.Millimeter

        Dim drawFont As New Font("宋体", 10), drawBrush As New SolidBrush(Color.Black), drawFormat As New StringFormat
        drawFormat.FormatFlags = StringFormatFlags.NoWrap
        Dim x As Integer = frmInternetSalesInvoice.dtInvoiceLayout.Rows(0)("X"), y As Integer = frmInternetSalesInvoice.dtInvoiceLayout.Rows(0)("Y")

        If My.Settings.IsInTraining Then
            drawFont = New Font("宋体", 12, FontStyle.Bold)
            x -= 6 : y -= 18
            e.Graphics.DrawString("（培训使用，非有效发票！）", drawFont, drawBrush, x, y, drawFormat)
            drawFont = New Font("宋体", 10)
            x = frmInternetSalesInvoice.dtInvoiceLayout.Rows(0)("X") : y = frmInternetSalesInvoice.dtInvoiceLayout.Rows(0)("Y")
        End If

        x += 13 : y -= 10 '开票日期
        e.Graphics.DrawString(Format(Today(), "yyyy-MM-dd"), drawFont, drawBrush, x, y, drawFormat)
        x += 56 '行业分类
        e.Graphics.DrawString("商业", drawFont, drawBrush, x, y, drawFormat)
        x += 78 : y += 2 '订单号
        drawFormat.Alignment = StringAlignment.Far
        e.Graphics.DrawString("订单号：" & frmInternetSalesInvoice.txtBillNo.Text.Replace(" ", ""), drawFont, drawBrush, x, y, drawFormat)
        x -= 147 : y += 8 '付款单位名称
        drawFormat.Alignment = StringAlignment.Near
        e.Graphics.DrawString("付款单位名称：××市××××有限公司", drawFont, drawBrush, x, y, drawFormat)
        x += 90 '付款单位税号
        e.Graphics.DrawString("付款单位税号：", drawFont, drawBrush, x, y, drawFormat)
        x -= 90 : y += 6 '收款单位名称
        e.Graphics.DrawString("收款单位名称：" & sCarrefourName, drawFont, drawBrush, x, y, drawFormat)
        x += 90 '收款单位税号
        e.Graphics.DrawString("收款单位税号：" & sReceiverTaxNo, drawFont, drawBrush, x, y, drawFormat)
        x -= 90 : y += 6 '标题“商品编号”
        e.Graphics.DrawString("商品编号", drawFont, drawBrush, x, y, drawFormat)
        x += 20 '标题“商品名称”
        e.Graphics.DrawString("商品名称", drawFont, drawBrush, x, y, drawFormat)
        x += 40 '标题“单位”
        e.Graphics.DrawString("单位", drawFont, drawBrush, x, y, drawFormat)
        x += 20 '标题“数量”
        e.Graphics.DrawString("数量", drawFont, drawBrush, x, y, drawFormat)
        x += 20 '标题“单价”
        e.Graphics.DrawString("单价", drawFont, drawBrush, x, y, drawFormat)
        x += 25 '标题“金额”
        e.Graphics.DrawString("金额", drawFont, drawBrush, x, y, drawFormat)
        y += 5 : x -= 105 '发票品项
        e.Graphics.DrawString("家乐福购物卡".ToString, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Center
        x += 64 '数量
        e.Graphics.DrawString("1", drawFont, drawBrush, x, y, drawFormat)
        x += 20 '单价
        e.Graphics.DrawString(Format(frmInternetSalesInvoice.txtBillPayTotalAmount.Text, "#,0.00"), drawFont, drawBrush, x, y, drawFormat)
        x += 25 '总价
        e.Graphics.DrawString(Format(frmInternetSalesInvoice.txtBillPayTotalAmount.Text, "#,0.00"), drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Near
        'y += 5 : x -= 18 '折扣
        'drawFormat.Alignment = StringAlignment.Far
        'e.Graphics.DrawString("折扣：", drawFont, drawBrush, x, y, drawFormat)
        'drawFormat.Alignment = StringAlignment.Center
        'x += 18 '折扣金额
        'drawFormat.Alignment = StringAlignment.Center
        'e.Graphics.DrawString(Format(.drSalesBill("RebateSalesAMT"), "#,0.00"), drawFont, drawBrush, x, y, drawFormat)
        y += 5 : x -= 18 '实付金额
        drawFormat.Alignment = StringAlignment.Far
        e.Graphics.DrawString("实付金额：", drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Center
        x += 18 '实付金额
        drawFormat.Alignment = StringAlignment.Center
        e.Graphics.DrawString(Format(frmInternetSalesInvoice.txtBillPayTotalAmount.Text, "#,0.00"), drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Near
        x -= 129 : y += 15 '大写金额
        e.Graphics.DrawString("合计金额大写（人民币）：" & CapitalDigits.CapitalRMB(frmInternetSalesInvoice.txtBillPayTotalAmount.Text), drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Far
        x += 140 '小写金额
        e.Graphics.DrawString("合计金额小写：" & Format(frmInternetSalesInvoice.txtBillPayTotalAmount.Text, "#,0.00"), drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Near
        x -= 140 : y += 5 '开票人
        e.Graphics.DrawString("开票人：" & frmMain.sLoginUserRealName, drawFont, drawBrush, x, y, drawFormat)
        'x += 35 '收款人
        'e.Graphics.DrawString("收款人：" & .drSalesBill("CreatorName").ToString, drawFont, drawBrush, x, y, drawFormat)
        x += 35 '付款方式
        Dim sText As String = "网上付款"
        e.Graphics.DrawString("付款方式：" & sText, drawFont, drawBrush, x, y, drawFormat)
        x += 35 '标题“开票单位（盖章）”
        e.Graphics.DrawString("开票单位（盖章）：", drawFont, drawBrush, x, y, drawFormat)

        e.HasMorePages = False
    End Sub
End Class
'modify code 040:end-------------------------------------------------------------------------