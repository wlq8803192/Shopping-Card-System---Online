<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCardPassword
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCardPassword))
        Me.tabPassword = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.pnlResetPW = New System.Windows.Forms.Panel
        Me.lblConfirmedPWError1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txbConfirmedPW1 = New System.Windows.Forms.TextBox
        Me.lblNewPWError1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txbNewPW1 = New System.Windows.Forms.TextBox
        Me.lblCardNoError1 = New System.Windows.Forms.Label
        Me.txbCardNo1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.pnlChangePW = New System.Windows.Forms.Panel
        Me.lblConfirmedPWError2 = New System.Windows.Forms.Label
        Me.lblNewPWError2 = New System.Windows.Forms.Label
        Me.lblOldPWError = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txbConfirmedPW2 = New System.Windows.Forms.TextBox
        Me.txbNewPW2 = New System.Windows.Forms.TextBox
        Me.txbOldPW = New System.Windows.Forms.TextBox
        Me.lblCardNoError2 = New System.Windows.Forms.Label
        Me.txbCardNo2 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnExcute = New System.Windows.Forms.Button
        Me.lblResult1 = New System.Windows.Forms.Label
        Me.lblResult2 = New System.Windows.Forms.Label
        Me.tabPassword.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.pnlResetPW.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.pnlChangePW.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabPassword
        '
        Me.tabPassword.Controls.Add(Me.TabPage1)
        Me.tabPassword.Controls.Add(Me.TabPage2)
        Me.tabPassword.Location = New System.Drawing.Point(12, 12)
        Me.tabPassword.Name = "tabPassword"
        Me.tabPassword.SelectedIndex = 0
        Me.tabPassword.Size = New System.Drawing.Size(575, 193)
        Me.tabPassword.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.pnlResetPW)
        Me.TabPage1.Controls.Add(Me.lblCardNoError1)
        Me.TabPage1.Controls.Add(Me.txbCardNo1)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 21)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(567, 168)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "重置密码"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'pnlResetPW
        '
        Me.pnlResetPW.Controls.Add(Me.lblConfirmedPWError1)
        Me.pnlResetPW.Controls.Add(Me.Label5)
        Me.pnlResetPW.Controls.Add(Me.txbConfirmedPW1)
        Me.pnlResetPW.Controls.Add(Me.lblNewPWError1)
        Me.pnlResetPW.Controls.Add(Me.Label4)
        Me.pnlResetPW.Controls.Add(Me.txbNewPW1)
        Me.pnlResetPW.Enabled = False
        Me.pnlResetPW.Location = New System.Drawing.Point(7, 68)
        Me.pnlResetPW.Name = "pnlResetPW"
        Me.pnlResetPW.Size = New System.Drawing.Size(545, 65)
        Me.pnlResetPW.TabIndex = 5
        '
        'lblConfirmedPWError1
        '
        Me.lblConfirmedPWError1.AutoSize = True
        Me.lblConfirmedPWError1.ForeColor = System.Drawing.Color.Red
        Me.lblConfirmedPWError1.Location = New System.Drawing.Point(335, 37)
        Me.lblConfirmedPWError1.Name = "lblConfirmedPWError1"
        Me.lblConfirmedPWError1.Size = New System.Drawing.Size(0, 12)
        Me.lblConfirmedPWError1.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(-1, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(203, 12)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "请再次输入上面购物卡的新密码(&M)："
        '
        'txbConfirmedPW1
        '
        Me.txbConfirmedPW1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbConfirmedPW1.Location = New System.Drawing.Point(208, 33)
        Me.txbConfirmedPW1.MaxLength = 6
        Me.txbConfirmedPW1.Name = "txbConfirmedPW1"
        Me.txbConfirmedPW1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txbConfirmedPW1.Size = New System.Drawing.Size(121, 21)
        Me.txbConfirmedPW1.TabIndex = 4
        '
        'lblNewPWError1
        '
        Me.lblNewPWError1.AutoSize = True
        Me.lblNewPWError1.ForeColor = System.Drawing.Color.Red
        Me.lblNewPWError1.Location = New System.Drawing.Point(335, 7)
        Me.lblNewPWError1.Name = "lblNewPWError1"
        Me.lblNewPWError1.Size = New System.Drawing.Size(0, 12)
        Me.lblNewPWError1.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(-1, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(203, 12)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "请为上面的购物卡设置新的密码(&P)："
        '
        'txbNewPW1
        '
        Me.txbNewPW1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbNewPW1.Location = New System.Drawing.Point(208, 3)
        Me.txbNewPW1.MaxLength = 6
        Me.txbNewPW1.Name = "txbNewPW1"
        Me.txbNewPW1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txbNewPW1.Size = New System.Drawing.Size(121, 21)
        Me.txbNewPW1.TabIndex = 1
        '
        'lblCardNoError1
        '
        Me.lblCardNoError1.AutoSize = True
        Me.lblCardNoError1.ForeColor = System.Drawing.Color.Red
        Me.lblCardNoError1.Location = New System.Drawing.Point(342, 46)
        Me.lblCardNoError1.Name = "lblCardNoError1"
        Me.lblCardNoError1.Size = New System.Drawing.Size(0, 12)
        Me.lblCardNoError1.TabIndex = 4
        '
        'txbCardNo1
        '
        Me.txbCardNo1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbCardNo1.Location = New System.Drawing.Point(215, 41)
        Me.txbCardNo1.MaxLength = 19
        Me.txbCardNo1.Name = "txbCardNo1"
        Me.txbCardNo1.Size = New System.Drawing.Size(121, 21)
        Me.txbCardNo1.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(203, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "请输入待重置密码的购物卡卡号(&N)："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(54, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(449, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "本功能用于顾客忘记自己的购物卡密码时，在未知原密码的情况下，替其重置密码。"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(7, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "说明："
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.pnlChangePW)
        Me.TabPage2.Controls.Add(Me.lblCardNoError2)
        Me.TabPage2.Controls.Add(Me.txbCardNo2)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Location = New System.Drawing.Point(4, 21)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(567, 168)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "修改密码"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'pnlChangePW
        '
        Me.pnlChangePW.Controls.Add(Me.lblConfirmedPWError2)
        Me.pnlChangePW.Controls.Add(Me.lblNewPWError2)
        Me.pnlChangePW.Controls.Add(Me.lblOldPWError)
        Me.pnlChangePW.Controls.Add(Me.Label14)
        Me.pnlChangePW.Controls.Add(Me.Label12)
        Me.pnlChangePW.Controls.Add(Me.Label7)
        Me.pnlChangePW.Controls.Add(Me.txbConfirmedPW2)
        Me.pnlChangePW.Controls.Add(Me.txbNewPW2)
        Me.pnlChangePW.Controls.Add(Me.txbOldPW)
        Me.pnlChangePW.Enabled = False
        Me.pnlChangePW.Location = New System.Drawing.Point(7, 68)
        Me.pnlChangePW.Name = "pnlChangePW"
        Me.pnlChangePW.Size = New System.Drawing.Size(545, 93)
        Me.pnlChangePW.TabIndex = 5
        '
        'lblConfirmedPWError2
        '
        Me.lblConfirmedPWError2.AutoSize = True
        Me.lblConfirmedPWError2.ForeColor = System.Drawing.Color.Red
        Me.lblConfirmedPWError2.Location = New System.Drawing.Point(335, 67)
        Me.lblConfirmedPWError2.Name = "lblConfirmedPWError2"
        Me.lblConfirmedPWError2.Size = New System.Drawing.Size(0, 12)
        Me.lblConfirmedPWError2.TabIndex = 8
        '
        'lblNewPWError2
        '
        Me.lblNewPWError2.AutoSize = True
        Me.lblNewPWError2.ForeColor = System.Drawing.Color.Red
        Me.lblNewPWError2.Location = New System.Drawing.Point(335, 37)
        Me.lblNewPWError2.Name = "lblNewPWError2"
        Me.lblNewPWError2.Size = New System.Drawing.Size(0, 12)
        Me.lblNewPWError2.TabIndex = 5
        '
        'lblOldPWError
        '
        Me.lblOldPWError.AutoSize = True
        Me.lblOldPWError.ForeColor = System.Drawing.Color.Red
        Me.lblOldPWError.Location = New System.Drawing.Point(335, 7)
        Me.lblOldPWError.Name = "lblOldPWError"
        Me.lblOldPWError.Size = New System.Drawing.Size(0, 12)
        Me.lblOldPWError.TabIndex = 2
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(-1, 67)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(203, 12)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "请再次输入上面购物卡的新密码(&M)："
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(-1, 37)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(203, 12)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "请为上面的购物卡设置新的密码(&P)："
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(-1, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(203, 12)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "请输入上面的购物卡的原来密码(&O)："
        '
        'txbConfirmedPW2
        '
        Me.txbConfirmedPW2.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbConfirmedPW2.Location = New System.Drawing.Point(208, 63)
        Me.txbConfirmedPW2.MaxLength = 6
        Me.txbConfirmedPW2.Name = "txbConfirmedPW2"
        Me.txbConfirmedPW2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txbConfirmedPW2.Size = New System.Drawing.Size(121, 21)
        Me.txbConfirmedPW2.TabIndex = 7
        '
        'txbNewPW2
        '
        Me.txbNewPW2.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbNewPW2.Location = New System.Drawing.Point(208, 33)
        Me.txbNewPW2.MaxLength = 6
        Me.txbNewPW2.Name = "txbNewPW2"
        Me.txbNewPW2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txbNewPW2.Size = New System.Drawing.Size(121, 21)
        Me.txbNewPW2.TabIndex = 4
        '
        'txbOldPW
        '
        Me.txbOldPW.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbOldPW.Location = New System.Drawing.Point(208, 3)
        Me.txbOldPW.MaxLength = 6
        Me.txbOldPW.Name = "txbOldPW"
        Me.txbOldPW.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txbOldPW.Size = New System.Drawing.Size(121, 21)
        Me.txbOldPW.TabIndex = 1
        '
        'lblCardNoError2
        '
        Me.lblCardNoError2.AutoSize = True
        Me.lblCardNoError2.ForeColor = System.Drawing.Color.Red
        Me.lblCardNoError2.Location = New System.Drawing.Point(342, 46)
        Me.lblCardNoError2.Name = "lblCardNoError2"
        Me.lblCardNoError2.Size = New System.Drawing.Size(0, 12)
        Me.lblCardNoError2.TabIndex = 4
        '
        'txbCardNo2
        '
        Me.txbCardNo2.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbCardNo2.Location = New System.Drawing.Point(215, 41)
        Me.txbCardNo2.MaxLength = 19
        Me.txbCardNo2.Name = "txbCardNo2"
        Me.txbCardNo2.Size = New System.Drawing.Size(121, 21)
        Me.txbCardNo2.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 45)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(203, 12)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "请输入待修改密码的购物卡卡号(&N)："
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(54, 14)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(329, 12)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "本功能用于顾客已知自己购物卡的原密码时，替其修改密码。"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label11.Location = New System.Drawing.Point(7, 14)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 12)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "说明："
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(-10, 218)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(631, 3)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(509, 234)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "取消(&C)"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnExcute
        '
        Me.btnExcute.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExcute.Enabled = False
        Me.btnExcute.Location = New System.Drawing.Point(394, 234)
        Me.btnExcute.Name = "btnExcute"
        Me.btnExcute.Size = New System.Drawing.Size(110, 23)
        Me.btnExcute.TabIndex = 4
        Me.btnExcute.Text = "到CUL重置密码(&E)"
        Me.btnExcute.UseVisualStyleBackColor = True
        '
        'lblResult1
        '
        Me.lblResult1.AutoSize = True
        Me.lblResult1.Location = New System.Drawing.Point(10, 239)
        Me.lblResult1.Name = "lblResult1"
        Me.lblResult1.Size = New System.Drawing.Size(0, 12)
        Me.lblResult1.TabIndex = 2
        '
        'lblResult2
        '
        Me.lblResult2.AutoSize = True
        Me.lblResult2.Location = New System.Drawing.Point(10, 239)
        Me.lblResult2.Name = "lblResult2"
        Me.lblResult2.Size = New System.Drawing.Size(0, 12)
        Me.lblResult2.TabIndex = 3
        Me.lblResult2.Visible = False
        '
        'frmCardPassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(600, 270)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnExcute)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tabPassword)
        Me.Controls.Add(Me.lblResult2)
        Me.Controls.Add(Me.lblResult1)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCardPassword"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "重置/修改购物卡密码 Reset/Change Shopping Card's Password"
        Me.tabPassword.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.pnlResetPW.ResumeLayout(False)
        Me.pnlResetPW.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.pnlChangePW.ResumeLayout(False)
        Me.pnlChangePW.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tabPassword As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents lblCardNoError1 As System.Windows.Forms.Label
    Friend WithEvents txbCardNo1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlResetPW As System.Windows.Forms.Panel
    Friend WithEvents lblNewPWError1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txbNewPW1 As System.Windows.Forms.TextBox
    Friend WithEvents pnlChangePW As System.Windows.Forms.Panel
    Friend WithEvents lblOldPWError As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txbOldPW As System.Windows.Forms.TextBox
    Friend WithEvents lblCardNoError2 As System.Windows.Forms.Label
    Friend WithEvents txbCardNo2 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblConfirmedPWError2 As System.Windows.Forms.Label
    Friend WithEvents lblNewPWError2 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txbConfirmedPW2 As System.Windows.Forms.TextBox
    Friend WithEvents txbNewPW2 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnExcute As System.Windows.Forms.Button
    Friend WithEvents lblResult1 As System.Windows.Forms.Label
    Friend WithEvents lblConfirmedPWError1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txbConfirmedPW1 As System.Windows.Forms.TextBox
    Friend WithEvents lblResult2 As System.Windows.Forms.Label
End Class
