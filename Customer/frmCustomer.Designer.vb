<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCustomer))
        Me.txbInvoiceTitle = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.grbUsing = New System.Windows.Forms.GroupBox
        Me.txbReason = New System.Windows.Forms.TextBox
        Me.rdbStopped = New System.Windows.Forms.RadioButton
        Me.rdbNormal = New System.Windows.Forms.RadioButton
        Me.grbLink = New System.Windows.Forms.GroupBox
        Me.txbCityName = New System.Windows.Forms.TextBox
        Me.rtbRemarks = New System.Windows.Forms.RichTextBox
        Me.txbLinkman2 = New System.Windows.Forms.TextBox
        Me.txbLinkman1 = New System.Windows.Forms.TextBox
        Me.txbEMail2 = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txbPosition2 = New System.Windows.Forms.TextBox
        Me.txbMP2 = New System.Windows.Forms.TextBox
        Me.txbTel2 = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.txbFax = New System.Windows.Forms.TextBox
        Me.txbPostCode = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txbEMail1 = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txbCompanyAddress = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.txbPosition1 = New System.Windows.Forms.TextBox
        Me.txbMP1 = New System.Windows.Forms.TextBox
        Me.txbTel1 = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.grbBelong = New System.Windows.Forms.GroupBox
        Me.pnlOtherSalesman = New System.Windows.Forms.Panel
        Me.Label35 = New System.Windows.Forms.Label
        Me.txbOtherSalesman = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.lblBusinessType = New System.Windows.Forms.Label
        Me.cbbBusinessType = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblSalesman = New System.Windows.Forms.Label
        Me.cbbStore = New System.Windows.Forms.ComboBox
        Me.txbStore = New System.Windows.Forms.TextBox
        Me.txbBusinessType = New System.Windows.Forms.TextBox
        Me.cbbSalesman = New System.Windows.Forms.ComboBox
        Me.txbSalesman = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.grbBasic = New System.Windows.Forms.GroupBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.txbPinYinCode = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txbCustomerEnglishName = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txbCustomerCode = New System.Windows.Forms.TextBox
        Me.txbStoreCode = New System.Windows.Forms.TextBox
        Me.txbCustomerChineseName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblModifiedTime = New System.Windows.Forms.Label
        Me.lblCreatedTime = New System.Windows.Forms.Label
        Me.lblModifier = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.lblCreator = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.pnlWarning = New System.Windows.Forms.Panel
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.grbCredentials = New System.Windows.Forms.GroupBox
        Me.lblAllowNoCredentials = New System.Windows.Forms.Label
        Me.chbAllowNoCredentials = New System.Windows.Forms.CheckBox
        Me.txbCompanyCredentialsNo = New System.Windows.Forms.TextBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.cbbCompanyCredentialsType = New System.Windows.Forms.ComboBox
        Me.txbCompanyCredentialsType = New System.Windows.Forms.TextBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.theTimer = New System.Windows.Forms.Timer(Me.components)
        Me.theTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlShortKeys = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.dgvCustomerList = New System.Windows.Forms.DataGridView
        Me.pnlControls = New System.Windows.Forms.Panel
        Me.pcbClose = New System.Windows.Forms.PictureBox
        Me.pnlButtons = New System.Windows.Forms.Panel
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button9 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button10 = New System.Windows.Forms.Button
        Me.LinkLabel10 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel9 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel8 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel7 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel6 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel5 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.grbUsing.SuspendLayout()
        Me.grbLink.SuspendLayout()
        Me.grbBelong.SuspendLayout()
        Me.pnlOtherSalesman.SuspendLayout()
        Me.grbBasic.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlWarning.SuspendLayout()
        Me.grbCredentials.SuspendLayout()
        Me.pnlShortKeys.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dgvCustomerList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlControls.SuspendLayout()
        CType(Me.pcbClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'txbInvoiceTitle
        '
        Me.txbInvoiceTitle.Location = New System.Drawing.Point(314, 71)
        Me.txbInvoiceTitle.MaxLength = 100
        Me.txbInvoiceTitle.Name = "txbInvoiceTitle"
        Me.txbInvoiceTitle.ReadOnly = True
        Me.txbInvoiceTitle.Size = New System.Drawing.Size(442, 21)
        Me.txbInvoiceTitle.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(171, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(143, 12)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "发票抬头 In&voice Title:"
        '
        'grbUsing
        '
        Me.grbUsing.Controls.Add(Me.txbReason)
        Me.grbUsing.Controls.Add(Me.rdbStopped)
        Me.grbUsing.Controls.Add(Me.rdbNormal)
        Me.grbUsing.Location = New System.Drawing.Point(12, 452)
        Me.grbUsing.Name = "grbUsing"
        Me.grbUsing.Size = New System.Drawing.Size(768, 48)
        Me.grbUsing.TabIndex = 4
        Me.grbUsing.TabStop = False
        Me.grbUsing.Text = "客户状态 Customer Status："
        '
        'txbReason
        '
        Me.txbReason.Location = New System.Drawing.Point(289, 17)
        Me.txbReason.MaxLength = 50
        Me.txbReason.Name = "txbReason"
        Me.txbReason.ReadOnly = True
        Me.txbReason.Size = New System.Drawing.Size(467, 21)
        Me.txbReason.TabIndex = 2
        '
        'rdbStopped
        '
        Me.rdbStopped.AutoSize = True
        Me.rdbStopped.Location = New System.Drawing.Point(112, 20)
        Me.rdbStopped.Name = "rdbStopped"
        Me.rdbStopped.Size = New System.Drawing.Size(173, 16)
        Me.rdbStopped.TabIndex = 1
        Me.rdbStopped.Text = "停止使用 Blocked, reason:"
        Me.rdbStopped.UseVisualStyleBackColor = True
        '
        'rdbNormal
        '
        Me.rdbNormal.AutoSize = True
        Me.rdbNormal.Checked = True
        Me.rdbNormal.Location = New System.Drawing.Point(11, 20)
        Me.rdbNormal.Name = "rdbNormal"
        Me.rdbNormal.Size = New System.Drawing.Size(95, 16)
        Me.rdbNormal.TabIndex = 0
        Me.rdbNormal.TabStop = True
        Me.rdbNormal.Text = "正常 Act&ived"
        Me.rdbNormal.UseVisualStyleBackColor = True
        '
        'grbLink
        '
        Me.grbLink.Controls.Add(Me.txbCityName)
        Me.grbLink.Controls.Add(Me.rtbRemarks)
        Me.grbLink.Controls.Add(Me.txbLinkman2)
        Me.grbLink.Controls.Add(Me.txbLinkman1)
        Me.grbLink.Controls.Add(Me.txbEMail2)
        Me.grbLink.Controls.Add(Me.Label18)
        Me.grbLink.Controls.Add(Me.Label29)
        Me.grbLink.Controls.Add(Me.Label14)
        Me.grbLink.Controls.Add(Me.txbPosition2)
        Me.grbLink.Controls.Add(Me.txbMP2)
        Me.grbLink.Controls.Add(Me.txbTel2)
        Me.grbLink.Controls.Add(Me.Label17)
        Me.grbLink.Controls.Add(Me.Label16)
        Me.grbLink.Controls.Add(Me.Label15)
        Me.grbLink.Controls.Add(Me.Label20)
        Me.grbLink.Controls.Add(Me.txbFax)
        Me.grbLink.Controls.Add(Me.txbPostCode)
        Me.grbLink.Controls.Add(Me.Label19)
        Me.grbLink.Controls.Add(Me.txbEMail1)
        Me.grbLink.Controls.Add(Me.Label13)
        Me.grbLink.Controls.Add(Me.Label28)
        Me.grbLink.Controls.Add(Me.Label9)
        Me.grbLink.Controls.Add(Me.txbCompanyAddress)
        Me.grbLink.Controls.Add(Me.Label22)
        Me.grbLink.Controls.Add(Me.Label30)
        Me.grbLink.Controls.Add(Me.Label21)
        Me.grbLink.Controls.Add(Me.txbPosition1)
        Me.grbLink.Controls.Add(Me.txbMP1)
        Me.grbLink.Controls.Add(Me.txbTel1)
        Me.grbLink.Controls.Add(Me.Label12)
        Me.grbLink.Controls.Add(Me.Label11)
        Me.grbLink.Controls.Add(Me.Label10)
        Me.grbLink.Location = New System.Drawing.Point(12, 251)
        Me.grbLink.Name = "grbLink"
        Me.grbLink.Size = New System.Drawing.Size(768, 196)
        Me.grbLink.TabIndex = 3
        Me.grbLink.TabStop = False
        Me.grbLink.Text = "联系信息 Contact Info:"
        '
        'txbCityName
        '
        Me.txbCityName.Location = New System.Drawing.Point(496, 98)
        Me.txbCityName.Name = "txbCityName"
        Me.txbCityName.Size = New System.Drawing.Size(260, 21)
        Me.txbCityName.TabIndex = 25
        '
        'rtbRemarks
        '
        Me.rtbRemarks.BackColor = System.Drawing.SystemColors.Window
        Me.rtbRemarks.Location = New System.Drawing.Point(107, 151)
        Me.rtbRemarks.MaxLength = 500
        Me.rtbRemarks.Name = "rtbRemarks"
        Me.rtbRemarks.Size = New System.Drawing.Size(649, 35)
        Me.rtbRemarks.TabIndex = 29
        Me.rtbRemarks.Text = ""
        '
        'txbLinkman2
        '
        Me.txbLinkman2.Location = New System.Drawing.Point(496, 18)
        Me.txbLinkman2.MaxLength = 20
        Me.txbLinkman2.Name = "txbLinkman2"
        Me.txbLinkman2.Size = New System.Drawing.Size(98, 21)
        Me.txbLinkman2.TabIndex = 11
        '
        'txbLinkman1
        '
        Me.txbLinkman1.Location = New System.Drawing.Point(107, 17)
        Me.txbLinkman1.MaxLength = 20
        Me.txbLinkman1.Name = "txbLinkman1"
        Me.txbLinkman1.Size = New System.Drawing.Size(98, 21)
        Me.txbLinkman1.TabIndex = 1
        '
        'txbEMail2
        '
        Me.txbEMail2.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbEMail2.Location = New System.Drawing.Point(496, 72)
        Me.txbEMail2.MaxLength = 100
        Me.txbEMail2.Name = "txbEMail2"
        Me.txbEMail2.Size = New System.Drawing.Size(260, 21)
        Me.txbEMail2.TabIndex = 19
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(396, 75)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(101, 12)
        Me.Label18.TabIndex = 18
        Me.Label18.Text = "电子邮件 E-Mail:"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(452, 15)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(41, 12)
        Me.Label29.TabIndex = 10
        Me.Label29.Text = "联系人"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(396, 28)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(101, 12)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "Contact Person&2:"
        '
        'txbPosition2
        '
        Me.txbPosition2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txbPosition2.Location = New System.Drawing.Point(657, 17)
        Me.txbPosition2.MaxLength = 20
        Me.txbPosition2.Name = "txbPosition2"
        Me.txbPosition2.Size = New System.Drawing.Size(99, 21)
        Me.txbPosition2.TabIndex = 13
        '
        'txbMP2
        '
        Me.txbMP2.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbMP2.Location = New System.Drawing.Point(657, 45)
        Me.txbMP2.MaxLength = 20
        Me.txbMP2.Name = "txbMP2"
        Me.txbMP2.Size = New System.Drawing.Size(99, 21)
        Me.txbMP2.TabIndex = 17
        '
        'txbTel2
        '
        Me.txbTel2.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbTel2.Location = New System.Drawing.Point(496, 45)
        Me.txbTel2.MaxLength = 20
        Me.txbTel2.Name = "txbTel2"
        Me.txbTel2.Size = New System.Drawing.Size(98, 21)
        Me.txbTel2.TabIndex = 15
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(609, 49)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(47, 12)
        Me.Label17.TabIndex = 16
        Me.Label17.Text = "Mobile:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(438, 48)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 12)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "电话 Tel:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(597, 21)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(59, 12)
        Me.Label15.TabIndex = 12
        Me.Label15.Text = "Position:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(206, 101)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(59, 12)
        Me.Label20.TabIndex = 22
        Me.Label20.Text = "传真 Fax:"
        '
        'txbFax
        '
        Me.txbFax.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbFax.Location = New System.Drawing.Point(265, 98)
        Me.txbFax.MaxLength = 20
        Me.txbFax.Name = "txbFax"
        Me.txbFax.Size = New System.Drawing.Size(98, 21)
        Me.txbFax.TabIndex = 23
        '
        'txbPostCode
        '
        Me.txbPostCode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbPostCode.Location = New System.Drawing.Point(107, 98)
        Me.txbPostCode.MaxLength = 6
        Me.txbPostCode.Name = "txbPostCode"
        Me.txbPostCode.Size = New System.Drawing.Size(98, 21)
        Me.txbPostCode.TabIndex = 21
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(12, 101)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(95, 12)
        Me.Label19.TabIndex = 20
        Me.Label19.Text = "邮编 Post Co&de:"
        '
        'txbEMail1
        '
        Me.txbEMail1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbEMail1.Location = New System.Drawing.Point(107, 71)
        Me.txbEMail1.MaxLength = 100
        Me.txbEMail1.Name = "txbEMail1"
        Me.txbEMail1.Size = New System.Drawing.Size(256, 21)
        Me.txbEMail1.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(9, 75)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(101, 12)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "电子邮箱 E-Mail:"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(65, 15)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(41, 12)
        Me.Label28.TabIndex = 0
        Me.Label28.Text = "联系人"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 28)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(101, 12)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Contact Person&1:"
        '
        'txbCompanyAddress
        '
        Me.txbCompanyAddress.AcceptsReturn = True
        Me.txbCompanyAddress.Location = New System.Drawing.Point(107, 125)
        Me.txbCompanyAddress.MaxLength = 255
        Me.txbCompanyAddress.Name = "txbCompanyAddress"
        Me.txbCompanyAddress.Size = New System.Drawing.Size(649, 21)
        Me.txbCompanyAddress.TabIndex = 27
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(24, 153)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(83, 12)
        Me.Label22.TabIndex = 28
        Me.Label22.Text = "备注 &Remarks:"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(432, 101)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(65, 12)
        Me.Label30.TabIndex = 24
        Me.Label30.Text = "城市 City:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(3, 128)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(107, 12)
        Me.Label21.TabIndex = 26
        Me.Label21.Text = "公司地址 &Address:"
        '
        'txbPosition1
        '
        Me.txbPosition1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txbPosition1.Location = New System.Drawing.Point(265, 17)
        Me.txbPosition1.MaxLength = 20
        Me.txbPosition1.Name = "txbPosition1"
        Me.txbPosition1.Size = New System.Drawing.Size(98, 21)
        Me.txbPosition1.TabIndex = 3
        '
        'txbMP1
        '
        Me.txbMP1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbMP1.Location = New System.Drawing.Point(265, 44)
        Me.txbMP1.MaxLength = 20
        Me.txbMP1.Name = "txbMP1"
        Me.txbMP1.Size = New System.Drawing.Size(98, 21)
        Me.txbMP1.TabIndex = 7
        '
        'txbTel1
        '
        Me.txbTel1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbTel1.Location = New System.Drawing.Point(107, 44)
        Me.txbTel1.MaxLength = 20
        Me.txbTel1.Name = "txbTel1"
        Me.txbTel1.Size = New System.Drawing.Size(98, 21)
        Me.txbTel1.TabIndex = 5
        Me.txbTel1.Tag = ""
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(218, 48)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(47, 12)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Mobile:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(48, 48)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 12)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "电话 Tel:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(206, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 12)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Position:"
        '
        'grbBelong
        '
        Me.grbBelong.Controls.Add(Me.pnlOtherSalesman)
        Me.grbBelong.Controls.Add(Me.Label34)
        Me.grbBelong.Controls.Add(Me.Label33)
        Me.grbBelong.Controls.Add(Me.Label32)
        Me.grbBelong.Controls.Add(Me.lblBusinessType)
        Me.grbBelong.Controls.Add(Me.cbbBusinessType)
        Me.grbBelong.Controls.Add(Me.Label8)
        Me.grbBelong.Controls.Add(Me.Label7)
        Me.grbBelong.Controls.Add(Me.Label6)
        Me.grbBelong.Controls.Add(Me.lblSalesman)
        Me.grbBelong.Controls.Add(Me.cbbStore)
        Me.grbBelong.Controls.Add(Me.txbStore)
        Me.grbBelong.Controls.Add(Me.txbBusinessType)
        Me.grbBelong.Controls.Add(Me.cbbSalesman)
        Me.grbBelong.Controls.Add(Me.txbSalesman)
        Me.grbBelong.Controls.Add(Me.Label27)
        Me.grbBelong.Location = New System.Drawing.Point(12, 120)
        Me.grbBelong.Name = "grbBelong"
        Me.grbBelong.Size = New System.Drawing.Size(768, 73)
        Me.grbBelong.TabIndex = 1
        Me.grbBelong.TabStop = False
        Me.grbBelong.Text = "客户归属 Customer Belongs to:"
        '
        'pnlOtherSalesman
        '
        Me.pnlOtherSalesman.Controls.Add(Me.Label35)
        Me.pnlOtherSalesman.Controls.Add(Me.txbOtherSalesman)
        Me.pnlOtherSalesman.Location = New System.Drawing.Point(376, 43)
        Me.pnlOtherSalesman.Name = "pnlOtherSalesman"
        Me.pnlOtherSalesman.Size = New System.Drawing.Size(380, 21)
        Me.pnlOtherSalesman.TabIndex = 12
        Me.pnlOtherSalesman.Visible = False
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(9, 5)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(107, 12)
        Me.Label35.TabIndex = 0
        Me.Label35.Text = "其他业务员 Other:"
        '
        'txbOtherSalesman
        '
        Me.txbOtherSalesman.Location = New System.Drawing.Point(120, 0)
        Me.txbOtherSalesman.MaxLength = 20
        Me.txbOtherSalesman.Name = "txbOtherSalesman"
        Me.txbOtherSalesman.Size = New System.Drawing.Size(241, 21)
        Me.txbOtherSalesman.TabIndex = 1
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Orange
        Me.Label34.Location = New System.Drawing.Point(743, 22)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(12, 12)
        Me.Label34.TabIndex = 11
        Me.Label34.Text = "*"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Orange
        Me.Label33.Location = New System.Drawing.Point(355, 46)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(12, 12)
        Me.Label33.TabIndex = 11
        Me.Label33.Text = "*"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Orange
        Me.Label32.Location = New System.Drawing.Point(355, 22)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(12, 12)
        Me.Label32.TabIndex = 11
        Me.Label32.Text = "*"
        '
        'lblBusinessType
        '
        Me.lblBusinessType.BackColor = System.Drawing.SystemColors.Window
        Me.lblBusinessType.ForeColor = System.Drawing.Color.Red
        Me.lblBusinessType.Location = New System.Drawing.Point(499, 20)
        Me.lblBusinessType.Name = "lblBusinessType"
        Me.lblBusinessType.Size = New System.Drawing.Size(219, 14)
        Me.lblBusinessType.TabIndex = 6
        Me.lblBusinessType.Text = "(没有商业类型 No Business Type!)"
        Me.lblBusinessType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBusinessType.Visible = False
        '
        'cbbBusinessType
        '
        Me.cbbBusinessType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbBusinessType.FormattingEnabled = True
        Me.cbbBusinessType.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cbbBusinessType.IntegralHeight = False
        Me.cbbBusinessType.Location = New System.Drawing.Point(496, 17)
        Me.cbbBusinessType.MaxDropDownItems = 12
        Me.cbbBusinessType.MaxLength = 2
        Me.cbbBusinessType.Name = "cbbBusinessType"
        Me.cbbBusinessType.Size = New System.Drawing.Size(241, 20)
        Me.cbbBusinessType.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 44)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 12)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "负责业务员"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(373, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(119, 12)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "类型 Business &Type:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 12)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "门店 Sto&re:"
        '
        'lblSalesman
        '
        Me.lblSalesman.AutoSize = True
        Me.lblSalesman.ForeColor = System.Drawing.Color.Red
        Me.lblSalesman.Location = New System.Drawing.Point(373, 46)
        Me.lblSalesman.Name = "lblSalesman"
        Me.lblSalesman.Size = New System.Drawing.Size(239, 12)
        Me.lblSalesman.TabIndex = 11
        Me.lblSalesman.Text = "(此业务员已无效 Salesman noneffective!)"
        Me.lblSalesman.Visible = False
        '
        'cbbStore
        '
        Me.cbbStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbStore.FormattingEnabled = True
        Me.cbbStore.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cbbStore.Location = New System.Drawing.Point(107, 17)
        Me.cbbStore.MaxDropDownItems = 12
        Me.cbbStore.MaxLength = 4
        Me.cbbStore.Name = "cbbStore"
        Me.cbbStore.Size = New System.Drawing.Size(242, 20)
        Me.cbbStore.TabIndex = 2
        '
        'txbStore
        '
        Me.txbStore.Location = New System.Drawing.Point(107, 17)
        Me.txbStore.MaxLength = 40
        Me.txbStore.Name = "txbStore"
        Me.txbStore.ReadOnly = True
        Me.txbStore.Size = New System.Drawing.Size(242, 21)
        Me.txbStore.TabIndex = 1
        Me.txbStore.Visible = False
        '
        'txbBusinessType
        '
        Me.txbBusinessType.Location = New System.Drawing.Point(496, 17)
        Me.txbBusinessType.MaxLength = 40
        Me.txbBusinessType.Name = "txbBusinessType"
        Me.txbBusinessType.ReadOnly = True
        Me.txbBusinessType.Size = New System.Drawing.Size(241, 21)
        Me.txbBusinessType.TabIndex = 4
        Me.txbBusinessType.Visible = False
        '
        'cbbSalesman
        '
        Me.cbbSalesman.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbSalesman.FormattingEnabled = True
        Me.cbbSalesman.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cbbSalesman.IntegralHeight = False
        Me.cbbSalesman.Location = New System.Drawing.Point(107, 43)
        Me.cbbSalesman.MaxDropDownItems = 12
        Me.cbbSalesman.MaxLength = 2
        Me.cbbSalesman.Name = "cbbSalesman"
        Me.cbbSalesman.Size = New System.Drawing.Size(242, 20)
        Me.cbbSalesman.TabIndex = 9
        '
        'txbSalesman
        '
        Me.txbSalesman.Location = New System.Drawing.Point(107, 43)
        Me.txbSalesman.MaxLength = 40
        Me.txbSalesman.Name = "txbSalesman"
        Me.txbSalesman.ReadOnly = True
        Me.txbSalesman.Size = New System.Drawing.Size(242, 21)
        Me.txbSalesman.TabIndex = 10
        Me.txbSalesman.Visible = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(10, 55)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(95, 12)
        Me.Label27.TabIndex = 8
        Me.Label27.Text = "Reponsible Man:"
        '
        'grbBasic
        '
        Me.grbBasic.Controls.Add(Me.Label31)
        Me.grbBasic.Controls.Add(Me.txbPinYinCode)
        Me.grbBasic.Controls.Add(Me.Label2)
        Me.grbBasic.Controls.Add(Me.txbInvoiceTitle)
        Me.grbBasic.Controls.Add(Me.Label5)
        Me.grbBasic.Controls.Add(Me.txbCustomerEnglishName)
        Me.grbBasic.Controls.Add(Me.Label4)
        Me.grbBasic.Controls.Add(Me.txbCustomerCode)
        Me.grbBasic.Controls.Add(Me.txbStoreCode)
        Me.grbBasic.Controls.Add(Me.txbCustomerChineseName)
        Me.grbBasic.Controls.Add(Me.Label1)
        Me.grbBasic.Controls.Add(Me.Label3)
        Me.grbBasic.Location = New System.Drawing.Point(12, 12)
        Me.grbBasic.Name = "grbBasic"
        Me.grbBasic.Size = New System.Drawing.Size(768, 103)
        Me.grbBasic.TabIndex = 0
        Me.grbBasic.TabStop = False
        Me.grbBasic.Text = "基本信息 Basic Info:"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Orange
        Me.Label31.Location = New System.Drawing.Point(744, 20)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(12, 12)
        Me.Label31.TabIndex = 7
        Me.Label31.Text = "*"
        '
        'txbPinYinCode
        '
        Me.txbPinYinCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txbPinYinCode.Location = New System.Drawing.Point(12, 69)
        Me.txbPinYinCode.Name = "txbPinYinCode"
        Me.txbPinYinCode.ReadOnly = True
        Me.txbPinYinCode.Size = New System.Drawing.Size(146, 21)
        Me.txbPinYinCode.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "拼音码 Pinyin Code:"
        '
        'txbCustomerEnglishName
        '
        Me.txbCustomerEnglishName.AcceptsReturn = True
        Me.txbCustomerEnglishName.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbCustomerEnglishName.Location = New System.Drawing.Point(314, 44)
        Me.txbCustomerEnglishName.MaxLength = 100
        Me.txbCustomerEnglishName.Name = "txbCustomerEnglishName"
        Me.txbCustomerEnglishName.Size = New System.Drawing.Size(442, 21)
        Me.txbCustomerEnglishName.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(171, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(137, 12)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "英文名称 En&glish Name:"
        '
        'txbCustomerCode
        '
        Me.txbCustomerCode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbCustomerCode.Location = New System.Drawing.Point(113, 17)
        Me.txbCustomerCode.MaxLength = 6
        Me.txbCustomerCode.Name = "txbCustomerCode"
        Me.txbCustomerCode.ReadOnly = True
        Me.txbCustomerCode.Size = New System.Drawing.Size(45, 21)
        Me.txbCustomerCode.TabIndex = 2
        '
        'txbStoreCode
        '
        Me.txbStoreCode.Location = New System.Drawing.Point(81, 17)
        Me.txbStoreCode.Name = "txbStoreCode"
        Me.txbStoreCode.ReadOnly = True
        Me.txbStoreCode.Size = New System.Drawing.Size(26, 21)
        Me.txbStoreCode.TabIndex = 1
        Me.txbStoreCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txbCustomerChineseName
        '
        Me.txbCustomerChineseName.Location = New System.Drawing.Point(314, 17)
        Me.txbCustomerChineseName.MaxLength = 100
        Me.txbCustomerChineseName.Name = "txbCustomerChineseName"
        Me.txbCustomerChineseName.Size = New System.Drawing.Size(423, 21)
        Me.txbCustomerChineseName.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "编号 Code:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(171, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(137, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "中文名称 C&hinese Name:"
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(697, 519)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(71, 23)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "保存 &Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblModifiedTime)
        Me.GroupBox1.Controls.Add(Me.lblCreatedTime)
        Me.GroupBox1.Controls.Add(Me.lblModifier)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.lblCreator)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 505)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(667, 46)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "操作信息 Operation Info:"
        '
        'lblModifiedTime
        '
        Me.lblModifiedTime.BackColor = System.Drawing.SystemColors.Info
        Me.lblModifiedTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblModifiedTime.Location = New System.Drawing.Point(534, 18)
        Me.lblModifiedTime.Name = "lblModifiedTime"
        Me.lblModifiedTime.Size = New System.Drawing.Size(122, 18)
        Me.lblModifiedTime.TabIndex = 7
        Me.lblModifiedTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCreatedTime
        '
        Me.lblCreatedTime.BackColor = System.Drawing.SystemColors.Info
        Me.lblCreatedTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCreatedTime.Location = New System.Drawing.Point(203, 18)
        Me.lblCreatedTime.Name = "lblCreatedTime"
        Me.lblCreatedTime.Size = New System.Drawing.Size(122, 18)
        Me.lblCreatedTime.TabIndex = 3
        Me.lblCreatedTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblModifier
        '
        Me.lblModifier.BackColor = System.Drawing.SystemColors.Info
        Me.lblModifier.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblModifier.Location = New System.Drawing.Point(392, 18)
        Me.lblModifier.Name = "lblModifier"
        Me.lblModifier.Size = New System.Drawing.Size(102, 18)
        Me.lblModifier.TabIndex = 5
        Me.lblModifier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(499, 21)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(35, 12)
        Me.Label26.TabIndex = 6
        Me.Label26.Text = "Time:"
        '
        'lblCreator
        '
        Me.lblCreator.BackColor = System.Drawing.SystemColors.Info
        Me.lblCreator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCreator.Location = New System.Drawing.Point(61, 18)
        Me.lblCreator.Name = "lblCreator"
        Me.lblCreator.Size = New System.Drawing.Size(102, 18)
        Me.lblCreator.TabIndex = 1
        Me.lblCreator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(333, 21)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(59, 12)
        Me.Label25.TabIndex = 4
        Me.Label25.Text = "Modifier:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(168, 21)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(35, 12)
        Me.Label24.TabIndex = 2
        Me.Label24.Text = "Time:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(8, 21)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(53, 12)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "Creator:"
        '
        'pnlWarning
        '
        Me.pnlWarning.BackColor = System.Drawing.SystemColors.Info
        Me.pnlWarning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlWarning.Controls.Add(Me.Label37)
        Me.pnlWarning.Controls.Add(Me.Label36)
        Me.pnlWarning.Location = New System.Drawing.Point(185, 4)
        Me.pnlWarning.Name = "pnlWarning"
        Me.pnlWarning.Size = New System.Drawing.Size(594, 22)
        Me.pnlWarning.TabIndex = 7
        Me.pnlWarning.Visible = False
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(157, 4)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(425, 12)
        Me.Label37.TabIndex = 0
        Me.Label37.Text = "客户中文名称只能由汉字及括号""（）""组成！不能包含数字、字母及其它符号！"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.ForeColor = System.Drawing.Color.Red
        Me.Label36.Location = New System.Drawing.Point(1, 4)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(161, 12)
        Me.Label36.TabIndex = 0
        Me.Label36.Text = "总部金额服务部的最新规定："
        '
        'grbCredentials
        '
        Me.grbCredentials.Controls.Add(Me.lblAllowNoCredentials)
        Me.grbCredentials.Controls.Add(Me.chbAllowNoCredentials)
        Me.grbCredentials.Controls.Add(Me.txbCompanyCredentialsNo)
        Me.grbCredentials.Controls.Add(Me.Label39)
        Me.grbCredentials.Controls.Add(Me.cbbCompanyCredentialsType)
        Me.grbCredentials.Controls.Add(Me.txbCompanyCredentialsType)
        Me.grbCredentials.Controls.Add(Me.Label38)
        Me.grbCredentials.Location = New System.Drawing.Point(12, 198)
        Me.grbCredentials.Name = "grbCredentials"
        Me.grbCredentials.Size = New System.Drawing.Size(768, 48)
        Me.grbCredentials.TabIndex = 2
        Me.grbCredentials.TabStop = False
        Me.grbCredentials.Text = "公司证件类型及号码 Company Credentials Type && No.："
        '
        'lblAllowNoCredentials
        '
        Me.lblAllowNoCredentials.AutoSize = True
        Me.lblAllowNoCredentials.Location = New System.Drawing.Point(512, 21)
        Me.lblAllowNoCredentials.Name = "lblAllowNoCredentials"
        Me.lblAllowNoCredentials.Size = New System.Drawing.Size(233, 12)
        Me.lblAllowNoCredentials.TabIndex = 6
        Me.lblAllowNoCredentials.Text = "允许购卡万元以上（含）时也无需提供证件"
        Me.theTip.SetToolTip(Me.lblAllowNoCredentials, "公司客户购卡一般需要提供有效证件，但学校、医院、部队等" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "特殊机构，可能无法提供证件。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "领航店长可以决定是否允许类似机构即使购卡万元以上（含）" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "时也可不必" & _
                "提供证件。")
        '
        'chbAllowNoCredentials
        '
        Me.chbAllowNoCredentials.AutoSize = True
        Me.chbAllowNoCredentials.Location = New System.Drawing.Point(496, 20)
        Me.chbAllowNoCredentials.Name = "chbAllowNoCredentials"
        Me.chbAllowNoCredentials.Size = New System.Drawing.Size(15, 14)
        Me.chbAllowNoCredentials.TabIndex = 5
        Me.theTip.SetToolTip(Me.chbAllowNoCredentials, "公司客户购卡一般需要提供有效证件，但学校、医院、部队等" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "特殊机构，可能无法提供证件。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "领航店长可以决定是否允许类似机构即使购卡万元以上（含）" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "时也可不必" & _
                "提供证件。")
        Me.chbAllowNoCredentials.UseVisualStyleBackColor = True
        '
        'txbCompanyCredentialsNo
        '
        Me.txbCompanyCredentialsNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txbCompanyCredentialsNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbCompanyCredentialsNo.Location = New System.Drawing.Point(314, 17)
        Me.txbCompanyCredentialsNo.MaxLength = 50
        Me.txbCompanyCredentialsNo.Name = "txbCompanyCredentialsNo"
        Me.txbCompanyCredentialsNo.Size = New System.Drawing.Size(115, 21)
        Me.txbCompanyCredentialsNo.TabIndex = 4
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(231, 21)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(83, 12)
        Me.Label39.TabIndex = 3
        Me.Label39.Text = "证件号码 No.:"
        '
        'cbbCompanyCredentialsType
        '
        Me.cbbCompanyCredentialsType.FormattingEnabled = True
        Me.cbbCompanyCredentialsType.Items.AddRange(New Object() {"（没有证件）", "营业执照", "事业单位法人证书", "税务登记证", "组织机构代码证"})
        Me.cbbCompanyCredentialsType.Location = New System.Drawing.Point(107, 17)
        Me.cbbCompanyCredentialsType.MaxLength = 50
        Me.cbbCompanyCredentialsType.Name = "cbbCompanyCredentialsType"
        Me.cbbCompanyCredentialsType.Size = New System.Drawing.Size(115, 20)
        Me.cbbCompanyCredentialsType.TabIndex = 1
        '
        'txbCompanyCredentialsType
        '
        Me.txbCompanyCredentialsType.Location = New System.Drawing.Point(107, 17)
        Me.txbCompanyCredentialsType.MaxLength = 50
        Me.txbCompanyCredentialsType.Name = "txbCompanyCredentialsType"
        Me.txbCompanyCredentialsType.ReadOnly = True
        Me.txbCompanyCredentialsType.Size = New System.Drawing.Size(115, 21)
        Me.txbCompanyCredentialsType.TabIndex = 2
        Me.txbCompanyCredentialsType.Visible = False
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(10, 21)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(89, 12)
        Me.Label38.TabIndex = 0
        Me.Label38.Text = "证件类型 T&ype:"
        '
        'theTimer
        '
        Me.theTimer.Interval = 500
        '
        'theTip
        '
        Me.theTip.AutoPopDelay = 15000
        Me.theTip.InitialDelay = 500
        Me.theTip.ReshowDelay = 100
        '
        'pnlShortKeys
        '
        Me.pnlShortKeys.Controls.Add(Me.Panel3)
        Me.pnlShortKeys.Controls.Add(Me.Panel2)
        Me.pnlShortKeys.Location = New System.Drawing.Point(13, 53)
        Me.pnlShortKeys.Name = "pnlShortKeys"
        Me.pnlShortKeys.Size = New System.Drawing.Size(766, 215)
        Me.pnlShortKeys.TabIndex = 8
        Me.pnlShortKeys.Visible = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Maroon
        Me.Panel3.Controls.Add(Me.dgvCustomerList)
        Me.Panel3.Controls.Add(Me.pnlControls)
        Me.Panel3.Location = New System.Drawing.Point(-2, -2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(763, 212)
        Me.Panel3.TabIndex = 0
        '
        'dgvCustomerList
        '
        Me.dgvCustomerList.AllowUserToAddRows = False
        Me.dgvCustomerList.AllowUserToDeleteRows = False
        Me.dgvCustomerList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCustomerList.BackgroundColor = System.Drawing.Color.LightYellow
        Me.dgvCustomerList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCustomerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCustomerList.ColumnHeadersVisible = False
        Me.dgvCustomerList.Location = New System.Drawing.Point(4, 59)
        Me.dgvCustomerList.MultiSelect = False
        Me.dgvCustomerList.Name = "dgvCustomerList"
        Me.dgvCustomerList.ReadOnly = True
        Me.dgvCustomerList.RowHeadersVisible = False
        Me.dgvCustomerList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCustomerList.Size = New System.Drawing.Size(757, 150)
        Me.dgvCustomerList.TabIndex = 11
        '
        'pnlControls
        '
        Me.pnlControls.BackColor = System.Drawing.Color.LightYellow
        Me.pnlControls.Controls.Add(Me.pcbClose)
        Me.pnlControls.Controls.Add(Me.pnlButtons)
        Me.pnlControls.Controls.Add(Me.LinkLabel10)
        Me.pnlControls.Controls.Add(Me.LinkLabel9)
        Me.pnlControls.Controls.Add(Me.LinkLabel8)
        Me.pnlControls.Controls.Add(Me.LinkLabel7)
        Me.pnlControls.Controls.Add(Me.LinkLabel6)
        Me.pnlControls.Controls.Add(Me.LinkLabel5)
        Me.pnlControls.Controls.Add(Me.LinkLabel4)
        Me.pnlControls.Controls.Add(Me.LinkLabel3)
        Me.pnlControls.Controls.Add(Me.LinkLabel2)
        Me.pnlControls.Controls.Add(Me.LinkLabel1)
        Me.pnlControls.Location = New System.Drawing.Point(4, 4)
        Me.pnlControls.Name = "pnlControls"
        Me.pnlControls.Size = New System.Drawing.Size(757, 53)
        Me.pnlControls.TabIndex = 0
        '
        'pcbClose
        '
        Me.pcbClose.Image = Global.ShoppingCardSystem.My.Resources.Resources.CloseShortKeys
        Me.pcbClose.Location = New System.Drawing.Point(740, 4)
        Me.pcbClose.Name = "pcbClose"
        Me.pcbClose.Size = New System.Drawing.Size(12, 12)
        Me.pcbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pcbClose.TabIndex = 22
        Me.pcbClose.TabStop = False
        '
        'pnlButtons
        '
        Me.pnlButtons.AutoSize = True
        Me.pnlButtons.Controls.Add(Me.Button1)
        Me.pnlButtons.Controls.Add(Me.Button2)
        Me.pnlButtons.Controls.Add(Me.Button3)
        Me.pnlButtons.Controls.Add(Me.Button7)
        Me.pnlButtons.Controls.Add(Me.Button5)
        Me.pnlButtons.Controls.Add(Me.Button9)
        Me.pnlButtons.Controls.Add(Me.Button4)
        Me.pnlButtons.Controls.Add(Me.Button8)
        Me.pnlButtons.Controls.Add(Me.Button6)
        Me.pnlButtons.Controls.Add(Me.Button10)
        Me.pnlButtons.Location = New System.Drawing.Point(3, 18)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(750, 31)
        Me.pnlButtons.TabIndex = 21
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Location = New System.Drawing.Point(3, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(69, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "中国"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.Location = New System.Drawing.Point(78, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(69, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "北京"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.Control
        Me.Button3.Location = New System.Drawing.Point(153, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(69, 23)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "公司"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.SystemColors.Control
        Me.Button7.Location = New System.Drawing.Point(453, 4)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(69, 23)
        Me.Button7.TabIndex = 6
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.Control
        Me.Button5.Location = New System.Drawing.Point(303, 4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(69, 23)
        Me.Button5.TabIndex = 4
        Me.Button5.Text = "大学"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.SystemColors.Control
        Me.Button9.Location = New System.Drawing.Point(603, 4)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(69, 23)
        Me.Button9.TabIndex = 8
        Me.Button9.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.Control
        Me.Button4.Location = New System.Drawing.Point(228, 4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(69, 23)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "部队"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.SystemColors.Control
        Me.Button8.Location = New System.Drawing.Point(528, 4)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(69, 23)
        Me.Button8.TabIndex = 7
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.SystemColors.Control
        Me.Button6.Location = New System.Drawing.Point(378, 4)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(69, 23)
        Me.Button6.TabIndex = 5
        Me.Button6.Text = "<未定义>"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.SystemColors.Control
        Me.Button10.Location = New System.Drawing.Point(678, 4)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(69, 23)
        Me.Button10.TabIndex = 9
        Me.Button10.UseVisualStyleBackColor = False
        '
        'LinkLabel10
        '
        Me.LinkLabel10.AutoSize = True
        Me.LinkLabel10.Location = New System.Drawing.Point(704, 4)
        Me.LinkLabel10.Name = "LinkLabel10"
        Me.LinkLabel10.Size = New System.Drawing.Size(23, 12)
        Me.LinkLabel10.TabIndex = 20
        Me.LinkLabel10.TabStop = True
        Me.LinkLabel10.Text = "F10"
        '
        'LinkLabel9
        '
        Me.LinkLabel9.AutoSize = True
        Me.LinkLabel9.Location = New System.Drawing.Point(632, 3)
        Me.LinkLabel9.Name = "LinkLabel9"
        Me.LinkLabel9.Size = New System.Drawing.Size(17, 12)
        Me.LinkLabel9.TabIndex = 19
        Me.LinkLabel9.TabStop = True
        Me.LinkLabel9.Text = "F9"
        '
        'LinkLabel8
        '
        Me.LinkLabel8.AutoSize = True
        Me.LinkLabel8.Location = New System.Drawing.Point(557, 4)
        Me.LinkLabel8.Name = "LinkLabel8"
        Me.LinkLabel8.Size = New System.Drawing.Size(17, 12)
        Me.LinkLabel8.TabIndex = 18
        Me.LinkLabel8.TabStop = True
        Me.LinkLabel8.Text = "F8"
        '
        'LinkLabel7
        '
        Me.LinkLabel7.AutoSize = True
        Me.LinkLabel7.Location = New System.Drawing.Point(482, 4)
        Me.LinkLabel7.Name = "LinkLabel7"
        Me.LinkLabel7.Size = New System.Drawing.Size(17, 12)
        Me.LinkLabel7.TabIndex = 17
        Me.LinkLabel7.TabStop = True
        Me.LinkLabel7.Text = "F7"
        '
        'LinkLabel6
        '
        Me.LinkLabel6.AutoSize = True
        Me.LinkLabel6.Location = New System.Drawing.Point(407, 3)
        Me.LinkLabel6.Name = "LinkLabel6"
        Me.LinkLabel6.Size = New System.Drawing.Size(17, 12)
        Me.LinkLabel6.TabIndex = 16
        Me.LinkLabel6.TabStop = True
        Me.LinkLabel6.Text = "F6"
        '
        'LinkLabel5
        '
        Me.LinkLabel5.AutoSize = True
        Me.LinkLabel5.Location = New System.Drawing.Point(332, 3)
        Me.LinkLabel5.Name = "LinkLabel5"
        Me.LinkLabel5.Size = New System.Drawing.Size(17, 12)
        Me.LinkLabel5.TabIndex = 15
        Me.LinkLabel5.TabStop = True
        Me.LinkLabel5.Text = "F5"
        '
        'LinkLabel4
        '
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.Location = New System.Drawing.Point(257, 4)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(17, 12)
        Me.LinkLabel4.TabIndex = 14
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Text = "F4"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Location = New System.Drawing.Point(182, 4)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(17, 12)
        Me.LinkLabel3.TabIndex = 13
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "F3"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(107, 3)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(17, 12)
        Me.LinkLabel2.TabIndex = 12
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "F2"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(32, 4)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(17, 12)
        Me.LinkLabel1.TabIndex = 11
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "F1"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gray
        Me.Panel2.Location = New System.Drawing.Point(4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(761, 211)
        Me.Panel2.TabIndex = 0
        '
        'frmCustomer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 566)
        Me.Controls.Add(Me.pnlShortKeys)
        Me.Controls.Add(Me.grbCredentials)
        Me.Controls.Add(Me.pnlWarning)
        Me.Controls.Add(Me.grbLink)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.grbUsing)
        Me.Controls.Add(Me.grbBelong)
        Me.Controls.Add(Me.grbBasic)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCustomer"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "创建客户 Create Customer"
        Me.grbUsing.ResumeLayout(False)
        Me.grbUsing.PerformLayout()
        Me.grbLink.ResumeLayout(False)
        Me.grbLink.PerformLayout()
        Me.grbBelong.ResumeLayout(False)
        Me.grbBelong.PerformLayout()
        Me.pnlOtherSalesman.ResumeLayout(False)
        Me.pnlOtherSalesman.PerformLayout()
        Me.grbBasic.ResumeLayout(False)
        Me.grbBasic.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlWarning.ResumeLayout(False)
        Me.pnlWarning.PerformLayout()
        Me.grbCredentials.ResumeLayout(False)
        Me.grbCredentials.PerformLayout()
        Me.pnlShortKeys.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.dgvCustomerList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlControls.ResumeLayout(False)
        Me.pnlControls.PerformLayout()
        CType(Me.pcbClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txbInvoiceTitle As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents grbUsing As System.Windows.Forms.GroupBox
    Friend WithEvents rdbStopped As System.Windows.Forms.RadioButton
    Friend WithEvents rdbNormal As System.Windows.Forms.RadioButton
    Friend WithEvents grbLink As System.Windows.Forms.GroupBox
    Friend WithEvents txbEMail2 As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txbMP2 As System.Windows.Forms.TextBox
    Friend WithEvents txbTel2 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txbLinkman2 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txbFax As System.Windows.Forms.TextBox
    Friend WithEvents txbPostCode As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txbEMail1 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txbCompanyAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txbMP1 As System.Windows.Forms.TextBox
    Friend WithEvents txbTel1 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txbLinkman1 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents grbBelong As System.Windows.Forms.GroupBox
    Friend WithEvents cbbStore As System.Windows.Forms.ComboBox
    Friend WithEvents cbbBusinessType As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents grbBasic As System.Windows.Forms.GroupBox
    Friend WithEvents txbPinYinCode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txbCustomerEnglishName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txbCustomerCode As System.Windows.Forms.TextBox
    Friend WithEvents txbStoreCode As System.Windows.Forms.TextBox
    Friend WithEvents txbCustomerChineseName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rtbRemarks As System.Windows.Forms.RichTextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txbReason As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblModifiedTime As System.Windows.Forms.Label
    Friend WithEvents lblCreatedTime As System.Windows.Forms.Label
    Friend WithEvents lblModifier As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents lblCreator As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txbPosition2 As System.Windows.Forms.TextBox
    Friend WithEvents txbPosition1 As System.Windows.Forms.TextBox
    Friend WithEvents cbbSalesman As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblSalesman As System.Windows.Forms.Label
    Friend WithEvents lblBusinessType As System.Windows.Forms.Label
    Friend WithEvents txbSalesman As System.Windows.Forms.TextBox
    Friend WithEvents txbBusinessType As System.Windows.Forms.TextBox
    Friend WithEvents txbStore As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txbCityName As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents pnlOtherSalesman As System.Windows.Forms.Panel
    Friend WithEvents txbOtherSalesman As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents pnlWarning As System.Windows.Forms.Panel
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents grbCredentials As System.Windows.Forms.GroupBox
    Friend WithEvents txbCompanyCredentialsNo As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents cbbCompanyCredentialsType As System.Windows.Forms.ComboBox
    Friend WithEvents txbCompanyCredentialsType As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents chbAllowNoCredentials As System.Windows.Forms.CheckBox
    Friend WithEvents lblAllowNoCredentials As System.Windows.Forms.Label
    Friend WithEvents theTimer As System.Windows.Forms.Timer
    Friend WithEvents theTip As System.Windows.Forms.ToolTip
    Friend WithEvents pnlShortKeys As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents pnlControls As System.Windows.Forms.Panel
    Friend WithEvents pcbClose As System.Windows.Forms.PictureBox
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents LinkLabel10 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel9 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel8 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel7 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel6 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel5 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel4 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel3 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dgvCustomerList As System.Windows.Forms.DataGridView
End Class
