Public Class frmSupply

    Private Sub frmSupplySms_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnExcute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcute.Click
        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法进行查询。请检查数据库连接。"
            Me.Cursor = Cursors.Default
            Return
        End If

        Dim IsSelect1 As Boolean = TabPage1.CanFocus
        Dim IsSelect2 As Boolean = TabPage2.CanFocus
        If IsSelect1 Then
            '补发短信
            Dim sCardNo As String = txtCardNo.Text.Trim(), sMobile As String = txtMobile.Text.Trim()
            If sCardNo = "" Then
                MessageBox.Show("卡号不能为空！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            Else
                If Len(sCardNo) <> 19 Then
                    MessageBox.Show("卡号长度不正确！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                Else
                    If sCardNo.Contains("233665999") Then
                        If sCardNo <> ShoppingCardNo.GetFullCardNo(sCardNo.Substring(0, 18)) Then
                            MessageBox.Show("卡号校验码错误！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return
                        End If
                    Else
                        MessageBox.Show("卡号不是正确的电子卡类型！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                End If
            End If
            If sMobile = "" Then
                MessageBox.Show("手机号不能为空！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            Else
                If Not IsNumeric(sMobile) Then
                    MessageBox.Show("手机号错误！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
                If sMobile.Length <> 11 Then
                    MessageBox.Show("手机号位数错误！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            End If

            Dim dtResult As DataTable = DB.GetDataTable("select EID from Electronic where EID in (select EID from ElectronicDetails where StartCardNo <= '" & sCardNo & "' and EndCardNo  >= '" & sCardNo & "' and TelePhone = '" & sMobile & "')")
            If dtResult.Rows.Count = 0 Then
                MessageBox.Show("卡号和手机号在系统中不存在！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim iElects As InternetElects.Service = Nothing
            Dim resendMsgInfo As InternetElects.ResendMsgInfo = Nothing, resendMsgResponse As InternetElects.ResendMsgResponse = Nothing

            Try
                iElects = New InternetElects.Service()
                resendMsgInfo = New InternetElects.ResendMsgInfo()
                resendMsgResponse = New InternetElects.ResendMsgResponse()
                resendMsgInfo.Mobile = sMobile
                resendMsgInfo.CardNo = sCardNo
                resendMsgInfo.IssuerId = frmMain.sIssuerId
                resendMsgInfo.Operators = frmMain.sLoginUserID

                resendMsgResponse = iElects.ResendMsgRequest(resendMsgInfo) '补发短信调用银商接口
                If resendMsgResponse.CodeMsg.Code = "00" Then
                    frmMain.statusText.Text = "已经将补发短信提交到CUL系统，并且补发短信成功。"
                    MessageBox.Show("已经将补发短信提交到CUL系统，并且补发短信成功！ ", "Cancellation OK.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    frmMain.statusText.Text = resendMsgResponse.CodeMsg.Msg
                    MessageBox.Show(resendMsgResponse.CodeMsg.Msg, resendMsgResponse.CodeMsg.Msg, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception

            End Try

            Dim sSQL As String = "'" & frmMain.sLoginUserID & "','" & Date.Now.ToString() & "','补发短信','" & sCardNo & "','" & sMobile & "','','','','" & resendMsgResponse.CodeMsg.Msg & "','" & resendMsgResponse.CodeMsg.Code & "'"
            DB.ModifyTable("insert into ElectronicLog values (" & sSQL & ")")
            btnExcute.Enabled = False
            DB.Close()
        End If
        If IsSelect2 Then
            '补发邮件
            Dim sOrderNo As String = txtCardNo2.Text.Trim()
            If sOrderNo = "" Then
                MessageBox.Show("订单号不能为空！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            Else
                Dim dtResult As DataTable = DB.GetDataTable("select EID from Electronic where OrderNo = '" & sOrderNo & "' and EType = 2")
                If dtResult.Rows.Count = 0 Then
                    MessageBox.Show("订单号在系统中不存在！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            End If

            Dim iElects As InternetElects.Service = Nothing
            Dim resendMailInfo As InternetElects.ResendMailInfo = Nothing, resendMailResponse As InternetElects.ResendMailResponse = Nothing

            Try
                iElects = New InternetElects.Service()
                resendMailInfo = New InternetElects.ResendMailInfo()
                resendMailResponse = New InternetElects.ResendMailResponse()
                resendMailInfo.OrderNo = sOrderNo
                resendMailInfo.IssuerId = frmMain.sIssuerId
                resendMailInfo.User = frmMain.sLoginUserID

                resendMailResponse = iElects.ResendMailRequest(resendMailInfo) '补发邮件调用银商接口
                If resendMailResponse.CodeMsg.Code = "00" Then
                    frmMain.statusText.Text = "已经将补发邮件提交到CUL系统，并且补发邮件成功。"
                    MessageBox.Show("已经将补发邮件提交到CUL系统，并且补发邮件成功。", "Cancellation OK.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    frmMain.statusText.Text = resendMailResponse.CodeMsg.Msg
                    MessageBox.Show(resendMailResponse.CodeMsg.Msg, resendMailResponse.CodeMsg.Msg, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception

            End Try

            Dim sSQL As String = "'" & frmMain.sLoginUserID & "','" & Date.Now.ToString() & "','补发邮件','','','','" & sOrderNo & "','','" & resendMailResponse.CodeMsg.Msg & "','" & resendMailResponse.CodeMsg.Code & "'"
            DB.ModifyTable("insert into ElectronicLog values (" & sSQL & ")")
            btnExcute.Enabled = False
            DB.Close()
        End If
    End Sub
End Class