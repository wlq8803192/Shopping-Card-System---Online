Public Class frmCrossContractCityRule
    'modify code 067:
    'date;2016/10/17
    'auther:Qipeng
    'remark:新添加通卖合同管理

    Public dvCityRule As DataView, dvRuleDetails As DataView
    Private blSkipDeal As Boolean = True, iCorrespondingRowID As Int16 = -1

    Private Sub frmCrossContractCityRule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me.dgvContractDetails
            .DataSource = frmCrossContract.dtContractDetails
            .Columns(0).Visible = False
            With .Columns(1)
                .HeaderText = "No."
                .Width = 40
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.ForeColor = SystemColors.ControlText
                .DefaultCellStyle.BackColor = SystemColors.Control
                .DefaultCellStyle.SelectionForeColor = SystemColors.ControlText
                .DefaultCellStyle.SelectionBackColor = SystemColors.Control
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns(2)
                .HeaderText = "最小金额 ＞" & Chr(13) & "Minimal AMT"
                .Width = 85
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,0.00"
            End With
            With .Columns(3)
                .HeaderText = "最大金额 ≤" & Chr(13) & "Maximum AMT"
                .Width = 85
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,0.00"
            End With
            With .Columns(4)
                .HeaderText = "返点" & Chr(13) & "Discount %"
                .Width = 75
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Format = "#,0.0"
            End With
            .Columns.Add("Result", "对比结果" & Chr(13) & "Compare Result")
            With .Columns(5)
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            If Not ToolStripManager.VisualStylesEnabled Then .Height += 2
        End With

        dvCityRule.RowFilter = ""
        With Me.cbbCity
            .DataSource = dvCityRule
            .ValueMember = "RuleID"
            .DisplayMember = "CityFullName"
            .SelectedIndex = -1
        End With

        dvRuleDetails.RowFilter = "1=2"
        With Me.dgvCityRuleDetails
            .DataSource = dvRuleDetails
            .Columns(0).Visible = False
            .Columns(1).Visible = False
            .Columns(2).Visible = False
            With .Columns(3)
                .HeaderText = "No."
                .Width = 40
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.ForeColor = SystemColors.ControlText
                .DefaultCellStyle.BackColor = SystemColors.Control
                .DefaultCellStyle.SelectionForeColor = SystemColors.ControlText
                .DefaultCellStyle.SelectionBackColor = SystemColors.Control
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns(4)
                .HeaderText = "最小金额 ＞" & Chr(13) & "Minimal AMT"
                .Width = 85
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,0.00"
            End With
            With .Columns(5)
                .HeaderText = "最大金额 ≤" & Chr(13) & "Maximum AMT"
                .Width = 85
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,0.00"
            End With
            With .Columns(6)
                .HeaderText = "最大返点" & Chr(13) & "Max Disc %"
                .Width = 75
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Format = "#,0.0"
            End With
            .Columns(7).Visible = False
            With .Columns(8)
                .HeaderText = "审核者（超过最大返点时）" & Chr(13) & "Who Validate if over Maximum Rate"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            If Not ToolStripManager.VisualStylesEnabled Then .Top -= 2 : .Height += 2
        End With

        blSkipDeal = False
        Me.cbbCity.SelectedIndex = 0
    End Sub

    Private Sub dgvContractDetails_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvContractDetails.CellFormatting
        If Me.dgvContractDetails.Columns(e.ColumnIndex).Name = "Result" Then
            If e.Value.ToString.IndexOf("未") = -1 Then
                e.CellStyle.ForeColor = Color.Red
                e.CellStyle.SelectionForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub dgvContractDetails_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvContractDetails.SelectionChanged
        If blSkipDeal OrElse Not Me.IsHandleCreated Then Return
        Dim dmLevelStartAMT As Decimal = 0, drRuleDetail As DataRowView = Nothing
        If Me.dgvContractDetails.CurrentRow IsNot Nothing Then
            dmLevelStartAMT = Me.dgvContractDetails("StartSalesAMT", Me.dgvContractDetails.CurrentRow.Index).Value + 0.001
        End If
        For Each drRuleDetail In dvRuleDetails
            If dmLevelStartAMT = 0 Then
                Exit For
            ElseIf drRuleDetail("EndSalesAMT").ToString <> "" AndAlso dmLevelStartAMT > drRuleDetail("StartSalesAMT") AndAlso dmLevelStartAMT <= drRuleDetail("EndSalesAMT") Then
                Exit For
            End If
        Next
        iCorrespondingRowID = drRuleDetail("RowID") - 1
        Me.dgvCityRuleDetails.FirstDisplayedScrollingRowIndex = iCorrespondingRowID
        Me.dgvCityRuleDetails.Refresh()
    End Sub

    Private Sub cbbCity_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbCity.SelectedIndexChanged
        If blSkipDeal OrElse Not Me.IsHandleCreated Then Return
        dvRuleDetails.RowFilter = "RuleID=" & Me.cbbCity.SelectedValue.ToString
        Dim dmLevelStartAMT As Decimal = 0, drRuleDetail As DataRowView = Nothing
        For Each dr As DataGridViewRow In Me.dgvContractDetails.Rows
            dmLevelStartAMT = dr.Cells("StartSalesAMT").Value + 0.001
            For Each drRuleDetail In dvRuleDetails
                If dmLevelStartAMT = 0 Then
                    Exit For
                ElseIf drRuleDetail("EndSalesAMT").ToString <> "" AndAlso dmLevelStartAMT > drRuleDetail("StartSalesAMT") AndAlso dmLevelStartAMT <= drRuleDetail("EndSalesAMT") Then
                    Exit For
                End If
            Next
            If dr.Cells("RebateRate").Value > drRuleDetail("MaxRebateRate") Then
                dr.Cells("Result").Value = "已超过标准 Over Standard"
            Else
                dr.Cells("Result").Value = "未超过标准 Within Standard"
            End If
        Next
        Me.dgvContractDetails.Rows(0).Selected = False
        Me.dgvContractDetails.Rows(0).Selected = True
        If dvCityRule(Me.cbbCity.SelectedIndex)("RuleState") = 3 Then
            Me.lblExpired.Visible = True
        Else
            Me.lblExpired.Visible = False
        End If
    End Sub

    Private Sub dgvCityRuleDetails_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvCityRuleDetails.CellFormatting
        If e.ColumnIndex > 3 AndAlso e.RowIndex = iCorrespondingRowID Then
            e.CellStyle.ForeColor = Color.Blue
            e.CellStyle.BackColor = Color.Yellow
            e.CellStyle.SelectionForeColor = Color.Blue
            e.CellStyle.SelectionBackColor = Color.Yellow
        End If
    End Sub
End Class