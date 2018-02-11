Public Class frmSignCardRegisterHistory
    Private Sub frmSignCardRegisterHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me.dgvHistory
            .AutoGenerateColumns = False
            .ColumnCount = 12
            With .Columns(0)
                .HeaderText = "旧卡号"
                .Width = 130
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
                .DataPropertyName = "CardNo"
            End With
            With .Columns(1)
                .HeaderText = "新卡号"
                .Width = 130
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
                .DataPropertyName = "NewCardNo"
            End With
            With .Columns(2)
                .HeaderText = "操作员ID"
                .Width = 80
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
                .DataPropertyName = "OperatorID"
            End With
            With .Columns(3)
                .HeaderText = "操作员姓名"
                .Width = 75
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
                .DataPropertyName = "OperatorName"
            End With
            With .Columns(4)
                .HeaderText = "操作计算机名"
                .Width = 85
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
                .DataPropertyName = "ComputerName"
            End With
            With .Columns(5)
                .HeaderText = "操作计算机IP"
                .Width = 90
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
                .DataPropertyName = "ComputerIP"
            End With
            With .Columns(6)
                .HeaderText = "操作计算机MAC"
                .Width = 100
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
                .DataPropertyName = "ComputerMAC"
            End With
            With .Columns(7)
                .HeaderText = "操作时间"
                .Width = 120
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
                .DataPropertyName = "OperationTime"
                .DefaultCellStyle.Format = "yyyy\/MM\/dd HH:mm:ss"
            End With
            With .Columns(8)
                .HeaderText = "身份证"
                .Width = 130
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
                .DataPropertyName = "HolderIdNo"
            End With
            With .Columns(9)
                .HeaderText = "姓名"
                .Width = 70
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
                .DataPropertyName = "HolderName"
            End With
            With .Columns(10)
                .HeaderText = "性别"
                .Width = 40
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
                .DataPropertyName = "Gender"
            End With
            With .Columns(11)
                .HeaderText = "手机"
                .Width = 80
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
                .DataPropertyName = "Mobile"
            End With
        End With

        showAllHistory()
    End Sub

    Private Sub showAllHistory()
        Dim DB As New DataBase
        Dim dtResult As DataTable
        Dim strsql As String

        Me.Cursor = Cursors.WaitCursor
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法进行查询。请检查数据库连接。"
            Me.Cursor = Cursors.Default
            Return
        End If

        strsql = "SELECT H.* FROM CULNewSignCardReplace AS H WITH (READPAST) INNER JOIN UserList AS U WITH (READPAST) ON H.OperatorID = U.UserID INNER JOIN AreaScope(" & frmMain.sLoginUserID & ") AS S On U.AreaID = S.AreaID order by H.OperationTime desc"

        dtResult = DB.GetDataTable(strsql)

        Me.dgvHistory.DataSource = dtResult
        DB.Close()
        dtResult.Dispose()
        dtResult = Nothing
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

    End Sub
End Class