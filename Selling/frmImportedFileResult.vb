Public Class frmImportedFileResult

    Public drImportedFile As DataRow, dtImportedDetails As DataTable
    'modify code 046:start-------------------------------------------------------------------------
    Public isSign As Boolean
    'modify code 046:end-------------------------------------------------------------------------

    Private Sub frmImportedFileResult_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.dgvDetails.Select()
        Me.Label1.Select()
        If Me.dgvDetails.CurrentCell IsNot Nothing Then Me.dgvDetails.CurrentCell.Selected = False
        If Me.dgvDetails.CurrentRow IsNot Nothing Then Me.dgvDetails.CurrentRow.Selected = False
    End Sub

    Private Sub frmImportedFileResult_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If drImportedFile Is Nothing OrElse drImportedFile("SourceComputer").ToString = "" Then
            Me.grbSource.Visible = False
        Else
            Me.txbSourceComputer.Text = drImportedFile("SourceComputer").ToString
            Me.txbSourceFile.Text = drImportedFile("SourceFile").ToString
            Me.txbWorkSheet.Text = drImportedFile("WorkSheet").ToString
            If drImportedFile("FileSize").ToString <> "" Then Me.txbFileSize.Text = Format(drImportedFile("FileSize"), "#,0")
            If drImportedFile("FileModifiedTime").ToString <> "" Then Me.txbFileModifiedTime.Text = Format(drImportedFile("FileModifiedTime"), "yyyy\/MM\/dd HH:mm:ss")
        End If

        dtImportedDetails.DefaultView.Sort = "RowID"
        Dim iGridWidth As Integer = 0, iGridHeight As Integer = (dtImportedDetails.Rows.Count + 1) * 24, iWidth As Integer = 696, iHeight As Integer = 0
        With Me.dgvDetails
            .DataSource = dtImportedDetails
            .Columns(0).Visible = False
            .Columns(1).Visible = False
            .Columns(2).Visible = False
            With .Columns(3)
                .HeaderText = "城市"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                iGridWidth = .Width
            End With
            With .Columns(4)
                .HeaderText = "卡号"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                iGridWidth += .Width
            End With
            With .Columns(5)
                .HeaderText = "面值"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                iGridWidth += .Width
            End With
            With .Columns(6)
                .HeaderText = "销售日期"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                iGridWidth += .Width
                .Visible = False
            End With
            With .Columns(7)
                .HeaderText = "备注"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                iGridWidth += .Width
            End With
            With .Columns(8)
                .HeaderText = "卡费/张"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                iGridWidth += .Width
                If isSign Then
                    .Visible = True
                Else
                    .Visible = False
                End If
            End With
            With .Columns(9)
                .HeaderText = "持卡人姓名"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                iGridWidth += .Width
                If isSign Then
                    .Visible = True
                Else
                    .Visible = False
                End If
            End With
            With .Columns(10)
                .HeaderText = "性别"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                iGridWidth += .Width
                If isSign Then
                    .Visible = True
                Else
                    .Visible = False
                End If
            End With
            With .Columns(11)
                .HeaderText = "持卡人身份证"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                iGridWidth += .Width
                If isSign Then
                    .Visible = True
                Else
                    .Visible = False
                End If
            End With
            With .Columns(12)
                .HeaderText = "持卡人手机"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                iGridWidth += .Width
                If isSign Then
                    .Visible = True
                Else
                    .Visible = False
                End If
            End With
            'modify code 046:start-------------------------------------------------------------------------
            'With .Columns(8)
            '    .HeaderText = "导入状态"
            '    .HeaderCell.Style.Font = New Font(Me.dgvDetails.Font, FontStyle.Bold)
            '    .DefaultCellStyle.BackColor = Color.Gray
            '    .DefaultCellStyle.ForeColor = Color.LawnGreen
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '    .Resizable = DataGridViewTriState.False
            '    .SortMode = DataGridViewColumnSortMode.NotSortable
            '    iGridWidth += .Width
            'End With
            'With .Columns(9)
            '    .HeaderText = "无法导入原因"
            '    .HeaderCell.Style.Font = New Font(Me.dgvDetails.Font, FontStyle.Bold)
            '    .DefaultCellStyle.BackColor = Color.Gray
            '    .DefaultCellStyle.ForeColor = Color.LawnGreen
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '    .Resizable = DataGridViewTriState.False
            '    .SortMode = DataGridViewColumnSortMode.NotSortable
            '    If dtImportedDetails.Select("Isnull(StateReason,'')<>''").Length > 0 Then
            '        iGridWidth += .Width
            '    Else
            '        .Visible = False
            '    End If
            'End With
            
            With .Columns(13)
                .HeaderText = "导入状态"
                .HeaderCell.Style.Font = New Font(Me.dgvDetails.Font, FontStyle.Bold)
                .DefaultCellStyle.BackColor = Color.Gray
                .DefaultCellStyle.ForeColor = Color.LawnGreen
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                iGridWidth += .Width
            End With
            With .Columns(14)
                .HeaderText = "无法导入原因"
                .HeaderCell.Style.Font = New Font(Me.dgvDetails.Font, FontStyle.Bold)
                .DefaultCellStyle.BackColor = Color.Gray
                .DefaultCellStyle.ForeColor = Color.LawnGreen
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                If dtImportedDetails.Select("Isnull(StateReason,'')<>''").Length > 0 Then
                    iGridWidth += .Width
                Else
                    .Visible = False
                End If
            End With
            'modify code 046:end-------------------------------------------------------------------------
        End With
        For bColumn As Byte = 0 To dtImportedDetails.Columns.Count - 1
            Me.dgvDetails.Columns(bColumn).Name = dtImportedDetails.Columns(bColumn).ColumnName
        Next

        If Me.Text <> "查看导入结果" Then
            Me.txbCardQTY.Text = "0" : Me.txbChargedAMT.Text = "0.00"
        ElseIf drImportedFile IsNot Nothing AndAlso drImportedFile("CardQTY").ToString <> "" Then
            Me.txbCardQTY.Text = Format(drImportedFile("CardQTY"), "#,0")
            Me.txbChargedAMT.Text = Format(drImportedFile("ChargedAMT"), "#,0.00")
        Else
            Dim iCardQTY As Integer = 0, dmChargedAMT As Decimal = 0
            For Each dr As DataRow In dtImportedDetails.Select("ImportedState='已导入'")
                iCardQTY += 1
                dmChargedAMT += CDec(dr("FaceValue"))
            Next
            Me.txbCardQTY.Text = Format(iCardQTY, "#,0")
            Me.txbChargedAMT.Text = Format(dmChargedAMT, "#,0.00")
        End If

        iGridWidth += IIf(ToolStripManager.VisualStylesEnabled, 2, 4)
        iGridHeight += IIf(ToolStripManager.VisualStylesEnabled, 0, 2)
        Dim blHaveHorizontal As Boolean = False
        If iGridWidth + 58 > iWidth Then
            If iGridWidth + 58 < My.Computer.Screen.WorkingArea.Width Then
                iWidth = iGridWidth + 58
            Else
                iWidth = My.Computer.Screen.WorkingArea.Width
                blHaveHorizontal = True '存在水平滚动条
            End If
        ElseIf Me.dgvDetails.Columns("StateReason").Visible Then
            With Me.dgvDetails.Columns("StateReason")
                .MinimumWidth = 2
                .MinimumWidth = .Width
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
        Else
            With Me.dgvDetails.Columns("Remarks")
                .MinimumWidth = 2
                .MinimumWidth = .Width
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
        End If
        Me.grbResult.Width = iWidth - 32

        If Me.grbSource.Visible Then
            iHeight = iGridHeight + 264
        Else
            iHeight = iGridHeight + 150
        End If

        If iHeight > My.Computer.Screen.WorkingArea.Height Then
            If iWidth + 17 < My.Computer.Screen.WorkingArea.Width Then iWidth = iWidth + 17
            If Me.grbSource.Visible Then
                iGridHeight = Int((My.Computer.Screen.WorkingArea.Height - 264 - IIf(blHaveHorizontal, 17, 0)) / 24) * 24
                iHeight = iGridHeight + 264
            Else
                iGridHeight = Int((My.Computer.Screen.WorkingArea.Height - 150 - IIf(blHaveHorizontal, 17, 0)) / 24) * 24
                iHeight = iGridHeight + 150
            End If
        End If

        Me.grbSource.Width = iWidth - 32
        Me.grbResult.Width = iWidth - 32
        Me.grbResult.Height = iGridHeight + 66

        Me.Size = New Size(iWidth, iHeight)
        Me.Location = New Point(Int((My.Computer.Screen.WorkingArea.Width - iWidth) / 2), Int((My.Computer.Screen.WorkingArea.Height - iHeight) / 2))
        If Me.Text <> "查看导入结果" Then
            For Each drDetail As DataGridViewRow In Me.dgvDetails.Rows
                If drDetail.Cells("ImportedState").Value.ToString = "无法导入" Then
                    Me.dgvDetails.FirstDisplayedScrollingRowIndex = drDetail.Index
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub dgvDetails_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvDetails.CellFormatting
        If Me.dgvDetails("ErrorColumn", e.RowIndex).Value.ToString <> "" Then
            If Me.dgvDetails.Columns(e.ColumnIndex).Name = "ImportedState" OrElse Me.dgvDetails.Columns(e.ColumnIndex).Name = "StateReason" OrElse e.ColumnIndex = Me.dgvDetails("ErrorColumn", e.RowIndex).Value Then
                e.CellStyle.ForeColor = Color.Red
                e.CellStyle.SelectionForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub dgvDetails_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDetails.Leave
        If Me.dgvDetails.CurrentCell IsNot Nothing Then Me.dgvDetails.CurrentCell.Selected = False
        If Me.dgvDetails.CurrentRow IsNot Nothing Then Me.dgvDetails.CurrentRow.Selected = False
    End Sub
End Class