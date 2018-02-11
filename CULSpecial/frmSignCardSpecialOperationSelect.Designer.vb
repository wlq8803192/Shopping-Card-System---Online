<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSignCardSpecialOperationSelect
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
        Me.tlpList = New System.Windows.Forms.TableLayoutPanel
        Me.pnlSignCardSpecialOperation = New System.Windows.Forms.Panel
        Me.btnSignCardSpecialOperation = New System.Windows.Forms.Button
        Me.pnlSignCardReplace = New System.Windows.Forms.Panel
        Me.btnSignCardReplace = New System.Windows.Forms.Button
        Me.tlpList.SuspendLayout()
        Me.pnlSignCardSpecialOperation.SuspendLayout()
        Me.pnlSignCardReplace.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpList
        '
        Me.tlpList.AutoSize = True
        Me.tlpList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpList.ColumnCount = 1
        Me.tlpList.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpList.Controls.Add(Me.pnlSignCardSpecialOperation, 0, 13)
        Me.tlpList.Controls.Add(Me.pnlSignCardReplace, 0, 15)
        Me.tlpList.Location = New System.Drawing.Point(12, 12)
        Me.tlpList.Name = "tlpList"
        Me.tlpList.RowCount = 17
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.Size = New System.Drawing.Size(406, 60)
        Me.tlpList.TabIndex = 1
        '
        'pnlSignCardSpecialOperation
        '
        Me.pnlSignCardSpecialOperation.Controls.Add(Me.btnSignCardSpecialOperation)
        Me.pnlSignCardSpecialOperation.Location = New System.Drawing.Point(0, 0)
        Me.pnlSignCardSpecialOperation.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlSignCardSpecialOperation.Name = "pnlSignCardSpecialOperation"
        Me.pnlSignCardSpecialOperation.Size = New System.Drawing.Size(406, 30)
        Me.pnlSignCardSpecialOperation.TabIndex = 13
        Me.pnlSignCardSpecialOperation.Visible = False
        '
        'btnSignCardSpecialOperation
        '
        Me.btnSignCardSpecialOperation.Location = New System.Drawing.Point(5, 3)
        Me.btnSignCardSpecialOperation.Name = "btnSignCardSpecialOperation"
        Me.btnSignCardSpecialOperation.Size = New System.Drawing.Size(398, 23)
        Me.btnSignCardSpecialOperation.TabIndex = 0
        Me.btnSignCardSpecialOperation.Text = "实名制卡特殊操作"
        Me.btnSignCardSpecialOperation.UseVisualStyleBackColor = True
        '
        'pnlSignCardReplace
        '
        Me.pnlSignCardReplace.Controls.Add(Me.btnSignCardReplace)
        Me.pnlSignCardReplace.Location = New System.Drawing.Point(0, 30)
        Me.pnlSignCardReplace.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlSignCardReplace.Name = "pnlSignCardReplace"
        Me.pnlSignCardReplace.Size = New System.Drawing.Size(406, 30)
        Me.pnlSignCardReplace.TabIndex = 15
        Me.pnlSignCardReplace.Visible = False
        '
        'btnSignCardReplace
        '
        Me.btnSignCardReplace.Location = New System.Drawing.Point(5, 3)
        Me.btnSignCardReplace.Name = "btnSignCardReplace"
        Me.btnSignCardReplace.Size = New System.Drawing.Size(398, 23)
        Me.btnSignCardReplace.TabIndex = 0
        Me.btnSignCardReplace.Text = "实名制卡查询"
        Me.btnSignCardReplace.UseVisualStyleBackColor = True
        '
        'frmSignCardSpecialOperationSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(431, 83)
        Me.Controls.Add(Me.tlpList)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSignCardSpecialOperationSelect"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "实名制卡特殊操作"
        Me.tlpList.ResumeLayout(False)
        Me.pnlSignCardSpecialOperation.ResumeLayout(False)
        Me.pnlSignCardReplace.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tlpList As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlSignCardSpecialOperation As System.Windows.Forms.Panel
    Friend WithEvents btnSignCardSpecialOperation As System.Windows.Forms.Button
    Friend WithEvents pnlSignCardReplace As System.Windows.Forms.Panel
    Friend WithEvents btnSignCardReplace As System.Windows.Forms.Button
End Class
