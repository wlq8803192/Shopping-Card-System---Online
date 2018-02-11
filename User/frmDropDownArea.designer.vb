<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDropDownArea
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDropDownArea))
        Me.trvArea = New System.Windows.Forms.TreeView
        Me.imlIcon = New System.Windows.Forms.ImageList(Me.components)
        Me.theTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'trvArea
        '
        Me.trvArea.AllowDrop = True
        Me.trvArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.trvArea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trvArea.ImageIndex = 0
        Me.trvArea.ImageList = Me.imlIcon
        Me.trvArea.ItemHeight = 18
        Me.trvArea.Location = New System.Drawing.Point(0, 0)
        Me.trvArea.Name = "trvArea"
        Me.trvArea.SelectedImageKey = "Family.ico"
        Me.trvArea.Size = New System.Drawing.Size(292, 266)
        Me.trvArea.TabIndex = 2
        '
        'imlIcon
        '
        Me.imlIcon.ImageStream = CType(resources.GetObject("imlIcon.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlIcon.TransparentColor = System.Drawing.Color.Transparent
        Me.imlIcon.Images.SetKeyName(0, "H")
        Me.imlIcon.Images.SetKeyName(1, "T")
        Me.imlIcon.Images.SetKeyName(2, "R")
        Me.imlIcon.Images.SetKeyName(3, "C")
        Me.imlIcon.Images.SetKeyName(4, "S")
        '
        'theTimer
        '
        Me.theTimer.Interval = 50
        '
        'frmDropDownArea
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.trvArea)
        Me.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDropDownArea"
        Me.ShowInTaskbar = False
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents trvArea As System.Windows.Forms.TreeView
    Friend WithEvents imlIcon As System.Windows.Forms.ImageList
    Friend WithEvents theTimer As System.Windows.Forms.Timer
End Class
