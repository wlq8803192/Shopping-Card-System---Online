<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSearchUser))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.rdbByUserCode = New System.Windows.Forms.RadioButton
        Me.pnlByUserCode = New System.Windows.Forms.Panel
        Me.txbUserCode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.rdbByLoginName = New System.Windows.Forms.RadioButton
        Me.pnlByLoginName = New System.Windows.Forms.Panel
        Me.txbLoginName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.rdbByRealName = New System.Windows.Forms.RadioButton
        Me.pnlByRealName = New System.Windows.Forms.Panel
        Me.txbRealName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.pnlByUserCode.SuspendLayout()
        Me.pnlByLoginName.SuspendLayout()
        Me.pnlByRealName.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(-5, 224)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(347, 4)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(143, 241)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(85, 23)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "查找 &Search"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(234, 241)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(85, 23)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "取消 &Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'rdbByUserCode
        '
        Me.rdbByUserCode.AutoSize = True
        Me.rdbByUserCode.Location = New System.Drawing.Point(12, 12)
        Me.rdbByUserCode.Name = "rdbByUserCode"
        Me.rdbByUserCode.Size = New System.Drawing.Size(299, 16)
        Me.rdbByUserCode.TabIndex = 0
        Me.rdbByUserCode.Text = "通过用户编号查找用户 Search user by User Code:"
        Me.rdbByUserCode.UseVisualStyleBackColor = True
        '
        'pnlByUserCode
        '
        Me.pnlByUserCode.Controls.Add(Me.txbUserCode)
        Me.pnlByUserCode.Controls.Add(Me.Label1)
        Me.pnlByUserCode.Enabled = False
        Me.pnlByUserCode.Location = New System.Drawing.Point(25, 34)
        Me.pnlByUserCode.Name = "pnlByUserCode"
        Me.pnlByUserCode.Size = New System.Drawing.Size(286, 42)
        Me.pnlByUserCode.TabIndex = 1
        '
        'txbUserCode
        '
        Me.txbUserCode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbUserCode.Location = New System.Drawing.Point(5, 17)
        Me.txbUserCode.MaxLength = 8
        Me.txbUserCode.Name = "txbUserCode"
        Me.txbUserCode.Size = New System.Drawing.Size(161, 21)
        Me.txbUserCode.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(233, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "请输入用户编号 Please input User Code:"
        '
        'rdbByLoginName
        '
        Me.rdbByLoginName.AutoSize = True
        Me.rdbByLoginName.Location = New System.Drawing.Point(12, 82)
        Me.rdbByLoginName.Name = "rdbByLoginName"
        Me.rdbByLoginName.Size = New System.Drawing.Size(305, 16)
        Me.rdbByLoginName.TabIndex = 2
        Me.rdbByLoginName.Text = "通过登录名称查找用户 Search user by Login Name:"
        Me.rdbByLoginName.UseVisualStyleBackColor = True
        '
        'pnlByLoginName
        '
        Me.pnlByLoginName.Controls.Add(Me.txbLoginName)
        Me.pnlByLoginName.Controls.Add(Me.Label2)
        Me.pnlByLoginName.Enabled = False
        Me.pnlByLoginName.Location = New System.Drawing.Point(25, 104)
        Me.pnlByLoginName.Name = "pnlByLoginName"
        Me.pnlByLoginName.Size = New System.Drawing.Size(286, 42)
        Me.pnlByLoginName.TabIndex = 3
        '
        'txbLoginName
        '
        Me.txbLoginName.Location = New System.Drawing.Point(5, 17)
        Me.txbLoginName.MaxLength = 20
        Me.txbLoginName.Name = "txbLoginName"
        Me.txbLoginName.Size = New System.Drawing.Size(161, 21)
        Me.txbLoginName.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(239, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "请输入登录名称 Please input Login Name:"
        '
        'rdbByRealName
        '
        Me.rdbByRealName.AutoSize = True
        Me.rdbByRealName.Checked = True
        Me.rdbByRealName.Location = New System.Drawing.Point(12, 152)
        Me.rdbByRealName.Name = "rdbByRealName"
        Me.rdbByRealName.Size = New System.Drawing.Size(299, 16)
        Me.rdbByRealName.TabIndex = 4
        Me.rdbByRealName.TabStop = True
        Me.rdbByRealName.Text = "通过真实姓名查找用户 Search user by Real Name:"
        Me.rdbByRealName.UseVisualStyleBackColor = True
        '
        'pnlByRealName
        '
        Me.pnlByRealName.Controls.Add(Me.txbRealName)
        Me.pnlByRealName.Controls.Add(Me.Label3)
        Me.pnlByRealName.Location = New System.Drawing.Point(25, 174)
        Me.pnlByRealName.Name = "pnlByRealName"
        Me.pnlByRealName.Size = New System.Drawing.Size(286, 42)
        Me.pnlByRealName.TabIndex = 5
        '
        'txbRealName
        '
        Me.txbRealName.Location = New System.Drawing.Point(5, 17)
        Me.txbRealName.MaxLength = 20
        Me.txbRealName.Name = "txbRealName"
        Me.txbRealName.Size = New System.Drawing.Size(161, 21)
        Me.txbRealName.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(233, 12)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "请输入真实名称 Please input Real Name:"
        '
        'frmSearchUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(331, 276)
        Me.Controls.Add(Me.pnlByRealName)
        Me.Controls.Add(Me.pnlByLoginName)
        Me.Controls.Add(Me.pnlByUserCode)
        Me.Controls.Add(Me.rdbByRealName)
        Me.Controls.Add(Me.rdbByLoginName)
        Me.Controls.Add(Me.rdbByUserCode)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSearchUser"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "查找用户 Search User:"
        Me.pnlByUserCode.ResumeLayout(False)
        Me.pnlByUserCode.PerformLayout()
        Me.pnlByLoginName.ResumeLayout(False)
        Me.pnlByLoginName.PerformLayout()
        Me.pnlByRealName.ResumeLayout(False)
        Me.pnlByRealName.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents rdbByUserCode As System.Windows.Forms.RadioButton
    Friend WithEvents pnlByUserCode As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txbUserCode As System.Windows.Forms.TextBox
    Friend WithEvents rdbByLoginName As System.Windows.Forms.RadioButton
    Friend WithEvents pnlByLoginName As System.Windows.Forms.Panel
    Friend WithEvents txbLoginName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rdbByRealName As System.Windows.Forms.RadioButton
    Friend WithEvents pnlByRealName As System.Windows.Forms.Panel
    Friend WithEvents txbRealName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
