Public Class frmElectronicCardFreeze

    Private dvCULParameter As DataView, dtOldState As DataTable, dtNewState As DataTable
    Private blStep1OK As Boolean = False, blStep2OK As Boolean = False, blStep3OK As Boolean = False, blStep4OK As Boolean = False
    Private bStep As Byte = 1, sStartCardNo As String = "", sEndCardNo As String = "", blIsToFreeze As Boolean = True, sMerchantNo As String = ""

    Dim guIDClass As C4ShoppingCardService.GuIDClass

    Private Sub frmFreezeCard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "60" & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "92" & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "94" & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), frmMain.signCardBin & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
        Next

        Dim DB As New DataBase(), dtResult As DataTable = Nothing
        DB.Open()
        If DB.IsConnected Then
            'select t1.ExtraCardBin,t2.AreaID,isnull(t2.CULStoreCode,0) CULStoreCode from CityExtraCardBin_ELC T1 left join AreaList T2 on t1.CityID = t2.AreaID
            'select t1.ExtraCardBin,t2.AreaID,isnull(t2.CULStoreCode,0) CULStoreCode from CityExtraCardBin_ELC T1 left join (SELECT S.AreaID,  A.ParentAreaID, A.CULStoreCode FROM AreaScope(0) AS S INNER JOIN AreaList AS A ON S.AreaID = A.AreaID) T2 on t1.CityID = t2.ParentAreaID
            dtResult = DB.GetDataTable("select t1.ExtraCardBin,t2.AreaID,isnull(t2.CULStoreCode,0) CULStoreCode from CityExtraCardBin_ELC T1 left join (SELECT S.AreaID,  A.ParentAreaID, A.CULStoreCode FROM AreaScope(" & frmMain.sLoginUserID & ") AS S INNER JOIN AreaList AS A ON S.AreaID = A.AreaID) T2 on t1.CityID = t2.ParentAreaID where T2.AreaID is not null")
            If dtResult Is Nothing Then
            ElseIf dtResult.Rows.Count > 0 Then
                For Each drCUL As DataRow In dtResult.Rows
                    dvCULParameter.Table.Rows.Add(drCUL("AreaID"), drCUL("ExtraCardBin"), drCUL("CULStoreCode")).EndEdit()
                Next
            End If
        End If
        DB.Close()

        dvCULParameter.RowFilter = ""
        dvCULParameter.Table.AcceptChanges()

        dtOldState = New DataTable
        dtOldState.Columns.Add("CardNo", System.Type.GetType("System.String"))
        dtOldState.Columns.Add("Balance", System.Type.GetType("System.Decimal"))
        dtOldState.Columns.Add("ActivatedDate", System.Type.GetType("System.DateTime"))
        dtOldState.Columns.Add("EffectiveDate", System.Type.GetType("System.DateTime"))
        dtOldState.Columns.Add("StoreName", System.Type.GetType("System.String"))
        dtOldState.Columns.Add("CardState", System.Type.GetType("System.String"))
        dtOldState.Columns.Add("Remarks", System.Type.GetType("System.String"))
        dtOldState.AcceptChanges()

        With Me.dgvOldState
            .DataSource = dtOldState
            With .Columns(0)
                .HeaderText = "卡号"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 125
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(1)
                .HeaderText = "余额"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,0.00"
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(2)
                .HeaderText = "激活日期"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Format = "yyyy\/MM\/dd"
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(3)
                .HeaderText = "有效期至"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Format = "yyyy\/MM\/dd"
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(4)
                .HeaderText = "发卡门店"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .MinimumWidth = .Width
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(5)
                .HeaderText = "卡片状态"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(6)
                .HeaderText = "备注"
                .DefaultCellStyle.ForeColor = Color.Red
                .DefaultCellStyle.SelectionForeColor = Color.Red
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .Visible = False
            End With
        End With

        dtNewState = dtOldState.Copy
        With Me.dgvNewState
            .DataSource = dtNewState
            With .Columns(0)
                .HeaderText = "卡号"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 125
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(1)
                .HeaderText = "余额"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,0.00"
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(2)
                .HeaderText = "激活日期"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Format = "yyyy\/MM\/dd"
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(3)
                .HeaderText = "有效期至"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Format = "yyyy\/MM\/dd"
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(4)
                .HeaderText = "发卡门店"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .MinimumWidth = .Width
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(5)
                .HeaderText = "卡片状态"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(6)
                .HeaderText = "备注"
                .DefaultCellStyle.ForeColor = Color.Red
                .DefaultCellStyle.SelectionForeColor = Color.Red
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .Visible = False
            End With
        End With
    End Sub

    Private Sub txbStartCardNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbStartCardNo.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then Me.txbEndCardNo.Select() : Me.txbEndCardNo.SelectAll() : e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If Me.txbStartCardNo.SelectedText = Me.txbStartCardNo.Text Then Me.txbStartCardNo.Text = ""
            Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbStartCardNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbStartCardNo.Leave
        If Me.txbStartCardNo.Text = "" Then Return
        If Me.txbStartCardNo.Text <> Me.txbStartCardNo.Text.Trim Then Me.txbStartCardNo.Text = Me.txbStartCardNo.Text.Trim
        Dim sValue As String = Me.txbStartCardNo.Text

        If sValue <> sStartCardNo Then
            If Not IsNumeric(sValue) Then
                Me.lblStartCardError.Text = "（卡号只能由数字组成！）"
            ElseIf sValue.Length < 19 Then
                Me.lblStartCardError.Text = "（卡号位数不足 19 位！）"
            ElseIf sValue <> ShoppingCardNo.GetFullCardNo(sValue.Substring(0, 18)) Then
                Me.lblStartCardError.Text = "（卡号校验码错误！）"
            ElseIf dvCULParameter.Table.Select("CULCardBin='" & sValue.Substring(4, 5) & "'").Length = 0 Then
                Me.lblStartCardError.Text = "（无权操作该卡段！）"
            Else
                sStartCardNo = sValue
            End If
        End If

        If Me.lblStartCardError.Text = "" AndAlso Me.lblEndCardError.Text = "" Then
            If sEndCardNo = "" Then
                sEndCardNo = sValue
                Me.txbEndCardNo.Text = sValue
            End If
            If sStartCardNo > sEndCardNo Then
                Me.lblCardNoError.Text = "（开始卡号不应大于结束卡号！）"
            ElseIf sStartCardNo.Substring(4, 5) <> sEndCardNo.Substring(4, 5) Then
                Me.lblCardNoError.Text = "（卡类型/卡Bin码不一致！）"
            ElseIf CULng(sEndCardNo.Substring(0, 18)) - CULng(sStartCardNo.Substring(0, 18)) + 1 > 5000 Then
                Me.lblCardNoError.Text = "（一次操作不要超过 5,000 张卡！）"
            End If
        End If

        If Me.lblStartCardError.Text = "" AndAlso Me.lblEndCardError.Text = "" AndAlso Me.lblCardNoError.Text = "" Then
            blStep1OK = True
            sMerchantNo = dvCULParameter.Table.Select("CULCardBin='" & sStartCardNo.Substring(4, 5) & "'")(0)("CULStoreCode").ToString
            If sStartCardNo = sEndCardNo Then
                Me.lblInfo1.Text = "请按""下一步""查询该张购物卡的状态……"
            Else
                Me.lblInfo1.Text = "请按""下一步""查询该批购物卡的状态……"
            End If
            Me.btnNext.Enabled = True
        End If
    End Sub

    Private Sub txbStartCardNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbStartCardNo.TextChanged
        Me.lblStartCardError.Text = ""
        Me.lblCardNoError.Text = ""
        Me.lblInfo1.Text = ""
        dtOldState.Rows.Clear()
        dtNewState.Rows.Clear()
        Me.btnStart.Enabled = False : blStep1OK = False
        Me.btnPrevious.Enabled = False : blStep2OK = False
        Me.btnNext.Enabled = False : blStep3OK = False
        Me.btnFinish.Enabled = False : Me.pnlResult.Visible = False : blStep4OK = False
    End Sub

    Private Sub txbEndCardNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbEndCardNo.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then Me.txbStartCardNo.Select() : Me.txbStartCardNo.SelectAll() : e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If Me.txbEndCardNo.SelectedText = Me.txbEndCardNo.Text Then Me.txbEndCardNo.Text = ""
            Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbEndCardNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbEndCardNo.Leave
        If Me.txbEndCardNo.Text = "" Then Return
        If Me.txbEndCardNo.Text <> Me.txbEndCardNo.Text.Trim Then Me.txbEndCardNo.Text = Me.txbEndCardNo.Text.Trim
        Dim sValue As String = Me.txbEndCardNo.Text

        If sValue <> sEndCardNo Then
            If Not IsNumeric(sValue) Then
                Me.lblEndCardError.Text = "（卡号只能由数字组成！）"
            ElseIf sValue.Length < 19 Then
                Me.lblEndCardError.Text = "（卡号位数不足 19 位！）"
            ElseIf sValue <> ShoppingCardNo.GetFullCardNo(sValue.Substring(0, 18)) Then
                Me.lblEndCardError.Text = "（卡号校验码错误！）"
            ElseIf dvCULParameter.Table.Select("CULCardBin='" & sValue.Substring(4, 5) & "'").Length = 0 Then
                Me.lblEndCardError.Text = "（无权操作该卡段！）"
            Else
                sEndCardNo = sValue
            End If
        End If

        If Me.lblStartCardError.Text = "" AndAlso Me.lblEndCardError.Text = "" Then
            If sStartCardNo = "" Then
                sStartCardNo = sValue
                Me.txbStartCardNo.Text = sValue
            End If
            If sStartCardNo > sEndCardNo Then
                Me.lblCardNoError.Text = "（结束卡号不应小于开始卡号！）"
            ElseIf sStartCardNo.Substring(4, 5) <> sEndCardNo.Substring(4, 5) Then
                Me.lblCardNoError.Text = "（卡类型/卡Bin码不一致！）"
            ElseIf CULng(sEndCardNo.Substring(0, 18)) - CULng(sStartCardNo.Substring(0, 18)) + 1 > 5000 Then
                Me.lblCardNoError.Text = "（一次操作不要超过 5,000 张卡！）"
            End If
        End If

        If Me.lblStartCardError.Text = "" AndAlso Me.lblEndCardError.Text = "" AndAlso Me.lblCardNoError.Text = "" Then
            blStep1OK = True
            sMerchantNo = dvCULParameter.Table.Select("CULCardBin='" & sStartCardNo.Substring(4, 5) & "'")(0)("CULStoreCode").ToString
            If sStartCardNo = sEndCardNo Then
                Me.lblInfo1.Text = "请按""下一步""查询该张购物卡的状态……"
            Else
                Me.lblInfo1.Text = "请按""下一步""查询该批购物卡的状态……"
            End If
            Me.btnNext.Enabled = True
        End If
    End Sub

    Private Sub txbEndCardNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbEndCardNo.TextChanged
        Me.lblEndCardError.Text = ""
        Me.lblCardNoError.Text = ""
        Me.lblInfo1.Text = ""
        dtOldState.Rows.Clear()
        dtNewState.Rows.Clear()
        Me.btnStart.Enabled = False : blStep1OK = False
        Me.btnPrevious.Enabled = False : blStep2OK = False
        Me.btnNext.Enabled = False : blStep3OK = False
        Me.btnFinish.Enabled = False : Me.pnlResult.Visible = False : blStep4OK = False
    End Sub

    Private Sub txbReason_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbReason.Leave
        If Me.txbReason.Text <> Me.txbReason.Text.Trim Then Me.txbReason.Text = Me.txbReason.Text.Trim
    End Sub

    Private Sub txbReason_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbReason.TextChanged
        If Me.txbReason.Text.Trim = "" Then
            Me.lblInfo3.Text = ""
            blStep3OK = False
            Me.btnNext.Enabled = False
            Me.btnFinish.Enabled = False
        Else
            Me.lblInfo3.Text = "请按""下一卡""或""完成""到CUL系统" & IIf(blIsToFreeze, "冻结", "解冻") & "该" & IIf(sStartCardNo = sEndCardNo, "张", "批") & "购物卡……"
            blStep3OK = True
            Me.btnNext.Enabled = True
            Me.btnFinish.Enabled = True
        End If
    End Sub

    Private Sub dgvNewState_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvNewState.CellFormatting
        If e.ColumnIndex = 5 AndAlso e.Value.ToString.IndexOf("失败") > -1 Then
            e.CellStyle.ForeColor = Color.Red
            e.CellStyle.SelectionForeColor = Color.Red
        End If
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        Me.pnlStep1.Visible = True
        Me.pnlStep2.Visible = False
        Me.pnlStep3.Visible = False
        Me.pnlStep4.Visible = False

        bStep = 1
        If blStep4OK Then
            Me.txbStartCardNo.ReadOnly = False
            Me.txbStartCardNo.BackColor = SystemColors.Window
            Me.txbStartCardNo.Text = ""
            Me.lblStartCardError.Text = ""
            Me.txbEndCardNo.ReadOnly = False
            Me.txbEndCardNo.BackColor = SystemColors.Window
            Me.txbEndCardNo.Text = ""
            Me.lblEndCardError.Text = ""
            Me.lblCardNoError.Text = ""

            Me.dgvOldState.Columns(6).Visible = False

            Me.txbReason.ReadOnly = False
            Me.txbReason.BackColor = SystemColors.Window
            Me.txbReason.Text = ""

            Me.pnlResult.Visible = False

            Me.btnStart.Enabled = False
            Me.btnPrevious.Enabled = False
            Me.btnNext.Enabled = False
            Me.btnFinish.Enabled = False
            Me.btnCancel.Text = "取消(&C)"

            sStartCardNo = "" : sEndCardNo = ""
            blStep1OK = False : blStep2OK = False : blStep3OK = False : blStep4OK = False
        Else
            Me.btnStart.Enabled = False
            Me.btnPrevious.Enabled = False
            Me.btnNext.Enabled = True
            Me.btnFinish.Enabled = blStep3OK
        End If
        Me.txbStartCardNo.Select()
    End Sub

    Private Sub btnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevious.Click
        Select Case bStep
            Case 2
                bStep = 1
                Me.pnlStep1.Visible = True
                Me.pnlStep2.Visible = False
                Me.pnlStep3.Visible = False
                Me.pnlStep4.Visible = False

                Me.btnStart.Enabled = blStep4OK
                Me.btnPrevious.Enabled = False
                Me.btnNext.Enabled = True
                Me.btnFinish.Enabled = blStep3OK

                If blStep4OK Then
                    Me.btnNext.Select()
                Else
                    Me.txbStartCardNo.Select() : Me.txbStartCardNo.SelectAll()
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
                Me.btnFinish.Enabled = blStep3OK

                If blStep4OK Then
                    Me.btnPrevious.Select()
                Else
                    Me.dgvOldState.Select()
                End If
            Case 4
                bStep = 3
                Me.pnlStep1.Visible = False
                Me.pnlStep2.Visible = False
                Me.pnlStep3.Visible = True
                Me.pnlStep4.Visible = False

                Me.btnStart.Enabled = True
                Me.btnPrevious.Enabled = True
                Me.btnNext.Enabled = True
                Me.btnFinish.Enabled = True

                If blStep4OK Then
                    Me.btnPrevious.Select()
                Else
                    Me.txbReason.Select() : Me.txbReason.SelectAll()
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

                Me.dgvOldState.Select()
                If Not blStep2OK AndAlso dtOldState.Rows.Count = 0 Then
                    Me.Cursor = Cursors.WaitCursor
                    Me.btnFinish.Enabled = False
                    Me.lblInfo2.ForeColor = SystemColors.ControlText
                    Me.lblInfo2.Text = "正在到CUL查询该" & IIf(sStartCardNo = sEndCardNo, "张", "批") & "购物卡的状态，请稍候……"
                    Me.Refresh()

                    Dim dtTemp As DataTable = Nothing, sStart As String = sStartCardNo, sEnd As String
                    Do While sStart <= sEndCardNo
                        sEnd = ShoppingCardNo.GetFullCardNo(Format(CULng(sStart.Substring(0, 18)) + 99, "#"))
                        If sEnd > sEndCardNo Then sEnd = sEndCardNo

                        If frmSelectEChannel.sChannelType = "Online" Then
                            dtTemp = ShoppingCardOperation.GetCRFCardState(sMerchantNo, sStart, sEnd)
                        Else
                            dtTemp = ShoppingCardOperation.GetECardState(sMerchantNo, sStart, sEnd)
                        End If

                        If dtTemp.Rows(0)("CardNo").ToString = "Error" Then
                            dtOldState.Rows.Clear()
                            Me.lblInfo2.ForeColor = Color.Red
                            Me.lblInfo2.Text = "查询卡状态时发生错误！错误提示：" & dtTemp.Rows(0)("StoreName").ToString
                            Exit Do
                        Else
                            dtTemp.DefaultView.Sort = "CardNo"
                            dtOldState.Merge(dtTemp.DefaultView.ToTable)
                            dtOldState.AcceptChanges()
                        End If

                        sStart = ShoppingCardNo.GetFullCardNo(Format(CULng(sEnd.Substring(0, 18)) + 1, "#"))
                    Loop

                    If dtOldState.Rows.Count > 0 Then
                        For Each column As DataGridViewColumn In Me.dgvOldState.Columns
                            If column.Visible Then
                                If column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells Then
                                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                ElseIf column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill Then
                                    column.MinimumWidth = 2
                                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                    column.MinimumWidth = column.Width
                                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                                End If
                            End If
                        Next

                        Me.lblInfo1.Text = ""

                        Dim iActivatedQTY As Int16 = 0, iFrozenQTY As Int16 = 0
                        Try
                            iActivatedQTY = dtOldState.Compute("Count(CardNo)", "CardState='已激活'")
                        Catch
                        End Try
                        Try
                            iFrozenQTY = dtOldState.Compute("Count(CardNo)", "CardState='已冻结'")
                        Catch
                        End Try
                        If iActivatedQTY = dtOldState.Rows.Count OrElse iFrozenQTY = dtOldState.Rows.Count Then
                            If iActivatedQTY = dtOldState.Rows.Count Then blIsToFreeze = True Else blIsToFreeze = False
                            Me.lblInfo2.Text = "正在检查该" & IIf(sStartCardNo = sEndCardNo, "张", "批") & "购物卡是否可以" & IIf(blIsToFreeze, "冻结", "解冻") & "，请稍候……"
                            Me.Refresh()

                            Dim DB As New DataBase(), dtResult As DataTable = Nothing
                            DB.Open()
                            If DB.IsConnected Then
                                If sStartCardNo = sEndCardNo Then
                                    dtResult = DB.GetDataTable("Exec CULOperationCheckCardState " & sStartCardNo)
                                ElseIf DB.ModifyTable("Select CardNo Into #tempCard From CardUnavailable Where 1=2") > -1 AndAlso DB.BulkCopyTable("#tempCard", dtOldState.DefaultView.ToTable(False, "CardNo")) > -1 Then
                                    dtResult = DB.GetDataTable("Exec CULOperationCheckCardState")
                                End If
                                DB.Close()

                                If dtResult Is Nothing Then
                                    Me.lblInfo2.ForeColor = Color.Red
                                    Me.lblInfo2.Text = "检查购物卡是否可以" & IIf(blIsToFreeze, "冻结", "解冻") & "失败！"
                                ElseIf dtResult.Rows.Count > 0 Then
                                    For Each drCard As DataRow In dtResult.Rows
                                        If blIsToFreeze Then
                                            If drCard("UsageState") < 3 Then dtOldState.Select("CardNo='" & drCard("CardNo").ToString & "'")(0)("Remarks") = "该卡正等待激活！"
                                        Else
                                            dtOldState.Select("CardNo='" & drCard("CardNo").ToString & "'")(0)("Remarks") = drCard("StateReason").ToString
                                        End If
                                    Next
                                    dtOldState.AcceptChanges()
                                    Me.dgvOldState.Columns(6).HeaderText = "不可" & IIf(blIsToFreeze, "冻结", "解冻") & "原因"
                                    Me.dgvOldState.Columns(6).Visible = True
                                    For Each column As DataGridViewColumn In Me.dgvOldState.Columns
                                        If column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells Then
                                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                        ElseIf column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill Then
                                            column.MinimumWidth = 2
                                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                            column.MinimumWidth = column.Width
                                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                                        End If
                                    Next

                                    Me.lblInfo2.ForeColor = Color.Red
                                    If sStartCardNo = sEndCardNo Then
                                        Me.lblInfo2.Text = "该张购物卡因为处于待审核状态，所以不可被" & IIf(blIsToFreeze, "冻结", "解冻") & "！"
                                    ElseIf dtResult.Rows.Count = dtOldState.Rows.Count Then
                                        Me.lblInfo2.Text = "该批购物卡因为处于待审核状态，所以不可被" & IIf(blIsToFreeze, "冻结", "解冻") & "！"
                                    Else
                                        Me.lblInfo2.Text = "该批购物卡中的部分购物卡因为处于待审核状态，所以不可被" & IIf(blIsToFreeze, "冻结", "解冻") & "！"
                                    End If

                                    dtResult.Dispose() : dtResult = Nothing
                                Else
                                    Me.lblInfo2.Text = "查询完成。您可以对该" & IIf(sStartCardNo = sEndCardNo, "张", "批") & "购物卡执行""" & IIf(blIsToFreeze, "冻结", "解冻") & """操作，请按""下一卡""输入" & IIf(blIsToFreeze, "冻结", "解冻") & "原因……"
                                    Me.grbReason.Text = "第三步：输入" & IIf(blIsToFreeze, "冻结", "解冻") & "原因"
                                    Me.lblReason.Text = "您即将" & IIf(blIsToFreeze, "冻结", "解冻") & "该" & IIf(sStartCardNo = sEndCardNo, "张", "批") & "购物卡，请输入" & IIf(blIsToFreeze, "冻结", "解冻") & "原因（限 50 个字以内）："
                                    Me.grbResult.Text = "第四步：到CUL" & IIf(blIsToFreeze, "冻结", "解冻") & "购物卡"
                                    Me.lblResult.Text = "这是" & IIf(blIsToFreeze, "冻结", "解冻") & "后的购物卡的最新状态："
                                    blStep2OK = True

                                    dtResult.Dispose() : dtResult = Nothing
                                End If
                            Else
                                Me.lblInfo2.ForeColor = Color.Red
                                Me.lblInfo2.Text = "系统因连接不到数据库而无法检查购物卡是否可以" & IIf(blIsToFreeze, "冻结", "解冻") & "。请检查数据库连接。"
                            End If
                        ElseIf iActivatedQTY + iFrozenQTY > 0 Then
                            Me.lblInfo2.ForeColor = Color.Red
                            Me.lblInfo2.Text = "查询完成。但该批购物卡的卡片状态不唯一，没法执行""冻结""或""解冻""操作！"
                        Else
                            Me.lblInfo2.ForeColor = Color.Red
                            Me.lblInfo2.Text = "查询完成。但该" & IIf(sStartCardNo = sEndCardNo, "张", "批") & "购物卡是未激活卡，没法进行""冻结""或""解冻""操作！"
                        End If
                    End If
                    dtTemp.Dispose() : dtTemp = Nothing
                    Me.Cursor = Cursors.Default
                End If

                Me.btnNext.Enabled = blStep2OK
                Me.btnFinish.Enabled = blStep3OK

                If blStep4OK Then
                    If Me.btnNext.Enabled Then
                        Me.btnNext.Select()
                    Else
                        Me.btnPrevious.Select()
                    End If
                End If
            Case 2
                bStep = 3
                Me.pnlStep1.Visible = False
                Me.pnlStep2.Visible = False
                Me.pnlStep3.Visible = True
                Me.pnlStep4.Visible = False

                Me.btnStart.Enabled = True
                Me.btnPrevious.Enabled = True
                Me.btnNext.Enabled = blStep3OK
                Me.btnFinish.Enabled = blStep3OK

                If blStep4OK Then
                    Me.btnNext.Select()
                Else
                    Me.txbReason.Select()
                    Me.txbReason.SelectAll()
                End If
            Case 3
                Me.btnFinish.PerformClick()
        End Select
    End Sub

    Private Sub btnFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinish.Click
        bStep = 4
        Me.pnlStep1.Visible = False
        Me.pnlStep2.Visible = False
        Me.pnlStep3.Visible = False
        Me.pnlStep4.Visible = True

        Me.btnStart.Enabled = True
        Me.btnPrevious.Enabled = True

        If blStep4OK Then
            Me.btnPrevious.Select()
        Else
            Me.dgvNewState.Select()
            Me.Cursor = Cursors.WaitCursor
            Me.lblInfo4.ForeColor = SystemColors.ControlText
            Me.lblInfo4.Text = "正在将该" & IIf(sStartCardNo = sEndCardNo, "张", "批") & "购物卡提交到CUL执行""" & IIf(blIsToFreeze, "冻结", "解冻") & """操作，请稍候……"
            Me.Refresh()

            If frmSelectEChannel.sChannelType = "Online" Then

                Dim c4Service As C4ShoppingCardService.C4ShoppingCardService = Nothing
                Try
                    c4Service = New C4ShoppingCardService.C4ShoppingCardService
                    Dim statusClass As New C4ShoppingCardService.StatusClass, msg As C4ShoppingCardService.CodeMsg = Nothing, dtTemp As DataTable = dtOldState.Copy, sStart As String = sStartCardNo, sEnd As String, sResult As String
                    statusClass.Type = IIf(blIsToFreeze, "ICLK", "ICUK")
                    statusClass.UserID = sMerchantNo
                    statusClass.MerchantNo = sMerchantNo

                    Do While sStart <= sEndCardNo
                        sEnd = ShoppingCardNo.GetFullCardNo(Format(CULng(sStart.Substring(0, 18)) + 99, "#"))
                        If sEnd > sEndCardNo Then sEnd = sEndCardNo

                        statusClass.CardNoFrom = sStart
                        statusClass.CardNoTo = sEnd
                        guIDClass = New C4ShoppingCardService.GuIDClass
                        guIDClass.GuID = frmMain.sGuID
                        msg = c4Service.status(statusClass, guIDClass)

                        If msg.Code.ToUpper = "IY" OrElse msg.Code.ToUpper = "IZ" Then
                            sResult = IIf(blIsToFreeze, "已冻结", "已解冻")
                        Else
                            sResult = IIf(blIsToFreeze, "冻结", "解冻") & "失败！"
                        End If
                        For Each drCard As DataRow In dtTemp.Select("CardNo>='" & sStart & "' And CardNo<='" & sEnd & "'")
                            drCard("CardState") = sResult
                        Next

                        sStart = ShoppingCardNo.GetFullCardNo(Format(CULng(sEnd.Substring(0, 18)) + 1, "#"))
                    Loop

                    dtTemp.AcceptChanges()
                    If dtTemp.Select("CardState Like '已%'").Length > 0 Then
                        dtNewState.Merge(dtTemp)
                        For Each column As DataGridViewColumn In Me.dgvNewState.Columns
                            If column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells Then
                                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                            ElseIf column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill Then
                                column.MinimumWidth = 2
                                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                column.MinimumWidth = column.Width
                                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                            End If
                        Next
                        Me.pnlResult.Visible = True

                        Dim DB As New DataBase(), sSQL As String = ""
                        DB.Open()
                        If DB.IsConnected Then
                            sSQL = "Exec CULFreezeCard "
                            If Not blIsToFreeze Then sSQL = sSQL & "@IsToFreeze=0,"
                            sSQL = sSQL & "@StartCardNo='" & sStartCardNo & "',"
                            sSQL = sSQL & "@EndCardNo='" & sEndCardNo & "',"
                            sSQL = sSQL & "@OperationReason='" & Me.txbReason.Text.Replace("'", "''") & "',"
                            sSQL = sSQL & "@OperatorName='" & frmMain.sLoginUserRealName.Replace("'", "''") & "',@SSID=" & frmMain.sSSID
                            DB.ModifyTable(sSQL)
                        End If
                        DB.Close()

                        Me.lblInfo2.Text = ""
                        Me.lblInfo3.Text = ""
                        Me.lblInfo4.Text = "当次操作已完成。按""开始""执行新的操作，或按""关闭""结束操作。"

                        Me.txbStartCardNo.ReadOnly = True
                        Me.txbStartCardNo.BackColor = SystemColors.Window
                        Me.txbStartCardNo.BackColor = SystemColors.Control
                        Me.txbEndCardNo.ReadOnly = True
                        Me.txbEndCardNo.BackColor = SystemColors.Window
                        Me.txbEndCardNo.BackColor = SystemColors.Control
                        Me.txbReason.ReadOnly = True
                        Me.txbReason.BackColor = SystemColors.Window
                        Me.txbReason.BackColor = SystemColors.Control
                        Me.btnCancel.Text = "关闭(&C)"
                        blStep4OK = True
                        Me.btnHistory.Enabled = True
                    Else
                        Me.lblInfo4.ForeColor = Color.Red
                        If msg IsNot Nothing Then
                            Me.lblInfo4.Text = "执行""" & IIf(blIsToFreeze, "冻结", "解冻") & """操作时出现错误！错误提示：" & msg.Msg
                        Else
                            Me.lblInfo4.Text = "执行""" & IIf(blIsToFreeze, "冻结", "解冻") & """操作时出现错误！"
                        End If
                    End If

                    dtTemp.Dispose() : dtTemp = Nothing
                    statusClass = Nothing
                    msg = Nothing
                Catch ex As Exception
                    Me.lblInfo4.ForeColor = Color.Red
                    Me.lblInfo4.Text = "执行""" & IIf(blIsToFreeze, "冻结", "解冻") & """操作时出现错误！错误提示：" & ex.Message
                Finally
                    If c4Service IsNot Nothing Then c4Service.Dispose() : c4Service = Nothing
                End Try
            Else

                Dim electService As InternetElects.Service = Nothing
                Try
                    electService = New InternetElects.Service()
                    Dim reqFreezeInfo As New InternetElects.FreezeInfo(), respFreezeInfo As New InternetElects.FreezeResponse(), dtTemp As DataTable = dtOldState.Copy, sStart As String = sStartCardNo, sEnd As String, sResult As String

                    'modify code 080:start-------------------------------------------------------------------------
                    Dim sCurCardNo As String, sCurCardNum As Integer
                    If sStartCardNo <= sEndCardNo Then
                        sCurCardNum = Long.Parse(sEndCardNo.Substring(0, 18)) - Long.Parse(sStartCardNo.Substring(0, 18))
                        For nIndex As Integer = 0 To sCurCardNum
                            sCurCardNo = ShoppingCardNo.GetFullCardNo(Format(CULng(sStartCardNo.Substring(0, 18)) + nIndex, "#"))

                            reqFreezeInfo = New InternetElects.FreezeInfo()
                            respFreezeInfo = New InternetElects.FreezeResponse()
                            reqFreezeInfo.IssuerId = frmMain.sIssuerId
                            reqFreezeInfo.MerchantNo = sMerchantNo
                            reqFreezeInfo.Operators = frmMain.sLoginUserID
                            reqFreezeInfo.CardNo = sCurCardNo
                            reqFreezeInfo.Freeze = IIf(blIsToFreeze, "Y", "N")
                            respFreezeInfo = electService.FreezeRequest(reqFreezeInfo)

                            If respFreezeInfo.CodeMsg.Code.ToUpper = "00" Then
                                sResult = IIf(blIsToFreeze, "已冻结", "已解冻")
                            Else
                                sResult = IIf(blIsToFreeze, "冻结", "解冻") & "失败！"
                            End If

                            For Each drCard As DataRow In dtTemp.Select("CardNo='" & sCurCardNo & "'")
                                drCard("CardState") = sResult
                            Next

                        Next
                    End If
                    'modify code 080:end-------------------------------------------------------------------------

                    dtTemp.AcceptChanges()
                    If dtTemp.Select("CardState Like '已%'").Length > 0 Then
                        dtNewState.Merge(dtTemp)
                        For Each column As DataGridViewColumn In Me.dgvNewState.Columns
                            If column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells Then
                                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                            ElseIf column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill Then
                                column.MinimumWidth = 2
                                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                column.MinimumWidth = column.Width
                                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                            End If
                        Next
                        Me.pnlResult.Visible = True

                        Dim DB As New DataBase(), sSQL As String = ""
                        DB.Open()
                        If DB.IsConnected Then
                            sSQL = "Exec CULFreezeCard "
                            If Not blIsToFreeze Then sSQL = sSQL & "@IsToFreeze=0,"
                            sSQL = sSQL & "@StartCardNo='" & sStartCardNo & "',"
                            sSQL = sSQL & "@EndCardNo='" & sEndCardNo & "',"
                            sSQL = sSQL & "@OperationReason='" & Me.txbReason.Text.Replace("'", "''") & "',"
                            sSQL = sSQL & "@OperatorName='" & frmMain.sLoginUserRealName.Replace("'", "''") & "',@SSID=" & frmMain.sSSID
                            DB.ModifyTable(sSQL)
                        End If
                        DB.Close()

                        Me.lblInfo2.Text = ""
                        Me.lblInfo3.Text = ""
                        Me.lblInfo4.Text = "当次操作已完成。按""开始""执行新的操作，或按""关闭""结束操作。"

                        Me.txbStartCardNo.ReadOnly = True
                        Me.txbStartCardNo.BackColor = SystemColors.Window
                        Me.txbStartCardNo.BackColor = SystemColors.Control
                        Me.txbEndCardNo.ReadOnly = True
                        Me.txbEndCardNo.BackColor = SystemColors.Window
                        Me.txbEndCardNo.BackColor = SystemColors.Control
                        Me.txbReason.ReadOnly = True
                        Me.txbReason.BackColor = SystemColors.Window
                        Me.txbReason.BackColor = SystemColors.Control
                        Me.btnCancel.Text = "关闭(&C)"
                        blStep4OK = True
                        Me.btnHistory.Enabled = True
                    Else
                        Me.lblInfo4.ForeColor = Color.Red
                        If respFreezeInfo IsNot Nothing Then
                            Me.lblInfo4.Text = "执行""" & IIf(blIsToFreeze, "冻结", "解冻") & """操作时出现错误！错误提示：" & respFreezeInfo.CodeMsg.Msg
                        Else
                            Me.lblInfo4.Text = "执行""" & IIf(blIsToFreeze, "冻结", "解冻") & """操作时出现错误！"
                        End If
                    End If

                    dtTemp.Dispose() : dtTemp = Nothing
                    reqFreezeInfo = Nothing
                    respFreezeInfo = Nothing
                Catch ex As Exception
                    Me.lblInfo4.ForeColor = Color.Red
                    Me.lblInfo4.Text = "执行""" & IIf(blIsToFreeze, "冻结", "解冻") & """操作时出现错误！错误提示：" & ex.Message
                Finally
                    If electService IsNot Nothing Then electService.Dispose() : electService = Nothing
                End Try
            End If

            Me.Cursor = Cursors.Default
        End If

        Me.btnNext.Enabled = False
        Me.btnFinish.Enabled = False
    End Sub

    Private Sub btnHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistory.Click
        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在打开购物卡""冻结/解冻""历史记录窗口……"
        frmMain.statusMain.Refresh()

        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打开购物卡""冻结/解冻""历史记录窗口。请检查数据库连接。"
            Me.Cursor = Cursors.Default : Return
        End If

        Dim dtHistory As DataTable
        If frmMain.sLoginAreaType = "S" Then
            dtHistory = DB.GetDataTable("Select Case H.IsToFreeze When 0 Then '解冻' Else '冻结' End As OperationType,H.StartCardNo,H.EndCardNo,H.OperationReason,H.OperatorName,H.OperationTime From CULFreeze As H Join UserList As U On H.OperatorID=U.UserID Where U.AreaID=" & frmMain.sLoginAreaID)
        Else
            dtHistory = DB.GetDataTable("Select Case H.IsToFreeze When 0 Then '解冻' Else '冻结' End As OperationType,H.StartCardNo,H.EndCardNo,H.OperationReason,H.OperatorName,H.OperationTime From CULFreeze As H Join UserList As U On H.OperatorID=U.UserID Join AreaScope(" & frmMain.sLoginUserID & ") As S On U.AreaID=S.AreaID")
        End If
        DB.Close()

        If dtHistory Is Nothing Then
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开购物卡""冻结/解冻""历史记录窗口。请联系软件开发人员。"
            Me.Cursor = Cursors.Default : Return
        End If

        frmMain.statusText.Text = "就绪。"
        If dtHistory.Rows.Count = 0 Then
            MessageBox.Show("还未发现任何购物卡""冻结/解冻""历史记录。    ", "没有历史记录。", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dtHistory.Dispose() : dtHistory = Nothing
            Me.btnHistory.Enabled = False
            Me.Cursor = Cursors.Default : Return
        End If

        dtHistory.DefaultView.Sort = "OperationTime Desc"
        With frmCULOperationHistory
            With .dgvList
                .DataSource = dtHistory
                With .Columns(0)
                    .HeaderText = "操作类型"
                    .SortMode = DataGridViewColumnSortMode.Automatic
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "开始卡号"
                    .SortMode = DataGridViewColumnSortMode.Automatic
                    .Width = 125
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "结束卡号"
                    .SortMode = DataGridViewColumnSortMode.Automatic
                    .Width = 125
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = """冻结/解冻""原因"
                    .SortMode = DataGridViewColumnSortMode.Automatic
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .MinimumWidth = .Width
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "操作者"
                    .SortMode = DataGridViewColumnSortMode.Automatic
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "操作时间"
                    .SortMode = DataGridViewColumnSortMode.Automatic
                    .DefaultCellStyle.Format = "yyyy\/MM\/dd HH:mm:ss"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Resizable = DataGridViewTriState.False
                End With

                For bColumn As Byte = 0 To dtHistory.Columns.Count - 1
                    .Columns(bColumn).Name = dtHistory.Columns(bColumn).ColumnName
                Next
            End With
            .ShowDialog()
            .Dispose()
        End With

        dtHistory.Dispose() : dtHistory = Nothing
        Me.Cursor = Cursors.Default
    End Sub

End Class