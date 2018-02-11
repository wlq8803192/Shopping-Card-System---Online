<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDealingQuery_Section
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnClose = New System.Windows.Forms.Button
        Me.lblState = New System.Windows.Forms.Label
        Me.grbState = New System.Windows.Forms.GroupBox
        Me.dgvState = New System.Windows.Forms.DataGridView
        Me.lblCardNo = New System.Windows.Forms.Label
        Me.btnQuery = New System.Windows.Forms.Button
        Me.txbCardNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txbCardNo_End = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblSumBalance = New System.Windows.Forms.Label
        Me.lblTimeDiff = New System.Windows.Forms.Label
        Me.grbState.SuspendLayout()
        CType(Me.dgvState, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(-13, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(923, 3)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(810, 10)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 13
        Me.btnClose.Text = "关闭(&C)"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblState
        '
        Me.lblState.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblState.BackColor = System.Drawing.SystemColors.Window
        Me.lblState.ForeColor = System.Drawing.Color.Maroon
        Me.lblState.Location = New System.Drawing.Point(15, 46)
        Me.lblState.Name = "lblState"
        Me.lblState.Size = New System.Drawing.Size(843, 407)
        Me.lblState.TabIndex = 1
        Me.lblState.Text = "（未查询）"
        Me.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grbState
        '
        Me.grbState.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbState.Controls.Add(Me.lblTimeDiff)
        Me.grbState.Controls.Add(Me.lblState)
        Me.grbState.Controls.Add(Me.dgvState)
        Me.grbState.Location = New System.Drawing.Point(11, 52)
        Me.grbState.Name = "grbState"
        Me.grbState.Size = New System.Drawing.Size(873, 469)
        Me.grbState.TabIndex = 15
        Me.grbState.TabStop = False
        Me.grbState.Text = "购物卡状态："
        '
        'dgvState
        '
        Me.dgvState.AllowUserToAddRows = False
        Me.dgvState.AllowUserToDeleteRows = False
        Me.dgvState.AllowUserToResizeRows = False
        Me.dgvState.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvState.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvState.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvState.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvState.ColumnHeadersHeight = 22
        Me.dgvState.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvState.Location = New System.Drawing.Point(12, 19)
        Me.dgvState.MultiSelect = False
        Me.dgvState.Name = "dgvState"
        Me.dgvState.ReadOnly = True
        Me.dgvState.RowHeadersVisible = False
        Me.dgvState.RowTemplate.Height = 24
        Me.dgvState.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvState.Size = New System.Drawing.Size(849, 437)
        Me.dgvState.TabIndex = 0
        '
        'lblCardNo
        '
        Me.lblCardNo.AutoSize = True
        Me.lblCardNo.Location = New System.Drawing.Point(441, 15)
        Me.lblCardNo.Name = "lblCardNo"
        Me.lblCardNo.Size = New System.Drawing.Size(0, 13)
        Me.lblCardNo.TabIndex = 11
        '
        'btnQuery
        '
        Me.btnQuery.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnQuery.Enabled = False
        Me.btnQuery.Location = New System.Drawing.Point(729, 10)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(75, 23)
        Me.btnQuery.TabIndex = 10
        Me.btnQuery.Text = "查询(&Q)"
        Me.btnQuery.UseVisualStyleBackColor = True
        '
        'txbCardNo
        '
        Me.txbCardNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbCardNo.Location = New System.Drawing.Point(154, 12)
        Me.txbCardNo.MaxLength = 19
        Me.txbCardNo.Name = "txbCardNo"
        Me.txbCardNo.Size = New System.Drawing.Size(121, 20)
        Me.txbCardNo.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(141, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "请输入待查询的卡号(&N)："
        '
        'txbCardNo_End
        '
        Me.txbCardNo_End.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbCardNo_End.Location = New System.Drawing.Point(304, 12)
        Me.txbCardNo_End.MaxLength = 19
        Me.txbCardNo_End.Name = "txbCardNo_End"
        Me.txbCardNo_End.Size = New System.Drawing.Size(121, 20)
        Me.txbCardNo_End.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(281, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "---"
        '
        'lblSumBalance
        '
        Me.lblSumBalance.AutoSize = True
        Me.lblSumBalance.Location = New System.Drawing.Point(582, 15)
        Me.lblSumBalance.Name = "lblSumBalance"
        Me.lblSumBalance.Size = New System.Drawing.Size(67, 13)
        Me.lblSumBalance.TabIndex = 18
        Me.lblSumBalance.Text = "余额汇总："
        '
        'lblTimeDiff
        '
        Me.lblTimeDiff.AutoSize = True
        Me.lblTimeDiff.Location = New System.Drawing.Point(93, 0)
        Me.lblTimeDiff.Name = "lblTimeDiff"
        Me.lblTimeDiff.Size = New System.Drawing.Size(43, 13)
        Me.lblTimeDiff.TabIndex = 19
        Me.lblTimeDiff.Text = "用时："
        '
        'frmDealingQuery_Section
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(896, 533)
        Me.Controls.Add(Me.lblSumBalance)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txbCardNo_End)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.grbState)
        Me.Controls.Add(Me.lblCardNo)
        Me.Controls.Add(Me.btnQuery)
        Me.Controls.Add(Me.txbCardNo)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDealingQuery_Section"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "购物卡状态批量查询  Card Status Query"
        Me.grbState.ResumeLayout(False)
        Me.grbState.PerformLayout()
        CType(Me.dgvState, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblState As System.Windows.Forms.Label
    Friend WithEvents grbState As System.Windows.Forms.GroupBox
    Friend WithEvents dgvState As System.Windows.Forms.DataGridView
    Friend WithEvents lblCardNo As System.Windows.Forms.Label
    Friend WithEvents btnQuery As System.Windows.Forms.Button
    Friend WithEvents txbCardNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txbCardNo_End As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblSumBalance As System.Windows.Forms.Label
    Friend WithEvents lblTimeDiff As System.Windows.Forms.Label
End Class
