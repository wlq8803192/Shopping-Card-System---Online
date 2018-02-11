Public Class frmTransfer

    Private Sub btnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        statusText.Text = "提示信息：正在发出请求，请稍等......"
        statusMain.Refresh()
        If txbFromCard.Text.Trim.Length <> 19 Then
            statusText.Text = "错误信息：请输入转出卡号,卡号的长度必须是19位!"
            Return
        End If
        If txbToCard.Text.Trim.Length <> 19 Then
            statusText.Text = "错误信息：请输入转入卡号,卡号的长度必须是19位!"
            Return
        End If
        If txbFromCard.Text = txbToCard.Text Then
            statusText.Text = "错误信息：转出卡号和转入卡号不能相同!"
            Return
        End If

        '如果转出卡属于未确认的转账申请，不允许再提出转账申请，这样容易发生错误
        Dim bdb As New DataBase()
        Dim dtTemp As DataTable
        bdb.Open()
        If bdb.IsConnected Then
            dtTemp = bdb.GetDataTable("select * from culspecialoperation where operationtype='转账' and AffirmState=0 and StartCard='" & txbFromCard.Text & "'")
            bdb.Close()
            If dtTemp.Rows.Count > 0 Then
                statusText.Text = "错误提示：转出卡号已经被申请转账，请等待上次的申请被确认后才能再次申请转帐！"
                Return
            End If
        Else
            statusText.Text = "错误提示：连接数据库失败！操作无法进行"
            Return
        End If


        dgvCards.Rows.Clear()

        Dim c4Service As C4ShoppingCardService.C4ShoppingCardService
        c4Service = New C4ShoppingCardService.C4ShoppingCardService
        Dim infoClass As C4ShoppingCardService.InfoClass
        infoClass = New C4ShoppingCardService.InfoClass()
        Dim infoDataClass As C4ShoppingCardService.InfoDataClass


        infoClass.MerchantNo = "102210054110420"
        infoClass.UserID = "test"
        infoClass.CardNoFrom = txbFromCard.Text
        infoClass.CardNoTo = txbFromCard.Text
        infoClass.IsPager = "N"
        infoClass.PageNo = "1"

        infoDataClass = c4Service.info(infoClass)
        Dim i As Integer = 0
        If infoDataClass.CodeMsg.Code = "OZ" Then
            Dim ll_row As Integer
            ll_row = dgvCards.Rows.Add()
            dgvCards.Rows(ll_row).Cells("CardType").Value = "转出卡"
            dgvCards.Rows(ll_row).Cells("CardNo").Value = infoDataClass.Cards(i).CardNo
            dgvCards.Rows(ll_row).Cells("Balance").Value = infoDataClass.Cards(i).Balance
            dgvCards.Rows(ll_row).Cells("ActivedDate").Value = infoDataClass.Cards(i).ActivedDate
            dgvCards.Rows(ll_row).Cells("Status").Value = infoDataClass.Cards(i).Status
            dgvCards.Rows(ll_row).Cells("HotReason").Value = infoDataClass.Cards(i).HotReason
            dgvCards.Rows(ll_row).Cells("ExpiredDate").Value = infoDataClass.Cards(i).ExpiredDate
            dgvCards.Rows(ll_row).Cells("IssuerMerchant").Value = infoDataClass.Cards(i).IssuerMerchant
            dgvCards.Rows(ll_row).Cells("IssuerCreateUser").Value = infoDataClass.Cards(i).IssuerCreateUser
        Else
            statusText.Text = "错误信息：查询失败,请检查您输入的转出卡号.(" + infoDataClass.CodeMsg.Msg + ")"
            Return
        End If


        '转入卡
        infoClass.MerchantNo = "102210054110420"
        infoClass.UserID = "test"
        infoClass.CardNoFrom = txbToCard.Text
        infoClass.CardNoTo = txbToCard.Text
        infoClass.IsPager = "N"
        infoClass.PageNo = "1"

        infoDataClass = c4Service.info(infoClass)

        If infoDataClass.CodeMsg.Code = "OZ" Then
            Dim ll_row As Integer
            ll_row = dgvCards.Rows.Add()
            dgvCards.Rows(ll_row).Cells("CardType").Value = "转入卡"
            dgvCards.Rows(ll_row).Cells("CardNo").Value = infoDataClass.Cards(i).CardNo
            dgvCards.Rows(ll_row).Cells("Balance").Value = infoDataClass.Cards(i).Balance
            dgvCards.Rows(ll_row).Cells("ActivedDate").Value = infoDataClass.Cards(i).ActivedDate
            dgvCards.Rows(ll_row).Cells("Status").Value = infoDataClass.Cards(i).Status
            dgvCards.Rows(ll_row).Cells("HotReason").Value = infoDataClass.Cards(i).HotReason
            dgvCards.Rows(ll_row).Cells("ExpiredDate").Value = infoDataClass.Cards(i).ExpiredDate
            dgvCards.Rows(ll_row).Cells("IssuerMerchant").Value = infoDataClass.Cards(i).IssuerMerchant
            dgvCards.Rows(ll_row).Cells("IssuerCreateUser").Value = infoDataClass.Cards(i).IssuerCreateUser
            statusText.Text = "提示信息：查询成功!"
            btnQuery.Enabled = False
            btnTransfer.Enabled = True
            txbAmount.Enabled = True
        Else
            statusText.Text = "错误信息：查询失败,请检查您输入的转入卡号.(" + infoDataClass.CodeMsg.Msg + ")"
        End If

    End Sub
    Private Sub AfterTransfer()

        Dim c4Service As C4ShoppingCardService.C4ShoppingCardService
        c4Service = New C4ShoppingCardService.C4ShoppingCardService
        Dim infoClass As C4ShoppingCardService.InfoClass
        infoClass = New C4ShoppingCardService.InfoClass()
        Dim infoDataClass As C4ShoppingCardService.InfoDataClass


        infoClass.MerchantNo = "102210054110420"
        infoClass.UserID = "test"
        infoClass.CardNoFrom = txbFromCard.Text
        infoClass.CardNoTo = txbFromCard.Text
        infoClass.IsPager = "N"
        infoClass.PageNo = "1"

        infoDataClass = c4Service.info(infoClass)
        Dim i As Integer = 0
        If infoDataClass.CodeMsg.Code = "OZ" Then
            Dim ll_row As Integer
            ll_row = dgvCards.Rows.Add()
            dgvCards.Rows(ll_row).Cells("CardType").Value = "转出卡"
            dgvCards.Rows(ll_row).Cells("CardNo").Value = infoDataClass.Cards(i).CardNo
            dgvCards.Rows(ll_row).Cells("Balance").Value = infoDataClass.Cards(i).Balance
            dgvCards.Rows(ll_row).Cells("ActivedDate").Value = infoDataClass.Cards(i).ActivedDate
            dgvCards.Rows(ll_row).Cells("Status").Value = infoDataClass.Cards(i).Status
            dgvCards.Rows(ll_row).Cells("HotReason").Value = infoDataClass.Cards(i).HotReason
            dgvCards.Rows(ll_row).Cells("ExpiredDate").Value = infoDataClass.Cards(i).ExpiredDate
            dgvCards.Rows(ll_row).Cells("IssuerMerchant").Value = infoDataClass.Cards(i).IssuerMerchant
            dgvCards.Rows(ll_row).Cells("IssuerCreateUser").Value = infoDataClass.Cards(i).IssuerCreateUser
        Else
            statusText.Text = "错误信息：查询失败,请检查您输入的转出卡号.(" + infoDataClass.CodeMsg.Msg + ")"
            Return
        End If


        '转入卡
        infoClass.MerchantNo = "102210054110420"
        infoClass.UserID = "test"
        infoClass.CardNoFrom = txbToCard.Text
        infoClass.CardNoTo = txbToCard.Text
        infoClass.IsPager = "N"
        infoClass.PageNo = "1"

        infoDataClass = c4Service.info(infoClass)

        If infoDataClass.CodeMsg.Code = "OZ" Then
            Dim ll_row As Integer
            ll_row = dgvCards.Rows.Add()
            dgvCards.Rows(ll_row).Cells("CardType").Value = "转入卡"
            dgvCards.Rows(ll_row).Cells("CardNo").Value = infoDataClass.Cards(i).CardNo
            dgvCards.Rows(ll_row).Cells("Balance").Value = infoDataClass.Cards(i).Balance
            dgvCards.Rows(ll_row).Cells("ActivedDate").Value = infoDataClass.Cards(i).ActivedDate
            dgvCards.Rows(ll_row).Cells("Status").Value = infoDataClass.Cards(i).Status
            dgvCards.Rows(ll_row).Cells("HotReason").Value = infoDataClass.Cards(i).HotReason
            dgvCards.Rows(ll_row).Cells("ExpiredDate").Value = infoDataClass.Cards(i).ExpiredDate
            dgvCards.Rows(ll_row).Cells("IssuerMerchant").Value = infoDataClass.Cards(i).IssuerMerchant
            dgvCards.Rows(ll_row).Cells("IssuerCreateUser").Value = infoDataClass.Cards(i).IssuerCreateUser
            statusText.Text = "查询成功!"
            btnQuery.Enabled = False
            btnTransfer.Enabled = True
            txbAmount.Enabled = True
        Else
            statusText.Text = "错误信息：查询失败,请检查您输入的转入卡号.(" + infoDataClass.CodeMsg.Msg + ")"
        End If

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub frmTransfer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txbFromCard.Text = ""
        txbToCard.Text = ""
        dgvCards.Rows.Clear()
        dgvRequest.DataSource = Nothing
        txbAmount.Text = ""
        txbAmount.Enabled = False


        btnQuery.Enabled = True
        btnTransfer.Enabled = False

        statusText.Text = ""

    End Sub
    Private Sub WriteData(ByVal pFromCard As String, ByVal pToCard As String, ByVal pAmount As Decimal, ByVal pResult As String, ByVal pRemark As String)
        Dim sSQL As String
        Dim bdb As New DataBase()
        bdb.Open()
        If bdb.IsConnected Then
            sSQL = "insert into CULspecialOperation(OperationType,StartCard,EndCard,RequestAMT,ResultDescription,RequestID,RequestedTime,RequestedInFront,AffirmState,Remark) "
            sSQL += " values('转账','" & pFromCard + "','" & pToCard & "'," & pAmount & ",'" & pResult & "','888',getdate(),1,0,'" & pRemark & "') "
            bdb.ModifyTable(sSQL)
        Else
            MsgBox("连接数据库失败！")
        End If
        bdb.Close()
    End Sub


    Private Sub btnTransfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransfer.Click
        statusText.Text = "提示信息：正在发出请求，请稍等......"
        statusMain.Refresh()
        If txbFromCard.Text.Trim.Length <> 19 Then
            statusText.Text = "错误信息：请输入转出卡号,卡号的长度必须是19位!"
            Return
        End If
        If txbToCard.Text.Trim.Length <> 19 Then
            statusText.Text = "错误信息：请输入转入卡号,卡号的长度必须是19位!"
            Return
        End If

        If txbFromCard.Text = txbToCard.Text Then
            statusText.Text = "错误信息：转出卡号和转入卡号不能相同!"
            Return
        End If

        If txbAmount.Text.Trim.Length = 0 Then
            statusText.Text = "错误信息：请输入正确的扣款金额!"
            Return
        End If

        Dim TransferAmount As Decimal
        TransferAmount = CDec(txbAmount.Text)
        If TransferAmount <= 0 Then
            statusText.Text = "错误信息：请输入正确的扣款金额!"
            Return
        End If

        If (Math.Round(TransferAmount, 2) - TransferAmount) <> 0 Then
            statusText.Text = "错误信息：扣款金额只能输入到分，不可以超过2位小数!"
            Return
        End If

        Dim b1 As Boolean = (dgvCards.Rows(0).Cells("Status").Value.ToString = "激活")
        Dim b2 As Boolean = (dgvCards.Rows(1).Cells("Status").Value.ToString = "激活")
        Dim b3 As Boolean = (dgvCards.Rows(0).Cells("HotReason").Value.ToString = "无")
        Dim b4 As Boolean = (dgvCards.Rows(1).Cells("HotReason").Value.ToString = "无")


        If Not (b1 And b2 And b3 And b4) Then
            statusText.Text = "错误提示：两张卡必须都处于激活状态并且无暂停原因才可以转账！"
            Return
        End If

        If dgvCards.Rows(0).Cells("Balance").Value < TransferAmount Then
            statusText.Text = "错误提示：转账金额大于转出卡余额，无法转账！"
            Return
        End If
        'WriteData(txbFromCard.Text, txbToCard.Text, TransferAmount, "", NumUtil.GetGridText(dgvCards))

        statusText.Text = "提示信息：转账申请成功，请等待确认！"
        btnTransfer.Enabled = False
        txbAmount.Enabled = False


    End Sub

    Private Sub txbFromCard_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txbFromCard.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub txbToCard_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txbToCard.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub txbAmount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txbAmount.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Or e.KeyChar = "." Then
            If e.KeyChar = "." And InStr(txbAmount.Text, ".") > 0 Then
                e.Handled = True
            Else
                e.Handled = False
            End If
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub btnQueryHis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQueryHis.Click
        '还需要考虑权限的控制，当前用户可以查询那些人的转账申请
        statusText.Text = "提示信息：正在查询，请稍等......"
        statusMain.Refresh()

        Dim bdb As New DataBase()
        Dim dtRequest As DataTable
        bdb.Open()
        If bdb.IsConnected Then
            dtRequest = bdb.GetDataTable("select * from culspecialoperation where operationtype='转账' and AffirmState=0 ")
            dgvRequest.AutoGenerateColumns = False
            dgvRequest.DataSource = dtRequest

        Else
            MsgBox("连接数据库失败！")
        End If
        bdb.Close()

        statusText.Text = "提示信息：查询完成！"
        statusMain.Refresh()

    End Sub
End Class