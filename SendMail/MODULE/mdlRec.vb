Imports System.Data
Imports System.Data.OleDb
'Imports CrystalDecisions.Shared
'Imports CrystalDecisions.CrystalReports.Engine

Module mdlRec
#Region "String"
    Public strSQL As String

    Public Kode, Nama, NoRev, NoLine, SBU, Dept, Brand, SQM, Floor As String
    Public Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec As String
    Public Tglrev As String
    Public i As Integer
    Public sFloor, sCount As String
    Public VUser As String

    Public bln As String
    Public TB As String

    Public strLS As String

    Public State As Boolean
    Public Lis As ListViewItem
    Public Y As String 'tahun
    Public H As String 'hari
    Public ms As IO.MemoryStream
    Public ReportPath As String
    Public strReport As String
    'Public Report As New ReportDocument
    'Public MyTableLogInfos As New TableLogOnInfos
    'Public MyTableLogInfo As New TableLogOnInfo
    'Public MyConectionInfo As New ConnectionInfo
    'Public MyTables As Tables
    'Public tbCurrent As Table

    Public PosisiRecord As String = Nothing


#End Region

#Region "Data"
    Public OleDR As OleDbDataReader
    Public DR As OleDbDataReader
    Public drLs As OleDbDataReader
    Public drV As OleDbDataReader
    Public SQMNET As String
    Public DRTran As OleDbDataReader

    Public View As OleDbDataAdapter

    Public CnString As String

    Public sqlDT As New DataTable

    Public DRCEK As OleDbDataReader 'cek
    Public DRUser As OleDbDataReader 'user
    Public DRSaldo As OleDbDataReader
    Public DRSave As OleDbDataReader 'save

    Public DRIM As OleDbDataReader '--itema master
    Public DRSO As OleDbDataReader 'stock opname
    Public DRMUT As OleDbDataReader 'mutasi

    Public DRArea As OleDbDataReader 'Area
    Public da As OleDbDataAdapter
    Public ds As DataSet
    Public dsD As DataSet

    Public da2 As OleDbDataAdapter
    Public ds2 As DataSet

    Public cmd As OleDbCommand
    Public cmdDel As OleDbCommand
    Public cmdSales As OleDbCommand
    Public cmdInsert As OleDbCommand
    Public cmdUpdate As OleDbCommand
    Public cmdStore As OleDbCommand

#End Region

#Region "Data2"
    Public DRNRh As OleDbDataReader
    Public DRNRd As OleDbDataReader
    Public DRBranch As OleDbDataReader
    Public DRlKPI As OleDbDataReader
    Public DRKPI As OleDbDataReader
    Public DRYear As OleDbDataReader

#End Region


    

End Module
