<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportantInformation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportantInformation))
        Me.btnOK = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblOperationMode = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.grbTrainingMode = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.grbProducingMode = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.grbTrainingMode.SuspendLayout()
        Me.grbProducingMode.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnOK.Location = New System.Drawing.Point(376, 270)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "确定(&O)"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(-10, 252)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(490, 4)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(319, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "敬请留意 PLEASE PAY ATTENTION THAT:"
        '
        'lblOperationMode
        '
        Me.lblOperationMode.Font = New System.Drawing.Font("宋体", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblOperationMode.ForeColor = System.Drawing.Color.Maroon
        Me.lblOperationMode.Location = New System.Drawing.Point(26, 79)
        Me.lblOperationMode.Name = "lblOperationMode"
        Me.lblOperationMode.Size = New System.Drawing.Size(363, 29)
        Me.lblOperationMode.TabIndex = 3
        Me.lblOperationMode.Text = "培训模式 Training Mode"
        Me.lblOperationMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "现在，您已经进入："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(143, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Now, you already enter:"
        '
        'grbTrainingMode
        '
        Me.grbTrainingMode.Controls.Add(Me.Label8)
        Me.grbTrainingMode.Controls.Add(Me.Label7)
        Me.grbTrainingMode.Controls.Add(Me.Label6)
        Me.grbTrainingMode.Controls.Add(Me.Label5)
        Me.grbTrainingMode.Controls.Add(Me.Label4)
        Me.grbTrainingMode.Location = New System.Drawing.Point(12, 118)
        Me.grbTrainingMode.Name = "grbTrainingMode"
        Me.grbTrainingMode.Size = New System.Drawing.Size(439, 120)
        Me.grbTrainingMode.TabIndex = 4
        Me.grbTrainingMode.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(401, 12)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "您所输入的关于客户、合同和销售等数据都将是虚拟的，不具有实际的商业"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(233, 12)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "意义。这些数据将被保存在测试服务器中。"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 59)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(401, 12)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "The data what you will key in, such as Customer, Contract, Sales, "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(383, 12)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "etc, all of them will be virtual, no any real business meaning."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 93)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(227, 12)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "They will be saved in Testing Server."
        '
        'grbProducingMode
        '
        Me.grbProducingMode.Controls.Add(Me.Label9)
        Me.grbProducingMode.Controls.Add(Me.Label10)
        Me.grbProducingMode.Controls.Add(Me.Label11)
        Me.grbProducingMode.Controls.Add(Me.Label12)
        Me.grbProducingMode.Controls.Add(Me.Label13)
        Me.grbProducingMode.Location = New System.Drawing.Point(12, 118)
        Me.grbProducingMode.Name = "grbProducingMode"
        Me.grbProducingMode.Size = New System.Drawing.Size(439, 120)
        Me.grbProducingMode.TabIndex = 5
        Me.grbProducingMode.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 93)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(389, 12)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "responsibility for them. They will be saved in Producing Server."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 76)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(413, 12)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "effective. Please take care when you input data because you have the"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 59)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(407, 12)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "All the data what you will input and can be saved, must be real and"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 37)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(353, 12)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "负责。所以，请您谨慎输入。这些数据将被保存在生产服务器中。"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(16, 20)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(401, 12)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "您所输入的可以被保存的数据必须是真实有效的，您需要对您所输入的数据"
        '
        'frmImportantInformation
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnOK
        Me.ClientSize = New System.Drawing.Size(464, 305)
        Me.Controls.Add(Me.grbProducingMode)
        Me.Controls.Add(Me.grbTrainingMode)
        Me.Controls.Add(Me.lblOperationMode)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnOK)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImportantInformation"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "重要提示 Very Important Information!!!"
        Me.grbTrainingMode.ResumeLayout(False)
        Me.grbTrainingMode.PerformLayout()
        Me.grbProducingMode.ResumeLayout(False)
        Me.grbProducingMode.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblOperationMode As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grbTrainingMode As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents grbProducingMode As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
