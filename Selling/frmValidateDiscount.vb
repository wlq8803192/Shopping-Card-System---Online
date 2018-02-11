Public Class frmValidateDiscount

    'modify code 038:
    'date;2014/9/24
    'auther:Hyron bjy 
    'remark:返点比率0.0->0.00

    'modify code 054:
    'date;2016/02/15
    'auther:BJY 
    'remark:增加65卡销售单，65/61使用新返点规则，去除051的一般销售单售卖65卡功能

    Public currentSalesBill As DataRow
    Private iAvailableRowID As Int16 = 0, sRemarks As String = ""

    Private Sub frmValidateDiscount_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim DB As New DataBase()
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法审核销售单返点。请检查数据库连接。"
            Me.Close() : Return
        End If

        'modify code 054:start-------------------------------------------------------------------------
        Dim sCityRuleDetails = "CityRuleDetails"
        If currentSalesBill("SalesBillType").ToString = "实名制卡销售单" OrElse currentSalesBill("SalesBillType").ToString = "通卖非实名卡销售单" Then
            sCityRuleDetails = "CrossSellingCityRuleDetails"
        End If

        'Dim dtRule As DataTable = DB.GetDataTable("Select * From CityRuleDetails Where RuleID=" & currentSalesBill("RebateRuleID").ToString).DefaultView.Table
        Dim dtRule As DataTable = DB.GetDataTable("Select * From " & sCityRuleDetails & " Where RuleID=" & currentSalesBill("RebateRuleID").ToString).DefaultView.Table
        'modify code 054:end-------------------------------------------------------------------------
        If dtRule Is Nothing Then
            frmMain.statusText.Text = "系统因在检索数据时出错而无法审核销售单返点。请联系软件开发人员。"
            DB.Close() : Me.Close() : Return
        End If
        If currentSalesBill("RebateState") = "审核失败" Then
            Try
                sRemarks = DB.GetDataTable("Select NormalRebateRemarks From PendingSalesBillExtra Where SalesBillID=" & currentSalesBill("SalesBillID").ToString).Rows(0)(0).ToString
            Catch
            End Try
        End If
        DB.Close()

        With Me.dgvRule
            .DataSource = dtRule
            .Columns(0).Visible = False
            .Columns(1).Visible = False
            .Columns(2).Visible = False
            With .Columns(3)
                .HeaderText = "No."
                .Width = 40
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.ForeColor = SystemColors.ControlText
                .DefaultCellStyle.BackColor = SystemColors.Control
                .DefaultCellStyle.SelectionForeColor = SystemColors.ControlText
                .DefaultCellStyle.SelectionBackColor = SystemColors.Control
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns(4)
                .HeaderText = "最小金额 ＞" & Chr(13) & "Minimal AMT"
                .Width = 85
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,0.00"
            End With
            With .Columns(5)
                .HeaderText = "最大金额 ≤" & Chr(13) & "Maximum AMT"
                .Width = 85
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,0.00"
            End With
            With .Columns(6)
                .HeaderText = "最大返点" & Chr(13) & "Max Disc %"
                .Width = 75
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'modify code 038:start-------------------------------------------------------------------------
                '.DefaultCellStyle.Format = "#,0.0"
                .DefaultCellStyle.Format = "#,0.00"
                'modify code 038:end-------------------------------------------------------------------------
            End With
            .Columns(7).Visible = False
            With .Columns(8)
                .HeaderText = "审核者（超过最大返点时）" & Chr(13) & "Who Validate if over Maximum Rate"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
        End With

        Dim dmNormalSalesAMT As Decimal = currentSalesBill("ChargedAMT") - currentSalesBill("RebateSalesAMT"), drRule As DataRow = Nothing
        For Each drRule In dtRule.Rows
            If drRule("EndSalesAMT").ToString <> "" AndAlso dmNormalSalesAMT > drRule("StartSalesAMT") - 1 AndAlso dmNormalSalesAMT <= drRule("EndSalesAMT") Then
                Exit For
            End If
        Next
        iAvailableRowID = drRule("RowID") - 1

        Me.txbNormalSalesAMT.Text = Format(dmNormalSalesAMT, "#,0.00")
        'modify code 038:start-------------------------------------------------------------------------
        'Me.txbMaxNormalRebateRate.Text = Format(drRule("MaxRebateRate"), "#,0.0")
        Me.txbMaxNormalRebateRate.Text = Format(drRule("MaxRebateRate"), "#,0.00")
        Me.txbMaxNormalRebateAMT.Text = Format(dmNormalSalesAMT * drRule("MaxRebateRate") / 100, "#,0.00")
        'Me.txbNormalRebateRate.Text = Format(currentSalesBill("RebateRate") * 100, "#,0.0")
        Me.txbNormalRebateRate.Text = Format(currentSalesBill("RebateRate") * 100, "#,0.00")
        'modify code 038:end-------------------------------------------------------------------------
        Me.txbNormalRebateAMT.Text = Format(currentSalesBill("RebateSalesAMT"), "#,0.00")
        Me.txbOverRebateAMT.Text = Format(CDec(Me.txbNormalRebateAMT.Text) - CDec(Me.txbMaxNormalRebateAMT.Text), "#,0.00")
        If currentSalesBill("RebateState") = "审核失败" Then
            Me.txbReason.Text = sRemarks
            Me.rdbFailure.Checked = True
        End If

        Dim iAdded As Integer = 36 + IIf(ToolStripManager.VisualStylesEnabled, 2, 4) + 325, iHeight As Integer = dtRule.Rows.Count * 24 + iAdded
        If iHeight > My.Computer.Screen.WorkingArea.Height Then
            iHeight = My.Computer.Screen.WorkingArea.Height
            iHeight = Int((iHeight - iAdded) / 24) * 24 + iAdded
        End If
        Me.Height = iHeight
        Me.Location = New Point(Int((My.Computer.Screen.WorkingArea.Width - Me.Width) / 2), Int((My.Computer.Screen.WorkingArea.Height - Me.Height) / 2))

        Me.dgvRule.FirstDisplayedScrollingRowIndex = iAvailableRowID
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub dgvRule_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvRule.CellFormatting
        If e.ColumnIndex > 3 AndAlso e.RowIndex = iAvailableRowID Then
            e.CellStyle.ForeColor = Color.Blue
            e.CellStyle.BackColor = Color.Yellow
            e.CellStyle.SelectionForeColor = Color.Blue
            e.CellStyle.SelectionBackColor = Color.Yellow
        End If
    End Sub

    Private Sub rdbOK_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbOK.CheckedChanged
        If Me.rdbOK.Checked Then Me.btnOK.Enabled = True
    End Sub

    Private Sub rdbFailure_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbFailure.CheckedChanged
        Me.txbReason.Enabled = Me.rdbFailure.Checked
        If Me.txbReason.Enabled Then
            Me.txbReason.Select() : Me.txbReason.SelectAll()

            If currentSalesBill("RebateState", DataRowVersion.Original) = "等待审核" OrElse sRemarks <> Me.txbReason.Text.Trim Then
                Me.btnOK.Enabled = True
            Else
                Me.btnOK.Enabled = False
            End If
        End If
    End Sub

    Private Sub txbReason_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbReason.TextChanged
        If currentSalesBill("RebateState", DataRowVersion.Original) = "等待审核" Then Return
        Me.btnOK.Enabled = (sRemarks <> Me.txbReason.Text.Trim)
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Me.rdbOK.Checked AndAlso MessageBox.Show("注意：确认审核（通过）后不再可撤消！是否确认通过？    " & Chr(13) & Chr(13) & _
                                                    "Please pay attention that:    " & Chr(13) & Chr(13) & "Once you approve the discount, it can not be cancelled any longer!    " & Chr(13) & Chr(13) & _
                                                    "Do you really want to aprrove this discount?    ", "是否确认审核（通过） Please confirm to approve discount:", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then Return

        Me.Refresh()
        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在保存审核结果……"
        frmMain.statusMain.Refresh()

        Dim DB As New DataBase()
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法保存审核结果。请检查数据库连接。"
            Me.Cursor = Cursors.Default : Return
        End If

        Dim sSQL As String = "Exec ValidateNormalRebate @SalesBillID=" & currentSalesBill("SalesBillID").ToString & ","
        If currentSalesBill("RebateState").ToString = "审核失败" Then sSQL = sSQL & "@OldRebateState=1,"
        If Me.rdbOK.Checked Then
            sSQL = sSQL & "@RebateState=3,"
        Else
            sSQL = sSQL & "@RebateState=1,"
            If Me.txbReason.Text.Trim <> "" Then sSQL = sSQL & "@NormalRebateRemarks='" & Me.txbReason.Text.Trim.Replace("'", "''") & "',"
        End If
        sSQL = sSQL & "@OperatorName='" & frmMain.sLoginUserRealName.Replace("'", "''") & "',@SSID=" & frmMain.sSSID

        Dim dtResult As DataTable = DB.GetDataTable(sSQL)
        DB.Close()

        If dtResult Is Nothing Then
            frmMain.statusText.Text = "保存审核结果失败！"
        Else
            Select Case dtResult.Rows(0)("Result").ToString
                Case "SalesBillDeleted"
                    MessageBox.Show("该销售单已被取消！审核无效。    ", "审核一般返点无效！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If frmSelling.IsHandleCreated AndAlso frmSelling.sSalesBillID = currentSalesBill("SalesBillID").ToString Then
                        frmSelling.ResetInterfaceWhenSalesBillDeleted(dtResult.Rows(0))
                    Else
                        currentSalesBill.Delete() : currentSalesBill.AcceptChanges()
                    End If
                    frmMain.statusText.Text = "当前销售单已被取消！"
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Case "SalesBillCancelled"
                    MessageBox.Show("该销售单已被申请取消！您再也不能审核该销售单的返点。    ", "审核一般返点无效！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If frmSelling.IsHandleCreated AndAlso frmSelling.sSalesBillID = currentSalesBill("SalesBillID").ToString Then
                        frmSelling.ResetInterfaceWhenSalesBillCancelled(dtResult.Rows(0))
                    Else
                        currentSalesBill("SalesBillState") = "等待取消"
                        currentSalesBill.AcceptChanges()
                    End If
                    frmMain.statusText.Text = "当前销售单已被申请取消！"
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Case "RebateStateChanged"
                    MessageBox.Show("当前销售单的返点审核状态已经发生改变！    ", "审核一般返点失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If frmSelling.IsHandleCreated AndAlso frmSelling.sSalesBillID = currentSalesBill("SalesBillID").ToString Then frmSelling.Close()

                    If frmSalesBillManagement.IsHandleCreated Then
                        Try
                            With frmSalesBillManagement
                                currentSalesBill("CardQTY") = dtResult.Rows(0)("CardQTY")
                                currentSalesBill("ChargedAMT") = dtResult.Rows(0)("ChargedAMT")
                                Select Case dtResult.Rows(0)("RebateMode")
                                    Case 0
                                        currentSalesBill("RebateMode") = "没有返点"
                                        currentSalesBill("RebateRate") = DBNull.Value
                                        currentSalesBill("RebateSalesAMT") = DBNull.Value
                                        currentSalesBill("RebateState") = DBNull.Value
                                    Case 1
                                        currentSalesBill("RebateRate") = dtResult.Rows(0)("RebateRate")
                                        currentSalesBill("RebateSalesAMT") = dtResult.Rows(0)("RebateSalesAMT")
                                        Select Case frmSelling.drSalesBill("RebateState")
                                            Case 1
                                                currentSalesBill("RebateState") = "审核失败"
                                            Case 2
                                                currentSalesBill("RebateState") = "不用审核"
                                            Case 3
                                                currentSalesBill("RebateState") = "审核成功"
                                        End Select
                                End Select
                                currentSalesBill.AcceptChanges()
                                currentSalesBill = Nothing
                            End With
                        Catch
                        End Try
                    End If

                    frmMain.statusText.Text = "当前销售单的返点审核状态已经发生改变！"
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Case "OK"
                    currentSalesBill("RebateState") = IIf(Me.rdbOK.Checked, "审核成功", "审核失败")
                    currentSalesBill.AcceptChanges()
                    frmMain.statusText.Text = "保存审核结果成功。"
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                Case Else
                    MessageBox.Show("保存审核结果时出现错误！下面是数据库的内部错误提示：    " & Chr(13) & Chr(13) & dtResult.Rows(0)("ErrorInfo").ToString & Space(4) & Chr(13) & Chr(13) & "请放弃保存，在关闭窗口后重试。如果仍有问题，请联系软件开发人员。    ", "保存销售单失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    frmMain.statusText.Text = "保存审核结果失败！"
            End Select
            dtResult.Dispose() : dtResult = Nothing
        End If
        Me.Cursor = Cursors.Default
    End Sub
End Class