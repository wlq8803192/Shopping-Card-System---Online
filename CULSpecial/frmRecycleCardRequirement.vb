Public Class frmRecycleCardRequirement

    Private dvCULParameter As DataView, dtList1 As DataTable, dtList2 As DataTable
    Private bStep As Byte = 1, blStep1OK As Boolean = False, blStep2OK As Boolean = False, blStep3OK As Boolean = False
    Private blSkipDeal As Boolean = False, editingCardNo As TextBox, errorCell As DataGridViewCell, sErrorInfo As String = ""

    Private Sub frmRecycleCardRequirement_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Me.dgvList1.Visible AndAlso Not Me.dgvList1.ReadOnly Then
            Me.dgvList1.Focus()
            Me.dgvList1.Select()
            Me.dgvList1("CardNo", Me.dgvList1.RowCount - 1).Selected = True
            Me.dgvList1.BeginEdit(True)
        End If
    End Sub

    Private Sub frmRecycleCardRequirement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dvCULParameter = frmMain.dtLoginStructure.Copy.DefaultView
        dvCULParameter.RowFilter = "AreaType='S'"
        dvCULParameter = dvCULParameter.ToTable(False, "AreaID", "CULCardBin", "CULStoreCode").DefaultView
        dvCULParameter.RowFilter = "CULCardBin Like '%|%'"
        For Each drCUL As DataRowView In dvCULParameter
            Dim saCardBins() As String = drCUL("CULCardBin").ToString.Split("|")
            For bIndex As Byte = 0 To saCardBins.Length - 1
                dvCULParameter.Table.Rows.Add(drCUL("AreaID"), saCardBins(bIndex), drCUL("CULStoreCode")).EndEdit()
            Next
        Next
        For Each drCUL As DataRow In frmMain.dtLoginStructure.Select("ParentAreaID=33") '青岛市
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "71866", drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "72866", drCUL("CULStoreCode")).EndEdit()
        Next
        For Each drCUL As DataRow In frmMain.dtLoginStructure.Select("ParentAreaID=52") '郑州市
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "35601", drCUL("CULStoreCode")).EndEdit()
        Next
        For Each drCUL As DataRow In frmMain.dtLoginStructure.Select("ParentAreaID=39") '长沙市
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "73608", drCUL("CULStoreCode")).EndEdit()
        Next
        For Each drCUL As DataRow In frmMain.dtLoginStructure.Select("ParentAreaID=59") '海口市
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "11020", drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "11100", drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "11200", drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "11300", drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "11500", drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "11066", drCUL("CULStoreCode")).EndEdit()
        Next
        For Each drCUL As DataRow In dvCULParameter.Table.Select("CULCardBin Like '84%'")
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "60" & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "92" & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "94" & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()

            'modify code 050:start-------------------------------------------------------------------------
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), frmMain.signCardBin & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
            'modify code 050:end-------------------------------------------------------------------------
        Next
        dvCULParameter.RowFilter = ""
        dvCULParameter.Table.AcceptChanges()

        dtList1 = New DataTable
        dtList1.Columns.Add("RowID", System.Type.GetType("System.Int16"))
        dtList1.Columns.Add("CardNo", System.Type.GetType("System.String"))
        dtList1.Columns.Add("CardState", System.Type.GetType("System.String"))
        dtList1.Columns.Add("Balance", System.Type.GetType("System.Decimal"))
        dtList1.Columns.Add("RecycleState", System.Type.GetType("System.String"))

        dtList2 = dtList1.DefaultView.ToTable(False, "RowID", "CardNo", "CardState", "Balance")
        dtList2.Columns.Add("AddedResult", System.Type.GetType("System.String"))
        dtList2.Columns.Add("FailureReason", System.Type.GetType("System.String"))

        With Me.dgvList1
            .DataSource = dtList1
            With .Columns(0)
                .HeaderText = "行号"
                .Width = 40
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.BackColor = SystemColors.Control
                .DefaultCellStyle.ForeColor = SystemColors.ControlText
                .DefaultCellStyle.SelectionBackColor = SystemColors.Control
                .DefaultCellStyle.SelectionForeColor = SystemColors.ControlText
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
            End With
            With .Columns(1)
                .HeaderText = "卡号"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            .Columns(2).Visible = False
            .Columns(3).Visible = False
            .Columns(4).Visible = False

            For bColumn As Byte = 0 To dtList1.Columns.Count - 1
                .Columns(bColumn).Name = dtList1.Columns(bColumn).ColumnName
            Next
        End With

        With Me.dgvList2
            .DataSource = dtList1
            With .Columns(0)
                .HeaderText = "行号"
                .Width = 40
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.BackColor = SystemColors.Control
                .DefaultCellStyle.ForeColor = SystemColors.ControlText
                .DefaultCellStyle.SelectionBackColor = SystemColors.Control
                .DefaultCellStyle.SelectionForeColor = SystemColors.ControlText
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(1)
                .HeaderText = "卡号"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(2)
                .HeaderText = "卡状态"
                .Width = 82
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            .Columns(3).Visible = False
            With .Columns(4)
                .HeaderText = "可否回收"
                .Width = 70
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With

            For bColumn As Byte = 0 To dtList1.Columns.Count - 1
                .Columns(bColumn).Name = dtList1.Columns(bColumn).ColumnName
            Next
        End With

        With Me.dgvList3
            .DataSource = dtList2
            With .Columns(0)
                .HeaderText = "行号"
                .Width = 40
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.BackColor = SystemColors.Control
                .DefaultCellStyle.ForeColor = SystemColors.ControlText
                .DefaultCellStyle.SelectionBackColor = SystemColors.Control
                .DefaultCellStyle.SelectionForeColor = SystemColors.ControlText
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(1)
                .HeaderText = "卡号"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(2)
                .HeaderText = "卡状态"
                .Width = 60
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            .Columns(3).Visible = False
            With .Columns(4)
                .HeaderText = "申请结果"
                .Width = 75
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .Visible = False
            End With
            With .Columns(5)
                .HeaderText = "失败原因"
                .Width = 85
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.ForeColor = Color.Red
                .DefaultCellStyle.SelectionForeColor = Color.Red
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .Visible = False
            End With

            For bColumn As Byte = 0 To dtList2.Columns.Count - 1
                .Columns(bColumn).Name = dtList2.Columns(bColumn).ColumnName
            Next
        End With

        dtList1.Rows.Add(1)
        Me.dgvList1.Focus()
        Me.dgvList1.Select()
        Me.dgvList1("CardNo", 0).Selected = True
    End Sub

    Private Sub dgvList1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvList1.CellEndEdit
        If blSkipDeal Then Return
        blSkipDeal = True : Me.dgvList1.CurrentCell.Selected = False : blSkipDeal = False
    End Sub

    Private Sub dgvList1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvList1.CellFormatting
        If errorCell IsNot Nothing AndAlso e.ColumnIndex = errorCell.ColumnIndex AndAlso e.RowIndex = errorCell.RowIndex Then
            e.CellStyle.ForeColor = Color.Red
            e.CellStyle.SelectionForeColor = Color.Red
        End If
    End Sub

    Private Sub dgvList1_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvList1.CellLeave
        If editingCardNo IsNot Nothing AndAlso e.ColumnIndex = 1 Then
            RemoveHandler editingCardNo.KeyDown, AddressOf CardNo_KeyDown
            RemoveHandler editingCardNo.TextChanged, AddressOf CardNo_TextChanged
            editingCardNo = Nothing
        End If
    End Sub

    Private Sub dgvList1_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvList1.CellMouseUp
        If Me.dgvList1.ReadOnly OrElse e.RowIndex = -1 OrElse e.ColumnIndex <> 0 OrElse e.Button <> Windows.Forms.MouseButtons.Right OrElse Me.dgvList1("CardNo", 0).Value.ToString = "" Then Return

        blSkipDeal = True
        Me.dgvList1.EditMode = DataGridViewEditMode.EditProgrammatically
        Me.dgvList1("CardNo", e.RowIndex).Selected = True
        Me.dgvList1.CurrentRow.Selected = True
        blSkipDeal = False
        Me.cmenuDelete.Show(Control.MousePosition)
    End Sub

    Private Sub dgvList1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvList1.CellValueChanged
        If blSkipDeal OrElse e.ColumnIndex <> 1 OrElse e.RowIndex = -1 Then Return

        errorCell = Nothing : sErrorInfo = ""
        blSkipDeal = True
        Dim sCardNo As String = Me.dgvList1(e.ColumnIndex, e.RowIndex).Value.ToString

        If sCardNo = "" Then
            If e.RowIndex < Me.dgvList1.RowCount - 1 Then
                If Me.dgvList1.RowCount = 1 Then
                    sErrorInfo = "请在该单元格输入卡号。"
                Else
                    sErrorInfo = "请在该单元格输入卡号（在行号上按鼠标右键出现""删除""菜单可删除该行）。"
                End If
            End If
        ElseIf Not IsNumeric(sCardNo) Then
            sErrorInfo = "该卡号错误：卡号只能由数字组成！"
        ElseIf sCardNo.Length < 19 Then
            sErrorInfo = "该卡号错误：卡号位数不足 19 位！"
        ElseIf sCardNo <> ShoppingCardNo.GetFullCardNo(sCardNo.Substring(0, 18)) Then
            sErrorInfo = "该卡号错误：卡号校验码错误！"
        ElseIf dvCULParameter.Table.Select("CULCardBin='" & sCardNo.Substring(4, 5) & "'").Length = 0 Then
            sErrorInfo = "该卡号错误：无权操作该卡段！"
        ElseIf dtList1.Select("CardNo='" & sCardNo & "'").Length > 0 Then
            sErrorInfo = "该卡号已经存在，不可重复！"
        End If

        Me.dgvList1.EditMode = DataGridViewEditMode.EditOnEnter
        If sErrorInfo = "" Then
            Me.dgvList1("CardState", e.RowIndex).Value = Nothing
            Me.dgvList1("Balance", e.RowIndex).Value = 0
            Me.dgvList1("RecycleState", e.RowIndex).Value = Nothing
            If Me.dgvList1("CardNo", Me.dgvList1.RowCount - 1).Value.ToString <> "" Then
                dtList1.Rows.Add(Me.dgvList1.RowCount + 1)
                If Me.dgvList1.DisplayedRowCount(False) < Me.dgvList1.RowCount Then
                    Me.dgvList1.Width = 185
                Else
                    Me.dgvList1.Width = 168
                End If
                Me.dgvList1("CardNo", Me.dgvList1.RowCount - 1).Selected = True
            End If
            Me.lblInfo1.ForeColor = SystemColors.ControlText
            Me.lblInfo1.Text = "共输入了 " & Format(Me.dgvList1.RowCount - 1, "#,0") & " 张卡。如果卡号输入完毕，请按""下一步""到CUL系统查询该" & IIf(Me.dgvList1.RowCount = 2, "张", "批") & "购物卡的状态。"

            blStep1OK = True : blStep2OK = False
            Me.btnNext.Enabled = True
            Me.btnFinish.Enabled = False
        Else
            errorCell = Me.dgvList1("CardNo", e.RowIndex)
            Me.lblInfo1.ForeColor = Color.Red
            Me.lblInfo1.Text = sErrorInfo

            blStep1OK = False : blStep2OK = False
            Me.btnNext.Enabled = False : Me.btnFinish.Enabled = False
            Me.dgvList1.Select() : Me.dgvList1("RowID", e.RowIndex).Selected = True : errorCell.Selected = True
        End If
        blSkipDeal = False
    End Sub

    Private Sub dgvList1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvList1.EditingControlShowing
        If Me.dgvList1.Columns(Me.dgvList1.CurrentCell.ColumnIndex).Name = "CardNo" Then
            editingCardNo = CType(e.Control, TextBox)
            editingCardNo.ImeMode = Windows.Forms.ImeMode.Disable
            editingCardNo.MaxLength = 19
            AddHandler editingCardNo.KeyDown, AddressOf CardNo_KeyDown
            AddHandler editingCardNo.TextChanged, AddressOf CardNo_TextChanged
        End If
    End Sub

    Private Sub dgvList1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvList1.KeyDown
        If e.KeyCode = Keys.Delete AndAlso Me.dgvList1.ReadOnly = False AndAlso Me.dgvList1.CurrentRow.Selected = True Then
            If Me.dgvList1("CardNo", 0).Value.ToString = "" Then
                Me.dgvList1.EditMode = DataGridViewEditMode.EditOnEnter
                Me.dgvList1("CardNo", 0).Selected = True
                Me.dgvList1.BeginEdit(True)
            Else
                Me.menuDelete.PerformClick()
            End If
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub dgvList1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvList1.Leave
        blSkipDeal = True
        If Me.dgvList1.CurrentCell IsNot Nothing Then Me.dgvList1.CurrentCell.Selected = False
        If Me.dgvList1.CurrentRow IsNot Nothing Then Me.dgvList1.CurrentRow.Selected = False
        blSkipDeal = False
    End Sub

    Private Sub dgvList1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvList1.SelectionChanged
        If blSkipDeal OrElse Me.dgvList1.CurrentCell Is Nothing Then Return
        blSkipDeal = True
        If Me.dgvList1.ReadOnly Then
            Me.dgvList1.CurrentRow.Selected = True
        ElseIf Me.dgvList1.CurrentCell.ColumnIndex = 0 Then
            Me.dgvList1.EditMode = DataGridViewEditMode.EditProgrammatically
            If errorCell IsNot Nothing AndAlso errorCell IsNot Me.dgvList1.CurrentCell Then errorCell.Selected = True
            Me.dgvList1("CardNo", Me.dgvList1.CurrentRow.Index).Selected = True
            Me.dgvList1.CurrentRow.Selected = True
        Else
            Me.dgvList1.EditMode = DataGridViewEditMode.EditOnEnter
            If errorCell IsNot Nothing AndAlso errorCell IsNot Me.dgvList1.CurrentCell Then errorCell.Selected = True
            Me.dgvList1.BeginEdit(True)
        End If
        blSkipDeal = False
    End Sub

    Private Sub menuDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuDelete.Click
        blSkipDeal = True
        Dim iCurrentRow As Integer = Me.dgvList1.CurrentRow.Index, drCard As DataRow = dtList1.Select("RowID=" & Me.dgvList1("RowID", iCurrentRow).Value.ToString)(0)
        If errorCell IsNot Nothing AndAlso errorCell.RowIndex = iCurrentRow Then errorCell = Nothing : sErrorInfo = ""
        If iCurrentRow = Me.dgvList1.RowCount - 1 Then
            If drCard("CardNo").ToString <> "" Then
                drCard.Delete()
                drCard = dtList1.Rows.Add(iCurrentRow + 1)
            End If
        Else
            drCard.Delete()
            For Each drCard In dtList1.Select("RowID>" & (iCurrentRow + 1))
                drCard("RowID") = drCard("RowID") - 1
            Next
        End If

        If iCurrentRow > Me.dgvList1.RowCount - 1 Then iCurrentRow = Me.dgvList1.RowCount - 1
        If Me.dgvList1("CardNo", iCurrentRow).Value.ToString = "" Then
            Me.dgvList1.EditMode = DataGridViewEditMode.EditOnEnter
            Me.dgvList1("CardNo", iCurrentRow).Selected = True
            Me.dgvList1.BeginEdit(True)
        Else
            Me.dgvList1.EditMode = DataGridViewEditMode.EditProgrammatically
            Me.dgvList1("CardNo", iCurrentRow).Selected = True : Me.dgvList1.CurrentRow.Selected = True
        End If

        If sErrorInfo = "" Then
            Me.lblInfo1.ForeColor = SystemColors.ControlText
            If Me.dgvList1.RowCount > 1 Then
                If dtList1.Select("Isnull(CardNo,'')<>'' And Isnull(CardState, '（未知）')='（未知）'").Length = 0 Then
                    blStep2OK = True
                    Me.lblInfo1.Text = "共输入了 " & Format(Me.dgvList1.RowCount - 1, "#,0") & " 张卡。请按""下一步""查看该" & IIf(Me.dgvList1.RowCount = 2, "张", "批") & "购物卡的状态。"
                Else
                    blStep2OK = False
                    Me.lblInfo1.Text = "共输入了 " & Format(Me.dgvList1.RowCount - 1, "#,0") & " 张卡。如果卡号输入完毕，请按""下一步""到CUL系统查询该" & IIf(Me.dgvList1.RowCount = 2, "张", "批") & "购物卡的状态。"
                End If
                Me.btnNext.Enabled = True
                Me.btnFinish.Enabled = blStep2OK
            Else
                Me.lblInfo1.Text = ""
                blStep1OK = False : blStep2OK = False
                Me.btnNext.Enabled = False
                Me.btnFinish.Enabled = False
            End If
        End If
        If Me.dgvList1.DisplayedRowCount(False) < Me.dgvList1.RowCount Then
            Me.dgvList1.Width = 185
        Else
            Me.dgvList1.Width = 168
        End If
        blSkipDeal = False
    End Sub

    Private Sub dgvList2_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvList2.CellFormatting
        Select Case Me.dgvList2.Columns(e.ColumnIndex).Name
            Case "CardState"
                If e.Value.ToString = "未激活" Then
                    e.CellStyle.ForeColor = Color.Maroon
                    e.CellStyle.SelectionForeColor = Color.Yellow
                ElseIf e.Value.ToString = "（未知）" Then
                    e.CellStyle.ForeColor = Color.Red
                    e.CellStyle.SelectionForeColor = Color.Red
                End If
            Case "RecycleState"
                If e.Value.ToString = "不用回收" Then
                    e.CellStyle.ForeColor = Color.Maroon
                    e.CellStyle.SelectionForeColor = Color.Yellow
                ElseIf e.Value.ToString.IndexOf("！") > -1 Then
                    e.CellStyle.ForeColor = Color.Red
                    e.CellStyle.SelectionForeColor = Color.Red
                End If
        End Select
    End Sub

    Private Sub dgvList2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvList2.Leave
        If Me.dgvList2.CurrentCell IsNot Nothing Then Me.dgvList2.CurrentCell.Selected = False
        If Me.dgvList2.CurrentRow IsNot Nothing Then Me.dgvList2.CurrentRow.Selected = False
    End Sub

    Private Sub dgvList3_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvList3.CellFormatting
        If Me.dgvList3.Columns(e.ColumnIndex).Name = "AddedResult" AndAlso e.Value.ToString = "申请失败！" Then
            e.CellStyle.ForeColor = Color.Red
            e.CellStyle.SelectionForeColor = Color.Red
        End If
    End Sub

    Private Sub dgvList3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvList3.Leave
        If Me.dgvList3.CurrentCell IsNot Nothing Then Me.dgvList3.CurrentCell.Selected = False
        If Me.dgvList3.CurrentRow IsNot Nothing Then Me.dgvList3.CurrentRow.Selected = False
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        Me.pnlStep1.Visible = True
        Me.pnlStep2.Visible = False
        Me.pnlStep3.Visible = False

        bStep = 1
        If blStep3OK Then
            dtList1.Rows.Clear() : dtList1.AcceptChanges()
            dtList2.Rows.Clear() : dtList2.AcceptChanges()

            Me.dgvList1.Width = 168
            Me.dgvList1.ReadOnly = False
            Me.dgvList1.Columns(0).ReadOnly = True
            Me.dgvList1.DefaultCellStyle.BackColor = SystemColors.Window
            Me.lblInfo1.Text = ""
            Me.dgvList2.Columns("RecycleState").Width = 70
            Me.dgvList2.Width = 320
            Me.dgvList2.DefaultCellStyle.BackColor = SystemColors.Window
            Me.lblInfo2.Text = ""
            Me.dgvList3.Columns("AddedResult").Visible = False
            Me.dgvList3.Columns("FailureReason").Visible = False
            Me.dgvList3.Width = 228
            Me.dgvList3.DefaultCellStyle.BackColor = SystemColors.Window
            Me.lblInfo3.ForeColor = SystemColors.ControlText
            Me.lblInfo3.Text = ""

            Me.btnStart.Enabled = False
            Me.btnPrevious.Enabled = False
            Me.btnNext.Enabled = False
            Me.btnFinish.Enabled = False
            Me.btnCancel.Text = "取消(&C)"

            blStep1OK = False : blStep2OK = False : blStep3OK = False
        Else
            Me.btnStart.Enabled = False
            Me.btnPrevious.Enabled = False
            Me.btnNext.Enabled = True
            Me.btnFinish.Enabled = blStep2OK
        End If

        dtList1.Rows.Add(Me.dgvList1.RowCount + 1)
        Me.dgvList1.EditMode = DataGridViewEditMode.EditOnEnter
        Me.dgvList1.Select()
        Me.dgvList1("CardNo", Me.dgvList1.RowCount - 1).Selected = True
        Me.dgvList1.BeginEdit(True)
    End Sub

    Private Sub btnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevious.Click
        Select Case bStep
            Case 2
                bStep = 1
                Me.pnlStep1.Visible = True
                Me.pnlStep2.Visible = False
                Me.pnlStep3.Visible = False

                Me.btnStart.Enabled = blStep3OK
                Me.btnPrevious.Enabled = False
                Me.btnNext.Enabled = True
                Me.btnFinish.Enabled = blStep2OK

                If blStep3OK Then
                    Me.dgvList1.Select()
                    Me.btnNext.Select()
                Else
                    dtList1.Rows.Add(Me.dgvList1.RowCount + 1)
                    Me.dgvList1.EditMode = DataGridViewEditMode.EditOnEnter
                    Me.dgvList1.Select()
                    Me.dgvList1("CardNo", Me.dgvList1.RowCount - 1).Selected = True
                    Me.dgvList1.BeginEdit(True)
                End If
            Case 3
                bStep = 2
                Me.pnlStep1.Visible = False
                Me.pnlStep2.Visible = True
                Me.pnlStep3.Visible = False

                Me.btnStart.Enabled = True
                Me.btnPrevious.Enabled = True
                Me.btnNext.Enabled = True
                Me.btnFinish.Enabled = True

                Me.dgvList2.Select()
                Me.btnPrevious.Select()
        End Select
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Select Case bStep
            Case 1
                bStep = 2
                Me.pnlStep1.Visible = False
                Me.pnlStep2.Visible = True
                Me.pnlStep3.Visible = False

                Me.btnStart.Enabled = True
                Me.btnPrevious.Enabled = True

                Dim iCards As Integer = 0
                If Not blStep3OK Then
                    dtList1.Rows(dtList1.Rows.Count - 1).Delete()
                    If dtList1.Select("RecycleState='不可回收（余额超过10元）！'").Length = 0 Then
                        Me.dgvList2.Columns("RecycleState").Width = 70
                        Me.dgvList2.Width = 320
                    Else
                        Me.dgvList2.Columns("RecycleState").Width = 170
                        Me.dgvList2.Width = 420
                    End If
                    If Me.dgvList2.DisplayedRowCount(False) < Me.dgvList2.RowCount Then Me.dgvList2.Width += 17
                    iCards = dtList1.Select("Isnull(CardState,'（未知）')='（未知）'").Length
                End If

                If Not blStep2OK OrElse iCards > 0 Then
                    Me.Cursor = Cursors.WaitCursor
                    Me.lblInfo2.ForeColor = SystemColors.ControlText
                    Me.lblInfo2.Text = "正在到CUL查询该" & IIf(dtList1.Rows.Count = 1, "张", "批") & "购物卡的状态，请稍候……"
                    Me.dgvList2.Select()
                    Me.Refresh()

                    Dim sDecimalSeparator As String = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
                    Dim c4Service As C4ShoppingCardService.C4ShoppingCardService = Nothing, infoClass As C4ShoppingCardService.InfoClass = Nothing, infoDataClass As C4ShoppingCardService.InfoDataClass = Nothing
                    Try
                        c4Service = New C4ShoppingCardService.C4ShoppingCardService()
                        infoClass = New C4ShoppingCardService.InfoClass()
                    Catch ex As Exception
                        MessageBox.Show("因为CUL系统故障，无法查询购物卡状态！ 下面是CUL系统的内部错误提示：    " & Chr(13) & Chr(13) & ex.Message & Space(4), "出现CUL系统故障！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.lblInfo2.ForeColor = Color.Red
                        Me.lblInfo2.Text = "因为CUL系统故障，无法查询购物卡状态！"
                        If c4Service IsNot Nothing Then c4Service.Dispose() : c4Service = Nothing
                        Me.btnNext.Enabled = False
                        Me.btnFinish.Enabled = False
                        Me.Cursor = Cursors.Default
                        Return
                    End Try

                    frmMain.statusRate.Visible = True
                    frmMain.statusRate.Text = ""
                    frmMain.statusProgress.Visible = True
                    frmMain.statusProgress.Value = 0
                    frmMain.statusMain.Refresh()

                    Dim currentRow As DataRow, iCard As Integer = 0, sCardNo As String, sMerchantNo As String, sCardState As String, dmBalance As Decimal = 0
                    For iRow As Integer = 0 To Me.dgvList2.RowCount - 1
                        If Me.dgvList2("CardState", iRow).Value.ToString = "" OrElse Me.dgvList2("CardState", iRow).Value.ToString = "（未知）" Then
                            dmBalance = 0
                            currentRow = dtList1.Select("RowID=" & Me.dgvList2("RowID", iRow).Value.ToString)(0)
                            Try
                                Me.dgvList2("CardNo", iRow).Selected = True
                                Me.dgvList2.Rows(iRow).Selected = True

                                iCard += 1
                                frmMain.statusText.Text = "正在查询购物卡状态……"
                                frmMain.statusRate.Text = "(" & iCard.ToString & "/" & iCards.ToString & ")"
                                frmMain.statusProgress.Value = Int((iCard / iCards) * 100)
                                frmMain.statusMain.Refresh()

                                currentRow("CardState") = "正在查询……"
                                currentRow("RecycleState") = Nothing
                                Me.dgvList2.Refresh()

                                sCardNo = currentRow("CardNo").ToString
                                sMerchantNo = dvCULParameter.Table.Select("CULCardBin='" & sCardNo.Substring(4, 5) & "'")(0)("CULStoreCode").ToString
                                infoClass.MerchantNo = sMerchantNo
                                infoClass.UserID = sMerchantNo
                                infoClass.CardNoFrom = sCardNo
                                infoClass.CardNoTo = sCardNo
                                infoClass.IsPager = "N"
                                infoClass.PageNo = "1"
                                infoDataClass = c4Service.info(infoClass)
                                If infoDataClass.CodeMsg.Code = "OZ" Then
                                    dmBalance = CDec(infoDataClass.Cards(0).Balance.ToString.Replace(".", sDecimalSeparator))
                                    If infoDataClass.Cards(0).HotReason = "冻结" Then
                                        sCardState = "已冻结"
                                    ElseIf infoDataClass.Cards(0).HotReason = "结束" Then
                                        sCardState = "已结束"
                                    ElseIf infoDataClass.Cards(0).Status = "激活" Then
                                        sCardState = "已激活"
                                    Else
                                        sCardState = "未激活"
                                    End If
                                Else
                                    sCardState = "（未知）"
                                End If
                            Catch
                                sCardState = "（未知）"
                            End Try

                            currentRow("Balance") = dmBalance
                            currentRow("CardState") = sCardState
                            Select Case sCardState
                                Case "已激活", "已冻结", "已结束"
                                    If dmBalance <= 10 Then
                                        currentRow("RecycleState") = "可以回收"
                                    Else
                                        currentRow("RecycleState") = "不可回收（余额超过10元）！"
                                        If Me.dgvList2.Width <= 337 Then
                                            Me.dgvList2.Columns("RecycleState").Width = 170
                                            Me.dgvList2.Width += 100
                                        End If
                                    End If
                                Case "未激活"
                                    currentRow("RecycleState") = "不用回收"
                                Case "（未知）"
                                    currentRow("RecycleState") = "不能回收！"
                            End Select
                        End If
                    Next

                    c4Service.Dispose() : c4Service = Nothing

                    frmMain.statusText.Text = "就绪。"
                    frmMain.statusRate.Text = ""
                    frmMain.statusRate.Visible = False
                    frmMain.statusProgress.Value = 0
                    frmMain.statusProgress.Visible = False

                    iCard = dtList1.Select("Isnull(RecycleState,'（未知）')='可以回收'").Length
                    iCards = dtList1.Select("Isnull(CardState,'（未知）')='（未知）'").Length
                    Dim iUnable As Int16 = dtList1.Select("Isnull(RecycleState,'（未知）')='不可回收（余额超过10元）！'").Length
                    If iCard = 0 Then
                        Me.lblInfo2.ForeColor = Color.Red
                        If iCards + iUnable = 0 Then
                            Me.lblInfo2.Text = "查询结束。没有需要回收的购物卡！"
                        ElseIf iUnable = dtList1.Rows.Count Then
                            Me.lblInfo2.Text = "查询结束。总部金融服务部规定：当购物卡余额超过10元时不可回收！"
                        ElseIf iCards = dtList1.Rows.Count Then
                            Me.lblInfo2.Text = "查询结束。由于不能确定该" & IIf(dtList1.Rows.Count = 1, "张", "批") & "购物卡的状态，所以不能对它" & IIf(dtList1.Rows.Count = 1, "", "们") & "进行回收！"
                        Else
                            Me.lblInfo2.Text = "查询结束。由于该批购物卡或者状态未知，或者余额超过10元，或者无需回收，所以不能对它" & IIf(dtList1.Rows.Count = 1, "", "们") & "进行回收！"
                        End If
                    Else
                        blStep2OK = True
                        If iCard < dtList1.Rows.Count Then
                            If iCards + iUnable = 0 Then
                                Me.lblInfo2.Text = "查询结束。但有部分购物卡不用回收。请按""下一步""将可以回收的购物卡加入到回收申请中。"
                            ElseIf iCard + iCards = dtList1.Rows.Count Then
                                Me.lblInfo2.Text = "查询结束。但有部分购物卡的状态不能确定。请按""下一步""将可以回收的购物卡加入到回收申请中。"
                            ElseIf iCard + iUnable = dtList1.Rows.Count Then
                                Me.lblInfo2.Text = "查询结束。但有部分购物卡因余额超过10元而不能回收。请按""下一步""将可以回收的购物卡加入到回收申请中。"
                            Else
                                Me.lblInfo2.Text = "查询结束。但有部分购物卡或者状态未知，或者余额超过10元，或者无需回收。请按""下一步""将可以回收的购物卡加入到回收申请中。"
                            End If
                        Else
                            Me.lblInfo1.Text = "共输入了 " & Format(Me.dgvList1.RowCount - 1, "#,0") & " 张卡。请按""下一步""查看该" & IIf(Me.dgvList1.RowCount = 2, "张", "批") & "购物卡的状态。"
                            Me.lblInfo2.Text = "查询结束。该" & IIf(dtList1.Rows.Count = 1, "张", "批") & "购物卡可以回收。请按""下一步""将它" & IIf(dtList1.Rows.Count = 1, "", "们") & "加入到回收申请中。"
                        End If
                    End If

                    Me.Cursor = Cursors.Default
                Else
                    Me.btnNext.Enabled = True
                    Me.btnNext.Select()
                End If

                Me.btnNext.Enabled = blStep2OK
                Me.btnFinish.Enabled = blStep2OK

                If Me.btnNext.Enabled Then
                    Me.btnNext.Select()
                Else
                    Me.btnPrevious.Select()
                End If
            Case 2
                Me.btnFinish.PerformClick()
        End Select
    End Sub

    Private Sub btnFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinish.Click
        bStep = 3
        Me.pnlStep1.Visible = False
        Me.pnlStep2.Visible = False
        Me.pnlStep3.Visible = True

        Me.btnStart.Enabled = True
        Me.btnPrevious.Enabled = True

        If Not blStep3OK Then
            Me.Cursor = Cursors.WaitCursor
            Me.lblInfo3.ForeColor = SystemColors.ControlText
            Me.lblInfo3.Text = "正在保存购物卡回收申请记录……"
            Me.dgvList3.Select()
            Me.Refresh()

            dtList2.Rows.Clear()
            With Me.dgvList3
                .Columns("AddedResult").Visible = False
                .Columns("FailureReason").Visible = False
                .Width = 228
            End With

            Dim newCard As DataRow, iRowID As Int16 = 0
            For Each drCard As DataRow In dtList1.Select("RecycleState='可以回收'", "RowID")
                iRowID += 1
                newCard = dtList2.Rows.Add(iRowID)
                newCard("CardNo") = drCard("CardNo")
                newCard("CardState") = drCard("CardState")
                newCard("Balance") = drCard("Balance")
            Next
            If Me.dgvList3.DisplayedRowCount(False) < Me.dgvList3.RowCount Then Me.dgvList3.Width += 17
            Me.dgvList3.Refresh()

            Dim DB As New DataBase
            DB.Open()
            If DB.IsConnected Then
                If DB.ModifyTable("Select RowID,CardNo,CardState,Balance,Convert(nvarchar(50),Null) As FailureReason Into #tempCard From CULRecycle Where 1=2") = -1 Then
                    Me.lblInfo3.ForeColor = Color.Red
                    Me.lblInfo3.Text = "保存购物卡回收申请记录失败！"
                    Me.btnNext.Enabled = False : Me.btnFinish.Enabled = True
                    DB.Close() : Me.Cursor = Cursors.Default : Return
                End If
Submit_Again:
                If DB.BulkCopyTable("#tempCard", dtList2.DefaultView.ToTable(False, "RowID", "CardNo", "CardState", "Balance", "FailureReason")) = -1 Then
                    Me.lblInfo3.ForeColor = Color.Red
                    Me.lblInfo3.Text = "保存购物卡回收申请记录失败！"
                    Me.btnNext.Enabled = False : Me.btnFinish.Enabled = True
                    DB.Close() : Me.Cursor = Cursors.Default : Return
                End If

                Dim dtResult As DataTable = DB.GetDataTable("Exec CULRecycleCardRequest " & dtList2.Rows.Count.ToString & ",'" & frmMain.sLoginUserRealName.Replace("'", "''") & "'," & frmMain.sSSID)
                If dtResult Is Nothing Then
                    Me.lblInfo3.ForeColor = Color.Red
                    Me.lblInfo3.Text = "保存购物卡回收申请记录时出现数据库内部错误！"
                    Me.btnNext.Enabled = False : Me.btnFinish.Enabled = True
                    Me.Cursor = Cursors.Default : Return
                End If

                If dtResult.Rows(0)("Result").ToString = "Missing" Then GoTo Submit_Again
                DB.Close()

                If dtResult.Rows(0)("Result").ToString = "Error" Then
                    Me.lblInfo3.ForeColor = Color.Red
                    Me.lblInfo3.Text = "保存购物卡回收申请记录时出现数据库内部错误！"
                    Me.btnNext.Enabled = False : Me.btnFinish.Enabled = True
                    MessageBox.Show("系统无法保存购物卡回收申请记录！下面是数据库的内部错误提示：    " & Chr(13) & Chr(13) & dtResult.Rows(0)("ErrorInfo").ToString & Space(4) & Chr(13) & Chr(13) & "请重试。如果仍有问题，请联系软件开发人员。    ", "保存购物卡回收申请记录时出现数据库内部错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Cursor = Cursors.Default : Return
                End If

                Dim sInfo As String
                If dtResult.Rows(0)("Result").ToString = "Nothing" Then
                    For Each drCard As DataRow In dtResult.Rows
                        dtList2.Rows(drCard("RowID") - 1)("AddedResult") = "申请失败！"
                        dtList2.Rows(drCard("RowID") - 1)("FailureReason") = drCard("FailureReason").ToString
                    Next

                    Me.lblInfo3.ForeColor = Color.Red
                    sInfo = "没有任何卡加入回收申请！按""开始""执行新的操作，或按""关闭""结束操作。"
                ElseIf dtResult.Rows(0)("Result").ToString = "AllOK" Then
                    For Each drCard As DataRow In dtList2.Rows
                        drCard("AddedResult") = "申请成功"
                    Next
                    sInfo = "已将" & IIf(dtList2.Rows.Count = 1, "该张", "全部") & "购物卡加入回收申请。按""开始""执行新的操作，或按""关闭""结束操作。"
                Else
                    For Each drCard As DataRow In dtResult.Rows
                        If drCard("FailureReason").ToString = "" Then
                            dtList2.Rows(drCard("RowID") - 1)("AddedResult") = "申请成功"
                        Else
                            dtList2.Rows(drCard("RowID") - 1)("AddedResult") = "申请失败！"
                            dtList2.Rows(drCard("RowID") - 1)("FailureReason") = drCard("FailureReason").ToString
                        End If
                    Next
                    sInfo = "已将 " & Format(dtList2.Select("AddedResult='申请成功'").Length, "#,0") & " 张卡加入回收申请。按""开始""执行新的操作，或按""关闭""结束操作。"
                End If

                With Me.dgvList3
                    .Columns("AddedResult").Visible = True
                    If dtList2.Select("AddedResult='申请失败！'").Length = 0 Then
                        .Width += .Columns("AddedResult").Width
                    Else
                        With .Columns("FailureReason")
                            .Visible = True
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        End With
                        .Width += (.Columns("AddedResult").Width + .Columns("FailureReason").Width)
                    End If
                    If .Width > 543 Then .Width = 543
                End With

                If Me.dgvList1("CardNo", Me.dgvList1.RowCount - 1).Value.ToString = "" Then
                    dtList1.Select("RowID=" & Me.dgvList1("RowID", Me.dgvList1.RowCount - 1).Value.ToString)(0).Delete()
                    If Me.dgvList1.DisplayedRowCount(False) < Me.dgvList1.RowCount Then
                        Me.dgvList1.Width = 185
                    Else
                        Me.dgvList1.Width = 168
                    End If
                End If
                Me.dgvList1.ReadOnly = True
                Me.dgvList1.DefaultCellStyle.BackColor = SystemColors.Control
                Me.lblInfo1.Text = "共输入了 " & Format(Me.dgvList1.RowCount, "#,0") & " 张卡。"

                Me.dgvList2.DefaultCellStyle.BackColor = SystemColors.Control
                Me.lblInfo2.Text = "共有 " & Format(Me.dgvList3.RowCount, "#,0") & " 张卡可以回收。"

                Me.dgvList3.DefaultCellStyle.BackColor = SystemColors.Control

                dtResult.Dispose() : dtResult = Nothing
                blStep3OK = True
                Me.Refresh()

                Dim dvCard As DataView = dtList2.Copy.DefaultView
                dvCard.RowFilter = "AddedResult='申请成功' And CardState='已激活' And Balance>0"
                If dvCard.Count > 0 Then
                    Me.lblInfo3.Text = "为确保余额不被消费，正对可用于消费的购物卡执行冻结操作……"
                    Me.Refresh()
                    ShoppingCardOperation.CRFCardAutoFreeze(True, dvCULParameter.Table, dvCard.ToTable(True, "CardNo"))
                End If
                dvCard.Dispose() : dvCard = Nothing

                Me.lblInfo3.Text = sInfo
            Else
                Me.lblInfo3.ForeColor = Color.Red
                Me.lblInfo3.Text = "系统因连接不到数据库而无法保存购物卡回收申请记录。请检查数据库连接。"
            End If

            dtList1.AcceptChanges()
            dtList2.AcceptChanges()
            Me.btnCancel.Text = "关闭(&C)"
            Me.Cursor = Cursors.Default
        Else
            Me.btnPrevious.Select()
        End If

        Me.btnNext.Enabled = False
        Me.btnFinish.Enabled = Not blStep3OK
        If Me.btnFinish.Enabled Then
            Me.btnFinish.Select()
        Else
            Me.btnPrevious.Select()
        End If
    End Sub

    Private Sub btnHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistory.Click
        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在打开购物卡""回收""历史记录窗口……"
        frmMain.statusMain.Refresh()

        If frmRecycleCardHistory.ShowDialog() = Windows.Forms.DialogResult.Ignore Then Me.btnHistory.Enabled = False
        frmRecycleCardHistory.Dispose()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CardNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If editingCardNo IsNot Nothing AndAlso editingCardNo.SelectedText.Length = editingCardNo.Text.Length Then
                blSkipDeal = True
                Me.dgvList1.CurrentCell.Value = ""
                blSkipDeal = False
            End If
            Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub CardNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If blSkipDeal Then Return
        If editingCardNo Is Nothing Then Return
        editingCardNo.ForeColor = SystemColors.ControlText
    End Sub
End Class