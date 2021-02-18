Public Class VQuery
    'Inherits DataSet
    'Inherits System.Collections.CollectionBase

    Implements IDisposable
    Private col As Collection = New Collection
    Private myPrimary, myTable, myQuery, myStringColumn1, myStringColumn2, myStrCon As String
    Private myZQCollection As New ZQCollection
    Private myZQColumns As New ZQCollection
    Private myColEdit As New ZQCollection
    Private myRecordCount, myColumnCount, myRecNo As Integer
    Private myIsUpdate As Boolean
    Private LsCol As New List(Of String)
    Private LsPK As New List(Of String)
    Private LsColumnSet As New List(Of String)
    Private strFill() As String
    Private dsss As DataSet
    Private stopx As Integer
#Region "Property"
    ReadOnly Property SQL() As String
        Get
            CheckIfDisposed()
            Return myQuery
        End Get
        'Set(ByVal Value As String)
        '    CheckIfDisposed()
        '    myQuery = Value
        'End Set
    End Property
    ReadOnly Property RecordCount() As Integer
        Get
            CheckIfDisposed()
            Return myRecordCount
        End Get
    End Property
    ReadOnly Property RecNo() As Integer
        Get
            CheckIfDisposed()
            Return myRecNo
        End Get
    End Property
    ReadOnly Property IsUpdate() As Boolean
        Get
            CheckIfDisposed()
            Return myIsUpdate
        End Get
    End Property
    ReadOnly Property ColumnCount() As Integer
        Get
            CheckIfDisposed()
            Return myColumnCount
        End Get
    End Property
    ReadOnly Property Items() As ZQCollection
        Get
            CheckIfDisposed()
            Return myZQCollection
        End Get
    End Property
    ReadOnly Property Columns() As ZQCollection
        Get
            CheckIfDisposed()
            Return myZQCollection
            'Return myZQColumns
        End Get
    End Property
    ReadOnly Property ColEdit() As ZQCollection
        Get
            CheckIfDisposed()
            Return myColEdit
        End Get
    End Property
    ReadOnly Property TableName() As String
        Get
            CheckIfDisposed()
            Return myTable
        End Get
    End Property
#End Region

#Region "Add, Edit, Save"
    Public Sub Query(ByVal SQL As String, ByVal Primary As String, Optional ByVal strCon As String = "")
        CheckIfDisposed()
        myPrimary = LCase(Primary)

        Dim words As String() = SplitWords(SQL, " ") : Dim word As String
        Dim ls1 As New List(Of String) : ls1.Clear()
        For Each word In words
            word = LCase(word).ToString.Trim
            ls1.Add(word)
        Next
        For x As Integer = 0 To ls1.Count - 1
            If LCase(ls1.Item(x).ToString) = "from" Then
                myTable = ls1.Item(x + 1).ToString.Trim
                Exit For
            End If
        Next

        LsPK.Clear()
        words = SplitWords(Primary, ",")
        For Each word In words
            word = LCase(word).ToString.Trim
            LsPK.Add(word)
        Next

        myStrCon = strCon
        If myStrCon = "" Then myStrCon = strCon_Global
        'MsgOK(myStrCon)
        myRecNo = 0
        myQuery = SQL
        dsss = QueryToDataset2(SQL, myStrCon)
        myRecordCount = GetDSRecordCount(dsss)
        myColumnCount = dsss.Tables(0).Columns.Count

        myIsUpdate = False
        If myRecordCount > 0 Then myIsUpdate = True

        myZQCollection.Clear()
        'myZQColumns.Clear()
        'myColEdit.Clear()
        myStringColumn1 = ""
        myStringColumn2 = ""
        For x As Integer = 0 To dsss.Tables(0).Columns.Count - 1
            myZQCollection.Add(LCase(dsss.Tables(0).Columns(x).ColumnName.ToString.Trim))
            'MsgOK("Columnname : " & dsss.Tables(0).Columns(x).ColumnName.ToString & vbCrLf & _
            '      "ColumnType : " & dsss.Tables(0).Columns(x).DataType.ToString)
            'myZQColumns.Add("null")
            'myColEdit.Add("0")
        Next

        LsColumnSet.Clear()
        stopx = 0
        If myIsUpdate Then
            FillFirstData(0)
        End If
    End Sub
    Function Tables(Optional ByVal index As Integer = 0) As DataTable
        Return dsss.Tables(index)
    End Function
    Sub FillFirstData(Optional ByVal rowIndex As Integer = 0)
        myStringColumn1 = ""
        LsColumnSet.Clear()
        For x As Integer = 0 To dsss.Tables(0).Columns.Count - 1
            If IsDSNull(dsss, Me.ColumnName(x)) Then
            Else
                'If LCase(dsss.Tables(0).Columns(x).DataType.ToString) = "system.datetime" Or _
                '   LCase(dsss.Tables(0).Columns(x).DataType.ToString) = "system.date" Or _
                '   LCase(dsss.Tables(0).Columns(x).DataType.ToString) = "system.time" Then
                '    Me.SetField(dsss.Tables(0).Columns(x).ColumnName, _
                '                Format(DateTime.Parse(dsss.Tables(0).Rows(rowIndex).Item(x).ToString), "yyyy-MM-dd"))
                'Else
                '    Me.SetField(dsss.Tables(0).Columns(x).ColumnName, _
                '                dsss.Tables(0).Rows(rowIndex).Item(x).ToString)
                'End If

                If LCase(Me.ColumnType(x)) = "system.datetime" Or _
                  LCase(Me.ColumnType(x)) = "system.date" Or _
                  LCase(Me.ColumnType(x)) = "system.time" Then
                    If dsss.Tables(0).Rows(rowIndex).Item(x).ToString <> "" Then
                        Me.SetField(Me.ColumnName(x), _
                                    Format(DateTime.Parse(dsss.Tables(0).Rows(rowIndex).Item(x).ToString), "yyyy-MM-dd"))
                    End If
                Else
                    Me.SetField(Me.ColumnName(x), _
                                dsss.Tables(0).Rows(rowIndex).Item(x).ToString)
                End If

                End If
        Next
    End Sub
    Public Sub Edit()
        CheckIfDisposed()
        myIsUpdate = True
    End Sub
    Public Sub Add()
        CheckIfDisposed()
        myIsUpdate = False
    End Sub
    Public Sub Save()
        CheckIfDisposed()
        Dim kol1, kol2, kolUpdate, ssQL, kolPrimary As String

        kolUpdate = ""
        kolPrimary = ""
        kol1 = ""
        kol2 = ""
        For x As Integer = 0 To LsColumnSet.Count - 1
            If Not myPrimary.Contains(LsColumnSet.Item(x).ToString.Trim()) Then
                'bukan primary key
                If getValueFromString(LsColumnSet.Item(x).ToString.Trim, myStringColumn2) <> "" Then
                    kolUpdate += vbCrLf + LsColumnSet.Item(x).ToString.Trim + "='" + _
                             getValueFromString(LsColumnSet.Item(x).ToString.Trim, myStringColumn2) + "',"
                Else
                    kolUpdate += vbCrLf + LsColumnSet.Item(x).ToString.Trim + "='" + _
                             getValueFromString(LsColumnSet.Item(x).ToString.Trim, myStringColumn1) + "',"
                End If
            Else
                If getValueFromString(LsColumnSet.Item(x).ToString.Trim, myStringColumn2) <> "" Then
                    kolPrimary += vbCrLf + LsColumnSet.Item(x).ToString.Trim + "='" + _
                             getValueFromString(LsColumnSet.Item(x).ToString.Trim, myStringColumn2) + "' and "
                Else
                    kolPrimary += vbCrLf + LsColumnSet.Item(x).ToString.Trim + "='" + _
                             getValueFromString(LsColumnSet.Item(x).ToString.Trim, myStringColumn1) + "' and "
                End If
            End If
            kol1 += vbCrLf + LsColumnSet.Item(x).ToString.Trim + ","
            If getValueFromString(LsColumnSet.Item(x).ToString.Trim, myStringColumn2) <> "" Then
                kol2 += vbCrLf + "'" + getValueFromString(LsColumnSet.Item(x).ToString.Trim, myStringColumn2) + "',"
            Else
                kol2 += vbCrLf + "'" + getValueFromString(LsColumnSet.Item(x).ToString.Trim, myStringColumn1) + "',"
            End If
        Next

        kolPrimary += " (0=0) "
        kolUpdate = Mid(kolUpdate, 1, Len(kolUpdate) - 1)
        kol1 = Mid(kol1, 1, Len(kol1) - 1)
        kol2 = Mid(kol2, 1, Len(kol2) - 1)

        If myIsUpdate Then
            ssQL = "update " & myTable & " set " & kolUpdate & " where " & kolPrimary
        Else
            ssQL = "insert into " & myTable & " (" & kol1 & ") values (" & kol2 & ")"
        End If
        'Dbg(ssQL)
        ExecQuery(ssQL)
    End Sub
#End Region
#Region "Record"
    Public Sub FirstRecord()
        CheckIfDisposed()
        myRecNo = 0
        stopx = 0
        FillFirstData(myRecNo)
    End Sub
    Public Sub LastRecord()
        CheckIfDisposed()
        myRecNo = dsss.Tables(0).Rows.Count - 1
        FillFirstData(myRecNo)
    End Sub
    Public Sub NextRecord()
        CheckIfDisposed()
        myRecNo += 1
        If myRecNo >= dsss.Tables(0).Rows.Count - 1 Then
            myRecNo = dsss.Tables(0).Rows.Count - 1
        End If
        'MsgOK(myRecNo)
        FillFirstData(myRecNo)
    End Sub
    Public Sub PrevRecord()
        CheckIfDisposed()
        myRecNo -= 1
        If myRecNo <= 0 Then
            myRecNo = 0
        End If
        FillFirstData(myRecNo)
    End Sub
    Public Function EOF()
        CheckIfDisposed()
        Dim hasil As Boolean = False
        If myRecNo = dsss.Tables(0).Rows.Count - 1 Then
            stopx += 1
        End If
        'MsgOK(myRecNo & "," & dsss.Tables(0).Rows.Count - 1 & "," & stopx)
        If myRecNo >= dsss.Tables(0).Rows.Count - 1 Then
            If stopx >= 2 Then hasil = True
        End If
        Return hasil
    End Function
    Public Function BOF()
        CheckIfDisposed()
        Dim hasil As Boolean = False
        If myRecNo <= 0 Then
            hasil = True
        End If
        Return hasil
    End Function

    Public Function ColumnName(ByVal Index As Integer) As String
        CheckIfDisposed()
        Return dsss.Tables(0).Columns(Index).ColumnName.ToString
    End Function
    Public Function ColumnType(ByVal index As Integer) As String
        CheckIfDisposed()
        Return dsss.Tables(0).Columns(index).DataType.ToString
    End Function
#End Region
#Region "Set Get"
    Public Sub SetField1(ByVal ColumnName As String, ByVal Text As String)
        CheckIfDisposed()
        Dim sudahAda As Boolean = False
        For x As Integer = 0 To LsColumnSet.Count - 1
            If LCase(LsColumnSet.Item(x).ToString.Trim) = LCase(ColumnName.Trim) Then sudahAda = True
        Next
        If sudahAda = False Then LsColumnSet.Add(ColumnName.Trim)

        myStringColumn1 += ColumnName.Trim + "=" + Text.Trim + ";"
    End Sub
    Public Sub SetField(ByVal ColumnName As String, ByVal Text As String)
        CheckIfDisposed()
        Dim sudahAda As Boolean = False
        For x As Integer = 0 To LsColumnSet.Count - 1
            If LCase(LsColumnSet.Item(x).ToString.Trim) = LCase(ColumnName.Trim) Then sudahAda = True
        Next
        If sudahAda = False Then LsColumnSet.Add(ColumnName.Trim)

        myStringColumn2 += ColumnName.Trim + "=" + Text.Trim + ";"
    End Sub
    Public Function GetField(ByVal ColumnName As String) As String
        CheckIfDisposed()
        Dim hasil As String = ""
        If getValueFromString(ColumnName.Trim, myStringColumn2) <> "" Then
            hasil = getValueFromString(ColumnName.Trim, myStringColumn2)
        Else
            hasil = getValueFromString(ColumnName.Trim, myStringColumn1)
        End If
        Return hasil
    End Function
    'Public Sub GetDateTime(ByVal ColumnName As String, ByVal Dt As DateTimePicker)
    '    'If Me.GetField(ColumnName) = "null" Then
    '    If Me.IsNull(ColumnName) Then
    '        Dt.Checked = False
    '    Else
    '        Dt.Checked = True
    '        Dt.Value = Me.GetField(ColumnName)
    '    End If
    'End Sub
    Public Function IsNull(ByVal ColumnName As String) As Boolean
        CheckIfDisposed()
        Dim index As Integer
        For x As Integer = 0 To Me.Items.Count - 1
            If LCase(Me.Items(x).ToString) = LCase(ColumnName) Then
                index = x
                Exit For
            End If
        Next
        Dim hasil As Boolean = True

        If IsDBNull(dsss.Tables(0).Rows(myRecNo).Item(index)) Then
            'If dsss.Tables(0).Rows(myRecNo).Item(index) = DBNull.Value Then
            'MsgBox(dsss.Tables(0).Rows(myRecNo).Item(index).GetType.ToString)
            hasil = True
        Else
            'MsgBox(dsss.Tables(0).Rows(myRecNo).Item(index).GetType.ToString)
            hasil = False
        End If
        Return hasil
    End Function
#End Region


#Region "Finalize Dispose"
    Protected Overrides Sub Finalize()
        'MsgBox("ThisClass is shutting down with Sub Finalize.")
        Dispose(False)
    End Sub
    ' Do not add Overridable to this method. 
    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        'MsgBox("ThisClass is shutting down with Sub Dispose.")
        clearDataSet(dsss)
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
    Private disposed As Boolean = False
    Public Sub CheckIfDisposed()
        If Me.disposed Then
            Throw New ObjectDisposedException(Me.GetType().ToString, _
            "This object has been disposed.")
        End If
    End Sub
    Protected Overridable Overloads Sub Dispose( _
    ByVal disposing As Boolean)
        'MsgBox("ThisClass is shutting down with the Sub Dispose overload.")
        ' Place final cleanup tasks here. 
        If Not Me.disposed Then
            If disposing Then
                ' Dispose of any managed resources. 
            End If
            ' Dispose of any unmanaged resource. 
            ' Call MyBase.Finalize if this is a derived class,  
            ' and the base class does not implement Dispose. 
            MyBase.Finalize()
        End If
        Me.disposed = True
    End Sub
#End Region
End Class
