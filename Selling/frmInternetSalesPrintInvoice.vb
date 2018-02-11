
'modify code 040:
'date;2014/11/5
'auther:Hyron bjy 
'remark:新增销售单类型---线下提卡销售单

'modify code 042:
'date;2014/12/11
'auther:Hyron bjy 
'remark: 成都开票去除付款方式项目

'modify code 041:
'date;2014/11/28
'auther:Hyron bjy 
'remark:资阳的发票打印同成都

'modify code 070:
'date;2017/3/31
'auther:Qipeng
'remark:取消超过31天不能打印发票的限制

'modify code 040:start-------------------------------------------------------------------------
Public Class frmInternetSalesPrintInvoice

    Private blSkipDeal As Boolean = True, dmAvailableAMT As Decimal = 0, dmReprintableAMT As Decimal = 0, dtPrintItem As DataTable, bShowTimes As Byte = 0, bSeconds As Byte = 10, iMultiPrint As Int16 = 2
    Private sMachineNo As String = "", sInvoiceCode As String = "", sInvoiceNo As String = "", sInvoiceSecurityCode As String = "", sPrintedTime As String = ""
    Public blIsDeduction As Boolean = False, dmTotalChargedAMT As Decimal = 0, dmTotalRebateAMT As Decimal = 0, sCarrefourName As String, sReceiverTaxNo As String

    Private Sub frmInternetSalesPrintInvoice_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If frmMain.statusText.Text.IndexOf("无法") = -1 Then frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub frmInternetSalesPrintInvoice_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If dmReprintableAMT > 0 Then
            Dim bAnswer As DialogResult = Windows.Forms.DialogResult.Cancel
            If frmInternetSalesInvoice.dtInvoice.Select("Remarks Like '剩余金额%'").Length > 0 Then
                bAnswer = MessageBox.Show("您已经取消了某些发票，但还有部分已经取消的发票金额未被重打印！    " & Chr(13) & Chr(13) & "您应该及时重打印这些剩余金额，否则，可能会因为超过可重打印时限而再也不能重打印这部分金额！    " & Chr(13) & Chr(13) & "您确实不想现在就重打印剩余发票金额吗？    ", "请确认退出发票窗口：", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            Else
                bAnswer = MessageBox.Show("您已经取消了某些发票，但未对即将取消的发票金额进行重打印！    " & Chr(13) & Chr(13) & "现在退出发票窗口将撤销发票取消操作，是否退出？    ", "请确认退出发票窗口：", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
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
                .HeaderText = "行号"
                .Width = 40
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
            End With
            With .Columns(1)
                .HeaderText = "发票代码"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(2)
                .HeaderText = "发票号码"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(3)
                .HeaderText = "发票抬头"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(4)
                .HeaderText = "发票品项"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(5)
                .HeaderText = "发票金额"
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(6)
                .HeaderText = "数量"
                .DefaultCellStyle.Format = "#,0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(7)
                .HeaderText = "付款方式"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(8)
                .HeaderText = "打印者"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(9)
                .HeaderText = "打印时间"
                .DefaultCellStyle.Format = "yyyy\/MM\/dd HH:mm:ss"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(10)
                .HeaderText = "原发票"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .Visible = (frmInternetSalesInvoice.dtInvoice.Select("Isnull(SourceInvoice,'')<>''").Length > 0)
            End With
            With .Columns(11)
                .HeaderText = "状态"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(12)
                .HeaderText = "取消并重打印原因"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .Visible = (frmInternetSalesInvoice.dtInvoice.Select("Isnull(CancelledReason,'')<>''").Length > 0)
            End With
            With .Columns(13)
                .HeaderText = "说明"
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
                .HeaderText = "操作"
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
                .Items.Add("（没有品项）")
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
                Me.btnPrintInvoice.Text = "打印发票(&I)"
            Else
                Me.btnPrintInvoice.Text = "重打印发票(&I)"
            End If

            If Not frmInternetSalesInvoice.drInvoicePrintable("CanPrintInNextMonth") AndAlso Today() > CDate(Format(DateAdd(DateInterval.Month, 1, CDate(ConvertStrToDatetime(frmInternetSalesInvoice.oair.OrderAllInfoData.BillCreateTimestamp))), "yyyy\/MM\/dd").Substring(0, 8) & "01") Then
                For Each ctrl As Control In Me.grbNewInvoice.Controls
                    ctrl.Enabled = False
                Next
                For Each ctrl As Control In Me.grbNewInvoiceExtra.Controls
                    ctrl.Enabled = False
                Next
                Me.lblError.Text = "（应当地税务部门""不可过月打印发票""的规定，不再能打印发票。）"
                Me.lblError.Visible = True
                'modify code 070:start-------------------------------------------------------------------------
                'ElseIf DateDiff(DateInterval.Day, CDate(ConvertStrToDatetime(frmInternetSalesInvoice.oair.OrderAllInfoData.BillCreateTimestamp)), Today()) > 31 Then
                '    For Each ctrl As Control In Me.grbNewInvoice.Controls
                '        ctrl.Enabled = False
                '    Next
                '    For Each ctrl As Control In Me.grbNewInvoiceExtra.Controls
                '        ctrl.Enabled = False
                '    Next
                '    Me.lblError.Text = "（当前销售单已超过 31 天的发票打印有效期，不再能打印发票。）"
                '    Me.lblError.Visible = True
                'modify code 070:end-------------------------------------------------------------------------
            ElseIf dmAvailableAMT + dmReprintableAMT < frmInternetSalesInvoice.drInvoicePrintable("MinInvoiceAMT") Then
                For Each ctrl As Control In Me.grbNewInvoice.Controls
                    ctrl.Enabled = False
                Next
                For Each ctrl As Control In Me.grbNewInvoiceExtra.Controls
                    ctrl.Enabled = False
                Next
                Me.lblError.Text = "（可打印发票金额小于系统设定的单张发票最小金额。）"
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
                        Me.lblError.Text = "（" & sResult & "不能打印发票！）"
                        Me.lblError.Visible = True
                    End If
                End If

                If Not frmMain.blUseInvoiceDevice OrElse frmMain.blInvoiceDeviceOK Then Me.txbInvoiceAMT.Text = Format(IIf(dmAvailableAMT + dmReprintableAMT <= frmInternetSalesInvoice.drInvoicePrintable("MaxInvoiceAMT"), dmAvailableAMT + dmReprintableAMT, frmInternetSalesInvoice.drInvoicePrintable("MaxInvoiceAMT")), "#,0.00")
            End If
        End If

        If "|21|272|".IndexOf(frmInternetSalesInvoice.sCityID) > 0 Then '上海及测试城市
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
        If frmInternetSalesInvoice.blInvoicePrinterMultiUser Then Me.btnGetNewInvoiceNo.Text = "10秒后获取下一个可用号码"
    End Sub

    Private Sub theTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles theTimer.Tick
        bShowTimes += 1
        If bShowTimes = 7 Then bShowTimes = 0 : Me.theTimer.Enabled = False
        Me.dgvInvoice.Refresh()
    End Sub

    Private Sub newInvoiceNoTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles newInvoiceNoTimer.Tick
        bSeconds -= 1
        If bSeconds = 0 Then
            Me.btnGetNewInvoiceNo.Text = "获取下一个可用发票号码"
            Me.btnGetNewInvoiceNo.Enabled = (frmInternetSalesInvoice.blInvoicePrinterMultiUser AndAlso Me.btnPrintInvoice.Enabled)
            Me.newInvoiceNoTimer.Enabled = False
        ElseIf frmInternetSalesInvoice.blInvoicePrinterMultiUser Then
            Me.btnGetNewInvoiceNo.Text = bSeconds.ToString & "秒后获取下一个可用号码"
        End If
    End Sub

    Private Sub dgvInvoice_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInvoice.CellContentClick
        If e.RowIndex = -1 OrElse Me.dgvInvoice.Columns(e.ColumnIndex).Name <> "Reprint" Then Return
        If Me.dgvInvoice("InvoiceState", e.RowIndex).Value.ToString = "已被取消" OrElse (Me.dgvInvoice("Remarks", e.RowIndex).Value.ToString <> "" AndAlso Me.dgvInvoice("Remarks", e.RowIndex).Value.ToString.IndexOf("重打印时限：") = -1) Then Return

        If frmMain.dtAllowedRight.Select("RightName='E-CardInvoice'").Length = 0 Then
            MessageBox.Show("对不起！您没有重打印销售发票的权限。    ", "您无权重打印销售发票！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.dgvInvoice.Columns(e.ColumnIndex).Visible = False
            Me.dgvInvoice.Columns("InvoiceTitle").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Return
        End If

        frmMain.statusText.Text = "就绪。"
        Dim drInvoice As DataRow = frmInternetSalesInvoice.dtInvoice.Select("RowID=" & Me.dgvInvoice("RowID", e.RowIndex).Value.ToString)(0)
        If drInvoice("InvoiceState").ToString = "正常" Then
            If drInvoice("ReprintableTimes") = 0 Then
                MessageBox.Show("总部财务部规定，一张发票最多可重打印两次。    " & Chr(13) & Chr(13) & "该发票的原发票已被重打印过两次，所以不再可打印。    ", "重打印发票不能超过两次！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                drInvoice("Remarks") = "原发票已被重打印过两次，不允许再打印！"
                With Me.dgvInvoice.Columns("Remarks")
                    .Visible = True
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
            ElseIf DateAdd(DateInterval.Second, frmInternetSalesInvoice.iDifferenceSeconds, drInvoice("ReprintableTime")) < Now() Then
                MessageBox.Show("总部财务部规定，发票只能在一个小时之内重打印， 之后不再允许重打印。    ", "发票已经超过可重打印的时限！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                drInvoice("Remarks") = "该发票" & IIf(drInvoice("SourceInvoice").ToString = "", "", "的原发票") & "已经超过可重打印的时限！"
                With Me.dgvInvoice.Columns("Remarks")
                    .Visible = True
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With
            Else
                If frmMain.blUseInvoiceDevice AndAlso Not frmMain.blInvoiceDeviceOK Then
                    Dim sResult As String = frmMain.InvoiceDeviceCheck()
                    If Not frmMain.blInvoiceDeviceOK Then
                        drInvoice("Remarks") = sResult & "不能取消发票！）"
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
                    drInvoice("InvoiceState") = "即将取消"
                    drInvoice("CancelledReason") = sReprintReason
                    drInvoice("Remarks") = "可重打印金额：" & Format(drInvoice("InvoiceAMT"), "#,0.00").Replace(".00", "") & "；可重打印时限：" & Format(drInvoice("ReprintableTime"), "HH:mm:ss") & "。"
                    drInvoice("Reprint") = "撤销重打印"
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
                    Me.btnPrintInvoice.Text = "重打印发票(&I)"
                    Me.btnPrintInvoice.Visible = True
                    Me.theTimer.Enabled = True
                End If
            End If
        Else '撤销重打印
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
            Me.btnPrintInvoice.Text = IIf(dmReprintableAMT = 0, "打印发票(&I)", "重打印发票(&I)")
            Me.btnPrintInvoice.Visible = Me.pnlNewInvoice.Visible
        End If

        Me.ResetInterface()
        If Me.dgvInvoice.CurrentRow IsNot Nothing Then Me.dgvInvoice.FirstDisplayedScrollingRowIndex = Me.dgvInvoice.CurrentRow.Index
        If Me.grbPrintedInvoice.Visible Then Me.dgvInvoice.Select()
        If Me.pnlNewInvoice.Visible Then
            Me.chbPrintLine.Visible = ("|21|272|".IndexOf(frmInternetSalesInvoice.sCityID) > 0) '上海及测试城市
        Else
            Me.chbPrintLine.Visible = False
        End If
    End Sub

    Private Sub dgvInvoice_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvInvoice.CellFormatting
        If Me.dgvInvoice("InvoiceState", e.RowIndex).Value.ToString = "已被取消" Then
            e.CellStyle.BackColor = Color.WhiteSmoke
            e.CellStyle.SelectionBackColor = SystemColors.GradientInactiveCaption
            If Me.dgvInvoice.Columns(e.ColumnIndex).Name = "Remarks" Then
                If e.Value.ToString <> "" AndAlso e.Value.ToString.IndexOf("重打印时限：") = -1 Then
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
        ElseIf Me.dgvInvoice("InvoiceState", e.RowIndex).Value.ToString = "即将取消" Then
            e.CellStyle.BackColor = Color.WhiteSmoke
            e.CellStyle.SelectionBackColor = SystemColors.GradientInactiveCaption
            If Me.dgvInvoice.Columns(e.ColumnIndex).Name = "Remarks" Then
                If e.Value.ToString <> "" AndAlso e.Value.ToString.IndexOf("重打印时限：") = -1 Then
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

        If Me.dgvInvoice.Columns(e.ColumnIndex).Name = "Reprint" AndAlso (Me.dgvInvoice("InvoiceState", e.RowIndex).Value.ToString = "已被取消" OrElse (Me.dgvInvoice("Remarks", e.RowIndex).Value.ToString <> "" AndAlso Me.dgvInvoice("Remarks", e.RowIndex).Value.ToString.IndexOf("重打印时限：") = -1)) Then
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
                .Items.Add("（没有品项）")
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
            Me.lblError.Text = "（错误：超过最大可打印金额！）"
            Me.btnPrintInvoice.Enabled = False
        ElseIf CDec(Me.txbInvoiceAMT.Text.Trim.Replace(",", "")) < frmInternetSalesInvoice.drInvoicePrintable("MinInvoiceAMT") Then
            Me.lblError.Visible = True
            Me.lblError.Text = "（当地税务部门规定：单张发票的最小金额不能低于 " & Format(frmInternetSalesInvoice.drInvoicePrintable("MinInvoiceAMT"), "#,0.00").Replace(".00", "") & " 元！）"
            Me.btnPrintInvoice.Enabled = False
        ElseIf CDec(Me.txbInvoiceAMT.Text.Trim.Replace(",", "")) > frmInternetSalesInvoice.drInvoicePrintable("MaxInvoiceAMT") Then
            Me.lblError.Visible = True
            Me.lblError.Text = "（当地税务部门规定：单张发票的最大金额不能超过 " & Format(frmInternetSalesInvoice.drInvoicePrintable("MaxInvoiceAMT"), "#,0.00").Replace(".00", "") & " 元！）"
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
        frmMain.statusText.Text = "正在获取下一个可用发票号码……"
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
                Me.btnGetNewInvoiceNo.Text = "10秒后获取下一个可用号码"
                Me.btnGetNewInvoiceNo.Enabled = False
                Me.newInvoiceNoTimer.Enabled = True
                frmMain.statusText.Text = "就绪。"
            Catch ex As Exception
                frmInternetSalesInvoice.sInvoiceCode = "" : frmInternetSalesInvoice.sInvoiceNo = ""
                MessageBox.Show("获取可用发票号码失败！下面是错误提示：    " & Chr(13) & Chr(13) & ex.Message & Space(4), "获取可用发票号码失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                frmMain.statusText.Text = "f获取可用发票号码失败！"
            End Try
        Else
            frmMain.statusText.Text = "系统因连接不到数据库而无法获取下一个可用发票号码。请检查数据库连接。"
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
            MessageBox.Show("您选择的发票品项不存在！    " & Chr(13) & Chr(13) & "请重新选择发票品项。    ", "发票品项不存在！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.cbbInvoiceItem1.Select() : Me.cbbInvoiceItem1.SelectAll()
            Return
        End If
        If Me.cbbInvoiceItem2.SelectedIndex = -1 Then
            MessageBox.Show("您选择的发票品项不存在！    " & Chr(13) & Chr(13) & "请重新选择发票品项。    ", "发票品项不存在！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.cbbInvoiceItem2.Select() : Me.cbbInvoiceItem2.SelectAll()
            Return
        End If

        If Not frmMain.blUseInvoiceDevice Then
            If Me.txbInvoiceCode.Text = "" Then
                MessageBox.Show("发票代码不能为空！请输入发票代码。    ", "发票代码不能为空！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txbInvoiceCode.Select()
                Return
            End If
            If Me.txbInvoiceNo.Text = "" Then
                MessageBox.Show("发票号码不能为空！请输入发票号码。    ", "发票号码不能为空！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txbInvoiceNo.Select()
                Return
            End If
            sInvoiceCode = Me.txbInvoiceCode.Text : sInvoiceNo = Me.txbInvoiceNo.Text
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim sTask As String = IIf(Me.btnPrintInvoice.Text.IndexOf("重") > -1, "重", "") & "打印"
        frmMain.statusText.Text = "正在" & sTask & "发票……"
        frmMain.statusMain.Refresh()

        Dim dmTotalPayment As Decimal = CDec(Me.txbTotalPaymentAMT.Text.Trim.Replace(",", "")), dmInvoiceAMT As Decimal = CDec(Me.txbInvoiceAMT.Text.Trim.Replace(",", "")), sTotalAMT As String = "", sRebateAMT As String = "", sRealAMT As String = "", sInvoiceItem As String = "", sPaymentTerm As String = "", sSummaryInfo As String = ""
        If Me.cbbInvoiceItem2.SelectedIndex = 0 Then
            sInvoiceItem = Me.cbbInvoiceItem1.Text
        Else
            sInvoiceItem = Me.cbbInvoiceItem1.Text & "、" & Me.cbbInvoiceItem2.Text
        End If

        sPaymentTerm = "网上付款"

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

        sSummaryInfo = "总购买金额：" & Format(IIf(blIsDeduction, dmTotalChargedAMT, dmTotalPayment) * (dmInvoiceAMT / dmTotalPayment), "#,0.00")
        If Me.chbPrintDiscount.Checked Then sSummaryInfo = sSummaryInfo & "  折扣金额：" & Format(dmTotalRebateAMT * (dmInvoiceAMT / dmTotalPayment), "#,0.00")
        sSummaryInfo = sSummaryInfo & "  实付金额：" & Format(dmInvoiceAMT, "#,0.00")

        Dim sSQL As String = "Exec PrintInvoice_InternetSales @BillNo='" & frmInternetSalesInvoice.oair.OrderAllInfoData.BillNo.ToString & "',@TotalPaymentAMT=" & CDec(Me.txbTotalPaymentAMT.Text).ToString & ",@TotalPrintedInvoiceAMT=" & CDec(Me.txbTotalPrintedInvoiceAMT.Text).ToString & ",@RowID=" & (Me.dgvInvoice.RowCount + 1).ToString & ","
        If Not frmMain.blUseInvoiceDevice Then sSQL = sSQL & "@PrinterDevice='" & frmInternetSalesInvoice.sInvoicePrinterDevice.Replace("'", "''") & "',@InvoiceCode='" & sInvoiceCode & "',@InvoiceNo='" & sInvoiceNo & "',"
        sSQL = sSQL & "@InvoiceTitle='" & Me.txbInvoiceTitle.Text.Trim.Replace("'", "''") & "',@InvoiceItem1='" & Me.cbbInvoiceItem1.Text.Replace("'", "''") & "',"
        If Me.cbbInvoiceItem2.SelectedIndex > 0 Then sSQL = sSQL & "@InvoiceItem2='" & Me.cbbInvoiceItem2.Text.Replace("'", "''") & "',"
        sSQL = sSQL & "@InvoiceAMT=" & dmInvoiceAMT.ToString & ","
        If Me.nudQTY.Value <> 1 Then sSQL = sSQL & "@Quantity=" & Me.nudQTY.Value.ToString & ","
        If sPaymentTerm <> "网上付款" Then sSQL = sSQL & "@PaymentTerm='" & sPaymentTerm & "',"

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
                    If drInvoice("InvoiceState").ToString = "已被取消" Then
                        drInvoice("Remarks") = "剩余金额：" & Format(drInvoice("ReprintableAMT"), "#,0.00").Replace(".00", "") & "（已超过可重打印时限！）"
                        drInvoice("ReprintableAMT") = 0
                        drInvoice.AcceptChanges()
                    Else
                        drInvoice.RejectChanges()
                        drInvoice("Remarks") = "可重打印金额：" & Format(drInvoice("InvoiceAMT"), "#,0.00").Replace(".00", "") & "（已超过可重打印时限！）"
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
                Me.lblError.Text = "（错误：超过最大可打印金额！）"
                Me.btnPrintInvoice.Enabled = False
                frmMain.statusText.Text = "发票金额超过最大可打印金额！"
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
            frmMain.statusText.Text = "系统因连接不到数据库而无法" & sTask & "发票。请检查数据库连接。"
            dtNew.Dispose() : dtNew = Nothing
            If dtCancelled IsNot Nothing Then dtCancelled.Dispose() : dtCancelled = Nothing
            drInvoice = Nothing : drNew = Nothing : drCancelled = Nothing
            Me.Cursor = Cursors.Default : Return
        End If

        If dtCancelled IsNot Nothing AndAlso dtCancelled.Rows.Count > 0 Then
            If DB.ModifyTable("Select BILLNO,RowID,CancelledReason,ReprintableAMT Into #CancelledInvoice From InternetSalesInvoice Where 1=2") = -1 OrElse DB.BulkCopyTable("#CancelledInvoice", dtCancelled) = -1 Then
                Me.ResetInterface()
                frmMain.statusText.Text = sTask & "发票失败！"
                dtNew.Dispose() : dtNew = Nothing
                dtCancelled.Dispose() : dtCancelled = Nothing
                drInvoice = Nothing : drNew = Nothing : drCancelled = Nothing
                DB.Close() : Me.Cursor = Cursors.Default : Return
            End If
        End If

        If dmReprintableAMT > 0 Then
            dtCancelled.AcceptChanges()
            Dim sSourceInvoice As String = "第"
            For Each drCancelled In dtCancelled.Select("", "RowID")
                sSourceInvoice = sSourceInvoice & drCancelled("RowID").ToString & "、"
            Next
            sSourceInvoice = sSourceInvoice.Substring(0, sSourceInvoice.Length - 1) & "张"
            drNew("SourceInvoice") = sSourceInvoice
            sSQL = sSQL & "@SourceInvoice='" & sSourceInvoice & "',@ReprintableTimes=" & drNew("ReprintableTimes").ToString & ",@ReprintableTime='" & Format(drNew("ReprintableTime"), "yyyy\/MM\/dd HH:mm:ss") & "',"
            sSQL = sSQL & "@NewPrintedInvoiceAMT=" & IIf(dmReprintableAMT >= dmInvoiceAMT, 0, dmInvoiceAMT - dmReprintableAMT).ToString & ",@CancelledInvoices=" & dtCancelled.Rows.Count.ToString & ","
        End If
        sSQL = sSQL & "@OperatorName='" & frmMain.sLoginUserRealName.Replace("'", "''") & "',@SSID=" & frmMain.sSSID & ",@StoreID=" & frmInternetSalesInvoice.sStoreID

        Dim dtResult As DataTable = DB.GetDataTable(sSQL), sResult As String = "", blNeedResetInfo As Boolean = False, blSentDataFailure As Boolean = False
        If dtResult Is Nothing Then
            frmMain.statusText.Text = "" & sTask & "发票失败！"
        ElseIf dtResult.Rows(0)("Result").ToString <> "OK" Then
            Select Case dtResult.Rows(0)("Result").ToString
                Case "SalesBillDeleted"
                    MessageBox.Show("当前销售单已被取消！不能" & sTask & "发票。    ", "不能" & sTask & "发票！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    frmMain.statusText.Text = "当前销售单已被取消！"
                    dtNew.Dispose() : dtNew = Nothing
                    If dtCancelled IsNot Nothing Then dtCancelled.Dispose() : dtCancelled = Nothing
                    drInvoice = Nothing : drNew = Nothing : drCancelled = Nothing
                    DB.Close() : Me.Cursor = Cursors.Default
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel : Return
                Case "SalesBillCancelled"
                    MessageBox.Show("当前销售单已被申请取消！不能" & sTask & "发票。    ", "不能" & sTask & "发票！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    frmMain.statusText.Text = "当前销售单已被申请取消！"
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
                        MessageBox.Show("当前可打印的发票金额已经发生改变！    " & Chr(13) & Chr(13) & "请重新检查或输入当次即将打印的发票金额。    ", "可打印发票金额已改变！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        frmMain.statusText.Text = "可打印发票金额已改变！"
                    ElseIf dmNewReprintableAMT = 0 Then
                        MessageBox.Show("当前销售单的发票列表已经发生改变！    ", "发票列表已经发生改变！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        frmMain.statusText.Text = "发票列表已经发生改变！"
                    Else
                        MessageBox.Show("当前销售单的发票列表已经发生改变！    " & Chr(13) & Chr(13) & "请重新检查或输入当次即将重打印的发票金额。    ", "可打印发票金额已改变！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        frmMain.statusText.Text = "发票列表已经发生改变！"
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
                        Me.chbPrintLine.Visible = ("|21|272|".IndexOf(frmInternetSalesInvoice.sCityID) > 0) '上海及测试城市
                    End If

                    blNeedResetInfo = True
                Case "InvoiceNoUsed"
                    bSeconds = 10
                    frmInternetSalesInvoice.blInvoicePrinterMultiUser = True
                    Me.btnGetNewInvoiceNo.Text = "10秒后获取下一个可用号码"
                    Me.btnGetNewInvoiceNo.Enabled = False
                    Me.newInvoiceNoTimer.Enabled = True

                    frmInternetSalesInvoice.sInvoiceCode = dtResult.Rows(0)("LastInvoiceCode").ToString
                    frmInternetSalesInvoice.sInvoiceNo = dtResult.Rows(0)("LastInvoiceNo").ToString
                    frmInternetSalesInvoice.sInvoiceNo = (CLng(frmInternetSalesInvoice.sInvoiceNo) + 1).ToString
                    If frmInternetSalesInvoice.sInvoiceNo.Length < dtResult.Rows(0)("LastInvoiceNo").ToString.Length Then frmInternetSalesInvoice.sInvoiceNo = StrDup(dtResult.Rows(0)("LastInvoiceNo").ToString.Length - frmInternetSalesInvoice.sInvoiceNo.Length, "0") & frmInternetSalesInvoice.sInvoiceNo
                    MessageBox.Show("发票代码""" & sInvoiceCode & """中的发票号码""" & sInvoiceNo & """已被使用！    " & Chr(13) & Chr(13) & _
                                    "下面是系统自动获取的下一个可用的发票代码及发票号码：    " & Chr(13) & Chr(13) & _
                                    "发票代码：" & frmInternetSalesInvoice.sInvoiceCode & Space(4) & Chr(13) & _
                                    "发票号码：" & frmInternetSalesInvoice.sInvoiceNo & Space(4) & Chr(13) & Chr(13) & _
                                    "请核对上面的发票代码及发票号码是否正确。如果有误，请手工输入。    " & Chr(13) & Chr(13) & _
                                    "核对过发票代码及发票号码后,请再按""打印""按钮继续打印发票。    ", "输入的发票号码已被使用！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txbInvoiceCode.Text = frmInternetSalesInvoice.sInvoiceCode
                    Me.txbInvoiceNo.Text = frmInternetSalesInvoice.sInvoiceNo
                    Me.txbInvoiceNo.Select() : Me.txbInvoiceNo.SelectAll()
                Case Else
                    MessageBox.Show("" & sTask & "发票时出现错误！下面是数据库的内部错误提示：    " & Chr(13) & Chr(13) & dtResult.Rows(0)("ErrorInfo").ToString & Space(4) & Chr(13) & Chr(13) & "请放弃" & sTask & "发票，在关闭窗口后重试。如果仍有问题，请联系软件开发人员。    ", "" & sTask & "发票失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    frmMain.statusText.Text = "" & sTask & "发票失败！"
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

            If frmMain.blUseInvoiceDevice Then '如果需要开票器 AndAlso Not My.Settings.IsInTraining
                Dim objInvoice As Object = CreateObject("PZHPrj.ComDLL"), sInvoiceInfo As String = ""
                If dtCancelled IsNot Nothing AndAlso dtCancelled.Rows.Count > 0 Then
                    frmMain.statusText.Text = "正在向开票器提交发票退票数据……"
                    frmMain.statusMain.Refresh()
                    Try
                        For Each drInvoice In frmInternetSalesInvoice.dtInvoice.Select("ReprintableAMT>0", "RowID")
                            If drInvoice("InvoiceCode").ToString <> "" AndAlso drInvoice("InvoiceNo").ToString <> "" Then
                                Me.GetAvailableInvoiceInfo()
                                If sInvoiceCode = "" Then
                                    frmMain.statusText.Text = "重打印发票失败！"
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

                                '发票主项（TrecordIn）
                                sInvoiceInfo = drInvoice("InvoiceCode").ToString & "," '原发票代码
                                sInvoiceInfo = sInvoiceInfo & drInvoice("InvoiceNo").ToString & "," '原发票号码
                                sInvoiceInfo = sInvoiceInfo & "," '受票方纳税识别号CustomerID，空白
                                sInvoiceInfo = sInvoiceInfo & drInvoice("InvoiceTitle").ToString & "," '受票方名称Customer
                                sInvoiceInfo = sInvoiceInfo & frmMain.sLoginUserRealName.Replace(",", " ") & "," '操作员UserName
                                sInvoiceInfo = sInvoiceInfo & Format(drInvoice("InvoiceAMT"), "0.00") & "," '总金额InvMoney
                                sInvoiceInfo = sInvoiceInfo & "0," '购物卡金额CardMoney
                                sInvoiceInfo = sInvoiceInfo & "0," '积分类金额JFMoney
                                sInvoiceInfo = sInvoiceInfo & "0," '其他可抵OtherMoney
                                sInvoiceInfo = sInvoiceInfo & "1," '经营项目个数ItemNum
                                '发票明细项（TInvoiceDTL）
                                sInvoiceInfo = sInvoiceInfo & "1," '商品编号ItemNO
                                sInvoiceInfo = sInvoiceInfo & drInvoice("InvoiceItem").ToString.Replace(",", " ") & "," '商品名称ItemName
                                sInvoiceInfo = sInvoiceInfo & "0," '数量小数位数DigitNum
                                sInvoiceInfo = sInvoiceInfo & Format(drInvoice("Quantity"), "0") & "," '数量Number
                                sInvoiceInfo = sInvoiceInfo & "01," '税目索引号TaxItemIndex
                                sInvoiceInfo = sInvoiceInfo & Format(drInvoice("InvoiceAMT") / drInvoice("Quantity"), "0.00") & "," '商品单价Price
                                sInvoiceInfo = sInvoiceInfo & Format(drInvoice("InvoiceAMT"), "0.00") & "," '商品金额Money
                                sInvoiceInfo = sInvoiceInfo '商品单位Units

                                sResult = objInvoice.UntreadaInv(sInvoiceInfo)
                                If sResult.IndexOf("0") = 0 Then
                                    Me.GetPrintedInvoiceInfo(sResult)
                                    sResult = objInvoice.SendData()
                                    If sResult <> "0" Then blSentDataFailure = True
                                    With dtPrintItem.Rows
                                        .Clear()
                                        .Add(1, drInvoice("InvoiceCode").ToString & " " & drInvoice("InvoiceNo").ToString & IIf(My.Settings.IsInTraining, " （培训使用，非有效发票！）", "")) '发票抬头
                                        .Add(2, drInvoice("InvoiceItem").ToString) '发票品项
                                        .Add(3, Format(drInvoice("Quantity"), "#,0")) '计量数量
                                        .Add(4, "-" & Format(drInvoice("InvoiceAMT") / drInvoice("Quantity"), "#,0.00")) '计量单价
                                        .Add(5, "-" & Format(drInvoice("InvoiceAMT"), "#,0.00")) '发票金额
                                        .Add(6, "（退）" & CapitalDigits.CapitalRMB(drInvoice("InvoiceAMT"))) '大写金额
                                        .Add(7, sPaymentTerm) '付款方式
                                        .Add(8, frmMain.sLoginUserRealName) '经手人
                                        .Add(9, sPrintedTime.Substring(0, 10)) '开票日期
                                        .Add(10, "订单号：" & frmInternetSalesInvoice.oair.OrderAllInfoData.BillNo.Replace(" ", "") & IIf(drInvoice("RowID") = 1 AndAlso drInvoice("InvoiceAMT") = dmTotalPayment, "", "-" & drInvoice("RowID").ToString)) '家乐福小票号（含标题）
                                        .Add(11, "") '购买统计信息（含标题）
                                        .Add(12, "") '折扣金额
                                        .Add(13, "-" & Format(drInvoice("InvoiceAMT"), "#,0.00")) '实付金额
                                    End With
                                    dtPrintItem.AcceptChanges()
                                    sResult = Me.FinalPrinting(drInvoice("RowID").ToString)
                                    If sResult <> "OK" Then
                                        MessageBox.Show("打印发票退票时发生如下错误：    " & Chr(13) & Chr(13) & sResult & "    " & Chr(13) & Chr(13) & "请在检查发票打印机后重试。    ", "打印发票退票出错！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                        sResult = ""
                                    End If
                                ElseIf sResult <> "45" Then '已取消
                                    MessageBox.Show("向开票器提交发票退票数据时出错（错误代码：" & sResult & "）！    " & Chr(13) & Chr(13) & "请在检查开票器后重试。    ", "向开票器提交发票退票数据出错！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    sResult = ""
                                End If

                                If sResult = "" Then Exit For
                            Else
                                sResult = "OK"
                            End If
                        Next
                    Catch ex As Exception
                        MessageBox.Show("向开票器提交发票退票数据时出现错误，下面是具体的错误提示：    " & Chr(13) & Chr(13) & ex.Message & Space(4), "向开票器提交发票退票数据出错！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        sResult = ""
                    End Try

                    If sResult = "" Then
                        frmMain.statusText.Text = "重打印发票失败！"
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

                frmMain.statusText.Text = "正在向开票器提交新发票数据……"
                frmMain.statusMain.Refresh()

                Try
                    Me.GetAvailableInvoiceInfo()
                    If sInvoiceCode = "" Then
                        frmMain.statusText.Text = sTask & "发票失败！"
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

                    '发票主项（TrecordIn）
                    sInvoiceInfo = "," '受票方纳税识别号CustomerID，空白
                    sInvoiceInfo = sInvoiceInfo & Me.txbInvoiceTitle.Text & "," '受票方名称Customer
                    sInvoiceInfo = sInvoiceInfo & frmMain.sLoginUserRealName.Replace(",", " ") & "," '操作员UserName
                    sInvoiceInfo = sInvoiceInfo & Format(CDec(sRealAMT.Trim), "0.00") & "," '总金额InvMoney
                    sInvoiceInfo = sInvoiceInfo & "0," '购物卡金额CardMoney
                    sInvoiceInfo = sInvoiceInfo & "0," '积分类金额JFMoney
                    sInvoiceInfo = sInvoiceInfo & "0," '其他可抵OtherMoney
                    sInvoiceInfo = sInvoiceInfo & "1," '经营项目个数ItemNum
                    '发票明细项（TInvoiceDTL）
                    sInvoiceInfo = sInvoiceInfo & "1," '商品编号ItemNO
                    sInvoiceInfo = sInvoiceInfo & sInvoiceItem & "," '商品名称ItemName
                    sInvoiceInfo = sInvoiceInfo & "0," '数量小数位数DigitNum
                    sInvoiceInfo = sInvoiceInfo & Format(Me.nudQTY.Value, "0") & "," '数量Number
                    sInvoiceInfo = sInvoiceInfo & "01," '税目索引号TaxItemIndex
                    sInvoiceInfo = sInvoiceInfo & Format(CDec(sRealAMT.Trim) / Me.nudQTY.Value, "0.00") & "," '商品单价Price
                    sInvoiceInfo = sInvoiceInfo & Format(CDec(sRealAMT.Trim), "0.00") & "," '商品金额Money
                    sInvoiceInfo = sInvoiceInfo '商品单位Units

                    sResult = objInvoice.WriteRecord(sInvoiceInfo)
                    If sResult.IndexOf("0") = 0 Then
                        Me.GetPrintedInvoiceInfo(sResult)
                        sResult = objInvoice.SendData()
                        If sResult <> "0" Then blSentDataFailure = True
                    Else
                        MessageBox.Show("向开票器提交新发票数据时出错（错误代码：" & sResult & "）！    " & Chr(13) & Chr(13) & "请在检查开票器后重试。    ", "向开票器提交新发票数据出错！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        sResult = ""
                    End If
                Catch ex As Exception
                    MessageBox.Show("向开票器提交新发票数据时出现错误，下面是具体的错误提示：    " & Chr(13) & Chr(13) & ex.Message & Space(4), "向开票器提交新发票数据出错！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    sResult = ""
                End Try

                objInvoice = Nothing

                If sResult = "" Then
                    frmMain.statusText.Text = sTask & "发票失败！"
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
                .Add(1, Me.txbInvoiceTitle.Text & IIf(My.Settings.IsInTraining, " （培训使用，非有效发票！）", "")) '发票抬头
                .Add(2, sInvoiceItem) '发票品项
                .Add(3, Format(Me.nudQTY.Value, "#,0")) '计量数量
                .Add(4, Format(CDec(sTotalAMT.Trim) / Me.nudQTY.Value, "#,0.00")) '计量单价
                .Add(5, sTotalAMT) '发票金额
                .Add(6, CapitalDigits.CapitalRMB(dmInvoiceAMT)) '大写金额
                .Add(7, sPaymentTerm) '付款方式
                .Add(8, frmMain.sLoginUserRealName) '经手人
                .Add(9, Format(dtResult.Rows(0)("PrintedTime"), "yyyy-MM-dd")) '开票日期
                .Add(10, "订单号：" & frmInternetSalesInvoice.oair.OrderAllInfoData.BillNo.Replace(" ", "") & IIf(Me.dgvInvoice.RowCount = 0 AndAlso dmInvoiceAMT = dmTotalPayment, "", "-" & drNew("RowID").ToString)) '家乐福小票号（含标题）
                .Add(11, sSummaryInfo) '购买统计信息（含标题）
                .Add(12, sRebateAMT) '折扣金额
                .Add(13, sRealAMT) '实付金额
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
                        Me.btnGetNewInvoiceNo.Text = "10秒后获取下一个可用号码"
                        Me.btnGetNewInvoiceNo.Enabled = False
                    End If
                    Me.newInvoiceNoTimer.Enabled = True
                End If

                frmMain.statusText.Text = "已经将发票" & sTask & "到""" & My.Settings.InvoicePrinter & """。"
                blNeedResetInfo = True
            Else
                MessageBox.Show("" & sTask & "发票时发生如下错误：    " & Chr(13) & Chr(13) & sResult & "    " & Chr(13) & Chr(13) & "请在关闭发票窗口后重试。    ", sTask & "发票出错！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Try
                    DB.ModifyTable(sRestoreSQL)
                Catch
                End Try
                dtNew.Dispose() : dtNew = Nothing
                If dtCancelled IsNot Nothing Then dtCancelled.Dispose() : dtCancelled = Nothing
                drInvoice = Nothing : drNew = Nothing : drCancelled = Nothing
                dtPrintItem.Dispose() : dtPrintItem = Nothing
                DB.Close() : dmReprintableAMT = 0 : Me.Cursor = Cursors.Default
                frmMain.statusText.Text = "" & sTask & "发票出错！"
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

            drNew("InvoiceState") = "正常" : drNew("ReprintableAMT") = 0 : drNew("PrinterName") = frmMain.sLoginUserRealName : drNew("PrintedTime") = dtResult.Rows(0)("PrintedTime") : drNew("Reprint") = "取消后重打印"
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
                    drInvoice("InvoiceState") = "已被取消"
                    drInvoice("ReprintableAMT") = drCancelled("ReprintableAMT")
                    If drInvoice("ReprintableAMT") = 0 Then
                        drInvoice("Remarks") = DBNull.Value
                    ElseIf DateAdd(DateInterval.Second, frmInternetSalesInvoice.iDifferenceSeconds, drInvoice("ReprintableTime")) < Now() Then
                        drInvoice("Remarks") = "剩余金额：" & Format(drInvoice("ReprintableAMT"), "#,0.00").Replace(".00", "") & "（已超过可重打印时限！）"
                        dmReprintableAMT = dmReprintableAMT - drInvoice("ReprintableAMT")
                    Else
                        drInvoice("Remarks") = "剩余金额：" & Format(drInvoice("ReprintableAMT"), "#,0.00").Replace(".00", "") & "；可重打印时限：" & Format(drInvoice("ReprintableTime"), "HH:mm:ss") & "。"
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
                Me.chbPrintLine.Visible = ("|21|272|".IndexOf(frmInternetSalesInvoice.sCityID) > 0) '上海及测试城市
            End If
        End If

        Me.btnPrintInvoice.Text = IIf(dmReprintableAMT = 0, "打印发票(&I)", "重打印发票(&I)")
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

        If blSentDataFailure Then MessageBox.Show("发票已打印，但未能将数据及时传送到税务局服务器！    " & Chr(13) & Chr(13) & "如多次发生类似故障，请联系当地IT检查外网网络设置。    ", "未将发票数据及时传送到税务局服务器！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

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
                '    MessageBox.Show("因为向税务局服务器上传上一批发票验旧数据时出错（错误代码：" & sResult & "）而无法获取新的发票号码！    ", "获取新的发票号码过程被中断！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
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
                MessageBox.Show("无法从开票器获取当前可用的发票号码！错误代码：" & sInvoiceCode & "。    ", "获取当前可用的发票号码失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                sInvoiceCode = ""
            Else
                sInvoiceNo = sInvoiceCode.Substring(sInvoiceCode.LastIndexOf(",") + 1)
                sInvoiceCode = sInvoiceCode.Substring(sInvoiceCode.IndexOf(",") + 1, 12)
            End If
        Catch ex As Exception
            MessageBox.Show("从开票器获取当前可用的发票号码时出错！下面是具体的错误提示：    " & Chr(13) & Chr(13) & ex.Message & Space(4), "获取当前可用的发票号码失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
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
            Invoice.PrintController = PrintStandard '不出现打印窗口
            Invoice.DocumentName = "Invoice_" & frmInternetSalesInvoice.oair.OrderAllInfoData.BillNo.Replace(" ", "") & "-" & sRowID
            If "|21|272|".IndexOf("|" & frmInternetSalesInvoice.sCityID & "|") > -1 Then '上海''''
                If Me.chbPrintLine.Checked Then
                    AddHandler Invoice.PrintPage, AddressOf InvoiceSHWithLine_PrintPage
                Else
                    AddHandler Invoice.PrintPage, AddressOf InvoiceSHWithoutLine_PrintPage
                End If
                'modify code 041:start-------------------------------------------------------------------------
                'ElseIf "|24|25|".IndexOf("|" & frmInternetSalesInvoice.sCityID & "|") > -1 Then '重庆/成都/测试城市272|''''''
            ElseIf "|24|25|304|".IndexOf("|" & frmInternetSalesInvoice.sCityID & "|") > -1 Then '重庆/成都/资阳/测试城市272|''''''
                'modify code 041:end-------------------------------------------------------------------------
                AddHandler Invoice.PrintPage, AddressOf InvoiceCQ_PrintPage
            ElseIf "|27|".IndexOf("|" & frmInternetSalesInvoice.sCityID & "|") > -1 Then '武汉
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
            drawFont = New Font("宋体", drItem("FontSize"))
            e.Graphics.DrawString(dtPrintItem.Rows.Find(drItem("ItemID"))("PrintText").ToString, drawFont, drawBrush, drItem("X"), drItem("Y"), drawFormat)
        Next

        drawFont = New Font("宋体", frmInternetSalesInvoice.dtInvoiceLayout.Rows(5)("FontSize"))
        Dim x As Integer = frmInternetSalesInvoice.dtInvoiceLayout.Rows(4)("X"), y As Integer = frmInternetSalesInvoice.dtInvoiceLayout.Rows(4)("Y") '发票金额的坐标
        y += 5
        If dtPrintItem.Rows.Find(12)("PrintText").ToString.Trim <> "" Then
            drawFormat.Alignment = StringAlignment.Far
            e.Graphics.DrawString("折扣： ", drawFont, drawBrush, x, y, drawFormat)
            drawFormat.Alignment = StringAlignment.Near
            e.Graphics.DrawString(dtPrintItem.Rows.Find(12)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        End If
        y += 5
        drawFormat.Alignment = StringAlignment.Far
        e.Graphics.DrawString("实付金额： ", drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Near
        e.Graphics.DrawString(dtPrintItem.Rows.Find(13)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)

        If sInvoiceSecurityCode <> "" Then
            x -= 40 : y += 8
            e.Graphics.DrawString("防伪码： " & sInvoiceSecurityCode, drawFont, drawBrush, x, y, drawFormat)
        End If

        e.HasMorePages = False
    End Sub

    Private Sub InvoiceSHWithLine_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        e.Graphics.PageUnit = GraphicsUnit.Millimeter

        Dim drawFont As New Font("宋体", 10), drawBrush As New SolidBrush(Color.Black), drawFormat As New StringFormat, blackPen As New Pen(Color.Black, 0.2)
        drawFormat.FormatFlags = StringFormatFlags.NoWrap
        Dim x As Integer = frmInternetSalesInvoice.dtInvoiceLayout.Rows(0)("X"), y As Integer = frmInternetSalesInvoice.dtInvoiceLayout.Rows(0)("Y")

        If My.Settings.IsInTraining Then
            drawFont = New Font("宋体", 12, FontStyle.Bold)
            x -= 6 : y -= 18
            e.Graphics.DrawString("（培训使用，非有效发票！）", drawFont, drawBrush, x, y, drawFormat)
            drawFont = New Font("宋体", 10)
            x = frmInternetSalesInvoice.dtInvoiceLayout.Rows(0)("X") : y = frmInternetSalesInvoice.dtInvoiceLayout.Rows(0)("Y")
        End If

        'x -= 3 : y -= 3
        'e.Graphics.DrawRectangle(blackPen, New Rectangle(x, y, 170, 96))
        'x += 3 : y += 3

        x += 13 : y -= 8 '开票日期
        e.Graphics.DrawString(dtPrintItem.Rows.Find(9)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x += 56 '行业分类
        e.Graphics.DrawString("商业", drawFont, drawBrush, x, y, drawFormat)
        x += 98 '家乐福小票号
        drawFormat.Alignment = StringAlignment.Far
        e.Graphics.DrawString(dtPrintItem.Rows.Find(10)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x -= 169 : y += 6 '付款单位名称
        drawFormat.Alignment = StringAlignment.Near
        e.Graphics.DrawString("付款单位名称：" & dtPrintItem.Rows.Find(1)("PrintText").ToString.Replace("（培训使用，非有效发票！）", ""), drawFont, drawBrush, x, y, drawFormat)
        x += 113 '付款单位税号
        e.Graphics.DrawString("付款单位税号：", drawFont, drawBrush, x, y, drawFormat)
        If Me.chbPrintLine.Checked Then e.Graphics.DrawLine(blackPen, x - 114, y + 4, x - 114 + 170, y + 4)
        x -= 113 : y += 5 '收款单位名称
        e.Graphics.DrawString("收款单位名称：" & sCarrefourName, drawFont, drawBrush, x, y, drawFormat)
        x += 113 '收款单位税号
        e.Graphics.DrawString("收款单位税号：" & sReceiverTaxNo, drawFont, drawBrush, x, y, drawFormat)
        If Me.chbPrintLine.Checked Then e.Graphics.DrawLine(blackPen, x - 114, y + 4, x - 114 + 170, y + 4)
        drawFormat.Alignment = StringAlignment.Center
        x -= 113 : y += 5 '标题“商品编号”
        e.Graphics.DrawString("商品编号", drawFont, drawBrush, New RectangleF(x, y, 19, 5), drawFormat)
        If Me.chbPrintLine.Checked Then e.Graphics.DrawLine(blackPen, x + 19, y - 1, x + 19, y - 1 + 55)
        x += 19 '标题“商品名称”
        e.Graphics.DrawString("商 品 名 称", drawFont, drawBrush, New RectangleF(x, y, 55, 5), drawFormat)
        If Me.chbPrintLine.Checked Then e.Graphics.DrawLine(blackPen, x + 55, y - 1, x + 55, y - 1 + 55)
        x += 55 '标题“单位”
        e.Graphics.DrawString("单 位", drawFont, drawBrush, New RectangleF(x, y, 15, 5), drawFormat)
        If Me.chbPrintLine.Checked Then e.Graphics.DrawLine(blackPen, x + 15, y - 1, x + 15, y - 1 + 55)
        x += 15 '标题“数量”
        e.Graphics.DrawString("数 量", drawFont, drawBrush, New RectangleF(x, y, 15, 5), drawFormat)
        If Me.chbPrintLine.Checked Then e.Graphics.DrawLine(blackPen, x + 15, y - 1, x + 15, y - 1 + 55)
        x += 15 '标题“单价”
        e.Graphics.DrawString("单 价", drawFont, drawBrush, New RectangleF(x, y, 30, 5), drawFormat)
        If Me.chbPrintLine.Checked Then e.Graphics.DrawLine(blackPen, x + 30, y - 1, x + 30, y - 1 + 55)
        x += 30 '标题“金额”
        e.Graphics.DrawString("金 额", drawFont, drawBrush, New RectangleF(x, y, 35, 5), drawFormat)
        If Me.chbPrintLine.Checked Then e.Graphics.DrawLine(blackPen, x - 135, y + 4, x - 135 + 170, y + 4)
        drawFormat.Alignment = StringAlignment.Near
        y += 5 : x -= 115 '发票品项
        e.Graphics.DrawString(dtPrintItem.Rows.Find(2)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Far
        x += 85 '数量
        e.Graphics.DrawString(dtPrintItem.Rows.Find(3)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x += 30 '单价
        e.Graphics.DrawString(dtPrintItem.Rows.Find(4)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x += 35 '总价
        e.Graphics.DrawString(dtPrintItem.Rows.Find(5)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        y += 5 : x -= 95 '折扣
        If dtPrintItem.Rows.Find(12)("PrintText").ToString.Trim <> "" Then e.Graphics.DrawString("折扣", drawFont, drawBrush, x, y, drawFormat)
        x += 95 '折扣金额
        e.Graphics.DrawString(dtPrintItem.Rows.Find(12)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        y += 5 : x -= 95 '实付金额
        e.Graphics.DrawString("实付金额", drawFont, drawBrush, x, y, drawFormat)
        x += 95 '实付金额
        e.Graphics.DrawString(dtPrintItem.Rows.Find(13)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        If Me.chbPrintLine.Checked Then e.Graphics.DrawLine(blackPen, x - 170, y + 39, x - 170 + 170, y + 39)
        drawFormat.Alignment = StringAlignment.Near
        x -= 169 : y += 40 '大写金额
        e.Graphics.DrawString("合计金额大写（人民币）：" & dtPrintItem.Rows.Find(6)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Far
        x += 169 '小写金额
        e.Graphics.DrawString("合计金额小写：" & dtPrintItem.Rows.Find(13)("PrintText").ToString.Trim, drawFont, drawBrush, x, y, drawFormat)
        If Me.chbPrintLine.Checked Then e.Graphics.DrawLine(blackPen, x - 170, y + 4, x - 170 + 170, y + 4)
        drawFormat.Alignment = StringAlignment.Near
        x -= 169 : y += 5
        e.Graphics.DrawString("备", drawFont, drawBrush, x, y, drawFormat)
        y += 15
        e.Graphics.DrawString("注", drawFont, drawBrush, x, y, drawFormat)
        If Me.chbPrintLine.Checked Then e.Graphics.DrawLine(blackPen, x + 5, y - 16, x + 5, y - 16 + 20)
        x += 6 : y -= 8 '付款方式
        If sInvoiceSecurityCode = "" Then
            e.Graphics.DrawString("付款方式：" & dtPrintItem.Rows.Find(7)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        Else
            e.Graphics.DrawString("付款方式：" & dtPrintItem.Rows.Find(7)("PrintText").ToString & "    防伪码：" & sInvoiceSecurityCode, drawFont, drawBrush, x, y, drawFormat)
        End If
        x += 109 : y -= 7
        e.Graphics.DrawString("机", drawFont, drawBrush, x, y, drawFormat)
        y += 5
        e.Graphics.DrawString("打", drawFont, drawBrush, x, y, drawFormat)
        y += 5
        e.Graphics.DrawString("信", drawFont, drawBrush, x, y, drawFormat)
        y += 5
        e.Graphics.DrawString("息", drawFont, drawBrush, x, y, drawFormat)
        x += 6 : y -= 11
        e.Graphics.DrawString("发票代码：" & sInvoiceCode, drawFont, drawBrush, x, y, drawFormat)
        y += 7
        e.Graphics.DrawString("发票号码：" & sInvoiceNo, drawFont, drawBrush, x, y, drawFormat)
        x -= 121 : y += 9
        If Me.chbPrintLine.Checked Then
            e.Graphics.DrawLine(blackPen, x + 114, y - 21, x + 114, y - 21 + 20)
            e.Graphics.DrawLine(blackPen, x + 114 + 6, y - 21, x + 114 + 6, y - 21 + 20)
            e.Graphics.DrawLine(blackPen, x - 1, y - 1, x - 1 + 170, y - 1)
        End If

        e.Graphics.DrawString("开票单位（盖章）：", drawFont, drawBrush, x, y, drawFormat)
        x += 168
        drawFormat.Alignment = StringAlignment.Far
        e.Graphics.DrawString("开票门店：" & frmMain.dtLoginStructure.Rows.Find(frmInternetSalesInvoice.sStoreID)("AreaName").ToString.Substring(4) & "    开票人：" & frmMain.sLoginUserRealName, drawFont, drawBrush, x, y, drawFormat)

        e.HasMorePages = False
    End Sub

    Private Sub InvoiceSHWithoutLine_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
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
        e.Graphics.DrawString(dtPrintItem.Rows.Find(9)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x += 56 '行业分类
        e.Graphics.DrawString("商业", drawFont, drawBrush, x, y, drawFormat)
        x += 98 '家乐福小票号
        drawFormat.Alignment = StringAlignment.Far
        e.Graphics.DrawString(dtPrintItem.Rows.Find(10)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x -= 167 : y += 8 '付款单位名称
        drawFormat.Alignment = StringAlignment.Near
        e.Graphics.DrawString("付款单位名称：" & dtPrintItem.Rows.Find(1)("PrintText").ToString.Replace("（培训使用，非有效发票！）", ""), drawFont, drawBrush, x, y, drawFormat)
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
        e.Graphics.DrawString(dtPrintItem.Rows.Find(2)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Center
        x += 79 '数量
        e.Graphics.DrawString(dtPrintItem.Rows.Find(3)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x += 25 '单价
        e.Graphics.DrawString(dtPrintItem.Rows.Find(4)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x += 25 '总价
        e.Graphics.DrawString(dtPrintItem.Rows.Find(5)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Near
        y += 5 : x -= 18 '折扣
        drawFormat.Alignment = StringAlignment.Far
        If dtPrintItem.Rows.Find(12)("PrintText").ToString.Trim <> "" Then e.Graphics.DrawString("折扣：", drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Center
        x += 18 '折扣金额
        drawFormat.Alignment = StringAlignment.Center
        e.Graphics.DrawString(dtPrintItem.Rows.Find(12)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        y += 5 : x -= 18 '实付金额
        drawFormat.Alignment = StringAlignment.Far
        e.Graphics.DrawString("实付金额：", drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Center
        x += 18 '实付金额
        drawFormat.Alignment = StringAlignment.Center
        e.Graphics.DrawString(dtPrintItem.Rows.Find(13)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Near
        x -= 149 : y += 40 '大写金额
        e.Graphics.DrawString("合计金额大写（人民币）：" & dtPrintItem.Rows.Find(6)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Far
        x += 160 '小写金额
        e.Graphics.DrawString("合计金额小写：" & dtPrintItem.Rows.Find(13)("PrintText").ToString.Trim, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Near
        x -= 160 : y += 8 '开票门店、发票代码、发票号码
        If sInvoiceSecurityCode = "" Then
            e.Graphics.DrawString("开票门店：" & frmMain.dtLoginStructure.Rows.Find(frmInternetSalesInvoice.sStoreID)("AreaName").ToString.Substring(4) & "    发票代码：" & sInvoiceCode & "    发票号码：" & sInvoiceNo, drawFont, drawBrush, x, y, drawFormat)
        Else
            e.Graphics.DrawString("开票门店：" & frmMain.dtLoginStructure.Rows.Find(frmInternetSalesInvoice.sStoreID)("AreaName").ToString.Substring(4) & "    发票代码：" & sInvoiceCode & "    发票号码：" & sInvoiceNo & "    防伪码：" & sInvoiceSecurityCode, drawFont, drawBrush, x, y, drawFormat)
        End If
        y += 8 '开票人
        e.Graphics.DrawString("开票人：" & frmMain.sLoginUserRealName, drawFont, drawBrush, x, y, drawFormat)
        x += 35 '付款方式
        e.Graphics.DrawString("付款方式：" & dtPrintItem.Rows.Find(7)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x += 35 '标题“开票单位（盖章）”
        e.Graphics.DrawString("开票单位（盖章）：", drawFont, drawBrush, x, y, drawFormat)

        e.HasMorePages = False
    End Sub

    Private Sub InvoiceCQ_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
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
        e.Graphics.DrawString(dtPrintItem.Rows.Find(9)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x += 56 '行业分类
        e.Graphics.DrawString("商业", drawFont, drawBrush, x, y, drawFormat)
        x += 98 '家乐福小票号
        drawFormat.Alignment = StringAlignment.Far
        e.Graphics.DrawString(dtPrintItem.Rows.Find(10)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x -= 167 : y += 8 '付款单位名称
        drawFormat.Alignment = StringAlignment.Near
        e.Graphics.DrawString("付款单位名称：" & dtPrintItem.Rows.Find(1)("PrintText").ToString.Replace("（培训使用，非有效发票！）", ""), drawFont, drawBrush, x, y, drawFormat)
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
        e.Graphics.DrawString(dtPrintItem.Rows.Find(2)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Center
        x += 79 '数量
        e.Graphics.DrawString(dtPrintItem.Rows.Find(3)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x += 25 '单价
        e.Graphics.DrawString(dtPrintItem.Rows.Find(4)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x += 25 '总价
        e.Graphics.DrawString(dtPrintItem.Rows.Find(5)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Near
        y += 5 : x -= 18 '折扣
        drawFormat.Alignment = StringAlignment.Far
        If dtPrintItem.Rows.Find(12)("PrintText").ToString.Trim <> "" Then e.Graphics.DrawString("折扣：", drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Center
        x += 18 '折扣金额
        drawFormat.Alignment = StringAlignment.Center
        e.Graphics.DrawString(dtPrintItem.Rows.Find(12)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        y += 5 : x -= 18 '实付金额
        drawFormat.Alignment = StringAlignment.Far
        e.Graphics.DrawString("实付金额：", drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Center
        x += 18 '实付金额
        drawFormat.Alignment = StringAlignment.Center
        e.Graphics.DrawString(dtPrintItem.Rows.Find(13)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Near
        x -= 149 : y += 40 '大写金额
        e.Graphics.DrawString("合计金额大写（人民币）：" & dtPrintItem.Rows.Find(6)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Far
        x += 160 '小写金额
        e.Graphics.DrawString("合计金额小写：" & dtPrintItem.Rows.Find(13)("PrintText").ToString.Trim, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Near
        x -= 160 : y += 8 '发票代码、发票号码、防伪码
        If sInvoiceSecurityCode <> "" Then e.Graphics.DrawString("发票代码：" & sInvoiceCode & "    发票号码：" & sInvoiceNo & "    防伪码：" & sInvoiceSecurityCode, drawFont, drawBrush, x, y, drawFormat)
        y += 8 '开票人
        e.Graphics.DrawString("开票人：" & frmMain.sLoginUserRealName, drawFont, drawBrush, x, y, drawFormat)
        'modify code 042:start-------------------------------------------------------------------------
        'x += 35 '付款方式
        'e.Graphics.DrawString("付款方式：" & dtPrintItem.Rows.Find(7)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        'modify code 042:end-------------------------------------------------------------------------
        x += 35 '标题“开票单位（盖章）”
        e.Graphics.DrawString("开票单位（盖章）：", drawFont, drawBrush, x, y, drawFormat)

        e.HasMorePages = False
    End Sub

    Private Sub InvoiceWH_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
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
        e.Graphics.DrawString(dtPrintItem.Rows.Find(9)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x += 56 '行业分类
        e.Graphics.DrawString("商业", drawFont, drawBrush, x, y, drawFormat)
        x += 78 : y += 2 '家乐福小票号
        drawFormat.Alignment = StringAlignment.Far
        e.Graphics.DrawString(dtPrintItem.Rows.Find(10)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x -= 147 : y += 8 '付款单位名称
        drawFormat.Alignment = StringAlignment.Near
        e.Graphics.DrawString("付款单位名称：" & dtPrintItem.Rows.Find(1)("PrintText").ToString.Replace("（培训使用，非有效发票！）", ""), drawFont, drawBrush, x, y, drawFormat)
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
        e.Graphics.DrawString(dtPrintItem.Rows.Find(2)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Center
        x += 64 '数量
        e.Graphics.DrawString(dtPrintItem.Rows.Find(3)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x += 20 '单价
        e.Graphics.DrawString(dtPrintItem.Rows.Find(4)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x += 25 '总价
        e.Graphics.DrawString(dtPrintItem.Rows.Find(5)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Near
        y += 5 : x -= 18 '折扣
        drawFormat.Alignment = StringAlignment.Far
        If dtPrintItem.Rows.Find(12)("PrintText").ToString.Trim <> "" Then e.Graphics.DrawString("折扣：", drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Center
        x += 18 '折扣金额
        drawFormat.Alignment = StringAlignment.Center
        e.Graphics.DrawString(dtPrintItem.Rows.Find(12)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        y += 5 : x -= 18 '实付金额
        drawFormat.Alignment = StringAlignment.Far
        e.Graphics.DrawString("实付金额：", drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Center
        x += 18 '实付金额
        drawFormat.Alignment = StringAlignment.Center
        e.Graphics.DrawString(dtPrintItem.Rows.Find(13)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Near
        x -= 129 : y += 15 '大写金额
        e.Graphics.DrawString("合计金额大写（人民币）：" & dtPrintItem.Rows.Find(6)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Far
        x += 140 '小写金额
        e.Graphics.DrawString("合计金额小写：" & dtPrintItem.Rows.Find(13)("PrintText").ToString.Trim, drawFont, drawBrush, x, y, drawFormat)
        drawFormat.Alignment = StringAlignment.Near
        x -= 140 : y += 5 '开票人
        e.Graphics.DrawString("开票人：" & frmMain.sLoginUserRealName, drawFont, drawBrush, x, y, drawFormat)
        x += 35 '付款方式
        e.Graphics.DrawString("付款方式：" & dtPrintItem.Rows.Find(7)("PrintText").ToString, drawFont, drawBrush, x, y, drawFormat)
        x += 35 '标题“开票单位（盖章）”
        e.Graphics.DrawString("开票单位（盖章）：", drawFont, drawBrush, x, y, drawFormat)
        x -= 115 : y += 5 '发票代码、发票号码、防伪码
        If sInvoiceSecurityCode <> "" Then e.Graphics.DrawString("发票代码：" & sInvoiceCode & "    发票号码：" & sInvoiceNo & "    防伪码：" & sInvoiceSecurityCode, drawFont, drawBrush, x, y, drawFormat)

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