
'modify code 040:
'date;2014/11/5
'auther:Hyron bjy 
'remark:�������۵�����---�����Ῠ���۵�

'modify code 042:
'date;2014/12/11
'auther:Hyron bjy 
'remark: �ɶ���Ʊȥ�����ʽ��Ŀ

'modify code 041:
'date;2014/11/28
'auther:Hyron bjy 
'remark:�����ķ�Ʊ��ӡͬ�ɶ�

'modify code 070:
'date;2017/3/31
'auther:Qipeng
'remark:ȡ������31�첻�ܴ�ӡ��Ʊ������

'modify code 040:start-------------------------------------------------------------------------
Public Class frmInternetSalesPrintInvoice

    Private blSkipDeal As Boolean = True, dmAvailableAMT As Decimal = 0, dmReprintableAMT As Decimal = 0, dtPrintItem As DataTable, bShowTimes As Byte = 0, bSeconds As Byte = 10, iMultiPrint As Int16 = 2
    Private sMachineNo As String = "", sInvoiceCode As String = "", sInvoiceNo As String = "", sInvoiceSecurityCode As String = "", sPrintedTime As String = ""
    Public blIsDeduction As Boolean = False, dmTotalChargedAMT As Decimal = 0, dmTotalRebateAMT As Decimal = 0, sCarrefourName As String, sReceiverTaxNo As String

    Private Sub frmInternetSalesPrintInvoice_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If frmMain.statusText.Text.IndexOf("�޷�") = -1 Then frmMain.statusText.Text = "������"
    End Sub

    Private Sub frmInternetSalesPrintInvoice_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If dmReprintableAMT > 0 Then
            Dim bAnswer As DialogResult = Windows.Forms.DialogResult.Cancel
            If frmInternetSalesInvoice.dtInvoice.Select("Remarks Like 'ʣ����%'").Length > 0 Then
                bAnswer = MessageBox.Show("���Ѿ�ȡ����ĳЩ��Ʊ�������в����Ѿ�ȡ���ķ�Ʊ���δ���ش�ӡ��    " & Chr(13) & Chr(13) & "��Ӧ�ü�ʱ�ش�ӡ��Щʣ������򣬿��ܻ���Ϊ�������ش�ӡʱ�޶���Ҳ�����ش�ӡ�ⲿ�ֽ�    " & Chr(13) & Chr(13) & "��ȷʵ�������ھ��ش�ӡʣ�෢Ʊ�����    ", "��ȷ���˳���Ʊ���ڣ�", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            Else
                bAnswer = MessageBox.Show("���Ѿ�ȡ����ĳЩ��Ʊ����δ�Լ���ȡ���ķ�Ʊ�������ش�ӡ��    " & Chr(13) & Chr(13) & "�����˳���Ʊ���ڽ�������Ʊȡ���������Ƿ��˳���    ", "��ȷ���˳���Ʊ���ڣ�", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            End If
            If bAnswer = Windows.Forms.DialogResult.OK Then
                frmInternetSalesInvoice.dtInvoice.RejectChanges()
            Else
                Me.txbInvoiceAMT.Select()
                Me.txbInvoiceAMT.SelectAll()
                e.Cancel = True
            End If
        Else
            frmInternetSalesInvoice.dtInvoice.RejectChanges()
        End If
    End Sub

    Private Sub frmInternetSalesPrintInvoice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dmAvailableAMT = CDec(Me.txbAvailableInvoiceAMT.Text)
        Try
            dmReprintableAMT = frmInternetSalesInvoice.dtInvoice.Compute("Sum(ReprintableAMT)", "")
        Catch
            dmReprintableAMT = 0
        End Try

        With Me.dgvInvoice
            .DataSource = frmInternetSalesInvoice.dtInvoice
            With .Columns(0)
                .HeaderText = "�к�"
                .Width = 40
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
            End With
            With .Columns(1)
                .HeaderText = "��Ʊ����"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(2)
                .HeaderText = "��Ʊ����"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(3)
                .HeaderText = "��Ʊ̧ͷ"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(4)
                .HeaderText = "��ƱƷ��"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(5)
                .HeaderText = "��Ʊ���"
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(6)
                .HeaderText = "����"
                .DefaultCellStyle.Format = "#,0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(7)
                .HeaderText = "���ʽ"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(8)
                .HeaderText = "��ӡ��"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(9)
                .HeaderText = "��ӡʱ��"
                .DefaultCellStyle.Format = "yyyy\/MM\/dd HH:mm:ss"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(10)
                .HeaderText = "ԭ��Ʊ"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .Visible = (frmInternetSalesInvoice.dtInvoice.Select("Isnull(SourceInvoice,'')<>''").Length > 0)
            End With
            With .Columns(11)
                .HeaderText = "״̬"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(12)
                .HeaderText = "ȡ�����ش�ӡԭ��"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .Visible = (frmInternetSalesInvoice.dtInvoice.Select("Isnull(CancelledReason,'')<>''").Length > 0)
            End With
            With .Columns(13)
                .HeaderText = "˵��"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .Visible = (frmInternetSalesInvoice.dtInvoice.Select("Isnull(Remarks,'')<>''").Length > 0)
            End With
            Dim newButtonColumn As New DataGridViewButtonColumn
            With newButtonColumn
                .DataPropertyName = "Reprint"
                .DefaultCellStyle.ForeColor = SystemColors.ControlText
                .DefaultCellStyle.SelectionForeColor = SystemColors.ControlText
                .DefaultCellStyle.BackColor = SystemColors.Control
                .DefaultCellStyle.SelectionBackColor = SystemColors.Control
                .DefaultCellStyle.Padding = New Padding(1)
            End With
            .Columns.RemoveAt(14)
            .Columns.Insert(14, newButtonColumn)
            With .Columns(14)
                .HeaderText = "����"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.BackColor = SystemColors.Control
                .DefaultCellStyle.SelectionBackColor = SystemColors.Highlight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .Visible = (frmMain.dtAllowedRight.Select("RightName='E-CardInvoice'").Length > 0)
            End With
            .Columns(15).Visible = False
            .Columns(16).Visible = False
            .Columns(17).Visible = False
        End With
        For bColumn As Byte = 0 To frmInternetSalesInvoice.dtInvoice.Columns.Count - 1
            Me.dgvInvoice.Columns(bColumn).Name = frmInternetSalesInvoice.dtInvoice.Columns(bColumn).ColumnName
        Next

        If frmMain.dtAllowedRight.Select("RightName='E-CardInvoice'").Length > 0 Then
            With Me.cbbInvoiceItem1
                For Each drItem As DataRow In frmInternetSalesInvoice.dtInvoiceItem.Select("", "ItemID")
                    .Items.Add(drItem("Content").ToString)
                Next
                .SelectedIndex = 0
            End With

            With Me.cbbInvoiceItem2
                .Items.Add("��û��Ʒ�")
                If frmInternetSalesInvoice.dtInvoiceItem.Rows.Count = 1 Then
                    .SelectedIndex = 0
                Else
                    For Each drItem As DataRow In frmInternetSalesInvoice.dtInvoiceItem.Select("Content<>'" & Me.cbbInvoiceItem1.Text.Replace("'", "''") & "'", "ItemID")
                        .Items.Add(drItem("Content").ToString)
                    Next
                    .SelectedIndex = IIf(.Items.Count = 2, 1, 0)
                End If
            End With
        End If

        blSkipDeal = False
        Me.grbNewInvoiceExtra.Visible = (Not frmMain.blUseInvoiceDevice)
        If dmAvailableAMT + dmReprintableAMT = 0 OrElse frmMain.dtAllowedRight.Select("RightName='E-CardInvoice'").Length = 0 Then
            Me.pnlNewInvoice.Visible = False
            Me.btnPrintInvoice.Enabled = False
            Me.btnPrintInvoice.Visible = False
        Else
            If dmReprintableAMT = 0 Then
                Me.btnPrintInvoice.Text = "��ӡ��Ʊ(&I)"
            Else
                Me.btnPrintInvoice.Text = "�ش�ӡ��Ʊ(&I)"
            End If

            If Not frmInternetSalesInvoice.drInvoicePrintable("CanPrintInNextMonth") AndAlso Today() > CDate(Format(DateAdd(DateInterval.Month, 1, CDate(ConvertStrToDatetime(frmInternetSalesInvoice.oair.OrderAllInfoData.BillCreateTimestamp))), "yyyy\/MM\/dd").Substring(0, 8) & "01") Then
                For Each ctrl As Control In Me.grbNewInvoice.Controls
                    ctrl.Enabled = False
                Next
                For Each ctrl As Control In Me.grbNewInvoiceExtra.Controls
                    ctrl.Enabled = False
                Next
                Me.lblError.Text = "��Ӧ����˰����""���ɹ��´�ӡ��Ʊ""�Ĺ涨�������ܴ�ӡ��Ʊ����"
                Me.lblError.Visible = True
                'modify code 070:start-------------------------------------------------------------------------
                'ElseIf DateDiff(DateInterval.Day, CDate(ConvertStrToDatetime(frmInternetSalesInvoice.oair.OrderAllInfoData.BillCreateTimestamp)), Today()) > 31 Then
                '    For Each ctrl As Control In Me.grbNewInvoice.Controls
                '        ctrl.Enabled = False
                '    Next
                '    For Each ctrl As Control In Me.grbNewInvoiceExtra.Controls
                '        ctrl.Enabled = False
                '    Next
                '    Me.lblError.Text = "����ǰ���۵��ѳ��� 31 ��ķ�Ʊ��ӡ��Ч�ڣ������ܴ�ӡ��Ʊ����"
                '    Me.lblError.Visible = True
                'modify code 070:end-------------------------------------------------------------------------
            ElseIf dmAvailableAMT + dmReprintableAMT < frmInternetSalesInvoice.drInvoicePrintable("MinInvoiceAMT") Then
                For Each ctrl As Control In Me.grbNewInvoice.Controls
                    ctrl.Enabled = False
                Next
                For Each ctrl As Control In Me.grbNewInvoiceExtra.Controls
                    ctrl.Enabled = False
                Next
                Me.lblError.Text = "���ɴ�ӡ��Ʊ���С��ϵͳ�趨�ĵ��ŷ�Ʊ��С����"
                Me.lblError.Visible = True
            Else
                If frmMain.blUseInvoiceDevice Then
                    Dim sResult As String = "OK"
                    If Not frmMain.blInvoiceDeviceOK Then sResult = frmMain.InvoiceDeviceCheck(False)
                    If Not frmMain.blInvoiceDeviceOK Then
                        For Each ctrl As Control In Me.grbNewInvoice.Controls
                            ctrl.Enabled = False
                        Next
                        For Each ctrl As Control In Me.grbNewInvoiceExtra.Controls
                            ctrl.Enabled = False
                        Next
                        Me.lblError.Text = "��" & sResult & "���ܴ�ӡ��Ʊ����"
                        Me.lblError.Visible = True
                    End If
                End If

                If Not frmMain.blUseInvoiceDevice OrElse frmMain.blInvoiceDeviceOK Then Me.txbInvoiceAMT.Text = Format(IIf(dmAvailableAMT + dmReprintableAMT <= frmInternetSalesInvoice.drInvoicePrintable("MaxInvoiceAMT"), dmAvailableAMT + dmReprintableAMT, frmInternetSalesInvoice.drInvoicePrintable("MaxInvoiceAMT")), "#,0.00")
            End If
        End If

        If "|21|272|".IndexOf(frmInternetSalesInvoice.sCityID) > 0 Then '�Ϻ������Գ���
            Me.chbPrintLine.Visible = Me.pnlNewInvoice.Visible
            Me.chbPrintLine.Checked = My.Settings.PrintInvoiceLine
        Else
            Me.chbPrintLine.Visible = False
        End If
        Me.ResetInterface()

        If Me.grbPrintedInvoice.Visible Then Me.dgvInvoice.Select()
        If Me.pnlNewInvoice.Visible Then Me.txbInvoiceAMT.Select() : Me.txbInvoiceAMT.SelectAll()

        If dmReprintableAMT > 0 Then
            Dim drPending As DataRow = frmInternetSalesInvoice.dtInvoice.Select("ReprintableAMT>0")(0)
            Me.dgvInvoice.FirstDisplayedScrollingRowIndex = drPending("RowID") - 1
            drPending = Nothing
            Me.theTimer.Enabled = True
        End If

        Me.newInvoiceNoTimer.Enabled = True
        If frmInternetSalesInvoice.blInvoicePrinterMultiUser Then Me.btnGetNewInvoiceNo.Text = "10����ȡ��һ�����ú���"
    End Sub

    Private Sub theTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles theTimer.Tick
        bShowTimes += 1
        If bShowTimes = 7 Then bShowTimes = 0 : Me.theTimer.Enabled = False
        Me.dgvInvoice.Refresh()
    End Sub

    Private Sub newInvoiceNoTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles newInvoiceNoTimer.Tick
        bSeconds -= 1
        If bSeconds = 0 Then
            Me.btnGetNewInvoiceNo.Text = "��ȡ��һ�����÷�Ʊ����"
            Me.btnGetNewInvoiceNo.Enabled = (frmInternetSalesInvoice.blInvoicePrinterMultiUser AndAlso Me.btnPrintInvoice.Enabled)
            Me.newInvoiceNoTimer.Enabled = False
        ElseIf frmInternetSalesInvoice.blInvoicePrinterMultiUser Then
            Me.btnGetNewInvoiceNo.Text = bSeconds.ToString & "����ȡ��һ�����ú���"
        End If
    End Sub

    Private Sub dgvInvoice_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInvoice.CellContentClick
        If e.RowIndex = -1 OrElse Me.dgvInvoice.Columns(e.ColumnIndex).Name <> "Reprint" Then Return
        If Me.dgvInvoice("InvoiceState", e.RowIndex).Value.ToString = "�ѱ�ȡ��" OrElse (Me.dgvInvoice("Remarks", e.RowIndex).Value.ToString <> "" AndAlso Me.dgvInvoice("Remarks", e.RowIndex).Value.ToString.IndexOf("�ش�ӡʱ�ޣ�") = -1) Then Return

        If frmMain.dtAllowedRight.Select("RightName='E-CardInvoice'").Length = 0 Then
            MessageBox.Show("�Բ�����û���ش�ӡ���۷�Ʊ��Ȩ�ޡ�    ", "����Ȩ�ش�ӡ���۷�Ʊ��", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.dgvInvoice.Columns(e.ColumnIndex).Visible = False
            Me.dgvInvoice.Columns("InvoiceTitle").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Return
        End If

        frmMain.statusText.Text = "������"
        Dim drInvoice As DataRow = frmInternetSalesInvoice.dtInvoice.Select("RowID=" & Me.dgvInvoice("RowID", e.RowIndex).Value.ToString)(0)
        If drInvoice("InvoiceState").ToString = "����" Then
            If drInvoice("ReprintableTimes") = 0 Then
                MessageBox.Show("�ܲ����񲿹涨��һ�ŷ�Ʊ�����ش�ӡ���Ρ�    " & Chr(13) & Chr(13) & "�÷�Ʊ��ԭ��Ʊ�ѱ��ش�ӡ�����Σ����Բ��ٿɴ�ӡ��    ", "�ش�ӡ��Ʊ���ܳ������Σ�", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                drInvoice("Remarks") = "ԭ��Ʊ�ѱ��ش�ӡ�����Σ��������ٴ�ӡ��"
                With Me.dgvInvoice.Columns("Remarks")
                    .Visible = True
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
            ElseIf DateAdd(DateInterval.Second, frmInternetSalesInvoice.iDifferenceSeconds, drInvoice("ReprintableTime")) < Now() Then
                MessageBox.Show("�ܲ����񲿹涨����Ʊֻ����һ��Сʱ֮���ش�ӡ�� ֮���������ش�ӡ��    ", "��Ʊ�Ѿ��������ش�ӡ��ʱ�ޣ�", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                drInvoice("Remarks") = "�÷�Ʊ" & IIf(drInvoice("SourceInvoice").ToString = "", "", "��ԭ��Ʊ") & "�Ѿ��������ش�ӡ��ʱ�ޣ�"
                With Me.dgvInvoice.Columns("Remarks")
                    .Visible = True
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
            Else
                If frmMain.blUseInvoiceDevice AndAlso Not frmMain.blInvoiceDeviceOK Then
                    Dim sResult As String = frmMain.InvoiceDeviceCheck()
                    If Not frmMain.blInvoiceDeviceOK Then
                        drInvoice("Remarks") = sResult & "����ȡ����Ʊ����"
                        With Me.dgvInvoice.Columns("Remarks")
                            .Visible = True
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        End With
                    End If
                End If

                If Not frmMain.blUseInvoiceDevice OrElse frmMain.blInvoiceDeviceOK Then
                    Dim sReprintReason As String = ""
                    With frmReprintInvoiceReason
                        If .ShowDialog = Windows.Forms.DialogResult.OK Then sReprintReason = .txbReprintReason.Text.Trim
                        .Dispose()
                    End With
                    If sReprintReason = "" Then Return

                    dmReprintableAMT += drInvoice("InvoiceAMT")
                    drInvoice("InvoiceState") = "����ȡ��"
                    drInvoice("CancelledReason") = sReprintReason
                    drInvoice("Remarks") = "���ش�ӡ��" & Format(drInvoice("InvoiceAMT"), "#,0.00").Replace(".00", "") & "�����ش�ӡʱ�ޣ�" & Format(drInvoice("ReprintableTime"), "HH:mm:ss") & "��"
                    drInvoice("Reprint") = "�����ش�ӡ"
                    drInvoice("ReprintableAMT") = drInvoice("InvoiceAMT")
                    With Me.dgvInvoice
                        With .Columns("InvoiceState")
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        End With
                        With .Columns("CancelledReason")
                            .Visible = True
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        End With
                        With .Columns("Remarks")
                            .Visible = True
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        End With
                        With .Columns("Reprint")
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        End With
                    End With
                    If dmAvailableAMT + dmReprintableAMT >= frmInternetSalesInvoice.drInvoicePrintable("MinInvoiceAMT") Then
                        Me.txbInvoiceAMT.Text = Format(IIf(dmAvailableAMT + dmReprintableAMT <= frmInternetSalesInvoice.drInvoicePrintable("MaxInvoiceAMT"), dmAvailableAMT + dmReprintableAMT, frmInternetSalesInvoice.drInvoicePrintable("MaxInvoiceAMT")), "#,0.00")
                    Else
                        Me.txbInvoiceAMT.Text = "0.00"
                    End If
                    Me.pnlNewInvoice.Visible = True
                    Me.btnPrintInvoice.Text = "�ش�ӡ��Ʊ(&I)"
                    Me.btnPrintInvoice.Visible = True
                    Me.theTimer.Enabled = True
                End If
            End If
        Else '�����ش�ӡ
            dmReprintableAMT -= drInvoice("InvoiceAMT")
            drInvoice.RejectChanges()
            With Me.dgvInvoice
                With .Columns("InvoiceState")
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                With .Columns("CancelledReason")
                    If frmInternetSalesInvoice.dtInvoice.Select("Isnull(CancelledReason,'')<>''").Length = 0 Then
                        .Visible = False
                    Else
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    End If
                End With
                With .Columns("Remarks")
                    If frmInternetSalesInvoice.dtInvoice.Select("Isnull(Remarks,'')<>''").Length = 0 Then
                        .Visible = False
                    Else
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    End If
                End With
                With .Columns("Reprint")
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
            End With
            If dmAvailableAMT + dmReprintableAMT >= frmInternetSalesInvoice.drInvoicePrintable("MinInvoiceAMT") Then
                Me.txbInvoiceAMT.Text = Format(IIf(dmAvailableAMT + dmReprintableAMT <= frmInternetSalesInvoice.drInvoicePrintable("MaxInvoiceAMT"), dmAvailableAMT + dmReprintableAMT, frmInternetSalesInvoice.drInvoicePrintable("MaxInvoiceAMT")), "#,0.00")
            Else
                Me.txbInvoiceAMT.Text = "0.00"
            End If
            Me.pnlNewInvoice.Visible = (dmAvailableAMT + dmReprintableAMT > 0)
            Me.btnPrintInvoice.Text = IIf(dmReprintableAMT = 0, "��ӡ��Ʊ(&I)", "�ش�ӡ��Ʊ(&I)")
            Me.btnPrintInvoice.Visible = Me.pnlNewInvoice.Visible
        End If

        Me.ResetInterface()
        If Me.dgvInvoice.CurrentRow IsNot Nothing Then Me.dgvInvoice.FirstDisplayedScrollingRowIndex = Me.dgvInvoice.CurrentRow.Index
        If Me.grbPrintedInvoice.Visible Then Me.dgvInvoice.Select()
        If Me.pnlNewInvoice.Visible Then
            Me.chbPrintLine.Visible = ("|21|272|".IndexOf(frmInternetSalesInvoice.sCityID) > 0) '�Ϻ������Գ���
        Else
            Me.chbPrintLine.Visible = False
        End If
    End Sub

    Private Sub dgvInvoice_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvInvoice.CellFormatting
        If Me.dgvInvoice("InvoiceState", e.RowIndex).Value.ToString = "�ѱ�ȡ��" Then
            e.CellStyle.BackColor = Color.WhiteSmoke
            e.CellStyle.SelectionBackColor = SystemColors.GradientInactiveCaption
            If Me.dgvInvoice.Columns(e.ColumnIndex).Name = "Remarks" Then
                If e.Value.ToString <> "" AndAlso e.Value.ToString.IndexOf("�ش�ӡʱ�ޣ�") = -1 Then
                    e.CellStyle.ForeColor = Color.Red
                    e.CellStyle.SelectionForeColor = Color.Brown
                Else
                    Select Case bShowTimes
                        Case 1, 3, 5
                            e.CellStyle.ForeColor = e.CellStyle.BackColor
                            e.CellStyle.SelectionForeColor = e.CellStyle.SelectionBackColor
                        Case Else
                            e.CellStyle.ForeColor = Color.Blue
                            e.CellStyle.SelectionForeColor = Color.Navy
                    End Select
                End If
            Else
                e.CellStyle.ForeColor = Color.Orange
                e.CellStyle.SelectionForeColor = Color.Yellow
            End If
        ElseIf Me.dgvInvoice("InvoiceState", e.RowIndex).Value.ToString = "����ȡ��" Then
            e.CellStyle.BackColor = Color.WhiteSmoke
            e.CellStyle.SelectionBackColor = SystemColors.GradientInactiveCaption
            If Me.dgvInvoice.Columns(e.ColumnIndex).Name = "Remarks" Then
                If e.Value.ToString <> "" AndAlso e.Value.ToString.IndexOf("�ش�ӡʱ�ޣ�") = -1 Then
                    e.CellStyle.ForeColor = Color.Red
                    e.CellStyle.SelectionForeColor = Color.Brown
                Else
                    Select Case bShowTimes
                        Case 1, 3, 5
                            e.CellStyle.ForeColor = e.CellStyle.BackColor
                            e.CellStyle.SelectionForeColor = e.CellStyle.SelectionBackColor
                        Case Else
                            e.CellStyle.ForeColor = Color.Blue
                            e.CellStyle.SelectionForeColor = Color.Navy
                    End Select
                End If
            Else
                e.CellStyle.ForeColor = Color.Crimson
                e.CellStyle.SelectionForeColor = Color.DeepPink
            End If
        ElseIf Me.dgvInvoice.Columns(e.ColumnIndex).Name = "Remarks" Then
            e.CellStyle.ForeColor = Color.Red
            e.CellStyle.SelectionForeColor = Color.Brown
        End If

        If Me.dgvInvoice.Columns(e.ColumnIndex).Name = "Reprint" AndAlso (Me.dgvInvoice("InvoiceState", e.RowIndex).Value.ToString = "�ѱ�ȡ��" OrElse (Me.dgvInvoice("Remarks", e.RowIndex).Value.ToString <> "" AndAlso Me.dgvInvoice("Remarks", e.RowIndex).Value.ToString.IndexOf("�ش�ӡʱ�ޣ�") = -1)) Then
            e.CellStyle.Padding = New Padding(0, 24, 0, 0)
        End If
    End Sub

    Private Sub dgvInvoice_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvInvoice.Leave
        If Me.dgvInvoice.CurrentCell IsNot Nothing Then Me.dgvInvoice.CurrentCell.Selected = False
        If Me.dgvInvoice.CurrentRow IsNot Nothing Then Me.dgvInvoice.CurrentRow.Selected = False
    End Sub

    Private Sub cbbInvoiceItem1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbInvoiceItem1.SelectedIndexChanged
        If blSkipDeal Then Return

        If Me.cbbInvoiceItem2.Items.Count > 1 Then
            Dim sOldInvoiceItem2 As String = Me.cbbInvoiceItem2.Text
            With Me.cbbInvoiceItem2
                .Items.Clear()
                .Items.Add("��û��Ʒ�")
                For Each drItem As DataRow In frmInternetSalesInvoice.dtInvoiceItem.Select("Content<>'" & Me.cbbInvoiceItem1.Text.Replace("'", "''") & "'", "ItemID")
                    .Items.Add(drItem("Content").ToString)
                Next
                If sOldInvoiceItem2 = Me.cbbInvoiceItem1.Text Then
                    .SelectedIndex = 0
                Else
                    .SelectedIndex = .Items.IndexOf(sOldInvoiceItem2)
                End If
            End With
        End If
    End Sub

    Private Sub txbInvoiceAMT_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbInvoiceAMT.DoubleClick
        Me.txbInvoiceAMT.SelectAll()
    End Sub

    Private Sub txbInvoiceAMT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbInvoiceAMT.Enter
        blSkipDeal = True
        Me.txbInvoiceAMT.Text = Me.txbInvoiceAMT.Text.Replace(",", "")
        blSkipDeal = False
    End Sub

    Private Sub txbInvoiceAMT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbInvoiceAMT.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then
            If Me.txbInvoiceCode.Text.Trim = "" Then
                Me.txbInvoiceCode.Select()
            ElseIf Me.txbInvoiceNo.Text.Trim = "" Then
                Me.txbInvoiceNo.Select()
            Else
                Me.btnPrintInvoice.PerformClick()
            End If
            e.SuppressKeyPress = True : Return
        End If
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        If e.KeyCode = Keys.OemPeriod OrElse e.KeyCode = Keys.Decimal Then
            If Me.txbInvoiceAMT.SelectedText.IndexOf(".") > -1 OrElse Me.txbInvoiceAMT.Text.IndexOf(".") = -1 Then Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbInvoiceAMT_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbInvoiceAMT.Leave
        If blSkipDeal Then Return
        blSkipDeal = True
        If Me.txbInvoiceAMT.Text = "" OrElse Not IsNumeric(Me.txbInvoiceAMT.Text) OrElse CDec(Me.txbInvoiceAMT.Text.Trim.Replace(",", "")) = 0 Then
            Me.txbInvoiceAMT.Text = "0.00"
        Else
            Me.txbInvoiceAMT.Text = Format(CDec(Me.txbInvoiceAMT.Text.Trim.Replace(",", "")), "#,0.00")
        End If
        blSkipDeal = False
    End Sub

    Private Sub txbInvoiceAMT_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbInvoiceAMT.TextChanged
        If blSkipDeal Then Return
        Me.tlpMultiPrint.Visible = False
        If Me.txbInvoiceAMT.Text = "" OrElse Not IsNumeric(Me.txbInvoiceAMT.Text) OrElse CDec(Me.txbInvoiceAMT.Text.Trim.Replace(",", "")) = 0 Then
            Me.lblError.Visible = False : Me.btnPrintInvoice.Enabled = False
        ElseIf CDec(Me.txbInvoiceAMT.Text.Trim.Replace(",", "")) > dmAvailableAMT + dmReprintableAMT Then
            Me.lblError.Visible = True
            Me.lblError.Text = "�����󣺳������ɴ�ӡ����"
            Me.btnPrintInvoice.Enabled = False
        ElseIf CDec(Me.txbInvoiceAMT.Text.Trim.Replace(",", "")) < frmInternetSalesInvoice.drInvoicePrintable("MinInvoiceAMT") Then
            Me.lblError.Visible = True
            Me.lblError.Text = "������˰���Ź涨�����ŷ�Ʊ����С���ܵ��� " & Format(frmInternetSalesInvoice.drInvoicePrintable("MinInvoiceAMT"), "#,0.00").Replace(".00", "") & " Ԫ����"
            Me.btnPrintInvoice.Enabled = False
        ElseIf CDec(Me.txbInvoiceAMT.Text.Trim.Replace(",", "")) > frmInternetSalesInvoice.drInvoicePrintable("MaxInvoiceAMT") Then
            Me.lblError.Visible = True
            Me.lblError.Text = "������˰���Ź涨�����ŷ�Ʊ�������ܳ��� " & Format(frmInternetSalesInvoice.drInvoicePrintable("MaxInvoiceAMT"), "#,0.00").Replace(".00", "") & " Ԫ����"
            Me.btnPrintInvoice.Enabled = False
        Else
            Me.lblError.Visible = False
            If dmAvailableAMT + dmReprintableAMT > CDec(Me.txbInvoiceAMT.Text.Trim.Replace(",", "")) Then
                Me.nudMultiPrint.Value = 2
                Try
                    iMultiPrint = Math.Ceiling((dmAvailableAMT + dmReprintableAMT) / CDec(Me.txbInvoiceAMT.Text.Trim.Replace(",", "")))
                    If iMultiPrint > 1000 Then iMultiPrint = 1000
                Catch
                    iMultiPrint = 1000
                End Try
                Me.nudMultiPrint.Maximum = iMultiPrint
                Me.nudMultiPrint.Value = iMultiPrint
                Me.tlpMultiPrint.Visible = True
            End If
            Me.btnPrintInvoice.Enabled = True
        End If
    End Sub

    Private Sub txbInvoiceCode_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbInvoiceCode.DoubleClick
        Me.txbInvoiceCode.SelectAll()
    End Sub

    Private Sub txbInvoiceCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbInvoiceCode.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then
            If Me.txbInvoiceCode.Text.Trim = "" Then
                Me.txbInvoiceCode.Select()
            ElseIf Me.txbInvoiceNo.Text.Trim = "" Then
                Me.txbInvoiceNo.Select()
            ElseIf Me.btnPrintInvoice.Enabled Then
                Me.btnPrintInvoice.PerformClick()
            Else
                Me.txbInvoiceAMT.Select() : Me.txbInvoiceAMT.SelectAll()
            End If
            e.SuppressKeyPress = True : Return
        End If
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbInvoiceCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbInvoiceCode.Leave
        Me.txbInvoiceCode.Text = Me.txbInvoiceCode.Text.Trim
        If Me.txbInvoiceCode.Text = "" Then Me.txbInvoiceCode.Text = frmInternetSalesInvoice.sInvoiceCode
    End Sub

    Private Sub txbInvoiceNo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbInvoiceNo.DoubleClick
        Me.txbInvoiceNo.SelectAll()
    End Sub

    Private Sub txbInvoiceNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbInvoiceNo.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then
            If Me.txbInvoiceNo.Text.Trim = "" Then
                Me.txbInvoiceNo.Select()
            ElseIf Me.txbInvoiceNo.Text.Trim = "" Then
                Me.txbInvoiceNo.Select()
            ElseIf Me.btnPrintInvoice.Enabled Then
                Me.btnPrintInvoice.PerformClick()
            Else
                Me.txbInvoiceAMT.Select() : Me.txbInvoiceAMT.SelectAll()
            End If
            e.SuppressKeyPress = True : Return
        End If
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbInvoiceNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbInvoiceNo.Leave
        Me.txbInvoiceNo.Text = Me.txbInvoiceNo.Text.Trim
        If Me.txbInvoiceNo.Text = "" Then Me.txbInvoiceNo.Text = frmInternetSalesInvoice.sInvoiceNo
    End Sub

    Private Sub chbMultiPrint_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbMultiPrint.CheckedChanged
        Me.nudMultiPrint.Enabled = Me.chbMultiPrint.Checked
    End Sub

    Private Sub chbPrintLine_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbPrintLine.CheckedChanged
        My.Settings.PrintInvoiceLine = Me.chbPrintLine.Checked
        My.Settings.Save()
    End Sub

    Private Sub btnGetNewInvoiceNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetNewInvoiceNo.Click
        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "���ڻ�ȡ��һ�����÷�Ʊ���롭��"
        frmMain.statusMain.Refresh()

        Dim DB As New DataBase
        DB.Open()
        If DB.IsConnected Then
            Try
                Dim drInvoiceCodeNo As DataRow = DB.GetDataTable("Select LastInvoiceCode,LastInvoiceNo From InvoiceCodeNo Where StoreID=" & frmInternetSalesInvoice.sStoreID & " And PrinterDevice='" & frmInternetSalesInvoice.sInvoicePrinterDevice.Replace("'", "''") & "'").Rows(0)
                frmInternetSalesInvoice.sInvoiceCode = drInvoiceCodeNo("LastInvoiceCode").ToString
                frmInternetSalesInvoice.sInvoiceNo = drInvoiceCodeNo("LastInvoiceNo").ToString
                If frmInternetSalesInvoice.sInvoiceNo <> "" Then
                    frmInternetSalesInvoice.sInvoiceNo = (CLng(frmInternetSalesInvoice.sInvoiceNo) + 1).ToString
                    If frmInternetSalesInvoice.sInvoiceNo.Length < drInvoiceCodeNo("LastInvoiceNo").ToString.Length Then frmInternetSalesInvoice.sInvoiceNo = StrDup(drInvoiceCodeNo("LastInvoiceNo").ToString.Length - frmInternetSalesInvoice.sInvoiceNo.Length, "0") & frmInternetSalesInvoice.sInvoiceNo
                    Me.txbInvoiceCode.Text = frmInternetSalesInvoice.sInvoiceCode
                    Me.txbInvoiceNo.Text = frmInternetSalesInvoice.sInvoiceNo
                End If

                bSeconds = 10
                Me.btnGetNewInvoiceNo.Text = "10����ȡ��һ�����ú���"
                Me.btnGetNewInvoiceNo.Enabled = False
                Me.newInvoiceNoTimer.Enabled = True
                frmMain.statusText.Text = "������"
            Catch ex As Exception
                frmInternetSalesInvoice.sInvoiceCode = "" : frmInternetSalesInvoice.sInvoiceNo = ""
                MessageBox.Show("��ȡ���÷�Ʊ����ʧ�ܣ������Ǵ�����ʾ��    " & Chr(13) & Chr(13) & ex.Message & Space(4), "��ȡ���÷�Ʊ����ʧ�ܣ�", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                frmMain.statusText.Text = "f��ȡ���÷�Ʊ����ʧ�ܣ�"
            End Try
        Else
            frmMain.statusText.Text = "ϵͳ�����Ӳ������ݿ���޷���ȡ��һ�����÷�Ʊ���롣�������ݿ����ӡ�"
        End If
        DB.Close()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub lblMultiPrint1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMultiPrint1.Click, lblMultiPrint2.Click
        Me.chbMultiPrint.Checked = Not Me.chbMultiPrint.Checked
    End Sub

    Private Sub nudMultiPrint_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudMultiPrint.ValueChanged
        iMultiPrint = Me.nudMultiPrint.Value
    End Sub

    Private Sub btnPrintInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintInvoice.Click
        Me.btnPrintInvoice.Select()
        If Me.cbbInvoiceItem1.SelectedIndex = -1 Then
            MessageBox.Show("��ѡ��ķ�ƱƷ����ڣ�    " & Chr(13) & Chr(13) & "������ѡ��ƱƷ�    ", "��ƱƷ����ڣ�", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.cbbInvoiceItem1.Select() : Me.cbbInvoiceItem1.SelectAll()
            Return
        End If
        If Me.cbbInvoiceItem2.SelectedIndex = -1 Then
            MessageBox.Show("��ѡ��ķ�ƱƷ����ڣ�    " & Chr(13) & Chr(13) & "������ѡ��ƱƷ�    ", "��ƱƷ����ڣ�", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.cbbInvoiceItem2.Select() : Me.cbbInvoiceItem2.SelectAll()
            Return
        End If

        If Not frmMain.blUseInvoiceDevice Then
            If Me.txbInvoiceCode.Text = "" Then
                MessageBox.Show("��Ʊ���벻��Ϊ�գ������뷢Ʊ���롣    ", "��Ʊ���벻��Ϊ�գ�", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txbInvoiceCode.Select()
                Return
            End If
            If Me.txbInvoiceNo.Text = "" Then
                MessageBox.Show("��Ʊ���벻��Ϊ�գ������뷢Ʊ���롣    ", "��Ʊ���벻��Ϊ�գ�", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txbInvoiceNo.Select()
                Return
            End If
            sInvoiceCode = Me.txbInvoiceCode.Text : sInvoiceNo = Me.txbInvoiceNo.Text
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim sTask As String = IIf(Me.btnPrintInvoice.Text.IndexOf("��") > -1, "��", "") & "��ӡ"
        frmMain.statusText.Text = "����" & sTask & "��Ʊ����"
        frmMain.statusMain.Refresh()

        Dim dmTotalPayment As Decimal = CDec(Me.txbTotalPaymentAMT.Text.Trim.Replace(",", "")), dmInvoiceAMT As Decimal = CDec(Me.txbInvoiceAMT.Text.Trim.Replace(",", "")), sTotalAMT As String = "", sRebateAMT As String = "", sRealAMT As String = "", sInvoiceItem As String = "", sPaymentTerm As String = "", sSummaryInfo As String = ""
        If Me.cbbInvoiceItem2.SelectedIndex = 0 Then
            sInvoiceItem = Me.cbbInvoiceItem1.Text
        Else
            sInvoiceItem = Me.cbbInvoiceItem1.Text & "��" & Me.cbbInvoiceItem2.Text
        End If

        sPaymentTerm = "���ϸ���"

        If Me.chbPrintDiscount.Checked Then
            sTotalAMT = Format(dmTotalChargedAMT * (dmInvoiceAMT / dmTotalPayment), "#,0.00")
            sRebateAMT = "-" & Format(dmTotalRebateAMT * (dmInvoiceAMT / dmTotalPayment), "#,0.00")
        Else
            sTotalAMT = Format(dmInvoiceAMT, "#,0.00")
        End If
        sRealAMT = Format(dmInvoiceAMT, "#,0.00")
        Dim bLen As Byte = sTotalAMT.Length
        If bLen < sRebateAMT.Length Then bLen = sRebateAMT.Length
        If bLen < sRealAMT.Length Then bLen = sRealAMT.Length
        sTotalAMT = StrDup(bLen - sTotalAMT.Length, " ") & sTotalAMT
        sRebateAMT = StrDup(bLen - sRebateAMT.Length, " ") & sRebateAMT
        sRealAMT = StrDup(bLen - sRealAMT.Length, " ") & sRealAMT

        sSummaryInfo = "�ܹ����" & Format(IIf(blIsDeduction, dmTotalChargedAMT, dmTotalPayment) * (dmInvoiceAMT / dmTotalPayment), "#,0.00")
        If Me.chbPrintDiscount.Checked Then sSummaryInfo = sSummaryInfo & "  �ۿ۽�" & Format(dmTotalRebateAMT * (dmInvoiceAMT / dmTotalPayment), "#,0.00")
        sSummaryInfo = sSummaryInfo & "  ʵ����" & Format(dmInvoiceAMT, "#,0.00")

        Dim sSQL As String = "Exec PrintInvoice_InternetSales @BillNo='" & frmInternetSalesInvoice.oair.OrderAllInfoData.BillNo.ToString & "',@TotalPaymentAMT=" & CDec(Me.txbTotalPaymentAMT.Text).ToString & ",@TotalPrintedInvoiceAMT=" & CDec(Me.txbTotalPrintedInvoiceAMT.Text).ToString & ",@RowID=" & (Me.dgvInvoice.RowCount + 1).ToString & ","
        If Not frmMain.blUseInvoiceDevice Then sSQL = sSQL & "@PrinterDevice='" & frmInternetSalesInvoice.sInvoicePrinterDevice.Replace("'", "''") & "',@InvoiceCode='" & sInvoiceCode & "',@InvoiceNo='" & sInvoiceNo & "',"
        sSQL = sSQL & "@InvoiceTitle='" & Me.txbInvoiceTitle.Text.Trim.Replace("'", "''") & "',@InvoiceItem1='" & Me.cbbInvoiceItem1.Text.Replace("'", "''") & "',"
        If Me.cbbInvoiceItem2.SelectedIndex > 0 Then sSQL = sSQL & "@InvoiceItem2='" & Me.cbbInvoiceItem2.Text.Replace("'", "''") & "',"
        sSQL = sSQL & "@InvoiceAMT=" & dmInvoiceAMT.ToString & ","
        If Me.nudQTY.Value <> 1 Then sSQL = sSQL & "@Quantity=" & Me.nudQTY.Value.ToString & ","
        If sPaymentTerm <> "���ϸ���" Then sSQL = sSQL & "@PaymentTerm='" & sPaymentTerm & "',"

        Dim dtNew As DataTable = frmInternetSalesInvoice.dtInvoice.Copy, drNew As DataRow, drInvoice As DataRow, dtCancelled As DataTable = Nothing, drCancelled As DataRow
        dtNew.Rows.Clear()
        drNew = dtNew.Rows.Add()
        drNew("RowID") = Me.dgvInvoice.RowCount + 1
        If Not frmMain.blUseInvoiceDevice Then
            drNew("InvoiceCode") = sInvoiceCode
            drNew("InvoiceNo") = sInvoiceNo
        End If
        drNew("InvoiceTitle") = Me.txbInvoiceTitle.Text
        drNew("InvoiceItem") = sInvoiceItem
        drNew("InvoiceAMT") = CDec(Me.txbInvoiceAMT.Text.Trim.Replace(",", ""))
        drNew("Quantity") = Me.nudQTY.Value
        drNew("PaymentTerm") = sPaymentTerm

        If dmReprintableAMT > 0 Then
            Dim dmBalanceAMT As Decimal = dmReprintableAMT
            dtCancelled = New DataTable
            dtCancelled.Columns.Add("BillNo", System.Type.GetType("System.String"))
            dtCancelled.Columns.Add("RowID", System.Type.GetType("System.Int16"))
            dtCancelled.Columns.Add("CancelledReason", System.Type.GetType("System.String"))
            dtCancelled.Columns.Add("ReprintableAMT", System.Type.GetType("System.Decimal"))

            For Each drInvoice In frmInternetSalesInvoice.dtInvoice.Select("ReprintableAMT>0", "RowID")
                If DateAdd(DateInterval.Second, frmInternetSalesInvoice.iDifferenceSeconds, drInvoice("ReprintableTime")) < Now() Then
                    dmReprintableAMT -= drInvoice("ReprintableAMT")
                    dmBalanceAMT -= drInvoice("ReprintableAMT")
                    If drInvoice("InvoiceState").ToString = "�ѱ�ȡ��" Then
                        drInvoice("Remarks") = "ʣ���" & Format(drInvoice("ReprintableAMT"), "#,0.00").Replace(".00", "") & "���ѳ������ش�ӡʱ�ޣ���"
                        drInvoice("ReprintableAMT") = 0
                        drInvoice.AcceptChanges()
                    Else
                        drInvoice.RejectChanges()
                        drInvoice("Remarks") = "���ش�ӡ��" & Format(drInvoice("InvoiceAMT"), "#,0.00").Replace(".00", "") & "���ѳ������ش�ӡʱ�ޣ���"
                    End If
                ElseIf dmBalanceAMT > 0 Then
                    If dmBalanceAMT > dmInvoiceAMT Then dmBalanceAMT = dmInvoiceAMT
                    drCancelled = dtCancelled.Rows.Add()
                    drCancelled("BillNo") = frmInternetSalesInvoice.oair.OrderAllInfoData.BillNo.ToString
                    drCancelled("RowID") = drInvoice("RowID")
                    drCancelled("CancelledReason") = drInvoice("CancelledReason").ToString
                    drCancelled("ReprintableAMT") = IIf(dmBalanceAMT > drInvoice("ReprintableAMT"), 0, drInvoice("ReprintableAMT") - dmBalanceAMT)
                    dmBalanceAMT = dmBalanceAMT - drInvoice("ReprintableAMT")
                    If drNew("ReprintableTimes").ToString = "" OrElse drNew("ReprintableTimes") > drInvoice("ReprintableTimes") - 1 Then drNew("ReprintableTimes") = drInvoice("ReprintableTimes") - 1
                    If drNew("ReprintableTime").ToString = "" OrElse drNew("ReprintableTime") > drInvoice("ReprintableTime") Then drNew("ReprintableTime") = drInvoice("ReprintableTime")
                End If
            Next

            If dmInvoiceAMT > dmReprintableAMT + dmAvailableAMT Then
                With Me.dgvInvoice.Columns("Remarks")
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
                Me.ResetInterface()
                Me.lblError.Visible = True : Me.tlpMultiPrint.Visible = False
                Me.lblError.Text = "�����󣺳������ɴ�ӡ����"
                Me.btnPrintInvoice.Enabled = False
                frmMain.statusText.Text = "��Ʊ�������ɴ�ӡ��"
                dtNew.Dispose() : dtNew = Nothing
                If dtCancelled IsNot Nothing Then dtCancelled.Dispose() : dtCancelled = Nothing
                drInvoice = Nothing : drNew = Nothing : drCancelled = Nothing
                Me.Cursor = Cursors.Default
                Me.theTimer.Enabled = True
                Return
            End If
        End If

        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            Me.ResetInterface()
            frmMain.statusText.Text = "ϵͳ�����Ӳ������ݿ���޷�" & sTask & "��Ʊ���������ݿ����ӡ�"
            dtNew.Dispose() : dtNew = Nothing
            If dtCancelled IsNot Nothing Then dtCancelled.Dispose() : dtCancelled = Nothing
            drInvoice = Nothing : drNew = Nothing : drCancelled = Nothing
            Me.Cursor = Cursors.Default : Return
        End If

        If dtCancelled IsNot Nothing AndAlso dtCancelled.Rows.Count > 0 Then
            If DB.ModifyTable("Select BILLNO,RowID,CancelledReason,ReprintableAMT Into #CancelledInvoice From InternetSalesInvoice Where 1=2") = -1 OrElse DB.BulkCopyTable("#CancelledInvoice", dtCancelled) = -1 Then
                Me.ResetInterface()
                frmMain.statusText.Text = sTask & "��Ʊʧ�ܣ�"
                dtNew.Dispose() : dtNew = Nothing
                dtCancelled.Dispose() : dtCancelled = Nothing
                drInvoice = Nothing : drNew = Nothing : drCancelled = Nothing
                DB.Close() : Me.Cursor = Cursors.Default : Return
            End If
        End If

        If dmReprintableAMT > 0 Then
            dtCancelled.AcceptChanges()
            Dim sSourceInvoice As String = "��"
            For Each drCancelled In dtCancelled.Select("", "RowID")
                sSourceInvoice = sSourceInvoice & drCancelled("RowID").ToString & "��"
            Next
            sSourceInvoice = sSourceInvoice.Substring(0, sSourceInvoice.Length - 1) & "��"
            drNew("SourceInvoice") = sSourceInvoice
            sSQL = sSQL & "@SourceInvoice='" & sSourceInvoice & "',@ReprintableTimes=" & drNew("ReprintableTimes").ToString & ",@ReprintableTime='" & Format(drNew("ReprintableTime"), "yyyy\/MM\/dd HH:mm:ss") & "',"
            sSQL = sSQL & "@NewPrintedInvoiceAMT=" & IIf(dmReprintableAMT >= dmInvoiceAMT, 0, dmInvoiceAMT - dmReprintableAMT).ToString & ",@CancelledInvoices=" & dtCancelled.Rows.Count.ToString & ","
        End If
        sSQL = sSQL & "@OperatorName='" & frmMain.sLoginUserRealName.Replace("'", "''") & "',@SSID=" & frmMain.sSSID & ",@StoreID=" & frmInternetSalesInvoice.sStoreID

        Dim dtResult As DataTable = DB.GetDataTable(sSQL), sResult As String = "", blNeedResetInfo As Boolean = False, blSentDataFailure As Boolean = False
        If dtResult Is Nothing Then
            frmMain.statusText.Text = "" & sTask & "��Ʊʧ�ܣ�"
        ElseIf dtResult.Rows(0)("Result").ToString <> "OK" Then
            Select Case dtResult.Rows(0)("Result").ToString
                Case "SalesBillDeleted"
                    MessageBox.Show("��ǰ���۵��ѱ�ȡ��������" & sTask & "��Ʊ��    ", "����" & sTask & "��Ʊ��", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    frmMain.statusText.Text = "��ǰ���۵��ѱ�ȡ����"
                    dtNew.Dispose() : dtNew = Nothing
                    If dtCancelled IsNot Nothing Then dtCancelled.Dispose() : dtCancelled = Nothing
                    drInvoice = Nothing : drNew = Nothing : drCancelled = Nothing
                    DB.Close() : Me.Cursor = Cursors.Default
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel : Return
                Case "SalesBillCancelled"
                    MessageBox.Show("��ǰ���۵��ѱ�����ȡ��������" & sTask & "��Ʊ��    ", "����" & sTask & "��Ʊ��", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    frmMain.statusText.Text = "��ǰ���۵��ѱ�����ȡ����"
                    dtNew.Dispose() : dtNew = Nothing
                    If dtCancelled IsNot Nothing Then dtCancelled.Dispose() : dtCancelled = Nothing
                    drInvoice = Nothing : drNew = Nothing : drCancelled = Nothing
                    DB.Close() : Me.Cursor = Cursors.Default
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel : Return
                Case "AMTChanged"
                    Dim dmNewAvailableAMT As Decimal = dtResult.Rows(0)("TotalPaymentAMT") - dtResult.Rows(0)("TotalPrintedInvoiceAMT"), dmNewReprintableAMT As Decimal = 0
                    Try
                        dmNewReprintableAMT = dtResult.Compute("Sum(ReprintableAMT)", "")
                    Catch
                        dmNewReprintableAMT = 0
                    End Try

                    If dmAvailableAMT <> dmNewAvailableAMT Then
                        MessageBox.Show("��ǰ�ɴ�ӡ�ķ�Ʊ����Ѿ������ı䣡    " & Chr(13) & Chr(13) & "�����¼������뵱�μ�����ӡ�ķ�Ʊ��    ", "�ɴ�ӡ��Ʊ����Ѹı䣡", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        frmMain.statusText.Text = "�ɴ�ӡ��Ʊ����Ѹı䣡"
                    ElseIf dmNewReprintableAMT = 0 Then
                        MessageBox.Show("��ǰ���۵��ķ�Ʊ�б��Ѿ������ı䣡    ", "��Ʊ�б��Ѿ������ı䣡", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        frmMain.statusText.Text = "��Ʊ�б��Ѿ������ı䣡"
                    Else
                        MessageBox.Show("��ǰ���۵��ķ�Ʊ�б��Ѿ������ı䣡    " & Chr(13) & Chr(13) & "�����¼������뵱�μ����ش�ӡ�ķ�Ʊ��    ", "�ɴ�ӡ��Ʊ����Ѹı䣡", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        frmMain.statusText.Text = "��Ʊ�б��Ѿ������ı䣡"
                    End If

                    dmAvailableAMT = dmNewAvailableAMT : dmReprintableAMT = dmNewReprintableAMT
                    Me.txbTotalPaymentAMT.Text = Format(dtResult.Rows(0)("TotalPaymentAMT"), "#,0.00")
                    Me.txbTotalPrintedInvoiceAMT.Text = Format(dtResult.Rows(0)("TotalPrintedInvoiceAMT"), "#,0.00")
                    Me.txbAvailableInvoiceAMT.Text = Format(dmAvailableAMT, "#,0.00")
                    With frmInternetSalesInvoice.dtInvoice
                        .Rows.Clear()
                        For Each dr As DataRow In dtResult.Rows
                            drInvoice = .Rows.Add
                            For bColumn As Byte = 0 To .Columns.Count - 1
                                drInvoice(bColumn) = dr(bColumn + 3)
                            Next
                        Next
                        .AcceptChanges()
                    End With

                    Me.tlpMultiPrint.Visible = False
                    If dmAvailableAMT + dmReprintableAMT = 0 OrElse frmMain.dtAllowedRight.Select("RightName='E-CardInvoice'").Length = 0 Then
                        Me.pnlNewInvoice.Visible = False
                        Me.btnPrintInvoice.Visible = False
                        Me.chbPrintLine.Visible = False
                    Else
                        Me.pnlNewInvoice.Visible = True
                        Me.btnPrintInvoice.Visible = True
                        Me.chbPrintLine.Visible = ("|21|272|".IndexOf(frmInternetSalesInvoice.sCityID) > 0) '�Ϻ������Գ���
                    End If

                    blNeedResetInfo = True
                Case "InvoiceNoUsed"
                    bSeconds = 10
                    frmInternetSalesInvoice.blInvoicePrinterMultiUser = True
                    Me.btnGetNewInvoiceNo.Text = "10����ȡ��һ�����ú���"
                    Me.btnGetNewInvoiceNo.Enabled = False
                    Me.newInvoiceNoTimer.Enabled = True

                    frmInternetSalesInvoice.sInvoiceCode = dtResult.Rows(0)("LastInvoiceCode").ToString
                    frmInternetSalesInvoice.sInvoiceNo = dtResult.Rows(0)("LastInvoiceNo").ToString
                    frmInternetSalesInvoice.sInvoiceNo = (CLng(frmInternetSalesInvoice.sInvoiceNo) + 1).ToString
                    If frmInternetSalesInvoice.sInvoiceNo.Length < dtResult.Rows(0)("LastInvoiceNo").ToString.Length Then frmInternetSalesInvoice.sInvoiceNo = StrDup(dtResult.Rows(0)("LastInvoiceNo").ToString.Length - frmInternetSalesInvoice.sInvoiceNo.Length, "0") & frmInternetSalesInvoice.sInvoiceNo
                    MessageBox.Show("��Ʊ����""" & sInvoiceCode & """�еķ�Ʊ����""" & sInvoiceNo & """�ѱ�ʹ�ã�    " & Chr(13) & Chr(13) & _
                                    "������ϵͳ�Զ���ȡ����һ�����õķ�Ʊ���뼰��Ʊ���룺    " & Chr(13) & Chr(13) & _
                                    "��Ʊ���룺" & frmInternetSalesInvoice.sInvoiceCode & Space(4) & Chr(13) & _
                                    "��Ʊ���룺" & frmInternetSalesInvoice.sInvoiceNo & Space(4) & Chr(13) & Chr(13) & _
                                    "��˶�����ķ�Ʊ���뼰��Ʊ�����Ƿ���ȷ������������ֹ����롣    " & Chr(13) & Chr(13) & _
                                    "�˶Թ���Ʊ���뼰��Ʊ�����,���ٰ�""��ӡ""��ť������ӡ��Ʊ��    ", "����ķ�Ʊ�����ѱ�ʹ�ã�", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txbInvoiceCode.Text = frmInternetSalesInvoice.sInvoiceCode
                    Me.txbInvoiceNo.Text = frmInternetSalesInvoice.sInvoiceNo
                    Me.txbInvoiceNo.Select() : Me.txbInvoiceNo.SelectAll()
                Case Else
                    MessageBox.Show("" & sTask & "��Ʊʱ���ִ������������ݿ���ڲ�������ʾ��    " & Chr(13) & Chr(13) & dtResult.Rows(0)("ErrorInfo").ToString & Space(4) & Chr(13) & Chr(13) & "�����" & sTask & "��Ʊ���ڹرմ��ں����ԡ�����������⣬����ϵ���������Ա��    ", "" & sTask & "��Ʊʧ�ܣ�", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    frmMain.statusText.Text = "" & sTask & "��Ʊʧ�ܣ�"
            End Select
        Else
            Dim sRestoreSQL As String = "Exec PrintInvoiceRestore_InternetSales @StoreID=" & frmInternetSalesInvoice.sStoreID & ",@BillNo='" & frmInternetSalesInvoice.oair.OrderAllInfoData.BillNo.ToString & "',@RowID=" & drNew("RowID").ToString & ","
            If Not frmMain.blUseInvoiceDevice Then sRestoreSQL = sRestoreSQL & "@PrinterDevice='" & frmInternetSalesInvoice.sInvoicePrinterDevice.Replace("'", "''") & "',"
            sRestoreSQL = sRestoreSQL & "@NewPrintedInvoiceAMT=" & IIf(dmReprintableAMT >= dmInvoiceAMT, 0, dmInvoiceAMT - dmReprintableAMT).ToString & ","
            If dtCancelled IsNot Nothing Then sRestoreSQL = sRestoreSQL & "@CancelledInvoices=" & dtCancelled.Rows.Count.ToString & ","
            sRestoreSQL = sRestoreSQL.Substring(0, sRestoreSQL.Length - 1)

            dtPrintItem = New DataTable
            dtPrintItem.Columns.Add("ItemID", System.Type.GetType("System.Byte"))
            dtPrintItem.Columns.Add("PrintText", System.Type.GetType("System.String"))
            dtPrintItem.PrimaryKey = New DataColumn() {dtPrintItem.Columns("ItemID")}

            If frmMain.blUseInvoiceDevice Then '�����Ҫ��Ʊ�� AndAlso Not My.Settings.IsInTraining
                Dim objInvoice As Object = CreateObject("PZHPrj.ComDLL"), sInvoiceInfo As String = ""
                If dtCancelled IsNot Nothing AndAlso dtCancelled.Rows.Count > 0 Then
                    frmMain.statusText.Text = "������Ʊ���ύ��Ʊ��Ʊ���ݡ���"
                    frmMain.statusMain.Refresh()
                    Try
                        For Each drInvoice In frmInternetSalesInvoice.dtInvoice.Select("ReprintableAMT>0", "RowID")
                            If drInvoice("InvoiceCode").ToString <> "" AndAlso drInvoice("InvoiceNo").ToString <> "" Then
                                Me.GetAvailableInvoiceInfo()
                                If sInvoiceCode = "" Then
                                    frmMain.statusText.Text = "�ش�ӡ��Ʊʧ�ܣ�"
                                    Try
                                        DB.ModifyTable(sRestoreSQL)
                                    Catch
                                    End Try
                                    objInvoice = Nothing
                                    dtNew.Dispose() : dtNew = Nothing
                                    dtCancelled.Dispose() : dtCancelled = Nothing
                                    drInvoice = Nothing : drNew = Nothing : drCancelled = Nothing
                                    dtPrintItem.Dispose() : dtPrintItem = Nothing
                                    DB.Close() : Me.Cursor = Cursors.Default : Return
                                End If

                                '��Ʊ���TrecordIn��
                                sInvoiceInfo = drInvoice("InvoiceCode").ToString & "," 'ԭ��Ʊ����
                                sInvoiceInfo = sInvoiceInfo & drInvoice("InvoiceNo").ToString & "," 'ԭ��Ʊ����
                                sInvoiceInfo = sInvoiceInfo & "," '��Ʊ����˰ʶ���CustomerID���հ�
                                sInvoiceInfo = sInvoiceInfo & drInvoice("InvoiceTitle").ToString & "," '��Ʊ������Customer
                                sInvoiceInfo = sInvoiceInfo & frmMain.sLoginUserRealName.Replace(",", " ") & "," '����ԱUserName
                                sInvoiceInfo = sInvoiceInfo & Format(drInvoice("InvoiceAMT"), "0.00") & "," '�ܽ��InvMoney
                                sInvoiceInfo = sInvoiceInfo & "0," '���￨���CardMoney
                                sInvoiceInfo = sInvoiceInfo & "0," '��������JFMoney
                                sInvoiceInfo = sInvoiceInfo & "0," '�����ɵ�OtherMoney
                                sInvoiceInfo = sInvoiceInfo & "1," '��Ӫ��Ŀ����ItemNum
                                '��Ʊ��ϸ�TInvoiceDTL��
                                sInvoiceInfo = sInvoiceInfo & "1," '��Ʒ���ItemNO
                                sInvoiceInfo = sInvoiceInfo & drInvoice("InvoiceItem").ToString.Replace(",", " ") & "," '��Ʒ����ItemName
                                sInvoiceInfo = sInvoiceInfo & "0," '����С��λ��DigitNum
                                sInvoiceInfo = sInvoiceInfo & Format(drInvoice("Quantity"), "0") & "," '����Number
                                sInvoiceInfo = sInvoiceInfo & "01," '˰Ŀ������TaxItemIndex
                                sInvoiceInfo = sInvoiceInfo & Format(drInvoice("InvoiceAMT") / drInvoice("Quantity"), "0.00") & "," '��Ʒ����Price
                                sInvoiceInfo = sInvoiceInfo & Format(drInvoice("InvoiceAMT"), "0.00") & "," '��Ʒ���Money
                                sInvoiceInfo = sInvoiceInfo '��Ʒ��λUnits

                                sResult = objInvoice.UntreadaInv(sInvoiceInfo)
                                If sResult.IndexOf("0") = 0 Then
                                    Me.GetPrintedInvoiceInfo(sResult)
                                    sResult = objInvoice.SendData()
                                    If sResult <> "0" Then blSentDataFailure = True
                                    With dtPrintItem.Rows
                                        .Clear()
                                        .Add(1, drInvoice("InvoiceCode").ToString & " " & drInvoice("InvoiceNo").ToString & IIf(My.Settings.IsInTraining, " ����ѵʹ�ã�����Ч��Ʊ����", "")) '��Ʊ̧ͷ
                                        .Add(2, drInvoice("InvoiceItem").ToString) '��ƱƷ��
                                        .Add(3, Format(drInvoice("Quantity"), "#,0")) '��������
                                        .Add(4, "-" & Format(drInvoice("InvoiceAMT") / drInvoice("Quantity"), "#,0.00")) '��������
                                        .Add(5, "-" & Format(drInvoice("InvoiceAMT"), "#,0.00")) '��Ʊ���
                                        .Add(6, "���ˣ�" & CapitalDigits.CapitalRMB(drInvoice("InvoiceAMT"))) '��д���
                                        .Add(7, sPaymentTerm) '���ʽ
                                        .Add(8, frmMain.sLoginUserRealName) '������
                                        .Add(9, sPrintedTime.Substring(0, 10)) '��Ʊ����
                                        .Add(10, "�����ţ�" & frmInternetSalesInvoice.oair.OrderAllInfoData.BillNo.Replace(" ", "") & IIf(drInvoice("RowID") = 1 AndAlso drInvoice("InvoiceAMT") = dmTotalPayment, "", "-" & drInvoice("RowID").ToString)) '���ָ�СƱ�ţ������⣩
                                        .Add(11, "") '����ͳ����Ϣ�������⣩
                                        .Add(12, "") '�ۿ۽��
                                        .Add(13, "-" & Format(drInvoice("InvoiceAMT"), "#,0.00")) 'ʵ�����
                                    End With
                                    dtPrintItem.AcceptChanges()
                                    sResult = Me.FinalPrinting(drInvoice("RowID").ToString)
                                    If sResult <> "OK" Then
                                        MessageBox.Show("��ӡ��Ʊ��Ʊʱ�������´���    " & Chr(13) & Chr(13) & sResult & "    " & Chr(13) & Chr(13) & "���ڼ�鷢Ʊ��ӡ�������ԡ�    ", "��ӡ��Ʊ��Ʊ����", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                        sResult = ""
                                    End If
                                ElseIf sResult <> "45" Then '��ȡ��
                                    MessageBox.Show("��Ʊ���ύ��Ʊ��Ʊ����ʱ����������룺" & sResult & "����    " & Chr(13) & Chr(13) & "���ڼ�鿪Ʊ�������ԡ�    ", "��Ʊ���ύ��Ʊ��Ʊ���ݳ���", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    sResult = ""
                                End If

                                If sResult = "" Then Exit For
                            Else
                                sResult = "OK"
                            End If
                        Next
                    Catch ex As Exception
                        MessageBox.Show("��Ʊ���ύ��Ʊ��Ʊ����ʱ���ִ��������Ǿ���Ĵ�����ʾ��    " & Chr(13) & Chr(13) & ex.Message & Space(4), "��Ʊ���ύ��Ʊ��Ʊ���ݳ���", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        sResult = ""
                    End Try

                    If sResult = "" Then
                        frmMain.statusText.Text = "�ش�ӡ��Ʊʧ�ܣ�"
                        Try
                            DB.ModifyTable(sRestoreSQL)
                        Catch
                        End Try
                        objInvoice = Nothing
                        dtNew.Dispose() : dtNew = Nothing
                        dtCancelled.Dispose() : dtCancelled = Nothing
                        drInvoice = Nothing : drNew = Nothing : drCancelled = Nothing
                        dtPrintItem.Dispose() : dtPrintItem = Nothing
                        DB.Close() : Me.Cursor = Cursors.Default : Return
                    End If
                End If

                frmMain.statusText.Text = "������Ʊ���ύ�·�Ʊ���ݡ���"
                frmMain.statusMain.Refresh()

                Try
                    Me.GetAvailableInvoiceInfo()
                    If sInvoiceCode = "" Then
                        frmMain.statusText.Text = sTask & "��Ʊʧ�ܣ�"
                        Try
                            DB.ModifyTable(sRestoreSQL)
                        Catch
                        End Try
                        objInvoice = Nothing
                        dtNew.Dispose() : dtNew = Nothing
                        If dtCancelled IsNot Nothing Then dtCancelled.Dispose() : dtCancelled = Nothing
                        drInvoice = Nothing : drNew = Nothing : drCancelled = Nothing
                        DB.Close() : Me.Cursor = Cursors.Default : Return
                    End If

                    '��Ʊ���TrecordIn��
                    sInvoiceInfo = "," '��Ʊ����˰ʶ���CustomerID���հ�
                    sInvoiceInfo = sInvoiceInfo & Me.txbInvoiceTitle.Text & "," '��Ʊ������Customer
                    sInvoiceInfo = sInvoiceInfo & frmMain.sLoginUserRealName.Replace(",", " ") & "," '����ԱUserName
                    sInvoiceInfo = sInvoiceInfo & Format(CDec(sRealAMT.Trim), "0.00") & "," '�ܽ��InvMoney
                    sInvoiceInfo = sInvoiceInfo & "0," '���￨���CardMoney
                    sInvoiceInfo = sInvoiceInfo & "0," '��������JFMoney
                    sInvoiceInfo = sInvoiceInfo & "0," '�����ɵ�OtherMoney
                    sInvoiceInfo = sInvoiceInfo & "1," '��Ӫ��Ŀ����ItemNum
                    '��Ʊ��ϸ�TInvoiceDTL��
                    sInvoiceInfo = sInvoiceInfo & "1," '��Ʒ���ItemNO
                    sInvoiceInfo = sInvoiceInfo & sInvoiceItem & "," '��Ʒ����ItemName
                    sInvoiceInfo = sInvoiceInfo & "0," '����С��λ��DigitNum
                    sInvoiceInfo = sInvoiceInfo & Format(Me.nudQTY.Value, "0") & "," '����Number
                    sInvoiceInfo = sInvoiceInfo & "01," '˰Ŀ������TaxItemIndex
                    sInvoiceInfo = sInvoiceInfo & Format(CDec(sRealAMT.Trim) / Me.nudQTY.Value, "0.00") & "," '��Ʒ����Price
                    sInvoiceInfo = sInvoiceInfo & Format(CDec(sRealAMT.Trim), "0.00") & "," '��Ʒ���Money
                    sInvoiceInfo = sInvoiceInfo '��Ʒ��λUnits

                    sResult = objInvoice.WriteRecord(sInvoiceInfo)
                    If sResult.IndexOf("0") = 0 Then
                        Me.GetPrintedInvoiceInfo(sResult)
                        sResult = objInvoice.SendData()
                        If sResult <> "0" Then blSentDataFailure = True
                    Else
                        MessageBox.Show("��Ʊ���ύ�·�Ʊ����ʱ����������룺" & sResult & "����    " & Chr(13) & Chr(13) & "���ڼ�鿪Ʊ�������ԡ�    ", "��Ʊ���ύ�·�Ʊ���ݳ���", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        sResult = ""
                    End If
                Catch ex As Exception
                    MessageBox.Show("��Ʊ���ύ�·�Ʊ����ʱ���ִ��������Ǿ���Ĵ�����ʾ��    " & Chr(13) & Chr(13) & ex.Message & Space(4), "��Ʊ���ύ�·�Ʊ���ݳ���", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    sResult = ""
                End Try

                objInvoice = Nothing

                If sResult = "" Then
                    frmMain.statusText.Text = sTask & "��Ʊʧ�ܣ�"
                    Try
                        DB.ModifyTable(sRestoreSQL)
                    Catch
                    End Try
                    dtNew.Dispose() : dtNew = Nothing
                    If dtCancelled IsNot Nothing Then dtCancelled.Dispose() : dtCancelled = Nothing
                    drInvoice = Nothing : drNew = Nothing : drCancelled = Nothing
                    dtPrintItem.Dispose() : dtPrintItem = Nothing
                    DB.Close() : Me.Cursor = Cursors.Default : Return
                Else
                    Try
                        DB.ModifyTable("Update InternetSalesInvoice Set InvoiceCode='" & sInvoiceCode & "',InvoiceNo='" & sInvoiceNo & "' Where BILLNO=" & frmInternetSalesInvoice.oair.OrderAllInfoData.BillNo & " And RowID=" & drNew("RowID").ToString)
                    Catch
                    End Try
                    drNew("InvoiceCode") = sInvoiceCode : drNew("InvoiceNo") = sInvoiceNo
                End If
            End If

            dtPrintItem.Clear()
            With dtPrintItem.Rows
                .Clear()
                .Add(1, Me.txbInvoiceTitle.Text & IIf(My.Settings.IsInTraining, " ����ѵʹ�ã�����Ч��Ʊ����", "")) '��Ʊ̧ͷ
                .Add(2, sInvoiceItem) '��ƱƷ��
                .Add(3, Format(Me.nudQTY.Value, "#,0")) '��������
                .Add(4, Format(CDec(sTotalAMT.Trim) / Me.nudQTY.Value, "#,0.00")) '��������
                .Add(5, sTotalAMT) '��Ʊ���
                .Add(6, CapitalDigits.CapitalRMB(dmInvoiceAMT)) '��д���
                .Add(7, sPaymentTerm) '���ʽ
                .Add(8, frmMain.sLoginUserRealName) '������
                .Add(9, Format(dtResult.Rows(0)("PrintedTime"), "yyyy-MM-dd")) '��Ʊ����
                .Add(10, "�����ţ�" & frmInternetSalesInvoice.oair.OrderAllInfoData.BillNo.Replace(" ", "") & IIf(Me.dgvInvoice.RowCount = 0 AndAlso dmInvoiceAMT = dmTotalPayment, "", "-" & drNew("RowID").ToString)) '���ָ�СƱ�ţ������⣩
                .Add(11, sSummaryInfo) '����ͳ����Ϣ�������⣩
                .Add(12, sRebateAMT) '�ۿ۽��
                .Add(13, sRealAMT) 'ʵ�����
            End With
            dtPrintItem.AcceptChanges()
            sResult = Me.FinalPrinting(drNew("RowID").ToString)

            If sResult = "OK" Then
                If Not frmMain.blUseInvoiceDevice Then
                    frmInternetSalesInvoice.sInvoiceCode = sInvoiceCode
                    frmInternetSalesInvoice.sInvoiceNo = sInvoiceNo
                    frmInternetSalesInvoice.sInvoiceNo = (CLng(frmInternetSalesInvoice.sInvoiceNo) + 1).ToString
                    If frmInternetSalesInvoice.sInvoiceNo.Length < sInvoiceNo.Length Then frmInternetSalesInvoice.sInvoiceNo = StrDup(sInvoiceNo.Length - frmInternetSalesInvoice.sInvoiceNo.Length, "0") & frmInternetSalesInvoice.sInvoiceNo
                    Me.txbInvoiceNo.Text = frmInternetSalesInvoice.sInvoiceNo
                    bSeconds = 10
                    If frmInternetSalesInvoice.blInvoicePrinterMultiUser Then
                        Me.btnGetNewInvoiceNo.Text = "10����ȡ��һ�����ú���"
                        Me.btnGetNewInvoiceNo.Enabled = False
                    End If
                    Me.newInvoiceNoTimer.Enabled = True
                End If

                frmMain.statusText.Text = "�Ѿ�����Ʊ" & sTask & "��""" & My.Settings.InvoicePrinter & """��"
                blNeedResetInfo = True
            Else
                MessageBox.Show("" & sTask & "��Ʊʱ�������´���    " & Chr(13) & Chr(13) & sResult & "    " & Chr(13) & Chr(13) & "���ڹرշ�Ʊ���ں����ԡ�    ", sTask & "��Ʊ����", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Try
                    DB.ModifyTable(sRestoreSQL)
                Catch
                End Try
                dtNew.Dispose() : dtNew = Nothing
                If dtCancelled IsNot Nothing Then dtCancelled.Dispose() : dtCancelled = Nothing
                drInvoice = Nothing : drNew = Nothing : drCancelled = Nothing
                dtPrintItem.Dispose() : dtPrintItem = Nothing
                DB.Close() : dmReprintableAMT = 0 : Me.Cursor = Cursors.Default
                frmMain.statusText.Text = "" & sTask & "��Ʊ����"
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Return
            End If

            dtPrintItem.Dispose() : dtPrintItem = Nothing

            If dmInvoiceAMT <= dmReprintableAMT Then
                dmReprintableAMT = dmReprintableAMT - dmInvoiceAMT
            Else
                Me.txbTotalPrintedInvoiceAMT.Text = Format(CDec(Me.txbTotalPrintedInvoiceAMT.Text.Replace(",", "")) + dmInvoiceAMT - dmReprintableAMT, "#,0.00")
                dmAvailableAMT = dmAvailableAMT + dmReprintableAMT - dmInvoiceAMT
                Me.txbAvailableInvoiceAMT.Text = Format(dmAvailableAMT, "#,0.00")
                dmReprintableAMT = 0
            End If

            drNew("InvoiceState") = "����" : drNew("ReprintableAMT") = 0 : drNew("PrinterName") = frmMain.sLoginUserRealName : drNew("PrintedTime") = dtResult.Rows(0)("PrintedTime") : drNew("Reprint") = "ȡ�����ش�ӡ"
            If drNew("SourceInvoice").ToString = "" Then
                drNew("ReprintableTimes") = 2 : drNew("ReprintableTime") = Format(DateAdd(DateInterval.Hour, 1, drNew("PrintedTime")), "yyyy\/MM\/dd HH:mm:ss")
            End If
            drNew.AcceptChanges()
            frmInternetSalesInvoice.dtInvoice.Merge(dtNew.Copy)
            Me.dgvInvoice.FirstDisplayedScrollingRowIndex = Me.dgvInvoice.RowCount - 1
            dtNew.Dispose() : dtNew = Nothing : drNew = Nothing

            If dtCancelled IsNot Nothing AndAlso dtCancelled.Rows.Count > 0 Then
                For Each drCancelled In dtCancelled.Rows
                    drInvoice = frmInternetSalesInvoice.dtInvoice.Select("RowID=" & drCancelled("RowID").ToString)(0)
                    drInvoice("InvoiceState") = "�ѱ�ȡ��"
                    drInvoice("ReprintableAMT") = drCancelled("ReprintableAMT")
                    If drInvoice("ReprintableAMT") = 0 Then
                        drInvoice("Remarks") = DBNull.Value
                    ElseIf DateAdd(DateInterval.Second, frmInternetSalesInvoice.iDifferenceSeconds, drInvoice("ReprintableTime")) < Now() Then
                        drInvoice("Remarks") = "ʣ���" & Format(drInvoice("ReprintableAMT"), "#,0.00").Replace(".00", "") & "���ѳ������ش�ӡʱ�ޣ���"
                        dmReprintableAMT = dmReprintableAMT - drInvoice("ReprintableAMT")
                    Else
                        drInvoice("Remarks") = "ʣ���" & Format(drInvoice("ReprintableAMT"), "#,0.00").Replace(".00", "") & "�����ش�ӡʱ�ޣ�" & Format(drInvoice("ReprintableTime"), "HH:mm:ss") & "��"
                    End If
                    drInvoice.AcceptChanges()
                Next
                dtCancelled.Dispose() : dtCancelled = Nothing : drCancelled = Nothing
            End If
            With Me.dgvInvoice.Columns("Remarks")
                If frmInternetSalesInvoice.dtInvoice.Select("Isnull(Remarks,'')<>''").Length = 0 Then
                    .Visible = False
                Else
                    .Visible = True
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End If
            End With
            With Me.dgvInvoice.Columns("SourceInvoice")
                If frmInternetSalesInvoice.dtInvoice.Select("Isnull(SourceInvoice,'')<>''").Length = 0 Then
                    .Visible = False
                Else
                    .Visible = True
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End If
            End With

            If dmAvailableAMT + dmReprintableAMT = 0 OrElse frmMain.dtAllowedRight.Select("RightName='E-CardInvoice'").Length = 0 Then
                Me.txbInvoiceAMT.Text = "0.00"
                Me.pnlNewInvoice.Visible = False
                Me.btnPrintInvoice.Enabled = False
                Me.btnPrintInvoice.Visible = False
                Me.chbPrintLine.Visible = False
            Else
                Me.pnlNewInvoice.Visible = True
                Me.btnPrintInvoice.Visible = True
                Me.chbPrintLine.Visible = ("|21|272|".IndexOf(frmInternetSalesInvoice.sCityID) > 0) '�Ϻ������Գ���
            End If
        End If

        Me.btnPrintInvoice.Text = IIf(dmReprintableAMT = 0, "��ӡ��Ʊ(&I)", "�ش�ӡ��Ʊ(&I)")
        Me.ResetInterface()

        If blNeedResetInfo Then
            If Me.dgvInvoice.RowCount = 1 AndAlso dmAvailableAMT = 0 Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
            ElseIf dmAvailableAMT + dmReprintableAMT > 0 Then
                If Me.grbPrintedInvoice.Visible Then Me.dgvInvoice.Select()
                If Me.chbMultiPrint.Visible = False OrElse Me.chbMultiPrint.Checked = False Then Me.txbInvoiceAMT.Text = Format(IIf(dmAvailableAMT + dmReprintableAMT <= frmInternetSalesInvoice.drInvoicePrintable("MaxInvoiceAMT"), dmAvailableAMT + dmReprintableAMT, frmInternetSalesInvoice.drInvoicePrintable("MaxInvoiceAMT")), "0.00")
                Me.txbInvoiceAMT.Select()
                Me.txbInvoiceAMT.SelectAll()
            ElseIf Me.grbPrintedInvoice.Visible Then
                Me.dgvInvoice.Select()
            End If
            If dmReprintableAMT > 0 Then Me.theTimer.Enabled = True

            If Me.chbMultiPrint.Visible AndAlso Me.chbMultiPrint.Checked AndAlso iMultiPrint >= 2 Then
                Me.dgvInvoice.Refresh() : Me.Refresh() : Me.dgvInvoice.Refresh() : frmMain.statusMain.Refresh() : frmMain.Refresh() : Me.dgvInvoice.Refresh()
                blSkipDeal = True
                iMultiPrint -= 1
                dmInvoiceAMT = CDec(Me.txbInvoiceAMT.Text.Trim)
                If CDec(Me.txbInvoiceAMT.Text.Trim) > dmAvailableAMT + dmReprintableAMT Then Me.txbInvoiceAMT.Text = Format(dmAvailableAMT + dmReprintableAMT, "#,0.00")
                If CDec(Me.txbInvoiceAMT.Text.Trim) > 0 Then Me.btnPrintInvoice.PerformClick()
                blSkipDeal = False
            Else
                Me.chbMultiPrint.Checked = False
                Me.tlpMultiPrint.Visible = False
                Me.txbInvoiceAMT.Text = Format(IIf(dmAvailableAMT + dmReprintableAMT <= frmInternetSalesInvoice.drInvoicePrintable("MaxInvoiceAMT"), dmAvailableAMT + dmReprintableAMT, frmInternetSalesInvoice.drInvoicePrintable("MaxInvoiceAMT")), "0.00")
                Me.txbInvoiceAMT.Select()
                Me.txbInvoiceAMT.SelectAll()
            End If
        End If

        If dtResult IsNot Nothing Then dtResult.Dispose() : dtResult = Nothing
        DB.Close()

        If blSentDataFailure Then MessageBox.Show("��Ʊ�Ѵ�ӡ����δ�ܽ����ݼ�ʱ���͵�˰��ַ�������    " & Chr(13) & Chr(13) & "���η������ƹ��ϣ�����ϵ����IT��������������á�    ", "δ����Ʊ���ݼ�ʱ���͵�˰��ַ�������", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnPrintInvoice_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintInvoice.EnabledChanged
        Me.btnGetNewInvoiceNo.Enabled = (frmInternetSalesInvoice.blInvoicePrinterMultiUser AndAlso bSeconds = 0 AndAlso Me.btnPrintInvoice.Enabled)
        If Me.btnPrintInvoice.Enabled AndAlso dmTotalRebateAMT > 0 Then
            'If frmInternetSalesInvoice.drSalesBill("InvoicePrintDiscount").ToString = "" Then
            '    Me.chbPrintDiscount.Visible = True
            'Else
            '    Me.chbPrintDiscount.Checked = frmInternetSalesInvoice.drSalesBill("InvoicePrintDiscount")
            '    Me.chbPrintDiscount.Visible = False
            'End If
        Else
            Me.chbPrintDiscount.Visible = False
        End If
    End Sub

    Private Sub ResetInterface()
        Dim iBasicWidth As Int16 = IIf(frmMain.blUseInvoiceDevice, 443, 637)
        If Me.dgvInvoice.RowCount = 0 Then
            Me.grbAvailableInvoiceAMT.Width = iBasicWidth + 31
            Me.grbPrintedInvoice.Visible = False
        Else
            If Me.grbNewInvoice.Visible = False Then iBasicWidth = 443
            Dim iGridWidth As Integer = 0, iGridHeight As Integer = (Me.dgvInvoice.RowCount + 1) * 24 + IIf(ToolStripManager.VisualStylesEnabled, 0, 2), iHeight As Integer = 0
            Me.dgvInvoice.Columns("InvoiceCode").Visible = (frmInternetSalesInvoice.dtInvoice.Select("Isnull(InvoiceCode,'')<>''").Length > 0)
            Me.dgvInvoice.Columns("InvoiceNo").Visible = (frmInternetSalesInvoice.dtInvoice.Select("Isnull(InvoiceNo,'')<>''").Length > 0)
            For Each column As DataGridViewColumn In Me.dgvInvoice.Columns
                If column.Visible Then
                    If column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells OrElse column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill Then
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    End If
                    iGridWidth += column.Width
                End If
            Next
            iGridWidth += IIf(ToolStripManager.VisualStylesEnabled, 2, 4)

            iHeight = Me.grbAvailableInvoiceAMT.Height + 6 + iGridHeight + 38 + 6 + IIf(Me.pnlNewInvoice.Visible, Me.pnlNewInvoice.Height + 6, 0) + 98
            If iHeight > My.Computer.Screen.WorkingArea.Height Then
                iGridHeight = Int((My.Computer.Screen.WorkingArea.Height - Me.grbAvailableInvoiceAMT.Height - 6 - 38 - 6 - IIf(Me.pnlNewInvoice.Visible, Me.pnlNewInvoice.Height + 6, 0) - 98) / 24) * 24
                iGridWidth += 17
            End If
            If iGridWidth < iBasicWidth Then iGridWidth = iBasicWidth
            If iGridWidth > My.Computer.Screen.WorkingArea.Width Then
                iGridWidth = My.Computer.Screen.WorkingArea.Width - 61
                iGridHeight += 17
            End If
            Me.grbAvailableInvoiceAMT.Width = iGridWidth + 31
            Me.grbPrintedInvoice.Height = iGridHeight + 38
            Me.grbPrintedInvoice.Visible = True
            Me.dgvInvoice.Columns("InvoiceTitle").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End If

        Me.Size = New Size(Me.flpLayout.Width + 32, Me.flpLayout.Height + 98)
        Me.Location = New Point((My.Computer.Screen.WorkingArea.Width - Me.Width) / 2, (My.Computer.Screen.WorkingArea.Height - Me.Height) / 2)
    End Sub

    Private Sub GetAvailableInvoiceInfo()
        sInvoiceCode = "" : sInvoiceNo = ""
        Dim objInvoice As Object = Nothing
        Try
            objInvoice = CreateObject("PZHPrj.ComDLL")
            sInvoiceCode = objInvoice.GetCurrInvNOs()
            If sInvoiceCode = "35" Then
                Dim sResult As String = objInvoice.SendInvInfo()
                'If sResult <> "0" Then
                '    MessageBox.Show("��Ϊ��˰��ַ������ϴ���һ����Ʊ�������ʱ����������룺" & sResult & "�����޷���ȡ�µķ�Ʊ���룡    ", "��ȡ�µķ�Ʊ������̱��жϣ�", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '    sInvoiceCode = ""
                '    Return
                'End If

                If frmNewBatchInvoice.ShowDialog = Windows.Forms.DialogResult.OK Then
                    sInvoiceCode = frmNewBatchInvoice.txbInvoiceCode.Text
                    sInvoiceNo = frmNewBatchInvoice.txbStartInvoiceNo.Text
                Else
                    sInvoiceCode = ""
                End If
                frmNewBatchInvoice.Dispose()
            ElseIf sInvoiceCode.IndexOf("0") <> 0 Then
                MessageBox.Show("�޷��ӿ�Ʊ����ȡ��ǰ���õķ�Ʊ���룡������룺" & sInvoiceCode & "��    ", "��ȡ��ǰ���õķ�Ʊ����ʧ�ܣ�", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                sInvoiceCode = ""
            Else
                sInvoiceNo = sInvoiceCode.Substring(sInvoiceCode.LastIndexOf(",") + 1)
                sInvoiceCode = sInvoiceCode.Substring(sInvoiceCode.IndexOf(",") + 1, 12)
            End If
        Catch ex As Exception
            MessageBox.Show("�ӿ�Ʊ����ȡ��ǰ���õķ�Ʊ����ʱ���������Ǿ���Ĵ�����ʾ��    " & Chr(13) & Chr(13) & ex.Message & Space(4), "��ȡ��ǰ���õķ�Ʊ����ʧ�ܣ�", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            sInvoiceCode = ""
        End Try
        objInvoice = Nothing
    End Sub

    Private Sub GetPrintedInvoiceInfo(ByVal sResult As String)
        Dim saResults() As String = sResult.Split(",")
        sMachineNo = saResults(1)
        sInvoiceCode = saResults(2)
        sInvoiceNo = saResults(3)
        sInvoiceSecurityCode = saResults(4).Insert(4, " ").Insert(9, " ").Insert(14, " ").Insert(19, " ")
        sPrintedTime = saResults(5).Insert(4, "-").Insert(7, "-").Insert(10, " ").Insert(13, ":").Insert(16, ":")
    End Sub

    Private Function FinalPrinting(ByVal sRowID As String) As String
        Dim sResult As String = "OK", Invoice As New System.Drawing.Printing.PrintDocument, PrintStandard As New System.Drawing.Printing.StandardPrintController()
        Try
            Invoice.PrintController = PrintStandard '�����ִ�ӡ����
            Invoice.DocumentName = "Invoice_" & frmInternetSalesInvoice.oair.OrderAllInfoData.BillNo.Replace(" ", "") & "-" & sRowID
            If "|21|272|".IndexOf("|" & frmInternetSalesInvoice.sCityID & "|") > -1 Then '�Ϻ�''''
                If Me.chbPrintLine.Checked Then
                    AddHandler Invoice.PrintPage, AddressOf InvoiceSHWithLine_PrintPage
                Else
                    AddHandler Invoice.PrintPage, AddressOf InvoiceSHWithoutLine_PrintPage
                End If
                'modify code 041:start-------------------------------------------------------------------------
                'ElseIf "|24|25|".IndexOf("|" & frmInternetSalesInvoice.sCityID & "|") > -1 Then '����/�ɶ�/���Գ���272|''''''
            ElseIf "|24|25|304|".IndexOf("|" & frmInternetSalesInvoice.sCityID & "|") > -1 Then '����/�ɶ�/����/���Գ���272|''''''
                'modify code 041:end-------------------------------------------------------------------------
                AddHandler Invoice.PrintPage, AddressOf InvoiceCQ_PrintPage
            ElseIf "|27|".IndexOf("|" & frmInternetSalesInvoice.sCityID & "|") > -1 Then '�人
                AddHandler Invoice.PrintPage, AddressOf InvoiceWH_PrintPage
            Else
                AddHandler Invoice.PrintPage, AddressOf Invoice_PrintPage
            End If
            Invoice.PrinterSettings.PrinterName = My.Settings.InvoicePrinter
            Invoice.Print()
        Catch ex As Exception
            sResult = ex.Message
        Finally
            Invoice.Dispose() : Invoice = Nothing : PrintStandard = Nothing
        End Try
        Return sResult
    End Function

    Private Sub Invoice_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        e.Graphics.PageUnit = GraphicsUnit.Millimeter

        Dim drawFont As Font, drawBrush As New SolidBrush(Color.Black), drawFormat As New StringFormat
        drawFormat.FormatFlags = StringFormatFlags.NoWrap

        For Each drItem As DataRow In frmInternetSalesInvoice.dtInvoiceLayout.Select("IsVisible=1 And ItemID<11")
            drawFont = New Font("����", drItem("FontSize"))
            e.Graphics.DrawString(dtPrintItem.Rows.Find(drItem("ItemID"))("PrintText").ToString, drawFont, drawBrush, drItem("X"), drItem("Y"), drawFormat)
        Next

        drawFont = New Font("����", frmInternetSalesInvoice.dtInvoiceLayout.Rows(5)("FontSize"))
        Dim x As Integer = frmInternetSalesInvoice.dtInvoiceLayout.Rows(4)("X"), y As Integer = frmInternetSalesInvoice.dtInvoiceLayout.Rows(4)("Y") '��Ʊ��������
        y += 5
        If dtPrintItem.Rows.Find(12)("PrintText").ToString.Trim <> "" Then
            drawFormat.Alignment = StringAlignment.Far
            e.Graphics.DrawString("�ۿۣ� ", drawFont, drawBrush, x, y, drawFormat)
            drawFormat.Alignment = StringAlignment.Near
            e.Graphics.DrawString(dtPrintItem.Rows.Find(12)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        End If
        y += 5
        drawFormat.Alignment = StringAlignment.Far
        e.Graphics.DrawString("ʵ���� ", drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Near
        e.Graphics.DrawString(dtPrintItem.Rows.Find(13)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)

        If sInvoiceSecurityCode <> "" Then
            x -= 40 : y += 8
            e.Graphics.DrawString("��α�룺 " & sInvoiceSecurityCode, drawFont, drawBrush, x, y, drawFormat)
        End If

        e.HasMorePages = False
    End Sub

    Private Sub InvoiceSHWithLine_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        e.Graphics.PageUnit = GraphicsUnit.Millimeter

        Dim drawFont As New Font("����", 10), drawBrush As New SolidBrush(Color.Black), drawFormat As New StringFormat, blackPen As New Pen(Color.Black, 0.2)
        drawFormat.FormatFlags = StringFormatFlags.NoWrap
        Dim x As Integer = frmInternetSalesInvoice.dtInvoiceLayout.Rows(0)("X"), y As Integer = frmInternetSalesInvoice.dtInvoiceLayout.Rows(0)("Y")

        If My.Settings.IsInTraining Then
            drawFont = New Font("����", 12, FontStyle.Bold)
            x -= 6 : y -= 18
            e.Graphics.DrawString("����ѵʹ�ã�����Ч��Ʊ����", drawFont, drawBrush, x, y, drawFormat)
            drawFont = New Font("����", 10)
            x = frmInternetSalesInvoice.dtInvoiceLayout.Rows(0)("X") : y = frmInternetSalesInvoice.dtInvoiceLayout.Rows(0)("Y")
        End If

        'x -= 3 : y -= 3
        'e.Graphics.DrawRectangle(blackPen, New Rectangle(x, y, 170, 96))
        'x += 3 : y += 3

        x += 13 : y -= 8 '��Ʊ����
        e.Graphics.DrawString(dtPrintItem.Rows.Find(9)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x += 56 '��ҵ����
        e.Graphics.DrawString("��ҵ", drawFont, drawBrush, x, y, drawFormat)
        x += 98 '���ָ�СƱ��
        drawFormat.Alignment = StringAlignment.Far
        e.Graphics.DrawString(dtPrintItem.Rows.Find(10)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x -= 169 : y += 6 '���λ����
        drawFormat.Alignment = StringAlignment.Near
        e.Graphics.DrawString("���λ���ƣ�" & dtPrintItem.Rows.Find(1)("PrintText").ToString.Replace("����ѵʹ�ã�����Ч��Ʊ����", ""), drawFont, drawBrush, x, y, drawFormat)
        x += 113 '���λ˰��
        e.Graphics.DrawString("���λ˰�ţ�", drawFont, drawBrush, x, y, drawFormat)
        If Me.chbPrintLine.Checked Then e.Graphics.DrawLine(blackPen, x - 114, y + 4, x - 114 + 170, y + 4)
        x -= 113 : y += 5 '�տλ����
        e.Graphics.DrawString("�տλ���ƣ�" & sCarrefourName, drawFont, drawBrush, x, y, drawFormat)
        x += 113 '�տλ˰��
        e.Graphics.DrawString("�տλ˰�ţ�" & sReceiverTaxNo, drawFont, drawBrush, x, y, drawFormat)
        If Me.chbPrintLine.Checked Then e.Graphics.DrawLine(blackPen, x - 114, y + 4, x - 114 + 170, y + 4)
        drawFormat.Alignment = StringAlignment.Center
        x -= 113 : y += 5 '���⡰��Ʒ��š�
        e.Graphics.DrawString("��Ʒ���", drawFont, drawBrush, New RectangleF(x, y, 19, 5), drawFormat)
        If Me.chbPrintLine.Checked Then e.Graphics.DrawLine(blackPen, x + 19, y - 1, x + 19, y - 1 + 55)
        x += 19 '���⡰��Ʒ���ơ�
        e.Graphics.DrawString("�� Ʒ �� ��", drawFont, drawBrush, New RectangleF(x, y, 55, 5), drawFormat)
        If Me.chbPrintLine.Checked Then e.Graphics.DrawLine(blackPen, x + 55, y - 1, x + 55, y - 1 + 55)
        x += 55 '���⡰��λ��
        e.Graphics.DrawString("�� λ", drawFont, drawBrush, New RectangleF(x, y, 15, 5), drawFormat)
        If Me.chbPrintLine.Checked Then e.Graphics.DrawLine(blackPen, x + 15, y - 1, x + 15, y - 1 + 55)
        x += 15 '���⡰������
        e.Graphics.DrawString("�� ��", drawFont, drawBrush, New RectangleF(x, y, 15, 5), drawFormat)
        If Me.chbPrintLine.Checked Then e.Graphics.DrawLine(blackPen, x + 15, y - 1, x + 15, y - 1 + 55)
        x += 15 '���⡰���ۡ�
        e.Graphics.DrawString("�� ��", drawFont, drawBrush, New RectangleF(x, y, 30, 5), drawFormat)
        If Me.chbPrintLine.Checked Then e.Graphics.DrawLine(blackPen, x + 30, y - 1, x + 30, y - 1 + 55)
        x += 30 '���⡰��
        e.Graphics.DrawString("�� ��", drawFont, drawBrush, New RectangleF(x, y, 35, 5), drawFormat)
        If Me.chbPrintLine.Checked Then e.Graphics.DrawLine(blackPen, x - 135, y + 4, x - 135 + 170, y + 4)
        drawFormat.Alignment = StringAlignment.Near
        y += 5 : x -= 115 '��ƱƷ��
        e.Graphics.DrawString(dtPrintItem.Rows.Find(2)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Far
        x += 85 '����
        e.Graphics.DrawString(dtPrintItem.Rows.Find(3)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x += 30 '����
        e.Graphics.DrawString(dtPrintItem.Rows.Find(4)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x += 35 '�ܼ�
        e.Graphics.DrawString(dtPrintItem.Rows.Find(5)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        y += 5 : x -= 95 '�ۿ�
        If dtPrintItem.Rows.Find(12)("PrintText").ToString.Trim <> "" Then e.Graphics.DrawString("�ۿ�", drawFont, drawBrush, x, y, drawFormat)
        x += 95 '�ۿ۽��
        e.Graphics.DrawString(dtPrintItem.Rows.Find(12)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        y += 5 : x -= 95 'ʵ�����
        e.Graphics.DrawString("ʵ�����", drawFont, drawBrush, x, y, drawFormat)
        x += 95 'ʵ�����
        e.Graphics.DrawString(dtPrintItem.Rows.Find(13)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        If Me.chbPrintLine.Checked Then e.Graphics.DrawLine(blackPen, x - 170, y + 39, x - 170 + 170, y + 39)
        drawFormat.Alignment = StringAlignment.Near
        x -= 169 : y += 40 '��д���
        e.Graphics.DrawString("�ϼƽ���д������ң���" & dtPrintItem.Rows.Find(6)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Far
        x += 169 'Сд���
        e.Graphics.DrawString("�ϼƽ��Сд��" & dtPrintItem.Rows.Find(13)("PrintText").ToString.Trim, drawFont, drawBrush, x, y, drawFormat)
        If Me.chbPrintLine.Checked Then e.Graphics.DrawLine(blackPen, x - 170, y + 4, x - 170 + 170, y + 4)
        drawFormat.Alignment = StringAlignment.Near
        x -= 169 : y += 5
        e.Graphics.DrawString("��", drawFont, drawBrush, x, y, drawFormat)
        y += 15
        e.Graphics.DrawString("ע", drawFont, drawBrush, x, y, drawFormat)
        If Me.chbPrintLine.Checked Then e.Graphics.DrawLine(blackPen, x + 5, y - 16, x + 5, y - 16 + 20)
        x += 6 : y -= 8 '���ʽ
        If sInvoiceSecurityCode = "" Then
            e.Graphics.DrawString("���ʽ��" & dtPrintItem.Rows.Find(7)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        Else
            e.Graphics.DrawString("���ʽ��" & dtPrintItem.Rows.Find(7)("PrintText").ToString & "    ��α�룺" & sInvoiceSecurityCode, drawFont, drawBrush, x, y, drawFormat)
        End If
        x += 109 : y -= 7
        e.Graphics.DrawString("��", drawFont, drawBrush, x, y, drawFormat)
        y += 5
        e.Graphics.DrawString("��", drawFont, drawBrush, x, y, drawFormat)
        y += 5
        e.Graphics.DrawString("��", drawFont, drawBrush, x, y, drawFormat)
        y += 5
        e.Graphics.DrawString("Ϣ", drawFont, drawBrush, x, y, drawFormat)
        x += 6 : y -= 11
        e.Graphics.DrawString("��Ʊ���룺" & sInvoiceCode, drawFont, drawBrush, x, y, drawFormat)
        y += 7
        e.Graphics.DrawString("��Ʊ���룺" & sInvoiceNo, drawFont, drawBrush, x, y, drawFormat)
        x -= 121 : y += 9
        If Me.chbPrintLine.Checked Then
            e.Graphics.DrawLine(blackPen, x + 114, y - 21, x + 114, y - 21 + 20)
            e.Graphics.DrawLine(blackPen, x + 114 + 6, y - 21, x + 114 + 6, y - 21 + 20)
            e.Graphics.DrawLine(blackPen, x - 1, y - 1, x - 1 + 170, y - 1)
        End If

        e.Graphics.DrawString("��Ʊ��λ�����£���", drawFont, drawBrush, x, y, drawFormat)
        x += 168
        drawFormat.Alignment = StringAlignment.Far
        e.Graphics.DrawString("��Ʊ�ŵ꣺" & frmMain.dtLoginStructure.Rows.Find(frmInternetSalesInvoice.sStoreID)("AreaName").ToString.Substring(4) & "    ��Ʊ�ˣ�" & frmMain.sLoginUserRealName, drawFont, drawBrush, x, y, drawFormat)

        e.HasMorePages = False
    End Sub

    Private Sub InvoiceSHWithoutLine_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
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
        e.Graphics.DrawString(dtPrintItem.Rows.Find(9)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x += 56 '��ҵ����
        e.Graphics.DrawString("��ҵ", drawFont, drawBrush, x, y, drawFormat)
        x += 98 '���ָ�СƱ��
        drawFormat.Alignment = StringAlignment.Far
        e.Graphics.DrawString(dtPrintItem.Rows.Find(10)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x -= 167 : y += 8 '���λ����
        drawFormat.Alignment = StringAlignment.Near
        e.Graphics.DrawString("���λ���ƣ�" & dtPrintItem.Rows.Find(1)("PrintText").ToString.Replace("����ѵʹ�ã�����Ч��Ʊ����", ""), drawFont, drawBrush, x, y, drawFormat)
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
        e.Graphics.DrawString(dtPrintItem.Rows.Find(2)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Center
        x += 79 '����
        e.Graphics.DrawString(dtPrintItem.Rows.Find(3)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x += 25 '����
        e.Graphics.DrawString(dtPrintItem.Rows.Find(4)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x += 25 '�ܼ�
        e.Graphics.DrawString(dtPrintItem.Rows.Find(5)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Near
        y += 5 : x -= 18 '�ۿ�
        drawFormat.Alignment = StringAlignment.Far
        If dtPrintItem.Rows.Find(12)("PrintText").ToString.Trim <> "" Then e.Graphics.DrawString("�ۿۣ�", drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Center
        x += 18 '�ۿ۽��
        drawFormat.Alignment = StringAlignment.Center
        e.Graphics.DrawString(dtPrintItem.Rows.Find(12)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        y += 5 : x -= 18 'ʵ�����
        drawFormat.Alignment = StringAlignment.Far
        e.Graphics.DrawString("ʵ����", drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Center
        x += 18 'ʵ�����
        drawFormat.Alignment = StringAlignment.Center
        e.Graphics.DrawString(dtPrintItem.Rows.Find(13)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Near
        x -= 149 : y += 40 '��д���
        e.Graphics.DrawString("�ϼƽ���д������ң���" & dtPrintItem.Rows.Find(6)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Far
        x += 160 'Сд���
        e.Graphics.DrawString("�ϼƽ��Сд��" & dtPrintItem.Rows.Find(13)("PrintText").ToString.Trim, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Near
        x -= 160 : y += 8 '��Ʊ�ŵꡢ��Ʊ���롢��Ʊ����
        If sInvoiceSecurityCode = "" Then
            e.Graphics.DrawString("��Ʊ�ŵ꣺" & frmMain.dtLoginStructure.Rows.Find(frmInternetSalesInvoice.sStoreID)("AreaName").ToString.Substring(4) & "    ��Ʊ���룺" & sInvoiceCode & "    ��Ʊ���룺" & sInvoiceNo, drawFont, drawBrush, x, y, drawFormat)
        Else
            e.Graphics.DrawString("��Ʊ�ŵ꣺" & frmMain.dtLoginStructure.Rows.Find(frmInternetSalesInvoice.sStoreID)("AreaName").ToString.Substring(4) & "    ��Ʊ���룺" & sInvoiceCode & "    ��Ʊ���룺" & sInvoiceNo & "    ��α�룺" & sInvoiceSecurityCode, drawFont, drawBrush, x, y, drawFormat)
        End If
        y += 8 '��Ʊ��
        e.Graphics.DrawString("��Ʊ�ˣ�" & frmMain.sLoginUserRealName, drawFont, drawBrush, x, y, drawFormat)
        x += 35 '���ʽ
        e.Graphics.DrawString("���ʽ��" & dtPrintItem.Rows.Find(7)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x += 35 '���⡰��Ʊ��λ�����£���
        e.Graphics.DrawString("��Ʊ��λ�����£���", drawFont, drawBrush, x, y, drawFormat)

        e.HasMorePages = False
    End Sub

    Private Sub InvoiceCQ_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
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
        e.Graphics.DrawString(dtPrintItem.Rows.Find(9)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x += 56 '��ҵ����
        e.Graphics.DrawString("��ҵ", drawFont, drawBrush, x, y, drawFormat)
        x += 98 '���ָ�СƱ��
        drawFormat.Alignment = StringAlignment.Far
        e.Graphics.DrawString(dtPrintItem.Rows.Find(10)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x -= 167 : y += 8 '���λ����
        drawFormat.Alignment = StringAlignment.Near
        e.Graphics.DrawString("���λ���ƣ�" & dtPrintItem.Rows.Find(1)("PrintText").ToString.Replace("����ѵʹ�ã�����Ч��Ʊ����", ""), drawFont, drawBrush, x, y, drawFormat)
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
        e.Graphics.DrawString(dtPrintItem.Rows.Find(2)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Center
        x += 79 '����
        e.Graphics.DrawString(dtPrintItem.Rows.Find(3)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x += 25 '����
        e.Graphics.DrawString(dtPrintItem.Rows.Find(4)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x += 25 '�ܼ�
        e.Graphics.DrawString(dtPrintItem.Rows.Find(5)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Near
        y += 5 : x -= 18 '�ۿ�
        drawFormat.Alignment = StringAlignment.Far
        If dtPrintItem.Rows.Find(12)("PrintText").ToString.Trim <> "" Then e.Graphics.DrawString("�ۿۣ�", drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Center
        x += 18 '�ۿ۽��
        drawFormat.Alignment = StringAlignment.Center
        e.Graphics.DrawString(dtPrintItem.Rows.Find(12)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        y += 5 : x -= 18 'ʵ�����
        drawFormat.Alignment = StringAlignment.Far
        e.Graphics.DrawString("ʵ����", drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Center
        x += 18 'ʵ�����
        drawFormat.Alignment = StringAlignment.Center
        e.Graphics.DrawString(dtPrintItem.Rows.Find(13)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Near
        x -= 149 : y += 40 '��д���
        e.Graphics.DrawString("�ϼƽ���д������ң���" & dtPrintItem.Rows.Find(6)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Far
        x += 160 'Сд���
        e.Graphics.DrawString("�ϼƽ��Сд��" & dtPrintItem.Rows.Find(13)("PrintText").ToString.Trim, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Near
        x -= 160 : y += 8 '��Ʊ���롢��Ʊ���롢��α��
        If sInvoiceSecurityCode <> "" Then e.Graphics.DrawString("��Ʊ���룺" & sInvoiceCode & "    ��Ʊ���룺" & sInvoiceNo & "    ��α�룺" & sInvoiceSecurityCode, drawFont, drawBrush, x, y, drawFormat)
        y += 8 '��Ʊ��
        e.Graphics.DrawString("��Ʊ�ˣ�" & frmMain.sLoginUserRealName, drawFont, drawBrush, x, y, drawFormat)
        'modify code 042:start-------------------------------------------------------------------------
        'x += 35 '���ʽ
        'e.Graphics.DrawString("���ʽ��" & dtPrintItem.Rows.Find(7)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        'modify code 042:end-------------------------------------------------------------------------
        x += 35 '���⡰��Ʊ��λ�����£���
        e.Graphics.DrawString("��Ʊ��λ�����£���", drawFont, drawBrush, x, y, drawFormat)

        e.HasMorePages = False
    End Sub

    Private Sub InvoiceWH_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
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
        e.Graphics.DrawString(dtPrintItem.Rows.Find(9)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x += 56 '��ҵ����
        e.Graphics.DrawString("��ҵ", drawFont, drawBrush, x, y, drawFormat)
        x += 78 : y += 2 '���ָ�СƱ��
        drawFormat.Alignment = StringAlignment.Far
        e.Graphics.DrawString(dtPrintItem.Rows.Find(10)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x -= 147 : y += 8 '���λ����
        drawFormat.Alignment = StringAlignment.Near
        e.Graphics.DrawString("���λ���ƣ�" & dtPrintItem.Rows.Find(1)("PrintText").ToString.Replace("����ѵʹ�ã�����Ч��Ʊ����", ""), drawFont, drawBrush, x, y, drawFormat)
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
        e.Graphics.DrawString(dtPrintItem.Rows.Find(2)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Center
        x += 64 '����
        e.Graphics.DrawString(dtPrintItem.Rows.Find(3)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x += 20 '����
        e.Graphics.DrawString(dtPrintItem.Rows.Find(4)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x += 25 '�ܼ�
        e.Graphics.DrawString(dtPrintItem.Rows.Find(5)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Near
        y += 5 : x -= 18 '�ۿ�
        drawFormat.Alignment = StringAlignment.Far
        If dtPrintItem.Rows.Find(12)("PrintText").ToString.Trim <> "" Then e.Graphics.DrawString("�ۿۣ�", drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Center
        x += 18 '�ۿ۽��
        drawFormat.Alignment = StringAlignment.Center
        e.Graphics.DrawString(dtPrintItem.Rows.Find(12)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        y += 5 : x -= 18 'ʵ�����
        drawFormat.Alignment = StringAlignment.Far
        e.Graphics.DrawString("ʵ����", drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Center
        x += 18 'ʵ�����
        drawFormat.Alignment = StringAlignment.Center
        e.Graphics.DrawString(dtPrintItem.Rows.Find(13)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Near
        x -= 129 : y += 15 '��д���
        e.Graphics.DrawString("�ϼƽ���д������ң���" & dtPrintItem.Rows.Find(6)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Far
        x += 140 'Сд���
        e.Graphics.DrawString("�ϼƽ��Сд��" & dtPrintItem.Rows.Find(13)("PrintText").ToString.Trim, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Near
        x -= 140 : y += 5 '��Ʊ��
        e.Graphics.DrawString("��Ʊ�ˣ�" & frmMain.sLoginUserRealName, drawFont, drawBrush, x, y, drawFormat)
        x += 35 '���ʽ
        e.Graphics.DrawString("���ʽ��" & dtPrintItem.Rows.Find(7)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x += 35 '���⡰��Ʊ��λ�����£���
        e.Graphics.DrawString("��Ʊ��λ�����£���", drawFont, drawBrush, x, y, drawFormat)
        x -= 115 : y += 5 '��Ʊ���롢��Ʊ���롢��α��
        If sInvoiceSecurityCode <> "" Then e.Graphics.DrawString("��Ʊ���룺" & sInvoiceCode & "    ��Ʊ���룺" & sInvoiceNo & "    ��α�룺" & sInvoiceSecurityCode, drawFont, drawBrush, x, y, drawFormat)

        e.HasMorePages = False
    End Sub

    Private Function ConvertStrToDatetime(ByVal sStr As String) As String
        If sStr = "" Then
            Return ""
        ElseIf IsDate(sStr) Then
            Return sStr
        Else
            Return sStr.Substring(0, 4) & "-" & sStr.Substring(4, 2) & "-" & sStr.Substring(6, 2) _
            & " " & sStr.Substring(8, 2) & ":" & sStr.Substring(10, 2) & ":" & sStr.Substring(12)
        End If
    End Function

End Class
'modify code 040:end-------------------------------------------------------------------------