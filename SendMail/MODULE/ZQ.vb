Public Class ZQ
    'Inherits DataSet
    'Inherits System.Collections.CollectionBase

    Implements IDisposable
    Private col As Collection = New Collection
    Private myPrimary, myTable, myQuery As String
    Private myZQCollection As New ZQCollection
    Private myZQColumns As New ZQCollection
    Private myColEdit As New ZQCollection
    Private myRecordCount, myColumnCount, myRecNo As Integer
    Private myIsUpdate As Boolean
    Private LsCol As New List(Of String)
    Private LsPK As New List(Of String)
    Private strFill() As String
    Private dsss As DataSet
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
            Return myZQColumns
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

        myRecNo = 0
        myQuery = SQL
        myIsUpdate = False
        dsss = QueryToDataset(SQL, strCon)
        myRecordCount = GetDSRecordCount(dsss)
        If myRecordCount > 0 Then myIsUpdate = True

        myZQCollection.Clear()
        myZQColumns.Clear()
        myColEdit.Clear()
        For x As Integer = 0 To dsss.Tables(0).Columns.Count - 1
            myZQCollection.Add(LCase(dsss.Tables(0).Columns(x).ColumnName.ToString.Trim))
            myZQColumns.Add("null")
            myColEdit.Add("0")
        Next
        myColumnCount = myZQCollection.Count
    End Sub
    Public Sub Edit()
        myIsUpdate = True
    End Sub
    Public Sub Add()
        myIsUpdate = False
    End Sub
    Public Sub Save()
        Dim i1, i2, p, u, sql As String
        Dim isPrimary As Boolean = False
        i1 = "" : i2 = "" : u = "" : p = ""
        For x As Integer = 0 To Me.ColumnCount - 1
            i1 = i1 & Me.ColumnName(x) & ","
            If IsDBNull(dsss.Tables(0).Rows(myRecNo).Item(x)) Then
                i2 = i2 & "null,"
                isPrimary = False
                For y As Integer = 0 To LsPK.Count - 1
                    If LCase(LsPK(y).ToString) = Me.ColumnName(x).ToString Then isPrimary = True
                Next
                If isPrimary = False Then
                    u = u & Me.ColumnName(x) & "=null,"
                Else
                    p = p & Me.ColumnName(x) & "=null and "
                End If
            Else
                If Me.ColumnType(x) = "date" Then
                    i2 = i2 & "'" & Format(Date.Parse(Me.GetField(Me.ColumnName(x)).ToString), "yyyy-MM-dd") & "',"
                    isPrimary = False
                    For y As Integer = 0 To LsPK.Count - 1
                        If LCase(LsPK(y).ToString) = Me.ColumnName(x).ToString Then isPrimary = True
                    Next
                    If isPrimary = False Then
                        u = u & Me.ColumnName(x) & "='" & Format(Date.Parse(Me.GetField(Me.ColumnName(x)).ToString), "yyyy-MM-dd") & "',"
                    Else
                        p = p & Me.ColumnName(x) & "='" & Format(Date.Parse(Me.GetField(Me.ColumnName(x)).ToString), "yyyy-MM-dd") & "' and "
                    End If
                ElseIf Me.ColumnType(x) = "datetime" Then
                    i2 = i2 & "'" & Format(Date.Parse(Me.GetField(Me.ColumnName(x)).ToString), "yyyy-MM-dd HH:mm:ss") & "',"
                    isPrimary = False
                    For y As Integer = 0 To LsPK.Count - 1
                        If LCase(LsPK(y).ToString) = Me.ColumnName(x).ToString Then isPrimary = True
                    Next
                    If isPrimary = False Then
                        u = u & Me.ColumnName(x) & "='" & Format(Date.Parse(Me.GetField(Me.ColumnName(x)).ToString), "yyyy-MM-dd HH:mm:ss") & "',"
                    Else
                        p = p & Me.ColumnName(x) & "='" & Format(Date.Parse(Me.GetField(Me.ColumnName(x)).ToString), "yyyy-MM-dd HH:mm:ss") & "' and "
                    End If
                Else
                    i2 = i2 & "'" & Me.GetField(Me.ColumnName(x)).ToString & "',"
                    isPrimary = False
                    For y As Integer = 0 To LsPK.Count - 1
                        If LCase(LsPK(y).ToString) = Me.ColumnName(x).ToString Then isPrimary = True
                    Next
                    If isPrimary = False Then
                        u = u & Me.ColumnName(x) & "='" & Me.GetField(Me.ColumnName(x)).ToString & "',"
                    Else
                        p = p & Me.ColumnName(x) & "='" & Me.GetField(Me.ColumnName(x)).ToString & "' and "
                    End If
                End If
            End If
        Next
        i1 = Mid(i1, 1, Len(i1) - 1)
        i2 = Mid(i2, 1, Len(i2) - 1)
        u = Mid(u, 1, Len(u) - 1)
        p = p & " (0=0) "
        Dim words As String() = SplitWords(myPrimary, ",") : Dim word As String
        Dim ls1 As New List(Of String) : ls1.Clear()
        For Each word In words
            word = LCase(word).ToString.Trim
            ls1.Add(word)
        Next
        If myIsUpdate Then
            sql = "update " & myTable & " set " & u & " where " & p
        Else
            sql = "insert into " & myTable & " (" & i1 & ") values (" & i2 & ") "
        End If
        Dbg(sql)
        ExecQuery(sql)
    End Sub
#End Region
#Region "Record"
    Public Sub FirstRecord()
        CheckIfDisposed()
        For x As Integer = 0 To myColEdit.Count - 1
            myColEdit.Fill(x, "0")
        Next
        myRecNo = 0
    End Sub
    Public Sub NextRecord()
        CheckIfDisposed()
        For x As Integer = 0 To myColEdit.Count - 1
            myColEdit.Fill(x, "0")
        Next
        myRecNo = myRecNo + 1
        If myRecNo >= myRecordCount Then myRecNo = myRecordCount - 1
    End Sub
    Public Function ColumnName(ByVal Index As Integer) As String
        Return Me.Items(Index).ToString
    End Function
    Public Function ColumnType(ByVal index As Integer, Optional ByVal strCon As String = "") As String
        Dim sql As String
        sql = "SELECT data_type FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'" & myTable & "' " & _
                               "and column_name='" & Me.ColumnName(index).ToString & "'"
        Return LCase(getStringFromDB(sql, strCon))
    End Function
#End Region
#Region "Set Get"
    Public Sub SetField(ByVal ColumnName As String, ByVal Text As Object)
        CheckIfDisposed()
        Dim index As Integer
        For x As Integer = 0 To Me.Items.Count - 1
            If LCase(Me.Items(x).ToString) = LCase(ColumnName) Then
                index = x
                Exit For
            End If
        Next
        Me.ColEdit.Fill(index, "1")
        Me.Columns.Fill(index, Text)
    End Sub
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
    Public Function GetField(ByVal ColumnName As String) As Object
        CheckIfDisposed()
        Dim index As Integer
        For x As Integer = 0 To Me.Items.Count - 1
            If LCase(Me.Items(x).ToString) = LCase(ColumnName) Then
                index = x
                Exit For
            End If
        Next
        If Me.ColEdit(index).ToString = "1" Then
            Return Me.Columns(index).ToString
        Else
            If Me.IsNull(ColumnName) Then
                Return ""
            Else
                Return dsss.Tables(0).Rows(myRecNo).Item(index).ToString.Trim
            End If

            'If IsDBNull(dsss.Tables(0).Rows(myRecNo).Item(index)) Then
            '    'MsgBox(dsss.Tables(0).Rows(myRecNo).Item(index).GetType.ToString)
            '    Return "null"
            'Else
            '    'MsgBox(dsss.Tables(0).Rows(myRecNo).Item(index).GetType.ToString)
            '    Return dsss.Tables(0).Rows(myRecNo).Item(index).ToString.Trim
            'End If
        End If
    End Function
    Public Sub GetDateTime(ByVal ColumnName As String, ByVal Dt As DateTimePicker)
        'If Me.GetField(ColumnName) = "null" Then
        If Me.IsNull(ColumnName) Then
            Dt.Checked = False
        Else
            Dt.Checked = True
            Dt.Value = Me.GetField(ColumnName)
        End If
    End Sub
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
