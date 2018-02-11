
'modify code 044:
'date;2015/1/9
'auther:Hyron bjy 
'remark: 增加线下提卡销售单支付方式--瑞泰

'modify code 044:start-------------------------------------------------------------------------
Public Class frmSelectBuyChannel

    Public sCityID As String, sStoreID As String
    Private boolCul As Boolean = False, boolRuiTai As Boolean = False, dtCityBillBuyChannel As DataTable = Nothing

    Private Sub frmSelectBuyChannel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '检查必要条件
        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法创建线下提卡销售单。请检查数据库连接。"
            Return
        End If
        Try
            '城市支付方式
            With frmSelling
                .GetPaymentTermByCityID(sCityID, "8,11")
                If .dtCityPaymentTerm.Select("PaymentTerm=8").Length > 0 Then boolCul = True
                If .dtCityPaymentTerm.Select("PaymentTerm=11").Length > 0 Then boolRuiTai = True
            End With
            '购买渠道和购买渠道接口
            dtCityBillBuyChannel = DB.GetDataTable("Select * From City_BillBuyChannel Where CityID=" & sCityID).Copy
            If dtCityBillBuyChannel Is Nothing OrElse dtCityBillBuyChannel.Rows.Count = 0 Then
                MessageBox.Show("当前城市没有设置城市支持的购买渠道，不能创建线下提卡销售单！    " & Chr(13) & Chr(13) & "请找系统管理员设置购买渠道。    ", "未发现购买渠道！", MessageBoxButtons.OK)
                DB.Close()
                Return
            End If
            If boolCul = True Then
                If dtCityBillBuyChannel.Select("BillBuyChannel='ALIPAY' or BillBuyChannel='WECHAT'").Length = 0 Then
                    boolCul = False
                End If
            End If
            If boolRuiTai = True Then
                If dtCityBillBuyChannel.Select("BillBuyChannel='RUITAI'").Length = 0 Then
                    boolRuiTai = False
                End If
            End If
            If boolCul = False And boolRuiTai = False Then
                MessageBox.Show("当前城市没有设置购买渠道，不能创建线下提卡销售单！    " & Chr(13) & Chr(13) & "请找系统管理员设置购买渠道。    ", "未发现购买渠道！", MessageBoxButtons.OK)
                DB.Close()
                Return
            End If
        Catch ex As Exception
            DB.Close()
            Return
        End Try
        Me.cboBuyChannel.Items.Clear()
        If boolCul Then Me.cboBuyChannel.Items.Add("支付宝/微信")
        If boolRuiTai Then Me.cboBuyChannel.Items.Add("瑞泰")
        Me.cboBuyChannel.SelectedIndex = 0
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Dim sFormName As String = ""

        If Me.cboBuyChannel.SelectedIndex = 0 Then      '支付宝/微信
            sFormName = "frmInternetSales_ForCul"
            OpenCul()
        ElseIf Me.cboBuyChannel.SelectedIndex = 1 Then  '瑞泰
            If frmMain.sShopId = "" Then
                MessageBox.Show("当前门店不能创建瑞泰线下提卡销售单，需要配置门店参数！", "不能创建销售单！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                sFormName = "frmInternetSales_ForRuiTai"
                OpenRuiTai()
            End If
        End If

    End Sub

    Private Sub OpenCul()
        With frmInternetSales_ForCul
            .sCityID = sCityID
            .sStoreID = sStoreID
            Dim dv As DataView = New DataView
            dv.Table = dtCityBillBuyChannel
            dv.RowFilter = "BillBuyChannel='ALIPAY' or BillBuyChannel='WECHAT'"
            .dtCityBillBuyChannel = dv.ToTable
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                If .sSalesBillID = "" Then  '提取码还未使用
                    If frmSelling.IsHandleCreated Then
                        frmSelling.Activate()
                        frmSelling.WindowState = FormWindowState.Maximized
                        If frmSelling.blIsChanged Then
                            Dim bAnswer As DialogResult = MessageBox.Show("是否在新建销售单之前，先保存当前销售单？    ", "当前销售单未保存！", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                            If bAnswer = Windows.Forms.DialogResult.Cancel OrElse (bAnswer = Windows.Forms.DialogResult.Yes AndAlso Not frmSelling.SaveChanges()) Then
                                Me.Activate()
                                frmMain.statusText.Text = "因为存在未保存销售单，所以不能新建销售单。"
                                Return
                            End If
                        End If

                        frmSelling.cbbSalesBillType.Items(0) = "线下提卡销售单"
                        frmSelling.sCustomerID = ""
                        frmSelling.bNewSalesBillType = 6
                        frmSelling.blUsedOldCard = False
                        frmSelling.ecir = .ecir
                        frmSelling.sIssuerId = .sIssuerId
                        frmSelling.strSelectedBuyChannel = "Cul"
                        frmSelling.ReCreateSalesBill()
                    Else
                        Me.Cursor = Cursors.WaitCursor
                        frmMain.statusText.Text = "正在打开销售单窗口……"
                        frmMain.statusMain.Refresh()

                        frmSelling.cbbSalesBillType.Items(0) = "线下提卡销售单"
                        frmSelling.bNewSalesBillType = 6
                        frmSelling.blUsedOldCard = False
                        frmSelling.ecir = .ecir
                        frmSelling.sIssuerId = .sIssuerId
                        frmSelling.strSelectedBuyChannel = "Cul"
                        frmSelling.Show()
                        If frmSelling.IsHandleCreated Then
                            frmSelling.MdiParent = frmMain
                            frmSelling.WindowState = FormWindowState.Maximized
                            frmSelling.Activate()
                        End If

                        If frmMain.statusText.Text.IndexOf("……") > -1 Then frmMain.statusText.Text = "就绪。"
                        Me.Cursor = Cursors.Default
                    End If

                    If frmSelling.IsHandleCreated Then
                        If frmSelling.dgvNormalCard.CurrentRow IsNot Nothing Then frmSelling.dgvNormalCard.CurrentRow.Selected = False
                        If frmSelling.dgvRebateCard.CurrentRow IsNot Nothing Then frmSelling.dgvRebateCard.CurrentRow.Selected = False
                        If frmSelling.dgvPayment.CurrentRow IsNot Nothing Then frmSelling.dgvPayment.CurrentRow.Selected = False
                    End If
                Else
                    If frmSelling.IsHandleCreated Then
                        frmSelling.Activate()
                        frmSelling.WindowState = FormWindowState.Maximized
                        If frmSelling.sSalesBillID <> .sSalesBillID Then
                            If frmSelling.blIsChanged Then
                                Dim bAnswer As DialogResult = MessageBox.Show("是否在打开销售单之前，先保存当前销售单？    ", "当前销售单未保存！", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                                If bAnswer = Windows.Forms.DialogResult.Cancel OrElse (bAnswer = Windows.Forms.DialogResult.Yes AndAlso Not frmSelling.SaveChanges()) Then
                                    Me.Activate()
                                    frmMain.statusText.Text = "因为存在未保存销售单，所以不能打开销售单。"
                                    Return
                                End If
                            End If
                            frmSelling.sSalesBillID = .sSalesBillID
                            frmSelling.strSelectedBuyChannel = "Cul"
                            frmSelling.bNewSalesBillType = 6
                            frmSelling.LoadSalesBill()
                        End If
                    Else
                        Me.Cursor = Cursors.WaitCursor
                        frmMain.statusText.Text = "正在打开销售单……"
                        frmMain.statusMain.Refresh()

                        frmSelling.Text = "查看销售单"
                        frmSelling.sSalesBillID = .sSalesBillID
                        frmSelling.strSelectedBuyChannel = "Cul"
                        frmSelling.bNewSalesBillType = 6
                        frmSelling.Show()
                        If frmSelling.IsHandleCreated Then
                            frmSelling.MdiParent = frmMain
                            frmSelling.WindowState = FormWindowState.Maximized
                            frmSelling.Activate()
                            frmSelling.btnModifyPaymentInfo.Visible = False
                        End If

                        If frmMain.statusText.Text.IndexOf("……") > -1 Then frmMain.statusText.Text = "就绪。"
                        Me.Cursor = Cursors.Default
                    End If

                    If frmSelling.IsHandleCreated Then
                        If frmSelling.dgvNormalCard.CurrentRow IsNot Nothing Then frmSelling.dgvNormalCard.CurrentRow.Selected = False
                        If frmSelling.dgvRebateCard.CurrentRow IsNot Nothing Then frmSelling.dgvRebateCard.CurrentRow.Selected = False
                        If frmSelling.dgvPayment.CurrentRow IsNot Nothing Then frmSelling.dgvPayment.CurrentRow.Selected = False
                    End If
                End If

            End If
            .Dispose()
        End With
    End Sub

    Private Sub OpenRuiTai()
        With frmInternetSales_ForRuiTai
            .sCityID = sCityID
            .sStoreID = sStoreID
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                If .sSalesBillID = "" Then  '电子券没有生成销售单
                    If frmSelling.IsHandleCreated Then
                        frmSelling.Activate()
                        frmSelling.WindowState = FormWindowState.Maximized
                        If frmSelling.blIsChanged Then
                            Dim bAnswer As DialogResult = MessageBox.Show("是否在新建销售单之前，先保存当前销售单？    ", "当前销售单未保存！", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                            If bAnswer = Windows.Forms.DialogResult.Cancel OrElse (bAnswer = Windows.Forms.DialogResult.Yes AndAlso Not frmSelling.SaveChanges()) Then
                                Me.Activate()
                                frmMain.statusText.Text = "因为存在未保存销售单，所以不能新建销售单。"
                                Return
                            End If
                        End If

                        frmSelling.cbbSalesBillType.Items(0) = "线下提卡销售单"
                        frmSelling.sCustomerID = ""
                        frmSelling.bNewSalesBillType = 6
                        frmSelling.blUsedOldCard = False
                        frmSelling.cir = .cir
                        frmSelling.strSelectedBuyChannel = "RuiTai"
                        frmSelling.strSerialNo = .ci.SerialNo
                        frmSelling.ReCreateSalesBill()
                    Else
                        Me.Cursor = Cursors.WaitCursor
                        frmMain.statusText.Text = "正在打开销售单窗口……"
                        frmMain.statusMain.Refresh()

                        frmSelling.cbbSalesBillType.Items(0) = "线下提卡销售单"
                        frmSelling.bNewSalesBillType = 6
                        frmSelling.blUsedOldCard = False
                        frmSelling.cir = .cir
                        frmSelling.strSelectedBuyChannel = "RuiTai"
                        frmSelling.strSerialNo = .ci.SerialNo
                        frmSelling.Show()
                        If frmSelling.IsHandleCreated Then
                            frmSelling.MdiParent = frmMain
                            frmSelling.WindowState = FormWindowState.Maximized
                            frmSelling.Activate()
                        End If

                        If frmMain.statusText.Text.IndexOf("……") > -1 Then frmMain.statusText.Text = "就绪。"
                        Me.Cursor = Cursors.Default
                    End If

                    If frmSelling.IsHandleCreated Then
                        If frmSelling.dgvNormalCard.CurrentRow IsNot Nothing Then frmSelling.dgvNormalCard.CurrentRow.Selected = False
                        If frmSelling.dgvRebateCard.CurrentRow IsNot Nothing Then frmSelling.dgvRebateCard.CurrentRow.Selected = False
                        If frmSelling.dgvPayment.CurrentRow IsNot Nothing Then frmSelling.dgvPayment.CurrentRow.Selected = False
                        .Dispose()
                    End If
                Else
                    If frmSelling.IsHandleCreated Then
                        frmSelling.Activate()
                        frmSelling.WindowState = FormWindowState.Maximized
                        If frmSelling.sSalesBillID <> .sSalesBillID Then
                            If frmSelling.blIsChanged Then
                                Dim bAnswer As DialogResult = MessageBox.Show("是否在打开销售单之前，先保存当前销售单？    ", "当前销售单未保存！", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                                If bAnswer = Windows.Forms.DialogResult.Cancel OrElse (bAnswer = Windows.Forms.DialogResult.Yes AndAlso Not frmSelling.SaveChanges()) Then
                                    Me.Activate()
                                    frmMain.statusText.Text = "因为存在未保存销售单，所以不能打开销售单。"
                                    Return
                                End If
                            End If
                            frmSelling.sSalesBillID = .sSalesBillID
                            frmSelling.strSelectedBuyChannel = "RuiTai"
                            frmSelling.bNewSalesBillType = 6
                            frmSelling.LoadSalesBill()
                        End If
                    Else
                        Me.Cursor = Cursors.WaitCursor
                        frmMain.statusText.Text = "正在打开销售单……"
                        frmMain.statusMain.Refresh()

                        frmSelling.Text = "查看销售单"
                        frmSelling.sSalesBillID = .sSalesBillID
                        frmSelling.strSelectedBuyChannel = "RuiTai"
                        frmSelling.bNewSalesBillType = 6
                        frmSelling.Show()
                        If frmSelling.IsHandleCreated Then
                            frmSelling.MdiParent = frmMain
                            frmSelling.WindowState = FormWindowState.Maximized
                            frmSelling.Activate()
                            frmSelling.btnModifyPaymentInfo.Visible = False
                        End If

                        If frmMain.statusText.Text.IndexOf("……") > -1 Then frmMain.statusText.Text = "就绪。"
                        Me.Cursor = Cursors.Default
                    End If

                    If frmSelling.IsHandleCreated Then
                        If frmSelling.dgvNormalCard.CurrentRow IsNot Nothing Then frmSelling.dgvNormalCard.CurrentRow.Selected = False
                        If frmSelling.dgvRebateCard.CurrentRow IsNot Nothing Then frmSelling.dgvRebateCard.CurrentRow.Selected = False
                        If frmSelling.dgvPayment.CurrentRow IsNot Nothing Then frmSelling.dgvPayment.CurrentRow.Selected = False
                        .Dispose()
                    End If
                End If
            End If
        End With
    End Sub

    Public Sub GetBillBuyChannelByCityID(ByVal parmCityID As String)
        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法创建线下提卡销售单。请检查数据库连接。"
            Me.Close() : Return
        End If

        Try
            dtCityBillBuyChannel = DB.GetDataTable("Select * From City_BillBuyChannel Where CityID=" & parmCityID).Copy
            DB.Close()
        Catch ex As Exception
            DB.Close()
        End Try
    End Sub

End Class
'modify code 044:end-------------------------------------------------------------------------