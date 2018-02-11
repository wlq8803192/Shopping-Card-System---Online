<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSignCardSpecialOperation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSignCardSpecialOperation))
        Me.dgvCardInfo = New System.Windows.Forms.DataGridView
        Me.btnQuit = New System.Windows.Forms.Button
        Me.txtHolderIdNo = New System.Windows.Forms.TextBox
        Me.btnQuery = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnSave = New System.Windows.Forms.Button
        Me.txtMobile = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.radioFemale = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.radioMale = New System.Windows.Forms.RadioButton
        Me.txtName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        CType(Me.dgvCardInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvCardInfo
        '
        Me.dgvCardInfo.AllowUserToAddRows = False
        Me.dgvCardInfo.AllowUserToDeleteRows = False
        Me.dgvCardInfo.AllowUserToResizeRows = False
        Me.dgvCardInfo.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvCardInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCardInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCardInfo.Location = New System.Drawing.Point(12, 91)
        Me.dgvCardInfo.MultiSelect = False
        Me.dgvCardInfo.Name = "dgvCardInfo"
        Me.dgvCardInfo.RowHeadersWidth = 25
        Me.dgvCardInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvCardInfo.Size = New System.Drawing.Size(947, 195)
        Me.dgvCardInfo.TabIndex = 0
        '
        'btnQuit
        '
        Me.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnQuit.Location = New System.Drawing.Point(884, 301)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(75, 23)
        Me.btnQuit.TabIndex = 7
        Me.btnQuit.Text = "退出(&C)"
        Me.btnQuit.UseVisualStyleBackColor = True
        '
        'txtHolderIdNo
        '
        Me.txtHolderIdNo.Location = New System.Drawing.Point(75, 22)
        Me.txtHolderIdNo.MaxLength = 18
        Me.txtHolderIdNo.Name = "txtHolderIdNo"
        Me.txtHolderIdNo.Size = New System.Drawing.Size(122, 20)
        Me.txtHolderIdNo.TabIndex = 0
        '
        'btnQuery
        '
        Me.btnQuery.Location = New System.Drawing.Point(214, 20)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(75, 23)
        Me.btnQuery.TabIndex = 1
        Me.btnQuery.Text = "查询(&Q)"
        Me.btnQuery.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.txtMobile)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.radioFemale)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.radioMale)
        Me.GroupBox1.Controls.Add(Me.txtHolderIdNo)
        Me.GroupBox1.Controls.Add(Me.btnQuery)
        Me.GroupBox1.Controls.Add(Me.txtName)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(947, 58)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "个人信息"
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(859, 20)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "保存(&S)"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtMobile
        '
        Me.txtMobile.Enabled = False
        Me.txtMobile.Location = New System.Drawing.Point(715, 22)
        Me.txtMobile.MaxLength = 11
        Me.txtMobile.Name = "txtMobile"
        Me.txtMobile.Size = New System.Drawing.Size(81, 20)
        Me.txtMobile.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(668, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "手机："
        '
        'radioFemale
        '
        Me.radioFemale.AutoSize = True
        Me.radioFemale.Enabled = False
        Me.radioFemale.Location = New System.Drawing.Point(604, 23)
        Me.radioFemale.Name = "radioFemale"
        Me.radioFemale.Size = New System.Drawing.Size(37, 17)
        Me.radioFemale.TabIndex = 4
        Me.radioFemale.TabStop = True
        Me.radioFemale.Text = "女"
        Me.radioFemale.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Tag = ""
        Me.Label1.Text = "身份证："
        '
        'radioMale
        '
        Me.radioMale.AutoSize = True
        Me.radioMale.Enabled = False
        Me.radioMale.Location = New System.Drawing.Point(564, 23)
        Me.radioMale.Name = "radioMale"
        Me.radioMale.Size = New System.Drawing.Size(37, 17)
        Me.radioMale.TabIndex = 3
        Me.radioMale.TabStop = True
        Me.radioMale.Text = "男"
        Me.radioMale.UseVisualStyleBackColor = True
        '
        'txtName
        '
        Me.txtName.Enabled = False
        Me.txtName.Location = New System.Drawing.Point(375, 22)
        Me.txtName.MaxLength = 20
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(112, 20)
        Me.txtName.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(524, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "性别："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(323, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "姓名："
        '
        'frmSignCardSpecialOperation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnQuit
        Me.ClientSize = New System.Drawing.Size(971, 334)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.dgvCardInfo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSignCardSpecialOperation"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "实名制卡特殊操作"
        CType(Me.dgvCardInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvCardInfo As System.Windows.Forms.DataGridView
    Friend WithEvents btnQuit As System.Windows.Forms.Button
    Friend WithEvents txtHolderIdNo As System.Windows.Forms.TextBox
    Friend WithEvents btnQuery As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents radioFemale As System.Windows.Forms.RadioButton
    Friend WithEvents radioMale As System.Windows.Forms.RadioButton
    Friend WithEvents txtMobile As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
End Class
