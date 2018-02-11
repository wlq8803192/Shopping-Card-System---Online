<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCancelMKTActivationValidation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCancelMKTActivationValidation))
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnHistory = New System.Windows.Forms.Button
        Me.cmenuDelete = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.menuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvDetails = New System.Windows.Forms.DataGridView
        Me.lblDetails = New System.Windows.Forms.Label
        Me.cbbBatch = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lblAMT = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblTime = New System.Windows.Forms.Label
        Me.lblPerson = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblReason = New System.Windows.Forms.Label
        Me.lblStore = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.lblQTY = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txbReason = New System.Windows.Forms.TextBox
        Me.rdbNotapprove = New System.Windows.Forms.RadioButton
        Me.rdbApprove = New System.Windows.Forms.RadioButton
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btnExcute = New System.Windows.Forms.Button
        Me.lblSelected = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblNothing = New System.Windows.Forms.Label
        Me.cmenuDelete.SuspendLayout()
        CType(Me.dgvDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(707, 493)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 11
        Me.btnClose.Text = "关闭 Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnHistory
        '
        Me.btnHistory.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHistory.Location = New System.Drawing.Point(528, 493)
        Me.btnHistory.Name = "btnHistory"
        Me.btnHistory.Size = New System.Drawing.Size(173, 23)
        Me.btnHistory.TabIndex = 10
        Me.btnHistory.Text = "查看历史记录 View &History"
        Me.btnHistory.UseVisualStyleBackColor = True
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(40, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "激活撤销申请记录列表"
        '
        'dgvDetails
        '
        Me.dgvDetails.AllowUserToAddRows = False
        Me.dgvDetails.AllowUserToDeleteRows = False
        Me.dgvDetails.AllowUserToResizeRows = False
        Me.dgvDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetails.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDetails.ColumnHeadersHeight = 22
        Me.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvDetails.Location = New System.Drawing.Point(12, 182)
        Me.dgvDetails.MultiSelect = False
        Me.dgvDetails.Name = "dgvDetails"
        Me.dgvDetails.ReadOnly = True
        Me.dgvDetails.RowHeadersVisible = False
        Me.dgvDetails.RowTemplate.Height = 24
        Me.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetails.Size = New System.Drawing.Size(768, 216)
        Me.dgvDetails.TabIndex = 5
        '
        'lblDetails
        '
        Me.lblDetails.AutoSize = True
        Me.lblDetails.Location = New System.Drawing.Point(10, 163)
        Me.lblDetails.Name = "lblDetails"
        Me.lblDetails.Size = New System.Drawing.Size(137, 12)
        Me.lblDetails.TabIndex = 4
        Me.lblDetails.Text = "激活撤销申请记录明细："
        '
        'cbbBatch
        '
        Me.cbbBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbBatch.FormattingEnabled = True
        Me.cbbBatch.Location = New System.Drawing.Point(171, 12)
        Me.cbbBatch.MaxDropDownItems = 50
        Me.cbbBatch.Name = "cbbBatch"
        Me.cbbBatch.Size = New System.Drawing.Size(609, 20)
        Me.cbbBatch.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(-10, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(820, 3)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblAMT)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.lblTime)
        Me.GroupBox2.Controls.Add(Me.lblPerson)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.lblReason)
        Me.GroupBox2.Controls.Add(Me.lblStore)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.lblQTY)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 54)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(768, 102)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "激活撤销申请 Activation Cancellation Requiremnt:"
        '
        'lblAMT
        '
        Me.lblAMT.BackColor = System.Drawing.SystemColors.Info
        Me.lblAMT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAMT.Location = New System.Drawing.Point(525, 21)
        Me.lblAMT.Name = "lblAMT"
        Me.lblAMT.Size = New System.Drawing.Size(144, 18)
        Me.lblAMT.TabIndex = 4
        Me.lblAMT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(370, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(149, 12)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "撤销金额 Cancelling AMT:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(675, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 12)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "元 Yuan"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(287, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "张 Pieces"
        '
        'lblTime
        '
        Me.lblTime.BackColor = System.Drawing.SystemColors.Info
        Me.lblTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTime.Location = New System.Drawing.Point(632, 46)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(123, 18)
        Me.lblTime.TabIndex = 11
        Me.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPerson
        '
        Me.lblPerson.BackColor = System.Drawing.SystemColors.Info
        Me.lblPerson.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPerson.Location = New System.Drawing.Point(400, 46)
        Me.lblPerson.Name = "lblPerson"
        Me.lblPerson.Size = New System.Drawing.Size(131, 18)
        Me.lblPerson.TabIndex = 9
        Me.lblPerson.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(537, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(89, 12)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "申请时间 Time:"
        '
        'lblReason
        '
        Me.lblReason.BackColor = System.Drawing.SystemColors.Info
        Me.lblReason.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblReason.Location = New System.Drawing.Point(137, 72)
        Me.lblReason.Name = "lblReason"
        Me.lblReason.Size = New System.Drawing.Size(618, 18)
        Me.lblReason.TabIndex = 13
        Me.lblReason.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStore
        '
        Me.lblStore.BackColor = System.Drawing.SystemColors.Info
        Me.lblStore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblStore.Location = New System.Drawing.Point(137, 46)
        Me.lblStore.Name = "lblStore"
        Me.lblStore.Size = New System.Drawing.Size(144, 18)
        Me.lblStore.TabIndex = 7
        Me.lblStore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(287, 49)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(107, 12)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "申请者 Applicant:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 75)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(101, 12)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "撤销原因 Reason:"
        '
        'lblQTY
        '
        Me.lblQTY.BackColor = System.Drawing.SystemColors.Info
        Me.lblQTY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblQTY.Location = New System.Drawing.Point(137, 21)
        Me.lblQTY.Name = "lblQTY"
        Me.lblQTY.Size = New System.Drawing.Size(144, 18)
        Me.lblQTY.TabIndex = 1
        Me.lblQTY.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 49)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(125, 12)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "申请门店 From Store:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "卡数 Cancelling QTY:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txbReason)
        Me.GroupBox3.Controls.Add(Me.rdbNotapprove)
        Me.GroupBox3.Controls.Add(Me.rdbApprove)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 406)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(768, 55)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "激活撤销确认 Activation Cancellation Validation:"
        '
        'txbReason
        '
        Me.txbReason.Enabled = False
        Me.txbReason.Location = New System.Drawing.Point(228, 21)
        Me.txbReason.Name = "txbReason"
        Me.txbReason.Size = New System.Drawing.Size(527, 21)
        Me.txbReason.TabIndex = 2
        '
        'rdbNotapprove
        '
        Me.rdbNotapprove.AutoSize = True
        Me.rdbNotapprove.Location = New System.Drawing.Point(79, 23)
        Me.rdbNotapprove.Name = "rdbNotapprove"
        Me.rdbNotapprove.Size = New System.Drawing.Size(143, 16)
        Me.rdbNotapprove.TabIndex = 1
        Me.rdbNotapprove.TabStop = True
        Me.rdbNotapprove.Text = "&Not approve, reason:"
        Me.rdbNotapprove.UseVisualStyleBackColor = True
        '
        'rdbApprove
        '
        Me.rdbApprove.AccessibleDescription = ""
        Me.rdbApprove.AutoSize = True
        Me.rdbApprove.Location = New System.Drawing.Point(8, 23)
        Me.rdbApprove.Name = "rdbApprove"
        Me.rdbApprove.Size = New System.Drawing.Size(65, 16)
        Me.rdbApprove.TabIndex = 0
        Me.rdbApprove.TabStop = True
        Me.rdbApprove.Text = "&Approve"
        Me.rdbApprove.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Enabled = False
        Me.GroupBox4.Location = New System.Drawing.Point(-10, 476)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(820, 3)
        Me.GroupBox4.TabIndex = 7
        Me.GroupBox4.TabStop = False
        '
        'btnExcute
        '
        Me.btnExcute.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExcute.Enabled = False
        Me.btnExcute.Location = New System.Drawing.Point(12, 493)
        Me.btnExcute.Name = "btnExcute"
        Me.btnExcute.Size = New System.Drawing.Size(220, 23)
        Me.btnExcute.TabIndex = 8
        Me.btnExcute.Text = "Send to CUL to &excute cancellation"
        Me.btnExcute.UseVisualStyleBackColor = True
        '
        'lblSelected
        '
        Me.lblSelected.AutoSize = True
        Me.lblSelected.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblSelected.ForeColor = System.Drawing.Color.Brown
        Me.lblSelected.Location = New System.Drawing.Point(238, 498)
        Me.lblSelected.Name = "lblSelected"
        Me.lblSelected.Size = New System.Drawing.Size(0, 12)
        Me.lblSelected.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(155, 12)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Cancellation &Requisition:"
        '
        'lblNothing
        '
        Me.lblNothing.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNothing.BackColor = System.Drawing.SystemColors.Window
        Me.lblNothing.ForeColor = System.Drawing.Color.Maroon
        Me.lblNothing.Location = New System.Drawing.Point(13, 207)
        Me.lblNothing.Name = "lblNothing"
        Me.lblNothing.Size = New System.Drawing.Size(766, 188)
        Me.lblNothing.TabIndex = 12
        Me.lblNothing.Text = "（未发现任何需要确认的激活撤销申请记录。）" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(No any requisition of activation cancellation found.)"
        Me.lblNothing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblNothing.Visible = False
        '
        'frmCancelMKTActivationValidation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(794, 528)
        Me.Controls.Add(Me.lblNothing)
        Me.Controls.Add(Me.lblSelected)
        Me.Controls.Add(Me.btnExcute)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cbbBatch)
        Me.Controls.Add(Me.lblDetails)
        Me.Controls.Add(Me.dgvDetails)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnHistory)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCancelMKTActivationValidation"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "活动卡激活撤销确认 Cancel Marketing Card Activation Validation"
        Me.cmenuDelete.ResumeLayout(False)
        CType(Me.dgvDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnHistory As System.Windows.Forms.Button
    Friend WithEvents cmenuDelete As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents menuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvDetails As System.Windows.Forms.DataGridView
    Friend WithEvents lblDetails As System.Windows.Forms.Label
    Friend WithEvents cbbBatch As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblAMT As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblQTY As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblPerson As System.Windows.Forms.Label
    Friend WithEvents lblStore As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblReason As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txbReason As System.Windows.Forms.TextBox
    Friend WithEvents rdbNotapprove As System.Windows.Forms.RadioButton
    Friend WithEvents rdbApprove As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExcute As System.Windows.Forms.Button
    Friend WithEvents lblSelected As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblNothing As System.Windows.Forms.Label
End Class
