Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class DataBase
    Implements IDisposable
    Public IsConnected As Boolean = True
    Private SqlConn As SqlConnection = Nothing

    Public Sub Dispose() Implements System.IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(True)
    End Sub

    Public Sub Dispose(ByVal disposing As Boolean)
        If disposing <> True Then Return
        If SqlConn Is Nothing = False Then
            SqlConn.Dispose()
            SqlConn = Nothing
        End If
    End Sub

    Public Sub Open(Optional ByVal blMustProducingMode As Boolean = False)
        'If My.Computer.Network.IsAvailable Then
        If SqlConn Is Nothing Then
            If blMustProducingMode Then
                SqlConn = New SqlConnection(frmMain.sProducingConnection)
            Else
                SqlConn = New SqlConnection(frmMain.sConnectionString)
            End If
            If SqlConn.State = ConnectionState.Closed Then
                Try
                    SqlConn.Open()
                Catch ex As Exception
                    MessageBox.Show("系统连接不到数据库！    " & Chr(13) & Chr(13) & "可能连接到总部数据库的外部网络已中断，或者数据库存服务被停止或暂停。    " & Chr(13) & Chr(13) & "以下是SQL Server的内部错误提示： " & Chr(13) & Chr(13) & ex.Message & Space(4), "连接数据库时出错！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    IsConnected = False
                    Me.Close()
                End Try
            End If
        End If
        'Else
        'IsConnected = False
        'End If
    End Sub

    Public Sub Close()
        If SqlConn IsNot Nothing Then
            SqlConn.Close()
            Me.Dispose()
        End If
    End Sub

    Public Function GetDataTable(ByVal sSQLString As String, Optional ByVal blNeedPromptError As Boolean = True) As DataTable
        Try
            Dim dsSQL As DataSet = New DataSet
            Dim daSQL As SqlDataAdapter = New SqlDataAdapter(sSQLString, SqlConn)
            daSQL.SelectCommand.CommandTimeout = 300 '五分钟
            daSQL.Fill(dsSQL)
            Return dsSQL.Tables(0)
        Catch ex As Exception
            If blNeedPromptError Then MessageBox.Show("从数据库中检索不到数据！下面是数据库的内部错误提示：    " & Chr(13) & Chr(13) & ex.Message & Space(4) & Chr(13) & Chr(13) & "请先退出系统后重试。如果仍有问题，请联系软件开发人员。    ", "检索数据库时出错！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return Nothing
        End Try
    End Function

    Public Function ModifyTable(ByVal sSQLString As String, Optional ByVal blNeedPromptError As Boolean = True) As Integer
        Try
            Dim sqlComm As New SqlCommand(sSQLString, SqlConn)
            sqlComm.CommandTimeout = 300 '五分钟
            Dim lReturn As Long = sqlComm.ExecuteNonQuery()
            sqlComm.Dispose()
            Return IIf(lReturn = -1, 0, lReturn) '当执行成功但返回值为 -1 时重置为 0
        Catch ex As Exception
            If blNeedPromptError Then MessageBox.Show("系统无法更新数据到数据库！下面是数据库的内部错误提示：    " & Chr(13) & Chr(13) & ex.Message & Space(4) & Chr(13) & Chr(13) & "请先退出系统后重试。如果仍有问题，请联系软件开发人员。    ", "更新数据库时出错！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return -1
        End Try
    End Function

    Public Function BulkCopyTable(ByVal sTargetTable As String, ByVal dtSourceTable As DataTable, Optional ByVal blNeedPromptError As Boolean = True) As Int16
        Try
            Dim BulkCopy As New SqlBulkCopy(SqlConn)
            BulkCopy.DestinationTableName = sTargetTable
            BulkCopy.BulkCopyTimeout = 300 '五分钟
            BulkCopy.BatchSize = 2000
            BulkCopy.NotifyAfter = dtSourceTable.Rows.Count
            BulkCopy.WriteToServer(dtSourceTable)
            dtSourceTable.Dispose()
            BulkCopy.Close()
            Return 0
        Catch ex As Exception
            If blNeedPromptError Then MessageBox.Show("系统无法更新数据到数据库！下面是数据库的内部错误提示：    " & Chr(13) & Chr(13) & ex.Message & Space(4) & Chr(13) & Chr(13) & "请先退出系统后重试。如果仍有问题，请联系软件开发人员。    ", "更新数据库时出错！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return -1
        End Try
    End Function

    Public Function DownloadData(ByVal sSQLString As String, Optional ByVal blNeedPromptError As Boolean = True) As SqlDataReader
        Try
            Dim sqlComm As New SqlCommand(sSQLString, SqlConn)
            sqlComm.CommandTimeout = 300 '五分钟
            Return sqlComm.ExecuteReader()
        Catch ex As Exception
            If blNeedPromptError Then MessageBox.Show("系统无法下载数据！下面是数据库的内部错误提示：    " & Chr(13) & Chr(13) & ex.Message & Space(4) & Chr(13) & Chr(13) & "请先退出系统后重试。如果仍有问题，请联系软件开发人员。    ", "下载数据时出错！", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return Nothing
        End Try
    End Function
End Class