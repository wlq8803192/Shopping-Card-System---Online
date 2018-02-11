<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSwitchMode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSwitchMode))
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblOperationMode = New System.Windows.Forms.Label
        Me.grbSwitchMode = New System.Windows.Forms.GroupBox
        Me.flpSwitchMode = New System.Windows.Forms.FlowLayoutPanel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.rdbTrainingMode = New System.Windows.Forms.RadioButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblTrainingMode = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.pnlLockedTrainingMode = New System.Windows.Forms.Panel
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.rdbProducingMode = New System.Windows.Forms.RadioButton
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.lblProducingMode = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.pnlNotRollout = New System.Windows.Forms.Panel
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.pnlPrompt = New System.Windows.Forms.Panel
        Me.GroupBox1.SuspendLayout()
        Me.grbSwitchMode.SuspendLayout()
        Me.flpSwitchMode.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlLockedTrainingMode.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlNotRollout.SuspendLayout()
        Me.pnlPrompt.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(296, 438)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "确定(&O)"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(377, 438)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "取消(&C)"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(-10, 420)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(490, 4)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(359, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "系统目前所处的操作模式是 System current operation mode is: "
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblOperationMode)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(439, 79)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "当前模式 Current Mode:"
        '
        'lblOperationMode
        '
        Me.lblOperationMode.Font = New System.Drawing.Font("宋体", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblOperationMode.ForeColor = System.Drawing.Color.Maroon
        Me.lblOperationMode.Location = New System.Drawing.Point(9, 41)
        Me.lblOperationMode.Name = "lblOperationMode"
        Me.lblOperationMode.Size = New System.Drawing.Size(363, 29)
        Me.lblOperationMode.TabIndex = 1
        Me.lblOperationMode.Text = "培训模式 Training Mode"
        Me.lblOperationMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grbSwitchMode
        '
        Me.grbSwitchMode.Controls.Add(Me.flpSwitchMode)
        Me.grbSwitchMode.Location = New System.Drawing.Point(12, 94)
        Me.grbSwitchMode.Name = "grbSwitchMode"
        Me.grbSwitchMode.Size = New System.Drawing.Size(439, 315)
        Me.grbSwitchMode.TabIndex = 1
        Me.grbSwitchMode.TabStop = False
        Me.grbSwitchMode.Text = "切换模式 Switch Mode:"
        '
        'flpSwitchMode
        '
        Me.flpSwitchMode.AutoSize = True
        Me.flpSwitchMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpSwitchMode.Controls.Add(Me.Panel1)
        Me.flpSwitchMode.Controls.Add(Me.pnlLockedTrainingMode)
        Me.flpSwitchMode.Controls.Add(Me.Panel2)
        Me.flpSwitchMode.Controls.Add(Me.pnlNotRollout)
        Me.flpSwitchMode.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpSwitchMode.Location = New System.Drawing.Point(3, 14)
        Me.flpSwitchMode.Name = "flpSwitchMode"
        Me.flpSwitchMode.Size = New System.Drawing.Size(433, 296)
        Me.flpSwitchMode.TabIndex = 9
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rdbTrainingMode)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.lblTrainingMode)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(433, 114)
        Me.Panel1.TabIndex = 0
        '
        'rdbTrainingMode
        '
        Me.rdbTrainingMode.AutoSize = True
        Me.rdbTrainingMode.Checked = True
        Me.rdbTrainingMode.Location = New System.Drawing.Point(7, 9)
        Me.rdbTrainingMode.Name = "rdbTrainingMode"
        Me.rdbTrainingMode.Size = New System.Drawing.Size(14, 13)
        Me.rdbTrainingMode.TabIndex = 0
        Me.rdbTrainingMode.TabStop = True
        Me.rdbTrainingMode.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(389, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "用于培训或测试目的。该模式下产生的客户、合同和销售数据是虚拟的，"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(31, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(371, 12)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "It is used for training or testing. Under this mode, the data"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(31, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(329, 12)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "不具有实际的商业意义。这些数据将被保存在测试服务器中。"
        '
        'lblTrainingMode
        '
        Me.lblTrainingMode.AutoSize = True
        Me.lblTrainingMode.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblTrainingMode.ForeColor = System.Drawing.Color.Orange
        Me.lblTrainingMode.Location = New System.Drawing.Point(25, 7)
        Me.lblTrainingMode.Name = "lblTrainingMode"
        Me.lblTrainingMode.Size = New System.Drawing.Size(202, 16)
        Me.lblTrainingMode.TabIndex = 1
        Me.lblTrainingMode.Text = "培训模式 Training Mode"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(31, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(377, 12)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "of Customer, Contract and Sales, are virtual, not have actual "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(31, 97)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(335, 12)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "business meaning. They are saved in the Testing Server."
        '
        'pnlLockedTrainingMode
        '
        Me.pnlLockedTrainingMode.Controls.Add(Me.Label16)
        Me.pnlLockedTrainingMode.Controls.Add(Me.Label15)
        Me.pnlLockedTrainingMode.Location = New System.Drawing.Point(0, 114)
        Me.pnlLockedTrainingMode.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlLockedTrainingMode.Name = "pnlLockedTrainingMode"
        Me.pnlLockedTrainingMode.Size = New System.Drawing.Size(433, 34)
        Me.pnlLockedTrainingMode.TabIndex = 1
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.Red
        Me.Label16.Location = New System.Drawing.Point(31, 17)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(377, 12)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "(This mode has been blocked now, pls contact HO if necessary.)"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(31, 3)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(221, 12)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "(目前该模式被锁，有需要请联系总部。)"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rdbProducingMode)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.lblProducingMode)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Location = New System.Drawing.Point(0, 148)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(433, 114)
        Me.Panel2.TabIndex = 2
        '
        'rdbProducingMode
        '
        Me.rdbProducingMode.AutoSize = True
        Me.rdbProducingMode.Checked = True
        Me.rdbProducingMode.Location = New System.Drawing.Point(7, 9)
        Me.rdbProducingMode.Name = "rdbProducingMode"
        Me.rdbProducingMode.Size = New System.Drawing.Size(14, 13)
        Me.rdbProducingMode.TabIndex = 0
        Me.rdbProducingMode.TabStop = True
        Me.rdbProducingMode.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(32, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(233, 12)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "服务器中。用户必须对所输入的数据负责。"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(31, 65)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(395, 12)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Launch the system under real producing environment. All data are "
        '
        'lblProducingMode
        '
        Me.lblProducingMode.AutoSize = True
        Me.lblProducingMode.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblProducingMode.ForeColor = System.Drawing.Color.Orange
        Me.lblProducingMode.Location = New System.Drawing.Point(25, 7)
        Me.lblProducingMode.Name = "lblProducingMode"
        Me.lblProducingMode.Size = New System.Drawing.Size(211, 16)
        Me.lblProducingMode.TabIndex = 1
        Me.lblProducingMode.Text = "生产模式 Producing Mode"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(31, 81)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(389, 12)
        Me.Label13.TabIndex = 5
        Me.Label13.Text = "real and effective, and saved in Producing Server. The user must"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(32, 33)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(389, 12)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "即在正式生产环境下使用系统。所有数据都是真实有效的，都保存在生产"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(31, 97)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(317, 12)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "be responsible for all the data what he/her inputed."
        '
        'pnlNotRollout
        '
        Me.pnlNotRollout.Controls.Add(Me.Label18)
        Me.pnlNotRollout.Controls.Add(Me.Label17)
        Me.pnlNotRollout.Location = New System.Drawing.Point(0, 262)
        Me.pnlNotRollout.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlNotRollout.Name = "pnlNotRollout"
        Me.pnlNotRollout.Size = New System.Drawing.Size(433, 34)
        Me.pnlNotRollout.TabIndex = 3
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.Red
        Me.Label18.Location = New System.Drawing.Point(31, 17)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(353, 12)
        Me.Label18.TabIndex = 1
        Me.Label18.Text = "(Can't use this mode since it is not in rollout schedule.)"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.Red
        Me.Label17.Location = New System.Drawing.Point(31, 3)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(197, 12)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "(未安排上线，暂不能使用该模式。)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(2, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "注意："
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(49, 6)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(149, 12)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "切换模式后需要重新登录！"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(49, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(203, 12)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Need relogin System after switch!"
        '
        'pnlPrompt
        '
        Me.pnlPrompt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlPrompt.Controls.Add(Me.Label2)
        Me.pnlPrompt.Controls.Add(Me.Label9)
        Me.pnlPrompt.Controls.Add(Me.Label8)
        Me.pnlPrompt.Location = New System.Drawing.Point(12, 432)
        Me.pnlPrompt.Name = "pnlPrompt"
        Me.pnlPrompt.Size = New System.Drawing.Size(279, 34)
        Me.pnlPrompt.TabIndex = 3
        Me.pnlPrompt.Visible = False
        '
        'frmSwitchMode
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(464, 473)
        Me.Controls.Add(Me.pnlPrompt)
        Me.Controls.Add(Me.grbSwitchMode)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSwitchMode"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "切换操作模式 Switch Operation Mode"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grbSwitchMode.ResumeLayout(False)
        Me.grbSwitchMode.PerformLayout()
        Me.flpSwitchMode.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlLockedTrainingMode.ResumeLayout(False)
        Me.pnlLockedTrainingMode.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlNotRollout.ResumeLayout(False)
        Me.pnlNotRollout.PerformLayout()
        Me.pnlPrompt.ResumeLayout(False)
        Me.pnlPrompt.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblOperationMode As System.Windows.Forms.Label
    Friend WithEvents grbSwitchMode As System.Windows.Forms.GroupBox
    Friend WithEvents rdbTrainingMode As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblTrainingMode As System.Windows.Forms.Label
    Friend WithEvents pnlLockedTrainingMode As System.Windows.Forms.Panel
    Friend WithEvents lblProducingMode As System.Windows.Forms.Label
    Friend WithEvents rdbProducingMode As System.Windows.Forms.RadioButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents pnlNotRollout As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents pnlPrompt As System.Windows.Forms.Panel
    Friend WithEvents flpSwitchMode As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
