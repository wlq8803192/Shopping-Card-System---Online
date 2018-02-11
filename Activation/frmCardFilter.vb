Public Class frmCardFilter

    Public dtAvailable As DataTable, dtCard As DataTable, dmFaceValue As Decimal
    Private iBatchID As Int16 = 0, sStartCardNo As String, sEndCardNo As String, sInputStartCardNo As String = "", sInputEndCardNo As String = "", bMaxLength As Byte, sSameCode As String, dtInput As DataTable

    Private Sub frmCardFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Delete AndAlso Me.btnDeleteSelected.Enabled Then Me.btnDeleteSelected.PerformClick()
    End Sub

    Private Sub frmCardFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtAvailable.PrimaryKey = New DataColumn() {dtAvailable.Columns("CardNo")}
        dtCard = New DataTable
        dtCard.Columns.Add("RowID", System.Type.GetType("System.Int32"))
        dtCard.Columns.Add("CardNo", System.Type.GetType("System.String"))
        dtCard.Columns.Add("BatchID", System.Type.GetType("System.Int16"))
        dtCard.PrimaryKey = New DataColumn() {dtCard.Columns("CardNo")}
        dtCard.Columns("CardNo").AllowDBNull = True
        dtCard.DefaultView.Sort = "CardNo"
        For Each drCard As DataRow In dtAvailable.Select("Selected=1", "CardNo")
            dtCard.Rows.Add()("CardNo") = drCard("CardNo").ToString
        Next
        dtCard.AcceptChanges()

        dtInput = New DataTable()
        dtInput.Columns.Add("CardNo", System.Type.GetType("System.String"))

        sStartCardNo = dtAvailable.Rows(0)("CardNo").ToString
        sEndCardNo = dtAvailable.Rows(dtAvailable.Rows.Count - 1)("CardNo").ToString
        For bChar As Byte = 0 To 16
            If sStartCardNo.Substring(bChar, 1) <> sEndCardNo.Substring(bChar, 1) Then
                sSameCode = sStartCardNo.Substring(0, bChar)
                Exit For
            End If
        Next

        Me.lblSameCode.Text = sSameCode
        If sStartCardNo.IndexOf("2") = 0 Then
            bMaxLength = sStartCardNo.Length - sSameCode.Length - 1
        Else
            bMaxLength = sStartCardNo.Length - sSameCode.Length
            Me.lblExclude.Text = "位数字即可。"
        End If
        Me.lblLength.Text = bMaxLength.ToString
        sStartCardNo = sStartCardNo.Substring(sSameCode.Length, bMaxLength)
        sEndCardNo = sEndCardNo.Substring(sSameCode.Length, bMaxLength)
        Me.lblStartCardNo.Text = sStartCardNo
        Me.lblEndCardNo.Text = sEndCardNo
        Me.txbStartCardNo.MaxLength = bMaxLength
        Me.txbEndCardNo.MaxLength = bMaxLength

        With Me.dgvCard
            .DataSource = dtCard
            With .Columns(0)
                .HeaderText = "行号"
                .MinimumWidth = 36
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.BackColor = SystemColors.Control
                .DefaultCellStyle.ForeColor = SystemColors.ControlText
                .DefaultCellStyle.SelectionBackColor = SystemColors.Control
                .DefaultCellStyle.SelectionForeColor = SystemColors.ControlText
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(1)
                .HeaderText = "卡号"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            .Columns(2).Visible = False
            .Sort(.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
        End With

        Me.lblQTY.Text = Format(dtCard.Rows.Count, "#,0") & " 张"
        Me.lblAMT.Text = Format(dtCard.Rows.Count * dmFaceValue, "#,0.00") & " 元"

        If dtCard.Rows.Count > 0 Then
            Me.pnlPrompt.Visible = True
            Me.btnDeleteSelected.Enabled = True
            Me.btnClearList.Enabled = True
        End If

        Dim iGridHeight As Integer = Int((My.Computer.Screen.WorkingArea.Height - IIf(ToolStripManager.VisualStylesEnabled, 61, 56)) / 24) * 24
        Me.Height = iGridHeight + IIf(ToolStripManager.VisualStylesEnabled, 61, 56)
        Dim iLeft As Integer = frmCardActivation.splitHorizontal.PointToScreen(frmCardActivation.dgvCard.Location).X - Me.Width - 12
        If iLeft < 0 Then iLeft = 0
        Me.Location = New Point(iLeft, 0)
    End Sub

    Private Sub dgvCard_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvCard.CellFormatting
        If e.ColumnIndex = 0 Then e.Value = e.RowIndex + 1
        If e.ColumnIndex = 1 AndAlso Me.dgvCard(2, e.RowIndex).Value.ToString <> "" AndAlso Me.dgvCard(2, e.RowIndex).Value = iBatchID Then
            e.CellStyle.BackColor = Color.WhiteSmoke
            e.CellStyle.SelectionBackColor = SystemColors.GradientInactiveCaption
        End If
    End Sub

    Private Sub dgvCard_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvCard.CellMouseClick
        If e.Button = Windows.Forms.MouseButtons.Right AndAlso e.ColumnIndex = 1 Then
            If Not Me.dgvCard.Rows(e.RowIndex).Selected Then
                Me.dgvCard("CardNo", e.RowIndex).Selected = True
                Me.dgvCard.ClearSelection()
                Me.dgvCard("CardNo", e.RowIndex).Selected = True
            End If
            Me.cmenuDeleteCard.Show(Control.MousePosition)
        End If
    End Sub

    Private Sub dgvCard_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCard.SelectionChanged
        Me.btnDeleteSelected.Enabled = (Me.dgvCard.SelectedRows.Count > 0)
    End Sub

    Private Sub menuDeleteNormalCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuDeleteNormalCard.Click
        If Me.btnDeleteSelected.Enabled Then Me.btnDeleteSelected.PerformClick()
    End Sub

    Private Sub txbStartCardNo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbStartCardNo.Enter
        Me.txbStartCardNo.SelectAll()
    End Sub

    Private Sub txbStartCardNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbStartCardNo.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then Me.txbEndCardNo.Select() : Me.txbEndCardNo.SelectAll() : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbStartCardNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbStartCardNo.Leave
        If Me.txbStartCardNo.Text.Trim = "" OrElse sInputStartCardNo = "" OrElse Me.lblCurrentInfo.Text <> "" Then Return
        If Me.txbStartCardNo.Text <> sInputStartCardNo Then Me.txbStartCardNo.Text = sInputStartCardNo

        If Not IsNumeric(sInputStartCardNo) Then
            Me.lblStartError.Text = "（卡号必须是数字！）"
            Me.lblCurrentInfo.Text = ""
            Me.btnAdd.Enabled = False
            Return
        End If

        If sInputStartCardNo.Length < bMaxLength Then
            Me.lblStartError.Text = "（卡号不足 " & bMaxLength.ToString & "位数！）"
            Me.lblCurrentInfo.Text = ""
            Me.btnAdd.Enabled = False
            Return
        End If

        If sInputStartCardNo < sStartCardNo Then
            Me.lblStartError.Text = "（卡号不能小于最小卡号""" & sStartCardNo & """！）"
            Me.lblCurrentInfo.Text = ""
            Me.btnAdd.Enabled = False
            Return
        End If

        If sInputStartCardNo > sEndCardNo Then
            Me.lblStartError.Text = "（卡号不能大于最大卡号""" & sEndCardNo & """！）"
            Me.lblCurrentInfo.Text = ""
            Me.btnAdd.Enabled = False
            Return
        End If

        If sInputEndCardNo = "" Then Me.txbEndCardNo.Text = sInputStartCardNo
        If Me.lblEndError.Text <> "" Then Return

        If sInputStartCardNo > sInputEndCardNo Then
            Dim sTemp As String = sInputStartCardNo
            Me.txbStartCardNo.Text = sInputEndCardNo
            Me.txbEndCardNo.Text = sTemp
        End If

        Me.SummaryInput()
    End Sub

    Private Sub txbStartCardNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbStartCardNo.TextChanged
        sInputStartCardNo = Me.txbStartCardNo.Text.Trim
        If sInputEndCardNo = "" Then Me.txbEndCardNo.Text = ""
        Me.lblStartError.Text = ""
        Me.lblCurrentInfo.Text = ""
    End Sub

    Private Sub txbEndCardNo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbEndCardNo.Enter
        Me.txbEndCardNo.SelectAll()
    End Sub

    Private Sub txbEndCardNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbEndCardNo.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then Me.txbStartCardNo.Select() : Me.txbStartCardNo.SelectAll() : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbEndCardNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbEndCardNo.Leave
        If Me.txbEndCardNo.Text.Trim = "" OrElse sInputEndCardNo = "" OrElse Me.lblCurrentInfo.Text <> "" Then Return
        If Me.txbEndCardNo.Text <> sInputEndCardNo Then Me.txbEndCardNo.Text = sInputEndCardNo

        If Not IsNumeric(sInputEndCardNo) Then
            Me.lblEndError.Text = "（卡号必须是数字！）"
            Me.lblCurrentInfo.Text = ""
            Me.btnAdd.Enabled = False
            Return
        End If

        If sInputEndCardNo.Length < bMaxLength Then
            Me.lblEndError.Text = "（卡号不足 " & bMaxLength.ToString & "位数！）"
            Me.lblCurrentInfo.Text = ""
            Me.btnAdd.Enabled = False
            Return
        End If

        If sInputEndCardNo < sStartCardNo Then
            Me.lblEndError.Text = "（卡号不能小于最小卡号""" & sStartCardNo & """！）"
            Me.lblCurrentInfo.Text = ""
            Me.btnAdd.Enabled = False
            Return
        End If

        If sInputEndCardNo > sEndCardNo Then
            Me.lblEndError.Text = "（卡号不能大于最大卡号""" & sEndCardNo & """！）"
            Me.lblCurrentInfo.Text = ""
            Me.btnAdd.Enabled = False
            Return
        End If

        If sInputStartCardNo = "" Then Me.txbStartCardNo.Text = sInputEndCardNo
        If Me.lblStartError.Text <> "" Then Return

        If sInputStartCardNo > sInputEndCardNo Then
            Dim sTemp As String = sInputStartCardNo
            Me.txbStartCardNo.Text = sInputEndCardNo
            Me.txbEndCardNo.Text = sTemp
        End If

        Me.SummaryInput()
    End Sub

    Private Sub txbEndCardNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbEndCardNo.TextChanged
        sInputEndCardNo = Me.txbEndCardNo.Text.Trim
        If sInputStartCardNo = "" Then Me.txbStartCardNo.Text = ""
        Me.lblEndError.Text = ""
        Me.lblCurrentInfo.Text = ""
    End Sub

    Private Sub SummaryInput()
        Dim iCards As Integer = CInt(sInputEndCardNo) - CInt(sInputStartCardNo), iAvailableCards As Integer = 0, sCurrentInfo As String = "（共 " & Format(iCards + 1, "#,0") & " 张；实际可加入 ", sCardNo As String
        dtInput.Rows.Clear()
        For iCard As Integer = 0 To iCards
            sCardNo = sSameCode & Format(CInt(sInputStartCardNo) + iCard, StrDup(bMaxLength, "0"))
            If sCardNo.IndexOf("2") = 0 Then sCardNo = ShoppingCardNo.GetFullCardNo(sCardNo)
            If dtAvailable.Rows.Find(sCardNo) IsNot Nothing AndAlso dtCard.Rows.Find(sCardNo) Is Nothing Then
                dtInput.Rows.Add(sCardNo)
            End If
        Next
        iAvailableCards = dtInput.Rows.Count

        sCurrentInfo = sCurrentInfo & Format(iAvailableCards, "#,0") & " 张）"
        Me.lblCurrentInfo.Text = sCurrentInfo
        Me.btnAdd.Enabled = (iAvailableCards > 0)
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        iBatchID += 1
        Me.dgvCard.ClearSelection()
        Dim currentCell As DataGridViewCell = Me.dgvCard.CurrentCell, sCardNo As String, iRowID As Integer
        For Each drCard As DataRow In dtInput.Rows
            sCardNo = drCard("CardNo").ToString
            dtCard.Rows.Add(0, sCardNo, iBatchID)
            iRowID = dtCard.Compute("Count(CardNo)", "CardNo<'" & sCardNo & "'")
            If Me.dgvCard.CurrentCell Is Nothing OrElse Me.dgvCard.CurrentCell.Equals(currentCell) Then
                Me.dgvCard.CurrentCell = Me.dgvCard("CardNo", iRowID)
            Else
                Me.dgvCard("CardNo", iRowID).Selected = True
                Me.dgvCard.Rows(iRowID).Selected = True
            End If
            Try
                Me.dgvCard.FirstDisplayedScrollingRowIndex = iRowID - Me.dgvCard.DisplayedRowCount(True) + 1
            Catch
            End Try
        Next

        Me.lblQTY.Text = Format(dtCard.Rows.Count, "#,0") & " 张"
        Me.lblAMT.Text = Format(dtCard.Rows.Count * dmFaceValue, "#,0.00") & " 元"

        Me.pnlPrompt.Visible = True
        Me.btnDeleteSelected.Enabled = True
        Me.btnClearList.Enabled = True
        Me.btnOK.Enabled = True
        Me.btnAdd.Enabled = False

        sInputStartCardNo = "" : sInputEndCardNo = ""
    End Sub

    Private Sub btnDeleteSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteSelected.Click
        Me.btnDeleteSelected.Enabled = False
        For Each drCard As DataGridViewRow In Me.dgvCard.SelectedRows()
            dtCard.Rows.Find(drCard.Cells("CardNo").Value.ToString).Delete()
        Next

        Me.lblQTY.Text = Format(dtCard.Rows.Count, "#,0") & " 张"
        Me.lblAMT.Text = Format(dtCard.Rows.Count * dmFaceValue, "#,0.00") & " 元"

        Me.pnlPrompt.Visible = (dtCard.Rows.Count > 0)
        Me.btnClearList.Enabled = (dtCard.Rows.Count > 0)

        Me.lblCurrentInfo.Text = ""
        sInputStartCardNo = Me.txbStartCardNo.Text.Trim
        sInputEndCardNo = Me.txbEndCardNo.Text.Trim
        Me.txbStartCardNo.Select()
        Me.dgvCard.Select()

        Me.btnOK.Enabled = (dtCard.GetChanges() IsNot Nothing)
    End Sub

    Private Sub btnClearList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearList.Click
        dtCard.Rows.Clear()
        Me.pnlPrompt.Visible = False
        Me.btnDeleteSelected.Enabled = False
        Me.btnClearList.Enabled = False

        Me.lblCurrentInfo.Text = ""
        sInputStartCardNo = Me.txbStartCardNo.Text.Trim
        sInputEndCardNo = Me.txbEndCardNo.Text.Trim
        Me.lblQTY.Text = "0 张"
        Me.lblAMT.Text = "0.00 元"

        Me.txbStartCardNo.Select()
        Me.dgvCard.Select()

        Me.btnOK.Enabled = (dtAvailable.Select("Selected=1").Length > 0)
    End Sub
End Class