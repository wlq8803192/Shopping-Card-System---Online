<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCrossContractCityRule
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
        'components = New System.ComponentModel.Container
        'Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        'Me.Text = "frmCrossContractCityRule"

        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmContractCityRule))
        Me.dgvCityRuleDetails = New System.Windows.Forms.DataGridView
        Me.lblCityRuleChineseTitle = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbbCity = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvContractDetails = New System.Windows.Forms.DataGridView
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lblCityRuleEnglishTitle = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblExpired = New System.Windows.Forms.Label
        Me.lblConclusion = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        CType(Me.dgvCityRuleDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvContractDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvCityRuleDetails
        '
        Me.dgvCityRuleDetails.AllowUserToAddRows = False
        Me.dgvCityRuleDetails.AllowUserToDeleteRows = False
        Me.dgvCityRuleDetails.AllowUserToResizeRows = False
        Me.dgvCityRuleDetails.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvCityRuleDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCityRuleDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCityRuleDetails.ColumnHeadersHeight = 36
        Me.dgvCityRuleDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCityRuleDetails.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCityRuleDetails.Location = New System.Drawing.Point(12, 270)
        Me.dgvCityRuleDetails.MultiSelect = False
        Me.dgvCityRuleDetails.Name = "dgvCityRuleDetails"
        Me.dgvCityRuleDetails.ReadOnly = True
        Me.dgvCityRuleDetails.RowHeadersVisible = False
        Me.dgvCityRuleDetails.RowTemplate.Height = 24
        Me.dgvCityRuleDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvCityRuleDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCityRuleDetails.Size = New System.Drawing.Size(563, 206)
        Me.dgvCityRuleDetails.TabIndex = 6
        '
        'lblCityRuleChineseTitle
        '
        Me.lblCityRuleChineseTitle.AutoSize = True
        Me.lblCityRuleChineseTitle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCityRuleChineseTitle.Location = New System.Drawing.Point(10, 238)
        Me.lblCityRuleChineseTitle.Name = "lblCityRuleChineseTitle"
        Me.lblCityRuleChineseTitle.Size = New System.Drawing.Size(137, 12)
        Me.lblCityRuleChineseTitle.TabIndex = 2
        Me.lblCityRuleChineseTitle.Text = "当前有效的通卖城市返点规则"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(296, 243)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "城市 City:"
        '
        'cbbCity
        '
        Me.cbbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbCity.FormattingEnabled = True
        Me.cbbCity.Location = New System.Drawing.Point(367, 240)
        Me.cbbCity.MaxDropDownItems = 20
        Me.cbbCity.Name = "cbbCity"
        Me.cbbCity.Size = New System.Drawing.Size(208, 20)
        Me.cbbCity.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(10, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(305, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "当前的合同返点列表 Current Contract Discount List:"
        '
        'dgvContractDetails
        '
        Me.dgvContractDetails.AllowUserToAddRows = False
        Me.dgvContractDetails.AllowUserToDeleteRows = False
        Me.dgvContractDetails.AllowUserToResizeRows = False
        Me.dgvContractDetails.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvContractDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvContractDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvContractDetails.ColumnHeadersHeight = 36
        Me.dgvContractDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvContractDetails.Location = New System.Drawing.Point(12, 24)
        Me.dgvContractDetails.MultiSelect = False
        Me.dgvContractDetails.Name = "dgvContractDetails"
        Me.dgvContractDetails.ReadOnly = True
        Me.dgvContractDetails.RowHeadersVisible = False
        Me.dgvContractDetails.RowTemplate.Height = 24
        Me.dgvContractDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvContractDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvContractDetails.Size = New System.Drawing.Size(563, 206)
        Me.dgvContractDetails.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.Location = New System.Drawing.Point(0, 502)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(615, 4)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "GroupBox3"
        '
        'lblCityRuleEnglishTitle
        '
        Me.lblCityRuleEnglishTitle.AutoSize = True
        Me.lblCityRuleEnglishTitle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCityRuleEnglishTitle.Location = New System.Drawing.Point(10, 251)
        Me.lblCityRuleEnglishTitle.Name = "lblCityRuleEnglishTitle"
        Me.lblCityRuleEnglishTitle.Size = New System.Drawing.Size(227, 12)
        Me.lblCityRuleEnglishTitle.TabIndex = 3
        Me.lblCityRuleEnglishTitle.Text = "Current effective City Discount Rule:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Maroon
        Me.Label6.Location = New System.Drawing.Point(59, 484)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(281, 12)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "黄色行是与选定的合同返点相适应的通卖城市返点规则。"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 484)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 12)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "说明："
        '
        'lblExpired
        '
        Me.lblExpired.AutoSize = True
        Me.lblExpired.ForeColor = System.Drawing.Color.Red
        Me.lblExpired.Location = New System.Drawing.Point(399, 484)
        Me.lblExpired.Name = "lblExpired"
        Me.lblExpired.Size = New System.Drawing.Size(185, 12)
        Me.lblExpired.TabIndex = 9
        Me.lblExpired.Text = "备注：上面通卖城市返点规则已过期。"
        Me.lblExpired.Visible = False
        '
        'lblConclusion
        '
        Me.lblConclusion.BackColor = System.Drawing.SystemColors.Info
        Me.lblConclusion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblConclusion.Location = New System.Drawing.Point(12, 533)
        Me.lblConclusion.Name = "lblConclusion"
        Me.lblConclusion.Size = New System.Drawing.Size(563, 18)
        Me.lblConclusion.TabIndex = 12
        Me.lblConclusion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 513)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 12)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "结论 Conclusion:"
        '
        'frmContractCityRule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(590, 566)
        Me.Controls.Add(Me.lblConclusion)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cbbCity)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblExpired)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dgvContractDetails)
        Me.Controls.Add(Me.lblCityRuleEnglishTitle)
        Me.Controls.Add(Me.lblCityRuleChineseTitle)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.dgvCityRuleDetails)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmContractCityRule"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "合同返点对比通卖城市返点 Contract Discount VS City Discount"
        CType(Me.dgvCityRuleDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvContractDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvCityRuleDetails As System.Windows.Forms.DataGridView
    Friend WithEvents lblCityRuleChineseTitle As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbbCity As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvContractDetails As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblCityRuleEnglishTitle As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblExpired As System.Windows.Forms.Label
    Friend WithEvents lblConclusion As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class

