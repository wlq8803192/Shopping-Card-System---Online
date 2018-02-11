
'modify code 073:
'date;2017/6/5
'auther:Qipeng 
'remark:电子卡65999卡Bin过滤

'modify code 078:
'date;2017/9/25
'auther:Qipeng 
'remark:电子卡65999卡Bin查询接口替换

Public Class frmDealingQuery

    'modify code 078:start-------------------------------------------------------------------------
    Private sCardBin65 = "65999"
    'modify code 078:end-------------------------------------------------------------------------

    Private dvCULParameter As DataView, dvState As DataView, dvDealing As DataView, sCardNo As String = "", blCardNoError As Boolean = False

    Private Sub frmDealingQuery_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        For Each drCUL As DataRow In frmMain.dtLoginStructure.Select("ParentAreaID=33") '青岛市
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "71866", drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "72866", drCUL("CULStoreCode")).EndEdit()
        Next
        For Each drCUL As DataRow In frmMain.dtLoginStructure.Select("ParentAreaID=52") '郑州市
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "35601", drCUL("CULStoreCode")).EndEdit()
        Next
        For Each drCUL As DataRow In frmMain.dtLoginStructure.Select("ParentAreaID=39") '长沙市
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "73608", drCUL("CULStoreCode")).EndEdit()
        Next
        For Each drCUL As DataRow In frmMain.dtLoginStructure.Select("ParentAreaID=59") '海口市
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "11020", drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "11100", drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "11200", drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "11300", drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "11500", drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "11066", drCUL("CULStoreCode")).EndEdit()
        Next
        For Each drCUL As DataRow In dvCULParameter.Table.Select("CULCardBin Like '84%'")
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "60" & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "86" & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "92" & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "94" & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()

            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), frmMain.signCardBin & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
        Next

        'modify code 073:start-------------------------------------------------------------------------
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
        'modify code 073:end-------------------------------------------------------------------------

        dvCULParameter.RowFilter = ""
        dvCULParameter.Table.AcceptChanges()

        Dim dtTemp As New DataTable
        dtTemp.Columns.Add("CardNo", System.Type.GetType("System.String"))
        dtTemp.Columns.Add("Balance", System.Type.GetType("System.Decimal"))
        dtTemp.Columns.Add("ActivatedDate", System.Type.GetType("System.DateTime"))
        dtTemp.Columns.Add("EffectiveDate", System.Type.GetType("System.DateTime"))
        dtTemp.Columns.Add("StoreName", System.Type.GetType("System.String"))
        dtTemp.Columns.Add("CardState", System.Type.GetType("System.String"))
        dtTemp.Columns.Add("AlreadyQueryAll", System.Type.GetType("System.Boolean")) '是否已查询过激活日期之前的记录
        dtTemp.Columns.Add("QueryStartDate", System.Type.GetType("System.DateTime")) '历史查询开始日期
        dvState = New DataView(dtTemp)

        dtTemp = New DataTable()
        dtTemp.Columns.Add("CardNo", System.Type.GetType("System.String"))
        dtTemp.Columns.Add("txnId", System.Type.GetType("System.String")) 'txnId:  流水号
        dtTemp.Columns.Add("inputChannel", System.Type.GetType("System.String")) ' inputChannel：交易渠道
        dtTemp.Columns.Add("txnCode", System.Type.GetType("System.String")) ' txnCode：交易类型
        dtTemp.Columns.Add("earnAmount", System.Type.GetType("System.Decimal")) ' earnAmount：赚取金额
        dtTemp.Columns.Add("redeemAmount", System.Type.GetType("System.Decimal")) ' redeemAmount：兑换金额
        dtTemp.Columns.Add("transferAmount", System.Type.GetType("System.Decimal")) ' transferAmount：转账金额
        dtTemp.Columns.Add("adjustAmount", System.Type.GetType("System.Decimal")) ' adjustAmount：调整金额
        dtTemp.Columns.Add("status", System.Type.GetType("System.String")) ' status：成功/失败
        dtTemp.Columns.Add("txnDate", System.Type.GetType("System.DateTime")) ' txnDate：交易日期
        dtTemp.Columns.Add("txnTime", System.Type.GetType("System.DateTime")) ' txnTime：交易时间
        dtTemp.Columns.Add("merchantNo", System.Type.GetType("System.String")) ' merchantNo：商户号
        dtTemp.Columns.Add("termNo", System.Type.GetType("System.String")) ' termNo：终端号
        dtTemp.Columns.Add("IsAfterActivatedDate", System.Type.GetType("System.Boolean")) '表明是从激活日期之后还是之前
        dvDealing = New DataView(dtTemp)
        dvDealing.Sort = "txnTime"
        dtTemp = Nothing

        With Me.dgvState
            .DataSource = dvState
            .Columns(0).Visible = False
            With .Columns(1)
                .HeaderText = "余额"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .MinimumWidth = 40
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,0.00"
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(2)
                .HeaderText = "激活日期"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .MinimumWidth = 70
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Format = "yyyy\/MM\/dd"
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(3)
                .HeaderText = "有效期至"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .MinimumWidth = 70
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Format = "yyyy\/MM\/dd"
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(4)
                .HeaderText = "发卡门店"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(5)
                .HeaderText = "卡片状态"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            .Columns(6).Visible = False
            .Columns(7).Visible = False

            For bColumn As Byte = 0 To dvState.Table.Columns.Count - 1
                .Columns(bColumn).Name = dvState.Table.Columns(bColumn).ColumnName
            Next
        End With

        With Me.dgvDealing
            .DataSource = dvDealing
            .Columns(0).Visible = False
            With .Columns(1)
                .HeaderText = "流水号"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .MinimumWidth = 50
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(2)
                .HeaderText = "交易渠道"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(3)
                .HeaderText = "交易类型"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(4)
                .HeaderText = "赚取金额"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(5)
                .HeaderText = "兑换金额"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(6)
                .HeaderText = "转账金额"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(7)
                .HeaderText = "调整金额"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(8)
                .HeaderText = "成功/失败"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(9)
                .HeaderText = "交易日期"
                .DefaultCellStyle.Format = "yyyy\/MM\/dd"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .Visible = False
            End With
            With .Columns(10)
                .HeaderText = "交易时间"
                .DefaultCellStyle.Format = "yyyy\/MM\/dd HH:mm:ss"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(11)
                .HeaderText = "商户号"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .MinimumWidth = .Width
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(12)
                .HeaderText = "终端号"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
            .Columns(13).Visible = False

            For bColumn As Byte = 0 To dvDealing.Table.Columns.Count - 1
                .Columns(bColumn).Name = dvDealing.Table.Columns(bColumn).ColumnName
            Next
        End With
    End Sub

    Private Sub txbCardNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbCardNo.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter AndAlso Me.btnQuery.Enabled Then Me.btnQuery.Select() : Me.btnQuery.PerformClick() : e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If Me.txbCardNo.SelectedText = Me.txbCardNo.Text Then Me.txbCardNo.Text = ""
            Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbCardNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbCardNo.Leave
        If Me.txbCardNo.Text <> Me.txbCardNo.Text.Trim Then Me.txbCardNo.Text = Me.txbCardNo.Text.Trim
        Dim sValue As String = Me.txbCardNo.Text
        If sValue = sCardNo Then Return

        blCardNoError = False
        If sValue <> "" Then
            If Not IsNumeric(sValue) Then
                blCardNoError = True
                Me.lblCardNo.Text = "（卡号只能由数字组成！）"
            ElseIf sValue.IndexOf("8") = 0 OrElse sValue.IndexOf("9") = 0 Then
                If sValue.Length < 17 Then
                    blCardNoError = True
                    Me.lblCardNo.Text = "（条码卡卡号位数不足 17 位！）"
                ElseIf dvCULParameter.Table.Select("CULCardBin='" & sValue.Substring(0, 5) & "'").Length = 0 Then
                    blCardNoError = True
                    Me.lblCardNo.Text = "（无权查询该卡段！）"
                ElseIf sValue.IndexOf("94") = 0 Then
                    Me.lblCardNo.Text = "（活动券）"
                ElseIf sValue.IndexOf("92") = 0 Then
                    Me.lblCardNo.Text = "（营销券）"
                ElseIf sValue.IndexOf("86") = 0 OrElse sValue.Substring(5, 1) = "8" OrElse sValue.Substring(5, 3) = "100" Then
                    Me.lblCardNo.Text = "（条码卡）"
                Else
                    Me.lblCardNo.Text = "（充值券）"
                End If
            ElseIf sValue.Length < 19 Then
                blCardNoError = True
                Me.lblCardNo.Text = "（卡号位数不足 19 位！）"
            ElseIf sValue <> ShoppingCardNo.GetFullCardNo(sValue.Substring(0, 18)) Then
                blCardNoError = True
                Me.lblCardNo.Text = "（卡号校验码错误！）"
            ElseIf dvCULParameter.Table.Select("CULCardBin='" & sValue.Substring(4, 5) & "'").Length = 0 Then
                blCardNoError = True
                Me.lblCardNo.Text = "（无权查询该卡段！）"
            ElseIf sValue.IndexOf("94") = 4 Then
                Me.lblCardNo.Text = "（活动卡）"
            ElseIf sValue.IndexOf("92") = 4 Then
                Me.lblCardNo.Text = "（营销卡）"
            ElseIf sValue.IndexOf("60") = 4 Then
                Me.lblCardNo.Text = "（礼品卡）"
            End If
        End If

        If blCardNoError Then
            Me.lblCardNo.ForeColor = Color.Red
        Else
            Me.lblCardNo.ForeColor = SystemColors.ControlText
            sCardNo = sValue
        End If

        If blCardNoError = False AndAlso sValue <> "" Then
            Me.btnQuery.Enabled = True
        Else
            Me.txbCardNo.Select() : Me.txbCardNo.SelectAll()
            Me.btnQuery.Enabled = False
        End If
    End Sub

    Private Sub txbCardNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbCardNo.TextChanged
        If Me.txbCardNo.Text.Trim <> "" Then
            Dim bCurrentMaxLength As Byte = Me.txbCardNo.MaxLength, bNewMaxLength As Byte = 19
            If Me.txbCardNo.Text.Trim.IndexOf("8") = 0 OrElse Me.txbCardNo.Text.Trim.IndexOf("9") = 0 Then bNewMaxLength = 17
            If bNewMaxLength <> bCurrentMaxLength Then Me.txbCardNo.MaxLength = bNewMaxLength
        End If

        Me.lblCardNo.Text = ""
        dvState.RowFilter = "1=2"
        Me.lblState.ForeColor = Color.Maroon
        Me.lblState.Text = "（未查询）"
        Me.lblState.Visible = True
        dvDealing.RowFilter = "1=2"
        Me.lblDealing.ForeColor = Color.Maroon
        Me.lblDealing.Text = "（未查询）"
        Me.lblDealing.Visible = True
        If Me.txbCardNo.Text.Trim <> "" Then
            Me.btnQuery.Enabled = True
        Else
            Me.btnQuery.Enabled = False
        End If
        Me.btnHistory.Enabled = False
    End Sub

    Private Sub btnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        If sCardNo.IndexOf("8") = 0 OrElse sCardNo.IndexOf("9") = 0 Then
            Me.QueryAfter3()
        ElseIf frmMain.sLoginUserID = "0" Then
            Me.QueryAfter1()
        Else
            Me.QueryAfter2()
        End If
    End Sub

    Private Sub btnHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistory.Click
        If frmMain.sLoginUserID = "0" Then
            Me.QueryBefore1()
        Else
            Me.QueryBefore2()
        End If
    End Sub

    Private Sub dgvState_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvState.Leave
        If Me.dgvState.CurrentCell IsNot Nothing Then Me.dgvState.CurrentCell.Selected = False
        If Me.dgvState.CurrentRow IsNot Nothing Then Me.dgvState.CurrentRow.Selected = False
    End Sub

    Private Sub dgvDealing_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvDealing.CellFormatting
        If Me.dgvDealing("IsAfterActivatedDate", e.RowIndex).Value.ToString.ToLower = "false" Then
            e.CellStyle.BackColor = Color.WhiteSmoke
            e.CellStyle.SelectionBackColor = SystemColors.GradientInactiveCaption
            e.CellStyle.ForeColor = Color.Orange
            e.CellStyle.SelectionForeColor = Color.Yellow
        End If
    End Sub

    Private Sub dgvDealing_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDealing.Leave
        If Me.dgvDealing.CurrentCell IsNot Nothing Then Me.dgvDealing.CurrentCell.Selected = False
        If Me.dgvDealing.CurrentRow IsNot Nothing Then Me.dgvDealing.CurrentRow.Selected = False
    End Sub

    Private Sub QueryAfter1()
        Me.Cursor = Cursors.WaitCursor

        dvState.RowFilter = "CardNo='" & sCardNo & "'"
        If dvState.Count = 0 Then
            Me.lblState.Text = "（正在查询状态……）"
            Me.Refresh()

            Dim sMerchantNo As String = dvCULParameter.Table.Select("CULCardBin='" & sCardNo.Substring(4, 5) & "'")(0)("CULStoreCode").ToString
            Dim dtTemp As DataTable = ShoppingCardOperation.GetCRFCardState(sMerchantNo, sCardNo, sCardNo)

            'modify code 078:start-------------------------------------------------------------------------
            'If sCardNo.Substring(4, 5) = sCardBin65 Then
            '    dtTemp = ShoppingCardOperation.GetECardState(sMerchantNo, sCardNo, sCardNo)
            'End If
            'modify code 078:end-------------------------------------------------------------------------

            If dtTemp.Rows(0)("CardNo").ToString = "Error" Then
                Me.lblState.ForeColor = Color.Red
                Me.lblState.Text = "（到CUL系统查询购物卡状态时发生错误！错误提示：" & dtTemp.Rows(0)("StoreName").ToString & "）"
                dvState.RowFilter = "1=2"
                Me.lblDealing.ForeColor = Color.Red
                Me.lblDealing.Text = Me.lblState.Text
                dvDealing.RowFilter = "1=2"
            Else
                Dim newCard As DataRow = dvState.Table.Rows.Add(sCardNo)
                For bColumn As Byte = 1 To dtTemp.Columns.Count - 1
                    newCard(bColumn) = dtTemp.Rows(0)(bColumn)
                Next

                dvDealing.RowFilter = "CardNo='" & sCardNo & "'"
                Dim newDealing As DataRow = Nothing
                If newCard("CardState").ToString = "未激活" AndAlso newCard("ActivatedDate").ToString = "" Then
                    newCard("AlreadyQueryAll") = 1
                    newCard.AcceptChanges()

                    Me.lblState.ForeColor = SystemColors.ControlText
                    Me.lblState.Text = "（该购物卡未激活，是空白卡。）"
                    dvState.RowFilter = "1=2"
                    newDealing = dvDealing.Table.Rows.Add()
                    newDealing("CardNo") = sCardNo
                    newDealing("txnId") = "未激活"
                    newDealing.AcceptChanges()
                    Me.lblDealing.ForeColor = SystemColors.ControlText
                    Me.lblDealing.Text = "（该购物卡未激活，不存在交易明细。）"
                    dvDealing.RowFilter = "1=2"

                    Me.btnQuery.Enabled = False
                    Me.btnHistory.Enabled = False
                Else
                    newCard("AlreadyQueryAll") = 0
                    newCard.AcceptChanges()

                    For Each column As DataGridViewColumn In Me.dgvState.Columns
                        If column.Visible AndAlso column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells Then
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        End If
                    Next
                    Me.dgvState.Select()
                    Me.btnClose.Select()
                    Me.lblState.Visible = False

                    Me.lblDealing.Text = "（正在查询交易明细……）"
                    Me.Refresh()

                    Dim sDecimalSeparator As String = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
                    Dim c4Service As C4ShoppingCardService.C4ShoppingCardService = Nothing
                    Try
                        c4Service = New C4ShoppingCardService.C4ShoppingCardService
                        Dim CtqyClass As New C4ShoppingCardService.CtqyClass()
                        CtqyClass.MerchantNo = sMerchantNo
                        CtqyClass.UserID = sMerchantNo
                        CtqyClass.CardNo = sCardNo
                        CtqyClass.QueryType = "T"
                        CtqyClass.IsPager = "N"
                        CtqyClass.PageNo = "1"
                        CtqyClass.PageSize = "1000000"

                        Dim CtqyDataClass As C4ShoppingCardService.CtqyDataClass = c4Service.ctqy(CtqyClass), icardTxns As Integer = 0
                        If CtqyDataClass.CodeMsg.Code = "PZ" Then
                            icardTxns = CInt(CtqyDataClass.Total) - 1
                            If icardTxns > -1 Then
                                For iTxn As Integer = 0 To icardTxns
                                    newDealing = dvDealing.Table.Rows.Add()
                                    newDealing("CardNo") = sCardNo
                                    newDealing("txnId") = CtqyDataClass.CardTxns(iTxn).TxnId
                                    newDealing("inputChannel") = CtqyDataClass.CardTxns(iTxn).InputChannel
                                    newDealing("txnCode") = CtqyDataClass.CardTxns(iTxn).TxnCode
                                    Try
                                        newDealing("earnAmount") = CDec(CtqyDataClass.CardTxns(iTxn).EarnAmount.ToString.Replace(".", sDecimalSeparator))
                                    Catch
                                        newDealing("earnAmount") = 0
                                    End Try
                                    Try
                                        newDealing("redeemAmount") = CDec(CtqyDataClass.CardTxns(iTxn).RedeemAmount.ToString.Replace(".", sDecimalSeparator))
                                    Catch
                                        newDealing("redeemAmount") = 0
                                    End Try
                                    Try
                                        newDealing("transferAmount") = CDec(CtqyDataClass.CardTxns(iTxn).TransferAmount.ToString.Replace(".", sDecimalSeparator))
                                    Catch
                                        newDealing("transferAmount") = 0
                                    End Try
                                    Try
                                        newDealing("adjustAmount") = CDec(CtqyDataClass.CardTxns(iTxn).AdjustAmount.ToString.Replace(".", sDecimalSeparator))
                                    Catch
                                        newDealing("adjustAmount") = 0
                                    End Try
                                    newDealing("status") = CtqyDataClass.CardTxns(iTxn).Status
                                    newDealing("txnDate") = CDate(CtqyDataClass.CardTxns(iTxn).TxnDate.Insert(4, "/").Insert(7, "/"))
                                    newDealing("txnTime") = CDate(CtqyDataClass.CardTxns(iTxn).TxnTime)
                                    newDealing("merchantNo") = CtqyDataClass.CardTxns(iTxn).MerchantNo
                                    newDealing("termNo") = CtqyDataClass.CardTxns(iTxn).TermNo
                                    newDealing("IsAfterActivatedDate") = 1
                                    newDealing.AcceptChanges()
                                Next
                            End If

                            CtqyClass.QueryType = "H"
                            CtqyClass.DateFrom = Format(dtTemp.Rows(0)("ActivatedDate"), "yyyyMMdd")
                            CtqyClass.DateTo = Format(Today(), "yyyyMMdd")

                            CtqyDataClass = c4Service.ctqy(CtqyClass)
                            If CtqyDataClass.CodeMsg.Code = "PZ" Then
                                icardTxns = CInt(CtqyDataClass.Total) - 1
                                If icardTxns > -1 Then
                                    For iTxn As Integer = 0 To icardTxns
                                        newDealing = dvDealing.Table.Rows.Add()
                                        newDealing("CardNo") = sCardNo
                                        newDealing("txnId") = CtqyDataClass.CardTxns(iTxn).TxnId
                                        newDealing("inputChannel") = CtqyDataClass.CardTxns(iTxn).InputChannel
                                        newDealing("txnCode") = CtqyDataClass.CardTxns(iTxn).TxnCode
                                        Try
                                            newDealing("earnAmount") = CDec(CtqyDataClass.CardTxns(iTxn).EarnAmount.ToString.Replace(".", sDecimalSeparator))
                                        Catch
                                            newDealing("earnAmount") = 0
                                        End Try
                                        Try
                                            newDealing("redeemAmount") = CDec(CtqyDataClass.CardTxns(iTxn).RedeemAmount.ToString.Replace(".", sDecimalSeparator))
                                        Catch
                                            newDealing("redeemAmount") = 0
                                        End Try
                                        Try
                                            newDealing("transferAmount") = CDec(CtqyDataClass.CardTxns(iTxn).TransferAmount.ToString.Replace(".", sDecimalSeparator))
                                        Catch
                                            newDealing("transferAmount") = 0
                                        End Try
                                        Try
                                            newDealing("adjustAmount") = CDec(CtqyDataClass.CardTxns(iTxn).AdjustAmount.ToString.Replace(".", sDecimalSeparator))
                                        Catch
                                            newDealing("adjustAmount") = 0
                                        End Try
                                        newDealing("status") = CtqyDataClass.CardTxns(iTxn).Status
                                        newDealing("txnDate") = CDate(CtqyDataClass.CardTxns(iTxn).TxnDate.Insert(4, "/").Insert(7, "/"))
                                        newDealing("txnTime") = CDate(CtqyDataClass.CardTxns(iTxn).TxnTime)
                                        newDealing("merchantNo") = CtqyDataClass.CardTxns(iTxn).MerchantNo
                                        newDealing("termNo") = CtqyDataClass.CardTxns(iTxn).TermNo
                                        newDealing("IsAfterActivatedDate") = 1
                                        newDealing.AcceptChanges()
                                    Next
                                End If

                                If dvDealing.Count = 0 Then
                                    newDealing = dvDealing.Table.Rows.Add()
                                    newDealing("CardNo") = sCardNo
                                    newDealing("txnId") = "没有明细"
                                    newDealing.AcceptChanges()
                                End If
                            Else
                                For Each dr As DataRowView In dvDealing
                                    dr.Delete()
                                    If dr.Row.RowState = DataRowState.Deleted Then dr.Row.AcceptChanges()
                                Next
                                newDealing = dvDealing.Table.Rows.Add()
                                newDealing("CardNo") = sCardNo
                                newDealing("txnId") = "错误！"
                                newDealing("inputChannel") = CtqyDataClass.CodeMsg.Msg
                                newDealing("IsAfterActivatedDate") = 1
                                newDealing.AcceptChanges()
                            End If
                        Else
                            For Each dr As DataRowView In dvDealing
                                dr.Delete()
                                If dr.Row.RowState = DataRowState.Deleted Then dr.Row.AcceptChanges()
                            Next
                            newDealing = dvDealing.Table.Rows.Add()
                            newDealing("CardNo") = sCardNo
                            newDealing("txnId") = "错误！"
                            newDealing("inputChannel") = CtqyDataClass.CodeMsg.Msg
                            newDealing("IsAfterActivatedDate") = 1
                            newDealing.AcceptChanges()
                        End If

                        CtqyClass = Nothing : CtqyDataClass = Nothing
                    Catch ex As Exception
                        For Each dr As DataRowView In dvDealing
                            dr.Delete()
                            If dr.Row.RowState = DataRowState.Deleted Then dr.Row.AcceptChanges()
                        Next
                        newDealing = dvDealing.Table.Rows.Add()
                        newDealing("CardNo") = sCardNo
                        newDealing("txnId") = "错误！"
                        newDealing("inputChannel") = ex.Message
                        newDealing("IsAfterActivatedDate") = 1
                        newDealing.AcceptChanges()
                    Finally
                        If c4Service IsNot Nothing Then c4Service.Dispose() : c4Service = Nothing
                    End Try

                    dvDealing.RowFilter = "CardNo='" & sCardNo & "'"
                    If newDealing("txnId").ToString = "错误！" Then
                        Me.lblDealing.ForeColor = Color.Red
                        Me.lblDealing.Text = "（到CUL系统查询购物卡交易明细时发生错误！错误提示：" & newDealing("inputChannel").ToString & "）"
                        dvDealing.RowFilter = "1=2"
                    ElseIf newDealing("txnId").ToString = "没有明细" Then
                        Me.lblDealing.ForeColor = SystemColors.ControlText
                        Me.lblDealing.Text = "（没有交易明细）"
                        dvDealing.RowFilter = "1=2"
                    Else
                        For Each column As DataGridViewColumn In Me.dgvDealing.Columns
                            If column.Visible AndAlso column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells Then
                                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                            ElseIf column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill Then
                                column.MinimumWidth = 2
                                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                column.MinimumWidth = column.Width
                                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                            End If
                        Next
                        Me.dgvDealing.Select()
                        Me.btnClose.Select()
                        Me.lblDealing.Visible = False
                        Me.btnQuery.Enabled = False
                        Me.btnHistory.Enabled = (Not newCard("AlreadyQueryAll"))
                    End If
                End If
            End If
        ElseIf dvState(0)("CardState").ToString = "未激活" AndAlso dvState(0)("ActivatedDate").ToString = "" Then
            Me.lblState.ForeColor = SystemColors.ControlText
            Me.lblState.Text = "（该购物卡未激活，是空白卡。）"
            dvState.RowFilter = "1=2"
            Me.lblDealing.ForeColor = SystemColors.ControlText
            Me.lblDealing.Text = "（该购物卡未激活，不存在交易明细。）"
            dvDealing.RowFilter = "1=2"
            Me.btnQuery.Enabled = False
            Me.btnHistory.Enabled = False
        Else
            For Each column As DataGridViewColumn In Me.dgvState.Columns
                If column.Visible AndAlso column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells Then
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                ElseIf column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill Then
                    column.MinimumWidth = 2
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    column.MinimumWidth = column.Width
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End If
            Next
            Me.dgvState.Select()
            Me.btnClose.Select()
            Me.lblState.Visible = False

            dvDealing.RowFilter = "CardNo='" & sCardNo & "'"
            If dvDealing(0)("txnId").ToString = "错误！" Then
                Me.lblDealing.ForeColor = Color.Red
                Me.lblDealing.Text = "（到CUL系统查询购物卡交易明细时发生错误！错误提示：" & dvDealing(0)("inputChannel").ToString & "）"
                dvDealing.RowFilter = "1=2"
            ElseIf dvDealing(0)("txnId").ToString = "没有明细" Then
                Me.lblDealing.ForeColor = SystemColors.ControlText
                Me.lblDealing.Text = "（没有交易明细）"
                dvDealing.RowFilter = "1=2"
            Else
                For Each column As DataGridViewColumn In Me.dgvDealing.Columns
                    If column.Visible AndAlso column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells Then
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    End If
                Next
                Me.dgvDealing.Select()
                Me.btnClose.Select()
                Me.lblDealing.Visible = False
                Me.btnQuery.Enabled = False
                Me.btnHistory.Enabled = (Not dvState(0)("AlreadyQueryAll"))
            End If
        End If

        Me.txbCardNo.Select() : Me.txbCardNo.SelectAll()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub QueryAfter2()
        Me.Cursor = Cursors.WaitCursor

        dvState.RowFilter = "CardNo='" & sCardNo & "'"
        If dvState.Count = 0 Then
            Me.lblState.Text = "（正在查询状态……）"
            Me.Refresh()

            Dim DB As New DataBase()
            DB.Open()
            If Not DB.IsConnected Then
                frmMain.statusText.Text = "系统因连接不到远程服务器而无法查询查询购物卡。请检查网络连接。"
                Me.lblState.Text = "（未查询）"
                Me.Cursor = Cursors.Default : Return
            End If

            Dim dtTempState As DataTable, drQueriedState As DataRow = Nothing, dtQueriedDealing As DataTable = Nothing, drQueriedDealing As DataRow, dtToday As DateTime
            Try
                dtToday = DB.GetDataTable("Select Convert(datetime,Convert(varchar(10), Getdate(),112))").Rows(0)(0)
                dtTempState = DB.GetDataTable("Select * From [State&Dealing].dbo.CardState Where CardNo='" & sCardNo & "'").Copy
                If dtTempState.Rows.Count = 0 Then
                    drQueriedState = dtTempState.Rows.Add(sCardNo)
                Else
                    drQueriedState = dtTempState.Rows(0)
                End If
                dtQueriedDealing = DB.GetDataTable("Select * From [State&Dealing].dbo.CardDealing Where CardNo='" & sCardNo & "'").Copy
            Catch
                frmMain.statusText.Text = "系统因在检索数据时出错而无法查询查询购物卡。请联系软件开发人员。"
                Me.lblState.Text = "（未查询）"
                DB.Close()
                Me.txbCardNo.Select() : Me.txbCardNo.SelectAll()
                Me.Cursor = Cursors.Default : Return
            End Try

            Dim sMerchantNo As String = dvCULParameter.Table.Select("CULCardBin='" & sCardNo.Substring(4, 5) & "'")(0)("CULStoreCode").ToString
            Dim newState As DataRow = Nothing, newDealing As DataRow = Nothing
            If drQueriedState("QueryEndDate").ToString = "" OrElse drQueriedState("QueryEndDate") < dtToday Then
                dtTempState = ShoppingCardOperation.GetCRFCardState(sMerchantNo, sCardNo, sCardNo)

                'modify code 078:start-------------------------------------------------------------------------
                'If sCardNo.Substring(4, 5) = sCardBin65 Then
                '    dtTempState = ShoppingCardOperation.GetECardState(sMerchantNo, sCardNo, sCardNo)
                'End If
                'modify code 078:end-------------------------------------------------------------------------

                If dtTempState.Rows(0)("CardNo").ToString = "Error" Then
                    Me.lblState.ForeColor = Color.Red
                    Me.lblState.Text = "（到CUL系统查询购物卡状态时发生错误！错误提示：" & dtTempState.Rows(0)("StoreName").ToString & "）"
                    dvState.RowFilter = "1=2"
                    Me.lblDealing.ForeColor = Color.Red
                    Me.lblDealing.Text = Me.lblState.Text
                    dvDealing.RowFilter = "1=2"
                    DB.Close()
                    Me.txbCardNo.Select() : Me.txbCardNo.SelectAll()
                    Me.Cursor = Cursors.Default : Return
                Else
                    newState = dvState.Table.Rows.Add(sCardNo)
                    newState("Balance") = dtTempState.Rows(0)("Balance")
                    drQueriedState("Balance") = newState("Balance")
                    If drQueriedState("StoreName").ToString = "" Then
                        newState("ActivatedDate") = dtTempState.Rows(0)("ActivatedDate")
                        drQueriedState("ActivatedDate") = newState("ActivatedDate")
                        newState("EffectiveDate") = dtTempState.Rows(0)("EffectiveDate")
                        drQueriedState("EffectiveDate") = newState("EffectiveDate")
                        newState("StoreName") = dtTempState.Rows(0)("StoreName")
                        drQueriedState("StoreName") = newState("StoreName")
                    Else
                        newState("ActivatedDate") = drQueriedState("ActivatedDate")
                        newState("EffectiveDate") = drQueriedState("EffectiveDate")
                        newState("StoreName") = drQueriedState("StoreName")
                    End If
                    newState("CardState") = dtTempState.Rows(0)("CardState")
                    drQueriedState("CardState") = newState("CardState")
                End If
            Else
                newState = dvState.Table.Rows.Add(sCardNo)
                For bColumn As Byte = 1 To 5
                    newState(bColumn) = drQueriedState(bColumn)
                Next
            End If

            If newState("CardState").ToString = "未激活" AndAlso newState("ActivatedDate").ToString = "" Then
                newState("AlreadyQueryAll") = 1
                newState.AcceptChanges()

                Me.lblState.ForeColor = SystemColors.ControlText
                Me.lblState.Text = "（该购物卡未激活，是空白卡。）"
                dvState.RowFilter = "1=2"
                newDealing = dvDealing.Table.Rows.Add()
                newDealing("CardNo") = sCardNo
                newDealing("txnId") = "未激活"
                newDealing.AcceptChanges()
                Me.lblDealing.ForeColor = SystemColors.ControlText
                Me.lblDealing.Text = "（该购物卡未激活，不存在交易明细。）"
                dvDealing.RowFilter = "1=2"

                Me.btnQuery.Enabled = False
                Me.btnHistory.Enabled = False

                DB.Close()
                Me.txbCardNo.Select() : Me.txbCardNo.SelectAll()
                Me.Cursor = Cursors.Default : Return
            End If

            newState("AlreadyQueryAll") = 0
            newState("QueryStartDate") = drQueriedState("QueryStartDate")
            newState.AcceptChanges()

            For Each column As DataGridViewColumn In Me.dgvState.Columns
                If column.Visible AndAlso column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells Then
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End If
            Next
            Me.dgvState.Select()
            Me.btnClose.Select()
            Me.lblState.Visible = False

            Me.lblDealing.Text = "（正在查询交易明细……）"
            Me.Refresh()

            For Each drQueriedDealing In dtQueriedDealing.Rows
                newDealing = dvDealing.Table.Rows.Add()
                newDealing("CardNo") = sCardNo
                For bColumn As Byte = 1 To dtQueriedDealing.Columns.Count - 1
                    newDealing(bColumn) = drQueriedDealing(bColumn)
                Next
                newDealing("IsAfterActivatedDate") = (drQueriedDealing("txnDate") >= newState("ActivatedDate"))
                newDealing.AcceptChanges()
            Next
            dtQueriedDealing.Rows.Clear()

            If drQueriedState("QueryEndDate").ToString = "" OrElse drQueriedState("QueryEndDate") < dtToday Then
                Dim sDecimalSeparator As String = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
                Dim c4Service As C4ShoppingCardService.C4ShoppingCardService = Nothing
                Try
                    c4Service = New C4ShoppingCardService.C4ShoppingCardService
                    Dim CtqyClass As New C4ShoppingCardService.CtqyClass()
                    CtqyClass.MerchantNo = sMerchantNo
                    CtqyClass.UserID = sMerchantNo
                    CtqyClass.CardNo = sCardNo
                    CtqyClass.QueryType = "T"
                    CtqyClass.IsPager = "N"
                    CtqyClass.PageNo = "1"
                    CtqyClass.PageSize = "1000000"

                    Dim CtqyDataClass As C4ShoppingCardService.CtqyDataClass = c4Service.ctqy(CtqyClass), icardTxns As Integer = 0
                    If CtqyDataClass.CodeMsg.Code = "PZ" Then
                        icardTxns = CInt(CtqyDataClass.Total) - 1
                        If icardTxns > -1 Then
                            For iTxn As Integer = 0 To icardTxns
                                newDealing = dvDealing.Table.Rows.Add()
                                newDealing("CardNo") = sCardNo
                                newDealing("txnId") = CtqyDataClass.CardTxns(iTxn).TxnId
                                newDealing("inputChannel") = CtqyDataClass.CardTxns(iTxn).InputChannel
                                newDealing("txnCode") = CtqyDataClass.CardTxns(iTxn).TxnCode
                                Try
                                    newDealing("earnAmount") = CDec(CtqyDataClass.CardTxns(iTxn).EarnAmount.ToString.Replace(".", sDecimalSeparator))
                                Catch
                                    newDealing("earnAmount") = 0
                                End Try
                                Try
                                    newDealing("redeemAmount") = CDec(CtqyDataClass.CardTxns(iTxn).RedeemAmount.ToString.Replace(".", sDecimalSeparator))
                                Catch
                                    newDealing("redeemAmount") = 0
                                End Try
                                Try
                                    newDealing("transferAmount") = CDec(CtqyDataClass.CardTxns(iTxn).TransferAmount.ToString.Replace(".", sDecimalSeparator))
                                Catch
                                    newDealing("transferAmount") = 0
                                End Try
                                Try
                                    newDealing("adjustAmount") = CDec(CtqyDataClass.CardTxns(iTxn).AdjustAmount.ToString.Replace(".", sDecimalSeparator))
                                Catch
                                    newDealing("adjustAmount") = 0
                                End Try
                                newDealing("status") = CtqyDataClass.CardTxns(iTxn).Status
                                newDealing("txnDate") = CDate(CtqyDataClass.CardTxns(iTxn).TxnDate.Insert(4, "/").Insert(7, "/"))
                                newDealing("txnTime") = CDate(CtqyDataClass.CardTxns(iTxn).TxnTime)
                                newDealing("merchantNo") = CtqyDataClass.CardTxns(iTxn).MerchantNo
                                newDealing("termNo") = CtqyDataClass.CardTxns(iTxn).TermNo
                                newDealing("IsAfterActivatedDate") = 1
                                newDealing.AcceptChanges()
                            Next
                        End If

                        If drQueriedState("QueryEndDate").ToString = "" OrElse DateDiff(DateInterval.Day, drQueriedState("QueryEndDate"), dtToday) > 1 Then
                            CtqyClass.QueryType = "H"
                            If drQueriedState("QueryEndDate").ToString = "" Then
                                CtqyClass.DateFrom = Format(newState("ActivatedDate"), "yyyyMMdd")
                            Else
                                CtqyClass.DateFrom = Format(DateAdd(DateInterval.Day, 1, drQueriedState("QueryEndDate")), "yyyyMMdd")
                            End If
                            CtqyClass.DateTo = Format(dtToday, "yyyyMMdd")

                            CtqyDataClass = c4Service.ctqy(CtqyClass)
                            If CtqyDataClass.CodeMsg.Code = "PZ" Then
                                icardTxns = CInt(CtqyDataClass.Total) - 1
                                If icardTxns > -1 Then
                                    For iTxn As Integer = 0 To icardTxns
                                        newDealing = dvDealing.Table.Rows.Add()
                                        newDealing("CardNo") = sCardNo
                                        newDealing("txnId") = CtqyDataClass.CardTxns(iTxn).TxnId
                                        newDealing("inputChannel") = CtqyDataClass.CardTxns(iTxn).InputChannel
                                        newDealing("txnCode") = CtqyDataClass.CardTxns(iTxn).TxnCode
                                        Try
                                            newDealing("earnAmount") = CDec(CtqyDataClass.CardTxns(iTxn).EarnAmount.ToString.Replace(".", sDecimalSeparator))
                                        Catch
                                            newDealing("earnAmount") = 0
                                        End Try
                                        Try
                                            newDealing("redeemAmount") = CDec(CtqyDataClass.CardTxns(iTxn).RedeemAmount.ToString.Replace(".", sDecimalSeparator))
                                        Catch
                                            newDealing("redeemAmount") = 0
                                        End Try
                                        Try
                                            newDealing("transferAmount") = CDec(CtqyDataClass.CardTxns(iTxn).TransferAmount.ToString.Replace(".", sDecimalSeparator))
                                        Catch
                                            newDealing("transferAmount") = 0
                                        End Try
                                        Try
                                            newDealing("adjustAmount") = CDec(CtqyDataClass.CardTxns(iTxn).AdjustAmount.ToString.Replace(".", sDecimalSeparator))
                                        Catch
                                            newDealing("adjustAmount") = 0
                                        End Try
                                        newDealing("status") = CtqyDataClass.CardTxns(iTxn).Status
                                        newDealing("txnDate") = CDate(CtqyDataClass.CardTxns(iTxn).TxnDate.Insert(4, "/").Insert(7, "/"))
                                        newDealing("txnTime") = CDate(CtqyDataClass.CardTxns(iTxn).TxnTime)
                                        newDealing("merchantNo") = CtqyDataClass.CardTxns(iTxn).MerchantNo
                                        newDealing("termNo") = CtqyDataClass.CardTxns(iTxn).TermNo
                                        newDealing("IsAfterActivatedDate") = (newDealing("txnDate") >= newState("ActivatedDate"))
                                        newDealing.AcceptChanges()

                                        drQueriedDealing = dtQueriedDealing.Rows.Add
                                        For bColumn As Byte = 0 To dtQueriedDealing.Columns.Count - 1
                                            drQueriedDealing(bColumn) = newDealing(bColumn)
                                        Next
                                    Next
                                End If

                                If drQueriedState("QueryStartDate").ToString = "" Then
                                    drQueriedState("QueryStartDate") = newState("ActivatedDate")
                                    newState("QueryStartDate") = newState("ActivatedDate")
                                    newState.AcceptChanges()
                                End If
                                drQueriedState("QueryEndDate") = DateAdd(DateInterval.Day, -1, dtToday)
                            Else
                                For Each dr As DataRowView In dvDealing
                                    dr.Delete()
                                    If dr.Row.RowState = DataRowState.Deleted Then dr.Row.AcceptChanges()
                                Next
                                newDealing = dvDealing.Table.Rows.Add()
                                newDealing("CardNo") = sCardNo
                                newDealing("txnId") = "错误！"
                                newDealing("inputChannel") = CtqyDataClass.CodeMsg.Msg
                                newDealing("IsAfterActivatedDate") = 1
                                newDealing.AcceptChanges()
                            End If
                        End If
                    Else
                        For Each dr As DataRowView In dvDealing
                            dr.Delete()
                            If dr.Row.RowState = DataRowState.Deleted Then dr.Row.AcceptChanges()
                        Next
                        newDealing = dvDealing.Table.Rows.Add()
                        newDealing("CardNo") = sCardNo
                        newDealing("txnId") = "错误！"
                        newDealing("inputChannel") = CtqyDataClass.CodeMsg.Msg
                        newDealing("IsAfterActivatedDate") = 1
                        newDealing.AcceptChanges()
                    End If

                    dvDealing.RowFilter = "CardNo='" & sCardNo & "' And IsAfterActivatedDate=1"
                    If dvDealing.Count = 0 Then
                        newDealing = dvDealing.Table.Rows.Add()
                        newDealing("CardNo") = sCardNo
                        newDealing("txnId") = "没有明细"
                        newDealing.AcceptChanges()
                    End If

                    CtqyClass = Nothing : CtqyDataClass = Nothing
                Catch ex As Exception
                    For Each dr As DataRowView In dvDealing
                        dr.Delete()
                        If dr.Row.RowState = DataRowState.Deleted Then dr.Row.AcceptChanges()
                    Next
                    newDealing = dvDealing.Table.Rows.Add()
                    newDealing("CardNo") = sCardNo
                    newDealing("txnId") = "错误！"
                    newDealing("inputChannel") = ex.Message
                    newDealing("IsAfterActivatedDate") = 1
                    newDealing.AcceptChanges()
                Finally
                    If c4Service IsNot Nothing Then c4Service.Dispose() : c4Service = Nothing
                End Try
            End If

            dvDealing.RowFilter = "CardNo='" & sCardNo & "' And IsAfterActivatedDate=1"
            If newDealing("txnId").ToString = "错误！" Then
                Me.lblDealing.ForeColor = Color.Red
                Me.lblDealing.Text = "（到CUL系统查询购物卡交易明细时发生错误！错误提示：" & newDealing("inputChannel").ToString & "）"
                dvDealing.RowFilter = "1=2"
            ElseIf newDealing("txnId").ToString = "没有明细" Then
                Me.lblDealing.ForeColor = SystemColors.ControlText
                Me.lblDealing.Text = "（没有交易明细）"
                dvDealing.RowFilter = "1=2"
            Else
                For Each column As DataGridViewColumn In Me.dgvDealing.Columns
                    If column.Visible AndAlso column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells Then
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    ElseIf column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill Then
                        column.MinimumWidth = 2
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        column.MinimumWidth = column.Width
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    End If
                Next

                Me.dgvState.Select()
                Me.dgvDealing.Select()
                Me.lblDealing.Visible = False

                Dim sSQL As String = "Exec wCardStateDealingInsert @SSID=" & frmMain.sSSID & ",", sStateSQL As String = ""
                If drQueriedState.RowState = DataRowState.Added OrElse drQueriedState("Balance") <> drQueriedState("Balance", DataRowVersion.Original) Then sStateSQL = "@Balance=" & drQueriedState("Balance").ToString.Replace(",", ".") & ","
                If drQueriedState.RowState = DataRowState.Added OrElse drQueriedState("ActivatedDate").ToString <> drQueriedState("ActivatedDate", DataRowVersion.Original).ToString Then sStateSQL = sStateSQL & "@ActivatedDate='" & Format(drQueriedState("ActivatedDate"), "yyyy\/MM\/dd") & "',"
                If drQueriedState.RowState = DataRowState.Added OrElse drQueriedState("EffectiveDate").ToString <> drQueriedState("EffectiveDate", DataRowVersion.Original).ToString Then sStateSQL = sStateSQL & "@EffectiveDate='" & Format(drQueriedState("EffectiveDate"), "yyyy\/MM\/dd") & "',"
                If drQueriedState.RowState = DataRowState.Added OrElse drQueriedState("StoreName").ToString <> drQueriedState("StoreName", DataRowVersion.Original).ToString Then sStateSQL = sStateSQL & "@StoreName='" & drQueriedState("StoreName").ToString & "',"
                If drQueriedState.RowState = DataRowState.Added OrElse drQueriedState("CardState").ToString <> drQueriedState("CardState", DataRowVersion.Original).ToString Then sStateSQL = sStateSQL & "@CardState='" & drQueriedState("CardState").ToString & "',"
                If drQueriedState.RowState = DataRowState.Added OrElse drQueriedState("QueryStartDate").ToString <> drQueriedState("QueryStartDate", DataRowVersion.Original).ToString Then sStateSQL = sStateSQL & "@QueryStartDate='" & Format(drQueriedState("QueryStartDate"), "yyyy\/MM\/dd") & "',"
                If drQueriedState.RowState = DataRowState.Added OrElse drQueriedState("QueryEndDate").ToString <> drQueriedState("QueryEndDate", DataRowVersion.Original).ToString Then sStateSQL = sStateSQL & "@QueryEndDate='" & Format(drQueriedState("QueryEndDate"), "yyyy\/MM\/dd") & "',"
                If sStateSQL = "" Then drQueriedState.AcceptChanges()
                If drQueriedState.RowState = DataRowState.Unchanged Then
                    sSQL = sSQL & "@QueryMode=0,"
                ElseIf drQueriedState.RowState = DataRowState.Modified Then
                    sSQL = sSQL & "@QueryMode=2,"
                End If
                sSQL = sSQL & "@QueryTime='" & Now.ToString("yyyy\/MM\/dd HH:mm:ss") & "',@CardNo='" & sCardNo & "'," & sStateSQL
                If dtQueriedDealing.Rows.Count > 0 Then
                    If DB.ModifyTable("Select * Into #tempDealing From [State&Dealing].dbo.CardDealing Where 1=2") = -1 OrElse DB.BulkCopyTable("#tempDealing", dtQueriedDealing) = -1 Then
                        sSQL = ""
                    Else
                        sSQL = sSQL & "@DealingRecords=" & dtQueriedDealing.Rows.Count.ToString & ","
                    End If
                End If
                If sSQL <> "" Then
                    sSQL = sSQL.Substring(0, sSQL.Length - 1)
                    DB.ModifyTable(sSQL)
                End If
                Me.btnQuery.Enabled = False
                Me.btnHistory.Enabled = True
            End If

            DB.Close()
        ElseIf dvState(0)("CardState").ToString = "未激活" AndAlso dvState(0)("ActivatedDate").ToString = "" Then
            Me.lblState.ForeColor = SystemColors.ControlText
            Me.lblState.Text = "（该购物卡未激活，是空白卡。）"
            dvState.RowFilter = "1=2"
            Me.lblDealing.ForeColor = SystemColors.ControlText
            Me.lblDealing.Text = "（该购物卡未激活，不存在交易明细。）"
            dvDealing.RowFilter = "1=2"
            Me.btnQuery.Enabled = False
            Me.btnHistory.Enabled = False
        Else
            For Each column As DataGridViewColumn In Me.dgvState.Columns
                If column.Visible AndAlso column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells Then
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                ElseIf column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill Then
                    column.MinimumWidth = 2
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    column.MinimumWidth = column.Width
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End If
            Next
            Me.dgvState.Select()
            Me.btnClose.Select()
            Me.lblState.Visible = False

            If dvState(0)("AlreadyQueryAll") Then
                dvDealing.RowFilter = "CardNo='" & sCardNo & "'"
            Else
                dvDealing.RowFilter = "CardNo='" & sCardNo & "' And IsAfterActivatedDate=1"
            End If
            If dvDealing(0)("txnId").ToString = "错误！" Then
                Me.lblDealing.ForeColor = Color.Red
                Me.lblDealing.Text = "（到CUL系统查询购物卡交易明细时发生错误！错误提示：" & dvDealing(0)("inputChannel").ToString & "）"
                dvDealing.RowFilter = "1=2"
            ElseIf dvDealing(0)("txnId").ToString = "没有明细" Then
                Me.lblDealing.ForeColor = SystemColors.ControlText
                Me.lblDealing.Text = "（没有交易明细）"
                dvDealing.RowFilter = "1=2"
            Else
                For Each column As DataGridViewColumn In Me.dgvDealing.Columns
                    If column.Visible AndAlso column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells Then
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    End If
                Next
                Me.dgvDealing.Select()
                Me.btnClose.Select()
                Me.lblDealing.Visible = False
                Me.btnQuery.Enabled = False
                Me.btnHistory.Enabled = (Not dvState(0)("AlreadyQueryAll"))
            End If
        End If

        Me.txbCardNo.Select() : Me.txbCardNo.SelectAll()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub QueryAfter3()
        Me.Cursor = Cursors.WaitCursor

        dvState.RowFilter = "CardNo='" & sCardNo & "'"
        If dvState.Count = 0 Then
            Me.lblState.Text = "（正在查询状态……）"
            Me.Refresh()

            Dim sMerchantNo As String = dvCULParameter.Table.Select("CULCardBin='" & sCardNo.Substring(0, 5) & "'")(0)("CULStoreCode").ToString
            Dim sDecimalSeparator As String = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
            Dim c4Service As C4ShoppingCardService.C4ShoppingCardService = Nothing

            Try
                c4Service = New C4ShoppingCardService.C4ShoppingCardService()
                Dim infoClass As New C4ShoppingCardService.VInfoClass()
                infoClass.MerchantNo = sMerchantNo
                infoClass.UserID = sMerchantNo
                infoClass.TypeId = sCardNo.Substring(0, 8)
                infoClass.SeqNoFrom = sCardNo.Substring(8)
                infoClass.SeqNoTo = sCardNo.Substring(8)
                infoClass.IsPager = "N"
                infoClass.PageNo = "1"

                Dim infoDataClass As C4ShoppingCardService.VInfoDataClass = c4Service.vinfo(infoClass)
                If infoDataClass.VCodeMsg.Code = "01" Then
                    Dim newCard As DataRow = dvState.Table.Rows.Add(sCardNo)
                    Try
                        newCard("Balance") = CDec(infoDataClass.Vouchers(0).Amount.ToString.Replace(".", sDecimalSeparator))
                    Catch
                        newCard("Balance") = 0
                    End Try
                    newCard("AlreadyQueryAll") = 1

                    dvDealing.RowFilter = "CardNo='" & sCardNo & "'"
                    Dim newDealing As DataRow = Nothing
                    If infoDataClass.Vouchers(0).Status < "2" Then
                        newCard("CardState") = "未激活"
                        newCard.AcceptChanges()

                        Me.lblState.ForeColor = SystemColors.ControlText
                        Me.lblState.Text = "（该条码卡未激活，是空白卡。）"
                        dvState.RowFilter = "1=2"
                        newDealing = dvDealing.Table.Rows.Add()
                        newDealing("CardNo") = sCardNo
                        newDealing("txnId") = "未激活"
                        newDealing.AcceptChanges()
                        Me.lblDealing.ForeColor = SystemColors.ControlText
                        Me.lblDealing.Text = "（该条码卡未激活，不存在交易明细。）"
                        dvDealing.RowFilter = "1=2"
                    Else
                        Select Case infoDataClass.Vouchers(0).Status
                            Case "2"
                                newCard("CardState") = "已激活"
                            Case "3"
                                newCard("Balance") = 0
                                newCard("CardState") = "已使用"
                            Case "4"
                                newCard("CardState") = "已过期"
                            Case Else
                                newCard("CardState") = "已冻结"
                        End Select
                        Try
                            newCard("ActivatedDate") = CDate(infoDataClass.Vouchers(0).ActivedDate)
                        Catch
                        End Try
                        Try
                            newCard("EffectiveDate") = CDate(infoDataClass.Vouchers(0).ExpiredDate.Insert(4, "/").Insert(7, "/"))
                        Catch
                        End Try
                        newCard("StoreName") = infoDataClass.Vouchers(0).ActivedDMer & "-" & infoDataClass.Vouchers(0).ActivedMerName

                        For Each column As DataGridViewColumn In Me.dgvState.Columns
                            If column.Visible AndAlso column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells Then
                                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                            End If
                        Next
                        Me.dgvState.Select()
                        Me.btnClose.Select()
                        Me.lblState.Visible = False

                        Me.lblDealing.Text = "（正在查询交易明细……）"
                        Me.Refresh()

                        Try
                            Dim CtqyClass As New C4ShoppingCardService.VtqyClass()
                            CtqyClass.MerchantNo = sMerchantNo
                            CtqyClass.UserID = sMerchantNo
                            CtqyClass.TypeId = sCardNo.Substring(0, 8)
                            CtqyClass.SeqNo = sCardNo.Substring(8)
                            CtqyClass.QueryType = "T"
                            CtqyClass.IsPager = "N"
                            CtqyClass.PageNo = "1"
                            CtqyClass.PageSize = "1000000"

                            Dim CtqyDataClass As C4ShoppingCardService.VtqyDataClass = c4Service.vtqy(CtqyClass), iVoucherTxns As Integer = 0
                            If CtqyDataClass.VCodeMsg.Code = "00" Then
                                iVoucherTxns = CInt(CtqyDataClass.Total) - 1
                                If iVoucherTxns > -1 Then
                                    For iTxn As Integer = 0 To iVoucherTxns
                                        If CtqyDataClass.VoucherTxns(iTxn).OperType <> "IDAD" OrElse CtqyDataClass.VoucherTxns(iTxn).RespCode = "00" Then '仅当RespCode="00"时才是成功的消费记录
                                            newDealing = dvDealing.Table.Rows.Add()
                                            newDealing("CardNo") = sCardNo
                                            newDealing("txnId") = CtqyDataClass.VoucherTxns(iTxn).TxnId
                                            Select Case CtqyDataClass.VoucherTxns(iTxn).OperType
                                                Case "ISLV" '激活
                                                    newDealing("inputChannel") = "WEB网站"
                                                    newDealing("txnCode") = "激活"
                                                    Try
                                                        newDealing("earnAmount") = CDec(CtqyDataClass.VoucherTxns(iTxn).Amount.ToString.Replace(".", sDecimalSeparator))
                                                    Catch
                                                        newDealing("earnAmount") = 0
                                                    End Try
                                                    newDealing("redeemAmount") = 0
                                                    newDealing("transferAmount") = 0
                                                    newDealing("adjustAmount") = newDealing("earnAmount")
                                                Case "IDAD" '消费
                                                    newDealing("inputChannel") = "POS渠道"
                                                    newDealing("txnCode") = "积分兑换"
                                                    newDealing("earnAmount") = 0
                                                    Try
                                                        newDealing("redeemAmount") = CDec(CtqyDataClass.VoucherTxns(iTxn).Amount.ToString.Replace(".", sDecimalSeparator))
                                                    Catch
                                                        newDealing("redeemAmount") = 0
                                                    End Try
                                                    newDealing("transferAmount") = 0
                                                    newDealing("adjustAmount") = 0
                                                Case "IDVV" '激活撤销
                                                    newDealing("inputChannel") = "WEB网站"
                                                    newDealing("txnCode") = "激活撤销"
                                                    Try
                                                        newDealing("earnAmount") = CDec(CtqyDataClass.VoucherTxns(iTxn).Amount.ToString.Replace(".", sDecimalSeparator))
                                                    Catch
                                                        newDealing("earnAmount") = 0
                                                    End Try
                                                    newDealing("redeemAmount") = 0
                                                    newDealing("transferAmount") = 0
                                                    newDealing("adjustAmount") = newDealing("earnAmount")
                                            End Select
                                            newDealing("status") = "成功"
                                            newDealing("txnDate") = CDate(CtqyDataClass.VoucherTxns(iTxn).SettleDate.Insert(4, "/").Insert(7, "/"))
                                            newDealing("txnTime") = CDate(CtqyDataClass.VoucherTxns(iTxn).CreateTimestamp.Insert(4, "/").Insert(7, "/").Insert(10, " ").Insert(13, ":").Insert(16, ":"))
                                            newDealing("merchantNo") = CtqyDataClass.VoucherTxns(iTxn).MerNo & "-" & CtqyDataClass.VoucherTxns(iTxn).MerName
                                            newDealing("termNo") = CtqyDataClass.VoucherTxns(iTxn).TermNo
                                            newDealing("IsAfterActivatedDate") = 1
                                            newDealing.AcceptChanges()
                                        End If
                                    Next
                                End If

                                CtqyClass.QueryType = "H"
                                CtqyClass.DateFrom = Format(newCard("ActivatedDate"), "yyyyMMdd")
                                CtqyClass.DateTo = Format(Today(), "yyyyMMdd")

                                CtqyDataClass = c4Service.vtqy(CtqyClass)
                                If CtqyDataClass.VCodeMsg.Code = "01" Then
                                    iVoucherTxns = CInt(CtqyDataClass.Total) - 1
                                    If iVoucherTxns > -1 Then
                                        For iTxn As Integer = 0 To iVoucherTxns
                                            If CtqyDataClass.VoucherTxns(iTxn).OperType = "IDAD" AndAlso CtqyDataClass.VoucherTxns(iTxn).RespCode = "00" Then '仅取成功的消费记录
                                                newDealing = dvDealing.Table.Rows.Add()
                                                newDealing("CardNo") = sCardNo
                                                newDealing("txnId") = CtqyDataClass.VoucherTxns(iTxn).TxnId
                                                newDealing("inputChannel") = "POS渠道"
                                                newDealing("txnCode") = "积分兑换"
                                                newDealing("earnAmount") = 0
                                                Try
                                                    newDealing("redeemAmount") = CDec(CtqyDataClass.VoucherTxns(iTxn).Amount.ToString.Replace(".", sDecimalSeparator))
                                                Catch
                                                    newDealing("redeemAmount") = 0
                                                End Try
                                                newDealing("transferAmount") = 0
                                                newDealing("adjustAmount") = 0
                                                newDealing("status") = "成功"
                                                newDealing("txnDate") = CDate(CtqyDataClass.VoucherTxns(iTxn).SettleDate.Insert(4, "/").Insert(7, "/"))
                                                newDealing("txnTime") = CDate(CtqyDataClass.VoucherTxns(iTxn).CreateTimestamp.Insert(4, "/").Insert(7, "/").Insert(10, " ").Insert(13, ":").Insert(16, ":"))
                                                newDealing("merchantNo") = CtqyDataClass.VoucherTxns(iTxn).MerNo & "-" & CtqyDataClass.VoucherTxns(iTxn).MerName
                                                newDealing("termNo") = CtqyDataClass.VoucherTxns(iTxn).TermNo
                                                newDealing("IsAfterActivatedDate") = 1
                                                newDealing.AcceptChanges()
                                            End If
                                        Next
                                    End If

                                    If dvDealing.Count = 0 Then
                                        newDealing = dvDealing.Table.Rows.Add()
                                        newDealing("CardNo") = sCardNo
                                        newDealing("txnId") = "没有明细"
                                        newDealing.AcceptChanges()
                                    End If
                                Else
                                    For Each dr As DataRowView In dvDealing
                                        dr.Delete()
                                        If dr.Row.RowState = DataRowState.Deleted Then dr.Row.AcceptChanges()
                                    Next
                                    newDealing = dvDealing.Table.Rows.Add()
                                    newDealing("CardNo") = sCardNo
                                    newDealing("txnId") = "错误！"
                                    newDealing("inputChannel") = CtqyDataClass.VCodeMsg.Msg
                                    newDealing("IsAfterActivatedDate") = 1
                                    newDealing.AcceptChanges()
                                End If
                            Else
                                For Each dr As DataRowView In dvDealing
                                    dr.Delete()
                                    If dr.Row.RowState = DataRowState.Deleted Then dr.Row.AcceptChanges()
                                Next
                                newDealing = dvDealing.Table.Rows.Add()
                                newDealing("CardNo") = sCardNo
                                newDealing("txnId") = "错误！"
                                newDealing("inputChannel") = CtqyDataClass.VCodeMsg.Msg
                                newDealing("IsAfterActivatedDate") = 1
                                newDealing.AcceptChanges()
                            End If

                            CtqyClass = Nothing : CtqyDataClass = Nothing
                        Catch ex As Exception
                            For Each dr As DataRowView In dvDealing
                                dr.Delete()
                                If dr.Row.RowState = DataRowState.Deleted Then dr.Row.AcceptChanges()
                            Next
                            newDealing = dvDealing.Table.Rows.Add()
                            newDealing("CardNo") = sCardNo
                            newDealing("txnId") = "错误！"
                            newDealing("inputChannel") = ex.Message
                            newDealing.AcceptChanges()
                        End Try

                        dvDealing.RowFilter = "CardNo='" & sCardNo & "'"
                        If newDealing("txnId").ToString = "错误！" Then
                            Me.lblDealing.ForeColor = Color.Red
                            Me.lblDealing.Text = "（到CUL系统查询条码卡交易明细时发生错误！错误提示：" & newDealing("inputChannel").ToString & "）"
                            dvDealing.RowFilter = "1=2"
                        ElseIf newDealing("txnId").ToString = "没有明细" Then
                            Me.lblDealing.ForeColor = SystemColors.ControlText
                            Me.lblDealing.Text = "（没有交易明细）"
                            dvDealing.RowFilter = "1=2"
                        Else
                            For Each column As DataGridViewColumn In Me.dgvDealing.Columns
                                If column.Visible AndAlso column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells Then
                                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                ElseIf column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill Then
                                    column.MinimumWidth = 2
                                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                    column.MinimumWidth = column.Width
                                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                                End If
                            Next
                            Me.dgvDealing.Select()
                            Me.btnClose.Select()
                            Me.lblDealing.Visible = False
                            Me.btnQuery.Enabled = False
                        End If
                    End If
                Else
                    Me.lblState.ForeColor = Color.Red
                    Me.lblState.Text = "（到CUL系统查询条码卡状态时发生错误！错误提示：" & infoDataClass.VCodeMsg.Msg & "）"
                    dvState.RowFilter = "1=2"
                    Me.lblDealing.ForeColor = Color.Red
                    Me.lblDealing.Text = Me.lblState.Text
                    dvDealing.RowFilter = "1=2"
                End If

                infoClass = Nothing
                infoDataClass = Nothing
            Catch ex As Exception
                Me.lblState.ForeColor = Color.Red
                Me.lblState.Text = "（到CUL系统查询条码卡状态时发生错误！错误提示：" & ex.Message & "）"
                dvState.RowFilter = "1=2"
                Me.lblDealing.ForeColor = Color.Red
                Me.lblDealing.Text = Me.lblState.Text
                dvDealing.RowFilter = "1=2"
            Finally
                If c4Service IsNot Nothing Then c4Service.Dispose() : c4Service = Nothing
            End Try
        ElseIf dvState(0)("CardState").ToString = "未激活" Then
            Me.lblState.ForeColor = SystemColors.ControlText
            Me.lblState.Text = "（该条码卡未激活。）"
            dvState.RowFilter = "1=2"
            Me.lblDealing.ForeColor = SystemColors.ControlText
            Me.lblDealing.Text = "（该条码卡未激活，不存在交易明细。）"
            dvDealing.RowFilter = "1=2"
            Me.btnQuery.Enabled = False
        Else
            For Each column As DataGridViewColumn In Me.dgvState.Columns
                If column.Visible AndAlso column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells Then
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                ElseIf column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill Then
                    column.MinimumWidth = 2
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    column.MinimumWidth = column.Width
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End If
            Next
            Me.dgvState.Select()
            Me.btnClose.Select()
            Me.lblState.Visible = False

            dvDealing.RowFilter = "CardNo='" & sCardNo & "'"
            If dvDealing(0)("txnId").ToString = "错误！" Then
                Me.lblDealing.ForeColor = Color.Red
                Me.lblDealing.Text = "（到CUL系统查询条码卡交易明细时发生错误！错误提示：" & dvDealing(0)("inputChannel").ToString & "）"
                dvDealing.RowFilter = "1=2"
            ElseIf dvDealing(0)("txnId").ToString = "没有明细" Then
                Me.lblDealing.ForeColor = SystemColors.ControlText
                Me.lblDealing.Text = "（没有交易明细）"
                dvDealing.RowFilter = "1=2"
            Else
                For Each column As DataGridViewColumn In Me.dgvDealing.Columns
                    If column.Visible AndAlso column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells Then
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    End If
                Next
                Me.dgvDealing.Select()
                Me.btnClose.Select()
                Me.lblDealing.Visible = False
                Me.btnQuery.Enabled = False
            End If
        End If

        Me.txbCardNo.Select() : Me.txbCardNo.SelectAll()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub QueryBefore1()
        If MessageBox.Show("注意：    " & Chr(13) & Chr(13) & "激活日期之前的交易明细记录可能属于另一顾客！    " & Chr(13) & Chr(13) & "是否确实需要查询这些记录？    ", "请确认查询激活日期之前的交易明细：", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then Return

        Dim sRowFilter As String = dvDealing.RowFilter, sFirstState As String = dvDealing(0)("txnId").ToString, sOldError As String = dvDealing(0)("inputChannel").ToString, sError As String = "", sMerchantNo As String = dvCULParameter.Table.Select("CULCardBin='" & sCardNo.Substring(4, 5) & "'")(0)("CULStoreCode").ToString, newDealing As DataRow
        dvDealing.RowFilter = "1=2"

        Me.Cursor = Cursors.WaitCursor
        Me.lblDealing.Visible = True
        Me.lblDealing.Text = "（正在查询激活日期之前的交易明细……）"
        Me.Refresh()

        Dim sDecimalSeparator As String = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
        Dim c4Service As C4ShoppingCardService.C4ShoppingCardService = Nothing
        Try
            c4Service = New C4ShoppingCardService.C4ShoppingCardService
            Dim CtqyClass As New C4ShoppingCardService.CtqyClass()
            CtqyClass.MerchantNo = sMerchantNo
            CtqyClass.UserID = sMerchantNo
            CtqyClass.CardNo = sCardNo
            CtqyClass.QueryType = "H"
            CtqyClass.DateFrom = "20000101"
            CtqyClass.DateTo = Format(DateAdd(DateInterval.Day, -1, dvState(0)("ActivatedDate")), "yyyyMMdd")
            CtqyClass.IsPager = "N"
            CtqyClass.PageNo = "1"
            CtqyClass.PageSize = "1000000"

            Dim CtqyDataClass As C4ShoppingCardService.CtqyDataClass = c4Service.ctqy(CtqyClass), icardTxns As Integer = 0
            If CtqyDataClass.CodeMsg.Code = "PZ" Then
                icardTxns = CInt(CtqyDataClass.Total) - 1
                If icardTxns = -1 Then
                    MessageBox.Show("没有激活日期之前的交易明细记录。    ", "没有交易明细。", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    For iTxn As Integer = 0 To icardTxns
                        newDealing = dvDealing.Table.Rows.Add()
                        newDealing("CardNo") = sCardNo
                        newDealing("txnId") = CtqyDataClass.CardTxns(iTxn).TxnId
                        newDealing("inputChannel") = CtqyDataClass.CardTxns(iTxn).InputChannel
                        newDealing("txnCode") = CtqyDataClass.CardTxns(iTxn).TxnCode
                        Try
                            newDealing("earnAmount") = CDec(CtqyDataClass.CardTxns(iTxn).EarnAmount.ToString.Replace(".", sDecimalSeparator))
                        Catch
                            newDealing("earnAmount") = 0
                        End Try
                        Try
                            newDealing("redeemAmount") = CDec(CtqyDataClass.CardTxns(iTxn).RedeemAmount.ToString.Replace(".", sDecimalSeparator))
                        Catch
                            newDealing("redeemAmount") = 0
                        End Try
                        Try
                            newDealing("transferAmount") = CDec(CtqyDataClass.CardTxns(iTxn).TransferAmount.ToString.Replace(".", sDecimalSeparator))
                        Catch
                            newDealing("transferAmount") = 0
                        End Try
                        Try
                            newDealing("adjustAmount") = CDec(CtqyDataClass.CardTxns(iTxn).AdjustAmount.ToString.Replace(".", sDecimalSeparator))
                        Catch
                            newDealing("adjustAmount") = 0
                        End Try
                        newDealing("status") = CtqyDataClass.CardTxns(iTxn).Status
                        newDealing("txnDate") = CDate(CtqyDataClass.CardTxns(iTxn).TxnDate.Insert(4, "/").Insert(7, "/"))
                        newDealing("txnTime") = CDate(CtqyDataClass.CardTxns(iTxn).TxnTime)
                        newDealing("merchantNo") = CtqyDataClass.CardTxns(iTxn).MerchantNo
                        newDealing("termNo") = CtqyDataClass.CardTxns(iTxn).TermNo
                        newDealing("IsAfterActivatedDate") = 0
                        newDealing.AcceptChanges()
                    Next
                End If

                dvState(0)("AlreadyQueryAll") = 1
                dvState.Table.AcceptChanges()
                Me.btnHistory.Enabled = False
            Else
                sError = CtqyDataClass.CodeMsg.Msg
                MessageBox.Show("到CUL系统查询交易明细时发生错误！下面是来自CUL系统的错误提示：    " & Chr(13) & Chr(13) & sError & Space(4), "查询出错！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

            CtqyClass = Nothing : CtqyDataClass = Nothing
        Catch ex As Exception
            sError = ex.Message
            MessageBox.Show("查询交易明细时发生错误！下面是错误提示：    " & Chr(13) & Chr(13) & sError & Space(4), "查询出错！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            If c4Service IsNot Nothing Then c4Service.Dispose() : c4Service = Nothing
        End Try

        dvDealing.RowFilter = sRowFilter
        If dvDealing.ToTable.Select("IsAfterActivatedDate=0").Length = 0 Then
            If sFirstState = "错误！" Then
                Me.lblDealing.ForeColor = Color.Red
                Me.lblDealing.Text = "（到CUL系统查询购物卡交易明细时发生错误！错误提示：" & IIf(sError = "", sOldError, sError) & "）"
                dvDealing.RowFilter = "1=2"
            ElseIf sFirstState = "没有明细" Then
                If sError = "" Then
                    Me.lblDealing.ForeColor = SystemColors.ControlText
                    Me.lblDealing.Text = "（没有交易明细）"
                Else
                    Me.lblDealing.ForeColor = Color.Red
                    Me.lblDealing.Text = "（到CUL系统查询购物卡交易明细时发生错误！错误提示：" & sError & "）"
                End If
                dvDealing.RowFilter = "1=2"
            Else
                Me.lblDealing.Visible = False
            End If
        Else
            If sFirstState = "错误！" OrElse sFirstState = "没有明细" Then
                dvDealing.Table.Select("txnId='" & sFirstState & "'")(0).Delete()
                dvDealing.Table.AcceptChanges()
            End If
            For Each column As DataGridViewColumn In Me.dgvDealing.Columns
                If column.Visible AndAlso column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells Then
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                ElseIf column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill Then
                    column.MinimumWidth = 2
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    column.MinimumWidth = column.Width
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End If
            Next
            Me.lblDealing.Visible = False
        End If

        Me.dgvState.Select() : Me.dgvDealing.Select()
        Me.txbCardNo.Select() : Me.txbCardNo.SelectAll()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub QueryBefore2()
        If MessageBox.Show("注意：    " & Chr(13) & Chr(13) & "激活日期之前的交易明细记录可能属于另一顾客！    " & Chr(13) & Chr(13) & "是否确实需要查询这些记录？    ", "请确认查询激活日期之前的交易明细：", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then Return

        Dim sRowFilter As String = dvDealing.RowFilter, sFirstState As String = dvDealing(0)("txnId").ToString, sOldError As String = dvDealing(0)("inputChannel").ToString, sError As String = "", sMerchantNo As String = dvCULParameter.Table.Select("CULCardBin='" & sCardNo.Substring(4, 5) & "'")(0)("CULStoreCode").ToString, newDealing As DataRow
        dvDealing.RowFilter = "1=2"

        Me.Cursor = Cursors.WaitCursor
        Me.lblDealing.Visible = True
        Me.lblDealing.Text = "（正在查询激活日期之前的交易明细……）"
        Me.Refresh()

        If Format(dvState(0)("QueryStartDate"), "yyyy\/MM\/dd") = "2000/01/01" Then
            dvDealing.RowFilter = "CardNo='" & sCardNo & "' And IsAfterActivatedDate=0"
            If dvDealing.Count = 0 Then MessageBox.Show("没有激活日期之前的交易明细记录。    ", "没有交易明细。", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dvState(0)("AlreadyQueryAll") = 1
            dvState.Table.AcceptChanges()
            Me.btnHistory.Enabled = False

            sRowFilter = "CardNo='" & sCardNo & "'"
        Else
            Dim sDecimalSeparator As String = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
            Dim c4Service As C4ShoppingCardService.C4ShoppingCardService = Nothing
            Try
                c4Service = New C4ShoppingCardService.C4ShoppingCardService
                Dim CtqyClass As New C4ShoppingCardService.CtqyClass()
                CtqyClass.MerchantNo = sMerchantNo
                CtqyClass.UserID = sMerchantNo
                CtqyClass.CardNo = sCardNo
                CtqyClass.QueryType = "H"
                CtqyClass.DateFrom = "20000101"
                CtqyClass.DateTo = Format(DateAdd(DateInterval.Day, -1, dvState(0)("QueryStartDate")), "yyyyMMdd")
                CtqyClass.IsPager = "N"
                CtqyClass.PageNo = "1"
                CtqyClass.PageSize = "1000000"

                Dim CtqyDataClass As C4ShoppingCardService.CtqyDataClass = c4Service.ctqy(CtqyClass), icardTxns As Integer = 0
                If CtqyDataClass.CodeMsg.Code = "PZ" Then
                    Dim dtQueriedDealing As DataTable = dvDealing.ToTable(), drQueriedDealing As DataRow
                    dtQueriedDealing.Rows.Clear()
                    dtQueriedDealing.Columns.RemoveAt(dtQueriedDealing.Columns.Count - 1)
                    dtQueriedDealing.AcceptChanges()

                    icardTxns = CInt(CtqyDataClass.Total) - 1
                    If icardTxns = -1 Then
                        MessageBox.Show("没有激活日期之前的交易明细记录。    ", "没有交易明细。", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        For iTxn As Integer = 0 To icardTxns
                            newDealing = dvDealing.Table.Rows.Add()
                            newDealing("CardNo") = sCardNo
                            newDealing("txnId") = CtqyDataClass.CardTxns(iTxn).TxnId
                            newDealing("inputChannel") = CtqyDataClass.CardTxns(iTxn).InputChannel
                            newDealing("txnCode") = CtqyDataClass.CardTxns(iTxn).TxnCode
                            Try
                                newDealing("earnAmount") = CDec(CtqyDataClass.CardTxns(iTxn).EarnAmount.ToString.Replace(".", sDecimalSeparator))
                            Catch
                                newDealing("earnAmount") = 0
                            End Try
                            Try
                                newDealing("redeemAmount") = CDec(CtqyDataClass.CardTxns(iTxn).RedeemAmount.ToString.Replace(".", sDecimalSeparator))
                            Catch
                                newDealing("redeemAmount") = 0
                            End Try
                            Try
                                newDealing("transferAmount") = CDec(CtqyDataClass.CardTxns(iTxn).TransferAmount.ToString.Replace(".", sDecimalSeparator))
                            Catch
                                newDealing("transferAmount") = 0
                            End Try
                            Try
                                newDealing("adjustAmount") = CDec(CtqyDataClass.CardTxns(iTxn).AdjustAmount.ToString.Replace(".", sDecimalSeparator))
                            Catch
                                newDealing("adjustAmount") = 0
                            End Try
                            newDealing("status") = CtqyDataClass.CardTxns(iTxn).Status
                            newDealing("txnDate") = CDate(CtqyDataClass.CardTxns(iTxn).TxnDate.Insert(4, "/").Insert(7, "/"))
                            newDealing("txnTime") = CDate(CtqyDataClass.CardTxns(iTxn).TxnTime)
                            newDealing("merchantNo") = CtqyDataClass.CardTxns(iTxn).MerchantNo
                            newDealing("termNo") = CtqyDataClass.CardTxns(iTxn).TermNo
                            newDealing("IsAfterActivatedDate") = 0
                            newDealing.AcceptChanges()

                            drQueriedDealing = dtQueriedDealing.Rows.Add
                            For bColumn As Byte = 0 To dtQueriedDealing.Columns.Count - 1
                                drQueriedDealing(bColumn) = newDealing(bColumn)
                            Next
                        Next
                    End If

                    sRowFilter = "CardNo='" & sCardNo & "'"
                    dvState(0)("AlreadyQueryAll") = 1
                    dvState(0)("QueryStartDate") = CDate("2000/01/01")
                    dvState.Table.AcceptChanges()
                    Me.btnHistory.Enabled = False

                    Dim DB As New DataBase
                    DB.Open()
                    If DB.IsConnected Then
                        If dtQueriedDealing.Rows.Count > 0 Then
                            If DB.ModifyTable("Select * Into #tempDealing From [State&Dealing].dbo.CardDealing Where 1=2") <> -1 AndAlso DB.BulkCopyTable("#tempDealing", dtQueriedDealing) <> -1 Then
                                DB.ModifyTable("Exec wCardStateDealingInsert @SSID=" & frmMain.sSSID & ",@QueryMode=2,@QueryHisitory=1,@CardNo='" & sCardNo & "',@QueryStartDate='2000/01/01',@DealingRecords=" & dtQueriedDealing.Rows.Count.ToString)
                            End If
                        Else
                            DB.ModifyTable("Exec wCardStateDealingInsert @SSID=" & frmMain.sSSID & ",@QueryMode=2,@QueryHisitory=1,@CardNo='" & sCardNo & "',@QueryStartDate='2000/01/01'")
                        End If

                        DB.Close()
                    End If
                Else
                    sError = CtqyDataClass.CodeMsg.Msg
                    MessageBox.Show("到CUL系统查询交易明细时发生错误！下面是来自CUL系统的错误提示：    " & Chr(13) & Chr(13) & sError & Space(4), "查询出错！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

                CtqyClass = Nothing : CtqyDataClass = Nothing
            Catch ex As Exception
                sError = ex.Message
                MessageBox.Show("查询交易明细时发生错误！下面是错误提示：    " & Chr(13) & Chr(13) & sError & Space(4), "查询出错！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Finally
                If c4Service IsNot Nothing Then c4Service.Dispose() : c4Service = Nothing
            End Try
        End If

        dvDealing.RowFilter = sRowFilter
        If dvDealing.ToTable.Select("IsAfterActivatedDate=0").Length = 0 Then
            If sFirstState = "错误！" Then
                Me.lblDealing.ForeColor = Color.Red
                Me.lblDealing.Text = "（到CUL系统查询购物卡交易明细时发生错误！错误提示：" & IIf(sError = "", sOldError, sError) & "）"
                dvDealing.RowFilter = "1=2"
            ElseIf sFirstState = "没有明细" Then
                If sError = "" Then
                    Me.lblDealing.ForeColor = SystemColors.ControlText
                    Me.lblDealing.Text = "（没有交易明细）"
                Else
                    Me.lblDealing.ForeColor = Color.Red
                    Me.lblDealing.Text = "（到CUL系统查询购物卡交易明细时发生错误！错误提示：" & sError & "）"
                End If
                dvDealing.RowFilter = "1=2"
            Else
                Me.lblDealing.Visible = False
            End If
        Else
            If sFirstState = "错误！" OrElse sFirstState = "没有明细" Then
                dvDealing.Table.Select("txnId='" & sFirstState & "'")(0).Delete()
                dvDealing.Table.AcceptChanges()
            End If
            For Each column As DataGridViewColumn In Me.dgvDealing.Columns
                If column.Visible AndAlso column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells Then
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                ElseIf column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill Then
                    column.MinimumWidth = 2
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    column.MinimumWidth = column.Width
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End If
            Next
            Me.lblDealing.Visible = False
        End If

        Me.dgvState.Select() : Me.dgvDealing.Select()
        Me.txbCardNo.Select() : Me.txbCardNo.SelectAll()
        Me.Cursor = Cursors.Default
    End Sub
End Class