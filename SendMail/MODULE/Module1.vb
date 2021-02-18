Imports System.Data.SqlClient
Imports System.Xml
Imports System.Math
Imports System.Text
Imports System.Data.SQLite
Imports System.Text.RegularExpressions
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OleDb
Module Module1
    Public m_con, m_con2 As SqlConnection
    Public strConLite, m_Sqlconn, m_ServerName, m_DBName, m_UserName, m_Password, m_Path, UsrID, UsrName, _
    m_Sqlconn2, m_ServerName2, m_DBName2, m_UserName2, m_Password2, SbuCode, Judul, GrpId, _
    so_ServerName, so_DBName, so_UserName, so_Password, m_sqlstoremkg, m_sqlstoresms, m_sqlstoresmb, _
    MyEmail, Sec_Lev, P_SMTP, P_FROM, P_PASS, P_MYEMA, masterFile, ScanFile, ExcelFile, dbSOFile, _
    m_ServerNameOLE, m_DBNameOLE, m_UserNameOLE, m_PasswordOLE, m_ServerNameOLE2, m_DBNameOLE2, m_UserNameOLE2, m_PasswordOLE2, _
    m_SqlconnPromo, m_ServerNamePromo, m_DBNamePromo, m_UserNamePromo, m_PasswordPromo, PromoTypex, PromoGrpUsr As String
    Public CCon, strSQL1, StrSQL2, StrSQL3, strSQL4 As String
    Public CServer As New OleDbConnection
    Public CCSV As New OleDbConnection
    Public bln() As String
    Public Server, DB, UID, PWS, BI, NM, BID, BNM As String
    Public Value(100), Value2(100) As String
    Public Param(100), Param2(100) As String
    Public dsForm As New DataSet
    Public conLITE As SQLiteConnection
    Public DecimalDigit, DecimalSeparator, NumberSeparator As String
    Public sqlreport As String
    Public ReportDoc As New ReportDocument
    Public dsCek As DataSet
    Public m_ServerName3, m_DBName3, m_UserName3, m_Password3 As String
    Public m_ServerName4, m_DBName4, m_UserName4, m_Password4 As String
    Public m_ServerName5, m_DBName5, m_UserName5, m_Password5 As String
    Public AtlsDay As Integer

    Public Function subgetSqldb(ByVal scmd As String) As DataSet
        Dim da As New OleDbDataAdapter
        Dim ds As New DataSet
        Dim cmd As New OleDbCommand

        Dim sqlConx As New OleDbConnection(m_Sqlconn.ToString)
        cmd.Connection = sqlConx
        cmd.CommandText = scmd
        cmd.CommandTimeout = 3000
        da.SelectCommand = cmd
        Try
            da.Fill(ds)
            da.Dispose()
            cmd.Dispose()
            da = Nothing
            cmd = Nothing
        Catch ex As Exception
            If Err.Number = 5 Then
                MsgBox("Error Pada Primary Key No Voucher, Telah ada Sebelumnya.", MsgBoxStyle.Exclamation)
            Else
                MsgBox(ex.Message, MsgBoxStyle.Information)
            End If
        End Try
        Return ds
    End Function

    Public Sub isiVariableGlobal()
        'MsgOK(Application.CurrentCulture.NumberFormat.NumberDecimalSeparator) 'separator koma
        'MsgOK(Application.CurrentCulture.NumberFormat.NumberDecimalDigits)    'berapa digit dibelakang koma
        'MsgOK(Application.CurrentCulture.NumberFormat.NumberGroupSeparator)   'separator rupiah
        DecimalDigit = Application.CurrentCulture.NumberFormat.NumberDecimalDigits
        DecimalSeparator = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
        NumberSeparator = Application.CurrentCulture.NumberFormat.NumberGroupSeparator

        FolderImage = Application.StartupPath & "\IMG\"
        FolderReport = Application.StartupPath & "\REPORT\"
        masterFile = ReadIni("so", "masterfile")
        ScanFile = ReadIni("so", "scanfile")
        ExcelFile = ReadIni("so", "excelfile")
        'FolderABSLOG = ReadIni("HRD", "foldergenerate")
    End Sub

    Public Function GetDSRecordCount(ByVal ds As DataSet) As Integer
        Return ds.Tables(0).Rows.Count
    End Function
    Public Function IsDSNull(ByVal ds As DataSet, ByVal ColumnName As String, _
                              Optional ByVal rowIndex As Integer = 0) As Boolean
        If IsDBNull(ds.Tables(0).Rows(rowIndex).Item(ColumnName).ToString.Trim) Or ds.Tables(0).Rows(0).Item(ColumnName).ToString.Trim = "" Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function getDSDate(ByVal ds1 As DataSet, ByVal rowIndex As Integer, ByVal ColumnName As String) As Date
        Return DateTime.Parse(ds1.Tables(0).Rows(rowIndex).Item(ColumnName).ToString)
    End Function
    Public Function getDSDateSQL(ByVal ds1 As DataSet, ByVal rowIndex As Integer, ByVal ColumnName As String) As String
        Return dt2sql(DateTime.Parse(ds1.Tables(0).Rows(rowIndex).Item(ColumnName).ToString))
    End Function

    Public Function getDataGridView(ByVal dg As DataGridView, ByVal Columnname As String) As String
        Dim hasil As String = ""
        Dim colIndex As Integer
        colIndex = 1000
        For x As Integer = 0 To dg.Columns.Count - 1
            If dg.Columns(x).DataPropertyName = Columnname Then
                colIndex = x
            End If
        Next
        If Not IsDBNull(dg.Item(colIndex, dg.CurrentRow.Index).Value) Then
            hasil = dg.Item(colIndex, dg.CurrentRow.Index).Value.ToString
        End If
        Return hasil
    End Function

#Region "tampillookup"
    Public Function TampilLookup(ByVal SQL As String, ByVal isi As String, _
                                 Optional ByVal MultiSelect As Boolean = True, _
                                 Optional ByVal strCon As String = "") As System.Windows.Forms.DialogResult
        Dim dstable As DataSet
        'Cursor.wait()

        dstable = Query(SQL, strCon)
        'For x = 0 To LookupForm.dg.Rows.Count - 1
        '    LookupForm.dg.Rows.RemoveAt(x)
        'Next
        'For x = 0 To LookupForm.dg.Columns.Count - 1
        '    LookupForm.dg.Columns.RemoveAt(x)
        'Next
        LookupForm.dg.DataSource = Nothing
        'LookupForm.dg.Columns.Clear()
        LookupForm.dg.Refresh()
        LookupForm.txtisi.Text = isi

        'Dbg(SQL)
        If dstable.Tables(0).Rows.Count > 0 Then
            'Dim chk As New DataGridViewCheckBoxColumn
            'LookupForm.dg.Columns.Add(chk)
            'LookupForm.dg.Columns(0).HeaderText = "Choose"
            LookupForm.dg.DataSource = dstable.Tables(0)
            LookupForm.BindingSource1.DataSource = dstable.Tables(0)
            'LookupForm.NavSource1.DataSource = dstable.Tables(0)
            LookupForm.dg.Columns(1).Visible = False
            LookupForm.dg.Columns(0).Visible = True
            If MultiSelect = False Then LookupForm.dg.Columns(0).Visible = False
            For x = 1 To LookupForm.dg.Columns.Count - 1
                LookupForm.dg.Columns(x).ReadOnly = True
            Next
            Return LookupForm.ShowDialog()
        Else
            MsgError("No Data To Choose")
            Return DialogResult.Cancel
        End If
    End Function
#End Region
    Public Function getDataGrid(ByVal dg As DataGridView, ByVal Columnname As String, _
                                Optional ByVal RowIndex As Integer = 10000) As String
        Dim hasil As String = ""
        'DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
        If RowIndex = 10000 Then RowIndex = dg.CurrentRow.Index
        Try
            If Not IsDBNull(dg.Item(Columnname, RowIndex).Value) Then
                'If Not IsDBNull(dg.Rows(dg.CurrentRow.Index).Cells(Columnname).Value) Then
                hasil = dg.Item(Columnname, RowIndex).Value.ToString.Trim
                'hasil = dg.Rows(dg.CurrentRow.Index).Cells(Columnname).Value.ToString
            End If
        Catch
            'MsgError("No Data Choose")
            Return hasil
        End Try
        Return hasil
    End Function

    Public Sub createReportTandaTerima(Optional ByVal noterima As String = " (0=0) ")
        Dim ss, s, t As String
        t = noterima
        s = ""
        'If noterima.Trim <> "(0=0)" Then
        '    t = "t.noterima='" & noterima & "' "
        'End If

        Dim ds1, ds2 As DataSet
        Dim isDirect As Integer
        isDirect = CInt(getQValue("select isdirect from t_terima t where " & t & " "))
        If isDirect = 1 Then
            ds1 = QueryToDataset("select * from t_terima_t1 t where " & t & " order by nokw ")
            s = "Kwitansi : "
            For Each ro As DataRow In ds1.Tables(0).Rows
                If ro("whsstr").ToString.Trim <> "" Then
                    s += Replace(ro("whsstr").ToString.Trim, "'", "") & " "
                End If
                s += Replace(ro("nokw").ToString.Trim, "'", "")
                If CDbl(ro("tagihan").ToString) > 0 Then
                    s += " (Rp. " & Format(CDbl(ro("tagihan").ToString), "N2") & ")"
                End If
                s += ", "
            Next
            s = Mid(s, 1, Len(s) - 2)
            's += vbCrLf
            s += ",   "

            ds1 = QueryToDataset("select distinct tipe from t_terima_t2 t where oke=1 and " & t & " order by tipe ")
            For Each rt As DataRow In ds1.Tables(0).Rows
                ds2 = QueryToDataset("select whsstr, grandtotal, nomor from t_terima_t2 t where oke=1 and " & t & " and " & vbCrLf & _
                                     "tipe='" & rt("tipe").ToString.Trim & "' order by tipe, nomor")
                s += rt("tipe").ToString.Trim & " : "
                For Each rn As DataRow In ds2.Tables(0).Rows
                    If rn("whsstr").ToString.Trim <> "" Then
                        s += Replace(rn("whsstr").ToString.Trim, "'", "") & " "
                    End If
                    s += Replace(rn("nomor").ToString.Trim, "'", "")
                    If CDbl(rn("grandtotal").ToString) > 0 Then
                        s += " (Rp. " & Format(CDbl(rn("grandtotal").ToString), "N2") & ")"
                    End If
                    s += ", "
                Next
                s = Mid(s, 1, Len(s) - 2)
                's += vbCrLf
                s += ",   "
            Next
            s = Mid(s, 1, Len(s) - 4)
        Else
            ss = ""
            s = ""
            s += "Periode " & Format(Date.Parse(getStringFromDB("select distinct periode from t_terima_c t where " & t & " ")), "MMM yyyy")
            s += " Rp. " & Format(CDbl(getStringFromDB("select totaltagihan from t_terima t where " & t & " ")), "N2")
            s += " ( "

            ds1 = QueryToDataset("select whscode from t_terima_c t where " & t & " and tagihan<>0 order by whscode")
            For Each ro As DataRow In ds1.Tables(0).Rows
                ss = ro("whscode").ToString.Trim
                ReplaceString(ss, "S001", "MKG")
                ReplaceString(ss, "S002", "SMS")
                ReplaceString(ss, "S003", "SMB")

                s += ss & " "
            Next
            s += ") " & vbCrLf
            'Replace(ss, ";", ", ")
            's +=  getStringFromDB("select distinct dokumen from t_terima_c t where " & t & " ") & " "
            s += Replace(getStringFromDB("select distinct dokumen from t_terima_c t where " & t & " "), ";", ", ") & " "


            'If GetDSRecordCount(ds1) > 0 Then
            '    s += "Periode " & Format(Date.Parse(ds1.Tables(0).Rows(0).Item("Periode").ToString), "yyyy-MM-01")
            '    s += " Rp. " & Format(CDbl(getStringFromDB("select totaltagihan from t_terima t where " & t & " ")), "N2")

            'End If

            'x = 1
            'For Each ro As DataRow In ds1.Tables(0).Rows
            '    s += Replace(ro("whsname").ToString.Trim, "'", "") & " : " & _
            '         Format(CDbl(ro("tagihan").ToString), "N2") & " ( " & _
            '         Replace(Replace(ro("dokumen").ToString.Trim, "'", ""), ";", ", ") & " ) "
            '    If x <> ds1.Tables(0).Rows.Count Then s += vbCrLf
            '    x += 1
            'Next
            s = Mid(s, 1, Len(s) - 1)
        End If

        s = "SELECT coalesce(v.cardname, '') as vendor_name, t.noterima, t.tgl, t.totaltagihan, t.serah, " & vbCrLf & _
                  "t.terima, t.istrade, t.tgl_jatuhtempo, t.sisatagihan, t.issudahbayar, t.remarks, t.isdirect, " & vbCrLf & _
                  "t.cardcode as vendor_id, t.useradded, t.dateadded, t.useredited, t.dateedited, " & vbCrLf & _
                  "" & vbCrLf & _
                  "" & vbCrLf & _
                  "" & vbCrLf & _
                  "'" & s & "' as dokumen " & vbCrLf & _
                  "into tmp_terima " & vbCrLf & _
                  "from t_terima t " & vbCrLf & _
                  "left join m_vendor v on t.cardcode=v.cardcode " & vbCrLf & _
                  "where " & t & " "
        'Dbg(s)
        ExecQuery("drop table tmp_terima")
        ExecQuery(s)
        strReport = "TANDATERIMA"
        ReportPath = "\REPORT\RptTandaTerima.rpt"
        sqlreport = "select * from tmp_terima order by noterima"
        FrmLaporan.ShowDialog()
    End Sub
    Public Sub createReportTandaTerima2(ByVal noterima As String)
        Dim t As String
        Dim dsh As DataSet

        t = noterima
        dsh = Query("select * from t_terima where noterima='" & t & "' ")
        If GetDSRecordCount(dsh) <= 0 Then
            clearDataSet(dsh)
            Exit Sub
        End If
        'MsgOK("1")
        ExecQuery("truncate table tmp_terima2")
        Dim ds1 As DataSet
        Dim ss, s, vname As String
        Dim no, isDirect As Integer
        'MsgOK("2")
        s = ""
        'isDirect = CInt(getQValue("select isdirect from t_terima t where " & t & " "))
        isDirect = dsh.Tables(0).Rows(0).Item("isdirect").ToString.Trim
        vname = getStringFromDB("select cardname from m_vendor where cardcode='" & getDSString(dsh, 0, "cardcode") & "' ")
        'MsgOK("3")
        If isDirect = 1 Then
            ds1 = QueryToDataset("select t.* from t_terima_t1 t " & vbCrLf & _
                                 "left join store s on t.whsstr=s.whsstr " & vbCrLf & _
                                 "where t.noterima='" & t & "' order by s.whscode, t.nokw ")
            no = 1
            'MsgOK("4")
            For Each ro As DataRow In ds1.Tables(0).Rows
                s = "insert into tmp_terima2 (noterima, cardcode, cardname, tgl, tipe, nokw, whsstr, " & vbCrLf & _
                          "tagihan, serah, terima, _order) values ('" & t & "', " & vbCrLf & _
                          "'" & getDSString(dsh, 0, "cardcode") & "', " & vbCrLf & _
                          "'" & vname & "', " & getDSDateSQL(dsh, 0, "tgl") & ", 'Kwitansi', " & vbCrLf & _
                          "'" & ro("nokw").ToString.Trim & "', '" & ro("whsstr").ToString.Trim & "', " & vbCrLf & _
                          "'" & ro("tagihan").ToString.Trim & "', '" & getDSString(dsh, 0, "serah") & "', " & vbCrLf & _
                          "'" & getDSString(dsh, 0, "terima") & "', '" & no & "' )"
                'Dbg(s)
                ExecQuery(s)
                no += 1

            Next
            'MsgOK("5")

            Dim nom, whs As String
            ds1 = QueryToDataset("select distinct tipe from t_terima_t2 where oke=1 and noterima='" & t & "' order by tipe ")
            For Each rt As DataRow In ds1.Tables(0).Rows
                ds2 = QueryToDataset("select t.nomor, t.whsstr from t_terima_t2 t " & vbCrLf & _
                                     "left join store s on t.whsstr=s.whsstr " & vbCrLf & _
                                     "where t.oke=1 and t.noterima='" & t & "' and " & vbCrLf & _
                                     "t.tipe='" & rt("tipe").ToString.Trim & "' order by t.tipe, s.whscode, t.nomor")
                nom = ""
                whs = ""
                For Each rn As DataRow In ds2.Tables(0).Rows
                    'MsgOK("ALL WHS : " & whs & vbCrLf & _
                    '      "WHS Str : " & Replace(rn("whsstr").ToString.Trim, "'", ""))
                    If rn("whsstr").ToString.Trim <> "" Then
                        If Not whs.Contains(Replace(rn("whsstr").ToString.Trim, "'", "")) Then
                            whs += Replace(rn("whsstr").ToString.Trim, "'", "") & ", "
                            'MsgOK("Whs Oke : " & whs)
                        End If
                    End If
                    If rn("nomor").ToString.Trim <> "" Then
                        nom += Replace(rn("nomor").ToString.Trim, "'", "") & ", "
                    End If
                Next

                If Len(nom) > 2 Then nom = Mid(nom, 1, Len(nom) - 2)
                If Len(whs) > 2 Then whs = Mid(whs, 1, Len(whs) - 2)
                s = "insert into tmp_terima2 (noterima, cardcode, cardname, tgl, tipe, nokw, whsstr, " & vbCrLf & _
                          "tagihan, serah, terima, _order) values ('" & t & "', " & vbCrLf & _
                          "'" & getDSString(dsh, 0, "cardcode") & "', " & vbCrLf & _
                          "'" & vname & "', " & getDSDateSQL(dsh, 0, "tgl") & ", '" & rt("tipe").ToString.Trim & "', " & vbCrLf & _
                          "'" & nom & "', '" & whs & "', " & vbCrLf & _
                          "'0', '" & getDSString(dsh, 0, "serah") & "', " & vbCrLf & _
                          "'" & getDSString(dsh, 0, "terima") & "', '" & no & "' )"
                'Dbg(s)
                ExecQuery(s)
                no += 1
            Next
        Else
            ss = ""
            s = ""
            s += "Periode " & Format(Date.Parse(getStringFromDB("select distinct periode from t_terima_c t where " & t & " ")), "MMM yyyy")
            s += " Rp. " & Format(CDbl(getStringFromDB("select totaltagihan from t_terima t where " & t & " ")), "N2")
            s += " ( "

            ds1 = QueryToDataset("select whscode from t_terima_c t where " & t & " and tagihan<>0 order by whscode")
            For Each ro As DataRow In ds1.Tables(0).Rows
                ss = ro("whscode").ToString.Trim
                ReplaceString(ss, "S001", "MKG")
                ReplaceString(ss, "S002", "SMS")
                ReplaceString(ss, "S003", "SMB")

                s += ss & " "
            Next
            s += ") " & vbCrLf
            'Replace(ss, ";", ", ")
            's +=  getStringFromDB("select distinct dokumen from t_terima_c t where " & t & " ") & " "
            s += Replace(getStringFromDB("select distinct dokumen from t_terima_c t where " & t & " "), ";", ", ") & " "


            'If GetDSRecordCount(ds1) > 0 Then
            '    s += "Periode " & Format(Date.Parse(ds1.Tables(0).Rows(0).Item("Periode").ToString), "yyyy-MM-01")
            '    s += " Rp. " & Format(CDbl(getStringFromDB("select totaltagihan from t_terima t where " & t & " ")), "N2")

            'End If

            'x = 1
            'For Each ro As DataRow In ds1.Tables(0).Rows
            '    s += Replace(ro("whsname").ToString.Trim, "'", "") & " : " & _
            '         Format(CDbl(ro("tagihan").ToString), "N2") & " ( " & _
            '         Replace(Replace(ro("dokumen").ToString.Trim, "'", ""), ";", ", ") & " ) "
            '    If x <> ds1.Tables(0).Rows.Count Then s += vbCrLf
            '    x += 1
            'Next
            s = Mid(s, 1, Len(s) - 1)
        End If

        strReport = "TANDATERIMA2"
        ReportPath = "\REPORT\RptTandaTerima2.rpt"
        sqlreport = "select * from tmp_terima2 order by noterima, _order"
        MsgOK("finished")
        'FrmLaporan.ShowDialog()
    End Sub
    Public Sub getDataGridViewDate(ByVal dg As DataGridView, ByVal ColumnName As String, ByRef dt As DateTimePicker)
        dt.Checked = False
        If Not IsDBNull(dg.Item(ColumnName, dg.CurrentRow.Index).Value) Then
            'If Not IsDBNull(dg.Rows(dg.CurrentRow.Index).Cells(ColumnName).Value) Then
            dt.Checked = True
            dt.Value = dg.Item(ColumnName, dg.CurrentRow.Index).Value
            'dt.Value = dg.Rows(dg.CurrentRow.Index).Cells(ColumnName).Value
        End If
    End Sub

    Public Sub ShowReport(ByVal ReportName As String, ByVal ReportFile As String, ByVal ReportSQL As String)
        strReport = ReportName
        ReportPath = ReportFile
        sqlreport = ReportSQL
        FrmLaporan.ShowDialog()
    End Sub

    Public Function getDataGridViewCheckbox(ByVal dg As DataGridView, ByVal ColumnName As String) As Boolean
        Dim hasil As Boolean = False
        If Not IsDBNull(dg.Item(ColumnName, dg.CurrentRow.Index).Value) Then
            If CBool(dg.Item(ColumnName, dg.CurrentRow.Index).Value) Then hasil = True
        End If
        Return hasil
    End Function

    Public Function Query(ByVal SQL As String, Optional ByVal strCon As String = "") As DataSet
        Return QueryToDataset(SQL, strCon)
    End Function

    Public Sub ReplaceString(ByRef Str As String, ByVal OldString As String, ByVal NewString As String)
        'If IsDBNull(NewString) Then NewString = ""
        Str = Regex.Replace(Str, OldString, NewString, RegexOptions.IgnoreCase)
    End Sub
    Public Function date2sql(ByVal dt As DateTimePicker) As String
        Return "'" & Format(dt.Value, "yyyy-MM-dd") & "'"
    End Function
    Public Function dt2sql(ByVal dt As Date) As String
        Return "'" & Format(dt, "yyyy-MM-dd") & "'"
    End Function
    Public Function datetime2sql(ByVal dt As DateTimePicker) As String
        Return "'" & Format(dt.Value, "yyyy-MM-dd hh:mm:ss") & "'"
    End Function
    Public Sub isiComboFromString(ByVal cmb As ComboBox, ByVal Str As String, ByVal strSplit As String)
        Dim x As Integer
        Dim s() As String = SplitWords(Str, strSplit)
        Dim c As New ArrayList
        c.Add(New CCombo("", ""))
        For x = 0 To s.Count - 1
            If s(x).ToString.Trim <> "" Then
                c.Add(New CCombo(s(x), s(x)))
            End If
        Next
        With cmb
            .DataSource = c
            .DisplayMember = "Number_Name"
            .ValueMember = "ID"
        End With
    End Sub
    Public Sub isiComboFromArray(ByVal cmb As ComboBox, ByVal isi() As String, ByVal totalArray As Integer)
        Dim x As Integer
        Dim c As New ArrayList
        c.Add(New CCombo("", ""))
        For x = 0 To totalArray
            If isi(x).ToString.Trim <> "" Then
                c.Add(New CCombo(isi(x), isi(x)))
            End If
        Next
        With cmb
            .DataSource = c
            .DisplayMember = "Number_Name"
            .ValueMember = "ID"
        End With
    End Sub

    Public Function getStringFromDB(ByVal Query As String, Optional ByVal strcon As String = "") As String
        Dim dss As DataSet
        Dim hasil As String = ""
        strcon = strCon_Global
        If strcon.Trim = "" Then strcon = StrConSUP()
        dss = QueryToDataset(Query, strcon)
        If dss.Tables(0).Rows.Count Then
            If Not IsDBNull(dss.Tables(0).Rows(0).Item(0)) Then
                hasil = dss.Tables(0).Rows(0).Item(0).ToString.Trim
            End If
        End If
        clearDataSet(dss)
        Return hasil
    End Function

    Public Sub clearDataSet(ByVal ds As DataSet)
        ds.Clear() : ds.Dispose() : ds = Nothing
    End Sub
    Public Function getRecordCount(ByVal SQL As String) As Integer
        Dim ds1 As DataSet
        Dim hasil As Integer
        hasil = 0
        'MsgBox(SQL)
        ds1 = getSqldb(SQL)
        If ds1.Tables(0).Rows.Count > 0 Then
            hasil = ds1.Tables(0).Rows.Count
        End If
        ds1.Clear()
        ds1.Dispose()
        Return hasil
    End Function
    Public Function getQValue(ByVal SQL As String) As String
        Dim dsq As DataSet
        Dim hasil As String = ""
        dsq = QueryToDataset(SQL)
        If dsq.Tables(0).Rows.Count > 0 Then
            If Not IsDBNull(dsq.Tables(0).Rows(0).Item(0).ToString.Trim) Then
                hasil = dsq.Tables(0).Rows(0).Item(0).ToString.Trim
            End If
        End If
        dsq.Dispose()
        Return hasil
    End Function
    Public Function getDoubleFromDB(ByVal Query As String, Optional ByVal strcon As String = "") As Double
        Dim dss As DataSet
        Dim hasil As Double = 0
        dss = QueryToDataset(Query, strcon)
        If dss.Tables(0).Rows.Count Then
            If Not IsDBNull(dss.Tables(0).Rows(0).Item(0)) Then
                hasil = CDbl(dss.Tables(0).Rows(0).Item(0).ToString.Trim)
            End If
        End If
        clearDataSet(dss)
        Return hasil
    End Function

    Public Sub isiComboFromSQL(ByVal cmb As ComboBox, ByVal SQL As String, ByVal colID As String, ByVal colName As String)
        Dim dsc As DataSet
        Dim x As Integer
        Dim c As New ArrayList
        c.Add(New CCombo("", ""))
        dsc = QueryToDataset(SQL)
        x = 0
        While x <= dsc.Tables(0).Rows.Count - 1
            c.Add(New CCombo(dsc.Tables(0).Rows(x).Item(colID).ToString, dsc.Tables(0).Rows(x).Item(colName).ToString))
            x = x + 1
        End While
        'cmb.Items.Clear()
        With cmb
            .DataSource = c
            .DisplayMember = "Number_Name"
            .ValueMember = "ID"
        End With
    End Sub
    Public sp_DBServer, sp_DBName, sp_DBUser, sp_DBPass, _
          sa_DBServer, sa_DBName, sa_DBUser, sa_DBPass, _
          hr_DBServer, hr_DBName, hr_DBUser, hr_DBPass, _
          aplikasiName, UserLogin, PassLogin, DayTHN, MntExp, Whs, _
          FolderImage, FolderReport As String
    Public Sub MsgOK(ByVal Pesan As String)
        MsgBox(Pesan, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "STAR System")
    End Sub

    Public Sub BacaIniFile()
        sp_DBServer = ReadIni("localdb2", "dbserver")
        sp_DBName = ReadIni("localdb2", "dbname")
        sp_DBUser = ReadIni("localdb2", "dbuser")
        sp_DBPass = Decrypt(ReadIni("localdb2", "dbpaswd"))

        sa_DBServer = ReadIni("localdb", "dbserver")
        sa_DBName = ReadIni("localdb", "dbname")
        sa_DBUser = ReadIni("localdb", "dbuser")
        sa_DBPass = Decrypt(ReadIni("localdb", "dbpaswd"))

        hr_DBServer = ReadIni("HRD", "ServerName")
        hr_DBName = ReadIni("HRD", "DatabaseName")
        hr_DBUser = ReadIni("HRD", "LoginID")
        hr_DBPass = Decrypt(ReadIni("HRD", "Password"))
    End Sub

    Public Function StrConSAP() As String
        BacaIniFile()
        Dim hasil As String
        hasil = "Data Source=" & sa_DBServer & ";" & "Initial Catalog=" & sa_DBName & ";" & "User ID=" & sa_DBUser & ";" & "Password=" & sa_DBPass & ";"
        Return hasil
    End Function
    Public Function StrConSUP() As String
        BacaIniFile()
        Dim hasil As String
        hasil = "Data Source=" & sp_DBServer & ";" & "Initial Catalog=" & sp_DBName & ";" & "User ID=" & sp_DBUser & ";" & "Password=" & sp_DBPass & ";"
        Return hasil
    End Function
    Public Function StrConHRD() As String
        BacaIniFile()
        Dim hasil As String
        hasil = "Data Source=" & hr_DBServer & ";" & "Initial Catalog=" & hr_DBName & ";" & "User ID=" & hr_DBUser & ";" & "Password=" & hr_DBPass & ";"
        Return hasil
    End Function

    Public Function QueryToDataset(ByVal SQL As String, Optional ByVal strCon As String = "") As DataSet
        'ConnectServer()
        'm_Sqlconn = "Data Source=" & m_ServerName & ";" & "Initial Catalog=" & m_DBName & ";" & "User ID=" & m_UserName & ";" & "Password=" & m_Password & ";"
        'If strCon.Trim = "" Then
        '    strCon = m_Sqlconn
        '    'm_con = New SqlConnection(m_Sqlconn)
        'Else
        '    strCon = strCon
        '    'm_con = New SqlConnection(strCon)
        'End If
        ''MsgOK(strCon)
        strCon = strCon_Global
        If strCon.Trim = "" Then strCon = StrConSUP()

        m_con = New SqlConnection(strCon)

        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim cmd As New SqlCommand

        cmd = m_con.CreateCommand
        cmd.CommandText = SQL
        cmd.CommandTimeout = 120
        da.SelectCommand = cmd
        If m_con.State = ConnectionState.Open Then
            m_con.Close()
        End If
        m_con.Open()
1:
        Try
            da.Fill(ds)
        Catch ex As Exception
            'GoTo 1
            MsgBox(ex.Message)
        End Try

        m_con.Close()
        Return ds
    End Function

    Public Sub createColumnGrid(ByVal dgv As DataGridView, ByVal colName() As String, ByVal colHeader() As String, _
                                ByVal colVisible() As Boolean, ByVal totalColumn As Integer, _
                                Optional ByVal colWidth() As Integer = Nothing, _
                                Optional ByVal colType As String = "")

        Dim colx As String()
        colx = Split(getValueFromString("checkbox", colType), ",")

        With dgv
            'MsgOK(totalColumn)
            Dim txtCol(totalColumn - 1) As DataGridViewColumn
            Dim x As Integer
            Dim sudah As Boolean
            For x = 0 To totalColumn - 1
                sudah = False
                If colx.Length > 0 Then
                    'Dim txtColx(colx.Length) As DataGridViewComboBoxColumn
                    For Each word As String In colx
                        word = word.Trim.ToLower
                        If word <> "" Then
                            If x = CInt(word) Then
                                sudah = True
                                txtCol(x) = New DataGridViewColumn
                                txtCol(x).CellTemplate = New DataGridViewCheckBoxCell
                            End If
                        End If
                    Next
                End If

                If sudah = False Then
                    txtCol(x) = New DataGridViewColumn
                    txtCol(x).CellTemplate = New DataGridViewTextBoxCell
                End If


                txtCol(x).HeaderText = colHeader(x)
                txtCol(x).Name = colName(x)
                txtCol(x).DataPropertyName = colName(x)
                txtCol(x).Visible = colVisible(x)
                txtCol(x).Width = colWidth(x)
                'MsgOK("Header Text : " & txtCol(x).HeaderText & vbCrLf & _
                '      "name : " & txtCol(x).Name & vbCrLf & _
                '      "property : " & txtCol(x).DataPropertyName & vbCrLf & _
                '      "visible : " & txtCol(x).Visible.ToString)
                txtCol(x).SortMode = DataGridViewColumnSortMode.Automatic
                .Columns.Add(txtCol(x))
            Next
        End With
    End Sub

    Public Sub SimpanData(ByVal SQLSelect As String, ByVal SQLUpdate As String, ByVal SQLInsert As String, _
                          Optional ByVal IsMsg As Boolean = False)
        Dim ds As DataSet
        ds = QueryToDataset(SQLSelect)
        If ds.Tables(0).Rows.Count > 0 Then
            ExecQuery(SQLUpdate)
            If IsMsg Then MsgOK("Data Telah Diupdate")
        Else
            ExecQuery(SQLInsert)
            If IsMsg Then MsgOK("Data Telah Ditambah")
        End If
        clearDataSet(ds)
    End Sub

    Public Function SplitWords(ByVal teks As String, ByVal splitChar As String) As String()
        Return Regex.Split(teks, splitChar)
    End Function
    Public Function FNumberClear(ByVal Txt As Object) As String
        Txt.text = Replace(Txt.Text, NumberSeparator, "")
        Return Txt.text
    End Function
    Public Sub FNumber(ByVal Txt As Object, Optional ByVal DigitDecimal As Integer = 2)
        If IsNumeric(Txt.Text) Then
            Dim temp As Double = Txt.Text
            Txt.Text = Format(temp, "N" & DigitDecimal)
            Txt.SelectionStart = Txt.TextLength - 3
        End If
    End Sub
    Public Sub onlyNumber(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) <> 8 And Asc(e.KeyChar) <> Asc(DecimalSeparator) Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Public Sub FormatColumnGrid(ByVal dg As DataGridView, ByVal colIndex As Integer, ByVal Tipe As String, _
                                Optional ByVal desimal As Integer = 0)
        Tipe = LCase(Tipe)
        If Tipe = "number" Then
            dg.Columns(colIndex).DefaultCellStyle.Format = "n" & CStr(desimal)
            dg.Columns(colIndex).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        ElseIf Tipe = "date" Then
            dg.Columns(colIndex).DefaultCellStyle.Format = "dd MMM yyyy"
            dg.Columns(colIndex).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
    End Sub
    Public Sub FormatColumnGridClear(ByVal dg As DataGridView, ByVal colIndex As Integer)
        dg.Columns(colIndex).DefaultCellStyle.Format = ""
    End Sub

    Public Sub ExecLITE(ByVal Query As String, Optional ByVal strCon As String = "")
        'Exit Sub
        'strConLite = strConLite & "dbSO.db"
        If strCon = "" Then strCon = strConLite
        conLITE = New SQLiteConnection(strCon)
        Dim cmd As New SQLiteCommand
        cmd = conLITE.CreateCommand
        cmd.CommandText = Query
        cmd.CommandTimeout = 240
        If conLITE.State = 1 Then conLITE.Close()
        Try
            conLITE.Open()
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            MsgError(ex.Message)
        End Try
        conLITE.Close()
    End Sub

    Public Sub ExecSAP(ByVal Query As String)
        Dim strCon As String = ""
        ConnectServer()
        m_Sqlconn = "Data Source=" & m_ServerName & ";" & "Initial Catalog=" & m_DBName & ";" & "User ID=" & m_UserName & ";" & "Password=" & m_Password & ";"
        m_Sqlconn2 = "Data Source=" & m_ServerName2 & ";" & "Initial Catalog=" & m_DBName2 & ";" & "User ID=" & m_UserName2 & ";" & "Password=" & m_Password2 & ";"
        strCon = m_Sqlconn

        m_con = New SqlConnection(strCon)
        Dim cmd As New SqlCommand
        cmd = m_con.CreateCommand
        cmd.CommandText = Query
        cmd.CommandTimeout = 240
        If m_con.State = 1 Then m_con.Close()
        '1:
        Try
            m_con.Open()
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            'GoTo 1
            MsgError(ex.Message)
            Application.Exit()
        End Try
        m_con.Close()
    End Sub

    Public Function MsgConfirm(ByVal pesan As String) As Integer
        Return MsgBox(pesan, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm")
    End Function
    Public Sub Dbg(ByVal pesan As String)
        'Exit Sub
        FrmPesan.txtPesan.Text = pesan
        FrmPesan.ShowDialog()
    End Sub

    Public Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Public Function getValueFromString(ByVal ValueName As String, ByVal properties As String) As String
        Dim hasil As String = ""
        Dim words As String() = Split(properties, ";")
        Dim arr() As String
        For Each word As String In words
            arr = Split(word, "=")
            If arr.Count >= 1 Then
                If LCase(arr(0).ToString.Trim) = LCase(ValueName) Then
                    hasil = arr(1).ToString.Trim
                End If
            End If
        Next
        Return hasil

    End Function

    Public Sub MsgError(ByVal Pesan As String)
        MsgBox(Pesan, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "STAR System")
    End Sub

    Public Function QuerySAP(ByVal Query As String) As System.Data.DataSet
        Dim strCon As String = ""
        ConnectServer()
        m_Sqlconn = "Data Source=" & m_ServerName & ";" & "Initial Catalog=" & m_DBName & ";" & "User ID=" & m_UserName & ";" & "Password=" & m_Password & ";"
        m_Sqlconn2 = "Data Source=" & m_ServerName2 & ";" & "Initial Catalog=" & m_DBName2 & ";" & "User ID=" & m_UserName2 & ";" & "Password=" & m_Password2 & ";"

        strCon = m_Sqlconn
        m_con = New SqlConnection(strCon)
        Dim da As New SqlDataAdapter
        Dim ds As New System.Data.DataSet
        Dim cmd As New SqlCommand
        cmd = m_con.CreateCommand
        cmd.CommandText = Query
        cmd.CommandTimeout = 240
        da.SelectCommand = cmd
        If m_con.State = 1 Then m_con.Close()
        '1:
        Try
            m_con.Open()
            da.Fill(ds)
        Catch ex As Exception
            'GoTo 1
            MsgError(ex.Message)
            Application.Exit()
        End Try
        m_con.Close()
        Return ds
    End Function

    Public Function QuerySO(ByVal Query As String) As System.Data.DataSet
        Dim strCon As String = ""
        ConnectServer()
        m_Sqlconn = "Data Source=" & so_ServerName & ";" & "Initial Catalog=" & so_DBName & ";" & "User ID=" & so_UserName & ";" & "Password=" & so_Password & ";"
        strCon = m_Sqlconn

        m_con2 = New SqlConnection(strCon)
        Dim da As New SqlDataAdapter
        Dim ds As New System.Data.DataSet
        Dim cmd As New SqlCommand
        cmd = m_con2.CreateCommand
        cmd.CommandText = Query
        cmd.CommandTimeout = 240
        da.SelectCommand = cmd
        If m_con2.State = 1 Then m_con2.Close()
        '1:
        Try
            m_con2.Open()
            da.Fill(ds)
        Catch ex As Exception
            'GoTo 1
            MsgError(ex.Message)
            Application.Exit()
        End Try
        m_con2.Close()
        Return ds
    End Function

    Public Sub ExecSO(ByVal Query As String)
        Dim strCon As String = ""
        ConnectServer()
        m_Sqlconn = "Data Source=" & so_ServerName & ";" & "Initial Catalog=" & so_DBName & ";" & "User ID=" & so_UserName & ";" & "Password=" & so_Password & ";"
        strCon = m_Sqlconn

        m_con2 = New SqlConnection(strCon)
        Dim cmd As New SqlCommand
        cmd = m_con2.CreateCommand
        cmd.CommandText = Query
        cmd.CommandTimeout = 240
        If m_con2.State = 1 Then m_con2.Close()
        '1:
        Try
            m_con2.Open()
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            'GoTo 1
            MsgError(ex.Message)
            Application.Exit()
        End Try
        m_con2.Close()
    End Sub


    Public Function getSqldbOLE(ByVal scmd As String) As DataTable
        Try
            Dim sqlConx As New OleDbConnection(m_Sqlconn.ToString)
            Dim sqlDA As New OleDbDataAdapter(scmd, sqlConx)
            Dim sqlCB As New OleDbCommandBuilder(sqlDA)
            sqlDT.Reset()
            sqlDA.Fill(sqlDT)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
        Return sqlDT
    End Function

    Public Function getSqldbOLE2(ByVal scmd As String) As DataTable
        Try

            Dim sqlConx As New OleDbConnection(m_Sqlconn2.ToString)
            Dim sqlDA As New OleDbDataAdapter(scmd, sqlConx)
            Dim sqlCB As New OleDbCommandBuilder(sqlDA)
            sqlDT.Reset()
            sqlDA.Fill(sqlDT)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
        Return sqlDT
    End Function

    Public Function getSqldb(ByVal scmd As String) As DataSet
        m_con = New SqlConnection(m_Sqlconn)
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim cmd As New SqlCommand

        cmd = m_con.CreateCommand
        cmd.CommandText = scmd

        da.SelectCommand = cmd
        If m_con.State = ConnectionState.Open Then
            m_con.Close()
        End If
        m_con.Open()
        cmd.CommandTimeout = 120
        da.Fill(ds)
        m_con.Close()
        Return ds
    End Function

    Public Function getSqldbPromo(ByVal scmd As String) As DataSet
        m_con = New SqlConnection(m_SqlconnPromo)
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim cmd As New SqlCommand

        cmd = m_con.CreateCommand
        cmd.CommandText = scmd

        da.SelectCommand = cmd
        If m_con.State = ConnectionState.Open Then
            m_con.Close()
        End If
        m_con.Open()
        cmd.CommandTimeout = 360
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        m_con.Close()
        Return ds
    End Function

    Public Function getSqldb2(ByVal scmd As String) As DataSet
        m_con2 = New SqlConnection(m_Sqlconn2)
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim cmd As New SqlCommand

        cmd = m_con2.CreateCommand
        cmd.CommandText = scmd

        da.SelectCommand = cmd
        If m_con2.State = ConnectionState.Open Then
            m_con2.Close()
        End If
        m_con2.Open()
        cmd.CommandTimeout = 120
        da.Fill(ds)
        m_con2.Close()
        Return ds
    End Function


    Public Function Encrypt(ByVal data)
        Dim i, Key, RdmKey, PjgData As Integer
        Dim TempStr, RdmStr As String
        TempStr = ""
        RdmStr = ""
        'Key = 888
        For i = 1 To Len(data)
            TempStr = TempStr + Chr(Asc(Mid(data, i, 1)) + (Round(Sin(Key ^ 2 + i), 1) * 10 + Round(234 / 3, 0)))
        Next
        Randomize()
        RdmKey = Fix(8 * Rnd()) + 1 + 64
        PjgData = Len(data) + RdmKey
        RdmStr = RandomKey(150 - PjgData)
        Encrypt = Chr(PjgData) + Chr(RdmKey) + TempStr + RdmStr
    End Function

    'Public Function getSqldb3(ByVal scmd As String) As DataSet
    '    m_con3 = New SqlConnection(m_Sqlconn3)
    '    Dim da As New SqlDataAdapter
    '    Dim ds As New DataSet
    '    Dim cmd As New SqlCommand

    '    cmd = m_con3.CreateCommand
    '    cmd.CommandText = scmd

    '    da.SelectCommand = cmd
    '    If m_con3.State = ConnectionState.Open Then
    '        m_con3.Close()
    '    End If
    '    m_con3.Open()
    '    da.Fill(ds)
    '    m_con3.Close()
    '    Return ds
    'End Function

    Public Sub ConnectServer()
        m_ServerName = ReadIni("localdb", "dbserver")
        m_DBName = ReadIni("localdb", "dbname")
        m_UserName = ReadIni("localdb", "dbuser")
        m_Password = Decrypt(ReadIni("localdb", "dbpaswd"))
        m_ServerName2 = ReadIni("localdb2", "dbserver")
        m_DBName2 = ReadIni("localdb2", "dbname")
        m_UserName2 = ReadIni("localdb2", "dbuser")
        m_Password2 = Decrypt(ReadIni("localdb2", "dbpaswd"))

        so_ServerName = ReadIni("so", "dbserver")
        so_DBName = ReadIni("so", "dbname")
        so_UserName = ReadIni("so", "dbuser")
        so_Password = Decrypt(ReadIni("so", "dbpaswd"))
        dbSOFile = ReadIni("so", "pathdbso")
        strConLite = "Data Source=" & dbSOFile & ";Version=3;"
        'm_ServerName3 = ReadIni("localdb3", "dbserver")
        'm_DBName3 = ReadIni("localdb3", "dbname")
        'm_UserName3 = ReadIni("localdb3", "dbuser")
        'm_Password3 = Decrypt(ReadIni("localdb3", "dbpaswd"))
        m_Path = ReadIni("Path", "pathpdf")
        Judul = ReadIni("Text", "Judul")

        m_ServerNameOLE = ReadIni("DBSVR1", "ServerName")
        m_DBNameOLE = ReadIni("DBSVR1", "DatabaseName")
        m_UserNameOLE = ReadIni("DBSVR1", "LoginID")
        m_PasswordOLE = Decrypt(ReadIni("DBSVR1", "Password"))

        m_ServerNameOLE2 = ReadIni("DBSVR2", "ServerName")
        m_DBNameOLE2 = ReadIni("DBSVR2", "DatabaseName")
        m_UserNameOLE2 = ReadIni("DBSVR2", "LoginID")
        m_PasswordOLE2 = Decrypt(ReadIni("DBSVR2", "Password"))

        m_ServerName3 = ReadIni("DBSVRSTORE1", "ServerName")
        m_DBName3 = ReadIni("DBSVRSTORE1", "DatabaseName")
        m_UserName3 = ReadIni("DBSVRSTORE1", "LoginID")
        m_Password3 = Decrypt(ReadIni("DBSVRSTORE1", "Password"))

        m_ServerName4 = ReadIni("DBSVRSTORE2", "ServerName")
        m_DBName4 = ReadIni("DBSVRSTORE2", "DatabaseName")
        m_UserName4 = ReadIni("DBSVRSTORE2", "LoginID")
        m_Password4 = Decrypt(ReadIni("DBSVRSTORE2", "Password"))

        m_ServerName5 = ReadIni("DBSVRSTORE3", "ServerName")
        m_DBName5 = ReadIni("DBSVRSTORE3", "DatabaseName")
        m_UserName5 = ReadIni("DBSVRSTORE3", "LoginID")
        m_Password5 = Decrypt(ReadIni("DBSVRSTORE3", "Password"))

        m_ServerNamePromo = ReadIni("DBPROMO", "dbserver")
        m_DBNamePromo = ReadIni("DBPROMO", "dbname")
        m_UserNamePromo = ReadIni("DBPROMO", "dbuser")
        m_PasswordPromo = Decrypt(ReadIni("DBPROMO", "dbpaswd"))
        AtlsDay = ReadIni("DBPROMO", "AtLastDay")
    End Sub

    Public Function ReadIni(ByVal xTipe As String, ByVal xName As String, _
                            Optional ByVal fn As String = "") As String
        If fn.Trim = "" Then fn = Application.StartupPath & "\Config.ini"
        Dim res As Integer
        Dim sb As StringBuilder
        sb = New StringBuilder(500)
        res = GetPrivateProfileString(xTipe, xName, "", sb, sb.Capacity, fn)
        'res = GetPrivateProfileString(xTipe, xName, "", sb, sb.Capacity, "C:\Program Files\Berca\Config.ini")
        ReadIni = sb.ToString()
    End Function
    Public Function ReadInix(ByVal xTipe As String, ByVal xName As String) As String
        Dim res As Integer
        Dim sb As StringBuilder
        sb = New StringBuilder(500)
        res = GetPrivateProfileString(xTipe, xName, "", sb, sb.Capacity, Application.StartupPath & "\Config.ini")
        'res = GetPrivateProfileString(xTipe, xName, "", sb, sb.Capacity, "C:\Program Files\Berca\Config.ini")
        ReadInix = sb.ToString()
    End Function

    Public Function Decrypt(ByVal data)
        Dim i, Key, RdmKey, PjgData As Integer
        Dim TempStr, TempData As String
        TempStr = ""
        RdmKey = Asc(Mid(data, 2, 1)) - 64
        PjgData = Asc(Left(data, 1)) - (RdmKey + 64)
        TempData = Mid(data, 3, PjgData)
        For i = 1 To PjgData
            TempStr = TempStr + Chr(Asc(Mid(TempData, i, 1)) - (Round(Sin(Key ^ 2 + i), 1) * 10 + Round(234 / 3, 0)))
        Next
        Decrypt = TempStr
    End Function


    Private Function RandomKey(ByVal JumKey)
        Dim i As Integer
        Dim Temp, tblkey As String
        Temp = ""
        tblkey = "Çüéåçêèï@#$%!&*ÄÉæÆôûÿÖ¢Ü£¥PƒáíúñÑªº¿"
        For i = 1 To JumKey
            Randomize()
            Temp = Temp + Mid$(tblkey, Fix(91 * Rnd()) + 1, 1)
        Next
        RandomKey = Temp
    End Function


    Public Function SelProc(ByVal StoreName As String, ByVal Count As Integer) As DataSet
        m_con = New SqlConnection(m_Sqlconn)
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim cmd As New SqlCommand
        cmd = m_con.CreateCommand
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = StoreName
        For x As Integer = 1 To Count
            'cmd.Parameters.Add(Param(x), CType(SetSqlType(x), SqlDbType)).Value = Value(x)
            cmd.Parameters.AddWithValue(Param(x), Value(x))
        Next

        da.SelectCommand = cmd
        If m_con.State = ConnectionState.Open Then
            m_con.Close()
        End If
        m_con.Open()
        cmd.CommandTimeout = 120
        da.Fill(ds)
        m_con.Close()
        Return ds
    End Function

    Public Function cmb(ByVal ccmb As ComboBox, ByVal sql As String, ByVal UsrID As String, ByVal mName As String, ByVal cek As Integer)
        Dim c As New ArrayList
        m_con = New SqlConnection(m_Sqlconn)
        Try
            Dim strsql As String
            strsql = sql

            If m_con.State = ConnectionState.Closed Then m_con.Open()
            Dim cmd2 As New SqlCommand(strsql, m_con)

            Dim objreader2 As SqlDataReader = cmd2.ExecuteReader()
            If cek = 1 Then
            Else
                c.Add(New CCombo("*", "***ALL***"))
            End If
            Do While objreader2.Read()
                c.Add(New CCombo(objreader2(UsrID), objreader2(mName).ToString))
                'cmbPTKPID.Items.Add(objreader2("ID"))
            Loop
            m_con.Close()
            With ccmb
                .DataSource = c
                .DisplayMember = "Number_Name"
                .ValueMember = "ID"
            End With

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        Return ccmb
    End Function


    Public Function cmbPromo(ByVal ccmb As ComboBox, ByVal sql As String, ByVal UsrID As String, ByVal mName As String, ByVal cek As Integer)
        Dim c As New ArrayList
        m_con = New SqlConnection(m_SqlconnPromo)
        Try
            Dim strsql As String
            strsql = sql

            If m_con.State = ConnectionState.Closed Then m_con.Open()
            Dim cmd2 As New SqlCommand(strsql, m_con)

            Dim objreader2 As SqlDataReader = cmd2.ExecuteReader()
            If cek = 1 Then
            Else
                c.Add(New CCombo("*", "***ALL***"))
            End If
            Do While objreader2.Read()
                c.Add(New CCombo(objreader2(UsrID), objreader2(UsrID).ToString & ". " & objreader2(mName).ToString))
                'cmbPTKPID.Items.Add(objreader2("ID"))
            Loop
            m_con.Close()
            With ccmb
                .DataSource = c
                .DisplayMember = "Number_Name"
                .ValueMember = "ID"
            End With

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        Return ccmb
    End Function

    Public Function cmbBank(ByVal ccmb As ComboBox, ByVal sql As String, ByVal UsrID As String, ByVal mName As String, ByVal cek As Integer)
        Dim c As New ArrayList
        m_con = New SqlConnection(m_SqlconnPromo)
        Try
            Dim strsql As String
            strsql = sql

            If m_con.State = ConnectionState.Closed Then m_con.Open()
            Dim cmd2 As New SqlCommand(strsql, m_con)

            Dim objreader2 As SqlDataReader = cmd2.ExecuteReader()
            If cek = 1 Then
            Else
                c.Add(New CCombo("*", "***ALL***"))
            End If
            Do While objreader2.Read()
                c.Add(New CCombo(objreader2(UsrID), objreader2(mName).ToString))
                'cmbPTKPID.Items.Add(objreader2("ID"))
            Loop
            m_con.Close()
            With ccmb
                .DataSource = c
                .DisplayMember = "Number_Name"
                .ValueMember = "ID"
            End With

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        Return ccmb
    End Function
    Public Function newTerimaNumber(Optional ByVal code As String = "TR", _
                                    Optional ByVal col As String = "noterima", _
                                    Optional ByVal tb As String = "t_terima") As String
        Dim dsn As DataSet
        Dim kode, branch, hasil As String
        hasil = ""
        'TRH001-18052016-0001
        branch = ReadIni("localdb2", "whs")
        kode = "00001"
        dsn = QueryToDataset("select max(" & col & ") as nomor from " & tb & " " & vbCrLf & _
                       "where substring(" & col & ", 3, 4) = '" & branch & "' and " & vbCrLf & _
                       "substring(" & col & ", 8, 6) = '" & Format(Now, "MMyyyy") & "' ")
        If dsn.Tables(0).Rows.Count > 0 Then
            If Not IsDBNull(dsn.Tables(0).Rows(0).Item("nomor")) Then
                kode = Microsoft.VisualBasic.Right(dsn.Tables(0).Rows(0).Item("nomor"), 5)
                kode = CStr(CInt(kode) + 1)
                kode = Format(CInt(kode), "00000")
            End If
        End If
        dsn.Dispose()
        hasil = code + branch + "-" + Format(Now, "MMyyyy") + "-" + kode
        Return hasil
    End Function
    Public Function cmb2(ByVal ccmb As ComboBox, ByVal sql As String, ByVal UsrID As String, ByVal mName As String, ByVal cek As Integer)
        Dim c As New ArrayList
        m_con2 = New SqlConnection(m_Sqlconn2)
        Try
            Dim strsql As String
            strsql = sql

            If m_con2.State = ConnectionState.Closed Then m_con2.Open()
            Dim cmd2 As New SqlCommand(strsql, m_con2)

            Dim objreader2 As SqlDataReader = cmd2.ExecuteReader()
            If cek = 1 Then
            Else
                c.Add(New CCombo("*", "***ALL***"))
            End If

            Do While objreader2.Read()
                c.Add(New CCombo(objreader2(UsrID), objreader2(mName).ToString))
                'cmbPTKPID.Items.Add(objreader2("ID"))
            Loop
        

            m_con2.Close()
            With ccmb
                Try
                    .DataSource = c
                    .DisplayMember = "Number_Name"
                    .ValueMember = "ID"
                Catch ex As Exception

                End Try

            End With

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        Return ccmb
    End Function

    Private Declare Auto Function GetPrivateProfileString Lib "kernel32" (ByVal lpAppName As String, _
             ByVal lpKeyName As String, _
             ByVal lpDefault As String, _
             ByVal lpReturnedString As StringBuilder, _
             ByVal nSize As Integer, _
             ByVal lpFileName As String) As Integer


End Module
