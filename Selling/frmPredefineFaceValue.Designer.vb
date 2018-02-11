<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPredefineFaceValue
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPredefineFaceValue))
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvCard = New System.Windows.Forms.DataGridView
        Me.btnClearAll = New System.Windows.Forms.Button
        Me.theTimer = New System.Windows.Forms.Timer(Me.components)
        Me.cmenuDeleteCardRow = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.menuDeleteCardRow = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.dgvCard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmenuDeleteCardRow.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(443, 366)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "关闭(&C)"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(362, 366)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "保存(&S)"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(-5, 349)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(543, 4)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "购物卡预定义面值列表："
        '
        'dgvCard
        '
        Me.dgvCard.AllowUserToAddRows = False
        Me.dgvCard.AllowUserToDeleteRows = False
        Me.dgvCard.AllowUserToResizeRows = False
        Me.dgvCard.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCard.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvCard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCard.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCard.ColumnHeadersHeight = 22
        Me.dgvCard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvCard.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvCard.Location = New System.Drawing.Point(14, 24)
        Me.dgvCard.MultiSelect = False
        Me.dgvCard.Name = "dgvCard"
        Me.dgvCard.RowHeadersVisible = False
        Me.dgvCard.RowTemplate.Height = 24
        Me.dgvCard.ShowRowErrors = False
        Me.dgvCard.Size = New System.Drawing.Size(504, 312)
        Me.dgvCard.TabIndex = 1
        '
        'btnClearAll
        '
        Me.btnClearAll.Location = New System.Drawing.Point(14, 366)
        Me.btnClearAll.Name = "btnClearAll"
        Me.btnClearAll.Size = New System.Drawing.Size(98, 23)
        Me.btnClearAll.TabIndex = 3
        Me.btnClearAll.Text = "清除所有卡(&D)"
        Me.btnClearAll.UseVisualStyleBackColor = True
        '
        'theTimer
        '
        Me.theTimer.Interval = 1000
        '
        'cmenuDeleteCardRow
        '
        Me.cmenuDeleteCardRow.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuDeleteCardRow})
        Me.cmenuDeleteCardRow.Name = "cmenuDeleteCardRow"
        Me.cmenuDeleteCardRow.Size = New System.Drawing.Size(166, 26)
        '
        'menuDeleteCardRow
        '
        Me.menuDeleteCardRow.Name = "menuDeleteCardRow"
        Me.menuDeleteCardRow.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.menuDeleteCardRow.Size = New System.Drawing.Size(165, 22)
        Me.menuDeleteCardRow.Text = "删除行   "
        '
        'frmPredefineFaceValue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(534, 401)
        Me.Controls.Add(Me.btnClearAll)
        Me.Controls.Add(Me.dgvCard)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPredefineFaceValue"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "预定义卡面值 Predefine Face Value"
        CType(Me.dgvCard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmenuDeleteCardRow.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvCard As System.Windows.Forms.DataGridView
    Friend WithEvents btnClearAll As System.Windows.Forms.Button
    Friend WithEvents theTimer As System.Windows.Forms.Timer
    Friend WithEvents cmenuDeleteCardRow As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents menuDeleteCardRow As System.Windows.Forms.ToolStripMenuItem
End Class
