Public Class frmArea

    Private blSkipDeal As Boolean = False, blIsReadOnly As Boolean = False, blInnerError As Boolean = False, blPrompt As Boolean = True, dtArea As DataTable, currentRow As DataRow, currentNode As TreeNode = Nothing, cuttedNode As TreeNode = Nothing, dtToday As Date

    Private Sub frmArea_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Enter
        If blSkipDeal Then
            Me.trvArea.ExpandAll()
            blSkipDeal = False
            Me.trvArea.SelectedNode.EnsureVisible()
        End If
    End Sub

    Private Sub frmArea_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub frmArea_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DB As New DataBase()
        DB.Open(True)
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打开窗口。请检查数据库连接。"
            Me.Close() : Return
        End If

        dtArea = DB.GetDataTable("Select *, Convert(datetime,Convert(varchar(10),Getdate(),112)) As Today From AreaList Order By AreaCode")
        If dtArea.Rows.Count = 0 Then
            dtToday = Today
        Else
            dtToday = dtArea.Rows(0)("Today")
        End If
        If dtArea Is Nothing Then
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开窗口。请联系软件开发人员。"
            DB.Close() : Me.Close() : Return
        End If
        DB.Close()

        Me.InitAreaTree(Me.trvArea.Nodes, "-1")
        currentNode = Me.trvArea.Nodes(0)
        Me.trvArea.SelectedNode = currentNode
        currentNode.ExpandAll()
        currentNode.EnsureVisible()
        Me.trvArea.Select()

        blIsReadOnly = (frmMain.dtAllowedRight.Select("RightName='AreaMaintance'").Length = 0)
        If blIsReadOnly Then
            Me.txbAreaCode.ReadOnly = True
            Me.txbChineseName.ReadOnly = True : Me.txbChineseName.BackColor = SystemColors.Window : Me.txbChineseName.BackColor = SystemColors.Control
            Me.txbEnglishName.ReadOnly = True : Me.txbEnglishName.BackColor = SystemColors.Window : Me.txbEnglishName.BackColor = SystemColors.Control
            Me.txbCULCardBin.ReadOnly = True : Me.txbCULCardBin.BackColor = SystemColors.Window : Me.txbCULCardBin.BackColor = SystemColors.Control
            Me.txbCULStoreCode.ReadOnly = True : Me.txbCULStoreCode.BackColor = SystemColors.Window : Me.txbCULStoreCode.BackColor = SystemColors.Control
            Me.chbIsRollout.AutoCheck = False
            Me.chbLockedTrainingMode.AutoCheck = False
            Me.pnlEdit.Enabled = False
            Me.Text = Me.Text & " (只读 Readonly)"
        End If
        blSkipDeal = True
    End Sub

    Private Sub InitAreaTree(ByVal tncCurrent As TreeNodeCollection, ByVal sParentID As String)
        Try
            Dim newNode As TreeNode
            For Each dr As DataRow In dtArea.Select("ParentAreaID=" & sParentID, "AreaCode")
                newNode = New TreeNode
                newNode.Name = dr("AreaID").ToString
                newNode.Text = dr("AreaType").ToString & dr("AreaCode").ToString & " " & dr("AreaChineseName").ToString & " " & dr("AreaEnglishName").ToString
                If dr("IsRollout") AndAlso dr("RolloutDate") <= dtToday Then
                    newNode.ImageKey = dr("AreaType").ToString & "R"
                Else
                    newNode.ImageKey = dr("AreaType").ToString
                End If
                newNode.SelectedImageKey = newNode.ImageKey
                tncCurrent.Add(newNode)
                sParentID = dr("AreaID").ToString
                Me.InitAreaTree(tncCurrent(tncCurrent.Count - 1).Nodes, sParentID)
            Next
        Catch
            MessageBox.Show("初始化分类结构树时失败！", "初始化分类结构树时失败！")
        End Try
    End Sub

    Private Sub promptTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles promptTimer.Tick
        Me.promptTimer.Enabled = False
        blPrompt = True
    End Sub

    Private Sub trvArea_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvArea.AfterSelect
        If Not blIsReadOnly AndAlso Me.trvArea.SelectedNode IsNot Nothing Then
            Me.btnAdd.Enabled = (Me.trvArea.SelectedNode.ImageKey.IndexOf("S") = -1)
            Me.btnDelete.Enabled = (Me.trvArea.SelectedNode.Name <> "0")
            Me.btnCut.Enabled = (Me.trvArea.SelectedNode.ImageKey.IndexOf("H") = -1 AndAlso Me.trvArea.SelectedNode.ImageKey.IndexOf("T") = -1)
            If cuttedNode Is Nothing Then
                Me.btnPaste.Enabled = False
            Else
                Dim blEnabled As Boolean = False
                Select Case cuttedNode.ImageKey
                    Case "RC"
                        If Me.trvArea.SelectedNode.ImageKey.IndexOf("T") > -1 Then blEnabled = True
                    Case "CC"
                        If Me.trvArea.SelectedNode.ImageKey.IndexOf("R") > -1 Then blEnabled = True
                    Case "SC"
                        If Me.trvArea.SelectedNode.ImageKey.IndexOf("C") > -1 Then blEnabled = True
                End Select
                Me.btnPaste.Enabled = blEnabled
            End If
        End If
        If blSkipDeal Then Return

        currentNode = Me.trvArea.SelectedNode
        currentRow = dtArea.Select("AreaID=" & currentNode.Name)(0)
        Me.FillArea()
    End Sub

    Private Sub trvArea_BeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles trvArea.BeforeSelect
        If Me.txbPreCode.Text = "S" AndAlso currentRow.RowState <> DataRowState.Deleted AndAlso currentRow.RowState <> DataRowState.Detached Then
            If Me.txbCULCardBin.Text = "" Then
                Me.txbCULCardBin.Select()
                e.Cancel = True
            ElseIf Me.txbCULStoreCode.Text = "" Then
                Me.txbCULStoreCode.Select()
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub trvArea_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles trvArea.DoubleClick
        Me.txbAreaCode.Select()
        Me.txbAreaCode.SelectAll()
    End Sub

    Private Sub trvArea_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles trvArea.Enter
        If currentNode IsNot Nothing Then
            currentNode.BackColor = SystemColors.Window
            currentNode.ForeColor = SystemColors.ControlText
        End If
    End Sub

    Private Sub trvArea_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles trvArea.KeyDown
        If e.KeyCode = Keys.Insert AndAlso Me.btnAdd.Enabled Then Me.btnAdd.PerformClick() : e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Delete AndAlso Me.btnDelete.Enabled Then Me.btnDelete.PerformClick() : e.SuppressKeyPress = True : Return
        If e.Control AndAlso e.KeyCode = Keys.X AndAlso Me.btnCut.Enabled Then Me.btnCut.PerformClick() : e.SuppressKeyPress = True : Return
        If e.Control AndAlso e.KeyCode = Keys.V AndAlso Me.btnPaste.Enabled Then Me.btnPaste.PerformClick() : e.SuppressKeyPress = True : Return
    End Sub

    Private Sub trvArea_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles trvArea.Leave
        If currentNode IsNot Nothing Then
            currentNode.BackColor = SystemColors.Highlight
            currentNode.ForeColor = SystemColors.HighlightText
        End If
    End Sub

    Private Sub FillArea()
        If Me.txbPreCode.Text <> currentRow("AreaType").ToString Then
            Me.grbCUL.Visible = (currentRow("AreaType").ToString = "S")
        End If
        Me.txbPreCode.Text = currentRow("AreaType").ToString
        Select Case currentRow("AreaType").ToString
            Case "H"
                Me.theTip.SetToolTip(Me.txbPreCode, "区域类型：总部")
            Case "T"
                Me.theTip.SetToolTip(Me.txbPreCode, "区域类型：大区")
            Case "R"
                Me.theTip.SetToolTip(Me.txbPreCode, "区域类型：小区")
            Case "C"
                Me.theTip.SetToolTip(Me.txbPreCode, "区域类型：城市")
            Case "S"
                Me.theTip.SetToolTip(Me.txbPreCode, "区域类型：门店")
                Me.txbCULCardBin.Text = currentRow("CULCardBin").ToString
                Me.txbCULStoreCode.Text = currentRow("CULStoreCode").ToString
        End Select
        Me.txbAreaCode.Text = currentRow("AreaCode").ToString
        Me.txbChineseName.Text = currentRow("AreaChineseName").ToString
        Me.txbEnglishName.Text = currentRow("AreaEnglishName").ToString

        blSkipDeal = True
        Me.chbIsRollout.Checked = currentRow("IsRollout")
        Me.pnlIsRollout.Enabled = Me.chbIsRollout.Checked
        Me.dtpRolloutDate.MinDate = "1753-1-1"
        If currentRow("RolloutDate").ToString = "" Then
            Me.dtpRolloutDate.MinDate = Today()
            Me.dtpRolloutDate.Value = Today()
            Me.dtpRolloutDate.Visible = True
            Me.txbRolloutDate.Visible = False
            If currentRow("AreaCode").ToString = "999" Then
                Me.grbSchedule.Enabled = False
            Else
                Me.grbSchedule.Enabled = True
            End If
        Else
            Me.grbSchedule.Enabled = True
            Me.dtpRolloutDate.Value = currentRow("RolloutDate")
            If blIsReadOnly Then
                Me.dtpRolloutDate.Visible = False
                Me.txbRolloutDate.Visible = True
            ElseIf currentRow.RowState = DataRowState.Added OrElse currentRow("RolloutDate", DataRowVersion.Original).ToString = "" OrElse currentRow("RolloutDate", DataRowVersion.Original) > Today() Then
                Me.dtpRolloutDate.MinDate = Today()
                Me.dtpRolloutDate.Visible = True
                Me.txbRolloutDate.Visible = False
            Else
                Me.dtpRolloutDate.Visible = False
                Me.txbRolloutDate.Visible = True
            End If
        End If
        Me.chbLockedTrainingMode.Checked = (currentRow("IsRollout") AndAlso currentRow("LockedTrainingMode"))
        blSkipDeal = False
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Me.trvArea.Select()

        Dim iAreaID As Int16, sChineseName As String = "", sEnglishName As String = "", sName As String, newRow As DataRow = dtArea.Rows.Add(), newNode As New TreeNode
        Try
            iAreaID = dtArea.Compute("Max(AreaID)", "") + 1
        Catch
            iAreaID = 0
            Do While dtArea.Select("AreaID=" & iAreaID.ToString).Length > 0
                iAreaID += 1
            Loop
        End Try
        newRow("AreaID") = iAreaID : newNode.Name = iAreaID.ToString
        newRow("ParentAreaID") = currentRow("AreaID")
        newRow("IsRollout") = 0
        newRow("LockedTrainingMode") = 0
        newRow("UserQTY") = 0
        Select Case currentRow("AreaType").ToString
            Case "H"
                sChineseName = "新大区" : sEnglishName = "New Territory"
                newRow("AreaType") = "T"
                newNode.ImageKey = "T"
            Case "T"
                sChineseName = "新小区" : sEnglishName = "New Region"
                newRow("AreaType") = "R"
                newNode.ImageKey = "R"
            Case "R"
                sChineseName = "新城市" : sEnglishName = "New City"
                newRow("AreaType") = "C"
                newNode.ImageKey = "C"
            Case "C"
                sChineseName = "新门店" : sEnglishName = "New Store"
                newRow("AreaType") = "S"
                newNode.ImageKey = "S"
        End Select
        If currentNode.Nodes.Count = 0 Then
            iAreaID = 0
        Else
            iAreaID = dtArea.Compute("Max(AreaCode)", "AreaType='" & newRow("AreaType").ToString & "' And ParentAreaID=" & currentRow("AreaID")) + 1
        End If
        If iAreaID = 1000 Then iAreaID = 0
        Do While dtArea.Select("AreaType='" & newRow("AreaType").ToString & "' And AreaCode='" & Format(iAreaID, "000") & "'").Length > 0
            iAreaID += 1
        Loop
        newRow("AreaCode") = Format(iAreaID, "000")
        iAreaID = 0 : sName = sChineseName
        Do While dtArea.Select("AreaType='" & newRow("AreaType").ToString & "' And AreaChineseName='" & sName & "'").Length > 0
            iAreaID += 1
            sName = sChineseName & " (" & iAreaID.ToString & ")"
        Loop
        newRow("AreaChineseName") = sName
        newNode.Text = newRow("AreaType").ToString & newRow("AreaCode").ToString & " " & sName
        iAreaID = 0 : sName = sEnglishName
        Do While dtArea.Select("AreaType='" & newRow("AreaType").ToString & "' And AreaEnglishName='" & sName & "'").Length > 0
            iAreaID += 1
            sName = sEnglishName & " (" & iAreaID.ToString & ")"
        Loop
        newRow("AreaEnglishName") = sName
        newNode.Text = newNode.Text & " " & sName

        newNode.SelectedImageKey = newNode.ImageKey
        iAreaID = dtArea.Compute("Count(AreaCode)", "ParentAreaID=" & currentRow("AreaID").ToString & " And AreaCode<='" & newRow("AreaCode").ToString & "'") - 1
        currentNode.Nodes.Insert(iAreaID, newNode)
        Me.trvArea.SelectedNode = newNode
        newNode.EnsureVisible()

        Me.btnSave.Enabled = True

        Me.trvArea.Select()
        Me.txbAreaCode.Select()
        Me.txbAreaCode.SelectAll()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If currentRow("UserQTY") > 0 Then
            MessageBox.Show("您不能删除当前区域单元！因为当前区域单元已存在用户。    ", "不能删除已存在用户的区域单元！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        ElseIf currentNode.Nodes.Count > 1 Then
            MessageBox.Show("您不能删除当前区域单元！因为当前区域单元存在下级区域单元。    ", "不能删除存在下级区域单元的区域单元！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If currentNode.Equals(cuttedNode) Then cuttedNode = Nothing
        currentRow.Delete()
        currentNode.Remove()
        Me.btnSave.Enabled = True
        Me.trvArea.Select()
    End Sub

    Private Sub btnCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCut.Click
        If cuttedNode IsNot Nothing Then Me.SetCuttedState(cuttedNode, False)
        cuttedNode = currentNode
        Me.SetCuttedState(cuttedNode, True)

        Me.trvArea.Select()
    End Sub

    Private Sub btnPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaste.Click
        If Not cuttedNode.Parent.Equals(currentNode) Then
            Dim cuttedRow As DataRow = dtArea.Select("AreaID=" & cuttedNode.Name)(0)
            cuttedRow("ParentAreaID") = currentNode.Name
            If cuttedRow.RowState = DataRowState.Modified AndAlso cuttedRow("AreaCode").ToString = cuttedRow("AreaCode", DataRowVersion.Original).ToString AndAlso cuttedRow("AreaChineseName").ToString = cuttedRow("AreaChineseName", DataRowVersion.Original).ToString AndAlso cuttedRow("AreaEnglishName").ToString = cuttedRow("AreaEnglishName", DataRowVersion.Original).ToString AndAlso cuttedRow("ParentAreaID").ToString = cuttedRow("ParentAreaID", DataRowVersion.Original).ToString Then cuttedRow.AcceptChanges()
            Me.btnSave.Enabled = True
            Dim iIndex As Int16 = dtArea.Compute("Count(AreaCode)", "ParentAreaID=" & currentNode.Name & " And AreaCode<='" & cuttedRow("AreaCode").ToString & "'") - 1
            blSkipDeal = True
            cuttedNode.Remove()
            currentNode.Nodes.Insert(iIndex, cuttedNode)
            blSkipDeal = False
        End If
        Me.SetCuttedState(cuttedNode, False)
        currentNode.BackColor = SystemColors.Window
        currentNode.ForeColor = SystemColors.ControlText
        Me.trvArea.SelectedNode = cuttedNode
        cuttedNode.EnsureVisible()
        cuttedNode = Nothing
        Me.btnPaste.Enabled = False
        Me.trvArea.Select()
    End Sub

    Private Sub SetCuttedState(ByVal node As TreeNode, ByVal IsCutted As Boolean)
        If IsCutted Then
            node.ImageKey = node.ImageKey.Substring(0, 1) & "C"
        Else
            Dim dr As DataRow = dtArea.Select("AreaID=" & node.Name)(0)
            If dr("IsRollout") AndAlso dr("RolloutDate") <= dtToday Then
                node.ImageKey = dr("AreaType").ToString & "R"
            Else
                node.ImageKey = dr("AreaType").ToString
            End If
        End If
        node.SelectedImageKey = node.ImageKey
        For Each chdNode As TreeNode In node.Nodes
            Me.SetCuttedState(chdNode, IsCutted)
        Next
    End Sub

    Private Sub txbAreaCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbAreaCode.KeyDown
        If e.KeyCode = Keys.Escape AndAlso Me.txbAreaCode.Text <> currentRow("AreaCode").ToString Then Me.txbAreaCode.Text = currentRow("AreaCode").ToString : Me.txbAreaCode.SelectAll() : e.SuppressKeyPress = True : blInnerError = False : Return
        If e.KeyCode = Keys.Enter Then Me.txbChineseName.Select() : Me.txbChineseName.SelectAll() : e.SuppressKeyPress = True : Return
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbAreaCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txbAreaCode.KeyPress
        If blIsReadOnly Then
            My.Computer.Clipboard.Clear()
            e.Handled = True
            frmMain.statusText.Text = "您不能修改区域编号！因为您只有浏览的权限但没有修改的权限。"
        End If
    End Sub

    Private Sub txbAreaCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbAreaCode.Leave
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub txbAreaCode_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txbAreaCode.MouseDown
        If blIsReadOnly OrElse Not IsNumeric(My.Computer.Clipboard.GetText) Then My.Computer.Clipboard.Clear()
    End Sub

    Private Sub txbAreaCode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txbAreaCode.Validating
        blInnerError = False
        If cuttedNode IsNot Nothing AndAlso cuttedNode.Equals(currentNode) AndAlso Me.txbAreaCode.Text <> currentRow("AreaCode").ToString Then
            Me.SetCuttedState(cuttedNode, False)
            cuttedNode = Nothing
        End If
        Dim sCode As String = Me.txbAreaCode.Text.Trim
        Me.txbAreaCode.Text = sCode
        If sCode = "" Then
            Me.txbAreaCode.Text = currentRow("AreaCode").ToString
        ElseIf sCode <> currentRow("AreaCode").ToString Then
            If dtArea.Select("AreaType='" & currentRow("AreaType").ToString & "' And AreaCode='" & sCode & "'").Length > 0 Then
                blInnerError = True
                Me.Activate()
                If blPrompt Then
                    MessageBox.Show("此编号已经存在！请改用另一个编号。    ", "区域编号重复！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    blPrompt = False
                    Me.promptTimer.Enabled = True
                End If
                Me.txbAreaCode.Select()
                Me.txbAreaCode.SelectAll()
                e.Cancel = True
            Else
                currentRow("AreaCode") = sCode
                currentNode.Text = currentRow("AreaType").ToString & currentRow("AreaCode").ToString & " " & currentRow("AreaChineseName").ToString & " " & currentRow("AreaEnglishName").ToString
                Dim iOldIndex As Int16 = currentNode.Index, iNewIndex As Int16 = dtArea.Compute("Count(AreaCode)", "ParentAreaID=" & currentNode.Parent.Name & " And AreaCode<='" & sCode & "'") - 1
                If iOldIndex <> iNewIndex Then
                    blSkipDeal = True
                    Dim parentNode As TreeNode = currentNode.Parent
                    currentNode.Remove()
                    parentNode.Nodes.Insert(iNewIndex, currentNode)
                    Me.trvArea.SelectedNode = currentNode
                    parentNode = Nothing
                    blSkipDeal = False
                End If
                If currentRow.RowState = DataRowState.Modified AndAlso currentRow("AreaCode").ToString = currentRow("AreaCode", DataRowVersion.Original).ToString AndAlso currentRow("AreaChineseName").ToString = currentRow("AreaChineseName", DataRowVersion.Original).ToString AndAlso currentRow("AreaEnglishName").ToString = currentRow("AreaEnglishName", DataRowVersion.Original).ToString AndAlso currentRow("ParentAreaID").ToString = currentRow("ParentAreaID", DataRowVersion.Original).ToString Then currentRow.AcceptChanges()
                Me.btnSave.Enabled = (dtArea.GetChanges() IsNot Nothing)
            End If
        End If
    End Sub

    Private Sub txbChineseName_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbChineseName.DoubleClick
        Me.txbChineseName.SelectAll()
    End Sub

    Private Sub txbChineseName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbChineseName.KeyDown
        If e.KeyCode = Keys.Escape AndAlso Me.txbChineseName.Text <> currentRow("AreaChineseName").ToString Then Me.txbChineseName.Text = currentRow("AreaChineseName").ToString : Me.txbChineseName.SelectAll() : e.SuppressKeyPress = True : blInnerError = False : Return
        If e.KeyCode = Keys.Enter Then Me.txbEnglishName.Select() : Me.txbEnglishName.SelectAll() : e.SuppressKeyPress = True
    End Sub

    Private Sub txbChineseName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txbChineseName.KeyPress
        If blIsReadOnly Then
            My.Computer.Clipboard.Clear()
            e.Handled = True
            frmMain.statusText.Text = "您不能修改中文名称！因为您只有浏览的权限但没有修改的权限。"
        End If
    End Sub

    Private Sub txbChineseName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbChineseName.Leave
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub txbChineseName_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txbChineseName.MouseDown
        If blIsReadOnly Then My.Computer.Clipboard.Clear()
    End Sub

    Private Sub txbChineseName_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txbChineseName.Validating
        blInnerError = False
        If cuttedNode IsNot Nothing AndAlso cuttedNode.Equals(currentNode) AndAlso Me.txbAreaCode.Text <> currentRow("AreaChineseName").ToString Then
            Me.SetCuttedState(cuttedNode, False)
            cuttedNode = Nothing
        End If
        Dim sName As String = Me.txbChineseName.Text.Trim
        Me.txbChineseName.Text = sName
        If sName = "" Then
            Me.txbChineseName.Text = currentRow("AreaChineseName").ToString
        ElseIf sName <> currentRow("AreaChineseName").ToString Then
            If dtArea.Select("AreaType='" & currentRow("AreaType").ToString & "' And AreaCode<>'" & Me.txbAreaCode.Text & "' And AreaChineseName='" & sName & "'").Length > 0 Then
                blInnerError = True
                Me.Activate()
                If blPrompt Then
                    MessageBox.Show("此名称已经存在！请改用另一个名称。    ", "中文名称重复！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    blPrompt = False
                    Me.promptTimer.Enabled = True
                End If
                Me.txbChineseName.SelectAll()
                e.Cancel = True
            Else
                currentRow("AreaChineseName") = sName
                currentNode.Text = currentRow("AreaType").ToString & currentRow("AreaCode").ToString & " " & currentRow("AreaChineseName").ToString & " " & currentRow("AreaEnglishName").ToString
                If currentRow.RowState = DataRowState.Modified AndAlso currentRow("AreaCode").ToString = currentRow("AreaCode", DataRowVersion.Original).ToString AndAlso currentRow("AreaChineseName").ToString = currentRow("AreaChineseName", DataRowVersion.Original).ToString AndAlso currentRow("AreaEnglishName").ToString = currentRow("AreaEnglishName", DataRowVersion.Original).ToString AndAlso currentRow("ParentAreaID").ToString = currentRow("ParentAreaID", DataRowVersion.Original).ToString Then currentRow.AcceptChanges()
                Me.btnSave.Enabled = (dtArea.GetChanges() IsNot Nothing)
            End If
        End If
    End Sub

    Private Sub txbEnglishName_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbEnglishName.DoubleClick
        Me.txbEnglishName.SelectAll()
    End Sub

    Private Sub txbEnglishName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbEnglishName.KeyDown
        If e.KeyCode = Keys.Escape AndAlso Me.txbEnglishName.Text <> currentRow("AreaEnglishName").ToString Then Me.txbEnglishName.Text = currentRow("AreaEnglishName").ToString : Me.txbEnglishName.SelectAll() : e.SuppressKeyPress = True : blInnerError = False : Return
        If e.KeyCode = Keys.Enter Then
            If Me.txbPreCode.Text = "S" Then
                Me.txbCULCardBin.Select() : Me.txbCULCardBin.SelectAll()
            Else
                Me.txbAreaCode.Select() : Me.txbAreaCode.SelectAll()
            End If
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txbEnglishName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txbEnglishName.KeyPress
        If blIsReadOnly Then
            My.Computer.Clipboard.Clear()
            e.Handled = True
            frmMain.statusText.Text = "您不能修英文名称！因为您只有浏览的权限但没有修改的权限。"
        End If
    End Sub

    Private Sub txbEnglishName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbEnglishName.Leave
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub txbEnglishName_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txbEnglishName.MouseDown
        If blIsReadOnly Then My.Computer.Clipboard.Clear()
    End Sub

    Private Sub txbEnglishName_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txbEnglishName.Validating
        blInnerError = False
        If cuttedNode IsNot Nothing AndAlso cuttedNode.Equals(currentNode) AndAlso Me.txbAreaCode.Text <> currentRow("AreaEnglishName").ToString Then
            Me.SetCuttedState(cuttedNode, False)
            cuttedNode = Nothing
        End If
        Dim sName As String = Me.txbEnglishName.Text.Trim
        Me.txbEnglishName.Text = sName
        If sName = "" Then
            Me.txbEnglishName.Text = currentRow("AreaEnglishName").ToString
        ElseIf sName <> currentRow("AreaEnglishName").ToString Then
            If dtArea.Select("AreaType='" & currentRow("AreaType").ToString & "' And AreaCode<>'" & Me.txbAreaCode.Text & "' And AreaEnglishName='" & sName & "'").Length > 0 Then
                blInnerError = True
                Me.Activate()
                If blPrompt Then
                    MessageBox.Show("此名称已经存在！请改用另一个名称。    ", "英文名称重复！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    blPrompt = False
                    Me.promptTimer.Enabled = True
                End If
                Me.txbEnglishName.SelectAll()
                e.Cancel = True
            Else
                currentRow("AreaEnglishName") = sName
                currentNode.Text = currentRow("AreaType").ToString & currentRow("AreaCode").ToString & " " & currentRow("AreaChineseName").ToString & " " & currentRow("AreaEnglishName").ToString
                If currentRow.RowState = DataRowState.Modified AndAlso currentRow("AreaCode").ToString = currentRow("AreaCode", DataRowVersion.Original).ToString AndAlso currentRow("AreaChineseName").ToString = currentRow("AreaChineseName", DataRowVersion.Original).ToString AndAlso currentRow("AreaEnglishName").ToString = currentRow("AreaEnglishName", DataRowVersion.Original).ToString AndAlso currentRow("ParentAreaID").ToString = currentRow("ParentAreaID", DataRowVersion.Original).ToString Then currentRow.AcceptChanges()
                Me.btnSave.Enabled = (dtArea.GetChanges() IsNot Nothing)
            End If
        End If
    End Sub

    Private Sub chbIsRollout_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbIsRollout.CheckedChanged
        If blSkipDeal Then Return
        If cuttedNode IsNot Nothing AndAlso cuttedNode.Equals(currentNode) Then
            Me.SetCuttedState(cuttedNode, False)
            cuttedNode = Nothing
        End If
        If Me.chbIsRollout.Checked Then
            currentRow("IsRollout") = 1
            If currentRow("RolloutDate").ToString = "" Then currentRow("RolloutDate") = Me.dtpRolloutDate.Value
            If currentRow.RowState = DataRowState.Added OrElse currentRow("RolloutDate", DataRowVersion.Original).ToString = "" Then
                Me.chbLockedTrainingMode.Checked = True
            Else
                Me.chbLockedTrainingMode.Checked = currentRow("LockedTrainingMode", DataRowVersion.Original)
            End If
            If currentRow("RolloutDate") <= dtToday Then
                currentNode.ImageKey = currentRow("AreaType").ToString & "R"
            Else
                currentNode.ImageKey = currentRow("AreaType").ToString
            End If
        Else
            currentRow("IsRollout") = 0
            If currentRow.RowState = DataRowState.Added OrElse currentRow("RolloutDate", DataRowVersion.Original).ToString = "" Then
                currentRow("RolloutDate") = DBNull.Value
            End If
            Me.chbLockedTrainingMode.Checked = False
            currentNode.ImageKey = currentRow("AreaType").ToString
        End If
        currentNode.SelectedImageKey = currentNode.ImageKey
        Me.pnlIsRollout.Enabled = Me.chbIsRollout.Checked
        Me.btnSave.Enabled = True
    End Sub

    Private Sub chbIsRollout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbIsRollout.Click
        If blIsReadOnly Then
            frmMain.statusText.Text = "您不能计划该区域上线时间！因为您只有浏览的权限但没有修改的权限（仅系统管理员有修改权限）。"
        End If
    End Sub

    Private Sub lblIsRollout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblIsRollout.Click
        If blIsReadOnly Then
            frmMain.statusText.Text = "您不能计划该区域上线时间！因为您只有浏览的权限但没有修改的权限（仅系统管理员有修改权限）。"
        Else
            Me.chbIsRollout.Checked = Not Me.chbIsRollout.Checked
        End If
    End Sub

    Private Sub dtpRolloutDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpRolloutDate.ValueChanged
        Me.txbRolloutDate.Text = Format(Me.dtpRolloutDate.Value, "yyyy\/MM\/dd")
        If blSkipDeal Then Return
        If cuttedNode IsNot Nothing AndAlso cuttedNode.Equals(currentNode) Then
            Me.SetCuttedState(cuttedNode, False)
            cuttedNode = Nothing
        End If
        currentRow("RolloutDate") = Me.dtpRolloutDate.Value
        If currentRow("RolloutDate") <= dtToday Then
            currentNode.ImageKey = currentRow("AreaType").ToString & "R"
        Else
            currentNode.ImageKey = currentRow("AreaType").ToString
        End If
        currentNode.SelectedImageKey = currentNode.ImageKey
        Me.btnSave.Enabled = True
    End Sub

    Private Sub txbRolloutDate_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbRolloutDate.DoubleClick
        Me.txbRolloutDate.SelectAll()
    End Sub

    Private Sub txbRolloutDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txbRolloutDate.KeyPress
        If blIsReadOnly Then
            e.Handled = True
            frmMain.statusText.Text = "您不能计划该区域上线时间！因为您只有浏览的权限但没有修改的权限（仅系统管理员有修改权限）。"
        End If
    End Sub

    Private Sub chbLockedTrainingMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbLockedTrainingMode.CheckedChanged
        If blSkipDeal Then Return
        If cuttedNode IsNot Nothing AndAlso cuttedNode.Equals(currentNode) Then
            Me.SetCuttedState(cuttedNode, False)
            cuttedNode = Nothing
        End If
        currentRow("LockedTrainingMode") = IIf(Me.chbLockedTrainingMode.Checked, 1, 0)
        Me.btnSave.Enabled = True
    End Sub

    Private Sub chbLockedTrainingMode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbLockedTrainingMode.Click
        If blIsReadOnly Then
            frmMain.statusText.Text = "您不能为该区域锁住或解锁培训模式！因为您只有浏览的权限但没有修改的权限（仅系统管理员有修改权限）。"
        End If
    End Sub

    Private Sub lblLockedTrainingMode1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblLockedTrainingMode1.Click, lblLockedTrainingMode2.Click
        If blIsReadOnly Then
            frmMain.statusText.Text = "您不能为该区域锁住或解锁培训模式！因为您只有浏览的权限但没有修改的权限（仅系统管理员有修改权限）。"
        Else
            Me.chbIsRollout.Checked = Not Me.chbIsRollout.Checked
        End If
    End Sub

    Private Sub txbCULCardBin_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbCULCardBin.DoubleClick
        Me.txbCULCardBin.SelectAll()
    End Sub

    Private Sub txbCULCardBin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbCULCardBin.KeyDown
        If e.KeyCode = Keys.Escape AndAlso Me.txbCULCardBin.Text <> currentRow("CULCardBin").ToString Then Me.txbCULCardBin.Text = currentRow("CULCardBin").ToString : Me.txbCULCardBin.SelectAll() : e.SuppressKeyPress = True : blInnerError = False : Return
        If e.KeyCode = Keys.Enter Then Me.txbCULStoreCode.Select() : Me.txbCULStoreCode.SelectAll() : e.SuppressKeyPress = True : Return
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbCULCardBin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txbCULCardBin.KeyPress
        If blIsReadOnly Then
            My.Computer.Clipboard.Clear()
            e.Handled = True
            frmMain.statusText.Text = "您不能修改银商的卡Bin号！因为您只有浏览的权限但没有修改的权限。"
        End If
    End Sub

    Private Sub txbCULCardBin_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbCULCardBin.Leave
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub txbCULCardBin_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txbCULCardBin.MouseDown
        If blIsReadOnly Then My.Computer.Clipboard.Clear()
    End Sub

    Private Sub txbCULCardBin_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txbCULCardBin.Validating
        blInnerError = False
        If currentRow.RowState = DataRowState.Deleted OrElse currentRow.RowState = DataRowState.Detached Then Return

        If cuttedNode IsNot Nothing AndAlso cuttedNode.Equals(currentNode) AndAlso Me.txbAreaCode.Text <> currentRow("CULCardBin").ToString Then
            Me.SetCuttedState(cuttedNode, False)
            cuttedNode = Nothing
        End If
        Dim sCardBin As String = Me.txbCULCardBin.Text.Trim
        Me.txbCULCardBin.Text = sCardBin
        If sCardBin = "" Then
            If currentRow("CULCardBin").ToString = "" Then
                blInnerError = True
                Me.Activate()
                If blPrompt Then
                    MessageBox.Show("银商的卡Bin号不能为空！请输入银商卡Bin号。    ", "银商的卡Bin号不能为空！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    blPrompt = False
                    Me.promptTimer.Enabled = True
                End If
                Me.txbCULCardBin.SelectAll()
                e.Cancel = True
            Else
                Me.txbCULCardBin.Text = currentRow("CULCardBin").ToString
            End If
        ElseIf sCardBin <> currentRow("CULCardBin").ToString Then
            currentRow("CULCardBin") = sCardBin
            If currentRow.RowState = DataRowState.Modified AndAlso currentRow("AreaCode").ToString = currentRow("AreaCode", DataRowVersion.Original).ToString AndAlso currentRow("CULCardBin").ToString = currentRow("CULCardBin", DataRowVersion.Original).ToString AndAlso currentRow("AreaEnglishName").ToString = currentRow("AreaEnglishName", DataRowVersion.Original).ToString AndAlso currentRow("ParentAreaID").ToString = currentRow("ParentAreaID", DataRowVersion.Original).ToString Then currentRow.AcceptChanges()
            Me.btnSave.Enabled = (dtArea.GetChanges() IsNot Nothing)
        End If
    End Sub

    Private Sub txbCULStoreCode_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbCULStoreCode.DoubleClick
        Me.txbCULStoreCode.SelectAll()
    End Sub

    Private Sub txbCULStoreCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbCULStoreCode.KeyDown
        If e.KeyCode = Keys.Escape AndAlso Me.txbCULStoreCode.Text <> currentRow("CULStoreCode").ToString Then Me.txbCULStoreCode.Text = currentRow("CULStoreCode").ToString : Me.txbCULStoreCode.SelectAll() : e.SuppressKeyPress = True : blInnerError = False : Return
        If e.KeyCode = Keys.Enter Then Me.txbAreaCode.Select() : Me.txbAreaCode.SelectAll() : e.SuppressKeyPress = True : Return
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbCULStoreCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txbCULStoreCode.KeyPress
        If blIsReadOnly Then
            My.Computer.Clipboard.Clear()
            e.Handled = True
            frmMain.statusText.Text = "您不能修改银商的门店编号！因为您只有浏览的权限但没有修改的权限（仅系统管理员有修改权限）。"
        End If
    End Sub

    Private Sub txbCULStoreCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbCULStoreCode.Leave
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub txbCULStoreCode_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txbCULStoreCode.MouseDown
        If blIsReadOnly Then My.Computer.Clipboard.Clear()
    End Sub

    Private Sub txbCULStoreCode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txbCULStoreCode.Validating
        blInnerError = False
        If currentRow.RowState = DataRowState.Deleted OrElse currentRow.RowState = DataRowState.Detached Then Return
        If cuttedNode IsNot Nothing AndAlso cuttedNode.Equals(currentNode) AndAlso Me.txbAreaCode.Text <> currentRow("CULStoreCode").ToString Then
            Me.SetCuttedState(cuttedNode, False)
            cuttedNode = Nothing
        End If
        Dim sCULStoreCode As String = Me.txbCULStoreCode.Text.Trim
        Me.txbCULStoreCode.Text = sCULStoreCode
        If sCULStoreCode = "" Then
            If currentRow("CULStoreCode").ToString = "" Then
                blInnerError = True
                Me.Activate()
                If blPrompt Then
                    MessageBox.Show("银商的门店编号不能为空！请输入银商门店编号。    ", "银商的门店编号不能为空！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    blPrompt = False
                    Me.promptTimer.Enabled = True
                End If
                Me.txbCULStoreCode.SelectAll()
                e.Cancel = True
            Else
                Me.txbCULStoreCode.Text = currentRow("CULStoreCode").ToString
            End If
        ElseIf sCULStoreCode <> currentRow("CULStoreCode").ToString Then
            If dtArea.Select("AreaType='" & currentRow("AreaType").ToString & "' And AreaCode<>'" & Me.txbAreaCode.Text & "' And CULStoreCode='" & sCULStoreCode & "'").Length > 0 Then
                blInnerError = True
                Me.Activate()
                If blPrompt Then
                    MessageBox.Show("银商的门店编号已经存在！请改用另一个编号。    ", "银商的门店编号重复！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    blPrompt = False
                    Me.promptTimer.Enabled = True
                End If
                Me.txbCULStoreCode.SelectAll()
                e.Cancel = True
            Else
                currentRow("CULStoreCode") = sCULStoreCode
                If currentRow.RowState = DataRowState.Modified AndAlso currentRow("AreaCode").ToString = currentRow("AreaCode", DataRowVersion.Original).ToString AndAlso currentRow("CULStoreCode").ToString = currentRow("CULStoreCode", DataRowVersion.Original).ToString AndAlso currentRow("AreaEnglishName").ToString = currentRow("AreaEnglishName", DataRowVersion.Original).ToString AndAlso currentRow("ParentAreaID").ToString = currentRow("ParentAreaID", DataRowVersion.Original).ToString Then currentRow.AcceptChanges()
                Me.btnSave.Enabled = (dtArea.GetChanges() IsNot Nothing)
            End If
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Me.SaveChanges()
    End Sub

    Public Function SaveChanges() As Boolean
        Me.trvArea.Select()

        If Me.txbPreCode.Text = "S" Then
            If Me.txbCULCardBin.Text = "" Then
                Me.txbCULCardBin.Select()
            ElseIf Me.txbCULStoreCode.Text = "" Then
                Me.txbCULStoreCode.Select()
            End If
        End If
        Me.trvArea.Select() '引发最后修改的控件的Valating事件
        If blInnerError Then Return False

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在保存更改……"
        frmMain.statusMain.Refresh()

        Dim DB As New DataBase()
        DB.Open(True)
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法保存更改！请检查数据库连接。"
            Me.Cursor = Cursors.Default
            Return False
        End If

        For Each dr As DataRow In dtArea.Select("", "", DataViewRowState.Deleted)
            If DB.ModifyTable("Delete From AreaList Where AreaID=" & dr("AreaID", DataRowVersion.Original).ToString & " And UserQTY=0") = -1 Then
                DB.Close()
                Me.Activate()
                frmMain.statusText.Text = "保存更改失败！"
                Me.Cursor = Cursors.Default
                Return False
            Else
                DB.ModifyTable("Exec OperationLogInsert " & frmMain.sSSID & ",'Delete Position: " & (dr("AreaChineseName", DataRowVersion.Original).ToString & " " & dr("AreaEnglishName", DataRowVersion.Original).ToString).Trim.Replace("'", "''") & "','Area'," & dr("AreaID", DataRowVersion.Original).ToString)
                dr.AcceptChanges()
            End If
        Next

        Dim sSQL As String = ""
        For Each dr As DataRow In dtArea.Select("", "", DataViewRowState.ModifiedCurrent)
            sSQL = ""
            If dr("AreaCode").ToString <> dr("AreaCode", DataRowVersion.Original).ToString Then sSQL = "AreaCode='" & dr("AreaCode").ToString & "'"
            If dr("AreaChineseName").ToString <> dr("AreaChineseName", DataRowVersion.Original).ToString Then sSQL = IIf(sSQL = "", "", sSQL & ",") & "AreaChineseName='" & dr("AreaChineseName").ToString.Replace("'", "''") & "'"
            If dr("AreaEnglishName").ToString <> dr("AreaEnglishName", DataRowVersion.Original).ToString Then sSQL = IIf(sSQL = "", "", sSQL & ",") & "AreaEnglishName='" & dr("AreaEnglishName").ToString.Replace("'", "''") & "'"
            If dr("ParentAreaID").ToString <> dr("ParentAreaID", DataRowVersion.Original).ToString Then sSQL = IIf(sSQL = "", "", sSQL & ",") & "ParentAreaID=" & dr("ParentAreaID").ToString
            If dr("IsRollout").ToString <> dr("IsRollout", DataRowVersion.Original).ToString Then sSQL = IIf(sSQL = "", "", sSQL & ",") & "IsRollout=" & IIf(dr("IsRollout"), 1, 0).ToString
            If dr("RolloutDate").ToString <> dr("RolloutDate", DataRowVersion.Original).ToString Then
                If dr("RolloutDate").ToString = "" Then
                    sSQL = IIf(sSQL = "", "", sSQL & ",") & "RolloutDate=NULL"
                Else
                    sSQL = IIf(sSQL = "", "", sSQL & ",") & "RolloutDate='" & Format(dr("RolloutDate"), "yyyy\/MM\/dd") & "'"
                End If
            End If
            If dr("LockedTrainingMode").ToString <> dr("LockedTrainingMode", DataRowVersion.Original).ToString Then sSQL = IIf(sSQL = "", "", sSQL & ",") & "LockedTrainingMode=" & IIf(dr("LockedTrainingMode"), 1, 0).ToString
            If dr("CULCardBin").ToString <> dr("CULCardBin", DataRowVersion.Original).ToString Then sSQL = IIf(sSQL = "", "", sSQL & ",") & "CULCardBin='" & dr("CULCardBin").ToString & "'"
            If dr("CULStoreCode").ToString <> dr("CULStoreCode", DataRowVersion.Original).ToString Then sSQL = IIf(sSQL = "", "", sSQL & ",") & "CULStoreCode='" & dr("CULStoreCode").ToString & "'"
            If sSQL <> "" Then
                sSQL = "Update AreaList Set " & sSQL & " Where AreaID=" & dr("AreaID").ToString
                If DB.ModifyTable(sSQL) = -1 Then
                    DB.Close()
                    Me.Activate()
                    frmMain.statusText.Text = "保存更改失败！"
                    frmMain.Cursor = Cursors.Default
                    Return False
                Else
                    DB.ModifyTable("Exec OperationLogInsert " & frmMain.sSSID & ",'Update Position: " & (dr("AreaChineseName").ToString & " " & dr("AreaEnglishName").ToString).Trim.Replace("'", "''") & "','Area'," & dr("AreaID").ToString)
                    dr.AcceptChanges()
                End If
            End If
        Next

        For Each dr As DataRow In dtArea.Select("", "", DataViewRowState.Added)
            sSQL = "Insert Into AreaList Values (" & dr("AreaID").ToString & ",'" & dr("AreaType").ToString & "','" & dr("AreaCode").ToString & "','" & dr("AreaChineseName").ToString.Replace("'", "''") & "','" & dr("AreaEnglishName").ToString.Replace("'", "''") & "'," & dr("ParentAreaID").ToString & "," & IIf(dr("IsRollout"), 1, 0).ToString
            If dr("RolloutDate").ToString = "" Then
                sSQL = sSQL & ",NULL," & IIf(dr("LockedTrainingMode"), 1, 0).ToString & ",0," & IIf(dr("AreaType").ToString = "S", "'" & dr("CULCardBin").ToString & "',", "NULL,") & IIf(dr("AreaType").ToString = "S", "'" & dr("CULStoreCode").ToString & "'", "NULL") & ",0,0)"
            Else
                sSQL = sSQL & ",'" & Format(dr("RolloutDate"), "yyyy\/MM\/dd") & "'," & IIf(dr("LockedTrainingMode"), 1, 0).ToString & ",0," & IIf(dr("AreaType").ToString = "S", "'" & dr("CULCardBin").ToString & "',", "NULL,") & IIf(dr("AreaType").ToString = "S", "'" & dr("CULStoreCode").ToString & "'", "NULL") & ",0,0)"
            End If
            If DB.ModifyTable(sSQL) = -1 Then
                DB.Close()
                Me.Activate()
                frmMain.statusText.Text = "保存更改失败！"
                frmMain.Cursor = Cursors.Default
                Return False
            Else
                DB.ModifyTable("Exec OperationLogInsert " & frmMain.sSSID & ",'Create Position: " & (dr("AreaChineseName").ToString & " " & dr("AreaEnglishName").ToString).Trim.Replace("'", "''") & "','Area'," & dr("AreaID").ToString)
                dr.AcceptChanges()
            End If
        Next

        dtArea.AcceptChanges()
        frmMain.statusText.Text = "就绪。"
        Me.btnSave.Enabled = False
        Me.Cursor = Cursors.Default
        Return True
    End Function
End Class