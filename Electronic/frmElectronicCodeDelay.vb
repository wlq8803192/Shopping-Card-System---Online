Public Class frmElectronicCodeDelay

    Private dvCULParameter As DataView

    Private Sub frmElectronicCodeDelay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        For Each drCUL As DataRow In dvCULParameter.Table.Select("CULCardBin Like '84%'")
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "60" & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "92" & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), "94" & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
            dvCULParameter.Table.Rows.Add(drCUL("AreaID"), frmMain.signCardBin & drCUL("CULCardBin").ToString.Substring(2, 3), drCUL("CULStoreCode")).EndEdit()
        Next

        Dim DB As New DataBase(), dtResult As DataTable = Nothing
        DB.Open()
        If DB.IsConnected Then
            dtResult = DB.GetDataTable("select t1.ExtraCardBin,t2.AreaID,isnull(t2.CULStoreCode,0) CULStoreCode from CityExtraCardBin_ELC T1 left join (SELECT S.AreaID,  A.ParentAreaID, A.CULStoreCode FROM AreaScope(" & frmMain.sLoginUserID & ") AS S INNER JOIN AreaList AS A ON S.AreaID = A.AreaID) T2 on t1.CityID = t2.ParentAreaID where T2.AreaID is not null")
            If dtResult Is Nothing Then
            ElseIf dtResult.Rows.Count > 0 Then
                For Each drCUL As DataRow In dtResult.Rows
                    dvCULParameter.Table.Rows.Add(drCUL("AreaID"), drCUL("ExtraCardBin"), drCUL("CULStoreCode")).EndEdit()
                Next
            End If
        End If
        DB.Close()

        dvCULParameter.RowFilter = ""
        dvCULParameter.Table.AcceptChanges()

    End Sub

    Private Sub btnExcute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcute.Click
        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法进行查询。请检查数据库连接。"
            Me.Cursor = Cursors.Default
            Return
        End If

        Dim sMerchantNo As String = dvCULParameter(0)("CULStoreCode").ToString
        Dim sCardNo As String = txtCardNo.Text.Trim(), sValidDate As String = dtValidDate.Text.Trim()
        If sCardNo = "" Then
            MessageBox.Show("卡号不能为空！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        Else
            If Len(sCardNo) <> 19 Then
                MessageBox.Show("卡号长度不正确！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            Else
                If sCardNo.Contains("233665999") Then
                    If sCardNo <> ShoppingCardNo.GetFullCardNo(sCardNo.Substring(0, 18)) Then
                        MessageBox.Show("卡号校验码错误！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                Else
                    MessageBox.Show("卡号不是正确的电子卡类型！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            End If
        End If

        If sValidDate = "" Then
            MessageBox.Show("电子码有效期不能为空！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        Else
            Dim dtResult As DataTable = DB.GetDataTable("select EID from Electronic where EID in (select EID from ElectronicDetails where StartCardNo <= '" & sCardNo & "' and EndCardNo  >= '" & sCardNo & "') and DATEDIFF(year,BeginDate,'" & Convert.ToDateTime(sValidDate).ToString("yyyy-MM-dd") & "') > 3")
            If dtResult.Rows.Count > 0 Then
                MessageBox.Show("电子码有效期不能超过3年！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If

        Dim iElects As InternetElects.Service = Nothing
        Dim postPoneInfo As InternetElects.PostPoneInfo = Nothing, postPoneResponse As InternetElects.PostPoneResponse = Nothing

        Try
            iElects = New InternetElects.Service()
            postPoneInfo = New InternetElects.PostPoneInfo()
            postPoneResponse = New InternetElects.PostPoneResponse()
            postPoneInfo.CardNo = sCardNo
            postPoneInfo.Date = Convert.ToDateTime(sValidDate).ToString("yyyyMMdd")
            postPoneInfo.IssuerId = frmMain.sIssuerId
            postPoneInfo.MerchantNo = sMerchantNo
            postPoneInfo.Operators = frmMain.sLoginUserID

            postPoneResponse = iElects.PostPoneRequest(postPoneInfo) '电子卡延期调用银商接口
            If postPoneResponse.CodeMsg.Code = "00" Then
                frmMain.statusText.Text = "已经将电子码延期提交到CUL系统，并且延期成功。"
                MessageBox.Show("已经将电子码延期提交到CUL系统，并且延期成功。", "Cancellation OK.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                frmMain.statusText.Text = postPoneResponse.CodeMsg.Msg
                MessageBox.Show(postPoneResponse.CodeMsg.Msg, postPoneResponse.CodeMsg.Msg, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception

        End Try

        Dim sSQL As String = "'" & frmMain.sLoginUserID & "','" & Date.Now.ToString() & "','电子码延期','" & sCardNo & "','','','','" & sValidDate & "','" & postPoneResponse.CodeMsg.Msg & "','" & postPoneResponse.CodeMsg.Code & "'"
        DB.ModifyTable("insert into ElectronicLog values (" & sSQL & ")")
        btnExcute.Enabled = False
        DB.Close()
    End Sub
End Class