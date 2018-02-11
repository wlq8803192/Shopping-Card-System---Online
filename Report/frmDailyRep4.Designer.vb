<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDailyRep4
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
        Me.components = New System.ComponentModel.Container
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDailyRep4))
        Me.tbRepBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsDailyRep4 = New ShoppingCardSystem.dsDailyRep4
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtArea = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnSelect = New System.Windows.Forms.Button
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.cb_query = New System.Windows.Forms.Button
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        CType(Me.tbRepBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsDailyRep4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbRepBindingSource
        '
        Me.tbRepBindingSource.DataMember = "tbRep"
        Me.tbRepBindingSource.DataSource = Me.dsDailyRep4
        '
        'dsDailyRep4
        '
        Me.dsDailyRep4.DataSetName = "dsDailyRep4"
        Me.dsDailyRep4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtArea)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.btnSelect)
        Me.Panel1.Controls.Add(Me.dtpFrom)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cb_query)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(815, 65)
        Me.Panel1.TabIndex = 2
        '
        'txtArea
        '
        Me.txtArea.Enabled = False
        Me.txtArea.Location = New System.Drawing.Point(224, 5)
        Me.txtArea.Name = "txtArea"
        Me.txtArea.Size = New System.Drawing.Size(297, 20)
        Me.txtArea.TabIndex = 16
        Me.txtArea.Text = "All(不指定区域)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(215, 12)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Please select area(请选择查询范围):"
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(523, 3)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(144, 23)
        Me.btnSelect.TabIndex = 14
        Me.btnSelect.Text = "Select (选择查询区域)"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'dtpFrom
        '
        Me.dtpFrom.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFrom.Location = New System.Drawing.Point(225, 33)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(296, 21)
        Me.dtpFrom.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(57, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(161, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Activated Date (激活日期):"
        '
        'cb_query
        '
        Me.cb_query.Location = New System.Drawing.Point(523, 32)
        Me.cb_query.Name = "cb_query"
        Me.cb_query.Size = New System.Drawing.Size(144, 23)
        Me.cb_query.TabIndex = 0
        Me.cb_query.Text = "Query (查询)"
        Me.cb_query.UseVisualStyleBackColor = True
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dsDailyRep4_tbRep"
        ReportDataSource1.Value = Me.tbRepBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "ShoppingCardSystem.repDailyRep4.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 65)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(815, 331)
        Me.ReportViewer1.TabIndex = 3
        '
        'frmDailyRep4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(815, 396)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDailyRep4"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Daily Report 4 For Territory Manager, Territory BC"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        CType(Me.tbRepBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsDailyRep4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cb_query As System.Windows.Forms.Button
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents tbRepBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsDailyRep4 As ShoppingCardSystem.dsDailyRep4
    Friend WithEvents txtArea As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSelect As System.Windows.Forms.Button
End Class
