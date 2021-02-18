Public Class FrmFinger
    'connect finger
    'dim idwErrorCode As Integer
    'Dim port As Integer
    'Dim ip As String
    'Cursor = Cursors.WaitCursor
    'If FConnect Then
    '    ZK.Disconnect()
    '    FConnect = False
    '    Cursor = Cursors.Default
    '    Return
    'End If
    'port = CInt(getStringDB("select port from tbl_mesin where nama='" & CboFinger1.Text.Trim & "' "))
    'ip = getStringDB("select ip from tbl_mesin where nama='" & CboFinger1.Text.Trim & "' ")
    'MsgOK(port)
    'MsgOK(ip)
    'FConnect = ZK.Connect_Net(ip, port)
    'If FConnect = True Then
    '    iMachineNumber = 1 'In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
    '    ZK.RegEvent(iMachineNumber, 65535) 'Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
    '    MsgOK("OK")
    'Else
    '    ZK.GetLastError(idwErrorCode)
    '    MsgError("Unable to connect the device,ErrorCode=" & idwErrorCode)
    '    Cursor = Cursors.Default
    '    Exit Sub
    'End If

    'ZK.Disconnect()
    'FConnect = False
    'Cursor = Cursors.Default
    '-------------------------
    'read user
    'Dim sdwEnrollNumber As String = ""
    'Dim sName As String = ""
    'Dim sPassword As String = ""
    'Dim iPrivilege As Integer
    'Dim bEnabled As Boolean = False
    'Dim idwFingerIndex As Integer
    'Dim sTmpData As String = ""
    'Dim iTmpLength As Integer
    'Dim iFlag As Integer
    'Dim lvItem As New ListViewItem("Items", 0)
    'iMachineNumber = 1
    'LV1.Items.Clear()
    'LV1.BeginUpdate()
    'ZK.EnableDevice(iMachineNumber, False)

    'Cursor = Cursors.WaitCursor
    'ZK.ReadAllUserID(iMachineNumber) 'read all the user information to the memory
    'ZK.ReadAllTemplate(iMachineNumber) 'read all the users' fingerprint templates to the memory
    'While ZK.SSR_GetAllUserInfo(iMachineNumber, sdwEnrollNumber, sName, sPassword, iPrivilege, bEnabled) = True  'get all the users' information from the memory
    '    For idwFingerIndex = 0 To 9
    '        If ZK.GetUserTmpExStr(iMachineNumber, sdwEnrollNumber, idwFingerIndex, iFlag, sTmpData, iTmpLength) Then 'get the corresponding templates string and length from the memory
    '            lvItem = LV1.Items.Add(sdwEnrollNumber.ToString())
    '            lvItem.SubItems.Add(sName)
    '            lvItem.SubItems.Add(idwFingerIndex.ToString())
    '            lvItem.SubItems.Add(sTmpData)
    '            lvItem.SubItems.Add(iPrivilege.ToString())
    '            lvItem.SubItems.Add(sPassword)
    '            If bEnabled = True Then
    '                lvItem.SubItems.Add("true")
    '            Else
    '                lvItem.SubItems.Add("false")
    '            End If
    '            lvItem.SubItems.Add(iFlag.ToString())
    '        End If
    '    Next
    'End While
    'LV1.EndUpdate()
    'ZK.EnableDevice(iMachineNumber, True)
    'Cursor = Cursors.Default
    '------------------
    Public ZK As New zkemkeeper.CZKEM
    Dim FConnect As Boolean = False 'the boolean value identifies whether the device is connected
    Dim iMachineNumber As Integer 'In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
    Dim dtFinger As New DataTable

    Private Sub BtnUpdateName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdateName.Click
        Cursor = Cursors.WaitCursor
        'pBar.Visible = True
        'pBar.Value = 0
        'BackgroundWorker1.WorkerReportsProgress = True
        'BackgroundWorker1.WorkerSupportsCancellation = True
        'BackgroundWorker1.RunWorkerAsync()

        Dim id As String
        For x As Integer = 0 To dg1.RowCount - 1
            id = dg1.Item(1, x).Value.ToString.Trim
            If CInt(dg1.Item(0, x).Value.ToString) = 1 Then
                dg1.Item(2, x).Value = getStringFromDB("select spg_name from tbl_karyawan where spg_id='" & id & "' ")
            End If
        Next
        UpdateFingerName(ZK, dg1)

        Lbl1.Text = "Total Data : " & dg1.RowCount
        Cursor = Cursors.Default
        MsgOK(Lbl1.Text)
    End Sub
    Private Sub BtnLihat1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLihat1.Click
        pBar.Value = 0
        pBar.Visible = True
        GroupBox5.Enabled = False

        BackgroundWorker1.WorkerReportsProgress = True
        BackgroundWorker1.WorkerSupportsCancellation = True
        BackgroundWorker1.RunWorkerAsync()
    End Sub
    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim port As Integer
        Dim ip As String
        port = 4370
        ip = "192.168.1.244"
        port = CInt(getStringFromDB("select port from tbl_mesin where nama='" & CboFinger1.Text.Trim & "' "))
        ip = getStringFromDB("select ip from tbl_mesin where nama='" & CboFinger1.Text.Trim & "' ")
        'MsgOK("1")
        FConnect = ConnectFinger(ZK, ip, port)
        If FConnect = False Then
            BackgroundWorker1.CancelAsync()
            pBar.Visible = False
            pBar.Value = 0
            GroupBox5.Enabled = True
            Exit Sub
        End If
        'MsgOK("2")
        ReadUserFinger(ZK, BackgroundWorker1)
        'MsgOK("3")
        FConnect = DisconnectFinger(ZK)
        'MsgOK("4")
    End Sub
    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        pBar.Value = e.ProgressPercentage
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        pBar.Visible = False
        pBar.Value = 0
        GroupBox5.Enabled = True

        dg1.AutoGenerateColumns = False
        dg1.DataSource = dtFinger
        NavFinger.DataSource = dtFinger

        If dg1.RowCount <= 0 Then MsgOK("No Data Finger")
        Lbl1.Text = "Total Data : " & dg1.RowCount
    End Sub
    Public Sub ReadUserFinger(ByVal ZK As zkemkeeper.CZKEM, _
                              ByVal BW As System.ComponentModel.BackgroundWorker)
        Dim iMachineNumber As Integer
        Dim sdwEnrollNumber As String = ""
        Dim sName As String = ""
        Dim sPassword As String = ""
        Dim iPrivilege As Integer
        Dim bEnabled As Boolean = False
        Dim idwFingerIndex As Integer
        Dim sTmpData As String = ""
        Dim iTmpLength As Integer
        Dim iFlag As Integer
        Dim no, total As Integer
        Dim ena As String
        iMachineNumber = 1
        ZK.EnableDevice(iMachineNumber, False)
        ZK.ReadAllUserID(iMachineNumber) 'read all the user information to the memory
        ZK.ReadAllTemplate(iMachineNumber) 'read all the users' fingerprint templates to the memory

        'MsgOK("a")
        no = 1
        total = 0
        ZK.GetDeviceStatus(iMachineNumber, 3, total)
        'MsgOK("b")
        'ZK.GetDeviceStatus(iMachineNumber, 2, totaluser)

        CreateColumnDataTable()
        'MsgOK("c")
        While ZK.SSR_GetAllUserInfo(iMachineNumber, sdwEnrollNumber, sName, sPassword, iPrivilege, bEnabled) = True  'get all the users' information from the memory
            BW.ReportProgress(CInt(100 * (no) / total))
            For idwFingerIndex = 0 To 9
                If ZK.GetUserTmpExStr(iMachineNumber, sdwEnrollNumber, idwFingerIndex, iFlag, sTmpData, iTmpLength) Then 'get the corresponding templates string and length from the memory
                    If bEnabled Then : ena = "1" : Else : ena = "0" : End If

                    'If LCase(whsCode) = "s001" And CInt(sdwEnrollNumber) >= 1000 And CInt(sdwEnrollNumber) <= 2999 Then
                    '    dtFinger.Rows.Add("0", sdwEnrollNumber.ToString(), sName, idwFingerIndex.ToString(), sTmpData, iPrivilege.ToString(), sPassword, ena, iFlag.ToString())
                    'ElseIf LCase(whsCode) = "s002" And CInt(sdwEnrollNumber) >= 3000 And CInt(sdwEnrollNumber) <= 4999 Then
                    '    dtFinger.Rows.Add("0", sdwEnrollNumber.ToString(), sName, idwFingerIndex.ToString(), sTmpData, iPrivilege.ToString(), sPassword, ena, iFlag.ToString())
                    'ElseIf LCase(whsCode) = "s003" And CInt(sdwEnrollNumber) >= 5000 And CInt(sdwEnrollNumber) <= 6999 Then
                    '    dtFinger.Rows.Add("0", sdwEnrollNumber.ToString(), sName, idwFingerIndex.ToString(), sTmpData, iPrivilege.ToString(), sPassword, ena, iFlag.ToString())
                    'End If
                    dtFinger.Rows.Add("0", sdwEnrollNumber.ToString(), sName, idwFingerIndex.ToString(), sTmpData, iPrivilege.ToString(), sPassword, ena, iFlag.ToString())
                    no += 1
                End If
            Next
        End While
        'MsgOK("d")
        ZK.EnableDevice(iMachineNumber, True)
        'MsgOK("e")
    End Sub
    Sub CreateColumnDataTable()
        dg1.DataSource = Nothing
        NavFinger.DataSource = Nothing
        If dtFinger.Columns.Count > 0 Then dtFinger.Columns.Clear()
        If dtFinger.Rows.Count > 0 Then dtFinger.Rows.Clear()

        dtFinger.Columns.Add("choose", GetType(Integer))
        dtFinger.Columns.Add("fingercode", GetType(Integer))
        dtFinger.Columns.Add("name", GetType(String))
        dtFinger.Columns.Add("fingerindex", GetType(Integer))
        dtFinger.Columns.Add("tmp", GetType(String))
        dtFinger.Columns.Add("privilege", GetType(Integer))
        dtFinger.Columns.Add("pass", GetType(String))
        dtFinger.Columns.Add("enabled", GetType(Integer))
        dtFinger.Columns.Add("flag", GetType(Integer))

    End Sub
    Private Sub FrmFinger_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OpenDBHRD()
        'Dim ico As New System.Drawing.Icon(LokasiICOFile) : Me.Icon = ico
        CheckForIllegalCrossThreadCalls = False
        isiCombo()
        CboFinger1.Focus()
        dg1.Font = Label14.Font
    End Sub
    Sub isiCombo()
        isiComboboxFromSQL(CboFinger1, "select nama from tbl_mesin order by nama")
        CboFinger1.Text = getStringFromDB("select nama from tbl_mesin where utama=1")
    End Sub

    Private Sub btnTutup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Close()
    End Sub
    Sub Bersih()
        isiCombo()
        Lbl1.Text = "Total Data : 0"
        'Lbl2.Text = "Total Data : 0"
        dg1.Rows.Clear()
        'LV1.Items.Clear()
        'LV2.Items.Clear()
        CboFinger1.Focus()
    End Sub
    Private Sub btnBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Bersih()
    End Sub
    Private Sub BtnNonActive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNonActive.Click
        Dim port As Integer
        Dim ip As String
        port = CInt(getStringFromDB("select port from tbl_mesin where nama='" & CboFinger1.Text.Trim & "' "))
        ip = getStringFromDB("select ip from tbl_mesin where nama='" & CboFinger1.Text.Trim & "' ")
        FConnect = ConnectFinger(ZK, ip, port)
        If FConnect = False Then
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor

        For x As Integer = 0 To dg1.RowCount - 1
            If CInt(dg1.Item(0, x).Value.ToString) = 1 Then
                ZK.SSR_EnableUser(1, dg1.Item(1, x).Value.ToString, False)
            End If
        Next

        ReadUserFingerToDataGrid(ZK, dg1)
        SinkronFinger(ZK, dg1)
        FConnect = DisconnectFinger(ZK)
        Lbl1.Text = "Total Data : " & dg1.RowCount
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnActive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActive.Click
        Dim port As Integer
        Dim ip As String
        port = CInt(getStringFromDB("select port from tbl_mesin where nama='" & CboFinger1.Text.Trim & "' "))
        ip = getStringFromDB("select ip from tbl_mesin where nama='" & CboFinger1.Text.Trim & "' ")
        FConnect = ConnectFinger(ZK, ip, port)
        If FConnect = False Then
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor

        For x As Integer = 0 To dg1.RowCount - 1
            If CInt(dg1.Item(0, x).Value.ToString) = 1 Then
                ZK.SSR_EnableUser(1, dg1.Item(1, x).Value.ToString, True)
            End If
        Next
        ReadUserFingerToDataGrid(ZK, dg1)
        SinkronFinger(ZK, dg1)
        FConnect = DisconnectFinger(ZK)
        Lbl1.Text = "Total Data : " & dg1.RowCount
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        pBar.Value = 0
        pBar.Visible = True
        GroupBox5.Enabled = False

        BwDelete.WorkerReportsProgress = True
        BwDelete.WorkerSupportsCancellation = True
        BwDelete.RunWorkerAsync()
    End Sub
    Private Sub BwDelete_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BwDelete.DoWork
        Dim port As Integer
        Dim ip As String
        port = 4370
        ip = "192.168.1.244"
        port = CInt(getStringFromDB("select port from tbl_mesin where nama='" & CboFinger1.Text.Trim & "' "))
        ip = getStringFromDB("select ip from tbl_mesin where nama='" & CboFinger1.Text.Trim & "' ")

        
        FConnect = ConnectFinger(ZK, ip, port)
        If FConnect = False Then
            BackgroundWorker1.CancelAsync()
            pBar.Visible = False
            pBar.Value = 0
            GroupBox5.Enabled = True
            Exit Sub
        End If

        For x As Integer = 0 To dg1.RowCount - 1
            BwDelete.ReportProgress(CInt(100 * (x + 1) / dg1.RowCount))
            If CInt(dg1.Item(0, x).Value.ToString) = 1 Then
                ZK.SSR_DelUserTmpExt(1, dg1.Item(1, x).Value.ToString, dg1.Item(3, x).Value.ToString)
            End If
        Next
        'ReadUserFinger(ZK, BwDelete)
        FConnect = DisconnectFinger(ZK)
    End Sub
    Private Sub BwDelete_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BwDelete.ProgressChanged
        pBar.Value = e.ProgressPercentage
    End Sub
    Private Sub BwDelete_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BwDelete.RunWorkerCompleted
        pBar.Visible = False
        pBar.Value = 0
        GroupBox5.Enabled = True

        'BtnLihat1_Click(sender, e)

        dg1.AutoGenerateColumns = False
        dg1.DataSource = Nothing
        NavFinger.DataSource = Nothing
        MsgOK("Delete Success")
        'If dg1.RowCount <= 0 Then MsgOK("No Data Finger")
        'Lbl1.Text = "Total Data : " & dg1.RowCount
    End Sub
    Private Sub BtnSinkron_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSinkron.Click
        'Dim dsi As DataSet
        'Dim PORT As Integer
        'Dim IP As String
        Cursor = Cursors.WaitCursor
        'dsi = Query("select * from tbl_mesin order by ip")
        'For Each ro As DataRow In dsi.Tables(0).Rows
        '    IP = ro("ip").ToString.Trim
        '    PORT = CInt(ro("port").ToString)
        '    FConnect = ConnectFinger(ZK, IP, PORT)
        '    If FConnect = False Then
        '        Continue For
        '    End If
        '    DeleteALLUserFinger(ZK)
        '    UploadUserFingerFromDatagrid(ZK, dg1)
        '    DisconnectFinger(ZK)
        'Next
        'clearDataSet(dsi)
        SinkronFinger(ZK, dg1)
        Cursor = Cursors.Default
        Lbl1.Text = "Total Data : " & dg1.RowCount
        MsgOK("Sukses Copy Finger, Total : " & dg1.RowCount)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim port As Integer
        Dim ip As String
        port = CInt(getStringFromDB("select port from tbl_mesin where nama='" & CboFinger1.Text.Trim & "' "))
        ip = getStringFromDB("select ip from tbl_mesin where nama='" & CboFinger1.Text.Trim & "' ")
        FConnect = ConnectFinger(ZK, ip, port)
        If FConnect = False Then
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        ZK.DeleteUserInfoEx(1, 617)

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

        Dim iUpdateFlag As Integer = 1
        Dim lvItem As New ListViewItem
        Dim iMachineNumber As Integer = 1

        'Cursor = Cursors.WaitCursor
        ZK.EnableDevice(iMachineNumber, False)

        If ZK.BeginBatchUpdate(iMachineNumber, iUpdateFlag) Then 'create memory space for batching data
            Dim iLastEnrollNumber As Integer = 0 'the former enrollnumber you have upload(define original value as 0)
            For x As Integer = 0 To dg1.RowCount - 1
                If CInt(dg1.Item(7, x).Value.ToString.Trim) = 1 Then
                    sdwEnrollNumber = Convert.ToInt32(dg1.Item(1, x).Value.ToString.Trim)
                    sName = dg1.Item(2, x).Value.ToString.Trim
                    idwFingerIndex = Convert.ToInt32(dg1.Item(3, x).Value.ToString.Trim)
                    sTmpData = dg1.Item(4, x).Value.ToString.Trim
                    iPrivilege = Convert.ToInt32(dg1.Item(5, x).Value.ToString.Trim)
                    sPassword = dg1.Item(6, x).Value.ToString.Trim
                    sEnabled = dg1.Item(7, x).Value.ToString.Trim
                    iflag = Convert.ToInt32(dg1.Item(8, x).Value.ToString.Trim)
                    If sEnabled = "1" Then : bEnabled = True : Else : bEnabled = False : End If

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
                End If
            Next
        End If

        ZK.BatchUpdate(iMachineNumber) 'upload all the information in the memory
        ZK.RefreshData(iMachineNumber) 'the data in the device should be refreshed
        ZK.EnableDevice(iMachineNumber, True)


        ReadUserFingerToDataGrid(ZK, dg1)
        FConnect = DisconnectFinger(ZK)
        Lbl1.Text = "Total Data : " & dg1.RowCount
        Cursor = Cursors.Default

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

    Private Sub cbxHilang_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxHilang.CheckedChanged
        If cbxHilang.Checked Then
            cbxPilih.Checked = False
            isiChooseALL(0)
        Else
            cbxPilih.Checked = True
            isiChooseALL(1)
        End If
    End Sub
    Sub isiChooseALL(ByVal pilih As Integer)
        If dg1.RowCount = 0 Then Exit Sub
        'Label3.Text = "Please Wait"
        'Thread.Sleep(1000)
        Dim x As Integer
        For x = 0 To dg1.RowCount - 1
            dg1.Item(0, x).Value = pilih
        Next
        'Thread.Sleep(1000)
        'Label3.Text = ""
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim dr As DataRow
        dt.Columns.Add(New System.Data.DataColumn("pilih", Type.GetType("System.Int32")))
        dt.Columns.Add(New System.Data.DataColumn("userid", Type.GetType("System.String")))
        dt.Columns.Add(New System.Data.DataColumn("nama", Type.GetType("System.String")))
        dt.Columns.Add(New System.Data.DataColumn("fingerindex", Type.GetType("System.String")))
        dt.Columns.Add(New System.Data.DataColumn("tmpdata", Type.GetType("System.String")))
        dt.Columns.Add(New System.Data.DataColumn("privilege", Type.GetType("System.String")))
        dt.Columns.Add(New System.Data.DataColumn("pass", Type.GetType("System.String")))
        dt.Columns.Add(New System.Data.DataColumn("enabled", Type.GetType("System.Int32")))
        dt.Columns.Add(New System.Data.DataColumn("flag", Type.GetType("System.String")))

        dr = dt.NewRow
        dr("pilih") = 1
        dr("userid") = "1"
        dr("nama") = "1"
        dr("fingerindex") = "1"
        dr("tmpdata") = "1"
        dr("privilege") = "1"
        dr("pass") = "1"
        dr("enabled") = 1
        dr("flag") = "1"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("pilih") = 1
        dr("userid") = "2"
        dr("nama") = "2"
        dr("fingerindex") = "2"
        dr("tmpdata") = "2"
        dr("privilege") = "2"
        dr("pass") = "2"
        dr("enabled") = 1
        dr("flag") = "2"
        dt.Rows.Add(dr)

        ds.Tables.Add(dt)
        dg1.DataSource = ds.Tables(0)

        'ds.Tables(0).Rows.Add(
        clearDataSet(ds)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim dsf As DataSet
        Dim port As Integer
        Dim ip As String
        dsf = QueryToDataset("select * from tbl_mesin order by ip")
        For Each rf As DataRow In dsf.Tables(0).Rows
            port = CInt(rf("port").ToString.Trim)
            ip = rf("ip").ToString.Trim
            FConnect = ConnectFinger(ZK, ip, port)
            If FConnect = False Then
                MsgOK("Koneksi Error")
                'UpdateMessageGenerate(numberx, "Finger IP " & ip & " Connection Problem")
                Continue For
            End If

            ''ini untuk hapus fingerlog
            If ClearLogFinger(ZK, iMachineNumber) = False Then
                MsgOK("Delete error")
                Continue For
            End If
            FConnect = DisconnectFinger(ZK)
        Next
        clearDataSet(dsf)
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
        If dg1.RowCount <= 0 Then Exit Sub
        Dim strFilter As String
        strFilter = " convert(fingercode, 'System.String') like '%" & txtName.Text.Trim & "%' or name like '%" & txtName.Text.Trim & "%' "
        NavFinger.Filter = strFilter
        Lbl1.Text = "Total Data : " & dg1.RowCount
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Close()
    End Sub
End Class