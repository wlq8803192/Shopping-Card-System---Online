<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCardSpecialOperation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCardSpecialOperation))
        Me.tlpList = New System.Windows.Forms.TableLayoutPanel
        Me.pnlAffirmGiftCardActivationCancel = New System.Windows.Forms.Panel
        Me.btnAffirmGiftCardActivationCancel = New System.Windows.Forms.Button
        Me.pnlUnchargeMKTCard = New System.Windows.Forms.Panel
        Me.btnUnchargeMKTCard = New System.Windows.Forms.Button
        Me.pnlAffirmUnchargeMKTCard = New System.Windows.Forms.Panel
        Me.btnAffirmUnchargeMKTCard = New System.Windows.Forms.Button
        Me.pnlAffirmGiftCardOfflineActivate = New System.Windows.Forms.Panel
        Me.btnAffirmGiftCardOfflineActivate = New System.Windows.Forms.Button
        Me.pnlGiftCardOfflineActivate = New System.Windows.Forms.Panel
        Me.btnGiftCardOfflineActivate = New System.Windows.Forms.Button
        Me.pnlGiftCardActivationCancel = New System.Windows.Forms.Panel
        Me.btnGiftCardActivationCancel = New System.Windows.Forms.Button
        Me.pnlResetCardPassword = New System.Windows.Forms.Panel
        Me.btnResetCardPassword = New System.Windows.Forms.Button
        Me.pnlFreezeCard = New System.Windows.Forms.Panel
        Me.btnFreezeCard = New System.Windows.Forms.Button
        Me.pnlUrgencyDeduct = New System.Windows.Forms.Panel
        Me.btnUrgencyDeduct = New System.Windows.Forms.Button
        Me.pnlChangeCard = New System.Windows.Forms.Panel
        Me.btnChangeCard = New System.Windows.Forms.Button
        Me.pnlAffirmChangeCard = New System.Windows.Forms.Panel
        Me.btnAffirmChangeCard = New System.Windows.Forms.Button
        Me.pnlUnchargeCard = New System.Windows.Forms.Panel
        Me.btnUnchargeCard = New System.Windows.Forms.Button
        Me.pnlAffirmUnchargeCard = New System.Windows.Forms.Panel
        Me.btnAffirmUnchargeCard = New System.Windows.Forms.Button
        Me.pnlRecycleCard = New System.Windows.Forms.Panel
        Me.btnRecycleCard = New System.Windows.Forms.Button
        Me.pnlAffirmRecycleCard = New System.Windows.Forms.Panel
        Me.btnAffirmRecycleCard = New System.Windows.Forms.Button
        Me.pnlCardStateQuery = New System.Windows.Forms.Panel
        Me.btnCardStateQuery = New System.Windows.Forms.Button
        Me.pnlCardStateQuery_Section = New System.Windows.Forms.Panel
        Me.btnCardStateQuery_Section = New System.Windows.Forms.Button
        Me.tlpList.SuspendLayout()
        Me.pnlAffirmGiftCardActivationCancel.SuspendLayout()
        Me.pnlUnchargeMKTCard.SuspendLayout()
        Me.pnlAffirmUnchargeMKTCard.SuspendLayout()
        Me.pnlAffirmGiftCardOfflineActivate.SuspendLayout()
        Me.pnlGiftCardOfflineActivate.SuspendLayout()
        Me.pnlGiftCardActivationCancel.SuspendLayout()
        Me.pnlResetCardPassword.SuspendLayout()
        Me.pnlFreezeCard.SuspendLayout()
        Me.pnlUrgencyDeduct.SuspendLayout()
        Me.pnlChangeCard.SuspendLayout()
        Me.pnlAffirmChangeCard.SuspendLayout()
        Me.pnlUnchargeCard.SuspendLayout()
        Me.pnlAffirmUnchargeCard.SuspendLayout()
        Me.pnlRecycleCard.SuspendLayout()
        Me.pnlAffirmRecycleCard.SuspendLayout()
        Me.pnlCardStateQuery.SuspendLayout()
        Me.pnlCardStateQuery_Section.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpList
        '
        Me.tlpList.AutoSize = True
        Me.tlpList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpList.ColumnCount = 1
        Me.tlpList.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpList.Controls.Add(Me.pnlCardStateQuery_Section, 0, 16)
        Me.tlpList.Controls.Add(Me.pnlAffirmGiftCardActivationCancel, 0, 10)
        Me.tlpList.Controls.Add(Me.pnlUnchargeMKTCard, 0, 7)
        Me.tlpList.Controls.Add(Me.pnlAffirmUnchargeMKTCard, 0, 8)
        Me.tlpList.Controls.Add(Me.pnlAffirmGiftCardOfflineActivate, 0, 12)
        Me.tlpList.Controls.Add(Me.pnlGiftCardOfflineActivate, 0, 11)
        Me.tlpList.Controls.Add(Me.pnlGiftCardActivationCancel, 0, 9)
        Me.tlpList.Controls.Add(Me.pnlResetCardPassword, 0, 0)
        Me.tlpList.Controls.Add(Me.pnlFreezeCard, 0, 1)
        Me.tlpList.Controls.Add(Me.pnlUrgencyDeduct, 0, 2)
        Me.tlpList.Controls.Add(Me.pnlChangeCard, 0, 3)
        Me.tlpList.Controls.Add(Me.pnlAffirmChangeCard, 0, 4)
        Me.tlpList.Controls.Add(Me.pnlUnchargeCard, 0, 5)
        Me.tlpList.Controls.Add(Me.pnlAffirmUnchargeCard, 0, 6)
        Me.tlpList.Controls.Add(Me.pnlRecycleCard, 0, 13)
        Me.tlpList.Controls.Add(Me.pnlAffirmRecycleCard, 0, 14)
        Me.tlpList.Controls.Add(Me.pnlCardStateQuery, 0, 15)
        Me.tlpList.Location = New System.Drawing.Point(12, 12)
        Me.tlpList.Name = "tlpList"
        Me.tlpList.RowCount = 17
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.Size = New System.Drawing.Size(406, 510)
        Me.tlpList.TabIndex = 0
        '
        'pnlAffirmGiftCardActivationCancel
        '
        Me.pnlAffirmGiftCardActivationCancel.Controls.Add(Me.btnAffirmGiftCardActivationCancel)
        Me.pnlAffirmGiftCardActivationCancel.Location = New System.Drawing.Point(0, 300)
        Me.pnlAffirmGiftCardActivationCancel.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlAffirmGiftCardActivationCancel.Name = "pnlAffirmGiftCardActivationCancel"
        Me.pnlAffirmGiftCardActivationCancel.Size = New System.Drawing.Size(406, 30)
        Me.pnlAffirmGiftCardActivationCancel.TabIndex = 10
        Me.pnlAffirmGiftCardActivationCancel.Visible = False
        '
        'btnAffirmGiftCardActivationCancel
        '
        Me.btnAffirmGiftCardActivationCancel.Location = New System.Drawing.Point(5, 3)
        Me.btnAffirmGiftCardActivationCancel.Name = "btnAffirmGiftCardActivationCancel"
        Me.btnAffirmGiftCardActivationCancel.Size = New System.Drawing.Size(398, 23)
        Me.btnAffirmGiftCardActivationCancel.TabIndex = 0
        Me.btnAffirmGiftCardActivationCancel.Text = "礼品卡激活撤销确认 G&ift Card Activation Cancellation Validation"
        Me.btnAffirmGiftCardActivationCancel.UseVisualStyleBackColor = True
        '
        'pnlUnchargeMKTCard
        '
        Me.pnlUnchargeMKTCard.Controls.Add(Me.btnUnchargeMKTCard)
        Me.pnlUnchargeMKTCard.Location = New System.Drawing.Point(0, 210)
        Me.pnlUnchargeMKTCard.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlUnchargeMKTCard.Name = "pnlUnchargeMKTCard"
        Me.pnlUnchargeMKTCard.Size = New System.Drawing.Size(406, 30)
        Me.pnlUnchargeMKTCard.TabIndex = 7
        Me.pnlUnchargeMKTCard.Visible = False
        '
        'btnUnchargeMKTCard
        '
        Me.btnUnchargeMKTCard.Location = New System.Drawing.Point(5, 3)
        Me.btnUnchargeMKTCard.Name = "btnUnchargeMKTCard"
        Me.btnUnchargeMKTCard.Size = New System.Drawing.Size(398, 23)
        Me.btnUnchargeMKTCard.TabIndex = 0
        Me.btnUnchargeMKTCard.Text = "活动卡激活撤销申请 Cancel &MKT Card Activation Requirement"
        Me.btnUnchargeMKTCard.UseVisualStyleBackColor = True
        '
        'pnlAffirmUnchargeMKTCard
        '
        Me.pnlAffirmUnchargeMKTCard.Controls.Add(Me.btnAffirmUnchargeMKTCard)
        Me.pnlAffirmUnchargeMKTCard.Location = New System.Drawing.Point(0, 240)
        Me.pnlAffirmUnchargeMKTCard.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlAffirmUnchargeMKTCard.Name = "pnlAffirmUnchargeMKTCard"
        Me.pnlAffirmUnchargeMKTCard.Size = New System.Drawing.Size(406, 30)
        Me.pnlAffirmUnchargeMKTCard.TabIndex = 8
        Me.pnlAffirmUnchargeMKTCard.Visible = False
        '
        'btnAffirmUnchargeMKTCard
        '
        Me.btnAffirmUnchargeMKTCard.Location = New System.Drawing.Point(5, 3)
        Me.btnAffirmUnchargeMKTCard.Name = "btnAffirmUnchargeMKTCard"
        Me.btnAffirmUnchargeMKTCard.Size = New System.Drawing.Size(398, 23)
        Me.btnAffirmUnchargeMKTCard.TabIndex = 0
        Me.btnAffirmUnchargeMKTCard.Text = "活动卡激活撤销确认 Cancel M&KT Card Activation Validation"
        Me.btnAffirmUnchargeMKTCard.UseVisualStyleBackColor = True
        '
        'pnlAffirmGiftCardOfflineActivate
        '
        Me.pnlAffirmGiftCardOfflineActivate.Controls.Add(Me.btnAffirmGiftCardOfflineActivate)
        Me.pnlAffirmGiftCardOfflineActivate.Location = New System.Drawing.Point(0, 360)
        Me.pnlAffirmGiftCardOfflineActivate.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlAffirmGiftCardOfflineActivate.Name = "pnlAffirmGiftCardOfflineActivate"
        Me.pnlAffirmGiftCardOfflineActivate.Size = New System.Drawing.Size(406, 30)
        Me.pnlAffirmGiftCardOfflineActivate.TabIndex = 12
        Me.pnlAffirmGiftCardOfflineActivate.Visible = False
        '
        'btnAffirmGiftCardOfflineActivate
        '
        Me.btnAffirmGiftCardOfflineActivate.Location = New System.Drawing.Point(5, 3)
        Me.btnAffirmGiftCardOfflineActivate.Name = "btnAffirmGiftCardOfflineActivate"
        Me.btnAffirmGiftCardOfflineActivate.Size = New System.Drawing.Size(398, 23)
        Me.btnAffirmGiftCardOfflineActivate.TabIndex = 0
        Me.btnAffirmGiftCardOfflineActivate.Text = "礼品卡离线激活确认 Gift Card Off-&line Activation Validation"
        Me.btnAffirmGiftCardOfflineActivate.UseVisualStyleBackColor = True
        '
        'pnlGiftCardOfflineActivate
        '
        Me.pnlGiftCardOfflineActivate.Controls.Add(Me.btnGiftCardOfflineActivate)
        Me.pnlGiftCardOfflineActivate.Location = New System.Drawing.Point(0, 330)
        Me.pnlGiftCardOfflineActivate.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlGiftCardOfflineActivate.Name = "pnlGiftCardOfflineActivate"
        Me.pnlGiftCardOfflineActivate.Size = New System.Drawing.Size(406, 30)
        Me.pnlGiftCardOfflineActivate.TabIndex = 11
        Me.pnlGiftCardOfflineActivate.Visible = False
        '
        'btnGiftCardOfflineActivate
        '
        Me.btnGiftCardOfflineActivate.Location = New System.Drawing.Point(5, 3)
        Me.btnGiftCardOfflineActivate.Name = "btnGiftCardOfflineActivate"
        Me.btnGiftCardOfflineActivate.Size = New System.Drawing.Size(398, 23)
        Me.btnGiftCardOfflineActivate.TabIndex = 0
        Me.btnGiftCardOfflineActivate.Text = "礼品卡离线激活申请 Gift Card &Off-line Activation Requirement"
        Me.btnGiftCardOfflineActivate.UseVisualStyleBackColor = True
        '
        'pnlGiftCardActivationCancel
        '
        Me.pnlGiftCardActivationCancel.Controls.Add(Me.btnGiftCardActivationCancel)
        Me.pnlGiftCardActivationCancel.Location = New System.Drawing.Point(0, 270)
        Me.pnlGiftCardActivationCancel.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlGiftCardActivationCancel.Name = "pnlGiftCardActivationCancel"
        Me.pnlGiftCardActivationCancel.Size = New System.Drawing.Size(406, 30)
        Me.pnlGiftCardActivationCancel.TabIndex = 9
        Me.pnlGiftCardActivationCancel.Visible = False
        '
        'btnGiftCardActivationCancel
        '
        Me.btnGiftCardActivationCancel.Location = New System.Drawing.Point(5, 3)
        Me.btnGiftCardActivationCancel.Name = "btnGiftCardActivationCancel"
        Me.btnGiftCardActivationCancel.Size = New System.Drawing.Size(398, 23)
        Me.btnGiftCardActivationCancel.TabIndex = 0
        Me.btnGiftCardActivationCancel.Text = "礼品卡激活撤销申请 &Gift Card Activation Cancellation Requirement"
        Me.btnGiftCardActivationCancel.UseVisualStyleBackColor = True
        '
        'pnlResetCardPassword
        '
        Me.pnlResetCardPassword.Controls.Add(Me.btnResetCardPassword)
        Me.pnlResetCardPassword.Location = New System.Drawing.Point(0, 0)
        Me.pnlResetCardPassword.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlResetCardPassword.Name = "pnlResetCardPassword"
        Me.pnlResetCardPassword.Size = New System.Drawing.Size(406, 30)
        Me.pnlResetCardPassword.TabIndex = 0
        Me.pnlResetCardPassword.Visible = False
        '
        'btnResetCardPassword
        '
        Me.btnResetCardPassword.Location = New System.Drawing.Point(5, 3)
        Me.btnResetCardPassword.Name = "btnResetCardPassword"
        Me.btnResetCardPassword.Size = New System.Drawing.Size(398, 23)
        Me.btnResetCardPassword.TabIndex = 0
        Me.btnResetCardPassword.Text = "重置/修改购物卡密码 Reset/Change Shopping Card's &Password"
        Me.btnResetCardPassword.UseVisualStyleBackColor = True
        '
        'pnlFreezeCard
        '
        Me.pnlFreezeCard.Controls.Add(Me.btnFreezeCard)
        Me.pnlFreezeCard.Location = New System.Drawing.Point(0, 30)
        Me.pnlFreezeCard.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlFreezeCard.Name = "pnlFreezeCard"
        Me.pnlFreezeCard.Size = New System.Drawing.Size(406, 30)
        Me.pnlFreezeCard.TabIndex = 1
        Me.pnlFreezeCard.Visible = False
        '
        'btnFreezeCard
        '
        Me.btnFreezeCard.Location = New System.Drawing.Point(5, 3)
        Me.btnFreezeCard.Name = "btnFreezeCard"
        Me.btnFreezeCard.Size = New System.Drawing.Size(398, 23)
        Me.btnFreezeCard.TabIndex = 0
        Me.btnFreezeCard.Text = "冻结/解冻购物卡 &Freeze/unfreeze Cards"
        Me.btnFreezeCard.UseVisualStyleBackColor = True
        '
        'pnlUrgencyDeduct
        '
        Me.pnlUrgencyDeduct.Controls.Add(Me.btnUrgencyDeduct)
        Me.pnlUrgencyDeduct.Location = New System.Drawing.Point(0, 60)
        Me.pnlUrgencyDeduct.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlUrgencyDeduct.Name = "pnlUrgencyDeduct"
        Me.pnlUrgencyDeduct.Size = New System.Drawing.Size(406, 30)
        Me.pnlUrgencyDeduct.TabIndex = 2
        Me.pnlUrgencyDeduct.Visible = False
        '
        'btnUrgencyDeduct
        '
        Me.btnUrgencyDeduct.Location = New System.Drawing.Point(5, 3)
        Me.btnUrgencyDeduct.Name = "btnUrgencyDeduct"
        Me.btnUrgencyDeduct.Size = New System.Drawing.Size(398, 23)
        Me.btnUrgencyDeduct.TabIndex = 0
        Me.btnUrgencyDeduct.Text = "购物卡紧急扣款  &Urgent Deduction"
        Me.btnUrgencyDeduct.UseVisualStyleBackColor = True
        '
        'pnlChangeCard
        '
        Me.pnlChangeCard.Controls.Add(Me.btnChangeCard)
        Me.pnlChangeCard.Location = New System.Drawing.Point(0, 90)
        Me.pnlChangeCard.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlChangeCard.Name = "pnlChangeCard"
        Me.pnlChangeCard.Size = New System.Drawing.Size(406, 30)
        Me.pnlChangeCard.TabIndex = 3
        Me.pnlChangeCard.Visible = False
        '
        'btnChangeCard
        '
        Me.btnChangeCard.Location = New System.Drawing.Point(5, 3)
        Me.btnChangeCard.Name = "btnChangeCard"
        Me.btnChangeCard.Size = New System.Drawing.Size(398, 23)
        Me.btnChangeCard.TabIndex = 0
        Me.btnChangeCard.Text = "购物卡换卡申请  &Replace Card Requirement"
        Me.btnChangeCard.UseVisualStyleBackColor = True
        '
        'pnlAffirmChangeCard
        '
        Me.pnlAffirmChangeCard.Controls.Add(Me.btnAffirmChangeCard)
        Me.pnlAffirmChangeCard.Location = New System.Drawing.Point(0, 120)
        Me.pnlAffirmChangeCard.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlAffirmChangeCard.Name = "pnlAffirmChangeCard"
        Me.pnlAffirmChangeCard.Size = New System.Drawing.Size(406, 30)
        Me.pnlAffirmChangeCard.TabIndex = 4
        Me.pnlAffirmChangeCard.Visible = False
        '
        'btnAffirmChangeCard
        '
        Me.btnAffirmChangeCard.Location = New System.Drawing.Point(5, 3)
        Me.btnAffirmChangeCard.Name = "btnAffirmChangeCard"
        Me.btnAffirmChangeCard.Size = New System.Drawing.Size(398, 23)
        Me.btnAffirmChangeCard.TabIndex = 0
        Me.btnAffirmChangeCard.Text = "购物卡换卡确认  Replace Card &Validation"
        Me.btnAffirmChangeCard.UseVisualStyleBackColor = True
        '
        'pnlUnchargeCard
        '
        Me.pnlUnchargeCard.Controls.Add(Me.btnUnchargeCard)
        Me.pnlUnchargeCard.Location = New System.Drawing.Point(0, 150)
        Me.pnlUnchargeCard.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlUnchargeCard.Name = "pnlUnchargeCard"
        Me.pnlUnchargeCard.Size = New System.Drawing.Size(406, 30)
        Me.pnlUnchargeCard.TabIndex = 5
        Me.pnlUnchargeCard.Visible = False
        '
        'btnUnchargeCard
        '
        Me.btnUnchargeCard.Location = New System.Drawing.Point(5, 3)
        Me.btnUnchargeCard.Name = "btnUnchargeCard"
        Me.btnUnchargeCard.Size = New System.Drawing.Size(398, 23)
        Me.btnUnchargeCard.TabIndex = 0
        Me.btnUnchargeCard.Text = "购物卡激活撤销申请 Canc&el Card Activation Requirement"
        Me.btnUnchargeCard.UseVisualStyleBackColor = True
        '
        'pnlAffirmUnchargeCard
        '
        Me.pnlAffirmUnchargeCard.Controls.Add(Me.btnAffirmUnchargeCard)
        Me.pnlAffirmUnchargeCard.Location = New System.Drawing.Point(0, 180)
        Me.pnlAffirmUnchargeCard.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlAffirmUnchargeCard.Name = "pnlAffirmUnchargeCard"
        Me.pnlAffirmUnchargeCard.Size = New System.Drawing.Size(406, 30)
        Me.pnlAffirmUnchargeCard.TabIndex = 6
        Me.pnlAffirmUnchargeCard.Visible = False
        '
        'btnAffirmUnchargeCard
        '
        Me.btnAffirmUnchargeCard.Location = New System.Drawing.Point(5, 3)
        Me.btnAffirmUnchargeCard.Name = "btnAffirmUnchargeCard"
        Me.btnAffirmUnchargeCard.Size = New System.Drawing.Size(398, 23)
        Me.btnAffirmUnchargeCard.TabIndex = 0
        Me.btnAffirmUnchargeCard.Text = "购物卡激活撤销确认 Ca&ncel Card Activation Validation"
        Me.btnAffirmUnchargeCard.UseVisualStyleBackColor = True
        '
        'pnlRecycleCard
        '
        Me.pnlRecycleCard.Controls.Add(Me.btnRecycleCard)
        Me.pnlRecycleCard.Location = New System.Drawing.Point(0, 390)
        Me.pnlRecycleCard.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlRecycleCard.Name = "pnlRecycleCard"
        Me.pnlRecycleCard.Size = New System.Drawing.Size(406, 30)
        Me.pnlRecycleCard.TabIndex = 13
        Me.pnlRecycleCard.Visible = False
        '
        'btnRecycleCard
        '
        Me.btnRecycleCard.Location = New System.Drawing.Point(5, 3)
        Me.btnRecycleCard.Name = "btnRecycleCard"
        Me.btnRecycleCard.Size = New System.Drawing.Size(398, 23)
        Me.btnRecycleCard.TabIndex = 0
        Me.btnRecycleCard.Text = "购物卡回收申请 Rec&ycle Card Requirement"
        Me.btnRecycleCard.UseVisualStyleBackColor = True
        '
        'pnlAffirmRecycleCard
        '
        Me.pnlAffirmRecycleCard.Controls.Add(Me.btnAffirmRecycleCard)
        Me.pnlAffirmRecycleCard.Location = New System.Drawing.Point(0, 420)
        Me.pnlAffirmRecycleCard.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlAffirmRecycleCard.Name = "pnlAffirmRecycleCard"
        Me.pnlAffirmRecycleCard.Size = New System.Drawing.Size(406, 30)
        Me.pnlAffirmRecycleCard.TabIndex = 14
        Me.pnlAffirmRecycleCard.Visible = False
        '
        'btnAffirmRecycleCard
        '
        Me.btnAffirmRecycleCard.Location = New System.Drawing.Point(5, 3)
        Me.btnAffirmRecycleCard.Name = "btnAffirmRecycleCard"
        Me.btnAffirmRecycleCard.Size = New System.Drawing.Size(398, 23)
        Me.btnAffirmRecycleCard.TabIndex = 0
        Me.btnAffirmRecycleCard.Text = "购物卡回收确认 Recy&cle Card Validation"
        Me.btnAffirmRecycleCard.UseVisualStyleBackColor = True
        '
        'pnlCardStateQuery
        '
        Me.pnlCardStateQuery.Controls.Add(Me.btnCardStateQuery)
        Me.pnlCardStateQuery.Location = New System.Drawing.Point(0, 450)
        Me.pnlCardStateQuery.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlCardStateQuery.Name = "pnlCardStateQuery"
        Me.pnlCardStateQuery.Size = New System.Drawing.Size(406, 30)
        Me.pnlCardStateQuery.TabIndex = 15
        Me.pnlCardStateQuery.Visible = False
        '
        'btnCardStateQuery
        '
        Me.btnCardStateQuery.Location = New System.Drawing.Point(5, 3)
        Me.btnCardStateQuery.Name = "btnCardStateQuery"
        Me.btnCardStateQuery.Size = New System.Drawing.Size(398, 23)
        Me.btnCardStateQuery.TabIndex = 0
        Me.btnCardStateQuery.Text = "购物卡状态及交易明细查询  Card S&tatus && Dealing Query"
        Me.btnCardStateQuery.UseVisualStyleBackColor = True
        '
        'pnlCardStateQuery_Section
        '
        Me.pnlCardStateQuery_Section.Controls.Add(Me.btnCardStateQuery_Section)
        Me.pnlCardStateQuery_Section.Location = New System.Drawing.Point(0, 480)
        Me.pnlCardStateQuery_Section.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlCardStateQuery_Section.Name = "pnlCardStateQuery_Section"
        Me.pnlCardStateQuery_Section.Size = New System.Drawing.Size(406, 30)
        Me.pnlCardStateQuery_Section.TabIndex = 17
        Me.pnlCardStateQuery_Section.Visible = False
        '
        'btnCardStateQuery_Section
        '
        Me.btnCardStateQuery_Section.Location = New System.Drawing.Point(5, 3)
        Me.btnCardStateQuery_Section.Name = "btnCardStateQuery_Section"
        Me.btnCardStateQuery_Section.Size = New System.Drawing.Size(398, 23)
        Me.btnCardStateQuery_Section.TabIndex = 0
        Me.btnCardStateQuery_Section.Text = "购物卡状态批量查询  Card St&atus Query"
        Me.btnCardStateQuery_Section.UseVisualStyleBackColor = True
        '
        'frmCardSpecialOperation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 547)
        Me.Controls.Add(Me.tlpList)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCardSpecialOperation"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "购物卡特殊操作 Card Special Operation"
        Me.tlpList.ResumeLayout(False)
        Me.pnlAffirmGiftCardActivationCancel.ResumeLayout(False)
        Me.pnlUnchargeMKTCard.ResumeLayout(False)
        Me.pnlAffirmUnchargeMKTCard.ResumeLayout(False)
        Me.pnlAffirmGiftCardOfflineActivate.ResumeLayout(False)
        Me.pnlGiftCardOfflineActivate.ResumeLayout(False)
        Me.pnlGiftCardActivationCancel.ResumeLayout(False)
        Me.pnlResetCardPassword.ResumeLayout(False)
        Me.pnlFreezeCard.ResumeLayout(False)
        Me.pnlUrgencyDeduct.ResumeLayout(False)
        Me.pnlChangeCard.ResumeLayout(False)
        Me.pnlAffirmChangeCard.ResumeLayout(False)
        Me.pnlUnchargeCard.ResumeLayout(False)
        Me.pnlAffirmUnchargeCard.ResumeLayout(False)
        Me.pnlRecycleCard.ResumeLayout(False)
        Me.pnlAffirmRecycleCard.ResumeLayout(False)
        Me.pnlCardStateQuery.ResumeLayout(False)
        Me.pnlCardStateQuery_Section.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tlpList As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnFreezeCard As System.Windows.Forms.Button
    Friend WithEvents pnlFreezeCard As System.Windows.Forms.Panel
    Friend WithEvents pnlUrgencyDeduct As System.Windows.Forms.Panel
    Friend WithEvents btnUrgencyDeduct As System.Windows.Forms.Button
    Friend WithEvents pnlChangeCard As System.Windows.Forms.Panel
    Friend WithEvents btnChangeCard As System.Windows.Forms.Button
    Friend WithEvents pnlAffirmChangeCard As System.Windows.Forms.Panel
    Friend WithEvents btnAffirmChangeCard As System.Windows.Forms.Button
    Friend WithEvents pnlUnchargeCard As System.Windows.Forms.Panel
    Friend WithEvents btnUnchargeCard As System.Windows.Forms.Button
    Friend WithEvents pnlAffirmUnchargeCard As System.Windows.Forms.Panel
    Friend WithEvents btnAffirmUnchargeCard As System.Windows.Forms.Button
    Friend WithEvents pnlRecycleCard As System.Windows.Forms.Panel
    Friend WithEvents btnRecycleCard As System.Windows.Forms.Button
    Friend WithEvents pnlAffirmRecycleCard As System.Windows.Forms.Panel
    Friend WithEvents btnAffirmRecycleCard As System.Windows.Forms.Button
    Friend WithEvents pnlCardStateQuery As System.Windows.Forms.Panel
    Friend WithEvents btnCardStateQuery As System.Windows.Forms.Button
    Friend WithEvents pnlResetCardPassword As System.Windows.Forms.Panel
    Friend WithEvents btnResetCardPassword As System.Windows.Forms.Button
    Friend WithEvents pnlGiftCardActivationCancel As System.Windows.Forms.Panel
    Friend WithEvents btnGiftCardActivationCancel As System.Windows.Forms.Button
    Friend WithEvents pnlGiftCardOfflineActivate As System.Windows.Forms.Panel
    Friend WithEvents btnGiftCardOfflineActivate As System.Windows.Forms.Button
    Friend WithEvents pnlAffirmGiftCardOfflineActivate As System.Windows.Forms.Panel
    Friend WithEvents btnAffirmGiftCardOfflineActivate As System.Windows.Forms.Button
    Friend WithEvents pnlUnchargeMKTCard As System.Windows.Forms.Panel
    Friend WithEvents btnUnchargeMKTCard As System.Windows.Forms.Button
    Friend WithEvents pnlAffirmUnchargeMKTCard As System.Windows.Forms.Panel
    Friend WithEvents btnAffirmUnchargeMKTCard As System.Windows.Forms.Button
    Friend WithEvents pnlAffirmGiftCardActivationCancel As System.Windows.Forms.Panel
    Friend WithEvents btnAffirmGiftCardActivationCancel As System.Windows.Forms.Button
    Friend WithEvents pnlCardStateQuery_Section As System.Windows.Forms.Panel
    Friend WithEvents btnCardStateQuery_Section As System.Windows.Forms.Button
End Class
