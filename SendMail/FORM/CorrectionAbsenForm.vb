Public Class CorrectionAbsenForm

    Private Sub CorrectionAbsenForm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        CloseDBALL()
    End Sub

    Private Sub CorrectionAbsenForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OpenDBHRD()
        BtnCari.Image = Image.FromFile(FolderImage & "find.png")
        BtnReload.Image = Image.FromFile(FolderImage & "reload.png")
        btnTutup.Image = Image.FromFile(FolderImage & "close.png")
        btnSave.Image = Image.FromFile(FolderImage & "save.png")
        btnBatal.Image = Image.FromFile(FolderImage & "32cancel.png")
        dtPeriode.Value = DateTime.Parse(Now.Year & "-" & Now.Month & "-01")
        dg.Font = txtEmployeeID.Font
        txtNIP.Focus()
        If LCase(UserLogin) = "hr2" Then
            dg.Columns(4).ReadOnly = True
            dg.Columns(5).ReadOnly = True
        End If
    End Sub

    Private Sub txtBarcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFingerCode.TextChanged

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
    Sub reloadClick()
        Dim dss As DataSet
        dss = Query("select employee_id, nip, fingercode, name, departmentname, bagianname, jabatanname " & vbCrLf & _
                    "from v_employee where nip='" & txtNIP.Text.Trim & "' ")
        If GetDSRecordCount(dss) <= 0 Then
            MsgError("Data Employee Not Found")
            clearDataSet(dss)
            Exit Sub
        End If
        txtFingerCode.Text = dss.Tables(0).Rows(0).Item("fingercode").ToString.Trim
        txtName.Text = dss.Tables(0).Rows(0).Item("name").ToString.Trim
        txtDept.Text = dss.Tables(0).Rows(0).Item("departmentname").ToString.Trim
        txtBagian.Text = dss.Tables(0).Rows(0).Item("bagianname").ToString.Trim
        txtJabatan.Text = dss.Tables(0).Rows(0).Item("jabatanname").ToString.Trim
        txtEmployeeID.Text = dss.Tables(0).Rows(0).Item("employee_id").ToString.Trim
        strSQL = "select case DATEPART(dw, tgl) " & vbCrLf & _
                    "when '1' then 'MINGGU' " & vbCrLf & _
                    "when '2' then 'SENIN' " & vbCrLf & _
                    "when '3' then 'SELASA' " & vbCrLf & _
                    "when '4' then 'RABU' " & vbCrLf & _
                    "when '5' then 'KAMIS' " & vbCrLf & _
                    "when '6' then 'JUMAT' " & vbCrLf & _
                    "when '7' then 'SABTU' end " & vbCrLf & _
                    "as hari, " & vbCrLf & _
                    "tgl, masukroster, pulangroster, jammasuk, jampulang, status, " & vbCrLf & _
                    "keterangan, lemburmasuk, lemburpulang, dateadded, useradded, dateedited, useredited, " & vbCrLf & _
                    "jammasuk as jammasuk1, jampulang as jampulang1, status as status1, " & vbCrLf & _
                    "keterangan as keterangan1, lemburmasuk as lemburmasuk1, lemburpulang as lemburpulang1 " & vbCrLf & _
                    "from t_absen where nip='" & txtNIP.Text & "' " & vbCrLf & _
                    "and convert(varchar(7), tgl, 20)='" & Format(dtPeriode.Value, "yyyy-MM") & "' order by tgl "
        'Dbg(strSQL)
        dss = Query(strSQL)
        dg.DataSource = dss.Tables(0)
        If dss.Tables(0).Rows.Count > 0 Then
            dg.DataSource = dss.Tables(0)
            dg.Refresh()
        Else
            If dg.DataSource.rows.count > 0 Then dg.DataSource.rows.clear()
            MsgError("No Data Absen")
        End If
        'clearDataSet(dss)
        'MsgOK("reload")
    End Sub
    Private Sub BtnReload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReload.Click
        reloadClick()
    End Sub

    Private Sub txtNIP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNIP.KeyDown
        If e.KeyCode = 13 Then
            reloadClick()
        End If
    End Sub

    Private Sub txtNIP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNIP.TextChanged

    End Sub
    Sub TampilKaryawan(ByVal txt As String)
        Dim SQL As String
        Dim dsKar As New DataSet

        SQL = "select employee_id, nip, name, departmentname, bagianname, jabatanname, unitname " & vbCrLf & _
              "from v_employee " & vbCrLf & _
              "where " & vbCrLf & _
              "unitcode='S000' and " & vbCrLf & _
              " isactive='YES' and (nip like '%" & txtCari.Text.Trim & "%' or name like '%" & txtCari.Text.Trim & "%') " & vbCrLf & _
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
    Private Sub BtnCari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCari.Click
        gbPilih.Top = 110
        gbPilih.Left = 67

        txtCari.Clear()
        TampilKaryawan(txtCari.Text.Trim)
        Me.Height = 445
        gbPilih.Visible = True
        txtCari.Focus()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgKar.CellContentClick

    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgKar.CellContentDoubleClick
        gbPilih.Visible = False
        txtEmployeeID.Text = dgKar.Item(0, e.RowIndex).Value.ToString.Trim
        txtNIP.Text = dgKar.Item(1, e.RowIndex).Value.ToString.Trim
        reloadClick()
        If dgKar.DataSource.rows.count > 0 Then dgKar.DataSource.rows.clear()
        txtCari.Clear()
    End Sub

    Private Sub txtCari_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCari.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = Keys.Down Then
            dgKar.Focus()
        ElseIf e.KeyCode = Keys.Escape Then
            gbPilih.Visible = False
            txtEmployeeID.Text = ""
            txtNIP.Text = ""
            If dg.DataSource.rows.count > 0 Then dg.DataSource.rows.clear()
            If dgKar.DataSource.rows.count > 0 Then dgKar.DataSource.rows.clear()
            txtCari.Clear()
            txtNIP.Focus()
        End If
    End Sub

    Private Sub txtCari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCari.TextChanged
        NavSource1.Filter = " (nip like '%" & txtCari.Text.Trim & "%') or (name like '%" & txtCari.Text.Trim & "%') "
    End Sub

    Private Sub dgKar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgKar.KeyDown
        If e.KeyCode = 13 Then
            gbPilih.Visible = False
            txtEmployeeID.Text = dgKar.Item(0, dgKar.CurrentRow.Index).Value.ToString.Trim
            txtNIP.Text = dgKar.Item(1, dgKar.CurrentRow.Index).Value.ToString.Trim
            reloadClick()
            If dgKar.DataSource.rows.count > 0 Then dgKar.DataSource.rows.clear()
            txtCari.Clear()
        ElseIf e.KeyCode = Keys.Escape Then
            gbPilih.Visible = False
            txtEmployeeID.Text = ""
            txtNIP.Text = ""
            If dg.DataSource.rows.count > 0 Then dg.DataSource.rows.clear()
            If dgKar.DataSource.rows.count > 0 Then dgKar.DataSource.rows.clear()
            txtCari.Clear()
            txtNIP.Focus()
        End If

    End Sub
    Sub Bersih()
        dtPeriode.Value = DateTime.Parse(Now.Year & "-" & Now.Month & "-01")
        txtNIP.Clear()
        txtEmployeeID.Text = ""
        txtName.Clear()
        txtFingerCode.Clear()
        txtDept.Clear()
        txtBagian.Clear()
        txtJabatan.Clear()
        If dg.DataSource.rows.count > 0 Then dg.DataSource.rows.clear()
        'If dgKar.DataSource.rows.count > 0 Then dgKar.DataSource.rows.clear()
        'SimpanData, error clear datasource
    End Sub
    Private Sub btnBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBatal.Click
        Bersih()
        txtNIP.Focus()
    End Sub

    Private Sub btnTutup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTutup.Click
        CloseDBALL()
        Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtNIP.Text = "" Or txtEmployeeID.Text = "" Or dg.Rows.Count <= 0 Then
            MsgError("ID Tidak Boleh Kosong")
            Exit Sub
        End If

        Dim i As Integer
        Dim masuk, pulang, masuklembur, pulanglembur, status, _
            keterangan, ket, tgl_upd, user_upd As String
        Dim dsa As DataSet
        Dim tanggal As DateTime
        dsa = Query("select top 1 * from t_absen")
        For i = 0 To dg.Rows.Count - 1
            'MsgOK(dg.Rows(i).Cells(1).Value)
            tanggal = dg.Rows(i).Cells(1).Value

            If IsDBNull(dg.Rows(i).Cells(4).Value) = True Then
                masuk = "0000"
            Else
                If Trim(dg.Rows(i).Cells(4).Value) = "" Then
                    masuk = "0000"
                Else
                    masuk = dg.Rows(i).Cells(4).Value
                End If
            End If

            If IsDBNull(dg.Rows(i).Cells(5).Value) = True Then
                pulang = "0000"
            Else
                If Trim(dg.Rows(i).Cells(5).Value) = "" Then
                    pulang = "0000"
                Else
                    pulang = dg.Rows(i).Cells(5).Value
                End If
            End If

            If IsDBNull(dg.Item(6, i).Value) = True Then
                status = "Alpa"
            Else
                If Trim(dg.Item(6, i).Value) = "" Then
                    status = "Alpa"
                Else
                    status = dg.Item(6, i).Value
                End If
            End If

            If IsDBNull(dg.Rows(i).Cells(7).Value) = True Then
                keterangan = ""
            Else
                If Trim(dg.Rows(i).Cells(7).Value) = "" Then
                    keterangan = ""
                Else
                    keterangan = Microsoft.VisualBasic.Replace(dg.Rows(i).Cells(7).Value, "'", "")
                End If
            End If

            ket = ""
            If IsDBNull(dg.Rows(i).Cells(8).Value) = True Then
                masuklembur = "null"
            Else
                If Trim(dg.Rows(i).Cells(8).Value) = "" Then
                    masuklembur = "null"
                Else
                    masuklembur = "'" & dg.Rows(i).Cells(8).Value & "'"
                    ket = ket & "LM " & dg.Rows(i).Cells(8).Value & " s/d "
                End If
            End If

            If IsDBNull(dg.Rows(i).Cells(9).Value) = True Then
                pulanglembur = "null"
            Else
                If Trim(dg.Rows(i).Cells(9).Value) = "" Then
                    pulanglembur = "null"
                Else
                    pulanglembur = "'" & dg.Rows(i).Cells(9).Value & "'"
                    ket = ket & dg.Rows(i).Cells(9).Value
                End If
            End If

            tgl_upd = "null"
            If Not IsDBNull(dg.Rows(i).Cells(12).Value) Then 'keterangan null
                If dg.Rows(i).Cells(12).Value.ToString.Trim <> "" Then
                    tgl_upd = "'" & Microsoft.VisualBasic.Replace(dg.Rows(i).Cells(12).Value, "'", "") & "'"
                End If
            End If

            user_upd = "null"
            If Not IsDBNull(dg.Rows(i).Cells(13).Value) Then 'keterangan null
                If dg.Rows(i).Cells(13).Value.ToString.Trim <> "" Then
                    user_upd = "'" & Microsoft.VisualBasic.Replace(dg.Rows(i).Cells(13).Value, "'", "") & "'"
                End If
            End If

            StrSQL2 = "select * from t_absen where employee_id='" & txtEmployeeID.Text.Trim & "' and " & vbCrLf & _
                      "convert(varchar(10), tgl, 20)='" & Format(tanggal, "yyyy-MM-dd") & "' "
            'Dbg(StrSQL2)
            dsa = Query(StrSQL2)
            If GetDSRecordCount(dsa) > 0 Then
                strSQL = "update t_absen set jammasuk='" & masuk & "', " & vbCrLf & _
                         "jampulang='" & pulang & "', status='" & status & "', " & vbCrLf & _
                         "lemburmasuk=" & masuklembur & ", lemburpulang=" & pulanglembur & ", " & vbCrLf & _
                         "ket='" & ket & "', " & vbCrLf & _
                         "keterangan='" & keterangan & "', dateedited=" & tgl_upd & ", " & vbCrLf & _
                         "useredited=" & user_upd & " " & vbCrLf & _
                         "where " & vbCrLf & _
                         "employee_id='" & txtEmployeeID.Text.Trim & "' " & vbCrLf & _
                         "and convert(varchar(10), tgl, 20)='" & Format(tanggal, "yyyy-MM-dd") & "' "
                'Dbg(strSQL)
                ExecQuery(strSQL)
            End If
        Next

        clearDataSet(dsa)
        Bersih()
        MsgOK("Data Absen sudah disimpan")
        txtNIP.Focus()
    End Sub

    Private Sub dg_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg.CellContentClick

    End Sub

    Private Sub dg_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg.CellEndEdit
        If dg.CurrentCell.ColumnIndex = 4 Then
            If getDataGridView(dg, "jammasuk").ToString.Trim <> _
               getDataGridView(dg, "jammasuk1").ToString.Trim Then
                dg.Item(13, dg.CurrentRow.Index).Value = UserLogin
                dg.Item(12, dg.CurrentRow.Index).Value = Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss.fff")
            End If
        End If
        If dg.CurrentCell.ColumnIndex = 5 Then
            If getDataGridView(dg, "jampulang").ToString.Trim <> _
               getDataGridView(dg, "jampulang1").ToString.Trim Then
                dg.Item(13, dg.CurrentRow.Index).Value = UserLogin
                dg.Item(12, dg.CurrentRow.Index).Value = Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss.fff")
            End If
        End If
        If dg.CurrentCell.ColumnIndex = 6 Then
            If getDataGridView(dg, "status").ToString.Trim <> _
               getDataGridView(dg, "status1").ToString.Trim Then
                dg.Item(13, dg.CurrentRow.Index).Value = UserLogin
                dg.Item(12, dg.CurrentRow.Index).Value = Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss.fff")
            End If
        End If
        If dg.CurrentCell.ColumnIndex = 7 Then
            If getDataGridView(dg, "keterangan").ToString.Trim <> _
               getDataGridView(dg, "keterangan1").ToString.Trim Then
                dg.Item(13, dg.CurrentRow.Index).Value = UserLogin
                dg.Item(12, dg.CurrentRow.Index).Value = Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss.fff")
            End If
        End If
        If dg.CurrentCell.ColumnIndex = 8 Then
            If getDataGridView(dg, "lemburmasuk").ToString.Trim <> _
               getDataGridView(dg, "lemburmasuk1").ToString.Trim Then
                dg.Item(13, dg.CurrentRow.Index).Value = UserLogin
                dg.Item(12, dg.CurrentRow.Index).Value = Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss.fff")
            End If
        End If
        If dg.CurrentCell.ColumnIndex = 9 Then
            If getDataGridView(dg, "lemburpulang").ToString.Trim <> _
              getDataGridView(dg, "lemburpulang1").ToString.Trim Then
                dg.Item(13, dg.CurrentRow.Index).Value = UserLogin
                dg.Item(12, dg.CurrentRow.Index).Value = Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss.fff")
            End If
        End If
    End Sub

    Private Sub dtPeriode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtPeriode.KeyDown
        If e.KeyCode = 13 Then
            txtNIP.Focus()
        End If
    End Sub

    Private Sub dtPeriode_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtPeriode.ValueChanged

    End Sub
End Class