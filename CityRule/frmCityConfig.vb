Public Class frmCityConfig

    'modify code 038:
    'date;2014/9/24
    'auther:Hyron bjy 
    'remark:返点比率0.0->0.00

    Private blSkipDeal As Boolean = True, blCanModify As Boolean = True, blCanValidate As Boolean = True, sCityID As String
    Private errorCell As DataGridViewCell, sErrorInfo As String = "", editingTextBox As TextBox, sOldValue As String, drPendingRule As DataRow
    Private dtCity As DataTable, dtRole As DataTable, dtCityRule As DataTable, dvValidatedDetails As DataView, dvPendingDetails As DataView, dvCopied As DataView

    Private Sub frmCityConfig_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.cbbCity.Select()
        blSkipDeal = True
        If Me.dgvValidated.CurrentCell IsNot Nothing Then Me.dgvValidated.CurrentCell.Selected = False
        If Me.dgvValidated.CurrentRow IsNot Nothing Then Me.dgvValidated.CurrentRow.Selected = False
        If blCanModify Then
            Me.dgvPending.Focus()
            Me.dgvPending.Select()
            Me.dgvPending.EditMode = DataGridViewEditMode.EditOnEnter
            Me.dgvPending(5, Me.dgvPending.RowCount - 1).Selected = True
            Me.dgvPending.BeginEdit(True)
        Else
            If Me.dgvPending.CurrentCell IsNot Nothing Then Me.dgvPending.CurrentCell.Selected = False
            If Me.dgvPending.CurrentRow IsNot Nothing Then Me.dgvPending.CurrentRow.Selected = False
        End If
        blSkipDeal = False
    End Sub

    Private Sub frmCityConfig_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub frmCityConfig_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim DB As New DataBase()
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打开""城市设置""窗口。请检查数据库连接。"
            Me.Close() : Return
        End If

        If frmMain.sLoginAreaType = "S" Then
            dtCity = DB.GetDataTable("Select C.AreaID,C.AreaType+C.AreaCode+' '+Rtrim(Ltrim(Isnull(C.AreaChineseName,'')+' '+Isnull(C.AreaEnglishName,''))) As AreaFullName From AreaList AS C Inner Join AreaList AS S On C.AreaID = S.ParentAreaID Where S.AreaID=" & frmMain.sLoginAreaID)
            If dtCity Is Nothing Then
                frmMain.statusText.Text = "系统因在检索数据时出错而无法打开""城市设置""窗口。请联系软件开发人员。"
                DB.Close() : Me.Close() : Return
            End If
        Else
            Dim dvTemp As DataView = frmMain.dtLoginStructure.Copy.DefaultView
            dvTemp.RowFilter = "AreaType='C'"
            dvTemp.Sort = "SortCode"
            dtCity = dvTemp.ToTable(True, "AreaID", "AreaFullName")
            dvTemp.Dispose() : dvTemp = Nothing
        End If
        dtCity.Columns.Add("IsLoaded", System.Type.GetType("System.Boolean")).DefaultValue = 0
        dtCity.Rows(0)("IsLoaded") = 1 : dtCity.AcceptChanges()
        dtCity.PrimaryKey = New DataColumn() {dtCity.Columns("AreaID")}

        If dtCity Is Nothing Then
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开""城市设置""窗口。请联系软件开发人员。"
            DB.Close() : Me.Close() : Return
        End If
        With Me.cbbCity
            .DataSource = dtCity
            .ValueMember = "AreaID"
            .DisplayMember = "AreaFullName"
            .SelectedIndex = 0
        End With

        dtRole = DB.GetDataTable("Select * From ValidateRebateRoleList Order By RoleFullName")
        If dtRole Is Nothing Then
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开""城市设置""窗口。请联系软件开发人员。"
            DB.Close() : Me.Close() : Return
        End If

        dtCityRule = DB.GetDataTable("Select * From CityRule Where CityID=" & dtCity.Rows(0)("AreaID").ToString & " And RuleState<>3")
        If dtCityRule Is Nothing Then
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开""城市设置""窗口。请联系软件开发人员。"
            DB.Close() : Me.Close() : Return
        End If

        Try
            Dim dvCityRuleDetails As DataView = DB.GetDataTable("Select * From CityRuleDetails Where CityID=" & dtCity.Rows(0)("AreaID").ToString & " And RuleState<>3").DefaultView
            dvCityRuleDetails.RowFilter = "RuleState=2"
            dvValidatedDetails = dvCityRuleDetails.ToTable.DefaultView
            dvValidatedDetails.Table.AcceptChanges()
            dvValidatedDetails.Sort = "RowID"
            dvCityRuleDetails.RowFilter = "RuleState<2"
            dvPendingDetails = dvCityRuleDetails.ToTable.DefaultView
            dvPendingDetails.Table.AcceptChanges()
            dvPendingDetails.Sort = "RowID"
            dvCityRuleDetails.Dispose() : dvCityRuleDetails = Nothing
        Catch
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开""城市设置""窗口。请联系软件开发人员。"
            DB.Close() : Me.Close() : Return
        End Try

        DB.Close()

        blCanModify = (frmMain.dtAllowedRight.Select("RightName='CityConfigModify'").Length > 0)
        blCanValidate = (frmMain.dtAllowedRight.Select("RightName='CityConfigValidate'").Length > 0)

        With Me.dgvValidated
            .DataSource = dvValidatedDetails
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
                'modify code 038:start-------------------------------------------------------------------------
                '.DefaultCellStyle.Format = "#,0.0"
                .DefaultCellStyle.Format = "#,0.00"
                'modify code 038:start-------------------------------------------------------------------------
            End With
            .Columns(7).Visible = False
            With .Columns(8)
                .HeaderText = "审核者（超过最大返点时）" & Chr(13) & "Who Validate if over Maximum Rate"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            If Not ToolStripManager.VisualStylesEnabled Then .Height += 2
        End With

        With Me.dgvPending
            .DataSource = dvPendingDetails
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
                .ReadOnly = True
            End With
            With .Columns(4)
                .HeaderText = "最小金额 ＞" & Chr(13) & "Minimal AMT"
                .Width = 85
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,0.00"
                If blCanModify Then .ToolTipText = "由系统自动设置，不必手工输入。"
                .ReadOnly = True
            End With
            With .Columns(5)
                .HeaderText = "最大金额 ≤" & Chr(13) & "Maximum AMT"
                .Width = 85
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,0.00"
                If blCanModify Then .ToolTipText = "请在最后一行保留空白（没有上限）"
            End With
            With .Columns(6)
                .HeaderText = "最大返点" & Chr(13) & "Max Disc %"
                .Width = 75
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'modify code 038:start-------------------------------------------------------------------------
                '.DefaultCellStyle.Format = "#,0.0"
                .DefaultCellStyle.Format = "#,0.00"
                'modify code 038:start-------------------------------------------------------------------------
            End With
            If blCanModify Then
                Dim columnCombobox As New DataGridViewComboBoxColumn()
                With columnCombobox
                    .Name = "ApprovableRoleID"
                    .DataPropertyName = "ApprovableRoleID"
                    .DataSource = dtRole
                    .ValueMember = "RoleID"
                    .DisplayMember = "RoleFullName"
                    .HeaderText = "审核者（超过最大返点时）" & Chr(13) & "Who Validate if over Maximum Rate"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .Resizable = DataGridViewTriState.False
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Padding = New Padding(0, 1, 0, 0)
                    .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                End With
                .Columns.RemoveAt(7)
                .Columns.Insert(7, columnCombobox)
                .Columns(8).Visible = False
            Else
                .Columns(7).Visible = False
                With .Columns(8)
                    .HeaderText = "审核者（超过最大返点时）" & Chr(13) & "Who Validate if over Maximum Rate"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .Resizable = DataGridViewTriState.False
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                .ReadOnly = True
                .EditMode = DataGridViewEditMode.EditProgrammatically
            End If
            If Not ToolStripManager.VisualStylesEnabled Then .Height += 2
        End With
        If Not blCanModify AndAlso Not blCanValidate Then Me.Text = Me.Text & " (只读 Readonly)"

        Me.cbbCity.SelectedIndex = -1
        blSkipDeal = False
        Me.cbbCity.SelectedIndex = 0
    End Sub

    Private Sub cbbCity_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbCity.SelectedIndexChanged
        If blSkipDeal Then Return
        blSkipDeal = True
        If errorCell IsNot Nothing Then
            If errorCell.ColumnIndex = 5 Then
                frmMain.statusText.Text = "不能选择其它城市，因为有一行的最大金额错误（" & sErrorInfo & "）！请重新输入该行的最大金额。"
            Else
                frmMain.statusText.Text = "不能选择其它城市，因为有一行的最大返点比率错误（" & sErrorInfo & "）！请重新输入该行的最大返点比率。"
            End If
            Me.cbbCity.SelectedValue = sCityID
            Me.dgvPending.Select()
            Me.dgvPending.EditMode = DataGridViewEditMode.EditOnEnter
            errorCell.Selected = True
            Me.dgvPending.BeginEdit(True)
            blSkipDeal = False
            Return
        End If
        sCityID = Me.cbbCity.SelectedValue.ToString
        Dim drCity As DataRow = dtCity.Rows.Find(sCityID)
        If drCity("IsLoaded").ToString <> "True" Then
            Me.Cursor = Cursors.WaitCursor
            frmMain.statusText.Text = "正在检索城市设置……"
            frmMain.statusMain.Refresh()
            Dim DB As New DataBase, dtRuleTemp As DataTable
            DB.Open()
            If Not DB.IsConnected Then
                frmMain.statusText.Text = "系统因连接不到数据库而无法检索城市设置。请检查数据库连接。"
            Else
                dtRuleTemp = DB.GetDataTable("Select * From CityRule Where CityID=" & sCityID & " And RuleState<>3")
                If dtRuleTemp Is Nothing Then
                    frmMain.statusText.Text = "系统因在检索数据时出错而无法检索城市设置。请联系软件开发人员。"
                Else
                    Try
                        Dim dvCityRuleDetails As DataView = DB.GetDataTable("Select * From CityRuleDetails Where CityID=" & sCityID & " And RuleState<>3").DefaultView
                        dvCityRuleDetails.RowFilter = "RuleState=2"
                        Dim dtDetailsTemp As DataTable = dvCityRuleDetails.ToTable
                        If dtDetailsTemp.Rows.Count > 0 Then
                            dtDetailsTemp.AcceptChanges()
                            dvValidatedDetails.Table.Merge(dtDetailsTemp)
                        End If
                        dvCityRuleDetails.RowFilter = "RuleState<2"
                        dtDetailsTemp = dvCityRuleDetails.ToTable
                        If dtDetailsTemp.Rows.Count > 0 Then
                            dtDetailsTemp.AcceptChanges()
                            dvPendingDetails.Table.Merge(dtDetailsTemp)
                        End If
                        dtDetailsTemp.Dispose() : dtDetailsTemp = Nothing : dvCityRuleDetails.Dispose() : dvCityRuleDetails = Nothing

                        dtCityRule.Merge(dtRuleTemp.Copy)
                        drCity("IsLoaded") = 1 : drCity.AcceptChanges()
                    Catch
                        frmMain.statusText.Text = "系统因在检索数据时出错而无法检索城市设置。请联系软件开发人员。"
                    End Try
                    dtRuleTemp.Dispose() : dtRuleTemp = Nothing : DB.Close()
                End If
            End If
            frmMain.statusText.Text = "就绪。"
            Me.Cursor = Cursors.Default
        End If

        Dim drRows() As DataRow = dtCityRule.Select("CityID=" & sCityID & " And RuleState=2", "", DataViewRowState.Unchanged)
        If drRows.Length = 0 Then
            Me.lblModifier1.Text = ""
            Me.lblModifiedTime1.Text = ""
            Me.lblAuditor1.Text = ""
            Me.lblValidatedTime1.Text = ""
        Else
            Me.lblModifier1.Text = drRows(0)("Modifier").ToString
            Me.lblModifiedTime1.Text = Format(drRows(0)("ModifiedTime"), "yyyy\/MM\/dd HH:mm:ss")
            Me.lblAuditor1.Text = drRows(0)("Auditor").ToString
            Me.lblValidatedTime1.Text = Format(drRows(0)("ValidatedTime"), "yyyy\/MM\/dd HH:mm:ss")
        End If
        dvValidatedDetails.RowFilter = "CityID=" & sCityID
        Me.btnCopy.Enabled = (blCanModify AndAlso dvValidatedDetails.Count > 0)
        If Me.dgvValidated.CurrentCell IsNot Nothing Then
            Me.dgvValidated.CurrentCell.Selected = False : Me.dgvValidated.CurrentRow.Selected = False
        End If

        drRows = dtCityRule.Select("CityID=" & sCityID & " And RuleState<2", "", DataViewRowState.Unchanged Or DataViewRowState.ModifiedOriginal Or DataViewRowState.Added)
        If drRows.Length = 0 Then drPendingRule = Nothing Else drPendingRule = drRows(0)
        drRows = Nothing
        If drPendingRule Is Nothing OrElse drPendingRule.RowState = DataRowState.Added Then
            Me.lblModifier2.Text = ""
            Me.lblModifiedTime2.Text = ""
            Me.lblAuditor2.Text = ""
            Me.lblValidatedTime2.Text = ""
        Else
            Me.lblModifier2.Text = drPendingRule("Modifier").ToString
            Me.lblModifiedTime2.Text = Format(drPendingRule("ModifiedTime"), "yyyy\/MM\/dd HH:mm:ss")
            Me.lblAuditor2.Text = drPendingRule("Auditor").ToString
            If drPendingRule("ValidatedTime").ToString = "" Then
                Me.lblValidatedTime2.Text = ""
            Else
                Me.lblValidatedTime2.Text = Format(drPendingRule("ValidatedTime"), "yyyy\/MM\/dd HH:mm:ss")
            End If
        End If
        dvPendingDetails.RowFilter = "CityID=" & sCityID
        If blCanModify AndAlso dvPendingDetails.Count = 0 Then
            Dim newDetail As DataRowView = dvPendingDetails.AddNew()
            newDetail("CityID") = sCityID
            newDetail("RuleState") = 0
            newDetail("RowID") = 1
            newDetail("StartSalesAMT") = 0

            newDetail("MaxRebateRate") = 0
            newDetail.EndEdit()
        End If
        If drPendingRule Is Nothing OrElse drPendingRule.RowState = DataRowState.Added OrElse drPendingRule("RuleState") = 0 Then
            Me.rdbOK.Checked = False : Me.rdbFailure.Checked = False : Me.txbReason.Text = ""
        ElseIf drPendingRule("RuleState") = 1 Then
            Me.rdbFailure.Checked = True
            Me.txbReason.Text = drPendingRule("StateReason").ToString
        Else
            Me.rdbOK.Checked = True : Me.txbReason.Text = ""
        End If
        Me.pnlValidate.Enabled = (blCanValidate AndAlso drPendingRule IsNot Nothing AndAlso drPendingRule.RowState <> DataRowState.Added)
        Me.btnPaste.Enabled = (dvCopied IsNot Nothing AndAlso (drPendingRule Is Nothing OrElse drPendingRule("RuleState") < 2))
        Me.btnDeleteRow.Enabled = (blCanModify AndAlso drPendingRule IsNot Nothing AndAlso drPendingRule("RuleState") < 2 AndAlso Me.dgvPending.CurrentRow IsNot Nothing AndAlso (Me.dgvPending.CurrentRow.Index > 0 OrElse Me.dgvPending("ApprovableRoleID", 0).Value.ToString <> ""))
        If Me.dgvValidated.CurrentCell IsNot Nothing Then Me.dgvValidated.CurrentCell.Selected = False
        If Me.dgvValidated.CurrentRow IsNot Nothing Then Me.dgvValidated.CurrentRow.Selected = False
        If blCanModify Then
            Me.dgvPending.ReadOnly = False
            Me.dgvPending.EditMode = DataGridViewEditMode.EditOnEnter
            Me.dgvPending.Select()
            Me.dgvPending(5, Me.dgvPending.RowCount - 1).Selected = True
            Me.dgvPending.BeginEdit(True)
        Else
            Me.dgvPending.ReadOnly = True
            If Me.dgvPending.CurrentCell IsNot Nothing Then Me.dgvPending.CurrentCell.Selected = False
            If Me.dgvPending.CurrentRow IsNot Nothing Then Me.dgvPending.CurrentRow.Selected = False
        End If
        blSkipDeal = False
    End Sub

    Private Sub dgvValidated_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvValidated.Leave
        blSkipDeal = True
        If Me.dgvValidated.CurrentCell IsNot Nothing Then Me.dgvValidated.CurrentCell.Selected = False
        If Me.dgvValidated.CurrentRow IsNot Nothing Then Me.dgvValidated.CurrentRow.Selected = False
        blSkipDeal = False
    End Sub

    Private Sub dgvValidated_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvValidated.SelectionChanged
        If blSkipDeal OrElse Me.dgvValidated.CurrentCell Is Nothing Then Return
        blSkipDeal = True
        If Me.dgvValidated.CurrentCell.ColumnIndex = 3 Then
            Me.dgvValidated("StartSalesAMT", Me.dgvValidated.CurrentRow.Index).Selected = True
            Me.dgvValidated.CurrentRow.Selected = True
        Else
            Me.dgvValidated.CurrentRow.Selected = True
        End If
        blSkipDeal = False
    End Sub

    Private Sub btnCopy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        dvCopied = dvValidatedDetails.ToTable.DefaultView
        For Each dr As DataRowView In dvCopied
            dr("RuleState") = 0
        Next
        Me.btnPaste.Enabled = (drPendingRule Is Nothing OrElse drPendingRule("RuleState") < 2)
    End Sub

    Private Sub dgvPending_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvPending.CellFormatting
        If e.ColumnIndex = 4 Then
            If Me.dgvPending.Rows(e.RowIndex).Selected = False Then
                e.CellStyle.SelectionForeColor = SystemColors.ControlText
                e.CellStyle.SelectionBackColor = SystemColors.Window
            End If
        Else
            If errorCell IsNot Nothing AndAlso e.ColumnIndex = errorCell.ColumnIndex AndAlso e.RowIndex = errorCell.RowIndex Then e.CellStyle.ForeColor = Color.Red : e.CellStyle.SelectionForeColor = Color.Red
        End If
    End Sub

    Private Sub dgvPending_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPending.CellLeave
        If editingTextBox IsNot Nothing Then
            Select Case e.ColumnIndex
                Case 5
                    If editingTextBox.Text <> "" Then editingTextBox.Text = Format(CDec(editingTextBox.Text), "#,0.00")
                Case 6
                    'modify code 038:start-------------------------------------------------------------------------
                    'If editingTextBox.Text <> "" Then editingTextBox.Text = Format(CDec(editingTextBox.Text), "#,0.0")
                    If editingTextBox.Text <> "" Then editingTextBox.Text = Format(CDec(editingTextBox.Text), "#,0.00")
                    'modify code 038:start-------------------------------------------------------------------------
            End Select
            editingTextBox = Nothing
        End If
    End Sub

    Private Sub dgvPending_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPending.CellValueChanged
        If blSkipDeal Then Return
        blSkipDeal = True
        Dim sValue As String = Me.dgvPending(e.ColumnIndex, e.RowIndex).Value.ToString
        sErrorInfo = "" : errorCell = Nothing
        If sValue <> "" AndAlso Not IsNumeric(sValue) Then sValue = ""
        'If sValue = "" AndAlso sOldValue <> "" Then Me.dgvPending.EndEdit() : Me.dgvPending(e.ColumnIndex, e.RowIndex).Value = sOldValue : sValue = sOldValue
        frmMain.statusText.Text = "就绪。"

        Select Case e.ColumnIndex
            Case 5
                If sValue = "" Then
                    If e.RowIndex <> Me.dgvPending.RowCount - 1 Then
                        For iRow As Int16 = Me.dgvPending.RowCount - 1 To e.RowIndex + 1 Step -1
                            dvPendingDetails(iRow).Delete()
                        Next
                    End If
                ElseIf e.RowIndex > 0 AndAlso CDec(sValue) <= Me.dgvPending(5, e.RowIndex - 1).Value Then
                    sErrorInfo = IIf(CDec(sValue) = Me.dgvPending(5, e.RowIndex - 1).Value, "等", "低") & "于上一行的最大金额"
                ElseIf e.RowIndex < Me.dgvPending.RowCount - 2 AndAlso CDec(sValue) >= Me.dgvPending(5, e.RowIndex + 1).Value Then
                    sErrorInfo = IIf(CDec(sValue) = Me.dgvPending(5, e.RowIndex + 1).Value, "等", "高") & "于下一行的最大金额"
                ElseIf e.RowIndex = 0 AndAlso Me.dgvPending(7, 0).Value.ToString = "" Then
                    If dtRole.Select("RoleID=4").Length = 0 Then
                        Me.dgvPending(7, 0).Value = dtRole.Rows(0)("RoleID")
                        Me.dgvPending(8, 0).Value = dtRole.Rows(0)("RoleFullName").ToString
                    Else '默认小区经理
                        Me.dgvPending(7, 0).Value = 4
                        Me.dgvPending(8, 0).Value = dtRole.Select("RoleID=4")(0)("RoleFullName").ToString
                    End If
                    drPendingRule = dtCityRule.Rows.Add()
                    drPendingRule("CityID") = sCityID
                    drPendingRule("CityFullName") = Me.cbbCity.Text
                    drPendingRule("RuleState") = 0
                    drPendingRule("StateDescription") = "等待审核 Pending"
                    drPendingRule.EndEdit()
                End If

                If sErrorInfo = "" Then
                    Me.dgvPending.EndEdit()
                    If e.RowIndex = Me.dgvPending.RowCount - 1 Then
                        If sValue <> "" Then
                            Dim newDetail As DataRowView = dvPendingDetails.AddNew()
                            newDetail("CityID") = sCityID
                            newDetail("RuleState") = 0
                            newDetail("RowID") = e.RowIndex + 2
                            newDetail("StartSalesAMT") = CDec(sValue)
                            If dtRole.Select("RoleID=4").Length = 0 Then
                                newDetail("ApprovableRoleID") = dtRole.Rows(0)("RoleID")
                                newDetail("RoleFullName") = dtRole.Rows(0)("RoleFullName").ToString
                            Else '默认小区经理
                                newDetail("ApprovableRoleID") = 4
                                newDetail("RoleFullName") = dtRole.Select("RoleID=4")(0)("RoleFullName").ToString
                            End If
                            newDetail.EndEdit() : newDetail = Nothing
                            If Me.dgvPending("MaxRebateRate", e.RowIndex).Value.ToString = "" Then
                                Me.dgvPending("MaxRebateRate", e.RowIndex).Selected = True
                                Me.dgvPending.BeginEdit(True)
                            Else
                                Me.dgvPending("MaxRebateRate", e.RowIndex + 1).Selected = True
                                Me.dgvPending.BeginEdit(True)
                            End If
                            Me.btnDeleteRow.Enabled = True
                        End If
                    Else
                        Me.dgvPending(4, e.RowIndex + 1).Value = CDec(sValue)
                        Me.dgvPending(4, e.RowIndex + 1).Selected = True
                        Me.dgvPending.BeginEdit(True)
                    End If
                Else
                    errorCell = Me.dgvPending.CurrentCell
                    MessageBox.Show("该行的最大金额不能" & sErrorInfo & "！    " & Chr(13) & Chr(13) & "请重新输入该行的最大金额。    ", "最大金额错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    frmMain.statusText.Text = "此行的最大金额错误（" & sErrorInfo & "）！请重新输入该行的最大金额。"
                    Me.dgvPending(6, e.RowIndex).Selected = True : errorCell.Selected = True
                    Me.dgvPending.BeginEdit(True)
                End If
            Case 6
                If sValue = "" Then
                ElseIf CDec(sValue) > 20 Then
                    sErrorInfo = "大于 20 %"
                ElseIf e.RowIndex > 0 AndAlso Me.dgvPending(6, e.RowIndex - 1).Value.ToString <> "" AndAlso CDec(sValue) <= Me.dgvPending(6, e.RowIndex - 1).Value Then
                    sErrorInfo = IIf(CDec(sValue) = Me.dgvPending(6, e.RowIndex - 1).Value, "等", "低") & "于上一行的最大返点比率"
                ElseIf e.RowIndex < Me.dgvPending.RowCount - 1 AndAlso Me.dgvPending(6, e.RowIndex + 1).Value.ToString <> "" AndAlso CDec(sValue) >= Me.dgvPending(6, e.RowIndex + 1).Value Then
                    sErrorInfo = IIf(CDec(sValue) = Me.dgvPending(6, e.RowIndex + 1).Value, "等", "高") & "于下一行的最大返点比率"
                End If

                If sErrorInfo = "" Then
                    If e.RowIndex = 0 AndAlso Me.dgvPending(7, 0).Value.ToString = "" Then
                        Me.dgvPending(7, 0).Value = dtRole.Rows(0)("RoleID")
                        Me.dgvPending(8, 0).Value = dtRole.Rows(0)("RoleFullName").ToString
                        drPendingRule = dtCityRule.Rows.Add()
                        drPendingRule("CityID") = sCityID
                        drPendingRule("CityFullName") = Me.cbbCity.Text
                        drPendingRule("RuleState") = 0
                        drPendingRule("StateDescription") = "等待审核 Pending"
                        drPendingRule.EndEdit()
                    End If
                    Me.dgvPending.EndEdit()
                Else
                    errorCell = Me.dgvPending.CurrentCell
                    MessageBox.Show("该行的最大返点比率不能" & sErrorInfo & "！    " & Chr(13) & Chr(13) & "请重新输入该行的最大返点比率。    ", "最大返点比率错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    frmMain.statusText.Text = "此行的最大返点比率错误（" & sErrorInfo & "）！请重新输入该行的最大返点比率。"
                    Me.dgvPending(5, e.RowIndex).Selected = True : errorCell.Selected = True
                    Me.dgvPending.BeginEdit(True)
                End If
            Case 7
                If e.RowIndex = 0 AndAlso drPendingRule Is Nothing Then
                    drPendingRule = dtCityRule.Rows.Add()
                    drPendingRule("CityID") = sCityID
                    drPendingRule("CityFullName") = Me.cbbCity.Text
                    drPendingRule("RuleState") = 0
                    drPendingRule("StateDescription") = "等待审核 Pending"
                End If
                Me.dgvPending.EndEdit()
                If Me.dgvPending(e.ColumnIndex, e.RowIndex).Value.ToString = "" Then
                    Me.dgvPending(8, e.RowIndex).Value = DBNull.Value
                Else
                    Me.dgvPending(8, e.RowIndex).Value = dtRole.Select("RoleID=" & Me.dgvPending(e.ColumnIndex, e.RowIndex).Value.ToString)(0)("RoleFullName").ToString
                End If
        End Select

        If sErrorInfo = "" Then
            drPendingRule("RuleState") = 0 : drPendingRule("Auditor") = "" : drPendingRule("ValidatedTime") = DBNull.Value : drPendingRule("StateDescription") = "等待审核 Pending"
            Me.lblAuditor2.Text = "" : Me.lblValidatedTime2.Text = ""
            Me.rdbOK.Checked = False : Me.rdbFailure.Checked = False : Me.txbReason.Text = "" : Me.pnlValidate.Enabled = False
            Me.btnSave.Enabled = True
        End If

        blSkipDeal = False
    End Sub

    Private Sub dgvPending_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvPending.DataError
        If e.ColumnIndex = 7 Then
            Me.dgvPending(e.ColumnIndex, e.RowIndex).Value = DBNull.Value
            e.Cancel = True
        End If
    End Sub

    Private Sub dgvPending_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvPending.EditingControlShowing
        If Me.dgvPending.CurrentCell.ColumnIndex = 5 OrElse Me.dgvPending.CurrentCell.ColumnIndex = 6 Then
            editingTextBox = CType(e.Control, TextBox)
            RemoveHandler editingTextBox.KeyDown, AddressOf editingTextBox_KeyDown
            editingTextBox.ImeMode = Windows.Forms.ImeMode.Disable
            editingTextBox.Text = editingTextBox.Text.Replace(",", "")
            If errorCell Is Nothing Then sOldValue = editingTextBox.Text
            If Me.dgvPending.CurrentCell.ColumnIndex = 5 Then
                editingTextBox.MaxLength = 12
            Else
                editingTextBox.MaxLength = 4
            End If
            AddHandler editingTextBox.KeyDown, AddressOf editingTextBox_KeyDown
        End If
    End Sub

    Private Sub dgvPending_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvPending.Leave
        frmMain.statusText.Text = "就绪。"
        blSkipDeal = True
        If blCanModify Then
            If Me.dgvPending.CurrentCell IsNot Nothing Then Me.dgvPending.CurrentRow.Selected = True
        Else
            If Me.dgvPending.CurrentCell IsNot Nothing Then Me.dgvPending.CurrentCell.Selected = False
            If Me.dgvPending.CurrentRow IsNot Nothing Then Me.dgvPending.CurrentRow.Selected = False
        End If
        blSkipDeal = False
    End Sub

    Private Sub dgvPending_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvPending.SelectionChanged
        If blSkipDeal OrElse Me.dgvPending.CurrentCell Is Nothing Then Return
        blSkipDeal = True
        frmMain.statusText.Text = "就绪。"
        Me.dgvPending.EditMode = DataGridViewEditMode.EditProgrammatically
        If Me.dgvPending.CurrentCell.ColumnIndex = 3 Then
            Me.dgvPending("StartSalesAMT", Me.dgvPending.CurrentRow.Index).Selected = True
            Me.dgvPending.CurrentRow.Selected = True
        ElseIf Me.dgvPending.ReadOnly = True Then
            Me.dgvPending.CurrentRow.Selected = True
        ElseIf Me.dgvPending.CurrentCell.ColumnIndex = 4 Then
            If Me.dgvPending.CurrentCell.RowIndex = 0 Then
                frmMain.statusText.Text = "最小金额由系统自动设置（第一行的最小金额固定为零），不必手工输入。"
            Else
                frmMain.statusText.Text = "最小金额由系统自动设置（上一行的最大金额），不必手工输入。"
            End If
        Else
            Me.dgvPending.EditMode = DataGridViewEditMode.EditOnEnter
            If errorCell IsNot Nothing AndAlso errorCell IsNot Me.dgvPending.CurrentCell Then
                If errorCell.ColumnIndex = 5 Then
                    frmMain.statusText.Text = "此行的最大金额错误（" & sErrorInfo & "）！请重新输入该行的最大金额。"
                Else
                    frmMain.statusText.Text = "此行的最大返点比率错误（" & sErrorInfo & "）！请重新输入该行的最大返点比率。"
                End If
                errorCell.Selected = True
            End If
            Me.dgvPending.BeginEdit(True)
        End If
        Me.btnDeleteRow.Enabled = (blCanModify AndAlso drPendingRule IsNot Nothing AndAlso drPendingRule("RuleState") < 2 AndAlso (Me.dgvPending.CurrentRow.Index > 0 OrElse Me.dgvPending("ApprovableRoleID", 0).Value.ToString <> ""))
        blSkipDeal = False
    End Sub

    Private Sub btnPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaste.Click
        If drPendingRule IsNot Nothing AndAlso MessageBox.Show("粘贴操作将删除原来的设置，是否继续？    ", "请确认粘贴：", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then Return

        blSkipDeal = True
        If errorCell IsNot Nothing Then errorCell = Nothing : sErrorInfo = ""
        For Each dr As DataRowView In dvPendingDetails
            dr.Delete()
        Next
        For Each dr As DataRowView In dvCopied
            dr("CityID") = sCityID : dr.BeginEdit()
        Next
        dvPendingDetails.Table.Merge(dvCopied.ToTable)
        If drPendingRule Is Nothing Then
            drPendingRule = dtCityRule.Rows.Add()
            drPendingRule("CityID") = sCityID
            drPendingRule("CityFullName") = Me.cbbCity.Text
            drPendingRule("RuleState") = 0
            drPendingRule("StateDescription") = "等待审核 Pending"
            drPendingRule.EndEdit()
        Else
            drPendingRule("RuleState") = 0 : drPendingRule("Auditor") = "" : drPendingRule("ValidatedTime") = DBNull.Value : drPendingRule("StateDescription") = "等待审核 Pending"
        End If
        Me.lblAuditor2.Text = "" : Me.lblValidatedTime2.Text = ""
        Me.rdbOK.Checked = False : Me.rdbFailure.Checked = False : Me.txbReason.Text = "" : Me.pnlValidate.Enabled = False
        Me.btnSave.Enabled = True
        blSkipDeal = False
        Me.dgvPending.Select()
        Me.dgvPending(5, dvCopied.Count - 1).Selected = True
        Me.dgvPending(5, dvCopied.Count - 1).Selected = True
    End Sub

    Private Sub btnDeleteRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteRow.Click
        blSkipDeal = True
        Dim iCurrentRow As Integer = Me.dgvPending.CurrentRow.Index
        If errorCell IsNot Nothing AndAlso errorCell.RowIndex = iCurrentRow Then errorCell = Nothing : sErrorInfo = ""
        If dvPendingDetails.Count = 1 Then
            dvPendingDetails(0)(4) = 0
            dvPendingDetails(0)(5) = DBNull.Value
            dvPendingDetails(0)(6) = 0
            dvPendingDetails(0)(7) = DBNull.Value
            dvPendingDetails(0)(8) = DBNull.Value
            drPendingRule.Delete() : drPendingRule = Nothing
            Me.lblModifier2.Text = ""
            Me.lblModifiedTime2.Text = ""
            Me.lblAuditor2.Text = ""
            Me.lblValidatedTime2.Text = ""
        ElseIf iCurrentRow = 0 Then
            dvPendingDetails(1)(4) = 0
            For iRow As Int16 = 1 To dvPendingDetails.Count - 1
                dvPendingDetails(iRow)(3) = iRow
            Next
            dvPendingDetails(0).Delete()
        ElseIf iCurrentRow = dvPendingDetails.Count - 1 Then
            dvPendingDetails(iCurrentRow - 1)(5) = DBNull.Value
            dvPendingDetails(iCurrentRow).Delete()
        Else
            dvPendingDetails(iCurrentRow - 1)(5) = dvPendingDetails(iCurrentRow + 1)(4)
            For iRow As Int16 = iCurrentRow + 1 To dvPendingDetails.Count - 1
                dvPendingDetails(iRow)(3) = iRow
            Next
            dvPendingDetails(iCurrentRow).Delete()
        End If

        If drPendingRule IsNot Nothing Then
            drPendingRule("RuleState") = 0 : drPendingRule("Auditor") = "" : drPendingRule("ValidatedTime") = DBNull.Value : drPendingRule("StateDescription") = "等待审核 Pending"
        End If
        Me.lblAuditor2.Text = "" : Me.lblValidatedTime2.Text = ""
        Me.rdbOK.Checked = False : Me.rdbFailure.Checked = False : Me.txbReason.Text = "" : Me.pnlValidate.Enabled = False
        Me.btnSave.Enabled = True
        blSkipDeal = False
        If Me.dgvPending.CurrentRow IsNot Nothing Then
            Me.dgvPending(3, Me.dgvPending.CurrentRow.Index).Selected = True
            Me.dgvPending.CurrentRow.Selected = True
        End If
    End Sub

    Private Sub rdbOK_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbOK.CheckedChanged
        If blSkipDeal OrElse Me.rdbOK.Checked = False Then Return
        If errorCell IsNot Nothing Then
            If errorCell.ColumnIndex = 5 Then
                frmMain.statusText.Text = "不能审核该规则，因为有一行的最大金额错误（" & sErrorInfo & "）！请重新输入该行的最大金额。"
            Else
                frmMain.statusText.Text = "不能审核该规则，因为有一行的最大返点比率错误（" & sErrorInfo & "）！请重新输入该行的最大返点比率。"
            End If
            Me.dgvPending.Select()
            Me.dgvPending.EditMode = DataGridViewEditMode.EditOnEnter
            errorCell.Selected = True
            Me.dgvPending.BeginEdit(True)
            Return
        End If
        drPendingRule("RuleState") = 2
        drPendingRule("StateReason") = ""
        Me.dgvPending.ReadOnly = True
        Me.btnPaste.Enabled = False : Me.btnDeleteRow.Enabled = False
        Me.btnSave.Enabled = True
    End Sub

    Private Sub rdbFailure_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbFailure.CheckedChanged
        Me.txbReason.ReadOnly = Not Me.rdbFailure.Checked
        If blSkipDeal OrElse Me.rdbFailure.Checked = False Then Return
        drPendingRule("RuleState") = 1
        drPendingRule("StateReason") = Me.txbReason.Text.Trim
        If blCanModify Then
            Me.dgvPending.ReadOnly = False
            Me.btnPaste.Enabled = (dvCopied IsNot Nothing)
            Me.btnDeleteRow.Enabled = True
        End If
        Me.btnSave.Enabled = True
        Me.txbReason.Select() : Me.txbReason.SelectAll()
    End Sub

    Private Sub txbReason_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbReason.Leave
        If Me.rdbFailure.Checked = False Then Return
        If Me.txbReason.Text <> Me.txbReason.Text.Trim Then Me.txbReason.Text = Me.txbReason.Text.Trim
        If drPendingRule("StateReason").ToString <> Me.txbReason.Text Then
            drPendingRule("StateReason") = Me.txbReason.Text
            Me.btnSave.Enabled = True
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Me.SaveChanges()
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
        If errorCell IsNot Nothing Then
            If errorCell.ColumnIndex = 5 Then
                MessageBox.Show("不能保存修改，因为有一行的最大金额错误（" & sErrorInfo & "）！    " & Chr(13) & Chr(13) & "请重新输入该行的最大金额。    ", "不能保存修改！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                frmMain.statusText.Text = "不能保存修改，因为有一行的最大金额错误（" & sErrorInfo & "）！请重新输入该行的最大金额。"
            Else
                MessageBox.Show("不能保存修改，因为有一行的返点比率错误（" & sErrorInfo & "）！    " & Chr(13) & Chr(13) & "请重新输入该行的返点比率。    ", "不能保存修改！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                frmMain.statusText.Text = "不能保存修改，因为有一行的最大返点比率错误（" & sErrorInfo & "）！请重新输入该行的最大返点比率。"
            End If
            blSkipDeal = True
            Me.dgvPending.Select()
            Me.dgvPending.EditMode = DataGridViewEditMode.EditOnEnter
            errorCell.Selected = True
            Me.dgvPending.BeginEdit(True)
            blSkipDeal = False
            Me.btnSave.Enabled = False : Return False
        End If

        For Each drRebate As DataGridViewRow In Me.dgvPending.Rows
            If drRebate.Cells("MaxRebateRate").Value.ToString = "" Then
                MessageBox.Show("不能保存修改，因为有一行的最大返点比率未设置！    " & Chr(13) & Chr(13) & "请设置该行的最大返点比率。    ", "不能保存修改！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                frmMain.statusText.Text = "不能保存修改，因为有一行的最大返点比率未设置！请设置该行的最大返点比率。"
                blSkipDeal = True
                Me.dgvPending.Select()
                Me.dgvPending.EditMode = DataGridViewEditMode.EditOnEnter
                drRebate.Cells("MaxRebateRate").Selected = True
                Me.dgvPending.BeginEdit(True)
                blSkipDeal = False
                Me.btnSave.Enabled = False : Return False
            End If
        Next

        Dim dtChanges As New DataTable, drChange As DataRow, drRuleRows() As DataRow, drDetailRows() As DataRow, drPendingRows() As DataRow = Nothing, iCity As Integer = 0
        dtChanges.Columns.Add("CityID", System.Type.GetType("System.Int16"))
        dtChanges.Columns.Add("CityFullName", System.Type.GetType("System.String"))
        dtChanges.Columns.Add("Description", System.Type.GetType("System.String"))
        dtChanges.Columns.Add("Result", System.Type.GetType("System.String"))
        dtChanges.Columns.Add("SQL", System.Type.GetType("System.String"))

        For Each drCity As DataRow In dtCity.Rows
            drRuleRows = dtCityRule.Select("CityID=" & drCity("AreaID").ToString, "", DataViewRowState.Added)
            If drRuleRows.Length = 0 Then
                drRuleRows = dtCityRule.Select("CityID=" & drCity("AreaID").ToString, "", DataViewRowState.ModifiedCurrent)
                If drRuleRows.Length = 0 Then
                    drRuleRows = dtCityRule.Select("CityID=" & drCity("AreaID").ToString, "", DataViewRowState.Deleted)
                    If drRuleRows.Length > 0 Then
                        ReDim Preserve drPendingRows(iCity)
                        drPendingRows(iCity) = drRuleRows(0)
                        iCity += 1
                        drChange = dtChanges.Rows.Add()
                        drChange("CityID") = drCity("AreaID")
                        drChange("CityFullName") = drCity("AreaFullName").ToString.Insert(drCity("AreaFullName").ToString.IndexOf(" ", 6) + 1, Chr(13))
                        drChange("Description") = "删除未通过审核的城市返点规则" & Chr(13) & "Delete City's Discount Scale which did not pass validation."
                        drChange("Result") = "没有新规则，等待下一次建立" & Chr(13) & "No new rule, wait to create next time..."
                        drChange("SQL") = "Exec CityRebateRuleModification @RuleID=" & drRuleRows(0)("RuleID", DataRowVersion.Original).ToString & ",@IsDeleted=1,@SSID=" & frmMain.sSSID
                    End If
                Else
                    drDetailRows = dvPendingDetails.Table.Select("CityID=" & drCity("AreaID").ToString, "", DataViewRowState.Added Or DataViewRowState.Deleted Or DataViewRowState.ModifiedCurrent)
                    If drDetailRows.Length = 0 Then
                        If drRuleRows(0)("RuleState") <> drRuleRows(0)("RuleState", DataRowVersion.Original) Then
                            ReDim Preserve drPendingRows(iCity)
                            drPendingRows(iCity) = drRuleRows(0)
                            iCity += 1
                            drChange = dtChanges.Rows.Add()
                            drChange("CityID") = drCity("AreaID")
                            drChange("CityFullName") = drCity("AreaFullName").ToString.Insert(drCity("AreaFullName").ToString.IndexOf(" ", 6) + 1, Chr(13))
                            If drRuleRows(0)("RuleState") = 1 Then
                                drChange("Description") = "审核城市返点规则（不通过）" & Chr(13) & "Not approve City's Discount Scale."
                                drChange("Result") = "规则不生效，等待下一次修改" & Chr(13) & "Rule ineffective, wait to modify again next time..."
                                drChange("SQL") = "Exec CityRebateRuleModification @RuleID=" & drRuleRows(0)("RuleID").ToString & ",@RuleState=1" & IIf(drRuleRows(0)("StateReason").ToString = "", "", ",@StateReason='" & drRuleRows(0)("StateReason").ToString.Replace("'", "''") & "'") & ",@SSID=" & frmMain.sSSID
                            Else
                                drChange("Description") = "审核城市返点规则" & Chr(13) & "Approve City's Discount Scale."
                                drChange("Result") = "规则审核后立即生效" & Chr(13) & "Rule effective immediately since it had been approved."
                                drChange("SQL") = "Exec CityRebateRuleModification @RuleID=" & drRuleRows(0)("RuleID").ToString & ",@CityID=" & drCity("AreaID").ToString & ",@RuleState=2,@SSID=" & frmMain.sSSID
                            End If
                            drChange.EndEdit()
                        End If
                    Else
                        ReDim Preserve drPendingRows(iCity)
                        drPendingRows(iCity) = drRuleRows(0)
                        iCity += 1
                        drChange = dtChanges.Rows.Add()
                        drChange("CityID") = drCity("AreaID")
                        drChange("CityFullName") = drCity("AreaFullName").ToString.Insert(drCity("AreaFullName").ToString.IndexOf(" ", 6) + 1, Chr(13))
                        If drRuleRows(0)("RuleState") = drRuleRows(0)("RuleState", DataRowVersion.Original) OrElse drRuleRows(0)("RuleState", DataRowVersion.Original) = 1 Then
                            drChange("Description") = "修改城市返点规则" & Chr(13) & "Modify City's Discount Scale."
                            drChange("Result") = "规则未生效，等待审核" & Chr(13) & "Rule ineffective, wait to approve..."
                            drChange("SQL") = "Exec CityRebateRuleModification @CityID=" & drCity("AreaID").ToString & ",@SSID=" & frmMain.sSSID
                        Else
                            drChange("Description") = "修改并审核城市返点规则" & Chr(13) & "Modify and then approve City's Discount Scale."
                            drChange("Result") = "规则审核后立即生效" & Chr(13) & "Rule effective immediately since it had been approved."
                            drChange("SQL") = "Exec CityRebateRuleModification @CityID=" & drCity("AreaID").ToString & ",@RuleState=2,@SSID=" & frmMain.sSSID
                        End If
                        drChange.EndEdit()
                    End If
                End If
            Else
                ReDim Preserve drPendingRows(iCity)
                drPendingRows(iCity) = drRuleRows(0)
                iCity += 1
                drChange = dtChanges.Rows.Add()
                drChange("CityID") = drCity("AreaID")
                drChange("CityFullName") = drCity("AreaFullName").ToString.Insert(drCity("AreaFullName").ToString.IndexOf(" ", 6) + 1, Chr(13))
                drChange("Description") = "建立新的城市返点规则 Create new City's Discount Scale"
                drChange("Result") = "新规则未生效，等待审核 New rule ineffective, wait to approve..."
                drChange("SQL") = "Exec CityRebateRuleModification @CityID=" & drCity("AreaID").ToString & ",@SSID=" & frmMain.sSSID
                drChange.EndEdit()
            End If
        Next

        If dtChanges.Rows.Count = 0 Then
            MessageBox.Show("未发现任何需要保存的规则 No anything need to save。    ", "规则无变化。", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dtChanges.Dispose() : dtChanges = Nothing
            dtCityRule.AcceptChanges() : dvPendingDetails.Table.AcceptChanges()
            Me.btnSave.Enabled = False
            Return True
        End If

        With frmConfirmSaveRule
            With .dgvChanges
                .DataSource = dtChanges
                .Columns(0).Visible = False
                With .Columns(1)
                    .HeaderText = "城市 City"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                With .Columns(2)
                    .HeaderText = "更改描述" & Chr(13) & "Modification Description"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .MinimumWidth = .Width
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .Resizable = DataGridViewTriState.False
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                With .Columns(3)
                    .HeaderText = "保存后结果" & Chr(13) & "Result after Saved"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .MinimumWidth = .Width
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .Resizable = DataGridViewTriState.False
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                End With
                .Columns(4).Visible = False
            End With
            If .ShowDialog <> Windows.Forms.DialogResult.OK Then
                dtChanges.Dispose() : dtChanges = Nothing
                .Dispose() : Return False
            End If
            .Dispose()
        End With

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在保存更改……"
        frmMain.statusMain.Refresh()

        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法保存更改！请检查数据库连接。"
            dtChanges.Dispose() : dtChanges = Nothing
            Me.Cursor = Cursors.Default
            Return False
        End If

        Dim tempDetails As New DataTable, newDetail As DataRow, dtResult As DataTable = Nothing
        tempDetails.Columns.Add("RowID", System.Type.GetType("System.Byte"))
        tempDetails.Columns.Add("StartSalesAMT", System.Type.GetType("System.Decimal"))
        tempDetails.Columns.Add("EndSalesAMT", System.Type.GetType("System.Decimal"))
        tempDetails.Columns.Add("MaxRebateRate", System.Type.GetType("System.Decimal"))
        tempDetails.Columns.Add("ApprovableRoleID", System.Type.GetType("System.Byte"))

        If dtChanges.Select("SQL Like '%@RuleID=%'").Length <> dtChanges.Rows.Count Then '当参数中不包含@RuleID时表示需要修改RuleDetails
            If DB.ModifyTable("Select RowID,StartSalesAMT,EndSalesAMT,MaxRebateRate,ApprovableRoleID Into #tempDetails From CityRebateRuleDetails Where 1=2") = -1 Then
                frmMain.statusText.Text = "保存更改失败！"
                DB.Close() : Me.Cursor = Cursors.Default
                Return False
            End If
        End If
        iCity = 0
        Dim blAllOK As Boolean = True, blAllFailure As Boolean = True
        For Each drChange In dtChanges.Rows
            frmMain.statusText.Text = "正在保存对城市""" & drChange("CityFullName").ToString.Replace(Chr(13), "") & """的返点规则更改……"
            frmMain.statusMain.Refresh()
            If drChange("SQL").ToString.IndexOf("@RuleID=") = -1 Then
                For Each drDetail As DataRow In dvPendingDetails.Table.Select("CityID=" & drChange("CityID").ToString, "RowID")
                    newDetail = tempDetails.Rows.Add()
                    newDetail("RowID") = drDetail("RowID")
                    newDetail("StartSalesAMT") = drDetail("StartSalesAMT")
                    newDetail("EndSalesAMT") = drDetail("EndSalesAMT")
                    newDetail("MaxRebateRate") = drDetail("MaxRebateRate") / 100
                    newDetail("ApprovableRoleID") = drDetail("ApprovableRoleID")
                    newDetail.EndEdit() : newDetail.AcceptChanges()
                Next

                If DB.BulkCopyTable("#tempDetails", tempDetails) = -1 Then
                    frmMain.statusText.Text = "保存城市""" & drChange("CityFullName").ToString.Replace(Chr(13), "") & """的返点规则更改失败！"
                    frmMain.statusMain.Refresh()
                    tempDetails.Dispose() : tempDetails = Nothing
                    dtChanges.Dispose() : dtChanges = Nothing
                    DB.Close() : Me.Cursor = Cursors.Default
                    Return False
                End If
                tempDetails.Rows.Clear()
            End If

            dtResult = DB.GetDataTable(drChange("SQL").ToString)
            If dtResult Is Nothing Then
                frmMain.statusText.Text = "保存城市""" & drChange("CityFullName").ToString.Replace(Chr(13), "") & """的返点规则更改失败！"
                frmMain.statusMain.Refresh()
                tempDetails.Dispose() : tempDetails = Nothing
                dtChanges.Dispose() : dtChanges = Nothing
                DB.Close() : Me.Cursor = Cursors.Default
                Return False
            Else
                Select Case dtResult.Rows(0)(0).ToString
                    Case "AlreadyDeleted"
                        If drChange("SQL").ToString.IndexOf("@IsDeleted=") = -1 Then
                            MessageBox.Show("该城市的返点规则已被他人删除，您不再可以审核它！    " & Chr(13) & "This City's discount scale had been deleted by someone else, you can not validate it any longer!    " & Chr(13) & Chr(13) & "城市 City: " & drChange("CityFullName").ToString.Replace(Chr(13), "") & Chr(13) & Chr(13) & "请先关闭该窗口，然后再打开以查看该城市的最新规则。    ", "不能审核城市返点规则 You can not validate discount scale!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            blAllOK = False
                        Else
                            MessageBox.Show("该城市的返点规则已被他人删除，您无须再删除它！    " & Chr(13) & "This City's discount scale had been deleted by someone else, you don't need delete again!    " & Chr(13) & Chr(13) & "城市 City: " & drChange("CityFullName").ToString.Replace(Chr(13), ""), "无须删除城市返点规则 You don't need delete discount scale!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            drPendingRows(iCity).AcceptChanges()
                        End If
                        frmMain.statusText.Text = "保存城市""" & drChange("CityFullName").ToString.Replace(Chr(13), "") & """的返点规则更改失败！"
                        frmMain.statusMain.Refresh()
                    Case "AlreadyValidated"
                        If drChange("SQL").ToString.IndexOf("@IsDeleted=") = -1 Then
                            MessageBox.Show("该城市的返点规则已被他人审核，您无须再审核它！    " & Chr(13) & "This City's discount scale had been validated by someone else, you can not validate again!    " & Chr(13) & Chr(13) & "城市 City: " & drChange("CityFullName").ToString.Replace(Chr(13), "") & Chr(13) & Chr(13) & "请先关闭该窗口，然后再打开以查看该城市规则的最新状态。    ", "无须审核城市返点规则 You don't need validate discount scale!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            MessageBox.Show("该城市的返点规则已被他人审核，您不再可以删除它！    " & Chr(13) & "This City's discount scale had been validated by someone else, you can not delete it any longer!    " & Chr(13) & Chr(13) & "城市 City: " & drChange("CityFullName").ToString.Replace(Chr(13), "") & Chr(13) & Chr(13) & "请先关闭该窗口，然后再打开以查看该城市规则的最新状态。    ", "不能删除城市返点规则 You can not delete discount scale!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If
                        blAllOK = False
                        frmMain.statusText.Text = "保存城市""" & drChange("CityFullName").ToString.Replace(Chr(13), "") & """的返点规则更改失败！"
                        frmMain.statusMain.Refresh()
                    Case "Error"
                        MessageBox.Show("保存城市返点规则时出现错误！下面是数据库的内部错误提示：    " & Chr(13) & Chr(13) & dtResult.Rows(0)("ErrorInfo").ToString & Space(4) & Chr(13) & Chr(13) & "请放弃保存，在关闭窗口后重试。如果仍有问题，请联系软件开发人员。    ", "保存城市返点规则失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        frmMain.statusText.Text = "保存城市""" & drChange("CityFullName").ToString.Replace(Chr(13), "") & """的返点规则更改失败！"
                        frmMain.statusMain.Refresh()
                        tempDetails.Dispose() : tempDetails = Nothing
                        dtChanges.Dispose() : dtChanges = Nothing
                        dtResult.Dispose() : dtResult = Nothing
                        DB.Close() : Me.Cursor = Cursors.Default
                        Return False
                    Case Else
                        If drChange("SQL").ToString.IndexOf("@IsDeleted") = -1 Then
                            If dtResult.Rows(0)("RuleID").ToString <> drPendingRows(iCity)("RuleID").ToString Then
                                For Each dr As DataRow In dvPendingDetails.Table.Select("CityID=" & drChange("CityID").ToString)
                                    dr("RuleID") = dtResult.Rows(0)("RuleID") : dr.AcceptChanges()
                                Next
                                drPendingRows(iCity)("RuleID") = dtResult.Rows(0)("RuleID")
                            End If
                            If dtResult.Rows(0)("ModifiedTime").ToString <> "" Then
                                drPendingRows(iCity)("Modifier") = frmMain.sLoginUserRealName
                                drPendingRows(iCity)("ModifiedTime") = dtResult.Rows(0)("ModifiedTime")
                            End If
                            If dtResult.Rows(0)("ValidatedTime").ToString <> "" Then
                                drPendingRows(iCity)("Auditor") = frmMain.sLoginUserRealName
                                drPendingRows(iCity)("ValidatedTime") = dtResult.Rows(0)("ValidatedTime")
                            End If

                            If drPendingRows(iCity)("RuleState") = 2 Then
                                Dim drValidatedRules() As DataRow = dtCityRule.Select("CityID=" & drChange("CityID").ToString & " And RuleState=2", "", DataViewRowState.Unchanged)
                                If drValidatedRules.Length > 0 Then
                                    drValidatedRules(0).Delete() : drValidatedRules(0).AcceptChanges()
                                    For Each drDetail As DataRow In dvValidatedDetails.Table.Select("CityID=" & drChange("CityID").ToString)
                                        drDetail.Delete() : drDetail.AcceptChanges()
                                    Next
                                End If
                                drValidatedRules = Nothing
                                drDetailRows = dvPendingDetails.Table.Select("CityID=" & drChange("CityID").ToString)
                                Dim iRows As Int16 = drDetailRows.Length - 1, drValidatedDetail As DataRowView, bColumns As Byte = dvPendingDetails.Table.Columns.Count - 1
                                For iRow As Int16 = iRows To 0 Step -1
                                    drValidatedDetail = dvValidatedDetails.AddNew
                                    For bColumn As Byte = 0 To bColumns
                                        drValidatedDetail(bColumn) = drDetailRows(iRow)(bColumn)
                                    Next
                                    drValidatedDetail.EndEdit() : drValidatedDetail.Row.AcceptChanges()
                                    drDetailRows(iRow).Delete() : drDetailRows(iRow).AcceptChanges()
                                Next
                            End If
                        End If
                        drPendingRows(iCity).AcceptChanges()
                        blAllFailure = False
                End Select
            End If
            iCity += 1
        Next

        blSkipDeal = True
        Dim sCityID As String = Me.cbbCity.SelectedValue.ToString
        Me.cbbCity.SelectedIndex = -1
        blSkipDeal = False
        Me.cbbCity.SelectedValue = sCityID

        DB.Close()
        tempDetails.Dispose() : tempDetails = Nothing
        dtChanges.Dispose() : dtChanges = Nothing
        dtResult.Dispose() : dtResult = Nothing
        Me.Cursor = Cursors.Default

        If blAllOK Then
            dtCityRule.AcceptChanges()
            dvPendingDetails.Table.AcceptChanges()
            frmMain.statusText.Text = IIf(iCity = 1, "城市返点规则更改保存成功。", "所有城市返点规则更改保存成功。")
            Me.btnSave.Enabled = False
            Return True
        ElseIf blAllFailure Then
            frmMain.statusText.Text = IIf(iCity = 1, "城市返点规则更改保存失败！", "所有城市返点规则更改保存失败！")
            Return False
        Else
            frmMain.statusText.Text = "部分城市返点规则更改保存成功。"
            Return False
        End If
    End Function
End Class