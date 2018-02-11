<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResetPassword
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmResetPassword))
        Me.lblPromptChinese = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblPassword = New System.Windows.Forms.Label
        Me.btnCopy = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.rtbNamePassword = New System.Windows.Forms.RichTextBox
        Me.lblPromptEnglish = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblUserName = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblPromptChinese
        '
        Me.lblPromptChinese.AutoSize = True
        Me.lblPromptChinese.Location = New System.Drawing.Point(53, 12)
        Me.lblPromptChinese.Name = "lblPromptChinese"
        Me.lblPromptChinese.Size = New System.Drawing.Size(413, 12)
        Me.lblPromptChinese.TabIndex = 0
        Me.lblPromptChinese.Text = "用户已通过审核，且系统已经为生生成初始密码。该用户名可以登录系统了。"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(53, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "密码  Password: "
        '
        'lblPassword
        '
        Me.lblPassword.BackColor = System.Drawing.SystemColors.Info
        Me.lblPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPassword.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblPassword.ForeColor = System.Drawing.Color.Red
        Me.lblPassword.Location = New System.Drawing.Point(160, 96)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(236, 23)
        Me.lblPassword.TabIndex = 5
        Me.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCopy
        '
        Me.btnCopy.Location = New System.Drawing.Point(402, 68)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(56, 51)
        Me.btnCopy.TabIndex = 6
        Me.btnCopy.Text = "拷贝" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "&Copy"
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(53, 150)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(233, 12)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "请将上面用户名和密码告诉对应的使用者。"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(53, 168)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(293, 12)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Please tell the user with above name && password."
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.btnOK.Location = New System.Drawing.Point(223, 196)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 10
        Me.btnOK.Text = "确定 &OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'rtbNamePassword
        '
        Me.rtbNamePassword.Font = New System.Drawing.Font("宋体", 12.0!)
        Me.rtbNamePassword.Location = New System.Drawing.Point(288, 122)
        Me.rtbNamePassword.Name = "rtbNamePassword"
        Me.rtbNamePassword.Size = New System.Drawing.Size(164, 23)
        Me.rtbNamePassword.TabIndex = 7
        Me.rtbNamePassword.Text = ""
        Me.rtbNamePassword.Visible = False
        '
        'lblPromptEnglish
        '
        Me.lblPromptEnglish.AutoSize = True
        Me.lblPromptEnglish.Location = New System.Drawing.Point(53, 32)
        Me.lblPromptEnglish.Name = "lblPromptEnglish"
        Me.lblPromptEnglish.Size = New System.Drawing.Size(431, 12)
        Me.lblPromptEnglish.TabIndex = 1
        Me.lblPromptEnglish.Text = "The user already had been validated with following intial password.    "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(53, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "用户 User Name: "
        '
        'lblUserName
        '
        Me.lblUserName.AutoEllipsis = True
        Me.lblUserName.BackColor = System.Drawing.SystemColors.Info
        Me.lblUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUserName.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblUserName.ForeColor = System.Drawing.Color.Red
        Me.lblUserName.Location = New System.Drawing.Point(160, 68)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(236, 23)
        Me.lblUserName.TabIndex = 3
        Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ShoppingCardSystem.My.Resources.Resources.Information
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'frmResetPassword
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(515, 231)
        Me.Controls.Add(Me.rtbNamePassword)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblUserName)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblPromptEnglish)
        Me.Controls.Add(Me.lblPromptChinese)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmResetPassword"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "用户已审核且已生成密码 User validated & password built."
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblPromptChinese As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents btnCopy As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents rtbNamePassword As System.Windows.Forms.RichTextBox
    Friend WithEvents lblPromptEnglish As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
End Class
