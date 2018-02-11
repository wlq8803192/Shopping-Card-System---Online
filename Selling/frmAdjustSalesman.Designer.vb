<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdjustSalesman
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAdjustSalesman))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txbOldSalesman = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbbBigFish = New System.Windows.Forms.ComboBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.flpSalesman = New System.Windows.Forms.FlowLayoutPanel
        Me.pnlBigFish = New System.Windows.Forms.Panel
        Me.rdbBigFish = New System.Windows.Forms.RadioButton
        Me.pnlMediumFish = New System.Windows.Forms.Panel
        Me.rdbMediumFish = New System.Windows.Forms.RadioButton
        Me.cbbMediumFish = New System.Windows.Forms.ComboBox
        Me.pnlOthers = New System.Windows.Forms.Panel
        Me.rdbOthers = New System.Windows.Forms.RadioButton
        Me.txbOtherSalesman = New System.Windows.Forms.TextBox
        Me.pnlNoSalesman = New System.Windows.Forms.Panel
        Me.chkNoSalesMan = New System.Windows.Forms.CheckBox
        Me.flpSalesman.SuspendLayout()
        Me.pnlBigFish.SuspendLayout()
        Me.pnlMediumFish.SuspendLayout()
        Me.pnlOthers.SuspendLayout()
        Me.pnlNoSalesman.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(365, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "注：指明销售单的业务员用于计算业务员（外勤人员）的销售业绩。"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "调整前的业务员："
        '
        'txbOldSalesman
        '
        Me.txbOldSalesman.Location = New System.Drawing.Point(119, 37)
        Me.txbOldSalesman.Name = "txbOldSalesman"
        Me.txbOldSalesman.ReadOnly = True
        Me.txbOldSalesman.Size = New System.Drawing.Size(176, 21)
        Me.txbOldSalesman.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(209, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "请在下面调整该销售单对应的业务员："
        '
        'cbbBigFish
        '
        Me.cbbBigFish.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbBigFish.Enabled = False
        Me.cbbBigFish.FormattingEnabled = True
        Me.cbbBigFish.Location = New System.Drawing.Point(86, 1)
        Me.cbbBigFish.Margin = New System.Windows.Forms.Padding(0)
        Me.cbbBigFish.Name = "cbbBigFish"
        Me.cbbBigFish.Size = New System.Drawing.Size(176, 20)
        Me.cbbBigFish.TabIndex = 1
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(220, 225)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "确定(&O)"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(301, 225)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "取消(&C)"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(-10, 208)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(411, 4)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'flpSalesman
        '
        Me.flpSalesman.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flpSalesman.AutoSize = True
        Me.flpSalesman.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpSalesman.Controls.Add(Me.pnlBigFish)
        Me.flpSalesman.Controls.Add(Me.pnlMediumFish)
        Me.flpSalesman.Controls.Add(Me.pnlOthers)
        Me.flpSalesman.Controls.Add(Me.pnlNoSalesman)
        Me.flpSalesman.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpSalesman.Location = New System.Drawing.Point(33, 93)
        Me.flpSalesman.Margin = New System.Windows.Forms.Padding(0)
        Me.flpSalesman.Name = "flpSalesman"
        Me.flpSalesman.Size = New System.Drawing.Size(265, 113)
        Me.flpSalesman.TabIndex = 4
        '
        'pnlBigFish
        '
        Me.pnlBigFish.AutoSize = True
        Me.pnlBigFish.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlBigFish.Controls.Add(Me.rdbBigFish)
        Me.pnlBigFish.Controls.Add(Me.cbbBigFish)
        Me.pnlBigFish.Location = New System.Drawing.Point(0, 0)
        Me.pnlBigFish.Margin = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.pnlBigFish.Name = "pnlBigFish"
        Me.pnlBigFish.Size = New System.Drawing.Size(262, 23)
        Me.pnlBigFish.TabIndex = 0
        '
        'rdbBigFish
        '
        Me.rdbBigFish.AutoSize = True
        Me.rdbBigFish.Location = New System.Drawing.Point(3, 4)
        Me.rdbBigFish.Name = "rdbBigFish"
        Me.rdbBigFish.Size = New System.Drawing.Size(83, 16)
        Me.rdbBigFish.TabIndex = 0
        Me.rdbBigFish.TabStop = True
        Me.rdbBigFish.Text = "大鱼团队："
        Me.rdbBigFish.UseVisualStyleBackColor = True
        '
        'pnlMediumFish
        '
        Me.pnlMediumFish.AutoSize = True
        Me.pnlMediumFish.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlMediumFish.Controls.Add(Me.rdbMediumFish)
        Me.pnlMediumFish.Controls.Add(Me.cbbMediumFish)
        Me.pnlMediumFish.Location = New System.Drawing.Point(0, 28)
        Me.pnlMediumFish.Margin = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.pnlMediumFish.Name = "pnlMediumFish"
        Me.pnlMediumFish.Size = New System.Drawing.Size(262, 23)
        Me.pnlMediumFish.TabIndex = 1
        '
        'rdbMediumFish
        '
        Me.rdbMediumFish.AutoSize = True
        Me.rdbMediumFish.Location = New System.Drawing.Point(3, 4)
        Me.rdbMediumFish.Name = "rdbMediumFish"
        Me.rdbMediumFish.Size = New System.Drawing.Size(83, 16)
        Me.rdbMediumFish.TabIndex = 0
        Me.rdbMediumFish.Text = "中鱼团队："
        Me.rdbMediumFish.UseVisualStyleBackColor = True
        '
        'cbbMediumFish
        '
        Me.cbbMediumFish.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbMediumFish.Enabled = False
        Me.cbbMediumFish.FormattingEnabled = True
        Me.cbbMediumFish.Location = New System.Drawing.Point(86, 1)
        Me.cbbMediumFish.Margin = New System.Windows.Forms.Padding(0)
        Me.cbbMediumFish.Name = "cbbMediumFish"
        Me.cbbMediumFish.Size = New System.Drawing.Size(176, 20)
        Me.cbbMediumFish.TabIndex = 1
        '
        'pnlOthers
        '
        Me.pnlOthers.AutoSize = True
        Me.pnlOthers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlOthers.Controls.Add(Me.rdbOthers)
        Me.pnlOthers.Controls.Add(Me.txbOtherSalesman)
        Me.pnlOthers.Location = New System.Drawing.Point(0, 56)
        Me.pnlOthers.Margin = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.pnlOthers.Name = "pnlOthers"
        Me.pnlOthers.Size = New System.Drawing.Size(265, 25)
        Me.pnlOthers.TabIndex = 2
        '
        'rdbOthers
        '
        Me.rdbOthers.Location = New System.Drawing.Point(3, 4)
        Me.rdbOthers.Name = "rdbOthers"
        Me.rdbOthers.Size = New System.Drawing.Size(83, 16)
        Me.rdbOthers.TabIndex = 0
        Me.rdbOthers.TabStop = True
        Me.rdbOthers.Text = "    其他："
        Me.rdbOthers.UseVisualStyleBackColor = True
        '
        'txbOtherSalesman
        '
        Me.txbOtherSalesman.Enabled = False
        Me.txbOtherSalesman.Location = New System.Drawing.Point(86, 1)
        Me.txbOtherSalesman.Name = "txbOtherSalesman"
        Me.txbOtherSalesman.Size = New System.Drawing.Size(176, 21)
        Me.txbOtherSalesman.TabIndex = 1
        '
        'pnlNoSalesman
        '
        Me.pnlNoSalesman.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlNoSalesman.Controls.Add(Me.chkNoSalesMan)
        Me.pnlNoSalesman.Location = New System.Drawing.Point(0, 86)
        Me.pnlNoSalesman.Margin = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.pnlNoSalesman.Name = "pnlNoSalesman"
        Me.pnlNoSalesman.Size = New System.Drawing.Size(263, 22)
        Me.pnlNoSalesman.TabIndex = 3
        '
        'chkNoSalesMan
        '
        Me.chkNoSalesMan.AutoSize = True
        Me.chkNoSalesMan.Location = New System.Drawing.Point(86, 3)
        Me.chkNoSalesMan.Name = "chkNoSalesMan"
        Me.chkNoSalesMan.Size = New System.Drawing.Size(84, 16)
        Me.chkNoSalesMan.TabIndex = 0
        Me.chkNoSalesMan.Text = "没有业务员"
        Me.chkNoSalesMan.UseVisualStyleBackColor = True
        '
        'frmAdjustSalesman
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(389, 260)
        Me.Controls.Add(Me.flpSalesman)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txbOldSalesman)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAdjustSalesman"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "请调整销售单的业务员："
        Me.flpSalesman.ResumeLayout(False)
        Me.flpSalesman.PerformLayout()
        Me.pnlBigFish.ResumeLayout(False)
        Me.pnlBigFish.PerformLayout()
        Me.pnlMediumFish.ResumeLayout(False)
        Me.pnlMediumFish.PerformLayout()
        Me.pnlOthers.ResumeLayout(False)
        Me.pnlOthers.PerformLayout()
        Me.pnlNoSalesman.ResumeLayout(False)
        Me.pnlNoSalesman.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txbOldSalesman As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbbBigFish As System.Windows.Forms.ComboBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents flpSalesman As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlBigFish As System.Windows.Forms.Panel
    Friend WithEvents rdbBigFish As System.Windows.Forms.RadioButton
    Friend WithEvents pnlMediumFish As System.Windows.Forms.Panel
    Friend WithEvents rdbMediumFish As System.Windows.Forms.RadioButton
    Friend WithEvents cbbMediumFish As System.Windows.Forms.ComboBox
    Friend WithEvents pnlOthers As System.Windows.Forms.Panel
    Friend WithEvents rdbOthers As System.Windows.Forms.RadioButton
    Friend WithEvents txbOtherSalesman As System.Windows.Forms.TextBox
    Friend WithEvents pnlNoSalesman As System.Windows.Forms.Panel
    Friend WithEvents chkNoSalesMan As System.Windows.Forms.CheckBox
End Class
