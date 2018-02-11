Public Class frmInvoiceItem

    'modify code 026:
    'date;2014/5/30
    'auther:Hyron bjy 
    'remark:发票品项Bug修正

    Private dtItem As DataTable, dtCity As DataTable, dvCityItem As DataView
    Private blSkipDeal As Boolean = True, blIsReadOnly As Boolean = False, sContent As String = ""

    Private Sub frmInvoiceItem_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Not ToolStripManager.VisualStylesEnabled AndAlso Me.dgvItem.Height <> 434 Then
            Me.dgvItem.Height = 434
            Me.dgvCity.Height = 434
            Me.dgvCityItem.Height = 434
        End If
    End Sub

    Private Sub frmInvoiceItem_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub frmInvoiceItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DB As New DataBase()
        DB.Open(True)
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打开""发票品项""窗口。请检查数据库连接。"
            Me.Close() : Return
        End If

        Try
            dtItem = DB.GetDataTable("Select * From InvoiceItemList Order By ItemID").DefaultView.Table
            dtItem.DefaultView.Sort = "ItemID"
            dtCity = DB.GetDataTable("Select AreaID As CityID, Convert(bit,0) As Selected,Rtrim(Ltrim(Isnull(AreaChineseName,'')+' '+Isnull(AreaEnglishName,''))) As CityName From AreaList Where AreaType = 'C' Order by AreaCode").DefaultView.Table
            dvCityItem = DB.GetDataTable("Select C.CityID,C.ItemID,I.Content From InvoiceCityItem AS C Join InvoiceItemList As I On C.ItemID=I.ItemID Order By C.CityID,C.ItemID").DefaultView
        Catch
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开""发票品项""窗口。请联系软件开发人员。"
            DB.Close() : Me.Close() : Return
        End Try
        DB.Close()

        blIsReadOnly = (frmMain.dtAllowedRight.Select("RightName='InvoiceItemMaintance'").Length = 0)

        With Me.dgvItem
            .DataSource = dtItem
            With .Columns(0)
                .Name = "ItemID"
                .HeaderText = "序号"
                .Width = 36
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
                .Name = "Content"
                .HeaderText = "发票品项"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
        End With

        With Me.dgvCity
            .DataSource = dtCity
            .Columns(0).Visible = False
            Dim checkboxColumn As New DataGridViewCheckBoxColumn
            With checkboxColumn
                .Name = "Selected"
                .DataPropertyName = "Selected"
                .HeaderText = "选择"
                .TrueValue = 1
                .Width = 60
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            .Columns.RemoveAt(1)
            .Columns.Insert(1, checkboxColumn)
            With .Columns(2)
                .Name = "CityName"
                .HeaderText = "城市名称"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
        End With

        dvCityItem.RowFilter = "1=2"
        dvCityItem.Sort = "ItemID"
        With Me.dgvCityItem
            .DataSource = dvCityItem
            .Columns(0).Visible = False
            With .Columns(1)
                .Name = "ItemID"
                .HeaderText = "序号"
                .Width = 36
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.BackColor = SystemColors.Control
                .DefaultCellStyle.ForeColor = SystemColors.ControlText
                .DefaultCellStyle.SelectionBackColor = SystemColors.Control
                .DefaultCellStyle.SelectionForeColor = SystemColors.ControlText
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(2)
                .HeaderText = "发票品项"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
        End With

        If dtItem.Rows.Count > 0 Then Me.dgvItem.Rows(0).Selected = False
        If dtCity.Rows.Count > 0 Then Me.dgvCity.Rows(0).Selected = False
        blSkipDeal = False
        If dtItem.Rows.Count > 0 Then Me.dgvItem.Rows(0).Selected = True
        If dtCity.Rows.Count > 0 Then Me.dgvCity.Rows(0).Selected = True

        Me.btnAdd.Enabled = Not blIsReadOnly
        If blIsReadOnly Then
            Me.dgvItem.ReadOnly = True
            Me.chbAll.Enabled = False
            Me.Text = Me.Text & " (只读 Readonly)"
        End If
    End Sub

    Private Sub dgvItem_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItem.CellEnter
        If Not blIsReadOnly AndAlso Me.dgvItem.Columns(e.ColumnIndex).Name = "Content" Then sContent = Me.dgvItem.CurrentCell.Value.ToString
    End Sub

    Private Sub dgvItem_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgvItem.CellValidating
        If blIsReadOnly OrElse blSkipDeal Then Return

        If Me.dgvItem.EditingControl IsNot Nothing AndAlso sContent <> Me.dgvItem.EditingControl.Text AndAlso dtItem.Select("Content='" & Me.dgvItem.EditingControl.Text.Replace("'", "''") & "'").Length > 0 Then
            MessageBox.Show("该发票品项已存在，请输入新的内容。    ", "发票品项重复！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
        End If
    End Sub

    Private Sub dgvItem_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItem.CellValueChanged
        If blSkipDeal OrElse e.RowIndex = -1 Then Return
        If Me.dgvItem.Columns(e.ColumnIndex).Name = "Content" Then
            blSkipDeal = True
            If Me.dgvItem.CurrentCell.Value.ToString = "" AndAlso sContent <> "" Then
                Me.dgvItem.CurrentCell.Value = sContent
            ElseIf Not blIsReadOnly Then
                sContent = Me.dgvItem.CurrentCell.Value.ToString
                Dim oldState As DataRowState
                For Each drItem As DataRow In dvCityItem.Table.Select("ItemID=" & Me.dgvItem("ItemID", e.RowIndex).Value.ToString)
                    oldState = drItem.RowState
                    drItem("Content") = sContent
                    If oldState = DataRowState.Unchanged Then drItem.AcceptChanges()
                Next
                Me.btnUp.Enabled = (Me.dgvItem.CurrentCell.Value.ToString <> "" AndAlso Me.dgvItem.CurrentCell.RowIndex > 0)
                Me.btnDown.Enabled = (Me.dgvItem.CurrentCell.RowIndex < Me.dgvItem.RowCount - 1 AndAlso Me.dgvItem("Content", Me.dgvItem.CurrentCell.RowIndex + 1).Value.ToString <> "")
                Me.btnSave.Enabled = True
            End If
            blSkipDeal = False
        End If
    End Sub

    Private Sub dgvItem_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvItem.SelectionChanged
        If blSkipDeal Then Return
        Me.btnDelete.Enabled = False
        Me.btnUp.Enabled = False
        Me.btnDown.Enabled = False
        If Me.dgvItem.CurrentCell Is Nothing Then Return

        blSkipDeal = True
        If dvCityItem.Table.Select("ItemID=" & Me.dgvItem("ItemID", Me.dgvItem.CurrentCell.RowIndex).Value.ToString).Length > 0 Then
            For Each drCityItem As DataGridViewRow In Me.dgvCityItem.Rows
                If drCityItem.Cells("ItemID").Value.ToString = Me.dgvItem("ItemID", Me.dgvItem.CurrentCell.RowIndex).Value.ToString Then
                    drCityItem.Cells("Content").Selected = True
                    drCityItem.Selected = True
                    Exit For
                End If
            Next
        End If

        If Me.dgvItem.CurrentCell.ColumnIndex = 0 Then
            Me.dgvItem("Content", Me.dgvItem.CurrentCell.RowIndex).Selected = True
        ElseIf Not blIsReadOnly Then
            Me.dgvItem.BeginEdit(True)
        End If

        For Each drCity As DataRow In dtCity.Rows
            drCity("Selected") = 0
        Next

        For Each drCity As DataRow In dvCityItem.Table.Select("ItemID=" & Me.dgvItem("ItemID", Me.dgvItem.CurrentCell.RowIndex).Value.ToString)
            dtCity.Select("CityID=" & drCity("CityID").ToString)(0)("Selected") = 1
        Next
        dtCity.AcceptChanges()

        Select Case dtCity.Select("Selected=1").Length
            Case 0
                Me.chbAll.CheckState = CheckState.Unchecked
            Case Me.dgvCity.RowCount
                Me.chbAll.CheckState = CheckState.Checked
            Case Else
                Me.chbAll.CheckState = CheckState.Indeterminate
        End Select

        If Not blIsReadOnly Then
            Me.btnDelete.Enabled = True
            Me.btnUp.Enabled = (Me.dgvItem.CurrentCell.Value.ToString <> "" AndAlso Me.dgvItem.CurrentCell.RowIndex > 0)
            Me.btnDown.Enabled = (Me.dgvItem.CurrentCell.RowIndex < Me.dgvItem.RowCount - 1 AndAlso Me.dgvItem("Content", Me.dgvItem.CurrentCell.RowIndex + 1).Value.ToString <> "")
        End If

        blSkipDeal = False
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Me.dgvItem.Select()
        If Me.dgvItem.RowCount = 0 OrElse Me.dgvItem("Content", Me.dgvItem.RowCount - 1).Value.ToString <> "" Then dtItem.Rows.Add(Me.dgvItem.RowCount + 1)
        blSkipDeal = True
        Me.dgvItem("Content", Me.dgvItem.RowCount - 1).Selected = True
        Me.dgvItem("Content", Me.dgvItem.RowCount - 1).Selected = False
        blSkipDeal = False
        Me.dgvItem("Content", Me.dgvItem.RowCount - 1).Selected = True
        Me.dgvItem.BeginEdit(True)
        Me.btnSave.Enabled = True
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Me.dgvItem.Select()
        Dim iCurrentRow As Int16 = Me.dgvItem.CurrentCell.RowIndex
        dtItem.Select("ItemID=" & (iCurrentRow + 1).ToString)(0).Delete()
        For Each drCityItem As DataRow In dvCityItem.Table.Select("ItemID=" & (iCurrentRow + 1).ToString)
            drCityItem.Delete()
        Next
        If iCurrentRow < Me.dgvItem.RowCount - 1 Then
            For iRow As Int16 = iCurrentRow + 1 To Me.dgvItem.RowCount - 1
                dtItem.Select("ItemID=" & (iRow + 1).ToString)(0)("ItemID") = iRow
                For Each drCityItem As DataRow In dvCityItem.Table.Select("ItemID=" & (iRow + 1).ToString)
                    drCityItem("ItemID") = iRow
                Next
            Next
            Me.dgvItem("ItemID", iCurrentRow).Selected = True
        ElseIf Me.dgvItem.RowCount = 0 Then
            For Each drCity As DataRow In dtCity.Rows
                drCity("Selected") = 0
            Next
            dtCity.AcceptChanges()
            Me.chbAll.CheckState = CheckState.Unchecked
            Me.btnDelete.Enabled = False
        Else
            blSkipDeal = True
            Me.dgvItem("ItemID", Me.dgvItem.RowCount - 1).Selected = True
            Me.dgvItem("ItemID", Me.dgvItem.RowCount - 1).Selected = False
            blSkipDeal = False
            Me.dgvItem("ItemID", Me.dgvItem.RowCount - 1).Selected = True
        End If
        Me.btnSave.Enabled = True
    End Sub

    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
        Me.dgvItem.Select()
        Dim iCurrentRow As Int16 = Me.dgvItem.CurrentCell.RowIndex
        For Each drCityItem As DataRow In dvCityItem.Table.Select("ItemID=" & iCurrentRow.ToString)
            drCityItem("ItemID") = -1
        Next
        For Each drCityItem As DataRow In dvCityItem.Table.Select("ItemID=" & (iCurrentRow + 1).ToString)
            drCityItem("ItemID") = iCurrentRow
        Next
        For Each drCityItem As DataRow In dvCityItem.Table.Select("ItemID=-1")
            drCityItem("ItemID") = iCurrentRow + 1
        Next
        dtItem.Select("ItemID=" & iCurrentRow.ToString)(0)("ItemID") = -1
        dtItem.Select("ItemID=" & (iCurrentRow + 1).ToString)(0)("ItemID") = iCurrentRow
        dtItem.Select("ItemID=-1")(0)("ItemID") = iCurrentRow + 1
        blSkipDeal = True
        Me.dgvItem("ItemID", iCurrentRow - 1).Selected = True
        Me.dgvItem("ItemID", iCurrentRow - 1).Selected = False
        blSkipDeal = False
        Me.dgvItem("ItemID", iCurrentRow - 1).Selected = True
        Me.btnSave.Enabled = True
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        Me.dgvItem.Select()
        Dim iCurrentRow As Int16 = Me.dgvItem.CurrentCell.RowIndex
        For Each drCityItem As DataRow In dvCityItem.Table.Select("ItemID=" & (iCurrentRow + 1).ToString)
            drCityItem("ItemID") = -1
        Next
        For Each drCityItem As DataRow In dvCityItem.Table.Select("ItemID=" & (iCurrentRow + 2).ToString)
            drCityItem("ItemID") = iCurrentRow + 1
        Next
        For Each drCityItem As DataRow In dvCityItem.Table.Select("ItemID=-1")
            drCityItem("ItemID") = iCurrentRow + 2
        Next
        dtItem.Select("ItemID=" & (iCurrentRow + 1).ToString)(0)("ItemID") = -1
        dtItem.Select("ItemID=" & (iCurrentRow + 2).ToString)(0)("ItemID") = iCurrentRow + 1
        dtItem.Select("ItemID=-1")(0)("ItemID") = iCurrentRow + 2
        blSkipDeal = True
        Me.dgvItem("ItemID", iCurrentRow + 1).Selected = True
        Me.dgvItem("ItemID", iCurrentRow + 1).Selected = False
        blSkipDeal = False
        Me.dgvItem("ItemID", iCurrentRow + 1).Selected = True
        Me.btnSave.Enabled = True
    End Sub

    Private Sub dgvCity_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCity.CellContentClick
        If Me.dgvCity.Columns(e.ColumnIndex).Name <> "Selected" Then Return

        If blIsReadOnly Then
            frmMain.statusText.Text = "您无权限分配发票品项给各城市。"
            Return
        End If

        If dtItem.Rows.Count = 0 Then
            Me.dgvItem.Select()
            frmMain.statusText.Text = "未发现任何发票品项！请先增加发票品项，再分配给各城市。"
            Return
        End If

        If Me.dgvItem("Content", Me.dgvItem.CurrentCell.RowIndex).Value.ToString = "" Then
            Me.dgvItem.Select()
            blSkipDeal = True
            Me.dgvItem("Content", Me.dgvItem.RowCount - 1).Selected = True
            Me.dgvItem("Content", Me.dgvItem.RowCount - 1).Selected = False
            blSkipDeal = False
            Me.dgvItem("Content", Me.dgvItem.RowCount - 1).Selected = True
            frmMain.statusText.Text = "发票品项内容为空！请先输入发票品项内容，再分配给各城市。"
            Return
        End If

        Dim drCity As DataRow = dtCity.Select("CityID=" & Me.dgvCity("CityID", Me.dgvCity.CurrentCell.RowIndex).Value.ToString)(0)
        If drCity("Selected") Then
            drCity("Selected") = 0
            blSkipDeal = True
            dvCityItem.Table.Select("CityID=" & drCity("CityID").ToString & " And ItemID=" & Me.dgvItem("ItemID", Me.dgvItem.CurrentCell.RowIndex).Value.ToString)(0).Delete()
            If Me.dgvCityItem.RowCount > 0 Then
                If Me.dgvCityItem.CurrentRow Is Nothing Then
                    Me.dgvCityItem("Content", Me.dgvCityItem.RowCount - 1).Selected = True
                    blSkipDeal = False
                    Me.dgvCityItem.Rows(Me.dgvCityItem.RowCount - 1).Selected = True
                Else
                    Me.dgvCityItem("Content", Me.dgvCityItem.CurrentRow.Index).Selected = True
                    Me.dgvCityItem.CurrentRow.Selected = False
                    Me.dgvItem.CurrentRow.Selected = False
                    blSkipDeal = False
                    Me.dgvCityItem.CurrentRow.Selected = True
                    blSkipDeal = True
                    Me.dgvItem.CurrentRow.Selected = False
                    blSkipDeal = False
                    Me.dgvItem.CurrentRow.Selected = True
                End If
            End If
            blSkipDeal = False
        Else
            drCity("Selected") = 1
            blSkipDeal = True
            dvCityItem.Table.Rows.Add(drCity("CityID"), Me.dgvItem("ItemID", Me.dgvItem.CurrentCell.RowIndex).Value, Me.dgvItem("Content", Me.dgvItem.CurrentCell.RowIndex).Value)
            For Each drCityItem As DataGridViewRow In Me.dgvCityItem.Rows
                If drCityItem.Cells("ItemID").Value.ToString = Me.dgvItem("ItemID", Me.dgvItem.CurrentCell.RowIndex).Value.ToString Then
                    blSkipDeal = True
                    drCityItem.Cells("Content").Selected = True
                    drCityItem.Selected = True
                    blSkipDeal = False
                    Exit For
                End If
            Next
            blSkipDeal = False
        End If

        Select Case dtCity.Select("Selected=1").Length
            Case 0
                Me.chbAll.CheckState = CheckState.Unchecked
            Case Me.dgvCity.RowCount
                Me.chbAll.CheckState = CheckState.Checked
            Case Else
                Me.chbAll.CheckState = CheckState.Indeterminate
        End Select
        dtCity.AcceptChanges()
        Me.btnSave.Enabled = True
    End Sub

    Private Sub dgvCity_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCity.Leave
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub dgvCity_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCity.SelectionChanged
        If blSkipDeal OrElse Me.dgvCity.CurrentCell Is Nothing Then Return
        dvCityItem.RowFilter = "CityID=" & Me.dgvCity("CityID", Me.dgvCity.CurrentCell.RowIndex).Value.ToString
    End Sub

    Private Sub dgvCityItem_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCityItem.SelectionChanged
        'modify code 026:start-------------------------------------------------------------------------
        'If blSkipDeal OrElse Me.dgvCityItem.CurrentCell Is Nothing Then Return
        'For Each drItem As DataGridViewRow In Me.dgvItem.Rows
        '    If drItem.Cells("ItemID").Value.ToString = Me.dgvCityItem("ItemID", Me.dgvCityItem.CurrentCell.RowIndex).Value.ToString Then
        '        blSkipDeal = True
        '        drItem.Cells("Content").Selected = True
        '        drItem.Selected = True
        '        blSkipDeal = False
        '        Exit For
        '    End If
        'Next
        'modify code 026:end-------------------------------------------------------------------------
    End Sub

    Private Sub chbAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbAll.Click
        If dtItem.Rows.Count = 0 Then
            Me.dgvItem.Select()
            frmMain.statusText.Text = "未发现任何发票品项！请先增加发票品项，再分配给各城市。"
            Return
        End If

        If Me.dgvItem("Content", Me.dgvItem.CurrentCell.RowIndex).Value.ToString = "" Then
            Me.dgvItem.Select()
            blSkipDeal = True
            Me.dgvItem("Content", Me.dgvItem.RowCount - 1).Selected = True
            Me.dgvItem("Content", Me.dgvItem.RowCount - 1).Selected = False
            blSkipDeal = False
            Me.dgvItem("Content", Me.dgvItem.RowCount - 1).Selected = True
            frmMain.statusText.Text = "发票品项内容为空！请先输入发票品项内容，再分配给各城市。"
            Return
        End If

        If Me.chbAll.CheckState = CheckState.Checked Then
            For Each drCity As DataRow In dtCity.Rows
                drCity("Selected") = 0
            Next
            For Each drCityItem As DataRow In dvCityItem.Table.Select("ItemID=" & Me.dgvItem("ItemID", Me.dgvItem.CurrentCell.RowIndex).Value.ToString)
                drCityItem.Delete()
            Next
            Me.chbAll.CheckState = CheckState.Unchecked
        Else
            For Each drCity As DataRow In dtCity.Select("Selected=0")
                drCity("Selected") = 1
                dvCityItem.Table.Rows.Add(drCity("CityID"), Me.dgvItem("ItemID", Me.dgvItem.CurrentCell.RowIndex).Value, Me.dgvItem("Content", Me.dgvItem.CurrentCell.RowIndex).Value)
            Next
            Me.chbAll.CheckState = CheckState.Checked
        End If
        dtCity.AcceptChanges()
        Me.btnSave.Enabled = True
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Me.SaveChanges()
    End Sub

    Private Function SaveChanges() As Boolean
        Me.btnSave.Select()
        If Me.dgvItem.RowCount > 0 AndAlso Me.dgvItem("Content", Me.dgvItem.RowCount - 1).Value.ToString = "" Then
            Me.dgvItem.Select()
            blSkipDeal = True
            Me.dgvItem("Content", Me.dgvItem.RowCount - 1).Selected = True
            Me.dgvItem("Content", Me.dgvItem.RowCount - 1).Selected = False
            blSkipDeal = False
            Me.dgvItem("Content", Me.dgvItem.RowCount - 1).Selected = True
            frmMain.statusText.Text = "发票品项内容为空！请先输入发票品项内容，或者删除该品项。"
            Return False
        End If

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

        For Each drItem As DataRow In dtItem.Select("", "ItemID", DataViewRowState.Deleted Or DataViewRowState.ModifiedOriginal)
            If DB.ModifyTable("Delete From InvoiceItemList Where ItemID=" & drItem("ItemID", DataRowVersion.Original).ToString) = -1 Then
                DB.Close()
                frmMain.statusText.Text = "保存更改失败！"
                Me.Cursor = Cursors.Default
                Return False
            ElseIf drItem.RowState = DataRowState.Deleted Then
                drItem.AcceptChanges()
            End If
        Next

        For Each drItem As DataRow In dtItem.Select("", "ItemID", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent)
            If DB.ModifyTable("Insert Into InvoiceItemList Values (" & drItem("ItemID").ToString & ",'" & drItem("Content").ToString.Replace("'", "''") & "')") = -1 Then
                DB.Close()
                frmMain.statusText.Text = "保存更改失败！"
                Me.Cursor = Cursors.Default
                Return False
            Else
                drItem.AcceptChanges()
            End If
        Next

        For Each drItem As DataRow In dvCityItem.Table.Select("", "ItemID", DataViewRowState.Deleted Or DataViewRowState.ModifiedOriginal)
            If DB.ModifyTable("Delete From InvoiceCityItem Where CityID=" & drItem("CityID", DataRowVersion.Original).ToString & " And ItemID=" & drItem("ItemID", DataRowVersion.Original).ToString) = -1 Then
                DB.Close()
                frmMain.statusText.Text = "保存更改失败！"
                Me.Cursor = Cursors.Default
                Return False
            ElseIf drItem.RowState = DataRowState.Deleted Then
                drItem.AcceptChanges()
            End If
        Next

        For Each drItem As DataRow In dvCityItem.Table.Select("", "ItemID", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent)
            If DB.ModifyTable("Insert Into InvoiceCityItem Values (" & drItem("CityID").ToString & "," & drItem("ItemID").ToString & ")") = -1 Then
                DB.Close()
                frmMain.statusText.Text = "保存更改失败！"
                Me.Cursor = Cursors.Default
                Return False
            Else
                drItem.AcceptChanges()
            End If
        Next

        dtItem.AcceptChanges()
        dvCityItem.Table.AcceptChanges()

        DB.ModifyTable("Exec OperationLogInsert " & frmMain.sSSID & ",'Maintain Invoice Item','InvoiceItem',NULL")
        DB.Close()

        If Me.dgvItem.CurrentCell IsNot Nothing Then
            blSkipDeal = True
            Me.dgvItem("ItemID", Me.dgvItem.CurrentCell.RowIndex).Selected = True
            Me.dgvItem("ItemID", Me.dgvItem.CurrentCell.RowIndex).Selected = False
            blSkipDeal = False
            Me.dgvItem("ItemID", Me.dgvItem.CurrentCell.RowIndex).Selected = True
        End If
        Me.btnSave.Enabled = False
        frmMain.statusText.Text = "保存更改成功。"
        Me.Cursor = Cursors.Default
        Return True
    End Function
End Class