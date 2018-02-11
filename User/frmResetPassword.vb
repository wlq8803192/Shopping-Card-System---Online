Public Class frmResetPassword

    Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        My.Computer.Clipboard.Clear()
        Me.rtbNamePassword.SelectAll()
        Me.rtbNamePassword.Copy()
    End Sub
End Class