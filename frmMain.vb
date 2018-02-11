Imports System.Runtime.InteropServices

'modify code 023:
'date;2014/5/22
'auther:Hyron bjy 
'remark:新增界面，特殊操作，卡号段查询

'modify code 024:
'date;2014/5/27
'auther:Hyron bjy 
'remark:更改数据库连接获取方式为webservice

'modify code 027:
'date;2014/6/13
'auther:Hyron bjy 
'remark:增加测试版本号，自动升级测试版本，必须最新的正式版本才能升级测试版本

'modify code 032:
'date;2014/7/3
'auther:Hyron bjy 
'remark:增加登录成功后的提示框，无内容则不提示，内容设置在webserviceConfig中

'modify code 033:
'date;2014/7/24
'auther:Hyron bjy 
'remark:更改特殊操作用户登录验证方式为guid

'modify code 037:
'date;2014/8/7
'auther:Carreofour Eros
'remark:更改银商报表下载为web

'modify code 040:
'date;2014/11/5
'auther:Hyron bjy 
'remark:新增销售单类型---线下提卡销售单

'modify code 043:
'date;2014/12/29
'auther:Hyron bjy 
'remark: 修改自定义报表为web形式

'modify code 044:
'date;2015/1/9
'auther:Hyron bjy 
'remark: 增加线下提卡销售单支付方式--瑞泰

'modify code 046:
'date;2015/4/1
'auther:Hyron zyx 
'remark:新增销售单类型---实名制卡销售单

'modify code 047:
'date;2014/5/11
'auther:Hyron qm 
'remark:实名制卡特殊操作

'modify code 050:
'date;2015/10/26
'auther:Hyron qm 
'remark:增加实名制卡CardBin，实名制卡非实名制卡售卖分开，修改实名制卡特殊操作

'modify code 054:
'date;2016/02/15
'auther:BJY 
'remark:增加65卡销售单，65/61使用新返点规则，去除051的一般销售单售卖65卡功能

'modify code 072:
'date;2017/05/10
'auther:Qipeng
'remark:增加电子卡团购功能

Public Class frmMain
    Private Declare Function LockWindowUpdate Lib "user32" (ByVal hwndLock As Long) As Long

    Public Const SystemVersion As String = "2.9.7" '更新时修改版本号

    'modify code 027:start-------------------------------------------------------------------------
    Public Const SystemTestVersion As String = "9994" '更新时修改测试版本号
    'modify code 027:end-------------------------------------------------------------------------

    'modify code 024:start-------------------------------------------------------------------------
    'Private sTrainingWebService As String = SecurityText.DecryptData("qfESIwi33U83ObMfQirMJlrPiRIFxKfOfLLpjqnSw86Lnx0bSMTsw4yimUjX92BB7OZFn4sfuTC1eM0mwjQBlRgUbUppzuh98roDTRWO0z199yzGWS5fO4DIKKuvN0JBknPEZpbNJ/tJ3mAyIjPApTjwEdokDFVQW1znLm1NKAV8SR+z1XDnDnNd8nFcV0KV")
    'Private sProducingWebService As String = SecurityText.DecryptData("qfESIwi33U83ObMfQirMJlrPiRIFxKfOfLLpjqnSw87pb7iMBW7B5wTTe288pvA/9MsXsr8guK4o0YBSBiwfUkTPlC2nDfPn48ktaBI+cjjBaiGDpOiNAdvuATHptoKhI/6g9trRAjqrLUoUmNxskJs8tFdkJjiv3FRQoVrJOqqzFP9KsYbtG1O2HnpTrke3")
    'Public sTrainingConnection As String = SecurityText.DecryptData("sbeskhryWyKBseb6t1L0JktP9ubb6I9bLMpsH3ixVgFtFhi+S8dxbqSuPMXsny/uL0BlvRU9hau/BQx/UZ+MovJ23ci6dIk7vfWyjtcsAwPOdm38aItobDhXKrTi/NCuK7AIu/WmxtZDt+1jK3AIWX7iTWIlFVq9OngTpQxbWxP4CELniMz0tavrtma4L4iktEgddlebvxT2w7mpmLZUGCi7iog+vdL4XWTsgLmqc4pdPjqAS9daWftmwsmo3J9WbXSJEWQV8bCokvM8o9FW+ZYY+R4IxUaLP+03S8da/qg=")
    'Public sProducingConnection As String = SecurityText.DecryptData("sbeskhryWyKBseb6t1L0JktP9ubb6I9bLMpsH3ixVgFtFhi+S8dxbqSuPMXsny/uzO/moe7tKAKNgsG2kGfKHioFftrtVNJ1huQxh5eEwjbt7PH1TjgF4clMwnCM3CNp8j0Ib5k+lxpd1GqhjntN36mUQm4eEXMIq8vDyOPaXjeT8eM/z61I78jSP2C3np/kKLQfiWthCzdA5krFcZ4L8Mv0puj/E024PIWwA/CfhfdPyUWC9dpj6CUtEE7CqZmmzgaSxJOczlrasLEUPe/m8vA3ofwXNvgT/I0gKsaxeyM=")
    'Public sReportConnection As String = SecurityText.DecryptData("sbeskhryWyKBseb6t1L0JktP9ubb6I9bLMpsH3ixVgFtFhi+S8dxbqSuPMXsny/ugZF2SLMdqvFP8OagyKqKLeI5KJK9WzKkhfqIJnyJas4nEZsSZVsiHYWWDsZO4FOSEYTeA3zdKCSBxdFxErzrdRc6iRxyy/VcABTgguN56EQD/Gl3NFBE2Pcj1OMVmTQjshdiS2O1Ad4PsoMzEpIljmiWCY0MX80M/WWty2jSaH7JxXgy1yz2sEjMYma/xFCjtUnbdEjzaXtpteLH1eXhU66qNpqR3ZA+G7u+0TPAkKU=")

    'Private sTrainingWebService As String = "Data Source=10.132.201.71;Initial Catalog=ShoppingCard;User ID=NormalUser;Password=nor123"
    'Private sProducingWebService As String = "http://127.0.0.1/ShoppingCardC4WS/C4ShoppingCardService.asmx"
    'Private sTrainingWebService As String = "http://10.132.203.182/ShoppingCardC4WS/C4ShoppingCardService.asmx"
    'Private sProducingWebService As String = "http://10.132.203.182/ShoppingCardC4WS/C4ShoppingCardService.asmx"
    'Public sTrainingConnection As String = "Data Source=10.132.201.71;Initial Catalog=ShoppingCard;User ID=NormalUser;Password=nor123"
    'Public sProducingConnection As String = "Data Source=10.132.201.71;Initial Catalog=ShoppingCard;User ID=NormalUser;Password=nor123"
    'Public sReportConnection As String = "Data Source=10.132.201.71;Initial Catalog=ShoppingCard;User ID=NormalUser;Password=nor123"

    Private sTrainingWebService As String = ""
    Private sProducingWebService As String = ""
    Public sTrainingConnection As String = ""
    Public sProducingConnection As String = ""
    Public sReportConnection As String = ""
    Public sShoppingCardWebService As String = ""
    Public sCulReportConnection As String = ""
    'modify code 046:start-------------------------------------------------------------------------
    Public sFTPConnection As String = ""
    Public sFTPUserName As String = ""
    Public sFTPPassword As String = ""
    'modify code 046:end-------------------------------------------------------------------------
    'modify code 037:start-------------------------------------------------------------------------
    Public sCULReportWeb As String = ""
    'modify code 037:end-------------------------------------------------------------------------
    'modify code 040:start-------------------------------------------------------------------------
    Public sInternetWebService As String = ""
    Public sTrainingInternetWebService As String = ""
    Public sProducingInternetWebService As String = ""
    Public sIssuerId As String = "C000"
    Public dtAreaCode As DataTable = Nothing
    'modify code 040:end-------------------------------------------------------------------------
    'modify code 044:start-------------------------------------------------------------------------
    Public sInternetRuiTaiWebService As String = ""
    Public sTrainingInternetRuiTaiWebService As String = ""
    Public sProducingInternetRuiTaiWebService As String = ""
    Public sShopId As String = ""
    Public sShopAccount As String = ""
    Public sShopPassword As String = ""
    Public sShopKey As String = ""
    'modify code 044:end-------------------------------------------------------------------------
    'modify code 043:start-------------------------------------------------------------------------
    Public sCustomReportWeb As String = ""
    'modify code 043:end-------------------------------------------------------------------------
    Private wbConfig As WebServiceConfig.Service = Nothing
    'modify code 024:end-------------------------------------------------------------------------

    Public sConnectionString As String = "", sWebServiceURL As String = ""
    Public blIsRollout As Boolean = False, sRolloutDate As String = "", blLockedTrainingMode As Boolean = False, blNeedPrompt As Boolean = False, blCanValidateNormalRebate As Boolean = False
    Public sLoginUserID As String = "0", sLoginUserRealName As String = "", sLoginAreaType As String = "H", sLoginAreaID As String = "0", sLoginRoleID As String = "0", sSSID As String = "-1"
    Public dtAllowedRight As DataTable, dtLoginStructure As DataTable, dvCardFaceValue As DataView, dvBigFish As DataView, dvMediumFish As DataView
    Public blHadTestedTicket As Boolean = False, blHadTestedInvoice As Boolean = False

    Public blUseInvoiceDevice As Boolean = False, blInvoiceDeviceOK As Boolean = False

    Private iMessages As Int16 = 0, blBallClosed As Boolean = True

    'modify code 033:start-------------------------------------------------------------------------
    Public sGuID As String = "" '登录用户成功时获取，用于特殊操作验证
    'modify code 033:end-------------------------------------------------------------------------

    'modify code 046:start-------------------------------------------------------------------------
    '定义全局变量
    Private dtCardCostManage As DataTable
    Private dm84CardCost As Decimal = 0
    Private dm86CardCost As Decimal = 0
    Private dm92CardCost As Decimal = 0
    Private dm94CardCost As Decimal = 0
    Private dm60CardCost As Decimal = 0
    Private bl84CanChanged As Boolean = False
    Private bl86CanChanged As Boolean = False
    Private bl92CanChanged As Boolean = False
    Private bl94CanChanged As Boolean = False
    Private bl60CanChanged As Boolean = False
    Private CARD_TYPE_84 As String = "84"
    Private CARD_TYPE_86 As String = "86"
    Private CARD_TYPE_92 As String = "92"
    Private CARD_TYPE_94 As String = "94"
    Private CARD_TYPE_60 As String = "60"
    'modify code 046:end-------------------------------------------------------------------------

    'modify code 050:start-------------------------------------------------------------------------
    '实名制卡CardBin
    Public signCardBin As String = "61"
    Private dmSignCardCost As Decimal = 0
    Private blSignCanChanged As Boolean = False
    'modify code 050:end-------------------------------------------------------------------------

    Private Sub frmMain_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Me.MdiChildren.Length > 1 AndAlso Me.ActiveMdiChild.Equals(frmNavigation) Then
            Try
                Call LockWindowUpdate(Me.Handle)
                For Each theForm As Form In Me.MdiChildren
                    If Not theForm.Equals(frmNavigation) Then theForm.Activate() : Exit For
                Next
            Finally
                Call LockWindowUpdate(0)
            End Try
        End If
    End Sub

    Private Sub frmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If sSSID <> "" AndAlso sSSID <> "-1" Then
            Try
                Dim DB As New DataBase()
                DB.Open(True)
                If DB.IsConnected Then DB.ModifyTable("Exec LogoutSystem @SSID=" & sSSID)
                DB.Close()
            Catch
            End Try
        End If

        Me.Dispose()
    End Sub

    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sOldUserID As String = My.Settings.LastLoginUser
        Dim sText As String = "家乐福购物卡管理系统 （V " & SystemVersion & "）"
        'modify code 027:start-------------------------------------------------------------------------
        If SystemTestVersion > 0 Then
            sText = sText & " 测试版本" & SystemTestVersion.ToString
        End If
        'modify code 027:end-------------------------------------------------------------------------

        'modify code 024:start-------------------------------------------------------------------------
        Dim dtConnection As DataTable
        wbConfig = New WebServiceConfig.Service
        wbConfig.Proxy = Nothing
        dtConnection = wbConfig.GetConnection
        If dtConnection Is Nothing Then
            MessageBox.Show("获取数据库连接失败！", "打开系统失败", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        sTrainingWebService = dtConnection.Rows(0)("sTrainingWebService0913")
        sProducingWebService = dtConnection.Rows(0)("sProducingWebServiceNew0913")
        sTrainingConnection = dtConnection.Rows(0)("sTrainingConnection")
        sProducingConnection = dtConnection.Rows(0)("sProducingConnection")
        sReportConnection = dtConnection.Rows(0)("sReportConnection")
        sShoppingCardWebService = dtConnection.Rows(0)("sShoppingCardWebService")
        sCulReportConnection = dtConnection.Rows(0)("sCulReportConnection")
        'modify code 046:start-------------------------------------------------------------------------
        sFTPConnection = dtConnection.Rows(0)("sFTPConnection")
        sFTPUserName = dtConnection.Rows(0)("sFTPUserName")
        sFTPPassword = dtConnection.Rows(0)("sFTPPassword")
        'modify code 046:end-------------------------------------------------------------------------
        'modify code 037:start-------------------------------------------------------------------------
        sCULReportWeb = dtConnection.Rows(0)("sCULReportWeb")
        'modify code 037:end-------------------------------------------------------------------------
        'modify code 040:start-------------------------------------------------------------------------
        sProducingInternetWebService = dtConnection.Rows(0)("sProducingInternetWebService0913")
        sTrainingInternetWebService = dtConnection.Rows(0)("sTrainingInternetWebService0913")
        'modify code 040:end-------------------------------------------------------------------------
        'modify code 044:start-------------------------------------------------------------------------
        sProducingInternetRuiTaiWebService = dtConnection.Rows(0)("sProducingInternetRuiTaiWebService")
        sTrainingInternetRuiTaiWebService = dtConnection.Rows(0)("sTrainingInternetRuiTaiWebService")
        'modify code 044:end-------------------------------------------------------------------------
        'modify code 043:start-------------------------------------------------------------------------
        sCustomReportWeb = dtConnection.Rows(0)("sCustomReportWeb")
        'modify code 043:end-------------------------------------------------------------------------

        If sTrainingConnection = "" Or sProducingConnection = "" Or sReportConnection = "" Then
            MessageBox.Show("获取数据库连接失败！", "打开系统失败", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        If sTrainingWebService = "" Or sProducingWebService = "" Or sShoppingCardWebService = "" Or sCulReportConnection = "" Then
            MessageBox.Show("获取WebService连接失败！", "打开系统失败", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        'modify code 037:start-------------------------------------------------------------------------
        If sCULReportWeb = "" Then
            MessageBox.Show("获取银商报表下载地址失败！", "打开系统失败", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        'modify code 037:end-------------------------------------------------------------------------
        'modify code 043:start-------------------------------------------------------------------------
        If sCustomReportWeb = "" Then
            MessageBox.Show("获取自定义报表Web地址失败！", "打开系统失败", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        'modify code 043:end-------------------------------------------------------------------------
        'modify code 024:end-------------------------------------------------------------------------

        If My.Settings.IsInTraining = True Then '培训模式
            sText = sText & " - 培训模式"
            sConnectionString = sTrainingConnection
            sWebServiceURL = sTrainingWebService
            'modify code 040:start-------------------------------------------------------------------------
            sInternetWebService = sTrainingInternetWebService
            'modify code 040:end-------------------------------------------------------------------------
            'modify code 044:start-------------------------------------------------------------------------
            sInternetRuiTaiWebService = sTrainingInternetRuiTaiWebService
            'modify code 044:end-------------------------------------------------------------------------
        Else '生产模式
            sConnectionString = sProducingConnection
            sWebServiceURL = sProducingWebService
            'modify code 040:start-------------------------------------------------------------------------
            sInternetWebService = sProducingInternetWebService
            'modify code 040:end-------------------------------------------------------------------------
            'modify code 044:start-------------------------------------------------------------------------
            sInternetRuiTaiWebService = sProducingInternetRuiTaiWebService
            'modify code 044:end-------------------------------------------------------------------------
        End If
        Me.Text = sText

        If frmLogin.ShowDialog = Windows.Forms.DialogResult.Cancel Then frmLogin.Dispose() : Me.Close() : Return
        frmLogin.Dispose()

        'modify code 032:start-------------------------------------------------------------------------
        Dim dtLoginShowMsg As DataTable
        wbConfig = New WebServiceConfig.Service
        wbConfig.Proxy = Nothing
        dtLoginShowMsg = wbConfig.GetLoginShowMsg
        If Not dtLoginShowMsg Is Nothing AndAlso dtLoginShowMsg.Rows(0)("sLoginShowMsg") <> "" Then
            MessageBox.Show(dtLoginShowMsg.Rows(0)("sLoginShowMsg"), "提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        'modify code 032:end-------------------------------------------------------------------------

        Dim bAnswer As DialogResult = Windows.Forms.DialogResult.Yes, sChinese As String = "", sEnglish As String = ""
        Select Case sLoginAreaType
            Case "H"
                sChinese = "总部办公室"
                sEnglish = "Head Office"
            Case "T"
                sChinese = "该大区"
                sEnglish = "This Territory"
            Case "R"
                sChinese = "该小区"
                sEnglish = "This Reggion"
            Case "C"
                sChinese = "该城市"
                sEnglish = "This City"
            Case Else
                sChinese = "该门店"
                sEnglish = "This Store"
        End Select
        If My.Settings.IsInTraining Then
            If blIsRollout Then
                If blLockedTrainingMode Then
                    MessageBox.Show("重要提示 Important information!    " & Chr(13) & Chr(13) & sChinese & "已被安排上线，请切换至生产模式！    " & Chr(13) & Chr(13) & sEnglish & " already is on the schedule to rollout, pls switch to Producing Mode!    ", "请切换至生产模式 Pls switch to Producing Mode!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    bAnswer = MessageBox.Show("重要提示 Important information!    " & Chr(13) & Chr(13) & sChinese & "已被安排上线，是否切换至生产模式？    " & Chr(13) & Chr(13) & sEnglish & " already is on the schedule to rollout, are you want to switch to Producing Mode?    ", "请确认切换至生产模式 Pls confirm to switch to Producing Mode!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    blNeedPrompt = (bAnswer = Windows.Forms.DialogResult.Yes)
                End If
                If bAnswer <> Windows.Forms.DialogResult.No Then
                    If frmSwitchMode.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                        If blLockedTrainingMode Then frmSwitchMode.Dispose() : Me.Close() : Return
                    Else
                        frmSwitchMode.Dispose()
                        Me.menuRelogin.PerformClick()
                        Return
                    End If
                End If
            End If
        ElseIf Not blIsRollout Then
            If sRolloutDate = "" Then
                bAnswer = MessageBox.Show("重要提示 Important information!    " & Chr(13) & Chr(13) & sChinese & "目前只能在培训模式下操作，您要进入培训模式吗？    " & Chr(13) & Chr(13) & sEnglish & " just only can work in Training Mode now, are you want to enter Training Mode?    ", "请确认切换至培训模式 Pls confirm to switch to Training Mode!", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation)
            Else
                bAnswer = MessageBox.Show("重要提示 Important information!    " & Chr(13) & Chr(13) & sChinese & "已被停止上线，目前只能在培训模式下操作，您要进入培训模式吗？    " & Chr(13) & Chr(13) & sEnglish & " already had been stopped to rollout, are you want to enter Training Mode?    ", "请确认切换至培训模式 Pls confirm to switch to Training Mode!", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation)
            End If
            If bAnswer = Windows.Forms.DialogResult.OK Then
                If frmSwitchMode.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                    frmSwitchMode.Dispose()
                    Me.Close()
                Else
                    frmSwitchMode.Dispose()
                    Me.menuRelogin.PerformClick()
                End If
            Else
                Me.Close()
            End If
            Return
        End If

        If sOldUserID <> My.Settings.LastLoginUser Then
            With frmImportantInformation
                If My.Settings.IsInTraining Then
                    .grbProducingMode.Visible = False
                Else
                    .lblOperationMode.Text = "生产模式 Producing Mode"
                    .grbTrainingMode.Visible = False
                End If
                .ShowDialog()
                .Dispose()
            End With
        End If

        Me.menuNavigation.Checked = My.Settings.ShowNavigationWhenStart
        Me.CheckAuthorities()
        If Me.menuNavigation.Checked Then
            frmNavigation.Show()
            frmNavigation.Location = New Point(Me.CalculateLocation(frmNavigation.Size))
        End If

        'If Me.menuMessage.Checked Then Me.menuMessage.Checked = False : Me.menuMessage.PerformClick()
        If Me.menuMessage.Enabled Then Me.menuMessage.PerformClick() ''''
    End Sub

    Private Sub frmMain_MdiChildActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MdiChildActivate
        If Me.MdiChildren.Length > 1 AndAlso Me.ActiveMdiChild.Equals(frmNavigation) Then
            Try
                Call LockWindowUpdate(Me.Handle)
                For Each theForm As Form In Me.MdiChildren
                    If Not theForm.Disposing AndAlso theForm.Equals(frmNavigation) Then theForm.Activate() : Exit For
                Next
            Finally
                Call LockWindowUpdate(0)
            End Try
        End If
    End Sub

    Private Sub frmMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If frmNavigation.IsHandleCreated AndAlso frmNavigation.Visible = True Then frmNavigation.Location = New Point(Me.CalculateLocation(frmNavigation.Size))
    End Sub

    Private Sub menuNavigation_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuNavigation.Click
        Me.menuNavigation.Checked = Not menuNavigation.Checked
        My.Settings.ShowNavigationWhenStart = Me.menuNavigation.Checked : My.Settings.Save()

        If Me.menuNavigation.Checked Then
            For Each frmEach As Form In Me.MdiChildren
                If Not frmEach.Equals(frmNavigation) AndAlso frmEach.WindowState <> FormWindowState.Minimized Then frmEach.WindowState = FormWindowState.Minimized
            Next

            frmNavigation.Show()
            frmNavigation.Location = New Point(Me.CalculateLocation(frmNavigation.Size))
        Else
            frmNavigation.Dispose()
        End If
    End Sub

    Private Sub menuSwitchMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuSwitchMode.Click
        Dim bResult As DialogResult = frmSwitchMode.ShowDialog()
        frmSwitchMode.Dispose()
        If bResult = Windows.Forms.DialogResult.OK Then Me.menuRelogin.PerformClick()
    End Sub

    Private Sub menuRelogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuRelogin.Click
        If frmMessageValidated.IsHandleCreated Then frmMessageValidated.Dispose()
        If frmMessageNeedValidate.IsHandleCreated Then frmMessageNeedValidate.Dispose()
        Me.notifyMessage.Visible = False
        Me.timerMessage.Enabled = False
        Me.menuMessage.Checked = False

        If dvCardFaceValue IsNot Nothing Then dvCardFaceValue.Dispose() : dvCardFaceValue = Nothing
        If dvBigFish IsNot Nothing Then dvBigFish.Dispose() : dvBigFish = Nothing
        If dvMediumFish IsNot Nothing Then dvMediumFish.Dispose() : dvMediumFish = Nothing

        Dim sOldUserID As String = My.Settings.LastLoginUser
        For Each theForm As Form In Me.MdiChildren
            theForm.Close()
        Next
        If Me.MdiChildren.Length > 0 Then Return
        If sSSID <> "" Then
            Try
                Dim DB As New DataBase()
                DB.Open(True)
                If DB.IsConnected Then DB.ModifyTable("Exec LogoutSystem @SSID=" & sSSID)
                DB.Close()
            Catch
            End Try
        End If

        Dim sText As String = "家乐福购物卡管理系统 （V " & SystemVersion & "）"
        'modify code 027:start-------------------------------------------------------------------------
        If SystemTestVersion > 0 Then
            sText = sText & " 测试版本" & SystemTestVersion.ToString
        End If
        'modify code 027:end-------------------------------------------------------------------------
        If My.Settings.IsInTraining = True Then '培训模式
            sText = sText & " - 培训模式"
            sConnectionString = sTrainingConnection
            sWebServiceURL = sTrainingWebService
        Else '生产模式
            sConnectionString = sProducingConnection
            sWebServiceURL = sProducingWebService
        End If
        Me.Text = sText : Me.Refresh()

        If frmLogin.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            frmLogin.Dispose()
            Me.Dispose() : Return
        End If
        frmLogin.Dispose()

        'modify code 032:start-------------------------------------------------------------------------
        Dim dtLoginShowMsg As DataTable
        wbConfig = New WebServiceConfig.Service
        wbConfig.Proxy = Nothing
        dtLoginShowMsg = wbConfig.GetLoginShowMsg
        If Not dtLoginShowMsg Is Nothing AndAlso dtLoginShowMsg.Rows(0)("sLoginShowMsg") <> "" Then
            MessageBox.Show(dtLoginShowMsg.Rows(0)("sLoginShowMsg"), "提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        'modify code 032:end-------------------------------------------------------------------------

        Dim bAnswer As DialogResult = Windows.Forms.DialogResult.Yes, sChinese As String = "", sEnglish As String = ""
        Select Case sLoginAreaType
            Case "H"
                sChinese = "总部办公室"
                sEnglish = "Head Office"
            Case "T"
                sChinese = "该大区"
                sEnglish = "This Territory"
            Case "R"
                sChinese = "该小区"
                sEnglish = "This Reggion"
            Case "C"
                sChinese = "该城市"
                sEnglish = "This City"
            Case Else
                sChinese = "该门店"
                sEnglish = "This Store"
        End Select
        If My.Settings.IsInTraining Then
            If blIsRollout Then
                If blLockedTrainingMode Then
                    MessageBox.Show("重要提示 Important information!    " & Chr(13) & Chr(13) & sChinese & "已被安排上线，请切换至生产模式！    " & Chr(13) & Chr(13) & sEnglish & " already is on the schedule to rollout, pls switch to Producing Mode!    ", "请切换至生产模式 Pls switch to Producing Mode!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf blNeedPrompt Then
                    bAnswer = Windows.Forms.DialogResult.No
                Else
                    bAnswer = MessageBox.Show("重要提示 Important information!    " & Chr(13) & Chr(13) & sChinese & "已被安排上线，是否切换至生产模式？    " & Chr(13) & Chr(13) & sEnglish & " already is on the schedule to rollout, are you want to switch to Producing Mode?    ", "请确认切换至生产模式 Pls confirm to switch to Producing Mode!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                End If
                If bAnswer <> Windows.Forms.DialogResult.No Then
                    If frmSwitchMode.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                        If blLockedTrainingMode Then frmSwitchMode.Dispose() : Me.Close() : Return
                    Else
                        frmSwitchMode.Dispose()
                        Me.menuRelogin.PerformClick()
                        Return
                    End If
                End If
            End If
        ElseIf Not blIsRollout Then
            If sRolloutDate = "" Then
                bAnswer = MessageBox.Show("重要提示 Important information!    " & Chr(13) & Chr(13) & sChinese & "目前只能在培训模式下操作，您要进入培训模式吗？    " & Chr(13) & Chr(13) & sEnglish & " just only can work in Training Mode now, are you want to enter Training Mode?    ", "请确认切换至培训模式 Pls confirm to switch to Training Mode!", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation)
            Else
                bAnswer = MessageBox.Show("重要提示 Important information!    " & Chr(13) & Chr(13) & sChinese & "已被停止上线，目前只能在培训模式下操作，您要进入培训模式吗？    " & Chr(13) & Chr(13) & sEnglish & " already had been stopped to rollout, are you want to enter Training Mode?    ", "请确认切换至培训模式 Pls confirm to switch to Training Mode!", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation)
            End If
            If bAnswer = Windows.Forms.DialogResult.OK Then
                If frmSwitchMode.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                    frmSwitchMode.Dispose()
                    Me.Close()
                Else
                    frmSwitchMode.Dispose()
                    Me.menuRelogin.PerformClick()
                End If
            Else
                Me.Close()
            End If
            Return
        End If

        For Each menuM As ToolStripMenuItem In Me.menuMain.Items
            menuM.Visible = True
            menuM.Enabled = True
            For Each menuS As ToolStripItem In menuM.DropDownItems
                menuS.Visible = True
                menuS.Enabled = True
                Try
                    For Each menuSS As ToolStripItem In CType(menuS, ToolStripMenuItem).DropDownItems
                        menuSS.Visible = True
                        menuSS.Enabled = True
                    Next
                Catch
                End Try
            Next
        Next
        Me.CheckAuthorities()

        If blNeedPrompt OrElse sOldUserID <> My.Settings.LastLoginUser Then
            With frmImportantInformation
                If My.Settings.IsInTraining Then
                    .grbProducingMode.Visible = False
                Else
                    .lblOperationMode.Text = "生产模式 Producing Mode"
                    .grbTrainingMode.Visible = False
                End If
                .ShowDialog()
                .Dispose()
            End With
            blNeedPrompt = False
        End If

        If Me.menuNavigation.Checked Then
            frmNavigation.Show()
            frmNavigation.Location = New Point(Me.CalculateLocation(frmNavigation.Size))
        End If

        'If Me.menuMessage.Checked Then Me.menuMessage.Checked = False : Me.menuMessage.PerformClick()
        If Me.menuMessage.Enabled Then Me.menuMessage.PerformClick() ''''
    End Sub

    Private Sub menuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuExit.Click, menuExitSystem.Click
        If sSSID <> "" Then
            Try
                Dim DB As New DataBase()
                DB.Open(True)
                If DB.IsConnected Then DB.ModifyTable("Exec LogoutSystem @SSID=" & sSSID)
                DB.Close()
            Catch
            End Try
        End If

        Me.Dispose()
    End Sub

    Private Sub menuCityConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuCityConfig.Click
        'If dtAllowedRight.Select("RightName='CityConfigBrowse'").Length = 0 Then
        '    MessageBox.Show("对不起！您没有浏览城市设置的权限。    " & Chr(13) & "Sorry, you have no right to browse city configuration.    ", "您无权浏览城市设置 No right to browse city configuration!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Me.menuCityConfig.Enabled = False
        '    'If frmNavigation.IsHandleCreated Then frmNavigation.pnlCityRule.BackgroundImage = My.Resources.ChequeActivationDisabled
        '    Return
        'End If

        Me.Cursor = Cursors.WaitCursor
        Me.statusText.Text = "正在打开""城市设置""窗口……"
        Me.statusMain.Refresh()

        frmCityConfig.Show()
        If frmCityConfig.IsHandleCreated Then
            frmCityConfig.MdiParent = Me
            frmCityConfig.WindowState = FormWindowState.Normal
            frmCityConfig.Location = Me.CalculateLocation(frmCityConfig.Size)
            frmCityConfig.Activate()
            If frmCityConfig.dgvPending.ReadOnly = False Then
                frmCityConfig.cbbCity.Select()
                frmCityConfig.dgvPending.Select()
                frmCityConfig.dgvPending.CurrentRow.Selected = False
            End If

            If Me.statusText.Text.IndexOf("……") > -1 Then Me.statusText.Text = "就绪。"
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub menuBonusCalculation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuBonusCalculation.Click
        Me.Cursor = Cursors.WaitCursor
        Me.statusText.Text = "正在打开""奖金计算""窗口……"
        Me.statusMain.Refresh()

        frmBonusCalculation.Show()
        If frmBonusCalculation.IsHandleCreated Then
            frmBonusCalculation.MdiParent = Me
            frmBonusCalculation.WindowState = FormWindowState.Normal
            frmBonusCalculation.Location = Me.CalculateLocation(frmBonusCalculation.Size)
            frmBonusCalculation.Activate()
            frmBonusCalculation.trvEmployee.ExpandAll()

            If Me.statusText.Text.IndexOf("……") > -1 Then Me.statusText.Text = "就绪。"
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub menuUserManagement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuUserManagement.Click
        'If dtAllowedRight.Select("RightName='UserBrowse'").Length = 0 Then
        '    MessageBox.Show("对不起！您没有浏览用户的权限。    " & Chr(13) & "Sorry, you have no right to browse user.    ", "您无权浏览用户 No right to browse user!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Me.menuUserManagement.Enabled = False
        '    If frmNavigation.IsHandleCreated Then frmNavigation.pnlUser.BackgroundImage = My.Resources.UserManagementDisabled
        '    Return
        'End If

        Me.Cursor = Cursors.WaitCursor
        Me.statusText.Text = "正在打开""用户管理""窗口……"
        Me.statusMain.Refresh()

        frmUserManagerment.Show()
        If frmUserManagerment.IsHandleCreated Then
            frmUserManagerment.MdiParent = Me
            frmUserManagerment.WindowState = FormWindowState.Maximized
            frmUserManagerment.Activate()
            frmUserManagerment.dgvList.Columns(1).Frozen = True

            If Me.statusText.Text.IndexOf("……") > -1 Then Me.statusText.Text = "就绪。"
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub menuArea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuArea.Click
        'If dtAllowedRight.Select("RightName='AreaBrowse'").Length = 0 Then
        '    MessageBox.Show("对不起！您没有浏览组织结构的权限。    " & Chr(13) & "Sorry, you have no right to browse organization.    ", "您无权浏览组织结构 No right to browse organization!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Me.menuArea.Enabled = False
        '    If frmNavigation.IsHandleCreated Then frmNavigation.pnlLocation.BackgroundImage = My.Resources.LocationDisabled
        '    Return
        'End If

        Me.Cursor = Cursors.WaitCursor
        Me.statusText.Text = "正在打开""区域管理""窗口……"
        Me.statusMain.Refresh()

        frmArea.Show()
        If frmArea.IsHandleCreated Then
            frmArea.MdiParent = Me
            frmArea.WindowState = FormWindowState.Normal
            frmArea.Location = Me.CalculateLocation(frmArea.Size)
            frmArea.Activate()

            If Me.statusText.Text.IndexOf("……") > -1 Then Me.statusText.Text = "就绪。"
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub menuPosition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuPosition.Click
        'If dtAllowedRight.Select("RightName='RoleBrowse'").Length = 0 Then
        '    MessageBox.Show("对不起！您没有浏览职位的权限。    " & Chr(13) & "Sorry, you have no right to browse organization.    ", "您无权浏览职位 No right to browse position!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Me.menuPosition.Enabled = False
        '    If frmNavigation.IsHandleCreated Then frmNavigation.pnlPosition.BackgroundImage = My.Resources.PositionDisabled
        '    Return
        'End If

        Me.Cursor = Cursors.WaitCursor
        Me.statusText.Text = "正在打开""职位管理""窗口……"
        Me.statusMain.Refresh()

        frmPosition.Show()
        If frmPosition.IsHandleCreated Then
            frmPosition.MdiParent = Me
            frmPosition.WindowState = FormWindowState.Normal
            frmPosition.Location = Me.CalculateLocation(frmPosition.Size)
            frmPosition.Activate()

            If Me.statusText.Text.IndexOf("……") > -1 Then Me.statusText.Text = "就绪。"
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub menuEmployeeQuota_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuEmployeeQuota.Click
        Me.Cursor = Cursors.WaitCursor
        Me.statusText.Text = "正在打开""员工额度设置""窗口……"
        Me.statusMain.Refresh()

        frmEmployeeQuota.Show()
        If frmEmployeeQuota.IsHandleCreated Then
            frmEmployeeQuota.MdiParent = Me
            frmEmployeeQuota.WindowState = FormWindowState.Normal
            frmEmployeeQuota.Location = Me.CalculateLocation(frmEmployeeQuota.Size)
            frmEmployeeQuota.Activate()

            If Me.statusText.Text.IndexOf("……") > -1 Then Me.statusText.Text = "就绪。"
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub menuCustomerManagement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuCustomerManagement.Click
        'If dtAllowedRight.Select("RightName='CustomerBrowse'").Length = 0 Then
        '    MessageBox.Show("对不起！您没有浏览客户的权限。    " & Chr(13) & "Sorry, you have no right to browse customer.    ", "您无权浏览客户 No right to browse customer!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Me.menuCustomerManagement.Enabled = False
        '    If frmNavigation.IsHandleCreated Then frmNavigation.pnlCustomer.BackgroundImage = My.Resources.CustomerDisabled
        '    Return
        'End If

        Me.Cursor = Cursors.WaitCursor
        Me.statusText.Text = "正在打开""客户管理""窗口……"
        Me.statusMain.Refresh()

        frmCustomerManagement.Show()
        If frmCustomerManagement.IsHandleCreated Then
            frmCustomerManagement.MdiParent = Me
            frmCustomerManagement.WindowState = FormWindowState.Maximized
            frmCustomerManagement.Activate()
            frmCustomerManagement.dgvList.Columns(1).Frozen = True

            If Me.statusText.Text.IndexOf("……") > -1 Then Me.statusText.Text = "就绪。"
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub menuBusinessType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuBusinessType.Click
        'If dtAllowedRight.Select("RightName='BusinessTypeBrowse'").Length = 0 Then
        '    MessageBox.Show("对不起！您没有浏览商业类型的权限。    " & Chr(13) & "Sorry, you have no right to browse business type.    ", "您无权浏览商业类型 No right to browse business type!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Me.menuBusinessType.Enabled = False
        '    If frmNavigation.IsHandleCreated Then frmNavigation.pnlBusinessType.BackgroundImage = My.Resources.BusinessTypeDisabled
        '    Return
        'End If

        Me.Cursor = Cursors.WaitCursor
        Me.statusText.Text = "正在打开""商业类型""窗口……"
        Me.statusMain.Refresh()

        frmBusinessType.Show()
        If frmBusinessType.IsHandleCreated Then
            frmBusinessType.MdiParent = Me
            frmBusinessType.WindowState = FormWindowState.Normal
            frmBusinessType.Location = Me.CalculateLocation(frmBusinessType.Size)
            frmBusinessType.Activate()

            If Me.statusText.Text.IndexOf("……") > -1 Then Me.statusText.Text = "就绪。"
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub menuInvoiceItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuInvoiceItem.Click
        If dtAllowedRight.Select("RightName='InvoiceItemBrowse'").Length = 0 Then
            MessageBox.Show("对不起！您没有浏览发票品项的权限。    " & Chr(13) & "Sorry, you have no right to browse invoice item.    ", "您无权浏览发票品项 No right to browse invoice item!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.menuInvoiceItem.Enabled = False
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        Me.statusText.Text = "正在打开""发票品项""窗口……"
        Me.statusMain.Refresh()

        frmInvoiceItem.Show()
        If frmInvoiceItem.IsHandleCreated Then
            frmInvoiceItem.MdiParent = Me
            frmInvoiceItem.WindowState = FormWindowState.Normal
            frmInvoiceItem.Location = Me.CalculateLocation(frmInvoiceItem.Size)
            frmInvoiceItem.Activate()

            If Me.statusText.Text.IndexOf("……") > -1 Then Me.statusText.Text = "就绪。"
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub menuInvoiceLayout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuInvoiceLayout.Click
        If dtAllowedRight.Select("RightName='InvoiceLayoutBrowse'").Length = 0 Then
            MessageBox.Show("对不起！您没有浏览发票版面的权限。    " & Chr(13) & "Sorry, you have no right to browse invoice layout.    ", "您无权浏览发票版面 No right to browse invoice Layout!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.menuInvoiceLayout.Enabled = False
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        Me.statusText.Text = "正在打开""发票版面""窗口……"
        Me.statusMain.Refresh()

        frmInvoiceLayout.Show()
        If frmInvoiceLayout.IsHandleCreated Then
            frmInvoiceLayout.MdiParent = Me
            frmInvoiceLayout.WindowState = FormWindowState.Normal
            frmInvoiceLayout.Location = Me.CalculateLocation(frmInvoiceLayout.Size)
            frmInvoiceLayout.Activate()

            If Me.statusText.Text.IndexOf("……") > -1 Then Me.statusText.Text = "就绪。"
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub menuContractManagement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuContractManagement.Click
        'If dtAllowedRight.Select("RightName='ContractBrowse'").Length = 0 Then
        '    MessageBox.Show("对不起！您没有浏览合同的权限。    " & Chr(13) & "Sorry, you have no right to browse contract.    ", "您无权浏览合同 No right to browse contract!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Me.menuContractManagement.Enabled = False
        '    If frmNavigation.IsHandleCreated Then frmNavigation.pnlContract.BackgroundImage = My.Resources.ContractManagementDisabled
        '    Return
        'End If

        Me.Cursor = Cursors.WaitCursor
        Me.statusText.Text = "正在打开""合同管理""窗口……"
        Me.statusMain.Refresh()

        frmContractManagement.Show()
        If frmContractManagement.IsHandleCreated Then
            frmContractManagement.MdiParent = Me
            frmContractManagement.WindowState = FormWindowState.Maximized
            frmContractManagement.Activate()
            frmContractManagement.dgvList.Columns(1).Frozen = True

            If Me.statusText.Text.IndexOf("……") > -1 Then Me.statusText.Text = "就绪。"
            If Me.statusText.Text = "就绪。" Then Me.statusText.Text = "共 " & Format(frmContractManagement.dgvList.RowCount, "#,0") & " 张合同。"
        End If
        Me.Cursor = Cursors.Default
    End Sub

    '通卖合同管理菜单打开事件
    Private Sub menuCrossContractManagement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuCrossContractManagement.Click

        'modify code 067:start-------------------------------------------------------------------------
        Me.Cursor = Cursors.WaitCursor
        Me.statusText.Text = "正在打开""通卖合同管理""窗口……"
        Me.statusMain.Refresh()

        frmCrossContractManagement.Show()
        If frmCrossContractManagement.IsHandleCreated Then
            frmCrossContractManagement.MdiParent = Me
            frmCrossContractManagement.WindowState = FormWindowState.Maximized
            frmCrossContractManagement.Activate()
            frmCrossContractManagement.dgvList.Columns(1).Frozen = True

            If Me.statusText.Text.IndexOf("……") > -1 Then Me.statusText.Text = "就绪。"
            If Me.statusText.Text = "就绪。" Then Me.statusText.Text = "共 " & Format(frmCrossContractManagement.dgvList.RowCount, "#,0") & " 张合同。"
        End If
        Me.Cursor = Cursors.Default
        'modify code 067:end-------------------------------------------------------------------------

    End Sub

    Private Sub menuSalesBillManagement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuSalesBillManagement.Click
        'If dtAllowedRight.Select("RightName='SalesBillBrowse'").Length = 0 Then
        '    MessageBox.Show("对不起！您没有浏览销售单的权限。    " & Chr(13) & "Sorry, you have no right to browse sales bill.    ", "您无权浏览销售单 No right to browse sales bill!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Me.menuSalesBillManagement.Enabled = False
        '    If frmNavigation.IsHandleCreated Then frmNavigation.pnlSelling.BackgroundImage = My.Resources.SellingDisabled
        '    Return
        'End If

        Me.Cursor = Cursors.WaitCursor
        Me.statusText.Text = "正在打开""销售单管理""窗口……"
        Me.statusMain.Refresh()

        ' Call LockWindowUpdate(Me.Handle)
        frmSalesBillManagement.Show()
        If frmSalesBillManagement.IsHandleCreated Then
            frmSalesBillManagement.MdiParent = Me
            frmSalesBillManagement.WindowState = FormWindowState.Maximized
            frmSalesBillManagement.Activate()
            frmSalesBillManagement.dgvList.Columns(0).Visible = False
            frmSalesBillManagement.dgvList.Columns(1).Frozen = True

            If Me.statusText.Text.IndexOf("……") > -1 Then Me.statusText.Text = "就绪。"
        End If
        'Call LockWindowUpdate(0)
        Me.Cursor = Cursors.Default
    End Sub

    'modify code 046:start-------------------------------------------------------------------------
    '添加实名制
    Private Sub menuSignCardSelling_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuSignCardSelling.Click
        If frmSelling.IsHandleCreated Then
            frmSelling.Activate()
            frmSelling.WindowState = FormWindowState.Maximized
            If frmSelling.blIsChanged Then
                Dim bAnswer As DialogResult = MessageBox.Show("是否在新建销售单之前，先保存当前销售单？    ", "当前销售单未保存！", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                If bAnswer = Windows.Forms.DialogResult.Cancel OrElse (bAnswer = Windows.Forms.DialogResult.Yes AndAlso Not frmSelling.SaveChanges()) Then
                    Me.Activate()
                    Me.statusText.Text = "因为存在未保存销售单，所以不能新建销售单。"
                    Return
                End If
            End If

            frmSelling.cbbSalesBillType.Items(0) = "实名制卡销售单"
            frmSelling.sCustomerID = ""
            frmSelling.bNewSalesBillType = 7
            frmSelling.blUsedOldCard = False
            frmSelling.ReCreateSalesBill()
        Else
            Me.Cursor = Cursors.WaitCursor
            Me.statusText.Text = "正在打开销售单窗口……"
            Me.statusMain.Refresh()

            frmSelling.cbbSalesBillType.Items(0) = "实名制卡销售单"
            frmSelling.bNewSalesBillType = 7
            frmSelling.blUsedOldCard = False
            frmSelling.Show()
            If frmSelling.IsHandleCreated Then
                frmSelling.MdiParent = Me
                frmSelling.WindowState = FormWindowState.Maximized
                frmSelling.Activate()
            End If

            If Me.statusText.Text.IndexOf("……") > -1 Then Me.statusText.Text = "就绪。"
            Me.Cursor = Cursors.Default
        End If

        If frmSelling.IsHandleCreated Then
            If frmSelling.dgvNormalCard.CurrentRow IsNot Nothing Then frmSelling.dgvNormalCard.CurrentRow.Selected = False
            If frmSelling.dgvRebateCard.CurrentRow IsNot Nothing Then frmSelling.dgvRebateCard.CurrentRow.Selected = False
            If frmSelling.dgvPayment.CurrentRow IsNot Nothing Then frmSelling.dgvPayment.CurrentRow.Selected = False
        End If
    End Sub

    Private Sub menuDownloadSignCardSalesBillSellingTemp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuDownloadSignCardSalesBillSellingTemp.Click
        If dtAllowedRight.Select("RightName='SalesBillSignCardCreate'").Length = 0 Then
            MessageBox.Show("对不起！您没有实名制卡批量导入的权限。    " & Chr(13) & "Sorry, you have no right to import signcard salesbill from file.    ", "您无权从文件中批量导入 No right to import signcard salesbill from file!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.menuCreateSignCardSalesBillFromFile.Enabled = False
            Return
        End If

        Dim xlsheet As Excel.Worksheet
        Dim xlBook As Excel.Workbook
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

        Dim saveFile As New SaveFileDialog(), sFileName As String = ""
        saveFile.Title = "请选择实名制卡售卖模板的保存路径（Microsoft Excel 文件）："
        saveFile.FileName = "实名制卡售卖模板"
        saveFile.Filter = "模板文件（Microsoft Excel 文件）|*.xls"
        saveFile.RestoreDirectory = True

        If saveFile.ShowDialog() = Windows.Forms.DialogResult.OK Then sFileName = saveFile.FileName
        saveFile.Dispose()
        If sFileName = "" Then
            Me.statusText.Text = "您已经取消了下载实名制卡售卖模板。"
            Me.Cursor = Cursors.Default
            Return
        End If

        'Try
        '    My.Computer.Network.DownloadFile(sFTPConnection & "/实名制卡售卖模板.xls", sFileName, sFTPUserName, sFTPPassword, True, 100, True)
        'Catch ex As Exception
        '    MessageBox.Show("保存模板文件时发生错误！具体的错误信息如下：    " & Chr(13) & Chr(13) & ex.Message & Space(4) & Chr(13) & Chr(13) & "请检查错误原因，然后重试。如仍有问题，请联系软件开发人员。    ", "保存模板文件时发生错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Me.statusText.Text = "保存模板文件时发生错误！"
        '    Me.Cursor = Cursors.Default
        '    Return
        'End Try

        Try '如果已打开，先不保存而关闭，以确保打开的是当前文件
            excelAPP.Windows(sFileName.Substring(sFileName.LastIndexOf("\") + 1)).Activate()
            excelAPP.ActiveWorkBook.Close(False)
        Catch
        End Try

        Try
            excelAPP.DisplayAlerts = False
            xlBook = excelAPP.Workbooks.Add
            xlsheet = xlBook.Worksheets(1)
            xlsheet.Cells.NumberFormatLocal = "@"
            xlsheet.Name = "实名制卡售卖"
            xlsheet.Cells(1, 1) = "城市"
            xlsheet.Cells(1, 2) = "卡号"
            xlsheet.Cells(1, 3) = "面值"
            xlsheet.Cells(1, 4) = "备注"
            xlsheet.Cells(1, 5) = "卡费/张"
            xlsheet.Cells(1, 6) = "持卡人姓名"
            xlsheet.Cells(1, 7) = "性别"
            xlsheet.Cells(1, 8) = "持卡人身份证"
            xlsheet.Cells(1, 9) = "持卡人手机"
            xlBook.SaveAs(sFileName)
            xlBook.Close()
            excelAPP.Quit()
        Catch ex As Exception
            excelAPP.Quit()
            MessageBox.Show("保存模板文件时发生错误！具体的错误信息如下：    " & Chr(13) & Chr(13) & ex.Message & Space(4) & Chr(13) & Chr(13) & "请检查错误原因，然后重试。如仍有问题，请联系软件开发人员。    ", "保存模板文件时发生错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            excelAPP = Nothing
            Me.statusText.Text = "保存模板文件时发生错误！"
            Me.Cursor = Cursors.Default
            Return
        End Try

        Me.statusText.Text = "保存模板文件成功！"

    End Sub

    Private Sub menuCreateSignCardSalesBillFromFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuCreateSignCardSalesBillFromFile.Click
        'Dim isSign As Boolean = False
        Dim dtHolderInfo As New DataTable

        If dtAllowedRight.Select("RightName='SalesBillSignCardCreate'").Length = 0 Then
            MessageBox.Show("对不起！您没有实名制卡批量导入的权限。    " & Chr(13) & "Sorry, you have no right to import signcard salesbill from file.    ", "您无权从文件中批量导入 No right to import signcard salesbill from file!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.menuCreateSignCardSalesBillFromFile.Enabled = False
            Return
        End If

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

        If frmSelling.IsHandleCreated AndAlso frmSelling.blIsChanged Then
            frmSelling.Activate()
            frmSelling.WindowState = FormWindowState.Maximized
            Dim bAnswer As DialogResult = MessageBox.Show("是否在导入文件之前，先保存当前销售单？    ", "当前销售单未保存！", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If bAnswer = Windows.Forms.DialogResult.Cancel OrElse (bAnswer = Windows.Forms.DialogResult.Yes AndAlso Not frmSelling.SaveChanges()) Then
                Me.statusText.Text = "因为存在未保存销售单，所以不能导入文件。"
                Return
            End If
        End If

        Dim sStoreID As String = ""
        Dim sCityID As String = ""
        If sLoginAreaType = "S" Then
            sStoreID = sLoginAreaID
            sCityID = dtLoginStructure.Rows.Find(sLoginAreaID)("ParentAreaID").ToString
        Else
            frmSelectStore.ShowDialog()
            sStoreID = frmSelectStore.cbbStore.SelectedValue
            frmSelectStore.Dispose()
            sCityID = sLoginAreaID
        End If
        SetCardCostByCityID(sCityID)

        Me.Cursor = Cursors.WaitCursor
        Me.statusText.Text = "正在获取门店销售参数……"

        Dim DB As New DataBase()
        DB.Open()
        If Not DB.IsConnected Then
            Me.statusText.Text = "系统因连接不到数据库而无法获取门店销售参数。请检查数据库连接。"
            Me.Cursor = Cursors.Default
            Return
        End If

        Dim drStore As DataRow = Nothing
        Try
            drStore = DB.GetDataTable("Exec GetStoreParameterWhenSellCard " & sStoreID).Rows(0)
            dtHolderInfo = DB.GetDataTable("SELECT * FROM HolderInfoList")
        Catch
            Me.statusText.Text = "系统因在检索数据时出错而无法获取门店销售参数。请联系软件开发人员。"
            DB.Close()
            Me.Cursor = Cursors.Default
            Return
        End Try
        DB.Close()

        Me.statusText.Text = "请选择源文件："
        Me.statusMain.Refresh()

        Dim openFile As New OpenFileDialog(), sFileName As String = "", sWorkSheet As String = ""
        openFile.Title = "请选择想从中导入购物卡号的源文件（Microsoft Excel 文件）："
        openFile.Filter = "源文件（Microsoft Excel 文件）|*.xls"
        openFile.Multiselect = False
        openFile.RestoreDirectory = True

        If openFile.ShowDialog() = Windows.Forms.DialogResult.OK Then sFileName = openFile.FileName
        openFile.Dispose()
        If sFileName = "" Then
            Me.statusText.Text = "您已经取消了导入文件。"
            Me.Cursor = Cursors.Default
            Return
        End If

        Me.statusText.Text = "正在检查源文件……"
        Me.statusMain.Refresh()

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
            MessageBox.Show("打开源文件时发生错误！具体的错误信息如下：    " & Chr(13) & Chr(13) & ex.Message & Space(4) & Chr(13) & Chr(13) & "请检查错误原因，然后重试。如仍有问题，请联系软件开发人员。    ", "打开源文件时发生错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            excelAPP = Nothing
            Me.statusText.Text = "打开源文件时发生错误！"
            Me.Cursor = Cursors.Default
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
            If sWorkSheet = "" Then
                Me.statusText.Text = "您已经取消了导入文件。"
                Me.Cursor = Cursors.Default
                Return
            End If

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
                Me.statusText.Text = "打开源文件时发生错误！"
                Me.Cursor = Cursors.Default
                Return
            End Try
        End If

        Dim dtImportedDetails As New DataTable

        excelAPP.ActiveWorkBook.WorkSheets(sWorkSheet).Select()
        With excelAPP.ActiveWorkBook.ActiveSheet
            'If .Range("A1").Value.ToString.Trim <> "城市" OrElse .Range("B1").Value.ToString.Trim <> "卡号" OrElse .Range("C1").Value.ToString.Trim <> "面值" OrElse .Range("D1").Value.ToString.Trim <> "备注" OrElse .Range("E1").Value.ToString.Trim <> "卡费/张" OrElse .Range("F1").Value.ToString.Trim <> "持卡人姓名" OrElse .Range("G1").Value.ToString.Trim <> "性别" OrElse .Range("H1").Value.ToString.Trim <> "持卡人身份证" OrElse .Range("I1").Value.ToString.Trim <> "持卡人手机" Then
            '    MessageBox.Show("源文件格式存在错误！源文件应该由下面九列组成：    " & Chr(13) & Chr(13) & _
            '                    "城市 + 卡号 + 面值 + 备注 + 卡费/张 + 持卡人姓名 + 性别 + 持卡人身份证 + 持卡人手机    " & Chr(13) & Chr(13) & _
            '                    "请确保源文件第一行各单元格的值与上面各列相一致。    ", "源文件格式错误，导入失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    excelAPP = Nothing
            '    Me.statusText.Text = "源文件格式错误，导入失败！"
            '    Me.Cursor = Cursors.Default
            '    Return
            'End If

            If .Range("A1").Value <> Nothing _
                AndAlso .Range("B1").Value <> Nothing _
                AndAlso .Range("C1").Value <> Nothing _
                AndAlso .Range("D1").Value <> Nothing _
                AndAlso .Range("E1").Value <> Nothing _
                AndAlso .Range("F1").Value <> Nothing _
                AndAlso .Range("G1").Value <> Nothing _
                AndAlso .Range("H1").Value <> Nothing _
                AndAlso .Range("I1").Value <> Nothing _
                AndAlso .Range("A1").Value.ToString.Trim = "城市" _
                AndAlso .Range("B1").Value.ToString.Trim = "卡号" _
                AndAlso .Range("C1").Value.ToString.Trim = "面值" _
                AndAlso .Range("D1").Value.ToString.Trim = "备注" _
                AndAlso .Range("E1").Value.ToString.Trim = "卡费/张" _
                AndAlso .Range("F1").Value.ToString.Trim = "持卡人姓名" _
                AndAlso .Range("G1").Value.ToString.Trim = "性别" _
                AndAlso .Range("H1").Value.ToString.Trim = "持卡人身份证" _
                AndAlso .Range("I1").Value.ToString.Trim = "持卡人手机" Then
                'isSign = True
            Else
                'isSign = False
                MessageBox.Show("源文件格式存在错误！源文件应该由下面九列组成：    " & Chr(13) & Chr(13) & _
                                "城市 + 卡号 + 面值 + 备注 + 卡费/张 + 持卡人姓名 + 性别 + 持卡人身份证 + 持卡人手机    " & Chr(13) & Chr(13) & _
                                "请确保源文件第一行各单元格的值与上面各列相一致。    ", "源文件格式错误，导入失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                excelAPP = Nothing
                Me.statusText.Text = "源文件格式错误，导入失败！"
                Me.Cursor = Cursors.Default
                Return
            End If

            dtImportedDetails.Columns.Add("SalesBillID", System.Type.GetType("System.Int32"))
            dtImportedDetails.Columns.Add("RowID", System.Type.GetType("System.Int16"))
            dtImportedDetails.Columns.Add("ErrorColumn", System.Type.GetType("System.Byte"))
            dtImportedDetails.Columns.Add("CityName", System.Type.GetType("System.String"))
            dtImportedDetails.Columns.Add("CardNo", System.Type.GetType("System.String"))
            dtImportedDetails.Columns.Add("FaceValue", System.Type.GetType("System.String"))
            dtImportedDetails.Columns.Add("SalesDate", System.Type.GetType("System.String"))
            dtImportedDetails.Columns.Add("Remarks", System.Type.GetType("System.String"))
            'If isSign Then
            dtImportedDetails.Columns.Add("CardCost", System.Type.GetType("System.String"))
            dtImportedDetails.Columns.Add("HolderName", System.Type.GetType("System.String"))
            dtImportedDetails.Columns.Add("Gender", System.Type.GetType("System.String"))
            dtImportedDetails.Columns.Add("HolderIdNo", System.Type.GetType("System.String"))
            dtImportedDetails.Columns.Add("Mobile", System.Type.GetType("System.String"))
            'End If
            dtImportedDetails.Columns.Add("ImportedState", System.Type.GetType("System.String"))
            dtImportedDetails.Columns.Add("StateReason", System.Type.GetType("System.String"))

            Dim iRows As Integer = .UsedRange.Rows.Count, drDetail As DataRow, sFirstCity As String = "", sValue As String = "", iRowID As Int16 = -1
            For iRow As Integer = 2 To iRows
                If .Range("A" & iRow.ToString).Value <> "" OrElse .Range("B" & iRow.ToString).Value <> "" OrElse .Range("C" & iRow.ToString).Value <> "" OrElse .Range("D" & iRow.ToString).Value <> "" Then
                    drDetail = dtImportedDetails.Rows.Add
                    iRowID += 1
                    drDetail("RowID") = iRowID
                    sValue = .Range("A" & iRow.ToString).Value
                    drDetail("CityName") = sValue.ToString.Trim
                    If sValue = "" Then
                        drDetail("ErrorColumn") = 3
                        drDetail("ImportedState") = "无法导入"
                        drDetail("StateReason") = "未指明城市"
                    ElseIf (drStore("CityChineseName").ToString.IndexOf(sValue) = -1) AndAlso (drStore("CityEnglishName").ToString.IndexOf(sValue) = -1) AndAlso _
                           (drStore("CityChineseName").ToString <> "" AndAlso sValue.IndexOf(drStore("CityChineseName").ToString) = -1) AndAlso _
                           (drStore("CityEnglishName").ToString <> "" AndAlso sValue.IndexOf(drStore("CityEnglishName").ToString) = -1) Then
                        drDetail("ErrorColumn") = 3
                        drDetail("ImportedState") = "无法导入"
                        drDetail("StateReason") = "城市不存在"
                    ElseIf sFirstCity <> "" AndAlso sValue <> sFirstCity Then
                        drDetail("ErrorColumn") = 3
                        drDetail("ImportedState") = "无法导入"
                        drDetail("StateReason") = "非同一城市"
                    End If

                    sValue = .Range("B" & iRow.ToString).Value
                    If sValue = "" Then
                        If iRow > 2 AndAlso dtImportedDetails.Rows(iRow - 3)("CardNo") <> "" Then
                            sValue = ShoppingCardNo.GetFullCardNo((CDec(dtImportedDetails.Rows(iRow - 3)("CardNo").ToString().Substring(0, 18)) + 1).ToString())
                        End If
                    End If

                    drDetail("CardNo") = sValue.ToString.Trim
                    If drDetail("ImportedState").ToString = "" Then
                        'modify code 050:start-------------------------------------------------------------------------
                        Dim drStore2 As DataRow = dtLoginStructure.Rows.Find(sStoreID)
                        Dim sSignCardBin As String
                        sSignCardBin = signCardBin & drStore2("CULCardBin").ToString.Substring(2)
                        sSignCardBin = sSignCardBin.Replace("|84", "|" & signCardBin)
                        'modify code 050:start-------------------------------------------------------------------------
                        If sValue = "" Then
                            drDetail("ErrorColumn") = 4
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "未指明卡号"
                        ElseIf Not IsNumeric(sValue) OrElse sValue.Length <> 19 Then
                            drDetail("ErrorColumn") = 4
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "卡号错误（应由19个数字组成）"
                        ElseIf sValue <> ShoppingCardNo.GetFullCardNo(sValue.Substring(0, 18)) Then
                            drDetail("ErrorColumn") = 4
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "卡号错误（验证码错误）"
                        ElseIf sValue.Substring(0, 4) <> "2336" Then
                            drDetail("ErrorColumn") = 4
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "卡号非法（非银商卡）"
                            'modify code 004:start-------------------------------------------------------------------------
                            'ElseIf sValue.Substring(4, 5) <> drStore("CULCardBin").ToString Then
                            'ElseIf sValue.Substring(4, 5) <> drStore("CULCardBin").ToString And sValue.Substring(4, 5) <> "60" & drStore("CULCardBin").ToString.Substring(2, 3) Then
                            'ElseIf sValue.Substring(4, 5) <> signCardBin & drStore("CULCardBin").ToString.Substring(2, 3) Then
                        ElseIf sSignCardBin.IndexOf(sValue.Substring(4, 5)) = -1 Then
                            'modify code 004:start-------------------------------------------------------------------------
                            drDetail("ErrorColumn") = 4
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "卡号非法（银商卡Bin码（第5至9位）不符）"
                        ElseIf dtImportedDetails.Select("CardNo='" & sValue & "'").Length > 1 Then
                            drDetail("ErrorColumn") = 4
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "卡号重复"
                            'ElseIf sValue.IndexOf("233684") <> 0 AndAlso sValue.IndexOf("233660") <> 0 Then
                            '    drDetail("ErrorColumn") = 4
                            '    drDetail("ImportedState") = "无法导入"
                            '    drDetail("StateReason") = "实名卡销售仅限于84卡及60卡"
                        End If
                    End If

                    sValue = .Range("C" & iRow.ToString).Value
                    If sValue = "" OrElse Not IsNumeric(sValue) Then
                        drDetail("FaceValue") = sValue.ToString.Trim
                    Else
                        drDetail("FaceValue") = Format(CDec(sValue), "#,0.00")
                    End If
                    If drDetail("ImportedState").ToString = "" Then
                        Dim dmMaxValue As Decimal = drStore("MaxFaceValue")
                        'If isSign Then
                        dmMaxValue = 5000
                        'End If
                        If sValue = "" Then
                            drDetail("ErrorColumn") = 5
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "未指明面值"
                        ElseIf Not IsNumeric(sValue) Then
                            drDetail("ErrorColumn") = 5
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "面值错误（应该是数值）"
                        ElseIf CDec(sValue) = 0 Then
                            drDetail("ErrorColumn") = 5
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "面值错误（应该大于零）"
                        ElseIf CDec(sValue) > dmMaxValue Then
                            drDetail("ErrorColumn") = 5
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "面值错误（已经超过最大许可面值" & Format(dmMaxValue, "#,0.00") & "元）"
                        End If
                    End If

                    sValue = .Range("E" & iRow.ToString).Value
                    Dim iValue As Integer = 0
                    If sValue = "" OrElse Not Integer.TryParse(sValue, iValue) Then
                        drDetail("CardCost") = sValue.ToString.Trim
                    Else
                        drDetail("CardCost") = iValue.ToString.Trim
                    End If

                    If drDetail("ImportedState").ToString = "" Then
                        If sValue = "" Then
                            drDetail("ErrorColumn") = 8
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "未指明卡成本"
                        ElseIf Not Integer.TryParse(sValue, iValue) Then
                            drDetail("ErrorColumn") = 8
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "卡成本应为整数"
                            'modify code 050:start-------------------------------------------------------------------------
                            'ElseIf drDetail("CardNo").ToString.IndexOf("233684") = 0 Then
                            '    If bl84CanChanged Then
                            '        If iValue > dm84CardCost Then
                            '            drDetail("ErrorColumn") = 8
                            '            drDetail("ImportedState") = "无法导入"
                            '            drDetail("StateReason") = "卡成本超过指定值"
                            '        End If
                            '    Else
                            '        If iValue <> dm84CardCost Then
                            '            drDetail("ErrorColumn") = 8
                            '            drDetail("ImportedState") = "无法导入"
                            '            drDetail("StateReason") = "卡成本指定值不正确"
                            '        End If
                            '    End If
                        ElseIf drDetail("CardNo").ToString.IndexOf("2336" & signCardBin) = 0 Then
                            If blSignCanChanged Then
                                If iValue > dmSignCardCost Then
                                    drDetail("ErrorColumn") = 8
                                    drDetail("ImportedState") = "无法导入"
                                    drDetail("StateReason") = "卡成本超过指定值"
                                End If
                            Else
                                If iValue <> dmSignCardCost Then
                                    drDetail("ErrorColumn") = 8
                                    drDetail("ImportedState") = "无法导入"
                                    drDetail("StateReason") = "卡成本指定值不正确"
                                End If
                            End If
                            'modify code 050:end-------------------------------------------------------------------------
                        End If
                    End If

                    If .Range("F" & iRow.ToString).Value = "" AndAlso .Range("G" & iRow.ToString).Value = "" AndAlso .Range("H" & iRow.ToString).Value = "" AndAlso .Range("I" & iRow.ToString).Value = "" Then
                        drDetail("HolderName") = .Range("F" & iRow.ToString).Value
                        drDetail("Gender") = .Range("G" & iRow.ToString).Value
                        drDetail("HolderIdNo") = .Range("H" & iRow.ToString).Value
                        drDetail("Mobile") = .Range("I" & iRow.ToString).Value
                    Else
                        sValue = .Range("H" & iRow.ToString).Value
                        drDetail("HolderIdNo") = sValue.ToString.Trim
                        If drDetail("ImportedState").ToString = "" Then
                            If sValue = "" Then
                                drDetail("ErrorColumn") = 11
                                drDetail("ImportedState") = "无法导入"
                                drDetail("StateReason") = "未指明持卡人身份证号"
                            ElseIf Not frmSelling.CheckCredentialsNo(sValue) Then
                                drDetail("ErrorColumn") = 11
                                drDetail("ImportedState") = "无法导入"
                                drDetail("StateReason") = "持卡人身份证号错误"
                            End If
                        End If

                        sValue = .Range("F" & iRow.ToString).Value
                        drDetail("HolderName") = sValue.ToString.Trim
                        If drDetail("ImportedState").ToString = "" Then
                            If sValue = "" Then
                                drDetail("ErrorColumn") = 9
                                drDetail("ImportedState") = "无法导入"
                                drDetail("StateReason") = "未指明持卡人姓名"
                            ElseIf dtImportedDetails.Select("HolderIdNo = '" & drDetail("HolderIdNo") & "'").Length <> dtImportedDetails.Select("HolderIdNo = '" & drDetail("HolderIdNo") & "' AND HolderName = '" & drDetail("HolderName") & "'").Length Then
                                drDetail("ErrorColumn") = 9
                                drDetail("ImportedState") = "无法导入"
                                drDetail("StateReason") = "持相同身份证的持卡人姓名错误"
                            ElseIf dtHolderInfo.Select("HolderIdNo = '" & drDetail("HolderIdNo") & "'").Length <> dtHolderInfo.Select("HolderIdNo = '" & drDetail("HolderIdNo") & "' AND HolderName = '" & drDetail("HolderName") & "'").Length Then
                                drDetail("ErrorColumn") = 9
                                drDetail("ImportedState") = "无法导入"
                                drDetail("StateReason") = "持卡人姓名与数据库中记录的不一致"
                            End If
                        End If

                        sValue = .Range("G" & iRow.ToString).Value
                        drDetail("Gender") = sValue.ToString.Trim
                        If drDetail("ImportedState").ToString = "" Then
                            If sValue = "" Then
                                drDetail("ErrorColumn") = 10
                                drDetail("ImportedState") = "无法导入"
                                drDetail("StateReason") = "未指明持卡人性别"
                            ElseIf sValue <> "男" AndAlso sValue <> "女" Then
                                drDetail("ErrorColumn") = 10
                                drDetail("ImportedState") = "无法导入"
                                drDetail("StateReason") = "持卡人性别错误"
                            ElseIf dtImportedDetails.Select("HolderIdNo = '" & drDetail("HolderIdNo") & "'").Length <> dtImportedDetails.Select("HolderIdNo = '" & drDetail("HolderIdNo") & "' AND Gender = '" & drDetail("Gender") & "'").Length Then
                                drDetail("ErrorColumn") = 10
                                drDetail("ImportedState") = "无法导入"
                                drDetail("StateReason") = "持相同身份证的持卡人性别错误"
                            End If
                        End If

                        sValue = .Range("I" & iRow.ToString).Value
                        drDetail("Mobile") = sValue.ToString.Trim
                        If drDetail("ImportedState").ToString = "" Then
                            If sValue = "" Then
                                drDetail("ErrorColumn") = 12
                                drDetail("ImportedState") = "无法导入"
                                drDetail("StateReason") = "未指明持卡人手机号"
                            ElseIf Not IsNumeric(sValue) OrElse sValue.Length <> 11 Then
                                drDetail("ErrorColumn") = 12
                                drDetail("ImportedState") = "无法导入"
                                drDetail("StateReason") = "持卡人手机号错误"
                            ElseIf dtImportedDetails.Select("HolderIdNo = '" & drDetail("HolderIdNo") & "'").Length <> dtImportedDetails.Select("HolderIdNo = '" & drDetail("HolderIdNo") & "' AND Mobile = '" & drDetail("Mobile") & "'").Length Then
                                drDetail("ErrorColumn") = 12
                                drDetail("ImportedState") = "无法导入"
                                drDetail("StateReason") = "持相同身份证的持卡人手机号错误"
                            End If
                        End If
                    End If

                    drDetail("Remarks") = .Range("D" & iRow.ToString).Value

                    If drDetail("ImportedState").ToString = "" Then
                        drDetail("ImportedState") = "已导入"
                        If sFirstCity = "" Then sFirstCity = drDetail("CityName").ToString
                    End If
                End If
            Next
        End With
        dtImportedDetails.AcceptChanges()

        excelAPP.DisplayAlerts = True
        excelAPP.ActiveWorkBook.Close(False)
        excelAPP.Quit()
        excelAPP = Nothing

        If dtImportedDetails.Rows.Count = 0 Then
            MessageBox.Show("源文件中不存在任何卡号！：    " & Chr(13) & Chr(13) & "请重新选择源文件（或源工作表）。    ", "源文件中不存在任何卡号！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.statusText.Text = "源文件中不存在任何卡号！"
            dtImportedDetails.Dispose() : dtImportedDetails = Nothing
            Me.Cursor = Cursors.Default
            Return
        End If

        Dim dvImportedDetails As DataView = dtImportedDetails.Copy.DefaultView
        dvImportedDetails.RowFilter = "ImportedState='已导入'"
        If dvImportedDetails.Count = 0 Then
            With frmImportedFileResult
                .isSign = True
                .dtImportedDetails = dtImportedDetails.Copy
                .Text = "源文件中不存在任何满足导入条件的卡号！"
                .grbResult.Text = "检查结果："
                .lblPrompt.Visible = True
                .btnClose.Text = "确定(&O)"
                .ShowDialog()
                .Dispose()
            End With
            Me.statusText.Text = "源文件中不存在任何满足导入条件的卡号！"
            dvImportedDetails.Dispose() : dvImportedDetails = Nothing
            dtImportedDetails.Dispose() : dtImportedDetails = Nothing
            Me.Cursor = Cursors.Default
            Return
        End If

        'DB = New DataBase
        'DB.Open()
        'If Not DB.IsConnected Then
        '    Me.statusText.Text = "系统因连接不到数据库而无法到数据库检查购物卡状态。请检查数据库连接。"
        '    Me.Cursor = Cursors.Default
        '    Return
        'End If

        'If DB.ModifyTable("Select CardNo Into #tempCard From ImportedFileDetails Where 1=2") = -1 OrElse _
        '   DB.BulkCopyTable("#tempCard", dvImportedDetails.ToTable(True, "CardNo")) = -1 Then
        '    Me.statusText.Text = "到数据库检查购物卡状态时出现错误！"
        '    dvImportedDetails.Dispose() : dvImportedDetails = Nothing
        '    dtImportedDetails.Dispose() : dtImportedDetails = Nothing
        '    DB.Close() : Me.Cursor = Cursors.Default
        '    Return
        'End If
        'dvImportedDetails.Dispose() : dvImportedDetails = Nothing

        'Dim sFlag As String = "0"
        ''If isSign Then
        ''    sFlag = "1"
        ''End If
        'Dim dtResult As DataTable = DB.GetDataTable("Exec CheckImportedSignCard " & dtLoginStructure.Rows.Find(sStoreID)("ParentAreaID").ToString & "," & sFlag)
        'DB.Close()

        'If dtResult Is Nothing Then
        '    Me.statusText.Text = "到数据库检查购物卡状态时出现错误！"
        '    dtImportedDetails.Dispose() : dtImportedDetails = Nothing
        '    Me.Cursor = Cursors.Default
        '    Return
        'End If

        'If dtResult.Rows(0)("Result").ToString <> "OK" Then
        '    Select Case dtResult.Rows(0)("Result").ToString
        '        Case "NoneCharged"
        '            If Not isSign Then
        '                If dtImportedDetails.Select("ImportedState='无法导入'").Length = 0 Then
        '                    MessageBox.Show("源文件所包含的购物卡均未充过值，所以无法对它们进行再充值！    ", "源文件中的购物卡从未充过值！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '                    Me.statusText.Text = "源文件中的购物卡从未充过值！"
        '                Else
        '                    For Each drCard As DataRow In dtImportedDetails.Select("ImportedState='已导入'")
        '                        drCard("ImportedState") = "无法导入"
        '                        drCard("StateReason") = "该卡从未充过值，不能再充值"
        '                        drCard.AcceptChanges()
        '                    Next

        '                    With frmImportedFileResult
        '                        .isSign = isSign
        '                        .dtImportedDetails = dtImportedDetails.Copy
        '                        .Text = "源文件中不存在任何满足导入条件的卡号！"
        '                        .grbSource.Text = "检查结果："
        '                        .lblPrompt.Visible = True
        '                        .btnClose.Text = "确定(&O)"
        '                        .ShowDialog()
        '                        .Dispose()
        '                    End With
        '                    Me.statusText.Text = "源文件中不存在任何满足导入条件的卡号！"
        '                End If
        '            End If
        '        Case "NotCompany"
        '            MessageBox.Show("源文件的购物卡的原来客户是个人客户，不是公司客户！    " & Chr(13) & Chr(13) & """从文件再充值""操作仅适用于公司客户，不适用于个人客户。    ", "非公司客户不能使用""从文件再充值""操作！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '            Me.statusText.Text = "非公司客户不能使用""从文件再充值""操作！"
        '        Case "CustomerDeleted"
        '            MessageBox.Show("源文件的购物卡的原来客户已被删除，导入充值无效！    ", "源文件的购物卡的原来客户已被删除！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '            Me.statusText.Text = "源文件的购物卡的原来客户已被删除！"
        '        Case "CustomerStopped"
        '            MessageBox.Show("源文件的购物卡的原来客户已被停止使用，再也不能向该客户充值！    " & Chr(13) & Chr(13) & _
        '                            "客户名称： " & dtResult.Rows(0)("CustomerName").ToString & Space(4) & _
        '                            IIf(dtResult.Rows(0)("StoppedReason").ToString = "", "", Chr(13) & "停用原因： " & dtResult.Rows(0)("StoppedReason").ToString), "源文件的购物卡的原来客户已被停止使用！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '            Me.statusText.Text = "源文件的购物卡的原来客户已被停止使用！"
        '        Case Else
        '            MessageBox.Show("源文件的购物卡的原来客户所在的城市与源文件所指出的城市不一致，导入充值无效！    " & Chr(13) & Chr(13) & _
        '                            "      客户名称： " & dtResult.Rows(0)("CustomerName").ToString & Space(4) & Chr(13) & _
        '                            "      所在城市： " & dtResult.Rows(0)("CityName").ToString & Space(4) & Chr(13) & _
        '                            "源文件中的城市： " & dtImportedDetails.Select("ImportedState='已导入'")(0)("CityName").ToString, _
        '                            "原来客户所在城市与源文件中的城市不一致！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '            Me.statusText.Text = "原来客户所在城市与源文件中的城市不一致！"
        '    End Select

        '    If dtResult.Rows(0)("Result").ToString = "NoneCharged" AndAlso isSign Then

        '    Else
        '        dtImportedDetails.Dispose() : dtImportedDetails = Nothing
        '        dtResult.Dispose() : dtResult = Nothing
        '        Me.Cursor = Cursors.Default
        '        Return
        '    End If
        'End If

        'Dim sCustomerID As String = dtResult.Rows(0)("CustomerID").ToString
        'If dtResult.Columns.Count = 2 Then
        '    For Each drCard As DataRow In dtImportedDetails.Select("ImportedState='已导入'")
        '        If dtResult.Select("CardNo='" & drCard("CardNo").ToString & "'").Length = 0 Then
        '            drCard("ImportedState") = "无法导入"
        '            drCard("StateReason") = "该卡从未充过值，不能再充值"
        '            drCard.AcceptChanges()
        '        End If
        '    Next
        'End If
        'dtResult.Dispose() : dtResult = Nothing
        If dtImportedDetails.Select("ImportedState='无法导入'").Length > 0 Then
            For Each drDetail As DataRow In dtImportedDetails.Rows
                If drDetail("ImportedState").ToString <> "无法导入" Then
                    drDetail("ImportedState") = DBNull.Value
                End If
            Next
            With frmImportedFileResult
                dtImportedDetails.DefaultView.RowFilter = "ImportedState='无法导入'"
                .isSign = True
                .dtImportedDetails = dtImportedDetails.DefaultView.ToTable
                .Text = "源文件中存在错误，无法导入！"
                .grbResult.Text = "检查结果："
                .lblPrompt.Text = "源文件中存在错误，请在更正错误后重试。"
                .lblPrompt.Visible = True
                .btnClose.Text = "确定(&O)"
                .ShowDialog()
                .Dispose()
            End With
            Me.statusText.Text = "源文件中存在错误，无法导入！"
            dtImportedDetails.Dispose() : dtImportedDetails = Nothing
            Me.Cursor = Cursors.Default
            Return
        End If

        If frmSelling.IsHandleCreated Then
            frmSelling.Activate()
            frmSelling.WindowState = FormWindowState.Maximized

            'If isSign Then
            frmSelling.cbbSalesBillType.Items(0) = "实名制卡销售单"
            frmSelling.txbSalesBillType.Text = "实名制卡销售单"
            frmSelling.bNewSalesBillType = 7
            'Else
            '    frmSelling.cbbSalesBillType.Items(0) = "一般销售单"
            '    frmSelling.txbSalesBillType.Text = "一般销售单"
            '    frmSelling.bNewSalesBillType = 0
            'End If
            frmSelling.sSalesBillID = "-1"
            'modify code 046:start-------------------------------------------------------------------------
            'frmSelling.sCustomerID = sCustomerID
            frmSelling.sCustomerID = ""
            'modify code 046:end-------------------------------------------------------------------------
            frmSelling.blUsedOldCard = False
            frmSelling.ReCreateSalesBill()
        Else
            Me.statusText.Text = "正在打开销售单窗口……"
            Me.statusMain.Refresh()

            'If isSign Then
            frmSelling.cbbSalesBillType.Items(0) = "实名制卡销售单"
            frmSelling.txbSalesBillType.Text = "实名制卡销售单"
            frmSelling.bNewSalesBillType = 7
            'Else
            '    frmSelling.cbbSalesBillType.Items(0) = "一般销售单"
            '    frmSelling.txbSalesBillType.Text = "一般销售单"
            '    frmSelling.bNewSalesBillType = 0
            'End If

            'modify code 046:start-------------------------------------------------------------------------
            'frmSelling.sCustomerID = sCustomerID
            frmSelling.sCustomerID = ""
            'modify code 046:end-------------------------------------------------------------------------
            frmSelling.Show()
            If frmSelling.IsHandleCreated Then
                frmSelling.MdiParent = Me
                frmSelling.WindowState = FormWindowState.Maximized
                frmSelling.Activate()
            End If
        End If

        If frmSelling.IsHandleCreated Then
            Dim dtImportedFile As New DataTable, drImportedFile As DataRow
            With dtImportedFile.Columns
                .Add("SalesBillID", System.Type.GetType("System.Int32"))
                .Add("SourceComputer", System.Type.GetType("System.String"))
                .Add("SourceFile", System.Type.GetType("System.String"))
                .Add("WorkSheet", System.Type.GetType("System.String"))
                .Add("FileSize", System.Type.GetType("System.Int32"))
                .Add("FileModifiedTime", System.Type.GetType("System.DateTime"))
                .Add("CardQTY", System.Type.GetType("System.Int32"))
                .Add("ChargedAMT", System.Type.GetType("System.Decimal"))
            End With
            drImportedFile = dtImportedFile.Copy.Rows.Add
            dtImportedFile.Dispose() : dtImportedFile = Nothing
            drImportedFile("SourceFile") = sFileName
            drImportedFile("WorkSheet") = sWorkSheet
            Try
                Dim fileInfo As IO.FileInfo = My.Computer.FileSystem.GetFileInfo(sFileName)
                drImportedFile("FileSize") = fileInfo.Length
                drImportedFile("FileModifiedTime") = fileInfo.LastWriteTime
                fileInfo = Nothing
            Catch
            End Try
            Dim iCardQTY As Integer = 0, dmChargedAMT As Decimal = 0
            For Each dr As DataRow In dtImportedDetails.Select("ImportedState='已导入'")
                iCardQTY += 1
                dmChargedAMT += CDec(dr("FaceValue"))
            Next
            drImportedFile("CardQTY") = iCardQTY
            drImportedFile("ChargedAMT") = dmChargedAMT
            drImportedFile.AcceptChanges()

            With frmSelling
                .resetCardCostColumn(False)
                .drImportedFile = drImportedFile
                .dtImportedDetails = dtImportedDetails.Copy
                .UpdateInterFaceWhenImportFile()
            End With

            drImportedFile = Nothing

            MessageBox.Show("已将源文件中的卡号导入到新的销售单。    ", "已完成导入操作。", MessageBoxButtons.OK, MessageBoxIcon.Information)

            With frmSelling
                .Activate()
                .dgvNormalCard.Select()
                .dgvPayment.Focus()
                .dgvPayment.Select()
                .dgvPayment.Rows(0).Selected = False
                .dgvPayment("PaymentAMT", 0).Selected = True
                .dgvPayment.BeginEdit(True)

                If .dgvNormalCard.CurrentRow IsNot Nothing Then .dgvNormalCard.CurrentRow.Selected = False
                If .dgvRebateCard.CurrentRow IsNot Nothing Then .dgvRebateCard.CurrentRow.Selected = False
                If .dgvPayment.CurrentRow IsNot Nothing Then .dgvPayment.CurrentRow.Selected = False
            End With

            Me.statusText.Text = "已完成导入操作，请对该销售单进行收款操作。"
        End If

        dtImportedDetails.Dispose() : dtImportedDetails = Nothing
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub menuDownloadSignCardSalesBillRechargeTemp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If dtAllowedRight.Select("RightName='SalesBillSignCardCreate'").Length = 0 Then
            MessageBox.Show("对不起！您没有实名制卡批量导入的权限。    " & Chr(13) & "Sorry, you have no right to import signcard salesbill from file.    ", "您无权从文件中批量导入 No right to import signcard salesbill from file!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.menuCreateSignCardSalesBillFromFile.Enabled = False
            Return
        End If

        Dim xlsheet As Excel.Worksheet
        Dim xlBook As Excel.Workbook
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

        Dim saveFile As New SaveFileDialog(), sFileName As String = ""
        saveFile.Title = "请选择实名制卡充值模板的保存路径（Microsoft Excel 文件）："
        saveFile.FileName = "实名制卡充值模板"
        saveFile.Filter = "模板文件（Microsoft Excel 文件）|*.xls"
        saveFile.RestoreDirectory = True

        If saveFile.ShowDialog() = Windows.Forms.DialogResult.OK Then sFileName = saveFile.FileName
        saveFile.Dispose()
        If sFileName = "" Then
            Me.statusText.Text = "您已经取消了下载实名制卡充值模板。"
            Me.Cursor = Cursors.Default
            Return
        End If

        'Try
        '    My.Computer.Network.DownloadFile(sFTPConnection & "/实名制卡充值模板.xls", sFileName, sFTPUserName, sFTPPassword, True, 100, True)
        'Catch ex As Exception
        '    MessageBox.Show("保存模板文件时发生错误！具体的错误信息如下：    " & Chr(13) & Chr(13) & ex.Message & Space(4) & Chr(13) & Chr(13) & "请检查错误原因，然后重试。如仍有问题，请联系软件开发人员。    ", "保存模板文件时发生错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Me.statusText.Text = "保存模板文件时发生错误！"
        '    Me.Cursor = Cursors.Default
        '    Return
        'End Try

        Try '如果已打开，先不保存而关闭，以确保打开的是当前文件
            excelAPP.Windows(sFileName.Substring(sFileName.LastIndexOf("\") + 1)).Activate()
            excelAPP.ActiveWorkBook.Close(False)
        Catch
        End Try

        Try
            excelAPP.DisplayAlerts = False
            xlBook = excelAPP.Workbooks.Add
            xlsheet = xlBook.Worksheets(1)
            xlsheet.Cells.NumberFormatLocal = "@"
            xlsheet.Name = "实名制卡充值"
            xlsheet.Cells(1, 1) = "城市"
            xlsheet.Cells(1, 2) = "卡号"
            xlsheet.Cells(1, 3) = "面值"
            xlsheet.Cells(1, 4) = "备注"
            xlBook.SaveAs(sFileName)
            xlBook.Close()
            excelAPP.Quit()
        Catch ex As Exception
            excelAPP.Quit()
            MessageBox.Show("保存模板文件时发生错误！具体的错误信息如下：    " & Chr(13) & Chr(13) & ex.Message & Space(4) & Chr(13) & Chr(13) & "请检查错误原因，然后重试。如仍有问题，请联系软件开发人员。    ", "保存模板文件时发生错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            excelAPP = Nothing
            Me.statusText.Text = "保存模板文件时发生错误！"
            Me.Cursor = Cursors.Default
            Return
        End Try

        Me.statusText.Text = "保存模板文件成功！"

    End Sub

    Private Sub menuRechargeSignCardSalesBillFromFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim isSign As Boolean = False
        Dim dtHolderInfo As New DataTable

        If dtAllowedRight.Select("RightName='SalesBillSignCardCreate'").Length = 0 Then
            MessageBox.Show("对不起！您没有实名制卡批量导入的权限。    " & Chr(13) & "Sorry, you have no right to import signcard salesbill from file.    ", "您无权从文件中批量导入 No right to import signcard salesbill from file!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.menuCreateSignCardSalesBillFromFile.Enabled = False
            Return
        End If

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

        If frmSelling.IsHandleCreated AndAlso frmSelling.blIsChanged Then
            frmSelling.Activate()
            frmSelling.WindowState = FormWindowState.Maximized
            Dim bAnswer As DialogResult = MessageBox.Show("是否在导入文件之前，先保存当前销售单？    ", "当前销售单未保存！", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If bAnswer = Windows.Forms.DialogResult.Cancel OrElse (bAnswer = Windows.Forms.DialogResult.Yes AndAlso Not frmSelling.SaveChanges()) Then
                Me.statusText.Text = "因为存在未保存销售单，所以不能导入文件。"
                Return
            End If
        End If

        Dim sStoreID As String = ""
        Dim sCityID As String = ""
        If sLoginAreaType = "S" Then
            sStoreID = sLoginAreaID
            sCityID = dtLoginStructure.Rows.Find(sLoginAreaID)("ParentAreaID").ToString
        Else
            frmSelectStore.ShowDialog()
            sStoreID = frmSelectStore.cbbStore.SelectedValue
            frmSelectStore.Dispose()
            sCityID = sLoginAreaID
        End If
        SetCardCostByCityID(sCityID)

        Me.Cursor = Cursors.WaitCursor
        Me.statusText.Text = "正在获取门店销售参数……"

        Dim DB As New DataBase()
        DB.Open()
        If Not DB.IsConnected Then
            Me.statusText.Text = "系统因连接不到数据库而无法获取门店销售参数。请检查数据库连接。"
            Me.Cursor = Cursors.Default
            Return
        End If

        Dim drStore As DataRow = Nothing
        Try
            drStore = DB.GetDataTable("Exec GetStoreParameterWhenSellCard " & sStoreID).Rows(0)
            dtHolderInfo = DB.GetDataTable("SELECT * FROM HolderInfoList")
        Catch
            Me.statusText.Text = "系统因在检索数据时出错而无法获取门店销售参数。请联系软件开发人员。"
            DB.Close()
            Me.Cursor = Cursors.Default
            Return
        End Try
        DB.Close()

        Me.statusText.Text = "请选择源文件："
        Me.statusMain.Refresh()

        Dim openFile As New OpenFileDialog(), sFileName As String = "", sWorkSheet As String = ""
        openFile.Title = "请选择想从中导入购物卡号的源文件（Microsoft Excel 文件）："
        openFile.Filter = "源文件（Microsoft Excel 文件）|*.xls"
        openFile.Multiselect = False
        openFile.RestoreDirectory = True

        If openFile.ShowDialog() = Windows.Forms.DialogResult.OK Then sFileName = openFile.FileName
        openFile.Dispose()
        If sFileName = "" Then
            Me.statusText.Text = "您已经取消了导入文件。"
            Me.Cursor = Cursors.Default
            Return
        End If

        Me.statusText.Text = "正在检查源文件……"
        Me.statusMain.Refresh()

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
            MessageBox.Show("打开源文件时发生错误！具体的错误信息如下：    " & Chr(13) & Chr(13) & ex.Message & Space(4) & Chr(13) & Chr(13) & "请检查错误原因，然后重试。如仍有问题，请联系软件开发人员。    ", "打开源文件时发生错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            excelAPP = Nothing
            Me.statusText.Text = "打开源文件时发生错误！"
            Me.Cursor = Cursors.Default
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
            If sWorkSheet = "" Then
                Me.statusText.Text = "您已经取消了导入文件。"
                Me.Cursor = Cursors.Default
                Return
            End If

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
                Me.statusText.Text = "打开源文件时发生错误！"
                Me.Cursor = Cursors.Default
                Return
            End Try
        End If

        Dim dtImportedDetails As New DataTable

        excelAPP.ActiveWorkBook.WorkSheets(sWorkSheet).Select()
        With excelAPP.ActiveWorkBook.ActiveSheet
            'If .Range("A1").Value.ToString.Trim <> "城市" OrElse .Range("B1").Value.ToString.Trim <> "卡号" OrElse .Range("C1").Value.ToString.Trim <> "面值" OrElse .Range("D1").Value.ToString.Trim <> "备注" Then
            '    MessageBox.Show("源文件格式存在错误！源文件应该由下面四列组成：    " & Chr(13) & Chr(13) & _
            '                    "城市 + 卡号 + 面值 + 备注    " & Chr(13) & Chr(13) & _
            '                    "请确保源文件第一行各单元格的值与上面各列相一致。    ", "源文件格式错误，导入失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    excelAPP = Nothing
            '    Me.statusText.Text = "源文件格式错误，导入失败！"
            '    Me.Cursor = Cursors.Default
            '    Return
            'End If

            If .Range("A1").Value <> Nothing _
                AndAlso .Range("B1").Value <> Nothing _
                AndAlso .Range("C1").Value <> Nothing _
                AndAlso .Range("D1").Value <> Nothing _
                AndAlso .Range("A1").Value.ToString.Trim = "城市" _
                AndAlso .Range("B1").Value.ToString.Trim = "卡号" _
                AndAlso .Range("C1").Value.ToString.Trim = "面值" _
                AndAlso .Range("D1").Value.ToString.Trim = "备注" Then
                isSign = False
            Else
                isSign = True
                MessageBox.Show("源文件格式存在错误！源文件应该由下面四列组成：    " & Chr(13) & Chr(13) & _
                                "城市 + 卡号 + 面值 + 备注    " & Chr(13) & Chr(13) & _
                                "请确保源文件第一行各单元格的值与上面各列相一致。    ", "源文件格式错误，导入失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                excelAPP = Nothing
                Me.statusText.Text = "源文件格式错误，导入失败！"
                Me.Cursor = Cursors.Default
                Return
            End If

            dtImportedDetails.Columns.Add("SalesBillID", System.Type.GetType("System.Int32"))
            dtImportedDetails.Columns.Add("RowID", System.Type.GetType("System.Int16"))
            dtImportedDetails.Columns.Add("ErrorColumn", System.Type.GetType("System.Byte"))
            dtImportedDetails.Columns.Add("CityName", System.Type.GetType("System.String"))
            dtImportedDetails.Columns.Add("CardNo", System.Type.GetType("System.String"))
            dtImportedDetails.Columns.Add("FaceValue", System.Type.GetType("System.String"))
            dtImportedDetails.Columns.Add("SalesDate", System.Type.GetType("System.String"))
            dtImportedDetails.Columns.Add("Remarks", System.Type.GetType("System.String"))
            'If isSign Then
            dtImportedDetails.Columns.Add("CardCost", System.Type.GetType("System.String"))
            dtImportedDetails.Columns.Add("HolderName", System.Type.GetType("System.String"))
            dtImportedDetails.Columns.Add("Gender", System.Type.GetType("System.String"))
            dtImportedDetails.Columns.Add("HolderIdNo", System.Type.GetType("System.String"))
            dtImportedDetails.Columns.Add("Mobile", System.Type.GetType("System.String"))
            'End If
            dtImportedDetails.Columns.Add("ImportedState", System.Type.GetType("System.String"))
            dtImportedDetails.Columns.Add("StateReason", System.Type.GetType("System.String"))

            Dim iRows As Integer = .UsedRange.Rows.Count, drDetail As DataRow, sFirstCity As String = "", sValue As String = "", iRowID As Int16 = -1
            For iRow As Integer = 2 To iRows
                If .Range("A" & iRow.ToString).Value <> "" OrElse .Range("B" & iRow.ToString).Value <> "" OrElse .Range("C" & iRow.ToString).Value <> "" OrElse .Range("D" & iRow.ToString).Value <> "" Then
                    drDetail = dtImportedDetails.Rows.Add
                    iRowID += 1
                    drDetail("RowID") = iRowID
                    sValue = .Range("A" & iRow.ToString).Value
                    drDetail("CityName") = sValue
                    If sValue = "" Then
                        drDetail("ErrorColumn") = 3
                        drDetail("ImportedState") = "无法导入"
                        drDetail("StateReason") = "未指明城市"
                    ElseIf (drStore("CityChineseName").ToString.IndexOf(sValue) = -1) AndAlso (drStore("CityEnglishName").ToString.IndexOf(sValue) = -1) AndAlso _
                           (drStore("CityChineseName").ToString <> "" AndAlso sValue.IndexOf(drStore("CityChineseName").ToString) = -1) AndAlso _
                           (drStore("CityEnglishName").ToString <> "" AndAlso sValue.IndexOf(drStore("CityEnglishName").ToString) = -1) Then
                        drDetail("ErrorColumn") = 3
                        drDetail("ImportedState") = "无法导入"
                        drDetail("StateReason") = "城市不存在"
                    ElseIf sFirstCity <> "" AndAlso sValue <> sFirstCity Then
                        drDetail("ErrorColumn") = 3
                        drDetail("ImportedState") = "无法导入"
                        drDetail("StateReason") = "非同一城市"
                    End If

                    sValue = .Range("B" & iRow.ToString).Value
                    If sValue = "" Then
                        If iRow > 2 AndAlso dtImportedDetails.Rows(iRow - 3)("CardNo") <> "" Then
                            sValue = ShoppingCardNo.GetFullCardNo((CDec(dtImportedDetails.Rows(iRow - 3)("CardNo").ToString().Substring(0, 18)) + 1).ToString())
                        End If
                    End If

                    drDetail("CardNo") = sValue
                    If drDetail("ImportedState").ToString = "" Then
                        If sValue = "" Then
                            drDetail("ErrorColumn") = 4
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "未指明卡号"
                        ElseIf Not IsNumeric(sValue) OrElse sValue.Length <> 19 Then
                            drDetail("ErrorColumn") = 4
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "卡号错误（应由19个数字组成）"
                        ElseIf sValue <> ShoppingCardNo.GetFullCardNo(sValue.Substring(0, 18)) Then
                            drDetail("ErrorColumn") = 4
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "卡号错误（验证码错误）"
                        ElseIf sValue.Substring(0, 4) <> "2336" Then
                            drDetail("ErrorColumn") = 4
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "卡号非法（非银商卡）"
                            'modify code 004:start-------------------------------------------------------------------------
                            'ElseIf sValue.Substring(4, 5) <> drStore("CULCardBin").ToString Then
                        ElseIf sValue.Substring(4, 5) <> drStore("CULCardBin").ToString And sValue.Substring(4, 5) <> "60" & drStore("CULCardBin").ToString.Substring(2, 3) Then
                            'modify code 004:start-------------------------------------------------------------------------
                            drDetail("ErrorColumn") = 4
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "卡号非法（银商卡Bin码（第5至9位）不符）"
                        ElseIf dtImportedDetails.Select("CardNo='" & sValue & "'").Length > 1 Then
                            drDetail("ErrorColumn") = 4
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "卡号重复"
                        ElseIf sValue.IndexOf("233684") <> 0 AndAlso sValue.IndexOf("233660") <> 0 Then
                            drDetail("ErrorColumn") = 4
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "实名卡销售仅限于84卡及60卡"
                        End If
                    End If

                    sValue = .Range("C" & iRow.ToString).Value
                    If sValue = "" OrElse Not IsNumeric(sValue) Then
                        drDetail("FaceValue") = sValue
                    Else
                        drDetail("FaceValue") = Format(CDec(sValue), "#,0.00")
                    End If
                    If drDetail("ImportedState").ToString = "" Then
                        Dim dmMaxValue As Decimal = drStore("MaxFaceValue")
                        If frmSelling.getSignCardList(drDetail("CardNo").ToString).Rows.Count > 0 Then
                            dmMaxValue = 5000
                        End If
                        If sValue = "" Then
                            drDetail("ErrorColumn") = 5
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "未指明面值"
                        ElseIf Not IsNumeric(sValue) Then
                            drDetail("ErrorColumn") = 5
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "面值错误（应该是数值）"
                        ElseIf CDec(sValue) = 0 Then
                            drDetail("ErrorColumn") = 5
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "面值错误（应该大于零）"
                        ElseIf CDec(sValue) > dmMaxValue Then
                            drDetail("ErrorColumn") = 5
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "面值错误（已经超过最大许可面值" & Format(dmMaxValue, "#,0.00") & "元）"
                        End If
                    End If

                    'sValue = .Range("D" & iRow.ToString).Value
                    'If sValue = "" OrElse Not IsDate(sValue) Then
                    '    drDetail("SalesDate") = sValue
                    'Else
                    '    drDetail("SalesDate") = Format(CDate(sValue), "yyyy\/MM\/dd")
                    'End If
                    'If drDetail("ImportedState").ToString = "" Then
                    '    If sValue = "" Then
                    '        drDetail("ErrorColumn") = 6
                    '        drDetail("ImportedState") = "无法导入"
                    '        drDetail("StateReason") = "未指明销售日期"
                    '    ElseIf Not IsDate(sValue) Then
                    '        drDetail("ErrorColumn") = 6
                    '        drDetail("ImportedState") = "无法导入"
                    '        drDetail("StateReason") = "销售日期错误"
                    '    ElseIf CDate(Format(CDate(sValue), "yyyy\/MM\/dd")) <> CDate(drStore("Today").ToString) Then
                    '        drDetail("ErrorColumn") = 6
                    '        drDetail("ImportedState") = "无法导入"
                    '        drDetail("StateReason") = "指定的销售日期非当天日期（" & drStore("Today").ToString & "）"
                    '    End If
                    'End If

                    drDetail("Remarks") = .Range("D" & iRow.ToString).Value

                    If drDetail("ImportedState").ToString = "" Then
                        drDetail("ImportedState") = "已导入"
                        If sFirstCity = "" Then sFirstCity = drDetail("CityName").ToString
                    End If
                End If
            Next
        End With
        dtImportedDetails.AcceptChanges()

        excelAPP.DisplayAlerts = True
        excelAPP.ActiveWorkBook.Close(False)
        excelAPP.Quit()
        excelAPP = Nothing

        If dtImportedDetails.Rows.Count = 0 Then
            MessageBox.Show("源文件中不存在任何卡号！：    " & Chr(13) & Chr(13) & "请重新选择源文件（或源工作表）。    ", "源文件中不存在任何卡号！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.statusText.Text = "源文件中不存在任何卡号！"
            dtImportedDetails.Dispose() : dtImportedDetails = Nothing
            Me.Cursor = Cursors.Default
            Return
        End If

        Dim dvImportedDetails As DataView = dtImportedDetails.Copy.DefaultView
        dvImportedDetails.RowFilter = "ImportedState='已导入'"
        If dvImportedDetails.Count = 0 Then
            With frmImportedFileResult
                .isSign = isSign
                .dtImportedDetails = dtImportedDetails.Copy
                .Text = "源文件中不存在任何满足导入条件的卡号！"
                .grbResult.Text = "检查结果："
                .lblPrompt.Visible = True
                .btnClose.Text = "确定(&O)"
                .ShowDialog()
                .Dispose()
            End With
            Me.statusText.Text = "源文件中不存在任何满足导入条件的卡号！"
            dvImportedDetails.Dispose() : dvImportedDetails = Nothing
            dtImportedDetails.Dispose() : dtImportedDetails = Nothing
            Me.Cursor = Cursors.Default
            Return
        End If

        'DB = New DataBase
        'DB.Open()
        'If Not DB.IsConnected Then
        '    Me.statusText.Text = "系统因连接不到数据库而无法到数据库检查购物卡状态。请检查数据库连接。"
        '    Me.Cursor = Cursors.Default
        '    Return
        'End If

        'If DB.ModifyTable("Select CardNo Into #tempCard From ImportedFileDetails Where 1=2") = -1 OrElse _
        '   DB.BulkCopyTable("#tempCard", dvImportedDetails.ToTable(True, "CardNo")) = -1 Then
        '    Me.statusText.Text = "到数据库检查购物卡状态时出现错误！"
        '    dvImportedDetails.Dispose() : dvImportedDetails = Nothing
        '    dtImportedDetails.Dispose() : dtImportedDetails = Nothing
        '    DB.Close() : Me.Cursor = Cursors.Default
        '    Return
        'End If
        'dvImportedDetails.Dispose() : dvImportedDetails = Nothing

        'Dim sFlag As String = "1"
        ''If isSign Then
        ''    sFlag = "1"
        ''End If
        'Dim dtResult As DataTable = DB.GetDataTable("Exec CheckImportedSignCard " & dtLoginStructure.Rows.Find(sStoreID)("ParentAreaID").ToString & "," & sFlag)
        'DB.Close()

        'If dtResult Is Nothing Then
        '    Me.statusText.Text = "到数据库检查购物卡状态时出现错误！"
        '    dtImportedDetails.Dispose() : dtImportedDetails = Nothing
        '    Me.Cursor = Cursors.Default
        '    Return
        'End If

        'If dtResult.Rows(0)("Result").ToString <> "OK" Then
        '    Select Case dtResult.Rows(0)("Result").ToString
        '        Case "NoneCharged"
        '            If Not isSign Then
        '                If dtImportedDetails.Select("ImportedState='无法导入'").Length = 0 Then
        '                    MessageBox.Show("源文件所包含的购物卡均未充过值，所以无法对它们进行再充值！    ", "源文件中的购物卡从未充过值！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '                    Me.statusText.Text = "源文件中的购物卡从未充过值！"
        '                Else
        '                    For Each drCard As DataRow In dtImportedDetails.Select("ImportedState='已导入'")
        '                        drCard("ImportedState") = "无法导入"
        '                        drCard("StateReason") = "该卡从未充过值，不能再充值"
        '                        drCard.AcceptChanges()
        '                    Next

        '                    With frmImportedFileResult
        '                        .isSign = isSign
        '                        .dtImportedDetails = dtImportedDetails.Copy
        '                        .Text = "源文件中不存在任何满足导入条件的卡号！"
        '                        .grbSource.Text = "检查结果："
        '                        .lblPrompt.Visible = True
        '                        .btnClose.Text = "确定(&O)"
        '                        .ShowDialog()
        '                        .Dispose()
        '                    End With
        '                    Me.statusText.Text = "源文件中不存在任何满足导入条件的卡号！"
        '                End If
        '            End If
        '        Case "NotCompany"
        '            MessageBox.Show("源文件的购物卡的原来客户是个人客户，不是公司客户！    " & Chr(13) & Chr(13) & """从文件再充值""操作仅适用于公司客户，不适用于个人客户。    ", "非公司客户不能使用""从文件再充值""操作！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '            Me.statusText.Text = "非公司客户不能使用""从文件再充值""操作！"
        '        Case "CustomerDeleted"
        '            MessageBox.Show("源文件的购物卡的原来客户已被删除，导入充值无效！    ", "源文件的购物卡的原来客户已被删除！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '            Me.statusText.Text = "源文件的购物卡的原来客户已被删除！"
        '        Case "CustomerStopped"
        '            MessageBox.Show("源文件的购物卡的原来客户已被停止使用，再也不能向该客户充值！    " & Chr(13) & Chr(13) & _
        '                            "客户名称： " & dtResult.Rows(0)("CustomerName").ToString & Space(4) & _
        '                            IIf(dtResult.Rows(0)("StoppedReason").ToString = "", "", Chr(13) & "停用原因： " & dtResult.Rows(0)("StoppedReason").ToString), "源文件的购物卡的原来客户已被停止使用！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '            Me.statusText.Text = "源文件的购物卡的原来客户已被停止使用！"
        '        Case Else
        '            MessageBox.Show("源文件的购物卡的原来客户所在的城市与源文件所指出的城市不一致，导入充值无效！    " & Chr(13) & Chr(13) & _
        '                            "      客户名称： " & dtResult.Rows(0)("CustomerName").ToString & Space(4) & Chr(13) & _
        '                            "      所在城市： " & dtResult.Rows(0)("CityName").ToString & Space(4) & Chr(13) & _
        '                            "源文件中的城市： " & dtImportedDetails.Select("ImportedState='已导入'")(0)("CityName").ToString, _
        '                            "原来客户所在城市与源文件中的城市不一致！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '            Me.statusText.Text = "原来客户所在城市与源文件中的城市不一致！"
        '    End Select

        '    If dtResult.Rows(0)("Result").ToString = "NoneCharged" AndAlso isSign Then

        '    Else
        '        dtImportedDetails.Dispose() : dtImportedDetails = Nothing
        '        dtResult.Dispose() : dtResult = Nothing
        '        Me.Cursor = Cursors.Default
        '        Return
        '    End If
        'End If

        ''Dim sCustomerID As String = dtResult.Rows(0)("CustomerID").ToString
        'If dtResult.Columns.Count = 2 Then
        '    For Each drCard As DataRow In dtImportedDetails.Select("ImportedState='已导入'")
        '        If dtResult.Select("CardNo='" & drCard("CardNo").ToString & "'").Length = 0 Then
        '            drCard("ImportedState") = "无法导入"
        '            drCard("StateReason") = "该卡从未充过值，不能再充值"
        '            drCard.AcceptChanges()
        '        End If
        '    Next
        'End If
        'dtResult.Dispose() : dtResult = Nothing
        If dtImportedDetails.Select("ImportedState='无法导入'").Length > 0 Then
            For Each drDetail As DataRow In dtImportedDetails.Rows
                If drDetail("ImportedState").ToString <> "无法导入" Then
                    drDetail("ImportedState") = DBNull.Value
                End If
            Next
            With frmImportedFileResult
                dtImportedDetails.DefaultView.RowFilter = "ImportedState='无法导入'"
                .isSign = isSign
                .dtImportedDetails = dtImportedDetails.DefaultView.ToTable
                .Text = "源文件中存在错误，无法导入！"
                .grbResult.Text = "检查结果："
                .lblPrompt.Text = "源文件中存在错误，请在更正错误后重试。"
                .lblPrompt.Visible = True
                .btnClose.Text = "确定(&O)"
                .ShowDialog()
                .Dispose()
            End With
            Me.statusText.Text = "源文件中存在错误，无法导入！"
            dtImportedDetails.Dispose() : dtImportedDetails = Nothing
            Me.Cursor = Cursors.Default
            Return
        End If

        If frmSelling.IsHandleCreated Then
            frmSelling.Activate()
            frmSelling.WindowState = FormWindowState.Maximized

            If isSign Then
                frmSelling.cbbSalesBillType.Items(0) = "实名制卡销售单"
                frmSelling.txbSalesBillType.Text = "实名制卡销售单"
                frmSelling.bNewSalesBillType = 7
            Else
                frmSelling.cbbSalesBillType.Items(0) = "一般销售单"
                frmSelling.txbSalesBillType.Text = "一般销售单"
                frmSelling.bNewSalesBillType = 0
            End If
            frmSelling.sSalesBillID = "-1"
            'modify code 046:start-------------------------------------------------------------------------
            'frmSelling.sCustomerID = sCustomerID
            frmSelling.sCustomerID = ""
            'modify code 046:end-------------------------------------------------------------------------
            frmSelling.blUsedOldCard = False
            frmSelling.ReCreateSalesBill()
        Else
            Me.statusText.Text = "正在打开销售单窗口……"
            Me.statusMain.Refresh()

            If isSign Then
                frmSelling.cbbSalesBillType.Items(0) = "实名制卡销售单"
                frmSelling.txbSalesBillType.Text = "实名制卡销售单"
                frmSelling.bNewSalesBillType = 7
            Else
                frmSelling.cbbSalesBillType.Items(0) = "一般销售单"
                frmSelling.txbSalesBillType.Text = "一般销售单"
                frmSelling.bNewSalesBillType = 0
            End If

            'modify code 046:start-------------------------------------------------------------------------
            'frmSelling.sCustomerID = sCustomerID
            frmSelling.sCustomerID = ""
            'modify code 046:end-------------------------------------------------------------------------
            frmSelling.Show()
            If frmSelling.IsHandleCreated Then
                frmSelling.MdiParent = Me
                frmSelling.WindowState = FormWindowState.Maximized
                frmSelling.Activate()
            End If
        End If

        If frmSelling.IsHandleCreated Then
            Dim dtImportedFile As New DataTable, drImportedFile As DataRow
            With dtImportedFile.Columns
                .Add("SalesBillID", System.Type.GetType("System.Int32"))
                .Add("SourceComputer", System.Type.GetType("System.String"))
                .Add("SourceFile", System.Type.GetType("System.String"))
                .Add("WorkSheet", System.Type.GetType("System.String"))
                .Add("FileSize", System.Type.GetType("System.Int32"))
                .Add("FileModifiedTime", System.Type.GetType("System.DateTime"))
                .Add("CardQTY", System.Type.GetType("System.Int32"))
                .Add("ChargedAMT", System.Type.GetType("System.Decimal"))
            End With
            drImportedFile = dtImportedFile.Copy.Rows.Add
            dtImportedFile.Dispose() : dtImportedFile = Nothing
            drImportedFile("SourceFile") = sFileName
            drImportedFile("WorkSheet") = sWorkSheet
            Try
                Dim fileInfo As IO.FileInfo = My.Computer.FileSystem.GetFileInfo(sFileName)
                drImportedFile("FileSize") = fileInfo.Length
                drImportedFile("FileModifiedTime") = fileInfo.LastWriteTime
                fileInfo = Nothing
            Catch
            End Try
            Dim iCardQTY As Integer = 0, dmChargedAMT As Decimal = 0
            For Each dr As DataRow In dtImportedDetails.Select("ImportedState='已导入'")
                iCardQTY += 1
                dmChargedAMT += CDec(dr("FaceValue"))
            Next
            drImportedFile("CardQTY") = iCardQTY
            drImportedFile("ChargedAMT") = dmChargedAMT
            drImportedFile.AcceptChanges()

            With frmSelling
                .resetCardCostColumn(False)
                .drImportedFile = drImportedFile
                .dtImportedDetails = dtImportedDetails.Copy
                .UpdateInterFaceWhenImportFile()
            End With

            drImportedFile = Nothing

            MessageBox.Show("已将源文件中的卡号导入到新的销售单。    ", "已完成导入操作。", MessageBoxButtons.OK, MessageBoxIcon.Information)

            With frmSelling
                .Activate()
                .dgvNormalCard.Select()
                .dgvPayment.Focus()
                .dgvPayment.Select()
                .dgvPayment.Rows(0).Selected = False
                .dgvPayment("PaymentAMT", 0).Selected = True
                .dgvPayment.BeginEdit(True)

                If .dgvNormalCard.CurrentRow IsNot Nothing Then .dgvNormalCard.CurrentRow.Selected = False
                If .dgvRebateCard.CurrentRow IsNot Nothing Then .dgvRebateCard.CurrentRow.Selected = False
                If .dgvPayment.CurrentRow IsNot Nothing Then .dgvPayment.CurrentRow.Selected = False
            End With

            Me.statusText.Text = "已完成导入操作，请对该销售单进行收款操作。"
        End If

        dtImportedDetails.Dispose() : dtImportedDetails = Nothing
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SetCardCostByCityID(ByVal parmCityID As String)
        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            statusText.Text = "系统因连接不到数据库而无法获取卡成本。请检查数据库连接。"
            Me.Close() : Return
        End If

        Try
            If parmCityID <> String.Empty Then
                dtCardCostManage = DB.GetDataTable("Select * From CardCostManage Where CityID=" & parmCityID).Copy
                If dtCardCostManage.Rows.Count > 0 Then
                    For Each drCardCost As DataRow In dtCardCostManage.Rows
                        If drCardCost("CardType").ToString = CARD_TYPE_84 Then
                            dm84CardCost = Decimal.Parse(drCardCost("CardCost").ToString)
                            bl84CanChanged = Boolean.Parse(drCardCost("CanChanged").ToString)
                        ElseIf drCardCost("CardType").ToString = CARD_TYPE_86 Then
                            dm86CardCost = Decimal.Parse(drCardCost("CardCost").ToString)
                            bl86CanChanged = Boolean.Parse(drCardCost("CanChanged").ToString)
                        ElseIf drCardCost("CardType").ToString = CARD_TYPE_92 Then
                            dm92CardCost = Decimal.Parse(drCardCost("CardCost").ToString)
                            bl92CanChanged = Boolean.Parse(drCardCost("CanChanged").ToString)
                        ElseIf drCardCost("CardType").ToString = CARD_TYPE_94 Then
                            dm94CardCost = Decimal.Parse(drCardCost("CardCost").ToString)
                            bl94CanChanged = Boolean.Parse(drCardCost("CanChanged").ToString)
                        ElseIf drCardCost("CardType").ToString = CARD_TYPE_60 Then
                            dm60CardCost = Decimal.Parse(drCardCost("CardCost").ToString)
                            bl60CanChanged = Boolean.Parse(drCardCost("CanChanged").ToString)
                            'modify code 050:start-------------------------------------------------------------------------
                        ElseIf drCardCost("CardType").ToString = signCardBin Then
                            dmSignCardCost = Decimal.Parse(drCardCost("CardCost").ToString)
                            blSignCanChanged = Boolean.Parse(drCardCost("CanChanged").ToString)
                            'modify code 050:end-------------------------------------------------------------------------
                        End If
                    Next
                End If
            End If

            DB.Close()
        Catch ex As Exception
            DB.Close()
        End Try
    End Sub
    'modify code 046:end-------------------------------------------------------------------------

    Private Sub menuCashActivation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuCashActivation.Click
        'If dtAllowedRight.Select("RightName='CardActivate'").Length = 0 Then
        '    MessageBox.Show("对不起！您没有激活支付方式是""现金/银行卡""的购物卡的权限。    " & Chr(13) & "Sorry, you have no right to active cards which pay term is Cash or Bank Card.    ", "您无权激活""""现金/银行卡"" No activation right for ""Cash/Bank Card""!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Me.menuCashActivation.Enabled = False
        '    If frmNavigation.IsHandleCreated Then frmNavigation.pnlCashActivation.BackgroundImage = My.Resources.CashActivationDisabled
        '    Return
        'End If

        Me.Cursor = Cursors.WaitCursor
        Me.statusText.Text = "正在打开""购物卡激活""窗口……"
        Me.statusMain.Refresh()

        frmCardActivation.Show()
        If frmCardActivation.IsHandleCreated Then
            frmCardActivation.MdiParent = Me
            frmCardActivation.WindowState = FormWindowState.Maximized
            frmCardActivation.Activate()

            If Me.statusText.Text.IndexOf("……") > -1 Then Me.statusText.Text = "就绪。"
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub menuEmployeeActivation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuEmployeeActivation.Click
        Me.Cursor = Cursors.WaitCursor
        Me.statusText.Text = "正在打开""员工卡激活""窗口……"
        Me.statusMain.Refresh()

        frmEmployeeCardActivation.Show()
        If frmEmployeeCardActivation.IsHandleCreated Then
            frmEmployeeCardActivation.MdiParent = Me
            frmEmployeeCardActivation.WindowState = FormWindowState.Maximized
            frmEmployeeCardActivation.Activate()

            If Me.statusText.Text.IndexOf("……") > -1 Then Me.statusText.Text = "就绪。"
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub menuChequeActivation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuChequeActivation.Click
        'If dtAllowedRight.Select("RightName='PaymentConfirm'").Length = 0 Then
        '    MessageBox.Show("对不起！您没有激活支付方式是""转账/支票""的购物卡的权限。    " & Chr(13) & "Sorry, you have no right to active cards which pay term is Transfer or Cheque.    ", "您无权激活""""转账/支票"" No activation right for ""Transfer/Cheque""!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Me.menuChequeActivation.Enabled = False
        '    If frmNavigation.IsHandleCreated Then frmNavigation.pnlChequeActivation.BackgroundImage = My.Resources.ChequeActivationDisabled
        '    Return
        'End If

        Me.Cursor = Cursors.WaitCursor
        Me.statusText.Text = "正在打开""转账/支票""到账确认窗口……"
        Me.statusMain.Refresh()

        frmPaymentConfirmation.Show()
        If frmPaymentConfirmation.IsHandleCreated Then
            frmPaymentConfirmation.MdiParent = Me
            frmPaymentConfirmation.WindowState = FormWindowState.Maximized
            frmPaymentConfirmation.Activate()

            If Me.statusText.Text.IndexOf("……") > -1 Then Me.statusText.Text = "就绪。"
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub menuResetCardPassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuResetCardPassword.Click
        If dtAllowedRight.Select("RightName='ResetCardPassword'").Length = 0 Then
            MessageBox.Show("对不起，您没有""重置/修改购物卡密码""的权限！    ", "您不能进行重置/修改购物卡密码！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.menuResetCardPassword.Enabled = False
        Else
            frmCardPassword.ShowDialog()
            frmCardPassword.Dispose()
        End If
    End Sub

    Private Sub menuFreezeCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuFreezeCard.Click
        If dtAllowedRight.Select("RightName='FreezeCard'").Length = 0 Then
            MessageBox.Show("对不起，您没有""冻结/解冻购物卡""的权限！    ", "您不能进行冻结/解冻购物卡！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.menuFreezeCard.Enabled = False
        Else
            frmFreezeCard.ShowDialog()
            frmFreezeCard.Dispose()
        End If
    End Sub

    Private Sub menuUrgentDeduction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuUrgentDeduction.Click
        If dtAllowedRight.Select("RightName='UrgencyDeduct'").Length = 0 Then
            MessageBox.Show("对不起，您没有""购物卡紧急扣款""的权限！    ", "您不能进行紧急扣款！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.menuUrgentDeduction.Enabled = False
        Else
            frmUrgentDeduction.ShowDialog()
            frmUrgentDeduction.Dispose()
        End If
    End Sub

    Private Sub menuReplaceCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuReplaceCard.Click
        If dtAllowedRight.Select("RightName='ChangeCard'").Length = 0 Then
            MessageBox.Show("对不起，您没有""购物卡换卡申请""的权限！    ", "您不能申请换卡！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.menuReplaceCard.Enabled = False
        Else
            frmReplaceCardRequirement.ShowDialog()
            frmReplaceCardRequirement.Dispose()
        End If
    End Sub

    Private Sub menuReplaceCardValidation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuReplaceCardValidation.Click
        If dtAllowedRight.Select("RightName='AffirmChangeCard'").Length = 0 Then
            MessageBox.Show("对不起，您没有""购物卡换卡确认""的权限！    ", "您不能确认换卡！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.menuReplaceCardValidation.Enabled = False
        Else
            Me.Cursor = Cursors.WaitCursor
            Me.statusText.Text = "正在打开""购物卡换卡确认""窗口……"
            Me.statusMain.Refresh()
            frmReplaceCardValidation.ShowDialog()
            frmReplaceCardValidation.Dispose()
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub menuUnchargeCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuUnchargeCard.Click
        If dtAllowedRight.Select("RightName='UnchargeCard'").Length = 0 Then
            MessageBox.Show("对不起，您没有""购物卡激活撤销申请""的权限！    ", "您不能申请购物卡激活撤销！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.menuUnchargeCard.Enabled = False
        Else
            frmCancelActivationRequirement.ShowDialog()
            frmCancelActivationRequirement.Dispose()
        End If
    End Sub

    Private Sub menuAffirmUnchargeCard_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuAffirmUnchargeCard.Click
        If dtAllowedRight.Select("RightName='AffirmUnchargeCard'").Length = 0 Then
            MessageBox.Show("对不起，您没有""购物卡激活撤销确认""的权限！    ", "您不能确认购物卡激活撤销！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.menuAffirmUnchargeCard.Enabled = False
        Else
            Me.Cursor = Cursors.WaitCursor
            Me.statusText.Text = "正在打开""活动卡激活撤销确认""窗口……"
            Me.statusMain.Refresh()
            frmCancelActivationValidation.ShowDialog()
            frmCancelActivationValidation.Dispose()
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub menuUnchargeMKTCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuUnchargeMKTCard.Click
        If dtAllowedRight.Select("RightName='UnchargeMKTCard'").Length = 0 Then
            MessageBox.Show("对不起，您没有""活动卡激活撤销申请""的权限！    ", "您不能申请活动卡激活撤销！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.menuUnchargeCard.Enabled = False
        Else
            frmCancelMKTActivationRequirement.ShowDialog()
            frmCancelMKTActivationRequirement.Dispose()
        End If
    End Sub

    Private Sub menuAffirmUnchargeMKTCard_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuAffirmUnchargeMKTCard.Click
        If dtAllowedRight.Select("RightName='AffirmUnchargeMKTCard'").Length = 0 Then
            MessageBox.Show("对不起，您没有""活动卡激活撤销确认""的权限！    ", "您不能确认活动卡激活撤销！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.menuAffirmUnchargeCard.Enabled = False
        Else
            Me.Cursor = Cursors.WaitCursor
            Me.statusText.Text = "正在打开""活动卡激活撤销确认""窗口……"
            Me.statusMain.Refresh()
            frmCancelMKTActivationValidation.ShowDialog()
            frmCancelMKTActivationValidation.Dispose()
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub menuGiftCardActivationCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuGiftCardActivationCancel.Click
        If dtAllowedRight.Select("RightName='GiftCardActivationCancel'").Length = 0 Then
            MessageBox.Show("对不起，您没有""礼品卡激活撤销申请""的权限！    ", "您不能申请礼品卡激活撤销！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.menuGiftCardActivationCancel.Enabled = False
        Else
            frmGiftCardCancellationRequirement.ShowDialog()
            frmGiftCardCancellationRequirement.Dispose()
        End If
    End Sub

    Private Sub menuAffirmGiftCardActivationCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuAffirmGiftCardActivationCancel.Click
        If dtAllowedRight.Select("RightName='AffirmGiftCardActivationCancel'").Length = 0 Then
            MessageBox.Show("对不起，您没有""礼品卡激活撤销确认""的权限！    ", "您不能确认礼品卡激活撤销！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.menuGiftCardActivationCancel.Enabled = False
        Else
            frmGiftCardCancellationValidation.ShowDialog()
            frmGiftCardCancellationValidation.Dispose()
        End If
    End Sub

    Private Sub menuGiftCardOfflineActivate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuGiftCardOfflineActivate.Click
        If dtAllowedRight.Select("RightName='GiftCardOfflineActivate'").Length = 0 Then
            MessageBox.Show("对不起，您没有""礼品卡离线激活申请""的权限！    ", "您不能申请礼品卡离线激活！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.menuGiftCardOfflineActivate.Enabled = False
        Else
            frmGiftCardOfflineActivationRequirement.ShowDialog()
            frmGiftCardOfflineActivationRequirement.Dispose()
        End If
    End Sub

    Private Sub menuAffirmGiftCardOfflineActivate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuAffirmGiftCardOfflineActivate.Click
        If dtAllowedRight.Select("RightName='AffirmGiftCardOfflineActivate'").Length = 0 Then
            MessageBox.Show("对不起，您没有""礼品卡离线激活确认""的权限！    ", "您不能确认礼品卡离线激活！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.menuGiftCardOfflineActivate.Enabled = False
        Else
            frmGiftCardOfflineActivationValidation.ShowDialog()
            frmGiftCardOfflineActivationValidation.Dispose()
        End If
    End Sub

    Private Sub menuAffirmRecycleCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuAffirmRecycleCard.Click
        If dtAllowedRight.Select("RightName='AffirmRecycleCard'").Length = 0 Then
            MessageBox.Show("对不起，您没有""购物卡回收确认""的权限！    ", "您不能确认回收购物卡！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.menuRecycleCard.Enabled = False
        Else
            Me.Cursor = Cursors.WaitCursor
            Me.statusText.Text = "正在打开""购物卡回收确认""窗口……"
            Me.statusMain.Refresh()
            frmRecycleCardValidation.ShowDialog()
            frmRecycleCardValidation.Dispose()
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub menuRecycleCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuRecycleCard.Click
        If dtAllowedRight.Select("RightName='RecycleCard'").Length = 0 Then
            MessageBox.Show("对不起，您没有""购物卡回收申请""的权限！    ", "您不能申请回收购物卡！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.menuRecycleCard.Enabled = False
        Else
            frmRecycleCardRequirement.ShowDialog()
            frmRecycleCardRequirement.Dispose()
        End If
    End Sub

    Private Sub menuCardStateQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuCardStateQuery.Click
        If dtAllowedRight.Select("RightName='CardExchangeQuery'").Length = 0 Then
            MessageBox.Show("对不起，您没有""购物卡交易明细查询""的权限！    ", "您不能查询购物卡交易明细！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.menuCardStateQuery.Enabled = False
        Else
            frmDealingQuery.ShowDialog()
            frmDealingQuery.Dispose()
        End If
    End Sub

    Private Sub menuCreateSalesBillFromFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuCreateSalesBillFromFile.Click
        If dtAllowedRight.Select("RightName='SalesBillFromFile'").Length = 0 Then
            MessageBox.Show("对不起！您没有从文件中再充值的权限。    " & Chr(13) & "Sorry, you have no right to recharge card from file.    ", "您无权从文件中充值 No right to recharge card from file!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.menuCreateSalesBillFromFile.Enabled = False
            Return
        End If

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

        If frmSelling.IsHandleCreated AndAlso frmSelling.blIsChanged Then
            frmSelling.Activate()
            frmSelling.WindowState = FormWindowState.Maximized
            Dim bAnswer As DialogResult = MessageBox.Show("是否在导入文件之前，先保存当前销售单？    ", "当前销售单未保存！", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If bAnswer = Windows.Forms.DialogResult.Cancel OrElse (bAnswer = Windows.Forms.DialogResult.Yes AndAlso Not frmSelling.SaveChanges()) Then
                Me.statusText.Text = "因为存在未保存销售单，所以不能导入文件。"
                Return
            End If
        End If

        Dim sStoreID As String = ""
        If sLoginAreaType = "S" Then
            sStoreID = sLoginAreaID
        Else
            frmSelectStore.ShowDialog()
            sStoreID = frmSelectStore.cbbStore.SelectedValue
            frmSelectStore.Dispose()
        End If

        Me.Cursor = Cursors.WaitCursor
        Me.statusText.Text = "正在获取门店销售参数……"

        Dim DB As New DataBase()
        DB.Open()
        If Not DB.IsConnected Then
            Me.statusText.Text = "系统因连接不到数据库而无法获取门店销售参数。请检查数据库连接。"
            Me.Cursor = Cursors.Default
            Return
        End If

        Dim drStore As DataRow = Nothing
        Try
            drStore = DB.GetDataTable("Exec GetStoreParameterWhenSellCard " & sStoreID).Rows(0)
        Catch
            Me.statusText.Text = "系统因在检索数据时出错而无法获取门店销售参数。请联系软件开发人员。"
            DB.Close()
            Me.Cursor = Cursors.Default
            Return
        End Try
        DB.Close()

        Me.statusText.Text = "请选择源文件："
        Me.statusMain.Refresh()

        Dim openFile As New OpenFileDialog(), sFileName As String = "", sWorkSheet As String = ""
        openFile.Title = "请选择想从中导入购物卡号的源文件（Microsoft Excel 文件）："
        openFile.Filter = "源文件（Microsoft Excel 文件）|*.xls"
        openFile.Multiselect = False
        openFile.RestoreDirectory = True

        If openFile.ShowDialog() = Windows.Forms.DialogResult.OK Then sFileName = openFile.FileName
        openFile.Dispose()
        If sFileName = "" Then
            Me.statusText.Text = "您已经取消了导入文件。"
            Me.Cursor = Cursors.Default
            Return
        End If

        Me.statusText.Text = "正在检查源文件……"
        Me.statusMain.Refresh()

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
            MessageBox.Show("打开源文件时发生错误！具体的错误信息如下：    " & Chr(13) & Chr(13) & ex.Message & Space(4) & Chr(13) & Chr(13) & "请检查错误原因，然后重试。如仍有问题，请联系软件开发人员。    ", "打开源文件时发生错误！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            excelAPP = Nothing
            Me.statusText.Text = "打开源文件时发生错误！"
            Me.Cursor = Cursors.Default
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
            If sWorkSheet = "" Then
                Me.statusText.Text = "您已经取消了导入文件。"
                Me.Cursor = Cursors.Default
                Return
            End If

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
                Me.statusText.Text = "打开源文件时发生错误！"
                Me.Cursor = Cursors.Default
                Return
            End Try
        End If

        Dim dtImportedDetails As New DataTable
        dtImportedDetails.Columns.Add("SalesBillID", System.Type.GetType("System.Int32"))
        dtImportedDetails.Columns.Add("RowID", System.Type.GetType("System.Int16"))
        dtImportedDetails.Columns.Add("ErrorColumn", System.Type.GetType("System.Byte"))
        dtImportedDetails.Columns.Add("CityName", System.Type.GetType("System.String"))
        dtImportedDetails.Columns.Add("CardNo", System.Type.GetType("System.String"))
        dtImportedDetails.Columns.Add("FaceValue", System.Type.GetType("System.String"))
        dtImportedDetails.Columns.Add("SalesDate", System.Type.GetType("System.String"))
        dtImportedDetails.Columns.Add("Remarks", System.Type.GetType("System.String"))
        dtImportedDetails.Columns.Add("ImportedState", System.Type.GetType("System.String"))
        dtImportedDetails.Columns.Add("StateReason", System.Type.GetType("System.String"))
        'modify code 046:start-------------------------------------------------------------------------
        dtImportedDetails.Columns.Add("CardCost", System.Type.GetType("System.String"))
        dtImportedDetails.Columns.Add("HolderName", System.Type.GetType("System.String"))
        dtImportedDetails.Columns.Add("Gender", System.Type.GetType("System.String"))
        dtImportedDetails.Columns.Add("HolderIdNo", System.Type.GetType("System.String"))
        dtImportedDetails.Columns.Add("Mobile", System.Type.GetType("System.String"))
        'modify code 046:end-------------------------------------------------------------------------

        excelAPP.ActiveWorkBook.WorkSheets(sWorkSheet).Select()
        With excelAPP.ActiveWorkBook.ActiveSheet
            If .Range("A1").Value.ToString.Trim <> "城市" OrElse .Range("B1").Value.ToString.Trim <> "卡号" OrElse .Range("C1").Value.ToString.Trim <> "面值" OrElse .Range("D1").Value.ToString.Trim <> "销售日期" OrElse .Range("E1").Value.ToString.Trim <> "备注" Then
                MessageBox.Show("源文件格式存在错误！源文件应该由下面五列组成：    " & Chr(13) & Chr(13) & _
                                "城市 + 卡号 + 面值 + 销售日期 + 备注    " & Chr(13) & Chr(13) & _
                                "请确保源文件第一行各单元格的值与上面各列相一致。    ", "源文件格式错误，导入失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                excelAPP = Nothing
                Me.statusText.Text = "源文件格式错误，导入失败！"
                Me.Cursor = Cursors.Default
                Return
            End If

            Dim iRows As Integer = .UsedRange.Rows.Count, drDetail As DataRow, sFirstCity As String = "", sValue As String = "", iRowID As Int16 = -1
            For iRow As Integer = 2 To iRows
                If .Range("A" & iRow.ToString).Value <> "" OrElse .Range("B" & iRow.ToString).Value <> "" OrElse .Range("C" & iRow.ToString).Value <> "" OrElse .Range("D" & iRow.ToString).Value <> "" OrElse .Range("E" & iRow.ToString).Value <> "" Then
                    drDetail = dtImportedDetails.Rows.Add
                    iRowID += 1
                    drDetail("RowID") = iRowID
                    sValue = .Range("A" & iRow.ToString).Value
                    drDetail("CityName") = sValue
                    If sValue = "" Then
                        drDetail("ErrorColumn") = 3
                        drDetail("ImportedState") = "无法导入"
                        drDetail("StateReason") = "未指明城市"
                    ElseIf (drStore("CityChineseName").ToString.IndexOf(sValue) = -1) AndAlso (drStore("CityEnglishName").ToString.IndexOf(sValue) = -1) AndAlso _
                           (drStore("CityChineseName").ToString <> "" AndAlso sValue.IndexOf(drStore("CityChineseName").ToString) = -1) AndAlso _
                           (drStore("CityEnglishName").ToString <> "" AndAlso sValue.IndexOf(drStore("CityEnglishName").ToString) = -1) Then
                        drDetail("ErrorColumn") = 3
                        drDetail("ImportedState") = "无法导入"
                        drDetail("StateReason") = "城市不存在"
                    ElseIf sFirstCity <> "" AndAlso sValue <> sFirstCity Then
                        drDetail("ErrorColumn") = 3
                        drDetail("ImportedState") = "无法导入"
                        drDetail("StateReason") = "非同一城市"
                    End If

                    sValue = .Range("B" & iRow.ToString).Value
                    drDetail("CardNo") = sValue
                    If drDetail("ImportedState").ToString = "" Then
                        If sValue = "" Then
                            drDetail("ErrorColumn") = 4
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "未指明卡号"
                        ElseIf Not IsNumeric(sValue) OrElse sValue.Length <> 19 Then
                            drDetail("ErrorColumn") = 4
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "卡号错误（应由19个数字组成）"
                        ElseIf sValue <> ShoppingCardNo.GetFullCardNo(sValue.Substring(0, 18)) Then
                            drDetail("ErrorColumn") = 4
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "卡号错误（验证码错误）"
                        ElseIf sValue.Substring(0, 4) <> "2336" Then
                            drDetail("ErrorColumn") = 4
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "卡号非法（非银商卡）"
                            'modify code 004:start-------------------------------------------------------------------------
                            'ElseIf sValue.Substring(4, 5) <> drStore("CULCardBin").ToString Then
                        ElseIf sValue.Substring(4, 5) <> drStore("CULCardBin").ToString And sValue.Substring(4, 5) <> "60" & drStore("CULCardBin").ToString.Substring(2, 3) Then
                            'modify code 004:start-------------------------------------------------------------------------
                            drDetail("ErrorColumn") = 4
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "卡号非法（银商卡Bin码（第5至9位）不符）"
                        ElseIf dtImportedDetails.Select("CardNo='" & sValue & "'").Length > 1 Then
                            drDetail("ErrorColumn") = 4
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "卡号重复"
                        End If
                    End If

                    sValue = .Range("C" & iRow.ToString).Value
                    If sValue = "" OrElse Not IsNumeric(sValue) Then
                        drDetail("FaceValue") = sValue
                    Else
                        drDetail("FaceValue") = Format(CDec(sValue), "#,0.00")
                    End If
                    If drDetail("ImportedState").ToString = "" Then
                        If sValue = "" Then
                            drDetail("ErrorColumn") = 5
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "未指明面值"
                        ElseIf Not IsNumeric(sValue) Then
                            drDetail("ErrorColumn") = 5
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "面值错误（应该是数值）"
                        ElseIf CDec(sValue) = 0 Then
                            drDetail("ErrorColumn") = 5
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "面值错误（应该大于零）"
                        ElseIf CDec(sValue) > drStore("MaxFaceValue") Then
                            drDetail("ErrorColumn") = 5
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "面值错误（已经超过最大许可面值" & Format(drStore("MaxFaceValue"), "#,0.00") & "元）"
                        End If
                    End If

                    sValue = .Range("D" & iRow.ToString).Value
                    If sValue = "" OrElse Not IsDate(sValue) Then
                        drDetail("SalesDate") = sValue
                    Else
                        drDetail("SalesDate") = Format(CDate(sValue), "yyyy\/MM\/dd")
                    End If
                    If drDetail("ImportedState").ToString = "" Then
                        If sValue = "" Then
                            drDetail("ErrorColumn") = 6
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "未指明销售日期"
                        ElseIf Not IsDate(sValue) Then
                            drDetail("ErrorColumn") = 6
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "销售日期错误"
                        ElseIf CDate(Format(CDate(sValue), "yyyy\/MM\/dd")) <> CDate(drStore("Today").ToString) Then
                            drDetail("ErrorColumn") = 6
                            drDetail("ImportedState") = "无法导入"
                            drDetail("StateReason") = "指定的销售日期非当天日期（" & drStore("Today").ToString & "）"
                        End If
                    End If

                    If .Range("E" & iRow.ToString).Value <> "" Then drDetail("Remarks") = .Range("E" & iRow.ToString).Value

                    If drDetail("ImportedState").ToString = "" Then
                        drDetail("ImportedState") = "已导入"
                        If sFirstCity = "" Then sFirstCity = drDetail("CityName").ToString
                    End If
                End If
            Next
        End With
        dtImportedDetails.AcceptChanges()

        excelAPP.DisplayAlerts = True
        excelAPP.ActiveWorkBook.Close(False)
        excelAPP.Quit()
        excelAPP = Nothing

        If dtImportedDetails.Rows.Count = 0 Then
            MessageBox.Show("源文件中不存在任何卡号！：    " & Chr(13) & Chr(13) & "请重新选择源文件（或源工作表）。    ", "源文件中不存在任何卡号！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.statusText.Text = "源文件中不存在任何卡号！"
            dtImportedDetails.Dispose() : dtImportedDetails = Nothing
            Me.Cursor = Cursors.Default
            Return
        End If

        Dim dvImportedDetails As DataView = dtImportedDetails.Copy.DefaultView
        dvImportedDetails.RowFilter = "ImportedState='已导入'"
        If dvImportedDetails.Count = 0 Then
            With frmImportedFileResult
                .dtImportedDetails = dtImportedDetails.Copy
                .Text = "源文件中不存在任何满足导入条件的卡号！"
                .grbResult.Text = "检查结果："
                .lblPrompt.Visible = True
                .btnClose.Text = "确定(&O)"
                .ShowDialog()
                .Dispose()
            End With
            Me.statusText.Text = "源文件中不存在任何满足导入条件的卡号！"
            dvImportedDetails.Dispose() : dvImportedDetails = Nothing
            dtImportedDetails.Dispose() : dtImportedDetails = Nothing
            Me.Cursor = Cursors.Default
            Return
        End If

        DB = New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            Me.statusText.Text = "系统因连接不到数据库而无法到数据库检查购物卡状态。请检查数据库连接。"
            Me.Cursor = Cursors.Default
            Return
        End If

        If DB.ModifyTable("Select CardNo Into #tempCard From ImportedFileDetails Where 1=2") = -1 OrElse _
           DB.BulkCopyTable("#tempCard", dvImportedDetails.ToTable(True, "CardNo")) = -1 Then
            Me.statusText.Text = "到数据库检查购物卡状态时出现错误！"
            dvImportedDetails.Dispose() : dvImportedDetails = Nothing
            dtImportedDetails.Dispose() : dtImportedDetails = Nothing
            DB.Close() : Me.Cursor = Cursors.Default
            Return
        End If
        dvImportedDetails.Dispose() : dvImportedDetails = Nothing

        Dim dtResult As DataTable = DB.GetDataTable("Exec CheckImportedCard " & dtLoginStructure.Rows.Find(sStoreID)("ParentAreaID").ToString)
        DB.Close()

        If dtResult Is Nothing Then
            Me.statusText.Text = "到数据库检查购物卡状态时出现错误！"
            dtImportedDetails.Dispose() : dtImportedDetails = Nothing
            Me.Cursor = Cursors.Default
            Return
        End If

        If dtResult.Rows(0)("Result").ToString <> "OK" Then
            Select Case dtResult.Rows(0)("Result").ToString
                Case "NoneCharged"
                    If dtImportedDetails.Select("ImportedState='无法导入'").Length = 0 Then
                        MessageBox.Show("源文件所包含的购物卡均未充过值，所以无法对它们进行再充值！    ", "源文件中的购物卡从未充过值！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.statusText.Text = "源文件中的购物卡从未充过值！"
                    Else
                        For Each drCard As DataRow In dtImportedDetails.Select("ImportedState='已导入'")
                            drCard("ImportedState") = "无法导入"
                            drCard("StateReason") = "该卡从未充过值，不能再充值"
                            drCard.AcceptChanges()
                        Next

                        With frmImportedFileResult
                            .dtImportedDetails = dtImportedDetails.Copy
                            .Text = "源文件中不存在任何满足导入条件的卡号！"
                            .grbSource.Text = "检查结果："
                            .lblPrompt.Visible = True
                            .btnClose.Text = "确定(&O)"
                            .ShowDialog()
                            .Dispose()
                        End With
                        Me.statusText.Text = "源文件中不存在任何满足导入条件的卡号！"
                    End If
                Case "NotCompany"
                    MessageBox.Show("源文件的购物卡的原来客户是个人客户，不是公司客户！    " & Chr(13) & Chr(13) & """从文件再充值""操作仅适用于公司客户，不适用于个人客户。    ", "非公司客户不能使用""从文件再充值""操作！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.statusText.Text = "非公司客户不能使用""从文件再充值""操作！"
                Case "CustomerDeleted"
                    MessageBox.Show("源文件的购物卡的原来客户已被删除，导入充值无效！    ", "源文件的购物卡的原来客户已被删除！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.statusText.Text = "源文件的购物卡的原来客户已被删除！"
                Case "CustomerStopped"
                    MessageBox.Show("源文件的购物卡的原来客户已被停止使用，再也不能向该客户充值！    " & Chr(13) & Chr(13) & _
                                    "客户名称： " & dtResult.Rows(0)("CustomerName").ToString & Space(4) & _
                                    IIf(dtResult.Rows(0)("StoppedReason").ToString = "", "", Chr(13) & "停用原因： " & dtResult.Rows(0)("StoppedReason").ToString), "源文件的购物卡的原来客户已被停止使用！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.statusText.Text = "源文件的购物卡的原来客户已被停止使用！"
                Case Else
                    MessageBox.Show("源文件的购物卡的原来客户所在的城市与源文件所指出的城市不一致，导入充值无效！    " & Chr(13) & Chr(13) & _
                                    "      客户名称： " & dtResult.Rows(0)("CustomerName").ToString & Space(4) & Chr(13) & _
                                    "      所在城市： " & dtResult.Rows(0)("CityName").ToString & Space(4) & Chr(13) & _
                                    "源文件中的城市： " & dtImportedDetails.Select("ImportedState='已导入'")(0)("CityName").ToString, _
                                    "原来客户所在城市与源文件中的城市不一致！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.statusText.Text = "原来客户所在城市与源文件中的城市不一致！"
            End Select

            dtImportedDetails.Dispose() : dtImportedDetails = Nothing
            dtResult.Dispose() : dtResult = Nothing
            Me.Cursor = Cursors.Default
            Return
        End If

        Dim sCustomerID As String = dtResult.Rows(0)("CustomerID").ToString
        If dtResult.Columns.Count = 3 Then
            For Each drCard As DataRow In dtImportedDetails.Select("ImportedState='已导入'")
                If dtResult.Select("CardNo='" & drCard("CardNo").ToString & "'").Length = 0 Then
                    drCard("ImportedState") = "无法导入"
                    drCard("StateReason") = "该卡从未充过值，不能再充值"
                    drCard.AcceptChanges()
                End If
            Next
        End If
        dtResult.Dispose() : dtResult = Nothing
        If dtImportedDetails.Select("ImportedState='无法导入'").Length > 0 Then
            For Each drDetail As DataRow In dtImportedDetails.Rows
                If drDetail("ImportedState").ToString <> "无法导入" Then
                    drDetail("ImportedState") = DBNull.Value
                End If
            Next
            With frmImportedFileResult
                dtImportedDetails.DefaultView.RowFilter = "ImportedState='无法导入'"
                .dtImportedDetails = dtImportedDetails.DefaultView.ToTable
                .Text = "源文件中存在错误，无法导入！"
                .grbResult.Text = "检查结果："
                .lblPrompt.Text = "源文件中存在错误，请在更正错误后重试。"
                .lblPrompt.Visible = True
                .btnClose.Text = "确定(&O)"
                .ShowDialog()
                .Dispose()
            End With
            Me.statusText.Text = "源文件中存在错误，无法导入！"
            dtImportedDetails.Dispose() : dtImportedDetails = Nothing
            Me.Cursor = Cursors.Default
            Return
        End If

        If frmSelling.IsHandleCreated Then
            frmSelling.Activate()
            frmSelling.WindowState = FormWindowState.Maximized

            frmSelling.cbbSalesBillType.Items(0) = "一般销售单"
            frmSelling.sSalesBillID = "-1"
            frmSelling.sCustomerID = sCustomerID
            frmSelling.bNewSalesBillType = 0
            frmSelling.blUsedOldCard = False
            frmSelling.ReCreateSalesBill()
        Else
            Me.statusText.Text = "正在打开销售单窗口……"
            Me.statusMain.Refresh()

            frmSelling.sCustomerID = sCustomerID
            frmSelling.Show()
            If frmSelling.IsHandleCreated Then
                frmSelling.MdiParent = Me
                frmSelling.WindowState = FormWindowState.Maximized
                frmSelling.Activate()
            End If
        End If

        If frmSelling.IsHandleCreated Then
            Dim dtImportedFile As New DataTable, drImportedFile As DataRow
            With dtImportedFile.Columns
                .Add("SalesBillID", System.Type.GetType("System.Int32"))
                .Add("SourceComputer", System.Type.GetType("System.String"))
                .Add("SourceFile", System.Type.GetType("System.String"))
                .Add("WorkSheet", System.Type.GetType("System.String"))
                .Add("FileSize", System.Type.GetType("System.Int32"))
                .Add("FileModifiedTime", System.Type.GetType("System.DateTime"))
                .Add("CardQTY", System.Type.GetType("System.Int32"))
                .Add("ChargedAMT", System.Type.GetType("System.Decimal"))
            End With
            drImportedFile = dtImportedFile.Copy.Rows.Add
            dtImportedFile.Dispose() : dtImportedFile = Nothing
            drImportedFile("SourceFile") = sFileName
            drImportedFile("WorkSheet") = sWorkSheet
            Try
                Dim fileInfo As IO.FileInfo = My.Computer.FileSystem.GetFileInfo(sFileName)
                drImportedFile("FileSize") = fileInfo.Length
                drImportedFile("FileModifiedTime") = fileInfo.LastWriteTime
                fileInfo = Nothing
            Catch
            End Try
            Dim iCardQTY As Integer = 0, dmChargedAMT As Decimal = 0
            For Each dr As DataRow In dtImportedDetails.Select("ImportedState='已导入'")
                iCardQTY += 1
                dmChargedAMT += CDec(dr("FaceValue"))
            Next
            drImportedFile("CardQTY") = iCardQTY
            drImportedFile("ChargedAMT") = dmChargedAMT
            drImportedFile.AcceptChanges()

            With frmSelling
                .drImportedFile = drImportedFile
                .dtImportedDetails = dtImportedDetails.Copy
                .UpdateInterFaceWhenImportFile()
            End With

            drImportedFile = Nothing
            'If dtImportedDetails.Select("ImportedState='无法导入'").Length > 0 Then
            '    MessageBox.Show("已将源文件中符合导入条件的卡号导入到新的销售单。    " & Chr(13) & Chr(13) & _
            '                    "但也有部分记录因不符合导入条件而未被导入，具体原因请查看导入结果。    " & Chr(13) & Chr(13) & _
            '                    "请在客户付款后按""付款确认""按钮保存该销售单。否则，该导入结果将被废弃！    ", "已完成导入操作。", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Else
            '    MessageBox.Show("已将源文件中的卡号导入到新的销售单。    " & Chr(13) & Chr(13) & _
            '                    "请在客户付款后按""付款确认""按钮保存该销售单。否则，该导入结果将被废弃！    ", "已完成导入操作。", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End If
            MessageBox.Show("已将源文件中的卡号导入到新的销售单。    ", "已完成导入操作。", MessageBoxButtons.OK, MessageBoxIcon.Information)

            With frmSelling
                .Activate()
                .dgvNormalCard.Select()
                .dgvPayment.Focus()
                .dgvPayment.Select()
                .dgvPayment.Rows(0).Selected = False
                .dgvPayment("PaymentAMT", 0).Selected = True
                .dgvPayment.BeginEdit(True)

                If .dgvNormalCard.CurrentRow IsNot Nothing Then .dgvNormalCard.CurrentRow.Selected = False
                If .dgvRebateCard.CurrentRow IsNot Nothing Then .dgvRebateCard.CurrentRow.Selected = False
                If .dgvPayment.CurrentRow IsNot Nothing Then .dgvPayment.CurrentRow.Selected = False
            End With

            Me.statusText.Text = "已完成导入操作，请对该销售单进行收款操作。"
        End If

        dtImportedDetails.Dispose() : dtImportedDetails = Nothing
        Me.Cursor = Cursors.Default
    End Sub

    'Private Sub menuSalesBillRecharge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If dtAllowedRight.Select("RightName='SalesBillRecharge'").Length = 0 Then
    '        MessageBox.Show("对不起！您没有购物卡再充值的权限。    " & Chr(13) & "Sorry, you have no right to recharge card.    ", "您无权对购物卡进行再充值 No right to recharge card!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '        Me.menuSalesBillRecharge.Enabled = False
    '        Return
    '    End If

    '    If frmSelling.IsHandleCreated Then
    '        frmSelling.Activate()
    '        frmSelling.WindowState = FormWindowState.Maximized
    '    End If

    '    Dim bAnswer As DialogResult = Windows.Forms.DialogResult.Cancel
    '    If frmSelling.IsHandleCreated AndAlso frmSelling.blIsChanged Then
    '        bAnswer = MessageBox.Show("您即将进入购物卡再充值销售模式……    " & Chr(13) & Chr(13) & _
    '                                  "购物卡再充值是指对至少已充值过一次的购物卡再一次充值。    " & Chr(13) & _
    '                                  "因此，只有已经充值过的购物卡才可以选择该操作。    " & Chr(13) & Chr(13) & _
    '                                  "购物卡再充值时，最小充值金额将不受限制（大于零即可）。   " & Chr(13) & _
    '                                  "但每张购物卡必须独占一行（每一行不能连号）。    " & Chr(13) & Chr(13) & _
    '                                  "请按""确定""按钮进入购物卡再充值销售模式。    " & Chr(13) & Chr(13) & _
    '                                  "注意：确认后，当前未保存的销售单将被自动放弃保存！    ", _
    '                                  "请确认进入购物卡再充值销售模式：", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
    '    Else
    '        bAnswer = MessageBox.Show("您即将进入购物卡再充值销售模式……    " & Chr(13) & Chr(13) & _
    '                                  "购物卡再充值是指对至少已充值过一次的购物卡再一次充值。    " & Chr(13) & _
    '                                  "因此，只有已经充值过的购物卡才可以选择该操作。    " & Chr(13) & Chr(13) & _
    '                                  "购物卡再充值时，最小充值金额将不受限制（大于零即可）。   " & Chr(13) & _
    '                                  "但每张购物卡必须独占一行（每一行不能连号）。    " & Chr(13) & Chr(13) & _
    '                                  "请按""确定""按钮进入购物卡再充值销售模式。    ", _
    '                                  "请确认进入购物卡再充值销售模式：", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
    '    End If
    '    If bAnswer = Windows.Forms.DialogResult.Cancel Then Return

    '    If frmSelling.IsHandleCreated Then
    '        frmSelling.Activate()
    '        frmSelling.WindowState = FormWindowState.Maximized

    '        frmSelling.cbbSalesBillType.Items(0) = "一般销售单"
    '        frmSelling.sCustomerID = ""
    '        frmSelling.bNewSalesBillType = 0
    '        frmSelling.blUsedOldCard = True
    '        frmSelling.ReCreateSalesBill()
    '        frmSelling.blUsedOldCard = True
    '    Else
    '        Me.Cursor = Cursors.WaitCursor
    '        Me.statusText.Text = "正在打开销售单窗口……"
    '        Me.statusMain.Refresh()

    '        frmSelling.bNewSalesBillType = 0
    '        frmSelling.blUsedOldCard = True
    '        frmSelling.Show()
    '        If frmSelling.IsHandleCreated Then
    '            frmSelling.MdiParent = Me
    '            frmSelling.WindowState = FormWindowState.Maximized
    '            frmSelling.Activate()
    '        End If

    '        If Me.statusText.Text.IndexOf("……") > -1 Then Me.statusText.Text = "就绪。"
    '        Me.Cursor = Cursors.Default
    '    End If

    '    If frmSelling.IsHandleCreated Then
    '        With frmSelling
    '            With .dgvNormalCard
    '                .Columns("EndCardNo").ReadOnly = True
    '                .Columns("CardQTY").ReadOnly = True
    '                .Columns("CardCost").Visible = False
    '            End With

    '            With .dgvRebateCard
    '                .Columns("EndCardNo").ReadOnly = True
    '                .Columns("CardQTY").ReadOnly = True
    '            End With

    '            If .dgvNormalCard.CurrentRow IsNot Nothing Then .dgvNormalCard.CurrentRow.Selected = False
    '            If .dgvRebateCard.CurrentRow IsNot Nothing Then .dgvRebateCard.CurrentRow.Selected = False
    '            If .dgvPayment.CurrentRow IsNot Nothing Then .dgvPayment.CurrentRow.Selected = False
    '        End With
    '    End If
    'End Sub

    Private Sub menuCreateReturnedSalesBill_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuCreateReturnedSalesBill.Click
        If dtAllowedRight.Select("RightName='SalesBillReturnedCreate'").Length = 0 Then
            MessageBox.Show("对不起！您没有创建退货销售单的权限。    " & Chr(13) & "Sorry, you have no right to create sales bill.    ", "您无权创建退货销售单 No right to create sales bill!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.menuCreateReturnedSalesBill.Enabled = False
            Return
        End If

        If frmSelling.IsHandleCreated Then
            frmSelling.Activate()
            frmSelling.WindowState = FormWindowState.Maximized
            If frmSelling.blIsChanged Then
                Dim bAnswer As DialogResult = MessageBox.Show("是否在新建销售单之前，先保存当前销售单？    ", "当前销售单未保存！", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                If bAnswer = Windows.Forms.DialogResult.Cancel OrElse (bAnswer = Windows.Forms.DialogResult.Yes AndAlso Not frmSelling.SaveChanges()) Then
                    Me.Activate()
                    Me.statusText.Text = "因为存在未保存销售单，所以不能新建销售单。"
                    Return
                End If
            End If

            frmSelling.cbbSalesBillType.Items(0) = "退货销售单"
            frmSelling.sCustomerID = ""
            frmSelling.bNewSalesBillType = 1
            frmSelling.blUsedOldCard = True
            frmSelling.ReCreateSalesBill()
        Else
            Me.Cursor = Cursors.WaitCursor
            Me.statusText.Text = "正在打开销售单窗口……"
            Me.statusMain.Refresh()

            frmSelling.cbbSalesBillType.Items(0) = "退货销售单"
            frmSelling.bNewSalesBillType = 1
            frmSelling.blUsedOldCard = True
            frmSelling.Show()
            If frmSelling.IsHandleCreated Then
                frmSelling.MdiParent = Me
                frmSelling.WindowState = FormWindowState.Maximized
                frmSelling.Activate()
            End If

            If Me.statusText.Text.IndexOf("……") > -1 Then Me.statusText.Text = "就绪。"
            Me.Cursor = Cursors.Default
        End If

        If frmSelling.IsHandleCreated Then
            If frmSelling.dgvNormalCard.CurrentRow IsNot Nothing Then frmSelling.dgvNormalCard.CurrentRow.Selected = False
            If frmSelling.dgvRebateCard.CurrentRow IsNot Nothing Then frmSelling.dgvRebateCard.CurrentRow.Selected = False
            If frmSelling.dgvPayment.CurrentRow IsNot Nothing Then frmSelling.dgvPayment.CurrentRow.Selected = False
        End If
    End Sub

    Private Sub menuMarketingPromotion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuMarketingPromotion.Click
        If frmSelling.IsHandleCreated Then
            frmSelling.Activate()
            frmSelling.WindowState = FormWindowState.Maximized
            If frmSelling.blIsChanged Then
                Dim bAnswer As DialogResult = MessageBox.Show("是否在新建销售单之前，先保存当前销售单？    ", "当前销售单未保存！", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                If bAnswer = Windows.Forms.DialogResult.Cancel OrElse (bAnswer = Windows.Forms.DialogResult.Yes AndAlso Not frmSelling.SaveChanges()) Then
                    Me.Activate()
                    Me.statusText.Text = "因为存在未保存销售单，所以不能新建销售单。"
                    Return
                End If
            End If

            frmSelling.cbbSalesBillType.Items(0) = "活动卡销售单"
            frmSelling.sCustomerID = ""
            frmSelling.bNewSalesBillType = 2
            frmSelling.blUsedOldCard = False
            frmSelling.ReCreateSalesBill()
        Else
            Me.Cursor = Cursors.WaitCursor
            Me.statusText.Text = "正在打开销售单窗口……"
            Me.statusMain.Refresh()

            frmSelling.cbbSalesBillType.Items(0) = "活动卡销售单"
            frmSelling.bNewSalesBillType = 2
            frmSelling.blUsedOldCard = False
            frmSelling.Show()
            If frmSelling.IsHandleCreated Then
                frmSelling.MdiParent = Me
                frmSelling.WindowState = FormWindowState.Maximized
                frmSelling.Activate()
            End If

            If Me.statusText.Text.IndexOf("……") > -1 Then Me.statusText.Text = "就绪。"
            Me.Cursor = Cursors.Default
        End If

        If frmSelling.IsHandleCreated Then
            If frmSelling.dgvNormalCard.CurrentRow IsNot Nothing Then frmSelling.dgvNormalCard.CurrentRow.Selected = False
            If frmSelling.dgvRebateCard.CurrentRow IsNot Nothing Then frmSelling.dgvRebateCard.CurrentRow.Selected = False
            If frmSelling.dgvPayment.CurrentRow IsNot Nothing Then frmSelling.dgvPayment.CurrentRow.Selected = False
        End If
    End Sub

    Private Sub menuPRCard_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuPRCard.Click
        If frmSelling.IsHandleCreated Then
            frmSelling.Activate()
            frmSelling.WindowState = FormWindowState.Maximized
            If frmSelling.blIsChanged Then
                Dim bAnswer As DialogResult = MessageBox.Show("是否在新建销售单之前，先保存当前销售单？    ", "当前销售单未保存！", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                If bAnswer = Windows.Forms.DialogResult.Cancel OrElse (bAnswer = Windows.Forms.DialogResult.Yes AndAlso Not frmSelling.SaveChanges()) Then
                    Me.Activate()
                    Me.statusText.Text = "因为存在未保存销售单，所以不能新建销售单。"
                    Return
                End If
            End If

            frmSelling.cbbSalesBillType.Items(0) = "公关卡销售单"
            frmSelling.sCustomerID = ""
            frmSelling.bNewSalesBillType = 3
            frmSelling.blUsedOldCard = False
            frmSelling.ReCreateSalesBill()
        Else
            Me.Cursor = Cursors.WaitCursor
            Me.statusText.Text = "正在打开销售单窗口……"
            Me.statusMain.Refresh()

            frmSelling.cbbSalesBillType.Items(0) = "公关卡销售单"
            frmSelling.bNewSalesBillType = 3
            frmSelling.blUsedOldCard = False
            frmSelling.Show()
            If frmSelling.IsHandleCreated Then
                frmSelling.MdiParent = Me
                frmSelling.WindowState = FormWindowState.Maximized
                frmSelling.Activate()
            End If

            If Me.statusText.Text.IndexOf("……") > -1 Then Me.statusText.Text = "就绪。"
            Me.Cursor = Cursors.Default
        End If

        If frmSelling.IsHandleCreated Then
            If frmSelling.dgvNormalCard.CurrentRow IsNot Nothing Then frmSelling.dgvNormalCard.CurrentRow.Selected = False
            If frmSelling.dgvRebateCard.CurrentRow IsNot Nothing Then frmSelling.dgvRebateCard.CurrentRow.Selected = False
            If frmSelling.dgvPayment.CurrentRow IsNot Nothing Then frmSelling.dgvPayment.CurrentRow.Selected = False
        End If
    End Sub

    Private Sub menuEmployeeSales_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuEmployeeSales.Click
        If frmSelling.IsHandleCreated Then
            frmSelling.Activate()
            frmSelling.WindowState = FormWindowState.Maximized
            If frmSelling.blIsChanged Then
                Dim bAnswer As DialogResult = MessageBox.Show("是否在新建销售单之前，先保存当前销售单？    ", "当前销售单未保存！", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                If bAnswer = Windows.Forms.DialogResult.Cancel OrElse (bAnswer = Windows.Forms.DialogResult.Yes AndAlso Not frmSelling.SaveChanges()) Then
                    Me.Activate()
                    Me.statusText.Text = "因为存在未保存销售单，所以不能新建销售单。"
                    Return
                End If
            End If

            frmSelling.cbbSalesBillType.Items(0) = "员工销售单"
            frmSelling.sCustomerID = ""
            frmSelling.bNewSalesBillType = 4
            frmSelling.blUsedOldCard = False
            frmSelling.ReCreateSalesBill()
        Else
            Me.Cursor = Cursors.WaitCursor
            Me.statusText.Text = "正在打开销售单窗口……"
            Me.statusMain.Refresh()

            frmSelling.cbbSalesBillType.Items(0) = "员工销售单"
            frmSelling.bNewSalesBillType = 4
            frmSelling.blUsedOldCard = False
            frmSelling.Show()
            If frmSelling.IsHandleCreated Then
                frmSelling.MdiParent = Me
                frmSelling.WindowState = FormWindowState.Maximized
                frmSelling.Activate()
                frmSelling.btnEmployeeNo.Text = "确定" '表示员工卡销售窗口初始化完毕
            End If

            If Me.statusText.Text.IndexOf("……") > -1 Then Me.statusText.Text = "就绪。"
            Me.Cursor = Cursors.Default
        End If

        If frmSelling.IsHandleCreated Then
            If frmSelling.dgvNormalCard.CurrentRow IsNot Nothing Then frmSelling.dgvNormalCard.CurrentRow.Selected = False
            If frmSelling.dgvRebateCard.CurrentRow IsNot Nothing Then frmSelling.dgvRebateCard.CurrentRow.Selected = False
            If frmSelling.dgvPayment.CurrentRow IsNot Nothing Then frmSelling.dgvPayment.CurrentRow.Selected = False
        End If
    End Sub

    Private Sub menuCobrandCard_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuCobrandCard.Click
        If frmSelling.IsHandleCreated Then
            frmSelling.Activate()
            frmSelling.WindowState = FormWindowState.Maximized
            If frmSelling.blIsChanged Then
                Dim bAnswer As DialogResult = MessageBox.Show("是否在新建销售单之前，先保存当前销售单？    ", "当前销售单未保存！", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                If bAnswer = Windows.Forms.DialogResult.Cancel OrElse (bAnswer = Windows.Forms.DialogResult.Yes AndAlso Not frmSelling.SaveChanges()) Then
                    Me.Activate()
                    Me.statusText.Text = "因为存在未保存销售单，所以不能新建销售单。"
                    Return
                End If
            End If

            frmSelling.cbbSalesBillType.Items(0) = "联名卡销售单"
            frmSelling.sCustomerID = ""
            frmSelling.bNewSalesBillType = 5
            frmSelling.blUsedOldCard = False
            frmSelling.ReCreateSalesBill()
        Else
            Me.Cursor = Cursors.WaitCursor
            Me.statusText.Text = "正在打开销售单窗口……"
            Me.statusMain.Refresh()

            frmSelling.cbbSalesBillType.Items(0) = "联名卡销售单"
            frmSelling.bNewSalesBillType = 5
            frmSelling.blUsedOldCard = False
            frmSelling.Show()
            If frmSelling.IsHandleCreated Then
                frmSelling.MdiParent = Me
                frmSelling.WindowState = FormWindowState.Maximized
                frmSelling.Activate()
            End If

            If Me.statusText.Text.IndexOf("……") > -1 Then Me.statusText.Text = "就绪。"
            Me.Cursor = Cursors.Default
        End If

        If frmSelling.IsHandleCreated Then
            If frmSelling.dgvNormalCard.CurrentRow IsNot Nothing Then frmSelling.dgvNormalCard.CurrentRow.Selected = False
            If frmSelling.dgvRebateCard.CurrentRow IsNot Nothing Then frmSelling.dgvRebateCard.CurrentRow.Selected = False
            If frmSelling.dgvPayment.CurrentRow IsNot Nothing Then frmSelling.dgvPayment.CurrentRow.Selected = False
        End If
    End Sub

    Private Sub menuCardFee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuCardFee.Click
        frmCardFee.ShowDialog()
        frmCardFee.Dispose()
    End Sub

    Private Sub menuPredefineFaceValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuPredefineFaceValue.Click
        frmPredefineFaceValue.ShowDialog()
        frmPredefineFaceValue.Dispose()
    End Sub

    Private Sub menuInvoiceDeviceTesting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuInvoiceDeviceTesting.Click
        frmInvoiceDeviceTesting.ShowDialog()
        frmInvoiceDeviceTesting.Dispose()
    End Sub

    Private Sub menuInvoiceCancellation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuInvoiceCancellation.Click
        Me.Refresh()
        If Not blInvoiceDeviceOK Then Me.InvoiceDeviceCheck()
        If blInvoiceDeviceOK Then
            Dim objInvoice As Object = Nothing, sInvoiceCode As String = "", sInvoiceNo As String = ""
            Try
                objInvoice = CreateObject("PZHPrj.ComDLL")
                sInvoiceCode = objInvoice.GetCurrInvNOs()
                If sInvoiceCode = "35" Then
                    MessageBox.Show("发票已用完！    ", "发票已用完！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf sInvoiceCode.IndexOf("0") <> 0 Then
                    MessageBox.Show("无法从开票器获取当前的发票号码！错误代码：" & sInvoiceCode & "。    ", "获取当前的发票号码失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    sInvoiceNo = sInvoiceCode.Substring(sInvoiceCode.LastIndexOf(",") + 1)
                    sInvoiceCode = sInvoiceCode.Substring(sInvoiceCode.IndexOf(",") + 1, 12)
                    With frmInvoiceCancellation
                        .txbInvoiceCode.Text = sInvoiceCode
                        .txbInvoiceNo.Text = sInvoiceNo
                        .ShowDialog()
                        .Dispose()
                    End With
                End If
            Catch
                blInvoiceDeviceOK = False
            End Try
            objInvoice = Nothing
        End If
    End Sub

    Private Sub menuDailyReport1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuDailyReport1.Click
        frmDailyRep1.Show()
        frmDailyRep1.MdiParent = Me
        frmDailyRep1.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub menuDailyReport2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuDailyReport2.Click
        frmDailyRep2.Show()
        frmDailyRep2.MdiParent = Me
        frmDailyRep2.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub menuDailyReport3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuDailyReport3.Click
        frmDailyRep3.Show()
        frmDailyRep3.MdiParent = Me
        frmDailyRep3.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub menuDailyReport4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuDailyReport4.Click
        frmDailyRep4.Show()
        frmDailyRep4.MdiParent = Me
        frmDailyRep4.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub menuDailyReport5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuDailyReport5.Click
        frmDailyRep5.Show()
        frmDailyRep5.MdiParent = Me
        frmDailyRep5.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub menuDailyReport6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuDailyReport6.Click
        frmDailyRep6.Show()
        frmDailyRep6.MdiParent = Me
        frmDailyRep6.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub menuMonthReport1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuMonthReport1.Click
        frmMonthRep1.Show()
        frmMonthRep1.MdiParent = Me
        frmMonthRep1.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub menuMonthReport2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuMonthReport2.Click
        frmMonthRep2.Show()
        frmMonthRep2.MdiParent = Me
        frmMonthRep2.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub menuMonthReport3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuMonthReport3.Click
        frmMonthRep3.Show()
        frmMonthRep3.MdiParent = Me
        frmMonthRep3.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub menuMonthReport4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuMonthReport4.Click
        frmMonthRep4.Show()
        frmMonthRep4.MdiParent = Me
        frmMonthRep4.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub menuYearlyReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuYearlyReport.Click
        frmColumnMonth1.Show()
        frmColumnMonth1.MdiParent = Me
        frmColumnMonth1.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub menuDailybyCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuDailybyCustomer.Click
        frmDailyCustomer.Show()
        frmDailyCustomer.MdiParent = Me
        frmDailyCustomer.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub menuFishReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuFishReport.Click
        frmFishReport1.Show()
        frmFishReport1.MdiParent = Me
        frmFishReport1.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub menuSmallTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuSmallTool.Click
        frmSmallTool.ShowDialog()
        frmSmallTool.Dispose()
    End Sub

    Private Sub menuJVReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuJVReport.Click
        frmJVReport.ShowDialog()
        frmJVReport.Dispose()
    End Sub

    Private Sub menuCustomExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuCustomExport.Click
        'modify code 043:start-------------------------------------------------------------------------
        Dim sRight As String = "|Customer|Contract|SalesBill|SalesBillDetails|Payment|Invoice|"
        If sLoginRoleID = "7" Then sRight = "|SalesBillJV|SalesBillDetails|Payment|Invoice|" '城市财务经理
        If sLoginRoleID = "16" Then sRight = "|SalesBill|SalesBillDetails|Payment|" '门店绩效经理
        If My.Settings.IsInTraining = True Then '培训模式
            Dim newReport As New report.SCReport(sLoginUserID, sTrainingConnection, sRight)
        Else
            Dim newReport As New report.SCReport(sLoginUserID, sReportConnection, sRight)
        End If
        'frmCustomReport.ShowDialog()
        'frmCustomReport.Dispose()
        'modify code 043:end-------------------------------------------------------------------------
    End Sub

    Private Sub menuCULReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuCULReport.Click
        With frmCULReport
            If .IsHandleCreated Then
                .Activate()
            Else
                .Show()
                If .IsHandleCreated Then
                    .trvDate.SelectedNode = .trvDate.Nodes(0).Nodes(0).Nodes(0)
                    .trvDate.SelectedNode.EnsureVisible()
                    .trvDate.Select()
                    .trvMerchant.ExpandAll()
                    If .trvMerchant.Nodes(0).Tag.ToString = "Yes" Then
                        .trvMerchant.SelectedNode = .trvMerchant.Nodes(0)
                    Else
                        .trvMerchant.SelectedNode = .trvMerchant.Nodes(0).Nodes(0)
                    End If
                    .trvMerchant.SelectedNode.EnsureVisible()
                    .trvMerchant.Select()
                End If
            End If
        End With
    End Sub

    Private Sub menuHotLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuHotLine.Click
        frmHotLine.ShowDialog()
        frmHotLine.Dispose()
    End Sub

    Private Sub menuMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuMessage.Click
        'If Me.menuMessage.Checked Then
        '    If frmMessageValidated.IsHandleCreated Then frmMessageValidated.Dispose()
        '    If frmMessageNeedValidate.IsHandleCreated Then frmMessageNeedValidate.Dispose()
        '    Me.notifyMessage.Visible = False
        '    Me.timerMessage.Enabled = False
        '    Me.menuMessage.Checked = False
        'Else
        '    Me.menuMessage.Checked = True
        '    Me.timerMessage.Interval = 500
        '    Me.timerMessage.Enabled = True
        'End If

        'Dim DB As New DataBase
        'DB.Open()
        'If DB.IsConnected Then
        '    Try
        '        If blCanValidateNormalRebate Then
        '            iMessages = DB.GetDataTable("Select Count(*) From MessageNormalRebateNeedValidate As M Join AreaScope(" & sLoginUserID & ") As S On M.StoreID=S.AreaID Where M.NormalRebateApprovableRoleID=" & sLoginRoleID).Rows(0)(0)
        '        Else
        '            iMessages = DB.GetDataTable("Select Count(*) From MessageNormalRebateValidated As M Join AreaScope(" & sLoginUserID & ") As S On M.StoreID=S.AreaID").Rows(0)(0)
        '        End If
        '    Catch
        '        iMessages = 0
        '    End Try
        '    DB.Close()
        'End If
        If blCanValidateNormalRebate Then frmMessageNeedValidate.ShowDialog() Else frmMessageValidated.ShowDialog()
    End Sub

    Private Sub timerMessage_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerMessage.Tick
        Me.timerMessage.Enabled = False

        If My.Computer.Network.IsAvailable Then
            Dim DB As New DataBase
            DB.Open()
            If DB.IsConnected Then
                Try
                    If blCanValidateNormalRebate Then
                        iMessages = DB.GetDataTable("Select Count(*) From MessageNormalRebateNeedValidate As M Join AreaScope(" & sLoginUserID & ") As S On M.StoreID=S.AreaID Where M.IsLoaded=0 And M.NormalRebateApprovableRoleID=" & sLoginRoleID).Rows(0)(0)
                    Else
                        iMessages = DB.GetDataTable("Select Count(*) From MessageNormalRebateValidated As M Join AreaScope(" & sLoginUserID & ") As S On M.StoreID=S.AreaID Where IsLoaded=0").Rows(0)(0)
                    End If
                Catch
                    iMessages = 0
                End Try
                DB.Close()
            End If
            If iMessages > 0 Then
                If frmMessageNeedValidate.IsHandleCreated Then frmMessageNeedValidate.Dispose()
                If frmMessageValidated.IsHandleCreated Then frmMessageValidated.Dispose()
                Me.notifyMessage.Visible = True
                blBallClosed = False
                If blCanValidateNormalRebate Then
                    Me.notifyMessage.ShowBalloonTip(1000, "New Message From Shopping Card System", IIf(iMessages = 1, "There is a sales bill wait you to validate. ", "There are " & Format(iMessages, "#,0") & " sales bills wait you to validate. "), ToolTipIcon.Info)
                Else
                    Me.notifyMessage.ShowBalloonTip(1000, "New Message From Shopping Card System", IIf(iMessages = 1, "There is a sales bill had been validated. ", "There are " & Format(iMessages, "#,0") & " sales bills had been validated. "), ToolTipIcon.Info)
                End If
            End If

            Me.timerMessage.Interval = 300000 '五分钟
        Else
            Me.timerMessage.Interval = 60000 '一分钟
        End If
        Me.timerMessage.Enabled = True
    End Sub

    Private Sub notifyMessage_BalloonTipClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles notifyMessage.BalloonTipClicked
        blBallClosed = False
        Try
            If blCanValidateNormalRebate Then frmMessageNeedValidate.Show() Else frmMessageValidated.Show()
        Catch
        End Try
    End Sub

    Private Sub notifyMessage_BalloonTipClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles notifyMessage.BalloonTipClosed
        blBallClosed = True
    End Sub

    Private Sub notifyMessage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles notifyMessage.Click
        blBallClosed = False
        Try
            If blCanValidateNormalRebate Then frmMessageNeedValidate.Show() Else frmMessageValidated.Show()
        Catch
        End Try
    End Sub

    Private Sub notifyMessage_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles notifyMessage.MouseMove
        If blBallClosed Then
            If blCanValidateNormalRebate Then
                Me.notifyMessage.ShowBalloonTip(1000, "New Message From Shopping Card System", IIf(iMessages = 1, "There is a sales bill wait you to validate. ", "There are " & Format(iMessages, "#,0") & " sales bills wait you to validate. "), ToolTipIcon.Info)
            Else
                Me.notifyMessage.ShowBalloonTip(1000, "New Message From Shopping Card System", IIf(iMessages = 1, "There is a sales bill had been validated. ", "There are " & Format(iMessages, "#,0") & " sales bills had been validated. "), ToolTipIcon.Info)
            End If
        End If
    End Sub

    Private Function CalculateLocation(ByVal FormSize As Size) As Point
        Dim iLeft As Integer = (Me.ClientSize.Width - FormSize.Width) / 2 - 4, iTop As Integer = (Me.ClientSize.Height - FormSize.Height) / 2 - 20
        If iLeft < 0 Then iLeft = 0
        If iTop < 0 Then iTop = 0
        Return New Point(iLeft, iTop)
    End Function

    Private Sub CheckAuthorities()
        Me.menuNavigation.Enabled = False
        If sLoginUserID = "0" Then
            Me.menuSmallTool.Visible = True
            Me.spTool.Visible = True
        Else
            Me.menuSmallTool.Visible = False
            Me.spTool.Visible = False
        End If

        If "|4|6|9|".IndexOf("|" & sLoginRoleID & "|") > -1 Then '小区经理, 指导店长, 城市经理
            Me.menuMessage.Enabled = True '''''
            Me.menuMessage.Visible = True
            'Me.menuMessage.Checked = My.Settings.NotifyMessage
        Else
            Me.menuMessage.Enabled = False
            Me.menuMessage.Checked = False
            Me.menuMessage.Visible = False
        End If

        Dim bMenus As Byte = 0
        If dtAllowedRight.Select("RightName='RoleBrowse'").Length = 0 Then Me.menuPosition.Enabled = False : Me.menuPosition.Visible = False Else bMenus += 1
        If dtAllowedRight.Select("RightName='AreaBrowse'").Length = 0 Then Me.menuArea.Enabled = False : Me.menuArea.Visible = False Else bMenus += 1
        If dtAllowedRight.Select("RightName='UserBrowse'").Length = 0 Then Me.menuUserManagement.Enabled = False : Me.menuUserManagement.Visible = False Else bMenus += 1
        If bMenus = 0 Then Me.spEmployeeQuota.Visible = False
        If "|0|15|18|".IndexOf("|" & sLoginRoleID & "|") = -1 Then Me.menuEmployeeQuota.Enabled = False : Me.menuEmployeeQuota.Visible = False : Me.spEmployeeQuota.Visible = False Else bMenus += 1 '限系统管理员、总部金融服务部总监、总部购物卡经理可维护员工购买额度
        If dtAllowedRight.Select("RightName='BusinessTypeBrowse'").Length = 0 Then Me.menuBusinessType.Enabled = False : Me.menuBusinessType.Visible = False : Me.spBusinessType.Visible = False Else bMenus += 1
        If dtAllowedRight.Select("RightName='InvoiceItemBrowse'").Length = 0 Then Me.menuInvoiceItem.Enabled = False : Me.menuInvoiceItem.Visible = False : Me.spInvoiceItem.Visible = False Else bMenus += 1
        If dtAllowedRight.Select("RightName='InvoiceLayoutBrowse'").Length = 0 Then Me.menuInvoiceLayout.Enabled = False : Me.menuInvoiceLayout.Visible = False : Me.spInvoiceLayout.Visible = False Else bMenus += 1
        'modify code 054:start-------------------------------------------------------------------------
        'If dtAllowedRight.Select("RightName='CityConfigBrowse'").Length = 0 Then Me.menuCityConfig.Enabled = False : Me.menuCityConfig.Visible = False : Me.spRule.Visible = False Else bMenus += 1
        If dtAllowedRight.Select("RightName='CityConfigBrowse'").Length = 0 Then Me.menuCityConfig.Enabled = False : Me.menuCityConfig.Visible = False Else bMenus += 1
        If dtAllowedRight.Select("RightName='CrossSellingCityConfigBrowse'").Length = 0 Then Me.menuCrossSellingCityConfig.Enabled = False : Me.menuCrossSellingCityConfig.Visible = False Else bMenus += 1
        If menuCityConfig.Visible = False AndAlso menuCrossSellingCityConfig.Visible = False Then Me.spRule.Visible = False
        'modify code 054:end-------------------------------------------------------------------------
        If dtAllowedRight.Select("RightName='BounsCalculation'").Length = 0 Then Me.menuBonusCalculation.Enabled = False : Me.menuBonusCalculation.Visible = False : Me.spBonusCalcultion.Visible = False Else bMenus += 1
        If bMenus = 0 Then
            Me.menuParameter.Visible = False
        Else
            For Each menuS As ToolStripItem In Me.menuParameter.DropDownItems
                If menuS.GetType.Name = "ToolStripMenuItem" AndAlso menuS.Enabled Then
                    Exit For
                ElseIf menuS.GetType.Name = "ToolStripSeparator" Then
                    menuS.Visible = False
                End If
            Next
        End If

        bMenus = 0
        If dtAllowedRight.Select("RightName='SalesBillBrowse'").Length = 0 Then Me.menuSalesBillManagement.Enabled = False : Me.menuSalesBillManagement.Visible = False Else bMenus += 1
        'modify code 050:start-------------------------------------------------------------------------
        Dim sCityCanUse61 As Boolean = True
        'modify code 054:start-------------------------------------------------------------------------
        Dim sCityCanUse65 As Boolean = True
        'modify code 054:end-------------------------------------------------------------------------
        If sLoginAreaType = "S" Then  '按城市设置是否可使用61卡,如不可使用,则直接屏蔽实名制卡建单和特殊操作功能,只检查售卡员
            Dim dtCardParameter As DataTable, drCity As DataRow, DB As New DataBase
            DB.Open()
            If DB.IsConnected Then
                dtCardParameter = DB.GetDataTable("Select * From CityCardParameter Where CityID=" & dtLoginStructure.Rows.Find(sLoginAreaID)("ParentAreaID").ToString).Copy
                If Not dtCardParameter Is Nothing AndAlso dtCardParameter.Rows.Count > 0 Then
                    drCity = dtCardParameter.Rows(0)
                    If Not drCity("Use61Card") Then
                        Me.menuSignCardSelling.Enabled = False
                        Me.menuSignCardSelling.Visible = False
                        Me.menuImportSignCardSalesBill.Enabled = False
                        Me.menuImportSignCardSalesBill.Visible = False
                        Me.menuSignCardSpecialOperationHead.Enabled = False
                        Me.menuSignCardSpecialOperationHead.Visible = False
                        sCityCanUse61 = False
                    End If
                    'modify code 054:start-------------------------------------------------------------------------
                    If Not drCity("Use65Card") Then
                        Me.menuCrossSellingNonRealNameCard.Enabled = False
                        Me.menuCrossSellingNonRealNameCard.Visible = False
                        sCityCanUse65 = False
                    End If
                    'modify code 054:end-------------------------------------------------------------------------
                End If
                DB.Close()
            End If
        End If
        If sCityCanUse61 Then
            'modify code 046:start-------------------------------------------------------------------------
            '添加实名制
            If dtAllowedRight.Select("RightName='SalesBillSignCardCreate'").Length = 0 Then Me.menuSignCardSelling.Enabled = False : Me.menuSignCardSelling.Visible = False Else bMenus += 1
            If dtAllowedRight.Select("RightName='SalesBillSignCardCreate'").Length = 0 Then Me.menuImportSignCardSalesBill.Enabled = False : Me.menuImportSignCardSalesBill.Visible = False Else bMenus += 1
            If dtAllowedRight.Select("RightName='SalesBillSignCardCreate'").Length = 0 Then Me.menuDownloadSignCardSalesBillSellingTemp.Enabled = False : Me.menuDownloadSignCardSalesBillSellingTemp.Visible = False Else bMenus += 1
            If dtAllowedRight.Select("RightName='SalesBillSignCardCreate'").Length = 0 Then Me.menuCreateSignCardSalesBillFromFile.Enabled = False : Me.menuCreateSignCardSalesBillFromFile.Visible = False Else bMenus += 1
            'If dtAllowedRight.Select("RightName='SalesBillSignCardCreate'").Length = 0 Then Me.menuDownloadSignCardSalesBillRechargeTemp.Enabled = False : Me.menuDownloadSignCardSalesBillRechargeTemp.Visible = False Else bMenus += 1
            'If dtAllowedRight.Select("RightName='SalesBillSignCardCreate'").Length = 0 Then Me.menuRechargeSignCardSalesBillFromFile.Enabled = False : Me.menuRechargeSignCardSalesBillFromFile.Visible = False Else bMenus += 1
            Dim bSignCardMenus As Byte = 0
            If dtAllowedRight.Select("RightName='SignCardSpecialOperation'").Length = 0 Then Me.menuSignCardSpecialOperation.Enabled = False : Me.menuSignCardSpecialOperation.Visible = False Else bSignCardMenus += 1
            If dtAllowedRight.Select("RightName='SignCardReplace'").Length = 0 Then Me.menuSignCardReplace.Enabled = False : Me.menuSignCardReplace.Visible = False Else bSignCardMenus += 1
            'If dtAllowedRight.Select("RightName='SignCardSpecialOperationHead'").Length = 0 Then Me.menuSignCardSpecialOperationHead.Enabled = False : Me.menuSignCardSpecialOperationHead.Visible = False Else bMenus += 1
            If bSignCardMenus = 0 Then
                Me.menuSignCardSpecialOperationHead.Enabled = False
                Me.menuSignCardSpecialOperationHead.Visible = False
            End If
            'modify code 046:end-------------------------------------------------------------------------
        End If
        'modify code 050:end-------------------------------------------------------------------------
        'modify code 054:start-------------------------------------------------------------------------
        If sCityCanUse65 Then
            If dtAllowedRight.Select("RightName='CrossSellingNonRealnameCard'").Length = 0 Then Me.menuCrossSellingNonRealNameCard.Enabled = False : Me.menuCrossSellingNonRealNameCard.Visible = False Else bMenus += 1
        End If
        'modify code 054:end-------------------------------------------------------------------------
        If sLoginAreaID = "20" AndAlso (sLoginRoleID = "6" OrElse sLoginRoleID = "9") Then '北京的Pilot店长或城市主管
            bMenus += 1
        Else
            Me.menuCardFee.Enabled = False : Me.menuCardFee.Visible = False
        End If
        If sLoginRoleID = "14" Then bMenus += 1 Else Me.menuPredefineFaceValue.Enabled = False : Me.menuPredefineFaceValue.Visible = False
        If bMenus = 0 Then Me.spSelling.Visible = False
        If dtAllowedRight.Select("RightName='CustomerBrowse'").Length = 0 Then Me.menuCustomerManagement.Enabled = False : Me.menuCustomerManagement.Visible = False Else bMenus += 1
        If bMenus = 0 Then Me.spContract.Visible = False
        If dtAllowedRight.Select("RightName='ContractBrowse'").Length = 0 Then Me.menuContractManagement.Enabled = False : Me.menuContractManagement.Visible = False : Me.spContract.Visible = False Else bMenus += 1

        'modify code 067:start-------------------------------------------------------------------------
        If bMenus = 0 Then Me.spCrossContract.Visible = False
        If dtAllowedRight.Select("RightName='CrossContractBrowse'").Length = 0 Then Me.menuCrossContractManagement.Enabled = False : Me.menuCrossContractManagement.Visible = False : Me.spCrossContract.Visible = False Else bMenus += 1
        'modify code 067:end-------------------------------------------------------------------------

        If dtAllowedRight.Select("RightName='SalesBillFromFile'").Length = 0 Then Me.menuCreateSalesBillFromFile.Enabled = False : Me.menuCreateSalesBillFromFile.Visible = False : Me.spBatchRechargeFromFile.Visible = False Else bMenus += 1
        Dim bCardMenus As Byte = 0, bCULMenus As Byte = 0
        Me.menuSalesBillRecharge.Enabled = False : Me.menuSalesBillRecharge.Visible = False 'If dtAllowedRight.Select("RightName='SalesBillRecharge'").Length = 0 Then
        If dtAllowedRight.Select("RightName='SalesBillReturnedCreate'").Length = 0 Then
            Me.menuCreateReturnedSalesBill.Enabled = False : Me.menuCreateReturnedSalesBill.Visible = False
        Else
            bCardMenus += 1 : bMenus += 1
        End If
        If dtAllowedRight.Select("RightName='SalesBillMKCreate'").Length = 0 Then
            Me.menuMarketingPromotion.Enabled = False : Me.menuMarketingPromotion.Visible = False
        Else
            bCardMenus += 1 : bMenus += 1
        End If
        Me.menuPRCard.Enabled = False : Me.menuPRCard.Visible = False '关闭全国公关卡销售单
        If dtAllowedRight.Select("RightName='SalesBillEMPCreate'").Length = 0 Then
            Me.menuEmployeeSales.Enabled = False : Me.menuEmployeeSales.Visible = False
        Else
            bCardMenus += 1 : bMenus += 1
        End If
        If dtAllowedRight.Select("RightName='SalesBillCobrandCreate'").Length = 0 OrElse "|34|272|".IndexOf("|" & dtLoginStructure.Rows.Find(sLoginAreaID)("ParentAreaID").ToString & "|") = -1 Then '目前仅限大连及测试城市可以建立联名卡销售单
            Me.menuCobrandCard.Enabled = False : Me.menuCobrandCard.Visible = False
        Else
            bCardMenus += 1 : bMenus += 1
        End If
        'modify code 040:start-------------------------------------------------------------------------
        Dim sCityID As String = "", sStoreID As String = ""
        If sLoginRoleID = "14" Then '由于需要门店信息,目前限制售卡员
            '获取城市能否使用虚拟卡设置
            sCityID = Me.dtLoginStructure.Rows.Find(Me.sLoginAreaID)("ParentAreaID").ToString
            sStoreID = Me.sLoginAreaID
            GetAreaCode(sCityID, sStoreID)
            If dtAreaCode Is Nothing OrElse dtAreaCode.Rows.Count = 0 Then
                Me.menuInternetSelling.Enabled = False : Me.menuInternetSelling.Visible = False
                Me.menuInternetSalesInvoice.Enabled = False : Me.menuInternetSalesInvoice.Visible = False
            Else
                '线下提卡销售单
                If dtAreaCode.Rows(0)("CanSelling") = 0 Then
                    Me.menuInternetSelling.Enabled = False : Me.menuInternetSelling.Visible = False
                Else
                    If dtAllowedRight.Select("RightName='OfflineCardTaking'").Length = 0 Then
                        Me.menuInternetSelling.Enabled = False : Me.menuInternetSelling.Visible = False
                    Else
                        bCardMenus += 1 : bMenus += 1
                    End If
                End If
                '电子卡开票
                If dtAreaCode.Rows(0)("CanInvoice") = 0 Then
                    Me.menuInternetSalesInvoice.Enabled = False : Me.menuInternetSalesInvoice.Visible = False
                Else
                    If dtAllowedRight.Select("RightName='E-CardInvoice'").Length = 0 Then
                        Me.menuInternetSalesInvoice.Enabled = False : Me.menuInternetSalesInvoice.Visible = False
                    Else
                        bCardMenus += 1 : bMenus += 1
                    End If
                End If
            End If
        Else
            Me.menuInternetSelling.Enabled = False : Me.menuInternetSelling.Visible = False
            Me.menuInternetSalesInvoice.Enabled = False : Me.menuInternetSalesInvoice.Visible = False
        End If
        'modify code 040:end-------------------------------------------------------------------------
        If bCardMenus = 0 Then Me.spReturnGoods.Visible = False

        If dtAllowedRight.Select("RightName='ResetCardPassword'").Length = 0 Then Me.menuResetCardPassword.Enabled = False : Me.menuResetCardPassword.Visible = False Else bCardMenus += 1 : bCULMenus += 1 : bMenus += 1
        If dtAllowedRight.Select("RightName='FreezeCard'").Length = 0 Then Me.menuFreezeCard.Enabled = False : Me.menuFreezeCard.Visible = False Else bCardMenus += 1 : bCULMenus += 1 : bMenus += 1
        If dtAllowedRight.Select("RightName='UrgencyDeduct'").Length = 0 Then Me.menuUrgentDeduction.Enabled = False : Me.menuUrgentDeduction.Visible = False Else bCardMenus += 1 : bCULMenus += 1 : bMenus += 1
        If dtAllowedRight.Select("RightName='ChangeCard'").Length = 0 Then Me.menuReplaceCard.Enabled = False : Me.menuReplaceCard.Visible = False Else bCardMenus += 1 : bCULMenus += 1 : bMenus += 1
        If dtAllowedRight.Select("RightName='AffirmChangeCard'").Length = 0 Then Me.menuReplaceCardValidation.Enabled = False : Me.menuReplaceCardValidation.Visible = False Else bCardMenus += 1 : bCULMenus += 1 : bMenus += 1
        If dtAllowedRight.Select("RightName='UnchargeCard'").Length = 0 Then Me.menuUnchargeCard.Enabled = False : Me.menuUnchargeCard.Visible = False Else bCardMenus += 1 : bCULMenus += 1 : bMenus += 1
        If dtAllowedRight.Select("RightName='AffirmUnchargeCard'").Length = 0 Then Me.menuAffirmUnchargeCard.Enabled = False : Me.menuAffirmUnchargeCard.Visible = False Else bCardMenus += 1 : bCULMenus += 1 : bMenus += 1
        If dtAllowedRight.Select("RightName='UnchargeMKTCard'").Length = 0 Then Me.menuUnchargeMKTCard.Enabled = False : Me.menuUnchargeMKTCard.Visible = False Else bCardMenus += 1 : bCULMenus += 1 : bMenus += 1
        If dtAllowedRight.Select("RightName='AffirmUnchargeMKTCard'").Length = 0 Then Me.menuAffirmUnchargeMKTCard.Enabled = False : Me.menuAffirmUnchargeMKTCard.Visible = False Else bCardMenus += 1 : bCULMenus += 1 : bMenus += 1
        If dtAllowedRight.Select("RightName='GiftCardActivationCancel'").Length = 0 Then Me.menuGiftCardActivationCancel.Enabled = False : Me.menuGiftCardActivationCancel.Visible = False Else bCardMenus += 1 : bCULMenus += 1 : bMenus += 1
        If dtAllowedRight.Select("RightName='AffirmGiftCardActivationCancel'").Length = 0 Then Me.menuAffirmGiftCardActivationCancel.Enabled = False : Me.menuAffirmGiftCardActivationCancel.Visible = False Else bCardMenus += 1 : bCULMenus += 1 : bMenus += 1
        If dtAllowedRight.Select("RightName='GiftCardOfflineActivate'").Length = 0 Then Me.menuGiftCardOfflineActivate.Enabled = False : Me.menuGiftCardOfflineActivate.Visible = False Else bCardMenus += 1 : bCULMenus += 1 : bMenus += 1
        If dtAllowedRight.Select("RightName='AffirmGiftCardOfflineActivate'").Length = 0 Then Me.menuAffirmGiftCardOfflineActivate.Enabled = False : Me.menuAffirmGiftCardOfflineActivate.Visible = False Else bCardMenus += 1 : bCULMenus += 1 : bMenus += 1
        If dtAllowedRight.Select("RightName='RecycleCard'").Length = 0 Then Me.menuRecycleCard.Enabled = False : Me.menuRecycleCard.Visible = False Else bCardMenus += 1 : bCULMenus += 1 : bMenus += 1
        If dtAllowedRight.Select("RightName='AffirmRecycleCard'").Length = 0 Then Me.menuAffirmRecycleCard.Enabled = False : Me.menuAffirmRecycleCard.Visible = False Else bCardMenus += 1 : bCULMenus += 1 : bMenus += 1
        If bCULMenus = 0 Then Me.spCUL.Visible = False
        If dtAllowedRight.Select("RightName='CardExchangeQuery'").Length = 0 Then Me.menuCardStateQuery.Enabled = False : Me.menuCardStateQuery.Visible = False : Me.spCULQuery.Visible = False Else bCardMenus += 1 : bMenus += 1
        If bCardMenus = 0 Then
            Me.spCard.Visible = False
            Me.menuCULSpecialOperation.Enabled = False
            Me.menuCULSpecialOperation.Visible = False
        Else
            For Each menuS As ToolStripItem In Me.menuCULSpecialOperation.DropDownItems
                If menuS.GetType.Name = "ToolStripMenuItem" AndAlso menuS.Enabled Then
                    Exit For
                ElseIf menuS.GetType.Name = "ToolStripSeparator" Then
                    menuS.Visible = False
                End If
            Next
        End If
        If bMenus = 0 Then
            Me.menuCardManagement.Visible = False
        Else
            For Each menuS As ToolStripItem In Me.menuCardManagement.DropDownItems
                If menuS.GetType.Name = "ToolStripMenuItem" AndAlso menuS.Enabled Then
                    Exit For
                ElseIf menuS.GetType.Name = "ToolStripSeparator" Then
                    menuS.Visible = False
                End If
            Next
        End If

        If Not blUseInvoiceDevice Then
            Me.menuInvoiceOperation.Enabled = False
            Me.menuInvoiceOperation.Visible = False
        End If

        'modify code 072,081:start-------------------------------------------------------------------------
        bMenus = 0
        'If dtAllowedRight.Select("RightName='ElectronicCard'").Length = 0 Then Me.menuElectronicCard.Enabled = False : Me.menuElectronicCard.Visible = False Else bMenus += 1
        'If dtAllowedRight.Select("RightName='ElectronicCardRequirement'").Length = 0 Then Me.menuERequirement.Enabled = False : Me.menuERequirement.Visible = False Else bMenus += 1
        'If dtAllowedRight.Select("RightName='ElectronicCardQuery'").Length = 0 Then Me.menuEQuery.Enabled = False : Me.menuEQuery.Visible = False Else bMenus += 1
        'If dtAllowedRight.Select("RightName='ECancelActivationRequirement'").Length = 0 Then Me.menuEActivationRequirement.Enabled = False : Me.menuEActivationRequirement.Visible = False Else bMenus += 1
        'If dtAllowedRight.Select("RightName='ECancelActivationValidation'").Length = 0 Then Me.menuEActivationValidation.Enabled = False : Me.menuEActivationValidation.Visible = False Else bMenus += 1
        'If dtAllowedRight.Select("RightName='ElectronicCardFreeze'").Length = 0 Then Me.menuEFreezeCard.Enabled = False : Me.menuEFreezeCard.Visible = False Else bMenus += 1
        'If dtAllowedRight.Select("RightName='ElectronicCardSupplySms'").Length = 0 Then Me.menuESupplySms.Enabled = False : Me.menuESupplySms.Visible = False Else bMenus += 1
        'If dtAllowedRight.Select("RightName='ElectronicCodeDelay'").Length = 0 Then Me.menuECodeDelay.Enabled = False : Me.menuECodeDelay.Visible = False Else bMenus += 1
        'If dtAllowedRight.Select("RightName='ECancelChargeRequirement'").Length = 0 Then Me.menuECancelChargeRequirement.Enabled = False : Me.menuECancelChargeRequirement.Visible = False Else bMenus += 1
        'If dtAllowedRight.Select("RightName='ECancelChargeValidation'").Length = 0 Then Me.menuECancelChargeValidation.Enabled = False : Me.menuECancelChargeValidation.Visible = False Else bMenus += 1
        'If dtAllowedRight.Select("RightName='ECancelExtractingCodeRequirement'").Length = 0 Then Me.menuECancelExtractingCodeRequirement.Enabled = False : Me.menuECancelExtractingCodeRequirement.Visible = False Else bMenus += 1
        'If dtAllowedRight.Select("RightName='ECancelExtractingCodeValidation'").Length = 0 Then Me.menuECancelExtractingCodeValidation.Enabled = False : Me.menuECancelExtractingCodeValidation.Visible = False Else bMenus += 1
        'If dtAllowedRight.Select("RightName='ECodeDelayRequirement'").Length = 0 Then Me.menuECodeDelayRequirement.Enabled = False : Me.menuECodeDelayRequirement.Visible = False Else bMenus += 1
        If dtAllowedRight.Select("RightName='ElectronicCardRequirement'").Length = 0 Then Me.menuERequirement.Enabled = False : Me.menuERequirement.Visible = False Else bMenus += 1 : Me.menuERequirement.Enabled = True : Me.menuERequirement.Visible = True
        If dtAllowedRight.Select("RightName='ElectronicCardQuery'").Length = 0 Then Me.menuEQuery.Enabled = False : Me.menuEQuery.Visible = False Else bMenus += 1 : Me.menuEQuery.Enabled = True : Me.menuEQuery.Visible = True
        If dtAllowedRight.Select("RightName='ECancelActivationRequirement'").Length = 0 Then Me.menuEActivationRequirement.Enabled = False : Me.menuEActivationRequirement.Visible = False Else bMenus += 1 : Me.menuEActivationRequirement.Enabled = True : Me.menuEActivationRequirement.Visible = True
        If dtAllowedRight.Select("RightName='ECancelActivationValidation'").Length = 0 Then Me.menuEActivationValidation.Enabled = False : Me.menuEActivationValidation.Visible = False Else bMenus += 1 : Me.menuEActivationValidation.Enabled = True : Me.menuEActivationValidation.Visible = True
        If dtAllowedRight.Select("RightName='ElectronicCardFreeze'").Length = 0 Then Me.menuEFreezeCard.Enabled = False : Me.menuEFreezeCard.Visible = False Else bMenus += 1 : Me.menuEFreezeCard.Enabled = True : Me.menuEFreezeCard.Visible = True
        If dtAllowedRight.Select("RightName='ElectronicCardSupplySms'").Length = 0 Then Me.menuESupplySms.Enabled = False : Me.menuESupplySms.Visible = False Else bMenus += 1 : Me.menuESupplySms.Enabled = True : Me.menuESupplySms.Visible = True
        If dtAllowedRight.Select("RightName='ElectronicCodeDelay'").Length = 0 Then Me.menuECodeDelay.Enabled = False : Me.menuECodeDelay.Visible = False Else bMenus += 1 : Me.menuECodeDelay.Enabled = True : Me.menuECodeDelay.Visible = True
        If bMenus = 0 Then Me.menuElectronicCard.Enabled = False : Me.menuElectronicCard.Visible = False Else Me.menuElectronicCard.Enabled = True : Me.menuElectronicCard.Visible = True
        'modify code 072,081:end--------------------------------------------------------------------------

        'modify code 082:start-------------------------------------------------------------------------
        bMenus = 0
        'If dtAllowedRight.Select("RightName='ElectronicSpecialOperation'").Length = 0 Then Me.menuElcSpecialOperation.Enabled = False : Me.menuElcSpecialOperation.Visible = False Else bMenus += 1
        'If dtAllowedRight.Select("RightName='ECancelChargeRequirement'").Length = 0 Then Me.menuECancelChargeRequirement.Enabled = False : Me.menuECancelChargeRequirement.Visible = False Else bMenus += 1
        'If dtAllowedRight.Select("RightName='ECancelChargeValidation'").Length = 0 Then Me.menuECancelChargeValidation.Enabled = False : Me.menuECancelChargeValidation.Visible = False Else bMenus += 1
        'If dtAllowedRight.Select("RightName='ECancelExtractingCodeRequirement'").Length = 0 Then Me.menuECancelExtractingCodeRequirement.Enabled = False : Me.menuECancelExtractingCodeRequirement.Visible = False Else bMenus += 1
        'If dtAllowedRight.Select("RightName='ECancelExtractingCodeValidation'").Length = 0 Then Me.menuECancelExtractingCodeValidation.Enabled = False : Me.menuECancelExtractingCodeValidation.Visible = False Else bMenus += 1
        'If dtAllowedRight.Select("RightName='ECodeDelayRequirement'").Length = 0 Then Me.menuECodeDelayRequirement.Enabled = False : Me.menuECodeDelayRequirement.Visible = False Else bMenus += 1
        If dtAllowedRight.Select("RightName='ECancelChargeRequirement'").Length = 0 Then Me.menuECancelChargeRequirement.Enabled = False : Me.menuECancelChargeRequirement.Visible = False Else bMenus += 1 : Me.menuECancelChargeRequirement.Enabled = True : Me.menuECancelChargeRequirement.Visible = True
        If dtAllowedRight.Select("RightName='ECancelChargeValidation'").Length = 0 Then Me.menuECancelChargeValidation.Enabled = False : Me.menuECancelChargeValidation.Visible = False Else bMenus += 1 : Me.menuECancelChargeValidation.Enabled = True : Me.menuECancelChargeValidation.Visible = True
        If dtAllowedRight.Select("RightName='ECancelExtractingCodeRequirement'").Length = 0 Then Me.menuECancelExtractingCodeRequirement.Enabled = False : Me.menuECancelExtractingCodeRequirement.Visible = False Else bMenus += 1 : Me.menuECancelExtractingCodeRequirement.Enabled = True : Me.menuECancelExtractingCodeRequirement.Visible = True
        If dtAllowedRight.Select("RightName='ECancelExtractingCodeValidation'").Length = 0 Then Me.menuECancelExtractingCodeValidation.Enabled = False : Me.menuECancelExtractingCodeValidation.Visible = False Else bMenus += 1 : Me.menuECancelExtractingCodeValidation.Enabled = True : Me.menuECancelExtractingCodeValidation.Visible = True
        If dtAllowedRight.Select("RightName='ECodeDelayRequirement'").Length = 0 Then Me.menuECodeDelayRequirement.Enabled = False : Me.menuECodeDelayRequirement.Visible = False Else bMenus += 1 : Me.menuECodeDelayRequirement.Enabled = True : Me.menuECodeDelayRequirement.Visible = True
        If bMenus = 0 Then Me.menuElcSpecialOperation.Enabled = False : Me.menuElcSpecialOperation.Visible = False Else Me.menuElcSpecialOperation.Enabled = True : Me.menuElcSpecialOperation.Visible = True
        'modify code 082:end-------------------------------------------------------------------------

        bMenus = 0
        If dtAllowedRight.Select("RightName In ('CardActivate','MKCardActivate','ActivationView')").Length = 0 Then Me.menuCashActivation.Enabled = False : Me.menuCashActivation.Visible = False Else bMenus += 1
        If dtAllowedRight.Select("RightName In ('EMPCardActivate','ActivationView')").Length = 0 Then Me.menuEmployeeActivation.Enabled = False : Me.menuEmployeeActivation.Visible = False Else bMenus += 1
        If dtAllowedRight.Select("RightName='PaymentConfirm'").Length = 0 Then Me.menuChequeActivation.Enabled = False : Me.menuChequeActivation.Visible = False Else bMenus += 1
        If bMenus = 0 Then Me.menuActivation.Visible = False

        bMenus = 0
        If dtAllowedRight.Select("RightName='ReportBrowse'").Length = 0 Then Me.menuSalesReport.Enabled = False : Me.menuSalesReport.Visible = False Else bMenus += 1
        If bMenus = 0 Then Me.spJVReports.Visible = False
        If My.Settings.IsInTraining OrElse dtAllowedRight.Select("RightName='JVReportExorpt'").Length = 0 Then Me.spJVReports.Visible = False : Me.menuJVReport.Enabled = False : Me.menuJVReport.Visible = False Else bMenus += 1
        Me.spBonusReport.Visible = False : Me.menuBonusReporting.Enabled = False : Me.menuBonusReporting.Visible = False
        If My.Settings.IsInTraining OrElse dtAllowedRight.Select("RightName='CustomReportExport'").Length = 0 Then Me.spCustomReport.Visible = False : Me.menuCustomExport.Enabled = False : Me.menuCustomExport.Visible = False Else bMenus += 1 '小区BC、店长、售卡员、中鱼、大鱼不能使用自定义导出报表
        If My.Settings.IsInTraining OrElse dtAllowedRight.Select("RightName='CULReportDownload'").Length = 0 Then Me.spCULReport.Visible = False : Me.menuCULReport.Enabled = False : Me.menuCULReport.Visible = False Else bMenus += 1 '培训模式下或售卡员、中鱼、大鱼不能下载CUL报表
        If bMenus = 0 Then Me.menuReport.Visible = False
    End Sub

    Public Function InvoiceDeviceCheck(Optional ByVal blNeedPrompt As Boolean = True) As String
        blInvoiceDeviceOK = False
        If My.Settings.InvoiceDevicePort = "" Then
            Me.menuInvoiceDeviceTesting.PerformClick()
        Else
            If blNeedPrompt Then
                Me.Cursor = Cursors.Default
                Me.statusText.Text = "正在初始化开票器……"
                Me.statusMain.Refresh()
            End If


            Dim objInvoice As Object = Nothing
            Try
                objInvoice = CreateObject("PZHPrj.ComDLL")
            Catch ex As Exception
                If blNeedPrompt Then
                    MessageBox.Show("初始化开票器失败！动态链接库""PZHPrj.dll""未注册！    " & Chr(13) & Chr(13) & "请联系当地IT进行注册（命令：regsvr32 \%PATHNAME%\PZHPrj.dll）    ", "初始化开票器失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.statusText.Text = "初始化开票器失败！"
                    Me.Cursor = Cursors.Default
                End If
                objInvoice = Nothing
                Return "初始化开票器失败！"
            End Try

            Dim sResult As String = objInvoice.InitReader(CInt(My.Settings.InvoiceDevicePort.Substring(3)))
            If sResult <> "0" Then
                If blNeedPrompt Then
                    MessageBox.Show("初始化开票器失败！错误代码：" & sResult & "。    " & Chr(13) & Chr(13) & "请联系当地IT检查如下事项：    " & Chr(13) & Chr(13) & "1. 开票器是否已正确连接；    " & Chr(13) & "2. 驱动程序是否已正确安装；    " & Chr(13) & "3. 连接端口是否已正确选择。    ", "初始化开票器失败！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.statusText.Text = "初始化开票器失败！"
                    Me.Cursor = Cursors.Default
                End If
                objInvoice = Nothing
                Return "初始化开票器失败！"
            End If

            'sResult = objInvoice.SendData()
            'If sResult = "0" Then
            blInvoiceDeviceOK = True
            If blNeedPrompt Then
                Me.statusText.Text = "就绪。"
                Me.Cursor = Cursors.Default
            End If
            objInvoice = Nothing
            'Else
            '    If blNeedPrompt Then
            '        MessageBox.Show("开票器未能连接外部网络！   " & Chr(13) & Chr(13) & "请联系当地IT检查外网网络设置。    ", "开票器未能连接外部网络！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '        Me.statusText.Text = "开票器未能连接外部网络！"
            '        Me.Cursor = Cursors.Default
            '    End If
            '    objInvoice = Nothing
            '    Return "开票器未能连接外部网络！"
            'End If
        End If

        Return "OK"
    End Function

    'modify code 023:start-------------------------------------------------------------------------
    Private Sub menuCardStateQuery_Section_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuCardStateQuery_Section.Click
        If dtAllowedRight.Select("RightName='CardExchangeQuery'").Length = 0 Then
            MessageBox.Show("对不起，您没有""购物卡交易明细查询""的权限！    ", "您不能查询购物卡交易明细！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.menuCardStateQuery_Section.Enabled = False
        Else
            frmDealingQuery_Section.ShowDialog()
            frmDealingQuery_Section.Dispose()
        End If
    End Sub
    'modify code 023:end-------------------------------------------------------------------------

    'modify code 040:start-------------------------------------------------------------------------
    Private Sub menuInternetSalesInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuInternetSalesInvoice.Click
        If sLoginRoleID = "14" Then
            '获取线下提卡接口
            If sInternetWebService = "" Then
                MessageBox.Show("获取开票接口失败！", "打开网上售卖开票失败", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Me.Cursor = Cursors.WaitCursor
            Me.statusText.Text = "正在打开""网上售卖开票""窗口……"
            Me.statusMain.Refresh()

            frmInternetSalesInvoice.Show()
            If frmInternetSalesInvoice.IsHandleCreated Then
                frmInternetSalesInvoice.MdiParent = Me
                frmInternetSalesInvoice.WindowState = FormWindowState.Normal
                frmInternetSalesInvoice.Location = Me.CalculateLocation(frmInvoiceLayout.Size)
                frmInternetSalesInvoice.Activate()

                If Me.statusText.Text.IndexOf("……") > -1 Then Me.statusText.Text = "就绪。"
            End If
            Me.Cursor = Cursors.Default
        Else
            MessageBox.Show("对不起，您不是售卡员，没有""网上售卖开票""的权限！    ", "您不能网上售卖开票！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.menuInternetSalesInvoice.Enabled = False
        End If
    End Sub

    Private Sub menuInternetSelling_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuInternetSelling.Click
        'modify code 044:start-------------------------------------------------------------------------
        ''获取线下提卡接口
        'If sInternetWebService = "" Then
        '    MessageBox.Show("获取线下提卡接口失败！", "打开线下提卡销售单失败", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Return
        'End If
        ''需要唯一门店信息
        'If Me.sLoginAreaType <> "S" Then
        '    MessageBox.Show("不允许超过门店级别的家乐福员工执行此操作。", "请重新登陆！", MessageBoxButtons.OK)
        '    Return
        'End If
        If sLoginRoleID = "14" Then
            '获取门店/城市ID
            Dim sCityID As String = "", sStoreID As String = ""
            Try
                sCityID = Me.dtLoginStructure.Rows.Find(Me.sLoginAreaID)("ParentAreaID").ToString
                sStoreID = Me.sLoginAreaID

                If sCityID = "" Or sStoreID = "" Then
                    MessageBox.Show("获取员工门店和城市信息失败。", "请重新登陆！", MessageBoxButtons.OK)
                    Return
                End If
            Catch
                Return
            End Try
            '打开选择购卡渠道界面
            Me.Cursor = Cursors.WaitCursor
            Me.statusText.Text = "正在打开""选择购买渠道""窗口……"
            Me.statusMain.Refresh()

            With frmSelectBuyChannel
                .sCityID = sCityID
                .sStoreID = sStoreID
                .Show()
                If .IsHandleCreated Then
                    .MdiParent = Me
                    .WindowState = FormWindowState.Normal
                    .Location = Me.CalculateLocation(.Size)
                    .Activate()

                    If Me.statusText.Text.IndexOf("……") > -1 Then Me.statusText.Text = "就绪。"
                End If
            End With
            Me.Cursor = Cursors.Default
        Else
            MessageBox.Show("对不起，您不是售卡员，没有""创建线下提卡销售单""的权限！    ", "您不能创建线下提卡销售单！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.menuInternetSalesInvoice.Enabled = False
        End If
        ''打开提取码验证界面
        'With frmInternetSales_ForCul
        '    .sCityID = sCityID
        '    .sStoreID = sStoreID
        '    If .ShowDialog = Windows.Forms.DialogResult.OK Then
        '        If .sSalesBillID = "" Then  '提取码还未使用
        '            If frmSelling.IsHandleCreated Then
        '                frmSelling.Activate()
        '                frmSelling.WindowState = FormWindowState.Maximized
        '                If frmSelling.blIsChanged Then
        '                    Dim bAnswer As DialogResult = MessageBox.Show("是否在新建销售单之前，先保存当前销售单？    ", "当前销售单未保存！", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
        '                    If bAnswer = Windows.Forms.DialogResult.Cancel OrElse (bAnswer = Windows.Forms.DialogResult.Yes AndAlso Not frmSelling.SaveChanges()) Then
        '                        Me.Activate()
        '                        Me.statusText.Text = "因为存在未保存销售单，所以不能新建销售单。"
        '                        Return
        '                    End If
        '                End If

        '                frmSelling.cbbSalesBillType.Items(0) = "线下提卡销售单"
        '                frmSelling.sCustomerID = ""
        '                frmSelling.bNewSalesBillType = 6
        '                frmSelling.blUsedOldCard = False
        '                frmSelling.ecir = .ecir
        '                frmSelling.sIssuerId = .sIssuerId
        '                frmSelling.ReCreateSalesBill()
        '            Else
        '                Me.Cursor = Cursors.WaitCursor
        '                Me.statusText.Text = "正在打开销售单窗口……"
        '                Me.statusMain.Refresh()

        '                frmSelling.cbbSalesBillType.Items(0) = "线下提卡销售单"
        '                frmSelling.bNewSalesBillType = 6
        '                frmSelling.blUsedOldCard = False
        '                frmSelling.ecir = .ecir
        '                frmSelling.sIssuerId = .sIssuerId
        '                frmSelling.Show()
        '                If frmSelling.IsHandleCreated Then
        '                    frmSelling.MdiParent = Me
        '                    frmSelling.WindowState = FormWindowState.Maximized
        '                    frmSelling.Activate()
        '                End If

        '                If Me.statusText.Text.IndexOf("……") > -1 Then Me.statusText.Text = "就绪。"
        '                Me.Cursor = Cursors.Default
        '            End If

        '            If frmSelling.IsHandleCreated Then
        '                If frmSelling.dgvNormalCard.CurrentRow IsNot Nothing Then frmSelling.dgvNormalCard.CurrentRow.Selected = False
        '                If frmSelling.dgvRebateCard.CurrentRow IsNot Nothing Then frmSelling.dgvRebateCard.CurrentRow.Selected = False
        '                If frmSelling.dgvPayment.CurrentRow IsNot Nothing Then frmSelling.dgvPayment.CurrentRow.Selected = False
        '            End If
        '        Else
        '            If frmSelling.IsHandleCreated Then
        '                frmSelling.Activate()
        '                frmSelling.WindowState = FormWindowState.Maximized
        '                If frmSelling.sSalesBillID <> .sSalesBillID Then
        '                    If frmSelling.blIsChanged Then
        '                        Dim bAnswer As DialogResult = MessageBox.Show("是否在打开销售单之前，先保存当前销售单？    ", "当前销售单未保存！", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
        '                        If bAnswer = Windows.Forms.DialogResult.Cancel OrElse (bAnswer = Windows.Forms.DialogResult.Yes AndAlso Not frmSelling.SaveChanges()) Then
        '                            Me.Activate()
        '                            Me.statusText.Text = "因为存在未保存销售单，所以不能打开销售单。"
        '                            Return
        '                        End If
        '                    End If
        '                    frmSelling.sSalesBillID = .sSalesBillID
        '                    frmSelling.LoadSalesBill()
        '                End If
        '            Else
        '                Me.Cursor = Cursors.WaitCursor
        '                Me.statusText.Text = "正在打开销售单……"
        '                Me.statusMain.Refresh()

        '                frmSelling.Text = "查看销售单"
        '                frmSelling.sSalesBillID = .sSalesBillID
        '                frmSelling.Show()
        '                If frmSelling.IsHandleCreated Then
        '                    frmSelling.MdiParent = Me
        '                    frmSelling.WindowState = FormWindowState.Maximized
        '                    frmSelling.Activate()
        '                    frmSelling.btnModifyPaymentInfo.Visible = False
        '                End If

        '                If Me.statusText.Text.IndexOf("……") > -1 Then Me.statusText.Text = "就绪。"
        '                Me.Cursor = Cursors.Default
        '            End If

        '            If frmSelling.IsHandleCreated Then
        '                If frmSelling.dgvNormalCard.CurrentRow IsNot Nothing Then frmSelling.dgvNormalCard.CurrentRow.Selected = False
        '                If frmSelling.dgvRebateCard.CurrentRow IsNot Nothing Then frmSelling.dgvRebateCard.CurrentRow.Selected = False
        '                If frmSelling.dgvPayment.CurrentRow IsNot Nothing Then frmSelling.dgvPayment.CurrentRow.Selected = False
        '            End If
        '        End If

        '    End If
        '    .Dispose()
        'End With
        'modify code 044:end-------------------------------------------------------------------------

    End Sub

    Private Sub GetAreaCode(ByVal parmCityID As String, ByVal parmStoreID As String)
        Dim DB As New DataBase
        DB.Open()
        If Not DB.IsConnected Then
            Return
        End If

        Try
            Dim dtStoreAreaCode As DataTable = DB.GetDataTable("select M.IssuerID from CULMerchantList M join AreaList A on A.CULStoreCode = M.MerchantNo where A.AreaID = " & parmStoreID)
            If dtStoreAreaCode Is Nothing OrElse dtStoreAreaCode.Rows.Count = 0 Then
                DB.Close()
                Return
            End If
            dtAreaCode = DB.GetDataTable("Select * From City_AreaCode Where CityID=" & parmCityID & " and AreaCode = '" & dtStoreAreaCode.Rows(0)("IssuerID").ToString & "'").Copy
            DB.Close()
        Catch ex As Exception
            DB.Close()
        End Try
    End Sub
    'modify code 040:end-------------------------------------------------------------------------

    'modify code 047:start-------------------------------------------------------------------------
    Private Sub menuSignCardSpecialOperation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuSignCardSpecialOperation.Click
        If dtAllowedRight.Select("RightName='SignCardSpecialOperation'").Length = 0 Then
            MessageBox.Show("对不起，您没有""实名制卡特殊操作""的权限！    ", "您不能操作实名制卡！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.menuCardStateQuery.Enabled = False
        Else
            frmSignCardSpecialOperation.ShowDialog()
            frmSignCardSpecialOperation.Dispose()
        End If
    End Sub

    Private Sub menuSignCardReplace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuSignCardReplace.Click
        If dtAllowedRight.Select("RightName='SignCardReplace'").Length = 0 Then
            MessageBox.Show("对不起，您没有""转实名制卡""的权限！    ", "您不能操作实名制卡！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.menuCardStateQuery.Enabled = False
        Else
            frmSignCardReplace.ShowDialog()
            frmSignCardReplace.Dispose()
        End If
    End Sub
    'modify code 047:end-------------------------------------------------------------------------

    'modify code 054:start-------------------------------------------------------------------------
    Private Sub menuCrossSellingNonRealNameCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuCrossSellingNonRealNameCard.Click
        If frmSelling.IsHandleCreated Then
            frmSelling.Activate()
            frmSelling.WindowState = FormWindowState.Maximized
            If frmSelling.blIsChanged Then
                Dim bAnswer As DialogResult = MessageBox.Show("是否在新建销售单之前，先保存当前销售单？    ", "当前销售单未保存！", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                If bAnswer = Windows.Forms.DialogResult.Cancel OrElse (bAnswer = Windows.Forms.DialogResult.Yes AndAlso Not frmSelling.SaveChanges()) Then
                    Me.Activate()
                    Me.statusText.Text = "因为存在未保存销售单，所以不能新建销售单。"
                    Return
                End If
            End If

            frmSelling.cbbSalesBillType.Items(0) = "通卖非实名卡销售单"
            frmSelling.sCustomerID = ""
            frmSelling.bNewSalesBillType = 8
            frmSelling.blUsedOldCard = False
            frmSelling.ReCreateSalesBill()
        Else
            Me.Cursor = Cursors.WaitCursor
            Me.statusText.Text = "正在打开销售单窗口……"
            Me.statusMain.Refresh()

            frmSelling.cbbSalesBillType.Items(0) = "通卖非实名卡销售单"
            frmSelling.bNewSalesBillType = 8
            frmSelling.blUsedOldCard = False
            frmSelling.Show()
            If frmSelling.IsHandleCreated Then
                frmSelling.MdiParent = Me
                frmSelling.WindowState = FormWindowState.Maximized
                frmSelling.Activate()
            End If

            If Me.statusText.Text.IndexOf("……") > -1 Then Me.statusText.Text = "就绪。"
            Me.Cursor = Cursors.Default
        End If

        If frmSelling.IsHandleCreated Then
            If frmSelling.dgvNormalCard.CurrentRow IsNot Nothing Then frmSelling.dgvNormalCard.CurrentRow.Selected = False
            If frmSelling.dgvRebateCard.CurrentRow IsNot Nothing Then frmSelling.dgvRebateCard.CurrentRow.Selected = False
            If frmSelling.dgvPayment.CurrentRow IsNot Nothing Then frmSelling.dgvPayment.CurrentRow.Selected = False
        End If
    End Sub

    Private Sub menuCrossSellingCityConfig_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuCrossSellingCityConfig.Click
        Me.Cursor = Cursors.WaitCursor
        Me.statusText.Text = "正在打开""城市设置""窗口……"
        Me.statusMain.Refresh()

        frmCrossSellingCityConfig.Show()
        If frmCrossSellingCityConfig.IsHandleCreated Then
            frmCrossSellingCityConfig.MdiParent = Me
            frmCrossSellingCityConfig.WindowState = FormWindowState.Normal
            frmCrossSellingCityConfig.Location = Me.CalculateLocation(frmCrossSellingCityConfig.Size)
            frmCrossSellingCityConfig.Activate()
            If frmCrossSellingCityConfig.dgvPending.ReadOnly = False Then
                frmCrossSellingCityConfig.cbbCity.Select()
                frmCrossSellingCityConfig.dgvPending.Select()
                frmCrossSellingCityConfig.dgvPending.CurrentRow.Selected = False
            End If

            If Me.statusText.Text.IndexOf("……") > -1 Then Me.statusText.Text = "就绪。"
        End If

        Me.Cursor = Cursors.Default
    End Sub
    'modify code 054:end-------------------------------------------------------------------------

    'modify code 072:start-------------------------------------------------------------------------
    Private Sub menuElectronicCard_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuElectronicCard.Click
        frmElectronicOperation.ShowDialog()
        frmElectronicOperation.Dispose()
    End Sub

    Private Sub menuERequirement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuERequirement.Click
        If dtAllowedRight.Select("RightName='ElectronicCardRequirement'").Length = 0 Then
            MessageBox.Show("对不起，您没有""电子卡团购申请""的权限！    ", "您不能操作电子卡！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.menuCardStateQuery.Enabled = False
        Else
            frmElectronic.ShowDialog()
            frmElectronic.Dispose()
        End If
    End Sub

    Private Sub menuEQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuEQuery.Click
        If dtAllowedRight.Select("RightName='ElectronicCardQuery'").Length = 0 Then
            MessageBox.Show("对不起，您没有""电子卡团购查询""的权限！    ", "您不能操作电子卡！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.menuCardStateQuery.Enabled = False
        Else
            frmElectronicManagement.ShowDialog()
            frmElectronicManagement.Dispose()
        End If
    End Sub

    Private Sub menuEActivationRequirement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuEActivationRequirement.Click
        If dtAllowedRight.Select("RightName='ECancelActivationRequirement'").Length = 0 Then
            MessageBox.Show("对不起，您没有""电子卡团购撤销激活申请""的权限！    ", "您不能操作电子卡！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.menuCardStateQuery.Enabled = False
        Else
            frmECancelActivationRequirement.ShowDialog()
            frmECancelActivationRequirement.Dispose()
        End If
    End Sub

    Private Sub menuEActivationValidation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuEActivationValidation.Click
        If dtAllowedRight.Select("RightName='ECancelActivationValidation'").Length = 0 Then
            MessageBox.Show("对不起，您没有""电子卡团购撤销激活确认""的权限！    ", "您不能操作电子卡！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.menuCardStateQuery.Enabled = False
        Else
            frmECancelActivationValidation.ShowDialog()
            frmECancelActivationValidation.Dispose()
        End If
    End Sub

    Private Sub menuEFreezeCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuEFreezeCard.Click
        If dtAllowedRight.Select("RightName='ElectronicCardFreeze'").Length = 0 Then
            MessageBox.Show("对不起，您没有""电子卡团购冻结/解冻""的权限！    ", "您不能操作电子卡！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.menuCardStateQuery.Enabled = False
        Else
            frmSelectEChannel.ShowDialog()
            frmSelectEChannel.Dispose()
            'frmElectronicCardFreeze.ShowDialog()
            'frmElectronicCardFreeze.Dispose()
        End If
    End Sub

    Private Sub menuESupplySms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuESupplySms.Click
        If dtAllowedRight.Select("RightName='ElectronicCardSupplySms'").Length = 0 Then
            MessageBox.Show("对不起，您没有""电子卡团购补发短信""的权限！    ", "您不能操作电子卡！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.menuCardStateQuery.Enabled = False
        Else
            frmSupply.ShowDialog()
            frmSupply.Dispose()
        End If
    End Sub

    Private Sub menuECodeDelay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuECodeDelay.Click
        If dtAllowedRight.Select("RightName='ElectronicCodeDelay'").Length = 0 Then
            MessageBox.Show("对不起，您没有""电子卡团购电子码延期""的权限！    ", "您不能操作电子卡！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.menuCardStateQuery.Enabled = False
        Else
            frmElectronicCodeDelay.ShowDialog()
            frmElectronicCodeDelay.Dispose()
        End If
    End Sub

    Private Sub menuECancelChargeRequirement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuECancelChargeRequirement.Click
        If dtAllowedRight.Select("RightName='ECancelChargeRequirement'").Length = 0 Then
            MessageBox.Show("对不起，您没有""电子卡充值撤销申请""的权限！    ", "您不能操作电子卡！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.menuCardStateQuery.Enabled = False
        Else
            frmECancelChargeRequirement.ShowDialog()
            frmECancelChargeRequirement.Dispose()
        End If
    End Sub

    Private Sub menuECancelChargeValidation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuECancelChargeValidation.Click
        If dtAllowedRight.Select("RightName='ECancelChargeValidation'").Length = 0 Then
            MessageBox.Show("对不起，您没有""电子卡充值撤销确认""的权限！    ", "您不能操作电子卡！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.menuCardStateQuery.Enabled = False
        Else
            frmECancelChargeValidationList.ShowDialog()
            frmECancelChargeValidationList.Dispose()
        End If
    End Sub
    'modify code 072:end-------------------------------------------------------------------------

    'modify code 076:start-------------------------------------------------------------------------
    Private Sub menuECancelExtractingCodeRequirement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuECancelExtractingCodeRequirement.Click
        If dtAllowedRight.Select("RightName='ECancelExtractingCodeRequirement'").Length = 0 Then
            MessageBox.Show("对不起，您没有""提取码作废申请""的权限！    ", "您不能操作电子卡！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.menuECancelExtractingCodeRequirement.Enabled = False
        Else
            frmECancelExtractingCodeRequirement.ShowDialog()
            frmECancelExtractingCodeRequirement.Dispose()
        End If
    End Sub

    Private Sub menuECancelExtractingCodeValidation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuECancelExtractingCodeValidation.Click
        If dtAllowedRight.Select("RightName='ECancelExtractingCodeValidation'").Length = 0 Then
            MessageBox.Show("对不起，您没有""提取码作废确认""的权限！    ", "您不能操作电子卡！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.menuECancelExtractingCodeValidation.Enabled = False
        Else
            frmECancelExtractingCodeValidation.ShowDialog()
            frmECancelExtractingCodeValidation.Dispose()
        End If
    End Sub

    Private Sub menuECodeDelayRequirement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuECodeDelayRequirement.Click
        If dtAllowedRight.Select("RightName='ECodeDelayRequirement'").Length = 0 Then
            MessageBox.Show("对不起，您没有""电子码延期""的权限！    ", "您不能操作电子卡！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.menuECodeDelayRequirement.Enabled = False
        Else
            frmECodeDelayRequirement.ShowDialog()
            frmECodeDelayRequirement.Dispose()
        End If
    End Sub
    'modify code 076:end-------------------------------------------------------------------------

    'modify code 082:start-------------------------------------------------------------------------
    Private Sub menuElcSpecialOperation_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuElcSpecialOperation.Click
        frmElectronicSpecialOperation.ShowDialog()
        frmElectronicSpecialOperation.Dispose()
    End Sub
    'modify code 082:end-------------------------------------------------------------------------
End Class