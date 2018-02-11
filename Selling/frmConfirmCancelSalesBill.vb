Public Class frmConfirmCancelSalesBill

    'modify code 046:
    'date;2015/4/1
    'auther:Hyron zyx 
    'remark:新增销售单类型---实名制卡销售单

    Public drSalesBill As DataRow

    Private Sub frmConfirmCancelSalesBill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txbChargedAMT.Text = Format(drSalesBill("ChargedAMT"), "#,0.00")
        Me.txbPaymentAMT.Text = Format(drSalesBill("PayableAMT"), "#,0.00")
        Me.txbWho.Text = drSalesBill("CancellerName").ToString
        Me.txbWhen.Text = Format(drSalesBill("CancelledTime"), "yyyy\/MM\/dd HH:mm:ss")
        Me.txbWhy.Text = drSalesBill("StateReason").ToString
        Me.btnCancel.Select()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在确认取消销售单……"
        frmMain.statusMain.Refresh()

        Dim DB As New DataBase()
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法确认取消销售单。请检查数据库连接。"
            Me.Cursor = Cursors.Default
            Return
        End If

        Dim sSQL As String = ""
        sSQL = "Exec SalesBillDeletion @SalesBillID=" & drSalesBill("SalesBillID").ToString & ","
        If drSalesBill("ActivationCancelledAMT").ToString = drSalesBill("ChargedAMT").ToString Then sSQL = sSQL & "@ActivationCancelled=1,"
        sSQL = sSQL & "@OperatorName='" & frmMain.sLoginUserRealName.Replace("'", "''") & "',@SSID=" & frmMain.sSSID

        Dim dtResult As DataTable = DB.GetDataTable(sSQL)
        DB.Close()

        If dtResult Is Nothing Then
            frmMain.statusText.Text = "确认取消销售单失败！"
        ElseIf dtResult.Rows(0)("Result").ToString = "Error" Then
            MessageBox.Show("确认取消销售单时出现错误！下面是数据库的内部错误提示：    " & Chr(13) & Chr(13) & dtResult.Rows(0)("ErrorInfo").ToString & Space(4) & Chr(13) & Chr(13) & "请放弃保存，在关闭窗口后重试。如果仍有问题，请联系软件开发人员。    ", "保存销售单失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "确认取消销售单失败！"
        ElseIf dtResult.Rows(0)("Result").ToString= "SalesBillDeleted"
            MessageBox.Show("当前销售单的取消申请已被他人确认！    ", "取消申请已被他人确认！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "当前销售单的取消申请已被他人确认！"
        Else
            frmMain.statusText.Text = "确认取消销售单成功。"

            'modify code 046:start-------------------------------------------------------------------------
            '确认取消实名制销售单
            frmSelling.updateSignCardType("非实名制卡", "确认取消")
            'modify code 046:start-------------------------------------------------------------------------

            If frmSelling.IsHandleCreated AndAlso frmSelling.sSalesBillID = drSalesBill("SalesBillID").ToString Then frmSelling.ResetInterfaceWhenSalesBillDeleted(dtResult.Rows(0))
            If frmSalesBillManagement.IsHandleCreated Then
                With frmSalesBillManagement
                    Try
                        .dvSalesBill.Table.Rows.Find(drSalesBill("SalesBillID").ToString).Delete()
                        .dvSalesBill.Table.AcceptChanges()
                    Catch
                    End Try
                    If .dgvList.CurrentRow IsNot Nothing Then
                        .dgvList.CurrentRow.Selected = False
                        .dgvList.CurrentRow.Selected = True
                    Else
                        .btnOpen.Enabled = False
                        .btnDelete.Enabled = False
                    End If
                End With
            End If
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If

        If dtResult IsNot Nothing Then dtResult.Dispose() : dtResult = Nothing
        Me.Cursor = Cursors.Default
    End Sub
End Class