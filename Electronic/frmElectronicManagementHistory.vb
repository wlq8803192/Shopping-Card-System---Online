Public Class frmElectronicManagementHistory

    Private selectRow As Integer

    Private Sub initDataGridView()
        With Me.dgvElectronic
            .AutoGenerateColumns = False
            .ColumnCount = 9
            With .Columns(0)
                .Name = "EType"
                .HeaderText = "申请类型"
                .Width = 70
                '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
                .DataPropertyName = "EType"
            End With
            With .Columns(1)
                .Name = "OrderNo"
                .HeaderText = "订单号"
                .Width = 85
                '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
                .DataPropertyName = "OrderNo"
            End With
            With .Columns(2)
                .Name = "CardQTY"
                .HeaderText = "总数量"
                .Width = 55
                '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
                .DataPropertyName = "CardQTY"
            End With
            With .Columns(3)
                .Name = "Amount"
                .HeaderText = "总金额"
                .Width = 75
                '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
                .DataPropertyName = "Amount"
                .DefaultCellStyle.Format = "#,0.00"
            End With
            With .Columns(4)
                .Name = "CreatorTime"
                .HeaderText = "申请时间"
                .Width = 125
                '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
                .DataPropertyName = "CreatorTime"
                .DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss"
            End With
            With .Columns(5)
                .Name = "AreaName"
                .HeaderText = "申请门店"
                .Width = 75
                '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
                .DataPropertyName = "AreaName"
            End With
            With .Columns(6)
                .Name = "CreatorName"
                .HeaderText = "申请人"
                .Width = 60
                '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
                .DataPropertyName = "CreatorName"
            End With
            With .Columns(7)
                .Name = "EValue"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .Visible = False
                .DataPropertyName = "EValue"
            End With
            With .Columns(8)
                .Name = "Status"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .Visible = False
                .DataPropertyName = "Status"
            End With
            Dim newColumn As DataGridViewButtonColumn

            newColumn = New DataGridViewButtonColumn
            newColumn.Name = ""
            newColumn.UseColumnTextForButtonValue = True
            newColumn.Text = "查看明细"
            newColumn.Width = 75
            .Columns.Add(newColumn)

            newColumn = New DataGridViewButtonColumn
            newColumn.Name = ""
            newColumn.UseColumnTextForButtonValue = True
            newColumn.Text = "查看销售单"
            newColumn.Width = 80
            .Columns.Add(newColumn)
        End With
    End Sub

    Private Sub frmElectronicManagementHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.dgvElectronic.DataSource = Nothing
        initDataGridView()
    End Sub

    Private Sub dgvElectronic_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvElectronic.CellContentClick
        If e.RowIndex > -1 Then
            selectRow = dgvElectronic.CurrentRow.Index
            Dim eType As String = dgvElectronic.Rows(selectRow).Cells("EValue").Value.ToString() '申请类型
            Dim orderNo As String = dgvElectronic.Rows(selectRow).Cells("OrderNo").Value.ToString() '订单号
            Dim status As String = dgvElectronic.Rows(selectRow).Cells("Status").Value.ToString() '状态

            Select Case e.ColumnIndex
                Case 9
                    genericCardList(eType, orderNo) '查看卡号明细
                Case 10
                    genericSalesDetails(eType, orderNo) '查看销售单
            End Select
        End If
    End Sub

    Private Sub genericCardList(ByVal eType As String, ByVal orderNo As String)

        If eType = "1" Then
            frmCardForMobile.sOrderNo = orderNo
            frmCardForMobile.sEType = eType
            frmCardForMobile.ShowDialog()
        End If

        If eType = "2" Then
            frmCardForEmail.sOrderNo = orderNo
            frmCardForEmail.sEType = eType
            frmCardForEmail.ShowDialog()
        End If

    End Sub

    Private Sub genericSalesDetails(ByVal eType As String, ByVal orderNo As String)
        Dim DB As New DataBase, sSQL As String = ""

        Me.Cursor = Cursors.WaitCursor
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法进行查询。请检查数据库连接。"
            Me.Cursor = Cursors.Default
            Return
        End If

        sSQL = "select SalesBillID from Electronic where OrderNo = '" & orderNo & "'"
        Dim dtResult As DataTable = DB.GetDataTable(sSQL)
        If dtResult.Rows.Count = 0 Then
            MessageBox.Show("查找不到销售单数据！    ", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            If frmSelling.IsHandleCreated Then
                frmSelling.Activate()
                frmSelling.WindowState = FormWindowState.Maximized
                If frmSelling.blIsChanged Then
                    Dim bAnswer As DialogResult = MessageBox.Show("是否在打开销售单之前，先保存当前销售单？    ", "当前销售单未保存！", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                    If bAnswer = Windows.Forms.DialogResult.Cancel OrElse (bAnswer = Windows.Forms.DialogResult.Yes AndAlso Not frmSelling.SaveChanges()) Then
                        Me.Activate()
                        frmMain.statusText.Text = "因为存在未保存销售单，所以不能打开销售单。"
                        Return
                    End If
                End If

                frmSelling.bNewSalesBillType = 9
                frmSelling.sSalesBillID = dtResult.Rows(0)(0).ToString
                frmSelling.LoadSalesBill()
            Else
                Me.Cursor = Cursors.WaitCursor
                frmMain.statusText.Text = "正在打开销售单……"
                frmMain.statusMain.Refresh()

                frmSelling.Text = "查看销售单"
                frmSelling.bNewSalesBillType = 9
                frmSelling.sSalesBillID = dtResult.Rows(0)(0).ToString
                frmSelling.Show()
                If frmSelling.IsHandleCreated Then
                    frmSelling.MdiParent = frmMain
                    frmSelling.WindowState = FormWindowState.Maximized
                    frmSelling.Activate()
                    frmSelling.btnModifyPaymentInfo.Visible = False
                End If

                If frmMain.statusText.Text.IndexOf("……") > -1 Then frmMain.statusText.Text = "就绪。"
                Me.Cursor = Cursors.Default
            End If

            If frmSelling.IsHandleCreated Then
                If frmSelling.dgvNormalCard.CurrentRow IsNot Nothing Then frmSelling.dgvNormalCard.CurrentRow.Selected = False
                If frmSelling.dgvRebateCard.CurrentRow IsNot Nothing Then frmSelling.dgvRebateCard.CurrentRow.Selected = False
                If frmSelling.dgvPayment.CurrentRow IsNot Nothing Then frmSelling.dgvPayment.CurrentRow.Selected = False
            End If

            dtResult.Dispose()
            dtResult = Nothing
        End If

        Me.Cursor = Cursors.Default
        Me.Close()
        DB.Close()
    End Sub

    Private Sub btnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        Dim DB As New DataBase, sSQL As String = ""

        Me.Cursor = Cursors.WaitCursor
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法进行查询。请检查数据库连接。"
            Me.Cursor = Cursors.Default
            Return
        End If

        Dim sMobile As String = Me.txtMobile.Text.Trim(), sEmailNo As String = Me.txtEmailNo.Text.Trim(), sOrderNo As String = Me.txtOrderNo.Text.Trim()

        '验证手机号码
        If sMobile = "" Then
            'MessageBox.Show("手机号为空！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'Return
        Else
            '类型验证
            If Not IsNumeric(sMobile) Then
                MessageBox.Show("手机号错误！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            '长度验证
            If sMobile.Length <> 11 Then
                MessageBox.Show("手机号位数错误！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If

        '查询数据库
        Dim sFilter As String = String.Empty
        If sMobile <> "" Then
            sFilter += " and (T1.TelePhone = '" & sMobile & "' or T2.TelePhone = '" & sMobile & "')"
        End If
        If sEmailNo <> "" Then
            sFilter += " and T1.EmailNo = '" & sEmailNo & "'"
        End If
        If sOrderNo <> "" Then
            sFilter += " and T1.OrderNo = '" & sOrderNo & "'"
        End If
        If frmMain.sLoginAreaType = "S" Then
            sFilter += " and T1.CreatorID = '" & frmMain.sLoginUserID & "'"
        ElseIf frmMain.sLoginAreaType = "C" Then
            sFilter += " and T1.CreatorID in (select UserID from UserList where AreaID in (select AreaID from AreaList where ParentAreaID = '" & frmMain.sLoginAreaID & "'))"
        End If

        sSQL += "select distinct case T1.EType when 1 then '手机申请' when 2 then '邮箱申请' when 3 then '手机实时下单' when 4 then '邮箱实时下单' else '' end as EType,EType as EValue,T1.OrderNo,T1.CardQTY,T1.Amount,T1.CreatorTime,T3.AreaChineseName as AreaName,CreatorName,T1.Status from Electronic T1 "
        sSQL += "left join ElectronicDetails T2 on T1.EID = T2.EID "
        sSQL += "left join AreaList T3 on T1.StoreID = T3.AreaID "
        sSQL += "where 1=1 {0}"
        sSQL += "and T1.Status = 3 "
        sSQL += "order by T1.CreatorTime desc "
        Dim dtResult As DataTable = DB.GetDataTable(String.Format(sSQL, sFilter))
        If dtResult.Rows.Count = 0 Then
            MessageBox.Show("查找不到数据！    ", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Me.dgvElectronic.DataSource = dtResult
            DB.Close()
            dtResult.Dispose()
            dtResult = Nothing
        End If

        Me.Cursor = Cursors.Default
    End Sub
End Class