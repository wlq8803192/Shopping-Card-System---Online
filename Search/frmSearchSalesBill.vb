Public Class frmSearchSalesBill

    Private dtList As DataTable, dvCULParameter As DataView, dtDropdownCustomer As DataTable
    Private blSkipDeal As Boolean = False, sCardNo As String = "", sSalesBillCode As String = "", sEmployeeNo As String = "", blCardNoError As Boolean = False
    Private sCustomerID As String = "", sCustomerName As String = "", sCustomerPrompt As String = "提示：您可以输入客户编号、客户名称中的部分文字或客户名称拼音码来确定客户。"

    Private Declare Function LockWindowUpdate Lib "user32" (ByVal hwndLock As Long) As Long

    Private Sub frmSearchSalesBill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dvCULParameter = frmMain.dtLoginStructure.Copy.DefaultView
        dvCULParameter.RowFilter = "AreaType='S'"
        dvCULParameter = dvCULParameter.ToTable(False, "CULCardBin").DefaultView
        dvCULParameter.RowFilter = "CULCardBin Like '%|%'"
        For Each drCUL As DataRowView In dvCULParameter
            Dim saCardBins() As String = drCUL("CULCardBin").ToString.Split("|")
            For bIndex As Byte = 0 To saCardBins.Length - 1
                dvCULParameter.Table.Rows.Add(saCardBins(bIndex)).EndEdit()
            Next
        Next
        For Each drCUL As DataRow In dvCULParameter.Table.Select("CULCardBin Like '84%'")
            dvCULParameter.Table.Rows.Add("60" & drCUL("CULCardBin").ToString.Substring(2, 3)).EndEdit()
            dvCULParameter.Table.Rows.Add("86" & drCUL("CULCardBin").ToString.Substring(2, 3)).EndEdit()
            dvCULParameter.Table.Rows.Add("92" & drCUL("CULCardBin").ToString.Substring(2, 3)).EndEdit()
            dvCULParameter.Table.Rows.Add("94" & drCUL("CULCardBin").ToString.Substring(2, 3)).EndEdit()
        Next

        'modify code 073:start-------------------------------------------------------------------------
        Dim DB As New DataBase(), dtResult As DataTable = Nothing
        DB.Open()
        If DB.IsConnected Then
            dtResult = DB.GetDataTable("select t1.ExtraCardBin,t2.AreaID,isnull(t2.CULStoreCode,0) CULStoreCode from CityExtraCardBin_ELC T1 left join (SELECT S.AreaID,  A.ParentAreaID, A.CULStoreCode FROM AreaScope(" & frmMain.sLoginUserID & ") AS S INNER JOIN AreaList AS A ON S.AreaID = A.AreaID) T2 on t1.CityID = t2.ParentAreaID where T2.AreaID is not null")
            If dtResult Is Nothing Then
            ElseIf dtResult.Rows.Count > 0 Then
                For Each drCUL As DataRow In dtResult.Rows
                    dvCULParameter.Table.Rows.Add(drCUL("ExtraCardBin")).EndEdit()
                Next
            End If
        End If
        DB.Close()
        'modify code 073:end-------------------------------------------------------------------------

        dvCULParameter.RowFilter = ""
        dvCULParameter.Table.AcceptChanges()

        dtList = New DataTable()
        dtList.Columns.Add("SalesBillID", System.Type.GetType("System.Int32"))
        dtList.Columns.Add("SalesBillCode", System.Type.GetType("System.String"))
        dtList.Columns.Add("CustomerName", System.Type.GetType("System.String"))
        dtList.Columns.Add("CardQTY", System.Type.GetType("System.Int32"))
        dtList.Columns.Add("ChargedAMT", System.Type.GetType("System.Decimal"))
        dtList.Columns.Add("PayableAMT", System.Type.GetType("System.Decimal"))
        dtList.Columns.Add("SalesBillState", System.Type.GetType("System.String"))
        dtList.Columns.Add("CreatorName", System.Type.GetType("System.String"))

        With Me.dgvList
            .DataSource = dtList
            .Columns(0).Visible = False
            With .Columns(1)
                .HeaderText = "销售单号"
                .Width = 85
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns(2)
                .HeaderText = "客户名称"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns(3)
                .HeaderText = "卡数"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Format = "#,0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns(4)
                .HeaderText = "充值金额"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns(5)
                .HeaderText = "应付金额" & Chr(13) & "Payable AMT"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Format = "#,0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns(6)
                .HeaderText = "销售单状态"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns(7)
                .HeaderText = "建单"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Resizable = DataGridViewTriState.False
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With

            For bColumn As Byte = 0 To .Columns.Count - 1
                .Columns(bColumn).Name = dtList.Columns(bColumn).ColumnName
            Next
        End With

        Me.txbSalesBillCode.Select()
    End Sub

    Private Sub rdbByCustomerName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbByCustomerName.CheckedChanged
        If Me.rdbByCustomerName.Checked Then
            Me.pnlCustomer.Enabled = True
            Me.btnOK.Text = "查找 &Search"
            If Me.txbCustomerName.Visible Then
                Me.txbCustomerName.Select() : Me.txbCustomerName.SelectAll()
                Me.btnOK.Enabled = (sCustomerName <> Me.txbCustomerName.Text AndAlso Me.txbCustomerName.Text <> "")
            Else
                Me.cbbCustomerName.Select() : Me.cbbCustomerName.SelectAll()
                Me.btnOK.Enabled = (sCustomerName <> Me.cbbCustomerName.Text AndAlso Me.cbbCustomerName.Text <> "")
            End If
        Else
            Me.pnlCustomer.Enabled = False
        End If
    End Sub

    Private Sub txbCustomerName_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbCustomerName.Enter, cbbCustomerName.Enter
        If sCustomerPrompt = "存在多个相似客户。请选择其中一个。" AndAlso Me.pnlCustomer.PointToClient(Control.MousePosition).X <= Me.pnlCustomer.Width - 20 Then
            Me.cbbCustomerName.Cursor = Cursors.Arrow
            Me.cbbCustomerName.DroppedDown = True
        End If
        frmMain.statusText.Text = sCustomerPrompt
    End Sub

    Private Sub txbCustomerName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbCustomerName.KeyDown, cbbCustomerName.KeyDown
        If e.KeyCode = Keys.Enter AndAlso Me.btnOK.Enabled Then Me.btnOK.Select() : Me.btnOK.PerformClick() : e.SuppressKeyPress = True : Return
    End Sub

    Private Sub txbCustomerName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbCustomerName.Leave, cbbCustomerName.Leave
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub txbCustomerName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbCustomerName.TextChanged, cbbCustomerName.TextChanged
        If blSkipDeal Then Return

        Me.btnOK.Text = "查找 &Search"
        If Me.txbCustomerName.Visible Then
            Me.btnOK.Enabled = (sCustomerName <> Me.txbCustomerName.Text AndAlso Me.txbCustomerName.Text <> "")
        Else
            Me.btnOK.Enabled = (sCustomerName <> Me.cbbCustomerName.Text AndAlso Me.cbbCustomerName.Text <> "")
        End If
    End Sub

    Private Sub cbbCustomerName_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbCustomerName.SelectedValueChanged
        If blSkipDeal Then Return
        Me.btnOK.Text = "查找 &Search"
        Me.btnOK.Enabled = (Me.cbbCustomerName.SelectedValue IsNot Nothing AndAlso sCustomerID <> Me.cbbCustomerName.SelectedValue.ToString)
        sCustomerPrompt = "提示：您可以输入客户编号、客户名称中的部分文字或客户名称拼音码来确定客户。"
    End Sub

    Private Sub rdbBySalesBillCode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbBySalesBillCode.CheckedChanged
        If Me.rdbBySalesBillCode.Checked Then
            Me.txbSalesBillCode.Enabled = True
            Me.txbSalesBillCode.Select() : Me.txbSalesBillCode.SelectAll()
            Me.btnOK.Text = "查找 &Search"
            Me.btnOK.Enabled = (Me.lblSalesBillCodeError.Text = "" AndAlso sSalesBillCode <> Me.txbSalesBillCode.Text.Trim AndAlso Me.txbSalesBillCode.Text.Trim <> "")
        Else
            Me.txbSalesBillCode.Enabled = False
        End If
    End Sub

    Private Sub txbSalesBillCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbSalesBillCode.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter AndAlso Me.btnOK.Enabled Then Me.btnOK.Select() : Me.btnOK.PerformClick() : e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If Me.txbSalesBillCode.SelectedText = Me.txbSalesBillCode.Text Then Me.txbSalesBillCode.Text = ""
            Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbSalesBillCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbSalesBillCode.Leave
        If Not Me.rdbBySalesBillCode.Checked Then Return
        If Me.txbSalesBillCode.Text <> Me.txbSalesBillCode.Text.Trim Then Me.txbSalesBillCode.Text = Me.txbSalesBillCode.Text.Trim
        Dim sValue As String = Me.txbSalesBillCode.Text

        If sValue <> "" Then
            If Not IsNumeric(sValue) Then
                Me.lblSalesBillCodeError.Text = "（销售单号只能由数字组成！）"
            ElseIf sValue.Length < 13 Then
                Me.lblSalesBillCodeError.Text = "（销售单号位数不足 13 位！）"
            ElseIf frmMain.dtLoginStructure.Select("AreaCode='S" & sValue.Substring(0, 3) & "'").Length = 0 Then
                Me.lblSalesBillCodeError.Text = "（前3位的门店编号不存在或无权查询！）"
            Else
                Dim sDate As String = "20" & sValue.Substring(3, 6)
                sDate = sDate.Insert(4, "/").Insert(7, "/")
                If Not IsDate(sDate) Then Me.lblSalesBillCodeError.Text = "（第4至9位的日期非法！）"
            End If
        End If

        Me.btnOK.Enabled = (Me.lblSalesBillCodeError.Text = "" AndAlso sSalesBillCode <> sValue AndAlso sValue <> "")
    End Sub

    Private Sub txbSalesBillCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbSalesBillCode.TextChanged
        Me.lblSalesBillCodeError.Text = ""
        Me.btnOK.Text = "查找 &Search"
        Me.btnOK.Enabled = (Me.lblSalesBillCodeError.Text = "" AndAlso sSalesBillCode <> Me.txbSalesBillCode.Text.Trim AndAlso Me.txbSalesBillCode.Text.Trim <> "")
    End Sub

    Private Sub rdbByCardNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbByCardNo.CheckedChanged
        If Me.rdbByCardNo.Checked Then
            Me.pnlCardNo.Enabled = True
            Me.txbCardNo.Select() : Me.txbCardNo.SelectAll()
            Me.btnOK.Text = "查找 &Search"
            Me.btnOK.Enabled = (blCardNoError = False AndAlso sCardNo <> Me.txbCardNo.Text.Trim AndAlso Me.txbCardNo.Text.Trim <> "")
        Else
            Me.pnlCardNo.Enabled = False
        End If
    End Sub

    Private Sub txbCardNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbCardNo.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter AndAlso Me.btnOK.Enabled Then Me.btnOK.Select() : Me.btnOK.PerformClick() : e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If Me.txbCardNo.SelectedText = Me.txbCardNo.Text Then Me.txbCardNo.Text = ""
            Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbCardNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbCardNo.Leave
        If Not Me.rdbByCardNo.Checked Then Return
        If Me.txbCardNo.Text <> Me.txbCardNo.Text.Trim Then Me.txbCardNo.Text = Me.txbCardNo.Text.Trim
        Dim sValue As String = Me.txbCardNo.Text

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
                    Me.lblCardNo.Text = "（银商JV编号不符或无权查询该卡段！）"
                ElseIf sValue.IndexOf("94") = 0 Then
                    Me.lblCardNo.Text = "（活动券）"
                ElseIf sValue.IndexOf("92") = 0 Then
                    Me.lblCardNo.Text = "（营销券）"
                ElseIf sValue.IndexOf("86") = 0 OrElse sCardNo.Substring(5, 1) = "8" OrElse sCardNo.Substring(5, 3) = "100" Then
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
                Me.lblCardNo.Text = "（卡Bin码不符或无权查询该卡段！）"
            ElseIf sValue.IndexOf("94") = 4 Then
                Me.lblCardNo.Text = "（活动卡）"
            ElseIf sValue.IndexOf("92") = 4 Then
                Me.lblCardNo.Text = "（营销卡）"
            End If
        End If

        If blCardNoError Then
            Me.lblCardNo.ForeColor = Color.Red
        Else
            Me.lblCardNo.ForeColor = SystemColors.ControlText
        End If

        Me.btnOK.Enabled = (blCardNoError = False AndAlso sCardNo <> sValue AndAlso sValue <> "")
    End Sub

    Private Sub txbCardNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbCardNo.TextChanged
        If Me.txbCardNo.Text.Trim <> "" Then
            Dim bCurrentMaxLength As Byte = Me.txbCardNo.MaxLength, bNewMaxLength As Byte = 19
            If Me.txbCardNo.Text.Trim.IndexOf("8") = 0 OrElse Me.txbCardNo.Text.Trim.IndexOf("9") = 0 Then bNewMaxLength = 17
            If bNewMaxLength <> bCurrentMaxLength Then Me.txbCardNo.MaxLength = bNewMaxLength
        End If
        Me.lblCardNo.Text = ""
        Me.btnOK.Text = "查找 &Search"
        Me.btnOK.Enabled = (blCardNoError = False AndAlso sCardNo <> Me.txbCardNo.Text.Trim AndAlso Me.txbCardNo.Text.Trim <> "")
    End Sub

    Private Sub rdbByEmployeeNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbByEmployeeNo.CheckedChanged
        If Me.rdbByEmployeeNo.Checked Then
            Me.pnlEmployeeNo.Enabled = True
            Me.txbEmployeeNo.Select() : Me.txbEmployeeNo.SelectAll()
            Me.btnOK.Text = "查找 &Search"
            Me.btnOK.Enabled = (Me.lblEmployeeNoError.Text = "" AndAlso sEmployeeNo <> Me.txbEmployeeNo.Text.Trim AndAlso Me.txbEmployeeNo.Text.Trim <> "")
        Else
            Me.pnlEmployeeNo.Enabled = False
        End If
    End Sub

    Private Sub txbEmployeeNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbEmployeeNo.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter AndAlso Me.btnOK.Enabled Then Me.btnOK.Select() : Me.btnOK.PerformClick() : e.SuppressKeyPress = True : Return
        If Me.txbEmployeeNo.SelectedText = Me.txbEmployeeNo.Text Then Me.txbEmployeeNo.Text = ""
    End Sub

    Private Sub txbEmployeeNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbEmployeeNo.Leave
        If Not Me.rdbByEmployeeNo.Checked Then Return
        If Me.txbEmployeeNo.Text <> Me.txbEmployeeNo.Text.Trim Then Me.txbEmployeeNo.Text = Me.txbEmployeeNo.Text.Trim
        Dim sValue As String = Me.txbEmployeeNo.Text

        If sValue <> "" Then
            If sValue.Length < 10 Then
                Me.lblEmployeeNoError.Text = "（员工编号位数不足 10 位！）"
            Else
                If sValue.IndexOf("CHNHOE") <> 0 Then
                    For bChar As Byte = 0 To 4
                        If Asc(sValue.Substring(bChar, 1)) < 65 OrElse Asc(sValue.Substring(bChar, 1)) > 90 Then
                            sValue = ""
                            Exit For
                        End If
                    Next
                    If sValue <> "" Then
                        For bChar As Byte = 5 To 9
                            If Asc(sValue.Substring(bChar, 1)) < 48 OrElse Asc(sValue.Substring(bChar, 1)) > 57 Then
                                sValue = ""
                                Exit For
                            End If
                        Next
                    End If
                End If

                If sValue = "" Then Me.lblEmployeeNoError.Text = "（一般应由5位字母和5位数字组成！）"
            End If
        End If

        Me.btnOK.Enabled = (Me.lblEmployeeNoError.Text = "" AndAlso sEmployeeNo <> sValue AndAlso sValue <> "")
    End Sub

    Private Sub txbEmployeeNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbEmployeeNo.TextChanged
        Me.lblEmployeeNoError.Text = ""
        Me.btnOK.Text = "查找 &Search"
        Me.btnOK.Enabled = (Me.lblEmployeeNoError.Text = "" AndAlso sEmployeeNo <> Me.txbEmployeeNo.Text.Trim AndAlso Me.txbEmployeeNo.Text.Trim <> "")
    End Sub

    Private Sub dgvList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvList.CellDoubleClick
        If e.RowIndex <> -1 Then Me.btnOpen.PerformClick()
    End Sub

    Private Sub dgvList_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvList.CellFormatting
        If Me.dgvList.Columns(e.ColumnIndex).Name = "SalesBillState" Then
            Select Case e.Value.ToString
                Case "等待激活"
                    e.CellStyle.ForeColor = Color.Green
                    e.CellStyle.SelectionForeColor = Color.LightGreen
                Case "正在激活"
                    e.CellStyle.ForeColor = Color.SteelBlue
                    e.CellStyle.SelectionForeColor = Color.LightBlue
                Case "部分激活"
                    e.CellStyle.ForeColor = Color.Chocolate
                    e.CellStyle.SelectionForeColor = Color.PeachPuff
                Case "激活失败", "已撤销激活", "等待取消", "已被取消"
                    e.CellStyle.ForeColor = Color.Red
                    e.CellStyle.SelectionForeColor = Color.Red
            End Select
        End If
    End Sub

    Private Sub dgvList_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvList.Enter
        If Me.dgvList.CurrentRow IsNot Nothing Then Me.dgvList.CurrentRow.Selected = True : Me.btnOpen.Enabled = True
    End Sub

    Private Sub dgvList_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvList.Leave
        Dim clickedControl As Control = Me.tlpOperation.GetChildAtPoint(Me.tlpOperation.PointToClient(Control.MousePosition))
        If clickedControl IsNot Nothing AndAlso clickedControl.Name = "btnOpen" Then Return

        If Me.dgvList.CurrentCell IsNot Nothing Then Me.dgvList.CurrentCell.Selected = False
        If Me.dgvList.CurrentRow IsNot Nothing Then Me.dgvList.CurrentRow.Selected = False
        Me.btnOpen.Enabled = False
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Cursor = Cursors.WaitCursor

        Dim sTask As String = "客户", sNewCustomerID As String = "", sNewCustomerName As String = ""
        If Me.rdbByCustomerName.Checked Then
            If Me.cbbCustomerName.Visible AndAlso Me.cbbCustomerName.SelectedValue IsNot Nothing Then
                sTask = "销售单"
                sNewCustomerID = Me.cbbCustomerName.SelectedValue.ToString
                sNewCustomerName = Me.cbbCustomerName.Text.Trim
            End If
        Else
            sTask = "销售单"
        End If
        frmMain.statusText.Text = "正在查找" & sTask & "……"
        frmMain.Refresh()
        If sTask = "销售单" Then
            Me.lblSearchResult.ForeColor = SystemColors.ActiveCaption
            Me.lblSearchResult.Text = "正在查找销售单……"
            Me.Refresh()
        End If

        Dim DB As New DataBase()
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法查找" & sTask & "。请检查数据库连接。"
            If sTask = "销售单" Then
                Me.lblSearchResult.ForeColor = Color.Red
                Me.lblSearchResult.Text = "查找销售单失败！"
            End If
            Me.Cursor = Cursors.Default : Return
        End If

        If Me.rdbByCustomerName.Checked AndAlso sNewCustomerID = "" Then
            blSkipDeal = True
            If Me.txbCustomerName.Visible Then
                sNewCustomerName = Me.txbCustomerName.Text.Trim
            Else
                sNewCustomerName = Me.cbbCustomerName.Text.Trim
            End If
            If dtDropdownCustomer IsNot Nothing Then dtDropdownCustomer.Dispose() : dtDropdownCustomer = Nothing
            dtDropdownCustomer = DB.GetDataTable("Exec GetMatchedCustomerWhenSearchSalesBill " & frmMain.sLoginUserID & ",'" & sNewCustomerName.Replace("'", "''") & "'")
            If dtDropdownCustomer Is Nothing Then
                sNewCustomerID = ""
                If Me.cbbCustomerName.Visible Then
                    Me.cbbCustomerName.Visible = False
                    Me.txbCustomerName.Visible = True
                    Me.txbCustomerName.Text = sNewCustomerName
                End If
                sCustomerPrompt = "系统因在检索数据时出错而无法查找客户。请联系软件开发人员。"
                frmMain.statusText.Text = sCustomerPrompt
            Else
                Select Case dtDropdownCustomer.Rows.Count
                    Case 0
                        sNewCustomerID = ""
                        If Me.cbbCustomerName.Visible Then
                            Me.cbbCustomerName.Visible = False
                            Me.txbCustomerName.Visible = True
                            Me.txbCustomerName.Text = sNewCustomerName
                        End If
                        sCustomerPrompt = "找不到该客户，请输入其他的公司名称。"
                        frmMain.statusText.Text = sCustomerPrompt
                        Me.txbCustomerName.Select() : Me.txbCustomerName.SelectAll()
                        Me.btnOK.Enabled = False
                    Case 1
                        sNewCustomerID = dtDropdownCustomer.Rows(0)("CustomerID").ToString
                        sNewCustomerName = dtDropdownCustomer.Rows(0)("CustomerName").ToString
                        If Me.cbbCustomerName.Visible Then
                            Me.cbbCustomerName.Visible = False
                            Me.txbCustomerName.Visible = True
                        End If
                        Me.txbCustomerName.Text = sNewCustomerName
                        sCustomerPrompt = "提示：您可以输入客户编号、客户名称中的部分文字或客户名称拼音码来确定客户。"
                        frmMain.statusText.Text = sCustomerPrompt
                    Case Else
                        Call LockWindowUpdate(Me.Handle)
                        If Me.txbCustomerName.Visible Then Me.cbbCustomerName.Visible = True : Me.txbCustomerName.Visible = False
                        With Me.cbbCustomerName
                            .DataSource = dtDropdownCustomer
                            .ValueMember = "CustomerID"
                            .DisplayMember = "CustomerName"
                            .Text = sNewCustomerName
                        End With
                        sNewCustomerID = ""
                        sCustomerPrompt = "存在多个相似客户。请选择其中一个。"
                        frmMain.statusText.Text = sCustomerPrompt
                        Me.cbbCustomerName.Cursor = Cursors.Arrow
                        Me.cbbCustomerName.Focus()
                        Me.cbbCustomerName.Select()
                        Me.cbbCustomerName.DroppedDown = True
                        Me.cbbCustomerName.Text = sNewCustomerName
                        Me.cbbCustomerName.SelectAll()
                        Me.btnOK.Enabled = False
                        Call LockWindowUpdate(0)
                End Select
            End If

            blSkipDeal = False
            If sNewCustomerID = "" OrElse sNewCustomerID = sCustomerID Then
                If sNewCustomerID = "" Then
                    sCustomerID = "" : sCustomerName = "" : sSalesBillCode = "" : sCardNo = ""
                    Me.lblSearchResult.Text = "查找结果："
                    dtList.Rows.Clear()
                Else
                    If Me.cbbCustomerName.Visible Then Me.cbbCustomerName.Select()
                    Me.btnOK.Enabled = False : Me.dgvList.Select()
                End If
                DB.Close() : Me.Cursor = Cursors.Default : Return
            Else
                Me.lblSearchResult.Text = "正在查找销售单……" : Me.Refresh()
            End If
        End If

        dtList.Rows.Clear()
        Me.btnOpen.Enabled = False
        sCustomerID = "" : sCustomerName = "" : sSalesBillCode = "" : sCardNo = ""

        Dim sSQL As String = "Exec SearchSalesBill ", dtResult As DataTable = Nothing
        If Me.rdbByCustomerName.Checked Then
            sSQL = sSQL & "@SearchType=2,@CustomerID=" & sNewCustomerID
        ElseIf Me.rdbBySalesBillCode.Checked Then
            sSQL = sSQL & "@SearchText='" & Me.txbSalesBillCode.Text.Trim & "'"
        ElseIf Me.rdbByCardNo.Checked Then
            sSQL = sSQL & "@LoginUserID=" & frmMain.sLoginUserID & ",@SearchType=0,@SearchText='" & Me.txbCardNo.Text.Trim & Space(19 - Me.txbCardNo.Text.Trim.Length) & "'"
        Else
            sSQL = sSQL & "@LoginUserID=" & frmMain.sLoginUserID & ",@SearchType=3,@SearchText='" & Me.txbEmployeeNo.Text.Trim & "'"
        End If
        If Me.btnOK.Text.IndexOf("已取消") > -1 Then sSQL = sSQL & ",@SearchInCancelled=1"
        dtResult = DB.GetDataTable(sSQL)
        DB.Close()
        If dtResult Is Nothing Then
            frmMain.statusText.Text = "系统因在检索数据时出错而无法查找销售单。请联系软件开发人员。"
            Me.lblSearchResult.ForeColor = Color.Red
            Me.lblSearchResult.Text = "查找销售单失败！"
            Me.Cursor = Cursors.Default : Return
        End If

        dtList.Rows.Clear()
        If dtResult.Rows.Count = 0 Then
            Me.lblSearchResult.Text = "找不到销售单！"
            If Me.btnOK.Text.IndexOf("已取消") = -1 Then
                Me.btnOK.Text = "尝试在已取消的销售单中查找 &Search In Cancellations"
            Else
                Me.btnOK.Enabled = False
            End If
        Else
            Me.lblSearchResult.Text = "共找到 " & Format(dtResult.Rows.Count, "#,0") & " 张销售单："
            dtList.Merge(dtResult.Copy)
            dtList.DefaultView.Sort = "SalesBillCode DESC"
            For Each column As DataGridViewColumn In Me.dgvList.Columns
                If column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells Then
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End If
            Next

            Call LockWindowUpdate(Me.Handle)
            Dim iGridWidth As Integer = 0, iGridHeight As Integer = 0
            For Each column As DataGridViewColumn In Me.dgvList.Columns
                If column.Visible Then
                    If column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill OrElse column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells Then
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    End If
                    iGridWidth += column.Width
                End If
            Next
            If Not ToolStripManager.VisualStylesEnabled Then
                iGridWidth += 4
            Else
                iGridWidth += 2
            End If
            If iGridWidth < 565 Then
                iGridWidth = 565
                Me.dgvList.Columns("CustomerName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If
            If iGridWidth > My.Computer.Screen.WorkingArea.Width - 35 Then
                iGridWidth = My.Computer.Screen.WorkingArea.Width - 35
                iGridHeight = 17
            End If
            Dim iMaxDisplayRows As Integer = Int((My.Computer.Screen.WorkingArea.Height - 246 - iGridHeight - IIf(Not ToolStripManager.VisualStylesEnabled, 2, 0)) / 24) - 1, iDistance As Integer = 0
            If iMaxDisplayRows < Me.dgvList.RowCount Then
                If iGridHeight = 0 Then iGridWidth += 18
                iGridHeight += (iMaxDisplayRows + 1) * 24
                iDistance = 25
            Else
                iGridHeight += (IIf(Me.dgvList.RowCount < 5, 5, Me.dgvList.RowCount) + 1) * 24
            End If
            If Not ToolStripManager.VisualStylesEnabled Then iGridHeight += 2
            Me.Size = New Size(iGridWidth + 35, iGridHeight + 268)
            Me.Location = New Point((My.Computer.Screen.WorkingArea.Width - Me.Width) / 2, (My.Computer.Screen.WorkingArea.Height - Me.Height - iDistance) / 2)
            Call LockWindowUpdate(0)
            Me.btnOK.Enabled = False
        End If

        dtResult.Dispose() : dtResult = Nothing
        sCustomerID = "" : sCustomerName = "" : sSalesBillCode = "" : sCardNo = "" : sEmployeeNo = ""
        Me.cbbCustomerName.SelectionLength = 0
        If Me.rdbByCustomerName.Checked Then
            sCustomerID = sNewCustomerID : sCustomerName = sNewCustomerName
            If Me.cbbCustomerName.Visible Then Me.cbbCustomerName.Select()
        ElseIf Me.rdbBySalesBillCode.Checked Then
            sSalesBillCode = Me.txbSalesBillCode.Text.Trim
        ElseIf Me.rdbByCardNo.Checked Then
            sCardNo = Me.txbCardNo.Text.Trim
        Else
            sEmployeeNo = Me.txbEmployeeNo.Text.Trim
        End If
        Me.dgvList.Select()
        frmMain.statusText.Text = "就绪。"
        Me.Cursor = Cursors.Default
    End Sub
End Class