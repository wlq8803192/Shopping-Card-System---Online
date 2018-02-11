Public Class frmInternetSales_ForRuiTai

    Public sCityID As String = "", sStoreID As String = ""
    Public sSalesBillID As String = ""

    Private IWebService As InternetRuiTaiWebService.Service = Nothing
    Public ci As InternetRuiTaiWebService.CodeInfo = Nothing
    Public cir As InternetRuiTaiWebService.CodeInfoResponse = Nothing

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnVerify_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVerify.Click

        If Me.txtCodePassword.Text.Trim = "" Then
            MessageBox.Show("请输入电子券密码！", "请输入！", MessageBoxButtons.OK)
            Exit Sub
        End If

        Me.cir = Nothing

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在执行验证电子券密码操作……"

        Try
            '清空
            InitForm()
            Me.lblGetCodeResult.Text = ""

            sSalesBillID = ""
            sSalesBillID = GetSalesBillID()
            If sSalesBillID <> "" Then
                Me.lblGetCodeResult.ForeColor = Color.Blue
                Me.lblGetCodeResult.Text = "此电子券已在线下提卡销售单中使用，点击[确定]查看订单。"
                Me.btnOK.Enabled = True
                frmMain.statusText.Text = "就绪"
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            IWebService = New InternetRuiTaiWebService.Service()
            ci = New InternetRuiTaiWebService.CodeInfo()
            With ci
                .CodePassword = Me.txtCodePassword.Text.Trim
                .DealAmountTotal = "0"
                .DealDate = Format(Now, "yyyy-MM-dd hh:mm:ss")
                .SerialNo = "SHCARREFOUR" + frmMain.sShopId + "1001" + Format(Now, "yyyyMMddHHmmss")

                .ShopId = frmMain.sShopId
                .Account = frmMain.sShopAccount
                .Passwd = frmMain.sShopPassword
                .Key = frmMain.sShopKey
            End With
            cir = IWebService.QueryCode(ci)
            If cir.CodeMsg.Code = "0" Then '查询成功
                Me.txtCodeAmount.Text = cir.CodeAmount / 100
                Me.txtValidDate.Text = cir.ValidDate
                Select Case cir.CodeType
                    Case "001", "002"
                        Me.txtCodeType.Text = "单次消费"
                    Case "003", "004"
                        Me.txtCodeType.Text = "多次消费"
                    Case "007"
                        Me.txtCodeType.Text = "折扣券"
                    Case Else
                        Me.txtCodeType.Text = "未知"
                End Select
                
                Me.lblGetCodeResult.ForeColor = Color.Blue
                Me.lblGetCodeResult.Text = "电子券密码验证成功！"
                Me.btnOK.Enabled = True
            Else
                Me.lblGetCodeResult.ForeColor = Color.Red
                Me.lblGetCodeResult.Text = "电子券密码验证失败！" & cir.CodeMsg.Msg
                Me.btnOK.Enabled = False
            End If

            frmMain.statusText.Text = "就绪"
            IWebService.Dispose() : IWebService = Nothing
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show("因为系统故障，无法进行验证操作！ 下面是系统的内部错误提示：    " & Chr(13) & Chr(13) & ex.Message & Space(4), "出现系统故障！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "因为CUL系统故障，无法进行验证操作！"
            If IWebService IsNot Nothing Then IWebService.Dispose() : IWebService = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub InitForm()
        Me.txtCodeAmount.Text = ""
        Me.txtValidDate.Text = ""
        Me.txtCodeType.Text = ""
    End Sub

    Private Function GetSalesBillID() As String
        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法查询电子券订单信息。"
            Return ""
        End If
        Try
            Dim dtSalesBillID As DataTable = Nothing
            dtSalesBillID = DB.GetDataTable("select SalesBillID from InternetSales_RuiTai where CodePassword = '" & Me.txtCodePassword.Text.Trim & "'")
            If dtSalesBillID Is Nothing OrElse dtSalesBillID.Rows.Count = 0 Then
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

    Private Sub frmInternetSales_ForRuiTai_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'modify code 040:start-------------------------------------------------------------------------
        Me.txtCodePassword.Text = ""
        'modify code 040:end-------------------------------------------------------------------------
        InitForm()
        Me.lblGetCodeResult.Text = ""
        Me.btnOK.Enabled = False

        Me.txtCodePassword.Select()
    End Sub
End Class