'modify code 065:
'date;2016/8/26
'auther:Qipeng
'remark:修正保存实名制卡和非实名制卡时,连CUL进行检查时报错,数组越界

'modify code 074:
'date;2017/6/22
'auther:Qipeng
'remark:修正保存销售单时，连接CUL验证卡号(礼品卡)有效性报错，数组越界

Public Class frmCheckCardFromCUL

    Private Sub frmCheckCardFromCUL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        frmSelling.blNeedReloadCard = False
        Me.lblTitle.Text = "共有 " & Format(frmSelling.dtAllCheckedCard.Select("UsageState=9").Length, "#,0") & " 张卡需要到银商系统检查其可用状态。"
        Me.theTimer.Enabled = True
    End Sub

    Private Sub theTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles theTimer.Tick
        Me.theTimer.Enabled = False
        Me.Cursor = Cursors.WaitCursor

        Me.lblError.Visible = False
        Me.lblInfo.Text = "已完成： 0 张 (0 %)"
        Me.lblPrompt.Visible = False
        Me.pnlRetry.Enabled = False

        Dim dvCULParameter As DataView = frmMain.dtLoginStructure.Copy.DefaultView
        dvCULParameter.RowFilter = "AreaType='S'"
        dvCULParameter = dvCULParameter.ToTable(False, "AreaID", "CULCardBin", "CULStoreCode").DefaultView
        dvCULParameter.RowFilter = "CULCardBin Like '%|%'"
        For Each drCUL As DataRowView In dvCULParameter
            Dim saCardBins() As String = drCUL("CULCardBin").ToString.Split("|")
            For bIndex As Byte = 0 To saCardBins.Length - 1
                dvCULParameter.Table.Rows.Add(drCUL("AreaID"), saCardBins(bIndex), drCUL("CULStoreCode")).EndEdit()
            Next
        Next
        dvCULParameter.RowFilter = ""
        dvCULParameter.Table.AcceptChanges()

        Dim sDecimalSeparator As String = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
        Dim c4Service As C4ShoppingCardService.C4ShoppingCardService = Nothing, infoClass As C4ShoppingCardService.InfoClass = Nothing, infoDataClass As C4ShoppingCardService.InfoDataClass = Nothing
        Try
            c4Service = New C4ShoppingCardService.C4ShoppingCardService()
            infoClass = New C4ShoppingCardService.InfoClass()
        Catch ex As Exception
            For Each drCard As DataRow In frmSelling.dtAllCheckedCard.Select("UsageState=9")
                drCard("UnchargableReason") = "查询失败（" & ex.Message & "）！"
            Next
            Me.lblError.Visible = True
            Me.lblInfo.Text = ex.Message
            Me.pnlRetry.Visible = True
            Me.pnlRetry.Enabled = True
            Me.lblPrompt.Visible = True
            Me.Height = 160
            Me.Cursor = Cursors.Default
            Return
        End Try

        Dim iCard As Integer = 0, iCards As Integer = frmSelling.dtAllCheckedCard.Select("UsageState=9").Length, sCardNo As String, sMerchantNo As String
        'modify code 046:start-------------------------------------------------------------------------
        Dim dtSignCard As DataTable
        Dim maxChargeValue As String = "1,000"
        'modify code 046:end-------------------------------------------------------------------------
        For Each drCard As DataRow In frmSelling.dtAllCheckedCard.Select("UsageState=9")
            sCardNo = drCard("CardNo").ToString
            Me.lblInfo.Text = "已完成： " & Format(iCard, "#,0") & " 张 (" & CInt((iCard / iCards) * 100).ToString & " %)        正在检查： " & sCardNo
            Me.Refresh()

            'modify code 046:start-------------------------------------------------------------------------
            dtSignCard = frmSelling.getSignCardList(sCardNo)
            maxChargeValue = "1,000"
            If dtSignCard.Rows.Count > 0 Then
                maxChargeValue = "5,000"
            End If
            'modify code 046:end-------------------------------------------------------------------------

            sMerchantNo = sCardNo.Substring(4, 5)

            'modify code 065:start-------------------------------------------------------------------------
            If Not sMerchantNo.Contains("61") AndAlso Not sMerchantNo.Contains("65") Then
                sMerchantNo = "84" & sMerchantNo.Substring(2)
            End If
            'modify code 074:start-------------------------------------------------------------------------
            If sMerchantNo.Contains("6061") Then
                sMerchantNo = "84" & sMerchantNo.Substring(2)
            End If
            'modify code 074:end-------------------------------------------------------------------------
            'modify code 065:end-------------------------------------------------------------------------

            sMerchantNo = dvCULParameter.Table.Select("CULCardBin='" & sMerchantNo & "'")(0)("CULStoreCode").ToString
            Try
                infoClass.MerchantNo = sMerchantNo
                infoClass.UserID = sMerchantNo
                infoClass.CardNoFrom = sCardNo
                infoClass.CardNoTo = sCardNo
                infoClass.IsPager = "N"
                infoClass.PageNo = "1"
                infoDataClass = c4Service.info(infoClass)
                If infoDataClass.CodeMsg.Code = "OZ" Then
                    drCard("Balance") = CDec(infoDataClass.Cards(0).Balance.ToString.Replace(".", sDecimalSeparator))
                    If infoDataClass.Cards(0).HotReason = "冻结" Then
                        drCard("UsageState") = 7
                        drCard("UnchargableReason") = "该卡已冻结！"
                    ElseIf infoDataClass.Cards(0).HotReason = "结束" Then
                        drCard("UsageState") = 8
                        drCard("UnchargableReason") = "该卡已结束使用（回收后方可使用）！"
                    ElseIf infoDataClass.Cards(0).Status = "激活" Then
                        drCard("UsageState") = 0 '该卡可用，但可能面值受限
                        'modify code 046:start-------------------------------------------------------------------------
                        'drCard("UnchargableReason") = "该卡余额 " & Format(drCard("Balance"), "#,0.00").Replace(".00", "") & " 元，加上本次充值金额已超过 1,000 元！"
                        drCard("UnchargableReason") = "该卡余额 " & Format(drCard("Balance"), "#,0.00").Replace(".00", "") & " 元，加上本次充值金额已超过 " & maxChargeValue & " 元！"
                        'modify code 046:end-------------------------------------------------------------------------
                    Else
                        frmSelling.blNeedReloadCard = True '该卡不是再充值卡，可能是新卡或回收卡，需要重传
                        drCard("UsageState") = 0 '该卡可用
                        If infoDataClass.Cards(0).ActivedDate = "" Then
                            drCard("CardType") = 0 '新卡
                        Else
                            drCard("CardType") = 1 '回收卡
                        End If
                        drCard("UnchargableReason") = DBNull.Value
                    End If
                Else '状态仍然未知
                    drCard("UnchargableReason") = "查询失败（" & infoDataClass.CodeMsg.Msg & "）！"
                End If
            Catch ex As Exception '状态仍然未知
                drCard("UsageState") = 9
                drCard("UnchargableReason") = "查询失败（" & ex.Message & "）！"
            End Try

            iCard += 1
            Me.pgbRunning.Value = (iCard / iCards) * 100
            Me.Refresh()
        Next
        Me.lblInfo.Text = "已完成： " & Format(iCards, "#,0") & " 张 (100 %)"
        Me.Refresh()

        c4Service = Nothing
        infoClass = Nothing
        infoDataClass = Nothing
        Me.Cursor = Cursors.Default
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnRetry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetry.Click
        Me.theTimer.Enabled = True
    End Sub
End Class