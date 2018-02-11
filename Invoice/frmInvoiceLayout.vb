Public Class frmInvoiceLayout

    Private blSkipDeal As Boolean = True, blIsReadOnly As Boolean = False, sStoreID As String = "", dvCity As DataView, dvStore As DataView, dvInvoiceLayout As DataView, dvExistingInvoice As DataView, editingTextBox As TextBox

    Private Sub frmInvoiceLayout_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.btnSave.Enabled Then
            Me.btnSave.Select()
            Dim bAnswer As Windows.Forms.DialogResult = MessageBox.Show("当前窗口内容已更改，但未保存。    " & Chr(13) & Chr(13) & "是否在关闭窗口前保存这些更改？    " & Chr(13) & Chr(13) & "   是    -   保存更改并退出" & Chr(13) & "   否    -   放弃更改并退出" & Chr(13) & "  取消   -   取消关闭", "请确认保存更改：", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

            If bAnswer = Windows.Forms.DialogResult.Yes Then
                Me.btnSave.PerformClick()
                If Not Me.btnSave.Enabled Then Me.Dispose() Else e.Cancel = True
            ElseIf bAnswer = Windows.Forms.DialogResult.No Then
                Me.Dispose()
            Else
                e.Cancel = True
            End If
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub frmInvoiceLayout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        blIsReadOnly = (frmMain.dtAllowedRight.Select("RightName='InvoiceLayoutModification'").Length = 0)

        Dim DB As New DataBase
        DB.Open(True)
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打开发票版面设置窗口。请检查数据库连接。"
            Me.Close() : Return
        End If

        Try
            If frmMain.sLoginAreaType = "S" Then
                dvCity = DB.GetDataTable("Select AreaID, AreaType+AreaCode+' '+Isnull(AreaChineseName,'')+' '+Isnull(AreaEnglishName,'') As AreaFullName,'000' As SortCode From AreaList Where AreaID=" & frmMain.dtLoginStructure.Rows.Find(frmMain.sLoginAreaID)("ParentAreaID").ToString).DefaultView
            Else
                dvCity = frmMain.dtLoginStructure.Copy.DefaultView
                dvCity.RowFilter = "AreaType='C'"
                dvCity = dvCity.ToTable(False, "AreaID", "AreaFullName", "SortCode").DefaultView
            End If
            dvCity.Sort = "SortCode"
            dvCity.Table.AcceptChanges()

            dvStore = frmMain.dtLoginStructure.Copy.DefaultView
            dvStore.RowFilter = "AreaType='S'"
            dvStore = dvStore.ToTable(False, "AreaID", "AreaFullName", "ParentAreaID", "SortCode").DefaultView
            dvStore.Sort = "SortCode"
            dvStore.Table.AcceptChanges()

            dvInvoiceLayout = DB.GetDataTable("Select I.* From InvoiceLayout As I Join AreaScope(" & frmMain.sLoginUserID & ") As S On I.StoreID=S.AreaID").DefaultView
            dvInvoiceLayout.Sort = "ItemID"

            dvExistingInvoice = DB.GetDataTable("Select Distinct A.ParentAreaID As CityID,I.StoreID,I.IsLocked From InvoiceLayout As I Join AreaList As A On I.StoreID=A.AreaID Join AreaScope(" & frmMain.sLoginUserID & ") As S On A.AreaID=S.AreaID").DefaultView
        Catch
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开发票版面设置窗口。请联系软件开发人员。"
            DB.Close() : Me.Close() : Return
        End Try

        With Me.cbbCity
            .DataSource = dvCity
            .DisplayMember = "AreaFullName"
            .ValueMember = "AreaID"
            .SelectedIndex = 0
        End With

        If Me.cbbCity.SelectedValue.ToString <> "" Then dvStore.RowFilter = "ParentAreaID=" & Me.cbbCity.SelectedValue.ToString
        With Me.cbbStore
            .DataSource = dvStore
            .DisplayMember = "AreaFullName"
            .ValueMember = "AreaID"
            .SelectedIndex = 0
        End With

        sStoreID = Me.cbbStore.SelectedValue.ToString
        If sStoreID = "" Then
            Me.chbAllow.Checked = False
            Me.chbAllow.Enabled = False
            dvInvoiceLayout.RowFilter = "1=2"
        Else
            dvInvoiceLayout.RowFilter = "StoreID=" & sStoreID
            If dvInvoiceLayout.Count = 0 AndAlso Not blIsReadOnly Then Me.SetDefaultInvoicLayout(sStoreID)
            Me.chbAllow.Checked = (dvInvoiceLayout.Count > 0 AndAlso Not dvInvoiceLayout(0)("IsLocked"))
            Me.chbAllow.Enabled = (dvInvoiceLayout.Count > 0 AndAlso Not blIsReadOnly)
        End If

        With Me.dgvInvoice
            .DataSource = dvInvoiceLayout
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
                If Not blIsReadOnly Then .DefaultCellStyle.BackColor = Color.WhiteSmoke
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
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
            End With
            If Not ToolStripManager.VisualStylesEnabled Then .Height += 2
        End With
        For bColumn As Byte = 0 To dvInvoiceLayout.Table.Columns.Count - 1
            Me.dgvInvoice.Columns(bColumn).Name = dvInvoiceLayout.Table.Columns(bColumn).ColumnName
        Next

        If blIsReadOnly Then
            Me.dgvInvoice.ReadOnly = True
            Me.dgvInvoice.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Me.dgvInvoice.EditMode = DataGridViewEditMode.EditProgrammatically
        End If

        For Each sPrinter As String In Printing.PrinterSettings.InstalledPrinters
            Me.cbbPrinter.Items.Add(sPrinter)
        Next
        If My.Settings.InvoicePrinter <> "" AndAlso Me.cbbPrinter.Items.IndexOf(My.Settings.InvoicePrinter) > -1 Then
            Me.cbbPrinter.SelectedIndex = Me.cbbPrinter.Items.IndexOf(My.Settings.InvoicePrinter)
        Else
            Dim printDoc As New Printing.PrintDocument
            Me.cbbPrinter.SelectedIndex = Me.cbbPrinter.Items.IndexOf(printDoc.PrinterSettings.PrinterName)
            printDoc.Dispose() : printDoc = Nothing
        End If
        Me.cbbPrinter.Enabled = (Not blIsReadOnly)

        Me.btnPrintTest.Enabled = (Not blIsReadOnly AndAlso Me.cbbPrinter.Text <> "")
        If blIsReadOnly Then Me.Text = "各门店设置发票版面 (只读 Readonly)"

        Me.dgvInvoice.Select()
        blSkipDeal = False
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub cbbCity_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbCity.SelectedIndexChanged
        If blSkipDeal Then Return
        dvStore.RowFilter = "ParentAreaID=" & Me.cbbCity.SelectedValue.ToString
        blSkipDeal = True
        Me.cbbStore.SelectedIndex = -1
        blSkipDeal = False
        Me.cbbStore.SelectedIndex = 0
    End Sub

    Private Sub cbbStore_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbStore.SelectedIndexChanged
        If blSkipDeal Then Return
        sStoreID = Me.cbbStore.SelectedValue.ToString
        If sStoreID = "" Then
            Me.chbAllow.Checked = False
            Me.chbAllow.Enabled = False
            dvInvoiceLayout.RowFilter = "1=2"
        Else
            dvInvoiceLayout.RowFilter = "StoreID=" & sStoreID
            If dvInvoiceLayout.Count = 0 AndAlso Not blIsReadOnly Then Me.SetDefaultInvoicLayout(sStoreID)
            blSkipDeal = True
            Me.chbAllow.Checked = (dvInvoiceLayout.Count > 0 AndAlso Not dvInvoiceLayout(0)("IsLocked"))
            blSkipDeal = False
            Me.chbAllow.Enabled = (dvInvoiceLayout.Count > 0 AndAlso Not blIsReadOnly)
        End If
    End Sub

    Private Sub chbAllow_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbAllow.CheckedChanged
        If blSkipDeal Then Return
        For Each drItem As DataRowView In dvInvoiceLayout
            drItem("IsLocked") = (Not Me.chbAllow.Checked)
        Next
        Me.btnSave.Enabled = True
    End Sub

    Private Sub dgvInvoice_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInvoice.CellContentClick
        If blIsReadOnly Then Return
        If Me.dgvInvoice.Columns(e.ColumnIndex).Name = "IsVisible" Then
            Me.dgvInvoice(e.ColumnIndex, e.RowIndex).Value = Not Me.dgvInvoice(e.ColumnIndex, e.RowIndex).Value
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
        Me.btnSave.Enabled = True
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
        If blSkipDeal OrElse blIsReadOnly OrElse Me.dgvInvoice.CurrentCell Is Nothing Then Return
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
        My.Settings.InvoicePrinter = Me.cbbPrinter.Text
    End Sub

    Private Sub btnPrintTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintTest.Click
        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在打印测试页……"
        frmMain.statusMain.Refresh()

        Try
            Dim testPrint As New System.Drawing.Printing.PrintDocument, PrintStandard As New System.Drawing.Printing.StandardPrintController()
            testPrint.PrintController = PrintStandard '不出现打印窗口
            testPrint.DocumentName = "InvoiceTestingPage"
            AddHandler testPrint.PrintPage, AddressOf testPrint_PrintPage
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

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim dtChanges As DataTable = dvInvoiceLayout.Table.GetChanges()
        If dtChanges Is Nothing Then
            frmMain.statusText.Text = "未发现任何修改，无须保存。"
            Me.btnSave.Enabled = False
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在保存发票版面设置……"
        frmMain.statusMain.Refresh()

        If My.Settings.InvoicePrinter <> Me.cbbPrinter.Text Then
            My.Settings.InvoicePrinter = Me.cbbPrinter.Text
            My.Settings.Save()
        End If

        Dim DB As New DataBase, blSaved As Boolean = False, blFailure As Boolean = False
        DB.Open(True)
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法保存发票版面设置。请检查数据库连接。"
            Me.Cursor = Cursors.Default : Return
        End If

        dtChanges = dtChanges.DefaultView.ToTable(True, "StoreID")
        For Each drStore As DataRow In dtChanges.Rows
            dvInvoiceLayout.RowFilter = "StoreID=" & drStore("StoreID").ToString
            If DB.ModifyTable("Delete From InvoiceLayout Where StoreID=" & drStore("StoreID").ToString) = -1 OrElse _
               DB.BulkCopyTable("InvoiceLayout", dvInvoiceLayout.ToTable) = -1 Then
                frmMain.statusText.Text = "保存发票版面设置失败！"
                blFailure = blFailure
            Else
                DB.ModifyTable("Exec OperationLogInsert " & frmMain.sSSID & ",'Config Invoice Layout','Store'," & drStore("StoreID").ToString)
                blSaved = True
            End If
            If blSaved Then
                dvInvoiceLayout.Table.AcceptChanges()
                Me.btnSave.Enabled = blFailure
                MessageBox.Show("保存发票版面设置成功。    ", "保存发票版面设置成功。", MessageBoxButtons.OK, MessageBoxIcon.Information)
                frmMain.statusText.Text = "保存发票版面设置成功。"
            End If
        Next
        dvInvoiceLayout.RowFilter = "StoreID=" & sStoreID
        DB.Close()

        Me.Cursor = Cursors.Default
        If frmSelling.dtInvoiceLayout IsNot Nothing Then Me.DialogResult = Windows.Forms.DialogResult.OK
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

        For Each drItem As DataRow In dvInvoiceLayout.Table.Select("StoreID=" & sStoreID & " And IsVisible=1")
            Select Case drItem("ItemName").ToString
                Case "发票抬头"
                    sText = "××市××××有限公司 （测试版面，非有效发票！）"
                Case "发票品项"
                    sText = "家乐福购物卡"
                Case "计量数量"
                    sText = "1"
                Case "计量单价"
                    sText = Format(15000, "#,0.00")
                Case "发票金额"
                    sText = Format(15000, "#,0.00")
                Case "大写总额"
                    sText = CapitalDigits.CapitalRMB(15000)
                Case "付款方式"
                    sText = "支票"
                Case "经手人"
                    sText = "XXX"
                Case "开票日期"
                    sText = Format(Today(), "yyyy-MM-dd")
                Case "家乐福小票号（含标题）"
                    sText = "家乐福小票号：" & Me.cbbStore.Text.Substring(1, 3) & Format(Today(), "yyMMdd") & "0001"
                Case "购买统计信息（含标题）"
                    sText = "总购买金额：" & Format(15000, "#,0.00") & "  折扣金额：" & Format(0, "#,0.00") & "  实付金额：" & Format(15000, "#,0.00")
            End Select

            drawFont = New Font("宋体", drItem("FontSize"))
            e.Graphics.DrawString(sText, drawFont, drawBrush, drItem("X"), drItem("Y"), drawFormat)
        Next

        e.HasMorePages = False
    End Sub

    Private Sub SetDefaultInvoicLayout(ByVal sStoreID As String)
        Dim sCity As String = dvStore.Table.Select("AreaID=" & sStoreID)(0)("ParentAreaID").ToString, sSourceStoreID As String = ""
        dvExistingInvoice.RowFilter = "CityID=" & sCity & " And IsLocked=1"
        If dvExistingInvoice.Count > 0 Then
            sSourceStoreID = dvExistingInvoice(0)("StoreID").ToString
        Else
            dvExistingInvoice.RowFilter = "CityID=" & sCity
            If dvExistingInvoice.Count > 0 Then sSourceStoreID = dvExistingInvoice(0)("StoreID").ToString
        End If
        If sSourceStoreID = "" Then
            dvInvoiceLayout.Table.Rows.Add(sStoreID, 0, 1, "发票抬头", 10, 10, 30, 1)
            dvInvoiceLayout.Table.Rows.Add(sStoreID, 0, 2, "发票品项", 10, 40, 45, 1)
            dvInvoiceLayout.Table.Rows.Add(sStoreID, 0, 3, "计量数量", 10, 105, 45, 1)
            dvInvoiceLayout.Table.Rows.Add(sStoreID, 0, 4, "计量单价", 10, 120, 45, 1)
            dvInvoiceLayout.Table.Rows.Add(sStoreID, 0, 5, "发票金额", 10, 140, 45, 1)
            dvInvoiceLayout.Table.Rows.Add(sStoreID, 0, 6, "大写总额", 10, 25, 80, 1)
            dvInvoiceLayout.Table.Rows.Add(sStoreID, 0, 7, "付款方式", 10, 125, 90, 1)
            dvInvoiceLayout.Table.Rows.Add(sStoreID, 0, 8, "经手人", 10, 145, 90, 1)
            dvInvoiceLayout.Table.Rows.Add(sStoreID, 0, 9, "开票日期", 10, 135, 15, 1)
            dvInvoiceLayout.Table.Rows.Add(sStoreID, 0, 10, "家乐福小票号（含标题）", 10, 110, 10, 1)
            dvInvoiceLayout.Table.Rows.Add(sStoreID, 0, 11, "购买统计信息（含标题）", 10, 5, 95, 1)
        Else
            For Each drItem As DataRow In dvInvoiceLayout.Table.Select("StoreID=" & sSourceStoreID)
                dvInvoiceLayout.Table.Rows.Add(sStoreID, 0, drItem("ItemID"), drItem("ItemName"), drItem("FontSize"), drItem("X"), drItem("Y"), drItem("IsVisible"))
            Next
        End If

        Me.btnSave.Enabled = True
    End Sub
End Class