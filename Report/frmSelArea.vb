Public Class frmSelArea
    Private blSkipDeal As Boolean = False, blIsReadOnly As Boolean = False, blInnerError As Boolean = False, blPrompt As Boolean = True, dtArea As DataTable, currentRow As DataRow, currentNode As TreeNode = Nothing, cuttedNode As TreeNode = Nothing, dtToday As Date
    Public fs_showlevel = "All"


    Private Sub frmSelArea_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DB As New DataBaseReport()
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打开窗口。请检查数据库连接。"
            Me.Close() : Return
        End If

        dtArea = DB.GetDataTable("Select *, Convert(datetime,Convert(varchar(10),Getdate())) As Today From AreaList Order By AreaCode")
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
        Me.trvArea.Nodes.Clear()
        Me.InitArea(Me.trvArea.Nodes, frmMain.dtLoginStructure.Rows(0)("ParentAreaID").ToString)

        currentNode = Me.trvArea.Nodes(0)
        Me.trvArea.ExpandAll()
        Me.trvArea.SelectedNode = currentNode
        Me.trvArea.Select()

    End Sub
    Private Sub InitArea(ByVal tncCurrent As TreeNodeCollection, ByVal sParentID As String)
        Try
            Dim newNode As TreeNode
            Dim drRows() As DataRow
            If fs_showlevel = "All" Then
                drRows = frmMain.dtLoginStructure.Select("ParentAreaID=" & sParentID, "SortCode")
            Else
                drRows = frmMain.dtLoginStructure.Select("ParentAreaID=" & sParentID & " and areatype <> 'S'", "SortCode")
            End If

            For Each dr As DataRow In drRows
                newNode = New TreeNode
                newNode.Name = dr("AreaID").ToString
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

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

    End Sub
End Class