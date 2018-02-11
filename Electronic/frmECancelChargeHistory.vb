Public Class frmECancelChargeHistory
    Private selectRow As Integer
    Private dtList As DataTable, dtDatas As DataTable

    Private Sub frmECancelChargeHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法打开窗口。请检查数据库连接。"
            Me.Close() : Return
        End If

        Try
            dtDatas = DB.GetDataTable("select distinct OrderNo,CityName,StoreName,RequestorName,RequestedTime,OperationReason,BillTotalAmount,BillPayTotalAmount,AuditorName,AuditorTime from CULECancelCharge where OperationState = 9 order by RequestedTime desc")

            dtList = New DataTable
            dtList.Columns.Add("OrderNo", System.Type.GetType("System.String"))
            dtList.Columns.Add("CityName", System.Type.GetType("System.String"))
            dtList.Columns.Add("StoreName", System.Type.GetType("System.String"))
            dtList.Columns.Add("BillTotalAmount", System.Type.GetType("System.String"))
            dtList.Columns.Add("BillPayTotalAmount", System.Type.GetType("System.String"))
            dtList.Columns.Add("OperationReason", System.Type.GetType("System.String"))
            dtList.Columns.Add("RequestorName", System.Type.GetType("System.String"))
            dtList.Columns.Add("RequestedTime", System.Type.GetType("System.String"))
            dtList.Columns.Add("AuditorName", System.Type.GetType("System.String"))
            dtList.Columns.Add("AuditorTime", System.Type.GetType("System.String"))

            If dtDatas Is Nothing OrElse dtDatas.Rows.Count = 0 Then
                Me.lblNothing.Visible = True
            Else
                Dim newCard As DataRow, iCard As Integer = 0
                For index As Integer = 0 To dtDatas.Rows.Count - 1
                    iCard += 1
                    newCard = dtList.Rows.Add(iCard)
                    newCard("OrderNo") = dtDatas.Rows(index)("OrderNo").ToString
                    newCard("CityName") = dtDatas.Rows(index)("CityName").ToString
                    newCard("StoreName") = dtDatas.Rows(index)("StoreName").ToString
                    newCard("BillTotalAmount") = dtDatas.Rows(index)("BillTotalAmount").ToString
                    newCard("BillPayTotalAmount") = dtDatas.Rows(index)("BillPayTotalAmount").ToString
                    newCard("OperationReason") = dtDatas.Rows(index)("OperationReason").ToString
                    newCard("RequestorName") = dtDatas.Rows(index)("RequestorName").ToString
                    newCard("RequestedTime") = dtDatas.Rows(index)("RequestedTime").ToString
                    newCard("AuditorName") = dtDatas.Rows(index)("AuditorName").ToString
                    newCard("AuditorTime") = dtDatas.Rows(index)("AuditorTime").ToString
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
            With .Columns(0)
                .Name = "OrderNo"
                .HeaderText = "订单号"
                .Width = 140
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
            End With
            With .Columns(1)
                .Name = "CityName"
                .HeaderText = "所属城市"
                .Width = 80
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
            End With
            With .Columns(2)
                .Name = "StoreName"
                .HeaderText = "申请门店"
                .Width = 80
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
            End With
            With .Columns(3)
                .Name = "BillTotalAmount"
                .HeaderText = "订单金额"
                .Width = 70
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
            End With
            With .Columns(4)
                .Name = "BillPayTotalAmount"
                .HeaderText = "支付金额"
                .Width = 70
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
            End With
            With .Columns(5)
                .Name = "OperationReason"
                .HeaderText = "撤销原因"
                .Width = 105
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
            End With
            With .Columns(6)
                .Name = "RequestorName"
                .HeaderText = "申请人"
                .Width = 70
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
            End With
            With .Columns(7)
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
            With .Columns(8)
                .Name = "AuditorName"
                .HeaderText = "确认人"
                .Width = 70
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
            End With
            With .Columns(9)
                .Name = "AuditorTime"
                .HeaderText = "确认时间"
                .Width = 120
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
                .DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss"
            End With
        End With
    End Sub
End Class