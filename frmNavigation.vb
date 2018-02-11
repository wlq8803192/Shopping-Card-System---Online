Public Class frmNavigation

    'modify code 023:
    'date;2014/5/22
    'auther:Hyron bjy 
    'remark:新增界面，特殊操作，卡号段查询

    'modify code 040:
    'date;2014/11/5
    'auther:Hyron bjy 
    'remark:新增销售单类型---线下提卡销售单

    'modify code 050:
    'date;2015/10/26
    'auther:Hyron qm 
    'remark:增加实名制卡CardBin，实名制卡非实名制卡售卖分开，修改实名制卡特殊操作

    'modify code 054:
    'date;2016/02/15
    'auther:BJY 
    'remark:增加65卡销售单，65/61使用新返点规则，去除051的一般销售单售卖65卡功能

    'modify code 072:
    'date;2017/05/10
    'auther:Qipeng
    'remark:增加电子卡团购功能

    'modify code 082:
    'date;2017/10/10
    'auther:Qipeng
    'remark:增加退卡,提取码作废和电子卡延期放到新的菜单(电子卡特殊操作)中

    Private Sub frmNavigation_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If frmMain.MdiChildren.Length > 1 AndAlso frmMain.ActiveMdiChild.Equals(Me) Then
            Try
                For Each theForm As Form In frmMain.MdiChildren
                    If Not theForm.Disposing AndAlso Not theForm.Equals(Me) Then theForm.Activate() : Exit For
                Next
            Finally
            End Try
        End If
    End Sub

    Private Sub frmNavigation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.MdiParent = frmMain

        If My.Settings.IsInTraining = False Then
            Me.pnlNavigation.BackColor = SystemColors.Window
            Me.pnlMain.BackColor = SystemColors.Window
            Me.pnlMain.BorderStyle = BorderStyle.None
            Me.picMode.Image = My.Resources.CarrefourLogo
            Me.picMode.Location = New Point(581, 333)
        End If

        Me.pnlPositionOut.Visible = frmMain.menuPosition.Enabled
        Me.pnlLocationOut.Visible = frmMain.menuArea.Enabled
        Me.pnlUserOut.Visible = frmMain.menuUserManagement.Enabled
        Me.pnlEmployeeQuotaOut.Visible = frmMain.menuEmployeeQuota.Enabled
        Me.pnlBusinessTypeOut.Visible = frmMain.menuBusinessType.Enabled
        Me.pnlInvoiceItemOut.Visible = frmMain.menuInvoiceItem.Enabled
        Me.pnlInvoiceLayoutOut.Visible = frmMain.menuInvoiceLayout.Enabled
        Me.pnlCityRuleOut.Visible = frmMain.menuCityConfig.Enabled
        'modify code 054:start-------------------------------------------------------------------------
        Me.pnlCrossSellingCityDiscountRule.Visible = frmMain.menuCrossSellingCityConfig.Enabled
        Me.pnlCrossSellingCityDiscountRule.Visible = frmMain.menuCrossSellingCityConfig.Enabled
        'modify code 054:end-------------------------------------------------------------------------
        Me.pnlBonusCalculationOut.Visible = frmMain.menuBonusCalculation.Enabled
        Me.pnlCustomerOut.Visible = (frmMain.menuCustomerManagement.Enabled OrElse frmMain.dtAllowedRight.Select("RightName='CustomerCreate'").Length > 0)
        Me.pnlContractOut.Visible = (frmMain.menuContractManagement.Enabled OrElse frmMain.dtAllowedRight.Select("RightName='ContractCreate'").Length > 0)

        'modify code 067:start-------------------------------------------------------------------------
        Me.pnlCrossContractOut.Visible = (frmMain.menuCrossContractManagement.Enabled OrElse frmMain.dtAllowedRight.Select("RightName='CrossContractCreate'").Length > 0)
        'modify code 067:end-------------------------------------------------------------------------

        'modify code 072:start-------------------------------------------------------------------------
        Me.pnlElectronicCardOut.Visible = (frmMain.menuElectronicCard.Enabled OrElse frmMain.dtAllowedRight.Select("RightName='ElectronicCard'").Length > 0)
        'modify code 072:end-------------------------------------------------------------------------

        'modify code 082:start-------------------------------------------------------------------------
        Me.pnlElcSpecialOperationOut.Visible = (frmMain.menuElcSpecialOperation.Enabled OrElse frmMain.dtAllowedRight.Select("RightName='ElectronicSpecialOperation'").Length > 0)
        'modify code 082:end-------------------------------------------------------------------------

        Me.pnlSellingOut.Visible = (frmMain.menuSalesBillManagement.Enabled OrElse frmMain.dtAllowedRight.Select("RightName='SalesBillNormalCreate'").Length > 0)
        'modify code 046:start-------------------------------------------------------------------------
        Me.pnlSignCardSellingOut.Visible = frmMain.menuSignCardSelling.Enabled
        'modify code 050:start-------------------------------------------------------------------------
        'Me.pnlSignCardCulOut.Visible = frmMain.menuSignCardSpecialOperation.Enabled
        Me.pnlSignCardCulOut.Visible = frmMain.menuSignCardSpecialOperationHead.Enabled
        'modify code 050:end-------------------------------------------------------------------------
        'modify code 046:end-------------------------------------------------------------------------
        'modify code 040:start-------------------------------------------------------------------------
        Me.pnlInternetSalesOut.Visible = frmMain.menuInternetSelling.Enabled
        Me.pnlInternetSalesInvoiceOut.Visible = frmMain.menuInternetSalesInvoice.Enabled
        'modify code 040:end-------------------------------------------------------------------------
        Me.pnlPreDefineFaceValueOut.Visible = frmMain.menuPredefineFaceValue.Enabled
        Me.pnlBatchChargeOut.Visible = frmMain.menuCreateSalesBillFromFile.Enabled
        Me.pnlReturnGoodsOut.Visible = frmMain.menuCreateReturnedSalesBill.Enabled
        Me.pnlMarketingPromotionOut.Visible = frmMain.menuMarketingPromotion.Enabled
        Me.pnlPRCardOut.Visible = frmMain.menuPRCard.Enabled
        Me.pnlEmployeeSalesOut.Visible = frmMain.menuEmployeeSales.Enabled
        Me.pnlCobrandCardOut.Visible = frmMain.menuCobrandCard.Enabled
        Me.pnlCULOut.Visible = (frmMain.dtAllowedRight.Select("RightName In ('FreezeCard','UrgencyDeduct','ChangeCard','AffirmChangeCard','GiftCardActivationCancel','GiftCardOfflineActivate','UnchargeCard','AffirmUnchargeCard','RecycleCard','AffirmRecycleCard','CardExchangeQuery')").Length > 0)
        Me.pnlCashActivationOut.Visible = frmMain.menuCashActivation.Enabled
        Me.pnlEmployeeActivationOut.Visible = frmMain.menuEmployeeActivation.Enabled
        Me.pnlChequeActivationOut.Visible = frmMain.menuChequeActivation.Enabled
        Me.pnlSalesReportingOut.Visible = frmMain.menuSalesReport.Enabled
        Me.pnlJVReportingOut.Visible = frmMain.menuJVReport.Enabled
        Me.pnlBonusReportingOut.Visible = frmMain.menuBonusReporting.Enabled
        Me.pnlCustomExportOut.Visible = frmMain.menuCustomExport.Enabled
        Me.pnlCULReportingOut.Visible = frmMain.menuCULReport.Enabled
        'modify code 054:start-------------------------------------------------------------------------
        Me.pnlCrossSelling.Visible = frmMain.menuCrossSellingNonRealNameCard.Enabled
        Me.pnlCrossSellingOut.Visible = frmMain.menuCrossSellingNonRealNameCard.Enabled
        'modify code 054:end-------------------------------------------------------------------------
    End Sub

    Private Sub frmNavigation_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged
        If Me.MdiParent Is Nothing Then Return
        If Me.WindowState <> FormWindowState.Normal Then Me.WindowState = FormWindowState.Normal : Return

        Dim iLeft As Integer = (frmMain.ClientSize.Width - Me.Width) / 2 - 4
        Dim iTop As Integer = (frmMain.ClientSize.Height - Me.Height) / 2 - 20
        If iLeft < 0 Then iLeft = 0
        If iTop < 0 Then iTop = 0
        Me.Location = New Point(iLeft, iTop)
    End Sub

    Private Sub pnlPosition_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlPosition.Click
        frmMain.menuPosition.PerformClick()
        Me.pnlPosition.BackgroundImage = My.Resources.Position
    End Sub

    Private Sub pnlPosition_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlPosition.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlPosition.BackgroundImage = My.Resources.PositionSelected
    End Sub

    Private Sub pnlPosition_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlPosition.MouseEnter
        Me.pnlPosition.BackgroundImage = My.Resources.PositionHover
    End Sub

    Private Sub pnlPosition_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlPosition.MouseLeave
        Me.pnlPosition.BackgroundImage = My.Resources.Position
    End Sub

    Private Sub pnlLocation_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlLocation.Click
        frmMain.menuArea.PerformClick()
        Me.pnlLocation.BackgroundImage = My.Resources.Location
    End Sub

    Private Sub pnlLocation_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlLocation.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlLocation.BackgroundImage = My.Resources.LocationSelected
    End Sub

    Private Sub pnlLocation_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlLocation.MouseEnter
        Me.pnlLocation.BackgroundImage = My.Resources.LocationHover
    End Sub

    Private Sub pnlLocation_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlLocation.MouseLeave
        Me.pnlLocation.BackgroundImage = My.Resources.Location
    End Sub

    Private Sub pnlUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlUser.Click
        frmMain.menuUserManagement.PerformClick()
        Me.pnlUser.BackgroundImage = My.Resources.UserManagement
    End Sub

    Private Sub pnlUser_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlUser.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlUser.BackgroundImage = My.Resources.UserManagementSelected
    End Sub

    Private Sub pnlUser_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlUser.MouseEnter
        Me.pnlUser.BackgroundImage = My.Resources.UserManagemeHover
    End Sub

    Private Sub pnlUser_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlUser.MouseLeave
        Me.pnlUser.BackgroundImage = My.Resources.UserManagement
    End Sub

    Private Sub pnlEmployeeQuota_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlEmployeeQuota.Click
        frmMain.menuEmployeeQuota.PerformClick()
        Me.pnlEmployeeQuota.BackgroundImage = My.Resources.EmployeeQuota
    End Sub

    Private Sub pnlEmployeeQuota_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlEmployeeQuota.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlEmployeeQuota.BackgroundImage = My.Resources.EmployeeQuotaSelected
    End Sub

    Private Sub pnlEmployeeQuota_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlEmployeeQuota.MouseEnter
        Me.pnlEmployeeQuota.BackgroundImage = My.Resources.EmployeeQuotaHover
    End Sub

    Private Sub pnlEmployeeQuota_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlEmployeeQuota.MouseLeave
        Me.pnlEmployeeQuota.BackgroundImage = My.Resources.EmployeeQuota
    End Sub

    Private Sub pnlBusinessType_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlBusinessType.Click
        frmMain.menuBusinessType.PerformClick()
        Me.pnlBusinessType.BackgroundImage = My.Resources.BusinessType
    End Sub

    Private Sub pnlBusinessType_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlBusinessType.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlBusinessType.BackgroundImage = My.Resources.BusinessTypeSelected
    End Sub

    Private Sub pnlBusinessType_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlBusinessType.MouseEnter
        Me.pnlBusinessType.BackgroundImage = My.Resources.BusinessTypeHover
    End Sub

    Private Sub pnlBusinessType_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlBusinessType.MouseLeave
        Me.pnlBusinessType.BackgroundImage = My.Resources.BusinessType
    End Sub

    Private Sub pnlInvoiceItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlInvoiceItem.Click
        frmMain.menuInvoiceItem.PerformClick()
        Me.pnlInvoiceItem.BackgroundImage = My.Resources.InvoiceItem
    End Sub

    Private Sub pnlInvoiceItem_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlInvoiceItem.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlInvoiceItem.BackgroundImage = My.Resources.InvoiceItemSelected
    End Sub

    Private Sub pnlInvoiceItem_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlInvoiceItem.MouseEnter
        Me.pnlInvoiceItem.BackgroundImage = My.Resources.InvoiceItemHover
    End Sub

    Private Sub pnlInvoiceItem_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlInvoiceItem.MouseLeave
        Me.pnlInvoiceItem.BackgroundImage = My.Resources.InvoiceItem
    End Sub

    Private Sub pnlInvoiceLayout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlInvoiceLayout.Click
        frmMain.menuInvoiceLayout.PerformClick()
        Me.pnlInvoiceLayout.BackgroundImage = My.Resources.InvoiceLayout
    End Sub

    Private Sub pnlInvoiceLayout_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlInvoiceLayout.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlInvoiceLayout.BackgroundImage = My.Resources.InvoiceLayoutSelected
    End Sub

    Private Sub pnlInvoiceLayout_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlInvoiceLayout.MouseEnter
        Me.pnlInvoiceLayout.BackgroundImage = My.Resources.InvoiceLayoutHover
    End Sub

    Private Sub pnlInvoiceLayout_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlInvoiceLayout.MouseLeave
        Me.pnlInvoiceLayout.BackgroundImage = My.Resources.InvoiceLayout
    End Sub

    Private Sub pnlCityRule_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlCityRule.Click
        frmMain.menuCityConfig.PerformClick()
        Me.pnlCityRule.BackgroundImage = My.Resources.CityDiscountRule
    End Sub

    Private Sub pnlCityRule_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlCityRule.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlCityRule.BackgroundImage = My.Resources.CityDiscountRuleSelected
    End Sub

    Private Sub pnlCityRule_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlCityRule.MouseEnter
        Me.pnlCityRule.BackgroundImage = My.Resources.CityDiscountRuleHover
    End Sub

    Private Sub pnlCityRule_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlCityRule.MouseLeave
        Me.pnlCityRule.BackgroundImage = My.Resources.CityDiscountRule
    End Sub

    Private Sub pnlBonusCalculation_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlBonusCalculation.Click
        frmMain.menuBonusCalculation.PerformClick()
        Me.pnlBonusCalculation.BackgroundImage = My.Resources.Bonus
    End Sub

    Private Sub pnlBonusCalculation_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlBonusCalculation.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlBonusCalculation.BackgroundImage = My.Resources.BonusSelected
    End Sub

    Private Sub pnlBonusCalculation_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlBonusCalculation.MouseEnter
        Me.pnlBonusCalculation.BackgroundImage = My.Resources.BonusHover
    End Sub

    Private Sub pnlBonusCalculation_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlBonusCalculation.MouseLeave
        Me.pnlBonusCalculation.BackgroundImage = My.Resources.Bonus
    End Sub

    Private Sub pnlCustomer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlCustomer.Click
        If frmMain.menuCustomerManagement.Enabled Then
            frmMain.menuCustomerManagement.PerformClick()
            Me.pnlCustomer.BackgroundImage = My.Resources.Customer
        End If
        Me.Refresh()
        'If frmMain.dtAllowedRight.Select("RightName='CustomerCreate'").Length > 0 Then
        '    frmCustomer.ShowDialog()
        '    frmCustomer.Dispose()
        'End If
    End Sub

    Private Sub pnlCustomer_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlCustomer.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlCustomer.BackgroundImage = My.Resources.CustomerSelected
    End Sub

    Private Sub pnlCustomer_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlCustomer.MouseEnter
        Me.pnlCustomer.BackgroundImage = My.Resources.CustomerHover
    End Sub

    Private Sub pnlCustomer_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlCustomer.MouseLeave
        Me.pnlCustomer.BackgroundImage = My.Resources.Customer
    End Sub

    Private Sub pnlContract_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlContract.Click
        If frmMain.menuContractManagement.Enabled Then
            frmMain.menuContractManagement.PerformClick()
            Me.pnlContract.BackgroundImage = My.Resources.ContractManagement
        End If
        Me.Refresh()
        'If frmMain.dtAllowedRight.Select("RightName='ContractCreate'").Length > 0 Then
        '    frmContract.ShowDialog()
        '    frmContract.Dispose()
        'End If
    End Sub

    Private Sub pnlCrossContract_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlCrossContract.Click
        'modify code 067:start-------------------------------------------------------------------------
        If frmMain.menuCrossContractManagement.Enabled Then
            frmMain.menuCrossContractManagement.PerformClick()
            Me.pnlCrossContract.BackgroundImage = My.Resources.CrossContractManagement
        End If
        Me.Refresh()
        'modify code 067:end-------------------------------------------------------------------------
    End Sub

    Private Sub pnlContract_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlContract.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlContract.BackgroundImage = My.Resources.ContractManagementSelected
    End Sub

    Private Sub pnlContract_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlContract.MouseEnter
        Me.pnlContract.BackgroundImage = My.Resources.ContractManagementHover
    End Sub

    Private Sub pnlContract_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlContract.MouseLeave
        Me.pnlContract.BackgroundImage = My.Resources.ContractManagement
    End Sub

    Private Sub pnlCrossContract_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlCrossContract.MouseDown
        'modify code 067:start-------------------------------------------------------------------------
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlCrossContract.BackgroundImage = My.Resources.CrossContractManagementSelected
        'modify code 067:end-------------------------------------------------------------------------
    End Sub

    Private Sub pnlCrossContract_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlCrossContract.MouseEnter
        'modify code 067:start-------------------------------------------------------------------------
        Me.pnlCrossContract.BackgroundImage = My.Resources.CrossContractManagementHover
        'modify code 067:end-------------------------------------------------------------------------
    End Sub

    Private Sub pnlCrossContract_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlCrossContract.MouseLeave
        'modify code 067:start-------------------------------------------------------------------------
        Me.pnlCrossContract.BackgroundImage = My.Resources.CrossContractManagement
        'modify code 067:end-------------------------------------------------------------------------
    End Sub

    Private Sub pnlSelling_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlSelling.Click
        If frmMain.menuSalesBillManagement.Enabled Then
            frmMain.menuSalesBillManagement.PerformClick()
            Me.pnlSelling.BackgroundImage = My.Resources.Selling
        End If
        If frmMain.dtAllowedRight.Select("RightName='SalesBillNormalCreate'").Length > 0 AndAlso frmSelling.IsHandleCreated = False Then
            frmSelling.Show()
            If frmSelling.IsHandleCreated Then
                frmSelling.MdiParent = frmMain
                frmSelling.WindowState = FormWindowState.Maximized
                frmSelling.Activate()
                If frmSelling.dgvNormalCard.CurrentRow IsNot Nothing Then frmSelling.dgvNormalCard.CurrentRow.Selected = False
                If frmSelling.dgvRebateCard.CurrentRow IsNot Nothing Then frmSelling.dgvRebateCard.CurrentRow.Selected = False
                If frmSelling.dgvPayment.CurrentRow IsNot Nothing Then frmSelling.dgvPayment.CurrentRow.Selected = False
            End If
        End If
    End Sub

    Private Sub pnlSelling_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlSelling.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlSelling.BackgroundImage = My.Resources.SellingSelected
    End Sub

    Private Sub pnlSelling_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlSelling.MouseEnter
        Me.pnlSelling.BackgroundImage = My.Resources.SellingHover
    End Sub

    Private Sub pnlSelling_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlSelling.MouseLeave
        Me.pnlSelling.BackgroundImage = My.Resources.Selling
    End Sub

    'modify code 046:start-------------------------------------------------------------------------
    Private Sub pnlSignCardSelling_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlSignCardSelling.Click
        If frmMain.menuSignCardSelling.Enabled Then
            frmMain.menuSignCardSelling.PerformClick()
        End If
        Me.pnlSignCardSelling.BackgroundImage = My.Resources.SignCardSelling
    End Sub

    Private Sub pnlSignCardSelling_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlSignCardSelling.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlSignCardSelling.BackgroundImage = My.Resources.SignCardSellingSelected
    End Sub

    Private Sub pnlSignCardSelling_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlSignCardSelling.MouseEnter
        Me.pnlSignCardSelling.BackgroundImage = My.Resources.SignCardSellingHover
    End Sub

    Private Sub pnlSignCardSelling_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlSignCardSelling.MouseLeave
        Me.pnlSignCardSelling.BackgroundImage = My.Resources.SignCardSelling
    End Sub

    Private Sub pnlSignCardCul_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlSignCardCul.Click
        Me.pnlSignCardCul.BackgroundImage = My.Resources.SignCardSpecialOperation
        Dim sMenu As String = "", bFunctions As Byte = 0
        With frmSignCardSpecialOperationSelect
            If frmMain.menuSignCardSpecialOperation.Enabled Then
                .pnlSignCardSpecialOperation.Visible = True
                sMenu = "menuSignCardSpecialOperation" : bFunctions += 1
            End If
            If frmMain.menuSignCardReplace.Enabled Then
                .pnlSignCardReplace.Visible = True
                sMenu = "menuSignCardReplace" : bFunctions += 1
            End If
        End With

        If bFunctions > 1 Then
            sMenu = ""
            If frmSignCardSpecialOperationSelect.ShowDialog = Windows.Forms.DialogResult.OK Then
                sMenu = frmSignCardSpecialOperationSelect.sMenu
            End If
            frmSignCardSpecialOperationSelect.Dispose()
        End If

        If sMenu <> "" Then frmMain.menuSignCardSpecialOperationHead.DropDownItems(sMenu).PerformClick()
    End Sub

    Private Sub pnlSignCardCul_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlSignCardCul.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlSignCardCul.BackgroundImage = My.Resources.SignCardSpecialOperationSelected
    End Sub

    Private Sub pnlSignCardCul_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlSignCardCul.MouseEnter
        Me.pnlSignCardCul.BackgroundImage = My.Resources.SignCardSpecialOperationHover
    End Sub

    Private Sub pnlSignCardCul_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlSignCardCul.MouseLeave
        Me.pnlSignCardCul.BackgroundImage = My.Resources.SignCardSpecialOperation
    End Sub
    'modify code 046:end-------------------------------------------------------------------------

    Private Sub pnlPredefineFaceValue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlPreDefineFaceValue.Click
        frmMain.menuPredefineFaceValue.PerformClick()
        Me.pnlPreDefineFaceValue.BackgroundImage = My.Resources.PredefineFaceValue
    End Sub

    Private Sub pnlPredefineFaceValue_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlPreDefineFaceValue.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlPreDefineFaceValue.BackgroundImage = My.Resources.PredefineFaceValueSelected
    End Sub

    Private Sub pnlPredefineFaceValue_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlPreDefineFaceValue.MouseEnter
        Me.pnlPreDefineFaceValue.BackgroundImage = My.Resources.PredefineFaceValueHover
    End Sub

    Private Sub pnlPredefineFaceValue_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlPreDefineFaceValue.MouseLeave
        Me.pnlPreDefineFaceValue.BackgroundImage = My.Resources.PredefineFaceValue
    End Sub

    Private Sub pnlBatchCharge_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlBatchCharge.Click
        frmMain.menuCreateSalesBillFromFile.PerformClick()
        Me.pnlBatchCharge.BackgroundImage = My.Resources.BatchCharge
    End Sub

    Private Sub pnlBatchCharge_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlBatchCharge.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlBatchCharge.BackgroundImage = My.Resources.BatchChargeSelected
    End Sub

    Private Sub pnlBatchCharge_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlBatchCharge.MouseEnter
        Me.pnlBatchCharge.BackgroundImage = My.Resources.BatchChargeHover
    End Sub

    Private Sub pnlBatchCharge_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlBatchCharge.MouseLeave
        Me.pnlBatchCharge.BackgroundImage = My.Resources.BatchCharge
    End Sub

    Private Sub pnlReturnGoods_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlReturnGoods.Click
        frmMain.menuCreateReturnedSalesBill.PerformClick()
        Me.pnlReturnGoods.BackgroundImage = My.Resources.ReturnGoods
    End Sub

    Private Sub pnlReturnGoods_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlReturnGoods.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlReturnGoods.BackgroundImage = My.Resources.ReturnGoodsSelected
    End Sub

    Private Sub pnlReturnGoods_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlReturnGoods.MouseEnter
        Me.pnlReturnGoods.BackgroundImage = My.Resources.ReturnGoodsHover
    End Sub

    Private Sub pnlReturnGoods_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlReturnGoods.MouseLeave
        Me.pnlReturnGoods.BackgroundImage = My.Resources.ReturnGoods
    End Sub

    Private Sub pnlMarketingPromotion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlMarketingPromotion.Click
        frmMain.menuMarketingPromotion.PerformClick()
        Me.pnlMarketingPromotion.BackgroundImage = My.Resources.MarketingPromotion
    End Sub

    Private Sub pnlMarketingPromotion_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlMarketingPromotion.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlMarketingPromotion.BackgroundImage = My.Resources.MarketingPromotionSelected
    End Sub

    Private Sub pnlMarketingPromotion_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlMarketingPromotion.MouseEnter
        Me.pnlMarketingPromotion.BackgroundImage = My.Resources.MarketingPromotionHover
    End Sub

    Private Sub pnlMarketingPromotion_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlMarketingPromotion.MouseLeave
        Me.pnlMarketingPromotion.BackgroundImage = My.Resources.MarketingPromotion
    End Sub

    Private Sub pnlPRCard_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlPRCard.Click
        frmMain.menuPRCard.PerformClick()
        Me.pnlPRCard.BackgroundImage = My.Resources.PRCard
    End Sub

    Private Sub pnlPRCard_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlPRCard.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlPRCard.BackgroundImage = My.Resources.PRCardSelected
    End Sub

    Private Sub pnlPRCard_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlPRCard.MouseEnter
        Me.pnlPRCard.BackgroundImage = My.Resources.PRCardHover
    End Sub

    Private Sub pnlPRCard_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlPRCard.MouseLeave
        Me.pnlPRCard.BackgroundImage = My.Resources.PRCard
    End Sub

    Private Sub pnlEmployeeSales_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlEmployeeSales.Click
        frmMain.menuEmployeeSales.PerformClick()
        Me.pnlEmployeeSales.BackgroundImage = My.Resources.EmployeeSales
    End Sub

    Private Sub pnlEmployeeSales_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlEmployeeSales.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlEmployeeSales.BackgroundImage = My.Resources.EmployeeSalesSelected
    End Sub

    Private Sub pnlEmployeeSales_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlEmployeeSales.MouseEnter
        Me.pnlEmployeeSales.BackgroundImage = My.Resources.EmployeeSalesHover
    End Sub

    Private Sub pnlEmployeeSales_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlEmployeeSales.MouseLeave
        Me.pnlEmployeeSales.BackgroundImage = My.Resources.EmployeeSales
    End Sub

    Private Sub pnlCobrandCard_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlCobrandCard.Click
        frmMain.menuCobrandCard.PerformClick()
        Me.pnlCobrandCard.BackgroundImage = My.Resources.CobrandCard
    End Sub

    Private Sub pnlCobrandCard_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlCobrandCard.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlCobrandCard.BackgroundImage = My.Resources.CobrandCardSelected
    End Sub

    Private Sub pnlCobrandCard_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlCobrandCard.MouseEnter
        Me.pnlCobrandCard.BackgroundImage = My.Resources.CobrandCardHover
    End Sub

    Private Sub pnlCobrandCard_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlCobrandCard.MouseLeave
        Me.pnlCobrandCard.BackgroundImage = My.Resources.CobrandCard
    End Sub

    Private Sub pnlCUL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlCUL.Click
        Me.pnlCUL.BackgroundImage = My.Resources.CULSpecialOperation
        Dim sMenu As String = "", bFunctions As Byte = 0
        With frmCardSpecialOperation
            If frmMain.menuResetCardPassword.Enabled Then
                .pnlResetCardPassword.Visible = True
                sMenu = "menuResetCardPassword" : bFunctions += 1
            End If
            If frmMain.menuFreezeCard.Enabled Then
                .pnlFreezeCard.Visible = True
                sMenu = "menuFreezeCard" : bFunctions += 1
            End If
            If frmMain.menuUrgentDeduction.Enabled Then
                .pnlUrgencyDeduct.Visible = True
                sMenu = "menuUrgentDeduction" : bFunctions += 1
            End If
            If frmMain.menuReplaceCard.Enabled Then
                .pnlChangeCard.Visible = True
                sMenu = "menuReplaceCard" : bFunctions += 1
            End If
            If frmMain.menuReplaceCardValidation.Enabled Then
                .pnlAffirmChangeCard.Visible = True
                sMenu = "menuReplaceCardValidation" : bFunctions += 1
            End If
            If frmMain.menuUnchargeCard.Enabled Then
                .pnlUnchargeCard.Visible = True
                sMenu = "menuUnchargeCard" : bFunctions += 1
            End If
            If frmMain.menuAffirmUnchargeCard.Enabled Then
                .pnlAffirmUnchargeCard.Visible = True
                sMenu = "menuAffirmUnchargeCard" : bFunctions += 1
            End If
            If frmMain.menuUnchargeMKTCard.Enabled Then
                .pnlUnchargeMKTCard.Visible = True
                sMenu = "menuUnchargeMKTCard" : bFunctions += 1
            End If
            If frmMain.menuAffirmUnchargeMKTCard.Enabled Then
                .pnlAffirmUnchargeMKTCard.Visible = True
                sMenu = "menuAffirmUnchargeMKTCard" : bFunctions += 1
            End If
            If frmMain.menuGiftCardActivationCancel.Enabled Then
                .pnlGiftCardActivationCancel.Visible = True
                sMenu = "menuGiftCardActivationCancel" : bFunctions += 1
            End If
            If frmMain.menuAffirmGiftCardActivationCancel.Enabled Then
                .pnlAffirmGiftCardActivationCancel.Visible = True
                sMenu = "menuAffirmGiftCardActivationCancel" : bFunctions += 1
            End If
            If frmMain.menuGiftCardOfflineActivate.Enabled Then
                .pnlGiftCardOfflineActivate.Visible = True
                sMenu = "pnlGiftCardOfflineActivate" : bFunctions += 1
            End If
            If frmMain.menuAffirmGiftCardOfflineActivate.Enabled Then
                .pnlAffirmGiftCardOfflineActivate.Visible = True
                sMenu = "menuAffirmGiftCardOfflineActivate" : bFunctions += 1
            End If
            If frmMain.menuRecycleCard.Enabled Then
                .pnlRecycleCard.Visible = True
                sMenu = "menuRecycleCard" : bFunctions += 1
            End If
            If frmMain.menuAffirmRecycleCard.Enabled Then
                .pnlAffirmRecycleCard.Visible = True
                sMenu = "menuAffirmRecycleCard" : bFunctions += 1
            End If
            If frmMain.menuCardStateQuery.Enabled Then
                .pnlCardStateQuery.Visible = True
                sMenu = "menuCardStateQuery" : bFunctions += 1
            End If
            'modify code 023:start-------------------------------------------------------------------------
            If frmMain.menuCardStateQuery_Section.Enabled Then
                .pnlCardStateQuery_Section.Visible = True
                sMenu = "menuCardStateQuery_Section" : bFunctions += 1
            End If
            'modify code 023:end-------------------------------------------------------------------------
        End With

        If bFunctions > 1 Then
            sMenu = ""
            If frmCardSpecialOperation.ShowDialog = Windows.Forms.DialogResult.OK Then
                sMenu = frmCardSpecialOperation.sMenu
            End If
            frmCardSpecialOperation.Dispose()
        End If

        If sMenu <> "" Then frmMain.menuCULSpecialOperation.DropDownItems(sMenu).PerformClick()
    End Sub

    Private Sub pnlCUL_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlCUL.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlCUL.BackgroundImage = My.Resources.CULSpecialOperationSelected
    End Sub

    Private Sub pnlCUL_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlCUL.MouseEnter
        Me.pnlCUL.BackgroundImage = My.Resources.CULSpecialOperationHover
    End Sub

    Private Sub pnlCUL_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlCUL.MouseLeave
        Me.pnlCUL.BackgroundImage = My.Resources.CULSpecialOperation
    End Sub

    Private Sub pnlCashActivation_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlCashActivation.Click
        frmMain.menuCashActivation.PerformClick()
        Me.pnlCashActivation.BackgroundImage = My.Resources.CashActivation
    End Sub

    Private Sub pnlCashActivation_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlCashActivation.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlCashActivation.BackgroundImage = My.Resources.CashActivationSelected
    End Sub

    Private Sub pnlCashActivation_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlCashActivation.MouseEnter
        Me.pnlCashActivation.BackgroundImage = My.Resources.CashActivationHover
    End Sub

    Private Sub pnlCashActivation_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlCashActivation.MouseLeave
        Me.pnlCashActivation.BackgroundImage = My.Resources.CashActivation
    End Sub

    Private Sub pnlEmployeeActivation_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlEmployeeActivation.Click
        frmMain.menuEmployeeActivation.PerformClick()
        Me.pnlEmployeeActivation.BackgroundImage = My.Resources.EmployeeActivation
    End Sub

    Private Sub pnlEmployeeActivation_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlEmployeeActivation.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlEmployeeActivation.BackgroundImage = My.Resources.EmployeeActivationSelected
    End Sub

    Private Sub pnlEmployeeActivation_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlEmployeeActivation.MouseEnter
        Me.pnlEmployeeActivation.BackgroundImage = My.Resources.EmployeeActivationHover
    End Sub

    Private Sub pnlEmployeeActivation_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlEmployeeActivation.MouseLeave
        Me.pnlEmployeeActivation.BackgroundImage = My.Resources.EmployeeActivation
    End Sub

    Private Sub pnlChequeActivation_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlChequeActivation.Click
        frmMain.menuChequeActivation.PerformClick()
        Me.pnlChequeActivation.BackgroundImage = My.Resources.ChequeActivation
    End Sub

    Private Sub pnlChequeActivation_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlChequeActivation.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlChequeActivation.BackgroundImage = My.Resources.ChequeActivationSelected
    End Sub

    Private Sub pnlChequeActivation_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlChequeActivation.MouseEnter
        Me.pnlChequeActivation.BackgroundImage = My.Resources.ChequeActivationHover
    End Sub

    Private Sub pnlChequeActivation_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlChequeActivation.MouseLeave
        Me.pnlChequeActivation.BackgroundImage = My.Resources.ChequeActivation
    End Sub

    Private Sub pnlSalesReporting_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlSalesReporting.Click
        Me.pnlSalesReporting.BackgroundImage = My.Resources.SalesReporting
        frmSalesReport.ShowDialog()
        frmSalesReport.Dispose()
        If frmMain.MdiChildren.Length > 1 AndAlso frmMain.ActiveMdiChild.Equals(Me) Then
            Try
                For Each theForm As Form In frmMain.MdiChildren
                    If Not theForm.Equals(Me) Then theForm.Activate() : Exit For
                Next
            Finally
            End Try
        End If
    End Sub

    Private Sub pnlSalesReporting_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlSalesReporting.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlSalesReporting.BackgroundImage = My.Resources.SalesReportingSelected
    End Sub

    Private Sub pnlSalesReporting_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlSalesReporting.MouseEnter
        Me.pnlSalesReporting.BackgroundImage = My.Resources.SalesReportingHover
    End Sub

    Private Sub pnlSalesReporting_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlSalesReporting.MouseLeave
        Me.pnlSalesReporting.BackgroundImage = My.Resources.SalesReporting
    End Sub

    Private Sub pnlJVReporting_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlJVReporting.Click
        Me.pnlJVReporting.BackgroundImage = My.Resources.JVReporting
        frmJVReport.ShowDialog()
        frmJVReport.Dispose()
        If frmMain.MdiChildren.Length > 1 AndAlso frmMain.ActiveMdiChild.Equals(Me) Then
            Try
                For Each theForm As Form In frmMain.MdiChildren
                    If Not theForm.Equals(Me) Then theForm.Activate() : Exit For
                Next
            Finally
            End Try
        End If
    End Sub

    Private Sub pnlJVReporting_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlJVReporting.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlJVReporting.BackgroundImage = My.Resources.JVReportingSelected
    End Sub

    Private Sub pnlJVReporting_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlJVReporting.MouseEnter
        Me.pnlJVReporting.BackgroundImage = My.Resources.JVReportingHover
    End Sub

    Private Sub pnlJVReporting_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlJVReporting.MouseLeave
        Me.pnlJVReporting.BackgroundImage = My.Resources.JVReporting
    End Sub

    Private Sub pnlCustomExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlCustomExport.Click
        frmMain.menuCustomExport.PerformClick()
        Me.pnlCustomExport.BackgroundImage = My.Resources.CustomExport
    End Sub

    Private Sub pnlCustomExport_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlCustomExport.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlCustomExport.BackgroundImage = My.Resources.CustomExportSelected
    End Sub

    Private Sub pnlCustomExport_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlCustomExport.MouseEnter
        Me.pnlCustomExport.BackgroundImage = My.Resources.CustomExportHover
    End Sub

    Private Sub pnlCustomExport_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlCustomExport.MouseLeave
        Me.pnlCustomExport.BackgroundImage = My.Resources.CustomExport
    End Sub

    Private Sub pnlBonusReporting_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlBonusReporting.Click
        frmMain.menuBonusReporting.PerformClick()
        Me.pnlBonusReporting.BackgroundImage = My.Resources.BonusReporting
    End Sub

    Private Sub pnlBonusReporting_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlBonusReporting.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlBonusReporting.BackgroundImage = My.Resources.BonusReportingSelected
    End Sub

    Private Sub pnlBonusReporting_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlBonusReporting.MouseEnter
        Me.pnlBonusReporting.BackgroundImage = My.Resources.BonusReportingHover
    End Sub

    Private Sub pnlBonusReporting_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlBonusReporting.MouseLeave
        Me.pnlBonusReporting.BackgroundImage = My.Resources.BonusReporting
    End Sub

    Private Sub pnlCULReporting_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlCULReporting.Click
        frmMain.menuCULReport.PerformClick()
        Me.pnlCULReporting.BackgroundImage = My.Resources.CULReports
    End Sub

    Private Sub pnlCULReporting_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlCULReporting.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlCULReporting.BackgroundImage = My.Resources.CULReportsSelected
    End Sub

    Private Sub pnlCULReporting_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlCULReporting.MouseEnter
        Me.pnlCULReporting.BackgroundImage = My.Resources.CULReportsHover
    End Sub

    Private Sub pnlCULReporting_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlCULReporting.MouseLeave
        Me.pnlCULReporting.BackgroundImage = My.Resources.CULReports
    End Sub

    Private Sub pnlNavigation_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlNavigation.Click, flpMain.Click
        Me.Activate()
    End Sub

    'modify code 040:start-------------------------------------------------------------------------
    Private Sub pnlInternetSales_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlInternetSales.Click
        frmMain.menuInternetSelling.PerformClick()
        Me.pnlInternetSales.BackgroundImage = My.Resources.OfflineCardTaking
    End Sub

    Private Sub pnlInternetSales_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlInternetSales.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlInternetSales.BackgroundImage = My.Resources.OfflineCardTakingSelected
    End Sub

    Private Sub pnlInternetSales_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlInternetSales.MouseEnter
        Me.pnlInternetSales.BackgroundImage = My.Resources.OfflineCardTakingHover
    End Sub

    Private Sub pnlInternetSales_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlInternetSales.MouseLeave
        Me.pnlInternetSales.BackgroundImage = My.Resources.OfflineCardTaking
    End Sub

    Private Sub pnlInternetSalesInvoice_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlInternetSalesInvoice.Click
        frmMain.menuInternetSalesInvoice.PerformClick()
        Me.pnlInternetSalesInvoice.BackgroundImage = My.Resources.ECardInvoice
    End Sub

    Private Sub pnlInternetSalesInvoice_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlInternetSalesInvoice.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlInternetSalesInvoice.BackgroundImage = My.Resources.ECardInvoiceSelected
    End Sub

    Private Sub pnlInternetSalesInvoice_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlInternetSalesInvoice.MouseEnter
        Me.pnlInternetSalesInvoice.BackgroundImage = My.Resources.ECardInvoiceHover
    End Sub

    Private Sub pnlInternetSalesInvoice_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlInternetSalesInvoice.MouseLeave
        Me.pnlInternetSalesInvoice.BackgroundImage = My.Resources.ECardInvoice
    End Sub
    'modify code 040:end-------------------------------------------------------------------------
    'modify code 054:start-------------------------------------------------------------------------
    Private Sub pnlCrossSelling_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlCrossSelling.Click
        frmMain.menuCrossSellingNonRealNameCard.PerformClick()
        Me.pnlCrossSelling.BackgroundImage = My.Resources.CrossSelling
    End Sub

    Private Sub pnlCrossSelling_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlCrossSelling.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlCrossSelling.BackgroundImage = My.Resources.CrossSellingSelected
    End Sub

    Private Sub pnlCrossSelling_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlCrossSelling.MouseEnter
        Me.pnlCrossSelling.BackgroundImage = My.Resources.CrossSellingHover
    End Sub

    Private Sub pnlCrossSelling_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlCrossSelling.MouseLeave
        Me.pnlCrossSelling.BackgroundImage = My.Resources.CrossSelling
    End Sub

    Private Sub pnlCrossSellingCityDiscountRule_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlCrossSellingCityDiscountRule.Click
        frmMain.menuCrossSellingCityConfig.PerformClick()
        Me.pnlCrossSellingCityDiscountRule.BackgroundImage = My.Resources.CrossSellingCityDiscountRule
    End Sub

    Private Sub pnlCrossSellingCityDiscountRule_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlCrossSellingCityDiscountRule.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlCrossSellingCityDiscountRule.BackgroundImage = My.Resources.CrossSellingCityDiscountRuleSelected
    End Sub

    Private Sub pnlCrossSellingCityDiscountRule_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlCrossSellingCityDiscountRule.MouseEnter
        Me.pnlCrossSellingCityDiscountRule.BackgroundImage = My.Resources.CrossSellingCityDiscountRuleHover
    End Sub

    Private Sub pnlCrossSellingCityDiscountRule_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlCrossSellingCityDiscountRule.MouseLeave
        Me.pnlCrossSellingCityDiscountRule.BackgroundImage = My.Resources.CrossSellingCityDiscountRule
    End Sub
    'modify code 054:end-------------------------------------------------------------------------

    Private Sub pnlElectronicCard_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlElectronicCard.Click
        'modify code 072:start-------------------------------------------------------------------------
        Me.pnlElectronicCard.BackgroundImage = My.Resources.ElectronicCard
        Dim sMenu As String = "", bFunctions As Byte = 0
        With frmElectronicOperation
            If frmMain.menuERequirement.Enabled Then
                .pnlRequirement.Visible = True
                sMenu = "menuERequirement" : bFunctions += 1
            End If
            If frmMain.menuEQuery.Enabled Then
                .pnlSearch.Visible = True
                sMenu = "menuEQuery" : bFunctions += 1
            End If
            If frmMain.menuEActivationRequirement.Enabled Then
                .pnlActivationRequirement.Visible = True
                sMenu = "menuEActivationRequirement" : bFunctions += 1
            End If
            If frmMain.menuEActivationValidation.Enabled Then
                .pnlActivationValidation.Visible = True
                sMenu = "menuEActivationValidation" : bFunctions += 1
            End If
            If frmMain.menuEFreezeCard.Enabled Then
                .pnlFreezeCard.Visible = True
                sMenu = "menuEFreezeCard" : bFunctions += 1
            End If
            If frmMain.menuESupplySms.Enabled Then
                .pnlSupplySms.Visible = True
                sMenu = "menuESupplySms" : bFunctions += 1
            End If
            If frmMain.menuECodeDelay.Enabled Then
                .pnlElectronicCodeDelay.Visible = True
                sMenu = "menuECodeDelay" : bFunctions += 1
            End If
        End With

        If bFunctions >= 0 Then
            sMenu = ""
            If frmElectronicOperation.ShowDialog = Windows.Forms.DialogResult.OK Then
                sMenu = frmElectronicOperation.sMenu
            End If
            frmElectronicOperation.Dispose()
        End If

        If sMenu <> "" Then frmMain.menuElectronicCard.DropDownItems(sMenu).PerformClick()
        'modify code 072:end-------------------------------------------------------------------------
    End Sub

    Private Sub pnlElectronicCard_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlElectronicCard.MouseDown
        'modify code 072:start-------------------------------------------------------------------------
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlElectronicCard.BackgroundImage = My.Resources.ElectronicCardSelected
        'modify code 072:end-------------------------------------------------------------------------
    End Sub

    Private Sub pnlElectronicCard_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlElectronicCard.MouseEnter
        'modify code 072:start-------------------------------------------------------------------------
        Me.pnlElectronicCard.BackgroundImage = My.Resources.ElectronicCardHover
        'modify code 072:end-------------------------------------------------------------------------
    End Sub

    Private Sub pnlElectronicCard_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlElectronicCard.MouseLeave
        'modify code 072:start-------------------------------------------------------------------------
        Me.pnlElectronicCard.BackgroundImage = My.Resources.ElectronicCard
        'modify code 072:end-------------------------------------------------------------------------
    End Sub

    Private Sub pnlElcSpecialOperation_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlElcSpecialOperation.Click
        'modify code 082:start-------------------------------------------------------------------------
        Me.pnlElcSpecialOperation.BackgroundImage = My.Resources.CULElcSpecialOperation
        Dim sMenu As String = "", bFunctions As Byte = 0
        With frmElectronicSpecialOperation
            If frmMain.menuECancelChargeRequirement.Enabled Then
                .pnlECancelChargeRequirement.Visible = True
                sMenu = "menuECancelChargeRequirement" : bFunctions += 1
            End If
            If frmMain.menuECancelChargeValidation.Enabled Then
                .pnlECancelChargeValidation.Visible = True
                sMenu = "menuECancelChargeValidation" : bFunctions += 1
            End If
            If frmMain.menuECancelExtractingCodeRequirement.Enabled Then
                .pnlECancelExtractingCodeRequirement.Visible = True
                sMenu = "menuECancelExtractingCodeRequirement" : bFunctions += 1
            End If
            If frmMain.menuECancelExtractingCodeValidation.Enabled Then
                .pnlECancelExtractingCodeValidation.Visible = True
                sMenu = "menuECancelExtractingCodeValidation" : bFunctions += 1
            End If
            If frmMain.menuECodeDelayRequirement.Enabled Then
                .pnlECodeDelayRequirement.Visible = True
                sMenu = "menuECodeDelayRequirement" : bFunctions += 1
            End If
        End With

        If bFunctions >= 0 Then
            sMenu = ""
            If frmElectronicSpecialOperation.ShowDialog = Windows.Forms.DialogResult.OK Then
                sMenu = frmElectronicSpecialOperation.sMenu
            End If
            frmElectronicSpecialOperation.Dispose()
        End If

        If sMenu <> "" Then frmMain.menuElcSpecialOperation.DropDownItems(sMenu).PerformClick()
        'modify code 072:end-------------------------------------------------------------------------
    End Sub

    Private Sub pnlElcSpecialOperation_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlElcSpecialOperation.MouseDown
        'modify code 082:start-------------------------------------------------------------------------
        If e.Button = Windows.Forms.MouseButtons.Left Then Me.pnlElcSpecialOperation.BackgroundImage = My.Resources.CULElcSpecialOperationSelected
        'modify code 082:end-------------------------------------------------------------------------
    End Sub

    Private Sub pnlElcSpecialOperation_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlElcSpecialOperation.MouseEnter
        'modify code 082:start-------------------------------------------------------------------------
        Me.pnlElcSpecialOperation.BackgroundImage = My.Resources.CULElcSpecialOperationHover
        'modify code 082:end-------------------------------------------------------------------------
    End Sub

    Private Sub pnlElcSpecialOperation_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlElcSpecialOperation.MouseLeave
        'modify code 082:start-------------------------------------------------------------------------
        Me.pnlElcSpecialOperation.BackgroundImage = My.Resources.CULElcSpecialOperation
        'modify code 082:end-------------------------------------------------------------------------
    End Sub
End Class