Public Class frmBonusCalculation

    Private Sub frmBonusCalculation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.trvEmployee.SelectedNode = Me.trvEmployee.Nodes(0).Nodes(0)
        Me.dgvRule.Columns(1).HeaderText = "最小金额 ＞" & Chr(13) & "Minimal AMT"
        Me.dgvRule.Columns(2).HeaderText = "最大金额 ≤" & Chr(13) & "Maximum AMT"
        Me.dgvRule.Columns(3).HeaderText = "奖金比例" & Chr(13) & "Bonus Rate %"
        Me.dgvRule.Rows.Add(1, 0, 10000000, 0)
        Me.dgvRule.Rows.Add(2, 10000000, 25000000, 0.01)
        Me.dgvRule.Rows.Add(3, 25000000, 50000000, 0.02)
        Me.dgvRule.Rows.Add(4, 50000000, 100000000, 0.03)
        Me.dgvRule.Rows.Add(5, 100000000, DBNull.Value, 0.04)

        Me.dgvRule.Select()
        Me.Button1.Select()
        Me.trvEmployee.Select()
    End Sub

    Private Sub trvEmployee_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvEmployee.AfterSelect

    End Sub

    Private Sub trvEmployee_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles trvEmployee.Enter
        If Me.trvEmployee.SelectedNode IsNot Nothing Then
            Me.trvEmployee.SelectedNode.BackColor = SystemColors.Window
            Me.trvEmployee.SelectedNode.ForeColor = SystemColors.ControlText
        End If
    End Sub

    Private Sub trvEmployee_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles trvEmployee.Leave
        If Me.trvEmployee.SelectedNode IsNot Nothing Then
            Me.trvEmployee.SelectedNode.BackColor = SystemColors.Highlight
            Me.trvEmployee.SelectedNode.ForeColor = SystemColors.HighlightText
        End If
    End Sub

    Private Sub dgvRule_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRule.CellContentClick

    End Sub

    Private Sub dgvRule_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvRule.Leave
        If Me.dgvRule.CurrentCell IsNot Nothing Then Me.dgvRule.CurrentCell.Selected = False
        If Me.dgvRule.CurrentRow IsNot Nothing Then Me.dgvRule.CurrentRow.Selected = False
    End Sub
End Class