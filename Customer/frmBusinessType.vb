Public Class frmBusinessType

    Private dvArea As DataView, dtCity As DataTable, dtType As DataTable, dtCityType As DataTable, dtList As DataTable, dvList As DataView
    Private blSkipdeal As Boolean = True, editingTextBox As TextBox, blIsReadOnly As Boolean = False, sOldValue As String = "", sCityID As String = ""

    Private Sub frmBusinessType_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Me.dgvList.CurrentCell IsNot Nothing AndAlso Me.dgvList.CurrentCell.ReadOnly = False Then
            Me.dgvList.CurrentCell.Selected = False
            Me.dgvList.CurrentCell.Selected = True
        End If

        If Not ToolStripManager.VisualStylesEnabled AndAlso Me.dgvList.Height <> 410 Then Me.dgvList.Height = 410
    End Sub

    Private Sub frmBusinessType_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub frmBusinessType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DB As New DataBase()
        DB.Open(True)
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打开""商业类型""窗口。请检查数据库连接。"
            Me.Close() : Return
        End If

        Try
            dvArea = DB.GetDataTable("Select AreaID,AreaType+AreaCode+' '+Isnull(AreaChineseName,'')+' '+Isnull(AreaEnglishName,'') As AreaFullName,AreaType,ParentAreaID From AreaList Where AreaType<>'S'").DefaultView
            dvArea.Sort = "AreaFullName"
        Catch
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开""商业类型""窗口。请联系软件开发人员。"
            DB.Close() : Me.Close() : Return
        End Try

        dtType = DB.GetDataTable("Select * From BusinessType")
        If dtType Is Nothing Then
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开""商业类型""窗口。请联系软件开发人员。"
            DB.Close() : Me.Close() : Return
        End If
        dtCityType = DB.GetDataTable("Select * From CityBusinessType")
        If dtCityType Is Nothing Then
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开""商业类型""窗口。请联系软件开发人员。"
            DB.Close() : Me.Close() : Return
        End If
        DB.Close()

        If frmMain.sLoginAreaType = "S" Then
            sCityID = frmMain.dtLoginStructure.Rows.Find(frmMain.sLoginAreaID)("ParentAreaID").ToString
            dvArea.RowFilter = "AreaID=" & sCityID
            dtCity = dvArea.ToTable(True, "AreaID", "AreaFullName")
        Else
            Dim dvTemp As DataView = frmMain.dtLoginStructure.Copy.DefaultView
            dvTemp.RowFilter = "AreaType='C'"
            dvTemp.Sort = "SortCode"
            dtCity = dvTemp.ToTable(True, "AreaID", "AreaFullName")
            dvTemp.Dispose() : dvTemp = Nothing
        End If
        dtCity.AcceptChanges()

        dtList = New DataTable()
        dtList.Columns.Add("Selected", System.Type.GetType("System.Boolean"))
        dtList.Columns.Add("Code", System.Type.GetType("System.String"))
        dtList.Columns.Add("ChineseName", System.Type.GetType("System.String"))
        dtList.Columns.Add("EnglishName", System.Type.GetType("System.String"))
        dtList.Columns.Add("Level", System.Type.GetType("System.String"))
        dtList.Columns.Add("ID", System.Type.GetType("System.Int16"))
        dtList.Columns.Add("IsInnerType", System.Type.GetType("System.Boolean"))
        dtList.Columns.Add("CustomerQTY", System.Type.GetType("System.Int32"))
        dvList = New DataView(dtList)
        dvList.Sort = "Code"

        With Me.dgvList
            .DataSource = dvList
            Dim checkboxColumn As New DataGridViewCheckBoxColumn
            With checkboxColumn
                .DataPropertyName = "Selected"
                .HeaderText = "Selected"
                .TrueValue = 1
                .Width = 60
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            .Columns.RemoveAt(0)
            .Columns.Insert(0, checkboxColumn)
            With .Columns(1)
                .HeaderText = "Code"
                .Width = 35
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns(2)
                .HeaderText = "中文名称 Chinsee Name"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns(3)
                .HeaderText = "英文名称 English Name"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns(4)
                .HeaderText = "Level"
                .Width = 100
                .DefaultCellStyle.BackColor = SystemColors.Control
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With
            .Columns(5).Visible = False
            .Columns(6).Visible = False
            .Columns(7).Visible = False
        End With

        blIsReadOnly = (frmMain.dtAllowedRight.Select("RightName='BusinessTypeMaintance'").Length = 0)

        If blIsReadOnly Then
            Me.dgvList.ReadOnly = True
            Me.dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Me.dgvList.EditMode = DataGridViewEditMode.EditProgrammatically
        End If

        With Me.cbbCity
            .DataSource = dtCity
            .ValueMember = "AreaID"
            .DisplayMember = "AreaFullName"
        End With
        Me.cbbCity.SelectedIndex = -1
        blSkipdeal = False
        Me.cbbCity.SelectedIndex = 0

        Me.btnAdd.Enabled = Not blIsReadOnly
        If blIsReadOnly Then Me.Text = Me.Text & " (只读 Readonly)"
    End Sub

    Private Sub cbbCity_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbCity.SelectedIndexChanged
        If blSkipdeal Then Return
        Me.chbShowSelected.Checked = False
        sCityID = Me.cbbCity.SelectedValue.ToString
        dtList.Rows.Clear()
        Dim sAreaID As String = sCityID, dvType As DataView = dtType.DefaultView, drType As DataRow
        dvType.RowFilter = "AreaID=" & sAreaID
        For Each dr As DataRowView In dvType
            drType = dtList.Rows.Add()
            If dtCityType.Select("CityID=" & sCityID & " And BusinessTypeID=" & dr("BusinessTypeID").ToString).Length = 0 Then
                drType("Selected") = 0
            Else
                drType("Selected") = 1
            End If
            drType("Code") = dr("BusinessTypeCode").ToString
            drType("ChineseName") = dr("BusinessTypeChineseName").ToString
            drType("EnglishName") = dr("BusinessTypeEnglishName").ToString
            drType("Level") = "City's"
            drType("ID") = dr("BusinessTypeID")
            drType("IsInnerType") = 0
            drType("CustomerQTY") = dr("CustomerQTY")
        Next
        dvArea.RowFilter = "AreaID=" & sAreaID
        sAreaID = dvArea(0)("ParentAreaID").ToString
        dvType.RowFilter = "AreaID=" & sAreaID
        For Each dr As DataRowView In dvType
            drType = dtList.Rows.Add()
            If dtCityType.Select("CityID=" & sCityID & " And BusinessTypeID=" & dr("BusinessTypeID").ToString).Length = 0 Then
                drType("Selected") = 0
            Else
                drType("Selected") = 1
            End If
            drType("Code") = dr("BusinessTypeCode").ToString
            drType("ChineseName") = dr("BusinessTypeChineseName").ToString
            drType("EnglishName") = dr("BusinessTypeEnglishName").ToString
            drType("Level") = "Regional"
            drType("ID") = dr("BusinessTypeID")
            drType("IsInnerType") = 0
            drType("CustomerQTY") = dr("CustomerQTY")
        Next
        dvArea.RowFilter = "AreaID=" & sAreaID
        sAreaID = dvArea(0)("ParentAreaID").ToString
        dvType.RowFilter = "AreaID=" & sAreaID
        For Each dr As DataRowView In dvType
            drType = dtList.Rows.Add()
            If dtCityType.Select("CityID=" & sCityID & " And BusinessTypeID=" & dr("BusinessTypeID").ToString).Length = 0 Then
                drType("Selected") = 0
            Else
                drType("Selected") = 1
            End If
            drType("Code") = dr("BusinessTypeCode").ToString
            drType("ChineseName") = dr("BusinessTypeChineseName").ToString
            drType("EnglishName") = dr("BusinessTypeEnglishName").ToString
            drType("Level") = "Territory's"
            drType("ID") = dr("BusinessTypeID")
            drType("IsInnerType") = 0
            drType("CustomerQTY") = dr("CustomerQTY")
        Next
        dvType.RowFilter = "AreaID=0"
        For Each dr As DataRowView In dvType
            drType = dtList.Rows.Add()
            If dtCityType.Select("CityID=" & sCityID & " And BusinessTypeID=" & dr("BusinessTypeID").ToString).Length = 0 Then
                drType("Selected") = 0
            Else
                drType("Selected") = 1
            End If
            drType("Code") = dr("BusinessTypeCode").ToString
            drType("ChineseName") = dr("BusinessTypeChineseName").ToString
            drType("EnglishName") = dr("BusinessTypeEnglishName").ToString
            drType("Level") = IIf(dr("IsInnerType"), "Built-in", "National")
            drType("ID") = dr("BusinessTypeID")
            drType("IsInnerType") = dr("IsInnerType")
            drType("CustomerQTY") = dr("CustomerQTY")
        Next
        dtList.AcceptChanges()
        dtList.DefaultView.Sort = "Code"
        If dtList.Rows.Count > 0 Then
            Me.dgvList(0, 0).Selected = True
            Me.dgvList.Rows(0).Selected = True
        End If
        dvType = Nothing
    End Sub

    Private Sub dgvList_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvList.CellBeginEdit
        Me.dgvList.CurrentRow.Selected = False
    End Sub

    Private Sub dgvList_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvList.CellFormatting
        If e.ColumnIndex = 1 AndAlso Me.dgvList("IsInnerType", e.RowIndex).Value.ToString = "True" Then
            Me.dgvList.Rows(e.RowIndex).ReadOnly = True
            Me.dgvList.Rows(e.RowIndex).DefaultCellStyle.BackColor = SystemColors.Control
        End If
    End Sub

    Private Sub dgvList_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvList.CellLeave
        If Me.dgvList.CurrentCell.ReadOnly = False AndAlso editingTextBox IsNot Nothing Then
            RemoveHandler editingTextBox.KeyDown, AddressOf Code_KeyDown
        End If
    End Sub

    Private Sub dgvList_CellParsing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellParsingEventArgs) Handles dgvList.CellParsing
        Dim sValue As String = e.Value.ToString.Trim
        If Me.dgvList.CurrentCell.ColumnIndex = 1 AndAlso sValue.Length = 1 Then sValue = "0" & sValue
        If sValue <> e.Value.ToString Then e.Value = sValue : e.ParsingApplied = True
        If sValue = sOldValue Then Return
        Select Case e.ColumnIndex
            Case 1
                If sValue = "" Then
                    e.Value = sOldValue : e.ParsingApplied = True : Return
                ElseIf dtList.Select("Code='" & sValue.Replace("'", "''") & "'").Length > 0 Then
                    MessageBox.Show("该编号已经存在！该次修改无效。    ", "编号重复！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    e.Value = sOldValue : e.ParsingApplied = True : Return
                End If
            Case 2
                If sValue = "" Then
                    e.Value = sOldValue : e.ParsingApplied = True : Return
                ElseIf dtList.Select("ChineseName='" & sValue.Replace("'", "''") & "'").Length > 0 Then
                    MessageBox.Show("该名称已经存在！该次修改无效。    ", "名称重复！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    e.Value = sOldValue : e.ParsingApplied = True : Return
                End If
            Case 3
                If sValue <> "" AndAlso dtList.Select("EnglishName='" & sValue.Replace("'", "''") & "'").Length > 0 Then
                    MessageBox.Show("No effective for this modification since this name is already existing!    ", "Name Repeated!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    e.Value = sOldValue : e.ParsingApplied = True : Return
                End If
        End Select
        Me.btnSave.Enabled = True
    End Sub

    Private Sub dgvList_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvList.CellValueChanged
        If e.RowIndex = -1 OrElse Me.dgvList(e.ColumnIndex, e.RowIndex).ReadOnly Then Return
        Select Case e.ColumnIndex
            Case 0
                If Me.dgvList(e.ColumnIndex, e.RowIndex).Value Then
                    If dtCityType.Select("CityID=" & sCityID & " And BusinessTypeID=" & Me.dgvList("ID", e.RowIndex).Value.ToString).Length = 0 Then
                        dtCityType.Rows.Add(CInt(sCityID), Me.dgvList("ID", e.RowIndex).Value)
                        Me.btnSave.Enabled = True
                    End If
                Else
                    If dtCityType.Select("CityID=" & sCityID & " And BusinessTypeID=" & Me.dgvList("ID", e.RowIndex).Value.ToString).Length = 1 Then
                        dtCityType.Select("CityID=" & sCityID & " And BusinessTypeID=" & Me.dgvList("ID", e.RowIndex).Value.ToString)(0).Delete()
                        Me.btnSave.Enabled = True
                    End If
                End If
            Case 1
                If Me.dgvList(e.ColumnIndex, e.RowIndex).Value.ToString <> sOldValue Then
                    Dim sID As String = Me.dgvList("ID", Me.dgvList.CurrentRow.Index).Value.ToString, bColumnIndex As Byte = Me.dgvList.CurrentCell.ColumnIndex
                    dtType.Select("BusinessTypeID=" & sID)(0)("BusinessTypeCode") = Me.dgvList(e.ColumnIndex, e.RowIndex).Value.ToString
                    Me.dgvList.Sort(Me.dgvList.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
                    For Each dr As DataGridViewRow In Me.dgvList.Rows
                        If dr.Cells("ID").Value.ToString = sID Then
                            Me.dgvList(bColumnIndex, dr.Index).Selected = True
                            Exit For
                        End If
                    Next
                End If
            Case 2
                If Me.dgvList(e.ColumnIndex, e.RowIndex).Value.ToString <> sOldValue Then
                    dtType.Select("BusinessTypeID=" & Me.dgvList("ID", e.RowIndex).Value.ToString)(0)("BusinessTypeChineseName") = Me.dgvList(e.ColumnIndex, e.RowIndex).Value.ToString
                End If
            Case 3
                If Me.dgvList(e.ColumnIndex, e.RowIndex).Value.ToString <> sOldValue Then
                    dtType.Select("BusinessTypeID=" & Me.dgvList("ID", e.RowIndex).Value.ToString)(0)("BusinessTypeEnglishName") = Me.dgvList(e.ColumnIndex, e.RowIndex).Value.ToString
                End If
        End Select
    End Sub

    Private Sub dgvList_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvList.EditingControlShowing
        sOldValue = Me.dgvList.CurrentCell.Value.ToString
        editingTextBox = CType(Me.dgvList.EditingControl, TextBox)
        Select Case Me.dgvList.CurrentCell.ColumnIndex
            Case 1
                editingTextBox.ImeMode = Windows.Forms.ImeMode.Disable
                editingTextBox.MaxLength = 2
                AddHandler editingTextBox.KeyDown, AddressOf Code_KeyDown
            Case 2
                editingTextBox.ImeMode = Windows.Forms.ImeMode.NoControl
                editingTextBox.MaxLength = 50
            Case 3
                editingTextBox.ImeMode = Windows.Forms.ImeMode.Disable
                editingTextBox.MaxLength = 50
        End Select
    End Sub

    Private Sub Code_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        e.SuppressKeyPress = True
    End Sub

    Private Sub dgvList_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvList.Leave
        If Me.dgvList.CurrentRow IsNot Nothing Then Me.dgvList.CurrentRow.Selected = True
    End Sub

    Private Sub dgvList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvList.SelectionChanged
        If blIsReadOnly AndAlso Not Me.dgvList.Focused Then Return
        If Me.dgvList.CurrentCell IsNot Nothing AndAlso (Me.dgvList.CurrentCell.ReadOnly OrElse Me.dgvList.CurrentCell.ColumnIndex = 0) Then Me.dgvList.CurrentRow.Selected = True
        If Me.dgvList.CurrentRow IsNot Nothing AndAlso Me.dgvList("IsInnerType", Me.dgvList.CurrentRow.Index).Value.ToString = "False" AndAlso Me.dgvList.CurrentCell IsNot Nothing Then
            Me.btnDelete.Enabled = True
            frmMain.statusText.Text = "就绪。"
        Else
            Me.btnDelete.Enabled = False
            frmMain.statusText.Text = "系统内置商业类型必须被选取且不可删除或修改。"
        End If
    End Sub

    Private Sub chbShowSelected_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbShowSelected.CheckedChanged
        If Me.chbShowSelected.Checked Then
            dvList.RowFilter = "Selected=1"
        Else
            dvList.RowFilter = ""
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim newType As DataRow = dtType.Rows.Add(), newList As DataRow = dtList.Rows.Add(), iID As Int16 = dtType.Compute("Max(BusinessTypeID)", "") + 1, sCode As String = Format(CByte(dtList.Compute("Max(Code)", "IsInnerType=0")) + 1, "00"), sChineseName As String = "新商业类型", sEnglishName As String = "New Business Type", bNo As Byte = 0
        If dtList.Select("Code='" & sCode & "'").Length > 0 Then
            sCode = "00"
            Do While dtList.Select("Code='" & sCode & "'").Length > 0
                sCode = Format(CByte(sCode) + 1, "00")
            Loop
        End If
        Do While dtList.Select("ChineseName='" & sChineseName & "'").Length > 0
            bNo += 1
            sChineseName = "新商业类型 (" & bNo.ToString & ")"
        Loop
        bNo = 0
        Do While dtList.Select("EnglishName='" & sEnglishName & "'").Length > 0
            bNo += 1
            sEnglishName = "New Business Type (" & bNo.ToString & ")"
        Loop

        newType("BusinessTypeID") = iID
        newType("BusinessTypeCode") = sCode
        newType("BusinessTypeChineseName") = sChineseName
        newType("BusinessTypeEnglishName") = sEnglishName
        newType("IsInnerType") = 0
        If frmMain.sLoginAreaType = "S" Then
            newType("AreaID") = sCityID
        Else
            newType("AreaID") = frmMain.sLoginAreaID
        End If
        newType("CustomerQTY") = 0
        newType.EndEdit()

        For Each dr As DataRow In dtCity.Rows
            dtCityType.Rows.Add(dr("AreaID"), iID)
        Next

        newList("Selected") = 1
        newList("Code") = sCode
        newList("ChineseName") = sChineseName
        newList("EnglishName") = sEnglishName
        Select Case frmMain.sLoginAreaType
            Case "H"
                newList("Level") = "National"
            Case "T"
                newList("Level") = "Territory's"
            Case "R"
                newList("Level") = "Regional"
            Case Else
                newList("Level") = "City's"
        End Select
        newList("ID") = iID
        newList("IsInnerType") = 0
        newList("CustomerQTY") = 0
        Me.dgvList.Sort(Me.dgvList.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
        For Each dr As DataGridViewRow In Me.dgvList.Rows
            If dr.Cells(1).Value.ToString = sCode Then
                Me.dgvList(1, dr.Index).Selected = True
            End If
        Next
        Me.btnSave.Enabled = True
        Me.dgvList.Select()
        Me.dgvList.BeginEdit(True)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim currentType As DataRow = dtList.Select("ID=" & Me.dgvList("ID", Me.dgvList.CurrentRow.Index).Value.ToString)(0)
        If frmMain.sLoginAreaType = "T" AndAlso currentType("Level") = "National" Then
            MessageBox.Show("对不起，大区级别的""商业类型""不能删除全国级别的商业类型！    ", "不能删除商业类型！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.btnDelete.Enabled = False
        ElseIf frmMain.sLoginAreaType = "R" AndAlso (currentType("Level") = "National" OrElse currentType("Level") = "Territory's") Then
            MessageBox.Show("对不起，小区级别的""商业类型""不能删除高于小区级别的商业类型！    ", "不能删除商业类型！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.btnDelete.Enabled = False
        ElseIf (frmMain.sLoginAreaType = "C" OrElse frmMain.sLoginAreaType = "S") AndAlso currentType("Level") <> "City's" Then
            MessageBox.Show("对不起，您不能删除非城市区级别的商业类型！    ", "不能删除商业类型！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.btnDelete.Enabled = False
        ElseIf currentType("CustomerQTY") > 0 Then
            MessageBox.Show("当前商业类型已被使用，不能删除该商业类型！    " & Chr(13) & Chr(13) & "请将使用该商业类型的所有客户改成其他商业类型，然后再尝试删除该商业类型。    ", "不能删除商业类型！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.btnDelete.Enabled = False
        Else
            dtType.Select("BusinessTypeID=" & currentType("ID").ToString)(0).Delete()
            For Each dr As DataRow In dtCityType.Select("BusinessTypeID=" & currentType("ID").ToString)
                dr.Delete()
                dr.EndEdit()
            Next
            currentType.Delete()
            currentType.EndEdit()
            Me.btnSave.Enabled = (dtType.GetChanges() IsNot Nothing OrElse dtCityType.GetChanges() IsNot Nothing)
        End If
        Me.dgvList.Select()
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Me.SaveChanges()
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

        Dim sCityName As String, drType As DataRow, sTypeName As String
        For Each dr As DataRow In dtCityType.Select("", "", DataViewRowState.Deleted)
            If DB.ModifyTable("Delete From CityBusinessType Where CityID=" & dr("CityID", DataRowVersion.Original).ToString & " And BusinessTypeID=" & dr("BusinessTypeID", DataRowVersion.Original).ToString) = -1 Then
                DB.Close()
                frmMain.statusText.Text = "保存更改失败！"
                Me.Cursor = Cursors.Default
                Return False
            Else
                sCityName = dvArea.Table.Select("AreaID=" & dr("CityID", DataRowVersion.Original).ToString)(0)("AreaFullName").ToString.Substring(4).Trim
                drType = dtType.Select("BusinessTypeID=" & dr("BusinessTypeID", DataRowVersion.Original).ToString, "", DataViewRowState.OriginalRows)(0)
                sTypeName = (drType("BusinessTypeChineseName", DataRowVersion.Original).ToString & " " & drType("BusinessTypeEnglishName", DataRowVersion.Original).ToString).Trim
                DB.ModifyTable("Exec OperationLogInsert " & frmMain.sSSID & ",'Unselect Business Type: " & sTypeName.Replace("'", "''") & " From City: " & sCityName.Replace("'", "''") & "','City'," & dr("CityID", DataRowVersion.Original).ToString)
                dr.AcceptChanges()
            End If
        Next

        For Each dr As DataRow In dtType.Select("", "", DataViewRowState.Deleted)
            If DB.ModifyTable("Delete From BusinessType Where BusinessTypeID=" & dr("BusinessTypeID", DataRowVersion.Original).ToString & " And CustomerQTY=0") = -1 Then
                DB.Close()
                frmMain.statusText.Text = "保存更改失败！"
                Me.Cursor = Cursors.Default
                Return False
            Else
                DB.ModifyTable("Exec OperationLogInsert " & frmMain.sSSID & ",'Delete Business Type: " & (dr("BusinessTypeChineseName", DataRowVersion.Original).ToString & " " & dr("BusinessTypeEnglishName", DataRowVersion.Original).ToString).Trim.Replace("'", "''") & "','BusinessType'," & dr("BusinessTypeID", DataRowVersion.Original).ToString)
                dr.AcceptChanges()
            End If
        Next

        Dim sSQL As String = ""
        For Each dr As DataRow In dtType.Select("", "", DataViewRowState.ModifiedCurrent)
            sSQL = ""
            If dr("BusinessTypeCode").ToString <> dr("BusinessTypeCode", DataRowVersion.Original).ToString Then sSQL = "BusinessTypeCode='" & dr("BusinessTypeCode").ToString & "',"
            If dr("BusinessTypeChineseName").ToString <> dr("BusinessTypeChineseName", DataRowVersion.Original).ToString Then sSQL = sSQL & "BusinessTypeChineseName='" & dr("BusinessTypeChineseName").ToString.Replace("'", "''") & "',"
            If dr("BusinessTypeEnglishName").ToString <> dr("BusinessTypeEnglishName", DataRowVersion.Original).ToString Then sSQL = sSQL & "BusinessTypeEnglishName='" & dr("BusinessTypeEnglishName").ToString.Replace("'", "''") & "',"
            If sSQL <> "" Then
                sSQL = "Update BusinessType Set " & sSQL.Substring(0, sSQL.Length - 1) & " Where BusinessTypeID=" & dr("BusinessTypeID").ToString
                If DB.ModifyTable(sSQL) = -1 Then
                    DB.Close()
                    frmMain.statusText.Text = "保存更改失败！"
                    Me.Cursor = Cursors.Default
                    Return False
                Else
                    DB.ModifyTable("Exec OperationLogInsert " & frmMain.sSSID & ",'Update Business Type: " & (dr("BusinessTypeChineseName").ToString & " " & dr("BusinessTypeEnglishName").ToString).Trim.Replace("'", "''") & "','BusinessType'," & dr("BusinessTypeID").ToString)
                    dr.AcceptChanges()
                End If
            End If
        Next

        Dim dtResult As DataTable = Nothing, iID As Int16
        For Each dr As DataRow In dtType.Select("", "", DataViewRowState.Added)
            dtResult = DB.GetDataTable("Exec BusinessTypeInsertion '" & dr("BusinessTypeCode").ToString & "','" & dr("BusinessTypeChineseName").ToString.Replace("'", "''") & "','" & dr("BusinessTypeEnglishName").ToString.Replace("'", "''") & "'," & dr("AreaID").ToString)
            If dtResult.Rows(0)(0).ToString = "OK" Then
                iID = dtResult.Rows(0)(1)
                For Each drCityType As DataRow In dtCityType.Select("BusinessTypeID=" & dr("BusinessTypeID").ToString, "BusinessTypeID", DataViewRowState.Added)
                    If DB.ModifyTable("Insert Into CityBusinessType Values (" & drCityType(0).ToString & "," & iID.ToString & ")") = -1 Then
                        DB.Close()
                        frmMain.statusText.Text = "保存更改失败！"
                        Me.Cursor = Cursors.Default
                        Return False
                    Else
                        drCityType("BusinessTypeID") = iID
                        drCityType.AcceptChanges()
                    End If
                Next
                dtList.Select("ID=" & dr("BusinessTypeID").ToString)(0)("ID") = iID
                dr("BusinessTypeID") = iID
                DB.ModifyTable("Exec OperationLogInsert " & frmMain.sSSID & ",'Create Business Type: " & (dr("BusinessTypeChineseName").ToString & " " & dr("BusinessTypeEnglishName").ToString).Trim.Replace("'", "''") & "','BusinessType'," & iID.ToString)
                dr.AcceptChanges()
            Else
                MessageBox.Show("保存修改时出错，下面数据库的内部错误提示：    " & Chr(13) & Chr(13) & dtResult.Rows(0)(1).ToString & Space(4) & Chr(13) & Chr(13) & "请关闭窗口后重试，或者联系软件开发师。    ", "保存更改失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                DB.Close()
                frmMain.statusText.Text = "保存更改失败！"
                Me.Cursor = Cursors.Default
                Return False
            End If
        Next
        If dtResult IsNot Nothing Then dtResult.Dispose() : dtResult = Nothing

        For Each dr As DataRow In dtCityType.Select("", "", DataViewRowState.Added)
            If DB.ModifyTable("Insert Into CityBusinessType Values (" & dr(0).ToString & "," & dr(1).ToString & ")") = -1 Then
                DB.Close()
                frmMain.statusText.Text = "保存更改失败！"
                Me.Cursor = Cursors.Default
                Return False
            Else
                sCityName = dvArea.Table.Select("AreaID=" & dr("CityID").ToString)(0)("AreaFullName").ToString.Substring(4).Trim
                drType = dtType.Select("BusinessTypeID=" & dr("BusinessTypeID").ToString)(0)
                sTypeName = (drType("BusinessTypeChineseName").ToString & " " & drType("BusinessTypeEnglishName").ToString).Trim
                DB.ModifyTable("Exec OperationLogInsert " & frmMain.sSSID & ",'Select Business Type: " & sTypeName.Replace("'", "''") & " Into City: " & sCityName.Replace("'", "''") & "','City'," & dr("CityID").ToString)
                dr.AcceptChanges()
            End If
        Next

        DB.Close()

        dtType.AcceptChanges()
        dtCityType.AcceptChanges()
        dtList.AcceptChanges()

        Me.btnSave.Enabled = False
        Me.dgvList.Select()
        Me.dgvList(0, Me.dgvList.CurrentRow.Index).Selected = True
        Me.dgvList.CurrentRow.Selected = True
        frmMain.statusText.Text = "保存更改成功。"
        Me.Cursor = Cursors.Default
        Return True
    End Function
End Class