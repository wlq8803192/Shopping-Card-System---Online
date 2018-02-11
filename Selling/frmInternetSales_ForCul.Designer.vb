<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInternetSales_ForCul
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
        Me.btnVerify = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtExtractingCode = New System.Windows.Forms.TextBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.grbDetail = New System.Windows.Forms.GroupBox
        Me.txtBillBuyChannel = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtBillPayTotalAmount = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtBillTotalAmount = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtBillNo = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtStatus = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtHolderMobilePhone = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.grbCard = New System.Windows.Forms.GroupBox
        Me.txtProductNum = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtCardPrice = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtBillType = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblGetCodeResult = New System.Windows.Forms.Label
        Me.grbDetail.SuspendLayout()
        Me.grbCard.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnVerify
        '
        Me.btnVerify.Location = New System.Drawing.Point(323, 36)
        Me.btnVerify.Name = "btnVerify"
        Me.btnVerify.Size = New System.Drawing.Size(44, 23)
        Me.btnVerify.TabIndex = 1
        Me.btnVerify.Text = "验证"
        Me.btnVerify.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "提取码 "
        '
        'txtExtractingCode
        '
        Me.txtExtractingCode.Location = New System.Drawing.Point(111, 12)
        Me.txtExtractingCode.Name = "txtExtractingCode"
        Me.txtExtractingCode.Size = New System.Drawing.Size(185, 20)
        Me.txtExtractingCode.TabIndex = 3
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(232, 326)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(64, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "取消"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnOK.Location = New System.Drawing.Point(126, 326)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(64, 23)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "确定"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'grbDetail
        '
        Me.grbDetail.Controls.Add(Me.txtBillBuyChannel)
        Me.grbDetail.Controls.Add(Me.Label4)
        Me.grbDetail.Controls.Add(Me.txtBillPayTotalAmount)
        Me.grbDetail.Controls.Add(Me.Label10)
        Me.grbDetail.Controls.Add(Me.txtBillTotalAmount)
        Me.grbDetail.Controls.Add(Me.Label9)
        Me.grbDetail.Controls.Add(Me.txtBillNo)
        Me.grbDetail.Controls.Add(Me.Label8)
        Me.grbDetail.Controls.Add(Me.txtStatus)
        Me.grbDetail.Controls.Add(Me.Label2)
        Me.grbDetail.Enabled = False
        Me.grbDetail.Location = New System.Drawing.Point(10, 74)
        Me.grbDetail.Name = "grbDetail"
        Me.grbDetail.Size = New System.Drawing.Size(394, 110)
        Me.grbDetail.TabIndex = 12
        Me.grbDetail.TabStop = False
        Me.grbDetail.Text = "订单信息"
        '
        'txtBillBuyChannel
        '
        Me.txtBillBuyChannel.Location = New System.Drawing.Point(273, 23)
        Me.txtBillBuyChannel.Name = "txtBillBuyChannel"
        Me.txtBillBuyChannel.Size = New System.Drawing.Size(107, 20)
        Me.txtBillBuyChannel.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(212, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "购买渠道"
        '
        'txtBillPayTotalAmount
        '
        Me.txtBillPayTotalAmount.Location = New System.Drawing.Point(273, 75)
        Me.txtBillPayTotalAmount.Name = "txtBillPayTotalAmount"
        Me.txtBillPayTotalAmount.Size = New System.Drawing.Size(107, 20)
        Me.txtBillPayTotalAmount.TabIndex = 24
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(212, 78)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "支付金额"
        '
        'txtBillTotalAmount
        '
        Me.txtBillTotalAmount.Location = New System.Drawing.Point(89, 75)
        Me.txtBillTotalAmount.Name = "txtBillTotalAmount"
        Me.txtBillTotalAmount.Size = New System.Drawing.Size(107, 20)
        Me.txtBillTotalAmount.TabIndex = 22
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 78)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "订单金额"
        '
        'txtBillNo
        '
        Me.txtBillNo.Location = New System.Drawing.Point(89, 49)
        Me.txtBillNo.Name = "txtBillNo"
        Me.txtBillNo.Size = New System.Drawing.Size(291, 20)
        Me.txtBillNo.TabIndex = 20
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "订单号"
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(89, 23)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(107, 20)
        Me.txtStatus.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "提取码状态"
        '
        'txtHolderMobilePhone
        '
        Me.txtHolderMobilePhone.Location = New System.Drawing.Point(111, 38)
        Me.txtHolderMobilePhone.Name = "txtHolderMobilePhone"
        Me.txtHolderMobilePhone.Size = New System.Drawing.Size(185, 20)
        Me.txtHolderMobilePhone.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(26, 45)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "持卡人手机号"
        '
        'grbCard
        '
        Me.grbCard.Controls.Add(Me.txtProductNum)
        Me.grbCard.Controls.Add(Me.Label6)
        Me.grbCard.Controls.Add(Me.txtCardPrice)
        Me.grbCard.Controls.Add(Me.Label5)
        Me.grbCard.Controls.Add(Me.txtBillType)
        Me.grbCard.Controls.Add(Me.Label3)
        Me.grbCard.Enabled = False
        Me.grbCard.Location = New System.Drawing.Point(8, 190)
        Me.grbCard.Name = "grbCard"
        Me.grbCard.Size = New System.Drawing.Size(396, 59)
        Me.grbCard.TabIndex = 15
        Me.grbCard.TabStop = False
        Me.grbCard.Text = "换卡信息"
        '
        'txtProductNum
        '
        Me.txtProductNum.Location = New System.Drawing.Point(343, 23)
        Me.txtProductNum.Name = "txtProductNum"
        Me.txtProductNum.Size = New System.Drawing.Size(39, 20)
        Me.txtProductNum.TabIndex = 39
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(294, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "卡数量"
        '
        'txtCardPrice
        '
        Me.txtCardPrice.Location = New System.Drawing.Point(204, 23)
        Me.txtCardPrice.Name = "txtCardPrice"
        Me.txtCardPrice.Size = New System.Drawing.Size(84, 20)
        Me.txtCardPrice.TabIndex = 37
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(155, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "卡面值"
        '
        'txtBillType
        '
        Me.txtBillType.Location = New System.Drawing.Point(65, 23)
        Me.txtBillType.Name = "txtBillType"
        Me.txtBillType.Size = New System.Drawing.Size(84, 20)
        Me.txtBillType.TabIndex = 35
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "卡类型"
        '
        'lblGetCodeResult
        '
        Me.lblGetCodeResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGetCodeResult.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblGetCodeResult.Location = New System.Drawing.Point(10, 264)
        Me.lblGetCodeResult.Name = "lblGetCodeResult"
        Me.lblGetCodeResult.Size = New System.Drawing.Size(394, 59)
        Me.lblGetCodeResult.TabIndex = 16
        Me.lblGetCodeResult.Text = "提取码验证成功！"
        '
        'frmInternetSales_ForCul
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(416, 361)
        Me.Controls.Add(Me.lblGetCodeResult)
        Me.Controls.Add(Me.grbCard)
        Me.Controls.Add(Me.txtHolderMobilePhone)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.grbDetail)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtExtractingCode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnVerify)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInternetSales_ForCul"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "支付宝/微信验证："
        Me.grbDetail.ResumeLayout(False)
        Me.grbDetail.PerformLayout()
        Me.grbCard.ResumeLayout(False)
        Me.grbCard.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnVerify As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtExtractingCode As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents grbDetail As System.Windows.Forms.GroupBox
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtHolderMobilePhone As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtBillTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtBillNo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtBillBuyChannel As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtBillPayTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents grbCard As System.Windows.Forms.GroupBox
    Friend WithEvents txtProductNum As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCardPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtBillType As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblGetCodeResult As System.Windows.Forms.Label
End Class
