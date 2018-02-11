Public Class frmElectronicManagement

    Private selectRow As Integer

    Private Sub initDataGridView()
        With Me.dgvElectronic
            .AutoGenerateColumns = False
            .ColumnCount = 9
            With .Columns(0)
                .Name = "EType"
                .HeaderText = "申请类型"
                .Width = 80
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
                .Width = 100
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
                .Width = 70
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
                .Width = 80
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
                .Width = 127
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
                .Width = 80
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
                .Width = 80
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
            newColumn.Width = 80
            .Columns.Add(newColumn)

            newColumn = New DataGridViewButtonColumn
            newColumn.Name = ""
            newColumn.UseColumnTextForButtonValue = True
            newColumn.Text = "生成销售单"
            newColumn.Width = 80
            .Columns.Add(newColumn)

            newColumn = New DataGridViewButtonColumn
            newColumn.Name = ""
            newColumn.UseColumnTextForButtonValue = True
            newColumn.Text = "删除"
            newColumn.Width = 50
            .Columns.Add(newColumn)
        End With
    End Sub

    Private Sub frmElectronicManagement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.dgvElectronic.DataSource = Nothing
        initDataGridView()
        Me.txtMobile.Select()
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
                    genericSalesBillList(eType, orderNo, status) '生成销售单
                Case 11
                    genericSalesBillDelete(eType, orderNo, status) '删除电子卡申请
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

    Private Sub genericSalesBillList(ByVal eType As String, ByVal orderNo As String, ByVal status As String)

        If status = "2" Then
            Dim DB As New DataBase, sSQL As String = "", dtDatas As New DataTable
            Me.Cursor = Cursors.WaitCursor
            DB.Open()
            If Not DB.IsConnected Then
                frmMain.statusText.Text = "系统因连接不到数据库而无法进行查询。请检查数据库连接。"
                Me.Cursor = Cursors.Default
                Return
            End If
            dtDatas = DB.GetDataTable("select TID,StartCardNo,EndCardNo,TelePhone,FaceValue,CardQTY from ElectronicDetails where EID in (select EID from Electronic where OrderNo = '" + orderNo + "' and EType = '" + eType + "')")
            DB.Close()

            Dim dtImportedDetails As New DataTable, drDetail As DataRow
            dtImportedDetails.Columns.Add("SalesBillID", System.Type.GetType("System.Int32"))
            dtImportedDetails.Columns.Add("RowID", System.Type.GetType("System.Int16"))
            dtImportedDetails.Columns.Add("ErrorColumn", System.Type.GetType("System.Byte"))
            dtImportedDetails.Columns.Add("CityName", System.Type.GetType("System.String"))
            dtImportedDetails.Columns.Add("CardNo", System.Type.GetType("System.String"))
            dtImportedDetails.Columns.Add("StartCardNo", System.Type.GetType("System.String"))
            dtImportedDetails.Columns.Add("EndCardNo", System.Type.GetType("System.String"))
            dtImportedDetails.Columns.Add("CardQTY", System.Type.GetType("System.String"))
            dtImportedDetails.Columns.Add("FaceValue", System.Type.GetType("System.String"))
            dtImportedDetails.Columns.Add("SalesDate", System.Type.GetType("System.String"))
            dtImportedDetails.Columns.Add("Remarks", System.Type.GetType("System.String"))
            dtImportedDetails.Columns.Add("ImportedState", System.Type.GetType("System.String"))
            dtImportedDetails.Columns.Add("StateReason", System.Type.GetType("System.String"))
            dtImportedDetails.Columns.Add("CardCost", System.Type.GetType("System.String"))
            dtImportedDetails.Columns.Add("HolderName", System.Type.GetType("System.String"))
            dtImportedDetails.Columns.Add("Gender", System.Type.GetType("System.String"))
            dtImportedDetails.Columns.Add("HolderIdNo", System.Type.GetType("System.String"))
            dtImportedDetails.Columns.Add("Mobile", System.Type.GetType("System.String"))

            If Not dtDatas Is Nothing Then
                If dtDatas.Rows.Count = 0 Then
                    MessageBox.Show("查找不到数据！    ", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Dim iRows As Integer = dtDatas.Rows.Count, iRowID As Int16 = 0
                    For iRow As Integer = 0 To iRows - 1
                        iRowID += 1
                        drDetail = dtImportedDetails.Rows.Add
                        drDetail("RowID") = iRowID
                        drDetail("CityName") = frmMain.statusAreaName.Text
                        drDetail("CardNo") = dtDatas.Rows(iRow)("StartCardNo")
                        drDetail("StartCardNo") = dtDatas.Rows(iRow)("StartCardNo")
                        drDetail("EndCardNo") = dtDatas.Rows(iRow)("EndCardNo")
                        drDetail("CardQTY") = dtDatas.Rows(iRow)("CardQTY")
                        drDetail("FaceValue") = dtDatas.Rows(iRow)("FaceValue")
                        drDetail("SalesDate") = Date.Now.ToString("yyyy\/MM\/dd")
                        drDetail("ImportedState") = "已导入"
                    Next
                End If
            End If
            dtImportedDetails.AcceptChanges()

            If frmSelling.IsHandleCreated Then
                frmSelling.Activate()
                frmSelling.WindowState = FormWindowState.Maximized
                If frmSelling.blIsChanged Then
                    Dim bAnswer As DialogResult = MessageBox.Show("是否在新建销售单之前，先保存当前销售单？    ", "当前销售单未保存！", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                    If bAnswer = Windows.Forms.DialogResult.Cancel OrElse (bAnswer = Windows.Forms.DialogResult.Yes AndAlso Not frmSelling.SaveChanges()) Then
                        Me.Activate()
                        frmMain.statusText.Text = "因为存在未保存销售单，所以不能新建销售单。"
                        Return
                    End If
                End If

                frmSelling.sOrderNo = orderNo
                frmSelling.cbbSalesBillType.Items(0) = "电子卡销售单"
                frmSelling.txbSalesBillType.Text = "电子卡销售单"
                frmSelling.sSalesBillID = "-1"
                frmSelling.sCustomerID = ""
                frmSelling.bNewSalesBillType = 9
                frmSelling.blUsedOldCard = False
                frmSelling.ReCreateSalesBill()

            Else
                Me.Cursor = Cursors.WaitCursor
                frmMain.statusText.Text = "正在打开销售单窗口……"
                frmMain.statusMain.Refresh()

                frmSelling.sOrderNo = orderNo
                frmSelling.cbbSalesBillType.Items(0) = "电子卡销售单"
                frmSelling.txbSalesBillType.Text = "电子卡销售单"
                frmSelling.bNewSalesBillType = 9
                frmSelling.blUsedOldCard = False
                frmSelling.Show()
                If frmSelling.IsHandleCreated Then
                    frmSelling.MdiParent = frmMain
                    frmSelling.WindowState = FormWindowState.Maximized
                    frmSelling.Activate()
                End If

                If frmMain.statusText.Text.IndexOf("……") > -1 Then frmMain.statusText.Text = "就绪。"
                Me.Cursor = Cursors.Default
            End If

            If frmSelling.IsHandleCreated Then
                Dim dtImportedFile As New DataTable, drImportedFile As DataRow
                With dtImportedFile.Columns
                    .Add("SalesBillID", System.Type.GetType("System.Int32"))
                    .Add("SourceComputer", System.Type.GetType("System.String"))
                    .Add("SourceFile", System.Type.GetType("System.String"))
                    .Add("WorkSheet", System.Type.GetType("System.String"))
                    .Add("FileSize", System.Type.GetType("System.Int32"))
                    .Add("FileModifiedTime", System.Type.GetType("System.DateTime"))
                    .Add("CardQTY", System.Type.GetType("System.Int32"))
                    .Add("ChargedAMT", System.Type.GetType("System.Decimal"))
                End With
                drImportedFile = dtImportedFile.Copy.Rows.Add
                dtImportedFile.Dispose() : dtImportedFile = Nothing
                drImportedFile("SourceFile") = "Null"
                drImportedFile("WorkSheet") = "Null"
                drImportedFile("FileSize") = 0

                Dim iCardQTY As Integer = 0, dmChargedAMT As Decimal = 0
                For Each dr As DataRow In dtImportedDetails.Select("ImportedState='已导入'")
                    iCardQTY += 1
                    dmChargedAMT += CDec(dr("FaceValue"))
                Next
                drImportedFile("CardQTY") = iCardQTY
                drImportedFile("ChargedAMT") = dmChargedAMT
                drImportedFile.AcceptChanges()

                With frmSelling
                    .resetCardCostColumn(False)
                    .drImportedFile = drImportedFile
                    .dtImportedDetails = dtImportedDetails.Copy
                    .UpdateInterFaceWhenElectronic()
                End With
                drImportedFile = Nothing

                If frmSelling.dgvNormalCard.CurrentRow IsNot Nothing Then frmSelling.dgvNormalCard.CurrentRow.Selected = False
                If frmSelling.dgvRebateCard.CurrentRow IsNot Nothing Then frmSelling.dgvRebateCard.CurrentRow.Selected = False
                If frmSelling.dgvPayment.CurrentRow IsNot Nothing Then frmSelling.dgvPayment.CurrentRow.Selected = False
            End If

            dtImportedDetails.Dispose() : dtImportedDetails = Nothing
        Else
            MessageBox.Show("银商系统未返回卡号，不能创建电子卡销售单！    ", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Default
        Me.Dispose()
    End Sub

    Private Sub genericSalesBillDelete(ByVal eType As String, ByVal orderNo As String, ByVal status As String)

        If status <> "2" Then
            MessageBox.Show("该条申请记录不可删除，CUL还未返回卡号或已生成销售单！", "删除提示！", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
            Return
        End If

        Dim dResult As DialogResult = MessageBox.Show("是否删除该条电子卡申请记录？ ", "删除提示！", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
        If dResult = Windows.Forms.DialogResult.OK Then
            Dim DB As New DataBase, sSQL As String = "", iResult As Integer
            Me.Cursor = Cursors.WaitCursor
            DB.Open()
            If Not DB.IsConnected Then
                frmMain.statusText.Text = "系统因连接不到数据库而无法进行查询。请检查数据库连接。"
                Me.Cursor = Cursors.Default
                Return
            End If

            sSQL += "delete Electronic where OrderNo = '" & orderNo & "' and EType = '" & eType & "';"
            sSQL += "delete ElectronicDetails where EID in (select EID from Electronic where OrderNo = '" & orderNo & "' and EType = '" & eType & "');"
            iResult = DB.ModifyTable(sSQL)
            DB.Close()
            MessageBox.Show("电子卡申请记录删除成功！", "删除提示！", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

            Me.Query()
        End If
    End Sub

    Private Sub btnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuery.Click

        Me.Query()
    End Sub

    Private Sub BtnHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHistory.Click
        frmElectronicManagementHistory.ShowDialog()
    End Sub

    Private Sub Query()
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

        sSQL += "select distinct case T1.EType when 1 then '手机申请' when 2 then '邮箱申请' else '' end as EType,EType as EValue,T1.OrderNo,T1.CardQTY,T1.Amount,T1.CreatorTime,T3.AreaChineseName as AreaName,CreatorName,T1.Status from Electronic T1 "
        sSQL += "left join ElectronicDetails T2 on T1.EID = T2.EID "
        sSQL += "left join AreaList T3 on T1.StoreID = T3.AreaID "
        sSQL += "where 1=1 {0}"
        sSQL += "and (T1.Status is null or T1.Status <> 3) "
        sSQL += "order by T1.CreatorTime desc "
        Dim dtResult As DataTable = DB.GetDataTable(String.Format(sSQL, sFilter))
        If dtResult.Rows.Count = 0 Then
            MessageBox.Show("查找不到数据！    ", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.dgvElectronic.DataSource = Nothing
        Else
            Me.dgvElectronic.DataSource = dtResult
            dtResult.Dispose()
            dtResult = Nothing
        End If

        DB.Close()
        Me.Cursor = Cursors.Default
    End Sub
End Class