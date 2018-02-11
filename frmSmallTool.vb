Public Class frmSmallTool

    Private sStartCardNo As String, sEndCardNo As String

    Private Sub txbStartCardNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbStartCardNo.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then Me.txbEndCardNo.Select() : Me.txbEndCardNo.SelectAll() : e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If Me.txbStartCardNo.SelectedText = Me.txbStartCardNo.Text Then Me.txbStartCardNo.Text = ""
            Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbStartCardNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbStartCardNo.Leave
        If Me.txbStartCardNo.Text = "" Then Return
        If Me.txbStartCardNo.Text <> Me.txbStartCardNo.Text.Trim Then Me.txbStartCardNo.Text = Me.txbStartCardNo.Text.Trim
        Dim sValue As String = Me.txbStartCardNo.Text

        If sValue <> sStartCardNo Then
            If Not IsNumeric(sValue) Then
                Me.lblStartCardError.Text = "（卡号只能由数字组成！）"
            ElseIf sValue.Length < 19 Then
                Me.lblStartCardError.Text = "（卡号位数不足 19 位！）"
            ElseIf sValue <> ShoppingCardNo.GetFullCardNo(sValue.Substring(0, 18)) Then
                Me.lblStartCardError.Text = "（卡号校验码错误！）"
            Else
                sStartCardNo = sValue
            End If
        End If

        If Me.lblStartCardError.Text = "" AndAlso Me.lblEndCardError.Text = "" AndAlso sStartCardNo <> "" AndAlso sEndCardNo <> "" Then
            If sStartCardNo > sEndCardNo Then
                Me.txbStartCardNo.Text = sEndCardNo
                Me.txbEndCardNo.Text = sStartCardNo
                sStartCardNo = Me.txbStartCardNo.Text
                sEndCardNo = Me.txbEndCardNo.Text
            End If
        End If

        If Me.lblStartCardError.Text = "" AndAlso Me.lblEndCardError.Text = "" AndAlso sStartCardNo <> "" AndAlso sEndCardNo <> "" Then
            Me.btnRun.Enabled = True
        End If
    End Sub

    Private Sub txbStartCardNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbStartCardNo.TextChanged
        Me.lblStartCardError.Text = ""
        Me.btnRun.Enabled = False
        If Me.txbStartCardNo.Text.Trim.Length = 19 Then
            Me.txbEndCardNo.Select()
            Me.txbStartCardNo.Select()
            Me.txbStartCardNo.SelectAll()
        End If
    End Sub

    Private Sub txbEndCardNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbEndCardNo.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then Me.txbStartCardNo.Select() : Me.txbStartCardNo.SelectAll() : e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If Me.txbEndCardNo.SelectedText = Me.txbEndCardNo.Text Then Me.txbEndCardNo.Text = ""
            Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbEndCardNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbEndCardNo.Leave
        If Me.txbEndCardNo.Text = "" Then Return
        If Me.txbEndCardNo.Text <> Me.txbEndCardNo.Text.Trim Then Me.txbEndCardNo.Text = Me.txbEndCardNo.Text.Trim
        Dim sValue As String = Me.txbEndCardNo.Text

        If sValue <> sEndCardNo Then
            If Not IsNumeric(sValue) Then
                Me.lblEndCardError.Text = "（卡号只能由数字组成！）"
            ElseIf sValue.Length < 19 Then
                Me.lblEndCardError.Text = "（卡号位数不足 19 位！）"
            ElseIf sValue <> ShoppingCardNo.GetFullCardNo(sValue.Substring(0, 18)) Then
                Me.lblEndCardError.Text = "（卡号校验码错误！）"
            Else
                sEndCardNo = sValue
            End If
        End If

        If Me.lblStartCardError.Text = "" AndAlso Me.lblEndCardError.Text = "" AndAlso sStartCardNo <> "" AndAlso sEndCardNo <> "" Then
            If sStartCardNo > sEndCardNo Then
                Me.txbStartCardNo.Text = sEndCardNo
                Me.txbEndCardNo.Text = sStartCardNo
                sStartCardNo = Me.txbStartCardNo.Text
                sEndCardNo = Me.txbEndCardNo.Text
            End If
        End If

        If Me.lblStartCardError.Text = "" AndAlso Me.lblEndCardError.Text = "" AndAlso sStartCardNo <> "" AndAlso sEndCardNo <> "" Then
            Me.btnRun.Enabled = True
        End If
    End Sub

    Private Sub txbEndCardNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbEndCardNo.TextChanged
        Me.lblEndCardError.Text = ""
        Me.btnRun.Enabled = False
        If Me.txbEndCardNo.Text.Trim.Length = 19 Then
            Me.txbStartCardNo.Select()
            Me.txbEndCardNo.Select()
            Me.txbEndCardNo.SelectAll()
        End If
    End Sub

    Private Sub btnRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRun.Click
        Me.rtbCards.Clear()
        Me.lblCount.Text = ""
        Dim iCards As Long = CLng(sEndCardNo.Substring(0, 18)) - CLng(sStartCardNo.Substring(0, 18)), iStart As Long = CLng(sStartCardNo.Substring(0, 18))
        For iCard As Long = 0 To iCards
            Me.rtbCards.AppendText(ShoppingCardNo.GetFullCardNo((iStart + iCard).ToString) & Chr(10))
        Next
        Me.lblCount.Text = "（共 " & Format(iCards + 1, "#,0") & " 张）"

        Me.btnRun.Enabled = False
    End Sub

    Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        Me.rtbCards.SelectAll()
        Me.rtbCards.Copy()
    End Sub

    Private Sub rtbCards_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rtbCards.TextChanged
        Me.btnCopy.Enabled = (Me.rtbCards.Text.Trim <> "")
    End Sub
End Class