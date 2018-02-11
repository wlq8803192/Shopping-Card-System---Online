<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArea
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmArea))
        Me.btnSave = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.trvArea = New System.Windows.Forms.TreeView
        Me.imlArea = New System.Windows.Forms.ImageList(Me.components)
        Me.txbCULStoreCode = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txbCULCardBin = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txbEnglishName = New System.Windows.Forms.TextBox
        Me.txbChineseName = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txbAreaCode = New System.Windows.Forms.TextBox
        Me.txbPreCode = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.grbArea = New System.Windows.Forms.GroupBox
        Me.grbCUL = New System.Windows.Forms.GroupBox
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnPaste = New System.Windows.Forms.Button
        Me.btnCut = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.theTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.promptTimer = New System.Windows.Forms.Timer(Me.components)
        Me.pnlEdit = New System.Windows.Forms.Panel
        Me.grbSchedule = New System.Windows.Forms.GroupBox
        Me.lblIsRollout = New System.Windows.Forms.Label
        Me.pnlIsRollout = New System.Windows.Forms.Panel
        Me.lblLockedTrainingMode2 = New System.Windows.Forms.Label
        Me.lblLockedTrainingMode1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.chbLockedTrainingMode = New System.Windows.Forms.CheckBox
        Me.txbRolloutDate = New System.Windows.Forms.TextBox
        Me.dtpRolloutDate = New System.Windows.Forms.DateTimePicker
        Me.chbIsRollout = New System.Windows.Forms.CheckBox
        Me.grbArea.SuspendLayout()
        Me.grbCUL.SuspendLayout()
        Me.pnlEdit.SuspendLayout()
        Me.grbSchedule.SuspendLayout()
        Me.pnlIsRollout.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(705, 469)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "保存 &Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(197, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "组织结构 Organization Structure:"
        '
        'trvArea
        '
        Me.trvArea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.trvArea.ImageIndex = 0
        Me.trvArea.ImageList = Me.imlArea
        Me.trvArea.ItemHeight = 18
        Me.trvArea.Location = New System.Drawing.Point(12, 28)
        Me.trvArea.Name = "trvArea"
        Me.trvArea.SelectedImageIndex = 0
        Me.trvArea.Size = New System.Drawing.Size(494, 429)
        Me.trvArea.TabIndex = 1
        '
        'imlArea
        '
        Me.imlArea.ImageStream = CType(resources.GetObject("imlArea.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlArea.TransparentColor = System.Drawing.Color.Transparent
        Me.imlArea.Images.SetKeyName(0, "H")
        Me.imlArea.Images.SetKeyName(1, "HR")
        Me.imlArea.Images.SetKeyName(2, "T")
        Me.imlArea.Images.SetKeyName(3, "TR")
        Me.imlArea.Images.SetKeyName(4, "R")
        Me.imlArea.Images.SetKeyName(5, "RC")
        Me.imlArea.Images.SetKeyName(6, "RR")
        Me.imlArea.Images.SetKeyName(7, "C")
        Me.imlArea.Images.SetKeyName(8, "CC")
        Me.imlArea.Images.SetKeyName(9, "CR")
        Me.imlArea.Images.SetKeyName(10, "S")
        Me.imlArea.Images.SetKeyName(11, "SC")
        Me.imlArea.Images.SetKeyName(12, "SR")
        '
        'txbCULStoreCode
        '
        Me.txbCULStoreCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txbCULStoreCode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbCULStoreCode.Location = New System.Drawing.Point(13, 93)
        Me.txbCULStoreCode.MaxLength = 15
        Me.txbCULStoreCode.Name = "txbCULStoreCode"
        Me.txbCULStoreCode.Size = New System.Drawing.Size(228, 21)
        Me.txbCULStoreCode.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(137, 12)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "银商卡Bin号 SC Number:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(11, 73)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(173, 12)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "银商门店编号 CUL Store Code:"
        '
        'txbCULCardBin
        '
        Me.txbCULCardBin.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbCULCardBin.Location = New System.Drawing.Point(12, 42)
        Me.txbCULCardBin.MaxLength = 5
        Me.txbCULCardBin.Name = "txbCULCardBin"
        Me.txbCULCardBin.Size = New System.Drawing.Size(229, 21)
        Me.txbCULCardBin.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(137, 12)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "英文名称 &English Name:"
        '
        'txbEnglishName
        '
        Me.txbEnglishName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txbEnglishName.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbEnglishName.Location = New System.Drawing.Point(14, 139)
        Me.txbEnglishName.MaxLength = 40
        Me.txbEnglishName.Name = "txbEnglishName"
        Me.txbEnglishName.Size = New System.Drawing.Size(229, 21)
        Me.txbEnglishName.TabIndex = 6
        '
        'txbChineseName
        '
        Me.txbChineseName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txbChineseName.Location = New System.Drawing.Point(14, 90)
        Me.txbChineseName.MaxLength = 40
        Me.txbChineseName.Name = "txbChineseName"
        Me.txbChineseName.Size = New System.Drawing.Size(229, 21)
        Me.txbChineseName.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(137, 12)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "中文名称 C&hinese Name:"
        '
        'txbAreaCode
        '
        Me.txbAreaCode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txbAreaCode.Location = New System.Drawing.Point(33, 41)
        Me.txbAreaCode.MaxLength = 3
        Me.txbAreaCode.Name = "txbAreaCode"
        Me.txbAreaCode.Size = New System.Drawing.Size(210, 21)
        Me.txbAreaCode.TabIndex = 1
        '
        'txbPreCode
        '
        Me.txbPreCode.Location = New System.Drawing.Point(14, 41)
        Me.txbPreCode.MaxLength = 1
        Me.txbPreCode.Name = "txbPreCode"
        Me.txbPreCode.ReadOnly = True
        Me.txbPreCode.Size = New System.Drawing.Size(14, 21)
        Me.txbPreCode.TabIndex = 2
        Me.txbPreCode.TabStop = False
        Me.txbPreCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 12)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "区域编号 Area C&ode:"
        '
        'grbArea
        '
        Me.grbArea.Controls.Add(Me.Label3)
        Me.grbArea.Controls.Add(Me.Label5)
        Me.grbArea.Controls.Add(Me.txbPreCode)
        Me.grbArea.Controls.Add(Me.txbEnglishName)
        Me.grbArea.Controls.Add(Me.Label4)
        Me.grbArea.Controls.Add(Me.txbChineseName)
        Me.grbArea.Controls.Add(Me.txbAreaCode)
        Me.grbArea.Location = New System.Drawing.Point(520, 20)
        Me.grbArea.Name = "grbArea"
        Me.grbArea.Size = New System.Drawing.Size(257, 176)
        Me.grbArea.TabIndex = 3
        Me.grbArea.TabStop = False
        Me.grbArea.Text = "区域单元设置 Area Config:"
        '
        'grbCUL
        '
        Me.grbCUL.Controls.Add(Me.txbCULStoreCode)
        Me.grbCUL.Controls.Add(Me.Label10)
        Me.grbCUL.Controls.Add(Me.Label9)
        Me.grbCUL.Controls.Add(Me.txbCULCardBin)
        Me.grbCUL.Location = New System.Drawing.Point(520, 325)
        Me.grbCUL.Name = "grbCUL"
        Me.grbCUL.Size = New System.Drawing.Size(257, 132)
        Me.grbCUL.TabIndex = 5
        Me.grbCUL.TabStop = False
        Me.grbCUL.Text = "银商信息设置 CUL Info Config:"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(105, 6)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(90, 23)
        Me.btnDelete.TabIndex = 1
        Me.btnDelete.Text = "删除 &Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnPaste
        '
        Me.btnPaste.Location = New System.Drawing.Point(297, 6)
        Me.btnPaste.Name = "btnPaste"
        Me.btnPaste.Size = New System.Drawing.Size(90, 23)
        Me.btnPaste.TabIndex = 3
        Me.btnPaste.Text = "粘贴 &Paste"
        Me.btnPaste.UseVisualStyleBackColor = True
        '
        'btnCut
        '
        Me.btnCut.Location = New System.Drawing.Point(201, 6)
        Me.btnCut.Name = "btnCut"
        Me.btnCut.Size = New System.Drawing.Size(90, 23)
        Me.btnCut.TabIndex = 2
        Me.btnCut.Text = "剪切 &Cut"
        Me.btnCut.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(9, 6)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(90, 23)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Tag = " "
        Me.btnAdd.Text = "增加 &Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'promptTimer
        '
        Me.promptTimer.Interval = 500
        '
        'pnlEdit
        '
        Me.pnlEdit.Controls.Add(Me.btnPaste)
        Me.pnlEdit.Controls.Add(Me.btnDelete)
        Me.pnlEdit.Controls.Add(Me.btnCut)
        Me.pnlEdit.Controls.Add(Me.btnAdd)
        Me.pnlEdit.Location = New System.Drawing.Point(1, 463)
        Me.pnlEdit.Name = "pnlEdit"
        Me.pnlEdit.Size = New System.Drawing.Size(396, 35)
        Me.pnlEdit.TabIndex = 2
        '
        'grbSchedule
        '
        Me.grbSchedule.Controls.Add(Me.lblIsRollout)
        Me.grbSchedule.Controls.Add(Me.pnlIsRollout)
        Me.grbSchedule.Controls.Add(Me.chbIsRollout)
        Me.grbSchedule.Location = New System.Drawing.Point(520, 202)
        Me.grbSchedule.Name = "grbSchedule"
        Me.grbSchedule.Size = New System.Drawing.Size(257, 117)
        Me.grbSchedule.TabIndex = 4
        Me.grbSchedule.TabStop = False
        Me.grbSchedule.Text = "上线计划 Rollout Schedule:"
        '
        'lblIsRollout
        '
        Me.lblIsRollout.AutoSize = True
        Me.lblIsRollout.Location = New System.Drawing.Point(28, 22)
        Me.lblIsRollout.Name = "lblIsRollout"
        Me.lblIsRollout.Size = New System.Drawing.Size(173, 12)
        Me.lblIsRollout.TabIndex = 1
        Me.lblIsRollout.Text = "在下面日期起上线 Rollout at:"
        '
        'pnlIsRollout
        '
        Me.pnlIsRollout.Controls.Add(Me.lblLockedTrainingMode2)
        Me.pnlIsRollout.Controls.Add(Me.lblLockedTrainingMode1)
        Me.pnlIsRollout.Controls.Add(Me.Label2)
        Me.pnlIsRollout.Controls.Add(Me.chbLockedTrainingMode)
        Me.pnlIsRollout.Controls.Add(Me.txbRolloutDate)
        Me.pnlIsRollout.Controls.Add(Me.dtpRolloutDate)
        Me.pnlIsRollout.Location = New System.Drawing.Point(12, 43)
        Me.pnlIsRollout.Name = "pnlIsRollout"
        Me.pnlIsRollout.Size = New System.Drawing.Size(240, 66)
        Me.pnlIsRollout.TabIndex = 2
        '
        'lblLockedTrainingMode2
        '
        Me.lblLockedTrainingMode2.AutoSize = True
        Me.lblLockedTrainingMode2.Location = New System.Drawing.Point(34, 49)
        Me.lblLockedTrainingMode2.Name = "lblLockedTrainingMode2"
        Me.lblLockedTrainingMode2.Size = New System.Drawing.Size(203, 12)
        Me.lblLockedTrainingMode2.TabIndex = 5
        Me.lblLockedTrainingMode2.Text = "Block Training Mode after rollout"
        '
        'lblLockedTrainingMode1
        '
        Me.lblLockedTrainingMode1.AutoSize = True
        Me.lblLockedTrainingMode1.Location = New System.Drawing.Point(33, 34)
        Me.lblLockedTrainingMode1.Name = "lblLockedTrainingMode1"
        Me.lblLockedTrainingMode1.Size = New System.Drawing.Size(113, 12)
        Me.lblLockedTrainingMode1.TabIndex = 4
        Me.lblLockedTrainingMode1.Text = "上线后锁住培训模式"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "日期 Date:"
        '
        'chbLockedTrainingMode
        '
        Me.chbLockedTrainingMode.AutoSize = True
        Me.chbLockedTrainingMode.Location = New System.Drawing.Point(18, 41)
        Me.chbLockedTrainingMode.Name = "chbLockedTrainingMode"
        Me.chbLockedTrainingMode.Size = New System.Drawing.Size(15, 14)
        Me.chbLockedTrainingMode.TabIndex = 3
        Me.chbLockedTrainingMode.UseVisualStyleBackColor = True
        '
        'txbRolloutDate
        '
        Me.txbRolloutDate.Location = New System.Drawing.Point(86, 3)
        Me.txbRolloutDate.Name = "txbRolloutDate"
        Me.txbRolloutDate.ReadOnly = True
        Me.txbRolloutDate.Size = New System.Drawing.Size(88, 21)
        Me.txbRolloutDate.TabIndex = 2
        Me.txbRolloutDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dtpRolloutDate
        '
        Me.dtpRolloutDate.CustomFormat = "yyyy/MM/dd"
        Me.dtpRolloutDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpRolloutDate.Location = New System.Drawing.Point(86, 3)
        Me.dtpRolloutDate.Name = "dtpRolloutDate"
        Me.dtpRolloutDate.Size = New System.Drawing.Size(88, 21)
        Me.dtpRolloutDate.TabIndex = 1
        '
        'chbIsRollout
        '
        Me.chbIsRollout.AutoSize = True
        Me.chbIsRollout.Location = New System.Drawing.Point(12, 22)
        Me.chbIsRollout.Name = "chbIsRollout"
        Me.chbIsRollout.Size = New System.Drawing.Size(15, 14)
        Me.chbIsRollout.TabIndex = 0
        Me.chbIsRollout.UseVisualStyleBackColor = True
        '
        'frmArea
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 506)
        Me.Controls.Add(Me.grbSchedule)
        Me.Controls.Add(Me.pnlEdit)
        Me.Controls.Add(Me.grbCUL)
        Me.Controls.Add(Me.grbArea)
        Me.Controls.Add(Me.trvArea)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSave)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmArea"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "区域管理 Location Management"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.grbArea.ResumeLayout(False)
        Me.grbArea.PerformLayout()
        Me.grbCUL.ResumeLayout(False)
        Me.grbCUL.PerformLayout()
        Me.pnlEdit.ResumeLayout(False)
        Me.grbSchedule.ResumeLayout(False)
        Me.grbSchedule.PerformLayout()
        Me.pnlIsRollout.ResumeLayout(False)
        Me.pnlIsRollout.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents trvArea As System.Windows.Forms.TreeView
    Friend WithEvents txbCULStoreCode As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txbCULCardBin As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txbEnglishName As System.Windows.Forms.TextBox
    Friend WithEvents txbChineseName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txbAreaCode As System.Windows.Forms.TextBox
    Friend WithEvents txbPreCode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grbArea As System.Windows.Forms.GroupBox
    Friend WithEvents grbCUL As System.Windows.Forms.GroupBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnPaste As System.Windows.Forms.Button
    Friend WithEvents btnCut As System.Windows.Forms.Button
    Friend WithEvents imlArea As System.Windows.Forms.ImageList
    Friend WithEvents theTip As System.Windows.Forms.ToolTip
    Friend WithEvents promptTimer As System.Windows.Forms.Timer
    Friend WithEvents pnlEdit As System.Windows.Forms.Panel
    Friend WithEvents grbSchedule As System.Windows.Forms.GroupBox
    Friend WithEvents pnlIsRollout As System.Windows.Forms.Panel
    Friend WithEvents dtpRolloutDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents chbIsRollout As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chbLockedTrainingMode As System.Windows.Forms.CheckBox
    Friend WithEvents lblLockedTrainingMode2 As System.Windows.Forms.Label
    Friend WithEvents lblLockedTrainingMode1 As System.Windows.Forms.Label
    Friend WithEvents lblIsRollout As System.Windows.Forms.Label
    Friend WithEvents txbRolloutDate As System.Windows.Forms.TextBox
End Class
