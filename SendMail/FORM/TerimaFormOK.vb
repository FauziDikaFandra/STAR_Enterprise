Public Class TerimaFormOK
#Region "Procedure"
    Sub TampilVendor(Optional ByVal syarat As String = " (0=0) ", _
                   Optional ByVal SQL As String = "select cardcode as vendor_id, cardname as vendor_name, groupname, city from m_vendor " & vbCrLf & _
                   "where @syarat and @filtertgl " & vbCrLf & _
                   "order by cardname ")
        Dim colHeader() As String = {"Vendor ID", "Vendor Name", "Group Name", "City"}
        Dim colName() As String = {"vendor_id", "vendor_name", "groupname", "city"}
        Dim colWidth() As Integer = {70, 200, 100, 100, 100}
        Dim colVisible() As Boolean = {True, True, True, True}
        SQL = Replace(SQL, "@syarat", syarat)
        SQL = Replace(SQL, "@filtertgl", " (0=0) ")
        Dim dstable As DataSet
        'Dbg(SQL)
        dstable = QueryToDataset(SQL)
        dgVendor.Columns.Clear()
        dgVendor.AutoGenerateColumns = False
        createColumnGrid(dgVendor, colName, colHeader, colVisible, dstable.Tables(0).Columns.Count, colWidth)
        dgVendor.DataSource = dstable.Tables(0)
        'dgVendor.Columns(0).Visible = False
        dgVendor.RowsDefaultCellStyle.BackColor = Color.Bisque
        dgVendor.AlternatingRowsDefaultCellStyle.BackColor = Color.White
    End Sub
    Sub TampilD1(Optional ByVal syarat As String = " (0=0) ", _
                   Optional ByVal SQL As String = "select * from t_terima_t1 " & vbCrLf & _
                   "where @syarat and noterima='@noterima' " & vbCrLf & _
                   "order by nokw ")
        'If LCase(lblTipe.Text) = "new" Then Exit Sub
        SQL = Replace(SQL, "@syarat", syarat)
        SQL = Replace(SQL, "@filtertgl", " (0=0) ")
        SQL = Replace(SQL, "@noterima", txtNoTerima.Text)
        Dim dsKW As DataSet
        'Dbg(SQL)
        dsKW = QueryToDataset(SQL)
        dgKW.AutoGenerateColumns = False
        dgKW.DataSource = dsKW.Tables(0)
        dgKW.RowsDefaultCellStyle.BackColor = Color.Bisque
        dgKW.AlternatingRowsDefaultCellStyle.BackColor = Color.White

        FormatColumnGrid(dgKW, 2, "number", 2)
        FormatColumnGrid(dgKW, 3, "date")
        FormatColumnGrid(dgKW, 4, "date")
    End Sub
    Sub TampilD2(Optional ByVal nokw As String = " (0=0) ", _
                 Optional ByVal syarat As String = " (0=0) ", _
                 Optional ByVal SQL As String = "select * from t_terima_t2 " & vbCrLf & _
                   "where @syarat and @sy and @kw " & vbCrLf & _
                   "order by oke desc, tipe, nomor ")
        'If LCase(lblTipe.Text) = "new" Then Exit Sub
        SQL = Replace(SQL, "@syarat", syarat)
        SQL = Replace(SQL, "@filtertgl", " (0=0) ")
        SQL = Replace(SQL, "@sy", "noterima='" & txtNoTerima.Text & "' " & vbCrLf)
        If Trim(nokw) = "(0=0)" Then
            SQL = Replace(SQL, "@kw", "nokw='" & dgKW.Item(0, dgKW.CurrentRow.Index).Value.ToString.Trim & "' " & vbCrLf)
        Else
            SQL = Replace(SQL, "@kw", "nokw='" & nokw & "' " & vbCrLf)
        End If

        Dim dsDK As DataSet
        'Dbg(Sql)
        dsDK = QueryToDataset(SQL)
        dgDK.AutoGenerateColumns = False
        dgDK.DataSource = dsDK.Tables(0)
        dgDK.RowsDefaultCellStyle.BackColor = Color.Bisque
        dgDK.AlternatingRowsDefaultCellStyle.BackColor = Color.White


        FormatColumnGrid(dgDK, 6, "number", 2)
        FormatColumnGrid(dgDK, 7, "number", 2)
        FormatColumnGrid(dgDK, 8, "number", 2)
        FormatColumnGrid(dgDK, 10, "number", 2)
        FormatColumnGrid(dgDK, 11, "number", 2)

        dgDK.Columns(4).DefaultCellStyle.Format = "yyyy-MM-dd"
        dgDK.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'FormatColumnGrid(dgDK, 4, "date")
    End Sub
    Sub clearALL()
        txtNoTerima.Clear()
        dtTanggal.Value = Now
        txtVendor.Clear()
        txtVendor_ID.Text = ""
        txtContact_ID.Text = ""
        txtSerah.Clear()
        txtTerima.Clear()
        'txtTerima.Text = FormMain.ssUserLogin.Text.Trim
        txtTerima.Text = UserLogin
    End Sub
    Sub SimpanHeader()
        Dim SQLSelect, SQLUpdate, SQLInsert, isTrade, tgl, isSave, isDirect As String

        tgl = "null"
        If dtTanggal.Checked Then tgl = "'" & Format(dtTanggal.Value, "yyyy-MM-dd") & "'"
        isTrade = "1"
        isDirect = "1"
        If rbtConsignment.Checked Then isDirect = "0"
        If rbtDirect.Checked Then isDirect = "1"
        isSave = "0"
        If CbIsSave.Checked Then isSave = "1"

        SQLSelect = String.Format("select * from t_terima where noterima='{0}'", txtNoTerima.Text)
        SQLUpdate = String.Format("update t_terima set tgl={1}, cardcode='{2}', totaltagihan='{3}', serah='{4}', " & _
                                  "terima='{5}', istrade={6}, sisatagihan='{7}', isdirect='{8}', issave='{9}' where noterima='{0}' ", _
                                  txtNoTerima.Text, tgl, txtVendor_ID.Text, FNumberClear(txtTotalTagihan), txtSerah.Text, _
                                  txtTerima.Text, isTrade, FNumberClear(txtSisaTagihan), isDirect, isSave)
        SQLInsert = String.Format("insert into t_terima (noterima, tgl, cardcode, totaltagihan, serah, " & _
                                  "terima, istrade, sisatagihan, isdirect, issave ) values " & _
                                  "('{0}', {1}, '{2}', '{3}', '{4}', '{5}', {6}, '{7}', '{8}', '{9}' )", _
                                  txtNoTerima.Text, tgl, txtVendor_ID.Text, FNumberClear(txtTotalTagihan), txtSerah.Text, _
                                  txtTerima.Text, isTrade, FNumberClear(txtSisaTagihan), isDirect, isSave)
        SimpanData(SQLSelect, SQLUpdate, SQLInsert)
        If lblTipe.Text = "new" Then
            ExecQuery("update t_terima set useradded='" & UserLogin & "', dateadded='" & Format(Now, "yyyy-MM-dd HH:mm:ss") & "' where noterima='" & txtNoTerima.Text & "'")
        Else
            ExecQuery("update t_terima set useredited='" & UserLogin & "', dateedited='" & Format(Now, "yyyy-MM-dd HH:mm:ss") & "' where noterima='" & txtNoTerima.Text & "'")
        End If
        isiTotalTagihan(rbtDirect.Checked)
    End Sub
    Sub simpanD1()
        If txtNoKW.Text.Trim = "" Then
            MsgError("No Kwitansi Masih Kosong")
            Exit Sub
        End If
        If txtTagihanKW.Text.Trim = "" Then
            MsgError("Tagihan Masih Kosong")
            Exit Sub
        End If
        Dim SQLSelect, SQLUpdate, SQLInsert, tglKW, tglBayar, revisi As String

        tglKW = "null"
        If DtTglKW.Checked Then tglKW = "'" & Format(DtTglKW.Value, "yyyy-MM-dd") & "'"
        tglBayar = "null"
        If DtTglBayar.Checked Then tglBayar = "'" & Format(DtTglBayar.Value, "yyyy-MM-dd") & "'"
        revisi = "0"
        If cbRevisi.Checked Then revisi = "1"

        SQLSelect = String.Format("select * from t_terima_t1 where noterima='{0}' and nokw='{1}' ", txtNoTerima.Text, txtNoKW.Text)
        SQLUpdate = String.Format("update t_terima_t1 set tipe='{2}', tagihan='{3}', tgl_jatuhtempo={4}, " & _
                                  "remarks='{5}', tgl_bayar={6}, isrevisi='{7}', whsstr='{8}',  " & _
                                  "notebayar='{9}', tipebayar='{10}', nobk='{11}', nogiro='{12}' where noterima='{0}' and nokw='{1}'", _
                                  txtNoTerima.Text, txtNoKW.Text, "Kwitansi", FNumberClear(txtTagihanKW), tglKW, _
                                  txtRemarksKW.Text, tglBayar, revisi, CboStoreKW.Text, txtNoteBayar.Text, _
                                  CboTipeBayar.Text, txtNoBK.Text, txtNoGiro.Text)
        SQLInsert = String.Format("insert into t_terima_t1 (noterima, nokw, tipe, tagihan, tgl_jatuhtempo, " & _
                                  "remarks, tgl_bayar, isrevisi, whsstr, notebayar, tipebayar, nobk, nogiro) values " & _
                                  "('{0}', '{1}', '{2}', '{3}', {4}, '{5}', {6}, '{7}', '{8}', '{9}', '{10}', '{11}', '{12}')", _
                                  txtNoTerima.Text, txtNoKW.Text, "Kwitansi", FNumberClear(txtTagihanKW), _
                                  tglKW, txtRemarksKW.Text, tglBayar, revisi, CboStoreKW.Text, txtNoteBayar.Text, _
                                  CboTipeBayar.Text, txtNoBK.Text, txtNoGiro.Text)
        'Dbg(SQLSelect)
        'Dbg(SQLUpdate)
        'Dbg(SQLInsert)
        SimpanData(SQLSelect, SQLUpdate, SQLInsert)
        If lblTipe.Text = "new" Then
            ExecQuery(String.Format("update t_terima_t1 set useradded='{2}', dateadded='{3}' where noterima='{0}' and nokw='{1}' ", _
                                    txtNoTerima.Text, txtNoKW.Text, UserLogin, Format(Now, "yyyy-MM-dd HH:mm:ss")))
        Else
            ExecQuery(String.Format("update t_terima_t1 set useredited='{2}', dateedited='{3}' where noterima='{0}' and nokw='{1}' ", _
                                    txtNoTerima.Text, txtNoKW.Text, UserLogin, Format(Now, "yyyy-MM-dd HH:mm:ss")))
        End If
        isiDokumenDirect(txtNoTerima.Text.Trim, txtNoKW.Text.Trim)
    End Sub
    Sub isiDokumenDirect(ByVal noterima As String, ByVal nokw As String)
        'ExecQuery("delete from t_terima_t2 where noterima='" & noterima & "' and nokw='" & nokw & "' and oke<>1")
        Dim dsk, dst As DataSet
        Dim whs As String
        whs = getStringFromDB("select whsstr from t_terima_t1 where noterima='" & noterima & "' and nokw='" & nokw & "' ")
        dst = Query("select tipedokumen from m_tipedokumen order by tipedokumen")
        dsk = Query("select tipedokumen from m_tipedokumen order by tipedokumen")
        For Each ro As DataRow In dsk.Tables(0).Rows
            dst = Query("select * from t_terima_t2 where noterima='" & noterima & "' and nokw='" & nokw & "' " & vbCrLf & _
                        "and tipe='" & ro("tipedokumen").ToString.Trim & "' ")
            If dst.Tables(0).Rows.Count > 0 Then
                'ExecQuery("update set nomor=, tgl=, subtotal=, discount=, dpp=, ppn=, grandtotal=, remarks=, nomorpo=, isppn=, whsstr=, oke=, useredited=, dateedited= " & vbCrLf & _
                '          "where noterima='" & noterima & "' and nokw='" & nokw & "' " & vbCrLf & _
                '          "and tipe='" & ro("tipedokumen").ToString.Trim & "'")
            Else
                ExecQuery("insert into t_terima_t2 (noterima, nokw, tipe, nomor, tgl, subtotal, " & vbCrLf & _
                      "discount, dpp, ppn, grandtotal, remarks, nomorpo, useradded, dateadded, " & vbCrLf & _
                      "isppn, whsstr, oke) values ('" & txtNoTerima.Text & "', '" & txtNoKW.Text & "', " & vbCrLf & _
                      "'" & ro("tipedokumen").ToString.Trim & "', '', " & dt2sql(Now) & ", 0, 0, 0, 0, 0, " & vbCrLf & _
                      "'', null, '" & UserLogin & "', '" & Format(Now, "yyyy-MM-dd HH:mm:ss") & "', " & vbCrLf & _
                      "0, '" & whs & "', 0) ")
            End If
            
            '" &  & "', 
        Next
        clearDataSet(dsk)
        clearDataSet(dst)
    End Sub
    Sub simpanD2()
        Dim SQLSelect, SQLUpdate, SQLInsert, tgl, isPPN As String

        tgl = "null"
        If DtTglD1.Checked Then tgl = "'" & Format(DtTglD1.Value, "yyyy-MM-dd") & "'"
        isPPN = "0"
        If CbIsPPN.Checked Then isPPN = "1"


        SQLSelect = String.Format("select * from t_terima_t2 where noterima='{0}' and nokw='{1}' and tipe='{2}' and nomor='{3}' ", _
                                  txtNoTerima.Text, dgKW.Item(0, dgKW.CurrentRow.Index).Value.ToString.Trim, _
                                  cmbTipeD1.Text, txtNomorD1.Text)
        SQLUpdate = String.Format("update t_terima_t2 set tgl={4}, subtotal='{5}', discount='{6}', dpp='{7}', " & _
                                  "ppn='{8}', grandtotal='{9}', remarks='{10}', isppn='{11}', whsstr='{12}', " & _
                                  "oke='1' " & _
                                  "where noterima='{0}' and nokw='{1}' and tipe='{2}' and nomor='{3}'", _
                                  txtNoTerima.Text, dgKW.Item(0, dgKW.CurrentRow.Index).Value.ToString.Trim, _
                                  cmbTipeD1.Text, txtNomorD1.Text, tgl, FNumberClear(txtSubtotalD1), _
                                  FNumberClear(txtDiscountD1), FNumberClear(txtDPPD1), FNumberClear(txtPPND1), _
                                  FNumberClear(txtGrandtotalD1), txtRemarksD1.Text, isPPN, CboStoreDK.Text)
        SQLInsert = String.Format("insert into t_terima_t2 (noterima, nokw, tipe, nomor, tgl, subtotal, " & _
                                  "discount, dpp, ppn, grandtotal, remarks, isppn, whsstr, oke) values " & _
                                  "('{0}', '{1}', '{2}', '{3}', {4}, '{5}', '{6}', '{7}', '{8}', '{9}', " & _
                                  "'{10}', '{11}', '{12}', '1')", _
                                  txtNoTerima.Text, dgKW.Item(0, dgKW.CurrentRow.Index).Value.ToString.Trim, _
                                  cmbTipeD1.Text, txtNomorD1.Text, tgl, FNumberClear(txtSubtotalD1), _
                                  FNumberClear(txtDiscountD1), FNumberClear(txtDPPD1), FNumberClear(txtPPND1), _
                                  FNumberClear(txtGrandtotalD1), txtRemarksD1.Text, isPPN, CboStoreDK.Text)
        'Dbg(SQLUpdate)
        SimpanData(SQLSelect, SQLUpdate, SQLInsert)
        If lblTipe.Text = "new" Then
            ExecQuery(String.Format("update t_terima_t2 set useradded='{4}', dateadded='{5}' " & _
                                    "where noterima='{0}' and nokw='{1}' and tipe='{2}' and nomor='{3}' ", _
                                    txtNoTerima.Text, txtNoKW.Text, cmbTipeD1.Text, txtNomorD1.Text, _
                                    UserLogin, Format(Now, "yyyy-MM-dd HH:mm:ss")))
        Else
            ExecQuery(String.Format("update t_terima_t2 set useredited='{4}', dateedited='{5}' " & _
                                    "where noterima='{0}' and nokw='{1}' and tipe='{2}' and nomor='{3}' ", _
                                    txtNoTerima.Text, txtNoKW.Text, cmbTipeD1.Text, txtNomorD1.Text, _
                                    UserLogin, Format(Now, "yyyy-MM-dd HH:mm:ss")))
        End If
    End Sub
    Sub isiTotalTagihan(ByVal isDirect As Boolean)
        Dim t As Double

        If isDirect Then
            t = CDbl(getStringFromDB("select coalesce(sum(tagihan),0) as tagihan from t_terima_t1 " & vbCrLf & _
                                 "where noterima='" & txtNoTerima.Text & "' "))
        Else
            t = CDbl(getStringFromDB("select coalesce(sum(tagihan),0) as tagihan from t_terima_c " & vbCrLf & _
                                 "where noterima='" & txtNoTerima.Text & "' "))
        End If
        
        ExecQuery("update t_terima set totaltagihan='" & t & "' " & vbCrLf & _
                  "where noterima='" & txtNoTerima.Text & "' ")
        ExecQuery("update t_terima set jumlahbayar=totaltagihan-potongan " & vbCrLf & _
                  "where noterima='" & txtNoTerima.Text & "' ")
        txtTotalTagihan.Text = t
        FNumber(txtTotalTagihan)

        If isDirect Then
            t = CDbl(getStringFromDB("select coalesce(sum(tagihan),0) as tagihan from t_terima_t1 " & vbCrLf & _
                                     "where noterima='" & txtNoTerima.Text & "' and " & vbCrLf & _
                                     "tgl_bayar is null and isrevisi=0 "))
        Else
            t = CDbl(getStringFromDB("select coalesce(sum(tagihan),0) as tagihan from t_terima_c " & vbCrLf & _
                                     "where noterima='" & txtNoTerima.Text & "' and " & vbCrLf & _
                                     "tgl_bayar is null and isrevisi=0 "))
        End If
        ExecQuery("update t_terima set sisatagihan='" & t & "' where noterima='" & txtNoTerima.Text & "' ")
        txtSisaTagihan.Text = t
        FNumber(txtSisaTagihan)

        Dim q As New ZQ
        Dim tgl As String

        If isDirect Then
            q.Query("select top 1 tgl_jatuhtempo from t_terima_t1 " & vbCrLf & _
                                "where noterima='" & txtNoTerima.Text & "' " & vbCrLf & _
                                "order by tgl_jatuhtempo", "noterima")
        Else
            q.Query("select top 1 tgl_jatuhtempo from t_terima_c " & vbCrLf & _
                                "where noterima='" & txtNoTerima.Text & "' " & vbCrLf & _
                                "order by tgl_jatuhtempo", "noterima")
        End If
        tgl = "null"
        If q.RecordCount > 0 Then
            tgl = "'" & Format(Date.Parse(q.GetField("tgl_jatuhtempo")), "yyyy-MM-dd") & "'"
        End If
        ExecQuery("update t_terima set tgl_jatuhtempo=" & tgl & " where noterima='" & txtNoTerima.Text & "' ")

        'Dbg("update t_terima set issudahbayar=0 where noterima='" & txtNoTerima.Text & "' and sisatagihan<>0 ")
        'Dbg("update t_terima set issudahbayar=1 where noterima='" & txtNoTerima.Text & "' and sisatagihan=0 ")
        ExecQuery("update t_terima set issudahbayar=0 where noterima='" & txtNoTerima.Text & "' and sisatagihan<>0 ")
        ExecQuery("update t_terima set issudahbayar=1 where noterima='" & txtNoTerima.Text & "' and sisatagihan=0 ")

        q.Dispose()

        FNumber(txtTotalTagihan)
        FNumber(txtSisaTagihan)
    End Sub
#End Region
#Region "Form"
    Sub LoadImage()
        Dim ico As New System.Drawing.Icon(FolderImage & "star.ico") : Me.Icon = ico
        'BtnSave.Image = Image.FromFile(FolderImage & "save16.png")
        'BtnReload.Image = Image.FromFile(FolderImage & "reload16.png")
        'BtnDateTemplate.Image = Image.FromFile(FolderImage & "date16.png")
        'BtnPrint.Image = Image.FromFile(FolderImage & "print16.png")
        'BtnMenu.Image = Image.FromFile(FolderImage & "menu16.png")
        'BtnAdd.Image = Image.FromFile(FolderImage & "add16.png")
        'BtnEdit.Image = Image.FromFile(FolderImage & "edit16.png")
        'BtnDelete.Image = Image.FromFile(FolderImage & "delete16.png")
        'BtnClose.Image = Image.FromFile(FolderImage & "close16.png")
    End Sub

    Private Sub TerimaFormOK_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If CbIsSave.Checked = False Then
            If MsgConfirm("Save Belum Diceklist, Apakah Data Ingin Disimpan ?") = vbYes Then
                CbIsSave.Checked = True
                SimpanHeader()
            Else
                'MsgOK(txtNoTerima.Text.Trim)
                ExecQuery("delete from t_terima    where noterima='" & txtNoTerima.Text.Trim & "'")
                ExecQuery("delete from t_terima_c  where noterima='" & txtNoTerima.Text.Trim & "'")
                ExecQuery("delete from t_terima_t1 where noterima='" & txtNoTerima.Text.Trim & "'")
                ExecQuery("delete from t_terima_t2 where noterima='" & txtNoTerima.Text.Trim & "'")
            End If
        End If
    End Sub

    Private Sub TerimaFormOK_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

    End Sub
    Private Sub TerimaForm2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OpenDBSupplier()
        dgConsignment.Font = lblTipe.Font
        'isiComboDokumen()
        LoadImage()
    End Sub
    'Sub isiComboDokumen()
    '    Dim ds As DataSet
    '    ds = QueryToDataset("select tipedokumen from m_tipedokumen order by tipedokumen")
    '    colDokumen.Items.Clear()
    '    For Each ro As DataRow In ds.Tables(0).Rows
    '        colDokumen.Items.Add(ro("tipedokumen").ToString.Trim)
    '    Next
    '    ds.Dispose()
    'End Sub
    Sub isiCombostore()
        'select WhsName as Code, WhsName + ' - ' + WhsCode as WhsName  from Store Order by WhsCode
        'Dim ds As DataSet
        'ds = QueryToDataset("select WhsName as Code, WhsName + ' - ' + WhsCode as WhsName  from Store Order by WhsCode")
        'colStore.Items.Clear()
        'For Each ro As DataRow In ds.Tables(0).Rows
        '    colStore.Items.Add(ro("whsname").ToString.Trim)
        'Next
        'ds.Dispose()
    End Sub
    Private Sub TerimaForm2_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        GbDK.Visible = False
        GbKW.Visible = False
        isiComboFromSQL(cmbTipeD1, "select tipedokumen from m_tipedokumen order by tipedokumen", "tipedokumen", "tipedokumen")
        isiComboFromSQL(CboStoreKW, "select whsstr from store order by whscode", "whsstr", "whsstr")
        isiComboFromSQL(CboStoreDK, "select whsstr from store order by whscode", "whsstr", "whsstr")
        isiComboFromString(CboTipeBayar, getStringFromDB("select description from parameters where code='TIPEBAYAR'"), ";")
        If lblTipe.Text = "new" Then
            'lblTambahKW.Enabled = False
            'lblTambahDK.Enabled = False
            'dgKW.Enabled = False
            'dgDK.Enabled = False
        Else
            lblTambahKW.Enabled = True
            'lblTambahDK.Enabled = True
            BtnSaveDokumen.Enabled = True
            dgKW.Enabled = True
            dgDK.Enabled = True
        End If
        txtNoTerima.Focus()
    End Sub
#End Region
#Region "Button"
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        GbDgVendor.Left = 123
        GbDgVendor.Top = 94
        GbDgVendor.BringToFront()
        If GbDgVendor.Visible Then
            GbDgVendor.Visible = False
        Else
            GbDgVendor.Visible = True
            txtCariKaryawan.Focus()
        End If
        'TampilVendor(" cardname like '%" & txtCariKaryawan.Text.Trim & "%' ")
        TampilVendor(" cardcode like '%" & txtCariKaryawan.Text.Trim & "%' or cardname like '%" & txtCariKaryawan.Text.Trim & "%' ")
    End Sub
#End Region
#Region "Header"
    Private Sub txtNoTerima_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNoTerima.KeyDown
        If e.KeyCode = 13 Then
            dtTanggal.Focus()
        End If
    End Sub
    Private Sub dtTanggal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtTanggal.KeyDown
        If e.KeyCode = 13 Then
            txtVendor.Focus()
        End If
    End Sub
    Private Sub txtVendor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVendor.KeyDown
        If e.KeyCode = 13 Then
            txtSerah.Focus()
        End If
    End Sub
    Private Sub txtSerah_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSerah.KeyDown
        If e.KeyCode = 13 Then
            SimpanHeader()
            txtTerima.Focus()
        End If
    End Sub
    Private Sub txtTerima_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTerima.KeyDown
        If e.KeyCode = 13 Then
            'rbTrade.Focus()
            SimpanHeader()
            If rbtDirect.Checked Then
                lblTambahKW_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub txtCariKaryawan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCariKaryawan.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then
            dgVendor.Focus()
        ElseIf e.KeyCode = Keys.Escape Then
            GbDgVendor.Visible = False
            txtSerah.Focus()
        End If
    End Sub

    Private Sub txtNoTerima_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtNoTerima.MouseDown

    End Sub
    Private Sub txtNoTerima_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNoTerima.TextChanged
        Dim q As New ZQ
        q.Query("select t.*, v.cardname from t_terima t " & vbCrLf & _
                "left join m_vendor v on t.cardcode=v.cardcode where noterima='" & txtNoTerima.Text & "' ", "noterima")
        If q.RecordCount > 0 Then
            txtVendor_ID.Text = q.GetField("cardcode")
            txtVendor.Text = q.GetField("cardname")
            txtSerah.Text = q.GetField("serah")

            If q.IsNull("terima") Then
                txtTerima.Text = UserLogin
            Else
                txtTerima.Text = q.GetField("terima")
            End If

            If q.IsNull("totaltagihan") Then
                txtTotalTagihan.Text = "0"
            Else
                txtTotalTagihan.Text = q.GetField("totaltagihan")
            End If
            If q.IsNull("sisatagihan") Then
                txtSisaTagihan.Text = "0"
            Else
                txtSisaTagihan.Text = q.GetField("sisatagihan")
            End If
            

            dtTanggal.Checked = True
            If q.IsNull("tgl") Then
                dtTanggal.Value = Now
            Else
                dtTanggal.Value = q.GetField("tgl")
            End If

            rbtDirect.Checked = False
            rbtConsignment.Checked = False
            rbtDirect.Enabled = False
            rbtConsignment.Enabled = False

            If q.GetField("isdirect") = 1 Then
                rbtDirect.Checked = True
                rbtDirect.Enabled = True
                TampilDirect()
                TampilConsignment(False)
            End If

            If q.GetField("isdirect") = 0 Then
                rbtConsignment.Checked = True
                rbtConsignment.Enabled = True
                TampilConsignment()
                TampilDirect(False)
                TampilGridConsignment()
            End If

            CbIsSave.Checked = False
            If q.GetField("issave") = 1 Then
                CbIsSave.Checked = True
            End If
            'q.GetDateTime("tgl", dtTanggal)
            'q.GetDateTime("tgl_bayar", DtTglBayar)
            'q.GetDateTime("tgl_jatuhtempo", DtTglJatuhTempo)
            FNumber(txtTotalTagihan)
            FNumber(txtSisaTagihan)
        Else
            dtTanggal.Value = Now
            DtTglBayar.Checked = False
            txtVendor_ID.Text = ""
            txtVendor.Clear()
            txtSerah.Clear()
            txtTerima.Clear()
            txtTotalTagihan.Clear()
            txtSisaTagihan.Clear()

            rbtDirect.Checked = True
            rbtConsignment.Checked = False
            rbtDirect.Enabled = True
            rbtConsignment.Enabled = True
        End If
        q.Dispose()
        If lblTipe.Text = "new" Then
            rbtDirect.Enabled = True
            rbtConsignment.Enabled = True
        End If
        TampilD1()
        'TampilD2(getStringFromDB("select top 1 nokw from t_terima_t1 where noterima='" & txtNoTerima.Text & "' order by nokw"))
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim q As New ZQ
        q.Query("select * from t_terima " & vbCrLf & _
                " where noterima='" & txtNoTerima.Text & "' ", "noterima")
        If q.RecordCount > 0 Then
            q.Edit()
            q.SetField("useredited", UserLogin)
            q.SetField("dateedited", Now)
        Else
            q.Add()
            q.SetField("useradded", UserLogin)
            q.SetField("dateadded", Now)
        End If
        q.SetField("serah", txtSerah.Text)
        q.Save()
        q.Dispose()
    End Sub
    Private Sub txtCariKaryawan_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCariKaryawan.TextChanged
        TampilVendor(" cardcode like '%" & txtCariKaryawan.Text.Trim & "%' or cardname like '%" & txtCariKaryawan.Text.Trim & "%' ")
    End Sub
#End Region
#Region "DataGridView"
    Private Sub dgVendor_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgVendor.CellContentClick

    End Sub
    Private Sub dgVendor_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgVendor.CellContentDoubleClick
        txtVendor_ID.Text = getDataGridView(dgVendor, "vendor_id")
        txtVendor.Text = getDataGridView(dgVendor, "vendor_name")
        GbDgVendor.Visible = False
        txtSerah.Focus()
    End Sub
    Private Sub dgVendor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgVendor.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtVendor_ID.Text = getDataGridView(dgVendor, "vendor_id")
            txtVendor.Text = getDataGridView(dgVendor, "vendor_name")
            GbDgVendor.Visible = False
            txtSerah.Focus()
        ElseIf e.KeyCode = Keys.Escape Then
            GbDgVendor.Visible = False
            txtVendor.Focus()
        End If
    End Sub
#End Region
    Sub HideGroupBox()
        GbKW.Visible = False
        GbDK.Visible = False
        disableBack(True)
    End Sub
    Sub disableBack(Optional ByVal tipe As Boolean = False)
        txtNoTerima.Enabled = tipe
        dtTanggal.Enabled = tipe
        txtVendor.Enabled = tipe
        txtSerah.Enabled = tipe
        txtTerima.Enabled = tipe

        lblTambahKW.Enabled = tipe
        'lblTambahDK.Enabled = tipe
        BtnSaveDokumen.Enabled = tipe
        dgKW.Enabled = tipe
        dgDK.Enabled = tipe
        Button1.Enabled = tipe
        BtnPrint.Enabled = tipe
        txtTotalTagihan.Enabled = tipe
    End Sub
#Region "KW"
    Private Sub txtNoKW_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNoKW.KeyDown
        If e.KeyCode = 13 Then
            CboStoreKW.Focus()
        ElseIf e.KeyCode = 27 Then : HideGroupBox()
        End If
    End Sub

    Private Sub txtTagihanKW_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTagihanKW.GotFocus
        FNumberClear(txtTagihanKW)
    End Sub
    Private Sub txtTagihanKW_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTagihanKW.LostFocus
        FNumber(txtTagihanKW)
    End Sub
    Private Sub txtTagihanKW_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTagihanKW.KeyPress
        onlyNumber(e)
        'If Asc(e.KeyChar) <> 8 And Asc(e.KeyChar) <> Asc(DecimalSeparator) Then
        '    If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
        '        e.Handled = True
        '    End If
        'End If
    End Sub
    Private Sub txtTagihanKW_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTagihanKW.KeyDown
        If e.KeyCode = 13 Then
            DtTglKW.Focus()
        ElseIf e.KeyCode = 27 Then : HideGroupBox()
        End If
    End Sub
    Private Sub DtTglKW_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtTglKW.KeyDown
        If e.KeyCode = 13 Then
            txtRemarksD1.Focus()
        ElseIf e.KeyCode = 27 Then : HideGroupBox()
        End If
    End Sub
    Private Sub DtTglBayar_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtTglBayar.KeyDown
        If e.KeyCode = 13 Then
            CboTipeBayar.Focus()
        ElseIf e.KeyCode = 27 Then : HideGroupBox()
        End If
    End Sub
    Private Sub txtRemarksKW_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRemarksKW.KeyDown
        If e.KeyCode = 27 Then
            HideGroupBox()
        End If
    End Sub
    Private Sub BtnSaveKW_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnSaveKW.KeyDown
        If e.KeyCode = 27 Then
            HideGroupBox()
        End If
    End Sub
    Sub clearKW()
        txtNoKW.Clear()
        txtTagihanKW.Clear()
        DtTglKW.Value = DateAdd(DateInterval.Day, 14, Now)
        DtTglBayar.Value = DtTglKW.Value
        DtTglBayar.Checked = False
        txtNoKW.ReadOnly = False
        txtRemarksKW.Clear()
    End Sub
    Private Sub lblTambahKW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTambahKW.Click
        disableBack()
        GbKW.BringToFront()
        GbDK.Visible = False
        GbKW.Visible = True
        GbKW.Top = (Me.ClientSize.Height / 2) - (GbKW.Height / 2)
        GbKW.Left = (Me.ClientSize.Width / 2) - (GbKW.Width / 2)
        clearKW()
        txtNoKW.Enabled = True
        txtNoKW.Focus()
    End Sub
    Sub EditKW()
        disableBack()
        GbKW.BringToFront()
        GbDK.Visible = False
        GbKW.Visible = True
        GbKW.Top = (Me.ClientSize.Height / 2) - (GbKW.Height / 2)
        GbKW.Left = (Me.ClientSize.Width / 2) - (GbKW.Width / 2)
        clearKW()
        txtNoKW.Text = dgKW.Item(0, dgKW.CurrentRow.Index).Value.ToString.Trim
        txtNoKW.Enabled = False
        txtTagihanKW.Focus()
    End Sub
    Private Sub BtnSaveKW_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveKW.Click
        SimpanHeader()
        simpanD1()
        GbKW.Visible = False
        GbDK.Visible = False
        disableBack(True)
        TampilD1()
    End Sub
    Private Sub dgKW_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgKW.CellContentDoubleClick
        If dgKW.RowCount > 0 Then
            EditKW()
        End If
    End Sub
    Private Sub txtNoKW_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNoKW.TextChanged
        Dim ds1 As DataSet
        ds1 = QueryToDataset("select * from t_terima_t1 " & vbCrLf & _
                "where noterima='" & txtNoTerima.Text & "' and nokw='" & txtNoKW.Text & "' ")
        If ds1.Tables(0).Rows.Count > 0 Then
            txtTagihanKW.Text = ds1.Tables(0).Rows(0).Item("tagihan").ToString.Trim
            txtRemarksKW.Text = ds1.Tables(0).Rows(0).Item("remarks").ToString.Trim
            CboStoreKW.Text = ds1.Tables(0).Rows(0).Item("whsstr").ToString.Trim
            CboTipeBayar.Text = ds1.Tables(0).Rows(0).Item("tipebayar").ToString.Trim
            txtNoteBayar.Text = ds1.Tables(0).Rows(0).Item("notebayar").ToString.Trim
            txtNoBK.Text = ds1.Tables(0).Rows(0).Item("nobk").ToString.Trim

            DtTglKW.Checked = False
            DtTglKW.Value = DateAdd(DateInterval.Day, 14, Now)
            If Not IsDBNull(ds1.Tables(0).Rows(0).Item("tgl_jatuhtempo")) Then
                DtTglKW.Checked = True
                DtTglKW.Value = ds1.Tables(0).Rows(0).Item("tgl_jatuhtempo")
            End If

            DtTglBayar.Value = DateAdd(DateInterval.Day, 14, Now)
            DtTglBayar.Checked = False
            If Not IsDBNull(ds1.Tables(0).Rows(0).Item("tgl_bayar")) Then
                DtTglBayar.Checked = True
                DtTglBayar.Value = ds1.Tables(0).Rows(0).Item("tgl_bayar")
            End If
        Else
            txtTagihanKW.Clear()
            DtTglKW.Value = DateAdd(DateInterval.Day, 14, Now)
            DtTglBayar.Value = DtTglKW.Value
            DtTglBayar.Checked = False
            txtNoKW.ReadOnly = False
            txtRemarksKW.Clear()
            CboStoreKW.Text = ""
            CboTipeBayar.Text = ""
            txtNoteBayar.Clear()
            txtNoBK.Clear()
        End If
        ds1.Dispose()
    End Sub
#End Region
#Region "DK"
    Private Sub cmbTipeD1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbTipeD1.KeyDown
        If e.KeyCode = 13 Then
            txtNomorD1.Focus()
        ElseIf e.KeyCode = 27 Then : HideGroupBox()
        End If
    End Sub

    Private Sub txtNomorD1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNomorD1.GotFocus
        
    End Sub
    Private Sub txtNomorD1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNomorD1.KeyDown
        If e.KeyCode = 13 Then
            CboStoreDK.Focus()
        ElseIf e.KeyCode = 27 Then : HideGroupBox()
        End If
    End Sub
    Private Sub DtTglD1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtTglD1.KeyDown
        If e.KeyCode = 13 Then
            txtRemarksD1.Focus()
        ElseIf e.KeyCode = 27 Then : HideGroupBox()
        End If
    End Sub
    Private Sub txtRemarksD1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRemarksD1.KeyDown
        If e.KeyCode = 27 Then
            HideGroupBox()
        End If
    End Sub

    Private Sub txtSubtotalD1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSubtotalD1.GotFocus
        FNumberClear(txtSubtotalD1)
    End Sub
    Private Sub txtSubtotalD1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSubtotalD1.KeyDown
        If e.KeyCode = 13 Then
            txtDiscountD1.Focus()
        ElseIf e.KeyCode = 27 Then : HideGroupBox()
        End If
    End Sub

    Private Sub txtDiscountD1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDiscountD1.GotFocus
        FNumberClear(txtDiscountD1)
    End Sub
    Private Sub txtDiscountD1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDiscountD1.KeyDown
        If e.KeyCode = 13 Then
            txtDPPD1.Focus()
        ElseIf e.KeyCode = 27 Then : HideGroupBox()
        End If
    End Sub

    Private Sub txtDPPD1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDPPD1.GotFocus
        'FNumberClear(txtDPPD1)
    End Sub

    Private Sub txtDPPD1_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDPPD1.HandleCreated

    End Sub
    Private Sub txtDPPD1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDPPD1.KeyDown
        If e.KeyCode = 13 Then
            txtPPND1.Focus()
        ElseIf e.KeyCode = 27 Then : HideGroupBox()
        End If
    End Sub

    Private Sub txtPPND1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPPND1.GotFocus
        'FNumberClear(txtPPND1)
    End Sub
    Private Sub txtPPND1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPPND1.KeyDown
        If e.KeyCode = 13 Then
            txtGrandtotalD1.Focus()
        ElseIf e.KeyCode = 27 Then : HideGroupBox()
        End If
    End Sub

    Private Sub txtGrandtotalD1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGrandtotalD1.GotFocus
        'FNumberClear(txtGrandtotalD1)
    End Sub
    Private Sub txtGrandtotalD1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtGrandtotalD1.KeyDown
        If e.KeyCode = 13 Then
            BtnSaveD1_Click_1(sender, e)
        ElseIf e.KeyCode = 27 Then : HideGroupBox()
        End If
    End Sub
    Private Sub BtnSaveD1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnSaveD1.KeyDown
        If e.KeyCode = 27 Then
            HideGroupBox()
        End If
    End Sub
    Sub CariPO()
        Dim SQL As String
        Dim s As String = ""
        s = InputBox("Ketik No Purchase Order", "Cari Purchase Order")
        If s.Trim = "" Then
            MsgError("No. PO harus diisi")
            txtNomorD1.Clear()
            txtNomorD1.Focus()
            Cursor = Cursors.Default
            Exit Sub
        End If

        SQL = "select DocEntry, DocNum,  CardName, CardCode, docdate as PostingDate, DocDueDate as DeliveryDate, " & vbCrLf & _
              "TaxDate as DocumentDate, DocTotal from OPOR " & vbCrLf & _
              "where docnum like '%" & s & "%' "
        Cursor = Cursors.WaitCursor
        If TampilLookup(SQL, "", False, StrConSAP) = Windows.Forms.DialogResult.OK Then
            Cursor = Cursors.Default
            txtNomorD1.Text = LookupForm.dg.Item(2, LookupForm.dg.CurrentRow.Index).Value.ToString.Trim
            CboStoreDK.Focus()
        End If
    End Sub
    Sub CariGR()
        Dim SQL As String
        Dim s As String = ""
        s = InputBox("Ketik No Good Receipt", "Cari Good Receipt")
        If s.Trim = "" Then
            MsgError("No. GR harus diisi")
            txtNomorD1.Clear()
            txtNomorD1.Focus()
            Cursor = Cursors.Default
            Exit Sub
        End If

        SQL = "select DocEntry, DocNum,  CardName, CardCode, docdate as PostingDate, DocDueDate as DeliveryDate, " & vbCrLf & _
              "TaxDate as DocumentDate, DocTotal from OPDN " & vbCrLf & _
              "where docnum like '%" & s & "%' "
        Cursor = Cursors.WaitCursor
        If TampilLookup(SQL, "", False, StrConSAP) = Windows.Forms.DialogResult.OK Then
            Cursor = Cursors.Default
            txtNomorD1.Text = LookupForm.dg.Item(2, LookupForm.dg.CurrentRow.Index).Value.ToString.Trim
            CboStoreDK.Focus()
        End If
    End Sub
    Private Sub txtNomorD1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNomorD1.TextChanged
        TampilFormD2()
    End Sub

    Private Sub cmbTipeD1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipeD1.LostFocus
        
    End Sub
    Private Sub cmbTipeD1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipeD1.SelectedIndexChanged
        TampilFormD2()
        txtNomorD1.ReadOnly = False
        If (LCase(cmbTipeD1.Text.Trim) = "copy purchase order") Then
            txtNomorD1.ReadOnly = True
            BtnPO.Focus()
        ElseIf (LCase(cmbTipeD1.Text.Trim) = "copy good receipt") Then
            txtNomorD1.ReadOnly = True
            BtnPO.Focus()
        End If
    End Sub
    Private Sub cmbTipeD1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipeD1.TextChanged
        txtNomorD1.ReadOnly = True
        If (LCase(cmbTipeD1.Text.Trim) = "copy purchase order") Then
            txtNomorD1.ReadOnly = False
            BtnPO.Focus()
        ElseIf (LCase(cmbTipeD1.Text.Trim) = "copy good receipt") Then
            txtNomorD1.ReadOnly = False
            BtnPO.Focus()
        End If
    End Sub
    Sub clearDK()
        cmbTipeD1.Text = ""
        txtNomorD1.Clear()
        DtTglD1.Value = Now
        DtTglD1.Checked = True
        txtRemarksD1.Clear()
        txtSubtotalD1.Clear()
        txtDiscountD1.Clear()
        txtDPPD1.Clear()
        txtPPND1.Clear()
        txtGrandtotalD1.Clear()
    End Sub
    Private Sub lblTambahDK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTambahDK.Click
        Exit Sub
        If dgKW.RowCount <= 0 Then Exit Sub
        disableBack()
        GbDK.BringToFront()
        GbKW.Visible = False
        GbDK.Visible = True
        GbDK.Top = (Me.ClientSize.Height / 2) - (GbDK.Height / 2)
        GbDK.Left = (Me.ClientSize.Width / 2) - (GbDK.Width / 2)
        cmbTipeD1.Enabled = True
        txtNomorD1.Enabled = True
        CbIsPPN.Checked = True
        clearDK()
        cmbTipeD1.Focus()
    End Sub
    Sub EditDK()
        disableBack()
        GbDK.BringToFront()
        GbKW.Visible = False
        GbDK.Visible = True
        GbDK.Top = (Me.ClientSize.Height / 2) - (GbDK.Height / 2)
        GbDK.Left = (Me.ClientSize.Width / 2) - (GbDK.Width / 2)
        clearDK()
        cmbTipeD1.Text = dgDK.Item(0, dgDK.CurrentRow.Index).Value.ToString.Trim
        txtNomorD1.Text = dgDK.Item(1, dgDK.CurrentRow.Index).Value.ToString.Trim
        cmbTipeD1.Enabled = False
        txtNomorD1.Enabled = False
        DtTglD1.Focus()
    End Sub
    Private Sub BtnSaveD1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveD1.Click
        SimpanHeader()
        simpanD2()
        GbKW.Visible = False
        GbDK.Visible = False
        TampilD1()
        TampilD2()
        disableBack(True)
    End Sub
    Private Sub dgDK_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDK.CellContentDoubleClick
        If dgKW.RowCount > 0 Then
            EditDK()
        End If
    End Sub
    Sub TampilFormD2()
        'If LCase(lblTipe.Text) = "new" Then Exit Sub
        If dgKW.RowCount <= 0 Then Exit Sub
        Dim ds1 As DataSet
        ds1 = QueryToDataset("select * from t_terima_t2 " & vbCrLf & _
                "where noterima='" & txtNoTerima.Text & "' and " & vbCrLf & _
                "nokw='" & dgKW.Item(0, dgKW.CurrentRow.Index).Value.ToString.Trim & "' and " & vbCrLf & _
                "tipe='" & cmbTipeD1.Text & "' and " & vbCrLf & _
                "nomor='" & txtNomorD1.Text & "' ")
        If ds1.Tables(0).Rows.Count > 0 Then
            DtTglD1.Value = Now
            DtTglD1.Checked = False
            If Not IsDBNull(ds1.Tables(0).Rows(0).Item("tgl")) Then
                DtTglD1.Checked = True
                DtTglD1.Value = ds1.Tables(0).Rows(0).Item("tgl")
            End If

            txtSubtotalD1.Text = ds1.Tables(0).Rows(0).Item("subtotal").ToString.Trim
            txtDiscountD1.Text = ds1.Tables(0).Rows(0).Item("discount").ToString.Trim
            CboStoreDK.Text = ds1.Tables(0).Rows(0).Item("whsstr").ToString.Trim
            txtDPPD1.Text = ds1.Tables(0).Rows(0).Item("dpp").ToString.Trim
            txtPPND1.Text = ds1.Tables(0).Rows(0).Item("ppn").ToString.Trim
            If CDbl(txtPPND1.Text) = 0 Then
                CbIsPPN.Checked = False
            Else
                CbIsPPN.Checked = True
            End If
            txtGrandtotalD1.Text = ds1.Tables(0).Rows(0).Item("grandtotal").ToString.Trim
            txtRemarksD1.Text = ds1.Tables(0).Rows(0).Item("remarks").ToString.Trim
            FNumber(txtSubtotalD1)
            FNumber(txtDiscountD1)
            FNumber(txtDPPD1)
            FNumber(txtPPND1)
            FNumber(txtGrandtotalD1)
        Else
            DtTglD1.Value = Now
            DtTglD1.Checked = False
            CbIsPPN.Checked = True
            txtSubtotalD1.Clear()
            txtDiscountD1.Clear()
            txtDPPD1.Clear()
            txtPPND1.Clear()
            txtGrandtotalD1.Clear()
            txtRemarksD1.Clear()
        End If
        ds1.Dispose()
    End Sub
#End Region

    Private Sub dgKW_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgKW.CellClick
        TampilD2()
    End Sub

    Private Sub dgKW_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgKW.CellContentClick

    End Sub





    Private Sub txtRemarksKW_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemarksKW.TextChanged

    End Sub



    Private Sub dgKW_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgKW.RowEnter
        'TampilD2()
        'MsgOK("tes")
    End Sub

    Private Sub dgDK_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDK.CellContentClick
        
    End Sub




    Private Sub txtRemarksD1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemarksD1.TextChanged

    End Sub

    Private Sub txtDPPD1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDPPD1.KeyPress
        onlyNumber(e)
    End Sub

    Private Sub txtDPPD1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDPPD1.LostFocus
        FNumber(txtDPPD1)
    End Sub




    Private Sub txtDPPD1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDPPD1.TextChanged

    End Sub

    Private Sub dgKW_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles dgKW.Scroll

    End Sub

    Private Sub dgKW_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgKW.SelectionChanged
        'MsgOK("1")
        TampilD2()
    End Sub

    Private Sub dgKW_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgKW.KeyDown
        If e.KeyCode = 46 Then
            If MsgConfirm("Anda Yakin Ingin Hapus No Kwitansi : " & dgKW.Item(0, dgKW.CurrentRow.Index).Value.ToString.Trim & " ?") = vbYes Then
                ExecQuery("delete from t_terima_t2 where noterima='" & txtNoTerima.Text & "' and " & vbCrLf & _
                          "nokw='" & dgKW.Item(0, dgKW.CurrentRow.Index).Value.ToString.Trim & "' ")
                ExecQuery("delete from t_terima_t1 where noterima='" & txtNoTerima.Text & "' and " & vbCrLf & _
                          "nokw='" & dgKW.Item(0, dgKW.CurrentRow.Index).Value.ToString.Trim & "' ")
                isiTotalTagihan(rbtDirect.Checked)
                TampilD1()
            End If
        End If
    End Sub

    Private Sub dgDK_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgDK.KeyDown
        If e.KeyCode = 46 Then
            If MsgConfirm("Anda Yakin Ingin Hapus No " & dgDK.Item(0, dgDK.CurrentRow.Index).Value.ToString.Trim & " : " & _
                          dgDK.Item(1, dgDK.CurrentRow.Index).Value.ToString.Trim & " ?") = vbYes Then
                ExecQuery("delete from t_terima_t2 where noterima='" & txtNoTerima.Text & "' and " & vbCrLf & _
                          "nokw='" & dgKW.Item(0, dgKW.CurrentRow.Index).Value.ToString.Trim & "' and " & vbCrLf & _
                          "tipe='" & dgDK.Item(0, dgDK.CurrentRow.Index).Value.ToString.Trim & "' and " & vbCrLf & _
                          "nomor='" & dgDK.Item(1, dgDK.CurrentRow.Index).Value.ToString.Trim & "' ")
                TampilD2()
            End If
        End If
    End Sub
    Sub hitungAuto()
        Dim sb, ds, dp, pp, gr As Double
        sb = 0 : ds = 0 : dp = 0 : pp = 0 : gr = 0
        If txtSubtotalD1.Text.Trim <> "" Then sb = CDbl(txtSubtotalD1.Text)
        If txtDiscountD1.Text.Trim <> "" Then ds = CDbl(txtDiscountD1.Text)
        dp = sb - ds
        If CbIsPPN.Checked Then
            pp = (10 / 100) * dp
        Else
            pp = 0
        End If
        gr = dp + pp
        txtDPPD1.Text = dp
        txtPPND1.Text = pp
        txtGrandtotalD1.Text = gr
        FNumber(txtDPPD1)
        FNumber(txtPPND1)
        FNumber(txtGrandtotalD1)
    End Sub

    Private Sub txtSubtotalD1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSubtotalD1.KeyPress
        onlyNumber(e)
    End Sub

    Private Sub txtSubtotalD1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSubtotalD1.LostFocus
        FNumber(txtSubtotalD1)
    End Sub
    Private Sub txtSubtotalD1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubtotalD1.TextChanged
        hitungAuto()
    End Sub

    Private Sub txtDiscountD1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiscountD1.KeyPress
        onlyNumber(e)
    End Sub

    Private Sub txtDiscountD1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDiscountD1.LostFocus
        FNumber(txtDiscountD1)
    End Sub
    Private Sub txtDiscountD1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiscountD1.TextChanged
        hitungAuto()
    End Sub

    Private Sub txtPPND1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPPND1.KeyPress
        onlyNumber(e)
    End Sub

    Private Sub txtPPND1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPPND1.LostFocus
        FNumber(txtPPND1)
    End Sub

    Private Sub txtPPND1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPPND1.TextChanged

    End Sub

    Private Sub txtGrandtotalD1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGrandtotalD1.KeyPress
        onlyNumber(e)
    End Sub

    Private Sub txtGrandtotalD1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGrandtotalD1.LostFocus
        FNumber(txtGrandtotalD1)
    End Sub

    Private Sub txtGrandtotalD1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGrandtotalD1.TextChanged

    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        'createReportTandaTerima(" t.noterima='" & txtNoTerima.Text & "' ")
    End Sub
    
    Private Sub txtTerima_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTerima.TextChanged

    End Sub
    Private Sub txtTagihanKW_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTagihanKW.TextChanged

    End Sub

    Private Sub CbIsPPN_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbIsPPN.CheckedChanged
        hitungAuto()
    End Sub

    Private Sub txtTotalTagihan_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalTagihan.TextChanged

    End Sub

    Private Sub Label34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label34.Click

    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click

    End Sub

    Private Sub Label52_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label52.Click
        Dim s As String
        s = getStringFromDB("select remarks from t_terima where noterima='" & txtNoTerima.Text & "' ")
        s = InputBox("Isi Remarks : ", "Input Remarks Print", s)
        ExecQuery("update t_terima set remarks='" & s & "' where noterima='" & txtNoTerima.Text & "' ")
        MsgOK("Remarks Telah Disimpan")
    End Sub

    Private Sub rbtDirect_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtDirect.CheckedChanged
        
    End Sub

    Sub TampilDirect(Optional ByVal tipe As Boolean = True)
        lblTambahKW.Visible = tipe
        dgKW.Visible = tipe
        'lblTambahDK.Visible = tipe
        BtnSaveDokumen.Visible = tipe
        dgDK.Visible = tipe
        'Label34.Visible = tipe
        'Label12.Visible = tipe
        'Label51.Visible = tipe
        'Label50.Visible = tipe
        'txtTotalTagihan.Visible = tipe
        'txtSisaTagihan.Visible = tipe
    End Sub
    Sub TampilConsignment(Optional ByVal tipe As Boolean = True)
        gbConsignment.Visible = tipe
    End Sub

    Private Sub rbtConsignment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtConsignment.CheckedChanged

    End Sub
    Sub TampilGridConsignment()
        'isiCombostore()
        Dim dsSt, dsTr As DataSet
        Dim no, st As String
        no = txtNoTerima.Text.Trim
        dsTr = QueryToDataset("select store.*, WhsName + ' - ' + WhsCode as whs  from Store where whscode<>'HO01' Order by WhsCode")
        dsSt = QueryToDataset("select store.*, WhsName + ' - ' + WhsCode as whs  from Store where whscode<>'HO01' Order by WhsCode")
        For Each rs As DataRow In dsSt.Tables(0).Rows
            st = rs("whscode").ToString.Trim
            dsTr = QueryToDataset("select * from t_terima_c where noterima='" & no & "' and whscode='" & st & "'")
            If dsTr.Tables(0).Rows.Count = 0 Then
                dtTglJTC.Value = DateAdd(DateInterval.Day, 14, Now)
                DtTglBayarC.Value = dtTglJTC.Value
                DtTglBayarC.Checked = False
                ExecQuery("insert into t_terima_c (noterima, whscode, whsname, whs, tagihan, dokumen, " & vbCrLf & _
                          "tgl_jatuhtempo, tgl_bayar, isrevisi) values ( '" & no & "', '" & st & "', " & vbCrLf & _
                          "'" & rs("whsname").ToString.Trim & "', '" & rs("whs").ToString.Trim & "', " & vbCrLf & _
                          "'0', '', " & date2sql(dtTglJTC) & ", null, 0  ) ")
            End If
        Next
        dsSt.Dispose()
        dsTr.Dispose()

        Dim dsTCon As DataSet
        dsTCon = QueryToDataset("select * from t_terima_c where noterima='" & no & "' order by whscode ")
        If dsTCon.Tables(0).Rows.Count > 0 Then
            If IsDBNull(dsTCon.Tables(0).Rows(0).Item("tgl_jatuhtempo")) Then
                dtTglJTC.Value = DateAdd(DateInterval.Day, 14, Now)
                dtTglJTC.Checked = False
            Else
                dtTglJTC.Value = dsTCon.Tables(0).Rows(0).Item("tgl_jatuhtempo")
                dtTglJTC.Checked = True
            End If

            If IsDBNull(dsTCon.Tables(0).Rows(0).Item("tgl_bayar")) Then
                DtTglBayarC.Value = DateAdd(DateInterval.Day, 14, Now)
                DtTglBayarC.Checked = False
            Else
                DtTglBayarC.Value = dsTCon.Tables(0).Rows(0).Item("tgl_bayar")
                DtTglBayarC.Checked = True
            End If

            If IsDBNull(dsTCon.Tables(0).Rows(0).Item("periode")) Then
                dtPeriode.Value = DateAdd(DateInterval.Day, 14, Now)
                dtPeriode.Checked = False
            Else
                dtPeriode.Value = dsTCon.Tables(0).Rows(0).Item("periode")
                dtPeriode.Checked = True
            End If
        End If
        dgConsignment.AutoGenerateColumns = False
        dgConsignment.DataSource = dsTCon.Tables(0)
        dgConsignment.RowsDefaultCellStyle.BackColor = Color.Bisque
        dgConsignment.AlternatingRowsDefaultCellStyle.BackColor = Color.White
        FormatColumnGrid(dgConsignment, 1, "number", 2)
    End Sub
    Private Sub dgConsignment_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgConsignment.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)

        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then
            If e.ColumnIndex = 3 Then
                Dim SQL As String
                Dim s As String = ""
                SQL = "select tipedokumen as id, tipedokumen from m_tipedokumen order by tipedokumen"
                If TampilLookup(SQL, dgConsignment.Item(2, e.RowIndex).Value.ToString.Trim) = Windows.Forms.DialogResult.OK Then
                    For Each row As DataGridViewRow In LookupForm.dg.Rows
                        If CBool(row.Cells(0).Value) Then
                            s = s & row.Cells(2).Value.ToString.Trim & ";"
                        End If
                    Next
                    If s <> "" Then s = Mid(s, 1, Len(s) - 1)
                    For y As Integer = 0 To dgConsignment.RowCount - 1
                        'dgConsignment.Item(2, e.RowIndex).Value = s
                        dgConsignment.Item(2, y).Value = s
                    Next

                End If
            End If
        End If
    End Sub

    Private Sub dgConsignment_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgConsignment.CellEndEdit
        ShowSummaryC()
    End Sub
    Sub ShowSummaryC()
        Dim x As Integer
        Dim totalTagihan, sisaTagihan As Double
        totalTagihan = 0 : sisaTagihan = 0
        For x = 0 To dgConsignment.RowCount - 1
            totalTagihan = totalTagihan + Convert.ToDouble(dgConsignment.Item(1, x).Value)
            If Convert.ToDouble(dgConsignment.Item(4, x).Value) = 0 Then
                sisaTagihan = sisaTagihan + Convert.ToDouble(dgConsignment.Item(1, x).Value)
            End If
        Next
        If DtTglBayarC.Checked Then sisaTagihan = 0
        txtTotalTagihan.Text = FormatNumber(totalTagihan, 2)
        txtSisaTagihan.Text = FormatNumber(sisaTagihan, 2)
        'txtTotalDataH.Text = "Total Data : " & dg.RowCount
    End Sub
    Private Sub dgConsignment_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgConsignment.EditingControlShowing
        If dgConsignment.CurrentCell.ColumnIndex = 1 Then
            AddHandler CType(e.Control, TextBox).KeyPress, AddressOf TextBox_keyPress
        End If
    End Sub
    Private Sub TextBox_keyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        onlyNumber(e)
        'If Char.IsDigit(CChar(CStr(e.KeyChar))) = False Then e.Handled = True
    End Sub

    Private Sub txtSerah_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSerah.TextChanged

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        SimpanHeader()
        ExecQuery("update t_terima set tgl_jatuhtempo=" & date2sql(dtTglJTC) & " where noterima='" & txtNoTerima.Text & "' ")
        SimpanC()
        isiTotalTagihan(rbtDirect.Checked)
        Close()
    End Sub
    Sub SimpanC()
        Dim ds As DataSet
        Dim whscode, whsname, tglbayar As String
        Dim ss As String()
        FormatColumnGridClear(dgConsignment, 1)
        ds = QueryToDataset("select top 1 * from t_terima_c where noterima='" & txtNoTerima.Text & "' ")
        For x As Integer = 0 To dgConsignment.RowCount - 1
            ss = Split(dgConsignment.Item(0, x).Value, "-")
            whscode = ss(1).ToString.Trim
            whsname = ss(0).ToString.Trim
            If DtTglBayarC.Checked Then
                tglbayar = date2sql(DtTglBayarC)
            Else
                tglbayar = "null"
            End If

            ds = QueryToDataset("select * from t_terima_c where noterima='" & txtNoTerima.Text & "' " & vbCrLf & _
                              "and whs='" & dgConsignment.Item(0, x).Value & "' ")
            If ds.Tables(0).Rows.Count > 0 Then
                ExecQuery("update t_terima_c set whscode='" & whscode & "', whsname='" & whsname & "', " & vbCrLf & _
                          "tagihan='" & dgConsignment.Item(1, x).Value.ToString.Trim & "', " & vbCrLf & _
                          "dokumen='" & dgConsignment.Item(2, x).Value.ToString.Trim & "', " & vbCrLf & _
                          "tgl_jatuhtempo=" & date2sql(dtTglJTC) & ", tgl_bayar=" & tglbayar & ", " & vbCrLf & _
                          "isrevisi='" & dgConsignment.Item(4, x).Value.ToString.Trim & "', " & vbCrLf & _
                          "useredited='" & UserLogin & "', " & vbCrLf & _
                          "periode='" & Format(dtPeriode.Value, "yyyy-MM-01") & "', " & vbCrLf & _
                          "dateedited='" & Format(Now, "yyyy-MM-dd hh:mm:ss") & "' " & vbCrLf & _
                          "where noterima='" & txtNoTerima.Text & "' and " & vbCrLf & _
                          "whs='" & dgConsignment.Item(0, x).Value.ToString.Trim & "' ")
            Else
                ExecQuery("insert into t_terima_c (noterima, whscode, whsname, whs, tagihan, dokumen, " & vbCrLf & _
                          "tgl_jatuhtempo, tgl_bayar, periode, isrevisi, useradded, dateadded ) values " & vbCrLf & _
                          "('" & txtNoTerima.Text & "', '" & whscode & "', '" & whsname & "', " & vbCrLf & _
                          "'" & dgConsignment.Item(0, x).Value.ToString.Trim & "', " & vbCrLf & _
                          "'" & dgConsignment.Item(1, x).Value.ToString.Trim & "', " & vbCrLf & _
                          "'" & dgConsignment.Item(2, x).Value.ToString.Trim & "', " & vbCrLf & _
                          " " & date2sql(dtTglJTC) & ", " & tglbayar & ", " & vbCrLf & _
                          "'" & Format(dtPeriode.Value, "yyyy-MM-01") & "', " & vbCrLf & _
                          "'" & dgConsignment.Item(4, x).Value.ToString.Trim & "', " & vbCrLf & _
                          "'" & UserLogin & "', '" & Format(Now, "yyyy-MM-dd hh:mm:ss") & "' ) ")
            End If
        Next
        FormatColumnGrid(dgConsignment, 1, "number", 2)
        ds.Dispose()
    End Sub

    Sub isiTotalTagihanC()
        Dim t As Double
        Dim q As New ZQ
        Dim tgl As String
        q.Query("select top 1 tgl_jatuhtempo from t_terima_c " & vbCrLf & _
                            "where noterima='" & txtNoTerima.Text & "' " & vbCrLf & _
                            "order by tgl_jatuhtempo", "noterima")
        tgl = "null"
        If q.RecordCount > 0 Then
            tgl = "'" & Format(Date.Parse(q.GetField("tgl_jatuhtempo")), "yyyy-MM-dd") & "'"
        End If
        ExecQuery("update t_terima set tgl_jatuhtempo=" & tgl & " where noterima='" & txtNoTerima.Text & "' ")

        t = CDbl(getStringFromDB("select coalesce(sum(tagihan),0) as tagihan from t_terima_c where noterima='" & txtNoTerima.Text & "' "))
        ExecQuery("update t_terima set totaltagihan='" & t & "' where noterima='" & txtNoTerima.Text & "' ")
        txtTotalTagihan.Text = t
        FNumber(txtTotalTagihan)

        t = CDbl(getStringFromDB("select coalesce(sum(tagihan),0) as tagihan from t_terima_c " & vbCrLf & _
                                 "where noterima='" & txtNoTerima.Text & "' and tgl_bayar is null and isrevisi=0 "))
        ExecQuery("update t_terima set sisatagihan='" & t & "' where noterima='" & txtNoTerima.Text & "' ")
        txtSisaTagihan.Text = t
        FNumber(txtSisaTagihan)

        'Dbg("update t_terima set issudahbayar=0 where noterima='" & txtNoTerima.Text & "' and sisatagihan<>0 ")
        'Dbg("update t_terima set issudahbayar=1 where noterima='" & txtNoTerima.Text & "' and sisatagihan=0 ")
        ExecQuery("update t_terima set issudahbayar=0 where noterima='" & txtNoTerima.Text & "' and sisatagihan<>0 ")
        ExecQuery("update t_terima set issudahbayar=1 where noterima='" & txtNoTerima.Text & "' and sisatagihan=0 ")

        q.Dispose()
        'MsgOK("1")
        FNumber(txtTotalTagihan)
        FNumber(txtSisaTagihan)
    End Sub

    Private Sub rbtDirect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtDirect.Click
        ExecQuery("delete from t_terima_c where noterima='" & txtNoTerima.Text & "' ")
        TampilDirect()
        TampilConsignment(False)
    End Sub

    Private Sub rbtConsignment_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtConsignment.Click
        SimpanHeader()
        ExecQuery("delete from t_terima_t1 where noterima='" & txtNoTerima.Text & "' ")
        ExecQuery("delete from t_terima_t2 where noterima='" & txtNoTerima.Text & "' ")
        TampilConsignment()
        TampilDirect(False)
        TampilGridConsignment()
    End Sub

    Private Sub InputRemarksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InputRemarksToolStripMenuItem.Click
        Label52_Click(sender, e)
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgOK("Save")
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        BtnPrint_Click(sender, e)
    End Sub

    Private Sub TambahKwitansiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TambahKwitansiToolStripMenuItem.Click
        If lblTambahKW.Visible Then
            lblTambahKW_Click(sender, e)
        End If
    End Sub

    Private Sub TambahDokumenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TambahDokumenToolStripMenuItem.Click
        Exit Sub
        If lblTambahDK.Visible Then
            lblTambahDK_Click(sender, e)
        End If
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        
    End Sub

    Private Sub SaveToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        If gbConsignment.Visible Then
            Button2_Click(sender, e)
        ElseIf GbKW.Visible Then
            BtnSaveKW_Click_1(sender, e)
        ElseIf GbDK.Visible Then
            BtnSaveD1_Click_1(sender, e)
            'ElseIf BtnSaveDokumen.Visible Then
            '    Button3_Click(sender, e)
        End If
    End Sub

    Private Sub CboStoreKW_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboStoreKW.KeyDown
        If e.KeyCode = 13 Then
            txtTagihanKW.Focus()
        ElseIf e.KeyCode = 27 Then : HideGroupBox()
        End If
    End Sub

    Private Sub CboStoreKW_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboStoreKW.SelectedIndexChanged

    End Sub

    Private Sub CboStoreDK_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboStoreDK.KeyDown
        If e.KeyCode = 13 Then
            DtTglD1.Focus()
        ElseIf e.KeyCode = 27 Then : HideGroupBox()
        End If
    End Sub

    Private Sub CboStoreDK_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboStoreDK.SelectedIndexChanged

    End Sub

    Private Sub DtTglKW_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtTglKW.ValueChanged

    End Sub

    Private Sub DtTglBayar_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtTglBayar.ValueChanged

    End Sub

    Private Sub CboTipeBayar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboTipeBayar.KeyDown
        If e.KeyCode = 13 Then
            txtNoteBayar.Focus()
        ElseIf e.KeyCode = 27 Then : HideGroupBox()
        End If
    End Sub

    Private Sub CboTipeBayar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipeBayar.SelectedIndexChanged

    End Sub

    Private Sub txtNoteBayar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNoteBayar.KeyDown
        If e.KeyCode = 13 Then
            txtNoBK.Focus()
        ElseIf e.KeyCode = 27 Then : HideGroupBox()
        End If
    End Sub

    Private Sub txtNoteBayar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNoteBayar.TextChanged

    End Sub

    Private Sub txtNoBK_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNoBK.KeyDown
        If e.KeyCode = 13 Then
            txtNoGiro.Focus()
        ElseIf e.KeyCode = 27 Then : HideGroupBox()
        End If
    End Sub

    Private Sub txtNoBK_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNoBK.TextChanged

    End Sub

    Private Sub txtNoGiro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNoGiro.KeyDown
        If e.KeyCode = 13 Then
            cbRevisi.Focus()
        ElseIf e.KeyCode = 27 Then : HideGroupBox()
        End If
    End Sub

    Private Sub txtNoGiro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNoGiro.TextChanged

    End Sub

    Private Sub BtnPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPO.Click
        If (LCase(cmbTipeD1.Text.Trim) = "copy purchase order") Then
            CariPO()
        ElseIf (LCase(cmbTipeD1.Text.Trim) = "copy good receipt") Then
            CariGR()
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbIsSave.CheckedChanged
        SimpanHeader()
        FNumber(txtTotalTagihan)
        FNumber(txtSisaTagihan)
    End Sub
    Private Sub dgDK_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDK.CellValueChanged

    End Sub

    Private Sub dgDK_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDK.CellLeave
        
    End Sub

    Private Sub dgDK_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDK.CellEndEdit
        Dim a, b As Integer
        a = 0 : b = 0

        If e.ColumnIndex = 6 Or e.ColumnIndex = 7 Then
            FormatColumnGridClear(dgDK, 6)
            FormatColumnGridClear(dgDK, 7)
            a = CDbl(dgDK.Item(6, dgDK.CurrentRow.Index).Value)
            b = CDbl(dgDK.Item(7, dgDK.CurrentRow.Index).Value)
            'MsgOK(a)
            dgDK.Item(8, dgDK.CurrentRow.Index).Value = a - b
            FormatColumnGrid(dgDK, 6, "number", 2)
            FormatColumnGrid(dgDK, 7, "number", 2)
        End If
        If e.ColumnIndex = 9 Then
            FormatColumnGridClear(dgDK, 8)
            FormatColumnGridClear(dgDK, 10)
            a = CDbl(dgDK.Item(8, dgDK.CurrentRow.Index).Value)
            If CInt(dgDK.Item(9, dgDK.CurrentRow.Index).Value) = 1 Then
                b = (10 / 100) * a
            Else
                b = (10 / 100) * 0
            End If
            dgDK.Item(10, dgDK.CurrentRow.Index).Value = b
            dgDK.Item(11, dgDK.CurrentRow.Index).Value = a + b
            FormatColumnGrid(dgDK, 8, "number", 2)
            FormatColumnGrid(dgDK, 10, "number", 2)
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveDokumen.Click
        If dgDK.RowCount <= 0 Then
            MsgError("Input Dahulu Kwitansi")
            Exit Sub
        End If

        SimpanHeader()
        simpanGridToD2()
        GbKW.Visible = False
        GbDK.Visible = False
        TampilD1()
        TampilD2()
        disableBack(True)
        MsgOK("Dokumen Telah Disimpan")
    End Sub
    Sub simpanGridToD2()
        Dim dst As DataSet
        Dim noterima, s, nokw As String
        noterima = txtNoTerima.Text.Trim
        nokw = getDataGrid(dgKW, "colnokw")
        dst = Query("select top 1 * from t_terima_t2 ")
        For x As Integer = 0 To dgDK.RowCount - 1
            s = "select * from t_terima_t2 where noterima='" & noterima & "' and nokw='" & nokw & "' " & vbCrLf & _
                            "and tipe='" & getDataGrid(dgDK, "coltipedokumen", x) & "' "
            dst = Query(s)
            'Dbg(s)
            If GetDSRecordCount(dst) > 0 Then
                s = "update t_terima_t2 set nomor='" & getDataGrid(dgDK, "colnodokumen", x) & "', " & vbCrLf & _
                          "tgl='" & getDataGrid(dgDK, "coltgldokumen", x) & "', subtotal='" & getDataGrid(dgDK, "colSubtotal", x) & "', " & vbCrLf & _
                          "discount='" & getDataGrid(dgDK, "colDiscount", x) & "', " & vbCrLf & _
                          "dpp='" & getDataGrid(dgDK, "colDPP", x) & "', " & vbCrLf & _
                          "ppn='" & getDataGrid(dgDK, "colPPN", x) & "', " & vbCrLf & _
                          "grandtotal='" & getDataGrid(dgDK, "colGrandtotal", x) & "', " & vbCrLf & _
                          "remarks='" & getDataGrid(dgDK, "colRemarksDokumen", x) & "', " & vbCrLf & _
                          "useredited='" & UserLogin & "', dateedited='" & Format(Now, "yyyy-MM-dd HH:mm:ss") & "', " & vbCrLf & _
                          "isppn='" & getDataGrid(dgDK, "coldkISPPn", x) & "', " & vbCrLf & _
                          "whsstr='" & getDataGrid(dgDK, "coldkstore", x) & "', " & vbCrLf & _
                          "oke='" & getDataGrid(dgDK, "coldkpilih", x) & "' where noterima='" & noterima & "' and nokw='" & nokw & "' " & vbCrLf & _
                          "and tipe='" & getDataGrid(dgDK, "coltipedokumen", x) & "'"
            Else
                s = "insert into t_terima_t2 (noterima, nokw, tipe, nomor, tgl, subtotal, " & vbCrLf & _
                      "discount, dpp, ppn, grandtotal, remarks, nomorpo, useradded, dateadded, " & vbCrLf & _
                      "isppn, whsstr, oke) values ('" & noterima & "', '" & nokw & "', " & vbCrLf & _
                      "'" & getDataGrid(dgDK, "coltipedokumen", x) & "', '" & getDataGrid(dgDK, "colnodokumen", x) & "', " & vbCrLf & _
                      "'" & getDataGrid(dgDK, "coltgldokumen", x) & "', '" & getDataGrid(dgDK, "colSubtotal", x) & "', " & vbCrLf & _
                      "'" & getDataGrid(dgDK, "colDiscount", x) & "', '" & getDataGrid(dgDK, "colDPP", x) & "', " & vbCrLf & _
                      "'" & getDataGrid(dgDK, "colPPN", x) & "', '" & getDataGrid(dgDK, "colGrandtotal", x) & "', " & vbCrLf & _
                      "'" & getDataGrid(dgDK, "colRemarksDokumen", x) & "', null, '" & UserLogin & "', '" & Format(Now, "yyyy-MM-dd HH:mm:ss") & "', " & vbCrLf & _
                      "'" & getDataGrid(dgDK, "coldkISPPn", x) & "', '" & getDataGrid(dgDK, "coldkstore", x) & "', '" & getDataGrid(dgDK, "coldkpilih", x) & "') "
            End If
            'Dbg(s)
            ExecQuery(s)
        Next
        clearDataSet(dst)
    End Sub
End Class