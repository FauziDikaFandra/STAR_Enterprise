Imports System.Data.SqlClient
Imports System.Data.SQLite
Module MdAdi

    Public strCon_Global, DB_POS, DB_POSH, DB_SAP, DB_ABS As String
    Public isiTglBayar As Boolean = False
    Public BarcodeID As String

    Public Function LeftStr(ByVal text As String, ByVal length As Integer) As String
        Return Microsoft.VisualBasic.Left(text, length)
    End Function
    Public Function RightStr(ByVal text As String, ByVal length As Integer) As String
        Return Microsoft.VisualBasic.Right(text, length)
    End Function
    Public Function MidStr(ByVal text As String, ByVal start As Integer, ByVal length As Integer) As String
        Return Microsoft.VisualBasic.Mid(text, start, length)
    End Function
    Public Function QueryToDataset2(ByVal SQL As String, Optional ByVal strCon As String = "") As DataSet
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
        Dim m_con As SqlConnection
        If strCon.Trim = "" Then strCon = strCon_Global

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
    Public Function QueryLITE(ByVal Query As String, Optional ByVal strCon As String = "")
        If strCon = "" Then strCon = strConLite
        'MsgOK(strCon)
        conLITE = New SQLiteConnection(strCon)
        Dim da As New SQLiteDataAdapter
        Dim dss As New System.Data.DataSet
        Dim cmd As New SQLiteCommand
        cmd = conLITE.CreateCommand
        cmd.CommandText = Query
        cmd.CommandTimeout = 240
        da.SelectCommand = cmd
        If conLITE.State = 1 Then conLITE.Close()
        Try
            conLITE.Open()
            da.Fill(dss)
        Catch ex As Exception
            MsgError(ex.Message)
        End Try
        conLITE.Close()
        Return dss
    End Function
    Public Function getArray(ByVal Txt As String, ByVal Delimitter As String, ByVal Nomor As Integer)
        Dim s() As String
        Dim hasil As String
        s = Split(Txt.ToString.Trim, Delimitter)
        hasil = s(Nomor).ToString.Trim
        Return hasil
    End Function
    Public Function getDSString(ByVal ds1 As DataSet, ByVal rowIndex As Integer, ByVal ColumnName As String) As String
        If IsDSNull(ds1, ColumnName, rowIndex) Then
            Return ""
        Else
            Return ds1.Tables(0).Rows(rowIndex).Item(ColumnName).ToString
        End If

    End Function
    Public Sub QueryToCombo(ByVal cmb As ComboBox, ByVal SQL As String, Optional ByVal strcon As String = "")
        Dim dsc As DataSet
        cmb.Items.Clear()
        cmb.Items.Add("")
        dsc = QueryToDataset(SQL, strcon)
        For Each ro As DataRow In dsc.Tables(0).Rows
            cmb.Items.Add(ro(0).ToString.Trim)
        Next
        clearDataSet(dsc)
    End Sub
    Public Sub setColumnGrid(ByVal dgv As DataGridView, ByVal tablename As String)
        Dim x As Integer
        Dim ht, colName As String
        Dim dsc As DataSet
        dsc = QueryToDataset("select top 1 * from s_kolom where tablename='" & tablename & "'", StrConHRD)
        For x = 0 To dgv.ColumnCount - 1
            colName = LCase(dgv.Columns(x).DataPropertyName)
            ht = dgv.Columns(x).HeaderText
            ht = Replace(ht, "_", " ")
            ht = StrConv(ht, VbStrConv.ProperCase)
            dgv.Columns(x).HeaderText = ht
            'MsgError()
            dsc = QueryToDataset("select * from s_kolom where tablename='" & tablename & "' and columnname='" & colName & "' ", StrConHRD)
            If dsc.Tables(0).Rows.Count > 0 Then
                dgv.Columns(x).HeaderText = dsc.Tables(0).Rows(0).Item("caption").ToString.Trim
                dgv.Columns(x).Visible = False
                If CInt(dsc.Tables(0).Rows(0).Item("_visible").ToString.Trim) = 1 Then dgv.Columns(x).Visible = True
                dgv.Columns(x).Width = dsc.Tables(0).Rows(0).Item("_width").ToString.Trim
            End If

            If LCase(dgv.Columns(x).ValueType.ToString) = "system.datetime" Or _
                LCase(dgv.Columns(x).ValueType.ToString) = "system.date" Then
                FormatColumnGrid(dgv, x, "date")
            End If
        Next
        clearDataSet(dsc)
    End Sub
    Public Function isDateColumn(ByVal ColumnName As String) As Boolean
        ColumnName = LCase(ColumnName)
        If ColumnName = "dob" Or ColumnName = "joindate" Or ColumnName = "resigndate" Or ColumnName = "startcontract1" Or _
            ColumnName = "startcontract2" Or ColumnName = "endcontract1" Or ColumnName = "endcontract2" Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function dtsql(ByVal dt As Date) As String
        Return "" & Format(dt, "yyyy-MM-dd") & ""
    End Function
    Public Sub isiMasterCuti(ByVal eid As String)
        Dim joindate As Date
        Dim nip, s As String
        Dim x As Integer
        Dim dc As DataSet

        joindate = Date.Parse(getStringFromDB("select joindate from m_employee where employee_id='" & eid & "' ", StrConHRD))
        joindate = joindate.AddYears(1)

        nip = getStringFromDB("select nip from m_employee where employee_id='" & eid & "' ", StrConHRD)
        dc = Query("select * from m_employee_cuti where employee_id='" & eid & "' and startdate='" & dtsql(joindate) & "' ", StrConHRD)
        'MsgOK(dtsql(joindate))
        'MsgOK(DateDiff(DateInterval.Year, joindate, Now) + 1)
        For x = 1 To DateDiff(DateInterval.Year, joindate, Now) + 1
            If dtsql(joindate) > dtsql(Now) Then Continue For
            s = "select * from m_employee_cuti where employee_id='" & eid & "' and startdate='" & dtsql(joindate) & "' "
            'Dbg(s)
            dc = Query(s, StrConHRD)
            If GetDSRecordCount(dc) > 0 Then
                's = "update"
            Else
                s = "insert into m_employee_cuti (employee_id, nip, startdate, enddate, totalleave, takenleave, " & vbCrLf & _
                    "expiredleave, availableleave, expired, useradded, dateadded) values ('" & eid & "', " & vbCrLf & _
                    "'" & nip & "', '" & dtsql(joindate) & "', '" & dtsql(joindate.AddYears(1).AddDays(-1)) & "', '12', " & vbCrLf & _
                    "'0', '0', '12', '0', '" & UserLogin & "', '" & Format(Now, "yyyy-MM-dd hh:mm:ss") & "' )"
                ExecQuery(s, StrConHRD)
            End If
            joindate = joindate.AddYears(1)
        Next
        s = "update a " & vbCrLf & _
                "set a.takenleave = coalesce(b.takenleave, 0) " & vbCrLf & _
                "from m_employee_cuti a " & vbCrLf & _
                "inner join ( " & vbCrLf & _
                "select employee_cuti_id, employee_id, sum(takenleave) as takenleave from t_cuti " & vbCrLf & _
                "where  iscutitahunan=1 and employee_id='" & eid & "' " & vbCrLf & _
                "group by employee_cuti_id, employee_id " & vbCrLf & _
                ") b on a.employee_cuti_id=b.employee_cuti_id and a.employee_id=b.employee_id " & vbCrLf & _
                "where a.employee_id='" & eid & "'"
        'Dbg(s)
        ExecQuery(s, StrConHRD)

        s = "update m_employee_cuti set expired=1, expiredleave=totalleave-takenleave " & vbCrLf & _
            "where employee_id='" & eid & "' and convert(varchar(10), enddate, 20) < " & vbCrLf & _
            "convert(varchar(10), GETDATE(), 20) "
        ExecQuery(s, StrConHRD)

        s = "update m_employee_cuti set availableleave=totalleave-takenleave-expiredleave " & vbCrLf & _
            "where employee_id='" & eid & "' "
        ExecQuery(s, StrConHRD)


        s = "update a " & vbCrLf & _
            "set a.totalleave=b.totalleave, a.takenleave=b.takenleave,  " & vbCrLf & _
            "a.expiredleave=b.expiredleave, a.availableleave=b.availableleave " & vbCrLf & _
            "from m_employee a " & vbCrLf & _
            "inner join ( " & vbCrLf & _
            "select employee_id, sum(totalleave) as totalleave, sum(takenleave) as takenleave, " & vbCrLf & _
            "sum(expiredleave) as expiredleave, sum(availableleave) as availableleave " & vbCrLf & _
            "from m_employee_cuti " & vbCrLf & _
            "where employee_id='" & eid & "' " & vbCrLf & _
            "group by employee_id " & vbCrLf & _
            ") b on a.employee_id=b.employee_id " & vbCrLf & _
            "where a.employee_id='" & eid & "' "
        ExecQuery(s, StrConHRD)
        clearDataSet(dc)

    End Sub
    Public Function StrConX(ByVal IniName As String) As String
        Dim DBServer, DBName, DBUser, DBPass, hasil As String
        DBServer = ReadIni(IniName, "ServerName")
        DBName = ReadIni(IniName, "DatabaseName")
        DBUser = ReadIni(IniName, "LoginID")
        DBPass = Decrypt(ReadIni(IniName, "Password"))
        hasil = "Data Source=" & DBServer & ";" & "Initial Catalog=" & DBName & ";" & "User ID=" & DBUser & ";" & "Password=" & DBPass & ";"
        Return hasil
    End Function

    Public Sub OpenDB_ABS_S001()
        strCon_Global = StrConX("ABS_S001")
        'MsgOK(strCon_Global)
    End Sub
    Public Sub OpenDB_ABS_S002()
        strCon_Global = StrConX("ABS_S002")
    End Sub
    Public Sub OpenDB_ABS_S003()
        strCon_Global = StrConX("ABS_S003")
        'MsgOK(strCon_Global)
    End Sub

    Public Sub OpenDB_POSSERVER_S001()
        strCon_Global = StrConX("POSSERVER_S001")
    End Sub
    Public Sub OpenDB_POSSERVER_S002()
        strCon_Global = StrConX("POSSERVER_S002")
    End Sub
    Public Sub OpenDB_POSSERVER_S003()
        strCon_Global = StrConX("POSSERVER_S003")
    End Sub

    Public Sub OpenDB_POSSERVERHISTORY_S001()
        strCon_Global = StrConX("POSSERVERHISTORY_S001")
    End Sub
    Public Sub OpenDB_POSSERVERHISTORY_S002()
        strCon_Global = StrConX("POSSERVERHISTORY_S002")
    End Sub
    Public Sub OpenDB_POSSERVERHISTORY_S003()
        strCon_Global = StrConX("POSSERVERHISTORY_S003")
    End Sub
    Public Sub OpenDB_SAP()
        strCon_Global = StrConX("SAP")
    End Sub
    Public Sub OpenDBSupplier()
        strCon_Global = StrConSUP()
    End Sub
    Public Sub OpenDBHRD()
        strCon_Global = StrConHRD()
        'MsgOK()
    End Sub
    Public Sub CloseDBALL()
        strCon_Global = ""
    End Sub

    Public Sub isiComboboxFromSQL(ByVal cmb As ComboBox, ByVal SQL As String)
        Dim dcc As DataSet
        dcc = Query(SQL)
        cmb.Items.Clear()
        cmb.Items.Add("")
        For x As Integer = 0 To dcc.Tables(0).Rows.Count - 1
            cmb.Items.Add(dcc.Tables(0).Rows(x).Item(0).ToString.Trim)
        Next
        clearDataSet(dcc)
    End Sub
    Public Function getCodeFromCheckboxCombo(ByVal txt As String, ByVal Delimitter1 As String, ByVal Delimitter2 As String)
        If txt Is Nothing Then
            Return ""
            Exit Function
        End If
        If txt.Trim = "" Then
            Return ""
            Exit Function
        End If
        Dim arr1(), kode As String
        Dim x As Integer
        arr1 = Split(txt.Trim, Delimitter1)
        kode = ""
        For x = 0 To arr1.Length - 1
            kode = kode & "'" & getArray(arr1(x), Delimitter2, 0) & "',"
        Next
        kode = Mid(kode, 1, Len(kode) - 1)
        Return kode
    End Function

    Public Function TERBILANG(ByVal x As Double) As String
        Dim tampung As Double
        Dim teks As String
        Dim bagian As String
        Dim i As Integer
        Dim tanda As Boolean

        Dim letak(5)
        letak(1) = "RIBU "
        letak(2) = "JUTA "
        letak(3) = "MILYAR "
        letak(4) = "TRILYUN "

        If (x < 0) Then
            TERBILANG = ""
            Exit Function
        End If

        If (x = 0) Then
            TERBILANG = "NOL"
            Exit Function
        End If

        If (x < 2000) Then
            tanda = True
        End If
        teks = ""

        If (x >= 1.0E+15) Then
            TERBILANG = "NILAI TERLALU BESAR"
            Exit Function
        End If

        For i = 4 To 1 Step -1
            tampung = Int(x / (10 ^ (3 * i)))
            If (tampung > 0) Then
                bagian = ratusan(tampung, tanda)
                teks = teks & bagian & letak(i)
            End If
            x = x - tampung * (10 ^ (3 * i))
        Next

        teks = teks & ratusan(x, False)
        TERBILANG = teks & "RUPIAH"
    End Function

    Function ratusan(ByVal y As Double, ByVal flag As Boolean) As String
        Dim tmp As Double
        Dim bilang As String
        Dim bag As String
        Dim j As Integer

        Dim angka(9)
        angka(1) = "SE"
        angka(2) = "DUA "
        angka(3) = "TIGA "
        angka(4) = "EMPAT "
        angka(5) = "LIMA "
        angka(6) = "ENAM "
        angka(7) = "TUJUH "
        angka(8) = "DELAPAN "
        angka(9) = "SEMBILAN "

        Dim posisi(2)
        posisi(1) = "PULUH "
        posisi(2) = "RATUS "

        bilang = ""
        For j = 2 To 1 Step -1
            tmp = Int(y / (10 ^ j))
            If (tmp > 0) Then
                bag = angka(tmp)
                If (j = 1 And tmp = 1) Then
                    y = y - tmp * 10 ^ j
                    If (y >= 1) Then
                        posisi(j) = "BELAS "
                    Else
                        angka(y) = "SE"
                    End If
                    bilang = bilang & angka(y) & posisi(j)
                    ratusan = bilang
                    Exit Function
                Else
                    bilang = bilang & bag & posisi(j)
                End If
            End If
            y = y - tmp * 10 ^ j
        Next

        If (flag = False) Then
            angka(1) = "SATU "
        End If
        bilang = bilang & angka(y)
        ratusan = bilang
    End Function
    Public Sub isiComboFromSQL2(ByVal cmb As ComboBox, ByVal SQL As String)
        Dim dcc As DataSet
        dcc = Query(SQL)
        cmb.Items.Clear()
        cmb.Items.Add("")
        For x As Integer = 0 To dcc.Tables(0).Rows.Count - 1
            cmb.Items.Add(dcc.Tables(0).Rows(x).Item(0).ToString.Trim)
        Next
        clearDataSet(dcc)
    End Sub
    Public Function ReplacePetik(ByVal txt As String) As String
        Return Replace(txt, "'", "''")
    End Function
    Sub isiTmpTerimaConsignment(ByVal t As String, ByVal dsh As DataSet)
        Dim ds1 As DataSet
        Dim s, vname As String
        Dim no As Integer
        s = ""
        vname = getStringFromDB("select cardname from m_vendor where cardcode='" & getDSString(dsh, 0, "cardcode") & "' ")
        ds1 = QueryToDataset("select t.*, s.whsstr from t_terima_c t " & vbCrLf & _
                             "left join store s on t.whscode=s.whscode " & vbCrLf & _
                             "where t.noterima='" & t & "' order by t.noterima, t.whscode ")
        no = 1
        'MsgOK(ds1.Tables(0).Rows.Count)
        For Each ro As DataRow In ds1.Tables(0).Rows
            s = "insert into tmp_terima2 (noterima, cardcode, cardname, tgl, tipe, nokw, whsstr, " & vbCrLf & _
                      "tagihan, serah, terima, _order, periode) values ('" & t & "', " & vbCrLf & _
                      "'" & getDSString(dsh, 0, "cardcode") & "', " & vbCrLf & _
                      "'" & ReplacePetik(vname) & "', " & getDSDateSQL(dsh, 0, "tgl") & ", '" & ro("dokumen") & "', " & vbCrLf & _
                      "'', '" & ro("whsstr").ToString.Trim & "', " & vbCrLf & _
                      "'" & ro("tagihan").ToString.Trim & "', '" & StrConv(getDSString(dsh, 0, "serah"), VbStrConv.ProperCase) & "', " & vbCrLf & _
                      "'" & StrConv(getDSString(dsh, 0, "terima"), VbStrConv.ProperCase) & "', '" & no & "', '" & ro("periode").ToString.Trim & "' )"
            'Dbg(s)
            ExecQuery(s)
            no += 1
        Next
        clearDataSet(ds1)
        isiTmp_Terima3()
    End Sub
    Public Sub RptTerimaDirect(ByVal noterima As String)
        Dim t As String
        Dim dsh As DataSet
        Dim isDirect As Integer
        t = noterima
        dsh = Query("select * from t_terima where noterima='" & t & "' ")
        If GetDSRecordCount(dsh) <= 0 Then
            clearDataSet(dsh)
            Exit Sub
        End If
        'MsgOK("1")
        isDirect = CInt(dsh.Tables(0).Rows(0).Item("isdirect").ToString.Trim)
        If isDirect <> 1 Then
            isiTmpTerimaConsignment(t, dsh)
            clearDataSet(dsh)
            Exit Sub
        End If

        Dim ds1, ds2 As DataSet
        Dim s, vname As String
        Dim no As Integer
        'MsgOK("2")
        s = ""
        vname = getStringFromDB("select cardname from m_vendor where cardcode='" & getDSString(dsh, 0, "cardcode") & "' ")
        'MsgOK("3")
        ds1 = QueryToDataset("select t.* from t_terima_t1 t " & vbCrLf & _
                             "left join store s on t.whsstr=s.whsstr " & vbCrLf & _
                             "where t.noterima='" & t & "' order by s.whscode, t.nokw ")
        no = 1
        'MsgOK("4")
        For Each ro As DataRow In ds1.Tables(0).Rows
            s = "insert into tmp_terima2 (noterima, cardcode, cardname, tgl, tipe, nokw, whsstr, " & vbCrLf & _
                      "tagihan, serah, terima, _order, periode) values ('" & t & "', " & vbCrLf & _
                      "'" & getDSString(dsh, 0, "cardcode") & "', " & vbCrLf & _
                      "'" & ReplacePetik(vname) & "', " & getDSDateSQL(dsh, 0, "tgl") & ", 'Kwitansi', " & vbCrLf & _
                      "'" & ro("nokw").ToString.Trim & "', '" & ro("whsstr").ToString.Trim & "', " & vbCrLf & _
                      "'" & ro("tagihan").ToString.Trim & "', '" & StrConv(getDSString(dsh, 0, "serah"), VbStrConv.ProperCase) & "', " & vbCrLf & _
                      "'" & StrConv(getDSString(dsh, 0, "terima"), VbStrConv.ProperCase) & "', '" & no & "', " & getDSDateSQL(dsh, 0, "tgl") & " )"
            'Dbg(s)
            ExecQuery(s)
            no += 1
        Next
        'MsgOK("5")

        Dim tipe, nom, whs As String
        Dim xx As Integer = 1
        tipe = ""
        nom = ""
        whs = ""
        ds1 = QueryToDataset("select distinct tipe from t_terima_t2 where oke=1 and noterima='" & t & "' order by tipe ")
        For Each rt As DataRow In ds1.Tables(0).Rows
            If Not tipe.Contains(Replace(rt("tipe").ToString.Trim, "'", "")) Then
                tipe += "'" & Replace(rt("tipe").ToString.Trim, "'", "") & "', "
            End If

            If xx >= ds1.Tables(0).Rows.Count Then
            Else
                If xx Mod 2 <> 0 Then
                    xx += 1
                    Continue For
                End If
            End If

            If Len(tipe) > 2 Then tipe = Mid(tipe, 1, Len(tipe) - 2)
            ds2 = QueryToDataset("select t.nomor, t.whsstr from t_terima_t2 t " & vbCrLf & _
                                 "left join store s on t.whsstr=s.whsstr " & vbCrLf & _
                                 "where t.oke=1 and t.noterima='" & t & "' and " & vbCrLf & _
                                 "t.tipe in (" & tipe & ") order by t.tipe, s.whscode, t.nomor")
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
            tipe = Replace(tipe, "'", "")
            s = "insert into tmp_terima2 (noterima, cardcode, cardname, tgl, tipe, nokw, whsstr, " & vbCrLf & _
                  "tagihan, serah, terima, _order, periode) values ('" & t & "', " & vbCrLf & _
                  "'" & getDSString(dsh, 0, "cardcode") & "', " & vbCrLf & _
                  "'" & ReplacePetik(vname) & "', " & getDSDateSQL(dsh, 0, "tgl") & ", '" & tipe & "', " & vbCrLf & _
                  "'" & nom & "', '" & whs & "', " & vbCrLf & _
                  "'0', '" & StrConv(ReplacePetik(getDSString(dsh, 0, "serah")), VbStrConv.ProperCase) & "', " & vbCrLf & _
                  "'" & StrConv(ReplacePetik(getDSString(dsh, 0, "terima")), VbStrConv.ProperCase) & "', '" & no & "', " & getDSDateSQL(dsh, 0, "tgl") & " )"
            'Dbg(s)
            ExecQuery(s)
            tipe = ""
            no += 1
            xx += 1
        Next
        clearDataSet(dsh)
        clearDataSet(ds1)
        'clearDataSet(ds2)
        isiTmp_Terima3()
        'strReport = "TANDATERIMA2"
        'ReportPath = "\REPORT\RptTandaTerima2.rpt"
        'sqlreport = "select * from tmp_terima3 order by noterima, _order"
        ''MsgOK("finished")
        'FrmLaporan.ShowDialog()
    End Sub
    Public Sub isiTmp_Terima3()
        Dim ds1, ds2, ds3 As DataSet
        Dim s As String
        Dim page, aw, ak, kol, isDirect As Integer
        ds1 = Query("select noterima from tmp_terima2 group by noterima order by noterima")
        For Each rn As DataRow In ds1.Tables(0).Rows
            page = getStringFromDB("select round(count(*)/6,0) as a from tmp_terima2 where noterima='" & rn("noterima").ToString.Trim & "'")
            isDirect = getStringFromDB("select isdirect from t_terima where noterima='" & rn("noterima").ToString.Trim & "' ")
            page += 1
            aw = 1
            ak = 6
            For x As Integer = 1 To page
                ds2 = Query("select * from ( " & vbCrLf & _
                            "   select ROW_NUMBER() OVER ( ORDER BY _order ) AS RowNum, " & vbCrLf & _
                            "   * from tmp_terima2 where noterima='" & rn("noterima").ToString.Trim & "' " & vbCrLf & _
                            ") a where noterima='" & rn("noterima").ToString.Trim & "' " & vbCrLf & _
                            "and rownum >= '" & aw & "' and rownum <='" & ak & "' ")
                kol = 1
                For r As Integer = 0 To ds2.Tables(0).Rows.Count - 1
                    ds3 = Query("select * from tmp_terima3 where noterima='" & rn("noterima").ToString.Trim & "' and _order='" & x & "' ")
                    If GetDSRecordCount(ds3) > 0 Then
                        s = "update tmp_terima3 set " & vbCrLf & _
                            "tipe" & kol & "='" & getDSString(ds2, r, "tipe") & "', " & vbCrLf & _
                            "nokw" & kol & "='" & getDSString(ds2, r, "nokw") & "', " & vbCrLf & _
                            "whsstr" & kol & "='" & getDSString(ds2, r, "whsstr") & "', " & vbCrLf & _
                            "tagihan" & kol & "='" & getDSString(ds2, r, "tagihan") & "', " & vbCrLf & _
                            "isdirect='" & isDirect & "' " & vbCrLf & _
                            "where noterima='" & rn("noterima").ToString.Trim & "' and _order='" & x & "' "
                    Else
                        s = "insert into tmp_terima3 (noterima, periode, cardcode, cardname, tgl, serah, terima, _order, " & vbCrLf & _
                        "tipe" & kol & ", nokw" & kol & ", whsstr" & kol & ", tagihan" & kol & ", code, isDirect) values (" & vbCrLf & _
                        "'" & rn("noterima").ToString.Trim & "', '" & getDSString(ds2, r, "periode") & "', '" & getDSString(ds2, r, "cardcode") & "', " & vbCrLf & _
                        "'" & ReplacePetik(getDSString(ds2, r, "cardname")) & "', " & getDSDateSQL(ds2, 0, "tgl") & ", " & vbCrLf & _
                        "'" & getDSString(ds2, r, "serah") & "', '" & getDSString(ds2, r, "terima") & "', " & vbCrLf & _
                        "'" & x & "', '" & getDSString(ds2, r, "tipe") & "', " & vbCrLf & _
                        "'" & getDSString(ds2, r, "nokw") & "', '" & getDSString(ds2, r, "whsstr") & "', " & vbCrLf & _
                        "'" & getDSString(ds2, r, "tagihan") & "', " & vbCrLf & _
                        "'" & rn("noterima").ToString.Trim & "_" & x & "', '" & isDirect & "' " & vbCrLf & _
                        ")"
                    End If
                    ExecQuery(s)
                    kol += 1
                Next
                aw += 6
                ak += 6
            Next
        Next
        clearDataSet(ds1)
        'clearDataSet(ds2)
    End Sub
    Public Function getParamValue(ByVal ParamName As String) As String
        'Dbg("select paramvalue from tbl_param where paramname='" & ParamName & "' ")
        Return getStringFromDB("select paramvalue from tbl_param where paramname='" & ParamName & "' ", StrConSUP)
    End Function
    Public Function stringToDouble(ByVal txt As String) As Double
        Dim hasil As Double = 0
        If txt.Trim = "" Then
            hasil = 0
        Else
            hasil = CDbl(txt)
        End If
        Return hasil
    End Function
    Public Sub PrintBK(ByVal nobk As String)
        ExecQuery("truncate table tmp_bk")
        ExecQuery("insert into tmp_bk (bk_id, nobk, tglbk, vendor_id, cardname, totaltagihan, " & vbCrLf & _
                  "terbilang, bank, nogiro, tglgiro, description, useradded, dateadded, useredited, dateedited) " & vbCrLf & _
                  "select b.bk_id, (convert(varchar(100), b.bk_id) + '-' + b.nobk) as nobk, b.tglbk,  " & vbCrLf & _
                  "b.vendor_id, upper(b.cardname) as cardname, b.totaltagihan, b.terbilang, b.bank, " & vbCrLf & _
                  " b.nogiro, b.tglgiro, b.description, dbo.propercase(b.useradded), dateadded, " & vbCrLf & _
                  "dbo.propercase(useredited), dateedited from t_bk b " & vbCrLf & _
                  "left join m_vendor v on b.vendor_id=v.cardcode " & vbCrLf & _
                  "where b.bk_id in (" & nobk & ") order by b.nobk " & vbCrLf & _
                  "" & vbCrLf & _
                  " ")
        ExecQuery("update a " & vbCrLf & _
                    "set a.bk_check1=b.bk_check1," & vbCrLf & _
                    "a.bk_know1=b.bk_know1," & vbCrLf & _
                    "a.bk_know2=b.bk_know2," & vbCrLf & _
                    "a.bk_approved1=b.bk_approved1," & vbCrLf & _
                    "a.bk_approved2 = b.bk_approved2 " & vbCrLf & _
                    "from tmp_bk a " & vbCrLf & _
                    "cross join (" & vbCrLf & _
                    "    select " & vbCrLf & _
                    "    (select paramvalue from tbl_param where paramname='bk_check1') as bk_check1," & vbCrLf & _
                    "    (select paramvalue from tbl_param where paramname='bk_know1') as bk_know1," & vbCrLf & _
                    "    (select paramvalue from tbl_param where paramname='bk_know2') as bk_know2," & vbCrLf & _
                    "    (select paramvalue from tbl_param where paramname='bk_approved1') as bk_approved1," & vbCrLf & _
                    "    (select paramvalue from tbl_param where paramname='bk_approved2') as bk_approved2 " & vbCrLf & _
                    ") b ")
        'MsgOK("tes")
        Dim SQL As String
        SQL = "select * from tmp_bk order by nobk"
        ShowReport("REPORTBK", "\REPORT\RptBK.rpt", SQL)
    End Sub

    Public Function TextToBarcode(ByVal txt As String, _
                                  Optional ByVal Rotasi As Boolean = True, _
                                  Optional ByVal tipeEan As String = "ean-13", _
                                  Optional ByVal align As Integer = 1, _
                                  Optional ByVal Tinggi As Integer = 20) As Image
        Dim b As New BarcodeLib.Barcode
        Dim W, H As Integer
        'Dim img As Image
        '1  left
        '2  righ
        If LCase(tipeEan) = "code 128" Then
            W = 200
            H = Tinggi
            b.Alignment = align 'harus left
        Else
            W = 95
            H = Tinggi
            b.Alignment = BarcodeLib.AlignmentPositions.CENTER
        End If


        'Select Case cbBarcodeAlign.Text.ToString.Trim.ToLower
        '    Case "left" : b.Alignment = BarcodeLib.AlignmentPositions.LEFT
        '    Case "right" : b.Alignment = BarcodeLib.AlignmentPositions.RIGHT
        '    Case Else : b.Alignment = BarcodeLib.AlignmentPositions.CENTER
        'End Select
        'MsgOK(tipeEan.ToString.Trim.ToLower)
        Dim tb As BarcodeLib.TYPE = BarcodeLib.TYPE.UNSPECIFIED
        Select Case tipeEan.ToString.Trim.ToLower
            Case "upc-a" : tb = BarcodeLib.TYPE.UPCA
            Case "upc-e" : tb = BarcodeLib.TYPE.UPCE
            Case "upc 2 digit ext." : tb = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_2DIGIT
            Case "upc 5 digit ext." : tb = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_5DIGIT
            Case "ean-13" : tb = BarcodeLib.TYPE.EAN13
            Case "jan-13" : tb = BarcodeLib.TYPE.JAN13
            Case "ean-8" : tb = BarcodeLib.TYPE.EAN8
            Case "itf-14" : tb = BarcodeLib.TYPE.ITF14
            Case "codabar" : tb = BarcodeLib.TYPE.Codabar
            Case "postnet" : tb = BarcodeLib.TYPE.PostNet
            Case "bookland/isbn" : tb = BarcodeLib.TYPE.BOOKLAND
            Case "code 11" : tb = BarcodeLib.TYPE.CODE11
            Case "code 39" : tb = BarcodeLib.TYPE.CODE39
            Case "code 39 extended" : tb = BarcodeLib.TYPE.CODE39Extended
            Case "code 39 mod 43" : tb = BarcodeLib.TYPE.CODE39_Mod43
            Case "code 93" : tb = BarcodeLib.TYPE.CODE93
            Case "logmars" : tb = BarcodeLib.TYPE.LOGMARS
            Case "msi" : tb = BarcodeLib.TYPE.MSI_Mod10
            Case "interleaved 2 of 5" : tb = BarcodeLib.TYPE.Interleaved2of5
            Case "standard 2 of 5" : tb = BarcodeLib.TYPE.Standard2of5
            Case "code 128" : tb = BarcodeLib.TYPE.CODE128
            Case "code 128-a" : tb = BarcodeLib.TYPE.CODE128A
            Case "code 128-b" : tb = BarcodeLib.TYPE.CODE128B
            Case "code 128-c" : tb = BarcodeLib.TYPE.CODE128C
            Case "telepen" : tb = BarcodeLib.TYPE.TELEPEN
            Case "fim" : tb = BarcodeLib.TYPE.FIM
            Case "pharmacode" : tb = BarcodeLib.TYPE.PHARMACODE
            Case Else : MessageBox.Show("Please specify the encoding type.")
        End Select
        Try
            If tb <> BarcodeLib.TYPE.UNSPECIFIED Then
                'b.BarWidth
                'Try
                '    b.BarWidth = 0
                '    If textBoxBarWidth.Text.Trim.Length >= 1 Then
                '        b.BarWidth = CInt(textBoxBarWidth.Text.Trim)
                '    End If
                'Catch ex As Exception
                '    MsgBox("Unable to parse BarWidth: " + ex.Message)
                'End Try

                'Try
                '    b.AspectRatio = 0
                '    If textBoxAspectRatio.Text.Trim.Length >= 1 Then
                '        b.AspectRatio = CInt(textBoxAspectRatio.Text.Trim)
                '    End If
                'Catch ex As Exception
                '    MsgBox("Unable to parse AspectRatio: " + ex.Message)
                'End Try

                'b.BarWidth = CInt(textBoxBarWidth.Text.Trim)
                'b.AspectRatio = CInt(textBoxAspectRatio.Text.Trim)

                'b.IncludeLabel = chkGenerateLabel.Checked

                b.IncludeLabel = False
                If Rotasi Then b.RotateFlipType = RotateFlipType.Rotate180FlipY
                b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER

                'Select Case cbLabelLocation.Text.ToString.Trim.ToUpper
                '    Case "BOTTOMLEFT" : b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMLEFT
                '    Case "BOTTOMRIGHT" : b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMRIGHT
                '    Case "TOPCENTER" : b.LabelPosition = BarcodeLib.LabelPositions.TOPCENTER
                '    Case "TOPLEFT" : b.LabelPosition = BarcodeLib.LabelPositions.TOPLEFT
                '    Case "TOPRIGHT" : b.LabelPosition = BarcodeLib.LabelPositions.TOPRIGHT
                '    Case Else : b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER
                'End Select

                'Dim CropRect As New Rectangle(0, 0, 95, 20)
                'Dim OriginalImage = b.Encode(tb, txt.Trim, Color.Black, Color.White, W, H)
                'Dim CropImage = New Bitmap(CropRect.Width, CropRect.Height)
                'Using grp = Graphics.FromImage(CropImage)
                '    grp.DrawImage(OriginalImage, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
                '    OriginalImage.Dispose()
                '    CropImage.Save(fileName)
                'End Using

                'crop()
                'MsgOK("1")
                'Try
                '    img = b.Encode(tb, txt.Trim, Color.Black, Color.White, W, H)
                'Catch ex As Exception
                '    MessageBox.Show(ex.Message)
                'End Try

                Return b.Encode(tb, txt.Trim, Color.Black, Color.White, W, H)
                'MsgOK("2")
                'PictureBox1.Image = barcode.BackgroundImage
                'b.SaveImage("d:\tes.png", SaveTypes.PNG)
                'lblEncodingTime.Text = "(" + Math.Round(b.EncodingTime, 0, MidpointRounding.AwayFromZero).ToString() + "ms)"
                'txtEncoded.Text = b.EncodedValue

                'If b.BarWidth.HasValue Then txtWidth.Text = b.Width.ToString
                'If b.AspectRatio.HasValue Then txtHeight.Text = b.Height.ToString
                'barcode.Location = New Point(((barcode.Location.X + barcode.Width) / 2) - (barcode.Width / 2), ((barcode.Location.Y + barcode.Height) / 2) - (barcode.Height / 2))
            End If 'tb <> BarcodeLib.TYPE.UNSPECIFIED


        Catch ex As Exception

            MessageBox.Show(ex.Message)
        End Try
    End Function
    Public Sub FillCellGrid(ByVal dg As DataGridView, ByVal columnName As String, _
                             Optional ByVal Value As String = "", _
                             Optional ByVal RowIndex As Integer = -1)
        If RowIndex = -1 Then RowIndex = dg.CurrentRow.Index
        columnName = LCase(columnName)
        For x As Integer = 0 To dg.ColumnCount - 1
            If columnName = LCase(dg.Columns(x).DataPropertyName) Then
                dg.Item(x, RowIndex).Value = Value
                Exit For
            End If
        Next
    End Sub
    Public Function getColumnGrid(ByVal dg As DataGridView, ByVal columnName As String, _
                                  Optional ByVal RowIndex As Integer = -1) As String
        Dim hasil As String = ""
        If RowIndex = -1 Then RowIndex = dg.CurrentRow.Index
        columnName = LCase(columnName)
        For x As Integer = 0 To dg.ColumnCount - 1
            If columnName = LCase(dg.Columns(x).DataPropertyName) Then
                hasil = dg.Item(x, RowIndex).Value.ToString.Trim
                Exit For
            End If
        Next
        Return hasil
    End Function
End Module
