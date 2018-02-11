
'modify code 043:start-------------------------------------------------------------------------
Public Class frmCustomReport

    Private Sub frmCustomReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strHeaders As String = "Content-Type: application/x-www-form-urlencoded" & vbCrLf
        Dim strPostdata As String = ""
        Dim sRight As String = "|Customer|Contract|SalesBill|SalesBillDetails|Payment|Invoice|InternetSelling|ECardInvoice|"
        If frmMain.sLoginRoleID = "7" Then sRight = "|SalesBillJV|SalesBillDetails|Payment|Invoice|InternetSelling|ECardInvoice|" '城市财务经理
        If frmMain.sLoginRoleID = "16" Then sRight = "|SalesBill|SalesBillDetails|Payment|InternetSelling|ECardInvoice|" '门店绩效经理

        strPostdata = String.Format("LoginUserID={0}", frmMain.sLoginUserID)

        If My.Settings.IsInTraining = True Then '培训模式
            strPostdata += String.Format("&ConnectionString={0}", frmMain.sTrainingConnection)
        Else
            strPostdata += String.Format("&ConnectionString={0}", frmMain.sReportConnection)
        End If

        strPostdata += String.Format("&Right={0}", sRight)

        Dim bPostdata() As Byte = System.Text.Encoding.UTF8.GetBytes(strPostdata)

        Me.WebBrowser.Navigate(frmMain.sCustomReportWeb, Nothing, bPostdata, strHeaders)

    End Sub
End Class
'modify code 043:end-------------------------------------------------------------------------