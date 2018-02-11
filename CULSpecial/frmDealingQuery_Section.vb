
'modify code 023:
'date;2014/5/22
'auther:Hyron bjy 
'remark:新增界面，特殊操作，卡号段查询

'modify code 031:
'date;2014/7/2
'auther:Hyron bjy 
'remark:批量查询卡状态增加查询计时功能，仅供测试用

'modify code 073:
'date;2017/6/5
'auther:Qipeng 
'remark:电子卡65999卡Bin过滤

'modify code 078:
'date;2017/9/25
'auther:Qipeng 
'remark:电子卡65999卡Bin查询接口替换

'modify code 023:start-------------------------------------------------------------------------
Public Class frmDealingQuery_Section

    'modify code 078:start-------------------------------------------------------------------------
    Private sCardBin65 = "65999"
    'modify code 078:end-------------------------------------------------------------------------

    Private dvCULParameter As DataView, dvState As DataView, sCardNo As String = "", sCardNo_End As String = "", blCardNoError As Boolean = False

    Private Sub frmDealingQuery_Section_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        dvState = New DataView(dtTemp)

        With Me.dgvState
            .DataSource = dvState
            With .Columns(0)
                .HeaderText = "卡号"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .MinimumWidth = 40
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
            End With
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

            For bColumn As Byte = 0 To dvState.Table.Columns.Count - 1
                .Columns(bColumn).Name = dvState.Table.Columns(bColumn).ColumnName
            Next
        End With

        Me.lblSumBalance.Text = ""
        'modify code 031:start-------------------------------------------------------------------------
        Me.lblTimeDiff.Text = ""
        Me.lblTimeDiff.Visible = False
        'modify code 031:end-------------------------------------------------------------------------

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
        Me.lblState.ForeColor = Color.Maroon
        Me.lblState.Text = "（未查询）"
        Me.lblState.Visible = True
        If Me.txbCardNo.Text.Trim <> "" Then
            Me.btnQuery.Enabled = True
        Else
            Me.btnQuery.Enabled = False
        End If
    End Sub

    Private Sub btnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        'modify code 031:start-------------------------------------------------------------------------
        Dim dStart As Date, dEnd As Date, sTimeDiff As String
        Me.lblTimeDiff.Text = ""
        Me.lblTimeDiff.Visible = False
        dStart = Now
        'modify code 031:end-------------------------------------------------------------------------
        If sCardNo.IndexOf("8") = 0 OrElse sCardNo.IndexOf("9") = 0 Then
            Me.QueryAfter3()
        Else
            Me.QueryAfter1()
        End If
        GetSumBalance()
        'modify code 031:start-------------------------------------------------------------------------
        dEnd = Now
        sTimeDiff = DateDiff(DateInterval.Second, dStart, dEnd).ToString
        Me.lblTimeDiff.Text = "用时：" & sTimeDiff & "秒"
        Me.lblTimeDiff.Visible = True
        'modify code 031:end-------------------------------------------------------------------------
    End Sub

    Private Sub dgvState_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvState.Leave
        If Me.dgvState.CurrentCell IsNot Nothing Then Me.dgvState.CurrentCell.Selected = False
        If Me.dgvState.CurrentRow IsNot Nothing Then Me.dgvState.CurrentRow.Selected = False
    End Sub

    Private Sub QueryAfter1()
        Me.Cursor = Cursors.WaitCursor

        dvState.Table.Rows.Clear()

        Me.lblState.Visible = True
        Me.lblState.Text = "（正在查询状态……）"
        Me.Refresh()

        Dim sMerchantNo As String = dvCULParameter.Table.Select("CULCardBin='" & sCardNo.Substring(4, 5) & "'")(0)("CULStoreCode").ToString
        Dim dtTemp As DataTable = ShoppingCardOperation.GetCRFCardState(sMerchantNo, sCardNo, sCardNo_End)
        'Dim dtTemp As DataTable = ShoppingCardOperation.GetCRFCardState("100000000000000", sCardNo, sCardNo_End)

        'modify code 078:start-------------------------------------------------------------------------
        'If sCardNo.Substring(4, 5) = sCardBin65 Then
        '    dtTemp = ShoppingCardOperation.GetECardState(sMerchantNo, sCardNo, sCardNo)
        'End If
        'modify code 078:end-------------------------------------------------------------------------

        If dtTemp.Rows(0)("CardNo").ToString = "Error" Then
            Me.lblState.ForeColor = Color.Red
            Me.lblState.Text = "（到CUL系统查询购物卡状态时发生错误！错误提示：" & dtTemp.Rows(0)("StoreName").ToString & "）"
        Else

            For i As Integer = 0 To dtTemp.Rows.Count - 1
                dvState.Table.Rows.Add()
                dvState.Table.Rows(i)("CardNo") = dtTemp.Rows(i)("CardNo")
                dvState.Table.Rows(i)("Balance") = dtTemp.Rows(i)("Balance")
                dvState.Table.Rows(i)("ActivatedDate") = dtTemp.Rows(i)("ActivatedDate")
                dvState.Table.Rows(i)("EffectiveDate") = dtTemp.Rows(i)("EffectiveDate")
                dvState.Table.Rows(i)("StoreName") = dtTemp.Rows(i)("StoreName")
                dvState.Table.Rows(i)("CardState") = dtTemp.Rows(i)("CardState")
            Next

            '调整列宽
            For Each column As DataGridViewColumn In Me.dgvState.Columns
                If column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells Then
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End If
            Next

            Me.dgvState.Select()
            Me.btnClose.Select()
            Me.lblState.Visible = False

        End If

        Me.txbCardNo.Select() : Me.txbCardNo.SelectAll()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub QueryAfter3()
        Me.Cursor = Cursors.WaitCursor

        dvState.Table.Rows.Clear()

        Me.lblState.Visible = True
        Me.lblState.Text = "（正在查询状态……）"
        Me.Refresh()

        Dim sMerchantNo As String = dvCULParameter.Table.Select("CULCardBin='" & sCardNo.Substring(0, 5) & "'")(0)("CULStoreCode").ToString
        'Dim sMerchantNo As String = "100000000000000"
        Dim sDecimalSeparator As String = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
        Dim c4Service As C4ShoppingCardService.C4ShoppingCardService = Nothing

        Try
            c4Service = New C4ShoppingCardService.C4ShoppingCardService()
            Dim infoClass As New C4ShoppingCardService.VInfoClass()
            infoClass.MerchantNo = sMerchantNo
            infoClass.UserID = sMerchantNo
            infoClass.TypeId = sCardNo.Substring(0, 8)
            infoClass.SeqNoFrom = sCardNo.Substring(8)
            infoClass.SeqNoTo = sCardNo_End.Substring(8)
            infoClass.IsPager = "N"
            infoClass.PageNo = "1"

            Dim infoDataClass As C4ShoppingCardService.VInfoDataClass = c4Service.vinfo(infoClass)
            If infoDataClass.VCodeMsg.Code = "01" Then
                Dim iCards As Integer = infoDataClass.Vouchers.Length - 1
                For iCard As Integer = 0 To iCards
                    dvState.Table.Rows.Add()

                    dvState.Table.Rows(iCard)("CardNo") = infoDataClass.Vouchers(iCard).TypeId.ToString & infoDataClass.Vouchers(iCard).SeqNo.ToString

                    Try
                        dvState.Table.Rows(iCard)("Balance") = CDec(infoDataClass.Vouchers(iCard).Amount.ToString.Replace(".", sDecimalSeparator))
                    Catch
                        dvState.Table.Rows(iCard)("Balance") = 0
                    End Try

                    If infoDataClass.Vouchers(iCard).Status < "2" Then
                        dvState.Table.Rows(iCard)("CardState") = "未激活"
                    Else
                        Select Case infoDataClass.Vouchers(iCard).Status
                            Case "2"
                                dvState.Table.Rows(iCard)("CardState") = "已激活"
                            Case "3"
                                dvState.Table.Rows(iCard)("Balance") = 0
                                dvState.Table.Rows(iCard)("CardState") = "已使用"
                            Case "4"
                                dvState.Table.Rows(iCard)("CardState") = "已过期"
                            Case Else
                                dvState.Table.Rows(iCard)("CardState") = "已冻结"
                        End Select
                    End If

                    Try
                        dvState.Table.Rows(iCard)("ActivatedDate") = CDate(infoDataClass.Vouchers(iCard).ActivedDate)
                    Catch
                    End Try
                    Try
                        dvState.Table.Rows(iCard)("EffectiveDate") = CDate(infoDataClass.Vouchers(iCard).ExpiredDate.Insert(4, "/").Insert(7, "/"))
                    Catch
                    End Try
                    dvState.Table.Rows(iCard)("StoreName") = infoDataClass.Vouchers(iCard).ActivedDMer & "-" & infoDataClass.Vouchers(iCard).ActivedMerName

                    dvState.Table.AcceptChanges()

                    For Each column As DataGridViewColumn In Me.dgvState.Columns
                        If column.Visible AndAlso column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells Then
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        End If
                    Next
                    Me.dgvState.Select()
                    Me.btnClose.Select()
                    Me.lblState.Visible = False

                    Me.Refresh()
                Next
            Else
                Me.lblState.ForeColor = Color.Red
                Me.lblState.Text = "（到CUL系统查询条码卡状态时发生错误！错误提示：" & infoDataClass.VCodeMsg.Msg & "）"
            End If

            infoClass = Nothing
            infoDataClass = Nothing
        Catch ex As Exception
            Me.lblState.ForeColor = Color.Red
            Me.lblState.Text = "（到CUL系统查询条码卡状态时发生错误！错误提示：" & ex.Message & "）"
        Finally
            If c4Service IsNot Nothing Then c4Service.Dispose() : c4Service = Nothing
        End Try

        Me.txbCardNo.Select() : Me.txbCardNo.SelectAll()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txbCardNo_End_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbCardNo_End.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter AndAlso Me.btnQuery.Enabled Then Me.btnQuery.Select() : Me.btnQuery.PerformClick() : e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If Me.txbCardNo.SelectedText = Me.txbCardNo.Text Then Me.txbCardNo.Text = ""
            Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbCardNo_End_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbCardNo_End.Leave
        If Me.txbCardNo_End.Text <> Me.txbCardNo_End.Text.Trim Then Me.txbCardNo_End.Text = Me.txbCardNo_End.Text.Trim
        Dim sValue As String = Me.txbCardNo_End.Text
        If sValue = sCardNo_End Then Return

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
            sCardNo_End = sValue
        End If

        If blCardNoError = False AndAlso sValue <> "" Then
            Me.btnQuery.Enabled = True
        Else
            Me.txbCardNo.Select() : Me.txbCardNo.SelectAll()
            Me.btnQuery.Enabled = False
        End If
    End Sub

    Private Sub txbCardNo_End_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbCardNo_End.TextChanged
        If Me.txbCardNo.Text.Trim <> "" Then
            Dim bCurrentMaxLength As Byte = Me.txbCardNo.MaxLength, bNewMaxLength As Byte = 19
            If Me.txbCardNo.Text.Trim.IndexOf("8") = 0 OrElse Me.txbCardNo.Text.Trim.IndexOf("9") = 0 Then bNewMaxLength = 17
            If bNewMaxLength <> bCurrentMaxLength Then Me.txbCardNo.MaxLength = bNewMaxLength
        End If

        Me.lblCardNo.Text = ""
        Me.lblState.ForeColor = Color.Maroon
        Me.lblState.Text = "（未查询）"
        Me.lblState.Visible = True
        If Me.txbCardNo.Text.Trim <> "" Then
            Me.btnQuery.Enabled = True
        Else
            Me.btnQuery.Enabled = False
        End If
    End Sub

    Private Sub GetSumBalance()
        Dim dSumBalance As Decimal = 0
        If Not dvState Is Nothing AndAlso dvState.Table.Rows.Count > 0 Then
            For i As Integer = 0 To dvState.Table.Rows.Count - 1
                dSumBalance = dSumBalance + dvState.Table.Rows(i)("Balance")
            Next
            Me.lblSumBalance.Text = "余额汇总：" & dSumBalance.ToString & " 元"
        Else
            Me.lblSumBalance.Text = "余额汇总：0 元"
        End If
    End Sub

End Class
'modify code 023:end-------------------------------------------------------------------------