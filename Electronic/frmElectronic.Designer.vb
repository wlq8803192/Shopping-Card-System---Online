<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmElectronic
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
        Me.tabContent = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.lblZhi = New System.Windows.Forms.Label
        Me.dtEndDate1 = New System.Windows.Forms.DateTimePicker
        Me.dtBeginDate1 = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnFile = New System.Windows.Forms.Button
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.lblZhi2 = New System.Windows.Forms.Label
        Me.dtEndDate2 = New System.Windows.Forms.DateTimePicker
        Me.dtBeginDate2 = New System.Windows.Forms.DateTimePicker
        Me.txtNum2 = New System.Windows.Forms.TextBox
        Me.txtFaceValue2 = New System.Windows.Forms.TextBox
        Me.txtEmail = New System.Windows.Forms.TextBox
        Me.txtMobile = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnExcute = New System.Windows.Forms.Button
        Me.tabContent.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabContent
        '
        Me.tabContent.Controls.Add(Me.TabPage1)
        Me.tabContent.Controls.Add(Me.TabPage2)
        Me.tabContent.Location = New System.Drawing.Point(12, 12)
        Me.tabContent.Name = "tabContent"
        Me.tabContent.SelectedIndex = 0
        Me.tabContent.Size = New System.Drawing.Size(575, 230)
        Me.tabContent.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lblZhi)
        Me.TabPage1.Controls.Add(Me.dtEndDate1)
        Me.TabPage1.Controls.Add(Me.dtBeginDate1)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.btnFile)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(567, 204)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "手机申请"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lblZhi
        '
        Me.lblZhi.AutoSize = True
        Me.lblZhi.Location = New System.Drawing.Point(339, 84)
        Me.lblZhi.Name = "lblZhi"
        Me.lblZhi.Size = New System.Drawing.Size(11, 12)
        Me.lblZhi.TabIndex = 10
        Me.lblZhi.Text = "-"
        '
        'dtEndDate1
        '
        Me.dtEndDate1.CustomFormat = "yyyy/MM/dd"
        Me.dtEndDate1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtEndDate1.Location = New System.Drawing.Point(361, 78)
        Me.dtEndDate1.Name = "dtEndDate1"
        Me.dtEndDate1.Size = New System.Drawing.Size(141, 21)
        Me.dtEndDate1.TabIndex = 9
        '
        'dtBeginDate1
        '
        Me.dtBeginDate1.CustomFormat = "yyyy/MM/dd"
        Me.dtBeginDate1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtBeginDate1.Location = New System.Drawing.Point(185, 78)
        Me.dtBeginDate1.Name = "dtBeginDate1"
        Me.dtBeginDate1.Size = New System.Drawing.Size(141, 21)
        Me.dtBeginDate1.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(131, 12)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "输入电子码有效期(&C)："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(155, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "导入手机号时选择文件(&F)："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(53, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(479, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "本功能用于顾客批量购买电子卡时，通过Excel文件批量导入手机号码，为其申请电子卡。"
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
        Me.btnFile.Location = New System.Drawing.Point(185, 43)
        Me.btnFile.Name = "btnFile"
        Me.btnFile.Size = New System.Drawing.Size(100, 23)
        Me.btnFile.TabIndex = 4
        Me.btnFile.Text = "上传文件..."
        Me.btnFile.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lblZhi2)
        Me.TabPage2.Controls.Add(Me.dtEndDate2)
        Me.TabPage2.Controls.Add(Me.dtBeginDate2)
        Me.TabPage2.Controls.Add(Me.txtNum2)
        Me.TabPage2.Controls.Add(Me.txtFaceValue2)
        Me.TabPage2.Controls.Add(Me.txtEmail)
        Me.TabPage2.Controls.Add(Me.txtMobile)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(567, 204)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "邮箱申请"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lblZhi2
        '
        Me.lblZhi2.AutoSize = True
        Me.lblZhi2.Location = New System.Drawing.Point(339, 176)
        Me.lblZhi2.Name = "lblZhi2"
        Me.lblZhi2.Size = New System.Drawing.Size(11, 12)
        Me.lblZhi2.TabIndex = 11
        Me.lblZhi2.Text = "-"
        '
        'dtEndDate2
        '
        Me.dtEndDate2.CustomFormat = "yyyy/MM/dd"
        Me.dtEndDate2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtEndDate2.Location = New System.Drawing.Point(362, 170)
        Me.dtEndDate2.Name = "dtEndDate2"
        Me.dtEndDate2.Size = New System.Drawing.Size(141, 21)
        Me.dtEndDate2.TabIndex = 10
        '
        'dtBeginDate2
        '
        Me.dtBeginDate2.CustomFormat = "yyyy/MM/dd"
        Me.dtBeginDate2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtBeginDate2.Location = New System.Drawing.Point(185, 170)
        Me.dtBeginDate2.Name = "dtBeginDate2"
        Me.dtBeginDate2.Size = New System.Drawing.Size(141, 21)
        Me.dtBeginDate2.TabIndex = 9
        '
        'txtNum2
        '
        Me.txtNum2.Location = New System.Drawing.Point(185, 138)
        Me.txtNum2.Name = "txtNum2"
        Me.txtNum2.Size = New System.Drawing.Size(141, 21)
        Me.txtNum2.TabIndex = 8
        '
        'txtFaceValue2
        '
        Me.txtFaceValue2.Location = New System.Drawing.Point(185, 108)
        Me.txtFaceValue2.Name = "txtFaceValue2"
        Me.txtFaceValue2.Size = New System.Drawing.Size(141, 21)
        Me.txtFaceValue2.TabIndex = 7
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(185, 44)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(141, 21)
        Me.txtEmail.TabIndex = 6
        '
        'txtMobile
        '
        Me.txtMobile.Location = New System.Drawing.Point(185, 76)
        Me.txtMobile.Name = "txtMobile"
        Me.txtMobile.Size = New System.Drawing.Size(141, 21)
        Me.txtMobile.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(18, 171)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(107, 12)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "电子码有效期(&C)："
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(18, 141)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 12)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "卡数量(&N)："
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(18, 111)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 12)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "卡面值(&V)："
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(18, 47)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 12)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "电子邮箱(&E)："
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(18, 79)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 12)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "手机号码(&T)："
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(56, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(461, 12)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "本功能用于顾客批量购买电子卡时，通过手动填写手机号码和邮箱，为其申请电子卡。"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label7.Location = New System.Drawing.Point(13, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 12)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "说明："
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(-10, 253)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(631, 3)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(509, 269)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "取消(&C)"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnExcute
        '
        Me.btnExcute.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExcute.Location = New System.Drawing.Point(394, 269)
        Me.btnExcute.Name = "btnExcute"
        Me.btnExcute.Size = New System.Drawing.Size(110, 23)
        Me.btnExcute.TabIndex = 4
        Me.btnExcute.Text = "提交申请(&S)"
        Me.btnExcute.UseVisualStyleBackColor = True
        '
        'frmElectronic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 305)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnExcute)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tabContent)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmElectronic"
        Me.Padding = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "电子卡团购申请 Electronic Card Requirement"
        Me.tabContent.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents tabContent As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnExcute As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnFile As System.Windows.Forms.Button
    Friend WithEvents txtFaceValue2 As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtMobile As System.Windows.Forms.TextBox
    Friend WithEvents txtNum2 As System.Windows.Forms.TextBox
    Friend WithEvents dtBeginDate1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtBeginDate2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtEndDate1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblZhi As System.Windows.Forms.Label
    Friend WithEvents dtEndDate2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblZhi2 As System.Windows.Forms.Label
End Class
