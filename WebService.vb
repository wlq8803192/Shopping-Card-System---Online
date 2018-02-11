Public Class WebService

    Private ReportWS As ShoppingCardWebService.ReportWebService

    Public Sub New()
        ReportWS = New ShoppingCardWebService.ReportWebService
        ReportWS.Proxy = Nothing
        ReportWS.Timeout = 300000
    End Sub

    Public Function GetDataTable(ByVal sSQLString As String) As DataTable
        Try
            Return ReportWS.GetDataTable(sSQLString)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Class
