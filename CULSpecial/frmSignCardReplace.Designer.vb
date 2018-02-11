<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSignCardReplace
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSignCardReplace))
        Me.btnReplace = New System.Windows.Forms.Button
        Me.txtCardNo = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.radioFemale = New System.Windows.Forms.RadioButton
        Me.radioMale = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtMobile = New System.Windows.Forms.TextBox
        Me.txtName = New System.Windows.Forms.TextBox
        Me.txtHolderIdNo = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblError = New System.Windows.Forms.Label
        Me.btnHistory = New System.Windows.Forms.Button
        Me.txtNewCardNo = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblError2 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnReplace
        '
        Me.btnReplace.Location = New System.Drawing.Point(169, 284)
        Me.btnReplace.Name = "btnReplace"
        Me.btnReplace.Size = New System.Drawing.Size(89, 23)
        Me.btnReplace.TabIndex = 0
        Me.btnReplace.Text = "换新实名制卡"
        Me.btnReplace.UseVisualStyleBackColor = True
        '
        'txtCardNo
        '
        Me.txtCardNo.Location = New System.Drawing.Point(76, 12)
        Me.txtCardNo.MaxLength = 19
        Me.txtCardNo.Name = "txtCardNo"
        Me.txtCardNo.Size = New System.Drawing.Size(128, 20)
        Me.txtCardNo.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.radioFemale)
        Me.GroupBox1.Controls.Add(Me.radioMale)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtMobile)
        Me.GroupBox1.Controls.Add(Me.txtName)
        Me.GroupBox1.Controls.Add(Me.txtHolderIdNo)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 113)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(252, 159)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "个人信息"
        '
        'radioFemale
        '
        Me.radioFemale.AutoSize = True
        Me.radioFemale.Location = New System.Drawing.Point(132, 132)
        Me.radioFemale.Name = "radioFemale"
        Me.radioFemale.Size = New System.Drawing.Size(37, 17)
        Me.radioFemale.TabIndex = 12
        Me.radioFemale.Text = "女"
        Me.radioFemale.UseVisualStyleBackColor = True
        '
        'radioMale
        '
        Me.radioMale.AutoSize = True
        Me.radioMale.Checked = True
        Me.radioMale.Location = New System.Drawing.Point(76, 132)
        Me.radioMale.Name = "radioMale"
        Me.radioMale.Size = New System.Drawing.Size(37, 17)
        Me.radioMale.TabIndex = 11
        Me.radioMale.TabStop = True
        Me.radioMale.Text = "男"
        Me.radioMale.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 132)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "性别："
        '
        'txtMobile
        '
        Me.txtMobile.Location = New System.Drawing.Point(76, 93)
        Me.txtMobile.MaxLength = 11
        Me.txtMobile.Name = "txtMobile"
        Me.txtMobile.Size = New System.Drawing.Size(151, 20)
        Me.txtMobile.TabIndex = 9
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(76, 58)
        Me.txtName.MaxLength = 20
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(151, 20)
        Me.txtName.TabIndex = 8
        '
        'txtHolderIdNo
        '
        Me.txtHolderIdNo.Location = New System.Drawing.Point(76, 23)
        Me.txtHolderIdNo.MaxLength = 18
        Me.txtHolderIdNo.Name = "txtHolderIdNo"
        Me.txtHolderIdNo.Size = New System.Drawing.Size(151, 20)
        Me.txtHolderIdNo.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "手机："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "姓名："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "身份证："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "卡号："
        '
        'lblError
        '
        Me.lblError.AutoSize = True
        Me.lblError.ForeColor = System.Drawing.Color.Red
        Me.lblError.Location = New System.Drawing.Point(46, 40)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(39, 13)
        Me.lblError.TabIndex = 10
        Me.lblError.Text = "lblError"
        '
        'btnHistory
        '
        Me.btnHistory.Location = New System.Drawing.Point(74, 284)
        Me.btnHistory.Name = "btnHistory"
        Me.btnHistory.Size = New System.Drawing.Size(89, 23)
        Me.btnHistory.TabIndex = 12
        Me.btnHistory.Text = "查看历史记录"
        Me.btnHistory.UseVisualStyleBackColor = True
        '
        'txtNewCardNo
        '
        Me.txtNewCardNo.Location = New System.Drawing.Point(76, 61)
        Me.txtNewCardNo.Name = "txtNewCardNo"
        Me.txtNewCardNo.Size = New System.Drawing.Size(128, 20)
        Me.txtNewCardNo.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "新卡号："
        '
        'lblError2
        '
        Me.lblError2.AutoSize = True
        Me.lblError2.ForeColor = System.Drawing.Color.Red
        Me.lblError2.Location = New System.Drawing.Point(46, 89)
        Me.lblError2.Name = "lblError2"
        Me.lblError2.Size = New System.Drawing.Size(39, 13)
        Me.lblError2.TabIndex = 15
        Me.lblError2.Text = "lblError"
        '
        'frmSignCardReplace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(268, 314)
        Me.Controls.Add(Me.lblError2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtNewCardNo)
        Me.Controls.Add(Me.btnHistory)
        Me.Controls.Add(Me.lblError)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtCardNo)
        Me.Controls.Add(Me.btnReplace)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSignCardReplace"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "实名制卡查询"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnReplace As System.Windows.Forms.Button
    Friend WithEvents txtCardNo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblError As System.Windows.Forms.Label
    Friend WithEvents txtMobile As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtHolderIdNo As System.Windows.Forms.TextBox
    Friend WithEvents radioFemale As System.Windows.Forms.RadioButton
    Friend WithEvents radioMale As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnHistory As System.Windows.Forms.Button
    Friend WithEvents txtNewCardNo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblError2 As System.Windows.Forms.Label
End Class
