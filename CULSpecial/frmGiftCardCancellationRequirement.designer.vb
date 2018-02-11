<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGiftCardCancellationRequirement
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGiftCardCancellationRequirement))
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnHistory = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnRequest = New System.Windows.Forms.Button
        Me.txbCardNo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txbBarcode = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txbReason = New System.Windows.Forms.TextBox
        Me.grbResult = New System.Windows.Forms.GroupBox
        Me.lblResult = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        Me.lblCardNoError = New System.Windows.Forms.Label
        Me.dtpActivatedDate = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txbReferenceNo = New System.Windows.Forms.TextBox
        Me.lblBarcodeError = New System.Windows.Forms.Label
        Me.lblReferenceNoError = New System.Windows.Forms.Label
        Me.btnPrint = New System.Windows.Forms.Button
        Me.pnlPrinting = New System.Windows.Forms.Panel
        Me.btnConfig = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txbCardCost = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.grbResult.SuspendLayout()
        Me.pnlPrinting.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(507, 319)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 20
        Me.btnCancel.Text = "取消(&C)"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnHistory
        '
        Me.btnHistory.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHistory.Location = New System.Drawing.Point(396, 319)
        Me.btnHistory.Name = "btnHistory"
        Me.btnHistory.Size = New System.Drawing.Size(105, 23)
        Me.btnHistory.TabIndex = 19
        Me.btnHistory.Text = "查看历史记录(&H)"
        Me.btnHistory.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(-10, 304)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(619, 3)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        '
        'btnRequest
        '
        Me.btnRequest.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRequest.Enabled = False
        Me.btnRequest.Location = New System.Drawing.Point(11, 319)
        Me.btnRequest.Name = "btnRequest"
        Me.btnRequest.Size = New System.Drawing.Size(105, 23)
        Me.btnRequest.TabIndex = 17
        Me.btnRequest.Text = "申请激活撤销(&R)"
        Me.btnRequest.UseVisualStyleBackColor = True
        '
        'txbCardNo
        '
        Me.txbCardNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbCardNo.Location = New System.Drawing.Point(233, 37)
        Me.txbCardNo.MaxLength = 19
        Me.txbCardNo.Name = "txbCardNo"
        Me.txbCardNo.Size = New System.Drawing.Size(121, 21)
        Me.txbCardNo.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(215, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "请输入需要激活撤销的礼品卡卡号(&N)："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(215, 12)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "请输入礼品卡相对应的商品条形码(&B)："
        '
        'txbBarcode
        '
        Me.txbBarcode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbBarcode.Location = New System.Drawing.Point(233, 64)
        Me.txbBarcode.MaxLength = 13
        Me.txbBarcode.Name = "txbBarcode"
        Me.txbBarcode.Size = New System.Drawing.Size(121, 21)
        Me.txbBarcode.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 179)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(179, 12)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "请输入申请激活撤销的原因(&R)："
        '
        'txbReason
        '
        Me.txbReason.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txbReason.Location = New System.Drawing.Point(231, 174)
        Me.txbReason.MaxLength = 50
        Me.txbReason.Name = "txbReason"
        Me.txbReason.Size = New System.Drawing.Size(349, 21)
        Me.txbReason.TabIndex = 14
        '
        'grbResult
        '
        Me.grbResult.Controls.Add(Me.lblResult)
        Me.grbResult.Controls.Add(Me.lblStatus)
        Me.grbResult.Location = New System.Drawing.Point(11, 205)
        Me.grbResult.Name = "grbResult"
        Me.grbResult.Size = New System.Drawing.Size(567, 84)
        Me.grbResult.TabIndex = 15
        Me.grbResult.TabStop = False
        Me.grbResult.Text = "申请结果："
        Me.grbResult.Visible = False
        '
        'lblResult
        '
        Me.lblResult.Location = New System.Drawing.Point(17, 38)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(531, 38)
        Me.lblResult.TabIndex = 1
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(17, 20)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(251, 12)
        Me.lblStatus.TabIndex = 0
        Me.lblStatus.Text = "正在到CUL系统检查该卡是否可以撤销激活……"
        '
        'lblCardNoError
        '
        Me.lblCardNoError.AutoSize = True
        Me.lblCardNoError.ForeColor = System.Drawing.Color.Red
        Me.lblCardNoError.Location = New System.Drawing.Point(360, 42)
        Me.lblCardNoError.Name = "lblCardNoError"
        Me.lblCardNoError.Size = New System.Drawing.Size(0, 12)
        Me.lblCardNoError.TabIndex = 4
        '
        'dtpActivatedDate
        '
        Me.dtpActivatedDate.CustomFormat = "yyyy/MM/dd"
        Me.dtpActivatedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpActivatedDate.Location = New System.Drawing.Point(233, 91)
        Me.dtpActivatedDate.Name = "dtpActivatedDate"
        Me.dtpActivatedDate.Size = New System.Drawing.Size(121, 21)
        Me.dtpActivatedDate.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(191, 12)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "请输入礼品卡的交易激活日期(&D)："
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 123)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(179, 12)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "请输入礼品卡的交易参考号(&F)："
        '
        'txbReferenceNo
        '
        Me.txbReferenceNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbReferenceNo.Location = New System.Drawing.Point(233, 118)
        Me.txbReferenceNo.MaxLength = 12
        Me.txbReferenceNo.Name = "txbReferenceNo"
        Me.txbReferenceNo.Size = New System.Drawing.Size(121, 21)
        Me.txbReferenceNo.TabIndex = 11
        '
        'lblBarcodeError
        '
        Me.lblBarcodeError.AutoSize = True
        Me.lblBarcodeError.ForeColor = System.Drawing.Color.Red
        Me.lblBarcodeError.Location = New System.Drawing.Point(360, 69)
        Me.lblBarcodeError.Name = "lblBarcodeError"
        Me.lblBarcodeError.Size = New System.Drawing.Size(0, 12)
        Me.lblBarcodeError.TabIndex = 7
        '
        'lblReferenceNoError
        '
        Me.lblReferenceNoError.AutoSize = True
        Me.lblReferenceNoError.ForeColor = System.Drawing.Color.Red
        Me.lblReferenceNoError.Location = New System.Drawing.Point(360, 123)
        Me.lblReferenceNoError.Name = "lblReferenceNoError"
        Me.lblReferenceNoError.Size = New System.Drawing.Size(0, 12)
        Me.lblReferenceNoError.TabIndex = 12
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(0, 0)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(0)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(105, 23)
        Me.btnPrint.TabIndex = 0
        Me.btnPrint.Text = "打印撤销凭证(&P)"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'pnlPrinting
        '
        Me.pnlPrinting.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlPrinting.AutoSize = True
        Me.pnlPrinting.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlPrinting.Controls.Add(Me.btnConfig)
        Me.pnlPrinting.Controls.Add(Me.btnPrint)
        Me.pnlPrinting.Location = New System.Drawing.Point(122, 319)
        Me.pnlPrinting.Name = "pnlPrinting"
        Me.pnlPrinting.Size = New System.Drawing.Size(147, 23)
        Me.pnlPrinting.TabIndex = 18
        Me.pnlPrinting.Visible = False
        '
        'btnConfig
        '
        Me.btnConfig.Location = New System.Drawing.Point(110, 0)
        Me.btnConfig.Margin = New System.Windows.Forms.Padding(0)
        Me.btnConfig.Name = "btnConfig"
        Me.btnConfig.Size = New System.Drawing.Size(37, 23)
        Me.btnConfig.TabIndex = 1
        Me.btnConfig.Text = "设置"
        Me.btnConfig.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(62, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(383, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "该功能仅限当礼品卡是在卖场收银线的POS机上激活且想要撤销时使用。"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "说明："
        '
        'txbCardCost
        '
        Me.txbCardCost.Enabled = False
        Me.txbCardCost.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbCardCost.Location = New System.Drawing.Point(233, 145)
        Me.txbCardCost.MaxLength = 12
        Me.txbCardCost.Name = "txbCardCost"
        Me.txbCardCost.Size = New System.Drawing.Size(48, 21)
        Me.txbCardCost.TabIndex = 22
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 150)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(95, 12)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "请输入卡费(&C)："
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(287, 150)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(17, 12)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "元"
        '
        'frmGiftCardCancellationRequirement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(594, 354)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txbCardCost)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pnlPrinting)
        Me.Controls.Add(Me.dtpActivatedDate)
        Me.Controls.Add(Me.lblReferenceNoError)
        Me.Controls.Add(Me.lblBarcodeError)
        Me.Controls.Add(Me.lblCardNoError)
        Me.Controls.Add(Me.grbResult)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnRequest)
        Me.Controls.Add(Me.btnHistory)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txbReason)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txbReferenceNo)
        Me.Controls.Add(Me.txbBarcode)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txbCardNo)
        Me.Controls.Add(Me.Label3)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGiftCardCancellationRequirement"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "礼品卡激活撤销申请 Gift Card Activation Cancellation Requirement"
        Me.grbResult.ResumeLayout(False)
        Me.grbResult.PerformLayout()
        Me.pnlPrinting.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnHistory As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnRequest As System.Windows.Forms.Button
    Friend WithEvents txbCardNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txbBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txbReason As System.Windows.Forms.TextBox
    Friend WithEvents grbResult As System.Windows.Forms.GroupBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblResult As System.Windows.Forms.Label
    Friend WithEvents lblCardNoError As System.Windows.Forms.Label
    Friend WithEvents dtpActivatedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txbReferenceNo As System.Windows.Forms.TextBox
    Friend WithEvents lblBarcodeError As System.Windows.Forms.Label
    Friend WithEvents lblReferenceNoError As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents pnlPrinting As System.Windows.Forms.Panel
    Friend WithEvents btnConfig As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txbCardCost As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
