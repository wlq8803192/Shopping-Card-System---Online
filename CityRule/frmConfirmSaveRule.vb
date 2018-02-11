Public Class frmConfirmSaveRule

    Private Sub frmConfirmSaveRule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dgvChanges.Columns(1).Frozen = True
    End Sub
End Class