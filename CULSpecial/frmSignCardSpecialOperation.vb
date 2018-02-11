Public Class frmSignCardSpecialOperation

    'modify code 069:
    'date:2017/3/2
    'auther:QP
    'remark:修正实名制卡特殊操作,激活撤销

    Private dvCULParameter As DataView, sHolderIdNo As String = ""
    Private selectRow As Integer
    'modify code 050:start-------------------------------------------------------------------------
    '是否转换为新实名制卡的标记
    Private isConvert As Boolean = False
    'modify code 050:end-------------------------------------------------------------------------

    Private Sub initDataGridView()
        With Me.dgvCardInfo
            .AutoGenerateColumns = False
            .ColumnCount = 6
            With .Columns(0)
                .Name = "卡号"
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
                .Name = "余额"
                .HeaderText = "余额"
                .Width = 50
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "#,0.00"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
            End With
            With .Columns(2)
                .Name = "激活日期"
                .HeaderText = "激活日期"
                .Width = 70
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
            End With
            With .Columns(3)
                .Name = "卡状态"
                .HeaderText = "卡状态"
                .Width = 70
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
            End With
            With .Columns(4)
                .Name = "有效期"
                .HeaderText = "有效期"
                .Width = 70
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.False
                .ReadOnly = True
            End With
            With .Columns(5)
                .Name = "售卖店铺"
                .HeaderText = "售卖店铺"
                .Width = 220
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Resizable = DataGridViewTriState.True
                .ReadOnly = True
            End With
            Dim newColumn As DataGridViewButtonColumn

            newColumn = New DataGridViewButtonColumn
            newColumn.Name = ""
            newColumn.UseColumnTextForButtonValue = True
            newColumn.Text = "冻结/解冻"
            newColumn.Width = 65
            .Columns.Add(newColumn)

            newColumn = New DataGridViewButtonColumn
            newColumn.Name = ""
            newColumn.UseColumnTextForButtonValue = True
            newColumn.Text = "换卡/挂失"
            newColumn.Width = 65
            .Columns.Add(newColumn)

            newColumn = New DataGridViewButtonColumn
            newColumn.Name = ""
            newColumn.UseColumnTextForButtonValue = True
            newColumn.Text = "退卡"
            newColumn.Width = 40
            .Columns.Add(newColumn)

            newColumn = New DataGridViewButtonColumn
            newColumn.Name = ""
            newColumn.UseColumnTextForButtonValue = True
            newColumn.Text = "充值"
            newColumn.Width = 40
            .Columns.Add(newColumn)

            newColumn = New DataGridViewButtonColumn
            newColumn.Name = ""
            newColumn.UseColumnTextForButtonValue = True
            newColumn.Text = "修改密码"
            newColumn.Width = 60
            .Columns.Add(newColumn)

            'modify code 069:start-------------------------------------------------------------------------
            newColumn = New DataGridViewButtonColumn
            newColumn.Name = ""
            newColumn.UseColumnTextForButtonValue = True
            newColumn.Text = "激活撤销"
            newColumn.Width = 60
            .Columns.Add(newColumn)
            'modify code 069:end-------------------------------------------------------------------------
        End With
    End Sub

    Private Sub frmSignCardSpecialOperation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        initDataGridView()

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

            'modify code 050:start-------------------------------------------------------------------------
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), frmMain.signCardBin & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
            'modify code 050:end-------------------------------------------------------------------------
        Next
        dvCULParameter.RowFilter = ""
        dvCULParameter.Table.AcceptChanges()
        txtHolderIdNo.Select()
    End Sub

    Private Sub btnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        Dim DB As New DataBase
        Dim dtResult As DataTable

        Me.Cursor = Cursors.WaitCursor
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法进行查询。请检查数据库连接。"
            Me.Cursor = Cursors.Default
            Return
        End If

        If txtHolderIdNo.Text.Trim.Length = 18 Then
            If CheckCredentialsNo(txtHolderIdNo.Text.Trim) Then
                dtResult = DB.GetDataTable("Select CardNo,HolderName,Mobile,Gender from SignCardListNew join HolderInfoList on SignCardListNew.HolderIdNo=HolderInfoList.HolderIdNo where SignCardListNew.HolderIdNo='" & txtHolderIdNo.Text.Trim & "' and CardType='实名制卡' " & _
                                           "union " & _
                                           "Select CardNo,HolderName,Mobile,Gender from SignCardList join HolderInfoList on SignCardList.HolderIdNo=HolderInfoList.HolderIdNo where SignCardList.HolderIdNo='" & txtHolderIdNo.Text.Trim & "' and CardType='实名制卡' order by CardNo asc")
                If dtResult.Rows.Count = 0 Then
                    MessageBox.Show("查无此人！    ", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    sHolderIdNo = ""
                Else
                    sHolderIdNo = txtHolderIdNo.Text.Trim
                    txtName.Text = dtResult.Rows(0)("HolderName")
                    txtMobile.Text = dtResult.Rows(0)("Mobile").ToString.Trim
                    If dtResult.Rows(0)("Gender") = "男" Then
                        radioMale.Checked = True
                    Else
                        radioFemale.Checked = True
                    End If
                    txtName.Enabled = True
                    txtMobile.Enabled = True
                    radioMale.Enabled = True
                    radioFemale.Enabled = True
                    btnSave.Enabled = True

                    dgvCardInfo.DataSource = dtResult
                    DB.Close()
                    dtResult.Dispose()
                    dtResult = Nothing

                    '银联查询
                    For i As Int16 = 0 To dgvCardInfo.RowCount - 1
                        Dim sCardNo As String = dgvCardInfo.Rows(i).Cells("卡号").Value
                        If dvCULParameter.Table.Select("CULCardBin='" & sCardNo.Substring(4, 5) & "'").Length = 0 Then
                            dgvCardInfo.Rows(i).Cells("激活日期").Value() = "非本店卡"
                            dgvCardInfo.Rows(i).Cells("卡状态").Value() = "无法操作"
                        Else
                            Dim sMerchantNo As String = dvCULParameter.Table.Select("CULCardBin='" & sCardNo.Substring(4, 5) & "'")(0)("CULStoreCode").ToString
                            Dim dtTemp As DataTable = ShoppingCardOperation.GetCRFCardState(sMerchantNo, sCardNo, sCardNo)

                            dtTemp.DefaultView.Sort = "CardNo"
                            If dtTemp.Rows(0)("CardNo").ToString = "Error" Then
                                dgvCardInfo.Rows(i).Cells("余额").Value() = "Error"
                                'Me.lblState.Text = "（到CUL系统查询购物卡状态时发生错误！错误提示：" & dtTemp.Rows(0)("StoreName").ToString & "）"
                            Else
                                dgvCardInfo.Rows(i).Cells("余额").Value() = dtTemp.Rows(0)("Balance")
                                dgvCardInfo.Rows(i).Cells("卡状态").Value() = dtTemp.Rows(0)("CardState")

                                If dtTemp.Rows(0)("CardState") <> "未激活" Then
                                    dgvCardInfo.Rows(i).Cells("激活日期").Value() = Format(dtTemp.Rows(0)("ActivatedDate"), "yyyy/MM/dd")
                                    dgvCardInfo.Rows(i).Cells("售卖店铺").Value() = dtTemp.Rows(0)("StoreName")
                                    dgvCardInfo.Rows(i).Cells("有效期").Value() = Format(dtTemp.Rows(0)("EffectiveDate"), "yyyy/MM/dd")
                                End If

                            End If
                        End If
                    Next

                End If
            Else
                MessageBox.Show("身份证号错误！    ", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("身份证号位数错误！    ", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If sHolderIdNo = "" Then
            MessageBox.Show("请先查询！    ", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If txtName.Text.Trim = "" Then
            MessageBox.Show("姓名为空！    ", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If txtMobile.Text.Trim = "" Then
            MessageBox.Show("手机为空！    ", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If txtMobile.Text.Trim.Length <> 11 Then
            MessageBox.Show("手机号位数错误！    ", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not IsNumeric(txtMobile.Text.Trim) Then
            MessageBox.Show("手机号错误！    ", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If MessageBox.Show("确认保存！    ", "提示！", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) <> Windows.Forms.DialogResult.OK Then
            Return
        End If

        Dim strsql As String
        Dim DB As New DataBase

        Me.Cursor = Cursors.WaitCursor
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法进行查询。请检查数据库连接。"
            Me.Cursor = Cursors.Default
            Return
        End If

        If radioMale.Checked Then
            strsql = "update HolderInfoList set Gender='男',HolderName='" & txtName.Text.Trim & "',Mobile='" & txtMobile.Text.Trim & "' where HolderIdNo='" & sHolderIdNo & "'"
        Else
            strsql = "update HolderInfoList set Gender='女',HolderName='" & txtName.Text.Trim & "',Mobile='" & txtMobile.Text.Trim & "' where HolderIdNo='" & sHolderIdNo & "'"
        End If

        If DB.ModifyTable(strsql) = -1 Then
            Me.Cursor = Cursors.Default
            MessageBox.Show("保存失败！    ", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("保存成功！    ", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub dgvCardInfo_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCardInfo.CellContentClick
        If e.RowIndex > -1 AndAlso e.ColumnIndex >= 6 Then
            selectRow = dgvCardInfo.CurrentRow.Index
            If dgvCardInfo.Rows(selectRow).Cells("卡状态").Value <> "已激活" AndAlso e.ColumnIndex <> 6 Then
                MessageBox.Show("对不起，当前卡状态无法进行操作！    ", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Dim cardNo As String = dgvCardInfo.Rows(selectRow).Cells("卡号").Value
                If cardNo IsNot Nothing AndAlso cardNo.Substring(4, 2) <> frmMain.signCardBin Then
                    Dim response As Integer
                    response = MessageBox.Show("对不起，当前卡为旧实名制卡，无法继续操作，请先转换成新实名制卡后再重新操作。", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    'response = MessageBox.Show("对不起，当前卡为旧实名制卡，无法继续操作，请先转换成新实名制卡后再重新操作。是否需要跳转至转换界面？    ", "提示！", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                    'If response = 1 Then
                    '    Me.Dispose()
                    '    isConvert = True
                    '    signCardReplaceCard(cardNo)
                    'End If
                Else
                    Select Case e.ColumnIndex
                        Case 6
                            If dgvCardInfo.Rows(selectRow).Cells("卡状态").Value = "已激活" OrElse dgvCardInfo.Rows(selectRow).Cells("卡状态").Value = "已冻结" Then
                                signCardFreeze(cardNo)
                            Else
                                MessageBox.Show("对不起，当前卡状态无法进行操作！    ", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        Case 7
                            isConvert = False
                            signCardReplaceCard(cardNo)
                        Case 8
                            'modify code 069:start-------------------------------------------------------------------------
                            'signCardCanceActivation(cardNo)
                            signCardReturnCard(cardNo)
                            'modify code 069:end-------------------------------------------------------------------------
                        Case 9
                            signCardRecharge(cardNo)
                        Case 10
                            signCardPassword(cardNo)
                            'modify code 069:start-------------------------------------------------------------------------
                        Case 11
                            signCardCanceActivation(cardNo)
                            'modify code 069:end-------------------------------------------------------------------------
                    End Select
                End If
            End If
        End If
    End Sub

    Private Sub signCardFreeze(ByVal cardNo As String)
        Dim DB As New DataBase
        Dim strsql As String
        If frmMain.dtAllowedRight.Select("RightName='SignCardFreeze'").Length = 0 Then
            MessageBox.Show("对不起，您没有""实名制卡冻结/解冻""的权限！    ", "您不能进行冻结/解冻实名制卡！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        frmFreezeCard.isSignCard = True
        frmFreezeCard.signCardNo = cardNo

        frmFreezeCard.ShowDialog()
        If frmFreezeCard.signCardResult Then
            If dgvCardInfo.Rows(selectRow).Cells("卡状态").Value() = "已冻结" Then
                dgvCardInfo.Rows(selectRow).Cells("卡状态").Value() = "已激活"
            Else
                dgvCardInfo.Rows(selectRow).Cells("卡状态").Value() = "已冻结"
            End If

            DB.Open()
            If Not DB.IsConnected Then
                MessageBox.Show("操作已成功，但系统连接不到数据库而无法进行更新，请及时通知National IT。    ", "操作成功但保存结果失败！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                strsql = "update SignCardListNew set OperationDes='冻结/解冻' where CardNo='" & cardNo & "'"
                If DB.ModifyTable(strsql) = -1 Then
                    MessageBox.Show("操作已成功，但系统在保存结果时出错。    " & Chr(13) & Chr(13) & "请不要对该卡做重复确认，请及时通知National IT。    ", "操作成功但保存结果失败！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
        frmFreezeCard.Dispose()
    End Sub

    Private Sub signCardReplaceCard(ByVal cardNo As String)
        Dim DB As New DataBase
        Dim strsql As String
        If frmMain.dtAllowedRight.Select("RightName='ChangeCard'").Length = 0 Then
            MessageBox.Show("对不起，您没有""购物卡换卡申请""的权限！    ", "您不能申请换卡！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        frmReplaceCardRequirement.isSignCard = True
        'modify code 050:start-------------------------------------------------------------------------
        If isConvert Then
            frmReplaceCardRequirement.isNewSignCard = 1
        Else
            frmReplaceCardRequirement.isNewSignCard = 2
        End If
        'modify code 050:end-------------------------------------------------------------------------
        frmReplaceCardRequirement.signCardNo = cardNo

        frmReplaceCardRequirement.ShowDialog()
        If frmReplaceCardRequirement.signCardResult Then
            dgvCardInfo.Rows(selectRow).Cells("卡状态").Value() = "已冻结"

            DB.Open()
            If Not DB.IsConnected Then
                MessageBox.Show("操作已成功，但系统连接不到数据库而无法进行更新，请及时通知National IT。    ", "操作成功但保存结果失败！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                strsql = "update SignCardListNew set OperationDes='挂失' where CardNo='" & cardNo & "'"
                If DB.ModifyTable(strsql) = -1 Then
                    MessageBox.Show("操作已成功，但系统在保存结果时出错。    " & Chr(13) & Chr(13) & "请不要对该卡做重复确认，请及时通知National IT。    ", "操作成功但保存结果失败！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
        frmReplaceCardRequirement.Dispose()
        btnQuery_Click(Nothing, Nothing)
    End Sub

    'modify code 069:start-------------------------------------------------------------------------
    Private Sub signCardReturnCard(ByVal cardNo As String)
        Dim DB As New DataBase
        Dim strsql As String
        If frmMain.dtAllowedRight.Select("RightName='SignCardReturn'").Length = 0 Then
            MessageBox.Show("对不起，您没有""实名制卡退卡申请""的权限！    ", "您不能申请实名制卡退卡！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        DB.Open()
        If Not DB.IsConnected Then
            MessageBox.Show("操作已成功，但系统连接不到数据库而无法进行更新，请及时通知National IT。    ", "操作成功但保存结果失败！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            strsql = "update SignCardListNew set OperationDes='退卡申请' where CardNo='" & cardNo & "'"
            If DB.ModifyTable(strsql) = -1 Then
                MessageBox.Show("操作已成功，但系统在保存结果时出错。    " & Chr(13) & Chr(13) & "请不要对该卡做重复确认，请及时通知National IT。    ", "操作成功但保存结果失败！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If

        frmCancelActivationRequirement.isSignCard = True
        frmCancelActivationRequirement.signCardNo = cardNo

        frmCancelActivationRequirement.ShowDialog()
        If frmCancelActivationRequirement.signCardResult Then
            dgvCardInfo.Rows(selectRow).Cells("卡状态").Value() = "已冻结"

            DB.Open()
            If Not DB.IsConnected Then
                MessageBox.Show("操作已成功，但系统连接不到数据库而无法进行更新，请及时通知National IT。    ", "操作成功但保存结果失败！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                strsql = "update SignCardListNew set OperationDes='退卡' where CardNo='" & cardNo & "'"
                If DB.ModifyTable(strsql) = -1 Then
                    MessageBox.Show("操作已成功，但系统在保存结果时出错。    " & Chr(13) & Chr(13) & "请不要对该卡做重复确认，请及时通知National IT。    ", "操作成功但保存结果失败！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
        frmCancelActivationRequirement.Dispose()
    End Sub
    'modify code 069:end-------------------------------------------------------------------------

    Private Sub signCardCanceActivation(ByVal cardNo As String)
        Dim DB As New DataBase
        Dim strsql As String
        If frmMain.dtAllowedRight.Select("RightName='SignCardUncharge'").Length = 0 Then
            MessageBox.Show("对不起，您没有""实名制卡激活撤销申请""的权限！    ", "您不能申请实名制卡激活撤销！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        'modify code 069:start-------------------------------------------------------------------------
        DB.Open()
        If Not DB.IsConnected Then
            MessageBox.Show("操作已成功，但系统连接不到数据库而无法进行更新，请及时通知National IT。    ", "操作成功但保存结果失败！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            strsql = "update SignCardListNew set OperationDes='激活撤销申请' where CardNo='" & cardNo & "'"
            If DB.ModifyTable(strsql) = -1 Then
                MessageBox.Show("操作已成功，但系统在保存结果时出错。    " & Chr(13) & Chr(13) & "请不要对该卡做重复确认，请及时通知National IT。    ", "操作成功但保存结果失败！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        'modify code 069:end---------------------------------------------------------------------------

        frmCancelActivationRequirement.isSignCard = True
        frmCancelActivationRequirement.signCardNo = cardNo

        frmCancelActivationRequirement.ShowDialog()
        If frmCancelActivationRequirement.signCardResult Then
            dgvCardInfo.Rows(selectRow).Cells("卡状态").Value() = "已冻结"

            DB.Open()
            If Not DB.IsConnected Then
                MessageBox.Show("操作已成功，但系统连接不到数据库而无法进行更新，请及时通知National IT。    ", "操作成功但保存结果失败！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                'modify code 069:start-------------------------------------------------------------------------
                'strsql = "update SignCardListNew set OperationDes='退卡' where CardNo='" & cardNo & "'"
                strsql = "update SignCardListNew set OperationDes='激活撤销' where CardNo='" & cardNo & "'"
                'modify code 069:end-------------------------------------------------------------------------
                If DB.ModifyTable(strsql) = -1 Then
                    MessageBox.Show("操作已成功，但系统在保存结果时出错。    " & Chr(13) & Chr(13) & "请不要对该卡做重复确认，请及时通知National IT。    ", "操作成功但保存结果失败！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
        frmCancelActivationRequirement.Dispose()
    End Sub

    Private Sub signCardRecharge(ByVal cardNo As String)
        If frmMain.dtAllowedRight.Select("RightName='SalesBillNormalCreate'").Length = 0 Then
            MessageBox.Show("对不起，您没有""创建销售单""的权限！    ", "您不能创建销售单！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        'Me.Cursor = Cursors.WaitCursor
        'frmSelling.isSignCard = True
        'frmSelling.signCardNo = cardNo

        'frmSelling.ShowDialog()
        'frmSelling.Dispose()
        'Me.Cursor = Cursors.Default
        Me.Close()
        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在打开销售单窗口……"
        frmMain.statusMain.Refresh()

        frmSelling.isSignCard = True
        frmSelling.signCardNo = cardNo
        frmSelling.cbbSalesBillType.Items(0) = "实名制卡销售单"
        frmSelling.bNewSalesBillType = 7
        frmSelling.blUsedOldCard = False
        frmSelling.Show()
        If frmSelling.IsHandleCreated Then
            frmSelling.MdiParent = frmMain
            frmSelling.WindowState = FormWindowState.Maximized
            frmSelling.Activate()
        End If

        If frmMain.statusText.Text.IndexOf("……") > -1 Then frmMain.statusText.Text = "就绪。"
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub signCardPassword(ByVal cardNo As String)
        If frmMain.dtAllowedRight.Select("RightName='ResetCardPassword'").Length = 0 Then
            MessageBox.Show("对不起，您没有""重置/修改购物卡密码""的权限！    ", "您不能进行重置/修改购物卡密码！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        frmCardPassword.isSignCard = True
        frmCardPassword.signCardNo = cardNo

        frmCardPassword.ShowDialog()
        frmCardPassword.Dispose()
    End Sub

    Private Sub txtHolderIdNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHolderIdNo.TextChanged
        txtName.Text = ""
        txtMobile.Text = ""
        sHolderIdNo = ""
        radioMale.Checked = True

        txtName.Enabled = False
        txtMobile.Enabled = False
        radioMale.Enabled = False
        radioFemale.Enabled = False
        btnSave.Enabled = False
    End Sub

    '身份证号验证函数
    Private Function CheckCredentialsNo(ByVal aCredentialsNo As String) As Boolean
        If (Not IsNumeric(aCredentialsNo.Substring(0, 17))) OrElse (Not IsDate(aCredentialsNo.Substring(6, 8).Insert(4, "/").Insert(7, "/"))) OrElse aCredentialsNo <> CustomerIDNo.GetFullIDNo(aCredentialsNo.Substring(0, 17)) Then
            Return False
        Else
            Return True
        End If
    End Function
End Class