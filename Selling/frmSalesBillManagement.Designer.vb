<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSalesBillManagement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSalesBillManagement))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnOpen = New System.Windows.Forms.Button
        Me.lblOnly1 = New System.Windows.Forms.Label
        Me.cbbSalesBillState = New System.Windows.Forms.ComboBox
        Me.Split = New System.Windows.Forms.SplitContainer
        Me.btnSearch = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.trvArea = New System.Windows.Forms.TreeView
        Me.imlIcon = New System.Windows.Forms.ImageList(Me.components)
        Me.btnCheckAccount = New System.Windows.Forms.Button
        Me.btnAdjustSalesman = New System.Windows.Forms.Button
        Me.pnlConditions = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblSalesBillType = New System.Windows.Forms.Label
        Me.dtpSalesDate = New System.Windows.Forms.DateTimePicker
        Me.cbbSalesBillType = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.pnlOnlyInvalid = New System.Windows.Forms.Panel
        Me.chbOnlyInvalid = New System.Windows.Forms.CheckBox
        Me.lblOnly2 = New System.Windows.Forms.Label
        Me.lblTitle = New System.Windows.Forms.Label
        Me.btnValidateDiscount = New System.Windows.Forms.Button
        Me.dgvList = New System.Windows.Forms.DataGridView
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.Split.Panel1.SuspendLayout()
        Me.Split.Panel2.SuspendLayout()
        Me.Split.SuspendLayout()
        Me.pnlConditions.SuspendLayout()
        Me.pnlOnlyInvalid.SuspendLayout()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(177, 444)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(135, 23)
        Me.btnDelete.TabIndex = 6
        Me.btnDelete.Text = "Approve Cancel&lation"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(92, 444)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(79, 23)
        Me.btnAdd.TabIndex = 5
        Me.btnAdd.Text = "创建 &Create"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnOpen
        '
        Me.btnOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOpen.Enabled = False
        Me.btnOpen.Location = New System.Drawing.Point(7, 444)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(79, 23)
        Me.btnOpen.TabIndex = 4
        Me.btnOpen.Text = "打开 &Open"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'lblOnly1
        '
        Me.lblOnly1.AutoSize = True
        Me.lblOnly1.Location = New System.Drawing.Point(21, 3)
        Me.lblOnly1.Name = "lblOnly1"
        Me.lblOnly1.Size = New System.Drawing.Size(221, 12)
        Me.lblOnly1.TabIndex = 0
        Me.lblOnly1.Text = "仅显示所有城市返点未通过审核的销售单"
        '
        'cbbSalesBillState
        '
        Me.cbbSalesBillState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbSalesBillState.FormattingEnabled = True
        Me.cbbSalesBillState.Items.AddRange(New Object() {"（所有状态 All Types）", "等待激活 Inactivated ", "正在激活 Activating", "激活失败 Failure", "部分激活 Part Activated", "全部激活 Activated", "等待取消 to be Cancelled", "已撤销激活 Activation Cancelled"})
        Me.cbbSalesBillState.Location = New System.Drawing.Point(496, 5)
        Me.cbbSalesBillState.Name = "cbbSalesBillState"
        Me.cbbSalesBillState.Size = New System.Drawing.Size(153, 20)
        Me.cbbSalesBillState.TabIndex = 9
        '
        'Split
        '
        Me.Split.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Split.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.Split.Location = New System.Drawing.Point(0, 0)
        Me.Split.Name = "Split"
        '
        'Split.Panel1
        '
        Me.Split.Panel1.Controls.Add(Me.btnSearch)
        Me.Split.Panel1.Controls.Add(Me.Label1)
        Me.Split.Panel1.Controls.Add(Me.trvArea)
        '
        'Split.Panel2
        '
        Me.Split.Panel2.Controls.Add(Me.btnCheckAccount)
        Me.Split.Panel2.Controls.Add(Me.btnAdjustSalesman)
        Me.Split.Panel2.Controls.Add(Me.btnDelete)
        Me.Split.Panel2.Controls.Add(Me.pnlConditions)
        Me.Split.Panel2.Controls.Add(Me.pnlOnlyInvalid)
        Me.Split.Panel2.Controls.Add(Me.lblTitle)
        Me.Split.Panel2.Controls.Add(Me.btnValidateDiscount)
        Me.Split.Panel2.Controls.Add(Me.btnAdd)
        Me.Split.Panel2.Controls.Add(Me.btnOpen)
        Me.Split.Panel2.Controls.Add(Me.dgvList)
        Me.Split.Panel2.Controls.Add(Me.btnRefresh)
        Me.Split.Size = New System.Drawing.Size(786, 479)
        Me.Split.SplitterDistance = 260
        Me.Split.TabIndex = 2
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Location = New System.Drawing.Point(12, 444)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(90, 23)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "查找 Sea&rch"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "门店列表 Store List:"
        '
        'trvArea
        '
        Me.trvArea.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trvArea.ImageIndex = 0
        Me.trvArea.ImageList = Me.imlIcon
        Me.trvArea.ItemHeight = 18
        Me.trvArea.Location = New System.Drawing.Point(12, 34)
        Me.trvArea.Name = "trvArea"
        Me.trvArea.SelectedImageIndex = 0
        Me.trvArea.Size = New System.Drawing.Size(248, 399)
        Me.trvArea.TabIndex = 1
        '
        'imlIcon
        '
        Me.imlIcon.ImageStream = CType(resources.GetObject("imlIcon.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlIcon.TransparentColor = System.Drawing.Color.Transparent
        Me.imlIcon.Images.SetKeyName(0, "H")
        Me.imlIcon.Images.SetKeyName(1, "T")
        Me.imlIcon.Images.SetKeyName(2, "R")
        Me.imlIcon.Images.SetKeyName(3, "C")
        Me.imlIcon.Images.SetKeyName(4, "S")
        '
        'btnCheckAccount
        '
        Me.btnCheckAccount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCheckAccount.Location = New System.Drawing.Point(313, 444)
        Me.btnCheckAccount.Name = "btnCheckAccount"
        Me.btnCheckAccount.Size = New System.Drawing.Size(101, 23)
        Me.btnCheckAccount.TabIndex = 10
        Me.btnCheckAccount.Text = "对账报表 Chec&k"
        Me.btnCheckAccount.UseVisualStyleBackColor = True
        Me.btnCheckAccount.Visible = False
        '
        'btnAdjustSalesman
        '
        Me.btnAdjustSalesman.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAdjustSalesman.Enabled = False
        Me.btnAdjustSalesman.Location = New System.Drawing.Point(318, 444)
        Me.btnAdjustSalesman.Name = "btnAdjustSalesman"
        Me.btnAdjustSalesman.Size = New System.Drawing.Size(109, 23)
        Me.btnAdjustSalesman.TabIndex = 7
        Me.btnAdjustSalesman.Text = "Adjust Sales&man"
        Me.btnAdjustSalesman.UseVisualStyleBackColor = True
        '
        'pnlConditions
        '
        Me.pnlConditions.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlConditions.Controls.Add(Me.cbbSalesBillState)
        Me.pnlConditions.Controls.Add(Me.Label3)
        Me.pnlConditions.Controls.Add(Me.Label5)
        Me.pnlConditions.Controls.Add(Me.Label6)
        Me.pnlConditions.Controls.Add(Me.lblSalesBillType)
        Me.pnlConditions.Controls.Add(Me.dtpSalesDate)
        Me.pnlConditions.Controls.Add(Me.cbbSalesBillType)
        Me.pnlConditions.Controls.Add(Me.Label8)
        Me.pnlConditions.Controls.Add(Me.Label4)
        Me.pnlConditions.Controls.Add(Me.Label7)
        Me.pnlConditions.Location = New System.Drawing.Point(-139, 2)
        Me.pnlConditions.Name = "pnlConditions"
        Me.pnlConditions.Size = New System.Drawing.Size(653, 30)
        Me.pnlConditions.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 12)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "日期"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(450, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 12)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "状态"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(450, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 12)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "S&tatus:"
        '
        'lblSalesBillType
        '
        Me.lblSalesBillType.BackColor = System.Drawing.SystemColors.Window
        Me.lblSalesBillType.Location = New System.Drawing.Point(167, 7)
        Me.lblSalesBillType.Name = "lblSalesBillType"
        Me.lblSalesBillType.Size = New System.Drawing.Size(258, 14)
        Me.lblSalesBillType.TabIndex = 6
        Me.lblSalesBillType.Text = "（所有类型 All Types）"
        Me.lblSalesBillType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpSalesDate
        '
        Me.dtpSalesDate.CustomFormat = "yyyy/MM/dd"
        Me.dtpSalesDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSalesDate.Location = New System.Drawing.Point(38, 4)
        Me.dtpSalesDate.MinDate = New Date(2011, 1, 1, 0, 0, 0, 0)
        Me.dtpSalesDate.Name = "dtpSalesDate"
        Me.dtpSalesDate.Size = New System.Drawing.Size(85, 21)
        Me.dtpSalesDate.TabIndex = 2
        '
        'cbbSalesBillType
        '
        Me.cbbSalesBillType.FormattingEnabled = True
        'modify code 046:start-------------------------------------------------------------------------
        '添加实名制
        Me.cbbSalesBillType.Items.AddRange(New Object() {"（所有类型 All Types）", "1. 一般销售单 Normal Bill", "   1) 没有返点 No Discount", "   2) 城市返点 Normal Discount", "     (1) 不用审核 Don't Need Validate ", "     (2) 需要审核 Need Validate", "         ① 等待审核 Waiting to Validate", "         ② 审核失败 Validated Failure", "         ③ 审核成功 Validated Sucessfully", "   3) 合同返点 Contract Discount", "   4) 合同结余 Contract Balance", "2. 退货销售单 Returned Bill", "3. 活动卡销售单 Marketing Promotion", "4. 公关卡销售单 PR Card", "5. 员工销售单 Employee Bill", "6. 线下提卡销售单 Internet Selling", "7. 实名制卡销售单 SignCard Sales Bill"})
        'modify code 046:end-------------------------------------------------------------------------
        Me.cbbSalesBillType.Location = New System.Drawing.Point(164, 4)
        Me.cbbSalesBillType.MaxDropDownItems = 20
        Me.cbbSalesBillType.Name = "cbbSalesBillType"
        Me.cbbSalesBillType.Size = New System.Drawing.Size(280, 20)
        Me.cbbSalesBillType.TabIndex = 5
        Me.cbbSalesBillType.Text = "（所有类型 All Types）"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 12)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Da&te:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(129, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 12)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "类型"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(129, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 12)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "T&ype:"
        '
        'pnlOnlyInvalid
        '
        Me.pnlOnlyInvalid.Controls.Add(Me.chbOnlyInvalid)
        Me.pnlOnlyInvalid.Controls.Add(Me.lblOnly1)
        Me.pnlOnlyInvalid.Controls.Add(Me.lblOnly2)
        Me.pnlOnlyInvalid.Location = New System.Drawing.Point(8, 2)
        Me.pnlOnlyInvalid.Name = "pnlOnlyInvalid"
        Me.pnlOnlyInvalid.Size = New System.Drawing.Size(257, 30)
        Me.pnlOnlyInvalid.TabIndex = 1
        Me.pnlOnlyInvalid.Visible = False
        '
        'chbOnlyInvalid
        '
        Me.chbOnlyInvalid.AutoSize = True
        Me.chbOnlyInvalid.Location = New System.Drawing.Point(0, 9)
        Me.chbOnlyInvalid.Name = "chbOnlyInvalid"
        Me.chbOnlyInvalid.Size = New System.Drawing.Size(15, 14)
        Me.chbOnlyInvalid.TabIndex = 0
        Me.chbOnlyInvalid.UseVisualStyleBackColor = True
        '
        'lblOnly2
        '
        Me.lblOnly2.AutoSize = True
        Me.lblOnly2.Location = New System.Drawing.Point(21, 15)
        Me.lblOnly2.Name = "lblOnly2"
        Me.lblOnly2.Size = New System.Drawing.Size(233, 12)
        Me.lblOnly2.TabIndex = 1
        Me.lblOnly2.Text = "Only sales bills with pending discount"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Location = New System.Drawing.Point(6, 11)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(167, 12)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "销售单列表 Sales Bill List:"
        '
        'btnValidateDiscount
        '
        Me.btnValidateDiscount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnValidateDiscount.Enabled = False
        Me.btnValidateDiscount.Location = New System.Drawing.Point(433, 444)
        Me.btnValidateDiscount.Name = "btnValidateDiscount"
        Me.btnValidateDiscount.Size = New System.Drawing.Size(115, 23)
        Me.btnValidateDiscount.TabIndex = 8
        Me.btnValidateDiscount.Text = "&Validate Discount"
        Me.btnValidateDiscount.UseVisualStyleBackColor = True
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
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvList.ColumnHeadersHeight = 36
        Me.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvList.Location = New System.Drawing.Point(8, 34)
        Me.dgvList.MultiSelect = False
        Me.dgvList.Name = "dgvList"
        Me.dgvList.ReadOnly = True
        Me.dgvList.RowHeadersVisible = False
        Me.dgvList.RowTemplate.Height = 24
        Me.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvList.ShowRowErrors = False
        Me.dgvList.Size = New System.Drawing.Size(502, 399)
        Me.dgvList.TabIndex = 2
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.Location = New System.Drawing.Point(420, 444)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(90, 23)
        Me.btnRefresh.TabIndex = 9
        Me.btnRefresh.Text = "刷新 Re&fresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'frmSalesBillManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(786, 479)
        Me.Controls.Add(Me.Split)
        Me.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSalesBillManagement"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "销售单管理 Sales Bill Management"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.Split.Panel1.ResumeLayout(False)
        Me.Split.Panel1.PerformLayout()
        Me.Split.Panel2.ResumeLayout(False)
        Me.Split.Panel2.PerformLayout()
        Me.Split.ResumeLayout(False)
        Me.pnlConditions.ResumeLayout(False)
        Me.pnlConditions.PerformLayout()
        Me.pnlOnlyInvalid.ResumeLayout(False)
        Me.pnlOnlyInvalid.PerformLayout()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents lblOnly1 As System.Windows.Forms.Label
    Friend WithEvents cbbSalesBillState As System.Windows.Forms.ComboBox
    Friend WithEvents Split As System.Windows.Forms.SplitContainer
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents trvArea As System.Windows.Forms.TreeView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbbSalesBillType As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dgvList As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpSalesDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnAdjustSalesman As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnValidateDiscount As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblSalesBillType As System.Windows.Forms.Label
    Friend WithEvents chbOnlyInvalid As System.Windows.Forms.CheckBox
    Friend WithEvents lblOnly2 As System.Windows.Forms.Label
    Friend WithEvents pnlOnlyInvalid As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pnlConditions As System.Windows.Forms.Panel
    Friend WithEvents imlIcon As System.Windows.Forms.ImageList
    Friend WithEvents btnCheckAccount As System.Windows.Forms.Button
End Class
