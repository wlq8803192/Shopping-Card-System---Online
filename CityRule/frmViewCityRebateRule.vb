Public Class frmViewCityRebateRule

    Public iAvailableRowID As Int16 = -1

    Private Sub frmViewCityRebateRule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim iAdded As Integer = (Me.Height - Me.dgvValidated.Height) + IIf(ToolStripManager.VisualStylesEnabled, 2, 4) + 36, iHeight As Integer = Me.dgvValidated.RowCount * 24 + iAdded
        If iHeight > My.Computer.Screen.WorkingArea.Height Then
            iHeight = My.Computer.Screen.WorkingArea.Height
            iHeight = Int((iHeight - iAdded) / 24) * 24 + iAdded
        End If
        Me.Height = iHeight
        Me.Location = New Point(Int((My.Computer.Screen.WorkingArea.Width - Me.Width) / 2), Int((My.Computer.Screen.WorkingArea.Height - Me.Height) / 2))

        If iAvailableRowID = -1 Then
            Me.lblRemarks.Visible = False
        Else
            Me.dgvValidated.FirstDisplayedScrollingRowIndex = iAvailableRowID
        End If
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub dgvValidated_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvValidated.CellFormatting
        If e.ColumnIndex > 3 AndAlso e.RowIndex = iAvailableRowID Then
            e.CellStyle.ForeColor = Color.Blue
            e.CellStyle.BackColor = Color.Yellow
            e.CellStyle.SelectionForeColor = Color.Blue
            e.CellStyle.SelectionBackColor = Color.Yellow
        End If
    End Sub
End Class