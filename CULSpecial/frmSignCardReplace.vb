Imports System.Net
Imports System.Management

Public Class frmSignCardReplace
    Private dvCULParameter As DataView
    Private cardNo As String = ""
    Private balance As String = ""
    Private effectiveDate As Date
    Private holderExist As Boolean = False
    Private cardNoFlag As Boolean = False
    Private newCardNoFlag As Boolean = False

    Private Sub frmSignCardReplace_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        For Each drCUL As DataRow In frmMain.dtLoginStructure.Select("ParentAreaID=33") '青岛市
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "71866", drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "72866", drCUL("CULStoreCode")).EndEdit()
        Next
        For Each drCUL As DataRow In frmMain.dtLoginStructure.Select("ParentAreaID=52") '郑州市
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "35601", drCUL("CULStoreCode")).EndEdit()
        Next
        For Each drCUL As DataRow In frmMain.dtLoginStructure.Select("ParentAreaID=39") '长沙市
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "73608", drCUL("CULStoreCode")).EndEdit()
        Next
        For Each drCUL As DataRow In frmMain.dtLoginStructure.Select("ParentAreaID=59") '海口市
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "11020", drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "11100", drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "11200", drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "11300", drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "11500", drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "11066", drCUL("CULStoreCode")).EndEdit()
        Next
        For Each drCUL As DataRow In dvCULParameter.Table.Select("CULCardBin Like '84%'")
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "60" & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), frmMain.signCardBin & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
        Next
        dvCULParameter.RowFilter = ""
        dvCULParameter.Table.AcceptChanges()

        'lblType.Text = ""
        lblError.Text = ""
        lblError2.Text = ""
        btnReplace.Enabled = False

        txtNewCardNo.Enabled = False
        GroupBox1.Enabled = False
        txtHolderIdNo.Enabled = False
        txtMobile.Enabled = False
        txtName.Enabled = False
        radioMale.Enabled = False
        radioFemale.Enabled = False
        txtHolderIdNo.Text = ""
        txtMobile.Text = ""
        txtName.Text = ""
        radioMale.Checked = True

        txtCardNo.Select()
    End Sub

    Private Sub txtCardNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCardNo.Leave
        cardNo = txtCardNo.Text.Trim
        If cardNo <> "" Then
            If cardNo.Length < 19 Then
                lblError.Text = "卡号位数不足 19 位"
                cardNoFlag = False
                Return
            End If
        End If
    End Sub

    Private Sub txtNewCardNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNewCardNo.Leave
        cardNo = txtNewCardNo.Text.Trim
        If cardNo <> "" Then
            If cardNo.Length < 19 Then
                lblError2.Text = "卡号位数不足 19 位"
                newCardNoFlag = False
                Return
            End If
        End If
    End Sub

    Private Sub txtNewCardNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNewCardNo.TextChanged
        lblError2.Text = ""
        cardNo = txtNewCardNo.Text.Trim
        newCardNoFlag = False
        If cardNo.Length = 19 Then
            If Not IsNumeric(cardNo) Then
                lblError2.Text = "卡号只能由数字组成！"
            ElseIf cardNo.Substring(0, 6) <> "2336" & frmMain.signCardBin Then
                lblError2.Text = "非实名制卡！"
            ElseIf cardNo <> ShoppingCardNo.GetFullCardNo(cardNo.Substring(0, 18)) Then
                lblError2.Text = "卡号校验码错误！"
            ElseIf dvCULParameter.Table.Select("CULCardBin='" & cardNo.Substring(4, 5) & "'").Length = 0 Then
                lblError2.Text = "无权操作该卡段！"
            Else
                Me.Cursor = Cursors.WaitCursor

                Dim sMerchantNo As String = dvCULParameter.Table.Select("CULCardBin='" & cardNo.Substring(4, 5) & "'")(0)("CULStoreCode").ToString
                Dim dtTemp As DataTable = ShoppingCardOperation.GetCRFCardState(sMerchantNo, cardNo, cardNo)
                dtTemp.DefaultView.Sort = "CardNo"

                If dtTemp.Rows.Count = 0 Then
                    lblError.Text = "卡不存在"
                ElseIf dtTemp.Rows(0)("CardNo").ToString = "Error" Then
                    lblError.Text = "Error"
                    MessageBox.Show("到CUL系统查询购物卡状态时发生错误！错误提示：" & dtTemp.Rows(0)("StoreName").ToString, "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    lblError2.Text = dtTemp.Rows(0)("CardState").ToString
                    If dtTemp.Rows(0)("CardState").ToString = "未激活" Then
                        lblError2.Text = lblError2.Text + "，可以作为目标卡"

                        If txtHolderIdNo.Text.Trim = "" Then
                            txtHolderIdNo.Enabled = True
                            GroupBox1.Enabled = True
                        End If

                        newCardNoFlag = True
                    Else
                        lblError2.Text = lblError2.Text + "，不可换卡"
                    End If
                End If
                Me.Cursor = Cursors.Default
            End If
        End If

        If Not newCardNoFlag Then
            btnReplace.Enabled = False

            GroupBox1.Enabled = False
            txtHolderIdNo.Enabled = False
            txtMobile.Enabled = False
            txtName.Enabled = False
            radioMale.Enabled = False
            radioFemale.Enabled = False
        ElseIf cardNoFlag Then
            btnReplace.Enabled = True
            If Not holderExist Then
                GroupBox1.Enabled = True
                txtHolderIdNo.Enabled = True
            End If
        End If
    End Sub

    Private Sub txtCardNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCardNo.TextChanged
        lblError.Text = ""
        cardNo = txtCardNo.Text.Trim
        cardNoFlag = False
        If cardNo.Length = 19 Then
            If Not IsNumeric(cardNo) Then
                lblError.Text = "卡号只能由数字组成！"
            ElseIf cardNo.Substring(0, 6) <> "233684" AndAlso cardNo.Substring(0, 6) <> "233660" Then
                lblError.Text = "卡类型错误！"
            ElseIf cardNo <> ShoppingCardNo.GetFullCardNo(cardNo.Substring(0, 18)) Then
                lblError.Text = "卡号校验码错误！"
            ElseIf dvCULParameter.Table.Select("CULCardBin='" & cardNo.Substring(4, 5) & "'").Length = 0 Then
                lblError.Text = "无权操作该卡段！"
            Else
                Me.Cursor = Cursors.WaitCursor

                Dim sMerchantNo As String = dvCULParameter.Table.Select("CULCardBin='" & cardNo.Substring(4, 5) & "'")(0)("CULStoreCode").ToString
                Dim dtTemp As DataTable = ShoppingCardOperation.GetCRFCardState(sMerchantNo, cardNo, cardNo)
                dtTemp.DefaultView.Sort = "CardNo"

                If dtTemp.Rows.Count = 0 Then
                    lblError.Text = "卡不存在"
                ElseIf dtTemp.Rows(0)("CardNo").ToString = "Error" Then
                    lblError.Text = "Error"
                    MessageBox.Show("到CUL系统查询购物卡状态时发生错误！错误提示：" & dtTemp.Rows(0)("StoreName").ToString, "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    lblError.Text = dtTemp.Rows(0)("CardState").ToString
                    If dtTemp.Rows(0)("CardState").ToString = "已激活" Then
                        'lblError.Text = dtTemp.Rows(0)("CardState").ToString
                        'lblError.Text = dtTemp.Rows(0)("Balance").ToString
                        balance = dtTemp.Rows(0)("Balance").ToString
                        effectiveDate = dtTemp.Rows(0)("EffectiveDate")
                        lblError.Text = lblError.Text & "，余额：" & balance

                        Dim DB As New DataBase
                        Dim dtResult As DataTable
                        DB.Open()
                        If Not DB.IsConnected Then
                            frmMain.statusText.Text = "系统因连接不到数据库而无法进行查询。请检查数据库连接。"
                            Me.Cursor = Cursors.Default
                            Return
                        End If

                        dtResult = DB.GetDataTable("select * from SignCardList where CardType='实名制卡' and CardNo='" & cardNo & "'")

                        If dtResult.Rows.Count = 0 Then
                            holderExist = False
                            txtHolderIdNo.Text = ""
                            txtMobile.Text = ""
                            txtName.Text = ""
                            txtHolderIdNo.Enabled = True
                            GroupBox1.Enabled = True
                            'lblError.Text = "非实名制卡"
                        Else
                            'lblError.Text = "实名制卡"
                            holderExist = True
                            GroupBox1.Enabled = False
                            txtHolderIdNo.Text = dtResult.Rows(0)("HolderIdNo")
                            dtResult = DB.GetDataTable("select * from HolderInfoList where HolderIdNo='" & txtHolderIdNo.Text & "'")
                            txtMobile.Text = dtResult.Rows(0)("Mobile")
                            txtName.Text = dtResult.Rows(0)("HolderName")
                            If dtResult.Rows(0)("Gender") = "男" Then
                                radioMale.Checked = True
                            Else
                                radioFemale.Checked = True
                            End If
                        End If

                        If holderExist Then
                            cardNoFlag = True
                        Else
                            lblError.Text = "非实名制卡，不可换卡"
                        End If
                    Else
                        lblError.Text = lblError.Text + "，不可换卡"
                    End If
                End If
                Me.Cursor = Cursors.Default
            End If
        End If

        If Not cardNoFlag Then
            txtNewCardNo.Enabled = False

            btnReplace.Enabled = False

            GroupBox1.Enabled = False
            txtHolderIdNo.Enabled = False
            txtMobile.Enabled = False
            txtName.Enabled = False
            radioMale.Enabled = False
            radioFemale.Enabled = False
            txtHolderIdNo.Text = ""
            txtMobile.Text = ""
            txtName.Text = ""
            radioMale.Checked = True
        Else
            txtNewCardNo.Enabled = True
            If newCardNoFlag Then
                btnReplace.Enabled = True
            End If
        End If
    End Sub

    '身份证号验证函数
    Private Function CheckCredentialsNo(ByVal aCredentialsNo As String) As Boolean
        If (Not IsNumeric(aCredentialsNo.Substring(0, 17))) OrElse (Not IsDate(aCredentialsNo.Substring(6, 8).Insert(4, "/").Insert(7, "/"))) OrElse aCredentialsNo <> CustomerIDNo.GetFullIDNo(aCredentialsNo.Substring(0, 17)) Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub txtHolderIdNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHolderIdNo.TextChanged
        txtMobile.Enabled = False
        txtName.Enabled = False
        radioMale.Enabled = False
        radioFemale.Enabled = False
        'btnReplace.Enabled = False

        'lblError.Text = ""
        txtMobile.Text = ""
        txtName.Text = ""
        radioMale.Checked = True

        Dim holderIdNo As String
        Dim DB As New DataBase
        Dim dtResult As DataTable
        holderIdNo = txtHolderIdNo.Text.Trim

        If holderIdNo.Length = 18 Then
            If CheckCredentialsNo(holderIdNo) Then
                DB.Open()
                If Not DB.IsConnected Then
                    frmMain.statusText.Text = "系统因连接不到数据库而无法进行查询。请检查数据库连接。"
                    Me.Cursor = Cursors.Default : Return
                End If
                dtResult = DB.GetDataTable("select * from HolderInfoList where HolderIdNo='" & holderIdNo & "'")

                If dtResult.Rows.Count = 0 Then
                    txtMobile.Enabled = True
                    txtName.Enabled = True
                    radioMale.Enabled = True
                    radioFemale.Enabled = True
                    radioMale.Checked = True
                Else
                    txtMobile.Text = dtResult.Rows(0)("Mobile").ToString
                    txtName.Text = dtResult.Rows(0)("HolderName").ToString
                    If dtResult.Rows(0)("Gender").ToString = "男" Then
                        radioMale.Checked = True
                    Else
                        radioFemale.Checked = True
                    End If
                End If
                DB.Close()
                dtResult.Dispose()
                dtResult = Nothing

                'If lblType.Text = "实名制卡" Then
                '    btnReplace.Enabled = False
                'Else
                '    btnReplace.Enabled = True
                'End If
            Else
                MessageBox.Show("身份证号非法！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    'Private Sub btnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuery.Click
    '    Dim DB As New DataBase
    '    Dim dtResult As DataTable

    '    If lblError.Text.Trim <> "" Then Return

    '    Me.Cursor = Cursors.WaitCursor

    '    cardNo = txtCardNo.Text.Trim
    '    Dim sMerchantNo As String = dvCULParameter.Table.Select("CULCardBin='" & cardNo.Substring(4, 5) & "'")(0)("CULStoreCode").ToString
    '    Dim dtTemp As DataTable = ShoppingCardOperation.GetCRFCardState(sMerchantNo, cardNo, cardNo)
    '    dtTemp.DefaultView.Sort = "CardNo"

    '    If dtTemp.Rows.Count = 0 Then
    '        lblError.Text = "卡不存在"
    '        Me.Cursor = Cursors.Default
    '        Return
    '    End If

    '    If cardNo.Length = 19 AndAlso cardNo.Substring(4, 2) = frmMain.signCardBin Then
    '        lblError.Text = "卡类型错误"
    '        Me.Cursor = Cursors.Default
    '        Return
    '    End If

    '    If dtTemp.Rows(0)("CardNo").ToString = "Error" Then
    '        lblError.Text = "Error"
    '        MessageBox.Show("到CUL系统查询购物卡状态时发生错误！错误提示：" & dtTemp.Rows(0)("StoreName").ToString, "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        Me.Cursor = Cursors.Default
    '        Return
    '    ElseIf dtTemp.Rows(0)("CardState").ToString = "已激活" Then
    '        lblError.Text = dtTemp.Rows(0)("CardState").ToString
    '        balance = dtTemp.Rows(0)("Balance").ToString
    '        effectiveDate = dtTemp.Rows(0)("EffectiveDate").ToString
    '        Me.Cursor = Cursors.Default
    '        Return
    '    End If

    '    DB.Open()
    '    If Not DB.IsConnected Then
    '        frmMain.statusText.Text = "系统因连接不到数据库而无法进行查询。请检查数据库连接。"
    '        Me.Cursor = Cursors.Default
    '        Return
    '    End If

    '    dtResult = DB.GetDataTable("select * from SignCardList where CardType='实名制卡' and CardNo='" & cardNo & "'")

    '    If dtResult.Rows.Count = 0 Then
    '        txtHolderIdNo.Enabled = True
    '        GroupBox1.Enabled = True
    '        lblError.Text = "非实名制卡"
    '    Else
    '        lblError.Text = "实名制卡"
    '        GroupBox1.Enabled = False
    '        txtHolderIdNo.Text = dtResult.Rows(0)("HolderIdNo")
    '        dtResult = DB.GetDataTable("select * from HolderInfoList where HolderIdNo='" & txtHolderIdNo.Text & "'")
    '        txtMobile.Text = dtResult.Rows(0)("Mobile")
    '        txtName.Text = dtResult.Rows(0)("HolderName")
    '        If dtResult.Rows(0)("Gender") = "男" Then
    '            radioMale.Checked = True
    '        Else
    '            radioFemale.Checked = True
    '        End If
    '    End If

    '    DB.Close()
    '    dtResult.Dispose()
    '    dtResult = Nothing
    '    Me.Cursor = Cursors.Default
    'End Sub

    Private Sub btnReplace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReplace.Click
        Dim DB As New DataBase
        Dim strsql1 As String = ""
        Dim strsql2 As String = ""
        Dim strsql3 As String = ""
        Dim strDel As String = ""
        Dim gender As String = "男"
        Dim userName As String
        Dim dtResult1 As DataTable
        Dim dtResult2 As DataTable

        'If lblError.Text.Trim <> "" Then Return

        If txtName.Text.Trim = "" Then
            lblError.Text = "姓名为空！"
            Return
        End If

        If txtMobile.Text.Trim = "" Then
            lblError.Text = "手机号为空！"
            Return
        End If

        If txtMobile.Text.Trim.Length <> 11 Then
            lblError.Text = "手机号位数错误！"
            Return
        End If

        If Not IsNumeric(txtMobile.Text.Trim) Then
            lblError.Text = "手机号错误！"
            Return
        End If

        If txtNewCardNo.Text.Trim = "" Then
            lblError.Text = "新卡号为空！"
            Return
        End If

        If txtNewCardNo.Text.Trim.Length <> 19 Then
            lblError.Text = "新卡号位数错误！"
            Return
        End If

        If Not IsNumeric(txtNewCardNo.Text.Trim) Then
            lblError.Text = "新卡号错误！"
            Return
        End If

        Me.Cursor = Cursors.WaitCursor

        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法进行查询。请检查数据库连接。"
            Me.Cursor = Cursors.Default
            Return
        End If

        'CUL
        Dim msg As C4ShoppingCardService.CodeMsg = Nothing
        Dim c4Service As New C4ShoppingCardService.C4ShoppingCardService
        'Dim cardSignFlagRegisterBean As New C4ShoppingCardService.CardSignFlagRegisterBean
        'Dim cardSignFlagRegisterInfos(0) As C4ShoppingCardService.CardSignFlagRegisterInfo
        Dim islvClass As New C4ShoppingCardService.IslvClass
        Dim irecClass As New C4ShoppingCardService.IrecClass

        Dim guIDClass = New C4ShoppingCardService.GuIDClass
        Dim sMerchantNo As String

        Try
            sMerchantNo = dvCULParameter.Table.Select("CULCardBin='" & cardNo.Substring(4, 5) & "'")(0)("CULStoreCode").ToString
            'cardSignFlagRegisterInfos(0) = New C4ShoppingCardService.CardSignFlagRegisterInfo
            'cardSignFlagRegisterInfos(0).CardNoFrom = cardNo
            'cardSignFlagRegisterInfos(0).CardNoTo = cardNo
            'cardSignFlagRegisterInfos(0).CardNum = "1"
            'cardSignFlagRegisterInfos(0).SignFlag = "S"
            'cardSignFlagRegisterBean.UserID = sMerchantNo
            'cardSignFlagRegisterBean.MerchantNo = sMerchantNo
            'cardSignFlagRegisterBean.CardSignFlagRegisterInfos = cardSignFlagRegisterInfos
            guIDClass.GuID = frmMain.sGuID

            'msg = c4Service.cardSignFlagRegister(cardSignFlagRegisterBean, guIDClass)

            irecClass.MerchantNo = sMerchantNo
            irecClass.UserID = sMerchantNo
            irecClass.CardNoFrom = txtCardNo.Text.Trim
            irecClass.CardNoTo = txtCardNo.Text.Trim
            msg = c4Service.irec(irecClass, guIDClass) '先回收目标卡

            If msg.Code = "MZ" Then
                islvClass.MerchantNo = sMerchantNo
                islvClass.UserID = sMerchantNo
                islvClass.CardNoFrom = txtNewCardNo.Text.Trim
                islvClass.CardNoTo = txtNewCardNo.Text.Trim
                islvClass.Amount = balance
                islvClass.TotalAmount = balance
                islvClass.ExpiredDate = Format(effectiveDate, "yyyyMMdd").Substring(2, 4)
                msg = c4Service.islv(islvClass, guIDClass)
            Else
                Me.Cursor = Cursors.Default
                MessageBox.Show(msg.Code & vbCrLf & msg.Msg, "回收原卡失败，CUL操作失败！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        Catch ex As Exception
            MessageBox.Show("因为CUL系统故障，无法进行换卡操作！ 下面是CUL系统的内部错误提示：    " & Chr(13) & Chr(13) & ex.Message & Space(4), "出现CUL系统故障！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "因为CUL系统故障，无法进行换卡操作！"
            If c4Service IsNot Nothing Then c4Service.Dispose() : c4Service = Nothing
            DB.Close() : Me.Cursor = Cursors.Default : Return
        End Try

        If msg.Code.ToUpper = "HZ" Then
            If radioMale.Checked Then
                gender = "男"
            End If

            If radioFemale.Checked Then
                gender = "女"
            End If

            Dim dtResult As DataTable = DB.GetDataTable("select * from HolderInfoList where HolderIdNo='" & txtHolderIdNo.Text & "'")
            If dtResult.Rows.Count = 0 Then
                strsql1 = "insert into HolderInfoList (HolderIdNo,HolderName,Gender,Mobile) values ('" & txtHolderIdNo.Text.Trim & "','" & txtName.Text.Trim & "','" & gender & "','" & txtMobile.Text.Trim & "')"
            End If
            strsql2 = "insert into SignCardListNew (CardNo,HolderIdNo,CardType) values ('" & txtNewCardNo.Text.Trim & "','" & txtHolderIdNo.Text.Trim & "','实名制卡')"
            strDel = "delete from SignCardList where CardNo='" & txtCardNo.Text.Trim & "'"

            dtResult1 = DB.GetDataTable("select * from LoginInfo where SSID=" & frmMain.sSSID, False)
            dtResult2 = DB.GetDataTable("select * from UserList where USerID=" & frmMain.sLoginUserID, False)

            If dtResult2.Rows.Count = 0 Then
                userName = ""
            Else
                userName = dtResult2.Rows(0).Item("UserChineseName")
            End If

            If dtResult1.Rows.Count = 0 Then
                Dim sComputerName As String = Dns.GetHostName(), sComputerIP As String = "（未知）", sComputerMAC As String = "（未知）"

                Dim WMI As New ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration")
                For Each WMIOBJ As ManagementObject In WMI.Get
                    If CBool(WMIOBJ("IPEnabled")) Then
                        sComputerIP = WMIOBJ("IPAddress")(0)
                        sComputerMAC = WMIOBJ("MACAddress")
                        If sComputerIP.IndexOf("10.") = 0 Then Exit For
                    End If
                Next
                WMI = Nothing

                strsql3 = "insert into CULNewSignCardReplace (CardNo,NewCardNo,OperatorID,OperatorName,ComputerName,ComputerIP,ComputerMAC,OperationTime,HolderIdNo,HolderName,Gender,Mobile) values('" & _
                            txtCardNo.Text.Trim & "','" & txtNewCardNo.Text.Trim & "'," & frmMain.sLoginUserID & ",'" & userName & "','" & sComputerName & "','" & sComputerIP & _
                            sComputerMAC & "',getdate(),'" & txtHolderIdNo.Text.Trim & "','" & txtName.Text.Trim & "','" & gender & "','" & txtMobile.Text.Trim & "')"
            Else
                strsql3 = "insert into CULNewSignCardReplace (CardNo,NewCardNo,OperatorID,OperatorName,ComputerName,ComputerIP,ComputerMAC,OperationTime,HolderIdNo,HolderName,Gender,Mobile) values('" & _
                            txtCardNo.Text.Trim & "','" & txtNewCardNo.Text.Trim & "'," & dtResult1.Rows(0).Item("UserID") & ",'" & userName & "','" & dtResult1.Rows(0).Item("ComputerName") & "','" & dtResult1.Rows(0).Item("ComputerIP") & "','" & _
                            dtResult1.Rows(0).Item("ComputerMAC") & "',getdate(),'" & txtHolderIdNo.Text.Trim & "','" & txtName.Text.Trim & "','" & gender & "','" & txtMobile.Text.Trim & "')"
            End If


            If strsql1.Trim <> "" Then
                If DB.ModifyTable(strsql1) = -1 Then
                    Me.Cursor = Cursors.Default
                    MessageBox.Show("换卡已成功，但系统在保存结果时出错。    " & Chr(13) & Chr(13) & "请不要对该卡做重复确认，请及时通知National IT。    ", "换卡成功但保存结果失败！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf DB.ModifyTable(strDel) = -1 OrElse DB.ModifyTable(strsql2) = -1 OrElse DB.ModifyTable(strsql3) = -1 Then
                    Me.Cursor = Cursors.Default
                    MessageBox.Show("换卡已成功，但系统在保存结果时出错。    " & Chr(13) & Chr(13) & "请不要对该卡做重复确认，请及时通知National IT。    ", "换卡成功但保存结果失败！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Me.Cursor = Cursors.Default
                    MessageBox.Show("操作成功！    ", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                If DB.ModifyTable(strDel) = -1 OrElse DB.ModifyTable(strsql2) = -1 OrElse DB.ModifyTable(strsql3) = -1 Then
                    Me.Cursor = Cursors.Default
                    MessageBox.Show("换卡已成功，但系统在保存结果时出错。    " & Chr(13) & Chr(13) & "请不要对该卡做重复确认，请及时通知National IT。    ", "换卡成功但保存结果失败！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Me.Cursor = Cursors.Default
                    MessageBox.Show("操作成功！    ", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Else
            Me.Cursor = Cursors.Default
            MessageBox.Show(msg.Code & vbCrLf & msg.Msg, "回收原卡成功，新卡充值失败，CUL操作失败！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        'lblType.Text = ""
        lblError.Text = ""
        lblError2.Text = ""
        btnReplace.Enabled = False

        txtCardNo.Text = ""
        txtNewCardNo.Text = ""
        txtNewCardNo.Enabled = False
        GroupBox1.Enabled = False
        txtHolderIdNo.Enabled = False
        txtMobile.Enabled = False
        txtName.Enabled = False
        radioMale.Enabled = False
        radioFemale.Enabled = False
        txtHolderIdNo.Text = ""
        txtMobile.Text = ""
        txtName.Text = ""
        radioMale.Checked = True
    End Sub

    'Private Sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
    '    lblError.Text = ""
    'End Sub

    'Private Sub txtMobile_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMobile.TextChanged
    '    lblError.Text = ""
    'End Sub

    Private Sub btnHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistory.Click
        frmSignCardRegisterHistory.ShowDialog()
        frmSignCardRegisterHistory.Dispose()
    End Sub
End Class