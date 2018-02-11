Public Class frmSearchUser

    Private Sub frmSearchUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txbRealName.Select()
    End Sub

    Private Sub rdbByUserCode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbByUserCode.CheckedChanged
        Me.pnlByUserCode.Enabled = Me.rdbByUserCode.Checked
        If Me.rdbByUserCode.Checked Then
            Me.txbUserCode.Select() : Me.txbUserCode.SelectAll()
            Me.btnOK.Enabled = (Me.txbUserCode.Text.Trim <> "")
        End If
    End Sub

    Private Sub rdbByLoginName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbByLoginName.CheckedChanged
        Me.pnlByLoginName.Enabled = Me.rdbByLoginName.Checked
        If Me.rdbByLoginName.Checked Then
            Me.txbLoginName.Select() : Me.txbLoginName.SelectAll()
            Me.btnOK.Enabled = (Me.txbLoginName.Text.Trim <> "")
        End If
    End Sub

    Private Sub rdbByRealName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbByRealName.CheckedChanged
        Me.pnlByRealName.Enabled = Me.rdbByRealName.Checked
        If Me.rdbByRealName.Checked Then
            Me.txbRealName.Select() : Me.txbRealName.SelectAll()
            Me.btnOK.Enabled = (Me.txbRealName.Text.Trim <> "")
        End If
    End Sub

    Private Sub txbUserCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbUserCode.TextChanged
        Me.btnOK.Enabled = (Me.txbUserCode.Text.Trim <> "")
    End Sub

    Private Sub txbLoginName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbLoginName.TextChanged
        Me.btnOK.Enabled = (Me.txbLoginName.Text.Trim <> "")
    End Sub

    Private Sub txbRealName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbRealName.TextChanged
        Me.btnOK.Enabled = (Me.txbRealName.Text.Trim <> "")
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在查找用户……"
        frmMain.Refresh()

        Dim drRows() As DataRow
        If Me.rdbByUserCode.Checked Then
            Dim sUserCode As String = Me.txbUserCode.Text.Trim
            If sUserCode.Length < 8 OrElse "|H|T|R|C|S|".IndexOf(sUserCode.Substring(0, 1).ToUpper) = -1 OrElse Not IsNumeric(sUserCode.Substring(1, 7)) Then
                MessageBox.Show("用户编号应该由1个 字母 （H、T、R、C或S）和7个数字组成。    " & Chr(13) & Chr(13) & _
                                "User Code should be consist of one letter (H, T, R, C or S) and 7 digits.    ", "用户编号错误 User Code Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txbUserCode.Select() : Me.txbUserCode.SelectAll()
                Me.btnOK.Enabled = False
                Return
            Else
                drRows = frmUserManagerment.dvUser.Table.Select("UserCode='" & sUserCode & "'")
            End If
        ElseIf Me.rdbByLoginName.Checked Then
            drRows = frmUserManagerment.dvUser.Table.Select("LoginName='" & Me.txbLoginName.Text.Trim.Replace("'", "''") & "'")
        Else
            drRows = frmUserManagerment.dvUser.Table.Select("UserChineseName='" & Me.txbRealName.Text.Trim.Replace("'", "''") & "' Or UserEnglishName='" & Me.txbRealName.Text.Trim.Replace("'", "''") & "'")
        End If

        If drRows.Length = 0 Then
            MessageBox.Show("找不到此用户！    " & Chr(13) & Chr(13) & "The user can not be found!    ", "找不到 Not found!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            If Me.rdbByUserCode.Checked Then
                Me.txbUserCode.Select() : Me.txbUserCode.SelectAll()
            Else
                Me.txbLoginName.Select() : Me.txbLoginName.SelectAll()
            End If
            Me.btnOK.Enabled = False
            frmMain.statusText.Text = "找不到用户。"
        Else
            With frmUserManagerment
                If .trvArea.SelectedNode Is Nothing OrElse .trvArea.SelectedNode.Name <> drRows(0)("LocationID").ToString Then
                    If .trvArea.SelectedNode IsNot Nothing Then
                        .trvArea.SelectedNode.BackColor = SystemColors.Window
                        .trvArea.SelectedNode.ForeColor = SystemColors.ControlText
                    End If
                    .trvArea.SelectedNode = .trvArea.Nodes.Find(drRows(0)("LocationID").ToString, True)(0)
                    .trvArea.SelectedNode.BackColor = SystemColors.Highlight
                    .trvArea.SelectedNode.ForeColor = SystemColors.HighlightText
                    .trvArea.SelectedNode.EnsureVisible()
                End If
                If .cbbRole.SelectedValue <> 255 AndAlso .cbbRole.SelectedValue <> drRows(0)("RoleID").ToString Then .cbbRole.SelectedIndex = 0
                If .cbbState.SelectedIndex > 1 Then .cbbState.SelectedIndex = 0
                For Each dr As DataGridViewRow In .dgvList.Rows
                    If dr.Cells("UserID").Value.ToString = drRows(0)("UserID").ToString Then
                        dr.Cells(1).Selected = True
                        dr.Selected = False
                        dr.Selected = True
                        Exit For
                    End If
                Next
            End With
            frmMain.statusText.Text = "已找到用户。"
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
        drRows = Nothing

        Me.Cursor = Cursors.Default
    End Sub
End Class