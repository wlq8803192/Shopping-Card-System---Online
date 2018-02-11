Public Class frmElectronicOperation
    'modify code 070
    'date:2017/2/23
    'auther:Qipeng
    'remark:电子卡团购

    Public sMenu As String = ""

    Private Sub frmElectronicCard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'modify code 081:start-------------------------------------------------------------------------
        Me.Size = New Size(Me.tlpList.Width + 36, Me.tlpList.Height + 50)
        Me.Location = New Point(Int((My.Computer.Screen.WorkingArea.Width - Me.Width) / 2), Int((My.Computer.Screen.WorkingArea.Height - Me.Height) / 2))
        'modify code 081:end-------------------------------------------------------------------------
    End Sub

    Private Sub btnRequirement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRequirement.Click
        sMenu = "menuERequirement"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        sMenu = "menuEQuery"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnActivationRequirement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActivationRequirement.Click
        sMenu = "menuEActivationRequirement"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnActivationValidation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActivationValidation.Click
        sMenu = "menuEActivationValidation"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnFreezeCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFreezeCard.Click
        sMenu = "menuEFreezeCard"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnSupplySms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupply.Click
        sMenu = "menuESupplySms"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnElectronicCodeDelay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnElectronicCodeDelay.Click
        sMenu = "menuECodeDelay"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnECancelChargeRequirement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sMenu = "menuECancelChargeRequirement"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnECancelChargeValidation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sMenu = "menuECancelChargeValidation"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnECancelExtractingCodeRequirement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sMenu = "menuECancelExtractingCodeRequirement"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnECancelExtractingCodeValidation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sMenu = "menuECancelExtractingCodeValidation"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnECodeDelayRequirement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sMenu = "menuECodeDelayRequirement"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class