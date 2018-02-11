<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmECancelChargeRequirement
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
        Me.dgvNormal = New System.Windows.Forms.DataGridView
        Me.lblOrderNo = New System.Windows.Forms.Label
        Me.txtOrderNo = New System.Windows.Forms.TextBox
        Me.btnValidate = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnExecute = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtBillTotalAmount = New System.Windows.Forms.TextBox
        Me.txtBillPayTotalAmount = New System.Windows.Forms.TextBox
        Me.grbCustom = New System.Windows.Forms.GroupBox
        Me.lblGetBillResult = New System.Windows.Forms.Label
        Me.lblReason = New System.Windows.Forms.Label
        Me.txtReason = New System.Windows.Forms.TextBox
        Me.lblCity = New System.Windows.Forms.Label
        Me.txtCity = New System.Windows.Forms.TextBox
        Me.lblYHOrder = New System.Windows.Forms.Label
        CType(Me.dgvNormal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbCustom.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvNormal
        '
        Me.dgvNormal.AllowUserToAddRows = False
        Me.dgvNormal.AllowUserToDeleteRows = False
        Me.dgvNormal.AllowUserToResizeRows = False
        Me.dgvNormal.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvNormal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvNormal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNormal.Location = New System.Drawing.Point(12, 167)
        Me.dgvNormal.MultiSelect = False
        Me.dgvNormal.Name = "dgvNormal"
        Me.dgvNormal.RowTemplate.Height = 23
        Me.dgvNormal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvNormal.Size = New System.Drawing.Size(652, 239)
        Me.dgvNormal.TabIndex = 6
        '
        'lblOrderNo
        '
        Me.lblOrderNo.AutoSize = True
        Me.lblOrderNo.Location = New System.Drawing.Point(37, 25)
        Me.lblOrderNo.Name = "lblOrderNo"
        Me.lblOrderNo.Size = New System.Drawing.Size(46, 13)
        Me.lblOrderNo.TabIndex = 8
        Me.lblOrderNo.Text = "订单号"
        '
        'txtOrderNo
        '
        Me.txtOrderNo.Location = New System.Drawing.Point(103, 22)
        Me.txtOrderNo.Name = "txtOrderNo"
        Me.txtOrderNo.Size = New System.Drawing.Size(194, 20)
        Me.txtOrderNo.TabIndex = 7
        '
        'btnValidate
        '
        Me.btnValidate.Location = New System.Drawing.Point(318, 20)
        Me.btnValidate.Name = "btnValidate"
        Me.btnValidate.Size = New System.Drawing.Size(61, 25)
        Me.btnValidate.TabIndex = 5
        Me.btnValidate.Text = "验证(&V)"
        Me.btnValidate.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(284, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "总面值"
        '
        'btnExecute
        '
        Me.btnExecute.Location = New System.Drawing.Point(499, 490)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(84, 25)
        Me.btnExecute.TabIndex = 10
        Me.btnExecute.Text = "提交申请(&S)"
        Me.btnExecute.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(603, 490)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(61, 25)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "取消(&C)"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "实际支付金额"
        '
        'txtBillTotalAmount
        '
        Me.txtBillTotalAmount.Location = New System.Drawing.Point(341, 29)
        Me.txtBillTotalAmount.Name = "txtBillTotalAmount"
        Me.txtBillTotalAmount.Size = New System.Drawing.Size(143, 20)
        Me.txtBillTotalAmount.TabIndex = 23
        '
        'txtBillPayTotalAmount
        '
        Me.txtBillPayTotalAmount.Location = New System.Drawing.Point(91, 29)
        Me.txtBillPayTotalAmount.Name = "txtBillPayTotalAmount"
        Me.txtBillPayTotalAmount.Size = New System.Drawing.Size(151, 20)
        Me.txtBillPayTotalAmount.TabIndex = 25
        '
        'grbCustom
        '
        Me.grbCustom.Controls.Add(Me.Label1)
        Me.grbCustom.Controls.Add(Me.txtBillPayTotalAmount)
        Me.grbCustom.Controls.Add(Me.txtBillTotalAmount)
        Me.grbCustom.Controls.Add(Me.Label2)
        Me.grbCustom.Location = New System.Drawing.Point(12, 53)
        Me.grbCustom.Name = "grbCustom"
        Me.grbCustom.Size = New System.Drawing.Size(652, 66)
        Me.grbCustom.TabIndex = 27
        Me.grbCustom.TabStop = False
        Me.grbCustom.Text = "订单信息"
        '
        'lblGetBillResult
        '
        Me.lblGetBillResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGetBillResult.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblGetBillResult.Location = New System.Drawing.Point(12, 423)
        Me.lblGetBillResult.Name = "lblGetBillResult"
        Me.lblGetBillResult.Size = New System.Drawing.Size(652, 53)
        Me.lblGetBillResult.TabIndex = 29
        '
        'lblReason
        '
        Me.lblReason.AutoSize = True
        Me.lblReason.Location = New System.Drawing.Point(284, 135)
        Me.lblReason.Name = "lblReason"
        Me.lblReason.Size = New System.Drawing.Size(55, 13)
        Me.lblReason.TabIndex = 30
        Me.lblReason.Text = "撤销原因"
        '
        'txtReason
        '
        Me.txtReason.Location = New System.Drawing.Point(353, 132)
        Me.txtReason.Name = "txtReason"
        Me.txtReason.Size = New System.Drawing.Size(271, 20)
        Me.txtReason.TabIndex = 31
        '
        'lblCity
        '
        Me.lblCity.AutoSize = True
        Me.lblCity.Location = New System.Drawing.Point(31, 135)
        Me.lblCity.Name = "lblCity"
        Me.lblCity.Size = New System.Drawing.Size(55, 13)
        Me.lblCity.TabIndex = 32
        Me.lblCity.Text = "所属城市"
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(103, 132)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(143, 20)
        Me.txtCity.TabIndex = 26
        '
        'lblYHOrder
        '
        Me.lblYHOrder.AutoSize = True
        Me.lblYHOrder.Font = New System.Drawing.Font("SimSun", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblYHOrder.ForeColor = System.Drawing.Color.Red
        Me.lblYHOrder.Location = New System.Drawing.Point(395, 24)
        Me.lblYHOrder.Name = "lblYHOrder"
        Me.lblYHOrder.Size = New System.Drawing.Size(71, 15)
        Me.lblYHOrder.TabIndex = 33
        Me.lblYHOrder.Text = "优惠订单"
        '
        'frmECancelChargeRequirement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(676, 528)
        Me.Controls.Add(Me.lblYHOrder)
        Me.Controls.Add(Me.txtCity)
        Me.Controls.Add(Me.lblCity)
        Me.Controls.Add(Me.txtReason)
        Me.Controls.Add(Me.lblReason)
        Me.Controls.Add(Me.lblGetBillResult)
        Me.Controls.Add(Me.grbCustom)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnExecute)
        Me.Controls.Add(Me.dgvNormal)
        Me.Controls.Add(Me.lblOrderNo)
        Me.Controls.Add(Me.txtOrderNo)
        Me.Controls.Add(Me.btnValidate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmECancelChargeRequirement"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "卡友俱乐部电子卡退卡申请"
        CType(Me.dgvNormal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbCustom.ResumeLayout(False)
        Me.grbCustom.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvNormal As System.Windows.Forms.DataGridView
    Friend WithEvents lblOrderNo As System.Windows.Forms.Label
    Friend WithEvents txtOrderNo As System.Windows.Forms.TextBox
    Friend WithEvents btnValidate As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnExecute As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBillTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtBillPayTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents grbCustom As System.Windows.Forms.GroupBox
    Friend WithEvents lblGetBillResult As System.Windows.Forms.Label
    Friend WithEvents lblReason As System.Windows.Forms.Label
    Friend WithEvents txtReason As System.Windows.Forms.TextBox
    Friend WithEvents lblCity As System.Windows.Forms.Label
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents lblYHOrder As System.Windows.Forms.Label
End Class
