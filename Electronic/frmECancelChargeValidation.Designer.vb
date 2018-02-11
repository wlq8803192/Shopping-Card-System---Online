<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmECancelChargeValidation
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
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnExecute = New System.Windows.Forms.Button
        Me.lblGetBillResult = New System.Windows.Forms.Label
        Me.lblOrderNo = New System.Windows.Forms.Label
        Me.txtOrderNo = New System.Windows.Forms.TextBox
        Me.btnValidate = New System.Windows.Forms.Button
        Me.txtCity = New System.Windows.Forms.TextBox
        Me.lblCity = New System.Windows.Forms.Label
        Me.btnReturn = New System.Windows.Forms.Button
        Me.txtReason = New System.Windows.Forms.TextBox
        Me.lblReason = New System.Windows.Forms.Label
        Me.txtStore = New System.Windows.Forms.TextBox
        Me.txtRequestor = New System.Windows.Forms.TextBox
        Me.lblStore = New System.Windows.Forms.Label
        Me.lblRequestor = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtBillPayTotalAmount = New System.Windows.Forms.TextBox
        Me.txtBillTotalAmount = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblYHOrder = New System.Windows.Forms.Label
        Me.btnHistory = New System.Windows.Forms.Button
        CType(Me.dgvNormal, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.dgvNormal.Location = New System.Drawing.Point(13, 126)
        Me.dgvNormal.MultiSelect = False
        Me.dgvNormal.Name = "dgvNormal"
        Me.dgvNormal.RowTemplate.Height = 23
        Me.dgvNormal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvNormal.Size = New System.Drawing.Size(651, 276)
        Me.dgvNormal.TabIndex = 7
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(603, 490)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(61, 25)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "取消(&C)"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnExecute
        '
        Me.btnExecute.Location = New System.Drawing.Point(501, 490)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(84, 25)
        Me.btnExecute.TabIndex = 14
        Me.btnExecute.Text = "确认退卡(&S)"
        Me.btnExecute.UseVisualStyleBackColor = True
        '
        'lblGetBillResult
        '
        Me.lblGetBillResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGetBillResult.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblGetBillResult.Location = New System.Drawing.Point(13, 418)
        Me.lblGetBillResult.Name = "lblGetBillResult"
        Me.lblGetBillResult.Size = New System.Drawing.Size(651, 53)
        Me.lblGetBillResult.TabIndex = 30
        '
        'lblOrderNo
        '
        Me.lblOrderNo.AutoSize = True
        Me.lblOrderNo.Location = New System.Drawing.Point(37, 25)
        Me.lblOrderNo.Name = "lblOrderNo"
        Me.lblOrderNo.Size = New System.Drawing.Size(46, 13)
        Me.lblOrderNo.TabIndex = 33
        Me.lblOrderNo.Text = "订单号"
        '
        'txtOrderNo
        '
        Me.txtOrderNo.Location = New System.Drawing.Point(103, 22)
        Me.txtOrderNo.Name = "txtOrderNo"
        Me.txtOrderNo.Size = New System.Drawing.Size(194, 20)
        Me.txtOrderNo.TabIndex = 32
        '
        'btnValidate
        '
        Me.btnValidate.Location = New System.Drawing.Point(318, 20)
        Me.btnValidate.Name = "btnValidate"
        Me.btnValidate.Size = New System.Drawing.Size(61, 25)
        Me.btnValidate.TabIndex = 31
        Me.btnValidate.Text = "验证(&V)"
        Me.btnValidate.UseVisualStyleBackColor = True
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(103, 55)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(83, 20)
        Me.txtCity.TabIndex = 35
        '
        'lblCity
        '
        Me.lblCity.AutoSize = True
        Me.lblCity.Location = New System.Drawing.Point(31, 59)
        Me.lblCity.Name = "lblCity"
        Me.lblCity.Size = New System.Drawing.Size(55, 13)
        Me.lblCity.TabIndex = 34
        Me.lblCity.Text = "所属城市"
        '
        'btnReturn
        '
        Me.btnReturn.Location = New System.Drawing.Point(398, 490)
        Me.btnReturn.Name = "btnReturn"
        Me.btnReturn.Size = New System.Drawing.Size(84, 25)
        Me.btnReturn.TabIndex = 36
        Me.btnReturn.Text = "退回申请(&R)"
        Me.btnReturn.UseVisualStyleBackColor = True
        '
        'txtReason
        '
        Me.txtReason.Location = New System.Drawing.Point(429, 91)
        Me.txtReason.Name = "txtReason"
        Me.txtReason.Size = New System.Drawing.Size(235, 20)
        Me.txtReason.TabIndex = 38
        '
        'lblReason
        '
        Me.lblReason.AutoSize = True
        Me.lblReason.Location = New System.Drawing.Point(360, 94)
        Me.lblReason.Name = "lblReason"
        Me.lblReason.Size = New System.Drawing.Size(55, 13)
        Me.lblReason.TabIndex = 37
        Me.lblReason.Text = "撤销原因"
        '
        'txtStore
        '
        Me.txtStore.Location = New System.Drawing.Point(267, 55)
        Me.txtStore.Name = "txtStore"
        Me.txtStore.Size = New System.Drawing.Size(79, 20)
        Me.txtStore.TabIndex = 39
        '
        'txtRequestor
        '
        Me.txtRequestor.Location = New System.Drawing.Point(429, 55)
        Me.txtRequestor.Name = "txtRequestor"
        Me.txtRequestor.Size = New System.Drawing.Size(78, 20)
        Me.txtRequestor.TabIndex = 40
        '
        'lblStore
        '
        Me.lblStore.AutoSize = True
        Me.lblStore.Location = New System.Drawing.Point(198, 59)
        Me.lblStore.Name = "lblStore"
        Me.lblStore.Size = New System.Drawing.Size(55, 13)
        Me.lblStore.TabIndex = 41
        Me.lblStore.Text = "申请门店"
        '
        'lblRequestor
        '
        Me.lblRequestor.AutoSize = True
        Me.lblRequestor.Location = New System.Drawing.Point(372, 59)
        Me.lblRequestor.Name = "lblRequestor"
        Me.lblRequestor.Size = New System.Drawing.Size(43, 13)
        Me.lblRequestor.TabIndex = 42
        Me.lblRequestor.Text = "申请人"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "实际支付金额"
        '
        'txtBillPayTotalAmount
        '
        Me.txtBillPayTotalAmount.Location = New System.Drawing.Point(103, 88)
        Me.txtBillPayTotalAmount.Name = "txtBillPayTotalAmount"
        Me.txtBillPayTotalAmount.Size = New System.Drawing.Size(83, 20)
        Me.txtBillPayTotalAmount.TabIndex = 45
        '
        'txtBillTotalAmount
        '
        Me.txtBillTotalAmount.Location = New System.Drawing.Point(267, 91)
        Me.txtBillTotalAmount.Name = "txtBillTotalAmount"
        Me.txtBillTotalAmount.Size = New System.Drawing.Size(79, 20)
        Me.txtBillTotalAmount.TabIndex = 44
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(210, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "总面值"
        '
        'lblYHOrder
        '
        Me.lblYHOrder.AutoSize = True
        Me.lblYHOrder.Font = New System.Drawing.Font("SimSun", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblYHOrder.ForeColor = System.Drawing.Color.Red
        Me.lblYHOrder.Location = New System.Drawing.Point(395, 25)
        Me.lblYHOrder.Name = "lblYHOrder"
        Me.lblYHOrder.Size = New System.Drawing.Size(71, 15)
        Me.lblYHOrder.TabIndex = 47
        Me.lblYHOrder.Text = "优惠订单"
        '
        'btnHistory
        '
        Me.btnHistory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHistory.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnHistory.Location = New System.Drawing.Point(289, 491)
        Me.btnHistory.Name = "btnHistory"
        Me.btnHistory.Size = New System.Drawing.Size(90, 23)
        Me.btnHistory.TabIndex = 49
        Me.btnHistory.Text = "查看历史记录(&H)"
        Me.btnHistory.UseVisualStyleBackColor = True
        '
        'frmECancelChargeValidation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(676, 528)
        Me.Controls.Add(Me.btnHistory)
        Me.Controls.Add(Me.lblYHOrder)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtBillPayTotalAmount)
        Me.Controls.Add(Me.txtBillTotalAmount)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblRequestor)
        Me.Controls.Add(Me.lblStore)
        Me.Controls.Add(Me.txtRequestor)
        Me.Controls.Add(Me.txtStore)
        Me.Controls.Add(Me.txtReason)
        Me.Controls.Add(Me.lblReason)
        Me.Controls.Add(Me.btnReturn)
        Me.Controls.Add(Me.txtCity)
        Me.Controls.Add(Me.lblCity)
        Me.Controls.Add(Me.lblOrderNo)
        Me.Controls.Add(Me.txtOrderNo)
        Me.Controls.Add(Me.btnValidate)
        Me.Controls.Add(Me.lblGetBillResult)
        Me.Controls.Add(Me.btnExecute)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.dgvNormal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmECancelChargeValidation"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "卡友俱乐部电子卡退卡确认"
        CType(Me.dgvNormal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvNormal As System.Windows.Forms.DataGridView
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnExecute As System.Windows.Forms.Button
    Friend WithEvents lblGetBillResult As System.Windows.Forms.Label
    Friend WithEvents lblOrderNo As System.Windows.Forms.Label
    Friend WithEvents txtOrderNo As System.Windows.Forms.TextBox
    Friend WithEvents btnValidate As System.Windows.Forms.Button
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents lblCity As System.Windows.Forms.Label
    Friend WithEvents btnReturn As System.Windows.Forms.Button
    Friend WithEvents txtReason As System.Windows.Forms.TextBox
    Friend WithEvents lblReason As System.Windows.Forms.Label
    Friend WithEvents txtStore As System.Windows.Forms.TextBox
    Friend WithEvents txtRequestor As System.Windows.Forms.TextBox
    Friend WithEvents lblStore As System.Windows.Forms.Label
    Friend WithEvents lblRequestor As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBillPayTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtBillTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblYHOrder As System.Windows.Forms.Label
    Friend WithEvents btnHistory As System.Windows.Forms.Button
End Class
