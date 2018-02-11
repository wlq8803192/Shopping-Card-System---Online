Module ShoppingCardOperation

    'modify code 033:
    'date;2014/7/24
    'auther:Hyron bjy 
    'remark:更改特殊操作用户登录验证方式为guid

    'modify code 036:
    'date;2014/8/26
    'auther:Hyron bjy 
    'remark:增加三种换卡功能

    'modify code 072:
    'date;2017/05/10
    'auther:Qipeng
    'remark:增加电子卡团购功能

    'modify code 079:
    'date;2017/09/26
    'auther:Qipeng
    'remark:修改冻结/解冻和激活撤销功能中输入卡段,但只生效一个卡号的问题

    'modify code 033:start-------------------------------------------------------------------------
    Dim guIDClass As C4ShoppingCardService.GuIDClass
    'modify code 033:end-------------------------------------------------------------------------

    Public Function GetCRFCardState(ByVal sMerchantNo As String, ByVal sStartCardNo As String, ByVal sEndCardNo As String, Optional ByVal sIsPager As String = "N", Optional ByVal sPageNo As String = "1") As DataTable
        Dim sDecimalSeparator As String = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
        Dim dtResult As New DataTable(), newRow As DataRow
        dtResult.Columns.Add("CardNo", System.Type.GetType("System.String"))
        dtResult.Columns.Add("Balance", System.Type.GetType("System.Decimal"))
        dtResult.Columns.Add("ActivatedDate", System.Type.GetType("System.DateTime"))
        dtResult.Columns.Add("EffectiveDate", System.Type.GetType("System.DateTime"))
        dtResult.Columns.Add("StoreName", System.Type.GetType("System.String"))
        dtResult.Columns.Add("CardState", System.Type.GetType("System.String"))

        Dim c4Service As C4ShoppingCardService.C4ShoppingCardService = Nothing
        Try
            c4Service = New C4ShoppingCardService.C4ShoppingCardService()
            Dim infoClass As New C4ShoppingCardService.InfoClass()
            infoClass.MerchantNo = sMerchantNo
            infoClass.UserID = sMerchantNo
            infoClass.CardNoFrom = sStartCardNo
            infoClass.CardNoTo = sEndCardNo
            infoClass.IsPager = sIsPager
            infoClass.PageNo = sPageNo

            Dim infoDataClass As C4ShoppingCardService.InfoDataClass = c4Service.info(infoClass)
            If infoDataClass.CodeMsg.Code = "OZ" Then
                Dim iCards As Integer = infoDataClass.Cards.Length - 1, sDate As String
                For iCard As Integer = 0 To iCards
                    newRow = dtResult.Rows.Add()
                    newRow("CardNo") = infoDataClass.Cards(iCard).CardNo
                    newRow("Balance") = CDec(infoDataClass.Cards(iCard).Balance.ToString.Replace(".", sDecimalSeparator))
                    Try
                        sDate = infoDataClass.Cards(iCard).ActivedDate
                        sDate = sDate.Insert(4, "/").Insert(7, "/")
                        newRow("ActivatedDate") = CDate(sDate)
                    Catch
                    End Try
                    Try
                        sDate = "20" & infoDataClass.Cards(iCard).ExpiredDate & "01"
                        sDate = sDate.Insert(4, "/").Insert(7, "/")
                        newRow("EffectiveDate") = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, CDate(sDate)))
                    Catch
                    End Try
                    newRow("StoreName") = infoDataClass.Cards(iCard).IssuerMerchant
                    If infoDataClass.Cards(iCard).HotReason = "冻结" Then
                        newRow("CardState") = "已冻结"
                    ElseIf infoDataClass.Cards(iCard).HotReason = "结束" Then
                        newRow("CardState") = "已结束"
                    ElseIf infoDataClass.Cards(iCard).Status = "激活" Then
                        newRow("CardState") = "已激活"
                    Else
                        newRow("CardState") = infoDataClass.Cards(iCard).Status
                    End If
                Next
            Else
                dtResult.Rows.Clear()
                newRow = dtResult.Rows.Add()
                newRow("CardNo") = "Error"
                newRow("StoreName") = infoDataClass.CodeMsg.Msg
            End If

            infoClass = Nothing
            infoDataClass = Nothing
        Catch ex As Exception
            dtResult.Rows.Clear()
            newRow = dtResult.Rows.Add()
            newRow("CardNo") = "Error"
            newRow("StoreName") = ex.Message
        Finally
            If c4Service IsNot Nothing Then c4Service.Dispose() : c4Service = Nothing
            dtResult.AcceptChanges()
        End Try

        Return dtResult
    End Function

    Public Function GetICCardState(ByVal sMerchantNo As String, ByVal sCardType As String, ByVal sStartCardNo As String, ByVal sEndCardNo As String, Optional ByVal sIsPager As String = "N", Optional ByVal sPageNo As String = "1") As DataTable
        Dim sDecimalSeparator As String = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
        Dim dtResult As New DataTable(), newRow As DataRow
        dtResult.Columns.Add("CardNo", System.Type.GetType("System.String"))
        dtResult.Columns.Add("Balance", System.Type.GetType("System.Decimal"))
        dtResult.Columns.Add("ActivatedDate", System.Type.GetType("System.DateTime"))
        dtResult.Columns.Add("EffectiveDate", System.Type.GetType("System.DateTime"))
        dtResult.Columns.Add("StoreName", System.Type.GetType("System.String"))
        dtResult.Columns.Add("CardState", System.Type.GetType("System.String"))

        Dim c4Service As C4ShoppingCardService.C4ShoppingCardService = Nothing
        Try
            c4Service = New C4ShoppingCardService.C4ShoppingCardService()
            Dim icClass As New C4ShoppingCardService.IcClass()
            icClass.MerchantNo = sMerchantNo
            icClass.UserID = sMerchantNo
            icClass.IcType = sCardType
            icClass.CardNoFrom = sStartCardNo
            icClass.CardNoTo = sEndCardNo
            icClass.IsPager = sIsPager
            icClass.PageNo = sPageNo

            Dim icDataClass As C4ShoppingCardService.IcDataClass = c4Service.icInfo(icClass)
            If icDataClass.CodeMsg.Code = "00" Then
                Dim iCards As Integer = icDataClass.Cards.Length - 1, sDate As String
                For iCard As Integer = 0 To iCards
                    newRow = dtResult.Rows.Add()
                    newRow("CardNo") = icDataClass.Cards(iCard).CardNo
                    newRow("Balance") = CDec(icDataClass.Cards(iCard).Balance.ToString.Replace(".", sDecimalSeparator))
                    Try
                        sDate = icDataClass.Cards(iCard).ActivedDate
                        newRow("ActivatedDate") = CDate(sDate)
                    Catch
                    End Try
                    Try
                        sDate = icDataClass.Cards(iCard).ExpiredDate.Insert(4, "/").Insert(7, "/")
                        newRow("EffectiveDate") = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, CDate(sDate)))
                    Catch
                    End Try
                    newRow("StoreName") = icDataClass.Cards(iCard).MerchantNoName
                    If icDataClass.Cards(iCard).Status = "A" AndAlso icDataClass.Cards(iCard).HotReason = "" Then
                        newRow("CardState") = "已激活"
                    Else
                        newRow("CardState") = "已" & icDataClass.Cards(iCard).StatusName & IIf(icDataClass.Cards(iCard).HotReasonName = "", "", "（已" & icDataClass.Cards(iCard).HotReasonName & "）")
                    End If
                Next
            Else
                dtResult.Rows.Clear()
                newRow = dtResult.Rows.Add()
                newRow("CardNo") = "Error"
                newRow("StoreName") = icDataClass.CodeMsg.Msg
            End If

            icClass = Nothing
            icDataClass = Nothing
        Catch ex As Exception
            dtResult.Rows.Clear()
            newRow = dtResult.Rows.Add()
            newRow("CardNo") = "Error"
            newRow("StoreName") = ex.Message
        Finally
            If c4Service IsNot Nothing Then c4Service.Dispose() : c4Service = Nothing
            dtResult.AcceptChanges()
        End Try

        Return dtResult
    End Function

    Public Function GetPaperCardState(ByVal sMerchantNo As String, ByVal sStartCardNo As String, ByVal sEndCardNo As String, Optional ByVal sIsPager As String = "N", Optional ByVal sPageNo As String = "1") As DataTable
        Dim sDecimalSeparator As String = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
        Dim dtResult As New DataTable(), newRow As DataRow
        dtResult.Columns.Add("CardNo", System.Type.GetType("System.String"))
        dtResult.Columns.Add("Balance", System.Type.GetType("System.Decimal"))
        dtResult.Columns.Add("ActivatedDate", System.Type.GetType("System.DateTime"))
        dtResult.Columns.Add("EffectiveDate", System.Type.GetType("System.DateTime"))
        dtResult.Columns.Add("StoreName", System.Type.GetType("System.String"))
        dtResult.Columns.Add("CardState", System.Type.GetType("System.String"))

        Dim c4Service As C4ShoppingCardService.C4ShoppingCardService = Nothing
        Try
            c4Service = New C4ShoppingCardService.C4ShoppingCardService()
            Dim infoClass As New C4ShoppingCardService.VInfoClass()
            infoClass.MerchantNo = sMerchantNo
            infoClass.UserID = sMerchantNo
            infoClass.TypeId = sStartCardNo.Substring(0, 8)
            infoClass.SeqNoFrom = sStartCardNo.Substring(8)
            infoClass.SeqNoTo = sEndCardNo.Substring(8)
            infoClass.IsPager = "N"
            infoClass.PageNo = "1"

            'Dim infoDataClass As C4ShoppingCardService.VInfoDataClass = c4Service.vinfoTest("102412054110001", "84114050000030001", "84114050000030001")
            Dim infoDataClass As C4ShoppingCardService.VInfoDataClass = c4Service.vinfo(infoClass)
            If infoDataClass.VCodeMsg.Code = "01" Then
                Dim iCards As Integer = infoDataClass.Vouchers.Length - 1
                For iCard As Integer = 0 To iCards
                    newRow = dtResult.Rows.Add()
                    newRow("CardNo") = infoDataClass.Vouchers(iCard).TypeId & infoDataClass.Vouchers(iCard).SeqNo
                    newRow("Balance") = CDec(infoDataClass.Vouchers(iCard).Amount.ToString.Replace(".", sDecimalSeparator))
                    Try
                        newRow("ActivatedDate") = CDate(infoDataClass.Vouchers(iCard).ActivedDate)
                    Catch
                    End Try
                    Try
                        newRow("EffectiveDate") = CDate(infoDataClass.Vouchers(iCard).ExpiredDate.Insert(4, "/").Insert(7, "/"))
                    Catch
                    End Try
                    newRow("StoreName") = infoDataClass.Vouchers(iCard).ActivedDMer & "-" & infoDataClass.Vouchers(iCard).ActivedMerName
                    Select Case infoDataClass.Vouchers(iCard).Status
                        Case "2"
                            newRow("CardState") = "已激活"
                        Case "3"
                            newRow("Balance") = 0
                            newRow("CardState") = "已使用"
                        Case "4"
                            newRow("CardState") = "已过期"
                        Case Else
                            newRow("CardState") = "已冻结"
                    End Select
                Next
            Else
                dtResult.Rows.Clear()
                newRow = dtResult.Rows.Add()
                newRow("CardNo") = "Error"
                newRow("StoreName") = infoDataClass.VCodeMsg.Msg
            End If

            infoClass = Nothing
            infoDataClass = Nothing
        Catch ex As Exception
            dtResult.Rows.Clear()
            newRow = dtResult.Rows.Add()
            newRow("CardNo") = "Error"
            newRow("StoreName") = ex.Message
        Finally
            If c4Service IsNot Nothing Then c4Service.Dispose() : c4Service = Nothing
            dtResult.AcceptChanges()
        End Try

        Return dtResult
    End Function

    Public Function CRFCardAutoFreeze(ByVal blIsToFreeze As Boolean, ByVal dtCULParameter As DataTable, ByVal dtCard As DataTable) As Integer
        frmMain.statusText.Text = "正在执行磁条卡自动" & IIf(blIsToFreeze, "冻结", "解冻") & "……"
        frmMain.statusRate.Visible = True
        frmMain.statusRate.Text = ""
        frmMain.statusProgress.Visible = True
        frmMain.statusProgress.Value = 0
        frmMain.statusMain.Refresh()

        Dim dtSource As New DataTable(), sCardNo As String, sStartCardNo As String = "", sEndCardNo As String = "", iCardQTY As Integer = 0
        dtSource.Columns.Add("StartCardNo", System.Type.GetType("System.String"))
        dtSource.Columns.Add("EndCardNo", System.Type.GetType("System.String"))
        dtSource.Columns.Add("CardQTY", System.Type.GetType("System.Int32"))
        For Each drCard As DataRow In dtCard.Select("", "CardNo")
            sCardNo = drCard("CardNo").ToString
            If sStartCardNo = "" Then
                sStartCardNo = sCardNo
                sEndCardNo = sCardNo
                iCardQTY = 1
            ElseIf CLng(sCardNo.Substring(0, 18)) - CLng(sEndCardNo.Substring(0, 18)) = 1 AndAlso iCardQTY < 1000 Then
                sEndCardNo = sCardNo
                iCardQTY += 1
            Else
                dtSource.Rows.Add(sStartCardNo, sEndCardNo, iCardQTY).EndEdit()
                sStartCardNo = sCardNo
                sEndCardNo = sCardNo
                iCardQTY = 1
            End If
        Next
        dtSource.Rows.Add(sStartCardNo, sEndCardNo, iCardQTY).EndEdit()
        dtSource.AcceptChanges()

        Dim c4Service As C4ShoppingCardService.C4ShoppingCardService = Nothing, iCard As Integer = 0, iCards As Integer = dtCard.Rows.Count, sMerchantNo As String, iSucesses As Integer = 0
        Try
            c4Service = New C4ShoppingCardService.C4ShoppingCardService
            Dim statusClass As New C4ShoppingCardService.StatusClass, msg As C4ShoppingCardService.CodeMsg = Nothing
            statusClass.Type = IIf(blIsToFreeze, "ICLK", "ICUK")

            For Each drCard As DataRow In dtSource.Rows
                iCard += drCard("CardQTY")
                frmMain.statusRate.Text = "(" & iCard.ToString & "/" & iCards.ToString & ")"
                frmMain.statusProgress.Value = Int((iCard / iCards) * 100)
                frmMain.statusMain.Refresh()

                sMerchantNo = dtCULParameter.Select("CULCardBin='" & drCard("StartCardNo").ToString.Substring(4, 5) & "'")(0)("CULStoreCode").ToString

                statusClass.UserID = sMerchantNo
                statusClass.MerchantNo = sMerchantNo
                statusClass.CardNoFrom = drCard("StartCardNo")
                statusClass.CardNoTo = drCard("EndCardNo")
                'modify code 033:start-------------------------------------------------------------------------
                guIDClass = New C4ShoppingCardService.GuIDClass
                guIDClass.GuID = frmMain.sGuID
                msg = c4Service.status(statusClass, guIDClass)
                'modify code 033:end-------------------------------------------------------------------------

                If msg.Code.ToUpper = "IY" OrElse msg.Code.ToUpper = "IZ" Then iSucesses += drCard("CardQTY")
            Next

            statusClass = Nothing
            msg = Nothing
        Catch
        Finally
            If c4Service IsNot Nothing Then c4Service.Dispose() : c4Service = Nothing
        End Try

        frmMain.statusText.Text = "就绪。"
        frmMain.statusRate.Text = ""
        frmMain.statusRate.Visible = False
        frmMain.statusProgress.Value = 0
        frmMain.statusProgress.Visible = False

        dtSource.Dispose() : dtSource = Nothing

        Return iSucesses
    End Function

    Public Function PaperCardAutoFreeze(ByVal blIsToFreeze As Boolean, ByVal dtCULParameter As DataTable, ByVal dtCard As DataTable) As Integer
        frmMain.statusText.Text = "正在执行条码卡自动" & IIf(blIsToFreeze, "冻结", "解冻") & "……"
        frmMain.statusRate.Visible = True
        frmMain.statusRate.Text = ""
        frmMain.statusProgress.Visible = True
        frmMain.statusProgress.Value = 0
        frmMain.statusMain.Refresh()

        Dim dtSource As New DataTable(), sCardNo As String, sStartCardNo As String = "", sEndCardNo As String = "", iCardQTY As Integer = 0
        dtSource.Columns.Add("CardType", System.Type.GetType("System.String"))
        dtSource.Columns.Add("StartSeqNo", System.Type.GetType("System.String"))
        dtSource.Columns.Add("EndSeqNo", System.Type.GetType("System.String"))
        dtSource.Columns.Add("CardQTY", System.Type.GetType("System.Int32"))
        For Each drCard As DataRow In dtCard.Select("", "CardNo")
            sCardNo = drCard("CardNo").ToString.Trim
            If sStartCardNo = "" Then
                sStartCardNo = sCardNo
                sEndCardNo = sCardNo
                iCardQTY = 1
            ElseIf CLng(sCardNo) - CLng(sEndCardNo) = 1 AndAlso iCardQTY < 1000 Then
                sEndCardNo = sCardNo
                iCardQTY += 1
            Else
                dtSource.Rows.Add(sStartCardNo.Substring(0, 8), sStartCardNo.Substring(8), sEndCardNo.Substring(8), iCardQTY).EndEdit()
                sStartCardNo = sCardNo
                sEndCardNo = sCardNo
                iCardQTY = 1
            End If
        Next
        dtSource.Rows.Add(sStartCardNo.Substring(0, 8), sStartCardNo.Substring(8), sEndCardNo.Substring(8), iCardQTY).EndEdit()
        dtSource.AcceptChanges()

        Dim c4Service As C4ShoppingCardService.C4ShoppingCardService = Nothing, iCard As Integer = 0, iCards As Integer = dtCard.Rows.Count, sMerchantNo As String, iSucesses As Integer = 0
        Try
            c4Service = New C4ShoppingCardService.C4ShoppingCardService
            Dim statusClass As New C4ShoppingCardService.VStatusClass, msg As C4ShoppingCardService.VCodeMsg = Nothing
            statusClass.Type = IIf(blIsToFreeze, "ICLK", "ICUK")

            For Each drCard As DataRow In dtSource.Rows
                iCard += drCard("CardQTY")
                frmMain.statusRate.Text = "(" & iCard.ToString & "/" & iCards.ToString & ")"
                frmMain.statusProgress.Value = Int((iCard / iCards) * 100)
                frmMain.statusMain.Refresh()

                sMerchantNo = dtCULParameter.Select("CULCardBin='" & drCard("CardType").ToString.Substring(0, 5) & "'")(0)("CULStoreCode").ToString

                statusClass.UserID = sMerchantNo
                statusClass.MerchantNo = sMerchantNo
                statusClass.VTypeId = drCard("CardType").ToString
                statusClass.VSeqNoFrom = drCard("StartSeqNo").ToString
                statusClass.VSeqNoTo = drCard("EndSeqNo").ToString
                'modify code 033:start-------------------------------------------------------------------------
                guIDClass = New C4ShoppingCardService.GuIDClass
                guIDClass.GuID = frmMain.sGuID
                msg = c4Service.vstat(statusClass, guIDClass)
                'modify code 033:end-------------------------------------------------------------------------

                If msg.Code.ToUpper = "00" OrElse msg.Code.ToUpper = "01" Then iSucesses += drCard("CardQTY")
            Next

            statusClass = Nothing
            msg = Nothing
        Catch ex As Exception

        Finally
            If c4Service IsNot Nothing Then c4Service.Dispose() : c4Service = Nothing
        End Try

        frmMain.statusText.Text = "就绪。"
        frmMain.statusRate.Text = ""
        frmMain.statusRate.Visible = False
        frmMain.statusProgress.Value = 0
        frmMain.statusProgress.Visible = False

        dtSource.Dispose() : dtSource = Nothing

        Return iSucesses
    End Function

    'modify code 036:start-------------------------------------------------------------------------
    Public Function GetBLCCardState(ByVal sMerchantNo As String, ByVal sCardNo As String, Optional ByVal sIsPager As String = "N", Optional ByVal sPageNo As String = "1") As DataTable
        Dim sDecimalSeparator As String = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
        Dim dtResult As New DataTable(), newRow As DataRow
        dtResult.Columns.Add("CardNo", System.Type.GetType("System.String"))
        dtResult.Columns.Add("Balance", System.Type.GetType("System.Decimal"))
        dtResult.Columns.Add("ActivatedDate", System.Type.GetType("System.DateTime"))
        dtResult.Columns.Add("EffectiveDate", System.Type.GetType("System.DateTime"))
        dtResult.Columns.Add("StoreName", System.Type.GetType("System.String"))
        dtResult.Columns.Add("CardState", System.Type.GetType("System.String"))

        Dim c4Service As C4ShoppingCardService.C4ShoppingCardService = Nothing
        Try
            c4Service = New C4ShoppingCardService.C4ShoppingCardService()
            Dim m27j27CardInfoClass As New C4ShoppingCardService.M27j27CardInfoClass
            m27j27CardInfoClass.MerchantNo = sMerchantNo
            m27j27CardInfoClass.UserID = sMerchantNo
            m27j27CardInfoClass.CardNo = sCardNo
            m27j27CardInfoClass.IsPager = sIsPager
            m27j27CardInfoClass.PageNo = sPageNo

            Dim infoDataClass As C4ShoppingCardService.InfoDataClass = c4Service.m27j27CardInfo(m27j27CardInfoClass)
            If infoDataClass.CodeMsg.Code = "OM" Then
                Dim sDate As String

                newRow = dtResult.Rows.Add()
                newRow("CardNo") = infoDataClass.Cards(0).CardNo
                newRow("Balance") = CDec(infoDataClass.Cards(0).Balance.ToString.Replace(".", sDecimalSeparator))
                Try
                    sDate = infoDataClass.Cards(0).ActivedDate
                    sDate = sDate.Insert(4, "/").Insert(7, "/")
                    newRow("ActivatedDate") = CDate(sDate)
                Catch
                End Try
                Try
                    sDate = "20" & infoDataClass.Cards(0).ExpiredDate & "01"
                    sDate = sDate.Insert(4, "/").Insert(7, "/")
                    newRow("EffectiveDate") = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, CDate(sDate)))
                Catch
                End Try
                newRow("StoreName") = infoDataClass.Cards(0).IssuerMerchant
                If infoDataClass.Cards(0).HotReason = "冻结" Then
                    newRow("CardState") = "已冻结"
                ElseIf infoDataClass.Cards(0).HotReason = "结束" Then
                    newRow("CardState") = "已结束"
                ElseIf infoDataClass.Cards(0).Status = "激活" Then
                    newRow("CardState") = "已激活"
                Else
                    newRow("CardState") = infoDataClass.Cards(0).Status
                End If
            Else
                dtResult.Rows.Clear()
                newRow = dtResult.Rows.Add()
                newRow("CardNo") = "Error"
                newRow("StoreName") = infoDataClass.CodeMsg.Msg
            End If

            m27j27CardInfoClass = Nothing
            infoDataClass = Nothing
        Catch ex As Exception
            dtResult.Rows.Clear()
            newRow = dtResult.Rows.Add()
            newRow("CardNo") = "Error"
            newRow("StoreName") = ex.Message
        Finally
            If c4Service IsNot Nothing Then c4Service.Dispose() : c4Service = Nothing
            dtResult.AcceptChanges()
        End Try

        Return dtResult
    End Function
    'modify code 036:end-------------------------------------------------------------------------

    'modify code 072:start-------------------------------------------------------------------------
    Public Function GetECardState(ByVal sMerchantNo As String, ByVal sStartCardNo As String, ByVal sEndCardNo As String, Optional ByVal sIsPager As String = "N", Optional ByVal sPageNo As String = "1") As DataTable
        Dim sDecimalSeparator As String = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
        Dim dtResult As New DataTable(), newRow As DataRow, sCardNo As String, sCardNum As Integer
        dtResult.Columns.Add("CardNo", System.Type.GetType("System.String"))
        dtResult.Columns.Add("Balance", System.Type.GetType("System.Decimal"))
        dtResult.Columns.Add("EffectiveDate", System.Type.GetType("System.DateTime"))
        dtResult.Columns.Add("StoreName", System.Type.GetType("System.String"))
        dtResult.Columns.Add("CardState", System.Type.GetType("System.String"))
        dtResult.Columns.Add("ActivatedDate", System.Type.GetType("System.DateTime"))

        'Dim DB As New DataBase, sActivatedDate As String = Date.Now.ToString("yyyy/MM/dd")
        'DB.Open()
        'Dim dtData As DataTable = DB.GetDataTable("select top 1 CULActivatedTime from ActivationList where CardNo = '" & sStartCardNo & "'")
        'If dtData Is Nothing Then
        'Else
        '    If dtData.Rows.Count > 0 Then
        '        sActivatedDate = Convert.ToDecimal(dtData.Rows(0)(0)).ToString("yyyy/MM/dd")
        '    End If
        'End If
        'DB.Close()

        Dim electService As InternetElects.Service = Nothing
        Try
            'modify code 079:start-------------------------------------------------------------------------
            If sStartCardNo <= sEndCardNo Then
                sCardNum = Long.Parse(sEndCardNo.Substring(0, 18)) - Long.Parse(sStartCardNo.Substring(0, 18))

                For nIndex As Integer = 0 To sCardNum
                    sCardNo = ShoppingCardNo.GetFullCardNo(Format(CULng(sStartCardNo.Substring(0, 18)) + nIndex, "#"))

                    electService = New InternetElects.Service()
                    Dim infoClass As New InternetElects.QueryOrderInfo()
                    infoClass.IssuerId = frmMain.sIssuerId
                    infoClass.CardNo = sCardNo

                    Dim infoDataClass As InternetElects.QueryOrderResponse = electService.QueryOrderRequest(infoClass)
                    If infoDataClass.CodeMsg.Code = "00" Then

                        Dim iCards As Integer = infoDataClass.DataList.Length - 1, sDate As String
                        For iCard As Integer = 0 To iCards
                            newRow = dtResult.Rows.Add()
                            newRow("CardNo") = infoDataClass.DataList(iCard).CardNo
                            newRow("Balance") = CDec(infoDataClass.DataList(iCard).Balance.ToString.Replace(".", sDecimalSeparator))
                            newRow("StoreName") = infoDataClass.DataList(iCard).Msg
                            newRow("ActivatedDate") = Date.Now.ToString("yyyy/MM/dd")

                            Try
                                sDate = infoDataClass.DataList(iCard).Expiry
                                sDate = sDate.Insert(4, "/").Insert(7, "/")
                                newRow("EffectiveDate") = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, CDate(sDate)))
                            Catch
                            End Try

                            If infoDataClass.DataList(iCard).Status = "Y" Then
                                newRow("CardState") = "已激活"
                            ElseIf infoDataClass.DataList(iCard).Status = "F" Then
                                newRow("CardState") = "已冻结"
                            ElseIf infoDataClass.DataList(iCard).Status = "C" Then
                                newRow("CardState") = "已撤销"
                            Else
                                newRow("CardState") = infoDataClass.DataList(iCard).Status
                            End If
                        Next
                    Else
                        dtResult.Rows.Clear()
                        newRow = dtResult.Rows.Add()
                        newRow("CardNo") = "Error"
                        newRow("StoreName") = infoDataClass.CodeMsg.Msg
                    End If

                    infoClass = Nothing
                    infoDataClass = Nothing
                Next
            End If
            'modify code 079:start-------------------------------------------------------------------------
        Catch ex As Exception
            dtResult.Rows.Clear()
            newRow = dtResult.Rows.Add()
            newRow("CardNo") = "Error"
            newRow("StoreName") = ex.Message
        Finally
            If electService IsNot Nothing Then electService.Dispose() : electService = Nothing
            dtResult.AcceptChanges()
        End Try

        Return dtResult
    End Function

    Public Function ElectronicFreeze(ByVal blIsToFreeze As Boolean, ByVal dtCULParameter As DataTable, ByVal dtCard As DataTable) As Integer
        frmMain.statusText.Text = "正在执行磁条卡自动" & IIf(blIsToFreeze, "冻结", "解冻") & "……"
        frmMain.statusRate.Visible = True
        frmMain.statusRate.Text = ""
        frmMain.statusProgress.Visible = True
        frmMain.statusProgress.Value = 0
        frmMain.statusMain.Refresh()

        Dim dtSource As New DataTable(), sCardNo As String, sStartCardNo As String = "", sEndCardNo As String = "", iCardQTY As Integer = 0
        dtSource.Columns.Add("StartCardNo", System.Type.GetType("System.String"))
        dtSource.Columns.Add("EndCardNo", System.Type.GetType("System.String"))
        dtSource.Columns.Add("CardQTY", System.Type.GetType("System.Int32"))
        For Each drCard As DataRow In dtCard.Select("", "CardNo")
            sCardNo = drCard("CardNo").ToString
            If sStartCardNo = "" Then
                sStartCardNo = sCardNo
                sEndCardNo = sCardNo
                iCardQTY = 1
            ElseIf CLng(sCardNo.Substring(0, 18)) - CLng(sEndCardNo.Substring(0, 18)) = 1 AndAlso iCardQTY < 1000 Then
                sEndCardNo = sCardNo
                iCardQTY += 1
            Else
                dtSource.Rows.Add(sStartCardNo, sEndCardNo, iCardQTY).EndEdit()
                sStartCardNo = sCardNo
                sEndCardNo = sCardNo
                iCardQTY = 1
            End If
        Next
        dtSource.Rows.Add(sStartCardNo, sEndCardNo, iCardQTY).EndEdit()
        dtSource.AcceptChanges()

        Dim electService As InternetElects.Service = Nothing, iCard As Integer = 0, iCards As Integer = dtCard.Rows.Count, sMerchantNo As String, iSucesses As Integer = 0
        Try
            electService = New InternetElects.Service
            Dim statusClass As New InternetElects.FreezeInfo, resp As New InternetElects.FreezeResponse()

            For Each drCard As DataRow In dtSource.Rows
                iCard += drCard("CardQTY")
                frmMain.statusRate.Text = "(" & iCard.ToString & "/" & iCards.ToString & ")"
                frmMain.statusProgress.Value = Int((iCard / iCards) * 100)
                frmMain.statusMain.Refresh()

                sMerchantNo = dtCULParameter.Select("CULCardBin='" & drCard("StartCardNo").ToString.Substring(4, 5) & "'")(0)("CULStoreCode").ToString

                statusClass.IssuerId = frmMain.sIssuerId
                statusClass.MerchantNo = sMerchantNo
                statusClass.Operators = frmMain.sLoginUserID
                statusClass.CardNo = drCard("StartCardNo")
                statusClass.Freeze = IIf(blIsToFreeze, "Y", "N")
                resp = electService.FreezeRequest(statusClass)

                If resp.CodeMsg.Code.ToUpper = "00" Then iSucesses += drCard("CardQTY")
            Next

            statusClass = Nothing
            resp = Nothing
        Catch
        Finally
            If electService IsNot Nothing Then electService.Dispose() : electService = Nothing
        End Try

        frmMain.statusText.Text = "就绪。"
        frmMain.statusRate.Text = ""
        frmMain.statusRate.Visible = False
        frmMain.statusProgress.Value = 0
        frmMain.statusProgress.Visible = False

        dtSource.Dispose() : dtSource = Nothing

        Return iSucesses
    End Function
    'modify code 072:end-------------------------------------------------------------------------

End Module
