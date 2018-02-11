'modify code 027:start-------------------------------------------------------------------------
Imports System.Management
'modify code 027:end-------------------------------------------------------------------------

Namespace My

    'modify code 027:
    'date;2014/6/13
    'auther:Hyron bjy 
    'remark:增加测试版本号，自动升级测试版本，必须最新的正式版本才能升级测试版本

    'modify code 024:
    'date;2014/5/27
    'auther:Hyron bjy 
    'remark:更改数据库连接获取方式为webservice

    ' 以下事件可用于 MyApplication:
    ' 
    ' Startup: 应用程序启动时在创建启动窗体之前引发。
    ' Shutdown: 在关闭所有应用程序窗体后引发。如果应用程序异常终止，则不会引发此事件。
    ' UnhandledException: 在应用程序遇到未处理的异常时引发。
    ' StartupNextInstance: 在启动单实例应用程序且应用程序已处于活动状态时引发。
    ' NetworkAvailabilityChanged: 在连接或断开网络连接时引发。
    Partial Friend Class MyApplication

        'modify code 024:start-------------------------------------------------------------------------
        Private sUpdateSystemConnection As String = ""
        Private wbConfig As WebServiceConfig.Service = Nothing
        'modify code 024:end-------------------------------------------------------------------------

        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            If System.Diagnostics.Debugger.IsAttached Then Return
            If My.Computer.Network.IsAvailable Then

                'modify code 024:start-------------------------------------------------------------------------
                Dim dtUpdateSystemConnection As DataTable
                wbConfig = New WebServiceConfig.Service
                dtUpdateSystemConnection = wbConfig.GetUpdateSystemConnection
                If dtUpdateSystemConnection Is Nothing Then
                    MessageBox.Show("获取升级目录失败！", "打开系统失败", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
                sUpdateSystemConnection = dtUpdateSystemConnection.Rows(0)("sUpdateSystemConnection")
                If sUpdateSystemConnection = "" Then
                    MessageBox.Show("获取升级目录失败！", "打开系统失败", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
                'modify code 024:end-------------------------------------------------------------------------

                Dim sStartupPath As String = Application.Info.DirectoryPath, sCommandLine As String = Microsoft.VisualBasic.Interaction.Command()
                If sCommandLine.IndexOf("/SkipCheckUpdate") = -1 Then
                    Dim sOldVersion As String = frmMain.SystemVersion, sNewVersion As String = ""
                    'modify code 027:start-------------------------------------------------------------------------
                    Dim sOldTestVersion As String = frmMain.SystemTestVersion, sNewTestVersion As String = "", sIPlist As String = "", arrIPlist() As String
                    'modify code 027:end-------------------------------------------------------------------------
                    Try
                        Dim myWebClient As New Net.WebClient()
                        myWebClient.Proxy = Nothing
                        myWebClient.CachePolicy = New Net.Cache.RequestCachePolicy(Net.Cache.RequestCacheLevel.NoCacheNoStore)
                        If Not IO.File.Exists(sStartupPath & "\SystemUpdate.exe") OrElse Format(My.Computer.FileSystem.GetFileInfo(sStartupPath & "\SystemUpdate.exe").LastWriteTime, "yyyy\/MM\/dd") < "2012/05/22" Then
                            'modify code 024:start-------------------------------------------------------------------------
                            'myWebClient.DownloadFile(SecurityText.DecryptData("qfESIwi33U83ObMfQirMJlrPiRIFxKfOfLLpjqnSw84yAzwTfLJfi+JjK1eoOijrV+oF3uIB4IIj7EKwPPYARdc2P0xgFlumnW1jF0Hc/mABamT6auuq+/w1+nYXGlpeLv57+60+WLTf15T5zC+h/g=="), sStartupPath & "\SystemUpdate.exe")
                            'myWebClient.DownloadFile("http://10.132.203.180/SCPublish/New/SystemUpdate.exe", sStartupPath & "\SystemUpdate.exe")
                            myWebClient.DownloadFile(sUpdateSystemConnection & "SystemUpdate.exe", sStartupPath & "\SystemUpdate.exe")
                            'modify code 024:end-------------------------------------------------------------------------
                        End If
                        If Not IO.File.Exists(sStartupPath & "\ICSharpCode.SharpZipLib.dll") Then
                            'modify code 024:start-------------------------------------------------------------------------
                            'myWebClient.DownloadFile(SecurityText.DecryptData("qfESIwi33U83ObMfQirMJlrPiRIFxKfOfLLpjqnSw84yAzwTfLJfi+JjK1eoOijrV+oF3uIB4IIj7EKwPPYARQ+zCxefLdG6Y86r69li8cYMjnPyUv+u9TNz69NA9tGGZPGtXWP+MiTBmuFkoC0d/CYi/Kt+oRqjYCk0EXra6Wk="), sStartupPath & "\ICSharpCode.SharpZipLib.dll")
                            'myWebClient.DownloadFile("http://10.132.203.180/SCPublish/New/ICSharpCode.SharpZipLib.dll", sStartupPath & "\ICSharpCode.SharpZipLib.dll")
                            myWebClient.DownloadFile(sUpdateSystemConnection & "ICSharpCode.SharpZipLib.dll", sStartupPath & "\ICSharpCode.SharpZipLib.dll")
                            'modify code 024:end-------------------------------------------------------------------------
                        End If
                        'modify code 024:start-------------------------------------------------------------------------
                        'sNewVersion = myWebClient.DownloadString(SecurityText.DecryptData("qfESIwi33U83ObMfQirMJlrPiRIFxKfOfLLpjqnSw84yAzwTfLJfi+JjK1eoOijrV+oF3uIB4IIj7EKwPPYARfFztAhKNiQtTa5oUD95XNW+lhgkUZh/R866dTbMoznl"))
                        'sNewVersion = myWebClient.DownloadString("http://10.132.203.180/SCPublish/New/Version.txt")
                        'sNewVersion = myWebClient.DownloadString("D:\Hyron Folder\BaiJieYu\workspace\00-SCS All\New\Version.txt")
                        sNewVersion = myWebClient.DownloadString(sUpdateSystemConnection & "Version.txt")
                        sNewVersion = sNewVersion.Substring(sNewVersion.IndexOf(":") + 1).Trim
                        'modify code 027:start-------------------------------------------------------------------------
                        'sNewTestVersion = myWebClient.DownloadString("D:\Hyron Folder\BaiJieYu\workspace\00-SCS All\New\TestVersion.txt")
                        sNewTestVersion = myWebClient.DownloadString(sUpdateSystemConnection & "TestVersion.txt")
                        sNewTestVersion = sNewTestVersion.Substring(sNewTestVersion.IndexOf(":") + 1).Trim
                        'sIPlist = myWebClient.DownloadString("D:\Hyron Folder\BaiJieYu\workspace\00-SCS All\New\TestIPList.txt")
                        sIPlist = myWebClient.DownloadString(sUpdateSystemConnection & "TestIPList.txt")
                        'modify code 024:end-------------------------------------------------------------------------
                        arrIPlist = sIPlist.Split(Chr(13))
                        'modify code 027:end-------------------------------------------------------------------------
                        myWebClient.Dispose() : myWebClient = Nothing
                    Catch
                        sNewVersion = ""
                    End Try

                    If sNewVersion <> "" AndAlso sNewVersion <> sOldVersion Then
                        Try
                            'modify code 024:start-------------------------------------------------------------------------
                            'Shell("SystemUpdate.exe Old=" & sOldVersion & " New=" & sNewVersion & " Source=" & SecurityText.DecryptData("qfESIwi33U83ObMfQirMJlrPiRIFxKfOfLLpjqnSw84yAzwTfLJfi+JjK1eoOijrV+oF3uIB4IIj7EKwPPYARS3jSabZqaIfsFDFr114R4xUjpPROSGYQpUFl1nGtJk2AO/a7hGvZ5RiDNb2T9u4FBbJtAkyydWm3E1NCYnE+YKjzRY7pEa1nsYPdSUNpPOuncuUFcgdiFOSzBT5AbtfK0Y+UnewMN2Pvte+ibHrsjw/nSBmWB1fDd8hX+9H0IkR"), AppWinStyle.NormalFocus, False)
                            'Shell("SystemUpdate.exe Old=" & sOldVersion & " New=" & sNewVersion & " Source=http://10.132.203.180/SCPublish/New/ShoppingCardSystem.zip Target=Update\ShoppingCardSystem.zip", AppWinStyle.NormalFocus, False)
                            Shell("SystemUpdate.exe Old=" & sOldVersion & " New=" & sNewVersion & " Source=" & sUpdateSystemConnection & "ShoppingCardSystem.zip Target=Update\ShoppingCardSystem.zip", AppWinStyle.NormalFocus, False)
                            'modify code 024:end-------------------------------------------------------------------------
                        Catch
                            MessageBox.Show("发现新版本的购物卡系统，但无法自动升级！    " & Chr(13) & _
                                            "New version system found but unable to upgrade automatically!    " & Chr(13) & Chr(13) & _
                                            "请联系城市IT。 Please contact with City IT.    ", "无法升级购物卡系统 Shopping Card System can not be upgrade!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End Try
                        e.Cancel = True
                        'modify code 027:start-------------------------------------------------------------------------
                    ElseIf sNewVersion = sOldVersion Then
                        Dim WMI As New ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration")
                        Dim sComputerIP As String = "", boolUserTestVersion As Boolean = False
                        For Each WMIOBJ As ManagementObject In WMI.Get
                            If CBool(WMIOBJ("IPEnabled")) Then
                                sComputerIP = WMIOBJ("IPAddress")(0)
                                If sComputerIP.IndexOf("10.") = 0 Then Exit For
                            End If
                        Next
                        WMI = Nothing
                        If sComputerIP <> "" AndAlso Not IsDBNull(arrIPlist) AndAlso arrIPlist.Length > 0 Then
                            For i As Integer = 0 To arrIPlist.Length - 1
                                If arrIPlist(i).Trim() = sComputerIP.Trim() Then
                                    boolUserTestVersion = True
                                    Exit For
                                End If
                            Next
                            If boolUserTestVersion Then
                                If sNewTestVersion > sOldTestVersion Then
                                    Try
                                        'modify code 024:start-------------------------------------------------------------------------
                                        'Shell("SystemUpdate.exe Old=" & sOldTestVersion & " New=" & sNewTestVersion & " Source=" & SecurityText.DecryptData("qfESIwi33U83ObMfQirMJlrPiRIFxKfOfLLpjqnSw84yAzwTfLJfi+JjK1eoOijrV+oF3uIB4IIj7EKwPPYARS3jSabZqaIfsFDFr114R4xUjpPROSGYQpUFl1nGtJk2AO/a7hGvZ5RiDNb2T9u4FBbJtAkyydWm3E1NCYnE+YKjzRY7pEa1nsYPdSUNpPOuncuUFcgdiFOSzBT5AbtfK0Y+UnewMN2Pvte+ibHrsjw/nSBmWB1fDd8hX+9H0IkR"), AppWinStyle.NormalFocus, False)
                                        'Shell("SystemUpdate.exe Old=" & sOldTestVersion & " New=" & sNewTestVersion & " Source=http://10.132.203.180/SCPublish/New/ShoppingCardSystemTest.zip Target=Update\ShoppingCardSystemTest.zip", AppWinStyle.NormalFocus, False)
                                        Shell("SystemUpdate.exe Old=" & sOldTestVersion & " New=" & sNewTestVersion & " Source=" & sUpdateSystemConnection & "ShoppingCardSystemTest.zip Target=Update\ShoppingCardSystemTest.zip", AppWinStyle.NormalFocus, False)
                                        'modify code 024:end-------------------------------------------------------------------------
                                    Catch
                                        MessageBox.Show("发现新版本的购物卡系统测试版本，但无法自动升级！    " & Chr(13) & _
                                                        "New Test version system found but unable to upgrade automatically!    " & Chr(13) & Chr(13) & _
                                                        "请联系城市IT。 Please contact with City IT.    ", "无法升级购物卡系统测试版本 Shopping Card Test System can not be upgrade!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    End Try
                                    e.Cancel = True
                                End If
                            End If
                        End If
                        'modify code 027:end-------------------------------------------------------------------------
                    End If
                End If
            Else
                MessageBox.Show("网络未连接！不能启动购物卡系统！    " & Chr(13) & _
                                "Shopping Card System is unable to startup since network is disconnected!    " & Chr(13) & Chr(13) & _
                                "请检查网络连接。 Please check network connection.    ", "网络未连接 Network disconnected!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                e.Cancel = True
            End If
        End Sub
    End Class
End Namespace