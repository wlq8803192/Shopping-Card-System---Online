Public Class frmSelectWorkSheet

    Public sFileName As String = ""

    Private Sub lblOpenSource_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblOpenSource.LinkClicked
        Dim excelAPP As Object = Nothing
        Try
            excelAPP = GetObject(, "Excel.Application")
        Catch
            Try
                excelAPP = CreateObject("Excel.Application")
            Catch
            End Try
        End Try

        If excelAPP IsNot Nothing Then
            Try
                excelAPP.Windows(sFileName.Substring(sFileName.LastIndexOf("\") + 1)).Activate()
            Catch
                Try
                    excelAPP.DisplayAlerts = False
                    excelAPP.Workbooks.Open(sFileName)
                    excelAPP.DisplayAlerts = True
                Catch
                End Try
            End Try
            excelAPP.Visible = False : excelAPP.Visible = True
            excelAPP = Nothing
        End If
    End Sub
End Class