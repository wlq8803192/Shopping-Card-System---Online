
'modify code 040:
'date;2014/11/5
'auther:Hyron bjy 
'remark:新增销售单类型---线下提卡销售单

'modify code 044:
'date;2015/1/9
'auther:Hyron bjy 
'remark: 增加线下提卡销售单支付方式--瑞泰

'modify code 040:start-------------------------------------------------------------------------
Public Class frmInternetSales_ForCul

    Public sCityID As String = "", sStoreID As String = ""
    Public dtCityBillBuyChannel As DataTable = Nothing
    Public sIssuerId As String = frmMain.sIssuerId
    Public dtAreaCode As DataTable = Nothing
    Public sSalesBillID As String = ""

    Private IWebService As InternetWebService.Service = Nothing
    Private eci As InternetWebService.ExtractingCodeInfo = Nothing
    Public ecir As InternetWebService.ExtractingCodeInfoResponse = Nothing

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnVerify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerify.Click

        If Me.txtExtractingCode.Text.Trim = "" OrElse Me.txtHolderMobilePhone.Text.Trim = "" Then
            MessageBox.Show("请输入提取码和持卡人手机号！", "请输入！", MessageBoxButtons.OK)
            Exit Sub
        End If

        Me.ecir = Nothing

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在执行验证提取码操作……"

        Try
            '清空
            InitBillInfo()
            Me.lblGetCodeResult.Text = ""

            sSalesBillID = ""
            sSalesBillID = GetSalesBillID()
            If sSalesBillID <> "" Then
                Me.lblGetCodeResult.ForeColor = Color.Blue
                Me.lblGetCodeResult.Text = "提取码验证成功！" & Chr(13) & "此提取码已生成线下提卡销售单，点击[确定]查看订单。"
                Me.btnOK.Enabled = True
                frmMain.statusText.Text = "就绪"
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            IWebService = New InternetWebService.Service()
            eci = New InternetWebService.ExtractingCodeInfo()
            With eci
                .IssuerId = sIssuerId
                '.ExtractingCode = "1415968525638182270"
                '.MobilePhone = "13641804277"
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
                    Me.txtBillType.Text = IIf(.BillType = "ENTITY", "实体卡", "礼品卡") 'ENTITY-实体卡，GIFT-礼品卡
                    With .ExtractingCodeInfoDetailData
                        Me.txtCardPrice.Text = .CardPrice
                        Me.txtProductNum.Text = .ProductNum
                    End With
                End With

                '验证区域代码
                Dim returnResult As String
                Dim returnFlag As Boolean = False
                Dim i As Integer
                returnResult = ecir.ExtractingCodeInfoData.ExtractingCodeInfoDetailData.AreaCode.ToUpper
                For i = 0 To dtAreaCode.Rows.Count - 1
                    If returnResult = dtAreaCode.Rows(i)("AreaCode").ToString.ToUpper Then
                        returnFlag = True
                        Exit For
                    End If
                Next
                'If ecir.ExtractingCodeInfoData.ExtractingCodeInfoDetailData.AreaCode.ToUpper <> dtAreaCode.Rows(0)("AreaCode").ToString.ToUpper Then
                If Not returnFlag Then
                    Me.lblGetCodeResult.ForeColor = Color.Red
                    Me.lblGetCodeResult.Text = "提取码验证失败！此提取码不能在当前门店使用。"
                    Me.btnOK.Enabled = False
                    frmMain.statusText.Text = "就绪"
                    IWebService.Dispose() : IWebService = Nothing
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                '验证订单金额，卡面值，卡数量
                'If ecir.ExtractingCodeInfoData.BillTotalAmount <> _
                'ecir.ExtractingCodeInfoData.ExtractingCodeInfoDetailData.CardPrice _
                '* ecir.ExtractingCodeInfoData.ExtractingCodeInfoDetailData.ProductNum Then
                '    Me.lblGetCodeResult.ForeColor = Color.Red
                '    Me.lblGetCodeResult.Text = "提取码验证失败！订单金额<>卡面值*卡数量。"
                '    Me.btnOK.Enabled = False
                '    frmMain.statusText.Text = "就绪"
                '    IWebService.Dispose() : IWebService = Nothing
                '    Me.Cursor = Cursors.Default
                '    Exit Sub
                'End If
                '验证购买渠道
                If ecir.ExtractingCodeInfoData.BillBuyChannel Is Nothing Then
                    Me.lblGetCodeResult.ForeColor = Color.Red
                    Me.lblGetCodeResult.Text = "提取码验证失败！从银商获取购买渠道失败。"
                    Me.btnOK.Enabled = False
                    frmMain.statusText.Text = "就绪"
                    IWebService.Dispose() : IWebService = Nothing
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If

                Dim bBuyChannel As Boolean = False
                For Each channelRow As DataRow In dtCityBillBuyChannel.Rows
                    If channelRow("BillBuyChannel").ToString.ToUpper = ecir.ExtractingCodeInfoData.BillBuyChannel.ToUpper Then
                        bBuyChannel = True
                        Exit For
                    End If
                Next
                If bBuyChannel Then
                    '保存到数据库
                    If SaveBill(ecir) Then
                        Me.lblGetCodeResult.ForeColor = Color.Blue
                        Me.lblGetCodeResult.Text = "提取码验证成功！"
                        Me.btnOK.Enabled = True
                    Else
                        Me.lblGetCodeResult.ForeColor = Color.Red
                        Me.lblGetCodeResult.Text = "提取码验证失败！保存提取码信息失败。"
                        Me.btnOK.Enabled = False
                    End If
                Else
                    Me.lblGetCodeResult.ForeColor = Color.Red
                    Me.lblGetCodeResult.Text = "提取码验证失败！请核对城市允许的购买渠道。"
                    Me.btnOK.Enabled = False
                End If
            Else
                Me.lblGetCodeResult.ForeColor = Color.Red
                Me.lblGetCodeResult.Text = "提取码验证失败！" & ecir.CodeMsg.Msg
                Me.btnOK.Enabled = False
            End If

            frmMain.statusText.Text = "就绪"
            IWebService.Dispose() : IWebService = Nothing
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show("因为CUL系统故障，无法进行验证操作！ 下面是CUL系统的内部错误提示：    " & Chr(13) & Chr(13) & ex.Message & Space(4), "出现CUL系统故障！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "因为CUL系统故障，无法进行验证操作！"
            If IWebService IsNot Nothing Then IWebService.Dispose() : IWebService = Nothing
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub frmCheckInternetSales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            'modify code 044:start-------------------------------------------------------------------------
            'GetBillBuyChannelByCityID(sCityID)
            'modify code 044:end-------------------------------------------------------------------------
            If dtCityBillBuyChannel Is Nothing OrElse dtCityBillBuyChannel.Rows.Count = 0 Then
                MessageBox.Show("当前城市没有设置城市支持的购买渠道，不能创建线下提卡销售单！    " & Chr(13) & Chr(13) & "请找系统管理员设置购买渠道。    ", "未发现购买渠道！", MessageBoxButtons.OK)
                Me.Dispose() : Return
            End If
            GetAreaCode(sCityID, sStoreID)
            If dtAreaCode Is Nothing OrElse dtAreaCode.Rows.Count = 0 Then
                MessageBox.Show("当前城市或门店没有设置对应的区域代码，不能创建线下提卡销售单！    " & Chr(13) & Chr(13) & "请找系统管理员设置。    ", "未发现必要设置！", MessageBoxButtons.OK)
                Me.Dispose()
                Return
            End If
            If dtAreaCode.Rows(0)("CanSelling") = 0 Then
                MessageBox.Show("当前门店不允许线下提卡！    " & Chr(13) & Chr(13) & "请找系统管理员设置。    ", "不能线下提卡！", MessageBoxButtons.OK)
                Me.Dispose()
                Return
            End If
        Catch
            Me.Dispose() : Return
        End Try

        Me.txtExtractingCode.Text = ""
        Me.txtHolderMobilePhone.Text = ""
        InitBillInfo()
        Me.lblGetCodeResult.Text = ""
        Me.btnOK.Enabled = False

        Me.txtExtractingCode.Select()

    End Sub

    Private Sub InitBillInfo()
        '订单信息
        Me.txtStatus.Text = ""
        Me.txtBillBuyChannel.Text = ""
        Me.txtBillNo.Text = ""
        Me.txtBillTotalAmount.Text = ""
        Me.txtBillPayTotalAmount.Text = ""
        '换卡信息
        Me.txtBillType.Text = ""
        Me.txtCardPrice.Text = ""
        Me.txtProductNum.Text = ""
    End Sub

    Private Function SaveBill(ByVal result As InternetWebService.ExtractingCodeInfoResponse) As Boolean
        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            'MessageBox.Show("保存订单信息失败。", "保存失败！", MessageBoxButtons.OK)
            Return False
        End If
        Try
            With result.ExtractingCodeInfoData
                If DB.GetDataTable("select * from InternetSales where Type = '换卡' and BILLNO = '" & .BillNo & "'").Rows.Count > 0 Then
                    DB.ModifyTable("delete from InternetSales where Type = '换卡' and BILLNO = '" & .BillNo & "'")
                End If
                DB.ModifyTable("insert into InternetSales (Type,EXTRACTINGCODE,STATUS,HOTREASON,ISSUERID" _
                           & ",BILLNO,BILLTOTALAMOUNT,BILLPAYTOTALAMOUNT,BILLTOTALNUM,BILLPAYSTATUS" _
                           & ",BILLTYPE,BILLCREATETIMESTAMP,BILLBUYCHANNEL,BUYERMOBILEPHONE,HOLDERMOBILEPHONE" _
                           & ",CREATETIME,UPDATETIME" _
                           & ",PRODUCTID,AREACODE,PRODUCTNAME,DETAIL_STATUS,CARDPRICE,PRODUCTNUM,PAYAMOUNT)" _
                           & " values('换卡','" & .ExtractingCode & "','" & .Status & "','" & .HotReason & "','" & .IssuerId & "'" _
                           & ",'" & .BillNo & "'," & .BillTotalAmount & "," & .BillPayTotalAmount & "," & .BillTotalNum & ",'" & .BillPayStatus & "'" _
                           & ",'" & .BillType & "','" & ConvertStrToDatetime(.BillCreateTimestamp) & "','" & .BillBuyChannel & "','" & .BuyerMobilePhone & "','" & .HolderMobilePhone & "'" _
                           & ",'" & ConvertStrToDatetime(.CreateTime) & "','" & ConvertStrToDatetime(.UpdateTime) & "'" _
                           & ",'" & .ExtractingCodeInfoDetailData.ProductId & "','" & .ExtractingCodeInfoDetailData.AreaCode & "'" _
                           & ",'" & .ExtractingCodeInfoDetailData.ProductName & "','" & .ExtractingCodeInfoDetailData.Status & "'" _
                           & "," & .ExtractingCodeInfoDetailData.CardPrice & "," & .ExtractingCodeInfoDetailData.ProductNum & "," & .ExtractingCodeInfoDetailData.PayAmount & ")")
            End With
            DB.Close()
            Return True
        Catch ex As Exception
            DB.Close()
            Return False
        End Try
    End Function

    Private Function ConvertStrToDatetime(ByVal sStr As String) As String
        If sStr = "" Then
            Return ""
        ElseIf IsDate(sStr) Then
            Return sStr
        Else
            Return sStr.Substring(0, 4) & "-" & sStr.Substring(4, 2) & "-" & sStr.Substring(6, 2) _
            & " " & sStr.Substring(8, 2) & ":" & sStr.Substring(10, 2) & ":" & sStr.Substring(12)
        End If
    End Function

    'modify code 044:start-------------------------------------------------------------------------
    'Public Sub GetBillBuyChannelByCityID(ByVal parmCityID As String)
    '    Dim DB As New DataBase
    '    DB.Open()
    '    If Not DB.IsConnected Then
    '        frmMain.statusText.Text = "系统因连接不到数据库而无法创建线下提卡销售单。请检查数据库连接。"
    '        Me.Close() : Return
    '    End If

    '    Try
    '        dtCityBillBuyChannel = DB.GetDataTable("Select * From City_BillBuyChannel Where CityID=" & parmCityID).Copy
    '        DB.Close()
    '    Catch ex As Exception
    '        DB.Close()
    '    End Try
    'End Sub
    'modify code 044:end-------------------------------------------------------------------------

    Private Function GetSalesBillID() As String
        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法查询订单发票信息。"
            Return ""
        End If
        Try
            Dim dtSalesBillID As DataTable = Nothing
            dtSalesBillID = DB.GetDataTable("select SalesBillID from InternetSales where Type = '换卡' and EXTRACTINGCODE = '" & Me.txtExtractingCode.Text.Trim & "' and HOLDERMOBILEPHONE = '" & Me.txtHolderMobilePhone.Text.Trim & "'")
            If dtSalesBillID Is Nothing OrElse dtSalesBillID.Rows.Count = 0 Then
                Return ""
            ElseIf dtSalesBillID.Rows(0)("SalesBillID").ToString = "-1" Then
                Return ""
            Else
                Return dtSalesBillID.Rows(0)("SalesBillID").ToString
            End If
            DB.Close()
        Catch ex As Exception
            DB.Close()
            Return ""
        End Try
    End Function

    Private Sub GetAreaCode(ByVal parmCityID As String, ByVal parmStoreID As String)
        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法创建线下提卡销售单。请检查数据库连接。"
            Me.Close() : Return
        End If

        Try
            Dim dtStoreAreaCode As DataTable = DB.GetDataTable("select M.IssuerID from CULMerchantList M join AreaList A on A.CULStoreCode = M.MerchantNo where A.AreaID = " & parmStoreID)
            If dtStoreAreaCode Is Nothing OrElse dtStoreAreaCode.Rows.Count = 0 Then
                DB.Close()
                Return
            End If
            'dtAreaCode = DB.GetDataTable("Select * From City_AreaCode Where CityID=" & parmCityID & " and AreaCode = '" & dtStoreAreaCode.Rows(0)("IssuerID").ToString & "'").Copy
            dtAreaCode = DB.GetDataTable("Select * From City_AreaCode Where CityID=" & parmCityID).Copy
            DB.Close()
        Catch ex As Exception
            DB.Close()
        End Try
    End Sub
End Class
'modify code 040:end-------------------------------------------------------------------------