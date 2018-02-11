<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportedFileResult
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportedFileResult))
        Me.grbSource = New System.Windows.Forms.GroupBox
        Me.txbWorkSheet = New System.Windows.Forms.TextBox
        Me.txbSourceFile = New System.Windows.Forms.TextBox
        Me.txbSourceComputer = New System.Windows.Forms.TextBox
        Me.txbFileModifiedTime = New System.Windows.Forms.TextBox
        Me.txbFileSize = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.flpLayout = New System.Windows.Forms.FlowLayoutPanel
        Me.grbResult = New System.Windows.Forms.GroupBox
        Me.txbChargedAMT = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.dgvDetails = New System.Windows.Forms.DataGridView
        Me.Label9 = New System.Windows.Forms.Label
        Me.txbCardQTY = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.lblPrompt = New System.Windows.Forms.Label
        Me.grbSource.SuspendLayout()
        Me.flpLayout.SuspendLayout()
        Me.grbResult.SuspendLayout()
        CType(Me.dgvDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grbSource
        '
        Me.grbSource.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbSource.Controls.Add(Me.txbWorkSheet)
        Me.grbSource.Controls.Add(Me.txbSourceFile)
        Me.grbSource.Controls.Add(Me.txbSourceComputer)
        Me.grbSource.Controls.Add(Me.txbFileModifiedTime)
        Me.grbSource.Controls.Add(Me.txbFileSize)
        Me.grbSource.Controls.Add(Me.Label6)
        Me.grbSource.Controls.Add(Me.Label5)
        Me.grbSource.Controls.Add(Me.Label3)
        Me.grbSource.Controls.Add(Me.Label2)
        Me.grbSource.Controls.Add(Me.Label1)
        Me.grbSource.Controls.Add(Me.Label4)
        Me.grbSource.Location = New System.Drawing.Point(0, 0)
        Me.grbSource.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.grbSource.Name = "grbSource"
        Me.grbSource.Size = New System.Drawing.Size(664, 108)
        Me.grbSource.TabIndex = 0
        Me.grbSource.TabStop = False
        Me.grbSource.Text = "源文件信息："
        '
        'txbWorkSheet
        '
        Me.txbWorkSheet.Location = New System.Drawing.Point(75, 74)
        Me.txbWorkSheet.Name = "txbWorkSheet"
        Me.txbWorkSheet.ReadOnly = True
        Me.txbWorkSheet.Size = New System.Drawing.Size(147, 21)
        Me.txbWorkSheet.TabIndex = 5
        '
        'txbSourceFile
        '
        Me.txbSourceFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txbSourceFile.Location = New System.Drawing.Point(75, 47)
        Me.txbSourceFile.Name = "txbSourceFile"
        Me.txbSourceFile.ReadOnly = True
        Me.txbSourceFile.Size = New System.Drawing.Size(575, 21)
        Me.txbSourceFile.TabIndex = 3
        '
        'txbSourceComputer
        '
        Me.txbSourceComputer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txbSourceComputer.Location = New System.Drawing.Point(75, 20)
        Me.txbSourceComputer.Name = "txbSourceComputer"
        Me.txbSourceComputer.ReadOnly = True
        Me.txbSourceComputer.Size = New System.Drawing.Size(575, 21)
        Me.txbSourceComputer.TabIndex = 1
        '
        'txbFileModifiedTime
        '
        Me.txbFileModifiedTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txbFileModifiedTime.Location = New System.Drawing.Point(530, 74)
        Me.txbFileModifiedTime.Name = "txbFileModifiedTime"
        Me.txbFileModifiedTime.ReadOnly = True
        Me.txbFileModifiedTime.Size = New System.Drawing.Size(120, 21)
        Me.txbFileModifiedTime.TabIndex = 10
        Me.txbFileModifiedTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txbFileSize
        '
        Me.txbFileSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txbFileSize.Location = New System.Drawing.Point(293, 74)
        Me.txbFileSize.Name = "txbFileSize"
        Me.txbFileSize.ReadOnly = True
        Me.txbFileSize.Size = New System.Drawing.Size(84, 21)
        Me.txbFileSize.TabIndex = 7
        Me.txbFileSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(418, 79)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 12)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "文件最后修改时间："
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(378, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 12)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "字节"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "源工作表："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "源文件："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "源计算机："
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(229, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "文件大小："
        '
        'flpLayout
        '
        Me.flpLayout.AutoSize = True
        Me.flpLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpLayout.Controls.Add(Me.grbSource)
        Me.flpLayout.Controls.Add(Me.grbResult)
        Me.flpLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpLayout.Location = New System.Drawing.Point(12, 6)
        Me.flpLayout.Margin = New System.Windows.Forms.Padding(0)
        Me.flpLayout.Name = "flpLayout"
        Me.flpLayout.Size = New System.Drawing.Size(664, 396)
        Me.flpLayout.TabIndex = 0
        '
        'grbResult
        '
        Me.grbResult.Controls.Add(Me.txbChargedAMT)
        Me.grbResult.Controls.Add(Me.Label10)
        Me.grbResult.Controls.Add(Me.Label7)
        Me.grbResult.Controls.Add(Me.dgvDetails)
        Me.grbResult.Controls.Add(Me.Label9)
        Me.grbResult.Controls.Add(Me.txbCardQTY)
        Me.grbResult.Controls.Add(Me.Label8)
        Me.grbResult.Location = New System.Drawing.Point(0, 114)
        Me.grbResult.Margin = New System.Windows.Forms.Padding(0)
        Me.grbResult.Name = "grbResult"
        Me.grbResult.Size = New System.Drawing.Size(664, 282)
        Me.grbResult.TabIndex = 1
        Me.grbResult.TabStop = False
        Me.grbResult.Text = "导入结果："
        '
        'txbChargedAMT
        '
        Me.txbChargedAMT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txbChargedAMT.Location = New System.Drawing.Point(301, 247)
        Me.txbChargedAMT.Name = "txbChargedAMT"
        Me.txbChargedAMT.ReadOnly = True
        Me.txbChargedAMT.Size = New System.Drawing.Size(121, 21)
        Me.txbChargedAMT.TabIndex = 7
        Me.txbChargedAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(201, 252)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(101, 12)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "已导入充值金额："
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 252)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 12)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "已导入卡数："
        '
        'dgvDetails
        '
        Me.dgvDetails.AllowUserToAddRows = False
        Me.dgvDetails.AllowUserToDeleteRows = False
        Me.dgvDetails.AllowUserToResizeRows = False
        Me.dgvDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetails.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDetails.ColumnHeadersHeight = 22
        Me.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDetails.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDetails.Location = New System.Drawing.Point(12, 22)
        Me.dgvDetails.MultiSelect = False
        Me.dgvDetails.Name = "dgvDetails"
        Me.dgvDetails.ReadOnly = True
        Me.dgvDetails.RowHeadersVisible = False
        Me.dgvDetails.RowTemplate.Height = 24
        Me.dgvDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetails.Size = New System.Drawing.Size(638, 216)
        Me.dgvDetails.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(423, 252)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(17, 12)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "元"
        '
        'txbCardQTY
        '
        Me.txbCardQTY.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txbCardQTY.Location = New System.Drawing.Point(93, 247)
        Me.txbCardQTY.Name = "txbCardQTY"
        Me.txbCardQTY.ReadOnly = True
        Me.txbCardQTY.Size = New System.Drawing.Size(84, 21)
        Me.txbCardQTY.TabIndex = 7
        Me.txbCardQTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(178, 252)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(17, 12)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "张"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(601, 414)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "关闭(&C)"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblPrompt
        '
        Me.lblPrompt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPrompt.AutoSize = True
        Me.lblPrompt.Location = New System.Drawing.Point(10, 419)
        Me.lblPrompt.Name = "lblPrompt"
        Me.lblPrompt.Size = New System.Drawing.Size(317, 12)
        Me.lblPrompt.TabIndex = 2
        Me.lblPrompt.Text = "源文件中不存在任何满足导入条件的卡号！请检查源文件。"
        Me.lblPrompt.Visible = False
        '
        'frmImportedFileResult
        '
        Me.AcceptButton = Me.btnClose
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(690, 448)
        Me.Controls.Add(Me.lblPrompt)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.flpLayout)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImportedFileResult"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "查看导入结果"
        Me.grbSource.ResumeLayout(False)
        Me.grbSource.PerformLayout()
        Me.flpLayout.ResumeLayout(False)
        Me.grbResult.ResumeLayout(False)
        Me.grbResult.PerformLayout()
        CType(Me.dgvDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbSource As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txbWorkSheet As System.Windows.Forms.TextBox
    Friend WithEvents txbSourceFile As System.Windows.Forms.TextBox
    Friend WithEvents txbSourceComputer As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txbFileSize As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txbFileModifiedTime As System.Windows.Forms.TextBox
    Friend WithEvents flpLayout As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents grbResult As System.Windows.Forms.GroupBox
    Friend WithEvents dgvDetails As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txbChargedAMT As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txbCardQTY As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblPrompt As System.Windows.Forms.Label
End Class
