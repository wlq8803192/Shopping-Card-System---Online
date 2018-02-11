<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchCustomer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSearchCustomer))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.rdbByCustomerCode = New System.Windows.Forms.RadioButton
        Me.txbCustomerCode = New System.Windows.Forms.TextBox
        Me.rdbByCustomerName = New System.Windows.Forms.RadioButton
        Me.txbCustomerName = New System.Windows.Forms.TextBox
        Me.rdbByPinYinCode = New System.Windows.Forms.RadioButton
        Me.txbPinYinCode = New System.Windows.Forms.TextBox
        Me.rdbByLinkman = New System.Windows.Forms.RadioButton
        Me.txbLinkman = New System.Windows.Forms.TextBox
        Me.rdbByTelMP = New System.Windows.Forms.RadioButton
        Me.txbTelMP = New System.Windows.Forms.TextBox
        Me.rdbByCompanyAddress = New System.Windows.Forms.RadioButton
        Me.txbCompanyAddress = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(-5, 209)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(432, 4)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(225, 226)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(85, 23)
        Me.btnOK.TabIndex = 13
        Me.btnOK.Text = "查找 &Search"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(316, 226)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(85, 23)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "取消 &Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'rdbByCustomerCode
        '
        Me.rdbByCustomerCode.AutoSize = True
        Me.rdbByCustomerCode.Location = New System.Drawing.Point(12, 17)
        Me.rdbByCustomerCode.Name = "rdbByCustomerCode"
        Me.rdbByCustomerCode.Size = New System.Drawing.Size(203, 16)
        Me.rdbByCustomerCode.TabIndex = 0
        Me.rdbByCustomerCode.Text = "通过客户编号 by Customer Code:"
        Me.rdbByCustomerCode.UseVisualStyleBackColor = True
        '
        'txbCustomerCode
        '
        Me.txbCustomerCode.Enabled = False
        Me.txbCustomerCode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbCustomerCode.Location = New System.Drawing.Point(240, 13)
        Me.txbCustomerCode.MaxLength = 9
        Me.txbCustomerCode.Name = "txbCustomerCode"
        Me.txbCustomerCode.Size = New System.Drawing.Size(161, 21)
        Me.txbCustomerCode.TabIndex = 1
        '
        'rdbByCustomerName
        '
        Me.rdbByCustomerName.AutoSize = True
        Me.rdbByCustomerName.Checked = True
        Me.rdbByCustomerName.Location = New System.Drawing.Point(12, 44)
        Me.rdbByCustomerName.Name = "rdbByCustomerName"
        Me.rdbByCustomerName.Size = New System.Drawing.Size(203, 16)
        Me.rdbByCustomerName.TabIndex = 2
        Me.rdbByCustomerName.TabStop = True
        Me.rdbByCustomerName.Text = "通过客户名称 by Customer Name:"
        Me.rdbByCustomerName.UseVisualStyleBackColor = True
        '
        'txbCustomerName
        '
        Me.txbCustomerName.Location = New System.Drawing.Point(240, 41)
        Me.txbCustomerName.MaxLength = 100
        Me.txbCustomerName.Name = "txbCustomerName"
        Me.txbCustomerName.Size = New System.Drawing.Size(161, 21)
        Me.txbCustomerName.TabIndex = 3
        '
        'rdbByPinYinCode
        '
        Me.rdbByPinYinCode.AutoSize = True
        Me.rdbByPinYinCode.Location = New System.Drawing.Point(12, 71)
        Me.rdbByPinYinCode.Name = "rdbByPinYinCode"
        Me.rdbByPinYinCode.Size = New System.Drawing.Size(203, 16)
        Me.rdbByPinYinCode.TabIndex = 4
        Me.rdbByPinYinCode.Text = "通过客户拼音码 by Pinyin Code:"
        Me.rdbByPinYinCode.UseVisualStyleBackColor = True
        '
        'txbPinYinCode
        '
        Me.txbPinYinCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txbPinYinCode.Enabled = False
        Me.txbPinYinCode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbPinYinCode.Location = New System.Drawing.Point(240, 69)
        Me.txbPinYinCode.MaxLength = 50
        Me.txbPinYinCode.Name = "txbPinYinCode"
        Me.txbPinYinCode.Size = New System.Drawing.Size(161, 21)
        Me.txbPinYinCode.TabIndex = 5
        '
        'rdbByLinkman
        '
        Me.rdbByLinkman.AutoSize = True
        Me.rdbByLinkman.Location = New System.Drawing.Point(12, 98)
        Me.rdbByLinkman.Name = "rdbByLinkman"
        Me.rdbByLinkman.Size = New System.Drawing.Size(227, 16)
        Me.rdbByLinkman.TabIndex = 6
        Me.rdbByLinkman.Text = "通过联系人姓名 by Contract Person:"
        Me.rdbByLinkman.UseVisualStyleBackColor = True
        '
        'txbLinkman
        '
        Me.txbLinkman.Enabled = False
        Me.txbLinkman.Location = New System.Drawing.Point(240, 97)
        Me.txbLinkman.MaxLength = 20
        Me.txbLinkman.Name = "txbLinkman"
        Me.txbLinkman.Size = New System.Drawing.Size(161, 21)
        Me.txbLinkman.TabIndex = 7
        '
        'rdbByTelMP
        '
        Me.rdbByTelMP.AutoSize = True
        Me.rdbByTelMP.Location = New System.Drawing.Point(12, 125)
        Me.rdbByTelMP.Name = "rdbByTelMP"
        Me.rdbByTelMP.Size = New System.Drawing.Size(221, 16)
        Me.rdbByTelMP.TabIndex = 8
        Me.rdbByTelMP.Text = "通过联系电话 by Telephone/Mobile:"
        Me.rdbByTelMP.UseVisualStyleBackColor = True
        '
        'txbTelMP
        '
        Me.txbTelMP.Enabled = False
        Me.txbTelMP.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbTelMP.Location = New System.Drawing.Point(240, 125)
        Me.txbTelMP.MaxLength = 20
        Me.txbTelMP.Name = "txbTelMP"
        Me.txbTelMP.Size = New System.Drawing.Size(161, 21)
        Me.txbTelMP.TabIndex = 9
        '
        'rdbByCompanyAddress
        '
        Me.rdbByCompanyAddress.AutoSize = True
        Me.rdbByCompanyAddress.Location = New System.Drawing.Point(12, 152)
        Me.rdbByCompanyAddress.Name = "rdbByCompanyAddress"
        Me.rdbByCompanyAddress.Size = New System.Drawing.Size(215, 16)
        Me.rdbByCompanyAddress.TabIndex = 10
        Me.rdbByCompanyAddress.Text = "通过公司地址 by Company Address:"
        Me.rdbByCompanyAddress.UseVisualStyleBackColor = True
        '
        'txbCompanyAddress
        '
        Me.txbCompanyAddress.Enabled = False
        Me.txbCompanyAddress.Location = New System.Drawing.Point(12, 174)
        Me.txbCompanyAddress.MaxLength = 255
        Me.txbCompanyAddress.Name = "txbCompanyAddress"
        Me.txbCompanyAddress.Size = New System.Drawing.Size(389, 21)
        Me.txbCompanyAddress.TabIndex = 11
        '
        'frmSearchCustomer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(416, 261)
        Me.Controls.Add(Me.txbCompanyAddress)
        Me.Controls.Add(Me.txbTelMP)
        Me.Controls.Add(Me.txbLinkman)
        Me.Controls.Add(Me.txbPinYinCode)
        Me.Controls.Add(Me.rdbByCompanyAddress)
        Me.Controls.Add(Me.rdbByTelMP)
        Me.Controls.Add(Me.rdbByLinkman)
        Me.Controls.Add(Me.txbCustomerName)
        Me.Controls.Add(Me.rdbByPinYinCode)
        Me.Controls.Add(Me.txbCustomerCode)
        Me.Controls.Add(Me.rdbByCustomerName)
        Me.Controls.Add(Me.rdbByCustomerCode)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSearchCustomer"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "查找客户 Search Customer:"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents rdbByCustomerCode As System.Windows.Forms.RadioButton
    Friend WithEvents txbCustomerCode As System.Windows.Forms.TextBox
    Friend WithEvents rdbByCustomerName As System.Windows.Forms.RadioButton
    Friend WithEvents txbCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents rdbByPinYinCode As System.Windows.Forms.RadioButton
    Friend WithEvents txbPinYinCode As System.Windows.Forms.TextBox
    Friend WithEvents rdbByLinkman As System.Windows.Forms.RadioButton
    Friend WithEvents txbLinkman As System.Windows.Forms.TextBox
    Friend WithEvents rdbByTelMP As System.Windows.Forms.RadioButton
    Friend WithEvents txbTelMP As System.Windows.Forms.TextBox
    Friend WithEvents rdbByCompanyAddress As System.Windows.Forms.RadioButton
    Friend WithEvents txbCompanyAddress As System.Windows.Forms.TextBox
End Class
