Public Class frmCancelMKTActivationValidation

    'modify code 033:
    'date;2014/7/24
    'auther:Hyron bjy 
    'remark:更改特殊操作用户登录验证方式为guid

    Private blCanBrowseSalesBill As Boolean = True, dvCULParameter As DataView, dtBatch As DataTable, dvList As DataView, currentBatch As DataRow, sBatchID As String = ""

    'modify code 033:start-------------------------------------------------------------------------
    Dim guIDClass As C4ShoppingCardService.GuIDClass
    'modify code 033:end-------------------------------------------------------------------------

    Private Sub frmCancelMKTActivationValidation_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub frmCancelMKTActivationValidation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        blCanBrowseSalesBill = (frmMain.dtAllowedRight.Select("RightName='SalesBillBrowse'").Length > 0)

        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打开活动卡激活撤销确认窗口。请检查数据库连接。"
            Me.Close() : Return
        End If

        Try
            dvList = DB.GetDataTable("Exec GetCULCancelMKTActivationValidating " & frmMain.sLoginUserID).DefaultView
        Catch
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开活动卡激活撤销确认窗口。请联系软件开发人员。"
            DB.Close() : Me.Close() : Return
        End Try
        DB.Close()
        dvList.Sort = "BatchID,RowID"

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

        dtBatch = dvList.ToTable(True, "BatchID", "StoreName", "RequestedReason", "RequestorName", "RequestedTime", "OperationState", "OperationReason")
        dtBatch.Columns.Add("QTY", System.Type.GetType("System.Int32"))
        dtBatch.Columns.Add("AMT", System.Type.GetType("System.Decimal"))
        dtBatch.Columns.Add("Description", System.Type.GetType("System.String"))
        For Each drBatch As DataRow In dtBatch.Rows
            dvList.RowFilter = "BatchID=" & drBatch("BatchID").ToString
            drBatch("QTY") = dvList.ToTable(True, "CardNo").Rows.Count
            drBatch("AMT") = dvList.Table.Compute("Sum(FaceValue)", "BatchID=" & drBatch("BatchID").ToString)
            drBatch("Description") = "Store: " & drBatch("StoreName").ToString & "   Date: " & Format(drBatch("RequestedTime"), "yyyy\/MM\/dd") & "   Quantity: " & Format(drBatch("QTY"), "#,0") & " Pics   Amount: " & Format(drBatch("AMT"), "#,0.00").Replace(".00", "") & " Yuan"
        Next
        If dtBatch.Rows.Count = 0 Then
            Dim newBatch As DataRow = dtBatch.Rows.Add()
            newBatch("BatchID") = -1 : newBatch("Description") = "(No any requisition)"
            newBatch.EndEdit()
        End If
        dtBatch.AcceptChanges()

        With Me.cbbBatch
            .DataSource = dtBatch
            .ValueMember = "BatchID"
            .DisplayMember = "Description"
            .SelectedIndex = 0
        End With

        dvList.RowFilter = "OperationState=1"
        For Each drCard As DataRowView In dvList
            drCard("OperationReason") = DBNull.Value
            drCard.EndEdit()
        Next
        dvList.Table.AcceptChanges()
        dvList.RowFilter = "1=2"
        With Me.dgvDetails
            .DataSource = dvList
            .Columns(0).Visible = False
            With .Columns(1)
                .HeaderText = "No."
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
            With .Columns(2)
                .HeaderText = "Card No."
                .Width = 125
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(3)
                .HeaderText = "Card Status"
                .Width = 80
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(4)
                .HeaderText = "Balance"
                .MinimumWidth = 60
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            Dim linkColomn As New DataGridViewLinkColumn
            linkColomn.DataPropertyName = "SalesBillCode"
            .Columns.RemoveAt(5)
            .Columns.Insert(5, linkColomn)
            With .Columns(5)
                .HeaderText = "Salesbill Code"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 95
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(6)
                .HeaderText = "Face Value"
                .MinimumWidth = 80
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(7)
                .HeaderText = "Card Type"
                .Width = 85
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(8)
                .HeaderText = "Cancelling AMT"
                .MinimumWidth = 85
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(9)
                .HeaderText = "Operation Result"
                .Width = 160
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .Visible = False
            End With
            With .Columns(10)
                .HeaderText = "Failure Reason"
                .Width = 160
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .Visible = False
            End With
            .Columns(11).Visible = False
            .Columns(12).Visible = False
            .Columns(13).Visible = False
            .Columns(14).Visible = False
            .Columns(15).Visible = False
            .Columns(16).Visible = False
            .Columns(17).Visible = False
            .Columns(18).Visible = False

            For bColumn As Byte = 0 To dvList.Table.Columns.Count - 1
                .Columns(bColumn).Name = dvList.Table.Columns(bColumn).ColumnName
            Next
        End With

        currentBatch = dtBatch.Select("BatchID=" & Me.cbbBatch.SelectedValue.ToString)(0)
        If currentBatch("BatchID") = -1 Then
            Me.lblNothing.Visible = True
            Me.rdbApprove.AutoCheck = False
            Me.rdbNotapprove.AutoCheck = False
            Me.btnHistory.Select()
        Else
            Me.FillDetails()
        End If

        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub cbbBatch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbBatch.SelectedIndexChanged
        If Me.dgvDetails.DataSource Is Nothing Then Return
        If sBatchID = Me.cbbBatch.SelectedValue.ToString Then Return

        currentBatch = dtBatch.Select("BatchID=" & Me.cbbBatch.SelectedValue.ToString)(0)
        Me.FillDetails()
    End Sub

    Private Sub dgvDetails_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetails.CellContentClick
        If e.RowIndex = -1 Then Return
        If Me.dgvDetails.Columns(e.ColumnIndex).Name = "SalesBillCode" Then
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
                            If .sSalesBillID <> Me.dgvDetails("SalesBillID", Me.dgvDetails.CurrentRow.Index).Value.ToString Then
                                If .blIsChanged Then
                                    Dim bAnswer As DialogResult = MessageBox.Show("是否在打开销售单之前，先保存当前销售单？    ", "当前销售单未保存！", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                                    If bAnswer = Windows.Forms.DialogResult.Cancel OrElse (bAnswer = Windows.Forms.DialogResult.Yes AndAlso Not .SaveChanges()) Then
                                        Me.Activate()
                                        frmMain.statusText.Text = "因为存在未保存销售单，所以不能打开销售单。"
                                        Return
                                    End If
                                End If
                                .sSalesBillID = Me.dgvDetails("SalesBillID", Me.dgvDetails.CurrentRow.Index).Value.ToString
                                .LoadSalesBill()
                            End If
                        Else
                            Me.Cursor = Cursors.WaitCursor
                            frmMain.statusText.Text = "正在打开销售单……"
                            frmMain.statusMain.Refresh()

                            .sSalesBillID = Me.dgvDetails("SalesBillID", Me.dgvDetails.CurrentRow.Index).Value.ToString
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
        End If
    End Sub

    Private Sub dgvDetails_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvDetails.CellFormatting
        If Me.dgvDetails.Columns(e.ColumnIndex).GetType.Name = "DataGridViewLinkColumn" Then
            If Me.dgvDetails.CurrentRow IsNot Nothing AndAlso Me.dgvDetails.CurrentRow.Index = e.RowIndex AndAlso Me.dgvDetails.CurrentRow.Selected Then
                CType(Me.dgvDetails(e.ColumnIndex, e.RowIndex), DataGridViewLinkCell).LinkColor = Color.Yellow
            Else
                CType(Me.dgvDetails(e.ColumnIndex, e.RowIndex), DataGridViewLinkCell).LinkColor = Color.Blue
            End If
        ElseIf Me.dgvDetails.Columns(e.ColumnIndex).Name = "OperationResult" OrElse Me.dgvDetails.Columns(e.ColumnIndex).Name = "OperationReason" Then
            Select Case Me.dgvDetails("OperationResult", e.RowIndex).Value.ToString
                Case "Cancellation Failure!"
                    e.CellStyle.ForeColor = Color.Red
                    e.CellStyle.SelectionForeColor = Color.Red
                Case "CUL Trouble!"
                    e.CellStyle.ForeColor = Color.Maroon
                    e.CellStyle.SelectionForeColor = Color.Yellow
            End Select
        End If
    End Sub

    Private Sub dgvDetails_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDetails.Leave
        If Me.dgvDetails.CurrentCell IsNot Nothing Then Me.dgvDetails.CurrentCell.Selected = False
        If Me.dgvDetails.CurrentRow IsNot Nothing Then Me.dgvDetails.CurrentRow.Selected = False
    End Sub

    Private Sub rdbApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbApprove.Click
        If Me.rdbApprove.AutoCheck = False OrElse Me.rdbApprove.Checked = False Then Return
        currentBatch("OperationState") = 2
        currentBatch("OperationReason") = DBNull.Value
        For Each drCard As DataRow In dvList.Table.Select("BatchID=" & currentBatch("BatchID").ToString & " And OperationState<3")
            drCard("OperationState") = 2
            drCard.EndEdit()
        Next
        Dim iSelecteds As Integer = dtBatch.Select("OperationState=2", "", DataViewRowState.ModifiedCurrent).Length
        Me.lblSelected.Text = "( " & Format(iSelecteds, "#,0") & IIf(iSelecteds = 1, " batch ", " batches ") & "selected )"
        Me.btnExcute.Enabled = True
    End Sub

    Private Sub rdbNotapprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbNotapprove.Click
        If Me.rdbNotapprove.AutoCheck = False Then Return
        If currentBatch("OperationState") = 2 AndAlso currentBatch.RowState = DataRowState.Unchanged Then Return '如果当前批已部分生效，不再可改为不确认

        If Me.rdbNotapprove.Checked Then
            Me.txbReason.Enabled = True
            Me.txbReason.Select()
            Me.txbReason.SelectAll()
            currentBatch("OperationState") = 1
            currentBatch("OperationReason") = Me.txbReason.Text.Trim
            If currentBatch("OperationReason").ToString = "" Then currentBatch.AcceptChanges()
            For Each drCard As DataRow In dvList.Table.Select("BatchID=" & currentBatch("BatchID").ToString & " And OperationState<3")
                drCard("OperationState") = 1
                drCard.EndEdit()
            Next

            Dim iSelecteds As Integer = dtBatch.Select("OperationState=2", "", DataViewRowState.ModifiedCurrent).Length
            If iSelecteds = 0 Then
                Me.lblSelected.Text = ""
                Me.btnExcute.Enabled = False
            Else
                Me.lblSelected.Text = "( " & Format(iSelecteds, "#,0") & IIf(iSelecteds = 1, " batch ", " batches ") & "selected )"
                Me.btnExcute.Enabled = True
            End If
        Else
            Me.txbReason.Enabled = False
        End If
    End Sub

    Private Sub txbReason_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbReason.TextChanged
        If Me.rdbNotapprove.AutoCheck = False Then Return
        currentBatch("OperationReason") = Me.txbReason.Text.Trim
        If currentBatch("OperationReason").ToString = "" Then currentBatch.AcceptChanges()
    End Sub

    Private Sub btnExcute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcute.Click
        Dim iCard As Integer = 0, iCards As Integer = dtBatch.Compute("Sum(QTY)", "OperationState=2"), dmAmount As Decimal = dtBatch.Compute("Sum(AMT)", "OperationState=2")
        If MessageBox.Show("您本次选择要提交到CUL执行激活撤销操作的记录汇总信息如下：    " & Chr(13) & _
                           "The summarry info what you selected to cancel activation in CUL as following:    " & Chr(13) & Chr(13) & _
                           "即将撤销的卡数 will be cancelled QTY: " & Format(iCards, "#,0") & " 张 Pieces   " & Chr(13) & Chr(13) & _
                           "涉及的撤销金额 will be cancelled AMT: " & Format(dmAmount, "#,0.00").Replace(".00", "") & " 元 Yuan    " & Chr(13) & Chr(13) & _
                           "请注意：激活撤销操作一旦提交，便不可取消！    " & Chr(13) & _
                           "Pay attention that: once you submit this operation, you will never turn it back!    " & Chr(13) & Chr(13) & _
                           "如果您确认上面信息正确无误，请按""确定""按钮继续。    " & Chr(13) & _
                           "If you are sure your operations are correctly, please press ""OK"" button to continue.    ", _
                           "请确认执行激活撤销操作 Please confirm to excute activation cancellation:", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Cancel Then Return
        Me.Refresh()

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在提交激活撤销申请记录到CUL执行激活撤销操作……"

        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法进行激活撤销操作。请检查数据库连接。"
            Me.Cursor = Cursors.Default : Return
        End If

        Dim c4Service As C4ShoppingCardService.C4ShoppingCardService = Nothing
        Dim statusClass As C4ShoppingCardService.StatusClass = Nothing, idvvClass As C4ShoppingCardService.IdvvClass = Nothing, codeMsg As C4ShoppingCardService.CodeMsg = Nothing
        Dim vstatusClass As C4ShoppingCardService.VStatusClass = Nothing, vidvvClass As C4ShoppingCardService.VIdvvClass = Nothing, vcodeMsg As C4ShoppingCardService.VCodeMsg = Nothing
        Try
            c4Service = New C4ShoppingCardService.C4ShoppingCardService()
            statusClass = New C4ShoppingCardService.StatusClass
            idvvClass = New C4ShoppingCardService.IdvvClass
            vstatusClass = New C4ShoppingCardService.VStatusClass
            vidvvClass = New C4ShoppingCardService.VIdvvClass
        Catch ex As Exception
            MessageBox.Show("因为CUL系统故障，无法进行激活撤销操作！ 下面是CUL系统的内部错误提示：    " & Chr(13) & Chr(13) & ex.Message & Space(4), "出现CUL系统故障！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "因为CUL系统故障，无法进行激活撤销操作！"
            If c4Service IsNot Nothing Then c4Service.Dispose() : c4Service = Nothing
            statusClass = Nothing : idvvClass = Nothing : vstatusClass = Nothing : vidvvClass = Nothing
            DB.Close() : Me.Cursor = Cursors.Default : Return
        End Try

        frmMain.statusRate.Visible = True
        frmMain.statusRate.Text = ""
        frmMain.statusProgress.Visible = True
        frmMain.statusProgress.Value = 0
        frmMain.statusMain.Refresh()

        Dim dtCard As New DataTable, sCardNo As String, sStartCardNo As String, sEndCardNo As String, iCardQTY As Integer, dbFaceValue As Decimal
        Dim sMerchantNo As String = "", sFailureReason As String, sSQL As String, iBatchSuccessfully As Integer = 0, iSucessfully As Integer = 0, iRow As Integer = 0
        dtCard.Columns.Add("MerchantNo", System.Type.GetType("System.String"))
        dtCard.Columns.Add("StartCardNo", System.Type.GetType("System.String"))
        dtCard.Columns.Add("EndCardNo", System.Type.GetType("System.String"))
        dtCard.Columns.Add("CardQTY", System.Type.GetType("System.Int32"))
        dtCard.Columns.Add("FaceValue", System.Type.GetType("System.Decimal"))

        iCards = dvList.Table.Select("OperationState=2").Length
        Me.dgvDetails.Columns("OperationResult").Visible = True
        Me.dgvDetails.Columns("OperationResult").Width = 160
        Me.dgvDetails.FirstDisplayedScrollingColumnIndex = Me.dgvDetails.Columns("OperationResult").Index
        Me.dgvDetails.Columns("OperationReason").Width = 160

        'modify code 033:start-------------------------------------------------------------------------
        guIDClass = New C4ShoppingCardService.GuIDClass
        guIDClass.GuID = frmMain.sGuID
        'modify code 033:end-------------------------------------------------------------------------

        For Each drBatch As DataRow In dtBatch.Select("OperationState=2", "BatchID")
            Me.cbbBatch.SelectedValue = drBatch("BatchID")
            Me.dgvDetails.Columns("OperationResult").Visible = True
            Me.dgvDetails.Select()
            iBatchSuccessfully = 0

            frmMain.statusText.Text = "正在提交激活撤销申请记录到CUL执行激活撤销操作……"
            frmMain.statusMain.Refresh()
            For Each drCard As DataRow In dvList.Table.Select("BatchID=" & drBatch("BatchID").ToString & " And OperationState=2", "RowID")
                drCard("OperationResult") = "Activation cancelling..."
                drCard("OperationReason") = DBNull.Value
                Me.dgvDetails.Refresh()
            Next

            sMerchantNo = "" : sStartCardNo = "" : sEndCardNo = "" : iCardQTY = 0 : dbFaceValue = 0
            dtCard.Rows.Clear()
            For Each drCard As DataRow In dvList.Table.Select("BatchID=" & drBatch("BatchID").ToString & " And OperationState=2 And CardNo Like '2%'", "CardNo")
                sCardNo = drCard("CardNo").ToString
                If sStartCardNo = "" Then
                    dvCULParameter.RowFilter = "AreaID=" & drCard("StoreID").ToString
                    sMerchantNo = dvCULParameter(0)("CULStoreCode").ToString
                    sStartCardNo = sCardNo
                    sEndCardNo = sCardNo
                    iCardQTY = 1
                    dbFaceValue = drCard("FaceValue")
                ElseIf CLng(sCardNo.Substring(0, 18)) - CLng(sEndCardNo.Substring(0, 18)) = 1 AndAlso dbFaceValue = drCard("FaceValue") AndAlso iCardQTY < 1000 Then
                    sEndCardNo = sCardNo
                    iCardQTY += 1
                Else
                    dtCard.Rows.Add(sMerchantNo, sStartCardNo, sEndCardNo, iCardQTY, dbFaceValue).EndEdit()
                    dvCULParameter.RowFilter = "AreaID=" & drCard("StoreID").ToString
                    sMerchantNo = dvCULParameter(0)("CULStoreCode").ToString
                    sStartCardNo = sCardNo
                    sEndCardNo = sCardNo
                    iCardQTY = 1
                    dbFaceValue = drCard("FaceValue")
                End If
            Next
            If sStartCardNo <> "" Then
                dtCard.Rows.Add(sMerchantNo, sStartCardNo, sEndCardNo, iCardQTY, dbFaceValue).EndEdit()
                dtCard.AcceptChanges()
            End If

            If dtCard.Rows.Count > 0 Then
                For Each drCards As DataRow In dtCard.Rows
                    sFailureReason = ""
                    sMerchantNo = drCards("MerchantNo").ToString
                    sStartCardNo = drCards("StartCardNo").ToString
                    sEndCardNo = drCards("EndCardNo").ToString
                    iCardQTY = drCards("CardQTY")
                    dbFaceValue = drCards("FaceValue")

                    For Each drCard As DataGridViewRow In Me.dgvDetails.Rows
                        If drCard.Cells("CardNo").Value.ToString = sStartCardNo Then iRow = drCard.Index : Exit For
                    Next

                    Me.dgvDetails("OperationResult", iRow).Selected = True
                    Me.dgvDetails.Rows(iRow).Selected = True
                    Me.dgvDetails.Refresh()

                    iCard += iCardQTY
                    frmMain.statusRate.Text = "(" & iCard.ToString & "/" & iCards.ToString & ")"
                    frmMain.statusProgress.Value = Int((iCard / iCards) * 100)
                    frmMain.statusMain.Refresh()

                    Try
                        statusClass.Type = "ICUK"
                        statusClass.UserID = sMerchantNo
                        statusClass.MerchantNo = sMerchantNo
                        statusClass.CardNoFrom = sStartCardNo
                        statusClass.CardNoTo = sEndCardNo
                        'modify code 033:start-------------------------------------------------------------------------
                        codeMsg = c4Service.status(statusClass, guIDClass)
                        'modify code 033:end-------------------------------------------------------------------------

                        If codeMsg.Code.ToUpper = "IZ" Then
                            idvvClass.MerchantNo = sMerchantNo
                            idvvClass.UserID = sMerchantNo
                            idvvClass.CardNoFrom = sStartCardNo
                            idvvClass.CardNoTo = sEndCardNo
                            idvvClass.Amount = Format(dbFaceValue, "0.00")
                            idvvClass.TotalAmount = Format(dbFaceValue * iCardQTY, "0.00")
                            idvvClass.DMerchantNo = sMerchantNo
                            'modify code 033:start-------------------------------------------------------------------------
                            codeMsg = c4Service.idvv(idvvClass, guIDClass)
                            'modify code 033:end-------------------------------------------------------------------------

                            iBatchSuccessfully += iCardQTY
                            If codeMsg.Code.ToUpper = "NZ" Then
                                For Each drCard As DataRow In dvList.Table.Select("BatchID=" & drBatch("BatchID").ToString & " And OperationState=2 And CardNo>='" & sStartCardNo & "' And CardNo<='" & sEndCardNo & "'", "CardNo")
                                    drCard("OperationResult") = "Cancellation OK."
                                    drCard("OperationState") = 4
                                    drCard.AcceptChanges()
                                Next
                                iSucessfully += iCardQTY
                            Else
                                sFailureReason = codeMsg.Msg
                                For Each drCard As DataRow In dvList.Table.Select("BatchID=" & drBatch("BatchID").ToString & " And OperationState=2 And CardNo>='" & sStartCardNo & "' And CardNo<='" & sEndCardNo & "'", "CardNo")
                                    drCard("OperationResult") = "Cancellation Failure!"
                                    drCard("OperationReason") = sFailureReason
                                    drCard("OperationState") = 3
                                    drCard.AcceptChanges()
                                Next

                                Me.dgvDetails.Columns("OperationReason").Visible = True
                                Me.dgvDetails.FirstDisplayedScrollingColumnIndex = Me.dgvDetails.Columns("OperationReason").Index
                                Me.dgvDetails.Refresh()
                            End If
                        Else
                            sFailureReason = codeMsg.Msg
                            For Each drCard As DataRow In dvList.Table.Select("BatchID=" & drBatch("BatchID").ToString & " And OperationState=2 And CardNo>='" & sStartCardNo & "' And CardNo<='" & sEndCardNo & "'", "CardNo")
                                drCard("OperationResult") = "Cancellation Failure!"
                                drCard("OperationReason") = sFailureReason
                                drCard("OperationState") = 3
                                drCard.AcceptChanges()
                            Next

                            Me.dgvDetails.Columns("OperationReason").Visible = True
                            Me.dgvDetails.FirstDisplayedScrollingColumnIndex = Me.dgvDetails.Columns("OperationReason").Index
                            Me.dgvDetails.Refresh()
                        End If

                        sSQL = "Exec CULCancelActivationValidate @BatchID=" & drBatch("BatchID").ToString & ",@StartCardNo='" & sStartCardNo & "',@EndCardNo='" & sEndCardNo & "',"
                        If sFailureReason <> "" Then sSQL = sSQL & "@OperationState=3,@OperationReason='" & sFailureReason.Replace("'", "''") & "',"
                        sSQL = sSQL & "@AuditorName='" & frmMain.sLoginUserRealName.Replace("'", "''") & "',@SSID=" & frmMain.sSSID
                        DB.ModifyTable(sSQL)
                    Catch ex As Exception
                        For Each drCard As DataRow In dvList.Table.Select("BatchID=" & drBatch("BatchID").ToString & " And OperationState=2 And CardNo>='" & sStartCardNo & "' And CardNo<='" & sEndCardNo & "'", "CardNo")
                            drCard("OperationResult") = "CUL Trouble!"
                            drCard("OperationReason") = ex.Message
                        Next
                        Me.dgvDetails.Columns("OperationReason").Visible = True
                        Me.dgvDetails.FirstDisplayedScrollingColumnIndex = Me.dgvDetails.Columns("OperationReason").Index
                    End Try
                Next

                iRow += (iCardQTY - 1)
                Me.dgvDetails("OperationResult", iRow).Selected = True
                Me.dgvDetails.Rows(iRow).Selected = True
                Me.dgvDetails.Refresh()
            End If

            sMerchantNo = "" : sStartCardNo = "" : sEndCardNo = "" : iCardQTY = 0 : dbFaceValue = 0
            dtCard.Rows.Clear()
            For Each drCard As DataRow In dvList.Table.Select("BatchID=" & drBatch("BatchID").ToString & " And OperationState=2 And CardNo Not Like '2%'", "CardNo")
                sCardNo = drCard("CardNo").ToString.Trim
                If sStartCardNo = "" Then
                    dvCULParameter.RowFilter = "AreaID=" & drCard("StoreID").ToString
                    sMerchantNo = dvCULParameter(0)("CULStoreCode").ToString
                    sStartCardNo = sCardNo
                    sEndCardNo = sCardNo
                    iCardQTY = 1
                    dbFaceValue = drCard("FaceValue")
                ElseIf CLng(sCardNo) - CLng(sEndCardNo) = 1 AndAlso dbFaceValue = drCard("FaceValue") AndAlso iCardQTY < 1000 Then
                    sEndCardNo = sCardNo
                    iCardQTY += 1
                Else
                    dtCard.Rows.Add(sMerchantNo, sStartCardNo, sEndCardNo, iCardQTY, dbFaceValue).EndEdit()
                    dvCULParameter.RowFilter = "AreaID=" & drCard("StoreID").ToString
                    sMerchantNo = dvCULParameter(0)("CULStoreCode").ToString
                    sStartCardNo = sCardNo
                    sEndCardNo = sCardNo
                    iCardQTY = 1
                    dbFaceValue = drCard("FaceValue")
                End If
            Next
            If sStartCardNo <> "" Then
                dtCard.Rows.Add(sMerchantNo, sStartCardNo, sEndCardNo, iCardQTY, dbFaceValue).EndEdit()
                dtCard.AcceptChanges()
            End If

            If dtCard.Rows.Count > 0 Then
                For Each drCards As DataRow In dtCard.Rows
                    sFailureReason = ""
                    sMerchantNo = drCards("MerchantNo").ToString
                    sStartCardNo = drCards("StartCardNo").ToString
                    sEndCardNo = drCards("EndCardNo").ToString
                    iCardQTY = drCards("CardQTY")
                    dbFaceValue = drCards("FaceValue")

                    For Each drCard As DataGridViewRow In Me.dgvDetails.Rows
                        If drCard.Cells("CardNo").Value.ToString.Trim = sStartCardNo Then iRow = drCard.Index : Exit For
                    Next

                    Me.dgvDetails("OperationResult", iRow).Selected = True
                    Me.dgvDetails.Rows(iRow).Selected = True
                    Me.dgvDetails.Refresh()

                    Try
                        iCard += iCardQTY
                        frmMain.statusRate.Text = "(" & iCard.ToString & "/" & iCards.ToString & ")"
                        frmMain.statusProgress.Value = Int((iCard / iCards) * 100)
                        frmMain.statusMain.Refresh()

                        vstatusClass.Type = "ICUK"
                        vstatusClass.UserID = sMerchantNo
                        vstatusClass.MerchantNo = sMerchantNo
                        vstatusClass.VTypeId = sStartCardNo.Substring(0, 8)
                        vstatusClass.VSeqNoFrom = sStartCardNo.Substring(8)
                        vstatusClass.VSeqNoTo = sEndCardNo.Substring(8)
                        'modify code 033:start-------------------------------------------------------------------------
                        vcodeMsg = c4Service.vstat(vstatusClass, guIDClass)
                        'modify code 033:end-------------------------------------------------------------------------

                        If vcodeMsg.Code.ToUpper = "01" Then
                            vidvvClass.MerchantNo = sMerchantNo
                            vidvvClass.UserID = sMerchantNo
                            vidvvClass.VTypeId = sStartCardNo.Substring(0, 8)
                            vidvvClass.VSeqNoFrom = sStartCardNo.Substring(8)
                            vidvvClass.VSeqNoTo = sEndCardNo.Substring(8)
                            vidvvClass.VNumber = Format(iCardQTY, "0")
                            vidvvClass.VAmount = Format(dbFaceValue, "0.00")
                            vidvvClass.VTotalAmount = Format(dbFaceValue * iCardQTY, "0.00")
                            'modify code 033:start-------------------------------------------------------------------------
                            vcodeMsg = c4Service.vidvv(vidvvClass, guIDClass)
                            'modify code 033:end-------------------------------------------------------------------------

                            iBatchSuccessfully += iCardQTY
                            If vcodeMsg.Code.ToUpper = "01" Then
                                For Each drCard As DataRow In dvList.Table.Select("BatchID=" & drBatch("BatchID").ToString & " And OperationState=2 And CardNo>='" & sStartCardNo & "  ' And CardNo<='" & sEndCardNo & "  '", "CardNo")
                                    drCard("OperationResult") = "Cancellation OK."
                                    drCard("OperationState") = 4
                                    drCard.AcceptChanges()
                                Next
                                iSucessfully += iCardQTY
                            Else
                                sFailureReason = vcodeMsg.Msg
                                For Each drCard As DataRow In dvList.Table.Select("BatchID=" & drBatch("BatchID").ToString & " And OperationState=2 And CardNo>='" & sStartCardNo & "  ' And CardNo<='" & sEndCardNo & "  '", "CardNo")
                                    drCard("OperationResult") = "Cancellation Failure!"
                                    drCard("OperationReason") = sFailureReason
                                    drCard("OperationState") = 3
                                    drCard.AcceptChanges()
                                Next

                                Me.dgvDetails.Columns("OperationReason").Visible = True
                                Me.dgvDetails.FirstDisplayedScrollingColumnIndex = Me.dgvDetails.Columns("OperationReason").Index
                                Me.dgvDetails.Refresh()
                            End If
                        Else
                            sFailureReason = vcodeMsg.Msg
                            For Each drCard As DataRow In dvList.Table.Select("BatchID=" & drBatch("BatchID").ToString & " And OperationState=2 And CardNo>='" & sStartCardNo & "  ' And CardNo<='" & sEndCardNo & "  '", "CardNo")
                                drCard("OperationResult") = "Cancellation Failure!"
                                drCard("OperationReason") = sFailureReason
                                drCard("OperationState") = 3
                                drCard.AcceptChanges()
                            Next

                            Me.dgvDetails.Columns("OperationReason").Visible = True
                            Me.dgvDetails.FirstDisplayedScrollingColumnIndex = Me.dgvDetails.Columns("OperationReason").Index
                            Me.dgvDetails.Refresh()
                        End If

                        sSQL = "Exec CULCancelActivationValidate @BatchID=" & drBatch("BatchID").ToString & ",@StartCardNo='" & sStartCardNo & "  ',@EndCardNo='" & sEndCardNo & "  ',"
                        If sFailureReason <> "" Then sSQL = sSQL & "@OperationState=3,@OperationReason='" & sFailureReason.Replace("'", "''") & "',"
                        sSQL = sSQL & "@AuditorName='" & frmMain.sLoginUserRealName.Replace("'", "''") & "',@SSID=" & frmMain.sSSID
                        DB.ModifyTable(sSQL)
                    Catch ex As Exception
                        For Each drCard As DataRow In dvList.Table.Select("BatchID=" & drBatch("BatchID").ToString & " And OperationState=2 And CardNo>='" & sStartCardNo & "  ' And CardNo<='" & sEndCardNo & "  '", "CardNo")
                            drCard("OperationResult") = "CUL Trouble!"
                            drCard("OperationReason") = ex.Message
                        Next
                        Me.dgvDetails.Columns("OperationReason").Visible = True
                        Me.dgvDetails.FirstDisplayedScrollingColumnIndex = Me.dgvDetails.Columns("OperationReason").Index
                    End Try
                Next

                iRow += (iCardQTY - 1)
                Me.dgvDetails("OperationResult", iRow).Selected = True
                Me.dgvDetails.Rows(iRow).Selected = True
                Me.dgvDetails.Refresh()
            End If

            If iBatchSuccessfully > 0 Then
                drBatch("OperationState") = 4 : drBatch.AcceptChanges()
                Me.rdbApprove.AutoCheck = False : Me.rdbNotapprove.AutoCheck = False
            End If
        Next

        c4Service.Dispose() : c4Service = Nothing : statusClass = Nothing : idvvClass = Nothing
        DB.Close()

        Me.cbbBatch.SelectedIndex = 0
        Me.dgvDetails.Columns("OperationResult").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Me.dgvDetails.Columns("OperationResult").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        If Me.dgvDetails.Columns("OperationReason").Visible = True Then
            Me.dgvDetails.Columns("OperationReason").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            Me.dgvDetails.Columns("OperationReason").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        End If

        frmMain.statusText.Text = "就绪。"
        frmMain.statusRate.Text = ""
        frmMain.statusRate.Visible = False
        frmMain.statusProgress.Value = 0
        frmMain.statusProgress.Visible = False

        Dim iSelecteds As Integer = dtBatch.Select("OperationState=2", "", DataViewRowState.ModifiedCurrent).Length
        If iSelecteds = 0 Then
            Me.lblSelected.Text = ""
            Me.btnExcute.Enabled = False
        Else
            Me.lblSelected.Text = "( " & Format(iSelecteds, "#,0") & IIf(iSelecteds = 1, " batch ", " batches ") & "selected )"
            Me.btnExcute.Enabled = True
        End If

        If Me.btnExcute.Enabled Then
            frmMain.statusText.Text = "提交激活撤销申请记录到CUL执行激活撤销操作时出现故障，请检查故障原因。"
            MessageBox.Show("CUL trouble happen when excute to cancel activation.    " & Chr(13) & Chr(13) & "Please check the trouble reason and then try again.    ", "CUL trouble happen!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf iSucessfully = 0 Then
            frmMain.statusText.Text = "已经将激活撤销记录提交到CUL系统，但激活撤销失败！"
            MessageBox.Show("Activation cancellation had been submitted to CUL, but no card successfully!    ", "Cancellation failure!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf iSucessfully < iCards Then
            frmMain.statusText.Text = "已经将激活撤销记录提交到CUL系统，但部分成功，部分卡失败！"
            MessageBox.Show("Activation cancellation had been submitted to CUL, but some cancellations failure!    ", "Some cancellations failure!！", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            frmMain.statusText.Text = "已经将激活撤销记录提交到CUL系统，并且" & IIf(iSucessfully = 1, "", "全部") & "激活撤销成功。"
            MessageBox.Show("Activation cancellation had been submitted to CUL, and " & IIf(iSucessfully = 1, "it is ", "all of them are ") & "sucessfully.    ", "Cancellation OK.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

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

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If dtBatch.GetChanges() IsNot Nothing Then
            If Me.btnExcute.Enabled Then
                If MessageBox.Show("You already selected something but not yet submit to CUL.    " & Chr(13) & Chr(13) & "Do you really want to quit without operation?    ", "Please confirm to quit:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then Me.DialogResult = Windows.Forms.DialogResult.Cancel
            ElseIf MessageBox.Show("You already don't approve something, do you save them before quit?    ", "Please confirm to save result:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                frmMain.statusText.Text = "正在保存激活销售结果……"
                frmMain.statusMain.Refresh()
                Dim DB As New DataBase
                DB.Open()
                If Not DB.IsConnected Then
                    frmMain.statusText.Text = "系统因连接不到数据库而无法进行激活撤销操作。请检查数据库连接。"
                    Me.Cursor = Cursors.Default : Return
                End If

                For Each drBatch As DataRow In dtBatch.Select("OperationState=1", "BatchID", DataViewRowState.ModifiedCurrent)
                    DB.ModifyTable("Exec CULCancelActivationValidate @BatchID=" & drBatch("BatchID").ToString & ",@OperationState=1,@OperationReason='" & drBatch("OperationReason").ToString.Replace("'", "''") & "',@AuditorName='" & frmMain.sLoginUserRealName.Replace("'", "''") & "',@SSID=" & frmMain.sSSID)
                    drBatch.AcceptChanges()
                Next

                DB.Close()
                Me.Cursor = Cursors.Default
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
        Else
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Sub FillDetails()
        sBatchID = Me.cbbBatch.SelectedValue.ToString

        Me.lblQTY.Text = Format(currentBatch("QTY"), "#,0")
        Me.lblAMT.Text = Format(currentBatch("AMT"), "#,0.00")
        Me.lblStore.Text = currentBatch("StoreName").ToString
        Me.lblPerson.Text = currentBatch("RequestorName").ToString
        Me.lblTime.Text = Format(currentBatch("RequestedTime"), "yyyy\/MM\/dd HH:mm:ss")
        Me.lblReason.Text = currentBatch("RequestedReason").ToString

        dvList.RowFilter = "BatchID=" & currentBatch("BatchID").ToString
        With Me.dgvDetails.Columns("OperationResult")
            If dvList.ToTable.Select("Isnull(OperationResult,'')<>''").Length = 0 Then
                .Visible = False
            Else
                .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End If
        End With
        With Me.dgvDetails.Columns("OperationReason")
            If dvList.ToTable.Select("Isnull(OperationReason,'')<>''").Length = 0 Then
                .Visible = False
            Else
                .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End If
        End With

        Select Case currentBatch("OperationState")
            Case 0
                Me.rdbApprove.Checked = False
                Me.rdbApprove.AutoCheck = True
                Me.rdbNotapprove.Checked = False
                Me.rdbNotapprove.AutoCheck = True
                Me.txbReason.Enabled = False
            Case 1
                Me.rdbApprove.Checked = False
                Me.rdbApprove.AutoCheck = True
                Me.rdbNotapprove.Checked = True
                Me.rdbNotapprove.AutoCheck = True
                Me.txbReason.Enabled = True
                Dim oldState As DataRowState = currentBatch.RowState
                Me.txbReason.Text = currentBatch("OperationReason").ToString
                If oldState = DataRowState.Unchanged Then currentBatch.AcceptChanges()
            Case 2
                Me.rdbApprove.Checked = True
                Me.rdbApprove.AutoCheck = True
                Me.rdbNotapprove.Checked = False
                Me.rdbNotapprove.AutoCheck = True
                Me.txbReason.Enabled = False
            Case Else
                Me.rdbApprove.Checked = True
                Me.rdbApprove.AutoCheck = False
                Me.rdbNotapprove.Checked = False
                Me.rdbNotapprove.AutoCheck = False
                Me.txbReason.Enabled = False
        End Select

        Me.dgvDetails.Select()
        Me.cbbBatch.Select()
    End Sub
End Class