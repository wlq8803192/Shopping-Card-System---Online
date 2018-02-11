<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCheckCardFromCUL
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCheckCardFromCUL))
        Me.lblError = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.lblInfo = New System.Windows.Forms.Label
        Me.lblPrompt = New System.Windows.Forms.Label
        Me.pnlRetry = New System.Windows.Forms.Panel
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnRetry = New System.Windows.Forms.Button
        Me.lblCardNo = New System.Windows.Forms.Label
        Me.pgbRunning = New System.Windows.Forms.ProgressBar
        Me.lblTitle = New System.Windows.Forms.Label
        Me.theTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.pnlRetry.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblError
        '
        Me.lblError.AutoSize = True
        Me.lblError.ForeColor = System.Drawing.Color.Red
        Me.lblError.Location = New System.Drawing.Point(0, 5)
        Me.lblError.Margin = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(77, 12)
        Me.lblError.TabIndex = 0
        Me.lblError.Text = "检查时出错："
        Me.lblError.Visible = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblError, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblInfo, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 32)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(468, 19)
        Me.TableLayoutPanel1.TabIndex = 10
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Location = New System.Drawing.Point(77, 5)
        Me.lblInfo.Margin = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(119, 12)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "已完成： 0 张 (0 %)"
        '
        'lblPrompt
        '
        Me.lblPrompt.AutoSize = True
        Me.lblPrompt.ForeColor = System.Drawing.Color.Blue
        Me.lblPrompt.Location = New System.Drawing.Point(2, 7)
        Me.lblPrompt.Name = "lblPrompt"
        Me.lblPrompt.Size = New System.Drawing.Size(245, 12)
        Me.lblPrompt.TabIndex = 1
        Me.lblPrompt.Text = "如果已排除故障，请按""重试""按钮重新检查。"
        '
        'pnlRetry
        '
        Me.pnlRetry.Controls.Add(Me.lblPrompt)
        Me.pnlRetry.Controls.Add(Me.btnCancel)
        Me.pnlRetry.Controls.Add(Me.btnRetry)
        Me.pnlRetry.Location = New System.Drawing.Point(10, 90)
        Me.pnlRetry.Name = "pnlRetry"
        Me.pnlRetry.Size = New System.Drawing.Size(475, 26)
        Me.pnlRetry.TabIndex = 9
        Me.pnlRetry.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(395, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "取消(&C)"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnRetry
        '
        Me.btnRetry.Location = New System.Drawing.Point(315, 2)
        Me.btnRetry.Name = "btnRetry"
        Me.btnRetry.Size = New System.Drawing.Size(75, 23)
        Me.btnRetry.TabIndex = 0
        Me.btnRetry.Text = "重试(&R)"
        Me.btnRetry.UseVisualStyleBackColor = True
        '
        'lblCardNo
        '
        Me.lblCardNo.AutoSize = True
        Me.lblCardNo.Location = New System.Drawing.Point(233, 31)
        Me.lblCardNo.Name = "lblCardNo"
        Me.lblCardNo.Size = New System.Drawing.Size(0, 12)
        Me.lblCardNo.TabIndex = 7
        '
        'pgbRunning
        '
        Me.pgbRunning.Location = New System.Drawing.Point(12, 62)
        Me.pgbRunning.Name = "pgbRunning"
        Me.pgbRunning.Size = New System.Drawing.Size(468, 17)
        Me.pgbRunning.TabIndex = 8
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Location = New System.Drawing.Point(12, 12)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(251, 12)
        Me.lblTitle.TabIndex = 6
        Me.lblTitle.Text = "共有 6 张卡需要到银商系统检查其可用状态。"
        '
        'theTimer
        '
        Me.theTimer.Interval = 500
        '
        'frmCheckCardFromCUL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(494, 93)
        Me.ControlBox = False
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.pnlRetry)
        Me.Controls.Add(Me.lblCardNo)
        Me.Controls.Add(Me.pgbRunning)
        Me.Controls.Add(Me.lblTitle)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCheckCardFromCUL"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "正在到银商系统检查购物卡的可用状态……"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.pnlRetry.ResumeLayout(False)
        Me.pnlRetry.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblError As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents lblPrompt As System.Windows.Forms.Label
    Friend WithEvents pnlRetry As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnRetry As System.Windows.Forms.Button
    Friend WithEvents lblCardNo As System.Windows.Forms.Label
    Friend WithEvents pgbRunning As System.Windows.Forms.ProgressBar
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents theTimer As System.Windows.Forms.Timer
End Class
