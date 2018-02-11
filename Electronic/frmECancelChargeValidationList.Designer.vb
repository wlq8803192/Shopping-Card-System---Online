<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmECancelChargeValidationList
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
        Me.dgvElectronic = New System.Windows.Forms.DataGridView
        Me.lblNothing = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnHistory = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        CType(Me.dgvElectronic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvElectronic
        '
        Me.dgvElectronic.AllowUserToAddRows = False
        Me.dgvElectronic.AllowUserToDeleteRows = False
        Me.dgvElectronic.AllowUserToResizeRows = False
        Me.dgvElectronic.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvElectronic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvElectronic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvElectronic.Location = New System.Drawing.Point(12, 30)
        Me.dgvElectronic.MultiSelect = False
        Me.dgvElectronic.Name = "dgvElectronic"
        Me.dgvElectronic.RowTemplate.Height = 23
        Me.dgvElectronic.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvElectronic.Size = New System.Drawing.Size(795, 285)
        Me.dgvElectronic.TabIndex = 2
        '
        'lblNothing
        '
        Me.lblNothing.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNothing.BackColor = System.Drawing.SystemColors.Window
        Me.lblNothing.ForeColor = System.Drawing.Color.Maroon
        Me.lblNothing.Location = New System.Drawing.Point(18, 46)
        Me.lblNothing.Name = "lblNothing"
        Me.lblNothing.Size = New System.Drawing.Size(783, 255)
        Me.lblNothing.TabIndex = 11
        Me.lblNothing.Text = "（未发现任何需要确认的电子卡退卡申请记录。）"
        Me.lblNothing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblNothing.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(449, 12)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "请选择您要确认的电子卡退卡申请记录，然后选中下边列表中的""订单号""进行跳转："
        '
        'btnHistory
        '
        Me.btnHistory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHistory.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnHistory.Location = New System.Drawing.Point(627, 328)
        Me.btnHistory.Name = "btnHistory"
        Me.btnHistory.Size = New System.Drawing.Size(90, 23)
        Me.btnHistory.TabIndex = 14
        Me.btnHistory.Text = "查看历史记录(&H)"
        Me.btnHistory.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(732, 328)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 13
        Me.btnClose.Text = "退出(&C)"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmECancelChargeValidationList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(820, 362)
        Me.Controls.Add(Me.btnHistory)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblNothing)
        Me.Controls.Add(Me.dgvElectronic)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmECancelChargeValidationList"
        Me.Padding = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "卡友俱乐部电子卡退卡申请列表"
        CType(Me.dgvElectronic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvElectronic As System.Windows.Forms.DataGridView
    Friend WithEvents lblNothing As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnHistory As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button

End Class
