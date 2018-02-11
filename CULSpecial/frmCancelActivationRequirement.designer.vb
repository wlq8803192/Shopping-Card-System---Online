<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCancelActivationRequirement
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCancelActivationRequirement))
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnHistory = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnStart = New System.Windows.Forms.Button
        Me.btnPrevious = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnFinish = New System.Windows.Forms.Button
        Me.pnlStep2 = New System.Windows.Forms.Panel
        Me.lblInfo2 = New System.Windows.Forms.Label
        Me.grbQueryCardState = New System.Windows.Forms.GroupBox
        Me.dgvList2 = New System.Windows.Forms.DataGridView
        Me.pnlStep3 = New System.Windows.Forms.Panel
        Me.lblInfo3 = New System.Windows.Forms.Label
        Me.grbRequest = New System.Windows.Forms.GroupBox
        Me.chkSelectAll = New System.Windows.Forms.CheckBox
        Me.dgvList3 = New System.Windows.Forms.DataGridView
        Me.pnlStep1 = New System.Windows.Forms.Panel
        Me.grbInputCardNo = New System.Windows.Forms.GroupBox
        Me.dgvList1 = New System.Windows.Forms.DataGridView
        Me.lblInfo1 = New System.Windows.Forms.Label
        Me.cmenuDelete = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.menuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.pnlStep4 = New System.Windows.Forms.Panel
        Me.lblInfo4 = New System.Windows.Forms.Label
        Me.grbReason = New System.Windows.Forms.GroupBox
        Me.pnlAfter = New System.Windows.Forms.Panel
        Me.dgvList4 = New System.Windows.Forms.DataGridView
        Me.lblResult = New System.Windows.Forms.Label
        Me.txbReason = New System.Windows.Forms.TextBox
        Me.lblReason = New System.Windows.Forms.Label
        Me.pnlStep2.SuspendLayout()
        Me.grbQueryCardState.SuspendLayout()
        CType(Me.dgvList2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlStep3.SuspendLayout()
        Me.grbRequest.SuspendLayout()
        CType(Me.dgvList3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlStep1.SuspendLayout()
        Me.grbInputCardNo.SuspendLayout()
        CType(Me.dgvList1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmenuDelete.SuspendLayout()
        Me.pnlStep4.SuspendLayout()
        Me.grbReason.SuspendLayout()
        Me.pnlAfter.SuspendLayout()
        CType(Me.dgvList4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(707, 481)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "取消(&C)"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnHistory
        '
        Me.btnHistory.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHistory.Location = New System.Drawing.Point(596, 481)
        Me.btnHistory.Name = "btnHistory"
        Me.btnHistory.Size = New System.Drawing.Size(105, 23)
        Me.btnHistory.TabIndex = 9
        Me.btnHistory.Text = "查看历史记录(&H)"
        Me.btnHistory.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(-10, 466)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(819, 3)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'btnStart
        '
        Me.btnStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnStart.Enabled = False
        Me.btnStart.Location = New System.Drawing.Point(11, 481)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(80, 23)
        Me.btnStart.TabIndex = 5
        Me.btnStart.Text = "|<< 开始(&T)"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnPrevious
        '
        Me.btnPrevious.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrevious.Enabled = False
        Me.btnPrevious.Location = New System.Drawing.Point(97, 481)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(80, 23)
        Me.btnPrevious.TabIndex = 6
        Me.btnPrevious.Text = "< 上一步(&P)"
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNext.Enabled = False
        Me.btnNext.Location = New System.Drawing.Point(183, 481)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(80, 23)
        Me.btnNext.TabIndex = 7
        Me.btnNext.Text = "下一步(&N) >"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnFinish
        '
        Me.btnFinish.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnFinish.Enabled = False
        Me.btnFinish.Location = New System.Drawing.Point(269, 481)
        Me.btnFinish.Name = "btnFinish"
        Me.btnFinish.Size = New System.Drawing.Size(80, 23)
        Me.btnFinish.TabIndex = 8
        Me.btnFinish.Text = "完成 >>|(&F)"
        Me.btnFinish.UseVisualStyleBackColor = True
        '
        'pnlStep2
        '
        Me.pnlStep2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlStep2.Controls.Add(Me.lblInfo2)
        Me.pnlStep2.Controls.Add(Me.grbQueryCardState)
        Me.pnlStep2.Location = New System.Drawing.Point(12, 8)
        Me.pnlStep2.Name = "pnlStep2"
        Me.pnlStep2.Size = New System.Drawing.Size(769, 450)
        Me.pnlStep2.TabIndex = 1
        Me.pnlStep2.Visible = False
        '
        'lblInfo2
        '
        Me.lblInfo2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblInfo2.AutoSize = True
        Me.lblInfo2.Location = New System.Drawing.Point(3, 434)
        Me.lblInfo2.Name = "lblInfo2"
        Me.lblInfo2.Size = New System.Drawing.Size(0, 12)
        Me.lblInfo2.TabIndex = 1
        '
        'grbQueryCardState
        '
        Me.grbQueryCardState.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbQueryCardState.Controls.Add(Me.dgvList2)
        Me.grbQueryCardState.Location = New System.Drawing.Point(0, 0)
        Me.grbQueryCardState.Name = "grbQueryCardState"
        Me.grbQueryCardState.Size = New System.Drawing.Size(769, 419)
        Me.grbQueryCardState.TabIndex = 0
        Me.grbQueryCardState.TabStop = False
        Me.grbQueryCardState.Text = "第二步：查询需要进行激活撤销操作的购物卡状态及其对应的销售单"
        '
        'dgvList2
        '
        Me.dgvList2.AllowUserToAddRows = False
        Me.dgvList2.AllowUserToDeleteRows = False
        Me.dgvList2.AllowUserToResizeRows = False
        Me.dgvList2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvList2.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvList2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvList2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvList2.ColumnHeadersHeight = 22
        Me.dgvList2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvList2.Location = New System.Drawing.Point(12, 21)
        Me.dgvList2.MultiSelect = False
        Me.dgvList2.Name = "dgvList2"
        Me.dgvList2.ReadOnly = True
        Me.dgvList2.RowHeadersVisible = False
        Me.dgvList2.RowTemplate.Height = 24
        Me.dgvList2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvList2.Size = New System.Drawing.Size(743, 384)
        Me.dgvList2.TabIndex = 0
        '
        'pnlStep3
        '
        Me.pnlStep3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlStep3.Controls.Add(Me.lblInfo3)
        Me.pnlStep3.Controls.Add(Me.grbRequest)
        Me.pnlStep3.Location = New System.Drawing.Point(12, 8)
        Me.pnlStep3.Name = "pnlStep3"
        Me.pnlStep3.Size = New System.Drawing.Size(769, 450)
        Me.pnlStep3.TabIndex = 2
        Me.pnlStep3.Visible = False
        '
        'lblInfo3
        '
        Me.lblInfo3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblInfo3.AutoSize = True
        Me.lblInfo3.Location = New System.Drawing.Point(3, 434)
        Me.lblInfo3.Name = "lblInfo3"
        Me.lblInfo3.Size = New System.Drawing.Size(0, 12)
        Me.lblInfo3.TabIndex = 1
        '
        'grbRequest
        '
        Me.grbRequest.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbRequest.Controls.Add(Me.chkSelectAll)
        Me.grbRequest.Controls.Add(Me.dgvList3)
        Me.grbRequest.Location = New System.Drawing.Point(0, 0)
        Me.grbRequest.Name = "grbRequest"
        Me.grbRequest.Size = New System.Drawing.Size(769, 419)
        Me.grbRequest.TabIndex = 0
        Me.grbRequest.TabStop = False
        Me.grbRequest.Text = "第三步：选择需要进行激活撤销操作的购物卡对应的销售单号（由此确定撤销金额）"
        '
        'chkSelectAll
        '
        Me.chkSelectAll.AutoCheck = False
        Me.chkSelectAll.AutoSize = True
        Me.chkSelectAll.Location = New System.Drawing.Point(695, 0)
        Me.chkSelectAll.Name = "chkSelectAll"
        Me.chkSelectAll.Size = New System.Drawing.Size(66, 16)
        Me.chkSelectAll.TabIndex = 1
        Me.chkSelectAll.Text = "全选(&A)"
        Me.chkSelectAll.ThreeState = True
        Me.chkSelectAll.UseVisualStyleBackColor = True
        '
        'dgvList3
        '
        Me.dgvList3.AllowUserToAddRows = False
        Me.dgvList3.AllowUserToDeleteRows = False
        Me.dgvList3.AllowUserToResizeRows = False
        Me.dgvList3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvList3.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvList3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvList3.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvList3.ColumnHeadersHeight = 22
        Me.dgvList3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvList3.Location = New System.Drawing.Point(12, 21)
        Me.dgvList3.MultiSelect = False
        Me.dgvList3.Name = "dgvList3"
        Me.dgvList3.ReadOnly = True
        Me.dgvList3.RowHeadersVisible = False
        Me.dgvList3.RowTemplate.Height = 24
        Me.dgvList3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvList3.Size = New System.Drawing.Size(743, 384)
        Me.dgvList3.TabIndex = 0
        '
        'pnlStep1
        '
        Me.pnlStep1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlStep1.Controls.Add(Me.grbInputCardNo)
        Me.pnlStep1.Controls.Add(Me.lblInfo1)
        Me.pnlStep1.Location = New System.Drawing.Point(12, 8)
        Me.pnlStep1.Name = "pnlStep1"
        Me.pnlStep1.Size = New System.Drawing.Size(769, 450)
        Me.pnlStep1.TabIndex = 0
        '
        'grbInputCardNo
        '
        Me.grbInputCardNo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbInputCardNo.Controls.Add(Me.dgvList1)
        Me.grbInputCardNo.Location = New System.Drawing.Point(0, 0)
        Me.grbInputCardNo.Name = "grbInputCardNo"
        Me.grbInputCardNo.Size = New System.Drawing.Size(769, 419)
        Me.grbInputCardNo.TabIndex = 0
        Me.grbInputCardNo.TabStop = False
        Me.grbInputCardNo.Text = "第一步：输入需要进行激活撤销操作的购物卡卡号"
        '
        'dgvList1
        '
        Me.dgvList1.AllowUserToAddRows = False
        Me.dgvList1.AllowUserToDeleteRows = False
        Me.dgvList1.AllowUserToResizeRows = False
        Me.dgvList1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvList1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvList1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvList1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvList1.ColumnHeadersHeight = 22
        Me.dgvList1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvList1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvList1.Location = New System.Drawing.Point(12, 21)
        Me.dgvList1.MultiSelect = False
        Me.dgvList1.Name = "dgvList1"
        Me.dgvList1.RowHeadersVisible = False
        Me.dgvList1.RowTemplate.Height = 24
        Me.dgvList1.Size = New System.Drawing.Size(360, 384)
        Me.dgvList1.TabIndex = 0
        '
        'lblInfo1
        '
        Me.lblInfo1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblInfo1.AutoSize = True
        Me.lblInfo1.Location = New System.Drawing.Point(3, 434)
        Me.lblInfo1.Name = "lblInfo1"
        Me.lblInfo1.Size = New System.Drawing.Size(305, 12)
        Me.lblInfo1.TabIndex = 1
        Me.lblInfo1.Text = "请在上面列表输入需要进行激活撤销操作的购物卡卡号。"
        '
        'cmenuDelete
        '
        Me.cmenuDelete.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuDelete})
        Me.cmenuDelete.Name = "cmenuDeleteCardRow"
        Me.cmenuDelete.Size = New System.Drawing.Size(178, 26)
        '
        'menuDelete
        '
        Me.menuDelete.Name = "menuDelete"
        Me.menuDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.menuDelete.Size = New System.Drawing.Size(177, 22)
        Me.menuDelete.Text = "删除卡号   "
        '
        'pnlStep4
        '
        Me.pnlStep4.Controls.Add(Me.lblInfo4)
        Me.pnlStep4.Controls.Add(Me.grbReason)
        Me.pnlStep4.Location = New System.Drawing.Point(12, 8)
        Me.pnlStep4.Name = "pnlStep4"
        Me.pnlStep4.Size = New System.Drawing.Size(769, 450)
        Me.pnlStep4.TabIndex = 3
        Me.pnlStep4.Visible = False
        '
        'lblInfo4
        '
        Me.lblInfo4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblInfo4.AutoSize = True
        Me.lblInfo4.Location = New System.Drawing.Point(3, 434)
        Me.lblInfo4.Name = "lblInfo4"
        Me.lblInfo4.Size = New System.Drawing.Size(0, 12)
        Me.lblInfo4.TabIndex = 1
        '
        'grbReason
        '
        Me.grbReason.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbReason.Controls.Add(Me.pnlAfter)
        Me.grbReason.Controls.Add(Me.txbReason)
        Me.grbReason.Controls.Add(Me.lblReason)
        Me.grbReason.Location = New System.Drawing.Point(0, 0)
        Me.grbReason.Name = "grbReason"
        Me.grbReason.Size = New System.Drawing.Size(769, 419)
        Me.grbReason.TabIndex = 0
        Me.grbReason.TabStop = False
        Me.grbReason.Text = "第四步：输入激活撤销的原因"
        '
        'pnlAfter
        '
        Me.pnlAfter.Controls.Add(Me.dgvList4)
        Me.pnlAfter.Controls.Add(Me.lblResult)
        Me.pnlAfter.Location = New System.Drawing.Point(12, 74)
        Me.pnlAfter.Name = "pnlAfter"
        Me.pnlAfter.Size = New System.Drawing.Size(743, 333)
        Me.pnlAfter.TabIndex = 2
        Me.pnlAfter.Visible = False
        '
        'dgvList4
        '
        Me.dgvList4.AllowUserToAddRows = False
        Me.dgvList4.AllowUserToDeleteRows = False
        Me.dgvList4.AllowUserToResizeRows = False
        Me.dgvList4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvList4.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvList4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvList4.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvList4.ColumnHeadersHeight = 22
        Me.dgvList4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvList4.Location = New System.Drawing.Point(0, 19)
        Me.dgvList4.MultiSelect = False
        Me.dgvList4.Name = "dgvList4"
        Me.dgvList4.ReadOnly = True
        Me.dgvList4.RowHeadersVisible = False
        Me.dgvList4.RowTemplate.Height = 24
        Me.dgvList4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvList4.Size = New System.Drawing.Size(743, 312)
        Me.dgvList4.TabIndex = 1
        '
        'lblResult
        '
        Me.lblResult.AutoSize = True
        Me.lblResult.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblResult.Location = New System.Drawing.Point(-2, 0)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(605, 12)
        Me.lblResult.TabIndex = 0
        Me.lblResult.Text = "本次的激活撤销申请已保存。如果想撤销本次的申请，请打开历史记录窗口，在该窗口选择并删除本次申请即可。"
        '
        'txbReason
        '
        Me.txbReason.Location = New System.Drawing.Point(12, 40)
        Me.txbReason.MaxLength = 50
        Me.txbReason.Name = "txbReason"
        Me.txbReason.Size = New System.Drawing.Size(743, 21)
        Me.txbReason.TabIndex = 1
        '
        'lblReason
        '
        Me.lblReason.AutoSize = True
        Me.lblReason.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblReason.Location = New System.Drawing.Point(10, 21)
        Me.lblReason.Name = "lblReason"
        Me.lblReason.Size = New System.Drawing.Size(485, 12)
        Me.lblReason.TabIndex = 0
        Me.lblReason.Text = "请输入撤销原因（限 50 个字以内），然后按下面的""完成""按钮保存本次的激活撤销申请："
        '
        'frmCancelActivationRequirement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(794, 516)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnPrevious)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.btnFinish)
        Me.Controls.Add(Me.btnHistory)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pnlStep1)
        Me.Controls.Add(Me.pnlStep4)
        Me.Controls.Add(Me.pnlStep3)
        Me.Controls.Add(Me.pnlStep2)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCancelActivationRequirement"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "购物卡激活撤销申请 Cancel Card Activation Requirement"
        Me.pnlStep2.ResumeLayout(False)
        Me.pnlStep2.PerformLayout()
        Me.grbQueryCardState.ResumeLayout(False)
        CType(Me.dgvList2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlStep3.ResumeLayout(False)
        Me.pnlStep3.PerformLayout()
        Me.grbRequest.ResumeLayout(False)
        Me.grbRequest.PerformLayout()
        CType(Me.dgvList3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlStep1.ResumeLayout(False)
        Me.pnlStep1.PerformLayout()
        Me.grbInputCardNo.ResumeLayout(False)
        CType(Me.dgvList1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmenuDelete.ResumeLayout(False)
        Me.pnlStep4.ResumeLayout(False)
        Me.pnlStep4.PerformLayout()
        Me.grbReason.ResumeLayout(False)
        Me.grbReason.PerformLayout()
        Me.pnlAfter.ResumeLayout(False)
        Me.pnlAfter.PerformLayout()
        CType(Me.dgvList4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnHistory As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnPrevious As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnFinish As System.Windows.Forms.Button
    Friend WithEvents pnlStep2 As System.Windows.Forms.Panel
    Friend WithEvents lblInfo2 As System.Windows.Forms.Label
    Friend WithEvents grbQueryCardState As System.Windows.Forms.GroupBox
    Friend WithEvents pnlStep3 As System.Windows.Forms.Panel
    Friend WithEvents lblInfo3 As System.Windows.Forms.Label
    Friend WithEvents grbRequest As System.Windows.Forms.GroupBox
    Friend WithEvents pnlStep1 As System.Windows.Forms.Panel
    Friend WithEvents lblInfo1 As System.Windows.Forms.Label
    Friend WithEvents grbInputCardNo As System.Windows.Forms.GroupBox
    Friend WithEvents dgvList1 As System.Windows.Forms.DataGridView
    Friend WithEvents dgvList2 As System.Windows.Forms.DataGridView
    Friend WithEvents dgvList3 As System.Windows.Forms.DataGridView
    Friend WithEvents cmenuDelete As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents menuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkSelectAll As System.Windows.Forms.CheckBox
    Friend WithEvents pnlStep4 As System.Windows.Forms.Panel
    Friend WithEvents lblInfo4 As System.Windows.Forms.Label
    Friend WithEvents grbReason As System.Windows.Forms.GroupBox
    Friend WithEvents pnlAfter As System.Windows.Forms.Panel
    Friend WithEvents txbReason As System.Windows.Forms.TextBox
    Friend WithEvents lblReason As System.Windows.Forms.Label
    Friend WithEvents lblResult As System.Windows.Forms.Label
    Friend WithEvents dgvList4 As System.Windows.Forms.DataGridView
End Class
