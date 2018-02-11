<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChangePassword
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChangePassword))
        Me.Label7 = New System.Windows.Forms.Label
        Me.txbNewPassword = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.theTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.txbUser = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txbConfirmedPassword = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txbOldPassword = New System.Windows.Forms.TextBox
        Me.lblNewErrorChinese = New System.Windows.Forms.Label
        Me.lblConfirmedErrorChinese = New System.Windows.Forms.Label
        Me.lblOldErrorChinese = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cbbUser = New System.Windows.Forms.ComboBox
        Me.lblOldErrorEnglish = New System.Windows.Forms.Label
        Me.lblNewErrorEnglish = New System.Windows.Forms.Label
        Me.lblConfirmedErrorEnglish = New System.Windows.Forms.Label
        Me.pcbNewStrong = New System.Windows.Forms.PictureBox
        Me.pcbNewMedium = New System.Windows.Forms.PictureBox
        Me.pcbNewWeak = New System.Windows.Forms.PictureBox
        Me.pcbNewDisallowed = New System.Windows.Forms.PictureBox
        Me.lblNewDisallowed = New System.Windows.Forms.Label
        Me.lblNewWeak = New System.Windows.Forms.Label
        Me.lblNewMedium = New System.Windows.Forms.Label
        Me.lblNewStrong = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.pcbOldDisallowed = New System.Windows.Forms.PictureBox
        Me.pcbOldWeak = New System.Windows.Forms.PictureBox
        Me.pcbOldMedium = New System.Windows.Forms.PictureBox
        Me.pcbOldStrong = New System.Windows.Forms.PictureBox
        Me.lblOldDisallowed = New System.Windows.Forms.Label
        Me.lblOldWeak = New System.Windows.Forms.Label
        Me.lblOldMedium = New System.Windows.Forms.Label
        Me.lblOldStrong = New System.Windows.Forms.Label
        Me.flpContainer = New System.Windows.Forms.FlowLayoutPanel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.pnlOldStrength = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.pnlNewStrength = New System.Windows.Forms.Panel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.pnlButtom = New System.Windows.Forms.Panel
        CType(Me.pcbNewStrong, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcbNewMedium, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcbNewWeak, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcbNewDisallowed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcbOldDisallowed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcbOldWeak, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcbOldMedium, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcbOldStrong, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flpContainer.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlOldStrength.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlNewStrength.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlButtom.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 4)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 12)
        Me.Label7.TabIndex = 0
        Me.Label7.Tag = "6"
        Me.Label7.Text = "新密码"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txbNewPassword
        '
        Me.txbNewPassword.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbNewPassword.Location = New System.Drawing.Point(127, 6)
        Me.txbNewPassword.MaxLength = 20
        Me.txbNewPassword.Name = "txbNewPassword"
        Me.txbNewPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txbNewPassword.Size = New System.Drawing.Size(228, 21)
        Me.txbNewPassword.TabIndex = 2
        Me.txbNewPassword.Tag = "7"
        '
        'GroupBox1
        '
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(-1, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(510, 4)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'btnOK
        '
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(293, 21)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "确定(&O)"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(374, 21)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "取消(&C)"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "用户名"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.theTip.SetToolTip(Me.Label1, "请输入用户编号或登录名称")
        '
        'txbUser
        '
        Me.txbUser.Location = New System.Drawing.Point(127, 6)
        Me.txbUser.MaxLength = 60
        Me.txbUser.Name = "txbUser"
        Me.txbUser.Size = New System.Drawing.Size(228, 21)
        Me.txbUser.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 4)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 12)
        Me.Label11.TabIndex = 0
        Me.Label11.Tag = "8"
        Me.Label11.Text = "确认密码"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txbConfirmedPassword
        '
        Me.txbConfirmedPassword.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbConfirmedPassword.Location = New System.Drawing.Point(127, 6)
        Me.txbConfirmedPassword.MaxLength = 20
        Me.txbConfirmedPassword.Name = "txbConfirmedPassword"
        Me.txbConfirmedPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txbConfirmedPassword.Size = New System.Drawing.Size(228, 21)
        Me.txbConfirmedPassword.TabIndex = 2
        Me.txbConfirmedPassword.Tag = "9"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 12)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Ol&d Password:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txbOldPassword
        '
        Me.txbOldPassword.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbOldPassword.Location = New System.Drawing.Point(127, 6)
        Me.txbOldPassword.MaxLength = 20
        Me.txbOldPassword.Name = "txbOldPassword"
        Me.txbOldPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txbOldPassword.Size = New System.Drawing.Size(228, 21)
        Me.txbOldPassword.TabIndex = 2
        '
        'lblNewErrorChinese
        '
        Me.lblNewErrorChinese.AutoSize = True
        Me.lblNewErrorChinese.ForeColor = System.Drawing.Color.Red
        Me.lblNewErrorChinese.Location = New System.Drawing.Point(361, 4)
        Me.lblNewErrorChinese.Name = "lblNewErrorChinese"
        Me.lblNewErrorChinese.Size = New System.Drawing.Size(83, 12)
        Me.lblNewErrorChinese.TabIndex = 3
        Me.lblNewErrorChinese.Text = "长度少于6位！"
        Me.lblNewErrorChinese.Visible = False
        '
        'lblConfirmedErrorChinese
        '
        Me.lblConfirmedErrorChinese.AutoSize = True
        Me.lblConfirmedErrorChinese.ForeColor = System.Drawing.Color.Red
        Me.lblConfirmedErrorChinese.Location = New System.Drawing.Point(361, 4)
        Me.lblConfirmedErrorChinese.Name = "lblConfirmedErrorChinese"
        Me.lblConfirmedErrorChinese.Size = New System.Drawing.Size(101, 12)
        Me.lblConfirmedErrorChinese.TabIndex = 17
        Me.lblConfirmedErrorChinese.Text = "与新密码不一致！"
        Me.lblConfirmedErrorChinese.Visible = False
        '
        'lblOldErrorChinese
        '
        Me.lblOldErrorChinese.AutoSize = True
        Me.lblOldErrorChinese.ForeColor = System.Drawing.Color.Red
        Me.lblOldErrorChinese.Location = New System.Drawing.Point(361, 4)
        Me.lblOldErrorChinese.Name = "lblOldErrorChinese"
        Me.lblOldErrorChinese.Size = New System.Drawing.Size(53, 12)
        Me.lblOldErrorChinese.TabIndex = 3
        Me.lblOldErrorChinese.Text = "不正确！"
        Me.lblOldErrorChinese.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "&User Name:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "旧密码"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 12)
        Me.Label8.TabIndex = 1
        Me.Label8.Tag = "6"
        Me.Label8.Text = "&New Password:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(3, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(119, 12)
        Me.Label12.TabIndex = 1
        Me.Label12.Tag = "8"
        Me.Label12.Text = "Confir&med Password:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbbUser
        '
        Me.cbbUser.Location = New System.Drawing.Point(127, 6)
        Me.cbbUser.MaxLength = 27
        Me.cbbUser.Name = "cbbUser"
        Me.cbbUser.Size = New System.Drawing.Size(198, 20)
        Me.cbbUser.TabIndex = 3
        Me.cbbUser.Visible = False
        '
        'lblOldErrorEnglish
        '
        Me.lblOldErrorEnglish.AutoSize = True
        Me.lblOldErrorEnglish.ForeColor = System.Drawing.Color.Red
        Me.lblOldErrorEnglish.Location = New System.Drawing.Point(361, 16)
        Me.lblOldErrorEnglish.Name = "lblOldErrorEnglish"
        Me.lblOldErrorEnglish.Size = New System.Drawing.Size(41, 12)
        Me.lblOldErrorEnglish.TabIndex = 4
        Me.lblOldErrorEnglish.Text = "Wrong!"
        Me.lblOldErrorEnglish.Visible = False
        '
        'lblNewErrorEnglish
        '
        Me.lblNewErrorEnglish.AutoSize = True
        Me.lblNewErrorEnglish.ForeColor = System.Drawing.Color.Red
        Me.lblNewErrorEnglish.Location = New System.Drawing.Point(361, 16)
        Me.lblNewErrorEnglish.Name = "lblNewErrorEnglish"
        Me.lblNewErrorEnglish.Size = New System.Drawing.Size(77, 12)
        Me.lblNewErrorEnglish.TabIndex = 4
        Me.lblNewErrorEnglish.Text = "Length < 6 !"
        Me.lblNewErrorEnglish.Visible = False
        '
        'lblConfirmedErrorEnglish
        '
        Me.lblConfirmedErrorEnglish.AutoSize = True
        Me.lblConfirmedErrorEnglish.ForeColor = System.Drawing.Color.Red
        Me.lblConfirmedErrorEnglish.Location = New System.Drawing.Point(361, 16)
        Me.lblConfirmedErrorEnglish.Name = "lblConfirmedErrorEnglish"
        Me.lblConfirmedErrorEnglish.Size = New System.Drawing.Size(101, 12)
        Me.lblConfirmedErrorEnglish.TabIndex = 4
        Me.lblConfirmedErrorEnglish.Text = "Not same as new!"
        Me.lblConfirmedErrorEnglish.Visible = False
        '
        'pcbNewStrong
        '
        Me.pcbNewStrong.Image = CType(resources.GetObject("pcbNewStrong.Image"), System.Drawing.Image)
        Me.pcbNewStrong.Location = New System.Drawing.Point(289, 18)
        Me.pcbNewStrong.Margin = New System.Windows.Forms.Padding(0)
        Me.pcbNewStrong.Name = "pcbNewStrong"
        Me.pcbNewStrong.Size = New System.Drawing.Size(48, 9)
        Me.pcbNewStrong.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pcbNewStrong.TabIndex = 22
        Me.pcbNewStrong.TabStop = False
        '
        'pcbNewMedium
        '
        Me.pcbNewMedium.Image = CType(resources.GetObject("pcbNewMedium.Image"), System.Drawing.Image)
        Me.pcbNewMedium.Location = New System.Drawing.Point(240, 18)
        Me.pcbNewMedium.Margin = New System.Windows.Forms.Padding(0)
        Me.pcbNewMedium.Name = "pcbNewMedium"
        Me.pcbNewMedium.Size = New System.Drawing.Size(48, 9)
        Me.pcbNewMedium.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pcbNewMedium.TabIndex = 22
        Me.pcbNewMedium.TabStop = False
        '
        'pcbNewWeak
        '
        Me.pcbNewWeak.Image = CType(resources.GetObject("pcbNewWeak.Image"), System.Drawing.Image)
        Me.pcbNewWeak.Location = New System.Drawing.Point(191, 18)
        Me.pcbNewWeak.Margin = New System.Windows.Forms.Padding(0)
        Me.pcbNewWeak.Name = "pcbNewWeak"
        Me.pcbNewWeak.Size = New System.Drawing.Size(48, 9)
        Me.pcbNewWeak.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pcbNewWeak.TabIndex = 22
        Me.pcbNewWeak.TabStop = False
        '
        'pcbNewDisallowed
        '
        Me.pcbNewDisallowed.Image = CType(resources.GetObject("pcbNewDisallowed.Image"), System.Drawing.Image)
        Me.pcbNewDisallowed.Location = New System.Drawing.Point(142, 18)
        Me.pcbNewDisallowed.Margin = New System.Windows.Forms.Padding(0)
        Me.pcbNewDisallowed.Name = "pcbNewDisallowed"
        Me.pcbNewDisallowed.Size = New System.Drawing.Size(48, 9)
        Me.pcbNewDisallowed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pcbNewDisallowed.TabIndex = 22
        Me.pcbNewDisallowed.TabStop = False
        '
        'lblNewDisallowed
        '
        Me.lblNewDisallowed.AutoSize = True
        Me.lblNewDisallowed.Location = New System.Drawing.Point(146, 4)
        Me.lblNewDisallowed.Name = "lblNewDisallowed"
        Me.lblNewDisallowed.Size = New System.Drawing.Size(41, 12)
        Me.lblNewDisallowed.TabIndex = 2
        Me.lblNewDisallowed.Text = "不允许"
        Me.lblNewDisallowed.Visible = False
        '
        'lblNewWeak
        '
        Me.lblNewWeak.AutoSize = True
        Me.lblNewWeak.Location = New System.Drawing.Point(207, 4)
        Me.lblNewWeak.Name = "lblNewWeak"
        Me.lblNewWeak.Size = New System.Drawing.Size(17, 12)
        Me.lblNewWeak.TabIndex = 3
        Me.lblNewWeak.Text = "弱"
        Me.lblNewWeak.Visible = False
        '
        'lblNewMedium
        '
        Me.lblNewMedium.AutoSize = True
        Me.lblNewMedium.Location = New System.Drawing.Point(256, 4)
        Me.lblNewMedium.Name = "lblNewMedium"
        Me.lblNewMedium.Size = New System.Drawing.Size(17, 12)
        Me.lblNewMedium.TabIndex = 4
        Me.lblNewMedium.Text = "中"
        Me.lblNewMedium.Visible = False
        '
        'lblNewStrong
        '
        Me.lblNewStrong.AutoSize = True
        Me.lblNewStrong.Location = New System.Drawing.Point(305, 4)
        Me.lblNewStrong.Name = "lblNewStrong"
        Me.lblNewStrong.Size = New System.Drawing.Size(17, 12)
        Me.lblNewStrong.TabIndex = 23
        Me.lblNewStrong.Text = "强"
        Me.lblNewStrong.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 4)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 12)
        Me.Label9.TabIndex = 0
        Me.Label9.Tag = "6"
        Me.Label9.Text = "密码强度"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(113, 12)
        Me.Label10.TabIndex = 1
        Me.Label10.Tag = "6"
        Me.Label10.Text = "Password Strength:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 0
        Me.Label5.Tag = "6"
        Me.Label5.Text = "密码强度"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 12)
        Me.Label6.TabIndex = 1
        Me.Label6.Tag = "6"
        Me.Label6.Text = "Password Strength:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pcbOldDisallowed
        '
        Me.pcbOldDisallowed.Image = Global.ShoppingCardSystem.My.Resources.Resources.PWStrength0
        Me.pcbOldDisallowed.Location = New System.Drawing.Point(142, 18)
        Me.pcbOldDisallowed.Margin = New System.Windows.Forms.Padding(0)
        Me.pcbOldDisallowed.Name = "pcbOldDisallowed"
        Me.pcbOldDisallowed.Size = New System.Drawing.Size(48, 9)
        Me.pcbOldDisallowed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pcbOldDisallowed.TabIndex = 22
        Me.pcbOldDisallowed.TabStop = False
        '
        'pcbOldWeak
        '
        Me.pcbOldWeak.Image = CType(resources.GetObject("pcbOldWeak.Image"), System.Drawing.Image)
        Me.pcbOldWeak.Location = New System.Drawing.Point(191, 18)
        Me.pcbOldWeak.Margin = New System.Windows.Forms.Padding(0)
        Me.pcbOldWeak.Name = "pcbOldWeak"
        Me.pcbOldWeak.Size = New System.Drawing.Size(48, 9)
        Me.pcbOldWeak.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pcbOldWeak.TabIndex = 22
        Me.pcbOldWeak.TabStop = False
        '
        'pcbOldMedium
        '
        Me.pcbOldMedium.Image = CType(resources.GetObject("pcbOldMedium.Image"), System.Drawing.Image)
        Me.pcbOldMedium.Location = New System.Drawing.Point(240, 18)
        Me.pcbOldMedium.Margin = New System.Windows.Forms.Padding(0)
        Me.pcbOldMedium.Name = "pcbOldMedium"
        Me.pcbOldMedium.Size = New System.Drawing.Size(48, 9)
        Me.pcbOldMedium.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pcbOldMedium.TabIndex = 22
        Me.pcbOldMedium.TabStop = False
        '
        'pcbOldStrong
        '
        Me.pcbOldStrong.Image = CType(resources.GetObject("pcbOldStrong.Image"), System.Drawing.Image)
        Me.pcbOldStrong.Location = New System.Drawing.Point(289, 18)
        Me.pcbOldStrong.Margin = New System.Windows.Forms.Padding(0)
        Me.pcbOldStrong.Name = "pcbOldStrong"
        Me.pcbOldStrong.Size = New System.Drawing.Size(48, 9)
        Me.pcbOldStrong.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pcbOldStrong.TabIndex = 22
        Me.pcbOldStrong.TabStop = False
        '
        'lblOldDisallowed
        '
        Me.lblOldDisallowed.AutoSize = True
        Me.lblOldDisallowed.Location = New System.Drawing.Point(146, 4)
        Me.lblOldDisallowed.Name = "lblOldDisallowed"
        Me.lblOldDisallowed.Size = New System.Drawing.Size(41, 12)
        Me.lblOldDisallowed.TabIndex = 2
        Me.lblOldDisallowed.Text = "不允许"
        Me.lblOldDisallowed.Visible = False
        '
        'lblOldWeak
        '
        Me.lblOldWeak.AutoSize = True
        Me.lblOldWeak.Location = New System.Drawing.Point(207, 4)
        Me.lblOldWeak.Name = "lblOldWeak"
        Me.lblOldWeak.Size = New System.Drawing.Size(17, 12)
        Me.lblOldWeak.TabIndex = 3
        Me.lblOldWeak.Text = "弱"
        Me.lblOldWeak.Visible = False
        '
        'lblOldMedium
        '
        Me.lblOldMedium.AutoSize = True
        Me.lblOldMedium.Location = New System.Drawing.Point(256, 4)
        Me.lblOldMedium.Name = "lblOldMedium"
        Me.lblOldMedium.Size = New System.Drawing.Size(17, 12)
        Me.lblOldMedium.TabIndex = 4
        Me.lblOldMedium.Text = "中"
        Me.lblOldMedium.Visible = False
        '
        'lblOldStrong
        '
        Me.lblOldStrong.AutoSize = True
        Me.lblOldStrong.Location = New System.Drawing.Point(305, 4)
        Me.lblOldStrong.Name = "lblOldStrong"
        Me.lblOldStrong.Size = New System.Drawing.Size(17, 12)
        Me.lblOldStrong.TabIndex = 5
        Me.lblOldStrong.Text = "强"
        Me.lblOldStrong.Visible = False
        '
        'flpContainer
        '
        Me.flpContainer.AutoSize = True
        Me.flpContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpContainer.Controls.Add(Me.Panel1)
        Me.flpContainer.Controls.Add(Me.Panel2)
        Me.flpContainer.Controls.Add(Me.pnlOldStrength)
        Me.flpContainer.Controls.Add(Me.Panel3)
        Me.flpContainer.Controls.Add(Me.pnlNewStrength)
        Me.flpContainer.Controls.Add(Me.Panel4)
        Me.flpContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpContainer.Location = New System.Drawing.Point(9, 9)
        Me.flpContainer.Margin = New System.Windows.Forms.Padding(0)
        Me.flpContainer.Name = "flpContainer"
        Me.flpContainer.Size = New System.Drawing.Size(474, 192)
        Me.flpContainer.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txbUser)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cbbUser)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(474, 32)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.lblOldErrorChinese)
        Me.Panel2.Controls.Add(Me.lblOldErrorEnglish)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.txbOldPassword)
        Me.Panel2.Location = New System.Drawing.Point(0, 32)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(474, 32)
        Me.Panel2.TabIndex = 1
        '
        'pnlOldStrength
        '
        Me.pnlOldStrength.Controls.Add(Me.Label5)
        Me.pnlOldStrength.Controls.Add(Me.lblOldStrong)
        Me.pnlOldStrength.Controls.Add(Me.Label6)
        Me.pnlOldStrength.Controls.Add(Me.pcbOldDisallowed)
        Me.pnlOldStrength.Controls.Add(Me.lblOldMedium)
        Me.pnlOldStrength.Controls.Add(Me.pcbOldWeak)
        Me.pnlOldStrength.Controls.Add(Me.pcbOldMedium)
        Me.pnlOldStrength.Controls.Add(Me.lblOldWeak)
        Me.pnlOldStrength.Controls.Add(Me.pcbOldStrong)
        Me.pnlOldStrength.Controls.Add(Me.lblOldDisallowed)
        Me.pnlOldStrength.Location = New System.Drawing.Point(0, 64)
        Me.pnlOldStrength.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlOldStrength.Name = "pnlOldStrength"
        Me.pnlOldStrength.Size = New System.Drawing.Size(474, 32)
        Me.pnlOldStrength.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.lblNewErrorChinese)
        Me.Panel3.Controls.Add(Me.lblNewErrorEnglish)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.txbNewPassword)
        Me.Panel3.Location = New System.Drawing.Point(0, 96)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(474, 32)
        Me.Panel3.TabIndex = 3
        '
        'pnlNewStrength
        '
        Me.pnlNewStrength.Controls.Add(Me.Label9)
        Me.pnlNewStrength.Controls.Add(Me.lblNewStrong)
        Me.pnlNewStrength.Controls.Add(Me.Label10)
        Me.pnlNewStrength.Controls.Add(Me.lblNewMedium)
        Me.pnlNewStrength.Controls.Add(Me.pcbNewDisallowed)
        Me.pnlNewStrength.Controls.Add(Me.lblNewWeak)
        Me.pnlNewStrength.Controls.Add(Me.pcbNewWeak)
        Me.pnlNewStrength.Controls.Add(Me.lblNewDisallowed)
        Me.pnlNewStrength.Controls.Add(Me.pcbNewMedium)
        Me.pnlNewStrength.Controls.Add(Me.pcbNewStrong)
        Me.pnlNewStrength.Location = New System.Drawing.Point(0, 128)
        Me.pnlNewStrength.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlNewStrength.Name = "pnlNewStrength"
        Me.pnlNewStrength.Size = New System.Drawing.Size(474, 32)
        Me.pnlNewStrength.TabIndex = 4
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.lblConfirmedErrorChinese)
        Me.Panel4.Controls.Add(Me.lblConfirmedErrorEnglish)
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Controls.Add(Me.txbConfirmedPassword)
        Me.Panel4.Location = New System.Drawing.Point(0, 160)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(474, 32)
        Me.Panel4.TabIndex = 5
        '
        'pnlButtom
        '
        Me.pnlButtom.Controls.Add(Me.GroupBox1)
        Me.pnlButtom.Controls.Add(Me.btnOK)
        Me.pnlButtom.Controls.Add(Me.btnCancel)
        Me.pnlButtom.Location = New System.Drawing.Point(-4, 204)
        Me.pnlButtom.Name = "pnlButtom"
        Me.pnlButtom.Size = New System.Drawing.Size(502, 60)
        Me.pnlButtom.TabIndex = 1
        '
        'frmChangePassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(494, 261)
        Me.Controls.Add(Me.pnlButtom)
        Me.Controls.Add(Me.flpContainer)
        Me.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChangePassword"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "请修改密码 Please Change Password:"
        CType(Me.pcbNewStrong, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcbNewMedium, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcbNewWeak, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcbNewDisallowed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcbOldDisallowed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcbOldWeak, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcbOldMedium, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcbOldStrong, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flpContainer.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlOldStrength.ResumeLayout(False)
        Me.pnlOldStrength.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnlNewStrength.ResumeLayout(False)
        Me.pnlNewStrength.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pnlButtom.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txbNewPassword As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents theTip As System.Windows.Forms.ToolTip
    Friend WithEvents txbUser As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txbConfirmedPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txbOldPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblNewErrorChinese As System.Windows.Forms.Label
    Friend WithEvents lblConfirmedErrorChinese As System.Windows.Forms.Label
    Friend WithEvents lblOldErrorChinese As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbbUser As System.Windows.Forms.ComboBox
    Friend WithEvents lblOldErrorEnglish As System.Windows.Forms.Label
    Friend WithEvents lblNewErrorEnglish As System.Windows.Forms.Label
    Friend WithEvents lblConfirmedErrorEnglish As System.Windows.Forms.Label
    Friend WithEvents pcbNewDisallowed As System.Windows.Forms.PictureBox
    Friend WithEvents pcbNewWeak As System.Windows.Forms.PictureBox
    Friend WithEvents pcbNewMedium As System.Windows.Forms.PictureBox
    Friend WithEvents pcbNewStrong As System.Windows.Forms.PictureBox
    Friend WithEvents lblNewDisallowed As System.Windows.Forms.Label
    Friend WithEvents lblNewWeak As System.Windows.Forms.Label
    Friend WithEvents lblNewMedium As System.Windows.Forms.Label
    Friend WithEvents lblNewStrong As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents pcbOldDisallowed As System.Windows.Forms.PictureBox
    Friend WithEvents pcbOldWeak As System.Windows.Forms.PictureBox
    Friend WithEvents pcbOldMedium As System.Windows.Forms.PictureBox
    Friend WithEvents pcbOldStrong As System.Windows.Forms.PictureBox
    Friend WithEvents lblOldDisallowed As System.Windows.Forms.Label
    Friend WithEvents lblOldWeak As System.Windows.Forms.Label
    Friend WithEvents lblOldMedium As System.Windows.Forms.Label
    Friend WithEvents lblOldStrong As System.Windows.Forms.Label
    Friend WithEvents flpContainer As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlOldStrength As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents pnlNewStrength As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents pnlButtom As System.Windows.Forms.Panel
End Class
