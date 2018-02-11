Public Class frmTransferConfirm
    Private Sub QueryRecords()
        '还需要考虑权限的控制, 当前用户可以确认那些人的转账申请

        statusText.Text = "提示信息：正在查询未确认转账信息，请稍等......"
        statusMain.Refresh()

        Dim bdb As New DataBase()
        Dim dtRequest As DataTable
        bdb.Open()
        If bdb.IsConnected Then
            dtRequest = bdb.GetDataTable("select * from culspecialoperation where operationtype='转账' and AffirmState=0")
            dgvRequest.AutoGenerateColumns = False
            dgvRequest.DataSource = dtRequest

        Else
            MsgBox("连接数据库失败！无法进行转账确认！")
            statusText.Text = "错误提示：连接数据库失败！无法进行转账确认！"
        End If
        bdb.Close()

        If dgvRequest.RowCount = 0 Then
            statusText.Text = "提示信息：数据已查询完成！没有需要确认的转账请求！"
        Else
            statusText.Text = "提示信息：数据已查询完成！请选择一行然后点击确认按钮"
        End If
        statusMain.Refresh()

    End Sub

    Private Sub frmTransferConfirm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvRequest.Rows.Clear()
        QueryRecords()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        If dgvRequest.SelectedRows.Count > 0 Then
            Dim ls_msg As String
            ls_msg = "您确实要确认该笔转账么？" + vbCrLf
            ls_msg += "转出卡号:" & dgvRequest.SelectedRows(0).Cells("FromCard").Value.ToString() & vbCrLf
            ls_msg += "转入卡号:" & dgvRequest.SelectedRows(0).Cells("ToCard").Value.ToString() & vbCrLf
            ls_msg += "转账金额:" & dgvRequest.SelectedRows(0).Cells("RequestAMT").Value.ToString() & vbCrLf

            If MessageBox.Show(ls_msg, "操作确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Then
                Dim ls_OperationID As String = dgvRequest.SelectedRows(0).Cells("OperationID").Value.ToString()
                Dim ls_sql As String

                ls_sql = "update CULSpecialOperation set AffirmState=1 where OperationID=" & ls_OperationID
                Dim bdb As New DataBase()
                bdb.Open()
                If bdb.IsConnected Then
                    If bdb.ModifyTable(ls_sql) = -1 Then
                        statusText.Text = "错误提示：保存数据库失败！无法进行转账确认！"
                        Return
                    End If
                Else
                    statusText.Text = "错误提示：连接数据库失败，无法进行转账确认！"
                    Return
                End If



                Dim itrfClass As C4ShoppingCardService.ItrfClass
                itrfClass = New C4ShoppingCardService.ItrfClass

                Dim c4Service As C4ShoppingCardService.C4ShoppingCardService
                c4Service = New C4ShoppingCardService.C4ShoppingCardService

                Dim codeMsg As C4ShoppingCardService.CodeMsg
                codeMsg = New C4ShoppingCardService.CodeMsg

                itrfClass.MerchantNo = "102210054110420"
                itrfClass.UserID = "test"
                itrfClass.CardNoFrom = dgvRequest.SelectedRows(0).Cells("FromCard").Value.ToString()
                itrfClass.CardNoTo = dgvRequest.SelectedRows(0).Cells("ToCard").Value.ToString()
                itrfClass.Amount = Convert.ToDouble(dgvRequest.SelectedRows(0).Cells("RequestAMT").Value)
                itrfClass.Amount = Math.Round(Convert.ToDecimal(dgvRequest.SelectedRows(0).Cells("RequestAMT").Value), 2).ToString
                itrfClass.Remarks = "Carrefour"
                codeMsg = c4Service.itrf(itrfClass)
                If codeMsg.Code = "KZ" Then
                    statusText.Text = "提示信息：转账确认完成，已成功转账！"
                    dgvRequest.Rows.Remove(dgvRequest.SelectedRows(0))
                Else
                    ls_sql = "update CULSpecialOperation set AffirmState=0 where OperationID=" & ls_OperationID
                    bdb.ModifyTable(ls_sql)
                    statusText.Text = "错误提示：转账确认失败！" & codeMsg.Msg
                End If
                '最后关闭数据库连接()
                bdb.Close()

            End If
        Else
            statusText.Text = "提示信息：没有需要确认的转账请求！"
        End If
    End Sub
End Class