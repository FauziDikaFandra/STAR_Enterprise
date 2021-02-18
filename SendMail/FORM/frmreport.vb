Option Explicit On

Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmreport
    Dim pvCollection As New ParameterValues
    Dim pdvSDate As New ParameterDiscreteValue
    Dim pdvEDate As New ParameterDiscreteValue
    Dim pdvstore As New ParameterDiscreteValue
    Dim pdvstore1 As New ParameterDiscreteValue
    Dim pdvstore2 As New ParameterDiscreteValue
    Dim pdvstore3 As New ParameterDiscreteValue

    Private Sub crv1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles crv1.Load
    End Sub


    'Private Sub SetDBLogonForReport(ByVal myReportDocument As ReportDocument)
    '    Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()
    '    myConnectionInfo.DatabaseName = m_DBName
    '    myConnectionInfo.UserID = m_UserName
    '    myConnectionInfo.Password = m_Password
    '    myConnectionInfo.ServerName = m_ServerName
    '    myConnectionInfo.IntegratedSecurity = "false"
    '    Dim myTables As Tables = myReportDocument.Database.Tables
    '    For Each myTable As CrystalDecisions.CrystalReports.Engine.Table In myTables
    '        Dim myTableLogonInfo As TableLogOnInfo = myTable.LogOnInfo
    '        myTableLogonInfo.ConnectionInfo = myConnectionInfo
    '        myTable.ApplyLogOnInfo(myTableLogonInfo)
    '    Next
    'End Sub
End Class