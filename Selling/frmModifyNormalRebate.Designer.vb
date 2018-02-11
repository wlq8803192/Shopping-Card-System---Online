<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModifyNormalRebate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModifyNormalRebate))
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.grbNormalRebate = New System.Windows.Forms.GroupBox
        Me.flpNormalRebate = New System.Windows.Forms.FlowLayoutPanel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txbNormalSalesAMT = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.txbMaxNormalRebateAMT = New System.Windows.Forms.TextBox
        Me.txbMaxNormalRebateRate = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.txbNormalRebateAMT = New System.Windows.Forms.TextBox
        Me.txbNormalRebateRate = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.pnlNormalRebateState = New System.Windows.Forms.Panel
        Me.lblNormalRebateState = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.pnlNormalRebateRemarks = New System.Windows.Forms.Panel
        Me.lblNormalRebateRemarks = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.txbDistributionNormalRebateAMT = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.pnlBalanceNormalRebateAMT = New System.Windows.Forms.Panel
        Me.txbBalanceNormalRebateAMT = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.dgvRebateCard = New System.Windows.Forms.DataGridView
        Me.theTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.theTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.lblRebateCardSummary = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.cmenuDeleteRebateCard = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.menuDeleteRebateCard = New System.Windows.Forms.ToolStripMenuItem
        Me.grbPrintDiscount = New System.Windows.Forms.GroupBox
        Me.lblPrintDiscount = New System.Windows.Forms.Label
        Me.chbPrintDiscount = New System.Windows.Forms.CheckBox
        Me.btnShowResult = New System.Windows.Forms.Button
        Me.grbNormalRebate.SuspendLayout()
        Me.flpNormalRebate.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlNormalRebateState.SuspendLayout()
        Me.pnlNormalRebateRemarks.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlBalanceNormalRebateAMT.SuspendLayout()
        CType(Me.dgvRebateCard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmenuDeleteRebateCard.SuspendLayout()
        Me.grbPrintDiscount.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(624, 437)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 10
        Me.btnOK.Text = "确定(&O)"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(705, 437)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "取消(&C)"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(-10, 420)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(814, 4)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        '
        'grbNormalRebate
        '
        Me.grbNormalRebate.Controls.Add(Me.flpNormalRebate)
        Me.grbNormalRebate.Location = New System.Drawing.Point(10, 19)
        Me.grbNormalRebate.Margin = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.grbNormalRebate.Name = "grbNormalRebate"
        Me.grbNormalRebate.Size = New System.Drawing.Size(193, 342)
        Me.grbNormalRebate.TabIndex = 1
        Me.grbNormalRebate.TabStop = False
        '
        'flpNormalRebate
        '
        Me.flpNormalRebate.AutoSize = True
        Me.flpNormalRebate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpNormalRebate.Controls.Add(Me.Panel1)
        Me.flpNormalRebate.Controls.Add(Me.Panel2)
        Me.flpNormalRebate.Controls.Add(Me.Panel3)
        Me.flpNormalRebate.Controls.Add(Me.pnlNormalRebateState)
        Me.flpNormalRebate.Controls.Add(Me.pnlNormalRebateRemarks)
        Me.flpNormalRebate.Controls.Add(Me.Panel4)
        Me.flpNormalRebate.Controls.Add(Me.pnlBalanceNormalRebateAMT)
        Me.flpNormalRebate.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpNormalRebate.Location = New System.Drawing.Point(6, 15)
        Me.flpNormalRebate.Name = "flpNormalRebate"
        Me.flpNormalRebate.Size = New System.Drawing.Size(179, 322)
        Me.flpNormalRebate.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txbNormalSalesAMT)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(179, 43)
        Me.Panel1.TabIndex = 0
        '
        'txbNormalSalesAMT
        '
        Me.txbNormalSalesAMT.Location = New System.Drawing.Point(6, 16)
        Me.txbNormalSalesAMT.Name = "txbNormalSalesAMT"
        Me.txbNormalSalesAMT.ReadOnly = True
        Me.txbNormalSalesAMT.Size = New System.Drawing.Size(155, 21)
        Me.txbNormalSalesAMT.TabIndex = 1
        Me.txbNormalSalesAMT.Text = "0.00"
        Me.txbNormalSalesAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(174, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "当前销售单的正常充值金额："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(164, 21)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "元"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txbMaxNormalRebateAMT)
        Me.Panel2.Controls.Add(Me.txbMaxNormalRebateRate)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Location = New System.Drawing.Point(0, 43)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(179, 85)
        Me.Panel2.TabIndex = 1
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
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(162, 47)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(17, 12)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "元"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(165, 20)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 12)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "%"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 47)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 12)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "金额："
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.theTip.SetToolTip(Me.Label6, "标准范围内的最大返点金额")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(174, 12)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "标准范围内的最大返点计算："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 20)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 12)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "比率："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.theTip.SetToolTip(Me.Label4, "标准范围内的最大返点比率")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Maroon
        Me.Label8.Location = New System.Drawing.Point(0, 70)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(148, 12)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "请输入返点比率或金额："
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.txbNormalRebateAMT)
        Me.Panel3.Controls.Add(Me.txbNormalRebateRate)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Location = New System.Drawing.Point(0, 128)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(179, 57)
        Me.Panel3.TabIndex = 2
        '
        'txbNormalRebateAMT
        '
        Me.txbNormalRebateAMT.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txbNormalRebateAMT.ForeColor = System.Drawing.Color.Red
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
        Me.txbNormalRebateRate.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txbNormalRebateRate.ForeColor = System.Drawing.Color.Red
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
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(4, 7)
        Me.Label9.Margin = New System.Windows.Forms.Padding(0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 12)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "比率："
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.theTip.SetToolTip(Me.Label9, "返点比率")
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(4, 33)
        Me.Label11.Margin = New System.Windows.Forms.Padding(0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 12)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "金额："
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.theTip.SetToolTip(Me.Label11, "返点金额")
        '
        'pnlNormalRebateState
        '
        Me.pnlNormalRebateState.Controls.Add(Me.lblNormalRebateState)
        Me.pnlNormalRebateState.Controls.Add(Me.Label13)
        Me.pnlNormalRebateState.Location = New System.Drawing.Point(0, 185)
        Me.pnlNormalRebateState.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlNormalRebateState.Name = "pnlNormalRebateState"
        Me.pnlNormalRebateState.Size = New System.Drawing.Size(179, 19)
        Me.pnlNormalRebateState.TabIndex = 3
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
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(4, 0)
        Me.Label13.Margin = New System.Windows.Forms.Padding(0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 12)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "状态："
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlNormalRebateRemarks
        '
        Me.pnlNormalRebateRemarks.Controls.Add(Me.lblNormalRebateRemarks)
        Me.pnlNormalRebateRemarks.Controls.Add(Me.Label14)
        Me.pnlNormalRebateRemarks.Location = New System.Drawing.Point(0, 204)
        Me.pnlNormalRebateRemarks.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlNormalRebateRemarks.Name = "pnlNormalRebateRemarks"
        Me.pnlNormalRebateRemarks.Size = New System.Drawing.Size(179, 32)
        Me.pnlNormalRebateRemarks.TabIndex = 4
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
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(4, 6)
        Me.Label14.Margin = New System.Windows.Forms.Padding(0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 12)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "备注："
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.txbDistributionNormalRebateAMT)
        Me.Panel4.Controls.Add(Me.Label15)
        Me.Panel4.Controls.Add(Me.Label16)
        Me.Panel4.Location = New System.Drawing.Point(0, 236)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(179, 43)
        Me.Panel4.TabIndex = 4
        '
        'txbDistributionNormalRebateAMT
        '
        Me.txbDistributionNormalRebateAMT.Location = New System.Drawing.Point(4, 15)
        Me.txbDistributionNormalRebateAMT.Name = "txbDistributionNormalRebateAMT"
        Me.txbDistributionNormalRebateAMT.ReadOnly = True
        Me.txbDistributionNormalRebateAMT.Size = New System.Drawing.Size(155, 21)
        Me.txbDistributionNormalRebateAMT.TabIndex = 1
        Me.txbDistributionNormalRebateAMT.Text = "0.00"
        Me.txbDistributionNormalRebateAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Maroon
        Me.Label15.Location = New System.Drawing.Point(0, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(135, 12)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "本次已分配返点金额："
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(162, 20)
        Me.Label16.Margin = New System.Windows.Forms.Padding(0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(17, 12)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "元"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlBalanceNormalRebateAMT
        '
        Me.pnlBalanceNormalRebateAMT.Controls.Add(Me.txbBalanceNormalRebateAMT)
        Me.pnlBalanceNormalRebateAMT.Controls.Add(Me.Label17)
        Me.pnlBalanceNormalRebateAMT.Controls.Add(Me.Label18)
        Me.pnlBalanceNormalRebateAMT.Location = New System.Drawing.Point(0, 279)
        Me.pnlBalanceNormalRebateAMT.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlBalanceNormalRebateAMT.Name = "pnlBalanceNormalRebateAMT"
        Me.pnlBalanceNormalRebateAMT.Size = New System.Drawing.Size(179, 43)
        Me.pnlBalanceNormalRebateAMT.TabIndex = 5
        Me.pnlBalanceNormalRebateAMT.Visible = False
        '
        'txbBalanceNormalRebateAMT
        '
        Me.txbBalanceNormalRebateAMT.Location = New System.Drawing.Point(4, 15)
        Me.txbBalanceNormalRebateAMT.Name = "txbBalanceNormalRebateAMT"
        Me.txbBalanceNormalRebateAMT.ReadOnly = True
        Me.txbBalanceNormalRebateAMT.Size = New System.Drawing.Size(155, 21)
        Me.txbBalanceNormalRebateAMT.TabIndex = 1
        Me.txbBalanceNormalRebateAMT.Text = "0.00"
        Me.txbBalanceNormalRebateAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Maroon
        Me.Label17.Location = New System.Drawing.Point(0, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(135, 12)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "本次剩余的返点金额："
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(162, 20)
        Me.Label18.Margin = New System.Windows.Forms.Padding(0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(17, 12)
        Me.Label18.TabIndex = 2
        Me.Label18.Text = "元"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRebateCard.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvRebateCard.ColumnHeadersHeight = 22
        Me.dgvRebateCard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvRebateCard.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvRebateCard.Location = New System.Drawing.Point(214, 25)
        Me.dgvRebateCard.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvRebateCard.MultiSelect = False
        Me.dgvRebateCard.Name = "dgvRebateCard"
        Me.dgvRebateCard.RowHeadersVisible = False
        Me.dgvRebateCard.RowTemplate.Height = 24
        Me.dgvRebateCard.Size = New System.Drawing.Size(566, 384)
        Me.dgvRebateCard.StandardTab = True
        Me.dgvRebateCard.TabIndex = 5
        '
        'theTip
        '
        Me.theTip.AutoPopDelay = 15000
        Me.theTip.InitialDelay = 500
        Me.theTip.ReshowDelay = 100
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label20.Location = New System.Drawing.Point(8, 442)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(65, 12)
        Me.Label20.TabIndex = 7
        Me.Label20.Text = "操作说明："
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(71, 442)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(437, 12)
        Me.Label21.TabIndex = 8
        Me.Label21.Text = "请先在上面文本框输入返点比率或金额，然后在右边的返点卡列表重新分配返点。"
        '
        'lblRebateCardSummary
        '
        Me.lblRebateCardSummary.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRebateCardSummary.Location = New System.Drawing.Point(309, 9)
        Me.lblRebateCardSummary.Name = "lblRebateCardSummary"
        Me.lblRebateCardSummary.Size = New System.Drawing.Size(478, 12)
        Me.lblRebateCardSummary.TabIndex = 4
        Me.lblRebateCardSummary.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label19.Location = New System.Drawing.Point(212, 9)
        Me.Label19.Margin = New System.Windows.Forms.Padding(0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(101, 12)
        Me.Label19.TabIndex = 3
        Me.Label19.Text = "返点卡充值列表："
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label22.Location = New System.Drawing.Point(8, 9)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(77, 12)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "请修改返点："
        '
        'cmenuDeleteRebateCard
        '
        Me.cmenuDeleteRebateCard.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuDeleteRebateCard})
        Me.cmenuDeleteRebateCard.Name = "cmenuDeleteCardRow"
        Me.cmenuDeleteRebateCard.Size = New System.Drawing.Size(166, 26)
        '
        'menuDeleteRebateCard
        '
        Me.menuDeleteRebateCard.Name = "menuDeleteRebateCard"
        Me.menuDeleteRebateCard.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.menuDeleteRebateCard.Size = New System.Drawing.Size(165, 22)
        Me.menuDeleteRebateCard.Text = "删除行   "
        '
        'grbPrintDiscount
        '
        Me.grbPrintDiscount.Controls.Add(Me.lblPrintDiscount)
        Me.grbPrintDiscount.Controls.Add(Me.chbPrintDiscount)
        Me.grbPrintDiscount.Location = New System.Drawing.Point(10, 365)
        Me.grbPrintDiscount.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Me.grbPrintDiscount.Name = "grbPrintDiscount"
        Me.grbPrintDiscount.Size = New System.Drawing.Size(193, 44)
        Me.grbPrintDiscount.TabIndex = 2
        Me.grbPrintDiscount.TabStop = False
        '
        'lblPrintDiscount
        '
        Me.lblPrintDiscount.AutoSize = True
        Me.lblPrintDiscount.Location = New System.Drawing.Point(29, 20)
        Me.lblPrintDiscount.Name = "lblPrintDiscount"
        Me.lblPrintDiscount.Size = New System.Drawing.Size(125, 12)
        Me.lblPrintDiscount.TabIndex = 1
        Me.lblPrintDiscount.Text = "在发票上打印折扣信息"
        '
        'chbPrintDiscount
        '
        Me.chbPrintDiscount.AutoSize = True
        Me.chbPrintDiscount.Location = New System.Drawing.Point(11, 19)
        Me.chbPrintDiscount.Name = "chbPrintDiscount"
        Me.chbPrintDiscount.Size = New System.Drawing.Size(15, 14)
        Me.chbPrintDiscount.TabIndex = 0
        Me.chbPrintDiscount.UseVisualStyleBackColor = True
        '
        'btnShowResult
        '
        Me.btnShowResult.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnShowResult.Enabled = False
        Me.btnShowResult.Location = New System.Drawing.Point(514, 437)
        Me.btnShowResult.Name = "btnShowResult"
        Me.btnShowResult.Size = New System.Drawing.Size(104, 23)
        Me.btnShowResult.TabIndex = 9
        Me.btnShowResult.Text = "显示检查结果(&R)"
        Me.btnShowResult.UseVisualStyleBackColor = True
        Me.btnShowResult.Visible = False
        '
        'frmModifyNormalRebate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(792, 472)
        Me.Controls.Add(Me.grbPrintDiscount)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.lblRebateCardSummary)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.dgvRebateCard)
        Me.Controls.Add(Me.grbNormalRebate)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnShowResult)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmModifyNormalRebate"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "请修改销售单的城市返点："
        Me.grbNormalRebate.ResumeLayout(False)
        Me.grbNormalRebate.PerformLayout()
        Me.flpNormalRebate.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnlNormalRebateState.ResumeLayout(False)
        Me.pnlNormalRebateState.PerformLayout()
        Me.pnlNormalRebateRemarks.ResumeLayout(False)
        Me.pnlNormalRebateRemarks.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pnlBalanceNormalRebateAMT.ResumeLayout(False)
        Me.pnlBalanceNormalRebateAMT.PerformLayout()
        CType(Me.dgvRebateCard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmenuDeleteRebateCard.ResumeLayout(False)
        Me.grbPrintDiscount.ResumeLayout(False)
        Me.grbPrintDiscount.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents grbNormalRebate As System.Windows.Forms.GroupBox
    Friend WithEvents flpNormalRebate As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txbMaxNormalRebateAMT As System.Windows.Forms.TextBox
    Friend WithEvents txbMaxNormalRebateRate As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txbNormalRebateAMT As System.Windows.Forms.TextBox
    Friend WithEvents txbNormalRebateRate As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents pnlNormalRebateState As System.Windows.Forms.Panel
    Friend WithEvents lblNormalRebateState As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents pnlNormalRebateRemarks As System.Windows.Forms.Panel
    Friend WithEvents lblNormalRebateRemarks As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents txbDistributionNormalRebateAMT As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents pnlBalanceNormalRebateAMT As System.Windows.Forms.Panel
    Friend WithEvents txbBalanceNormalRebateAMT As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txbNormalSalesAMT As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvRebateCard As System.Windows.Forms.DataGridView
    Friend WithEvents theTip As System.Windows.Forms.ToolTip
    Friend WithEvents theTimer As System.Windows.Forms.Timer
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblRebateCardSummary As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cmenuDeleteRebateCard As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents menuDeleteRebateCard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grbPrintDiscount As System.Windows.Forms.GroupBox
    Friend WithEvents lblPrintDiscount As System.Windows.Forms.Label
    Friend WithEvents chbPrintDiscount As System.Windows.Forms.CheckBox
    Friend WithEvents btnShowResult As System.Windows.Forms.Button
End Class
