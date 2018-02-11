<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCrossContract
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        'components = New System.ComponentModel.Container
        'Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        'Me.Text = "frmCrossContract"

        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmContract))
        Me.flpContainer = New System.Windows.Forms.FlowLayoutPanel
        Me.grbPartyA = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txbSignPlace = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txbDomiciliation = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txbBankAccount = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txbBeneficiary = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txbACompanyEnglishName = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txbACompanyChineseName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbbSignPlace = New System.Windows.Forms.ComboBox
        Me.cbbACompanyChineseName = New System.Windows.Forms.ComboBox
        Me.grbPartyB = New System.Windows.Forms.GroupBox
        Me.flpCustomer = New System.Windows.Forms.FlowLayoutPanel
        Me.pnlInputCustomer = New System.Windows.Forms.Panel
        Me.Label14 = New System.Windows.Forms.Label
        Me.btnJoin = New System.Windows.Forms.Button
        Me.btnNewCustomer = New System.Windows.Forms.Button
        Me.btnViewCustomer = New System.Windows.Forms.Button
        Me.txbCustomerName = New System.Windows.Forms.TextBox
        Me.cbbCustomerName = New System.Windows.Forms.ComboBox
        Me.pnlCustomer = New System.Windows.Forms.Panel
        Me.tlpSetMainCompany = New System.Windows.Forms.TableLayoutPanel
        Me.btnSetMainCompany = New System.Windows.Forms.Button
        Me.dgvCustomer = New System.Windows.Forms.DataGridView
        Me.Label15 = New System.Windows.Forms.Label
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Label17 = New System.Windows.Forms.Label
        Me.txbBNoticeWays = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.grbContractPeriod = New System.Windows.Forms.GroupBox
        Me.pnlStoppedPeriod = New System.Windows.Forms.Panel
        Me.Label48 = New System.Windows.Forms.Label
        Me.Label50 = New System.Windows.Forms.Label
        Me.Label52 = New System.Windows.Forms.Label
        Me.Label47 = New System.Windows.Forms.Label
        Me.txbStoppedDate = New System.Windows.Forms.TextBox
        Me.Label49 = New System.Windows.Forms.Label
        Me.txbEndDateStopped = New System.Windows.Forms.TextBox
        Me.txbStartDateStopped = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker
        Me.txbStartDate = New System.Windows.Forms.TextBox
        Me.txbEndDate = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.grbFaceValue = New System.Windows.Forms.GroupBox
        Me.txbMaxFaceValue = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.txbMinFaceValue = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.grbContractAMT = New System.Windows.Forms.GroupBox
        Me.txbMaxContractAMT = New System.Windows.Forms.TextBox
        Me.txbMinContractAMT = New System.Windows.Forms.TextBox
        Me.txbTotalContractAMT = New System.Windows.Forms.TextBox
        Me.txbMinAMTPerPurchase = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label62 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.grbDiscountMode = New System.Windows.Forms.GroupBox
        Me.rdbDeduction = New System.Windows.Forms.RadioButton
        Me.rdbAddition = New System.Windows.Forms.RadioButton
        Me.grbCalculationMode = New System.Windows.Forms.GroupBox
        Me.rdbCalculationBySection = New System.Windows.Forms.RadioButton
        Me.rdbCalculationByTotal = New System.Windows.Forms.RadioButton
        Me.grbCalculationDate = New System.Windows.Forms.GroupBox
        Me.nudCalculationDay = New System.Windows.Forms.NumericUpDown
        Me.dtpAppointedDate = New System.Windows.Forms.DateTimePicker
        Me.rdbEachPurchase = New System.Windows.Forms.RadioButton
        Me.txbAppointedDate = New System.Windows.Forms.TextBox
        Me.rdbEndOfContract = New System.Windows.Forms.RadioButton
        Me.txbCalculationDay = New System.Windows.Forms.TextBox
        Me.rdbMonthly = New System.Windows.Forms.RadioButton
        Me.grbDetails = New System.Windows.Forms.GroupBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.btnCompare = New System.Windows.Forms.Button
        Me.lblAvailable = New System.Windows.Forms.Label
        Me.dgvDetails = New System.Windows.Forms.DataGridView
        Me.grbScope = New System.Windows.Forms.GroupBox
        Me.cbbAppointedStore = New System.Windows.Forms.ComboBox
        Me.rdbAppointedStore = New System.Windows.Forms.RadioButton
        Me.rdbAllStores = New System.Windows.Forms.RadioButton
        Me.txbAppointedStore = New System.Windows.Forms.TextBox
        Me.grbInvoice = New System.Windows.Forms.GroupBox
        Me.tlpInvoice = New System.Windows.Forms.TableLayoutPanel
        Me.cklInvoiceTitle = New System.Windows.Forms.CheckedListBox
        Me.cbbInvoiceItem = New System.Windows.Forms.ComboBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.grbOperation = New System.Windows.Forms.GroupBox
        Me.tlpOperation = New System.Windows.Forms.TableLayoutPanel
        Me.pnlStopInfo = New System.Windows.Forms.Panel
        Me.Label55 = New System.Windows.Forms.Label
        Me.lblStoppedTime = New System.Windows.Forms.Label
        Me.lblStopper = New System.Windows.Forms.Label
        Me.Label53 = New System.Windows.Forms.Label
        Me.pnlValidateInfo = New System.Windows.Forms.Panel
        Me.Label42 = New System.Windows.Forms.Label
        Me.lblValidatedTime = New System.Windows.Forms.Label
        Me.Label43 = New System.Windows.Forms.Label
        Me.lblAuditor = New System.Windows.Forms.Label
        Me.pnlValidateTitle = New System.Windows.Forms.Panel
        Me.Label57 = New System.Windows.Forms.Label
        Me.pnlFirstValidateInfo = New System.Windows.Forms.Panel
        Me.Label54 = New System.Windows.Forms.Label
        Me.Label51 = New System.Windows.Forms.Label
        Me.lblFirstValidatedTime = New System.Windows.Forms.Label
        Me.Label56 = New System.Windows.Forms.Label
        Me.lblFirstAuditor = New System.Windows.Forms.Label
        Me.pnlModifyInfo = New System.Windows.Forms.Panel
        Me.Label40 = New System.Windows.Forms.Label
        Me.Label41 = New System.Windows.Forms.Label
        Me.lblModifiedTime = New System.Windows.Forms.Label
        Me.lblModifier = New System.Windows.Forms.Label
        Me.pnlCreateInfo = New System.Windows.Forms.Panel
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.lblCreator = New System.Windows.Forms.Label
        Me.lblCreatedTime = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.theTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.txbCustomerCode = New System.Windows.Forms.TextBox
        Me.txbContractCode = New System.Windows.Forms.TextBox
        Me.btnSelectPrinter = New System.Windows.Forms.Button
        Me.theTimer = New System.Windows.Forms.Timer(Me.components)
        Me.cmenuDeleteRebateRow = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.menuDeleteRebateRow = New System.Windows.Forms.ToolStripMenuItem
        Me.pnlValidate = New System.Windows.Forms.Panel
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rdbOK = New System.Windows.Forms.RadioButton
        Me.txbFailureReason = New System.Windows.Forms.TextBox
        Me.rdbFailure = New System.Windows.Forms.RadioButton
        Me.Label61 = New System.Windows.Forms.Label
        Me.txbContratState = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnPrint = New System.Windows.Forms.Button
        Me.pnlContractState = New System.Windows.Forms.Panel
        Me.pnlReason = New System.Windows.Forms.Panel
        Me.Label44 = New System.Windows.Forms.Label
        Me.txbReason = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.tlpContainer = New System.Windows.Forms.TableLayoutPanel
        Me.pnlHOValidate = New System.Windows.Forms.Panel
        Me.pnlHOValidation = New System.Windows.Forms.Panel
        Me.txbHOFailureReason = New System.Windows.Forms.TextBox
        Me.rdbHOOK = New System.Windows.Forms.RadioButton
        Me.rdbHOFailure = New System.Windows.Forms.RadioButton
        Me.lblHOEnglishRemarks = New System.Windows.Forms.Label
        Me.lblHOChineseRemarks = New System.Windows.Forms.Label
        Me.Label65 = New System.Windows.Forms.Label
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.Label66 = New System.Windows.Forms.Label
        Me.pnlStop = New System.Windows.Forms.Panel
        Me.chbStop = New System.Windows.Forms.CheckBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txbStoppedReason = New System.Windows.Forms.TextBox
        Me.Label45 = New System.Windows.Forms.Label
        Me.pnlFirstValidate = New System.Windows.Forms.Panel
        Me.Label60 = New System.Windows.Forms.Label
        Me.Label59 = New System.Windows.Forms.Label
        Me.Label58 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.rdbFirstOK = New System.Windows.Forms.RadioButton
        Me.txbFirstFailureReason = New System.Windows.Forms.TextBox
        Me.rdbFirstFailure = New System.Windows.Forms.RadioButton
        Me.Label46 = New System.Windows.Forms.Label
        Me.cklInvoiceItem = New System.Windows.Forms.CheckedListBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.flpContainer.SuspendLayout()
        Me.grbPartyA.SuspendLayout()
        Me.grbPartyB.SuspendLayout()
        Me.flpCustomer.SuspendLayout()
        Me.pnlInputCustomer.SuspendLayout()
        Me.pnlCustomer.SuspendLayout()
        Me.tlpSetMainCompany.SuspendLayout()
        CType(Me.dgvCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.grbContractPeriod.SuspendLayout()
        Me.pnlStoppedPeriod.SuspendLayout()
        Me.grbFaceValue.SuspendLayout()
        Me.grbContractAMT.SuspendLayout()
        Me.grbDiscountMode.SuspendLayout()
        Me.grbCalculationMode.SuspendLayout()
        Me.grbCalculationDate.SuspendLayout()
        CType(Me.nudCalculationDay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbDetails.SuspendLayout()
        CType(Me.dgvDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbScope.SuspendLayout()
        Me.grbInvoice.SuspendLayout()
        Me.tlpInvoice.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.grbOperation.SuspendLayout()
        Me.tlpOperation.SuspendLayout()
        Me.pnlStopInfo.SuspendLayout()
        Me.pnlValidateInfo.SuspendLayout()
        Me.pnlValidateTitle.SuspendLayout()
        Me.pnlFirstValidateInfo.SuspendLayout()
        Me.pnlModifyInfo.SuspendLayout()
        Me.pnlCreateInfo.SuspendLayout()
        Me.cmenuDeleteRebateRow.SuspendLayout()
        Me.pnlValidate.SuspendLayout()
        Me.pnlContractState.SuspendLayout()
        Me.pnlReason.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.tlpContainer.SuspendLayout()
        Me.pnlHOValidate.SuspendLayout()
        Me.pnlHOValidation.SuspendLayout()
        Me.pnlStop.SuspendLayout()
        Me.pnlFirstValidate.SuspendLayout()
        Me.SuspendLayout()
        '
        'flpContainer
        '
        Me.flpContainer.AutoScroll = True
        Me.flpContainer.Controls.Add(Me.grbPartyA)
        Me.flpContainer.Controls.Add(Me.grbPartyB)
        Me.flpContainer.Controls.Add(Me.grbContractPeriod)
        Me.flpContainer.Controls.Add(Me.grbFaceValue)
        Me.flpContainer.Controls.Add(Me.grbContractAMT)
        Me.flpContainer.Controls.Add(Me.grbDiscountMode)
        Me.flpContainer.Controls.Add(Me.grbCalculationMode)
        Me.flpContainer.Controls.Add(Me.grbCalculationDate)
        Me.flpContainer.Controls.Add(Me.grbDetails)
        Me.flpContainer.Controls.Add(Me.grbScope)
        Me.flpContainer.Controls.Add(Me.grbInvoice)
        Me.flpContainer.Controls.Add(Me.grbOperation)
        Me.flpContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpContainer.Location = New System.Drawing.Point(0, 256)
        Me.flpContainer.Margin = New System.Windows.Forms.Padding(0)
        Me.flpContainer.Name = "flpContainer"
        Me.flpContainer.Size = New System.Drawing.Size(794, 258)
        Me.flpContainer.TabIndex = 5
        Me.flpContainer.WrapContents = False
        '
        'grbPartyA
        '
        Me.grbPartyA.Controls.Add(Me.Label13)
        Me.grbPartyA.Controls.Add(Me.Label12)
        Me.grbPartyA.Controls.Add(Me.txbSignPlace)
        Me.grbPartyA.Controls.Add(Me.Label11)
        Me.grbPartyA.Controls.Add(Me.Label9)
        Me.grbPartyA.Controls.Add(Me.Label7)
        Me.grbPartyA.Controls.Add(Me.Label6)
        Me.grbPartyA.Controls.Add(Me.txbDomiciliation)
        Me.grbPartyA.Controls.Add(Me.Label10)
        Me.grbPartyA.Controls.Add(Me.txbBankAccount)
        Me.grbPartyA.Controls.Add(Me.Label8)
        Me.grbPartyA.Controls.Add(Me.txbBeneficiary)
        Me.grbPartyA.Controls.Add(Me.Label4)
        Me.grbPartyA.Controls.Add(Me.txbACompanyEnglishName)
        Me.grbPartyA.Controls.Add(Me.Label5)
        Me.grbPartyA.Controls.Add(Me.txbACompanyChineseName)
        Me.grbPartyA.Controls.Add(Me.Label3)
        Me.grbPartyA.Controls.Add(Me.cbbSignPlace)
        Me.grbPartyA.Controls.Add(Me.cbbACompanyChineseName)
        Me.grbPartyA.Location = New System.Drawing.Point(12, 8)
        Me.grbPartyA.Margin = New System.Windows.Forms.Padding(12, 8, 8, 8)
        Me.grbPartyA.Name = "grbPartyA"
        Me.grbPartyA.Size = New System.Drawing.Size(752, 193)
        Me.grbPartyA.TabIndex = 0
        Me.grbPartyA.TabStop = False
        Me.grbPartyA.Text = "甲方（供卡方）信息 Party A (Vendor) Information: "
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Orange
        Me.Label13.Location = New System.Drawing.Point(507, 163)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(12, 12)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "*"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(28, 161)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(191, 12)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "合同签署地 Contract Sign Place:"
        '
        'txbSignPlace
        '
        Me.txbSignPlace.Location = New System.Drawing.Point(226, 158)
        Me.txbSignPlace.MaxLength = 100
        Me.txbSignPlace.Name = "txbSignPlace"
        Me.txbSignPlace.Size = New System.Drawing.Size(275, 21)
        Me.txbSignPlace.TabIndex = 16
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Orange
        Me.Label11.Location = New System.Drawing.Point(611, 135)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(12, 12)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "*"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Orange
        Me.Label9.Location = New System.Drawing.Point(611, 108)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(12, 12)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "*"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Orange
        Me.Label7.Location = New System.Drawing.Point(611, 81)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(12, 12)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "*"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(64, 80)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(155, 12)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "公司账户名称 Beneficiary:"
        '
        'txbDomiciliation
        '
        Me.txbDomiciliation.BackColor = System.Drawing.SystemColors.Window
        Me.txbDomiciliation.Location = New System.Drawing.Point(226, 131)
        Me.txbDomiciliation.MaxLength = 50
        Me.txbDomiciliation.Name = "txbDomiciliation"
        Me.txbDomiciliation.Size = New System.Drawing.Size(379, 21)
        Me.txbDomiciliation.TabIndex = 13
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(64, 134)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(155, 12)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "账号开户行 Domiciliation:"
        '
        'txbBankAccount
        '
        Me.txbBankAccount.BackColor = System.Drawing.SystemColors.Window
        Me.txbBankAccount.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbBankAccount.Location = New System.Drawing.Point(226, 104)
        Me.txbBankAccount.MaxLength = 50
        Me.txbBankAccount.Name = "txbBankAccount"
        Me.txbBankAccount.Size = New System.Drawing.Size(379, 21)
        Me.txbBankAccount.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(82, 107)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(137, 12)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "公司账号 Bank Account:"
        '
        'txbBeneficiary
        '
        Me.txbBeneficiary.BackColor = System.Drawing.SystemColors.Window
        Me.txbBeneficiary.Location = New System.Drawing.Point(226, 77)
        Me.txbBeneficiary.MaxLength = 50
        Me.txbBeneficiary.Name = "txbBeneficiary"
        Me.txbBeneficiary.Size = New System.Drawing.Size(379, 21)
        Me.txbBeneficiary.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Orange
        Me.Label4.Location = New System.Drawing.Point(732, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 12)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "*"
        '
        'txbACompanyEnglishName
        '
        Me.txbACompanyEnglishName.BackColor = System.Drawing.SystemColors.Window
        Me.txbACompanyEnglishName.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbACompanyEnglishName.Location = New System.Drawing.Point(226, 50)
        Me.txbACompanyEnglishName.MaxLength = 100
        Me.txbACompanyEnglishName.Name = "txbACompanyEnglishName"
        Me.txbACompanyEnglishName.Size = New System.Drawing.Size(500, 21)
        Me.txbACompanyEnglishName.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(209, 12)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "公司英文名称 Company English Name:"
        '
        'txbACompanyChineseName
        '
        Me.txbACompanyChineseName.BackColor = System.Drawing.SystemColors.Window
        Me.txbACompanyChineseName.Location = New System.Drawing.Point(226, 24)
        Me.txbACompanyChineseName.MaxLength = 50
        Me.txbACompanyChineseName.Name = "txbACompanyChineseName"
        Me.txbACompanyChineseName.Size = New System.Drawing.Size(500, 21)
        Me.txbACompanyChineseName.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(209, 12)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "公司中文名称 Company Chinese Name:"
        '
        'cbbSignPlace
        '
        Me.cbbSignPlace.FormattingEnabled = True
        Me.cbbSignPlace.Location = New System.Drawing.Point(226, 158)
        Me.cbbSignPlace.Name = "cbbSignPlace"
        Me.cbbSignPlace.Size = New System.Drawing.Size(275, 20)
        Me.cbbSignPlace.TabIndex = 17
        Me.cbbSignPlace.Visible = False
        '
        'cbbACompanyChineseName
        '
        Me.cbbACompanyChineseName.Location = New System.Drawing.Point(226, 24)
        Me.cbbACompanyChineseName.MaxLength = 50
        Me.cbbACompanyChineseName.Name = "cbbACompanyChineseName"
        Me.cbbACompanyChineseName.Size = New System.Drawing.Size(500, 20)
        Me.cbbACompanyChineseName.TabIndex = 2
        Me.cbbACompanyChineseName.Visible = False
        '
        'grbPartyB
        '
        Me.grbPartyB.Controls.Add(Me.flpCustomer)
        Me.grbPartyB.Location = New System.Drawing.Point(12, 209)
        Me.grbPartyB.Margin = New System.Windows.Forms.Padding(12, 0, 8, 8)
        Me.grbPartyB.Name = "grbPartyB"
        Me.grbPartyB.Size = New System.Drawing.Size(752, 156)
        Me.grbPartyB.TabIndex = 1
        Me.grbPartyB.TabStop = False
        Me.grbPartyB.Text = "乙方（购卡方）信息 Party B (Purchaser) Information: "
        '
        'flpCustomer
        '
        Me.flpCustomer.AutoSize = True
        Me.flpCustomer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpCustomer.Controls.Add(Me.pnlInputCustomer)
        Me.flpCustomer.Controls.Add(Me.pnlCustomer)
        Me.flpCustomer.Controls.Add(Me.Panel4)
        Me.flpCustomer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpCustomer.Location = New System.Drawing.Point(2, 18)
        Me.flpCustomer.Margin = New System.Windows.Forms.Padding(0)
        Me.flpCustomer.Name = "flpCustomer"
        Me.flpCustomer.Size = New System.Drawing.Size(748, 130)
        Me.flpCustomer.TabIndex = 0
        '
        'pnlInputCustomer
        '
        Me.pnlInputCustomer.Controls.Add(Me.Label14)
        Me.pnlInputCustomer.Controls.Add(Me.btnJoin)
        Me.pnlInputCustomer.Controls.Add(Me.btnNewCustomer)
        Me.pnlInputCustomer.Controls.Add(Me.btnViewCustomer)
        Me.pnlInputCustomer.Controls.Add(Me.txbCustomerName)
        Me.pnlInputCustomer.Controls.Add(Me.cbbCustomerName)
        Me.pnlInputCustomer.Location = New System.Drawing.Point(0, 0)
        Me.pnlInputCustomer.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlInputCustomer.Name = "pnlInputCustomer"
        Me.pnlInputCustomer.Size = New System.Drawing.Size(748, 27)
        Me.pnlInputCustomer.TabIndex = 0
        Me.pnlInputCustomer.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(10, 9)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(203, 12)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "输入客户名称 Input Customer &Name:"
        '
        'btnJoin
        '
        Me.btnJoin.Enabled = False
        Me.btnJoin.Location = New System.Drawing.Point(689, 5)
        Me.btnJoin.Name = "btnJoin"
        Me.btnJoin.Size = New System.Drawing.Size(37, 23)
        Me.btnJoin.TabIndex = 5
        Me.btnJoin.Text = "加入"
        Me.theTip.SetToolTip(Me.btnJoin, "Add into Party B")
        Me.btnJoin.UseVisualStyleBackColor = True
        '
        'btnNewCustomer
        '
        Me.btnNewCustomer.Location = New System.Drawing.Point(609, 5)
        Me.btnNewCustomer.Name = "btnNewCustomer"
        Me.btnNewCustomer.Size = New System.Drawing.Size(37, 23)
        Me.btnNewCustomer.TabIndex = 3
        Me.btnNewCustomer.Text = "新建"
        Me.theTip.SetToolTip(Me.btnNewCustomer, "Create Customer")
        Me.btnNewCustomer.UseVisualStyleBackColor = True
        '
        'btnViewCustomer
        '
        Me.btnViewCustomer.Enabled = False
        Me.btnViewCustomer.Location = New System.Drawing.Point(649, 5)
        Me.btnViewCustomer.Name = "btnViewCustomer"
        Me.btnViewCustomer.Size = New System.Drawing.Size(37, 23)
        Me.btnViewCustomer.TabIndex = 4
        Me.btnViewCustomer.Text = "打开"
        Me.theTip.SetToolTip(Me.btnViewCustomer, "Open Customer")
        Me.btnViewCustomer.UseVisualStyleBackColor = True
        '
        'txbCustomerName
        '
        Me.txbCustomerName.Location = New System.Drawing.Point(224, 6)
        Me.txbCustomerName.MaxLength = 100
        Me.txbCustomerName.Name = "txbCustomerName"
        Me.txbCustomerName.Size = New System.Drawing.Size(379, 21)
        Me.txbCustomerName.TabIndex = 1
        '
        'cbbCustomerName
        '
        Me.cbbCustomerName.FormattingEnabled = True
        Me.cbbCustomerName.Location = New System.Drawing.Point(224, 6)
        Me.cbbCustomerName.MaxDropDownItems = 30
        Me.cbbCustomerName.MaxLength = 100
        Me.cbbCustomerName.Name = "cbbCustomerName"
        Me.cbbCustomerName.Size = New System.Drawing.Size(379, 20)
        Me.cbbCustomerName.TabIndex = 2
        Me.cbbCustomerName.Visible = False
        '
        'pnlCustomer
        '
        Me.pnlCustomer.Controls.Add(Me.tlpSetMainCompany)
        Me.pnlCustomer.Controls.Add(Me.dgvCustomer)
        Me.pnlCustomer.Controls.Add(Me.Label15)
        Me.pnlCustomer.Location = New System.Drawing.Point(0, 27)
        Me.pnlCustomer.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlCustomer.Name = "pnlCustomer"
        Me.pnlCustomer.Size = New System.Drawing.Size(748, 68)
        Me.pnlCustomer.TabIndex = 1
        '
        'tlpSetMainCompany
        '
        Me.tlpSetMainCompany.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tlpSetMainCompany.ColumnCount = 1
        Me.tlpSetMainCompany.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpSetMainCompany.Controls.Add(Me.btnSetMainCompany, 0, 1)
        Me.tlpSetMainCompany.Location = New System.Drawing.Point(10, 23)
        Me.tlpSetMainCompany.Name = "tlpSetMainCompany"
        Me.tlpSetMainCompany.RowCount = 3
        Me.tlpSetMainCompany.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpSetMainCompany.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpSetMainCompany.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpSetMainCompany.Size = New System.Drawing.Size(200, 45)
        Me.tlpSetMainCompany.TabIndex = 2
        Me.tlpSetMainCompany.Visible = False
        '
        'btnSetMainCompany
        '
        Me.btnSetMainCompany.Location = New System.Drawing.Point(0, 11)
        Me.btnSetMainCompany.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSetMainCompany.Name = "btnSetMainCompany"
        Me.btnSetMainCompany.Size = New System.Drawing.Size(200, 23)
        Me.btnSetMainCompany.TabIndex = 0
        Me.btnSetMainCompany.Text = "设为主公司 Set As Main Company"
        Me.btnSetMainCompany.UseVisualStyleBackColor = True
        '
        'dgvCustomer
        '
        Me.dgvCustomer.AllowUserToAddRows = False
        Me.dgvCustomer.AllowUserToDeleteRows = False
        Me.dgvCustomer.AllowUserToResizeRows = False
        Me.dgvCustomer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCustomer.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvCustomer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCustomer.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCustomer.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCustomer.ColumnHeadersHeight = 22
        Me.dgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvCustomer.ColumnHeadersVisible = False
        Me.dgvCustomer.Location = New System.Drawing.Point(224, 6)
        Me.dgvCustomer.MultiSelect = False
        Me.dgvCustomer.Name = "dgvCustomer"
        Me.dgvCustomer.ReadOnly = True
        Me.dgvCustomer.RowHeadersVisible = False
        Me.dgvCustomer.RowTemplate.Height = 24
        Me.dgvCustomer.RowTemplate.ReadOnly = True
        Me.dgvCustomer.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgvCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCustomer.Size = New System.Drawing.Size(500, 62)
        Me.dgvCustomer.StandardTab = True
        Me.dgvCustomer.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(10, 8)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(209, 12)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "乙方公司列表 Party B Company List:"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label17)
        Me.Panel4.Controls.Add(Me.txbBNoticeWays)
        Me.Panel4.Controls.Add(Me.Label16)
        Me.Panel4.Location = New System.Drawing.Point(0, 95)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(748, 35)
        Me.Panel4.TabIndex = 2
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Orange
        Me.Label17.Location = New System.Drawing.Point(616, 9)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(12, 12)
        Me.Label17.TabIndex = 2
        Me.Label17.Text = "*"
        '
        'txbBNoticeWays
        '
        Me.txbBNoticeWays.Location = New System.Drawing.Point(224, 6)
        Me.txbBNoticeWays.MaxLength = 50
        Me.txbBNoticeWays.Name = "txbBNoticeWays"
        Me.txbBNoticeWays.Size = New System.Drawing.Size(386, 21)
        Me.txbBNoticeWays.TabIndex = 1
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(10, 10)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(209, 12)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "购卡通知方式 Purchase Notice Ways:"
        '
        'grbContractPeriod
        '
        Me.grbContractPeriod.Controls.Add(Me.pnlStoppedPeriod)
        Me.grbContractPeriod.Controls.Add(Me.Label19)
        Me.grbContractPeriod.Controls.Add(Me.dtpEndDate)
        Me.grbContractPeriod.Controls.Add(Me.dtpStartDate)
        Me.grbContractPeriod.Controls.Add(Me.txbStartDate)
        Me.grbContractPeriod.Controls.Add(Me.txbEndDate)
        Me.grbContractPeriod.Controls.Add(Me.Label21)
        Me.grbContractPeriod.Controls.Add(Me.Label18)
        Me.grbContractPeriod.Controls.Add(Me.Label20)
        Me.grbContractPeriod.Location = New System.Drawing.Point(12, 373)
        Me.grbContractPeriod.Margin = New System.Windows.Forms.Padding(12, 0, 8, 8)
        Me.grbContractPeriod.Name = "grbContractPeriod"
        Me.grbContractPeriod.Size = New System.Drawing.Size(752, 60)
        Me.grbContractPeriod.TabIndex = 2
        Me.grbContractPeriod.TabStop = False
        Me.grbContractPeriod.Text = "合同有效期设置 Contract Period Configuration: "
        '
        'pnlStoppedPeriod
        '
        Me.pnlStoppedPeriod.Controls.Add(Me.Label48)
        Me.pnlStoppedPeriod.Controls.Add(Me.Label50)
        Me.pnlStoppedPeriod.Controls.Add(Me.Label52)
        Me.pnlStoppedPeriod.Controls.Add(Me.Label47)
        Me.pnlStoppedPeriod.Controls.Add(Me.txbStoppedDate)
        Me.pnlStoppedPeriod.Controls.Add(Me.Label49)
        Me.pnlStoppedPeriod.Controls.Add(Me.txbEndDateStopped)
        Me.pnlStoppedPeriod.Controls.Add(Me.txbStartDateStopped)
        Me.pnlStoppedPeriod.Location = New System.Drawing.Point(6, 20)
        Me.pnlStoppedPeriod.Name = "pnlStoppedPeriod"
        Me.pnlStoppedPeriod.Size = New System.Drawing.Size(735, 28)
        Me.pnlStoppedPeriod.TabIndex = 8
        Me.pnlStoppedPeriod.Visible = False
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(4, 8)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(125, 12)
        Me.Label48.TabIndex = 0
        Me.Label48.Text = "开始日期 Sta&rt Date:"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label50.ForeColor = System.Drawing.Color.Orange
        Me.Label50.Location = New System.Drawing.Point(225, 8)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(12, 12)
        Me.Label50.TabIndex = 2
        Me.Label50.Text = "*"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(492, 8)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(137, 12)
        Me.Label52.TabIndex = 6
        Me.Label52.Text = "停用日期 Stopped Date:"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(253, 8)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(113, 12)
        Me.Label47.TabIndex = 3
        Me.Label47.Text = "结束日期 &End Date:"
        '
        'txbStoppedDate
        '
        Me.txbStoppedDate.Location = New System.Drawing.Point(635, 4)
        Me.txbStoppedDate.Name = "txbStoppedDate"
        Me.txbStoppedDate.ReadOnly = True
        Me.txbStoppedDate.Size = New System.Drawing.Size(85, 21)
        Me.txbStoppedDate.TabIndex = 7
        Me.txbStoppedDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label49.ForeColor = System.Drawing.Color.Orange
        Me.Label49.Location = New System.Drawing.Point(462, 7)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(12, 12)
        Me.Label49.TabIndex = 5
        Me.Label49.Text = "*"
        '
        'txbEndDateStopped
        '
        Me.txbEndDateStopped.Location = New System.Drawing.Point(372, 4)
        Me.txbEndDateStopped.Name = "txbEndDateStopped"
        Me.txbEndDateStopped.ReadOnly = True
        Me.txbEndDateStopped.Size = New System.Drawing.Size(85, 21)
        Me.txbEndDateStopped.TabIndex = 4
        Me.txbEndDateStopped.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txbStartDateStopped
        '
        Me.txbStartDateStopped.Location = New System.Drawing.Point(135, 4)
        Me.txbStartDateStopped.Name = "txbStartDateStopped"
        Me.txbStartDateStopped.ReadOnly = True
        Me.txbStartDateStopped.Size = New System.Drawing.Size(85, 21)
        Me.txbStartDateStopped.TabIndex = 1
        Me.txbStartDateStopped.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Orange
        Me.Label19.Location = New System.Drawing.Point(317, 28)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(12, 12)
        Me.Label19.TabIndex = 3
        Me.Label19.Text = "*"
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "yyyy/MM/dd"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.dtpEndDate.Location = New System.Drawing.Point(567, 23)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(86, 21)
        Me.dtpEndDate.TabIndex = 6
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CustomFormat = "yyyy/MM/dd"
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDate.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.dtpStartDate.Location = New System.Drawing.Point(226, 24)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(86, 21)
        Me.dtpStartDate.TabIndex = 1
        '
        'txbStartDate
        '
        Me.txbStartDate.Location = New System.Drawing.Point(226, 24)
        Me.txbStartDate.Name = "txbStartDate"
        Me.txbStartDate.ReadOnly = True
        Me.txbStartDate.Size = New System.Drawing.Size(86, 21)
        Me.txbStartDate.TabIndex = 2
        Me.txbStartDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txbStartDate.Visible = False
        '
        'txbEndDate
        '
        Me.txbEndDate.Location = New System.Drawing.Point(567, 23)
        Me.txbEndDate.Name = "txbEndDate"
        Me.txbEndDate.ReadOnly = True
        Me.txbEndDate.Size = New System.Drawing.Size(86, 21)
        Me.txbEndDate.TabIndex = 5
        Me.txbEndDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txbEndDate.Visible = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Orange
        Me.Label21.Location = New System.Drawing.Point(659, 28)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(12, 12)
        Me.Label21.TabIndex = 7
        Me.Label21.Text = "*"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(10, 28)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(203, 12)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "合同开始日期 Contract Sta&rt Date:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(348, 28)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(191, 12)
        Me.Label20.TabIndex = 4
        Me.Label20.Text = "合同结束日期 Contract &End Date:"
        '
        'grbFaceValue
        '
        Me.grbFaceValue.Controls.Add(Me.txbMaxFaceValue)
        Me.grbFaceValue.Controls.Add(Me.Label23)
        Me.grbFaceValue.Controls.Add(Me.txbMinFaceValue)
        Me.grbFaceValue.Controls.Add(Me.Label22)
        Me.grbFaceValue.Controls.Add(Me.Label24)
        Me.grbFaceValue.Controls.Add(Me.Label25)
        Me.grbFaceValue.Location = New System.Drawing.Point(12, 441)
        Me.grbFaceValue.Margin = New System.Windows.Forms.Padding(12, 0, 8, 8)
        Me.grbFaceValue.Name = "grbFaceValue"
        Me.grbFaceValue.Size = New System.Drawing.Size(752, 60)
        Me.grbFaceValue.TabIndex = 3
        Me.grbFaceValue.TabStop = False
        Me.grbFaceValue.Text = "卡片面值设置 Card Face Value Configuration:"
        '
        'txbMaxFaceValue
        '
        Me.txbMaxFaceValue.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbMaxFaceValue.Location = New System.Drawing.Point(567, 24)
        Me.txbMaxFaceValue.MaxLength = 12
        Me.txbMaxFaceValue.Name = "txbMaxFaceValue"
        Me.txbMaxFaceValue.Size = New System.Drawing.Size(86, 21)
        Me.txbMaxFaceValue.TabIndex = 5
        Me.txbMaxFaceValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Orange
        Me.Label23.Location = New System.Drawing.Point(317, 28)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(12, 12)
        Me.Label23.TabIndex = 12
        Me.Label23.Text = "*"
        '
        'txbMinFaceValue
        '
        Me.txbMinFaceValue.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbMinFaceValue.Location = New System.Drawing.Point(226, 24)
        Me.txbMinFaceValue.MaxLength = 12
        Me.txbMinFaceValue.Name = "txbMinFaceValue"
        Me.txbMinFaceValue.Size = New System.Drawing.Size(86, 21)
        Me.txbMinFaceValue.TabIndex = 3
        Me.txbMinFaceValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(10, 28)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(215, 12)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "卡片最小面值 Minimal Face Value: ￥"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(348, 28)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(221, 12)
        Me.Label24.TabIndex = 2
        Me.Label24.Text = "卡片最大面值 Maximum Face Value:  ￥"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Orange
        Me.Label25.Location = New System.Drawing.Point(659, 28)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(12, 12)
        Me.Label25.TabIndex = 12
        Me.Label25.Text = "*"
        '
        'grbContractAMT
        '
        Me.grbContractAMT.Controls.Add(Me.txbMaxContractAMT)
        Me.grbContractAMT.Controls.Add(Me.txbMinContractAMT)
        Me.grbContractAMT.Controls.Add(Me.txbTotalContractAMT)
        Me.grbContractAMT.Controls.Add(Me.txbMinAMTPerPurchase)
        Me.grbContractAMT.Controls.Add(Me.Label29)
        Me.grbContractAMT.Controls.Add(Me.Label62)
        Me.grbContractAMT.Controls.Add(Me.Label28)
        Me.grbContractAMT.Controls.Add(Me.Label27)
        Me.grbContractAMT.Controls.Add(Me.Label26)
        Me.grbContractAMT.Location = New System.Drawing.Point(12, 509)
        Me.grbContractAMT.Margin = New System.Windows.Forms.Padding(12, 0, 8, 8)
        Me.grbContractAMT.Name = "grbContractAMT"
        Me.grbContractAMT.Size = New System.Drawing.Size(752, 114)
        Me.grbContractAMT.TabIndex = 4
        Me.grbContractAMT.TabStop = False
        Me.grbContractAMT.Text = "合同金额设置 Contract Amount Configuration:"
        '
        'txbMaxContractAMT
        '
        Me.txbMaxContractAMT.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbMaxContractAMT.Location = New System.Drawing.Point(567, 51)
        Me.txbMaxContractAMT.MaxLength = 12
        Me.txbMaxContractAMT.Name = "txbMaxContractAMT"
        Me.txbMaxContractAMT.Size = New System.Drawing.Size(146, 21)
        Me.txbMaxContractAMT.TabIndex = 11
        Me.txbMaxContractAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txbMinContractAMT
        '
        Me.txbMinContractAMT.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbMinContractAMT.Location = New System.Drawing.Point(226, 51)
        Me.txbMinContractAMT.MaxLength = 12
        Me.txbMinContractAMT.Name = "txbMinContractAMT"
        Me.txbMinContractAMT.Size = New System.Drawing.Size(146, 21)
        Me.txbMinContractAMT.TabIndex = 7
        Me.txbMinContractAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txbTotalContractAMT
        '
        Me.txbTotalContractAMT.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbTotalContractAMT.Location = New System.Drawing.Point(226, 24)
        Me.txbTotalContractAMT.MaxLength = 12
        Me.txbTotalContractAMT.Name = "txbTotalContractAMT"
        Me.txbTotalContractAMT.Size = New System.Drawing.Size(146, 21)
        Me.txbTotalContractAMT.TabIndex = 3
        Me.txbTotalContractAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txbMinAMTPerPurchase
        '
        Me.txbMinAMTPerPurchase.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbMinAMTPerPurchase.Location = New System.Drawing.Point(226, 78)
        Me.txbMinAMTPerPurchase.MaxLength = 12
        Me.txbMinAMTPerPurchase.Name = "txbMinAMTPerPurchase"
        Me.txbMinAMTPerPurchase.Size = New System.Drawing.Size(146, 21)
        Me.txbMinAMTPerPurchase.TabIndex = 15
        Me.txbMinAMTPerPurchase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Orange
        Me.Label29.Location = New System.Drawing.Point(377, 82)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(12, 12)
        Me.Label29.TabIndex = 12
        Me.Label29.Text = "*"
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Location = New System.Drawing.Point(10, 82)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(215, 12)
        Me.Label62.TabIndex = 12
        Me.Label62.Text = "单次最低购买金额 Min per purchase￥"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(384, 56)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(185, 12)
        Me.Label28.TabIndex = 8
        Me.Label28.Text = "最大总金额 Maximum Amount:  ￥"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(10, 56)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(215, 12)
        Me.Label27.TabIndex = 4
        Me.Label27.Text = "合同最小总金额 Minimal Amount:   ￥"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(10, 28)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(215, 12)
        Me.Label26.TabIndex = 0
        Me.Label26.Text = "合同可能总金额 Total Amount:     ￥"
        '
        'grbDiscountMode
        '
        Me.grbDiscountMode.Controls.Add(Me.rdbDeduction)
        Me.grbDiscountMode.Controls.Add(Me.rdbAddition)
        Me.grbDiscountMode.Location = New System.Drawing.Point(12, 631)
        Me.grbDiscountMode.Margin = New System.Windows.Forms.Padding(12, 0, 8, 8)
        Me.grbDiscountMode.Name = "grbDiscountMode"
        Me.grbDiscountMode.Size = New System.Drawing.Size(752, 50)
        Me.grbDiscountMode.TabIndex = 5
        Me.grbDiscountMode.TabStop = False
        Me.grbDiscountMode.Text = "返点方式 Discount Mode: "
        '
        'rdbDeduction
        '
        Me.rdbDeduction.AutoSize = True
        Me.rdbDeduction.Location = New System.Drawing.Point(226, 21)
        Me.rdbDeduction.Name = "rdbDeduction"
        Me.rdbDeduction.Size = New System.Drawing.Size(209, 16)
        Me.rdbDeduction.TabIndex = 1
        Me.rdbDeduction.Text = "付款抵扣 &Deduction from Payment"
        Me.rdbDeduction.UseVisualStyleBackColor = True
        '
        'rdbAddition
        '
        Me.rdbAddition.AutoSize = True
        Me.rdbAddition.Checked = True
        Me.rdbAddition.Location = New System.Drawing.Point(12, 21)
        Me.rdbAddition.Name = "rdbAddition"
        Me.rdbAddition.Size = New System.Drawing.Size(173, 16)
        Me.rdbAddition.TabIndex = 0
        Me.rdbAddition.TabStop = True
        Me.rdbAddition.Text = "赠送返点 &Additional Cards"
        Me.rdbAddition.UseVisualStyleBackColor = True
        '
        'grbCalculationMode
        '
        Me.grbCalculationMode.Controls.Add(Me.rdbCalculationBySection)
        Me.grbCalculationMode.Controls.Add(Me.rdbCalculationByTotal)
        Me.grbCalculationMode.Location = New System.Drawing.Point(12, 689)
        Me.grbCalculationMode.Margin = New System.Windows.Forms.Padding(12, 0, 8, 8)
        Me.grbCalculationMode.Name = "grbCalculationMode"
        Me.grbCalculationMode.Size = New System.Drawing.Size(752, 50)
        Me.grbCalculationMode.TabIndex = 6
        Me.grbCalculationMode.TabStop = False
        Me.grbCalculationMode.Text = "计算方式 Calculation Mode:"
        '
        'rdbCalculationBySection
        '
        Me.rdbCalculationBySection.AutoSize = True
        Me.rdbCalculationBySection.Location = New System.Drawing.Point(372, 21)
        Me.rdbCalculationBySection.Name = "rdbCalculationBySection"
        Me.rdbCalculationBySection.Size = New System.Drawing.Size(353, 16)
        Me.rdbCalculationBySection.TabIndex = 1
        Me.rdbCalculationBySection.Text = "按分段金额计算 Calculate on sect&ions of purchase amount"
        Me.rdbCalculationBySection.UseVisualStyleBackColor = True
        '
        'rdbCalculationByTotal
        '
        Me.rdbCalculationByTotal.AutoSize = True
        Me.rdbCalculationByTotal.Checked = True
        Me.rdbCalculationByTotal.Location = New System.Drawing.Point(12, 21)
        Me.rdbCalculationByTotal.Name = "rdbCalculationByTotal"
        Me.rdbCalculationByTotal.Size = New System.Drawing.Size(317, 16)
        Me.rdbCalculationByTotal.TabIndex = 0
        Me.rdbCalculationByTotal.TabStop = True
        Me.rdbCalculationByTotal.Text = "按购物总额计算 Calculate on &total purchase amount"
        Me.rdbCalculationByTotal.UseVisualStyleBackColor = True
        '
        'grbCalculationDate
        '
        Me.grbCalculationDate.Controls.Add(Me.nudCalculationDay)
        Me.grbCalculationDate.Controls.Add(Me.dtpAppointedDate)
        Me.grbCalculationDate.Controls.Add(Me.rdbEachPurchase)
        Me.grbCalculationDate.Controls.Add(Me.txbAppointedDate)
        Me.grbCalculationDate.Controls.Add(Me.rdbEndOfContract)
        Me.grbCalculationDate.Controls.Add(Me.txbCalculationDay)
        Me.grbCalculationDate.Controls.Add(Me.rdbMonthly)
        Me.grbCalculationDate.Location = New System.Drawing.Point(12, 747)
        Me.grbCalculationDate.Margin = New System.Windows.Forms.Padding(12, 0, 8, 8)
        Me.grbCalculationDate.Name = "grbCalculationDate"
        Me.grbCalculationDate.Size = New System.Drawing.Size(752, 50)
        Me.grbCalculationDate.TabIndex = 8
        Me.grbCalculationDate.TabStop = False
        Me.grbCalculationDate.Text = "返点计算日 Discount Calculation Date:"
        '
        'nudCalculationDay
        '
        Me.nudCalculationDay.Enabled = False
        Me.nudCalculationDay.Location = New System.Drawing.Point(383, 18)
        Me.nudCalculationDay.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudCalculationDay.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudCalculationDay.Name = "nudCalculationDay"
        Me.nudCalculationDay.Size = New System.Drawing.Size(38, 21)
        Me.nudCalculationDay.TabIndex = 5
        Me.nudCalculationDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudCalculationDay.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'dtpAppointedDate
        '
        Me.dtpAppointedDate.CustomFormat = "yyyy/MM/dd"
        Me.dtpAppointedDate.Enabled = False
        Me.dtpAppointedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAppointedDate.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.dtpAppointedDate.Location = New System.Drawing.Point(651, 18)
        Me.dtpAppointedDate.Name = "dtpAppointedDate"
        Me.dtpAppointedDate.Size = New System.Drawing.Size(86, 21)
        Me.dtpAppointedDate.TabIndex = 1
        Me.dtpAppointedDate.Visible = False
        '
        'rdbEachPurchase
        '
        Me.rdbEachPurchase.AutoSize = True
        Me.rdbEachPurchase.Checked = True
        Me.rdbEachPurchase.Location = New System.Drawing.Point(470, 21)
        Me.rdbEachPurchase.Name = "rdbEachPurchase"
        Me.rdbEachPurchase.Size = New System.Drawing.Size(155, 16)
        Me.rdbEachPurchase.TabIndex = 6
        Me.rdbEachPurchase.TabStop = True
        Me.rdbEachPurchase.Text = "每次购物 Each p&urchase"
        Me.rdbEachPurchase.UseVisualStyleBackColor = True
        '
        'txbAppointedDate
        '
        Me.txbAppointedDate.Location = New System.Drawing.Point(651, 18)
        Me.txbAppointedDate.Name = "txbAppointedDate"
        Me.txbAppointedDate.ReadOnly = True
        Me.txbAppointedDate.Size = New System.Drawing.Size(86, 21)
        Me.txbAppointedDate.TabIndex = 2
        Me.txbAppointedDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txbAppointedDate.Visible = False
        '
        'rdbEndOfContract
        '
        Me.rdbEndOfContract.AutoSize = True
        Me.rdbEndOfContract.Location = New System.Drawing.Point(12, 21)
        Me.rdbEndOfContract.Name = "rdbEndOfContract"
        Me.rdbEndOfContract.Size = New System.Drawing.Size(179, 16)
        Me.rdbEndOfContract.TabIndex = 0
        Me.rdbEndOfContract.Text = "合同期满后 End of &Contract"
        Me.rdbEndOfContract.UseVisualStyleBackColor = True
        '
        'txbCalculationDay
        '
        Me.txbCalculationDay.Location = New System.Drawing.Point(383, 18)
        Me.txbCalculationDay.Name = "txbCalculationDay"
        Me.txbCalculationDay.ReadOnly = True
        Me.txbCalculationDay.Size = New System.Drawing.Size(38, 21)
        Me.txbCalculationDay.TabIndex = 4
        Me.txbCalculationDay.Text = "1"
        Me.txbCalculationDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txbCalculationDay.Visible = False
        '
        'rdbMonthly
        '
        Me.rdbMonthly.AutoSize = True
        Me.rdbMonthly.Location = New System.Drawing.Point(226, 21)
        Me.rdbMonthly.Name = "rdbMonthly"
        Me.rdbMonthly.Size = New System.Drawing.Size(161, 16)
        Me.rdbMonthly.TabIndex = 3
        Me.rdbMonthly.Text = "每月一次 &Monthly, day: "
        Me.rdbMonthly.UseVisualStyleBackColor = True
        '
        'grbDetails
        '
        Me.grbDetails.Controls.Add(Me.Label31)
        Me.grbDetails.Controls.Add(Me.Label32)
        Me.grbDetails.Controls.Add(Me.Label30)
        Me.grbDetails.Controls.Add(Me.btnCompare)
        Me.grbDetails.Controls.Add(Me.lblAvailable)
        Me.grbDetails.Controls.Add(Me.dgvDetails)
        Me.grbDetails.Location = New System.Drawing.Point(12, 805)
        Me.grbDetails.Margin = New System.Windows.Forms.Padding(12, 0, 8, 8)
        Me.grbDetails.Name = "grbDetails"
        Me.grbDetails.Size = New System.Drawing.Size(752, 133)
        Me.grbDetails.TabIndex = 8
        Me.grbDetails.TabStop = False
        Me.grbDetails.Text = "返点分段列表 Discount &List:"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(28, 38)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(167, 12)
        Me.Label31.TabIndex = 1
        Me.Label31.Text = "Compare with current City's"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(28, 52)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(167, 12)
        Me.Label32.TabIndex = 2
        Me.Label32.Text = "normal discount rate scale:"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(28, 23)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(173, 12)
        Me.Label30.TabIndex = 0
        Me.Label30.Text = "对比所在城市的当前返点规则："
        '
        'btnCompare
        '
        Me.btnCompare.Location = New System.Drawing.Point(53, 71)
        Me.btnCompare.Name = "btnCompare"
        Me.btnCompare.Size = New System.Drawing.Size(99, 23)
        Me.btnCompare.TabIndex = 4
        Me.btnCompare.Text = "对比 Compare"
        Me.btnCompare.UseVisualStyleBackColor = True
        '
        'lblAvailable
        '
        Me.lblAvailable.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblAvailable.AutoSize = True
        Me.lblAvailable.ForeColor = System.Drawing.Color.Maroon
        Me.lblAvailable.Location = New System.Drawing.Point(10, 107)
        Me.lblAvailable.Name = "lblAvailable"
        Me.lblAvailable.Size = New System.Drawing.Size(209, 12)
        Me.lblAvailable.TabIndex = 6
        Me.lblAvailable.Text = "（黄色行是适用于当前销售单的阶段）"
        Me.lblAvailable.Visible = False
        '
        'dgvDetails
        '
        Me.dgvDetails.AllowUserToAddRows = False
        Me.dgvDetails.AllowUserToDeleteRows = False
        Me.dgvDetails.AllowUserToResizeRows = False
        Me.dgvDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetails.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDetails.ColumnHeadersHeight = 22
        Me.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvDetails.Location = New System.Drawing.Point(226, 23)
        Me.dgvDetails.MultiSelect = False
        Me.dgvDetails.Name = "dgvDetails"
        Me.dgvDetails.RowHeadersVisible = False
        Me.dgvDetails.RowTemplate.Height = 24
        Me.dgvDetails.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgvDetails.Size = New System.Drawing.Size(511, 96)
        Me.dgvDetails.StandardTab = True
        Me.dgvDetails.TabIndex = 5
        '
        'grbScope
        '
        Me.grbScope.Controls.Add(Me.cbbAppointedStore)
        Me.grbScope.Controls.Add(Me.rdbAppointedStore)
        Me.grbScope.Controls.Add(Me.rdbAllStores)
        Me.grbScope.Controls.Add(Me.txbAppointedStore)
        Me.grbScope.Location = New System.Drawing.Point(12, 946)
        Me.grbScope.Margin = New System.Windows.Forms.Padding(12, 0, 8, 8)
        Me.grbScope.Name = "grbScope"
        Me.grbScope.Size = New System.Drawing.Size(752, 55)
        Me.grbScope.TabIndex = 9
        Me.grbScope.TabStop = False
        Me.grbScope.Text = "合同适用范围 Contract apply to: "
        '
        'cbbAppointedStore
        '
        Me.cbbAppointedStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbAppointedStore.Enabled = False
        Me.cbbAppointedStore.FormattingEnabled = True
        Me.cbbAppointedStore.Location = New System.Drawing.Point(381, 22)
        Me.cbbAppointedStore.Name = "cbbAppointedStore"
        Me.cbbAppointedStore.Size = New System.Drawing.Size(356, 20)
        Me.cbbAppointedStore.TabIndex = 2
        '
        'rdbAppointedStore
        '
        Me.rdbAppointedStore.AutoSize = True
        Me.rdbAppointedStore.Location = New System.Drawing.Point(226, 23)
        Me.rdbAppointedStore.Name = "rdbAppointedStore"
        Me.rdbAppointedStore.Size = New System.Drawing.Size(149, 16)
        Me.rdbAppointedStore.TabIndex = 1
        Me.rdbAppointedStore.Text = "门店级别 Store Level:"
        Me.rdbAppointedStore.UseVisualStyleBackColor = True
        '
        'rdbAllStores
        '
        Me.rdbAllStores.AutoSize = True
        Me.rdbAllStores.Checked = True
        Me.rdbAllStores.Location = New System.Drawing.Point(12, 23)
        Me.rdbAllStores.Name = "rdbAllStores"
        Me.rdbAllStores.Size = New System.Drawing.Size(137, 16)
        Me.rdbAllStores.TabIndex = 0
        Me.rdbAllStores.TabStop = True
        Me.rdbAllStores.Text = "城市级别 City Level"
        Me.rdbAllStores.UseVisualStyleBackColor = True
        '
        'txbAppointedStore
        '
        Me.txbAppointedStore.Enabled = False
        Me.txbAppointedStore.Location = New System.Drawing.Point(381, 22)
        Me.txbAppointedStore.Name = "txbAppointedStore"
        Me.txbAppointedStore.ReadOnly = True
        Me.txbAppointedStore.Size = New System.Drawing.Size(356, 21)
        Me.txbAppointedStore.TabIndex = 3
        Me.txbAppointedStore.Visible = False
        '
        'grbInvoice
        '
        Me.grbInvoice.Controls.Add(Me.tlpInvoice)
        Me.grbInvoice.Location = New System.Drawing.Point(12, 1009)
        Me.grbInvoice.Margin = New System.Windows.Forms.Padding(12, 0, 8, 8)
        Me.grbInvoice.Name = "grbInvoice"
        Me.grbInvoice.Size = New System.Drawing.Size(752, 85)
        Me.grbInvoice.TabIndex = 10
        Me.grbInvoice.TabStop = False
        Me.grbInvoice.Text = "发票抬头与品项 Invoice Title && Items: "
        '
        'tlpInvoice
        '
        Me.tlpInvoice.AutoSize = True
        Me.tlpInvoice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpInvoice.ColumnCount = 3
        Me.tlpInvoice.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpInvoice.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpInvoice.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpInvoice.Controls.Add(Me.cklInvoiceTitle, 1, 0)
        Me.tlpInvoice.Controls.Add(Me.cbbInvoiceItem, 1, 1)
        Me.tlpInvoice.Controls.Add(Me.Label35, 2, 0)
        Me.tlpInvoice.Controls.Add(Me.Label36, 0, 1)
        Me.tlpInvoice.Controls.Add(Me.Panel5, 0, 0)
        Me.tlpInvoice.Controls.Add(Me.Label37, 2, 1)
        Me.tlpInvoice.Location = New System.Drawing.Point(10, 24)
        Me.tlpInvoice.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpInvoice.Name = "tlpInvoice"
        Me.tlpInvoice.RowCount = 2
        Me.tlpInvoice.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpInvoice.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpInvoice.Size = New System.Drawing.Size(734, 49)
        Me.tlpInvoice.TabIndex = 0
        '
        'cklInvoiceTitle
        '
        Me.cklInvoiceTitle.FormattingEnabled = True
        Me.cklInvoiceTitle.Location = New System.Drawing.Point(216, 0)
        Me.cklInvoiceTitle.Margin = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.cklInvoiceTitle.Name = "cklInvoiceTitle"
        Me.cklInvoiceTitle.Size = New System.Drawing.Size(500, 20)
        Me.cklInvoiceTitle.TabIndex = 1
        '
        'cbbInvoiceItem
        '
        Me.cbbInvoiceItem.FormattingEnabled = True
        Me.cbbInvoiceItem.IntegralHeight = False
        Me.cbbInvoiceItem.Location = New System.Drawing.Point(216, 26)
        Me.cbbInvoiceItem.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.cbbInvoiceItem.MaxDropDownItems = 20
        Me.cbbInvoiceItem.Name = "cbbInvoiceItem"
        Me.cbbInvoiceItem.Size = New System.Drawing.Size(500, 20)
        Me.cbbInvoiceItem.TabIndex = 4
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.Orange
        Me.Label35.Location = New System.Drawing.Point(719, 4)
        Me.Label35.Margin = New System.Windows.Forms.Padding(3, 4, 0, 0)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(12, 12)
        Me.Label35.TabIndex = 2
        Me.Label35.Text = "*"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(0, 31)
        Me.Label36.Margin = New System.Windows.Forms.Padding(0, 8, 0, 0)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(173, 12)
        Me.Label36.TabIndex = 3
        Me.Label36.Text = "发票品项 Invoice Items List:"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label34)
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(216, 23)
        Me.Panel5.TabIndex = 0
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(0, 5)
        Me.Label34.Margin = New System.Windows.Forms.Padding(0)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(215, 12)
        Me.Label34.TabIndex = 0
        Me.Label34.Text = "发票抬头 Invoice Titles List:      "
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.Orange
        Me.Label37.Location = New System.Drawing.Point(719, 31)
        Me.Label37.Margin = New System.Windows.Forms.Padding(3, 8, 3, 0)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(12, 12)
        Me.Label37.TabIndex = 5
        Me.Label37.Text = "*"
        '
        'grbOperation
        '
        Me.grbOperation.Controls.Add(Me.tlpOperation)
        Me.grbOperation.Location = New System.Drawing.Point(12, 1102)
        Me.grbOperation.Margin = New System.Windows.Forms.Padding(12, 0, 8, 10)
        Me.grbOperation.Name = "grbOperation"
        Me.grbOperation.Size = New System.Drawing.Size(752, 192)
        Me.grbOperation.TabIndex = 11
        Me.grbOperation.TabStop = False
        Me.grbOperation.Text = "操作信息 Operation Info:"
        '
        'tlpOperation
        '
        Me.tlpOperation.AutoSize = True
        Me.tlpOperation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpOperation.ColumnCount = 1
        Me.tlpOperation.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpOperation.Controls.Add(Me.pnlStopInfo, 0, 5)
        Me.tlpOperation.Controls.Add(Me.pnlValidateInfo, 0, 4)
        Me.tlpOperation.Controls.Add(Me.pnlValidateTitle, 0, 3)
        Me.tlpOperation.Controls.Add(Me.pnlFirstValidateInfo, 0, 2)
        Me.tlpOperation.Controls.Add(Me.pnlModifyInfo, 0, 1)
        Me.tlpOperation.Controls.Add(Me.pnlCreateInfo, 0, 0)
        Me.tlpOperation.Location = New System.Drawing.Point(10, 24)
        Me.tlpOperation.Name = "tlpOperation"
        Me.tlpOperation.RowCount = 6
        Me.tlpOperation.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpOperation.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpOperation.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpOperation.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpOperation.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpOperation.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpOperation.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpOperation.Size = New System.Drawing.Size(559, 160)
        Me.tlpOperation.TabIndex = 0
        '
        'pnlStopInfo
        '
        Me.pnlStopInfo.Controls.Add(Me.Label55)
        Me.pnlStopInfo.Controls.Add(Me.lblStoppedTime)
        Me.pnlStopInfo.Controls.Add(Me.lblStopper)
        Me.pnlStopInfo.Controls.Add(Me.Label53)
        Me.pnlStopInfo.Location = New System.Drawing.Point(0, 135)
        Me.pnlStopInfo.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlStopInfo.Name = "pnlStopInfo"
        Me.pnlStopInfo.Size = New System.Drawing.Size(559, 25)
        Me.pnlStopInfo.TabIndex = 5
        Me.pnlStopInfo.Visible = False
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(0, 3)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(95, 12)
        Me.Label55.TabIndex = 8
        Me.Label55.Text = "停用者 Stopper:"
        '
        'lblStoppedTime
        '
        Me.lblStoppedTime.BackColor = System.Drawing.SystemColors.Info
        Me.lblStoppedTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblStoppedTime.Location = New System.Drawing.Point(412, 0)
        Me.lblStoppedTime.Name = "lblStoppedTime"
        Me.lblStoppedTime.Size = New System.Drawing.Size(144, 18)
        Me.lblStoppedTime.TabIndex = 11
        Me.lblStoppedTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStopper
        '
        Me.lblStopper.BackColor = System.Drawing.SystemColors.Info
        Me.lblStopper.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblStopper.Location = New System.Drawing.Point(107, 0)
        Me.lblStopper.Name = "lblStopper"
        Me.lblStopper.Size = New System.Drawing.Size(144, 18)
        Me.lblStopper.TabIndex = 9
        Me.lblStopper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(257, 3)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(137, 12)
        Me.Label53.TabIndex = 10
        Me.Label53.Text = "停用时间 Stopped Time:"
        '
        'pnlValidateInfo
        '
        Me.pnlValidateInfo.Controls.Add(Me.Label42)
        Me.pnlValidateInfo.Controls.Add(Me.lblValidatedTime)
        Me.pnlValidateInfo.Controls.Add(Me.Label43)
        Me.pnlValidateInfo.Controls.Add(Me.lblAuditor)
        Me.pnlValidateInfo.Location = New System.Drawing.Point(0, 110)
        Me.pnlValidateInfo.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlValidateInfo.Name = "pnlValidateInfo"
        Me.pnlValidateInfo.Size = New System.Drawing.Size(559, 25)
        Me.pnlValidateInfo.TabIndex = 4
        Me.pnlValidateInfo.Visible = False
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(0, 3)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(95, 12)
        Me.Label42.TabIndex = 8
        Me.Label42.Text = "审核者 Auditor:"
        '
        'lblValidatedTime
        '
        Me.lblValidatedTime.BackColor = System.Drawing.SystemColors.Info
        Me.lblValidatedTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblValidatedTime.Location = New System.Drawing.Point(412, 0)
        Me.lblValidatedTime.Name = "lblValidatedTime"
        Me.lblValidatedTime.Size = New System.Drawing.Size(144, 18)
        Me.lblValidatedTime.TabIndex = 11
        Me.lblValidatedTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(257, 3)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(149, 12)
        Me.Label43.TabIndex = 10
        Me.Label43.Text = "审核时间 Validated Time:"
        '
        'lblAuditor
        '
        Me.lblAuditor.BackColor = System.Drawing.SystemColors.Info
        Me.lblAuditor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAuditor.Location = New System.Drawing.Point(107, 0)
        Me.lblAuditor.Name = "lblAuditor"
        Me.lblAuditor.Size = New System.Drawing.Size(144, 18)
        Me.lblAuditor.TabIndex = 9
        Me.lblAuditor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlValidateTitle
        '
        Me.pnlValidateTitle.Controls.Add(Me.Label57)
        Me.pnlValidateTitle.Location = New System.Drawing.Point(0, 90)
        Me.pnlValidateTitle.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlValidateTitle.Name = "pnlValidateTitle"
        Me.pnlValidateTitle.Size = New System.Drawing.Size(559, 20)
        Me.pnlValidateTitle.TabIndex = 3
        Me.pnlValidateTitle.Visible = False
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label57.ForeColor = System.Drawing.Color.Maroon
        Me.Label57.Location = New System.Drawing.Point(0, 4)
        Me.Label57.Margin = New System.Windows.Forms.Padding(0)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(319, 12)
        Me.Label57.TabIndex = 0
        Me.Label57.Text = "二级（总部）审核 Second Level (HO) Validation:"
        '
        'pnlFirstValidateInfo
        '
        Me.pnlFirstValidateInfo.Controls.Add(Me.Label54)
        Me.pnlFirstValidateInfo.Controls.Add(Me.Label51)
        Me.pnlFirstValidateInfo.Controls.Add(Me.lblFirstValidatedTime)
        Me.pnlFirstValidateInfo.Controls.Add(Me.Label56)
        Me.pnlFirstValidateInfo.Controls.Add(Me.lblFirstAuditor)
        Me.pnlFirstValidateInfo.Location = New System.Drawing.Point(0, 50)
        Me.pnlFirstValidateInfo.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlFirstValidateInfo.Name = "pnlFirstValidateInfo"
        Me.pnlFirstValidateInfo.Size = New System.Drawing.Size(559, 40)
        Me.pnlFirstValidateInfo.TabIndex = 2
        Me.pnlFirstValidateInfo.Visible = False
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label54.ForeColor = System.Drawing.Color.Maroon
        Me.Label54.Location = New System.Drawing.Point(0, 4)
        Me.Label54.Margin = New System.Windows.Forms.Padding(0)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(225, 12)
        Me.Label54.TabIndex = 0
        Me.Label54.Text = "一级审核 First Level Validation:"
        '
        'Label51
        '
        Me.Label51.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(0, 23)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(95, 12)
        Me.Label51.TabIndex = 8
        Me.Label51.Text = "审核者 Auditor:"
        '
        'lblFirstValidatedTime
        '
        Me.lblFirstValidatedTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblFirstValidatedTime.BackColor = System.Drawing.SystemColors.Info
        Me.lblFirstValidatedTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFirstValidatedTime.Location = New System.Drawing.Point(412, 20)
        Me.lblFirstValidatedTime.Name = "lblFirstValidatedTime"
        Me.lblFirstValidatedTime.Size = New System.Drawing.Size(144, 18)
        Me.lblFirstValidatedTime.TabIndex = 11
        Me.lblFirstValidatedTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label56
        '
        Me.Label56.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(257, 23)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(149, 12)
        Me.Label56.TabIndex = 10
        Me.Label56.Text = "审核时间 Validated Time:"
        '
        'lblFirstAuditor
        '
        Me.lblFirstAuditor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblFirstAuditor.BackColor = System.Drawing.SystemColors.Info
        Me.lblFirstAuditor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFirstAuditor.Location = New System.Drawing.Point(107, 20)
        Me.lblFirstAuditor.Name = "lblFirstAuditor"
        Me.lblFirstAuditor.Size = New System.Drawing.Size(144, 18)
        Me.lblFirstAuditor.TabIndex = 9
        Me.lblFirstAuditor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlModifyInfo
        '
        Me.pnlModifyInfo.Controls.Add(Me.Label40)
        Me.pnlModifyInfo.Controls.Add(Me.Label41)
        Me.pnlModifyInfo.Controls.Add(Me.lblModifiedTime)
        Me.pnlModifyInfo.Controls.Add(Me.lblModifier)
        Me.pnlModifyInfo.Location = New System.Drawing.Point(0, 25)
        Me.pnlModifyInfo.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlModifyInfo.Name = "pnlModifyInfo"
        Me.pnlModifyInfo.Size = New System.Drawing.Size(559, 25)
        Me.pnlModifyInfo.TabIndex = 1
        Me.pnlModifyInfo.Visible = False
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(0, 3)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(101, 12)
        Me.Label40.TabIndex = 4
        Me.Label40.Text = "修改者 Modifier:"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(257, 3)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(143, 12)
        Me.Label41.TabIndex = 6
        Me.Label41.Text = "修改时间 Modified Time:"
        '
        'lblModifiedTime
        '
        Me.lblModifiedTime.BackColor = System.Drawing.SystemColors.Info
        Me.lblModifiedTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblModifiedTime.Location = New System.Drawing.Point(412, 0)
        Me.lblModifiedTime.Name = "lblModifiedTime"
        Me.lblModifiedTime.Size = New System.Drawing.Size(144, 18)
        Me.lblModifiedTime.TabIndex = 7
        Me.lblModifiedTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblModifier
        '
        Me.lblModifier.BackColor = System.Drawing.SystemColors.Info
        Me.lblModifier.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblModifier.Location = New System.Drawing.Point(107, 0)
        Me.lblModifier.Name = "lblModifier"
        Me.lblModifier.Size = New System.Drawing.Size(144, 18)
        Me.lblModifier.TabIndex = 5
        Me.lblModifier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlCreateInfo
        '
        Me.pnlCreateInfo.Controls.Add(Me.Label38)
        Me.pnlCreateInfo.Controls.Add(Me.Label39)
        Me.pnlCreateInfo.Controls.Add(Me.lblCreator)
        Me.pnlCreateInfo.Controls.Add(Me.lblCreatedTime)
        Me.pnlCreateInfo.Location = New System.Drawing.Point(0, 0)
        Me.pnlCreateInfo.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlCreateInfo.Name = "pnlCreateInfo"
        Me.pnlCreateInfo.Size = New System.Drawing.Size(559, 25)
        Me.pnlCreateInfo.TabIndex = 0
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(0, 3)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(95, 12)
        Me.Label38.TabIndex = 0
        Me.Label38.Text = "创建者 Creator:"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(257, 3)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(137, 12)
        Me.Label39.TabIndex = 2
        Me.Label39.Text = "建立时间 Created Time:"
        '
        'lblCreator
        '
        Me.lblCreator.BackColor = System.Drawing.SystemColors.Info
        Me.lblCreator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCreator.Location = New System.Drawing.Point(107, 0)
        Me.lblCreator.Name = "lblCreator"
        Me.lblCreator.Size = New System.Drawing.Size(144, 18)
        Me.lblCreator.TabIndex = 1
        Me.lblCreator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCreatedTime
        '
        Me.lblCreatedTime.BackColor = System.Drawing.SystemColors.Info
        Me.lblCreatedTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCreatedTime.Location = New System.Drawing.Point(412, 0)
        Me.lblCreatedTime.Name = "lblCreatedTime"
        Me.lblCreatedTime.Size = New System.Drawing.Size(144, 18)
        Me.lblCreatedTime.TabIndex = 3
        Me.lblCreatedTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "合同编号   Contract Code:"
        '
        'theTip
        '
        Me.theTip.AutoPopDelay = 15000
        Me.theTip.InitialDelay = 500
        Me.theTip.ReshowDelay = 100
        '
        'txbCustomerCode
        '
        Me.txbCustomerCode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbCustomerCode.Location = New System.Drawing.Point(168, 9)
        Me.txbCustomerCode.MaxLength = 9
        Me.txbCustomerCode.Name = "txbCustomerCode"
        Me.txbCustomerCode.ReadOnly = True
        Me.txbCustomerCode.Size = New System.Drawing.Size(68, 21)
        Me.txbCustomerCode.TabIndex = 1
        Me.txbCustomerCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.theTip.SetToolTip(Me.txbCustomerCode, "First Customer Code")
        '
        'txbContractCode
        '
        Me.txbContractCode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbContractCode.Location = New System.Drawing.Point(242, 9)
        Me.txbContractCode.MaxLength = 13
        Me.txbContractCode.Name = "txbContractCode"
        Me.txbContractCode.ReadOnly = True
        Me.txbContractCode.Size = New System.Drawing.Size(32, 21)
        Me.txbContractCode.TabIndex = 2
        Me.theTip.SetToolTip(Me.txbContractCode, "Sequence No.")
        '
        'btnSelectPrinter
        '
        Me.btnSelectPrinter.Location = New System.Drawing.Point(747, 9)
        Me.btnSelectPrinter.Name = "btnSelectPrinter"
        Me.btnSelectPrinter.Size = New System.Drawing.Size(31, 23)
        Me.btnSelectPrinter.TabIndex = 5
        Me.btnSelectPrinter.Text = "..."
        Me.theTip.SetToolTip(Me.btnSelectPrinter, "选择打印机")
        Me.btnSelectPrinter.UseVisualStyleBackColor = True
        '
        'theTimer
        '
        '
        'cmenuDeleteRebateRow
        '
        Me.cmenuDeleteRebateRow.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuDeleteRebateRow})
        Me.cmenuDeleteRebateRow.Name = "cmenuDeleteCardRow"
        Me.cmenuDeleteRebateRow.Size = New System.Drawing.Size(166, 26)
        '
        'menuDeleteRebateRow
        '
        Me.menuDeleteRebateRow.Name = "menuDeleteRebateRow"
        Me.menuDeleteRebateRow.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.menuDeleteRebateRow.Size = New System.Drawing.Size(165, 22)
        Me.menuDeleteRebateRow.Text = "删除行   "
        '
        'pnlValidate
        '
        Me.pnlValidate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlValidate.Controls.Add(Me.GroupBox3)
        Me.pnlValidate.Controls.Add(Me.rdbOK)
        Me.pnlValidate.Controls.Add(Me.txbFailureReason)
        Me.pnlValidate.Controls.Add(Me.rdbFailure)
        Me.pnlValidate.Controls.Add(Me.Label61)
        Me.pnlValidate.Location = New System.Drawing.Point(0, 166)
        Me.pnlValidate.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlValidate.Name = "pnlValidate"
        Me.pnlValidate.Size = New System.Drawing.Size(794, 45)
        Me.pnlValidate.TabIndex = 3
        Me.pnlValidate.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Enabled = False
        Me.GroupBox3.Location = New System.Drawing.Point(-10, 38)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(840, 4)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "GroupBox4"
        '
        'rdbOK
        '
        Me.rdbOK.AutoSize = True
        Me.rdbOK.Location = New System.Drawing.Point(233, 11)
        Me.rdbOK.Name = "rdbOK"
        Me.rdbOK.Size = New System.Drawing.Size(65, 16)
        Me.rdbOK.TabIndex = 1
        Me.rdbOK.TabStop = True
        Me.rdbOK.Text = "通过 &OK"
        Me.rdbOK.UseVisualStyleBackColor = True
        '
        'txbFailureReason
        '
        Me.txbFailureReason.Enabled = False
        Me.txbFailureReason.Location = New System.Drawing.Point(454, 9)
        Me.txbFailureReason.MaxLength = 50
        Me.txbFailureReason.Name = "txbFailureReason"
        Me.txbFailureReason.Size = New System.Drawing.Size(324, 21)
        Me.txbFailureReason.TabIndex = 3
        '
        'rdbFailure
        '
        Me.rdbFailure.AutoSize = True
        Me.rdbFailure.Location = New System.Drawing.Point(301, 11)
        Me.rdbFailure.Name = "rdbFailure"
        Me.rdbFailure.Size = New System.Drawing.Size(155, 16)
        Me.rdbFailure.TabIndex = 2
        Me.rdbFailure.TabStop = True
        Me.rdbFailure.Text = "失败 &Failure, reason: "
        Me.rdbFailure.UseVisualStyleBackColor = True
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.ForeColor = System.Drawing.Color.Blue
        Me.Label61.Location = New System.Drawing.Point(10, 13)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(221, 12)
        Me.Label61.TabIndex = 0
        Me.Label61.Text = "请审核合同 Please validate contract:"
        '
        'txbContratState
        '
        Me.txbContratState.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txbContratState.Location = New System.Drawing.Point(168, 8)
        Me.txbContratState.MaxLength = 9
        Me.txbContratState.Name = "txbContratState"
        Me.txbContratState.ReadOnly = True
        Me.txbContratState.Size = New System.Drawing.Size(610, 21)
        Me.txbContratState.TabIndex = 1
        Me.txbContratState.Text = "已过期（审核失败） Expired and validated failure"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "合同状态 Contract Status:"
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(565, 9)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(68, 23)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "保存 &Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(639, 9)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(102, 23)
        Me.btnPrint.TabIndex = 4
        Me.btnPrint.Text = "打印合同 &Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'pnlContractState
        '
        Me.pnlContractState.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlContractState.Controls.Add(Me.pnlReason)
        Me.pnlContractState.Controls.Add(Me.Label2)
        Me.pnlContractState.Controls.Add(Me.txbContratState)
        Me.pnlContractState.Controls.Add(Me.GroupBox2)
        Me.pnlContractState.Location = New System.Drawing.Point(0, 45)
        Me.pnlContractState.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlContractState.Name = "pnlContractState"
        Me.pnlContractState.Size = New System.Drawing.Size(794, 45)
        Me.pnlContractState.TabIndex = 1
        Me.pnlContractState.Visible = False
        '
        'pnlReason
        '
        Me.pnlReason.Controls.Add(Me.Label44)
        Me.pnlReason.Controls.Add(Me.txbReason)
        Me.pnlReason.Location = New System.Drawing.Point(473, 5)
        Me.pnlReason.Name = "pnlReason"
        Me.pnlReason.Size = New System.Drawing.Size(318, 27)
        Me.pnlReason.TabIndex = 2
        Me.pnlReason.Visible = False
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(0, 7)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(47, 12)
        Me.Label44.TabIndex = 0
        Me.Label44.Text = "Reason:"
        '
        'txbReason
        '
        Me.txbReason.Location = New System.Drawing.Point(51, 3)
        Me.txbReason.MaxLength = 50
        Me.txbReason.Name = "txbReason"
        Me.txbReason.ReadOnly = True
        Me.txbReason.Size = New System.Drawing.Size(254, 21)
        Me.txbReason.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(-10, 38)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(840, 4)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "GroupBox4"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(-10, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(820, 4)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox4"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txbContractCode)
        Me.Panel1.Controls.Add(Me.txbCustomerCode)
        Me.Panel1.Controls.Add(Me.btnSelectPrinter)
        Me.Panel1.Controls.Add(Me.btnPrint)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(794, 45)
        Me.Panel1.TabIndex = 0
        '
        'tlpContainer
        '
        Me.tlpContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpContainer.ColumnCount = 1
        Me.tlpContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpContainer.Controls.Add(Me.pnlHOValidate, 0, 6)
        Me.tlpContainer.Controls.Add(Me.flpContainer, 0, 5)
        Me.tlpContainer.Controls.Add(Me.pnlStop, 0, 4)
        Me.tlpContainer.Controls.Add(Me.pnlValidate, 0, 3)
        Me.tlpContainer.Controls.Add(Me.pnlFirstValidate, 0, 2)
        Me.tlpContainer.Controls.Add(Me.pnlContractState, 0, 1)
        Me.tlpContainer.Controls.Add(Me.Panel1, 0, 0)
        Me.tlpContainer.Location = New System.Drawing.Point(0, 0)
        Me.tlpContainer.Name = "tlpContainer"
        Me.tlpContainer.RowCount = 7
        Me.tlpContainer.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpContainer.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpContainer.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpContainer.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpContainer.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpContainer.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpContainer.Size = New System.Drawing.Size(794, 563)
        Me.tlpContainer.TabIndex = 0
        '
        'pnlHOValidate
        '
        Me.pnlHOValidate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlHOValidate.Controls.Add(Me.pnlHOValidation)
        Me.pnlHOValidate.Controls.Add(Me.lblHOEnglishRemarks)
        Me.pnlHOValidate.Controls.Add(Me.lblHOChineseRemarks)
        Me.pnlHOValidate.Controls.Add(Me.Label65)
        Me.pnlHOValidate.Controls.Add(Me.GroupBox7)
        Me.pnlHOValidate.Controls.Add(Me.Label66)
        Me.pnlHOValidate.Location = New System.Drawing.Point(0, 514)
        Me.pnlHOValidate.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlHOValidate.Name = "pnlHOValidate"
        Me.pnlHOValidate.Size = New System.Drawing.Size(794, 49)
        Me.pnlHOValidate.TabIndex = 6
        Me.pnlHOValidate.Visible = False
        '
        'pnlHOValidation
        '
        Me.pnlHOValidation.Controls.Add(Me.txbHOFailureReason)
        Me.pnlHOValidation.Controls.Add(Me.rdbHOOK)
        Me.pnlHOValidation.Controls.Add(Me.rdbHOFailure)
        Me.pnlHOValidation.Location = New System.Drawing.Point(230, 14)
        Me.pnlHOValidation.Name = "pnlHOValidation"
        Me.pnlHOValidation.Size = New System.Drawing.Size(551, 27)
        Me.pnlHOValidation.TabIndex = 1
        '
        'txbHOFailureReason
        '
        Me.txbHOFailureReason.Enabled = False
        Me.txbHOFailureReason.Location = New System.Drawing.Point(224, 3)
        Me.txbHOFailureReason.MaxLength = 50
        Me.txbHOFailureReason.Name = "txbHOFailureReason"
        Me.txbHOFailureReason.Size = New System.Drawing.Size(324, 21)
        Me.txbHOFailureReason.TabIndex = 2
        '
        'rdbHOOK
        '
        Me.rdbHOOK.AutoSize = True
        Me.rdbHOOK.Location = New System.Drawing.Point(3, 5)
        Me.rdbHOOK.Name = "rdbHOOK"
        Me.rdbHOOK.Size = New System.Drawing.Size(65, 16)
        Me.rdbHOOK.TabIndex = 0
        Me.rdbHOOK.TabStop = True
        Me.rdbHOOK.Text = "通过 &OK"
        Me.rdbHOOK.UseVisualStyleBackColor = True
        '
        'rdbHOFailure
        '
        Me.rdbHOFailure.AutoSize = True
        Me.rdbHOFailure.Location = New System.Drawing.Point(71, 5)
        Me.rdbHOFailure.Name = "rdbHOFailure"
        Me.rdbHOFailure.Size = New System.Drawing.Size(155, 16)
        Me.rdbHOFailure.TabIndex = 1
        Me.rdbHOFailure.TabStop = True
        Me.rdbHOFailure.Text = "失败 &Failure, reason: "
        Me.rdbHOFailure.UseVisualStyleBackColor = True
        '
        'lblHOEnglishRemarks
        '
        Me.lblHOEnglishRemarks.AutoSize = True
        Me.lblHOEnglishRemarks.Location = New System.Drawing.Point(99, 60)
        Me.lblHOEnglishRemarks.Name = "lblHOEnglishRemarks"
        Me.lblHOEnglishRemarks.Size = New System.Drawing.Size(509, 12)
        Me.lblHOEnglishRemarks.TabIndex = 4
        Me.lblHOEnglishRemarks.Text = "The contract is already pass the first level validation, so you can validate it n" & _
            "ow."
        Me.lblHOEnglishRemarks.Visible = False
        '
        'lblHOChineseRemarks
        '
        Me.lblHOChineseRemarks.AutoSize = True
        Me.lblHOChineseRemarks.Location = New System.Drawing.Point(99, 47)
        Me.lblHOChineseRemarks.Name = "lblHOChineseRemarks"
        Me.lblHOChineseRemarks.Size = New System.Drawing.Size(665, 12)
        Me.lblHOChineseRemarks.TabIndex = 3
        Me.lblHOChineseRemarks.Text = "此合同包含多家公司，通过初次审核后，还需要通过总部的进一步审核。目前该合同已经通过初次审核，可以进行再次审核。"
        Me.lblHOChineseRemarks.Visible = False
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.ForeColor = System.Drawing.Color.Blue
        Me.Label65.Location = New System.Drawing.Point(10, 44)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(83, 12)
        Me.Label65.TabIndex = 2
        Me.Label65.Text = "备注 Remarks:"
        Me.Label65.Visible = False
        '
        'GroupBox7
        '
        Me.GroupBox7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox7.Enabled = False
        Me.GroupBox7.Location = New System.Drawing.Point(-10, 2)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(840, 4)
        Me.GroupBox7.TabIndex = 4
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "GroupBox4"
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.ForeColor = System.Drawing.Color.Blue
        Me.Label66.Location = New System.Drawing.Point(10, 21)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(221, 12)
        Me.Label66.TabIndex = 0
        Me.Label66.Text = "请审核合同 Please validate contract:"
        '
        'pnlStop
        '
        Me.pnlStop.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlStop.Controls.Add(Me.chbStop)
        Me.pnlStop.Controls.Add(Me.GroupBox4)
        Me.pnlStop.Controls.Add(Me.txbStoppedReason)
        Me.pnlStop.Controls.Add(Me.Label45)
        Me.pnlStop.Location = New System.Drawing.Point(0, 211)
        Me.pnlStop.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlStop.Name = "pnlStop"
        Me.pnlStop.Size = New System.Drawing.Size(794, 45)
        Me.pnlStop.TabIndex = 4
        Me.pnlStop.Visible = False
        '
        'chbStop
        '
        Me.chbStop.AutoSize = True
        Me.chbStop.Location = New System.Drawing.Point(267, 10)
        Me.chbStop.Name = "chbStop"
        Me.chbStop.Size = New System.Drawing.Size(186, 16)
        Me.chbStop.TabIndex = 1
        Me.chbStop.Text = "停用 Stop contract, reason:"
        Me.chbStop.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Enabled = False
        Me.GroupBox4.Location = New System.Drawing.Point(-10, 38)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(840, 4)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "GroupBox4"
        '
        'txbStoppedReason
        '
        Me.txbStoppedReason.Enabled = False
        Me.txbStoppedReason.Location = New System.Drawing.Point(454, 8)
        Me.txbStoppedReason.MaxLength = 50
        Me.txbStoppedReason.Name = "txbStoppedReason"
        Me.txbStoppedReason.Size = New System.Drawing.Size(324, 21)
        Me.txbStoppedReason.TabIndex = 2
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.ForeColor = System.Drawing.Color.Blue
        Me.Label45.Location = New System.Drawing.Point(10, 12)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(251, 12)
        Me.Label45.TabIndex = 0
        Me.Label45.Text = "如有需要可停用合同 Stop contract if need:"
        '
        'pnlFirstValidate
        '
        Me.pnlFirstValidate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlFirstValidate.Controls.Add(Me.Label60)
        Me.pnlFirstValidate.Controls.Add(Me.Label59)
        Me.pnlFirstValidate.Controls.Add(Me.Label58)
        Me.pnlFirstValidate.Controls.Add(Me.GroupBox5)
        Me.pnlFirstValidate.Controls.Add(Me.rdbFirstOK)
        Me.pnlFirstValidate.Controls.Add(Me.txbFirstFailureReason)
        Me.pnlFirstValidate.Controls.Add(Me.rdbFirstFailure)
        Me.pnlFirstValidate.Controls.Add(Me.Label46)
        Me.pnlFirstValidate.Location = New System.Drawing.Point(0, 90)
        Me.pnlFirstValidate.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlFirstValidate.Name = "pnlFirstValidate"
        Me.pnlFirstValidate.Size = New System.Drawing.Size(794, 76)
        Me.pnlFirstValidate.TabIndex = 2
        Me.pnlFirstValidate.Visible = False
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(99, 51)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(485, 12)
        Me.Label60.TabIndex = 6
        Me.Label60.Text = "The contract includes multi-companies, need HO validation after your validation."
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Location = New System.Drawing.Point(99, 38)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(389, 12)
        Me.Label59.TabIndex = 5
        Me.Label59.Text = "此合同包含多家公司，通过本次审核后，还需要通过总部的进一步审核。"
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.ForeColor = System.Drawing.Color.Blue
        Me.Label58.Location = New System.Drawing.Point(10, 38)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(83, 12)
        Me.Label58.TabIndex = 4
        Me.Label58.Text = "备注 Remarks:"
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Enabled = False
        Me.GroupBox5.Location = New System.Drawing.Point(-10, 69)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(840, 4)
        Me.GroupBox5.TabIndex = 7
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "GroupBox4"
        '
        'rdbFirstOK
        '
        Me.rdbFirstOK.AutoSize = True
        Me.rdbFirstOK.Location = New System.Drawing.Point(233, 10)
        Me.rdbFirstOK.Name = "rdbFirstOK"
        Me.rdbFirstOK.Size = New System.Drawing.Size(65, 16)
        Me.rdbFirstOK.TabIndex = 1
        Me.rdbFirstOK.TabStop = True
        Me.rdbFirstOK.Text = "通过 &OK"
        Me.rdbFirstOK.UseVisualStyleBackColor = True
        '
        'txbFirstFailureReason
        '
        Me.txbFirstFailureReason.Enabled = False
        Me.txbFirstFailureReason.Location = New System.Drawing.Point(454, 8)
        Me.txbFirstFailureReason.MaxLength = 50
        Me.txbFirstFailureReason.Name = "txbFirstFailureReason"
        Me.txbFirstFailureReason.Size = New System.Drawing.Size(324, 21)
        Me.txbFirstFailureReason.TabIndex = 3
        '
        'rdbFirstFailure
        '
        Me.rdbFirstFailure.AutoSize = True
        Me.rdbFirstFailure.Location = New System.Drawing.Point(301, 10)
        Me.rdbFirstFailure.Name = "rdbFirstFailure"
        Me.rdbFirstFailure.Size = New System.Drawing.Size(155, 16)
        Me.rdbFirstFailure.TabIndex = 2
        Me.rdbFirstFailure.TabStop = True
        Me.rdbFirstFailure.Text = "失败 &Failure, reason: "
        Me.rdbFirstFailure.UseVisualStyleBackColor = True
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.ForeColor = System.Drawing.Color.Blue
        Me.Label46.Location = New System.Drawing.Point(10, 12)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(221, 12)
        Me.Label46.TabIndex = 0
        Me.Label46.Text = "请审核合同 Please validate contract:"
        '
        'cklInvoiceItem
        '
        Me.cklInvoiceItem.CheckOnClick = True
        Me.cklInvoiceItem.FormattingEnabled = True
        Me.cklInvoiceItem.Location = New System.Drawing.Point(238, 262)
        Me.cklInvoiceItem.Name = "cklInvoiceItem"
        Me.cklInvoiceItem.Size = New System.Drawing.Size(500, 20)
        Me.cklInvoiceItem.TabIndex = 1
        Me.cklInvoiceItem.Visible = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(200, 100)
        Me.GroupBox6.TabIndex = 0
        Me.GroupBox6.TabStop = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(200, 100)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'frmContract
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(794, 566)
        Me.Controls.Add(Me.cklInvoiceItem)
        Me.Controls.Add(Me.tlpContainer)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmContract"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "创建合同 Create Contract"
        Me.flpContainer.ResumeLayout(False)
        Me.grbPartyA.ResumeLayout(False)
        Me.grbPartyA.PerformLayout()
        Me.grbPartyB.ResumeLayout(False)
        Me.grbPartyB.PerformLayout()
        Me.flpCustomer.ResumeLayout(False)
        Me.pnlInputCustomer.ResumeLayout(False)
        Me.pnlInputCustomer.PerformLayout()
        Me.pnlCustomer.ResumeLayout(False)
        Me.pnlCustomer.PerformLayout()
        Me.tlpSetMainCompany.ResumeLayout(False)
        CType(Me.dgvCustomer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.grbContractPeriod.ResumeLayout(False)
        Me.grbContractPeriod.PerformLayout()
        Me.pnlStoppedPeriod.ResumeLayout(False)
        Me.pnlStoppedPeriod.PerformLayout()
        Me.grbFaceValue.ResumeLayout(False)
        Me.grbFaceValue.PerformLayout()
        Me.grbContractAMT.ResumeLayout(False)
        Me.grbContractAMT.PerformLayout()
        Me.grbDiscountMode.ResumeLayout(False)
        Me.grbDiscountMode.PerformLayout()
        Me.grbCalculationMode.ResumeLayout(False)
        Me.grbCalculationMode.PerformLayout()
        Me.grbCalculationDate.ResumeLayout(False)
        Me.grbCalculationDate.PerformLayout()
        CType(Me.nudCalculationDay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbDetails.ResumeLayout(False)
        Me.grbDetails.PerformLayout()
        CType(Me.dgvDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbScope.ResumeLayout(False)
        Me.grbScope.PerformLayout()
        Me.grbInvoice.ResumeLayout(False)
        Me.grbInvoice.PerformLayout()
        Me.tlpInvoice.ResumeLayout(False)
        Me.tlpInvoice.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.grbOperation.ResumeLayout(False)
        Me.grbOperation.PerformLayout()
        Me.tlpOperation.ResumeLayout(False)
        Me.pnlStopInfo.ResumeLayout(False)
        Me.pnlStopInfo.PerformLayout()
        Me.pnlValidateInfo.ResumeLayout(False)
        Me.pnlValidateInfo.PerformLayout()
        Me.pnlValidateTitle.ResumeLayout(False)
        Me.pnlValidateTitle.PerformLayout()
        Me.pnlFirstValidateInfo.ResumeLayout(False)
        Me.pnlFirstValidateInfo.PerformLayout()
        Me.pnlModifyInfo.ResumeLayout(False)
        Me.pnlModifyInfo.PerformLayout()
        Me.pnlCreateInfo.ResumeLayout(False)
        Me.pnlCreateInfo.PerformLayout()
        Me.cmenuDeleteRebateRow.ResumeLayout(False)
        Me.pnlValidate.ResumeLayout(False)
        Me.pnlValidate.PerformLayout()
        Me.pnlContractState.ResumeLayout(False)
        Me.pnlContractState.PerformLayout()
        Me.pnlReason.ResumeLayout(False)
        Me.pnlReason.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tlpContainer.ResumeLayout(False)
        Me.pnlHOValidate.ResumeLayout(False)
        Me.pnlHOValidate.PerformLayout()
        Me.pnlHOValidation.ResumeLayout(False)
        Me.pnlHOValidation.PerformLayout()
        Me.pnlStop.ResumeLayout(False)
        Me.pnlStop.PerformLayout()
        Me.pnlFirstValidate.ResumeLayout(False)
        Me.pnlFirstValidate.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents flpContainer As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents theTip As System.Windows.Forms.ToolTip
    Friend WithEvents theTimer As System.Windows.Forms.Timer
    Friend WithEvents cmenuDeleteRebateRow As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents menuDeleteRebateRow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txbCustomerCode As System.Windows.Forms.TextBox
    Friend WithEvents txbContractCode As System.Windows.Forms.TextBox
    Friend WithEvents grbPartyA As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbbACompanyChineseName As System.Windows.Forms.ComboBox
    Friend WithEvents txbACompanyChineseName As System.Windows.Forms.TextBox
    Friend WithEvents txbACompanyEnglishName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txbDomiciliation As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txbBankAccount As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txbBeneficiary As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txbSignPlace As System.Windows.Forms.TextBox
    Friend WithEvents grbPartyB As System.Windows.Forms.GroupBox
    Friend WithEvents flpCustomer As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlInputCustomer As System.Windows.Forms.Panel
    Friend WithEvents txbCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents cbbCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnJoin As System.Windows.Forms.Button
    Friend WithEvents btnNewCustomer As System.Windows.Forms.Button
    Friend WithEvents btnViewCustomer As System.Windows.Forms.Button
    Friend WithEvents pnlCustomer As System.Windows.Forms.Panel
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents dgvCustomer As System.Windows.Forms.DataGridView
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txbBNoticeWays As System.Windows.Forms.TextBox
    Friend WithEvents grbFaceValue As System.Windows.Forms.GroupBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txbMinFaceValue As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txbMaxFaceValue As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents grbContractPeriod As System.Windows.Forms.GroupBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txbStartDate As System.Windows.Forms.TextBox
    Friend WithEvents txbEndDate As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents grbContractAMT As System.Windows.Forms.GroupBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txbMinAMTPerPurchase As System.Windows.Forms.TextBox
    Friend WithEvents txbMaxContractAMT As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txbMinContractAMT As System.Windows.Forms.TextBox
    Friend WithEvents txbTotalContractAMT As System.Windows.Forms.TextBox
    Friend WithEvents grbDiscountMode As System.Windows.Forms.GroupBox
    Friend WithEvents rdbDeduction As System.Windows.Forms.RadioButton
    Friend WithEvents rdbAddition As System.Windows.Forms.RadioButton
    Friend WithEvents grbCalculationMode As System.Windows.Forms.GroupBox
    Friend WithEvents rdbCalculationBySection As System.Windows.Forms.RadioButton
    Friend WithEvents rdbCalculationByTotal As System.Windows.Forms.RadioButton
    Friend WithEvents grbCalculationDate As System.Windows.Forms.GroupBox
    Friend WithEvents nudCalculationDay As System.Windows.Forms.NumericUpDown
    Friend WithEvents rdbEachPurchase As System.Windows.Forms.RadioButton
    Friend WithEvents rdbEndOfContract As System.Windows.Forms.RadioButton
    Friend WithEvents txbCalculationDay As System.Windows.Forms.TextBox
    Friend WithEvents rdbMonthly As System.Windows.Forms.RadioButton
    Friend WithEvents grbDetails As System.Windows.Forms.GroupBox
    Friend WithEvents lblAvailable As System.Windows.Forms.Label
    Friend WithEvents dgvDetails As System.Windows.Forms.DataGridView
    Friend WithEvents btnCompare As System.Windows.Forms.Button
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents grbInvoice As System.Windows.Forms.GroupBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents cbbInvoiceItem As System.Windows.Forms.ComboBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents cklInvoiceTitle As System.Windows.Forms.CheckedListBox
    Friend WithEvents tlpInvoice As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents grbOperation As System.Windows.Forms.GroupBox
    Friend WithEvents lblModifiedTime As System.Windows.Forms.Label
    Friend WithEvents lblCreatedTime As System.Windows.Forms.Label
    Friend WithEvents lblModifier As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents lblCreator As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents lblValidatedTime As System.Windows.Forms.Label
    Friend WithEvents lblAuditor As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents pnlValidate As System.Windows.Forms.Panel
    Friend WithEvents rdbOK As System.Windows.Forms.RadioButton
    Friend WithEvents txbFailureReason As System.Windows.Forms.TextBox
    Friend WithEvents rdbFailure As System.Windows.Forms.RadioButton
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents txbContratState As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSelectPrinter As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents pnlContractState As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tlpContainer As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cklInvoiceItem As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents cbbSignPlace As System.Windows.Forms.ComboBox
    Friend WithEvents btnSetMainCompany As System.Windows.Forms.Button
    Friend WithEvents tlpSetMainCompany As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents pnlReason As System.Windows.Forms.Panel
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents txbReason As System.Windows.Forms.TextBox
    Friend WithEvents pnlStop As System.Windows.Forms.Panel
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txbStoppedReason As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents chbStop As System.Windows.Forms.CheckBox
    Friend WithEvents pnlStoppedPeriod As System.Windows.Forms.Panel
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents txbEndDateStopped As System.Windows.Forms.TextBox
    Friend WithEvents txbStartDateStopped As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents txbStoppedDate As System.Windows.Forms.TextBox
    Friend WithEvents tlpOperation As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlStopInfo As System.Windows.Forms.Panel
    Friend WithEvents pnlValidateInfo As System.Windows.Forms.Panel
    Friend WithEvents pnlModifyInfo As System.Windows.Forms.Panel
    Friend WithEvents pnlCreateInfo As System.Windows.Forms.Panel
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents lblStoppedTime As System.Windows.Forms.Label
    Friend WithEvents lblStopper As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents dtpAppointedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txbAppointedDate As System.Windows.Forms.TextBox
    Friend WithEvents pnlFirstValidate As System.Windows.Forms.Panel
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbFirstOK As System.Windows.Forms.RadioButton
    Friend WithEvents txbFirstFailureReason As System.Windows.Forms.TextBox
    Friend WithEvents rdbFirstFailure As System.Windows.Forms.RadioButton
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grbScope As System.Windows.Forms.GroupBox
    Friend WithEvents rdbAllStores As System.Windows.Forms.RadioButton
    Friend WithEvents cbbAppointedStore As System.Windows.Forms.ComboBox
    Friend WithEvents rdbAppointedStore As System.Windows.Forms.RadioButton
    Friend WithEvents txbAppointedStore As System.Windows.Forms.TextBox
    Friend WithEvents pnlValidateTitle As System.Windows.Forms.Panel
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents pnlFirstValidateInfo As System.Windows.Forms.Panel
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents lblFirstValidatedTime As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents lblFirstAuditor As System.Windows.Forms.Label
    Friend WithEvents pnlHOValidate As System.Windows.Forms.Panel
    Friend WithEvents pnlHOValidation As System.Windows.Forms.Panel
    Friend WithEvents txbHOFailureReason As System.Windows.Forms.TextBox
    Friend WithEvents rdbHOOK As System.Windows.Forms.RadioButton
    Friend WithEvents rdbHOFailure As System.Windows.Forms.RadioButton
    Friend WithEvents lblHOEnglishRemarks As System.Windows.Forms.Label
    Friend WithEvents lblHOChineseRemarks As System.Windows.Forms.Label
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Label66 As System.Windows.Forms.Label
End Class

