Imports System.Data.OleDb

Module Module1
    ' This is Your Database / Datasource Directory
    ' Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\dbgrp10.accdb

    Public connStr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\dbgrp10.accdb"
    Public conn As New OleDbConnection(connStr)

    Function connect()
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        Return True
    End Function

End Module
