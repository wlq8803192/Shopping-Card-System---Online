<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCardForMobile
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
        Me.btnClose = New System.Windows.Forms.Button
        Me.txtMobile = New System.Windows.Forms.TextBox
        Me.lblMobile = New System.Windows.Forms.Label
        Me.btnQuery = New System.Windows.Forms.Button
        Me.lblCardNo = New System.Windows.Forms.Label
        Me.txtCardNo = New System.Windows.Forms.TextBox
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
        Me.dgvElectronic.Location = New System.Drawing.Point(12, 66)
        Me.dgvElectronic.MultiSelect = False
        Me.dgvElectronic.Name = "dgvElectronic"
        Me.dgvElectronic.RowTemplate.Height = 23
        Me.dgvElectronic.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvElectronic.Size = New System.Drawing.Size(367, 323)
        Me.dgvElectronic.TabIndex = 2
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(304, 403)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "退出(&C)"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtMobile
        '
        Me.txtMobile.Location = New System.Drawing.Point(73, 10)
        Me.txtMobile.Name = "txtMobile"
        Me.txtMobile.Size = New System.Drawing.Size(164, 21)
        Me.txtMobile.TabIndex = 7
        '
        'lblMobile
        '
        Me.lblMobile.AutoSize = True
        Me.lblMobile.Location = New System.Drawing.Point(26, 15)
        Me.lblMobile.Name = "lblMobile"
        Me.lblMobile.Size = New System.Drawing.Size(29, 12)
        Me.lblMobile.TabIndex = 8
        Me.lblMobile.Text = "手机"
        '
        'btnQuery
        '
        Me.btnQuery.Location = New System.Drawing.Point(264, 35)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(75, 23)
        Me.btnQuery.TabIndex = 9
        Me.btnQuery.Text = "查询"
        Me.btnQuery.UseVisualStyleBackColor = True
        '
        'lblCardNo
        '
        Me.lblCardNo.AutoSize = True
        Me.lblCardNo.Location = New System.Drawing.Point(26, 40)
        Me.lblCardNo.Name = "lblCardNo"
        Me.lblCardNo.Size = New System.Drawing.Size(29, 12)
        Me.lblCardNo.TabIndex = 11
        Me.lblCardNo.Text = "卡号"
        '
        'txtCardNo
        '
        Me.txtCardNo.Location = New System.Drawing.Point(73, 37)
        Me.txtCardNo.Name = "txtCardNo"
        Me.txtCardNo.Size = New System.Drawing.Size(164, 21)
        Me.txtCardNo.TabIndex = 10
        '
        'frmCardForMobile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(391, 440)
        Me.Controls.Add(Me.lblCardNo)
        Me.Controls.Add(Me.txtCardNo)
        Me.Controls.Add(Me.btnQuery)
        Me.Controls.Add(Me.lblMobile)
        Me.Controls.Add(Me.txtMobile)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.dgvElectronic)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCardForMobile"
        Me.Padding = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "查看卡号明细 CardDetails"
        CType(Me.dgvElectronic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvElectronic As System.Windows.Forms.DataGridView
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents txtMobile As System.Windows.Forms.TextBox
    Friend WithEvents lblMobile As System.Windows.Forms.Label
    Friend WithEvents btnQuery As System.Windows.Forms.Button
    Friend WithEvents lblCardNo As System.Windows.Forms.Label
    Friend WithEvents txtCardNo As System.Windows.Forms.TextBox
End Class
