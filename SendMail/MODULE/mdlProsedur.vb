
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient

Module mdlProsedur
    Dim xsize As Integer
    Public m_con As SqlConnection
    'load data in the listview
    Public Sub FillListView(ByVal sqlData As DataTable, ByVal lvList As ListView, ByVal imageID As Integer)
        Dim i As Integer
        Dim j As Integer
        'lvList.Refresh()
        lvList.Clear()
        For i = 0 To sqlData.Columns.Count - 1
            lvList.Columns.Add(sqlData.Columns(i).ColumnName)
        Next i

        For i = 0 To sqlData.Rows.Count - 1
            lvList.Items.Add(sqlData.Rows(i).Item(0), imageID)
            For j = 1 To sqlData.Columns.Count - 1
                If Not IsDBNull(sqlData.Rows(i).Item(j)) Then
                    lvList.Items(i).SubItems.Add(sqlData.Rows(i).Item(j))
                Else
                    lvList.Items(i).SubItems.Add("")
                End If
            Next j
        Next i

        For i = 0 To sqlData.Columns.Count - 1
            xsize = lvList.Width / sqlData.Columns.Count - 8
            'MsgBox(xsize)
            'If xsize > 1440 Then
            lvList.Columns(i).Width = xsize
            'Else
            '   lvList.Columns(i).Width = 2000
            'End If
            'lvList.Columns(i).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
        Next i
    End Sub

    Public Function ExecuteSQLQuery(ByVal SQLQuery As String) As DataTable
        ' Try
        Dim sqlCon As New OleDbConnection(CnString)
        Dim sqlDA As New OleDbDataAdapter(SQLQuery, CMKG)
        Dim sqlCB As New OleDbCommandBuilder(sqlDA)
        sqlDT.Reset() ' refresh 
        sqlDA.Fill(sqlDT)
        'Catch ex As Exception
        'MsgBox("Error: " & ex.ToString)
        'MsgBox(Err.Number & " " & Err.Description)
        'If Err.Number = 5 Then
        '    ' MsgBox("Database settings was invalid !!", "Oops")
        '    MessageBox.Show("Database settings was invalid !!", "oops")
        'End If
        'End Try
        Return sqlDT
    End Function

    'Public Function cmb(ByVal ccmb As ComboBox, ByVal sql As String, ByVal UsrID As String, ByVal mName As String, ByVal cek As Integer)
    '    Dim c As New ArrayList
    '    'Dim m_con As New SqlConnection
    '    'm_con = New SqlConnection(CnString)
    '    Try
    '        Dim strsql As String
    '        strsql = sql

    '        OpenMKG()
    '        'Dim cmd2 As New SqlCommand(strsql, m_con)

    '        Dim objreader2 As SqlDataReader = cmd2.ExecuteReader()
    '        If cek = 1 Then
    '        Else
    '            c.Add(New CCombo("*", "***ALL***"))
    '        End If
    '        Do While objreader2.Read()
    '            c.Add(New CCombo(objreader2(UsrID), objreader2(mName).ToString))
    '            'cmbPTKPID.Items.Add(objreader2("ID"))
    '        Loop
    '        m_con.Close()
    '        With ccmb
    '            .DataSource = c
    '            .DisplayMember = "Number_Name"
    '            .ValueMember = "ID"
    '        End With

    '    Catch ex As Exception
    '        MessageBox.Show(ex.ToString)
    '    End Try
    '    Return ccmb
    'End Function

    
End Module
