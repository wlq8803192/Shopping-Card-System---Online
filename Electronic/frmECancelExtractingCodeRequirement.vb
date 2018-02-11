Public Class frmECancelExtractingCodeRequirement

    'modify code 083:
    'date;2017/11/8
    'auther:Qipeng
    'remark:修复提取码作废确认界面中添加显示字段“订单号”的功能

    Public dtAreaCode As DataTable = Nothing
    Public dtCityBillBuyChannel As DataTable = Nothing
    Public sCityID As String = "", sStoreID As String = "", sCityName As String = ""

    Private sIssuerId As String = frmMain.sIssuerId
    Private IWebService As InternetWebService.Service = Nothing
    Private eci As InternetWebService.ExtractingCodeInfo = Nothing
    Private ecir As InternetWebService.ExtractingCodeInfoResponse = Nothing

    Private Sub frmECancelExtractingCodeRequirement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.txtExtractingCode.Text = ""
        Me.txtHolderMobilePhone.Text = ""
        Me.txtStatus.Text = ""
        Me.txtBillBuyChannel.Text = ""
        Me.txtBillNo.Text = ""
        Me.txtBillTotalAmount.Text = ""
        Me.txtBillPayTotalAmount.Text = ""
        Me.lblGetCodeResult.Text = ""
        Me.txtExtractingCode.Select()
        Me.btnOK.Enabled = False
    End Sub

    Private Sub btnVerify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerify.Click
        If Me.txtExtractingCode.Text.Trim = "" OrElse Me.txtHolderMobilePhone.Text.Trim = "" Then
            MessageBox.Show("请输入提取码和持卡人手机号！", "请输入！", MessageBoxButtons.OK)
            Exit Sub
        End If

        Dim DB As New DataBase
        DB.Open()
        Me.ecir = Nothing
        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在执行验证提取码操作……"

        Try
            If frmMain.sLoginAreaType = "S" Then
                sCityID = frmMain.dtLoginStructure.Rows.Find(frmMain.sLoginAreaID)("ParentAreaID").ToString
            ElseIf frmMain.sLoginAreaType = "C" Then
                sCityID = frmMain.sLoginAreaID
            Else
                sCityID = frmMain.sLoginAreaID
            End If
            GetAreaCode(sCityID, sStoreID)

            '清空
            Me.txtStatus.Text = ""
            Me.txtBillBuyChannel.Text = ""
            Me.txtBillNo.Text = ""
            Me.txtBillTotalAmount.Text = ""
            Me.txtBillPayTotalAmount.Text = ""
            Me.lblGetCodeResult.Text = ""

            Dim dtExtractingCode As DataTable = DB.GetDataTable("select ExtractingCode,OperationResult from CULECancelExtractingCode where ExtractingCode = '" & Me.txtExtractingCode.Text.Trim & "'")
            If dtExtractingCode Is Nothing Then
            Else
                If dtExtractingCode.Rows.Count > 0 Then
                    If dtExtractingCode.Rows(0)("OperationResult").ToString() <> "" Then
                        Me.lblGetCodeResult.Text = "提取码验证失败！此提取码状态不正确，系统已确认作废。"
                    Else
                        Me.lblGetCodeResult.Text = "提取码验证失败！此提取码状已申请作废，待确认。"
                    End If

                    Me.lblGetCodeResult.ForeColor = Color.Red
                    Me.btnOK.Enabled = False
                    frmMain.statusText.Text = "就绪"
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            End If

            '    sSalesBillID = ""
            '    sSalesBillID = GetSalesBillID()
            '    If sSalesBillID <> "" Then
            '        Me.lblGetCodeResult.ForeColor = Color.Blue
            '        Me.lblGetCodeResult.Text = "提取码验证成功！" & Chr(13) & "此提取码已生成线下提卡销售单，点击[确定]查看订单。"
            '        Me.btnOK.Enabled = True
            '        frmMain.statusText.Text = "就绪"
            '        Me.Cursor = Cursors.Default
            '        Exit Sub
            '    End If

            IWebService = New InternetWebService.Service()
            eci = New InternetWebService.ExtractingCodeInfo()
            With eci
                .IssuerId = sIssuerId
                .ExtractingCode = Me.txtExtractingCode.Text.Trim
                .MobilePhone = Me.txtHolderMobilePhone.Text.Trim
            End With
            ecir = IWebService.QueryExtractingCodeInfo(eci)

            If ecir.CodeMsg.Code = "00" Then '查询成功
                With ecir.ExtractingCodeInfoData
                    If .Status Is Nothing Or .BillBuyChannel Is Nothing Or .ExtractingCodeInfoDetailData.AreaCode Is Nothing _
                    Or .BillNo Is Nothing Or .BillType Is Nothing Or .BillTotalAmount Is Nothing Or .BillPayTotalAmount Is Nothing _
                    Or .ExtractingCodeInfoDetailData.CardPrice Is Nothing Or .ExtractingCodeInfoDetailData.ProductNum Is Nothing Then
                        Me.lblGetCodeResult.ForeColor = Color.Red
                        Me.lblGetCodeResult.Text = "提取码验证失败！银商提供信息不足。"
                        Me.btnOK.Enabled = False
                        frmMain.statusText.Text = "就绪"
                        IWebService.Dispose() : IWebService = Nothing
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                End With
                With ecir.ExtractingCodeInfoData
                    '订单信息
                    Select Case .Status 'I-已产生，A-已激活，U-已领取，C-已撤销或关闭
                        Case "I"
                            Me.txtStatus.Text = "已产生"
                        Case "A"
                            Me.txtStatus.Text = "已激活"
                        Case "U"
                            Me.txtStatus.Text = "已领取"
                        Case "C"
                            Me.txtStatus.Text = "已撤销或关闭"
                    End Select
                    Me.txtBillBuyChannel.Text = IIf(.BillBuyChannel.ToUpper = "WECHAT", "微信", "支付宝") 'Wechat-微信，Alipay-支付宝
                    Me.txtBillNo.Text = .BillNo
                    Me.txtBillTotalAmount.Text = .BillTotalAmount
                    Me.txtBillPayTotalAmount.Text = .BillPayTotalAmount
                    '换卡信息
                    'Me.txtBillType.Text = IIf(.BillType = "ENTITY", "实体卡", "礼品卡") 'ENTITY-实体卡，GIFT-礼品卡
                    'With .ExtractingCodeInfoDetailData
                    '    Me.txtCardPrice.Text = .CardPrice
                    '    Me.txtProductNum.Text = .ProductNum
                    'End With
                End With

                '验证区域代码
                Dim returnResult As String
                Dim returnFlag As Boolean = False
                If dtAreaCode Is Nothing Then
                    returnFlag = False
                Else

                    Dim i As Integer
                    returnResult = ecir.ExtractingCodeInfoData.ExtractingCodeInfoDetailData.AreaCode.ToUpper
                    For i = 0 To dtAreaCode.Rows.Count - 1
                        If returnResult = dtAreaCode.Rows(i)("AreaCode").ToString.ToUpper Then
                            returnFlag = True
                            Exit For
                        End If
                    Next
                End If

                Dim dtCity As DataTable = DB.GetDataTable("select areachinesename from arealist where areaid in (select cityid from city_areacode where areacode = '" & ecir.ExtractingCodeInfoData.ExtractingCodeInfoDetailData.AreaCode & "')")
                If dtCity.Rows.Count > 0 Then
                    sCityName = dtCity.Rows(0)(0).ToString
                    Me.txtCityName.Text = sCityName
                End If

                If Not returnFlag Then
                    Me.lblGetCodeResult.ForeColor = Color.Red
                    Me.lblGetCodeResult.Text = "提取码验证失败！此提取码不能在当前城市使用。"
                    Me.btnOK.Enabled = False
                    frmMain.statusText.Text = "就绪"
                    IWebService.Dispose() : IWebService = Nothing
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If

                '验证购买渠道
                'If ecir.ExtractingCodeInfoData.BillBuyChannel Is Nothing Then
                '    Me.lblGetCodeResult.ForeColor = Color.Red
                '    Me.lblGetCodeResult.Text = "提取码验证失败！从银商获取购买渠道失败。"
                '    Me.btnOK.Enabled = False
                '    frmMain.statusText.Text = "就绪"
                '    IWebService.Dispose() : IWebService = Nothing
                '    Me.Cursor = Cursors.Default
                '    Exit Sub
                'End If

                If ecir.ExtractingCodeInfoData.Status = "U" Then
                    Me.lblGetCodeResult.ForeColor = Color.Red
                    Me.lblGetCodeResult.Text = "提取码验证失败！此提取码已领取。"
                    Me.btnOK.Enabled = False
                    frmMain.statusText.Text = "就绪"
                    IWebService.Dispose() : IWebService = Nothing
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                If ecir.ExtractingCodeInfoData.Status = "C" Then
                    Me.lblGetCodeResult.ForeColor = Color.Red
                    Me.lblGetCodeResult.Text = "提取码验证失败！此提取码已作废。"
                    Me.btnOK.Enabled = False
                    frmMain.statusText.Text = "就绪"
                    IWebService.Dispose() : IWebService = Nothing
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If

                Me.lblGetCodeResult.ForeColor = Color.Blue
                Me.lblGetCodeResult.Text = "提取码验证成功！"
                Me.btnOK.Enabled = True
            Else
                Me.lblGetCodeResult.ForeColor = Color.Red
                Me.lblGetCodeResult.Text = "提取码验证失败！" & ecir.CodeMsg.Msg
                Me.btnOK.Enabled = False
            End If

            frmMain.statusText.Text = "就绪"
            IWebService.Dispose() : IWebService = Nothing
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

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法提交数据。请检查数据库连接。"
            Me.Cursor = Cursors.Default
            Return
        End If

        Try
            Dim sSQL As String = ""
            Dim sValues As String = ""
            sValues = sValues & "'" & Me.txtExtractingCode.Text.Trim() & "',"
            sValues = sValues & "'" & Me.txtHolderMobilePhone.Text.Trim() & "',"
            sValues = sValues & "'" & frmMain.sLoginUserID & "',"
            sValues = sValues & "'" & frmMain.sLoginUserRealName & "',"
            sValues = sValues & "'" & Date.Now.ToString & "',"
            'modify code 083:start-------------------------------------------------------------------------
            sValues = sValues & "null,null,null,null,'" & Me.txtCityName.Text.Trim & "','" & Me.txtBillTotalAmount.Text.Trim & "','" & Me.txtBillPayTotalAmount.Text.Trim & "','" & Me.txtBillNo.Text.Trim & "'"
            'modify code 083:end-------------------------------------------------------------------------
            sSQL = sSQL & "insert into CULECancelExtractingCode values (" & sValues & ");"

            Dim sMsg As String = "请注意：申请操作一旦提交，便不可撤消！    " & Chr(13) & Chr(13) & "如果您确认上面信息正确无误，请按""确定""按钮继续。    "
            If MessageBox.Show(sMsg, "请确认申请：", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Cancel Then Return
            Me.Refresh()

            Me.Cursor = Cursors.Default
            frmMain.statusText.Text = "正在提交提取码作废申请……"

            DB.ModifyTable(sSQL)
            frmMain.statusText.Text = "提取码作废申请提交成功。"
            MessageBox.Show("提取码作废申请提交成功！ ", "Submit OK.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnOK.Enabled = False
        Catch ex As Exception
            MessageBox.Show("因为CUL系统故障，无法进行验证操作！ 下面是CUL系统的内部错误提示：    " & Chr(13) & Chr(13) & ex.Message & Space(4), "出现CUL系统故障！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "因为CUL系统故障，无法进行验证操作！"
            If IWebService IsNot Nothing Then IWebService.Dispose() : IWebService = Nothing
            Me.Cursor = Cursors.Default
        End Try
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
