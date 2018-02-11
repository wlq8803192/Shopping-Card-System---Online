<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCheckCardResult
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCheckCardResult))
        Me.lblTitle = New System.Windows.Forms.Label
        Me.dgvCard = New System.Windows.Forms.DataGridView
        Me.tlpContainer = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.lblPrompt = New System.Windows.Forms.Label
        Me.btnShowPrompt = New System.Windows.Forms.Button
        Me.btnHide = New System.Windows.Forms.Button
        Me.btnRecheck = New System.Windows.Forms.Button
        Me.pnlOperation = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.theTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblCardQTY = New System.Windows.Forms.Label
        CType(Me.dgvCard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpContainer.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.pnlOperation.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Location = New System.Drawing.Point(74, 9)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(377, 12)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "发现充值列表中存在不可售卖、面值受限和可用状态不明确的购物片！"
        '
        'dgvCard
        '
        Me.dgvCard.AllowUserToAddRows = False
        Me.dgvCard.AllowUserToDeleteRows = False
        Me.dgvCard.AllowUserToResizeRows = False
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
        Me.dgvCard.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvCard.Location = New System.Drawing.Point(0, 0)
        Me.dgvCard.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvCard.MultiSelect = False
        Me.dgvCard.Name = "dgvCard"
        Me.dgvCard.ReadOnly = True
        Me.dgvCard.RowHeadersVisible = False
        Me.dgvCard.RowTemplate.Height = 24
        Me.dgvCard.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCard.Size = New System.Drawing.Size(736, 216)
        Me.dgvCard.TabIndex = 0
        '
        'tlpContainer
        '
        Me.tlpContainer.AutoSize = True
        Me.tlpContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpContainer.ColumnCount = 1
        Me.tlpContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpContainer.Controls.Add(Me.TableLayoutPanel1, 0, 2)
        Me.tlpContainer.Controls.Add(Me.pnlOperation, 0, 1)
        Me.tlpContainer.Controls.Add(Me.dgvCard, 0, 0)
        Me.tlpContainer.Location = New System.Drawing.Point(12, 28)
        Me.tlpContainer.Name = "tlpContainer"
        Me.tlpContainer.RowCount = 3
        Me.tlpContainer.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpContainer.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpContainer.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpContainer.Size = New System.Drawing.Size(736, 324)
        Me.tlpContainer.TabIndex = 3
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPrompt, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnShowPrompt, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnHide, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnRecheck, 2, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 288)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(736, 36)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'lblPrompt
        '
        Me.lblPrompt.AutoSize = True
        Me.lblPrompt.ForeColor = System.Drawing.Color.Blue
        Me.lblPrompt.Location = New System.Drawing.Point(105, 18)
        Me.lblPrompt.Margin = New System.Windows.Forms.Padding(0, 18, 0, 0)
        Me.lblPrompt.Name = "lblPrompt"
        Me.lblPrompt.Size = New System.Drawing.Size(245, 12)
        Me.lblPrompt.TabIndex = 0
        Me.lblPrompt.Text = "正在重新检查购物卡的可用状态，请稍候……"
        Me.lblPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPrompt.Visible = False
        '
        'btnShowPrompt
        '
        Me.btnShowPrompt.Location = New System.Drawing.Point(0, 12)
        Me.btnShowPrompt.Margin = New System.Windows.Forms.Padding(0, 12, 0, 0)
        Me.btnShowPrompt.Name = "btnShowPrompt"
        Me.btnShowPrompt.Size = New System.Drawing.Size(105, 23)
        Me.btnShowPrompt.TabIndex = 0
        Me.btnShowPrompt.Text = "显示操作提示 ↑"
        Me.btnShowPrompt.UseVisualStyleBackColor = True
        '
        'btnHide
        '
        Me.btnHide.Location = New System.Drawing.Point(661, 12)
        Me.btnHide.Margin = New System.Windows.Forms.Padding(6, 12, 0, 0)
        Me.btnHide.Name = "btnHide"
        Me.btnHide.Size = New System.Drawing.Size(75, 23)
        Me.btnHide.TabIndex = 2
        Me.btnHide.Text = "隐藏(&H)"
        Me.theTip.SetToolTip(Me.btnHide, "隐藏该窗口后，可以按主界面的""显示检查结果""按钮重新显示该窗口。")
        Me.btnHide.UseVisualStyleBackColor = True
        '
        'btnRecheck
        '
        Me.btnRecheck.Location = New System.Drawing.Point(570, 12)
        Me.btnRecheck.Margin = New System.Windows.Forms.Padding(6, 12, 0, 0)
        Me.btnRecheck.Name = "btnRecheck"
        Me.btnRecheck.Size = New System.Drawing.Size(85, 23)
        Me.btnRecheck.TabIndex = 1
        Me.btnRecheck.Text = "重新检查(&R)"
        Me.btnRecheck.UseVisualStyleBackColor = True
        Me.btnRecheck.Visible = False
        '
        'pnlOperation
        '
        Me.pnlOperation.BackColor = System.Drawing.SystemColors.Info
        Me.pnlOperation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlOperation.Controls.Add(Me.Label4)
        Me.pnlOperation.Controls.Add(Me.Label3)
        Me.pnlOperation.Controls.Add(Me.Label5)
        Me.pnlOperation.Controls.Add(Me.Label2)
        Me.pnlOperation.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlOperation.Location = New System.Drawing.Point(12, 228)
        Me.pnlOperation.Margin = New System.Windows.Forms.Padding(12, 12, 12, 0)
        Me.pnlOperation.Name = "pnlOperation"
        Me.pnlOperation.Size = New System.Drawing.Size(712, 60)
        Me.pnlOperation.TabIndex = 4
        Me.pnlOperation.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(74, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(551, 12)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "如果存在面值受限的卡片，请回到充值列表，减少它的面值，使它加上它的余额后不会超过 1,000 元。"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(74, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(485, 12)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "如果存在不可售卖的卡片，请回到充值列表，删除这部分卡，然后添加其它卡号的购物卡；"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(74, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(593, 12)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "从这里拷贝（Ctrl + C）卡号粘贴（Ctrl + V）到充值列表的新行，可以从原来连续的号码段中分离出该卡号。"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(7, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "操作提示："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "检查结果："
        '
        'theTip
        '
        Me.theTip.AutoPopDelay = 15000
        Me.theTip.InitialDelay = 500
        Me.theTip.ReshowDelay = 100
        '
        'lblCardQTY
        '
        Me.lblCardQTY.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCardQTY.Location = New System.Drawing.Point(443, 9)
        Me.lblCardQTY.Name = "lblCardQTY"
        Me.lblCardQTY.Size = New System.Drawing.Size(313, 12)
        Me.lblCardQTY.TabIndex = 2
        Me.lblCardQTY.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmCheckCardResult
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(762, 364)
        Me.Controls.Add(Me.lblCardQTY)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tlpContainer)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCheckCardResult"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.TopMost = True
        CType(Me.dgvCard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpContainer.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.pnlOperation.ResumeLayout(False)
        Me.pnlOperation.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvCard As System.Windows.Forms.DataGridView
    Friend WithEvents tlpContainer As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlOperation As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnShowPrompt As System.Windows.Forms.Button
    Friend WithEvents btnHide As System.Windows.Forms.Button
    Friend WithEvents lblPrompt As System.Windows.Forms.Label
    Friend WithEvents theTip As System.Windows.Forms.ToolTip
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnRecheck As System.Windows.Forms.Button
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblCardQTY As System.Windows.Forms.Label
End Class
