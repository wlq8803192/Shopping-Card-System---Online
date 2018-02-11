<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmValidateDiscount
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmValidateDiscount))
        Me.dgvRule = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txbMaxNormalRebateAMT = New System.Windows.Forms.TextBox
        Me.txbMaxNormalRebateRate = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txbNormalSalesAMT = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txbNormalRebateRate = New System.Windows.Forms.TextBox
        Me.txbNormalRebateAMT = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txbOverRebateAMT = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rdbOK = New System.Windows.Forms.RadioButton
        Me.txbReason = New System.Windows.Forms.TextBox
        Me.rdbFailure = New System.Windows.Forms.RadioButton
        Me.Label14 = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.Label15 = New System.Windows.Forms.Label
        CType(Me.dgvRule, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvRule
        '
        Me.dgvRule.AllowUserToAddRows = False
        Me.dgvRule.AllowUserToDeleteRows = False
        Me.dgvRule.AllowUserToResizeRows = False
        Me.dgvRule.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRule.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvRule.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRule.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvRule.ColumnHeadersHeight = 36
        Me.dgvRule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRule.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvRule.Location = New System.Drawing.Point(14, 42)
        Me.dgvRule.MultiSelect = False
        Me.dgvRule.Name = "dgvRule"
        Me.dgvRule.ReadOnly = True
        Me.dgvRule.RowHeadersVisible = False
        Me.dgvRule.RowTemplate.Height = 24
        Me.dgvRule.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvRule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRule.Size = New System.Drawing.Size(566, 206)
        Me.dgvRule.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(485, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "下面是当前销售单在建单时刻的城市返点规则列表（黄色行是适用于当前销售单的规则）："
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txbMaxNormalRebateAMT)
        Me.GroupBox1.Controls.Add(Me.txbMaxNormalRebateRate)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 285)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(276, 81)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "按规则计算的最大返点 Standard Discont:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(254, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(17, 12)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "元"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(256, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 12)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "%"
        '
        'txbMaxNormalRebateAMT
        '
        Me.txbMaxNormalRebateAMT.Location = New System.Drawing.Point(129, 48)
        Me.txbMaxNormalRebateAMT.Name = "txbMaxNormalRebateAMT"
        Me.txbMaxNormalRebateAMT.ReadOnly = True
        Me.txbMaxNormalRebateAMT.Size = New System.Drawing.Size(122, 21)
        Me.txbMaxNormalRebateAMT.TabIndex = 6
        Me.txbMaxNormalRebateAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txbMaxNormalRebateRate
        '
        Me.txbMaxNormalRebateRate.Location = New System.Drawing.Point(129, 20)
        Me.txbMaxNormalRebateRate.Name = "txbMaxNormalRebateRate"
        Me.txbMaxNormalRebateRate.ReadOnly = True
        Me.txbMaxNormalRebateRate.Size = New System.Drawing.Size(122, 21)
        Me.txbMaxNormalRebateRate.TabIndex = 2
        Me.txbMaxNormalRebateRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 62)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(125, 12)
        Me.Label17.TabIndex = 5
        Me.Label17.Text = "Standard Max Amount:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 12)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "标准的最大返点金额"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 33)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(113, 12)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "Standard Max Rate:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 12)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "标准的最大返点比率"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 262)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(407, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "当前销售单正常的充值金额 Normal charged amount of current dealing: "
        '
        'txbNormalSalesAMT
        '
        Me.txbNormalSalesAMT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txbNormalSalesAMT.Location = New System.Drawing.Point(431, 258)
        Me.txbNormalSalesAMT.Name = "txbNormalSalesAMT"
        Me.txbNormalSalesAMT.ReadOnly = True
        Me.txbNormalSalesAMT.Size = New System.Drawing.Size(122, 21)
        Me.txbNormalSalesAMT.TabIndex = 4
        Me.txbNormalSalesAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.txbNormalRebateRate)
        Me.GroupBox2.Controls.Add(Me.txbNormalRebateAMT)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Location = New System.Drawing.Point(302, 285)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(276, 81)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "售卡员实际分配的返点 Required Discount:"
        '
        'txbNormalRebateRate
        '
        Me.txbNormalRebateRate.Location = New System.Drawing.Point(129, 20)
        Me.txbNormalRebateRate.Name = "txbNormalRebateRate"
        Me.txbNormalRebateRate.ReadOnly = True
        Me.txbNormalRebateRate.Size = New System.Drawing.Size(122, 21)
        Me.txbNormalRebateRate.TabIndex = 2
        Me.txbNormalRebateRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txbNormalRebateAMT
        '
        Me.txbNormalRebateAMT.Location = New System.Drawing.Point(129, 48)
        Me.txbNormalRebateAMT.Name = "txbNormalRebateAMT"
        Me.txbNormalRebateAMT.ReadOnly = True
        Me.txbNormalRebateAMT.Size = New System.Drawing.Size(122, 21)
        Me.txbNormalRebateAMT.TabIndex = 6
        Me.txbNormalRebateAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 62)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(101, 12)
        Me.Label19.TabIndex = 5
        Me.Label19.Text = "Required Amount:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 33)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(89, 12)
        Me.Label18.TabIndex = 1
        Me.Label18.Text = "Required Rate:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(113, 12)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "实际分配的返点比率"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(254, 53)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(17, 12)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "元"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 49)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(113, 12)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "实际分配的返点金额"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(256, 25)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(11, 12)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "%"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(556, 263)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "元"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(20, 381)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(413, 12)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "实际的返点金额已超出标准 The gap AMT between required and standard: "
        '
        'txbOverRebateAMT
        '
        Me.txbOverRebateAMT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txbOverRebateAMT.BackColor = System.Drawing.SystemColors.Control
        Me.txbOverRebateAMT.ForeColor = System.Drawing.Color.Red
        Me.txbOverRebateAMT.Location = New System.Drawing.Point(431, 377)
        Me.txbOverRebateAMT.Name = "txbOverRebateAMT"
        Me.txbOverRebateAMT.ReadOnly = True
        Me.txbOverRebateAMT.Size = New System.Drawing.Size(122, 21)
        Me.txbOverRebateAMT.TabIndex = 9
        Me.txbOverRebateAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(556, 381)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(17, 12)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "元"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.rdbOK)
        Me.GroupBox3.Controls.Add(Me.txbReason)
        Me.GroupBox3.Controls.Add(Me.rdbFailure)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Location = New System.Drawing.Point(14, 404)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(473, 80)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "审核返点 Validate Discount:"
        '
        'rdbOK
        '
        Me.rdbOK.AutoSize = True
        Me.rdbOK.Location = New System.Drawing.Point(10, 48)
        Me.rdbOK.Name = "rdbOK"
        Me.rdbOK.Size = New System.Drawing.Size(71, 16)
        Me.rdbOK.TabIndex = 1
        Me.rdbOK.TabStop = True
        Me.rdbOK.Text = "&Approved"
        Me.rdbOK.UseVisualStyleBackColor = True
        '
        'txbReason
        '
        Me.txbReason.Enabled = False
        Me.txbReason.Location = New System.Drawing.Point(229, 45)
        Me.txbReason.MaxLength = 50
        Me.txbReason.Name = "txbReason"
        Me.txbReason.Size = New System.Drawing.Size(230, 21)
        Me.txbReason.TabIndex = 3
        '
        'rdbFailure
        '
        Me.rdbFailure.AutoSize = True
        Me.rdbFailure.Location = New System.Drawing.Point(82, 48)
        Me.rdbFailure.Name = "rdbFailure"
        Me.rdbFailure.Size = New System.Drawing.Size(149, 16)
        Me.rdbFailure.TabIndex = 2
        Me.rdbFailure.TabStop = True
        Me.rdbFailure.Text = "&Not approved, reason:"
        Me.rdbFailure.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(8, 23)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(359, 12)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Please approve or not the discount for current sales deal: "
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(497, 421)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(81, 23)
        Me.btnOK.TabIndex = 12
        Me.btnOK.Text = "确定 &OK    "
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(497, 450)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(81, 23)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "取消 &Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(12, 23)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(545, 12)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "City Discount Scale at the selling moment (Yellow line is applicable at the sales" & _
            " amount):"
        '
        'frmValidateDiscount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(594, 499)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txbOverRebateAMT)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvRule)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txbNormalSalesAMT)
        Me.Controls.Add(Me.Label10)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmValidateDiscount"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "请审核销售单返点 Please validate the discount of dealing:"
        CType(Me.dgvRule, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvRule As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txbNormalSalesAMT As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txbMaxNormalRebateAMT As System.Windows.Forms.TextBox
    Friend WithEvents txbMaxNormalRebateRate As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txbNormalRebateRate As System.Windows.Forms.TextBox
    Friend WithEvents txbOverRebateAMT As System.Windows.Forms.TextBox
    Friend WithEvents txbNormalRebateAMT As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents rdbOK As System.Windows.Forms.RadioButton
    Friend WithEvents txbReason As System.Windows.Forms.TextBox
    Friend WithEvents rdbFailure As System.Windows.Forms.RadioButton
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
End Class
