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
            Me.lblNewErrorChinese.Text = "��������6λ��" : Me.lblNewErrorEnglish.Text = "Length < 6 !"
            Me.lblNewErrorChinese.Visible = True : Me.lblNewErrorEnglish.Visible = True
            Me.txbNewPassword.Select() : Me.txbNewPassword.SelectAll()
            Me.btnOK.Enabled = False : Return
        ElseIf Me.txbNewPassword.Text = Me.txbOldPassword.Text Then
            Me.lblNewErrorChinese.Text = "�;�������ͬ��" : Me.lblNewErrorEnglish.Text = "Same as old one!"
            Me.lblNewErrorChinese.Visible = True : Me.lblNewErrorEnglish.Visible = True
            Me.txbNewPassword.Select() : Me.txbNewPassword.SelectAll()
            Me.btnOK.Enabled = False : Return
        ElseIf blNewTooSimple Then
            Me.lblNewErrorChinese.Text = "������ڼ򵥣�" : Me.lblNewErrorEnglish.Text = "Too simple!"
            Me.lblNewErrorChinese.Visible = True : Me.lblNewErrorEnglish.Visible = True
            Me.txbNewPassword.Select() : Me.txbNewPassword.SelectAll()
            Me.btnOK.Enabled = False : Return
        ElseIf Me.txbNewPassword.Text <> Me.txbConfirmedPassword.Text Then
            Me.lblConfirmedErrorChinese.Visible = True : Me.lblConfirmedErrorEnglish.Visible = True
            Me.txbConfirmedPassword.Select() : Me.txbConfirmedPassword.SelectAll()
            Me.btnOK.Enabled = False : Return
        End If

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "�����޸����롭��"
        frmMain.statusMain.Refresh()
        Dim DB As New DataBase()
        DB.Open(True)
        If Not DB.IsConnected Then
            MessageBox.Show("ϵͳ�����Ӳ������ݿ���޷��޸����룡�������ݿ����ӡ�    ", "�޷��޸����룡", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "�޷��޸����룡"
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
            MessageBox.Show("�޸�����ʱ��������ϵ���������Ա��     ", "�޷��޸����룡", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "�޷��޸����룡"
        ElseIf dtResult.Rows(0)(0).ToString <> "OK" Then
            frmMain.statusText.Text = "�޸�����ʧ�ܣ�"
            Select Case dtResult.Rows(0)("Reason").ToString
                Case "LoginFullName NotFound"
                    MessageBox.Show("�޸�����ʧ�ܣ�ʧ��ԭ���û������ڣ�    " & Chr(13) & "Changing password failure since user is not existing!    " & Chr(13) & Chr(13) & "����ʾ���뵥�������û���Ż��޸��������ơ���    ", "�޸�����ʧ�ܣ�", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If Me.txbUser.Visible Then Me.txbUser.Select() : Me.txbUser.SelectAll() Else Me.cbbUser.Select() : Me.cbbUser.SelectAll()
                Case "UserCode NotFound"
                    MessageBox.Show("�޸�����ʧ�ܣ�ʧ��ԭ���û���Ų����ڣ�    " & Chr(13) & "Changing password failure since user code is not existing!    ", "�޸�����ʧ�ܣ�", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If Me.txbUser.Visible Then Me.txbUser.Select() : Me.txbUser.SelectAll() Else Me.cbbUser.Select() : Me.cbbUser.SelectAll()
                Case "LoginName NotFound"
                    MessageBox.Show("�޸�����ʧ�ܣ�ʧ��ԭ���û����Ʋ����ڣ�    " & Chr(13) & "Changing password failure since user name is not existing!    ", "�޸�����ʧ�ܣ�", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If Me.txbUser.Visible Then Me.txbUser.Select() : Me.txbUser.SelectAll() Else Me.cbbUser.Select() : Me.cbbUser.SelectAll()
                Case "MultiUsers"
                    Dim dtUser As DataTable = dtResult.Copy
                    dtUser.DefaultView.Sort = "UserName"
                    Me.cbbUser.DataSource = dtUser
                    Me.cbbUser.ValueMember = "UserName"
                    Me.cbbUser.DisplayMember = "UserName"
                    Me.cbbUser.SelectedIndex = 0
                    Me.cbbUser.Visible = True : Me.txbUser.Visible = False
                    MessageBox.Show("���ڶ����ͬ�û����Ƶ�������ͬλ�õ��û��� ��ѡ������һ���û���    ", " �û�����ȷ��", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.cbbUser.Select()
                    Me.cbbUser.DroppedDown = True
                Case "Pending"
                    If Me.txbUser.Visible Then
                        Me.txbUser.Text = dtResult.Rows(0)("UserName").ToString : Me.txbUser.Select() : Me.txbUser.SelectAll()
                    Else
                        Me.cbbUser.Text = dtResult.Rows(0)("UserName").ToString : Me.cbbUser.Select() : Me.cbbUser.SelectAll()
                    End If
                    MessageBox.Show("�޸�����ʧ�ܣ�ʧ��ԭ�򣺸��û���δ��ˣ�    " & Chr(13) & "Changing password failure since the user is not approved yet!    " & Chr(13) & Chr(13) & "����ʾ��������Ӧ��������˸��û�����    ", "�޸�����ʧ�ܣ�", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Case "Not Approved"
                    If Me.txbUser.Visible Then
                        Me.txbUser.Text = dtResult.Rows(0)("UserName").ToString : Me.txbUser.Select() : Me.txbUser.SelectAll()
                    Else
                        Me.cbbUser.Text = dtResult.Rows(0)("UserName").ToString : Me.cbbUser.Select() : Me.cbbUser.SelectAll()
                    End If
                    MessageBox.Show("�޸�����ʧ�ܣ�ʧ��ԭ�򣺸��û�δͨ����ˣ�    " & Chr(13) & "Changing password failure since the user was approved failure!    ", "�޸�����ʧ�ܣ�", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Case "Stopped"
                    If Me.txbUser.Visible Then
                        Me.txbUser.Text = dtResult.Rows(0)("UserName").ToString : Me.txbUser.Select() : Me.txbUser.SelectAll()
                    Else
                        Me.cbbUser.Text = dtResult.Rows(0)("UserName").ToString : Me.cbbUser.Select() : Me.cbbUser.SelectAll()
                    End If
                    MessageBox.Show("�޸�����ʧ�ܣ�ʧ��ԭ�򣺸��û��ѱ�ͣ�ã�    " & Chr(13) & "Changing password failure since the user had been stopped!    ", "�޸�����ʧ�ܣ�", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Case "IsTestingUser"
                    If Me.txbUser.Visible Then
                        Me.txbUser.Text = dtResult.Rows(0)("UserName").ToString : Me.txbUser.Select() : Me.txbUser.SelectAll()
                    Else
                        Me.cbbUser.Text = dtResult.Rows(0)("UserName").ToString : Me.cbbUser.Select() : Me.cbbUser.SelectAll()
                    End If
                    MessageBox.Show("���û��ǲ����û����벻Ҫ�޸����룡    " & Chr(13) & "Please don't change this testing user's password!    ", "�޸�����ʧ�ܣ�", MessageBoxButtons.OK, MessageBoxIcon.Stop)
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
            frmMain.statusText.Text = "������"
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CheckStrength(ByVal sPassword As String, ByVal blCheckNew As Boolean)
        Dim bResult As Byte = 0
        If blCheckNew Then blNewTooSimple = False

        If sPassword <> "" Then
            If sPassword.Length < 6 Then
                bResult = 1 '����6λ
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
                If bResult = 2 Then '����������ɵ�һ������ַ����
                    If sPassword = StrDup(sPassword.Length, sPassword.Substring(0, 1)) Then '�ɵ�һ�ַ����
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
            If bResult = 0 Then '�հ�
                Me.pnlNewStrength.Visible = False
            Else
                Me.pnlNewStrength.Visible = True
                Select Case bResult
                    Case 1 '����6λ����ڼ�
                        Me.lblNewDisallowed.Visible = True
                        Me.pcbNewDisallowed.Image = My.Resources.PWStrength1
                        Me.lblNewWeak.Visible = False
                        Me.pcbNewWeak.Image = My.Resources.PWStrength0
                        Me.lblNewMedium.Visible = False
                        Me.pcbNewMedium.Image = My.Resources.PWStrength0
                        Me.lblNewStrong.Visible = False
                        Me.pcbNewStrong.Image = My.Resources.PWStrength0
                    Case 2 '��
                        Me.lblNewDisallowed.Visible = False
                        Me.pcbNewDisallowed.Image = My.Resources.PWStrength0
                        Me.lblNewWeak.Visible = True
                        Me.pcbNewWeak.Image = My.Resources.PWStrength2
                        Me.lblNewMedium.Visible = False
                        Me.pcbNewMedium.Image = My.Resources.PWStrength0
                        Me.lblNewStrong.Visible = False
                        Me.pcbNewStrong.Image = My.Resources.PWStrength0
                    Case 3 '��
                        Me.lblNewDisallowed.Visible = False
                        Me.pcbNewDisallowed.Image = My.Resources.PWStrength0
                        Me.lblNewWeak.Visible = False
                        Me.pcbNewWeak.Image = My.Resources.PWStrength0
                        Me.lblNewMedium.Visible = True
                        Me.pcbNewMedium.Image = My.Resources.PWStrength3
                        Me.lblNewStrong.Visible = False
                        Me.pcbNewStrong.Image = My.Resources.PWStrength0
                    Case Else 'ǿ
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
            If bResult = 0 Then '�հ�
                Me.pnlOldStrength.Visible = False
            Else
                Me.pnlOldStrength.Visible = True
                Select Case bResult
                    Case 1 '����6λ����ڼ�
                        Me.lblOldDisallowed.Visible = True
                        Me.pcbOldDisallowed.Image = My.Resources.PWStrength1
                        Me.lblOldWeak.Visible = False
                        Me.pcbOldWeak.Image = My.Resources.PWStrength0
                        Me.lblOldMedium.Visible = False
                        Me.pcbOldMedium.Image = My.Resources.PWStrength0
                        Me.lblOldStrong.Visible = False
                        Me.pcbOldStrong.Image = My.Resources.PWStrength0
                    Case 2 '��
                        Me.lblOldDisallowed.Visible = False
                        Me.pcbOldDisallowed.Image = My.Resources.PWStrength0
                        Me.lblOldWeak.Visible = True
                        Me.pcbOldWeak.Image = My.Resources.PWStrength2
                        Me.lblOldMedium.Visible = False
                        Me.pcbOldMedium.Image = My.Resources.PWStrength0
                        Me.lblOldStrong.Visible = False
                        Me.pcbOldStrong.Image = My.Resources.PWStrength0
                    Case 3 '��
                        Me.lblOldDisallowed.Visible = False
                        Me.pcbOldDisallowed.Image = My.Resources.PWStrength0
                        Me.lblOldWeak.Visible = False
                        Me.pcbOldWeak.Image = My.Resources.PWStrength0
                        Me.lblOldMedium.Visible = True
                        Me.pcbOldMedium.Image = My.Resources.PWStrength3
                        Me.lblOldStrong.Visible = False
                        Me.pcbOldStrong.Image = My.Resources.PWStrength0
                    Case Else 'ǿ
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