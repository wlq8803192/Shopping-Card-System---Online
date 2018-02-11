<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewCityRebateRule
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmViewCityRebateRule))
        Me.dgvValidated = New System.Windows.Forms.DataGridView
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblModifier1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblModifiedTime1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblAuditor1 = New System.Windows.Forms.Label
        Me.lblValidatedTime1 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblCityFullName = New System.Windows.Forms.Label
        Me.lblRemarks = New System.Windows.Forms.Label
        CType(Me.dgvValidated, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvValidated
        '
        Me.dgvValidated.AllowUserToAddRows = False
        Me.dgvValidated.AllowUserToDeleteRows = False
        Me.dgvValidated.AllowUserToResizeRows = False
        Me.dgvValidated.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvValidated.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvValidated.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvValidated.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvValidated.ColumnHeadersHeight = 36
        Me.dgvValidated.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvValidated.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvValidated.Location = New System.Drawing.Point(14, 27)
        Me.dgvValidated.MultiSelect = False
        Me.dgvValidated.Name = "dgvValidated"
        Me.dgvValidated.ReadOnly = True
        Me.dgvValidated.RowHeadersVisible = False
        Me.dgvValidated.RowTemplate.Height = 24
        Me.dgvValidated.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvValidated.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvValidated.Size = New System.Drawing.Size(563, 206)
        Me.dgvValidated.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(29, 250)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "修改者："
        '
        'lblModifier1
        '
        Me.lblModifier1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblModifier1.BackColor = System.Drawing.SystemColors.Info
        Me.lblModifier1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblModifier1.Location = New System.Drawing.Point(84, 246)
        Me.lblModifier1.Name = "lblModifier1"
        Me.lblModifier1.Size = New System.Drawing.Size(190, 18)
        Me.lblModifier1.TabIndex = 5
        Me.lblModifier1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(284, 250)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "修改时间："
        '
        'lblModifiedTime1
        '
        Me.lblModifiedTime1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblModifiedTime1.BackColor = System.Drawing.SystemColors.Info
        Me.lblModifiedTime1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblModifiedTime1.Location = New System.Drawing.Point(355, 246)
        Me.lblModifiedTime1.Name = "lblModifiedTime1"
        Me.lblModifiedTime1.Size = New System.Drawing.Size(190, 18)
        Me.lblModifiedTime1.TabIndex = 7
        Me.lblModifiedTime1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(29, 278)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "审核者："
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(284, 278)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "审核时间："
        '
        'lblAuditor1
        '
        Me.lblAuditor1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblAuditor1.BackColor = System.Drawing.SystemColors.Info
        Me.lblAuditor1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAuditor1.Location = New System.Drawing.Point(84, 274)
        Me.lblAuditor1.Name = "lblAuditor1"
        Me.lblAuditor1.Size = New System.Drawing.Size(190, 18)
        Me.lblAuditor1.TabIndex = 9
        Me.lblAuditor1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblValidatedTime1
        '
        Me.lblValidatedTime1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblValidatedTime1.BackColor = System.Drawing.SystemColors.Info
        Me.lblValidatedTime1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblValidatedTime1.Location = New System.Drawing.Point(355, 274)
        Me.lblValidatedTime1.Name = "lblValidatedTime1"
        Me.lblValidatedTime1.Size = New System.Drawing.Size(190, 18)
        Me.lblValidatedTime1.TabIndex = 11
        Me.lblValidatedTime1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "城市："
        '
        'lblCityFullName
        '
        Me.lblCityFullName.AutoSize = True
        Me.lblCityFullName.Location = New System.Drawing.Point(59, 9)
        Me.lblCityFullName.Name = "lblCityFullName"
        Me.lblCityFullName.Size = New System.Drawing.Size(0, 12)
        Me.lblCityFullName.TabIndex = 1
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.ForeColor = System.Drawing.Color.Maroon
        Me.lblRemarks.Location = New System.Drawing.Point(376, 9)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(209, 12)
        Me.lblRemarks.TabIndex = 2
        Me.lblRemarks.Text = "（黄色行是适用于当前销售单的规则）"
        '
        'frmViewCityRebateRule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(594, 306)
        Me.Controls.Add(Me.lblRemarks)
        Me.Controls.Add(Me.lblCityFullName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblValidatedTime1)
        Me.Controls.Add(Me.lblModifiedTime1)
        Me.Controls.Add(Me.lblAuditor1)
        Me.Controls.Add(Me.lblModifier1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dgvValidated)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmViewCityRebateRule"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "查看城市返点规则 （只读）"
        CType(Me.dgvValidated, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvValidated As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblModifier1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblModifiedTime1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblAuditor1 As System.Windows.Forms.Label
    Friend WithEvents lblValidatedTime1 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCityFullName As System.Windows.Forms.Label
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
End Class
