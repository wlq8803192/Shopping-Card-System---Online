
'modify code 051:
'date;2016/01/08
'auther:BJY 
'remark:增加通卖卡65888

Public Class frmCheckCardResult

    Public blWhenModifyRebate As Boolean = False, blCanUse60Card As Boolean = False, blCanUse92Card As Boolean = False, blCanUse94Card As Boolean = False, blCanUsePaperCard As Boolean = False
    Private blIsClosing As Boolean = False
    'modify code 051:start-------------------------------------------------------------------------
    Public blCanUse65Card As Boolean = False
    'modify code 051:end-------------------------------------------------------------------------

    Private Sub frmCheckCardResult_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        Dim centerPoint As New Point(frmMain.Size.Width / 2, frmMain.Size.Height / 2)
        centerPoint.Offset(frmMain.Location)
        centerPoint = frmMain.PointToScreen(centerPoint)
        Dim myBounds As New Rectangle(frmMain.PointToScreen(Me.Location), Me.Size)
        If myBounds.Contains(centerPoint) Then
            Me.Location = New Point(Me.Left, centerPoint.Y + 75)
        End If
    End Sub

    Private Sub frmCheckCardResult_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing AndAlso blIsClosing = False Then
            blIsClosing = True
            Me.btnHide.PerformClick()
        End If
    End Sub

    Private Sub frmCheckCardResult_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.C AndAlso Me.dgvCard.CurrentRow IsNot Nothing AndAlso Me.dgvCard.CurrentRow.Selected Then
            My.Computer.Clipboard.SetText(Me.dgvCard("CardNo", Me.dgvCard.CurrentRow.Index).Value.ToString)
            e.SuppressKeyPress = True
        Else
            My.Computer.Clipboard.Clear()
        End If
    End Sub

    Private Sub frmCheckCardResult_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me.dgvCard
            .DataSource = frmSelling.dtLastCheckingProblemCard
            With .Columns(0)
                .HeaderText = "卡类型"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .MinimumWidth = .Width + 1
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(1)
                .HeaderText = "行号"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(2)
                .HeaderText = "卡号"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(3)
                .HeaderText = "面值"
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(4)
                .HeaderText = "可用状态"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(5)
                .HeaderText = "状态原因"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            Dim newButtonColumn As New DataGridViewButtonColumn
            With newButtonColumn
                .DataPropertyName = "Operation"
                .DefaultCellStyle.ForeColor = SystemColors.ControlText
                .DefaultCellStyle.SelectionForeColor = SystemColors.ControlText
                .DefaultCellStyle.BackColor = SystemColors.Control
                .DefaultCellStyle.SelectionBackColor = SystemColors.Control
                .DefaultCellStyle.Padding = New Padding(1)
            End With
            .Columns.RemoveAt(6)
            .Columns.Insert(6, newButtonColumn)
            With .Columns(6)
                .HeaderText = "操作"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.BackColor = SystemColors.Window
                .DefaultCellStyle.SelectionBackColor = SystemColors.Highlight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With

            For Each column As DataGridViewColumn In .Columns
                column.Name = frmSelling.dtLastCheckingProblemCard.Columns(column.Index).ColumnName
            Next

            .Height = (IIf(.RowCount > 8, 8, .RowCount) + 1) * 24 + IIf(ToolStripManager.VisualStylesEnabled, 0, 2)
        End With
        Me.lblCardQTY.Text = "（共 " & Format(Me.dgvCard.RowCount, "#,0") & " 张卡）"

        Dim sTitle As String = ""
        If frmSelling.dtLastCheckingProblemCard.Select("UsageState='不可售卖'").Length > 0 Then sTitle = "不可售卖、"
        If frmSelling.dtLastCheckingProblemCard.Select("UsageState='面值受限'").Length > 0 Then sTitle = sTitle & "面值受限、"
        If frmSelling.dtLastCheckingProblemCard.Select("UsageState='（未知）'").Length > 0 Then sTitle = sTitle & "可用状态不明确、"
        sTitle = sTitle.Substring(0, sTitle.Length - 1)
        If sTitle.LastIndexOf("、") > -1 Then sTitle = sTitle.Insert(sTitle.LastIndexOf("、"), "、").Replace("、、", "或")
        If Me.Text = "" Then Me.Text = "发现" & sTitle & "的购物卡！"
        Me.lblTitle.Text = "发现充值列表中存在" & sTitle & "的购物片！"

        Me.btnRecheck.Visible = (frmSelling.blCanRecheckCard OrElse frmSelling.dtLastCheckingProblemCard.Select("UsageState='（未知）'").Length > 0)

        Me.dgvCard.Select()
        Me.Height = Me.tlpContainer.Height + 72
        Me.Location = New Point((My.Computer.Screen.WorkingArea.Width - Me.Width) / 2, (My.Computer.Screen.WorkingArea.Height - Me.Height) / 2)
    End Sub

    Private Sub dgvCard_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvCard.CellFormatting
        If Me.dgvCard.Columns(e.ColumnIndex).Name = "UsageState" OrElse Me.dgvCard.Columns(e.ColumnIndex).Name = "UnchargableReason" Then
            Select Case Me.dgvCard("UsageState", e.RowIndex).Value.ToString
                Case "可以售卖"
                    e.CellStyle.ForeColor = Color.Green
                    e.CellStyle.SelectionForeColor = Color.Lime
                Case "不可售卖"
                    e.CellStyle.ForeColor = Color.Red
                    e.CellStyle.SelectionForeColor = Color.Brown
                Case "面值受限"
                    e.CellStyle.ForeColor = Color.Orange
                    e.CellStyle.SelectionForeColor = Color.Yellow
                Case "（未知）"
                    e.CellStyle.ForeColor = Color.Blue
                    e.CellStyle.SelectionForeColor = Color.Cyan
            End Select
        End If
    End Sub

    Private Sub dgvCard_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCard.CellContentClick
        If e.RowIndex > -1 AndAlso Me.dgvCard.Columns(e.ColumnIndex).Name = "Operation" Then
            My.Computer.Clipboard.SetText(Me.dgvCard("CardNo", e.RowIndex).Value.ToString)
        End If
    End Sub

    Private Sub dgvCard_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCard.Leave
        If Me.dgvCard.CurrentCell IsNot Nothing Then Me.dgvCard.CurrentCell.Selected = False
        If Me.dgvCard.CurrentRow IsNot Nothing Then Me.dgvCard.CurrentRow.Selected = False
    End Sub

    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnShowPrompt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowPrompt.Click
        Me.pnlOperation.Visible = Not Me.pnlOperation.Visible
        If Me.pnlOperation.Visible Then
            Me.btnShowPrompt.Text = "隐藏操作提示 ↓"
        Else
            Me.btnShowPrompt.Text = "显示操作提示 ↑"
        End If

        Me.Height = Me.tlpContainer.Height + 72
    End Sub

    Private Sub btnRecheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecheck.Click
        Me.Cursor = Cursors.Default
        Me.pnlOperation.Visible = False
        Me.Height = Me.tlpContainer.Height + 72
        Me.btnShowPrompt.Text = "显示操作提示 ↑"
        Me.btnShowPrompt.Visible = False
        Me.lblPrompt.ForeColor = Color.Blue
        Me.lblPrompt.Text = "正在重新检查购物卡的可用状态，请稍候……"
        Me.lblPrompt.Visible = True
        Me.Refresh()
        frmMain.statusText.Text = "正在重新检查购物卡的可用状态……"
        frmMain.statusMain.Refresh()

        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            Me.lblPrompt.ForeColor = Color.Red
            Me.lblPrompt.Text = "连接不到数据库！请检查数据库连接。"
            frmMain.statusText.Text = "系统因连接不到数据库而无法重新检查购物卡的可用状态。请检查数据库连接。"
            Me.Cursor = Cursors.Default
            Return
        End If

        Dim dtTempCard As New DataTable, drTempCard As DataRow, sCardNo As String, iRowCardQTY As Integer
        dtTempCard.Columns.Add("CardNo", System.Type.GetType("System.String"))
        dtTempCard.Columns.Add("FaceValue", System.Type.GetType("System.Decimal"))
        dtTempCard.Columns.Add("CardType", System.Type.GetType("System.Byte"))
        dtTempCard.Columns.Add("RowType", System.Type.GetType("System.Byte"))
        dtTempCard.Columns.Add("RowID", System.Type.GetType("System.Int16"))

        If blWhenModifyRebate Then
            For Each drRebate As DataGridViewRow In frmModifyNormalRebate.dgvRebateCard.Rows
                If drRebate.Cells("StartCardNo").Value.ToString <> "" Then
                    sCardNo = drRebate.Cells("StartCardNo").Value.ToString
                    If sCardNo.IndexOf("2") = 0 Then sCardNo = sCardNo.Substring(0, 18)
                    iRowCardQTY = drRebate.Cells("CardQTY").Value - 1
                    For iCard As Integer = 0 To iRowCardQTY
                        drTempCard = dtTempCard.Rows.Add()
                        If sCardNo.IndexOf("2") = 0 Then
                            drTempCard("CardNo") = ShoppingCardNo.GetFullCardNo((CLng(sCardNo) + iCard).ToString)
                        Else
                            drTempCard("CardNo") = (CLng(sCardNo) + iCard).ToString
                        End If
                        drTempCard("FaceValue") = drRebate.Cells("FaceValue").Value
                        drTempCard("RowType") = 2
                        drTempCard("RowID") = drRebate.Cells("RowID").Value
                    Next
                End If
            Next
        Else
            If frmSelling.drSalesBill("NormalSalesAMT") > 0 Then
                For Each drNormal As DataGridViewRow In frmSelling.dgvNormalCard.Rows
                    If drNormal.Cells("StartCardNo").Value.ToString <> "" Then
                        sCardNo = drNormal.Cells("StartCardNo").Value.ToString
                        If sCardNo.IndexOf("2") = 0 Then sCardNo = sCardNo.Substring(0, 18)
                        iRowCardQTY = drNormal.Cells("CardQTY").Value - 1
                        For iCard As Integer = 0 To iRowCardQTY
                            drTempCard = dtTempCard.Rows.Add()
                            If sCardNo.IndexOf("2") = 0 Then
                                drTempCard("CardNo") = ShoppingCardNo.GetFullCardNo((CLng(sCardNo) + iCard).ToString)
                            Else
                                drTempCard("CardNo") = (CLng(sCardNo) + iCard).ToString
                            End If
                            drTempCard("FaceValue") = drNormal.Cells("FaceValue").Value
                            drTempCard("RowType") = IIf(frmSelling.drSalesBill("SalesBillType") = 1, 1, 0)
                            drTempCard("RowID") = drNormal.Cells("RowID").Value
                        Next
                    End If
                Next
            End If
            If frmSelling.drSalesBill("RebateSalesAMT") > 0 Then
                For Each drRebate As DataGridViewRow In frmSelling.dgvRebateCard.Rows
                    If drRebate.Cells("StartCardNo").Value.ToString <> "" Then
                        sCardNo = drRebate.Cells("StartCardNo").Value.ToString
                        If sCardNo.IndexOf("2") = 0 Then sCardNo = sCardNo.Substring(0, 18)
                        iRowCardQTY = drRebate.Cells("CardQTY").Value - 1
                        For iCard As Integer = 0 To iRowCardQTY
                            drTempCard = dtTempCard.Rows.Add()
                            If sCardNo.IndexOf("2") = 0 Then
                                drTempCard("CardNo") = ShoppingCardNo.GetFullCardNo((CLng(sCardNo) + iCard).ToString)
                            Else
                                drTempCard("CardNo") = (CLng(sCardNo) + iCard).ToString
                            End If
                            drTempCard("FaceValue") = drRebate.Cells("FaceValue").Value
                            drTempCard("RowType") = 2
                            drTempCard("RowID") = drRebate.Cells("RowID").Value
                        Next
                    End If
                Next
            End If
        End If

        If DB.ModifyTable("Select Convert(varchar(19),CardNo) As CardNo,FaceValue,CardType,Convert(tinyint,0) As RowType, Convert(smallint,0) As RowID Into #tempCard From PendingActivationList Where 1=2") = -1 OrElse DB.BulkCopyTable("#tempCard", dtTempCard) = -1 Then
            Me.lblPrompt.ForeColor = Color.Red
            Me.lblPrompt.Text = "重新检查购物卡的可用状态失败！"
            frmMain.statusText.Text = "重新检查购物卡的可用状态失败！"
            dtTempCard.Dispose() : dtTempCard = Nothing
            DB.Close() : Me.Cursor = Cursors.Default : Return
        End If

        Dim dtResult As DataTable = DB.GetDataTable("Exec SalesBillCheckCardState")
        DB.Close()
        If dtResult Is Nothing Then
            Me.lblPrompt.ForeColor = Color.Red
            Me.lblPrompt.Text = "重新检查购物卡的可用状态失败！"
            frmMain.statusText.Text = "重新检查购物卡的可用状态失败！"
            dtTempCard.Dispose() : dtTempCard = Nothing
            Me.Cursor = Cursors.Default : Return
        End If

        If blWhenModifyRebate Then
            For Each drCard As DataRow In dtResult.Select("UsageState=1")
                sCardNo = drCard("CardNo").ToString
                If frmModifyNormalRebate.dtOriginalNormal.Rows.Find(sCardNo) IsNot Nothing OrElse frmModifyNormalRebate.dtOriginalRebate.Rows.Find(sCardNo) IsNot Nothing Then
                    drCard("UsageState") = 0 : drCard("UnchargableReason") = DBNull.Value : drCard.AcceptChanges()
                End If
            Next
        End If

        frmSelling.dtAllCheckedCard = dtResult.Copy
        frmSelling.dtAllCheckedCard.PrimaryKey = New DataColumn() {frmSelling.dtAllCheckedCard.Columns("CardNo")}

        Me.TopMost = False
        If frmSelling.dtAllCheckedCard.Select("UsageState=9").Length > 0 Then '如果存在状态不明确需要到银商系统查询状态的卡
            frmCheckCardFromCUL.ShowDialog()
            frmCheckCardFromCUL.Dispose()
            Me.Refresh()
        End If
        Me.TopMost = True

        frmSelling.dtLastCheckingProblemCard.Rows.Clear()
        Dim drCheckedCard As DataRow, drProblemCard As DataRow
        If blWhenModifyRebate Then
            Dim drNormalCard As DataRow, dmNormalValue As Decimal
            If frmSelling.dtAllCheckedCard.Select("CardType=2 Or UsageState>0").Length > 0 Then '如果检查结果中包含再充值卡或当次不可充值的卡，需要检查当前充值列表是否存在问题卡
                For Each drTempCard In dtTempCard.Select("", "RowType,RowID,CardNo")
                    sCardNo = drTempCard("CardNo").ToString
                    drCheckedCard = frmSelling.dtAllCheckedCard.Rows.Find(sCardNo)
                    drNormalCard = frmModifyNormalRebate.dtOriginalNormal.Rows.Find(sCardNo)
                    If drNormalCard Is Nothing Then dmNormalValue = 0 Else dmNormalValue = drNormalCard("FaceValue")
                    If (drCheckedCard("UsageState") > 0) OrElse _
                       (drCheckedCard("CardType") = 2 AndAlso dmNormalValue + drTempCard("FaceValue") + drCheckedCard("Balance") > 1000) Then
                        '该卡不可充值（如该卡已被充值、所在销售单等待取消、等待撤销充值、等待回收、等待换卡、冻结、结束或需要到银商系统查询状态等原因）
                        '或者该卡是顾客的再充值卡但未查询过卡状态及余额（需要查询）：UsageState = 9
                        '或者该卡是顾客的再充值卡且状态正确，但存在余额，并且加上本次的充值金额后已超过1000元
                        drProblemCard = frmSelling.dtLastCheckingProblemCard.Rows.Add()
                        If drNormalCard Is Nothing Then
                            drProblemCard("RowType") = Me.SetCardFeature(drTempCard("RowType"), sCardNo)
                            drProblemCard("RowID") = drTempCard("RowID").ToString
                        Else
                            drProblemCard("RowType") = "正常卡＋返点卡"
                            drProblemCard("RowID") = drNormalCard("RowID") & "+" & drTempCard("RowID").ToString
                        End If
                        drProblemCard("CardNo") = sCardNo
                        drProblemCard("FaceValue") = dmNormalValue + drTempCard("FaceValue")
                        If drCheckedCard("UsageState") = 9 Then
                            drProblemCard("UsageState") = "（未知）"
                        ElseIf drCheckedCard("UsageState") > 0 Then
                            drProblemCard("UsageState") = "不可售卖"
                        Else
                            drProblemCard("UsageState") = "面值受限"
                        End If
                        drProblemCard("UnchargableReason") = drCheckedCard("UnchargableReason").ToString
                        drProblemCard("Operation") = "拷贝卡号"
                    End If
                Next
            End If

            If frmSelling.dtLastCheckingProblemCard.Rows.Count = 0 Then
                For Each drTempCard In dtTempCard.Select("", "RowType,RowID,CardNo")
                    sCardNo = drTempCard("CardNo").ToString
                    drCheckedCard = frmSelling.dtAllCheckedCard.Rows.Find(sCardNo)
                    drNormalCard = frmModifyNormalRebate.dtOriginalNormal.Rows.Find(sCardNo)
                    If drNormalCard Is Nothing Then dmNormalValue = 0 Else dmNormalValue = drNormalCard("FaceValue")
                    drProblemCard = frmSelling.dtLastCheckingProblemCard.Rows.Add()
                    If drNormalCard Is Nothing Then
                        drProblemCard("RowType") = Me.SetCardFeature(drTempCard("RowType"), sCardNo)
                        drProblemCard("RowID") = drTempCard("RowID").ToString
                    Else
                        drProblemCard("RowType") = "正常卡＋返点卡"
                        drProblemCard("RowID") = drNormalCard("RowID") & "+" & drTempCard("RowID").ToString
                    End If
                    drProblemCard("CardNo") = sCardNo
                    drProblemCard("FaceValue") = dmNormalValue + drTempCard("FaceValue")
                    drProblemCard("UsageState") = "可以售卖"
                    Select Case drCheckedCard("CardType")
                        Case 0 '新卡
                            drProblemCard("UnchargableReason") = "该卡是新卡。"
                        Case 1 '回收卡
                            drProblemCard("UsageState") = "可以售卖"
                            drProblemCard("UnchargableReason") = "该卡是回收卡。"
                        Case Else '再充值卡
                            If drCheckedCard("Balance") = 0 Then
                                drProblemCard("UnchargableReason") = "该卡是再充值卡，但余额为零。"
                            Else
                                drProblemCard("UnchargableReason") = "该卡余额 " & Format(drCheckedCard("Balance"), "#,0.00").Replace(".00", "") & " 元，加上本次充值金额未超过 1,000 元。"
                            End If
                    End Select
                Next
            End If
        Else
            If frmSelling.dtAllCheckedCard.Select("CardType=2 Or UsageState>0").Length > 0 Then '如果检查结果中包含再充值卡或当次不可充值的卡，需要检查当前充值列表是否存在问题卡
                For Each drTempCard In dtTempCard.Select("", "RowType,RowID,CardNo")
                    sCardNo = drTempCard("CardNo").ToString
                    drCheckedCard = frmSelling.dtAllCheckedCard.Rows.Find(sCardNo)
                    If (drCheckedCard("UsageState") > 0) OrElse _
                       (drCheckedCard("CardType") = 2 AndAlso dtTempCard.Compute("Sum(FaceValue)", "CardNo='" & sCardNo & "'") + drCheckedCard("Balance") > 1000) Then
                        '该卡不可充值（如该卡已被充值、所在销售单等待取消、等待撤销充值、等待回收、等待换卡、冻结、结束或需要到银商系统查询状态等原因）
                        '或者该卡是顾客的再充值卡但未查询过卡状态及余额（需要查询）：UsageState = 9
                        '或者该卡是顾客的再充值卡且状态正确，但存在余额，并且加上本次的充值金额后已超过1000元
                        drProblemCard = frmSelling.dtLastCheckingProblemCard.Rows.Find(sCardNo)
                        If drProblemCard Is Nothing Then
                            drProblemCard = frmSelling.dtLastCheckingProblemCard.Rows.Add()
                            drProblemCard("RowType") = Me.SetCardFeature(drTempCard("RowType"), sCardNo)
                            drProblemCard("RowID") = drTempCard("RowID").ToString
                            drProblemCard("CardNo") = sCardNo
                            drProblemCard("FaceValue") = dtTempCard.Compute("Sum(FaceValue)", "CardNo='" & sCardNo & "'")
                            If drCheckedCard("UsageState") = 9 Then
                                drProblemCard("UsageState") = "（未知）"
                            ElseIf drCheckedCard("UsageState") > 0 Then
                                drProblemCard("UsageState") = "不可售卖"
                            Else
                                drProblemCard("UsageState") = "面值受限"
                            End If
                            drProblemCard("UnchargableReason") = drCheckedCard("UnchargableReason").ToString
                            drProblemCard("Operation") = "拷贝卡号"
                        Else
                            drProblemCard("RowType") = "正常卡＋返点卡"
                            drProblemCard("RowID") = drProblemCard("RowID") & "+" & drTempCard("RowID").ToString
                        End If
                    End If
                Next
            End If

            If frmSelling.dtLastCheckingProblemCard.Rows.Count = 0 Then
                For Each drTempCard In dtTempCard.Select("", "RowType,RowID,CardNo")
                    sCardNo = drTempCard("CardNo").ToString
                    drCheckedCard = frmSelling.dtAllCheckedCard.Rows.Find(sCardNo)
                    drProblemCard = frmSelling.dtLastCheckingProblemCard.Rows.Find(sCardNo)
                    If drProblemCard Is Nothing Then
                        drProblemCard = frmSelling.dtLastCheckingProblemCard.Rows.Add()
                        drProblemCard("RowType") = Me.SetCardFeature(drTempCard("RowType"), sCardNo)
                        drProblemCard("RowID") = drTempCard("RowID").ToString
                        drProblemCard("CardNo") = sCardNo
                        drProblemCard("FaceValue") = dtTempCard.Compute("Sum(FaceValue)", "CardNo='" & sCardNo & "'")
                        drProblemCard("UsageState") = "可以售卖"
                        Select Case drCheckedCard("CardType")
                            Case 0 '新卡
                                drProblemCard("UnchargableReason") = "该卡是新卡。"
                            Case 1 '回收卡
                                drProblemCard("UsageState") = "可以售卖"
                                drProblemCard("UnchargableReason") = "该卡是回收卡。"
                            Case Else '再充值卡
                                If drCheckedCard("Balance") = 0 Then
                                    drProblemCard("UnchargableReason") = "该卡是再充值卡，但余额为零。"
                                Else
                                    drProblemCard("UnchargableReason") = "该卡余额 " & Format(drCheckedCard("Balance"), "#,0.00").Replace(".00", "") & " 元，加上本次充值金额未超过 1,000 元。"
                                End If
                        End Select
                    Else
                        drProblemCard("RowType") = "正常卡＋返点卡"
                        drProblemCard("RowID") = drProblemCard("RowID") & "+" & drTempCard("RowID").ToString
                    End If
                Next
            End If
        End If
        frmSelling.dtLastCheckingProblemCard.AcceptChanges()
        dtTempCard.Dispose() : dtTempCard = Nothing

        frmSelling.sFirstCheckCardTime = Format(Now(), "yyyy\/MM\/dd HH:mm:ss")
        frmSelling.blCanRecheckCard = False
        If frmSelling.dtLastCheckingProblemCard.Select("UsageState='可以售卖'").Length = 0 Then '如果目前卡列表中存在不可充值的卡
            Dim sTitle As String = ""
            If frmSelling.dtLastCheckingProblemCard.Select("UsageState='不可售卖'").Length > 0 Then sTitle = "不可售卖、"
            If frmSelling.dtLastCheckingProblemCard.Select("UsageState='面值受限'").Length > 0 Then sTitle = sTitle & "面值受限、"
            If frmSelling.dtLastCheckingProblemCard.Select("UsageState='（未知）'").Length > 0 Then sTitle = sTitle & "可用状态不明确、"
            sTitle = sTitle.Substring(0, sTitle.Length - 1)
            If sTitle.LastIndexOf("、") > -1 Then sTitle = sTitle.Insert(sTitle.LastIndexOf("、"), "、").Replace("、、", "或")
            Me.Text = "发现" & sTitle & "的购物卡！"
            Me.lblTitle.Text = "发现充值列表中存在" & sTitle & "的购物片！"
            Me.btnShowPrompt.Visible = True
            Me.btnRecheck.Visible = (frmSelling.dtLastCheckingProblemCard.Select("UsageState='（未知）'").Length > 0)
        Else
            Me.Text = IIf(Me.dgvCard.RowCount = 1, "该购物卡可以用于本次售卖", "所有购物卡均可用于本次售卖")
            Me.lblTitle.Text = Me.Text & "。"
            Me.dgvCard.Columns("Operation").Visible = False
            Me.btnRecheck.Visible = False
        End If

        Me.lblCardQTY.Text = "（共 " & Format(Me.dgvCard.RowCount, "#,0") & " 张卡）"
        Me.lblPrompt.Visible = False
        Me.dgvCard.Height = (IIf(Me.dgvCard.RowCount > 8, 8, Me.dgvCard.RowCount) + 1) * 24 + IIf(ToolStripManager.VisualStylesEnabled, 0, 2)
        Me.Height = Me.tlpContainer.Height + 72
        Me.dgvCard.Select()
        frmMain.statusText.Text = "就绪。"
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHide.Click
        blIsClosing = True
        If blWhenModifyRebate Then
            frmModifyNormalRebate.btnShowResult.PerformClick()
        Else
            frmSelling.btnViewActivation.PerformClick()
        End If
    End Sub

    Private Function SetCardFeature(ByVal bRowType As Byte, ByVal sCardNo As String) As String
        Dim sFeature As String = ""
        Select Case bRowType
            Case 0
                If frmSelling.bNewSalesBillType = 2 Then
                    If sCardNo.IndexOf("9") = 0 Then
                        sFeature = "活动券"
                    Else
                        sFeature = "活动卡"
                    End If
                ElseIf frmSelling.bNewSalesBillType = 3 Then
                    If sCardNo.IndexOf("9") = 0 Then
                        sFeature = "公关券"
                    Else
                        sFeature = "公关卡"
                    End If
                ElseIf sCardNo.IndexOf("8") = 0 Then
                    If sCardNo.IndexOf("86") = 0 OrElse sCardNo.Substring(5, 1) = "8" OrElse sCardNo.Substring(5, 3) = "100" Then
                        sFeature = "正常卡（条码卡）"
                    Else
                        sFeature = "正常卡（充值券）"
                    End If
                Else
                    'modify code 051:start-------------------------------------------------------------------------
                    'sFeature = "正常卡" & IIf(sCardNo.IndexOf("23366") = 0, "（礼品卡）", IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard, "（磁条卡）", ""))
                    sFeature = "正常卡" & IIf(sCardNo.IndexOf("233660") = 0, "（礼品卡）", IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard OrElse blCanUse65Card, "（磁条卡）", ""))
                    'modify code 051:end-------------------------------------------------------------------------
                End If
            Case 1
                'modify code 051:start-------------------------------------------------------------------------
                'If blCanUse60Card = False AndAlso blCanUse92Card = False AndAlso blCanUse94Card = False AndAlso blCanUsePaperCard = False Then
                If blCanUse60Card = False AndAlso blCanUse92Card = False AndAlso blCanUse94Card = False AndAlso blCanUsePaperCard = False AndAlso blCanUse65Card = False Then
                    'modify code 051:end-------------------------------------------------------------------------
                    sFeature = "退货卡"
                ElseIf sCardNo.IndexOf("233694") = 0 Then
                    sFeature = "活动卡退卡"
                ElseIf sCardNo.IndexOf("233692") = 0 Then
                    sFeature = "营销卡退卡"
                    'modify code 051:start-------------------------------------------------------------------------
                    'ElseIf sCardNo.IndexOf("23366") = 0 Then
                ElseIf sCardNo.IndexOf("233660") = 0 Then
                    'modify code 051:end-------------------------------------------------------------------------
                    sFeature = "礼品卡退卡"
                Else
                    sFeature = "磁条卡退卡"
                End If
            Case Else
                If sCardNo.IndexOf("8") = 0 Then
                    If sCardNo.IndexOf("86") = 0 OrElse sCardNo.Substring(5, 1) = "8" OrElse sCardNo.Substring(5, 3) = "100" Then
                        sFeature = "返点卡（条码卡）"
                    Else
                        sFeature = "返点卡（充值券）"
                    End If
                ElseIf sCardNo.IndexOf("9") = 0 Then
                    sFeature = "返点卡（营销券）"
                Else
                    If sCardNo.Substring(4, 2) = "92" Then
                        sFeature = "返点卡（营销卡）"
                    ElseIf sCardNo.Substring(4, 2) = "60" Then
                        sFeature = "返点卡（礼品卡）"
                    Else
                        'modify code 051:start-------------------------------------------------------------------------
                        'sFeature = "返点卡" & IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard, "（磁条卡）", "")
                        sFeature = "返点卡" & IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard OrElse blCanUse65Card, "（磁条卡）", "")
                        'modify code 051:end-------------------------------------------------------------------------
                    End If
                End If
        End Select

        Return sFeature
    End Function
End Class