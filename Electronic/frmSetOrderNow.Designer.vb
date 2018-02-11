<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetOrderNow
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
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnExcute = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.tabContent = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.lblResult = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnFile = New System.Windows.Forms.Button
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.txtCardQTY = New System.Windows.Forms.TextBox
        Me.txtFaceValue = New System.Windows.Forms.TextBox
        Me.txtEmail = New System.Windows.Forms.TextBox
        Me.txtMobile = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.tabContent.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(432, 249)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "取消(&C)"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnExcute
        '
        Me.btnExcute.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExcute.Location = New System.Drawing.Point(317, 249)
        Me.btnExcute.Name = "btnExcute"
        Me.btnExcute.Size = New System.Drawing.Size(110, 23)
        Me.btnExcute.TabIndex = 10
        Me.btnExcute.Text = "提交CUL(&S)"
        Me.btnExcute.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(-68, 230)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(603, 10)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'tabContent
        '
        Me.tabContent.Controls.Add(Me.TabPage1)
        Me.tabContent.Controls.Add(Me.TabPage2)
        Me.tabContent.Location = New System.Drawing.Point(12, 13)
        Me.tabContent.Name = "tabContent"
        Me.tabContent.SelectedIndex = 0
        Me.tabContent.Size = New System.Drawing.Size(497, 211)
        Me.tabContent.TabIndex = 12
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lblResult)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.btnFile)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(489, 185)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "手机下单"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lblResult
        '
        Me.lblResult.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblResult.Location = New System.Drawing.Point(15, 98)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(457, 67)
        Me.lblResult.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(155, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "导入手机号时选择文件(&F)："
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(53, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(419, 38)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "本功能用于顾客批量购买电子卡时，通过Excel文件批量导入手机号码，从CUL系统获取相关返点卡信息。"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(10, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "说明："
        '
        'btnFile
        '
        Me.btnFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFile.Location = New System.Drawing.Point(172, 58)
        Me.btnFile.Name = "btnFile"
        Me.btnFile.Size = New System.Drawing.Size(100, 23)
        Me.btnFile.TabIndex = 4
        Me.btnFile.Text = "上传文件..."
        Me.btnFile.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtCardQTY)
        Me.TabPage2.Controls.Add(Me.txtFaceValue)
        Me.TabPage2.Controls.Add(Me.txtEmail)
        Me.TabPage2.Controls.Add(Me.txtMobile)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(489, 185)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "邮箱下单"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtCardQTY
        '
        Me.txtCardQTY.Location = New System.Drawing.Point(119, 151)
        Me.txtCardQTY.Name = "txtCardQTY"
        Me.txtCardQTY.Size = New System.Drawing.Size(167, 21)
        Me.txtCardQTY.TabIndex = 8
        '
        'txtFaceValue
        '
        Me.txtFaceValue.Location = New System.Drawing.Point(119, 121)
        Me.txtFaceValue.Name = "txtFaceValue"
        Me.txtFaceValue.Size = New System.Drawing.Size(167, 21)
        Me.txtFaceValue.TabIndex = 7
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(119, 57)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(167, 21)
        Me.txtEmail.TabIndex = 6
        '
        'txtMobile
        '
        Me.txtMobile.Location = New System.Drawing.Point(119, 89)
        Me.txtMobile.Name = "txtMobile"
        Me.txtMobile.Size = New System.Drawing.Size(167, 21)
        Me.txtMobile.TabIndex = 5
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 154)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 12)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "卡数量(&N)："
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 124)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 12)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "卡面值(&V)："
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 60)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 12)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "电子邮箱(&E)："
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 92)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 12)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "手机号码(&T)："
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(53, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(420, 37)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "本功能用于顾客批量购买电子卡时，通过手动填写手机号码和邮箱，从CUL系统获取相关返点卡信息。"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label7.Location = New System.Drawing.Point(10, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 12)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "说明："
        '
        'frmSetOrderNow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(521, 288)
        Me.Controls.Add(Me.tabContent)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnExcute)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSetOrderNow"
        Me.Padding = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "实时下单获取返点卡 Set OrderTo Get CardList"
        Me.tabContent.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnExcute As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tabContent As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnFile As System.Windows.Forms.Button
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents txtCardQTY As System.Windows.Forms.TextBox
    Friend WithEvents txtFaceValue As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtMobile As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblResult As System.Windows.Forms.Label

End Class
