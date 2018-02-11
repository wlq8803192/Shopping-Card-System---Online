Public Class frmSearchPayment

    Public sKeyCode As String
    Private dtList As DataTable, dvResult As DataView, iSelectedIndex As Integer, bSearchType As Byte = 0, blSkipDeal As Boolean = True

    Private Sub frmSearchPayment_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sKeyCode <> "" Then
            My.Computer.Keyboard.SendKeys(sKeyCode)
            sKeyCode = ""
        End If
    End Sub

    Private Sub frmSearchPayment_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub frmSearchPayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtList = frmPaymentConfirmation.dvList.ToTable
        dtList.AcceptChanges()

        If Me.rdbByPayerName.Checked Then
            Me.txbPayerName.Select()
            Me.txbPayerName.SelectAll()
        Else
            Me.txbMediaNo.Select()
            Me.txbMediaNo.SelectAll()
        End If
        Me.Location = New Point(0, 0)

        blSkipDeal = False
        If Me.btnOK.Enabled = False Then Me.SetNoSelected()
    End Sub

    Private Sub rdbByPayerName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbByPayerName.CheckedChanged
        Me.txbPayerName.Enabled = Me.rdbByPayerName.Checked
        If Me.txbPayerName.Enabled Then
            bSearchType = 0
            Me.txbPayerName.Select()
            Me.txbPayerName.SelectAll()
            If Me.txbPayerName.Text.Trim = "" Then
                Me.btnPrevious.Enabled = False
                Me.btnNext.Enabled = False
                Me.btnOK.Enabled = False
                Me.btnMore.Enabled = False
                Me.SetNoSelected()
            Else
                Me.SearchPayment()
                Me.btnMore.Enabled = True
            End If
        End If
    End Sub

    Private Sub txbPayerName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbPayerName.TextChanged
        If Me.txbPayerName.Text.Trim = "" Then
            Me.btnPrevious.Enabled = False
            Me.btnNext.Enabled = False
            Me.btnOK.Enabled = False
            Me.btnMore.Enabled = False
            Me.SetNoSelected()
        Else
            Me.SearchPayment()
            Me.btnMore.Enabled = True
        End If
    End Sub

    Private Sub rdbByMediaNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbByMediaNo.CheckedChanged
        Me.txbMediaNo.Enabled = Me.rdbByMediaNo.Checked
        If Me.txbMediaNo.Enabled Then
            bSearchType = 1
            Me.txbMediaNo.Select()
            Me.txbMediaNo.SelectAll()
            If Me.txbMediaNo.Text.Trim = "" Then
                Me.btnPrevious.Enabled = False
                Me.btnNext.Enabled = False
                Me.btnOK.Enabled = False
                Me.btnMore.Enabled = False
                Me.SetNoSelected()
            Else
                Me.SearchPayment()
                Me.btnMore.Enabled = True
            End If
        End If
    End Sub

    Private Sub txbMediaNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbMediaNo.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbMediaNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbMediaNo.TextChanged
        If Me.txbMediaNo.Text.Trim = "" Then
            Me.btnPrevious.Enabled = False
            Me.btnNext.Enabled = False
            Me.btnOK.Enabled = False
            Me.btnMore.Enabled = False
            Me.SetNoSelected()
        Else
            Me.SearchPayment()
            Me.btnMore.Enabled = True
        End If
    End Sub

    Private Sub rdbByPaymentAMT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbByPaymentAMT.CheckedChanged
        Me.txbPaymentAMT.Enabled = Me.rdbByPaymentAMT.Checked
        If Me.txbPaymentAMT.Enabled Then
            bSearchType = 2
            Me.txbPaymentAMT.Select()
            Me.txbPaymentAMT.SelectAll()
            If Me.txbPaymentAMT.Text.Trim = "" Then
                Me.btnPrevious.Enabled = False
                Me.btnNext.Enabled = False
                Me.btnOK.Enabled = False
                Me.btnMore.Enabled = False
                Me.SetNoSelected()
            Else
                Me.SearchPayment()
                Me.btnMore.Enabled = True
            End If
        End If
    End Sub

    Private Sub txbPaymentAMT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbPaymentAMT.Enter
        If IsNumeric(Me.txbPaymentAMT.Text) Then
            blSkipDeal = True
            Me.txbPaymentAMT.Text = Me.txbPaymentAMT.Text.Replace(",", "")
            blSkipDeal = False
        End If
    End Sub

    Private Sub txbPaymentAMT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbPaymentAMT.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        If e.KeyCode = Keys.OemPeriod OrElse e.KeyCode = Keys.Decimal Then
            If Me.txbPaymentAMT.SelectedText.IndexOf(".") > -1 OrElse Me.txbPaymentAMT.Text.IndexOf(".") = -1 Then Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbPaymentAMT_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbPaymentAMT.Leave
        If IsNumeric(Me.txbPaymentAMT.Text) Then
            blSkipDeal = True
            Me.txbPaymentAMT.Text = Format(CDec(Me.txbPaymentAMT.Text), "#,0.00")
            blSkipDeal = False
        End If
    End Sub

    Private Sub txbPaymentAMT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbPaymentAMT.TextChanged
        If blSkipDeal Then Return

        If Me.txbPaymentAMT.Text.Trim <> "" AndAlso Not IsNumeric(Me.txbPaymentAMT.Text.Trim) Then
            blSkipDeal = True
            Me.txbPaymentAMT.Text = ""
            blSkipDeal = False
        End If

        If Me.txbPaymentAMT.Text.Trim = "" Then
            Me.btnPrevious.Enabled = False
            Me.btnNext.Enabled = False
            Me.btnOK.Enabled = False
            Me.btnMore.Enabled = False
            Me.SetNoSelected()
        Else
            Me.SearchPayment()
            Me.btnMore.Enabled = True
        End If
    End Sub

    Private Sub rdbBySalesBillCode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbBySalesBillCode.CheckedChanged
        Me.txbSalesBillCode.Enabled = Me.rdbBySalesBillCode.Checked
        If Me.txbSalesBillCode.Enabled Then
            bSearchType = 3
            Me.txbSalesBillCode.Select()
            Me.txbSalesBillCode.SelectAll()
            If Me.txbSalesBillCode.Text.Trim = "" Then
                Me.btnPrevious.Enabled = False
                Me.btnNext.Enabled = False
                Me.btnOK.Enabled = False
                Me.btnMore.Enabled = False
                Me.SetNoSelected()
            Else
                Me.SearchPayment()
                Me.btnMore.Enabled = (Me.txbSalesBillCode.Text.Trim.Length = 13)
            End If
        End If
    End Sub

    Private Sub txbSalesBillCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbSalesBillCode.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbSalesBillCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbSalesBillCode.TextChanged
        If Me.txbSalesBillCode.Text.Trim = "" Then
            Me.btnPrevious.Enabled = False
            Me.btnNext.Enabled = False
            Me.btnOK.Enabled = False
            Me.btnMore.Enabled = False
            Me.SetNoSelected()
        Else
            Me.SearchPayment()
            Me.btnMore.Enabled = (Me.txbSalesBillCode.Text.Trim.Length = 13)
        End If
    End Sub

    Private Sub btnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevious.Click
        iSelectedIndex -= 1
        Me.SetSelectedRow()
        Me.btnPrevious.Enabled = (iSelectedIndex > 0)
        Me.btnNext.Enabled = True
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        iSelectedIndex += 1
        Me.SetSelectedRow()
        Me.btnPrevious.Enabled = True
        Me.btnNext.Enabled = (iSelectedIndex < dvResult.Count - 1)
    End Sub

    Private Sub btnMore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMore.Click
        Me.Cursor = Cursors.WaitCursor
        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法查找付款单。请检查数据库连接。"
            Me.Cursor = Cursors.Default : Return
        End If
        Dim sSQL As String = "Exec SearchPayment " & frmMain.sLoginUserID & "," & bSearchType.ToString & ","
        Select Case bSearchType
            Case 0
                sSQL = sSQL & "'" & Me.txbPayerName.Text.Trim.Replace("'", "''") & "',"
            Case 1
                sSQL = sSQL & "'" & Me.txbMediaNo.Text.Trim.Replace("'", "''") & "',"
            Case 2
                sSQL = sSQL & "'" & Me.txbPaymentAMT.Text.Trim.Replace(",", "") & "',"
            Case Else
                sSQL = sSQL & "'" & Me.txbSalesBillCode.Text.Trim.Replace("'", "''") & "',"
        End Select
        sSQL = sSQL & frmPaymentConfirmation.cbbStore.SelectedValue.ToString
        Dim dtResult As DataTable = DB.GetDataTable(sSQL)
        DB.Close()
        If dtResult Is Nothing Then
            frmMain.statusText.Text = "系统因在检索数据时出错而无法查找付款单。请联系软件开发人员。"
            Me.Cursor = Cursors.Default : Return
        End If

        frmPaymentConfirmation.dvList.Table.Merge(dtResult, True)
        Me.Cursor = Cursors.Default
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub SearchPayment()
        dvResult = dtList.Copy.DefaultView
        Select Case bSearchType
            Case 0
                dvResult.RowFilter = "PayerName Like '%" & Me.txbPayerName.Text.Trim.Replace("'", "''") & "%'"
            Case 1
                dvResult.RowFilter = "MediaNo Like '%" & Me.txbMediaNo.Text.Trim.Replace("'", "''") & "%'"
            Case 2
                dvResult.RowFilter = "PaymentAMT=" & Me.txbPaymentAMT.Text.Trim.Replace(",", "")
            Case Else
                dvResult.RowFilter = "SalesBillCode Like '%" & Me.txbSalesBillCode.Text.Trim.Replace("'", "''") & "%'"
        End Select
        dvResult = dvResult.ToTable.DefaultView
        If dvResult.Count = 0 Then
            Me.btnPrevious.Enabled = False
            Me.btnNext.Enabled = False
            Me.btnOK.Enabled = False
            Me.SetNoSelected()
        Else
            iSelectedIndex = 0
            Me.SetSelectedRow()
            Me.btnPrevious.Enabled = False
            Me.btnNext.Enabled = (dvResult.Count > 1)
            Me.btnOK.Enabled = True
        End If
    End Sub

    Private Sub SetNoSelected()
        With frmPaymentConfirmation
            If .dgvList.CurrentCell IsNot Nothing Then .dgvList.CurrentCell.Selected = False
            If .dgvList.CurrentRow IsNot Nothing Then .dgvList.CurrentRow.Selected = False
        End With
    End Sub

    Private Sub SetSelectedRow()
        With frmPaymentConfirmation
            Try
                Dim iPaymentID = dvResult(iSelectedIndex)("PaymentID"), iRowIndex As Integer, bColumnIndex As Byte
                For Each drPayment As DataGridViewRow In frmPaymentConfirmation.dgvList.Rows
                    If drPayment.Cells("PaymentID").Value = iPaymentID Then
                        iRowIndex = drPayment.Index
                        Exit For
                    End If
                Next
                Select Case bSearchType
                    Case 0
                        bColumnIndex = .dgvList.Columns("PayerName").Index
                    Case 1
                        bColumnIndex = .dgvList.Columns("MediaNo").Index
                    Case 2
                        bColumnIndex = .dgvList.Columns("PaymentAMT").Index
                    Case Else
                        bColumnIndex = .dgvList.Columns("SalesBillCode").Index
                End Select
                If Not .dgvList.Columns(bColumnIndex).Visible Then .dgvList.FirstDisplayedScrollingColumnIndex = bColumnIndex
                .dgvList(bColumnIndex, iRowIndex).Selected = True
                .dgvList.Rows(iRowIndex).Selected = True
                If Not .dgvList.Rows(iRowIndex).Visible Then .dgvList.FirstDisplayedScrollingRowIndex = iRowIndex - 1
            Catch
            End Try
        End With
    End Sub
End Class