Public Class frmSelectEChannel

    Public sChannelType As String = ""

    Private Sub frmSelectEChannel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        If rbChannel1.Checked Then
            sChannelType = "Online"
        ElseIf rbChannel2.Checked Then
            sChannelType = "Underline"
        Else
            MessageBox.Show("请选择购买渠道！", "请选择购买渠道！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        frmElectronicCardFreeze.ShowDialog()
        frmElectronicCardFreeze.Dispose()
    End Sub
End Class
