<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomerManagement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCustomerManagement))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Split = New System.Windows.Forms.SplitContainer
        Me.btnSearch = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.trvArea = New System.Windows.Forms.TreeView
        Me.imlIcon = New System.Windows.Forms.ImageList(Me.components)
        Me.btnSelling = New System.Windows.Forms.Button
        Me.btnCreateContract = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnOpen = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbbBusinessType = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dgvList = New System.Windows.Forms.DataGridView
        Me.Split.Panel1.SuspendLayout()
        Me.Split.Panel2.SuspendLayout()
        Me.Split.SuspendLayout()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.Split.Panel1.Controls.Add(Me.btnSearch)
        Me.Split.Panel1.Controls.Add(Me.Label1)
        Me.Split.Panel1.Controls.Add(Me.trvArea)
        '
        'Split.Panel2
        '
        Me.Split.Panel2.Controls.Add(Me.btnSelling)
        Me.Split.Panel2.Controls.Add(Me.btnCreateContract)
        Me.Split.Panel2.Controls.Add(Me.btnDelete)
        Me.Split.Panel2.Controls.Add(Me.btnAdd)
        Me.Split.Panel2.Controls.Add(Me.btnOpen)
        Me.Split.Panel2.Controls.Add(Me.Label2)
        Me.Split.Panel2.Controls.Add(Me.cbbBusinessType)
        Me.Split.Panel2.Controls.Add(Me.Label3)
        Me.Split.Panel2.Controls.Add(Me.dgvList)
        Me.Split.Size = New System.Drawing.Size(790, 504)
        Me.Split.SplitterDistance = 260
        Me.Split.TabIndex = 1
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Location = New System.Drawing.Point(12, 469)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(90, 23)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "查找 Sea&rch"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "门店列表 Store List:"
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
        'btnSelling
        '
        Me.btnSelling.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelling.Enabled = False
        Me.btnSelling.Location = New System.Drawing.Point(319, 469)
        Me.btnSelling.Name = "btnSelling"
        Me.btnSelling.Size = New System.Drawing.Size(86, 23)
        Me.btnSelling.TabIndex = 7
        Me.btnSelling.Text = "售卡 &Selling"
        Me.btnSelling.UseVisualStyleBackColor = True
        '
        'btnCreateContract
        '
        Me.btnCreateContract.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreateContract.Enabled = False
        Me.btnCreateContract.Location = New System.Drawing.Point(411, 469)
        Me.btnCreateContract.Name = "btnCreateContract"
        Me.btnCreateContract.Size = New System.Drawing.Size(103, 23)
        Me.btnCreateContract.TabIndex = 8
        Me.btnCreateContract.Text = "Create Con&tract"
        Me.btnCreateContract.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(177, 469)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(79, 23)
        Me.btnDelete.TabIndex = 6
        Me.btnDelete.Text = "删除 &Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(92, 469)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(79, 23)
        Me.btnAdd.TabIndex = 5
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
        Me.btnOpen.TabIndex = 4
        Me.btnOpen.Text = "打开 &Open"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(143, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "客户列表 Customer List:"
        '
        'cbbBusinessType
        '
        Me.cbbBusinessType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbbBusinessType.FormattingEnabled = True
        Me.cbbBusinessType.Location = New System.Drawing.Point(298, 8)
        Me.cbbBusinessType.MaxDropDownItems = 20
        Me.cbbBusinessType.Name = "cbbBusinessType"
        Me.cbbBusinessType.Size = New System.Drawing.Size(216, 20)
        Me.cbbBusinessType.TabIndex = 3
        Me.cbbBusinessType.Text = "（所有类型 All Types）"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(149, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(143, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "商业类型 &Business Type:"
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
        'frmCustomerManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 504)
        Me.Controls.Add(Me.Split)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCustomerManagement"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "客户管理 Customer Management"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.Split.Panel1.ResumeLayout(False)
        Me.Split.Panel1.PerformLayout()
        Me.Split.Panel2.ResumeLayout(False)
        Me.Split.Panel2.PerformLayout()
        Me.Split.ResumeLayout(False)
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Split As System.Windows.Forms.SplitContainer
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents trvArea As System.Windows.Forms.TreeView
    Friend WithEvents btnCreateContract As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbbBusinessType As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgvList As System.Windows.Forms.DataGridView
    Friend WithEvents btnSelling As System.Windows.Forms.Button
    Friend WithEvents imlIcon As System.Windows.Forms.ImageList
End Class
