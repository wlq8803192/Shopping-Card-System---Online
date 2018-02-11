<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectBuyChannel
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboBuyChannel = New System.Windows.Forms.ComboBox
        Me.btnOk = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "购买渠道"
        '
        'cboBuyChannel
        '
        Me.cboBuyChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBuyChannel.FormattingEnabled = True
        Me.cboBuyChannel.Items.AddRange(New Object() {"支付宝/微信", "瑞泰"})
        Me.cboBuyChannel.Location = New System.Drawing.Point(75, 24)
        Me.cboBuyChannel.Name = "cboBuyChannel"
        Me.cboBuyChannel.Size = New System.Drawing.Size(121, 21)
        Me.cboBuyChannel.TabIndex = 1
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(212, 24)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(55, 23)
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "确定"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'frmSelectBuyChannel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 71)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.cboBuyChannel)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelectBuyChannel"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "选择购买渠道："
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboBuyChannel As System.Windows.Forms.ComboBox
    Friend WithEvents btnOk As System.Windows.Forms.Button
End Class
