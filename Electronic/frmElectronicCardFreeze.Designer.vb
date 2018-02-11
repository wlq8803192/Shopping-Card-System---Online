<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmElectronicCardFreeze
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFreezeCard))
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnHistory = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnStart = New System.Windows.Forms.Button
        Me.btnPrevious = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnFinish = New System.Windows.Forms.Button
        Me.grbCardNo = New System.Windows.Forms.GroupBox
        Me.lblCardNoError = New System.Windows.Forms.Label
        Me.lblEndCardError = New System.Windows.Forms.Label
        Me.lblStartCardError = New System.Windows.Forms.Label
        Me.txbEndCardNo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txbStartCardNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.pnlStep1 = New System.Windows.Forms.Panel
        Me.lblInfo1 = New System.Windows.Forms.Label
        Me.pnlStep2 = New System.Windows.Forms.Panel
        Me.lblInfo2 = New System.Windows.Forms.Label
        Me.grbCardState = New System.Windows.Forms.GroupBox
        Me.dgvOldState = New System.Windows.Forms.DataGridView
        Me.pnlStep3 = New System.Windows.Forms.Panel
        Me.lblInfo3 = New System.Windows.Forms.Label
        Me.grbReason = New System.Windows.Forms.GroupBox
        Me.txbReason = New System.Windows.Forms.TextBox
        Me.lblReason = New System.Windows.Forms.Label
        Me.pnlStep4 = New System.Windows.Forms.Panel
        Me.lblInfo4 = New System.Windows.Forms.Label
        Me.grbResult = New System.Windows.Forms.GroupBox
        Me.pnlResult = New System.Windows.Forms.Panel
        Me.lblResult = New System.Windows.Forms.Label
        Me.dgvNewState = New System.Windows.Forms.DataGridView
        Me.grbCardNo.SuspendLayout()
        Me.pnlStep1.SuspendLayout()
        Me.pnlStep2.SuspendLayout()
        Me.grbCardState.SuspendLayout()
        CType(Me.dgvOldState, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlStep3.SuspendLayout()
        Me.grbReason.SuspendLayout()
        Me.pnlStep4.SuspendLayout()
        Me.grbResult.SuspendLayout()
        Me.pnlResult.SuspendLayout()
        CType(Me.dgvNewState, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(507, 289)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "取消(&C)"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnHistory
        '
        Me.btnHistory.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHistory.Location = New System.Drawing.Point(396, 289)
        Me.btnHistory.Name = "btnHistory"
        Me.btnHistory.Size = New System.Drawing.Size(105, 23)
        Me.btnHistory.TabIndex = 9
        Me.btnHistory.Text = "查看历史记录(&H)"
        Me.btnHistory.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(-10, 274)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(619, 3)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'btnStart
        '
        Me.btnStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnStart.Enabled = False
        Me.btnStart.Location = New System.Drawing.Point(11, 289)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(80, 23)
        Me.btnStart.TabIndex = 5
        Me.btnStart.Text = "|<< 开始(&T)"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnPrevious
        '
        Me.btnPrevious.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrevious.Enabled = False
        Me.btnPrevious.Location = New System.Drawing.Point(97, 289)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(80, 23)
        Me.btnPrevious.TabIndex = 6
        Me.btnPrevious.Text = "< 上一步(&P)"
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNext.Enabled = False
        Me.btnNext.Location = New System.Drawing.Point(183, 289)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(80, 23)
        Me.btnNext.TabIndex = 7
        Me.btnNext.Text = "下一步(&N) >"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnFinish
        '
        Me.btnFinish.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnFinish.Enabled = False
        Me.btnFinish.Location = New System.Drawing.Point(269, 289)
        Me.btnFinish.Name = "btnFinish"
        Me.btnFinish.Size = New System.Drawing.Size(80, 23)
        Me.btnFinish.TabIndex = 8
        Me.btnFinish.Text = "完成 >>|(&F)"
        Me.btnFinish.UseVisualStyleBackColor = True
        '
        'grbCardNo
        '
        Me.grbCardNo.Controls.Add(Me.lblCardNoError)
        Me.grbCardNo.Controls.Add(Me.lblEndCardError)
        Me.grbCardNo.Controls.Add(Me.lblStartCardError)
        Me.grbCardNo.Controls.Add(Me.txbEndCardNo)
        Me.grbCardNo.Controls.Add(Me.Label2)
        Me.grbCardNo.Controls.Add(Me.txbStartCardNo)
        Me.grbCardNo.Controls.Add(Me.Label1)
        Me.grbCardNo.Location = New System.Drawing.Point(0, 0)
        Me.grbCardNo.Name = "grbCardNo"
        Me.grbCardNo.Size = New System.Drawing.Size(569, 227)
        Me.grbCardNo.TabIndex = 0
        Me.grbCardNo.TabStop = False
        Me.grbCardNo.Text = "第一步：输入开始卡号与结束卡号"
        '
        'lblCardNoError
        '
        Me.lblCardNoError.AutoSize = True
        Me.lblCardNoError.ForeColor = System.Drawing.Color.Red
        Me.lblCardNoError.Location = New System.Drawing.Point(104, 84)
        Me.lblCardNoError.Name = "lblCardNoError"
        Me.lblCardNoError.Size = New System.Drawing.Size(0, 12)
        Me.lblCardNoError.TabIndex = 5
        '
        'lblEndCardError
        '
        Me.lblEndCardError.AutoSize = True
        Me.lblEndCardError.ForeColor = System.Drawing.Color.Red
        Me.lblEndCardError.Location = New System.Drawing.Point(233, 56)
        Me.lblEndCardError.Name = "lblEndCardError"
        Me.lblEndCardError.Size = New System.Drawing.Size(0, 12)
        Me.lblEndCardError.TabIndex = 4
        '
        'lblStartCardError
        '
        Me.lblStartCardError.AutoSize = True
        Me.lblStartCardError.ForeColor = System.Drawing.Color.Red
        Me.lblStartCardError.Location = New System.Drawing.Point(233, 29)
        Me.lblStartCardError.Name = "lblStartCardError"
        Me.lblStartCardError.Size = New System.Drawing.Size(0, 12)
        Me.lblStartCardError.TabIndex = 4
        '
        'txbEndCardNo
        '
        Me.txbEndCardNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbEndCardNo.Location = New System.Drawing.Point(106, 51)
        Me.txbEndCardNo.MaxLength = 19
        Me.txbEndCardNo.Name = "txbEndCardNo"
        Me.txbEndCardNo.Size = New System.Drawing.Size(121, 21)
        Me.txbEndCardNo.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "结束卡号(&E)："
        '
        'txbStartCardNo
        '
        Me.txbStartCardNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbStartCardNo.Location = New System.Drawing.Point(106, 24)
        Me.txbStartCardNo.MaxLength = 19
        Me.txbStartCardNo.Name = "txbStartCardNo"
        Me.txbStartCardNo.Size = New System.Drawing.Size(121, 21)
        Me.txbStartCardNo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "开始卡号(&S)："
        '
        'pnlStep1
        '
        Me.pnlStep1.Controls.Add(Me.lblInfo1)
        Me.pnlStep1.Controls.Add(Me.grbCardNo)
        Me.pnlStep1.Location = New System.Drawing.Point(12, 8)
        Me.pnlStep1.Name = "pnlStep1"
        Me.pnlStep1.Size = New System.Drawing.Size(569, 258)
        Me.pnlStep1.TabIndex = 0
        '
        'lblInfo1
        '
        Me.lblInfo1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblInfo1.AutoSize = True
        Me.lblInfo1.Location = New System.Drawing.Point(3, 242)
        Me.lblInfo1.Name = "lblInfo1"
        Me.lblInfo1.Size = New System.Drawing.Size(0, 12)
        Me.lblInfo1.TabIndex = 1
        '
        'pnlStep2
        '
        Me.pnlStep2.Controls.Add(Me.lblInfo2)
        Me.pnlStep2.Controls.Add(Me.grbCardState)
        Me.pnlStep2.Location = New System.Drawing.Point(12, 8)
        Me.pnlStep2.Name = "pnlStep2"
        Me.pnlStep2.Size = New System.Drawing.Size(569, 258)
        Me.pnlStep2.TabIndex = 1
        Me.pnlStep2.Visible = False
        '
        'lblInfo2
        '
        Me.lblInfo2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblInfo2.AutoSize = True
        Me.lblInfo2.Location = New System.Drawing.Point(3, 242)
        Me.lblInfo2.Name = "lblInfo2"
        Me.lblInfo2.Size = New System.Drawing.Size(413, 12)
        Me.lblInfo2.TabIndex = 1
        Me.lblInfo2.Text = "查询完成。您可以对该批卡执行""冻结""操作，请按""下一卡""输入冻结原因……"
        '
        'grbCardState
        '
        Me.grbCardState.Controls.Add(Me.dgvOldState)
        Me.grbCardState.Location = New System.Drawing.Point(0, 0)
        Me.grbCardState.Name = "grbCardState"
        Me.grbCardState.Size = New System.Drawing.Size(569, 227)
        Me.grbCardState.TabIndex = 0
        Me.grbCardState.TabStop = False
        Me.grbCardState.Text = "第二步：在CUL系统查询购物卡状态"
        '
        'dgvOldState
        '
        Me.dgvOldState.AllowUserToAddRows = False
        Me.dgvOldState.AllowUserToDeleteRows = False
        Me.dgvOldState.AllowUserToResizeRows = False
        Me.dgvOldState.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvOldState.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvOldState.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOldState.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvOldState.ColumnHeadersHeight = 22
        Me.dgvOldState.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvOldState.Location = New System.Drawing.Point(12, 21)
        Me.dgvOldState.MultiSelect = False
        Me.dgvOldState.Name = "dgvOldState"
        Me.dgvOldState.ReadOnly = True
        Me.dgvOldState.RowHeadersVisible = False
        Me.dgvOldState.RowTemplate.Height = 24
        Me.dgvOldState.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvOldState.Size = New System.Drawing.Size(545, 192)
        Me.dgvOldState.TabIndex = 0
        '
        'pnlStep3
        '
        Me.pnlStep3.Controls.Add(Me.lblInfo3)
        Me.pnlStep3.Controls.Add(Me.grbReason)
        Me.pnlStep3.Location = New System.Drawing.Point(12, 8)
        Me.pnlStep3.Name = "pnlStep3"
        Me.pnlStep3.Size = New System.Drawing.Size(569, 258)
        Me.pnlStep3.TabIndex = 3
        Me.pnlStep3.Visible = False
        '
        'lblInfo3
        '
        Me.lblInfo3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblInfo3.AutoSize = True
        Me.lblInfo3.Location = New System.Drawing.Point(3, 242)
        Me.lblInfo3.Name = "lblInfo3"
        Me.lblInfo3.Size = New System.Drawing.Size(0, 12)
        Me.lblInfo3.TabIndex = 1
        Me.lblInfo3.Visible = False
        '
        'grbReason
        '
        Me.grbReason.Controls.Add(Me.txbReason)
        Me.grbReason.Controls.Add(Me.lblReason)
        Me.grbReason.Location = New System.Drawing.Point(0, 0)
        Me.grbReason.Name = "grbReason"
        Me.grbReason.Size = New System.Drawing.Size(569, 227)
        Me.grbReason.TabIndex = 0
        Me.grbReason.TabStop = False
        Me.grbReason.Text = "第三步：输入冻结原因"
        '
        'txbReason
        '
        Me.txbReason.Location = New System.Drawing.Point(19, 51)
        Me.txbReason.MaxLength = 50
        Me.txbReason.Name = "txbReason"
        Me.txbReason.Size = New System.Drawing.Size(530, 21)
        Me.txbReason.TabIndex = 1
        '
        'lblReason
        '
        Me.lblReason.AutoSize = True
        Me.lblReason.Location = New System.Drawing.Point(17, 27)
        Me.lblReason.Name = "lblReason"
        Me.lblReason.Size = New System.Drawing.Size(341, 12)
        Me.lblReason.TabIndex = 0
        Me.lblReason.Text = "您即将冻结该批购物卡，请输入冻结原因（限 50 个字以内）："
        '
        'pnlStep4
        '
        Me.pnlStep4.Controls.Add(Me.lblInfo4)
        Me.pnlStep4.Controls.Add(Me.grbResult)
        Me.pnlStep4.Location = New System.Drawing.Point(12, 8)
        Me.pnlStep4.Name = "pnlStep4"
        Me.pnlStep4.Size = New System.Drawing.Size(569, 258)
        Me.pnlStep4.TabIndex = 3
        Me.pnlStep4.Visible = False
        '
        'lblInfo4
        '
        Me.lblInfo4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblInfo4.AutoSize = True
        Me.lblInfo4.Location = New System.Drawing.Point(3, 242)
        Me.lblInfo4.Name = "lblInfo4"
        Me.lblInfo4.Size = New System.Drawing.Size(353, 12)
        Me.lblInfo4.TabIndex = 1
        Me.lblInfo4.Text = "当次操作已完成。按""开始""执行新的操作，或按""关闭""结束操作。"
        '
        'grbResult
        '
        Me.grbResult.Controls.Add(Me.pnlResult)
        Me.grbResult.Location = New System.Drawing.Point(0, 0)
        Me.grbResult.Name = "grbResult"
        Me.grbResult.Size = New System.Drawing.Size(569, 227)
        Me.grbResult.TabIndex = 0
        Me.grbResult.TabStop = False
        Me.grbResult.Text = "第四步：到CUL冻结购物卡"
        '
        'pnlResult
        '
        Me.pnlResult.Controls.Add(Me.lblResult)
        Me.pnlResult.Controls.Add(Me.dgvNewState)
        Me.pnlResult.Location = New System.Drawing.Point(6, 20)
        Me.pnlResult.Name = "pnlResult"
        Me.pnlResult.Size = New System.Drawing.Size(557, 201)
        Me.pnlResult.TabIndex = 0
        Me.pnlResult.Visible = False
        '
        'lblResult
        '
        Me.lblResult.AutoSize = True
        Me.lblResult.Location = New System.Drawing.Point(4, 4)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(185, 12)
        Me.lblResult.TabIndex = 0
        Me.lblResult.Text = "这是冻结后的购物卡的最新状态："
        '
        'dgvNewState
        '
        Me.dgvNewState.AllowUserToAddRows = False
        Me.dgvNewState.AllowUserToDeleteRows = False
        Me.dgvNewState.AllowUserToResizeRows = False
        Me.dgvNewState.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvNewState.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvNewState.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvNewState.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvNewState.ColumnHeadersHeight = 22
        Me.dgvNewState.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvNewState.Location = New System.Drawing.Point(6, 25)
        Me.dgvNewState.MultiSelect = False
        Me.dgvNewState.Name = "dgvNewState"
        Me.dgvNewState.ReadOnly = True
        Me.dgvNewState.RowHeadersVisible = False
        Me.dgvNewState.RowTemplate.Height = 24
        Me.dgvNewState.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvNewState.Size = New System.Drawing.Size(545, 168)
        Me.dgvNewState.TabIndex = 1
        '
        'frmFreezeCard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(594, 324)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnPrevious)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.btnFinish)
        Me.Controls.Add(Me.btnHistory)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pnlStep1)
        Me.Controls.Add(Me.pnlStep4)
        Me.Controls.Add(Me.pnlStep2)
        Me.Controls.Add(Me.pnlStep3)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFreezeCard"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "电子卡冻结/解冻 Freeze/unfreeze Card"
        Me.grbCardNo.ResumeLayout(False)
        Me.grbCardNo.PerformLayout()
        Me.pnlStep1.ResumeLayout(False)
        Me.pnlStep1.PerformLayout()
        Me.pnlStep2.ResumeLayout(False)
        Me.pnlStep2.PerformLayout()
        Me.grbCardState.ResumeLayout(False)
        CType(Me.dgvOldState, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlStep3.ResumeLayout(False)
        Me.pnlStep3.PerformLayout()
        Me.grbReason.ResumeLayout(False)
        Me.grbReason.PerformLayout()
        Me.pnlStep4.ResumeLayout(False)
        Me.pnlStep4.PerformLayout()
        Me.grbResult.ResumeLayout(False)
        Me.pnlResult.ResumeLayout(False)
        Me.pnlResult.PerformLayout()
        CType(Me.dgvNewState, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnHistory As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnPrevious As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnFinish As System.Windows.Forms.Button
    Friend WithEvents grbCardNo As System.Windows.Forms.GroupBox
    Friend WithEvents pnlStep1 As System.Windows.Forms.Panel
    Friend WithEvents lblInfo1 As System.Windows.Forms.Label
    Friend WithEvents txbEndCardNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txbStartCardNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblEndCardError As System.Windows.Forms.Label
    Friend WithEvents lblStartCardError As System.Windows.Forms.Label
    Friend WithEvents pnlStep2 As System.Windows.Forms.Panel
    Friend WithEvents lblInfo2 As System.Windows.Forms.Label
    Friend WithEvents grbCardState As System.Windows.Forms.GroupBox
    Friend WithEvents dgvOldState As System.Windows.Forms.DataGridView
    Friend WithEvents lblCardNoError As System.Windows.Forms.Label
    Friend WithEvents pnlStep3 As System.Windows.Forms.Panel
    Friend WithEvents lblInfo3 As System.Windows.Forms.Label
    Friend WithEvents grbReason As System.Windows.Forms.GroupBox
    Friend WithEvents lblReason As System.Windows.Forms.Label
    Friend WithEvents txbReason As System.Windows.Forms.TextBox
    Friend WithEvents pnlStep4 As System.Windows.Forms.Panel
    Friend WithEvents lblInfo4 As System.Windows.Forms.Label
    Friend WithEvents grbResult As System.Windows.Forms.GroupBox
    Friend WithEvents dgvNewState As System.Windows.Forms.DataGridView
    Friend WithEvents lblResult As System.Windows.Forms.Label
    Friend WithEvents pnlResult As System.Windows.Forms.Panel
End Class
