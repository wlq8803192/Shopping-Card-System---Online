<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.statusMain = New System.Windows.Forms.StatusStrip
        Me.statusText = New System.Windows.Forms.ToolStripStatusLabel
        Me.statusRate = New System.Windows.Forms.ToolStripStatusLabel
        Me.statusProgress = New System.Windows.Forms.ToolStripProgressBar
        Me.statusUser = New System.Windows.Forms.ToolStripStatusLabel
        Me.statusUserName = New System.Windows.Forms.ToolStripStatusLabel
        Me.statusArea = New System.Windows.Forms.ToolStripStatusLabel
        Me.statusAreaName = New System.Windows.Forms.ToolStripStatusLabel
        Me.statusRole = New System.Windows.Forms.ToolStripStatusLabel
        Me.statusRoleName = New System.Windows.Forms.ToolStripStatusLabel
        Me.menuMain = New System.Windows.Forms.MenuStrip
        Me.menuSystem = New System.Windows.Forms.ToolStripMenuItem
        Me.menuNavigation = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.menuSwitchMode = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.menuSmallTool = New System.Windows.Forms.ToolStripMenuItem
        Me.spTool = New System.Windows.Forms.ToolStripSeparator
        Me.menuRelogin = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.menuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.menuParameter = New System.Windows.Forms.ToolStripMenuItem
        Me.menuPosition = New System.Windows.Forms.ToolStripMenuItem
        Me.menuArea = New System.Windows.Forms.ToolStripMenuItem
        Me.menuUserManagement = New System.Windows.Forms.ToolStripMenuItem
        Me.spEmployeeQuota = New System.Windows.Forms.ToolStripSeparator
        Me.menuEmployeeQuota = New System.Windows.Forms.ToolStripMenuItem
        Me.spBusinessType = New System.Windows.Forms.ToolStripSeparator
        Me.menuBusinessType = New System.Windows.Forms.ToolStripMenuItem
        Me.spInvoiceItem = New System.Windows.Forms.ToolStripSeparator
        Me.menuInvoiceItem = New System.Windows.Forms.ToolStripMenuItem
        Me.spInvoiceLayout = New System.Windows.Forms.ToolStripSeparator
        Me.menuInvoiceLayout = New System.Windows.Forms.ToolStripMenuItem
        Me.spRule = New System.Windows.Forms.ToolStripSeparator
        Me.menuCityConfig = New System.Windows.Forms.ToolStripMenuItem
        Me.menuCrossSellingCityConfig = New System.Windows.Forms.ToolStripMenuItem
        Me.spBonusCalcultion = New System.Windows.Forms.ToolStripSeparator
        Me.menuBonusCalculation = New System.Windows.Forms.ToolStripMenuItem
        Me.menuCardManagement = New System.Windows.Forms.ToolStripMenuItem
        Me.menuCustomerManagement = New System.Windows.Forms.ToolStripMenuItem
        Me.spContract = New System.Windows.Forms.ToolStripSeparator
        Me.menuCardFee = New System.Windows.Forms.ToolStripMenuItem
        Me.menuContractManagement = New System.Windows.Forms.ToolStripMenuItem
        Me.menuCrossContractManagement = New System.Windows.Forms.ToolStripMenuItem
        Me.spSelling = New System.Windows.Forms.ToolStripSeparator
        Me.menuSalesBillManagement = New System.Windows.Forms.ToolStripMenuItem
        Me.menuSignCardSelling = New System.Windows.Forms.ToolStripMenuItem
        Me.menuCrossSellingNonRealNameCard = New System.Windows.Forms.ToolStripMenuItem
        Me.menuPredefineFaceValue = New System.Windows.Forms.ToolStripMenuItem
        Me.spBatchRechargeFromFile = New System.Windows.Forms.ToolStripSeparator
        Me.menuCreateSalesBillFromFile = New System.Windows.Forms.ToolStripMenuItem
        Me.menuImportSignCardSalesBill = New System.Windows.Forms.ToolStripMenuItem
        Me.menuDownloadSignCardSalesBillSellingTemp = New System.Windows.Forms.ToolStripMenuItem
        Me.menuCreateSignCardSalesBillFromFile = New System.Windows.Forms.ToolStripMenuItem
        Me.spCard = New System.Windows.Forms.ToolStripSeparator
        Me.menuCULSpecialOperation = New System.Windows.Forms.ToolStripMenuItem
        Me.menuSalesBillRecharge = New System.Windows.Forms.ToolStripMenuItem
        Me.spReturnGoods = New System.Windows.Forms.ToolStripSeparator
        Me.menuCreateReturnedSalesBill = New System.Windows.Forms.ToolStripMenuItem
        Me.menuMarketingPromotion = New System.Windows.Forms.ToolStripMenuItem
        Me.menuPRCard = New System.Windows.Forms.ToolStripMenuItem
        Me.menuEmployeeSales = New System.Windows.Forms.ToolStripMenuItem
        Me.menuCobrandCard = New System.Windows.Forms.ToolStripMenuItem
        Me.menuInternetSelling = New System.Windows.Forms.ToolStripMenuItem
        Me.menuInternetSalesInvoice = New System.Windows.Forms.ToolStripMenuItem
        Me.spCUL = New System.Windows.Forms.ToolStripSeparator
        Me.menuResetCardPassword = New System.Windows.Forms.ToolStripMenuItem
        Me.menuFreezeCard = New System.Windows.Forms.ToolStripMenuItem
        Me.menuUrgentDeduction = New System.Windows.Forms.ToolStripMenuItem
        Me.menuReplaceCard = New System.Windows.Forms.ToolStripMenuItem
        Me.menuReplaceCardValidation = New System.Windows.Forms.ToolStripMenuItem
        Me.menuUnchargeCard = New System.Windows.Forms.ToolStripMenuItem
        Me.menuAffirmUnchargeCard = New System.Windows.Forms.ToolStripMenuItem
        Me.menuUnchargeMKTCard = New System.Windows.Forms.ToolStripMenuItem
        Me.menuAffirmUnchargeMKTCard = New System.Windows.Forms.ToolStripMenuItem
        Me.menuGiftCardActivationCancel = New System.Windows.Forms.ToolStripMenuItem
        Me.menuAffirmGiftCardActivationCancel = New System.Windows.Forms.ToolStripMenuItem
        Me.menuGiftCardOfflineActivate = New System.Windows.Forms.ToolStripMenuItem
        Me.menuAffirmGiftCardOfflineActivate = New System.Windows.Forms.ToolStripMenuItem
        Me.menuRecycleCard = New System.Windows.Forms.ToolStripMenuItem
        Me.menuAffirmRecycleCard = New System.Windows.Forms.ToolStripMenuItem
        Me.spCULQuery = New System.Windows.Forms.ToolStripSeparator
        Me.menuCardStateQuery = New System.Windows.Forms.ToolStripMenuItem
        Me.menuCardStateQuery_Section = New System.Windows.Forms.ToolStripMenuItem
        Me.menuSignCardSpecialOperationHead = New System.Windows.Forms.ToolStripMenuItem
        Me.menuSignCardSpecialOperation = New System.Windows.Forms.ToolStripMenuItem
        Me.menuSignCardReplace = New System.Windows.Forms.ToolStripMenuItem
        Me.menuInvoiceOperation = New System.Windows.Forms.ToolStripMenuItem
        Me.menuInvoiceDeviceTesting = New System.Windows.Forms.ToolStripMenuItem
        Me.menuInvoiceCancellation = New System.Windows.Forms.ToolStripMenuItem
        Me.menuActivation = New System.Windows.Forms.ToolStripMenuItem
        Me.menuCashActivation = New System.Windows.Forms.ToolStripMenuItem
        Me.menuEmployeeActivation = New System.Windows.Forms.ToolStripMenuItem
        Me.menuChequeActivation = New System.Windows.Forms.ToolStripMenuItem
        Me.menuReport = New System.Windows.Forms.ToolStripMenuItem
        Me.menuSalesReport = New System.Windows.Forms.ToolStripMenuItem
        Me.menuDailyReport1 = New System.Windows.Forms.ToolStripMenuItem
        Me.menuDailyReport2 = New System.Windows.Forms.ToolStripMenuItem
        Me.menuDailyReport3 = New System.Windows.Forms.ToolStripMenuItem
        Me.menuDailyReport4 = New System.Windows.Forms.ToolStripMenuItem
        Me.menuDailyReport5 = New System.Windows.Forms.ToolStripMenuItem
        Me.menuDailyReport6 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.menuMonthReport1 = New System.Windows.Forms.ToolStripMenuItem
        Me.menuMonthReport2 = New System.Windows.Forms.ToolStripMenuItem
        Me.menuMonthReport3 = New System.Windows.Forms.ToolStripMenuItem
        Me.menuMonthReport4 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.menuYearlyReport = New System.Windows.Forms.ToolStripMenuItem
        Me.menuDailybyCustomer = New System.Windows.Forms.ToolStripMenuItem
        Me.menuFishReport = New System.Windows.Forms.ToolStripMenuItem
        Me.spJVReports = New System.Windows.Forms.ToolStripSeparator
        Me.menuJVReport = New System.Windows.Forms.ToolStripMenuItem
        Me.spBonusReport = New System.Windows.Forms.ToolStripSeparator
        Me.menuBonusReporting = New System.Windows.Forms.ToolStripMenuItem
        Me.spCustomReport = New System.Windows.Forms.ToolStripSeparator
        Me.menuCustomExport = New System.Windows.Forms.ToolStripMenuItem
        Me.spCULReport = New System.Windows.Forms.ToolStripSeparator
        Me.menuCULReport = New System.Windows.Forms.ToolStripMenuItem
        Me.menuMessage = New System.Windows.Forms.ToolStripMenuItem
        Me.menuHotLine = New System.Windows.Forms.ToolStripMenuItem
        Me.menuExitSystem = New System.Windows.Forms.ToolStripMenuItem
        Me.menuElectronicCard = New System.Windows.Forms.ToolStripMenuItem
        Me.menuERequirement = New System.Windows.Forms.ToolStripMenuItem
        Me.menuEQuery = New System.Windows.Forms.ToolStripMenuItem
        Me.menuEActivationRequirement = New System.Windows.Forms.ToolStripMenuItem
        Me.menuEActivationValidation = New System.Windows.Forms.ToolStripMenuItem
        Me.menuEFreezeCard = New System.Windows.Forms.ToolStripMenuItem
        Me.menuESupplySms = New System.Windows.Forms.ToolStripMenuItem
        Me.menuECodeDelay = New System.Windows.Forms.ToolStripMenuItem
        Me.menuECancelChargeRequirement = New System.Windows.Forms.ToolStripMenuItem
        Me.menuECancelChargeValidation = New System.Windows.Forms.ToolStripMenuItem
        Me.menuECancelExtractingCodeRequirement = New System.Windows.Forms.ToolStripMenuItem
        Me.menuECancelExtractingCodeValidation = New System.Windows.Forms.ToolStripMenuItem
        Me.menuECodeDelayRequirement = New System.Windows.Forms.ToolStripMenuItem
        Me.menuElcSpecialOperation = New System.Windows.Forms.ToolStripMenuItem
        Me.spCrossContract = New System.Windows.Forms.ToolStripSeparator
        Me.notifyMessage = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.timerMessage = New System.Windows.Forms.Timer(Me.components)
        Me.statusMain.SuspendLayout()
        Me.menuMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'statusMain
        '
        Me.statusMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusText, Me.statusRate, Me.statusProgress, Me.statusUser, Me.statusUserName, Me.statusArea, Me.statusAreaName, Me.statusRole, Me.statusRoleName})
        Me.statusMain.Location = New System.Drawing.Point(0, 509)
        Me.statusMain.Name = "statusMain"
        Me.statusMain.ShowItemToolTips = True
        Me.statusMain.Size = New System.Drawing.Size(790, 25)
        Me.statusMain.TabIndex = 4
        Me.statusMain.Text = "StatusStrip1"
        '
        'statusText
        '
        Me.statusText.BackColor = System.Drawing.SystemColors.Control
        Me.statusText.Name = "statusText"
        Me.statusText.Size = New System.Drawing.Size(578, 20)
        Me.statusText.Spring = True
        Me.statusText.Text = "请登录系统……"
        Me.statusText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'statusRate
        '
        Me.statusRate.BackColor = System.Drawing.SystemColors.Control
        Me.statusRate.Name = "statusRate"
        Me.statusRate.Size = New System.Drawing.Size(0, 20)
        Me.statusRate.Visible = False
        '
        'statusProgress
        '
        Me.statusProgress.BackColor = System.Drawing.SystemColors.Control
        Me.statusProgress.Name = "statusProgress"
        Me.statusProgress.Size = New System.Drawing.Size(200, 19)
        Me.statusProgress.Visible = False
        '
        'statusUser
        '
        Me.statusUser.AutoSize = False
        Me.statusUser.BackColor = System.Drawing.SystemColors.Control
        Me.statusUser.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.statusUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.statusUser.Image = CType(resources.GetObject("statusUser.Image"), System.Drawing.Image)
        Me.statusUser.Name = "statusUser"
        Me.statusUser.Size = New System.Drawing.Size(24, 20)
        Me.statusUser.ToolTipText = "登录用户 " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Login User"
        '
        'statusUserName
        '
        Me.statusUserName.BackColor = System.Drawing.SystemColors.Control
        Me.statusUserName.Margin = New System.Windows.Forms.Padding(0, 3, 4, 2)
        Me.statusUserName.Name = "statusUserName"
        Me.statusUserName.Size = New System.Drawing.Size(39, 20)
        Me.statusUserName.Text = "(未知)"
        '
        'statusArea
        '
        Me.statusArea.AutoSize = False
        Me.statusArea.BackColor = System.Drawing.SystemColors.Control
        Me.statusArea.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.statusArea.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.statusArea.Image = CType(resources.GetObject("statusArea.Image"), System.Drawing.Image)
        Me.statusArea.Name = "statusArea"
        Me.statusArea.Size = New System.Drawing.Size(24, 20)
        Me.statusArea.Text = " "
        Me.statusArea.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.statusArea.ToolTipText = "登录位置 " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Login Location"
        '
        'statusAreaName
        '
        Me.statusAreaName.BackColor = System.Drawing.SystemColors.Control
        Me.statusAreaName.Margin = New System.Windows.Forms.Padding(0, 3, 4, 2)
        Me.statusAreaName.Name = "statusAreaName"
        Me.statusAreaName.Size = New System.Drawing.Size(39, 20)
        Me.statusAreaName.Text = "(未知)"
        '
        'statusRole
        '
        Me.statusRole.AutoSize = False
        Me.statusRole.BackColor = System.Drawing.SystemColors.Control
        Me.statusRole.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.statusRole.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.statusRole.Image = CType(resources.GetObject("statusRole.Image"), System.Drawing.Image)
        Me.statusRole.Name = "statusRole"
        Me.statusRole.Size = New System.Drawing.Size(24, 20)
        Me.statusRole.ToolTipText = "登录者职位" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "User's Position"
        '
        'statusRoleName
        '
        Me.statusRoleName.BackColor = System.Drawing.SystemColors.Control
        Me.statusRoleName.Name = "statusRoleName"
        Me.statusRoleName.Size = New System.Drawing.Size(39, 20)
        Me.statusRoleName.Text = "(未知)"
        '
        'menuMain
        '
        Me.menuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuSystem, Me.menuParameter, Me.menuCardManagement, Me.menuInvoiceOperation, Me.menuActivation, Me.menuReport, Me.menuMessage, Me.menuHotLine, Me.menuExitSystem})
        Me.menuMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.menuMain.Location = New System.Drawing.Point(0, 0)
        Me.menuMain.Name = "menuMain"
        Me.menuMain.Size = New System.Drawing.Size(790, 24)
        Me.menuMain.TabIndex = 3
        '
        'menuSystem
        '
        Me.menuSystem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuNavigation, Me.ToolStripSeparator5, Me.menuSwitchMode, Me.ToolStripSeparator3, Me.menuSmallTool, Me.spTool, Me.menuRelogin, Me.ToolStripSeparator4, Me.menuExit})
        Me.menuSystem.Name = "menuSystem"
        Me.menuSystem.Size = New System.Drawing.Size(82, 20)
        Me.menuSystem.Text = "系统-&System"
        '
        'menuNavigation
        '
        Me.menuNavigation.Checked = True
        Me.menuNavigation.CheckState = System.Windows.Forms.CheckState.Checked
        Me.menuNavigation.Name = "menuNavigation"
        Me.menuNavigation.Size = New System.Drawing.Size(260, 22)
        Me.menuNavigation.Text = "系统导航 System &Navigaion"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(257, 6)
        '
        'menuSwitchMode
        '
        Me.menuSwitchMode.Name = "menuSwitchMode"
        Me.menuSwitchMode.Size = New System.Drawing.Size(260, 22)
        Me.menuSwitchMode.Text = "切换操作模式 &Switch Operation Mode"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(257, 6)
        '
        'menuSmallTool
        '
        Me.menuSmallTool.Name = "menuSmallTool"
        Me.menuSmallTool.Size = New System.Drawing.Size(260, 22)
        Me.menuSmallTool.Text = "卡号计算器 Card No Calc&ulation"
        Me.menuSmallTool.Visible = False
        '
        'spTool
        '
        Me.spTool.Name = "spTool"
        Me.spTool.Size = New System.Drawing.Size(257, 6)
        Me.spTool.Visible = False
        '
        'menuRelogin
        '
        Me.menuRelogin.Name = "menuRelogin"
        Me.menuRelogin.Size = New System.Drawing.Size(260, 22)
        Me.menuRelogin.Text = "重新登录 &Relogin"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(257, 6)
        '
        'menuExit
        '
        Me.menuExit.Name = "menuExit"
        Me.menuExit.Size = New System.Drawing.Size(260, 22)
        Me.menuExit.Text = "退出     &Exit"
        '
        'menuParameter
        '
        Me.menuParameter.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuPosition, Me.menuArea, Me.menuUserManagement, Me.spEmployeeQuota, Me.menuEmployeeQuota, Me.spBusinessType, Me.menuBusinessType, Me.spInvoiceItem, Me.menuInvoiceItem, Me.spInvoiceLayout, Me.menuInvoiceLayout, Me.spRule, Me.menuCityConfig, Me.menuCrossSellingCityConfig, Me.spBonusCalcultion, Me.menuBonusCalculation})
        Me.menuParameter.Name = "menuParameter"
        Me.menuParameter.Size = New System.Drawing.Size(121, 20)
        Me.menuParameter.Text = "参数设置-&Parameter"
        '
        'menuPosition
        '
        Me.menuPosition.Name = "menuPosition"
        Me.menuPosition.Size = New System.Drawing.Size(298, 22)
        Me.menuPosition.Text = "职位管理 &Position Management"
        '
        'menuArea
        '
        Me.menuArea.Name = "menuArea"
        Me.menuArea.Size = New System.Drawing.Size(298, 22)
        Me.menuArea.Text = "区域管理 &Location Management"
        '
        'menuUserManagement
        '
        Me.menuUserManagement.Name = "menuUserManagement"
        Me.menuUserManagement.Size = New System.Drawing.Size(298, 22)
        Me.menuUserManagement.Text = "用户管理 &User Management"
        '
        'spEmployeeQuota
        '
        Me.spEmployeeQuota.Name = "spEmployeeQuota"
        Me.spEmployeeQuota.Size = New System.Drawing.Size(295, 6)
        '
        'menuEmployeeQuota
        '
        Me.menuEmployeeQuota.Name = "menuEmployeeQuota"
        Me.menuEmployeeQuota.Size = New System.Drawing.Size(298, 22)
        Me.menuEmployeeQuota.Text = "员工额度设置 Employee &Quota Configuration"
        '
        'spBusinessType
        '
        Me.spBusinessType.Name = "spBusinessType"
        Me.spBusinessType.Size = New System.Drawing.Size(295, 6)
        '
        'menuBusinessType
        '
        Me.menuBusinessType.Name = "menuBusinessType"
        Me.menuBusinessType.Size = New System.Drawing.Size(298, 22)
        Me.menuBusinessType.Text = "商业类型 Business &Type Management"
        '
        'spInvoiceItem
        '
        Me.spInvoiceItem.Name = "spInvoiceItem"
        Me.spInvoiceItem.Size = New System.Drawing.Size(295, 6)
        '
        'menuInvoiceItem
        '
        Me.menuInvoiceItem.Name = "menuInvoiceItem"
        Me.menuInvoiceItem.Size = New System.Drawing.Size(298, 22)
        Me.menuInvoiceItem.Text = "发票品项 Inovice &Item Management"
        '
        'spInvoiceLayout
        '
        Me.spInvoiceLayout.Name = "spInvoiceLayout"
        Me.spInvoiceLayout.Size = New System.Drawing.Size(295, 6)
        '
        'menuInvoiceLayout
        '
        Me.menuInvoiceLayout.Name = "menuInvoiceLayout"
        Me.menuInvoiceLayout.Size = New System.Drawing.Size(298, 22)
        Me.menuInvoiceLayout.Text = "发票版面 In&voice Layout Configuration"
        '
        'spRule
        '
        Me.spRule.Name = "spRule"
        Me.spRule.Size = New System.Drawing.Size(295, 6)
        '
        'menuCityConfig
        '
        Me.menuCityConfig.Name = "menuCityConfig"
        Me.menuCityConfig.Size = New System.Drawing.Size(298, 22)
        Me.menuCityConfig.Text = "城市返点规则设置 City &Discount Rule"
        '
        'menuCrossSellingCityConfig
        '
        Me.menuCrossSellingCityConfig.Name = "menuCrossSellingCityConfig"
        Me.menuCrossSellingCityConfig.Size = New System.Drawing.Size(298, 22)
        Me.menuCrossSellingCityConfig.Text = "通卖返点规则设置 CrossSelling Discount Rule"
        '
        'spBonusCalcultion
        '
        Me.spBonusCalcultion.Name = "spBonusCalcultion"
        Me.spBonusCalcultion.Size = New System.Drawing.Size(295, 6)
        '
        'menuBonusCalculation
        '
        Me.menuBonusCalculation.Name = "menuBonusCalculation"
        Me.menuBonusCalculation.Size = New System.Drawing.Size(298, 22)
        Me.menuBonusCalculation.Text = "奖金计算 &Bonus Calculate"
        '
        'menuCardManagement
        '
        Me.menuCardManagement.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuCustomerManagement, Me.spContract, Me.menuCardFee, Me.menuContractManagement, Me.menuCrossContractManagement, Me.spSelling, Me.menuSalesBillManagement, Me.menuSignCardSelling, Me.menuCrossSellingNonRealNameCard, Me.menuPredefineFaceValue, Me.spBatchRechargeFromFile, Me.menuCreateSalesBillFromFile, Me.menuImportSignCardSalesBill, Me.spCard, Me.menuCULSpecialOperation, Me.menuSignCardSpecialOperationHead})
        Me.menuCardManagement.Name = "menuCardManagement"
        Me.menuCardManagement.Size = New System.Drawing.Size(171, 20)
        Me.menuCardManagement.Text = "购物卡管理-&Card Management"
        '
        'menuCustomerManagement
        '
        Me.menuCustomerManagement.Name = "menuCustomerManagement"
        Me.menuCustomerManagement.Size = New System.Drawing.Size(329, 22)
        Me.menuCustomerManagement.Text = "客户管理 Custo&mer Management"
        '
        'spContract
        '
        Me.spContract.Name = "spContract"
        Me.spContract.Size = New System.Drawing.Size(326, 6)
        '
        'menuCardFee
        '
        Me.menuCardFee.Name = "menuCardFee"
        Me.menuCardFee.Size = New System.Drawing.Size(329, 22)
        Me.menuCardFee.Text = "卡片成本设置 Card &Fee Config"
        '
        'menuContractManagement
        '
        Me.menuContractManagement.Name = "menuContractManagement"
        Me.menuContractManagement.Size = New System.Drawing.Size(329, 22)
        Me.menuContractManagement.Text = "合同管理 Con&tract Management"
        '
        'menuCrossContractManagement
        '
        Me.menuCrossContractManagement.Name = "menuCrossContractManagement"
        Me.menuCrossContractManagement.Size = New System.Drawing.Size(329, 22)
        Me.menuCrossContractManagement.Text = "通卖合同管理 CrossContract Management"
        '
        'spSelling
        '
        Me.spSelling.Name = "spSelling"
        Me.spSelling.Size = New System.Drawing.Size(326, 6)
        '
        'menuSalesBillManagement
        '
        Me.menuSalesBillManagement.Name = "menuSalesBillManagement"
        Me.menuSalesBillManagement.Size = New System.Drawing.Size(329, 22)
        Me.menuSalesBillManagement.Text = "销售管理 &Selling Management"
        '
        'menuSignCardSelling
        '
        Me.menuSignCardSelling.Name = "menuSignCardSelling"
        Me.menuSignCardSelling.Size = New System.Drawing.Size(329, 22)
        Me.menuSignCardSelling.Text = "实名制卡销售 Sign Card Selling"
        '
        'menuCrossSellingNonRealNameCard
        '
        Me.menuCrossSellingNonRealNameCard.Name = "menuCrossSellingNonRealNameCard"
        Me.menuCrossSellingNonRealNameCard.Size = New System.Drawing.Size(329, 22)
        Me.menuCrossSellingNonRealNameCard.Text = "通卖非实名卡销售 CrossSelling Non RealName Card"
        '
        'menuPredefineFaceValue
        '
        Me.menuPredefineFaceValue.Name = "menuPredefineFaceValue"
        Me.menuPredefineFaceValue.Size = New System.Drawing.Size(329, 22)
        Me.menuPredefineFaceValue.Text = "预定义卡面值 Predefine Face &Value"
        '
        'spBatchRechargeFromFile
        '
        Me.spBatchRechargeFromFile.Name = "spBatchRechargeFromFile"
        Me.spBatchRechargeFromFile.Size = New System.Drawing.Size(326, 6)
        '
        'menuCreateSalesBillFromFile
        '
        Me.menuCreateSalesBillFromFile.Name = "menuCreateSalesBillFromFile"
        Me.menuCreateSalesBillFromFile.Size = New System.Drawing.Size(329, 22)
        Me.menuCreateSalesBillFromFile.Text = "批量再充值  &Batch Recharge Card "
        '
        'menuImportSignCardSalesBill
        '
        Me.menuImportSignCardSalesBill.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.menuImportSignCardSalesBill.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuDownloadSignCardSalesBillSellingTemp, Me.menuCreateSignCardSalesBillFromFile})
        Me.menuImportSignCardSalesBill.Name = "menuImportSignCardSalesBill"
        Me.menuImportSignCardSalesBill.Size = New System.Drawing.Size(329, 22)
        Me.menuImportSignCardSalesBill.Text = "实名制卡批量导入  SignCard Batch Import "
        '
        'menuDownloadSignCardSalesBillSellingTemp
        '
        Me.menuDownloadSignCardSalesBillSellingTemp.Name = "menuDownloadSignCardSalesBillSellingTemp"
        Me.menuDownloadSignCardSalesBillSellingTemp.Size = New System.Drawing.Size(358, 22)
        Me.menuDownloadSignCardSalesBillSellingTemp.Text = "下载实名制卡导入模板  Download SignCard Selling Temp "
        '
        'menuCreateSignCardSalesBillFromFile
        '
        Me.menuCreateSignCardSalesBillFromFile.Name = "menuCreateSignCardSalesBillFromFile"
        Me.menuCreateSignCardSalesBillFromFile.Size = New System.Drawing.Size(358, 22)
        Me.menuCreateSignCardSalesBillFromFile.Text = "实名制卡售卖  SignCard Selling "
        '
        'spCard
        '
        Me.spCard.Name = "spCard"
        Me.spCard.Size = New System.Drawing.Size(326, 6)
        '
        'menuCULSpecialOperation
        '
        Me.menuCULSpecialOperation.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.menuCULSpecialOperation.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuSalesBillRecharge, Me.spReturnGoods, Me.menuCreateReturnedSalesBill, Me.menuMarketingPromotion, Me.menuPRCard, Me.menuEmployeeSales, Me.menuCobrandCard, Me.menuInternetSelling, Me.menuInternetSalesInvoice, Me.spCUL, Me.menuResetCardPassword, Me.menuFreezeCard, Me.menuUrgentDeduction, Me.menuReplaceCard, Me.menuReplaceCardValidation, Me.menuUnchargeCard, Me.menuAffirmUnchargeCard, Me.menuUnchargeMKTCard, Me.menuAffirmUnchargeMKTCard, Me.menuGiftCardActivationCancel, Me.menuAffirmGiftCardActivationCancel, Me.menuGiftCardOfflineActivate, Me.menuAffirmGiftCardOfflineActivate, Me.menuRecycleCard, Me.menuAffirmRecycleCard, Me.spCULQuery, Me.menuCardStateQuery, Me.menuCardStateQuery_Section})
        Me.menuCULSpecialOperation.Name = "menuCULSpecialOperation"
        Me.menuCULSpecialOperation.Size = New System.Drawing.Size(329, 22)
        Me.menuCULSpecialOperation.Text = "购物卡特殊操作 &Card Special Operation"
        '
        'menuSalesBillRecharge
        '
        Me.menuSalesBillRecharge.Name = "menuSalesBillRecharge"
        Me.menuSalesBillRecharge.Size = New System.Drawing.Size(404, 22)
        Me.menuSalesBillRecharge.Text = "购物卡再充值  Card Rechar&ge"
        Me.menuSalesBillRecharge.Visible = False
        '
        'spReturnGoods
        '
        Me.spReturnGoods.Name = "spReturnGoods"
        Me.spReturnGoods.Size = New System.Drawing.Size(401, 6)
        Me.spReturnGoods.Visible = False
        '
        'menuCreateReturnedSalesBill
        '
        Me.menuCreateReturnedSalesBill.Name = "menuCreateReturnedSalesBill"
        Me.menuCreateReturnedSalesBill.Size = New System.Drawing.Size(404, 22)
        Me.menuCreateReturnedSalesBill.Text = "退货销售  &Return Goods Selling"
        '
        'menuMarketingPromotion
        '
        Me.menuMarketingPromotion.Name = "menuMarketingPromotion"
        Me.menuMarketingPromotion.Size = New System.Drawing.Size(404, 22)
        Me.menuMarketingPromotion.Text = "活动卡销售 &Marketing Promotion Selling"
        '
        'menuPRCard
        '
        Me.menuPRCard.Name = "menuPRCard"
        Me.menuPRCard.Size = New System.Drawing.Size(404, 22)
        Me.menuPRCard.Text = "公关卡销售 &PR Card Selling"
        '
        'menuEmployeeSales
        '
        Me.menuEmployeeSales.Name = "menuEmployeeSales"
        Me.menuEmployeeSales.Size = New System.Drawing.Size(404, 22)
        Me.menuEmployeeSales.Text = "员工专卖 &Employee Sales"
        '
        'menuCobrandCard
        '
        Me.menuCobrandCard.Name = "menuCobrandCard"
        Me.menuCobrandCard.Size = New System.Drawing.Size(404, 22)
        Me.menuCobrandCard.Text = "联名卡销售 Co-&brand Card Sales"
        '
        'menuInternetSelling
        '
        Me.menuInternetSelling.Name = "menuInternetSelling"
        Me.menuInternetSelling.Size = New System.Drawing.Size(404, 22)
        Me.menuInternetSelling.Text = "线下提卡 &Internet Selling"
        '
        'menuInternetSalesInvoice
        '
        Me.menuInternetSalesInvoice.Name = "menuInternetSalesInvoice"
        Me.menuInternetSalesInvoice.Size = New System.Drawing.Size(404, 22)
        Me.menuInternetSalesInvoice.Text = "电子卡开票 &InternetSales Invoice"
        '
        'spCUL
        '
        Me.spCUL.Name = "spCUL"
        Me.spCUL.Size = New System.Drawing.Size(401, 6)
        '
        'menuResetCardPassword
        '
        Me.menuResetCardPassword.Name = "menuResetCardPassword"
        Me.menuResetCardPassword.Size = New System.Drawing.Size(404, 22)
        Me.menuResetCardPassword.Text = "重置/修改购物卡密码 Reset/Change Shopping Card's &Password"
        '
        'menuFreezeCard
        '
        Me.menuFreezeCard.Name = "menuFreezeCard"
        Me.menuFreezeCard.Size = New System.Drawing.Size(404, 22)
        Me.menuFreezeCard.Text = "冻结/解冻购物卡 &Freeze/unfreeze Card"
        '
        'menuUrgentDeduction
        '
        Me.menuUrgentDeduction.Name = "menuUrgentDeduction"
        Me.menuUrgentDeduction.Size = New System.Drawing.Size(404, 22)
        Me.menuUrgentDeduction.Text = "购物卡紧急扣款  &Urgent Payment Deduction"
        '
        'menuReplaceCard
        '
        Me.menuReplaceCard.Name = "menuReplaceCard"
        Me.menuReplaceCard.Size = New System.Drawing.Size(404, 22)
        Me.menuReplaceCard.Text = "购物卡换卡申请  &Replace Card Requirement"
        '
        'menuReplaceCardValidation
        '
        Me.menuReplaceCardValidation.Name = "menuReplaceCardValidation"
        Me.menuReplaceCardValidation.Size = New System.Drawing.Size(404, 22)
        Me.menuReplaceCardValidation.Text = "购物卡换卡确认  Replace Card &Validation"
        '
        'menuUnchargeCard
        '
        Me.menuUnchargeCard.Name = "menuUnchargeCard"
        Me.menuUnchargeCard.Size = New System.Drawing.Size(404, 22)
        Me.menuUnchargeCard.Text = "购物卡激活撤销申请 Canc&el Card Activation Requirement"
        '
        'menuAffirmUnchargeCard
        '
        Me.menuAffirmUnchargeCard.Name = "menuAffirmUnchargeCard"
        Me.menuAffirmUnchargeCard.Size = New System.Drawing.Size(404, 22)
        Me.menuAffirmUnchargeCard.Text = "购物卡激活撤销确认 Ca&ncel Card Activation Validation"
        '
        'menuUnchargeMKTCard
        '
        Me.menuUnchargeMKTCard.Name = "menuUnchargeMKTCard"
        Me.menuUnchargeMKTCard.Size = New System.Drawing.Size(404, 22)
        Me.menuUnchargeMKTCard.Text = "活动卡激活撤销申请 Cancel &MKT Card Activation Requirement"
        '
        'menuAffirmUnchargeMKTCard
        '
        Me.menuAffirmUnchargeMKTCard.Name = "menuAffirmUnchargeMKTCard"
        Me.menuAffirmUnchargeMKTCard.Size = New System.Drawing.Size(404, 22)
        Me.menuAffirmUnchargeMKTCard.Text = "活动卡激活撤销确认 Cancel M&KT Card Activation Validation"
        '
        'menuGiftCardActivationCancel
        '
        Me.menuGiftCardActivationCancel.Name = "menuGiftCardActivationCancel"
        Me.menuGiftCardActivationCancel.Size = New System.Drawing.Size(404, 22)
        Me.menuGiftCardActivationCancel.Text = "礼品卡激活撤销申请 &Gift Card Activation Cancellation Requirement"
        '
        'menuAffirmGiftCardActivationCancel
        '
        Me.menuAffirmGiftCardActivationCancel.Name = "menuAffirmGiftCardActivationCancel"
        Me.menuAffirmGiftCardActivationCancel.Size = New System.Drawing.Size(404, 22)
        Me.menuAffirmGiftCardActivationCancel.Text = "礼品卡激活撤销确认 G&ift Card Activation Cancellation Validation"
        '
        'menuGiftCardOfflineActivate
        '
        Me.menuGiftCardOfflineActivate.Name = "menuGiftCardOfflineActivate"
        Me.menuGiftCardOfflineActivate.Size = New System.Drawing.Size(404, 22)
        Me.menuGiftCardOfflineActivate.Text = "礼品卡离线激活申请 Gift Card &Off-line Activation Requirement "
        '
        'menuAffirmGiftCardOfflineActivate
        '
        Me.menuAffirmGiftCardOfflineActivate.Name = "menuAffirmGiftCardOfflineActivate"
        Me.menuAffirmGiftCardOfflineActivate.Size = New System.Drawing.Size(404, 22)
        Me.menuAffirmGiftCardOfflineActivate.Text = "礼品卡离线激活确认 Gift Card Off-&line Activation Validation "
        '
        'menuRecycleCard
        '
        Me.menuRecycleCard.Name = "menuRecycleCard"
        Me.menuRecycleCard.Size = New System.Drawing.Size(404, 22)
        Me.menuRecycleCard.Text = "购物卡回收申请 Rec&ycle Card Requirement"
        '
        'menuAffirmRecycleCard
        '
        Me.menuAffirmRecycleCard.Name = "menuAffirmRecycleCard"
        Me.menuAffirmRecycleCard.Size = New System.Drawing.Size(404, 22)
        Me.menuAffirmRecycleCard.Text = "购物卡回收确认 Recy&cle Card Validation"
        '
        'spCULQuery
        '
        Me.spCULQuery.Name = "spCULQuery"
        Me.spCULQuery.Size = New System.Drawing.Size(401, 6)
        '
        'menuCardStateQuery
        '
        Me.menuCardStateQuery.Name = "menuCardStateQuery"
        Me.menuCardStateQuery.Size = New System.Drawing.Size(404, 22)
        Me.menuCardStateQuery.Text = "购物卡状态及交易明细查询  Card S&tatus && Dealing Query"
        '
        'menuCardStateQuery_Section
        '
        Me.menuCardStateQuery_Section.Name = "menuCardStateQuery_Section"
        Me.menuCardStateQuery_Section.Size = New System.Drawing.Size(404, 22)
        Me.menuCardStateQuery_Section.Text = "购物卡状态批量查询  Card St&atus Query"
        '
        'menuSignCardSpecialOperationHead
        '
        Me.menuSignCardSpecialOperationHead.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuSignCardSpecialOperation, Me.menuSignCardReplace})
        Me.menuSignCardSpecialOperationHead.Name = "menuSignCardSpecialOperationHead"
        Me.menuSignCardSpecialOperationHead.Size = New System.Drawing.Size(329, 22)
        Me.menuSignCardSpecialOperationHead.Text = "实名制卡特殊操作 SignCard Special Operation"
        '
        'menuSignCardSpecialOperation
        '
        Me.menuSignCardSpecialOperation.Name = "menuSignCardSpecialOperation"
        Me.menuSignCardSpecialOperation.Size = New System.Drawing.Size(303, 22)
        Me.menuSignCardSpecialOperation.Text = "实名制卡特殊操作 SignCard Special Operation"
        '
        'menuSignCardReplace
        '
        Me.menuSignCardReplace.Name = "menuSignCardReplace"
        Me.menuSignCardReplace.Size = New System.Drawing.Size(303, 22)
        Me.menuSignCardReplace.Text = "实名制卡查询 SignCard Replace"
        '
        'menuInvoiceOperation
        '
        Me.menuInvoiceOperation.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuInvoiceDeviceTesting, Me.menuInvoiceCancellation})
        Me.menuInvoiceOperation.Name = "menuInvoiceOperation"
        Me.menuInvoiceOperation.Size = New System.Drawing.Size(157, 20)
        Me.menuInvoiceOperation.Text = "发票操作-&Invoice Operation"
        '
        'menuInvoiceDeviceTesting
        '
        Me.menuInvoiceDeviceTesting.Name = "menuInvoiceDeviceTesting"
        Me.menuInvoiceDeviceTesting.Size = New System.Drawing.Size(359, 22)
        Me.menuInvoiceDeviceTesting.Text = "开票器设置及测试 Invoice Device Configuration && &Testing"
        '
        'menuInvoiceCancellation
        '
        Me.menuInvoiceCancellation.Name = "menuInvoiceCancellation"
        Me.menuInvoiceCancellation.ShortcutKeys = System.Windows.Forms.Keys.F12
        Me.menuInvoiceCancellation.Size = New System.Drawing.Size(359, 22)
        Me.menuInvoiceCancellation.Text = "发票作废处理 Invoice &Cancellation Operation"
        '
        'menuActivation
        '
        Me.menuActivation.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuCashActivation, Me.menuEmployeeActivation, Me.menuChequeActivation})
        Me.menuActivation.Name = "menuActivation"
        Me.menuActivation.Size = New System.Drawing.Size(149, 20)
        Me.menuActivation.Text = "购物卡激活-Card &Activate"
        '
        'menuCashActivation
        '
        Me.menuCashActivation.Name = "menuCashActivation"
        Me.menuCashActivation.Size = New System.Drawing.Size(331, 22)
        Me.menuCashActivation.Text = "购物卡激活 &Card Activation"
        '
        'menuEmployeeActivation
        '
        Me.menuEmployeeActivation.Name = "menuEmployeeActivation"
        Me.menuEmployeeActivation.Size = New System.Drawing.Size(331, 22)
        Me.menuEmployeeActivation.Text = "员工卡激活 &Employee Card Activation"
        '
        'menuChequeActivation
        '
        Me.menuChequeActivation.Name = "menuChequeActivation"
        Me.menuChequeActivation.Size = New System.Drawing.Size(331, 22)
        Me.menuChequeActivation.Text = """转账/支票""到账确认 &Transfer/Cheque Confirmation"
        '
        'menuReport
        '
        Me.menuReport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuSalesReport, Me.spJVReports, Me.menuJVReport, Me.spBonusReport, Me.menuBonusReporting, Me.spCustomReport, Me.menuCustomExport, Me.spCULReport, Me.menuCULReport})
        Me.menuReport.Name = "menuReport"
        Me.menuReport.Size = New System.Drawing.Size(85, 20)
        Me.menuReport.Text = "报表-&Reports"
        '
        'menuSalesReport
        '
        Me.menuSalesReport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuDailyReport1, Me.menuDailyReport2, Me.menuDailyReport3, Me.menuDailyReport4, Me.menuDailyReport5, Me.menuDailyReport6, Me.ToolStripSeparator1, Me.menuMonthReport1, Me.menuMonthReport2, Me.menuMonthReport3, Me.menuMonthReport4, Me.ToolStripSeparator2, Me.menuYearlyReport, Me.menuDailybyCustomer, Me.menuFishReport})
        Me.menuSalesReport.Name = "menuSalesReport"
        Me.menuSalesReport.Size = New System.Drawing.Size(292, 22)
        Me.menuSalesReport.Text = "销售报表 &Sales Reports"
        '
        'menuDailyReport1
        '
        Me.menuDailyReport1.Name = "menuDailyReport1"
        Me.menuDailyReport1.Size = New System.Drawing.Size(240, 22)
        Me.menuDailyReport1.Text = "Daily Report For Store Level "
        '
        'menuDailyReport2
        '
        Me.menuDailyReport2.Name = "menuDailyReport2"
        Me.menuDailyReport2.Size = New System.Drawing.Size(240, 22)
        Me.menuDailyReport2.Text = "Daily Report For City Level"
        '
        'menuDailyReport3
        '
        Me.menuDailyReport3.Name = "menuDailyReport3"
        Me.menuDailyReport3.Size = New System.Drawing.Size(240, 22)
        Me.menuDailyReport3.Text = "Daily Report For Regional Level"
        '
        'menuDailyReport4
        '
        Me.menuDailyReport4.Name = "menuDailyReport4"
        Me.menuDailyReport4.Size = New System.Drawing.Size(240, 22)
        Me.menuDailyReport4.Text = "Daily Report For Territory Level"
        '
        'menuDailyReport5
        '
        Me.menuDailyReport5.Name = "menuDailyReport5"
        Me.menuDailyReport5.Size = New System.Drawing.Size(240, 22)
        Me.menuDailyReport5.Text = "Daily Report For HO Level"
        '
        'menuDailyReport6
        '
        Me.menuDailyReport6.Name = "menuDailyReport6"
        Me.menuDailyReport6.Size = New System.Drawing.Size(240, 22)
        Me.menuDailyReport6.Text = "Daily Report For HO Level"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(237, 6)
        '
        'menuMonthReport1
        '
        Me.menuMonthReport1.Name = "menuMonthReport1"
        Me.menuMonthReport1.Size = New System.Drawing.Size(240, 22)
        Me.menuMonthReport1.Text = "Monthly Report For City Level"
        '
        'menuMonthReport2
        '
        Me.menuMonthReport2.Name = "menuMonthReport2"
        Me.menuMonthReport2.Size = New System.Drawing.Size(240, 22)
        Me.menuMonthReport2.Text = "Monthly Report For Regional Level"
        '
        'menuMonthReport3
        '
        Me.menuMonthReport3.Name = "menuMonthReport3"
        Me.menuMonthReport3.Size = New System.Drawing.Size(240, 22)
        Me.menuMonthReport3.Text = "Monthly Report For Territory Level"
        '
        'menuMonthReport4
        '
        Me.menuMonthReport4.Name = "menuMonthReport4"
        Me.menuMonthReport4.Size = New System.Drawing.Size(240, 22)
        Me.menuMonthReport4.Text = "Monthly Report For HO Level"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(237, 6)
        '
        'menuYearlyReport
        '
        Me.menuYearlyReport.Name = "menuYearlyReport"
        Me.menuYearlyReport.Size = New System.Drawing.Size(240, 22)
        Me.menuYearlyReport.Text = "Yearly Report by Month"
        '
        'menuDailybyCustomer
        '
        Me.menuDailybyCustomer.Name = "menuDailybyCustomer"
        Me.menuDailybyCustomer.Size = New System.Drawing.Size(240, 22)
        Me.menuDailybyCustomer.Text = "Daily Report by Customer"
        '
        'menuFishReport
        '
        Me.menuFishReport.Name = "menuFishReport"
        Me.menuFishReport.Size = New System.Drawing.Size(240, 22)
        Me.menuFishReport.Text = "Fish Summary Report"
        '
        'spJVReports
        '
        Me.spJVReports.Name = "spJVReports"
        Me.spJVReports.Size = New System.Drawing.Size(289, 6)
        '
        'menuJVReport
        '
        Me.menuJVReport.Name = "menuJVReport"
        Me.menuJVReport.Size = New System.Drawing.Size(292, 22)
        Me.menuJVReport.Text = "JV 报表 &JV Reports"
        '
        'spBonusReport
        '
        Me.spBonusReport.Name = "spBonusReport"
        Me.spBonusReport.Size = New System.Drawing.Size(289, 6)
        '
        'menuBonusReporting
        '
        Me.menuBonusReporting.Enabled = False
        Me.menuBonusReporting.Name = "menuBonusReporting"
        Me.menuBonusReporting.Size = New System.Drawing.Size(292, 22)
        Me.menuBonusReporting.Text = "奖金报表 &Bonus Reports"
        '
        'spCustomReport
        '
        Me.spCustomReport.Name = "spCustomReport"
        Me.spCustomReport.Size = New System.Drawing.Size(289, 6)
        '
        'menuCustomExport
        '
        Me.menuCustomExport.Name = "menuCustomExport"
        Me.menuCustomExport.Size = New System.Drawing.Size(292, 22)
        Me.menuCustomExport.Text = "自定义导出报表  &Custom to Export Reports "
        '
        'spCULReport
        '
        Me.spCULReport.Name = "spCULReport"
        Me.spCULReport.Size = New System.Drawing.Size(289, 6)
        '
        'menuCULReport
        '
        Me.menuCULReport.Name = "menuCULReport"
        Me.menuCULReport.Size = New System.Drawing.Size(292, 22)
        Me.menuCULReport.Text = "银商报表下载 CUL Reports &Download"
        '
        'menuMessage
        '
        Me.menuMessage.Name = "menuMessage"
        Me.menuMessage.Size = New System.Drawing.Size(150, 20)
        Me.menuMessage.Text = "查看消息 Review &Message"
        '
        'menuHotLine
        '
        Me.menuHotLine.Name = "menuHotLine"
        Me.menuHotLine.Size = New System.Drawing.Size(134, 20)
        Me.menuHotLine.Text = "帮助热线-Help Hot Line"
        '
        'menuExitSystem
        '
        Me.menuExitSystem.Name = "menuExitSystem"
        Me.menuExitSystem.Size = New System.Drawing.Size(127, 20)
        Me.menuExitSystem.Text = "退出系统-Exit System"
        '
        'menuElectronicCard
        '
        Me.menuElectronicCard.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuERequirement, Me.menuEQuery, Me.menuEActivationRequirement, Me.menuEActivationValidation, Me.menuEFreezeCard, Me.menuESupplySms, Me.menuECodeDelay})
        Me.menuElectronicCard.Name = "menuElectronicCard"
        Me.menuElectronicCard.Size = New System.Drawing.Size(32, 19)
        '
        'menuERequirement
        '
        Me.menuERequirement.Name = "menuERequirement"
        Me.menuERequirement.Size = New System.Drawing.Size(67, 22)
        '
        'menuEQuery
        '
        Me.menuEQuery.Name = "menuEQuery"
        Me.menuEQuery.Size = New System.Drawing.Size(67, 22)
        '
        'menuEActivationRequirement
        '
        Me.menuEActivationRequirement.Name = "menuEActivationRequirement"
        Me.menuEActivationRequirement.Size = New System.Drawing.Size(67, 22)
        '
        'menuEActivationValidation
        '
        Me.menuEActivationValidation.Name = "menuEActivationValidation"
        Me.menuEActivationValidation.Size = New System.Drawing.Size(67, 22)
        '
        'menuEFreezeCard
        '
        Me.menuEFreezeCard.Name = "menuEFreezeCard"
        Me.menuEFreezeCard.Size = New System.Drawing.Size(67, 22)
        '
        'menuESupplySms
        '
        Me.menuESupplySms.Name = "menuESupplySms"
        Me.menuESupplySms.Size = New System.Drawing.Size(67, 22)
        '
        'menuECodeDelay
        '
        Me.menuECodeDelay.Name = "menuECodeDelay"
        Me.menuECodeDelay.Size = New System.Drawing.Size(67, 22)
        '
        'menuECancelChargeRequirement
        '
        Me.menuECancelChargeRequirement.Name = "menuECancelChargeRequirement"
        Me.menuECancelChargeRequirement.Size = New System.Drawing.Size(67, 22)
        '
        'menuECancelChargeValidation
        '
        Me.menuECancelChargeValidation.Name = "menuECancelChargeValidation"
        Me.menuECancelChargeValidation.Size = New System.Drawing.Size(67, 22)
        '
        'menuECancelExtractingCodeRequirement
        '
        Me.menuECancelExtractingCodeRequirement.Name = "menuECancelExtractingCodeRequirement"
        Me.menuECancelExtractingCodeRequirement.Size = New System.Drawing.Size(67, 22)
        '
        'menuECancelExtractingCodeValidation
        '
        Me.menuECancelExtractingCodeValidation.Name = "menuECancelExtractingCodeValidation"
        Me.menuECancelExtractingCodeValidation.Size = New System.Drawing.Size(67, 22)
        '
        'menuECodeDelayRequirement
        '
        Me.menuECodeDelayRequirement.Name = "menuECodeDelayRequirement"
        Me.menuECodeDelayRequirement.Size = New System.Drawing.Size(67, 22)
        '
        'menuElcSpecialOperation
        '
        Me.menuElcSpecialOperation.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuECancelChargeRequirement, Me.menuECancelChargeValidation, Me.menuECancelExtractingCodeRequirement, Me.menuECancelExtractingCodeValidation, Me.menuECodeDelayRequirement})
        Me.menuElcSpecialOperation.Name = "menuElcSpecialOperation"
        Me.menuElcSpecialOperation.Size = New System.Drawing.Size(32, 19)
        '
        'spCrossContract
        '
        Me.spCrossContract.Name = "spCrossContract"
        Me.spCrossContract.Size = New System.Drawing.Size(326, 6)
        '
        'notifyMessage
        '
        Me.notifyMessage.Icon = CType(resources.GetObject("notifyMessage.Icon"), System.Drawing.Icon)
        Me.notifyMessage.Text = "Message From Shopping Card System"
        '
        'timerMessage
        '
        Me.timerMessage.Interval = 300000
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(790, 534)
        Me.Controls.Add(Me.statusMain)
        Me.Controls.Add(Me.menuMain)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.menuMain
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "家乐福购物卡管理系统"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.statusMain.ResumeLayout(False)
        Me.statusMain.PerformLayout()
        Me.menuMain.ResumeLayout(False)
        Me.menuMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents statusMain As System.Windows.Forms.StatusStrip
    Friend WithEvents statusText As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents statusProgress As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents statusRate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents statusUser As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents statusUserName As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents statusArea As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents statusAreaName As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents statusRole As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents statusRoleName As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents menuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents menuSystem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuRelogin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuActivation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuCashActivation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuChequeActivation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuNavigation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuParameter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuPosition As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuArea As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuUserManagement As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents spBusinessType As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuBusinessType As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents spInvoiceLayout As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuCityConfig As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents spInvoiceItem As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuBonusCalculation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuCardManagement As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuCustomerManagement As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents spContract As System.Windows.Forms.ToolStripSeparator

    'modify code 067:start-------------------------------------------------------------------------
    Friend WithEvents spCrossContract As System.Windows.Forms.ToolStripSeparator
    'modify code 067:end-------------------------------------------------------------------------

    Friend WithEvents spSelling As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuSalesBillManagement As System.Windows.Forms.ToolStripMenuItem
    'modify code 046:start-------------------------------------------------------------------------
    '添加实名制
    Friend WithEvents menuSignCardSelling As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuImportSignCardSalesBill As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuDownloadSignCardSalesBillSellingTemp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuCreateSignCardSalesBillFromFile As System.Windows.Forms.ToolStripMenuItem
    'modify code 046:end-------------------------------------------------------------------------
    Friend WithEvents menuContractManagement As System.Windows.Forms.ToolStripMenuItem

    'modify code 067:start-------------------------------------------------------------------------
    Friend WithEvents menuCrossContractManagement As System.Windows.Forms.ToolStripMenuItem
    'modify code 067:end-------------------------------------------------------------------------

    'modify code 072:start-------------------------------------------------------------------------
    Friend WithEvents menuElectronicCard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuERequirement As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuEQuery As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuEActivationRequirement As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuEActivationValidation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuEFreezeCard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuESupplySms As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuECodeDelay As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuECancelChargeRequirement As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuECancelChargeValidation As System.Windows.Forms.ToolStripMenuItem
    'modify code 072:end--------------------------------------------------------------------------

    'modify code 076:start-------------------------------------------------------------------------
    Friend WithEvents menuECancelExtractingCodeRequirement As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuECancelExtractingCodeValidation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuECodeDelayRequirement As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents menuECodeDelayValidation As System.Windows.Forms.ToolStripMenuItem
    'modify code 076:end--------------------------------------------------------------------------

    'modify code 082:start-------------------------------------------------------------------------
    Friend WithEvents menuElcSpecialOperation As System.Windows.Forms.ToolStripMenuItem
    'modify code 082:end-------------------------------------------------------------------------

    Friend WithEvents spBatchRechargeFromFile As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuCULSpecialOperation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuFreezeCard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuUrgentDeduction As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuReplaceCard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuReplaceCardValidation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuUnchargeCard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuRecycleCard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents spCULQuery As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuCardStateQuery As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents spBonusReport As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuBonusReporting As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents spCard As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuInvoiceItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents spRule As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuPredefineFaceValue As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuCardFee As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuInvoiceLayout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents spBonusCalcultion As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuCreateSalesBillFromFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuSalesBillRecharge As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents spReturnGoods As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuCreateReturnedSalesBill As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents spCUL As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuAffirmUnchargeCard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuAffirmRecycleCard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuSalesReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuDailyReport1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuDailyReport2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuDailyReport3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuDailyReport4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuDailyReport5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuDailyReport6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuMonthReport1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuMonthReport2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuMonthReport3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuMonthReport4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuSwitchMode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuYearlyReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuFishReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuDailybyCustomer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuSmallTool As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents spTool As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuResetCardPassword As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents spCustomReport As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuCustomExport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents spCULReport As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuCULReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuHotLine As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents notifyMessage As System.Windows.Forms.NotifyIcon
    Friend WithEvents timerMessage As System.Windows.Forms.Timer
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuMessage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents spJVReports As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuJVReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuMarketingPromotion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuPRCard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuEmployeeSales As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents spEmployeeQuota As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuEmployeeQuota As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuEmployeeActivation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuExitSystem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuCobrandCard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuGiftCardActivationCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuGiftCardOfflineActivate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuAffirmGiftCardOfflineActivate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuUnchargeMKTCard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuAffirmUnchargeMKTCard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuInvoiceOperation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuInvoiceDeviceTesting As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuInvoiceCancellation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuAffirmGiftCardActivationCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuCardStateQuery_Section As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuInternetSelling As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuInternetSalesInvoice As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuSignCardSpecialOperationHead As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuSignCardSpecialOperation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuSignCardReplace As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuCrossSellingNonRealNameCard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuCrossSellingCityConfig As System.Windows.Forms.ToolStripMenuItem

End Class
