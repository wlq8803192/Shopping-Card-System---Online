<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJVReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJVReport))
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpActivatedDate = New System.Windows.Forms.DateTimePicker
        Me.btnJVReport1 = New System.Windows.Forms.Button
        Me.btnJVReport2 = New System.Windows.Forms.Button
        Me.lblStatus = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "请选择银商激活日期："
        '
        'dtpActivatedDate
        '
        Me.dtpActivatedDate.CustomFormat = "yyyy/MM/dd"
        Me.dtpActivatedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpActivatedDate.Location = New System.Drawing.Point(147, 21)
        Me.dtpActivatedDate.MinDate = New Date(2011, 1, 1, 0, 0, 0, 0)
        Me.dtpActivatedDate.Name = "dtpActivatedDate"
        Me.dtpActivatedDate.Size = New System.Drawing.Size(85, 21)
        Me.dtpActivatedDate.TabIndex = 3
        '
        'btnJVReport1
        '
        Me.btnJVReport1.Location = New System.Drawing.Point(21, 58)
        Me.btnJVReport1.Name = "btnJVReport1"
        Me.btnJVReport1.Size = New System.Drawing.Size(211, 23)
        Me.btnJVReport1.TabIndex = 4
        Me.btnJVReport1.Text = "按付款单销售日报表"
        Me.btnJVReport1.UseVisualStyleBackColor = True
        '
        'btnJVReport2
        '
        Me.btnJVReport2.Location = New System.Drawing.Point(21, 87)
        Me.btnJVReport2.Name = "btnJVReport2"
        Me.btnJVReport2.Size = New System.Drawing.Size(211, 23)
        Me.btnJVReport2.TabIndex = 4
        Me.btnJVReport2.Text = "折扣、退货、自购按店按日统计报表"
        Me.btnJVReport2.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblStatus.Location = New System.Drawing.Point(19, 123)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(149, 12)
        Me.lblStatus.TabIndex = 5
        Me.lblStatus.Text = "正在准备数据，请稍候……"
        Me.lblStatus.Visible = False
        '
        'frmJVReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(254, 149)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.btnJVReport2)
        Me.Controls.Add(Me.btnJVReport1)
        Me.Controls.Add(Me.dtpActivatedDate)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmJVReport"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "JV报表 Sales Reports"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpActivatedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnJVReport1 As System.Windows.Forms.Button
    Friend WithEvents btnJVReport2 As System.Windows.Forms.Button
    Friend WithEvents lblStatus As System.Windows.Forms.Label

End Class
