Public Class frmInvoiceLayout

    Private blSkipDeal As Boolean = True, blIsReadOnly As Boolean = False, sStoreID As String = "", dvCity As DataView, dvStore As DataView, dvInvoiceLayout As DataView, dvExistingInvoice As DataView, editingTextBox As TextBox

    Private Sub frmInvoiceLayout_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.btnSave.Enabled Then
            Me.btnSave.Select()
            Dim bAnswer As Windows.Forms.DialogResult = MessageBox.Show("��ǰ���������Ѹ��ģ���δ���档    " & Chr(13) & Chr(13) & "�Ƿ��ڹرմ���ǰ������Щ���ģ�    " & Chr(13) & Chr(13) & "   ��    -   ������Ĳ��˳�" & Chr(13) & "   ��    -   �������Ĳ��˳�" & Chr(13) & "  ȡ��   -   ȡ���ر�", "��ȷ�ϱ�����ģ�", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

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
            frmMain.statusText.Text = "ϵͳ�����Ӳ������ݿ���޷��򿪷�Ʊ�������ô��ڡ��������ݿ����ӡ�"
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
            frmMain.statusText.Text = "ϵͳ���ڼ�������ʱ������޷��򿪷�Ʊ�������ô��ڡ�����ϵ���������Ա��"
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
                .HeaderText = "��ӡ��Ŀ"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                If Not blIsReadOnly Then .DefaultCellStyle.BackColor = Color.WhiteSmoke
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
            End With
            With .Columns(4)
                .HeaderText = "�����С"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(5)
                .HeaderText = "������� (mm)"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(6)
                .HeaderText = "�����ϱ� (mm)"
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
                .HeaderText = "�Ƿ��ӡ"
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
        If blIsReadOnly Then Me.Text = "���ŵ����÷�Ʊ���� (ֻ�� Readonly)"

        Me.dgvInvoice.Select()
        blSkipDeal = False
        frmMain.statusText.Text = "������"
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
        frmMain.statusText.Text = "���ڴ�ӡ����ҳ����"
        frmMain.statusMain.Refresh()

        Try
            Dim testPrint As New System.Drawing.Printing.PrintDocument, PrintStandard As New System.Drawing.Printing.StandardPrintController()
            testPrint.PrintController = PrintStandard '�����ִ�ӡ����
            testPrint.DocumentName = "InvoiceTestingPage"
            AddHandler testPrint.PrintPage, AddressOf testPrint_PrintPage
            testPrint.PrinterSettings.PrinterName = Me.cbbPrinter.Text
            testPrint.Print()
            testPrint.Dispose()
            frmMain.statusText.Text = "�Ѿ�����Ʊ����ҳ��ӡ��""" & Me.cbbPrinter.Text & """��"
        Catch ex As Exception
            MessageBox.Show("��ӡ����ҳʱ�������´���    " & Chr(13) & Chr(13) & ex.Message & "    ", "��ӡ����ҳ����", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "��ӡ����ҳ����"
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim dtChanges As DataTable = dvInvoiceLayout.Table.GetChanges()
        If dtChanges Is Nothing Then
            frmMain.statusText.Text = "δ�����κ��޸ģ����뱣�档"
            Me.btnSave.Enabled = False
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "���ڱ��淢Ʊ�������á���"
        frmMain.statusMain.Refresh()

        If My.Settings.InvoicePrinter <> Me.cbbPrinter.Text Then
            My.Settings.InvoicePrinter = Me.cbbPrinter.Text
            My.Settings.Save()
        End If

        Dim DB As New DataBase, blSaved As Boolean = False, blFailure As Boolean = False
        DB.Open(True)
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "ϵͳ�����Ӳ������ݿ���޷����淢Ʊ�������á��������ݿ����ӡ�"
            Me.Cursor = Cursors.Default : Return
        End If

        dtChanges = dtChanges.DefaultView.ToTable(True, "StoreID")
        For Each drStore As DataRow In dtChanges.Rows
            dvInvoiceLayout.RowFilter = "StoreID=" & drStore("StoreID").ToString
            If DB.ModifyTable("Delete From InvoiceLayout Where StoreID=" & drStore("StoreID").ToString) = -1 OrElse _
               DB.BulkCopyTable("InvoiceLayout", dvInvoiceLayout.ToTable) = -1 Then
                frmMain.statusText.Text = "���淢Ʊ��������ʧ�ܣ�"
                blFailure = blFailure
            Else
                DB.ModifyTable("Exec OperationLogInsert " & frmMain.sSSID & ",'Config Invoice Layout','Store'," & drStore("StoreID").ToString)
                blSaved = True
            End If
            If blSaved Then
                dvInvoiceLayout.Table.AcceptChanges()
                Me.btnSave.Enabled = blFailure
                MessageBox.Show("���淢Ʊ�������óɹ���    ", "���淢Ʊ�������óɹ���", MessageBoxButtons.OK, MessageBoxIcon.Information)
                frmMain.statusText.Text = "���淢Ʊ�������óɹ���"
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
                Case "��Ʊ̧ͷ"
                    sText = "�����С����������޹�˾ �����԰��棬����Ч��Ʊ����"
                Case "��ƱƷ��"
                    sText = "���ָ����￨"
                Case "��������"
                    sText = "1"
                Case "��������"
                    sText = Format(15000, "#,0.00")
                Case "��Ʊ���"
                    sText = Format(15000, "#,0.00")
                Case "��д�ܶ�"
                    sText = CapitalDigits.CapitalRMB(15000)
                Case "���ʽ"
                    sText = "֧Ʊ"
                Case "������"
                    sText = "XXX"
                Case "��Ʊ����"
                    sText = Format(Today(), "yyyy-MM-dd")
                Case "���ָ�СƱ�ţ������⣩"
                    sText = "���ָ�СƱ�ţ�" & Me.cbbStore.Text.Substring(1, 3) & Format(Today(), "yyMMdd") & "0001"
                Case "����ͳ����Ϣ�������⣩"
                    sText = "�ܹ����" & Format(15000, "#,0.00") & "  �ۿ۽�" & Format(0, "#,0.00") & "  ʵ����" & Format(15000, "#,0.00")
            End Select

            drawFont = New Font("����", drItem("FontSize"))
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
            dvInvoiceLayout.Table.Rows.Add(sStoreID, 0, 1, "��Ʊ̧ͷ", 10, 10, 30, 1)
            dvInvoiceLayout.Table.Rows.Add(sStoreID, 0, 2, "��ƱƷ��", 10, 40, 45, 1)
            dvInvoiceLayout.Table.Rows.Add(sStoreID, 0, 3, "��������", 10, 105, 45, 1)
            dvInvoiceLayout.Table.Rows.Add(sStoreID, 0, 4, "��������", 10, 120, 45, 1)
            dvInvoiceLayout.Table.Rows.Add(sStoreID, 0, 5, "��Ʊ���", 10, 140, 45, 1)
            dvInvoiceLayout.Table.Rows.Add(sStoreID, 0, 6, "��д�ܶ�", 10, 25, 80, 1)
            dvInvoiceLayout.Table.Rows.Add(sStoreID, 0, 7, "���ʽ", 10, 125, 90, 1)
            dvInvoiceLayout.Table.Rows.Add(sStoreID, 0, 8, "������", 10, 145, 90, 1)
            dvInvoiceLayout.Table.Rows.Add(sStoreID, 0, 9, "��Ʊ����", 10, 135, 15, 1)
            dvInvoiceLayout.Table.Rows.Add(sStoreID, 0, 10, "���ָ�СƱ�ţ������⣩", 10, 110, 10, 1)
            dvInvoiceLayout.Table.Rows.Add(sStoreID, 0, 11, "����ͳ����Ϣ�������⣩", 10, 5, 95, 1)
        Else
            For Each drItem As DataRow In dvInvoiceLayout.Table.Select("StoreID=" & sSourceStoreID)
                dvInvoiceLayout.Table.Rows.Add(sStoreID, 0, drItem("ItemID"), drItem("ItemName"), drItem("FontSize"), drItem("X"), drItem("Y"), drItem("IsVisible"))
            Next
        End If

        Me.btnSave.Enabled = True
    End Sub
End Class