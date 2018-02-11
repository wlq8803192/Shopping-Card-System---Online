Public Class frmPredefineFaceValue

    Private blSkipDeal As Boolean = True, sTimerType As String = "BrushingCard", bMouseClicks As Byte = 0, blBrushingEnd As Boolean = True, iPreviousErrorRowID As Int16 = -1, sErrorInfo As String, errorCell As DataGridViewCell, editingCardNo As TextBox, editingCardQTY As TextBox, editingFaceValue As TextBox
    Private sCULCardBin As String = "", dmMinFaceValue As Decimal = 0, dmMaxFaceValue As Decimal = 0

    Private Sub frmPredefineFaceValue_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If errorCell IsNot Nothing Then Return
        Me.dgvCard.Select()
        Me.btnClose.Select()
        Me.dgvCard.Select()
        Me.dgvCard.Rows(Me.dgvCard.RowCount - 1).Selected = True
        Me.dgvCard.Rows(Me.dgvCard.RowCount - 1).Selected = False
        blSkipDeal = False
        Me.dgvCard(1, Me.dgvCard.RowCount - 1).Selected = True
        Me.dgvCard.BeginEdit(True)
    End Sub

    Private Sub frmPredefineFaceValue_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.btnSave.Enabled Then
            Me.btnSave.Select()
            Dim bAnswer As Windows.Forms.DialogResult = MessageBox.Show("当前窗口内容已更改，但未保存。    " & Chr(13) & Chr(13) & "是否在关闭窗口前保存这些更改？    " & Chr(13) & Chr(13) & "   是    -   保存更改并退出" & Chr(13) & "   否    -   放弃更改并退出" & Chr(13) & "  取消   -   取消关闭", "请确认保存更改：", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

            If bAnswer = Windows.Forms.DialogResult.Yes Then
                Me.btnSave.PerformClick()
                e.Cancel = Me.btnSave.Enabled
            ElseIf bAnswer = Windows.Forms.DialogResult.Cancel Then
                e.Cancel = True
            Else
                errorCell = Nothing
                frmMain.dvCardFaceValue.Table.RejectChanges()
                frmMain.statusText.Text = "就绪。"
            End If
        Else
            errorCell = Nothing
            frmMain.dvCardFaceValue.Table.RejectChanges()
            frmMain.statusText.Text = "就绪。"
        End If
    End Sub

    Private Sub frmPredefineFaceValue_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打开预定义卡面值窗口。请检查数据库连接。"
            Me.Cursor = Cursors.Default : Return
        End If

        Try
            Dim drCityParameter As DataRow = DB.GetDataTable("Select * From CityCardParameter Where CityID=" & frmMain.dtLoginStructure.Select("AreaID=" & frmMain.sLoginAreaID)(0)("ParentAreaID").ToString).Rows(0)
            dmMinFaceValue = CDec(drCityParameter("MinFaceValue")) : dmMaxFaceValue = CDec(drCityParameter("MaxFaceValue"))
            sCULCardBin = DB.GetDataTable("Select CULCardBin From AreaList Where AreaID=" & frmMain.sLoginAreaID).Rows(0)(0).ToString
        Catch
            dmMinFaceValue = 1 : dmMaxFaceValue = 1000
        End Try
        DB.Close()

        If frmMain.dvCardFaceValue Is Nothing Then
            Dim dtCardFaceValue As New DataTable
            With dtCardFaceValue.Columns
                .Add("RowID", System.Type.GetType("System.Int16"))
                .Add("StartCardNo", System.Type.GetType("System.String"))
                .Add("EndCardNo", System.Type.GetType("System.String"))
                .Add("CardQTY", System.Type.GetType("System.Int32"))
                .Add("FaceValue", System.Type.GetType("System.Decimal"))
            End With
            frmMain.dvCardFaceValue = New DataView(dtCardFaceValue.Copy)
            dtCardFaceValue.Dispose() : dtCardFaceValue = Nothing

            If IO.File.Exists(Application.StartupPath & "\PredefineCardFaceValue\PredefineCardFaceValue.dat") Then
                Dim myReader As FileIO.TextFieldParser = Nothing, currentRow As String(), newCardRow As DataRowView = Nothing
                Try
                    myReader = New FileIO.TextFieldParser(Application.StartupPath & "\PredefineCardFaceValue\PredefineCardFaceValue.dat")
                    myReader.TextFieldType = FileIO.FieldType.Delimited
                    myReader.Delimiters = New String() {vbTab}
                    While Not myReader.EndOfData
                        Try
                            currentRow = myReader.ReadFields()
                            newCardRow = frmMain.dvCardFaceValue.AddNew
                            If currentRow.Length = 5 AndAlso currentRow(1).ToString <> "" Then
                                For bColumn As Byte = 0 To 4
                                    newCardRow(bColumn) = currentRow(bColumn)
                                Next
                            End If
                            newCardRow.EndEdit()
                        Catch
                            newCardRow.Row.RejectChanges()
                        End Try
                    End While
                Finally
                    If myReader IsNot Nothing Then
                        myReader.Close()
                        myReader.Dispose()
                        myReader = Nothing
                    End If
                End Try
            End If
            frmMain.dvCardFaceValue.Table.Rows.Add(frmMain.dvCardFaceValue.Count + 1)
            frmMain.dvCardFaceValue.Table.AcceptChanges()
        End If

        frmMain.dvCardFaceValue.RowFilter = ""
        frmMain.dvCardFaceValue.Sort = "RowID"
        With Me.dgvCard
            .DataSource = frmMain.dvCardFaceValue
            With .Columns(0)
                .HeaderText = "行号"
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
                .HeaderText = "开始卡号"
                .Width = 125
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(2)
                .HeaderText = "结束卡号"
                .Width = 125
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(3)
                .HeaderText = "数量"
                .MinimumWidth = 50
                .FillWeight = 80
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,0"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(4)
                .HeaderText = "面值"
                .MinimumWidth = 50
                .FillWeight = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,0.00"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
        End With

        Me.btnClearAll.Enabled = (Me.dgvCard.RowCount > 1)
    End Sub

    Private Sub dgvCard_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvCard.CellFormatting
        If errorCell IsNot Nothing AndAlso e.ColumnIndex = errorCell.ColumnIndex AndAlso e.RowIndex = errorCell.RowIndex Then
            e.CellStyle.ForeColor = Color.Red : e.CellStyle.SelectionForeColor = Color.Red
        End If
    End Sub

    Private Sub dgvCard_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCard.CellLeave
        Select Case e.ColumnIndex
            Case 1, 2
                If editingCardNo IsNot Nothing Then
                    RemoveHandler editingCardNo.KeyDown, AddressOf CardNo_KeyDown
                    RemoveHandler editingCardNo.TextChanged, AddressOf editingTextBox_TextChanged
                    editingCardNo = Nothing
                End If
            Case 3
                If editingCardQTY IsNot Nothing Then
                    If editingCardQTY.Text <> "" Then editingCardQTY.Text = Format(CDec(editingCardQTY.Text), "#,0")
                    RemoveHandler editingCardQTY.KeyDown, AddressOf CardQTY_KeyDown
                    RemoveHandler editingCardQTY.TextChanged, AddressOf editingTextBox_TextChanged
                    editingCardQTY = Nothing
                End If
            Case Else
                If editingFaceValue IsNot Nothing Then
                    If editingFaceValue.Text <> "" Then editingFaceValue.Text = Format(CDec(editingFaceValue.Text), "#,0.00")
                    RemoveHandler editingFaceValue.KeyDown, AddressOf FaceValue_KeyDown
                    RemoveHandler editingFaceValue.TextChanged, AddressOf editingTextBox_TextChanged
                    editingFaceValue = Nothing
                End If
        End Select
    End Sub

    Private Sub dgvCard_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvCard.CellMouseUp
        If e.Button = Windows.Forms.MouseButtons.Right AndAlso e.ColumnIndex = 0 Then
            blSkipDeal = True
            Me.dgvCard.EditMode = DataGridViewEditMode.EditProgrammatically
            Me.dgvCard("FaceValue", e.RowIndex).Selected = True
            Me.dgvCard.CurrentRow.Selected = True
            blSkipDeal = False
            Me.cmenuDeleteCardRow.Show(Control.MousePosition)
        End If
    End Sub

    Private Sub dgvCard_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCard.CellValueChanged
        If blSkipDeal Then Return
        blSkipDeal = True
        Dim sValue As String = ""
        If Me.dgvCard(e.ColumnIndex, e.RowIndex).Value IsNot Nothing Then sValue = Me.dgvCard(e.ColumnIndex, e.RowIndex).Value.ToString

        sErrorInfo = "" : errorCell = Nothing
        Select Case Me.dgvCard.Columns(e.ColumnIndex).Name
            Case "StartCardNo"
                If sValue = "" OrElse Not IsNumeric(sValue) Then
                    If Me.dgvCard("EndCardNo", e.RowIndex).Value.ToString <> "" Then
                        Me.dgvCard("StartCardNo", e.RowIndex).Value = Me.dgvCard("EndCardNo", e.RowIndex).Value
                    Else
                        Me.dgvCard("StartCardNo", e.RowIndex).Value = ""
                        blSkipDeal = False : Return
                    End If
                ElseIf sValue.Length < 19 Then
                    sErrorInfo = "卡号位数不足 19 位"
                ElseIf sValue <> ShoppingCardNo.GetFullCardNo(sValue.Substring(0, 18)) Then
                    sErrorInfo = "卡号校验码错误"
                ElseIf sCULCardBin <> "" AndAlso sCULCardBin.IndexOf(sValue.Substring(4, 5)) = -1 Then
                    sErrorInfo = "银商卡Bin码不符"
                ElseIf Me.dgvCard("EndCardNo", e.RowIndex).Value.ToString <> "" AndAlso Math.Abs(CLng(Me.dgvCard("EndCardNo", e.RowIndex).Value.ToString.Substring(0, 18)) - CLng(sValue.Substring(0, 18))) + 1 > 10000 Then
                    sErrorInfo = "卡号超出许可范围，单行卡数请限制在 10,000 张以内"
                End If

                If sErrorInfo = "" Then
                    Me.dgvCard.EndEdit()
                    Dim blGotoEndCardColumn As Boolean = False
                    If Me.dgvCard("EndCardNo", e.RowIndex).Value.ToString = "" Then
                        Me.dgvCard("EndCardNo", e.RowIndex).Value = sValue
                        Me.dgvCard.EndEdit()
                        blGotoEndCardColumn = True
                    End If
                    If Me.dgvCard("FaceValue", e.RowIndex).Value.ToString = "" AndAlso frmMain.dvCardFaceValue.Table.Select("'" & sValue & "'>=StartCardNo And '" & sValue & "'<=EndCardNo").Length > 0 Then
                        Try
                            Dim drOld As DataRow = frmMain.dvCardFaceValue.Table.Select("'" & sValue & "'>=StartCardNo And '" & sValue & "'<=EndCardNo")(0)
                            Me.dgvCard("FaceValue", e.RowIndex).Value = drOld("FaceValue")
                        Catch
                        End Try
                    End If
                    Me.ConfigCardRow()
                    If blGotoEndCardColumn Then Me.dgvCard("EndCardNo", Me.dgvCard.CurrentCell.RowIndex).Selected = True
                Else
                    errorCell = Me.dgvCard("StartCardNo", e.RowIndex)
                    If sErrorInfo = "银商卡Bin码不符" Then
                        MessageBox.Show("卡号错误：银商卡Bin码不符！    " & Chr(13) & Chr(13) & "银商Bin卡码即卡的第二段号码（第 5 至 9 位）。    " & Chr(13) & Chr(13) & "系统设置的该店的卡银商Bin码是： " & sCULCardBin & Space(4) & Chr(13) & "您刚才输入购物卡的银商Bin码是： " & sValue.Substring(4, 5) & Space(4) & Chr(13) & Chr(13) & "请重新输入卡号。    ", "开始卡号输入错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf sErrorInfo.IndexOf("卡号超出许可范围") > -1 Then
                        MessageBox.Show(sErrorInfo & "！    " & Chr(13) & Chr(13) & "请重新输入卡号。    ", "开始卡号输入错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        MessageBox.Show("卡号错误： " & sErrorInfo & "！    " & Chr(13) & Chr(13) & "请重新输入卡号。    ", "开始卡号输入错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                    frmMain.statusText.Text = "开始卡号错误（" & sErrorInfo & "）！请重新输入开始卡号。"

                    Me.dgvCard("EndCardNo", e.RowIndex).Selected = True : errorCell.Selected = True
                End If
            Case "EndCardNo"
                If sValue = "" OrElse Not IsNumeric(sValue) Then
                    If Me.dgvCard("StartCardNo", e.RowIndex).Value.ToString <> "" Then
                        Me.dgvCard("EndCardNo", e.RowIndex).Value = Me.dgvCard("StartCardNo", e.RowIndex).Value
                    Else
                        Me.dgvCard("EndCardNo", e.RowIndex).Value = ""
                        blSkipDeal = False : Return
                    End If
                ElseIf sValue.Length < 19 Then
                    sErrorInfo = "卡号位数不足 19 位"
                ElseIf sValue <> ShoppingCardNo.GetFullCardNo(sValue.Substring(0, 18)) Then
                    sErrorInfo = "卡号校验码错误"
                ElseIf sCULCardBin <> "" AndAlso sCULCardBin.IndexOf(sValue.Substring(4, 5)) = -1 Then
                    sErrorInfo = "银商卡Bin码不符"
                ElseIf Math.Abs(CLng(sValue.Substring(0, 18)) - CLng(Me.dgvCard("StartCardNo", e.RowIndex).Value.ToString.Substring(0, 18))) + 1 > 10000 Then
                    sErrorInfo = "卡号超出许可范围，单行卡数请限制在 10,000 张以内"
                End If

                If sErrorInfo = "" Then
                    Me.ConfigCardRow()
                Else
                    errorCell = Me.dgvCard("EndCardNo", e.RowIndex)
                    If sErrorInfo = "银商卡Bin码不符" Then
                        MessageBox.Show("卡号错误：银商卡Bin码不符！    " & Chr(13) & Chr(13) & "银商卡Bin码即卡的第二段号码（第 5 至 9 位）。    " & Chr(13) & Chr(13) & "系统设置的该店的卡银商Bin码是： " & sCULCardBin & Space(4) & Chr(13) & "您刚才输入购物卡的银商Bin码是： " & sValue.Substring(4, 5) & Space(4) & Chr(13) & Chr(13) & "请重新输入卡号。    ", "结束卡号输入错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf sErrorInfo.IndexOf("卡号超出许可范围") > -1 Then
                        MessageBox.Show(sErrorInfo & "！    " & Chr(13) & Chr(13) & "请重新输入卡号。    ", "结束卡号输入错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        MessageBox.Show("卡号错误： " & sErrorInfo & "！    " & Chr(13) & Chr(13) & "请重新输入卡号。    ", "结束卡号输入错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                    frmMain.statusText.Text = "结束卡号错误（" & sErrorInfo & "）！请重新输入结束卡号。"
                    Me.dgvCard("StartCardNo", e.RowIndex).Selected = True : errorCell.Selected = True
                End If
            Case "CardQTY"
                If sValue = "" OrElse Not IsNumeric(sValue) Then
                    Me.dgvCard("CardQTY", e.RowIndex).Value = CLng(Me.dgvCard("EndCardNo", e.RowIndex).Value.ToString.Substring(0, 18)) - CLng(Me.dgvCard("StartCardNo", e.RowIndex).Value.ToString.Substring(0, 18)) + 1
                ElseIf CInt(sValue) < 2 Then
                    blSkipDeal = False
                    Me.dgvCard("EndCardNo", e.RowIndex).Value = Me.dgvCard("StartCardNo", e.RowIndex).Value
                    Me.dgvCard("CardQTY", e.RowIndex).Value = 1
                ElseIf CInt(sValue) < 10001 Then
                    blSkipDeal = False
                    Me.dgvCard("EndCardNo", e.RowIndex).Value = ShoppingCardNo.GetFullCardNo((CLng(Me.dgvCard("StartCardNo", e.RowIndex).Value.ToString.Substring(0, 18)) + CLng(sValue) - 1).ToString)
                Else
                    sErrorInfo = "数量超出许可范围！单行卡数请限制在 10,000 张以内。"
                    errorCell = Me.dgvCard("CardQTY", e.RowIndex)
                    MessageBox.Show(sErrorInfo & Space(4) & Chr(13) & Chr(13) & "请重新设置数量。    ", "同一行的购物卡数量不可超过 10,000 张！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    frmMain.statusText.Text = sErrorInfo & "请重新设置数量。"
                    Me.dgvCard("EndCardNo", e.RowIndex).Selected = True : errorCell.Selected = True
                End If
            Case "FaceValue"
                If sValue = "" OrElse Not IsNumeric(sValue) OrElse CDec(sValue) = 0 Then
                    If sValue <> "" AndAlso Not IsNumeric(sValue) Then Me.dgvCard("FaceValue", e.RowIndex).Value = "" : sValue = ""
                    sErrorInfo = IIf(sValue = "", "卡片面值不能为空", "卡片面值不能为零")
                    errorCell = Me.dgvCard("FaceValue", e.RowIndex)
                    frmMain.statusText.Text = sErrorInfo & "！请重新设置卡片面值。"
                    Me.dgvCard("EndCardNo", e.RowIndex).Selected = True : errorCell.Selected = True
                ElseIf CDec(sValue) < dmMinFaceValue OrElse CDec(sValue) > dmMaxFaceValue Then '检查面值限制
                    sErrorInfo = "卡片预设面值应该介于 " & Format(dmMinFaceValue, "#,0.00").Replace(".00", "") & " 元 与 " & Format(dmMaxFaceValue, "#,0.00").Replace(".00", "") & " 元之间"
                    errorCell = Me.dgvCard("FaceValue", e.RowIndex)
                    MessageBox.Show(sErrorInfo & "！    " & Chr(13) & Chr(13) & "请重新设置卡片面值。    ", "卡片预设面值超出许可范围！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    frmMain.statusText.Text = "卡片预设面值超出许可范围（" & sErrorInfo & "）！请重新设置卡片面值。"
                    Me.dgvCard("EndCardNo", e.RowIndex).Selected = True : errorCell.Selected = True
                End If
        End Select
        blSkipDeal = False
        Me.btnClearAll.Enabled = (Me.dgvCard.RowCount > 1)
    End Sub

    Private Sub dgvCard_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvCard.DataError
        e.Cancel = False
    End Sub

    Private Sub dgvCard_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvCard.EditingControlShowing
        Select Case Me.dgvCard.CurrentCell.ColumnIndex
            Case 1, 2
                editingCardNo = CType(e.Control, TextBox)
                editingCardNo.ImeMode = Windows.Forms.ImeMode.Disable
                editingCardNo.MaxLength = 19
                RemoveHandler editingCardNo.KeyDown, AddressOf CardQTY_KeyDown
                RemoveHandler editingCardNo.KeyDown, AddressOf FaceValue_KeyDown
                AddHandler editingCardNo.KeyDown, AddressOf CardNo_KeyDown
                AddHandler editingCardNo.TextChanged, AddressOf editingTextBox_TextChanged
            Case 3
                editingCardQTY = CType(e.Control, TextBox)
                editingCardQTY.ImeMode = Windows.Forms.ImeMode.Disable
                editingCardQTY.MaxLength = 5
                editingCardQTY.Text = editingCardQTY.Text.Replace(",", "")
                RemoveHandler editingCardQTY.KeyDown, AddressOf CardNo_KeyDown
                RemoveHandler editingCardQTY.KeyDown, AddressOf FaceValue_KeyDown
                AddHandler editingCardQTY.KeyDown, AddressOf CardQTY_KeyDown
                AddHandler editingCardQTY.TextChanged, AddressOf editingTextBox_TextChanged
            Case Else
                editingFaceValue = CType(e.Control, TextBox)
                editingFaceValue.ImeMode = Windows.Forms.ImeMode.Disable
                editingFaceValue.MaxLength = 10
                editingFaceValue.Text = editingFaceValue.Text.Replace(",", "")
                RemoveHandler editingFaceValue.KeyDown, AddressOf CardNo_KeyDown
                RemoveHandler editingFaceValue.KeyDown, AddressOf CardQTY_KeyDown
                AddHandler editingFaceValue.KeyDown, AddressOf FaceValue_KeyDown
                AddHandler editingFaceValue.TextChanged, AddressOf editingTextBox_TextChanged
        End Select
    End Sub

    Private Sub dgvCard_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCard.KeyDown
        If e.KeyCode = Keys.Delete AndAlso Me.dgvCard.ReadOnly = False AndAlso Me.dgvCard.CurrentRow.Selected = True Then Me.menuDeleteCardRow.PerformClick() : e.SuppressKeyPress = True
    End Sub

    Private Sub dgvCard_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCard.Leave
        frmMain.statusText.Text = "就绪。"
        blSkipDeal = True
        If Me.dgvCard.CurrentCell IsNot Nothing Then Me.dgvCard.CurrentCell.Selected = False
        If Me.dgvCard.CurrentRow IsNot Nothing Then Me.dgvCard.CurrentRow.Selected = False
        blSkipDeal = False
    End Sub

    Private Sub dgvCard_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCard.SelectionChanged
        If blSkipDeal OrElse Me.dgvCard.CurrentCell Is Nothing Then Return
        blSkipDeal = True
        frmMain.statusText.Text = "就绪。"
        If Me.dgvCard.CurrentCell.ColumnIndex = 0 Then
            Me.dgvCard.EditMode = DataGridViewEditMode.EditProgrammatically
            Me.dgvCard("FaceValue", Me.dgvCard.CurrentRow.Index).Selected = True
            Me.dgvCard.CurrentRow.Selected = True
        Else
            Me.dgvCard.EditMode = DataGridViewEditMode.EditOnEnter
            If errorCell Is Nothing AndAlso iPreviousErrorRowID <> -1 Then Me.CheckErrorCell()

            If errorCell IsNot Nothing Then
                If errorCell.RowIndex = Me.dgvCard.CurrentRow.Index Then
                    iPreviousErrorRowID = errorCell.RowIndex
                Else
                    errorCell.Selected = True
                    Select Case errorCell.ColumnIndex
                        Case 1
                            frmMain.statusText.Text = "开始卡号错误（" & sErrorInfo & "）！请重新输入开始卡号。"
                        Case 2
                            frmMain.statusText.Text = "结束卡号错误（" & sErrorInfo & "）！请重新输入结束卡号。"
                        Case Else
                            frmMain.statusText.Text = sErrorInfo & "！请重新设置面值。"
                    End Select
                End If
            ElseIf Me.dgvCard(1, Me.dgvCard.CurrentRow.Index).Value Is Nothing OrElse Me.dgvCard(1, Me.dgvCard.CurrentRow.Index).Value.ToString = "" Then
                If Me.dgvCard.CurrentCell.ColumnIndex <> 1 Then
                    Me.dgvCard(1, Me.dgvCard.CurrentRow.Index).Selected = True
                    frmMain.statusText.Text = "请先输入开始卡号。"
                End If
            ElseIf Me.dgvCard(2, Me.dgvCard.CurrentRow.Index).Value Is Nothing OrElse Me.dgvCard(2, Me.dgvCard.CurrentRow.Index).Value.ToString = "" Then
                If Me.dgvCard.CurrentCell.ColumnIndex <> 1 Then
                    Me.dgvCard(2, Me.dgvCard.CurrentRow.Index).Selected = True
                    frmMain.statusText.Text = "请先输入结束卡号。"
                End If
            End If
        End If
        blSkipDeal = False
    End Sub

    Private Sub menuDeleteCardRow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuDeleteCardRow.Click
        blSkipDeal = True
        Dim iCurrentRow As Integer = Me.dgvCard.CurrentRow.Index, drCard As DataRowView = frmMain.dvCardFaceValue(iCurrentRow)
        If errorCell IsNot Nothing AndAlso errorCell.RowIndex = iCurrentRow Then errorCell = Nothing : sErrorInfo = ""
        If iCurrentRow = Me.dgvCard.RowCount - 1 Then
            drCard("StartCardNo") = DBNull.Value
            drCard("EndCardNo") = DBNull.Value
            drCard("CardQTY") = DBNull.Value
            drCard("FaceValue") = DBNull.Value
            drCard.EndEdit() : drCard.Row.AcceptChanges()
        Else
            drCard.Delete()
            For iRow As Integer = iCurrentRow To frmMain.dvCardFaceValue.Count - 1
                frmMain.dvCardFaceValue(iRow)("RowID") = iRow + 1
            Next
        End If
        iCurrentRow = Me.dgvCard.CurrentRow.Index
        Me.dgvCard("FaceValue", iCurrentRow).Selected = True : Me.dgvCard.CurrentRow.Selected = True
        Me.btnSave.Enabled = True
        Me.btnClearAll.Enabled = (Me.dgvCard.RowCount > 1)
        blSkipDeal = False
    End Sub

    Private Sub theTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles theTimer.Tick
        Me.theTimer.Enabled = False
        If sTimerType = "AfterConfigCard" Then
            frmMain.statusText.Text = "就绪。"
        Else '刷卡
            blBrushingEnd = True
        End If
    End Sub

    Private Sub btnClearAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClearAll.Click
        blSkipDeal = True
        For iRow As Int16 = Me.dgvCard.RowCount - 2 To 0 Step -1
            frmMain.dvCardFaceValue(iRow).Delete()
        Next
        errorCell = Nothing : sErrorInfo = ""
        Me.btnClearAll.Enabled = False
        frmMain.dvCardFaceValue(0)("RowID") = 1
        frmMain.dvCardFaceValue(0).EndEdit()
        Me.btnSave.Enabled = True
        blSkipDeal = False
        Me.dgvCard.Select()
        Me.dgvCard(1, 0).Selected = True
        Me.dgvCard.BeginEdit(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If errorCell IsNot Nothing Then
            MessageBox.Show("预定义列表中存在错误！请先修改错误，然后再保存。    ", "不能保存。", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.dgvCard.Select()
            blSkipDeal = True
            Me.dgvCard.Rows(errorCell.RowIndex).Selected = False
            blSkipDeal = False
            Me.dgvCard("StartCardNo", Me.dgvCard.RowCount - 1).Selected = True
            errorCell.Selected = True
            Me.dgvCard.BeginEdit(True)
            Return
        End If

        For Each drCard As DataGridViewRow In Me.dgvCard.Rows
            If drCard.Cells("StartCardNo").Value.ToString <> "" AndAlso drCard.Cells("FaceValue").Value.ToString = "" Then
                MessageBox.Show("不能保存预定义列表，因为有一行购物卡的面值未设置！    " & Chr(13) & Chr(13) & "请设置该行购物卡的面值。    ", "不能保存预定义列表！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.dgvCard.Select()
                Me.dgvCard("FaceValue", drCard.Index).Selected = True
                Me.dgvCard.BeginEdit(True)
                frmMain.statusText.Text = "不能保存预定义列表，因为有一行购物卡的面值未设置！请设置该行购物卡的面值。"
                Return
            End If
        Next

        Me.btnClose.Select()
        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在保存预定义的卡面值……"
        frmMain.statusMain.Refresh()

        Dim myWriter As IO.StreamWriter = Nothing, sRowText As String, iRows As Int16 = Me.dgvCard.RowCount - 2, bColumns As Byte = frmMain.dvCardFaceValue.Table.Columns.Count - 1
        Try
            If Not IO.Directory.Exists(Application.StartupPath & "\PredefineCardFaceValue") Then
                IO.Directory.CreateDirectory(Application.StartupPath & "\PredefineCardFaceValue")
            ElseIf IO.File.Exists(Application.StartupPath & "\PredefineCardFaceValue\PredefineCardFaceValue.dat") Then
                IO.File.Delete(Application.StartupPath & "\PredefineCardFaceValue\PredefineCardFaceValue.dat")
            End If

            myWriter = New IO.StreamWriter(Application.StartupPath & "\PredefineCardFaceValue\PredefineCardFaceValue.dat")
            For iRow As Int16 = 0 To iRows
                sRowText = ""
                For bColumn As Byte = 0 To bColumns
                    sRowText = sRowText & Me.dgvCard(bColumn, iRow).Value.ToString & Chr(9)
                Next
                sRowText = sRowText.Substring(0, sRowText.Length - 1)
                myWriter.WriteLine(sRowText)
            Next

            Me.dgvCard.Select()
            Me.btnClose.Select()
            Me.btnSave.Enabled = False

            MessageBox.Show("保存预定义的卡面值成功。    ", "保存成功。", MessageBoxButtons.OK, MessageBoxIcon.Information)
            frmMain.statusText.Text = "保存预定义的卡面值成功。"
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MessageBox.Show("保存预定义的卡面值时出现如下的错误：    " & Chr(13) & Chr(13) & ex.Message & "    " & Chr(13) & Chr(13) & "请检查原因，请在解决问题后重试。    ", "保存预定义的卡面值失败！", MessageBoxButtons.OK, MessageBoxIcon.Information)
            frmMain.statusText.Text = "保存预定义的卡面值失败！"
        Finally
            If myWriter IsNot Nothing Then
                myWriter.Close()
                myWriter.Dispose()
                myWriter = Nothing
            End If
            Me.Cursor = Cursors.Default
        End Try

        frmMain.dvCardFaceValue.Table.AcceptChanges()
    End Sub

    Private Sub CardNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Escape AndAlso errorCell IsNot Nothing AndAlso errorCell Is Me.dgvCard.CurrentCell Then errorCell = Nothing : e.SuppressKeyPress = True : Return
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If editingCardNo IsNot Nothing AndAlso editingCardNo.Text <> "" AndAlso editingCardNo.SelectedText.Length = editingCardNo.Text.Length Then
                blSkipDeal = True
                Me.dgvCard.CurrentCell.Value = ""
                blSkipDeal = False
            End If
            Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub CardQTY_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If Not blBrushingEnd Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.OemSemicolon Then '防止从读卡器上输入
            blBrushingEnd = False
            sTimerType = "BrushingCard"
            Me.theTimer.Interval = 1000 '延时1秒
            Me.theTimer.Enabled = True
            e.SuppressKeyPress = True : Return
        End If
        If e.KeyCode = Keys.Escape AndAlso errorCell IsNot Nothing AndAlso errorCell Is Me.dgvCard.CurrentCell Then errorCell = Nothing : e.SuppressKeyPress = True : Return
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        e.SuppressKeyPress = True
    End Sub

    Private Sub FaceValue_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If Not blBrushingEnd Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.OemSemicolon Then '防止从读卡器上输入
            blBrushingEnd = False
            sTimerType = "BrushingCard"
            Me.theTimer.Interval = 1000 '延时1秒
            Me.theTimer.Enabled = True
            e.SuppressKeyPress = True : Return
        End If
        If e.KeyCode = Keys.Escape AndAlso errorCell IsNot Nothing AndAlso errorCell Is Me.dgvCard.CurrentCell Then errorCell = Nothing : e.SuppressKeyPress = True : Return
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        If e.KeyCode = Keys.OemPeriod OrElse e.KeyCode = Keys.Decimal Then
            If editingFaceValue.SelectedText.IndexOf(".") > -1 OrElse editingFaceValue.Text.IndexOf(".") = -1 Then Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub editingTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.btnSave.Enabled = True
        sender.ForeColor = SystemColors.ControlText
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub ConfigCardRow()
        frmMain.Cursor = Cursors.WaitCursor

        Dim iRows As Integer = Me.dgvCard.RowCount - 1, iCurrentRow As Integer = Me.dgvCard.CurrentRow.Index, sStartCard As String = Me.dgvCard(1, iCurrentRow).Value.ToString, sEndCard As String = Me.dgvCard(2, iCurrentRow).Value.ToString
        If sStartCard > sEndCard Then
            Me.dgvCard.EndEdit() : sStartCard = sEndCard : sEndCard = Me.dgvCard(1, iCurrentRow).Value.ToString
            Me.dgvCard(1, iCurrentRow).Value = sStartCard : Me.dgvCard(2, iCurrentRow).Value = sEndCard
        End If

        Dim dtNew As DataTable = frmMain.dvCardFaceValue.ToTable, sStart As String, sEnd As String, iCardQTY As Integer = 0, drCard As DataRow, blNeedResetRow As Boolean = False
        dtNew.Rows.Clear()
        dtNew.Columns.Add("NewRowID", System.Type.GetType("System.Int16"))
        For iRow As Integer = 0 To iRows
            If iRow <> iCurrentRow AndAlso Me.dgvCard(1, iRow).Value.ToString <> "" AndAlso Me.dgvCard("CardQTY", iRow).Value <> 0 Then
                sStart = Me.dgvCard(1, iRow).Value.ToString : sEnd = Me.dgvCard(2, iRow).Value.ToString
                If sStartCard > sEnd OrElse sEndCard < sStart Then '该行卡号范围落在当前修改行之外,保留该行
                    drCard = dtNew.Rows.Add()
                    drCard("RowID") = iRow + 1
                    drCard("NewRowID") = 0
                    drCard("StartCardNo") = sStart
                    drCard("EndCardNo") = sEnd
                    drCard("CardQTY") = Me.dgvCard("CardQTY", iRow).Value
                    drCard("FaceValue") = Me.dgvCard("FaceValue", iRow).Value
                    drCard.EndEdit()
                ElseIf sStartCard < sStart AndAlso sEnd < sEndCard Then '该行卡号范围完全落在当前修改行之内,将被删除
                    blNeedResetRow = True
                Else '该行卡号范围部分落在当前修改行之内,将被截断
                    Dim dtTemp As New DataTable
                    dtTemp.Columns.Add("CardNo", System.Type.GetType("System.String"))
                    Dim dvTemp As New DataView(dtTemp), drTemp As DataRowView
                    sStart = sStart.Substring(0, 18)
                    iCardQTY = Me.dgvCard("CardQTY", iRow).Value - 1
                    For iCard As Integer = 0 To iCardQTY
                        sEnd = (CLng(sStart) + iCard).ToString
                        If sEnd < sStartCard.Substring(0, 18) OrElse sEnd > sEndCard.Substring(0, 18) Then
                            drTemp = dvTemp.AddNew
                            drTemp(0) = sEnd
                            drTemp.EndEdit()
                        End If
                    Next
                    dtTemp.AcceptChanges()

                    If dvTemp.Count > 0 Then
                        dvTemp.Sort = "CardNo"
                        sStart = dvTemp(0)("CardNo").ToString : sEnd = sStart : iCardQTY = 1
                        For iCard As Integer = 1 To dvTemp.Count - 1
                            If CLng(dvTemp(iCard)("CardNo").ToString) - CLng(sEnd) = 1 Then
                                iCardQTY += 1
                                sEnd = dvTemp(iCard)("CardNo").ToString
                            Else
                                drCard = dtNew.Rows.Add()
                                drCard("RowID") = iRow + 1
                                drCard("NewRowID") = iCard - 1
                                drCard("StartCardNo") = ShoppingCardNo.GetFullCardNo(sStart)
                                drCard("EndCardNo") = ShoppingCardNo.GetFullCardNo(sEnd)
                                drCard("CardQTY") = iCardQTY
                                drCard("FaceValue") = Me.dgvCard("FaceValue", iRow).Value
                                drCard.EndEdit()

                                sStart = dvTemp(iCard)("CardNo").ToString
                                sEnd = sStart
                                iCardQTY = 1
                            End If
                        Next
                        drCard = dtNew.Rows.Add()
                        drCard("RowID") = iRow + 1
                        drCard("NewRowID") = dvTemp.Count
                        drCard("StartCardNo") = ShoppingCardNo.GetFullCardNo(sStart)
                        drCard("EndCardNo") = ShoppingCardNo.GetFullCardNo(sEnd)
                        drCard("CardQTY") = iCardQTY
                        drCard("FaceValue") = Me.dgvCard("FaceValue", iRow).Value
                        drCard.EndEdit()
                    End If
                    dtTemp.Dispose() : dtTemp = Nothing : dvTemp.Dispose() : dvTemp = Nothing
                    blNeedResetRow = True
                End If
            End If
        Next

        If blNeedResetRow Then
            drCard = dtNew.Rows.Add()
            drCard("RowID") = iCurrentRow + 1
            drCard("NewRowID") = 0
            drCard("StartCardNo") = sStartCard
            drCard("EndCardNo") = sEndCard
            drCard("CardQTY") = CLng(sEndCard.Substring(0, 18)) - CLng(sStartCard.Substring(0, 18)) + 1
            If Me.dgvCard("FaceValue", iCurrentRow).Value.ToString <> "" Then
                drCard("FaceValue") = Me.dgvCard("FaceValue", iCurrentRow).Value
            End If
            drCard.EndEdit()
            Dim bCurrentColumn As Byte = Me.dgvCard.CurrentCell.ColumnIndex
            For Each drOld As DataRowView In frmMain.dvCardFaceValue
                drOld.Delete()
            Next
            dtNew.DefaultView.Sort = "RowID,NewRowID"
            iRows = 1
            Dim newCard As DataRowView
            For Each drNew As DataRow In dtNew.Rows
                drNew("RowID") = iRows
                newCard = frmMain.dvCardFaceValue.AddNew
                newCard("RowID") = iRows
                newCard("StartCardNo") = drNew("StartCardNo").ToString
                newCard("EndCardNo") = drNew("EndCardNo").ToString
                newCard("CardQTY") = drNew("CardQTY")
                newCard("FaceValue") = drNew("FaceValue")
                iRows += 1
            Next

            For Each dr As DataGridViewRow In Me.dgvCard.Rows
                If dr.Cells("StartCardNo").Value.ToString = sStartCard Then
                    iCurrentRow = dr.Index
                    Me.dgvCard(bCurrentColumn, dr.Index).Selected = True : Exit For
                End If
            Next
        Else
            Me.dgvCard("CardQTY", iCurrentRow).Value = CLng(sEndCard.Substring(0, 18)) - CLng(sStartCard.Substring(0, 18)) + 1
            If Me.dgvCard.CurrentCell.RowIndex = Me.dgvCard.RowCount - 1 Then frmMain.dvCardFaceValue.Table.Rows.Add(iRows + 2)
        End If

        If Me.dgvCard("CardQTY", Me.dgvCard.RowCount - 1).Value.ToString <> "" Then
            Dim newCardRow As DataRowView = frmMain.dvCardFaceValue.AddNew()
            newCardRow("RowID") = Me.dgvCard.RowCount
            newCardRow.EndEdit() : newCardRow.Row.AcceptChanges()
        End If

        Me.dgvCard.EndEdit()
        dtNew.Dispose() : dtNew = Nothing
        frmMain.Cursor = Cursors.Default
    End Sub

    Private Sub CheckErrorCell()
        If iPreviousErrorRowID > Me.dgvCard.RowCount - 1 Then iPreviousErrorRowID = -1 : Return
        Dim sValue As String = Me.dgvCard("StartCardNo", iPreviousErrorRowID).Value.ToString, iCardQTY As Integer = 0
        errorCell = Nothing : sErrorInfo = ""
        If Not IsNumeric(sValue) Then
            sErrorInfo = "卡号错误"
        ElseIf sValue.Length < 19 Then
            sErrorInfo = "卡号位数不足 19 位"
        ElseIf sValue <> ShoppingCardNo.GetFullCardNo(sValue.Substring(0, 18)) Then
            sErrorInfo = "卡号校验码错误"
        ElseIf sCULCardBin <> "" AndAlso sCULCardBin.IndexOf(sValue.Substring(4, 5)) = -1 Then
            sErrorInfo = "银商卡Bin码不符"
        End If

        If sErrorInfo = "" Then
            sValue = Me.dgvCard("EndCardNo", iPreviousErrorRowID).Value.ToString
            If Not IsNumeric(sValue) Then
                sErrorInfo = "卡号错误"
            ElseIf sValue.Length < 19 Then
                sErrorInfo = "卡号位数不足 19 位"
            ElseIf sValue <> ShoppingCardNo.GetFullCardNo(sValue.Substring(0, 18)) Then
                sErrorInfo = "卡号校验码错误"
            ElseIf sCULCardBin <> "" AndAlso sCULCardBin.IndexOf(sValue.Substring(4, 5)) = -1 Then
                sErrorInfo = "银商卡Bin码不符"
            Else
                iCardQTY = Math.Abs(CLng(sValue.Substring(0, 18)) - CLng(Me.dgvCard("StartCardNo", iPreviousErrorRowID).Value.ToString.Substring(0, 18))) + 1
                If iCardQTY > 10000 Then
                    sErrorInfo = "卡号超出许可范围，单行卡数请限制在 10,000 张以内"
                End If
            End If

            If sErrorInfo = "" Then
                sValue = Me.dgvCard("CardQTY", iPreviousErrorRowID).Value.ToString
                If iCardQTY.ToString <> sValue Then Me.dgvCard("CardQTY", iPreviousErrorRowID).Value = iCardQTY
                sValue = Me.dgvCard("FaceValue", iPreviousErrorRowID).Value.ToString
                If sValue = "" OrElse Not IsNumeric(sValue) OrElse CDec(sValue) = 0 Then
                    If sValue <> "" AndAlso Not IsNumeric(sValue) Then Me.dgvCard("FaceValue", iPreviousErrorRowID).Value = "" : sValue = ""
                    sErrorInfo = IIf(sValue = "", "卡片面值不能为空", "卡片面值不能为零")
                ElseIf CDec(sValue) < dmMinFaceValue OrElse CDec(sValue) > dmMaxFaceValue Then '检查面值限制
                    sErrorInfo = "卡片预设面值应该介于 " & Format(dmMinFaceValue, "#,0.00").Replace(".00", "") & " 元 与 " & Format(dmMaxFaceValue, "#,0.00").Replace(".00", "") & " 元之间"
                End If

                If sErrorInfo = "" Then
                    iPreviousErrorRowID = -1
                Else
                    errorCell = Me.dgvCard("FaceValue", iPreviousErrorRowID)
                End If
            Else
                errorCell = Me.dgvCard("EndCardNo", iPreviousErrorRowID)
            End If
        Else
            errorCell = Me.dgvCard("StartCardNo", iPreviousErrorRowID)
        End If
    End Sub
End Class
