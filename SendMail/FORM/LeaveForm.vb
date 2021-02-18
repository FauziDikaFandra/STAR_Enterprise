Public Class LeaveForm

    Private Sub LeaveForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OpenDBHRD()
    End Sub
    Sub Bersih()
        txtNIP.Clear()
        txtNama.Clear()
        dtStartdate.Value = Now
        dtEnddate.Value = Now
        dtLeaveSource.Checked = False
        dtLeaveSource.Value = Now
        isiCboLeaveType()
        txtTakenLeave.Clear()
        txtDescription.Clear()
        txtDept.Clear()
        txtBagian.Clear()
        txtStatus.Clear()
        txtAvailableLeave.Clear()

        txtEmployeeID.Text = ""
        txtEmployeeCutiID.Text = ""
        txtLeaveTypeID.Text = ""
        txtTCutiID.Text = ""
    End Sub
    Sub isiCboLeaveType()
        isiComboboxFromSQL(txtLeaveType, "select ltrim(rtrim(code))+'-'+ltrim(rtrim(name)) as aa " & vbCrLf & _
                               "from m_leavetype order by ltrim(rtrim(code))+'-'+ltrim(rtrim(name)) ")
    End Sub
    Sub TampilKaryawan(ByVal txt As String)
        Dim SQL As String
        Dim dsKar As New DataSet

        SQL = "select employee_id, nip, name, departmentname, bagianname, jabatanname, unitname " & vbCrLf & _
              "from v_employee " & vbCrLf & _
              "where " & vbCrLf & _
              "unitcode='S000' and " & vbCrLf & _
              " isactive='YES' and (nip like '%" & txt & "%' or name like '%" & txt & "%') " & vbCrLf & _
              "order by name"
        'Dbg(SQL)
        dsKar = Query(SQL, StrConHRD)
        dgKar.DataSource = dsKar.Tables(0)
        NavSource1.DataSource = dsKar.Tables(0)
        If dsKar.Tables(0).Rows.Count > 0 Then
            dgKar.Refresh()
        Else
            MsgError("No Data")
        End If
    End Sub
    Private Sub BtnCariNIP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCariNIP.Click
        gbPilih.Top = 82
        gbPilih.Left = 113
        txtCari.Clear()
        TampilKaryawan(txtCari.Text.Trim)
        gbPilih.Visible = True
        txtCari.Focus()
    End Sub

    Private Sub txtCari_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCari.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = Keys.Down Then
            dgKar.Focus()
        ElseIf e.KeyCode = Keys.Escape Then
            gbPilih.Visible = False
            txtEmployeeID.Text = ""
            txtNIP.Text = ""
            txtCari.Clear()
            txtNIP.Focus()
        End If
    End Sub

    Private Sub txtCari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCari.TextChanged
        NavSource1.Filter = " (nip like '%" & txtCari.Text.Trim & "%') or (name like '%" & txtCari.Text.Trim & "%') "
    End Sub

    Private Sub dgKar_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgKar.CellContentClick

    End Sub

    Private Sub dgKar_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgKar.CellContentDoubleClick
        gbPilih.Visible = False
        txtEmployeeID.Text = dgKar.Item(0, e.RowIndex).Value.ToString.Trim
        txtNIP.Text = dgKar.Item(1, e.RowIndex).Value.ToString.Trim
        'reloadClick()
        txtCari.Clear()
    End Sub

    Private Sub dgKar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgKar.KeyDown
        If e.KeyCode = 13 Then
            gbPilih.Visible = False
            txtEmployeeID.Text = dgKar.Item(0, dgKar.CurrentRow.Index).Value.ToString.Trim
            txtNIP.Text = dgKar.Item(1, dgKar.CurrentRow.Index).Value.ToString.Trim
            'reloadClick()
            txtCari.Clear()
        ElseIf e.KeyCode = Keys.Escape Then
            gbPilih.Visible = False
            txtEmployeeID.Text = ""
            txtNIP.Text = ""
            txtCari.Clear()
            txtNIP.Focus()
        End If
    End Sub

    Private Sub txtNIP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNIP.TextChanged
        Dim dss As DataSet
        Dim eid As String = ""
        dss = Query("select employee_id, nip, name, departmentname, bagianname, jabatanname from v_employee where nip='" & txtNIP.Text.Trim & "' ")
        If GetDSRecordCount(dss) > 0 Then
            eid = dss.Tables(0).Rows(0).Item(0).ToString.Trim
            isiMasterCuti(eid)

            txtNama.Text = dss.Tables(0).Rows(0).Item(2).ToString.Trim
            txtDept.Text = dss.Tables(0).Rows(0).Item(3).ToString.Trim
            txtBagian.Text = dss.Tables(0).Rows(0).Item(4).ToString.Trim
            txtJabatan.Text = dss.Tables(0).Rows(0).Item(5).ToString.Trim
            dtLeaveSource.Checked = False
            dtLeaveSource.Value = Now
            txtEmployeeCutiID.Text = ""
            dss = Query("select top 1 employee_cuti_id, startdate from m_employee_cuti where employee_id='" & eid & "' and expired=0 order by startdate ")
            If GetDSRecordCount(dss) > 0 Then
                dtLeaveSource.Checked = True
                dtLeaveSource.Value = dss.Tables(0).Rows(0).Item(1).ToString.Trim
                txtEmployeeCutiID.Text = dss.Tables(0).Rows(0).Item(0).ToString.Trim
            Else
                MsgError("Karyawan Ini Belum Mempunyai Hak Cuti")
                clearDataSet(dss)
                Bersih()
                Exit Sub
            End If
            txtAvailableLeave.Text = getStringFromDB("select availableleave from m_employee where employee_id='" & eid & "' ")
            If CInt(txtAvailableLeave.Text) <= 0 Then
                MsgError("Karyawan Ini Belum Mempunyai Hak Cuti")
                clearDataSet(dss)
                Bersih()
                Exit Sub
            End If
        Else
            txtNama.Clear()
            txtDept.Clear()
            txtBagian.Clear()
            txtJabatan.Clear()
            txtEmployeeCutiID.Text = ""
            dtLeaveSource.Checked = False
            dtLeaveSource.Value = Now
            txtAvailableLeave.Clear()
        End If
        clearDataSet(dss)
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim cutitahunan, tipe, s As String
        Dim join, res As String
        Dim dse As DataSet
        tipe = LCase(lblTipe.Text)
        cutitahunan = "0"
        If cbxCutiTahunan.Checked Then cutitahunan = "1"
        'sampe sini

        join = "null"
        res = "null"
        dse = Query("select employee_id, joindate, resigndate from m_employee where employee_id='" & txtEmployeeID.Text & "' ")
        If GetDSRecordCount(dse) > 0 Then
            'If IsDSNull(dse, "joindate") = False Then join = "'" & Format(dse.Tables(0).Rows(0).Item(1).ToString, "yyyy-MM-dd") & "'"
            'If IsDSNull(dse, "resigndate") = False Then res = "'" & Format(dse.Tables(0).Rows(0).Item(2).ToString, "yyyy-MM-dd") & "'"
            If IsDSNull(dse, "joindate") = False Then
                'MsgOK(dse.Tables(0).Rows(0).Item(1))
                'join = "'" & dse.Tables(0).Rows(0).Item(1).ToString & "'"
                join = "'" & Format(dse.Tables(0).Rows(0).Item(1), "yyyy-MM-dd") & "'"
                'MsgOK(join)
            End If
            If IsDSNull(dse, "resigndate") = False Then
                res = "'" & Format(dse.Tables(0).Rows(0).Item(2), "yyyy-MM-dd") & "'"
                'res = "'" & dse.Tables(0).Rows(0).Item(2).ToString & "'"
                'res = Format(res, "yyyy-MM-dd")
            End If
        End If
        clearDataSet(dse)

        If tipe = "new" Then
            s = "insert into t_cuti (employee_cuti_id, leavetype_id, startdate, enddate, takenleave, " & vbCrLf & _
                "availableleave, description, status, iscutitahunan, employee_id, nip, tdate, " & vbCrLf & _
                "userentry, useradded, dateadded, joindate, resigndate) values " & vbCrLf & _
                "('" & txtEmployeeCutiID.Text & "', '" & txtLeaveTypeID.Text & "', " & vbCrLf & _
                "'" & Format(dtStartdate.Value, "yyyy-MM-dd") & "', '" & Format(dtEnddate.Value, "yyyy-MM-dd") & "', " & vbCrLf & _
                "'" & txtTakenLeave.Text & "', '" & txtAvailableLeave.Text & "', '" & txtDescription.Text & "', " & vbCrLf & _
                "'" & txtStatus.Text & "', '" & cutitahunan & "', '" & txtEmployeeID.Text & "', '" & txtNIP.Text & "', " & vbCrLf & _
                "'" & Format(dtLeaveSource.Value, "yyyy-MM-dd") & "', " & vbCrLf & _
                "'" & UserLogin & "', '" & UserLogin & "', " & vbCrLf & _
                "'" & Format(Now, "yyyy-MM-dd HH:mm:ss") & "', " & join & ", " & res & " )"
        Else
            s = "update t_cuti set employee_cuti_id='" & txtEmployeeCutiID.Text & "', " & vbCrLf & _
                "leavetype_id='" & txtLeaveTypeID.Text & "', startdate='" & Format(dtStartdate.Value, "yyyy-MM-dd") & "', " & vbCrLf & _
                "enddate='" & Format(dtEnddate.Value, "yyyy-MM-dd") & "', takenleave='" & txtTakenLeave.Text & "', " & vbCrLf & _
                "availableleave='" & txtAvailableLeave.Text & "', description='" & txtDescription.Text & "', " & vbCrLf & _
                "status='" & txtStatus.Text & "', iscutitahunan='" & cutitahunan & "', " & vbCrLf & _
                "employee_id='" & txtEmployeeID.Text & "', nip='" & txtNIP.Text & "', " & vbCrLf & _
                "tdate='" & Format(dtLeaveSource.Value, "yyyy-MM-dd") & "', " & vbCrLf & _
                "useredited='" & UserLogin & "', joindate=" & join & ", resigndate=" & res & ", " & vbCrLf & _
                "dateedited='" & Format(Now, "yyyy-MM-dd HH:mm:ss") & "' where tcuti_id='" & txtTCutiID.Text & "' "
        End If
        Dbg(s)
        'joindate, resigndate di update manual
        ExecQuery(s)
        'ExecQuery("update t_cuti set joindate")
        MsgOK("Data Telah Disimpan")
        Close()
    End Sub

    Private Sub txtLeaveType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLeaveType.SelectedIndexChanged
        Dim dss As DataSet
        dss = Query("select leavetype_id, code, name, iscutitahunan from m_leavetype where code in (" & getCodeFromCheckboxCombo(txtLeaveType.Text.Trim, ",", "-") & ") ")
        If GetDSRecordCount(dss) > 0 Then
            txtLeaveTypeID.Text = dss.Tables(0).Rows(0).Item(0).ToString.Trim
            If CInt(dss.Tables(0).Rows(0).Item(3).ToString.Trim) = 1 Then
                cbxCutiTahunan.Checked = True
            Else
                cbxCutiTahunan.Checked = False
            End If
        Else
            txtLeaveTypeID.Text = ""
            cbxCutiTahunan.Checked = False
        End If
        clearDataSet(dss)
    End Sub

    Private Sub txtEmployeeCutiID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmployeeCutiID.Click

    End Sub
End Class