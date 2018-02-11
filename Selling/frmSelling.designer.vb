<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelling
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelling))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.splitLayout = New System.Windows.Forms.SplitContainer
        Me.pnlLeft = New System.Windows.Forms.Panel
        Me.flpLeftContainer = New System.Windows.Forms.FlowLayoutPanel
        Me.grbSalesBillType = New System.Windows.Forms.GroupBox
        Me.cbbSalesBillType = New System.Windows.Forms.ComboBox
        Me.txbSalesBillType = New System.Windows.Forms.TextBox
        Me.flpEmployee = New System.Windows.Forms.FlowLayoutPanel
        Me.grbInputEmployeeNo = New System.Windows.Forms.GroupBox
        Me.txbInputEmployeeNo = New System.Windows.Forms.TextBox
        Me.btnEmployeeNo = New System.Windows.Forms.Button
        Me.grbEmployeeInfo = New System.Windows.Forms.GroupBox
        Me.flpEmployeeInfo = New System.Windows.Forms.FlowLayoutPanel
        Me.pnlEmployeeNo = New System.Windows.Forms.Panel
        Me.txbEmployeeNo = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.pnlEmployeeInfo = New System.Windows.Forms.Panel
        Me.txbEmployeeName = New System.Windows.Forms.TextBox
        Me.txbEmployeeState = New System.Windows.Forms.TextBox
        Me.Label111 = New System.Windows.Forms.Label
        Me.txbLevelName = New System.Windows.Forms.TextBox
        Me.Label82 = New System.Windows.Forms.Label
        Me.Label77 = New System.Windows.Forms.Label
        Me.txbOfficeName = New System.Windows.Forms.TextBox
        Me.txbEmployeeIDNo = New System.Windows.Forms.TextBox
        Me.txbEmployeeIDType = New System.Windows.Forms.TextBox
        Me.Label79 = New System.Windows.Forms.Label
        Me.Label81 = New System.Windows.Forms.Label
        Me.lblEmployeeIDNo = New System.Windows.Forms.Label
        Me.pnlEmployeeTel = New System.Windows.Forms.Panel
        Me.txbEmployeeTel = New System.Windows.Forms.TextBox
        Me.Label83 = New System.Windows.Forms.Label
        Me.grbInputEmployeeTel = New System.Windows.Forms.GroupBox
        Me.txbInputEmployeeTel = New System.Windows.Forms.TextBox
        Me.cbbInputEmployeeTel = New System.Windows.Forms.ComboBox
        Me.grbEmployeeQuota = New System.Windows.Forms.GroupBox
        Me.flpEmployeeQuota = New System.Windows.Forms.FlowLayoutPanel
        Me.pnlQuota = New System.Windows.Forms.Panel
        Me.txbRateQuota = New System.Windows.Forms.TextBox
        Me.txbPurchaseQuota = New System.Windows.Forms.TextBox
        Me.Label88 = New System.Windows.Forms.Label
        Me.txbRebateQuota = New System.Windows.Forms.TextBox
        Me.Label87 = New System.Windows.Forms.Label
        Me.Label86 = New System.Windows.Forms.Label
        Me.Label85 = New System.Windows.Forms.Label
        Me.Label90 = New System.Windows.Forms.Label
        Me.Label84 = New System.Windows.Forms.Label
        Me.Label89 = New System.Windows.Forms.Label
        Me.pnlUsedQuota = New System.Windows.Forms.Panel
        Me.txbUsedRebateQuota = New System.Windows.Forms.TextBox
        Me.txbUsedPurchaseQuota = New System.Windows.Forms.TextBox
        Me.Label95 = New System.Windows.Forms.Label
        Me.Label94 = New System.Windows.Forms.Label
        Me.Label93 = New System.Windows.Forms.Label
        Me.Label92 = New System.Windows.Forms.Label
        Me.Label91 = New System.Windows.Forms.Label
        Me.tlpAvailableQuota = New System.Windows.Forms.TableLayoutPanel
        Me.pnlAvailableRebateQuota = New System.Windows.Forms.Panel
        Me.txbAvailableRebateQuota = New System.Windows.Forms.TextBox
        Me.Label80 = New System.Windows.Forms.Label
        Me.Label112 = New System.Windows.Forms.Label
        Me.pnlMaxAvailableQuota = New System.Windows.Forms.Panel
        Me.txbMaxAvailableRebateQuota = New System.Windows.Forms.TextBox
        Me.txbMaxAvailablePurchaseQuota = New System.Windows.Forms.TextBox
        Me.Label100 = New System.Windows.Forms.Label
        Me.Label99 = New System.Windows.Forms.Label
        Me.Label98 = New System.Windows.Forms.Label
        Me.Label97 = New System.Windows.Forms.Label
        Me.Label96 = New System.Windows.Forms.Label
        Me.tlpDistributedQuota = New System.Windows.Forms.TableLayoutPanel
        Me.pnlDistributedBalanceRebateQuota = New System.Windows.Forms.Panel
        Me.txbDistributedBalanceRebateQuota = New System.Windows.Forms.TextBox
        Me.Label107 = New System.Windows.Forms.Label
        Me.Label109 = New System.Windows.Forms.Label
        Me.pnlDistributedQuota = New System.Windows.Forms.Panel
        Me.txbDistributedRebateQuota = New System.Windows.Forms.TextBox
        Me.txbDistributedPurchaseQuota = New System.Windows.Forms.TextBox
        Me.Label105 = New System.Windows.Forms.Label
        Me.Label104 = New System.Windows.Forms.Label
        Me.Label103 = New System.Windows.Forms.Label
        Me.Label102 = New System.Windows.Forms.Label
        Me.Label101 = New System.Windows.Forms.Label
        Me.tlpBalanceQuota = New System.Windows.Forms.TableLayoutPanel
        Me.pnlBalanceRebateQuota = New System.Windows.Forms.Panel
        Me.txbBalanceRebateQuota = New System.Windows.Forms.TextBox
        Me.Label110 = New System.Windows.Forms.Label
        Me.Label114 = New System.Windows.Forms.Label
        Me.Label106 = New System.Windows.Forms.Label
        Me.pnlBalancePurchaseQuota = New System.Windows.Forms.Panel
        Me.txbBalancePurchaseQuota = New System.Windows.Forms.TextBox
        Me.Label113 = New System.Windows.Forms.Label
        Me.Label108 = New System.Windows.Forms.Label
        Me.grbPromotionInfo = New System.Windows.Forms.GroupBox
        Me.pnlPromotionPeriod = New System.Windows.Forms.Panel
        Me.pnlPromotionEndDate = New System.Windows.Forms.Panel
        Me.pnlPromotionStartDate = New System.Windows.Forms.Panel
        Me.dtpPromotionEndDate = New System.Windows.Forms.DateTimePicker
        Me.dtpPromotionStartDate = New System.Windows.Forms.DateTimePicker
        Me.Label75 = New System.Windows.Forms.Label
        Me.Label74 = New System.Windows.Forms.Label
        Me.Label72 = New System.Windows.Forms.Label
        Me.txbPromotionTitle = New System.Windows.Forms.TextBox
        Me.pnlPromotionPeriodReadOnly = New System.Windows.Forms.Panel
        Me.txbPromotionEndDate = New System.Windows.Forms.TextBox
        Me.txbPromotionStartDate = New System.Windows.Forms.TextBox
        Me.Label76 = New System.Windows.Forms.Label
        Me.grbCustomer = New System.Windows.Forms.GroupBox
        Me.flpCustomer = New System.Windows.Forms.FlowLayoutPanel
        Me.pnlSelectStore = New System.Windows.Forms.Panel
        Me.Label59 = New System.Windows.Forms.Label
        Me.cbbSelectStore = New System.Windows.Forms.ComboBox
        Me.pnlCustomerType = New System.Windows.Forms.Panel
        Me.Label119 = New System.Windows.Forms.Label
        Me.cbbCustomerType = New System.Windows.Forms.ComboBox
        Me.pnlCompanyCustomer = New System.Windows.Forms.Panel
        Me.txbCompanyCredentialsNo = New System.Windows.Forms.TextBox
        Me.Label116 = New System.Windows.Forms.Label
        Me.cbbCompanyCredentialsType = New System.Windows.Forms.ComboBox
        Me.txbCompanyCredentialsType = New System.Windows.Forms.TextBox
        Me.lblCustomerName = New System.Windows.Forms.Label
        Me.txbCustomerName = New System.Windows.Forms.TextBox
        Me.cbbCustomerName = New System.Windows.Forms.ComboBox
        Me.Label115 = New System.Windows.Forms.Label
        Me.pnlCustomerButtons = New System.Windows.Forms.Panel
        Me.btnViewCustomer = New System.Windows.Forms.Button
        Me.btnNewCustomer = New System.Windows.Forms.Button
        Me.grbAvailablePayer = New System.Windows.Forms.GroupBox
        Me.cbbAvailablePayer = New System.Windows.Forms.ComboBox
        Me.Label78 = New System.Windows.Forms.Label
        Me.grbBuyerInfo = New System.Windows.Forms.GroupBox
        Me.pnlBuyerName = New System.Windows.Forms.Panel
        Me.txbTelMP = New System.Windows.Forms.TextBox
        Me.txbBuyerName = New System.Windows.Forms.TextBox
        Me.cbbBuyerName = New System.Windows.Forms.ComboBox
        Me.cbbTelMP = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.pnlBuyerCredentials = New System.Windows.Forms.Panel
        Me.txbBuyerCredentialsNo = New System.Windows.Forms.TextBox
        Me.Label118 = New System.Windows.Forms.Label
        Me.cbbBuyerCredentialsType = New System.Windows.Forms.ComboBox
        Me.txbBuyerCredentialsType = New System.Windows.Forms.TextBox
        Me.Label117 = New System.Windows.Forms.Label
        Me.grbMemberInfo = New System.Windows.Forms.GroupBox
        Me.txbOldMemberCardNo = New System.Windows.Forms.TextBox
        Me.txbNewMemberCardNo = New System.Windows.Forms.TextBox
        Me.txbMemberAddress = New System.Windows.Forms.TextBox
        Me.txbMemberTel = New System.Windows.Forms.TextBox
        Me.txbMemberIDNo = New System.Windows.Forms.TextBox
        Me.Label121 = New System.Windows.Forms.Label
        Me.txbMemberName = New System.Windows.Forms.TextBox
        Me.Label125 = New System.Windows.Forms.Label
        Me.Label124 = New System.Windows.Forms.Label
        Me.Label123 = New System.Windows.Forms.Label
        Me.Label120 = New System.Windows.Forms.Label
        Me.Label122 = New System.Windows.Forms.Label
        Me.grbBalanceContract = New System.Windows.Forms.GroupBox
        Me.flpBalanceContract = New System.Windows.Forms.FlowLayoutPanel
        Me.pnlPreviousDistribution = New System.Windows.Forms.Panel
        Me.txbPreviousDistribution = New System.Windows.Forms.TextBox
        Me.Label68 = New System.Windows.Forms.Label
        Me.Label69 = New System.Windows.Forms.Label
        Me.pnlPreviousBalance = New System.Windows.Forms.Panel
        Me.txbPreviousBalance = New System.Windows.Forms.TextBox
        Me.Label70 = New System.Windows.Forms.Label
        Me.Label71 = New System.Windows.Forms.Label
        Me.txbBalanceContractBalanceRebateAMT = New System.Windows.Forms.TextBox
        Me.Label66 = New System.Windows.Forms.Label
        Me.Label67 = New System.Windows.Forms.Label
        Me.txbBalanceContractCode = New System.Windows.Forms.TextBox
        Me.btnViewBalanceContract = New System.Windows.Forms.Button
        Me.Label62 = New System.Windows.Forms.Label
        Me.lblBalanceContract = New System.Windows.Forms.Label
        Me.chbBalanceContract = New System.Windows.Forms.CheckBox
        Me.grbContract = New System.Windows.Forms.GroupBox
        Me.flpContract = New System.Windows.Forms.FlowLayoutPanel
        Me.pnlThisPurchaseRebate = New System.Windows.Forms.Panel
        Me.pnlThisPurchaseRemarks = New System.Windows.Forms.Panel
        Me.lblThisPurchaseRemarks = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.txbThisRebateAMT = New System.Windows.Forms.TextBox
        Me.txbThisRebateRate = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.txbThisSalesAMT = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.lblThisRebateAMT = New System.Windows.Forms.Label
        Me.lblThisPurchaseRebate = New System.Windows.Forms.Label
        Me.lblThisRebateRate = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.lblThisSalesAMT = New System.Windows.Forms.Label
        Me.pnlHistoryPurchaseRebate = New System.Windows.Forms.Panel
        Me.Label44 = New System.Windows.Forms.Label
        Me.txbHistoryPaidRebateAMT = New System.Windows.Forms.TextBox
        Me.lblHistoryPaidRebateAMT = New System.Windows.Forms.Label
        Me.pnlHistoryPurchaseRemarks = New System.Windows.Forms.Panel
        Me.lblHistoryPurchaseRemarks = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.txbHistoryRebateAMT = New System.Windows.Forms.TextBox
        Me.txbHistoryRebateRate = New System.Windows.Forms.TextBox
        Me.Label37 = New System.Windows.Forms.Label
        Me.txbHistorySalesAMT = New System.Windows.Forms.TextBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.lblHistoryRebateAMT = New System.Windows.Forms.Label
        Me.lblHistoryPurchaseRebate = New System.Windows.Forms.Label
        Me.lblHistoryRebateRate = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.lblHistorySalesAMT = New System.Windows.Forms.Label
        Me.pnlAvailableRebateSalesAMT = New System.Windows.Forms.Panel
        Me.txbAvailableRebateSalesAMT = New System.Windows.Forms.TextBox
        Me.lblAvailableRebateAMT = New System.Windows.Forms.Label
        Me.Label46 = New System.Windows.Forms.Label
        Me.pnlRebatSalesAMT = New System.Windows.Forms.Panel
        Me.txbRebateSalesAMT = New System.Windows.Forms.TextBox
        Me.lblRebateSalesAMT = New System.Windows.Forms.Label
        Me.Label48 = New System.Windows.Forms.Label
        Me.pnlBalanceRebateAMT = New System.Windows.Forms.Panel
        Me.txbBalanceRebateAMT = New System.Windows.Forms.TextBox
        Me.lblBalanceRebateAMT = New System.Windows.Forms.Label
        Me.Label50 = New System.Windows.Forms.Label
        Me.txbContractCode = New System.Windows.Forms.TextBox
        Me.btnViewContract = New System.Windows.Forms.Button
        Me.Label26 = New System.Windows.Forms.Label
        Me.lblContract = New System.Windows.Forms.Label
        Me.chbContract = New System.Windows.Forms.CheckBox
        Me.grbNormalRebate = New System.Windows.Forms.GroupBox
        Me.flpNormalRebate = New System.Windows.Forms.FlowLayoutPanel
        Me.pnlMaxNormalRebateCalculation = New System.Windows.Forms.Panel
        Me.txbMaxNormalRebateAMT = New System.Windows.Forms.TextBox
        Me.txbMaxNormalRebateRate = New System.Windows.Forms.TextBox
        Me.Label43 = New System.Windows.Forms.Label
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label45 = New System.Windows.Forms.Label
        Me.pnlNormalRebate = New System.Windows.Forms.Panel
        Me.txbNormalRebateAMT = New System.Windows.Forms.TextBox
        Me.txbNormalRebateRate = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.pnlNormalRebateState = New System.Windows.Forms.Panel
        Me.lblNormalRebateState = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.pnlNormalRebateRemarks = New System.Windows.Forms.Panel
        Me.lblNormalRebateRemarks = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.pnlDistributionNormalRebateAMT = New System.Windows.Forms.Panel
        Me.txbDistributionNormalRebateAMT = New System.Windows.Forms.TextBox
        Me.Label49 = New System.Windows.Forms.Label
        Me.Label51 = New System.Windows.Forms.Label
        Me.pnlBalanceNormalRebateAMT = New System.Windows.Forms.Panel
        Me.txbBalanceNormalRebateAMT = New System.Windows.Forms.TextBox
        Me.Label52 = New System.Windows.Forms.Label
        Me.Label53 = New System.Windows.Forms.Label
        Me.pnlModifyNormalRebate = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnModifyNormalRebate = New System.Windows.Forms.Button
        Me.Label22 = New System.Windows.Forms.Label
        Me.lblNormalRebate = New System.Windows.Forms.Label
        Me.chbNormalRebate = New System.Windows.Forms.CheckBox
        Me.btnViewCityRule = New System.Windows.Forms.Button
        Me.grbPrintDiscount = New System.Windows.Forms.GroupBox
        Me.lblPrintDiscount = New System.Windows.Forms.Label
        Me.chbPrintDiscount = New System.Windows.Forms.CheckBox
        Me.grbSalesBillSummary = New System.Windows.Forms.GroupBox
        Me.flpSalesBillSummary = New System.Windows.Forms.FlowLayoutPanel
        Me.Panel10 = New System.Windows.Forms.Panel
        Me.txbCardQTY = New System.Windows.Forms.TextBox
        Me.txbChargedAMT = New System.Windows.Forms.TextBox
        Me.Label54 = New System.Windows.Forms.Label
        Me.Label55 = New System.Windows.Forms.Label
        Me.Label61 = New System.Windows.Forms.Label
        Me.Label60 = New System.Windows.Forms.Label
        Me.pnlActivationSummary = New System.Windows.Forms.Panel
        Me.txbInactiveAMT = New System.Windows.Forms.TextBox
        Me.txbActiveAMT = New System.Windows.Forms.TextBox
        Me.Label57 = New System.Windows.Forms.Label
        Me.Label56 = New System.Windows.Forms.Label
        Me.Label58 = New System.Windows.Forms.Label
        Me.Label63 = New System.Windows.Forms.Label
        Me.Panel17 = New System.Windows.Forms.Panel
        Me.txbPaymentAMT = New System.Windows.Forms.TextBox
        Me.Label65 = New System.Windows.Forms.Label
        Me.Label64 = New System.Windows.Forms.Label
        Me.pnlCardCost = New System.Windows.Forms.Panel
        Me.txbCardCost = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.grbSalesBillInfo = New System.Windows.Forms.GroupBox
        Me.lblCreatorName = New System.Windows.Forms.Label
        Me.lblCreatedTime = New System.Windows.Forms.Label
        Me.lblSalesBillCode = New System.Windows.Forms.Label
        Me.lblSalesBillState = New System.Windows.Forms.Label
        Me.pnlSalesBillStateDescription = New System.Windows.Forms.Panel
        Me.lblSalesBillRemarks = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.pnlAddjustSalesman = New System.Windows.Forms.Panel
        Me.btnAddjustSalesman = New System.Windows.Forms.Button
        Me.tlpLeft = New System.Windows.Forms.TableLayoutPanel
        Me.Panel9 = New System.Windows.Forms.Panel
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.flpContainer = New System.Windows.Forms.FlowLayoutPanel
        Me.splitRight = New System.Windows.Forms.SplitContainer
        Me.pnlRight = New System.Windows.Forms.Panel
        Me.splitList = New System.Windows.Forms.SplitContainer
        Me.pnlImportedFile = New System.Windows.Forms.Panel
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel
        Me.Label28 = New System.Windows.Forms.Label
        Me.lblSourceFile = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.lblViewImportedResult = New System.Windows.Forms.Label
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.dgvNormalCard = New System.Windows.Forms.DataGridView
        Me.pnlDeductionAMT = New System.Windows.Forms.Panel
        Me.Label18 = New System.Windows.Forms.Label
        Me.lblDeductionAMT = New System.Windows.Forms.Label
        Me.lblNormalListTitle = New System.Windows.Forms.Label
        Me.lblNormalCardSummary = New System.Windows.Forms.Label
        Me.lblRebateCardSummary = New System.Windows.Forms.Label
        Me.dgvRebateCard = New System.Windows.Forms.DataGridView
        Me.Label24 = New System.Windows.Forms.Label
        Me.tlpRight = New System.Windows.Forms.TableLayoutPanel
        Me.Panel22 = New System.Windows.Forms.Panel
        Me.Panel24 = New System.Windows.Forms.Panel
        Me.Panel25 = New System.Windows.Forms.Panel
        Me.Panel26 = New System.Windows.Forms.Panel
        Me.Panel27 = New System.Windows.Forms.Panel
        Me.Panel28 = New System.Windows.Forms.Panel
        Me.Panel29 = New System.Windows.Forms.Panel
        Me.Panel30 = New System.Windows.Forms.Panel
        Me.Panel31 = New System.Windows.Forms.Panel
        Me.Panel41 = New System.Windows.Forms.Panel
        Me.pnlFunction = New System.Windows.Forms.Panel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel42 = New System.Windows.Forms.Panel
        Me.btnConfigApplicationForm = New System.Windows.Forms.Button
        Me.btnPrintApplicationForm = New System.Windows.Forms.Button
        Me.btnNewSalesBill = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnViewActivation = New System.Windows.Forms.Button
        Me.Panel18 = New System.Windows.Forms.Panel
        Me.btnConfigInvoice = New System.Windows.Forms.Button
        Me.btnPrintInvoice = New System.Windows.Forms.Button
        Me.Panel23 = New System.Windows.Forms.Panel
        Me.btnConfigTicket = New System.Windows.Forms.Button
        Me.btnPrintTicket = New System.Windows.Forms.Button
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel11 = New System.Windows.Forms.Panel
        Me.Panel12 = New System.Windows.Forms.Panel
        Me.Panel13 = New System.Windows.Forms.Panel
        Me.Panel14 = New System.Windows.Forms.Panel
        Me.Panel15 = New System.Windows.Forms.Panel
        Me.Panel16 = New System.Windows.Forms.Panel
        Me.Panel19 = New System.Windows.Forms.Panel
        Me.Panel20 = New System.Windows.Forms.Panel
        Me.Panel21 = New System.Windows.Forms.Panel
        Me.pnlBottom = New System.Windows.Forms.Panel
        Me.pnlNormalPayment = New System.Windows.Forms.Panel
        Me.tlpPayment = New System.Windows.Forms.TableLayoutPanel
        Me.lblTotalPayAmtTitle = New System.Windows.Forms.Label
        Me.lblTotalPayAmt = New System.Windows.Forms.Label
        Me.lblTotalPayAmtUnit = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblPayable = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.lblPaid = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblUnpaidTitle = New System.Windows.Forms.Label
        Me.lblUnpaid = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.btnModifyPaymentInfo = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.dgvPayment = New System.Windows.Forms.DataGridView
        Me.pnlBalanceContractPayment = New System.Windows.Forms.Panel
        Me.Label73 = New System.Windows.Forms.Label
        Me.pnlReturnPayment = New System.Windows.Forms.Panel
        Me.txbRefundNo = New System.Windows.Forms.TextBox
        Me.dtpRefundDate = New System.Windows.Forms.DateTimePicker
        Me.Label47 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.lblRefundTitle = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.txbRefundDate = New System.Windows.Forms.TextBox
        Me.tlpBottom = New System.Windows.Forms.TableLayoutPanel
        Me.Panel32 = New System.Windows.Forms.Panel
        Me.Panel33 = New System.Windows.Forms.Panel
        Me.Panel34 = New System.Windows.Forms.Panel
        Me.Panel35 = New System.Windows.Forms.Panel
        Me.Panel36 = New System.Windows.Forms.Panel
        Me.Panel37 = New System.Windows.Forms.Panel
        Me.Panel38 = New System.Windows.Forms.Panel
        Me.Panel39 = New System.Windows.Forms.Panel
        Me.Panel40 = New System.Windows.Forms.Panel
        Me.theTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.theTimer = New System.Windows.Forms.Timer(Me.components)
        Me.cmenuDeleteNormalCard = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.menuDeleteNormalCard = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenuDeleteRebateCard = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.menuDeleteRebateCard = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenuDeletePayment = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.menuDeletePayment = New System.Windows.Forms.ToolStripMenuItem
        Me.pnlSelectablePayment = New System.Windows.Forms.Panel
        Me.dgvSelectablePayment = New System.Windows.Forms.DataGridView
        Me.cmenuCardCost = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.pcbSelectablPayment = New System.Windows.Forms.PictureBox

        'modify code 075:start-------------------------------------------------------------------------
        Me.btnCheckCUL = New System.Windows.Forms.Button
        'modify code 075:end-------------------------------------------------------------------------

        Me.splitLayout.Panel1.SuspendLayout()
        Me.splitLayout.Panel2.SuspendLayout()
        Me.splitLayout.SuspendLayout()
        Me.pnlLeft.SuspendLayout()
        Me.flpLeftContainer.SuspendLayout()
        Me.grbSalesBillType.SuspendLayout()
        Me.flpEmployee.SuspendLayout()
        Me.grbInputEmployeeNo.SuspendLayout()
        Me.grbEmployeeInfo.SuspendLayout()
        Me.flpEmployeeInfo.SuspendLayout()
        Me.pnlEmployeeNo.SuspendLayout()
        Me.pnlEmployeeInfo.SuspendLayout()
        Me.pnlEmployeeTel.SuspendLayout()
        Me.grbInputEmployeeTel.SuspendLayout()
        Me.grbEmployeeQuota.SuspendLayout()
        Me.flpEmployeeQuota.SuspendLayout()
        Me.pnlQuota.SuspendLayout()
        Me.pnlUsedQuota.SuspendLayout()
        Me.tlpAvailableQuota.SuspendLayout()
        Me.pnlAvailableRebateQuota.SuspendLayout()
        Me.pnlMaxAvailableQuota.SuspendLayout()
        Me.tlpDistributedQuota.SuspendLayout()
        Me.pnlDistributedBalanceRebateQuota.SuspendLayout()
        Me.pnlDistributedQuota.SuspendLayout()
        Me.tlpBalanceQuota.SuspendLayout()
        Me.pnlBalanceRebateQuota.SuspendLayout()
        Me.pnlBalancePurchaseQuota.SuspendLayout()
        Me.grbPromotionInfo.SuspendLayout()
        Me.pnlPromotionPeriod.SuspendLayout()
        Me.pnlPromotionPeriodReadOnly.SuspendLayout()
        Me.grbCustomer.SuspendLayout()
        Me.flpCustomer.SuspendLayout()
        Me.pnlSelectStore.SuspendLayout()
        Me.pnlCustomerType.SuspendLayout()
        Me.pnlCompanyCustomer.SuspendLayout()
        Me.pnlCustomerButtons.SuspendLayout()
        Me.grbAvailablePayer.SuspendLayout()
        Me.grbBuyerInfo.SuspendLayout()
        Me.pnlBuyerName.SuspendLayout()
        Me.pnlBuyerCredentials.SuspendLayout()
        Me.grbMemberInfo.SuspendLayout()
        Me.grbBalanceContract.SuspendLayout()
        Me.flpBalanceContract.SuspendLayout()
        Me.pnlPreviousDistribution.SuspendLayout()
        Me.pnlPreviousBalance.SuspendLayout()
        Me.grbContract.SuspendLayout()
        Me.flpContract.SuspendLayout()
        Me.pnlThisPurchaseRebate.SuspendLayout()
        Me.pnlThisPurchaseRemarks.SuspendLayout()
        Me.pnlHistoryPurchaseRebate.SuspendLayout()
        Me.pnlHistoryPurchaseRemarks.SuspendLayout()
        Me.pnlAvailableRebateSalesAMT.SuspendLayout()
        Me.pnlRebatSalesAMT.SuspendLayout()
        Me.pnlBalanceRebateAMT.SuspendLayout()
        Me.grbNormalRebate.SuspendLayout()
        Me.flpNormalRebate.SuspendLayout()
        Me.pnlMaxNormalRebateCalculation.SuspendLayout()
        Me.pnlNormalRebate.SuspendLayout()
        Me.pnlNormalRebateState.SuspendLayout()
        Me.pnlNormalRebateRemarks.SuspendLayout()
        Me.pnlDistributionNormalRebateAMT.SuspendLayout()
        Me.pnlBalanceNormalRebateAMT.SuspendLayout()
        Me.pnlModifyNormalRebate.SuspendLayout()
        Me.grbPrintDiscount.SuspendLayout()
        Me.grbSalesBillSummary.SuspendLayout()
        Me.flpSalesBillSummary.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.pnlActivationSummary.SuspendLayout()
        Me.Panel17.SuspendLayout()
        Me.pnlCardCost.SuspendLayout()
        Me.grbSalesBillInfo.SuspendLayout()
        Me.pnlSalesBillStateDescription.SuspendLayout()
        Me.pnlAddjustSalesman.SuspendLayout()
        Me.tlpLeft.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.splitRight.Panel1.SuspendLayout()
        Me.splitRight.Panel2.SuspendLayout()
        Me.splitRight.SuspendLayout()
        Me.pnlRight.SuspendLayout()
        Me.splitList.Panel1.SuspendLayout()
        Me.splitList.Panel2.SuspendLayout()
        Me.splitList.SuspendLayout()
        Me.pnlImportedFile.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.dgvNormalCard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDeductionAMT.SuspendLayout()
        CType(Me.dgvRebateCard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpRight.SuspendLayout()
        Me.Panel41.SuspendLayout()
        Me.pnlFunction.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel42.SuspendLayout()
        Me.Panel18.SuspendLayout()
        Me.Panel23.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
        Me.pnlNormalPayment.SuspendLayout()
        Me.tlpPayment.SuspendLayout()
        CType(Me.dgvPayment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBalanceContractPayment.SuspendLayout()
        Me.pnlReturnPayment.SuspendLayout()
        Me.tlpBottom.SuspendLayout()
        Me.cmenuDeleteNormalCard.SuspendLayout()
        Me.cmenuDeleteRebateCard.SuspendLayout()
        Me.cmenuDeletePayment.SuspendLayout()
        Me.pnlSelectablePayment.SuspendLayout()
        CType(Me.dgvSelectablePayment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcbSelectablPayment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'splitLayout
        '
        Me.splitLayout.BackColor = System.Drawing.SystemColors.Window
        Me.splitLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitLayout.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.splitLayout.IsSplitterFixed = True
        Me.splitLayout.Location = New System.Drawing.Point(0, 0)
        Me.splitLayout.Margin = New System.Windows.Forms.Padding(0)
        Me.splitLayout.Name = "splitLayout"
        '
        'splitLayout.Panel1
        '
        Me.splitLayout.Panel1.BackColor = System.Drawing.SystemColors.Window
        Me.splitLayout.Panel1.Controls.Add(Me.pnlLeft)
        Me.splitLayout.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        'splitLayout.Panel2
        '
        Me.splitLayout.Panel2.Controls.Add(Me.splitRight)
        Me.splitLayout.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.splitLayout.Size = New System.Drawing.Size(972, 690)
        Me.splitLayout.SplitterDistance = 264
        Me.splitLayout.SplitterWidth = 1
        Me.splitLayout.TabIndex = 0
        '
        'pnlLeft
        '
        Me.pnlLeft.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlLeft.Controls.Add(Me.flpLeftContainer)
        Me.pnlLeft.Controls.Add(Me.tlpLeft)
        Me.pnlLeft.Location = New System.Drawing.Point(11, 11)
        Me.pnlLeft.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlLeft.Name = "pnlLeft"
        Me.pnlLeft.Size = New System.Drawing.Size(245, 667)
        Me.pnlLeft.TabIndex = 0
        '
        'flpLeftContainer
        '
        Me.flpLeftContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flpLeftContainer.AutoScroll = True
        Me.flpLeftContainer.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.flpLeftContainer.Controls.Add(Me.grbSalesBillType)
        Me.flpLeftContainer.Controls.Add(Me.flpEmployee)
        Me.flpLeftContainer.Controls.Add(Me.grbPromotionInfo)
        Me.flpLeftContainer.Controls.Add(Me.grbCustomer)
        Me.flpLeftContainer.Controls.Add(Me.grbAvailablePayer)
        Me.flpLeftContainer.Controls.Add(Me.grbBuyerInfo)
        Me.flpLeftContainer.Controls.Add(Me.grbMemberInfo)
        Me.flpLeftContainer.Controls.Add(Me.grbBalanceContract)
        Me.flpLeftContainer.Controls.Add(Me.grbContract)
        Me.flpLeftContainer.Controls.Add(Me.grbNormalRebate)
        Me.flpLeftContainer.Controls.Add(Me.grbPrintDiscount)
        Me.flpLeftContainer.Controls.Add(Me.grbSalesBillSummary)
        Me.flpLeftContainer.Controls.Add(Me.grbSalesBillInfo)
        Me.flpLeftContainer.Controls.Add(Me.pnlAddjustSalesman)

        'modify code 075:start-------------------------------------------------------------------------
        Me.flpLeftContainer.Controls.Add(Me.btnCheckCUL)
        'modify code 075:end-------------------------------------------------------------------------

        Me.flpLeftContainer.Location = New System.Drawing.Point(13, 13)
        Me.flpLeftContainer.Name = "flpLeftContainer"
        Me.flpLeftContainer.Size = New System.Drawing.Size(219, 639)
        Me.flpLeftContainer.TabIndex = 1
        '
        'grbSalesBillType
        '
        Me.grbSalesBillType.Controls.Add(Me.cbbSalesBillType)
        Me.grbSalesBillType.Controls.Add(Me.txbSalesBillType)
        Me.grbSalesBillType.Location = New System.Drawing.Point(0, 0)
        Me.grbSalesBillType.Margin = New System.Windows.Forms.Padding(0)
        Me.grbSalesBillType.Name = "grbSalesBillType"
        Me.grbSalesBillType.Size = New System.Drawing.Size(193, 50)
        Me.grbSalesBillType.TabIndex = 0
        Me.grbSalesBillType.TabStop = False
        Me.grbSalesBillType.Text = "请选择销售单类型："
        '
        'cbbSalesBillType
        '
        Me.cbbSalesBillType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbSalesBillType.FormattingEnabled = True
        Me.cbbSalesBillType.Items.AddRange(New Object() {"一般销售单"})
        Me.cbbSalesBillType.Location = New System.Drawing.Point(9, 18)
        Me.cbbSalesBillType.MaxLength = 27
        Me.cbbSalesBillType.Name = "cbbSalesBillType"
        Me.cbbSalesBillType.Size = New System.Drawing.Size(174, 20)
        Me.cbbSalesBillType.TabIndex = 1
        '
        'txbSalesBillType
        '
        Me.txbSalesBillType.Location = New System.Drawing.Point(9, 18)
        Me.txbSalesBillType.Name = "txbSalesBillType"
        Me.txbSalesBillType.ReadOnly = True
        Me.txbSalesBillType.Size = New System.Drawing.Size(174, 21)
        Me.txbSalesBillType.TabIndex = 0
        Me.txbSalesBillType.Text = "一般销售单"
        Me.txbSalesBillType.Visible = False
        '
        'flpEmployee
        '
        Me.flpEmployee.AutoSize = True
        Me.flpEmployee.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpEmployee.Controls.Add(Me.grbInputEmployeeNo)
        Me.flpEmployee.Controls.Add(Me.grbEmployeeInfo)
        Me.flpEmployee.Controls.Add(Me.grbInputEmployeeTel)
        Me.flpEmployee.Controls.Add(Me.grbEmployeeQuota)
        Me.flpEmployee.Location = New System.Drawing.Point(0, 50)
        Me.flpEmployee.Margin = New System.Windows.Forms.Padding(0)
        Me.flpEmployee.Name = "flpEmployee"
        Me.flpEmployee.Size = New System.Drawing.Size(193, 846)
        Me.flpEmployee.TabIndex = 1
        '
        'grbInputEmployeeNo
        '
        Me.grbInputEmployeeNo.Controls.Add(Me.txbInputEmployeeNo)
        Me.grbInputEmployeeNo.Controls.Add(Me.btnEmployeeNo)
        Me.grbInputEmployeeNo.Location = New System.Drawing.Point(0, 6)
        Me.grbInputEmployeeNo.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Me.grbInputEmployeeNo.Name = "grbInputEmployeeNo"
        Me.grbInputEmployeeNo.Size = New System.Drawing.Size(193, 50)
        Me.grbInputEmployeeNo.TabIndex = 0
        Me.grbInputEmployeeNo.TabStop = False
        Me.grbInputEmployeeNo.Text = "请输入员工编号："
        '
        'txbInputEmployeeNo
        '
        Me.txbInputEmployeeNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txbInputEmployeeNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbInputEmployeeNo.Location = New System.Drawing.Point(9, 18)
        Me.txbInputEmployeeNo.MaxLength = 10
        Me.txbInputEmployeeNo.Name = "txbInputEmployeeNo"
        Me.txbInputEmployeeNo.Size = New System.Drawing.Size(122, 21)
        Me.txbInputEmployeeNo.TabIndex = 1
        Me.txbInputEmployeeNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnEmployeeNo
        '
        Me.btnEmployeeNo.Enabled = False
        Me.btnEmployeeNo.Location = New System.Drawing.Point(135, 17)
        Me.btnEmployeeNo.Name = "btnEmployeeNo"
        Me.btnEmployeeNo.Size = New System.Drawing.Size(48, 23)
        Me.btnEmployeeNo.TabIndex = 2
        Me.btnEmployeeNo.UseVisualStyleBackColor = True
        '
        'grbEmployeeInfo
        '
        Me.grbEmployeeInfo.Controls.Add(Me.flpEmployeeInfo)
        Me.grbEmployeeInfo.Location = New System.Drawing.Point(0, 62)
        Me.grbEmployeeInfo.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Me.grbEmployeeInfo.Name = "grbEmployeeInfo"
        Me.grbEmployeeInfo.Size = New System.Drawing.Size(193, 271)
        Me.grbEmployeeInfo.TabIndex = 1
        Me.grbEmployeeInfo.TabStop = False
        Me.grbEmployeeInfo.Text = "请核对员工信息："
        '
        'flpEmployeeInfo
        '
        Me.flpEmployeeInfo.AutoSize = True
        Me.flpEmployeeInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpEmployeeInfo.Controls.Add(Me.pnlEmployeeNo)
        Me.flpEmployeeInfo.Controls.Add(Me.pnlEmployeeInfo)
        Me.flpEmployeeInfo.Controls.Add(Me.pnlEmployeeTel)
        Me.flpEmployeeInfo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpEmployeeInfo.Location = New System.Drawing.Point(6, 20)
        Me.flpEmployeeInfo.Name = "flpEmployeeInfo"
        Me.flpEmployeeInfo.Size = New System.Drawing.Size(179, 246)
        Me.flpEmployeeInfo.TabIndex = 0
        '
        'pnlEmployeeNo
        '
        Me.pnlEmployeeNo.Controls.Add(Me.txbEmployeeNo)
        Me.pnlEmployeeNo.Controls.Add(Me.Label23)
        Me.pnlEmployeeNo.Location = New System.Drawing.Point(0, 0)
        Me.pnlEmployeeNo.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlEmployeeNo.Name = "pnlEmployeeNo"
        Me.pnlEmployeeNo.Size = New System.Drawing.Size(179, 27)
        Me.pnlEmployeeNo.TabIndex = 0
        '
        'txbEmployeeNo
        '
        Me.txbEmployeeNo.Location = New System.Drawing.Point(41, 0)
        Me.txbEmployeeNo.Name = "txbEmployeeNo"
        Me.txbEmployeeNo.ReadOnly = True
        Me.txbEmployeeNo.Size = New System.Drawing.Size(136, 21)
        Me.txbEmployeeNo.TabIndex = 1
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(4, 5)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(41, 12)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "编号："
        '
        'pnlEmployeeInfo
        '
        Me.pnlEmployeeInfo.Controls.Add(Me.txbEmployeeName)
        Me.pnlEmployeeInfo.Controls.Add(Me.txbEmployeeState)
        Me.pnlEmployeeInfo.Controls.Add(Me.Label111)
        Me.pnlEmployeeInfo.Controls.Add(Me.txbLevelName)
        Me.pnlEmployeeInfo.Controls.Add(Me.Label82)
        Me.pnlEmployeeInfo.Controls.Add(Me.Label77)
        Me.pnlEmployeeInfo.Controls.Add(Me.txbOfficeName)
        Me.pnlEmployeeInfo.Controls.Add(Me.txbEmployeeIDNo)
        Me.pnlEmployeeInfo.Controls.Add(Me.txbEmployeeIDType)
        Me.pnlEmployeeInfo.Controls.Add(Me.Label79)
        Me.pnlEmployeeInfo.Controls.Add(Me.Label81)
        Me.pnlEmployeeInfo.Controls.Add(Me.lblEmployeeIDNo)
        Me.pnlEmployeeInfo.Location = New System.Drawing.Point(0, 27)
        Me.pnlEmployeeInfo.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlEmployeeInfo.Name = "pnlEmployeeInfo"
        Me.pnlEmployeeInfo.Size = New System.Drawing.Size(179, 192)
        Me.pnlEmployeeInfo.TabIndex = 1
        '
        'txbEmployeeName
        '
        Me.txbEmployeeName.Location = New System.Drawing.Point(41, 0)
        Me.txbEmployeeName.Name = "txbEmployeeName"
        Me.txbEmployeeName.ReadOnly = True
        Me.txbEmployeeName.Size = New System.Drawing.Size(136, 21)
        Me.txbEmployeeName.TabIndex = 1
        '
        'txbEmployeeState
        '
        Me.txbEmployeeState.Location = New System.Drawing.Point(41, 165)
        Me.txbEmployeeState.Name = "txbEmployeeState"
        Me.txbEmployeeState.ReadOnly = True
        Me.txbEmployeeState.Size = New System.Drawing.Size(136, 21)
        Me.txbEmployeeState.TabIndex = 11
        '
        'Label111
        '
        Me.Label111.AutoSize = True
        Me.Label111.Location = New System.Drawing.Point(4, 170)
        Me.Label111.Name = "Label111"
        Me.Label111.Size = New System.Drawing.Size(41, 12)
        Me.Label111.TabIndex = 10
        Me.Label111.Text = "状态："
        '
        'txbLevelName
        '
        Me.txbLevelName.Location = New System.Drawing.Point(41, 138)
        Me.txbLevelName.Name = "txbLevelName"
        Me.txbLevelName.ReadOnly = True
        Me.txbLevelName.Size = New System.Drawing.Size(136, 21)
        Me.txbLevelName.TabIndex = 9
        '
        'Label82
        '
        Me.Label82.AutoSize = True
        Me.Label82.Location = New System.Drawing.Point(4, 143)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(41, 12)
        Me.Label82.TabIndex = 8
        Me.Label82.Text = "级别："
        '
        'Label77
        '
        Me.Label77.AutoSize = True
        Me.Label77.Location = New System.Drawing.Point(4, 5)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(41, 12)
        Me.Label77.TabIndex = 0
        Me.Label77.Text = "姓名："
        '
        'txbOfficeName
        '
        Me.txbOfficeName.Location = New System.Drawing.Point(41, 111)
        Me.txbOfficeName.Name = "txbOfficeName"
        Me.txbOfficeName.ReadOnly = True
        Me.txbOfficeName.Size = New System.Drawing.Size(136, 21)
        Me.txbOfficeName.TabIndex = 7
        '
        'txbEmployeeIDNo
        '
        Me.txbEmployeeIDNo.Location = New System.Drawing.Point(3, 84)
        Me.txbEmployeeIDNo.Name = "txbEmployeeIDNo"
        Me.txbEmployeeIDNo.ReadOnly = True
        Me.txbEmployeeIDNo.Size = New System.Drawing.Size(174, 21)
        Me.txbEmployeeIDNo.TabIndex = 5
        '
        'txbEmployeeIDType
        '
        Me.txbEmployeeIDType.Location = New System.Drawing.Point(3, 42)
        Me.txbEmployeeIDType.Name = "txbEmployeeIDType"
        Me.txbEmployeeIDType.ReadOnly = True
        Me.txbEmployeeIDType.Size = New System.Drawing.Size(174, 21)
        Me.txbEmployeeIDType.TabIndex = 3
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.Location = New System.Drawing.Point(4, 27)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(65, 12)
        Me.Label79.TabIndex = 2
        Me.Label79.Text = "证件类型："
        '
        'Label81
        '
        Me.Label81.AutoSize = True
        Me.Label81.Location = New System.Drawing.Point(4, 116)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(41, 12)
        Me.Label81.TabIndex = 6
        Me.Label81.Text = "地点："
        Me.theTip.SetToolTip(Me.Label81, "员工办公地点，可能是门店、CCU、大区办、小区办或总部")
        '
        'lblEmployeeIDNo
        '
        Me.lblEmployeeIDNo.AutoSize = True
        Me.lblEmployeeIDNo.Location = New System.Drawing.Point(4, 69)
        Me.lblEmployeeIDNo.Name = "lblEmployeeIDNo"
        Me.lblEmployeeIDNo.Size = New System.Drawing.Size(65, 12)
        Me.lblEmployeeIDNo.TabIndex = 4
        Me.lblEmployeeIDNo.Text = "证件号码："
        '
        'pnlEmployeeTel
        '
        Me.pnlEmployeeTel.Controls.Add(Me.txbEmployeeTel)
        Me.pnlEmployeeTel.Controls.Add(Me.Label83)
        Me.pnlEmployeeTel.Location = New System.Drawing.Point(0, 219)
        Me.pnlEmployeeTel.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlEmployeeTel.Name = "pnlEmployeeTel"
        Me.pnlEmployeeTel.Size = New System.Drawing.Size(179, 27)
        Me.pnlEmployeeTel.TabIndex = 2
        '
        'txbEmployeeTel
        '
        Me.txbEmployeeTel.Location = New System.Drawing.Point(41, 0)
        Me.txbEmployeeTel.Name = "txbEmployeeTel"
        Me.txbEmployeeTel.ReadOnly = True
        Me.txbEmployeeTel.Size = New System.Drawing.Size(136, 21)
        Me.txbEmployeeTel.TabIndex = 1
        '
        'Label83
        '
        Me.Label83.AutoSize = True
        Me.Label83.Location = New System.Drawing.Point(4, 5)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(41, 12)
        Me.Label83.TabIndex = 0
        Me.Label83.Text = "电话："
        '
        'grbInputEmployeeTel
        '
        Me.grbInputEmployeeTel.Controls.Add(Me.txbInputEmployeeTel)
        Me.grbInputEmployeeTel.Controls.Add(Me.cbbInputEmployeeTel)
        Me.grbInputEmployeeTel.Location = New System.Drawing.Point(0, 339)
        Me.grbInputEmployeeTel.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Me.grbInputEmployeeTel.Name = "grbInputEmployeeTel"
        Me.grbInputEmployeeTel.Size = New System.Drawing.Size(193, 50)
        Me.grbInputEmployeeTel.TabIndex = 2
        Me.grbInputEmployeeTel.TabStop = False
        Me.grbInputEmployeeTel.Text = "请输入员工联系电话："
        '
        'txbInputEmployeeTel
        '
        Me.txbInputEmployeeTel.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbInputEmployeeTel.Location = New System.Drawing.Point(9, 18)
        Me.txbInputEmployeeTel.MaxLength = 20
        Me.txbInputEmployeeTel.Name = "txbInputEmployeeTel"
        Me.txbInputEmployeeTel.Size = New System.Drawing.Size(174, 21)
        Me.txbInputEmployeeTel.TabIndex = 0
        Me.txbInputEmployeeTel.Visible = False
        '
        'cbbInputEmployeeTel
        '
        Me.cbbInputEmployeeTel.FormattingEnabled = True
        Me.cbbInputEmployeeTel.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cbbInputEmployeeTel.Location = New System.Drawing.Point(9, 18)
        Me.cbbInputEmployeeTel.MaxDropDownItems = 20
        Me.cbbInputEmployeeTel.Name = "cbbInputEmployeeTel"
        Me.cbbInputEmployeeTel.Size = New System.Drawing.Size(174, 20)
        Me.cbbInputEmployeeTel.TabIndex = 1
        Me.cbbInputEmployeeTel.Visible = False
        '
        'grbEmployeeQuota
        '
        Me.grbEmployeeQuota.Controls.Add(Me.flpEmployeeQuota)
        Me.grbEmployeeQuota.Location = New System.Drawing.Point(0, 395)
        Me.grbEmployeeQuota.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Me.grbEmployeeQuota.Name = "grbEmployeeQuota"
        Me.grbEmployeeQuota.Size = New System.Drawing.Size(193, 451)
        Me.grbEmployeeQuota.TabIndex = 3
        Me.grbEmployeeQuota.TabStop = False
        Me.grbEmployeeQuota.Text = "额度信息："
        '
        'flpEmployeeQuota
        '
        Me.flpEmployeeQuota.AutoSize = True
        Me.flpEmployeeQuota.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpEmployeeQuota.Controls.Add(Me.pnlQuota)
        Me.flpEmployeeQuota.Controls.Add(Me.pnlUsedQuota)
        Me.flpEmployeeQuota.Controls.Add(Me.tlpAvailableQuota)
        Me.flpEmployeeQuota.Controls.Add(Me.tlpDistributedQuota)
        Me.flpEmployeeQuota.Controls.Add(Me.tlpBalanceQuota)
        Me.flpEmployeeQuota.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpEmployeeQuota.Location = New System.Drawing.Point(6, 18)
        Me.flpEmployeeQuota.Name = "flpEmployeeQuota"
        Me.flpEmployeeQuota.Size = New System.Drawing.Size(179, 426)
        Me.flpEmployeeQuota.TabIndex = 0
        '
        'pnlQuota
        '
        Me.pnlQuota.Controls.Add(Me.txbRateQuota)
        Me.pnlQuota.Controls.Add(Me.txbPurchaseQuota)
        Me.pnlQuota.Controls.Add(Me.Label88)
        Me.pnlQuota.Controls.Add(Me.txbRebateQuota)
        Me.pnlQuota.Controls.Add(Me.Label87)
        Me.pnlQuota.Controls.Add(Me.Label86)
        Me.pnlQuota.Controls.Add(Me.Label85)
        Me.pnlQuota.Controls.Add(Me.Label90)
        Me.pnlQuota.Controls.Add(Me.Label84)
        Me.pnlQuota.Controls.Add(Me.Label89)
        Me.pnlQuota.Location = New System.Drawing.Point(0, 0)
        Me.pnlQuota.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlQuota.Name = "pnlQuota"
        Me.pnlQuota.Size = New System.Drawing.Size(179, 96)
        Me.pnlQuota.TabIndex = 0
        '
        'txbRateQuota
        '
        Me.txbRateQuota.Location = New System.Drawing.Point(41, 42)
        Me.txbRateQuota.Name = "txbRateQuota"
        Me.txbRateQuota.ReadOnly = True
        Me.txbRateQuota.Size = New System.Drawing.Size(118, 21)
        Me.txbRateQuota.TabIndex = 5
        Me.txbRateQuota.Text = "0.0"
        Me.txbRateQuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txbPurchaseQuota
        '
        Me.txbPurchaseQuota.Location = New System.Drawing.Point(41, 15)
        Me.txbPurchaseQuota.Name = "txbPurchaseQuota"
        Me.txbPurchaseQuota.ReadOnly = True
        Me.txbPurchaseQuota.Size = New System.Drawing.Size(118, 21)
        Me.txbPurchaseQuota.TabIndex = 2
        Me.txbPurchaseQuota.Text = "0.00"
        Me.txbPurchaseQuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label88
        '
        Me.Label88.AutoSize = True
        Me.Label88.Location = New System.Drawing.Point(165, 47)
        Me.Label88.Margin = New System.Windows.Forms.Padding(0)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(11, 12)
        Me.Label88.TabIndex = 6
        Me.Label88.Text = "%"
        Me.Label88.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txbRebateQuota
        '
        Me.txbRebateQuota.Location = New System.Drawing.Point(41, 69)
        Me.txbRebateQuota.Name = "txbRebateQuota"
        Me.txbRebateQuota.ReadOnly = True
        Me.txbRebateQuota.Size = New System.Drawing.Size(118, 21)
        Me.txbRebateQuota.TabIndex = 8
        Me.txbRebateQuota.Text = "0.00"
        Me.txbRebateQuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label87
        '
        Me.Label87.AutoSize = True
        Me.Label87.Location = New System.Drawing.Point(4, 47)
        Me.Label87.Margin = New System.Windows.Forms.Padding(0)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(41, 12)
        Me.Label87.TabIndex = 4
        Me.Label87.Text = "比率："
        Me.Label87.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.theTip.SetToolTip(Me.Label87, "公司规定的员工可获赠的返点比例")
        '
        'Label86
        '
        Me.Label86.AutoSize = True
        Me.Label86.Location = New System.Drawing.Point(162, 20)
        Me.Label86.Margin = New System.Windows.Forms.Padding(0)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(17, 12)
        Me.Label86.TabIndex = 3
        Me.Label86.Text = "元"
        Me.Label86.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label85
        '
        Me.Label85.AutoSize = True
        Me.Label85.Location = New System.Drawing.Point(4, 20)
        Me.Label85.Margin = New System.Windows.Forms.Padding(0)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(41, 12)
        Me.Label85.TabIndex = 1
        Me.Label85.Text = "购买："
        Me.Label85.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.theTip.SetToolTip(Me.Label85, "公司规定的员工单月可获赠返点的最大购买金额")
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.Location = New System.Drawing.Point(162, 74)
        Me.Label90.Margin = New System.Windows.Forms.Padding(0)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(17, 12)
        Me.Label90.TabIndex = 9
        Me.Label90.Text = "元"
        Me.Label90.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label84
        '
        Me.Label84.AutoSize = True
        Me.Label84.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label84.ForeColor = System.Drawing.Color.Maroon
        Me.Label84.Location = New System.Drawing.Point(0, 0)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(70, 12)
        Me.Label84.TabIndex = 0
        Me.Label84.Text = "本月额度："
        '
        'Label89
        '
        Me.Label89.AutoSize = True
        Me.Label89.Location = New System.Drawing.Point(4, 74)
        Me.Label89.Margin = New System.Windows.Forms.Padding(0)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(41, 12)
        Me.Label89.TabIndex = 7
        Me.Label89.Text = "返点："
        Me.Label89.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.theTip.SetToolTip(Me.Label89, "公司规定的员工单月可获赠的最大返点金额")
        '
        'pnlUsedQuota
        '
        Me.pnlUsedQuota.Controls.Add(Me.txbUsedRebateQuota)
        Me.pnlUsedQuota.Controls.Add(Me.txbUsedPurchaseQuota)
        Me.pnlUsedQuota.Controls.Add(Me.Label95)
        Me.pnlUsedQuota.Controls.Add(Me.Label94)
        Me.pnlUsedQuota.Controls.Add(Me.Label93)
        Me.pnlUsedQuota.Controls.Add(Me.Label92)
        Me.pnlUsedQuota.Controls.Add(Me.Label91)
        Me.pnlUsedQuota.Location = New System.Drawing.Point(0, 96)
        Me.pnlUsedQuota.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlUsedQuota.Name = "pnlUsedQuota"
        Me.pnlUsedQuota.Size = New System.Drawing.Size(179, 69)
        Me.pnlUsedQuota.TabIndex = 1
        '
        'txbUsedRebateQuota
        '
        Me.txbUsedRebateQuota.Location = New System.Drawing.Point(40, 42)
        Me.txbUsedRebateQuota.Name = "txbUsedRebateQuota"
        Me.txbUsedRebateQuota.ReadOnly = True
        Me.txbUsedRebateQuota.Size = New System.Drawing.Size(118, 21)
        Me.txbUsedRebateQuota.TabIndex = 4
        Me.txbUsedRebateQuota.Text = "0.00"
        Me.txbUsedRebateQuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txbUsedPurchaseQuota
        '
        Me.txbUsedPurchaseQuota.Location = New System.Drawing.Point(41, 15)
        Me.txbUsedPurchaseQuota.Name = "txbUsedPurchaseQuota"
        Me.txbUsedPurchaseQuota.ReadOnly = True
        Me.txbUsedPurchaseQuota.Size = New System.Drawing.Size(118, 21)
        Me.txbUsedPurchaseQuota.TabIndex = 1
        Me.txbUsedPurchaseQuota.Text = "0.00"
        Me.txbUsedPurchaseQuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label95
        '
        Me.Label95.AutoSize = True
        Me.Label95.Location = New System.Drawing.Point(161, 47)
        Me.Label95.Margin = New System.Windows.Forms.Padding(0)
        Me.Label95.Name = "Label95"
        Me.Label95.Size = New System.Drawing.Size(17, 12)
        Me.Label95.TabIndex = 5
        Me.Label95.Text = "元"
        Me.Label95.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label94
        '
        Me.Label94.AutoSize = True
        Me.Label94.Location = New System.Drawing.Point(3, 47)
        Me.Label94.Margin = New System.Windows.Forms.Padding(0)
        Me.Label94.Name = "Label94"
        Me.Label94.Size = New System.Drawing.Size(41, 12)
        Me.Label94.TabIndex = 3
        Me.Label94.Text = "返点："
        Me.Label94.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.theTip.SetToolTip(Me.Label94, "员工本月已获赠的返点金额（不含本次）")
        '
        'Label93
        '
        Me.Label93.AutoSize = True
        Me.Label93.Location = New System.Drawing.Point(162, 20)
        Me.Label93.Margin = New System.Windows.Forms.Padding(0)
        Me.Label93.Name = "Label93"
        Me.Label93.Size = New System.Drawing.Size(17, 12)
        Me.Label93.TabIndex = 2
        Me.Label93.Text = "元"
        Me.Label93.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label92
        '
        Me.Label92.AutoSize = True
        Me.Label92.Location = New System.Drawing.Point(4, 20)
        Me.Label92.Margin = New System.Windows.Forms.Padding(0)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(41, 12)
        Me.Label92.TabIndex = 0
        Me.Label92.Text = "购买："
        Me.Label92.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.theTip.SetToolTip(Me.Label92, "员工本月已使用的购买金额（不含本次）")
        '
        'Label91
        '
        Me.Label91.AutoSize = True
        Me.Label91.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label91.ForeColor = System.Drawing.Color.Maroon
        Me.Label91.Location = New System.Drawing.Point(0, 0)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(109, 12)
        Me.Label91.TabIndex = 0
        Me.Label91.Text = "本月已使用额度："
        '
        'tlpAvailableQuota
        '
        Me.tlpAvailableQuota.AutoSize = True
        Me.tlpAvailableQuota.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpAvailableQuota.ColumnCount = 1
        Me.tlpAvailableQuota.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpAvailableQuota.Controls.Add(Me.pnlAvailableRebateQuota, 0, 1)
        Me.tlpAvailableQuota.Controls.Add(Me.pnlMaxAvailableQuota, 0, 0)
        Me.tlpAvailableQuota.Location = New System.Drawing.Point(0, 165)
        Me.tlpAvailableQuota.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpAvailableQuota.Name = "tlpAvailableQuota"
        Me.tlpAvailableQuota.RowCount = 2
        Me.tlpAvailableQuota.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69.0!))
        Me.tlpAvailableQuota.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpAvailableQuota.Size = New System.Drawing.Size(179, 96)
        Me.tlpAvailableQuota.TabIndex = 2
        '
        'pnlAvailableRebateQuota
        '
        Me.pnlAvailableRebateQuota.Controls.Add(Me.txbAvailableRebateQuota)
        Me.pnlAvailableRebateQuota.Controls.Add(Me.Label80)
        Me.pnlAvailableRebateQuota.Controls.Add(Me.Label112)
        Me.pnlAvailableRebateQuota.Location = New System.Drawing.Point(0, 69)
        Me.pnlAvailableRebateQuota.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlAvailableRebateQuota.Name = "pnlAvailableRebateQuota"
        Me.pnlAvailableRebateQuota.Size = New System.Drawing.Size(179, 27)
        Me.pnlAvailableRebateQuota.TabIndex = 1
        '
        'txbAvailableRebateQuota
        '
        Me.txbAvailableRebateQuota.BackColor = System.Drawing.SystemColors.Control
        Me.txbAvailableRebateQuota.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txbAvailableRebateQuota.ForeColor = System.Drawing.Color.Blue
        Me.txbAvailableRebateQuota.Location = New System.Drawing.Point(41, 1)
        Me.txbAvailableRebateQuota.Name = "txbAvailableRebateQuota"
        Me.txbAvailableRebateQuota.ReadOnly = True
        Me.txbAvailableRebateQuota.Size = New System.Drawing.Size(118, 21)
        Me.txbAvailableRebateQuota.TabIndex = 1
        Me.txbAvailableRebateQuota.Text = "0.00"
        Me.txbAvailableRebateQuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label80
        '
        Me.Label80.AutoSize = True
        Me.Label80.Location = New System.Drawing.Point(162, 6)
        Me.Label80.Margin = New System.Windows.Forms.Padding(0)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(17, 12)
        Me.Label80.TabIndex = 2
        Me.Label80.Text = "元"
        Me.Label80.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label112
        '
        Me.Label112.AutoSize = True
        Me.Label112.Location = New System.Drawing.Point(4, 6)
        Me.Label112.Margin = New System.Windows.Forms.Padding(0)
        Me.Label112.Name = "Label112"
        Me.Label112.Size = New System.Drawing.Size(41, 12)
        Me.Label112.TabIndex = 0
        Me.Label112.Text = "可兑："
        Me.Label112.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.theTip.SetToolTip(Me.Label112, "根据本次购买金额计算出来的本次可兑现的返点额度")
        '
        'pnlMaxAvailableQuota
        '
        Me.pnlMaxAvailableQuota.Controls.Add(Me.txbMaxAvailableRebateQuota)
        Me.pnlMaxAvailableQuota.Controls.Add(Me.txbMaxAvailablePurchaseQuota)
        Me.pnlMaxAvailableQuota.Controls.Add(Me.Label100)
        Me.pnlMaxAvailableQuota.Controls.Add(Me.Label99)
        Me.pnlMaxAvailableQuota.Controls.Add(Me.Label98)
        Me.pnlMaxAvailableQuota.Controls.Add(Me.Label97)
        Me.pnlMaxAvailableQuota.Controls.Add(Me.Label96)
        Me.pnlMaxAvailableQuota.Location = New System.Drawing.Point(0, 0)
        Me.pnlMaxAvailableQuota.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlMaxAvailableQuota.Name = "pnlMaxAvailableQuota"
        Me.pnlMaxAvailableQuota.Size = New System.Drawing.Size(179, 69)
        Me.pnlMaxAvailableQuota.TabIndex = 0
        '
        'txbMaxAvailableRebateQuota
        '
        Me.txbMaxAvailableRebateQuota.Location = New System.Drawing.Point(41, 42)
        Me.txbMaxAvailableRebateQuota.Name = "txbMaxAvailableRebateQuota"
        Me.txbMaxAvailableRebateQuota.ReadOnly = True
        Me.txbMaxAvailableRebateQuota.Size = New System.Drawing.Size(118, 21)
        Me.txbMaxAvailableRebateQuota.TabIndex = 5
        Me.txbMaxAvailableRebateQuota.Text = "0.00"
        Me.txbMaxAvailableRebateQuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txbMaxAvailablePurchaseQuota
        '
        Me.txbMaxAvailablePurchaseQuota.Location = New System.Drawing.Point(41, 15)
        Me.txbMaxAvailablePurchaseQuota.Name = "txbMaxAvailablePurchaseQuota"
        Me.txbMaxAvailablePurchaseQuota.ReadOnly = True
        Me.txbMaxAvailablePurchaseQuota.Size = New System.Drawing.Size(118, 21)
        Me.txbMaxAvailablePurchaseQuota.TabIndex = 2
        Me.txbMaxAvailablePurchaseQuota.Text = "0.00"
        Me.txbMaxAvailablePurchaseQuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label100
        '
        Me.Label100.AutoSize = True
        Me.Label100.Location = New System.Drawing.Point(162, 47)
        Me.Label100.Margin = New System.Windows.Forms.Padding(0)
        Me.Label100.Name = "Label100"
        Me.Label100.Size = New System.Drawing.Size(17, 12)
        Me.Label100.TabIndex = 6
        Me.Label100.Text = "元"
        Me.Label100.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label99
        '
        Me.Label99.AutoSize = True
        Me.Label99.Location = New System.Drawing.Point(4, 47)
        Me.Label99.Margin = New System.Windows.Forms.Padding(0)
        Me.Label99.Name = "Label99"
        Me.Label99.Size = New System.Drawing.Size(41, 12)
        Me.Label99.TabIndex = 4
        Me.Label99.Text = "返点："
        Me.Label99.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.theTip.SetToolTip(Me.Label99, "员工本月剩余的可在本次获赠的的返点金额")
        '
        'Label98
        '
        Me.Label98.AutoSize = True
        Me.Label98.Location = New System.Drawing.Point(162, 20)
        Me.Label98.Margin = New System.Windows.Forms.Padding(0)
        Me.Label98.Name = "Label98"
        Me.Label98.Size = New System.Drawing.Size(17, 12)
        Me.Label98.TabIndex = 3
        Me.Label98.Text = "元"
        Me.Label98.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label97
        '
        Me.Label97.AutoSize = True
        Me.Label97.Location = New System.Drawing.Point(4, 20)
        Me.Label97.Margin = New System.Windows.Forms.Padding(0)
        Me.Label97.Name = "Label97"
        Me.Label97.Size = New System.Drawing.Size(41, 12)
        Me.Label97.TabIndex = 1
        Me.Label97.Text = "购买："
        Me.Label97.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.theTip.SetToolTip(Me.Label97, "员工本月剩余的可用于本次的最大购买金额")
        '
        'Label96
        '
        Me.Label96.AutoSize = True
        Me.Label96.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label96.ForeColor = System.Drawing.Color.Maroon
        Me.Label96.Location = New System.Drawing.Point(0, 0)
        Me.Label96.Name = "Label96"
        Me.Label96.Size = New System.Drawing.Size(109, 12)
        Me.Label96.TabIndex = 0
        Me.Label96.Text = "本次可使用额度："
        '
        'tlpDistributedQuota
        '
        Me.tlpDistributedQuota.AutoSize = True
        Me.tlpDistributedQuota.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpDistributedQuota.ColumnCount = 1
        Me.tlpDistributedQuota.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpDistributedQuota.Controls.Add(Me.pnlDistributedBalanceRebateQuota, 0, 1)
        Me.tlpDistributedQuota.Controls.Add(Me.pnlDistributedQuota, 0, 0)
        Me.tlpDistributedQuota.Location = New System.Drawing.Point(0, 261)
        Me.tlpDistributedQuota.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpDistributedQuota.Name = "tlpDistributedQuota"
        Me.tlpDistributedQuota.RowCount = 2
        Me.tlpDistributedQuota.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69.0!))
        Me.tlpDistributedQuota.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpDistributedQuota.Size = New System.Drawing.Size(179, 96)
        Me.tlpDistributedQuota.TabIndex = 3
        '
        'pnlDistributedBalanceRebateQuota
        '
        Me.pnlDistributedBalanceRebateQuota.Controls.Add(Me.txbDistributedBalanceRebateQuota)
        Me.pnlDistributedBalanceRebateQuota.Controls.Add(Me.Label107)
        Me.pnlDistributedBalanceRebateQuota.Controls.Add(Me.Label109)
        Me.pnlDistributedBalanceRebateQuota.Location = New System.Drawing.Point(0, 69)
        Me.pnlDistributedBalanceRebateQuota.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlDistributedBalanceRebateQuota.Name = "pnlDistributedBalanceRebateQuota"
        Me.pnlDistributedBalanceRebateQuota.Size = New System.Drawing.Size(179, 27)
        Me.pnlDistributedBalanceRebateQuota.TabIndex = 1
        '
        'txbDistributedBalanceRebateQuota
        '
        Me.txbDistributedBalanceRebateQuota.BackColor = System.Drawing.SystemColors.Control
        Me.txbDistributedBalanceRebateQuota.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txbDistributedBalanceRebateQuota.ForeColor = System.Drawing.Color.Red
        Me.txbDistributedBalanceRebateQuota.Location = New System.Drawing.Point(41, 1)
        Me.txbDistributedBalanceRebateQuota.Name = "txbDistributedBalanceRebateQuota"
        Me.txbDistributedBalanceRebateQuota.ReadOnly = True
        Me.txbDistributedBalanceRebateQuota.Size = New System.Drawing.Size(118, 21)
        Me.txbDistributedBalanceRebateQuota.TabIndex = 5
        Me.txbDistributedBalanceRebateQuota.Text = "0.00"
        Me.txbDistributedBalanceRebateQuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label107
        '
        Me.Label107.AutoSize = True
        Me.Label107.Location = New System.Drawing.Point(162, 6)
        Me.Label107.Margin = New System.Windows.Forms.Padding(0)
        Me.Label107.Name = "Label107"
        Me.Label107.Size = New System.Drawing.Size(17, 12)
        Me.Label107.TabIndex = 6
        Me.Label107.Text = "元"
        Me.Label107.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label109
        '
        Me.Label109.AutoSize = True
        Me.Label109.Location = New System.Drawing.Point(4, 6)
        Me.Label109.Margin = New System.Windows.Forms.Padding(0)
        Me.Label109.Name = "Label109"
        Me.Label109.Size = New System.Drawing.Size(41, 12)
        Me.Label109.TabIndex = 4
        Me.Label109.Text = "剩余："
        Me.Label109.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.theTip.SetToolTip(Me.Label109, "本次剩余（未分配）的返点金额")
        '
        'pnlDistributedQuota
        '
        Me.pnlDistributedQuota.Controls.Add(Me.txbDistributedRebateQuota)
        Me.pnlDistributedQuota.Controls.Add(Me.txbDistributedPurchaseQuota)
        Me.pnlDistributedQuota.Controls.Add(Me.Label105)
        Me.pnlDistributedQuota.Controls.Add(Me.Label104)
        Me.pnlDistributedQuota.Controls.Add(Me.Label103)
        Me.pnlDistributedQuota.Controls.Add(Me.Label102)
        Me.pnlDistributedQuota.Controls.Add(Me.Label101)
        Me.pnlDistributedQuota.Location = New System.Drawing.Point(0, 0)
        Me.pnlDistributedQuota.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlDistributedQuota.Name = "pnlDistributedQuota"
        Me.pnlDistributedQuota.Size = New System.Drawing.Size(179, 69)
        Me.pnlDistributedQuota.TabIndex = 0
        '
        'txbDistributedRebateQuota
        '
        Me.txbDistributedRebateQuota.Location = New System.Drawing.Point(41, 42)
        Me.txbDistributedRebateQuota.Name = "txbDistributedRebateQuota"
        Me.txbDistributedRebateQuota.ReadOnly = True
        Me.txbDistributedRebateQuota.Size = New System.Drawing.Size(118, 21)
        Me.txbDistributedRebateQuota.TabIndex = 5
        Me.txbDistributedRebateQuota.Text = "0.00"
        Me.txbDistributedRebateQuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.theTip.SetToolTip(Me.txbDistributedRebateQuota, "本次已分配的返点金额")
        '
        'txbDistributedPurchaseQuota
        '
        Me.txbDistributedPurchaseQuota.Location = New System.Drawing.Point(41, 15)
        Me.txbDistributedPurchaseQuota.Name = "txbDistributedPurchaseQuota"
        Me.txbDistributedPurchaseQuota.ReadOnly = True
        Me.txbDistributedPurchaseQuota.Size = New System.Drawing.Size(118, 21)
        Me.txbDistributedPurchaseQuota.TabIndex = 2
        Me.txbDistributedPurchaseQuota.Text = "0.00"
        Me.txbDistributedPurchaseQuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label105
        '
        Me.Label105.AutoSize = True
        Me.Label105.Location = New System.Drawing.Point(162, 47)
        Me.Label105.Margin = New System.Windows.Forms.Padding(0)
        Me.Label105.Name = "Label105"
        Me.Label105.Size = New System.Drawing.Size(17, 12)
        Me.Label105.TabIndex = 6
        Me.Label105.Text = "元"
        Me.Label105.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label104
        '
        Me.Label104.AutoSize = True
        Me.Label104.Location = New System.Drawing.Point(4, 47)
        Me.Label104.Margin = New System.Windows.Forms.Padding(0)
        Me.Label104.Name = "Label104"
        Me.Label104.Size = New System.Drawing.Size(41, 12)
        Me.Label104.TabIndex = 4
        Me.Label104.Text = "返点："
        Me.Label104.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.theTip.SetToolTip(Me.Label104, "本次已分配的返点金额")
        '
        'Label103
        '
        Me.Label103.AutoSize = True
        Me.Label103.Location = New System.Drawing.Point(162, 20)
        Me.Label103.Margin = New System.Windows.Forms.Padding(0)
        Me.Label103.Name = "Label103"
        Me.Label103.Size = New System.Drawing.Size(17, 12)
        Me.Label103.TabIndex = 3
        Me.Label103.Text = "元"
        Me.Label103.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label102
        '
        Me.Label102.AutoSize = True
        Me.Label102.Location = New System.Drawing.Point(4, 20)
        Me.Label102.Margin = New System.Windows.Forms.Padding(0)
        Me.Label102.Name = "Label102"
        Me.Label102.Size = New System.Drawing.Size(41, 12)
        Me.Label102.TabIndex = 1
        Me.Label102.Text = "购买："
        Me.Label102.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.theTip.SetToolTip(Me.Label102, "本次已分配的购买金额")
        '
        'Label101
        '
        Me.Label101.AutoSize = True
        Me.Label101.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label101.ForeColor = System.Drawing.Color.Maroon
        Me.Label101.Location = New System.Drawing.Point(0, 0)
        Me.Label101.Name = "Label101"
        Me.Label101.Size = New System.Drawing.Size(109, 12)
        Me.Label101.TabIndex = 0
        Me.Label101.Text = "本次已分配额度："
        '
        'tlpBalanceQuota
        '
        Me.tlpBalanceQuota.AutoSize = True
        Me.tlpBalanceQuota.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpBalanceQuota.ColumnCount = 1
        Me.tlpBalanceQuota.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpBalanceQuota.Controls.Add(Me.pnlBalanceRebateQuota, 0, 2)
        Me.tlpBalanceQuota.Controls.Add(Me.Label106, 0, 0)
        Me.tlpBalanceQuota.Controls.Add(Me.pnlBalancePurchaseQuota, 0, 1)
        Me.tlpBalanceQuota.Location = New System.Drawing.Point(0, 357)
        Me.tlpBalanceQuota.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpBalanceQuota.Name = "tlpBalanceQuota"
        Me.tlpBalanceQuota.RowCount = 3
        Me.tlpBalanceQuota.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpBalanceQuota.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpBalanceQuota.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpBalanceQuota.Size = New System.Drawing.Size(179, 69)
        Me.tlpBalanceQuota.TabIndex = 4
        '
        'pnlBalanceRebateQuota
        '
        Me.pnlBalanceRebateQuota.Controls.Add(Me.txbBalanceRebateQuota)
        Me.pnlBalanceRebateQuota.Controls.Add(Me.Label110)
        Me.pnlBalanceRebateQuota.Controls.Add(Me.Label114)
        Me.pnlBalanceRebateQuota.Location = New System.Drawing.Point(0, 42)
        Me.pnlBalanceRebateQuota.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlBalanceRebateQuota.Name = "pnlBalanceRebateQuota"
        Me.pnlBalanceRebateQuota.Size = New System.Drawing.Size(179, 27)
        Me.pnlBalanceRebateQuota.TabIndex = 2
        '
        'txbBalanceRebateQuota
        '
        Me.txbBalanceRebateQuota.Location = New System.Drawing.Point(41, 1)
        Me.txbBalanceRebateQuota.Name = "txbBalanceRebateQuota"
        Me.txbBalanceRebateQuota.ReadOnly = True
        Me.txbBalanceRebateQuota.Size = New System.Drawing.Size(118, 21)
        Me.txbBalanceRebateQuota.TabIndex = 5
        Me.txbBalanceRebateQuota.Text = "0.00"
        Me.txbBalanceRebateQuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label110
        '
        Me.Label110.AutoSize = True
        Me.Label110.Location = New System.Drawing.Point(162, 6)
        Me.Label110.Margin = New System.Windows.Forms.Padding(0)
        Me.Label110.Name = "Label110"
        Me.Label110.Size = New System.Drawing.Size(17, 12)
        Me.Label110.TabIndex = 6
        Me.Label110.Text = "元"
        Me.Label110.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label114
        '
        Me.Label114.AutoSize = True
        Me.Label114.Location = New System.Drawing.Point(4, 6)
        Me.Label114.Margin = New System.Windows.Forms.Padding(0)
        Me.Label114.Name = "Label114"
        Me.Label114.Size = New System.Drawing.Size(41, 12)
        Me.Label114.TabIndex = 4
        Me.Label114.Text = "返点："
        Me.Label114.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.theTip.SetToolTip(Me.Label114, "员工本月剩余的可在下次获赠的的返点金额")
        '
        'Label106
        '
        Me.Label106.AutoSize = True
        Me.Label106.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label106.ForeColor = System.Drawing.Color.Maroon
        Me.Label106.Location = New System.Drawing.Point(0, 0)
        Me.Label106.Margin = New System.Windows.Forms.Padding(0)
        Me.Label106.Name = "Label106"
        Me.Label106.Size = New System.Drawing.Size(70, 12)
        Me.Label106.TabIndex = 0
        Me.Label106.Text = "剩余额度："
        '
        'pnlBalancePurchaseQuota
        '
        Me.pnlBalancePurchaseQuota.Controls.Add(Me.txbBalancePurchaseQuota)
        Me.pnlBalancePurchaseQuota.Controls.Add(Me.Label113)
        Me.pnlBalancePurchaseQuota.Controls.Add(Me.Label108)
        Me.pnlBalancePurchaseQuota.Location = New System.Drawing.Point(0, 15)
        Me.pnlBalancePurchaseQuota.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlBalancePurchaseQuota.Name = "pnlBalancePurchaseQuota"
        Me.pnlBalancePurchaseQuota.Size = New System.Drawing.Size(179, 27)
        Me.pnlBalancePurchaseQuota.TabIndex = 1
        '
        'txbBalancePurchaseQuota
        '
        Me.txbBalancePurchaseQuota.Location = New System.Drawing.Point(41, 1)
        Me.txbBalancePurchaseQuota.Name = "txbBalancePurchaseQuota"
        Me.txbBalancePurchaseQuota.ReadOnly = True
        Me.txbBalancePurchaseQuota.Size = New System.Drawing.Size(118, 21)
        Me.txbBalancePurchaseQuota.TabIndex = 2
        Me.txbBalancePurchaseQuota.Text = "0.00"
        Me.txbBalancePurchaseQuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label113
        '
        Me.Label113.AutoSize = True
        Me.Label113.Location = New System.Drawing.Point(4, 6)
        Me.Label113.Margin = New System.Windows.Forms.Padding(0)
        Me.Label113.Name = "Label113"
        Me.Label113.Size = New System.Drawing.Size(41, 12)
        Me.Label113.TabIndex = 1
        Me.Label113.Text = "购买："
        Me.Label113.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.theTip.SetToolTip(Me.Label113, "员工本月剩余的可用于下次的最大购买金额")
        '
        'Label108
        '
        Me.Label108.AutoSize = True
        Me.Label108.Location = New System.Drawing.Point(162, 6)
        Me.Label108.Margin = New System.Windows.Forms.Padding(0)
        Me.Label108.Name = "Label108"
        Me.Label108.Size = New System.Drawing.Size(17, 12)
        Me.Label108.TabIndex = 3
        Me.Label108.Text = "元"
        Me.Label108.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grbPromotionInfo
        '
        Me.grbPromotionInfo.Controls.Add(Me.pnlPromotionPeriod)
        Me.grbPromotionInfo.Controls.Add(Me.Label74)
        Me.grbPromotionInfo.Controls.Add(Me.Label72)
        Me.grbPromotionInfo.Controls.Add(Me.txbPromotionTitle)
        Me.grbPromotionInfo.Controls.Add(Me.pnlPromotionPeriodReadOnly)
        Me.grbPromotionInfo.Location = New System.Drawing.Point(0, 902)
        Me.grbPromotionInfo.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Me.grbPromotionInfo.Name = "grbPromotionInfo"
        Me.grbPromotionInfo.Size = New System.Drawing.Size(193, 108)
        Me.grbPromotionInfo.TabIndex = 2
        Me.grbPromotionInfo.TabStop = False
        Me.grbPromotionInfo.Text = "请输入活动摘要："
        '
        'pnlPromotionPeriod
        '
        Me.pnlPromotionPeriod.Controls.Add(Me.pnlPromotionEndDate)
        Me.pnlPromotionPeriod.Controls.Add(Me.pnlPromotionStartDate)
        Me.pnlPromotionPeriod.Controls.Add(Me.dtpPromotionEndDate)
        Me.pnlPromotionPeriod.Controls.Add(Me.dtpPromotionStartDate)
        Me.pnlPromotionPeriod.Controls.Add(Me.Label75)
        Me.pnlPromotionPeriod.Location = New System.Drawing.Point(6, 76)
        Me.pnlPromotionPeriod.Name = "pnlPromotionPeriod"
        Me.pnlPromotionPeriod.Size = New System.Drawing.Size(179, 21)
        Me.pnlPromotionPeriod.TabIndex = 3
        '
        'pnlPromotionEndDate
        '
        Me.pnlPromotionEndDate.BackColor = System.Drawing.SystemColors.Window
        Me.pnlPromotionEndDate.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.pnlPromotionEndDate.Location = New System.Drawing.Point(95, 2)
        Me.pnlPromotionEndDate.Name = "pnlPromotionEndDate"
        Me.pnlPromotionEndDate.Size = New System.Drawing.Size(62, 17)
        Me.pnlPromotionEndDate.TabIndex = 4
        '
        'pnlPromotionStartDate
        '
        Me.pnlPromotionStartDate.BackColor = System.Drawing.SystemColors.Window
        Me.pnlPromotionStartDate.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.pnlPromotionStartDate.Location = New System.Drawing.Point(5, 2)
        Me.pnlPromotionStartDate.Name = "pnlPromotionStartDate"
        Me.pnlPromotionStartDate.Size = New System.Drawing.Size(62, 17)
        Me.pnlPromotionStartDate.TabIndex = 1
        '
        'dtpPromotionEndDate
        '
        Me.dtpPromotionEndDate.CustomFormat = "yyyy/MM/dd"
        Me.dtpPromotionEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPromotionEndDate.Location = New System.Drawing.Point(93, 0)
        Me.dtpPromotionEndDate.MinDate = New Date(2011, 1, 1, 0, 0, 0, 0)
        Me.dtpPromotionEndDate.Name = "dtpPromotionEndDate"
        Me.dtpPromotionEndDate.Size = New System.Drawing.Size(84, 21)
        Me.dtpPromotionEndDate.TabIndex = 3
        '
        'dtpPromotionStartDate
        '
        Me.dtpPromotionStartDate.CustomFormat = "yyyy/MM/dd"
        Me.dtpPromotionStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPromotionStartDate.Location = New System.Drawing.Point(3, 0)
        Me.dtpPromotionStartDate.MinDate = New Date(2011, 1, 1, 0, 0, 0, 0)
        Me.dtpPromotionStartDate.Name = "dtpPromotionStartDate"
        Me.dtpPromotionStartDate.Size = New System.Drawing.Size(84, 21)
        Me.dtpPromotionStartDate.TabIndex = 0
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Font = New System.Drawing.Font("SimSun", 8.0!)
        Me.Label75.Location = New System.Drawing.Point(85, 6)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(11, 11)
        Me.Label75.TabIndex = 2
        Me.Label75.Text = "-"
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Location = New System.Drawing.Point(6, 61)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(65, 12)
        Me.Label74.TabIndex = 2
        Me.Label74.Text = "活动时期："
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Location = New System.Drawing.Point(6, 18)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(65, 12)
        Me.Label72.TabIndex = 0
        Me.Label72.Text = "活动名称："
        '
        'txbPromotionTitle
        '
        Me.txbPromotionTitle.Location = New System.Drawing.Point(9, 33)
        Me.txbPromotionTitle.MaxLength = 50
        Me.txbPromotionTitle.Name = "txbPromotionTitle"
        Me.txbPromotionTitle.Size = New System.Drawing.Size(174, 21)
        Me.txbPromotionTitle.TabIndex = 1
        '
        'pnlPromotionPeriodReadOnly
        '
        Me.pnlPromotionPeriodReadOnly.Controls.Add(Me.txbPromotionEndDate)
        Me.pnlPromotionPeriodReadOnly.Controls.Add(Me.txbPromotionStartDate)
        Me.pnlPromotionPeriodReadOnly.Controls.Add(Me.Label76)
        Me.pnlPromotionPeriodReadOnly.Location = New System.Drawing.Point(6, 76)
        Me.pnlPromotionPeriodReadOnly.Name = "pnlPromotionPeriodReadOnly"
        Me.pnlPromotionPeriodReadOnly.Size = New System.Drawing.Size(179, 21)
        Me.pnlPromotionPeriodReadOnly.TabIndex = 4
        Me.pnlPromotionPeriodReadOnly.Visible = False
        '
        'txbPromotionEndDate
        '
        Me.txbPromotionEndDate.Location = New System.Drawing.Point(101, 0)
        Me.txbPromotionEndDate.Name = "txbPromotionEndDate"
        Me.txbPromotionEndDate.ReadOnly = True
        Me.txbPromotionEndDate.Size = New System.Drawing.Size(76, 21)
        Me.txbPromotionEndDate.TabIndex = 2
        Me.txbPromotionEndDate.Text = "2012/06/01"
        Me.txbPromotionEndDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txbPromotionStartDate
        '
        Me.txbPromotionStartDate.Location = New System.Drawing.Point(3, 0)
        Me.txbPromotionStartDate.Name = "txbPromotionStartDate"
        Me.txbPromotionStartDate.ReadOnly = True
        Me.txbPromotionStartDate.Size = New System.Drawing.Size(76, 21)
        Me.txbPromotionStartDate.TabIndex = 0
        Me.txbPromotionStartDate.Text = "2012/06/01"
        Me.txbPromotionStartDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Location = New System.Drawing.Point(85, 4)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(11, 12)
        Me.Label76.TabIndex = 1
        Me.Label76.Text = "-"
        '
        'grbCustomer
        '
        Me.grbCustomer.Controls.Add(Me.flpCustomer)
        Me.grbCustomer.Location = New System.Drawing.Point(0, 1016)
        Me.grbCustomer.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Me.grbCustomer.Name = "grbCustomer"
        Me.grbCustomer.Size = New System.Drawing.Size(193, 235)
        Me.grbCustomer.TabIndex = 3
        Me.grbCustomer.TabStop = False
        Me.grbCustomer.Text = "请选择客户："
        '
        'flpCustomer
        '
        Me.flpCustomer.AutoSize = True
        Me.flpCustomer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpCustomer.Controls.Add(Me.pnlSelectStore)
        Me.flpCustomer.Controls.Add(Me.pnlCustomerType)
        Me.flpCustomer.Controls.Add(Me.pnlCompanyCustomer)
        Me.flpCustomer.Controls.Add(Me.pnlCustomerButtons)
        Me.flpCustomer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpCustomer.Location = New System.Drawing.Point(6, 16)
        Me.flpCustomer.Name = "flpCustomer"
        Me.flpCustomer.Size = New System.Drawing.Size(179, 207)
        Me.flpCustomer.TabIndex = 0
        '
        'pnlSelectStore
        '
        Me.pnlSelectStore.Controls.Add(Me.Label59)
        Me.pnlSelectStore.Controls.Add(Me.cbbSelectStore)
        Me.pnlSelectStore.Location = New System.Drawing.Point(0, 0)
        Me.pnlSelectStore.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlSelectStore.Name = "pnlSelectStore"
        Me.pnlSelectStore.Size = New System.Drawing.Size(179, 41)
        Me.pnlSelectStore.TabIndex = 0
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Location = New System.Drawing.Point(0, 2)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(77, 12)
        Me.Label59.TabIndex = 0
        Me.Label59.Text = "请选择门店："
        '
        'cbbSelectStore
        '
        Me.cbbSelectStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbSelectStore.FormattingEnabled = True
        Me.cbbSelectStore.Items.AddRange(New Object() {"个人客户", "公司客户"})
        Me.cbbSelectStore.Location = New System.Drawing.Point(3, 17)
        Me.cbbSelectStore.MaxDropDownItems = 20
        Me.cbbSelectStore.Name = "cbbSelectStore"
        Me.cbbSelectStore.Size = New System.Drawing.Size(174, 20)
        Me.cbbSelectStore.TabIndex = 1
        '
        'pnlCustomerType
        '
        Me.pnlCustomerType.Controls.Add(Me.Label119)
        Me.pnlCustomerType.Controls.Add(Me.cbbCustomerType)
        Me.pnlCustomerType.Location = New System.Drawing.Point(0, 41)
        Me.pnlCustomerType.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlCustomerType.Name = "pnlCustomerType"
        Me.pnlCustomerType.Size = New System.Drawing.Size(179, 41)
        Me.pnlCustomerType.TabIndex = 1
        '
        'Label119
        '
        Me.Label119.AutoSize = True
        Me.Label119.Location = New System.Drawing.Point(0, 2)
        Me.Label119.Name = "Label119"
        Me.Label119.Size = New System.Drawing.Size(101, 12)
        Me.Label119.TabIndex = 0
        Me.Label119.Text = "请选择客户类型："
        '
        'cbbCustomerType
        '
        Me.cbbCustomerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbCustomerType.FormattingEnabled = True
        Me.cbbCustomerType.Items.AddRange(New Object() {"个人客户", "公司客户"})
        Me.cbbCustomerType.Location = New System.Drawing.Point(3, 17)
        Me.cbbCustomerType.MaxLength = 20
        Me.cbbCustomerType.Name = "cbbCustomerType"
        Me.cbbCustomerType.Size = New System.Drawing.Size(174, 20)
        Me.cbbCustomerType.TabIndex = 2
        '
        'pnlCompanyCustomer
        '
        Me.pnlCompanyCustomer.Controls.Add(Me.txbCompanyCredentialsNo)
        Me.pnlCompanyCustomer.Controls.Add(Me.Label116)
        Me.pnlCompanyCustomer.Controls.Add(Me.cbbCompanyCredentialsType)
        Me.pnlCompanyCustomer.Controls.Add(Me.txbCompanyCredentialsType)
        Me.pnlCompanyCustomer.Controls.Add(Me.lblCustomerName)
        Me.pnlCompanyCustomer.Controls.Add(Me.txbCustomerName)
        Me.pnlCompanyCustomer.Controls.Add(Me.cbbCustomerName)
        Me.pnlCompanyCustomer.Controls.Add(Me.Label115)
        Me.pnlCompanyCustomer.Location = New System.Drawing.Point(0, 82)
        Me.pnlCompanyCustomer.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlCompanyCustomer.Name = "pnlCompanyCustomer"
        Me.pnlCompanyCustomer.Size = New System.Drawing.Size(179, 95)
        Me.pnlCompanyCustomer.TabIndex = 2
        '
        'txbCompanyCredentialsNo
        '
        Me.txbCompanyCredentialsNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txbCompanyCredentialsNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbCompanyCredentialsNo.Location = New System.Drawing.Point(62, 70)
        Me.txbCompanyCredentialsNo.MaxLength = 50
        Me.txbCompanyCredentialsNo.Name = "txbCompanyCredentialsNo"
        Me.txbCompanyCredentialsNo.Size = New System.Drawing.Size(115, 21)
        Me.txbCompanyCredentialsNo.TabIndex = 7
        '
        'Label116
        '
        Me.Label116.AutoSize = True
        Me.Label116.Location = New System.Drawing.Point(0, 75)
        Me.Label116.Name = "Label116"
        Me.Label116.Size = New System.Drawing.Size(65, 12)
        Me.Label116.TabIndex = 6
        Me.Label116.Text = "证件号码："
        '
        'cbbCompanyCredentialsType
        '
        Me.cbbCompanyCredentialsType.FormattingEnabled = True
        Me.cbbCompanyCredentialsType.Items.AddRange(New Object() {"营业执照", "事业单位法人证书", "税务登记证", "组织机构代码证"})
        Me.cbbCompanyCredentialsType.Location = New System.Drawing.Point(62, 43)
        Me.cbbCompanyCredentialsType.MaxLength = 50
        Me.cbbCompanyCredentialsType.Name = "cbbCompanyCredentialsType"
        Me.cbbCompanyCredentialsType.Size = New System.Drawing.Size(115, 20)
        Me.cbbCompanyCredentialsType.TabIndex = 4
        '
        'txbCompanyCredentialsType
        '
        Me.txbCompanyCredentialsType.Location = New System.Drawing.Point(62, 43)
        Me.txbCompanyCredentialsType.MaxLength = 50
        Me.txbCompanyCredentialsType.Name = "txbCompanyCredentialsType"
        Me.txbCompanyCredentialsType.ReadOnly = True
        Me.txbCompanyCredentialsType.Size = New System.Drawing.Size(115, 21)
        Me.txbCompanyCredentialsType.TabIndex = 5
        '
        'lblCustomerName
        '
        Me.lblCustomerName.AutoSize = True
        Me.lblCustomerName.Location = New System.Drawing.Point(0, 0)
        Me.lblCustomerName.Name = "lblCustomerName"
        Me.lblCustomerName.Size = New System.Drawing.Size(101, 12)
        Me.lblCustomerName.TabIndex = 0
        Me.lblCustomerName.Text = "请输入公司名称："
        '
        'txbCustomerName
        '
        Me.txbCustomerName.Location = New System.Drawing.Point(3, 15)
        Me.txbCustomerName.MaxLength = 100
        Me.txbCustomerName.Name = "txbCustomerName"
        Me.txbCustomerName.Size = New System.Drawing.Size(174, 21)
        Me.txbCustomerName.TabIndex = 1
        '
        'cbbCustomerName
        '
        Me.cbbCustomerName.FormattingEnabled = True
        Me.cbbCustomerName.Location = New System.Drawing.Point(3, 15)
        Me.cbbCustomerName.MaxDropDownItems = 50
        Me.cbbCustomerName.MaxLength = 100
        Me.cbbCustomerName.Name = "cbbCustomerName"
        Me.cbbCustomerName.Size = New System.Drawing.Size(174, 20)
        Me.cbbCustomerName.TabIndex = 2
        Me.cbbCustomerName.Visible = False
        '
        'Label115
        '
        Me.Label115.AutoSize = True
        Me.Label115.Location = New System.Drawing.Point(0, 49)
        Me.Label115.Name = "Label115"
        Me.Label115.Size = New System.Drawing.Size(65, 12)
        Me.Label115.TabIndex = 3
        Me.Label115.Text = "证件类型："
        '
        'pnlCustomerButtons
        '
        Me.pnlCustomerButtons.Controls.Add(Me.btnViewCustomer)
        Me.pnlCustomerButtons.Controls.Add(Me.btnNewCustomer)
        Me.pnlCustomerButtons.Location = New System.Drawing.Point(0, 177)
        Me.pnlCustomerButtons.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlCustomerButtons.Name = "pnlCustomerButtons"
        Me.pnlCustomerButtons.Size = New System.Drawing.Size(179, 30)
        Me.pnlCustomerButtons.TabIndex = 3
        '
        'btnViewCustomer
        '
        Me.btnViewCustomer.Enabled = False
        Me.btnViewCustomer.Location = New System.Drawing.Point(130, 5)
        Me.btnViewCustomer.Name = "btnViewCustomer"
        Me.btnViewCustomer.Size = New System.Drawing.Size(48, 23)
        Me.btnViewCustomer.TabIndex = 1
        Me.btnViewCustomer.Text = "查看"
        Me.theTip.SetToolTip(Me.btnViewCustomer, "查看公司客户")
        Me.btnViewCustomer.UseVisualStyleBackColor = True
        '
        'btnNewCustomer
        '
        Me.btnNewCustomer.Location = New System.Drawing.Point(62, 5)
        Me.btnNewCustomer.Name = "btnNewCustomer"
        Me.btnNewCustomer.Size = New System.Drawing.Size(48, 23)
        Me.btnNewCustomer.TabIndex = 0
        Me.btnNewCustomer.Text = "新建"
        Me.theTip.SetToolTip(Me.btnNewCustomer, "新建公司客户")
        Me.btnNewCustomer.UseVisualStyleBackColor = True
        '
        'grbAvailablePayer
        '
        Me.grbAvailablePayer.Controls.Add(Me.cbbAvailablePayer)
        Me.grbAvailablePayer.Controls.Add(Me.Label78)
        Me.grbAvailablePayer.Location = New System.Drawing.Point(0, 1257)
        Me.grbAvailablePayer.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Me.grbAvailablePayer.Name = "grbAvailablePayer"
        Me.grbAvailablePayer.Size = New System.Drawing.Size(193, 66)
        Me.grbAvailablePayer.TabIndex = 4
        Me.grbAvailablePayer.TabStop = False
        Me.grbAvailablePayer.Text = "请选择付款单位名称："
        '
        'cbbAvailablePayer
        '
        Me.cbbAvailablePayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbAvailablePayer.FormattingEnabled = True
        Me.cbbAvailablePayer.Location = New System.Drawing.Point(9, 33)
        Me.cbbAvailablePayer.MaxDropDownItems = 20
        Me.cbbAvailablePayer.Name = "cbbAvailablePayer"
        Me.cbbAvailablePayer.Size = New System.Drawing.Size(174, 20)
        Me.cbbAvailablePayer.TabIndex = 1
        '
        'Label78
        '
        Me.Label78.AutoSize = True
        Me.Label78.Location = New System.Drawing.Point(6, 18)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(149, 12)
        Me.Label78.TabIndex = 0
        Me.Label78.Text = "可选择付款单位名称列表："
        '
        'grbBuyerInfo
        '
        Me.grbBuyerInfo.Controls.Add(Me.pnlBuyerName)
        Me.grbBuyerInfo.Controls.Add(Me.pnlBuyerCredentials)
        Me.grbBuyerInfo.Location = New System.Drawing.Point(0, 1329)
        Me.grbBuyerInfo.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Me.grbBuyerInfo.Name = "grbBuyerInfo"
        Me.grbBuyerInfo.Size = New System.Drawing.Size(193, 134)
        Me.grbBuyerInfo.TabIndex = 5
        Me.grbBuyerInfo.TabStop = False
        Me.grbBuyerInfo.Text = "请完善购买人信息："
        '
        'pnlBuyerName
        '
        Me.pnlBuyerName.Controls.Add(Me.txbTelMP)
        Me.pnlBuyerName.Controls.Add(Me.txbBuyerName)
        Me.pnlBuyerName.Controls.Add(Me.cbbBuyerName)
        Me.pnlBuyerName.Controls.Add(Me.cbbTelMP)
        Me.pnlBuyerName.Controls.Add(Me.Label5)
        Me.pnlBuyerName.Controls.Add(Me.Label9)
        Me.pnlBuyerName.Location = New System.Drawing.Point(6, 18)
        Me.pnlBuyerName.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlBuyerName.Name = "pnlBuyerName"
        Me.pnlBuyerName.Size = New System.Drawing.Size(179, 52)
        Me.pnlBuyerName.TabIndex = 0
        '
        'txbTelMP
        '
        Me.txbTelMP.BackColor = System.Drawing.SystemColors.Window
        Me.txbTelMP.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbTelMP.Location = New System.Drawing.Point(62, 29)
        Me.txbTelMP.MaxLength = 20
        Me.txbTelMP.Name = "txbTelMP"
        Me.txbTelMP.Size = New System.Drawing.Size(115, 21)
        Me.txbTelMP.TabIndex = 4
        Me.txbTelMP.Visible = False
        '
        'txbBuyerName
        '
        Me.txbBuyerName.Location = New System.Drawing.Point(62, 2)
        Me.txbBuyerName.MaxLength = 20
        Me.txbBuyerName.Name = "txbBuyerName"
        Me.txbBuyerName.Size = New System.Drawing.Size(115, 21)
        Me.txbBuyerName.TabIndex = 1
        Me.txbBuyerName.Visible = False
        '
        'cbbBuyerName
        '
        Me.cbbBuyerName.IntegralHeight = False
        Me.cbbBuyerName.Location = New System.Drawing.Point(62, 2)
        Me.cbbBuyerName.MaxDropDownItems = 15
        Me.cbbBuyerName.MaxLength = 20
        Me.cbbBuyerName.Name = "cbbBuyerName"
        Me.cbbBuyerName.Size = New System.Drawing.Size(115, 20)
        Me.cbbBuyerName.TabIndex = 2
        Me.cbbBuyerName.Visible = False
        '
        'cbbTelMP
        '
        Me.cbbTelMP.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cbbTelMP.IntegralHeight = False
        Me.cbbTelMP.Location = New System.Drawing.Point(62, 29)
        Me.cbbTelMP.MaxLength = 20
        Me.cbbTelMP.Name = "cbbTelMP"
        Me.cbbTelMP.Size = New System.Drawing.Size(115, 20)
        Me.cbbTelMP.TabIndex = 11
        Me.cbbTelMP.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(0, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "姓    名："
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(0, 35)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 12)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "联系电话："
        '
        'pnlBuyerCredentials
        '
        Me.pnlBuyerCredentials.Controls.Add(Me.txbBuyerCredentialsNo)
        Me.pnlBuyerCredentials.Controls.Add(Me.Label118)
        Me.pnlBuyerCredentials.Controls.Add(Me.cbbBuyerCredentialsType)
        Me.pnlBuyerCredentials.Controls.Add(Me.txbBuyerCredentialsType)
        Me.pnlBuyerCredentials.Controls.Add(Me.Label117)
        Me.pnlBuyerCredentials.Location = New System.Drawing.Point(6, 70)
        Me.pnlBuyerCredentials.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlBuyerCredentials.Name = "pnlBuyerCredentials"
        Me.pnlBuyerCredentials.Size = New System.Drawing.Size(179, 55)
        Me.pnlBuyerCredentials.TabIndex = 1
        '
        'txbBuyerCredentialsNo
        '
        Me.txbBuyerCredentialsNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txbBuyerCredentialsNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbBuyerCredentialsNo.Location = New System.Drawing.Point(62, 32)
        Me.txbBuyerCredentialsNo.MaxLength = 50
        Me.txbBuyerCredentialsNo.Name = "txbBuyerCredentialsNo"
        Me.txbBuyerCredentialsNo.Size = New System.Drawing.Size(115, 21)
        Me.txbBuyerCredentialsNo.TabIndex = 4
        '
        'Label118
        '
        Me.Label118.AutoSize = True
        Me.Label118.Location = New System.Drawing.Point(0, 37)
        Me.Label118.Name = "Label118"
        Me.Label118.Size = New System.Drawing.Size(65, 12)
        Me.Label118.TabIndex = 3
        Me.Label118.Text = "证件号码："
        '
        'cbbBuyerCredentialsType
        '
        Me.cbbBuyerCredentialsType.FormattingEnabled = True
        Me.cbbBuyerCredentialsType.Items.AddRange(New Object() {"居民身份证", "户口簿", "军人身份证件", "武警身份证件", "港澳台居民通行证", "护照"})
        Me.cbbBuyerCredentialsType.Location = New System.Drawing.Point(62, 5)
        Me.cbbBuyerCredentialsType.MaxLength = 50
        Me.cbbBuyerCredentialsType.Name = "cbbBuyerCredentialsType"
        Me.cbbBuyerCredentialsType.Size = New System.Drawing.Size(115, 20)
        Me.cbbBuyerCredentialsType.TabIndex = 1
        '
        'txbBuyerCredentialsType
        '
        Me.txbBuyerCredentialsType.Location = New System.Drawing.Point(62, 5)
        Me.txbBuyerCredentialsType.MaxLength = 50
        Me.txbBuyerCredentialsType.Name = "txbBuyerCredentialsType"
        Me.txbBuyerCredentialsType.ReadOnly = True
        Me.txbBuyerCredentialsType.Size = New System.Drawing.Size(115, 21)
        Me.txbBuyerCredentialsType.TabIndex = 2
        '
        'Label117
        '
        Me.Label117.AutoSize = True
        Me.Label117.Location = New System.Drawing.Point(0, 9)
        Me.Label117.Name = "Label117"
        Me.Label117.Size = New System.Drawing.Size(65, 12)
        Me.Label117.TabIndex = 0
        Me.Label117.Text = "证件类型："
        '
        'grbMemberInfo
        '
        Me.grbMemberInfo.Controls.Add(Me.txbOldMemberCardNo)
        Me.grbMemberInfo.Controls.Add(Me.txbNewMemberCardNo)
        Me.grbMemberInfo.Controls.Add(Me.txbMemberAddress)
        Me.grbMemberInfo.Controls.Add(Me.txbMemberTel)
        Me.grbMemberInfo.Controls.Add(Me.txbMemberIDNo)
        Me.grbMemberInfo.Controls.Add(Me.Label121)
        Me.grbMemberInfo.Controls.Add(Me.txbMemberName)
        Me.grbMemberInfo.Controls.Add(Me.Label125)
        Me.grbMemberInfo.Controls.Add(Me.Label124)
        Me.grbMemberInfo.Controls.Add(Me.Label123)
        Me.grbMemberInfo.Controls.Add(Me.Label120)
        Me.grbMemberInfo.Controls.Add(Me.Label122)
        Me.grbMemberInfo.Location = New System.Drawing.Point(0, 1469)
        Me.grbMemberInfo.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Me.grbMemberInfo.Name = "grbMemberInfo"
        Me.grbMemberInfo.Size = New System.Drawing.Size(193, 230)
        Me.grbMemberInfo.TabIndex = 6
        Me.grbMemberInfo.TabStop = False
        Me.grbMemberInfo.Text = "请完善会员信息："
        '
        'txbOldMemberCardNo
        '
        Me.txbOldMemberCardNo.BackColor = System.Drawing.SystemColors.Window
        Me.txbOldMemberCardNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbOldMemberCardNo.Location = New System.Drawing.Point(9, 196)
        Me.txbOldMemberCardNo.MaxLength = 20
        Me.txbOldMemberCardNo.Name = "txbOldMemberCardNo"
        Me.txbOldMemberCardNo.Size = New System.Drawing.Size(174, 21)
        Me.txbOldMemberCardNo.TabIndex = 11
        '
        'txbNewMemberCardNo
        '
        Me.txbNewMemberCardNo.BackColor = System.Drawing.SystemColors.Window
        Me.txbNewMemberCardNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbNewMemberCardNo.Location = New System.Drawing.Point(9, 156)
        Me.txbNewMemberCardNo.MaxLength = 20
        Me.txbNewMemberCardNo.Name = "txbNewMemberCardNo"
        Me.txbNewMemberCardNo.Size = New System.Drawing.Size(174, 21)
        Me.txbNewMemberCardNo.TabIndex = 9
        '
        'txbMemberAddress
        '
        Me.txbMemberAddress.BackColor = System.Drawing.SystemColors.Window
        Me.txbMemberAddress.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txbMemberAddress.Location = New System.Drawing.Point(9, 116)
        Me.txbMemberAddress.MaxLength = 100
        Me.txbMemberAddress.Name = "txbMemberAddress"
        Me.txbMemberAddress.Size = New System.Drawing.Size(174, 21)
        Me.txbMemberAddress.TabIndex = 7
        '
        'txbMemberTel
        '
        Me.txbMemberTel.BackColor = System.Drawing.SystemColors.Window
        Me.txbMemberTel.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbMemberTel.Location = New System.Drawing.Point(68, 74)
        Me.txbMemberTel.MaxLength = 20
        Me.txbMemberTel.Name = "txbMemberTel"
        Me.txbMemberTel.Size = New System.Drawing.Size(115, 21)
        Me.txbMemberTel.TabIndex = 5
        '
        'txbMemberIDNo
        '
        Me.txbMemberIDNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txbMemberIDNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbMemberIDNo.Location = New System.Drawing.Point(68, 47)
        Me.txbMemberIDNo.MaxLength = 18
        Me.txbMemberIDNo.Name = "txbMemberIDNo"
        Me.txbMemberIDNo.Size = New System.Drawing.Size(115, 21)
        Me.txbMemberIDNo.TabIndex = 3
        '
        'Label121
        '
        Me.Label121.AutoSize = True
        Me.Label121.Location = New System.Drawing.Point(6, 52)
        Me.Label121.Name = "Label121"
        Me.Label121.Size = New System.Drawing.Size(65, 12)
        Me.Label121.TabIndex = 2
        Me.Label121.Text = "身份证号："
        '
        'txbMemberName
        '
        Me.txbMemberName.Location = New System.Drawing.Point(68, 20)
        Me.txbMemberName.MaxLength = 20
        Me.txbMemberName.Name = "txbMemberName"
        Me.txbMemberName.Size = New System.Drawing.Size(115, 21)
        Me.txbMemberName.TabIndex = 1
        '
        'Label125
        '
        Me.Label125.AutoSize = True
        Me.Label125.Location = New System.Drawing.Point(5, 181)
        Me.Label125.Name = "Label125"
        Me.Label125.Size = New System.Drawing.Size(167, 12)
        Me.Label125.TabIndex = 10
        Me.Label125.Text = "旧积分卡号（20 位条形码）："
        '
        'Label124
        '
        Me.Label124.AutoSize = True
        Me.Label124.Location = New System.Drawing.Point(5, 141)
        Me.Label124.Name = "Label124"
        Me.Label124.Size = New System.Drawing.Size(167, 12)
        Me.Label124.TabIndex = 8
        Me.Label124.Text = "新积分卡号（20 位条形码）："
        '
        'Label123
        '
        Me.Label123.AutoSize = True
        Me.Label123.Location = New System.Drawing.Point(6, 101)
        Me.Label123.Name = "Label123"
        Me.Label123.Size = New System.Drawing.Size(65, 12)
        Me.Label123.TabIndex = 6
        Me.Label123.Text = "联系地址："
        '
        'Label120
        '
        Me.Label120.AutoSize = True
        Me.Label120.Location = New System.Drawing.Point(6, 25)
        Me.Label120.Name = "Label120"
        Me.Label120.Size = New System.Drawing.Size(65, 12)
        Me.Label120.TabIndex = 0
        Me.Label120.Text = "会员姓名："
        '
        'Label122
        '
        Me.Label122.AutoSize = True
        Me.Label122.Location = New System.Drawing.Point(6, 80)
        Me.Label122.Name = "Label122"
        Me.Label122.Size = New System.Drawing.Size(65, 12)
        Me.Label122.TabIndex = 4
        Me.Label122.Text = "联系电话："
        '
        'grbBalanceContract
        '
        Me.grbBalanceContract.Controls.Add(Me.flpBalanceContract)
        Me.grbBalanceContract.Controls.Add(Me.txbBalanceContractBalanceRebateAMT)
        Me.grbBalanceContract.Controls.Add(Me.Label66)
        Me.grbBalanceContract.Controls.Add(Me.Label67)
        Me.grbBalanceContract.Controls.Add(Me.txbBalanceContractCode)
        Me.grbBalanceContract.Controls.Add(Me.btnViewBalanceContract)
        Me.grbBalanceContract.Controls.Add(Me.Label62)
        Me.grbBalanceContract.Controls.Add(Me.lblBalanceContract)
        Me.grbBalanceContract.Controls.Add(Me.chbBalanceContract)
        Me.grbBalanceContract.Location = New System.Drawing.Point(0, 1705)
        Me.grbBalanceContract.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Me.grbBalanceContract.Name = "grbBalanceContract"
        Me.grbBalanceContract.Size = New System.Drawing.Size(193, 196)
        Me.grbBalanceContract.TabIndex = 7
        Me.grbBalanceContract.TabStop = False
        Me.grbBalanceContract.Text = "是否结算上期合同剩余返点？"
        '
        'flpBalanceContract
        '
        Me.flpBalanceContract.AutoSize = True
        Me.flpBalanceContract.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpBalanceContract.Controls.Add(Me.pnlPreviousDistribution)
        Me.flpBalanceContract.Controls.Add(Me.pnlPreviousBalance)
        Me.flpBalanceContract.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpBalanceContract.Location = New System.Drawing.Point(6, 105)
        Me.flpBalanceContract.Name = "flpBalanceContract"
        Me.flpBalanceContract.Size = New System.Drawing.Size(179, 86)
        Me.flpBalanceContract.TabIndex = 8
        '
        'pnlPreviousDistribution
        '
        Me.pnlPreviousDistribution.Controls.Add(Me.txbPreviousDistribution)
        Me.pnlPreviousDistribution.Controls.Add(Me.Label68)
        Me.pnlPreviousDistribution.Controls.Add(Me.Label69)
        Me.pnlPreviousDistribution.Location = New System.Drawing.Point(0, 0)
        Me.pnlPreviousDistribution.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlPreviousDistribution.Name = "pnlPreviousDistribution"
        Me.pnlPreviousDistribution.Size = New System.Drawing.Size(179, 43)
        Me.pnlPreviousDistribution.TabIndex = 0
        '
        'txbPreviousDistribution
        '
        Me.txbPreviousDistribution.Location = New System.Drawing.Point(5, 15)
        Me.txbPreviousDistribution.Name = "txbPreviousDistribution"
        Me.txbPreviousDistribution.ReadOnly = True
        Me.txbPreviousDistribution.Size = New System.Drawing.Size(155, 21)
        Me.txbPreviousDistribution.TabIndex = 1
        Me.txbPreviousDistribution.Text = "0.00"
        Me.txbPreviousDistribution.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label68.ForeColor = System.Drawing.Color.Maroon
        Me.Label68.Location = New System.Drawing.Point(0, 0)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(135, 12)
        Me.Label68.TabIndex = 0
        Me.Label68.Text = "本次已分配返点金额："
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Location = New System.Drawing.Point(162, 20)
        Me.Label69.Margin = New System.Windows.Forms.Padding(0)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(17, 12)
        Me.Label69.TabIndex = 2
        Me.Label69.Text = "元"
        Me.Label69.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlPreviousBalance
        '
        Me.pnlPreviousBalance.Controls.Add(Me.txbPreviousBalance)
        Me.pnlPreviousBalance.Controls.Add(Me.Label70)
        Me.pnlPreviousBalance.Controls.Add(Me.Label71)
        Me.pnlPreviousBalance.Location = New System.Drawing.Point(0, 43)
        Me.pnlPreviousBalance.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlPreviousBalance.Name = "pnlPreviousBalance"
        Me.pnlPreviousBalance.Size = New System.Drawing.Size(179, 43)
        Me.pnlPreviousBalance.TabIndex = 1
        Me.pnlPreviousBalance.Visible = False
        '
        'txbPreviousBalance
        '
        Me.txbPreviousBalance.Location = New System.Drawing.Point(5, 15)
        Me.txbPreviousBalance.Name = "txbPreviousBalance"
        Me.txbPreviousBalance.ReadOnly = True
        Me.txbPreviousBalance.Size = New System.Drawing.Size(155, 21)
        Me.txbPreviousBalance.TabIndex = 1
        Me.txbPreviousBalance.Text = "0.00"
        Me.txbPreviousBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label70.ForeColor = System.Drawing.Color.Maroon
        Me.Label70.Location = New System.Drawing.Point(0, 0)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(96, 12)
        Me.Label70.TabIndex = 0
        Me.Label70.Text = "剩余返点金额："
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Location = New System.Drawing.Point(162, 20)
        Me.Label71.Margin = New System.Windows.Forms.Padding(0)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(17, 12)
        Me.Label71.TabIndex = 2
        Me.Label71.Text = "元"
        Me.Label71.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txbBalanceContractBalanceRebateAMT
        '
        Me.txbBalanceContractBalanceRebateAMT.Location = New System.Drawing.Point(47, 75)
        Me.txbBalanceContractBalanceRebateAMT.Name = "txbBalanceContractBalanceRebateAMT"
        Me.txbBalanceContractBalanceRebateAMT.ReadOnly = True
        Me.txbBalanceContractBalanceRebateAMT.Size = New System.Drawing.Size(118, 21)
        Me.txbBalanceContractBalanceRebateAMT.TabIndex = 6
        Me.txbBalanceContractBalanceRebateAMT.Text = "0.00"
        Me.txbBalanceContractBalanceRebateAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Location = New System.Drawing.Point(168, 80)
        Me.Label66.Margin = New System.Windows.Forms.Padding(0)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(17, 12)
        Me.Label66.TabIndex = 7
        Me.Label66.Text = "元"
        Me.Label66.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Location = New System.Drawing.Point(8, 80)
        Me.Label67.Margin = New System.Windows.Forms.Padding(0)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(41, 12)
        Me.Label67.TabIndex = 5
        Me.Label67.Text = "金额："
        Me.Label67.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.theTip.SetToolTip(Me.Label67, "上期合同剩余的返点金额")
        '
        'txbBalanceContractCode
        '
        Me.txbBalanceContractCode.Location = New System.Drawing.Point(47, 48)
        Me.txbBalanceContractCode.Name = "txbBalanceContractCode"
        Me.txbBalanceContractCode.ReadOnly = True
        Me.txbBalanceContractCode.Size = New System.Drawing.Size(84, 21)
        Me.txbBalanceContractCode.TabIndex = 3
        '
        'btnViewBalanceContract
        '
        Me.btnViewBalanceContract.Location = New System.Drawing.Point(135, 47)
        Me.btnViewBalanceContract.Name = "btnViewBalanceContract"
        Me.btnViewBalanceContract.Size = New System.Drawing.Size(48, 23)
        Me.btnViewBalanceContract.TabIndex = 4
        Me.btnViewBalanceContract.Text = "查看"
        Me.btnViewBalanceContract.UseVisualStyleBackColor = True
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Location = New System.Drawing.Point(8, 52)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(41, 12)
        Me.Label62.TabIndex = 2
        Me.Label62.Text = "合同："
        Me.theTip.SetToolTip(Me.Label62, "上期合同编号")
        '
        'lblBalanceContract
        '
        Me.lblBalanceContract.AutoSize = True
        Me.lblBalanceContract.Location = New System.Drawing.Point(29, 24)
        Me.lblBalanceContract.Name = "lblBalanceContract"
        Me.lblBalanceContract.Size = New System.Drawing.Size(125, 12)
        Me.lblBalanceContract.TabIndex = 1
        Me.lblBalanceContract.Text = "结算上期合同剩余返点"
        '
        'chbBalanceContract
        '
        Me.chbBalanceContract.AutoSize = True
        Me.chbBalanceContract.Location = New System.Drawing.Point(11, 23)
        Me.chbBalanceContract.Name = "chbBalanceContract"
        Me.chbBalanceContract.Size = New System.Drawing.Size(15, 14)
        Me.chbBalanceContract.TabIndex = 0
        Me.chbBalanceContract.UseVisualStyleBackColor = True
        '
        'grbContract
        '
        Me.grbContract.Controls.Add(Me.flpContract)
        Me.grbContract.Controls.Add(Me.txbContractCode)
        Me.grbContract.Controls.Add(Me.btnViewContract)
        Me.grbContract.Controls.Add(Me.Label26)
        Me.grbContract.Controls.Add(Me.lblContract)
        Me.grbContract.Controls.Add(Me.chbContract)
        Me.grbContract.Location = New System.Drawing.Point(0, 1907)
        Me.grbContract.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Me.grbContract.Name = "grbContract"
        Me.grbContract.Size = New System.Drawing.Size(193, 477)
        Me.grbContract.TabIndex = 8
        Me.grbContract.TabStop = False
        Me.grbContract.Text = "是否使用当前合同？"
        '
        'flpContract
        '
        Me.flpContract.AutoSize = True
        Me.flpContract.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpContract.Controls.Add(Me.pnlThisPurchaseRebate)
        Me.flpContract.Controls.Add(Me.pnlHistoryPurchaseRebate)
        Me.flpContract.Controls.Add(Me.pnlAvailableRebateSalesAMT)
        Me.flpContract.Controls.Add(Me.pnlRebatSalesAMT)
        Me.flpContract.Controls.Add(Me.pnlBalanceRebateAMT)
        Me.flpContract.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpContract.Location = New System.Drawing.Point(6, 78)
        Me.flpContract.Margin = New System.Windows.Forms.Padding(0)
        Me.flpContract.Name = "flpContract"
        Me.flpContract.Size = New System.Drawing.Size(179, 394)
        Me.flpContract.TabIndex = 1
        '
        'pnlThisPurchaseRebate
        '
        Me.pnlThisPurchaseRebate.Controls.Add(Me.pnlThisPurchaseRemarks)
        Me.pnlThisPurchaseRebate.Controls.Add(Me.txbThisRebateAMT)
        Me.pnlThisPurchaseRebate.Controls.Add(Me.txbThisRebateRate)
        Me.pnlThisPurchaseRebate.Controls.Add(Me.Label33)
        Me.pnlThisPurchaseRebate.Controls.Add(Me.txbThisSalesAMT)
        Me.pnlThisPurchaseRebate.Controls.Add(Me.Label31)
        Me.pnlThisPurchaseRebate.Controls.Add(Me.lblThisRebateAMT)
        Me.pnlThisPurchaseRebate.Controls.Add(Me.lblThisPurchaseRebate)
        Me.pnlThisPurchaseRebate.Controls.Add(Me.lblThisRebateRate)
        Me.pnlThisPurchaseRebate.Controls.Add(Me.Label27)
        Me.pnlThisPurchaseRebate.Controls.Add(Me.lblThisSalesAMT)
        Me.pnlThisPurchaseRebate.Location = New System.Drawing.Point(0, 0)
        Me.pnlThisPurchaseRebate.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlThisPurchaseRebate.Name = "pnlThisPurchaseRebate"
        Me.pnlThisPurchaseRebate.Size = New System.Drawing.Size(179, 119)
        Me.pnlThisPurchaseRebate.TabIndex = 0
        '
        'pnlThisPurchaseRemarks
        '
        Me.pnlThisPurchaseRemarks.Controls.Add(Me.lblThisPurchaseRemarks)
        Me.pnlThisPurchaseRemarks.Controls.Add(Me.Label34)
        Me.pnlThisPurchaseRemarks.Location = New System.Drawing.Point(0, 95)
        Me.pnlThisPurchaseRemarks.Name = "pnlThisPurchaseRemarks"
        Me.pnlThisPurchaseRemarks.Size = New System.Drawing.Size(179, 21)
        Me.pnlThisPurchaseRemarks.TabIndex = 10
        '
        'lblThisPurchaseRemarks
        '
        Me.lblThisPurchaseRemarks.AutoSize = True
        Me.lblThisPurchaseRemarks.Location = New System.Drawing.Point(39, 4)
        Me.lblThisPurchaseRemarks.Margin = New System.Windows.Forms.Padding(0)
        Me.lblThisPurchaseRemarks.Name = "lblThisPurchaseRemarks"
        Me.lblThisPurchaseRemarks.Size = New System.Drawing.Size(0, 12)
        Me.lblThisPurchaseRemarks.TabIndex = 1
        Me.lblThisPurchaseRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(4, 4)
        Me.Label34.Margin = New System.Windows.Forms.Padding(0)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(41, 12)
        Me.Label34.TabIndex = 0
        Me.Label34.Text = "备注："
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txbThisRebateAMT
        '
        Me.txbThisRebateAMT.Location = New System.Drawing.Point(41, 69)
        Me.txbThisRebateAMT.Name = "txbThisRebateAMT"
        Me.txbThisRebateAMT.ReadOnly = True
        Me.txbThisRebateAMT.Size = New System.Drawing.Size(118, 21)
        Me.txbThisRebateAMT.TabIndex = 8
        Me.txbThisRebateAMT.Text = "0.00"
        Me.txbThisRebateAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txbThisRebateRate
        '
        Me.txbThisRebateRate.Location = New System.Drawing.Point(41, 42)
        Me.txbThisRebateRate.Name = "txbThisRebateRate"
        Me.txbThisRebateRate.ReadOnly = True
        Me.txbThisRebateRate.Size = New System.Drawing.Size(118, 21)
        Me.txbThisRebateRate.TabIndex = 5
        Me.txbThisRebateRate.Text = "0.0"
        Me.txbThisRebateRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(162, 74)
        Me.Label33.Margin = New System.Windows.Forms.Padding(0)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(17, 12)
        Me.Label33.TabIndex = 9
        Me.Label33.Text = "元"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txbThisSalesAMT
        '
        Me.txbThisSalesAMT.Location = New System.Drawing.Point(41, 15)
        Me.txbThisSalesAMT.Name = "txbThisSalesAMT"
        Me.txbThisSalesAMT.ReadOnly = True
        Me.txbThisSalesAMT.Size = New System.Drawing.Size(118, 21)
        Me.txbThisSalesAMT.TabIndex = 2
        Me.txbThisSalesAMT.Text = "0.00"
        Me.txbThisSalesAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(165, 47)
        Me.Label31.Margin = New System.Windows.Forms.Padding(0)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(11, 12)
        Me.Label31.TabIndex = 6
        Me.Label31.Text = "%"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblThisRebateAMT
        '
        Me.lblThisRebateAMT.AutoSize = True
        Me.lblThisRebateAMT.Location = New System.Drawing.Point(4, 74)
        Me.lblThisRebateAMT.Margin = New System.Windows.Forms.Padding(0)
        Me.lblThisRebateAMT.Name = "lblThisRebateAMT"
        Me.lblThisRebateAMT.Size = New System.Drawing.Size(41, 12)
        Me.lblThisRebateAMT.TabIndex = 7
        Me.lblThisRebateAMT.Text = "金额："
        Me.lblThisRebateAMT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblThisPurchaseRebate
        '
        Me.lblThisPurchaseRebate.AutoSize = True
        Me.lblThisPurchaseRebate.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblThisPurchaseRebate.ForeColor = System.Drawing.Color.Maroon
        Me.lblThisPurchaseRebate.Location = New System.Drawing.Point(0, 0)
        Me.lblThisPurchaseRebate.Name = "lblThisPurchaseRebate"
        Me.lblThisPurchaseRebate.Size = New System.Drawing.Size(122, 12)
        Me.lblThisPurchaseRebate.TabIndex = 0
        Me.lblThisPurchaseRebate.Text = "本次购买返点计算："
        '
        'lblThisRebateRate
        '
        Me.lblThisRebateRate.AutoSize = True
        Me.lblThisRebateRate.Location = New System.Drawing.Point(4, 47)
        Me.lblThisRebateRate.Margin = New System.Windows.Forms.Padding(0)
        Me.lblThisRebateRate.Name = "lblThisRebateRate"
        Me.lblThisRebateRate.Size = New System.Drawing.Size(41, 12)
        Me.lblThisRebateRate.TabIndex = 4
        Me.lblThisRebateRate.Text = "比率："
        Me.lblThisRebateRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(162, 20)
        Me.Label27.Margin = New System.Windows.Forms.Padding(0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(17, 12)
        Me.Label27.TabIndex = 3
        Me.Label27.Text = "元"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblThisSalesAMT
        '
        Me.lblThisSalesAMT.AutoSize = True
        Me.lblThisSalesAMT.Location = New System.Drawing.Point(4, 20)
        Me.lblThisSalesAMT.Margin = New System.Windows.Forms.Padding(0)
        Me.lblThisSalesAMT.Name = "lblThisSalesAMT"
        Me.lblThisSalesAMT.Size = New System.Drawing.Size(41, 12)
        Me.lblThisSalesAMT.TabIndex = 1
        Me.lblThisSalesAMT.Text = "购买："
        Me.lblThisSalesAMT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlHistoryPurchaseRebate
        '
        Me.pnlHistoryPurchaseRebate.Controls.Add(Me.Label44)
        Me.pnlHistoryPurchaseRebate.Controls.Add(Me.txbHistoryPaidRebateAMT)
        Me.pnlHistoryPurchaseRebate.Controls.Add(Me.lblHistoryPaidRebateAMT)
        Me.pnlHistoryPurchaseRebate.Controls.Add(Me.pnlHistoryPurchaseRemarks)
        Me.pnlHistoryPurchaseRebate.Controls.Add(Me.txbHistoryRebateAMT)
        Me.pnlHistoryPurchaseRebate.Controls.Add(Me.txbHistoryRebateRate)
        Me.pnlHistoryPurchaseRebate.Controls.Add(Me.Label37)
        Me.pnlHistoryPurchaseRebate.Controls.Add(Me.txbHistorySalesAMT)
        Me.pnlHistoryPurchaseRebate.Controls.Add(Me.Label38)
        Me.pnlHistoryPurchaseRebate.Controls.Add(Me.lblHistoryRebateAMT)
        Me.pnlHistoryPurchaseRebate.Controls.Add(Me.lblHistoryPurchaseRebate)
        Me.pnlHistoryPurchaseRebate.Controls.Add(Me.lblHistoryRebateRate)
        Me.pnlHistoryPurchaseRebate.Controls.Add(Me.Label42)
        Me.pnlHistoryPurchaseRebate.Controls.Add(Me.lblHistorySalesAMT)
        Me.pnlHistoryPurchaseRebate.Location = New System.Drawing.Point(0, 119)
        Me.pnlHistoryPurchaseRebate.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlHistoryPurchaseRebate.Name = "pnlHistoryPurchaseRebate"
        Me.pnlHistoryPurchaseRebate.Size = New System.Drawing.Size(179, 146)
        Me.pnlHistoryPurchaseRebate.TabIndex = 1
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(162, 101)
        Me.Label44.Margin = New System.Windows.Forms.Padding(0)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(17, 12)
        Me.Label44.TabIndex = 12
        Me.Label44.Text = "元"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txbHistoryPaidRebateAMT
        '
        Me.txbHistoryPaidRebateAMT.Location = New System.Drawing.Point(41, 96)
        Me.txbHistoryPaidRebateAMT.Name = "txbHistoryPaidRebateAMT"
        Me.txbHistoryPaidRebateAMT.ReadOnly = True
        Me.txbHistoryPaidRebateAMT.Size = New System.Drawing.Size(118, 21)
        Me.txbHistoryPaidRebateAMT.TabIndex = 11
        Me.txbHistoryPaidRebateAMT.Text = "0.00"
        Me.txbHistoryPaidRebateAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblHistoryPaidRebateAMT
        '
        Me.lblHistoryPaidRebateAMT.AutoSize = True
        Me.lblHistoryPaidRebateAMT.Location = New System.Drawing.Point(4, 101)
        Me.lblHistoryPaidRebateAMT.Margin = New System.Windows.Forms.Padding(0)
        Me.lblHistoryPaidRebateAMT.Name = "lblHistoryPaidRebateAMT"
        Me.lblHistoryPaidRebateAMT.Size = New System.Drawing.Size(41, 12)
        Me.lblHistoryPaidRebateAMT.TabIndex = 10
        Me.lblHistoryPaidRebateAMT.Text = "已兑："
        Me.lblHistoryPaidRebateAMT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlHistoryPurchaseRemarks
        '
        Me.pnlHistoryPurchaseRemarks.Controls.Add(Me.lblHistoryPurchaseRemarks)
        Me.pnlHistoryPurchaseRemarks.Controls.Add(Me.Label36)
        Me.pnlHistoryPurchaseRemarks.Location = New System.Drawing.Point(0, 122)
        Me.pnlHistoryPurchaseRemarks.Name = "pnlHistoryPurchaseRemarks"
        Me.pnlHistoryPurchaseRemarks.Size = New System.Drawing.Size(179, 21)
        Me.pnlHistoryPurchaseRemarks.TabIndex = 13
        '
        'lblHistoryPurchaseRemarks
        '
        Me.lblHistoryPurchaseRemarks.AutoSize = True
        Me.lblHistoryPurchaseRemarks.Location = New System.Drawing.Point(39, 4)
        Me.lblHistoryPurchaseRemarks.Margin = New System.Windows.Forms.Padding(0)
        Me.lblHistoryPurchaseRemarks.Name = "lblHistoryPurchaseRemarks"
        Me.lblHistoryPurchaseRemarks.Size = New System.Drawing.Size(0, 12)
        Me.lblHistoryPurchaseRemarks.TabIndex = 1
        Me.lblHistoryPurchaseRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(4, 4)
        Me.Label36.Margin = New System.Windows.Forms.Padding(0)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(41, 12)
        Me.Label36.TabIndex = 0
        Me.Label36.Text = "备注："
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txbHistoryRebateAMT
        '
        Me.txbHistoryRebateAMT.Location = New System.Drawing.Point(41, 69)
        Me.txbHistoryRebateAMT.Name = "txbHistoryRebateAMT"
        Me.txbHistoryRebateAMT.ReadOnly = True
        Me.txbHistoryRebateAMT.Size = New System.Drawing.Size(118, 21)
        Me.txbHistoryRebateAMT.TabIndex = 8
        Me.txbHistoryRebateAMT.Text = "0.00"
        Me.txbHistoryRebateAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txbHistoryRebateRate
        '
        Me.txbHistoryRebateRate.Location = New System.Drawing.Point(41, 42)
        Me.txbHistoryRebateRate.Name = "txbHistoryRebateRate"
        Me.txbHistoryRebateRate.ReadOnly = True
        Me.txbHistoryRebateRate.Size = New System.Drawing.Size(118, 21)
        Me.txbHistoryRebateRate.TabIndex = 5
        Me.txbHistoryRebateRate.Text = "0.0"
        Me.txbHistoryRebateRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(162, 74)
        Me.Label37.Margin = New System.Windows.Forms.Padding(0)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(17, 12)
        Me.Label37.TabIndex = 9
        Me.Label37.Text = "元"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txbHistorySalesAMT
        '
        Me.txbHistorySalesAMT.Location = New System.Drawing.Point(41, 15)
        Me.txbHistorySalesAMT.Name = "txbHistorySalesAMT"
        Me.txbHistorySalesAMT.ReadOnly = True
        Me.txbHistorySalesAMT.Size = New System.Drawing.Size(118, 21)
        Me.txbHistorySalesAMT.TabIndex = 2
        Me.txbHistorySalesAMT.Text = "0.00"
        Me.txbHistorySalesAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(165, 47)
        Me.Label38.Margin = New System.Windows.Forms.Padding(0)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(11, 12)
        Me.Label38.TabIndex = 6
        Me.Label38.Text = "%"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblHistoryRebateAMT
        '
        Me.lblHistoryRebateAMT.AutoSize = True
        Me.lblHistoryRebateAMT.Location = New System.Drawing.Point(4, 74)
        Me.lblHistoryRebateAMT.Margin = New System.Windows.Forms.Padding(0)
        Me.lblHistoryRebateAMT.Name = "lblHistoryRebateAMT"
        Me.lblHistoryRebateAMT.Size = New System.Drawing.Size(41, 12)
        Me.lblHistoryRebateAMT.TabIndex = 7
        Me.lblHistoryRebateAMT.Text = "金额："
        Me.lblHistoryRebateAMT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblHistoryPurchaseRebate
        '
        Me.lblHistoryPurchaseRebate.AutoSize = True
        Me.lblHistoryPurchaseRebate.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHistoryPurchaseRebate.ForeColor = System.Drawing.Color.Maroon
        Me.lblHistoryPurchaseRebate.Location = New System.Drawing.Point(0, 0)
        Me.lblHistoryPurchaseRebate.Name = "lblHistoryPurchaseRebate"
        Me.lblHistoryPurchaseRebate.Size = New System.Drawing.Size(122, 12)
        Me.lblHistoryPurchaseRebate.TabIndex = 0
        Me.lblHistoryPurchaseRebate.Text = "历史购买返点计算："
        '
        'lblHistoryRebateRate
        '
        Me.lblHistoryRebateRate.AutoSize = True
        Me.lblHistoryRebateRate.Location = New System.Drawing.Point(4, 47)
        Me.lblHistoryRebateRate.Margin = New System.Windows.Forms.Padding(0)
        Me.lblHistoryRebateRate.Name = "lblHistoryRebateRate"
        Me.lblHistoryRebateRate.Size = New System.Drawing.Size(41, 12)
        Me.lblHistoryRebateRate.TabIndex = 4
        Me.lblHistoryRebateRate.Text = "比率："
        Me.lblHistoryRebateRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(162, 20)
        Me.Label42.Margin = New System.Windows.Forms.Padding(0)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(17, 12)
        Me.Label42.TabIndex = 3
        Me.Label42.Text = "元"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblHistorySalesAMT
        '
        Me.lblHistorySalesAMT.AutoSize = True
        Me.lblHistorySalesAMT.Location = New System.Drawing.Point(4, 20)
        Me.lblHistorySalesAMT.Margin = New System.Windows.Forms.Padding(0)
        Me.lblHistorySalesAMT.Name = "lblHistorySalesAMT"
        Me.lblHistorySalesAMT.Size = New System.Drawing.Size(41, 12)
        Me.lblHistorySalesAMT.TabIndex = 1
        Me.lblHistorySalesAMT.Text = "购买："
        Me.lblHistorySalesAMT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlAvailableRebateSalesAMT
        '
        Me.pnlAvailableRebateSalesAMT.Controls.Add(Me.txbAvailableRebateSalesAMT)
        Me.pnlAvailableRebateSalesAMT.Controls.Add(Me.lblAvailableRebateAMT)
        Me.pnlAvailableRebateSalesAMT.Controls.Add(Me.Label46)
        Me.pnlAvailableRebateSalesAMT.Location = New System.Drawing.Point(0, 265)
        Me.pnlAvailableRebateSalesAMT.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlAvailableRebateSalesAMT.Name = "pnlAvailableRebateSalesAMT"
        Me.pnlAvailableRebateSalesAMT.Size = New System.Drawing.Size(179, 43)
        Me.pnlAvailableRebateSalesAMT.TabIndex = 2
        '
        'txbAvailableRebateSalesAMT
        '
        Me.txbAvailableRebateSalesAMT.Location = New System.Drawing.Point(5, 15)
        Me.txbAvailableRebateSalesAMT.Name = "txbAvailableRebateSalesAMT"
        Me.txbAvailableRebateSalesAMT.ReadOnly = True
        Me.txbAvailableRebateSalesAMT.Size = New System.Drawing.Size(155, 21)
        Me.txbAvailableRebateSalesAMT.TabIndex = 1
        Me.txbAvailableRebateSalesAMT.Text = "0.00"
        Me.txbAvailableRebateSalesAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAvailableRebateAMT
        '
        Me.lblAvailableRebateAMT.AutoSize = True
        Me.lblAvailableRebateAMT.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvailableRebateAMT.ForeColor = System.Drawing.Color.Maroon
        Me.lblAvailableRebateAMT.Location = New System.Drawing.Point(0, 0)
        Me.lblAvailableRebateAMT.Name = "lblAvailableRebateAMT"
        Me.lblAvailableRebateAMT.Size = New System.Drawing.Size(148, 12)
        Me.lblAvailableRebateAMT.TabIndex = 0
        Me.lblAvailableRebateAMT.Text = "本次最大可兑返点金额："
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(162, 20)
        Me.Label46.Margin = New System.Windows.Forms.Padding(0)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(17, 12)
        Me.Label46.TabIndex = 2
        Me.Label46.Text = "元"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlRebatSalesAMT
        '
        Me.pnlRebatSalesAMT.Controls.Add(Me.txbRebateSalesAMT)
        Me.pnlRebatSalesAMT.Controls.Add(Me.lblRebateSalesAMT)
        Me.pnlRebatSalesAMT.Controls.Add(Me.Label48)
        Me.pnlRebatSalesAMT.Location = New System.Drawing.Point(0, 308)
        Me.pnlRebatSalesAMT.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlRebatSalesAMT.Name = "pnlRebatSalesAMT"
        Me.pnlRebatSalesAMT.Size = New System.Drawing.Size(179, 43)
        Me.pnlRebatSalesAMT.TabIndex = 3
        '
        'txbRebateSalesAMT
        '
        Me.txbRebateSalesAMT.Location = New System.Drawing.Point(5, 15)
        Me.txbRebateSalesAMT.Name = "txbRebateSalesAMT"
        Me.txbRebateSalesAMT.ReadOnly = True
        Me.txbRebateSalesAMT.Size = New System.Drawing.Size(155, 21)
        Me.txbRebateSalesAMT.TabIndex = 1
        Me.txbRebateSalesAMT.Text = "0.00"
        Me.txbRebateSalesAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRebateSalesAMT
        '
        Me.lblRebateSalesAMT.AutoSize = True
        Me.lblRebateSalesAMT.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRebateSalesAMT.ForeColor = System.Drawing.Color.Maroon
        Me.lblRebateSalesAMT.Location = New System.Drawing.Point(0, 0)
        Me.lblRebateSalesAMT.Name = "lblRebateSalesAMT"
        Me.lblRebateSalesAMT.Size = New System.Drawing.Size(135, 12)
        Me.lblRebateSalesAMT.TabIndex = 0
        Me.lblRebateSalesAMT.Text = "本次已分配返点金额："
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(162, 20)
        Me.Label48.Margin = New System.Windows.Forms.Padding(0)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(17, 12)
        Me.Label48.TabIndex = 2
        Me.Label48.Text = "元"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlBalanceRebateAMT
        '
        Me.pnlBalanceRebateAMT.Controls.Add(Me.txbBalanceRebateAMT)
        Me.pnlBalanceRebateAMT.Controls.Add(Me.lblBalanceRebateAMT)
        Me.pnlBalanceRebateAMT.Controls.Add(Me.Label50)
        Me.pnlBalanceRebateAMT.Location = New System.Drawing.Point(0, 351)
        Me.pnlBalanceRebateAMT.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlBalanceRebateAMT.Name = "pnlBalanceRebateAMT"
        Me.pnlBalanceRebateAMT.Size = New System.Drawing.Size(179, 43)
        Me.pnlBalanceRebateAMT.TabIndex = 4
        Me.pnlBalanceRebateAMT.Visible = False
        '
        'txbBalanceRebateAMT
        '
        Me.txbBalanceRebateAMT.Location = New System.Drawing.Point(5, 15)
        Me.txbBalanceRebateAMT.Name = "txbBalanceRebateAMT"
        Me.txbBalanceRebateAMT.ReadOnly = True
        Me.txbBalanceRebateAMT.Size = New System.Drawing.Size(155, 21)
        Me.txbBalanceRebateAMT.TabIndex = 1
        Me.txbBalanceRebateAMT.Text = "0.00"
        Me.txbBalanceRebateAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblBalanceRebateAMT
        '
        Me.lblBalanceRebateAMT.AutoSize = True
        Me.lblBalanceRebateAMT.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBalanceRebateAMT.ForeColor = System.Drawing.Color.Maroon
        Me.lblBalanceRebateAMT.Location = New System.Drawing.Point(0, 0)
        Me.lblBalanceRebateAMT.Name = "lblBalanceRebateAMT"
        Me.lblBalanceRebateAMT.Size = New System.Drawing.Size(96, 12)
        Me.lblBalanceRebateAMT.TabIndex = 0
        Me.lblBalanceRebateAMT.Text = "剩余返点金额："
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(162, 20)
        Me.Label50.Margin = New System.Windows.Forms.Padding(0)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(17, 12)
        Me.Label50.TabIndex = 2
        Me.Label50.Text = "元"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txbContractCode
        '
        Me.txbContractCode.Location = New System.Drawing.Point(47, 48)
        Me.txbContractCode.Name = "txbContractCode"
        Me.txbContractCode.ReadOnly = True
        Me.txbContractCode.Size = New System.Drawing.Size(84, 21)
        Me.txbContractCode.TabIndex = 1
        '
        'btnViewContract
        '
        Me.btnViewContract.Location = New System.Drawing.Point(135, 47)
        Me.btnViewContract.Name = "btnViewContract"
        Me.btnViewContract.Size = New System.Drawing.Size(48, 23)
        Me.btnViewContract.TabIndex = 2
        Me.btnViewContract.Text = "查看"
        Me.btnViewContract.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(8, 52)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(41, 12)
        Me.Label26.TabIndex = 0
        Me.Label26.Text = "合同："
        Me.theTip.SetToolTip(Me.Label26, "当前有效的合同编号")
        '
        'lblContract
        '
        Me.lblContract.AutoSize = True
        Me.lblContract.Location = New System.Drawing.Point(29, 24)
        Me.lblContract.Name = "lblContract"
        Me.lblContract.Size = New System.Drawing.Size(125, 12)
        Me.lblContract.TabIndex = 1
        Me.lblContract.Text = "使用当前合同计算返点"
        '
        'chbContract
        '
        Me.chbContract.AutoSize = True
        Me.chbContract.Checked = True
        Me.chbContract.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbContract.Location = New System.Drawing.Point(11, 23)
        Me.chbContract.Name = "chbContract"
        Me.chbContract.Size = New System.Drawing.Size(15, 14)
        Me.chbContract.TabIndex = 0
        Me.chbContract.UseVisualStyleBackColor = True
        '
        'grbNormalRebate
        '
        Me.grbNormalRebate.Controls.Add(Me.flpNormalRebate)
        Me.grbNormalRebate.Controls.Add(Me.lblNormalRebate)
        Me.grbNormalRebate.Controls.Add(Me.chbNormalRebate)
        Me.grbNormalRebate.Controls.Add(Me.btnViewCityRule)
        Me.grbNormalRebate.Location = New System.Drawing.Point(0, 2390)
        Me.grbNormalRebate.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Me.grbNormalRebate.Name = "grbNormalRebate"
        Me.grbNormalRebate.Size = New System.Drawing.Size(193, 376)
        Me.grbNormalRebate.TabIndex = 9
        Me.grbNormalRebate.TabStop = False
        Me.grbNormalRebate.Text = "是否给予城市返点？"
        '
        'flpNormalRebate
        '
        Me.flpNormalRebate.AutoSize = True
        Me.flpNormalRebate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpNormalRebate.Controls.Add(Me.pnlMaxNormalRebateCalculation)
        Me.flpNormalRebate.Controls.Add(Me.pnlNormalRebate)
        Me.flpNormalRebate.Controls.Add(Me.pnlNormalRebateState)
        Me.flpNormalRebate.Controls.Add(Me.pnlNormalRebateRemarks)
        Me.flpNormalRebate.Controls.Add(Me.pnlDistributionNormalRebateAMT)
        Me.flpNormalRebate.Controls.Add(Me.pnlBalanceNormalRebateAMT)
        Me.flpNormalRebate.Controls.Add(Me.pnlModifyNormalRebate)
        Me.flpNormalRebate.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpNormalRebate.Location = New System.Drawing.Point(6, 50)
        Me.flpNormalRebate.Name = "flpNormalRebate"
        Me.flpNormalRebate.Size = New System.Drawing.Size(179, 321)
        Me.flpNormalRebate.TabIndex = 5
        '
        'pnlMaxNormalRebateCalculation
        '
        Me.pnlMaxNormalRebateCalculation.Controls.Add(Me.txbMaxNormalRebateAMT)
        Me.pnlMaxNormalRebateCalculation.Controls.Add(Me.txbMaxNormalRebateRate)
        Me.pnlMaxNormalRebateCalculation.Controls.Add(Me.Label43)
        Me.pnlMaxNormalRebateCalculation.Controls.Add(Me.Label41)
        Me.pnlMaxNormalRebateCalculation.Controls.Add(Me.Label40)
        Me.pnlMaxNormalRebateCalculation.Controls.Add(Me.Label30)
        Me.pnlMaxNormalRebateCalculation.Controls.Add(Me.Label39)
        Me.pnlMaxNormalRebateCalculation.Controls.Add(Me.Label45)
        Me.pnlMaxNormalRebateCalculation.Location = New System.Drawing.Point(0, 0)
        Me.pnlMaxNormalRebateCalculation.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlMaxNormalRebateCalculation.Name = "pnlMaxNormalRebateCalculation"
        Me.pnlMaxNormalRebateCalculation.Size = New System.Drawing.Size(179, 85)
        Me.pnlMaxNormalRebateCalculation.TabIndex = 0
        '
        'txbMaxNormalRebateAMT
        '
        Me.txbMaxNormalRebateAMT.Location = New System.Drawing.Point(41, 42)
        Me.txbMaxNormalRebateAMT.Name = "txbMaxNormalRebateAMT"
        Me.txbMaxNormalRebateAMT.ReadOnly = True
        Me.txbMaxNormalRebateAMT.Size = New System.Drawing.Size(118, 21)
        Me.txbMaxNormalRebateAMT.TabIndex = 5
        Me.txbMaxNormalRebateAMT.Text = "0.00"
        Me.txbMaxNormalRebateAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txbMaxNormalRebateRate
        '
        Me.txbMaxNormalRebateRate.Location = New System.Drawing.Point(41, 15)
        Me.txbMaxNormalRebateRate.Name = "txbMaxNormalRebateRate"
        Me.txbMaxNormalRebateRate.ReadOnly = True
        Me.txbMaxNormalRebateRate.Size = New System.Drawing.Size(118, 21)
        Me.txbMaxNormalRebateRate.TabIndex = 2
        Me.txbMaxNormalRebateRate.Text = "0.0"
        Me.txbMaxNormalRebateRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(162, 47)
        Me.Label43.Margin = New System.Windows.Forms.Padding(0)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(17, 12)
        Me.Label43.TabIndex = 6
        Me.Label43.Text = "元"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(165, 20)
        Me.Label41.Margin = New System.Windows.Forms.Padding(0)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(11, 12)
        Me.Label41.TabIndex = 3
        Me.Label41.Text = "%"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(4, 47)
        Me.Label40.Margin = New System.Windows.Forms.Padding(0)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(41, 12)
        Me.Label40.TabIndex = 4
        Me.Label40.Text = "金额："
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.theTip.SetToolTip(Me.Label40, "标准范围内的最大返点金额")
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Maroon
        Me.Label30.Location = New System.Drawing.Point(0, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(174, 12)
        Me.Label30.TabIndex = 0
        Me.Label30.Text = "标准范围内的最大返点计算："
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(4, 20)
        Me.Label39.Margin = New System.Windows.Forms.Padding(0)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(41, 12)
        Me.Label39.TabIndex = 1
        Me.Label39.Text = "比率："
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.theTip.SetToolTip(Me.Label39, "标准范围内的最大返点比率")
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.Maroon
        Me.Label45.Location = New System.Drawing.Point(0, 70)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(148, 12)
        Me.Label45.TabIndex = 7
        Me.Label45.Text = "请输入返点比率或金额："
        '
        'pnlNormalRebate
        '
        Me.pnlNormalRebate.Controls.Add(Me.txbNormalRebateAMT)
        Me.pnlNormalRebate.Controls.Add(Me.txbNormalRebateRate)
        Me.pnlNormalRebate.Controls.Add(Me.Label12)
        Me.pnlNormalRebate.Controls.Add(Me.Label10)
        Me.pnlNormalRebate.Controls.Add(Me.Label1)
        Me.pnlNormalRebate.Controls.Add(Me.Label2)
        Me.pnlNormalRebate.Location = New System.Drawing.Point(0, 85)
        Me.pnlNormalRebate.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlNormalRebate.Name = "pnlNormalRebate"
        Me.pnlNormalRebate.Size = New System.Drawing.Size(179, 57)
        Me.pnlNormalRebate.TabIndex = 1
        '
        'txbNormalRebateAMT
        '
        Me.txbNormalRebateAMT.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbNormalRebateAMT.Location = New System.Drawing.Point(41, 28)
        Me.txbNormalRebateAMT.MaxLength = 10
        Me.txbNormalRebateAMT.Name = "txbNormalRebateAMT"
        Me.txbNormalRebateAMT.Size = New System.Drawing.Size(118, 21)
        Me.txbNormalRebateAMT.TabIndex = 4
        Me.txbNormalRebateAMT.Text = "0.00"
        Me.txbNormalRebateAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txbNormalRebateRate
        '
        Me.txbNormalRebateRate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txbNormalRebateRate.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbNormalRebateRate.Location = New System.Drawing.Point(41, 1)
        Me.txbNormalRebateRate.MaxLength = 4
        Me.txbNormalRebateRate.Name = "txbNormalRebateRate"
        Me.txbNormalRebateRate.Size = New System.Drawing.Size(118, 21)
        Me.txbNormalRebateRate.TabIndex = 1
        Me.txbNormalRebateRate.Text = "0.0"
        Me.txbNormalRebateRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(162, 33)
        Me.Label12.Margin = New System.Windows.Forms.Padding(0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(17, 12)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "元"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(165, 6)
        Me.Label10.Margin = New System.Windows.Forms.Padding(0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(11, 12)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "%"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 7)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "比率："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.theTip.SetToolTip(Me.Label1, "返点比率")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 33)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "金额："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.theTip.SetToolTip(Me.Label2, "返点金额")
        '
        'pnlNormalRebateState
        '
        Me.pnlNormalRebateState.Controls.Add(Me.lblNormalRebateState)
        Me.pnlNormalRebateState.Controls.Add(Me.Label3)
        Me.pnlNormalRebateState.Location = New System.Drawing.Point(0, 142)
        Me.pnlNormalRebateState.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlNormalRebateState.Name = "pnlNormalRebateState"
        Me.pnlNormalRebateState.Size = New System.Drawing.Size(179, 19)
        Me.pnlNormalRebateState.TabIndex = 2
        '
        'lblNormalRebateState
        '
        Me.lblNormalRebateState.AutoSize = True
        Me.lblNormalRebateState.Location = New System.Drawing.Point(39, 0)
        Me.lblNormalRebateState.Margin = New System.Windows.Forms.Padding(0)
        Me.lblNormalRebateState.Name = "lblNormalRebateState"
        Me.lblNormalRebateState.Size = New System.Drawing.Size(0, 12)
        Me.lblNormalRebateState.TabIndex = 1
        Me.lblNormalRebateState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 0)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "状态："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlNormalRebateRemarks
        '
        Me.pnlNormalRebateRemarks.Controls.Add(Me.lblNormalRebateRemarks)
        Me.pnlNormalRebateRemarks.Controls.Add(Me.Label25)
        Me.pnlNormalRebateRemarks.Location = New System.Drawing.Point(0, 161)
        Me.pnlNormalRebateRemarks.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlNormalRebateRemarks.Name = "pnlNormalRebateRemarks"
        Me.pnlNormalRebateRemarks.Size = New System.Drawing.Size(179, 32)
        Me.pnlNormalRebateRemarks.TabIndex = 3
        '
        'lblNormalRebateRemarks
        '
        Me.lblNormalRebateRemarks.Location = New System.Drawing.Point(39, 0)
        Me.lblNormalRebateRemarks.Margin = New System.Windows.Forms.Padding(0)
        Me.lblNormalRebateRemarks.Name = "lblNormalRebateRemarks"
        Me.lblNormalRebateRemarks.Size = New System.Drawing.Size(137, 25)
        Me.lblNormalRebateRemarks.TabIndex = 1
        Me.lblNormalRebateRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(4, 6)
        Me.Label25.Margin = New System.Windows.Forms.Padding(0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(41, 12)
        Me.Label25.TabIndex = 0
        Me.Label25.Text = "备注："
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlDistributionNormalRebateAMT
        '
        Me.pnlDistributionNormalRebateAMT.Controls.Add(Me.txbDistributionNormalRebateAMT)
        Me.pnlDistributionNormalRebateAMT.Controls.Add(Me.Label49)
        Me.pnlDistributionNormalRebateAMT.Controls.Add(Me.Label51)
        Me.pnlDistributionNormalRebateAMT.Location = New System.Drawing.Point(0, 193)
        Me.pnlDistributionNormalRebateAMT.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlDistributionNormalRebateAMT.Name = "pnlDistributionNormalRebateAMT"
        Me.pnlDistributionNormalRebateAMT.Size = New System.Drawing.Size(179, 43)
        Me.pnlDistributionNormalRebateAMT.TabIndex = 4
        '
        'txbDistributionNormalRebateAMT
        '
        Me.txbDistributionNormalRebateAMT.Location = New System.Drawing.Point(5, 15)
        Me.txbDistributionNormalRebateAMT.Name = "txbDistributionNormalRebateAMT"
        Me.txbDistributionNormalRebateAMT.ReadOnly = True
        Me.txbDistributionNormalRebateAMT.Size = New System.Drawing.Size(155, 21)
        Me.txbDistributionNormalRebateAMT.TabIndex = 1
        Me.txbDistributionNormalRebateAMT.Text = "0.00"
        Me.txbDistributionNormalRebateAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.ForeColor = System.Drawing.Color.Maroon
        Me.Label49.Location = New System.Drawing.Point(0, 0)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(135, 12)
        Me.Label49.TabIndex = 0
        Me.Label49.Text = "本次已分配返点金额："
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(162, 20)
        Me.Label51.Margin = New System.Windows.Forms.Padding(0)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(17, 12)
        Me.Label51.TabIndex = 2
        Me.Label51.Text = "元"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlBalanceNormalRebateAMT
        '
        Me.pnlBalanceNormalRebateAMT.Controls.Add(Me.txbBalanceNormalRebateAMT)
        Me.pnlBalanceNormalRebateAMT.Controls.Add(Me.Label52)
        Me.pnlBalanceNormalRebateAMT.Controls.Add(Me.Label53)
        Me.pnlBalanceNormalRebateAMT.Location = New System.Drawing.Point(0, 236)
        Me.pnlBalanceNormalRebateAMT.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlBalanceNormalRebateAMT.Name = "pnlBalanceNormalRebateAMT"
        Me.pnlBalanceNormalRebateAMT.Size = New System.Drawing.Size(179, 43)
        Me.pnlBalanceNormalRebateAMT.TabIndex = 4
        Me.pnlBalanceNormalRebateAMT.Visible = False
        '
        'txbBalanceNormalRebateAMT
        '
        Me.txbBalanceNormalRebateAMT.Location = New System.Drawing.Point(5, 15)
        Me.txbBalanceNormalRebateAMT.Name = "txbBalanceNormalRebateAMT"
        Me.txbBalanceNormalRebateAMT.ReadOnly = True
        Me.txbBalanceNormalRebateAMT.Size = New System.Drawing.Size(155, 21)
        Me.txbBalanceNormalRebateAMT.TabIndex = 1
        Me.txbBalanceNormalRebateAMT.Text = "0.00"
        Me.txbBalanceNormalRebateAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.Color.Maroon
        Me.Label52.Location = New System.Drawing.Point(0, 0)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(135, 12)
        Me.Label52.TabIndex = 0
        Me.Label52.Text = "本次剩余的返点金额："
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(162, 20)
        Me.Label53.Margin = New System.Windows.Forms.Padding(0)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(17, 12)
        Me.Label53.TabIndex = 2
        Me.Label53.Text = "元"
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlModifyNormalRebate
        '
        Me.pnlModifyNormalRebate.Controls.Add(Me.GroupBox1)
        Me.pnlModifyNormalRebate.Controls.Add(Me.btnModifyNormalRebate)
        Me.pnlModifyNormalRebate.Controls.Add(Me.Label22)
        Me.pnlModifyNormalRebate.Location = New System.Drawing.Point(0, 279)
        Me.pnlModifyNormalRebate.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlModifyNormalRebate.Name = "pnlModifyNormalRebate"
        Me.pnlModifyNormalRebate.Size = New System.Drawing.Size(179, 42)
        Me.pnlModifyNormalRebate.TabIndex = 5
        Me.pnlModifyNormalRebate.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(-11, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 4)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'btnModifyNormalRebate
        '
        Me.btnModifyNormalRebate.Location = New System.Drawing.Point(112, 12)
        Me.btnModifyNormalRebate.Name = "btnModifyNormalRebate"
        Me.btnModifyNormalRebate.Size = New System.Drawing.Size(65, 25)
        Me.btnModifyNormalRebate.TabIndex = 2
        Me.btnModifyNormalRebate.Text = "修改返点"
        Me.btnModifyNormalRebate.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(4, 17)
        Me.Label22.Margin = New System.Windows.Forms.Padding(0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(103, 16)
        Me.Label22.TabIndex = 1
        Me.Label22.Text = "想修改返点，请按"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNormalRebate
        '
        Me.lblNormalRebate.AutoSize = True
        Me.lblNormalRebate.Location = New System.Drawing.Point(29, 24)
        Me.lblNormalRebate.Name = "lblNormalRebate"
        Me.lblNormalRebate.Size = New System.Drawing.Size(77, 12)
        Me.lblNormalRebate.TabIndex = 1
        Me.lblNormalRebate.Text = "给予城市返点"
        '
        'chbNormalRebate
        '
        Me.chbNormalRebate.AutoSize = True
        Me.chbNormalRebate.Location = New System.Drawing.Point(11, 23)
        Me.chbNormalRebate.Name = "chbNormalRebate"
        Me.chbNormalRebate.Size = New System.Drawing.Size(15, 14)
        Me.chbNormalRebate.TabIndex = 0
        Me.chbNormalRebate.UseVisualStyleBackColor = True
        '
        'btnViewCityRule
        '
        Me.btnViewCityRule.Enabled = False
        Me.btnViewCityRule.Location = New System.Drawing.Point(118, 18)
        Me.btnViewCityRule.Name = "btnViewCityRule"
        Me.btnViewCityRule.Size = New System.Drawing.Size(65, 23)
        Me.btnViewCityRule.TabIndex = 2
        Me.btnViewCityRule.Text = "查看规则"
        Me.btnViewCityRule.UseVisualStyleBackColor = True
        '
        'grbPrintDiscount
        '
        Me.grbPrintDiscount.Controls.Add(Me.lblPrintDiscount)
        Me.grbPrintDiscount.Controls.Add(Me.chbPrintDiscount)
        Me.grbPrintDiscount.Location = New System.Drawing.Point(0, 2772)
        Me.grbPrintDiscount.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Me.grbPrintDiscount.Name = "grbPrintDiscount"
        Me.grbPrintDiscount.Size = New System.Drawing.Size(193, 50)
        Me.grbPrintDiscount.TabIndex = 10
        Me.grbPrintDiscount.TabStop = False
        Me.grbPrintDiscount.Text = "发票折扣信息打印选项："
        '
        'lblPrintDiscount
        '
        Me.lblPrintDiscount.AutoSize = True
        Me.lblPrintDiscount.Location = New System.Drawing.Point(29, 24)
        Me.lblPrintDiscount.Name = "lblPrintDiscount"
        Me.lblPrintDiscount.Size = New System.Drawing.Size(125, 12)
        Me.lblPrintDiscount.TabIndex = 1
        Me.lblPrintDiscount.Text = "在发票上打印折扣信息"
        '
        'chbPrintDiscount
        '
        Me.chbPrintDiscount.AutoSize = True
        Me.chbPrintDiscount.Location = New System.Drawing.Point(11, 23)
        Me.chbPrintDiscount.Name = "chbPrintDiscount"
        Me.chbPrintDiscount.Size = New System.Drawing.Size(15, 14)
        Me.chbPrintDiscount.TabIndex = 0
        Me.chbPrintDiscount.UseVisualStyleBackColor = True

        'modify code 075:start-------------------------------------------------------------------------
        '
        'btnCheckCUL
        '
        Me.btnCheckCUL.Enabled = False
        Me.btnCheckCUL.Location = New System.Drawing.Point(118, 18)
        Me.btnCheckCUL.Name = "btnCheckCUL"
        Me.btnCheckCUL.Size = New System.Drawing.Size(110, 23)
        Me.btnCheckCUL.TabIndex = 2
        Me.btnCheckCUL.Text = "获取返点卡"
        Me.btnCheckCUL.UseVisualStyleBackColor = True
        Me.btnCheckCUL.Margin = New System.Windows.Forms.Padding(40, 10, 10, 10)
        'modify code 075:end-------------------------------------------------------------------------

        '
        'grbSalesBillSummary
        '
        Me.grbSalesBillSummary.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.grbSalesBillSummary.Controls.Add(Me.flpSalesBillSummary)
        Me.grbSalesBillSummary.Location = New System.Drawing.Point(0, 2828)
        Me.grbSalesBillSummary.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Me.grbSalesBillSummary.Name = "grbSalesBillSummary"
        Me.grbSalesBillSummary.Size = New System.Drawing.Size(194, 190)
        Me.grbSalesBillSummary.TabIndex = 11
        Me.grbSalesBillSummary.TabStop = False
        Me.grbSalesBillSummary.Text = "销售单汇总："
        '
        'flpSalesBillSummary
        '
        Me.flpSalesBillSummary.AutoSize = True
        Me.flpSalesBillSummary.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpSalesBillSummary.Controls.Add(Me.Panel10)
        Me.flpSalesBillSummary.Controls.Add(Me.pnlActivationSummary)
        Me.flpSalesBillSummary.Controls.Add(Me.Panel17)
        Me.flpSalesBillSummary.Controls.Add(Me.pnlCardCost)
        Me.flpSalesBillSummary.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpSalesBillSummary.Location = New System.Drawing.Point(6, 20)
        Me.flpSalesBillSummary.Name = "flpSalesBillSummary"
        Me.flpSalesBillSummary.Size = New System.Drawing.Size(179, 162)
        Me.flpSalesBillSummary.TabIndex = 10
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.txbCardQTY)
        Me.Panel10.Controls.Add(Me.txbChargedAMT)
        Me.Panel10.Controls.Add(Me.Label54)
        Me.Panel10.Controls.Add(Me.Label55)
        Me.Panel10.Controls.Add(Me.Label61)
        Me.Panel10.Controls.Add(Me.Label60)
        Me.Panel10.Location = New System.Drawing.Point(0, 0)
        Me.Panel10.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(179, 51)
        Me.Panel10.TabIndex = 0
        '
        'txbCardQTY
        '
        Me.txbCardQTY.Location = New System.Drawing.Point(41, 0)
        Me.txbCardQTY.Name = "txbCardQTY"
        Me.txbCardQTY.ReadOnly = True
        Me.txbCardQTY.Size = New System.Drawing.Size(118, 21)
        Me.txbCardQTY.TabIndex = 1
        Me.txbCardQTY.Text = "0"
        Me.txbCardQTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txbChargedAMT
        '
        Me.txbChargedAMT.Location = New System.Drawing.Point(41, 27)
        Me.txbChargedAMT.Name = "txbChargedAMT"
        Me.txbChargedAMT.ReadOnly = True
        Me.txbChargedAMT.Size = New System.Drawing.Size(118, 21)
        Me.txbChargedAMT.TabIndex = 4
        Me.txbChargedAMT.Text = "0.00"
        Me.txbChargedAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(162, 5)
        Me.Label54.Margin = New System.Windows.Forms.Padding(0)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(17, 12)
        Me.Label54.TabIndex = 2
        Me.Label54.Text = "张"
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(162, 32)
        Me.Label55.Margin = New System.Windows.Forms.Padding(0)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(17, 12)
        Me.Label55.TabIndex = 5
        Me.Label55.Text = "元"
        Me.Label55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Location = New System.Drawing.Point(4, 32)
        Me.Label61.Margin = New System.Windows.Forms.Padding(0)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(41, 12)
        Me.Label61.TabIndex = 3
        Me.Label61.Text = "充值："
        Me.Label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(4, 5)
        Me.Label60.Margin = New System.Windows.Forms.Padding(0)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(41, 12)
        Me.Label60.TabIndex = 0
        Me.Label60.Text = "卡数："
        Me.Label60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlActivationSummary
        '
        Me.pnlActivationSummary.Controls.Add(Me.txbInactiveAMT)
        Me.pnlActivationSummary.Controls.Add(Me.txbActiveAMT)
        Me.pnlActivationSummary.Controls.Add(Me.Label57)
        Me.pnlActivationSummary.Controls.Add(Me.Label56)
        Me.pnlActivationSummary.Controls.Add(Me.Label58)
        Me.pnlActivationSummary.Controls.Add(Me.Label63)
        Me.pnlActivationSummary.Location = New System.Drawing.Point(0, 51)
        Me.pnlActivationSummary.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlActivationSummary.Name = "pnlActivationSummary"
        Me.pnlActivationSummary.Size = New System.Drawing.Size(179, 53)
        Me.pnlActivationSummary.TabIndex = 1
        Me.pnlActivationSummary.Visible = False
        '
        'txbInactiveAMT
        '
        Me.txbInactiveAMT.Location = New System.Drawing.Point(41, 30)
        Me.txbInactiveAMT.Name = "txbInactiveAMT"
        Me.txbInactiveAMT.ReadOnly = True
        Me.txbInactiveAMT.Size = New System.Drawing.Size(118, 21)
        Me.txbInactiveAMT.TabIndex = 4
        Me.txbInactiveAMT.Text = "0.00"
        Me.txbInactiveAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txbActiveAMT
        '
        Me.txbActiveAMT.Location = New System.Drawing.Point(41, 3)
        Me.txbActiveAMT.Name = "txbActiveAMT"
        Me.txbActiveAMT.ReadOnly = True
        Me.txbActiveAMT.Size = New System.Drawing.Size(118, 21)
        Me.txbActiveAMT.TabIndex = 1
        Me.txbActiveAMT.Text = "0.00"
        Me.txbActiveAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(162, 35)
        Me.Label57.Margin = New System.Windows.Forms.Padding(0)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(17, 12)
        Me.Label57.TabIndex = 5
        Me.Label57.Text = "元"
        Me.Label57.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(162, 8)
        Me.Label56.Margin = New System.Windows.Forms.Padding(0)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(17, 12)
        Me.Label56.TabIndex = 2
        Me.Label56.Text = "元"
        Me.Label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Location = New System.Drawing.Point(4, 35)
        Me.Label58.Margin = New System.Windows.Forms.Padding(0)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(41, 12)
        Me.Label58.TabIndex = 3
        Me.Label58.Text = "未激："
        Me.Label58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Location = New System.Drawing.Point(4, 8)
        Me.Label63.Margin = New System.Windows.Forms.Padding(0)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(41, 12)
        Me.Label63.TabIndex = 0
        Me.Label63.Text = "已激："
        Me.Label63.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel17
        '
        Me.Panel17.Controls.Add(Me.txbPaymentAMT)
        Me.Panel17.Controls.Add(Me.Label65)
        Me.Panel17.Controls.Add(Me.Label64)
        Me.Panel17.Location = New System.Drawing.Point(0, 104)
        Me.Panel17.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Size = New System.Drawing.Size(179, 29)
        Me.Panel17.TabIndex = 2
        '
        'txbPaymentAMT
        '
        Me.txbPaymentAMT.Location = New System.Drawing.Point(41, 4)
        Me.txbPaymentAMT.Name = "txbPaymentAMT"
        Me.txbPaymentAMT.ReadOnly = True
        Me.txbPaymentAMT.Size = New System.Drawing.Size(118, 21)
        Me.txbPaymentAMT.TabIndex = 1
        Me.txbPaymentAMT.Text = "0.00"
        Me.txbPaymentAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Location = New System.Drawing.Point(162, 9)
        Me.Label65.Margin = New System.Windows.Forms.Padding(0)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(17, 12)
        Me.Label65.TabIndex = 2
        Me.Label65.Text = "元"
        Me.Label65.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Location = New System.Drawing.Point(4, 9)
        Me.Label64.Margin = New System.Windows.Forms.Padding(0)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(41, 12)
        Me.Label64.TabIndex = 0
        Me.Label64.Text = "实付："
        Me.Label64.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlCardCost
        '
        Me.pnlCardCost.Controls.Add(Me.txbCardCost)
        Me.pnlCardCost.Controls.Add(Me.Label7)
        Me.pnlCardCost.Controls.Add(Me.Label21)
        Me.pnlCardCost.Location = New System.Drawing.Point(0, 133)
        Me.pnlCardCost.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlCardCost.Name = "pnlCardCost"
        Me.pnlCardCost.Size = New System.Drawing.Size(179, 29)
        Me.pnlCardCost.TabIndex = 3
        Me.pnlCardCost.Visible = False
        '
        'txbCardCost
        '
        Me.txbCardCost.Location = New System.Drawing.Point(41, 4)
        Me.txbCardCost.Name = "txbCardCost"
        Me.txbCardCost.ReadOnly = True
        Me.txbCardCost.Size = New System.Drawing.Size(118, 21)
        Me.txbCardCost.TabIndex = 1
        Me.txbCardCost.Text = "0.00"
        Me.txbCardCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(162, 9)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(17, 12)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "元"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(4, 9)
        Me.Label21.Margin = New System.Windows.Forms.Padding(0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(41, 12)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "卡费："
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grbSalesBillInfo
        '
        Me.grbSalesBillInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.grbSalesBillInfo.Controls.Add(Me.lblCreatorName)
        Me.grbSalesBillInfo.Controls.Add(Me.lblCreatedTime)
        Me.grbSalesBillInfo.Controls.Add(Me.lblSalesBillCode)
        Me.grbSalesBillInfo.Controls.Add(Me.lblSalesBillState)
        Me.grbSalesBillInfo.Controls.Add(Me.pnlSalesBillStateDescription)
        Me.grbSalesBillInfo.Controls.Add(Me.Label15)
        Me.grbSalesBillInfo.Controls.Add(Me.Label17)
        Me.grbSalesBillInfo.Controls.Add(Me.Label13)
        Me.grbSalesBillInfo.Controls.Add(Me.Label19)
        Me.grbSalesBillInfo.Location = New System.Drawing.Point(0, 3024)
        Me.grbSalesBillInfo.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Me.grbSalesBillInfo.Name = "grbSalesBillInfo"
        Me.grbSalesBillInfo.Size = New System.Drawing.Size(194, 157)
        Me.grbSalesBillInfo.TabIndex = 12
        Me.grbSalesBillInfo.TabStop = False
        Me.grbSalesBillInfo.Text = "销售单信息："
        '
        'lblCreatorName
        '
        Me.lblCreatorName.BackColor = System.Drawing.SystemColors.Info
        Me.lblCreatorName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCreatorName.Location = New System.Drawing.Point(47, 70)
        Me.lblCreatorName.Name = "lblCreatorName"
        Me.lblCreatorName.Size = New System.Drawing.Size(136, 18)
        Me.lblCreatorName.TabIndex = 5
        Me.lblCreatorName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCreatedTime
        '
        Me.lblCreatedTime.BackColor = System.Drawing.SystemColors.Info
        Me.lblCreatedTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCreatedTime.Location = New System.Drawing.Point(47, 46)
        Me.lblCreatedTime.Name = "lblCreatedTime"
        Me.lblCreatedTime.Size = New System.Drawing.Size(136, 18)
        Me.lblCreatedTime.TabIndex = 3
        Me.lblCreatedTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSalesBillCode
        '
        Me.lblSalesBillCode.BackColor = System.Drawing.SystemColors.Info
        Me.lblSalesBillCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSalesBillCode.Location = New System.Drawing.Point(47, 22)
        Me.lblSalesBillCode.Name = "lblSalesBillCode"
        Me.lblSalesBillCode.Size = New System.Drawing.Size(136, 18)
        Me.lblSalesBillCode.TabIndex = 1
        Me.lblSalesBillCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSalesBillState
        '
        Me.lblSalesBillState.BackColor = System.Drawing.SystemColors.Info
        Me.lblSalesBillState.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSalesBillState.Location = New System.Drawing.Point(47, 94)
        Me.lblSalesBillState.Name = "lblSalesBillState"
        Me.lblSalesBillState.Size = New System.Drawing.Size(136, 18)
        Me.lblSalesBillState.TabIndex = 7
        Me.lblSalesBillState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlSalesBillStateDescription
        '
        Me.pnlSalesBillStateDescription.Controls.Add(Me.lblSalesBillRemarks)
        Me.pnlSalesBillStateDescription.Controls.Add(Me.Label6)
        Me.pnlSalesBillStateDescription.Location = New System.Drawing.Point(6, 118)
        Me.pnlSalesBillStateDescription.Name = "pnlSalesBillStateDescription"
        Me.pnlSalesBillStateDescription.Size = New System.Drawing.Size(179, 29)
        Me.pnlSalesBillStateDescription.TabIndex = 8
        '
        'lblSalesBillRemarks
        '
        Me.lblSalesBillRemarks.Location = New System.Drawing.Point(38, 2)
        Me.lblSalesBillRemarks.Margin = New System.Windows.Forms.Padding(0)
        Me.lblSalesBillRemarks.Name = "lblSalesBillRemarks"
        Me.lblSalesBillRemarks.Size = New System.Drawing.Size(137, 25)
        Me.lblSalesBillRemarks.TabIndex = 1
        Me.lblSalesBillRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(0, 8)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 12)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "备注："
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 27)
        Me.Label15.Margin = New System.Windows.Forms.Padding(0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(41, 12)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "单号："
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 51)
        Me.Label17.Margin = New System.Windows.Forms.Padding(0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(41, 12)
        Me.Label17.TabIndex = 2
        Me.Label17.Text = "时间："
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 99)
        Me.Label13.Margin = New System.Windows.Forms.Padding(0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 12)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "状态："
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 75)
        Me.Label19.Margin = New System.Windows.Forms.Padding(0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(41, 12)
        Me.Label19.TabIndex = 4
        Me.Label19.Text = "建单："
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlAddjustSalesman
        '
        Me.pnlAddjustSalesman.Controls.Add(Me.btnAddjustSalesman)
        Me.pnlAddjustSalesman.Location = New System.Drawing.Point(0, 3186)
        Me.pnlAddjustSalesman.Margin = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.pnlAddjustSalesman.Name = "pnlAddjustSalesman"
        Me.pnlAddjustSalesman.Size = New System.Drawing.Size(194, 28)
        Me.pnlAddjustSalesman.TabIndex = 13
        Me.pnlAddjustSalesman.Visible = False
        '
        'btnAddjustSalesman
        '
        Me.btnAddjustSalesman.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddjustSalesman.Location = New System.Drawing.Point(52, 5)
        Me.btnAddjustSalesman.Name = "btnAddjustSalesman"
        Me.btnAddjustSalesman.Size = New System.Drawing.Size(78, 23)
        Me.btnAddjustSalesman.TabIndex = 0
        Me.btnAddjustSalesman.Text = "调整业务员"
        Me.btnAddjustSalesman.UseVisualStyleBackColor = True
        '
        'tlpLeft
        '
        Me.tlpLeft.ColumnCount = 3
        Me.tlpLeft.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.tlpLeft.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpLeft.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.tlpLeft.Controls.Add(Me.Panel9, 2, 2)
        Me.tlpLeft.Controls.Add(Me.Panel8, 1, 2)
        Me.tlpLeft.Controls.Add(Me.Panel7, 0, 2)
        Me.tlpLeft.Controls.Add(Me.Panel6, 2, 1)
        Me.tlpLeft.Controls.Add(Me.Panel5, 1, 1)
        Me.tlpLeft.Controls.Add(Me.Panel4, 0, 1)
        Me.tlpLeft.Controls.Add(Me.Panel3, 2, 0)
        Me.tlpLeft.Controls.Add(Me.Panel2, 1, 0)
        Me.tlpLeft.Controls.Add(Me.Panel1, 0, 0)
        Me.tlpLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpLeft.Location = New System.Drawing.Point(0, 0)
        Me.tlpLeft.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpLeft.Name = "tlpLeft"
        Me.tlpLeft.RowCount = 3
        Me.tlpLeft.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.tlpLeft.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpLeft.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.tlpLeft.Size = New System.Drawing.Size(245, 667)
        Me.tlpLeft.TabIndex = 0
        '
        'Panel9
        '
        Me.Panel9.BackgroundImage = CType(resources.GetObject("Panel9.BackgroundImage"), System.Drawing.Image)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(224, 646)
        Me.Panel9.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(21, 21)
        Me.Panel9.TabIndex = 8
        '
        'Panel8
        '
        Me.Panel8.BackgroundImage = CType(resources.GetObject("Panel8.BackgroundImage"), System.Drawing.Image)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(21, 646)
        Me.Panel8.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(203, 21)
        Me.Panel8.TabIndex = 7
        '
        'Panel7
        '
        Me.Panel7.BackgroundImage = CType(resources.GetObject("Panel7.BackgroundImage"), System.Drawing.Image)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(0, 646)
        Me.Panel7.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(21, 21)
        Me.Panel7.TabIndex = 6
        '
        'Panel6
        '
        Me.Panel6.BackgroundImage = CType(resources.GetObject("Panel6.BackgroundImage"), System.Drawing.Image)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(224, 21)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(21, 625)
        Me.Panel6.TabIndex = 5
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(21, 21)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(203, 625)
        Me.Panel5.TabIndex = 4
        '
        'Panel4
        '
        Me.Panel4.BackgroundImage = CType(resources.GetObject("Panel4.BackgroundImage"), System.Drawing.Image)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 21)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(21, 625)
        Me.Panel4.TabIndex = 3
        '
        'Panel3
        '
        Me.Panel3.BackgroundImage = CType(resources.GetObject("Panel3.BackgroundImage"), System.Drawing.Image)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(224, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(21, 21)
        Me.Panel3.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(21, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(203, 21)
        Me.Panel2.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.Controls.Add(Me.flpContainer)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(21, 21)
        Me.Panel1.TabIndex = 0
        '
        'flpContainer
        '
        Me.flpContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flpContainer.AutoScroll = True
        Me.flpContainer.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.flpContainer.Location = New System.Drawing.Point(21, 12)
        Me.flpContainer.Margin = New System.Windows.Forms.Padding(0)
        Me.flpContainer.Name = "flpContainer"
        Me.flpContainer.Size = New System.Drawing.Size(194, 650)
        Me.flpContainer.TabIndex = 0
        '
        'splitRight
        '
        Me.splitRight.BackColor = System.Drawing.SystemColors.Window
        Me.splitRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitRight.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.splitRight.IsSplitterFixed = True
        Me.splitRight.Location = New System.Drawing.Point(0, 0)
        Me.splitRight.Name = "splitRight"
        Me.splitRight.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitRight.Panel1
        '
        Me.splitRight.Panel1.Controls.Add(Me.pnlRight)
        Me.splitRight.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        'splitRight.Panel2
        '
        Me.splitRight.Panel2.Controls.Add(Me.Panel41)
        Me.splitRight.Panel2.Controls.Add(Me.pnlBottom)
        Me.splitRight.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.splitRight.Size = New System.Drawing.Size(707, 690)
        Me.splitRight.SplitterDistance = 545
        Me.splitRight.SplitterWidth = 1
        Me.splitRight.TabIndex = 0
        '
        'pnlRight
        '
        Me.pnlRight.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlRight.Controls.Add(Me.splitList)
        Me.pnlRight.Controls.Add(Me.tlpRight)
        Me.pnlRight.Location = New System.Drawing.Point(2, 11)
        Me.pnlRight.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlRight.Name = "pnlRight"
        Me.pnlRight.Size = New System.Drawing.Size(694, 524)
        Me.pnlRight.TabIndex = 0
        '
        'splitList
        '
        Me.splitList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.splitList.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.splitList.IsSplitterFixed = True
        Me.splitList.Location = New System.Drawing.Point(13, 13)
        Me.splitList.Name = "splitList"
        Me.splitList.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitList.Panel1
        '
        Me.splitList.Panel1.Controls.Add(Me.pnlImportedFile)
        Me.splitList.Panel1.Controls.Add(Me.TableLayoutPanel4)
        Me.splitList.Panel1.Controls.Add(Me.TableLayoutPanel3)
        Me.splitList.Panel1.Controls.Add(Me.lblNormalListTitle)
        Me.splitList.Panel1.Controls.Add(Me.lblNormalCardSummary)
        '
        'splitList.Panel2
        '
        Me.splitList.Panel2.Controls.Add(Me.lblRebateCardSummary)
        Me.splitList.Panel2.Controls.Add(Me.dgvRebateCard)
        Me.splitList.Panel2.Controls.Add(Me.Label24)
        Me.splitList.Size = New System.Drawing.Size(669, 497)
        Me.splitList.SplitterDistance = 221
        Me.splitList.TabIndex = 1
        '
        'pnlImportedFile
        '
        Me.pnlImportedFile.AutoSize = True
        Me.pnlImportedFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlImportedFile.Controls.Add(Me.TableLayoutPanel5)
        Me.pnlImportedFile.Location = New System.Drawing.Point(97, 0)
        Me.pnlImportedFile.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlImportedFile.Name = "pnlImportedFile"
        Me.pnlImportedFile.Size = New System.Drawing.Size(163, 13)
        Me.pnlImportedFile.TabIndex = 1
        Me.pnlImportedFile.Visible = False
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.AutoSize = True
        Me.TableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel5.ColumnCount = 4
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel5.Controls.Add(Me.Label28, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.lblSourceFile, 1, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.Label29, 3, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.lblViewImportedResult, 2, 1)
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel5.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 3
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(163, 13)
        Me.TableLayoutPanel5.TabIndex = 0
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(0, 0)
        Me.Label28.Margin = New System.Windows.Forms.Padding(0)
        Me.Label28.Name = "Label28"
        Me.Label28.Padding = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.Label28.Size = New System.Drawing.Size(65, 13)
        Me.Label28.TabIndex = 0
        Me.Label28.Text = "【源文件："
        '
        'lblSourceFile
        '
        Me.lblSourceFile.AutoSize = True
        Me.lblSourceFile.Location = New System.Drawing.Point(65, 0)
        Me.lblSourceFile.Margin = New System.Windows.Forms.Padding(0)
        Me.lblSourceFile.Name = "lblSourceFile"
        Me.lblSourceFile.Padding = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.lblSourceFile.Size = New System.Drawing.Size(0, 13)
        Me.lblSourceFile.TabIndex = 1
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(146, 0)
        Me.Label29.Margin = New System.Windows.Forms.Padding(0)
        Me.Label29.Name = "Label29"
        Me.Label29.Padding = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.Label29.Size = New System.Drawing.Size(17, 13)
        Me.Label29.TabIndex = 3
        Me.Label29.Text = "】"
        '
        'lblViewImportedResult
        '
        Me.lblViewImportedResult.AutoSize = True
        Me.lblViewImportedResult.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblViewImportedResult.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblViewImportedResult.ForeColor = System.Drawing.Color.Blue
        Me.lblViewImportedResult.Location = New System.Drawing.Point(65, 0)
        Me.lblViewImportedResult.Margin = New System.Windows.Forms.Padding(0)
        Me.lblViewImportedResult.Name = "lblViewImportedResult"
        Me.lblViewImportedResult.Padding = New System.Windows.Forms.Padding(4, 1, 0, 0)
        Me.lblViewImportedResult.Size = New System.Drawing.Size(81, 13)
        Me.lblViewImportedResult.TabIndex = 2
        Me.lblViewImportedResult.Text = "查看导入结果"
        Me.theTip.SetToolTip(Me.lblViewImportedResult, "单击此链接可以查看源文件的导入结果。")
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.AutoSize = True
        Me.TableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, -1)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(0, 0)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.dgvNormalCard, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.pnlDeductionAMT, 0, 1)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 15)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(668, 206)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'dgvNormalCard
        '
        Me.dgvNormalCard.AllowUserToAddRows = False
        Me.dgvNormalCard.AllowUserToDeleteRows = False
        Me.dgvNormalCard.AllowUserToResizeRows = False
        Me.dgvNormalCard.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvNormalCard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvNormalCard.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvNormalCard.ColumnHeadersHeight = 22
        Me.dgvNormalCard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvNormalCard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvNormalCard.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvNormalCard.Location = New System.Drawing.Point(0, 0)
        Me.dgvNormalCard.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvNormalCard.MultiSelect = False
        Me.dgvNormalCard.Name = "dgvNormalCard"
        Me.dgvNormalCard.RowHeadersVisible = False
        Me.dgvNormalCard.RowTemplate.Height = 24
        Me.dgvNormalCard.Size = New System.Drawing.Size(668, 186)
        Me.dgvNormalCard.StandardTab = True
        Me.dgvNormalCard.TabIndex = 0
        '
        'pnlDeductionAMT
        '
        Me.pnlDeductionAMT.Controls.Add(Me.Label18)
        Me.pnlDeductionAMT.Controls.Add(Me.lblDeductionAMT)
        Me.pnlDeductionAMT.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDeductionAMT.Location = New System.Drawing.Point(0, 186)
        Me.pnlDeductionAMT.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlDeductionAMT.Name = "pnlDeductionAMT"
        Me.pnlDeductionAMT.Size = New System.Drawing.Size(668, 20)
        Me.pnlDeductionAMT.TabIndex = 1
        Me.pnlDeductionAMT.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label18.Location = New System.Drawing.Point(0, 7)
        Me.Label18.Margin = New System.Windows.Forms.Padding(0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(65, 12)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "付款抵扣："
        '
        'lblDeductionAMT
        '
        Me.lblDeductionAMT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDeductionAMT.Location = New System.Drawing.Point(68, 7)
        Me.lblDeductionAMT.Name = "lblDeductionAMT"
        Me.lblDeductionAMT.Size = New System.Drawing.Size(595, 12)
        Me.lblDeductionAMT.TabIndex = 2
        Me.lblDeductionAMT.Text = "0.00 元"
        Me.lblDeductionAMT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNormalListTitle
        '
        Me.lblNormalListTitle.AutoSize = True
        Me.lblNormalListTitle.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblNormalListTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblNormalListTitle.Margin = New System.Windows.Forms.Padding(0)
        Me.lblNormalListTitle.Name = "lblNormalListTitle"
        Me.lblNormalListTitle.Padding = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.lblNormalListTitle.Size = New System.Drawing.Size(101, 13)
        Me.lblNormalListTitle.TabIndex = 0
        Me.lblNormalListTitle.Text = "购物卡充值列表："
        Me.lblNormalListTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNormalCardSummary
        '
        Me.lblNormalCardSummary.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNormalCardSummary.Location = New System.Drawing.Point(97, 0)
        Me.lblNormalCardSummary.Name = "lblNormalCardSummary"
        Me.lblNormalCardSummary.Size = New System.Drawing.Size(578, 12)
        Me.lblNormalCardSummary.TabIndex = 2
        Me.lblNormalCardSummary.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRebateCardSummary
        '
        Me.lblRebateCardSummary.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRebateCardSummary.Location = New System.Drawing.Point(97, 0)
        Me.lblRebateCardSummary.Name = "lblRebateCardSummary"
        Me.lblRebateCardSummary.Size = New System.Drawing.Size(578, 12)
        Me.lblRebateCardSummary.TabIndex = 2
        Me.lblRebateCardSummary.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvRebateCard
        '
        Me.dgvRebateCard.AllowUserToAddRows = False
        Me.dgvRebateCard.AllowUserToDeleteRows = False
        Me.dgvRebateCard.AllowUserToResizeRows = False
        Me.dgvRebateCard.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRebateCard.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvRebateCard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRebateCard.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvRebateCard.ColumnHeadersHeight = 22
        Me.dgvRebateCard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvRebateCard.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvRebateCard.Location = New System.Drawing.Point(0, 15)
        Me.dgvRebateCard.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvRebateCard.MultiSelect = False
        Me.dgvRebateCard.Name = "dgvRebateCard"
        Me.dgvRebateCard.RowHeadersVisible = False
        Me.dgvRebateCard.RowTemplate.Height = 24
        Me.dgvRebateCard.Size = New System.Drawing.Size(668, 257)
        Me.dgvRebateCard.StandardTab = True
        Me.dgvRebateCard.TabIndex = 1
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label24.Location = New System.Drawing.Point(0, 0)
        Me.Label24.Margin = New System.Windows.Forms.Padding(0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(101, 12)
        Me.Label24.TabIndex = 0
        Me.Label24.Text = "返点卡充值列表："
        '
        'tlpRight
        '
        Me.tlpRight.ColumnCount = 3
        Me.tlpRight.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.tlpRight.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpRight.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.tlpRight.Controls.Add(Me.Panel22, 2, 2)
        Me.tlpRight.Controls.Add(Me.Panel24, 1, 2)
        Me.tlpRight.Controls.Add(Me.Panel25, 0, 2)
        Me.tlpRight.Controls.Add(Me.Panel26, 2, 1)
        Me.tlpRight.Controls.Add(Me.Panel27, 1, 1)
        Me.tlpRight.Controls.Add(Me.Panel28, 0, 1)
        Me.tlpRight.Controls.Add(Me.Panel29, 2, 0)
        Me.tlpRight.Controls.Add(Me.Panel30, 1, 0)
        Me.tlpRight.Controls.Add(Me.Panel31, 0, 0)
        Me.tlpRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpRight.Location = New System.Drawing.Point(0, 0)
        Me.tlpRight.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpRight.Name = "tlpRight"
        Me.tlpRight.RowCount = 3
        Me.tlpRight.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.tlpRight.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpRight.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.tlpRight.Size = New System.Drawing.Size(694, 524)
        Me.tlpRight.TabIndex = 0
        '
        'Panel22
        '
        Me.Panel22.BackgroundImage = CType(resources.GetObject("Panel22.BackgroundImage"), System.Drawing.Image)
        Me.Panel22.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel22.Location = New System.Drawing.Point(673, 503)
        Me.Panel22.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel22.Name = "Panel22"
        Me.Panel22.Size = New System.Drawing.Size(21, 21)
        Me.Panel22.TabIndex = 8
        '
        'Panel24
        '
        Me.Panel24.BackgroundImage = CType(resources.GetObject("Panel24.BackgroundImage"), System.Drawing.Image)
        Me.Panel24.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel24.Location = New System.Drawing.Point(21, 503)
        Me.Panel24.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel24.Name = "Panel24"
        Me.Panel24.Size = New System.Drawing.Size(652, 21)
        Me.Panel24.TabIndex = 7
        '
        'Panel25
        '
        Me.Panel25.BackgroundImage = CType(resources.GetObject("Panel25.BackgroundImage"), System.Drawing.Image)
        Me.Panel25.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel25.Location = New System.Drawing.Point(0, 503)
        Me.Panel25.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel25.Name = "Panel25"
        Me.Panel25.Size = New System.Drawing.Size(21, 21)
        Me.Panel25.TabIndex = 6
        '
        'Panel26
        '
        Me.Panel26.BackgroundImage = CType(resources.GetObject("Panel26.BackgroundImage"), System.Drawing.Image)
        Me.Panel26.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel26.Location = New System.Drawing.Point(673, 21)
        Me.Panel26.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel26.Name = "Panel26"
        Me.Panel26.Size = New System.Drawing.Size(21, 482)
        Me.Panel26.TabIndex = 5
        '
        'Panel27
        '
        Me.Panel27.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.Panel27.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel27.Location = New System.Drawing.Point(21, 21)
        Me.Panel27.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel27.Name = "Panel27"
        Me.Panel27.Size = New System.Drawing.Size(652, 482)
        Me.Panel27.TabIndex = 4
        '
        'Panel28
        '
        Me.Panel28.BackgroundImage = CType(resources.GetObject("Panel28.BackgroundImage"), System.Drawing.Image)
        Me.Panel28.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel28.Location = New System.Drawing.Point(0, 21)
        Me.Panel28.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel28.Name = "Panel28"
        Me.Panel28.Size = New System.Drawing.Size(21, 482)
        Me.Panel28.TabIndex = 3
        '
        'Panel29
        '
        Me.Panel29.BackgroundImage = CType(resources.GetObject("Panel29.BackgroundImage"), System.Drawing.Image)
        Me.Panel29.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel29.Location = New System.Drawing.Point(673, 0)
        Me.Panel29.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel29.Name = "Panel29"
        Me.Panel29.Size = New System.Drawing.Size(21, 21)
        Me.Panel29.TabIndex = 2
        '
        'Panel30
        '
        Me.Panel30.BackgroundImage = CType(resources.GetObject("Panel30.BackgroundImage"), System.Drawing.Image)
        Me.Panel30.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel30.Location = New System.Drawing.Point(21, 0)
        Me.Panel30.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel30.Name = "Panel30"
        Me.Panel30.Size = New System.Drawing.Size(652, 21)
        Me.Panel30.TabIndex = 1
        '
        'Panel31
        '
        Me.Panel31.BackgroundImage = CType(resources.GetObject("Panel31.BackgroundImage"), System.Drawing.Image)
        Me.Panel31.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel31.Location = New System.Drawing.Point(0, 0)
        Me.Panel31.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel31.Name = "Panel31"
        Me.Panel31.Size = New System.Drawing.Size(21, 21)
        Me.Panel31.TabIndex = 0
        '
        'Panel41
        '
        Me.Panel41.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel41.Controls.Add(Me.pnlFunction)
        Me.Panel41.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel41.Location = New System.Drawing.Point(512, 1)
        Me.Panel41.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel41.Name = "Panel41"
        Me.Panel41.Size = New System.Drawing.Size(184, 132)
        Me.Panel41.TabIndex = 1
        '
        'pnlFunction
        '
        Me.pnlFunction.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.pnlFunction.Controls.Add(Me.TableLayoutPanel2)
        Me.pnlFunction.Location = New System.Drawing.Point(10, 10)
        Me.pnlFunction.Name = "pnlFunction"
        Me.pnlFunction.Size = New System.Drawing.Size(166, 153)
        Me.pnlFunction.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel42, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.btnNewSalesBill, 0, 10)
        Me.TableLayoutPanel2.Controls.Add(Me.btnOK, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnViewActivation, 0, 8)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel18, 0, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel23, 0, 2)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 11
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(166, 153)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Panel42
        '
        Me.Panel42.Controls.Add(Me.btnConfigApplicationForm)
        Me.Panel42.Controls.Add(Me.btnPrintApplicationForm)
        Me.Panel42.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel42.Location = New System.Drawing.Point(0, 50)
        Me.Panel42.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel42.Name = "Panel42"
        Me.Panel42.Size = New System.Drawing.Size(166, 28)
        Me.Panel42.TabIndex = 2
        '
        'btnConfigApplicationForm
        '
        Me.btnConfigApplicationForm.Enabled = False
        Me.btnConfigApplicationForm.Location = New System.Drawing.Point(124, 2)
        Me.btnConfigApplicationForm.Margin = New System.Windows.Forms.Padding(2)
        Me.btnConfigApplicationForm.Name = "btnConfigApplicationForm"
        Me.btnConfigApplicationForm.Size = New System.Drawing.Size(37, 23)
        Me.btnConfigApplicationForm.TabIndex = 1
        Me.btnConfigApplicationForm.Text = "设置"
        Me.theTip.SetToolTip(Me.btnConfigApplicationForm, "设置折扣申请单打印机")
        Me.btnConfigApplicationForm.UseVisualStyleBackColor = True
        '
        'btnPrintApplicationForm
        '
        Me.btnPrintApplicationForm.Enabled = False
        Me.btnPrintApplicationForm.Location = New System.Drawing.Point(2, 2)
        Me.btnPrintApplicationForm.Margin = New System.Windows.Forms.Padding(2)
        Me.btnPrintApplicationForm.Name = "btnPrintApplicationForm"
        Me.btnPrintApplicationForm.Size = New System.Drawing.Size(116, 23)
        Me.btnPrintApplicationForm.TabIndex = 0
        Me.btnPrintApplicationForm.Text = "打印折扣申请单(&D)"
        Me.btnPrintApplicationForm.UseVisualStyleBackColor = True
        '
        'btnNewSalesBill
        '
        Me.btnNewSalesBill.Enabled = False
        Me.btnNewSalesBill.Location = New System.Drawing.Point(2, 127)
        Me.btnNewSalesBill.Margin = New System.Windows.Forms.Padding(2)
        Me.btnNewSalesBill.Name = "btnNewSalesBill"
        Me.btnNewSalesBill.Size = New System.Drawing.Size(160, 23)
        Me.btnNewSalesBill.TabIndex = 5
        Me.btnNewSalesBill.Text = "新建销售单(&N)"
        Me.btnNewSalesBill.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(2, 2)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(2)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(160, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "付款确认(&O)"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnViewActivation
        '
        Me.btnViewActivation.Enabled = False
        Me.btnViewActivation.Location = New System.Drawing.Point(2, 102)
        Me.btnViewActivation.Margin = New System.Windows.Forms.Padding(2)
        Me.btnViewActivation.Name = "btnViewActivation"
        Me.btnViewActivation.Size = New System.Drawing.Size(160, 23)
        Me.btnViewActivation.TabIndex = 4
        Me.btnViewActivation.Text = "激活明细(&A)"
        Me.btnViewActivation.UseVisualStyleBackColor = True
        '
        'Panel18
        '
        Me.Panel18.Controls.Add(Me.btnConfigInvoice)
        Me.Panel18.Controls.Add(Me.btnPrintInvoice)
        Me.Panel18.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel18.Location = New System.Drawing.Point(0, 75)
        Me.Panel18.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Size = New System.Drawing.Size(166, 28)
        Me.Panel18.TabIndex = 3
        '
        'btnConfigInvoice
        '
        Me.btnConfigInvoice.Enabled = False
        Me.btnConfigInvoice.Location = New System.Drawing.Point(124, 2)
        Me.btnConfigInvoice.Margin = New System.Windows.Forms.Padding(2)
        Me.btnConfigInvoice.Name = "btnConfigInvoice"
        Me.btnConfigInvoice.Size = New System.Drawing.Size(37, 23)
        Me.btnConfigInvoice.TabIndex = 1
        Me.btnConfigInvoice.Text = "设置"
        Me.theTip.SetToolTip(Me.btnConfigInvoice, "设置发票版面及打印机")
        Me.btnConfigInvoice.UseVisualStyleBackColor = True
        '
        'btnPrintInvoice
        '
        Me.btnPrintInvoice.Enabled = False
        Me.btnPrintInvoice.Location = New System.Drawing.Point(2, 2)
        Me.btnPrintInvoice.Margin = New System.Windows.Forms.Padding(2)
        Me.btnPrintInvoice.Name = "btnPrintInvoice"
        Me.btnPrintInvoice.Size = New System.Drawing.Size(116, 23)
        Me.btnPrintInvoice.TabIndex = 0
        Me.btnPrintInvoice.Text = "打印发票(&I)"
        Me.btnPrintInvoice.UseVisualStyleBackColor = True
        '
        'Panel23
        '
        Me.Panel23.Controls.Add(Me.btnConfigTicket)
        Me.Panel23.Controls.Add(Me.btnPrintTicket)
        Me.Panel23.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel23.Location = New System.Drawing.Point(0, 25)
        Me.Panel23.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel23.Name = "Panel23"
        Me.Panel23.Size = New System.Drawing.Size(166, 28)
        Me.Panel23.TabIndex = 1
        '
        'btnConfigTicket
        '
        Me.btnConfigTicket.Enabled = False
        Me.btnConfigTicket.Location = New System.Drawing.Point(124, 2)
        Me.btnConfigTicket.Margin = New System.Windows.Forms.Padding(2)
        Me.btnConfigTicket.Name = "btnConfigTicket"
        Me.btnConfigTicket.Size = New System.Drawing.Size(37, 23)
        Me.btnConfigTicket.TabIndex = 1
        Me.btnConfigTicket.Text = "设置"
        Me.theTip.SetToolTip(Me.btnConfigTicket, "设置小票打印机")
        Me.btnConfigTicket.UseVisualStyleBackColor = True
        '
        'btnPrintTicket
        '
        Me.btnPrintTicket.Enabled = False
        Me.btnPrintTicket.Location = New System.Drawing.Point(2, 2)
        Me.btnPrintTicket.Margin = New System.Windows.Forms.Padding(2)
        Me.btnPrintTicket.Name = "btnPrintTicket"
        Me.btnPrintTicket.Size = New System.Drawing.Size(116, 23)
        Me.btnPrintTicket.TabIndex = 0
        Me.btnPrintTicket.Text = "打印小票(&T)"
        Me.btnPrintTicket.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel11, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel12, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel13, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel14, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel15, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel16, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel19, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel20, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel21, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(184, 132)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel11
        '
        Me.Panel11.BackgroundImage = CType(resources.GetObject("Panel11.BackgroundImage"), System.Drawing.Image)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel11.Location = New System.Drawing.Point(163, 111)
        Me.Panel11.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(21, 21)
        Me.Panel11.TabIndex = 8
        '
        'Panel12
        '
        Me.Panel12.BackgroundImage = CType(resources.GetObject("Panel12.BackgroundImage"), System.Drawing.Image)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel12.Location = New System.Drawing.Point(21, 111)
        Me.Panel12.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(142, 21)
        Me.Panel12.TabIndex = 7
        '
        'Panel13
        '
        Me.Panel13.BackgroundImage = CType(resources.GetObject("Panel13.BackgroundImage"), System.Drawing.Image)
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel13.Location = New System.Drawing.Point(0, 111)
        Me.Panel13.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(21, 21)
        Me.Panel13.TabIndex = 6
        '
        'Panel14
        '
        Me.Panel14.BackgroundImage = CType(resources.GetObject("Panel14.BackgroundImage"), System.Drawing.Image)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel14.Location = New System.Drawing.Point(163, 21)
        Me.Panel14.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(21, 90)
        Me.Panel14.TabIndex = 5
        '
        'Panel15
        '
        Me.Panel15.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.Panel15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel15.Location = New System.Drawing.Point(21, 21)
        Me.Panel15.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(142, 90)
        Me.Panel15.TabIndex = 4
        '
        'Panel16
        '
        Me.Panel16.BackgroundImage = CType(resources.GetObject("Panel16.BackgroundImage"), System.Drawing.Image)
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel16.Location = New System.Drawing.Point(0, 21)
        Me.Panel16.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(21, 90)
        Me.Panel16.TabIndex = 3
        '
        'Panel19
        '
        Me.Panel19.BackgroundImage = CType(resources.GetObject("Panel19.BackgroundImage"), System.Drawing.Image)
        Me.Panel19.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel19.Location = New System.Drawing.Point(163, 0)
        Me.Panel19.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel19.Name = "Panel19"
        Me.Panel19.Size = New System.Drawing.Size(21, 21)
        Me.Panel19.TabIndex = 2
        '
        'Panel20
        '
        Me.Panel20.BackgroundImage = CType(resources.GetObject("Panel20.BackgroundImage"), System.Drawing.Image)
        Me.Panel20.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel20.Location = New System.Drawing.Point(21, 0)
        Me.Panel20.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Size = New System.Drawing.Size(142, 21)
        Me.Panel20.TabIndex = 1
        '
        'Panel21
        '
        Me.Panel21.BackgroundImage = CType(resources.GetObject("Panel21.BackgroundImage"), System.Drawing.Image)
        Me.Panel21.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel21.Location = New System.Drawing.Point(0, 0)
        Me.Panel21.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel21.Name = "Panel21"
        Me.Panel21.Size = New System.Drawing.Size(21, 21)
        Me.Panel21.TabIndex = 0
        '
        'pnlBottom
        '
        Me.pnlBottom.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBottom.Controls.Add(Me.pnlNormalPayment)
        Me.pnlBottom.Controls.Add(Me.pnlBalanceContractPayment)
        Me.pnlBottom.Controls.Add(Me.pnlReturnPayment)
        Me.pnlBottom.Controls.Add(Me.tlpBottom)
        Me.pnlBottom.Location = New System.Drawing.Point(2, 1)
        Me.pnlBottom.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(499, 132)
        Me.pnlBottom.TabIndex = 0
        '
        'pnlNormalPayment
        '
        Me.pnlNormalPayment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlNormalPayment.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.pnlNormalPayment.Controls.Add(Me.tlpPayment)
        Me.pnlNormalPayment.Controls.Add(Me.Label14)
        Me.pnlNormalPayment.Controls.Add(Me.dgvPayment)
        Me.pnlNormalPayment.Location = New System.Drawing.Point(13, 13)
        Me.pnlNormalPayment.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlNormalPayment.Name = "pnlNormalPayment"
        Me.pnlNormalPayment.Size = New System.Drawing.Size(474, 107)
        Me.pnlNormalPayment.TabIndex = 3
        '
        'tlpPayment
        '
        Me.tlpPayment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpPayment.ColumnCount = 14
        Me.tlpPayment.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpPayment.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPayment.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpPayment.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpPayment.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpPayment.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpPayment.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpPayment.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpPayment.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpPayment.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpPayment.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpPayment.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpPayment.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpPayment.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpPayment.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpPayment.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpPayment.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpPayment.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpPayment.Controls.Add(Me.lblTotalPayAmtTitle, 2, 0)
        Me.tlpPayment.Controls.Add(Me.lblTotalPayAmt, 3, 0)
        Me.tlpPayment.Controls.Add(Me.lblTotalPayAmtUnit, 4, 0)
        Me.tlpPayment.Controls.Add(Me.Label4, 5, 0)
        Me.tlpPayment.Controls.Add(Me.lblPayable, 6, 0)
        Me.tlpPayment.Controls.Add(Me.Label8, 7, 0)
        Me.tlpPayment.Controls.Add(Me.Label16, 8, 0)
        Me.tlpPayment.Controls.Add(Me.lblPaid, 9, 0)
        Me.tlpPayment.Controls.Add(Me.Label11, 10, 0)
        Me.tlpPayment.Controls.Add(Me.lblUnpaidTitle, 11, 0)
        Me.tlpPayment.Controls.Add(Me.lblUnpaid, 12, 0)
        Me.tlpPayment.Controls.Add(Me.Label20, 13, 0)
        Me.tlpPayment.Controls.Add(Me.btnModifyPaymentInfo, 0, 0)
        Me.tlpPayment.Location = New System.Drawing.Point(1, 83)
        Me.tlpPayment.Name = "tlpPayment"
        Me.tlpPayment.RowCount = 1
        Me.tlpPayment.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPayment.Size = New System.Drawing.Size(473, 23)
        Me.tlpPayment.TabIndex = 3
        '
        'lblTotalPayAmtTitle
        '
        Me.lblTotalPayAmtTitle.AutoSize = True
        Me.lblTotalPayAmtTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTotalPayAmtTitle.Location = New System.Drawing.Point(2, 6)
        Me.lblTotalPayAmtTitle.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Me.lblTotalPayAmtTitle.Name = "lblTotalPayAmtTitle"
        Me.lblTotalPayAmtTitle.Size = New System.Drawing.Size(89, 17)
        Me.lblTotalPayAmtTitle.TabIndex = 10
        Me.lblTotalPayAmtTitle.Text = "可开票总金额："
        Me.lblTotalPayAmtTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblTotalPayAmtTitle.Visible = False
        '
        'lblTotalPayAmt
        '
        Me.lblTotalPayAmt.AutoSize = True
        Me.lblTotalPayAmt.BackColor = System.Drawing.SystemColors.Control
        Me.lblTotalPayAmt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTotalPayAmt.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalPayAmt.ForeColor = System.Drawing.Color.Maroon
        Me.lblTotalPayAmt.Location = New System.Drawing.Point(91, 4)
        Me.lblTotalPayAmt.Margin = New System.Windows.Forms.Padding(0, 4, 0, 0)
        Me.lblTotalPayAmt.Name = "lblTotalPayAmt"
        Me.lblTotalPayAmt.Size = New System.Drawing.Size(44, 19)
        Me.lblTotalPayAmt.TabIndex = 11
        Me.lblTotalPayAmt.Text = "0.00"
        Me.lblTotalPayAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblTotalPayAmt.Visible = False
        '
        'lblTotalPayAmtUnit
        '
        Me.lblTotalPayAmtUnit.AutoSize = True
        Me.lblTotalPayAmtUnit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTotalPayAmtUnit.Location = New System.Drawing.Point(135, 6)
        Me.lblTotalPayAmtUnit.Margin = New System.Windows.Forms.Padding(0, 6, 3, 0)
        Me.lblTotalPayAmtUnit.Name = "lblTotalPayAmtUnit"
        Me.lblTotalPayAmtUnit.Size = New System.Drawing.Size(17, 17)
        Me.lblTotalPayAmtUnit.TabIndex = 12
        Me.lblTotalPayAmtUnit.Text = "元"
        Me.lblTotalPayAmtUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTotalPayAmtUnit.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(155, 6)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 17)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "应付："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPayable
        '
        Me.lblPayable.AutoSize = True
        Me.lblPayable.BackColor = System.Drawing.SystemColors.Control
        Me.lblPayable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPayable.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblPayable.ForeColor = System.Drawing.Color.Maroon
        Me.lblPayable.Location = New System.Drawing.Point(196, 4)
        Me.lblPayable.Margin = New System.Windows.Forms.Padding(0, 4, 0, 0)
        Me.lblPayable.Name = "lblPayable"
        Me.lblPayable.Size = New System.Drawing.Size(44, 19)
        Me.lblPayable.TabIndex = 2
        Me.lblPayable.Text = "0.00"
        Me.lblPayable.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Location = New System.Drawing.Point(240, 6)
        Me.Label8.Margin = New System.Windows.Forms.Padding(0, 6, 3, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(17, 17)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "元"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label16.Location = New System.Drawing.Point(263, 6)
        Me.Label16.Margin = New System.Windows.Forms.Padding(3, 6, 0, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(41, 17)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "已付："
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPaid
        '
        Me.lblPaid.AutoSize = True
        Me.lblPaid.BackColor = System.Drawing.SystemColors.Control
        Me.lblPaid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPaid.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblPaid.ForeColor = System.Drawing.Color.Maroon
        Me.lblPaid.Location = New System.Drawing.Point(304, 4)
        Me.lblPaid.Margin = New System.Windows.Forms.Padding(0, 4, 0, 0)
        Me.lblPaid.Name = "lblPaid"
        Me.lblPaid.Size = New System.Drawing.Size(44, 19)
        Me.lblPaid.TabIndex = 5
        Me.lblPaid.Text = "0.00"
        Me.lblPaid.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Location = New System.Drawing.Point(348, 6)
        Me.Label11.Margin = New System.Windows.Forms.Padding(0, 6, 3, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(17, 17)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "元"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUnpaidTitle
        '
        Me.lblUnpaidTitle.AutoSize = True
        Me.lblUnpaidTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblUnpaidTitle.Location = New System.Drawing.Point(371, 6)
        Me.lblUnpaidTitle.Margin = New System.Windows.Forms.Padding(3, 6, 0, 0)
        Me.lblUnpaidTitle.Name = "lblUnpaidTitle"
        Me.lblUnpaidTitle.Size = New System.Drawing.Size(41, 17)
        Me.lblUnpaidTitle.TabIndex = 7
        Me.lblUnpaidTitle.Text = "未付："
        Me.lblUnpaidTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblUnpaid
        '
        Me.lblUnpaid.AutoSize = True
        Me.lblUnpaid.BackColor = System.Drawing.SystemColors.Control
        Me.lblUnpaid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblUnpaid.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblUnpaid.ForeColor = System.Drawing.Color.Maroon
        Me.lblUnpaid.Location = New System.Drawing.Point(412, 4)
        Me.lblUnpaid.Margin = New System.Windows.Forms.Padding(0, 4, 0, 0)
        Me.lblUnpaid.Name = "lblUnpaid"
        Me.lblUnpaid.Size = New System.Drawing.Size(44, 19)
        Me.lblUnpaid.TabIndex = 8
        Me.lblUnpaid.Text = "0.00"
        Me.lblUnpaid.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label20.Location = New System.Drawing.Point(456, 6)
        Me.Label20.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(17, 17)
        Me.Label20.TabIndex = 9
        Me.Label20.Text = "元"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnModifyPaymentInfo
        '
        Me.btnModifyPaymentInfo.Location = New System.Drawing.Point(0, 0)
        Me.btnModifyPaymentInfo.Margin = New System.Windows.Forms.Padding(0)
        Me.btnModifyPaymentInfo.Name = "btnModifyPaymentInfo"
        Me.btnModifyPaymentInfo.Size = New System.Drawing.Size(50, 23)
        Me.btnModifyPaymentInfo.TabIndex = 0
        Me.btnModifyPaymentInfo.Text = "修改付款信息"
        Me.btnModifyPaymentInfo.UseVisualStyleBackColor = True
        Me.btnModifyPaymentInfo.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label14.Location = New System.Drawing.Point(0, 0)
        Me.Label14.Margin = New System.Windows.Forms.Padding(0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(77, 12)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "销售单付款："
        '
        'dgvPayment
        '
        Me.dgvPayment.AllowUserToAddRows = False
        Me.dgvPayment.AllowUserToDeleteRows = False
        Me.dgvPayment.AllowUserToResizeRows = False
        Me.dgvPayment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPayment.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvPayment.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPayment.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvPayment.ColumnHeadersHeight = 22
        Me.dgvPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvPayment.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvPayment.Location = New System.Drawing.Point(1, 15)
        Me.dgvPayment.MultiSelect = False
        Me.dgvPayment.Name = "dgvPayment"
        Me.dgvPayment.RowHeadersVisible = False
        Me.dgvPayment.RowTemplate.Height = 24
        Me.dgvPayment.Size = New System.Drawing.Size(472, 84)
        Me.dgvPayment.StandardTab = True
        Me.dgvPayment.TabIndex = 1
        '
        'pnlBalanceContractPayment
        '
        Me.pnlBalanceContractPayment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBalanceContractPayment.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.pnlBalanceContractPayment.Controls.Add(Me.Label73)
        Me.pnlBalanceContractPayment.Location = New System.Drawing.Point(13, 13)
        Me.pnlBalanceContractPayment.Name = "pnlBalanceContractPayment"
        Me.pnlBalanceContractPayment.Size = New System.Drawing.Size(474, 104)
        Me.pnlBalanceContractPayment.TabIndex = 2
        '
        'Label73
        '
        Me.Label73.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label73.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label73.ForeColor = System.Drawing.Color.Maroon
        Me.Label73.Location = New System.Drawing.Point(0, 0)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(474, 104)
        Me.Label73.TabIndex = 0
        Me.Label73.Text = "结算到期合同剩余返点时，不能售卖正常卡，客户无须付款。"
        Me.Label73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlReturnPayment
        '
        Me.pnlReturnPayment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlReturnPayment.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.pnlReturnPayment.Controls.Add(Me.txbRefundNo)
        Me.pnlReturnPayment.Controls.Add(Me.dtpRefundDate)
        Me.pnlReturnPayment.Controls.Add(Me.Label47)
        Me.pnlReturnPayment.Controls.Add(Me.Label35)
        Me.pnlReturnPayment.Controls.Add(Me.lblRefundTitle)
        Me.pnlReturnPayment.Controls.Add(Me.Label32)
        Me.pnlReturnPayment.Controls.Add(Me.txbRefundDate)
        Me.pnlReturnPayment.Location = New System.Drawing.Point(13, 13)
        Me.pnlReturnPayment.Name = "pnlReturnPayment"
        Me.pnlReturnPayment.Size = New System.Drawing.Size(474, 104)
        Me.pnlReturnPayment.TabIndex = 1
        '
        'txbRefundNo
        '
        Me.txbRefundNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbRefundNo.Location = New System.Drawing.Point(65, 78)
        Me.txbRefundNo.MaxLength = 50
        Me.txbRefundNo.Name = "txbRefundNo"
        Me.txbRefundNo.Size = New System.Drawing.Size(86, 21)
        Me.txbRefundNo.TabIndex = 7
        '
        'dtpRefundDate
        '
        Me.dtpRefundDate.CustomFormat = "yyyy/MM/dd"
        Me.dtpRefundDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpRefundDate.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.dtpRefundDate.Location = New System.Drawing.Point(65, 51)
        Me.dtpRefundDate.Name = "dtpRefundDate"
        Me.dtpRefundDate.Size = New System.Drawing.Size(86, 21)
        Me.dtpRefundDate.TabIndex = 4
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(0, 83)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(65, 12)
        Me.Label47.TabIndex = 6
        Me.Label47.Text = "退货单号："
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(0, 57)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(65, 12)
        Me.Label35.TabIndex = 2
        Me.Label35.Text = "退货日期："
        '
        'lblRefundTitle
        '
        Me.lblRefundTitle.AutoSize = True
        Me.lblRefundTitle.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblRefundTitle.Location = New System.Drawing.Point(1, 27)
        Me.lblRefundTitle.Name = "lblRefundTitle"
        Me.lblRefundTitle.Size = New System.Drawing.Size(233, 12)
        Me.lblRefundTitle.TabIndex = 1
        Me.lblRefundTitle.Text = "但需要输入如下来自退货中心的退货信息："
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label32.ForeColor = System.Drawing.Color.Maroon
        Me.Label32.Location = New System.Drawing.Point(0, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(212, 16)
        Me.Label32.TabIndex = 0
        Me.Label32.Text = "退货销售，客户无须付款。"
        '
        'txbRefundDate
        '
        Me.txbRefundDate.Location = New System.Drawing.Point(65, 51)
        Me.txbRefundDate.Name = "txbRefundDate"
        Me.txbRefundDate.ReadOnly = True
        Me.txbRefundDate.Size = New System.Drawing.Size(86, 21)
        Me.txbRefundDate.TabIndex = 3
        Me.txbRefundDate.Visible = False
        '
        'tlpBottom
        '
        Me.tlpBottom.ColumnCount = 3
        Me.tlpBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.tlpBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.tlpBottom.Controls.Add(Me.Panel32, 2, 2)
        Me.tlpBottom.Controls.Add(Me.Panel33, 1, 2)
        Me.tlpBottom.Controls.Add(Me.Panel34, 0, 2)
        Me.tlpBottom.Controls.Add(Me.Panel35, 2, 1)
        Me.tlpBottom.Controls.Add(Me.Panel36, 1, 1)
        Me.tlpBottom.Controls.Add(Me.Panel37, 0, 1)
        Me.tlpBottom.Controls.Add(Me.Panel38, 2, 0)
        Me.tlpBottom.Controls.Add(Me.Panel39, 1, 0)
        Me.tlpBottom.Controls.Add(Me.Panel40, 0, 0)
        Me.tlpBottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpBottom.Location = New System.Drawing.Point(0, 0)
        Me.tlpBottom.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpBottom.Name = "tlpBottom"
        Me.tlpBottom.RowCount = 3
        Me.tlpBottom.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.tlpBottom.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpBottom.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.tlpBottom.Size = New System.Drawing.Size(499, 132)
        Me.tlpBottom.TabIndex = 0
        '
        'Panel32
        '
        Me.Panel32.BackgroundImage = CType(resources.GetObject("Panel32.BackgroundImage"), System.Drawing.Image)
        Me.Panel32.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel32.Location = New System.Drawing.Point(478, 111)
        Me.Panel32.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel32.Name = "Panel32"
        Me.Panel32.Size = New System.Drawing.Size(21, 21)
        Me.Panel32.TabIndex = 8
        '
        'Panel33
        '
        Me.Panel33.BackgroundImage = CType(resources.GetObject("Panel33.BackgroundImage"), System.Drawing.Image)
        Me.Panel33.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel33.Location = New System.Drawing.Point(21, 111)
        Me.Panel33.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel33.Name = "Panel33"
        Me.Panel33.Size = New System.Drawing.Size(457, 21)
        Me.Panel33.TabIndex = 7
        '
        'Panel34
        '
        Me.Panel34.BackgroundImage = CType(resources.GetObject("Panel34.BackgroundImage"), System.Drawing.Image)
        Me.Panel34.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel34.Location = New System.Drawing.Point(0, 111)
        Me.Panel34.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel34.Name = "Panel34"
        Me.Panel34.Size = New System.Drawing.Size(21, 21)
        Me.Panel34.TabIndex = 6
        '
        'Panel35
        '
        Me.Panel35.BackgroundImage = CType(resources.GetObject("Panel35.BackgroundImage"), System.Drawing.Image)
        Me.Panel35.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel35.Location = New System.Drawing.Point(478, 21)
        Me.Panel35.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel35.Name = "Panel35"
        Me.Panel35.Size = New System.Drawing.Size(21, 90)
        Me.Panel35.TabIndex = 5
        '
        'Panel36
        '
        Me.Panel36.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.Panel36.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel36.Location = New System.Drawing.Point(21, 21)
        Me.Panel36.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel36.Name = "Panel36"
        Me.Panel36.Size = New System.Drawing.Size(457, 90)
        Me.Panel36.TabIndex = 4
        '
        'Panel37
        '
        Me.Panel37.BackgroundImage = CType(resources.GetObject("Panel37.BackgroundImage"), System.Drawing.Image)
        Me.Panel37.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel37.Location = New System.Drawing.Point(0, 21)
        Me.Panel37.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel37.Name = "Panel37"
        Me.Panel37.Size = New System.Drawing.Size(21, 90)
        Me.Panel37.TabIndex = 3
        '
        'Panel38
        '
        Me.Panel38.BackgroundImage = CType(resources.GetObject("Panel38.BackgroundImage"), System.Drawing.Image)
        Me.Panel38.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel38.Location = New System.Drawing.Point(478, 0)
        Me.Panel38.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel38.Name = "Panel38"
        Me.Panel38.Size = New System.Drawing.Size(21, 21)
        Me.Panel38.TabIndex = 2
        '
        'Panel39
        '
        Me.Panel39.BackgroundImage = CType(resources.GetObject("Panel39.BackgroundImage"), System.Drawing.Image)
        Me.Panel39.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel39.Location = New System.Drawing.Point(21, 0)
        Me.Panel39.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel39.Name = "Panel39"
        Me.Panel39.Size = New System.Drawing.Size(457, 21)
        Me.Panel39.TabIndex = 1
        '
        'Panel40
        '
        Me.Panel40.BackgroundImage = CType(resources.GetObject("Panel40.BackgroundImage"), System.Drawing.Image)
        Me.Panel40.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel40.Location = New System.Drawing.Point(0, 0)
        Me.Panel40.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel40.Name = "Panel40"
        Me.Panel40.Size = New System.Drawing.Size(21, 21)
        Me.Panel40.TabIndex = 0
        '
        'theTip
        '
        Me.theTip.AutoPopDelay = 15000
        Me.theTip.InitialDelay = 500
        Me.theTip.ReshowDelay = 100
        '
        'theTimer
        '
        '
        'cmenuDeleteNormalCard
        '
        Me.cmenuDeleteNormalCard.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuDeleteNormalCard})
        Me.cmenuDeleteNormalCard.Name = "cmenuDeleteCardRow"
        Me.cmenuDeleteNormalCard.Size = New System.Drawing.Size(142, 26)
        '
        'menuDeleteNormalCard
        '
        Me.menuDeleteNormalCard.Name = "menuDeleteNormalCard"
        Me.menuDeleteNormalCard.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.menuDeleteNormalCard.Size = New System.Drawing.Size(141, 22)
        Me.menuDeleteNormalCard.Text = "删除行   "
        '
        'cmenuDeleteRebateCard
        '
        Me.cmenuDeleteRebateCard.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuDeleteRebateCard})
        Me.cmenuDeleteRebateCard.Name = "cmenuDeleteCardRow"
        Me.cmenuDeleteRebateCard.Size = New System.Drawing.Size(142, 26)
        '
        'menuDeleteRebateCard
        '
        Me.menuDeleteRebateCard.Name = "menuDeleteRebateCard"
        Me.menuDeleteRebateCard.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.menuDeleteRebateCard.Size = New System.Drawing.Size(141, 22)
        Me.menuDeleteRebateCard.Text = "删除行   "
        '
        'cmenuDeletePayment
        '
        Me.cmenuDeletePayment.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuDeletePayment})
        Me.cmenuDeletePayment.Name = "cmenuDeleteCardRow"
        Me.cmenuDeletePayment.Size = New System.Drawing.Size(142, 26)
        '
        'menuDeletePayment
        '
        Me.menuDeletePayment.Name = "menuDeletePayment"
        Me.menuDeletePayment.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.menuDeletePayment.Size = New System.Drawing.Size(141, 22)
        Me.menuDeletePayment.Text = "删除行   "
        '
        'pnlSelectablePayment
        '
        Me.pnlSelectablePayment.BackColor = System.Drawing.SystemColors.Window
        Me.pnlSelectablePayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSelectablePayment.Controls.Add(Me.dgvSelectablePayment)
        Me.pnlSelectablePayment.Location = New System.Drawing.Point(762, 62)
        Me.pnlSelectablePayment.Name = "pnlSelectablePayment"
        Me.pnlSelectablePayment.Size = New System.Drawing.Size(200, 100)
        Me.pnlSelectablePayment.TabIndex = 1
        Me.pnlSelectablePayment.Visible = False
        '
        'dgvSelectablePayment
        '
        Me.dgvSelectablePayment.AllowUserToAddRows = False
        Me.dgvSelectablePayment.AllowUserToDeleteRows = False
        Me.dgvSelectablePayment.AllowUserToResizeRows = False
        Me.dgvSelectablePayment.BackgroundColor = System.Drawing.Color.Coral
        Me.dgvSelectablePayment.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSelectablePayment.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Coral
        DataGridViewCellStyle4.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSelectablePayment.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvSelectablePayment.ColumnHeadersHeight = 24
        Me.dgvSelectablePayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.PeachPuff
        DataGridViewCellStyle5.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.PeachPuff
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSelectablePayment.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvSelectablePayment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSelectablePayment.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvSelectablePayment.EnableHeadersVisualStyles = False
        Me.dgvSelectablePayment.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.dgvSelectablePayment.Location = New System.Drawing.Point(0, 0)
        Me.dgvSelectablePayment.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvSelectablePayment.MultiSelect = False
        Me.dgvSelectablePayment.Name = "dgvSelectablePayment"
        Me.dgvSelectablePayment.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvSelectablePayment.RowHeadersVisible = False
        Me.dgvSelectablePayment.RowTemplate.Height = 24
        Me.dgvSelectablePayment.Size = New System.Drawing.Size(198, 98)
        Me.dgvSelectablePayment.StandardTab = True
        Me.dgvSelectablePayment.TabIndex = 1
        '
        'cmenuCardCost
        '
        Me.cmenuCardCost.Name = "cmenuCardCost"
        Me.cmenuCardCost.Size = New System.Drawing.Size(61, 4)
        '
        'pcbSelectablPayment
        '
        Me.pcbSelectablPayment.Image = Global.ShoppingCardSystem.My.Resources.Resources.PaymentDown
        Me.pcbSelectablPayment.Location = New System.Drawing.Point(937, 39)
        Me.pcbSelectablPayment.Name = "pcbSelectablPayment"
        Me.pcbSelectablPayment.Size = New System.Drawing.Size(23, 23)
        Me.pcbSelectablPayment.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pcbSelectablPayment.TabIndex = 3
        Me.pcbSelectablPayment.TabStop = False
        Me.pcbSelectablPayment.Visible = False
        '
        'frmSelling
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(972, 690)
        Me.Controls.Add(Me.pcbSelectablPayment)
        Me.Controls.Add(Me.pnlSelectablePayment)
        Me.Controls.Add(Me.splitLayout)
        Me.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSelling"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "创建销售单"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.splitLayout.Panel1.ResumeLayout(False)
        Me.splitLayout.Panel2.ResumeLayout(False)
        Me.splitLayout.ResumeLayout(False)
        Me.pnlLeft.ResumeLayout(False)
        Me.flpLeftContainer.ResumeLayout(False)
        Me.flpLeftContainer.PerformLayout()
        Me.grbSalesBillType.ResumeLayout(False)
        Me.grbSalesBillType.PerformLayout()
        Me.flpEmployee.ResumeLayout(False)
        Me.grbInputEmployeeNo.ResumeLayout(False)
        Me.grbInputEmployeeNo.PerformLayout()
        Me.grbEmployeeInfo.ResumeLayout(False)
        Me.grbEmployeeInfo.PerformLayout()
        Me.flpEmployeeInfo.ResumeLayout(False)
        Me.pnlEmployeeNo.ResumeLayout(False)
        Me.pnlEmployeeNo.PerformLayout()
        Me.pnlEmployeeInfo.ResumeLayout(False)
        Me.pnlEmployeeInfo.PerformLayout()
        Me.pnlEmployeeTel.ResumeLayout(False)
        Me.pnlEmployeeTel.PerformLayout()
        Me.grbInputEmployeeTel.ResumeLayout(False)
        Me.grbInputEmployeeTel.PerformLayout()
        Me.grbEmployeeQuota.ResumeLayout(False)
        Me.grbEmployeeQuota.PerformLayout()
        Me.flpEmployeeQuota.ResumeLayout(False)
        Me.flpEmployeeQuota.PerformLayout()
        Me.pnlQuota.ResumeLayout(False)
        Me.pnlQuota.PerformLayout()
        Me.pnlUsedQuota.ResumeLayout(False)
        Me.pnlUsedQuota.PerformLayout()
        Me.tlpAvailableQuota.ResumeLayout(False)
        Me.pnlAvailableRebateQuota.ResumeLayout(False)
        Me.pnlAvailableRebateQuota.PerformLayout()
        Me.pnlMaxAvailableQuota.ResumeLayout(False)
        Me.pnlMaxAvailableQuota.PerformLayout()
        Me.tlpDistributedQuota.ResumeLayout(False)
        Me.pnlDistributedBalanceRebateQuota.ResumeLayout(False)
        Me.pnlDistributedBalanceRebateQuota.PerformLayout()
        Me.pnlDistributedQuota.ResumeLayout(False)
        Me.pnlDistributedQuota.PerformLayout()
        Me.tlpBalanceQuota.ResumeLayout(False)
        Me.tlpBalanceQuota.PerformLayout()
        Me.pnlBalanceRebateQuota.ResumeLayout(False)
        Me.pnlBalanceRebateQuota.PerformLayout()
        Me.pnlBalancePurchaseQuota.ResumeLayout(False)
        Me.pnlBalancePurchaseQuota.PerformLayout()
        Me.grbPromotionInfo.ResumeLayout(False)
        Me.grbPromotionInfo.PerformLayout()
        Me.pnlPromotionPeriod.ResumeLayout(False)
        Me.pnlPromotionPeriod.PerformLayout()
        Me.pnlPromotionPeriodReadOnly.ResumeLayout(False)
        Me.pnlPromotionPeriodReadOnly.PerformLayout()
        Me.grbCustomer.ResumeLayout(False)
        Me.grbCustomer.PerformLayout()
        Me.flpCustomer.ResumeLayout(False)
        Me.pnlSelectStore.ResumeLayout(False)
        Me.pnlSelectStore.PerformLayout()
        Me.pnlCustomerType.ResumeLayout(False)
        Me.pnlCustomerType.PerformLayout()
        Me.pnlCompanyCustomer.ResumeLayout(False)
        Me.pnlCompanyCustomer.PerformLayout()
        Me.pnlCustomerButtons.ResumeLayout(False)
        Me.grbAvailablePayer.ResumeLayout(False)
        Me.grbAvailablePayer.PerformLayout()
        Me.grbBuyerInfo.ResumeLayout(False)
        Me.pnlBuyerName.ResumeLayout(False)
        Me.pnlBuyerName.PerformLayout()
        Me.pnlBuyerCredentials.ResumeLayout(False)
        Me.pnlBuyerCredentials.PerformLayout()
        Me.grbMemberInfo.ResumeLayout(False)
        Me.grbMemberInfo.PerformLayout()
        Me.grbBalanceContract.ResumeLayout(False)
        Me.grbBalanceContract.PerformLayout()
        Me.flpBalanceContract.ResumeLayout(False)
        Me.pnlPreviousDistribution.ResumeLayout(False)
        Me.pnlPreviousDistribution.PerformLayout()
        Me.pnlPreviousBalance.ResumeLayout(False)
        Me.pnlPreviousBalance.PerformLayout()
        Me.grbContract.ResumeLayout(False)
        Me.grbContract.PerformLayout()
        Me.flpContract.ResumeLayout(False)
        Me.pnlThisPurchaseRebate.ResumeLayout(False)
        Me.pnlThisPurchaseRebate.PerformLayout()
        Me.pnlThisPurchaseRemarks.ResumeLayout(False)
        Me.pnlThisPurchaseRemarks.PerformLayout()
        Me.pnlHistoryPurchaseRebate.ResumeLayout(False)
        Me.pnlHistoryPurchaseRebate.PerformLayout()
        Me.pnlHistoryPurchaseRemarks.ResumeLayout(False)
        Me.pnlHistoryPurchaseRemarks.PerformLayout()
        Me.pnlAvailableRebateSalesAMT.ResumeLayout(False)
        Me.pnlAvailableRebateSalesAMT.PerformLayout()
        Me.pnlRebatSalesAMT.ResumeLayout(False)
        Me.pnlRebatSalesAMT.PerformLayout()
        Me.pnlBalanceRebateAMT.ResumeLayout(False)
        Me.pnlBalanceRebateAMT.PerformLayout()
        Me.grbNormalRebate.ResumeLayout(False)
        Me.grbNormalRebate.PerformLayout()
        Me.flpNormalRebate.ResumeLayout(False)
        Me.pnlMaxNormalRebateCalculation.ResumeLayout(False)
        Me.pnlMaxNormalRebateCalculation.PerformLayout()
        Me.pnlNormalRebate.ResumeLayout(False)
        Me.pnlNormalRebate.PerformLayout()
        Me.pnlNormalRebateState.ResumeLayout(False)
        Me.pnlNormalRebateState.PerformLayout()
        Me.pnlNormalRebateRemarks.ResumeLayout(False)
        Me.pnlNormalRebateRemarks.PerformLayout()
        Me.pnlDistributionNormalRebateAMT.ResumeLayout(False)
        Me.pnlDistributionNormalRebateAMT.PerformLayout()
        Me.pnlBalanceNormalRebateAMT.ResumeLayout(False)
        Me.pnlBalanceNormalRebateAMT.PerformLayout()
        Me.pnlModifyNormalRebate.ResumeLayout(False)
        Me.grbPrintDiscount.ResumeLayout(False)
        Me.grbPrintDiscount.PerformLayout()
        Me.grbSalesBillSummary.ResumeLayout(False)
        Me.grbSalesBillSummary.PerformLayout()
        Me.flpSalesBillSummary.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.pnlActivationSummary.ResumeLayout(False)
        Me.pnlActivationSummary.PerformLayout()
        Me.Panel17.ResumeLayout(False)
        Me.Panel17.PerformLayout()
        Me.pnlCardCost.ResumeLayout(False)
        Me.pnlCardCost.PerformLayout()
        Me.grbSalesBillInfo.ResumeLayout(False)
        Me.grbSalesBillInfo.PerformLayout()
        Me.pnlSalesBillStateDescription.ResumeLayout(False)
        Me.pnlSalesBillStateDescription.PerformLayout()
        Me.pnlAddjustSalesman.ResumeLayout(False)
        Me.tlpLeft.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.splitRight.Panel1.ResumeLayout(False)
        Me.splitRight.Panel2.ResumeLayout(False)
        Me.splitRight.ResumeLayout(False)
        Me.pnlRight.ResumeLayout(False)
        Me.splitList.Panel1.ResumeLayout(False)
        Me.splitList.Panel1.PerformLayout()
        Me.splitList.Panel2.ResumeLayout(False)
        Me.splitList.Panel2.PerformLayout()
        Me.splitList.ResumeLayout(False)
        Me.pnlImportedFile.ResumeLayout(False)
        Me.pnlImportedFile.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        CType(Me.dgvNormalCard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDeductionAMT.ResumeLayout(False)
        Me.pnlDeductionAMT.PerformLayout()
        CType(Me.dgvRebateCard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpRight.ResumeLayout(False)
        Me.Panel41.ResumeLayout(False)
        Me.pnlFunction.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel42.ResumeLayout(False)
        Me.Panel18.ResumeLayout(False)
        Me.Panel23.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.pnlBottom.ResumeLayout(False)
        Me.pnlNormalPayment.ResumeLayout(False)
        Me.pnlNormalPayment.PerformLayout()
        Me.tlpPayment.ResumeLayout(False)
        Me.tlpPayment.PerformLayout()
        CType(Me.dgvPayment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBalanceContractPayment.ResumeLayout(False)
        Me.pnlReturnPayment.ResumeLayout(False)
        Me.pnlReturnPayment.PerformLayout()
        Me.tlpBottom.ResumeLayout(False)
        Me.cmenuDeleteNormalCard.ResumeLayout(False)
        Me.cmenuDeleteRebateCard.ResumeLayout(False)
        Me.cmenuDeletePayment.ResumeLayout(False)
        Me.pnlSelectablePayment.ResumeLayout(False)
        CType(Me.dgvSelectablePayment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcbSelectablPayment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents splitLayout As System.Windows.Forms.SplitContainer
    Friend WithEvents pnlLeft As System.Windows.Forms.Panel
    Friend WithEvents flpContainer As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents grbCustomer As System.Windows.Forms.GroupBox
    Friend WithEvents cbbBuyerName As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbbCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents lblCustomerName As System.Windows.Forms.Label
    Friend WithEvents tlpLeft As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents splitRight As System.Windows.Forms.SplitContainer
    Friend WithEvents pnlRight As System.Windows.Forms.Panel
    Friend WithEvents dgvNormalCard As System.Windows.Forms.DataGridView
    Friend WithEvents tlpRight As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel22 As System.Windows.Forms.Panel
    Friend WithEvents Panel24 As System.Windows.Forms.Panel
    Friend WithEvents Panel25 As System.Windows.Forms.Panel
    Friend WithEvents Panel26 As System.Windows.Forms.Panel
    Friend WithEvents Panel27 As System.Windows.Forms.Panel
    Friend WithEvents Panel28 As System.Windows.Forms.Panel
    Friend WithEvents Panel29 As System.Windows.Forms.Panel
    Friend WithEvents Panel30 As System.Windows.Forms.Panel
    Friend WithEvents Panel31 As System.Windows.Forms.Panel
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents tlpBottom As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel32 As System.Windows.Forms.Panel
    Friend WithEvents Panel33 As System.Windows.Forms.Panel
    Friend WithEvents Panel34 As System.Windows.Forms.Panel
    Friend WithEvents Panel35 As System.Windows.Forms.Panel
    Friend WithEvents Panel36 As System.Windows.Forms.Panel
    Friend WithEvents Panel37 As System.Windows.Forms.Panel
    Friend WithEvents Panel38 As System.Windows.Forms.Panel
    Friend WithEvents Panel39 As System.Windows.Forms.Panel
    Friend WithEvents Panel40 As System.Windows.Forms.Panel
    Friend WithEvents flpLeftContainer As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnViewCustomer As System.Windows.Forms.Button
    Friend WithEvents btnNewCustomer As System.Windows.Forms.Button
    Friend WithEvents Panel41 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents Panel15 As System.Windows.Forms.Panel
    Friend WithEvents Panel16 As System.Windows.Forms.Panel
    Friend WithEvents Panel19 As System.Windows.Forms.Panel
    Friend WithEvents Panel20 As System.Windows.Forms.Panel
    Friend WithEvents Panel21 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnPrintInvoice As System.Windows.Forms.Button
    Friend WithEvents btnPrintTicket As System.Windows.Forms.Button
    Friend WithEvents btnViewActivation As System.Windows.Forms.Button
    Friend WithEvents grbSalesBillType As System.Windows.Forms.GroupBox
    Friend WithEvents cbbSalesBillType As System.Windows.Forms.ComboBox
    Friend WithEvents btnNewSalesBill As System.Windows.Forms.Button
    Friend WithEvents cbbTelMP As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents theTip As System.Windows.Forms.ToolTip
    Friend WithEvents theTimer As System.Windows.Forms.Timer
    Friend WithEvents lblNormalListTitle As System.Windows.Forms.Label
    Friend WithEvents txbSalesBillType As System.Windows.Forms.TextBox
    Friend WithEvents grbSalesBillInfo As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblCreatorName As System.Windows.Forms.Label
    Friend WithEvents lblCreatedTime As System.Windows.Forms.Label
    Friend WithEvents lblSalesBillCode As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblSalesBillState As System.Windows.Forms.Label
    Friend WithEvents pnlNormalPayment As System.Windows.Forms.Panel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dgvPayment As System.Windows.Forms.DataGridView
    Friend WithEvents tlpPayment As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblPayable As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblPaid As System.Windows.Forms.Label
    Friend WithEvents lblUnpaid As System.Windows.Forms.Label
    Friend WithEvents lblUnpaidTitle As System.Windows.Forms.Label
    Friend WithEvents splitList As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvRebateCard As System.Windows.Forms.DataGridView
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cbbCustomerType As System.Windows.Forms.ComboBox
    Friend WithEvents Label119 As System.Windows.Forms.Label
    Friend WithEvents txbCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents txbBuyerName As System.Windows.Forms.TextBox
    Friend WithEvents txbTelMP As System.Windows.Forms.TextBox
    Friend WithEvents grbNormalRebate As System.Windows.Forms.GroupBox
    Friend WithEvents chbNormalRebate As System.Windows.Forms.CheckBox
    Friend WithEvents btnViewCityRule As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txbNormalRebateAMT As System.Windows.Forms.TextBox
    Friend WithEvents txbNormalRebateRate As System.Windows.Forms.TextBox
    Friend WithEvents pnlSalesBillStateDescription As System.Windows.Forms.Panel
    Friend WithEvents lblNormalRebateRemarks As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblSalesBillRemarks As System.Windows.Forms.Label
    Friend WithEvents grbContract As System.Windows.Forms.GroupBox
    Friend WithEvents flpCustomer As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlCompanyCustomer As System.Windows.Forms.Panel
    Friend WithEvents pnlBuyerName As System.Windows.Forms.Panel
    Friend WithEvents pnlCustomerButtons As System.Windows.Forms.Panel
    Friend WithEvents lblNormalRebate As System.Windows.Forms.Label
    Friend WithEvents pnlCustomerType As System.Windows.Forms.Panel
    Friend WithEvents lblNormalCardSummary As System.Windows.Forms.Label
    Friend WithEvents lblRebateCardSummary As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txbContractCode As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents btnViewContract As System.Windows.Forms.Button
    Friend WithEvents flpContract As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlThisPurchaseRebate As System.Windows.Forms.Panel
    Friend WithEvents txbThisSalesAMT As System.Windows.Forms.TextBox
    Friend WithEvents lblThisPurchaseRebate As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txbThisRebateAMT As System.Windows.Forms.TextBox
    Friend WithEvents txbThisRebateRate As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents lblThisRebateAMT As System.Windows.Forms.Label
    Friend WithEvents lblThisRebateRate As System.Windows.Forms.Label
    Friend WithEvents lblThisSalesAMT As System.Windows.Forms.Label
    Friend WithEvents pnlThisPurchaseRemarks As System.Windows.Forms.Panel
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents lblThisPurchaseRemarks As System.Windows.Forms.Label
    Friend WithEvents pnlHistoryPurchaseRebate As System.Windows.Forms.Panel
    Friend WithEvents pnlHistoryPurchaseRemarks As System.Windows.Forms.Panel
    Friend WithEvents lblHistoryPurchaseRemarks As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txbHistoryRebateAMT As System.Windows.Forms.TextBox
    Friend WithEvents txbHistoryRebateRate As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents txbHistorySalesAMT As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents lblHistoryRebateAMT As System.Windows.Forms.Label
    Friend WithEvents lblHistoryPurchaseRebate As System.Windows.Forms.Label
    Friend WithEvents lblHistoryRebateRate As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents lblHistorySalesAMT As System.Windows.Forms.Label
    Friend WithEvents txbHistoryPaidRebateAMT As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents lblHistoryPaidRebateAMT As System.Windows.Forms.Label
    Friend WithEvents pnlAvailableRebateSalesAMT As System.Windows.Forms.Panel
    Friend WithEvents txbAvailableRebateSalesAMT As System.Windows.Forms.TextBox
    Friend WithEvents lblAvailableRebateAMT As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents flpNormalRebate As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlMaxNormalRebateCalculation As System.Windows.Forms.Panel
    Friend WithEvents txbMaxNormalRebateAMT As System.Windows.Forms.TextBox
    Friend WithEvents txbMaxNormalRebateRate As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents pnlNormalRebate As System.Windows.Forms.Panel
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents pnlDistributionNormalRebateAMT As System.Windows.Forms.Panel
    Friend WithEvents txbDistributionNormalRebateAMT As System.Windows.Forms.TextBox
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents pnlRebatSalesAMT As System.Windows.Forms.Panel
    Friend WithEvents txbRebateSalesAMT As System.Windows.Forms.TextBox
    Friend WithEvents lblRebateSalesAMT As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents pnlBalanceRebateAMT As System.Windows.Forms.Panel
    Friend WithEvents txbBalanceRebateAMT As System.Windows.Forms.TextBox
    Friend WithEvents lblBalanceRebateAMT As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents pnlNormalRebateState As System.Windows.Forms.Panel
    Friend WithEvents lblNormalRebateState As System.Windows.Forms.Label
    Friend WithEvents pnlNormalRebateRemarks As System.Windows.Forms.Panel
    Friend WithEvents pnlBalanceNormalRebateAMT As System.Windows.Forms.Panel
    Friend WithEvents txbBalanceNormalRebateAMT As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents grbSalesBillSummary As System.Windows.Forms.GroupBox
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents txbActiveAMT As System.Windows.Forms.TextBox
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents txbChargedAMT As System.Windows.Forms.TextBox
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents txbCardQTY As System.Windows.Forms.TextBox
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents flpSalesBillSummary As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents pnlActivationSummary As System.Windows.Forms.Panel
    Friend WithEvents txbInactiveAMT As System.Windows.Forms.TextBox
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Panel17 As System.Windows.Forms.Panel
    Friend WithEvents txbPaymentAMT As System.Windows.Forms.TextBox
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlDeductionAMT As System.Windows.Forms.Panel
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblDeductionAMT As System.Windows.Forms.Label
    Friend WithEvents pnlModifyNormalRebate As System.Windows.Forms.Panel
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents btnModifyNormalRebate As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnModifyPaymentInfo As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlImportedFile As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents lblSourceFile As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents lblViewImportedResult As System.Windows.Forms.Label
    Friend WithEvents Panel18 As System.Windows.Forms.Panel
    Friend WithEvents btnConfigInvoice As System.Windows.Forms.Button
    Friend WithEvents Panel23 As System.Windows.Forms.Panel
    Friend WithEvents btnConfigTicket As System.Windows.Forms.Button
    Friend WithEvents cmenuDeleteNormalCard As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents menuDeleteNormalCard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmenuDeleteRebateCard As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents menuDeleteRebateCard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmenuDeletePayment As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents menuDeletePayment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlReturnPayment As System.Windows.Forms.Panel
    Friend WithEvents lblRefundTitle As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txbRefundNo As System.Windows.Forms.TextBox
    Friend WithEvents dtpRefundDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents txbRefundDate As System.Windows.Forms.TextBox
    Friend WithEvents pnlAddjustSalesman As System.Windows.Forms.Panel
    Friend WithEvents btnAddjustSalesman As System.Windows.Forms.Button
    Friend WithEvents pcbSelectablPayment As System.Windows.Forms.PictureBox
    Friend WithEvents pnlSelectablePayment As System.Windows.Forms.Panel
    Friend WithEvents dgvSelectablePayment As System.Windows.Forms.DataGridView
    Friend WithEvents grbBalanceContract As System.Windows.Forms.GroupBox
    Friend WithEvents lblBalanceContract As System.Windows.Forms.Label
    Friend WithEvents chbBalanceContract As System.Windows.Forms.CheckBox
    Friend WithEvents txbBalanceContractCode As System.Windows.Forms.TextBox
    Friend WithEvents btnViewBalanceContract As System.Windows.Forms.Button
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents txbBalanceContractBalanceRebateAMT As System.Windows.Forms.TextBox
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents pnlPreviousDistribution As System.Windows.Forms.Panel
    Friend WithEvents txbPreviousDistribution As System.Windows.Forms.TextBox
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents pnlPreviousBalance As System.Windows.Forms.Panel
    Friend WithEvents txbPreviousBalance As System.Windows.Forms.TextBox
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents lblContract As System.Windows.Forms.Label
    Friend WithEvents chbContract As System.Windows.Forms.CheckBox
    Friend WithEvents flpBalanceContract As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlBalanceContractPayment As System.Windows.Forms.Panel
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents cmenuCardCost As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents grbPrintDiscount As System.Windows.Forms.GroupBox
    Friend WithEvents lblPrintDiscount As System.Windows.Forms.Label
    Friend WithEvents chbPrintDiscount As System.Windows.Forms.CheckBox
    Friend WithEvents pnlCardCost As System.Windows.Forms.Panel
    Friend WithEvents txbCardCost As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents pnlFunction As System.Windows.Forms.Panel
    Friend WithEvents Panel42 As System.Windows.Forms.Panel
    Friend WithEvents btnConfigApplicationForm As System.Windows.Forms.Button
    Friend WithEvents btnPrintApplicationForm As System.Windows.Forms.Button
    Friend WithEvents pnlSelectStore As System.Windows.Forms.Panel
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents cbbSelectStore As System.Windows.Forms.ComboBox
    Friend WithEvents grbPromotionInfo As System.Windows.Forms.GroupBox
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents txbPromotionTitle As System.Windows.Forms.TextBox
    Friend WithEvents dtpPromotionStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpPromotionEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents pnlPromotionEndDate As System.Windows.Forms.Panel
    Friend WithEvents pnlPromotionStartDate As System.Windows.Forms.Panel
    Friend WithEvents pnlPromotionPeriod As System.Windows.Forms.Panel
    Friend WithEvents pnlPromotionPeriodReadOnly As System.Windows.Forms.Panel
    Friend WithEvents txbPromotionStartDate As System.Windows.Forms.TextBox
    Friend WithEvents txbPromotionEndDate As System.Windows.Forms.TextBox
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents grbAvailablePayer As System.Windows.Forms.GroupBox
    Friend WithEvents Label78 As System.Windows.Forms.Label
    Friend WithEvents cbbAvailablePayer As System.Windows.Forms.ComboBox
    Friend WithEvents flpEmployee As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents grbInputEmployeeNo As System.Windows.Forms.GroupBox
    Friend WithEvents txbInputEmployeeNo As System.Windows.Forms.TextBox
    Friend WithEvents btnEmployeeNo As System.Windows.Forms.Button
    Friend WithEvents grbEmployeeInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txbEmployeeName As System.Windows.Forms.TextBox
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents txbEmployeeIDType As System.Windows.Forms.TextBox
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents txbEmployeeIDNo As System.Windows.Forms.TextBox
    Friend WithEvents lblEmployeeIDNo As System.Windows.Forms.Label
    Friend WithEvents flpEmployeeInfo As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlEmployeeNo As System.Windows.Forms.Panel
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txbEmployeeNo As System.Windows.Forms.TextBox
    Friend WithEvents pnlEmployeeInfo As System.Windows.Forms.Panel
    Friend WithEvents txbOfficeName As System.Windows.Forms.TextBox
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents txbLevelName As System.Windows.Forms.TextBox
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents pnlEmployeeTel As System.Windows.Forms.Panel
    Friend WithEvents Label83 As System.Windows.Forms.Label
    Friend WithEvents txbEmployeeTel As System.Windows.Forms.TextBox
    Friend WithEvents grbInputEmployeeTel As System.Windows.Forms.GroupBox
    Friend WithEvents txbInputEmployeeTel As System.Windows.Forms.TextBox
    Friend WithEvents cbbInputEmployeeTel As System.Windows.Forms.ComboBox
    Friend WithEvents grbEmployeeQuota As System.Windows.Forms.GroupBox
    Friend WithEvents flpEmployeeQuota As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlQuota As System.Windows.Forms.Panel
    Friend WithEvents Label84 As System.Windows.Forms.Label
    Friend WithEvents txbRateQuota As System.Windows.Forms.TextBox
    Friend WithEvents txbPurchaseQuota As System.Windows.Forms.TextBox
    Friend WithEvents Label88 As System.Windows.Forms.Label
    Friend WithEvents Label87 As System.Windows.Forms.Label
    Friend WithEvents Label86 As System.Windows.Forms.Label
    Friend WithEvents Label85 As System.Windows.Forms.Label
    Friend WithEvents pnlUsedQuota As System.Windows.Forms.Panel
    Friend WithEvents txbUsedRebateQuota As System.Windows.Forms.TextBox
    Friend WithEvents txbUsedPurchaseQuota As System.Windows.Forms.TextBox
    Friend WithEvents Label95 As System.Windows.Forms.Label
    Friend WithEvents txbRebateQuota As System.Windows.Forms.TextBox
    Friend WithEvents Label94 As System.Windows.Forms.Label
    Friend WithEvents Label93 As System.Windows.Forms.Label
    Friend WithEvents Label92 As System.Windows.Forms.Label
    Friend WithEvents Label90 As System.Windows.Forms.Label
    Friend WithEvents Label89 As System.Windows.Forms.Label
    Friend WithEvents Label91 As System.Windows.Forms.Label
    Friend WithEvents pnlMaxAvailableQuota As System.Windows.Forms.Panel
    Friend WithEvents txbMaxAvailableRebateQuota As System.Windows.Forms.TextBox
    Friend WithEvents txbMaxAvailablePurchaseQuota As System.Windows.Forms.TextBox
    Friend WithEvents Label100 As System.Windows.Forms.Label
    Friend WithEvents Label99 As System.Windows.Forms.Label
    Friend WithEvents Label98 As System.Windows.Forms.Label
    Friend WithEvents Label97 As System.Windows.Forms.Label
    Friend WithEvents Label96 As System.Windows.Forms.Label
    Friend WithEvents pnlDistributedQuota As System.Windows.Forms.Panel
    Friend WithEvents txbDistributedRebateQuota As System.Windows.Forms.TextBox
    Friend WithEvents txbDistributedPurchaseQuota As System.Windows.Forms.TextBox
    Friend WithEvents Label105 As System.Windows.Forms.Label
    Friend WithEvents Label104 As System.Windows.Forms.Label
    Friend WithEvents Label103 As System.Windows.Forms.Label
    Friend WithEvents Label102 As System.Windows.Forms.Label
    Friend WithEvents Label101 As System.Windows.Forms.Label
    Friend WithEvents txbBalanceRebateQuota As System.Windows.Forms.TextBox
    Friend WithEvents txbBalancePurchaseQuota As System.Windows.Forms.TextBox
    Friend WithEvents Label110 As System.Windows.Forms.Label
    Friend WithEvents Label114 As System.Windows.Forms.Label
    Friend WithEvents Label108 As System.Windows.Forms.Label
    Friend WithEvents Label113 As System.Windows.Forms.Label
    Friend WithEvents Label106 As System.Windows.Forms.Label
    Friend WithEvents tlpBalanceQuota As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlBalanceRebateQuota As System.Windows.Forms.Panel
    Friend WithEvents pnlBalancePurchaseQuota As System.Windows.Forms.Panel
    Friend WithEvents txbEmployeeState As System.Windows.Forms.TextBox
    Friend WithEvents Label111 As System.Windows.Forms.Label
    Friend WithEvents tlpAvailableQuota As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlAvailableRebateQuota As System.Windows.Forms.Panel
    Friend WithEvents txbAvailableRebateQuota As System.Windows.Forms.TextBox
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents Label112 As System.Windows.Forms.Label
    Friend WithEvents tlpDistributedQuota As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlDistributedBalanceRebateQuota As System.Windows.Forms.Panel
    Friend WithEvents txbDistributedBalanceRebateQuota As System.Windows.Forms.TextBox
    Friend WithEvents Label107 As System.Windows.Forms.Label
    Friend WithEvents Label109 As System.Windows.Forms.Label
    Friend WithEvents cbbCompanyCredentialsType As System.Windows.Forms.ComboBox
    Friend WithEvents Label115 As System.Windows.Forms.Label
    Friend WithEvents txbCompanyCredentialsType As System.Windows.Forms.TextBox
    Friend WithEvents txbCompanyCredentialsNo As System.Windows.Forms.TextBox
    Friend WithEvents Label116 As System.Windows.Forms.Label
    Friend WithEvents pnlBuyerCredentials As System.Windows.Forms.Panel
    Friend WithEvents txbBuyerCredentialsNo As System.Windows.Forms.TextBox
    Friend WithEvents Label117 As System.Windows.Forms.Label
    Friend WithEvents Label118 As System.Windows.Forms.Label
    Friend WithEvents cbbBuyerCredentialsType As System.Windows.Forms.ComboBox
    Friend WithEvents txbBuyerCredentialsType As System.Windows.Forms.TextBox
    Friend WithEvents grbBuyerInfo As System.Windows.Forms.GroupBox
    Friend WithEvents grbMemberInfo As System.Windows.Forms.GroupBox
    Friend WithEvents Label120 As System.Windows.Forms.Label
    Friend WithEvents txbMemberAddress As System.Windows.Forms.TextBox
    Friend WithEvents txbMemberTel As System.Windows.Forms.TextBox
    Friend WithEvents txbMemberIDNo As System.Windows.Forms.TextBox
    Friend WithEvents Label121 As System.Windows.Forms.Label
    Friend WithEvents txbMemberName As System.Windows.Forms.TextBox
    Friend WithEvents Label123 As System.Windows.Forms.Label
    Friend WithEvents Label122 As System.Windows.Forms.Label
    Friend WithEvents txbNewMemberCardNo As System.Windows.Forms.TextBox
    Friend WithEvents Label124 As System.Windows.Forms.Label
    Friend WithEvents txbOldMemberCardNo As System.Windows.Forms.TextBox
    Friend WithEvents Label125 As System.Windows.Forms.Label
    Friend WithEvents lblTotalPayAmtUnit As System.Windows.Forms.Label
    Friend WithEvents lblTotalPayAmt As System.Windows.Forms.Label
    Friend WithEvents lblTotalPayAmtTitle As System.Windows.Forms.Label

    'modify code 075:start-------------------------------------------------------------------------
    Friend WithEvents btnCheckCUL As System.Windows.Forms.Button
    'modify code 075:end-------------------------------------------------------------------------

End Class
