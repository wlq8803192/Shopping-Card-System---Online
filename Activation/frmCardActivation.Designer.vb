<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCardActivation
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCardActivation))
        Me.dgvList = New System.Windows.Forms.DataGridView
        Me.Label61 = New System.Windows.Forms.Label
        Me.lblCardTitle = New System.Windows.Forms.Label
        Me.dgvCard = New System.Windows.Forms.DataGridView
        Me.btnActivate = New System.Windows.Forms.Button
        Me.chbSelectAllCards = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.splitVertical = New System.Windows.Forms.SplitContainer
        Me.splitHorizontal = New System.Windows.Forms.SplitContainer
        Me.lklFilter = New System.Windows.Forms.LinkLabel
        Me.grbRemakrs = New System.Windows.Forms.GroupBox
        Me.rtbRemarks = New System.Windows.Forms.RichTextBox
        Me.chbDisplaySelected = New System.Windows.Forms.CheckBox
        Me.mtcSalesDate = New System.Windows.Forms.MonthCalendar
        Me.pnlSalesDate = New System.Windows.Forms.Panel
        Me.theTimer = New System.Windows.Forms.Timer(Me.components)
        Me.btnFind = New System.Windows.Forms.Button
        Me.theTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.tlpConditions = New System.Windows.Forms.TableLayoutPanel
        Me.pnlCity = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbbCity = New System.Windows.Forms.ComboBox
        Me.pnlSalesBillType = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbbSalesBillType = New System.Windows.Forms.ComboBox
        Me.pnlSalesman = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.cbbPaymentTerm = New System.Windows.Forms.ComboBox
        Me.cbbSalesman = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.pnlState = New System.Windows.Forms.Panel
        Me.lblActivationState = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.cbbActivationState = New System.Windows.Forms.ComboBox
        Me.pnlSaleDate = New System.Windows.Forms.Panel
        Me.cbbSalesDate = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.pnlStore = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbbStore = New System.Windows.Forms.ComboBox
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitVertical.Panel1.SuspendLayout()
        Me.splitVertical.Panel2.SuspendLayout()
        Me.splitVertical.SuspendLayout()
        Me.splitHorizontal.Panel1.SuspendLayout()
        Me.splitHorizontal.Panel2.SuspendLayout()
        Me.splitHorizontal.SuspendLayout()
        Me.grbRemakrs.SuspendLayout()
        Me.pnlSalesDate.SuspendLayout()
        Me.tlpConditions.SuspendLayout()
        Me.pnlCity.SuspendLayout()
        Me.pnlSalesBillType.SuspendLayout()
        Me.pnlSalesman.SuspendLayout()
        Me.pnlState.SuspendLayout()
        Me.pnlSaleDate.SuspendLayout()
        Me.pnlStore.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvList
        '
        Me.dgvList.AllowUserToAddRows = False
        Me.dgvList.AllowUserToDeleteRows = False
        Me.dgvList.AllowUserToResizeRows = False
        Me.dgvList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvList.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvList.ColumnHeadersHeight = 22
        Me.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvList.Location = New System.Drawing.Point(10, 28)
        Me.dgvList.MultiSelect = False
        Me.dgvList.Name = "dgvList"
        Me.dgvList.ReadOnly = True
        Me.dgvList.RowHeadersVisible = False
        Me.dgvList.RowTemplate.Height = 24
        Me.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvList.Size = New System.Drawing.Size(483, 382)
        Me.dgvList.TabIndex = 1
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Location = New System.Drawing.Point(9, 8)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(131, 12)
        Me.Label61.TabIndex = 0
        Me.Label61.Text = "销售单-购物卡行列表："
        '
        'lblCardTitle
        '
        Me.lblCardTitle.AutoSize = True
        Me.lblCardTitle.Location = New System.Drawing.Point(0, 9)
        Me.lblCardTitle.Name = "lblCardTitle"
        Me.lblCardTitle.Size = New System.Drawing.Size(77, 12)
        Me.lblCardTitle.TabIndex = 0
        Me.lblCardTitle.Text = "购物卡列表："
        '
        'dgvCard
        '
        Me.dgvCard.AllowUserToAddRows = False
        Me.dgvCard.AllowUserToDeleteRows = False
        Me.dgvCard.AllowUserToResizeRows = False
        Me.dgvCard.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCard.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvCard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCard.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCard.ColumnHeadersHeight = 22
        Me.dgvCard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvCard.Location = New System.Drawing.Point(4, 28)
        Me.dgvCard.MultiSelect = False
        Me.dgvCard.Name = "dgvCard"
        Me.dgvCard.ReadOnly = True
        Me.dgvCard.RowHeadersVisible = False
        Me.dgvCard.RowTemplate.Height = 24
        Me.dgvCard.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCard.Size = New System.Drawing.Size(269, 366)
        Me.dgvCard.TabIndex = 1
        '
        'btnActivate
        '
        Me.btnActivate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnActivate.AutoSize = True
        Me.btnActivate.Enabled = False
        Me.btnActivate.Font = New System.Drawing.Font("宋体", 15.0!, System.Drawing.FontStyle.Bold)
        Me.btnActivate.Location = New System.Drawing.Point(639, 9)
        Me.btnActivate.Name = "btnActivate"
        Me.btnActivate.Size = New System.Drawing.Size(136, 36)
        Me.btnActivate.TabIndex = 3
        Me.btnActivate.Text = "激活所选(&V)"
        Me.btnActivate.UseVisualStyleBackColor = True
        '
        'chbSelectAllCards
        '
        Me.chbSelectAllCards.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chbSelectAllCards.AutoCheck = False
        Me.chbSelectAllCards.AutoSize = True
        Me.chbSelectAllCards.Location = New System.Drawing.Point(214, 7)
        Me.chbSelectAllCards.Name = "chbSelectAllCards"
        Me.chbSelectAllCards.Size = New System.Drawing.Size(66, 16)
        Me.chbSelectAllCards.TabIndex = 2
        Me.chbSelectAllCards.Text = "全选(&A)"
        Me.chbSelectAllCards.ThreeState = True
        Me.chbSelectAllCards.UseVisualStyleBackColor = True
        Me.chbSelectAllCards.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(-2, 53)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(798, 4)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'splitVertical
        '
        Me.splitVertical.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.splitVertical.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.splitVertical.IsSplitterFixed = True
        Me.splitVertical.Location = New System.Drawing.Point(0, 58)
        Me.splitVertical.Name = "splitVertical"
        '
        'splitVertical.Panel1
        '
        Me.splitVertical.Panel1.Controls.Add(Me.Label61)
        Me.splitVertical.Panel1.Controls.Add(Me.dgvList)
        '
        'splitVertical.Panel2
        '
        Me.splitVertical.Panel2.Controls.Add(Me.splitHorizontal)
        Me.splitVertical.Size = New System.Drawing.Size(786, 421)
        Me.splitVertical.SplitterDistance = 497
        Me.splitVertical.TabIndex = 7
        '
        'splitHorizontal
        '
        Me.splitHorizontal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitHorizontal.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.splitHorizontal.IsSplitterFixed = True
        Me.splitHorizontal.Location = New System.Drawing.Point(0, 0)
        Me.splitHorizontal.Name = "splitHorizontal"
        Me.splitHorizontal.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitHorizontal.Panel1
        '
        Me.splitHorizontal.Panel1.Controls.Add(Me.lklFilter)
        Me.splitHorizontal.Panel1.Controls.Add(Me.lblCardTitle)
        Me.splitHorizontal.Panel1.Controls.Add(Me.chbSelectAllCards)
        Me.splitHorizontal.Panel1.Controls.Add(Me.dgvCard)
        '
        'splitHorizontal.Panel2
        '
        Me.splitHorizontal.Panel2.Controls.Add(Me.grbRemakrs)
        Me.splitHorizontal.Size = New System.Drawing.Size(285, 421)
        Me.splitHorizontal.SplitterDistance = 395
        Me.splitHorizontal.SplitterWidth = 1
        Me.splitHorizontal.TabIndex = 0
        '
        'lklFilter
        '
        Me.lklFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lklFilter.AutoSize = True
        Me.lklFilter.Location = New System.Drawing.Point(142, 8)
        Me.lklFilter.Name = "lklFilter"
        Me.lklFilter.Size = New System.Drawing.Size(65, 12)
        Me.lklFilter.TabIndex = 3
        Me.lklFilter.TabStop = True
        Me.lklFilter.Text = "打开筛选器"
        Me.theTip.SetToolTip(Me.lklFilter, "当该批卡需要进行选择性激活时使用")
        Me.lklFilter.Visible = False
        Me.lklFilter.VisitedLinkColor = System.Drawing.Color.Blue
        '
        'grbRemakrs
        '
        Me.grbRemakrs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbRemakrs.Controls.Add(Me.rtbRemarks)
        Me.grbRemakrs.Location = New System.Drawing.Point(4, 0)
        Me.grbRemakrs.Name = "grbRemakrs"
        Me.grbRemakrs.Size = New System.Drawing.Size(269, 15)
        Me.grbRemakrs.TabIndex = 0
        Me.grbRemakrs.TabStop = False
        Me.grbRemakrs.Text = "备注："
        '
        'rtbRemarks
        '
        Me.rtbRemarks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbRemarks.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbRemarks.Location = New System.Drawing.Point(8, 17)
        Me.rtbRemarks.Name = "rtbRemarks"
        Me.rtbRemarks.ReadOnly = True
        Me.rtbRemarks.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.rtbRemarks.Size = New System.Drawing.Size(251, 0)
        Me.rtbRemarks.TabIndex = 0
        Me.rtbRemarks.Text = ""
        '
        'chbDisplaySelected
        '
        Me.chbDisplaySelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chbDisplaySelected.AutoSize = True
        Me.chbDisplaySelected.Location = New System.Drawing.Point(480, 23)
        Me.chbDisplaySelected.Name = "chbDisplaySelected"
        Me.chbDisplaySelected.Size = New System.Drawing.Size(72, 16)
        Me.chbDisplaySelected.TabIndex = 1
        Me.chbDisplaySelected.Text = "显示已选"
        Me.chbDisplaySelected.UseVisualStyleBackColor = True
        Me.chbDisplaySelected.Visible = False
        '
        'mtcSalesDate
        '
        Me.mtcSalesDate.Location = New System.Drawing.Point(1, 1)
        Me.mtcSalesDate.Margin = New System.Windows.Forms.Padding(0)
        Me.mtcSalesDate.MaxSelectionCount = 1
        Me.mtcSalesDate.MinDate = New Date(2011, 1, 1, 0, 0, 0, 0)
        Me.mtcSalesDate.Name = "mtcSalesDate"
        Me.mtcSalesDate.TabIndex = 0
        '
        'pnlSalesDate
        '
        Me.pnlSalesDate.AutoSize = True
        Me.pnlSalesDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlSalesDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSalesDate.Controls.Add(Me.mtcSalesDate)
        Me.pnlSalesDate.Location = New System.Drawing.Point(137, 45)
        Me.pnlSalesDate.Name = "pnlSalesDate"
        Me.pnlSalesDate.Size = New System.Drawing.Size(272, 148)
        Me.pnlSalesDate.TabIndex = 4
        Me.pnlSalesDate.Visible = False
        '
        'theTimer
        '
        '
        'btnFind
        '
        Me.btnFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFind.Location = New System.Drawing.Point(558, 17)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(75, 23)
        Me.btnFind.TabIndex = 2
        Me.btnFind.Text = "查找(&F)..."
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'theTip
        '
        Me.theTip.AutoPopDelay = 15000
        Me.theTip.InitialDelay = 500
        Me.theTip.ReshowDelay = 100
        '
        'tlpConditions
        '
        Me.tlpConditions.AutoSize = True
        Me.tlpConditions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpConditions.ColumnCount = 6
        Me.tlpConditions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpConditions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpConditions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpConditions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpConditions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpConditions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpConditions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpConditions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpConditions.Controls.Add(Me.pnlCity, 0, 0)
        Me.tlpConditions.Controls.Add(Me.pnlSalesBillType, 2, 0)
        Me.tlpConditions.Controls.Add(Me.pnlSalesman, 4, 0)
        Me.tlpConditions.Controls.Add(Me.pnlState, 5, 0)
        Me.tlpConditions.Controls.Add(Me.pnlSaleDate, 3, 0)
        Me.tlpConditions.Controls.Add(Me.pnlStore, 1, 0)
        Me.tlpConditions.Location = New System.Drawing.Point(5, 0)
        Me.tlpConditions.Name = "tlpConditions"
        Me.tlpConditions.RowCount = 1
        Me.tlpConditions.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpConditions.Size = New System.Drawing.Size(946, 54)
        Me.tlpConditions.TabIndex = 0
        '
        'pnlCity
        '
        Me.pnlCity.Controls.Add(Me.Label1)
        Me.pnlCity.Controls.Add(Me.cbbCity)
        Me.pnlCity.Location = New System.Drawing.Point(0, 0)
        Me.pnlCity.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlCity.Name = "pnlCity"
        Me.pnlCity.Size = New System.Drawing.Size(126, 54)
        Me.pnlCity.TabIndex = 0
        Me.pnlCity.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "城市(&C)："
        '
        'cbbCity
        '
        Me.cbbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbCity.FormattingEnabled = True
        Me.cbbCity.Location = New System.Drawing.Point(5, 25)
        Me.cbbCity.MaxDropDownItems = 20
        Me.cbbCity.Name = "cbbCity"
        Me.cbbCity.Size = New System.Drawing.Size(120, 20)
        Me.cbbCity.TabIndex = 3
        '
        'pnlSalesBillType
        '
        Me.pnlSalesBillType.Controls.Add(Me.Label3)
        Me.pnlSalesBillType.Controls.Add(Me.cbbSalesBillType)
        Me.pnlSalesBillType.Location = New System.Drawing.Point(252, 0)
        Me.pnlSalesBillType.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlSalesBillType.Name = "pnlSalesBillType"
        Me.pnlSalesBillType.Size = New System.Drawing.Size(126, 54)
        Me.pnlSalesBillType.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 12)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "销售单类型(&B)："
        '
        'cbbSalesBillType
        '
        Me.cbbSalesBillType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbSalesBillType.FormattingEnabled = True
        Me.cbbSalesBillType.Location = New System.Drawing.Point(5, 25)
        Me.cbbSalesBillType.MaxDropDownItems = 15
        Me.cbbSalesBillType.Name = "cbbSalesBillType"
        Me.cbbSalesBillType.Size = New System.Drawing.Size(120, 20)
        Me.cbbSalesBillType.TabIndex = 1
        '
        'pnlSalesman
        '
        Me.pnlSalesman.Controls.Add(Me.Label5)
        Me.pnlSalesman.Controls.Add(Me.cbbPaymentTerm)
        Me.pnlSalesman.Controls.Add(Me.cbbSalesman)
        Me.pnlSalesman.Controls.Add(Me.Label6)
        Me.pnlSalesman.Location = New System.Drawing.Point(504, 0)
        Me.pnlSalesman.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlSalesman.Name = "pnlSalesman"
        Me.pnlSalesman.Size = New System.Drawing.Size(252, 54)
        Me.pnlSalesman.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 12)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "售卡员(&M)："
        '
        'cbbPaymentTerm
        '
        Me.cbbPaymentTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbPaymentTerm.FormattingEnabled = True
        Me.cbbPaymentTerm.Items.AddRange(New Object() {"（所有方式）", "现金/银行卡", "现金", "银行卡", "转账/支票", "转账", "支票", "支票＋保证金", "积分兑换", "（混合付款）", "（返点卡）", "（退货卡）"})
        Me.cbbPaymentTerm.Location = New System.Drawing.Point(131, 25)
        Me.cbbPaymentTerm.MaxDropDownItems = 15
        Me.cbbPaymentTerm.Name = "cbbPaymentTerm"
        Me.cbbPaymentTerm.Size = New System.Drawing.Size(120, 20)
        Me.cbbPaymentTerm.TabIndex = 7
        '
        'cbbSalesman
        '
        Me.cbbSalesman.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbSalesman.FormattingEnabled = True
        Me.cbbSalesman.Location = New System.Drawing.Point(5, 25)
        Me.cbbSalesman.Name = "cbbSalesman"
        Me.cbbSalesman.Size = New System.Drawing.Size(120, 20)
        Me.cbbSalesman.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(129, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 12)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "付款方式:(&P)："
        '
        'pnlState
        '
        Me.pnlState.Controls.Add(Me.lblActivationState)
        Me.pnlState.Controls.Add(Me.Label7)
        Me.pnlState.Controls.Add(Me.btnRefresh)
        Me.pnlState.Controls.Add(Me.cbbActivationState)
        Me.pnlState.Location = New System.Drawing.Point(756, 0)
        Me.pnlState.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlState.Name = "pnlState"
        Me.pnlState.Size = New System.Drawing.Size(190, 54)
        Me.pnlState.TabIndex = 5
        '
        'lblActivationState
        '
        Me.lblActivationState.BackColor = System.Drawing.SystemColors.Window
        Me.lblActivationState.Location = New System.Drawing.Point(8, 28)
        Me.lblActivationState.Name = "lblActivationState"
        Me.lblActivationState.Size = New System.Drawing.Size(98, 14)
        Me.lblActivationState.TabIndex = 10
        Me.lblActivationState.Text = "所有可以激活"
        Me.lblActivationState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 12)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "激活状态(&T)："
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(131, 23)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(58, 23)
        Me.btnRefresh.TabIndex = 11
        Me.btnRefresh.Text = "刷新(&R)"
        Me.btnRefresh.UseVisualStyleBackColor = True
        Me.btnRefresh.Visible = False
        '
        'cbbActivationState
        '
        Me.cbbActivationState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbActivationState.FormattingEnabled = True
        Me.cbbActivationState.Items.AddRange(New Object() {"1. 所有可以激活", "   1) 等待激活", "   2) 部分未激活", "2. 所有未全部激活", "   1) 等待激活", "   2) 部分未激活", "   3) 不可激活", "   4) 正在激活", "   5) 部分失败", "   6) 全部失败"})
        Me.cbbActivationState.Location = New System.Drawing.Point(5, 25)
        Me.cbbActivationState.MaxDropDownItems = 20
        Me.cbbActivationState.Name = "cbbActivationState"
        Me.cbbActivationState.Size = New System.Drawing.Size(120, 20)
        Me.cbbActivationState.TabIndex = 9
        '
        'pnlSaleDate
        '
        Me.pnlSaleDate.Controls.Add(Me.cbbSalesDate)
        Me.pnlSaleDate.Controls.Add(Me.Label4)
        Me.pnlSaleDate.Location = New System.Drawing.Point(378, 0)
        Me.pnlSaleDate.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlSaleDate.Name = "pnlSaleDate"
        Me.pnlSaleDate.Size = New System.Drawing.Size(126, 54)
        Me.pnlSaleDate.TabIndex = 3
        '
        'cbbSalesDate
        '
        Me.cbbSalesDate.FormattingEnabled = True
        Me.cbbSalesDate.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cbbSalesDate.Location = New System.Drawing.Point(5, 25)
        Me.cbbSalesDate.MaxDropDownItems = 10
        Me.cbbSalesDate.Name = "cbbSalesDate"
        Me.cbbSalesDate.Size = New System.Drawing.Size(120, 20)
        Me.cbbSalesDate.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 12)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "销售日期(&D)："
        '
        'pnlStore
        '
        Me.pnlStore.Controls.Add(Me.Label2)
        Me.pnlStore.Controls.Add(Me.cbbStore)
        Me.pnlStore.Location = New System.Drawing.Point(126, 0)
        Me.pnlStore.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlStore.Name = "pnlStore"
        Me.pnlStore.Size = New System.Drawing.Size(126, 54)
        Me.pnlStore.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "门店(&S)："
        '
        'cbbStore
        '
        Me.cbbStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbStore.FormattingEnabled = True
        Me.cbbStore.Location = New System.Drawing.Point(5, 25)
        Me.cbbStore.MaxDropDownItems = 20
        Me.cbbStore.Name = "cbbStore"
        Me.cbbStore.Size = New System.Drawing.Size(120, 20)
        Me.cbbStore.TabIndex = 1
        '
        'frmCardActivation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(786, 479)
        Me.Controls.Add(Me.pnlSalesDate)
        Me.Controls.Add(Me.btnFind)
        Me.Controls.Add(Me.btnActivate)
        Me.Controls.Add(Me.chbDisplaySelected)
        Me.Controls.Add(Me.splitVertical)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tlpConditions)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCardActivation"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "购物卡激活 Card Activation"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitVertical.Panel1.ResumeLayout(False)
        Me.splitVertical.Panel1.PerformLayout()
        Me.splitVertical.Panel2.ResumeLayout(False)
        Me.splitVertical.ResumeLayout(False)
        Me.splitHorizontal.Panel1.ResumeLayout(False)
        Me.splitHorizontal.Panel1.PerformLayout()
        Me.splitHorizontal.Panel2.ResumeLayout(False)
        Me.splitHorizontal.ResumeLayout(False)
        Me.grbRemakrs.ResumeLayout(False)
        Me.pnlSalesDate.ResumeLayout(False)
        Me.tlpConditions.ResumeLayout(False)
        Me.pnlCity.ResumeLayout(False)
        Me.pnlCity.PerformLayout()
        Me.pnlSalesBillType.ResumeLayout(False)
        Me.pnlSalesBillType.PerformLayout()
        Me.pnlSalesman.ResumeLayout(False)
        Me.pnlSalesman.PerformLayout()
        Me.pnlState.ResumeLayout(False)
        Me.pnlState.PerformLayout()
        Me.pnlSaleDate.ResumeLayout(False)
        Me.pnlSaleDate.PerformLayout()
        Me.pnlStore.ResumeLayout(False)
        Me.pnlStore.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvList As System.Windows.Forms.DataGridView
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents lblCardTitle As System.Windows.Forms.Label
    Friend WithEvents dgvCard As System.Windows.Forms.DataGridView
    Friend WithEvents btnActivate As System.Windows.Forms.Button
    Friend WithEvents chbSelectAllCards As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents splitVertical As System.Windows.Forms.SplitContainer
    Friend WithEvents grbRemakrs As System.Windows.Forms.GroupBox
    Friend WithEvents rtbRemarks As System.Windows.Forms.RichTextBox
    Friend WithEvents chbDisplaySelected As System.Windows.Forms.CheckBox
    Friend WithEvents pnlSalesDate As System.Windows.Forms.Panel
    Friend WithEvents mtcSalesDate As System.Windows.Forms.MonthCalendar
    Friend WithEvents theTimer As System.Windows.Forms.Timer
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents lklFilter As System.Windows.Forms.LinkLabel
    Friend WithEvents theTip As System.Windows.Forms.ToolTip
    Friend WithEvents tlpConditions As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlCity As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbbCity As System.Windows.Forms.ComboBox
    Friend WithEvents pnlSalesBillType As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbbSalesDate As System.Windows.Forms.ComboBox
    Friend WithEvents cbbStore As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pnlSalesman As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbbPaymentTerm As System.Windows.Forms.ComboBox
    Friend WithEvents cbbSalesman As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents pnlState As System.Windows.Forms.Panel
    Friend WithEvents lblActivationState As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents cbbActivationState As System.Windows.Forms.ComboBox
    Friend WithEvents pnlSaleDate As System.Windows.Forms.Panel
    Friend WithEvents cbbSalesBillType As System.Windows.Forms.ComboBox
    Friend WithEvents pnlStore As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents splitHorizontal As System.Windows.Forms.SplitContainer
End Class
