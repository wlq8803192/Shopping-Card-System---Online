Public Class frmReplaceCardRequirement

    'modify code 020:
    'date;2014/5/9
    'auther:Hyron bjy 
    'remark:商银通卡号位数增加到20位

    'modify code 021:
    'date;2014/5/15
    'auther:Hyron bjy 
    'remark:培训模式下，换卡时，不检查卡Bin，使用固定的测试MerchantNo和UserID

    'modify code 036:
    'date;2014/8/26
    'auther:Hyron bjy 
    'remark:增加三种换卡功能

    'modify code 045:
    'date;2015/3/17
    'auther:Hyron zyx 
    'remark:86条码卡换84磁条卡，86条码卡换60磁条卡

    'modify code 047:
    'date;2014/5/11
    'auther:Hyron qm 
    'remark:实名制卡特殊操作

    'modify code 050:
    'date;2015/11/1
    'auther:Hyron wzh 
    'remark:增加旧实名制卡和新实名制卡操作

    'modify code 051:
    'date;2016/01/08
    'auther:BJY 
    'remark:增加通卖卡65888

    'modify code 075:
    'date;2017/07/17
    'auther:Qipeng
    'remark:礼品卡特殊操作（换卡，激活撤销，离线激活，查询）

    'modify code 076:
    'date;2017/08/23
    'auther:Qipeng
    'remark:商银通卡打印小票

    'modify code 077:
    'date;2017/09/22
    'auther:Qipeng
    'remark:65换卡添加65999卡Bin换65888

    Private blSkipDeal As Boolean = True, editingCardNo As TextBox
    Private dvCULParameter As DataView, drOldCard As DataRow, drNewCard As DataRow, dtMulti As DataTable
    Private sOldCardType As String = "CRF", sBeforeCardNo As String, sExistingOldCardNo As String = "", sOldError As String = "", sExistingNewCardNo As String = "", sNewError As String = ""
    Private bStep As Byte = 0, blStep1OK As Boolean = False, blStep2OK As Boolean = False, blStep3OK As Boolean = False, iNewCards As Int16 = 0
    Private sOldCardNo As String = "", dmOldBalance As Decimal = 0, sOldActivatedDate As String, sOldEffectiveDate As String, sOldCULStoreCode As String, sNewCardNo As String = "", sMerchantNo As String = "", dmNewBalance As Decimal = 0

    'modify code 021:start-------------------------------------------------------------------------
    Private clsForCulTest As New ForCulTest
    'modify code 021:end-------------------------------------------------------------------------

    'modify code 047:start-------------------------------------------------------------------------
    Public isSignCard As Boolean = False
    Public signCardResult As Boolean = False
    Public signCardNo As String
    'modify code 047:end-------------------------------------------------------------------------

    'modify code 050:start-------------------------------------------------------------------------
    ' 卡类型标志; 0为非实名制卡，1为旧实名制卡，2为新实名制卡
    Public isNewSignCard As Integer = 0
    'modify code 050:end-------------------------------------------------------------------------

    'modify code 076:start-------------------------------------------------------------------------
    Private iAdjust As Integer = -10
    Private iPrintRows As Integer = 45
    Private blCheckTicketPrinter As Boolean = False, iTicketPageNum As Int16 = 1, iTicketPageCount As Int16 = 1, dtCardListInTicket As DataTable '用于打印小票
    'modify code 076:end-------------------------------------------------------------------------

    'modify code 077:start-------------------------------------------------------------------------
    Private sCardBin65 As String = "65999"
    Private sCardBinEx65 As String = "6599900"
    'modify code 077:end-------------------------------------------------------------------------

    Private Sub frmReplaceCardRequirement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "92" & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "94" & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
            'modify code 045:start-------------------------------------------------------------------------
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "86" & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
            'modify code 045:end-------------------------------------------------------------------------

            'modify code 050:start-------------------------------------------------------------------------
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), frmMain.signCardBin & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
            'modify code 050:end-------------------------------------------------------------------------
        Next

        'modify code 077:start-------------------------------------------------------------------------
        Dim DB As New DataBase(), dtResult As DataTable = Nothing
        DB.Open()
        If DB.IsConnected Then
            dtResult = DB.GetDataTable("select t1.ExtraCardBin,t2.AreaID,isnull(t2.CULStoreCode,0) CULStoreCode from CityExtraCardBin_ELC T1 left join (SELECT S.AreaID,  A.ParentAreaID, A.CULStoreCode FROM AreaScope(" & frmMain.sLoginUserID & ") AS S INNER JOIN AreaList AS A ON S.AreaID = A.AreaID) T2 on t1.CityID = t2.ParentAreaID where T2.AreaID is not null")
            If dtResult Is Nothing Then
            ElseIf dtResult.Rows.Count > 0 Then
                For Each drCUL As DataRow In dtResult.Rows
                    If drCUL("ExtraCardBin") = sCardBin65 Then
                        dvCULParameter.Table.Rows.Add(drCUL("AreaID"), drCUL("ExtraCardBin"), drCUL("CULStoreCode")).EndEdit()
                    End If
                Next
            End If
        End If
        DB.Close()
        'modify code 077:end-------------------------------------------------------------------------

        dvCULParameter.RowFilter = ""
        dvCULParameter.Table.AcceptChanges()

        dtMulti = New DataTable
        dtMulti.Columns.Add("RowID", System.Type.GetType("System.Int16"))
        dtMulti.Columns.Add("CardNo", System.Type.GetType("System.String"))
        dtMulti.Columns.Add("CardState", System.Type.GetType("System.String"))
        dtMulti.Columns.Add("Balance", System.Type.GetType("System.Decimal"))
        dtMulti.Columns.Add("NewBalance", System.Type.GetType("System.Decimal"))
        dtMulti.Columns.Add("OperationResult", System.Type.GetType("System.String"))
        dtMulti.Columns.Add("IsError", System.Type.GetType("System.Boolean"))
        dtMulti.Columns.Add("QueryState", System.Type.GetType("System.Byte")) '0 - 等待查询；1 - 查询失败；2 - 查询成功
        dtMulti.PrimaryKey = New DataColumn() {dtMulti.Columns("RowID")}
        dtMulti.Rows.Add(1, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, 0, 0)
        dtMulti.AcceptChanges()

        With Me.dgvMulti
            .DataSource = dtMulti
            With .Columns(0)
                .HeaderText = "No."
                .Width = 36
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
                .HeaderText = "卡号"
                .Width = 125
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(2)
                .HeaderText = "卡状态"
                .Width = 70
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
            End With
            With .Columns(3)
                .HeaderText = "余额"
                .Width = 70
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,0.00"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
            End With
            With .Columns(4)
                .HeaderText = "未来面值"
                .Width = 75
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,0.00"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
                .Visible = False
            End With
            With .Columns(5)
                .HeaderText = "检查结果"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
            End With
            .Columns(6).Visible = False
            .Columns(7).Visible = False
        End With

        For Each column As DataGridViewColumn In Me.dgvMulti.Columns
            column.Name = dtMulti.Columns(column.Index).ColumnName
        Next

        blSkipDeal = False

        'modify code 047:start-------------------------------------------------------------------------
        If isSignCard Then
            If isNewSignCard = 2 Then
                rdbNSC.Select()
                btnNSC_Click(Nothing, Nothing)
            ElseIf isNewSignCard = 1 Then
                rdbOSC.Select()
                btnOSC_Click(Nothing, Nothing)
            End If
            txbOldCardNo.Text = signCardNo
            txbOldCardNo.Enabled = False
            txbOldCardNo_Leave(Nothing, Nothing)
            btnStart.Enabled = False
            btnPrevious.Enabled = False
        End If
        'modify code 047:end-------------------------------------------------------------------------
    End Sub

    Private Sub rdbCRF_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbCRF.CheckedChanged
        sOldCardType = "CRF"
        'modify code 050:start-------------------------------------------------------------------------
        isSignCard = False
        isNewSignCard = 0
        'modify code 050:end-------------------------------------------------------------------------
        Me.txbOldCardNo.Text = ""
        Me.txbOldCardNo.MaxLength = 19
        Me.txbNewCardNo.Text = ""
        Me.grbOldCard.Text = "第一步：输入原卡（家乐福卡）卡号并查询该卡的状态"
    End Sub

    Private Sub btnCRF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCRF.Click
        Me.rdbCRF.Checked = True
        Me.btnNext.PerformClick()
    End Sub

    'modify code 050:start-------------------------------------------------------------------------
    Private Sub rdbOSC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbOSC.CheckedChanged
        sOldCardType = "CRF"
        isSignCard = True
        isNewSignCard = 1
        Me.txbOldCardNo.Text = ""
        Me.txbOldCardNo.MaxLength = 19
        Me.txbNewCardNo.Text = ""
        Me.grbOldCard.Text = "第一步：输入原卡（旧实名制）卡号并查询该卡的状态"
    End Sub

    Private Sub btnOSC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOSC.Click
        Me.rdbOSC.Checked = True
        Me.btnNext.PerformClick()
    End Sub

    Private Sub rdbNSC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbNSC.CheckedChanged
        sOldCardType = "CRF"
        isSignCard = True
        isNewSignCard = 2
        Me.txbOldCardNo.Text = ""
        Me.txbOldCardNo.MaxLength = 19
        Me.txbNewCardNo.Text = ""
        Me.grbOldCard.Text = "第一步：输入原卡（新实名制）卡号并查询该卡的状态"
    End Sub

    Private Sub btnNSC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNSC.Click
        Me.rdbNSC.Checked = True
        Me.btnNext.PerformClick()
    End Sub

    'modify code 050:end-------------------------------------------------------------------------

    Private Sub rdbSYT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbSYT.CheckedChanged
        sOldCardType = "SYT"
        Me.txbOldCardNo.Text = ""
        'modify code 020:start-------------------------------------------------------------------------
        'Me.txbOldCardNo.MaxLength = 16
        Me.txbOldCardNo.MaxLength = 20
        'modify code 020:end-------------------------------------------------------------------------
        Me.txbNewCardNo.Text = ""
        Me.grbOldCard.Text = "第一步：输入原卡（商银通卡）卡号并查询该卡的状态"
    End Sub

    Private Sub btnSYT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSYT.Click
        Me.rdbSYT.Checked = True
        Me.btnNext.PerformClick()
    End Sub

    Private Sub rdbSMT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbSMT.CheckedChanged
        sOldCardType = "SMT"
        Me.txbOldCardNo.Text = ""
        Me.txbOldCardNo.MaxLength = 16
        Me.txbNewCardNo.Text = ""
        Me.grbOldCard.Text = "第一步：输入原卡（斯玛特卡）卡号并查询该卡的状态"
    End Sub

    Private Sub btnSMT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSMT.Click
        Me.rdbSMT.Checked = True
        Me.btnNext.PerformClick()
    End Sub

    'modify code 045:start-------------------------------------------------------------------------
    Private Sub rdbC86_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbC86.CheckedChanged
        sOldCardType = "C86"
        Me.txbOldCardNo.Text = ""
        Me.txbOldCardNo.MaxLength = 17
        Me.txbNewCardNo.Text = ""
        Me.grbOldCard.Text = "第一步：输入原卡（86卡）卡号并查询该卡的状态"
    End Sub

    Private Sub btnC86_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC86.Click
        Me.rdbC86.Checked = True
        Me.btnNext.PerformClick()
    End Sub
    'modify code 045:end-------------------------------------------------------------------------

    Private Sub txbOldCardNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbOldCardNo.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter AndAlso Me.btnQueryOldCardState.Enabled Then Me.btnQueryOldCardState.Select() : Me.btnQueryOldCardState.PerformClick() : e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If Me.txbOldCardNo.SelectedText = Me.txbOldCardNo.Text Then Me.txbOldCardNo.Text = ""
            Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbOldCardNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbOldCardNo.Leave
        If Me.txbOldCardNo.Text <> Me.txbOldCardNo.Text.Trim Then Me.txbOldCardNo.Text = Me.txbOldCardNo.Text.Trim
        Dim sValue As String = Me.txbOldCardNo.Text
        If sValue = sOldCardNo Then Return

        'modify code 021:start-------------------------------------------------------------------------
        'If My.Settings.IsInTraining Then
        '    sOldCardNo = sValue
        '    sMerchantNo = clsForCulTest.sTestMerchantNo
        'Else
        If Not IsNumeric(sValue) Then
            Me.lblOldCardError.Text = "（卡号只能由数字组成！）"
            Me.btnQueryOldCardState.Enabled = False
            'modify code 050:start-------------------------------------------------------------------------
        ElseIf sOldCardType = "CRF" AndAlso sValue.Length > 5 AndAlso sValue.Substring(0, 4) <> "2336" Then
            'modify code 050:end-------------------------------------------------------------------------
            Me.lblOldCardError.Text = "（非家乐福卡！）"
            Me.btnQueryOldCardState.Enabled = False
        ElseIf sOldCardType = "CRF" AndAlso sValue.Length < 19 Then
            Me.lblOldCardError.Text = "（卡号位数不足 19 位！）"
            Me.btnQueryOldCardState.Enabled = False
            'modify code 050:start-------------------------------------------------------------------------
        ElseIf sOldCardType = "CRF" AndAlso isNewSignCard = 0 AndAlso sValue.Substring(4, 2) = frmMain.signCardBin Then
            Me.lblOldCardError.Text = "（实名制卡不可换卡！）"
            Me.btnQueryOldCardState.Enabled = False
        ElseIf sOldCardType = "CRF" AndAlso isNewSignCard = 2 AndAlso sValue.Substring(4, 2) <> frmMain.signCardBin Then
            Me.lblOldCardError.Text = "（非实名制卡！）"
            Me.btnQueryOldCardState.Enabled = False
        ElseIf sOldCardType = "CRF" AndAlso isNewSignCard = 1 AndAlso sValue.Substring(4, 2) = frmMain.signCardBin Then
            Me.lblOldCardError.Text = "（非旧实名制卡！）"
            Me.btnQueryOldCardState.Enabled = False
            'modify code 050:end-------------------------------------------------------------------------
            'modify code 051:start-------------------------------------------------------------------------
        ElseIf sOldCardType = "CRF" AndAlso sValue.Substring(4, 2) = "65" Then
            Me.lblOldCardError.Text = "（65卡不可换家乐福卡！请到65卡换65卡处操作。）"
            Me.btnQueryOldCardState.Enabled = False
            'modify code 051:end-------------------------------------------------------------------------
            'modify code 036:start-------------------------------------------------------------------------
        ElseIf sOldCardType = "SYT" AndAlso sValue.Length <> 20 Then
            Me.lblOldCardError.Text = "（卡号位数不足 20 位！）"
            Me.btnQueryOldCardState.Enabled = False
        ElseIf sOldCardType = "SMT" AndAlso sValue.Length <> 16 Then
            Me.lblOldCardError.Text = "（卡号位数不足 16 位！）"
            Me.btnQueryOldCardState.Enabled = False
        ElseIf sOldCardType = "ZH" AndAlso sValue.Length <> 19 Then
            Me.lblOldCardError.Text = "（卡号位数不足 19 位！）"
            Me.btnQueryOldCardState.Enabled = False
        ElseIf sOldCardType = "BLC" AndAlso sValue.Length <> 7 Then
            Me.lblOldCardError.Text = "（卡号位数不足 7 位！）"
            Me.btnQueryOldCardState.Enabled = False
            'ElseIf sOldCardType <> "CRF" AndAlso sValue.Length < 16 Then
            '    Me.lblOldCardError.Text = "（卡号位数不足 16 位！）"
            '    Me.btnQueryOldCardState.Enabled = False
            'modify code 036:end-------------------------------------------------------------------------
        ElseIf sOldCardType = "CRF" AndAlso sValue <> ShoppingCardNo.GetFullCardNo(sValue.Substring(0, 18)) Then
            Me.lblOldCardError.Text = "（卡号校验码错误！）"
            Me.btnQueryOldCardState.Enabled = False
        ElseIf sOldCardType = "CRF" AndAlso dvCULParameter.Table.Select("CULCardBin='" & sValue.Substring(4, 5) & "'").Length = 0 Then
            Me.lblOldCardError.Text = "（无权操作该卡段！）"
            Me.btnQueryOldCardState.Enabled = False
            'modify code 045:start-------------------------------------------------------------------------
        ElseIf sOldCardType = "C86" AndAlso sValue.Length > 2 AndAlso sValue.Substring(0, 2) <> "86" Then
            Me.lblOldCardError.Text = "（非86卡！）"
            Me.btnQueryOldCardState.Enabled = False
        ElseIf sOldCardType = "C86" AndAlso sValue.Length < 17 Then
            Me.lblOldCardError.Text = "（卡号位数不足 17 位！）"
            Me.btnQueryOldCardState.Enabled = False
        ElseIf sOldCardType = "C86" AndAlso dvCULParameter.Table.Select("CULCardBin='" & sValue.Substring(0, 5) & "'").Length = 0 Then
            Me.lblOldCardError.Text = "（无权操作该卡段！）"
            Me.btnQueryOldCardState.Enabled = False
            'modify code 045:end-------------------------------------------------------------------------
            'modify code 051:start-------------------------------------------------------------------------
        ElseIf sOldCardType = "C65" AndAlso sValue.Substring(4, 2) <> "65" Then
            Me.lblOldCardError.Text = "（非65卡！）"
            Me.btnQueryOldCardState.Enabled = False
        ElseIf sOldCardType = "C65" AndAlso sValue.Length < 19 Then
            Me.lblOldCardError.Text = "（卡号位数不足 19 位！）"
            Me.btnQueryOldCardState.Enabled = False
            'modify code 077:start-------------------------------------------------------------------------
        ElseIf sOldCardType = "C65" AndAlso sValue.Substring(4, 5) = sCardBin65 AndAlso sValue.Substring(4, 7) <> sCardBinEx65 Then
            Me.lblOldCardError.Text = "（非线下售卖65卡！）"
            Me.btnQueryOldCardState.Enabled = False
            'modify code 077:end-------------------------------------------------------------------------
        ElseIf sOldCardType = "C65" AndAlso sValue <> ShoppingCardNo.GetFullCardNo(sValue.Substring(0, 18)) Then
            Me.lblOldCardError.Text = "（卡号校验码错误！）"
            Me.btnQueryOldCardState.Enabled = False
        ElseIf sOldCardType = "C65" AndAlso dvCULParameter.Table.Select("CULCardBin='" & sValue.Substring(4, 5) & "'").Length = 0 Then
            Me.lblOldCardError.Text = "（无权操作该卡段！）"
            Me.btnQueryOldCardState.Enabled = False
            'modify code 051:end-------------------------------------------------------------------------
        ElseIf sValue = sNewCardNo Then
            Me.lblOldCardError.Text = "（不能和新卡号相同！）"
            Me.btnQueryOldCardState.Enabled = False
        ElseIf sValue = sExistingOldCardNo Then
            Me.lblOldCardError.Text = "（" & sOldError & "）"
            Me.btnQueryOldCardState.Enabled = False
        Else
            sOldCardNo = sValue
            If sOldCardType = "CRF" Then
                sMerchantNo = dvCULParameter.Table.Select("CULCardBin='" & sOldCardNo.Substring(4, 5) & "'")(0)("CULStoreCode").ToString
                'modify code 045:start-------------------------------------------------------------------------
            ElseIf sOldCardType = "C86" Then
                sMerchantNo = dvCULParameter.Table.Select("CULCardBin='" & sOldCardNo.Substring(0, 5) & "'")(0)("CULStoreCode").ToString
                'modify code 045:end-------------------------------------------------------------------------
            Else
                sMerchantNo = dvCULParameter(0)("CULStoreCode").ToString
            End If
        End If
        'End If
        'modify code 021:end-------------------------------------------------------------------------

        If Not Me.btnQueryOldCardState.Enabled Then
            Me.txbOldCardNo.Select()
            Me.txbOldCardNo.SelectAll()
        End If
    End Sub

    Private Sub txbOldCardNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbOldCardNo.TextChanged
        Me.lblOldCardError.Text = ""
        Me.lblInfo1.Text = ""
        blStep1OK = False
        If drOldCard IsNot Nothing AndAlso drOldCard("CardNo").ToString = Me.txbOldCardNo.Text.Trim Then
            Me.btnQueryOldCardState.Enabled = True
            Me.btnQueryOldCardState.PerformClick()
        Else
            Me.btnQueryOldCardState.Enabled = (Me.txbOldCardNo.Text.Trim <> "")
            Me.grbOldCardState.Visible = False

            If blStep2OK Then
                If sNewCardNo <> "" Then
                    sNewCardNo = ""
                    Me.txbNewCardNo.Text = ""
                End If

                If dtMulti.Rows.Count > 1 Then
                    dtMulti.Rows.Clear()
                    dtMulti.Rows.Add(1, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, 0, 0)
                    Me.lblMulti.Text = ""
                    Me.btnDelete.Enabled = False
                    Me.btnClear.Enabled = False
                    Me.btnMulti.Enabled = False
                End If
                blStep2OK = False
            End If

            Me.btnNext.Enabled = False
            Me.btnFinish.Enabled = False
        End If
    End Sub

    Private Sub btnQueryOldCardState_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQueryOldCardState.Click
        If drOldCard Is Nothing OrElse drOldCard("CardNo").ToString <> sOldCardNo Then
            Me.Cursor = Cursors.Default
            Me.lblInfo1.ForeColor = SystemColors.ControlText
            Me.lblInfo1.Text = "正在到CUL查询该张购物卡的状态，请稍候……"
            Me.Refresh()
            'modify code 036:start-------------------------------------------------------------------------
            'modify code 051:start-------------------------------------------------------------------------
            'If sOldCardType = "CRF" Then
            If sOldCardType = "CRF" OrElse sOldCardType = "C65" OrElse sOldCardType = "80888" Then

                'modify code 077:start-------------------------------------------------------------------------
                'If sOldCardType = "C65" AndAlso drOldCard("CardNo").ToString.Substring(4, 5) = sCardBin65 AndAlso drOldCard("CardNo").ToString.Substring(4, 7) <> sCardBinEx65 Then
                '    drOldCard = ShoppingCardOperation.GetCRFCardState(sMerchantNo, sOldCardNo, sOldCardNo).Rows(0)
                'Else
                '    drOldCard = ShoppingCardOperation.GetCRFCardState(sMerchantNo, sOldCardNo, sOldCardNo).Rows(0)
                'End If
                'modify code 077:end-------------------------------------------------------------------------
                drOldCard = ShoppingCardOperation.GetCRFCardState(sMerchantNo, sOldCardNo, sOldCardNo).Rows(0)

                'modify code 051:end-------------------------------------------------------------------------
            ElseIf sOldCardType = "ZH" Or sOldCardType = "BLC" Then
                drOldCard = ShoppingCardOperation.GetBLCCardState(sMerchantNo, sOldCardNo).Rows(0)
                'modify code 045:start-------------------------------------------------------------------------
            ElseIf sOldCardType = "C86" Then
                Dim dtTemp As DataTable
                dtTemp = ShoppingCardOperation.GetPaperCardState(sMerchantNo, sOldCardNo, sOldCardNo)
                If dtTemp.Rows.Count > 0 Then
                    drOldCard = dtTemp.Rows(0)
                End If
                'modify code 045:end-------------------------------------------------------------------------
            Else
                drOldCard = ShoppingCardOperation.GetICCardState(sMerchantNo, sOldCardType, sOldCardNo, sOldCardNo).Rows(0)
            End If
            'modify code 036:end-------------------------------------------------------------------------
        End If

        If drOldCard("CardNo").ToString = "Error" Then
            Me.lblInfo1.ForeColor = Color.Red
            Me.lblInfo1.Text = "查询原卡状态时发生错误！错误提示：" & drOldCard("StoreName").ToString
        Else
            Me.btnQueryOldCardState.Enabled = False
            Me.grbOldCardState.Visible = True
            iNewCards = 0
            If drOldCard("CardState") = "已激活" Then
                If drOldCard("Balance").ToString = "" OrElse Not IsNumeric(drOldCard("Balance").ToString) OrElse drOldCard("Balance") <= 0 Then
                    dmOldBalance = 0
                Else
                    'modify code 047:start-------------------------------------------------------------------------
                    Dim dtResult As DataTable
                    Dim DB As New DataBase

                    DB.Open()
                    If Not DB.IsConnected Then
                        frmMain.statusText.Text = "系统因连接不到数据库而无法进行查询。请检查数据库连接。"
                        Return
                    End If
                    dtResult = DB.GetDataTable("select * from SignCardListNew where CardType='实名制卡' and CardNo='" & sOldCardNo & "'")
                    'modify code 047:end-------------------------------------------------------------------------
                    dmOldBalance = drOldCard("Balance")
                    If dmOldBalance <= 1000 OrElse dtResult.Rows.Count > 0 Then
                        iNewCards = 1
                    Else
                        iNewCards = CInt(Int(dmOldBalance / 1000))
                        If CDec(iNewCards * 1000) < dmOldBalance Then iNewCards += 1
                    End If
                End If
                sOldActivatedDate = Format(drOldCard("ActivatedDate"), "yyyy\/MM\/dd")
                sOldEffectiveDate = Format(drOldCard("EffectiveDate"), "yyyy\/MM\/dd")
                Try
                    sOldCULStoreCode = drOldCard("StoreName").ToString.Substring(0, 15)
                Catch
                    sOldCULStoreCode = sMerchantNo
                End Try

                Me.lblOldCardState.Text = "发卡门店：" & drOldCard("StoreName").ToString.Substring(drOldCard("StoreName").ToString.IndexOf("-") + 1) & Chr(13) & Chr(13) & "原卡状态：已激活" & Chr(13) & Chr(13) & "原卡余额：" & Format(dmOldBalance, "#,0.00") & " 元" & IIf(iNewCards > 1, " （需要换成 " & Format(iNewCards, "#,0") & " 张新卡）", "") & Chr(13) & Chr(13) & "激活日期：" & sOldActivatedDate & "    有效期至：" & sOldEffectiveDate + IIf(CDate(sOldEffectiveDate) < Today(), " （已过期）", "")
                If dmOldBalance = 0 Then
                    Me.lblInfo1.ForeColor = Color.Red
                    Me.lblInfo1.Text = "查询完成。因为该卡没有余额，所以不可以换卡！"
                Else
                    If CDate(sOldEffectiveDate) < Today() Then
                        Me.lblInfo1.Text = "查询完成。原卡过期，换卡后新卡自动延期两个月。请按""下一步""输入新卡号并查询其状态……"
                    Else
                        Me.lblInfo1.Text = "查询完成。原卡状态正确，可以换卡。请按""下一步""输入新卡号并查询其状态……"
                    End If
                    If iNewCards = 1 Then
                        Me.pnlSingle.Visible = True
                        Me.pnlMulti.Visible = False
                        Me.lblInfo2.Text = ""
                    Else
                        Me.lblMulti.Text = "请在下面列表输入 " & Format(iNewCards, "#,0") & " 张新卡，然后查询它们的状态："
                        Me.pnlSingle.Visible = False
                        Me.pnlMulti.Visible = True
                        Me.lblInfo2.Text = "原卡余额是 " & Format(dmOldBalance, "#,0.00").Replace(".00", "") & " 元，已超过单卡 1,000 元面值的限制，需换成 " & Format(iNewCards, "#,0") & " 张新卡，请输入新卡。"
                    End If
                    blStep1OK = True
                    Me.btnNext.Enabled = True
                    Me.btnFinish.Enabled = blStep2OK
                End If
            Else
                If drOldCard("CardState") = "未激活" Then
                    Me.lblOldCardState.Text = "未激活"
                Else
                    Me.lblOldCardState.Text = "发卡门店：" & drOldCard("StoreName").ToString.Substring(drOldCard("StoreName").ToString.IndexOf("-") + 1) & Chr(13) & Chr(13) & "原卡状态：" & drOldCard("CardState").ToString & Chr(13) & Chr(13) & "原卡余额："
                    If drOldCard("Balance").ToString = "" OrElse Not IsNumeric(drOldCard("Balance").ToString) OrElse drOldCard("Balance") <= 0 Then
                        Me.lblOldCardState.Text = Me.lblOldCardState.Text & "0.00 元"
                    Else
                        Me.lblOldCardState.Text = Me.lblOldCardState.Text & Format(drOldCard("Balance"), "#,0.00") & " 元"
                    End If
                    Me.lblOldCardState.Text = Me.lblOldCardState.Text & Chr(13) & Chr(13) & "激活日期：" & Format(drOldCard("ActivatedDate"), "yyyy\/MM\/dd") & "    有效期至：" & Format(drOldCard("EffectiveDate"), "yyyy\/MM\/dd")
                End If
                Me.lblInfo1.ForeColor = Color.Red
                Me.lblInfo1.Text = "查询完成。原卡状态不正确（原卡必须已激活且存有余额），不可以换卡！"
            End If
        End If

        If blStep1OK Then
            Me.btnNext.Select()
        Else
            Me.txbOldCardNo.Select() : Me.txbOldCardNo.SelectAll()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txbNewCardNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbNewCardNo.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter AndAlso Me.btnQueryNewCardState.Enabled Then Me.btnQueryNewCardState.Select() : Me.btnQueryNewCardState.PerformClick() : e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If Me.txbNewCardNo.SelectedText = Me.txbNewCardNo.Text Then Me.txbNewCardNo.Text = ""
            Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbNewCardNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbNewCardNo.Leave
        If Me.txbNewCardNo.Text <> Me.txbNewCardNo.Text.Trim Then Me.txbNewCardNo.Text = Me.txbNewCardNo.Text.Trim
        Dim sValue As String = Me.txbNewCardNo.Text
        If sValue = sNewCardNo Then Return

        'modify code 021:start-------------------------------------------------------------------------
        'If My.Settings.IsInTraining Then
        '    sNewCardNo = sValue
        '    sMerchantNo = clsForCulTest.sTestMerchantNo
        'Else
        If Not IsNumeric(sValue) Then
            Me.lblNewCardError.Text = "（卡号只能由数字组成！）"
            Me.btnQueryNewCardState.Enabled = False
        ElseIf sValue.Length < 19 Then
            Me.lblNewCardError.Text = "（卡号位数不足 19 位！）"
            Me.btnQueryNewCardState.Enabled = False
        ElseIf sValue <> ShoppingCardNo.GetFullCardNo(sValue.Substring(0, 18)) Then
            Me.lblNewCardError.Text = "（卡号校验码错误！）"
            Me.btnQueryNewCardState.Enabled = False
        ElseIf dvCULParameter.Table.Select("CULCardBin='" & sValue.Substring(4, 5) & "'").Length = 0 Then
            Me.lblNewCardError.Text = "（无权操作该卡段！）"
            Me.btnQueryNewCardState.Enabled = False
        ElseIf sValue = sOldCardNo Then
            Me.lblNewCardError.Text = "（不能和原卡号相同！）"
            Me.btnQueryNewCardState.Enabled = False
            'modify code 036:start-------------------------------------------------------------------------
            'modify code 050:start-------------------------------------------------------------------------
        ElseIf isNewSignCard = 0 AndAlso sValue.Substring(4, 2) = frmMain.signCardBin Then
            Me.lblNewCardError.Text = "（实名制卡不能当作目标卡，请前往实名制卡特殊操作界面！）"
            Me.btnQueryNewCardState.Enabled = False
            'modify code 050:end-------------------------------------------------------------------------
            'modify code 050,051:start-------------------------------------------------------------------------
            'ElseIf sValue.Substring(4, 2) <> "84" AndAlso sValue.Substring(4, 2) <> "92" AndAlso sValue.Substring(4, 2) <> "94" AndAlso sValue.Substring(4, 2) <> "60" Then
        ElseIf sOldCardType = "80888" Then
            If sValue.Substring(4, 5) <> "80888" AndAlso sValue.Substring(4, 5) <> "65888" Then
                Me.lblNewCardError.Text = "（新卡为卡BIN以""80888""""65888""开头的磁条卡！）"
                Me.btnQueryNewCardState.Enabled = False
            End If

            sNewCardNo = sValue
            sMerchantNo = dvCULParameter.Table.Select("CULCardBin='" & sNewCardNo.Substring(4, 5) & "'")(0)("CULStoreCode").ToString
        ElseIf sValue.Substring(4, 2) <> frmMain.signCardBin AndAlso sValue.Substring(4, 2) <> "84" AndAlso sValue.Substring(4, 2) <> "92" AndAlso sValue.Substring(4, 2) <> "94" AndAlso sValue.Substring(4, 2) <> "60" AndAlso sValue.Substring(4, 2) <> "65" Then
            'modify code 050,051:end-------------------------------------------------------------------------
            Me.lblNewCardError.Text = "（早期卡不能当作目标卡！）"
            Me.btnQueryNewCardState.Enabled = False
            'modify code 051:start-------------------------------------------------------------------------
        ElseIf sOldCardType = "C65" AndAlso sValue.Substring(4, 2) <> "65" Then
            Me.lblOldCardError.Text = "（非65卡！）"
            Me.btnQueryOldCardState.Enabled = False
            'ElseIf sOldCardType <> "CRF" AndAlso sValue.Substring(4, 2) <> "84" AndAlso sValue.Substring(4, 2) <> "60" Then
        ElseIf sOldCardType <> "CRF" AndAlso sOldCardType <> "C65" AndAlso sValue.Substring(4, 2) <> "84" AndAlso sValue.Substring(4, 2) <> "60" Then
            'modify code 051:end-------------------------------------------------------------------------
            'Me.lblNewCardError.Text = "（新卡必须和旧卡同为卡BIN以""84""开头的磁条卡！）"
            Me.lblNewCardError.Text = "（新卡为卡BIN以""84""""60""开头的磁条卡！）"
            Me.btnQueryNewCardState.Enabled = False
            'ElseIf sOldCardType = "CRF" AndAlso sOldCardNo.Substring(4, 2) = "84" AndAlso sValue.Substring(4, 2) <> "84" Then
            '    Me.lblNewCardError.Text = "（新卡必须和旧卡同为卡BIN以""84""开头的磁条卡！）"
            '    Me.btnQueryNewCardState.Enabled = False
            'modify code 036:end-------------------------------------------------------------------------
        ElseIf sOldCardType = "CRF" AndAlso sOldCardNo.Substring(4, 2) = "92" AndAlso sValue.Substring(4, 2) <> "92" Then
            Me.lblNewCardError.Text = "（新卡必须和旧卡同为卡BIN以""92""开头的营销卡！）"
            Me.btnQueryNewCardState.Enabled = False
        ElseIf sOldCardType = "CRF" AndAlso sOldCardNo.Substring(4, 2) = "94" AndAlso sValue.Substring(4, 2) <> "94" Then
            Me.lblNewCardError.Text = "（新卡必须和旧卡同为卡BIN以""94""开头的活动卡！）"
            Me.btnQueryNewCardState.Enabled = False

            'modify code 050:start-------------------------------------------------------------------------
        ElseIf sOldCardType = "CRF" AndAlso isNewSignCard = 2 AndAlso sOldCardNo.Substring(4, 2) = frmMain.signCardBin AndAlso sValue.Substring(4, 2) <> frmMain.signCardBin Then
            Me.lblNewCardError.Text = "（新卡必须和旧卡同为卡BIN以""" & frmMain.signCardBin & """开头的实名制卡！）"
            Me.btnQueryNewCardState.Enabled = False
        ElseIf sOldCardType = "CRF" AndAlso isNewSignCard = 1 AndAlso sValue.Substring(4, 2) <> frmMain.signCardBin Then
            Me.lblNewCardError.Text = "（新卡为卡BIN以""" & frmMain.signCardBin & """开头的实名制卡！）"
            Me.btnQueryNewCardState.Enabled = False
            'modify code 050:end-------------------------------------------------------------------------
            'modify code 051:start-------------------------------------------------------------------------
        ElseIf sOldCardType = "CRF" AndAlso sValue.Substring(4, 2) = "65" Then
            Me.lblOldCardError.Text = "（家乐福卡不可换65卡！请到65卡换65卡处操作。）"
            Me.btnQueryOldCardState.Enabled = False
            'modify code 051:end-------------------------------------------------------------------------
            'modify code 045:start-------------------------------------------------------------------------
        ElseIf sOldCardType = "C86" AndAlso sValue.Substring(4, 2) <> "84" AndAlso sValue.Substring(4, 2) <> "60" Then
            Me.lblNewCardError.Text = "（新卡为卡BIN以""84""""60""开头的磁条卡！）"
            Me.btnQueryNewCardState.Enabled = False
            'modify code 045:end-------------------------------------------------------------------------
        ElseIf sValue = sExistingNewCardNo Then
            Me.lblNewCardError.Text = "（" & sNewError & "）"
            Me.btnQueryNewCardState.Enabled = False
        Else
            sNewCardNo = sValue
            sMerchantNo = dvCULParameter.Table.Select("CULCardBin='" & sNewCardNo.Substring(4, 5) & "'")(0)("CULStoreCode").ToString
        End If
        'End If
        'modify code 021:end-------------------------------------------------------------------------

        If Not Me.btnQueryNewCardState.Enabled Then
            Me.txbNewCardNo.Select()
            Me.txbNewCardNo.SelectAll()
        End If
    End Sub

    Private Sub txbNewCardNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbNewCardNo.TextChanged
        Me.lblNewCardError.Text = ""
        Me.lblInfo2.Text = ""
        blStep2OK = False
        If drNewCard IsNot Nothing AndAlso drNewCard("CardNo").ToString = Me.txbNewCardNo.Text.Trim Then
            Me.btnQueryNewCardState.Enabled = True
            Me.btnQueryNewCardState.PerformClick()
        Else
            Me.btnQueryNewCardState.Enabled = (Me.txbNewCardNo.Text.Trim <> "")
            Me.grbNewCardState.Visible = False

            Me.btnNext.Enabled = False
            Me.btnFinish.Enabled = False
        End If
    End Sub

    Private Sub btnQueryNewCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQueryNewCardState.Click
        If drNewCard Is Nothing OrElse drNewCard("CardNo").ToString <> sNewCardNo Then
            Me.Cursor = Cursors.Default
            Me.lblInfo2.Text = "正在到CUL查询该张购物卡的状态，请稍候……"
            Me.Refresh()

            'modify code 077:start-------------------------------------------------------------------------
            'If sOldCardType = "C65" AndAlso drNewCard("CardNo").ToString.Substring(4, 5) = sCardBin65 AndAlso drNewCard("CardNo").ToString.Substring(4, 7) <> sCardBinEx65 Then
            '    drNewCard = ShoppingCardOperation.GetCRFCardState(sMerchantNo, sNewCardNo, sNewCardNo).Rows(0)
            'Else
            '    drNewCard = ShoppingCardOperation.GetCRFCardState(sMerchantNo, sNewCardNo, sNewCardNo).Rows(0)
            'End If
            'modify code 077:end-------------------------------------------------------------------------
            drNewCard = ShoppingCardOperation.GetCRFCardState(sMerchantNo, sNewCardNo, sNewCardNo).Rows(0)
        End If

        Me.btnQueryNewCardState.Enabled = False
        If drNewCard("CardNo").ToString = "Error" Then
            Me.lblInfo2.ForeColor = Color.Red
            Me.lblInfo2.Text = "查询新卡状态时发生错误！错误提示：" & drNewCard("StoreName").ToString
        Else
            Me.grbNewCardState.Visible = True
            If drNewCard("Balance").ToString <> "" AndAlso IsNumeric(drNewCard("Balance").ToString) AndAlso drNewCard("Balance") = 0 Then
                Me.lblNewCardState.Text = "新卡状态：" & drNewCard("CardState").ToString & Chr(13) & Chr(13) & "目前余额：0.00 元"
                If drNewCard("CardState").ToString = "未激活" Then
                    Me.lblInfo2.Text = "查询完成。新卡状态正确，可作为目标卡。请按""下一步""输入换卡原因并申请换卡……"
                Else
                    'modify code 047:start-------------------------------------------------------------------------
                    Dim DB As New DataBase
                    Dim dtResult As DataTable

                    Me.Cursor = Cursors.WaitCursor
                    DB.Open()
                    If Not DB.IsConnected Then
                        frmMain.statusText.Text = "系统因连接不到数据库而无法进行查询。请检查数据库连接。"
                        Me.Cursor = Cursors.Default
                        Return
                    End If
                    dtResult = DB.GetDataTable("select * from SignCardListNew where CardType='实名制卡' and CardNo='" & sNewCardNo & "'")
                    If dtResult.Rows.Count > 0 Then
                        Me.lblInfo2.Text = "查询完成。实名制卡非""未激活""状态，不可作为目标卡！"
                        Me.Cursor = Cursors.Default
                        Return
                    End If
                    Me.Cursor = Cursors.Default
                    'modify code 047:end-------------------------------------------------------------------------
                    Me.lblInfo2.Text = "查询完成。该卡将被自动回收变成未激活卡，可作为目标卡。请按""下一步""输入换卡原因并申请换卡……"
                End If
                blStep2OK = True
                Me.btnNext.Enabled = True
                Me.btnFinish.Enabled = True
            Else
                'Dim dmNewBalance As Decimal = 0
                Try
                    If drNewCard("StoreName").ToString.Substring(drNewCard("StoreName").ToString.IndexOf("-") + 1) <> "" Then
                        Me.lblNewCardState.Text = "发卡门店：" & drNewCard("StoreName").ToString.Substring(drNewCard("StoreName").ToString.IndexOf("-") + 1) & Chr(13) & Chr(13)
                    End If
                Catch
                End Try
                Me.lblNewCardState.Text = Me.lblNewCardState.Text & "新卡状态：" & drNewCard("CardState").ToString & Chr(13) & Chr(13) & "目前余额："
                If drNewCard("Balance").ToString = "" OrElse Not IsNumeric(drNewCard("Balance").ToString) OrElse drNewCard("Balance") <= 0 Then
                    Me.lblNewCardState.Text = Me.lblNewCardState.Text & "（不明确）"
                Else
                    dmNewBalance = drNewCard("Balance")
                    Me.lblNewCardState.Text = Me.lblNewCardState.Text & Format(dmNewBalance, "#,0.00") & " 元"
                End If
                Me.lblNewCardState.Text = Me.lblNewCardState.Text & Chr(13) & Chr(13) & "激活日期：" & Format(drNewCard("ActivatedDate"), "yyyy\/MM\/dd") & "    有效期至：" & Format(drNewCard("EffectiveDate"), "yyyy\/MM\/dd")
                Me.lblInfo2.ForeColor = Color.Red
                If dmNewBalance = 0 Then
                    Me.lblInfo2.Text = "查询完成。新卡余额不明确，需要通过回收操作才可用，不可作为目标卡！"
                Else
                    Me.lblInfo2.Text = "查询完成。新卡存在余额，需要通过回收操作才可用，不可作为目标卡！"
                End If
            End If
        End If

        If blStep2OK Then
            Me.btnNext.Select()
        Else
            Me.txbNewCardNo.Select() : Me.txbNewCardNo.SelectAll()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgvMulti_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMulti.CellEndEdit
        If blSkipDeal Then Return
        blSkipDeal = True : Me.dgvMulti.CurrentCell.Selected = False : blSkipDeal = False
    End Sub

    Private Sub dgvMulti_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMulti.CellEnter
        If Not blStep3OK AndAlso Me.dgvMulti.Columns(e.ColumnIndex).Name = "CardNo" Then
            sBeforeCardNo = Me.dgvMulti("CardNo", e.RowIndex).Value.ToString
        End If
    End Sub

    Private Sub dgvMulti_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvMulti.CellFormatting
        If Me.dgvMulti.Columns(e.ColumnIndex).Name = "OperationResult" Then
            If (Me.dgvMulti("IsError", e.RowIndex).Value OrElse Me.dgvMulti("QueryState", e.RowIndex).Value = 1) Then
                e.CellStyle.ForeColor = Color.Red
                e.CellStyle.SelectionForeColor = Color.Brown
            ElseIf e.Value.ToString.IndexOf("等待") > -1 Then
                e.CellStyle.ForeColor = Color.Blue
                e.CellStyle.SelectionForeColor = Color.Yellow
            ElseIf e.Value.ToString.IndexOf("正在") > -1 Then
                e.CellStyle.ForeColor = Color.Green
                e.CellStyle.SelectionForeColor = Color.LightGreen
            End If
        End If
    End Sub

    Private Sub dgvMulti_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMulti.CellLeave
        If editingCardNo IsNot Nothing AndAlso Me.dgvMulti.Columns(e.ColumnIndex).Name = "CardNo" Then
            RemoveHandler editingCardNo.KeyDown, AddressOf CardNo_KeyDown
            editingCardNo = Nothing
        End If
    End Sub

    Private Sub dgvMulti_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvMulti.CellMouseUp
        If blStep3OK OrElse e.Button <> Windows.Forms.MouseButtons.Right OrElse e.RowIndex = -1 OrElse e.ColumnIndex <> 0 OrElse Me.dgvMulti("CardNo", e.RowIndex).Value.ToString = "" Then Return

        blSkipDeal = True
        Me.dgvMulti("OperationResult", e.RowIndex).Selected = True
        Me.dgvMulti.CurrentRow.Selected = True
        blSkipDeal = False
        Me.cmenuDeleteCard.Show(Control.MousePosition)
    End Sub

    Private Sub dgvMulti_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMulti.CellValueChanged
        If blSkipDeal OrElse Me.dgvMulti.Columns(e.ColumnIndex).Name <> "CardNo" Then Return
        blSkipDeal = True

        blStep2OK = False : Me.btnNext.Enabled = False : Me.btnFinish.Enabled = False
        Me.btnDelete.Enabled = True : Me.btnClear.Enabled = True : Me.btnMulti.Enabled = False
        Me.lblInfo2.Text = "原卡余额是 " & Format(dmOldBalance, "#,0.00").Replace(".00", "") & " 元，已超过单卡 1,000 元面值的限制，需换成 " & Format(iNewCards, "#,0") & " 张新卡，请输入新卡。"
        Me.dgvMulti.Columns("NewBalance").Visible = False
        Dim sCardNo As String = Me.dgvMulti("CardNo", e.RowIndex).Value.ToString, blIsOK As Boolean = False
        If sCardNo = "" Then
            If sBeforeCardNo = "" Then
                Me.btnDelete.Enabled = False
                Me.btnClear.Enabled = dtMulti.Rows.Count > 1
            Else
                Me.dgvMulti.EndEdit() : Me.dgvMulti("CardNo", e.RowIndex).Value = sBeforeCardNo : Me.dgvMulti.Refresh()
            End If
        ElseIf Not IsNumeric(sCardNo) Then
            Me.dgvMulti("OperationResult", e.RowIndex).Value = "（卡号只能由数字组成！）"
            Me.dgvMulti("IsError", e.RowIndex).Value = 1
        ElseIf sCardNo.Length < 19 Then
            Me.dgvMulti("OperationResult", e.RowIndex).Value = "（卡号位数不足 19 位！）"
            Me.dgvMulti("IsError", e.RowIndex).Value = 1
        ElseIf sCardNo <> ShoppingCardNo.GetFullCardNo(sCardNo.Substring(0, 18)) Then
            Me.dgvMulti("OperationResult", e.RowIndex).Value = "（卡号校验码错误！）"
            Me.dgvMulti("IsError", e.RowIndex).Value = 1
        ElseIf dvCULParameter.Table.Select("CULCardBin='" & sCardNo.Substring(4, 5) & "'").Length = 0 Then
            Me.dgvMulti("OperationResult", e.RowIndex).Value = "（无权操作该卡段！）"
            Me.dgvMulti("IsError", e.RowIndex).Value = 1
        ElseIf sCardNo = sOldCardNo Then
            Me.dgvMulti("OperationResult", e.RowIndex).Value = "（不能和原卡号相同！）"
            Me.dgvMulti("IsError", e.RowIndex).Value = 1
            'modify code 036,051:start-------------------------------------------------------------------------
        ElseIf sCardNo.Substring(4, 2) <> "84" AndAlso sCardNo.Substring(4, 2) <> "92" AndAlso sCardNo.Substring(4, 2) <> "60" AndAlso sCardNo.Substring(4, 2) <> "65" Then
            Me.dgvMulti("OperationResult", e.RowIndex).Value = "（早期卡不能当作目标卡！）"
            Me.dgvMulti("IsError", e.RowIndex).Value = 1
        ElseIf sOldCardType <> "CRF" AndAlso sOldCardType <> "C65" AndAlso sCardNo.Substring(4, 2) <> "84" AndAlso sCardNo.Substring(4, 2) <> "60" Then
            'Me.dgvMulti("OperationResult", e.RowIndex).Value = "（新卡必须和旧卡同为卡BIN以""84""开头的磁条卡！）"
            Me.dgvMulti("OperationResult", e.RowIndex).Value = "（新卡必须为卡BIN以""84""""60""开头的磁条卡！）"
            Me.dgvMulti("IsError", e.RowIndex).Value = 1
            'modify code 036,051:end-------------------------------------------------------------------------
        ElseIf sOldCardType = "CRF" AndAlso (sOldCardNo.Substring(4, 2) = "84" OrElse sOldCardNo.Substring(4, 2) = "60") AndAlso (sCardNo.Substring(4, 2) = "84" OrElse sCardNo.Substring(4, 2) = "60") Then
            '60和84卡可以互换
            blIsOK = True
            'modify code 036:start-------------------------------------------------------------------------
            'ElseIf sOldCardType = "CRF" AndAlso sOldCardNo.Substring(4, 2) = "84" AndAlso sCardNo.Substring(4, 2) <> "84" Then
            '    Me.dgvMulti("OperationResult", e.RowIndex).Value = "（新卡必须和旧卡同为卡BIN以""84""开头的磁条卡！）"
            '    Me.dgvMulti("IsError", e.RowIndex).Value = 1
            'modify code 036:end-------------------------------------------------------------------------
        ElseIf sOldCardType = "CRF" AndAlso sOldCardNo.Substring(4, 2) = "92" AndAlso sCardNo.Substring(4, 2) <> "92" Then
            Me.dgvMulti("OperationResult", e.RowIndex).Value = "（新卡必须和旧卡同为卡BIN以""92""开头的营销卡！）"
            Me.dgvMulti("IsError", e.RowIndex).Value = 1
        ElseIf sOldCardType = "CRF" AndAlso sOldCardNo.Substring(4, 2) = "94" AndAlso sCardNo.Substring(4, 2) <> "94" Then
            Me.dgvMulti("OperationResult", e.RowIndex).Value = "（新卡必须和旧卡同为卡BIN以""94""开头的活动卡！）"
            Me.dgvMulti("IsError", e.RowIndex).Value = 1
            'modify code 045:start-------------------------------------------------------------------------
        ElseIf sOldCardType = "C86" AndAlso sCardNo.Substring(4, 2) <> "84" AndAlso sCardNo.Substring(4, 2) <> "60" Then
            Me.lblNewCardError.Text = "（新卡为卡BIN以""84""""60""开头的磁条卡！）"
            Me.btnQueryNewCardState.Enabled = False
            'modify code 045:end-------------------------------------------------------------------------
            'modify code 051:start-------------------------------------------------------------------------
        ElseIf sOldCardType = "C65" AndAlso sCardNo.Substring(4, 2) <> "65" Then
            Me.lblNewCardError.Text = "（新卡为卡BIN以""65""开头的磁条卡！）"
            Me.btnQueryNewCardState.Enabled = False
            'modify code 051:end-------------------------------------------------------------------------
        ElseIf dtMulti.Select("CardNo='" & sCardNo & "'").Length > 0 Then
            Me.dgvMulti("OperationResult", e.RowIndex).Value = "（卡号重复！）"
            Me.dgvMulti("IsError", e.RowIndex).Value = 1
        Else
            blIsOK = True
        End If

        If blIsOK Then
            Me.dgvMulti("CardState", e.RowIndex).Value = DBNull.Value
            Me.dgvMulti("Balance", e.RowIndex).Value = DBNull.Value
            Me.dgvMulti("OperationResult", e.RowIndex).Value = "等待到CUL查询状态"
            Me.dgvMulti("IsError", e.RowIndex).Value = 0
            Me.dgvMulti("QueryState", e.RowIndex).Value = 0
            If Me.dgvMulti.RowCount = iNewCards Then
                Me.btnMulti.Enabled = True
                Me.lblInfo2.Text = "您已经输完 " & Format(iNewCards, "#,0") & " 张新卡，现在可以按下右上角的""查询状态""到CUL系统查询它们的状态了……"
            Else
                If Me.dgvMulti.CurrentRow.Index = Me.dgvMulti.RowCount - 1 Then
                    dtMulti.Rows.Add(Me.dgvMulti.RowCount + 1, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, 0, 0)
                    Me.dgvMulti("CardNo", Me.dgvMulti.RowCount - 1).Selected = True
                End If
                Me.dgvMulti.BeginEdit(True)
                Me.btnDelete.Enabled = False
            End If
        End If

        blSkipDeal = False
    End Sub

    Private Sub dgvMulti_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvMulti.EditingControlShowing
        editingCardNo = CType(e.Control, TextBox)
        editingCardNo.ImeMode = Windows.Forms.ImeMode.Disable
        editingCardNo.MaxLength = 19
        AddHandler editingCardNo.KeyDown, AddressOf CardNo_KeyDown
    End Sub

    Private Sub dgvMulti_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvMulti.KeyDown
        If blStep3OK OrElse e.KeyCode <> Keys.Delete OrElse Not Me.dgvMulti.CurrentRow.Selected OrElse Me.dgvMulti("CardNo", Me.dgvMulti.CurrentRow.Index).Value.ToString = "" Then Return
        Me.btnDelete.PerformClick()
        e.SuppressKeyPress = True
    End Sub

    Private Sub dgvMulti_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvMulti.Leave
        Dim clickedControl As Control = Me.pnlMulti.GetChildAtPoint(Me.pnlMulti.PointToClient(Control.MousePosition))
        If clickedControl IsNot Nothing AndAlso clickedControl.Name = "btnDelete" Then Return

        blSkipDeal = True
        If Me.dgvMulti.CurrentCell IsNot Nothing Then Me.dgvMulti.CurrentCell.Selected = False
        If Me.dgvMulti.CurrentRow IsNot Nothing Then Me.dgvMulti.CurrentRow.Selected = False
        Me.btnDelete.Enabled = False
        blSkipDeal = False
    End Sub

    Private Sub dgvMulti_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvMulti.SelectionChanged
        If blSkipDeal OrElse Me.dgvMulti.CurrentCell Is Nothing Then Return
        blSkipDeal = True
        If blStep3OK Then
            Me.dgvMulti.CurrentRow.Selected = True
            Me.btnDelete.Enabled = False
        ElseIf Me.dgvMulti.CurrentCell.ColumnIndex = 0 Then
            Me.dgvMulti("OperationResult", Me.dgvMulti.CurrentRow.Index).Selected = True
            Me.dgvMulti.CurrentRow.Selected = True
            Me.btnDelete.Enabled = (Me.dgvMulti("CardNo", Me.dgvMulti.CurrentRow.Index).Value.ToString <> "")
        ElseIf dtMulti.Select("IsError=1").Length > 0 Then
            Me.dgvMulti("CardNo", dtMulti.Select("IsError=1")(0)("RowID") - 1).Selected = True
            Me.dgvMulti.BeginEdit(True)
            Me.btnDelete.Enabled = (Me.dgvMulti("CardNo", Me.dgvMulti.CurrentRow.Index).Value.ToString <> "")
        ElseIf Me.dgvMulti("CardNo", Me.dgvMulti.CurrentRow.Index).Value.ToString = "" Then
            Me.dgvMulti("CardNo", Me.dgvMulti.CurrentRow.Index).Selected = True
            Me.dgvMulti.BeginEdit(True)
            Me.btnDelete.Enabled = False
        ElseIf Me.dgvMulti.Columns(Me.dgvMulti.CurrentCell.ColumnIndex).Name <> "CardNo" Then
            Me.dgvMulti.CurrentRow.Selected = True
            Me.btnDelete.Enabled = True
        Else
            Me.dgvMulti.BeginEdit(True)
            Me.btnDelete.Enabled = (Me.dgvMulti("CardNo", Me.dgvMulti.CurrentRow.Index).Value.ToString <> "")
        End If
        blSkipDeal = False
    End Sub

    Private Sub menuDeleteCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuDeleteCard.Click
        Me.btnDelete.PerformClick()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        blSkipDeal = True
        blStep2OK = False : Me.btnNext.Enabled = False : Me.btnFinish.Enabled = False
        Me.lblInfo2.Text = "原卡余额是 " & Format(dmOldBalance, "#,0.00").Replace(".00", "") & " 元，已超过单卡 1,000 元面值的限制，需换成 " & Format(iNewCards, "#,0") & " 张新卡，请输入新卡。"
        Me.dgvMulti.Columns("NewBalance").Visible = False
        Dim iCurrentRow As Integer = Me.dgvMulti.CurrentRow.Index, drCard As DataRow = dtMulti.Select("RowID=" & Me.dgvMulti("RowID", iCurrentRow).Value.ToString)(0)
        If iCurrentRow = Me.dgvMulti.RowCount - 1 Then
            If drCard("CardNo").ToString <> "" Then
                drCard.Delete()
                drCard = dtMulti.Rows.Add(iCurrentRow + 1, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, 0, 0)
                Me.btnDelete.Enabled = False
                Me.btnClear.Enabled = False
            End If
        Else
            drCard.Delete()
            For Each drCard In dtMulti.Select("RowID>" & (iCurrentRow + 1))
                drCard("RowID") = drCard("RowID") - 1
            Next
        End If

        If iCurrentRow > Me.dgvMulti.RowCount - 1 Then iCurrentRow = Me.dgvMulti.RowCount - 1
        If Me.dgvMulti("CardNo", iCurrentRow).Value.ToString = "" Then
            Me.dgvMulti.Select()
            Me.dgvMulti("CardNo", iCurrentRow).Selected = True
            Me.dgvMulti.BeginEdit(True)
            Me.btnDelete.Enabled = False
        Else
            If Me.dgvMulti("CardNo", Me.dgvMulti.RowCount - 1).Value.ToString <> "" Then drCard = dtMulti.Rows.Add(Me.dgvMulti.RowCount + 1, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, 0, 0)
            Me.dgvMulti("OperationResult", iCurrentRow).Selected = True : Me.dgvMulti.CurrentRow.Selected = True
        End If
        Me.btnMulti.Enabled = False
        blSkipDeal = False
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        blStep2OK = False : Me.btnNext.Enabled = False : Me.btnFinish.Enabled = False
        dtMulti.Rows.Clear()
        dtMulti.Rows.Add(Me.dgvMulti.RowCount + 1, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, 0, 0)
        Me.dgvMulti.Select()
        Me.dgvMulti("CardNo", Me.dgvMulti.RowCount - 1).Selected = True
        Me.dgvMulti.BeginEdit(True)
        Me.btnDelete.Enabled = False
        Me.btnClear.Enabled = False
        Me.btnMulti.Enabled = False
    End Sub

    Private Sub btnMulti_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMulti.Click
        Me.Cursor = Cursors.WaitCursor
        Me.lblInfo2.ForeColor = SystemColors.ControlText
        Me.lblInfo2.Text = "正在到CUL查询该批购物卡的状态，请稍候……"
        Me.dgvMulti.Select()
        Me.Refresh()

        Dim sDecimalSeparator As String = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
        Dim c4Service As C4ShoppingCardService.C4ShoppingCardService = Nothing, infoClass As C4ShoppingCardService.InfoClass = Nothing, infoDataClass As C4ShoppingCardService.InfoDataClass = Nothing
        Try
            c4Service = New C4ShoppingCardService.C4ShoppingCardService()
            infoClass = New C4ShoppingCardService.InfoClass()
        Catch ex As Exception
            MessageBox.Show("因为CUL系统故障，无法查询购物卡状态！ 下面是CUL系统的内部错误提示：    " & Chr(13) & Chr(13) & ex.Message & Space(4), "出现CUL系统故障！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.lblInfo2.ForeColor = Color.Red
            Me.lblInfo2.Text = "因为CUL系统故障，无法查询购物卡状态！"
            If c4Service IsNot Nothing Then c4Service.Dispose() : c4Service = Nothing
            Me.Cursor = Cursors.Default
            Return
        End Try

        frmMain.statusRate.Visible = True
        frmMain.statusRate.Text = ""
        frmMain.statusProgress.Visible = True
        frmMain.statusProgress.Value = 0
        frmMain.statusMain.Refresh()

        Dim currentRow As DataRow, iCards As Integer = dtMulti.Select("QueryState<>2").Length, iCard As Integer = 0, sCardNo As String, sMerchantNo As String, dmBalance As Decimal = 0
        For iRow As Integer = 0 To Me.dgvMulti.RowCount - 1
            currentRow = dtMulti.Rows.Find(Me.dgvMulti("RowID", iRow).Value.ToString)
            If currentRow("QueryState") <> 2 Then
                dmBalance = 0
                Try
                    Me.dgvMulti("OperationResult", iRow).Selected = True
                    Me.dgvMulti.Rows(iRow).Selected = True

                    iCard += 1
                    frmMain.statusText.Text = "正在查询购物卡状态……"
                    frmMain.statusRate.Text = "(" & iCard.ToString & "/" & iCards.ToString & ")"
                    frmMain.statusProgress.Value = Int((iCard / iCards) * 100)
                    frmMain.statusMain.Refresh()

                    currentRow("OperationResult") = "正在到CUL查询状态……"
                    Me.dgvMulti.Refresh()

                    sCardNo = currentRow("CardNo").ToString
                    sMerchantNo = dvCULParameter.Table.Select("CULCardBin='" & sCardNo.Substring(4, 5) & "'")(0)("CULStoreCode").ToString
                    infoClass.MerchantNo = sMerchantNo
                    infoClass.UserID = sMerchantNo
                    infoClass.CardNoFrom = sCardNo
                    infoClass.CardNoTo = sCardNo
                    infoClass.IsPager = "N"
                    infoClass.PageNo = "1"
                    infoDataClass = c4Service.info(infoClass)

                    If infoDataClass.CodeMsg.Code = "OZ" Then
                        If infoDataClass.Cards(0).HotReason = "冻结" Then
                            currentRow("CardState") = "已冻结"
                        ElseIf infoDataClass.Cards(0).HotReason = "结束" Then
                            currentRow("CardState") = "已结束"
                        ElseIf infoDataClass.Cards(0).Status = "激活" Then
                            currentRow("CardState") = "已激活"
                        Else
                            currentRow("CardState") = "未激活"
                        End If
                        Try
                            dmBalance = CDec(infoDataClass.Cards(0).Balance.ToString.Replace(".", sDecimalSeparator))
                            currentRow("Balance") = dmBalance
                            If dmBalance = 0 Then
                                currentRow("OperationResult") = "余额为零，可以作为目标卡。"
                            Else
                                currentRow("OperationResult") = "余额不为零，不可作为目标卡！"
                                currentRow("IsError") = 1
                            End If
                        Catch
                            currentRow("OperationResult") = "余额不明确，不可作为目标卡。"
                            currentRow("IsError") = 1
                        End Try
                        currentRow("QueryState") = 2
                    Else
                        currentRow("OperationResult") = "（查询失败！）"
                        currentRow("QueryState") = 1
                    End If
                Catch
                    currentRow("OperationResult") = "（查询失败！）"
                    currentRow("QueryState") = 1
                End Try
            End If
        Next

        c4Service.Dispose() : c4Service = Nothing

        frmMain.statusText.Text = "就绪。"
        frmMain.statusRate.Text = ""
        frmMain.statusRate.Visible = False
        frmMain.statusProgress.Value = 0
        frmMain.statusProgress.Visible = False

        dtMulti.AcceptChanges()
        iCard = dtMulti.Select("IsError=1").Length
        iCards = dtMulti.Select("QueryState=1").Length
        If iCard + iCards = 0 Then
            blStep2OK = True
            Me.btnMulti.Enabled = False
            For iCard = 0 To iNewCards - 2
                dtMulti.Rows(iCard)("NewBalance") = 1000
            Next
            dtMulti.Rows(iNewCards - 1)("NewBalance") = dmOldBalance - 1000 * (iNewCards - 1)
            Me.dgvMulti.Columns("NewBalance").Visible = True
            Me.lblInfo2.Text = "查询完成。所有卡的余额均为零，符合作为目标卡的要求。请按""下一步""输入换卡原因并申请换卡……"
            Me.btnNext.Enabled = True
            Me.btnFinish.Enabled = True
            Me.btnNext.Select()
        Else
            Me.lblInfo2.ForeColor = Color.Red
            If iCards = 0 Then
                Me.btnMulti.Enabled = False
                Me.dgvMulti.Select()
                Me.dgvMulti("RowID", 0).Selected = True
                If iCard = iNewCards Then
                    Me.lblInfo2.Text = "查询完成。所有卡的余额均不为零，不符合作为目标卡的要求。请清除这些卡，然后输入其它卡！"
                Else
                    Me.lblInfo2.Text = "查询完成。部分卡的余额不为零，不符合作为目标卡的要求。请删除这部分卡并输入其它卡！"
                End If
            ElseIf iCards = iNewCards Then
                Me.lblInfo2.Text = "所有卡的状态查询失败！请检查网络连接，然后重新检查。"
            Else
                Me.lblInfo2.Text = "部分卡的状态查询失败！请检查网络连接，然后重新检查。"
            End If
        End If
        dtMulti.AcceptChanges()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txbReason_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbReason.Leave
        If Me.txbReason.Text <> Me.txbReason.Text.Trim Then Me.txbReason.Text = Me.txbReason.Text.Trim
    End Sub

    Private Sub txbReason_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbReason.TextChanged
        Me.btnRequest.Enabled = (Me.txbReason.Text <> "")
    End Sub

    Private Sub btnRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRequest.Click
        Me.Cursor = Cursors.WaitCursor
        Me.btnRequest.Select()
        Me.lblInfo3.ForeColor = SystemColors.ControlText
        Me.lblInfo3.Text = "正在保存换卡申请……"
        Me.Refresh()

        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            Me.lblInfo3.ForeColor = Color.Red
            Me.lblInfo3.Text = "系统因连接不到数据库而无法保存换卡申请记录。请检查数据库连接。"
            Me.Cursor = Cursors.Default : Return
        End If

        If DB.ModifyTable("Select TargetCardNo,TargetBalance Into #tempCard From CULReplace Where 1=2") = -1 Then
            Me.lblInfo3.ForeColor = Color.Red
            Me.lblInfo3.Text = "保存购物卡换卡申请记录失败！"
            DB.Close() : Me.Cursor = Cursors.Default : Return
        End If

        Dim tempNewCard As DataTable = dtMulti.DefaultView.ToTable(False, "CardNo", "NewBalance"), dtResult As DataTable
        If iNewCards = 1 Then
            tempNewCard.Rows.Clear()
            tempNewCard.Rows.Add(sNewCardNo, dmOldBalance)
        End If
        tempNewCard.AcceptChanges()

Submit_Again:
        If DB.BulkCopyTable("#tempCard", tempNewCard) = -1 Then
            Me.lblInfo3.ForeColor = Color.Red
            Me.lblInfo3.Text = "保存购物卡换卡申请失败！"
            DB.Close() : Me.Cursor = Cursors.Default : Return
        End If

        'modify code 036:start-------------------------------------------------------------------------
        'modify code 020:start-------------------------------------------------------------------------
        'dtResult = DB.GetDataTable("Exec CULReplaceCardRequest '" & sOldCardNo & Space(19 - sOldCardNo.Length) & "','" & IIf(sOldCardType = "CRF", "家乐福卡", IIf(sOldCardType = "SYT", "商银通卡", "斯玛特卡")) & "'," & dmOldBalance.ToString & ",'" & sOldActivatedDate & "','" & sOldEffectiveDate & "','" & sOldCULStoreCode & "'," & iNewCards.ToString & ",'" & Me.txbReason.Text.Replace("'", "''") & "','" & frmMain.sLoginUserRealName.Replace("'", "''") & "'," & frmMain.sSSID)
        'dtResult = DB.GetDataTable("Exec CULReplaceCardRequest '" & sOldCardNo & "','" & IIf(sOldCardType = "CRF", "家乐福卡", IIf(sOldCardType = "SYT", "商银通卡", "斯玛特卡")) & "'," & dmOldBalance.ToString & ",'" & sOldActivatedDate & "','" & sOldEffectiveDate & "','" & sOldCULStoreCode & "'," & iNewCards.ToString & ",'" & Me.txbReason.Text.Replace("'", "''") & "','" & frmMain.sLoginUserRealName.Replace("'", "''") & "'," & frmMain.sSSID)
        'modify code 020:end-------------------------------------------------------------------------
        Dim sCardTypeDes As String = ""
        If sOldCardType = "CRF" Then
            'modify code 050:start-------------------------------------------------------------------------
            'sCardTypeDes = "家乐福卡"
            If isSignCard = True AndAlso isNewSignCard = 1 Then
                sCardTypeDes = "旧实名制卡"
            ElseIf isSignCard = True AndAlso isNewSignCard = 2 Then
                sCardTypeDes = "实名制卡"
            Else
                sCardTypeDes = "家乐福卡"
            End If
            'modify code 050:end-------------------------------------------------------------------------
        ElseIf sOldCardType = "SYT" Then
            sCardTypeDes = "商银通卡"
        ElseIf sOldCardType = "SMT" Then
            sCardTypeDes = "斯玛特卡"
        ElseIf sOldCardType = "ZH" Then
            sCardTypeDes = "中行卡"
        ElseIf sOldCardType = "BLC" Then
            sCardTypeDes = "保龙仓卡"
            'modify code 045:start-------------------------------------------------------------------------
        ElseIf sOldCardType = "C86" Then
            sCardTypeDes = "86卡"
            'modify code 045:end-------------------------------------------------------------------------
            'modify code 051:start-------------------------------------------------------------------------
        ElseIf sOldCardType = "C65" Then
            sCardTypeDes = "65卡"
            'modify code 051:end-------------------------------------------------------------------------
        End If
        dtResult = DB.GetDataTable("Exec CULReplaceCardRequest '" & sOldCardNo & "','" & sCardTypeDes & "'," & dmOldBalance.ToString & ",'" & sOldActivatedDate & "','" & sOldEffectiveDate & "','" & sOldCULStoreCode & "'," & iNewCards.ToString & ",'" & Me.txbReason.Text.Replace("'", "''") & "','" & frmMain.sLoginUserRealName.Replace("'", "''") & "'," & frmMain.sSSID)
        'modify code 036:end-------------------------------------------------------------------------
        If dtResult Is Nothing Then
            Me.lblInfo3.ForeColor = Color.Red
            Me.lblInfo3.Text = "保存换卡申请记录时出现数据库内部错误！"
        ElseIf dtResult.Rows(0)("Result").ToString = "Missing" Then
            GoTo Submit_Again
        ElseIf dtResult.Rows(0)("Result").ToString = "Failure" Then
            If dtResult.Select("IsSource=1").Length > 0 Then
                sExistingOldCardNo = sOldCardNo
                sOldError = dtResult.Select("IsSource=1")(0)("FailureReason").ToString.Replace("！", "，不可以换卡！")
                Me.lblOldCardError.Text = "（" & sOldError & "）"
                blStep1OK = False
            End If
            If dtResult.Select("IsSource=0").Length > 0 Then
                sExistingNewCardNo = dtResult.Select("IsSource=0")(0)("CardNo").ToString
                sNewError = dtResult.Select("IsSource=0")(0)("FailureReason").ToString.Replace("！", "，不可以作为目标卡！")
                Me.lblNewCardError.Text = "（" & sNewError & "）"
                If iNewCards > 1 Then
                    Dim drCard As DataRow
                    For Each dr As DataRow In dtResult.Select("IsSource=0")
                        drCard = dtMulti.Select("CardNo='" & dr("CardNo").ToString & "'")(0)
                        drCard("OperationResult") = dr("FailureReason").ToString.Replace("！", "，不可以作为目标卡！")
                        drCard("IsError") = 1
                        drCard.AcceptChanges()
                    Next
                End If
                blStep2OK = False
            End If

            If dtResult.Select("IsSource=1").Length > 0 Then
                MessageBox.Show("旧卡""" & sOldCardNo & """" & sOldError.Replace("该卡", "") & "    ", "不可以换卡！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.btnStart.PerformClick()
                Me.txbOldCardNo.Select() : Me.txbOldCardNo.SelectAll()
            ElseIf iNewCards = 1 Then
                MessageBox.Show("新卡""" & sNewCardNo & """" & sNewError.Replace("该卡", "") & "    ", "不可以作为目标卡！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.btnPrevious.PerformClick()
                Me.txbNewCardNo.Select() : Me.txbNewCardNo.SelectAll()
            Else
                MessageBox.Show("部分新卡正处在待审核状态，不可以作为目标卡！    ", "部分新卡不可以作为目标卡！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.btnPrevious.PerformClick()
                Me.dgvMulti.Select()
                Me.dgvMulti("RowID", 0).Selected = True
            End If
            Me.lblInfo3.Text = ""
        ElseIf dtResult.Rows(0)("Result").ToString = "Error" Then
            Me.lblInfo3.ForeColor = Color.Red
            Me.lblInfo3.Text = "保存换卡申请记录时出现错误！"
            MessageBox.Show("系统无法保存购物卡换卡申请记录！下面是数据库的内部错误提示：    " & Chr(13) & Chr(13) & dtResult.Rows(0)("ErrorInfo").ToString & Space(4) & Chr(13) & Chr(13) & "请重试。如果仍有问题，请联系软件开发人员。    ", "保存购物卡换卡申请时出现数据库内部错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            blStep3OK = True
            sExistingOldCardNo = sOldCardNo
            sOldError = "该卡作为原卡，正等待换卡，不可以换卡！"
            If iNewCards = 1 Then sExistingNewCardNo = sNewCardNo Else sExistingNewCardNo = Me.dgvMulti("CardNo", 0).Value.ToString
            sNewError = "该卡作为目标卡，正等待换卡，不可以换卡！"
            Me.pnlStart.Enabled = False
            Me.txbOldCardNo.ReadOnly = True
            Me.txbOldCardNo.BackColor = SystemColors.Window
            Me.txbOldCardNo.BackColor = SystemColors.Control
            Me.txbNewCardNo.ReadOnly = True
            Me.txbNewCardNo.BackColor = SystemColors.Window
            Me.txbNewCardNo.BackColor = SystemColors.Control
            Me.txbReason.ReadOnly = True
            Me.txbReason.BackColor = SystemColors.Window
            Me.txbReason.BackColor = SystemColors.Control
            Me.btnRequest.Enabled = False
            Me.pnlAfter.Visible = True

            If sOldCardType = "CRF" Then
                Me.lblInfo3.Text = "为确保原卡不被消费，正对原卡执行冻结操作……"
                Me.Refresh()

                Dim dtCard As New DataTable()
                dtCard.Columns.Add("CardNo", System.Type.GetType("System.String"))
                dtCard.Rows.Add(sOldCardNo).AcceptChanges()
                If ShoppingCardOperation.CRFCardAutoFreeze(True, dvCULParameter.Table, dtCard) = 0 Then
                    MessageBox.Show("系统在对原卡执行自动冻结时失败！    " & Chr(13) & Chr(13) & "为确保原卡不被消费，请您手工对该卡执行冻结操作。    ", "原卡自动冻结失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    'modify code 047:start-------------------------------------------------------------------------
                Else
                    If isSignCard Then signCardResult = True
                    'modify code 047:end-------------------------------------------------------------------------
                End If
                dtCard.Dispose() : dtCard = Nothing
                'modify code 045:start-------------------------------------------------------------------------
            ElseIf sOldCardType = "C86" Then
                Me.lblInfo3.Text = "为确保原卡不被消费，正对原卡执行冻结操作……"
                Me.Refresh()

                Dim dtCard As New DataTable()
                dtCard.Columns.Add("CardNo", System.Type.GetType("System.String"))
                dtCard.Rows.Add(sOldCardNo).AcceptChanges()
                If ShoppingCardOperation.PaperCardAutoFreeze(True, dvCULParameter.Table, dtCard) = 0 Then MessageBox.Show("系统在对原卡执行自动冻结时失败！    " & Chr(13) & Chr(13) & "为确保原卡不被消费，请您手工对该卡执行冻结操作。    ", "原卡自动冻结失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                dtCard.Dispose() : dtCard = Nothing
                'modify code 045:end-------------------------------------------------------------------------
                'modify code 051:start-------------------------------------------------------------------------
            ElseIf sOldCardType = "C65" Then
                Me.lblInfo3.Text = "为确保原卡不被消费，正对原卡执行冻结操作……"
                Me.Refresh()

                Dim dtCard As New DataTable()
                dtCard.Columns.Add("CardNo", System.Type.GetType("System.String"))
                dtCard.Rows.Add(sOldCardNo).AcceptChanges()
                If ShoppingCardOperation.CRFCardAutoFreeze(True, dvCULParameter.Table, dtCard) = 0 Then
                    MessageBox.Show("系统在对原卡执行自动冻结时失败！    " & Chr(13) & Chr(13) & "为确保原卡不被消费，请您手工对该卡执行冻结操作。    ", "原卡自动冻结失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
                dtCard.Dispose() : dtCard = Nothing
                'modify code 051:end-------------------------------------------------------------------------
            End If
            Me.lblInfo3.Text = "当次操作已完成。按""开始""执行新的操作，或按""关闭""结束操作。"
            Me.btnCancel.Text = "关闭(&C)"
        End If

        If dtResult IsNot Nothing Then dtResult.Dispose() : dtResult = Nothing
        DB.Close()

        If blStep3OK Then Me.btnCancel.Select()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        Me.pnlStart.Visible = True
        Me.pnlStep1.Visible = False
        Me.pnlStep2.Visible = False
        Me.pnlStep3.Visible = False

        bStep = 0
        If blStep3OK Then
            Me.pnlStart.Enabled = True
            Me.txbOldCardNo.ReadOnly = False
            Me.txbOldCardNo.BackColor = SystemColors.Window
            Me.txbOldCardNo.Text = ""
            Me.lblOldCardError.Text = ""
            Me.lblInfo1.Text = ""

            Me.txbNewCardNo.ReadOnly = False
            Me.txbNewCardNo.BackColor = SystemColors.Window
            Me.txbNewCardNo.Text = ""
            Me.lblNewCardError.Text = ""
            Me.lblInfo2.Text = ""
            Me.pnlSingle.Visible = True

            dtMulti.Rows.Clear()
            dtMulti.Rows.Add(1, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, 0, 0)
            Me.lblMulti.Text = ""
            Me.btnDelete.Enabled = False
            Me.btnClear.Enabled = False
            Me.btnMulti.Enabled = False
            Me.dgvMulti.Columns("CardNo").ReadOnly = False
            Me.pnlMulti.Visible = False

            Me.txbReason.ReadOnly = False
            Me.txbReason.BackColor = SystemColors.Window
            Me.txbReason.Text = ""
            Me.pnlAfter.Visible = False
            Me.lblInfo3.Text = ""

            Me.btnStart.Enabled = False
            Me.btnPrevious.Enabled = False
            'modify code 036:start-------------------------------------------------------------------------
            'Me.btnNext.Enabled = False
            Me.btnNext.Enabled = True
            'modify code 036:end-------------------------------------------------------------------------
            Me.btnFinish.Enabled = False
            Me.btnCancel.Text = "取消(&C)"

            sOldCardNo = "" : sNewCardNo = ""
            blStep1OK = False : blStep2OK = False : blStep3OK = False
        Else
            Me.btnStart.Enabled = False
            Me.btnPrevious.Enabled = False
            Me.btnNext.Enabled = True
            Me.btnFinish.Enabled = blStep2OK
        End If
        'modify code 036:start-------------------------------------------------------------------------
        If Me.rdbCRF.Checked Then
            Me.rdbCRF.Select()
        ElseIf Me.rdbSYT.Checked Then
            Me.rdbSYT.Select()
        ElseIf Me.rdbSMT.Checked Then
            Me.rdbSMT.Select()
        ElseIf Me.rdbZH.Checked Then
            Me.rdbZH.Select()
            'modify code 050:start-------------------------------------------------------------------------
        ElseIf Me.rdbOSC.Checked Then
            Me.rdbOSC.Select()
        ElseIf Me.rdbNSC.Checked Then
            Me.rdbNSC.Select()
            'modify code 050:end-------------------------------------------------------------------------
            'modify code 045:start-------------------------------------------------------------------------
        ElseIf Me.rdbC86.Checked Then
            Me.rdbC86.Select()
            'modify code 045:end-------------------------------------------------------------------------
            'modify code 051:start-------------------------------------------------------------------------
        ElseIf Me.rdb65.Checked Then
            Me.rdb65.Select()
            'modify code 051:end-------------------------------------------------------------------------
        Else
            Me.rdbBLC.Select()
        End If
        'modify code 036:end-------------------------------------------------------------------------
    End Sub

    Private Sub btnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevious.Click
        Select Case bStep
            Case 1
                bStep = 0
                Me.pnlStart.Visible = True
                Me.pnlStep1.Visible = False
                Me.pnlStep2.Visible = False
                Me.pnlStep3.Visible = False

                Me.btnStart.Enabled = blStep3OK
                Me.btnPrevious.Enabled = False
                Me.btnNext.Enabled = True
                Me.btnFinish.Enabled = blStep2OK

                'modify code 036:start-------------------------------------------------------------------------
                If blStep3OK Then
                    Me.btnNext.Select()
                ElseIf Me.rdbCRF.Checked Then
                    Me.rdbCRF.Select()
                ElseIf Me.rdbSYT.Checked Then
                    Me.rdbSYT.Select()
                ElseIf Me.rdbSMT.Checked Then
                    Me.rdbSMT.Select()
                ElseIf Me.rdbZH.Checked Then
                    Me.rdbZH.Select()
                    'modify code 050:start-------------------------------------------------------------------------
                ElseIf Me.rdbOSC.Checked Then
                    Me.rdbOSC.Select()
                ElseIf Me.rdbNSC.Checked Then
                    Me.rdbNSC.Select()
                    'modify code 050:end-------------------------------------------------------------------------
                    'modify code 045:start-------------------------------------------------------------------------
                ElseIf Me.rdbC86.Checked Then
                    Me.rdbC86.Select()
                    'modify code 045:end-------------------------------------------------------------------------
                    'modify code 051:start-------------------------------------------------------------------------
                ElseIf Me.rdb65.Checked Then
                    Me.rdb65.Select()
                    'modify code 051:end-------------------------------------------------------------------------
                Else
                    Me.rdbBLC.Select()
                End If
                'modify code 036:end-------------------------------------------------------------------------
            Case 2
                bStep = 1
                Me.pnlStart.Visible = False
                Me.pnlStep1.Visible = True
                Me.pnlStep2.Visible = False
                Me.pnlStep3.Visible = False

                Me.btnStart.Enabled = True
                Me.btnPrevious.Enabled = True
                Me.btnNext.Enabled = True
                Me.btnFinish.Enabled = blStep2OK

                If blStep3OK Then
                    Me.btnNext.Select()
                Else
                    Me.txbOldCardNo.Select() : Me.txbOldCardNo.SelectAll()
                End If
                'modify code 047:start-------------------------------------------------------------------------
                If isSignCard Then btnPrevious.Enabled = False
                'modify code 047:end-------------------------------------------------------------------------
            Case 3
                bStep = 2
                Me.pnlStart.Visible = False
                Me.pnlStep1.Visible = False
                Me.pnlStep2.Visible = True
                Me.pnlStep3.Visible = False

                Me.btnStart.Enabled = True
                Me.btnPrevious.Enabled = True
                Me.btnNext.Enabled = True
                Me.btnFinish.Enabled = True

                If blStep3OK Then
                    Me.btnPrevious.Select()
                Else
                    Me.txbNewCardNo.Select() : Me.txbNewCardNo.SelectAll()
                End If
        End Select

        'modify code 047:start-------------------------------------------------------------------------
        If isSignCard Then btnStart.Enabled = False
        'modify code 047:end-------------------------------------------------------------------------
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Select Case bStep
            Case 0
                bStep = 1
                Me.pnlStart.Visible = False
                Me.pnlStep1.Visible = True
                Me.pnlStep2.Visible = False
                Me.pnlStep3.Visible = False

                Me.btnStart.Enabled = True
                Me.btnPrevious.Enabled = True
                Me.btnNext.Enabled = blStep1OK
                Me.btnFinish.Enabled = blStep2OK

                If blStep3OK Then
                    Me.btnNext.Select()
                Else
                    Me.txbOldCardNo.Select() : Me.txbOldCardNo.SelectAll()
                End If
            Case 1
                bStep = 2
                Me.pnlStart.Visible = False
                Me.pnlStep1.Visible = False
                Me.pnlStep2.Visible = True
                Me.pnlStep3.Visible = False

                Me.btnStart.Enabled = True
                Me.btnPrevious.Enabled = True
                Me.btnNext.Enabled = blStep2OK
                Me.btnFinish.Enabled = blStep2OK

                If Not blStep2OK Then
                    If iNewCards = 1 Then
                        Me.txbNewCardNo.Select() : Me.txbNewCardNo.SelectAll()
                    Else
                        Me.dgvMulti.Select()
                        Me.dgvMulti("CardNo", Me.dgvMulti.RowCount - 1).Selected = True
                    End If
                ElseIf Me.btnNext.Enabled Then
                    Me.btnNext.Select()
                Else
                    Me.btnPrevious.Select()
                End If
            Case 2
                Me.btnFinish.PerformClick()
        End Select
        'modify code 047:start-------------------------------------------------------------------------
        If isSignCard Then btnStart.Enabled = False
        'modify code 047:end-------------------------------------------------------------------------
    End Sub

    Private Sub btnFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinish.Click
        bStep = 3
        Me.pnlStart.Visible = False
        Me.pnlStep1.Visible = False
        Me.pnlStep2.Visible = False
        Me.pnlStep3.Visible = True

        Me.btnStart.Enabled = True
        Me.btnPrevious.Enabled = True
        Me.btnNext.Enabled = False
        Me.btnFinish.Enabled = False

        If Not blStep3OK Then
            Me.txbReason.Select() : Me.txbReason.SelectAll()
        Else
            Me.btnPrevious.Select()
        End If

        'modify code 047:start-------------------------------------------------------------------------
        If isSignCard Then btnStart.Enabled = False
        'modify code 047:end-------------------------------------------------------------------------

        'modify code 076:start-------------------------------------------------------------------------
        If rdbSYT.Checked Then
            PrintTicket()
        End If
        'modify code 076:end-------------------------------------------------------------------------
    End Sub

    Private Sub btnHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistory.Click
        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在打开购物卡""换卡""历史记录窗口……"
        frmMain.statusMain.Refresh()

        If frmReplaceCardHistory.ShowDialog() = Windows.Forms.DialogResult.Ignore Then Me.btnHistory.Enabled = False
        frmReplaceCardHistory.Dispose()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CardNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If editingCardNo IsNot Nothing AndAlso editingCardNo.SelectedText.Length = editingCardNo.Text.Length Then
                blSkipDeal = True
                Me.dgvMulti.CurrentCell.Value = ""
                blSkipDeal = False
            End If
            Return
        End If
        e.SuppressKeyPress = True
    End Sub

    'modify code 036:start-------------------------------------------------------------------------
    Private Sub rdbZH_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbZH.CheckedChanged
        sOldCardType = "ZH"
        Me.txbOldCardNo.Text = ""
        Me.txbOldCardNo.MaxLength = 19
        Me.txbNewCardNo.Text = ""
        Me.grbOldCard.Text = "第一步：输入原卡（中行卡）卡号并查询该卡的状态"
    End Sub

    Private Sub btnZH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnZH.Click
        Me.rdbZH.Checked = True
        Me.btnNext.PerformClick()
    End Sub

    Private Sub rdbBLC_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbBLC.CheckedChanged
        sOldCardType = "BLC"
        Me.txbOldCardNo.Text = ""
        Me.txbOldCardNo.MaxLength = 7
        Me.txbNewCardNo.Text = ""
        Me.grbOldCard.Text = "第一步：输入原卡（保龙仓卡）卡号并查询该卡的状态"
    End Sub

    Private Sub btnBLC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBLC.Click
        Me.rdbBLC.Checked = True
        Me.btnNext.PerformClick()
    End Sub
    'modify code 036:end-------------------------------------------------------------------------

    'modify code 051:start-------------------------------------------------------------------------
    Private Sub rdb65_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdb65.CheckedChanged
        sOldCardType = "C65"
        Me.txbOldCardNo.Text = ""
        Me.txbOldCardNo.MaxLength = 19
        Me.txbNewCardNo.Text = ""
        Me.grbOldCard.Text = "第一步：输入原卡（65卡）卡号并查询该卡的状态"
    End Sub

    Private Sub btn65_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn65.Click
        Me.rdb65.Checked = True
        Me.btnNext.PerformClick()
    End Sub
    'modify code 051:end-------------------------------------------------------------------------

    'modify code 075:start-------------------------------------------------------------------------
    Private Sub rdbNew80_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbNew80.CheckedChanged
        sOldCardType = "80888"
        Me.txbOldCardNo.Text = ""
        Me.txbOldCardNo.MaxLength = 19
        Me.txbNewCardNo.Text = ""
        Me.grbOldCard.Text = "第一步：输入原卡（80888）卡号并查询该卡的状态"
    End Sub

    Private Sub btnNew80_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew80.Click
        Me.rdbNew80.Checked = True
        Me.btnNext.PerformClick()
    End Sub
    'modify code 075:end-------------------------------------------------------------------------

    'modify code 076:end-------------------------------------------------------------------------
    Private Sub PrintTicket()

        If Printing.PrinterSettings.InstalledPrinters.Count = 0 Then
            MessageBox.Show("您的电脑未发现打印机！请先安装打印机。    ", "未发现打印机！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "未发现打印机！"
            Return
        End If

        'With frmConfigTicket
        '    For Each sPrinter As String In Printing.PrinterSettings.InstalledPrinters
        '        .cbbPrinter.Items.Add(sPrinter)
        '    Next
        '    If My.Settings.TicketPrinter <> "" AndAlso .cbbPrinter.Items.IndexOf(My.Settings.TicketPrinter) > -1 Then
        '        .cbbPrinter.SelectedIndex = .cbbPrinter.Items.IndexOf(My.Settings.TicketPrinter)
        '        If .Text.IndexOf("不再可用") > -1 Then
        '            .cbbPrinter.Items(.cbbPrinter.Items.IndexOf(My.Settings.TicketPrinter)) = My.Settings.TicketPrinter & "（不可用）"
        '        End If
        '    Else
        '        Dim printDoc As New Printing.PrintDocument
        '        .cbbPrinter.SelectedIndex = .cbbPrinter.Items.IndexOf(printDoc.PrinterSettings.PrinterName)
        '        printDoc.Dispose() : printDoc = Nothing
        '    End If

        '    If .ShowDialog = Windows.Forms.DialogResult.OK Then
        '        My.Settings.TicketPrinter = .cbbPrinter.Text
        '        My.Settings.Save()
        '        blCheckTicketPrinter = False
        '    End If

        '    .Dispose()
        'End With

        If My.Settings.TicketPrinter = "" Then
            frmConfigTicket.Text = "未指定打印机，请先指定打印机："
            frmSelling.btnConfigTicket.PerformClick()
            If My.Settings.TicketPrinter = "" Then Return
        End If

        Dim DB As New DataBase()
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打印发票。请检查数据库连接。"
            Me.Activate() : Me.Cursor = Cursors.Default : Return
        End If

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在打印发票"
        frmMain.statusMain.Refresh()

        dtCardListInTicket = New DataTable
        dtCardListInTicket.Columns.Add("OldCardNo", System.Type.GetType("System.String"))
        dtCardListInTicket.Columns.Add("OldAmount", System.Type.GetType("System.Decimal"))
        dtCardListInTicket.Columns.Add("NewCardNo", System.Type.GetType("System.String"))
        dtCardListInTicket.Columns.Add("NewFaceValue", System.Type.GetType("System.Decimal"))

        Dim newCard As DataRow
        newCard = dtCardListInTicket.Rows.Add(0)
        newCard("OldCardNo") = sOldCardNo
        newCard("OldAmount") = dmOldBalance
        newCard("NewCardNo") = sNewCardNo
        newCard("NewFaceValue") = dmNewBalance
        newCard.EndEdit()
        dtCardListInTicket.AcceptChanges()

        If Not blCheckTicketPrinter Then
            Dim sPrinterName As String = "", sDriverName As String = ""
            Try
                Dim WMI As New System.Management.ManagementObjectSearcher("SELECT * FROM Win32_Printer"), WMER As System.Management.PropertyDataCollection.PropertyDataEnumerator
                For Each WMIOBJ As System.Management.ManagementObject In WMI.Get
                    WMER = WMIOBJ.Properties.GetEnumerator : sPrinterName = "" : sDriverName = ""
                    While WMER.MoveNext
                        With WMER.Current
                            If .Name.ToLower = "name" Then sPrinterName = .Value.ToString
                            If .Name.ToLower = "drivername" Then sDriverName = .Value.ToString
                            If sPrinterName <> "" AndAlso sDriverName <> "" Then Exit While
                        End With
                    End While
                    If sPrinterName = My.Settings.TicketPrinter Then Exit For
                Next
                WMI = Nothing
            Catch
                If My.Settings.TicketPrinter.ToLower.IndexOf("epson") > -1 Then sDriverName = "EPSON LQ-735K ESC/P2" Else sDriverName = ""
            End Try

            blCheckTicketPrinter = True
        End If

        Try
            Dim Ticket As New System.Drawing.Printing.PrintDocument, PrintStandard As New System.Drawing.Printing.StandardPrintController()
            Ticket.PrintController = PrintStandard '不出现打印窗口
            Ticket.DocumentName = "Ticket_" & Date.Now.ToString
            iTicketPageNum = 1
            Ticket.PrinterSettings.PrinterName = My.Settings.TicketPrinter

            AddHandler Ticket.PrintPage, AddressOf Ticket_PrintPage
            Ticket.PrinterSettings.Copies = 1

            Ticket.Print()
            Ticket.Dispose()

            frmMain.statusText.Text = "就绪。"
        Catch ex As Exception
            MessageBox.Show("打印发票时发生如下错误：    " & Chr(13) & Chr(13) & ex.Message & "    ", "打印发票出错！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "打印发票出错！"
        End Try

        Me.Activate() : Me.Cursor = Cursors.Default
        DB.Close()
    End Sub

    Private Sub Ticket_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        e.Graphics.PageUnit = GraphicsUnit.Millimeter

        Dim titleFont As New Font("宋体", 16), drawFont As New Font("宋体", 10), footFont As New Font("宋体", 9, FontStyle.Italic), blackPen As New Pen(Color.Black, 0.2), drawBrush As New SolidBrush(Color.Black)
        Dim titleFormat As New StringFormat, rightFormat As New StringFormat, drawFormat As New StringFormat
        titleFormat.Alignment = StringAlignment.Center
        rightFormat.Alignment = StringAlignment.Far
        drawFormat.Alignment = StringAlignment.Near
        drawFormat.FormatFlags = StringFormatFlags.NoWrap

        Dim sPrintingText As String = "商银通卡换福卡换卡凭证"
        e.Graphics.DrawString(sPrintingText, titleFont, drawBrush, New Rectangle(10, 10, 180, 20), titleFormat)

        e.Graphics.DrawLine(blackPen, 10, 23, 190, 23)

        Dim newRowHeight As Integer = 0
        Dim iRow As Integer, iStartRow As Int16 = (iTicketPageNum - 1) * iPrintRows, iEndRow As Int16 = iStartRow + iPrintRows - 1
        If iEndRow > dtCardListInTicket.Rows.Count - 1 Then iEndRow = dtCardListInTicket.Rows.Count - 1

        If iEndRow >= iStartRow Then
            e.Graphics.DrawString("原卡号", drawFont, drawBrush, New Rectangle(20, 30 + newRowHeight, 40, 10), drawFormat)
            e.Graphics.DrawString("原卡金额", drawFont, drawBrush, New Rectangle(60, 30 + newRowHeight, 18, 10), drawFormat)
            e.Graphics.DrawString("新卡号", drawFont, drawBrush, New Rectangle(83, 30 + newRowHeight, 40, 10), drawFormat)
            e.Graphics.DrawString("新卡面值", drawFont, drawBrush, New Rectangle(123, 30 + newRowHeight, 18, 10), drawFormat)
        End If

        For iRow = iStartRow To iEndRow
            e.Graphics.DrawString(dtCardListInTicket.Rows(iRow)("OldCardNo").ToString, drawFont, drawBrush, New Rectangle(20, 36 + newRowHeight + (iRow Mod iPrintRows) * 5, 40, 10), drawFormat)
            e.Graphics.DrawString(dtCardListInTicket.Rows(iRow)("OldAmount").ToString, drawFont, drawBrush, New Rectangle(63, 36 + newRowHeight + (iRow Mod iPrintRows) * 5, 18, 10), drawFormat)
            e.Graphics.DrawString(dtCardListInTicket.Rows(iRow)("NewCardNo").ToString, drawFont, drawBrush, New Rectangle(83, 36 + newRowHeight + (iRow Mod iPrintRows) * 5, 40, 10), drawFormat)
            e.Graphics.DrawString(dtCardListInTicket.Rows(iRow)("NewFaceValue").ToString, drawFont, drawBrush, New Rectangle(126, 36 + newRowHeight + (iRow Mod iPrintRows) * 5, 18, 10), drawFormat)
        Next

        Dim blIsLastPage As Boolean, iCurrentPageNum As Int16 = iTicketPageNum
        If iTicketPageCount > 1 Then
            If iTicketPageNum < iTicketPageCount Then
                blIsLastPage = False
                e.HasMorePages = True
            Else
                blIsLastPage = True
                e.HasMorePages = False
            End If
            iTicketPageNum = iTicketPageNum + 1
        Else
            blIsLastPage = True
            e.HasMorePages = False
        End If

        If blIsLastPage Then
            Dim bDistance As Byte = 5, iTop As Integer = 238 + iAdjust + newRowHeight - 130, iWidth As Integer = 90
            bDistance = 4
            iWidth = 50

            e.Graphics.DrawLine(blackPen, 10, 252 + iAdjust + newRowHeight - 130, 190, 252 + iAdjust + newRowHeight - 130)

            e.Graphics.DrawString("本人已认真阅读家乐福福卡公告及章程，知晓并同意其中所有条款。", drawFont, drawBrush, New Rectangle(11, 261 + iAdjust + newRowHeight - 130, 120, 10), drawFormat)

            e.Graphics.DrawString("客户签名：", drawFont, drawBrush, New Rectangle(117, 271 + iAdjust + newRowHeight - 130, 20, 10), drawFormat) '-6
            e.Graphics.DrawString("销售签名：", drawFont, drawBrush, New Rectangle(155, 271 + iAdjust + newRowHeight - 130, 20, 10), drawFormat) '-6
        Else
            e.Graphics.DrawLine(blackPen, 10, 276 + iAdjust + newRowHeight - 130, 190, 276 + iAdjust + newRowHeight - 130)
        End If

        e.Graphics.DrawString("门店：" & frmMain.dtLoginStructure.Rows.Find(frmMain.sLoginAreaID)("AreaName").ToString & "  " & _
            "打印：" & frmMain.sLoginUserRealName & "  " & _
            "打印时间：" & Date.Now.ToString, footFont, drawBrush, New Rectangle(10, 278 + iAdjust + newRowHeight - 130, 180, 10), drawFormat)

        e.Graphics.DrawString("(第" & iCurrentPageNum & "页,共" & iTicketPageCount & "页)", footFont, drawBrush, New Rectangle(10, 278 + iAdjust + newRowHeight - 130, 180, 10), rightFormat)

    End Sub
    'modify code 076:end-------------------------------------------------------------------------

End Class