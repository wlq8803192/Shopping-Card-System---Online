Public Class frmEmployeeQuota

    Private dvOffice As DataView, dvLevel As DataView, dtCity As DataTable, dtStore As DataTable
    Private blSkipDeal As Boolean = True, editingTextBox As TextBox

    Private Sub frmEmployeeQuota_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Me.dgvOffice.CurrentCell IsNot Nothing AndAlso Me.dgvOffice.CurrentCell.ReadOnly = False Then
            Me.dgvOffice.CurrentCell.Selected = False
            Me.dgvOffice.CurrentCell.Selected = True
        End If

        If Me.dgvLevel.CurrentCell IsNot Nothing AndAlso Me.dgvLevel.CurrentCell.ReadOnly = False Then
            Me.dgvLevel.CurrentCell.Selected = False
            Me.dgvLevel.CurrentCell.Selected = True
        End If
    End Sub

    Private Sub frmEmployeeQuota_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.btnSave.Enabled Then
            Me.btnSave.Select()
            Dim bAnswer As Windows.Forms.DialogResult = MessageBox.Show("当前窗口内容已更改，但未保存。    " & Chr(13) & Chr(13) & "是否在关闭窗口前保存这些更改？    " & Chr(13) & Chr(13) & "   是    -   保存更改并退出" & Chr(13) & "   否    -   放弃更改并退出" & Chr(13) & "  取消   -   取消关闭", "请确认保存更改：", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

            If bAnswer = Windows.Forms.DialogResult.Yes Then
                If Me.SaveChanges Then Me.Dispose() Else e.Cancel = True
            ElseIf bAnswer = Windows.Forms.DialogResult.No Then
                Me.Dispose()
            Else
                e.Cancel = True
            End If
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub frmEmployeeQuota_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DB As New DataBase()
        DB.Open(True)
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打开""员工额度设置""窗口。请检查数据库连接。"
            Me.Close() : Return
        End If

        Try
            dvOffice = DB.GetDataTable("Select * From EmployeOfficeList").DefaultView
            dvOffice.Sort = "SortCode,OfficeSortID"

            dvLevel = DB.GetDataTable("Select * From EmployeeLevelQuota").DefaultView
            dvLevel.Sort = "CityID,LevelSortID"
        Catch
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开""员工额度设置""窗口。请联系软件开发人员。"
            DB.Close() : Me.Close() : Return
        End Try
        DB.Close()

        dtCity = dvOffice.ToTable(True, "CityID", "CityName")
        dtCity.AcceptChanges()

        With Me.cbbCity
            .DataSource = dtCity
            .ValueMember = "CityID"
            .DisplayMember = "CityName"
            .SelectedIndex = 0
        End With

        dvOffice.RowFilter = "CityID=" & Me.cbbCity.SelectedValue.ToString
        dtStore = dvOffice.ToTable(True, "StoreID", "StoreName", "SortCode")
        If dtStore.Select("StoreID=-1").Length = 0 Then
            dtStore.Rows.Add(-1, "（本市的任何门店）")
        End If
        dtStore.AcceptChanges()
        dtStore.DefaultView.Sort = "SortCode"

        With Me.dgvOffice
            .DataSource = dvOffice
            .Columns(0).Visible = False
            .Columns(1).Visible = False
            .Columns(2).Visible = False
            .Columns(3).Visible = False
            .Columns(4).Visible = False
            .Columns(5).Visible = False
            .Columns(6).Visible = False
            With .Columns(7)
                .HeaderText = "门店/办公室名称"
                .ToolTipText = "来自Payroll系统的名称"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .FillWeight = 80
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With
            With .Columns(8)
                .HeaderText = "人数"
                .ToolTipText = "在职人数"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Width = 40
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,0"
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With
            Dim columnCombobox As New DataGridViewComboBoxColumn()
            With columnCombobox
                .DataPropertyName = "PurchaseStoreID"
                .DataSource = dtStore
                .ValueMember = "StoreID"
                .DisplayMember = "StoreName"
                .MaxDropDownItems = 50
                .HeaderText = "指定购卡门店"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Padding = New Padding(0, 1, 0, 0)
                .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
            End With
            .Columns.RemoveAt(9)
            .Columns.Insert(9, columnCombobox)
            .Columns(10).Visible = False

            For Each column As DataGridViewColumn In .Columns
                column.Name = dvOffice.Table.Columns(column.Index).ColumnName
            Next

            .Columns.Insert(6, New DataGridViewTextBoxColumn)
            With .Columns(6)
                .Name = "RowID"
                .HeaderText = ""
                .Width = 28
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
        End With

        dvLevel.RowFilter = dvOffice.RowFilter
        With Me.dgvLevel
            .DataSource = dvLevel
            .Columns(0).Visible = False
            .Columns(1).Visible = False
            .Columns(2).Visible = False
            With .Columns(3)
                .HeaderText = "级别名称"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Width = 60
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With
            With .Columns(4)
                .HeaderText = "购买额度（元）"
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns(5)
                .HeaderText = "返点比例 %"
                .DefaultCellStyle.Format = "#,0.0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Width = 75
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns(6)
                .HeaderText = "返点额度（元）"
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With
            .Columns(7).Visible = False

            For Each column As DataGridViewColumn In .Columns
                column.Name = dvLevel.Table.Columns(column.Index).ColumnName
            Next

            .Columns.Insert(3, New DataGridViewTextBoxColumn)
            With .Columns(3)
                .Name = "RowID"
                .HeaderText = ""
                .Width = 28
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
        End With

        If Not ToolStripManager.VisualStylesEnabled Then
            Me.dgvOffice.Top -= 2
            Me.dgvOffice.Height += 2
            Me.dgvLevel.Top -= 2
            Me.dgvLevel.Height += 2
        End If

        blSkipDeal = False

        If frmMain.sLoginRoleID = "0" Then '系统管理员只读
            Me.dgvOffice.DefaultCellStyle.BackColor = SystemColors.Control
            Me.dgvOffice.ReadOnly = True
            Me.dgvOffice.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Me.dgvOffice.EditMode = DataGridViewEditMode.EditProgrammatically

            Me.dgvLevel.DefaultCellStyle.BackColor = SystemColors.Control
            Me.dgvLevel.ReadOnly = True
            Me.dgvLevel.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Me.dgvLevel.EditMode = DataGridViewEditMode.EditProgrammatically

            Me.Text = Me.Text & " (只读 Readonly)"
        End If
    End Sub

    Private Sub cbbCity_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbCity.SelectedIndexChanged
        If blSkipDeal Then Return

        dvOffice.RowFilter = "CityID=" & Me.cbbCity.SelectedValue.ToString
        dvLevel.RowFilter = dvOffice.RowFilter

        dtStore.Rows.Clear()
        Dim dtTemp As DataTable = dvOffice.ToTable(True, "StoreID", "StoreName", "SortCode")
        If dtTemp.Select("StoreID=-1").Length = 0 Then
            dtTemp.Rows.Add(-1, "（本市的任何门店）")
        End If
        dtTemp.AcceptChanges()
        dtStore.Merge(dtTemp.Copy)
        dtTemp.Dispose() : dtTemp = Nothing

        Me.dgvOffice.Select()
        Me.dgvLevel.Select()
        Me.cbbCity.Select()
    End Sub

    Private Sub dgvOffice_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvOffice.CellFormatting
        If Me.dgvOffice.Columns(e.ColumnIndex).Name = "RowID" Then
            e.Value = e.RowIndex + 1
        ElseIf Me.dgvOffice.ReadOnly = False Then
            If Me.dgvOffice.Columns(e.ColumnIndex).Name = "PurchaseStoreID" Then
                If Me.dgvOffice("StoreID", e.RowIndex).Value.ToString <> "-1" Then
                    Me.dgvOffice(e.ColumnIndex, e.RowIndex).ReadOnly = True
                    e.CellStyle.BackColor = Color.WhiteSmoke
                End If
            Else
                e.CellStyle.BackColor = Color.WhiteSmoke
            End If
        End If
    End Sub

    Private Sub dgvOffice_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOffice.CellValueChanged
        If blSkipDeal OrElse Me.dgvOffice.ReadOnly Then Return

        If Me.dgvOffice.Columns(e.ColumnIndex).Name = "PurchaseStoreID" Then
            Me.dgvOffice.EndEdit()
            Dim drOffice As DataRow = dvOffice.Table.Select("OfficeID=" & Me.dgvOffice("OfficeID", e.RowIndex).Value.ToString)(0)
            If drOffice("PurchaseStoreID").ToString = drOffice("PurchaseStoreID", DataRowVersion.Original).ToString Then drOffice.AcceptChanges()
            drOffice.EndEdit()

            Me.btnSave.Enabled = (dvOffice.Table.GetChanges() IsNot Nothing OrElse dvLevel.Table.GetChanges() IsNot Nothing)
        End If
    End Sub

    Private Sub dgvOffice_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvOffice.Leave
        If Me.dgvOffice.CurrentCell IsNot Nothing Then Me.dgvOffice.CurrentCell.Selected = False
        If Me.dgvOffice.CurrentRow IsNot Nothing Then Me.dgvOffice.CurrentRow.Selected = False
    End Sub

    Private Sub dgvOffice_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvOffice.SelectionChanged
        If Me.dgvOffice.ReadOnly Then Return
        If Me.dgvOffice.CurrentCell IsNot Nothing AndAlso Me.dgvOffice.CurrentCell.ReadOnly Then Me.dgvOffice.CurrentRow.Selected = True
    End Sub

    Private Sub dgvLevel_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvLevel.CellFormatting
        If Me.dgvLevel.Columns(e.ColumnIndex).Name = "RowID" Then
            e.Value = e.RowIndex + 1
        ElseIf Me.dgvLevel.ReadOnly = False AndAlso Me.dgvLevel.Columns(e.ColumnIndex).ReadOnly Then
            e.CellStyle.BackColor = Color.WhiteSmoke
        End If
    End Sub

    Private Sub dgvLevel_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLevel.CellLeave
        If editingTextBox IsNot Nothing Then
            Select Case Me.dgvLevel.Columns(e.ColumnIndex).Name
                Case "PurchaseQuota"
                    If editingTextBox.Text <> "" Then editingTextBox.Text = Format(CDec(editingTextBox.Text), "#,0.00")
                Case "RateQuota"
                    If editingTextBox.Text <> "" Then editingTextBox.Text = Format(CDec(editingTextBox.Text), "#,0.0")
            End Select
            RemoveHandler editingTextBox.KeyDown, AddressOf editingTextBox_KeyDown
            editingTextBox = Nothing
        End If
    End Sub

    Private Sub dgvLevel_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgvLevel.CellValidating
        If blSkipDeal OrElse Me.dgvLevel.ReadOnly Then Return

        If Me.dgvLevel.Columns(Me.dgvLevel.CurrentCell.ColumnIndex).Name = "RateQuota" Then
            Me.dgvLevel.EndEdit()
            Dim drLevel As DataRow = dvLevel.Table.Select("CityID=" & Me.dgvLevel("CityID", e.RowIndex).Value.ToString & " And LevelID=" & Me.dgvLevel("LevelID", e.RowIndex).Value.ToString)(0)
            If IsNumeric(drLevel("RateQuota").ToString) AndAlso drLevel("RateQuota") > 20 Then
                MessageBox.Show("最高优惠比例不能超过 20% ！    ", "最高优惠比例不能超过 20% ！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub dgvLevel_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLevel.CellValueChanged
        If blSkipDeal OrElse Me.dgvLevel.ReadOnly Then Return

        If "|PurchaseQuota|RateQuota|".IndexOf(Me.dgvLevel.Columns(e.ColumnIndex).Name) > 0 Then
            Me.dgvLevel.EndEdit()
            Dim drLevel As DataRow = dvLevel.Table.Select("CityID=" & Me.dgvLevel("CityID", e.RowIndex).Value.ToString & " And LevelID=" & Me.dgvLevel("LevelID", e.RowIndex).Value.ToString)(0)
            If drLevel("PurchaseQuota").ToString = "" Then drLevel("PurchaseQuota") = drLevel("PurchaseQuota", DataRowVersion.Original)
            If drLevel("RateQuota").ToString = "" Then drLevel("RateQuota") = drLevel("RateQuota", DataRowVersion.Original)
            If drLevel("PurchaseQuota").ToString = "" OrElse drLevel("RateQuota").ToString = "" Then
                drLevel("RebateQuota") = DBNull.Value
            Else
                drLevel("RebateQuota") = drLevel("PurchaseQuota") * drLevel("RateQuota") / 100
            End If
            drLevel.EndEdit()
            Try
                If drLevel("PurchaseQuota") = drLevel("PurchaseQuota", DataRowVersion.Original) AndAlso drLevel("RateQuota") = drLevel("RateQuota", DataRowVersion.Original) Then drLevel.AcceptChanges()
            Catch
            End Try
            If dvLevel.Table.GetChanges() IsNot Nothing Then
                Dim blChanged As Boolean = False, bColumns As Byte = dvLevel.Table.Columns.Count - 1
                For Each drLevel In dvLevel.Table.GetChanges().Rows
                    For bColumn As Byte = 0 To bColumns
                        Try
                            If drLevel(bColumn) <> drLevel(bColumn, DataRowVersion.Original) Then
                                blChanged = True
                                Exit For
                            End If
                        Catch
                            blChanged = True
                            Exit For
                        End Try
                    Next
                    If blChanged Then Exit For
                Next
                If Not blChanged Then dvLevel.Table.AcceptChanges()
            End If

            Me.btnSave.Enabled = (dvOffice.Table.GetChanges() IsNot Nothing OrElse dvLevel.Table.GetChanges() IsNot Nothing)
        End If
    End Sub

    Private Sub dgvLevel_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvLevel.EditingControlShowing
        If "|PurchaseQuota|RateQuota|".IndexOf(Me.dgvLevel.Columns(Me.dgvLevel.CurrentCell.ColumnIndex).Name) > 0 Then
            editingTextBox = CType(e.Control, TextBox)
            editingTextBox.ImeMode = Windows.Forms.ImeMode.Disable
            editingTextBox.Text = editingTextBox.Text.Replace(",", "")
            If Me.dgvLevel.Columns(Me.dgvLevel.CurrentCell.ColumnIndex).Name = "PurchaseQuota" Then
                editingTextBox.MaxLength = 12
            Else
                editingTextBox.MaxLength = 4
            End If
            AddHandler editingTextBox.KeyDown, AddressOf editingTextBox_KeyDown
        End If
    End Sub

    Private Sub dgvLevel_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvLevel.Leave
        If Me.dgvLevel.CurrentCell IsNot Nothing Then Me.dgvLevel.CurrentCell.Selected = False
        If Me.dgvLevel.CurrentRow IsNot Nothing Then Me.dgvLevel.CurrentRow.Selected = False
    End Sub

    Private Sub dgvLevel_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvLevel.SelectionChanged
        If Me.dgvLevel.ReadOnly Then Return
        If Me.dgvLevel.CurrentCell IsNot Nothing AndAlso Me.dgvLevel.CurrentCell.ReadOnly Then Me.dgvLevel.CurrentRow.Selected = True
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Me.btnSave.Enabled = Not Me.SaveChanges
    End Sub

    Private Sub editingTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        If e.KeyCode = Keys.OemPeriod OrElse e.KeyCode = Keys.Decimal Then
            If editingTextBox.SelectedText.IndexOf(".") > -1 OrElse editingTextBox.Text.IndexOf(".") = -1 Then Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Function SaveChanges() As Boolean
        Me.btnSave.Select()
        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在保存更改……"
        frmMain.statusMain.Refresh()

        Dim DB As New DataBase
        DB.Open(True)
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法保存更改！请检查数据库连接。"
            Me.Cursor = Cursors.Default
            Return False
        End If

        Dim blStoreChanged As Boolean = False, blLevelchanged As Boolean = False

        If dvOffice.Table.GetChanges() IsNot Nothing Then
            For Each drOffice As DataRow In dvOffice.Table.Select("", "", DataViewRowState.ModifiedCurrent)
                If drOffice("PurchaseStoreID").ToString <> drOffice("PurchaseStoreID", DataRowVersion.Original).ToString Then
                    If DB.ModifyTable("Update EmployeeOffice Set PurchaseStoreID=" & drOffice("PurchaseStoreID").ToString & " Where OfficeID=" & drOffice("OfficeID").ToString) = -1 Then
                        Me.Cursor = Cursors.Default
                        Return False
                    Else
                        DB.ModifyTable("Exec OperationLogInsert " & frmMain.sSSID & ",'Change Purchase Store From " & drOffice("PurchaseStoreID", DataRowVersion.Original).ToString & " To " & drOffice("PurchaseStoreID").ToString & "', 'EmployeeOffice'," & drOffice("OfficeID").ToString)
                        drOffice.AcceptChanges()
                        blStoreChanged = True
                    End If
                End If
            Next
        End If

        If dvLevel.Table.GetChanges() IsNot Nothing Then
            For Each drLevel As DataRow In dvLevel.Table.Select("", "", DataViewRowState.ModifiedCurrent)
                If drLevel("PurchaseQuota").ToString <> drLevel("PurchaseQuota", DataRowVersion.Original).ToString OrElse drLevel("RateQuota").ToString <> drLevel("RateQuota", DataRowVersion.Original).ToString Then
                    Select Case DB.ModifyTable("Update EmployeeQuota Set PurchaseQuota=" & drLevel("PurchaseQuota").ToString & ",RateQuota=" & (drLevel("RateQuota") / 100).ToString & " Where CityID=" & drLevel("CityID").ToString & " And LevelID=" & drLevel("LevelID").ToString)
                        Case -1
                            Me.Cursor = Cursors.Default
                            Return False
                        Case 0
                            If DB.ModifyTable("Insert Into EmployeeQuota Values (" & drLevel("CityID").ToString & "," & drLevel("LevelID").ToString & "," & drLevel("PurchaseQuota").ToString & "," & (drLevel("RateQuota") / 100).ToString & ")") = -1 Then
                                Me.Cursor = Cursors.Default
                                Return False
                            Else
                                DB.ModifyTable("Exec OperationLogInsert " & frmMain.sSSID & ",'Set Employee Quota For (CityID: " & drLevel("CityID").ToString & ", LevelID: " & drLevel("LevelID").ToString & ") As (PurchaseQuota: " & Format(drLevel("PurchaseQuota"), "#,0.00") & " RMB, RateQuota: " & Format(drLevel("RateQuota"), "#,0.0") & " %)', 'EmployeeQuota', NULL")
                            End If
                            drLevel.AcceptChanges()
                            blLevelchanged = True
                        Case Else
                            DB.ModifyTable("Exec OperationLogInsert " & frmMain.sSSID & ",'Change Employee Quota For (CityID: " & drLevel("CityID").ToString & ", LevelID: " & drLevel("LevelID").ToString & ") From (PurchaseQuota: " & Format(drLevel("PurchaseQuota", DataRowVersion.Original), "#,0.00") & " RMB, RateQuota: " & Format(drLevel("RateQuota", DataRowVersion.Original), "#,0.0") & " %) To (PurchaseQuota: " & Format(drLevel("PurchaseQuota"), "#,0.00") & " RMB, RateQuota: " & Format(drLevel("RateQuota"), "#,0.0") & " %)', 'EmployeeQuota', NULL")
                            drLevel.AcceptChanges()
                            blLevelchanged = True
                    End Select
                End If
            Next
        End If
        DB.Close()

        If blLevelchanged Then
            MessageBox.Show("员工额度设置保存成功。    " & Chr(13) & Chr(13) & "新的额度设置将在下月1日生效。    ", "保存成功。", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf blStoreChanged Then
            MessageBox.Show("购卡门店修改保存成功。    ", "保存成功。", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Me.Cursor = Cursors.Default
        Return True
    End Function
End Class