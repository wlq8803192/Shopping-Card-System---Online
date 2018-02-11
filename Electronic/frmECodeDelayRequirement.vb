Public Class frmECodeDelayRequirement

    Private dvCULParameter As DataView

    Private Sub frmECodeDelayRequirement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        dvCULParameter.RowFilter = ""
        dvCULParameter.Table.AcceptChanges()

        Me.lblGetCodeResult.Text = ""
        Me.txtCardNo.Select()

    End Sub

    Private Sub btnVerify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerify.Click

        If Me.txtCardNo.Text.Trim = "" Then
            MessageBox.Show("请输入卡号！", "请输入！", MessageBoxButtons.OK)
            frmMain.statusText.Text = "就绪。"
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        Dim c4Service As C4ShoppingCardService.C4ShoppingCardService = Nothing, infoClass As C4ShoppingCardService.InfoClass = Nothing, infoDataClass As C4ShoppingCardService.InfoDataClass = Nothing
        Try
            c4Service = New C4ShoppingCardService.C4ShoppingCardService()
            infoClass = New C4ShoppingCardService.InfoClass()

            Dim sMerchantNo As String = dvCULParameter(0)("CULStoreCode").ToString
            infoClass.MerchantNo = sMerchantNo
            infoClass.UserID = frmMain.sLoginUserID
            infoClass.CardNoFrom = txtCardNo.Text.Trim()
            infoClass.CardNoTo = txtCardNo.Text.Trim()
            infoClass.IsPager = "N"
            infoClass.PageNo = "1"
            infoClass.PageSize = "1000000"
            infoDataClass = c4Service.info(infoClass)
            If infoDataClass.CodeMsg.Code = "OZ" Then '查询成功

                Me.btnVerify.Enabled = False
                Me.txtNewDate.Enabled = True
                Me.txtBalance.Text = infoDataClass.Cards(0).Balance
                Me.txtOldDate.Text = infoDataClass.Cards(0).ExpiredDate
                Me.lblGetCodeResult.ForeColor = Color.Blue
                Me.lblGetCodeResult.Text = "卡号验证成功！"
            Else
                Me.lblGetCodeResult.ForeColor = Color.Red
                Me.lblGetCodeResult.Text = "卡号验证失败！" & infoDataClass.CodeMsg.Msg
            End If
        Catch ex As Exception
            MessageBox.Show("因为CUL系统故障，无法进行验证操作！ 下面是CUL系统的内部错误提示：    " & Chr(13) & Chr(13) & ex.Message & Space(4), "出现CUL系统故障！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "因为CUL系统故障，无法进行验证操作！"
            Me.Cursor = Cursors.Default
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

        If Me.txtNewDate.Text.Trim = "" Then
            MessageBox.Show("请输入卡号延期的有效日期！", "请输入！", MessageBoxButtons.OK)
            frmMain.statusText.Text = "就绪。"
            DB.Close() : Me.Cursor = Cursors.Default
            Exit Sub
        End If

        Dim oldDateInt As Integer = Convert.ToInt32(Me.txtOldDate.Text.Trim()), nowDateInt As Integer = Convert.ToInt32(Date.Now.ToString("yyMM"))
        If oldDateInt > nowDateInt Then
            MessageBox.Show("该电子卡卡号仍未过期，无法进行延期！", "请输入！", MessageBoxButtons.OK)
            frmMain.statusText.Text = "就绪。"
            DB.Close() : Me.Cursor = Cursors.Default
            Exit Sub
        End If
        Dim nowDateIntEx As Integer = Convert.ToInt32(Date.Now.ToString("yy")), newDateIntEx As Integer = Convert.ToInt32(Convert.ToDateTime(Me.txtNewDate.Text.Trim()).ToString("yy"))
        If (newDateIntEx - nowDateIntEx) > 3 Then
            MessageBox.Show("电子码有效期不能超过3年！", "请输入！", MessageBoxButtons.OK)
            frmMain.statusText.Text = "就绪。"
            DB.Close() : Me.Cursor = Cursors.Default
            Exit Sub
        End If

        Dim c4Service As C4ShoppingCardService.C4ShoppingCardService = Nothing, infoClass As C4ShoppingCardService.BatchPostponeClass = Nothing, infoDataClass As C4ShoppingCardService.InfoDataClass = Nothing
        Try
            Dim sSQL As String = "", sValues As String = ""
            c4Service = New C4ShoppingCardService.C4ShoppingCardService()
            infoClass = New C4ShoppingCardService.BatchPostponeClass()

            Dim sMerchantNo As String = dvCULParameter(0)("CULStoreCode").ToString
            infoClass.MerchantNo = sMerchantNo
            infoClass.UserID = frmMain.sLoginUserID
            infoClass.CardNoFrom = txtCardNo.Text.Trim()
            infoClass.CardNoTo = txtCardNo.Text.Trim()
            infoClass.ReqExpireDate = Convert.ToDateTime(Me.txtNewDate.Text.Trim).ToString("YYMM")
            infoDataClass = c4Service.batchPostpone(infoClass)
            If infoDataClass.CodeMsg.Code = "IZ" Then '延期成功

                Me.btnOK.Enabled = False
                Me.lblGetCodeResult.ForeColor = Color.Blue
                Me.lblGetCodeResult.Text = "卡号延期成功！"
            Else
                Me.lblGetCodeResult.ForeColor = Color.Red
                Me.lblGetCodeResult.Text = "卡号延期失败！" & infoDataClass.CodeMsg.Msg
            End If

            sValues = sValues & "'" & infoDataClass.Cards(0).CardNo & "',"
            sValues = sValues & "'" & infoDataClass.Cards(0).Balance & "',"
            sValues = sValues & "'" & infoDataClass.Cards(0).ExpiredDate & "',"
            sValues = sValues & "'" & Me.txtNewDate.Text.Trim & "',"
            sValues = sValues & "'" & frmMain.sLoginUserID & "',"
            sValues = sValues & "'" & frmMain.sLoginUserRealName & "',"
            sValues = sValues & "'" & Date.Now.ToString & "',"
            sValues = sValues & "'" & infoDataClass.CodeMsg.Msg & "'"
            sSQL = sSQL & "insert into CULECodeDelay values (" & sValues & ");"

            DB.ModifyTable(sSQL)
            frmMain.statusText.Text = "就绪。"
        Catch ex As Exception
            MessageBox.Show("因为CUL系统故障，无法进行延期操作！ 下面是CUL系统的内部错误提示：    " & Chr(13) & Chr(13) & ex.Message & Space(4), "出现CUL系统故障！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "因为CUL系统故障，无法进行延期操作！"
            Me.Cursor = Cursors.Default
        End Try
        DB.Close()
    End Sub
End Class
