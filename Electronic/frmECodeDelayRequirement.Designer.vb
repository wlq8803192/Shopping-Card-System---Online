<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmECodeDelayRequirement
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
        Me.txtCardNo = New System.Windows.Forms.TextBox
        Me.lblCard = New System.Windows.Forms.Label
        Me.btnVerify = New System.Windows.Forms.Button
        Me.grbDetail = New System.Windows.Forms.GroupBox
        Me.txtOldDate = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtBalance = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.lblGetCodeResult = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtNewDate = New System.Windows.Forms.DateTimePicker
        Me.grbDetail.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtCardNo
        '
        Me.txtCardNo.Location = New System.Drawing.Point(87, 17)
        Me.txtCardNo.Name = "txtCardNo"
        Me.txtCardNo.Size = New System.Drawing.Size(185, 21)
        Me.txtCardNo.TabIndex = 22
        '
        'lblCard
        '
        Me.lblCard.AutoSize = True
        Me.lblCard.Location = New System.Drawing.Point(36, 21)
        Me.lblCard.Name = "lblCard"
        Me.lblCard.Size = New System.Drawing.Size(29, 12)
        Me.lblCard.TabIndex = 21
        Me.lblCard.Text = "卡号"
        '
        'btnVerify
        '
        Me.btnVerify.Location = New System.Drawing.Point(302, 17)
        Me.btnVerify.Name = "btnVerify"
        Me.btnVerify.Size = New System.Drawing.Size(44, 21)
        Me.btnVerify.TabIndex = 20
        Me.btnVerify.Text = "验证"
        Me.btnVerify.UseVisualStyleBackColor = True
        '
        'grbDetail
        '
        Me.grbDetail.Controls.Add(Me.txtOldDate)
        Me.grbDetail.Controls.Add(Me.Label10)
        Me.grbDetail.Controls.Add(Me.txtBalance)
        Me.grbDetail.Controls.Add(Me.Label9)
        Me.grbDetail.Enabled = False
        Me.grbDetail.Location = New System.Drawing.Point(12, 51)
        Me.grbDetail.Name = "grbDetail"
        Me.grbDetail.Size = New System.Drawing.Size(394, 60)
        Me.grbDetail.TabIndex = 23
        Me.grbDetail.TabStop = False
        Me.grbDetail.Text = "卡号信息"
        '
        'txtOldDate
        '
        Me.txtOldDate.Enabled = False
        Me.txtOldDate.Location = New System.Drawing.Point(259, 25)
        Me.txtOldDate.Name = "txtOldDate"
        Me.txtOldDate.Size = New System.Drawing.Size(107, 21)
        Me.txtOldDate.TabIndex = 24
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Enabled = False
        Me.Label10.Location = New System.Drawing.Point(198, 28)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 12)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "有效期"
        '
        'txtBalance
        '
        Me.txtBalance.Enabled = False
        Me.txtBalance.Location = New System.Drawing.Point(75, 25)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.Size = New System.Drawing.Size(107, 21)
        Me.txtBalance.TabIndex = 22
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Enabled = False
        Me.Label9.Location = New System.Drawing.Point(24, 28)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 12)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "余额"
        '
        'lblGetCodeResult
        '
        Me.lblGetCodeResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGetCodeResult.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblGetCodeResult.Location = New System.Drawing.Point(9, 163)
        Me.lblGetCodeResult.Name = "lblGetCodeResult"
        Me.lblGetCodeResult.Size = New System.Drawing.Size(394, 54)
        Me.lblGetCodeResult.TabIndex = 28
        Me.lblGetCodeResult.Text = "提取码验证成功！"
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnOK.Location = New System.Drawing.Point(120, 232)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(64, 21)
        Me.btnOK.TabIndex = 30
        Me.btnOK.Text = "确定"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(212, 232)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(64, 21)
        Me.btnCancel.TabIndex = 29
        Me.btnCancel.Text = "取消"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Location = New System.Drawing.Point(24, 133)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "有效期"
        '
        'txtNewDate
        '
        Me.txtNewDate.Enabled = False
        Me.txtNewDate.Location = New System.Drawing.Point(87, 127)
        Me.txtNewDate.Name = "txtNewDate"
        Me.txtNewDate.Size = New System.Drawing.Size(185, 21)
        Me.txtNewDate.TabIndex = 31
        '
        'frmECodeDelayRequirement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(417, 269)
        Me.Controls.Add(Me.txtNewDate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblGetCodeResult)
        Me.Controls.Add(Me.grbDetail)
        Me.Controls.Add(Me.txtCardNo)
        Me.Controls.Add(Me.lblCard)
        Me.Controls.Add(Me.btnVerify)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmECodeDelayRequirement"
        Me.Padding = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "电子码延期申请 ECode Delay Requirement"
        Me.grbDetail.ResumeLayout(False)
        Me.grbDetail.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCardNo As System.Windows.Forms.TextBox
    Friend WithEvents lblCard As System.Windows.Forms.Label
    Friend WithEvents btnVerify As System.Windows.Forms.Button
    Friend WithEvents grbDetail As System.Windows.Forms.GroupBox
    Friend WithEvents txtOldDate As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtBalance As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblGetCodeResult As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNewDate As System.Windows.Forms.DateTimePicker

End Class
