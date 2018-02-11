Public Class frmCancelSalesBill

    Private Sub txbReason_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbReason.TextChanged
        Me.btnOK.Enabled = (Me.txbReason.Text.Trim <> "")
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在申请取消销售单……"
        frmMain.statusMain.Refresh()

        Dim DB As New DataBase()
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法申请取消销售单。请检查数据库连接。"
            Me.Cursor = Cursors.Default : Return
        End If

        Dim dtResult As DataTable = DB.GetDataTable("Exec SalesBillCancellation " & frmSelling.sSalesBillID & "," & IIf(frmSelling.drSalesBill("ActivationCancelledAMT").ToString = frmSelling.drSalesBill("ChargedAMT").ToString, 1, 0).ToString & ",'" & Me.txbReason.Text.Trim.Replace("'", "''") & "','" & frmMain.sLoginUserRealName.Replace("'", "''") & "'," & frmMain.sSSID)
        DB.Close()

        If dtResult Is Nothing Then
            frmMain.statusText.Text = "申请取消销售单失败！"
        ElseIf dtResult.Rows(0)("Result").ToString = "Error" Then
            MessageBox.Show("申请取消销售单时出现错误！下面是数据库的内部错误提示：    " & Chr(13) & Chr(13) & dtResult.Rows(0)("ErrorInfo").ToString & Space(4) & Chr(13) & Chr(13) & "请放弃保存，在关闭窗口后重试。如果仍有问题，请联系软件开发人员。    ", "保存销售单失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "申请取消销售单失败！"
        ElseIf dtResult.Rows(0)("Result").ToString <> "OK" Then
            Select Case dtResult.Rows(0)("Result").ToString
                Case "SalesBillDeleted"
                    MessageBox.Show("当前销售单已被他人申请取消且已确认！    ", "申请取消销售单无效！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    frmSelling.ResetInterfaceWhenSalesBillDeleted(dtResult.Rows(0))
                    frmMain.statusText.Text = "当前销售单已被申请取消且确认！"
                Case "SalesBillStateChanged"
                    MessageBox.Show("仅当销售单处于""等待激活""的状态时，才可以申请取消！    " & Chr(13) & Chr(13) & "目前销售单已经不再处于处于""等待激活""状态，所以不再可以取消。    ", "销售单不能被取消！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    With frmSelling
                        .drSalesBill("SalesBillState") = dtResult.Rows(0)("SalesBillState")
                        .drSalesBill("StateReason") = dtResult.Rows(0)("StateReason")
                        .drSalesBill("ActivatorName") = dtResult.Rows(0)("ActivatorName")
                        .drSalesBill("ActivatedTime") = dtResult.Rows(0)("ActivatedTime")
                        .drSalesBill.AcceptChanges()
                        Select Case .drSalesBill("SalesBillState")
                            Case 1
                                .lblSalesBillState.Text = "已提交到CUL，正在激活"
                                .lblSalesBillRemarks.Text = "提交： " & .drSalesBill("ActivatorName").ToString & Chr(13) & "时间： " & Format(.drSalesBill("ActivatedTime"), "yyyy\/MM\/dd HH:mm")
                            Case 2
                                .lblSalesBillState.Text = "激活失败！"
                                .lblSalesBillRemarks.Text = "提交： " & .drSalesBill("ActivatorName").ToString & Chr(13) & "时间： " & Format(.drSalesBill("ActivatedTime"), "yyyy\/MM\/dd HH:mm")
                                If .drSalesBill("StateReason").ToString <> "" Then .theTip.SetToolTip(.lblSalesBillState, "失败原因： " & .drSalesBill("StateReason").ToString)
                            Case 3
                                .lblSalesBillState.Text = "部分激活"
                                .lblSalesBillRemarks.Text = "提交： " & .drSalesBill("ActivatorName").ToString & Chr(13) & "时间： " & Format(.drSalesBill("ActivatedTime"), "yyyy\/MM\/dd HH:mm")
                                If .drSalesBill("StateReason").ToString <> "" Then .theTip.SetToolTip(.lblSalesBillState, "部分失败原因： " & .drSalesBill("StateReason").ToString)
                            Case 4
                                .lblSalesBillState.Text = "全部激活"
                                .lblSalesBillRemarks.Text = "提交： " & .drSalesBill("ActivatorName").ToString & Chr(13) & "时间： " & Format(.drSalesBill("ActivatedTime"), "yyyy\/MM\/dd HH:mm")
                        End Select
                        .pnlSalesBillStateDescription.Visible = True
                        .grbSalesBillInfo.Height = 157

                        Try
                            .splitLayout.SplitterDistance = IIf(.flpLeftContainer.VerticalScroll.Visible, 264, 239)
                        Catch
                        End Try

                        .btnOK.Enabled = False
                    End With

                    If frmSalesBillManagement.IsHandleCreated Then
                        Try
                            Dim currentSalesBill As DataRow = frmSalesBillManagement.dvSalesBill.Table.Rows.Find(frmSelling.drSalesBill("SalesBillID").ToString)
                            Select Case frmSelling.drSalesBill("SalesBillState")
                                Case 1
                                    currentSalesBill("SalesBillState") = "正在激活"
                                Case 2
                                    currentSalesBill("SalesBillState") = "激活失败"
                                Case 3
                                    currentSalesBill("SalesBillState") = "部分激活"
                                Case 4
                                    currentSalesBill("SalesBillState") = "全部激活"
                            End Select
                            currentSalesBill.AcceptChanges()
                            currentSalesBill = Nothing
                        Catch
                        End Try
                    End If

                    frmMain.statusText.Text = "当前销售单不能被取消！"
                Case "SalesBillCancelled"
                    MessageBox.Show("当前销售单已被他人申请取消！您无须再申请。    ", "申请取消销售单无效！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    frmSelling.ResetInterfaceWhenSalesBillCancelled(dtResult.Rows(0))
                    frmMain.statusText.Text = "当前销售单已被他人申请取消！"
            End Select

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Else
            With frmSelling
                .drSalesBill("CancellerID") = frmMain.sLoginUserID
                .drSalesBill("SalesBillState") = 9
                .drSalesBill.AcceptChanges()
                .ResetInterfaceWhenSalesBillCancelled(dtResult.Rows(0))
                If frmMain.dtAllowedRight.Select("RightName='SalesBillDelete'").Length = 0 Then
                    .btnOK.Text = "撤销取消(&O)"
                Else
                    .btnOK.Text = "确认取消(&O)"
                End If
            End With
            frmMain.statusText.Text = "保存销售单取消申请成功。"
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If

        If dtResult IsNot Nothing Then dtResult.Dispose() : dtResult = Nothing
        Me.Cursor = Cursors.Default
    End Sub
End Class