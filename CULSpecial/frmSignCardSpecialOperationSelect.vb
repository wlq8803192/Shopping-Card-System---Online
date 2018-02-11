Public Class frmSignCardSpecialOperationSelect
    Public sMenu As String = ""

    Private Sub frmCardSpecialOperation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Size(Me.tlpList.Width + 36, Me.tlpList.Height + 60)
        Me.Location = New Point(Int((My.Computer.Screen.WorkingArea.Width - Me.Width) / 2), Int((My.Computer.Screen.WorkingArea.Height - Me.Height) / 2))
    End Sub

    Private Sub btnSignCardSpecialOperation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSignCardSpecialOperation.Click
        sMenu = "menuSignCardSpecialOperation"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnSignCardReplace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSignCardReplace.Click
        sMenu = "menuSignCardReplace"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class