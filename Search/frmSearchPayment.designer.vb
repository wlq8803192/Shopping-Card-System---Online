<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchPayment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSearchPayment))
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnMore = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rdbByPayerName = New System.Windows.Forms.RadioButton
        Me.txbPayerName = New System.Windows.Forms.TextBox
        Me.rdbByMediaNo = New System.Windows.Forms.RadioButton
        Me.txbMediaNo = New System.Windows.Forms.TextBox
        Me.rdbBySalesBillCode = New System.Windows.Forms.RadioButton
        Me.txbSalesBillCode = New System.Windows.Forms.TextBox
        Me.btnPrevious = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.txbPaymentAMT = New System.Windows.Forms.TextBox
        Me.rdbByPaymentAMT = New System.Windows.Forms.RadioButton
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(270, 144)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(73, 23)
        Me.btnOK.TabIndex = 11
        Me.btnOK.Text = "确定 &OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnMore
        '
        Me.btnMore.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMore.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnMore.Enabled = False
        Me.btnMore.Location = New System.Drawing.Point(349, 144)
        Me.btnMore.Name = "btnMore"
        Me.btnMore.Size = New System.Drawing.Size(159, 23)
        Me.btnMore.TabIndex = 12
        Me.btnMore.Text = "到数据库中查找更多 &More"
        Me.btnMore.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(-5, 127)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(541, 4)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'rdbByPayerName
        '
        Me.rdbByPayerName.AutoSize = True
        Me.rdbByPayerName.Checked = True
        Me.rdbByPayerName.Location = New System.Drawing.Point(14, 15)
        Me.rdbByPayerName.Name = "rdbByPayerName"
        Me.rdbByPayerName.Size = New System.Drawing.Size(209, 16)
        Me.rdbByPayerName.TabIndex = 0
        Me.rdbByPayerName.TabStop = True
        Me.rdbByPayerName.Text = "通过付款单位名称 by Payer Name:"
        Me.rdbByPayerName.UseVisualStyleBackColor = True
        '
        'txbPayerName
        '
        Me.txbPayerName.Location = New System.Drawing.Point(270, 12)
        Me.txbPayerName.MaxLength = 1000
        Me.txbPayerName.Name = "txbPayerName"
        Me.txbPayerName.Size = New System.Drawing.Size(238, 21)
        Me.txbPayerName.TabIndex = 1
        '
        'rdbByMediaNo
        '
        Me.rdbByMediaNo.AutoSize = True
        Me.rdbByMediaNo.Location = New System.Drawing.Point(14, 42)
        Me.rdbByMediaNo.Name = "rdbByMediaNo"
        Me.rdbByMediaNo.Size = New System.Drawing.Size(251, 16)
        Me.rdbByMediaNo.TabIndex = 2
        Me.rdbByMediaNo.Text = "通过转账/支票号 by Account/Cheque No.:"
        Me.rdbByMediaNo.UseVisualStyleBackColor = True
        '
        'txbMediaNo
        '
        Me.txbMediaNo.Enabled = False
        Me.txbMediaNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbMediaNo.Location = New System.Drawing.Point(270, 39)
        Me.txbMediaNo.MaxLength = 50
        Me.txbMediaNo.Name = "txbMediaNo"
        Me.txbMediaNo.Size = New System.Drawing.Size(238, 21)
        Me.txbMediaNo.TabIndex = 3
        '
        'rdbBySalesBillCode
        '
        Me.rdbBySalesBillCode.AutoSize = True
        Me.rdbBySalesBillCode.Location = New System.Drawing.Point(14, 96)
        Me.rdbBySalesBillCode.Name = "rdbBySalesBillCode"
        Me.rdbBySalesBillCode.Size = New System.Drawing.Size(215, 16)
        Me.rdbBySalesBillCode.TabIndex = 6
        Me.rdbBySalesBillCode.Text = "通过销售单号 by Sales Bill Code:"
        Me.rdbBySalesBillCode.UseVisualStyleBackColor = True
        '
        'txbSalesBillCode
        '
        Me.txbSalesBillCode.Enabled = False
        Me.txbSalesBillCode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbSalesBillCode.Location = New System.Drawing.Point(270, 93)
        Me.txbSalesBillCode.MaxLength = 13
        Me.txbSalesBillCode.Name = "txbSalesBillCode"
        Me.txbSalesBillCode.Size = New System.Drawing.Size(238, 21)
        Me.txbSalesBillCode.TabIndex = 7
        '
        'btnPrevious
        '
        Me.btnPrevious.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrevious.Enabled = False
        Me.btnPrevious.Location = New System.Drawing.Point(14, 144)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(105, 23)
        Me.btnPrevious.TabIndex = 9
        Me.btnPrevious.Text = "上一个 &Previous"
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNext.Enabled = False
        Me.btnNext.Location = New System.Drawing.Point(125, 144)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(105, 23)
        Me.btnNext.TabIndex = 10
        Me.btnNext.Text = "下一个 &Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'txbPaymentAMT
        '
        Me.txbPaymentAMT.Enabled = False
        Me.txbPaymentAMT.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbPaymentAMT.Location = New System.Drawing.Point(270, 66)
        Me.txbPaymentAMT.MaxLength = 13
        Me.txbPaymentAMT.Name = "txbPaymentAMT"
        Me.txbPaymentAMT.Size = New System.Drawing.Size(238, 21)
        Me.txbPaymentAMT.TabIndex = 5
        '
        'rdbByPaymentAMT
        '
        Me.rdbByPaymentAMT.AutoSize = True
        Me.rdbByPaymentAMT.Location = New System.Drawing.Point(14, 69)
        Me.rdbByPaymentAMT.Name = "rdbByPaymentAMT"
        Me.rdbByPaymentAMT.Size = New System.Drawing.Size(209, 16)
        Me.rdbByPaymentAMT.TabIndex = 4
        Me.rdbByPaymentAMT.Text = "通过付款金额 by Payment Amount:"
        Me.rdbByPaymentAMT.UseVisualStyleBackColor = True
        '
        'frmSearchPayment
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 179)
        Me.Controls.Add(Me.txbPaymentAMT)
        Me.Controls.Add(Me.rdbByPaymentAMT)
        Me.Controls.Add(Me.txbSalesBillCode)
        Me.Controls.Add(Me.rdbBySalesBillCode)
        Me.Controls.Add(Me.txbMediaNo)
        Me.Controls.Add(Me.rdbByMediaNo)
        Me.Controls.Add(Me.txbPayerName)
        Me.Controls.Add(Me.rdbByPayerName)
        Me.Controls.Add(Me.btnMore)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnPrevious)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSearchPayment"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "查找付款单 Search Payment:"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnMore As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbByPayerName As System.Windows.Forms.RadioButton
    Friend WithEvents txbPayerName As System.Windows.Forms.TextBox
    Friend WithEvents rdbByMediaNo As System.Windows.Forms.RadioButton
    Friend WithEvents txbMediaNo As System.Windows.Forms.TextBox
    Friend WithEvents rdbBySalesBillCode As System.Windows.Forms.RadioButton
    Friend WithEvents txbSalesBillCode As System.Windows.Forms.TextBox
    Friend WithEvents btnPrevious As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents txbPaymentAMT As System.Windows.Forms.TextBox
    Friend WithEvents rdbByPaymentAMT As System.Windows.Forms.RadioButton
End Class
