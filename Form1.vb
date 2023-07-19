Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine

Public Class Form1
    Dim dset As New DataSet
    Dim comm As New OleDbCommand
    Dim da As New OleDbDataAdapter(comm)

    Dim strReportPath As String

    Private Sub verifyCr()
        ' This is Your Crystal Report Directory
        strReportPath = "G:\TOHOOOO\APP DRAFTS\Visual Basic\GRP10_CR_MsAccess\CrystalReport2.rpt"

        If Not IO.File.Exists(strReportPath) Then
            MessageBox.Show("Unable to Locate File. " & vbCrLf & strReportPath)
        End If
    End Sub

    Private Sub populate()
        ' Loads the Updated Data when Operations was used.
        da = New OleDbDataAdapter("Select * From mvlst", conn)
        dset = New DataSet
        da.Fill(dset, "mvlst")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        connect()
        verifyCr()
        populate()

        Try
            ' Load the Crystal Report .rpt File and pass it onto Datatable
            Dim cr As New ReportDocument

            cr.Load(strReportPath)
            cr.SetDataSource(dset.Tables("mvlst"))

            ' Set the CrystalReportViewer's Appearance and Set the ReportSource:
            CrystalReportViewer1.ShowRefreshButton = False
            CrystalReportViewer1.ShowCloseButton = False
            CrystalReportViewer1.ShowGroupTreeButton = False

            CrystalReportViewer1.ReportSource = cr

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        Finally
            conn.Close()
        End Try
    End Sub
End Class
