<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPosition
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPosition))
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvRole = New System.Windows.Forms.DataGridView
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.trvRight = New System.Windows.Forms.TreeView
        Me.imlXP = New System.Windows.Forms.ImageList(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnUp = New System.Windows.Forms.Button
        Me.btnDown = New System.Windows.Forms.Button
        Me.imlCS = New System.Windows.Forms.ImageList(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblRole = New System.Windows.Forms.Label
        Me.cbbArea = New System.Windows.Forms.ComboBox
        Me.cklArea = New System.Windows.Forms.CheckedListBox
        Me.cbbRole = New System.Windows.Forms.ComboBox
        Me.cklRole = New System.Windows.Forms.CheckedListBox
        CType(Me.dgvRole, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "职位列表 Position List:"
        '
        'dgvRole
        '
        Me.dgvRole.AllowUserToAddRows = False
        Me.dgvRole.AllowUserToDeleteRows = False
        Me.dgvRole.AllowUserToResizeRows = False
        Me.dgvRole.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvRole.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvRole.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRole.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvRole.ColumnHeadersHeight = 22
        Me.dgvRole.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvRole.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvRole.Location = New System.Drawing.Point(12, 27)
        Me.dgvRole.MultiSelect = False
        Me.dgvRole.Name = "dgvRole"
        Me.dgvRole.RowHeadersVisible = False
        Me.dgvRole.RowTemplate.Height = 24
        Me.dgvRole.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRole.Size = New System.Drawing.Size(289, 432)
        Me.dgvRole.TabIndex = 1
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(10, 469)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(90, 23)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "增加 &Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(106, 469)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(90, 23)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "删除 &Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'trvRight
        '
        Me.trvRight.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trvRight.ImageIndex = 0
        Me.trvRight.ImageList = Me.imlXP
        Me.trvRight.ItemHeight = 18
        Me.trvRight.Location = New System.Drawing.Point(315, 65)
        Me.trvRight.Name = "trvRight"
        Me.trvRight.SelectedImageIndex = 0
        Me.trvRight.Size = New System.Drawing.Size(463, 394)
        Me.trvRight.TabIndex = 13
        '
        'imlXP
        '
        Me.imlXP.ImageStream = CType(resources.GetObject("imlXP.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlXP.TransparentColor = System.Drawing.Color.Transparent
        Me.imlXP.Images.SetKeyName(0, "Object")
        Me.imlXP.Images.SetKeyName(1, "Yes")
        Me.imlXP.Images.SetKeyName(2, "No")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(313, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(149, 12)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "权限列表 Authority List:"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(703, 469)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 14
        Me.btnSave.Text = "保存 &Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnUp
        '
        Me.btnUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnUp.Enabled = False
        Me.btnUp.Location = New System.Drawing.Point(249, 469)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(23, 23)
        Me.btnUp.TabIndex = 4
        Me.btnUp.Text = "↑"
        Me.btnUp.UseVisualStyleBackColor = True
        '
        'btnDown
        '
        Me.btnDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDown.Enabled = False
        Me.btnDown.Location = New System.Drawing.Point(278, 469)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(23, 23)
        Me.btnDown.TabIndex = 5
        Me.btnDown.Text = "↓"
        Me.btnDown.UseVisualStyleBackColor = True
        '
        'imlCS
        '
        Me.imlCS.ImageStream = CType(resources.GetObject("imlCS.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlCS.TransparentColor = System.Drawing.Color.Transparent
        Me.imlCS.Images.SetKeyName(0, "Object")
        Me.imlCS.Images.SetKeyName(1, "Yes")
        Me.imlCS.Images.SetKeyName(2, "No")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(313, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(173, 12)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "适用区域 Apply to Locations:"
        '
        'lblRole
        '
        Me.lblRole.AutoSize = True
        Me.lblRole.Location = New System.Drawing.Point(550, 9)
        Me.lblRole.Name = "lblRole"
        Me.lblRole.Size = New System.Drawing.Size(209, 12)
        Me.lblRole.TabIndex = 9
        Me.lblRole.Text = "可分配职位 Controllable Positions:"
        '
        'cbbArea
        '
        Me.cbbArea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbbArea.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.cbbArea.DropDownHeight = 1
        Me.cbbArea.DropDownWidth = 1
        Me.cbbArea.IntegralHeight = False
        Me.cbbArea.Location = New System.Drawing.Point(315, 27)
        Me.cbbArea.Name = "cbbArea"
        Me.cbbArea.Size = New System.Drawing.Size(226, 20)
        Me.cbbArea.TabIndex = 7
        '
        'cklArea
        '
        Me.cklArea.FormattingEnabled = True
        Me.cklArea.Items.AddRange(New Object() {"总部 Head Office", "大区 Territory", "小区 Region", "城市 City", "门店 Store"})
        Me.cklArea.Location = New System.Drawing.Point(315, 47)
        Me.cklArea.Name = "cklArea"
        Me.cklArea.Size = New System.Drawing.Size(226, 84)
        Me.cklArea.TabIndex = 8
        Me.cklArea.UseTabStops = False
        Me.cklArea.Visible = False
        '
        'cbbRole
        '
        Me.cbbRole.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbbRole.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.cbbRole.DropDownHeight = 1
        Me.cbbRole.DropDownWidth = 1
        Me.cbbRole.IntegralHeight = False
        Me.cbbRole.Location = New System.Drawing.Point(552, 27)
        Me.cbbRole.Name = "cbbRole"
        Me.cbbRole.Size = New System.Drawing.Size(226, 20)
        Me.cbbRole.TabIndex = 10
        '
        'cklRole
        '
        Me.cklRole.FormattingEnabled = True
        Me.cklRole.Location = New System.Drawing.Point(552, 47)
        Me.cklRole.Name = "cklRole"
        Me.cklRole.Size = New System.Drawing.Size(226, 20)
        Me.cklRole.TabIndex = 11
        Me.cklRole.UseTabStops = False
        Me.cklRole.Visible = False
        '
        'frmPosition
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 506)
        Me.Controls.Add(Me.lblRole)
        Me.Controls.Add(Me.cbbArea)
        Me.Controls.Add(Me.cklArea)
        Me.Controls.Add(Me.cbbRole)
        Me.Controls.Add(Me.cklRole)
        Me.Controls.Add(Me.btnDown)
        Me.Controls.Add(Me.btnUp)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.trvRight)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.dgvRole)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmPosition"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "职位管理 Position Management"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        CType(Me.dgvRole, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvRole As System.Windows.Forms.DataGridView
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents trvRight As System.Windows.Forms.TreeView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnUp As System.Windows.Forms.Button
    Friend WithEvents btnDown As System.Windows.Forms.Button
    Friend WithEvents imlXP As System.Windows.Forms.ImageList
    Friend WithEvents imlCS As System.Windows.Forms.ImageList
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblRole As System.Windows.Forms.Label
    Friend WithEvents cbbArea As System.Windows.Forms.ComboBox
    Friend WithEvents cklArea As System.Windows.Forms.CheckedListBox
    Friend WithEvents cbbRole As System.Windows.Forms.ComboBox
    Friend WithEvents cklRole As System.Windows.Forms.CheckedListBox
End Class
