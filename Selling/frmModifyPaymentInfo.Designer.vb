<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModifyPaymentInfo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModifyPaymentInfo))
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbbPaymentTerm = New System.Windows.Forms.ComboBox
        Me.pnlExtra = New System.Windows.Forms.Panel
        Me.txbPayerName = New System.Windows.Forms.TextBox
        Me.lblPayerName = New System.Windows.Forms.Label
        Me.txbMediaNo = New System.Windows.Forms.TextBox
        Me.lblMediaNo = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txbPaymentAMT = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txbPaymentTerm = New System.Windows.Forms.TextBox
        Me.GroupBox2.SuspendLayout()
        Me.pnlExtra.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(215, 221)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 9
        Me.btnOK.Text = "确定(&O)"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(296, 221)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "取消(&C)"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(-10, 204)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(405, 4)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(359, 73)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "说明："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(341, 12)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "如果付款金额有误，请取消原来的销售单，再重建新的销售单。"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(275, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "付款方式、账号/支票号。但不允许修改付款金额。"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(341, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "允许在售卡员收款后而在Reporting/JV到账确认前修改付款单的"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(35, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "付款方式："
        '
        'cbbPaymentTerm
        '
        Me.cbbPaymentTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbPaymentTerm.FormattingEnabled = True
        Me.cbbPaymentTerm.Location = New System.Drawing.Point(100, 89)
        Me.cbbPaymentTerm.Name = "cbbPaymentTerm"
        Me.cbbPaymentTerm.Size = New System.Drawing.Size(190, 20)
        Me.cbbPaymentTerm.TabIndex = 2
        '
        'pnlExtra
        '
        Me.pnlExtra.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlExtra.Controls.Add(Me.txbPayerName)
        Me.pnlExtra.Controls.Add(Me.lblPayerName)
        Me.pnlExtra.Controls.Add(Me.txbMediaNo)
        Me.pnlExtra.Controls.Add(Me.lblMediaNo)
        Me.pnlExtra.Location = New System.Drawing.Point(12, 142)
        Me.pnlExtra.Name = "pnlExtra"
        Me.pnlExtra.Size = New System.Drawing.Size(359, 50)
        Me.pnlExtra.TabIndex = 7
        '
        'txbPayerName
        '
        Me.txbPayerName.Location = New System.Drawing.Point(88, 28)
        Me.txbPayerName.MaxLength = 100
        Me.txbPayerName.Name = "txbPayerName"
        Me.txbPayerName.Size = New System.Drawing.Size(190, 21)
        Me.txbPayerName.TabIndex = 3
        '
        'lblPayerName
        '
        Me.lblPayerName.Location = New System.Drawing.Point(-1, 33)
        Me.lblPayerName.Name = "lblPayerName"
        Me.lblPayerName.Size = New System.Drawing.Size(89, 12)
        Me.lblPayerName.TabIndex = 2
        Me.lblPayerName.Text = "付款单位："
        Me.lblPayerName.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txbMediaNo
        '
        Me.txbMediaNo.Location = New System.Drawing.Point(88, 1)
        Me.txbMediaNo.MaxLength = 50
        Me.txbMediaNo.Name = "txbMediaNo"
        Me.txbMediaNo.Size = New System.Drawing.Size(190, 21)
        Me.txbMediaNo.TabIndex = 1
        '
        'lblMediaNo
        '
        Me.lblMediaNo.Location = New System.Drawing.Point(-1, 6)
        Me.lblMediaNo.Name = "lblMediaNo"
        Me.lblMediaNo.Size = New System.Drawing.Size(89, 12)
        Me.lblMediaNo.TabIndex = 0
        Me.lblMediaNo.Text = "卡/账/支票号："
        Me.lblMediaNo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(35, 121)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 12)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "付款金额："
        '
        'txbPaymentAMT
        '
        Me.txbPaymentAMT.Location = New System.Drawing.Point(100, 116)
        Me.txbPaymentAMT.MaxLength = 30
        Me.txbPaymentAMT.Name = "txbPaymentAMT"
        Me.txbPaymentAMT.ReadOnly = True
        Me.txbPaymentAMT.Size = New System.Drawing.Size(190, 21)
        Me.txbPaymentAMT.TabIndex = 5
        Me.txbPaymentAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(293, 121)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(17, 12)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "元"
        '
        'txbPaymentTerm
        '
        Me.txbPaymentTerm.Location = New System.Drawing.Point(100, 89)
        Me.txbPaymentTerm.Name = "txbPaymentTerm"
        Me.txbPaymentTerm.ReadOnly = True
        Me.txbPaymentTerm.Size = New System.Drawing.Size(190, 21)
        Me.txbPaymentTerm.TabIndex = 3
        Me.txbPaymentTerm.Text = "支票＋保证金"
        Me.txbPaymentTerm.Visible = False
        '
        'frmModifyPaymentInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(383, 256)
        Me.Controls.Add(Me.pnlExtra)
        Me.Controls.Add(Me.cbbPaymentTerm)
        Me.Controls.Add(Me.txbPaymentAMT)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txbPaymentTerm)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmModifyPaymentInfo"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "请修改付款信息："
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.pnlExtra.ResumeLayout(False)
        Me.pnlExtra.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbbPaymentTerm As System.Windows.Forms.ComboBox
    Friend WithEvents pnlExtra As System.Windows.Forms.Panel
    Friend WithEvents txbMediaNo As System.Windows.Forms.TextBox
    Friend WithEvents lblMediaNo As System.Windows.Forms.Label
    Friend WithEvents txbPayerName As System.Windows.Forms.TextBox
    Friend WithEvents lblPayerName As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txbPaymentAMT As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txbPaymentTerm As System.Windows.Forms.TextBox
End Class
