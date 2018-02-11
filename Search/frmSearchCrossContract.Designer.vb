<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchCrossContract
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
        'components = New System.ComponentModel.Container
        'Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        'Me.Text = "frmSearchCrossContract"

        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSearchContract))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.rdbByContractCode = New System.Windows.Forms.RadioButton
        Me.pnlByContractCode = New System.Windows.Forms.Panel
        Me.txbContractCode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.rdbByCustomerName = New System.Windows.Forms.RadioButton
        Me.pnlByCustomerName = New System.Windows.Forms.Panel
        Me.txbCustomerName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.pnlByContractCode.SuspendLayout()
        Me.pnlByCustomerName.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(-5, 152)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(386, 4)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(182, 169)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(85, 23)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "查找 &Search"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(273, 169)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(85, 23)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "取消 &Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'rdbByContractCode
        '
        Me.rdbByContractCode.AutoSize = True
        Me.rdbByContractCode.Location = New System.Drawing.Point(12, 12)
        Me.rdbByContractCode.Name = "rdbByContractCode"
        Me.rdbByContractCode.Size = New System.Drawing.Size(347, 16)
        Me.rdbByContractCode.TabIndex = 0
        Me.rdbByContractCode.Text = "通过合同编号查找合同 Search contract by Contract Code:"
        Me.rdbByContractCode.UseVisualStyleBackColor = True
        '
        'pnlByContractCode
        '
        Me.pnlByContractCode.Controls.Add(Me.txbContractCode)
        Me.pnlByContractCode.Controls.Add(Me.Label1)
        Me.pnlByContractCode.Enabled = False
        Me.pnlByContractCode.Location = New System.Drawing.Point(25, 34)
        Me.pnlByContractCode.Name = "pnlByContractCode"
        Me.pnlByContractCode.Size = New System.Drawing.Size(286, 42)
        Me.pnlByContractCode.TabIndex = 1
        '
        'txbContractCode
        '
        Me.txbContractCode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbContractCode.Location = New System.Drawing.Point(5, 17)
        Me.txbContractCode.MaxLength = 12
        Me.txbContractCode.Name = "txbContractCode"
        Me.txbContractCode.Size = New System.Drawing.Size(161, 21)
        Me.txbContractCode.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(257, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "请输入合同编号 Please input Contract Code:"
        '
        'rdbByCustomerName
        '
        Me.rdbByCustomerName.AutoSize = True
        Me.rdbByCustomerName.Checked = True
        Me.rdbByCustomerName.Location = New System.Drawing.Point(12, 82)
        Me.rdbByCustomerName.Name = "rdbByCustomerName"
        Me.rdbByCustomerName.Size = New System.Drawing.Size(347, 16)
        Me.rdbByCustomerName.TabIndex = 2
        Me.rdbByCustomerName.TabStop = True
        Me.rdbByCustomerName.Text = "通过客户名称查找合同 Search contract by Customer Name:"
        Me.rdbByCustomerName.UseVisualStyleBackColor = True
        '
        'pnlByCustomerName
        '
        Me.pnlByCustomerName.Controls.Add(Me.txbCustomerName)
        Me.pnlByCustomerName.Controls.Add(Me.Label2)
        Me.pnlByCustomerName.Location = New System.Drawing.Point(25, 104)
        Me.pnlByCustomerName.Name = "pnlByCustomerName"
        Me.pnlByCustomerName.Size = New System.Drawing.Size(286, 42)
        Me.pnlByCustomerName.TabIndex = 3
        '
        'txbCustomerName
        '
        Me.txbCustomerName.Location = New System.Drawing.Point(5, 17)
        Me.txbCustomerName.MaxLength = 20
        Me.txbCustomerName.Name = "txbCustomerName"
        Me.txbCustomerName.Size = New System.Drawing.Size(161, 21)
        Me.txbCustomerName.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(257, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "请输入客户名称 Please input Customer Name:"
        '
        'frmSearchContract
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(370, 204)
        Me.Controls.Add(Me.pnlByCustomerName)
        Me.Controls.Add(Me.pnlByContractCode)
        Me.Controls.Add(Me.rdbByCustomerName)
        Me.Controls.Add(Me.rdbByContractCode)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSearchContract"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "查找合同 Search Contract:"
        Me.pnlByContractCode.ResumeLayout(False)
        Me.pnlByContractCode.PerformLayout()
        Me.pnlByCustomerName.ResumeLayout(False)
        Me.pnlByCustomerName.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents rdbByContractCode As System.Windows.Forms.RadioButton
    Friend WithEvents pnlByContractCode As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txbContractCode As System.Windows.Forms.TextBox
    Friend WithEvents rdbByCustomerName As System.Windows.Forms.RadioButton
    Friend WithEvents pnlByCustomerName As System.Windows.Forms.Panel
    Friend WithEvents txbCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class

