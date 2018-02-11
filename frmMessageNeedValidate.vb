Public Class frmMessageNeedValidate

    Private dtList As DataTable

    Private Sub frmMessageNeedValidate_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'For Each dr As DataRow In dtList.Select("IsValidated=1")
        '    dr.Delete() : dr.AcceptChanges()
        'Next

        'If dtList.Rows.Count > 0 Then
        '    Dim iMessages As Int16 = dtList.Rows.Count
        '    If iMessages = 0 Then
        '        Me.lblTitle.Text = "No sales bill need you to validate now."
        '    ElseIf iMessages = 1 Then
        '        Me.lblTitle.Text = "There is a sales bill wait you to validate. "
        '    Else
        '        Me.lblTitle.Text = "There are " & Format(iMessages, "#,0") & " sales bills wait you to validate. "
        '    End If
        '    Me.Hide()
        '    e.Cancel = True
        'Else
        '    frmMain.notifyMessage.Visible = False
        'End If
    End Sub

    Private Sub frmMessageNeedValidate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then Me.Close() : Return

        dtList = DB.GetDataTable("Exec GetMessageNormalRebateNeedValidate " & frmMain.sLoginUserID & "," & frmMain.sLoginRoleID)
        DB.Close()
        If dtList Is Nothing OrElse dtList.Rows.Count = 0 Then Me.Close() : Return
        dtList.PrimaryKey = New DataColumn() {dtList.Columns("SalesBillID")}

        Dim iMessages As Int16 = dtList.Rows.Count, iWidth As Integer, iHeight As Integer
        Me.lblTitle.Text = IIf(iMessages = 1, "There is a sales bill wait you to validate. ", "There are " & Format(iMessages, "#,0") & " sales bills wait you to validate. ")
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
                .HeaderText = "Discount AMT"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,0.00"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                iWidth += .Width
            End With
            With .Columns(3)
                .HeaderText = "Discount Rate"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,0.0 %"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                iWidth += .Width
            End With
            Dim buttonColumn As New DataGridViewButtonColumn
            With buttonColumn
                .DataPropertyName = "Operation"
                .DefaultCellStyle.ForeColor = SystemColors.ControlText
                .DefaultCellStyle.SelectionForeColor = SystemColors.ControlText
                .DefaultCellStyle.BackColor = SystemColors.Window
                .DefaultCellStyle.SelectionBackColor = SystemColors.Window
                .DefaultCellStyle.Padding = New Padding(1)
            End With
            .Columns.RemoveAt(4)
            .Columns.Insert(4, buttonColumn)
            With .Columns(4)
                .HeaderText = "Operation"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.BackColor = SystemColors.Window
                .DefaultCellStyle.SelectionBackColor = SystemColors.Window
                .Resizable = DataGridViewTriState.False
                iWidth += .Width
            End With
            .Columns(5).Visible = False
            .Columns(6).Visible = False
            .Columns(7).Visible = False

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
        Me.Size = New Size(iWidth + 36 + IIf(ToolStripManager.VisualStylesEnabled, 2, 4), iHeight + 110 + IIf(ToolStripManager.VisualStylesEnabled, 0, 2))
        Me.dgvList.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'Me.Location = New Point(My.Computer.Screen.WorkingArea.Width - Me.Width, My.Computer.Screen.WorkingArea.Height - Me.Height)
    End Sub

    Private Sub dgvList_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvList.CellClick
        'Me.theTimer.Enabled = False
        'Me.theTimer.Enabled = True
    End Sub

    Private Sub dgvList_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvList.CellContentClick
        If e.RowIndex = -1 OrElse (Me.dgvList.Columns(e.ColumnIndex).Name <> "SalesBillCode" AndAlso Me.dgvList.Columns(e.ColumnIndex).Name <> "Operation") Then Return
        Dim sSalesBillID As String = Me.dgvList("SalesBillID", e.RowIndex).Value.ToString, drSalesBill As DataRow = dtList.Rows.Find(sSalesBillID), blIsReaded As Boolean = drSalesBill("IsReaded"), blIsValidated As Boolean = drSalesBill("IsValidated")
        If Me.dgvList.Columns(e.ColumnIndex).Name = "SalesBillCode" Then
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
                        blIsReaded = True
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
                        blIsReaded = True
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

            drSalesBill("IsReaded") = blIsReaded
            drSalesBill.AcceptChanges()
            If blIsReaded Then CType(Me.dgvList("SalesBillCode", e.RowIndex), DataGridViewLinkCell).LinkVisited = True
        ElseIf Not blIsValidated Then
            Me.Cursor = Cursors.WaitCursor
            Dim DB As New DataBase()
            DB.Open()
            If DB.IsConnected Then
                Dim dtResult As DataTable = DB.GetDataTable("Select * From SalesBillView Where SalesBillID=" & sSalesBillID), blCanDelete As Boolean = True
                If dtResult Is Nothing Then
                    frmMain.statusText.Text = "系统因在检索数据时出错而无法审核销售单返点。请联系软件开发人员。"
                    DB.Close() : Me.Cursor = Cursors.Default : Return
                End If

                If dtResult.Rows.Count = 0 Then
                    MessageBox.Show("The sales bill is not existing now!    ", " Sales bill is not existing!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    drSalesBill.Delete()
                    Dim iMessages As Int16 = dtList.Rows.Count
                    If iMessages = 0 Then
                        Me.lblTitle.Text = "No sales bill need you to validate now."
                    ElseIf iMessages = 1 Then
                        Me.lblTitle.Text = "There is a sales bill wait you to validate. "
                    Else
                        Me.lblTitle.Text = "There are " & Format(iMessages, "#,0") & " sales bills wait you to validate. "
                    End If
                ElseIf dtResult.Rows(0)("SalesBillState").ToString = "等待取消" Then
                    MessageBox.Show("This sales bill will be cancelled!    " & Chr(13) & Chr(13) & "So you don't need validate it.   ", "Sales bill had been cancelled!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    drSalesBill("RebateSalesAMT") = 0
                    drSalesBill("RebateRate") = 0
                    drSalesBill("IsValidated") = 1
                ElseIf dtResult.Rows(0)("RebateState").ToString = "没有返点" Then
                    MessageBox.Show("This sales bill had been cancelled normal discount!    ", "Normal discount had been cancelled!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    drSalesBill("RebateSalesAMT") = 0
                    drSalesBill("RebateRate") = 0
                    drSalesBill("IsValidated") = 1
                ElseIf dtResult.Rows(0)("RebateState").ToString = "不用审核" Then
                    MessageBox.Show("This sales bill don't need vailate now!    ", "Don't need validate!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    drSalesBill("RebateSalesAMT") = dtResult.Rows(0)("RebateSalesAMT")
                    drSalesBill("RebateRate") = dtResult.Rows(0)("RebateRate")
                    drSalesBill("IsValidated") = 1
                ElseIf dtResult.Rows(0)("RebateState").ToString = "审核成功" Then
                    MessageBox.Show("This sales bill had been validated by someone else!    ", "Had been validated!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    drSalesBill("RebateSalesAMT") = dtResult.Rows(0)("RebateSalesAMT")
                    drSalesBill("RebateRate") = dtResult.Rows(0)("RebateRate")
                    drSalesBill("IsValidated") = 1
                ElseIf dtResult.Rows(0)("NormalRebateApprovableRoleID").ToString <> frmMain.sLoginRoleID Then
                    MessageBox.Show("You have no right to validate this sales bill now!    ", "No right to validate!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    drSalesBill("RebateSalesAMT") = dtResult.Rows(0)("RebateSalesAMT")
                    drSalesBill("RebateRate") = dtResult.Rows(0)("RebateRate")
                    drSalesBill("IsValidated") = 1
                Else
                    drSalesBill("RebateSalesAMT") = dtResult.Rows(0)("RebateSalesAMT")
                    drSalesBill("RebateRate") = dtResult.Rows(0)("RebateRate")
                    Me.Hide()
                    With frmValidateDiscount
                        .currentSalesBill = dtResult.Copy.Rows(0)
                        If .ShowDialog = Windows.Forms.DialogResult.OK AndAlso .rdbOK.Checked Then
                            drSalesBill("IsValidated") = 1
                        Else
                            blCanDelete = False
                        End If
                    End With
                    Me.Show()
                End If

                If blCanDelete Then
                    Try
                        DB.ModifyTable("Delete From dbo.MessageNormalRebateNeedValidate Where SalesBillID=" & sSalesBillID)
                    Catch
                    End Try
                End If

                drSalesBill.AcceptChanges()
                dtResult.Dispose() : dtResult = Nothing
                If blIsReaded Then CType(Me.dgvList("SalesBillCode", e.RowIndex), DataGridViewLinkCell).LinkVisited = True
                If dtList.Select("IsValidated=0").Length = 0 Then Me.Close()
            Else
                frmMain.statusText.Text = "系统因连接不到数据库而无法审核销售单返点。请检查数据库连接。"
            End If
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub dgvList_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvList.CellFormatting
        If Me.dgvList.Columns(e.ColumnIndex).Name = "Operation" AndAlso Me.dgvList("IsValidated", e.RowIndex).Value Then
            e.CellStyle.Padding = New Padding(0, 24, 0, 0)
        End If
    End Sub

    Private Sub dgvList_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles dgvList.Scroll
        'Me.theTimer.Enabled = False
        'Me.theTimer.Enabled = True
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub theTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles theTimer.Tick
        'Me.theTimer.Enabled = False
        'Me.Close()
    End Sub
End Class