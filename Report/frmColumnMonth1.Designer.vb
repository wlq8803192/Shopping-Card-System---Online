<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmColumnMonth1
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
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.tbRepBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsRepColumnMonth1 = New ShoppingCardSystem.dsRepColumnMonth1
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cbx_year = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cb_query = New System.Windows.Forms.Button
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.txtArea = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnSelect = New System.Windows.Forms.Button
        CType(Me.tbRepBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsRepColumnMonth1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbRepBindingSource
        '
        Me.tbRepBindingSource.DataMember = "tbRep"
        Me.tbRepBindingSource.DataSource = Me.dsRepColumnMonth1
        '
        'dsRepColumnMonth1
        '
        Me.dsRepColumnMonth1.DataSetName = "dsRepColumnMonth1"
        Me.dsRepColumnMonth1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtArea)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.btnSelect)
        Me.Panel1.Controls.Add(Me.cbx_year)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cb_query)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(729, 61)
        Me.Panel1.TabIndex = 3
        '
        'cbx_year
        '
        Me.cbx_year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_year.FormattingEnabled = True
        Me.cbx_year.Items.AddRange(New Object() {"2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018", "2019", "2020", "2021"})
        Me.cbx_year.Location = New System.Drawing.Point(223, 31)
        Me.cbx_year.Name = "cbx_year"
        Me.cbx_year.Size = New System.Drawing.Size(121, 21)
        Me.cbx_year.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(135, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Year (年):"
        '
        'cb_query
        '
        Me.cb_query.Location = New System.Drawing.Point(360, 31)
        Me.cb_query.Name = "cb_query"
        Me.cb_query.Size = New System.Drawing.Size(160, 23)
        Me.cb_query.TabIndex = 0
        Me.cb_query.Text = "Query (查询)"
        Me.cb_query.UseVisualStyleBackColor = True
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource2.Name = "dsRepColumnMonth1_tbRep"
        ReportDataSource2.Value = Me.tbRepBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "ShoppingCardSystem.repColumnMonth1.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 61)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(729, 342)
        Me.ReportViewer1.TabIndex = 4
        '
        'txtArea
        '
        Me.txtArea.Enabled = False
        Me.txtArea.Location = New System.Drawing.Point(223, 5)
        Me.txtArea.Name = "txtArea"
        Me.txtArea.Size = New System.Drawing.Size(297, 20)
        Me.txtArea.TabIndex = 25
        Me.txtArea.Text = "All(不指定区域)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(215, 12)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Please select area(请选择查询范围):"
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(522, 3)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(144, 23)
        Me.btnSelect.TabIndex = 23
        Me.btnSelect.Text = "Select (选择查询区域)"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'frmColumnMonth1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(729, 403)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmColumnMonth1"
        Me.Text = "Yealy Report By Customer and Month"
        CType(Me.tbRepBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsRepColumnMonth1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cbx_year As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cb_query As System.Windows.Forms.Button
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents tbRepBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsRepColumnMonth1 As ShoppingCardSystem.dsRepColumnMonth1
    Friend WithEvents txtArea As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSelect As System.Windows.Forms.Button
End Class
