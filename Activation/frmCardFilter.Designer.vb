<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCardFilter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCardFilter))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dgvCard = New System.Windows.Forms.DataGridView
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblQTY = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.lblAMT = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.TableLayoutPanel12 = New System.Windows.Forms.TableLayoutPanel
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblSameCode = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.lblEndCardNo = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblStartCardNo = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.lblExclude = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblLength = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label9 = New System.Windows.Forms.Label
        Me.txbStartCardNo = New System.Windows.Forms.TextBox
        Me.lblStartError = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.lblEndError = New System.Windows.Forms.Label
        Me.txbEndCardNo = New System.Windows.Forms.TextBox
        Me.btnAdd = New System.Windows.Forms.Button
        Me.lblCurrentInfo = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnDeleteSelected = New System.Windows.Forms.Button
        Me.btnClearList = New System.Windows.Forms.Button
        Me.pnlPrompt = New System.Windows.Forms.Panel
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.cmenuDeleteCard = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.menuDeleteNormalCard = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.dgvCard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel12.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlPrompt.SuspendLayout()
        Me.cmenuDeleteCard.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(12, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "说明："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(60, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(353, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "此功能在一行卡需要分批次激活、且单批次激活数量较大时使用。"
        '
        'dgvCard
        '
        Me.dgvCard.AllowUserToAddRows = False
        Me.dgvCard.AllowUserToDeleteRows = False
        Me.dgvCard.AllowUserToResizeRows = False
        Me.dgvCard.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
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
        Me.dgvCard.Location = New System.Drawing.Point(428, 14)
        Me.dgvCard.Name = "dgvCard"
        Me.dgvCard.ReadOnly = True
        Me.dgvCard.RowHeadersVisible = False
        Me.dgvCard.RowTemplate.Height = 24
        Me.dgvCard.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCard.ShowRowErrors = False
        Me.dgvCard.Size = New System.Drawing.Size(196, 504)
        Me.dgvCard.TabIndex = 15
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(0, 6)
        Me.Label11.Margin = New System.Windows.Forms.Padding(0, 6, 0, 6)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 12)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "待激活数量："
        '
        'lblQTY
        '
        Me.lblQTY.AutoSize = True
        Me.lblQTY.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblQTY.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQTY.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblQTY.Location = New System.Drawing.Point(77, 6)
        Me.lblQTY.Margin = New System.Windows.Forms.Padding(0, 6, 0, 6)
        Me.lblQTY.Name = "lblQTY"
        Me.lblQTY.Size = New System.Drawing.Size(32, 12)
        Me.lblQTY.TabIndex = 1
        Me.lblQTY.Text = "0 张"
        Me.lblQTY.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(0, 30)
        Me.Label12.Margin = New System.Windows.Forms.Padding(0, 6, 0, 6)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 12)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "待激活金额："
        '
        'lblAMT
        '
        Me.lblAMT.AutoSize = True
        Me.lblAMT.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAMT.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblAMT.Location = New System.Drawing.Point(77, 30)
        Me.lblAMT.Margin = New System.Windows.Forms.Padding(0, 6, 0, 6)
        Me.lblAMT.Name = "lblAMT"
        Me.lblAMT.Size = New System.Drawing.Size(32, 12)
        Me.lblAMT.TabIndex = 3
        Me.lblAMT.Text = "0 元"
        Me.lblAMT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(336, 498)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 19
        Me.btnOK.Text = "确定(&O)"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(255, 498)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 18
        Me.btnCancel.Text = "取消(&C)"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel12
        '
        Me.TableLayoutPanel12.AutoSize = True
        Me.TableLayoutPanel12.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel12.ColumnCount = 2
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel12.Controls.Add(Me.Label11, 0, 0)
        Me.TableLayoutPanel12.Controls.Add(Me.lblQTY, 1, 0)
        Me.TableLayoutPanel12.Controls.Add(Me.Label12, 0, 1)
        Me.TableLayoutPanel12.Controls.Add(Me.lblAMT, 1, 1)
        Me.TableLayoutPanel12.Location = New System.Drawing.Point(17, 29)
        Me.TableLayoutPanel12.Name = "TableLayoutPanel12"
        Me.TableLayoutPanel12.RowCount = 2
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel12.Size = New System.Drawing.Size(109, 48)
        Me.TableLayoutPanel12.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(401, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "请输入要激活的卡号范围，然后按""加入""按钮将该批卡号加入到右边列表："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Location = New System.Drawing.Point(6, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 12)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "提示："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 31)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(137, 12)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "该批卡的公共号码段是："
        '
        'lblSameCode
        '
        Me.lblSameCode.AutoSize = True
        Me.lblSameCode.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblSameCode.ForeColor = System.Drawing.Color.DarkOrange
        Me.lblSameCode.Location = New System.Drawing.Point(140, 28)
        Me.lblSameCode.Name = "lblSameCode"
        Me.lblSameCode.Size = New System.Drawing.Size(125, 16)
        Me.lblSameCode.TabIndex = 2
        Me.lblSameCode.Text = "2336840200128"
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.SystemColors.Info
        Me.Panel3.Controls.Add(Me.TableLayoutPanel3)
        Me.Panel3.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.lblSameCode)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(395, 106)
        Me.Panel3.TabIndex = 9
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.AutoSize = True
        Me.TableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel3.ColumnCount = 4
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.Controls.Add(Me.lblEndCardNo, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label8, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label7, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblStartCardNo, 1, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(5, 78)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(290, 16)
        Me.TableLayoutPanel3.TabIndex = 4
        '
        'lblEndCardNo
        '
        Me.lblEndCardNo.AutoSize = True
        Me.lblEndCardNo.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblEndCardNo.ForeColor = System.Drawing.Color.DarkOrange
        Me.lblEndCardNo.Location = New System.Drawing.Point(237, 0)
        Me.lblEndCardNo.Margin = New System.Windows.Forms.Padding(0)
        Me.lblEndCardNo.Name = "lblEndCardNo"
        Me.lblEndCardNo.Size = New System.Drawing.Size(53, 16)
        Me.lblEndCardNo.TabIndex = 3
        Me.lblEndCardNo.Text = "80000"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(166, 0)
        Me.Label8.Margin = New System.Windows.Forms.Padding(0)
        Me.Label8.Name = "Label8"
        Me.Label8.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label8.Size = New System.Drawing.Size(71, 15)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = " 最大卡号："
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0)
        Me.Label7.Name = "Label7"
        Me.Label7.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label7.Size = New System.Drawing.Size(113, 15)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "该批卡的最小卡号："
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStartCardNo
        '
        Me.lblStartCardNo.AutoSize = True
        Me.lblStartCardNo.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblStartCardNo.ForeColor = System.Drawing.Color.DarkOrange
        Me.lblStartCardNo.Location = New System.Drawing.Point(113, 0)
        Me.lblStartCardNo.Margin = New System.Windows.Forms.Padding(0)
        Me.lblStartCardNo.Name = "lblStartCardNo"
        Me.lblStartCardNo.Size = New System.Drawing.Size(53, 16)
        Me.lblStartCardNo.TabIndex = 1
        Me.lblStartCardNo.Text = "75001"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.Controls.Add(Me.lblExclude, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLength, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(5, 52)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(387, 16)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'lblExclude
        '
        Me.lblExclude.AutoSize = True
        Me.lblExclude.Location = New System.Drawing.Point(178, 0)
        Me.lblExclude.Margin = New System.Windows.Forms.Padding(0)
        Me.lblExclude.Name = "lblExclude"
        Me.lblExclude.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.lblExclude.Size = New System.Drawing.Size(209, 15)
        Me.lblExclude.TabIndex = 2
        Me.lblExclude.Text = "位数字（不含最后一位校验码）即可。"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0)
        Me.Label6.Name = "Label6"
        Me.Label6.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label6.Size = New System.Drawing.Size(161, 15)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "所以，您只要输入卡号中最后"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLength
        '
        Me.lblLength.AutoSize = True
        Me.lblLength.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblLength.ForeColor = System.Drawing.Color.DarkOrange
        Me.lblLength.Location = New System.Drawing.Point(161, 0)
        Me.lblLength.Margin = New System.Windows.Forms.Padding(0)
        Me.lblLength.Name = "lblLength"
        Me.lblLength.Size = New System.Drawing.Size(17, 16)
        Me.lblLength.TabIndex = 1
        Me.lblLength.Text = "5"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(14, 71)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(397, 108)
        Me.Panel1.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Location = New System.Drawing.Point(1, 1)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(396, 107)
        Me.Panel2.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(21, 200)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 12)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "开始卡号："
        '
        'txbStartCardNo
        '
        Me.txbStartCardNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbStartCardNo.Location = New System.Drawing.Point(92, 195)
        Me.txbStartCardNo.Name = "txbStartCardNo"
        Me.txbStartCardNo.Size = New System.Drawing.Size(100, 21)
        Me.txbStartCardNo.TabIndex = 5
        Me.txbStartCardNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblStartError
        '
        Me.lblStartError.AutoSize = True
        Me.lblStartError.ForeColor = System.Drawing.Color.Red
        Me.lblStartError.Location = New System.Drawing.Point(198, 200)
        Me.lblStartError.Name = "lblStartError"
        Me.lblStartError.Size = New System.Drawing.Size(0, 12)
        Me.lblStartError.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(21, 227)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 12)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "结束卡号："
        '
        'lblEndError
        '
        Me.lblEndError.AutoSize = True
        Me.lblEndError.ForeColor = System.Drawing.Color.Red
        Me.lblEndError.Location = New System.Drawing.Point(198, 227)
        Me.lblEndError.Name = "lblEndError"
        Me.lblEndError.Size = New System.Drawing.Size(0, 12)
        Me.lblEndError.TabIndex = 9
        '
        'txbEndCardNo
        '
        Me.txbEndCardNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbEndCardNo.Location = New System.Drawing.Point(92, 222)
        Me.txbEndCardNo.Name = "txbEndCardNo"
        Me.txbEndCardNo.Size = New System.Drawing.Size(100, 21)
        Me.txbEndCardNo.TabIndex = 8
        Me.txbEndCardNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnAdd
        '
        Me.btnAdd.Enabled = False
        Me.btnAdd.Location = New System.Drawing.Point(88, 287)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(104, 23)
        Me.btnAdd.TabIndex = 11
        Me.btnAdd.Text = "加到左边列表(&A)"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'lblCurrentInfo
        '
        Me.lblCurrentInfo.AutoSize = True
        Me.lblCurrentInfo.Location = New System.Drawing.Point(90, 259)
        Me.lblCurrentInfo.Name = "lblCurrentInfo"
        Me.lblCurrentInfo.Size = New System.Drawing.Size(0, 12)
        Me.lblCurrentInfo.TabIndex = 10
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel12)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 328)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(395, 98)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "待激活卡片汇总："
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label22.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label22.Location = New System.Drawing.Point(77, 6)
        Me.Label22.Margin = New System.Windows.Forms.Padding(0, 6, 0, 6)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(32, 12)
        Me.Label22.TabIndex = 1
        Me.Label22.Text = "0 张"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel4.Controls.Add(Me.GroupBox2)
        Me.Panel4.Enabled = False
        Me.Panel4.Location = New System.Drawing.Point(15, 479)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(395, 12)
        Me.Panel4.TabIndex = 14
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(-5, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(420, 4)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'btnDeleteSelected
        '
        Me.btnDeleteSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteSelected.Enabled = False
        Me.btnDeleteSelected.Location = New System.Drawing.Point(15, 498)
        Me.btnDeleteSelected.Name = "btnDeleteSelected"
        Me.btnDeleteSelected.Size = New System.Drawing.Size(71, 23)
        Me.btnDeleteSelected.TabIndex = 16
        Me.btnDeleteSelected.Text = "删除已选"
        Me.btnDeleteSelected.UseVisualStyleBackColor = True
        '
        'btnClearList
        '
        Me.btnClearList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClearList.Enabled = False
        Me.btnClearList.Location = New System.Drawing.Point(92, 498)
        Me.btnClearList.Name = "btnClearList"
        Me.btnClearList.Size = New System.Drawing.Size(71, 23)
        Me.btnClearList.TabIndex = 17
        Me.btnClearList.Text = "清空列表"
        Me.btnClearList.UseVisualStyleBackColor = True
        '
        'pnlPrompt
        '
        Me.pnlPrompt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlPrompt.Controls.Add(Me.Label13)
        Me.pnlPrompt.Controls.Add(Me.Label14)
        Me.pnlPrompt.Location = New System.Drawing.Point(15, 451)
        Me.pnlPrompt.Name = "pnlPrompt"
        Me.pnlPrompt.Size = New System.Drawing.Size(395, 27)
        Me.pnlPrompt.TabIndex = 13
        Me.pnlPrompt.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label13.Location = New System.Drawing.Point(2, 8)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 12)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "提示："
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(49, 8)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(263, 12)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "按住键盘上的""Shift""键或""Ctrl""键可进行多选。"
        '
        'cmenuDeleteCard
        '
        Me.cmenuDeleteCard.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuDeleteNormalCard})
        Me.cmenuDeleteCard.Name = "cmenuDeleteCardRow"
        Me.cmenuDeleteCard.Size = New System.Drawing.Size(178, 26)
        '
        'menuDeleteNormalCard
        '
        Me.menuDeleteNormalCard.Name = "menuDeleteNormalCard"
        Me.menuDeleteNormalCard.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.menuDeleteNormalCard.Size = New System.Drawing.Size(177, 22)
        Me.menuDeleteNormalCard.Text = "删除已选   "
        '
        'frmCardFilter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(638, 533)
        Me.Controls.Add(Me.pnlPrompt)
        Me.Controls.Add(Me.btnClearList)
        Me.Controls.Add(Me.btnDeleteSelected)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txbEndCardNo)
        Me.Controls.Add(Me.lblEndError)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.txbStartCardNo)
        Me.Controls.Add(Me.lblCurrentInfo)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lblStartError)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.dgvCard)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCardFilter"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "卡号筛选器"
        CType(Me.dgvCard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel12.ResumeLayout(False)
        Me.TableLayoutPanel12.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.pnlPrompt.ResumeLayout(False)
        Me.pnlPrompt.PerformLayout()
        Me.cmenuDeleteCard.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvCard As System.Windows.Forms.DataGridView
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblQTY As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblAMT As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel12 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblSameCode As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblLength As System.Windows.Forms.Label
    Friend WithEvents lblExclude As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txbStartCardNo As System.Windows.Forms.TextBox
    Friend WithEvents lblStartError As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblEndError As System.Windows.Forms.Label
    Friend WithEvents txbEndCardNo As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lblCurrentInfo As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnDeleteSelected As System.Windows.Forms.Button
    Friend WithEvents btnClearList As System.Windows.Forms.Button
    Friend WithEvents pnlPrompt As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblStartCardNo As System.Windows.Forms.Label
    Friend WithEvents lblEndCardNo As System.Windows.Forms.Label
    Friend WithEvents cmenuDeleteCard As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents menuDeleteNormalCard As System.Windows.Forms.ToolStripMenuItem
End Class
