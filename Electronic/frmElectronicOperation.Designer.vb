<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmElectronicOperation
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
        Me.pnlRequirement = New System.Windows.Forms.Panel
        Me.btnRequirement = New System.Windows.Forms.Button
        Me.pnlSearch = New System.Windows.Forms.Panel
        Me.btnSearch = New System.Windows.Forms.Button
        Me.pnlActivationRequirement = New System.Windows.Forms.Panel
        Me.btnActivationRequirement = New System.Windows.Forms.Button
        Me.pnlActivationValidation = New System.Windows.Forms.Panel
        Me.btnActivationValidation = New System.Windows.Forms.Button
        Me.pnlFreezeCard = New System.Windows.Forms.Panel
        Me.btnFreezeCard = New System.Windows.Forms.Button
        Me.pnlSupplySms = New System.Windows.Forms.Panel
        Me.btnSupply = New System.Windows.Forms.Button
        Me.pnlElectronicCodeDelay = New System.Windows.Forms.Panel
        Me.btnElectronicCodeDelay = New System.Windows.Forms.Button
        Me.tlpList.SuspendLayout()
        Me.pnlRequirement.SuspendLayout()
        Me.pnlSearch.SuspendLayout()
        Me.pnlActivationRequirement.SuspendLayout()
        Me.pnlActivationValidation.SuspendLayout()
        Me.pnlFreezeCard.SuspendLayout()
        Me.pnlSupplySms.SuspendLayout()
        Me.pnlElectronicCodeDelay.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpList
        '
        Me.tlpList.AutoSize = True
        Me.tlpList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpList.ColumnCount = 1
        Me.tlpList.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpList.Controls.Add(Me.pnlRequirement, 0, 0)
        Me.tlpList.Controls.Add(Me.pnlSearch, 0, 1)
        Me.tlpList.Controls.Add(Me.pnlActivationRequirement, 0, 2)
        Me.tlpList.Controls.Add(Me.pnlActivationValidation, 0, 3)
        Me.tlpList.Controls.Add(Me.pnlFreezeCard, 0, 4)
        Me.tlpList.Controls.Add(Me.pnlSupplySms, 0, 5)
        Me.tlpList.Controls.Add(Me.pnlElectronicCodeDelay, 0, 6)
        Me.tlpList.Location = New System.Drawing.Point(12, 12)
        Me.tlpList.Name = "tlpList"
        Me.tlpList.RowCount = 7
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpList.Size = New System.Drawing.Size(406, 210)
        Me.tlpList.TabIndex = 1
        '
        'pnlRequirement
        '
        Me.pnlRequirement.Controls.Add(Me.btnRequirement)
        Me.pnlRequirement.Location = New System.Drawing.Point(0, 0)
        Me.pnlRequirement.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlRequirement.Name = "pnlRequirement"
        Me.pnlRequirement.Size = New System.Drawing.Size(406, 30)
        Me.pnlRequirement.TabIndex = 13
        Me.pnlRequirement.Visible = False
        '
        'btnRequirement
        '
        Me.btnRequirement.Location = New System.Drawing.Point(5, 3)
        Me.btnRequirement.Name = "btnRequirement"
        Me.btnRequirement.Size = New System.Drawing.Size(398, 23)
        Me.btnRequirement.TabIndex = 0
        Me.btnRequirement.Text = "电子卡团购申请 Electronic Card Requirement"
        Me.btnRequirement.UseVisualStyleBackColor = True
        '
        'pnlSearch
        '
        Me.pnlSearch.Controls.Add(Me.btnSearch)
        Me.pnlSearch.Location = New System.Drawing.Point(0, 30)
        Me.pnlSearch.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Size = New System.Drawing.Size(406, 30)
        Me.pnlSearch.TabIndex = 15
        Me.pnlSearch.Visible = False
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(5, 3)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(398, 23)
        Me.btnSearch.TabIndex = 0
        Me.btnSearch.Text = "电子卡销售单管理 Electronic Card Management"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'pnlActivationRequirement
        '
        Me.pnlActivationRequirement.Controls.Add(Me.btnActivationRequirement)
        Me.pnlActivationRequirement.Location = New System.Drawing.Point(0, 60)
        Me.pnlActivationRequirement.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlActivationRequirement.Name = "pnlActivationRequirement"
        Me.pnlActivationRequirement.Size = New System.Drawing.Size(406, 30)
        Me.pnlActivationRequirement.TabIndex = 15
        Me.pnlActivationRequirement.Visible = False
        '
        'btnActivationRequirement
        '
        Me.btnActivationRequirement.Location = New System.Drawing.Point(5, 3)
        Me.btnActivationRequirement.Name = "btnActivationRequirement"
        Me.btnActivationRequirement.Size = New System.Drawing.Size(398, 23)
        Me.btnActivationRequirement.TabIndex = 0
        Me.btnActivationRequirement.Text = "电子卡激活撤销申请 Card Activation Requirement"
        Me.btnActivationRequirement.UseVisualStyleBackColor = True
        '
        'pnlActivationValidation
        '
        Me.pnlActivationValidation.Controls.Add(Me.btnActivationValidation)
        Me.pnlActivationValidation.Location = New System.Drawing.Point(0, 90)
        Me.pnlActivationValidation.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlActivationValidation.Name = "pnlActivationValidation"
        Me.pnlActivationValidation.Size = New System.Drawing.Size(406, 30)
        Me.pnlActivationValidation.TabIndex = 15
        Me.pnlActivationValidation.Visible = False
        '
        'btnActivationValidation
        '
        Me.btnActivationValidation.Location = New System.Drawing.Point(5, 3)
        Me.btnActivationValidation.Name = "btnActivationValidation"
        Me.btnActivationValidation.Size = New System.Drawing.Size(398, 23)
        Me.btnActivationValidation.TabIndex = 0
        Me.btnActivationValidation.Text = "电子卡激活撤销确认 Card Activation Validation"
        Me.btnActivationValidation.UseVisualStyleBackColor = True
        '
        'pnlFreezeCard
        '
        Me.pnlFreezeCard.Controls.Add(Me.btnFreezeCard)
        Me.pnlFreezeCard.Location = New System.Drawing.Point(0, 120)
        Me.pnlFreezeCard.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlFreezeCard.Name = "pnlFreezeCard"
        Me.pnlFreezeCard.Size = New System.Drawing.Size(406, 30)
        Me.pnlFreezeCard.TabIndex = 15
        Me.pnlFreezeCard.Visible = False
        '
        'btnFreezeCard
        '
        Me.btnFreezeCard.Location = New System.Drawing.Point(5, 3)
        Me.btnFreezeCard.Name = "btnFreezeCard"
        Me.btnFreezeCard.Size = New System.Drawing.Size(398, 23)
        Me.btnFreezeCard.TabIndex = 0
        Me.btnFreezeCard.Text = "电子卡冻结/解冻 Freeze/UnFreeze Card"
        Me.btnFreezeCard.UseVisualStyleBackColor = True
        '
        'pnlSupplySms
        '
        Me.pnlSupplySms.Controls.Add(Me.btnSupply)
        Me.pnlSupplySms.Location = New System.Drawing.Point(0, 150)
        Me.pnlSupplySms.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlSupplySms.Name = "pnlSupplySms"
        Me.pnlSupplySms.Size = New System.Drawing.Size(406, 30)
        Me.pnlSupplySms.TabIndex = 15
        Me.pnlSupplySms.Visible = False
        '
        'btnSupply
        '
        Me.btnSupply.Location = New System.Drawing.Point(5, 3)
        Me.btnSupply.Name = "btnSupply"
        Me.btnSupply.Size = New System.Drawing.Size(398, 23)
        Me.btnSupply.TabIndex = 0
        Me.btnSupply.Text = "补发短信/补发邮件 Electronic Supply Sms/Email"
        Me.btnSupply.UseVisualStyleBackColor = True
        '
        'pnlElectronicCodeDelay
        '
        Me.pnlElectronicCodeDelay.Controls.Add(Me.btnElectronicCodeDelay)
        Me.pnlElectronicCodeDelay.Location = New System.Drawing.Point(0, 180)
        Me.pnlElectronicCodeDelay.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlElectronicCodeDelay.Name = "pnlElectronicCodeDelay"
        Me.pnlElectronicCodeDelay.Size = New System.Drawing.Size(406, 30)
        Me.pnlElectronicCodeDelay.TabIndex = 15
        Me.pnlElectronicCodeDelay.Visible = False
        '
        'btnElectronicCodeDelay
        '
        Me.btnElectronicCodeDelay.Location = New System.Drawing.Point(5, 3)
        Me.btnElectronicCodeDelay.Name = "btnElectronicCodeDelay"
        Me.btnElectronicCodeDelay.Size = New System.Drawing.Size(398, 23)
        Me.btnElectronicCodeDelay.TabIndex = 0
        Me.btnElectronicCodeDelay.Text = "短链接延期 Electronic Delay"
        Me.btnElectronicCodeDelay.UseVisualStyleBackColor = True
        '
        'frmElectronicOperation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(431, 237)
        Me.Controls.Add(Me.tlpList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmElectronicOperation"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "电子卡团购 Electronic Card"
        Me.tlpList.ResumeLayout(False)
        Me.pnlRequirement.ResumeLayout(False)
        Me.pnlSearch.ResumeLayout(False)
        Me.pnlActivationRequirement.ResumeLayout(False)
        Me.pnlActivationValidation.ResumeLayout(False)
        Me.pnlFreezeCard.ResumeLayout(False)
        Me.pnlSupplySms.ResumeLayout(False)
        Me.pnlElectronicCodeDelay.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tlpList As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlRequirement As System.Windows.Forms.Panel
    Friend WithEvents btnRequirement As System.Windows.Forms.Button
    Friend WithEvents pnlSearch As System.Windows.Forms.Panel
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents pnlActivationRequirement As System.Windows.Forms.Panel
    Friend WithEvents btnActivationRequirement As System.Windows.Forms.Button
    Friend WithEvents pnlActivationValidation As System.Windows.Forms.Panel
    Friend WithEvents btnActivationValidation As System.Windows.Forms.Button
    Friend WithEvents pnlFreezeCard As System.Windows.Forms.Panel
    Friend WithEvents btnFreezeCard As System.Windows.Forms.Button
    Friend WithEvents pnlSupplySms As System.Windows.Forms.Panel
    Friend WithEvents btnSupply As System.Windows.Forms.Button
    Friend WithEvents pnlElectronicCodeDelay As System.Windows.Forms.Panel
    Friend WithEvents btnElectronicCodeDelay As System.Windows.Forms.Button

End Class
