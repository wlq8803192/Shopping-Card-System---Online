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
                    MessageBox.Show("ϵͳ���Ӳ������ݿ⣡    " & Chr(13) & Chr(13) & "�������ӵ��ܲ����ݿ���ⲿ�������жϣ��������ݿ�����ֹͣ����ͣ��    " & Chr(13) & Chr(13) & "������SQL Server���ڲ�������ʾ�� " & Chr(13) & Chr(13) & ex.Message & Space(4), "�������ݿ�ʱ����", MessageBoxButtons.OK, MessageBoxIcon.Stop)
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
            daSQL.SelectCommand.CommandTimeout = 300 '�����
            daSQL.Fill(dsSQL)
            Return dsSQL.Tables(0)
        Catch ex As Exception
            If blNeedPromptError Then MessageBox.Show("�����ݿ��м����������ݣ����������ݿ���ڲ�������ʾ��    " & Chr(13) & Chr(13) & ex.Message & Space(4) & Chr(13) & Chr(13) & "�����˳�ϵͳ�����ԡ�����������⣬����ϵ���������Ա��    ", "�������ݿ�ʱ����", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return Nothing
        End Try
    End Function

    Public Function ModifyTable(ByVal sSQLString As String, Optional ByVal blNeedPromptError As Boolean = True) As Integer
        Try
            Dim sqlComm As New SqlCommand(sSQLString, SqlConn)
            sqlComm.CommandTimeout = 300 '�����
            Dim lReturn As Long = sqlComm.ExecuteNonQuery()
            sqlComm.Dispose()
            Return IIf(lReturn = -1, 0, lReturn) '��ִ�гɹ�������ֵΪ -1 ʱ����Ϊ 0
        Catch ex As Exception
            If blNeedPromptError Then MessageBox.Show("ϵͳ�޷��������ݵ����ݿ⣡���������ݿ���ڲ�������ʾ��    " & Chr(13) & Chr(13) & ex.Message & Space(4) & Chr(13) & Chr(13) & "�����˳�ϵͳ�����ԡ�����������⣬����ϵ���������Ա��    ", "�������ݿ�ʱ����", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return -1
        End Try
    End Function

    Public Function BulkCopyTable(ByVal sTargetTable As String, ByVal dtSourceTable As DataTable, Optional ByVal blNeedPromptError As Boolean = True) As Int16
        Try
            Dim BulkCopy As New SqlBulkCopy(SqlConn)
            BulkCopy.DestinationTableName = sTargetTable
            BulkCopy.BulkCopyTimeout = 300 '�����
            BulkCopy.BatchSize = 2000
            BulkCopy.NotifyAfter = dtSourceTable.Rows.Count
            BulkCopy.WriteToServer(dtSourceTable)
            dtSourceTable.Dispose()
            BulkCopy.Close()
            Return 0
        Catch ex As Exception
            If blNeedPromptError Then MessageBox.Show("ϵͳ�޷��������ݵ����ݿ⣡���������ݿ���ڲ�������ʾ��    " & Chr(13) & Chr(13) & ex.Message & Space(4) & Chr(13) & Chr(13) & "�����˳�ϵͳ�����ԡ�����������⣬����ϵ���������Ա��    ", "�������ݿ�ʱ����", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return -1
        End Try
    End Function

    Public Function DownloadData(ByVal sSQLString As String, Optional ByVal blNeedPromptError As Boolean = True) As SqlDataReader
        Try
            Dim sqlComm As New SqlCommand(sSQLString, SqlConn)
            sqlComm.CommandTimeout = 300 '�����
            Return sqlComm.ExecuteReader()
        Catch ex As Exception
            If blNeedPromptError Then MessageBox.Show("ϵͳ�޷��������ݣ����������ݿ���ڲ�������ʾ��    " & Chr(13) & Chr(13) & ex.Message & Space(4) & Chr(13) & Chr(13) & "�����˳�ϵͳ�����ԡ�����������⣬����ϵ���������Ա��    ", "��������ʱ����", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return Nothing
        End Try
    End Function
End Class