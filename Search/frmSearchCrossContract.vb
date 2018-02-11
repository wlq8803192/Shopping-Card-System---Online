Public Class frmSearchCrossContract
    'modify code 067:
    'date;2016/10/17
    'auther:Qipeng
    'remark:新添加通卖合同管理

    Private Sub frmSearchContract_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txbCustomerName.Select()
    End Sub

    Private Sub rdbByContractCode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbByContractCode.CheckedChanged
        Me.pnlByContractCode.Enabled = Me.rdbByContractCode.Checked
        If Me.rdbByContractCode.Checked Then
            Me.txbContractCode.Select() : Me.txbContractCode.SelectAll()
            Me.btnOK.Enabled = (Me.txbContractCode.Text.Trim <> "")
        End If
    End Sub

    Private Sub rdbByCustomerName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbByCustomerName.CheckedChanged
        Me.pnlByCustomerName.Enabled = Me.rdbByCustomerName.Checked
        If Me.rdbByCustomerName.Checked Then
            Me.txbCustomerName.Select() : Me.txbCustomerName.SelectAll()
            Me.btnOK.Enabled = (Me.txbCustomerName.Text.Trim <> "")
        End If
    End Sub

    Private Sub txbContractCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbContractCode.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then Return
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbContractCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbContractCode.TextChanged
        Me.btnOK.Enabled = (Me.txbContractCode.Text.Trim <> "")
    End Sub

    Private Sub txbCustomerName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbCustomerName.TextChanged
        Me.btnOK.Enabled = (Me.txbCustomerName.Text.Trim <> "")
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim drRows() As DataRow
        If Me.rdbByContractCode.Checked Then
            Dim sContractCode As String = Me.txbContractCode.Text.Trim
            If sContractCode.Length < 12 OrElse Not IsNumeric(sContractCode) Then
                MessageBox.Show("合同编号应该由12个数字组成。    " & Chr(13) & Chr(13) & _
                                "Contract Code should be consist of 12 digits.    ", "合同编号错误 Contract Code Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txbContractCode.Select() : Me.txbContractCode.SelectAll()
                Me.btnOK.Enabled = False
                Return
            Else
                drRows = frmCrossContractManagement.dvContract.Table.Select("ContractCode='" & sContractCode & "'")
            End If
        Else
            drRows = frmCrossContractManagement.dvContract.Table.Select("CustomerName Like '%" & Me.txbCustomerName.Text.Trim.Replace("'", "''") & "%'")
        End If
        If drRows.Length = 0 Then
            MessageBox.Show("找不到此合同！    " & Chr(13) & Chr(13) & "The Contract can not be found!    ", "找不到 Not found!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            If Me.rdbByContractCode.Checked Then
                Me.txbContractCode.Select() : Me.txbContractCode.SelectAll()
            Else
                Me.txbCustomerName.Select() : Me.txbCustomerName.SelectAll()
            End If
            Me.btnOK.Enabled = False
        Else
            With frmCrossContractManagement
                If .cbbState.SelectedIndex > 1 Then .cbbState.SelectedIndex = 0
                .cbbCity.Text = drRows(0)("CityNameBelongs").ToString
                For Each dr As DataGridViewRow In .dgvList.Rows
                    If dr.Cells("ContractID").Value.ToString = drRows(0)("ContractID").ToString Then
                        dr.Cells(1).Selected = True
                        dr.Selected = False
                        dr.Selected = True
                        Exit For
                    End If
                Next
            End With
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
        drRows = Nothing
    End Sub
End Class