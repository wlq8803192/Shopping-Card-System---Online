Public Class frmECancelChargeValidation

    'modify code 084:
    'date;2017/11/8
    'auther:Qipeng
    'remark:电子卡退卡确认中,添加查看历史记录的按钮

    Dim dtList As DataTable
    Private dvCULParameter As DataView
    Dim guIDClass As C4ShoppingCardService.GuIDClass

    Private Sub frmECancelChargeValidation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dvCULParameter = frmMain.dtLoginStructure.Copy.DefaultView
        dvCULParameter.RowFilter = "AreaType='S'"
        dvCULParameter = dvCULParameter.ToTable(False, "AreaID", "CULCardBin", "CULStoreCode").DefaultView
        dvCULParameter.RowFilter = "CULCardBin Like '%|%'"
        For Each drCUL As DataRowView In dvCULParameter
            Dim saCardBins() As String = drCUL("CULCardBin").ToString.Split("|")
            For bIndex As Byte = 0 To saCardBins.Length - 1
                dvCULParameter.Table.Rows.Add(drCUL("AreaID"), saCardBins(bIndex), drCUL("CULStoreCode")).EndEdit()
            Next
        Next
        For Each drCUL As DataRow In dvCULParameter.Table.Select("CULCardBin Like '84%'")
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "60" & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "86" & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "92" & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), frmMain.signCardBin & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
        Next

        'Dim DB As New DataBase(), dtResult As DataTable = Nothing
        'DB.Open()
        'If DB.IsConnected Then
        '    dtResult = DB.GetDataTable("select t1.ExtraCardBin,t2.AreaID,isnull(t2.CULStoreCode,0) CULStoreCode from CityExtraCardBin_ELC T1 left join (SELECT S.AreaID,  A.ParentAreaID, A.CULStoreCode FROM AreaScope(" & frmMain.sLoginUserID & ") AS S INNER JOIN AreaList AS A ON S.AreaID = A.AreaID) T2 on t1.CityID = t2.ParentAreaID where T2.AreaID is not null")
        '    If dtResult Is Nothing Then
        '    ElseIf dtResult.Rows.Count > 0 Then
        '        For Each drCUL As DataRow In dtResult.Rows
        '            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), drCUL("ExtraCardBin"), drCUL("CULStoreCode")).EndEdit()
        '        Next
        '    End If
        'End If
        'DB.Close()

        dvCULParameter.RowFilter = ""
        dvCULParameter.Table.AcceptChanges()

        dtList = New DataTable
        dtList.Columns.Add("RowID", System.Type.GetType("System.Int16"))
        dtList.Columns.Add("CardNo", System.Type.GetType("System.String"))
        dtList.Columns.Add("Amount", System.Type.GetType("System.Decimal"))
        dtList.Columns.Add("Balance", System.Type.GetType("System.Decimal"))
        dtList.Columns.Add("Selected", System.Type.GetType("System.Boolean"))
        dtList.Columns.Add("Result", System.Type.GetType("System.String"))
        dtList.Columns.Add("CancelAMT", System.Type.GetType("System.Decimal"))
        dtList.Columns.Add("RequestedTime", System.Type.GetType("System.String"))

        With Me.dgvNormal
            .DataSource = dtList
            With .Columns(0)
                .HeaderText = "行号"
                .Width = 35
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
                .HeaderText = "卡号"
                .Width = 120
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.True
            End With
            With .Columns(2)
                .HeaderText = "卡面值"
                .Width = 60
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
            End With
            With .Columns(3)
                .HeaderText = "卡余额"
                .Width = 60
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
            End With
            Dim newCheckColumn As New DataGridViewCheckBoxColumn()
            newCheckColumn.DataPropertyName = "Selected"
            .Columns.RemoveAt(4)
            .Columns.Insert(4, newCheckColumn)
            With .Columns(4)
                .HeaderText = "选择"
                .Width = 50
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(5)
                .HeaderText = "状态"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(6)
                .HeaderText = "实际撤销金额"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(7)
                .HeaderText = "申请日期"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
        End With

        Me.txtCity.Enabled = False
        Me.txtStore.Enabled = False
        Me.txtReason.Enabled = False
        Me.txtRequestor.Enabled = False
        Me.txtBillTotalAmount.Enabled = False
        Me.txtBillPayTotalAmount.Enabled = False
        Me.lblYHOrder.Visible = False
    End Sub

    Private Sub btnValidate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidate.Click
        Dim DB As New DataBase
        DB.Open()
        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在到CUL执行验证订单号操作……"

        If Me.txtOrderNo.Text.Trim = "" Then
            MessageBox.Show("请输入订单号！", "请输入！", MessageBoxButtons.OK)
            frmMain.statusText.Text = "就绪。"
            DB.Close() : Me.Cursor = Cursors.Default
            Exit Sub
        End If

        Try
            Me.lblGetBillResult.Text = ""
            Me.dtList.Rows.Clear()

            Dim dtResult As DataTable = Nothing
            Dim newCard As DataRow, iCard As Integer = 0, sReason As String = "", sCity As String = "", sRequestor As String = "", sStore As String = "", dbFaceValue As Decimal, sAmount As Decimal = 0, sBalance As Decimal = 0, sBillTotalAmount As String = "", sBillPayTotalAmount As String = ""
            Dim dtDatas As DataTable = DB.GetDataTable("select * from CULECancelCharge where OrderNo = '" & Me.txtOrderNo.Text.Trim & "' and OperationState = 0")
            If dtDatas.Rows.Count > 0 Then

                Dim BillTotalAmount As Decimal = dtDatas.Rows(0)("BillTotalAmount").ToString
                Dim BillPayTotalAmount As Decimal = dtDatas.Rows(0)("BillPayTotalAmount").ToString
                If BillTotalAmount > BillPayTotalAmount Then
                    Me.lblYHOrder.Visible = True
                Else
                    Me.lblYHOrder.Visible = False
                End If

                dtResult = DB.GetDataTable("select t1.ExtraCardBin,t2.AreaID,t2.ParentAreaID,isnull(t2.CULStoreCode,0) CULStoreCode from CityExtraCardBin_ELC T1 left join (SELECT S.AreaID,  A.ParentAreaID, A.CULStoreCode FROM AreaScope(" & dtDatas.Rows(0)("RequestorID").ToString & ") AS S INNER JOIN AreaList AS A ON S.AreaID = A.AreaID WHERE A.IsRollout = 1) T2 on t1.CityID = t2.ParentAreaID where T2.AreaID is not null")
                If dtResult Is Nothing Then
                ElseIf dtResult.Rows.Count > 0 Then
                    For Each drCUL As DataRow In dtResult.Rows
                        dvCULParameter.Table.Rows.Add(drCUL("AreaID"), drCUL("ExtraCardBin"), drCUL("CULStoreCode")).EndEdit()
                    Next
                End If

                For Each drCard As DataRow In dtDatas.Rows
                    iCard += 1
                    newCard = dtList.Rows.Add(iCard)
                    newCard("RowID") = iCard
                    newCard("CardNo") = drCard("CardNo").ToString
                    newCard("Amount") = drCard("Balance").ToString
                    newCard("Balance") = drCard("FaceValue").ToString
                    sAmount = drCard("Balance")
                    sBalance = drCard("FaceValue")
                    dbFaceValue = sAmount
                    If sBalance >= sAmount Then
                        '退充值金额
                        dbFaceValue = sAmount
                    End If
                    If sBalance < sAmount Then
                        '退余额
                        dbFaceValue = sBalance
                    End If
                    newCard("Selected") = 0
                    newCard("Result") = drCard("OperationResult").ToString
                    newCard("CancelAMT") = dbFaceValue
                    newCard("RequestedTime") = Convert.ToDateTime(drCard("RequestedTime").ToString).ToString("yyyy/MM/dd")

                    sCity = drCard("CityName").ToString
                    sStore = drCard("StoreName").ToString
                    sReason = drCard("OperationReason").ToString
                    sRequestor = drCard("RequestorName").ToString
                    sBillTotalAmount = drCard("BillTotalAmount").ToString
                    sBillPayTotalAmount = drCard("BillPayTotalAmount").ToString
                    newCard.EndEdit()
                Next
            Else
                Me.lblGetBillResult.ForeColor = Color.Red
                Me.lblGetBillResult.Text = "该订单号未提交申请，请确认订单号是否正确！"
                frmMain.statusText.Text = "就绪"
                DB.Close() : Me.Cursor = Cursors.Default
                Exit Sub
            End If

            btnReturn.Enabled = True : btnExecute.Enabled = True
            Me.txtCity.Text = sCity
            Me.txtStore.Text = sStore
            Me.txtReason.Text = sReason
            Me.txtRequestor.Text = sRequestor
            Me.txtBillTotalAmount.Text = sBillTotalAmount
            Me.txtBillPayTotalAmount.Text = sBillPayTotalAmount
            frmMain.statusText.Text = "就绪"
            Me.Cursor = Cursors.Default
            DB.Close()
        Catch ex As Exception
            MessageBox.Show("因为CUL系统故障，无法进行验证操作！ 下面是CUL系统的内部错误提示：    " & Chr(13) & Chr(13) & ex.Message & Space(4), "出现CUL系统故障！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "因为CUL系统故障，无法进行验证操作！"
            Me.Cursor = Cursors.Default
            DB.Close() : Return
        End Try
    End Sub

    Private Sub btnExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecute.Click
        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法提交数据。请检查数据库连接。"
            Me.Cursor = Cursors.Default
            Return
        End If

        guIDClass = New C4ShoppingCardService.GuIDClass
        guIDClass.GuID = frmMain.sGuID
        Dim c4Service As C4ShoppingCardService.C4ShoppingCardService = Nothing
        Dim idvvClass As C4ShoppingCardService.IdvvClass = Nothing, codeMsg As C4ShoppingCardService.CodeMsg = Nothing

        Try
            c4Service = New C4ShoppingCardService.C4ShoppingCardService()
            idvvClass = New C4ShoppingCardService.IdvvClass
        Catch ex As Exception
            MessageBox.Show("因为CUL系统故障，无法进行充值撤销操作！ 下面是CUL系统的内部错误提示：    " & Chr(13) & Chr(13) & ex.Message & Space(4), "出现CUL系统故障！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "因为CUL系统故障，无法进行充值撤销操作！"
            If c4Service IsNot Nothing Then c4Service.Dispose() : c4Service = Nothing
            If idvvClass IsNot Nothing Then idvvClass = Nothing
            DB.Close() : Me.Cursor = Cursors.Default : Return
        End Try

        Dim sMerchantNo As String = "", iSucessfully As Integer = 0, sStartCardNo As String = "", sEndCardNo As String = "", iCardQTY As Integer = 1, dbFaceValue As Decimal, sAmount As Decimal = 0, sBalance As Decimal = 0
        If dtList.Select("Selected=1").Length > 0 Then
            For Each drCard As DataRow In dtList.Select("Selected=1")
                sStartCardNo = drCard("CardNo").ToString
                sEndCardNo = drCard("CardNo").ToString
                sAmount = Convert.ToDecimal(drCard("Amount").ToString)
                sBalance = Convert.ToDecimal(drCard("Balance").ToString)

                dbFaceValue = sAmount
                If sBalance >= sAmount Then
                    '退充值金额
                    dbFaceValue = sAmount
                End If
                If sBalance < sAmount Then
                    '退余额
                    dbFaceValue = sBalance
                End If

                sMerchantNo = dvCULParameter.Table.Select("CULCardBin='" & sStartCardNo.Substring(4, 5) & "'")(0)("CULStoreCode").ToString

                idvvClass.MerchantNo = sMerchantNo
                idvvClass.UserID = sMerchantNo
                idvvClass.CardNoFrom = sStartCardNo
                idvvClass.CardNoTo = sEndCardNo
                idvvClass.Amount = Format(dbFaceValue, "0.00")
                idvvClass.TotalAmount = Format(dbFaceValue * iCardQTY, "0.00")
                idvvClass.DMerchantNo = sMerchantNo
                codeMsg = c4Service.idvv(idvvClass, guIDClass)

                If codeMsg.Code.ToUpper = "NZ" Then
                    iSucessfully += iCardQTY
                Else
                    '充值撤销失败
                    frmMain.statusText.Text = "充值撤销失败。"
                    MessageBox.Show("充值撤销失败！ " & codeMsg.Msg & "。", "Submit Failure.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DB.Close() : Return
                End If
            Next
        Else
            MessageBox.Show("系统在确认充值撤销时，未选中任何行！    ", "确认充值撤销未选中任何行！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Cursor = Cursors.Default
            Return
        End If

        Dim sMsg As String = "请注意：确认操作一旦提交，便不可撤消！    " & Chr(13) & Chr(13) & "如果您确认上面信息正确无误，请按""确定""按钮继续。    "
        If MessageBox.Show(sMsg, "请确认：", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Cancel Then Return
        Me.Refresh()

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在提交到CUL进行充值撤销……"

        Dim sValues As String = ""
        sValues = sValues & ",AuditorID = '" & frmMain.sLoginUserID & "'"
        sValues = sValues & ",AuditorName = '" & frmMain.sLoginUserRealName & "'"
        sValues = sValues & ",AuditorTime = '" & Date.Now.ToString & "'"
        Dim sSQL As String = "update CULECancelCharge set OperationState = 9,OperationResult = '充值撤销成功' " & sValues & " where OrderNo = '" & Me.txtOrderNo.Text.Trim & "' and OperationState = 0"
        DB.ModifyTable(sSQL)
        frmMain.statusText.Text = "充值撤销成功。"
        MessageBox.Show("充值撤销成功！ ", "Submit OK.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.btnValidate_Click(sender, e) : Me.lblGetBillResult.Visible = False
        btnReturn.Enabled = False : btnExecute.Enabled = False
        Me.Cursor = Cursors.Default
        DB.Close()
    End Sub

    Private Sub btnReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturn.Click
        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法提交数据。请检查数据库连接。"
            Me.Cursor = Cursors.Default
            Return
        End If

        Dim sCards As String = ""
        If dtList.Select("Selected=1").Length > 0 Then
            For Each drCard As DataRow In dtList.Select("Selected=1")
                If sCards = "" Then
                    sCards = "'" & drCard("CardNo").ToString & "'"
                Else
                    sCards = sCards & ",'" & drCard("CardNo").ToString & "'"
                End If
            Next
        Else
            MessageBox.Show("系统在退回申请时，未选中任何行！    ", "退回申请未选中任何行！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Cursor = Cursors.Default
            Return
        End If

        Dim sMsg As String = "请注意：确认操作一旦提交，便不可撤消！    " & Chr(13) & Chr(13) & "如果您确认上面信息正确无误，请按""确定""按钮继续。    "
        If MessageBox.Show(sMsg, "请确认：", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Cancel Then Return
        Me.Refresh()

        Dim sSQL As String = "delete CULECancelCharge where OrderNo = '" & Me.txtOrderNo.Text.Trim & "' and OperationState = 0" & " and CardNo in (" & sCards & ")"
        DB.ModifyTable(sSQL)
        frmMain.statusText.Text = "退回申请成功。"
        MessageBox.Show("退回申请成功！ ", "Submit OK.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.btnValidate_Click(sender, e) : Me.lblGetBillResult.Visible = False
        btnReturn.Enabled = False : btnExecute.Enabled = False
        Me.Cursor = Cursors.Default
        DB.Close()
    End Sub

    Private Sub btnHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistory.Click
        'modify code 084:start-------------------------------------------------------------------------
        With frmECancelChargeHistory
            .ShowDialog()
            .Dispose()
        End With
        'modify code 084:end-------------------------------------------------------------------------
    End Sub
End Class