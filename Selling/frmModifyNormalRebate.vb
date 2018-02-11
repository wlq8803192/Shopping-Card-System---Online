Public Class frmModifyNormalRebate

    'modify code 038:
    'date;2014/9/24
    'auther:Hyron bjy 
    'remark:返点比率0.0->0.00

    'modify code 046:
    'date;2015/4/1
    'auther:Hyron zyx 
    'remark:新增销售单类型---实名制卡销售单

    'modify code 050:
    'date;2015/10/26
    'auther:Hyron qm 
    'remark:增加实名制卡CardBin

    'modify code 051:
    'date;2016/01/08
    'auther:BJY 
    'remark:增加通卖卡65888

    Public drRule As DataRow, dtRebateCard As DataTable, dtOriginalNormal As DataTable, dtOriginalRebate As DataTable, dtPaperCardFaceValue As DataTable, dmMaxFaceValue As Decimal = 0, sCULCardBin As String = "", sGiftCardBin As String = "", sFreeCardBin As String = "", sPaperCardBin As String = "", blCanUse60Card As Boolean = False, blCanUse92Card As Boolean = False, blCanUse94Card As Boolean = False, blCanUsePaperCard As Boolean = False
    Private blSkipDeal As Boolean = True, blBrushingEnd As Boolean = True, sTimerType As String = "BrushCard", sErrorRebateInfo As String = "", errorRebateCell As DataGridViewCell, editingTextBox As TextBox
    Private dmNormalSalesAMT As Decimal = 0, dmRebateSalesAMT As Decimal = 0, iRebateCardQTY As Integer = 0, dmOldRebateSalesAMT As Decimal = 0, dmAvailableRebateAMT As Decimal = 0, dmAvailableRebateRate As Decimal = 0, dmMaxNormalRebateRate As Decimal = 0, dmMaxNormalRebateAMT As Decimal = 0, blCalculateNormalRebateByRate As Boolean = False

    Private blCanHavePaperCard As Boolean = False '如果是哈尔滨或测试城市且销售类型是一般销售单时为True

    Private Declare Function LockWindowUpdate Lib "user32" (ByVal hwndLock As Long) As Long
    'modify code 050:start-------------------------------------------------------------------------
    Public sSignCardBin As String = ""
    Private dtSignCardRangeAll As DataTable
    'modify code 050:end-------------------------------------------------------------------------
    'modify code 051:start-------------------------------------------------------------------------
    Public blCanUse65Card As Boolean = False
    'modify code 051:end-------------------------------------------------------------------------

    Private Sub frmModifyNormalRebate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtRebateCard.Rows.Add(dtRebateCard.Rows.Count + 1)
        With Me.dgvRebateCard
            .DataSource = dtRebateCard
            With .Columns(0)
                .HeaderText = "行号"
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
                .HeaderText = "卡类型"
                .Width = 50
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
                .Visible = (dtRebateCard.Select("Isnull(CardFeature,'磁条卡')<>'磁条卡'").Length > 0)
            End With
            With .Columns(2)
                .HeaderText = "开始卡号"
                .Width = 125
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(3)
                .HeaderText = "结束卡号"
                .Width = 125
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(4)
                .HeaderText = "数量"
                .MinimumWidth = 50
                .FillWeight = 50
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,0"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(5)
                .HeaderText = "面值"
                .MinimumWidth = 50
                .FillWeight = 75
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,0.00"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(6)
                .HeaderText = "充值总计"
                .MinimumWidth = 60
                .FillWeight = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,0.00"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
            End With
            'modify code 050:start-------------------------------------------------------------------------
            '实名制卡销售单界面返点表追加实名制信息列
            With .Columns(7)
                .HeaderText = "持卡人姓名"
                .Width = 80
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            Dim newColumn As New DataGridViewComboBoxColumn
            newColumn.Items.Add("男")
            newColumn.Items.Add("女")
            With newColumn
                .DataPropertyName = "Gender"
                .ValueMember = "Gender"
                .DisplayMember = "Gender"
                .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                .DefaultCellStyle.Padding = New Padding(0, 1, 0, 0)
            End With
            .Columns.RemoveAt(8)
            .Columns.Insert(8, newColumn)
            With .Columns(8)
                .HeaderText = "性别"
                .Width = 50
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(9)
                .HeaderText = "持卡人身份证"
                .Width = 125
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(10)
                .HeaderText = "持卡人手机"
                .Width = 125
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
            End With
            'modify code 050:end-------------------------------------------------------------------------
        End With
        For bColumn As Byte = 0 To dtRebateCard.Columns.Count - 1
            Me.dgvRebateCard.Columns(bColumn).Name = dtRebateCard.Columns(bColumn).ColumnName
        Next
        'modify code 050:start-------------------------------------------------------------------------
        '实名制卡销售单界面返点表追加实名制信息列
        'If frmSelling.bNewSalesBillType = 7 Then
        '    Me.dgvRebateCard.Columns(7).Visible = True
        '    Me.dgvRebateCard.Columns(8).Visible = True
        '    Me.dgvRebateCard.Columns(9).Visible = True
        '    Me.dgvRebateCard.Columns(10).Visible = True
        'Else
        Me.dgvRebateCard.Columns(7).Visible = False
        Me.dgvRebateCard.Columns(8).Visible = False
        Me.dgvRebateCard.Columns(9).Visible = False
        Me.dgvRebateCard.Columns(10).Visible = False
        'End If
        'modify code 050:end-------------------------------------------------------------------------
        For Each drRebate As DataGridViewRow In Me.dgvRebateCard.Rows
            drRebate.Cells("FaceValue").ReadOnly = (drRebate.Cells("StartCardNo").Value.ToString.IndexOf("8") = 0)
        Next

        dmNormalSalesAMT = CDec(Me.txbNormalSalesAMT.Text)
        dmAvailableRebateRate = CDec(Me.txbNormalRebateRate.Text) / 100
        dmOldRebateSalesAMT = CDec(Me.txbNormalRebateAMT.Text) : dmRebateSalesAMT = dmOldRebateSalesAMT : dmAvailableRebateAMT = dmOldRebateSalesAMT
        dmMaxNormalRebateRate = CDec(Me.txbMaxNormalRebateRate.Text) / 100
        dmMaxNormalRebateAMT = CDec(Me.txbMaxNormalRebateAMT.Text)
        Me.grbNormalRebate.Height = Me.flpNormalRebate.Height + 20

        iRebateCardQTY = dtRebateCard.Compute("Sum(CardQTY)", "")
        Me.lblRebateCardSummary.Text = "（卡数： " & Format(iRebateCardQTY, "#,0") & " 张  充值： " & Format(dmRebateSalesAMT, "#,0.00") & " 元）"

        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库。请检查数据库连接。"
            Me.Close() : Return
        End If

        'modify code 050:start-------------------------------------------------------------------------
        Dim strBin As String
        strBin = Replace(sSignCardBin, "|", "','")
        dtSignCardRangeAll = DB.GetDataTable("Select * From SignCardListNew Where CardType = '实名制卡' and SUBSTRING(cardno,5,5) in ('" & strBin & "')").Copy
        'modify code 050:end-------------------------------------------------------------------------

        blSkipDeal = False
        Me.txbNormalRebateAMT.Select() : Me.txbNormalRebateAMT.SelectAll()
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub txbNormalRebateRate_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbNormalRebateRate.DoubleClick
        Me.txbNormalRebateRate.SelectAll()
    End Sub

    Private Sub txbNormalRebateRate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbNormalRebateRate.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then Me.txbNormalRebateAMT.Select() : Me.txbNormalRebateAMT.SelectAll() : e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        If e.KeyCode = Keys.OemPeriod OrElse e.KeyCode = Keys.Decimal Then
            If Me.txbNormalRebateRate.SelectedText.IndexOf(".") > -1 OrElse Me.txbNormalRebateRate.Text.IndexOf(".") = -1 Then Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbNormalRebateRate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txbNormalRebateRate.Validating
        If Me.txbNormalRebateRate.Text <> Me.txbNormalRebateRate.Text.Trim Then Me.txbNormalRebateRate.Text = Me.txbNormalRebateRate.Text.Trim
        'modify code 038:start-------------------------------------------------------------------------
        'If Not IsNumeric(Me.txbNormalRebateRate.Text) Then Me.txbNormalRebateRate.Text = "0.0"
        'Me.txbNormalRebateRate.Text = Format(CDec(Me.txbNormalRebateRate.Text), "#,0.0")
        If Not IsNumeric(Me.txbNormalRebateRate.Text) Then Me.txbNormalRebateRate.Text = "0.00"
        Me.txbNormalRebateRate.Text = Format(CDec(Me.txbNormalRebateRate.Text), "#,0.00")
        'modify code 038:end-------------------------------------------------------------------------
        If dmAvailableRebateRate = CDec(Me.txbNormalRebateRate.Text) / 100 Then Return
        dmAvailableRebateRate = CDec(Me.txbNormalRebateRate.Text) / 100
        blCalculateNormalRebateByRate = True

        If dmAvailableRebateRate > 1 Then
            MessageBox.Show("系统规定：返点比率不能超过 20 %！请重新输入返点比率。    ", "返点比率超过 20 %！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
            Return
        End If

        dmAvailableRebateAMT = dmNormalSalesAMT * dmAvailableRebateRate
        Me.txbNormalRebateAMT.Text = Format(dmAvailableRebateAMT, "#,0.00")
        Me.UpdateNormalRebateInfo()
    End Sub

    Private Sub txbNormalRebateAMT_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbNormalRebateAMT.DoubleClick
        Me.txbNormalRebateAMT.SelectAll()
    End Sub

    Private Sub txbNormalRebateAMT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbNormalRebateAMT.Enter
        Me.txbNormalRebateAMT.Text = Me.txbNormalRebateAMT.Text.Replace(",", "")
    End Sub

    Private Sub txbNormalRebateAMT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbNormalRebateAMT.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.Enter Then
            If Not IsNumeric(Me.txbNormalRebateAMT.Text) OrElse CDec(Me.txbNormalRebateAMT.Text) = 0 Then
                Me.txbNormalRebateRate.Select() : Me.txbNormalRebateRate.SelectAll()
            Else
                Me.dgvRebateCard.Select() : Me.dgvRebateCard("StartCardNo", Me.dgvRebateCard.RowCount - 1).Selected = True
            End If
            e.SuppressKeyPress = True : Return
        End If
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        If e.KeyCode = Keys.OemPeriod OrElse e.KeyCode = Keys.Decimal Then
            If Me.txbNormalRebateAMT.SelectedText.IndexOf(".") > -1 OrElse Me.txbNormalRebateAMT.Text.IndexOf(".") = -1 Then Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbNormalRebateAMT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txbNormalRebateAMT.Validating
        If Me.txbNormalRebateAMT.Text <> Me.txbNormalRebateAMT.Text.Trim Then Me.txbNormalRebateAMT.Text = Me.txbNormalRebateAMT.Text.Trim
        If Not IsNumeric(Me.txbNormalRebateAMT.Text) Then Me.txbNormalRebateAMT.Text = "0.00"
        Me.txbNormalRebateAMT.Text = Format(CDec(Me.txbNormalRebateAMT.Text), "#,0.00")
        If dmAvailableRebateAMT = CDec(Me.txbNormalRebateAMT.Text) Then Return
        dmAvailableRebateAMT = CDec(Me.txbNormalRebateAMT.Text)
        blCalculateNormalRebateByRate = False

        If dmAvailableRebateAMT = 0 Then
            dmAvailableRebateRate = 0
        ElseIf dmNormalSalesAMT = 0 Then
            dmAvailableRebateRate = 1
        Else
            'modify code 038:start-------------------------------------------------------------------------
            'dmAvailableRebateRate = Int((dmAvailableRebateAMT / dmNormalSalesAMT) * 1000 + 0.5) / 1000
            dmAvailableRebateRate = Int((dmAvailableRebateAMT / dmNormalSalesAMT) * 10000 + 0.5) / 10000
            'modify code 038:end-------------------------------------------------------------------------
        End If
        If dmAvailableRebateRate > 1 Then
            MessageBox.Show("系统规定：返点比率不能超过 20 %！请重新输入返点比率。    ", "返点比率超过 20 %！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
            Return
        End If

        'modify code 038:start-------------------------------------------------------------------------
        'Me.txbNormalRebateRate.Text = Format(dmAvailableRebateRate * 100, "#,0.0")
        Me.txbNormalRebateRate.Text = Format(dmAvailableRebateRate * 100, "#,0.00")
        'modify code 038:end-------------------------------------------------------------------------
        Me.UpdateNormalRebateInfo()
    End Sub

    Private Sub chbPrintDiscount_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbPrintDiscount.CheckedChanged
        If blSkipDeal OrElse Me.grbPrintDiscount.Visible = False Then Return
        frmSelling.drSalesBill("InvoicePrintDiscount") = IIf(Me.chbPrintDiscount.Checked, 1, 0)
        Me.dgvRebateCard.Select()
        If Me.chbPrintDiscount.Checked = False Then
            For iRow As Int16 = Me.dgvRebateCard.RowCount - 1 To 0 Step -1
                If Me.dgvRebateCard("CardFeature", iRow).Value.ToString <> "" AndAlso Me.dgvRebateCard("CardFeature", iRow).Value.ToString <> "营销卡" Then
                    Me.dgvRebateCard("RowID", iRow).Selected = True
                    Me.menuDeleteRebateCard.PerformClick()
                End If
            Next
        End If
        Me.dgvRebateCard("StartCardNo", Me.dgvRebateCard.RowCount - 1).Selected = True
    End Sub

    Private Sub lblPrintDiscount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPrintDiscount.Click
        Me.chbPrintDiscount.Select()
        If sTimerType <> "CustomerError" Then Me.chbPrintDiscount.Checked = Not Me.chbPrintDiscount.Checked
    End Sub

    Private Sub dgvRebateCard_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRebateCard.CellEndEdit
        blSkipDeal = True : Me.dgvRebateCard.CurrentCell.Selected = False : blSkipDeal = False
    End Sub

    Private Sub dgvRebateCard_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvRebateCard.CellFormatting
        If e.ColumnIndex > 0 Then
            If Me.dgvRebateCard.Columns(e.ColumnIndex).Name = "CardFeature" AndAlso Me.dgvRebateCard("CardFeature", e.RowIndex).Value.ToString <> "磁条卡" Then
                e.CellStyle.BackColor = Color.WhiteSmoke
                'e.CellStyle.ForeColor = Color.Orange
                'e.CellStyle.Font = New Font(e.CellStyle.Font, FontStyle.Bold)
            ElseIf Me.dgvRebateCard.CurrentRow IsNot Nothing AndAlso Me.dgvRebateCard.CurrentRow.Selected = True AndAlso e.RowIndex = Me.dgvRebateCard.CurrentRow.Index Then
                If errorRebateCell IsNot Nothing AndAlso e.ColumnIndex = errorRebateCell.ColumnIndex AndAlso e.RowIndex = errorRebateCell.RowIndex Then
                    e.CellStyle.SelectionForeColor = Color.Red
                Else
                    e.CellStyle.SelectionForeColor = SystemColors.HighlightText
                End If
                e.CellStyle.SelectionBackColor = SystemColors.Highlight
            Else
                If Me.dgvRebateCard(e.ColumnIndex, e.RowIndex).ReadOnly Then
                    e.CellStyle.BackColor = Color.WhiteSmoke
                ElseIf Me.dgvRebateCard.Columns(e.ColumnIndex).Name = "FaceValue" AndAlso e.Value.ToString <> "" AndAlso e.Value = 0 Then
                    e.CellStyle.ForeColor = Color.Red
                ElseIf errorRebateCell IsNot Nothing AndAlso e.ColumnIndex = errorRebateCell.ColumnIndex AndAlso e.RowIndex = errorRebateCell.RowIndex Then
                    e.CellStyle.ForeColor = Color.Red
                End If
            End If
        End If
    End Sub

    Private Sub dgvRebateCard_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRebateCard.CellLeave
        If editingTextBox IsNot Nothing AndAlso e.ColumnIndex > 0 Then
            Select Case Me.dgvRebateCard.Columns(Me.dgvRebateCard.CurrentCell.ColumnIndex).Name
                Case "CardQTY"
                    If editingTextBox.Text <> "" Then editingTextBox.Text = Format(CDec(editingTextBox.Text), "#,0")
                Case "FaceValue"
                    If editingTextBox.Text <> "" Then editingTextBox.Text = Format(CDec(editingTextBox.Text), "#,0.00")
            End Select
            editingTextBox = Nothing
        End If
    End Sub

    Private Sub dgvRebateCard_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvRebateCard.CellMouseUp
        If e.Button = Windows.Forms.MouseButtons.Right AndAlso e.ColumnIndex = 0 AndAlso Me.dgvRebateCard.ReadOnly = False AndAlso Me.dgvRebateCard("StartCardNo", e.RowIndex).Value.ToString <> "" Then
            blSkipDeal = True
            Me.dgvRebateCard("ChargedAMT", e.RowIndex).Selected = True
            Me.dgvRebateCard.CurrentRow.Selected = True
            blSkipDeal = False
            Me.cmenuDeleteRebateCard.Show(Control.MousePosition)
        End If
    End Sub

    Private Sub dgvRebateCard_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRebateCard.CellValueChanged
        If blSkipDeal Then Return
        blSkipDeal = True
        Dim sValue As String = Me.dgvRebateCard(e.ColumnIndex, e.RowIndex).Value.ToString, sFeature As String = Me.dgvRebateCard("CardFeature", e.RowIndex).Value.ToString, sNewFeature As String = "充值券", blIsPaperCard As Boolean = False
        If blCanUsePaperCard Then
            If sFeature = "条码卡" OrElse sFeature = "充值券" OrElse sFeature = "营销券" OrElse sFeature = "活动券" Then
                blIsPaperCard = True
            ElseIf sFeature = "" Then
                'modify code 050:start-------------------------------------------------------------------------
                'sFeature = "磁条卡"
                If sValue.IndexOf("2336" & frmMain.signCardBin) = 0 Then
                    sFeature = "实名制卡"
                Else
                    sFeature = "磁条卡"
                End If
                'modify code 050:end-------------------------------------------------------------------------
            End If
        ElseIf sFeature = "" Then
            'modify code 050:start-------------------------------------------------------------------------
            'sFeature = "磁条卡"
            If sValue.IndexOf("2336" & frmMain.signCardBin) = 0 Then
                sFeature = "实名制卡"
            Else
                sFeature = "磁条卡"
            End If
            'modify code 050:end-------------------------------------------------------------------------
        End If

        Call LockWindowUpdate(Me.dgvRebateCard.Handle)

        errorRebateCell = Nothing : sErrorRebateInfo = ""
        Select Case Me.dgvRebateCard.Columns(e.ColumnIndex).Name
            Case "StartCardNo"
                sNewFeature = Me.SetInputtingCardFeature(sValue)

                If sValue = "" OrElse Not IsNumeric(sValue) Then
                    If Me.dgvRebateCard("EndCardNo", e.RowIndex).Value.ToString = "" Then
                        Me.dgvRebateCard.EndEdit() : Me.dgvRebateCard("StartCardNo", e.RowIndex).Value = DBNull.Value
                        blSkipDeal = False : Call LockWindowUpdate(0) : Return
                    Else
                        Me.dgvRebateCard.EndEdit()
                        Me.dgvRebateCard("StartCardNo", e.RowIndex).Value = Me.dgvRebateCard("EndCardNo", e.RowIndex).Value
                        sValue = Me.dgvRebateCard("StartCardNo", e.RowIndex).Value.ToString
                    End If
                ElseIf sNewFeature = "" Then
                    If Me.IsValidCard(sValue) Then
                        sErrorRebateInfo = "卡类型未开通"
                        MessageBox.Show("卡类型未开通！    " & Chr(13) & Chr(13) & "请通知总部开通此卡类型。    ", "卡类型未开通！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        sErrorRebateInfo = "不可识别的卡类型"
                        MessageBox.Show("不可识别的卡类型！    " & Chr(13) & Chr(13) & "请检查卡号！    ", "不可识别的卡类型！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                ElseIf sNewFeature = "活动卡" OrElse sNewFeature = "活动券" Then
                    sErrorRebateInfo = sNewFeature & "不能出现在一般销售单中"
                    MessageBox.Show(sNewFeature & "不能出现在一般销售单中！    " & Chr(13) & Chr(13) & "请输入除活动卡" & IIf(blCanUsePaperCard, "（券）", "") & "之外的卡" & IIf(blCanUsePaperCard, "（券）", "") & "号。    ", sNewFeature & "不能出现在一般销售单中！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    'modify code 050:start-------------------------------------------------------------------------
                ElseIf frmSelling.bNewSalesBillType = 7 AndAlso sNewFeature <> "实名制卡" AndAlso sNewFeature <> "营销卡" AndAlso sNewFeature <> "营销券" Then
                    sErrorRebateInfo = "此卡不能出现在实名制卡销售单中"
                    MessageBox.Show("此卡不能出现在实名制卡销售单中！    " & Chr(13) & Chr(13) & "请输入实名制卡/营销卡/营销券。    ", sNewFeature & "不能出现在实名制卡销售单中！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    'modify code 050:end-------------------------------------------------------------------------
                    'modify code 054:start-------------------------------------------------------------------------
                ElseIf frmSelling.bNewSalesBillType = 8 AndAlso sValue.IndexOf("233665") <> 0 AndAlso sNewFeature <> "营销卡" AndAlso sNewFeature <> "营销券" Then
                    sErrorRebateInfo = "此卡不能出现在通卖非实名卡销售单中"
                    MessageBox.Show("此卡不能出现在通卖非实名卡销售单中！    " & Chr(13) & Chr(13) & "请输入通卖非实名卡/营销卡/营销券。    ", sNewFeature & "不能出现在通卖非实名卡销售单中！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf frmSelling.bNewSalesBillType = 0 AndAlso sValue.IndexOf("233665") = 0 Then
                    sErrorRebateInfo = "通卖非实名卡不能出现在一般销售单中"
                    MessageBox.Show("一般销售单中不能售卖通卖非实名卡！    " & Chr(13) & Chr(13) & "请输入磁条卡" & IIf(blCanUsePaperCard, "或条码卡", "") & "的卡号。    ", "通卖非实名卡不能出现在一般销售单中！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    'modify code 054:end-------------------------------------------------------------------------
                ElseIf blCanUse92Card AndAlso Me.chbPrintDiscount.Checked = False AndAlso sNewFeature <> "营销卡" AndAlso sNewFeature <> "营销券" Then
                    sErrorRebateInfo = "该卡不是营销卡" & IIf(blCanUsePaperCard, "或营销券", "")
                    MessageBox.Show("您已选择不在发票上打印折扣信息，所以只能用营销卡" & IIf(blCanUsePaperCard, "（券）", "") & "作为返点卡。但当前卡不是营销卡" & IIf(blCanUsePaperCard, "（券）", "") & "！    " & Chr(13) & Chr(13) & "如果想使用除营销卡之外的其它卡作为返点卡" & IIf(blCanUsePaperCard, "（券）", "") & "，请先勾选左边面版的""在发票上打印折扣信息""选项。    ", "不是营销卡" & IIf(blCanUsePaperCard, "（券）", "") & "不能当作返点卡！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf sNewFeature <> sFeature Then
                    sErrorRebateInfo = sNewFeature & "不能出现在" & sFeature & "行中"
                    MessageBox.Show("该行已被确定为" & sFeature & "行，不能容纳" & sNewFeature & "！    " & Chr(13) & Chr(13) & "请另起一行或删除该" & sFeature & "行再输入" & sNewFeature & "号。    ", sNewFeature & "不能出现在" & sFeature & "行中！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf blIsPaperCard Then
                    If sValue.Length < 17 Then
                        sErrorRebateInfo = sNewFeature & "号位数不足 17 位"
                        MessageBox.Show(sNewFeature & "号错误：位数不足 17 位！    " & Chr(13) & Chr(13) & "请重新输入" & sNewFeature.Substring(2, 1) & "号。    ", sNewFeature.Substring(2, 1) & "号输入错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf (sNewFeature <> "营销券" AndAlso sPaperCardBin.IndexOf(sValue.Substring(0, 5)) = -1) OrElse (sNewFeature = "营销券" AndAlso sFreeCardBin.IndexOf(sValue.Substring(0, 5)) = -1) Then
                        sErrorRebateInfo = sFeature & "的银商JV编号不符"
                        MessageBox.Show(sNewFeature & "号错误：银商JV编号不符！    " & Chr(13) & Chr(13) & sNewFeature & "号的前 5 位即为银商JV编号。    " & Chr(13) & Chr(13) & "系统设置的该店的银商JV编号是： " & IIf(sNewFeature = "营销券", sFreeCardBin, sPaperCardBin) & Space(4) & Chr(13) & "您输入的" & sNewFeature & "的银商JV编号是： " & sValue.Substring(0, 5) & Space(4) & Chr(13) & Chr(13) & "请重新输入" & sNewFeature & "号。    ", "银商JV编号不符！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Me.dgvRebateCard("EndCardNo", e.RowIndex).Value.ToString <> "" AndAlso sValue.Substring(0, 8) <> Me.dgvRebateCard("EndCardNo", e.RowIndex).Value.ToString.Substring(0, 8) Then
                        sErrorRebateInfo = sFeature & "的开始" & sFeature.Substring(2, 1) & "号与结束" & sFeature.Substring(2, 1) & "号的券类型不一致"
                        MessageBox.Show("同一行" & sNewFeature & "的开始" & sNewFeature.Substring(2, 1) & "号与结束" & sNewFeature.Substring(2, 1) & "号的券类型必须一致！    " & Chr(13) & Chr(13) & "（" & sNewFeature & "号的前 8 位即为券类型。）    " & Chr(13) & Chr(13) & "请重新输入" & sNewFeature & "号。    ", "券类型不一致！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Me.dgvRebateCard("FaceValue", e.RowIndex).Value.ToString = "" AndAlso dtPaperCardFaceValue.Rows.Find(sValue.Substring(0, 8)) Is Nothing Then
                        sErrorRebateInfo = "券类型不存在"
                        MessageBox.Show("当前" & sNewFeature & "的券类型""" & sValue.Substring(0, 8) & """不存在！    " & Chr(13) & Chr(13) & "（" & sNewFeature & "号的前 8 位即为券类型。）    " & Chr(13) & Chr(13) & "请重新输入" & sNewFeature & "号。    ", "券类型不存在！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Me.dgvRebateCard("EndCardNo", e.RowIndex).Value.ToString <> "" AndAlso Math.Abs(CLng(Me.dgvRebateCard("EndCardNo", e.RowIndex).Value.ToString) - CLng(sValue)) + 1 > 100000 Then
                        sErrorRebateInfo = "该行" & sFeature & "数量超过 100,000 张"
                        MessageBox.Show("每行的" & sNewFeature & "数量不能超过 100,000 张！    " & Chr(13) & Chr(13) & "请分成多行输入。    ", sErrorRebateInfo & "！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                    'modify code 051:start-------------------------------------------------------------------------
                ElseIf sValue.Length < 19 Then
                    sErrorRebateInfo = "卡号位数不足 19 位"
                    'MessageBox.Show(IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard, sNewFeature, "购物卡") & "号错误：位数不足 19 位！" & Space(4) & Chr(13) & Chr(13) & "请重新输入" & sNewFeature.Substring(2, 1) & "号。    ", sNewFeature.Substring(2, 1) & "号输入错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    MessageBox.Show(IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard OrElse blCanUse65Card, sNewFeature, "购物卡") & "号错误：位数不足 19 位！" & Space(4) & Chr(13) & Chr(13) & "请重新输入" & sNewFeature.Substring(2, 1) & "号。    ", sNewFeature.Substring(2, 1) & "号输入错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf (sNewFeature = "磁条卡" AndAlso sCULCardBin.IndexOf(sValue.Substring(4, 5)) = -1) OrElse (sNewFeature = "礼品卡" AndAlso sGiftCardBin.IndexOf(sValue.Substring(4, 5)) = -1) OrElse (sNewFeature = "营销卡" AndAlso sFreeCardBin.IndexOf(sValue.Substring(4, 5)) = -1) Then
                    'sErrorRebateInfo = IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard, sNewFeature, "购物卡") & "银商Bin码不符"
                    'MessageBox.Show("卡号错误：" & sErrorRebateInfo & "！    " & Chr(13) & Chr(13) & IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard, sNewFeature, "购物卡") & "银商Bin码即卡的第二段号码（第 5 至 9 位）。    " & Chr(13) & Chr(13) & "系统设置的该店的银商Bin码是： " & IIf(sNewFeature = "磁条卡", sCULCardBin, IIf(sNewFeature = "礼品卡", sGiftCardBin, sFreeCardBin)) & Space(4) & Chr(13) & "您输入的" & IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard, sNewFeature, "购物卡") & "的银商Bin码是： " & sValue.Substring(4, 5) & Space(4) & Chr(13) & Chr(13) & "请重新输入卡号。    ", sErrorRebateInfo & "！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    sErrorRebateInfo = IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard OrElse blCanUse65Card, sNewFeature, "购物卡") & "银商Bin码不符"
                    MessageBox.Show("卡号错误：" & sErrorRebateInfo & "！    " & Chr(13) & Chr(13) & IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard OrElse blCanUse65Card, sNewFeature, "购物卡") & "银商Bin码即卡的第二段号码（第 5 至 9 位）。    " & Chr(13) & Chr(13) & "系统设置的该店的银商Bin码是： " & IIf(sNewFeature = "磁条卡", sCULCardBin, IIf(sNewFeature = "礼品卡", sGiftCardBin, sFreeCardBin)) & Space(4) & Chr(13) & "您输入的" & IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard OrElse blCanUse65Card, sNewFeature, "购物卡") & "的银商Bin码是： " & sValue.Substring(4, 5) & Space(4) & Chr(13) & Chr(13) & "请重新输入卡号。    ", sErrorRebateInfo & "！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf sValue <> ShoppingCardNo.GetFullCardNo(sValue.Substring(0, 18)) Then
                    sErrorRebateInfo = "卡号校验码错误"
                    'MessageBox.Show("  " & IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard, sNewFeature, "购物卡") & "号错误：卡号校验码错误！    " & Chr(13) & Chr(13) & "（卡号的最后一位数字即为校验码。）    " & Chr(13) & Chr(13) & "  请重新输入" & sNewFeature.Substring(2, 1) & "号。    ", sNewFeature.Substring(2, 1) & "号输入错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    MessageBox.Show("  " & IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard OrElse blCanUse65Card, sNewFeature, "购物卡") & "号错误：卡号校验码错误！    " & Chr(13) & Chr(13) & "（卡号的最后一位数字即为校验码。）    " & Chr(13) & Chr(13) & "  请重新输入" & sNewFeature.Substring(2, 1) & "号。    ", sNewFeature.Substring(2, 1) & "号输入错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.dgvRebateCard("EndCardNo", e.RowIndex).Value.ToString <> "" AndAlso Math.Abs(CLng(Me.dgvRebateCard("EndCardNo", e.RowIndex).Value.ToString.Substring(0, 18)) - CLng(sValue.Substring(0, 18))) + 1 > 100000 Then
                    'sErrorRebateInfo = "该行" & IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard, sNewFeature, "购物卡") & "数量超过 100,000 张"
                    'MessageBox.Show("每行的" & IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard, sNewFeature, "购物卡") & "数量不能超过 100,000 张！    " & Chr(13) & Chr(13) & "请分成多行输入。    ", sErrorRebateInfo & "！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    sErrorRebateInfo = "该行" & IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard OrElse blCanUse65Card, sNewFeature, "购物卡") & "数量超过 100,000 张"
                    MessageBox.Show("每行的" & IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard OrElse blCanUse65Card, sNewFeature, "购物卡") & "数量不能超过 100,000 张！    " & Chr(13) & Chr(13) & "请分成多行输入。    ", sErrorRebateInfo & "！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
                'modify code 051:end-------------------------------------------------------------------------

                If sErrorRebateInfo = "" Then
                    Dim blGotoEndCardColumn As Boolean = False
                    If blIsPaperCard Then
                        If Me.dgvRebateCard("EndCardNo", e.RowIndex).Value.ToString = "" Then
                            Me.dgvRebateCard("EndCardNo", e.RowIndex).Value = sValue
                            blGotoEndCardColumn = True
                        End If
                        If Me.dgvRebateCard("FaceValue", e.RowIndex).Value.ToString = "" Then
                            Me.dgvRebateCard("FaceValue", e.RowIndex).Value = dtPaperCardFaceValue.Rows.Find(sValue.Substring(0, 8))("FaceValue")
                        End If

                        Me.ConfigRebatePaperCardRow()
                        If sErrorRebateInfo.IndexOf("不能同时既是正常卡又是返点卡") > -1 Then
                            If Me.dgvRebateCard("CardQTY", errorRebateCell.RowIndex).Value = 1 Then
                                MessageBox.Show("该张" & sFeature & "已经出现在当前销售单的正常卡列表中，所以不能当作返点卡使用！    " & Chr(13) & Chr(13) & "请重新输入" & sFeature & "号。    ", "同一张" & sFeature & "不能同时既是正常卡又是返点卡！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Else
                                MessageBox.Show("该行的部分" & sFeature & "已经出现在当前销售单的正常卡列表中，所以不能当作返点卡使用！    " & Chr(13) & Chr(13) & "请重新输入" & sFeature & "号。    ", "同一张" & sFeature & "不能同时既是正常卡又是返点卡！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            End If
                            frmMain.statusText.Text = "开始" & sFeature.Substring(2, 1) & "号错误（" & sErrorRebateInfo & "）！请重新输入开始" & sFeature.Substring(2, 1) & "号。"
                            Me.dgvRebateCard.Select() : Me.dgvRebateCard("EndCardNo", e.RowIndex).Selected = True : errorRebateCell.Selected = True
                        ElseIf blGotoEndCardColumn Then
                            Me.dgvRebateCard("EndCardNo", Me.dgvRebateCard.CurrentRow.Index).Selected = True
                        End If
                    Else
                        If Me.dgvRebateCard("EndCardNo", e.RowIndex).Value.ToString = "" Then
                            Me.dgvRebateCard("EndCardNo", e.RowIndex).Value = sValue
                            blGotoEndCardColumn = True
                        End If

                        If Me.dgvRebateCard("FaceValue", e.RowIndex).Value.ToString = "" AndAlso dtRebateCard.Select("'" & sValue & "'>=StartCardNo And '" & sValue & "'<=EndCardNo").Length > 0 Then
                            Me.dgvRebateCard("FaceValue", e.RowIndex).Value = dtRebateCard.Select("'" & sValue & "'>=StartCardNo And '" & sValue & "'<=EndCardNo")(0)("FaceValue")
                        End If

                        Me.ConfigRebateCardRow()
                        If blGotoEndCardColumn Then Me.dgvRebateCard("EndCardNo", Me.dgvRebateCard.CurrentRow.Index).Selected = True
                        If Me.dgvRebateCard("FaceValue", Me.dgvRebateCard.CurrentRow.Index).Value.ToString = "" Then
                            errorRebateCell = Me.dgvRebateCard("FaceValue", Me.dgvRebateCard.CurrentRow.Index)
                            sErrorRebateInfo = "面值不能为空"
                        End If
                    End If
                Else
                    errorRebateCell = Me.dgvRebateCard("StartCardNo", e.RowIndex)
                    If sNewFeature = "" Then sNewFeature = "磁条卡"
                    frmMain.statusText.Text = "开始" & sFeature.Substring(2, 1) & "号错误（" & sErrorRebateInfo & "）！请重新输入开始" & sFeature.Substring(2, 1) & "号。"
                    Me.dgvRebateCard.Select() : Me.dgvRebateCard("EndCardNo", e.RowIndex).Selected = True : errorRebateCell.Selected = True
                End If
            Case "EndCardNo"
                sNewFeature = Me.SetInputtingCardFeature(sValue)

                If sValue = "" OrElse Not IsNumeric(sValue) Then
                    If Me.dgvRebateCard("StartCardNo", e.RowIndex).Value.ToString <> "" Then
                        Me.dgvRebateCard.EndEdit()
                        Me.dgvRebateCard("EndCardNo", e.RowIndex).Value = Me.dgvRebateCard("StartCardNo", e.RowIndex).Value
                        sValue = Me.dgvRebateCard("EndCardNo", e.RowIndex).Value.ToString
                    Else
                        Me.dgvRebateCard.EndEdit() : Me.dgvRebateCard("EndCardNo", e.RowIndex).Value = DBNull.Value
                        blSkipDeal = False : Call LockWindowUpdate(0) : Return
                    End If
                ElseIf sNewFeature = "" Then
                    If Me.IsValidCard(sValue) Then
                        sErrorRebateInfo = "卡类型未开通"
                        MessageBox.Show("卡类型未开通！    " & Chr(13) & Chr(13) & "请通知总部开通此卡类型。    ", "卡类型未开通！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        sErrorRebateInfo = "不可识别的卡类型"
                        MessageBox.Show("不可识别的卡类型！    " & Chr(13) & Chr(13) & "请检查卡号！    ", "不可识别的卡类型！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                ElseIf sNewFeature = "活动卡" OrElse sNewFeature = "活动券" Then
                    sErrorRebateInfo = sNewFeature & "不能出现在一般销售单中"
                    MessageBox.Show(sNewFeature & "不能出现在一般销售单中！    " & Chr(13) & Chr(13) & "请输入除活动卡" & IIf(blCanUsePaperCard, "（券）", "") & "之外的卡" & IIf(blCanUsePaperCard, "（券）", "") & "号。    ", sNewFeature & "不能出现在一般销售单中！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    'modify code 050:start-------------------------------------------------------------------------
                ElseIf frmSelling.bNewSalesBillType = 7 AndAlso sNewFeature <> "实名制卡" AndAlso sNewFeature <> "营销卡" AndAlso sNewFeature <> "营销券" Then
                    sErrorRebateInfo = "此卡不能出现在实名制卡销售单中"
                    MessageBox.Show("此卡不能出现在实名制卡销售单中！    " & Chr(13) & Chr(13) & "请输入实名制卡/营销卡/营销券。    ", sNewFeature & "不能出现在实名制卡销售单中！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    'modify code 050:end-------------------------------------------------------------------------
                    'modify code 054:start-------------------------------------------------------------------------
                ElseIf frmSelling.bNewSalesBillType = 8 AndAlso sValue.IndexOf("233665") <> 0 AndAlso sNewFeature <> "营销卡" AndAlso sNewFeature <> "营销券" Then
                    sErrorRebateInfo = "此卡不能出现在通卖非实名卡销售单中"
                    MessageBox.Show("此卡不能出现在通卖非实名卡销售单中！    " & Chr(13) & Chr(13) & "请输入通卖非实名卡/营销卡/营销券。    ", sNewFeature & "不能出现在通卖非实名卡销售单中！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf frmSelling.bNewSalesBillType = 0 AndAlso sValue.IndexOf("233665") = 0 Then
                    sErrorRebateInfo = "通卖非实名卡不能出现在一般销售单中"
                    MessageBox.Show("一般销售单中不能售卖通卖非实名卡！    " & Chr(13) & Chr(13) & "请输入磁条卡" & IIf(blCanUsePaperCard, "或条码卡", "") & "的卡号。    ", "通卖非实名卡不能出现在一般销售单中！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    'modify code 054:end-------------------------------------------------------------------------
                ElseIf blCanUse92Card AndAlso Me.chbPrintDiscount.Checked = False AndAlso sNewFeature <> "营销卡" AndAlso sNewFeature <> "营销券" Then
                    sErrorRebateInfo = "该卡不是营销卡" & IIf(blCanUsePaperCard, "或营销券", "")
                    MessageBox.Show("您已选择不在发票上打印折扣信息，所以只能用营销卡" & IIf(blCanUsePaperCard, "（券）", "") & "作为返点卡。但当前卡不是营销卡" & IIf(blCanUsePaperCard, "（券）", "") & "！    " & Chr(13) & Chr(13) & "如果想使用除营销卡之外的其它卡作为返点卡" & IIf(blCanUsePaperCard, "（券）", "") & "，请先勾选左边面版的""在发票上打印折扣信息""选项。    ", "不是营销卡" & IIf(blCanUsePaperCard, "（券）", "") & "不能当作返点卡！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf sNewFeature <> sFeature Then
                    sErrorRebateInfo = sNewFeature & "不能出现在" & sFeature & "行中"
                    MessageBox.Show("该行已被确定为" & sFeature & "行，不能容纳" & sNewFeature & "！    " & Chr(13) & Chr(13) & "请另起一行或删除该" & sFeature & "行再输入" & sNewFeature & "号。    ", sNewFeature & "不能出现在" & sFeature & "行中！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf blIsPaperCard Then
                    If sValue.Length < 17 Then
                        sErrorRebateInfo = sNewFeature & "号位数不足 17 位"
                        MessageBox.Show(sNewFeature & "号错误：位数不足 17 位！    " & Chr(13) & Chr(13) & "请重新输入" & sNewFeature.Substring(2, 1) & "号。    ", sNewFeature.Substring(2, 1) & "号输入错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf (sNewFeature <> "营销券" AndAlso sPaperCardBin.IndexOf(sValue.Substring(0, 5)) = -1) OrElse (sNewFeature = "营销券" AndAlso sFreeCardBin.IndexOf(sValue.Substring(0, 5)) = -1) Then
                        sErrorRebateInfo = sFeature & "的银商JV编号不符"
                        MessageBox.Show(sNewFeature & "号错误：银商JV编号不符！    " & Chr(13) & Chr(13) & sNewFeature & "号的前 5 位即为银商JV编号。    " & Chr(13) & Chr(13) & "系统设置的该店的银商JV编号是： " & IIf(sNewFeature = "营销券", sFreeCardBin, sPaperCardBin) & Space(4) & Chr(13) & "您输入的" & sNewFeature & "的银商JV编号是： " & sValue.Substring(0, 5) & Space(4) & Chr(13) & Chr(13) & "请重新输入" & sNewFeature & "号。    ", "银商JV编号不符！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Me.dgvRebateCard("EndCardNo", e.RowIndex).Value.ToString <> "" AndAlso sValue.Substring(0, 8) <> Me.dgvRebateCard("EndCardNo", e.RowIndex).Value.ToString.Substring(0, 8) Then
                        sErrorRebateInfo = sFeature & "的结束" & sFeature.Substring(2, 1) & "号与开始" & sFeature.Substring(2, 1) & "号的券类型不一致"
                        MessageBox.Show("同一行" & sNewFeature & "的结束" & sNewFeature.Substring(2, 1) & "号与开始" & sNewFeature.Substring(2, 1) & "号的券类型必须一致！    " & Chr(13) & Chr(13) & "（" & sNewFeature & "号的前 8 位即为券类型。）    " & Chr(13) & Chr(13) & "请重新输入" & sNewFeature & "号。    ", "券类型不一致！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Math.Abs(CLng(Me.dgvRebateCard("StartCardNo", e.RowIndex).Value.ToString) - CLng(sValue)) + 1 > 100000 Then
                        sErrorRebateInfo = "该行" & sFeature & "数量超过 100,000 张"
                        MessageBox.Show("每行的" & sNewFeature & "数量不能超过 100,000 张！    " & Chr(13) & Chr(13) & "请分成多行输入。    ", sErrorRebateInfo & "！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                    'modify code 051:start-------------------------------------------------------------------------
                ElseIf sValue.Length < 19 Then
                    sErrorRebateInfo = "卡号位数不足 19 位"
                    'MessageBox.Show(IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard, sNewFeature, "购物卡") & "号错误：位数不足 19 位！" & Space(4) & Chr(13) & Chr(13) & "请重新输入" & sNewFeature.Substring(2, 1) & "号。    ", sNewFeature.Substring(2, 1) & "号输入错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    MessageBox.Show(IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard OrElse blCanUse65Card, sNewFeature, "购物卡") & "号错误：位数不足 19 位！" & Space(4) & Chr(13) & Chr(13) & "请重新输入" & sNewFeature.Substring(2, 1) & "号。    ", sNewFeature.Substring(2, 1) & "号输入错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf (sNewFeature = "磁条卡" AndAlso sCULCardBin.IndexOf(sValue.Substring(4, 5)) = -1) OrElse (sNewFeature = "礼品卡" AndAlso sGiftCardBin.IndexOf(sValue.Substring(4, 5)) = -1) OrElse (sNewFeature = "营销卡" AndAlso sFreeCardBin.IndexOf(sValue.Substring(4, 5)) = -1) Then
                    'sErrorRebateInfo = IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard, sNewFeature, "购物卡") & "银商Bin码不符"
                    'MessageBox.Show("卡号错误：" & sErrorRebateInfo & "！    " & Chr(13) & Chr(13) & IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard, sNewFeature, "购物卡") & "银商Bin码即卡的第二段号码（第 5 至 9 位）。    " & Chr(13) & Chr(13) & "系统设置的该店的银商Bin码是： " & IIf(sNewFeature = "磁条卡", sCULCardBin, IIf(sNewFeature = "礼品卡", sGiftCardBin, sFreeCardBin)) & Space(4) & Chr(13) & "您输入的" & IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard, sNewFeature, "购物卡") & "的银商Bin码是： " & sValue.Substring(4, 5) & Space(4) & Chr(13) & Chr(13) & "请重新输入卡号。    ", sErrorRebateInfo & "！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    sErrorRebateInfo = IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard OrElse blCanUse65Card, sNewFeature, "购物卡") & "银商Bin码不符"
                    MessageBox.Show("卡号错误：" & sErrorRebateInfo & "！    " & Chr(13) & Chr(13) & IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard OrElse blCanUse65Card, sNewFeature, "购物卡") & "银商Bin码即卡的第二段号码（第 5 至 9 位）。    " & Chr(13) & Chr(13) & "系统设置的该店的银商Bin码是： " & IIf(sNewFeature = "磁条卡", sCULCardBin, IIf(sNewFeature = "礼品卡", sGiftCardBin, sFreeCardBin)) & Space(4) & Chr(13) & "您输入的" & IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard OrElse blCanUse65Card, sNewFeature, "购物卡") & "的银商Bin码是： " & sValue.Substring(4, 5) & Space(4) & Chr(13) & Chr(13) & "请重新输入卡号。    ", sErrorRebateInfo & "！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf sValue <> ShoppingCardNo.GetFullCardNo(sValue.Substring(0, 18)) Then
                    sErrorRebateInfo = "卡号校验码错误"
                    'MessageBox.Show("  " & IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard, sNewFeature, "购物卡") & "号错误：卡号校验码错误！    " & Chr(13) & Chr(13) & "（卡号的最后一位数字即为校验码。）    " & Chr(13) & Chr(13) & "  请重新输入" & sNewFeature.Substring(2, 1) & "号。    ", sNewFeature.Substring(2, 1) & "号输入错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    MessageBox.Show("  " & IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard OrElse blCanUse65Card, sNewFeature, "购物卡") & "号错误：卡号校验码错误！    " & Chr(13) & Chr(13) & "（卡号的最后一位数字即为校验码。）    " & Chr(13) & Chr(13) & "  请重新输入" & sNewFeature.Substring(2, 1) & "号。    ", sNewFeature.Substring(2, 1) & "号输入错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Math.Abs(CLng(Me.dgvRebateCard("StartCardNo", e.RowIndex).Value.ToString.Substring(0, 18)) - CLng(sValue.Substring(0, 18))) + 1 > 100000 Then
                    'sErrorRebateInfo = "该行" & IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard, sNewFeature, "购物卡") & "数量超过 100,000 张"
                    'MessageBox.Show("每行的" & IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard, sNewFeature, "购物卡") & "数量不能超过 100,000 张！    " & Chr(13) & Chr(13) & "请分成多行输入。    ", sErrorRebateInfo & "！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    sErrorRebateInfo = "该行" & IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard OrElse blCanUse65Card, sNewFeature, "购物卡") & "数量超过 100,000 张"
                    MessageBox.Show("每行的" & IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard OrElse blCanUse65Card, sNewFeature, "购物卡") & "数量不能超过 100,000 张！    " & Chr(13) & Chr(13) & "请分成多行输入。    ", sErrorRebateInfo & "！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
                'modify code 051:end-------------------------------------------------------------------------

                If sErrorRebateInfo = "" Then
                    If blIsPaperCard Then
                        Me.ConfigRebatePaperCardRow()
                        If sErrorRebateInfo.IndexOf("不能同时既是正常卡又是返点卡") > -1 Then
                            If Me.dgvRebateCard("CardQTY", errorRebateCell.RowIndex).Value = 1 Then
                                MessageBox.Show("该张" & sFeature & "已经出现在当前销售单的正常卡列表中，所以不能当作返点卡使用！    " & Chr(13) & Chr(13) & "请重新输入" & sFeature & "号。    ", "同一张" & sFeature & "不能同时既是正常卡又是返点卡！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Else
                                MessageBox.Show("该行的部分" & sFeature & "已经出现在当前销售单的正常卡列表中，所以不能当作返点卡使用！    " & Chr(13) & Chr(13) & "请重新输入" & sFeature & "号。    ", "同一张" & sFeature & "不能同时既是正常卡又是返点卡！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            End If
                            frmMain.statusText.Text = "结束" & sFeature.Substring(2, 1) & "号错误（" & sErrorRebateInfo & "）！请重新输入结束" & sFeature.Substring(2, 1) & "号。"
                            Me.dgvRebateCard.Select() : Me.dgvRebateCard("StartCardNo", e.RowIndex).Selected = True : errorRebateCell.Selected = True
                        End If
                    Else
                        Me.ConfigRebateCardRow()
                    End If
                Else
                    errorRebateCell = Me.dgvRebateCard("EndCardNo", e.RowIndex)
                    If sNewFeature = "" Then sNewFeature = "磁条卡"
                    frmMain.statusText.Text = "结束" & sFeature.Substring(2, 1) & "号错误（" & sErrorRebateInfo & "）！请重新输入结束" & sFeature.Substring(2, 1) & "号。"
                    Me.dgvRebateCard.Select() : Me.dgvRebateCard("StartCardNo", e.RowIndex).Selected = True : errorRebateCell.Selected = True
                End If
            Case "CardQTY"
                If sValue = "" OrElse Not IsNumeric(sValue) Then
                    Me.dgvRebateCard.EndEdit()
                    If blIsPaperCard Then
                        Me.dgvRebateCard("CardQTY", e.RowIndex).Value = CLng(Me.dgvRebateCard("EndCardNo", e.RowIndex).Value.ToString) - CLng(Me.dgvRebateCard("StartCardNo", e.RowIndex).Value.ToString) + 1
                    Else
                        Me.dgvRebateCard("CardQTY", e.RowIndex).Value = CLng(Me.dgvRebateCard("EndCardNo", e.RowIndex).Value.ToString.Substring(0, 18)) - CLng(Me.dgvRebateCard("StartCardNo", e.RowIndex).Value.ToString.Substring(0, 18)) + 1
                    End If
                ElseIf CLng(sValue) > 100000 Then
                    'modify code 051:start-------------------------------------------------------------------------
                    'sErrorRebateInfo = "该行的" & IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard, sFeature, "购物卡") & "数量超过 100,000 张"
                    'MessageBox.Show("每行的" & IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard, sFeature, "购物卡") & "数量不能超过 100,000 张！" & Space(4) & Chr(13) & Chr(13) & "请分成多行输入。    ", sErrorRebateInfo & "！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    'frmMain.statusText.Text = "每行的" & IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard, sFeature, "购物卡") & "数量不能超过 100,000 张！请重新输入" & IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard, sFeature, "购物卡") & "数量。"
                    sErrorRebateInfo = "该行的" & IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard OrElse blCanUse65Card, sFeature, "购物卡") & "数量超过 100,000 张"
                    MessageBox.Show("每行的" & IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard OrElse blCanUse65Card, sFeature, "购物卡") & "数量不能超过 100,000 张！" & Space(4) & Chr(13) & Chr(13) & "请分成多行输入。    ", sErrorRebateInfo & "！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    frmMain.statusText.Text = "每行的" & IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard OrElse blCanUse65Card, sFeature, "购物卡") & "数量不能超过 100,000 张！请重新输入" & IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard OrElse blCanUse65Card, sFeature, "购物卡") & "数量。"
                    'modify code 051:end-------------------------------------------------------------------------
                    errorRebateCell = Me.dgvRebateCard("CardQTY", e.RowIndex)
                    Me.dgvRebateCard.Select() : Me.dgvRebateCard("StartCardNo", e.RowIndex).Selected = True : errorRebateCell.Selected = True
                ElseIf CInt(sValue) < 2 Then
                    blSkipDeal = False
                    Me.dgvRebateCard("EndCardNo", e.RowIndex).Value = Me.dgvRebateCard("StartCardNo", e.RowIndex).Value
                    Me.dgvRebateCard("CardQTY", e.RowIndex).Value = 1
                Else
                    blSkipDeal = False
                    If blIsPaperCard Then
                        Me.dgvRebateCard("EndCardNo", e.RowIndex).Value = (CLng(Me.dgvRebateCard("StartCardNo", e.RowIndex).Value.ToString) + CInt(sValue) - 1).ToString
                    Else
                        Me.dgvRebateCard("EndCardNo", e.RowIndex).Value = ShoppingCardNo.GetFullCardNo((CLng(Me.dgvRebateCard("StartCardNo", e.RowIndex).Value.ToString.Substring(0, 18)) + CInt(sValue) - 1).ToString)
                    End If
                End If
            Case "FaceValue"
                If sValue = "" OrElse Not IsNumeric(sValue) Then
                    sValue = ""
                    Me.dgvRebateCard.EndEdit()
                    Me.dgvRebateCard("FaceValue", e.RowIndex).Value = DBNull.Value
                End If

                Dim signCardNum As Integer = dtSignCardRangeAll.Select("CardNo>='" & dgvRebateCard("StartCardNo", e.RowIndex).Value.ToString & "' and CardNo<='" & dgvRebateCard("EndCardNo", e.RowIndex).Value.ToString & "'").Length

                If sValue = "" Then
                ElseIf CDec(sValue) = 0 Then
                    sErrorRebateInfo = "卡片面值不能为零"
                    'modify code 054:start-------------------------------------------------------------------------
                    'ElseIf signCardNum < dgvRebateCard("CardQTY", e.RowIndex).Value AndAlso CDec(sValue) > 1000 Then
                ElseIf dgvRebateCard("StartCardNo", e.RowIndex).Value.ToString.IndexOf("2336" & frmMain.signCardBin) < 0 AndAlso CDec(sValue) > 1000 Then
                    sErrorRebateInfo = "非实名制卡面值不能超过 1,000 元"
                    'ElseIf signCardNum = dgvRebateCard("CardQTY", e.RowIndex).Value AndAlso CDec(sValue) > 5000 Then
                ElseIf dgvRebateCard("StartCardNo", e.RowIndex).Value.ToString.IndexOf("2336" & frmMain.signCardBin) = 0 AndAlso CDec(sValue) > 5000 Then
                    'modify code 054:end-------------------------------------------------------------------------
                    sErrorRebateInfo = "实名制卡面值不能超过 5,000 元"
                End If

                If sErrorRebateInfo = "" Then
                    If sValue = "" Then
                        Me.dgvRebateCard("ChargedAMT", e.RowIndex).Value = DBNull.Value
                    Else
                        Me.dgvRebateCard("ChargedAMT", e.RowIndex).Value = Me.dgvRebateCard("FaceValue", e.RowIndex).Value * Me.dgvRebateCard("CardQTY", e.RowIndex).Value
                    End If
                    Me.CheckFaceValue()
                    If Me.dgvRebateCard("FaceValue", e.RowIndex).Equals(errorRebateCell) Then
                        'modify code 054:start-------------------------------------------------------------------------
                        'If signCardNum > 0 Then
                        If dgvRebateCard("StartCardNo", e.RowIndex).Value.ToString.IndexOf("2336" & frmMain.signCardBin) = 0 Then
                            'modify code 054:end-------------------------------------------------------------------------
                            MessageBox.Show("国家政策规定， 实名制卡最大面值不能超过 5,000 元。    " & Chr(13) & Chr(13) & sErrorRebateInfo.Replace("不能", "已经") & "！" & Space(4) & Chr(13) & Chr(13) & "请重新设置卡片面值。    ", "卡片面值超出许可范围！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            MessageBox.Show("国家政策规定， 非实名制卡最大面值不能超过 1,000 元。    " & Chr(13) & Chr(13) & sErrorRebateInfo.Replace("不能", "已经") & "！" & Space(4) & Chr(13) & Chr(13) & "请重新设置卡片面值。    ", "卡片面值超出许可范围！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If
                        frmMain.statusText.Text = sErrorRebateInfo & "！请重新设置卡片面值。"
                    Else
                        Me.UpdateNormalRebateInfo()
                        frmSelling.blCanRecheckCard = True
                        If frmCheckCardResult.IsHandleCreated AndAlso frmCheckCardResult.Visible = True Then
                            frmCheckCardResult.btnRecheck.Visible = True
                        End If
                    End If
                Else
                    errorRebateCell = Me.dgvRebateCard("FaceValue", e.RowIndex)
                    If sErrorRebateInfo.IndexOf("超过") > -1 Then MessageBox.Show(sErrorRebateInfo & "！" & Space(4) & Chr(13) & Chr(13) & "请重新设置卡片面值。    ", "卡片面值超出许可范围！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    frmMain.statusText.Text = sErrorRebateInfo & "！请重新设置卡片面值。"
                    Me.dgvRebateCard.Select() : Me.dgvRebateCard("EndCardNo", e.RowIndex).Selected = True : errorRebateCell.Selected = True
                End If
        End Select
        blSkipDeal = False
        For Each Column As DataGridViewColumn In Me.dgvRebateCard.Columns
            If Column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill Then
                Column.MinimumWidth = 2
                Column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Column.MinimumWidth = Column.Width
                Column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If
        Next
        Call LockWindowUpdate(0)
    End Sub

    Private Sub dgvRebateCard_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvRebateCard.DataError
        e.Cancel = True
    End Sub

    Private Sub dgvRebateCard_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvRebateCard.EditingControlShowing
        editingTextBox = CType(e.Control, TextBox)
        editingTextBox.ImeMode = Windows.Forms.ImeMode.Disable
        RemoveHandler editingTextBox.KeyDown, AddressOf CardNo_KeyDown
        RemoveHandler editingTextBox.KeyDown, AddressOf CardQTY_KeyDown
        RemoveHandler editingTextBox.KeyDown, AddressOf Money_KeyDown
        RemoveHandler editingTextBox.TextChanged, AddressOf editingTextBox_TextChanged
        Select Case Me.dgvRebateCard.Columns(Me.dgvRebateCard.CurrentCell.ColumnIndex).Name
            Case "StartCardNo", "EndCardNo"
                If "|条码卡|充值券|营销券|".IndexOf(Me.dgvRebateCard("CardFeature", Me.dgvRebateCard.CurrentCell.RowIndex).Value.ToString) > 0 Then
                    editingTextBox.MaxLength = 17
                Else
                    editingTextBox.MaxLength = 19
                End If
                AddHandler editingTextBox.KeyDown, AddressOf CardNo_KeyDown
            Case "CardQTY"
                editingTextBox.MaxLength = 6
                editingTextBox.Text = editingTextBox.Text.Replace(",", "")
                AddHandler editingTextBox.KeyDown, AddressOf CardQTY_KeyDown
            Case Else
                editingTextBox.MaxLength = 12
                editingTextBox.Text = editingTextBox.Text.Replace(",", "")
                AddHandler editingTextBox.KeyDown, AddressOf Money_KeyDown
        End Select
        AddHandler editingTextBox.TextChanged, AddressOf editingTextBox_TextChanged
    End Sub

    Private Sub dgvRebateCard_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvRebateCard.KeyDown
        If e.KeyCode = Keys.Delete AndAlso Me.dgvRebateCard.ReadOnly = False AndAlso Me.dgvRebateCard.CurrentRow.Selected = True Then
            Me.menuDeleteRebateCard.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub dgvRebateCard_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvRebateCard.Leave
        frmMain.statusText.Text = "就绪。"
        blSkipDeal = True
        If Me.dgvRebateCard.CurrentCell IsNot Nothing Then Me.dgvRebateCard.CurrentCell.Selected = False
        If Me.dgvRebateCard.CurrentRow IsNot Nothing Then Me.dgvRebateCard.CurrentRow.Selected = False
        blSkipDeal = False
    End Sub

    Private Sub dgvRebateCard_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvRebateCard.SelectionChanged
        If blSkipDeal OrElse Me.dgvRebateCard.CurrentCell Is Nothing Then Return
        blSkipDeal = True
        frmMain.statusText.Text = "就绪。"
        If Me.dgvRebateCard.CurrentCell.ColumnIndex = 0 Then
            Me.dgvRebateCard("ChargedAMT", Me.dgvRebateCard.CurrentRow.Index).Selected = True
            Me.dgvRebateCard.CurrentRow.Selected = True
            If Me.dgvRebateCard.ReadOnly = False AndAlso Me.dgvRebateCard("CardQTY", Me.dgvRebateCard.CurrentRow.Index).Value.ToString <> "" Then frmMain.statusText.Text = "提示：按<Delete>键可删除该行。"
        ElseIf errorRebateCell IsNot Nothing Then
            If errorRebateCell IsNot Me.dgvRebateCard.CurrentCell Then
                Dim sFeature As String = Me.dgvRebateCard("CardFeature", errorRebateCell.RowIndex).Value.ToString
                If sFeature = "" Then sFeature = "购物卡"
                Select Case Me.dgvRebateCard.Columns(errorRebateCell.ColumnIndex).Name
                    Case "StartCardNo"
                        errorRebateCell.Selected = True
                        Me.dgvRebateCard.BeginEdit(True)
                        frmMain.statusText.Text = "开始" & sFeature.Substring(2, 1) & "号错误（" & sErrorRebateInfo & "）！请重新输入开始" & sFeature.Substring(2, 1) & "号。"
                    Case "EndCardNo"
                        errorRebateCell.Selected = True
                        Me.dgvRebateCard.BeginEdit(True)
                        frmMain.statusText.Text = "结束" & sFeature.Substring(2, 1) & "号错误（" & sErrorRebateInfo & "）！请重新输入结束" & sFeature.Substring(2, 1) & "号。"
                    Case "CardQTY"
                        errorRebateCell.Selected = True
                        Me.dgvRebateCard.BeginEdit(True)
                        'modify code 051:start-------------------------------------------------------------------------
                        'frmMain.statusText.Text = "该行" & IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard, sFeature, "购物卡") & "数量超过 100,000 张！请重新输入" & IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard, sFeature, "购物卡") & "数量。"
                        frmMain.statusText.Text = "该行" & IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard OrElse blCanUse65Card, sFeature, "购物卡") & "数量超过 100,000 张！请重新输入" & IIf(blCanUse60Card OrElse blCanUse92Card OrElse blCanUse94Card OrElse blCanUsePaperCard OrElse blCanUse65Card, sFeature, "购物卡") & "数量。"
                        'modify code 051:end-------------------------------------------------------------------------
                    Case Else
                        errorRebateCell.Selected = True
                        Me.dgvRebateCard.BeginEdit(True)
                        frmMain.statusText.Text = sErrorRebateInfo & "！请重新设置面值。"
                End Select
            End If
        Else
            For Each drRebate As DataGridViewRow In Me.dgvRebateCard.Rows
                If drRebate.Index <> Me.dgvRebateCard.RowCount - 1 AndAlso drRebate.Index <> Me.dgvRebateCard.CurrentRow.Index AndAlso drRebate.Cells("FaceValue").Value.ToString = "" Then
                    Me.dgvRebateCard("FaceValue", drRebate.Index).Selected = True
                    Me.dgvRebateCard.BeginEdit(True)
                    frmMain.statusText.Text = "当前行的返点卡的面值未设置！请先设置该行返点卡的面值。"
                    blSkipDeal = False : Exit Sub
                End If
            Next

            If Me.dgvRebateCard("StartCardNo", Me.dgvRebateCard.CurrentRow.Index).Value.ToString = "" Then
                If Me.dgvRebateCard.Columns(Me.dgvRebateCard.CurrentCell.ColumnIndex).Name <> "StartCardNo" Then
                    Me.dgvRebateCard("StartCardNo", Me.dgvRebateCard.CurrentRow.Index).Selected = True
                    frmMain.statusText.Text = "请先输入开始卡号。"
                End If
            ElseIf Me.dgvRebateCard("EndCardNo", Me.dgvRebateCard.CurrentRow.Index).Value.ToString = "" Then
                If Me.dgvRebateCard.Columns(Me.dgvRebateCard.CurrentCell.ColumnIndex).Name <> "EndCardNo" Then
                    Me.dgvRebateCard("EndCardNo", Me.dgvRebateCard.CurrentRow.Index).Selected = True
                    frmMain.statusText.Text = "请先输入结束卡号。"
                End If
            ElseIf Me.dgvRebateCard.CurrentCell.ReadOnly = True Then
                Me.dgvRebateCard("ChargedAMT", Me.dgvRebateCard.CurrentRow.Index).Selected = True
                Me.dgvRebateCard.CurrentRow.Selected = True
                If Me.dgvRebateCard.ReadOnly = False Then frmMain.statusText.Text = "提示：按<Delete>键可删除该行。"
            ElseIf Me.dgvRebateCard.CurrentCell.ReadOnly = False Then
                Me.dgvRebateCard.BeginEdit(True)
            End If
        End If
        blSkipDeal = False
    End Sub

    Private Sub menuDeleteRebateCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuDeleteRebateCard.Click
        Dim blDeleted As Boolean = False
        blSkipDeal = True
        Dim iCurrentRow As Integer = Me.dgvRebateCard.CurrentRow.Index, drRebate As DataRow = dtRebateCard.Select("RowID=" & Me.dgvRebateCard("RowID", iCurrentRow).Value.ToString)(0)
        If errorRebateCell IsNot Nothing AndAlso errorRebateCell.RowIndex = iCurrentRow Then errorRebateCell = Nothing
        If iCurrentRow = Me.dgvRebateCard.RowCount - 1 Then
            If drRebate("StartCardNo").ToString <> "" Then
                drRebate.Delete()
                drRebate = dtRebateCard.Rows.Add(iCurrentRow + 1)
            End If
            blDeleted = True
        Else
            drRebate.Delete()
            For Each drRebate In dtRebateCard.Select("RowID>" & (iCurrentRow + 1))
                drRebate("RowID") = drRebate("RowID") - 1
            Next
            blDeleted = True
        End If
        If blDeleted Then
            Me.CheckFaceValue() : Me.CheckPaperCardExisting()
            If errorRebateCell Is Nothing Then Me.UpdateNormalRebateInfo()
            frmSelling.blCanRecheckCard = True
            If frmCheckCardResult.IsHandleCreated AndAlso frmCheckCardResult.Visible = True Then
                frmCheckCardResult.btnRecheck.Visible = True
            End If
        End If
        If iCurrentRow > Me.dgvRebateCard.RowCount - 1 Then iCurrentRow = Me.dgvRebateCard.RowCount - 1
        If Me.dgvRebateCard("StartCardNo", iCurrentRow).Value.ToString = "" Then
            Me.dgvRebateCard("StartCardNo", iCurrentRow).Selected = True
            Me.dgvRebateCard.BeginEdit(True)
            frmMain.statusText.Text = "就绪。"
        Else
            Me.dgvRebateCard("ChargedAMT", iCurrentRow).Selected = True : Me.dgvRebateCard.CurrentRow.Selected = True
        End If
        Me.dgvRebateCard.Columns("CardFeature").Visible = (dtRebateCard.Select("Isnull(CardFeature,'磁条卡')<>'磁条卡'").Length > 0)
        blSkipDeal = False
    End Sub

    Private Sub btnShowResult_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowResult.Click
        If Me.btnShowResult.Text.IndexOf("显示") > -1 Then
            With frmCheckCardResult
                .blWhenModifyRebate = True
                .blCanUse60Card = blCanUse60Card
                .blCanUse92Card = blCanUse92Card
                .blCanUse94Card = blCanUse94Card
                .blCanUsePaperCard = blCanUsePaperCard
                'modify code 051:start-------------------------------------------------------------------------
                .blCanUse65Card = blCanUse65Card
                'modify code 051:end-------------------------------------------------------------------------
                .Text = "上次购物卡可用状态检查结果"
                .Show()
            End With
            Me.btnShowResult.Text = "隐藏检查结果(&R)"
        Else
            If frmCheckCardResult.IsHandleCreated AndAlso frmCheckCardResult.Visible Then frmCheckCardResult.Close()
            If frmSelling.dtLastCheckingProblemCard.Rows.Count > 0 AndAlso frmSelling.dtLastCheckingProblemCard.Select("UsageState='可以售卖'").Length = 0 Then
                Me.btnShowResult.Text = "显示检查结果(&R)"
            Else
                Me.btnShowResult.Visible = False
            End If
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If errorRebateCell IsNot Nothing Then
            MessageBox.Show("返点卡列表中存在错误！请先修改错误，然后再保存。    ", "不能保存。", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.dgvRebateCard.Select()
            blSkipDeal = True
            Me.dgvRebateCard("ChargedAMT", errorRebateCell.RowIndex).Selected = True
            blSkipDeal = False
            errorRebateCell.Selected = True
            Me.btnOK.Enabled = False
            Return
        End If

        For Each drRebate As DataGridViewRow In Me.dgvRebateCard.Rows
            If drRebate.Cells("StartCardNo").Value.ToString <> "" AndAlso drRebate.Cells("FaceValue").Value.ToString = "" Then
                MessageBox.Show("不能保存销售单，因为有一行返点卡的面值未设置！    " & Chr(13) & Chr(13) & "请设置该行返点卡的面值。    ", "不能保存销售单！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.dgvRebateCard.Select()
                Me.dgvRebateCard("FaceValue", drRebate.Index).Selected = True
                frmMain.statusText.Text = "不能保存合同，因为有一行返点卡的面值未设置！请设置该行返点卡的面值。"
                Me.btnOK.Enabled = False
                Return
            End If
        Next

        If dmRebateSalesAMT <> dmAvailableRebateAMT Then
            Dim sFormattedValue1 As String, sFormattedValue2 As String, sFormattedValue3 As String
            If dmRebateSalesAMT = 0 Then
                'modify code 038:start-------------------------------------------------------------------------
                'sFormattedValue1 = Format(dmAvailableRebateRate * 100, "#,0.0") & "  %    " : sFormattedValue2 = Format(dmAvailableRebateAMT, "#,0.00") & " 元    "
                sFormattedValue1 = Format(dmAvailableRebateRate * 100, "#,0.00") & "  %    " : sFormattedValue2 = Format(dmAvailableRebateAMT, "#,0.00") & " 元    "
                'modify code 038:end-------------------------------------------------------------------------
                If sFormattedValue1.Length < sFormattedValue2.Length Then sFormattedValue1 = Space(sFormattedValue2.Length - sFormattedValue1.Length) & sFormattedValue1
                MessageBox.Show("您已指定返点，但还没有分配返点卡。    " & Chr(13) & Chr(13) & "已指定的返点比率： " & sFormattedValue1 & Chr(13) & "已指定的返点金额： " & sFormattedValue2 & Chr(13) & Chr(13) & "请您分配返点卡，或者取消该单的返点。    ", "还未分配返点卡！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                frmMain.statusText.Text = "未确认，因为您还未分配返点卡！"
            ElseIf dmRebateSalesAMT < dmAvailableRebateAMT Then
                sFormattedValue1 = Format(dmAvailableRebateAMT, "#,0.00") & " 元    " : sFormattedValue2 = Format(dmRebateSalesAMT, "#,0.00") & " 元    " : sFormattedValue3 = Format(dmAvailableRebateAMT - dmRebateSalesAMT, "#,0.00") & " 元    "
                If sFormattedValue2.Length < sFormattedValue1.Length Then sFormattedValue2 = Space(sFormattedValue1.Length - sFormattedValue2.Length) & sFormattedValue2
                If sFormattedValue3.Length < sFormattedValue1.Length Then sFormattedValue3 = Space(sFormattedValue1.Length - sFormattedValue3.Length) & sFormattedValue3
                MessageBox.Show("已分配的返点金额未达到您指定的返点金额。    " & Chr(13) & Chr(13) & "已指定的返点金额： " & sFormattedValue1 & Chr(13) & "已分配的返点金额： " & sFormattedValue2 & Chr(13) & "待分配的返点金额： " & sFormattedValue3 & Chr(13) & Chr(13) & "请您继续分配返点卡，或者减少指定的返点金额。    ", "已分配的返点金额不足！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                frmMain.statusText.Text = "未确认，因为已分配的返点金额不足！"
            Else
                sFormattedValue1 = Format(dmAvailableRebateAMT, "#,0.00") & " 元    " : sFormattedValue2 = Format(dmRebateSalesAMT, "#,0.00") & " 元    " : sFormattedValue3 = Format(dmRebateSalesAMT - dmAvailableRebateAMT, "#,0.00") & " 元    "
                If sFormattedValue1.Length < sFormattedValue2.Length Then sFormattedValue1 = Space(sFormattedValue2.Length - sFormattedValue1.Length) & sFormattedValue1
                If sFormattedValue3.Length < sFormattedValue2.Length Then sFormattedValue3 = Space(sFormattedValue2.Length - sFormattedValue3.Length) & sFormattedValue3
                MessageBox.Show("已分配的返点金额超出您指定的返点金额。    " & Chr(13) & Chr(13) & "已指定的返点金额： " & sFormattedValue1 & Chr(13) & "已分配的返点金额： " & sFormattedValue2 & Chr(13) & "已超出的返点金额： " & sFormattedValue3 & Chr(13) & Chr(13) & "请您减少返点卡的充值金额，或者增加指定的返点金额。    ", "已分配的返点金额过多！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                frmMain.statusText.Text = "未确认，因为已分配的返点金额超出指定的返点金额！"
            End If
            Me.txbNormalRebateAMT.Select() : Me.txbNormalRebateAMT.SelectAll()
            Me.btnOK.Enabled = False
            Return
        End If

        If dmAvailableRebateAMT = 0 Then
            If MessageBox.Show("注意：您即将取消当前销售单的所有返点！一旦确认，便不再可修改！    " & Chr(13) & Chr(13) & "您是否确认取消当前销售单的所有返点？    ", "请确认取消返点：", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then Return
        ElseIf dmAvailableRebateAMT <= dmMaxNormalRebateAMT Then
            If MessageBox.Show("注意：修改过后的返点已经处在所在城市的标准范围之内（不再需要审核），一旦确认，便不再可修改！    " & Chr(13) & Chr(13) & "您是否确认您所做的修改？    ", "请确认修改返点：", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then Return
        Else
            If MessageBox.Show("注意：修改过后的返点仍然超出所在城市的标准范围，需要重新审核！    " & Chr(13) & Chr(13) & "您是否确认您所做的修改？    ", "请确认修改返点：", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then Return
        End If
        Me.Refresh()

        Me.Refresh()
        Me.Cursor = Cursors.WaitCursor
        Dim sTask As String = IIf(My.Settings.IsInTraining OrElse dmAvailableRebateAMT = 0, "保存对销售单城市返点的修改", "检查购物卡的可用状态")
        frmMain.statusText.Text = "正在" & sTask & "……"
        frmMain.statusMain.Refresh()
        Dim DB As New DataBase, dtResult As DataTable
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法" & sTask & "。请检查数据库连接。"
            Me.Cursor = Cursors.Default : Return
        End If

        If dmAvailableRebateAMT > 0 Then
            Dim dtTempCard As New DataTable, drTempCard As DataRow, sCardNo As String, iRowCardQTY As Integer, blNeedCheckCard As Boolean = (Not My.Settings.IsInTraining) '培训模式不必检查卡状态
            dtTempCard.Columns.Add("SalesBillDetailID", System.Type.GetType("System.Int32"))
            dtTempCard.Columns.Add("CardNo", System.Type.GetType("System.String"))
            dtTempCard.Columns.Add("FaceValue", System.Type.GetType("System.Decimal"))
            dtTempCard.Columns.Add("CardType", System.Type.GetType("System.Byte"))
            dtTempCard.Columns.Add("RowType", System.Type.GetType("System.Byte"))
            dtTempCard.Columns.Add("RowID", System.Type.GetType("System.Int16"))

            For Each drRebate As DataRow In dtRebateCard.Select("Isnull(StartCardNo,'')<>''", "RowID")
                sCardNo = drRebate("StartCardNo").ToString
                If sCardNo.IndexOf("2") = 0 Then sCardNo = sCardNo.Substring(0, 18)
                iRowCardQTY = drRebate("CardQTY") - 1
                For iCard As Integer = 0 To iRowCardQTY
                    drTempCard = dtTempCard.Rows.Add()
                    If sCardNo.IndexOf("2") = 0 Then
                        drTempCard("CardNo") = ShoppingCardNo.GetFullCardNo((CLng(sCardNo) + iCard).ToString)
                    Else
                        drTempCard("CardNo") = (CLng(sCardNo) + iCard).ToString
                    End If
                    drTempCard("FaceValue") = drRebate("FaceValue")
                    drTempCard("RowType") = 2
                    drTempCard("RowID") = drRebate("RowID")
                Next
            Next

            If frmSelling.dtAllCheckedCard IsNot Nothing AndAlso frmSelling.dtAllCheckedCard.Rows.Count > 0 Then '如果曾经检查过卡使用状态
                Dim drCheckedCard As DataRow, drProblemCard As DataRow, drNormalCard As DataRow, dmNormalValue As Decimal
                blNeedCheckCard = False
                frmSelling.dtLastCheckingProblemCard.Rows.Clear()
                Dim maxFaceValue As Integer
                For Each drTempCard In dtTempCard.Select("", "RowType,RowID,CardNo")
                    sCardNo = drTempCard("CardNo").ToString

                    'modify code 054:start-------------------------------------------------------------------------
                    'If dtSignCardRangeAll.Select("CardNo='" & sCardNo & "'").Length > 0 Then
                    If sCardNo.IndexOf("2336" & frmMain.signCardBin) = 0 Then
                        'modify code 054:end-------------------------------------------------------------------------
                        maxFaceValue = 5000
                    Else
                        maxFaceValue = 1000
                    End If

                    drCheckedCard = frmSelling.dtAllCheckedCard.Rows.Find(sCardNo)
                    drNormalCard = dtOriginalNormal.Rows.Find(sCardNo)
                    If drNormalCard Is Nothing Then dmNormalValue = 0 Else dmNormalValue = drNormalCard("FaceValue")
                    If drCheckedCard Is Nothing Then
                        blNeedCheckCard = True '如果当前准备充值的卡不出现在针对该销售单的检查结果中，说明该卡未被检查，需要重新检查所有卡的状态
                    ElseIf (drCheckedCard("UsageState") > 0) OrElse _
                           (drCheckedCard("CardType") = 2 AndAlso dmNormalValue + drTempCard("FaceValue") + drCheckedCard("Balance") > maxFaceValue) Then
                        '该卡不可充值（如该卡已被充值、所在销售单等待取消、等待撤销充值、等待回收、等待换卡、冻结、结束或需要到银商系统查询状态等原因）
                        '或者该卡是顾客的再充值卡且状态正确，但存在余额，并且加上本次的充值金额后已超过1000元（实名制卡5000元）
                        drProblemCard = frmSelling.dtLastCheckingProblemCard.Rows.Add()
                        If drNormalCard Is Nothing Then
                            drProblemCard("RowType") = Me.SetCardFeature(sCardNo)
                            drProblemCard("RowID") = drTempCard("RowID").ToString
                        Else
                            drProblemCard("RowType") = "正常卡＋返点卡"
                            drProblemCard("RowID") = drNormalCard("RowID") & "+" & drTempCard("RowID").ToString
                        End If
                        drProblemCard("CardNo") = sCardNo
                        drProblemCard("FaceValue") = dmNormalValue + drTempCard("FaceValue")
                        If drCheckedCard("UsageState") = 9 Then
                            drProblemCard("UsageState") = "（未知）" '上次到银商查询时失败
                        ElseIf drCheckedCard("UsageState") > 0 Then
                            drProblemCard("UsageState") = "不可售卖"
                        Else
                            drProblemCard("UsageState") = "面值受限"
                        End If
                        drProblemCard("UnchargableReason") = drCheckedCard("UnchargableReason").ToString
                        drProblemCard("Operation") = "拷贝卡号"
                    Else 'drCheckedCard("UsageState") = 0, 可售卖
                        drTempCard("CardType") = drCheckedCard("CardType") '0 - 新卡; 1 - 回收卡; 2 - 再充值卡（顾客自带）
                        If (DateDiff(DateInterval.Minute, Now(), CDate(frmSelling.sFirstCheckCardTime)) > 15) Then blNeedCheckCard = True : frmSelling.sFirstCheckCardTime = "" '如果该单第一次查询的时间已超过15分钟，则所有的卡都必须再查一遍
                    End If
                Next
                frmSelling.dtLastCheckingProblemCard.AcceptChanges()

                If frmSelling.dtLastCheckingProblemCard.Rows.Count > 0 Then '如果目前卡列表中存在不可充值的卡
                    With frmCheckCardResult
                        .blWhenModifyRebate = True
                        .blCanUse60Card = blCanUse60Card
                        .blCanUse92Card = blCanUse92Card
                        .blCanUse94Card = blCanUse94Card
                        .blCanUsePaperCard = blCanUsePaperCard
                        'modify code 051:start-------------------------------------------------------------------------
                        .blCanUse65Card = blCanUse65Card
                        'modify code 051:end-------------------------------------------------------------------------
                        .Text = "上次购物卡可用状态检查结果"
                        .Show()
                    End With
                    Me.btnShowResult.Text = "隐藏检查结果(&R)" : Me.btnShowResult.Visible = True
                    Dim sError As String = ""
                    If frmSelling.dtLastCheckingProblemCard.Select("UsageState='不可售卖'").Length > 0 Then sError = "不可售卖、"
                    If frmSelling.dtLastCheckingProblemCard.Select("UsageState='面值受限'").Length > 0 Then sError = sError & "面值受限、"
                    If frmSelling.dtLastCheckingProblemCard.Select("UsageState='（未知）'").Length > 0 Then sError = sError & "可用状态不明确、"
                    sError = sError.Substring(0, sError.Length - 1)
                    If sError.LastIndexOf("、") > -1 Then sError = sError.Insert(sError.LastIndexOf("、"), "、").Replace("、、", "或")
                    frmMain.statusText.Text = "充值列表中存在" & sError & "的卡片，所以不能保存对销售单城市返点的修改！"
                    dtTempCard.Dispose() : dtTempCard = Nothing
                    DB.Close() : Me.Cursor = Cursors.Default : Return
                Else
                    Me.btnShowResult.Visible = False
                End If
            End If

            If DB.ModifyTable("Select Convert(int,0) As SalesBillDetailID,Convert(varchar(19),CardNo) As CardNo,FaceValue,CardType,Convert(tinyint,0) As RowType, Convert(smallint,0) As RowID Into #tempCard From PendingActivationList Where 1=2") = -1 OrElse DB.BulkCopyTable("#tempCard", dtTempCard) = -1 Then
                frmMain.statusText.Text = sTask & "失败！"
                dtTempCard.Dispose() : dtTempCard = Nothing
                DB.Close() : Me.Cursor = Cursors.Default : Return
            End If

            If blNeedCheckCard Then
                dtResult = DB.GetDataTable("Exec SalesBillCheckCardState")
                If dtResult Is Nothing Then
                    frmMain.statusText.Text = "检查购物卡的使用状态失败！"
                    DB.Close() : Me.Cursor = Cursors.Default : Return
                End If

                Dim drCheckedCard As DataRow, drProblemCard As DataRow, drNormalCard As DataRow, dmNormalValue As Decimal
                '将本次检查结果保存到frmselling.dtAllCheckedCard，以避免对同一张单相同卡号进行再次检查
                For Each drCard As DataRow In dtResult.Select("UsageState=1")
                    sCardNo = drCard("CardNo").ToString
                    If dtOriginalNormal.Rows.Find(sCardNo) IsNot Nothing OrElse dtOriginalRebate.Rows.Find(sCardNo) IsNot Nothing Then
                        drCard("UsageState") = 0 : drCard("UnchargableReason") = DBNull.Value : drCard.AcceptChanges()
                    End If
                Next
                If frmSelling.dtAllCheckedCard Is Nothing OrElse frmSelling.dtAllCheckedCard.Rows.Count = 0 Then
                    frmSelling.dtAllCheckedCard = dtResult.Copy
                    frmSelling.dtAllCheckedCard.PrimaryKey = New DataColumn() {frmSelling.dtAllCheckedCard.Columns("CardNo")}
                Else
                    For Each drCard As DataRow In dtResult.Select("CardType=2") '如果再充值卡在上一次的检查中已存在，无须到CUL再检查，以节省时间
                        drCheckedCard = frmSelling.dtAllCheckedCard.Rows.Find(drCard("CardNo").ToString)
                        If drCheckedCard IsNot Nothing AndAlso drCheckedCard("CardType") = 2 Then
                            drCard("UsageState") = drCheckedCard("UsageState")
                            drCard("Balance") = drCheckedCard("Balance")
                            drCard("UnchargableReason") = drCheckedCard("UnchargableReason")
                            drCard.EndEdit() : drCard.AcceptChanges()
                        End If
                    Next
                    frmSelling.dtAllCheckedCard.Merge(dtResult.Copy, False)
                End If
                dtResult.Dispose() : dtResult = Nothing
                frmSelling.blCanRecheckCard = False
                If frmSelling.sFirstCheckCardTime = "" Then frmSelling.sFirstCheckCardTime = Format(Now(), "yyyy\/MM\/dd HH:mm:ss")

                frmSelling.blNeedReloadCard = False
                If frmSelling.dtAllCheckedCard.Select("UsageState=9").Length > 0 Then '如果存在状态不明确需要到银商系统查询状态的卡
                    frmCheckCardFromCUL.ShowDialog()
                    frmCheckCardFromCUL.Dispose()
                    Me.Refresh()
                End If

                If frmSelling.dtLastCheckingProblemCard Is Nothing Then
                    frmSelling.dtLastCheckingProblemCard = New DataTable
                    frmSelling.dtLastCheckingProblemCard.Columns.Add("RowType", System.Type.GetType("System.String"))
                    frmSelling.dtLastCheckingProblemCard.Columns.Add("RowID", System.Type.GetType("System.String"))
                    frmSelling.dtLastCheckingProblemCard.Columns.Add("CardNo", System.Type.GetType("System.String"))
                    frmSelling.dtLastCheckingProblemCard.Columns.Add("FaceValue", System.Type.GetType("System.Decimal"))
                    frmSelling.dtLastCheckingProblemCard.Columns.Add("UsageState", System.Type.GetType("System.String"))
                    frmSelling.dtLastCheckingProblemCard.Columns.Add("UnchargableReason", System.Type.GetType("System.String"))
                    frmSelling.dtLastCheckingProblemCard.Columns.Add("Operation", System.Type.GetType("System.String"))
                    frmSelling.dtLastCheckingProblemCard.PrimaryKey = New DataColumn() {frmSelling.dtLastCheckingProblemCard.Columns("CardNo")}
                    frmSelling.dtLastCheckingProblemCard.Columns("CardNo").AllowDBNull = True
                Else
                    frmSelling.dtLastCheckingProblemCard.Rows.Clear()
                End If

                If frmSelling.dtAllCheckedCard.Select("CardType=2 Or UsageState>0").Length > 0 Then '如果检查结果中包含再充值卡或当次不可充值的卡，需要检查当前充值列表是否存在问题卡
                    Dim maxFaceValue As Integer
                    For Each drTempCard In dtTempCard.Select("", "RowType,RowID,CardNo")
                        sCardNo = drTempCard("CardNo").ToString

                        'modify code 054:start-------------------------------------------------------------------------
                        'If dtSignCardRangeAll.Select("CardNo='" & sCardNo & "'").Length > 0 Then
                        If sCardNo.IndexOf("2336" & frmMain.signCardBin) = 0 Then
                            'modify code 054:end-------------------------------------------------------------------------
                            maxFaceValue = 5000
                        Else
                            maxFaceValue = 1000
                        End If

                        drCheckedCard = frmSelling.dtAllCheckedCard.Rows.Find(sCardNo)
                        drNormalCard = dtOriginalNormal.Rows.Find(sCardNo)
                        If drNormalCard Is Nothing Then dmNormalValue = 0 Else dmNormalValue = drNormalCard("FaceValue")
                        If (drCheckedCard("UsageState") > 0) OrElse _
                           (drCheckedCard("CardType") = 2 AndAlso dmNormalValue + drTempCard("FaceValue") + drCheckedCard("Balance") > maxFaceValue) Then
                            '该卡不可充值（如该卡已被充值、所在销售单等待取消、等待撤销充值、等待回收、等待换卡、冻结、结束或需要到银商系统查询状态等原因）
                            '或者该卡是顾客的再充值卡但未查询过卡状态及余额（需要查询）：UsageState = 9
                            '或者该卡是顾客的再充值卡且状态正确，但存在余额，并且加上本次的充值金额后已超过1000元（实名制卡5000元）
                            drProblemCard = frmSelling.dtLastCheckingProblemCard.Rows.Add()
                            If drNormalCard Is Nothing Then
                                drProblemCard("RowType") = Me.SetCardFeature(sCardNo)
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
                frmSelling.dtLastCheckingProblemCard.AcceptChanges()

                If frmSelling.dtLastCheckingProblemCard.Rows.Count > 0 Then '如果目前卡列表中存在不可充值的卡
                    With frmCheckCardResult
                        .blWhenModifyRebate = True
                        .blCanUse60Card = blCanUse60Card
                        .blCanUse92Card = blCanUse92Card
                        .blCanUse94Card = blCanUse94Card
                        .blCanUsePaperCard = blCanUsePaperCard
                        'modify code 051:start-------------------------------------------------------------------------
                        .blCanUse65Card = blCanUse65Card
                        'modify code 051:end-------------------------------------------------------------------------
                        .Text = "上次购物卡可用状态检查结果"
                        .Show()
                    End With
                    Me.btnShowResult.Text = "隐藏检查结果(&R)" : Me.btnShowResult.Visible = True
                    Dim sError As String = ""
                    If frmSelling.dtLastCheckingProblemCard.Select("UsageState='不可售卖'").Length > 0 Then sError = "不可售卖、"
                    If frmSelling.dtLastCheckingProblemCard.Select("UsageState='面值受限'").Length > 0 Then sError = sError & "面值受限、"
                    If frmSelling.dtLastCheckingProblemCard.Select("UsageState='（未知）'").Length > 0 Then sError = sError & "可用状态不明确、"
                    sError = sError.Substring(0, sError.Length - 1)
                    If sError.LastIndexOf("、") > -1 Then sError = sError.Insert(sError.LastIndexOf("、"), "、").Replace("、、", "或")
                    frmMain.statusText.Text = "充值列表中存在" & sError & "的卡片，所以不能保存对销售单城市返点的修改！"
                    dtTempCard.Dispose() : dtTempCard = Nothing
                    DB.Close() : Me.Cursor = Cursors.Default : Return
                End If

                If frmSelling.blNeedReloadCard Then
                    For Each drTempCard In dtTempCard.Rows
                        drCheckedCard = frmSelling.dtAllCheckedCard.Rows.Find(drTempCard("CardNo").ToString)
                        drTempCard("CardType") = drCheckedCard("CardType")
                    Next

                    If DB.ModifyTable("Delete From #tempCard") = -1 OrElse DB.BulkCopyTable("#tempCard", dtTempCard) = -1 Then
                        frmMain.statusText.Text = "保存对销售单城市返点的修改失败！"
                        dtTempCard.Dispose() : dtTempCard = Nothing
                        DB.Close() : Me.Cursor = Cursors.Default : Return
                    End If
                End If
            End If
            dtTempCard.Dispose() : dtTempCard = Nothing
        End If

        frmMain.statusText.Text = "正在保存对销售单城市返点的修改……"
        frmMain.statusMain.Refresh()

        Dim iCardQTY As Integer = 0
        If iRebateCardQTY = 0 Then
            iCardQTY = frmSelling.drSalesBill("NormalCardQTY")
        ElseIf frmSelling.drSalesBill("NormalCardQTY") = 0 Then
            iCardQTY = iRebateCardQTY
        Else
            Dim dtCard As DataTable = dtOriginalNormal.DefaultView.ToTable("CardNo"), sCardNo As String = ""
            dtCard.PrimaryKey = New DataColumn() {dtCard.Columns("CardNo")}
            For iRow As Int16 = 0 To Me.dgvRebateCard.RowCount - 2
                sCardNo = Me.dgvRebateCard("StartCardNo", iRow).Value.ToString
                If sCardNo.IndexOf("2") = 0 Then sCardNo = sCardNo.Substring(0, 18)
                For iCard As Int16 = 0 To Me.dgvRebateCard("CardQTY", iRow).Value - 1
                    Try
                        If sCardNo.IndexOf("2") = 0 Then
                            dtCard.Rows.Add(ShoppingCardNo.GetFullCardNo((CLng(sCardNo) + iCard).ToString))
                        Else
                            dtCard.Rows.Add((CLng(sCardNo) + iCard).ToString)
                        End If
                    Catch
                    End Try
                Next
            Next
            dtCard.AcceptChanges()
            iCardQTY = dtCard.Rows.Count
            dtCard.Dispose() : dtCard = Nothing
        End If

        Dim sSQL As String = "Exec ModifyNormalRebate @SalesBillID=" & frmSelling.sSalesBillID & ",@CardQTY=" & iCardQTY.ToString & ","

        If dmAvailableRebateAMT > 0 Then
            If DB.ModifyTable("Select RowID,StartCardNo,EndCardNo,CardQTY,FaceValue Into #tempDetails From PendingSalesBillDetails Where 1=2") = -1 Then
                frmMain.statusText.Text = "保存对销售单返点的修改失败！"
                DB.Close() : Me.Cursor = Cursors.Default
                Return
            End If

            Dim dvRebateCard As DataView = dtRebateCard.Copy.DefaultView
            dvRebateCard.RowFilter = "Isnull(CardQTY,0)>0"
            If DB.BulkCopyTable("#tempDetails", dvRebateCard.ToTable(False, "RowID", "StartCardNo", "EndCardNo", "CardQTY", "FaceValue")) = -1 Then
                frmMain.statusText.Text = "保存对销售单返点的修改失败！"
                dvRebateCard.Dispose() : dvRebateCard = Nothing
                DB.Close() : Me.Cursor = Cursors.Default
                Return
            End If

            sSQL = sSQL & "@RebateRate=" & dmAvailableRebateRate.ToString & ",@RebateCardQTY=" & iRebateCardQTY.ToString & ",@RebateSalesAMT=" & dmAvailableRebateAMT.ToString & ","
            If dmAvailableRebateAMT <= dmMaxNormalRebateAMT Then
                sSQL = sSQL & "@RebateState=2,"
            Else
                sSQL = sSQL & "@RebateState=0,@NormalRebateApprovableRoleID=" & drRule("ApprovableRoleID").ToString & ",@NormalRebateRemarks='" & Me.lblNormalRebateRemarks.Text.Replace("'", "''") & "',"
            End If
        End If

        sSQL = sSQL & "@OperatorName='" & frmMain.sLoginUserRealName.Replace("'", "''") & "',@SSID=" & frmMain.sSSID
        dtResult = DB.GetDataTable(sSQL)
        DB.Close()

        If dtResult Is Nothing Then
            frmMain.statusText.Text = "保存对销售单返点的修改失败！"
        ElseIf dtResult.Rows(0)("Result").ToString = "Error" Then
            MessageBox.Show("保存对销售单返点的修改时出现错误！下面是数据库的内部错误提示：    " & Chr(13) & Chr(13) & dtResult.Rows(0)("ErrorInfo").ToString & Space(4) & Chr(13) & Chr(13) & "请放弃保存，在关闭窗口后重试。如果仍有问题，请联系软件开发人员。    ", "保存销售单失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "保存对销售单返点的修改失败！"
        ElseIf dtResult.Rows(0)("Result").ToString <> "OK" Then
            frmSelling.txbNormalRebateAMT.Select() : frmSelling.txbNormalRebateAMT.SelectAll()
            Select Case dtResult.Rows(0)("Result").ToString
                Case "SalesBillDeleted"
                    MessageBox.Show("当前销售单已被取消！修改无效。    ", "修改销售单返点无效！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    frmSelling.ResetInterfaceWhenSalesBillDeleted(dtResult.Rows(0))
                    frmMain.statusText.Text = "当前销售单已被取消！"
                Case "SalesBillCancelled"
                    MessageBox.Show("当前销售单已被申请取消！修改无效。    ", "修改销售单返点无效！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    frmSelling.ResetInterfaceWhenSalesBillCancelled(dtResult.Rows(0))
                    frmMain.statusText.Text = "当前销售单已被申请取消！"
                Case "RebateStateChanged"
                    MessageBox.Show("当前销售单的返点审核状态已经发生改变！请先关闭该销售单后再打开，以查看最新的返点状态。    ", "修改销售单返点失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    With frmSelling
                        frmSelling.btnModifyNormalRebate.Enabled = False
                        .drSalesBill("CardQTY") = dtResult.Rows(0)("CardQTY")
                        .drSalesBill("ChargedAMT") = dtResult.Rows(0)("ChargedAMT")
                        .drSalesBill("RebateMode") = dtResult.Rows(0)("RebateMode")
                        .drSalesBill("RebateRate") = dtResult.Rows(0)("RebateRate")
                        .drSalesBill("RebateCardQTY") = dtResult.Rows(0)("RebateCardQTY")
                        .drSalesBill("RebateSalesAMT") = dtResult.Rows(0)("RebateSalesAMT")
                        .drSalesBill.AcceptChanges()
                    End With

                    If frmSalesBillManagement.IsHandleCreated Then
                        Try
                            With frmSalesBillManagement
                                Dim currentSalesBill As DataRow = .dvSalesBill.Table.Rows.Find(frmSelling.drSalesBill("SalesBillID").ToString)
                                currentSalesBill("CardQTY") = frmSelling.drSalesBill("CardQTY")
                                currentSalesBill("ChargedAMT") = frmSelling.drSalesBill("ChargedAMT")
                                Select Case frmSelling.drSalesBill("RebateMode")
                                    Case 0
                                        currentSalesBill("RebateMode") = "没有返点"
                                        currentSalesBill("RebateRate") = DBNull.Value
                                        currentSalesBill("RebateSalesAMT") = DBNull.Value
                                        currentSalesBill("RebateState") = DBNull.Value
                                    Case 1
                                        currentSalesBill("RebateRate") = frmSelling.drSalesBill("RebateRate")
                                        currentSalesBill("RebateSalesAMT") = frmSelling.drSalesBill("RebateSalesAMT")
                                        Select Case frmSelling.drSalesBill("RebateState")
                                            Case 0
                                                currentSalesBill("RebateState") = "等待审核"
                                            Case 2
                                                currentSalesBill("RebateState") = "不用审核"
                                            Case 3
                                                currentSalesBill("RebateState") = "审核成功"
                                        End Select
                                End Select
                                currentSalesBill.AcceptChanges()
                                currentSalesBill = Nothing
                                If .dgvList.CurrentRow IsNot Nothing Then
                                    .dgvList.CurrentRow.Selected = False
                                    .dgvList.CurrentRow.Selected = True
                                End If
                            End With
                        Catch
                        End Try
                    End If

                    frmMain.statusText.Text = "当前销售单的返点审核状态已经发生改变！"
            End Select

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Else
            With frmSelling
                .drSalesBill("CardQTY") = iCardQTY
                .txbCardQTY.Text = Format(iCardQTY, "#,0")
                .drSalesBill("ChargedAMT") = dmNormalSalesAMT + dmAvailableRebateAMT
                .txbChargedAMT.Text = Format(dmNormalSalesAMT + dmAvailableRebateAMT, "#,0.00")

                If dmAvailableRebateAMT = 0 Then
                    .drSalesBill("RebateMode") = 0
                    .drSalesBill("RebateRate") = DBNull.Value
                    .drSalesBill("RebateCardQTY") = 0
                    .drSalesBill("RebateSalesAMT") = 0
                    .drSalesBill("RebateState") = DBNull.Value
                    .drSalesBill("NormalRebateRemarks") = DBNull.Value

                    .grbNormalRebate.Visible = False
                Else
                    .drSalesBill("RebateRate") = dmAvailableRebateRate
                    .drSalesBill("RebateCardQTY") = iRebateCardQTY
                    .drSalesBill("RebateSalesAMT") = dmAvailableRebateAMT

                    .txbNormalRebateRate.Text = Me.txbNormalRebateRate.Text
                    .txbNormalRebateAMT.Text = Me.txbNormalRebateAMT.Text

                    If dmAvailableRebateAMT <= dmMaxNormalRebateAMT Then
                        .drSalesBill("RebateState") = 2
                        .drSalesBill("NormalRebateRemarks") = DBNull.Value

                        .txbNormalRebateRate.ForeColor = SystemColors.ControlText
                        .txbNormalRebateRate.Font = New Font(Me.txbNormalRebateRate.Font, FontStyle.Regular)
                        .txbNormalRebateAMT.ForeColor = SystemColors.ControlText
                        .txbNormalRebateAMT.Font = New Font(Me.txbNormalRebateAMT.Font, FontStyle.Regular)
                        .lblNormalRebateState.Text = "有效（在标准范围内）"
                        .pnlNormalRebateRemarks.Visible = False
                    Else
                        .drSalesBill("RebateState") = 0
                        .drSalesBill("NormalRebateRemarks") = Me.lblNormalRebateRemarks.Text

                        .txbNormalRebateRate.ForeColor = Color.Orange
                        .txbNormalRebateRate.Font = New Font(Me.txbNormalRebateRate.Font, FontStyle.Bold)
                        .txbNormalRebateAMT.ForeColor = Color.Orange
                        .txbNormalRebateAMT.Font = New Font(Me.txbNormalRebateAMT.Font, FontStyle.Bold)
                        .lblNormalRebateState.Text = "需审核（超出标准范围）"
                        .lblNormalRebateRemarks.Text = Me.lblNormalRebateRemarks.Text
                        .pnlNormalRebateRemarks.Visible = True
                    End If
                    .pnlModifyNormalRebate.Visible = False
                End If

                .drSalesBill.AcceptChanges()

                .flpNormalRebate.AutoSize = False
                .flpNormalRebate.AutoSize = True
                .grbNormalRebate.Height = .flpNormalRebate.Height + 53

                'modify code 046:start-------------------------------------------------------------------------
                Dim dtResult2 As DataTable
                DB.Open()
                dtResult2 = DB.GetDataTable("Select * From PendingSalesBillDetails Where RowType = 2 and SalesBillID = " & frmSelling.sSalesBillID).Copy

                For Each drResult In dtResult2.Select("", "SalesBillID,SalesBillDetailID,StartCardNo,EndCardNo,CardQTY")
                    If DB.GetDataTable("select * from SignCardList where CardNo>='" & drResult("StartCardNo") & "' and CardNo<='" & drResult("EndCardNo") & "'").Rows.Count = drResult("CardQTY") Then
                        DB.ModifyTable("insert into SalesBillExtendHis (SalesBillID,SalesBillDetailID,IsSignCard) values (" & frmSelling.sSalesBillID & "," & drResult("SalesBillDetailID") & ",'是')")
                    Else
                        DB.ModifyTable("insert into SalesBillExtendHis (SalesBillID,SalesBillDetailID,IsSignCard) values (" & frmSelling.sSalesBillID & "," & drResult("SalesBillDetailID") & ",'否')")
                    End If
                Next
                DB.Close()
                'modify code 046:end-------------------------------------------------------------------------
            End With

            If frmSalesBillManagement.IsHandleCreated Then
                Try
                    With frmSalesBillManagement
                        Dim currentSalesBill As DataRow = .dvSalesBill.Table.Rows.Find(frmSelling.drSalesBill("SalesBillID").ToString)
                        currentSalesBill("CardQTY") = iCardQTY
                        currentSalesBill("ChargedAMT") = dmNormalSalesAMT + dmAvailableRebateAMT
                        If frmSelling.drSalesBill("RebateMode") = 0 Then
                            currentSalesBill("RebateMode") = "没有返点"
                            currentSalesBill("RebateRate") = DBNull.Value
                            currentSalesBill("RebateSalesAMT") = DBNull.Value
                            currentSalesBill("RebateState") = DBNull.Value
                        Else
                            currentSalesBill("RebateRate") = dmAvailableRebateRate
                            currentSalesBill("RebateSalesAMT") = dmAvailableRebateAMT
                            If frmSelling.drSalesBill("RebateState") = 0 Then
                                currentSalesBill("RebateState") = "等待审核"
                            Else
                                currentSalesBill("RebateState") = "不用审核"
                            End If
                        End If
                        currentSalesBill.AcceptChanges()
                        currentSalesBill = Nothing
                        If .dgvList.CurrentRow IsNot Nothing Then
                            .dgvList.CurrentRow.Selected = False
                            .dgvList.CurrentRow.Selected = True
                        End If
                    End With
                Catch
                End Try
            End If

            frmMain.statusText.Text = "保存对销售单返点的修改成功。"
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If

        If dtResult IsNot Nothing Then dtResult.Dispose() : dtResult = Nothing
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CardNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If editingTextBox IsNot Nothing AndAlso editingTextBox.SelectedText.Length > 0 AndAlso editingTextBox.SelectedText.Length = editingTextBox.Text.Length Then
                blSkipDeal = True
                Me.dgvRebateCard.CurrentCell.Value = ""
                blSkipDeal = False
            End If
            Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub CardQTY_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If Not blBrushingEnd Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.OemSemicolon Then '防止从读卡器上输入 
            blBrushingEnd = False
            sTimerType = "BrushingCard"
            Me.theTimer.Interval = 1000
            Me.theTimer.Enabled = True
            e.SuppressKeyPress = True
            Return
        End If
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        e.SuppressKeyPress = True
    End Sub

    Private Sub Money_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If Not blBrushingEnd Then e.SuppressKeyPress = True : Return
        If e.KeyCode = Keys.OemSemicolon Then '防止从读卡器上输入 
            blBrushingEnd = False
            sTimerType = "BrushingCard"
            Me.theTimer.Interval = 1000
            Me.theTimer.Enabled = True
            e.SuppressKeyPress = True
            Return
        End If
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        If e.KeyCode = Keys.OemPeriod OrElse e.KeyCode = Keys.Decimal Then
            If editingTextBox.SelectedText.IndexOf(".") > -1 OrElse editingTextBox.Text.IndexOf(".") = -1 Then Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub editingTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If blSkipDeal Then Return
        If editingTextBox Is Nothing Then Return
        Dim blHaveOtherTypeCard As Boolean
        If Me.dgvRebateCard.Columns(Me.dgvRebateCard.CurrentCell.ColumnIndex).Name = "StartCardNo" AndAlso Me.dgvRebateCard("EndCardNo", Me.dgvRebateCard.CurrentCell.RowIndex).Value.ToString = "" Then
            blSkipDeal = True
            Dim sValue As String = editingTextBox.Text, bSelectionStart As Byte = editingTextBox.SelectionStart, bSelectionLength As Byte = editingTextBox.SelectionLength, sFeature As String = "充值券"
            If blCanUsePaperCard Then
                Dim bStart As Byte = editingTextBox.SelectionStart, bLen As Byte = editingTextBox.SelectionLength
                If sValue.IndexOf("9") = 0 Then
                    Dim blCanUse9Card As Boolean = False
                    If sValue.IndexOf("92") = 0 Then
                        If blCanUse92Card Then
                            sFeature = "营销券"
                            blCanUse9Card = True
                        End If
                    ElseIf sValue = "9" OrElse sValue.IndexOf("94") = 0 Then
                        If blCanUse94Card Then
                            sFeature = "活动券"
                            blCanUse9Card = True
                        End If
                    End If

                    If blCanUse9Card Then
                        Me.dgvRebateCard("CardFeature", Me.dgvRebateCard.CurrentCell.RowIndex).Value = sFeature
                        Me.dgvRebateCard.Columns("CardFeature").Visible = True
                        editingTextBox.MaxLength = 17
                        Me.dgvRebateCard("FaceValue", Me.dgvRebateCard.CurrentCell.RowIndex).ReadOnly = True
                    Else
                        Me.dgvRebateCard("CardFeature", Me.dgvRebateCard.CurrentCell.RowIndex).Value = DBNull.Value
                        blHaveOtherTypeCard = False
                        For Each drCard As DataGridViewRow In Me.dgvRebateCard.Rows
                            If drCard.Cells("CardFeature").Value.ToString <> "" AndAlso drCard.Cells("CardFeature").Value.ToString <> "磁条卡" Then
                                blHaveOtherTypeCard = True
                                Exit For
                            End If
                        Next

                        Me.dgvRebateCard.Columns("CardFeature").Visible = blHaveOtherTypeCard
                        editingTextBox.MaxLength = 19
                        Me.dgvRebateCard("FaceValue", Me.dgvRebateCard.CurrentCell.RowIndex).ReadOnly = False
                    End If
                ElseIf sValue.IndexOf("8") = 0 Then
                    If sValue.IndexOf("84") = 0 Then
                        If sValue.Length > 7 Then
                            If sValue.Substring(5, 1) = "8" OrElse sValue.Substring(5, 3) = "100" Then sFeature = "条码卡"
                        ElseIf sValue.Length > 5 Then
                            If sValue.Substring(5, 1) = "8" OrElse sValue.Substring(5, 1) = "1" Then sFeature = "条码卡"
                        Else
                            sFeature = "条码卡"
                        End If
                    ElseIf sValue = "8" OrElse sValue.IndexOf("86") = 0 Then
                        sFeature = "条码卡"
                    Else
                        sFeature = ""
                    End If

                    If sFeature = "" Then
                        Me.dgvRebateCard("CardFeature", Me.dgvRebateCard.CurrentCell.RowIndex).Value = DBNull.Value
                        blHaveOtherTypeCard = False
                        For Each drCard As DataGridViewRow In Me.dgvRebateCard.Rows
                            If drCard.Cells("CardFeature").Value.ToString <> "" AndAlso drCard.Cells("CardFeature").Value.ToString <> "磁条卡" Then
                                blHaveOtherTypeCard = True
                                Exit For
                            End If
                        Next

                        Me.dgvRebateCard.Columns("CardFeature").Visible = blHaveOtherTypeCard
                        editingTextBox.MaxLength = 19
                        Me.dgvRebateCard("FaceValue", Me.dgvRebateCard.CurrentCell.RowIndex).ReadOnly = False
                    Else
                        Me.dgvRebateCard("CardFeature", Me.dgvRebateCard.CurrentCell.RowIndex).Value = sFeature
                        Me.dgvRebateCard.Columns("CardFeature").Visible = True
                        editingTextBox.MaxLength = 17
                        Me.dgvRebateCard("FaceValue", Me.dgvRebateCard.CurrentCell.RowIndex).ReadOnly = True
                    End If
                Else
                    If sValue.IndexOf("2") = 0 Then
                        If sValue.IndexOf("233694") = 0 Then
                            sFeature = IIf(blCanUse94Card, "活动卡", "")
                        ElseIf sValue = "23369" OrElse sValue.IndexOf("233692") = 0 Then
                            sFeature = IIf(blCanUse92Card, "营销卡", "")
                        ElseIf sValue = "23368" OrElse sValue.IndexOf("233684") = 0 OrElse (sValue.Length < 5 AndAlso "2336".IndexOf(sValue) = 0) Then
                            sFeature = "磁条卡"
                            'modify code 051:start-------------------------------------------------------------------------
                            'ElseIf sValue = "23366" OrElse sValue.IndexOf("233660") = 0 Then
                        ElseIf sValue.IndexOf("233660") = 0 Then
                            sFeature = IIf(blCanUse60Card, "礼品卡", "")
                        ElseIf sValue.IndexOf("233665") = 0 Then
                            sFeature = IIf(blCanUse65Card, "磁条卡", "")
                            'modify code 051:end-------------------------------------------------------------------------
                        ElseIf Me.chbPrintDiscount.Checked = False AndAlso sValue.Length < 5 AndAlso "2336".IndexOf(sValue) = 0 Then
                            sFeature = "营销卡"
                        Else
                            sFeature = ""
                        End If
                    Else
                        sFeature = ""
                    End If

                    Me.dgvRebateCard("CardFeature", Me.dgvRebateCard.CurrentCell.RowIndex).Value = IIf(sFeature = "", DBNull.Value, sFeature)
                    If sFeature <> "" AndAlso sFeature <> "磁条卡" Then
                        blHaveOtherTypeCard = True
                    Else
                        blHaveOtherTypeCard = False
                        For Each drCard As DataGridViewRow In Me.dgvRebateCard.Rows
                            If drCard.Cells("CardFeature").Value.ToString <> "" AndAlso drCard.Cells("CardFeature").Value.ToString <> "磁条卡" Then
                                blHaveOtherTypeCard = True
                                Exit For
                            End If
                        Next
                    End If
                    Me.dgvRebateCard.Columns("CardFeature").Visible = blHaveOtherTypeCard
                    editingTextBox.MaxLength = 19
                    Me.dgvRebateCard("FaceValue", Me.dgvRebateCard.CurrentCell.RowIndex).ReadOnly = False
                End If

                editingTextBox.Text = sValue
                editingTextBox.SelectionStart = bStart
                editingTextBox.SelectionLength = bLen
            Else
                If sValue.IndexOf("2") = 0 Then
                    If sValue.IndexOf("233694") = 0 Then
                        sFeature = IIf(blCanUse94Card, "活动卡", "")
                    ElseIf sValue = "23369" OrElse sValue.IndexOf("233692") = 0 Then
                        sFeature = IIf(blCanUse92Card, "营销卡", "")
                    ElseIf sValue = "23368" OrElse sValue.IndexOf("233684") = 0 OrElse (sValue.Length < 5 AndAlso "2336".IndexOf(sValue) = 0) Then
                        sFeature = "磁条卡"
                        'modify code 051:start-------------------------------------------------------------------------
                        'ElseIf sValue = "23366" OrElse sValue.IndexOf("233660") = 0 Then
                    ElseIf sValue.IndexOf("233660") = 0 Then
                        sFeature = IIf(blCanUse60Card, "礼品卡", "")
                    ElseIf sValue.IndexOf("233665") = 0 Then
                        sFeature = IIf(blCanUse65Card, "磁条卡", "")
                        'modify code 051:end-------------------------------------------------------------------------
                    ElseIf Me.chbPrintDiscount.Checked = False AndAlso sValue.Length < 5 AndAlso "2336".IndexOf(sValue) = 0 Then
                        sFeature = "营销卡"
                    Else
                        sFeature = ""
                    End If
                Else
                    sFeature = ""
                End If

                Me.dgvRebateCard("CardFeature", Me.dgvRebateCard.CurrentCell.RowIndex).Value = IIf(sFeature = "", DBNull.Value, sFeature)
                If editingTextBox.Text <> sValue Then '可能数据丢失
                    editingTextBox.Text = sValue
                    editingTextBox.SelectionStart = bSelectionStart
                    editingTextBox.SelectionLength = bSelectionLength
                End If
                If sFeature <> "" AndAlso sFeature <> "磁条卡" Then
                    blHaveOtherTypeCard = True
                Else
                    blHaveOtherTypeCard = False
                    For Each drCard As DataGridViewRow In Me.dgvRebateCard.Rows
                        If drCard.Cells("CardFeature").Value.ToString <> "" AndAlso drCard.Cells("CardFeature").Value.ToString <> "磁条卡" Then
                            blHaveOtherTypeCard = True
                            Exit For
                        End If
                    Next
                End If
                Me.dgvRebateCard.Columns("CardFeature").Visible = blHaveOtherTypeCard
            End If
            blSkipDeal = False
            Me.dgvRebateCard.Refresh()
        End If
        editingTextBox.ForeColor = SystemColors.ControlText
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Function SetInputtingCardFeature(ByVal sInputtingCardNo As String) As String
        Dim sNewFeature As String = "充值券"
        If sInputtingCardNo.IndexOf("9") = 0 Then
            If blCanUsePaperCard Then
                If sInputtingCardNo.IndexOf("94") = 0 Then
                    sNewFeature = IIf(blCanUse94Card, "活动券", "")
                ElseIf sInputtingCardNo = "9" OrElse sInputtingCardNo.IndexOf("92") = 0 Then
                    sNewFeature = IIf(blCanUse92Card, "营销券", "")
                Else
                    sNewFeature = ""
                End If
            Else
                sNewFeature = ""
            End If
        ElseIf sInputtingCardNo.IndexOf("8") = 0 Then
            If blCanUsePaperCard Then
                If sInputtingCardNo.IndexOf("84") = 0 Then
                    If sInputtingCardNo.Length > 7 Then
                        If sInputtingCardNo.Substring(5, 1) = "8" OrElse sInputtingCardNo.Substring(5, 3) = "100" Then sNewFeature = "条码卡"
                    ElseIf sInputtingCardNo.Length > 5 Then
                        If sInputtingCardNo.Substring(5, 1) = "8" Then sNewFeature = "条码卡"
                    Else
                        sNewFeature = "条码卡"
                    End If
                ElseIf sInputtingCardNo = "8" OrElse sInputtingCardNo.IndexOf("86") = 0 Then
                    sNewFeature = "条码卡"
                Else
                    sNewFeature = ""
                End If
            Else
                sNewFeature = ""
            End If
        ElseIf sInputtingCardNo.IndexOf("2") = 0 Then
            If sInputtingCardNo.IndexOf("233694") = 0 Then
                sNewFeature = IIf(blCanUse94Card, "活动卡", "")
                'modify code 050:start-------------------------------------------------------------------------
            ElseIf sInputtingCardNo.IndexOf("2336" & frmMain.signCardBin) = 0 Then
                sNewFeature = "实名制卡"
                'modify code 050:end-------------------------------------------------------------------------
            ElseIf sInputtingCardNo = "23369" OrElse sInputtingCardNo.IndexOf("233692") = 0 Then
                sNewFeature = IIf(blCanUse92Card, "营销卡", "")
            ElseIf sInputtingCardNo = "23368" OrElse sInputtingCardNo.IndexOf("233684") = 0 OrElse (sInputtingCardNo.Length < 5 AndAlso "2336".IndexOf(sInputtingCardNo) = 0) Then
                sNewFeature = "磁条卡"
                'modify code 051:start-------------------------------------------------------------------------
                'ElseIf sInputtingCardNo = "23366" OrElse sInputtingCardNo.IndexOf("233660") = 0 Then
            ElseIf sInputtingCardNo.IndexOf("233660") = 0 Then
                sNewFeature = IIf(blCanUse60Card, "礼品卡", "")
            ElseIf sInputtingCardNo.IndexOf("233665") = 0 Then
                sNewFeature = IIf(blCanUse65Card, "磁条卡", "")
                'modify code 051:end-------------------------------------------------------------------------
            ElseIf sInputtingCardNo.Length < 5 AndAlso "2336".IndexOf(sInputtingCardNo) = 0 Then
                sNewFeature = "营销卡"
            Else
                sNewFeature = ""
            End If
        Else
            sNewFeature = ""
        End If

        Return sNewFeature
    End Function

    Private Function SetCardFeature(ByVal sCardNo As String) As String
        Dim sFeature As String = ""
       
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

        Return sFeature
    End Function

    Private Function IsValidCard(ByVal sCardNo As String) As Boolean
        If sCardNo.IndexOf("233684") = 0 Then
            Return True
        ElseIf sCardNo.IndexOf("233692") = 0 Then
            Return True
        ElseIf sCardNo.IndexOf("233694") = 0 Then
            Return True
        ElseIf sCardNo.IndexOf("233660") = 0 Then
            Return True
        ElseIf sCardNo.IndexOf("86") = 0 Then
            Return True
        ElseIf sCardNo.IndexOf("84") = 0 Then
            Return True
        ElseIf sCardNo.IndexOf("94") = 0 Then
            Return True
        ElseIf sCardNo.IndexOf("92") = 0 Then
            Return True
        ElseIf sCardNo = "2" Then
            Return True
        ElseIf sCardNo = "8" Then
            Return True
        ElseIf sCardNo = "9" Then
            Return True
        ElseIf sCardNo = "23" Then
            Return True
        ElseIf sCardNo = "233" Then
            Return True
        ElseIf sCardNo = "2336" Then
            Return True
        ElseIf sCardNo = "23368" Then
            Return True
        ElseIf sCardNo = "23369" Then
            Return True
        ElseIf sCardNo = "23366" Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub ConfigRebateCardRow()
        Dim iRows As Integer = Me.dgvRebateCard.RowCount - 1, iCurrentRow As Integer = Me.dgvRebateCard.CurrentRow.Index, sStartCardNo As String = Me.dgvRebateCard("StartCardNo", iCurrentRow).Value.ToString, sEndCardNo As String = Me.dgvRebateCard("EndCardNo", iCurrentRow).Value.ToString
        If sStartCardNo > sEndCardNo Then
            Me.dgvRebateCard.EndEdit() : sStartCardNo = sEndCardNo : sEndCardNo = Me.dgvRebateCard("StartCardNo", iCurrentRow).Value.ToString
            Me.dgvRebateCard("StartCardNo", iCurrentRow).Value = sStartCardNo : Me.dgvRebateCard("EndCardNo", iCurrentRow).Value = sEndCardNo
        End If

        Dim dtTempList As DataTable = dtRebateCard.DefaultView.ToTable, sFeature As String, sStart As String, sEnd As String, drCard As DataRow, blNeedResetRow As Boolean = False
        dtTempList.Rows.Clear()
        dtTempList.Columns.Add("SecondID", System.Type.GetType("System.Byte"))
        For iRow As Integer = 0 To iRows
            If iRow <> iCurrentRow AndAlso Me.dgvRebateCard("StartCardNo", iRow).Value.ToString <> "" Then
                sFeature = Me.dgvRebateCard("CardFeature", iRow).Value.ToString
                sStart = Me.dgvRebateCard("StartCardNo", iRow).Value.ToString : sEnd = Me.dgvRebateCard("EndCardNo", iRow).Value.ToString
                If sStart.IndexOf("8") = 0 OrElse sStart.IndexOf("9") = 0 Then '纸券,保留该行
                    drCard = dtTempList.Rows.Add()
                    drCard("RowID") = iRow + 1
                    drCard("SecondID") = 0
                    drCard("CardFeature") = sFeature
                    drCard("StartCardNo") = sStart
                    drCard("EndCardNo") = sEnd
                    drCard("CardQTY") = Me.dgvRebateCard("CardQTY", iRow).Value
                    drCard("FaceValue") = Me.dgvRebateCard("FaceValue", iRow).Value
                    drCard("ChargedAMT") = Me.dgvRebateCard("ChargedAMT", iRow).Value
                ElseIf sStartCardNo > sEnd OrElse sEndCardNo < sStart Then '该行卡号范围落在当前修改行之外,保留该行
                    drCard = dtTempList.Rows.Add()
                    drCard("RowID") = iRow + 1
                    drCard("SecondID") = 0
                    drCard("CardFeature") = sFeature
                    drCard("StartCardNo") = sStart
                    drCard("EndCardNo") = sEnd
                    drCard("CardQTY") = Me.dgvRebateCard("CardQTY", iRow).Value
                    drCard("FaceValue") = Me.dgvRebateCard("FaceValue", iRow).Value
                    drCard("ChargedAMT") = Me.dgvRebateCard("ChargedAMT", iRow).Value
                ElseIf sStartCardNo < sStart AndAlso sEnd < sEndCardNo Then '该行卡号范围完全落在当前修改行之内,将被删除
                    blNeedResetRow = True
                Else '该行卡号范围部分落在当前修改行之内,将被截断
                    Dim dtTemp As New DataTable
                    dtTemp.Columns.Add("CardNo", System.Type.GetType("System.String"))
                    Dim dvTemp As New DataView(dtTemp), drTemp As DataRowView
                    sStart = sStart.Substring(0, 18)
                    Dim iCardQTY As Integer = Me.dgvRebateCard("CardQTY", iRow).Value - 1
                    For iCard As Integer = 0 To iCardQTY
                        sEnd = (CLng(sStart) + iCard).ToString
                        If sEnd < sStartCardNo.Substring(0, 18) OrElse sEnd > sEndCardNo.Substring(0, 18) Then
                            drTemp = dvTemp.AddNew
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
                                drCard = dtTempList.Rows.Add()
                                drCard("RowID") = iRow + 1
                                drCard("SecondID") = iCard - 1
                                drCard("CardFeature") = sFeature
                                drCard("StartCardNo") = ShoppingCardNo.GetFullCardNo(sStart)
                                drCard("EndCardNo") = ShoppingCardNo.GetFullCardNo(sEnd)
                                drCard("CardQTY") = CLng(sEnd) - CLng(sStart) + 1
                                If Me.dgvRebateCard("FaceValue", iRow).Value.ToString <> "" Then
                                    drCard("FaceValue") = Me.dgvRebateCard("FaceValue", iRow).Value
                                    drCard("ChargedAMT") = drCard("FaceValue") * drCard("CardQTY")
                                End If
                                drCard.EndEdit()
                                sStart = dvTemp(iCard)("CardNo").ToString
                                sEnd = sStart
                                iCardQTY = 1
                            End If
                        Next
                        drCard = dtTempList.Rows.Add()
                        drCard("RowID") = iRow + 1
                        drCard("SecondID") = dvTemp.Count
                        drCard("CardFeature") = sFeature
                        drCard("StartCardNo") = ShoppingCardNo.GetFullCardNo(sStart)
                        drCard("EndCardNo") = ShoppingCardNo.GetFullCardNo(sEnd)
                        drCard("CardQTY") = CLng(sEnd) - CLng(sStart) + 1
                        If Me.dgvRebateCard("FaceValue", iRow).Value.ToString <> "" Then
                            drCard("FaceValue") = Me.dgvRebateCard("FaceValue", iRow).Value
                            drCard("ChargedAMT") = drCard("CardQTY") * drCard("FaceValue")
                        End If
                        drCard.EndEdit()
                    End If
                    dtTemp.Dispose() : dtTemp = Nothing : dvTemp.Dispose() : dvTemp = Nothing
                    blNeedResetRow = True
                End If
            End If
        Next

        If blNeedResetRow Then
            drCard = dtTempList.Rows.Add()
            drCard("RowID") = iCurrentRow + 1
            drCard("SecondID") = 0
            drCard("CardFeature") = IIf(sStartCardNo.Substring(4, 2) = "84", "磁条卡", "营销卡")
            drCard("StartCardNo") = sStartCardNo
            drCard("EndCardNo") = sEndCardNo
            drCard("CardQTY") = CLng(sEndCardNo.Substring(0, 18)) - CLng(sStartCardNo.Substring(0, 18)) + 1
            If Me.dgvRebateCard("FaceValue", iCurrentRow).Value.ToString <> "" Then
                drCard("FaceValue") = Me.dgvRebateCard("FaceValue", iCurrentRow).Value
                drCard("ChargedAMT") = drCard("CardQTY") * drCard("FaceValue")
            End If
            drCard.EndEdit()
            Dim bCurrentColumn As Byte = Me.dgvRebateCard.CurrentCell.ColumnIndex, drFinalCard As DataRow
            dtRebateCard.Rows.Clear()
            iRows = 1
            For Each drCard In dtTempList.Select("", "RowID,SecondID")
                drFinalCard = dtRebateCard.Rows.Add
                drFinalCard("RowID") = iRows
                For bColumn As Byte = 1 To dtRebateCard.Columns.Count - 1
                    If dtRebateCard.Columns(bColumn).ReadOnly = False Then drFinalCard(bColumn) = drCard(bColumn)
                Next
                drFinalCard.EndEdit()
                iRows += 1
            Next
            dtRebateCard.Rows.Add(iRows)
            For Each dr As DataGridViewRow In Me.dgvRebateCard.Rows
                If dr.Cells("StartCardNo").Value.ToString = sStartCardNo Then
                    iCurrentRow = dr.Index
                    Me.dgvRebateCard(bCurrentColumn, iCurrentRow).Selected = True : Exit For
                End If
            Next
        Else
            Me.dgvRebateCard("CardFeature", iCurrentRow).Value = IIf(sStartCardNo.Substring(4, 2) = "84", "磁条卡", "营销卡")
            Me.dgvRebateCard("CardQTY", iCurrentRow).Value = CLng(sEndCardNo.Substring(0, 18)) - CLng(sStartCardNo.Substring(0, 18)) + 1
            If Me.dgvRebateCard("FaceValue", iCurrentRow).Value.ToString <> "" Then
                Me.dgvRebateCard("ChargedAMT", iCurrentRow).Value = Me.dgvRebateCard("CardQTY", iCurrentRow).Value * Me.dgvRebateCard("FaceValue", iCurrentRow).Value
            End If
            If Me.dgvRebateCard.CurrentCell.RowIndex = Me.dgvRebateCard.RowCount - 1 Then dtRebateCard.Rows.Add(iRows + 2)
        End If

        For Each drRebate As DataGridViewRow In Me.dgvRebateCard.Rows
            drRebate.Cells("FaceValue").ReadOnly = (drRebate.Cells("CardFeature").Value.ToString = "条码卡" OrElse drRebate.Cells("CardFeature").Value.ToString = "充值券")
        Next

        Me.CheckFaceValue()
        If errorRebateCell Is Nothing Then Me.UpdateNormalRebateInfo()

        dtTempList.Dispose() : dtTempList = Nothing
    End Sub

    Private Sub ConfigRebatePaperCardRow()
        Dim iRows As Integer = Me.dgvRebateCard.RowCount - 1, iCurrentRow As Integer = Me.dgvRebateCard.CurrentRow.Index, sStartCardNo As String = Me.dgvRebateCard("StartCardNo", iCurrentRow).Value.ToString, sEndCardNo As String = Me.dgvRebateCard("EndCardNo", iCurrentRow).Value.ToString
        If sStartCardNo > sEndCardNo Then
            Me.dgvRebateCard.EndEdit() : sStartCardNo = sEndCardNo : sEndCardNo = Me.dgvRebateCard("StartCardNo", iCurrentRow).Value.ToString
            Me.dgvRebateCard("StartCardNo", iCurrentRow).Value = sStartCardNo : Me.dgvRebateCard("EndCardNo", iCurrentRow).Value = sEndCardNo
        End If

        Dim dtTempList As DataTable = dtRebateCard.DefaultView.ToTable, sFeature As String, sStart As String, sEnd As String, drCard As DataRow, blNeedResetRow As Boolean = False
        dtTempList.Rows.Clear()
        dtTempList.Columns.Add("SecondID", System.Type.GetType("System.Byte"))
        For iRow As Integer = 0 To iRows
            If iRow <> iCurrentRow AndAlso Me.dgvRebateCard("StartCardNo", iRow).Value.ToString <> "" Then
                sFeature = Me.dgvRebateCard("CardFeature", iRow).Value.ToString
                sStart = Me.dgvRebateCard("StartCardNo", iRow).Value.ToString : sEnd = Me.dgvRebateCard("EndCardNo", iRow).Value.ToString
                If sStart.IndexOf("2") = 0 Then '磁条卡或营销卡,保留该行
                    drCard = dtTempList.Rows.Add()
                    drCard("RowID") = iRow + 1
                    drCard("SecondID") = 0
                    drCard("CardFeature") = sFeature
                    drCard("StartCardNo") = sStart
                    drCard("EndCardNo") = sEnd
                    drCard("CardQTY") = Me.dgvRebateCard("CardQTY", iRow).Value
                    drCard("FaceValue") = Me.dgvRebateCard("FaceValue", iRow).Value
                    drCard("ChargedAMT") = Me.dgvRebateCard("ChargedAMT", iRow).Value
                ElseIf sStartCardNo > sEnd OrElse sEndCardNo < sStart Then '该行卡号范围落在当前修改行之外,保留该行
                    drCard = dtTempList.Rows.Add()
                    drCard("RowID") = iRow + 1
                    drCard("SecondID") = 0
                    drCard("CardFeature") = sFeature
                    drCard("StartCardNo") = sStart
                    drCard("EndCardNo") = sEnd
                    drCard("CardQTY") = Me.dgvRebateCard("CardQTY", iRow).Value
                    drCard("FaceValue") = Me.dgvRebateCard("FaceValue", iRow).Value
                    drCard("ChargedAMT") = Me.dgvRebateCard("ChargedAMT", iRow).Value
                ElseIf sStartCardNo < sStart AndAlso sEnd < sEndCardNo Then '该行卡号范围完全落在当前修改行之内,将被删除
                    blNeedResetRow = True
                Else '该行卡号范围部分落在当前修改行之内,将被截断
                    Dim dtTemp As New DataTable
                    dtTemp.Columns.Add("CardNo", System.Type.GetType("System.String"))
                    Dim dvTemp As New DataView(dtTemp), drTemp As DataRowView
                    Dim iCardQTY As Integer = Me.dgvRebateCard("CardQTY", iRow).Value - 1
                    For iCard As Integer = 0 To iCardQTY
                        sEnd = (CLng(sStart) + iCard).ToString
                        If sEnd < sStartCardNo OrElse sEnd > sEndCardNo Then
                            drTemp = dvTemp.AddNew
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
                                drCard = dtTempList.Rows.Add()
                                drCard("RowID") = iRow + 1
                                drCard("SecondID") = iCard - 1
                                drCard("CardFeature") = sFeature
                                drCard("StartCardNo") = sStart
                                drCard("EndCardNo") = sEnd
                                drCard("CardQTY") = CLng(sEnd) - CLng(sStart) + 1
                                If Me.dgvRebateCard("FaceValue", iRow).Value.ToString <> "" Then
                                    drCard("FaceValue") = Me.dgvRebateCard("FaceValue", iRow).Value
                                    drCard("ChargedAMT") = drCard("FaceValue") * drCard("CardQTY")
                                End If
                                drCard.EndEdit()
                                sStart = dvTemp(iCard)("CardNo").ToString
                                sEnd = sStart
                                iCardQTY = 1
                            End If
                        Next
                        drCard = dtTempList.Rows.Add()
                        drCard("RowID") = iRow + 1
                        drCard("SecondID") = dvTemp.Count
                        drCard("CardFeature") = sFeature
                        drCard("StartCardNo") = sStart
                        drCard("EndCardNo") = sEnd
                        drCard("CardQTY") = CLng(sEnd) - CLng(sStart) + 1
                        If Me.dgvRebateCard("FaceValue", iRow).Value.ToString <> "" Then
                            drCard("FaceValue") = Me.dgvRebateCard("FaceValue", iRow).Value
                            drCard("ChargedAMT") = drCard("CardQTY") * drCard("FaceValue")
                        End If
                        drCard.EndEdit()
                    End If
                    dtTemp.Dispose() : dtTemp = Nothing : dvTemp.Dispose() : dvTemp = Nothing
                    blNeedResetRow = True
                End If
            End If
        Next

        sFeature = Me.dgvRebateCard("CardFeature", iCurrentRow).Value.ToString
        If blNeedResetRow Then
            drCard = dtTempList.Rows.Add()
            drCard("RowID") = iCurrentRow + 1
            drCard("SecondID") = 0
            drCard("CardFeature") = sFeature
            drCard("StartCardNo") = sStartCardNo
            drCard("EndCardNo") = sEndCardNo
            drCard("CardQTY") = CLng(sEndCardNo) - CLng(sStartCardNo) + 1
            If Me.dgvRebateCard("FaceValue", iCurrentRow).Value.ToString <> "" Then
                drCard("FaceValue") = Me.dgvRebateCard("FaceValue", iCurrentRow).Value
                drCard("ChargedAMT") = drCard("CardQTY") * drCard("FaceValue")
            End If
            drCard.EndEdit()
            Dim bCurrentColumn As Byte = Me.dgvRebateCard.CurrentCell.ColumnIndex, drFinalCard As DataRow
            dtRebateCard.Rows.Clear()
            iRows = 1
            For Each drCard In dtTempList.Select("", "RowID,SecondID")
                drFinalCard = dtRebateCard.Rows.Add
                drFinalCard("RowID") = iRows
                For bColumn As Byte = 1 To dtRebateCard.Columns.Count - 1
                    If dtRebateCard.Columns(bColumn).ReadOnly = False Then drFinalCard(bColumn) = drCard(bColumn)
                Next
                drFinalCard.EndEdit()
                iRows += 1
            Next
            dtRebateCard.Rows.Add(iRows)
            For Each dr As DataGridViewRow In Me.dgvRebateCard.Rows
                If dr.Cells("StartCardNo").Value.ToString = sStartCardNo Then
                    iCurrentRow = dr.Index
                    Me.dgvRebateCard(bCurrentColumn, iCurrentRow).Selected = True : Exit For
                End If
            Next
        Else
            Me.dgvRebateCard("CardFeature", iCurrentRow).Value = sFeature
            Me.dgvRebateCard("CardQTY", iCurrentRow).Value = CLng(sEndCardNo) - CLng(sStartCardNo) + 1
            If Me.dgvRebateCard("FaceValue", iCurrentRow).Value.ToString <> "" Then
                Me.dgvRebateCard("ChargedAMT", iCurrentRow).Value = Me.dgvRebateCard("CardQTY", iCurrentRow).Value * Me.dgvRebateCard("FaceValue", iCurrentRow).Value
            End If
            If Me.dgvRebateCard.CurrentCell.RowIndex = Me.dgvRebateCard.RowCount - 1 Then dtRebateCard.Rows.Add(iRows + 2)
        End If

        For Each drRebate As DataGridViewRow In Me.dgvRebateCard.Rows
            drRebate.Cells("FaceValue").ReadOnly = (drRebate.Cells("CardFeature").Value.ToString = "条码卡" OrElse drRebate.Cells("CardFeature").Value.ToString = "充值券")
        Next

        Me.CheckPaperCardExisting()
        If errorRebateCell Is Nothing Then Me.UpdateNormalRebateInfo()

        dtTempList.Dispose() : dtTempList = Nothing
    End Sub

    Private Sub UpdateNormalRebateInfo()
        Try
            dmRebateSalesAMT = dtRebateCard.Compute("Sum(ChargedAMT)", "")
        Catch
            dmRebateSalesAMT = 0
        End Try
        Try
            iRebateCardQTY = dtRebateCard.Compute("Sum(CardQTY)", "")
        Catch
            iRebateCardQTY = 0
        End Try
        If dmRebateSalesAMT = 0 Then
            Me.lblRebateCardSummary.Text = ""
        Else
            Me.lblRebateCardSummary.Text = "（卡数： " & Format(iRebateCardQTY, "#,0") & " 张  充值： " & Format(dmRebateSalesAMT, "#,0.00") & " 元）"
        End If
        Me.btnOK.Enabled = (dmRebateSalesAMT <> dmOldRebateSalesAMT)

        If blCalculateNormalRebateByRate Then
            dmAvailableRebateRate = CDec(Me.txbNormalRebateRate.Text) / 100
            dmAvailableRebateAMT = dmNormalSalesAMT * dmAvailableRebateRate
            Me.txbNormalRebateAMT.Text = Format(dmAvailableRebateAMT, "#,0.00")
            dmAvailableRebateAMT = CDec(Me.txbNormalRebateAMT.Text)
        Else
            dmAvailableRebateAMT = CDec(Me.txbNormalRebateAMT.Text)
            If dmAvailableRebateAMT = 0 Then
                dmAvailableRebateRate = 0
            ElseIf dmNormalSalesAMT = 0 Then
                dmAvailableRebateRate = 1
            Else
                'modify code 038:start-------------------------------------------------------------------------
                'dmAvailableRebateRate = Int((dmAvailableRebateAMT / dmNormalSalesAMT) * 1000 + 0.5) / 1000
                dmAvailableRebateRate = Int((dmAvailableRebateAMT / dmNormalSalesAMT) * 10000 + 0.5) / 10000
                'modify code 038:end-------------------------------------------------------------------------
            End If
            'modify code 038:start-------------------------------------------------------------------------
            'Me.txbNormalRebateRate.Text = Format(dmAvailableRebateRate * 100, "#,0.0")
            Me.txbNormalRebateRate.Text = Format(dmAvailableRebateRate * 100, "#,0.00")
            'modify code 038:end-------------------------------------------------------------------------
        End If

        If dmAvailableRebateAMT = 0 Then
            Me.txbNormalRebateRate.ForeColor = SystemColors.ControlText
            Me.txbNormalRebateRate.Font = New Font(Me.txbNormalRebateRate.Font, FontStyle.Regular)
            Me.txbNormalRebateAMT.ForeColor = SystemColors.ControlText
            Me.txbNormalRebateAMT.Font = New Font(Me.txbNormalRebateAMT.Font, FontStyle.Regular)
            Me.pnlNormalRebateState.Visible = False
            Me.pnlNormalRebateRemarks.Visible = False
        ElseIf dmAvailableRebateAMT <= dmMaxNormalRebateAMT Then
            Me.txbNormalRebateRate.ForeColor = SystemColors.ControlText
            Me.txbNormalRebateRate.Font = New Font(Me.txbNormalRebateRate.Font, FontStyle.Regular)
            Me.txbNormalRebateAMT.ForeColor = SystemColors.ControlText
            Me.txbNormalRebateAMT.Font = New Font(Me.txbNormalRebateAMT.Font, FontStyle.Regular)
            Me.lblNormalRebateState.Text = "有效（在标准范围内）"
            Me.pnlNormalRebateState.Visible = True
            Me.pnlNormalRebateRemarks.Visible = False
        Else
            Me.txbNormalRebateRate.ForeColor = Color.Orange
            Me.txbNormalRebateRate.Font = New Font(Me.txbNormalRebateRate.Font, FontStyle.Bold)
            Me.txbNormalRebateAMT.ForeColor = Color.Orange
            Me.txbNormalRebateAMT.Font = New Font(Me.txbNormalRebateAMT.Font, FontStyle.Bold)
            Me.lblNormalRebateState.Text = "需审核（超出标准范围）"
            Me.pnlNormalRebateState.Visible = True
            If dmAvailableRebateRate > 0.2 Then
                Me.lblNormalRebateRemarks.Text = "返点不应超过 20% ！"
            Else
                Me.lblNormalRebateRemarks.Text = "需要由下面人员审核： " & Chr(13) & drRule("RoleFullName").ToString
            End If
            Me.pnlNormalRebateRemarks.Visible = True
        End If

        Me.txbDistributionNormalRebateAMT.Text = Format(dmRebateSalesAMT, "#,0.00")
        If dmRebateSalesAMT <= dmAvailableRebateAMT Then
            Me.txbDistributionNormalRebateAMT.ForeColor = SystemColors.ControlText
            Me.txbDistributionNormalRebateAMT.Font = New Font(Me.txbDistributionNormalRebateAMT.Font, FontStyle.Regular)
            Me.theTip.SetToolTip(Me.txbDistributionNormalRebateAMT, "")
        Else
            Me.txbDistributionNormalRebateAMT.BackColor = SystemColors.Control
            Me.txbDistributionNormalRebateAMT.ForeColor = Color.Red
            Me.txbDistributionNormalRebateAMT.Font = New Font(Me.txbDistributionNormalRebateAMT.Font, FontStyle.Bold)
            Me.theTip.SetToolTip(Me.txbDistributionNormalRebateAMT, "已分配的返点金额超过您输入的返点金额： " & Format(dmAvailableRebateAMT, "#,0.00").Replace(".00", "") & " 元！")
        End If

        If dmRebateSalesAMT < dmAvailableRebateAMT Then
            Me.pnlBalanceNormalRebateAMT.Visible = True
            Me.txbBalanceNormalRebateAMT.Text = Format(dmAvailableRebateAMT - dmRebateSalesAMT, "#,0.00")
            Me.theTip.SetToolTip(Me.txbBalanceNormalRebateAMT, "已分配的返点金额未达到您输入的返点金额： " & Format(dmAvailableRebateAMT, "#,0.00").Replace(".00", "") & " 元。" & Chr(13) & "请在右边返点卡列表中" & IIf(dmRebateSalesAMT = 0, "", "继续") & "分配返点卡及其金额。")
        Else
            Me.pnlBalanceNormalRebateAMT.Visible = False
        End If

        Me.grbNormalRebate.Height = Me.flpNormalRebate.Height + 20
    End Sub

    Private Sub CheckFaceValue()
        If sErrorRebateInfo.IndexOf("两个面值之和不能超过") > -1 Then errorRebateCell = Nothing : sErrorRebateInfo = ""
        Dim sStartNo As String, sCardNo As String, drNormalCard As DataRow
        Dim maxFaceValue As Integer
        For iRow As Int16 = 0 To Me.dgvRebateCard.RowCount - 2
            If Me.dgvRebateCard("FaceValue", iRow).Value.ToString.IndexOf("2") = 0 Then
                sStartNo = Me.dgvRebateCard("StartCardNo", iRow).Value.ToString.Substring(0, 18)
                For iCard As Int16 = 0 To Me.dgvRebateCard("CardQTY", iRow).Value - 1
                    sCardNo = ShoppingCardNo.GetFullCardNo((CLng(sStartNo) + iCard).ToString)
                    drNormalCard = dtOriginalNormal.Rows.Find(sCardNo)

                    'modify code 054:start-------------------------------------------------------------------------
                    'If dtSignCardRangeAll.Select("CardNo='" & sCardNo & "'").Length > 0 Then
                    If sCardNo.IndexOf("2336" & frmMain.signCardBin) = 0 Then
                        'modify code 054:end-------------------------------------------------------------------------
                        maxFaceValue = 5000
                    Else
                        maxFaceValue = 1000
                    End If

                    If drNormalCard IsNot Nothing AndAlso Me.dgvRebateCard("FaceValue", iRow).Value + drNormalCard("FaceValue") > maxFaceValue Then
                        If Me.dgvRebateCard("CardQTY", iRow).Value = 1 Then
                            sErrorRebateInfo = "该卡既是正常卡又是返点卡，两个面值之和不能超过 " & Format(maxFaceValue, "#,0,000") & " 元"
                        Else
                            sErrorRebateInfo = "该行部分卡片既是正常卡又是返点卡，两个面值之和不能超过 " & Format(maxFaceValue, "#,0,000") & " 元"
                        End If
                        errorRebateCell = Me.dgvRebateCard("FaceValue", iRow)
                        Exit Sub
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub CheckPaperCardExisting()
        If sErrorRebateInfo.IndexOf("不能同时既是正常卡又是返点卡") > -1 Then errorRebateCell = Nothing : sErrorRebateInfo = ""
        Dim sStartCardNo As String, sEndCardNo As String, sCardNo As String
        For Each drRebate As DataGridViewRow In Me.dgvRebateCard.Rows
            If "|条码卡|充值券|".IndexOf(drRebate.Cells("CardFeature").Value.ToString) > 0 Then
                sStartCardNo = drRebate.Cells("StartCardNo").Value.ToString
                sEndCardNo = drRebate.Cells("EndCardNo").Value.ToString
                For Each drNormal As DataRow In dtOriginalNormal.Select("CardNo Like '8%'")
                    sCardNo = drNormal("CardNo").ToString
                    If sCardNo >= sStartCardNo AndAlso sCardNo <= sEndCardNo Then
                        sErrorRebateInfo = "同一张" & drRebate.Cells("CardFeature").Value.ToString & "不能同时既是正常卡又是返点卡"
                        If drRebate.Cells("EndCardNo").Equals(Me.dgvRebateCard.CurrentCell) Then
                            errorRebateCell = drRebate.Cells("EndCardNo")
                        Else
                            errorRebateCell = drRebate.Cells("StartCardNo")
                        End If
                        Return
                    End If
                Next
            End If
        Next
    End Sub
End Class