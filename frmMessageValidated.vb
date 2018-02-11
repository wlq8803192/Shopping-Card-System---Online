Public Class frmMessageValidated

    Private dtList As DataTable

    Private Sub frmMessageValidated_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'If dtList.Select("IsReaded=0").Length > 0 Then
        '    Me.Hide()
        '    e.Cancel = True
        'Else
        '    frmMain.notifyMessage.Visible = False
        'End If
    End Sub

    Private Sub frmMessageValidated_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then Me.Close() : Return

        dtList = DB.GetDataTable("Exec GetMessageNormalRebateValidated " & frmMain.sLoginUserID)
        DB.Close()
        If dtList Is Nothing OrElse dtList.Rows.Count = 0 Then Me.Close() : Return
        dtList.PrimaryKey = New DataColumn() {dtList.Columns("SalesBillID")}

        Dim iMessages As Int16 = dtList.Rows.Count, iWidth As Integer, iHeight As Integer
        Me.lblTitle.Text = IIf(iMessages = 1, "There is a sales bill had been validated. ", "There are " & Format(iMessages, "#,0") & " sales bills had been validated. ")
        With Me.dgvList
            .DataSource = dtList
            .Columns(0).Visible = False
            Dim linkColumn As New DataGridViewLinkColumn
            linkColumn.DataPropertyName = "SalesBillCode"
            .Columns.RemoveAt(1)
            .Columns.Insert(1, linkColumn)
            With .Columns(1)
                .HeaderText = "SalesBill Code"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Width = .Width + 2
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
                iWidth = .Width
            End With
            With .Columns(2)
                .HeaderText = "Validation Result"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Resizable = DataGridViewTriState.False
                iWidth += .Width
            End With
            With .Columns(3)
                .HeaderText = "Validation Time"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Width = .Width + 2
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Format = "yyyy\/MM\/dd HH:mm"
                .Resizable = DataGridViewTriState.False
                iWidth += .Width
            End With
            .Columns(4).Visible = False
            .Columns(5).Visible = False

            For Each column As DataGridViewColumn In Me.dgvList.Columns
                column.Name = dtList.Columns(column.Index).ColumnName
            Next
        End With
        If dtList.Rows.Count > 10 Then
            iWidth += 18
            iHeight = 11 * 24
        Else
            iHeight = (dtList.Rows.Count + 1) * 24
        End If

        'Me.Size = New Size(iWidth + 36 + IIf(ToolStripManager.VisualStylesEnabled, 2, 4), iHeight + 102 + IIf(ToolStripManager.VisualStylesEnabled, 0, 2))
        Me.Size = New Size(iWidth + 36 + IIf(ToolStripManager.VisualStylesEnabled, 2, 4), iHeight + 110 + IIf(ToolStripManager.VisualStylesEnabled, 0, 2)) '
        Me.dgvList.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'Me.Location = New Point(My.Computer.Screen.WorkingArea.Width - Me.Width, My.Computer.Screen.WorkingArea.Height - Me.Height)
    End Sub

    Private Sub dgvList_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvList.CellClick
        'Me.theTimer.Enabled = False
        'Me.theTimer.Enabled = True
    End Sub

    Private Sub dgvList_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvList.CellContentClick
        If e.RowIndex = -1 OrElse Me.dgvList.Columns(e.ColumnIndex).Name <> "SalesBillCode" Then Return
        Dim sSalesBillID As String = Me.dgvList("SalesBillID", e.RowIndex).Value.ToString, blIsRead As Boolean = Me.dgvList("IsReaded", e.RowIndex).Value, blIsOpened As Boolean = False
        If frmMain.WindowState = FormWindowState.Minimized Then frmMain.WindowState = FormWindowState.Maximized
        With frmSelling
            If .IsHandleCreated Then
                .Activate()
                .WindowState = FormWindowState.Maximized
                If .sSalesBillID <> sSalesBillID Then
                    If .blIsChanged Then
                        Dim bAnswer As DialogResult = MessageBox.Show("是否在打开销售单之前，先保存当前销售单？    ", "当前销售单未保存！", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                        If bAnswer = Windows.Forms.DialogResult.Cancel OrElse (bAnswer = Windows.Forms.DialogResult.Yes AndAlso Not .SaveChanges()) Then
                            Me.Activate()
                            frmMain.statusText.Text = "因为存在未保存销售单，所以不能打开销售单。"
                            Return
                        End If
                    End If
                    .sSalesBillID = sSalesBillID
                    .LoadSalesBill()
                    blIsOpened = True
                End If
            Else
                Me.Cursor = Cursors.WaitCursor
                frmMain.statusText.Text = "正在打开销售单……"
                frmMain.statusMain.Refresh()

                .sSalesBillID = sSalesBillID
                .Show()
                If .IsHandleCreated Then
                    .MdiParent = frmMain
                    .WindowState = FormWindowState.Maximized
                    .Activate()
                    blIsOpened = True
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

        If blIsOpened Then
            Me.dgvList("IsOpened", e.RowIndex).Value = True
        End If

        If My.Computer.Network.IsAvailable AndAlso Not blIsRead Then
            Me.Cursor = Cursors.WaitCursor
            Dim DB As New DataBase()
            DB.Open()
            If DB.IsConnected Then
                If DB.ModifyTable("Delete From MessageNormalRebateValidated Where SalesBillID=" & sSalesBillID) > -1 Then
                    Me.dgvList("IsReaded", e.RowIndex).Value = True
                    blIsRead = True
                    Me.dgvList.EndEdit()
                End If
                DB.Close()
            End If
            Me.Cursor = Cursors.Default
        End If

        dtList.Rows.Find(sSalesBillID).AcceptChanges()
        If blIsRead Then CType(Me.dgvList("SalesBillCode", e.RowIndex), DataGridViewLinkCell).LinkVisited = True
        If dtList.Select("IsOpened=0").Length = 0 Then Me.Close()
    End Sub

    Private Sub dgvList_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles dgvList.Scroll
        'Me.theTimer.Enabled = False
        'Me.theTimer.Enabled = True
    End Sub

    Private Sub btnSetRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetRead.Click
        Me.dgvList.Select()
        If Not My.Computer.Network.IsAvailable Then Return
        Me.Cursor = Cursors.WaitCursor

        Dim DB As New DataBase(), blError As Boolean = False
        DB.Open()
        If DB.IsConnected Then
            For Each dr As DataGridViewRow In Me.dgvList.Rows
                If Not dr.Cells("IsReaded").Value Then
                    CType(dr.Cells("SalesBillCode"), DataGridViewLinkCell).LinkVisited = True
                    Try
                        If DB.ModifyTable("Delete From MessageNormalRebateValidated Where SalesBillID=" & dr.Cells("SalesBillID").Value.ToString) > -1 Then
                            dr.Cells("IsReaded").Value = True
                        Else
                            blError = True
                        End If
                    Catch
                        blError = True
                    End Try
                End If
            Next
            DB.Close()
            Me.btnSetRead.Enabled = blError
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub theTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles theTimer.Tick
        'Me.theTimer.Enabled = False
        'Me.Close()
    End Sub
End Class