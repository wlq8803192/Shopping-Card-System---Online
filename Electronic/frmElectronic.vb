Public Class frmElectronic

    Dim dtImportedDetails As New DataTable
    Private dvCULParameter As DataView, sExtraCardBin As String = "65999"

    Private Sub frmElectronic_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dvCULParameter = frmMain.dtLoginStructure.Copy.DefaultView
        dvCULParameter.RowFilter = "AreaType='S'"
        dvCULParameter = dvCULParameter.ToTable(False, "AreaID", "CULCardBin", "CULStoreCode").DefaultView

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

        Me.dtEndDate1.Text = DateAdd(DateInterval.Year, 3, Date.Now)
        Me.dtEndDate2.Text = DateAdd(DateInterval.Year, 3, Date.Now)
    End Sub

    Private Sub btnFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFile.Click
        Dim excelAPP As Object = Nothing
        Try
            excelAPP = GetObject(, "Excel.Application")
        Catch
        End Try

        If excelAPP Is Nothing Then
            Try
                excelAPP = CreateObject("Excel.Application")
                excelAPP.Visible = False
            Catch ex As Exception
                If excelAPP Is Nothing Then
                    MessageBox.Show("您的电脑还未安装 Microsoft Excel。因此，您无法使用该功能。    ", "请先安装 Microsoft Excel 应用程序。", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    MessageBox.Show("您电脑上的 Microsoft Excel 不能正常使用。因此，您无法使用该功能。    ", "请检查 Microsoft Excel 应用程序或重启电脑。", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    excelAPP = Nothing
                End If
                Return
            End Try
        End If

        Dim openFile As New OpenFileDialog(), sFileName As String = "", sWorkSheet As String = ""
        openFile.Title = "请选择想从中导入购物卡号的源文件（Microsoft Excel 文件）："
        openFile.Filter = "源文件（Microsoft Excel 文件）|*.xls"
        openFile.Multiselect = False
        openFile.RestoreDirectory = True

        If openFile.ShowDialog() = Windows.Forms.DialogResult.OK Then sFileName = openFile.FileName
        openFile.Dispose()

        Try '如果已打开，先不保存而关闭，以确保打开的是当前文件
            excelAPP.Windows(sFileName.Substring(sFileName.LastIndexOf("\") + 1)).Activate()
            excelAPP.ActiveWorkBook.Close(False)
        Catch
        End Try

        Try
            If sFileName Is Nothing OrElse sFileName = "" Then
                excelAPP.Quit()
                'MessageBox.Show("请上传源文件！  ", "上传源文件时发生错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                excelAPP = Nothing
                Return
            Else
                excelAPP.DisplayAlerts = False
                excelAPP.Workbooks.Open(sFileName)
                excelAPP.DisplayAlerts = True
            End If
        Catch ex As Exception
            excelAPP.Quit()
            MessageBox.Show("打开源文件时发生错误！具体的错误信息如下：    " & Chr(13) & Chr(13) & ex.Message & Space(4) & Chr(13) & Chr(13) & "请检查错误原因，然后重试。如仍有问题，请联系软件开发人员。    ", "打开源文件时发生错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            excelAPP = Nothing
            Return
        End Try

        If excelAPP.ActiveWorkBook.WorkSheets.Count = 1 Then
            sWorkSheet = excelAPP.ActiveWorkBook.WorkSheets(1).Name
        Else
            With frmSelectWorkSheet
                .sFileName = sFileName
                For Each WorkSheet As Object In excelAPP.ActiveWorkBook.WorkSheets
                    .cbbWorkSheet.Items.Add(WorkSheet.Name)
                Next
                .cbbWorkSheet.SelectedIndex = 0
                If .ShowDialog = Windows.Forms.DialogResult.OK Then sWorkSheet = .cbbWorkSheet.Text
                .Dispose()
            End With

            Try '如果已打开，先不保存而关闭，以确保打开的是当前文件
                excelAPP.Windows(sFileName.Substring(sFileName.LastIndexOf("\") + 1)).Activate()
                excelAPP.ActiveWorkBook.Close(False)
            Catch
            End Try

            Try
                excelAPP.DisplayAlerts = False
                excelAPP.Workbooks.Open(sFileName)
                excelAPP.DisplayAlerts = True
            Catch ex As Exception
                excelAPP.Quit()
                MessageBox.Show("打开源文件时发生错误！具体的错误信息如下：    " & Chr(13) & Chr(13) & ex.Message & Space(4) & "请检查错误原因，然后重试。如仍有问题，请联系软件开发人员。    ", "打开源文件时发生错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                excelAPP = Nothing
                Return
            End Try
        End If

        excelAPP.ActiveWorkBook.WorkSheets(sWorkSheet).Select()
        With excelAPP.ActiveWorkBook.ActiveSheet
            Try

                '手机号码
                If .Range("A1").Value.ToString.Trim <> "手机号码" Then
                    MessageBox.Show("源文件格式存在错误！源文件应该由下面一列组成：    " & Chr(13) & Chr(13) & _
                                    "手机号码    " & Chr(13) & Chr(13) & _
                                    "请确保源文件第一行各单元格的值与上面各列相一致。    ", "源文件格式错误，导入失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    excelAPP = Nothing
                    Return
                End If

                '面值
                If .Range("B1").Value.ToString.Trim <> "面值" Then
                    MessageBox.Show("源文件格式存在错误！源文件应该由下面一列组成：    " & Chr(13) & Chr(13) & _
                                    "面值    " & Chr(13) & Chr(13) & _
                                    "请确保源文件第一行各单元格的值与上面各列相一致。    ", "源文件格式错误，导入失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    excelAPP = Nothing
                    Return
                End If

                '数量
                If .Range("C1").Value.ToString.Trim <> "数量" Then
                    MessageBox.Show("源文件格式存在错误！源文件应该由下面一列组成：    " & Chr(13) & Chr(13) & _
                                    "数量    " & Chr(13) & Chr(13) & _
                                    "请确保源文件第一行各单元格的值与上面各列相一致。    ", "源文件格式错误，导入失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    excelAPP = Nothing
                    Return
                End If

                dtImportedDetails = New DataTable()
                dtImportedDetails.Columns.Add("TelePhone", System.Type.GetType("System.String"))
                dtImportedDetails.Columns.Add("FaceValue", System.Type.GetType("System.String"))
                dtImportedDetails.Columns.Add("CardQTY", System.Type.GetType("System.String"))

                Dim iRows As Integer = .UsedRange.Rows.Count, drDetail As DataRow, iRowID As Int16 = 0, sRepeatData As String = ""
                Dim sTelePhone As String = "", FaceValue As String = "", CardQTY As String = ""
                For iRow As Integer = 2 To iRows
                    drDetail = dtImportedDetails.Rows.Add
                    sTelePhone = .Range("A" & iRow.ToString).Value '手机号码
                    FaceValue = .Range("B" & iRow.ToString).Value '面值
                    CardQTY = .Range("C" & iRow.ToString).Value '数量
                    drDetail("TelePhone") = sTelePhone
                    drDetail("FaceValue") = FaceValue
                    drDetail("CardQTY") = CardQTY

                    '验证输入有效性(手机号码)
                    If sTelePhone = "" Then
                        MessageBox.Show("第 " & iRow & " 行手机号为空！")
                        Return
                    Else
                        '类型验证
                        If Not IsNumeric(sTelePhone) Then
                            MessageBox.Show("第 " & iRow & " 行手机号错误！")
                            Return
                        End If
                        '长度验证
                        If sTelePhone.Length <> 11 Then
                            MessageBox.Show("第 " & iRow & " 行手机号位数错误！")
                            Return
                        End If
                    End If

                    '验证输入有效性(面值)
                    If FaceValue = "" Then
                        MessageBox.Show("第 " & iRow & " 行面值为空！")
                        Return
                    Else
                        Try
                            Dim fValue As Decimal = Decimal.Parse(FaceValue)
                        Catch ex As Exception
                            MessageBox.Show("第 " & iRow & " 行面值输入无效")
                            Return
                        End Try
                    End If

                    '验证输入有效性(数量)
                    If CardQTY = "" Then
                        MessageBox.Show("第 " & iRow & " 行数量为空！")
                        Return
                    Else
                        Try
                            Dim cQTY As Integer = Integer.Parse(CardQTY)
                        Catch ex As Exception
                            MessageBox.Show("第 " & iRow & " 行数量输入无效")
                            Return
                        End Try
                    End If
                    iRowID += 1
                Next

                excelAPP.DisplayAlerts = True
                excelAPP.ActiveWorkBook.Close(False)
                excelAPP.Quit()
                excelAPP = Nothing

                If dtImportedDetails.Rows.Count = 0 Then
                    MessageBox.Show("源文件中不存在数据！：    " & Chr(13) & Chr(13) & "请重新选择源文件（或源工作表）。    ", "源文件中不存在任何数据！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    dtImportedDetails.Dispose() : dtImportedDetails = Nothing
                    Return
                End If

                btnExcute.Enabled = True
                MessageBox.Show("已将源文件中的数据导入到系统中。    ", "已完成导入操作。", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                excelAPP.Quit()
                MessageBox.Show("打开源文件时发生错误！具体的错误信息如下：    " & Chr(13) & Chr(13) & ex.Message & Space(4) & "请检查错误原因，然后重试。如仍有问题，请联系软件开发人员。    ", "打开源文件时发生错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                excelAPP = Nothing
                Return
            End Try
        End With
    End Sub

    Private Sub btnExcute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcute.Click

        If dvCULParameter.Table.Select("CULCardBin='" & sExtraCardBin & "'").Length > 0 Then
        Else
            MessageBox.Show("当前城市没有售卖" & sExtraCardBin & "卡Bin的权限！")
            btnExcute.Enabled = True
            Return
        End If

        Dim DB As New DataBase, sSQL As String = ""
        Dim IsSelect1 As Boolean = TabPage1.CanFocus
        Dim IsSelect2 As Boolean = TabPage2.CanFocus
        If IsSelect1 Then
            '申请方式一
            btnExcute.Enabled = False

            '连接数据库，数据交互
            DB.Open()
            If Not DB.IsConnected Then
                frmMain.statusText.Text = "系统因连接不到数据库而无法进行查询。请检查数据库连接。"
                btnExcute.Enabled = True
                Me.Cursor = Cursors.Default
                Return
            End If

            Dim EID As String = Guid.NewGuid.ToString, sOrderNo As String = getOrderNo(), sACardQTY As Integer = 0, sAAmount As Decimal = 0, sBeginDate As String = dtBeginDate1.Text.Trim(), sEndDate As String = dtEndDate1.Text.Trim()
            If Not dtImportedDetails Is Nothing Then
                If dtImportedDetails.Rows.Count = 0 Then
                    MessageBox.Show("请将源文件中的数据导入到系统中。    ", "导入操作失败。", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    btnExcute.Enabled = True
                    Return
                End If

                If sBeginDate = "" Then
                    MessageBox.Show("电子码开始有效期不能为空！")
                    btnExcute.Enabled = True
                    Return
                End If
                If sEndDate = "" Then
                    MessageBox.Show("电子码结束有效期不能为空！")
                    btnExcute.Enabled = True
                    Return
                End If
                Dim bDate As DateTime = Convert.ToDateTime(sBeginDate), eDate As DateTime = Convert.ToDateTime(sEndDate)
                If DateDiff(DateInterval.Day, bDate, eDate) < 0 Then
                    MessageBox.Show("电子码开始有效期不能超过结束有效期！")
                    btnExcute.Enabled = True
                    Return
                End If
                If DateDiff(DateInterval.Year, bDate, eDate) > 3 Then
                    MessageBox.Show("电子码有效期不能超过3年！")
                    btnExcute.Enabled = True
                    Return
                End If

                Dim iRows As Integer = dtImportedDetails.Rows.Count
                For iRow As Integer = 0 To iRows - 1
                    Dim sTelePhone As String = dtImportedDetails.Rows(iRow)("TelePhone")
                    Dim sFaceValue As Decimal = dtImportedDetails.Rows(iRow)("FaceValue")
                    Dim sCardQTY As Integer = dtImportedDetails.Rows(iRow)("CardQTY")
                    Dim sAmount = sFaceValue * sCardQTY
                    sACardQTY += sCardQTY
                    sAAmount += sAmount

                    sSQL += "insert into ElectronicDetails values (newid(),'" + EID + "',null,null,'" + sTelePhone + "','" + sCardQTY.ToString + "','" + sFaceValue.ToString + "'); "
                Next
            Else
                MessageBox.Show("源文件中不存在数据或重复提交！：    " & Chr(13) & Chr(13) & "请重新选择源文件（或源工作表）。    ", "源文件中不存在任何数据或重复提交！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Close() : Me.ResumeLayout()
                btnExcute.Enabled = True
                Return
            End If

            sSQL += "insert into Electronic values ('" + EID + "',1,null,null,'" + sACardQTY.ToString + "','" + sAAmount.ToString + "','" + sBeginDate + "','" + sEndDate + "','" + sOrderNo + "','" + frmMain.sLoginUserID + "','" + frmMain.sLoginUserRealName + "','" + Date.Now.ToString() + "',0,'" + frmMain.sLoginAreaID + "',null); "
            DB.ModifyTable(sSQL)
            MessageBox.Show("申请成功，提交申请到CUL进行验证！    ", "提交申请到CUL进行验证！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close() : Me.ResumeLayout()
            DB.Close()
        End If
        If IsSelect2 Then
            '申请方式二
            btnExcute.Enabled = False

            '手机号码、邮箱、卡面值、卡数量、电子码有效期
            Dim sMobile As String = txtMobile.Text.Trim(), sEmail As String = txtEmail.Text.Trim(), sFaceValue As Decimal = txtFaceValue2.Text.Trim(), sCardQTY As Integer = txtNum2.Text.Trim(), sBeginDate As String = dtBeginDate2.Text.Trim(), sEndDate As String = dtEndDate2.Text.Trim()

            '验证输入有效性
            If sEmail = "" Then
                MessageBox.Show("邮箱地址为空！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                btnExcute.Enabled = True
                Return
            End If

            If sMobile = "" Then
                MessageBox.Show("手机号为空！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                btnExcute.Enabled = True
                Return
            Else
                If Not IsNumeric(sMobile) Then
                    MessageBox.Show("手机号错误！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    btnExcute.Enabled = True
                    Return
                End If
                If sMobile.Length <> 11 Then
                    MessageBox.Show("手机号位数错误！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    btnExcute.Enabled = True
                    Return
                End If
            End If

            If sBeginDate = "" Then
                MessageBox.Show("电子码开始有效期不能为空！")
                btnExcute.Enabled = True
                Return
            End If
            If sEndDate = "" Then
                MessageBox.Show("电子码结束有效期不能为空！")
                btnExcute.Enabled = True
                Return
            End If
            Dim bDate As DateTime = Convert.ToDateTime(sBeginDate), eDate As DateTime = Convert.ToDateTime(sEndDate)
            If DateDiff(DateInterval.Day, bDate, eDate) < 0 Then
                MessageBox.Show("电子码开始有效期不能超过结束有效期！")
                btnExcute.Enabled = True
                Return
            End If
            If DateDiff(DateInterval.Year, bDate, eDate) > 3 Then
                MessageBox.Show("电子码有效期不能超过3年！")
                btnExcute.Enabled = True
                Return
            End If

            '连接数据库，数据交互
            DB.Open()
            If Not DB.IsConnected Then
                frmMain.statusText.Text = "系统因连接不到数据库而无法进行查询。请检查数据库连接。"
                btnExcute.Enabled = True
                Me.Cursor = Cursors.Default
                Return
            End If

            Dim EID As String = Guid.NewGuid.ToString, sOrderNo As String = getOrderNo()
            'For iRow As Integer = 0 To sCardQTY - 1
            '    sSQL += "insert into ElectronicDetails values (newid(),'" + EID + "',null,'" + sMobile + "','" + sEmail + "',1,'" + sFaceValue.ToString + "'); "
            'Next

            sSQL += "insert into Electronic values ('" + EID + "',2,'" + sMobile + "','" + sEmail + "','" + sCardQTY.ToString + "','" + (sFaceValue * sCardQTY).ToString + "','" + sBeginDate + "','" + sEndDate + "','" + sOrderNo + "','" + frmMain.sLoginUserID + "','" + frmMain.sLoginUserRealName + "','" + Date.Now.ToString() + "',0,'" + frmMain.sLoginAreaID + "',null); "
            DB.ModifyTable(sSQL)
            MessageBox.Show("申请成功，提交申请到CUL进行验证！    ", "提交申请到CUL进行验证！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close() : Me.ResumeLayout()
            DB.Close()
        End If
    End Sub

    Public Function getOrderNo() As String
        Dim DB As New DataBase, sSQL As String = "", sOrderNo As String = "", sFieldID As String = ""

        '连接数据库，数据交互
        DB.Open()
        If Not DB.IsConnected Then
            frmMain.statusText.Text = "系统因连接不到数据库而无法进行查询。请检查数据库连接。"
            Me.Cursor = Cursors.Default
            Return sOrderNo
        End If

        sSQL = "select * from ElectronicID"
        Dim dtResult As DataTable = DB.GetDataTable(sSQL)
        If dtResult.Rows.Count = 0 Then
            DB.ModifyTable("insert into ElectronicID values ('" & Date.Now.ToString("yyyy-MM-dd") & "',1)")
            sFieldID = "001"
        Else
            If dtResult.Rows(0)("CreatorTime").ToString() = Date.Now.ToString("yyyy-MM-dd") Then
                sFieldID = String.Format("{0:000}", Integer.Parse(dtResult.Rows(0)("ID").ToString()) + 1)
                sSQL = "update ElectronicID set ID = " + sFieldID
            Else
                sFieldID = "001"
                sSQL = "update ElectronicID set CreatorTime = '" & Date.Now.ToString("yyyy-MM-dd") & "',ID = 1"
            End If
            DB.ModifyTable(sSQL)
        End If

        sOrderNo = Date.Now.ToString("yyyyMMdd") + sFieldID
        Return sOrderNo
    End Function
End Class