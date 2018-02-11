<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransfer
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTransfer))
        Me.btnQuery = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnClose = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.txbFromCard = New System.Windows.Forms.TextBox
        Me.dgvCards = New System.Windows.Forms.DataGridView
        Me.CardType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cardNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.balance = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ActivedDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExpiredDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IssuerCreateUser = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IssuerMerchant = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.hotReason = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblPrompt = New System.Windows.Forms.Label
        Me.txbToCard = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txbAmount = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnTransfer = New System.Windows.Forms.Button
        Me.dgvRequest = New System.Windows.Forms.DataGridView
        Me.FromCard = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToCard = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RequestAmount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreateTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnQueryHis = New System.Windows.Forms.Button
        Me.statusMain = New System.Windows.Forms.StatusStrip
        Me.statusText = New System.Windows.Forms.ToolStripStatusLabel
        CType(Me.dgvCards, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvRequest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.statusMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnQuery
        '
        Me.btnQuery.Location = New System.Drawing.Point(468, 26)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(94, 23)
        Me.btnQuery.TabIndex = 34
        Me.btnQuery.Text = "查询"
        Me.btnQuery.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(-10, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(967, 4)
        Me.GroupBox1.TabIndex = 41
        Me.GroupBox1.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(610, 255)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(94, 23)
        Me.btnClose.TabIndex = 42
        Me.btnClose.Text = "退出(&X)"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(231, 33)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 13)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "转入卡号："
        '
        'txbFromCard
        '
        Me.txbFromCard.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbFromCard.Location = New System.Drawing.Point(85, 30)
        Me.txbFromCard.MaxLength = 19
        Me.txbFromCard.Name = "txbFromCard"
        Me.txbFromCard.Size = New System.Drawing.Size(121, 20)
        Me.txbFromCard.TabIndex = 36
        '
        'dgvCards
        '
        Me.dgvCards.AllowUserToAddRows = False
        Me.dgvCards.AllowUserToDeleteRows = False
        Me.dgvCards.AllowUserToResizeRows = False
        Me.dgvCards.BackgroundColor = System.Drawing.Color.White
        Me.dgvCards.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCards.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCards.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CardType, Me.cardNo, Me.status, Me.balance, Me.ActivedDate, Me.ExpiredDate, Me.IssuerCreateUser, Me.IssuerMerchant, Me.hotReason})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCards.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvCards.Location = New System.Drawing.Point(15, 75)
        Me.dgvCards.Name = "dgvCards"
        Me.dgvCards.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCards.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvCards.RowHeadersVisible = False
        Me.dgvCards.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.dgvCards.Size = New System.Drawing.Size(701, 84)
        Me.dgvCards.TabIndex = 40
        '
        'CardType
        '
        Me.CardType.HeaderText = "类别"
        Me.CardType.Name = "CardType"
        Me.CardType.ReadOnly = True
        Me.CardType.Width = 70
        '
        'cardNo
        '
        Me.cardNo.HeaderText = "卡号"
        Me.cardNo.Name = "cardNo"
        Me.cardNo.ReadOnly = True
        Me.cardNo.Width = 130
        '
        'status
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.status.DefaultCellStyle = DataGridViewCellStyle2
        Me.status.HeaderText = "状态"
        Me.status.Name = "status"
        Me.status.ReadOnly = True
        Me.status.Width = 65
        '
        'balance
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.balance.DefaultCellStyle = DataGridViewCellStyle3
        Me.balance.HeaderText = "余额"
        Me.balance.Name = "balance"
        Me.balance.ReadOnly = True
        Me.balance.Width = 80
        '
        'ActivedDate
        '
        Me.ActivedDate.HeaderText = "激活日期"
        Me.ActivedDate.Name = "ActivedDate"
        Me.ActivedDate.ReadOnly = True
        '
        'ExpiredDate
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ExpiredDate.DefaultCellStyle = DataGridViewCellStyle4
        Me.ExpiredDate.HeaderText = "有效期"
        Me.ExpiredDate.Name = "ExpiredDate"
        Me.ExpiredDate.ReadOnly = True
        Me.ExpiredDate.Width = 70
        '
        'IssuerCreateUser
        '
        Me.IssuerCreateUser.HeaderText = "售卖操作员"
        Me.IssuerCreateUser.Name = "IssuerCreateUser"
        Me.IssuerCreateUser.ReadOnly = True
        Me.IssuerCreateUser.Visible = False
        Me.IssuerCreateUser.Width = 90
        '
        'IssuerMerchant
        '
        Me.IssuerMerchant.HeaderText = "发卡店铺"
        Me.IssuerMerchant.Name = "IssuerMerchant"
        Me.IssuerMerchant.ReadOnly = True
        '
        'hotReason
        '
        Me.hotReason.HeaderText = "暂停原因"
        Me.hotReason.Name = "hotReason"
        Me.hotReason.ReadOnly = True
        Me.hotReason.Width = 80
        '
        'lblPrompt
        '
        Me.lblPrompt.AutoSize = True
        Me.lblPrompt.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblPrompt.Location = New System.Drawing.Point(10, 6)
        Me.lblPrompt.Name = "lblPrompt"
        Me.lblPrompt.Size = New System.Drawing.Size(329, 13)
        Me.lblPrompt.TabIndex = 39
        Me.lblPrompt.Text = "1. 请输入转出卡号和转入卡号，然后请按""查询""按钮进行查询"
        '
        'txbToCard
        '
        Me.txbToCard.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbToCard.Location = New System.Drawing.Point(316, 28)
        Me.txbToCard.MaxLength = 19
        Me.txbToCard.Name = "txbToCard"
        Me.txbToCard.Size = New System.Drawing.Size(121, 20)
        Me.txbToCard.TabIndex = 38
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "转出卡号："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(10, 173)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(523, 13)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "2 .请输入转账金额和转出卡密码，请注意转账金额不能超出转出卡的余额，然后点击按钮进行转账"
        '
        'txbAmount
        '
        Me.txbAmount.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbAmount.Location = New System.Drawing.Point(85, 207)
        Me.txbAmount.MaxLength = 8
        Me.txbAmount.Name = "txbAmount"
        Me.txbAmount.Size = New System.Drawing.Size(121, 20)
        Me.txbAmount.TabIndex = 44
        Me.txbAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 210)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "转账金额："
        '
        'btnTransfer
        '
        Me.btnTransfer.Location = New System.Drawing.Point(234, 205)
        Me.btnTransfer.Name = "btnTransfer"
        Me.btnTransfer.Size = New System.Drawing.Size(94, 23)
        Me.btnTransfer.TabIndex = 46
        Me.btnTransfer.Text = "转账"
        Me.btnTransfer.UseVisualStyleBackColor = True
        '
        'dgvRequest
        '
        Me.dgvRequest.AllowUserToAddRows = False
        Me.dgvRequest.AllowUserToDeleteRows = False
        Me.dgvRequest.AllowUserToOrderColumns = True
        Me.dgvRequest.BackgroundColor = System.Drawing.Color.White
        Me.dgvRequest.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvRequest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRequest.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FromCard, Me.ToCard, Me.RequestAmount, Me.Column1, Me.CreateTime})
        Me.dgvRequest.Location = New System.Drawing.Point(12, 289)
        Me.dgvRequest.Name = "dgvRequest"
        Me.dgvRequest.ReadOnly = True
        Me.dgvRequest.Size = New System.Drawing.Size(704, 109)
        Me.dgvRequest.TabIndex = 47
        '
        'FromCard
        '
        Me.FromCard.DataPropertyName = "startcard"
        Me.FromCard.HeaderText = "转出卡号"
        Me.FromCard.Name = "FromCard"
        Me.FromCard.ReadOnly = True
        Me.FromCard.Width = 130
        '
        'ToCard
        '
        Me.ToCard.DataPropertyName = "endcard"
        Me.ToCard.HeaderText = "转入卡号"
        Me.ToCard.Name = "ToCard"
        Me.ToCard.ReadOnly = True
        Me.ToCard.Width = 130
        '
        'RequestAmount
        '
        Me.RequestAmount.DataPropertyName = "RequestAMT"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.RequestAmount.DefaultCellStyle = DataGridViewCellStyle7
        Me.RequestAmount.HeaderText = "转账金额"
        Me.RequestAmount.Name = "RequestAmount"
        Me.RequestAmount.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "申请人"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'CreateTime
        '
        Me.CreateTime.DataPropertyName = "requestedtime"
        Me.CreateTime.HeaderText = "申请时间"
        Me.CreateTime.Name = "CreateTime"
        Me.CreateTime.ReadOnly = True
        '
        'GroupBox2
        '
        Me.GroupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(2, 241)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(967, 4)
        Me.GroupBox2.TabIndex = 42
        Me.GroupBox2.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Location = New System.Drawing.Point(14, 265)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(175, 13)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "3. 请在这里查询尚未确认的转账"
        '
        'btnQueryHis
        '
        Me.btnQueryHis.Location = New System.Drawing.Point(234, 260)
        Me.btnQueryHis.Name = "btnQueryHis"
        Me.btnQueryHis.Size = New System.Drawing.Size(94, 23)
        Me.btnQueryHis.TabIndex = 49
        Me.btnQueryHis.Text = "查询"
        Me.btnQueryHis.UseVisualStyleBackColor = True
        '
        'statusMain
        '
        Me.statusMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusText})
        Me.statusMain.Location = New System.Drawing.Point(0, 402)
        Me.statusMain.Name = "statusMain"
        Me.statusMain.Size = New System.Drawing.Size(726, 22)
        Me.statusMain.TabIndex = 53
        '
        'statusText
        '
        Me.statusText.AutoSize = False
        Me.statusText.ForeColor = System.Drawing.Color.Red
        Me.statusText.Name = "statusText"
        Me.statusText.Size = New System.Drawing.Size(600, 17)
        Me.statusText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmTransfer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(726, 424)
        Me.Controls.Add(Me.statusMain)
        Me.Controls.Add(Me.btnQueryHis)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dgvRequest)
        Me.Controls.Add(Me.btnTransfer)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txbAmount)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnQuery)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txbFromCard)
        Me.Controls.Add(Me.dgvCards)
        Me.Controls.Add(Me.lblPrompt)
        Me.Controls.Add(Me.txbToCard)
        Me.Controls.Add(Me.Label6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTransfer"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "转账申请"
        CType(Me.dgvCards, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvRequest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.statusMain.ResumeLayout(False)
        Me.statusMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnQuery As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txbFromCard As System.Windows.Forms.TextBox
    Friend WithEvents dgvCards As System.Windows.Forms.DataGridView
    Friend WithEvents lblPrompt As System.Windows.Forms.Label
    Friend WithEvents txbToCard As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txbAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnTransfer As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnQueryHis As System.Windows.Forms.Button
    Friend WithEvents CardType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cardNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents balance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActivedDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExpiredDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IssuerCreateUser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IssuerMerchant As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents hotReason As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvRequest As System.Windows.Forms.DataGridView
    Friend WithEvents statusMain As System.Windows.Forms.StatusStrip
    Friend WithEvents statusText As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents FromCard As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToCard As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RequestAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreateTime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
