Public Class frmTEST_ConvertPW

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.TextBox2.Text = SecurityText.EncryptData(Me.TextBox1.Text.Trim())
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.TextBox2.Text = SecurityText.DecryptData(Me.TextBox1.Text.Trim())
    End Sub
End Class