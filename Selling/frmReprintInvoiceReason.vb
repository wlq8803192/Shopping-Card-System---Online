Public Class frmReprintInvoiceReason

    Private Sub frmReprintInvoiceReason_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txbReprintReason.Select()
    End Sub

    Private Sub txbReprintReason_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbReprintReason.DoubleClick
        Me.txbReprintReason.SelectAll()
    End Sub

    Private Sub txbReprintReason_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbReprintReason.TextChanged
        Me.btnOK.Enabled = (Me.txbReprintReason.Text.Trim <> "")
    End Sub
End Class