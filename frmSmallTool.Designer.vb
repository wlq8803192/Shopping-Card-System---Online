<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSmallTool
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSmallTool))
        Me.rtbCards = New System.Windows.Forms.RichTextBox
        Me.btnRun = New System.Windows.Forms.Button
        Me.btnCopy = New System.Windows.Forms.Button
        Me.lblEndCardError = New System.Windows.Forms.Label
        Me.lblStartCardError = New System.Windows.Forms.Label
        Me.txbEndCardNo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txbStartCardNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblCount = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'rtbCards
        '
        Me.rtbCards.BackColor = System.Drawing.SystemColors.Window
        Me.rtbCards.Location = New System.Drawing.Point(242, 20)
        Me.rtbCards.Name = "rtbCards"
        Me.rtbCards.ReadOnly = True
        Me.rtbCards.Size = New System.Drawing.Size(258, 248)
        Me.rtbCards.TabIndex = 7
        Me.rtbCards.Text = ""
        '
        'btnRun
        '
        Me.btnRun.Enabled = False
        Me.btnRun.Location = New System.Drawing.Point(147, 211)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(75, 23)
        Me.btnRun.TabIndex = 8
        Me.btnRun.Text = "分解"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'btnCopy
        '
        Me.btnCopy.Enabled = False
        Me.btnCopy.Location = New System.Drawing.Point(147, 240)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(75, 23)
        Me.btnCopy.TabIndex = 9
        Me.btnCopy.Text = "拷贝"
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'lblEndCardError
        '
        Me.lblEndCardError.AutoSize = True
        Me.lblEndCardError.ForeColor = System.Drawing.Color.Red
        Me.lblEndCardError.Location = New System.Drawing.Point(85, 96)
        Me.lblEndCardError.Name = "lblEndCardError"
        Me.lblEndCardError.Size = New System.Drawing.Size(0, 12)
        Me.lblEndCardError.TabIndex = 5
        '
        'lblStartCardError
        '
        Me.lblStartCardError.AutoSize = True
        Me.lblStartCardError.ForeColor = System.Drawing.Color.Red
        Me.lblStartCardError.Location = New System.Drawing.Point(85, 48)
        Me.lblStartCardError.Name = "lblStartCardError"
        Me.lblStartCardError.Size = New System.Drawing.Size(0, 12)
        Me.lblStartCardError.TabIndex = 2
        '
        'txbEndCardNo
        '
        Me.txbEndCardNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbEndCardNo.Location = New System.Drawing.Point(101, 68)
        Me.txbEndCardNo.MaxLength = 19
        Me.txbEndCardNo.Name = "txbEndCardNo"
        Me.txbEndCardNo.Size = New System.Drawing.Size(121, 21)
        Me.txbEndCardNo.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "结束卡号(&E)："
        '
        'txbStartCardNo
        '
        Me.txbStartCardNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbStartCardNo.Location = New System.Drawing.Point(101, 20)
        Me.txbStartCardNo.MaxLength = 19
        Me.txbStartCardNo.Name = "txbStartCardNo"
        Me.txbStartCardNo.Size = New System.Drawing.Size(121, 21)
        Me.txbStartCardNo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "开始卡号(&S)："
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.Location = New System.Drawing.Point(15, 230)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(0, 12)
        Me.lblCount.TabIndex = 6
        '
        'frmSmallTool
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(520, 288)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.lblEndCardError)
        Me.Controls.Add(Me.lblStartCardError)
        Me.Controls.Add(Me.txbEndCardNo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txbStartCardNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.rtbCards)
        Me.Controls.Add(Me.btnRun)
        Me.Controls.Add(Me.btnCopy)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSmallTool"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "卡号计算器"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rtbCards As System.Windows.Forms.RichTextBox
    Friend WithEvents btnRun As System.Windows.Forms.Button
    Friend WithEvents btnCopy As System.Windows.Forms.Button
    Friend WithEvents lblEndCardError As System.Windows.Forms.Label
    Friend WithEvents lblStartCardError As System.Windows.Forms.Label
    Friend WithEvents txbEndCardNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txbStartCardNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCount As System.Windows.Forms.Label
End Class
