Imports System.Net
Imports System.Management

Public Class frmLogin

    'modify code 028:
    'date;2014/6/15
    'auther:Hyron bjy 
    'remark:用户登录时，写入当前版本号

    'modify code 030:
    'date;2014/7/1
    'auther:Hyron bjy 
    'remark:将成都开发票功能恢复成全国一致的标准

    'modify code 033:
    'date;2014/7/24
    'auther:Hyron bjy 
    'remark:更改特殊操作用户登录验证方式为guid

    'modify code 034:
    'date;2014/8/18
    'auther:Hyron bjy 
    'remark:城市可设置多个CardBin

    'modify code 044:
    'date;2015/10/19
    'auther:Hyron qm 
    'remark: 增加线下提卡销售单支付方式--瑞泰(获取瑞泰参数)

    'modify code 054:
    'date;2016/02/15
    'auther:BJY 
    'remark:增加65卡销售单，65/61使用新返点规则，去除051的一般销售单售卖65卡功能

    Private bTimes As Byte = 0, sUserID As String = "", blNeedResetPassword As Boolean = False
    Public sComputerName As String = Dns.GetHostName(), sComputerIP As String = "（未知）", sComputerMAC As String = "（未知）"

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim WMI As New ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration")
        For Each WMIOBJ As ManagementObject In WMI.Get
            If CBool(WMIOBJ("IPEnabled")) Then
                sComputerIP = WMIOBJ("IPAddress")(0)
                sComputerMAC = WMIOBJ("MACAddress")
                If sComputerIP.IndexOf("10.") = 0 Then Exit For
            End If
        Next
        WMI = Nothing
        Me.txbUser.Text = My.Settings.LastLoginUser.ToString
        If Me.txbUser.Text <> "" Then Me.txbPassword.Select()
    End Sub

    Private Sub txbUser_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbUser.DoubleClick
        Me.txbUser.SelectAll()
    End Sub

    Private Sub txbUser_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbUser.TextChanged
        Me.btnChangePassword.Visible = (Me.txbUser.Text.Trim <> "")
        Me.btnRequestResetPassword.Visible = False
        Me.btnLogin.Enabled = (Me.txbUser.Text.Trim <> "" AndAlso Me.txbPassword.Text <> "")
    End Sub

    Private Sub txbUser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbUser.KeyDown, cbbUser.KeyDown
        If e.KeyCode = Keys.Enter AndAlso Me.txbUser.Text.Trim <> "" Then
            Me.txbPassword.Select() : Me.txbPassword.SelectAll()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub cbbUser_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cbbUser.MouseDoubleClick
        If e.Button = Windows.Forms.MouseButtons.Left AndAlso e.Clicks = 2 Then
            Me.cbbUser.SelectAll()
        End If
    End Sub

    Private Sub cbbUserr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbUser.TextChanged
        Me.btnChangePassword.Visible = (Me.cbbUser.Text.Trim <> "")
        Me.btnRequestResetPassword.Visible = False
        Me.btnLogin.Enabled = (Me.cbbUser.Text.Trim <> "" AndAlso Me.txbPassword.Text <> "")
    End Sub

    Private Sub txbPassword_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbPassword.DoubleClick
        Me.txbPassword.SelectAll()
    End Sub

    Private Sub txbPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbPassword.KeyDown
        If e.KeyCode = Keys.Enter AndAlso Me.btnLogin.Enabled Then Me.btnLogin.Select() : Me.btnLogin.PerformClick() : e.SuppressKeyPress = True
    End Sub

    Private Sub txbPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txbPassword.TextChanged
        If Me.txbUser.Visible = True Then
            Me.btnLogin.Enabled = (Me.txbUser.Text.Trim <> "" AndAlso Me.txbPassword.Text <> "")
        Else
            Me.btnLogin.Enabled = (Me.cbbUser.Text.Trim <> "" AndAlso Me.txbPassword.Text <> "")
        End If
    End Sub

    Private Sub btnChangePassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangePassword.Click
        With frmChangePassword
            .txbUser.Text = IIf(Me.txbUser.Visible = True, Me.txbUser.Text.Trim, Me.cbbUser.Text.Trim)
            .txbOldPassword.Text = Me.txbPassword.Text
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                MessageBox.Show("密码已修改，请使用该新密码登录系统。    " & Chr(13) & Chr(13) & "Password had been changed, please use this new one to login system.    ", "密码已修改 Password changed.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txbPassword.Text = "" : Me.txbPassword.Select()
                frmMain.statusText.Text = "请登录系统……"
            End If
            .Dispose()
        End With
    End Sub

    Private Sub btnRequestResetPassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRequestResetPassword.Click
        If blNeedResetPassword Then
            MessageBox.Show("重置该用户密码的请求已经存在，您无须重发请求。    " & Chr(13) & _
                            "You don't need send again the request of changing password since it is already existing!    " & Chr(13) & Chr(13) & _
                            "您可以打电话给您的主管以尽快重置您的密码。    " & Chr(13) & _
                            "You can call your manager to reset your password as soon as possible.    ", "无须重发请求 Don't need send request again.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.btnRequestResetPassword.Enabled = False : Me.txbPassword.Select() : Me.txbPassword.SelectAll()
        Else
            Me.Cursor = Cursors.WaitCursor
            frmMain.statusText.Text = "正在发送重置密码请求……"
            frmMain.statusMain.Refresh()

            Dim DB As New DataBase
            DB.Open(True)
            If Not DB.IsConnected Then
                frmMain.statusText.Text = "系统因连接不到数据库而无法发送重置密码请求！"
                Me.Cursor = Cursors.Default
                Return
            End If

            Dim sResettingInfo As String = "Demander Name:  " & IIf(Me.txbUser.Visible = True, Me.txbUser.Text, Me.cbbUser.Text) & Chr(13) & _
                                           "Computer Name:  " & sComputerName & Chr(13) & _
                                           "Computer IP:    " & sComputerIP & Chr(13) & _
                                           "Requested Time: " & Format(Now, "yyyy\/MM\/dd HH:mm:ss")
            If DB.ModifyTable("Update UserExtra Set NeedResetPassword=1, ResettingInfo='" & sResettingInfo.Replace("'", "''") & "' Where UserID=" & sUserID) = -1 Then
                frmMain.statusText.Text = "系统因出现数据库内部错误而无法发送重置密码请求！"
            Else
                DB.ModifyTable("Insert Into OperationLog Values (" & sUserID & ",'" & sComputerName.Replace("'", "''") & "','" & sComputerIP & "','" & sComputerMAC & "',GetDate(),'Request to reset password','User'," & sUserID & ")")
                MessageBox.Show("您的重置密码请求已成功发出。您现在可以打电话给您的主管以尽快重置您的密码。    " & Chr(13) & _
                                "Your request of resetting password had been sent out sucessfully.    " & Chr(13) & _
                                "Now you can call your manager to reset your password as soon as possible.    ", "请求已发出 Request had been sent out.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                frmMain.statusText.Text = "您的重置密码请求已成功发出。"
                Me.btnRequestResetPassword.Enabled = False : Me.txbPassword.Select() : Me.txbPassword.SelectAll()
            End If

            DB.Close()
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "正在登录系统……"
        frmMain.statusMain.Refresh()

        Dim DB As New DataBase()
        DB.Open(True)
        If Not DB.IsConnected Then
            MessageBox.Show("系统因连接不到数据库而无法登录！请检查数据库连接。    ", "无法登录系统！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "无法登录系统！"
            Me.Cursor = Cursors.Default
            Me.DialogResult = DialogResult.Cancel : Return
        End If

        If frmMain.sSSID <> "" AndAlso frmMain.sSSID <> "-1" Then DB.ModifyTable("Exec LogoutSystem @SSID=" & frmMain.sSSID) : frmMain.sSSID = ""

        Dim sUserCode As String = IIf(Me.cbbUser.Visible, Me.cbbUser.Text, Me.txbUser.Text.Trim), sLoginName As String = sUserCode, sSQL As String = "Exec LoginSystem "
        If sUserCode.Length < 8 Then sUserCode = ""
        If sUserCode.IndexOf(" ") = 8 Then sUserCode = sUserCode.Substring(0, 8)
        If sUserCode <> "" Then
            Select Case sUserCode.Substring(0, 1).ToUpper
                Case "H", "T", "R", "C", "S"
                    If Not IsNumeric(sUserCode.Substring(1, 7)) Then sUserCode = ""
                Case Else
                    sUserCode = ""
            End Select
        End If
        If sUserCode = sLoginName Then
            sLoginName = ""
        ElseIf sUserCode <> "" Then
            sLoginName = sLoginName.Substring(9)
        End If

        If sUserCode <> "" Then sSQL = sSQL & "@UserCode='" & sUserCode & "',"
        If sLoginName <> "" Then sSQL = sSQL & "@LoginName='" & sLoginName.Replace("'", "''") & "',"
        If Me.txbPassword.Text <> "" Then sSQL = sSQL & "@Password='" & SecurityText.EncryptData(Me.txbPassword.Text) & "',"
        If bTimes = 4 Then sSQL = sSQL & "@IsLastAllowedLogin=1,"
        sSQL = sSQL + "@ComputerName='" & sComputerName.Replace("'", "''") & "',@ComputerIP='" & sComputerIP & "',@ComputerMAC='" & sComputerMAC & "'"

        'modify code 028:start-------------------------------------------------------------------------
        sSQL = sSQL + ",@LoginVersion = '" & frmMain.SystemVersion & "+" & frmMain.SystemTestVersion.ToString & "'"
        'modify code 028:end-------------------------------------------------------------------------

        'modify code 033:start-------------------------------------------------------------------------
        Dim sGuID_temp As String = System.Guid.NewGuid.ToString
        sSQL = sSQL + ",@GuID = '" & sGuID_temp & "'"
        'modify code 033:end-------------------------------------------------------------------------

        Dim dtResult As DataTable = DB.GetDataTable(sSQL)
        If dtResult Is Nothing Then
            MessageBox.Show("系统因在检索数据时出错而无法登录！请联系软件开发人员。     ", "无法登录系统！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "无法登录系统！"
            Me.Cursor = Cursors.Default
            DB.Close()
            Me.DialogResult = DialogResult.Cancel : Return
        ElseIf dtResult.Rows(0)("Result").ToString = "NightWork" Then
            MessageBox.Show("数据库夜间作业进行中，不允许前台用户登录系统！    " & Chr(13) & Chr(13) & "Sorry! Fibidden to use system since Database night work is running now...    " & Chr(13) & Chr(13) & "（每天凌晨 0～6 点属服务器夜间作业时间，不允许使用系统！）    ", "不允许登录系统！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "不允许登录系统！"
            dtResult.Dispose() : dtResult = Nothing : DB.Close()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel : Return
        ElseIf dtResult.Rows(0)("Result").ToString <> "OK" Then
            Select Case dtResult.Rows(0)("Reason").ToString
                Case "LoginFullName NotFound"
                    MessageBox.Show("登录失败！失败原因：登录用户不存在！    " & Chr(13) & "Login failure since user is not existing!    " & Chr(13) & Chr(13) & "（提示：请单独输入用户编号或登录名称。）    ", "登录失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If Me.txbUser.Visible Then Me.txbUser.Select() : Me.txbUser.SelectAll() Else Me.cbbUser.Select() : Me.cbbUser.SelectAll()
                Case "UserCode NotFound"
                    MessageBox.Show("登录失败！失败原因：用户编号不存在！    " & Chr(13) & "Login failure since user code is not existing!    ", "登录失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If Me.txbUser.Visible Then Me.txbUser.Select() : Me.txbUser.SelectAll() Else Me.cbbUser.Select() : Me.cbbUser.SelectAll()
                Case "LoginName NotFound"
                    MessageBox.Show("登录失败！失败原因：登录名称不存在！    " & Chr(13) & "Login failure since login name is not existing!    ", "登录失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If Me.txbUser.Visible Then Me.txbUser.Select() : Me.txbUser.SelectAll() Else Me.cbbUser.Select() : Me.cbbUser.SelectAll()
                Case "MultiUsers"
                    Dim dtUser As DataTable = dtResult.Copy
                    dtUser.DefaultView.Sort = "UserName"
                    Me.cbbUser.DataSource = dtUser
                    Me.cbbUser.ValueMember = "UserName"
                    Me.cbbUser.DisplayMember = "UserName"
                    Me.cbbUser.SelectedIndex = 0
                    Me.cbbUser.Visible = True : Me.txbUser.Visible = False
                    MessageBox.Show("存在多个相同登录名称但分属不同位置的用户， 请选择其中一个用户。    ", " 用户不明确。", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.cbbUser.Select()
                    Me.cbbUser.DroppedDown = True
                Case "Pending"
                    If Me.txbUser.Visible Then
                        Me.txbUser.Text = dtResult.Rows(0)("UserName").ToString : Me.txbUser.Select() : Me.txbUser.SelectAll()
                    Else
                        Me.cbbUser.Text = dtResult.Rows(0)("UserName").ToString : Me.cbbUser.Select() : Me.cbbUser.SelectAll()
                    End If
                    MessageBox.Show("登录失败！失败原因：该用户还未审核！    " & Chr(13) & "Login failure since the user is not approved yet!    " & Chr(13) & Chr(13) & "（提示：请找相应的主管审核该用户。）    ", "登录失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Case "Not Approved"
                    If Me.txbUser.Visible Then
                        Me.txbUser.Text = dtResult.Rows(0)("UserName").ToString : Me.txbUser.Select() : Me.txbUser.SelectAll()
                    Else
                        Me.cbbUser.Text = dtResult.Rows(0)("UserName").ToString : Me.cbbUser.Select() : Me.cbbUser.SelectAll()
                    End If
                    MessageBox.Show("登录失败！失败原因：该用户未通过审核！    " & Chr(13) & "Login failure since the user was approved failure!    ", "登录失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Case "Stopped"
                    If Me.txbUser.Visible Then
                        Me.txbUser.Text = dtResult.Rows(0)("UserName").ToString : Me.txbUser.Select() : Me.txbUser.SelectAll()
                    Else
                        Me.cbbUser.Text = dtResult.Rows(0)("UserName").ToString : Me.cbbUser.Select() : Me.cbbUser.SelectAll()
                    End If
                    MessageBox.Show("登录失败！失败原因：该用户已被停用！    " & Chr(13) & "Login failure since the user had been stopped!    ", "登录失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Case "Locked"
                    sUserID = dtResult.Rows(0)("UserID").ToString : blNeedResetPassword = dtResult.Rows(0)("NeedResetPassword")
                    If Me.txbUser.Visible Then
                        Me.txbUser.Text = dtResult.Rows(0)("UserName").ToString : Me.txbUser.Enabled = False
                    Else
                        Me.cbbUser.Text = dtResult.Rows(0)("UserName").ToString : Me.cbbUser.Enabled = False
                    End If
                    Me.txbPassword.Enabled = False
                    Me.btnLogin.Enabled = False
                    Me.btnRequestResetPassword.Visible = True : Me.btnRequestResetPassword.Enabled = True : Me.btnRequestResetPassword.Select()
                    MessageBox.Show("登录失败！失败原因：该用户在本机上的登录权限已被冻结！    " & Chr(13) & "Login failure since the user had been locked to login system in this computer!    " & Chr(13) & Chr(13) & "请在您的登录权限解冻后（" & Format(dtResult.Rows(0)("AfterMinutes"), "#,0") & " 分钟后）重试。    " & Chr(13) & "或者按""请求重置密码""按钮向上级主管请求重置密码以便重设密码。    ", "登录失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Case "Password Error"
                    sUserID = dtResult.Rows(0)("UserID").ToString : blNeedResetPassword = dtResult.Rows(0)("NeedResetPassword")
                    If Me.txbUser.Visible Then
                        Me.txbUser.Text = dtResult.Rows(0)("UserName").ToString
                    Else
                        Me.cbbUser.Text = dtResult.Rows(0)("UserName").ToString
                    End If
                    Me.btnRequestResetPassword.Visible = True : Me.btnRequestResetPassword.Enabled = True
                    bTimes += 1
                    If bTimes = 5 Then
                        MessageBox.Show("登录失败！失败原因：密码错误！    " & Chr(13) & "Login failure since the password is wrong!    " & Chr(13) & Chr(13) & "由于您已经连续 5 次输入错误密码，所以您在本机上的登录权限已被冻结。    " & Chr(13) & Chr(13) & "请在您的登录权限解冻后（30 分钟后）重试。    " & Chr(13) & "或者按""请求重置密码""按钮向上级主管请求重置密码以便重设密码。    ", "登录失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        If Me.txbUser.Visible Then Me.txbUser.Enabled = False Else Me.cbbUser.Enabled = False
                        Me.txbPassword.Enabled = False
                        Me.btnLogin.Enabled = False
                        Me.btnRequestResetPassword.Select()
                    Else
                        MessageBox.Show("登录失败！失败原因：密码错误！    " & Chr(13) & "Login failure since the password is wrong!    " & Chr(13) & Chr(13) & "请重新输入密码。注意：您仅剩 " & (5 - bTimes).ToString & " 次输入密码的机会，请谨慎输入！    " & Chr(13) & Chr(13) & "若忘记密码，请按""请求重置密码""按钮向上级主管请求重置密码以便重设密码。    ", "登录失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txbPassword.Select() : Me.txbPassword.SelectAll()
                    End If
                Case Else
                    If Me.txbUser.Visible Then
                        Me.txbUser.Text = dtResult.Rows(0)("UserName").ToString : Me.txbUser.Enabled = False
                    Else
                        Me.cbbUser.Text = dtResult.Rows(0)("UserName").ToString : Me.cbbUser.Enabled = False
                    End If
                    Me.txbPassword.Enabled = False
                    Me.btnLogin.Enabled = False
                    MessageBox.Show("登录系统时出现错误！下面是数据库的内部错误提示：    " & Chr(13) & Chr(13) & dtResult.Rows(0)("Reason").ToString & Space(4) & Chr(13) & Chr(13) & "请放弃登录，在关闭系统后重试。如果仍有问题，请联系软件开发人员。    ", "登录失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Select
            frmMain.statusText.Text = "登录失败！"
            dtResult.Dispose() : dtResult = Nothing : DB.Close()
            Me.Cursor = Cursors.Default
            Return
        End If

        If Me.txbUser.Visible Then
            Me.txbUser.Text = dtResult.Rows(0)("LoginFullName").ToString
        Else
            Me.cbbUser.Text = dtResult.Rows(0)("LoginFullName").ToString
        End If
        frmMain.sSSID = dtResult.Rows(0)("SSID").ToString
        frmMain.sLoginUserID = dtResult.Rows(0)("UserID").ToString
        frmMain.sLoginAreaID = dtResult.Rows(0)("AreaID").ToString
        frmMain.sLoginAreaType = dtResult.Rows(0)("AreaType").ToString
        frmMain.sLoginRoleID = dtResult.Rows(0)("RoleID").ToString
        frmMain.blIsRollout = dtResult.Rows(0)("IsRollout")
        frmMain.sRolloutDate = dtResult.Rows(0)("RolloutDate").ToString
        frmMain.blLockedTrainingMode = dtResult.Rows(0)("LockedTrainingMode")

        frmMain.dtLoginStructure = DB.GetDataTable("Exec LoginStructure " & frmMain.sLoginUserID)
        If frmMain.dtLoginStructure Is Nothing Then
            frmMain.statusText.Text = "登录失败！"
            DB.Close()
            Me.Cursor = Cursors.Default
            Me.DialogResult = DialogResult.Cancel : Return
        End If

        'modify code 034:start-------------------------------------------------------------------------
        Dim dtCityExtraCardBin As DataTable
        dtCityExtraCardBin = GetCityExtraCardBin(DB)
        If Not dtCityExtraCardBin Is Nothing OrElse dtCityExtraCardBin.Rows.Count > 0 Then
            For Each drCityExtraCardBin As DataRow In dtCityExtraCardBin.Rows
                For Each drStore As DataRow In frmMain.dtLoginStructure.Select("ParentAreaID=" & drCityExtraCardBin("CityID"))
                    If InStr(drStore("CULCardBin"), drCityExtraCardBin("ExtraCardBin")) = 0 Then
                        drStore("CULCardBin") = drStore("CULCardBin") & "|" & drCityExtraCardBin("ExtraCardBin")
                        drStore.AcceptChanges()
                    End If
                Next
            Next
        End If

        'modify code 044:start-------------------------------------------------------------------------
        If frmMain.sLoginAreaType = "S" Then
            Dim strsql As String
            strsql = "select * from ShopInfo4RuiTai where ShopNo=" & frmMain.sLoginAreaID
            Dim dtResultRT As DataTable = DB.GetDataTable(strsql)
            If dtResultRT.Rows.Count = 0 Then
                frmMain.sShopId = ""
                frmMain.sShopAccount = ""
                frmMain.sShopPassword = ""
                frmMain.sShopKey = ""
            Else
                frmMain.sShopId = dtResultRT.Rows(0)("ShopId").ToString
                frmMain.sShopAccount = dtResultRT.Rows(0)("ShopAccount").ToString
                frmMain.sShopPassword = dtResultRT.Rows(0)("ShopPassword").ToString
                frmMain.sShopKey = dtResultRT.Rows(0)("ShopKey").ToString
            End If
        End If
        'modify code 044:start-------------------------------------------------------------------------

        'For Each drStore As DataRow In frmMain.dtLoginStructure.Select("ParentAreaID=229") '石家庄
        '    drStore("CULCardBin") = "84810|84817|84818"
        '    drStore.AcceptChanges()
        'Next

        'For Each drStore As DataRow In frmMain.dtLoginStructure.Select("ParentAreaID=52") '郑州与新乡
        '    drStore("CULCardBin") = "84620|84626|84627"
        '    drStore.AcceptChanges()
        'Next

        'For Each drStore As DataRow In frmMain.dtLoginStructure.Select("ParentAreaID=292") '郑州与新乡
        '    drStore("CULCardBin") = "84620|84626|84627"
        '    drStore.AcceptChanges()
        'Next

        'For Each drStore As DataRow In frmMain.dtLoginStructure.Select("ParentAreaID=40") '哈尔滨
        '    drStore("CULCardBin") = "84360|84364" '允许大庆余卡在哈尔滨销售
        '    drStore.AcceptChanges()
        'Next

        'For Each drStore As DataRow In frmMain.dtLoginStructure.Select("ParentAreaID=35") '无锡与江阴
        '    drStore("CULCardBin") = "84270|84277"
        '    drStore.AcceptChanges()
        'Next

        'For Each drStore As DataRow In frmMain.dtLoginStructure.Select("ParentAreaID=330") '无锡与江阴
        '    drStore("CULCardBin") = "84270|84277"
        '    drStore.AcceptChanges()
        'Next

        'For Each drStore As DataRow In frmMain.dtLoginStructure.Select("ParentAreaID=267") '常州和溧阳
        '    drStore("CULCardBin") = "84800|84803"
        '    drStore.AcceptChanges()
        'Next

        'For Each drStore As DataRow In frmMain.dtLoginStructure.Select("ParentAreaID=315") '常州和溧阳
        '    drStore("CULCardBin") = "84800|84803"
        '    drStore.AcceptChanges()
        'Next
        'modify code 034:end-------------------------------------------------------------------------

        frmMain.dtLoginStructure.PrimaryKey = New DataColumn() {frmMain.dtLoginStructure.Columns("AreaID")}

        frmMain.dtAllowedRight = DB.GetDataTable("Exec GetLoginUserRight " & frmMain.sLoginRoleID)
        If frmMain.sLoginAreaType = "S" AndAlso frmMain.dtAllowedRight.Select("RightName In ('SalesBillPRCreate','SalesBillMKCreate','GiftCardActivationCancel','GiftCardOfflineActivate')").Length > 0 Then
            Try
                Dim drCityParameter As DataRow = DB.GetDataTable("Select Use60Card,Use92Card,Use94Card From CityCardParameter Where CityID=" & frmMain.dtLoginStructure.Rows.Find(frmMain.sLoginAreaID)("ParentAreaID").ToString).Rows(0)
                If frmMain.dtAllowedRight.Select("RightName='SalesBillPRCreate'").Length > 0 AndAlso Not drCityParameter("Use92Card") Then
                    frmMain.dtAllowedRight.Select("RightName='SalesBillPRCreate'")(0).Delete()
                End If
                If frmMain.dtAllowedRight.Select("RightName In ('SalesBillMKCreate','UnchargeMKTCard','AffirmUnchargeMKTCard')").Length > 0 AndAlso Not drCityParameter("Use94Card") Then
                    For Each drRight As DataRow In frmMain.dtAllowedRight.Select("RightName In ('SalesBillMKCreate','UnchargeMKTCard','AffirmUnchargeMKTCard')")
                        drRight.Delete()
                    Next
                End If
                If frmMain.dtAllowedRight.Select("RightName In ('GiftCardActivationCancel','GiftCardOfflineActivate','AffirmGiftCardOfflineActivate')").Length > 0 AndAlso Not drCityParameter("Use60Card") Then
                    For Each drRight As DataRow In frmMain.dtAllowedRight.Select("RightName In ('GiftCardActivationCancel','GiftCardOfflineActivate','AffirmGiftCardOfflineActivate')")
                        drRight.Delete()
                    Next
                End If
                frmMain.dtAllowedRight.AcceptChanges()
            Catch
                frmMain.dtAllowedRight = Nothing
            End Try
        End If

        If frmMain.dtAllowedRight Is Nothing Then
            frmMain.statusText.Text = "登录失败！"
            DB.Close()
            Me.Cursor = Cursors.Default
            Me.DialogResult = DialogResult.Cancel : Return
        End If

        If frmMain.dtLoginStructure.Rows.Find(frmMain.sLoginAreaID)("IsClosed") Then
            For Each drRight As DataRow In frmMain.dtAllowedRight.Select("RightName Like '%Create%' Or RightName Like '%Modify%' Or RightName In ('CardActivate','PaymentConfirm')")
                drRight.Delete()
                drRight.AcceptChanges()
            Next
        End If

        frmMain.statusUserName.Text = dtResult.Rows(0)("LoginName").ToString
        frmMain.statusAreaName.Text = dtResult.Rows(0)("AreaName").ToString
        frmMain.statusRoleName.Text = dtResult.Rows(0)("RoleName").ToString
        frmMain.sLoginUserRealName = dtResult.Rows(0)("UserRealName").ToString

        frmMain.blUseInvoiceDevice = False
        'modify code 030:start-------------------------------------------------------------------------
        'If frmMain.dtAllowedRight.Select("RightName In ('SalesBillTicketPrint','SalesBillTicketReprint')").Length > 0 Then
        '    Dim sCityID As String = frmMain.sLoginAreaID
        '    If "|25|".IndexOf("|" & sCityID & "|") = -1 Then sCityID = frmMain.dtLoginStructure.Rows.Find(sCityID)("ParentAreaID").ToString '|272''''''''
        '    If "|25|".IndexOf("|" & sCityID & "|") > -1 Then '测试城市、成都需要使用发票采集器|272''''''''''''
        '        Try
        '            If DB.GetDataTable("Select CanPrintInvoice From InvoicePrintable Where CityID=" & sCityID).Rows(0)(0) Then frmMain.blUseInvoiceDevice = True
        '        Catch
        '        End Try
        '    End If
        'End If
        'modify code 030:end-------------------------------------------------------------------------

        My.Settings.LastLoginUser = dtResult.Rows(0)("LoginFullName").ToString
        My.Settings.Save()

        'modify code 033:start-------------------------------------------------------------------------
        frmMain.sGuID = sGuID_temp
        'modify code 033:end-------------------------------------------------------------------------

        If dtResult.Rows(0)("NeedChangePassword") Then
            MessageBox.Show("系统发现刚才您使用的密码是系统为您分配的随机密码。    " & Chr(13) & _
                            "为确保您能记住密码，请您立即修改密码。否则，您将被拒绝使用系统！    " & Chr(13) & Chr(13) & _
                            "The password you just now used to login system is the random one built by system. " & Chr(13) & _
                            "Please change your password immediately. Otherwize, you will be rejected to use system.    " & Chr(13) & Chr(13) & _
                            "请按""确定""按钮进入""修改密码""窗口 Please press ""OK"" to enter ""Change Password"".    ", "修改密码提示 Prompting of Changing Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            frmMain.statusText.Text = "请修改密码……"
            With frmChangePassword
                .txbUser.Text = IIf(Me.txbUser.Visible = True, Me.txbUser.Text, Me.cbbUser.Text)
                .txbUser.ReadOnly = True
                .txbUser.BackColor = SystemColors.Window
                .txbUser.BackColor = SystemColors.Control
                .txbOldPassword.Text = Me.txbPassword.Text
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    MessageBox.Show("密码已修改，请牢记该密码，在下次登录时请使用该新密码。    " & Chr(13) & Chr(13) & _
                                    "Your password had been changed, please remember it well.     " & Chr(13) & _
                                    "Please use this new password to login system in next time.    ", "密码已修改 Password chanaged sucessfully.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    .Dispose()
                Else
                    MessageBox.Show("由于您并没有及时修改由系统自动生成的随机密码，系统将拒绝您继续使用系统！    " & Chr(13) & Chr(13) & _
                                    "System will reject you to continue to use system since you did not change the password in time.    ", "没有修改密码 Password no change!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    .Dispose()
                    frmMain.statusText.Text = "系统拒绝登录！"
                    dtResult.Dispose() : dtResult = Nothing
                    DB.Close()
                    Me.Cursor = Cursors.Default
                    Me.DialogResult = DialogResult.Cancel : Return
                End If
            End With
        End If

        'modify code 054:start-------------------------------------------------------------------------
        If "|4|6|9|".IndexOf("|" & frmMain.sLoginRoleID & "|") > -1 Then '小区经理,指导店长,城市经理
            Try
                'frmMain.blCanValidateNormalRebate = (DB.GetDataTable("Select Count(*) From CityRebateRuleDetails As D Inner Join CityRebateRule As R On D.RuleID=R.RuleID Inner Join AreaScope(" & frmMain.sLoginUserID & ") As S ON R.CityID=S.AreaID Where R.RuleState=2 And D.ApprovableRoleID=" & frmMain.sLoginRoleID).Rows(0)(0) > 0)
                frmMain.blCanValidateNormalRebate = (DB.GetDataTable("Select Count(*) From CityRebateRuleDetails As D Inner Join CityRebateRule As R On D.RuleID=R.RuleID Inner Join AreaScope(" & frmMain.sLoginUserID & ") As S ON R.CityID=S.AreaID Where R.RuleState=2 And D.ApprovableRoleID=" & frmMain.sLoginRoleID _
                                                                     & " union " _
                                                                     & "Select Count(*) From CrossSellingCityRebateRuleDetails As D Inner Join CrossSellingCityRebateRule As R On D.RuleID=R.RuleID Inner Join AreaScope(" & frmMain.sLoginUserID & ") As S ON R.CityID=S.AreaID Where R.RuleState=2 And D.ApprovableRoleID=" & frmMain.sLoginRoleID).Rows(0)(0) > 0)
            Catch
                frmMain.blCanValidateNormalRebate = False
            End Try
        Else
            frmMain.blCanValidateNormalRebate = False
        End If
        'modify code 054:end-------------------------------------------------------------------------

        If "|9|14|16|".IndexOf("|" & frmMain.sLoginRoleID & "|") > -1 Then '城市经理,售卡员,门店绩效经理
            Dim dtUnconfirmedPayment As DataTable = Nothing
            Try
                dtUnconfirmedPayment = DB.GetDataTable("Exec GetPaymentActivatedButNotYetConfirmed " & frmMain.sLoginUserID).Copy
            Catch
            End Try
            If dtUnconfirmedPayment IsNot Nothing AndAlso dtUnconfirmedPayment.Rows.Count > 0 Then
                With frmUnconfirmedPayment
                    .dgvList.DataSource = dtUnconfirmedPayment
                    .ShowDialog()
                End With
            End If
            If dtUnconfirmedPayment IsNot Nothing Then dtUnconfirmedPayment.Dispose() : dtUnconfirmedPayment = Nothing
        End If

        dtResult.Dispose() : dtResult = Nothing
        DB.Close()
        Me.Cursor = Cursors.Default
        frmMain.statusText.Text = "就绪。"
        Me.DialogResult = DialogResult.OK
    End Sub

    'modify code 034:start-------------------------------------------------------------------------
    Private Function GetCityExtraCardBin(ByVal db As DataBase) As DataTable
        Dim dtDataTable As DataTable
        dtDataTable = db.GetDataTable("select * from CityExtraCardBin")
        Return dtDataTable
    End Function
    'modify code 034:end-------------------------------------------------------------------------

    Private Sub frmLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click
        frmTEST_ConvertPW.ShowDialog()

    End Sub
End Class