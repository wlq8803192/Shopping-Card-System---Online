<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmActivationDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmActivationDetails))
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvCard = New System.Windows.Forms.DataGridView
        Me.btnExit = New System.Windows.Forms.Button
        Me.grbRemarks = New System.Windows.Forms.GroupBox
        Me.rtbRemarks = New System.Windows.Forms.RichTextBox
        Me.btnReactivate = New System.Windows.Forms.Button
        Me.tlpReactivate = New System.Windows.Forms.TableLayoutPanel
        Me.pnlFilter = New System.Windows.Forms.Panel
        Me.cbbFilter = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.chbSelectAll = New System.Windows.Forms.CheckBox
        CType(Me.dgvCard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbRemarks.SuspendLayout()
        Me.tlpReactivate.SuspendLayout()
        Me.pnlFilter.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(203, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "当前销售单的购物卡激活明细如下： " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
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
        Me.dgvCard.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCard.ColumnHeadersHeight = 22
        Me.dgvCard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvCard.Location = New System.Drawing.Point(12, 28)
        Me.dgvCard.MultiSelect = False
        Me.dgvCard.Name = "dgvCard"
        Me.dgvCard.ReadOnly = True
        Me.dgvCard.RowHeadersVisible = False
        Me.dgvCard.RowTemplate.Height = 24
        Me.dgvCard.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCard.Size = New System.Drawing.Size(769, 240)
        Me.dgvCard.TabIndex = 1
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(706, 348)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 5
        Me.btnExit.Text = "退出(&X)"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'grbRemarks
        '
        Me.grbRemarks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbRemarks.Controls.Add(Me.rtbRemarks)
        Me.grbRemarks.Location = New System.Drawing.Point(12, 274)
        Me.grbRemarks.Name = "grbRemarks"
        Me.grbRemarks.Size = New System.Drawing.Size(769, 60)
        Me.grbRemarks.TabIndex = 3
        Me.grbRemarks.TabStop = False
        Me.grbRemarks.Text = "注意："
        '
        'rtbRemarks
        '
        Me.rtbRemarks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbRemarks.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbRemarks.Location = New System.Drawing.Point(8, 18)
        Me.rtbRemarks.Name = "rtbRemarks"
        Me.rtbRemarks.ReadOnly = True
        Me.rtbRemarks.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.rtbRemarks.Size = New System.Drawing.Size(754, 36)
        Me.rtbRemarks.TabIndex = 0
        Me.rtbRemarks.Text = "存在激活失败的购物卡！这些购物卡虽然已提交到CUL，但激活未能成功。请仔细查看激活失败原因，并作出相应处理。然后勾选该卡，按下面的""重新激活""按钮，重新提交到CU" & _
            "L激活。"
        '
        'btnReactivate
        '
        Me.btnReactivate.Enabled = False
        Me.btnReactivate.Location = New System.Drawing.Point(175, 3)
        Me.btnReactivate.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.btnReactivate.Name = "btnReactivate"
        Me.btnReactivate.Size = New System.Drawing.Size(86, 23)
        Me.btnReactivate.TabIndex = 1
        Me.btnReactivate.Text = "重新激活(&V)"
        Me.btnReactivate.UseVisualStyleBackColor = True
        '
        'tlpReactivate
        '
        Me.tlpReactivate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tlpReactivate.AutoSize = True
        Me.tlpReactivate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpReactivate.ColumnCount = 2
        Me.tlpReactivate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpReactivate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpReactivate.Controls.Add(Me.pnlFilter, 0, 0)
        Me.tlpReactivate.Controls.Add(Me.btnReactivate, 1, 0)
        Me.tlpReactivate.Location = New System.Drawing.Point(12, 345)
        Me.tlpReactivate.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpReactivate.Name = "tlpReactivate"
        Me.tlpReactivate.RowCount = 1
        Me.tlpReactivate.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpReactivate.Size = New System.Drawing.Size(261, 30)
        Me.tlpReactivate.TabIndex = 4
        '
        'pnlFilter
        '
        Me.pnlFilter.Controls.Add(Me.cbbFilter)
        Me.pnlFilter.Controls.Add(Me.Label2)
        Me.pnlFilter.Location = New System.Drawing.Point(0, 0)
        Me.pnlFilter.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlFilter.Name = "pnlFilter"
        Me.pnlFilter.Size = New System.Drawing.Size(175, 30)
        Me.pnlFilter.TabIndex = 0
        '
        'cbbFilter
        '
        Me.cbbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbFilter.FormattingEnabled = True
        Me.cbbFilter.Location = New System.Drawing.Point(71, 5)
        Me.cbbFilter.Name = "cbbFilter"
        Me.cbbFilter.Size = New System.Drawing.Size(96, 20)
        Me.cbbFilter.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(0, 9)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "状态筛选："
        '
        'chbSelectAll
        '
        Me.chbSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chbSelectAll.AutoCheck = False
        Me.chbSelectAll.AutoSize = True
        Me.chbSelectAll.Location = New System.Drawing.Point(724, 7)
        Me.chbSelectAll.Name = "chbSelectAll"
        Me.chbSelectAll.Size = New System.Drawing.Size(66, 16)
        Me.chbSelectAll.TabIndex = 2
        Me.chbSelectAll.Text = "全选(&A)"
        Me.chbSelectAll.ThreeState = True
        Me.chbSelectAll.UseVisualStyleBackColor = True
        Me.chbSelectAll.Visible = False
        '
        'frmActivationDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(793, 383)
        Me.Controls.Add(Me.chbSelectAll)
        Me.Controls.Add(Me.tlpReactivate)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.dgvCard)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grbRemarks)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmActivationDetails"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "购物卡激活明细："
        CType(Me.dgvCard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbRemarks.ResumeLayout(False)
        Me.tlpReactivate.ResumeLayout(False)
        Me.pnlFilter.ResumeLayout(False)
        Me.pnlFilter.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvCard As System.Windows.Forms.DataGridView
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents grbRemarks As System.Windows.Forms.GroupBox
    Friend WithEvents rtbRemarks As System.Windows.Forms.RichTextBox
    Friend WithEvents btnReactivate As System.Windows.Forms.Button
    Friend WithEvents tlpReactivate As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlFilter As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbbFilter As System.Windows.Forms.ComboBox
    Friend WithEvents chbSelectAll As System.Windows.Forms.CheckBox
End Class
