Public Class frmDropDownArea

    Public mainControl As Control, blSkipDeal As Boolean = False

    Private Sub frmDropDownArea_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If mainControl Is Nothing OrElse Me.trvArea.Nodes.Count = 0 Then Return

        Dim sAreaCode As String = mainControl.Text
        If sAreaCode.IndexOf(" ") = 4 Then  sAreaCode = sAreaCode.Substring(0, sAreaCode.IndexOf(" "))

        Dim selectedNodes() As TreeNode = Me.trvArea.Nodes.Find(sAreaCode, True)
        If selectedNodes.Length = 0 Then
            Me.trvArea.SelectedNode = Nothing
            Me.trvArea.Nodes(0).EnsureVisible()
        Else
            blSkipDeal = True
            Me.trvArea.SelectedNode = selectedNodes(0)
            selectedNodes(0).EnsureVisible()
            blSkipDeal = False
        End If
        selectedNodes = Nothing
    End Sub

    Private Sub frmDropDownArea_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim startPoint As Point = mainControl.PointToScreen(New Point(0, 0)), iRows As Int16 = 0
        If frmMain.dtLoginStructure IsNot Nothing Then iRows = frmMain.dtLoginStructure.Rows.Count
        Dim iHeight As Int16 = iRows * 18 + 2, iUpHeight = startPoint.Y, iDownHeight As Int16 = My.Computer.Screen.WorkingArea.Height - startPoint.Y - mainControl.Height
        Dim iTop As Int16 = startPoint.Y + mainControl.Height
        If iHeight > iDownHeight Then
            If iUpHeight > iDownHeight Then
                iHeight = iUpHeight
                iTop = startPoint.Y - iHeight
            Else
                iHeight = iDownHeight
            End If
        End If
        Me.Size = New Size(IIf(mainControl.Width < 154, 154, mainControl.Width), iHeight)
        Me.Location = New Point(startPoint.X, iTop)

        If iRows > 0 Then
            Dim startRow As DataRow = frmMain.dtLoginStructure.Select("AreaID=" & frmMain.sLoginAreaID)(0)
            Me.InitArea(Me.trvArea.Nodes, startRow("ParentAreaID").ToString)
            Me.trvArea.ExpandAll()
            startRow = Nothing
        End If
        Me.OnActivated(e)
    End Sub

    Private Sub frmDropDownArea_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        mainControl.FindForm.Select()
    End Sub

    Private Sub trvArea_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvArea.AfterSelect
        If blSkipDeal Then Return
        If e.Action = TreeViewAction.ByKeyboard Or e.Action = TreeViewAction.ByMouse Then
            mainControl.Text = Me.trvArea.SelectedNode.Text
            Me.theTimer.Enabled = True
        Else
            Me.trvArea.SelectedNode = Nothing
        End If
    End Sub

    Private Sub trvArea_BeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles trvArea.BeforeSelect
        If Me.trvArea.SelectedNode IsNot Nothing Then
            Me.trvArea.SelectedNode.BackColor = System.Drawing.SystemColors.Window
            Me.trvArea.SelectedNode.ForeColor = System.Drawing.SystemColors.WindowText
        End If
    End Sub

    Private Sub trvArea_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles trvArea.Click
        Dim clickedNode As TreeNode = Me.trvArea.GetNodeAt(Me.trvArea.PointToClient(Control.MousePosition))
        If clickedNode IsNot Nothing AndAlso clickedNode.Equals(Me.trvArea.SelectedNode) Then Me.theTimer.Enabled = True
        clickedNode = Nothing : mainControl.Tag = Nothing
    End Sub

    Private Sub trvArea_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles trvArea.LostFocus
        If Me.trvArea.SelectedNode IsNot Nothing Then
            Me.trvArea.SelectedNode.BackColor = System.Drawing.SystemColors.Highlight
            Me.trvArea.SelectedNode.ForeColor = System.Drawing.SystemColors.HighlightText
        End If
        Dim clickedControl As Control = mainControl.Parent.GetChildAtPoint(mainControl.Parent.PointToClient(Control.MousePosition))
        If clickedControl Is Nothing OrElse clickedControl.Name <> mainControl.Name Then
            Me.Visible = False
            clickedControl = Nothing
        End If
    End Sub

    Private Sub trvArea_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles trvArea.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim clickedNode As TreeNode = Me.trvArea.GetNodeAt(Me.trvArea.PointToClient(Control.MousePosition))
            If clickedNode IsNot Nothing Then
                clickedNode.BackColor = System.Drawing.SystemColors.Highlight
                clickedNode.ForeColor = System.Drawing.SystemColors.HighlightText
            End If
            clickedNode = Nothing : mainControl.Tag = Nothing
        End If
    End Sub

    Private Sub theTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles theTimer.Tick
        Me.theTimer.Enabled = False
        Me.Hide()
        mainControl.FindForm.Select()
        mainControl.Select()
    End Sub

    Private Sub InitArea(ByVal tncCurrent As TreeNodeCollection, ByVal sParentID As String)
        Try
            Dim newNode As TreeNode
            Dim drRows() As DataRow = frmMain.dtLoginStructure.Select("ParentAreaID=" & sParentID, "SortCode")

            For Each dr As DataRow In drRows
                newNode = New TreeNode
                newNode.Name = dr("AreaCode").ToString
                newNode.Text = dr("AreaFullName").ToString
                newNode.ImageKey = dr("AreaType").ToString
                newNode.SelectedImageKey = dr("AreaType").ToString
                tncCurrent.Add(newNode)
                sParentID = dr("AreaID").ToString
                Me.InitArea(tncCurrent(tncCurrent.Count - 1).Nodes, sParentID)
            Next
        Catch
            MessageBox.Show("初始化分类结构树时失败！", "初始化分类结构树时失败！")
        End Try
    End Sub
End Class