<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCrossSellingCityConfig
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCrossSellingCityConfig))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgvValidated = New System.Windows.Forms.DataGridView
        Me.dgvPending = New System.Windows.Forms.DataGridView
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblModifier1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblModifiedTime1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblAuditor1 = New System.Windows.Forms.Label
        Me.lblValidatedTime1 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbbCity = New System.Windows.Forms.ComboBox
        Me.btnSave = New System.Windows.Forms.Button
        Me.txbReason = New System.Windows.Forms.TextBox
        Me.rdbFailure = New System.Windows.Forms.RadioButton
        Me.rdbOK = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnCopy = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.lblModifier2 = New System.Windows.Forms.Label
        Me.lblModifiedTime2 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btnDeleteRow = New System.Windows.Forms.Button
        Me.btnPaste = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.pnlValidate = New System.Windows.Forms.Panel
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblAuditor2 = New System.Windows.Forms.Label
        Me.lblValidatedTime2 = New System.Windows.Forms.Label
        CType(Me.dgvValidated, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPending, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.pnlValidate.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Location = New System.Drawing.Point(-3, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(799, 4)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "10"
        '
        'dgvValidated
        '
        Me.dgvValidated.AllowUserToAddRows = False
        Me.dgvValidated.AllowUserToDeleteRows = False
        Me.dgvValidated.AllowUserToResizeRows = False
        Me.dgvValidated.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvValidated.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvValidated.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvValidated.ColumnHeadersHeight = 36
        Me.dgvValidated.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvValidated.Location = New System.Drawing.Point(13, 65)
        Me.dgvValidated.MultiSelect = False
        Me.dgvValidated.Name = "dgvValidated"
        Me.dgvValidated.ReadOnly = True
        Me.dgvValidated.RowHeadersVisible = False
        Me.dgvValidated.RowTemplate.Height = 24
        Me.dgvValidated.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvValidated.Size = New System.Drawing.Size(563, 206)
        Me.dgvValidated.TabIndex = 4
        '
        'dgvPending
        '
        Me.dgvPending.AllowUserToAddRows = False
        Me.dgvPending.AllowUserToDeleteRows = False
        Me.dgvPending.AllowUserToResizeRows = False
        Me.dgvPending.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvPending.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPending.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPending.ColumnHeadersHeight = 36
        Me.dgvPending.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvPending.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvPending.Location = New System.Drawing.Point(13, 311)
        Me.dgvPending.MultiSelect = False
        Me.dgvPending.Name = "dgvPending"
        Me.dgvPending.RowHeadersVisible = False
        Me.dgvPending.RowTemplate.Height = 24
        Me.dgvPending.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvPending.Size = New System.Drawing.Size(563, 206)
        Me.dgvPending.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label7.Location = New System.Drawing.Point(12, 286)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(461, 12)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "已修改未生效的返点规则 Modified and need to be validated Discount Rate Rule:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Location = New System.Drawing.Point(-3, 290)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(799, 4)
        Me.GroupBox3.TabIndex = 15
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "GroupBox3"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(587, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(143, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "修改者 Modified Person:"
        '
        'lblModifier1
        '
        Me.lblModifier1.BackColor = System.Drawing.SystemColors.Info
        Me.lblModifier1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblModifier1.Location = New System.Drawing.Point(587, 80)
        Me.lblModifier1.Name = "lblModifier1"
        Me.lblModifier1.Size = New System.Drawing.Size(190, 18)
        Me.lblModifier1.TabIndex = 6
        Me.lblModifier1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(587, 101)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(143, 12)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "修改时间 Modified Time:"
        '
        'lblModifiedTime1
        '
        Me.lblModifiedTime1.BackColor = System.Drawing.SystemColors.Info
        Me.lblModifiedTime1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblModifiedTime1.Location = New System.Drawing.Point(587, 116)
        Me.lblModifiedTime1.Name = "lblModifiedTime1"
        Me.lblModifiedTime1.Size = New System.Drawing.Size(190, 18)
        Me.lblModifiedTime1.TabIndex = 8
        Me.lblModifiedTime1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(587, 137)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(149, 12)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "审核者 Validated Person:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(587, 173)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(149, 12)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "审核时间 Validated Time:"
        '
        'lblAuditor1
        '
        Me.lblAuditor1.BackColor = System.Drawing.SystemColors.Info
        Me.lblAuditor1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAuditor1.Location = New System.Drawing.Point(587, 152)
        Me.lblAuditor1.Name = "lblAuditor1"
        Me.lblAuditor1.Size = New System.Drawing.Size(190, 18)
        Me.lblAuditor1.TabIndex = 10
        Me.lblAuditor1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblValidatedTime1
        '
        Me.lblValidatedTime1.BackColor = System.Drawing.SystemColors.Info
        Me.lblValidatedTime1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblValidatedTime1.Location = New System.Drawing.Point(587, 188)
        Me.lblValidatedTime1.Name = "lblValidatedTime1"
        Me.lblValidatedTime1.Size = New System.Drawing.Size(190, 18)
        Me.lblValidatedTime1.TabIndex = 12
        Me.lblValidatedTime1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "城市 City:"
        '
        'cbbCity
        '
        Me.cbbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbCity.FormattingEnabled = True
        Me.cbbCity.Location = New System.Drawing.Point(83, 12)
        Me.cbbCity.MaxDropDownItems = 20
        Me.cbbCity.Name = "cbbCity"
        Me.cbbCity.Size = New System.Drawing.Size(208, 20)
        Me.cbbCity.TabIndex = 1
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(642, 529)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 28
        Me.btnSave.Text = "保存 &Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txbReason
        '
        Me.txbReason.Location = New System.Drawing.Point(223, 2)
        Me.txbReason.MaxLength = 50
        Me.txbReason.Name = "txbReason"
        Me.txbReason.ReadOnly = True
        Me.txbReason.Size = New System.Drawing.Size(246, 21)
        Me.txbReason.TabIndex = 2
        '
        'rdbFailure
        '
        Me.rdbFailure.AutoSize = True
        Me.rdbFailure.Location = New System.Drawing.Point(75, 4)
        Me.rdbFailure.Name = "rdbFailure"
        Me.rdbFailure.Size = New System.Drawing.Size(155, 16)
        Me.rdbFailure.TabIndex = 1
        Me.rdbFailure.TabStop = True
        Me.rdbFailure.Text = "失败 &Failure, reason: "
        Me.rdbFailure.UseVisualStyleBackColor = True
        '
        'rdbOK
        '
        Me.rdbOK.AutoSize = True
        Me.rdbOK.Location = New System.Drawing.Point(3, 4)
        Me.rdbOK.Name = "rdbOK"
        Me.rdbOK.Size = New System.Drawing.Size(65, 16)
        Me.rdbOK.TabIndex = 0
        Me.rdbOK.TabStop = True
        Me.rdbOK.Text = "通过 &OK"
        Me.rdbOK.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnCopy)
        Me.GroupBox2.Location = New System.Drawing.Point(589, 217)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(190, 54)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Copy to create new rule:"
        '
        'btnCopy
        '
        Me.btnCopy.Enabled = False
        Me.btnCopy.Location = New System.Drawing.Point(53, 21)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(75, 23)
        Me.btnCopy.TabIndex = 0
        Me.btnCopy.Text = "拷贝 &Copy"
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(12, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(281, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "已审核的返点规则 Validated Discount Rate Rule:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(587, 311)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(143, 12)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "修改者 Modified Person:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(587, 347)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(143, 12)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "修改时间 Modified Time:"
        '
        'lblModifier2
        '
        Me.lblModifier2.BackColor = System.Drawing.SystemColors.Info
        Me.lblModifier2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblModifier2.Location = New System.Drawing.Point(587, 326)
        Me.lblModifier2.Name = "lblModifier2"
        Me.lblModifier2.Size = New System.Drawing.Size(190, 18)
        Me.lblModifier2.TabIndex = 18
        Me.lblModifier2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblModifiedTime2
        '
        Me.lblModifiedTime2.BackColor = System.Drawing.SystemColors.Info
        Me.lblModifiedTime2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblModifiedTime2.Location = New System.Drawing.Point(587, 362)
        Me.lblModifiedTime2.Name = "lblModifiedTime2"
        Me.lblModifiedTime2.Size = New System.Drawing.Size(190, 18)
        Me.lblModifiedTime2.TabIndex = 20
        Me.lblModifiedTime2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnDeleteRow)
        Me.GroupBox4.Controls.Add(Me.btnPaste)
        Me.GroupBox4.Location = New System.Drawing.Point(589, 463)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(190, 54)
        Me.GroupBox4.TabIndex = 25
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Edit Buttons:"
        '
        'btnDeleteRow
        '
        Me.btnDeleteRow.Enabled = False
        Me.btnDeleteRow.Location = New System.Drawing.Point(9, 15)
        Me.btnDeleteRow.Name = "btnDeleteRow"
        Me.btnDeleteRow.Size = New System.Drawing.Size(87, 32)
        Me.btnDeleteRow.TabIndex = 0
        Me.btnDeleteRow.Text = "删除行 Delete Line"
        Me.btnDeleteRow.UseVisualStyleBackColor = True
        '
        'btnPaste
        '
        Me.btnPaste.Enabled = False
        Me.btnPaste.Location = New System.Drawing.Point(105, 20)
        Me.btnPaste.Name = "btnPaste"
        Me.btnPaste.Size = New System.Drawing.Size(75, 23)
        Me.btnPaste.TabIndex = 1
        Me.btnPaste.Text = "粘贴 &Paste"
        Me.btnPaste.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label12.Location = New System.Drawing.Point(11, 534)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(89, 12)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "审核 Validate:"
        '
        'pnlValidate
        '
        Me.pnlValidate.Controls.Add(Me.rdbOK)
        Me.pnlValidate.Controls.Add(Me.txbReason)
        Me.pnlValidate.Controls.Add(Me.rdbFailure)
        Me.pnlValidate.Enabled = False
        Me.pnlValidate.Location = New System.Drawing.Point(107, 529)
        Me.pnlValidate.Name = "pnlValidate"
        Me.pnlValidate.Size = New System.Drawing.Size(471, 25)
        Me.pnlValidate.TabIndex = 27
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(587, 383)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(149, 12)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "审核者 Validated Person:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(587, 419)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(149, 12)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "审核时间 Validated Time:"
        '
        'lblAuditor2
        '
        Me.lblAuditor2.BackColor = System.Drawing.SystemColors.Info
        Me.lblAuditor2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAuditor2.Location = New System.Drawing.Point(587, 398)
        Me.lblAuditor2.Name = "lblAuditor2"
        Me.lblAuditor2.Size = New System.Drawing.Size(190, 18)
        Me.lblAuditor2.TabIndex = 22
        Me.lblAuditor2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblValidatedTime2
        '
        Me.lblValidatedTime2.BackColor = System.Drawing.SystemColors.Info
        Me.lblValidatedTime2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblValidatedTime2.Location = New System.Drawing.Point(587, 434)
        Me.lblValidatedTime2.Name = "lblValidatedTime2"
        Me.lblValidatedTime2.Size = New System.Drawing.Size(190, 18)
        Me.lblValidatedTime2.TabIndex = 24
        Me.lblValidatedTime2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmCrossSellingCityConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 566)
        Me.Controls.Add(Me.pnlValidate)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.cbbCity)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblValidatedTime2)
        Me.Controls.Add(Me.lblValidatedTime1)
        Me.Controls.Add(Me.lblModifiedTime2)
        Me.Controls.Add(Me.lblModifiedTime1)
        Me.Controls.Add(Me.lblAuditor2)
        Me.Controls.Add(Me.lblAuditor1)
        Me.Controls.Add(Me.lblModifier2)
        Me.Controls.Add(Me.lblModifier1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dgvPending)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.dgvValidated)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCrossSellingCityConfig"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "通卖返点规则设置 City Discount Config"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        CType(Me.dgvValidated, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPending, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.pnlValidate.ResumeLayout(False)
        Me.pnlValidate.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvValidated As System.Windows.Forms.DataGridView
    Friend WithEvents dgvPending As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblModifier1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblModifiedTime1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblAuditor1 As System.Windows.Forms.Label
    Friend WithEvents lblValidatedTime1 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbbCity As System.Windows.Forms.ComboBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents rdbOK As System.Windows.Forms.RadioButton
    Friend WithEvents txbReason As System.Windows.Forms.TextBox
    Friend WithEvents rdbFailure As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCopy As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblModifier2 As System.Windows.Forms.Label
    Friend WithEvents lblModifiedTime2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnPaste As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnDeleteRow As System.Windows.Forms.Button
    Friend WithEvents pnlValidate As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblAuditor2 As System.Windows.Forms.Label
    Friend WithEvents lblValidatedTime2 As System.Windows.Forms.Label
End Class
