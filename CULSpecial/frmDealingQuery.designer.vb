<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDealingQuery
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDealingQuery))
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnQuery = New System.Windows.Forms.Button
        Me.txbCardNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblCardNo = New System.Windows.Forms.Label
        Me.grbState = New System.Windows.Forms.GroupBox
        Me.lblState = New System.Windows.Forms.Label
        Me.dgvState = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.grbDealing = New System.Windows.Forms.GroupBox
        Me.lblDealing = New System.Windows.Forms.Label
        Me.dgvDealing = New System.Windows.Forms.DataGridView
        Me.btnHistory = New System.Windows.Forms.Button
        Me.grbState.SuspendLayout()
        CType(Me.dgvState, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbDealing.SuspendLayout()
        CType(Me.dgvDealing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(705, 10)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "关闭(&C)"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnQuery
        '
        Me.btnQuery.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnQuery.Enabled = False
        Me.btnQuery.Location = New System.Drawing.Point(463, 10)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(75, 23)
        Me.btnQuery.TabIndex = 2
        Me.btnQuery.Text = "查询(&Q)"
        Me.btnQuery.UseVisualStyleBackColor = True
        '
        'txbCardNo
        '
        Me.txbCardNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbCardNo.Location = New System.Drawing.Point(155, 12)
        Me.txbCardNo.MaxLength = 19
        Me.txbCardNo.Name = "txbCardNo"
        Me.txbCardNo.Size = New System.Drawing.Size(121, 21)
        Me.txbCardNo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "请输入待查询的卡号(&N)："
        '
        'lblCardNo
        '
        Me.lblCardNo.AutoSize = True
        Me.lblCardNo.Location = New System.Drawing.Point(282, 17)
        Me.lblCardNo.Name = "lblCardNo"
        Me.lblCardNo.Size = New System.Drawing.Size(0, 12)
        Me.lblCardNo.TabIndex = 2
        '
        'grbState
        '
        Me.grbState.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbState.Controls.Add(Me.lblState)
        Me.grbState.Controls.Add(Me.dgvState)
        Me.grbState.Location = New System.Drawing.Point(12, 52)
        Me.grbState.Name = "grbState"
        Me.grbState.Size = New System.Drawing.Size(767, 80)
        Me.grbState.TabIndex = 6
        Me.grbState.TabStop = False
        Me.grbState.Text = "购物卡状态："
        '
        'lblState
        '
        Me.lblState.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblState.BackColor = System.Drawing.SystemColors.Window
        Me.lblState.ForeColor = System.Drawing.Color.Maroon
        Me.lblState.Location = New System.Drawing.Point(15, 44)
        Me.lblState.Name = "lblState"
        Me.lblState.Size = New System.Drawing.Size(737, 20)
        Me.lblState.TabIndex = 1
        Me.lblState.Text = "（未查询）"
        Me.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvState
        '
        Me.dgvState.AllowUserToAddRows = False
        Me.dgvState.AllowUserToDeleteRows = False
        Me.dgvState.AllowUserToResizeRows = False
        Me.dgvState.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvState.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvState.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvState.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvState.ColumnHeadersHeight = 22
        Me.dgvState.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvState.Location = New System.Drawing.Point(12, 19)
        Me.dgvState.MultiSelect = False
        Me.dgvState.Name = "dgvState"
        Me.dgvState.ReadOnly = True
        Me.dgvState.RowHeadersVisible = False
        Me.dgvState.RowTemplate.Height = 24
        Me.dgvState.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvState.Size = New System.Drawing.Size(743, 48)
        Me.dgvState.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(-12, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(817, 3)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'grbDealing
        '
        Me.grbDealing.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbDealing.Controls.Add(Me.lblDealing)
        Me.grbDealing.Controls.Add(Me.dgvDealing)
        Me.grbDealing.Location = New System.Drawing.Point(12, 138)
        Me.grbDealing.Name = "grbDealing"
        Me.grbDealing.Size = New System.Drawing.Size(767, 385)
        Me.grbDealing.TabIndex = 7
        Me.grbDealing.TabStop = False
        Me.grbDealing.Text = "交易明细："
        '
        'lblDealing
        '
        Me.lblDealing.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDealing.BackColor = System.Drawing.SystemColors.Window
        Me.lblDealing.ForeColor = System.Drawing.Color.Maroon
        Me.lblDealing.Location = New System.Drawing.Point(15, 44)
        Me.lblDealing.Name = "lblDealing"
        Me.lblDealing.Size = New System.Drawing.Size(737, 325)
        Me.lblDealing.TabIndex = 1
        Me.lblDealing.Text = "（未查询）"
        Me.lblDealing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvDealing
        '
        Me.dgvDealing.AllowUserToAddRows = False
        Me.dgvDealing.AllowUserToDeleteRows = False
        Me.dgvDealing.AllowUserToResizeRows = False
        Me.dgvDealing.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDealing.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvDealing.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDealing.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDealing.ColumnHeadersHeight = 22
        Me.dgvDealing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvDealing.Location = New System.Drawing.Point(12, 19)
        Me.dgvDealing.MultiSelect = False
        Me.dgvDealing.Name = "dgvDealing"
        Me.dgvDealing.ReadOnly = True
        Me.dgvDealing.RowHeadersVisible = False
        Me.dgvDealing.RowTemplate.Height = 24
        Me.dgvDealing.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDealing.Size = New System.Drawing.Size(743, 353)
        Me.dgvDealing.TabIndex = 0
        '
        'btnHistory
        '
        Me.btnHistory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHistory.Enabled = False
        Me.btnHistory.Location = New System.Drawing.Point(544, 10)
        Me.btnHistory.Name = "btnHistory"
        Me.btnHistory.Size = New System.Drawing.Size(155, 23)
        Me.btnHistory.TabIndex = 3
        Me.btnHistory.Text = "查询激活日期以前记录(&H)"
        Me.btnHistory.UseVisualStyleBackColor = True
        '
        'frmDealingQuery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(792, 535)
        Me.Controls.Add(Me.btnHistory)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grbDealing)
        Me.Controls.Add(Me.grbState)
        Me.Controls.Add(Me.lblCardNo)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnQuery)
        Me.Controls.Add(Me.txbCardNo)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDealingQuery"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "购物卡状态及交易明细查询 Card Status & Dealing Query"
        Me.grbState.ResumeLayout(False)
        CType(Me.dgvState, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbDealing.ResumeLayout(False)
        CType(Me.dgvDealing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnQuery As System.Windows.Forms.Button
    Friend WithEvents txbCardNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCardNo As System.Windows.Forms.Label
    Friend WithEvents grbState As System.Windows.Forms.GroupBox
    Friend WithEvents dgvState As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grbDealing As System.Windows.Forms.GroupBox
    Friend WithEvents dgvDealing As System.Windows.Forms.DataGridView
    Friend WithEvents lblState As System.Windows.Forms.Label
    Friend WithEvents lblDealing As System.Windows.Forms.Label
    Friend WithEvents btnHistory As System.Windows.Forms.Button
End Class
