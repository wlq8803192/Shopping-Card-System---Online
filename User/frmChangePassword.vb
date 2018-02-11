Public Class frmChangePassword

    Private blNewTooSimple As Boolean = False

    Private Sub frmChangePassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.txbUser.Text = "" Then
            Me.txbUser.Select()
        ElseIf Me.txbOldPassword.Text = "" Then
            Me.txbOldPassword.Select()
        Else
            Me.txbNewPassword.Select()
        End If

        Me.CheckStrength(Me.txbOldPassword.Text, False)
        Me.CheckStrength(Me.txbNewPassword.Text, True)
    End Sub

    Private Sub flpContainer_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles flpContainer.SizeChanged
        Me.Height = Me.flpContainer.Height + 101
        Me.pnlButtom.Top = Me.flpContainer.Top + Me.flpContainer.Height + 3
    End Sub

    Private Sub txbUser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbUser.KeyDown
        If e.KeyCode = Keys.Enter Then Me.txbOldPassword.Select() : Me.txbOldPassword.SelectAll() : e.SuppressKeyPress = True
    End Sub

    Private Sub txbUser_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbUser.TextChanged, cbbUser.TextChanged
        If Me.txbUser.Visible = True Then
            Me.btnOK.Enabled = (Me.txbUser.Text.Trim <> "" AndAlso Me.txbOldPassword.Text <> "" AndAlso Me.txbNewPassword.Text <> "" AndAlso Me.txbConfirmedPassword.Text <> "")
        Else
            Me.btnOK.Enabled = (Me.cbbUser.Text.Trim <> "" AndAlso Me.txbOldPassword.Text <> "" AndAlso Me.txbNewPassword.Text <> "" AndAlso Me.txbConfirmedPassword.Text <> "")
        End If
    End Sub

    Private Sub txbOldPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbOldPassword.KeyDown
        If e.KeyCode = Keys.Enter Then Me.txbNewPassword.Select() : Me.txbNewPassword.SelectAll() : e.SuppressKeyPress = True
    End Sub

    Private Sub txbOldPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbOldPassword.TextChanged
        Me.lblOldErrorChinese.Visible = False : Me.lblOldErrorEnglish.Visible = False
        If Me.txbUser.Visible = True Then
            Me.btnOK.Enabled = (Me.txbUser.Text.Trim <> "" AndAlso Me.txbOldPassword.Text <> "" AndAlso Me.txbNewPassword.Text <> "" AndAlso Me.txbConfirmedPassword.Text <> "")
        Else
            Me.btnOK.Enabled = (Me.cbbUser.Text.Trim <> "" AndAlso Me.txbOldPassword.Text <> "" AndAlso Me.txbNewPassword.Text <> "" AndAlso Me.txbConfirmedPassword.Text <> "")
        End If

        Me.CheckStrength(Me.txbOldPassword.Text, False)
    End Sub

    Private Sub txbNewPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbNewPassword.KeyDown
        If e.KeyCode = Keys.Enter Then Me.txbConfirmedPassword.Select() : Me.txbConfirmedPassword.SelectAll() : e.SuppressKeyPress = True
    End Sub

    Private Sub txbNewPassword_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbNewPassword.TextChanged
        Me.lblNewErrorChinese.Visible = False : Me.lblConfirmedErrorChinese.Visible = False : Me.lblNewErrorEnglish.Visible = False : Me.lblConfirmedErrorEnglish.Visible = False
        If Me.txbUser.Visible = True Then
            Me.btnOK.Enabled = (Me.txbUser.Text.Trim <> "" AndAlso Me.txbOldPassword.Text <> "" AndAlso Me.txbNewPassword.Text <> "" AndAlso Me.txbConfirmedPassword.Text <> "")
        Else
            Me.btnOK.Enabled = (Me.cbbUser.Text.Trim <> "" AndAlso Me.txbOldPassword.Text <> "" AndAlso Me.txbNewPassword.Text <> "" AndAlso Me.txbConfirmedPassword.Text <> "")
        End If

        Me.CheckStrength(Me.txbNewPassword.Text, True)
    End Sub

    Private Sub txbConfirmedPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbConfirmedPassword.KeyDown
        If e.KeyCode = Keys.Enter AndAlso Me.btnOK.Enabled Then Me.btnOK.Select() : Me.btnOK.PerformClick() : e.SuppressKeyPress = True
    End Sub

    Private Sub txbConfirmedPassword_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbConfirmedPassword.TextChanged
        Me.lblConfirmedErrorChinese.Visible = False : Me.lblConfirmedErrorEnglish.Visible = False
        If Me.txbUser.Visible = True Then
            Me.btnOK.Enabled = (Me.txbUser.Text.Trim <> "" AndAlso Me.txbOldPassword.Text <> "" AndAlso Me.txbNewPassword.Text <> "" AndAlso Me.txbConfirmedPassword.Text <> "")
        Else
            Me.btnOK.Enabled = (Me.cbbUser.Text.Trim <> "" AndAlso Me.txbOldPassword.Text <> "" AndAlso Me.txbNewPassword.Text <> "" AndAlso Me.txbConfirmedPassword.Text <> "")
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Me.txbNewPassword.Text.Length < 6 Then
            Me.lblNewErrorChinese.Text = "长度少于6位！" : Me.lblNewErrorEnglish.Text = "Length < 6 !"
            Me.lblNewErrorChinese.Visible = True : Me.lblNewErrorEnglish.Visible = True
            Me.txbNewPassword.Select() : Me.txbNewPassword.SelectAll()
            Me.btnOK.Enabled = False : Return
        ElseIf Me.txbNewPassword.Text = Me.txbOldPassword.Text Then
            Me.lblNewErrorChinese.Text = "和旧密码相同！" : Me.lblNewErrorEnglish.Text = "Same as old one!"
            Me.lblNewErrorChinese.Visible = True : Me.lblNewErrorEnglish.Visible = True
            Me.txbNewPassword.Select() : Me.txbNewPassword.SelectAll()
            Me.btnOK.Enabled = False : Return
        ElseIf blNewTooSimple Then
            Me.lblNewErrorChinese.Text = "密码过于简单！" : Me.lblNewErrorEnglish.Text = "Too simple!"
            Me.lblNewErrorChinese.Visible = True : Me.lblNewErrorEnglish.Visible = True
            Me.txbNewPassword.Select() : Me.txbNewPassword.SelectAll()
            Me.btnOK.Enabled = False : Return
        ElseIf Me.txbNewPassword.Text <> Me.txbConfirmedPassword.Text Then
            Me.lblConfirmedErrorChinese.Visible = True : Me.lblConfirmedErrorEnglish.Visible = True
            Me.txbConfirmedPassword.Select() : Me.txbConfirmedPassword.SelectAll()
            Me.btnOK.Enabled = False : Return
        End If

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在修改密码……"
        frmMain.statusMain.Refresh()
        Dim DB As New DataBase()
        DB.Open(True)
        If Not DB.IsConnected Then
            MessageBox.Show("系统因连接不到数据库而无法修改密码！请检查数据库连接。    ", "无法修改密码！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "无法修改密码！"
            Me.Cursor = Cursors.Default : Return
        End If

        Dim sUserCode As String = IIf(Me.cbbUser.Visible, Me.cbbUser.Text, Me.txbUser.Text.Trim), sLoginName As String = sUserCode, sSQL As String = "Exec PasswordChanging "
        If sUserCode.Length < 8 Then sUserCode = ""
        If sUserCode.IndexOf(" ") = 8 Then sUserCode = sUserCode.Substring(0, 8)
        If sUserCode <> "" Then
            Select Case sUserCode.Substring(0, 1).ToUpper
                Case "H", "T", "R", "C", "S"
                    If Not IsNumeric(sUserCode.Substring(1, 7)) Then sUserCode = ""
                Case Else
                    sUserCode = ""
            End Select
        End If
        If sUserCode = sLoginName Then
            sLoginName = ""
        ElseIf sUserCode <> "" Then
            sLoginName = sLoginName.Substring(9)
        End If

        If sUserCode <> "" Then sSQL = sSQL & "@UserCode='" & sUserCode & "',"
        If sLoginName <> "" Then sSQL = sSQL & "@LoginName='" & sLoginName.Replace("'", "''") & "',"
        sSQL = sSQL & "@OldPassword='" & SecurityText.EncryptData(Me.txbOldPassword.Text) & "',@NewPassword='" & SecurityText.EncryptData(Me.txbNewPassword.Text) & "',@ComputerName='" & frmLogin.sComputerName.Replace("'", "''") & "',@ComputerIP='" & frmLogin.sComputerIP & "',@ComputerMAC='" & frmLogin.sComputerMAC & "'"

        Dim dtResult As DataTable = DB.GetDataTable(sSQL)
        DB.Close()
        Me.txbNewPassword.Select() : Me.txbNewPassword.SelectAll()
        If dtResult Is Nothing Then
            MessageBox.Show("修改密码时出错！请联系软件开发人员。     ", "无法修改密码！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "无法修改密码！"
        ElseIf dtResult.Rows(0)(0).ToString <> "OK" Then
            frmMain.statusText.Text = "修改密码失败！"
            Select Case dtResult.Rows(0)("Reason").ToString
                Case "LoginFullName NotFound"
                    MessageBox.Show("修改密码失败！失败原因：用户不存在！    " & Chr(13) & "Changing password failure since user is not existing!    " & Chr(13) & Chr(13) & "（提示：请单独输入用户编号或修改密码名称。）    ", "修改密码失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If Me.txbUser.Visible Then Me.txbUser.Select() : Me.txbUser.SelectAll() Else Me.cbbUser.Select() : Me.cbbUser.SelectAll()
                Case "UserCode NotFound"
                    MessageBox.Show("修改密码失败！失败原因：用户编号不存在！    " & Chr(13) & "Changing password failure since user code is not existing!    ", "修改密码失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If Me.txbUser.Visible Then Me.txbUser.Select() : Me.txbUser.SelectAll() Else Me.cbbUser.Select() : Me.cbbUser.SelectAll()
                Case "LoginName NotFound"
                    MessageBox.Show("修改密码失败！失败原因：用户名称不存在！    " & Chr(13) & "Changing password failure since user name is not existing!    ", "修改密码失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If Me.txbUser.Visible Then Me.txbUser.Select() : Me.txbUser.SelectAll() Else Me.cbbUser.Select() : Me.cbbUser.SelectAll()
                Case "MultiUsers"
                    Dim dtUser As DataTable = dtResult.Copy
                    dtUser.DefaultView.Sort = "UserName"
                    Me.cbbUser.DataSource = dtUser
                    Me.cbbUser.ValueMember = "UserName"
                    Me.cbbUser.DisplayMember = "UserName"
                    Me.cbbUser.SelectedIndex = 0
                    Me.cbbUser.Visible = True : Me.txbUser.Visible = False
                    MessageBox.Show("存在多个相同用户名称但分属不同位置的用户， 请选择其中一个用户。    ", " 用户不明确。", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.cbbUser.Select()
                    Me.cbbUser.DroppedDown = True
                Case "Pending"
                    If Me.txbUser.Visible Then
                        Me.txbUser.Text = dtResult.Rows(0)("UserName").ToString : Me.txbUser.Select() : Me.txbUser.SelectAll()
                    Else
                        Me.cbbUser.Text = dtResult.Rows(0)("UserName").ToString : Me.cbbUser.Select() : Me.cbbUser.SelectAll()
                    End If
                    MessageBox.Show("修改密码失败！失败原因：该用户还未审核！    " & Chr(13) & "Changing password failure since the user is not approved yet!    " & Chr(13) & Chr(13) & "（提示：请找相应的主管审核该用户。）    ", "修改密码失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Case "Not Approved"
                    If Me.txbUser.Visible Then
                        Me.txbUser.Text = dtResult.Rows(0)("UserName").ToString : Me.txbUser.Select() : Me.txbUser.SelectAll()
                    Else
                        Me.cbbUser.Text = dtResult.Rows(0)("UserName").ToString : Me.cbbUser.Select() : Me.cbbUser.SelectAll()
                    End If
                    MessageBox.Show("修改密码失败！失败原因：该用户未通过审核！    " & Chr(13) & "Changing password failure since the user was approved failure!    ", "修改密码失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Case "Stopped"
                    If Me.txbUser.Visible Then
                        Me.txbUser.Text = dtResult.Rows(0)("UserName").ToString : Me.txbUser.Select() : Me.txbUser.SelectAll()
                    Else
                        Me.cbbUser.Text = dtResult.Rows(0)("UserName").ToString : Me.cbbUser.Select() : Me.cbbUser.SelectAll()
                    End If
                    MessageBox.Show("修改密码失败！失败原因：该用户已被停用！    " & Chr(13) & "Changing password failure since the user had been stopped!    ", "修改密码失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Case "IsTestingUser"
                    If Me.txbUser.Visible Then
                        Me.txbUser.Text = dtResult.Rows(0)("UserName").ToString : Me.txbUser.Select() : Me.txbUser.SelectAll()
                    Else
                        Me.cbbUser.Text = dtResult.Rows(0)("UserName").ToString : Me.cbbUser.Select() : Me.cbbUser.SelectAll()
                    End If
                    MessageBox.Show("该用户是测试用户，请不要修改密码！    " & Chr(13) & "Please don't change this testing user's password!    ", "修改密码失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Case Else
                    If Me.txbUser.Visible Then
                        Me.txbUser.Text = dtResult.Rows(0)("UserName").ToString
                    Else
                        Me.cbbUser.Text = dtResult.Rows(0)("UserName").ToString
                    End If
                    Me.lblOldErrorChinese.Visible = True : Me.lblOldErrorEnglish.Visible = True
                    Me.txbOldPassword.Select() : Me.txbOldPassword.SelectAll()
            End Select
            Me.btnOK.Enabled = False
            dtResult.Dispose() : dtResult = Nothing
        Else
            If Me.txbUser.Visible = True Then
                Me.txbUser.Text = dtResult.Rows(0)("UserName").ToString
            Else
                Me.cbbUser.Text = dtResult.Rows(0)("UserName").ToString
            End If
            With frmLogin
                If .txbUser.Visible = True Then
                    .txbUser.Text = dtResult.Rows(0)("UserName").ToString
                Else
                    .cbbUser.Text = dtResult.Rows(0)("UserName").ToString
                End If
            End With
            frmMain.statusText.Text = "就绪。"
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CheckStrength(ByVal sPassword As String, ByVal blCheckNew As Boolean)
        Dim bResult As Byte = 0
        If blCheckNew Then blNewTooSimple = False

        If sPassword <> "" Then
            If sPassword.Length < 6 Then
                bResult = 1 '不足6位
            Else
                Dim bDigit As Byte = 0, bLower As Byte = 0, bUpper As Byte = 0, bOther As Byte = 0, iASC As Integer
                For bChar As Byte = 0 To sPassword.Length - 1
                    iASC = Asc(sPassword.Substring(bChar, 1))
                    If iASC >= 48 AndAlso iASC <= 57 Then
                        bDigit = 1
                    ElseIf iASC >= 65 AndAlso iASC <= 90 Then
                        bUpper = 1
                    ElseIf iASC >= 97 AndAlso iASC <= 122 Then
                        bLower = 1
                    Else
                        bOther = 1
                    End If
                Next

                bResult = 1 + bDigit + bLower + bUpper + bOther
                If bResult = 2 Then '如果密码是由单一种类的字符组成
                    If sPassword = StrDup(sPassword.Length, sPassword.Substring(0, 1)) Then '由单一字符组成
                        bResult = 1
                        If blCheckNew Then blNewTooSimple = True
                    Else
                        Dim blIsContinued As Boolean = True, iFirstASC As Integer = Asc(sPassword.Substring(0, 1)), iSecondASC As Integer
                        For bChar As Byte = 1 To sPassword.Length - 1
                            iSecondASC = Asc(sPassword.Substring(bChar, 1))
                            If Math.Abs(iSecondASC - iFirstASC) = 1 Then
                                iFirstASC = iSecondASC
                            Else
                                blIsContinued = False
                                Exit For
                            End If
                        Next
                        If blIsContinued Then
                            bResult = 1
                            If blCheckNew Then blNewTooSimple = True
                        End If
                    End If
                End If
            End If
        End If

        If blCheckNew Then
            If bResult = 0 Then '空白
                Me.pnlNewStrength.Visible = False
            Else
                Me.pnlNewStrength.Visible = True
                Select Case bResult
                    Case 1 '不足6位或过于简单
                        Me.lblNewDisallowed.Visible = True
                        Me.pcbNewDisallowed.Image = My.Resources.PWStrength1
                        Me.lblNewWeak.Visible = False
                        Me.pcbNewWeak.Image = My.Resources.PWStrength0
                        Me.lblNewMedium.Visible = False
                        Me.pcbNewMedium.Image = My.Resources.PWStrength0
                        Me.lblNewStrong.Visible = False
                        Me.pcbNewStrong.Image = My.Resources.PWStrength0
                    Case 2 '弱
                        Me.lblNewDisallowed.Visible = False
                        Me.pcbNewDisallowed.Image = My.Resources.PWStrength0
                        Me.lblNewWeak.Visible = True
                        Me.pcbNewWeak.Image = My.Resources.PWStrength2
                        Me.lblNewMedium.Visible = False
                        Me.pcbNewMedium.Image = My.Resources.PWStrength0
                        Me.lblNewStrong.Visible = False
                        Me.pcbNewStrong.Image = My.Resources.PWStrength0
                    Case 3 '中
                        Me.lblNewDisallowed.Visible = False
                        Me.pcbNewDisallowed.Image = My.Resources.PWStrength0
                        Me.lblNewWeak.Visible = False
                        Me.pcbNewWeak.Image = My.Resources.PWStrength0
                        Me.lblNewMedium.Visible = True
                        Me.pcbNewMedium.Image = My.Resources.PWStrength3
                        Me.lblNewStrong.Visible = False
                        Me.pcbNewStrong.Image = My.Resources.PWStrength0
                    Case Else '强
                        Me.lblNewDisallowed.Visible = False
                        Me.pcbNewDisallowed.Image = My.Resources.PWStrength0
                        Me.lblNewWeak.Visible = False
                        Me.pcbNewWeak.Image = My.Resources.PWStrength0
                        Me.lblNewMedium.Visible = False
                        Me.pcbNewMedium.Image = My.Resources.PWStrength0
                        Me.lblNewStrong.Visible = True
                        Me.pcbNewStrong.Image = My.Resources.PWStrength4
                End Select
            End If
        Else
            If bResult = 0 Then '空白
                Me.pnlOldStrength.Visible = False
            Else
                Me.pnlOldStrength.Visible = True
                Select Case bResult
                    Case 1 '不足6位或过于简单
                        Me.lblOldDisallowed.Visible = True
                        Me.pcbOldDisallowed.Image = My.Resources.PWStrength1
                        Me.lblOldWeak.Visible = False
                        Me.pcbOldWeak.Image = My.Resources.PWStrength0
                        Me.lblOldMedium.Visible = False
                        Me.pcbOldMedium.Image = My.Resources.PWStrength0
                        Me.lblOldStrong.Visible = False
                        Me.pcbOldStrong.Image = My.Resources.PWStrength0
                    Case 2 '弱
                        Me.lblOldDisallowed.Visible = False
                        Me.pcbOldDisallowed.Image = My.Resources.PWStrength0
                        Me.lblOldWeak.Visible = True
                        Me.pcbOldWeak.Image = My.Resources.PWStrength2
                        Me.lblOldMedium.Visible = False
                        Me.pcbOldMedium.Image = My.Resources.PWStrength0
                        Me.lblOldStrong.Visible = False
                        Me.pcbOldStrong.Image = My.Resources.PWStrength0
                    Case 3 '中
                        Me.lblOldDisallowed.Visible = False
                        Me.pcbOldDisallowed.Image = My.Resources.PWStrength0
                        Me.lblOldWeak.Visible = False
                        Me.pcbOldWeak.Image = My.Resources.PWStrength0
                        Me.lblOldMedium.Visible = True
                        Me.pcbOldMedium.Image = My.Resources.PWStrength3
                        Me.lblOldStrong.Visible = False
                        Me.pcbOldStrong.Image = My.Resources.PWStrength0
                    Case Else '强
                        Me.lblOldDisallowed.Visible = False
                        Me.pcbOldDisallowed.Image = My.Resources.PWStrength0
                        Me.lblOldWeak.Visible = False
                        Me.pcbOldWeak.Image = My.Resources.PWStrength0
                        Me.lblOldMedium.Visible = False
                        Me.pcbOldMedium.Image = My.Resources.PWStrength0
                        Me.lblOldStrong.Visible = True
                        Me.pcbOldStrong.Image = My.Resources.PWStrength4
                End Select
            End If
        End If
    End Sub
End Class