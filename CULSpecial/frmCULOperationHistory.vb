Public Class frmCULOperationHistory

    Private Sub frmCULOperationHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim iGridWidth As Integer = 0, iMaxGridHeight As Integer = 0, iAvailableGridHeight As Integer = 0
        For Each column As DataGridViewColumn In Me.dgvList.Columns
            If column.Visible Then iGridWidth += column.Width
        Next
        iGridWidth += IIf(ToolStripManager.VisualStylesEnabled, 2, 4)

        iMaxGridHeight = (IIf(Me.dgvList.RowCount < 7, 7, Me.dgvList.RowCount) + 1) * 24 + IIf(ToolStripManager.VisualStylesEnabled, 0, 2)
        If My.Computer.Screen.WorkingArea.Width < iGridWidth + 33 Then
            Me.Width = My.Computer.Screen.WorkingArea.Width
            iMaxGridHeight += 17
        Else
            Me.Width = iGridWidth + 33
        End If
        With Me.dgvList.Columns("OperationReason")
            .MinimumWidth = .Width
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        iAvailableGridHeight = My.Computer.Screen.WorkingArea.Height - 116
        If iMaxGridHeight < iAvailableGridHeight Then
            Me.Height = iMaxGridHeight + 116
        Else
            If My.Computer.Screen.WorkingArea.Width < iGridWidth + 30 Then iAvailableGridHeight -= 17
            iAvailableGridHeight = Int(iAvailableGridHeight / 24) * 24
            If My.Computer.Screen.WorkingArea.Width < iGridWidth + 30 Then iAvailableGridHeight += 17
            Me.Height = iAvailableGridHeight + 116
        End If
        If Me.dgvList.RowCount > Me.dgvList.DisplayedRowCount(False) Then Me.Width += 20

        Me.Location = New Point(Int((My.Computer.Screen.WorkingArea.Width - Me.Width) / 2), Int((My.Computer.Screen.WorkingArea.Height - Me.Height) / 2))

        Me.dgvList.Select()
        Me.txbCardNo.Select()
    End Sub

    Private Sub dgvList_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvList.Leave
        If Me.dgvList.CurrentRow IsNot Nothing Then Me.dgvList.CurrentRow.Selected = False
    End Sub

    Private Sub txbCardNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbCardNo.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter AndAlso Me.btnSearch.Enabled Then Me.btnSearch.PerformClick() : e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If Me.txbCardNo.SelectedText = Me.txbCardNo.Text Then Me.txbCardNo.Text = ""
            Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbCardNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbCardNo.TextChanged
        Me.lblCardError.Text = ""
        Me.btnSearch.Enabled = (Me.txbCardNo.Text.Trim <> "")
    End Sub

    Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If Me.txbCardNo.Text <> Me.txbCardNo.Text.Trim Then Me.txbCardNo.Text = Me.txbCardNo.Text.Trim
        Dim sCardNo As String = Me.txbCardNo.Text

        If Not IsNumeric(sCardNo) Then
            Me.lblCardError.Text = "（卡号只能由数字组成！）"
        ElseIf sCardNo.Length < 19 Then
            Me.lblCardError.Text = "（卡号位数不足 19 位！）"
        ElseIf sCardNo <> ShoppingCardNo.GetFullCardNo(sCardNo.Substring(0, 18)) Then
            Me.lblCardError.Text = "（卡号校验码错误！）"
        End If

        If Me.lblCardError.Text = "" Then
            Me.Cursor = Cursors.WaitCursor
            Dim blFound As Boolean = False
            If Me.Text.IndexOf("冻结/解冻") > -1 Then
                For Each drCard As DataGridViewRow In Me.dgvList.Rows
                    If drCard.Cells("StartCardNo").Value.ToString <= sCardNo AndAlso drCard.Cells("EndCardNo").Value.ToString >= sCardNo Then
                        blFound = True
                        Me.dgvList.Select()
                        drCard.Selected = True
                        Me.dgvList.FirstDisplayedScrollingRowIndex = drCard.Index
                        Exit For
                    End If
                Next
            Else '紧急扣款/礼品卡激活撤销/礼品卡离线激活
                For Each drCard As DataGridViewRow In Me.dgvList.Rows
                    If drCard.Cells("CardNo").Value.ToString = sCardNo Then
                        blFound = True
                        Me.dgvList.Select()
                        drCard.Selected = True
                        Me.dgvList.FirstDisplayedScrollingRowIndex = drCard.Index
                        Exit For
                    End If
                Next
            End If
            If Not blFound Then
                MessageBox.Show("未找到该卡号！    ", "未找到卡号！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.txbCardNo.Select()
                Me.txbCardNo.SelectAll()
            End If
            Me.Cursor = Cursors.Default
        Else
            Me.txbCardNo.Select()
            Me.txbCardNo.SelectAll()
        End If
    End Sub
End Class