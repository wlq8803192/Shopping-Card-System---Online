
'modify code 040:
'date;2014/11/5
'auther:Hyron bjy 
'remark:新增销售单类型---线下提卡销售单

'modify code 040:start-------------------------------------------------------------------------
Public Class frmInternetSalesInvoice

    Private IWebService As InternetWebService.Service = Nothing
    Private oai As InternetWebService.OrderAllInfo = Nothing
    Public oair As InternetWebService.OrderAllInfoResponse = Nothing

    Public sCityID As String = "", sStoreID As String = ""
    Private sIssuerId As String = frmMain.sIssuerId
    Private dtAreaCode As DataTable = Nothing

    Public dtInvoice As DataTable = Nothing
    Public drInternalPayer As DataRow = Nothing
    Public dtInvoiceLayout As DataTable = Nothing, dtInvoiceItem As DataTable = Nothing
    Public drInvoicePrintable As DataRow = Nothing
    Public blInvoicePrinterMultiUser As Boolean = False, iDifferenceSeconds As Integer = 0
    Public sInvoiceCode As String = "", sInvoiceNo As String = "", sInvoicePrinterDevice As String
    Public sBillNo As String = ""
    Public drBillInfo As DataRow = Nothing

    Private sCustomID As String = ""
    Private dtDropdownCustomer As DataTable = Nothing, boolNeedDropdown As Boolean = False

    Private Sub frmInternetSalesInvoice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打开网上售卖开票窗口。请检查数据库连接。"
            Me.Activate() : Me.Cursor = Cursors.Default : Return
        End If

        '打开界面必要条件
        Try
            '必须门店用户
            If frmMain.sLoginAreaType = "S" Then
                sCityID = frmMain.dtLoginStructure.Rows.Find(frmMain.sLoginAreaID)("ParentAreaID").ToString
                sStoreID = frmMain.sLoginAreaID
            Else
                DB.Close() : Me.Dispose()
                Return
            End If
            '必须获取城市打印发票权限
            Dim dtInovicePrintable As DataTable = DB.GetDataTable("Select * From InvoicePrintable Where CityID=" & sCityID)
            If dtInovicePrintable.Rows.Count = 0 Then
                DB.Close() : Me.Dispose()
                Return
            Else
                drInvoicePrintable = dtInovicePrintable.Copy.Rows(0)
            End If
            dtInovicePrintable.Dispose() : dtInovicePrintable = Nothing
        Catch
            DB.Close() : Me.Dispose()
            Return
        End Try

        '开票辅助信息
        Try
            '获取收款单位信息
            Dim dtInternalPayer As DataTable = DB.GetDataTable("Select I.* From InternalPayerStore As I Inner Join AreaScope(" & frmMain.sLoginUserID & ") As S On I.StoreID = S.AreaID Order By S.SortCode")
            If dtInternalPayer.Rows.Count <= 0 Then
                DB.Close() : Me.Dispose()
                Return
            Else
                drInternalPayer = dtInternalPayer.Rows(0)
            End If
            '获取品项
            dtInvoiceItem = DB.GetDataTable("Select C.CityID,C.ItemID,I.Content From InvoiceCityItem As C Join InvoiceItemList As I On C.ItemID=I.ItemID Where C.CityID=" & sCityID)
            '获取发票布局
            dtInvoiceLayout = DB.GetDataTable("Select * From InvoiceLayout Where StoreID=" & sStoreID)
            '获取发票信息
            dtInvoice = DB.GetDataTable("Exec GetInternetSalesInvoice @BillNo = ''")
            dtInvoice.DefaultView.Sort = "RowID"
        Catch
            DB.Close() : Me.Dispose()
            Return
        End Try

        '获取数据库服务器与本机的时间差
        Try
            iDifferenceSeconds = DateDiff(DateInterval.Second, DB.GetDataTable("Select GetDate()").Rows(0)(0), Now())
        Catch
            iDifferenceSeconds = 0
        End Try

        Try
            '获取打印机设备
            GetInvoicePrinterDevice()
            '获取发票号
            Dim drInvoiceCodeNo As DataRow = DB.GetDataTable("Select LastInvoiceCode,LastInvoiceNo From InvoiceCodeNo Where StoreID=" & sStoreID & " And PrinterDevice='" & sInvoicePrinterDevice.Replace("'", "''") & "'").Rows(0)
            sInvoiceCode = drInvoiceCodeNo("LastInvoiceCode").ToString
            sInvoiceNo = (CLng(drInvoiceCodeNo("LastInvoiceNo").ToString) + 1).ToString
            If sInvoiceNo.Length < drInvoiceCodeNo("LastInvoiceNo").ToString.Length Then sInvoiceNo = StrDup(drInvoiceCodeNo("LastInvoiceNo").ToString.Length - sInvoiceNo.Length, "0") & sInvoiceNo
        Catch
            sInvoiceCode = "" : sInvoiceNo = ""
        End Try

        Try
            dtDropdownCustomer = DB.GetDataTable("Exec GetMatchedCustomerWhenSellCard " & frmMain.sLoginUserID & ",''")
            dtDropdownCustomer.DefaultView.Sort = "CustomerName"
        Catch
            dtDropdownCustomer = New DataTable
            dtDropdownCustomer.Columns.Add("CustomerID", System.Type.GetType("System.String"))
            dtDropdownCustomer.Columns.Add("CustomerName", System.Type.GetType("System.String"))
        End Try

        Try
            GetAreaCode(sCityID, sStoreID)
            If dtAreaCode Is Nothing OrElse dtAreaCode.Rows.Count = 0 Then
                MessageBox.Show("当前城市或门店没有设置对应的区域代码，不能开票！    " & Chr(13) & Chr(13) & "请找系统管理员设置。    ", "未发现必要设置！", MessageBoxButtons.OK)
                DB.Close() : Me.Dispose()
                Return
            End If
            If dtAreaCode.Rows(0)("CanInvoice") = 0 Then
                MessageBox.Show("当前门店不允许开票！    " & Chr(13) & Chr(13) & "请找系统管理员设置。    ", "不能开票！", MessageBoxButtons.OK)
                DB.Close() : Me.Dispose()
                Return
            End If
        Catch
            DB.Close() : Me.Dispose()
            Return
        End Try

        DB.Close()

        Me.txtBillNo.Text = ""
        Me.txtBillTotalAmount.Text = ""
        Me.txtBillPayTotalAmount.Text = ""

        Me.grbInvoiceDevice.Visible = False
        Me.txtInvoiceNo.Text = ""

        Me.grbCustom.Visible = True
        Me.grbCustom.Left = 14
        Me.grbCustom.Top = 99
        Me.rdo0.Checked = True
        Me.rdo1.Checked = False
        Me.grbCompany.Enabled = False
        With cbbCustomerName
            .DataSource = dtDropdownCustomer
            .ValueMember = "CustomerID"
            .DisplayMember = "CustomerName"
            .SelectedIndex = -1
        End With
        Me.txtTitle.Text = "（个人）"

        Me.lblGetBillResult.Text = ""

        Me.btnOK.Text = "打印发票"
        Me.btnOK.Enabled = False
        Me.btnConfigInvoice.Enabled = False
    End Sub

    Private Sub btnVerify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerify.Click
        Dim sInvoiceNo As String = ""

        If Me.txtBillNo.Text.Trim = "" Then
            MessageBox.Show("请输入定单号！", "请输入！", MessageBoxButtons.OK)
            Exit Sub
        End If

        Me.oair = Nothing
        sBillNo = ""

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在到CUL执行验证提取码操作……"

        Try
            '清空
            Me.txtBillTotalAmount.Text = ""
            Me.txtBillPayTotalAmount.Text = ""
            Me.grbInvoiceDevice.Visible = False
            Me.txtInvoiceNo.Text = ""
            Me.grbCustom.Visible = True
            Me.grbCustom.Left = 14
            Me.grbCustom.Top = 99
            Me.rdo0.Checked = True
            Me.rdo1.Checked = False
            Me.grbCompany.Enabled = False
            Me.txtTitle.Text = "（个人）"
            Me.lblGetBillResult.Text = ""
            Me.btnOK.Text = "打印发票"
            Me.btnOK.Enabled = False
            Me.btnConfigInvoice.Enabled = False

            If drInvoicePrintable("CanPrintInvoice") = 0 Then '验证城市是否在本系统开票
                sInvoiceNo = CheckInvoiceNo()
                If sInvoiceNo = "" Then
                    Me.btnOK.Text = "保存发票号"
                Else
                    Me.btnOK.Text = "修改发票号"
                End If
            Else
                If CheckInvoice() Then '检查订单是否已有开票记录
                    Me.btnOK.Text = "查看发票"
                Else
                    Me.btnOK.Text = "打印发票"
                End If
            End If

            If Me.btnOK.Text = "查看发票" Then
                GetBill()
                If oair Is Nothing Then
                    Me.txtBillTotalAmount.Text = ""
                    Me.txtBillPayTotalAmount.Text = ""

                    Me.lblGetBillResult.ForeColor = Color.Red
                    Me.lblGetBillResult.Text = "订单验证失败！" & Chr(13) & "此订单已开发票，发票信息获取失败。" & Chr(13) & "请重新验证。"
                    Me.btnOK.Enabled = False
                    Me.btnConfigInvoice.Enabled = False
                Else
                    With oair
                        Me.txtBillTotalAmount.Text = .OrderAllInfoData.BillTotalAmount
                        Me.txtBillPayTotalAmount.Text = .OrderAllInfoData.BillPayTotalAmount
                    End With
                    Me.grbCustom.Enabled = False
                    Me.lblGetBillResult.ForeColor = Color.Blue
                    Me.lblGetBillResult.Text = "订单验证成功！" & Chr(13) & "此订单已开发票，发票信息获取成功。"
                    Me.btnOK.Enabled = True
                    Me.btnConfigInvoice.Enabled = True
                End If
            ElseIf Me.btnOK.Text = "修改发票号" Then
                Me.grbInvoiceDevice.Visible = True
                Me.grbInvoiceDevice.Left = 14
                Me.grbInvoiceDevice.Top = 99
                Me.txtInvoiceNo.Text = sInvoiceNo
                Me.grbCustom.Visible = False

                Me.lblGetBillResult.ForeColor = Color.Blue
                Me.lblGetBillResult.Text = "订单验证成功！" & "请正确输入第三方发票号，并修改。"
                sBillNo = Me.txtBillNo.Text.Trim
                Me.btnOK.Enabled = True
                Me.btnConfigInvoice.Enabled = False
            Else
                '本地开票和第三方开票都需要先到银商验证订单
                IWebService = New InternetWebService.Service
                oai = New InternetWebService.OrderAllInfo
                With oai
                    .IssuerId = sIssuerId
                    '.BillNo = "1416293272466665811"
                    .BillNo = Me.txtBillNo.Text.Trim
                End With
                oair = IWebService.QueryOrderAllInfo(oai)
                If oair.CodeMsg.Code = "00" Then '查询成功
                    If oair.OrderAllInfoData.BillTotalAmount Is Nothing Or oair.OrderAllInfoData.BillPayTotalAmount Is Nothing Then
                        Me.lblGetBillResult.ForeColor = Color.Red
                        Me.lblGetBillResult.Text = "提取码验证失败！银商提供订单金额信息不足。"
                        Me.btnOK.Enabled = False
                        frmMain.statusText.Text = "就绪"
                        IWebService.Dispose() : IWebService = Nothing
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    Dim myCardTransInfo As InternetWebService.CardTransInfo = oair.OrderAllInfoData.CardTransInfoArray(0)
                    If myCardTransInfo.AreaCode Is Nothing OrElse myCardTransInfo.AreaCode = "" Then
                        Me.lblGetBillResult.ForeColor = Color.Red
                        Me.lblGetBillResult.Text = "提取码验证失败！银商提供区域代码信息不足。"
                        Me.btnOK.Enabled = False
                        frmMain.statusText.Text = "就绪"
                        IWebService.Dispose() : IWebService = Nothing
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    '验证区域代码
                    Dim returnFlag As Boolean = False
                    Dim i As Integer
                    For i = 0 To dtAreaCode.Rows.Count - 1
                        If myCardTransInfo.AreaCode.ToUpper = dtAreaCode.Rows(i)("AreaCode").ToString.ToUpper Then
                            returnFlag = True
                            Exit For
                        End If
                    Next

                    'If myCardTransInfo.AreaCode.ToUpper <> dtAreaCode.Rows(0)("AreaCode").ToString.ToUpper Then
                    If Not returnFlag Then
                        Me.lblGetBillResult.ForeColor = Color.Red
                        Me.lblGetBillResult.Text = "提取码验证失败！此提取码不能在当前门店使用。"
                        Me.btnOK.Enabled = False
                        frmMain.statusText.Text = "就绪"
                        IWebService.Dispose() : IWebService = Nothing
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    With oair
                        Me.txtBillTotalAmount.Text = .OrderAllInfoData.BillTotalAmount
                        Me.txtBillPayTotalAmount.Text = .OrderAllInfoData.BillPayTotalAmount
                    End With
                    '保存到数据库
                    If SaveBill(oair) Then
                        If Me.btnOK.Text = "保存发票号" Then
                            Me.grbInvoiceDevice.Visible = True
                            Me.grbInvoiceDevice.Left = 14
                            Me.grbInvoiceDevice.Top = 99
                            Me.grbCustom.Visible = False
                        End If
                        Me.lblGetBillResult.ForeColor = Color.Blue
                        Me.lblGetBillResult.Text = "订单验证成功！"
                        If Me.btnOK.Text = "保存发票号" Then Me.lblGetBillResult.Text = Me.lblGetBillResult.Text & "请正确输入第三方发票号，并保存。"
                        sBillNo = Me.txtBillNo.Text.Trim
                        Me.btnOK.Enabled = True
                        If Me.btnOK.Text = "打印发票" Then Me.btnConfigInvoice.Enabled = True
                    Else
                        Me.lblGetBillResult.ForeColor = Color.Red
                        Me.lblGetBillResult.Text = "订单验证失败！保存订单信息失败。"
                        Me.btnOK.Enabled = False
                        Me.btnConfigInvoice.Enabled = False
                    End If
                Else
                    Me.lblGetBillResult.ForeColor = Color.Red
                    Me.lblGetBillResult.Text = "订单验证失败！" & oair.CodeMsg.Msg
                    Me.btnOK.Enabled = False
                    Me.btnConfigInvoice.Enabled = False
                End If
                IWebService.Dispose() : IWebService = Nothing

            End If

            frmMain.statusText.Text = "就绪"
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show("因为CUL系统故障，无法进行验证操作！ 下面是CUL系统的内部错误提示：    " & Chr(13) & Chr(13) & ex.Message & Space(4), "出现CUL系统故障！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "因为CUL系统故障，无法进行验证操作！"
            If IWebService IsNot Nothing Then IWebService.Dispose() : IWebService = Nothing
            Me.Cursor = Cursors.Default : Return
        End Try

    End Sub

    Private Function CheckInvoice() As Boolean
        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法查询订单发票信息。"
            Return False
        End If
        Try
            If DB.GetDataTable("select * from InternetSalesInvoice where BILLNO = '" & Me.txtBillNo.Text.Trim & "'").Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
            DB.Close()
        Catch ex As Exception
            DB.Close()
            Return False
        End Try
    End Function

    Private Function CheckInvoiceNo() As String
        Dim dtInvoiceNo As DataTable = Nothing
        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法查询订单发票信息。"
            Return False
        End If
        Try
            dtInvoiceNo = DB.GetDataTable("select InvoiceNo from InternetSales where Type = '开票' and BILLNO = '" & Me.txtBillNo.Text.Trim & "'")
            If dtInvoiceNo Is Nothing OrElse dtInvoiceNo.Rows.Count = 0 Then
                Return ""
            Else
                Return dtInvoiceNo.Rows(0)("InvoiceNo").ToString
            End If
            DB.Close()
        Catch ex As Exception
            DB.Close()
            Return ""
        End Try
    End Function

    Private Sub GetBill()
        Dim dtBill As DataTable = Nothing

        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法查询订单发票信息。"
        End If
        Try
            dtBill = DB.GetDataTable("select * from InternetSales where Type = '开票' and BILLNO = '" & Me.txtBillNo.Text.Trim & "'")
            If dtBill Is Nothing OrElse dtBill.Rows.Count = 0 Then
                DB.Close()
                Return
            End If

            oair = New InternetWebService.OrderAllInfoResponse()
            oair.OrderAllInfoData = New InternetWebService.OrderAllInfoData

            With oair.OrderAllInfoData
                Dim drBill As DataRow = dtBill.Rows(0)
                .IssuerId = drBill("ISSUERID")
                .BillNo = drBill("BILLNO")
                .BillTotalAmount = drBill("BILLTOTALAMOUNT")
                .BillPayTotalAmount = drBill("BILLPAYTOTALAMOUNT")
                .BillTotalNum = drBill("BILLTOTALNUM")
                .BillPayStatus = drBill("BILLPAYSTATUS")
                .BillType = drBill("BILLTYPE")
                .BillCreateTimestamp = drBill("BILLCREATETIMESTAMP")
                .BillBuyChannel = drBill("BILLBUYCHANNEL")
                .BuyerMobilePhone = drBill("BUYERMOBILEPHONE")
                .HolderMobilePhone = drBill("HOLDERMOBILEPHONE")
                .CreateTime = drBill("CREATETIME")
                .UpdateTime = drBill("UPDATETIME")
                For iCount As Integer = 0 To dtBill.Rows.Count - 1
                    Array.Resize(.CardTransInfoArray, iCount + 1)
                    .CardTransInfoArray(iCount) = New InternetWebService.CardTransInfo
                    With .CardTransInfoArray(iCount)
                        .ProductId = dtBill.Rows(iCount)("PRODUCTID")
                        .AreaCode = dtBill.Rows(iCount)("AREACODE")
                        .ProductName = dtBill.Rows(iCount)("PRODUCTNAME")
                        .Amount = dtBill.Rows(iCount)("CARDPRICE")
                        .ProductNum = dtBill.Rows(iCount)("PRODUCTNUM")
                        .PayAmount = dtBill.Rows(iCount)("PAYAMOUNT")
                        .CardNo = dtBill.Rows(iCount)("CARDNO")
                        .CardHolderMobile = dtBill.Rows(iCount)("CARDHOLDERMOBILE")
                        .PromotionAmount = dtBill.Rows(iCount)("PROMOTIONAMOUNT")
                    End With
                Next
            End With
            '获取订单附加信息
            Dim dtBillInfo As DataTable = dtBill.DefaultView.ToTable(False, "PrintedInvoiceAMT", "InvoicePrintedTimes", "InvoicePrinterID", "InvoicePrinterName", "InvoicePrintedTime")
            drBillInfo = dtBillInfo.Rows(0)
            '获取已开发票信息
            dtInvoice = DB.GetDataTable("Exec GetInternetSalesInvoice @BillNo = '" & oair.OrderAllInfoData.BillNo & "'")
            dtInvoice.DefaultView.Sort = "RowID"

            DB.Close()
        Catch ex As Exception
            DB.Close()
        End Try
    End Sub

    Private Function SaveBill(ByVal result As InternetWebService.OrderAllInfoResponse) As Boolean
        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法保存订单信息失败。"
            Return False
        End If
        Try
            With result.OrderAllInfoData
                If DB.GetDataTable("select * from InternetSales where Type = '开票' and BILLNO = '" & .BillNo & "'").Rows.Count > 0 Then
                    DB.ModifyTable("delete from InternetSales where Type = '开票' and BILLNO = '" & .BillNo & "'")
                End If
                For i As Integer = 0 To .CardTransInfoArray.Length - 1
                    DB.ModifyTable("insert into InternetSales (Type,ISSUERID" _
                               & ",BILLNO,BILLTOTALAMOUNT,BILLPAYTOTALAMOUNT,BILLTOTALNUM,BILLPAYSTATUS" _
                               & ",BILLTYPE,BILLCREATETIMESTAMP,BILLBUYCHANNEL,BUYERMOBILEPHONE,HOLDERMOBILEPHONE" _
                               & ",CREATETIME,UPDATETIME" _
                               & ",PRODUCTID,AREACODE,PRODUCTNAME,CARDPRICE,PRODUCTNUM,PAYAMOUNT" _
                               & ",CARDNO,CARDHOLDERMOBILE,PROMOTIONAMOUNT)" _
                               & " values('开票','" & .IssuerId & "'" _
                               & ",'" & .BillNo & "'," & .BillTotalAmount & "," & .BillPayTotalAmount & "," & .BillTotalNum & ",'" & .BillPayStatus & "'" _
                               & ",'" & .BillType & "','" & ConvertStrToDatetime(.BillCreateTimestamp) & "','" & .BillBuyChannel & "','" & .BuyerMobilePhone & "','" & .HolderMobilePhone & "'" _
                               & ",'" & ConvertStrToDatetime(.CreateTime) & "','" & ConvertStrToDatetime(.UpdateTime) & "'" _
                               & ",'" & .CardTransInfoArray(i).ProductId & "','" & .CardTransInfoArray(i).AreaCode & "'" _
                               & ",'" & .CardTransInfoArray(i).ProductName & "'" _
                               & "," & .CardTransInfoArray(i).Amount & "," & .CardTransInfoArray(i).ProductNum & "," & .CardTransInfoArray(i).PayAmount _
                               & ",'" & .CardTransInfoArray(i).CardNo & "','" & .CardTransInfoArray(i).CardHolderMobile & "'," & .CardTransInfoArray(i).PromotionAmount & ")")
                Next
            End With
            DB.Close()
            Return True
        Catch ex As Exception
            DB.Close()
            Return False
        End Try
    End Function

    Private Function SaveCustom() As Boolean
        If sBillNo = "" Then Return False

        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法保存订单信息失败。"
            Return False
        End If
        Try
            DB.ModifyTable("update InternetSales set CustomID = " & sCustomID & " where  Type = '开票' and BILLNO = '" & sBillNo & "'")
            DB.Close()
            Return True
        Catch ex As Exception
            DB.Close()
            Return False
        End Try
    End Function

    Private Function SaveInvoiceNo() As Boolean
        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法保存订单信息失败。"
            Return False
        End If
        Try
            DB.ModifyTable("update InternetSales set InvoiceNo = " & Me.txtInvoiceNo.Text.Trim & " where Type = '开票' and BILLNO = '" & sBillNo & "'")
            DB.Close()
            Return True
        Catch ex As Exception
            DB.Close()
            Return False
        End Try
    End Function

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        If Me.btnOK.Text = "保存发票号" OrElse Me.btnOK.Text = "修改发票号" Then
            If Me.txtInvoiceNo.Text.Trim = "" Then
                MessageBox.Show("请输入发票号！", "没有发票号", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If
            If SaveInvoiceNo() Then
                Me.lblGetBillResult.ForeColor = Color.Blue
                Me.lblGetBillResult.Text = "发票号保存成功！"
            Else
                Me.lblGetBillResult.ForeColor = Color.Red
                Me.lblGetBillResult.Text = "发票号保存失败！"
            End If
            Exit Sub
        End If

        If frmMain.dtAllowedRight.Select("RightName='E-CardInvoice'").Length = 0 Then
            Me.btnOK.Enabled = False
            Me.btnConfigInvoice.Enabled = False
            MessageBox.Show("当前用户没有打印发票的权限！", "没有权限", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If Me.btnOK.Text = "打印发票" AndAlso Me.txtTitle.Text = "" Then
            MessageBox.Show("请输入发票抬头！", "没有发票抬头", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If sCustomID <> "" Then
            If Not SaveCustom() Then
                MessageBox.Show("保存客户ＩＤ失败！", "保存客户", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If
        End If

        Dim sTask As String = IIf(Me.btnOK.Text.IndexOf("打印") = 0, "打印", "查看")
        frmMain.statusText.Text = "正在打开发票" & sTask & "窗口……"
        frmMain.statusMain.Refresh()

        If dtInvoice Is Nothing Or dtInvoiceItem Is Nothing Or dtInvoiceLayout Is Nothing Then
            frmMain.statusText.Text = "打开发票" & sTask & "窗口失败！"
            Me.Activate() : Return
        End If

        Dim dmTotalChargedAMT As Decimal = oair.OrderAllInfoData.BillTotalAmount
        Dim dmTotalPaymentAMT As Decimal = oair.OrderAllInfoData.BillPayTotalAmount
        Dim dmTotalPrintedInvoiceAMT As Decimal = 0
        If Not drBillInfo Is Nothing Then dmTotalPrintedInvoiceAMT = drBillInfo("PrintedInvoiceAMT")

        With frmInternetSalesPrintInvoice
            .Text = sTask & "发票："
            .dmTotalChargedAMT = dmTotalChargedAMT
            .dmTotalRebateAMT = 0
            .txbTotalPaymentAMT.Text = Format(dmTotalPaymentAMT, "#,0.00")
            .txbTotalPrintedInvoiceAMT.Text = Format(dmTotalPrintedInvoiceAMT, "#,0.00")
            .sCarrefourName = drInternalPayer("PayeeName").ToString
            .sReceiverTaxNo = drInternalPayer("ReceiverTaxNo").ToString
            If sTask = "查看" Then
                .grbAvailableInvoiceAMT.Text = "发票金额汇总："
                .lblAvailableInvoiceAMT.Text = "未打印发票金额："
            End If
            .txbAvailableInvoiceAMT.Text = Format(dmTotalPaymentAMT - dmTotalPrintedInvoiceAMT, "#,0.00")
            .txbInvoiceTitle.Text = Me.txtTitle.Text.Trim
            .txbInvoiceCode.Text = sInvoiceCode
            .txbInvoiceNo.Text = sInvoiceNo
            .ShowDialog()
            If sTask = "打印" Then
                dmTotalPaymentAMT = CDec(.txbTotalPaymentAMT.Text)
                dmTotalPrintedInvoiceAMT = CDec(.txbTotalPrintedInvoiceAMT.Text)
                If dmTotalPaymentAMT = 0 Then
                    Me.btnOK.Text = "打印发票"
                    Me.btnOK.Enabled = False
                    Me.btnConfigInvoice.Enabled = False
                ElseIf dmTotalPrintedInvoiceAMT = 0 Then
                    Me.btnOK.Text = "打印发票"
                    Me.btnOK.Enabled = (frmMain.dtAllowedRight.Select("RightName='E-CardInvoice'").Length > 0) '当前用户是有权限打印发票的用户
                    Me.btnConfigInvoice.Enabled = Me.btnOK.Enabled
                ElseIf dmTotalPaymentAMT = dmTotalPrintedInvoiceAMT Then
                    Me.btnOK.Text = "查看发票"
                    Me.btnOK.Enabled = True
                    Me.btnConfigInvoice.Enabled = True
                Else
                    If frmMain.dtAllowedRight.Select("RightName='E-CardInvoice'").Length > 0 Then
                        Me.btnOK.Text = "打印发票"
                    Else
                        Me.btnOK.Text = "查看发票"
                    End If
                    Me.btnOK.Enabled = True
                    Me.btnConfigInvoice.Enabled = True
                End If
            End If
            .Dispose()
        End With
        Me.Activate()
    End Sub

    Private Function ConvertStrToDatetime(ByVal sStr As String) As String
        If sStr = "" Then
            Return ""
        Else
            Return sStr.Substring(0, 4) & "-" & sStr.Substring(4, 2) & "-" & sStr.Substring(6, 2) _
            & " " & sStr.Substring(8, 2) & ":" & sStr.Substring(10, 2) & ":" & sStr.Substring(12)
        End If
    End Function

    Private Sub GetInvoicePrinterDevice()
        Dim WMI As New System.Management.ManagementObjectSearcher("SELECT * FROM Win32_Printer"), WMER As System.Management.PropertyDataCollection.PropertyDataEnumerator, ipAddress As Net.IPAddress = Nothing
        Dim sPrinterName As String = "", sPortName As String = "", sSystemName As String = ""
        Try
            For Each WMIOBJ As System.Management.ManagementObject In WMI.Get
                WMER = WMIOBJ.Properties.GetEnumerator : sPrinterName = "" : sPortName = "" : sSystemName = ""
                While WMER.MoveNext
                    With WMER.Current
                        If .Name.ToLower = "name" Then sPrinterName = .Value.ToString
                        If .Name.ToLower = "portname" Then sPortName = .Value.ToString
                        If .Name.ToLower = "systemname" Then sSystemName = .Value.ToString
                        If sPrinterName <> "" AndAlso sPortName <> "" AndAlso sSystemName <> "" Then Exit While
                    End With
                End While
                If sPrinterName = My.Settings.InvoicePrinter Then Exit For
            Next
            WMI = Nothing
            If sPortName.ToUpper.IndexOf("IP_") = 0 Then
                sInvoicePrinterDevice = sPortName
            ElseIf Net.IPAddress.TryParse(sPortName, ipAddress) Then
                sInvoicePrinterDevice = "IP_" & sPortName 'Win7环境下的网络打印机本地化为以IP地址为名称的端口名
            ElseIf My.Settings.InvoicePrinter.IndexOf("\\") = 0 Then
                sInvoicePrinterDevice = My.Settings.InvoicePrinter
            Else '将本地打印机表达成网络打印机的形式
                sInvoicePrinterDevice = "\\" & sSystemName & "\" & My.Settings.InvoicePrinter
            End If
        Catch
            sInvoicePrinterDevice = ""
        End Try

    End Sub

    Private Sub rdo0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdo0.Click
        Me.rdo0.Checked = True
        Me.rdo1.Checked = False
        Me.grbCompany.Enabled = False
        Me.txtTitle.Text = "（个人）"
    End Sub

    Private Sub rdo1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdo1.Click
        Me.rdo0.Checked = False
        Me.rdo1.Checked = True
        Me.grbCompany.Enabled = True
        Me.cbbCustomerName.Focus()
        Me.txtTitle.Text = ""
    End Sub

    Private Sub SetDropDownList(ByVal sInputText As String)
        Dim DB As New DataBase
        DB.Open()

        If DB.IsConnected Then
            If dtDropdownCustomer IsNot Nothing Then dtDropdownCustomer.Dispose() : dtDropdownCustomer = Nothing
            dtDropdownCustomer = DB.GetDataTable("Exec GetMatchedCustomerWhenSellCard " & frmMain.sLoginUserID & ",'" & sInputText.Replace("'", "''") & "'")
            dtDropdownCustomer.DefaultView.Sort = "CustomerName"
            DB.Close()

            If dtDropdownCustomer Is Nothing OrElse dtDropdownCustomer.Rows.Count = 0 Then
                dtDropdownCustomer = New DataTable
                dtDropdownCustomer.Columns.Add("CustomerID", System.Type.GetType("System.String"))
                dtDropdownCustomer.Columns.Add("CustomerName", System.Type.GetType("System.String"))
                With cbbCustomerName
                    .DataSource = dtDropdownCustomer
                    .ValueMember = "CustomerID"
                    .DisplayMember = "CustomerName"
                End With
            Else
                '获取下拉框宽度
                Dim sMaxLengthName As String = "", iMaxLength As Int16 = 0, iLength As Int16 = 0, g As Graphics, iDropDownWidth As Int16
                For Each dr As DataRow In dtDropdownCustomer.Rows
                    iLength = System.Text.Encoding.Default.GetByteCount(dr("CustomerName").ToString)
                    If iMaxLength < iLength Then sMaxLengthName = dr("CustomerName").ToString
                Next
                g = Me.cbbCustomerName.CreateGraphics()
                iDropDownWidth = g.MeasureString(sMaxLengthName, Me.cbbCustomerName.Font).Width - 4
                g.Dispose() : g = Nothing
                If Me.cbbCustomerName.DropDownHeight < Me.cbbCustomerName.ItemHeight * Me.cbbCustomerName.Items.Count Then iDropDownWidth += 18
                If iDropDownWidth < Me.cbbCustomerName.Width Then iDropDownWidth = Me.cbbCustomerName.Width
                With cbbCustomerName
                    .DataSource = dtDropdownCustomer
                    .ValueMember = "CustomerID"
                    .DisplayMember = "CustomerName"
                    .DropDownWidth = iDropDownWidth
                    .SelectedIndex = 0
                End With
            End If
        Else
            dtDropdownCustomer = New DataTable
            dtDropdownCustomer.Columns.Add("CustomerID", System.Type.GetType("System.String"))
            dtDropdownCustomer.Columns.Add("CustomerName", System.Type.GetType("System.String"))
            With cbbCustomerName
                .DataSource = dtDropdownCustomer
                .ValueMember = "CustomerID"
                .DisplayMember = "CustomerName"
            End With
        End If
    End Sub

    Private Sub cbbCustomerName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbbCustomerName.KeyPress
        If e.KeyChar <> Convert.ToChar(Keys.Enter) Then Exit Sub
        SetDropDownList(CType(sender, Control).Text)
    End Sub

    Private Sub cbbCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbCustomerName.SelectedIndexChanged
        If Me.grbCompany.Enabled = False Then Exit Sub
        If Me.cbbCustomerName.DataSource Is Nothing OrElse dtDropdownCustomer Is Nothing OrElse dtDropdownCustomer.Rows.Count = 0 Then Exit Sub
        sCustomID = cbbCustomerName.SelectedValue.ToString
        Me.txtTitle.Text = cbbCustomerName.Text
    End Sub

    Private Sub btnNewCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewCustomer.Click
        If frmMain.dtAllowedRight.Select("RightName='CustomerCreate'").Length = 0 Then
            MessageBox.Show("对不起，您无权限创建新客户。    " & Chr(13) & _
                            "Sorry, you have no right to create new Customer.    ", "无权限创建客户 No right to create Customer!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.btnNewCustomer.Enabled = False : Return
        End If

        If frmCustomer.IsHandleCreated Then Return '避免重复打开
        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在打开客户窗口……"
        frmMain.statusMain.Refresh()

        
        frmCustomer.sCustomerNameFromOthers = Me.cbbCustomerName.Text.Trim
        If frmCustomer.sCustomerNameFromOthers = "" Then frmCustomer.sCustomerNameFromOthers = " "

        If frmCustomer.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If frmCustomer.sCustomerID = "-1" Then
                sCustomID = ""
                Me.txtTitle.Text = ""
            Else
                Dim drCustomer As DataRow = frmCustomer.drCustomer.Table.Copy.Rows(0)
                sCustomID = drCustomer("CustomerID").ToString
                Me.txtTitle.Text = drCustomer("CustomerChineseName").ToString
            End If
        End If

        frmCustomer.Dispose()
        Me.Activate()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnConfigInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfigInvoice.Click
        If frmMain.dtAllowedRight.Select("RightName='E-CardInvoice'").Length = 0 Then
            MessageBox.Show("因为您没有打印销售发票的权限，所以您不必要设置发票版面和打印机。    ", "您无须设置发票版面和打印机！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.btnOK.Enabled = False
            Me.btnConfigInvoice.Enabled = False
            Return
        End If

        If Printing.PrinterSettings.InstalledPrinters.Count = 0 Then
            MessageBox.Show("您的电脑未发现打印机！请先安装打印机。    ", "未发现打印机！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "未发现打印机！"
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在打开发票设置窗口……"
        frmMain.statusMain.Refresh()

        If dtInvoiceLayout Is Nothing Then
            frmMain.statusText.Text = "打开发票设置窗口失败！"
            Me.Activate() : Me.Cursor = Cursors.Default : Return
        End If

        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打开发票设置窗口。请检查数据库连接。"
            Me.Activate() : Me.Cursor = Cursors.Default : Return
        End If

        If dtInvoiceLayout.Rows.Count = 0 Then '从同一个城市的其他店复制发票版面
            Try
                Dim dtStore As DataTable = DB.GetDataTable("Select Distinct I.StoreID,I.IsLocked From InvoiceLayout As I Join AreaList As A On I.StoreID=A.AreaID Where A.ParentAreaID=" & sCityID)
                If dtStore.Rows.Count > 0 Then
                    If dtStore.Select("IsLocked=1").Length > 0 Then
                        dtInvoiceLayout = DB.GetDataTable("Select * From InvoiceLayout Where StoreID=" & dtStore.Select("IsLocked=1")(0)("StoreID").ToString)
                    Else
                        dtInvoiceLayout = DB.GetDataTable("Select * From InvoiceLayout Where StoreID=" & dtStore.Rows(0)("StoreID").ToString)
                    End If
                    For Each drItem As DataRow In dtInvoiceLayout.Rows
                        drItem("StoreID") = sStoreID
                        drItem("IsLocked") = 0
                    Next
                End If
                dtStore.Dispose() : dtStore = Nothing
            Catch
                dtInvoiceLayout = Nothing
                frmMain.statusText.Text = "打开发票设置窗口失败！"
                DB.Close()
                Me.Activate() : Me.Cursor = Cursors.Default : Return
            End Try
        End If

        DB.Close()
        dtInvoiceLayout.DefaultView.Sort = "ItemID"

        If dtInvoiceLayout.Rows.Count = 0 Then
            dtInvoiceLayout.Rows.Add(sStoreID, 0, 1, "发票抬头", 10, 10, 30, 1)
            dtInvoiceLayout.Rows.Add(sStoreID, 0, 2, "发票品项", 10, 40, 45, 1)
            dtInvoiceLayout.Rows.Add(sStoreID, 0, 3, "计量数量", 10, 105, 45, 1)
            dtInvoiceLayout.Rows.Add(sStoreID, 0, 4, "计量单价", 10, 120, 45, 1)
            dtInvoiceLayout.Rows.Add(sStoreID, 0, 5, "发票金额", 10, 140, 45, 1)
            dtInvoiceLayout.Rows.Add(sStoreID, 0, 6, "大写总额", 10, 25, 80, 1)
            dtInvoiceLayout.Rows.Add(sStoreID, 0, 7, "付款方式", 10, 125, 90, 1)
            dtInvoiceLayout.Rows.Add(sStoreID, 0, 8, "经手人", 10, 145, 90, 1)
            dtInvoiceLayout.Rows.Add(sStoreID, 0, 9, "开票日期", 10, 135, 15, 1)
            dtInvoiceLayout.Rows.Add(sStoreID, 0, 10, "家乐福小票号（含标题）", 10, 110, 10, 1)
            dtInvoiceLayout.Rows.Add(sStoreID, 0, 11, "购买统计信息（含标题）", 10, 5, 95, 1)
        End If

        frmMain.statusText.Text = "就绪。"
        With frmInternetSalesConfigInvoice
            .sCarrefourName = drInternalPayer("PayeeName").ToString
            .sReceiverTaxNo = drInternalPayer("ReceiverTaxNo").ToString
            If .ShowDialog() = Windows.Forms.DialogResult.Cancel Then dtInvoiceLayout.RejectChanges()
            .Dispose()
        End With
        frmMain.statusText.Text = "就绪。"
        Me.Activate() : Me.Cursor = Cursors.Default
    End Sub

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

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub
End Class
'modify code 040:end-------------------------------------------------------------------------