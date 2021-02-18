Option Strict Off
Option Explicit On

Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Module mdlCon
    Public CMKG As New OleDbConnection
    Public CCSV As New OleDbConnection
    Public bln() As String
    Public Server, DB, UID, PWS, BI, NM, BID, BNM, MySBU As String

    'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
    Public Class Ini
        Private Declare Ansi Function GetPrivateProfileString Lib "kernel32.dll" Alias "GetPrivateProfileStringA" _
        (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, _
        ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
        Private Declare Ansi Function GetPrivateProfileSection Lib "kernel32" Alias "GetPrivateProfileSectionA" _
        (ByVal lpAppName As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
        Private Declare Ansi Function WritePrivateProfileSection Lib "kernel32" Alias "WritePrivateProfileSectionA" _
        (ByVal lpAppName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer
        Private Declare Ansi Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" _
        (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer
        Private ConfigObject As String
        Public Sub New(ByVal strIniPathFileName As String)
            ConfigObject = strIniPathFileName
        End Sub
        'reads ini string
        Public Function Read(ByVal Section As String, ByVal Key As String, Optional ByVal strDefault As String = "") As String
            Dim v As Integer, strTemp As String = ""
            strTemp = strTemp.PadLeft(255, Chr(0))
            v = GetPrivateProfileString(Section, Key, strDefault, strTemp, 255, ConfigObject)
            If v > 0 Then Read = Left(strTemp, v)
            'Return v
        End Function

        'reads ini section, returns string with values separated with chr(0)
        Public Function ReadSection(ByVal Section As String) As String
            Dim v As Integer, strTemp As String = ""
            strTemp = strTemp.PadLeft(4096, Chr(0))
            v = GetPrivateProfileSection(Section, strTemp, 4096, ConfigObject)
            If v > 0 Then ReadSection = Left(strTemp, v - 1)
            'Return v
        End Function
        'writes ini. creates ini file if it doesnt exist
        Public Sub Save(ByVal Section As String, ByVal Key As String, ByVal Value As String)
            WritePrivateProfileString(Section, Key, Value, ConfigObject)
        End Sub
        'writes ini section. creates ini file if it doesnt exist
        Public Sub SaveSection(ByVal Section As String, ByVal Value As String)
            WritePrivateProfileSection(Section, Value, ConfigObject)
        End Sub
        'removes key in section. creates ini file if it doesnt exist
        Public Sub RemoveKey(ByVal Section As String, ByVal Key As String)
            WritePrivateProfileString(Section, Key, vbNullString, ConfigObject)
        End Sub
        'removes ini section. creates ini file if it doesnt exist
        Public Sub RemoveSection(ByVal Section As String)
            WritePrivateProfileString(Section, vbNullString, "", ConfigObject)
        End Sub
    End Class
    'Public Function getSqldb(ByVal scmd As String) As DataSet
    '    Dim da As New SqlDataAdapter
    '    Dim ds As New DataSet
    '    Dim cmd As New SqlCommand
    '    Dim MyIni As New Ini(Application.StartupPath & "\Config.ini")

    '    Server = MyIni.Read("SERVER", "SERVERNAME")
    '    DB = MyIni.Read("SERVER", "DATABASENAME")
    '    UID = MyIni.Read("SERVER", "LOGINID")
    '    PWS = YinD(MyIni.Read("SERVER", "PASSWORD"))
    '    m_con = New SqlConnection("Data Source=" & MyIni.Read("SERVER", "servername") & ";" & "Initial Catalog=" & MyIni.Read("SERVER", "DatabaseName") & ";" & "User ID=" & MyIni.Read("SERVER", "LoginId") & ";" & "Password=" & YinD(MyIni.Read("SERVER", "Password")) & ";")


    '    cmd = m_con.CreateCommand
    '    cmd.CommandText = scmd
    '    cmd.CommandTimeout = 60
    '    da.SelectCommand = cmd

    '    If m_con.State = ConnectionState.Open Then
    '        m_con.Close()
    '    End If
    '    m_con.Open()
    '    '1:
    '    '        Try
    '    da.Fill(ds)
    '    'Catch ex As Exception
    '    '    GoTo 1
    '    'End Try

    '    m_con.Close()
    '    Return ds
    'End Function
    Public Sub OpenSERVER2()
        Dim MyIni As New Ini(Application.StartupPath & "\Config.ini")
        Server = MyIni.Read("SERVER", "SERVERNAME")
        DB = MyIni.Read("SERVER", "DATABASENAME")
        UID = MyIni.Read("SERVER", "LOGINID")
        PWS = YinD(MyIni.Read("SERVER", "PASSWORD"))
        BID = MyIni.Read("SERVER", "BRANCH_ID")
        BNM = MyIni.Read("SERVER", "BRANCH_NAME")
        Try
            CServer = New OleDbConnection("Provider=sqloledb;" & "data source=" & MyIni.Read("SERVER", "servername") & ";" & _
                                                    " initial catalog=" & MyIni.Read("SERVER", "DatabaseName") & ";" & _
                                                    " uid=" & MyIni.Read("SERVER", "LoginId") & ";" & _
                                                    " Password=" & YinD(MyIni.Read("SERVER", "Password")) & ";")
            CServer.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End
        End Try
    End Sub

    Public Sub OpenMKG()
        Dim MyIni As New Ini(Application.StartupPath & "\Config.ini")
        Server = MyIni.Read("SERVERMKG", "SERVERNAME")
        DB = MyIni.Read("SERVERMKG", "DATABASENAME")
        UID = MyIni.Read("SERVERMKG", "LOGINID")
        PWS = YinD(MyIni.Read("SERVERMKG", "PASSWORD"))
        BID = MyIni.Read("SERVERMKG", "BRANCH_ID")
        BNM = MyIni.Read("SERVERMKG", "BRANCH_NAME")
        Try
            If My.Computer.Network.Ping(Server) Then
                CMKG = New OleDbConnection("Provider=sqloledb;" & "data source=" & MyIni.Read("SERVERMKG", "servername") & ";" & _
                                                        " initial catalog=" & MyIni.Read("SERVERMKG", "DatabaseName") & ";" & _
                                                        " uid=" & MyIni.Read("SERVERMKG", "LoginId") & ";" & _
                                                        " Password=" & YinD(MyIni.Read("SERVERMKG", "Password")) & ";")
                CMKG.Open()
            Else
                MessageBox.Show("Connection to MKG Offline", "Oops")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End
        End Try
    End Sub

    Public Sub CheckConnection()
        If CMKG Is Nothing OrElse CMKG.State = ConnectionState.Closed Then
            OpenMKG()
        End If

        'OpenMKG()
    End Sub

    Public Sub CheckConnection2()
        If CMKG Is Nothing OrElse CMKG.State = ConnectionState.Closed Then
            OpenSERVER2()
        End If

        'OpenMKG()
    End Sub

    'Public Sub OpenCSV()
    '    Try
    '        CCSV = New OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;" & "data source=" & Application.StartupPath & "c:\SOS001.csv" & " ; Extended Properties=text;")
    '        CCSV.Open()
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK)
    '    End Try
    'End Sub
    Public Sub Read(ByVal SQL As String)
        CheckConnection()
        cmd = New OleDbCommand(SQL, CMKG)
        cmd.CommandTimeout = 0
    End Sub

    Public Sub ExecQueryx(ByVal SQL As String)
        cmd = New OleDbCommand(SQL, CMKG)
        cmd.ExecuteNonQuery()
    End Sub
    Function DigitCheck(ByVal V_AngkaBC As String) As Byte
        Dim BytToggle As Byte, BytCount As Byte, BytDigit As Byte
        BytToggle = 3
        For i As Integer = Len(V_AngkaBC) To 1 Step -1
            BytCount = BytCount + (Mid(V_AngkaBC, i, 1) * BytToggle)
            BytToggle = 4 - BytToggle
        Next i
        BytDigit = BytCount Mod 10
        BytDigit = IIf(BytDigit = 0, 0, 10 - BytDigit)
        DigitCheck = BytDigit
    End Function
    Public Function YinC(ByRef C As String) As String
        Dim Result As String
        Dim i As Short
        Result = ""
        i = 1
        Do While i < (Len(Trim(C)) + 1)
            Result = Result & Chr(Asc(Mid(Trim(C), i, 1)) * 2)
            i = i + 1
        Loop
        YinC = Result
    End Function

    Public Function YinD(ByRef C As String) As String
        Dim Result As String
        Dim i As Short
        Result = ""
        i = 1
        Do While i < (Len(Trim(C)) + 1)
            Result = Result & Chr(Asc(Mid(Trim(C), i, 1)) / 2)
            i = i + 1
        Loop
        YinD = Result
    End Function
    Public Sub ExecQuery(ByVal Query As String, Optional ByVal strCon As String = "")
        strCon = strCon_Global
        If strCon.Trim = "" Then
            m_con2 = New SqlConnection(StrConSUP)
        Else
            m_con2 = New SqlConnection(strCon)
        End If
        Dim cmd As New SqlCommand

        cmd = m_con2.CreateCommand
        cmd.CommandText = Query
        cmd.CommandTimeout = 120
        If m_con2.State = ConnectionState.Open Then
            m_con2.Close()
        End If
        m_con2.Open()

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        m_con2.Close()
    End Sub
End Module

