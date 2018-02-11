<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmECancelExtractingCodeHistory
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
        Me.dgvElectronic.Location = New System.Drawing.Point(12, 11)
        Me.dgvElectronic.MultiSelect = False
        Me.dgvElectronic.Name = "dgvElectronic"
        Me.dgvElectronic.RowTemplate.Height = 23
        Me.dgvElectronic.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvElectronic.Size = New System.Drawing.Size(966, 340)
        Me.dgvElectronic.TabIndex = 1
        '
        'lblNothing
        '
        Me.lblNothing.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNothing.BackColor = System.Drawing.SystemColors.Window
        Me.lblNothing.ForeColor = System.Drawing.Color.Maroon
        Me.lblNothing.Location = New System.Drawing.Point(18, 34)
        Me.lblNothing.Name = "lblNothing"
        Me.lblNothing.Size = New System.Drawing.Size(953, 294)
        Me.lblNothing.TabIndex = 13
        Me.lblNothing.Text = "（未发现任何提取码作废历史记录。）"
        Me.lblNothing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblNothing.Visible = False
        '
        'frmECancelExtractingCodeHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(990, 362)
        Me.Controls.Add(Me.lblNothing)
        Me.Controls.Add(Me.dgvElectronic)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmECancelExtractingCodeHistory"
        Me.Padding = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "提取码作废历史记录 ECode Cancel History"
        CType(Me.dgvElectronic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvElectronic As System.Windows.Forms.DataGridView
    Friend WithEvents lblNothing As System.Windows.Forms.Label

End Class
