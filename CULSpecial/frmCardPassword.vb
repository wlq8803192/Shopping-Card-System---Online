Public Class frmCardPassword

    'modify code 033:
    'date;2014/7/24
    'auther:Hyron bjy 
    'remark:更改特殊操作用户登录验证方式为guid

    'modify code 047:
    'date;2014/5/11
    'auther:Hyron qm 
    'remark:实名制卡特殊操作

    'modify code 050:
    'date;2015/11/1
    'auther:Hyron wzh 
    'remark:增加旧实名制卡和新实名制卡操作

    Private dvCULParameter As DataView

    'modify code 033:start-------------------------------------------------------------------------
    Dim guIDClass As C4ShoppingCardService.GuIDClass
    'modify code 033:end-------------------------------------------------------------------------

    'modify code 047:start-------------------------------------------------------------------------
    Public isSignCard As Boolean = False
    Public signCardNo As String
    'modify code 047:end-------------------------------------------------------------------------

    Private Sub frmCardPassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dvCULParameter = frmMain.dtLoginStructure.Copy.DefaultView
        dvCULParameter.RowFilter = "AreaType='S'"
        dvCULParameter = dvCULParameter.ToTable(False, "AreaID", "CULCardBin", "CULStoreCode").DefaultView
        dvCULParameter.RowFilter = "CULCardBin Like '%|%'"
        For Each drCUL As DataRowView In dvCULParameter
            Dim saCardBins() As String = drCUL("CULCardBin").ToString.Split("|")
            For bIndex As Byte = 0 To saCardBins.Length - 1
                dvCULParameter.Table.Rows.Add(drCUL("AreaID"), saCardBins(bIndex), drCUL("CULStoreCode")).EndEdit()
            Next
        Next
        For Each drCUL As DataRow In dvCULParameter.Table.Select("CULCardBin Like '84%'")
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "60" & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "92" & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "94" & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()

            'modify code 050:start-------------------------------------------------------------------------
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), frmMain.signCardBin & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
            'modify code 050:end-------------------------------------------------------------------------
        Next
        dvCULParameter.RowFilter = ""
        dvCULParameter.Table.AcceptChanges()

        Me.tabPassword.SelectTab(0)
        Me.txbCardNo1.Select()

        'modify code 047:start-------------------------------------------------------------------------
        If isSignCard Then
            Me.txbCardNo1.Text = signCardNo
            txbCardNo1_Leave(Nothing, Nothing)
            Me.txbCardNo2.Text = signCardNo
            txbCardNo2_Leave(Nothing, Nothing)
        End If
        'modify code 047:end-------------------------------------------------------------------------
    End Sub

    Private Sub tabPassword_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabPassword.SelectedIndexChanged
        Me.lblResult1.Text = "" : Me.lblResult2.Text = ""
        If Me.tabPassword.SelectedIndex = 0 Then
            Me.lblResult1.Visible = True
            Me.lblResult2.Visible = False
            Me.btnExcute.Text = "到CUL重置密码(&E)"
            If Me.txbCardNo1.Text.Trim <> "" AndAlso Me.lblCardNoError1.Text = "" AndAlso Me.txbNewPW1.Text.Trim <> "" AndAlso Me.lblNewPWError1.Text = "" AndAlso Me.txbConfirmedPW1.Text <> "" AndAlso Me.lblConfirmedPWError1.Text = "" Then
                Me.btnExcute.Enabled = True
                Me.btnExcute.Select()
            Else
                Me.btnExcute.Enabled = False
                If Me.txbCardNo1.Text = "" OrElse Me.lblCardNoError1.Text <> "" Then
                    Me.txbCardNo1.Select() : Me.txbCardNo1.SelectAll()
                ElseIf Me.txbNewPW1.Text.Trim = "" OrElse Me.lblNewPWError1.Text <> "" Then
                    Me.txbNewPW1.Select() : Me.txbNewPW1.SelectAll()
                Else
                    Me.txbConfirmedPW1.Select() : Me.txbConfirmedPW1.SelectAll()
                End If
            End If
        Else
            Me.lblResult1.Visible = False
            Me.lblResult2.Visible = True
            Me.btnExcute.Text = "到CUL修改密码(&E)"
            If Me.txbCardNo2.Text.Trim <> "" AndAlso Me.lblCardNoError2.Text = "" AndAlso Me.txbOldPW.Text <> "" AndAlso Me.lblOldPWError.Text = "" AndAlso Me.txbConfirmedPW2.Text <> "" AndAlso Me.lblConfirmedPWError2.Text = "" Then
                Me.btnExcute.Enabled = True
                Me.btnExcute.Select()
            Else
                Me.btnExcute.Enabled = False
                If Me.txbCardNo2.Text = "" OrElse Me.lblCardNoError2.Text <> "" Then
                    Me.txbCardNo2.Select() : Me.txbCardNo2.SelectAll()
                ElseIf Me.txbOldPW.Text.Trim = "" OrElse Me.lblOldPWError.Text <> "" Then
                    Me.txbOldPW.Select() : Me.txbOldPW.SelectAll()
                ElseIf Me.txbNewPW2.Text.Trim = "" OrElse Me.lblNewPWError2.Text <> "" Then
                    Me.txbNewPW2.Select() : Me.txbNewPW2.SelectAll()
                Else
                    Me.txbConfirmedPW2.Select() : Me.txbConfirmedPW2.SelectAll()
                End If
            End If
        End If
    End Sub

    Private Sub txbCardNo1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbCardNo1.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then
            Me.btnCancel.Select() : Me.txbCardNo1.Select()
            If Me.pnlResetPW.Enabled Then Me.txbNewPW1.Select() : Me.txbNewPW1.SelectAll()
            e.SuppressKeyPress = True : Return
        End If

        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If Me.txbCardNo1.SelectedText = Me.txbCardNo1.Text Then Me.txbCardNo1.Text = ""
            Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbCardNo1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbCardNo1.Leave
        If Me.txbCardNo1.Text <> Me.txbCardNo1.Text.Trim Then Me.txbCardNo1.Text = Me.txbCardNo1.Text.Trim
        Dim sValue As String = Me.txbCardNo1.Text

        If sValue <> "" Then
            If Not IsNumeric(sValue) Then
                Me.lblCardNoError1.Text = "（卡号只能由数字组成！）"
            ElseIf sValue.Length < 19 Then
                Me.lblCardNoError1.Text = "（卡号位数不足 19 位！）"
            ElseIf sValue <> ShoppingCardNo.GetFullCardNo(sValue.Substring(0, 18)) Then
                Me.lblCardNoError1.Text = "（卡号校验码错误！）"
            ElseIf dvCULParameter.Table.Select("CULCardBin='" & sValue.Substring(4, 5) & "'").Length = 0 Then
                Me.lblCardNoError1.Text = "（无权操作该卡段！）"
            End If
        End If

        If Me.tabPassword.SelectedIndex = 1 OrElse Me.ActiveControl.Name = "tabPassword" Then Return
        If sValue = "" OrElse Me.lblCardNoError1.Text <> "" Then
            Me.txbCardNo1.Select() : Me.txbCardNo1.SelectAll()
            Me.pnlResetPW.Enabled = False
            Me.btnExcute.Enabled = False
        End If
    End Sub

    Private Sub txbCardNo1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbCardNo1.TextChanged
        Me.lblCardNoError1.Text = "" : Me.lblResult1.Text = ""
        Dim sValue As String = Me.txbCardNo1.Text
        If sValue.Length = 19 Then
            Me.btnCancel.Select()
            Me.txbCardNo1.Select()
            Me.txbCardNo1.SelectAll()
        End If
        If sValue.Length = 19 AndAlso IsNumeric(sValue) AndAlso sValue = ShoppingCardNo.GetFullCardNo(sValue.Substring(0, 18)) AndAlso dvCULParameter.Table.Select("CULCardBin='" & sValue.Substring(4, 5) & "'").Length > 0 Then
            Me.pnlResetPW.Enabled = True
            If Me.txbNewPW1.Text <> "" AndAlso Me.lblNewPWError1.Text = "" AndAlso Me.txbConfirmedPW1.Text <> "" AndAlso Me.lblNewPWError1.Text = "" Then
                Me.btnExcute.Enabled = True
            Else
                Me.btnExcute.Enabled = False
            End If
        Else
            Me.pnlResetPW.Enabled = False
            Me.btnExcute.Enabled = False
        End If
    End Sub

    Private Sub txbNewPW1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbNewPW1.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter AndAlso Me.txbNewPW1.Text.Length = 6 AndAlso IsNumeric(Me.txbNewPW1.Text) Then Me.txbConfirmedPW1.Select() : Me.txbConfirmedPW1.SelectAll() : e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If Me.txbNewPW1.SelectedText = Me.txbNewPW1.Text Then Me.txbNewPW1.Text = ""
            Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbNewPW1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbNewPW1.Leave
        Dim sValue As String = Me.txbNewPW1.Text

        If sValue <> "" AndAlso (Not IsNumeric(sValue) OrElse sValue.Length <> 6) Then
            Me.lblNewPWError1.Text = "（卡新密码必须由 6 位数字组成！）"
        End If

        If Me.tabPassword.SelectedIndex = 1 OrElse Me.ActiveControl.Name = "tabPassword" OrElse Me.ActiveControl.Name = "txbCardNo1" Then Return
        If Me.lblNewPWError1.Text <> "" Then
            Me.txbNewPW1.Select() : Me.txbNewPW1.SelectAll()
            Me.btnExcute.Enabled = False
        End If
    End Sub

    Private Sub txbNewPW1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbNewPW1.TextChanged
        Me.lblNewPWError1.Text = "" : Me.txbConfirmedPW1.Text = "" : Me.lblConfirmedPWError1.Text = "" : Me.lblResult1.Text = ""
        Dim sValue As String = Me.txbNewPW1.Text
        If sValue.Length = 6 AndAlso IsNumeric(sValue) AndAlso sValue = Me.txbConfirmedPW1.Text Then
            Me.btnExcute.Enabled = True
        Else
            Me.btnExcute.Enabled = False
        End If
    End Sub

    Private Sub txbConfirmedPW1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbConfirmedPW1.Enter
        If Me.txbNewPW1.Text = "" Then Me.txbNewPW1.Select()
    End Sub

    Private Sub txbConfirmedPW1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbConfirmedPW1.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then Me.txbNewPW1.Select() : Me.txbNewPW1.SelectAll() : e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If Me.txbConfirmedPW1.SelectedText = Me.txbConfirmedPW1.Text Then Me.txbConfirmedPW1.Text = ""
            Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbConfirmedPW1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbConfirmedPW1.Leave
        Dim sValue As String = Me.txbConfirmedPW1.Text

        If sValue = "" Then
            Me.lblConfirmedPWError1.Text = "（确认密码不能为空！）"
        ElseIf sValue <> Me.txbNewPW1.Text Then
            Me.lblConfirmedPWError1.Text = "（与新密码不一致！）"
        End If

        If Me.tabPassword.SelectedIndex = 1 OrElse Me.ActiveControl.Name = "tabPassword" OrElse Me.ActiveControl.Name = "txbCardNo1" Then Return
        If sValue = "" OrElse Me.lblConfirmedPWError1.Text <> "" Then
            Me.btnExcute.Enabled = False
        End If
    End Sub

    Private Sub txbConfirmedPW1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbConfirmedPW1.TextChanged
        Me.lblConfirmedPWError1.Text = "" : Me.lblResult1.Text = ""
        Dim sValue As String = Me.txbConfirmedPW1.Text
        If sValue = Me.txbNewPW1.Text Then
            Me.btnExcute.Enabled = True
        Else
            Me.btnExcute.Enabled = False
        End If
    End Sub

    Private Sub txbCardNo2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbCardNo2.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then
            Me.btnCancel.Select() : Me.txbCardNo2.Select()
            If Me.pnlChangePW.Enabled Then Me.txbOldPW.Select() : Me.txbOldPW.SelectAll()
            e.SuppressKeyPress = True : Return
        End If
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If Me.txbCardNo2.SelectedText = Me.txbCardNo2.Text Then Me.txbCardNo2.Text = ""
            Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbCardNo2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbCardNo2.Leave
        If Me.txbCardNo2.Text <> Me.txbCardNo2.Text.Trim Then Me.txbCardNo2.Text = Me.txbCardNo2.Text.Trim
        Dim sValue As String = Me.txbCardNo2.Text

        If sValue <> "" Then
            If Not IsNumeric(sValue) Then
                Me.lblCardNoError2.Text = "（卡号只能由数字组成！）"
            ElseIf sValue.Length < 19 Then
                Me.lblCardNoError2.Text = "（卡号位数不足 19 位！）"
            ElseIf sValue <> ShoppingCardNo.GetFullCardNo(sValue.Substring(0, 18)) Then
                Me.lblCardNoError2.Text = "（卡号校验码错误！）"
            ElseIf dvCULParameter.Table.Select("CULCardBin='" & sValue.Substring(4, 5) & "'").Length = 0 Then
                Me.lblCardNoError2.Text = "（无权操作该卡段！）"
            End If
        End If

        If Me.tabPassword.SelectedIndex = 0 OrElse Me.ActiveControl.Name = "tabPassword" Then Return
        If sValue = "" OrElse Me.lblCardNoError2.Text <> "" Then
            Me.txbCardNo2.Select() : Me.txbCardNo2.SelectAll()
            Me.pnlChangePW.Enabled = False
            Me.btnExcute.Enabled = False
        End If
    End Sub

    Private Sub txbCardNo2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbCardNo2.TextChanged
        Me.lblCardNoError2.Text = "" : Me.lblResult2.Text = ""
        If Me.lblOldPWError.Text = "（卡原密码错误！）" Then Me.lblOldPWError.Text = ""
        Dim sValue As String = Me.txbCardNo2.Text
        If sValue.Length = 19 Then
            Me.btnCancel.Select()
            Me.txbCardNo2.Select()
            Me.txbCardNo2.SelectAll()
        End If
        If sValue.Length = 19 AndAlso IsNumeric(sValue) AndAlso sValue = ShoppingCardNo.GetFullCardNo(sValue.Substring(0, 18)) AndAlso dvCULParameter.Table.Select("CULCardBin='" & sValue.Substring(4, 5) & "'").Length > 0 Then
            Me.pnlChangePW.Enabled = True
            If Me.txbOldPW.Text <> "" AndAlso Me.lblOldPWError.Text = "" AndAlso Me.txbNewPW2.Text <> "" AndAlso Me.lblNewPWError2.Text = "" AndAlso Me.txbConfirmedPW2.Text <> "" AndAlso Me.lblNewPWError2.Text = "" Then
                Me.btnExcute.Enabled = True
            Else
                Me.btnExcute.Enabled = False
            End If
        Else
            Me.pnlChangePW.Enabled = False
            Me.btnExcute.Enabled = False
        End If
    End Sub

    Private Sub txbOldPW_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbOldPW.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter AndAlso Me.txbOldPW.Text.Length = 6 AndAlso IsNumeric(Me.txbOldPW.Text) AndAlso Me.lblOldPWError.Text <> "（卡原密码错误！）" Then Me.txbNewPW2.Select() : Me.txbNewPW2.SelectAll() : e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If Me.txbOldPW.SelectedText = Me.txbOldPW.Text Then Me.txbOldPW.Text = ""
            Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbOldPW_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbOldPW.Leave
        Dim sValue As String = Me.txbOldPW.Text

        If sValue <> "" AndAlso (Not IsNumeric(sValue) OrElse sValue.Length <> 6) Then
            Me.lblOldPWError.Text = "（卡原密码必须由 6 位数字组成！）"
        ElseIf sValue <> "" AndAlso sValue = Me.txbNewPW2.Text Then
            Me.lblNewPWError2.Text = "（卡新密码不能与卡原密码相同！）"
        End If

        If Me.tabPassword.SelectedIndex = 0 OrElse Me.ActiveControl.Name = "tabPassword" OrElse Me.ActiveControl.Name = "txbCardNo2" Then Return
        If Me.lblOldPWError.Text <> "" Then
            Me.txbOldPW.Select() : Me.txbOldPW.SelectAll()
            Me.btnExcute.Enabled = False
        ElseIf Me.lblNewPWError2.Text <> "" Then
            Me.txbNewPW2.Select() : Me.txbNewPW2.SelectAll()
            Me.btnExcute.Enabled = False
        End If
    End Sub

    Private Sub txbOldPW_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbOldPW.TextChanged
        Me.lblOldPWError.Text = "" : Me.lblResult2.Text = ""
        Dim sValue As String = Me.txbNewPW2.Text
        If Me.txbOldPW.Text.Length = 6 AndAlso IsNumeric(Me.txbOldPW.Text) AndAlso sValue.Length = 6 AndAlso IsNumeric(sValue) AndAlso sValue = Me.txbConfirmedPW2.Text Then
            Me.btnExcute.Enabled = True
        Else
            Me.btnExcute.Enabled = False
        End If
    End Sub

    Private Sub txbNewPW2_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbNewPW2.Enter
        If Me.txbOldPW.Text = "" Then Me.txbOldPW.Select()
    End Sub

    Private Sub txbNewPW2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbNewPW2.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter AndAlso Me.txbNewPW2.Text.Length = 6 AndAlso IsNumeric(Me.txbNewPW2.Text) Then Me.txbConfirmedPW2.Select() : Me.txbConfirmedPW2.SelectAll() : e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If Me.txbNewPW2.SelectedText = Me.txbNewPW2.Text Then Me.txbNewPW2.Text = ""
            Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbNewPW2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbNewPW2.Leave
        Dim sValue As String = Me.txbNewPW2.Text

        If sValue <> "" AndAlso (Not IsNumeric(sValue) OrElse sValue.Length <> 6) Then
            Me.lblNewPWError2.Text = "（卡新密码必须由 6 位数字组成！）"
        ElseIf sValue <> "" AndAlso sValue = Me.txbOldPW.Text Then
            Me.lblNewPWError2.Text = "（卡新密码不能与卡原密码相同！）"
        End If

        If Me.tabPassword.SelectedIndex = 0 OrElse Me.ActiveControl.Name = "tabPassword" OrElse Me.ActiveControl.Name = "txbCardNo2" Then Return
        If Me.lblNewPWError2.Text <> "" Then
            Me.txbNewPW2.Select() : Me.txbNewPW2.SelectAll()
            Me.btnExcute.Enabled = False
        End If
    End Sub

    Private Sub txbNewPW2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbNewPW2.TextChanged
        Me.lblNewPWError2.Text = "" : Me.txbConfirmedPW2.Text = "" : Me.lblConfirmedPWError2.Text = "" : Me.lblResult2.Text = ""
        Dim sValue As String = Me.txbNewPW2.Text
        If Me.txbOldPW.Text.Length = 6 AndAlso IsNumeric(Me.txbOldPW.Text) AndAlso sValue.Length = 6 AndAlso IsNumeric(sValue) AndAlso sValue <> Me.txbOldPW.Text AndAlso sValue = Me.txbConfirmedPW2.Text Then
            Me.btnExcute.Enabled = True
        Else
            Me.btnExcute.Enabled = False
        End If
    End Sub

    Private Sub txbConfirmedPW2_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbConfirmedPW2.Enter
        If Me.txbNewPW2.Text = "" Then Me.txbNewPW2.Select()
    End Sub

    Private Sub txbConfirmedPW2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbConfirmedPW2.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then Me.txbOldPW.Select() : Me.txbOldPW.SelectAll() : e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If Me.txbConfirmedPW2.SelectedText = Me.txbConfirmedPW2.Text Then Me.txbConfirmedPW2.Text = ""
            Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbConfirmedPW2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbConfirmedPW2.Leave
        Dim sValue As String = Me.txbConfirmedPW2.Text

        If sValue = "" Then
            Me.lblConfirmedPWError2.Text = "（确认密码不能为空！）"
        ElseIf sValue <> Me.txbNewPW2.Text Then
            Me.lblConfirmedPWError2.Text = "（与新密码不一致！）"
        End If

        If Me.tabPassword.SelectedIndex = 0 OrElse Me.ActiveControl.Name = "tabPassword" OrElse Me.ActiveControl.Name = "txbCardNo2" Then Return
        If sValue = "" OrElse Me.lblConfirmedPWError2.Text <> "" Then
            Me.btnExcute.Enabled = False
        End If
    End Sub

    Private Sub txbConfirmedPW2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbConfirmedPW2.TextChanged
        Me.lblConfirmedPWError2.Text = "" : Me.lblResult2.Text = ""
        Dim sValue As String = Me.txbConfirmedPW2.Text
        If Me.txbOldPW.Text.Length = 6 AndAlso IsNumeric(Me.txbOldPW.Text) AndAlso sValue = Me.txbNewPW2.Text Then
            Me.btnExcute.Enabled = True
        Else
            Me.btnExcute.Enabled = False
        End If
    End Sub

    Private Sub btnExcute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcute.Click
        Me.Cursor = Cursors.WaitCursor
        Dim c4Service As C4ShoppingCardService.C4ShoppingCardService = Nothing, msg As C4ShoppingCardService.CodeMsg = Nothing, sMerchantNo As String, sOperation As String = ""

        'modify code 033:start-------------------------------------------------------------------------
        guIDClass = New C4ShoppingCardService.GuIDClass
        guIDClass.GuID = frmMain.sGuID
        'modify code 033:end-------------------------------------------------------------------------

        If Me.tabPassword.SelectedIndex = 0 Then
            Me.lblResult1.ForeColor = SystemColors.ControlText
            Me.lblResult1.Text = "正在到CUL执行重置购物卡密码操作，请稍候……"
            Me.Refresh()

            Try
                c4Service = New C4ShoppingCardService.C4ShoppingCardService
                Dim rstpClass As New C4ShoppingCardService.RstpClass
                sMerchantNo = dvCULParameter.Table.Select("CULCardBin='" & Me.txbCardNo1.Text.Substring(4, 5) & "'")(0)("CULStoreCode").ToString
                rstpClass.MerchantNo = sMerchantNo
                rstpClass.UserId = sMerchantNo
                rstpClass.CardNo = Me.txbCardNo1.Text
                rstpClass.Password = Me.txbNewPW1.Text
                'modify code 033:start-------------------------------------------------------------------------
                msg = c4Service.rstp(rstpClass, guIDClass)
                'modify code 033:end-------------------------------------------------------------------------

                If msg.Code.ToUpper = "QZ" Then
                    sOperation = "Reset Shopping Card's Password: Card No.: " & Me.txbCardNo1.Text & "  Password: " & Me.txbNewPW1.Text
                    Me.txbNewPW1.Text = "" : Me.txbConfirmedPW1.Text = ""
                    Me.lblResult1.Text = "重置购物卡密码成功。"
                Else
                    Me.lblResult1.ForeColor = Color.Red
                    Me.lblResult1.Text = "重置密码时出现错误！错误提示：" & msg.Msg
                End If

                Me.btnExcute.Enabled = False
                msg = Nothing : rstpClass = Nothing
            Catch ex As Exception
                Me.lblResult1.ForeColor = Color.Red
                Me.lblResult1.Text = "重置密码时出现错误！错误提示：" & ex.Message
            Finally
                If c4Service IsNot Nothing Then c4Service.Dispose() : c4Service = Nothing
            End Try
        Else
            Me.lblResult2.ForeColor = SystemColors.ControlText
            Me.lblResult2.Text = "正在到CUL执行修改购物卡密码操作，请稍候……"
            Me.Refresh()

            Try
                c4Service = New C4ShoppingCardService.C4ShoppingCardService
                Dim updpClass As New C4ShoppingCardService.UpdpClass
                sMerchantNo = dvCULParameter.Table.Select("CULCardBin='" & Me.txbCardNo1.Text.Substring(4, 5) & "'")(0)("CULStoreCode").ToString
                updpClass.MerchantNo = sMerchantNo
                updpClass.UserId = sMerchantNo
                updpClass.CardNo = Me.txbCardNo2.Text
                updpClass.OldPassword = Me.txbOldPW.Text
                updpClass.NewPassword = Me.txbNewPW2.Text
                'modify code 033:start-------------------------------------------------------------------------
                msg = c4Service.updp(updpClass, guIDClass)
                'modify code 033:end-------------------------------------------------------------------------

                If msg.Code.ToUpper = "RZ" Then
                    sOperation = "Change Shopping Card's Password: Card No.: " & Me.txbCardNo1.Text & "  Old Password: " & Me.txbOldPW.Text & "  New Password: " & Me.txbNewPW2.Text
                    Me.txbOldPW.Text = "" : Me.txbNewPW2.Text = "" : Me.txbConfirmedPW2.Text = ""
                    Me.lblResult2.Text = "修改购物卡密码成功。"
                Else
                    If msg.Code = "RM" Then Me.lblOldPWError.Text = "（卡原密码错误！）"
                    Me.lblResult2.ForeColor = Color.Red
                    Me.lblResult2.Text = "修改密码时出现错误！错误提示：" & msg.Msg
                End If

                Me.btnExcute.Enabled = False
                msg = Nothing : updpClass = Nothing
            Catch ex As Exception
                Me.lblResult2.ForeColor = Color.Red
                Me.lblResult2.Text = "重置密码时出现错误！错误提示：" & ex.Message
            Finally
                If c4Service IsNot Nothing Then c4Service.Dispose() : c4Service = Nothing
            End Try
        End If

        If sOperation <> "" Then
            Dim DB As New DataBase
            DB.Open()
            If DB.IsConnected Then
                DB.ModifyTable("Exec OperationLogInsert @SSID=" & frmMain.sSSID & ",@OperationDescription='" & sOperation.Replace("'", "''") & "'")
            End If
            DB.Close()
        End If

        Me.Cursor = Cursors.Default
    End Sub
End Class