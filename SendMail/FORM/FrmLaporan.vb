Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmLaporan
    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load
        Dim dsRep As DataSet
        'MsgOK(StrConSUP)
        'dsRep = QueryToDataset("select top 1 * from vendor", StrConSUP)
        'MsgOK("1")
        strReport = UCase(strReport)
        Try
            'Dbg(Application.StartupPath & ReportPath)
            'Dbg(sqlreport)
            'MsgOK("2")
            ReportDoc.Load(Application.StartupPath & ReportPath)
            'MsgOK("3")
            dsRep = QueryToDataset(sqlreport)
            'MsgOK("4")
            ReportDoc.DataSourceConnections.Clear()
            'MsgOK("5")
            ReportDoc.SetDataSource(dsRep.Tables(0))
            'MsgOK("6")
            CrystalReportViewer1.ReportSource = ReportDoc
            'MsgOK("7")
            CrystalReportViewer1.Refresh()
            'MsgOK("8")
        Catch ex As Exception
            'MsgOK("9")
            MsgBox(Err.Number & ex.Message & ex.StackTrace.ToString, MsgBoxStyle.Critical)
            'MsgOK("10")
        End Try
        'MsgOK("11")
    End Sub
    Private Sub FrmLaporan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ico As New System.Drawing.Icon(FolderImage & "star.ico") : Me.Icon = ico
        BtnClose.Image = Image.FromFile(FolderImage & "close16.png")
    End Sub
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Close()
    End Sub
End Class