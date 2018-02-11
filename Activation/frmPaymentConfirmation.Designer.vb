<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaymentConfirmation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPaymentConfirmation))
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbbStore = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbbPaymentTerm = New System.Windows.Forms.ComboBox
        Me.btnSave = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.cbbConfirmationState = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.cbbReceivedDate = New System.Windows.Forms.ComboBox
        Me.mtcReceivedDate = New System.Windows.Forms.MonthCalendar
        Me.pnlReceivedDate = New System.Windows.Forms.Panel
        Me.theTimer = New System.Windows.Forms.Timer(Me.components)
        Me.dgvList = New System.Windows.Forms.DataGridView
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.chbDisplaySelected = New System.Windows.Forms.CheckBox
        Me.pnlConditions = New System.Windows.Forms.Panel
        Me.btnFind = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.pnlReceivedDate.SuspendLayout()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlConditions.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "门店(&S)："
        '
        'cbbStore
        '
        Me.cbbStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbStore.FormattingEnabled = True
        Me.cbbStore.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cbbStore.Location = New System.Drawing.Point(10, 25)
        Me.cbbStore.MaxDropDownItems = 20
        Me.cbbStore.Name = "cbbStore"
        Me.cbbStore.Size = New System.Drawing.Size(120, 20)
        Me.cbbStore.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(134, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "开单日期(&D)："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(246, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 12)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "付款方式:(&P)："
        '
        'cbbPaymentTerm
        '
        Me.cbbPaymentTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbPaymentTerm.FormattingEnabled = True
        Me.cbbPaymentTerm.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cbbPaymentTerm.Items.AddRange(New Object() {"转账/支票", "转账", "支票"})
        Me.cbbPaymentTerm.Location = New System.Drawing.Point(250, 24)
        Me.cbbPaymentTerm.MaxDropDownItems = 9
        Me.cbbPaymentTerm.Name = "cbbPaymentTerm"
        Me.cbbPaymentTerm.Size = New System.Drawing.Size(78, 20)
        Me.cbbPaymentTerm.TabIndex = 5
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.AutoSize = True
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(644, 22)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(62, 23)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "保存(&S)"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(335, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 12)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "确认状态(&T)："
        '
        'cbbConfirmationState
        '
        Me.cbbConfirmationState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbConfirmationState.FormattingEnabled = True
        Me.cbbConfirmationState.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cbbConfirmationState.Items.AddRange(New Object() {"（全部）", "未确认到账", "已确认到账"})
        Me.cbbConfirmationState.Location = New System.Drawing.Point(336, 25)
        Me.cbbConfirmationState.MaxDropDownItems = 20
        Me.cbbConfirmationState.Name = "cbbConfirmationState"
        Me.cbbConfirmationState.Size = New System.Drawing.Size(84, 20)
        Me.cbbConfirmationState.TabIndex = 7
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(-2, 53)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(798, 4)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(426, 24)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(58, 23)
        Me.btnRefresh.TabIndex = 8
        Me.btnRefresh.Text = "刷新(&R)"
        Me.btnRefresh.UseVisualStyleBackColor = True
        Me.btnRefresh.Visible = False
        '
        'cbbReceivedDate
        '
        Me.cbbReceivedDate.FormattingEnabled = True
        Me.cbbReceivedDate.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.cbbReceivedDate.Location = New System.Drawing.Point(136, 24)
        Me.cbbReceivedDate.MaxDropDownItems = 18
        Me.cbbReceivedDate.Name = "cbbReceivedDate"
        Me.cbbReceivedDate.Size = New System.Drawing.Size(106, 20)
        Me.cbbReceivedDate.TabIndex = 3
        '
        'mtcReceivedDate
        '
        Me.mtcReceivedDate.Location = New System.Drawing.Point(1, 1)
        Me.mtcReceivedDate.Margin = New System.Windows.Forms.Padding(0)
        Me.mtcReceivedDate.MaxSelectionCount = 1
        Me.mtcReceivedDate.MinDate = New Date(2011, 1, 1, 0, 0, 0, 0)
        Me.mtcReceivedDate.Name = "mtcReceivedDate"
        Me.mtcReceivedDate.TabIndex = 0
        '
        'pnlReceivedDate
        '
        Me.pnlReceivedDate.AutoSize = True
        Me.pnlReceivedDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlReceivedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlReceivedDate.Controls.Add(Me.mtcReceivedDate)
        Me.pnlReceivedDate.Location = New System.Drawing.Point(137, 44)
        Me.pnlReceivedDate.Name = "pnlReceivedDate"
        Me.pnlReceivedDate.Size = New System.Drawing.Size(272, 148)
        Me.pnlReceivedDate.TabIndex = 4
        Me.pnlReceivedDate.Visible = False
        '
        'theTimer
        '
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
        Me.dgvList.Location = New System.Drawing.Point(10, 28)
        Me.dgvList.MultiSelect = False
        Me.dgvList.Name = "dgvList"
        Me.dgvList.ReadOnly = True
        Me.dgvList.RowHeadersVisible = False
        Me.dgvList.RowTemplate.Height = 24
        Me.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvList.Size = New System.Drawing.Size(763, 380)
        Me.dgvList.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 12)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "付款单列表："
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.AutoSize = True
        Me.btnClose.Location = New System.Drawing.Point(712, 22)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(62, 23)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "关闭(&C)"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'chbDisplaySelected
        '
        Me.chbDisplaySelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chbDisplaySelected.AutoSize = True
        Me.chbDisplaySelected.Location = New System.Drawing.Point(491, 26)
        Me.chbDisplaySelected.Name = "chbDisplaySelected"
        Me.chbDisplaySelected.Size = New System.Drawing.Size(72, 16)
        Me.chbDisplaySelected.TabIndex = 1
        Me.chbDisplaySelected.Text = "显示已选"
        Me.chbDisplaySelected.UseVisualStyleBackColor = True
        Me.chbDisplaySelected.Visible = False
        '
        'pnlConditions
        '
        Me.pnlConditions.Controls.Add(Me.Label1)
        Me.pnlConditions.Controls.Add(Me.btnRefresh)
        Me.pnlConditions.Controls.Add(Me.cbbConfirmationState)
        Me.pnlConditions.Controls.Add(Me.cbbPaymentTerm)
        Me.pnlConditions.Controls.Add(Me.cbbReceivedDate)
        Me.pnlConditions.Controls.Add(Me.Label4)
        Me.pnlConditions.Controls.Add(Me.Label5)
        Me.pnlConditions.Controls.Add(Me.cbbStore)
        Me.pnlConditions.Controls.Add(Me.Label2)
        Me.pnlConditions.Location = New System.Drawing.Point(0, 0)
        Me.pnlConditions.Name = "pnlConditions"
        Me.pnlConditions.Size = New System.Drawing.Size(490, 54)
        Me.pnlConditions.TabIndex = 0
        '
        'btnFind
        '
        Me.btnFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFind.Location = New System.Drawing.Point(563, 22)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(75, 23)
        Me.btnFind.TabIndex = 1
        Me.btnFind.Text = "查找(&F)..."
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.dgvList)
        Me.Panel1.Location = New System.Drawing.Point(0, 58)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(786, 421)
        Me.Panel1.TabIndex = 5
        '
        'frmPaymentConfirmation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(786, 479)
        Me.Controls.Add(Me.pnlReceivedDate)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnFind)
        Me.Controls.Add(Me.chbDisplaySelected)
        Me.Controls.Add(Me.pnlConditions)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPaymentConfirmation"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = """转账/支票""到账确认 Transfer/Cheque Confirmation"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.pnlReceivedDate.ResumeLayout(False)
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlConditions.ResumeLayout(False)
        Me.pnlConditions.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbbStore As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbbPaymentTerm As System.Windows.Forms.ComboBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbbConfirmationState As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents cbbReceivedDate As System.Windows.Forms.ComboBox
    Friend WithEvents pnlReceivedDate As System.Windows.Forms.Panel
    Friend WithEvents mtcReceivedDate As System.Windows.Forms.MonthCalendar
    Friend WithEvents theTimer As System.Windows.Forms.Timer
    Friend WithEvents dgvList As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents chbDisplaySelected As System.Windows.Forms.CheckBox
    Friend WithEvents pnlConditions As System.Windows.Forms.Panel
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
