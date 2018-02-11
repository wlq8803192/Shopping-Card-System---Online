<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInternetSalesInvoice
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
        Me.txtBillNo = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.btnVerify = New System.Windows.Forms.Button
        Me.grbDetail = New System.Windows.Forms.GroupBox
        Me.txtBillPayTotalAmount = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtBillTotalAmount = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.grbCustom = New System.Windows.Forms.GroupBox
        Me.grbCompany = New System.Windows.Forms.GroupBox
        Me.cbbCustomerName = New System.Windows.Forms.ComboBox
        Me.btnNewCustomer = New System.Windows.Forms.Button
        Me.rdo1 = New System.Windows.Forms.RadioButton
        Me.rdo0 = New System.Windows.Forms.RadioButton
        Me.txtTitle = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.lblGetBillResult = New System.Windows.Forms.Label
        Me.btnTest = New System.Windows.Forms.Button
        Me.btnConfigInvoice = New System.Windows.Forms.Button
        Me.grbInvoiceDevice = New System.Windows.Forms.GroupBox
        Me.txtInvoiceNo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.grbDetail.SuspendLayout()
        Me.grbCustom.SuspendLayout()
        Me.grbCompany.SuspendLayout()
        Me.grbInvoiceDevice.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtBillNo
        '
        Me.txtBillNo.Location = New System.Drawing.Point(60, 12)
        Me.txtBillNo.Name = "txtBillNo"
        Me.txtBillNo.Size = New System.Drawing.Size(291, 20)
        Me.txtBillNo.TabIndex = 22
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "订单号"
        '
        'btnVerify
        '
        Me.btnVerify.Location = New System.Drawing.Point(366, 10)
        Me.btnVerify.Name = "btnVerify"
        Me.btnVerify.Size = New System.Drawing.Size(44, 23)
        Me.btnVerify.TabIndex = 23
        Me.btnVerify.Text = "验证"
        Me.btnVerify.UseVisualStyleBackColor = True
        '
        'grbDetail
        '
        Me.grbDetail.Controls.Add(Me.txtBillPayTotalAmount)
        Me.grbDetail.Controls.Add(Me.Label10)
        Me.grbDetail.Controls.Add(Me.txtBillTotalAmount)
        Me.grbDetail.Controls.Add(Me.Label9)
        Me.grbDetail.Enabled = False
        Me.grbDetail.Location = New System.Drawing.Point(14, 39)
        Me.grbDetail.Name = "grbDetail"
        Me.grbDetail.Size = New System.Drawing.Size(394, 54)
        Me.grbDetail.TabIndex = 24
        Me.grbDetail.TabStop = False
        Me.grbDetail.Text = "订单信息"
        '
        'txtBillPayTotalAmount
        '
        Me.txtBillPayTotalAmount.Location = New System.Drawing.Point(269, 19)
        Me.txtBillPayTotalAmount.Name = "txtBillPayTotalAmount"
        Me.txtBillPayTotalAmount.Size = New System.Drawing.Size(107, 20)
        Me.txtBillPayTotalAmount.TabIndex = 24
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(208, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "支付金额"
        '
        'txtBillTotalAmount
        '
        Me.txtBillTotalAmount.Location = New System.Drawing.Point(85, 19)
        Me.txtBillTotalAmount.Name = "txtBillTotalAmount"
        Me.txtBillTotalAmount.Size = New System.Drawing.Size(107, 20)
        Me.txtBillTotalAmount.TabIndex = 22
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(10, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "订单金额"
        '
        'grbCustom
        '
        Me.grbCustom.Controls.Add(Me.grbCompany)
        Me.grbCustom.Controls.Add(Me.rdo1)
        Me.grbCustom.Controls.Add(Me.rdo0)
        Me.grbCustom.Controls.Add(Me.txtTitle)
        Me.grbCustom.Controls.Add(Me.Label1)
        Me.grbCustom.Location = New System.Drawing.Point(14, 163)
        Me.grbCustom.Name = "grbCustom"
        Me.grbCustom.Size = New System.Drawing.Size(394, 145)
        Me.grbCustom.TabIndex = 25
        Me.grbCustom.TabStop = False
        Me.grbCustom.Text = "本地开票自定义信息"
        '
        'grbCompany
        '
        Me.grbCompany.Controls.Add(Me.cbbCustomerName)
        Me.grbCompany.Controls.Add(Me.btnNewCustomer)
        Me.grbCompany.Location = New System.Drawing.Point(13, 51)
        Me.grbCompany.Name = "grbCompany"
        Me.grbCompany.Size = New System.Drawing.Size(363, 57)
        Me.grbCompany.TabIndex = 30
        Me.grbCompany.TabStop = False
        Me.grbCompany.Text = "请输入公司名称："
        '
        'cbbCustomerName
        '
        Me.cbbCustomerName.FormattingEnabled = True
        Me.cbbCustomerName.Location = New System.Drawing.Point(6, 19)
        Me.cbbCustomerName.Name = "cbbCustomerName"
        Me.cbbCustomerName.Size = New System.Drawing.Size(297, 21)
        Me.cbbCustomerName.TabIndex = 32
        '
        'btnNewCustomer
        '
        Me.btnNewCustomer.Location = New System.Drawing.Point(309, 17)
        Me.btnNewCustomer.Name = "btnNewCustomer"
        Me.btnNewCustomer.Size = New System.Drawing.Size(48, 23)
        Me.btnNewCustomer.TabIndex = 30
        Me.btnNewCustomer.Text = "新建"
        Me.btnNewCustomer.UseVisualStyleBackColor = True
        '
        'rdo1
        '
        Me.rdo1.AutoSize = True
        Me.rdo1.Location = New System.Drawing.Point(85, 28)
        Me.rdo1.Name = "rdo1"
        Me.rdo1.Size = New System.Drawing.Size(49, 17)
        Me.rdo1.TabIndex = 26
        Me.rdo1.Text = "公司"
        Me.rdo1.UseVisualStyleBackColor = True
        '
        'rdo0
        '
        Me.rdo0.AutoSize = True
        Me.rdo0.Checked = True
        Me.rdo0.Location = New System.Drawing.Point(13, 28)
        Me.rdo0.Name = "rdo0"
        Me.rdo0.Size = New System.Drawing.Size(49, 17)
        Me.rdo0.TabIndex = 25
        Me.rdo0.TabStop = True
        Me.rdo0.Text = "个人"
        Me.rdo0.UseVisualStyleBackColor = True
        '
        'txtTitle
        '
        Me.txtTitle.Enabled = False
        Me.txtTitle.Location = New System.Drawing.Point(85, 114)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(291, 20)
        Me.txtTitle.TabIndex = 24
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 117)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "发票抬头"
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnOK.Location = New System.Drawing.Point(60, 415)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 23)
        Me.btnOK.TabIndex = 27
        Me.btnOK.Text = "打印发票"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(223, 415)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(64, 23)
        Me.btnCancel.TabIndex = 26
        Me.btnCancel.Text = "取消"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblGetBillResult
        '
        Me.lblGetBillResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGetBillResult.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblGetBillResult.Location = New System.Drawing.Point(12, 322)
        Me.lblGetBillResult.Name = "lblGetBillResult"
        Me.lblGetBillResult.Size = New System.Drawing.Size(398, 76)
        Me.lblGetBillResult.TabIndex = 28
        Me.lblGetBillResult.Text = "提取码验证成功！"
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(336, 415)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(72, 23)
        Me.btnTest.TabIndex = 29
        Me.btnTest.Text = "连接测试"
        Me.btnTest.UseVisualStyleBackColor = True
        Me.btnTest.Visible = False
        '
        'btnConfigInvoice
        '
        Me.btnConfigInvoice.Location = New System.Drawing.Point(153, 415)
        Me.btnConfigInvoice.Margin = New System.Windows.Forms.Padding(2)
        Me.btnConfigInvoice.Name = "btnConfigInvoice"
        Me.btnConfigInvoice.Size = New System.Drawing.Size(65, 23)
        Me.btnConfigInvoice.TabIndex = 30
        Me.btnConfigInvoice.Text = "设置"
        Me.btnConfigInvoice.UseVisualStyleBackColor = True
        '
        'grbInvoiceDevice
        '
        Me.grbInvoiceDevice.Controls.Add(Me.txtInvoiceNo)
        Me.grbInvoiceDevice.Controls.Add(Me.Label2)
        Me.grbInvoiceDevice.Location = New System.Drawing.Point(14, 99)
        Me.grbInvoiceDevice.Name = "grbInvoiceDevice"
        Me.grbInvoiceDevice.Size = New System.Drawing.Size(396, 58)
        Me.grbInvoiceDevice.TabIndex = 31
        Me.grbInvoiceDevice.TabStop = False
        Me.grbInvoiceDevice.Text = "第三方开票信息"
        '
        'txtInvoiceNo
        '
        Me.txtInvoiceNo.Location = New System.Drawing.Point(85, 23)
        Me.txtInvoiceNo.Name = "txtInvoiceNo"
        Me.txtInvoiceNo.Size = New System.Drawing.Size(291, 20)
        Me.txtInvoiceNo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "发票号"
        '
        'frmInternetSalesInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(428, 449)
        Me.Controls.Add(Me.grbInvoiceDevice)
        Me.Controls.Add(Me.btnConfigInvoice)
        Me.Controls.Add(Me.btnTest)
        Me.Controls.Add(Me.lblGetBillResult)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.grbCustom)
        Me.Controls.Add(Me.grbDetail)
        Me.Controls.Add(Me.btnVerify)
        Me.Controls.Add(Me.txtBillNo)
        Me.Controls.Add(Me.Label8)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInternetSalesInvoice"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "电子卡开票"
        Me.grbDetail.ResumeLayout(False)
        Me.grbDetail.PerformLayout()
        Me.grbCustom.ResumeLayout(False)
        Me.grbCustom.PerformLayout()
        Me.grbCompany.ResumeLayout(False)
        Me.grbInvoiceDevice.ResumeLayout(False)
        Me.grbInvoiceDevice.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtBillNo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnVerify As System.Windows.Forms.Button
    Friend WithEvents grbDetail As System.Windows.Forms.GroupBox
    Friend WithEvents txtBillPayTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtBillTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents grbCustom As System.Windows.Forms.GroupBox
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblGetBillResult As System.Windows.Forms.Label
    Friend WithEvents btnTest As System.Windows.Forms.Button
    Friend WithEvents rdo0 As System.Windows.Forms.RadioButton
    Friend WithEvents rdo1 As System.Windows.Forms.RadioButton
    Friend WithEvents grbCompany As System.Windows.Forms.GroupBox
    Friend WithEvents btnNewCustomer As System.Windows.Forms.Button
    Friend WithEvents cbbCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents btnConfigInvoice As System.Windows.Forms.Button
    Friend WithEvents grbInvoiceDevice As System.Windows.Forms.GroupBox
    Friend WithEvents txtInvoiceNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
