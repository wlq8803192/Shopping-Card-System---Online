
'modify code 040:
'date;2014/11/5
'auther:Hyron bjy 
'remark:�������۵�����---�����Ῠ���۵�

'modify code 040:start-------------------------------------------------------------------------
Public Class frmInternetSalesConfigInvoice

    Private blSkipDeal As Boolean = False, blNeedCleanInvoiceCodeNo As Boolean = True, editingTextBox As TextBox
    Public sCarrefourName As String, sReceiverTaxNo As String

    Private Sub frmConfigInvoice_ForeColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ForeColorChanged
        frmMain.statusText.Text = "������"
    End Sub

    Private Sub frmConfigInvoice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If frmInternetSalesInvoice.dtInvoiceLayout.Rows(0)("IsLocked") Then
            If Me.Text = "�����÷�Ʊ���漰��ӡ����" Then Me.Text = "��Ʊ���漰��ӡ����"
            Me.lblTitle.Text = "����ӡ��Ŀ��λ�ü���ɼ��ԣ������޸ģ���"
            Me.dgvInvoice.ReadOnly = True
            Me.dgvInvoice.DefaultCellStyle.BackColor = SystemColors.Control
        ElseIf "|21|272|".IndexOf("|" & frmInternetSalesInvoice.sCityID & "|") > -1 Then '�Ϻ�
            Me.lblTitle.Text = "�Ϻ����ŵ�ֻ��ָ����Ʊ̧ͷ��λ�ã���Ӧ����ȫ������л�̨����"
        ElseIf frmInternetSalesInvoice.sCityID = "24" Then '����
            Me.lblTitle.Text = "�������ŵ�ֻ��ָ����Ʊ̧ͷ��λ�ã���Ӧ����ȫ������л�̨����"
        ElseIf frmInternetSalesInvoice.sCityID = "27" Then '�人
            Me.lblTitle.Text = "�人���ŵ�ֻ��ָ����Ʊ̧ͷ��λ�ã���Ӧ����ȫ������л�̨����"
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
                .HeaderText = "��ӡ��Ŀ"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                If Not Me.dgvInvoice.ReadOnly Then .DefaultCellStyle.BackColor = Color.WhiteSmoke
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
            If Me.Text.IndexOf("���ٿ���") > -1 Then
                Me.cbbPrinter.Items(Me.cbbPrinter.Items.IndexOf(My.Settings.InvoicePrinter)) = My.Settings.InvoicePrinter & "�������ã�"
            End If
        Else
            Dim printDoc As New Printing.PrintDocument
            Me.cbbPrinter.SelectedIndex = Me.cbbPrinter.Items.IndexOf(printDoc.PrinterSettings.PrinterName)
            printDoc.Dispose() : printDoc = Nothing
        End If

        Me.btnOK.Enabled = (Me.cbbPrinter.Text.IndexOf("�������ã�") = -1 AndAlso (Me.cbbPrinter.Text <> My.Settings.InvoicePrinter OrElse frmInternetSalesInvoice.dtInvoiceLayout.GetChanges() IsNot Nothing))
        Me.btnPrintTest.Enabled = (Me.cbbPrinter.Text.IndexOf("�������ã�") = -1)

        Me.dgvInvoice.Select()
        Me.btnCancel.Select()
    End Sub

    Private Sub dgvInvoice_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInvoice.CellContentClick
        If Me.dgvInvoice.ReadOnly Then Return
        If Me.dgvInvoice.Columns(e.ColumnIndex).Name = "IsVisible" Then
            frmMain.statusText.Text = "��Ʊ��ӡ��Ŀ�Ŀɼ���ֻ�����ܲ����ã�"
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
            frmMain.statusText.Text = "��Ʊ��ӡ��Ŀ����С�ֺ��� 8 ��"
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
                Me.btnOK.Enabled = (Me.cbbPrinter.Text.IndexOf("�������ã�") = -1)
            Else
                currentRow.AcceptChanges()
                Me.btnOK.Enabled = (Me.cbbPrinter.Text.IndexOf("�������ã�") = -1 AndAlso (Me.cbbPrinter.Text <> My.Settings.InvoicePrinter OrElse frmInternetSalesInvoice.dtInvoiceLayout.GetChanges() IsNot Nothing))
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
        Me.btnOK.Enabled = (Me.cbbPrinter.Text.IndexOf("�������ã�") = -1 AndAlso (Me.cbbPrinter.Text <> My.Settings.InvoicePrinter OrElse frmInternetSalesInvoice.dtInvoiceLayout.GetChanges() IsNot Nothing))
        Me.btnPrintTest.Enabled = (Me.cbbPrinter.Text.IndexOf("�������ã�") = -1)
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

        frmMain.statusText.Text = "���ڴ�ӡ����ҳ����"
        frmMain.statusMain.Refresh()

        Try
            Dim testPrint As New System.Drawing.Printing.PrintDocument, PrintStandard As New System.Drawing.Printing.StandardPrintController()
            testPrint.PrintController = PrintStandard '�����ִ�ӡ����
            testPrint.DocumentName = "InvoiceTestingPage"
            If "|21|24|".IndexOf("|" & frmInternetSalesInvoice.sCityID & "|") > -1 Then '�Ϻ�/����
                AddHandler testPrint.PrintPage, AddressOf testPrintSH_PrintPage
            ElseIf "|27|272|".IndexOf("|" & frmInternetSalesInvoice.sCityID & "|") > -1 Then '�人/���Գ���
                AddHandler testPrint.PrintPage, AddressOf testPrintWH_PrintPage
            Else
                AddHandler testPrint.PrintPage, AddressOf testPrint_PrintPage
            End If
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

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If frmInternetSalesInvoice.dtInvoiceLayout.GetChanges() IsNot Nothing AndAlso MessageBox.Show("ע�⣺��Ʊ��ӡ����һ�����棬�㲻�ٿ��޸ģ�    " & Chr(13) & Chr(13) & "��ȷ�����е����þ���ͨ�����ԡ��Ƿ����ھͱ��棿    ", "��ȷ�ϱ��淢Ʊ�������ã�", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then Return

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "���ڱ��淢Ʊ���á���"
        frmMain.statusMain.Refresh()

        Dim DB As New DataBase
        DB.Open(True)
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "ϵͳ�����Ӳ������ݿ���޷����淢Ʊ�������á��������ݿ����ӡ�"
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
                MessageBox.Show("�˷�Ʊ��ӡ�����ٿ��ã���ָ������Ĵ�ӡ����    ", "��Ʊ��ӡ�����ٿ��ã�", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.cbbPrinter.Items.RemoveAt(Me.cbbPrinter.Items.IndexOf(My.Settings.InvoicePrinter))
                Me.btnOK.Enabled = False
                My.Settings.InvoicePrinter = "" : My.Settings.Save()
                Me.Cursor = Cursors.Default : Return
            End Try

            If sPortName.ToUpper.IndexOf("IP_") = 0 Then
                frmInternetSalesInvoice.sInvoicePrinterDevice = sPortName
            ElseIf Net.IPAddress.TryParse(sPortName, ipAddress) Then
                frmInternetSalesInvoice.sInvoicePrinterDevice = "IP_" & sPortName 'Win7�����µ������ӡ�����ػ�Ϊ��IP��ַΪ���ƵĶ˿���
            ElseIf My.Settings.InvoicePrinter.IndexOf("\\") = 0 Then
                frmInternetSalesInvoice.sInvoicePrinterDevice = My.Settings.InvoicePrinter
            Else '�����ش�ӡ�����������ӡ������ʽ
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
                frmMain.statusText.Text = "���淢Ʊ����ʧ�ܣ�"
            Else
                DB.ModifyTable("Exec OperationLogInsert " & frmMain.sSSID & ",'Config Invoice Layout','Store'," & frmInternetSalesInvoice.sStoreID)
                frmInternetSalesInvoice.dtInvoiceLayout.AcceptChanges()
                Me.lblTitle.Text = "����ӡ��Ŀ��λ�ü���ɼ��ԣ������޸ģ���"
                Me.dgvInvoice.ReadOnly = True
                Me.dgvInvoice.Columns("ItemName").DefaultCellStyle.BackColor = SystemColors.Control
                Me.dgvInvoice.DefaultCellStyle.BackColor = SystemColors.Control
                Me.dgvInvoice.Columns("IsVisible").DefaultCellStyle.BackColor = SystemColors.Control
                MessageBox.Show("���淢Ʊ���óɹ���    ", "���淢Ʊ���óɹ���", MessageBoxButtons.OK, MessageBoxIcon.Information)
                frmMain.statusText.Text = "���淢Ʊ���óɹ���"
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
                Case "��Ʊ̧ͷ"
                    sText = "�����С����������޹�˾ �����԰��棬����Ч��Ʊ����"
                Case "��ƱƷ��"
                    sText = "���ָ����￨"
                Case "��������"
                    sText = "1"
                Case "��������"
                    sText = Format(frmInternetSalesInvoice.txtBillPayTotalAmount.Text, "#,0.00")
                Case "��Ʊ���"
                    sText = Format(frmInternetSalesInvoice.txtBillPayTotalAmount.Text, "#,0.00")
                Case "��д�ܶ�"
                    sText = CapitalDigits.CapitalRMB(frmInternetSalesInvoice.txtBillPayTotalAmount.Text)
                Case "���ʽ"
                    sText = "���ϸ���"
                Case "������"
                    sText = frmMain.sLoginUserRealName
                Case "��Ʊ����"
                    sText = Format(Today(), "yyyy-MM-dd")
                Case "������"
                    sText = "�����ţ�" & frmInternetSalesInvoice.txtBillNo.Text.Replace(" ", "")
                Case "����ͳ����Ϣ�������⣩"
                    sText = "�ܹ����" & Format(frmInternetSalesInvoice.txtBillTotalAmount.Text, "#,0.00") & "  ʵ����" & Format(frmInternetSalesInvoice.txtBillPayTotalAmount.Text, "#,0.00")
            End Select

            drawFont = New Font("����", drItem("FontSize"))
            e.Graphics.DrawString(sText, drawFont, drawBrush, drItem("X"), drItem("Y"), drawFormat)
        Next

        e.HasMorePages = False
    End Sub

    Private Sub testPrintSH_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        e.Graphics.PageUnit = GraphicsUnit.Millimeter

        Dim drawFont As New Font("����", 10), drawBrush As New SolidBrush(Color.Black), drawFormat As New StringFormat
        drawFormat.FormatFlags = StringFormatFlags.NoWrap
        Dim x As Integer = frmInternetSalesInvoice.dtInvoiceLayout.Rows(0)("X"), y As Integer = frmInternetSalesInvoice.dtInvoiceLayout.Rows(0)("Y")

        If My.Settings.IsInTraining Then
            drawFont = New Font("����", 12, FontStyle.Bold)
            x -= 6 : y -= 18
            e.Graphics.DrawString("����ѵʹ�ã�����Ч��Ʊ����", drawFont, drawBrush, x, y, drawFormat)
            drawFont = New Font("����", 10)
            x = frmInternetSalesInvoice.dtInvoiceLayout.Rows(0)("X") : y = frmInternetSalesInvoice.dtInvoiceLayout.Rows(0)("Y")
        End If

        x += 13 : y -= 8 '��Ʊ����
        e.Graphics.DrawString(Format(Today(), "yyyy-MM-dd"), drawFont, drawBrush, x, y, drawFormat)
        x += 56 '��ҵ����
        e.Graphics.DrawString("��ҵ", drawFont, drawBrush, x, y, drawFormat)
        x += 98 '������
        drawFormat.Alignment = StringAlignment.Far
        e.Graphics.DrawString("�����ţ�" & frmInternetSalesInvoice.txtBillNo.Text.Replace(" ", ""), drawFont, drawBrush, x, y, drawFormat)
        x -= 167 : y += 8 '���λ����
        drawFormat.Alignment = StringAlignment.Near
        e.Graphics.DrawString("���λ���ƣ������С����������޹�˾", drawFont, drawBrush, x, y, drawFormat)
        x += 110 '���λ˰��
        e.Graphics.DrawString("���λ˰�ţ�", drawFont, drawBrush, x, y, drawFormat)
        x -= 110 : y += 6 '�տλ����
        e.Graphics.DrawString("�տλ���ƣ�" & sCarrefourName, drawFont, drawBrush, x, y, drawFormat)
        x += 110 '�տλ˰��
        e.Graphics.DrawString("�տλ˰�ţ�" & sReceiverTaxNo, drawFont, drawBrush, x, y, drawFormat)
        x -= 110 : y += 6 '���⡰��Ʒ��š�
        e.Graphics.DrawString("��Ʒ���", drawFont, drawBrush, x, y, drawFormat)
        x += 20 '���⡰��Ʒ���ơ�
        e.Graphics.DrawString("��Ʒ����", drawFont, drawBrush, x, y, drawFormat)
        x += 50 '���⡰��λ��
        e.Graphics.DrawString("��λ", drawFont, drawBrush, x, y, drawFormat)
        x += 25 '���⡰������
        e.Graphics.DrawString("����", drawFont, drawBrush, x, y, drawFormat)
        x += 25 '���⡰���ۡ�
        e.Graphics.DrawString("����", drawFont, drawBrush, x, y, drawFormat)
        x += 25 '���⡰��
        e.Graphics.DrawString("���", drawFont, drawBrush, x, y, drawFormat)
        y += 5 : x -= 125 '��ƱƷ��
        e.Graphics.DrawString("���ָ����￨", drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Center
        x += 79 '����
        e.Graphics.DrawString("1", drawFont, drawBrush, x, y, drawFormat)
        x += 25 '����
        e.Graphics.DrawString(Format(frmInternetSalesInvoice.txtBillPayTotalAmount.Text, "#,0.00"), drawFont, drawBrush, x, y, drawFormat)
        x += 25 '�ܼ�
        e.Graphics.DrawString(Format(frmInternetSalesInvoice.txtBillPayTotalAmount.Text, "#,0.00"), drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Near
        'y += 5 : x -= 18 '�ۿ�
        'drawFormat.Alignment = StringAlignment.Far
        'e.Graphics.DrawString("�ۿۣ�", drawFont, drawBrush, x, y, drawFormat)
        'drawFormat.Alignment = StringAlignment.Center
        'x += 18 '�ۿ۽��
        'drawFormat.Alignment = StringAlignment.Center
        'e.Graphics.DrawString(Format(.drSalesBill("RebateSalesAMT"), "#,0.00"), drawFont, drawBrush, x, y, drawFormat)
        y += 5 : x -= 18 'ʵ�����
        drawFormat.Alignment = StringAlignment.Far
        e.Graphics.DrawString("ʵ����", drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Center
        x += 18 'ʵ�����
        drawFormat.Alignment = StringAlignment.Center
        e.Graphics.DrawString(Format(frmInternetSalesInvoice.txtBillPayTotalAmount.Text, "#,0.00"), drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Near
        x -= 149 : y += 40 '��д���
        e.Graphics.DrawString("�ϼƽ���д������ң���" & CapitalDigits.CapitalRMB(frmInternetSalesInvoice.txtBillPayTotalAmount.Text), drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Far
        x += 160 'Сд���
        e.Graphics.DrawString("�ϼƽ��Сд��" & Format(frmInternetSalesInvoice.txtBillPayTotalAmount.Text, "#,0.00"), drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Near
        x -= 160 : y += 16 '��Ʊ��
        e.Graphics.DrawString("��Ʊ�ˣ�" & frmMain.sLoginUserRealName, drawFont, drawBrush, x, y, drawFormat)
        'x += 35 '�տ���
        'e.Graphics.DrawString("�տ��ˣ�" & .drSalesBill("CreatorName").ToString, drawFont, drawBrush, x, y, drawFormat)
        x += 35 '���ʽ
        Dim sText As String = "���ϸ���"
        e.Graphics.DrawString("���ʽ��" & sText, drawFont, drawBrush, x, y, drawFormat)
        x += 35 '���⡰��Ʊ��λ�����£���
        e.Graphics.DrawString("��Ʊ��λ�����£���", drawFont, drawBrush, x, y, drawFormat)

        e.HasMorePages = False
    End Sub

    Private Sub testPrintWH_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        e.Graphics.PageUnit = GraphicsUnit.Millimeter

        Dim drawFont As New Font("����", 10), drawBrush As New SolidBrush(Color.Black), drawFormat As New StringFormat
        drawFormat.FormatFlags = StringFormatFlags.NoWrap
        Dim x As Integer = frmInternetSalesInvoice.dtInvoiceLayout.Rows(0)("X"), y As Integer = frmInternetSalesInvoice.dtInvoiceLayout.Rows(0)("Y")

        If My.Settings.IsInTraining Then
            drawFont = New Font("����", 12, FontStyle.Bold)
            x -= 6 : y -= 18
            e.Graphics.DrawString("����ѵʹ�ã�����Ч��Ʊ����", drawFont, drawBrush, x, y, drawFormat)
            drawFont = New Font("����", 10)
            x = frmInternetSalesInvoice.dtInvoiceLayout.Rows(0)("X") : y = frmInternetSalesInvoice.dtInvoiceLayout.Rows(0)("Y")
        End If

        x += 13 : y -= 10 '��Ʊ����
        e.Graphics.DrawString(Format(Today(), "yyyy-MM-dd"), drawFont, drawBrush, x, y, drawFormat)
        x += 56 '��ҵ����
        e.Graphics.DrawString("��ҵ", drawFont, drawBrush, x, y, drawFormat)
        x += 78 : y += 2 '������
        drawFormat.Alignment = StringAlignment.Far
        e.Graphics.DrawString("�����ţ�" & frmInternetSalesInvoice.txtBillNo.Text.Replace(" ", ""), drawFont, drawBrush, x, y, drawFormat)
        x -= 147 : y += 8 '���λ����
        drawFormat.Alignment = StringAlignment.Near
        e.Graphics.DrawString("���λ���ƣ������С����������޹�˾", drawFont, drawBrush, x, y, drawFormat)
        x += 90 '���λ˰��
        e.Graphics.DrawString("���λ˰�ţ�", drawFont, drawBrush, x, y, drawFormat)
        x -= 90 : y += 6 '�տλ����
        e.Graphics.DrawString("�տλ���ƣ�" & sCarrefourName, drawFont, drawBrush, x, y, drawFormat)
        x += 90 '�տλ˰��
        e.Graphics.DrawString("�տλ˰�ţ�" & sReceiverTaxNo, drawFont, drawBrush, x, y, drawFormat)
        x -= 90 : y += 6 '���⡰��Ʒ��š�
        e.Graphics.DrawString("��Ʒ���", drawFont, drawBrush, x, y, drawFormat)
        x += 20 '���⡰��Ʒ���ơ�
        e.Graphics.DrawString("��Ʒ����", drawFont, drawBrush, x, y, drawFormat)
        x += 40 '���⡰��λ��
        e.Graphics.DrawString("��λ", drawFont, drawBrush, x, y, drawFormat)
        x += 20 '���⡰������
        e.Graphics.DrawString("����", drawFont, drawBrush, x, y, drawFormat)
        x += 20 '���⡰���ۡ�
        e.Graphics.DrawString("����", drawFont, drawBrush, x, y, drawFormat)
        x += 25 '���⡰��
        e.Graphics.DrawString("���", drawFont, drawBrush, x, y, drawFormat)
        y += 5 : x -= 105 '��ƱƷ��
        e.Graphics.DrawString("���ָ����￨".ToString, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Center
        x += 64 '����
        e.Graphics.DrawString("1", drawFont, drawBrush, x, y, drawFormat)
        x += 20 '����
        e.Graphics.DrawString(Format(frmInternetSalesInvoice.txtBillPayTotalAmount.Text, "#,0.00"), drawFont, drawBrush, x, y, drawFormat)
        x += 25 '�ܼ�
        e.Graphics.DrawString(Format(frmInternetSalesInvoice.txtBillPayTotalAmount.Text, "#,0.00"), drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Near
        'y += 5 : x -= 18 '�ۿ�
        'drawFormat.Alignment = StringAlignment.Far
        'e.Graphics.DrawString("�ۿۣ�", drawFont, drawBrush, x, y, drawFormat)
        'drawFormat.Alignment = StringAlignment.Center
        'x += 18 '�ۿ۽��
        'drawFormat.Alignment = StringAlignment.Center
        'e.Graphics.DrawString(Format(.drSalesBill("RebateSalesAMT"), "#,0.00"), drawFont, drawBrush, x, y, drawFormat)
        y += 5 : x -= 18 'ʵ�����
        drawFormat.Alignment = StringAlignment.Far
        e.Graphics.DrawString("ʵ����", drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Center
        x += 18 'ʵ�����
        drawFormat.Alignment = StringAlignment.Center
        e.Graphics.DrawString(Format(frmInternetSalesInvoice.txtBillPayTotalAmount.Text, "#,0.00"), drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Near
        x -= 129 : y += 15 '��д���
        e.Graphics.DrawString("�ϼƽ���д������ң���" & CapitalDigits.CapitalRMB(frmInternetSalesInvoice.txtBillPayTotalAmount.Text), drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Far
        x += 140 'Сд���
        e.Graphics.DrawString("�ϼƽ��Сд��" & Format(frmInternetSalesInvoice.txtBillPayTotalAmount.Text, "#,0.00"), drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Near
        x -= 140 : y += 5 '��Ʊ��
        e.Graphics.DrawString("��Ʊ�ˣ�" & frmMain.sLoginUserRealName, drawFont, drawBrush, x, y, drawFormat)
        'x += 35 '�տ���
        'e.Graphics.DrawString("�տ��ˣ�" & .drSalesBill("CreatorName").ToString, drawFont, drawBrush, x, y, drawFormat)
        x += 35 '���ʽ
        Dim sText As String = "���ϸ���"
        e.Graphics.DrawString("���ʽ��" & sText, drawFont, drawBrush, x, y, drawFormat)
        x += 35 '���⡰��Ʊ��λ�����£���
        e.Graphics.DrawString("��Ʊ��λ�����£���", drawFont, drawBrush, x, y, drawFormat)

        e.HasMorePages = False
    End Sub
End Class
'modify code 040:end-------------------------------------------------------------------------