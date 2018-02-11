Public Class frmCancelMKTActivationRequirement

    'modify code 014:
    'date;2014/3/10 
    'auther:Hyron bjy 
    'remark:激活撤销申请时，申请成功后冻结卡BUG

    Private bStep As Byte = 1, blStep1OK As Boolean = False, blStep2OK As Boolean = False, blStep3OK As Boolean = False, blStep4OK As Boolean = False, blStep5OK As Boolean = False, blCanBrowseSalesBill As Boolean = True
    Private blSkipDeal As Boolean = False, editingCardNo As TextBox, errorCell As DataGridViewCell, sErrorInfo As String = ""
    Private dvCULParameter As DataView, dtList1 As DataTable, dtList2 As DataTable, dtList3 As DataTable, dtList4 As DataTable

    Private Sub frmCancelMKTActivationRequirement_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Me.dgvList1.Visible AndAlso Not Me.dgvList1.ReadOnly Then
            Me.dgvList1.Focus()
            Me.dgvList1.Select()
            Me.dgvList1("StartCardNo", Me.dgvList1.RowCount - 1).Selected = True
            Me.dgvList1.BeginEdit(True)
        End If
    End Sub

    Private Sub frmCancelMKTActivationRequirement_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        dtList1.Dispose() : dtList1 = Nothing
        dtList2.Dispose() : dtList2 = Nothing
        dtList3.Dispose() : dtList3 = Nothing
        dtList4.Dispose() : dtList4 = Nothing
        Me.dgvList1.DataSource = Nothing
        Me.dgvList2.DataSource = Nothing
        Me.dgvList3.DataSource = Nothing
        Me.dgvList4.DataSource = Nothing
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub frmCancelMKTActivationRequirement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        blCanBrowseSalesBill = (frmMain.dtAllowedRight.Select("RightName='SalesBillBrowse'").Length > 0)

        dvCULParameter = frmMain.dtLoginStructure.Copy.DefaultView
        dvCULParameter.RowFilter = "AreaType='S'"
        dvCULParameter = dvCULParameter.ToTable(False, "AreaID", "CULCardBin", "CULStoreCode").DefaultView
        dvCULParameter.RowFilter = "CULCardBin Like '%|%'"
        For Each drCUL As DataRowView In dvCULParameter
            Dim saCardBins() As String = drCUL("CULCardBin").ToString.Split("|")
            For bIndex As Byte = 0 To saCardBins.Length - 1
                dvCULParameter.Table.Rows.Add(drCUL("AreaID"), saCardBins(bIndex), drCUL("CULStoreCode")).EndEdit()
            Next
        Next
        For Each drCUL As DataRow In dvCULParameter.Table.Select("CULCardBin Like '84%'")
            drCUL("CULCardBin") = "94" & drCUL("CULCardBin").ToString.Substring(2, 3)
        Next
        dvCULParameter.RowFilter = ""
        dvCULParameter.Table.AcceptChanges()

        dtList1 = New DataTable
        dtList1.Columns.Add("RowID", System.Type.GetType("System.Int16"))
        dtList1.Columns.Add("StartCardNo", System.Type.GetType("System.String"))
        dtList1.Columns.Add("EndCardNo", System.Type.GetType("System.String"))
        dtList1.Columns.Add("CardQTY", System.Type.GetType("System.Decimal"))

        dtList2 = New DataTable
        dtList2.Columns.Add("RowID", System.Type.GetType("System.Int16"))
        dtList2.Columns.Add("CardNo", System.Type.GetType("System.String"))
        dtList2.Columns.Add("CardState", System.Type.GetType("System.String"))
        dtList2.Columns.Add("Balance", System.Type.GetType("System.Decimal"))
        dtList2.Columns.Add("SalesBillCode", System.Type.GetType("System.String"))
        dtList2.Columns.Add("FaceValue", System.Type.GetType("System.Decimal"))
        dtList2.Columns.Add("CardType", System.Type.GetType("System.String"))
        dtList2.Columns.Add("StoreName", System.Type.GetType("System.String"))
        dtList2.Columns.Add("CheckResult", System.Type.GetType("System.String"))
        dtList2.Columns.Add("ResultReason", System.Type.GetType("System.String"))
        dtList2.Columns.Add("StoreID", System.Type.GetType("System.Int16"))
        dtList2.Columns.Add("SalesBillID", System.Type.GetType("System.Int32"))
        dtList2.Columns.Add("SalesBillDetailID", System.Type.GetType("System.Int32"))

        dtList3 = New DataTable
        dtList3.Columns.Add("RowID", System.Type.GetType("System.Int16"))
        dtList3.Columns.Add("CardNo", System.Type.GetType("System.String"))
        dtList3.Columns.Add("CardState", System.Type.GetType("System.String"))
        dtList3.Columns.Add("Balance", System.Type.GetType("System.Decimal"))
        dtList3.Columns.Add("SalesBillCode", System.Type.GetType("System.String"))
        dtList3.Columns.Add("FaceValue", System.Type.GetType("System.Decimal"))
        dtList3.Columns.Add("CardType", System.Type.GetType("System.String"))
        dtList3.Columns.Add("StoreName", System.Type.GetType("System.String"))
        dtList3.Columns.Add("Selected", System.Type.GetType("System.Boolean"))
        dtList3.Columns.Add("ResultReason", System.Type.GetType("System.String"))
        dtList3.Columns.Add("AvailableBalance", System.Type.GetType("System.Decimal"))
        dtList3.Columns.Add("StoreID", System.Type.GetType("System.Int16"))
        dtList3.Columns.Add("SalesBillID", System.Type.GetType("System.Int32"))
        dtList3.Columns.Add("SalesBillDetailID", System.Type.GetType("System.Int32"))

        dtList4 = New DataTable
        dtList4.Columns.Add("RowID", System.Type.GetType("System.Int16"))
        dtList4.Columns.Add("CardNo", System.Type.GetType("System.String"))
        dtList4.Columns.Add("CardState", System.Type.GetType("System.String"))
        dtList4.Columns.Add("Balance", System.Type.GetType("System.Decimal"))
        dtList4.Columns.Add("SalesBillCode", System.Type.GetType("System.String"))
        dtList4.Columns.Add("FaceValue", System.Type.GetType("System.Decimal"))
        dtList4.Columns.Add("CardType", System.Type.GetType("System.String"))
        dtList4.Columns.Add("StoreName", System.Type.GetType("System.String"))
        dtList4.Columns.Add("AddedResult", System.Type.GetType("System.String"))
        dtList4.Columns.Add("FailureReason", System.Type.GetType("System.String"))
        dtList4.Columns.Add("StoreID", System.Type.GetType("System.Int16"))
        dtList4.Columns.Add("SalesBillID", System.Type.GetType("System.Int32"))
        dtList4.Columns.Add("SalesBillDetailID", System.Type.GetType("System.Int32"))

        With Me.dgvList1
            .DataSource = dtList1
            With .Columns(0)
                .HeaderText = "行号"
                .Width = 40
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.BackColor = SystemColors.Control
                .DefaultCellStyle.ForeColor = SystemColors.ControlText
                .DefaultCellStyle.SelectionBackColor = SystemColors.Control
                .DefaultCellStyle.SelectionForeColor = SystemColors.ControlText
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
            End With
            With .Columns(1)
                .HeaderText = "开始卡号"
                .Width = 125
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(2)
                .HeaderText = "结束卡号"
                .Width = 125
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(3)
                .HeaderText = "数量"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Format = "#,0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
            End With

            For bColumn As Byte = 0 To dtList1.Columns.Count - 1
                .Columns(bColumn).Name = dtList1.Columns(bColumn).ColumnName
            Next
        End With

        With Me.dgvList2
            .DataSource = dtList2
            With .Columns(0)
                .HeaderText = "行号"
                .Width = 40
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.BackColor = SystemColors.Control
                .DefaultCellStyle.ForeColor = SystemColors.ControlText
                .DefaultCellStyle.SelectionBackColor = SystemColors.Control
                .DefaultCellStyle.SelectionForeColor = SystemColors.ControlText
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(1)
                .HeaderText = "卡号"
                .Width = 125
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(2)
                .HeaderText = "卡状态"
                .Width = 50
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(3)
                .HeaderText = "余额"
                .Width = 60
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            Dim linkColomn As New DataGridViewLinkColumn
            linkColomn.DataPropertyName = "SalesBillCode"
            .Columns.RemoveAt(4)
            .Columns.Insert(4, linkColomn)
            With .Columns(4)
                .HeaderText = "销售单号"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 90
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(5)
                .HeaderText = "面值"
                .Width = 60
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(6)
                .HeaderText = "卡类型"
                .Width = 50
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(7)
                .HeaderText = "售卖门店"
                .MinimumWidth = 65
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(8)
                .HeaderText = "检查结果"
                .Width = 65
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(9)
                .HeaderText = "不可撤销原因"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .Visible = False
            End With
            .Columns(10).Visible = False
            .Columns(11).Visible = False
            .Columns(12).Visible = False

            For bColumn As Byte = 0 To dtList2.Columns.Count - 1
                .Columns(bColumn).Name = dtList2.Columns(bColumn).ColumnName
            Next
        End With

        With Me.dgvList3
            .DataSource = dtList3
            With .Columns(0)
                .HeaderText = "行号"
                .Width = 40
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.BackColor = SystemColors.Control
                .DefaultCellStyle.ForeColor = SystemColors.ControlText
                .DefaultCellStyle.SelectionBackColor = SystemColors.Control
                .DefaultCellStyle.SelectionForeColor = SystemColors.ControlText
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(1)
                .HeaderText = "卡号"
                .Width = 125
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(2)
                .HeaderText = "卡状态"
                .Width = 50
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(3)
                .HeaderText = "余额"
                .Width = 60
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            Dim linkColomn As New DataGridViewLinkColumn
            linkColomn.DataPropertyName = "SalesBillCode"
            .Columns.RemoveAt(4)
            .Columns.Insert(4, linkColomn)
            With .Columns(4)
                .HeaderText = "销售单号"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 90
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(5)
                .HeaderText = "面值"
                .Width = 60
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(6)
                .HeaderText = "卡类型"
                .Width = 50
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(7)
                .HeaderText = "售卖门店"
                .MinimumWidth = 65
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            Dim newCheckColumn As New DataGridViewCheckBoxColumn()
            newCheckColumn.DataPropertyName = "Selected"
            .Columns.RemoveAt(8)
            .Columns.Insert(8, newCheckColumn)
            With .Columns(8)
                .HeaderText = "选择"
                .Width = 40
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(9)
                .HeaderText = "不可撤销原因"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .Visible = False
            End With
            .Columns(10).Visible = False
            .Columns(11).Visible = False
            .Columns(12).Visible = False
            .Columns(13).Visible = False

            For bColumn As Byte = 0 To dtList3.Columns.Count - 1
                .Columns(bColumn).Name = dtList3.Columns(bColumn).ColumnName
            Next
        End With

        With Me.dgvList4
            .DataSource = dtList4
            With .Columns(0)
                .HeaderText = "行号"
                .Width = 40
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.BackColor = SystemColors.Control
                .DefaultCellStyle.ForeColor = SystemColors.ControlText
                .DefaultCellStyle.SelectionBackColor = SystemColors.Control
                .DefaultCellStyle.SelectionForeColor = SystemColors.ControlText
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(1)
                .HeaderText = "卡号"
                .Width = 125
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(2)
                .HeaderText = "卡状态"
                .Width = 50
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(3)
                .HeaderText = "余额"
                .Width = 60
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            Dim linkColomn As New DataGridViewLinkColumn
            linkColomn.DataPropertyName = "SalesBillCode"
            .Columns.RemoveAt(4)
            .Columns.Insert(4, linkColomn)
            With .Columns(4)
                .HeaderText = "销售单号"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 90
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(5)
                .HeaderText = "面值"
                .Width = 60
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(6)
                .HeaderText = "卡类型"
                .Width = 50
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(7)
                .HeaderText = "售卖门店"
                .MinimumWidth = 65
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(8)
                .HeaderText = "申请结果"
                .Width = 75
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(9)
                .HeaderText = "失败原因"
                .Width = 85
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .Visible = False
            End With
            .Columns(10).Visible = False
            .Columns(11).Visible = False
            .Columns(12).Visible = False

            For bColumn As Byte = 0 To dtList4.Columns.Count - 1
                .Columns(bColumn).Name = dtList4.Columns(bColumn).ColumnName
            Next
        End With

        If Not ToolStripManager.VisualStylesEnabled Then
            Me.dgvList1.Height += 2
            Me.dgvList2.Height += 2
            Me.dgvList3.Height += 2
            Me.dgvList4.Height += 2
        End If

        dtList1.Rows.Add(1)
        Me.dgvList1.Focus()
        Me.dgvList1.Select()
        Me.dgvList1("StartCardNo", 0).Selected = True
    End Sub

    Private Sub dgvList1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvList1.CellEndEdit
        If blSkipDeal Then Return
        blSkipDeal = True : Me.dgvList1.CurrentCell.Selected = False : blSkipDeal = False
    End Sub

    Private Sub dgvList1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvList1.CellFormatting
        If errorCell IsNot Nothing AndAlso e.ColumnIndex = errorCell.ColumnIndex AndAlso e.RowIndex = errorCell.RowIndex Then
            e.CellStyle.ForeColor = Color.Red
            e.CellStyle.SelectionForeColor = Color.Red
        End If
    End Sub

    Private Sub dgvList1_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvList1.CellLeave
        If editingCardNo IsNot Nothing AndAlso (e.ColumnIndex = 1 OrElse e.ColumnIndex = 2) Then
            editingCardNo = Nothing
        End If
    End Sub

    Private Sub dgvList1_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvList1.CellMouseUp
        If Me.dgvList1.ReadOnly OrElse e.RowIndex = -1 OrElse e.ColumnIndex <> 0 OrElse e.Button <> Windows.Forms.MouseButtons.Right OrElse Me.dgvList1("StartCardNo", 0).Value.ToString = "" Then Return

        blSkipDeal = True
        Me.dgvList1("CardQTY", e.RowIndex).Selected = True
        Me.dgvList1.CurrentRow.Selected = True
        blSkipDeal = False
        Me.cmenuDelete.Show(Control.MousePosition)
    End Sub

    Private Sub dgvList1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvList1.CellValueChanged
        If blSkipDeal OrElse (e.ColumnIndex <> 1 AndAlso e.ColumnIndex <> 2) OrElse e.RowIndex = -1 Then Return

        errorCell = Nothing : sErrorInfo = ""
        blSkipDeal = True

        Dim sCardNo As String = "", sFeature As String = "", sInputtingFeature As String = ""
        If Me.dgvList1(e.ColumnIndex, e.RowIndex).Value IsNot Nothing Then sCardNo = Me.dgvList1(e.ColumnIndex, e.RowIndex).Value.ToString
        Try
            If sCardNo.IndexOf("2336") = 0 Then
                sInputtingFeature = sCardNo.Substring(0, 9)
            ElseIf sCardNo.IndexOf("84") = 0 OrElse sCardNo.IndexOf("86") = 0 OrElse sCardNo.IndexOf("92") = 0 OrElse sCardNo.IndexOf("94") = 0 Then
                sInputtingFeature = sCardNo.Substring(0, 5)
            Else
                sInputtingFeature = ""
            End If
        Catch
            sInputtingFeature = ""
        End Try

        sErrorInfo = "" : errorCell = Nothing
        Select Case Me.dgvList1.Columns(e.ColumnIndex).Name
            Case "StartCardNo"
                sFeature = Me.dgvList1("EndCardNo", e.RowIndex).Value.ToString
                Try
                    If sFeature.IndexOf("2336") = 0 Then
                        sFeature = sFeature.Substring(0, 9)
                    ElseIf sFeature.IndexOf("84") = 0 OrElse sFeature.IndexOf("86") = 0 OrElse sFeature.IndexOf("92") = 0 OrElse sFeature.IndexOf("94") = 0 Then
                        sFeature = sFeature.Substring(0, 5)
                    Else
                        sFeature = ""
                    End If
                Catch
                End Try

                If sCardNo = "" Then
                    If Me.dgvList1("EndCardNo", e.RowIndex).Value.ToString <> "" Then
                        Me.dgvList1.EndEdit() : Me.dgvList1("StartCardNo", e.RowIndex).Value = Me.dgvList1("EndCardNo", e.RowIndex).Value
                    ElseIf e.RowIndex < Me.dgvList1.RowCount - 1 Then
                        sErrorInfo = "请在该单元格输入开始卡号（在行号上按鼠标右键出现""删除""菜单可删除该行）。"
                    Else
                        sErrorInfo = "请在该单元格输入开始卡号。"
                    End If
                ElseIf Not IsNumeric(sCardNo) Then
                    sErrorInfo = "开始卡号错误：卡号只能由数字组成！"
                ElseIf sFeature <> "" AndAlso sInputtingFeature <> "" AndAlso sFeature <> sInputtingFeature Then
                    sErrorInfo = "开始卡号错误：与结束卡片类型不一致！"
                ElseIf sCardNo.IndexOf("2") = 0 AndAlso sCardNo.Length < 19 Then
                    sErrorInfo = "开始卡号错误：卡号位数不足 19 位！"
                ElseIf sCardNo.IndexOf("2") <> 0 AndAlso sCardNo.Length < 17 Then
                    sErrorInfo = "开始卡号错误：卡号位数不足 17 位！"
                ElseIf sCardNo.IndexOf("94") <> 0 AndAlso sCardNo.IndexOf("233694") <> 0 Then
                    sErrorInfo = "开始卡号错误：卡号非法（应以""94""或""233694""开头）！"
                ElseIf sCardNo.IndexOf("2") = 0 AndAlso sCardNo <> ShoppingCardNo.GetFullCardNo(sCardNo.Substring(0, 18)) Then
                    sErrorInfo = "开始卡号错误：卡号校验码错误！"
                ElseIf (sCardNo.IndexOf("2") = 0 AndAlso dvCULParameter.Table.Select("CULCardBin='" & sCardNo.Substring(4, 5) & "'").Length = 0) OrElse (sCardNo.IndexOf("2") <> 0 AndAlso dvCULParameter.Table.Select("CULCardBin='" & sCardNo.Substring(0, 5) & "'").Length = 0) Then
                    sErrorInfo = "开始卡号错误：无权操作该卡段！"
                End If

                If sErrorInfo = "" Then
                    Me.dgvList1.EndEdit()
                    Dim blGotoEndCardColumn As Boolean = False
                    If Me.dgvList1("EndCardNo", e.RowIndex).Value.ToString = "" Then
                        Me.dgvList1("EndCardNo", e.RowIndex).Value = sCardNo
                        Me.dgvList1.EndEdit()
                        blGotoEndCardColumn = True
                    End If
                    Me.ConfigCardRow()
                    If blGotoEndCardColumn Then Me.dgvList1("EndCardNo", Me.dgvList1.CurrentCell.RowIndex).Selected = True
                End If
            Case "EndCardNo"
                sFeature = Me.dgvList1("StartCardNo", e.RowIndex).Value.ToString
                Try
                    If sFeature.IndexOf("2336") = 0 Then
                        sFeature = sFeature.Substring(0, 9)
                    ElseIf sFeature.IndexOf("84") = 0 OrElse sFeature.IndexOf("86") = 0 OrElse sFeature.IndexOf("92") = 0 OrElse sFeature.IndexOf("94") = 0 Then
                        sFeature = sFeature.Substring(0, 5)
                    Else
                        sFeature = ""
                    End If
                Catch
                End Try

                If sCardNo = "" Then
                    Me.dgvList1.EndEdit()
                    If Me.dgvList1("StartCardNo", e.RowIndex).Value.ToString <> "" Then
                        Me.dgvList1("EndCardNo", e.RowIndex).Value = Me.dgvList1("StartCardNo", e.RowIndex).Value
                    Else
                        Me.dgvList1("EndCardNo", e.RowIndex).Value = ""
                        blSkipDeal = False : Return
                    End If
                ElseIf Not IsNumeric(sCardNo) Then
                    sErrorInfo = "结束卡号错误：卡号只能由数字组成！"
                ElseIf sFeature <> "" AndAlso sInputtingFeature <> "" AndAlso sFeature <> sInputtingFeature Then
                    sErrorInfo = "结束卡号错误：与开始卡片类型不一致！"
                ElseIf sCardNo.IndexOf("2") = 0 AndAlso sCardNo.Length < 19 Then
                    sErrorInfo = "结束卡号错误：卡号位数不足 19 位！"
                ElseIf sCardNo.IndexOf("2") <> 0 AndAlso sCardNo.Length < 17 Then
                    sErrorInfo = "结束卡号错误：卡号位数不足 17 位！"
                ElseIf sCardNo.IndexOf("94") <> 0 AndAlso sCardNo.IndexOf("233694") <> 0 Then
                    sErrorInfo = "结束卡号错误：卡号非法（应以""94""或""233694""开头）！"
                ElseIf sCardNo.IndexOf("2") = 0 AndAlso sCardNo <> ShoppingCardNo.GetFullCardNo(sCardNo.Substring(0, 18)) Then
                    sErrorInfo = "结束卡号错误：卡号校验码错误！"
                ElseIf (sCardNo.IndexOf("2") = 0 AndAlso dvCULParameter.Table.Select("CULCardBin='" & sCardNo.Substring(4, 5) & "'").Length = 0) OrElse (sCardNo.IndexOf("2") <> 0 AndAlso dvCULParameter.Table.Select("CULCardBin='" & sCardNo.Substring(0, 5) & "'").Length = 0) Then
                    sErrorInfo = "结束卡号错误：无权操作该卡段！"
                End If

                If sErrorInfo = "" Then Me.ConfigCardRow()
        End Select
        blSkipDeal = False

        blStep1OK = False : blStep2OK = False : blStep3OK = False : blStep4OK = False
        If sErrorInfo = "" Then
            dtList2.Rows.Clear()
            Me.dgvList2.Columns("ResultReason").Visible = False
            Me.chkSelectAll.CheckState = CheckState.Unchecked
            dtList3.Rows.Clear()
            Me.dgvList3.Columns("ResultReason").Visible = False
            dtList4.Rows.Clear()

            Me.lblInfo1.ForeColor = SystemColors.ControlText
            Dim iCards As Integer = dtList1.Compute("Sum(CardQTY)", "")
            If iCards > 10000 Then
                Me.lblInfo1.ForeColor = Color.Red
                Me.lblInfo1.Text = sErrorInfo
                Me.lblInfo1.Text = "共输入了 " & Format(iCards, "#,0") & " 张卡。但系统限制不能在一次撤销操作中超过 10,000 张卡！请分成多批撤销。"
                Me.btnNext.Enabled = False : Me.btnFinish.Enabled = False
            Else
                Me.lblInfo1.Text = "共输入了 " & Format(iCards, "#,0") & " 张卡。如果卡号输入完毕，请按""下一步""查询该" & IIf(iCards = 1, "张", "批") & "活动卡的状态及其对应的销售单。"
                blStep1OK = True
                Me.btnNext.Enabled = True
                Me.btnFinish.Enabled = False
            End If
        Else
            errorCell = Me.dgvList1(e.ColumnIndex, e.RowIndex)
            Me.lblInfo1.ForeColor = Color.Red
            Me.lblInfo1.Text = sErrorInfo

            Me.btnNext.Enabled = False : Me.btnFinish.Enabled = False
            blSkipDeal = True
            Me.dgvList1.Select() : Me.dgvList1("RowID", e.RowIndex).Selected = True : errorCell.Selected = True
        End If
        blSkipDeal = False
    End Sub

    Private Sub dgvList1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvList1.EditingControlShowing
        If Me.dgvList1.Columns(Me.dgvList1.CurrentCell.ColumnIndex).Name.IndexOf("CardNo") > -1 Then
            editingCardNo = CType(e.Control, TextBox)
            RemoveHandler editingCardNo.KeyDown, AddressOf CardNo_KeyDown
            RemoveHandler editingCardNo.TextChanged, AddressOf CardNo_TextChanged
            editingCardNo.ImeMode = Windows.Forms.ImeMode.Disable
            editingCardNo.MaxLength = 19
            AddHandler editingCardNo.KeyDown, AddressOf CardNo_KeyDown
            AddHandler editingCardNo.TextChanged, AddressOf CardNo_TextChanged
        End If
    End Sub

    Private Sub dgvList1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvList1.KeyDown
        If e.KeyCode = Keys.Delete AndAlso Me.dgvList1.ReadOnly = False AndAlso Me.dgvList1.CurrentRow.Selected = True Then
            If Me.dgvList1("StartCardNo", 0).Value.ToString = "" Then
                Me.dgvList1("StartCardNo", 0).Selected = True
                Me.dgvList1.BeginEdit(True)
            Else
                Me.menuDelete.PerformClick()
            End If
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub dgvList1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvList1.Leave
        blSkipDeal = True
        If Me.dgvList1.CurrentCell IsNot Nothing Then Me.dgvList1.CurrentCell.Selected = False
        If Me.dgvList1.CurrentRow IsNot Nothing Then Me.dgvList1.CurrentRow.Selected = False
        blSkipDeal = False
    End Sub

    Private Sub dgvList1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvList1.SelectionChanged
        If blSkipDeal OrElse Me.dgvList1.CurrentCell Is Nothing Then Return
        blSkipDeal = True
        If Me.dgvList1.ReadOnly OrElse Me.dgvList1.Columns(Me.dgvList1.CurrentCell.ColumnIndex).Name = "CardQTY" Then
            Me.dgvList1.CurrentRow.Selected = True
        ElseIf Me.dgvList1.CurrentCell.ColumnIndex = 0 Then
            Me.dgvList1("CardQTY", Me.dgvList1.CurrentRow.Index).Selected = True
            Me.dgvList1.CurrentRow.Selected = True
        ElseIf errorCell IsNot Nothing Then
            Me.lblInfo1.ForeColor = Color.Red
            Me.lblInfo1.Text = sErrorInfo
            Me.dgvList1("CardQTY", errorCell.RowIndex).Selected = True : errorCell.Selected = True
        ElseIf Me.dgvList1(1, Me.dgvList1.CurrentRow.Index).Value Is Nothing OrElse Me.dgvList1(1, Me.dgvList1.CurrentRow.Index).Value.ToString = "" Then
            If Me.dgvList1.CurrentCell.ColumnIndex <> 1 Then
                Me.dgvList1(1, Me.dgvList1.CurrentRow.Index).Selected = True
            End If
        End If
        blSkipDeal = False
    End Sub

    Private Sub menuDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuDelete.Click
        blSkipDeal = True
        Dim iCurrentRow As Integer = Me.dgvList1.CurrentRow.Index, drCard As DataRow = dtList1.Rows(iCurrentRow)
        If errorCell IsNot Nothing AndAlso errorCell.RowIndex = iCurrentRow Then errorCell = Nothing : sErrorInfo = ""
        If iCurrentRow = Me.dgvList1.RowCount - 1 Then
            drCard("StartCardNo") = DBNull.Value
            drCard("EndCardNo") = DBNull.Value
            drCard("CardQTY") = DBNull.Value
            drCard.EndEdit() : drCard.AcceptChanges()
        Else
            drCard.Delete()
            For iRow As Integer = iCurrentRow To dtList1.Rows.Count - 1
                dtList1.Rows(iRow)("RowID") = iRow + 1
            Next
        End If
        iCurrentRow = Me.dgvList1.CurrentRow.Index
        Me.dgvList1("CardQTY", iCurrentRow).Selected = True : Me.dgvList1.CurrentRow.Selected = True

        blStep1OK = False : blStep2OK = False : blStep3OK = False : blStep4OK = False
        If sErrorInfo = "" Then
            dtList2.Rows.Clear()
            Me.dgvList2.Columns("ResultReason").Visible = False
            Me.chkSelectAll.CheckState = CheckState.Unchecked
            dtList3.Rows.Clear()
            Me.dgvList3.Columns("ResultReason").Visible = False
            dtList4.Rows.Clear()

            Dim iCards As Integer = 0
            Try
                iCards = dtList1.Compute("Sum(CardQTY)", "")
            Catch
            End Try

            Me.lblInfo1.ForeColor = SystemColors.ControlText
            If iCards > 10000 Then
                Me.lblInfo1.ForeColor = Color.Red
                Me.lblInfo1.Text = sErrorInfo
                Me.lblInfo1.Text = "共输入了 " & Format(iCards, "#,0") & " 张卡。但系统限制不能在一次撤销操作中超过 10,000 张卡！请分成多批撤销。"
                Me.btnNext.Enabled = False : Me.btnFinish.Enabled = False
            ElseIf iCards > 0 Then
                Me.lblInfo1.Text = "共输入了 " & Format(iCards, "#,0") & " 张卡。如果卡号输入完毕，请按""下一步""查询该" & IIf(iCards = 1, "张", "批") & "活动卡的状态及其对应的销售单。"
                blStep1OK = True
                Me.btnNext.Enabled = True
                Me.btnFinish.Enabled = False
            Else
                Me.lblInfo1.Text = "请在上面列表输入需要进行激活撤销操作的活动卡卡号。"
                Me.btnNext.Enabled = False
                Me.btnFinish.Enabled = False
            End If
        End If
        blSkipDeal = False
    End Sub

    Private Sub dgvList2_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvList2.CellContentClick
        If e.RowIndex = -1 OrElse Me.dgvList2.Columns(e.ColumnIndex).Name <> "SalesBillCode" Then Return
        If blCanBrowseSalesBill Then
            If frmMain.dtAllowedRight.Select("RightName='SalesBillBrowse'").Length = 0 Then
                MessageBox.Show("对不起！您没有浏览销售单的权限。    " & Chr(13) & "Sorry, you have no right to browse sales bill.    ", "您无权浏览销售单 No right to browse sales bill!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                blCanBrowseSalesBill = False
                frmMain.statusText.Text = "对不起！您没有浏览销售单的权限。"
            Else
                With frmSelling
                    If .IsHandleCreated Then
                        .Activate()
                        .WindowState = FormWindowState.Maximized
                        If .sSalesBillID <> Me.dgvList2("SalesBillID", Me.dgvList2.CurrentRow.Index).Value.ToString Then
                            If .blIsChanged Then
                                Dim bAnswer As DialogResult = MessageBox.Show("是否在打开销售单之前，先保存当前销售单？    ", "当前销售单未保存！", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                                If bAnswer = Windows.Forms.DialogResult.Cancel OrElse (bAnswer = Windows.Forms.DialogResult.Yes AndAlso Not .SaveChanges()) Then
                                    Me.Activate()
                                    frmMain.statusText.Text = "因为存在未保存销售单，所以不能打开销售单。"
                                    Return
                                End If
                            End If
                            .sSalesBillID = Me.dgvList2("SalesBillID", Me.dgvList2.CurrentRow.Index).Value.ToString
                            .LoadSalesBill()
                        End If
                    Else
                        Me.Cursor = Cursors.WaitCursor
                        frmMain.statusText.Text = "正在打开销售单……"
                        frmMain.statusMain.Refresh()

                        .sSalesBillID = Me.dgvList2("SalesBillID", Me.dgvList2.CurrentRow.Index).Value.ToString
                        .Show()
                        If .IsHandleCreated Then
                            .MdiParent = frmMain
                            .WindowState = FormWindowState.Maximized
                            .Activate()
                        End If

                        If frmMain.statusText.Text.IndexOf("……") > -1 Then frmMain.statusText.Text = "就绪。"
                        Me.Cursor = Cursors.Default
                    End If

                    If .IsHandleCreated Then
                        If .dgvNormalCard.CurrentRow IsNot Nothing Then .dgvNormalCard.CurrentRow.Selected = False
                        If .dgvRebateCard.CurrentRow IsNot Nothing Then .dgvRebateCard.CurrentRow.Selected = False
                        If .dgvPayment.CurrentRow IsNot Nothing Then .dgvPayment.CurrentRow.Selected = False
                    End If

                    .btnOK.Enabled = False
                    .btnPrintTicket.Enabled = False
                    .btnPrintInvoice.Enabled = False
                    .btnViewActivation.Enabled = True
                    .btnNewSalesBill.Enabled = False
                End With
            End If
        Else
            frmMain.statusText.Text = "对不起！您没有浏览销售单的权限。"
        End If
    End Sub

    Private Sub dgvList2_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvList2.CellFormatting
        If Me.dgvList2.Columns(e.ColumnIndex).GetType.Name = "DataGridViewLinkColumn" Then
            If Me.dgvList2.CurrentRow IsNot Nothing AndAlso Me.dgvList2.CurrentRow.Index = e.RowIndex AndAlso Me.dgvList2.CurrentRow.Selected Then
                CType(Me.dgvList2(e.ColumnIndex, e.RowIndex), DataGridViewLinkCell).LinkColor = Color.Yellow
            Else
                CType(Me.dgvList2(e.ColumnIndex, e.RowIndex), DataGridViewLinkCell).LinkColor = Color.Blue
            End If
        ElseIf Me.dgvList2("CheckResult", e.RowIndex).Value.ToString = "不可撤销" AndAlso (Me.dgvList2.Columns(e.ColumnIndex).Name = "CheckResult" OrElse Me.dgvList2.Columns(e.ColumnIndex).Name = "ResultReason") Then
            e.CellStyle.ForeColor = Color.Red
            e.CellStyle.SelectionForeColor = Color.Red
        End If
    End Sub

    Private Sub dgvList2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvList2.Leave
        If Me.dgvList2.CurrentCell IsNot Nothing Then Me.dgvList2.CurrentCell.Selected = False
        If Me.dgvList2.CurrentRow IsNot Nothing Then Me.dgvList2.CurrentRow.Selected = False
    End Sub

    Private Sub chkSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSelectAll.Click
        If blStep5OK Then Return
        If Me.chkSelectAll.CheckState = CheckState.Unchecked Then
            Dim dmFaceValue As Decimal = 0, dmAvailableBalance As Decimal = 0
            For Each drCard As DataRow In dtList3.Rows
                dmFaceValue = drCard("FaceValue") : dmAvailableBalance = drCard("AvailableBalance")
                If dmFaceValue <= dmAvailableBalance Then
                    drCard("Selected") = 1
                    Try
                        dmAvailableBalance = drCard("Balance") - dtList3.Compute("Sum(FaceValue)", "CardNo='" & drCard("CardNo").ToString & "' And Selected=1")
                    Catch
                        dmAvailableBalance = drCard("Balance")
                    End Try
                    For Each dr As DataRow In dtList3.Select("CardNo='" & drCard("CardNo").ToString & "'")
                        If dr("Selected") Then
                            dr("AvailableBalance") = dmAvailableBalance + dr("FaceValue")
                        Else
                            dr("AvailableBalance") = dmAvailableBalance
                        End If
                    Next
                End If
                drCard("ResultReason") = DBNull.Value
            Next
        Else
            For Each drCard As DataRow In dtList3.Rows
                drCard("Selected") = 0
                drCard("AvailableBalance") = drCard("Balance")
                drCard("ResultReason") = DBNull.Value
            Next
        End If
        Me.dgvList3.Columns("ResultReason").Visible = False

        dtList3.AcceptChanges()
        Dim iSelectedCards As Integer = dtList3.DefaultView.ToTable(True, "CardNo", "Selected").Select("Selected=1").Length, dmSelectedAMT As Decimal = 0
        Try
            dmSelectedAMT = dtList3.Compute("Sum(FaceValue)", "Selected=1")
        Catch
        End Try

        If iSelectedCards = 0 Then
            Me.chkSelectAll.CheckState = CheckState.Unchecked
        ElseIf dtList3.Select("Selected=1").Length = Me.dgvList3.RowCount Then
            Me.chkSelectAll.CheckState = CheckState.Checked
        Else
            Me.chkSelectAll.CheckState = CheckState.Indeterminate
        End If

        If iSelectedCards = 0 Then
            Me.lblInfo3.Text = "请选择需要进行激活撤销操作的活动卡对应的销售单号，然后按""下一步""输入撤销原因……"
            blStep3OK = False
            Me.btnNext.Enabled = False
        Else
            Me.lblInfo3.Text = "您已经选择了 " & Format(iSelectedCards, "#,0") & " 张卡共 " & Format(dmSelectedAMT, "#,0.00").Replace(".00", "") & " 元。如果选择完毕，请按""下一步""输入撤销原因。"
            blStep3OK = True
            Me.btnNext.Enabled = True
        End If
        Me.dgvList3.Select()
        Me.chkSelectAll.Select()
    End Sub

    Private Sub dgvList3_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvList3.CellContentClick
        If e.RowIndex = -1 Then Return
        If Me.dgvList3.Columns(e.ColumnIndex).Name = "SalesBillCode" Then
            If blCanBrowseSalesBill Then
                If frmMain.dtAllowedRight.Select("RightName='SalesBillBrowse'").Length = 0 Then
                    MessageBox.Show("对不起！您没有浏览销售单的权限。    " & Chr(13) & "Sorry, you have no right to browse sales bill.    ", "您无权浏览销售单 No right to browse sales bill!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    blCanBrowseSalesBill = False
                    frmMain.statusText.Text = "对不起！您没有浏览销售单的权限。"
                Else
                    With frmSelling
                        If .IsHandleCreated Then
                            .Activate()
                            .WindowState = FormWindowState.Maximized
                            If .sSalesBillID <> Me.dgvList3("SalesBillID", Me.dgvList3.CurrentRow.Index).Value.ToString Then
                                If .blIsChanged Then
                                    Dim bAnswer As DialogResult = MessageBox.Show("是否在打开销售单之前，先保存当前销售单？    ", "当前销售单未保存！", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                                    If bAnswer = Windows.Forms.DialogResult.Cancel OrElse (bAnswer = Windows.Forms.DialogResult.Yes AndAlso Not .SaveChanges()) Then
                                        Me.Activate()
                                        frmMain.statusText.Text = "因为存在未保存销售单，所以不能打开销售单。"
                                        Return
                                    End If
                                End If
                                .sSalesBillID = Me.dgvList3("SalesBillID", Me.dgvList3.CurrentRow.Index).Value.ToString
                                .LoadSalesBill()
                            End If
                        Else
                            Me.Cursor = Cursors.WaitCursor
                            frmMain.statusText.Text = "正在打开销售单……"
                            frmMain.statusMain.Refresh()

                            .sSalesBillID = Me.dgvList3("SalesBillID", Me.dgvList3.CurrentRow.Index).Value.ToString
                            .Show()
                            If .IsHandleCreated Then
                                .MdiParent = frmMain
                                .WindowState = FormWindowState.Maximized
                                .Activate()
                            End If

                            If frmMain.statusText.Text.IndexOf("……") > -1 Then frmMain.statusText.Text = "就绪。"
                            Me.Cursor = Cursors.Default
                        End If

                        If .IsHandleCreated Then
                            If .dgvNormalCard.CurrentRow IsNot Nothing Then .dgvNormalCard.CurrentRow.Selected = False
                            If .dgvRebateCard.CurrentRow IsNot Nothing Then .dgvRebateCard.CurrentRow.Selected = False
                            If .dgvPayment.CurrentRow IsNot Nothing Then .dgvPayment.CurrentRow.Selected = False
                        End If

                        .btnOK.Enabled = False
                        .btnPrintTicket.Enabled = False
                        .btnPrintInvoice.Enabled = False
                        .btnViewActivation.Enabled = True
                        .btnNewSalesBill.Enabled = False
                    End With
                End If
            Else
                frmMain.statusText.Text = "对不起！您没有浏览销售单的权限。"
            End If
        ElseIf Me.dgvList3.Columns(e.ColumnIndex).Name = "Selected" AndAlso Not blStep5OK Then
            Dim drCard As DataRow = dtList3.Select("RowID=" & Me.dgvList3("RowID", e.RowIndex).Value.ToString)(0), dmFaceValue As Decimal = drCard("FaceValue"), dmAvailableBalance As Decimal = drCard("AvailableBalance")
            If drCard("Selected") Then
                drCard("Selected") = 0
                Try
                    dmAvailableBalance = drCard("Balance") - dtList3.Compute("Sum(FaceValue)", "CardNo='" & drCard("CardNo").ToString & "' And Selected=1")
                Catch
                    dmAvailableBalance = drCard("Balance")
                End Try
                For Each dr As DataRow In dtList3.Select("CardNo='" & Me.dgvList3("CardNo", e.RowIndex).Value.ToString & "'")
                    If dr("Selected") Then
                        dr("AvailableBalance") = dmAvailableBalance + dr("FaceValue")
                    Else
                        dr("AvailableBalance") = dmAvailableBalance
                    End If
                    dr("ResultReason") = DBNull.Value
                Next
            ElseIf dmAvailableBalance < dmFaceValue Then
                drCard("ResultReason") = "卡余额不足！"
            Else
                drCard("Selected") = 1
                Try
                    dmAvailableBalance = drCard("Balance") - dtList3.Compute("Sum(FaceValue)", "CardNo='" & drCard("CardNo").ToString & "' And Selected=1")
                Catch
                    dmAvailableBalance = drCard("Balance")
                End Try
                For Each dr As DataRow In dtList3.Select("CardNo='" & Me.dgvList3("CardNo", e.RowIndex).Value.ToString & "'")
                    If dr("Selected") Then
                        dr("AvailableBalance") = dmAvailableBalance + dr("FaceValue")
                    Else
                        dr("AvailableBalance") = dmAvailableBalance
                    End If
                Next
            End If
            With Me.dgvList3.Columns("ResultReason")
                If dtList3.Select("Isnull(ResultReason,'')<>''").Length = 0 Then
                    .Visible = False
                Else
                    .Visible = True
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Me.dgvList3.FirstDisplayedScrollingColumnIndex = .Index
                End If
            End With

            dtList3.AcceptChanges()
            Dim iSelectedCards As Integer = dtList3.DefaultView.ToTable(True, "CardNo", "Selected").Select("Selected=1").Length, dmSelectedAMT As Decimal = 0
            Try
                dmSelectedAMT = dtList3.Compute("Sum(FaceValue)", "Selected=1")
            Catch
            End Try

            If iSelectedCards = 0 Then
                Me.chkSelectAll.CheckState = CheckState.Unchecked
            ElseIf dtList3.Select("Selected=1").Length = Me.dgvList3.RowCount Then
                Me.chkSelectAll.CheckState = CheckState.Checked
            Else
                Me.chkSelectAll.CheckState = CheckState.Indeterminate
            End If

            If iSelectedCards = 0 Then
                Me.lblInfo3.Text = "请选择需要进行激活撤销操作的活动卡对应的销售单号，然后按""下一步""输入撤销原因……"
                blStep3OK = False
                Me.btnNext.Enabled = False
            Else
                Me.lblInfo3.Text = "您已经选择了 " & Format(iSelectedCards, "#,0") & " 张卡共 " & Format(dmSelectedAMT, "#,0.00").Replace(".00", "") & " 元。如果选择完毕，请按""下一步""输入撤销原因。"
                blStep3OK = True
                Me.btnNext.Enabled = True
            End If
        End If
    End Sub

    Private Sub dgvList3_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvList3.CellFormatting
        If Me.dgvList3.Columns(e.ColumnIndex).GetType.Name = "DataGridViewLinkColumn" Then
            If Me.dgvList3.CurrentRow IsNot Nothing AndAlso Me.dgvList3.CurrentRow.Index = e.RowIndex AndAlso Me.dgvList3.CurrentRow.Selected Then
                CType(Me.dgvList3(e.ColumnIndex, e.RowIndex), DataGridViewLinkCell).LinkColor = Color.Yellow
            Else
                CType(Me.dgvList3(e.ColumnIndex, e.RowIndex), DataGridViewLinkCell).LinkColor = Color.Blue
            End If
        ElseIf Me.dgvList3.Columns(e.ColumnIndex).Name = "ResultReason" AndAlso Me.dgvList3("ResultReason", e.RowIndex).Value.ToString <> "" Then
            e.CellStyle.ForeColor = Color.Red
            e.CellStyle.SelectionForeColor = Color.Red
        End If
    End Sub

    Private Sub dgvList3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvList3.Leave
        If Me.dgvList3.CurrentCell IsNot Nothing Then Me.dgvList3.CurrentCell.Selected = False
        If Me.dgvList3.CurrentRow IsNot Nothing Then Me.dgvList3.CurrentRow.Selected = False
    End Sub

    Private Sub txbReason_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbReason.TextChanged
        If blSkipDeal Then Return
        blStep4OK = (Me.txbReason.Text.Trim <> "")
        Me.btnFinish.Enabled = (blStep4OK AndAlso Not blStep5OK)
        If Me.btnFinish.Enabled Then
            Me.lblInfo4.Text = "请按""完成""按钮保存本次的申请。"
        Else
            Me.lblInfo4.Text = "请在上面输入需要进行激活撤销操作的原因，然后按""完成""按钮保存本次的申请……"
        End If
    End Sub

    Private Sub dgvList4_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvList4.CellFormatting
        If Me.dgvList4.Columns(e.ColumnIndex).GetType.Name = "DataGridViewLinkColumn" Then
            If Me.dgvList4.CurrentRow IsNot Nothing AndAlso Me.dgvList4.CurrentRow.Index = e.RowIndex AndAlso Me.dgvList4.CurrentRow.Selected Then
                CType(Me.dgvList4(e.ColumnIndex, e.RowIndex), DataGridViewLinkCell).LinkColor = Color.Yellow
            Else
                CType(Me.dgvList4(e.ColumnIndex, e.RowIndex), DataGridViewLinkCell).LinkColor = Color.Blue
            End If
        Else
            Select Case Me.dgvList4.Columns(e.ColumnIndex).Name
                Case "AddedResult"
                    If e.Value.ToString = "申请失败！" Then
                        e.CellStyle.ForeColor = Color.Red
                        e.CellStyle.SelectionForeColor = Color.Red
                    End If
                Case "FailureReason"
                    e.CellStyle.ForeColor = Color.Red
                    e.CellStyle.SelectionForeColor = Color.Red
            End Select
        End If
    End Sub

    Private Sub dgvList4_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvList4.Leave
        If Me.dgvList4.CurrentCell IsNot Nothing Then Me.dgvList4.CurrentCell.Selected = False
        If Me.dgvList4.CurrentRow IsNot Nothing Then Me.dgvList4.CurrentRow.Selected = False
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        Me.pnlStep1.Visible = True
        Me.pnlStep2.Visible = False
        Me.pnlStep3.Visible = False
        Me.pnlStep4.Visible = False

        bStep = 1
        If blStep5OK Then
            blSkipDeal = True
            dtList1.Rows.Clear() : dtList1.AcceptChanges()
            dtList2.Rows.Clear() : dtList2.AcceptChanges()
            dtList3.Rows.Clear() : dtList3.AcceptChanges()
            dtList4.Rows.Clear() : dtList4.AcceptChanges()

            Me.dgvList1.ReadOnly = False
            Me.dgvList1.Columns("RowID").ReadOnly = True
            Me.dgvList1.Columns("CardQTY").ReadOnly = True
            Me.dgvList1.DefaultCellStyle.BackColor = SystemColors.Window
            Me.lblInfo1.Text = "请在上面列表输入需要进行激活撤销操作的活动卡卡号。"
            Me.dgvList2.DefaultCellStyle.BackColor = SystemColors.Window
            Me.lblInfo2.Text = ""
            Me.dgvList3.Columns("ResultReason").Visible = False
            Me.dgvList3.DefaultCellStyle.BackColor = SystemColors.Window
            Me.lblInfo3.ForeColor = SystemColors.ControlText
            Me.lblInfo3.Text = ""
            Me.txbReason.ReadOnly = False
            Me.txbReason.BackColor = SystemColors.Window
            Me.txbReason.Text = ""
            Me.dgvList4.Columns("FailureReason").Visible = False
            Me.lblReason.Text = "请输入撤销原因（限 50 个字以内），然后按下面的""完成""按钮保存本次的激活撤销申请："
            Me.pnlAfter.Visible = False
            Me.lblInfo4.ForeColor = SystemColors.ControlText
            Me.lblInfo4.Text = ""

            Me.btnStart.Enabled = False
            Me.btnPrevious.Enabled = False
            Me.btnNext.Enabled = False
            Me.btnFinish.Enabled = False
            Me.btnCancel.Text = "取消(&C)"

            dtList1.Rows.Add(1)
            blStep1OK = False : blStep2OK = False : blStep3OK = False : blStep4OK = False : blStep5OK = False
            blSkipDeal = False
            Me.dgvList1.Select()
            Me.dgvList1("StartCardNo", Me.dgvList1.RowCount - 1).Selected = True
            Me.dgvList1.CurrentRow.Selected = False
            Me.dgvList1.BeginEdit(True)
        Else
            Me.btnStart.Enabled = False
            Me.btnPrevious.Enabled = False
            Me.btnNext.Enabled = True
            Me.btnFinish.Enabled = (blStep4OK AndAlso Not blStep5OK)
            Me.btnNext.Select()
        End If
    End Sub

    Private Sub btnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevious.Click
        Select Case bStep
            Case 2
                bStep = 1
                Me.pnlStep1.Visible = True
                Me.pnlStep2.Visible = False
                Me.pnlStep3.Visible = False
                Me.pnlStep4.Visible = False

                Me.btnStart.Enabled = blStep5OK
                Me.btnPrevious.Enabled = False
                Me.btnNext.Enabled = True
                Me.btnFinish.Enabled = (blStep4OK AndAlso Not blStep5OK)

                If blStep5OK Then
                    Me.dgvList1.Select()
                    Me.btnNext.Select()
                Else
                    Me.dgvList1.Select()
                    Me.dgvList1("StartCardNo", Me.dgvList1.RowCount - 1).Selected = True
                    Me.dgvList1.CurrentRow.Selected = False
                    Me.dgvList1.BeginEdit(True)
                End If
            Case 3
                bStep = 2
                Me.pnlStep1.Visible = False
                Me.pnlStep2.Visible = True
                Me.pnlStep3.Visible = False
                Me.pnlStep4.Visible = False

                Me.btnStart.Enabled = True
                Me.btnPrevious.Enabled = True
                Me.btnNext.Enabled = True
                Me.btnFinish.Enabled = (blStep4OK AndAlso Not blStep5OK)

                Me.dgvList2.Select()
                Me.btnPrevious.Select()
            Case 4
                bStep = 3
                Me.pnlStep1.Visible = False
                Me.pnlStep2.Visible = False
                Me.pnlStep3.Visible = True
                Me.pnlStep4.Visible = False

                Me.btnStart.Enabled = True
                Me.btnPrevious.Enabled = True
                Me.btnNext.Enabled = True
                Me.btnFinish.Enabled = (blStep4OK AndAlso Not blStep5OK)

                If blStep5OK Then
                    Me.dgvList3.Select()
                    Me.btnPrevious.Select()
                Else
                    Me.dgvList3.Select()
                    If Me.dgvList3.CurrentRow IsNot Nothing Then
                        Me.dgvList3.CurrentRow.Selected = True
                    Else
                        Me.dgvList3("CardNo", 0).Selected = True
                        Me.dgvList3.Rows(0).Selected = True
                    End If
                End If
        End Select
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Select Case bStep
            Case 1
                bStep = 2
                Me.pnlStep1.Visible = False
                Me.pnlStep2.Visible = True
                Me.pnlStep3.Visible = False
                Me.pnlStep4.Visible = False

                Me.btnStart.Enabled = True
                Me.btnPrevious.Enabled = True

                If blStep2OK Then
                    Me.btnNext.Select()
                ElseIf dtList2.Rows.Count = 0 Then
                    Dim iCards As Integer = dtList1.Compute("Sum(CardQTY)", "")
                    Me.Cursor = Cursors.WaitCursor
                    Me.lblInfo2.ForeColor = SystemColors.ControlText
                    Me.lblInfo2.Text = "正在查询该" & IIf(iCards = 1, "张", "批") & "活动卡的状态及其对应的销售单，请稍候……"
                    Me.Refresh()

                    Dim dtTemp As DataTable, dtResult As DataTable = Nothing, sStartCardNo As String, sStart As String, sEndCardNo As String, sEnd As String, sMerchantNo As String
                    For Each drCard As DataRow In dtList1.Select("Isnull(StartCardNo,'')<>''")
                        sStartCardNo = drCard("StartCardNo").ToString : sEndCardNo = drCard("EndCardNo").ToString
                        If sStartCardNo.IndexOf("2") = 0 Then
                            sMerchantNo = dvCULParameter.Table.Select("CULCardBin='" & sStartCardNo.Substring(4, 5) & "'")(0)("CULStoreCode").ToString
                        Else
                            sMerchantNo = dvCULParameter.Table.Select("CULCardBin='" & sStartCardNo.Substring(0, 5) & "'")(0)("CULStoreCode").ToString
                        End If
                        sStart = sStartCardNo
                        Do While sStart <= sEndCardNo
                            If sStart.IndexOf("2") = 0 Then
                                sEnd = ShoppingCardNo.GetFullCardNo(Format(CULng(sStart.Substring(0, 18)) + 99, "#"))
                            Else
                                sEnd = Format(CULng(sStart) + 99, "#")
                            End If
                            If sEnd > sEndCardNo Then sEnd = sEndCardNo
                            If sStart.IndexOf("2") = 0 Then
                                dtTemp = ShoppingCardOperation.GetCRFCardState(sMerchantNo, sStart, sEnd)
                            Else
                                dtTemp = ShoppingCardOperation.GetPaperCardState(sMerchantNo, sStart, sEnd)
                            End If
                            If dtTemp.Rows(0)("CardNo").ToString = "Error" Then
                                Me.lblInfo2.ForeColor = Color.Red
                                Me.lblInfo2.Text = "查询卡片状态时发生错误！错误提示：" & dtTemp.Rows(0)("StoreName").ToString
                                dtTemp.Dispose() : dtTemp = Nothing
                                If dtResult IsNot Nothing Then dtResult.Dispose() : dtResult = Nothing
                                Exit For
                            ElseIf dtResult Is Nothing Then
                                dtTemp.DefaultView.Sort = "CardNo"
                                dtResult = dtTemp.DefaultView.ToTable
                                dtResult.AcceptChanges()
                            Else
                                dtTemp.DefaultView.Sort = "CardNo"
                                dtResult.Merge(dtTemp.DefaultView.ToTable)
                                dtResult.AcceptChanges()
                            End If

                            If sEnd.IndexOf("2") = 0 Then
                                sStart = ShoppingCardNo.GetFullCardNo(Format(CULng(sEnd.Substring(0, 18)) + 1, "#"))
                            Else
                                sStart = Format(CULng(sEnd) + 1, "#")
                            End If
                        Loop
                    Next

                    If dtResult Is Nothing Then
                        Me.btnNext.Enabled = False
                        Me.btnPrevious.Select()
                        Me.Cursor = Cursors.Default
                        Return
                    Else
                        dtTemp = dtResult.Copy
                    End If

                    Dim DB As New DataBase
                    DB.Open()
                    If Not DB.IsConnected Then
                        dtTemp.Dispose() : dtTemp = Nothing
                        dtResult.Dispose() : dtResult = Nothing
                        Me.lblInfo2.ForeColor = Color.Red
                        Me.lblInfo2.Text = "系统因连接不到数据库而无法活动卡对应的销售单。请检查数据库连接。"
                        Me.Cursor = Cursors.Default : Return
                    End If

                    If DB.ModifyTable("Select CardNo Into #tempCard From CULCancelActivation Where 1=2") = -1 OrElse DB.BulkCopyTable("#tempCard", dtTemp.DefaultView.ToTable(True, "CardNo")) = -1 Then
                        dtTemp.Dispose() : dtTemp = Nothing
                        dtResult.Dispose() : dtResult = Nothing
                        Me.lblInfo2.ForeColor = Color.Red
                        Me.lblInfo2.Text = "检查活动卡对应的销售单失败！"
                        Me.btnNext.Enabled = False
                        Me.btnPrevious.Select()
                        DB.Close() : Me.Cursor = Cursors.Default : Return
                    End If

                    dtResult = DB.GetDataTable("Exec GetSalesBillInfo " & frmMain.sLoginUserID)
                    DB.Close()

                    If dtResult Is Nothing Then
                        dtTemp.Dispose() : dtTemp = Nothing
                        Me.lblInfo2.ForeColor = Color.Red
                        Me.lblInfo2.Text = "检查活动卡对应的销售单时出现数据库内部错误！"
                        Me.btnNext.Enabled = False
                        Me.btnPrevious.Select()
                        Me.Cursor = Cursors.Default : Return
                    End If

                    Dim newCard As DataRow, iCard As Integer = 0
                    For Each drCUL As DataRow In dtTemp.Rows
                        If dtResult.Select("CardNo='" & drCUL("CardNo").ToString & "'", "SalesBillID Desc,SalesBillDetailID").Length = 0 Then
                            iCard += 1
                            newCard = dtList2.Rows.Add(iCard)
                            newCard("CardNo") = drCUL("CardNo").ToString
                            newCard("CardState") = drCUL("CardState").ToString
                            newCard("Balance") = drCUL("Balance")
                            newCard("CheckResult") = "不可撤销"
                            If drCUL("CardState").ToString = "已激活" Then
                                If drCUL("Balance") = 0 Then
                                    newCard("ResultReason") = "卡余额为零！"
                                Else
                                    newCard("ResultReason") = "找不到销售单！"
                                End If
                            Else
                                newCard("ResultReason") = "卡状态不正确！"
                            End If
                            newCard.EndEdit()
                        Else
                            For Each drCard As DataRow In dtResult.Select("CardNo='" & drCUL("CardNo").ToString & "'", "SalesBillID Desc,SalesBillDetailID")
                                iCard += 1
                                newCard = dtList2.Rows.Add(iCard)
                                newCard("CardNo") = drCUL("CardNo").ToString
                                newCard("CardState") = drCUL("CardState").ToString
                                newCard("Balance") = drCUL("Balance")
                                newCard("SalesBillCode") = drCard("SalesBillCode").ToString
                                newCard("FaceValue") = drCard("FaceValue")
                                newCard("CardType") = drCard("CardType").ToString
                                newCard("StoreName") = drCard("StoreName").ToString
                                If drCard("ActivationState") = 3 Then
                                    If drCUL("Balance") < drCard("FaceValue") Then
                                        newCard("CheckResult") = "不可撤销"
                                        If drCUL("Balance") = 0 Then
                                            newCard("ResultReason") = "卡余额为零！"
                                        Else
                                            newCard("ResultReason") = "卡余额不足！"
                                        End If
                                    Else
                                        newCard("CheckResult") = "可以撤销"
                                    End If
                                Else
                                    newCard("CheckResult") = "不可撤销"
                                    newCard("ResultReason") = "已被撤销！"
                                End If
                                newCard("StoreID") = drCard("StoreID").ToString
                                newCard("SalesBillID") = drCard("SalesBillID").ToString
                                newCard("SalesBillDetailID") = drCard("SalesBillDetailID").ToString
                                newCard.EndEdit()
                            Next
                        End If
                    Next

                    dtTemp.Dispose() : dtTemp = Nothing
                    dtResult.Dispose() : dtResult = Nothing
                    dtList2.AcceptChanges()
                    With Me.dgvList2.Columns("StoreName")
                        .MinimumWidth = 2
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .MinimumWidth = .Width
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    End With
                    If dtList2.Select("Isnull(ResultReason,'')<>''").Length > 0 Then
                        With Me.dgvList2.Columns("ResultReason")
                            .Visible = True
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        End With
                    End If

                    iCards = dtList2.DefaultView.ToTable(True, "CardNo", "CheckResult").Select("Isnull(CheckResult,'')='可以撤销'").Length
                    If iCards = 0 Then
                        Me.lblInfo2.ForeColor = Color.Red
                        Me.lblInfo2.Text = "查询结束。没有可以撤销激活的活动卡！"
                    Else
                        blStep2OK = True
                        If iCards < dtList1.Compute("Sum(CardQTY)", "") Then
                            Me.lblInfo2.Text = "查询结束。共有 " & Format(iCards, "#,0") & " 张活动卡可以撤销激活，其它卡不可撤销。请按""下一步""选择需要进行激活撤销操作的活动卡对应的销售单号。"
                        Else
                            Me.lblInfo2.Text = "查询结束。该" & IIf(iCards = 1, "张", "批（共 " & Format(iCards, "#,0") & " 张）") & "活动卡可以撤销激活。请按""下一步""选择需要进行激活撤销操作的活动卡对应的销售单号。"
                        End If

                        iCards = dtList1.Compute("Sum(CardQTY)", "")
                        Me.lblInfo1.Text = "共输入了 " & Format(iCards, "#,0") & " 张卡。如果卡号输入完毕，请按""下一步""查看该" & IIf(iCards = 1, "张", "批") & "活动卡的状态及其对应的销售单。"
                    End If

                    Me.Cursor = Cursors.Default
                End If

                Me.btnNext.Enabled = blStep2OK
                Me.btnFinish.Enabled = (blStep4OK AndAlso Not blStep5OK)

                Me.dgvList2.Select()
                If Me.btnNext.Enabled Then
                    Me.btnNext.Select()
                Else
                    Me.btnPrevious.Select()
                End If
            Case 2
                bStep = 3
                Me.pnlStep1.Visible = False
                Me.pnlStep2.Visible = False
                Me.pnlStep3.Visible = True
                Me.pnlStep4.Visible = False

                Me.btnStart.Enabled = True
                Me.btnPrevious.Enabled = True

                If dtList3.Rows.Count = 0 Then
                    Me.lblInfo3.ForeColor = SystemColors.ControlText
                    Me.lblInfo3.Text = "请选择需要进行激活撤销操作的活动卡对应的销售单号，然后按""下一步""输入撤销原因……"

                    Dim iCard As Integer = 0, newCard As DataRow
                    For Each drCard As DataRow In dtList2.Select("CheckResult='可以撤销'", "RowID")
                        iCard += 1
                        newCard = dtList3.Rows.Add(iCard)
                        newCard("CardNo") = drCard("CardNo").ToString
                        newCard("CardState") = drCard("CardState").ToString
                        newCard("Balance") = drCard("Balance")
                        newCard("SalesBillCode") = drCard("SalesBillCode").ToString
                        newCard("FaceValue") = drCard("FaceValue").ToString
                        newCard("CardType") = drCard("CardType").ToString
                        newCard("StoreName") = drCard("StoreName").ToString
                        newCard("Selected") = 0
                        newCard("AvailableBalance") = drCard("Balance").ToString
                        newCard("StoreID") = drCard("StoreID")
                        newCard("SalesBillID") = drCard("SalesBillID")
                        newCard("SalesBillDetailID") = drCard("SalesBillDetailID")
                    Next
                    dtList3.AcceptChanges()
                End If

                Me.btnNext.Enabled = blStep3OK
                Me.btnFinish.Enabled = (blStep4OK AndAlso Not blStep5OK)

                If blStep5OK Then
                    Me.dgvList3.Select()
                    Me.btnNext.Select()
                Else
                    Me.dgvList3.Select()
                    If Me.dgvList3.CurrentRow IsNot Nothing Then
                        Me.dgvList3.CurrentRow.Selected = True
                    Else
                        Me.dgvList3("StartCardNo", 0).Selected = True
                        Me.dgvList3.Rows(0).Selected = True
                    End If
                End If
            Case 3
                bStep = 4
                Me.pnlStep1.Visible = False
                Me.pnlStep2.Visible = False
                Me.pnlStep3.Visible = False
                Me.pnlStep4.Visible = True

                Me.btnStart.Enabled = True
                Me.btnPrevious.Enabled = True

                If blStep5OK Then
                    Me.btnPrevious.Select()
                Else
                    Dim iSelectedCards As Integer = dtList3.Select("Selected=1").Length, dmSelectedAMT As Decimal = 0
                    Try
                        dmSelectedAMT = dtList3.Compute("Sum(FaceValue)", "Selected=1")
                    Catch
                    End Try

                    Me.pnlAfter.Visible = False
                    If Me.txbReason.Text.Trim = "" Then
                        Me.lblInfo4.Text = "请在上面输入需要进行激活撤销操作的原因，然后按""完成""按钮保存本次的申请……"
                    Else
                        Me.lblInfo4.Text = "请按""完成""按钮保存本次的申请。"
                    End If

                    blStep4OK = (Me.txbReason.Text.Trim <> "")
                    Me.txbReason.Select() : Me.txbReason.SelectAll()
                End If

                Me.btnNext.Enabled = False
                Me.btnFinish.Enabled = (blStep4OK AndAlso Not blStep5OK)
        End Select
    End Sub

    Private Sub btnFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinish.Click
        Me.Cursor = Cursors.WaitCursor
        Me.lblInfo4.ForeColor = SystemColors.ControlText
        Me.lblInfo4.Text = "正在保存活动卡激活撤销申请记录……"
        Me.Refresh()

        If dtList4.Rows.Count = 0 Then
            Dim newCard As DataRow, iCard As Integer = 0

            For Each drCard As DataRow In dtList3.Select("Selected=1", "RowID")
                iCard += 1
                newCard = dtList4.Rows.Add(iCard)
                newCard("CardNo") = drCard("CardNo").ToString
                newCard("CardState") = drCard("CardState").ToString
                newCard("Balance") = drCard("Balance")
                newCard("SalesBillCode") = drCard("SalesBillCode").ToString
                newCard("FaceValue") = drCard("FaceValue")
                newCard("CardType") = drCard("CardType").ToString
                newCard("StoreName") = drCard("StoreName").ToString
                newCard("StoreID") = drCard("StoreID")
                newCard("SalesBillID") = drCard("SalesBillID")
                newCard("SalesBillDetailID") = drCard("SalesBillDetailID")
            Next
        End If

        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            Me.lblInfo4.ForeColor = Color.Red
            Me.lblInfo4.Text = "系统因连接不到数据库而无法保存活动卡激活撤销申请记录。请检查数据库连接。"
            Me.Cursor = Cursors.Default
            Return
        End If

        If DB.ModifyTable("Select RowID,CardNo,CardState,Balance,SalesBillCode,FaceValue,CardType,StoreName,StoreID,SalesBillID,SalesBillDetailID,Convert(nvarchar(50),Null) As FailureReason Into #tempCard From CULCancelActivation Where 1=2") = -1 Then
            Me.lblInfo4.ForeColor = Color.Red
            Me.lblInfo4.Text = "保存活动卡激活撤销申请记录失败！"
            DB.Close() : Me.Cursor = Cursors.Default : Return
        End If

Submit_Again:
        If DB.BulkCopyTable("#tempCard", dtList4.DefaultView.ToTable(False, "RowID", "CardNo", "CardState", "Balance", "SalesBillCode", "FaceValue", "CardType", "StoreName", "StoreID", "SalesBillID", "SalesBillDetailID", "FailureReason")) = -1 Then
            Me.lblInfo4.ForeColor = Color.Red
            Me.lblInfo4.Text = "保存活动卡激活撤销申请记录失败！"
            DB.Close() : Me.Cursor = Cursors.Default : Return
        End If

        Dim dtResult As DataTable = DB.GetDataTable("Exec CULCancelActivationRequest " & dtList4.Rows.Count.ToString & ",'" & Me.txbReason.Text.Trim.Replace("'", "''") & "','" & frmMain.sLoginUserRealName.Replace("'", "''") & "'," & frmMain.sSSID)
        If dtResult Is Nothing Then
            Me.lblInfo4.ForeColor = Color.Red
            Me.lblInfo4.Text = "保存活动卡激活撤销申请记录时出现数据库内部错误！"
            Me.Cursor = Cursors.Default : Return
        End If

        If dtResult.Rows(0)("Result").ToString = "Missing" Then GoTo Submit_Again
        DB.Close()

        If dtResult.Rows(0)("Result").ToString = "Error" Then
            Me.lblInfo4.ForeColor = Color.Red
            Me.lblInfo4.Text = "保存活动卡激活撤销申请记录时出现数据库内部错误！"
            MessageBox.Show("系统无法保存活动卡激活撤销申请记录！下面是数据库的内部错误提示：    " & Chr(13) & Chr(13) & dtResult.Rows(0)("ErrorInfo").ToString & Space(4) & Chr(13) & Chr(13) & "请重试。如果仍有问题，请联系软件开发人员。    ", "保存活动卡激活撤销申请记录时出现数据库内部错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Cursor = Cursors.Default : Return
        End If

        Me.lblReason.Text = "撤销原因："
        Me.txbReason.ReadOnly = True
        Me.txbReason.BackColor = SystemColors.Window
        Me.txbReason.BackColor = SystemColors.Control

        Dim sInfo As String
        Me.pnlAfter.Visible = True
        If dtResult.Rows(0)("Result").ToString = "Nothing" Then
            For Each drCard As DataRow In dtResult.Rows
                dtList4.Rows(drCard("RowID") - 1)("AddedResult") = "申请失败！"
                dtList4.Rows(drCard("RowID") - 1)("FailureReason") = drCard("FailureReason").ToString
            Next
            Me.dgvList4.Columns("FailureReason").Visible = True
            Me.lblInfo4.ForeColor = Color.Red
            sInfo = "没有任何卡可以加入激活撤销申请！按""开始""执行新的操作，或按""关闭""结束操作。"
            Me.lblResult.Text = "没有任何卡可以加入激活撤销申请："
        ElseIf dtResult.Rows(0)("Result").ToString = "AllOK" Then
            For Each drCard As DataRow In dtList4.Rows
                drCard("AddedResult") = "申请成功"
            Next
            sInfo = "已将" & IIf(dtList4.Rows.Count = 1, "该张", "全部") & "活动卡共 " & Format(dtList4.Compute("Sum(FaceValue)", ""), "#,0.00").Replace(".00", "") & " 元加入激活撤销申请。按""开始""执行新的操作，或按""关闭""结束操作。"
            Me.lblResult.Text = "本次的激活撤销申请已保存。如果想撤销本次的申请，请打开历史记录窗口，在该窗口选择并删除本次申请即可。"
            Me.btnHistory.Enabled = True
        Else
            For Each drCard As DataRow In dtResult.Rows
                If drCard("FailureReason").ToString = "" Then
                    dtList4.Rows(drCard("RowID") - 1)("AddedResult") = "申请成功"
                Else
                    dtList4.Rows(drCard("RowID") - 1)("AddedResult") = "申请失败！"
                    dtList4.Rows(drCard("RowID") - 1)("FailureReason") = drCard("FailureReason").ToString
                End If
            Next
            Me.dgvList4.Columns("FailureReason").Visible = True
            sInfo = "已将 " & Format(dtList4.DefaultView.ToTable(True, "CardNo", "AddedResult").Select("AddedResult='申请成功'").Length, "#,0") & " 张卡共 " & Format(dtList4.Compute("Sum(FaceValue)", "AddedResult='申请成功'"), "#,0.00").Replace(".00", "") & " 元加入激活撤销申请。按""开始""执行新的操作，或按""关闭""结束操作。"
            Me.lblResult.Text = "本次的激活撤销申请已保存。如果想撤销本次的申请，请打开历史记录窗口，在该窗口选择并删除本次申请即可。"
            Me.btnHistory.Enabled = True
        End If
        With Me.dgvList4.Columns("StoreName")
            .MinimumWidth = 2
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .MinimumWidth = .Width
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        If Me.dgvList4.Columns("FailureReason").Visible = True Then
            With Me.dgvList4.Columns("FailureReason")
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
        End If

        dtList1.AcceptChanges()
        dtList2.AcceptChanges()
        dtList3.AcceptChanges()
        dtList4.AcceptChanges()

        dtList1.Select("RowID=" & Me.dgvList1("RowID", Me.dgvList1.RowCount - 1).Value.ToString)(0).Delete()
        Me.dgvList1.ReadOnly = True
        Me.dgvList1.DefaultCellStyle.BackColor = SystemColors.Control
        Me.lblInfo1.Text = "共输入了 " & Format(dtList1.Compute("Sum(CardQTY)", ""), "#,0") & " 张卡。"

        Me.dgvList2.DefaultCellStyle.BackColor = SystemColors.Control
        Me.lblInfo2.Text = "共有 " & Format(dtList2.DefaultView.ToTable(True, "CardNo", "CheckResult").Select("Isnull(CheckResult,'')='可以撤销'").Length, "#,0") & " 张卡可以激活撤销。"

        Me.dgvList3.DefaultCellStyle.BackColor = SystemColors.Control
        Me.lblInfo3.Text = "共选择了 " & Format(dtList3.DefaultView.ToTable(True, "CardNo", "Selected").Select("Selected=1").Length, "#,0") & " 张卡，共 " & Format(dtList3.Compute("Sum(FaceValue)", "Selected=1"), "#,0.00").Replace(".00", "") & " 元。"

        'modify code 014:start-------------------------------------------------------------------------
        'Dim dvCard As DataView = dtList4.Copy.DefaultView
        'dvCard.RowFilter = "AddedResult='申请成功'"
        Dim dvCard_tmp As DataView = dtList4.Copy.DefaultView
        dvCard_tmp.RowFilter = "AddedResult='申请成功'"
        Dim dvCard As DataView = dvCard_tmp
        'modify code 014:end-------------------------------------------------------------------------
        If dvCard.Count > 0 Then
            Me.lblInfo3.Text = "为确保已申请激活撤销的活动卡不被消费，正对这" & IIf(dvCard.Count = 1, "张", "些") & "活动卡执行冻结操作……"
            Me.Refresh()
            Dim iSucesses As Integer = 0
            dvCard.RowFilter = "CardNo Like '2%'"
            If dvCard.Count > 0 Then iSucesses = ShoppingCardOperation.CRFCardAutoFreeze(True, dvCULParameter.Table, dvCard.ToTable(True, "CardNo"))
            dvCard.RowFilter = "CardNo Not Like '2%'"
            If dvCard.Count > 0 Then iSucesses += ShoppingCardOperation.PaperCardAutoFreeze(True, dvCULParameter.Table, dvCard.ToTable(True, "CardNo"))
            If iSucesses = 0 Then
                MessageBox.Show("系统在对已申请激活撤销的活动卡执行自动冻结时失败！    " & Chr(13) & Chr(13) & "为确保这" & IIf(dvCard.Count = 1, "张", "些") & "活动卡不被消费，请您手工执行冻结操作。    ", "活动卡自动冻结失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf iSucesses < dvCard.Count Then
                MessageBox.Show("系统在对已申请激活撤销的活动卡执行自动冻结时部分失败！    " & Chr(13) & Chr(13) & "为确保这" & IIf(dvCard.Count - iSucesses = 1, "张", "些") & "活动卡不被消费，请您手工执行冻结操作。    ", "活动卡自动冻结失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
        dvCard.Dispose() : dvCard = Nothing

        dtResult.Dispose() : dtResult = Nothing
        Me.lblInfo4.Text = sInfo
        blStep5OK = True

        Me.btnFinish.Enabled = False
        Me.btnCancel.Text = "关闭(&C)"
        Me.dgvList4.Select()
        Me.btnPrevious.Select()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistory.Click
        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在打开活动卡""激活撤销""历史记录窗口……"
        frmMain.statusMain.Refresh()

        If frmCancelMKTActivationHistory.ShowDialog() = Windows.Forms.DialogResult.Ignore Then Me.btnHistory.Enabled = False
        frmCancelMKTActivationHistory.Dispose()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CardNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If editingCardNo IsNot Nothing AndAlso editingCardNo.SelectedText.Length = editingCardNo.Text.Length Then
                blSkipDeal = True
                Me.dgvList1.CurrentCell.Value = "" : editingCardNo.Text = ""
                blSkipDeal = False
            End If
            Dim sValue As String = ""
            If editingCardNo IsNot Nothing Then sValue = editingCardNo.Text
            If sValue.Length = 17 AndAlso sValue.IndexOf("2") <> 0 AndAlso editingCardNo.SelectedText.Length = 0 Then e.SuppressKeyPress = True
            Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub CardNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If blSkipDeal Then Return
        If editingCardNo Is Nothing Then Return
        editingCardNo.ForeColor = SystemColors.ControlText
    End Sub

    Private Sub ConfigCardRow()
        Dim iRows As Integer = Me.dgvList1.RowCount - 1, iCurrentRow As Integer = Me.dgvList1.CurrentRow.Index, sStartCard As String = Me.dgvList1(1, iCurrentRow).Value.ToString, sEndCard As String = Me.dgvList1(2, iCurrentRow).Value.ToString
        If sStartCard > sEndCard Then
            Me.dgvList1.EndEdit() : sStartCard = sEndCard : sEndCard = Me.dgvList1(1, iCurrentRow).Value.ToString
            Me.dgvList1(1, iCurrentRow).Value = sStartCard : Me.dgvList1(2, iCurrentRow).Value = sEndCard
        End If

        Dim dtNew As DataTable = dtList1.Copy, sStart As String, sEnd As String, iCardQTY As Integer = 0, drCard As DataRow, blNeedResetRow As Boolean = False
        dtNew.Rows.Clear()
        dtNew.Columns.Add("NewRowID", System.Type.GetType("System.Int16"))
        If sStartCard.IndexOf("2") = 0 Then
            For iRow As Integer = 0 To iRows
                If iRow <> iCurrentRow AndAlso Me.dgvList1(1, iRow).Value.ToString <> "" AndAlso Me.dgvList1("CardQTY", iRow).Value <> 0 Then
                    sStart = Me.dgvList1(1, iRow).Value.ToString : sEnd = Me.dgvList1(2, iRow).Value.ToString
                    If sStart.IndexOf("8") = 0 OrElse sStart.IndexOf("9") = 0 Then '纸券行,保留该行
                        drCard = dtNew.Rows.Add()
                        drCard("RowID") = iRow + 1
                        drCard("NewRowID") = 0
                        drCard("StartCardNo") = sStart
                        drCard("EndCardNo") = sEnd
                        drCard("CardQTY") = Me.dgvList1("CardQTY", iRow).Value
                        drCard.EndEdit()
                    ElseIf sStartCard > sEnd OrElse sEndCard < sStart Then '该行卡号范围落在当前修改行之外,保留该行
                        drCard = dtNew.Rows.Add()
                        drCard("RowID") = iRow + 1
                        drCard("NewRowID") = 0
                        drCard("StartCardNo") = sStart
                        drCard("EndCardNo") = sEnd
                        drCard("CardQTY") = Me.dgvList1("CardQTY", iRow).Value
                        drCard.EndEdit()
                    ElseIf sStartCard < sStart AndAlso sEnd < sEndCard Then '该行卡号范围完全落在当前修改行之内,将被删除
                        blNeedResetRow = True
                    Else '该行卡号范围部分落在当前修改行之内,将被截断
                        Dim dtTemp As New DataTable
                        dtTemp.Columns.Add("CardNo", System.Type.GetType("System.String"))
                        Dim dvTemp As New DataView(dtTemp), drTemp As DataRowView
                        sStart = sStart.Substring(0, 18)
                        iCardQTY = Me.dgvList1("CardQTY", iRow).Value - 1
                        For iCard As Integer = 0 To iCardQTY
                            sEnd = (CLng(sStart) + iCard).ToString
                            If sEnd < sStartCard.Substring(0, 18) OrElse sEnd > sEndCard.Substring(0, 18) Then
                                drTemp = dvTemp.AddNew()
                                drTemp(0) = sEnd
                                drTemp.EndEdit()
                            End If
                        Next
                        dtTemp.AcceptChanges()

                        If dvTemp.Count > 0 Then
                            dvTemp.Sort = "CardNo"
                            sStart = dvTemp(0)("CardNo").ToString : sEnd = sStart : iCardQTY = 1
                            For iCard As Integer = 1 To dvTemp.Count - 1
                                If CLng(dvTemp(iCard)("CardNo").ToString) - CLng(sEnd) = 1 Then
                                    iCardQTY += 1
                                    sEnd = dvTemp(iCard)("CardNo").ToString
                                Else
                                    drCard = dtNew.Rows.Add()
                                    drCard("RowID") = iRow + 1
                                    drCard("NewRowID") = iCard - 1
                                    drCard("StartCardNo") = ShoppingCardNo.GetFullCardNo(sStart)
                                    drCard("EndCardNo") = ShoppingCardNo.GetFullCardNo(sEnd)
                                    drCard("CardQTY") = iCardQTY
                                    drCard.EndEdit()

                                    sStart = dvTemp(iCard)("CardNo").ToString
                                    sEnd = sStart
                                    iCardQTY = 1
                                End If
                            Next
                            drCard = dtNew.Rows.Add()
                            drCard("RowID") = iRow + 1
                            drCard("NewRowID") = dvTemp.Count
                            drCard("StartCardNo") = ShoppingCardNo.GetFullCardNo(sStart)
                            drCard("EndCardNo") = ShoppingCardNo.GetFullCardNo(sEnd)
                            drCard("CardQTY") = iCardQTY
                            drCard.EndEdit()
                        End If
                        dtTemp.Dispose() : dtTemp = Nothing : dvTemp.Dispose() : dvTemp = Nothing
                        blNeedResetRow = True
                    End If
                End If
            Next
        Else
            For iRow As Integer = 0 To iRows
                If iRow <> iCurrentRow AndAlso Me.dgvList1(1, iRow).Value.ToString <> "" AndAlso Me.dgvList1("CardQTY", iRow).Value <> 0 Then
                    sStart = Me.dgvList1("StartCardNo", iRow).Value.ToString : sEnd = Me.dgvList1("EndCardNo", iRow).Value.ToString
                    If sStart.IndexOf("2") = 0 Then '塑料卡行,保留该行
                        drCard = dtNew.Rows.Add()
                        drCard("RowID") = iRow + 1
                        drCard("NewRowID") = 0
                        drCard("StartCardNo") = sStart
                        drCard("EndCardNo") = sEnd
                        drCard("CardQTY") = Me.dgvList1("CardQTY", iRow).Value
                        drCard.EndEdit()
                    ElseIf sStartCard > sEnd OrElse sEndCard < sStart Then '该行卡号范围落在当前修改行之外,保留该行
                        drCard = dtNew.Rows.Add()
                        drCard("RowID") = iRow + 1
                        drCard("NewRowID") = 0
                        drCard("StartCardNo") = sStart
                        drCard("EndCardNo") = sEnd
                        drCard("CardQTY") = Me.dgvList1("CardQTY", iRow).Value
                        drCard.EndEdit()
                    ElseIf sStartCard < sStart AndAlso sEnd < sEndCard Then '该行卡号范围完全落在当前修改行之内,将被删除
                        blNeedResetRow = True
                    Else '该行卡号范围部分落在当前修改行之内,将被截断
                        Dim dtTemp As New DataTable
                        dtTemp.Columns.Add("CardNo", System.Type.GetType("System.String"))
                        Dim dvTemp As New DataView(dtTemp), drTemp As DataRowView
                        iCardQTY = Me.dgvList1("CardQTY", iRow).Value - 1
                        For iCard As Integer = 0 To iCardQTY
                            sEnd = (CLng(sStart) + iCard).ToString
                            If sEnd < sStartCard OrElse sEnd > sEndCard Then
                                drTemp = dvTemp.AddNew()
                                drTemp(0) = sEnd
                                drTemp.EndEdit()
                            End If
                        Next
                        dtTemp.AcceptChanges()

                        If dvTemp.Count > 0 Then
                            dvTemp.Sort = "CardNo"
                            sStart = dvTemp(0)("CardNo").ToString : sEnd = sStart : iCardQTY = 1
                            For iCard As Integer = 1 To dvTemp.Count - 1
                                If CLng(dvTemp(iCard)("CardNo").ToString) - CLng(sEnd) = 1 Then
                                    iCardQTY += 1
                                    sEnd = dvTemp(iCard)("CardNo").ToString
                                Else
                                    drCard = dtNew.Rows.Add()
                                    drCard("RowID") = iRow + 1
                                    drCard("NewRowID") = iCard - 1
                                    drCard("StartCardNo") = sStart
                                    drCard("EndCardNo") = sEnd
                                    drCard("CardQTY") = iCardQTY
                                    drCard.EndEdit()

                                    sStart = dvTemp(iCard)("CardNo").ToString
                                    sEnd = sStart
                                    iCardQTY = 1
                                End If
                            Next
                            drCard = dtNew.Rows.Add()
                            drCard("RowID") = iRow + 1
                            drCard("NewRowID") = dvTemp.Count
                            drCard("StartCardNo") = sStart
                            drCard("EndCardNo") = sEnd
                            drCard("CardQTY") = iCardQTY
                            drCard.EndEdit()
                        End If
                        dtTemp.Dispose() : dtTemp = Nothing : dvTemp.Dispose() : dvTemp = Nothing
                        blNeedResetRow = True
                    End If
                End If
            Next
        End If

        If blNeedResetRow Then
            drCard = dtNew.Rows.Add()
            drCard("RowID") = iCurrentRow + 1
            drCard("NewRowID") = 0
            drCard("StartCardNo") = sStartCard
            drCard("EndCardNo") = sEndCard
            If sStartCard.IndexOf("2") = 0 Then
                drCard("CardQTY") = CLng(sEndCard.Substring(0, 18)) - CLng(sStartCard.Substring(0, 18)) + 1
            Else
                drCard("CardQTY") = CLng(sEndCard) - CLng(sStartCard) + 1
            End If
            drCard.EndEdit()
            Dim bCurrentColumn As Byte = Me.dgvList1.CurrentCell.ColumnIndex
            dtList1.Rows.Clear()
            dtNew.DefaultView.Sort = "RowID,NewRowID"
            iRows = 1
            Dim newCard As DataRow
            For Each drNew As DataRow In dtNew.Rows
                drNew("RowID") = iRows
                newCard = dtList1.Rows.Add
                newCard("RowID") = iRows
                newCard("StartCardNo") = drNew("StartCardNo").ToString
                newCard("EndCardNo") = drNew("EndCardNo").ToString
                newCard("CardQTY") = drNew("CardQTY")
                iRows += 1
            Next

            For Each dr As DataGridViewRow In Me.dgvList1.Rows
                If dr.Cells("StartCardNo").Value.ToString = sStartCard Then
                    iCurrentRow = dr.Index
                    Me.dgvList1(bCurrentColumn, dr.Index).Selected = True : Exit For
                End If
            Next
        Else
            If sStartCard.IndexOf("2") = 0 Then
                Me.dgvList1("CardQTY", iCurrentRow).Value = CLng(sEndCard.Substring(0, 18)) - CLng(sStartCard.Substring(0, 18)) + 1
            Else
                Me.dgvList1("CardQTY", iCurrentRow).Value = CLng(sEndCard) - CLng(sStartCard) + 1
            End If
            If Me.dgvList1.CurrentCell.RowIndex = Me.dgvList1.RowCount - 1 Then dtList1.Rows.Add(iRows + 2)
        End If

        If Me.dgvList1("CardQTY", Me.dgvList1.RowCount - 1).Value.ToString <> "" Then dtList1.Rows.Add(Me.dgvList1.RowCount + 1)

        Me.dgvList1.EndEdit()
        dtNew.Dispose() : dtNew = Nothing
    End Sub
End Class