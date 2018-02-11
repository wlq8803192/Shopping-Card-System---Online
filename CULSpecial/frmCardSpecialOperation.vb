Public Class frmCardSpecialOperation

    'modify code 023:
    'date;2014/5/22
    'auther:Hyron bjy 
    'remark:新增界面，特殊操作，卡号段查询

    Public sMenu As String = ""

    Private Sub frmCardSpecialOperation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Size(Me.tlpList.Width + 36, Me.tlpList.Height + 60)
        Me.Location = New Point(Int((My.Computer.Screen.WorkingArea.Width - Me.Width) / 2), Int((My.Computer.Screen.WorkingArea.Height - Me.Height) / 2))
    End Sub

    Private Sub btnResetCardPassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetCardPassword.Click
        sMenu = "menuResetCardPassword"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnFreezeCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFreezeCard.Click
        sMenu = "menuFreezeCard"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnUrgencyDeduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUrgencyDeduct.Click
        sMenu = "menuUrgentDeduction"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnChangeCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeCard.Click
        sMenu = "menuReplaceCard"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnAffirmChangeCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAffirmChangeCard.Click
        sMenu = "menuReplaceCardValidation"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnUnchargeCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnchargeCard.Click
        sMenu = "menuUnchargeCard"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnAffirmUnchargeCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAffirmUnchargeCard.Click
        sMenu = "menuAffirmUnchargeCard"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnUnchargeMKTCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnchargeMKTCard.Click
        sMenu = "menuUnchargeMKTCard"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnAffirmUnchargeMKTCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAffirmUnchargeMKTCard.Click
        sMenu = "menuAffirmUnchargeMKTCard"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnGiftCardActivationCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGiftCardActivationCancel.Click
        sMenu = "menuGiftCardActivationCancel"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnAffirmGiftCardActivationCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAffirmGiftCardActivationCancel.Click
        sMenu = "menuAffirmGiftCardActivationCancel"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnGiftCardOfflineActivate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGiftCardOfflineActivate.Click
        sMenu = "menuGiftCardOfflineActivate"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnAffirmGiftCardOfflineActivate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAffirmGiftCardOfflineActivate.Click
        sMenu = "menuAffirmGiftCardOfflineActivate"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnRecycleCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecycleCard.Click
        sMenu = "menuRecycleCard"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnAffirmRecycleCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAffirmRecycleCard.Click
        sMenu = "menuAffirmRecycleCard"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnCardStateQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCardStateQuery.Click
        sMenu = "menuCardStateQuery"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    'modify code 023:start-------------------------------------------------------------------------
    Private Sub btnCardStateQuery_Section_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCardStateQuery_Section.Click
        sMenu = "menuCardStateQuery_Section"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
    'modify code 023:end-------------------------------------------------------------------------
End Class