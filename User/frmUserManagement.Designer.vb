<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserManagerment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUserManagerment))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.trvArea = New System.Windows.Forms.TreeView
        Me.imlIcon = New System.Windows.Forms.ImageList(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.dgvList = New System.Windows.Forms.DataGridView
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbbRole = New System.Windows.Forms.ComboBox
        Me.Split = New System.Windows.Forms.SplitContainer
        Me.lblIncludeDown2 = New System.Windows.Forms.Label
        Me.lblIncludeDown1 = New System.Windows.Forms.Label
        Me.chbIncludeDown = New System.Windows.Forms.CheckBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.cbbState = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnOpen = New System.Windows.Forms.Button
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Split.Panel1.SuspendLayout()
        Me.Split.Panel2.SuspendLayout()
        Me.Split.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "组织结构 Organization:"
        '
        'trvArea
        '
        Me.trvArea.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trvArea.ImageIndex = 0
        Me.trvArea.ImageList = Me.imlIcon
        Me.trvArea.ItemHeight = 18
        Me.trvArea.Location = New System.Drawing.Point(12, 34)
        Me.trvArea.Name = "trvArea"
        Me.trvArea.SelectedImageIndex = 0
        Me.trvArea.Size = New System.Drawing.Size(248, 424)
        Me.trvArea.TabIndex = 1
        '
        'imlIcon
        '
        Me.imlIcon.ImageStream = CType(resources.GetObject("imlIcon.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlIcon.TransparentColor = System.Drawing.Color.Transparent
        Me.imlIcon.Images.SetKeyName(0, "H")
        Me.imlIcon.Images.SetKeyName(1, "T")
        Me.imlIcon.Images.SetKeyName(2, "R")
        Me.imlIcon.Images.SetKeyName(3, "C")
        Me.imlIcon.Images.SetKeyName(4, "S")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "用户列表 User List:"
        '
        'dgvList
        '
        Me.dgvList.AllowUserToAddRows = False
        Me.dgvList.AllowUserToDeleteRows = False
        Me.dgvList.AllowUserToResizeRows = False
        Me.dgvList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvList.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvList.ColumnHeadersHeight = 22
        Me.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvList.Location = New System.Drawing.Point(8, 34)
        Me.dgvList.MultiSelect = False
        Me.dgvList.Name = "dgvList"
        Me.dgvList.ReadOnly = True
        Me.dgvList.RowHeadersVisible = False
        Me.dgvList.RowTemplate.Height = 24
        Me.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvList.ShowRowErrors = False
        Me.dgvList.Size = New System.Drawing.Size(506, 424)
        Me.dgvList.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "职位 &Position:"
        '
        'cbbRole
        '
        Me.cbbRole.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbRole.FormattingEnabled = True
        Me.cbbRole.Location = New System.Drawing.Point(94, 8)
        Me.cbbRole.MaxDropDownItems = 20
        Me.cbbRole.Name = "cbbRole"
        Me.cbbRole.Size = New System.Drawing.Size(192, 20)
        Me.cbbRole.TabIndex = 3
        '
        'Split
        '
        Me.Split.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Split.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.Split.Location = New System.Drawing.Point(0, 0)
        Me.Split.Name = "Split"
        '
        'Split.Panel1
        '
        Me.Split.Panel1.Controls.Add(Me.lblIncludeDown2)
        Me.Split.Panel1.Controls.Add(Me.lblIncludeDown1)
        Me.Split.Panel1.Controls.Add(Me.chbIncludeDown)
        Me.Split.Panel1.Controls.Add(Me.btnSearch)
        Me.Split.Panel1.Controls.Add(Me.Label1)
        Me.Split.Panel1.Controls.Add(Me.trvArea)
        '
        'Split.Panel2
        '
        Me.Split.Panel2.Controls.Add(Me.cbbState)
        Me.Split.Panel2.Controls.Add(Me.Label4)
        Me.Split.Panel2.Controls.Add(Me.btnDelete)
        Me.Split.Panel2.Controls.Add(Me.btnAdd)
        Me.Split.Panel2.Controls.Add(Me.btnOpen)
        Me.Split.Panel2.Controls.Add(Me.cbbRole)
        Me.Split.Panel2.Controls.Add(Me.Label3)
        Me.Split.Panel2.Controls.Add(Me.dgvList)
        Me.Split.Panel2.Controls.Add(Me.Label2)
        Me.Split.Size = New System.Drawing.Size(790, 504)
        Me.Split.SplitterDistance = 260
        Me.Split.TabIndex = 0
        '
        'lblIncludeDown2
        '
        Me.lblIncludeDown2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblIncludeDown2.AutoSize = True
        Me.lblIncludeDown2.Location = New System.Drawing.Point(180, 18)
        Me.lblIncludeDown2.Name = "lblIncludeDown2"
        Me.lblIncludeDown2.Size = New System.Drawing.Size(77, 12)
        Me.lblIncludeDown2.TabIndex = 4
        Me.lblIncludeDown2.Text = "Include down"
        '
        'lblIncludeDown1
        '
        Me.lblIncludeDown1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblIncludeDown1.AutoSize = True
        Me.lblIncludeDown1.Location = New System.Drawing.Point(180, 6)
        Me.lblIncludeDown1.Name = "lblIncludeDown1"
        Me.lblIncludeDown1.Size = New System.Drawing.Size(77, 12)
        Me.lblIncludeDown1.TabIndex = 3
        Me.lblIncludeDown1.Text = "包含下级部门"
        '
        'chbIncludeDown
        '
        Me.chbIncludeDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chbIncludeDown.AutoSize = True
        Me.chbIncludeDown.Checked = True
        Me.chbIncludeDown.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbIncludeDown.Location = New System.Drawing.Point(164, 12)
        Me.chbIncludeDown.Name = "chbIncludeDown"
        Me.chbIncludeDown.Size = New System.Drawing.Size(15, 14)
        Me.chbIncludeDown.TabIndex = 2
        Me.chbIncludeDown.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Location = New System.Drawing.Point(12, 469)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(90, 23)
        Me.btnSearch.TabIndex = 5
        Me.btnSearch.Text = "查找 Sea&rch"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'cbbState
        '
        Me.cbbState.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbState.FormattingEnabled = True
        Me.cbbState.Items.AddRange(New Object() {"(所有状态 All States)", "等待审核 Pending", "审核失败 Not Approved", "审核成功 Approved", "停止使用 Blocked"})
        Me.cbbState.Location = New System.Drawing.Point(363, 8)
        Me.cbbState.Name = "cbbState"
        Me.cbbState.Size = New System.Drawing.Size(151, 20)
        Me.cbbState.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(292, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 12)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "状态 Sta&te:"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(177, 469)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(79, 23)
        Me.btnDelete.TabIndex = 8
        Me.btnDelete.Text = "删除 &Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(92, 469)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(79, 23)
        Me.btnAdd.TabIndex = 7
        Me.btnAdd.Text = "创建 &Create"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnOpen
        '
        Me.btnOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOpen.Enabled = False
        Me.btnOpen.Location = New System.Drawing.Point(7, 469)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(79, 23)
        Me.btnOpen.TabIndex = 6
        Me.btnOpen.Text = "打开 &Open"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'frmUserManagerment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 504)
        Me.Controls.Add(Me.Split)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmUserManagerment"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "用户管理 User Management"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Split.Panel1.ResumeLayout(False)
        Me.Split.Panel1.PerformLayout()
        Me.Split.Panel2.ResumeLayout(False)
        Me.Split.Panel2.PerformLayout()
        Me.Split.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents trvArea As System.Windows.Forms.TreeView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvList As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbbRole As System.Windows.Forms.ComboBox
    Friend WithEvents Split As System.Windows.Forms.SplitContainer
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents cbbState As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents imlIcon As System.Windows.Forms.ImageList
    Friend WithEvents chbIncludeDown As System.Windows.Forms.CheckBox
    Friend WithEvents lblIncludeDown2 As System.Windows.Forms.Label
    Friend WithEvents lblIncludeDown1 As System.Windows.Forms.Label
End Class
