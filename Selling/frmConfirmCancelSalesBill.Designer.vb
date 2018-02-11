<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfirmCancelSalesBill
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfirmCancelSalesBill))
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txbPaymentAMT = New System.Windows.Forms.TextBox
        Me.txbChargedAMT = New System.Windows.Forms.TextBox
        Me.Label64 = New System.Windows.Forms.Label
        Me.Label55 = New System.Windows.Forms.Label
        Me.Label65 = New System.Windows.Forms.Label
        Me.Label61 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txbWho = New System.Windows.Forms.TextBox
        Me.txbWhen = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txbWhy = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(344, 249)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 23)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "确定 &OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(430, 249)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 23)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "取消 &Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(-10, 232)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(546, 4)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'txbPaymentAMT
        '
        Me.txbPaymentAMT.Location = New System.Drawing.Point(175, 51)
        Me.txbPaymentAMT.Name = "txbPaymentAMT"
        Me.txbPaymentAMT.ReadOnly = True
        Me.txbPaymentAMT.Size = New System.Drawing.Size(118, 21)
        Me.txbPaymentAMT.TabIndex = 7
        Me.txbPaymentAMT.Text = "0.00"
        Me.txbPaymentAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txbChargedAMT
        '
        Me.txbChargedAMT.Location = New System.Drawing.Point(175, 24)
        Me.txbChargedAMT.Name = "txbChargedAMT"
        Me.txbChargedAMT.ReadOnly = True
        Me.txbChargedAMT.Size = New System.Drawing.Size(118, 21)
        Me.txbChargedAMT.TabIndex = 10
        Me.txbChargedAMT.Text = "0.00"
        Me.txbChargedAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Location = New System.Drawing.Point(11, 56)
        Me.Label64.Margin = New System.Windows.Forms.Padding(0)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(161, 12)
        Me.Label64.TabIndex = 6
        Me.Label64.Text = "实付金额 Received Payment:"
        Me.Label64.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(296, 29)
        Me.Label55.Margin = New System.Windows.Forms.Padding(0)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(17, 12)
        Me.Label55.TabIndex = 11
        Me.Label55.Text = "元"
        Me.Label55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Location = New System.Drawing.Point(296, 56)
        Me.Label65.Margin = New System.Windows.Forms.Padding(0)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(17, 12)
        Me.Label65.TabIndex = 8
        Me.Label65.Text = "元"
        Me.Label65.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Location = New System.Drawing.Point(11, 29)
        Me.Label61.Margin = New System.Windows.Forms.Padding(0)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(161, 12)
        Me.Label61.TabIndex = 9
        Me.Label61.Text = "充值金额   Charged Amount:"
        Me.Label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txbChargedAMT)
        Me.GroupBox2.Controls.Add(Me.txbPaymentAMT)
        Me.GroupBox2.Controls.Add(Me.Label61)
        Me.GroupBox2.Controls.Add(Me.Label65)
        Me.GroupBox2.Controls.Add(Me.Label64)
        Me.GroupBox2.Controls.Add(Me.Label55)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 10)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(496, 87)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "销售单信息 Sales Bill Info:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txbWho)
        Me.GroupBox3.Controls.Add(Me.txbWhy)
        Me.GroupBox3.Controls.Add(Me.txbWhen)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(14, 103)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(496, 115)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "取消申请 Cancellation Requisition:"
        '
        'txbWho
        '
        Me.txbWho.Location = New System.Drawing.Point(145, 24)
        Me.txbWho.Name = "txbWho"
        Me.txbWho.ReadOnly = True
        Me.txbWho.Size = New System.Drawing.Size(148, 21)
        Me.txbWho.TabIndex = 10
        '
        'txbWhen
        '
        Me.txbWhen.Location = New System.Drawing.Point(145, 51)
        Me.txbWhen.Name = "txbWhen"
        Me.txbWhen.ReadOnly = True
        Me.txbWhen.Size = New System.Drawing.Size(148, 21)
        Me.txbWhen.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 29)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 12)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "申请人     Applicant:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 56)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(131, 12)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "申请时间 Date && Time:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 83)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(131, 12)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "申请原因      Reason:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txbWhy
        '
        Me.txbWhy.Location = New System.Drawing.Point(145, 78)
        Me.txbWhy.Name = "txbWhy"
        Me.txbWhy.ReadOnly = True
        Me.txbWhy.Size = New System.Drawing.Size(333, 21)
        Me.txbWhy.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(12, 254)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(320, 12)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "If you're agree to cancel, please click ""OK""."
        '
        'frmUncancelSalesBill
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(524, 284)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUncancelSalesBill"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "确认取消销售单 Approve Cancel Sales Bill:"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txbPaymentAMT As System.Windows.Forms.TextBox
    Friend WithEvents txbChargedAMT As System.Windows.Forms.TextBox
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txbWho As System.Windows.Forms.TextBox
    Friend WithEvents txbWhen As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txbWhy As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
