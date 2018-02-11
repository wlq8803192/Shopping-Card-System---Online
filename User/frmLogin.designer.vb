<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txbPassword = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnLogin = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.txbUser = New System.Windows.Forms.TextBox
        Me.theTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnChangePassword = New System.Windows.Forms.Button
        Me.btnRequestResetPassword = New System.Windows.Forms.Button
        Me.cbbUser = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "用户 &UserName:"
        Me.theTip.SetToolTip(Me.Label1, "请输入用户编号或登录名称")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "密码 &Password:"
        '
        'txbPassword
        '
        Me.txbPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txbPassword.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbPassword.Location = New System.Drawing.Point(103, 44)
        Me.txbPassword.MaxLength = 20
        Me.txbPassword.Name = "txbPassword"
        Me.txbPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txbPassword.Size = New System.Drawing.Size(228, 21)
        Me.txbPassword.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(-12, 80)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(451, 4)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'btnLogin
        '
        Me.btnLogin.Location = New System.Drawing.Point(251, 97)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(80, 23)
        Me.btnLogin.TabIndex = 8
        Me.btnLogin.Text = "登录 &Login"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(337, 97)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 23)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "取消 &Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txbUser
        '
        Me.txbUser.Location = New System.Drawing.Point(103, 17)
        Me.txbUser.MaxLength = 60
        Me.txbUser.Name = "txbUser"
        Me.txbUser.Size = New System.Drawing.Size(228, 21)
        Me.txbUser.TabIndex = 1
        '
        'btnChangePassword
        '
        Me.btnChangePassword.Location = New System.Drawing.Point(337, 44)
        Me.btnChangePassword.Name = "btnChangePassword"
        Me.btnChangePassword.Size = New System.Drawing.Size(80, 23)
        Me.btnChangePassword.TabIndex = 5
        Me.btnChangePassword.Text = "更改 Cha&nge"
        Me.btnChangePassword.UseVisualStyleBackColor = True
        Me.btnChangePassword.Visible = False
        '
        'btnRequestResetPassword
        '
        Me.btnRequestResetPassword.Location = New System.Drawing.Point(12, 97)
        Me.btnRequestResetPassword.Name = "btnRequestResetPassword"
        Me.btnRequestResetPassword.Size = New System.Drawing.Size(87, 23)
        Me.btnRequestResetPassword.TabIndex = 7
        Me.btnRequestResetPassword.Text = "请求重置密码"
        Me.btnRequestResetPassword.UseVisualStyleBackColor = True
        Me.btnRequestResetPassword.Visible = False
        '
        'cbbUser
        '
        Me.cbbUser.Location = New System.Drawing.Point(103, 17)
        Me.cbbUser.MaxLength = 27
        Me.cbbUser.Name = "cbbUser"
        Me.cbbUser.Size = New System.Drawing.Size(228, 20)
        Me.cbbUser.TabIndex = 2
        Me.cbbUser.Visible = False
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(433, 132)
        Me.Controls.Add(Me.btnRequestResetPassword)
        Me.Controls.Add(Me.btnChangePassword)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txbPassword)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txbUser)
        Me.Controls.Add(Me.cbbUser)
        Me.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "登录系统 Login System"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txbPassword As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txbUser As System.Windows.Forms.TextBox
    Friend WithEvents theTip As System.Windows.Forms.ToolTip
    Friend WithEvents btnChangePassword As System.Windows.Forms.Button
    Friend WithEvents btnRequestResetPassword As System.Windows.Forms.Button
    Friend WithEvents cbbUser As System.Windows.Forms.ComboBox
End Class
