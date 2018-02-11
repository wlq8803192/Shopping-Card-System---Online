Public Class frmECancelChargeRequirement

    Private IWebService As InternetWebService.Service = Nothing
    Private oai As InternetWebService.OrderAllInfo = Nothing
    Public oair As InternetWebService.OrderAllInfoResponse = Nothing

    Private dtAreaCode As DataTable = Nothing
    Public sCityID As String = "", sStoreID As String = ""
    Dim dtList As DataTable, TotalAmt As Decimal, PayAmt As Decimal, sCityName As String = "测试城市"
    Private sIssuerId As String = frmMain.sIssuerId
    Private dvCULParameter As DataView

    Private Sub frmECancelChargeRequirement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        Dim DB As New DataBase(), dtResult As DataTable = Nothing
        DB.Open()
        If DB.IsConnected Then
            dtResult = DB.GetDataTable("select t1.ExtraCardBin,t2.AreaID,isnull(t2.CULStoreCode,0) CULStoreCode from CityExtraCardBin_ELC T1 left join (SELECT S.AreaID,  A.ParentAreaID, A.CULStoreCode FROM AreaScope(" & frmMain.sLoginUserID & ") AS S INNER JOIN AreaList AS A ON S.AreaID = A.AreaID WHERE A.IsRollout = 1) T2 on t1.CityID = t2.ParentAreaID where T2.AreaID is not null")
            If dtResult Is Nothing Then
            ElseIf dtResult.Rows.Count > 0 Then
                For Each drCUL As DataRow In dtResult.Rows
                    dvCULParameter.Table.Rows.Add(drCUL("AreaID"), drCUL("ExtraCardBin"), drCUL("CULStoreCode")).EndEdit()
                Next
            End If
        End If
        DB.Close()

        dvCULParameter.RowFilter = ""
        dvCULParameter.Table.AcceptChanges()

        Me.txtCity.Enabled = False
        Me.txtBillTotalAmount.Enabled = False
        Me.txtBillPayTotalAmount.Enabled = False
        Me.lblYHOrder.Visible = False

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
    End Sub

    Private Sub btnValidate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidate.Click
        Dim DB As New DataBase
        DB.Open()
        Me.oair = Nothing
        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在到CUL执行验证订单号操作……"

        If Me.txtOrderNo.Text.Trim = "" Then
            MessageBox.Show("请输入订单号！", "请输入！", MessageBoxButtons.OK)
            frmMain.statusText.Text = "就绪。"
            DB.Close() : Me.Cursor = Cursors.Default
            Exit Sub
        End If

        Try
            If frmMain.sLoginAreaType = "S" Then
                sCityID = frmMain.dtLoginStructure.Rows.Find(frmMain.sLoginAreaID)("ParentAreaID").ToString
            ElseIf frmMain.sLoginAreaType = "C" Then
                sCityID = frmMain.sLoginAreaID
            Else
                sCityID = frmMain.sLoginAreaID
            End If
            GetAreaCode(sCityID, sStoreID)

            Me.txtBillTotalAmount.Text = ""
            Me.txtBillPayTotalAmount.Text = ""
            Me.lblGetBillResult.Text = ""
            Me.dtList.Rows.Clear()

            Dim c4Service As C4ShoppingCardService.C4ShoppingCardService = Nothing
            IWebService = New InternetWebService.Service
            oai = New InternetWebService.OrderAllInfo
            With oai
                .IssuerId = frmMain.sIssuerId
                .BillNo = Me.txtOrderNo.Text.Trim
            End With
            oair = IWebService.QueryOrderAllInfo(oai) '调用查询接口
            If oair.CodeMsg.Code = "00" Then '查询成功
                If oair.OrderAllInfoData.BillTotalAmount Is Nothing Or oair.OrderAllInfoData.BillPayTotalAmount Is Nothing Then
                    Me.lblGetBillResult.ForeColor = Color.Red
                    Me.lblGetBillResult.Text = "订单号验证失败！银商提供订单金额信息不足。"
                    frmMain.statusText.Text = "就绪"
                    IWebService.Dispose() : IWebService = Nothing
                    DB.Close() : Me.Cursor = Cursors.Default
                    Exit Sub
                End If

                Dim returnFlag As Boolean = False
                If dtAreaCode Is Nothing Then
                    returnFlag = False
                Else
                    Dim i As Integer
                    For i = 0 To dtAreaCode.Rows.Count - 1
                        If oair.OrderAllInfoData.CardTransInfoArray(0).AreaCode.ToUpper = dtAreaCode.Rows(i)("AreaCode").ToString.ToUpper Then
                            returnFlag = True
                            Exit For
                        End If
                    Next
                End If

                Dim dtCity As DataTable = DB.GetDataTable("select areachinesename from arealist where areaid in (select cityid from city_areacode where areacode = '" & oair.OrderAllInfoData.CardTransInfoArray(0).AreaCode & "')")
                If dtCity.Rows.Count > 0 Then
                    sCityName = dtCity.Rows(0)(0).ToString
                    Me.txtCity.Text = sCityName
                End If

                If Not returnFlag Then
                    Me.lblGetBillResult.ForeColor = Color.Red
                    Me.lblGetBillResult.Text = "订单验证失败！订单所属城市不是本市。"
                    frmMain.statusText.Text = "就绪"
                    IWebService.Dispose() : IWebService = Nothing
                    DB.Close() : Me.Cursor = Cursors.Default
                    Exit Sub
                End If

                TotalAmt = oair.OrderAllInfoData.BillTotalAmount
                PayAmt = oair.OrderAllInfoData.BillPayTotalAmount
                Dim newCard As DataRow, iCard As Integer = 0, sMerchantNo As String = ""
                For nIndex As Integer = 0 To oair.OrderAllInfoData.CardTransInfoArray.Length - 1
                    Dim myCardTransInfo As InternetWebService.CardTransInfo = oair.OrderAllInfoData.CardTransInfoArray(nIndex)

                    If myCardTransInfo.AreaCode Is Nothing OrElse myCardTransInfo.AreaCode = "" Then
                        Me.lblGetBillResult.ForeColor = Color.Red
                        Me.lblGetBillResult.Text = "提取码验证失败！银商提供区域代码信息不足。"
                        frmMain.statusText.Text = "就绪"
                        IWebService.Dispose() : IWebService = Nothing
                        DB.Close() : Me.Cursor = Cursors.Default
                        Exit Sub
                    End If

                    sMerchantNo = dvCULParameter.Table.Select("CULCardBin='" & myCardTransInfo.CardNo.Substring(4, 5) & "'")(0)("CULStoreCode").ToString
                    c4Service = New C4ShoppingCardService.C4ShoppingCardService
                    Dim iClass As New C4ShoppingCardService.InfoClass()
                    iClass.MerchantNo = sMerchantNo
                    iClass.UserID = sMerchantNo
                    iClass.CardNoFrom = myCardTransInfo.CardNo
                    iClass.CardNoTo = myCardTransInfo.CardNo
                    iClass.IsPager = "N"
                    iClass.PageNo = "1"
                    iClass.PageSize = "1000000"

                    Dim sBalance As String = "0"
                    Try
                        'sBalance = Convert.ToInt32(c4Service.getBalance(iClass)).ToString
                        Dim dtTemp As DataTable
                        If myCardTransInfo.CardNo.Substring(4, 5) = "6599900" Then
                            dtTemp = ShoppingCardOperation.GetECardState(sMerchantNo, myCardTransInfo.CardNo, myCardTransInfo.CardNo)
                        Else
                            dtTemp = ShoppingCardOperation.GetCRFCardState(sMerchantNo, myCardTransInfo.CardNo, myCardTransInfo.CardNo)
                        End If
                        If dtTemp.Rows.Count > 0 Then
                            sBalance = dtTemp.Rows(0)("Balance").ToString
                        End If
                    Catch
                        sBalance = "0"
                    End Try

                    iCard += 1
                    newCard = dtList.Rows.Add(iCard)
                    newCard("RowID") = iCard
                    newCard("CardNo") = myCardTransInfo.CardNo
                    newCard("Amount") = myCardTransInfo.Amount
                    newCard("Balance") = sBalance
                    newCard("Selected") = 0
                    newCard("Result") = ""
                    newCard("CancelAMT") = 0
                    newCard("RequestedTime") = ""
                    newCard.EndEdit()
                Next

                If dtList.Rows.Count > 0 Then
                    Dim sAmount As Decimal = 0, sBalance As Decimal = 0, sReturnAMT As Decimal = 0
                    For Each drCard As DataRow In dtList.Rows
                        Dim dtData As DataTable = DB.GetDataTable("select OperationID,OperationResult,RequestedTime,Balance,FaceValue from CULECancelCharge where CardNo = '" & drCard("CardNo").ToString & "'")
                        If dtData.Rows.Count > 0 Then
                            sAmount = dtData.Rows(0)("Balance")
                            sBalance = dtData.Rows(0)("FaceValue")

                            If sBalance >= sAmount Then
                                '退充值金额
                                sReturnAMT = sAmount
                            End If
                            If sBalance < sAmount Then
                                '退余额
                                sReturnAMT = sBalance
                            End If

                            Me.dgvNormal(4, drCard("RowID") - 1).ReadOnly = True
                            Me.dgvNormal(5, drCard("RowID") - 1).Value = dtData.Rows(0)("OperationResult").ToString
                            Me.dgvNormal(6, drCard("RowID") - 1).Value = sReturnAMT
                            Me.dgvNormal(7, drCard("RowID") - 1).Value = Convert.ToDateTime(dtData.Rows(0)("RequestedTime")).ToString("yyyy/MM/dd")
                            Me.dgvNormal.Rows(drCard("RowID") - 1).DefaultCellStyle.BackColor = SystemColors.Control
                        End If
                    Next
                Else
                    Me.lblGetBillResult.ForeColor = Color.Red
                    Me.lblGetBillResult.Text = "该订单号未找到相关卡号信息，请确认订单号是否正确！"
                    frmMain.statusText.Text = "就绪"
                    IWebService.Dispose() : IWebService = Nothing
                    DB.Close() : Me.Cursor = Cursors.Default
                    Exit Sub
                End If

                With oair
                    Me.txtCity.Text = sCityName
                    Me.txtBillTotalAmount.Text = .OrderAllInfoData.BillTotalAmount
                    Me.txtBillPayTotalAmount.Text = .OrderAllInfoData.BillPayTotalAmount
                End With
            End If

            If TotalAmt > PayAmt Then
                Me.lblYHOrder.Visible = True
            Else
                Me.lblYHOrder.Visible = False
            End If

            btnExecute.Enabled = True
            IWebService.Dispose() : IWebService = Nothing
            frmMain.statusText.Text = "就绪"
            Me.Cursor = Cursors.Default
            DB.Close()
        Catch ex As Exception
            MessageBox.Show("因为CUL系统故障，无法进行验证操作！ 下面是CUL系统的内部错误提示：    " & Chr(13) & Chr(13) & ex.Message & Space(4), "出现CUL系统故障！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "因为CUL系统故障，无法进行验证操作！"
            If IWebService IsNot Nothing Then IWebService.Dispose() : IWebService = Nothing
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

        Dim sStoreName As String = ""
        Dim dtStore As DataTable = DB.GetDataTable("select areachinesename from arealist where areaid = '" & frmMain.sLoginAreaID & "'")
        If dtStore.Rows.Count > 0 Then
            sStoreName = dtStore.Rows(0)(0).ToString
        End If

        If Me.txtReason.Text.Trim = "" Then
            MessageBox.Show("请输入撤销原因！", "请输入！", MessageBoxButtons.OK)
            frmMain.statusText.Text = "就绪。"
            DB.Close() : Me.Cursor = Cursors.Default
            Return
        End If

        Dim sSQL As String = "", sReason = Me.txtReason.Text.Trim().Replace("'", ""), sAmount As Decimal = 0, sBalance As Decimal = 0, sReturnAMT As Decimal = 0
        If dtList.Select("Selected=1").Length > 0 Then
            For Each drCard As DataRow In dtList.Select("Selected=1")
                sAmount = Convert.ToDecimal(drCard("Amount").ToString)
                sBalance = Convert.ToDecimal(drCard("Balance").ToString)

                If sBalance = 0 Then
                    Me.lblGetBillResult.ForeColor = Color.Red
                    Me.lblGetBillResult.Text = "该卡不允许申请该操作。"
                    DB.Close() : Me.Cursor = Cursors.Default
                    drCard("Result") = ""
                    Exit Sub
                End If

                If TotalAmt = PayAmt Then
                    If sBalance >= sAmount Then
                        '退充值金额
                        sReturnAMT = sAmount
                    End If
                    If sBalance < sAmount Then
                        '退余额
                        sReturnAMT = sBalance
                    End If
                End If

                If TotalAmt > PayAmt Then
                    If sBalance >= sAmount Then
                        ''整单退，充值金额
                        'If dtList.Select("Selected=1").Length <> dtList.Rows.Count Then
                        '    MessageBox.Show("系统在提交申请充值撤销时，余额不小于充值金额必须整单退掉！    ", "余额不小于充值金额必须整单退掉！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        '    Me.Cursor = Cursors.Default
                        '    Return
                        'End If
                        '退充值金额
                        sReturnAMT = sAmount
                    End If
                    If sBalance < sAmount Then
                        ''不能退
                        'MessageBox.Show("系统在提交申请充值撤销时，余额小于充值金额不可退卡！    ", "余额小于充值金额不可退卡！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        'Me.Cursor = Cursors.Default
                        'Return
                        '退余额
                        sReturnAMT = sBalance
                    End If
                End If

                drCard("Result") = "待充值撤销确认"
                Dim sValues As String = "'" & Me.txtOrderNo.Text.Trim & "'," '订单号’
                sValues = sValues & "'" & drCard("CardNo").ToString & "'," '卡号’
                sValues = sValues & "'" & drCard("Amount").ToString & "'," '充值金额’
                sValues = sValues & "'" & drCard("Balance").ToString & "'," '余额’
                sValues = sValues & "'" & sCityName & "'," '城市’
                sValues = sValues & "'" & frmMain.sLoginUserID & "',"
                sValues = sValues & "'" & frmMain.sLoginUserRealName & "',"
                sValues = sValues & "'" & Date.Now.ToString & "',"
                sValues = sValues & "null,null,null,0,'" & sReason & "','" & drCard("Result").ToString & "','" & sStoreName & "',"
                sValues = sValues & "'" & TotalAmt & "',"
                sValues = sValues & "'" & PayAmt & "'"
                sSQL = sSQL & "insert into CULECancelCharge values (" & sValues & "); "
            Next
        Else
            MessageBox.Show("未选择需充值撤销的卡，无法提交申请！    ", "未选择需充值撤销的卡，无法提交申请！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Cursor = Cursors.Default
            Return
        End If

        Dim sMsg As String = "请注意：申请操作一旦提交，便不可撤消！    " & Chr(13) & Chr(13) & "如果您确认上面信息正确无误，请按""确定""按钮继续。    "
        If MessageBox.Show(sMsg, "请确认申请：", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Cancel Then Return
        Me.Refresh()

        Me.Cursor = Cursors.Default
        frmMain.statusText.Text = "正在提交充值撤销申请……"

        Dim iResult As Integer = DB.ModifyTable(sSQL)
        frmMain.statusText.Text = "充值撤销申请提交成功。" & iResult
        MessageBox.Show("充值撤销申请提交成功！ ", "Submit OK.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.btnValidate_Click(sender, e)
        btnExecute.Enabled = False
        DB.Close()
    End Sub

    Private Sub GetAreaCode(ByVal parmCityID As String, ByVal parmStoreID As String)
        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法提交数据。请检查数据库连接。"
            Me.Close() : Return
        End If

        Try
            'Dim dtStoreAreaCode As DataTable = DB.GetDataTable("select M.IssuerID from CULMerchantList M join AreaList A on A.CULStoreCode = M.MerchantNo where A.AreaID = " & parmStoreID)
            'If dtStoreAreaCode Is Nothing OrElse dtStoreAreaCode.Rows.Count = 0 Then
            '    DB.Close()
            '    Return
            'End If
            If parmCityID <> "" Then
                dtAreaCode = DB.GetDataTable("Select * From City_AreaCode Where CityID=" & parmCityID).Copy
                If dtAreaCode Is Nothing OrElse dtAreaCode.Rows.Count = 0 Then
                    dtAreaCode = DB.GetDataTable("Select * From City_AreaCode Where CityID in (Select AreaID From AreaList Where ParentAreaID = '" & parmCityID & "')").Copy
                End If
            End If
            DB.Close()
        Catch ex As Exception
            DB.Close()
        End Try
    End Sub
End Class