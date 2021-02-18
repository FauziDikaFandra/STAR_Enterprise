Public Class UserFingerForm
    Public ZK As New zkemkeeper.CZKEM
    Dim FConnect As Boolean = False 'the boolean value identifies whether the device is connected
    Dim iMachineNumber As Integer 'In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
    Dim port As Integer
    Dim store, ip As String
    Sub LoadImage()
        'Dim ico As New System.Drawing.Icon(FolderImage & "star.ico") : Me.Icon = ico
        'BtnReload.Image = Image.FromFile(FolderImage & "reload16.png")
        'BtnDateTemplate.Image = Image.FromFile(FolderImage & "date16.png")
        'BtnPrint.Image = Image.FromFile(FolderImage & "print16.png")
        'BtnMenu.Image = Image.FromFile(FolderImage & "menu16.png")
        'BtnAdd.Image = Image.FromFile(FolderImage & "add16.png")
        'BtnEdit.Image = Image.FromFile(FolderImage & "edit16.png")
        'BtnDelete.Image = Image.FromFile(FolderImage & "delete16.png")
        'BtnClose.Image = Image.FromFile(FolderImage & "close16.png")
        Dim ico As New System.Drawing.Icon(FolderImage & "star.ico") : Me.Icon = ico
        'BtnReload.Image = Image.FromFile(FolderImage & "reload16.png")
        'BtnDateTemplate.Image = Image.FromFile(FolderImage & "date16.png")
        'BtnPrint.Image = Image.FromFile(FolderImage & "32print.png")
        'BtnMenu.Image = Image.FromFile(FolderImage & "32menu.png")
        'BtnAdd.Image = Image.FromFile(FolderImage & "32add.png")
        'BtnEdit.Image = Image.FromFile(FolderImage & "32edit.png")
        'BtnDelete.Image = Image.FromFile(FolderImage & "32delete.png")
        'BtnClose.Image = Image.FromFile(FolderImage & "32close.png")
    End Sub
    Private Sub UserFingerForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadImage()
        'Dim dss As DataSet

        'OpenDB_ABS_S001()
        'dss = Query("select branch_id from tbl_branches")
        'MsgOK(getDSString(dss, 0, "branch_id"))

        'OpenDB_ABS_S002()
        'dss = Query("select branch_id from tbl_branches")
        'MsgOK(getDSString(dss, 0, "branch_id"))

        'OpenDB_ABS_S003()
        'dss = Query("select branch_id from tbl_branches")
        'MsgOK(getDSString(dss, 0, "branch_id"))

        'OpenDB_POSSERVER_S001()
        'dss = Query("select branch_id from branches")
        'MsgOK(getDSString(dss, 0, "branch_id"))

        'OpenDB_POSSERVER_S002()
        'dss = Query("select branch_id from branches")
        'MsgOK(getDSString(dss, 0, "branch_id"))

        'OpenDB_POSSERVER_S003()
        'dss = Query("select branch_id from branches")
        'MsgOK(getDSString(dss, 0, "branch_id"))

        'clearDataSet(dss)

        txtIP.Items.Clear()
        txtStore.Items.Clear()
        isiComboStore()
    End Sub
    Sub isiComboStore()
        OpenDBHRD()
        Dim q As New VQuery
        q.Query("select whscode from store order by whscode", "whscode")
        While Not q.EOF
            'MsgOK(q.GetField("whscode"))
            txtStore.Items.Add(q.GetField("whscode"))
            q.NextRecord()
        End While
        q.Dispose()
    End Sub
    Sub OpenDB_ABS(ByVal store As String)
        If store = "ho01" Then
            OpenDBHRD()
        ElseIf store = "s001" Then
            OpenDB_ABS_S001()
        ElseIf store = "s002" Then
            OpenDB_ABS_S002()
        ElseIf store = "s003" Then
            OpenDB_ABS_S003()
        End If
    End Sub
    Sub isiComboIP()
        Dim store As String
        store = LCase(txtStore.Text.ToString.Trim)
        OpenDB_ABS(store)

        txtIP.Items.Clear()
        Dim q As New VQuery
        q.Query("select ip from tbl_mesin where utama=1 order by ip", "ip")
        While Not q.EOF
            txtIP.Items.Add(q.GetField("ip"))
            q.NextRecord()
        End While
        q.Dispose()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtStore_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStore.SelectedIndexChanged
        isiComboIP()
    End Sub

    Private Sub BtnLihat1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLihat1.Click
        OpenDB_ABS(txtStore.Text.ToString.Trim)
        Dim q As New VQuery
        q.Query("select * from TBL_MESIN where ip='" & txtIP.Text.Trim & "' ", "ip")
        port = q.GetField("port")
        ip = q.GetField("ip")
        q.Dispose()
        store = txtStore.Text.ToString.Trim
        pBar.Value = 0
        pBar.Visible = True
        BackgroundWorker1.WorkerReportsProgress = True
        BackgroundWorker1.WorkerSupportsCancellation = True
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        FConnect = ConnectFinger(ZK, ip, port)
        If FConnect = False Then
            BackgroundWorker1.CancelAsync()
            Exit Sub
        End If
        ReadUserFinger()
    End Sub
    Sub ReadUserFinger()
        Dim iMachineNumber As Integer
        Dim sdwEnrollNumber As String = ""
        Dim sName As String = ""
        Dim sPassword As String = ""
        Dim iPrivilege As Integer
        Dim bEnabled As Boolean = False
        Dim idwFingerIndex As Integer
        Dim sTmpData As String = ""
        Dim iTmpLength As Integer
        Dim iFlag, no As Integer
        Dim spg_id, ena, st As String
        'Dim lvItem As New ListViewItem("Items", 0)

        iMachineNumber = 1

        ZK.EnableDevice(iMachineNumber, False)
        ZK.ReadAllUserID(iMachineNumber) 'read all the user information to the memory
        ZK.ReadAllTemplate(iMachineNumber) 'read all the users' fingerprint templates to the memory
        'ZK.GetAllUserID()
        no = 1
        Dim dsf As DataSet
        dsf = Query("select top 1 * from m_finger")
        While ZK.SSR_GetAllUserInfo(iMachineNumber, sdwEnrollNumber, sName, sPassword, iPrivilege, bEnabled) = True  'get all the users' information from the memory
            BackgroundWorker1.ReportProgress(CInt(100 * no / 2000))
            For idwFingerIndex = 0 To 9
                If ZK.GetUserTmpExStr(iMachineNumber, sdwEnrollNumber, idwFingerIndex, iFlag, sTmpData, iTmpLength) Then 'get the corresponding templates string and length from the memory
                    'Bw.ReportProgress(CInt(100 * no / total))
                    If bEnabled Then : ena = "1" : Else : ena = "0" : End If
                    'dg1.Rows.Add("0", sdwEnrollNumber.ToString(), sName, idwFingerIndex.ToString(), sTmpData, iPrivilege.ToString(), sPassword, ena, iFlag.ToString())

                    'spg_id = getStringFromDB("select spg_id from m_employee_finger where whscode='" & store & "' ")
                    spg_id = getStringFromDB("select top 1 spg_id from m_employee_finger where fingercode='" & sdwEnrollNumber & "' and tgl <= '" & Format(Now, "yyyy-MM-dd") & "' order by tgl desc ")
                    st = "S001"
                    If CInt(sdwEnrollNumber) <= 999 Then st = "HO01"
                    If CInt(sdwEnrollNumber) >= 1000 And CInt(sdwEnrollNumber) <= 2999 Then st = "S001"
                    If CInt(sdwEnrollNumber) >= 3000 And CInt(sdwEnrollNumber) <= 4999 Then st = "S002"
                    If CInt(sdwEnrollNumber) >= 5000 And CInt(sdwEnrollNumber) <= 6999 Then st = "S003"

                    dsf = Query("select * from m_finger where fingercode='" & sdwEnrollNumber.ToString() & "' " & _
                              "and whscode='" & st & "' and fingerindex='" & idwFingerIndex.ToString & "' ")
                    If dsf.Tables(0).Rows.Count > 0 Then
                        ExecQuery("update m_finger set whscode='" & st & "', isdelete=0, isactive=1, " & vbCrLf & _
                                  "spg_id='" & spg_id & "', fingercode='" & sdwEnrollNumber.ToString() & "', " & vbCrLf & _
                                  "spg_name='" & sName & "', fingerindex='" & idwFingerIndex.ToString & "', " & vbCrLf & _
                                  "tmp_data='" & sTmpData & "', privelege='" & iPrivilege.ToString() & "', " & vbCrLf & _
                                  "pass='" & sPassword & "', enable='" & ena & "', " & vbCrLf & _
                                  "flag='" & iFlag.ToString() & "' where fingercode='" & sdwEnrollNumber.ToString() & "' " & vbCrLf & _
                                  "and whscode='" & store & "' and fingerindex='" & idwFingerIndex.ToString & "'")
                    Else
                        ExecQuery("insert into m_finger (whscode, isdelete, isactive, spg_id, fingercode, spg_name, " & _
                              "fingerindex, tmp_data, privelege, pass, enable, flag) " & _
                              "values ('" & st & "', 0, 1, '" & spg_id & "', '" & sdwEnrollNumber.ToString() & "', " & _
                              "'" & sName & "', '" & idwFingerIndex.ToString & "', '" & sTmpData & "', " & _
                              "'" & iPrivilege.ToString() & "', '" & sPassword & "', '" & ena & "', '" & iFlag.ToString() & "')")
                    End If
                End If
            Next
            no += 1
        End While
        no = 2000
        BackgroundWorker1.ReportProgress(CInt(100 * no / 2000))
        ZK.EnableDevice(iMachineNumber, True)
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        pBar.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        FConnect = DisconnectFinger(ZK)
        pBar.Value = 0
        pBar.Visible = False
        'Lbl1.Text = 
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        OpenDB_ABS(txtStore.Text.ToString.Trim)
        store = txtStore.Text.ToString.Trim
        pBar.Value = 0
        pBar.Visible = True
        BackgroundWorker2.WorkerReportsProgress = True
        BackgroundWorker2.WorkerSupportsCancellation = True
        BackgroundWorker2.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Dim tb As String
        tb = " select employee_id as spg_id, fingercode, name as spg_name from m_employee "
        If LCase(store) <> "ho01" Then
            tb = " select spg_id, fingercode, spg_name from tbl_karyawan "
            ExecQuery("update a " & vbCrLf & _
                        "a.kd_bagian = b.kd_bagian " & vbCrLf & _
                        "from m_finger a " & vbCrLf & _
                        "inner join ( select spg_id, kd_bagian from TBL_KARYAWAN ) b on a.spg_id=b.spg_id " & vbCrLf & _
                        "where a.whscode='" & store & "'")

        End If
        ExecQuery("update a " & vbCrLf & _
                  "set a.spg_name = b.spg_name " & vbCrLf & _
                  "from m_finger a inner join (" & tb & ") b " & vbCrLf & _
                  "on a.spg_id=b.spg_id " & vbCrLf & _
                  "where a.whscode='" & store & "' ")

        Dim q As New VQuery

        q.Query("select * from tbl_mesin order by ip", "ip")
        While Not q.EOF
            port = q.GetField("port")
            ip = q.GetField("ip")
            FConnect = ConnectFinger(ZK, ip, port)
            If FConnect = False Then
                BackgroundWorker2.CancelAsync()
                Exit Sub
            End If
            DeleteALLUserFinger(ZK)
            dbToFinger(ZK)
            FConnect = DisconnectFinger(ZK)
            q.NextRecord()
        End While
        q.Dispose()
    End Sub

    Private Sub BackgroundWorker2_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker2.ProgressChanged
        pBar.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker2_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        pBar.Value = 0
        pBar.Visible = False
        MsgOK("Finished")
    End Sub
    Sub dbToFinger(ByVal ZK As zkemkeeper.CZKEM)
        Dim iUpdateFlag As Integer = 1

        Dim idwErrorCode As Integer
        Dim sdwEnrollNumber As String = ""
        Dim sName As String = ""
        Dim sPassword As String = ""
        Dim iPrivilege As Integer
        Dim idwFingerIndex As Integer
        Dim sTmpData As String = ""
        Dim sEnabled As String = ""
        Dim bEnabled As Boolean = False
        Dim iflag As Integer


        'Dim lvItem As New ListViewItem
        Dim iMachineNumber As Integer = 1

        ZK.EnableDevice(iMachineNumber, False)

        Dim q As New VQuery
        BackgroundWorker2.ReportProgress(0)
        If ZK.BeginBatchUpdate(iMachineNumber, iUpdateFlag) Then 'create memory space for batching data
            Dim iLastEnrollNumber As Integer = 0 'the former enrollnumber you have upload(define original value as 0)
            'q.Query("select * from m_finger where whscode='HO01' " & vbCrLf & _
            '        "union all " & vbCrLf & _
            '        "select * from m_finger where whscode='S003' " & vbCrLf & _
            '        "order by whscode, fingercode", "whscode,fingercode")
            q.Query("select * from m_finger  " & vbCrLf & _
                   "order by whscode, fingercode", "whscode,fingercode")
            While Not q.EOF
                BackgroundWorker2.ReportProgress(CInt(100 * (q.RecNo + 1) / q.RecordCount))
                sdwEnrollNumber = Convert.ToInt32(q.GetField("fingercode"))
                sName = q.GetField("spg_name")
                idwFingerIndex = q.GetField("fingerindex")
                sTmpData = q.GetField("tmp_data")
                iPrivilege = Convert.ToInt32(q.GetField("privelege"))
                sPassword = q.GetField("pass")
                sEnabled = q.GetField("enable")
                iflag = q.GetField("flag")

                If sEnabled = "1" Then
                    bEnabled = True
                Else
                    bEnabled = False
                End If
                'ZK.SetUserInfo(
                If sdwEnrollNumber <> iLastEnrollNumber Then 'identify whether the user information(except fingerprint templates) has been uploaded
                    If ZK.SSR_SetUserInfo(iMachineNumber, sdwEnrollNumber, sName, sPassword, iPrivilege, bEnabled) Then 'upload user information to the device
                        ZK.SetUserTmpExStr(iMachineNumber, sdwEnrollNumber, idwFingerIndex, iflag, sTmpData) 'upload templates information to the device
                    Else
                        ZK.GetLastError(idwErrorCode)
                        MsgError("Operation failed Copy Finger,ErrorCode=" & idwErrorCode.ToString())
                        'Cursor = Cursors.Default
                        ZK.EnableDevice(iMachineNumber, True)
                        Return
                    End If
                Else 'the current fingerprint and the former one belongs the same user,that is ,one user has more than one template
                    ZK.SetUserTmpExStr(iMachineNumber, sdwEnrollNumber, idwFingerIndex, iflag, sTmpData) 'upload tempates information to the memory
                End If
                iLastEnrollNumber = sdwEnrollNumber 'change the value of iLastEnrollNumber dynamicly

                q.NextRecord()
            End While
        End If

        ZK.BatchUpdate(iMachineNumber) 'upload all the information in the memory
        ZK.RefreshData(iMachineNumber) 'the data in the device should be refreshed
        ZK.EnableDevice(iMachineNumber, True)
    End Sub

    Private Sub BackgroundWorker3_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker3.DoWork
        OpenDBHRD()
        Dim q As New VQuery
        Dim toko As String
        q.Query("select * from f_mesin order by whscode, utama desc ", "ip")
        While Not q.EOF
            BackgroundWorker3.ReportProgress(0)
            port = q.GetField("port")
            ip = q.GetField("ip")
            toko = q.GetField("whscode")
            FConnect = ConnectFinger(ZK, ip, port)
            If FConnect = False Then
                BackgroundWorker3.CancelAsync()
                Exit Sub
            End If
            DeleteALLUserFinger(ZK)
            UploadFinger(ZK, toko)
            FConnect = DisconnectFinger(ZK)
            q.NextRecord()
        End While
        q.Dispose()

    End Sub
    Sub UploadFinger(ByVal ZK As zkemkeeper.CZKEM, ByVal Toko As String)
        Toko = LCase(Toko)
        Dim iUpdateFlag As Integer = 1
        Dim idwErrorCode As Integer
        Dim sdwEnrollNumber As String = ""
        Dim sName As String = ""
        Dim sPassword As String = ""
        Dim iPrivilege As Integer
        Dim idwFingerIndex As Integer
        Dim sTmpData As String = ""
        Dim sEnabled As String = ""
        Dim bEnabled As Boolean = False
        Dim iflag As Integer
        Dim iMachineNumber As Integer = 1
        ZK.EnableDevice(iMachineNumber, False)

        Dim q As New VQuery
        BackgroundWorker3.ReportProgress(0)
        If ZK.BeginBatchUpdate(iMachineNumber, iUpdateFlag) Then 'create memory space for batching data
            Dim iLastEnrollNumber As Integer = 0 'the former enrollnumber you have upload(define original value as 0)
            If Toko = "ho01" Then                
                q.Query("select * from m_finger " & vbCrLf & _
                        "where whscode='HO01' " & vbCrLf & _
                        "union " & vbCrLf & _
                        "select f.* from m_finger f " & vbCrLf & _
                        "inner join f_bagian b on f.whscode=b.whscode and f.kd_bagian=b.kd_bagian " & vbCrLf & _
                        "where f.whscode<>'HO01' " & vbCrLf & _
                        "order by fingercode,fingerindex", "fingercode,fingerindex")
            Else
                q.Query("select * from m_finger " & vbCrLf & _
                        "where whscode='HO01' " & vbCrLf & _
                        "union " & vbCrLf & _
                        "select * from m_finger " & vbCrLf & _
                        "where whscode='" & Toko & "' " & vbCrLf & _
                        "UNION " & vbCrLf & _
                        "select f.* from m_finger f " & vbCrLf & _
                        "inner join f_bagian b on f.whscode=b.whscode and f.kd_bagian=b.kd_bagian " & vbCrLf & _
                        "where f.whscode not in ('HO01', '" & Toko & "') " & vbCrLf & _
                        "ORDER BY fingercode, fingerindex", "fingercode,fingerindex")
            End If

            'q.Query("select * from m_finger where whscode='HO01' " & vbCrLf & _
            '        "union all " & vbCrLf & _
            '        "select * from m_finger where whscode='S003' " & vbCrLf & _
            '        "order by whscode, fingercode", "whscode,fingercode")

            'q.Query("select * from m_finger  " & vbCrLf & _
            '       "order by whscode, fingercode", "whscode,fingercode")
            While Not q.EOF
                BackgroundWorker3.ReportProgress(CInt(100 * (q.RecNo + 1) / q.RecordCount))
                sdwEnrollNumber = Convert.ToInt32(q.GetField("fingercode"))
                sName = q.GetField("spg_name")
                idwFingerIndex = q.GetField("fingerindex")
                sTmpData = q.GetField("tmp_data")
                iPrivilege = Convert.ToInt32(q.GetField("privelege"))
                sPassword = q.GetField("pass")
                sEnabled = q.GetField("enable")
                iflag = q.GetField("flag")

                If sEnabled = "1" Then
                    bEnabled = True
                Else
                    bEnabled = False
                End If
                'ZK.SetUserInfo(
                If sdwEnrollNumber <> iLastEnrollNumber Then 'identify whether the user information(except fingerprint templates) has been uploaded
                    If ZK.SSR_SetUserInfo(iMachineNumber, sdwEnrollNumber, sName, sPassword, iPrivilege, bEnabled) Then 'upload user information to the device
                        ZK.SetUserTmpExStr(iMachineNumber, sdwEnrollNumber, idwFingerIndex, iflag, sTmpData) 'upload templates information to the device
                    Else
                        ZK.GetLastError(idwErrorCode)
                        MsgError("Operation failed Copy Finger,ErrorCode=" & idwErrorCode.ToString())
                        'Cursor = Cursors.Default
                        ZK.EnableDevice(iMachineNumber, True)
                        Return
                    End If
                Else 'the current fingerprint and the former one belongs the same user,that is ,one user has more than one template
                    ZK.SetUserTmpExStr(iMachineNumber, sdwEnrollNumber, idwFingerIndex, iflag, sTmpData) 'upload tempates information to the memory
                End If
                iLastEnrollNumber = sdwEnrollNumber 'change the value of iLastEnrollNumber dynamicly

                q.NextRecord()
            End While
        End If

        ZK.BatchUpdate(iMachineNumber) 'upload all the information in the memory
        ZK.RefreshData(iMachineNumber) 'the data in the device should be refreshed
        ZK.EnableDevice(iMachineNumber, True)
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MsgConfirm("Yakin...?") = vbNo Then
            Exit Sub
        End If
        OpenDBHRD()
        pBar.Value = 0
        pBar.Visible = True
        BackgroundWorker3.WorkerReportsProgress = True
        BackgroundWorker3.WorkerSupportsCancellation = True
        BackgroundWorker3.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker3_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker3.ProgressChanged
        pBar.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker3_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker3.RunWorkerCompleted
        pBar.Value = 0
        pBar.Visible = False
        MsgOK("Finished")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If MsgConfirm("Yakin...?") = vbNo Then
            Exit Sub
        End If
        OpenDBHRD()
        pBar.Value = 0
        pBar.Visible = True
        BackgroundWorker4.WorkerReportsProgress = True
        BackgroundWorker4.WorkerSupportsCancellation = True
        BackgroundWorker4.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker4_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker4.DoWork
        Dim q As New VQuery
        Dim toko As String
        q.Query("select * from f_mesin where utama=1 order by whscode, utama desc ", "ip")
        While Not q.EOF
            BackgroundWorker4.ReportProgress(0)
            port = q.GetField("port")
            ip = q.GetField("ip")
            toko = q.GetField("whscode")
            FConnect = ConnectFinger(ZK, ip, port)
            If FConnect = False Then
                BackgroundWorker4.CancelAsync()
                Exit Sub
            End If
            DeleteALLUserFinger(ZK)
            DownloadFinger(ZK, toko)
            FConnect = DisconnectFinger(ZK)
            q.NextRecord()
        End While
        q.Dispose()
    End Sub
    Private Sub BackgroundWorker4_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker4.ProgressChanged
        pBar.Value = e.ProgressPercentage
    End Sub
    Private Sub BackgroundWorker4_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker4.RunWorkerCompleted
        pBar.Value = 0
        pBar.Visible = False
        MsgOK("Finished")
    End Sub
    Sub DownloadFinger(ByVal ZK As zkemkeeper.CZKEM, ByVal Toko As String)
        Toko = LCase(Toko)
        If Toko = "ho01" Then
            OpenDBHRD()
        ElseIf Toko = "s001" Then
            OpenDB_ABS_S001()
        ElseIf Toko = "s002" Then
            OpenDB_ABS_S002()
        ElseIf Toko = "s003" Then
            OpenDB_ABS_S003()
        End If

        Dim iMachineNumber As Integer
        Dim sdwEnrollNumber As String = ""
        Dim sName As String = ""
        Dim sPassword As String = ""
        Dim iPrivilege As Integer
        Dim bEnabled As Boolean = False
        Dim idwFingerIndex As Integer
        Dim sTmpData As String = ""
        Dim iTmpLength As Integer
        Dim iFlag, no As Integer
        Dim spg_id, ena, st As String
        'Dim lvItem As New ListViewItem("Items", 0)

        iMachineNumber = 1

        ZK.EnableDevice(iMachineNumber, False)
        ZK.ReadAllUserID(iMachineNumber) 'read all the user information to the memory
        ZK.ReadAllTemplate(iMachineNumber) 'read all the users' fingerprint templates to the memory
        'ZK.GetAllUserID()
        no = 1
        Dim dsf As DataSet
        dsf = Query("select top 1 * from m_finger")
        While ZK.SSR_GetAllUserInfo(iMachineNumber, sdwEnrollNumber, sName, sPassword, iPrivilege, bEnabled) = True  'get all the users' information from the memory
            BackgroundWorker4.ReportProgress(CInt(100 * no / 2000))
            For idwFingerIndex = 0 To 9
                If ZK.GetUserTmpExStr(iMachineNumber, sdwEnrollNumber, idwFingerIndex, iFlag, sTmpData, iTmpLength) Then 'get the corresponding templates string and length from the memory
                    'Bw.ReportProgress(CInt(100 * no / total))
                    If bEnabled Then : ena = "1" : Else : ena = "0" : End If
                    'dg1.Rows.Add("0", sdwEnrollNumber.ToString(), sName, idwFingerIndex.ToString(), sTmpData, iPrivilege.ToString(), sPassword, ena, iFlag.ToString())

                    'spg_id = getStringFromDB("select spg_id from m_employee_finger where whscode='" & store & "' ")
                    spg_id = getStringFromDB("select top 1 spg_id from m_employee_finger where fingercode='" & sdwEnrollNumber & "' and tgl <= '" & Format(Now, "yyyy-MM-dd") & "' order by tgl desc ")
                    If sName = "" Then
                        If Toko = "ho01" Then
                            sName = getStringFromDB("select top 1 name from m_employee where employee_id='" & spg_id & "' ")
                        Else
                            sName = getStringFromDB("select top 1 spg_name from tbl_karyawan where spg_id='" & spg_id & "' ")
                        End If
                    End If
                    st = "S001"
                    If CInt(sdwEnrollNumber) <= 999 Then st = "HO01"
                    If CInt(sdwEnrollNumber) >= 1000 And CInt(sdwEnrollNumber) <= 2999 Then st = "S001"
                    If CInt(sdwEnrollNumber) >= 3000 And CInt(sdwEnrollNumber) <= 4999 Then st = "S002"
                    If CInt(sdwEnrollNumber) >= 5000 And CInt(sdwEnrollNumber) <= 6999 Then st = "S003"

                    dsf = Query("select * from m_finger where fingercode='" & sdwEnrollNumber.ToString() & "' " & _
                              "and whscode='" & st & "' and fingerindex='" & idwFingerIndex.ToString & "' ")
                    If dsf.Tables(0).Rows.Count > 0 Then
                        ExecQuery("update m_finger set whscode='" & st & "', isdelete=0, isactive=1, " & vbCrLf & _
                                  "spg_id='" & spg_id & "', fingercode='" & sdwEnrollNumber.ToString() & "', " & vbCrLf & _
                                  "spg_name='" & sName & "', fingerindex='" & idwFingerIndex.ToString & "', " & vbCrLf & _
                                  "tmp_data='" & sTmpData & "', privelege='" & iPrivilege.ToString() & "', " & vbCrLf & _
                                  "pass='" & sPassword & "', enable='" & ena & "', " & vbCrLf & _
                                  "flag='" & iFlag.ToString() & "' where fingercode='" & sdwEnrollNumber.ToString() & "' " & vbCrLf & _
                                  "and whscode='" & store & "' and fingerindex='" & idwFingerIndex.ToString & "'")
                    Else
                        ExecQuery("insert into m_finger (whscode, isdelete, isactive, spg_id, fingercode, spg_name, " & _
                              "fingerindex, tmp_data, privelege, pass, enable, flag) " & _
                              "values ('" & st & "', 0, 1, '" & spg_id & "', '" & sdwEnrollNumber.ToString() & "', " & _
                              "'" & sName & "', '" & idwFingerIndex.ToString & "', '" & sTmpData & "', " & _
                              "'" & iPrivilege.ToString() & "', '" & sPassword & "', '" & ena & "', '" & iFlag.ToString() & "')")
                    End If
                End If
            Next
            no += 1
        End While
        no = 2000
        BackgroundWorker4.ReportProgress(CInt(100 * no / 2000))
        ZK.EnableDevice(iMachineNumber, True)
    End Sub
End Class