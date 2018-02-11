Public Class frmSetLocution

    Public sOldLocution As String

    Private Sub frmSetLocution_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txbLocution.Select()
        Me.txbLocution.SelectAll()
    End Sub

    Private Sub txbLocution_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbLocution.TextChanged
        Me.btnOK.Enabled = (Me.txbLocution.Text.Trim <> sOldLocution)
    End Sub
End Class