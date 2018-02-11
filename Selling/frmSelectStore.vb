Public Class frmSelectStore

    Public sCityID As String = "" '选择员工购卡门店时使用

    Private Sub frmSelectStore_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dvStore As DataView = frmMain.dtLoginStructure.Copy.DefaultView
        If sCityID = "" Then
            dvStore.RowFilter = "AreaType='S'"
        Else
            dvStore.RowFilter = "ParentAreaID=" & sCityID
        End If
        dvStore.Sort = "SortCode"
        dvStore = dvStore.ToTable(False, "AreaID", "AreaName").DefaultView
        With Me.cbbStore
            .DataSource = dvStore
            .ValueMember = "AreaID"
            .DisplayMember = "AreaName"
            .SelectedIndex = 0
        End With
    End Sub
End Class