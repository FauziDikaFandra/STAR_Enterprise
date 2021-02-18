Imports System.Data
Imports System.Data.OleDb
Imports System.Linq
Imports System.IO
Public Class GenerateForm
    Dim Process As Decimal
    Dim strProcess As String
    Dim lokasiMasuk, lokasiPulang As String
    Dim dtGenerate As DateTime
    Public ZK As New zkemkeeper.CZKEM
    Dim FConnect As Boolean = False 'the boolean value identifies whether the device is connected
    Dim iMachineNumber As Integer = 1 'In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
    Dim numberx, errorCount, no, totalLog As Integer

    Function getRoster(ByVal kolom As String, ByVal eid As String, ByVal dt As Date) As String
        Dim hasil As String = "0000"
        kolom = LCase(kolom)
        If kolom = "masukroster" Then hasil = "0830"
        If kolom = "pulangroster" Then hasil = "1730"
        Dim dx As DataSet

        dx = Query("select employee_id, " & kolom & " from m_employee where employee_id='" & eid & "' ")
        If GetDSRecordCount(dx) Then
            hasil = dx.Tables(0).Rows(0).Item(1).ToString.Trim
        End If

        dx = Query("select employee_id, " & kolom & " from t_roster where employee_id='" & eid & "' and " & vbCrLf & _
                   "convert(varchar(10), tgl, 20)='" & dtsql(dt) & "' ")
        If GetDSRecordCount(dx) Then
            hasil = dx.Tables(0).Rows(0).Item(1).ToString.Trim
        End If
        clearDataSet(dx)
        Return hasil
    End Function
    Function getTime(ByVal kode As String, ByVal eid As String, ByVal dt As Date, _
                     Optional ByVal jammasuk As String = "0000") As String
        Dim hasil As String = "0000"
        Dim timein, sy As String
        Dim dx As DataSet
        sy = " (0=0) order by tgl"
        If kode = "1" Then 'proses masuk
            sy = " (0=0) and convert(varchar(10), tgl, 20)='" & dtsql(dt) & "' order by tgl"
        ElseIf kode = "2" Then 'proses pulang
            If jammasuk = "0000" Then
                timein = getStringFromDB("select jammasuk from t_absen " & vbCrLf & _
                                     "where employee_id='" & eid & "' and " & vbCrLf & _
                                     "convert(varchar(10), tgl, 20)='" & dtsql(dt) & "' ", StrConHRD)
                If timein = "" Then
                    timein = "08:30:00"
                Else
                    timein = Microsoft.VisualBasic.Left(timein, 2) & ":" & Microsoft.VisualBasic.Right(timein, 2) & ":00"
                End If
            Else
                timein = Microsoft.VisualBasic.Left(jammasuk, 2) & ":" & Microsoft.VisualBasic.Right(jammasuk, 2) & ":00"
            End If
            sy = " tgl >= dateadd(hour, 6, '" & dtsql(dt) & " " & timein & "') and " & vbCrLf & _
                 " tgl <= dateadd(hour, 20, '" & dtsql(dt) & " " & timein & "') " & vbCrLf & _
                 " order by tgl desc"
        End If
        strSQL = "select top 1 employee_id, tgl, jam, lokasi from t_finger where " & vbCrLf & _
                 "employee_id='" & eid & "' and " & sy & " "
        'Dbg(strSQL)
        dx = Query(strSQL)
        If dx.Tables(0).Rows.Count > 0 Then
            If Not IsDBNull(dx.Tables(0).Rows(0).Item("jam")) Then hasil = dx.Tables(0).Rows(0).Item("jam").ToString.Trim
            If Not IsDBNull(dx.Tables(0).Rows(0).Item("lokasi")) Then
                If kode = "1" Then
                    lokasiMasuk = dx.Tables(0).Rows(0).Item("lokasi").ToString.Trim
                ElseIf kode = "2" Then
                    lokasiPulang = dx.Tables(0).Rows(0).Item("lokasi").ToString.Trim
                End If
            End If
        Else
            If kode = "1" Then
                sy = " (0=0) and convert(varchar(10), tgl, 20)='" & dtsql(dt) & "' order by tgl"
            ElseIf kode = "2" Then
                sy = " (0=0) and convert(varchar(10), tgl, 20)='" & dtsql(dt) & "' order by tgl desc"
            End If
            strSQL = "select top 1 employee_id, tgl, jam, lokasi from t_finger where " & vbCrLf & _
                     "employee_id='" & eid & "' and kode='" & kode & "' and " & sy & " "
            'Dbg("x : " & strSQL)
            dx = Query(strSQL)
            If dx.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(dx.Tables(0).Rows(0).Item("jam")) Then hasil = dx.Tables(0).Rows(0).Item("jam").ToString.Trim

                If Not IsDBNull(dx.Tables(0).Rows(0).Item("lokasi")) Then
                    If kode = "1" Then
                        lokasiMasuk = dx.Tables(0).Rows(0).Item("lokasi").ToString.Trim
                    ElseIf kode = "2" Then
                        lokasiPulang = dx.Tables(0).Rows(0).Item("lokasi").ToString.Trim
                    End If
                End If
            End If
        End If
        clearDataSet(dx)
        Return hasil
    End Function
    Function isLibur(ByVal dt As Date) As Boolean
        Dim dst As DataSet
        Dim hasil As Boolean = False
        dst = Query("select * from m_calendar where convert(varchar(10), tgl, 20)='" & Format(dt, "yyyy-MM-dd") & "' ")
        If GetDSRecordCount(dst) > 0 Then
            hasil = True
        End If
        clearDataSet(dst)
        Return hasil
    End Function
    Function isCuti(ByVal spg_id As String, ByVal dt As Date) As Boolean
        Dim dst As DataSet
        Dim hasil As Boolean = False
        dst = Query("select * from t_cuti where '" & Format(dt, "yyyy-MM-dd") & "' between startdate and enddate " & vbCrLf & _
                    "and status='APPROVED' and employee_id='" & spg_id & "' ")
        If GetDSRecordCount(dst) > 0 Then
            hasil = True
        End If
        clearDataSet(dst)
        Return hasil
    End Function
    Function getStatus(ByVal spg_id As String, ByVal dt As Date, Optional ByVal jammasuk As String = "0000", _
                       Optional ByVal jampulang As String = "0000", Optional ByVal masukroster As String = "0830", _
                       Optional ByVal pulangroster As String = "1730") As String
        Dim hasil As String = ""
        Dim status As String = ""
        
        If jammasuk = "0000" And jampulang = "0000" Then
            hasil = "Alpa"
            If Weekday(dt, FirstDayOfWeek.Monday) >= 6 Then hasil = "Off"
            If isCuti(spg_id, dt) Then hasil = "Cuti"
            If baruJoin(spg_id, dt) Then hasil = "Off"
            If isLibur(dt) Then hasil = "Off"
        End If
        If jammasuk <> "0000" Or jampulang <> "0000" Then
            hasil = "Masuk"
            If jammasuk > masukroster Then hasil = "Terlambat"
            'If jampulang < pulangroster Then hasil = "Pulang Cepat"
            If Weekday(dt, FirstDayOfWeek.Monday) >= 6 Then hasil = "Lembur"
        End If

        'jika sabtu atau minggu lembur

        Return hasil
    End Function
    Function baruJoin(ByVal spg_id As String, ByVal dt As Date) As Boolean
        Dim join As Date
        Dim dss As DataSet
        Dim hasil As Boolean
        dss = Query("select employee_id, joindate from m_employee where employee_id='" & spg_id & "' ")
        If dss.Tables(0).Rows.Count > 0 Then
            join = getDSDate(dss, 0, "joindate")
        End If
        hasil = False
        If Format(dt, "yyyy-MM-dd") < Format(join, "yyyy-MM-dd") Then
            hasil = True
        End If
        clearDataSet(dss)
        Return hasil
    End Function
    Sub processSCANtoABSEN(ByVal eid As String, ByVal dt1 As Date, ByVal dt2 As Date)
        Dim dsE, dsA As DataSet
        Dim jarak As Integer
        Dim timein, timeout, dt As Date
        Dim jammasuk, jampulang, status, masukroster, pulangroster As String
        Dim status1, ket1, jammasuk1, jampulang1, nip, fgcode, name As String
        dt = dt1
        jarak = DateDiff(DateInterval.Day, dt1, dt2) + 1
        'MsgBox("jarak : " & jarak & _
        '       "dt1 : " & dt2DateStr(dt1) & _
        '       "dt2 : " & dt2DateStr(dt2))
        strSQL = "select top 1 employee_id, nip, fingercode, name from m_employee"
        dsE = Query(strSQL)
        dsA = Query(strSQL)
        For x = 1 To jarak
            strSQL = "select employee_id, nip, fingercode, name from m_employee where employee_id='" & eid & "' "
            dsE = Query(strSQL, StrConHRD)
            If dsE.Tables(0).Rows.Count > 0 Then
                nip = dsE.Tables(0).Rows(0).Item("nip").ToString.Trim
                fgcode = dsE.Tables(0).Rows(0).Item("fingercode").ToString.Trim
                name = dsE.Tables(0).Rows(0).Item("name").ToString.Trim
                masukroster = getRoster("masukroster", eid, dt)
                pulangroster = getRoster("pulangroster", eid, dt)
                lokasiMasuk = ""
                lokasiPulang = ""
                jammasuk = getTime("1", eid, dt)
                jampulang = getTime("2", eid, dt, jammasuk)
                status = getStatus(eid, dt, jammasuk, jampulang, masukroster, pulangroster)
                If LCase(status) = "off" Then
                    masukroster = "0000"
                    pulangroster = "0000"
                End If
                'Dbg("Jam Masuk : " & jammasuk & vbCrLf & _
                '    "Jam Pulang : " & jampulang & vbCrLf & _
                '    "Status : " & status)
                timein = Date.Parse(Format(dt, "yyyy-MM-dd ") & _
                                    Microsoft.VisualBasic.Left(jammasuk, 2) & ":" & _
                                    Microsoft.VisualBasic.Right(jammasuk, 2) & ":00")
                timeout = Date.Parse(Format(dt, "yyyy-MM-dd ") & _
                                     Microsoft.VisualBasic.Left(jampulang, 2) & ":" & _
                                     Microsoft.VisualBasic.Right(jampulang, 2) & ":00")
                'Dbg("timein : " & Format(timein, "yyyy-MM-dd HH:mm:ss") & vbCrLf & _
                '    "timeout : " & Format(timeout, "yyyy-MM-dd HH:mm:ss"))
                strSQL = "select employee_id, status, jammasuk, jampulang, keterangan, useredited, dateedited " & vbCrLf & _
                         "from t_absen where employee_id='" & eid & "' and tgl='" & dtsql(dt) & "' "
                'Dbg(strSQL)
                dsA = Query(strSQL)
                If GetDSRecordCount(dsA) > 0 Then
                    'jika jam masuk yang sudah disave di trn absen, tidakkosong, tidak sama dengan 0000, tidak sama dengan jammasuk hasil get time
                    If Not IsDBNull(dsA.Tables(0).Rows(0).Item("jammasuk")) Then
                        jammasuk1 = dsA.Tables(0).Rows(0).Item("jammasuk").ToString.Trim
                        If jammasuk1 <> "0000" And jammasuk1 <> "" Then
                            If jammasuk1 <> jammasuk Then
                                If Not IsDBNull(dsA.Tables(0).Rows(0).Item("useredited")) Then
                                    If dsA.Tables(0).Rows(0).Item("useredited").ToString.Trim <> "" Then
                                        jammasuk = jammasuk1
                                    End If
                                End If
                            End If
                        End If
                    End If
                    If Not IsDBNull(dsA.Tables(0).Rows(0).Item("jampulang")) Then
                        jampulang1 = dsA.Tables(0).Rows(0).Item("jampulang").ToString.Trim
                        If jampulang1 <> "0000" And jampulang1 <> "" Then
                            If jampulang1 <> jampulang Then
                                If Not IsDBNull(dsA.Tables(0).Rows(0).Item("useredited")) Then
                                    If dsA.Tables(0).Rows(0).Item("useredited").ToString.Trim <> "" Then
                                        jampulang = jampulang1
                                    End If
                                End If
                            End If
                        End If
                    End If

                    status = getStatus(eid, dt, jammasuk, jampulang, masukroster, pulangroster)
                    'kalo status udah pernah diupdate maka status sesuai yang diupdate
                    If Not IsDBNull(dsA.Tables(0).Rows(0).Item("status")) Then
                        status1 = LCase(dsA.Tables(0).Rows(0).Item("status").ToString.Trim)
                        If status1 = "terlambat" Or status1 = "masuk" Then
                        Else
                            If Not IsDBNull(dsA.Tables(0).Rows(0).Item("useredited")) Then
                                If dsA.Tables(0).Rows(0).Item("useredited").ToString.Trim <> "" Then
                                    status = status1
                                End If
                            End If
                        End If
                    End If

                    'set timein dan timeout lg
                    timein = Date.Parse(Format(dt, "yyyy-MM-dd ") & _
                                    Microsoft.VisualBasic.Left(jammasuk, 2) & ":" & _
                                    Microsoft.VisualBasic.Right(jammasuk, 2) & ":00")
                    timeout = Date.Parse(Format(dt, "yyyy-MM-dd ") & _
                                         Microsoft.VisualBasic.Left(jampulang, 2) & ":" & _
                                         Microsoft.VisualBasic.Right(jampulang, 2) & ":00")

                    ket1 = ""
                    If Not IsDBNull(dsA.Tables(0).Rows(0).Item("keterangan")) Then
                        ket1 = LCase(dsA.Tables(0).Rows(0).Item("keterangan").ToString.Trim)
                    End If

                    strSQL = "update t_absen " & vbCrLf & _
                             "set nip='" & nip & "', fingercode='" & fgcode & "', name='" & name & "', " & vbCrLf & _
                             "status='" & StrConv(status, VbStrConv.ProperCase) & "', masukroster='" & masukroster & "', " & vbCrLf & _
                             "pulangroster='" & pulangroster & "', " & vbCrLf & _
                             "timein='" & Format(timein, "yyyy-MM-dd HH:mm:ss") & "', " & vbCrLf & _
                             "timeout='" & Format(timeout, "yyyy-MM-dd HH:mm:ss") & "', " & vbCrLf & _
                             "jammasuk='" & jammasuk & "', jampulang='" & jampulang & "', " & vbCrLf & _
                             "keterangan='" & ket1 & "', lokasimasuk='" & lokasiMasuk & "', " & vbCrLf & _
                             "lokasipulang='" & lokasiPulang & "' " & vbCrLf & _
                             "where employee_id='" & eid & "' and tgl='" & dtsql(dt) & "' "
                Else
                    strSQL = "insert into t_absen (employee_id, nip, fingercode, name, status, tgl, " & vbCrLf & _
                             "masukroster, pulangroster, timein, timeout, jammasuk, jampulang, keterangan, " & vbCrLf & _
                             "useradded, dateadded, lokasimasuk, lokasipulang) values ('" & eid & "', '" & nip & "', '" & fgcode & "', " & vbCrLf & _
                             "'" & name & "', '" & StrConv(status, VbStrConv.ProperCase) & "', '" & dtsql(dt) & "', '" & masukroster & "', " & vbCrLf & _
                             "'" & pulangroster & "', '" & Format(timein, "yyyy-MM-dd HH:mm:ss") & "', " & vbCrLf & _
                             "'" & Format(timeout, "yyyy-MM-dd HH:mm:ss") & "', '" & jammasuk & "', " & vbCrLf & _
                             "'" & jampulang & "', '', '" & UserLogin & "', '" & Format(Now, "yyyy-MM-dd HH:mm:ss") & "', " & vbCrLf & _
                             "'" & lokasiMasuk & "', '" & lokasiPulang & "' )"
                End If
                'Dbg(strSQL)
                ExecQuery(strSQL)
            End If
            dt = DateAdd(DateInterval.Day, x, dt1)
        Next
        clearDataSet(dsE)
    End Sub

    Sub TextToHasilScan()
        'BackgroundWorker.ReportProgress(CInt(100 * i / ds1.Tables(0).Rows.Count))
        Dim line, cfg, txt, foa, fog, datestr, jamstr, fgcode, kode, _
            eid, nip, name As String
        Dim no, total, prg As Integer
        Dim datapart As Array
        Dim dsa As DataSet
        Dim dt As DateTime

        cfg = ReadIni("HRD", "uploadcfg")
        txt = ReadIni("Smart2KWeb", "Output FileName", cfg)
        foa = ReadIni("HRD", "folderabsen")
        fog = ReadIni("HRD", "foldergenerate")
        'MsgOK(txt)
        total = File.ReadAllLines(txt).Length
        no = 0

        dsa = Query("select top 1 employee_id, nip, name from m_employee", StrConHRD)

        If total <= 0 Then
            clearDataSet(dsa)
            Exit Sub
        End If

        Using reader As StreamReader = New StreamReader(txt)
            line = reader.ReadLine 'perbaris
            Do While (Not line Is Nothing)
                prg = CInt((no * 100) / total)
                BackgroundWorker.ReportProgress(prg)
                datapart = Split(line, ",")
                If datapart.Length = 6 Then
                    datestr = datapart(1).ToString.Trim
                    datestr = Microsoft.VisualBasic.Mid(datestr, 7, 4) & "-" & _
                              Microsoft.VisualBasic.Mid(datestr, 4, 2) & "-" & _
                              Microsoft.VisualBasic.Mid(datestr, 1, 2)
                    jamstr = datapart(2).ToString.Trim
                    datestr = datestr & " " & jamstr
                    dt = Date.Parse(datestr)
                    fgcode = datapart(3).ToString.Trim
                    kode = datapart(5).ToString.Trim
                    eid = "" : nip = "" : name = ""
                    strProcess = "Proses Finger " & fgcode
                    dsa = Query("select employee_id, nip, name from m_employee where fingercode='" & fgcode & "'", StrConHRD)
                    If GetDSRecordCount(dsa) > 0 Then
                        eid = dsa.Tables(0).Rows(0).Item(0).ToString.Trim
                        nip = dsa.Tables(0).Rows(0).Item(1).ToString.Trim
                        name = dsa.Tables(0).Rows(0).Item(2).ToString.Trim
                    End If

                    dsa = Query("select * from t_finger where fingercode='" & fgcode & "' and " & vbCrLf & _
                                "tgl='" & datestr & "' and jam='" & jamstr & "' and kode='" & kode & "' ", StrConHRD)
                    If GetDSRecordCount(dsa) <= 0 Then
                        ExecQuery("insert into t_finger (employee_id, nip, fingercode, name, tgl, jam, kode, whscode, lokasi) " & vbCrLf & _
                                  "values ('" & eid & "', '" & nip & "', '" & fgcode & "', '" & name & "', " & vbCrLf & _
                                  "'" & datestr & "', '" & Format(dt, "HHmm") & "', '" & kode & "', 'HO01', '192.168.1.31' )", StrConHRD)
                    End If
                End If
                no += 1
                line = reader.ReadLine
            Loop
        End Using
        clearDataSet(dsa)
        File.Copy(txt, fog & "Generate_" & Format(Now, "yyyyMMddHHmmss") & ".txt")
        File.WriteAllText(txt, "")
    End Sub

    Sub UpdateMessageGenerate(ByVal idLog As String, ByVal msg As String)
        ExecQuery("update tbl_loggenerate set message=message + '" & msg & "' +'; ' where idloggen='" & idLog & "' ")
    End Sub
    Function ReadAttLOG(ByVal ZK As zkemkeeper.CZKEM, ByVal IP As String) As Boolean
        Dim sdwEnrollNumber As String = ""
        Dim idwErrorCode, idwWorkcode, idwSecond, idwMinute, idwHour, idwDay, _
            idwMonth, idwYear, idwInOutMode, idwVerifyMode As Integer
        Dim iGLCount As Integer = 0
        Dim tipe As Boolean
        Dim employee_ID, spgname, S, spgbarcode, fn As String
        Dim tgl As DateTime
        Dim dsF As DataSet
        dsF = Query("select top 1 employee_id, nip, tgl from t_finger")
        tipe = True
        ZK.EnableDevice(iMachineNumber, False) 'disable the device
        fn = FolderABSLOG & "FLOG_" & RightStr(IP, 2) & "_" & Format(dtGenerate, "ddMMyyhhmmss") & ".txt"
        'MsgOK(totalLog)
        If ZK.ReadGeneralLogData(iMachineNumber) Then 'read all the attendance records to the memory
            'get records from the memory
            While ZK.SSR_GetGeneralLogData(iMachineNumber, sdwEnrollNumber, idwVerifyMode, idwInOutMode, idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond, idwWorkcode)
                'iGLCount += 1
                no += 1
                BackgroundWorker.ReportProgress(CInt(100 * no / totalLog))
                'MsgOK("No : " & no & vbCrLf & _
                '      "TotalLog : " & totalLog & vbCrLf & _
                '      "Prg : " & CInt(100 * no / totalLog))
                tgl = New DateTime(idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond)
                employee_ID = getStringFromDB("select top 1 spg_id from m_employee_finger where whscode='HO01' and fingercode='" & sdwEnrollNumber & "' and tgl <= '" & Format(tgl, "yyyy-MM-dd") & "' order by tgl desc ")
                spgbarcode = getStringFromDB("select nip from m_employee where employee_id='" & employee_ID & "' ")
                spgname = getStringFromDB("select name from m_employee where employee_id='" & employee_ID & "' ")

                dsF = Query("select top 1 employee_id, nip, fingercode tgl from t_finger " & vbCrLf & _
                            "where fingercode='" & sdwEnrollNumber & "' and " & vbCrLf & _
                            "nip='" & spgbarcode & "' and " & vbCrLf & _
                            "tgl='" & Format(tgl, "yyyy-MM-dd HH:mm:ss.fff") & "' " & vbCrLf & _
                            "")

                If GetDSRecordCount(dsF) = 0 Then
                    ExecQuery("insert into t_finger (employee_id, nip, fingercode, name, tgl, jam, kode, whscode, lokasi) values " & vbCrLf & _
                              "( '" & employee_ID & "', '" & spgbarcode & "', '" & sdwEnrollNumber & "', '" & spgname & "', " & vbCrLf & _
                              "  '" & Format(tgl, "yyyy-MM-dd HH:mm:ss.fff") & "', '" & Format(tgl, "HHmm") & "', '" & idwInOutMode & "', " & vbCrLf & _
                              "'HO01', '" & IP & "') ")
                End If
                Using writer As New StreamWriter(fn, True)
                    writer.WriteLine(sdwEnrollNumber & ";" & employee_ID & ";" & spgbarcode & ";" & spgname & ";" & _
                                     Format(tgl, "yyyy-MM-dd HH:mm:ss.fff") & _
                                     ";" & Format(tgl, "HHmm") & ";" & idwInOutMode & ";" & IP)
                End Using

                'lvItem = lvLogs.Items.Add(iGLCount.ToString())
                'lvItem.SubItems.Add(sdwEnrollNumber)
                'lvItem.SubItems.Add(idwVerifyMode.ToString())
                'lvItem.SubItems.Add(idwInOutMode.ToString())
                'lvItem.SubItems.Add(idwYear.ToString() & "-" + idwMonth.ToString() & "-" & idwDay.ToString() & " " & idwHour.ToString() & ":" & idwMinute.ToString() & ":" & idwSecond.ToString())
                'lvItem.SubItems.Add(idwWorkcode.ToString())

            End While
        Else
            ZK.GetLastError(idwErrorCode)
            If idwErrorCode <> 0 Then
                tipe = False
                'ZK.get()
                S = "Reading data from IP " & IP & " failed, ErrorCode: " & idwErrorCode
                MsgError(S)
                UpdateMessageGenerate(numberx, S)
            Else
                tipe = False
                S = "No data from IP " & IP & " returns!"
            End If
        End If
        ZK.EnableDevice(iMachineNumber, True) 'enable the device
        clearDataSet(dsF)
        Return tipe
    End Function
    Sub FingerLogToDB()
        Dim dsf As DataSet
        Dim idwErrorCode, port, ivalue As Integer
        Dim ip As String

        dsf = QueryToDataset("select * from tbl_mesin order by ip")
        totalLog = 0
        For Each rf As DataRow In dsf.Tables(0).Rows
            port = CInt(rf("port").ToString.Trim)
            ip = rf("ip").ToString.Trim
            FConnect = ConnectFinger(ZK, ip, port)
            If FConnect = False Then
                errorCount += 1
                UpdateMessageGenerate(numberx, "Finger IP " & ip & " Connection Problem")
                Continue For
            End If

            ZK.EnableDevice(iMachineNumber, False) 'disable the device
            If ZK.GetDeviceStatus(iMachineNumber, 6, ivalue) = True Then 'Here we use the function "GetDeviceStatus" to get totalthe record's count.The parameter "Status" is 6.
                totalLog += ivalue
            Else
                ZK.GetLastError(idwErrorCode)
                ZK.EnableDevice(iMachineNumber, True) 'enable the device
                FConnect = DisconnectFinger(ZK)
                UpdateMessageGenerate(numberx, "Error Get Total Log For IP " & ip)
                Continue For
            End If
            ZK.EnableDevice(iMachineNumber, True) 'enable the device

            FConnect = DisconnectFinger(ZK)
        Next
        'MsgOK("Process Total")
        no = 0
        For Each rf As DataRow In dsf.Tables(0).Rows
            port = CInt(rf("port").ToString.Trim)
            ip = rf("ip").ToString.Trim
            FConnect = ConnectFinger(ZK, ip, port)
            If FConnect = False Then
                errorCount += 1
                'UpdateMessageGenerate(numberx, "Finger IP " & ip & " Connection Problem")
                Continue For
            End If
            'MsgOK("Process Connect")
            ''ini untuk ambil data mesin ke txt file dan ke trn_hasil_scan
            If ReadAttLOG(ZK, ip) = False Then
                errorCount += 1
                FConnect = DisconnectFinger(ZK)
                Continue For
            End If
            'MsgOK("Process Read ATT Log")
            ''ini untuk hapus fingerlog
            'MsgOK("Delete")
            If ClearLogFinger(ZK, iMachineNumber) = False Then
                'MsgOK("1")
                errorCount += 1
                FConnect = DisconnectFinger(ZK)
                UpdateMessageGenerate(numberx, "Error Delete LOG Finger IP " & ip)
                'MsgOK("2")
                Continue For
            End If
            'MsgOK("Process Delete Log")
            FConnect = DisconnectFinger(ZK)
            'MsgOK("Process Disconnect")
        Next
        clearDataSet(dsf)
    End Sub

    Private Sub btnProses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProses.Click
        dtGenerate = Now
        pBar.Value = 0
        pBar.Visible = True
        LblProses.Text = ""
        LblProses.Visible = True
        BackgroundWorker.WorkerReportsProgress = True
        BackgroundWorker.WorkerSupportsCancellation = True
        BackgroundWorker.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker.DoWork
        'TextToHasilScan()
        FingerLogToDB()
        Dim ds1 As DataSet
        Dim s, z, nip As String
        nip = ""

        If cbxChoose.Checked Then
            For x = 0 To dg.RowCount - 1
                If CInt(dg.Item(0, x).Value.ToString.Trim) = 1 Then
                    nip = nip & "'" & dg.Item(1, x).Value.ToString.Trim & "',"
                End If
            Next
            If nip.Trim = "" Then
                nip = " (9=9) "
            Else
                nip = " e.employee_id in ( " & Mid(nip, 1, Len(nip) - 1) & " ) "
            End If
        Else
            nip = " (9=9) "
        End If

        z = " (1=1) "
        strSQL = "select e.employee_id, e.nip, e.fingercode, e.name from m_employee e " & vbCrLf & _
                 "where " & nip & " and isdelete=0 and unit_id=1 and isactive=1 order by e.name "
        'Dbg(strSQL)
        ds1 = Query(strSQL, StrConHRD)
        'pBar.Value = 0
        For i As Integer = 0 To ds1.Tables(0).Rows.Count - 1
            'MsgOK(ds1.Tables(0).Rows(i).Item("name"))
            processSCANtoABSEN(ds1.Tables(0).Rows(i).Item("employee_id"), dtgen.Value, dtgen2.Value)
            'ExecQuery()
            strProcess = "Proses Absen " & ds1.Tables(0).Rows(i).Item(3).ToString.Trim
            BackgroundWorker.ReportProgress(CInt(100 * i / ds1.Tables(0).Rows.Count))
        Next
        s = "insert into t_loggenerate (usergenerate, tgl) values ('" & UserLogin & "', " & vbCrLf & _
            "'" & Format(Now, "yyyy-MM-dd HH:mm:ss") & "' )"
        ExecQuery(s, StrConHRD)
    End Sub
    Private Sub BackgroundWorker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker.ProgressChanged
        pBar.Value = e.ProgressPercentage
        LblProses.Text = strProcess
        'Label1.Text = "Percentage Progress = " & pBar.Value.ToString & "%"
    End Sub

    Private Sub BackgroundWorker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker.RunWorkerCompleted
        pBar.Value = 0
        pBar.Visible = False
        pBar.Minimum = 0
        Label1.Text = ""
        LblProses.Text = ""
        LblProses.Visible = False
        BackgroundWorker.WorkerReportsProgress = False
        BackgroundWorker.WorkerSupportsCancellation = False
        'MDI.ssDate2.Text = Format(Date.Now, "yyyy-MM-dd HH:mm:ss")
        'MDI.ssusergen1.Text = UserLogin
        MsgOK("Proses Tarik Absen Telah Selesai")
        Close()
    End Sub


    



#Region "FORM"
    Private Sub FrmGenerate_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'BackgroundWorker.CancelAsync()
        CloseDBALL()
    End Sub
    Private Sub FrmGenerate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OpenDBHRD()
        'Dim ico As New System.Drawing.Icon(LokasiICOFile) : Me.Icon = ico
        'btnProses.Image = Image.FromFile(FolderImage & "reload.png")
        Me.Height = 127
        GbPilih.Visible = False
        dtgen.Value = Now
        dtgen2.Value = Now
        cbxChoose.Checked = False
        pBar.Visible = False
        pBar.Value = 0
    End Sub
#End Region
#Region "Tampil Karyawan"
    Private Sub cbxHilang_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxHilang.CheckedChanged
        If cbxHilang.Checked Then
            cbxPilih.Checked = False
            isiChooseALL(0)
        Else
            cbxPilih.Checked = True
            isiChooseALL(1)
        End If
    End Sub
    Private Sub cbxPilih_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxPilih.CheckedChanged
        If cbxPilih.Checked Then
            cbxHilang.Checked = False
            isiChooseALL(1)
        Else
            cbxHilang.Checked = True
            isiChooseALL(0)
        End If
    End Sub
    Sub isiChooseALL(ByVal pilih As Integer)
        If dg.RowCount = 0 Then Exit Sub
        Dim x As Integer
        For x = 0 To dg.RowCount - 1
            dg.Item(0, x).Value = pilih
        Next
    End Sub
    Private Sub cbxChoose_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxChoose.CheckedChanged
        If cbxChoose.Checked Then
            txtCari.Clear()
            TampilKaryawan(txtCari.Text.Trim)
            Me.Height = 445
            GbPilih.Visible = True
            txtCari.Focus()
        Else
            Me.Height = 127
            GbPilih.Visible = False
        End If
    End Sub

    Private Sub txtCari_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCari.KeyDown
        If e.KeyCode = Keys.Down Then
            dg.Focus()
        End If
    End Sub
    Private Sub txtCari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCari.TextChanged
        NavSource1.Filter = " (name like '%" & txtCari.Text.Trim & "%') or (nip like '%" & txtCari.Text.Trim & "%') "
    End Sub
    Sub TampilKaryawan(ByVal txt As String)
        Dim SQL As String
        Dim dsKar As New DataSet

        SQL = "select 0 as choose, employee_id, nip, name, departmentname, bagianname, jabatanname, unitname " & vbCrLf & _
              "from v_employee " & vbCrLf & _
              "where " & vbCrLf & _
              "unitcode='S000' and isdelete=0 and " & vbCrLf & _
              " isactive='YES' and (nip like '%" & txtCari.Text.Trim & "%' or name like '%" & txtCari.Text.Trim & "%') " & vbCrLf & _
              "order by name"
        'Dbg(SQL)
        cbxHilang.Checked = False
        dsKar = Query(SQL, StrConHRD)
        dg.DataSource = dsKar.Tables(0)
        NavSource1.DataSource = dsKar.Tables(0)
        If dsKar.Tables(0).Rows.Count > 0 Then
            dg.Refresh()
        Else
            MsgError("No Data")
        End If
    End Sub
#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'FirstDayOfWeek = 1
        'If dtgen.Value.Day = vbFriday Then
        '    MsgOK("tes")
        'End If
        'MsgOK(dtgen.Value.DayOfWeek)

        MsgOK(Weekday(dtgen.Value, FirstDayOfWeek.Sunday))
    End Sub
End Class