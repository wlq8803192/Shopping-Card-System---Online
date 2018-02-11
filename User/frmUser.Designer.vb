<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUser))
        Me.grbBasic = New System.Windows.Forms.GroupBox
        Me.cbbLocation = New ShoppingCardSystem.AreaComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txbUserCode = New System.Windows.Forms.TextBox
        Me.txbAreaCode = New System.Windows.Forms.TextBox
        Me.txbLoginName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txbLocation = New System.Windows.Forms.TextBox
        Me.cbbRole = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.grbPersonal = New System.Windows.Forms.GroupBox
        Me.chbLeaved = New System.Windows.Forms.CheckBox
        Me.rtbRemarks = New System.Windows.Forms.RichTextBox
        Me.rdbFemale = New System.Windows.Forms.RadioButton
        Me.rdbMan = New System.Windows.Forms.RadioButton
        Me.Label12 = New System.Windows.Forms.Label
        Me.txbTel = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txbUserEnglishName = New System.Windows.Forms.TextBox
        Me.txbHRNumber = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txbUserChineseName = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txbJoinDate = New System.Windows.Forms.TextBox
        Me.txbLeavedDate = New System.Windows.Forms.TextBox
        Me.dtpLeavedDate = New System.Windows.Forms.DateTimePicker
        Me.dtpJoinDate = New System.Windows.Forms.DateTimePicker
        Me.grbValidation = New System.Windows.Forms.GroupBox
        Me.rdbFailure = New System.Windows.Forms.RadioButton
        Me.rdbPending = New System.Windows.Forms.RadioButton
        Me.rdbApproved = New System.Windows.Forms.RadioButton
        Me.txbFailureReason = New System.Windows.Forms.TextBox
        Me.grbState = New System.Windows.Forms.GroupBox
        Me.rdbStopped = New System.Windows.Forms.RadioButton
        Me.rdbNormal = New System.Windows.Forms.RadioButton
        Me.txbStoppedReason = New System.Windows.Forms.TextBox
        Me.trvRight = New System.Windows.Forms.TreeView
        Me.imlXP = New System.Windows.Forms.ImageList(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnResetPassword = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.grpOperation = New System.Windows.Forms.GroupBox
        Me.lblValidatedTime = New System.Windows.Forms.Label
        Me.lblModifiedTime = New System.Windows.Forms.Label
        Me.lblCreatedTime = New System.Windows.Forms.Label
        Me.lblAuditor = New System.Windows.Forms.Label
        Me.lblModifier = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.lblCreator = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.cbbBusinessType1 = New System.Windows.Forms.ComboBox
        Me.txbRole = New System.Windows.Forms.TextBox
        Me.cklBusinessType = New System.Windows.Forms.CheckedListBox
        Me.cbbBusinessType2 = New System.Windows.Forms.ComboBox
        Me.theTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.cklArea = New System.Windows.Forms.CheckedListBox
        Me.cbbArea = New System.Windows.Forms.ComboBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.grbBasic.SuspendLayout()
        Me.grbPersonal.SuspendLayout()
        Me.grbValidation.SuspendLayout()
        Me.grbState.SuspendLayout()
        Me.grpOperation.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbBasic
        '
        Me.grbBasic.Controls.Add(Me.cbbLocation)
        Me.grbBasic.Controls.Add(Me.Label16)
        Me.grbBasic.Controls.Add(Me.Label15)
        Me.grbBasic.Controls.Add(Me.Label6)
        Me.grbBasic.Controls.Add(Me.txbUserCode)
        Me.grbBasic.Controls.Add(Me.txbAreaCode)
        Me.grbBasic.Controls.Add(Me.txbLoginName)
        Me.grbBasic.Controls.Add(Me.Label1)
        Me.grbBasic.Controls.Add(Me.Label2)
        Me.grbBasic.Controls.Add(Me.txbLocation)
        Me.grbBasic.Location = New System.Drawing.Point(10, 10)
        Me.grbBasic.Name = "grbBasic"
        Me.grbBasic.Size = New System.Drawing.Size(471, 77)
        Me.grbBasic.TabIndex = 0
        Me.grbBasic.TabStop = False
        Me.grbBasic.Text = "基本信息 Basic Info:"
        '
        'cbbLocation
        '
        Me.cbbLocation.FormattingEnabled = True
        Me.cbbLocation.Location = New System.Drawing.Point(80, 45)
        Me.cbbLocation.Name = "cbbLocation"
        Me.cbbLocation.Size = New System.Drawing.Size(362, 20)
        Me.cbbLocation.TabIndex = 7
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Orange
        Me.Label16.Location = New System.Drawing.Point(448, 49)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(12, 12)
        Me.Label16.TabIndex = 9
        Me.Label16.Text = "*"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Orange
        Me.Label15.Location = New System.Drawing.Point(448, 23)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(12, 12)
        Me.Label15.TabIndex = 8
        Me.Label15.Text = "*"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 12)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "&Location:"
        '
        'txbUserCode
        '
        Me.txbUserCode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbUserCode.Location = New System.Drawing.Point(117, 18)
        Me.txbUserCode.MaxLength = 4
        Me.txbUserCode.Name = "txbUserCode"
        Me.txbUserCode.ReadOnly = True
        Me.txbUserCode.Size = New System.Drawing.Size(30, 21)
        Me.txbUserCode.TabIndex = 4
        '
        'txbAreaCode
        '
        Me.txbAreaCode.Location = New System.Drawing.Point(81, 18)
        Me.txbAreaCode.Name = "txbAreaCode"
        Me.txbAreaCode.ReadOnly = True
        Me.txbAreaCode.Size = New System.Drawing.Size(30, 21)
        Me.txbAreaCode.TabIndex = 3
        '
        'txbLoginName
        '
        Me.txbLoginName.Location = New System.Drawing.Point(270, 18)
        Me.txbLoginName.MaxLength = 50
        Me.txbLoginName.Name = "txbLoginName"
        Me.txbLoginName.Size = New System.Drawing.Size(172, 21)
        Me.txbLoginName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "编号 Code:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(153, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "登录名 Login &Name:"
        '
        'txbLocation
        '
        Me.txbLocation.Location = New System.Drawing.Point(81, 45)
        Me.txbLocation.Name = "txbLocation"
        Me.txbLocation.ReadOnly = True
        Me.txbLocation.Size = New System.Drawing.Size(361, 21)
        Me.txbLocation.TabIndex = 6
        Me.txbLocation.Visible = False
        '
        'cbbRole
        '
        Me.cbbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbRole.Location = New System.Drawing.Point(584, 9)
        Me.cbbRole.MaxDropDownItems = 12
        Me.cbbRole.Name = "cbbRole"
        Me.cbbRole.Size = New System.Drawing.Size(182, 20)
        Me.cbbRole.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(493, 13)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 12)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "职位 &Position:"
        '
        'grbPersonal
        '
        Me.grbPersonal.Controls.Add(Me.chbLeaved)
        Me.grbPersonal.Controls.Add(Me.rtbRemarks)
        Me.grbPersonal.Controls.Add(Me.rdbFemale)
        Me.grbPersonal.Controls.Add(Me.rdbMan)
        Me.grbPersonal.Controls.Add(Me.Label12)
        Me.grbPersonal.Controls.Add(Me.txbTel)
        Me.grbPersonal.Controls.Add(Me.Label5)
        Me.grbPersonal.Controls.Add(Me.txbUserEnglishName)
        Me.grbPersonal.Controls.Add(Me.txbHRNumber)
        Me.grbPersonal.Controls.Add(Me.Label13)
        Me.grbPersonal.Controls.Add(Me.txbUserChineseName)
        Me.grbPersonal.Controls.Add(Me.Label8)
        Me.grbPersonal.Controls.Add(Me.Label3)
        Me.grbPersonal.Controls.Add(Me.Label11)
        Me.grbPersonal.Controls.Add(Me.Label10)
        Me.grbPersonal.Controls.Add(Me.txbJoinDate)
        Me.grbPersonal.Controls.Add(Me.txbLeavedDate)
        Me.grbPersonal.Controls.Add(Me.dtpLeavedDate)
        Me.grbPersonal.Controls.Add(Me.dtpJoinDate)
        Me.grbPersonal.Location = New System.Drawing.Point(10, 93)
        Me.grbPersonal.Name = "grbPersonal"
        Me.grbPersonal.Size = New System.Drawing.Size(471, 207)
        Me.grbPersonal.TabIndex = 1
        Me.grbPersonal.TabStop = False
        Me.grbPersonal.Text = "个人信息 Personal Info:"
        '
        'chbLeaved
        '
        Me.chbLeaved.AutoSize = True
        Me.chbLeaved.Location = New System.Drawing.Point(12, 178)
        Me.chbLeaved.Name = "chbLeaved"
        Me.chbLeaved.Size = New System.Drawing.Size(120, 16)
        Me.chbLeaved.TabIndex = 14
        Me.chbLeaved.Text = "离职 Leave Date:"
        Me.chbLeaved.UseVisualStyleBackColor = True
        '
        'rtbRemarks
        '
        Me.rtbRemarks.Location = New System.Drawing.Point(270, 33)
        Me.rtbRemarks.MaxLength = 500
        Me.rtbRemarks.Name = "rtbRemarks"
        Me.rtbRemarks.Size = New System.Drawing.Size(188, 163)
        Me.rtbRemarks.TabIndex = 18
        Me.rtbRemarks.Text = ""
        '
        'rdbFemale
        '
        Me.rdbFemale.AutoCheck = False
        Me.rdbFemale.Location = New System.Drawing.Point(147, 99)
        Me.rdbFemale.Name = "rdbFemale"
        Me.rdbFemale.Size = New System.Drawing.Size(77, 16)
        Me.rdbFemale.TabIndex = 8
        Me.rdbFemale.Text = "女 Female"
        Me.theTip.SetToolTip(Me.rdbFemale, "来自Payroll系统，不可更改。")
        Me.rdbFemale.UseVisualStyleBackColor = True
        '
        'rdbMan
        '
        Me.rdbMan.AutoCheck = False
        Me.rdbMan.Location = New System.Drawing.Point(80, 99)
        Me.rdbMan.Name = "rdbMan"
        Me.rdbMan.Size = New System.Drawing.Size(59, 16)
        Me.rdbMan.TabIndex = 7
        Me.rdbMan.Text = "男 Man"
        Me.theTip.SetToolTip(Me.rdbMan, "来自Payroll系统，不可更改。")
        Me.rdbMan.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(10, 100)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 12)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "性别 Sex:"
        '
        'txbTel
        '
        Me.txbTel.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbTel.Location = New System.Drawing.Point(147, 148)
        Me.txbTel.MaxLength = 20
        Me.txbTel.Name = "txbTel"
        Me.txbTel.Size = New System.Drawing.Size(113, 21)
        Me.txbTel.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(266, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 12)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "备注 Remarks:"
        '
        'txbUserEnglishName
        '
        Me.txbUserEnglishName.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbUserEnglishName.Location = New System.Drawing.Point(147, 72)
        Me.txbUserEnglishName.MaxLength = 20
        Me.txbUserEnglishName.Name = "txbUserEnglishName"
        Me.txbUserEnglishName.ReadOnly = True
        Me.txbUserEnglishName.Size = New System.Drawing.Size(113, 21)
        Me.txbUserEnglishName.TabIndex = 5
        Me.theTip.SetToolTip(Me.txbUserEnglishName, "来自Payroll系统，不可更改。")
        '
        'txbHRNumber
        '
        Me.txbHRNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txbHRNumber.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbHRNumber.Location = New System.Drawing.Point(147, 18)
        Me.txbHRNumber.MaxLength = 20
        Me.txbHRNumber.Name = "txbHRNumber"
        Me.txbHRNumber.Size = New System.Drawing.Size(113, 21)
        Me.txbHRNumber.TabIndex = 1
        Me.txbHRNumber.Text = " "
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(10, 151)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(113, 12)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "联系电话 Telphone:"
        '
        'txbUserChineseName
        '
        Me.txbUserChineseName.Location = New System.Drawing.Point(147, 45)
        Me.txbUserChineseName.MaxLength = 20
        Me.txbUserChineseName.Name = "txbUserChineseName"
        Me.txbUserChineseName.ReadOnly = True
        Me.txbUserChineseName.Size = New System.Drawing.Size(113, 21)
        Me.txbUserChineseName.TabIndex = 3
        Me.theTip.SetToolTip(Me.txbUserChineseName, "来自Payroll系统，不可更改。")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 125)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(119, 12)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "入职日期 Join Date:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 12)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "员工编号 HR Number:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(10, 74)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(137, 12)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "英文姓名 English Name:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 47)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(137, 12)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "中文姓名 Chinese Name:"
        '
        'txbJoinDate
        '
        Me.txbJoinDate.Location = New System.Drawing.Point(147, 121)
        Me.txbJoinDate.Name = "txbJoinDate"
        Me.txbJoinDate.ReadOnly = True
        Me.txbJoinDate.Size = New System.Drawing.Size(113, 21)
        Me.txbJoinDate.TabIndex = 11
        '
        'txbLeavedDate
        '
        Me.txbLeavedDate.Location = New System.Drawing.Point(147, 175)
        Me.txbLeavedDate.Name = "txbLeavedDate"
        Me.txbLeavedDate.ReadOnly = True
        Me.txbLeavedDate.Size = New System.Drawing.Size(113, 21)
        Me.txbLeavedDate.TabIndex = 15
        Me.txbLeavedDate.Text = "（在职）"
        '
        'dtpLeavedDate
        '
        Me.dtpLeavedDate.CustomFormat = "yyyy/MM/dd"
        Me.dtpLeavedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpLeavedDate.Location = New System.Drawing.Point(147, 175)
        Me.dtpLeavedDate.Name = "dtpLeavedDate"
        Me.dtpLeavedDate.Size = New System.Drawing.Size(113, 21)
        Me.dtpLeavedDate.TabIndex = 16
        Me.dtpLeavedDate.Visible = False
        '
        'dtpJoinDate
        '
        Me.dtpJoinDate.CustomFormat = "yyyy/MM/dd"
        Me.dtpJoinDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpJoinDate.Location = New System.Drawing.Point(147, 121)
        Me.dtpJoinDate.Name = "dtpJoinDate"
        Me.dtpJoinDate.Size = New System.Drawing.Size(113, 21)
        Me.dtpJoinDate.TabIndex = 10
        Me.dtpJoinDate.Value = New Date(2006, 1, 1, 10, 25, 0, 0)
        Me.dtpJoinDate.Visible = False
        '
        'grbValidation
        '
        Me.grbValidation.Controls.Add(Me.rdbFailure)
        Me.grbValidation.Controls.Add(Me.rdbPending)
        Me.grbValidation.Controls.Add(Me.rdbApproved)
        Me.grbValidation.Controls.Add(Me.txbFailureReason)
        Me.grbValidation.Location = New System.Drawing.Point(10, 306)
        Me.grbValidation.Name = "grbValidation"
        Me.grbValidation.Size = New System.Drawing.Size(471, 71)
        Me.grbValidation.TabIndex = 2
        Me.grbValidation.TabStop = False
        Me.grbValidation.Text = "审核状态 Validation Status:"
        '
        'rdbFailure
        '
        Me.rdbFailure.AutoSize = True
        Me.rdbFailure.Location = New System.Drawing.Point(12, 41)
        Me.rdbFailure.Name = "rdbFailure"
        Me.rdbFailure.Size = New System.Drawing.Size(149, 16)
        Me.rdbFailure.TabIndex = 2
        Me.rdbFailure.Text = "N&ot approved, reason:"
        Me.rdbFailure.UseVisualStyleBackColor = True
        '
        'rdbPending
        '
        Me.rdbPending.AutoSize = True
        Me.rdbPending.Location = New System.Drawing.Point(12, 18)
        Me.rdbPending.Name = "rdbPending"
        Me.rdbPending.Size = New System.Drawing.Size(167, 16)
        Me.rdbPending.TabIndex = 0
        Me.rdbPending.Text = "&Pending (to be approved)"
        Me.rdbPending.UseVisualStyleBackColor = True
        '
        'rdbApproved
        '
        Me.rdbApproved.AutoSize = True
        Me.rdbApproved.Checked = True
        Me.rdbApproved.Location = New System.Drawing.Point(185, 18)
        Me.rdbApproved.Name = "rdbApproved"
        Me.rdbApproved.Size = New System.Drawing.Size(71, 16)
        Me.rdbApproved.TabIndex = 1
        Me.rdbApproved.TabStop = True
        Me.rdbApproved.Text = "&Approved"
        Me.rdbApproved.UseVisualStyleBackColor = True
        '
        'txbFailureReason
        '
        Me.txbFailureReason.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txbFailureReason.Location = New System.Drawing.Point(167, 40)
        Me.txbFailureReason.MaxLength = 20
        Me.txbFailureReason.Name = "txbFailureReason"
        Me.txbFailureReason.ReadOnly = True
        Me.txbFailureReason.Size = New System.Drawing.Size(291, 21)
        Me.txbFailureReason.TabIndex = 3
        '
        'grbState
        '
        Me.grbState.Controls.Add(Me.rdbStopped)
        Me.grbState.Controls.Add(Me.rdbNormal)
        Me.grbState.Controls.Add(Me.txbStoppedReason)
        Me.grbState.Location = New System.Drawing.Point(10, 383)
        Me.grbState.Name = "grbState"
        Me.grbState.Size = New System.Drawing.Size(471, 71)
        Me.grbState.TabIndex = 3
        Me.grbState.TabStop = False
        Me.grbState.Text = "使用状态 Effective Status:"
        '
        'rdbStopped
        '
        Me.rdbStopped.AutoSize = True
        Me.rdbStopped.Location = New System.Drawing.Point(12, 42)
        Me.rdbStopped.Name = "rdbStopped"
        Me.rdbStopped.Size = New System.Drawing.Size(149, 16)
        Me.rdbStopped.TabIndex = 1
        Me.rdbStopped.Text = "停用 &Blocked, Reason:"
        Me.rdbStopped.UseVisualStyleBackColor = True
        '
        'rdbNormal
        '
        Me.rdbNormal.AutoSize = True
        Me.rdbNormal.Checked = True
        Me.rdbNormal.Location = New System.Drawing.Point(12, 18)
        Me.rdbNormal.Name = "rdbNormal"
        Me.rdbNormal.Size = New System.Drawing.Size(95, 16)
        Me.rdbNormal.TabIndex = 0
        Me.rdbNormal.TabStop = True
        Me.rdbNormal.Text = "正常 Act&ived"
        Me.rdbNormal.UseVisualStyleBackColor = True
        '
        'txbStoppedReason
        '
        Me.txbStoppedReason.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txbStoppedReason.Location = New System.Drawing.Point(167, 40)
        Me.txbStoppedReason.MaxLength = 20
        Me.txbStoppedReason.Name = "txbStoppedReason"
        Me.txbStoppedReason.ReadOnly = True
        Me.txbStoppedReason.Size = New System.Drawing.Size(291, 21)
        Me.txbStoppedReason.TabIndex = 2
        '
        'trvRight
        '
        Me.trvRight.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trvRight.BackColor = System.Drawing.SystemColors.Control
        Me.trvRight.ImageIndex = 0
        Me.trvRight.ImageList = Me.imlXP
        Me.trvRight.ItemHeight = 18
        Me.trvRight.Location = New System.Drawing.Point(495, 55)
        Me.trvRight.Name = "trvRight"
        Me.trvRight.SelectedImageIndex = 0
        Me.trvRight.Size = New System.Drawing.Size(284, 375)
        Me.trvRight.TabIndex = 9
        '
        'imlXP
        '
        Me.imlXP.ImageStream = CType(resources.GetObject("imlXP.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlXP.TransparentColor = System.Drawing.Color.Transparent
        Me.imlXP.Images.SetKeyName(0, "Object")
        Me.imlXP.Images.SetKeyName(1, "Yes")
        Me.imlXP.Images.SetKeyName(2, "No")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(493, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(149, 12)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "权限列表 Authority List:"
        '
        'btnResetPassword
        '
        Me.btnResetPassword.Location = New System.Drawing.Point(495, 531)
        Me.btnResetPassword.Name = "btnResetPassword"
        Me.btnResetPassword.Size = New System.Drawing.Size(158, 23)
        Me.btnResetPassword.TabIndex = 16
        Me.btnResetPassword.Text = "重置密码 Reset Password"
        Me.btnResetPassword.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(708, 531)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(71, 23)
        Me.btnSave.TabIndex = 17
        Me.btnSave.Text = "保存 &Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'grpOperation
        '
        Me.grpOperation.Controls.Add(Me.lblValidatedTime)
        Me.grpOperation.Controls.Add(Me.lblModifiedTime)
        Me.grpOperation.Controls.Add(Me.lblCreatedTime)
        Me.grpOperation.Controls.Add(Me.lblAuditor)
        Me.grpOperation.Controls.Add(Me.lblModifier)
        Me.grpOperation.Controls.Add(Me.Label22)
        Me.grpOperation.Controls.Add(Me.Label18)
        Me.grpOperation.Controls.Add(Me.Label21)
        Me.grpOperation.Controls.Add(Me.lblCreator)
        Me.grpOperation.Controls.Add(Me.Label17)
        Me.grpOperation.Controls.Add(Me.Label14)
        Me.grpOperation.Controls.Add(Me.Label9)
        Me.grpOperation.Location = New System.Drawing.Point(10, 460)
        Me.grpOperation.Name = "grpOperation"
        Me.grpOperation.Size = New System.Drawing.Size(471, 94)
        Me.grpOperation.TabIndex = 4
        Me.grpOperation.TabStop = False
        Me.grpOperation.Text = "操作信息 Operation Info:"
        '
        'lblValidatedTime
        '
        Me.lblValidatedTime.BackColor = System.Drawing.SystemColors.Info
        Me.lblValidatedTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblValidatedTime.Location = New System.Drawing.Point(314, 64)
        Me.lblValidatedTime.Name = "lblValidatedTime"
        Me.lblValidatedTime.Size = New System.Drawing.Size(144, 18)
        Me.lblValidatedTime.TabIndex = 11
        Me.lblValidatedTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblModifiedTime
        '
        Me.lblModifiedTime.BackColor = System.Drawing.SystemColors.Info
        Me.lblModifiedTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblModifiedTime.Location = New System.Drawing.Point(314, 42)
        Me.lblModifiedTime.Name = "lblModifiedTime"
        Me.lblModifiedTime.Size = New System.Drawing.Size(144, 18)
        Me.lblModifiedTime.TabIndex = 7
        Me.lblModifiedTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCreatedTime
        '
        Me.lblCreatedTime.BackColor = System.Drawing.SystemColors.Info
        Me.lblCreatedTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCreatedTime.Location = New System.Drawing.Point(314, 20)
        Me.lblCreatedTime.Name = "lblCreatedTime"
        Me.lblCreatedTime.Size = New System.Drawing.Size(144, 18)
        Me.lblCreatedTime.TabIndex = 3
        Me.lblCreatedTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAuditor
        '
        Me.lblAuditor.BackColor = System.Drawing.SystemColors.Info
        Me.lblAuditor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAuditor.Location = New System.Drawing.Point(67, 64)
        Me.lblAuditor.Name = "lblAuditor"
        Me.lblAuditor.Size = New System.Drawing.Size(144, 18)
        Me.lblAuditor.TabIndex = 9
        Me.lblAuditor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblModifier
        '
        Me.lblModifier.BackColor = System.Drawing.SystemColors.Info
        Me.lblModifier.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblModifier.Location = New System.Drawing.Point(67, 42)
        Me.lblModifier.Name = "lblModifier"
        Me.lblModifier.Size = New System.Drawing.Size(144, 18)
        Me.lblModifier.TabIndex = 5
        Me.lblModifier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(217, 67)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(95, 12)
        Me.Label22.TabIndex = 10
        Me.Label22.Text = "Validated Time:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(217, 45)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(89, 12)
        Me.Label18.TabIndex = 6
        Me.Label18.Text = "Modified Time:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(10, 67)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(53, 12)
        Me.Label21.TabIndex = 8
        Me.Label21.Text = "Auditor:"
        '
        'lblCreator
        '
        Me.lblCreator.BackColor = System.Drawing.SystemColors.Info
        Me.lblCreator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCreator.Location = New System.Drawing.Point(67, 20)
        Me.lblCreator.Name = "lblCreator"
        Me.lblCreator.Size = New System.Drawing.Size(144, 18)
        Me.lblCreator.TabIndex = 1
        Me.lblCreator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(10, 45)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(59, 12)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "Modifier:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(217, 23)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(83, 12)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Created Time:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 12)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Creator:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(493, 436)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(203, 12)
        Me.Label25.TabIndex = 10
        Me.Label25.Text = "可管理区域 Controllable Location:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(493, 480)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(257, 12)
        Me.Label26.TabIndex = 13
        Me.Label26.Text = "可管理商业类型 Controllable Business Type:"
        '
        'cbbBusinessType1
        '
        Me.cbbBusinessType1.IntegralHeight = False
        Me.cbbBusinessType1.Location = New System.Drawing.Point(495, 497)
        Me.cbbBusinessType1.MaxDropDownItems = 12
        Me.cbbBusinessType1.Name = "cbbBusinessType1"
        Me.cbbBusinessType1.Size = New System.Drawing.Size(271, 20)
        Me.cbbBusinessType1.TabIndex = 15
        Me.cbbBusinessType1.Visible = False
        '
        'txbRole
        '
        Me.txbRole.BackColor = System.Drawing.SystemColors.Control
        Me.txbRole.Location = New System.Drawing.Point(584, 9)
        Me.txbRole.Name = "txbRole"
        Me.txbRole.ReadOnly = True
        Me.txbRole.Size = New System.Drawing.Size(182, 21)
        Me.txbRole.TabIndex = 6
        Me.txbRole.Visible = False
        '
        'cklBusinessType
        '
        Me.cklBusinessType.FormattingEnabled = True
        Me.cklBusinessType.Location = New System.Drawing.Point(495, 477)
        Me.cklBusinessType.Name = "cklBusinessType"
        Me.cklBusinessType.Size = New System.Drawing.Size(271, 20)
        Me.cklBusinessType.TabIndex = 16
        Me.cklBusinessType.Visible = False
        '
        'cbbBusinessType2
        '
        Me.cbbBusinessType2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbBusinessType2.Items.AddRange(New Object() {"(所有商业类型 All Business Types)"})
        Me.cbbBusinessType2.Location = New System.Drawing.Point(495, 497)
        Me.cbbBusinessType2.MaxDropDownItems = 12
        Me.cbbBusinessType2.Name = "cbbBusinessType2"
        Me.cbbBusinessType2.Size = New System.Drawing.Size(271, 20)
        Me.cbbBusinessType2.TabIndex = 14
        '
        'theTip
        '
        Me.theTip.AutoPopDelay = 15000
        Me.theTip.InitialDelay = 500
        Me.theTip.ReshowDelay = 100
        '
        'cklArea
        '
        Me.cklArea.FormattingEnabled = True
        Me.cklArea.Location = New System.Drawing.Point(495, 431)
        Me.cklArea.Name = "cklArea"
        Me.cklArea.Size = New System.Drawing.Size(271, 20)
        Me.cklArea.TabIndex = 12
        Me.cklArea.Visible = False
        '
        'cbbArea
        '
        Me.cbbArea.IntegralHeight = False
        Me.cbbArea.Location = New System.Drawing.Point(495, 451)
        Me.cbbArea.MaxDropDownItems = 12
        Me.cbbArea.Name = "cbbArea"
        Me.cbbArea.Size = New System.Drawing.Size(271, 20)
        Me.cbbArea.TabIndex = 11
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Orange
        Me.Label19.Location = New System.Drawing.Point(772, 13)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(12, 12)
        Me.Label19.TabIndex = 7
        Me.Label19.Text = "*"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Orange
        Me.Label20.Location = New System.Drawing.Point(772, 454)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(12, 12)
        Me.Label20.TabIndex = 18
        Me.Label20.Text = "*"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Orange
        Me.Label23.Location = New System.Drawing.Point(772, 500)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(12, 12)
        Me.Label23.TabIndex = 18
        Me.Label23.Text = "*"
        '
        'frmUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 566)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.cklBusinessType)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.cklArea)
        Me.Controls.Add(Me.cbbArea)
        Me.Controls.Add(Me.cbbBusinessType1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnResetPassword)
        Me.Controls.Add(Me.trvRight)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.grbValidation)
        Me.Controls.Add(Me.grpOperation)
        Me.Controls.Add(Me.grbState)
        Me.Controls.Add(Me.grbPersonal)
        Me.Controls.Add(Me.grbBasic)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.cbbRole)
        Me.Controls.Add(Me.txbRole)
        Me.Controls.Add(Me.cbbBusinessType2)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUser"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "创建用户 Create User"
        Me.grbBasic.ResumeLayout(False)
        Me.grbBasic.PerformLayout()
        Me.grbPersonal.ResumeLayout(False)
        Me.grbPersonal.PerformLayout()
        Me.grbValidation.ResumeLayout(False)
        Me.grbValidation.PerformLayout()
        Me.grbState.ResumeLayout(False)
        Me.grbState.PerformLayout()
        Me.grpOperation.ResumeLayout(False)
        Me.grpOperation.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbBasic As System.Windows.Forms.GroupBox
    Friend WithEvents txbUserCode As System.Windows.Forms.TextBox
    Friend WithEvents txbAreaCode As System.Windows.Forms.TextBox
    Friend WithEvents txbLoginName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbbRole As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents grbPersonal As System.Windows.Forms.GroupBox
    Friend WithEvents rdbFemale As System.Windows.Forms.RadioButton
    Friend WithEvents rdbMan As System.Windows.Forms.RadioButton
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txbUserEnglishName As System.Windows.Forms.TextBox
    Friend WithEvents txbUserChineseName As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txbHRNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grbValidation As System.Windows.Forms.GroupBox
    Friend WithEvents rdbFailure As System.Windows.Forms.RadioButton
    Friend WithEvents rdbPending As System.Windows.Forms.RadioButton
    Friend WithEvents rdbApproved As System.Windows.Forms.RadioButton
    Friend WithEvents grbState As System.Windows.Forms.GroupBox
    Friend WithEvents rdbStopped As System.Windows.Forms.RadioButton
    Friend WithEvents rdbNormal As System.Windows.Forms.RadioButton
    Friend WithEvents trvRight As System.Windows.Forms.TreeView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents rtbRemarks As System.Windows.Forms.RichTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnResetPassword As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents imlXP As System.Windows.Forms.ImageList
    Friend WithEvents dtpJoinDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpLeavedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txbTel As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txbLeavedDate As System.Windows.Forms.TextBox
    Friend WithEvents chbLeaved As System.Windows.Forms.CheckBox
    Friend WithEvents txbFailureReason As System.Windows.Forms.TextBox
    Friend WithEvents txbStoppedReason As System.Windows.Forms.TextBox
    Friend WithEvents grpOperation As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblCreatedTime As System.Windows.Forms.Label
    Friend WithEvents lblCreator As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblValidatedTime As System.Windows.Forms.Label
    Friend WithEvents lblModifiedTime As System.Windows.Forms.Label
    Friend WithEvents lblAuditor As System.Windows.Forms.Label
    Friend WithEvents lblModifier As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cbbBusinessType1 As System.Windows.Forms.ComboBox
    Friend WithEvents txbLocation As System.Windows.Forms.TextBox
    Friend WithEvents txbRole As System.Windows.Forms.TextBox
    Friend WithEvents cklBusinessType As System.Windows.Forms.CheckedListBox
    Friend WithEvents cbbBusinessType2 As System.Windows.Forms.ComboBox
    Friend WithEvents txbJoinDate As System.Windows.Forms.TextBox
    Friend WithEvents theTip As System.Windows.Forms.ToolTip
    Friend WithEvents cklArea As System.Windows.Forms.CheckedListBox
    Friend WithEvents cbbArea As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cbbLocation As ShoppingCardSystem.AreaComboBox
End Class
