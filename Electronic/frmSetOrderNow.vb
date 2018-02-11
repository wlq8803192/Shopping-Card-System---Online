Public Class frmSetOrderNow

    Private dvCULParameter As DataView
    Dim dtImportedDetails As New DataTable

    Private Sub frmSetOrderNow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "92" & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "94" & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), frmMain.signCardBin & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
        Next

        Dim DB As New DataBase(), dtResult As DataTable = Nothing
        DB.Open()
        If DB.IsConnected Then
            dtResult = DB.GetDataTable("select t1.ExtraCardBin,t2.AreaID,isnull(t2.CULStoreCode,0) CULStoreCode from CityExtraCardBin_ELC T1 left join (SELECT S.AreaID,  A.ParentAreaID, A.CULStoreCode FROM AreaScope(" & frmMain.sLoginUserID & ") AS S INNER JOIN AreaList AS A ON S.AreaID = A.AreaID) T2 on t1.CityID = t2.ParentAreaID where T2.AreaID is not null")
            If dtResult Is Nothing Then
            ElseIf dtResult.Rows.Count > 0 Then
                For Each drCUL As DataRow In dtResult.Rows
                    dvCULParameter.Table.Rows.Add(drCUL("AreaID"), drCUL("ExtraCardBin"), drCUL("CULStoreCode")).EndEdit()
                Next
            End If
        End If


        dvCULParameter.RowFilter = ""
        dvCULParameter.Table.AcceptChanges()

        If frmSelling.sOrderNo <> "" Then
            Dim preTelePhone As String = "", preEmailNo As String = ""
            Dim dtOrder As DataTable = DB.GetDataTable("select TelePhone,EmailNo from Electronic where OrderNo = '" & frmSelling.sOrderNo & "'")
            If dtOrder.Rows.Count > 0 Then
                preTelePhone = dtOrder.Rows(0)("TelePhone").ToString
                preEmailNo = dtOrder.Rows(0)("EmailNo").ToString

                If preTelePhone <> "" Then
                    Me.txtMobile.Text = preTelePhone
                End If

                If preEmailNo <> "" Then
                    Me.txtEmail.Text = preEmailNo
                End If
            End If
        End If

        DB.Close()
    End Sub

    Private Sub btnFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFile.Click
        Dim excelAPP As Object = Nothing
        Try
            excelAPP = GetObject(, "Excel.Application")
        Catch
        End Try

        If excelAPP Is Nothing Then
            Try
                excelAPP = CreateObject("Excel.Application")
                excelAPP.Visible = False
            Catch ex As Exception
                If excelAPP Is Nothing Then
                    MessageBox.Show("您的电脑还未安装 Microsoft Excel。因此，您无法使用该功能。    ", "请先安装 Microsoft Excel 应用程序。", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    MessageBox.Show("您电脑上的 Microsoft Excel 不能正常使用。因此，您无法使用该功能。    ", "请检查 Microsoft Excel 应用程序或重启电脑。", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    excelAPP = Nothing
                End If
                Return
            End Try
        End If

        Dim openFile As New OpenFileDialog(), sFileName As String = "", sWorkSheet As String = ""
        openFile.Title = "请选择想从中导入购物卡号的源文件（Microsoft Excel 文件）："
        openFile.Filter = "源文件（Microsoft Excel 文件）|*.xls"
        openFile.Multiselect = False
        openFile.RestoreDirectory = True

        If openFile.ShowDialog() = Windows.Forms.DialogResult.OK Then sFileName = openFile.FileName
        openFile.Dispose()

        Try '如果已打开，先不保存而关闭，以确保打开的是当前文件
            excelAPP.Windows(sFileName.Substring(sFileName.LastIndexOf("\") + 1)).Activate()
            excelAPP.ActiveWorkBook.Close(False)
        Catch
        End Try

        Try
            If sFileName Is Nothing OrElse sFileName = "" Then
                excelAPP.Quit()
                'MessageBox.Show("请上传源文件！  ", "上传源文件时发生错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                excelAPP = Nothing
                Return
            Else
                excelAPP.DisplayAlerts = False
                excelAPP.Workbooks.Open(sFileName)
                excelAPP.DisplayAlerts = True
            End If
        Catch ex As Exception
            excelAPP.Quit()
            MessageBox.Show("打开源文件时发生错误！具体的错误信息如下：    " & Chr(13) & Chr(13) & ex.Message & Space(4) & Chr(13) & Chr(13) & "请检查错误原因，然后重试。如仍有问题，请联系软件开发人员。    ", "打开源文件时发生错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            excelAPP = Nothing
            Return
        End Try

        If excelAPP.ActiveWorkBook.WorkSheets.Count = 1 Then
            sWorkSheet = excelAPP.ActiveWorkBook.WorkSheets(1).Name
        Else
            With frmSelectWorkSheet
                .sFileName = sFileName
                For Each WorkSheet As Object In excelAPP.ActiveWorkBook.WorkSheets
                    .cbbWorkSheet.Items.Add(WorkSheet.Name)
                Next
                .cbbWorkSheet.SelectedIndex = 0
                If .ShowDialog = Windows.Forms.DialogResult.OK Then sWorkSheet = .cbbWorkSheet.Text
                .Dispose()
            End With

            Try '如果已打开，先不保存而关闭，以确保打开的是当前文件
                excelAPP.Windows(sFileName.Substring(sFileName.LastIndexOf("\") + 1)).Activate()
                excelAPP.ActiveWorkBook.Close(False)
            Catch
            End Try

            Try
                excelAPP.DisplayAlerts = False
                excelAPP.Workbooks.Open(sFileName)
                excelAPP.DisplayAlerts = True
            Catch ex As Exception
                excelAPP.Quit()
                MessageBox.Show("打开源文件时发生错误！具体的错误信息如下：    " & Chr(13) & Chr(13) & ex.Message & Space(4) & "请检查错误原因，然后重试。如仍有问题，请联系软件开发人员。    ", "打开源文件时发生错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                excelAPP = Nothing
                Return
            End Try
        End If

        excelAPP.ActiveWorkBook.WorkSheets(sWorkSheet).Select()
        With excelAPP.ActiveWorkBook.ActiveSheet
            Try

                '手机号码
                If .Range("A1").Value.ToString.Trim <> "手机号码" Then
                    MessageBox.Show("源文件格式存在错误！源文件应该由下面一列组成：    " & Chr(13) & Chr(13) & _
                                    "手机号码    " & Chr(13) & Chr(13) & _
                                    "请确保源文件第一行各单元格的值与上面各列相一致。    ", "源文件格式错误，导入失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    excelAPP = Nothing
                    Return
                End If

                '面值
                If .Range("B1").Value.ToString.Trim <> "面值" Then
                    MessageBox.Show("源文件格式存在错误！源文件应该由下面一列组成：    " & Chr(13) & Chr(13) & _
                                    "面值    " & Chr(13) & Chr(13) & _
                                    "请确保源文件第一行各单元格的值与上面各列相一致。    ", "源文件格式错误，导入失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    excelAPP = Nothing
                    Return
                End If

                '数量
                If .Range("C1").Value.ToString.Trim <> "数量" Then
                    MessageBox.Show("源文件格式存在错误！源文件应该由下面一列组成：    " & Chr(13) & Chr(13) & _
                                    "数量    " & Chr(13) & Chr(13) & _
                                    "请确保源文件第一行各单元格的值与上面各列相一致。    ", "源文件格式错误，导入失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    excelAPP = Nothing
                    Return
                End If

                dtImportedDetails = New DataTable()
                dtImportedDetails.Columns.Add("TelePhone", System.Type.GetType("System.String"))
                dtImportedDetails.Columns.Add("FaceValue", System.Type.GetType("System.String"))
                dtImportedDetails.Columns.Add("CardQTY", System.Type.GetType("System.String"))

                Dim iRows As Integer = .UsedRange.Rows.Count, drDetail As DataRow, iRowID As Int16 = 0, sRepeatData As String = ""
                Dim sTelePhone As String = "", FaceValue As String = "", CardQTY As String = ""
                For iRow As Integer = 2 To iRows
                    drDetail = dtImportedDetails.Rows.Add
                    sTelePhone = .Range("A" & iRow.ToString).Value '手机号码
                    FaceValue = .Range("B" & iRow.ToString).Value '面值
                    CardQTY = .Range("C" & iRow.ToString).Value '数量
                    drDetail("TelePhone") = sTelePhone
                    drDetail("FaceValue") = FaceValue
                    drDetail("CardQTY") = CardQTY

                    '验证输入有效性(手机号码)
                    If sTelePhone = "" Then
                        MessageBox.Show("第 " & iRow & " 行手机号为空！")
                        Return
                    Else
                        '类型验证
                        If Not IsNumeric(sTelePhone) Then
                            MessageBox.Show("第 " & iRow & " 行手机号错误！")
                            Return
                        End If
                        '长度验证
                        If sTelePhone.Length <> 11 Then
                            MessageBox.Show("第 " & iRow & " 行手机号位数错误！")
                            Return
                        End If
                    End If

                    '验证输入有效性(面值)
                    If FaceValue = "" Then
                        MessageBox.Show("第 " & iRow & " 行面值为空！")
                        Return
                    Else
                        Try
                            Dim fValue As Decimal = Decimal.Parse(FaceValue)
                        Catch ex As Exception
                            MessageBox.Show("第 " & iRow & " 行面值输入无效")
                            Return
                        End Try
                    End If

                    '验证输入有效性(数量)
                    If CardQTY = "" Then
                        MessageBox.Show("第 " & iRow & " 行数量为空！")
                        Return
                    Else
                        Try
                            Dim cQTY As Integer = Integer.Parse(CardQTY)
                        Catch ex As Exception
                            MessageBox.Show("第 " & iRow & " 行数量输入无效")
                            Return
                        End Try
                    End If
                    iRowID += 1
                Next

                excelAPP.DisplayAlerts = True
                excelAPP.ActiveWorkBook.Close(False)
                excelAPP.Quit()
                excelAPP = Nothing

                If dtImportedDetails.Rows.Count = 0 Then
                    MessageBox.Show("源文件中不存在数据！：    " & Chr(13) & Chr(13) & "请重新选择源文件（或源工作表）。    ", "源文件中不存在任何数据！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    dtImportedDetails.Dispose() : dtImportedDetails = Nothing
                    Return
                End If

                btnExcute.Enabled = True
                MessageBox.Show("已将源文件中的数据导入到系统中。    ", "已完成导入操作。", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.lblResult.ForeColor = Color.Blue
                Me.lblResult.Text = "已将源文件中的数据导入到系统中！"
                frmMain.statusText.Text = "就绪"
                btnExcute.Enabled = True
            Catch ex As Exception
                excelAPP.Quit()
                MessageBox.Show("打开源文件时发生错误！具体的错误信息如下：    " & Chr(13) & Chr(13) & ex.Message & Space(4) & "请检查错误原因，然后重试。如仍有问题，请联系软件开发人员。    ", "打开源文件时发生错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                excelAPP = Nothing
                Return
            End Try
        End With
    End Sub

    Private Sub btnExcute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcute.Click
        Dim DB As New DataBase, sSQLString As String = ""
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法提交激活记录。请检查数据库连接。"
            Me.Cursor = Cursors.Default
            Return
        End If

        Dim IsSelect1 As Boolean = TabPage1.CanFocus
        Dim IsSelect2 As Boolean = TabPage2.CanFocus

        Dim sEmail As String = Me.txtEmail.Text.Trim()
        Dim sMobile As String = Me.txtMobile.Text.Trim()
        Dim sFaceValue As String = Me.txtFaceValue.Text.Trim()
        Dim sCardQTY As String = Me.txtCardQTY.Text.Trim()

        If IsSelect2 Then
            '验证输入有效性(手机号码)
            If sMobile = "" Then
                MessageBox.Show("手机号为空！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
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

            '验证输入有效性(邮箱)
            If sEmail = "" Then
                MessageBox.Show("邮箱地址为空！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            '验证输入有效性(面值)
            If sFaceValue = "" Then
                MessageBox.Show("面值为空！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            Else
                Try
                    Dim fValue As Decimal = Decimal.Parse(sFaceValue)
                Catch ex As Exception
                    MessageBox.Show("面值输入无效", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End Try
            End If

            '验证输入有效性(数量)
            If sCardQTY = "" Then
                MessageBox.Show("数量为空！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            Else
                Try
                    Dim cQTY As Integer = Integer.Parse(sCardQTY)
                Catch ex As Exception
                    MessageBox.Show("数量输入无效", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End Try
            End If
        End If

        Dim sMsg As String = "请注意：确认操作一旦提交，便不可撤消！    " & Chr(13) & Chr(13) & "如果您确认上面信息正确无误，请按""确定""按钮继续。    "
        If MessageBox.Show(sMsg, "请确认：", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Cancel Then Return
        Me.Cursor = Cursors.WaitCursor
        btnExcute.Enabled = False
        Me.Refresh()

        Dim iElects As InternetElects.Service = Nothing
        Dim iEmailClass As InternetElects.MailListJsonInfo = Nothing, iEmailInfo As InternetElects.MailDetailInfo = Nothing, EmailResponse As InternetElects.MailRealTimeResponse = Nothing
        Dim iMobileClass As InternetElects.MobileListJsonInfo = Nothing, iMobileInfo As InternetElects.MobileDetailInfo = Nothing, MobileResponse As InternetElects.MobileRealTimeResponse = Nothing

        Try
            iElects = New InternetElects.Service
            Dim dtReturnDetails As New DataTable, drDetail As DataRow, nRows As Integer = 0
            Dim aRebateSalesAMT As Decimal = frmSelling.txbAvailableRebateSalesAMT.Text.Trim(), submitAMT As Decimal = 0
            Dim sMerchantNo As String = dvCULParameter.Table.Select("CULCardBin='65999'")(0)("CULStoreCode").ToString, sIssuerId As String = frmMain.sIssuerId

            Dim BeginDate As String = Date.Now.ToString("yyyyMMdd"), EndDate As String = DateAdd(DateInterval.Year, 3, Date.Now).ToString("yyyyMMdd"), SalesBillID As String = ""
            If frmSelling.sOrderNo <> "" Then
                Dim dtOrder As DataTable = DB.GetDataTable("select BeginDate,EndDate,SalesBillID from Electronic where OrderNo = '" & frmSelling.sOrderNo & "'")
                If dtOrder.Rows.Count > 0 Then
                    BeginDate = Convert.ToDateTime(dtOrder.Rows(0)("BeginDate")).ToString("yyyyMMdd")
                    EndDate = Convert.ToDateTime(dtOrder.Rows(0)("EndDate")).ToString("yyyyMMdd")
                    SalesBillID = dtOrder.Rows(0)("SalesBillID").ToString
                End If
            End If

            If IsSelect1 Then
                Dim sOrderNo = frmElectronic.getOrderNo(), EID As String = Guid.NewGuid.ToString, sACardQTY As Integer = 0, sAAmount As Decimal = 0
                iMobileClass = New InternetElects.MobileListJsonInfo
                Dim listInfo As New List(Of InternetElects.MobileDetailInfo)

                Dim iRows As Integer = dtImportedDetails.Rows.Count
                For iRow As Integer = 0 To iRows - 1
                    Dim iMobile As String = dtImportedDetails.Rows(iRow)("TelePhone")
                    Dim iFaceValue As Decimal = dtImportedDetails.Rows(iRow)("FaceValue")
                    Dim iCardQTY As Integer = dtImportedDetails.Rows(iRow)("CardQTY")
                    iMobileInfo = New InternetElects.MobileDetailInfo
                    iMobileInfo.issuerId = sIssuerId
                    iMobileInfo.merchantNo = sMerchantNo
                    iMobileInfo.mobile = iMobile
                    iMobileInfo.shortUrlBeginDate = BeginDate
                    iMobileInfo.shortUrlEndDate = EndDate
                    iMobileInfo.totalAmount = iFaceValue * iCardQTY * 100
                    iMobileInfo.availableCount = 999999 '//可以使用次数
                    iMobileInfo.needVerifyCode = "N" '//是否需要验证码
                    iMobileInfo.VerifyCodeLength = 4 '//验证码长度
                    iMobileInfo.VerifyCodeAmount = 200 '//验证码的触发金额
                    iMobileInfo.needFreezeCard = "" '//是否需要冻结卡片
                    iMobileInfo.amount = iFaceValue * 100
                    iMobileInfo.cardNumber = iCardQTY
                    listInfo.Add(iMobileInfo)
                    submitAMT = submitAMT + (iFaceValue * iCardQTY)
                Next

                If submitAMT > aRebateSalesAMT Then
                    MessageBox.Show("获取返点卡的总金额已超出本次最大可兑返点金额", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Cursor = Cursors.Default
                    Return
                End If

                iMobileClass.DataList = listInfo.ToArray
                iMobileClass.OrderNo = sOrderNo
                iMobileClass.IssuerId = sIssuerId
                iMobileClass.OrderType = "M"
                iMobileClass.Date = Date.Now.ToString("yyyyMMdd")
                MobileResponse = New InternetElects.MobileRealTimeResponse

                MobileResponse = iElects.MobileRealTimeOrderRequest(iMobileClass) '调用手机实时下单接口
                If MobileResponse.CodeMsg.Code = "00" Then
                    frmMain.statusText.Text = "实时下单获取返点卡成功。"
                    MessageBox.Show("实时下单获取返点卡成功！ ", "Submit OK.", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    dtReturnDetails.Clear()
                    dtReturnDetails.Columns.Add("Code", System.Type.GetType("System.String"))
                    dtReturnDetails.Columns.Add("Msg", System.Type.GetType("System.String"))
                    dtReturnDetails.Columns.Add("IssuerId", System.Type.GetType("System.String"))
                    dtReturnDetails.Columns.Add("OrderNo", System.Type.GetType("System.String"))
                    dtReturnDetails.Columns.Add("StartCardNo", System.Type.GetType("System.String"))
                    dtReturnDetails.Columns.Add("EndCardNo", System.Type.GetType("System.String"))
                    dtReturnDetails.Columns.Add("Amount", System.Type.GetType("System.Decimal"))
                    dtReturnDetails.Columns.Add("Mobile", System.Type.GetType("System.String"))
                    dtReturnDetails.Columns.Add("CardQTY", System.Type.GetType("System.Int32"))
                    dtReturnDetails.Columns.Add("FaceValue", System.Type.GetType("System.Decimal"))

                    nRows = MobileResponse.DataList.Length
                    For iRow As Integer = 0 To nRows - 1
                        drDetail = dtReturnDetails.Rows.Add
                        drDetail("Code") = MobileResponse.DataList(iRow).Code
                        drDetail("Msg") = MobileResponse.DataList(iRow).Msg
                        drDetail("IssuerId") = MobileResponse.DataList(iRow).IssuerId
                        drDetail("OrderNo") = MobileResponse.DataList(iRow).OrderNo
                        drDetail("StartCardNo") = MobileResponse.DataList(iRow).StartCardNo
                        drDetail("EndCardNo") = MobileResponse.DataList(iRow).EndCardNo
                        drDetail("Amount") = Convert.ToDecimal(MobileResponse.DataList(iRow).Amount)
                        drDetail("Mobile") = MobileResponse.DataList(iRow).Mobile
                        drDetail("CardQTY") = MobileResponse.DataList(iRow).CardNumber
                        drDetail("FaceValue") = Convert.ToDecimal(MobileResponse.DataList(iRow).FaceValue)

                        sACardQTY += drDetail("CardQTY")
                        sAAmount += (drDetail("FaceValue") * drDetail("CardQTY"))
                        sSQLString += "insert into ElectronicDetails values (newid(),'" + EID + "','" + drDetail("StartCardNo").ToString + "','" + drDetail("EndCardNo").ToString + "','" + drDetail("Mobile").ToString + "','" + drDetail("CardQTY").ToString + "','" + drDetail("FaceValue").ToString + "'); "
                    Next
                    dtReturnDetails.AcceptChanges()

                    sSQLString += "insert into Electronic values ('" + EID + "',3,null,null,'" + sACardQTY.ToString + "','" + sAAmount.ToString + "','" + BeginDate + "','" + EndDate + "','" + sOrderNo + "','" + frmMain.sLoginUserID + "','" + frmMain.sLoginUserRealName + "','" + Date.Now.ToString() + "',3,'" + frmMain.sLoginAreaID + "','" + SalesBillID + "'); "

                    With frmSelling
                        .dtRebateCardEx = dtReturnDetails
                        .GetCULReturnCard()
                    End With
                    Me.Dispose()
                Else
                    frmMain.statusText.Text = MobileResponse.CodeMsg.Msg
                    MessageBox.Show(MobileResponse.CodeMsg.Msg, MobileResponse.CodeMsg.Msg, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Cursor = Cursors.Default
                    Return
                End If

                '记录日志
                Dim sValues As String = "'" & frmMain.sLoginUserID & "','" & Date.Now.ToString() & "'," '日期
                sValues = sValues & "'手机实时下单'," '类型
                sValues = sValues & "''," '卡号
                sValues = sValues & "''," '手机
                sValues = sValues & "''," '邮箱
                sValues = sValues & "'" & sOrderNo & "'," '订单号
                sValues = sValues & "''," '有效期
                sValues = sValues & "'" & MobileResponse.CodeMsg.Msg & "'," 'Msg
                sValues = sValues & "'" & MobileResponse.CodeMsg.Code & "'" 'Code
                Dim sSQL As String = "insert into ElectronicLog values (" & sValues & ");"
                DB.ModifyTable(sSQL)
                DB.ModifyTable(sSQLString)
            End If

            If IsSelect2 Then
                Dim sOrderNo = frmElectronic.getOrderNo(), EID As String = Guid.NewGuid.ToString, sACardQTY As Integer = 0, sAAmount As Decimal = 0
                iEmailClass = New InternetElects.MailListJsonInfo
                Dim listInfo As New List(Of InternetElects.MailDetailInfo)

                iEmailInfo = New InternetElects.MailDetailInfo
                iEmailInfo.issuerId = sIssuerId
                iEmailInfo.merchantNo = sMerchantNo
                iEmailInfo.mail = sEmail
                iEmailInfo.mobile = sMobile
                iEmailInfo.shortUrlBeginDate = BeginDate
                iEmailInfo.shortUrlEndDate = EndDate
                iEmailInfo.totalAmount = sFaceValue * sCardQTY * 100
                iEmailInfo.availableCount = 999999 '//可以使用次数
                iEmailInfo.needVerifyCode = "N" '//是否需要验证码
                iEmailInfo.VerifyCodeLength = 4 '//验证码长度
                iEmailInfo.VerifyCodeAmount = 200 '//验证码的触发金额
                iEmailInfo.needFreezeCard = "" '//是否需要冻结卡片
                iEmailInfo.amount = sFaceValue * 100
                iEmailInfo.cardNumber = sCardQTY
                listInfo.Add(iEmailInfo)
                submitAMT = submitAMT + (sFaceValue * sCardQTY)

                If submitAMT > aRebateSalesAMT Then
                    MessageBox.Show("获取返点卡的总金额已超出本次最大可兑返点金额", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Cursor = Cursors.Default
                    Return
                End If

                iEmailClass.DataList = listInfo.ToArray
                iEmailClass.OrderNo = sOrderNo
                iEmailClass.IssuerId = sIssuerId
                iEmailClass.OrderType = "F"
                iEmailClass.Date = Date.Now.ToString("yyyyMMdd")
                EmailResponse = New InternetElects.MailRealTimeResponse

                EmailResponse = iElects.MailRealTimeOrderRequest(iEmailClass) '调用邮箱实时下单接口
                If EmailResponse.CodeMsg.Code = "00" Then
                    frmMain.statusText.Text = "实时下单获取返点卡成功。"
                    MessageBox.Show("实时下单获取返点卡成功！ ", "Submit OK.", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    dtReturnDetails.Clear()
                    dtReturnDetails.Columns.Add("Code", System.Type.GetType("System.String"))
                    dtReturnDetails.Columns.Add("Msg", System.Type.GetType("System.String"))
                    dtReturnDetails.Columns.Add("IssuerId", System.Type.GetType("System.String"))
                    dtReturnDetails.Columns.Add("OrderNo", System.Type.GetType("System.String"))
                    dtReturnDetails.Columns.Add("StartCardNo", System.Type.GetType("System.String"))
                    dtReturnDetails.Columns.Add("EndCardNo", System.Type.GetType("System.String"))
                    dtReturnDetails.Columns.Add("Amount", System.Type.GetType("System.Decimal"))
                    dtReturnDetails.Columns.Add("CardQTY", System.Type.GetType("System.Int32"))
                    dtReturnDetails.Columns.Add("FaceValue", System.Type.GetType("System.Decimal"))

                    nRows = EmailResponse.DataList.Length
                    For iRow As Integer = 0 To nRows - 1
                        drDetail = dtReturnDetails.Rows.Add
                        drDetail("Code") = EmailResponse.DataList(iRow).Code
                        drDetail("Msg") = EmailResponse.DataList(iRow).Msg
                        drDetail("IssuerId") = EmailResponse.DataList(iRow).IssuerId
                        drDetail("OrderNo") = EmailResponse.DataList(iRow).OrderNo
                        drDetail("StartCardNo") = EmailResponse.DataList(iRow).StartCardNo
                        drDetail("EndCardNo") = EmailResponse.DataList(iRow).EndCardNo
                        drDetail("Amount") = Convert.ToDecimal(EmailResponse.DataList(iRow).Amount)
                        drDetail("CardQTY") = EmailResponse.DataList(iRow).CardNumber
                        drDetail("FaceValue") = Convert.ToDecimal(EmailResponse.DataList(iRow).FaceValue)

                        sACardQTY += drDetail("CardQTY")
                        sAAmount += (drDetail("FaceValue") * drDetail("CardQTY"))
                        sSQLString += "insert into ElectronicDetails values (newid(),'" + EID + "','" + drDetail("StartCardNo").ToString + "','" + drDetail("EndCardNo").ToString + "',null,'" + drDetail("CardQTY").ToString + "','" + drDetail("FaceValue").ToString + "'); "
                    Next
                    dtReturnDetails.AcceptChanges()

                    sSQLString += "insert into Electronic values ('" + EID + "',4,'" + sMobile + "','" + sEmail + "','" + sACardQTY.ToString + "','" + sAAmount.ToString + "','" + BeginDate + "','" + EndDate + "','" + sOrderNo + "','" + frmMain.sLoginUserID + "','" + frmMain.sLoginUserRealName + "','" + Date.Now.ToString() + "',3,'" + frmMain.sLoginAreaID + "','" + SalesBillID + "'); "

                    With frmSelling
                        .dtRebateCardEx = dtReturnDetails
                        .GetCULReturnCard()
                    End With
                    Me.Dispose()
                Else
                    frmMain.statusText.Text = EmailResponse.CodeMsg.Msg
                    MessageBox.Show(EmailResponse.CodeMsg.Msg, EmailResponse.CodeMsg.Msg, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Cursor = Cursors.Default
                    Return
                End If

                '记录日志
                Dim sValues As String = "'" & frmMain.sLoginUserID & "','" & Date.Now.ToString() & "'," '日期
                sValues = sValues & "'邮箱实时下单'," '类型
                sValues = sValues & "''," '卡号
                sValues = sValues & "'" & sMobile & "'," '手机
                sValues = sValues & "'" & sEmail & "'," '邮箱
                sValues = sValues & "'" & sOrderNo & "'," '订单号
                sValues = sValues & "''," '有效期
                sValues = sValues & "'" & EmailResponse.CodeMsg.Msg & "'," 'Msg
                sValues = sValues & "'" & EmailResponse.CodeMsg.Code & "'" 'Code
                Dim sSQL As String = "insert into ElectronicLog values (" & sValues & ");"
                DB.ModifyTable(sSQL)
                DB.ModifyTable(sSQLString)
            End If
        Catch ex As Exception
            MessageBox.Show("因为CUL系统故障，无法进行充值撤销操作！ 下面是CUL系统的内部错误提示：    " & Chr(13) & Chr(13) & ex.Message & Space(4), "出现CUL系统故障！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "因为CUL系统故障，无法进行充值撤销操作！"
            If iElects IsNot Nothing Then iElects.Dispose() : iElects = Nothing
            DB.Close() : Me.Cursor = Cursors.Default : Return
        End Try

        Me.Cursor = Cursors.Default
        DB.Close()
    End Sub
End Class