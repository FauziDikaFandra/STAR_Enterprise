Module MdFinger
    Public FolderABSLOG As String
    Public Function ConnectFinger(ByVal ZK As zkemkeeper.CZKEM, ByVal IP As String, ByVal PORT As Integer) As Boolean
        Dim hasil As Boolean
        Dim idwErrorCode As Integer
        'Cursor = Cursors.WaitCursor
        Dim cn As Boolean
        cn = ZK.Connect_Net(IP.Trim(), PORT)
        If cn = True Then
            hasil = True
            'iMachineNumber = 1 'In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
            ZK.RegEvent(1, 65535) 'Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
        Else
            ZK.GetLastError(idwErrorCode)
            MsgError("Unable to connect the device,ErrorCode=" & idwErrorCode)
            'Cursor = Cursors.Default
            hasil = False
        End If
        Return hasil
    End Function
    Public Function DisconnectFinger(ByVal ZK As zkemkeeper.CZKEM) As Boolean
        ZK.Disconnect()
        Return False
    End Function
    Public Function ClearLogFinger(ByVal zk As zkemkeeper.CZKEM, ByVal iMachineNumber As Integer)
        Dim hasil As Boolean = True
        Dim idwErrorCode As Integer
        zk.EnableDevice(iMachineNumber, False) 'disable the device
        'MsgOK("a")
        If zk.ClearGLog(iMachineNumber) = True Then
            'MsgOK("Data Delete")
            'MsgOK("b")
            zk.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            'MsgOK("c")
        Else
            'MsgOK("d")
            zk.GetLastError(idwErrorCode)
            'MsgOK("e")
            hasil = False
            'MsgBox("Operation failed,ErrorCode=" & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
        End If
        zk.EnableDevice(iMachineNumber, True) 'enable the device
        Return hasil
    End Function
    Public Sub ReadUserFingerToDataGrid(ByVal ZK As zkemkeeper.CZKEM, ByVal dg1 As DataGridView)
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
        Dim ena As String
        'Dim lvItem As New ListViewItem("Items", 0)
        iMachineNumber = 1
        dg1.Rows.Clear()
        ZK.EnableDevice(iMachineNumber, False)
        ZK.ReadAllUserID(iMachineNumber) 'read all the user information to the memory
        ZK.ReadAllTemplate(iMachineNumber) 'read all the users' fingerprint templates to the memory
        'ZK.GetAllUserID()
        While ZK.SSR_GetAllUserInfo(iMachineNumber, sdwEnrollNumber, sName, sPassword, iPrivilege, bEnabled) = True  'get all the users' information from the memory
            For idwFingerIndex = 0 To 9
                If ZK.GetUserTmpExStr(iMachineNumber, sdwEnrollNumber, idwFingerIndex, iFlag, sTmpData, iTmpLength) Then 'get the corresponding templates string and length from the memory
                    'Bw.ReportProgress(CInt(100 * no / total))
                    If bEnabled Then : ena = "1" : Else : ena = "0" : End If
                    dg1.Rows.Add("0", sdwEnrollNumber.ToString(), sName, idwFingerIndex.ToString(), sTmpData, iPrivilege.ToString(), sPassword, ena, iFlag.ToString())
                End If
            Next
        End While

        ZK.EnableDevice(iMachineNumber, True)
        If dg1.RowCount <= 0 Then
            MsgOK("No Data Finger")
        End If
    End Sub
    Public Sub ReadUserFingerToListView(ByVal ZK As zkemkeeper.CZKEM, ByVal LV1 As ListView)
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
        Dim lvItem As New ListViewItem("Items", 0)
        iMachineNumber = 1
        LV1.Items.Clear()
        LV1.BeginUpdate()
        ZK.EnableDevice(iMachineNumber, False)
        ZK.ReadAllUserID(iMachineNumber) 'read all the user information to the memory
        ZK.ReadAllTemplate(iMachineNumber) 'read all the users' fingerprint templates to the memory
        While ZK.SSR_GetAllUserInfo(iMachineNumber, sdwEnrollNumber, sName, sPassword, iPrivilege, bEnabled) = True  'get all the users' information from the memory
            For idwFingerIndex = 0 To 9
                If ZK.GetUserTmpExStr(iMachineNumber, sdwEnrollNumber, idwFingerIndex, iFlag, sTmpData, iTmpLength) Then 'get the corresponding templates string and length from the memory
                    lvItem = LV1.Items.Add(sdwEnrollNumber.ToString())
                    lvItem.SubItems.Add(sName)
                    lvItem.SubItems.Add(idwFingerIndex.ToString())
                    lvItem.SubItems.Add(sTmpData)
                    lvItem.SubItems.Add(iPrivilege.ToString())
                    lvItem.SubItems.Add(sPassword)
                    If bEnabled = True Then
                        lvItem.SubItems.Add("true")
                    Else
                        lvItem.SubItems.Add("false")
                    End If
                    lvItem.SubItems.Add(iFlag.ToString())
                End If
            Next
        End While
        LV1.EndUpdate()
        ZK.EnableDevice(iMachineNumber, True)
        If LV1.Items.Count <= 0 Then
            MsgOK("No Data Finger")
        End If
    End Sub
    Public Sub DeleteALLUserFinger(ByVal ZK As zkemkeeper.CZKEM)
        Dim idwErrorCode As Integer

        Dim iDataFlag As Integer = 5
        'Cursor = Cursors.WaitCursor
        If ZK.ClearData(1, iDataFlag) = True Then
            ZK.RefreshData(1) 'the data in the device should be refreshed
            'MsgOK("Clear all the UserInfo data!")
        Else
            ZK.GetLastError(idwErrorCode)
            MsgError("Operation failed Delete ALL User Finger,ErrorCode=" & idwErrorCode.ToString())
        End If
        'Cursor = Cursors.Default
    End Sub
    Public Sub UploadUserFingerFromListview(ByVal ZK As zkemkeeper.CZKEM, ByVal LV1 As ListView)
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
            For Each lvItem In LV1.Items
                sdwEnrollNumber = Convert.ToInt32(lvItem.SubItems(0).Text.Trim())
                sName = lvItem.SubItems(1).Text.Trim()
                idwFingerIndex = Convert.ToInt32(lvItem.SubItems(2).Text.Trim())
                sTmpData = lvItem.SubItems(3).Text.Trim()
                iPrivilege = Convert.ToInt32(lvItem.SubItems(4).Text.Trim())
                sPassword = lvItem.SubItems(5).Text.Trim()
                sEnabled = lvItem.SubItems(6).Text.Trim()
                iflag = Convert.ToInt32(lvItem.SubItems(7).Text.Trim())

                If sEnabled = "true" Then
                    bEnabled = True
                Else
                    bEnabled = False
                End If

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
            Next
        End If

        ZK.BatchUpdate(iMachineNumber) 'upload all the information in the memory
        ZK.RefreshData(iMachineNumber) 'the data in the device should be refreshed
        ZK.EnableDevice(iMachineNumber, True)
    End Sub
    Public Sub UploadUserFingerFromDatagrid(ByVal ZK As zkemkeeper.CZKEM, ByVal DG1 As DataGridView)
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
            For x As Integer = 0 To DG1.RowCount - 1
                sdwEnrollNumber = Convert.ToInt32(DG1.Item(1, x).Value.ToString.Trim)
                sName = DG1.Item(2, x).Value.ToString.Trim
                idwFingerIndex = Convert.ToInt32(DG1.Item(3, x).Value.ToString.Trim)
                sTmpData = DG1.Item(4, x).Value.ToString.Trim
                iPrivilege = Convert.ToInt32(DG1.Item(5, x).Value.ToString.Trim)
                sPassword = DG1.Item(6, x).Value.ToString.Trim
                sEnabled = DG1.Item(7, x).Value.ToString.Trim
                iflag = Convert.ToInt32(DG1.Item(8, x).Value.ToString.Trim)

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
            Next
        End If

        ZK.BatchUpdate(iMachineNumber) 'upload all the information in the memory
        ZK.RefreshData(iMachineNumber) 'the data in the device should be refreshed
        ZK.EnableDevice(iMachineNumber, True)
    End Sub
    Public Sub ProcActiveFinger(ByVal ZK As zkemkeeper.CZKEM, ByVal IP As String, ByVal port As Integer, _
                                ByVal UserID As String, Optional ByVal activeType As Boolean = True)
        Dim FConnect As Boolean = False
        FConnect = ConnectFinger(ZK, IP, port)
        If FConnect = False Then
            Exit Sub
        End If
        ZK.SSR_EnableUser(1, UserID, activeType)
        FConnect = DisconnectFinger(ZK)
    End Sub
    Public Sub SinkronFinger(ByVal ZK As zkemkeeper.CZKEM, ByVal dg1 As DataGridView)
        Dim FConnect As Boolean
        Dim dsi As DataSet
        Dim PORT As Integer
        Dim IP As String
        dsi = Query("select * from tbl_mesin order by ip")
        For Each ro As DataRow In dsi.Tables(0).Rows
            IP = ro("ip").ToString.Trim
            PORT = CInt(ro("port").ToString)
            FConnect = ConnectFinger(ZK, IP, PORT)
            If FConnect = False Then
                Continue For
            End If
            DeleteALLUserFinger(ZK)
            UploadUserFingerFromDatagrid(ZK, dg1)
            DisconnectFinger(ZK)
        Next
        clearDataSet(dsi)
    End Sub
    Public Sub UpdateFingerName(ByVal zk As zkemkeeper.CZKEM, ByVal dg1 As DataGridView)
        'ByVal BackgroundWorker1 As System.ComponentModel.BackgroundWorker)
        Dim port As Integer
        Dim ip As String
        Dim FConnect As Boolean
        port = CInt(getStringFromDB("select port from tbl_mesin where utama=1 "))
        ip = getStringFromDB("select ip from tbl_mesin where utama=1 ")
        FConnect = ConnectFinger(zk, ip, port)
        If FConnect = False Then
            Exit Sub
        End If

        Dim idwErrorCode, i As Integer
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
        i = 0

        zk.EnableDevice(iMachineNumber, False)
        If zk.BeginBatchUpdate(iMachineNumber, iUpdateFlag) Then 'create memory space for batching data
            Dim iLastEnrollNumber As Integer = 0 'the former enrollnumber you have upload(define original value as 0)
            For x As Integer = 0 To dg1.RowCount - 1
                'BackgroundWorker1.ReportProgress(CInt(100 * (i + 1) / dg1.RowCount))

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
                    zk.DeleteUserInfoEx(1, sdwEnrollNumber)
                    If sdwEnrollNumber <> iLastEnrollNumber Then 'identify whether the user information(except fingerprint templates) has been uploaded
                        If zk.SSR_SetUserInfo(iMachineNumber, sdwEnrollNumber, sName, sPassword, iPrivilege, bEnabled) Then 'upload user information to the device
                            zk.SetUserTmpExStr(iMachineNumber, sdwEnrollNumber, idwFingerIndex, iflag, sTmpData) 'upload templates information to the device
                        Else
                            zk.GetLastError(idwErrorCode)
                            MsgError("Operation failed Copy Finger,ErrorCode=" & idwErrorCode.ToString())
                            zk.EnableDevice(iMachineNumber, True)
                            Return
                        End If
                    Else 'the current fingerprint and the former one belongs the same user,that is ,one user has more than one template
                        zk.SetUserTmpExStr(iMachineNumber, sdwEnrollNumber, idwFingerIndex, iflag, sTmpData) 'upload tempates information to the memory
                    End If
                    iLastEnrollNumber = sdwEnrollNumber 'change the value of iLastEnrollNumber dynamicly
                End If
                i = i + 1
            Next
        End If

        zk.BatchUpdate(iMachineNumber) 'upload all the information in the memory
        zk.RefreshData(iMachineNumber) 'the data in the device should be refreshed
        zk.EnableDevice(iMachineNumber, True)
        ReadUserFingerToDataGrid(zk, dg1)
        SinkronFinger(zk, dg1)
        FConnect = DisconnectFinger(zk)
    End Sub
End Module
