<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReplaceCardRequirement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReplaceCardRequirement))
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnHistory = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnStart = New System.Windows.Forms.Button
        Me.btnPrevious = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnFinish = New System.Windows.Forms.Button
        Me.pnlStep2 = New System.Windows.Forms.Panel
        Me.lblInfo2 = New System.Windows.Forms.Label
        Me.grbNewCard = New System.Windows.Forms.GroupBox
        Me.pnlMulti = New System.Windows.Forms.Panel
        Me.lblMulti = New System.Windows.Forms.Label
        Me.btnClear = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnMulti = New System.Windows.Forms.Button
        Me.dgvMulti = New System.Windows.Forms.DataGridView
        Me.pnlSingle = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.grbNewCardState = New System.Windows.Forms.GroupBox
        Me.lblNewCardState = New System.Windows.Forms.Label
        Me.txbNewCardNo = New System.Windows.Forms.TextBox
        Me.btnQueryNewCardState = New System.Windows.Forms.Button
        Me.lblNewCardError = New System.Windows.Forms.Label
        Me.pnlStep3 = New System.Windows.Forms.Panel
        Me.lblInfo3 = New System.Windows.Forms.Label
        Me.grbReason = New System.Windows.Forms.GroupBox
        Me.pnlAfter = New System.Windows.Forms.Panel
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnRequest = New System.Windows.Forms.Button
        Me.txbReason = New System.Windows.Forms.TextBox
        Me.lblReason = New System.Windows.Forms.Label
        Me.pnlStep1 = New System.Windows.Forms.Panel
        Me.lblInfo1 = New System.Windows.Forms.Label
        Me.grbOldCard = New System.Windows.Forms.GroupBox
        Me.grbOldCardState = New System.Windows.Forms.GroupBox
        Me.lblOldCardState = New System.Windows.Forms.Label
        Me.btnQueryOldCardState = New System.Windows.Forms.Button
        Me.lblOldCardError = New System.Windows.Forms.Label
        Me.txbOldCardNo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmenuDeleteCard = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.menuDeleteCard = New System.Windows.Forms.ToolStripMenuItem
        Me.pnlStart = New System.Windows.Forms.Panel
        Me.rdb65 = New System.Windows.Forms.RadioButton
        Me.btn65 = New System.Windows.Forms.Button
        Me.btnNSC = New System.Windows.Forms.Button
        Me.rdbNSC = New System.Windows.Forms.RadioButton
        Me.btnOSC = New System.Windows.Forms.Button
        Me.rdbOSC = New System.Windows.Forms.RadioButton
        Me.btnBLC = New System.Windows.Forms.Button
        Me.rdbBLC = New System.Windows.Forms.RadioButton
        Me.btnZH = New System.Windows.Forms.Button
        Me.rdbZH = New System.Windows.Forms.RadioButton
        Me.btnSMT = New System.Windows.Forms.Button
        Me.rdbSMT = New System.Windows.Forms.RadioButton
        Me.btnSYT = New System.Windows.Forms.Button
        Me.rdbSYT = New System.Windows.Forms.RadioButton
        Me.btnCRF = New System.Windows.Forms.Button
        Me.rdbCRF = New System.Windows.Forms.RadioButton
        Me.btnC86 = New System.Windows.Forms.Button
        Me.rdbC86 = New System.Windows.Forms.RadioButton

        'modify code 075:start-------------------------------------------------------------------------
        Me.btnNew80 = New System.Windows.Forms.Button
        Me.rdbNew80 = New System.Windows.Forms.RadioButton
        'modify code 075:end-------------------------------------------------------------------------

        Me.Label1 = New System.Windows.Forms.Label
        Me.pnlStep2.SuspendLayout()
        Me.grbNewCard.SuspendLayout()
        Me.pnlMulti.SuspendLayout()
        CType(Me.dgvMulti, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSingle.SuspendLayout()
        Me.grbNewCardState.SuspendLayout()
        Me.pnlStep3.SuspendLayout()
        Me.grbReason.SuspendLayout()
        Me.pnlAfter.SuspendLayout()
        Me.pnlStep1.SuspendLayout()
        Me.grbOldCard.SuspendLayout()
        Me.grbOldCardState.SuspendLayout()
        Me.cmenuDeleteCard.SuspendLayout()
        Me.pnlStart.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(507, 289)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "取消(&C)"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnHistory
        '
        Me.btnHistory.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHistory.Location = New System.Drawing.Point(396, 289)
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
        Me.GroupBox1.Location = New System.Drawing.Point(-10, 274)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(619, 3)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'btnStart
        '
        Me.btnStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnStart.Enabled = False
        Me.btnStart.Location = New System.Drawing.Point(11, 289)
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
        Me.btnPrevious.Location = New System.Drawing.Point(97, 289)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(80, 23)
        Me.btnPrevious.TabIndex = 6
        Me.btnPrevious.Text = "< 上一步(&P)"
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNext.Location = New System.Drawing.Point(183, 289)
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
        Me.btnFinish.Location = New System.Drawing.Point(269, 289)
        Me.btnFinish.Name = "btnFinish"
        Me.btnFinish.Size = New System.Drawing.Size(80, 23)
        Me.btnFinish.TabIndex = 8
        Me.btnFinish.Text = "完成 >>|(&F)"
        Me.btnFinish.UseVisualStyleBackColor = True
        '
        'pnlStep2
        '
        Me.pnlStep2.Controls.Add(Me.lblInfo2)
        Me.pnlStep2.Controls.Add(Me.grbNewCard)
        Me.pnlStep2.Location = New System.Drawing.Point(12, 8)
        Me.pnlStep2.Name = "pnlStep2"
        Me.pnlStep2.Size = New System.Drawing.Size(569, 258)
        Me.pnlStep2.TabIndex = 2
        Me.pnlStep2.Visible = False
        '
        'lblInfo2
        '
        Me.lblInfo2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblInfo2.AutoSize = True
        Me.lblInfo2.Location = New System.Drawing.Point(3, 242)
        Me.lblInfo2.Name = "lblInfo2"
        Me.lblInfo2.Size = New System.Drawing.Size(0, 12)
        Me.lblInfo2.TabIndex = 1
        '
        'grbNewCard
        '
        Me.grbNewCard.Controls.Add(Me.pnlMulti)
        Me.grbNewCard.Controls.Add(Me.pnlSingle)
        Me.grbNewCard.Location = New System.Drawing.Point(0, 0)
        Me.grbNewCard.Name = "grbNewCard"
        Me.grbNewCard.Size = New System.Drawing.Size(569, 227)
        Me.grbNewCard.TabIndex = 0
        Me.grbNewCard.TabStop = False
        Me.grbNewCard.Text = "第二步：输入新卡号并查询该卡的状态"
        '
        'pnlMulti
        '
        Me.pnlMulti.Controls.Add(Me.lblMulti)
        Me.pnlMulti.Controls.Add(Me.btnClear)
        Me.pnlMulti.Controls.Add(Me.btnDelete)
        Me.pnlMulti.Controls.Add(Me.btnMulti)
        Me.pnlMulti.Controls.Add(Me.dgvMulti)
        Me.pnlMulti.Location = New System.Drawing.Point(15, 15)
        Me.pnlMulti.Name = "pnlMulti"
        Me.pnlMulti.Size = New System.Drawing.Size(539, 197)
        Me.pnlMulti.TabIndex = 1
        '
        'lblMulti
        '
        Me.lblMulti.AutoSize = True
        Me.lblMulti.Location = New System.Drawing.Point(0, 8)
        Me.lblMulti.Name = "lblMulti"
        Me.lblMulti.Size = New System.Drawing.Size(0, 12)
        Me.lblMulti.TabIndex = 0
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.Enabled = False
        Me.btnClear.Location = New System.Drawing.Point(389, 0)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(55, 23)
        Me.btnClear.TabIndex = 2
        Me.btnClear.Text = "清空(&C)"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(328, 0)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(55, 23)
        Me.btnDelete.TabIndex = 1
        Me.btnDelete.Text = "删除(&D)"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnMulti
        '
        Me.btnMulti.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMulti.Enabled = False
        Me.btnMulti.Location = New System.Drawing.Point(456, 0)
        Me.btnMulti.Name = "btnMulti"
        Me.btnMulti.Size = New System.Drawing.Size(83, 23)
        Me.btnMulti.TabIndex = 3
        Me.btnMulti.Text = "查询状态(&Q)"
        Me.btnMulti.UseVisualStyleBackColor = True
        '
        'dgvMulti
        '
        Me.dgvMulti.AllowUserToAddRows = False
        Me.dgvMulti.AllowUserToDeleteRows = False
        Me.dgvMulti.AllowUserToResizeRows = False
        Me.dgvMulti.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvMulti.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvMulti.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMulti.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMulti.ColumnHeadersHeight = 22
        Me.dgvMulti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvMulti.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvMulti.Location = New System.Drawing.Point(0, 29)
        Me.dgvMulti.MultiSelect = False
        Me.dgvMulti.Name = "dgvMulti"
        Me.dgvMulti.RowHeadersVisible = False
        Me.dgvMulti.RowTemplate.Height = 24
        Me.dgvMulti.Size = New System.Drawing.Size(539, 168)
        Me.dgvMulti.TabIndex = 4
        '
        'pnlSingle
        '
        Me.pnlSingle.Controls.Add(Me.Label3)
        Me.pnlSingle.Controls.Add(Me.grbNewCardState)
        Me.pnlSingle.Controls.Add(Me.txbNewCardNo)
        Me.pnlSingle.Controls.Add(Me.btnQueryNewCardState)
        Me.pnlSingle.Controls.Add(Me.lblNewCardError)
        Me.pnlSingle.Location = New System.Drawing.Point(17, 24)
        Me.pnlSingle.Name = "pnlSingle"
        Me.pnlSingle.Size = New System.Drawing.Size(532, 182)
        Me.pnlSingle.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(0, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 12)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "新卡号(&S)："
        '
        'grbNewCardState
        '
        Me.grbNewCardState.Controls.Add(Me.lblNewCardState)
        Me.grbNewCardState.Location = New System.Drawing.Point(77, 59)
        Me.grbNewCardState.Name = "grbNewCardState"
        Me.grbNewCardState.Size = New System.Drawing.Size(455, 123)
        Me.grbNewCardState.TabIndex = 4
        Me.grbNewCardState.TabStop = False
        Me.grbNewCardState.Text = "新卡状态："
        Me.grbNewCardState.Visible = False
        '
        'lblNewCardState
        '
        Me.lblNewCardState.Location = New System.Drawing.Point(15, 23)
        Me.lblNewCardState.Name = "lblNewCardState"
        Me.lblNewCardState.Size = New System.Drawing.Size(421, 84)
        Me.lblNewCardState.TabIndex = 0
        '
        'txbNewCardNo
        '
        Me.txbNewCardNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbNewCardNo.Location = New System.Drawing.Point(77, 0)
        Me.txbNewCardNo.MaxLength = 19
        Me.txbNewCardNo.Name = "txbNewCardNo"
        Me.txbNewCardNo.Size = New System.Drawing.Size(130, 21)
        Me.txbNewCardNo.TabIndex = 1
        '
        'btnQueryNewCardState
        '
        Me.btnQueryNewCardState.Enabled = False
        Me.btnQueryNewCardState.Location = New System.Drawing.Point(77, 27)
        Me.btnQueryNewCardState.Name = "btnQueryNewCardState"
        Me.btnQueryNewCardState.Size = New System.Drawing.Size(121, 23)
        Me.btnQueryNewCardState.TabIndex = 3
        Me.btnQueryNewCardState.Text = "查询新卡状态(&Q)"
        Me.btnQueryNewCardState.UseVisualStyleBackColor = True
        '
        'lblNewCardError
        '
        Me.lblNewCardError.AutoSize = True
        Me.lblNewCardError.ForeColor = System.Drawing.Color.Red
        Me.lblNewCardError.Location = New System.Drawing.Point(205, 2)
        Me.lblNewCardError.Name = "lblNewCardError"
        Me.lblNewCardError.Size = New System.Drawing.Size(0, 12)
        Me.lblNewCardError.TabIndex = 2
        '
        'pnlStep3
        '
        Me.pnlStep3.Controls.Add(Me.lblInfo3)
        Me.pnlStep3.Controls.Add(Me.grbReason)
        Me.pnlStep3.Location = New System.Drawing.Point(12, 8)
        Me.pnlStep3.Name = "pnlStep3"
        Me.pnlStep3.Size = New System.Drawing.Size(569, 258)
        Me.pnlStep3.TabIndex = 3
        Me.pnlStep3.Visible = False
        '
        'lblInfo3
        '
        Me.lblInfo3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblInfo3.AutoSize = True
        Me.lblInfo3.Location = New System.Drawing.Point(3, 242)
        Me.lblInfo3.Name = "lblInfo3"
        Me.lblInfo3.Size = New System.Drawing.Size(0, 12)
        Me.lblInfo3.TabIndex = 1
        '
        'grbReason
        '
        Me.grbReason.Controls.Add(Me.pnlAfter)
        Me.grbReason.Controls.Add(Me.btnRequest)
        Me.grbReason.Controls.Add(Me.txbReason)
        Me.grbReason.Controls.Add(Me.lblReason)
        Me.grbReason.Location = New System.Drawing.Point(0, 0)
        Me.grbReason.Name = "grbReason"
        Me.grbReason.Size = New System.Drawing.Size(569, 227)
        Me.grbReason.TabIndex = 0
        Me.grbReason.TabStop = False
        Me.grbReason.Text = "第三步：输入换卡原因后申请换卡"
        '
        'pnlAfter
        '
        Me.pnlAfter.Controls.Add(Me.Label7)
        Me.pnlAfter.Controls.Add(Me.Label6)
        Me.pnlAfter.Controls.Add(Me.Label5)
        Me.pnlAfter.Controls.Add(Me.Label4)
        Me.pnlAfter.Location = New System.Drawing.Point(22, 126)
        Me.pnlAfter.Name = "pnlAfter"
        Me.pnlAfter.Size = New System.Drawing.Size(527, 80)
        Me.pnlAfter.TabIndex = 3
        Me.pnlAfter.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 62)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(473, 12)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "如果想撤销本次换卡的申请，请打开历史记录窗口，在该窗口选择并删除本次申请即可。"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(353, 12)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "换卡成功后，原卡不再可用，原卡上的余额将全部转移到新卡上！"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(329, 12)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "本次的换卡申请已保存，正等待确认。确认后，才正式换卡。"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Location = New System.Drawing.Point(3, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 12)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "注意："
        '
        'btnRequest
        '
        Me.btnRequest.Enabled = False
        Me.btnRequest.Location = New System.Drawing.Point(19, 87)
        Me.btnRequest.Name = "btnRequest"
        Me.btnRequest.Size = New System.Drawing.Size(95, 23)
        Me.btnRequest.TabIndex = 2
        Me.btnRequest.Text = "申请换卡(&R)"
        Me.btnRequest.UseVisualStyleBackColor = True
        '
        'txbReason
        '
        Me.txbReason.Location = New System.Drawing.Point(19, 51)
        Me.txbReason.MaxLength = 50
        Me.txbReason.Name = "txbReason"
        Me.txbReason.Size = New System.Drawing.Size(530, 21)
        Me.txbReason.TabIndex = 1
        '
        'lblReason
        '
        Me.lblReason.AutoSize = True
        Me.lblReason.Location = New System.Drawing.Point(17, 27)
        Me.lblReason.Name = "lblReason"
        Me.lblReason.Size = New System.Drawing.Size(281, 12)
        Me.lblReason.TabIndex = 0
        Me.lblReason.Text = "请在输入换卡原因（限 50 个字以内）后申请换卡："
        '
        'pnlStep1
        '
        Me.pnlStep1.Controls.Add(Me.lblInfo1)
        Me.pnlStep1.Controls.Add(Me.grbOldCard)
        Me.pnlStep1.Location = New System.Drawing.Point(12, 8)
        Me.pnlStep1.Name = "pnlStep1"
        Me.pnlStep1.Size = New System.Drawing.Size(569, 258)
        Me.pnlStep1.TabIndex = 1
        Me.pnlStep1.Visible = False
        '
        'lblInfo1
        '
        Me.lblInfo1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblInfo1.AutoSize = True
        Me.lblInfo1.Location = New System.Drawing.Point(3, 242)
        Me.lblInfo1.Name = "lblInfo1"
        Me.lblInfo1.Size = New System.Drawing.Size(0, 12)
        Me.lblInfo1.TabIndex = 1
        '
        'grbOldCard
        '
        Me.grbOldCard.Controls.Add(Me.grbOldCardState)
        Me.grbOldCard.Controls.Add(Me.btnQueryOldCardState)
        Me.grbOldCard.Controls.Add(Me.lblOldCardError)
        Me.grbOldCard.Controls.Add(Me.txbOldCardNo)
        Me.grbOldCard.Controls.Add(Me.Label2)
        Me.grbOldCard.Location = New System.Drawing.Point(0, 0)
        Me.grbOldCard.Name = "grbOldCard"
        Me.grbOldCard.Size = New System.Drawing.Size(569, 227)
        Me.grbOldCard.TabIndex = 0
        Me.grbOldCard.TabStop = False
        Me.grbOldCard.Text = "第一步：输入原卡（家乐福卡）卡号并查询该卡的状态"
        '
        'grbOldCardState
        '
        Me.grbOldCardState.Controls.Add(Me.lblOldCardState)
        Me.grbOldCardState.Location = New System.Drawing.Point(94, 83)
        Me.grbOldCardState.Name = "grbOldCardState"
        Me.grbOldCardState.Size = New System.Drawing.Size(455, 123)
        Me.grbOldCardState.TabIndex = 4
        Me.grbOldCardState.TabStop = False
        Me.grbOldCardState.Text = "原卡状态："
        Me.grbOldCardState.Visible = False
        '
        'lblOldCardState
        '
        Me.lblOldCardState.Location = New System.Drawing.Point(15, 23)
        Me.lblOldCardState.Name = "lblOldCardState"
        Me.lblOldCardState.Size = New System.Drawing.Size(421, 84)
        Me.lblOldCardState.TabIndex = 0
        '
        'btnQueryOldCardState
        '
        Me.btnQueryOldCardState.Enabled = False
        Me.btnQueryOldCardState.Location = New System.Drawing.Point(94, 51)
        Me.btnQueryOldCardState.Name = "btnQueryOldCardState"
        Me.btnQueryOldCardState.Size = New System.Drawing.Size(121, 23)
        Me.btnQueryOldCardState.TabIndex = 3
        Me.btnQueryOldCardState.Text = "查询原卡状态(&Q)"
        Me.btnQueryOldCardState.UseVisualStyleBackColor = True
        '
        'lblOldCardError
        '
        Me.lblOldCardError.AutoSize = True
        Me.lblOldCardError.ForeColor = System.Drawing.Color.Red
        Me.lblOldCardError.Location = New System.Drawing.Point(221, 29)
        Me.lblOldCardError.Name = "lblOldCardError"
        Me.lblOldCardError.Size = New System.Drawing.Size(0, 12)
        Me.lblOldCardError.TabIndex = 2
        '
        'txbOldCardNo
        '
        Me.txbOldCardNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbOldCardNo.Location = New System.Drawing.Point(94, 24)
        Me.txbOldCardNo.MaxLength = 23
        Me.txbOldCardNo.Name = "txbOldCardNo"
        Me.txbOldCardNo.Size = New System.Drawing.Size(130, 21)
        Me.txbOldCardNo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "原卡号(&S)："
        '
        'cmenuDeleteCard
        '
        Me.cmenuDeleteCard.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuDeleteCard})
        Me.cmenuDeleteCard.Name = "cmenuDeleteCardRow"
        Me.cmenuDeleteCard.Size = New System.Drawing.Size(142, 26)
        '
        'menuDeleteCard
        '
        Me.menuDeleteCard.Name = "menuDeleteCard"
        Me.menuDeleteCard.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.menuDeleteCard.Size = New System.Drawing.Size(141, 22)
        Me.menuDeleteCard.Text = "删除行   "
        '
        'pnlStart
        '
        Me.pnlStart.Controls.Add(Me.rdb65)
        Me.pnlStart.Controls.Add(Me.btn65)
        Me.pnlStart.Controls.Add(Me.btnNSC)
        Me.pnlStart.Controls.Add(Me.rdbNSC)
        Me.pnlStart.Controls.Add(Me.btnOSC)
        Me.pnlStart.Controls.Add(Me.rdbOSC)
        Me.pnlStart.Controls.Add(Me.btnBLC)
        Me.pnlStart.Controls.Add(Me.rdbBLC)
        Me.pnlStart.Controls.Add(Me.btnZH)
        Me.pnlStart.Controls.Add(Me.rdbZH)
        Me.pnlStart.Controls.Add(Me.btnSMT)
        Me.pnlStart.Controls.Add(Me.rdbSMT)
        Me.pnlStart.Controls.Add(Me.btnSYT)
        Me.pnlStart.Controls.Add(Me.rdbSYT)
        Me.pnlStart.Controls.Add(Me.btnCRF)
        Me.pnlStart.Controls.Add(Me.rdbCRF)
        Me.pnlStart.Controls.Add(Me.btnC86)
        Me.pnlStart.Controls.Add(Me.rdbC86)

        'modify code 075:start-------------------------------------------------------------------------
        Me.pnlStart.Controls.Add(Me.btnNew80)
        Me.pnlStart.Controls.Add(Me.rdbNew80)
        'modify code 075:end-------------------------------------------------------------------------

        Me.pnlStart.Controls.Add(Me.Label1)
        Me.pnlStart.Location = New System.Drawing.Point(12, 8)
        Me.pnlStart.Name = "pnlStart"
        Me.pnlStart.Size = New System.Drawing.Size(569, 258)
        Me.pnlStart.TabIndex = 0
        'modify code 075:start-------------------------------------------------------------------------
        '
        'rdbNew80
        '
        Me.rdbNew80.AutoSize = True
        Me.rdbNew80.Location = New System.Drawing.Point(283, 174)
        Me.rdbNew80.Name = "rdbNew80"
        Me.rdbNew80.Size = New System.Drawing.Size(14, 13)
        Me.rdbNew80.TabIndex = 20
        Me.rdbNew80.UseVisualStyleBackColor = True
        '
        'btnNew80
        '
        Me.btnNew80.Location = New System.Drawing.Point(313, 168)
        Me.btnNew80.Name = "btnNew80"
        Me.btnNew80.Size = New System.Drawing.Size(194, 23)
        Me.btnNew80.TabIndex = 19
        Me.btnNew80.Text = "80卡换65/80通卡"
        Me.btnNew80.UseVisualStyleBackColor = True
        'modify code 075:end-------------------------------------------------------------------------
        '
        'rdb65
        '
        Me.rdb65.AutoSize = True
        Me.rdb65.Location = New System.Drawing.Point(27, 174)
        Me.rdb65.Name = "rdb65"
        Me.rdb65.Size = New System.Drawing.Size(14, 13)
        Me.rdb65.TabIndex = 18
        Me.rdb65.UseVisualStyleBackColor = True
        '
        'btn65
        '
        Me.btn65.Location = New System.Drawing.Point(57, 168)
        Me.btn65.Name = "btn65"
        Me.btn65.Size = New System.Drawing.Size(194, 23)
        Me.btn65.TabIndex = 17
        Me.btn65.Text = "65卡换65卡"
        Me.btn65.UseVisualStyleBackColor = True
        '
        'btnNSC
        '
        Me.btnNSC.Location = New System.Drawing.Point(313, 168)
        Me.btnNSC.Name = "btnNSC"
        Me.btnNSC.Size = New System.Drawing.Size(194, 23)
        Me.btnNSC.TabIndex = 16
        Me.btnNSC.Text = "新实名制卡换新实名制卡"
        Me.btnNSC.UseVisualStyleBackColor = True
        Me.btnNSC.Visible = False
        '
        'rdbNSC
        '
        Me.rdbNSC.AutoSize = True
        Me.rdbNSC.Location = New System.Drawing.Point(283, 174)
        Me.rdbNSC.Name = "rdbNSC"
        Me.rdbNSC.Size = New System.Drawing.Size(14, 13)
        Me.rdbNSC.TabIndex = 15
        Me.rdbNSC.UseVisualStyleBackColor = True
        Me.rdbNSC.Visible = False
        '
        'btnOSC
        '
        Me.btnOSC.Location = New System.Drawing.Point(57, 168)
        Me.btnOSC.Name = "btnOSC"
        Me.btnOSC.Size = New System.Drawing.Size(194, 23)
        Me.btnOSC.TabIndex = 14
        Me.btnOSC.Text = "旧实名制卡换新实名制卡"
        Me.btnOSC.UseVisualStyleBackColor = True
        Me.btnOSC.Visible = False
        '
        'rdbOSC
        '
        Me.rdbOSC.AutoSize = True
        Me.rdbOSC.Location = New System.Drawing.Point(27, 174)
        Me.rdbOSC.Name = "rdbOSC"
        Me.rdbOSC.Size = New System.Drawing.Size(14, 13)
        Me.rdbOSC.TabIndex = 13
        Me.rdbOSC.UseVisualStyleBackColor = True
        Me.rdbOSC.Visible = False
        '
        'btnBLC
        '
        Me.btnBLC.Location = New System.Drawing.Point(313, 86)
        Me.btnBLC.Name = "btnBLC"
        Me.btnBLC.Size = New System.Drawing.Size(194, 23)
        Me.btnBLC.TabIndex = 10
        Me.btnBLC.Text = "保龙仓卡换家乐福卡"
        Me.btnBLC.UseVisualStyleBackColor = True
        '
        'rdbBLC
        '
        Me.rdbBLC.AutoSize = True
        Me.rdbBLC.Location = New System.Drawing.Point(283, 92)
        Me.rdbBLC.Name = "rdbBLC"
        Me.rdbBLC.Size = New System.Drawing.Size(14, 13)
        Me.rdbBLC.TabIndex = 9
        Me.rdbBLC.UseVisualStyleBackColor = True
        '
        'btnZH
        '
        Me.btnZH.Location = New System.Drawing.Point(313, 45)
        Me.btnZH.Name = "btnZH"
        Me.btnZH.Size = New System.Drawing.Size(194, 23)
        Me.btnZH.TabIndex = 8
        Me.btnZH.Text = "中行卡换家乐福卡"
        Me.btnZH.UseVisualStyleBackColor = True
        '
        'rdbZH
        '
        Me.rdbZH.AutoSize = True
        Me.rdbZH.Location = New System.Drawing.Point(283, 51)
        Me.rdbZH.Name = "rdbZH"
        Me.rdbZH.Size = New System.Drawing.Size(14, 13)
        Me.rdbZH.TabIndex = 7
        Me.rdbZH.UseVisualStyleBackColor = True
        '
        'btnSMT
        '
        Me.btnSMT.Location = New System.Drawing.Point(57, 127)
        Me.btnSMT.Name = "btnSMT"
        Me.btnSMT.Size = New System.Drawing.Size(194, 23)
        Me.btnSMT.TabIndex = 6
        Me.btnSMT.Text = "斯玛特卡（蓝卡）换家乐福卡"
        Me.btnSMT.UseVisualStyleBackColor = True
        '
        'rdbSMT
        '
        Me.rdbSMT.AutoSize = True
        Me.rdbSMT.Location = New System.Drawing.Point(27, 133)
        Me.rdbSMT.Name = "rdbSMT"
        Me.rdbSMT.Size = New System.Drawing.Size(14, 13)
        Me.rdbSMT.TabIndex = 5
        Me.rdbSMT.UseVisualStyleBackColor = True
        '
        'btnSYT
        '
        Me.btnSYT.Location = New System.Drawing.Point(57, 86)
        Me.btnSYT.Name = "btnSYT"
        Me.btnSYT.Size = New System.Drawing.Size(194, 23)
        Me.btnSYT.TabIndex = 4
        Me.btnSYT.Text = "商银通卡换家乐福卡"
        Me.btnSYT.UseVisualStyleBackColor = True
        '
        'rdbSYT
        '
        Me.rdbSYT.AutoSize = True
        Me.rdbSYT.Location = New System.Drawing.Point(27, 92)
        Me.rdbSYT.Name = "rdbSYT"
        Me.rdbSYT.Size = New System.Drawing.Size(14, 13)
        Me.rdbSYT.TabIndex = 3
        Me.rdbSYT.UseVisualStyleBackColor = True
        '
        'btnCRF
        '
        Me.btnCRF.Location = New System.Drawing.Point(57, 45)
        Me.btnCRF.Name = "btnCRF"
        Me.btnCRF.Size = New System.Drawing.Size(194, 23)
        Me.btnCRF.TabIndex = 2
        Me.btnCRF.Text = "家乐福卡换家乐福"
        Me.btnCRF.UseVisualStyleBackColor = True
        '
        'rdbCRF
        '
        Me.rdbCRF.AutoSize = True
        Me.rdbCRF.Checked = True
        Me.rdbCRF.Location = New System.Drawing.Point(27, 51)
        Me.rdbCRF.Name = "rdbCRF"
        Me.rdbCRF.Size = New System.Drawing.Size(14, 13)
        Me.rdbCRF.TabIndex = 1
        Me.rdbCRF.TabStop = True
        Me.rdbCRF.UseVisualStyleBackColor = True
        '
        'btnC86
        '
        Me.btnC86.Location = New System.Drawing.Point(313, 127)
        Me.btnC86.Name = "btnC86"
        Me.btnC86.Size = New System.Drawing.Size(194, 23)
        Me.btnC86.TabIndex = 12
        Me.btnC86.Text = "86卡换家乐福卡"
        Me.btnC86.UseVisualStyleBackColor = True
        '
        'rdbC86
        '
        Me.rdbC86.AutoSize = True
        Me.rdbC86.Location = New System.Drawing.Point(283, 133)
        Me.rdbC86.Name = "rdbC86"
        Me.rdbC86.Size = New System.Drawing.Size(14, 13)
        Me.rdbC86.TabIndex = 11
        Me.rdbC86.TabStop = True
        Me.rdbC86.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "请选择原卡类型："
        '
        'frmReplaceCardRequirement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(594, 324)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnPrevious)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.btnFinish)
        Me.Controls.Add(Me.btnHistory)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pnlStep1)
        Me.Controls.Add(Me.pnlStep3)
        Me.Controls.Add(Me.pnlStep2)
        Me.Controls.Add(Me.pnlStart)
        Me.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReplaceCardRequirement"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "购物卡换卡申请 Replace Card Requirement"
        Me.pnlStep2.ResumeLayout(False)
        Me.pnlStep2.PerformLayout()
        Me.grbNewCard.ResumeLayout(False)
        Me.pnlMulti.ResumeLayout(False)
        Me.pnlMulti.PerformLayout()
        CType(Me.dgvMulti, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSingle.ResumeLayout(False)
        Me.pnlSingle.PerformLayout()
        Me.grbNewCardState.ResumeLayout(False)
        Me.pnlStep3.ResumeLayout(False)
        Me.pnlStep3.PerformLayout()
        Me.grbReason.ResumeLayout(False)
        Me.grbReason.PerformLayout()
        Me.pnlAfter.ResumeLayout(False)
        Me.pnlAfter.PerformLayout()
        Me.pnlStep1.ResumeLayout(False)
        Me.pnlStep1.PerformLayout()
        Me.grbOldCard.ResumeLayout(False)
        Me.grbOldCard.PerformLayout()
        Me.grbOldCardState.ResumeLayout(False)
        Me.cmenuDeleteCard.ResumeLayout(False)
        Me.pnlStart.ResumeLayout(False)
        Me.pnlStart.PerformLayout()
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
    Friend WithEvents grbNewCard As System.Windows.Forms.GroupBox
    Friend WithEvents pnlStep3 As System.Windows.Forms.Panel
    Friend WithEvents lblInfo3 As System.Windows.Forms.Label
    Friend WithEvents grbReason As System.Windows.Forms.GroupBox
    Friend WithEvents lblReason As System.Windows.Forms.Label
    Friend WithEvents txbReason As System.Windows.Forms.TextBox
    Friend WithEvents grbNewCardState As System.Windows.Forms.GroupBox
    Friend WithEvents lblNewCardState As System.Windows.Forms.Label
    Friend WithEvents btnQueryNewCardState As System.Windows.Forms.Button
    Friend WithEvents lblNewCardError As System.Windows.Forms.Label
    Friend WithEvents txbNewCardNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnRequest As System.Windows.Forms.Button
    Friend WithEvents lblInfo1 As System.Windows.Forms.Label
    Friend WithEvents grbOldCard As System.Windows.Forms.GroupBox
    Friend WithEvents grbOldCardState As System.Windows.Forms.GroupBox
    Friend WithEvents lblOldCardState As System.Windows.Forms.Label
    Friend WithEvents btnQueryOldCardState As System.Windows.Forms.Button
    Friend WithEvents lblOldCardError As System.Windows.Forms.Label
    Friend WithEvents txbOldCardNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlAfter As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents pnlSingle As System.Windows.Forms.Panel
    Friend WithEvents pnlMulti As System.Windows.Forms.Panel
    Friend WithEvents dgvMulti As System.Windows.Forms.DataGridView
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnMulti As System.Windows.Forms.Button
    Friend WithEvents lblMulti As System.Windows.Forms.Label
    Friend WithEvents cmenuDeleteCard As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents menuDeleteCard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSMT As System.Windows.Forms.Button
    Friend WithEvents rdbSMT As System.Windows.Forms.RadioButton
    Friend WithEvents btnSYT As System.Windows.Forms.Button
    Friend WithEvents rdbSYT As System.Windows.Forms.RadioButton
    Friend WithEvents btnCRF As System.Windows.Forms.Button
    Friend WithEvents rdbCRF As System.Windows.Forms.RadioButton
    'modify code 045:start-------------------------------------------------------------------------
    Friend WithEvents btnC86 As System.Windows.Forms.Button
    Friend WithEvents rdbC86 As System.Windows.Forms.RadioButton
    'modify code 045:end-------------------------------------------------------------------------
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnBLC As System.Windows.Forms.Button
    Friend WithEvents rdbBLC As System.Windows.Forms.RadioButton
    Friend WithEvents btnZH As System.Windows.Forms.Button
    Friend WithEvents rdbZH As System.Windows.Forms.RadioButton
    Friend WithEvents pnlStep1 As System.Windows.Forms.Panel
    Friend WithEvents pnlStart As System.Windows.Forms.Panel
    Friend WithEvents btnOSC As System.Windows.Forms.Button
    Friend WithEvents rdbOSC As System.Windows.Forms.RadioButton
    Friend WithEvents btnNSC As System.Windows.Forms.Button
    Friend WithEvents rdbNSC As System.Windows.Forms.RadioButton
    Friend WithEvents btn65 As System.Windows.Forms.Button
    Friend WithEvents rdb65 As System.Windows.Forms.RadioButton

    'modify code 075:start-------------------------------------------------------------------------
    Friend WithEvents btnNew80 As System.Windows.Forms.Button
    Friend WithEvents rdbNew80 As System.Windows.Forms.RadioButton
    'modify code 075:end-------------------------------------------------------------------------
End Class
