Public Class BKForm
    Dim isSave As Boolean
    Private Sub BKForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If txtID.Text.Trim = "" Then Exit Sub
        If isSave Then Exit Sub


        If MessageBox.Show("Apakah BK Ingin Disimpan ?", "STAR ENTERPRISE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            'CServer.Close()
            'End
            'frmLogin.Close()
            'Application.Exit()

            SaveData()
            e.Cancel = False
        Else
            'e.Cancel = True
            'delete data, tidak jadi disimpan

            e.Cancel = False
            ExecQuery("delete from t_bk where bk_id='" & txtID.Text & "' ")
        End If
    End Sub

    Private Sub BKForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        OpenDBSupplier()
        isSave = False
        If isiTglBayar Then
            BtnCari.Visible = False
            BtnBuat.Visible = False
        Else
            BtnCari.Visible = True
            BtnBuat.Visible = True
        End If
    End Sub
    Public Sub TambahBK()

        ExecQuery("insert into t_bk (nobk, useradded, dateadded) values ('', '" & UserLogin & "', '" & Format(Now, "yyyy-MM-dd HH:mm:ss.fff") & "')")
        Dim ds1 As DataSet
        ds1 = Query("select max(bk_id) as id from t_bk")
        If ds1.Tables(0).Rows.Count > 0 Then
            If IsDSNull(ds1, "id") Then
                clearDataSet(ds1)
                Exit Sub
            Else
                txtID.Text = ds1.Tables(0).Rows(0).Item("id").ToString.Trim
            End If
        Else
            clearDataSet(ds1)
            Exit Sub
        End If
        clearDataSet(ds1)
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        OpenDBSupplier()
        If isiTglBayar Then
            FrmTglBayar.txtNoBK.Text = txtNoBK.Text
            FrmTglBayar.txtNoGiro.Text = txtNoGiro.Text
            FrmTglBayar.txtbkid.Text = txtID.Text
        End If
        SaveData()
        isSave = True
        If isiTglBayar Then Close()
    End Sub
    Sub SaveData()
        Dim SQLSelect, SQLInsert, SQLUpdate, tglbk, tglgiro As String
        tglbk = "null"
        tglgiro = "null"
        If DtTglBK.Checked Then tglbk = "'" & Format(DtTglBK.Value, "yyyy-MM-dd") & "'"
        If dtTglGiro.Checked Then tglgiro = "'" & Format(dtTglGiro.Value, "yyyy-MM-dd") & "'"
        Dim noterima As String
        noterima = ReplacePetik(txtNoTerima.Text)
        noterima = Replace(noterima, "(", "")
        noterima = Replace(noterima, ")", "")
        SQLSelect = "select * from t_bk where bk_id='" & txtID.Text & "' "
        SQLInsert = "insert into t_bk (nobk, tglbk, vendor_id, totaltagihan, terbilang, bank, " & vbCrLf & _
                    "nogiro, tglgiro, description, noterima, cardname, useradded, dateadded ) values ( '" & txtNoBK.Text & "', " & vbCrLf & _
                    "" & tglbk & ", '" & txtVendorID.Text & "', '" & txtAmount.Text & "', " & vbCrLf & _
                    "'" & txtTerbilang.Text & "', '" & txtBank.Text & "', " & vbCrLf & _
                    "'" & txtNoGiro.Text & "', " & tglgiro & ", '" & txtDescription.Text & "', " & vbCrLf & _
                    "'" & noterima & "', '" & ReplacePetik(txtVendor.Text) & "', '" & UserLogin & "', " & vbCrLf & _
                    "'" & Format(Now, "yyyy-MM-dd HH:mm:ss.fff") & "' ) "
        SQLUpdate = "update t_bk set nobk='" & txtNoBK.Text & "', tglbk=" & tglbk & ", " & vbCrLf & _
                    "vendor_id='" & txtVendorID.Text & "', totaltagihan='" & txtAmount.Text & "', " & vbCrLf & _
                    "terbilang='" & txtTerbilang.Text & "', bank='" & txtBank.Text & "', " & vbCrLf & _
                    "nogiro='" & txtNoGiro.Text & "', tglgiro=" & tglgiro & ", noterima='" & noterima & "', " & vbCrLf & _
                    "description='" & txtDescription.Text & "', cardname='" & ReplacePetik(txtVendor.Text) & "', " & vbCrLf & _
                    "useredited='" & UserLogin & "', dateedited='" & Format(Now, "yyyy-MM-dd HH:mm:ss.fff") & "' " & vbCrLf & _
                    "where bk_id='" & txtID.Text & "' "
        'Dbg(SQLSelect)
        SimpanData(SQLSelect, SQLUpdate, SQLInsert)
    End Sub

    Private Sub txtAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmount.TextChanged
        'If txtTerbilang.Text <> "" Then
        Try
            txtTerbilang.Text = TERBILANG(txtAmount.Text)
        Catch ex As Exception
            MsgError(ex.Message)
        End Try

        'End If
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        PrintBK("'" & txtID.Text & "'")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCari.Click
        OpenDBSupplier()
        Dim s, sql As String
        s = ""
        s = InputBox("Ketik No. BK / No. Giro / Nama Vendor", "Cari BK / Giro")
        sql = "select 1 as x, bk_id, nobk, tglbk, nogiro, tglgiro, vendor_id, totaltagihan, terbilang, bank, description,  cardname " & vbCrLf & _
              "from t_bk " & vbCrLf & _
              "where nobk like '%" & s & "%' or nogiro like '%" & s & "%' or cardname like '%" & s & "%' "
        'Cursor = Cursors.WaitCursor
        If TampilLookup(sql, "", False, StrConSAP) = Windows.Forms.DialogResult.OK Then
            'Cursor = Cursors.Default
            DtTglBK.Checked = False
            DtTglBK.Value = Now
            If IsDBNull(LookupForm.dg.Item(4, LookupForm.dg.CurrentRow.Index).Value.ToString.Trim) = False And _
               LookupForm.dg.Item(4, LookupForm.dg.CurrentRow.Index).Value.ToString.Trim <> "" Then
                DtTglBK.Checked = True
                DtTglBK.Value = Date.Parse(LookupForm.dg.Item(4, LookupForm.dg.CurrentRow.Index).Value.ToString.Trim)
            Else
                'MsgOK("tidak ada isi")
                DtTglBK.Checked = False
                DtTglBK.Value = Now
            End If

            dtTglGiro.Checked = False
            dtTglGiro.Value = Now
            If IsDBNull(LookupForm.dg.Item(6, LookupForm.dg.CurrentRow.Index).Value.ToString.Trim) = False And _
               LookupForm.dg.Item(6, LookupForm.dg.CurrentRow.Index).Value.ToString.Trim <> "" Then
                dtTglGiro.Checked = True
                dtTglGiro.Value = Date.Parse(LookupForm.dg.Item(6, LookupForm.dg.CurrentRow.Index).Value.ToString.Trim)
            Else
                'MsgOK("tidak ada isi")
                dtTglGiro.Checked = False
                dtTglGiro.Value = Now
            End If

            txtNoBK.Text = LookupForm.dg.Item(3, LookupForm.dg.CurrentRow.Index).Value.ToString.Trim
            txtNoGiro.Text = LookupForm.dg.Item(5, LookupForm.dg.CurrentRow.Index).Value.ToString.Trim
            txtID.Text = LookupForm.dg.Item(2, LookupForm.dg.CurrentRow.Index).Value.ToString.Trim
            txtVendorID.Text = LookupForm.dg.Item(7, LookupForm.dg.CurrentRow.Index).Value.ToString.Trim
            txtVendor.Text = getStringFromDB("select cardname from t_bk where bk_id='" & txtID.Text & "' ")

            txtAmount.Text = LookupForm.dg.Item(8, LookupForm.dg.CurrentRow.Index).Value.ToString.Trim
            txtTerbilang.Text = LookupForm.dg.Item(9, LookupForm.dg.CurrentRow.Index).Value.ToString.Trim
            txtBank.Text = LookupForm.dg.Item(10, LookupForm.dg.CurrentRow.Index).Value.ToString.Trim
            txtDescription.Text = LookupForm.dg.Item(11, LookupForm.dg.CurrentRow.Index).Value.ToString.Trim
            txtNoBK.Focus()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuat.Click
        OpenDBSupplier()
        TambahBK()
        'BKForm.txtVendor.Text = txtVendor.Text
        'BKForm.txtVendorID.Text = txtVendorID.Text
        'BKForm.txtAmount.Text = txtTotalTagihan.Text
        'BKForm.txtNoTerima.Text = txtNoTerima.Text
        txtNoBK.Clear()
        txtNoGiro.Clear()
        txtBank.Clear()
        txtDescription.Clear()
        DtTglBK.Checked = False
        DtTglBK.Value = Now
        dtTglGiro.Checked = False
        dtTglGiro.Value = Now
        txtNoBK.Focus()
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        If MsgConfirm("Anda Ingin Hapus BK ID " & txtID.Text & "? ") = vbYes Then
            ExecQuery("delete from t_bk where bk_id='" & txtID.Text & "' ")
            txtID.Clear()
            txtNoBK.Clear()
            DtTglBK.Checked = False
            DtTglBK.Value = Now
            txtVendorID.Text = ""
            txtVendor.Clear()
            txtAmount.Clear()
            txtTerbilang.Clear()
            txtBank.Clear()
            txtNoGiro.Clear()
            dtTglGiro.Checked = False
            dtTglGiro.Value = Now
            txtDescription.Clear()
            txtID.Focus()
        End If
    End Sub

    Private Sub BtnCariVendor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCariVendor.Click
        Dim s, sql As String
        s = ""
        s = InputBox("Cari Vendor", "Ketik Nama Vendor")
        sql = "select 1 as x, cardcode, cardname " & vbCrLf & _
              "from m_vendor " & vbCrLf & _
              "where cardname like '%" & s & "%' "
        'Cursor = Cursors.WaitCursor
        If TampilLookup(sql, "", False, StrConSAP) = Windows.Forms.DialogResult.OK Then
            'Cursor = Cursors.Default
            txtVendorID.Text = LookupForm.dg.Item(2, LookupForm.dg.CurrentRow.Index).Value.ToString.Trim
            txtVendor.Text = LookupForm.dg.Item(3, LookupForm.dg.CurrentRow.Index).Value.ToString.Trim
            txtAmount.Focus()
        End If
    End Sub

    Private Sub txtDescription_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescription.TextChanged

    End Sub
End Class