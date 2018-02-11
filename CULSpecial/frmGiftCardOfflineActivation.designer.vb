<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGiftCardOfflineActivation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGiftCardOfflineActivation))
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnHistory = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnExcute = New System.Windows.Forms.Button
        Me.txbCardNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txbBarcode = New System.Windows.Forms.TextBox
        Me.grbResult = New System.Windows.Forms.GroupBox
        Me.lblResult = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        Me.lblCardNoError = New System.Windows.Forms.Label
        Me.lblBarcodeError = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.grbResult.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(507, 289)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 17
        Me.btnCancel.Text = "取消(&C)"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnHistory
        '
        Me.btnHistory.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHistory.Location = New System.Drawing.Point(396, 289)
        Me.btnHistory.Name = "btnHistory"
        Me.btnHistory.Size = New System.Drawing.Size(105, 23)
        Me.btnHistory.TabIndex = 16
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
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        '
        'btnExcute
        '
        Me.btnExcute.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExcute.Enabled = False
        Me.btnExcute.Location = New System.Drawing.Point(11, 289)
        Me.btnExcute.Name = "btnExcute"
        Me.btnExcute.Size = New System.Drawing.Size(105, 23)
        Me.btnExcute.TabIndex = 15
        Me.btnExcute.Text = "执行离线激活(&E)"
        Me.btnExcute.UseVisualStyleBackColor = True
        '
        'txbCardNo
        '
        Me.txbCardNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbCardNo.Location = New System.Drawing.Point(233, 45)
        Me.txbCardNo.MaxLength = 19
        Me.txbCardNo.Name = "txbCardNo"
        Me.txbCardNo.Size = New System.Drawing.Size(121, 21)
        Me.txbCardNo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(215, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "请输入需要离线激活的礼品卡卡号(&N)："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(215, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "请输入礼品卡相对应的商品条形码(&B)："
        '
        'txbBarcode
        '
        Me.txbBarcode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbBarcode.Location = New System.Drawing.Point(233, 72)
        Me.txbBarcode.MaxLength = 13
        Me.txbBarcode.Name = "txbBarcode"
        Me.txbBarcode.Size = New System.Drawing.Size(121, 21)
        Me.txbBarcode.TabIndex = 4
        '
        'grbResult
        '
        Me.grbResult.Controls.Add(Me.lblResult)
        Me.grbResult.Controls.Add(Me.lblStatus)
        Me.grbResult.Location = New System.Drawing.Point(13, 110)
        Me.grbResult.Name = "grbResult"
        Me.grbResult.Size = New System.Drawing.Size(567, 150)
        Me.grbResult.TabIndex = 13
        Me.grbResult.TabStop = False
        Me.grbResult.Text = "执行结果："
        Me.grbResult.Visible = False
        '
        'lblResult
        '
        Me.lblResult.Location = New System.Drawing.Point(17, 61)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(531, 66)
        Me.lblResult.TabIndex = 1
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(17, 28)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(215, 12)
        Me.lblStatus.TabIndex = 0
        Me.lblStatus.Text = "正在到CUL系统对该卡执行激活操作……"
        '
        'lblCardNoError
        '
        Me.lblCardNoError.AutoSize = True
        Me.lblCardNoError.ForeColor = System.Drawing.Color.Red
        Me.lblCardNoError.Location = New System.Drawing.Point(360, 50)
        Me.lblCardNoError.Name = "lblCardNoError"
        Me.lblCardNoError.Size = New System.Drawing.Size(0, 12)
        Me.lblCardNoError.TabIndex = 2
        '
        'lblBarcodeError
        '
        Me.lblBarcodeError.AutoSize = True
        Me.lblBarcodeError.ForeColor = System.Drawing.Color.Red
        Me.lblBarcodeError.Location = New System.Drawing.Point(360, 77)
        Me.lblBarcodeError.Name = "lblBarcodeError"
        Me.lblBarcodeError.Size = New System.Drawing.Size(0, 12)
        Me.lblBarcodeError.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(12, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 12)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "说明："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(62, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(365, 12)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = """礼品卡离线激活""功能仅限当礼品卡在卖场收银线激活失败时使用。"
        '
        'frmGiftCardOfflineActivation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(594, 324)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblBarcodeError)
        Me.Controls.Add(Me.lblCardNoError)
        Me.Controls.Add(Me.grbResult)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnExcute)
        Me.Controls.Add(Me.btnHistory)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txbBarcode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txbCardNo)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGiftCardOfflineActivation"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "礼品卡离线激活 Gift Card Off-line Activation"
        Me.grbResult.ResumeLayout(False)
        Me.grbResult.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnHistory As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExcute As System.Windows.Forms.Button
    Friend WithEvents txbCardNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txbBarcode As System.Windows.Forms.TextBox
    Friend WithEvents grbResult As System.Windows.Forms.GroupBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblResult As System.Windows.Forms.Label
    Friend WithEvents lblCardNoError As System.Windows.Forms.Label
    Friend WithEvents lblBarcodeError As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
