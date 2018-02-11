Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Module ReportingLog
    Public Sub InsertLog(ByVal sExportingType As String, ByVal sFileName As String, ByVal sRemarks As String)
        Try
            Dim sourceConnection As New SqlConnection(frmMain.sProducingConnection)
            sourceConnection.Open()
            Dim sqlComm As New SqlCommand("Exec wReportingLogInsert @SSID=" & frmMain.sSSID & ",@ExportedTime='" & DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") & "',@ExportingType='" & sExportingType.Replace("'", "''") & "',@FileName='" & sFileName.Replace("'", "''") & "',@Remarks='" & sRemarks.Replace("'", "''") & "'", sourceConnection)
            sqlComm.ExecuteNonQuery()
            sqlComm.Dispose()
            sourceConnection.Close()
        Catch 
        End Try
    End Sub
End Module
