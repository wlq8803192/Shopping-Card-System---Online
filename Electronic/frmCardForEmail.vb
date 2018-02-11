Public Class frmCardForEmail

    Dim dtData As DataTable
    Public sOrderNo As String = "", sEType As String = ""

    Private Sub frmCardForEmail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dtData = New DataTable
        dtData.Columns.Add("CardNo", System.Type.GetType("System.String"))
        dtData.Columns.Add("EmailNo", System.Type.GetType("System.String"))
        dtData.Columns.Add("FaceValue", System.Type.GetType("System.Decimal"))

        Me.dgvElectronic.DataSource = Nothing
        initDataGridView()
        initDataGridBinding()
    End Sub

    Private Sub initDataGridView()
        With Me.dgvElectronic
            .AutoGenerateColumns = False
            .ColumnCount = 3
            With .Columns(0)
                .Name = "CardNo"
                .HeaderText = "卡号"
                .Width = 130
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
                .DataPropertyName = "CardNo"
            End With
            With .Columns(1)
                .Name = "EmailNo"
                .HeaderText = "邮箱地址"
                .Width = 110
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
                .DataPropertyName = "EmailNo"
            End With
            With .Columns(2)
                .Name = "FaceValue"
                .HeaderText = "面值"
                .Width = 60
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
                .DataPropertyName = "FaceValue"
                .DefaultCellStyle.Format = "#,0.00"
            End With
        End With
    End Sub

    Private Sub initDataGridBinding()
        Dim DB As New DataBase

        Me.Cursor = Cursors.WaitCursor
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法进行查询。请检查数据库连接。"
            Me.Cursor = Cursors.Default
            Return
        End If

        'Dim dtResult As DataTable = DB.GetDataTable("select T1.TID,T1.StartCardNo,T1.EndCardNo,T1.CardQTY,replace(T1.TelePhone,substring(T1.TelePhone,4,5),'*****') as TelePhone,T1.FaceValue,replace(T2.EmailNo,substring(T2.EmailNo,len(T2.EmailNo) / 4,6),'******') as EmailNo from ElectronicDetails T1,Electronic T2 where T1.EID = T2.EID and T2.OrderNo = '" + sOrderNo + "' and T2.EType = '" + sEType + "'")
        Dim dtResult As DataTable = DB.GetDataTable("select T1.TID,T1.StartCardNo,T1.EndCardNo,T1.CardQTY,T1.TelePhone,T1.FaceValue,T2.EmailNo from ElectronicDetails T1,Electronic T2 where T1.EID = T2.EID and T2.OrderNo = '" + sOrderNo + "' and T2.EType = '" + sEType + "'")
        If dtResult.Rows.Count = 0 Then
            MessageBox.Show("查找不到数据！    ", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Dispose()
            Me.Close()
            Return
        Else
            
            Dim newCard As DataRow, sStartCardNo As String, iCardQTY As Integer, sCardNo As String
            For Each drCard As DataRow In dtResult.Rows
                If drCard("StartCardNo").ToString = "" Then
                    MessageBox.Show("查找不到数据！    ", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Dispose()
                    Me.Close()
                    Return
                End If

                sStartCardNo = drCard("StartCardNo").ToString.Substring(0, 18)
                iCardQTY = drCard("CardQTY") - 1

                For iCard As Integer = 0 To iCardQTY
                    sCardNo = ShoppingCardNo.GetFullCardNo((CLng(sStartCardNo) + iCard).ToString)

                    newCard = dtData.Rows.Add(iCard + 1)
                    newCard("CardNo") = sCardNo
                    newCard("EmailNo") = drCard("EmailNo").ToString
                    newCard("FaceValue") = drCard("FaceValue").ToString

                    newCard.EndEdit()
                Next
            Next

            Me.dgvElectronic.DataSource = dtData
            DB.Close()
            dtResult.Dispose()
            dtResult = Nothing
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        Dim sEmail As String = txtEmail.Text.Trim, sCardNo As String = txtCardNo.Text.Trim.Trim, dtResult As DataTable, newCard As DataRow, iCard As Integer = 0

        If sEmail <> "" OrElse sCardNo <> "" Then
            dtResult = New DataTable
            dtResult.Columns.Add("CardNo", System.Type.GetType("System.String"))
            dtResult.Columns.Add("EmailNo", System.Type.GetType("System.String"))
            dtResult.Columns.Add("FaceValue", System.Type.GetType("System.Decimal"))

            Dim sFilter As String = ""
            If sCardNo = "" AndAlso sEmail <> "" Then
                'Try
                '    sEmail = sEmail.Replace(sEmail.Substring(4, 6), "******").ToString
                'Catch
                'End Try
                sFilter = "EmailNo='" & sEmail & "'"
            ElseIf sCardNo <> "" AndAlso sEmail = "" Then
                sFilter = "CardNo='" & sCardNo & "'"
            ElseIf sCardNo <> "" AndAlso sEmail <> "" Then
                'Try
                '    sEmail = sEmail.Replace(sEmail.Substring(4, 6), "******").ToString
                'Catch
                'End Try
                sFilter = "CardNo='" & sCardNo & "' and EmailNo='" & sEmail & "'"
            End If
            For Each drRow As DataRow In dtData.Select(sFilter)
                newCard = dtResult.Rows.Add(iCard + 1)
                newCard("CardNo") = drRow("CardNo").ToString
                newCard("EmailNo") = drRow("EmailNo").ToString
                newCard("FaceValue") = drRow("FaceValue").ToString
                newCard.EndEdit()
                iCard = iCard + 1
            Next
            Me.dgvElectronic.DataSource = dtResult
        Else
            Me.dgvElectronic.DataSource = dtData
        End If

        Me.Cursor = Cursors.Default
    End Sub
End Class