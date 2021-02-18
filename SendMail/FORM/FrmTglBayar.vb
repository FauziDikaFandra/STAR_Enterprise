Public Class FrmTglBayar

    Private Sub FrmTglBayar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OpenDBSupplier()
        Dim ico As New System.Drawing.Icon(FolderImage & "star.ico") : Me.Icon = ico
        
        'isiComboFromString(CboTipeBayar, getStringFromDB("select description from parameters where code='TIPEBAYAR'"), ";")
        'DtTglBayar.Value = Now
    End Sub
    Sub UpdateJmlBayar(ByVal noterima As String)
        ExecQuery("update t_terima set jumlahbayar=totaltagihan-potongan where noterima='" & noterima & "' ")
    End Sub

    Private Sub BtnSaveKW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveKW.Click
        If cbxIsDirect.Checked Then
            simpanD1("t_terima_t1")
        Else
            simpanD1("t_terima_c")
        End If
        Dim ds As DataSet
        ds = Query("select noterima, isdirect from t_terima where noterima in " & txtNoTerima.Text & " order by noterima")
        For Each ro As DataRow In ds.Tables(0).Rows
            isiTotalTagihan(ro("noterima").ToString.Trim, CInt(ro("isdirect").ToString.Trim))
        Next
        clearDataSet(ds)
        Close()
    End Sub
    Sub simpanD1(ByVal tablename As String)
        Dim SQLUpdate, tglBayar, revisi As String
        tglBayar = "null"
        If DtTglBayar.Checked Then tglBayar = "'" & Format(DtTglBayar.Value, "yyyy-MM-dd") & "'"
        revisi = "0"
        If cbRevisi.Checked Then revisi = "1"

        'tgl_bayar, isrevisi, notebayar, tipebayar, nobk, nogiro
        SQLUpdate = String.Format("update " & tablename & " set " & vbCrLf & _
                                  "tgl_bayar={1}, isrevisi='{2}', " & vbCrLf & _
                                  "notebayar='{3}', tipebayar='{4}', " & vbCrLf & _
                                  "nobk='{5}', nogiro='{6}', bk_id='{9}', " & vbCrLf & _
                                  "useredited='{7}', dateedited='{8}' where noterima in {0} ", _
                                  txtNoTerima.Text, tglBayar, revisi, txtNoteBayar.Text, _
                                  CboTipeBayar.Text, txtNoBK.Text, txtNoGiro.Text, _
                                  UserLogin, Format(Now, "yyyy-MM-dd HH:mm:ss"), txtbkid.Text)
        'Dbg(SQLUpdate)
        ExecQuery(SQLUpdate)
        SQLUpdate = "update t_terima set remarks='" & txtRemarksKW.Text & "' where noterima in " & txtNoTerima.Text & " "
        'Dbg(SQLUpdate)
        ExecQuery(SQLUpdate)
    End Sub
    Sub isiTotalTagihan(ByVal noterima As String, ByVal isDirect As Integer)
        Dim totaltagihan, potongan, jmlbayar, sisa As Double
        'MsgOK("1")
        totaltagihan = 0 : potongan = 0 : jmlbayar = 0 : sisa = 0
        potongan = txtPotongan.Text
        If isDirect = 1 Then
            totaltagihan = CDbl(getStringFromDB("select coalesce(sum(tagihan),0) as tagihan from t_terima_t1 " & vbCrLf & _
                                     "where noterima='" & noterima & "' "))
        Else
            totaltagihan = CDbl(getStringFromDB("select coalesce(sum(tagihan),0) as tagihan from t_terima_c " & vbCrLf & _
                                "where noterima='" & noterima & "' "))
        End If
        jmlbayar = totaltagihan - potongan

        ExecQuery("update t_terima set totaltagihan='" & totaltagihan & "', " & vbCrLf & _
                  "potongan='" & potongan & "', jumlahbayar='" & jmlbayar & "' where noterima='" & noterima & "' ")

        If isDirect = 1 Then
            sisa = CDbl(getStringFromDB("select coalesce(sum(tagihan),0) as tagihan from t_terima_t1 " & vbCrLf & _
                                     "where noterima='" & noterima & "' and " & vbCrLf & _
                                     "tgl_bayar is null and isrevisi=0 "))
        Else
            sisa = CDbl(getStringFromDB("select coalesce(sum(tagihan),0) as tagihan from t_terima_c " & vbCrLf & _
                                     "where noterima='" & noterima & "' and " & vbCrLf & _
                                     "tgl_bayar is null and isrevisi=0 "))
        End If
        ExecQuery("update t_terima set sisatagihan='" & sisa & "' where noterima='" & noterima & "' ")

        Dim q As New ZQ
        Dim tgl As String
        If isDirect = 1 Then
            q.Query("select top 1 tgl_jatuhtempo from t_terima_t1 " & vbCrLf & _
                                "where noterima='" & noterima & "' " & vbCrLf & _
                                "order by tgl_jatuhtempo", "noterima")
        Else
            q.Query("select top 1 tgl_jatuhtempo from t_terima_c " & vbCrLf & _
                               "where noterima='" & noterima & "' " & vbCrLf & _
                               "order by tgl_jatuhtempo", "noterima")
        End If
        tgl = "null"
        If q.RecordCount > 0 Then
            tgl = "'" & Format(Date.Parse(q.GetField("tgl_jatuhtempo")), "yyyy-MM-dd") & "'"
        End If
        'MsgOK("4")
        ExecQuery("update t_terima set tgl_jatuhtempo=" & tgl & " where noterima='" & noterima & "' ")
        'MsgOK("5")
        ExecQuery("update t_terima set issudahbayar=0 where noterima='" & noterima & "' and sisatagihan<>0 ")
        'MsgOK("6")
        ExecQuery("update t_terima set issudahbayar=1 where noterima='" & noterima & "' and sisatagihan=0 ")
        'MsgOK("7")
        q.Dispose()
    End Sub
    Sub isiTotalTagihanx()
        Dim totaltagihan, potongan, jmlbayar, sisa As Double
        'MsgOK("1")
        totaltagihan = 0 : potongan = 0 : jmlbayar = 0 : sisa = 0
        potongan = txtPotongan.Text
        totaltagihan = CDbl(getStringFromDB("select coalesce(sum(tagihan),0) as tagihan from t_terima_t1 " & vbCrLf & _
                                 "where noterima in " & txtNoTerima.Text & " "))
        jmlbayar = totaltagihan - potongan

        ExecQuery("update t_terima set totaltagihan='" & totaltagihan & "', " & vbCrLf & _
                  "potongan='" & potongan & "', jumlahbayar='" & jmlbayar & "' where noterima in " & txtNoTerima.Text & " ")

        sisa = CDbl(getStringFromDB("select coalesce(sum(tagihan),0) as tagihan from t_terima_t1 " & vbCrLf & _
                                 "where noterima in " & txtNoTerima.Text & " and " & vbCrLf & _
                                 "tgl_bayar is null and isrevisi=0 "))
        ExecQuery("update t_terima set sisatagihan='" & sisa & "' where noterima in " & txtNoTerima.Text & " ")

        Dim q As New ZQ
        Dim tgl As String
        q.Query("select top 1 tgl_jatuhtempo from t_terima_t1 " & vbCrLf & _
                            "where noterima in " & txtNoTerima.Text & " " & vbCrLf & _
                            "order by tgl_jatuhtempo", "noterima")
        tgl = "null"
        If q.RecordCount > 0 Then
            tgl = "'" & Format(Date.Parse(q.GetField("tgl_jatuhtempo")), "yyyy-MM-dd") & "'"
        End If
        'MsgOK("4")
        ExecQuery("update t_terima set tgl_jatuhtempo=" & tgl & " where noterima in " & txtNoTerima.Text & " ")
        'MsgOK("5")
        ExecQuery("update t_terima set issudahbayar=0 where noterima in " & txtNoTerima.Text & " and sisatagihan<>0 ")
        'MsgOK("6")
        ExecQuery("update t_terima set issudahbayar=1 where noterima in " & txtNoTerima.Text & " and sisatagihan=0 ")
        'MsgOK("7")
        q.Dispose()
    End Sub

    Private Sub FrmTglBayar_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        CboTipeBayar.Focus()
    End Sub

    Private Sub CboTipeBayar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboTipeBayar.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = 13 Then
            txtNoteBayar.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            DtTglBayar.Focus()
        ElseIf e.KeyCode = 27 Then
            Close()
        End If
    End Sub

    Private Sub CboTipeBayar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipeBayar.SelectedIndexChanged

    End Sub

    Private Sub DtTglBayar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtTglBayar.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = 13 Then
            CboTipeBayar.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            BtnSaveKW.Focus()
        ElseIf e.KeyCode = 27 Then
            Close()
        End If
    End Sub

    Private Sub DtTglBayar_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtTglBayar.ValueChanged

    End Sub

    Private Sub txtNoteBayar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNoteBayar.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = 13 Then
            txtNoBK.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            CboTipeBayar.Focus()
        ElseIf e.KeyCode = 27 Then
            Close()
        End If
    End Sub

    Private Sub txtNoteBayar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNoteBayar.TextChanged

    End Sub

    Private Sub txtNoBK_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNoBK.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = 13 Then
            txtNoGiro.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtNoteBayar.Focus()
        ElseIf e.KeyCode = 27 Then
            Close()
        End If
    End Sub

    Private Sub txtNoBK_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoBK.KeyPress

    End Sub

    Private Sub txtNoBK_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNoBK.TextChanged

    End Sub

    Private Sub txtNoGiro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNoGiro.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = 13 Then
            cbRevisi.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtNoBK.Focus()
        ElseIf e.KeyCode = 27 Then
            Close()
        End If
    End Sub

    Private Sub txtNoGiro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNoGiro.TextChanged

    End Sub

    Private Sub lblTambahDK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTambahDK.Click
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()

        If result = Windows.Forms.DialogResult.OK Then
            lblFileName.Text = OpenFileDialog1.FileName
        Else
            lblFileName.Text = ""
        End If
    End Sub

    Private Sub txtRemarksKW_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRemarksKW.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = 13 Then
            'txtNoGiro.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            'txtNoteBayar.Focus()
        ElseIf e.KeyCode = 27 Then
            Close()
        End If
    End Sub

    Private Sub txtRemarksKW_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemarksKW.TextChanged

    End Sub

    Private Sub txtPotongan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPotongan.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = 13 Then
            BtnSaveKW_Click(sender, e)
        ElseIf e.KeyCode = Keys.Up Then
            txtRemarksKW.Focus()
        ElseIf e.KeyCode = 27 Then
            Close()
        End If
    End Sub

    Private Sub txtPotongan_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPotongan.TextChanged

    End Sub
    Sub cekRemarks()
        If RbtBK.Checked Then
            txtRemarksKW.Enabled = False
            txtRemarksKW.Text = "Proses BK"
        ElseIf RbtGiro1.Checked Then
            txtRemarksKW.Enabled = False
            txtRemarksKW.Text = "Proses Giro"
        ElseIf RbtGiro2.Checked Then
            txtRemarksKW.Enabled = False
            txtRemarksKW.Text = "Giro Sudah Siap"
        ElseIf RbtGiro3.Checked Then
            txtRemarksKW.Enabled = False
            txtRemarksKW.Text = "Giro Belum Dicairkan"
        ElseIf RbtLain.Checked Then
            txtRemarksKW.Enabled = True
            txtRemarksKW.Text = ""
            txtRemarksKW.Focus()
        End If
    End Sub
    Private Sub RbtBK_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbtBK.CheckedChanged
        cekRemarks()
    End Sub

    Private Sub RbtGiro1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbtGiro1.CheckedChanged
        cekRemarks()
    End Sub

    Private Sub RbtGiro2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbtGiro2.CheckedChanged
        cekRemarks()
    End Sub

    Private Sub RbtGiro3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbtGiro3.CheckedChanged
        cekRemarks()
    End Sub

    Private Sub RbtLain_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbtLain.CheckedChanged
        cekRemarks()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        BKForm.TambahBK()
        BKForm.txtVendor.Text = txtVendor.Text
        BKForm.txtVendorID.Text = txtVendorID.Text
        BKForm.txtAmount.Text = txtTotalTagihan.Text
        BKForm.txtNoTerima.Text = txtNoTerima.Text
        BKForm.txtNoBK.Clear()
        BKForm.txtNoGiro.Clear()
        BKForm.txtBank.Clear()
        BKForm.txtDescription.Clear()
        BKForm.DtTglBK.Checked = False
        BKForm.DtTglBK.Value = DtTglBayar.Value
        BKForm.dtTglGiro.Checked = True
        BKForm.dtTglGiro.Value = Now
        isiTglBayar = True
        BKForm.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim s, sql As String
        's = ""
        's = InputBox("Cari BK / Giro", "Ketik No. BK / No. Giro")
        'sql = "select 1 as x, bk_id, nobk, tglbk, nogiro, tglgiro, vendor_id, totaltagihan, terbilang, bank, description " & vbCrLf & _
        '      "from t_bk " & vbCrLf & _
        '      "where nobk like '%" & s & "%' or nogiro like '%" & s & "%' "
        ''Cursor = Cursors.WaitCursor
        'If TampilLookup(Sql, "", False, StrConSAP) = Windows.Forms.DialogResult.OK Then
        '    'Cursor = Cursors.Default
        '    txtNoBK.Text = LookupForm.dg.Item(3, LookupForm.dg.CurrentRow.Index).Value.ToString.Trim
        '    txtNoGiro.Text = LookupForm.dg.Item(5, LookupForm.dg.CurrentRow.Index).Value.ToString.Trim
        '    txtbkid.Text = LookupForm.dg.Item(2, LookupForm.dg.CurrentRow.Index).Value.ToString.Trim
        '    'CboStoreDK.Focus()
        'End If
        Dim s, sql As String
        s = ""
        s = InputBox("Cari BK / Giro", "Ketik No. BK / No. Giro")
        sql = "select 1 as x, bk_id, nobk, tglbk, nogiro, tglgiro, vendor_id, totaltagihan, terbilang, bank, description " & vbCrLf & _
              "from t_bk " & vbCrLf & _
              "where nobk like '%" & s & "%' or nogiro like '%" & s & "%' "
        'Cursor = Cursors.WaitCursor
        If TampilLookup(sql, "", False, StrConSAP) = Windows.Forms.DialogResult.OK Then
            'Cursor = Cursors.Default
            With BKForm
                '.DtTglBK.Checked = False
                '.DtTglBK.Value = Now
                'If Not IsDBNull(LookupForm.dg.Item(4, LookupForm.dg.CurrentRow.Index).Value.ToString.Trim) Then
                '    .DtTglBK.Checked = True
                '    .DtTglBK.Value = Date.Parse(LookupForm.dg.Item(4, LookupForm.dg.CurrentRow.Index).Value.ToString.Trim)
                'End If
                '.dtTglGiro.Checked = False
                '.dtTglGiro.Value = Now
                'If Not IsDBNull(LookupForm.dg.Item(6, LookupForm.dg.CurrentRow.Index).Value.ToString.Trim) Then
                '    .dtTglGiro.Checked = True
                '    .dtTglGiro.Value = Date.Parse(LookupForm.dg.Item(6, LookupForm.dg.CurrentRow.Index).Value.ToString.Trim)
                'End If
                .txtNoBK.Text = LookupForm.dg.Item(3, LookupForm.dg.CurrentRow.Index).Value.ToString.Trim
                .txtNoGiro.Text = LookupForm.dg.Item(5, LookupForm.dg.CurrentRow.Index).Value.ToString.Trim
                .txtID.Text = LookupForm.dg.Item(2, LookupForm.dg.CurrentRow.Index).Value.ToString.Trim
                .txtVendorID.Text = LookupForm.dg.Item(7, LookupForm.dg.CurrentRow.Index).Value.ToString.Trim
                .txtVendor.Text = getStringFromDB("select cardname from m_vendor where cardcode='" & txtVendorID.Text & "' ")
                .txtAmount.Text = LookupForm.dg.Item(8, LookupForm.dg.CurrentRow.Index).Value.ToString.Trim
                .txtTerbilang.Text = LookupForm.dg.Item(9, LookupForm.dg.CurrentRow.Index).Value.ToString.Trim
                .txtBank.Text = LookupForm.dg.Item(10, LookupForm.dg.CurrentRow.Index).Value.ToString.Trim
                .txtDescription.Text = LookupForm.dg.Item(11, LookupForm.dg.CurrentRow.Index).Value.ToString.Trim
                'CboStoreDK.Focus()
                'txtNoBK.Focus()
                isiTglBayar = True
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub BtnPrintBK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrintBK.Click
        PrintBK("'" & txtbkid.Text & "'")
    End Sub
End Class