<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchSalesBill
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSearchSalesBill))
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.rdbByCardNo = New System.Windows.Forms.RadioButton
        Me.txbCardNo = New System.Windows.Forms.TextBox
        Me.rdbBySalesBillCode = New System.Windows.Forms.RadioButton
        Me.txbSalesBillCode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dgvList = New System.Windows.Forms.DataGridView
        Me.lblSearchResult = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnOpen = New System.Windows.Forms.Button
        Me.lblSalesBillCodeError = New System.Windows.Forms.Label
        Me.tlpOperation = New System.Windows.Forms.TableLayoutPanel
        Me.rdbByCustomerName = New System.Windows.Forms.RadioButton
        Me.txbCustomerName = New System.Windows.Forms.TextBox
        Me.cbbCustomerName = New System.Windows.Forms.ComboBox
        Me.pnlCustomer = New System.Windows.Forms.Panel
        Me.rdbByEmployeeNo = New System.Windows.Forms.RadioButton
        Me.txbEmployeeNo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.pnlCardNo = New System.Windows.Forms.Panel
        Me.lblCardNo = New System.Windows.Forms.Label
        Me.pnlEmployeeNo = New System.Windows.Forms.Panel
        Me.lblEmployeeNoError = New System.Windows.Forms.Label
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpOperation.SuspendLayout()
        Me.pnlCustomer.SuspendLayout()
        Me.pnlCardNo.SuspendLayout()
        Me.pnlEmployeeNo.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOK.AutoSize = True
        Me.btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(3, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.btnOK.Size = New System.Drawing.Size(81, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "查找 &Search"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(494, 345)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(85, 23)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "取消 &Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'rdbByCardNo
        '
        Me.rdbByCardNo.AutoSize = True
        Me.rdbByCardNo.Location = New System.Drawing.Point(12, 84)
        Me.rdbByCardNo.Name = "rdbByCardNo"
        Me.rdbByCardNo.Size = New System.Drawing.Size(191, 16)
        Me.rdbByCardNo.TabIndex = 6
        Me.rdbByCardNo.Text = "通过购物卡号 by Card Number:"
        Me.rdbByCardNo.UseVisualStyleBackColor = True
        '
        'txbCardNo
        '
        Me.txbCardNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txbCardNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbCardNo.Location = New System.Drawing.Point(0, 0)
        Me.txbCardNo.MaxLength = 19
        Me.txbCardNo.Name = "txbCardNo"
        Me.txbCardNo.Size = New System.Drawing.Size(125, 21)
        Me.txbCardNo.TabIndex = 0
        '
        'rdbBySalesBillCode
        '
        Me.rdbBySalesBillCode.AutoSize = True
        Me.rdbBySalesBillCode.Checked = True
        Me.rdbBySalesBillCode.Location = New System.Drawing.Point(12, 57)
        Me.rdbBySalesBillCode.Name = "rdbBySalesBillCode"
        Me.rdbBySalesBillCode.Size = New System.Drawing.Size(215, 16)
        Me.rdbBySalesBillCode.TabIndex = 3
        Me.rdbBySalesBillCode.TabStop = True
        Me.rdbBySalesBillCode.Text = "通过销售单号 by Sales Bill Code:"
        Me.rdbBySalesBillCode.UseVisualStyleBackColor = True
        '
        'txbSalesBillCode
        '
        Me.txbSalesBillCode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbSalesBillCode.Location = New System.Drawing.Point(235, 55)
        Me.txbSalesBillCode.MaxLength = 13
        Me.txbSalesBillCode.Name = "txbSalesBillCode"
        Me.txbSalesBillCode.Size = New System.Drawing.Size(125, 21)
        Me.txbSalesBillCode.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "请选择查找方式："
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(-5, 140)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(610, 4)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
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
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvList.ColumnHeadersHeight = 22
        Me.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvList.Location = New System.Drawing.Point(14, 171)
        Me.dgvList.MultiSelect = False
        Me.dgvList.Name = "dgvList"
        Me.dgvList.ReadOnly = True
        Me.dgvList.RowHeadersVisible = False
        Me.dgvList.RowTemplate.Height = 24
        Me.dgvList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvList.Size = New System.Drawing.Size(565, 144)
        Me.dgvList.StandardTab = True
        Me.dgvList.TabIndex = 13
        '
        'lblSearchResult
        '
        Me.lblSearchResult.AutoSize = True
        Me.lblSearchResult.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblSearchResult.Location = New System.Drawing.Point(12, 152)
        Me.lblSearchResult.Name = "lblSearchResult"
        Me.lblSearchResult.Size = New System.Drawing.Size(65, 12)
        Me.lblSearchResult.TabIndex = 12
        Me.lblSearchResult.Text = "查找结果："
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(-5, 328)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(610, 4)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        '
        'btnOpen
        '
        Me.btnOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOpen.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOpen.Enabled = False
        Me.btnOpen.Location = New System.Drawing.Point(90, 3)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(85, 23)
        Me.btnOpen.TabIndex = 1
        Me.btnOpen.Text = "打开 &Open"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'lblSalesBillCodeError
        '
        Me.lblSalesBillCodeError.AutoSize = True
        Me.lblSalesBillCodeError.ForeColor = System.Drawing.Color.Red
        Me.lblSalesBillCodeError.Location = New System.Drawing.Point(366, 60)
        Me.lblSalesBillCodeError.Name = "lblSalesBillCodeError"
        Me.lblSalesBillCodeError.Size = New System.Drawing.Size(0, 12)
        Me.lblSalesBillCodeError.TabIndex = 5
        '
        'tlpOperation
        '
        Me.tlpOperation.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tlpOperation.AutoSize = True
        Me.tlpOperation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpOperation.ColumnCount = 2
        Me.tlpOperation.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpOperation.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpOperation.Controls.Add(Me.btnOK, 0, 0)
        Me.tlpOperation.Controls.Add(Me.btnOpen, 1, 0)
        Me.tlpOperation.Location = New System.Drawing.Point(9, 342)
        Me.tlpOperation.Name = "tlpOperation"
        Me.tlpOperation.RowCount = 1
        Me.tlpOperation.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpOperation.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.tlpOperation.Size = New System.Drawing.Size(178, 29)
        Me.tlpOperation.TabIndex = 15
        '
        'rdbByCustomerName
        '
        Me.rdbByCustomerName.AutoSize = True
        Me.rdbByCustomerName.Location = New System.Drawing.Point(12, 30)
        Me.rdbByCustomerName.Name = "rdbByCustomerName"
        Me.rdbByCustomerName.Size = New System.Drawing.Size(221, 16)
        Me.rdbByCustomerName.TabIndex = 1
        Me.rdbByCustomerName.Text = "通过公司客户名称 by Company Name:"
        Me.rdbByCustomerName.UseVisualStyleBackColor = True
        '
        'txbCustomerName
        '
        Me.txbCustomerName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txbCustomerName.Location = New System.Drawing.Point(0, 0)
        Me.txbCustomerName.MaxLength = 100
        Me.txbCustomerName.Name = "txbCustomerName"
        Me.txbCustomerName.Size = New System.Drawing.Size(344, 21)
        Me.txbCustomerName.TabIndex = 0
        '
        'cbbCustomerName
        '
        Me.cbbCustomerName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbbCustomerName.FormattingEnabled = True
        Me.cbbCustomerName.Location = New System.Drawing.Point(0, 0)
        Me.cbbCustomerName.MaxDropDownItems = 30
        Me.cbbCustomerName.MaxLength = 100
        Me.cbbCustomerName.Name = "cbbCustomerName"
        Me.cbbCustomerName.Size = New System.Drawing.Size(344, 20)
        Me.cbbCustomerName.TabIndex = 1
        Me.cbbCustomerName.Visible = False
        '
        'pnlCustomer
        '
        Me.pnlCustomer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlCustomer.Controls.Add(Me.txbCustomerName)
        Me.pnlCustomer.Controls.Add(Me.cbbCustomerName)
        Me.pnlCustomer.Enabled = False
        Me.pnlCustomer.Location = New System.Drawing.Point(235, 28)
        Me.pnlCustomer.Name = "pnlCustomer"
        Me.pnlCustomer.Size = New System.Drawing.Size(344, 21)
        Me.pnlCustomer.TabIndex = 2
        '
        'rdbByEmployeeNo
        '
        Me.rdbByEmployeeNo.AutoSize = True
        Me.rdbByEmployeeNo.Location = New System.Drawing.Point(12, 111)
        Me.rdbByEmployeeNo.Name = "rdbByEmployeeNo"
        Me.rdbByEmployeeNo.Size = New System.Drawing.Size(215, 16)
        Me.rdbByEmployeeNo.TabIndex = 8
        Me.rdbByEmployeeNo.Text = "通过员工编号 by Employee Number:"
        Me.rdbByEmployeeNo.UseVisualStyleBackColor = True
        '
        'txbEmployeeNo
        '
        Me.txbEmployeeNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txbEmployeeNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbEmployeeNo.Location = New System.Drawing.Point(0, 0)
        Me.txbEmployeeNo.MaxLength = 10
        Me.txbEmployeeNo.Name = "txbEmployeeNo"
        Me.txbEmployeeNo.Size = New System.Drawing.Size(125, 21)
        Me.txbEmployeeNo.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(366, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 12)
        Me.Label2.TabIndex = 8
        '
        'pnlCardNo
        '
        Me.pnlCardNo.Controls.Add(Me.lblCardNo)
        Me.pnlCardNo.Controls.Add(Me.txbCardNo)
        Me.pnlCardNo.Enabled = False
        Me.pnlCardNo.Location = New System.Drawing.Point(235, 82)
        Me.pnlCardNo.Name = "pnlCardNo"
        Me.pnlCardNo.Size = New System.Drawing.Size(344, 21)
        Me.pnlCardNo.TabIndex = 7
        '
        'lblCardNo
        '
        Me.lblCardNo.AutoSize = True
        Me.lblCardNo.Location = New System.Drawing.Point(129, 4)
        Me.lblCardNo.Name = "lblCardNo"
        Me.lblCardNo.Size = New System.Drawing.Size(0, 12)
        Me.lblCardNo.TabIndex = 1
        '
        'pnlEmployeeNo
        '
        Me.pnlEmployeeNo.Controls.Add(Me.lblEmployeeNoError)
        Me.pnlEmployeeNo.Controls.Add(Me.txbEmployeeNo)
        Me.pnlEmployeeNo.Enabled = False
        Me.pnlEmployeeNo.Location = New System.Drawing.Point(235, 109)
        Me.pnlEmployeeNo.Name = "pnlEmployeeNo"
        Me.pnlEmployeeNo.Size = New System.Drawing.Size(344, 21)
        Me.pnlEmployeeNo.TabIndex = 9
        '
        'lblEmployeeNoError
        '
        Me.lblEmployeeNoError.AutoSize = True
        Me.lblEmployeeNoError.ForeColor = System.Drawing.Color.Red
        Me.lblEmployeeNoError.Location = New System.Drawing.Point(129, 4)
        Me.lblEmployeeNoError.Name = "lblEmployeeNoError"
        Me.lblEmployeeNoError.Size = New System.Drawing.Size(0, 12)
        Me.lblEmployeeNoError.TabIndex = 1
        '
        'frmSearchSalesBill
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(594, 380)
        Me.Controls.Add(Me.pnlEmployeeNo)
        Me.Controls.Add(Me.pnlCardNo)
        Me.Controls.Add(Me.pnlCustomer)
        Me.Controls.Add(Me.tlpOperation)
        Me.Controls.Add(Me.lblSalesBillCodeError)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblSearchResult)
        Me.Controls.Add(Me.dgvList)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txbSalesBillCode)
        Me.Controls.Add(Me.rdbByCustomerName)
        Me.Controls.Add(Me.rdbByEmployeeNo)
        Me.Controls.Add(Me.rdbBySalesBillCode)
        Me.Controls.Add(Me.rdbByCardNo)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSearchSalesBill"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "查找销售单 Search Sales Bill:"
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpOperation.ResumeLayout(False)
        Me.tlpOperation.PerformLayout()
        Me.pnlCustomer.ResumeLayout(False)
        Me.pnlCustomer.PerformLayout()
        Me.pnlCardNo.ResumeLayout(False)
        Me.pnlCardNo.PerformLayout()
        Me.pnlEmployeeNo.ResumeLayout(False)
        Me.pnlEmployeeNo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents rdbByCardNo As System.Windows.Forms.RadioButton
    Friend WithEvents txbCardNo As System.Windows.Forms.TextBox
    Friend WithEvents rdbBySalesBillCode As System.Windows.Forms.RadioButton
    Friend WithEvents txbSalesBillCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvList As System.Windows.Forms.DataGridView
    Friend WithEvents lblSearchResult As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents lblSalesBillCodeError As System.Windows.Forms.Label
    Friend WithEvents tlpOperation As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents rdbByCustomerName As System.Windows.Forms.RadioButton
    Friend WithEvents txbCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents cbbCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents pnlCustomer As System.Windows.Forms.Panel
    Friend WithEvents rdbByEmployeeNo As System.Windows.Forms.RadioButton
    Friend WithEvents txbEmployeeNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlCardNo As System.Windows.Forms.Panel
    Friend WithEvents lblCardNo As System.Windows.Forms.Label
    Friend WithEvents pnlEmployeeNo As System.Windows.Forms.Panel
    Friend WithEvents lblEmployeeNoError As System.Windows.Forms.Label
End Class
