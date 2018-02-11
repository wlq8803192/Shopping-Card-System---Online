Public Class frmUnconfirmedPayment

    Private blCanBrowseSalesBill As Boolean = True

    Private Sub frmCardCycle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        blCanBrowseSalesBill = (frmMain.dtAllowedRight.Select("RightName='SalesBillBrowse'").Length > 0)

        Dim iGridWidth As Integer = 0, iGridHeight As Integer = 0
        With Me.dgvList
            With .Columns(0)
                .Name = "SalesBillID"
                .Visible = False
            End With
            Dim linkColumn As New DataGridViewLinkColumn
            linkColumn.DataPropertyName = "SalesBillCode"
            .Columns.RemoveAt(1)
            .Columns.Insert(1, linkColumn)
            With .Columns(1)
                .Name = "SalesBillCode"
                .HeaderText = "销售单号"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 90
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
                iGridWidth = .Width
            End With
            With .Columns(2)
                .HeaderText = "付款方式"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 65
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
                iGridWidth += .Width
            End With
            With .Columns(3)
                .HeaderText = "付款单位"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                iGridWidth += .Width
            End With
            With .Columns(4)
                .HeaderText = "转账/支票号"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                iGridWidth += .Width
            End With
            With .Columns(5)
                .HeaderText = "金额"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,0.00"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                iGridWidth += .Width
            End With
        End With
        If Not ToolStripManager.VisualStylesEnabled Then
            iGridWidth += 4
        Else
            iGridWidth += 2
        End If

        If iGridWidth > My.Computer.Screen.WorkingArea.Width - 32 Then
            iGridWidth = My.Computer.Screen.WorkingArea.Width - 32
            iGridHeight = 17
        End If
        Dim iMaxDisplayRows As Integer = Int((My.Computer.Screen.WorkingArea.Height - 108 - iGridHeight - IIf(Not ToolStripManager.VisualStylesEnabled, 2, 0)) / 24) - 1
        If iMaxDisplayRows < Me.dgvList.RowCount Then
            If iGridHeight = 0 Then iGridWidth += 18
            iGridHeight += (iMaxDisplayRows + 1) * 24
        Else
            iGridHeight += (Me.dgvList.RowCount + 1) * 24
        End If
        If Not ToolStripManager.VisualStylesEnabled Then iGridHeight += 2

        If Me.dgvList.CurrentRow IsNot Nothing Then Me.dgvList.CurrentRow.Selected = False

        Me.Size = New Size(iGridWidth + 32, iGridHeight + 108)
        Me.Location = New Point((My.Computer.Screen.WorkingArea.Width - Me.Width) / 2, (My.Computer.Screen.WorkingArea.Height - Me.Height) / 2)
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub dgvList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvList.CellContentClick
        If Me.dgvList.Columns(e.ColumnIndex).Name <> "SalesBillCode" OrElse e.RowIndex = -1 Then Return

        If blCanBrowseSalesBill Then
            If frmMain.dtAllowedRight.Select("RightName='SalesBillBrowse'").Length = 0 Then
                MessageBox.Show("对不起！您没有浏览销售单的权限。    " & Chr(13) & "Sorry, you have no right to browse sales bill.    ", "您无权浏览销售单 No right to browse sales bill!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                blCanBrowseSalesBill = False
                frmMain.statusText.Text = "对不起！您没有浏览销售单的权限。"
            Else
                With frmSelling
                    If .IsHandleCreated Then
                        .Activate()
                        .WindowState = FormWindowState.Maximized
                        If .sSalesBillID <> Me.dgvList("SalesBillID", Me.dgvList.CurrentRow.Index).Value.ToString Then
                            If .blIsChanged Then
                                Dim bAnswer As DialogResult = MessageBox.Show("是否在打开销售单之前，先保存当前销售单？    ", "当前销售单未保存！", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                                If bAnswer = Windows.Forms.DialogResult.Cancel OrElse (bAnswer = Windows.Forms.DialogResult.Yes AndAlso Not .SaveChanges()) Then
                                    Me.Activate()
                                    frmMain.statusText.Text = "因为存在未保存销售单，所以不能打开销售单。"
                                    Return
                                End If
                            End If
                            .sSalesBillID = Me.dgvList("SalesBillID", Me.dgvList.CurrentRow.Index).Value.ToString
                            .LoadSalesBill()
                        End If
                    Else
                        Me.Cursor = Cursors.WaitCursor
                        frmMain.statusText.Text = "正在打开销售单……"
                        frmMain.statusMain.Refresh()

                        .sSalesBillID = Me.dgvList("SalesBillID", Me.dgvList.CurrentRow.Index).Value.ToString
                        .Show()
                        If .IsHandleCreated Then
                            .MdiParent = frmMain
                            .WindowState = FormWindowState.Maximized
                            .Activate()
                        End If

                        If frmMain.statusText.Text.IndexOf("……") > -1 Then frmMain.statusText.Text = "就绪。"
                        Me.Cursor = Cursors.Default
                    End If

                    If .IsHandleCreated Then
                        If .dgvNormalCard.CurrentRow IsNot Nothing Then .dgvNormalCard.CurrentRow.Selected = False
                        If .dgvRebateCard.CurrentRow IsNot Nothing Then .dgvRebateCard.CurrentRow.Selected = False
                        If .dgvPayment.CurrentRow IsNot Nothing Then .dgvPayment.CurrentRow.Selected = False
                    End If

                    .btnOK.Enabled = False
                    .btnPrintTicket.Enabled = False
                    .btnPrintInvoice.Enabled = False
                    .btnViewActivation.Enabled = True
                    .btnNewSalesBill.Enabled = False
                End With
            End If
        Else
            frmMain.statusText.Text = "对不起！您没有浏览销售单的权限。"
        End If
    End Sub
End Class