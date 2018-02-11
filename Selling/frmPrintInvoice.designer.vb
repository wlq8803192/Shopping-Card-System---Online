<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrintInvoice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrintInvoice))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnPrintInvoice = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.grbAvailableInvoiceAMT = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txbTotalPaymentAMT = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txbTotalPrintedInvoiceAMT = New System.Windows.Forms.TextBox
        Me.lblAvailableInvoiceAMT = New System.Windows.Forms.Label
        Me.txbAvailableInvoiceAMT = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblPaymentTitle = New System.Windows.Forms.Label
        Me.grbPrintedInvoice = New System.Windows.Forms.GroupBox
        Me.dgvInvoice = New System.Windows.Forms.DataGridView
        Me.grbNewInvoice = New System.Windows.Forms.GroupBox
        Me.nudQTY = New System.Windows.Forms.NumericUpDown
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbbInvoiceItem2 = New System.Windows.Forms.ComboBox
        Me.cbbInvoiceItem1 = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txbInvoiceAMT = New System.Windows.Forms.TextBox
        Me.txbInvoiceTitle = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblError = New System.Windows.Forms.Label
        Me.flpLayout = New System.Windows.Forms.FlowLayoutPanel
        Me.pnlNewInvoice = New System.Windows.Forms.Panel
        Me.grbNewInvoiceExtra = New System.Windows.Forms.GroupBox
        Me.btnGetNewInvoiceNo = New System.Windows.Forms.Button
        Me.txbInvoiceNo = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txbInvoiceCode = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.chbPrintDiscount = New System.Windows.Forms.CheckBox
        Me.theTimer = New System.Windows.Forms.Timer(Me.components)
        Me.chbMultiPrint = New System.Windows.Forms.CheckBox
        Me.tlpMultiPrint = New System.Windows.Forms.TableLayoutPanel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblMultiPrint1 = New System.Windows.Forms.Label
        Me.nudMultiPrint = New System.Windows.Forms.NumericUpDown
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblMultiPrint2 = New System.Windows.Forms.Label
        Me.newInvoiceNoTimer = New System.Windows.Forms.Timer(Me.components)
        Me.chbPrintLine = New System.Windows.Forms.CheckBox
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.grbAvailableInvoiceAMT.SuspendLayout()
        Me.grbPrintedInvoice.SuspendLayout()
        CType(Me.dgvInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbNewInvoice.SuspendLayout()
        CType(Me.nudQTY, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flpLayout.SuspendLayout()
        Me.pnlNewInvoice.SuspendLayout()
        Me.grbNewInvoiceExtra.SuspendLayout()
        Me.tlpMultiPrint.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.nudMultiPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(-5, 406)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(710, 4)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'btnPrintInvoice
        '
        Me.btnPrintInvoice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintInvoice.Enabled = False
        Me.btnPrintInvoice.Location = New System.Drawing.Point(496, 423)
        Me.btnPrintInvoice.Name = "btnPrintInvoice"
        Me.btnPrintInvoice.Size = New System.Drawing.Size(105, 23)
        Me.btnPrintInvoice.TabIndex = 5
        Me.btnPrintInvoice.Text = "打印发票(&I)"
        Me.btnPrintInvoice.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.Location = New System.Drawing.Point(608, 423)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(74, 23)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "关闭(&C)"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'grbAvailableInvoiceAMT
        '
        Me.grbAvailableInvoiceAMT.Controls.Add(Me.Label2)
        Me.grbAvailableInvoiceAMT.Controls.Add(Me.txbTotalPaymentAMT)
        Me.grbAvailableInvoiceAMT.Controls.Add(Me.Label4)
        Me.grbAvailableInvoiceAMT.Controls.Add(Me.Label6)
        Me.grbAvailableInvoiceAMT.Controls.Add(Me.txbTotalPrintedInvoiceAMT)
        Me.grbAvailableInvoiceAMT.Controls.Add(Me.lblAvailableInvoiceAMT)
        Me.grbAvailableInvoiceAMT.Controls.Add(Me.txbAvailableInvoiceAMT)
        Me.grbAvailableInvoiceAMT.Controls.Add(Me.Label3)
        Me.grbAvailableInvoiceAMT.Controls.Add(Me.lblPaymentTitle)
        Me.grbAvailableInvoiceAMT.Location = New System.Drawing.Point(0, 3)
        Me.grbAvailableInvoiceAMT.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.grbAvailableInvoiceAMT.Name = "grbAvailableInvoiceAMT"
        Me.grbAvailableInvoiceAMT.Size = New System.Drawing.Size(668, 109)
        Me.grbAvailableInvoiceAMT.TabIndex = 0
        Me.grbAvailableInvoiceAMT.TabStop = False
        Me.grbAvailableInvoiceAMT.Text = "可打印发票金额："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(334, 25)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "元"
        '
        'txbTotalPaymentAMT
        '
        Me.txbTotalPaymentAMT.Location = New System.Drawing.Point(159, 20)
        Me.txbTotalPaymentAMT.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.txbTotalPaymentAMT.Name = "txbTotalPaymentAMT"
        Me.txbTotalPaymentAMT.ReadOnly = True
        Me.txbTotalPaymentAMT.Size = New System.Drawing.Size(172, 21)
        Me.txbTotalPaymentAMT.TabIndex = 1
        Me.txbTotalPaymentAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(334, 52)
        Me.Label4.Margin = New System.Windows.Forms.Padding(3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(17, 12)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "元"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(334, 79)
        Me.Label6.Margin = New System.Windows.Forms.Padding(3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(17, 12)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "元"
        '
        'txbTotalPrintedInvoiceAMT
        '
        Me.txbTotalPrintedInvoiceAMT.Location = New System.Drawing.Point(159, 47)
        Me.txbTotalPrintedInvoiceAMT.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.txbTotalPrintedInvoiceAMT.Name = "txbTotalPrintedInvoiceAMT"
        Me.txbTotalPrintedInvoiceAMT.ReadOnly = True
        Me.txbTotalPrintedInvoiceAMT.Size = New System.Drawing.Size(172, 21)
        Me.txbTotalPrintedInvoiceAMT.TabIndex = 4
        Me.txbTotalPrintedInvoiceAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAvailableInvoiceAMT
        '
        Me.lblAvailableInvoiceAMT.Location = New System.Drawing.Point(7, 79)
        Me.lblAvailableInvoiceAMT.Margin = New System.Windows.Forms.Padding(3)
        Me.lblAvailableInvoiceAMT.Name = "lblAvailableInvoiceAMT"
        Me.lblAvailableInvoiceAMT.Size = New System.Drawing.Size(149, 12)
        Me.lblAvailableInvoiceAMT.TabIndex = 6
        Me.lblAvailableInvoiceAMT.Text = "本次可打印发票金额："
        Me.lblAvailableInvoiceAMT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txbAvailableInvoiceAMT
        '
        Me.txbAvailableInvoiceAMT.Location = New System.Drawing.Point(159, 74)
        Me.txbAvailableInvoiceAMT.Margin = New System.Windows.Forms.Padding(0)
        Me.txbAvailableInvoiceAMT.Name = "txbAvailableInvoiceAMT"
        Me.txbAvailableInvoiceAMT.ReadOnly = True
        Me.txbAvailableInvoiceAMT.Size = New System.Drawing.Size(172, 21)
        Me.txbAvailableInvoiceAMT.TabIndex = 7
        Me.txbAvailableInvoiceAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(55, 52)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "已打印发票金额："
        '
        'lblPaymentTitle
        '
        Me.lblPaymentTitle.AutoSize = True
        Me.lblPaymentTitle.Location = New System.Drawing.Point(10, 25)
        Me.lblPaymentTitle.Margin = New System.Windows.Forms.Padding(3)
        Me.lblPaymentTitle.Name = "lblPaymentTitle"
        Me.lblPaymentTitle.Size = New System.Drawing.Size(149, 12)
        Me.lblPaymentTitle.TabIndex = 0
        Me.lblPaymentTitle.Text = "本次销售可打印发票金额："
        '
        'grbPrintedInvoice
        '
        Me.grbPrintedInvoice.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbPrintedInvoice.Controls.Add(Me.dgvInvoice)
        Me.grbPrintedInvoice.Location = New System.Drawing.Point(0, 118)
        Me.grbPrintedInvoice.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.grbPrintedInvoice.Name = "grbPrintedInvoice"
        Me.grbPrintedInvoice.Size = New System.Drawing.Size(668, 158)
        Me.grbPrintedInvoice.TabIndex = 1
        Me.grbPrintedInvoice.TabStop = False
        Me.grbPrintedInvoice.Text = "已打印发票列表："
        '
        'dgvInvoice
        '
        Me.dgvInvoice.AllowUserToAddRows = False
        Me.dgvInvoice.AllowUserToDeleteRows = False
        Me.dgvInvoice.AllowUserToResizeRows = False
        Me.dgvInvoice.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInvoice.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvInvoice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInvoice.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInvoice.ColumnHeadersHeight = 22
        Me.dgvInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvInvoice.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvInvoice.Location = New System.Drawing.Point(14, 23)
        Me.dgvInvoice.MultiSelect = False
        Me.dgvInvoice.Name = "dgvInvoice"
        Me.dgvInvoice.ReadOnly = True
        Me.dgvInvoice.RowHeadersVisible = False
        Me.dgvInvoice.RowTemplate.Height = 24
        Me.dgvInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvInvoice.Size = New System.Drawing.Size(640, 120)
        Me.dgvInvoice.StandardTab = True
        Me.dgvInvoice.TabIndex = 0
        '
        'grbNewInvoice
        '
        Me.grbNewInvoice.Controls.Add(Me.nudQTY)
        Me.grbNewInvoice.Controls.Add(Me.Label1)
        Me.grbNewInvoice.Controls.Add(Me.cbbInvoiceItem2)
        Me.grbNewInvoice.Controls.Add(Me.cbbInvoiceItem1)
        Me.grbNewInvoice.Controls.Add(Me.Label9)
        Me.grbNewInvoice.Controls.Add(Me.Label11)
        Me.grbNewInvoice.Controls.Add(Me.txbInvoiceAMT)
        Me.grbNewInvoice.Controls.Add(Me.txbInvoiceTitle)
        Me.grbNewInvoice.Controls.Add(Me.Label10)
        Me.grbNewInvoice.Controls.Add(Me.Label8)
        Me.grbNewInvoice.Controls.Add(Me.Label7)
        Me.grbNewInvoice.Location = New System.Drawing.Point(0, 0)
        Me.grbNewInvoice.Margin = New System.Windows.Forms.Padding(0)
        Me.grbNewInvoice.Name = "grbNewInvoice"
        Me.grbNewInvoice.Size = New System.Drawing.Size(471, 107)
        Me.grbNewInvoice.TabIndex = 0
        Me.grbNewInvoice.TabStop = False
        Me.grbNewInvoice.Text = "新开发票："
        '
        'nudQTY
        '
        Me.nudQTY.Location = New System.Drawing.Point(308, 73)
        Me.nudQTY.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.nudQTY.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudQTY.Name = "nudQTY"
        Me.nudQTY.Size = New System.Drawing.Size(150, 21)
        Me.nudQTY.TabIndex = 10
        Me.nudQTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudQTY.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(267, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "数量："
        '
        'cbbInvoiceItem2
        '
        Me.cbbInvoiceItem2.FormattingEnabled = True
        Me.cbbInvoiceItem2.Location = New System.Drawing.Point(308, 47)
        Me.cbbInvoiceItem2.MaxDropDownItems = 20
        Me.cbbInvoiceItem2.Name = "cbbInvoiceItem2"
        Me.cbbInvoiceItem2.Size = New System.Drawing.Size(150, 20)
        Me.cbbInvoiceItem2.TabIndex = 5
        '
        'cbbInvoiceItem1
        '
        Me.cbbInvoiceItem1.FormattingEnabled = True
        Me.cbbInvoiceItem1.Location = New System.Drawing.Point(81, 47)
        Me.cbbInvoiceItem1.MaxDropDownItems = 20
        Me.cbbInvoiceItem1.Name = "cbbInvoiceItem1"
        Me.cbbInvoiceItem1.Size = New System.Drawing.Size(150, 20)
        Me.cbbInvoiceItem1.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(237, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 12)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "发票品项2："
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(237, 78)
        Me.Label11.Margin = New System.Windows.Forms.Padding(3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(17, 12)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "元"
        '
        'txbInvoiceAMT
        '
        Me.txbInvoiceAMT.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbInvoiceAMT.Location = New System.Drawing.Point(81, 73)
        Me.txbInvoiceAMT.MaxLength = 12
        Me.txbInvoiceAMT.Name = "txbInvoiceAMT"
        Me.txbInvoiceAMT.Size = New System.Drawing.Size(150, 21)
        Me.txbInvoiceAMT.TabIndex = 7
        Me.txbInvoiceAMT.Text = "0.00"
        Me.txbInvoiceAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txbInvoiceTitle
        '
        Me.txbInvoiceTitle.Location = New System.Drawing.Point(81, 20)
        Me.txbInvoiceTitle.Name = "txbInvoiceTitle"
        Me.txbInvoiceTitle.ReadOnly = True
        Me.txbInvoiceTitle.Size = New System.Drawing.Size(377, 21)
        Me.txbInvoiceTitle.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(4, 78)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 12)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "发票总金额："
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 12)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "发票品项1："
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 12)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "发票抬头："
        '
        'lblError
        '
        Me.lblError.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblError.AutoSize = True
        Me.lblError.ForeColor = System.Drawing.Color.Red
        Me.lblError.Location = New System.Drawing.Point(10, 428)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(185, 12)
        Me.lblError.TabIndex = 2
        Me.lblError.Text = "（错误：超过最大可打印金额！）"
        Me.lblError.Visible = False
        '
        'flpLayout
        '
        Me.flpLayout.AutoSize = True
        Me.flpLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpLayout.Controls.Add(Me.grbAvailableInvoiceAMT)
        Me.flpLayout.Controls.Add(Me.grbPrintedInvoice)
        Me.flpLayout.Controls.Add(Me.pnlNewInvoice)
        Me.flpLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpLayout.Location = New System.Drawing.Point(12, 5)
        Me.flpLayout.Name = "flpLayout"
        Me.flpLayout.Size = New System.Drawing.Size(668, 392)
        Me.flpLayout.TabIndex = 0
        '
        'pnlNewInvoice
        '
        Me.pnlNewInvoice.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlNewInvoice.Controls.Add(Me.grbNewInvoiceExtra)
        Me.pnlNewInvoice.Controls.Add(Me.grbNewInvoice)
        Me.pnlNewInvoice.Location = New System.Drawing.Point(0, 282)
        Me.pnlNewInvoice.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.pnlNewInvoice.Name = "pnlNewInvoice"
        Me.pnlNewInvoice.Size = New System.Drawing.Size(668, 107)
        Me.pnlNewInvoice.TabIndex = 2
        '
        'grbNewInvoiceExtra
        '
        Me.grbNewInvoiceExtra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbNewInvoiceExtra.Controls.Add(Me.btnGetNewInvoiceNo)
        Me.grbNewInvoiceExtra.Controls.Add(Me.txbInvoiceNo)
        Me.grbNewInvoiceExtra.Controls.Add(Me.Label12)
        Me.grbNewInvoiceExtra.Controls.Add(Me.txbInvoiceCode)
        Me.grbNewInvoiceExtra.Controls.Add(Me.Label5)
        Me.grbNewInvoiceExtra.Location = New System.Drawing.Point(483, 0)
        Me.grbNewInvoiceExtra.Margin = New System.Windows.Forms.Padding(0)
        Me.grbNewInvoiceExtra.Name = "grbNewInvoiceExtra"
        Me.grbNewInvoiceExtra.Size = New System.Drawing.Size(185, 107)
        Me.grbNewInvoiceExtra.TabIndex = 1
        Me.grbNewInvoiceExtra.TabStop = False
        Me.grbNewInvoiceExtra.Text = "发票代码和发票号码："
        '
        'btnGetNewInvoiceNo
        '
        Me.btnGetNewInvoiceNo.Enabled = False
        Me.btnGetNewInvoiceNo.Location = New System.Drawing.Point(11, 73)
        Me.btnGetNewInvoiceNo.Name = "btnGetNewInvoiceNo"
        Me.btnGetNewInvoiceNo.Size = New System.Drawing.Size(160, 23)
        Me.btnGetNewInvoiceNo.TabIndex = 4
        Me.btnGetNewInvoiceNo.Text = "获取下一个可用发票号码"
        Me.btnGetNewInvoiceNo.UseVisualStyleBackColor = True
        '
        'txbInvoiceNo
        '
        Me.txbInvoiceNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbInvoiceNo.Location = New System.Drawing.Point(73, 47)
        Me.txbInvoiceNo.MaxLength = 30
        Me.txbInvoiceNo.Name = "txbInvoiceNo"
        Me.txbInvoiceNo.Size = New System.Drawing.Size(98, 21)
        Me.txbInvoiceNo.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(8, 52)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 12)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "发票号码："
        '
        'txbInvoiceCode
        '
        Me.txbInvoiceCode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbInvoiceCode.Location = New System.Drawing.Point(73, 20)
        Me.txbInvoiceCode.MaxLength = 30
        Me.txbInvoiceCode.Name = "txbInvoiceCode"
        Me.txbInvoiceCode.Size = New System.Drawing.Size(98, 21)
        Me.txbInvoiceCode.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "发票代码："
        '
        'chbPrintDiscount
        '
        Me.chbPrintDiscount.AutoSize = True
        Me.chbPrintDiscount.Location = New System.Drawing.Point(84, 0)
        Me.chbPrintDiscount.Margin = New System.Windows.Forms.Padding(0)
        Me.chbPrintDiscount.Name = "chbPrintDiscount"
        Me.chbPrintDiscount.Size = New System.Drawing.Size(96, 16)
        Me.chbPrintDiscount.TabIndex = 4
        Me.chbPrintDiscount.Text = "打印折扣信息"
        Me.chbPrintDiscount.UseVisualStyleBackColor = True
        Me.chbPrintDiscount.Visible = False
        '
        'theTimer
        '
        Me.theTimer.Interval = 500
        '
        'chbMultiPrint
        '
        Me.chbMultiPrint.AutoSize = True
        Me.chbMultiPrint.Location = New System.Drawing.Point(3, 4)
        Me.chbMultiPrint.Name = "chbMultiPrint"
        Me.chbMultiPrint.Size = New System.Drawing.Size(15, 14)
        Me.chbMultiPrint.TabIndex = 6
        Me.chbMultiPrint.UseVisualStyleBackColor = True
        '
        'tlpMultiPrint
        '
        Me.tlpMultiPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tlpMultiPrint.AutoSize = True
        Me.tlpMultiPrint.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpMultiPrint.ColumnCount = 3
        Me.tlpMultiPrint.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpMultiPrint.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpMultiPrint.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpMultiPrint.Controls.Add(Me.Panel1, 0, 0)
        Me.tlpMultiPrint.Controls.Add(Me.nudMultiPrint, 1, 0)
        Me.tlpMultiPrint.Controls.Add(Me.Panel2, 2, 0)
        Me.tlpMultiPrint.Location = New System.Drawing.Point(12, 424)
        Me.tlpMultiPrint.Name = "tlpMultiPrint"
        Me.tlpMultiPrint.RowCount = 1
        Me.tlpMultiPrint.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMultiPrint.Size = New System.Drawing.Size(261, 22)
        Me.tlpMultiPrint.TabIndex = 3
        Me.tlpMultiPrint.Visible = False
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.Controls.Add(Me.lblMultiPrint1)
        Me.Panel1.Controls.Add(Me.chbMultiPrint)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(169, 21)
        Me.Panel1.TabIndex = 0
        '
        'lblMultiPrint1
        '
        Me.lblMultiPrint1.AutoSize = True
        Me.lblMultiPrint1.Location = New System.Drawing.Point(17, 5)
        Me.lblMultiPrint1.Name = "lblMultiPrint1"
        Me.lblMultiPrint1.Size = New System.Drawing.Size(149, 12)
        Me.lblMultiPrint1.TabIndex = 7
        Me.lblMultiPrint1.Text = "用上面品项、金额连续打印"
        '
        'nudMultiPrint
        '
        Me.nudMultiPrint.Enabled = False
        Me.nudMultiPrint.Location = New System.Drawing.Point(169, 0)
        Me.nudMultiPrint.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.nudMultiPrint.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.nudMultiPrint.Name = "nudMultiPrint"
        Me.nudMultiPrint.Size = New System.Drawing.Size(45, 21)
        Me.nudMultiPrint.TabIndex = 1
        Me.nudMultiPrint.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudMultiPrint.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.Controls.Add(Me.lblMultiPrint2)
        Me.Panel2.Location = New System.Drawing.Point(214, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(47, 17)
        Me.Panel2.TabIndex = 2
        '
        'lblMultiPrint2
        '
        Me.lblMultiPrint2.AutoSize = True
        Me.lblMultiPrint2.Location = New System.Drawing.Point(3, 5)
        Me.lblMultiPrint2.Name = "lblMultiPrint2"
        Me.lblMultiPrint2.Size = New System.Drawing.Size(41, 12)
        Me.lblMultiPrint2.TabIndex = 0
        Me.lblMultiPrint2.Text = "张发票"
        '
        'newInvoiceNoTimer
        '
        Me.newInvoiceNoTimer.Interval = 1000
        '
        'chbPrintLine
        '
        Me.chbPrintLine.AutoSize = True
        Me.chbPrintLine.Location = New System.Drawing.Point(0, 0)
        Me.chbPrintLine.Margin = New System.Windows.Forms.Padding(0)
        Me.chbPrintLine.Name = "chbPrintLine"
        Me.chbPrintLine.Size = New System.Drawing.Size(84, 16)
        Me.chbPrintLine.TabIndex = 5
        Me.chbPrintLine.Text = "打印表格线"
        Me.chbPrintLine.UseVisualStyleBackColor = True
        Me.chbPrintLine.Visible = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(486, 444)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(0, 0)
        Me.FlowLayoutPanel1.TabIndex = 4
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.chbPrintDiscount, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.chbPrintLine, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(310, 428)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(180, 16)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'frmPrintInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(694, 458)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.tlpMultiPrint)
        Me.Controls.Add(Me.lblError)
        Me.Controls.Add(Me.flpLayout)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnPrintInvoice)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrintInvoice"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "打印发票："
        Me.grbAvailableInvoiceAMT.ResumeLayout(False)
        Me.grbAvailableInvoiceAMT.PerformLayout()
        Me.grbPrintedInvoice.ResumeLayout(False)
        CType(Me.dgvInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbNewInvoice.ResumeLayout(False)
        Me.grbNewInvoice.PerformLayout()
        CType(Me.nudQTY, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flpLayout.ResumeLayout(False)
        Me.pnlNewInvoice.ResumeLayout(False)
        Me.grbNewInvoiceExtra.ResumeLayout(False)
        Me.grbNewInvoiceExtra.PerformLayout()
        Me.tlpMultiPrint.ResumeLayout(False)
        Me.tlpMultiPrint.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.nudMultiPrint, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnPrintInvoice As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents grbAvailableInvoiceAMT As System.Windows.Forms.GroupBox
    Friend WithEvents lblPaymentTitle As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblAvailableInvoiceAMT As System.Windows.Forms.Label
    Friend WithEvents txbTotalPaymentAMT As System.Windows.Forms.TextBox
    Friend WithEvents txbTotalPrintedInvoiceAMT As System.Windows.Forms.TextBox
    Friend WithEvents txbAvailableInvoiceAMT As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents grbPrintedInvoice As System.Windows.Forms.GroupBox
    Friend WithEvents dgvInvoice As System.Windows.Forms.DataGridView
    Friend WithEvents grbNewInvoice As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents flpLayout As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents cbbInvoiceItem2 As System.Windows.Forms.ComboBox
    Friend WithEvents cbbInvoiceItem1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txbInvoiceAMT As System.Windows.Forms.TextBox
    Friend WithEvents txbInvoiceTitle As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblError As System.Windows.Forms.Label
    Friend WithEvents nudQTY As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chbPrintDiscount As System.Windows.Forms.CheckBox
    Friend WithEvents theTimer As System.Windows.Forms.Timer
    Friend WithEvents chbMultiPrint As System.Windows.Forms.CheckBox
    Friend WithEvents tlpMultiPrint As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblMultiPrint1 As System.Windows.Forms.Label
    Friend WithEvents nudMultiPrint As System.Windows.Forms.NumericUpDown
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblMultiPrint2 As System.Windows.Forms.Label
    Friend WithEvents pnlNewInvoice As System.Windows.Forms.Panel
    Friend WithEvents grbNewInvoiceExtra As System.Windows.Forms.GroupBox
    Friend WithEvents txbInvoiceCode As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnGetNewInvoiceNo As System.Windows.Forms.Button
    Friend WithEvents txbInvoiceNo As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents newInvoiceNoTimer As System.Windows.Forms.Timer
    Friend WithEvents chbPrintLine As System.Windows.Forms.CheckBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
End Class
