Public Class frmCardFee


    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grbMaximun.Enter

    End Sub

    Private Sub frmCardFee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvList.Rows.Add(1, 0, 9999, 4)
        dgvList.Rows.Add(2, 10000, 29999, 3)
        dgvList.Rows.Add(3, 30000, 59999, 2)
        dgvList.Rows.Add(4, 60000, 999999, 1)
        dgvList.Rows.Add(5, 10000, DBNull.Value, 0)
        Me.dgvList.Select()
        Me.nudMaximum.Select()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbLaunch.CheckedChanged
        Panel1.Enabled = chbLaunch.Checked
    End Sub

    Private Sub dgvList_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvList.Leave
        If Me.dgvList.CurrentCell IsNot Nothing Then Me.dgvList.CurrentCell.Selected = False
        If Me.dgvList.CurrentRow IsNot Nothing Then Me.dgvList.CurrentRow.Selected = False
    End Sub
End Class