<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmECancelExtractingCodeRequirement
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
        Me.txtHolderMobilePhone = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtExtractingCode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnVerify = New System.Windows.Forms.Button
        Me.grbDetail = New System.Windows.Forms.GroupBox
        Me.txtCityName = New System.Windows.Forms.TextBox
        Me.lblCityName = New System.Windows.Forms.Label
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
        Me.lblGetCodeResult = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.grbDetail.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtHolderMobilePhone
        '
        Me.txtHolderMobilePhone.Location = New System.Drawing.Point(115, 40)
        Me.txtHolderMobilePhone.Name = "txtHolderMobilePhone"
        Me.txtHolderMobilePhone.Size = New System.Drawing.Size(185, 21)
        Me.txtHolderMobilePhone.TabIndex = 19
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(30, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 12)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "持卡人手机号"
        '
        'txtExtractingCode
        '
        Me.txtExtractingCode.Location = New System.Drawing.Point(115, 16)
        Me.txtExtractingCode.Name = "txtExtractingCode"
        Me.txtExtractingCode.Size = New System.Drawing.Size(185, 21)
        Me.txtExtractingCode.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 12)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "提取码 "
        '
        'btnVerify
        '
        Me.btnVerify.Location = New System.Drawing.Point(327, 38)
        Me.btnVerify.Name = "btnVerify"
        Me.btnVerify.Size = New System.Drawing.Size(44, 21)
        Me.btnVerify.TabIndex = 15
        Me.btnVerify.Text = "验证"
        Me.btnVerify.UseVisualStyleBackColor = True
        '
        'grbDetail
        '
        Me.grbDetail.Controls.Add(Me.txtCityName)
        Me.grbDetail.Controls.Add(Me.lblCityName)
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
        Me.grbDetail.Location = New System.Drawing.Point(12, 77)
        Me.grbDetail.Name = "grbDetail"
        Me.grbDetail.Size = New System.Drawing.Size(394, 102)
        Me.grbDetail.TabIndex = 20
        Me.grbDetail.TabStop = False
        Me.grbDetail.Text = "订单信息"
        '
        'txtCityName
        '
        Me.txtCityName.Location = New System.Drawing.Point(273, 21)
        Me.txtCityName.Name = "txtCityName"
        Me.txtCityName.Size = New System.Drawing.Size(107, 21)
        Me.txtCityName.TabIndex = 29
        '
        'lblCityName
        '
        Me.lblCityName.AutoSize = True
        Me.lblCityName.Location = New System.Drawing.Point(212, 24)
        Me.lblCityName.Name = "lblCityName"
        Me.lblCityName.Size = New System.Drawing.Size(53, 12)
        Me.lblCityName.TabIndex = 28
        Me.lblCityName.Text = "所属城市"
        '
        'txtBillBuyChannel
        '
        Me.txtBillBuyChannel.Location = New System.Drawing.Point(273, 45)
        Me.txtBillBuyChannel.Name = "txtBillBuyChannel"
        Me.txtBillBuyChannel.Size = New System.Drawing.Size(107, 21)
        Me.txtBillBuyChannel.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(212, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "购买渠道"
        '
        'txtBillPayTotalAmount
        '
        Me.txtBillPayTotalAmount.Location = New System.Drawing.Point(273, 69)
        Me.txtBillPayTotalAmount.Name = "txtBillPayTotalAmount"
        Me.txtBillPayTotalAmount.Size = New System.Drawing.Size(107, 21)
        Me.txtBillPayTotalAmount.TabIndex = 24
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(212, 72)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 12)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "支付金额"
        '
        'txtBillTotalAmount
        '
        Me.txtBillTotalAmount.Location = New System.Drawing.Point(89, 69)
        Me.txtBillTotalAmount.Name = "txtBillTotalAmount"
        Me.txtBillTotalAmount.Size = New System.Drawing.Size(107, 21)
        Me.txtBillTotalAmount.TabIndex = 22
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(28, 72)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 12)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "订单金额"
        '
        'txtBillNo
        '
        Me.txtBillNo.Location = New System.Drawing.Point(89, 45)
        Me.txtBillNo.Name = "txtBillNo"
        Me.txtBillNo.Size = New System.Drawing.Size(107, 21)
        Me.txtBillNo.TabIndex = 20
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(40, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 12)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "订单号"
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(89, 21)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(107, 21)
        Me.txtStatus.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "提取码状态"
        '
        'lblGetCodeResult
        '
        Me.lblGetCodeResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGetCodeResult.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblGetCodeResult.Location = New System.Drawing.Point(9, 193)
        Me.lblGetCodeResult.Name = "lblGetCodeResult"
        Me.lblGetCodeResult.Size = New System.Drawing.Size(397, 54)
        Me.lblGetCodeResult.TabIndex = 21
        Me.lblGetCodeResult.Text = "提取码验证成功！"
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnOK.Location = New System.Drawing.Point(115, 267)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(64, 21)
        Me.btnOK.TabIndex = 23
        Me.btnOK.Text = "提交申请"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(213, 267)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(64, 21)
        Me.btnCancel.TabIndex = 22
        Me.btnCancel.Text = "取消"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmECancelExtractingCodeRequirement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(417, 302)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblGetCodeResult)
        Me.Controls.Add(Me.grbDetail)
        Me.Controls.Add(Me.txtHolderMobilePhone)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtExtractingCode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnVerify)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmECancelExtractingCodeRequirement"
        Me.Padding = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "提取码作废申请 ECode Cancel Requirement"
        Me.grbDetail.ResumeLayout(False)
        Me.grbDetail.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtHolderMobilePhone As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtExtractingCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnVerify As System.Windows.Forms.Button
    Friend WithEvents grbDetail As System.Windows.Forms.GroupBox
    Friend WithEvents txtBillBuyChannel As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtBillPayTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtBillTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtBillNo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblGetCodeResult As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtCityName As System.Windows.Forms.TextBox
    Friend WithEvents lblCityName As System.Windows.Forms.Label

End Class
