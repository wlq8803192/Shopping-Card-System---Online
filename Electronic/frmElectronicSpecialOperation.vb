Public Class frmElectronicSpecialOperation

    'modify code 082
    'date:2017/9/30
    'auther:Qipeng
    'remark:添加电子卡特殊操作

    Public sMenu As String = ""

    Private Sub frmElectronicSpecialOperation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Size(Me.tlpList.Width + 36, Me.tlpList.Height + 50)
        Me.Location = New Point(Int((My.Computer.Screen.WorkingArea.Width - Me.Width) / 2), Int((My.Computer.Screen.WorkingArea.Height - Me.Height) / 2))
    End Sub

    Private Sub btnECancelChargeRequirement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnECancelChargeRequirement.Click
        sMenu = "menuECancelChargeRequirement"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnECancelChargeValidation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnECancelChargeValidation.Click
        sMenu = "menuECancelChargeValidation"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnECancelExtractingCodeRequirement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnECancelExtractingCodeRequirement.Click
        sMenu = "menuECancelExtractingCodeRequirement"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnECancelExtractingCodeValidation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnECancelExtractingCodeValidation.Click
        sMenu = "menuECancelExtractingCodeValidation"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnECodeDelayRequirement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnECodeDelayRequirement.Click
        sMenu = "menuECodeDelayRequirement"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class