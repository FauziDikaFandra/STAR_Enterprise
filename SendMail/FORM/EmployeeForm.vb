Public Class EmployeeForm

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        SaveData()
    End Sub
    Sub SaveData()
        Dim s, jd, isactive As String
        jd = LCase(lblTipe.Text.Trim)
        's = "insert into m_employee (nip,noktp,name,department_id,bagian_id,jabatan_id,unit_id," & vbCrLf & _
        '        "joindate,resigndate,isactive,pob,dob,gender,agama,goldarah,pendidikan,notelp,hp," & vbCrLf & _
        '        "statuspernikahan,alamat,email,password,totalleave,takenleave,expiredleave,sisaleave," & vbCrLf & _
        '        "approve1,approve2,gambar,isdelete,useradded,dateadded,useredited,dateedited) " & vbCrLf & _
        '        "values () "
        Dim dp, bg, jb, un, join, resign, dob, c1, c2, c3, c4 As String

        dp = getArray(txtDept.Text.Trim, "-", 0)
        bg = getArray(txtBagian.Text.Trim, "-", 0)
        jb = getArray(txtJabatan.Text.Trim, "-", 0)
        un = getArray(txtUnit.Text.Trim, "-", 0)

        dp = getStringFromDB("select department_id from m_department where code='" & dp & "'", StrConHRD)
        bg = getStringFromDB("select bagian_id from m_bagian where code='" & bg & "'", StrConHRD)
        jb = getStringFromDB("select jabatan_id from m_jabatan where code='" & jb & "'", StrConHRD)
        un = getStringFromDB("select unit_id from m_unit where code='" & un & "'", StrConHRD)

        join = "null" : If dtJoindate.Checked Then join = "'" & Format(dtJoindate.Value, "yyyy-MM-dd") & "'"
        dob = "null" : If dtDOB.Checked Then dob = "'" & Format(dtDOB.Value, "yyyy-MM-dd") & "'"
        resign = "null"
        isactive = "1"
        If dtResigndate.Checked Then
            resign = "'" & Format(dtResigndate.Value, "yyyy-MM-dd") & "'"
            If resign < Format(Now, "yyyy-MM-dd") Then
                isactive = "0"
            End If
        End If

        c1 = "null" : If dtc1.Checked Then c1 = "'" & Format(dtc1.Value, "yyyy-MM-dd") & "'"
        c2 = "null" : If dtc2.Checked Then c2 = "'" & Format(dtc2.Value, "yyyy-MM-dd") & "'"
        c3 = "null" : If dtc3.Checked Then c3 = "'" & Format(dtc3.Value, "yyyy-MM-dd") & "'"
        c4 = "null" : If dtc4.Checked Then c4 = "'" & Format(dtc4.Value, "yyyy-MM-dd") & "'"

        If jd = "new" Then
            s = "insert into m_employee (nip,noktp,name,department_id,bagian_id,jabatan_id,unit_id," & vbCrLf & _
                "joindate,resigndate,isactive,pob,dob,gender,agama,goldarah,pendidikan,notelp,hp," & vbCrLf & _
                "statuspernikahan,alamat,email,password,useradded,dateadded,startcontract1," & vbCrLf & _
                "endcontract1,startcontract2,endcontract2,fingercode) " & vbCrLf & _
                "values ('" & txtNIP.Text & "', '" & txtNoKTP.Text & "', '" & txtNama.Text & "', " & vbCrLf & _
                "'" & dp & "', '" & bg & "', '" & jb & "', " & vbCrLf & _
                "'" & un & "', " & join & ", " & resign & ", " & vbCrLf & _
                "'" & isactive & "', '" & txtTempatLahir.Text & "', " & dob & ", '" & txtJenisKelamin.Text & "', " & vbCrLf & _
                "'" & txtAgama.Text & "', '" & txtGolDarah.Text & "', '" & txtPendidikan.Text & "', " & vbCrLf & _
                "'" & txtNoTelp.Text & "', '" & txtHP.Text & "', '" & txtStatusNikah.Text & "', " & vbCrLf & _
                "'" & txtAlamat.Text & "', '" & txtEmail.Text & "', '" & txtPassword.Text & "', " & vbCrLf & _
                "'" & UserLogin & "', '" & Format(Now, "yyyy-MM-dd") & "', " & c1 & ", " & c2 & ", " & vbCrLf & _
                "" & c3 & ", " & c4 & ", '" & txtKdFinger.Text & "' ) "
        Else
            s = "update m_employee set nip='" & txtNIP.Text & "', noktp='" & txtNoKTP.Text & "', name='" & txtNama.Text & "', " & vbCrLf & _
                "department_id='" & dp & "', bagian_id='" & bg & "', jabatan_id='" & jb & "', " & vbCrLf & _
                "unit_id='" & un & "', joindate=" & join & ", resigndate=" & resign & ", " & vbCrLf & _
                "pob='" & txtTempatLahir.Text & "', dob=" & dob & ", gender='" & txtJenisKelamin.Text & "', " & vbCrLf & _
                "agama='" & txtAgama.Text & "', goldarah='" & txtGolDarah.Text & "', pendidikan='" & txtPendidikan.Text & "', " & vbCrLf & _
                "notelp='" & txtNoTelp.Text & "', hp='" & txtHP.Text & "', statuspernikahan='" & txtStatusNikah.Text & "', " & vbCrLf & _
                "alamat='" & txtAlamat.Text & "', email='" & txtEmail.Text & "', password='" & txtPassword.Text & "', " & vbCrLf & _
                "useredited='" & UserLogin & "', dateedited='" & Format(Now, "yyyy-MM-dd") & "', " & vbCrLf & _
                "startcontract1=" & c1 & ", endcontract1=" & c2 & ", startcontract2=" & c3 & ", isactive='" & isactive & "', " & vbCrLf & _
                "endcontract2=" & c4 & ", fingercode='" & txtKdFinger.Text & "' where employee_id='" & txtEmployeeID.Text & "'"
        End If
        'Dbg(s)
        ExecQuery(s, StrConHRD)
        simpanHistoryFingerCode(txtNIP.Text, txtKdFinger.Text)
        Close()
    End Sub
    Sub simpanHistoryFingerCode(ByVal nip As String, ByVal finger As String)
        Dim kd_bagian, spg_id As String
        spg_id = getStringFromDB("select employee_id from m_employee where nip='" & nip & "' ")
        kd_bagian = getStringFromDB("select d.code " & vbCrLf & _
                                    "from m_department d " & vbCrLf & _
                                    "inner join m_employee e on e.department_id=d.department_id " & vbCrLf & _
                                    "where nip='" & nip & "' ")

        'Whs
        Dim dss As DataSet
        dss = Query("select * from m_employee_finger where whscode='HO01' and spg_id='" & spg_id & "' and fingercode='" & finger & "' ")
        If dss.Tables(0).Rows.Count <= 0 Then
            ExecQuery("insert into m_employee_finger (whscode, spg_id, fingercode, tgl, kd_bagian) " & vbCrLf & _
                      "values ('HO01', '" & spg_id & "', '" & finger & "', " & vbCrLf & _
                      "'" & Format(Now, "yyyy-MM-dd") & "', '" & kd_bagian & "') ")
        End If
        clearDataSet(dss)
    End Sub
    Sub isiCombo()
        QueryToCombo(txtDept, "select ltrim(rtrim(code))+'-'+ltrim(rtrim(name)) from m_department", StrConHRD)
        QueryToCombo(txtBagian, "select ltrim(rtrim(code))+'-'+ltrim(rtrim(name)) from m_bagian", StrConHRD)
        QueryToCombo(txtJabatan, "select ltrim(rtrim(code))+'-'+ltrim(rtrim(name)) from m_jabatan", StrConHRD)
        QueryToCombo(txtUnit, "select ltrim(rtrim(code))+'-'+ltrim(rtrim(name)) from m_unit", StrConHRD)

        QueryToCombo(txtPendidikan, "select ltrim(rtrim(name)) from m_pendidikan", StrConHRD)
        QueryToCombo(txtStatusNikah, "select ltrim(rtrim(name)) from m_statusnikah", StrConHRD)
        QueryToCombo(txtAgama, "select ltrim(rtrim(name)) from m_agama", StrConHRD)

        isiComboFromString(txtJenisKelamin, "Laki-Laki;Perempuan", ";")
        isiComboFromString(txtGolDarah, "A;B;AB;O", ";")
    End Sub

    Private Sub EmployeeForm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub EmployeeForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'CloseDBALL()
        clearTextbox()
        txtNIP.Clear()
        txtEmployeeID.Text = ""
    End Sub
    Private Sub EmployeeForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OpenDBHRD()
    End Sub

    Private Sub EmployeeForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If lblTipe.Text = "update" Then
            txtNama.Focus()
        Else
            txtNIP.Focus()
        End If
    End Sub

    Private Sub txtNIP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNIP.TextChanged
        Dim ds As DataSet
        ds = Query("select * from m_employee where nip='" & txtNIP.Text & "' ", StrConHRD)
        If GetDSRecordCount(ds) > 0 Then
            txtNama.Text = ds.Tables(0).Rows(0).Item("name").ToString.Trim
            txtTempatLahir.Text = ds.Tables(0).Rows(0).Item("pob").ToString.Trim
            txtNoKTP.Text = ds.Tables(0).Rows(0).Item("noktp").ToString.Trim
            txtKdFinger.Text = ds.Tables(0).Rows(0).Item("fingercode").ToString.Trim
            txtNoTelp.Text = ds.Tables(0).Rows(0).Item("notelp").ToString.Trim
            txtHP.Text = ds.Tables(0).Rows(0).Item("hp").ToString.Trim
            txtEmail.Text = ds.Tables(0).Rows(0).Item("email").ToString.Trim
            txtPassword.Text = ds.Tables(0).Rows(0).Item("password").ToString.Trim
            txtAlamat.Text = ds.Tables(0).Rows(0).Item("alamat").ToString.Trim
            txtJenisKelamin.Text = ds.Tables(0).Rows(0).Item("gender").ToString.Trim
            txtGolDarah.Text = ds.Tables(0).Rows(0).Item("goldarah").ToString.Trim
            txtDept.Text = getStringFromDB("select ltrim(rtrim(code))+'-'+ltrim(rtrim(name)) " & vbCrLf & _
                                           "from m_department where department_id='" & _
                                           ds.Tables(0).Rows(0).Item("department_id").ToString.Trim & "'", StrConHRD)
            txtBagian.Text = getStringFromDB("select ltrim(rtrim(code))+'-'+ltrim(rtrim(name)) " & vbCrLf & _
                                           "from m_bagian where bagian_id='" & _
                                           ds.Tables(0).Rows(0).Item("bagian_id").ToString.Trim & "'", StrConHRD)
            txtJabatan.Text = getStringFromDB("select ltrim(rtrim(code))+'-'+ltrim(rtrim(name)) " & vbCrLf & _
                                           "from m_jabatan where jabatan_id='" & _
                                           ds.Tables(0).Rows(0).Item("jabatan_id").ToString.Trim & "'", StrConHRD)
            txtUnit.Text = getStringFromDB("select ltrim(rtrim(code))+'-'+ltrim(rtrim(name)) " & vbCrLf & _
                                           "from m_unit where unit_id='" & _
                                           ds.Tables(0).Rows(0).Item("unit_id").ToString.Trim & "'", StrConHRD)

            txtStatusNikah.Text = ds.Tables(0).Rows(0).Item("statuspernikahan").ToString.Trim
            txtPendidikan.Text = ds.Tables(0).Rows(0).Item("pendidikan").ToString.Trim
            txtAgama.Text = ds.Tables(0).Rows(0).Item("agama").ToString.Trim
            If IsDSNull(ds, "joindate") Then
                dtJoindate.Checked = False
                dtJoindate.Value = Now
            Else
                dtJoindate.Checked = True
                dtJoindate.Value = ds.Tables(0).Rows(0).Item("joindate").ToString.Trim
            End If
            If IsDSNull(ds, "resigndate") Then
                dtResigndate.Checked = False
                dtResigndate.Value = Now
            Else
                dtResigndate.Checked = True
                dtResigndate.Value = ds.Tables(0).Rows(0).Item("resigndate").ToString.Trim
            End If
            If IsDSNull(ds, "dob") Then
                dtDOB.Checked = False
                dtDOB.Value = Now
            Else
                dtDOB.Checked = True
                dtDOB.Value = ds.Tables(0).Rows(0).Item("dob").ToString.Trim
            End If

            If IsDSNull(ds, "startcontract1") Then
                dtc1.Checked = False
                dtc1.Value = Now
            Else
                dtc1.Checked = True
                dtc1.Value = ds.Tables(0).Rows(0).Item("startcontract1").ToString.Trim
            End If
            If IsDSNull(ds, "endcontract1") Then
                dtc2.Checked = False
                dtc2.Value = Now
            Else
                dtc2.Checked = True
                dtc2.Value = ds.Tables(0).Rows(0).Item("endcontract1").ToString.Trim
            End If
            If IsDSNull(ds, "startcontract2") Then
                dtc3.Checked = False
                dtc3.Value = Now
            Else
                dtc3.Checked = True
                dtc3.Value = ds.Tables(0).Rows(0).Item("startcontract2").ToString.Trim
            End If
            If IsDSNull(ds, "endcontract2") Then
                dtc4.Checked = False
                dtc4.Value = Now
            Else
                dtc4.Checked = True
                dtc4.Value = ds.Tables(0).Rows(0).Item("endcontract2").ToString.Trim
            End If
        Else
            clearTextbox()
        End If
        clearDataSet(ds)
    End Sub
    Sub clearTextbox()
        txtNama.Text = ""
        txtTempatLahir.Text = ""
        txtNoKTP.Text = ""
        txtNoTelp.Text = ""
        txtHP.Text = ""
        txtEmail.Text = ""
        txtPassword.Text = ""
        txtAlamat.Text = ""
        txtJenisKelamin.Text = ""
        txtGolDarah.Text = ""
        txtDept.Text = ""
        txtBagian.Text = ""
        txtJabatan.Text = ""
        txtUnit.Text = ""
        txtStatusNikah.Text = ""
        txtPendidikan.Text = ""
        txtAgama.Text = ""
        txtKdFinger.Text = ""
        dtJoindate.Value = Now : dtJoindate.Checked = True
        dtResigndate.Value = Now : dtResigndate.Checked = False
        dtDOB.Value = Now : dtDOB.Checked = False

        dtc1.Value = Now : dtc1.Checked = False
        dtc2.Value = Now : dtc2.Checked = False
        dtc3.Value = Now : dtc3.Checked = False
        dtc4.Value = Now : dtc4.Checked = False
    End Sub
End Class