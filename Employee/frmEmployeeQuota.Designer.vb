<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmployeeQuota
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmployeeQuota))
        Me.btnSave = New System.Windows.Forms.Button
        Me.dgvOffice = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbbCity = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.dgvLevel = New System.Windows.Forms.DataGridView
        Me.Label3 = New System.Windows.Forms.Label
        CType(Me.dgvOffice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLevel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(703, 13)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "保存 &Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'dgvOffice
        '
        Me.dgvOffice.AllowUserToAddRows = False
        Me.dgvOffice.AllowUserToDeleteRows = False
        Me.dgvOffice.AllowUserToResizeRows = False
        Me.dgvOffice.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvOffice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOffice.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvOffice.ColumnHeadersHeight = 22
        Me.dgvOffice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvOffice.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvOffice.Location = New System.Drawing.Point(14, 57)
        Me.dgvOffice.MultiSelect = False
        Me.dgvOffice.Name = "dgvOffice"
        Me.dgvOffice.RowHeadersVisible = False
        Me.dgvOffice.RowTemplate.Height = 24
        Me.dgvOffice.Size = New System.Drawing.Size(374, 432)
        Me.dgvOffice.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "城市列表："
        '
        'cbbCity
        '
        Me.cbbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbCity.FormattingEnabled = True
        Me.cbbCity.Location = New System.Drawing.Point(83, 10)
        Me.cbbCity.MaxDropDownItems = 20
        Me.cbbCity.Name = "cbbCity"
        Me.cbbCity.Size = New System.Drawing.Size(114, 20)
        Me.cbbCity.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(185, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "当前城市下的门店、办公室列表："
        '
        'dgvLevel
        '
        Me.dgvLevel.AllowUserToAddRows = False
        Me.dgvLevel.AllowUserToDeleteRows = False
        Me.dgvLevel.AllowUserToResizeRows = False
        Me.dgvLevel.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvLevel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLevel.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvLevel.ColumnHeadersHeight = 22
        Me.dgvLevel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvLevel.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvLevel.Location = New System.Drawing.Point(403, 58)
        Me.dgvLevel.MultiSelect = False
        Me.dgvLevel.Name = "dgvLevel"
        Me.dgvLevel.RowHeadersVisible = False
        Me.dgvLevel.RowTemplate.Height = 24
        Me.dgvLevel.Size = New System.Drawing.Size(374, 432)
        Me.dgvLevel.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(401, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(209, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "当前城市下各级别员工购买额度设置："
        '
        'frmEmployeeQuota
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 506)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbbCity)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvLevel)
        Me.Controls.Add(Me.dgvOffice)
        Me.Controls.Add(Me.btnSave)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmEmployeeQuota"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "员工额度设置 Employee Quota Configuration"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        CType(Me.dgvOffice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLevel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents dgvOffice As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbbCity As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvLevel As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
