Public Class frmSearchCustomer

    Private Sub frmSearchCustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txbCustomerName.Select()
    End Sub

    Private Sub rdbByCustomerCode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbByCustomerCode.CheckedChanged
        Me.txbCustomerCode.Enabled = Me.rdbByCustomerCode.Checked
        If Me.rdbByCustomerCode.Checked Then
            Me.txbCustomerCode.Select() : Me.txbCustomerCode.SelectAll()
            Me.btnOK.Enabled = (Me.txbCustomerCode.Text.Trim <> "")
        End If
    End Sub

    Private Sub txbCustomerCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbCustomerCode.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbCustomerCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbCustomerCode.TextChanged
        Me.btnOK.Enabled = (Me.txbCustomerCode.Text.Trim <> "")
    End Sub

    Private Sub rdbByCustomerName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbByCustomerName.CheckedChanged
        Me.txbCustomerName.Enabled = Me.rdbByCustomerName.Checked
        If Me.rdbByCustomerName.Checked Then
            Me.txbCustomerName.Select() : Me.txbCustomerName.SelectAll()
            Me.btnOK.Enabled = (Me.txbCustomerName.Text.Trim <> "")
        End If
    End Sub

    Private Sub txbCustomerName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbCustomerName.TextChanged
        Me.btnOK.Enabled = (Me.txbCustomerName.Text.Trim <> "")
    End Sub

    Private Sub rdbByPinYinCode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbByPinYinCode.CheckedChanged
        Me.txbPinYinCode.Enabled = Me.rdbByPinYinCode.Checked
        If Me.rdbByPinYinCode.Checked Then
            Me.txbPinYinCode.Select() : Me.txbPinYinCode.SelectAll()
            Me.btnOK.Enabled = (Me.txbPinYinCode.Text.Trim <> "")
        End If
    End Sub

    Private Sub txbPinYinCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbPinYinCode.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode >= Keys.A AndAlso e.KeyCode <= Keys.Z Then Return
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbPinYinCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbPinYinCode.TextChanged
        Me.btnOK.Enabled = (Me.txbPinYinCode.Text.Trim <> "")
    End Sub

    Private Sub rdbByLinkman_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbByLinkman.CheckedChanged
        Me.txbLinkman.Enabled = Me.rdbByLinkman.Checked
        If Me.rdbByLinkman.Checked Then
            Me.txbLinkman.Select() : Me.txbLinkman.SelectAll()
            Me.btnOK.Enabled = (Me.txbLinkman.Text.Trim <> "")
        End If
    End Sub

    Private Sub txbLinkman_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbLinkman.TextChanged
        Me.btnOK.Enabled = (Me.txbLinkman.Text.Trim <> "")
    End Sub

    Private Sub rdbByTelMP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbByTelMP.CheckedChanged
        Me.txbTelMP.Enabled = Me.rdbByTelMP.Checked
        If Me.rdbByTelMP.Checked Then
            Me.txbTelMP.Select() : Me.txbTelMP.SelectAll()
            Me.btnOK.Enabled = (Me.txbTelMP.Text.Trim <> "")
        End If
    End Sub

    Private Sub txbTelMP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbTelMP.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then Return
        If e.Shift AndAlso e.KeyCode <> Keys.D0 AndAlso e.KeyCode <> Keys.D9 Then e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        If (e.Shift AndAlso (e.KeyCode = Keys.D9 OrElse e.KeyCode = Keys.D0)) OrElse e.KeyCode = Keys.OemMinus OrElse e.KeyCode = Keys.Subtract OrElse e.KeyCode = Keys.Space Then Return
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbTelMP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbTelMP.TextChanged
        Me.btnOK.Enabled = (Me.txbTelMP.Text.Trim <> "")
    End Sub

    Private Sub rdbByCompanyAddress_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbByCompanyAddress.CheckedChanged
        Me.txbCompanyAddress.Enabled = Me.rdbByCompanyAddress.Checked
        If Me.rdbByCompanyAddress.Checked Then
            Me.txbCompanyAddress.Select() : Me.txbCompanyAddress.SelectAll()
            Me.btnOK.Enabled = (Me.txbCompanyAddress.Text.Trim <> "")
        End If
    End Sub

    Private Sub txbCompanyAddress_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbCompanyAddress.TextChanged
        Me.btnOK.Enabled = (Me.txbCompanyAddress.Text.Trim <> "")
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在查找客户……"
        frmMain.Refresh()

        Dim DB As New DataBase()
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法查找客户。请检查数据库连接。"
            Me.Cursor = Cursors.Default : Return
        End If

        frmCustomerManagement.iSearchNo += 1
        Dim sSQL As String = "Exec SearchCustomer " & frmMain.sLoginUserID & "," & frmCustomerManagement.iSearchNo.ToString & ",", dtResult As DataTable = Nothing
        If Me.rdbByCustomerCode.Checked Then
            sSQL = sSQL & "0,'" & Me.txbCustomerCode.Text.Trim & "'"
        ElseIf Me.rdbByCustomerName.Checked Then
            sSQL = sSQL & "1,'" & Me.txbCustomerName.Text.Trim.Replace("'", "''") & "'"
        ElseIf Me.rdbByPinYinCode.Checked Then
            sSQL = sSQL & "2,'" & Me.txbPinYinCode.Text.Trim & "'"
        ElseIf Me.rdbByLinkman.Checked Then
            sSQL = sSQL & "3,'" & Me.txbLinkman.Text.Trim.Replace("'", "''") & "'"
        ElseIf Me.rdbByTelMP.Checked Then
            sSQL = sSQL & "4,'" & Me.txbTelMP.Text.Trim & "'"
        Else
            sSQL = sSQL & "5,'" & Me.txbCompanyAddress.Text.Trim.Replace("'", "''") & "'"
        End If

        dtResult = DB.GetDataTable(sSQL)
        DB.Close()
        If dtResult Is Nothing Then
            frmMain.statusText.Text = "系统因在检索数据时出错而无法查找客户。请联系软件开发人员。"
            Me.Cursor = Cursors.Default : Return
        End If

        If dtResult.Rows.Count = 0 Then
            MessageBox.Show("找不到客户！    ", "找不到！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            If Me.rdbByCustomerCode.Checked Then
                Me.txbCustomerCode.Select() : Me.txbCustomerCode.SelectAll()
            ElseIf Me.rdbByCustomerName.Checked Then
                Me.txbCustomerName.Select() : Me.txbCustomerName.SelectAll()
            ElseIf Me.rdbByPinYinCode.Checked Then
                Me.txbPinYinCode.Select() : Me.txbPinYinCode.SelectAll()
            ElseIf Me.rdbByLinkman.Checked Then
                Me.txbLinkman.Select() : Me.txbLinkman.SelectAll()
            ElseIf Me.rdbByTelMP.Checked Then
                Me.txbTelMP.Select() : Me.txbTelMP.SelectAll()
            Else
                Me.txbCompanyAddress.Select() : Me.txbCompanyAddress.SelectAll()
            End If
            Me.btnOK.Enabled = False
            frmMain.statusText.Text = "找不到客户！"
        Else
            With frmCustomerManagement
                .dvCustomer.Table.Merge(dtResult.Copy, False)
                .dvCustomer.RowFilter = "SearchNo=" & .iSearchNo.ToString
                With .trvArea
                    If .SelectedNode IsNot Nothing Then
                        .SelectedNode.BackColor = SystemColors.Window
                        .SelectedNode.ForeColor = SystemColors.ControlText
                        .SelectedNode = Nothing
                    End If
                End With
            End With
            frmMain.statusText.Text = "共找到 " & Format(dtResult.Rows.Count, "#,0") & " 个客户 " & IIf(dtResult.Rows.Count = 500, "（一次最多只能找到 500 个客户）。", "。")
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If

        dtResult.Dispose() : dtResult = Nothing
        Me.Cursor = Cursors.Default
    End Sub
End Class