<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectEChannel
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
        Me.btnOk = New System.Windows.Forms.Button
        Me.rbChannel1 = New System.Windows.Forms.RadioButton
        Me.rbChannel2 = New System.Windows.Forms.RadioButton
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "购买渠道"
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(215, 22)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(55, 21)
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "确定"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'rbChannel1
        '
        Me.rbChannel1.AutoSize = True
        Me.rbChannel1.Location = New System.Drawing.Point(86, 13)
        Me.rbChannel1.Name = "rbChannel1"
        Me.rbChannel1.Size = New System.Drawing.Size(113, 16)
        Me.rbChannel1.TabIndex = 3
        Me.rbChannel1.TabStop = True
        Me.rbChannel1.Text = "线上-卡友俱乐部"
        Me.rbChannel1.UseVisualStyleBackColor = True
        '
        'rbChannel2
        '
        Me.rbChannel2.AutoSize = True
        Me.rbChannel2.Location = New System.Drawing.Point(86, 38)
        Me.rbChannel2.Name = "rbChannel2"
        Me.rbChannel2.Size = New System.Drawing.Size(113, 16)
        Me.rbChannel2.TabIndex = 4
        Me.rbChannel2.TabStop = True
        Me.rbChannel2.Text = "线下-购物卡系统"
        Me.rbChannel2.UseVisualStyleBackColor = True
        '
        'frmSelectEChannel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 66)
        Me.Controls.Add(Me.rbChannel2)
        Me.Controls.Add(Me.rbChannel1)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelectEChannel"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "选择购买渠道："
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents rbChannel1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbChannel2 As System.Windows.Forms.RadioButton
End Class
