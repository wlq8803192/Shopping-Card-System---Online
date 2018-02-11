<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGiftCardOfflineActivationRequirement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGiftCardOfflineActivationRequirement))
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnHistory = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnQuery = New System.Windows.Forms.Button
        Me.txbCardNo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txbBarcode = New System.Windows.Forms.TextBox
        Me.grbResult = New System.Windows.Forms.GroupBox
        Me.lblResult = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        Me.lblCardNoError = New System.Windows.Forms.Label
        Me.lblBarcodeError = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txbTicketPosNo = New System.Windows.Forms.TextBox
        Me.dtpTicketDate = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.cbbTicketStoreCode = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txbTicketTransNo = New System.Windows.Forms.TextBox
        Me.tlpOptional = New System.Windows.Forms.TableLayoutPanel
        Me.pnlPrinting = New System.Windows.Forms.Panel
        Me.btnConfig = New System.Windows.Forms.Button
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.pnlTicketInfo = New System.Windows.Forms.Panel
        Me.grbResult.SuspendLayout()
        Me.tlpOptional.SuspendLayout()
        Me.pnlPrinting.SuspendLayout()
        Me.pnlTicketInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(505, 289)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "取消(&C)"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnHistory
        '
        Me.btnHistory.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHistory.Location = New System.Drawing.Point(394, 289)
        Me.btnHistory.Name = "btnHistory"
        Me.btnHistory.Size = New System.Drawing.Size(105, 23)
        Me.btnHistory.TabIndex = 13
        Me.btnHistory.Text = "查看历史记录(&H)"
        Me.btnHistory.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(-10, 274)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(619, 3)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'btnQuery
        '
        Me.btnQuery.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnQuery.Enabled = False
        Me.btnQuery.Location = New System.Drawing.Point(11, 289)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(115, 23)
        Me.btnQuery.TabIndex = 11
        Me.btnQuery.Text = "查询礼品卡状态(&Q)"
        Me.btnQuery.UseVisualStyleBackColor = True
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
        Me.Label3.Text = "请输入需要离线激活的礼品卡卡号(&N)："
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
        'grbResult
        '
        Me.grbResult.Controls.Add(Me.lblResult)
        Me.grbResult.Controls.Add(Me.lblStatus)
        Me.grbResult.Location = New System.Drawing.Point(13, 152)
        Me.grbResult.Name = "grbResult"
        Me.grbResult.Size = New System.Drawing.Size(567, 108)
        Me.grbResult.TabIndex = 9
        Me.grbResult.TabStop = False
        Me.grbResult.Text = "查询结果："
        Me.grbResult.Visible = False
        '
        'lblResult
        '
        Me.lblResult.Location = New System.Drawing.Point(17, 38)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(531, 60)
        Me.lblResult.TabIndex = 1
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(17, 20)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(191, 12)
        Me.lblStatus.TabIndex = 0
        Me.lblStatus.Text = "正在到CUL系统查询该卡的状态……"
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
        'lblBarcodeError
        '
        Me.lblBarcodeError.AutoSize = True
        Me.lblBarcodeError.ForeColor = System.Drawing.Color.Red
        Me.lblBarcodeError.Location = New System.Drawing.Point(360, 69)
        Me.lblBarcodeError.Name = "lblBarcodeError"
        Me.lblBarcodeError.Size = New System.Drawing.Size(0, 12)
        Me.lblBarcodeError.TabIndex = 7
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(62, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(419, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = """礼品卡离线激活""功能仅限当礼品卡在卖场收银线的POS机上激活失败时使用。"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(293, 12)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "请输入以下家乐福收银小票信息（用于激活后对账）："
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(0, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 12)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "交易日期(&D)："
        '
        'txbTicketPosNo
        '
        Me.txbTicketPosNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbTicketPosNo.Location = New System.Drawing.Point(396, 24)
        Me.txbTicketPosNo.MaxLength = 2
        Me.txbTicketPosNo.Name = "txbTicketPosNo"
        Me.txbTicketPosNo.Size = New System.Drawing.Size(26, 21)
        Me.txbTicketPosNo.TabIndex = 6
        '
        'dtpTicketDate
        '
        Me.dtpTicketDate.CustomFormat = "yyyy/MM/dd"
        Me.dtpTicketDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTicketDate.Location = New System.Drawing.Point(89, 24)
        Me.dtpTicketDate.Name = "dtpTicketDate"
        Me.dtpTicketDate.Size = New System.Drawing.Size(87, 21)
        Me.dtpTicketDate.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(182, 29)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 12)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "门店编号(&R)："
        '
        'cbbTicketStoreCode
        '
        Me.cbbTicketStoreCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbTicketStoreCode.FormattingEnabled = True
        Me.cbbTicketStoreCode.Location = New System.Drawing.Point(271, 24)
        Me.cbbTicketStoreCode.MaxDropDownItems = 20
        Me.cbbTicketStoreCode.Name = "cbbTicketStoreCode"
        Me.cbbTicketStoreCode.Size = New System.Drawing.Size(42, 20)
        Me.cbbTicketStoreCode.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(319, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 12)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "机台号(&M)："
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(428, 29)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(95, 12)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "交易流水号(&T)："
        '
        'txbTicketTransNo
        '
        Me.txbTicketTransNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbTicketTransNo.Location = New System.Drawing.Point(529, 25)
        Me.txbTicketTransNo.MaxLength = 5
        Me.txbTicketTransNo.Name = "txbTicketTransNo"
        Me.txbTicketTransNo.Size = New System.Drawing.Size(39, 21)
        Me.txbTicketTransNo.TabIndex = 8
        '
        'tlpOptional
        '
        Me.tlpOptional.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tlpOptional.AutoSize = True
        Me.tlpOptional.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpOptional.ColumnCount = 2
        Me.tlpOptional.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpOptional.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpOptional.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpOptional.Controls.Add(Me.pnlPrinting, 0, 0)
        Me.tlpOptional.Controls.Add(Me.btnSave, 0, 0)
        Me.tlpOptional.Location = New System.Drawing.Point(132, 289)
        Me.tlpOptional.Name = "tlpOptional"
        Me.tlpOptional.RowCount = 1
        Me.tlpOptional.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpOptional.Size = New System.Drawing.Size(256, 23)
        Me.tlpOptional.TabIndex = 12
        Me.tlpOptional.Visible = False
        '
        'pnlPrinting
        '
        Me.pnlPrinting.AutoSize = True
        Me.pnlPrinting.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlPrinting.Controls.Add(Me.btnConfig)
        Me.pnlPrinting.Controls.Add(Me.btnPrint)
        Me.pnlPrinting.Location = New System.Drawing.Point(109, 0)
        Me.pnlPrinting.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlPrinting.Name = "pnlPrinting"
        Me.pnlPrinting.Size = New System.Drawing.Size(147, 23)
        Me.pnlPrinting.TabIndex = 1
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
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(0, 0)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(0)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(105, 23)
        Me.btnPrint.TabIndex = 0
        Me.btnPrint.Text = "打印激活凭证(&P)"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(0, 0)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(0, 0, 6, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(103, 23)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "申请离线激活(&S)"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'pnlTicketInfo
        '
        Me.pnlTicketInfo.Controls.Add(Me.Label5)
        Me.pnlTicketInfo.Controls.Add(Me.Label6)
        Me.pnlTicketInfo.Controls.Add(Me.cbbTicketStoreCode)
        Me.pnlTicketInfo.Controls.Add(Me.Label7)
        Me.pnlTicketInfo.Controls.Add(Me.dtpTicketDate)
        Me.pnlTicketInfo.Controls.Add(Me.Label8)
        Me.pnlTicketInfo.Controls.Add(Me.txbTicketPosNo)
        Me.pnlTicketInfo.Controls.Add(Me.Label9)
        Me.pnlTicketInfo.Controls.Add(Me.txbTicketTransNo)
        Me.pnlTicketInfo.Location = New System.Drawing.Point(12, 97)
        Me.pnlTicketInfo.Name = "pnlTicketInfo"
        Me.pnlTicketInfo.Size = New System.Drawing.Size(568, 49)
        Me.pnlTicketInfo.TabIndex = 8
        Me.pnlTicketInfo.Visible = False
        '
        'frmGiftCardOfflineActivationRequirement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(594, 324)
        Me.Controls.Add(Me.pnlTicketInfo)
        Me.Controls.Add(Me.tlpOptional)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblBarcodeError)
        Me.Controls.Add(Me.lblCardNoError)
        Me.Controls.Add(Me.grbResult)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnQuery)
        Me.Controls.Add(Me.btnHistory)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txbBarcode)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txbCardNo)
        Me.Controls.Add(Me.Label3)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGiftCardOfflineActivationRequirement"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "礼品卡离线激活申请 Gift Card Off-line Activation Requirement"
        Me.grbResult.ResumeLayout(False)
        Me.grbResult.PerformLayout()
        Me.tlpOptional.ResumeLayout(False)
        Me.tlpOptional.PerformLayout()
        Me.pnlPrinting.ResumeLayout(False)
        Me.pnlTicketInfo.ResumeLayout(False)
        Me.pnlTicketInfo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnHistory As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnQuery As System.Windows.Forms.Button
    Friend WithEvents txbCardNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txbBarcode As System.Windows.Forms.TextBox
    Friend WithEvents grbResult As System.Windows.Forms.GroupBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblResult As System.Windows.Forms.Label
    Friend WithEvents lblCardNoError As System.Windows.Forms.Label
    Friend WithEvents lblBarcodeError As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txbTicketPosNo As System.Windows.Forms.TextBox
    Friend WithEvents dtpTicketDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbbTicketStoreCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txbTicketTransNo As System.Windows.Forms.TextBox
    Friend WithEvents tlpOptional As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents pnlPrinting As System.Windows.Forms.Panel
    Friend WithEvents btnConfig As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents pnlTicketInfo As System.Windows.Forms.Panel
End Class
