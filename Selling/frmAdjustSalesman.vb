Public Class frmAdjustSalesman

    Public currentSalesBill As DataRow
    Private blSkipDeal As Boolean = True, dtBigFish As DataTable, dtMediumFish As DataTable, sSalesmanID As String = "-1", sSalesmanName As String = "", sNewSalesmanID As String = "-1", sNewSalesmanName As String = ""

    Private Sub frmAdjustSalesman_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMain.statusText.Text = "就绪。"
    End Sub

    Private Sub frmAdjustSalesman_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sSalesmanID = currentSalesBill("SalesmanID").ToString : sSalesmanName = currentSalesBill("SalesmanName").ToString
        dtBigFish = frmMain.dvBigFish.ToTable : dtMediumFish = frmMain.dvMediumFish.ToTable
        dtBigFish.AcceptChanges() : dtMediumFish.AcceptChanges()

        If sSalesmanID = "" Then sSalesmanID = "-1"
        If sSalesmanID <> "-1" AndAlso sSalesmanID <> "-2" Then
            If dtBigFish.Select("SalesmanID=" & sSalesmanID).Length > 0 Then
                sSalesmanName = dtBigFish.Select("SalesmanID=" & sSalesmanID)(0)("SalesmanName").ToString
            ElseIf dtMediumFish.Select("SalesmanID=" & sSalesmanID).Length > 0 Then
                sSalesmanName = dtMediumFish.Select("SalesmanID=" & sSalesmanID)(0)("SalesmanName").ToString
            Else
                sSalesmanID = "-2"
            End If
        End If
        Me.txbOldSalesman.Text = IIf(sSalesmanID = "-1", "（没有业务员）", sSalesmanName)
        If dtBigFish.Rows.Count = 0 Then
            Me.pnlBigFish.Visible = False
        Else
            With Me.cbbBigFish
                .DataSource = dtBigFish
                .DisplayMember = "SalesmanName"
                .ValueMember = "SalesmanID"
                .SelectedValue = sSalesmanID
                If .SelectedIndex > -1 Then
                    Me.rdbBigFish.Checked = True
                    Me.cbbBigFish.Enabled = True
                Else
                    .SelectedIndex = 0
                End If
            End With
        End If
        If dtMediumFish.Rows.Count = 0 Then
            Me.pnlMediumFish.Visible = False
        Else
            With Me.cbbMediumFish
                .DataSource = dtMediumFish
                .DisplayMember = "SalesmanName"
                .ValueMember = "SalesmanID"
                .SelectedValue = sSalesmanID
                If .SelectedIndex > -1 Then
                    Me.rdbMediumFish.Checked = True
                    Me.cbbMediumFish.Enabled = True
                Else
                    .SelectedIndex = 0
                End If
            End With
        End If
        If sSalesmanID = "-2" Then
            Me.rdbOthers.Checked = True
            Me.txbOtherSalesman.Enabled = True
            Me.txbOtherSalesman.Text = sSalesmanName
        End If
        If dtBigFish.Rows.Count + dtMediumFish.Rows.Count = 0 Then Me.rdbOthers.Visible = False
        If sSalesmanName = "" Then Me.pnlNoSalesman.Visible = False

        Me.Height = Me.flpSalesman.Height + 179
        Me.Location = New Point((My.Computer.Screen.WorkingArea.Width - Me.Width) / 2, (My.Computer.Screen.WorkingArea.Height - Me.Height) / 2)

        Me.btnOK.Enabled = False
        blSkipDeal = False
        If Me.rdbBigFish.Checked Then
            Me.cbbBigFish.Select()
        ElseIf Me.rdbMediumFish.Checked Then
            Me.cbbMediumFish.Select()
        ElseIf Me.rdbOthers.Checked Then
            Me.txbOtherSalesman.Select()
            Me.txbOtherSalesman.SelectAll()
        ElseIf Me.pnlBigFish.Visible Then
            Me.rdbBigFish.Checked = True
            Me.cbbBigFish.Select()
        ElseIf Me.pnlMediumFish.Visible Then
            Me.rdbMediumFish.Checked = True
        Else
            Me.rdbOthers.Checked = True
            Me.txbOtherSalesman.Select()
            Me.txbOtherSalesman.SelectAll()
        End If
    End Sub

    Private Sub rdbBigFish_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbBigFish.CheckedChanged
        If blSkipDeal Then Return
        If Me.rdbBigFish.Checked Then
            Me.cbbBigFish.Enabled = True
            Me.rdbMediumFish.Checked = False
            Me.rdbOthers.Checked = False
            Me.chkNoSalesMan.Checked = False
            sNewSalesmanID = Me.cbbBigFish.SelectedValue.ToString
            sNewSalesmanName = Me.cbbBigFish.Text
            Me.cbbBigFish.Select()
            Me.btnOK.Enabled = (sNewSalesmanID <> sSalesmanID OrElse sNewSalesmanName <> sSalesmanName)
        Else
            Me.cbbBigFish.Enabled = False
        End If
    End Sub

    Private Sub cbbBigFish_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbBigFish.SelectedIndexChanged
        If blSkipDeal Then Return
        sNewSalesmanID = Me.cbbBigFish.SelectedValue.ToString
        sNewSalesmanName = Me.cbbBigFish.Text
        Me.btnOK.Enabled = (sNewSalesmanID <> sSalesmanID OrElse sNewSalesmanName <> sSalesmanName)
    End Sub

    Private Sub rdbMediumFish_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbMediumFish.CheckedChanged
        If blSkipDeal Then Return
        If Me.rdbMediumFish.Checked Then
            Me.cbbMediumFish.Enabled = True
            Me.rdbBigFish.Checked = False
            Me.rdbOthers.Checked = False
            Me.chkNoSalesMan.Checked = False
            sNewSalesmanID = Me.cbbMediumFish.SelectedValue.ToString
            sNewSalesmanName = Me.cbbMediumFish.Text
            Me.cbbMediumFish.Select()
            Me.btnOK.Enabled = (sNewSalesmanID <> sSalesmanID OrElse sNewSalesmanName <> sSalesmanName)
        Else
            Me.cbbMediumFish.Enabled = False
        End If
    End Sub

    Private Sub cbbMediumFish_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbMediumFish.SelectedIndexChanged
        If blSkipDeal Then Return
        sNewSalesmanID = Me.cbbMediumFish.SelectedValue.ToString
        sNewSalesmanName = Me.cbbMediumFish.Text
        Me.btnOK.Enabled = (sNewSalesmanID <> sSalesmanID OrElse sNewSalesmanName <> sSalesmanName)
    End Sub

    Private Sub rdbOthers_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbOthers.CheckedChanged
        If blSkipDeal Then Return
        If Me.rdbOthers.Checked Then
            Me.txbOtherSalesman.Enabled = True
            Me.rdbBigFish.Checked = False
            Me.rdbMediumFish.Checked = False
            Me.chkNoSalesMan.Checked = False
            sNewSalesmanID = "-2"
            sNewSalesmanName = Me.txbOtherSalesman.Text.Trim
            Me.txbOtherSalesman.Select() : Me.txbOtherSalesman.SelectAll()
            Me.btnOK.Enabled = (sNewSalesmanID <> sSalesmanID OrElse sNewSalesmanName <> sSalesmanName)
        Else
            Me.txbOtherSalesman.Enabled = False
        End If
    End Sub

    Private Sub txbOtherSalesman_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbOtherSalesman.TextChanged
        If blSkipDeal Then Return
        sNewSalesmanID = "-2"
        sNewSalesmanName = Me.txbOtherSalesman.Text.Trim
        Me.btnOK.Enabled = (sNewSalesmanID <> sSalesmanID OrElse sNewSalesmanName <> sSalesmanName)
    End Sub

    Private Sub chkNoSalesMan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNoSalesMan.CheckedChanged
        If Me.chkNoSalesMan.Checked Then
            Me.pnlBigFish.Enabled = False
            Me.pnlMediumFish.Enabled = False
            Me.pnlOthers.Enabled = False
            sNewSalesmanID = "-1" : sNewSalesmanName = ""
        Else
            Me.pnlBigFish.Enabled = True
            Me.pnlMediumFish.Enabled = True
            Me.pnlOthers.Enabled = True
            If Me.rdbBigFish.Checked Then
                sNewSalesmanID = Me.cbbBigFish.SelectedValue.ToString
                sNewSalesmanName = Me.cbbBigFish.Text
                Me.cbbBigFish.Select()
            ElseIf Me.rdbMediumFish.Checked Then
                sNewSalesmanID = Me.cbbMediumFish.SelectedValue.ToString
                sNewSalesmanName = Me.cbbMediumFish.Text
                Me.cbbMediumFish.Select()
            Else
                sNewSalesmanID = "-2"
                sNewSalesmanName = Me.txbOtherSalesman.Text.Trim
                Me.txbOtherSalesman.Select() : Me.txbOtherSalesman.SelectAll()
            End If
        End If
        Me.btnOK.Enabled = (sNewSalesmanID <> sSalesmanID)
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If sNewSalesmanID = "-2" AndAlso sNewSalesmanName = "" Then
            sNewSalesmanID = "-1"
            If sSalesmanID = "-1" Then
                Me.btnOK.Enabled = False
                Return
            Else
                Me.chkNoSalesMan.Checked = True
            End If
        End If

        If frmMain.sLoginRoleID = "14" Then
            If MessageBox.Show("注意：业务员只能调整一次！一旦确定，便不可再调整！    " & Chr(13) & Chr(13) & _
                               "调整前业务员： " & sSalesmanName & Space(4) & Chr(13) & _
                               "调整后业务员： " & IIf(sNewSalesmanID = "-1", "（没有业务员）", sNewSalesmanName) & Space(4) & Chr(13) & Chr(13) & _
                               "您是否确认当前调整正确无误？    ", "请确认调整业务员：", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return
            Me.Refresh()
        End If

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在保存调整结果……"
        frmMain.statusMain.Refresh()

        Dim DB As New DataBase()
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法保存调整结果。请检查数据库连接。"
            Me.Cursor = Cursors.Default : Return
        End If

        Dim sSQL As String = "Exec AdjustSalesman @SalesBillID=" & currentSalesBill("SalesBillID").ToString & ","
        If sNewSalesmanID <> "-1" Then sSQL = sSQL & "@SalesmanID=" & sNewSalesmanID & ",@SalesmanName='" & sNewSalesmanName.Replace("'", "''") & "',"
        sSQL = sSQL & "@OperatorName='" & frmMain.sLoginUserRealName.Replace("'", "''") & "',@SSID=" & frmMain.sSSID

        Dim dtResult As DataTable = DB.GetDataTable(sSQL)
        DB.Close()

        If dtResult Is Nothing Then
            frmMain.statusText.Text = "调整失败！"
        Else
            Select Case dtResult.Rows(0)("Result").ToString
                Case "SalesBillDeleted"
                    MessageBox.Show("该销售单已被取消！调整无效。    ", "调整业务员无效！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If frmSelling.IsHandleCreated AndAlso frmSelling.sSalesBillID = currentSalesBill("SalesBillID").ToString Then
                        frmSelling.ResetInterfaceWhenSalesBillDeleted(dtResult.Rows(0))
                    Else
                        currentSalesBill.Delete() : currentSalesBill.AcceptChanges()
                    End If
                    frmMain.statusText.Text = "当前销售单已被取消！"
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Case "SalesBillCancelled"
                    MessageBox.Show("该销售单已被申请取消！调整无效。    ", "调整业务员无效！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If frmSelling.IsHandleCreated AndAlso frmSelling.sSalesBillID = currentSalesBill("SalesBillID").ToString Then
                        frmSelling.ResetInterfaceWhenSalesBillCancelled(dtResult.Rows(0))
                    Else
                        currentSalesBill("SalesBillState") = "已被申请取消"
                        currentSalesBill.AcceptChanges()
                    End If
                    frmMain.statusText.Text = "当前销售单已被申请取消！"
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Case "OK"
                    currentSalesBill("SalesmanID") = sNewSalesmanID
                    If sNewSalesmanID = "-1" Then
                        currentSalesBill("SalesmanName") = DBNull.Value
                    Else
                        currentSalesBill("SalesmanName") = sNewSalesmanName
                    End If
                    currentSalesBill("SalesmanChanged") = 1
                    currentSalesBill.AcceptChanges()
                    frmMain.statusText.Text = "调整成功。"
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                Case Else
                    MessageBox.Show("保存调整结果时出现错误！下面是数据库的内部错误提示：    " & Chr(13) & Chr(13) & dtResult.Rows(0)("ErrorInfo").ToString & Space(4) & Chr(13) & Chr(13) & "请放弃保存，在关闭窗口后重试。如果仍有问题，请联系软件开发人员。    ", "保存销售单失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    frmMain.statusText.Text = "调整失败！"
            End Select
            dtResult.Dispose() : dtResult = Nothing
        End If
        Me.Cursor = Cursors.Default
    End Sub
End Class