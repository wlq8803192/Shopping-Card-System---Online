Public Class frmECancelExtractingCodeValidation

    'modify code 083:
    'date;2017/11/8
    'auther:Qipeng
    'remark:修复提取码作废确认界面中添加显示字段“订单号”的功能

    'modify code 084:
    'date;2017/11/8
    'auther:Qipeng
    'remark:提取码作废确认中,添加查看历史记录的按钮

    Private dvCULParameter As DataView, dtList As DataTable, dtDatas As DataTable

    Private sIssuerId As String = frmMain.sIssuerId
    Private IWebService As InternetWebService.Service = Nothing
    Private eci As InternetWebService.SetExtractingCodeUsedUpdateStatus = Nothing
    Private ecir As InternetWebService.CodeMsg = Nothing
    Private guIDClass As InternetWebService.GuIDClass = Nothing

    Private Sub frmECancelExtractingCodeValidation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打开窗口。请检查数据库连接。"
            Me.Close() : Return
        End If

        Try
            dtDatas = DB.GetDataTable("select * from CULECancelExtractingCode where OperationResult is null")

            dtList = New DataTable
            dtList.Columns.Add("Selected", System.Type.GetType("System.Boolean"))
            dtList.Columns.Add("ExtractingCode", System.Type.GetType("System.String"))
            dtList.Columns.Add("MobilePhone", System.Type.GetType("System.String"))
            'modify code 083:start-------------------------------------------------------------------------
            dtList.Columns.Add("BillNo", System.Type.GetType("System.String"))
            'modify code 083:end-------------------------------------------------------------------------
            dtList.Columns.Add("CityName", System.Type.GetType("System.String"))
            dtList.Columns.Add("BillTotalAmount", System.Type.GetType("System.String"))
            dtList.Columns.Add("BillPayTotalAmount", System.Type.GetType("System.String"))
            dtList.Columns.Add("RequestorName", System.Type.GetType("System.String"))
            dtList.Columns.Add("RequestedTime", System.Type.GetType("System.String"))
            dtList.Columns.Add("RowID", System.Type.GetType("System.String"))

            If dtDatas Is Nothing OrElse dtDatas.Rows.Count = 0 Then
                Me.lblNothing.Visible = True
                btnOK.Enabled = False
            Else
                Dim newCard As DataRow, iCard As Integer = 0
                For index As Integer = 0 To dtDatas.Rows.Count - 1
                    iCard += 1
                    newCard = dtList.Rows.Add(iCard)
                    newCard("Selected") = 0
                    newCard("ExtractingCode") = dtDatas.Rows(index)("ExtractingCode").ToString
                    newCard("MobilePhone") = dtDatas.Rows(index)("MobilePhone").ToString
                    'modify code 083:start-------------------------------------------------------------------------
                    newCard("BillNo") = dtDatas.Rows(index)("BillNo").ToString
                    'modify code 083:end-------------------------------------------------------------------------
                    newCard("CityName") = dtDatas.Rows(index)("CityName").ToString
                    newCard("BillTotalAmount") = dtDatas.Rows(index)("BillTotalAmount").ToString
                    newCard("BillPayTotalAmount") = dtDatas.Rows(index)("BillPayTotalAmount").ToString
                    newCard("RequestorName") = dtDatas.Rows(index)("RequestorName").ToString
                    newCard("RequestedTime") = dtDatas.Rows(index)("RequestedTime").ToString
                    newCard("RowID") = dtDatas.Rows(index)("OperationID").ToString
                    newCard.EndEdit()
                Next

                initDataGridView()
            End If

            frmMain.statusText.Text = "就绪。"
        Catch
            frmMain.statusText.Text = "系统因在检索数据时出错而无法打开窗口。请联系软件开发人员。"
            DB.Close() : Me.Close() : Return
        End Try
        DB.Close()
    End Sub

    Private Sub initDataGridView()

        With Me.dgvElectronic
            .DataSource = dtList
            Dim newColumn As New DataGridViewCheckBoxColumn
            newColumn.DataPropertyName = "Selected"
            .Columns.RemoveAt(0)
            .Columns.Insert(0, newColumn)
            With .Columns(0)
                .HeaderText = "选择"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 40
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(1)
                .Name = "ExtractingCode"
                .HeaderText = "提取码"
                .Width = 120
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
            End With
            With .Columns(2)
                .Name = "MobilePhone"
                .HeaderText = "手机号码"
                .Width = 80
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
            End With
            With .Columns(3)
                .Name = "BillNo"
                .HeaderText = "订单号"
                .Width = 120
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.True
                .ReadOnly = True
            End With
            With .Columns(4)
                .Name = "CityName"
                .HeaderText = "所属城市"
                .Width = 80
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
            End With
            With .Columns(5)
                .Name = "BillTotalAmount"
                .HeaderText = "订单金额"
                .Width = 70
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
            End With
            With .Columns(6)
                .Name = "BillPayTotalAmount"
                .HeaderText = "支付金额"
                .Width = 70
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
            End With
            With .Columns(7)
                .Name = "RequestorName"
                .HeaderText = "申请人"
                .Width = 70
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
            End With
            With .Columns(8)
                .Name = "RequestedTime"
                .HeaderText = "申请时间"
                .Width = 120
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
                .DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss"
            End With
            With .Columns(9)
                .Name = "RowID"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .Visible = False
            End With
        End With
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法提交数据。请检查数据库连接。"
            Me.Cursor = Cursors.Default
            Return
        End If

        Me.ecir = Nothing
        Dim succCount As Integer = 0, failCount As Integer = 0

        Try
            If dtList.Select("Selected=1").Length > 0 Then
                For Each drCard As DataRow In dtList.Select("Selected=1")
                    IWebService = New InternetWebService.Service()
                    eci = New InternetWebService.SetExtractingCodeUsedUpdateStatus()
                    guIDClass = New InternetWebService.GuIDClass
                    guIDClass.GuID = frmMain.sGuID
                    With eci
                        .IssuerId = sIssuerId
                        .ExtractingCode = drCard("ExtractingCode").ToString
                        .MobilePhone = drCard("MobilePhone").ToString
                        .MoteStatus = "C"
                        .Cards = ""
                    End With
                    ecir = IWebService.SetExtractingCodeUsedUpdateStatus(eci, guIDClass)
                    If ecir.Code = "00" Then  '提取码使用成功
                        succCount += 1
                    Else
                        failCount += 1
                    End If

                    DB.ModifyTable("update CULECancelExtractingCode set AuditorID = '" & frmMain.sLoginUserID & "',AuditorName = '" & frmMain.sLoginUserRealName & "',AuditorTime = '" & Date.Now.ToString & "',OperationResult = '" & ecir.Msg & "' where OperationID = '" & drCard("RowID").ToString & "'")
                Next

                If failCount > 0 Then
                    MessageBox.Show("到CUL作废提取码成功 " & succCount & " 条，失败 " & failCount & " 条！", "到CUL作废提取码失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    MessageBox.Show("到CUL作废提取码成功 " & succCount & " 条！", "到CUL作废提取码成功！", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("请选择要作废的提取码申请！", "请选择要作废的提取码申请！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

            frmMain.statusText.Text = "就绪。"
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show("因为CUL系统故障，无法进行验证操作！ 下面是CUL系统的内部错误提示：    " & Chr(13) & Chr(13) & ex.Message & Space(4), "出现CUL系统故障！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "因为CUL系统故障，无法进行验证操作！"
            If IWebService IsNot Nothing Then IWebService.Dispose() : IWebService = Nothing
            Me.Cursor = Cursors.Default
        End Try
        DB.Close()
    End Sub

    Private Sub btnHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistory.Click
        'modify code 084:start-------------------------------------------------------------------------
        With frmECancelExtractingCodeHistory
            .ShowDialog()
            .Dispose()
        End With
        'modify code 084:end-------------------------------------------------------------------------
    End Sub
End Class
