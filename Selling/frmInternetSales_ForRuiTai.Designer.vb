<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInternetSales_ForRuiTai
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
        Me.txtCodePassword = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnVerify = New System.Windows.Forms.Button
        Me.grbDetail = New System.Windows.Forms.GroupBox
        Me.txtCodeType = New System.Windows.Forms.TextBox
        Me.txtValidDate = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCodeAmount = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.lblGetCodeResult = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.grbDetail.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtCodePassword
        '
        Me.txtCodePassword.Location = New System.Drawing.Point(99, 14)
        Me.txtCodePassword.Name = "txtCodePassword"
        Me.txtCodePassword.Size = New System.Drawing.Size(185, 20)
        Me.txtCodePassword.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "电子券密码"
        '
        'btnVerify
        '
        Me.btnVerify.Location = New System.Drawing.Point(302, 14)
        Me.btnVerify.Name = "btnVerify"
        Me.btnVerify.Size = New System.Drawing.Size(44, 23)
        Me.btnVerify.TabIndex = 4
        Me.btnVerify.Text = "验证"
        Me.btnVerify.UseVisualStyleBackColor = True
        '
        'grbDetail
        '
        Me.grbDetail.Controls.Add(Me.txtCodeType)
        Me.grbDetail.Controls.Add(Me.txtValidDate)
        Me.grbDetail.Controls.Add(Me.Label3)
        Me.grbDetail.Controls.Add(Me.Label2)
        Me.grbDetail.Controls.Add(Me.txtCodeAmount)
        Me.grbDetail.Controls.Add(Me.Label9)
        Me.grbDetail.Enabled = False
        Me.grbDetail.Location = New System.Drawing.Point(16, 51)
        Me.grbDetail.Name = "grbDetail"
        Me.grbDetail.Size = New System.Drawing.Size(345, 126)
        Me.grbDetail.TabIndex = 13
        Me.grbDetail.TabStop = False
        Me.grbDetail.Text = "电子券信息"
        '
        'txtCodeType
        '
        Me.txtCodeType.Location = New System.Drawing.Point(70, 94)
        Me.txtCodeType.Name = "txtCodeType"
        Me.txtCodeType.Size = New System.Drawing.Size(107, 20)
        Me.txtCodeType.TabIndex = 26
        '
        'txtValidDate
        '
        Me.txtValidDate.Location = New System.Drawing.Point(70, 62)
        Me.txtValidDate.Name = "txtValidDate"
        Me.txtValidDate.Size = New System.Drawing.Size(107, 20)
        Me.txtValidDate.TabIndex = 25
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "密码类型"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "有效期"
        '
        'txtCodeAmount
        '
        Me.txtCodeAmount.Location = New System.Drawing.Point(70, 30)
        Me.txtCodeAmount.Name = "txtCodeAmount"
        Me.txtCodeAmount.Size = New System.Drawing.Size(107, 20)
        Me.txtCodeAmount.TabIndex = 22
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(10, 33)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "金额"
        '
        'lblGetCodeResult
        '
        Me.lblGetCodeResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGetCodeResult.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblGetCodeResult.Location = New System.Drawing.Point(13, 192)
        Me.lblGetCodeResult.Name = "lblGetCodeResult"
        Me.lblGetCodeResult.Size = New System.Drawing.Size(348, 59)
        Me.lblGetCodeResult.TabIndex = 19
        Me.lblGetCodeResult.Text = "电子券验证成功！"
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnOK.Location = New System.Drawing.Point(105, 271)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(64, 23)
        Me.btnOK.TabIndex = 18
        Me.btnOK.Text = "确定"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(211, 271)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(64, 23)
        Me.btnCancel.TabIndex = 17
        Me.btnCancel.Text = "取消"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmInternetSales_ForRuiTai
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(375, 317)
        Me.Controls.Add(Me.lblGetCodeResult)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.grbDetail)
        Me.Controls.Add(Me.txtCodePassword)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnVerify)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInternetSales_ForRuiTai"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "瑞泰验证："
        Me.grbDetail.ResumeLayout(False)
        Me.grbDetail.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCodePassword As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnVerify As System.Windows.Forms.Button
    Friend WithEvents grbDetail As System.Windows.Forms.GroupBox
    Friend WithEvents txtCodeAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodeType As System.Windows.Forms.TextBox
    Friend WithEvents txtValidDate As System.Windows.Forms.TextBox
    Friend WithEvents lblGetCodeResult As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
