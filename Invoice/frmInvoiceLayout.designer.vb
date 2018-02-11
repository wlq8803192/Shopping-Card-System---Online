<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInvoiceLayout
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInvoiceLayout))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnSave = New System.Windows.Forms.Button
        Me.cbbPrinter = New System.Windows.Forms.ComboBox
        Me.dgvInvoice = New System.Windows.Forms.DataGridView
        Me.btnPrintTest = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbbCity = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbbStore = New System.Windows.Forms.ComboBox
        Me.chbAllow = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        CType(Me.dgvInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(-5, 355)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(520, 4)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(416, 372)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "保存(&S)"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'cbbPrinter
        '
        Me.cbbPrinter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbbPrinter.FormattingEnabled = True
        Me.cbbPrinter.Location = New System.Drawing.Point(166, 374)
        Me.cbbPrinter.MaxDropDownItems = 20
        Me.cbbPrinter.Name = "cbbPrinter"
        Me.cbbPrinter.Size = New System.Drawing.Size(177, 20)
        Me.cbbPrinter.TabIndex = 10
        '
        'dgvInvoice
        '
        Me.dgvInvoice.AllowUserToAddRows = False
        Me.dgvInvoice.AllowUserToDeleteRows = False
        Me.dgvInvoice.AllowUserToResizeRows = False
        Me.dgvInvoice.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInvoice.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvInvoice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInvoice.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInvoice.ColumnHeadersHeight = 22
        Me.dgvInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvInvoice.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvInvoice.Location = New System.Drawing.Point(12, 55)
        Me.dgvInvoice.MultiSelect = False
        Me.dgvInvoice.Name = "dgvInvoice"
        Me.dgvInvoice.RowHeadersVisible = False
        Me.dgvInvoice.RowTemplate.Height = 24
        Me.dgvInvoice.Size = New System.Drawing.Size(479, 288)
        Me.dgvInvoice.StandardTab = True
        Me.dgvInvoice.TabIndex = 5
        '
        'btnPrintTest
        '
        Me.btnPrintTest.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrintTest.Location = New System.Drawing.Point(12, 372)
        Me.btnPrintTest.Name = "btnPrintTest"
        Me.btnPrintTest.Size = New System.Drawing.Size(97, 23)
        Me.btnPrintTest.TabIndex = 8
        Me.btnPrintTest.Text = "打印测试页(&T)"
        Me.btnPrintTest.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "城市(&I)："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(115, 377)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "打印机："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbbCity
        '
        Me.cbbCity.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbbCity.FormattingEnabled = True
        Me.cbbCity.Location = New System.Drawing.Point(69, 9)
        Me.cbbCity.MaxDropDownItems = 20
        Me.cbbCity.Name = "cbbCity"
        Me.cbbCity.Size = New System.Drawing.Size(177, 20)
        Me.cbbCity.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(256, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "门店(&E)："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbbStore
        '
        Me.cbbStore.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbbStore.FormattingEnabled = True
        Me.cbbStore.Location = New System.Drawing.Point(315, 9)
        Me.cbbStore.MaxDropDownItems = 20
        Me.cbbStore.Name = "cbbStore"
        Me.cbbStore.Size = New System.Drawing.Size(177, 20)
        Me.cbbStore.TabIndex = 3
        '
        'chbAllow
        '
        Me.chbAllow.AutoSize = True
        Me.chbAllow.Location = New System.Drawing.Point(360, 37)
        Me.chbAllow.Name = "chbAllow"
        Me.chbAllow.Size = New System.Drawing.Size(138, 16)
        Me.chbAllow.TabIndex = 6
        Me.chbAllow.Text = "允许门店自行调整(&R)"
        Me.chbAllow.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(209, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "请设置各打印项目的位置及其可见性："
        '
        'frmInvoiceLayout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(504, 407)
        Me.Controls.Add(Me.chbAllow)
        Me.Controls.Add(Me.cbbStore)
        Me.Controls.Add(Me.cbbCity)
        Me.Controls.Add(Me.cbbPrinter)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvInvoice)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnPrintTest)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInvoiceLayout"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "请为各门店设置发票版面："
        CType(Me.dgvInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents cbbPrinter As System.Windows.Forms.ComboBox
    Friend WithEvents dgvInvoice As System.Windows.Forms.DataGridView
    Friend WithEvents btnPrintTest As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbbCity As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbbStore As System.Windows.Forms.ComboBox
    Friend WithEvents chbAllow As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
