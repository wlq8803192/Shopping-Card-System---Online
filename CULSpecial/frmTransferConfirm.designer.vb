<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransferConfirm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTransferConfirm))
        Me.dgvRequest = New System.Windows.Forms.DataGridView
        Me.OperationID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FromCard = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToCard = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RequestAMT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreateTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.statusMain = New System.Windows.Forms.StatusStrip
        Me.statusText = New System.Windows.Forms.ToolStripStatusLabel
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnConfirm = New System.Windows.Forms.Button
        CType(Me.dgvRequest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.statusMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvRequest
        '
        Me.dgvRequest.AllowUserToAddRows = False
        Me.dgvRequest.AllowUserToDeleteRows = False
        Me.dgvRequest.AllowUserToOrderColumns = True
        Me.dgvRequest.BackgroundColor = System.Drawing.Color.White
        Me.dgvRequest.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvRequest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRequest.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OperationID, Me.FromCard, Me.ToCard, Me.RequestAMT, Me.Column1, Me.CreateTime})
        Me.dgvRequest.Location = New System.Drawing.Point(4, 4)
        Me.dgvRequest.MultiSelect = False
        Me.dgvRequest.Name = "dgvRequest"
        Me.dgvRequest.ReadOnly = True
        Me.dgvRequest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRequest.Size = New System.Drawing.Size(603, 369)
        Me.dgvRequest.TabIndex = 48
        '
        'OperationID
        '
        Me.OperationID.DataPropertyName = "OperationID"
        Me.OperationID.HeaderText = "OperationID"
        Me.OperationID.Name = "OperationID"
        Me.OperationID.ReadOnly = True
        Me.OperationID.Visible = False
        '
        'FromCard
        '
        Me.FromCard.DataPropertyName = "startcard"
        Me.FromCard.HeaderText = "转出卡号"
        Me.FromCard.Name = "FromCard"
        Me.FromCard.ReadOnly = True
        Me.FromCard.Width = 130
        '
        'ToCard
        '
        Me.ToCard.DataPropertyName = "endcard"
        Me.ToCard.HeaderText = "转入卡号"
        Me.ToCard.Name = "ToCard"
        Me.ToCard.ReadOnly = True
        Me.ToCard.Width = 130
        '
        'RequestAMT
        '
        Me.RequestAMT.DataPropertyName = "RequestAMT"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.RequestAMT.DefaultCellStyle = DataGridViewCellStyle1
        Me.RequestAMT.HeaderText = "转账金额"
        Me.RequestAMT.Name = "RequestAMT"
        Me.RequestAMT.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "申请人"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'CreateTime
        '
        Me.CreateTime.DataPropertyName = "requestedtime"
        Me.CreateTime.HeaderText = "申请时间"
        Me.CreateTime.Name = "CreateTime"
        Me.CreateTime.ReadOnly = True
        '
        'statusMain
        '
        Me.statusMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusText})
        Me.statusMain.Location = New System.Drawing.Point(0, 380)
        Me.statusMain.Name = "statusMain"
        Me.statusMain.Size = New System.Drawing.Size(733, 22)
        Me.statusMain.TabIndex = 54
        '
        'statusText
        '
        Me.statusText.AutoSize = False
        Me.statusText.ForeColor = System.Drawing.Color.Red
        Me.statusText.Name = "statusText"
        Me.statusText.Size = New System.Drawing.Size(600, 17)
        Me.statusText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(627, 315)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(94, 23)
        Me.btnClose.TabIndex = 55
        Me.btnClose.Text = "退出(&X)"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnConfirm
        '
        Me.btnConfirm.Location = New System.Drawing.Point(627, 34)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(94, 23)
        Me.btnConfirm.TabIndex = 56
        Me.btnConfirm.Text = "确认转账"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'frmTransferConfirm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(733, 402)
        Me.Controls.Add(Me.btnConfirm)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.statusMain)
        Me.Controls.Add(Me.dgvRequest)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTransferConfirm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "转账确认"
        CType(Me.dgvRequest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.statusMain.ResumeLayout(False)
        Me.statusMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvRequest As System.Windows.Forms.DataGridView
    Friend WithEvents statusMain As System.Windows.Forms.StatusStrip
    Friend WithEvents statusText As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnConfirm As System.Windows.Forms.Button
    Friend WithEvents OperationID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FromCard As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToCard As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RequestAMT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreateTime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
