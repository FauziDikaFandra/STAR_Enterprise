Imports System.Drawing.Printing
Public Class TerimaTableOK
    Dim startdate, enddate As Date
    Dim PageNumber As Integer = 0
    Dim awal, akhir, totalRecord, totalPage As Integer
    'Dim xxx() As String
    'Dim axnoterima, aynoterima, axvendor, ayvendor, axperiode, ayperiode, axtipe, aytipe, _
    '    axnodokumen, aynodokumen, axstore, aystore, axnominal, aynominal, axtotal, aytotal, _
    '    axcatatan, aycatatan, axtgl, aytgl, axserah, ayserah, axterima, ayterima As Integer
    'Dim bxnoterima, bynoterima, bxvendor, byvendor, bxperiode, byperiode, bxtipe, bytipe, _
    '    bxnodokumen, bynodokumen, bxstore, bystore, bxnominal, bynominal, bxtotal, bytotal, _
    '    bxcatatan, bycatatan, bxtgl, bytgl, bxserah, byserah, bxterima, byterima As Integer
    Dim xnoterima(1), ynoterima(1), xvendor(1), yvendor(1), xperiode(1), yperiode(1), xtipe(1), ytipe(1), _
        xnodokumen(1), ynodokumen(1), xstore(1), ystore(1), xnominal(1), ynominal(1), xtotal(1), ytotal(1), _
        xcatatan(1), ycatatan(1), xtgl(1), ytgl(1), xserah(1), yserah(1), xterima(1), yterima(1) As String
    
#Region "procedure"
    Sub TampilTable(Optional ByVal syarat As String = " (0=0) ", _
                    Optional ByVal SQL As String = "select th.noterima, th.tgl, th.cardcode as vendor_id, " & vbCrLf & _
                    "v.cardname as vendor_name, isnull(th.totaltagihan,0) as totaltagihan, th.serah, th.terima, " & vbCrLf & _
                    "th.tgl_jatuhtempo, th.issudahbayar, th.remarks, th.isdirect, th.sisatagihan, " & vbCrLf & _
                    "th.potongan, th.jumlahbayar " & vbCrLf & _
                    "from t_terima th " & vbCrLf & _
                    "left join m_vendor v on th.cardcode = v.cardcode " & vbCrLf & _
                    "where @syarat and @filtertgl " & vbCrLf & _
                    "order by th.isdirect, v.cardname ")
        Dim dstable As DataSet
        Dim colHeader() As String = {"No. Tanda Terima", "Tgl", "Vendor ID", "Vendor Name", "Total Tagihan", "Potongan", "Jumlah Bayar", "Sisa Tagihan", "Diserahkan Oleh", "Diterima Oleh", "Tgl Jatuh Tempo", "Sudah Bayar", "Remarks", "Direct"}
        Dim colName() As String = {"noterima", "tgl", "vendor_id", "vendor_name", "totaltagihan", "potongan", "jumlahbayar", "sisatagihan", "serah", "terima", "tgl_jatuhtempo", "issudahbayar", "remarks", "isdirect"}
        Dim colWidth() As Integer = {130, 80, 100, 200, 120, 120, 120, 120, 100, 100, 80, 70, 180, 70}
        Dim colVisible() As Boolean = {True, True, False, True, True, True, True, True, True, True, True, True, True, True}
        SQL = Replace(SQL, "@syarat", syarat)
        SQL = Replace(SQL, "@filtertgl", " convert(varchar(10), th.tgl, 20) between " & vbCrLf & _
                        " " & date2sql(dtStartdate) & " and " & date2sql(dtEnddate) & " ")
        'Dbg(SQL)
        dstable = QueryToDataset(SQL)
        dg.Columns.Clear()
        dg.AutoGenerateColumns = False
        createColumnGrid(dg, colName, colHeader, colVisible, dstable.Tables(0).Columns.Count, colWidth, "checkbox=11,13")

        'Dim colx As DataGridViewColumn
        'colx = New DataGridViewColumn
        'colx.CellTemplate = New DataGridViewCheckBoxCell
        'colx.HeaderText = "Sudah Bayar"
        'colx.Name = "colsudahbayar"
        'colx.DataPropertyName = "issudahbayar"
        'colx.Visible = True
        'colx.Width = 100
        'colx.SortMode = DataGridViewColumnSortMode.Automatic
        'dg.Columns.Add(colx)

        dg.DataSource = dstable.Tables(0)
        NavSource1.DataSource = dstable.Tables(0)
        Navigator.BindingSource = NavSource1
        NavSource1.Filter = " (0=0) "
        FormatColumnGrid(dg, 4, "number", 2)
        FormatColumnGrid(dg, 5, "number", 2)
        FormatColumnGrid(dg, 6, "number", 2)
        FormatColumnGrid(dg, 7, "number", 2)

        FormatColumnGrid(dg, 1, "date")
        FormatColumnGrid(dg, 10, "date")

        dg.RowsDefaultCellStyle.BackColor = Color.Bisque
        dg.AlternatingRowsDefaultCellStyle.BackColor = Color.White
        showSummaryHeader()
        dg.Focus()
    End Sub
    Sub TampilConsingment(ByVal noterima As String, _
                          Optional ByVal SQL As String = "select whsname, tgl_jatuhtempo, tgl_bayar, tagihan, dokumen " & vbCrLf & _
                          "from t_terima_c " & vbCrLf & _
                          "where @noterima and @syarat " & vbCrLf & _
                          "order by noterima, whscode ", Optional ByVal syarat As String = " (0=0) ")
        If noterima = "" Then Exit Sub
        Dim dst2 As DataSet

        SQL = Replace(SQL, "@syarat", syarat)
        SQL = Replace(SQL, "@noterima", " noterima='" & noterima & "' ")
        'Dbg(SQL)
        dst2 = QueryToDataset(SQL)
        dgConsignment.AutoGenerateColumns = False
        dgConsignment.DataSource = dst2.Tables(0)
        NavD2.DataSource = dst2.Tables(0)
        NavD2.Filter = " (0=0) "
        FormatColumnGrid(dgConsignment, 3, "number", 2)
        FormatColumnGrid(dgConsignment, 1, "date")
        FormatColumnGrid(dgConsignment, 2, "date")

        dgConsignment.RowsDefaultCellStyle.BackColor = Color.Bisque
        dgConsignment.AlternatingRowsDefaultCellStyle.BackColor = Color.White
        showSummaryD2()
    End Sub
    Sub TampilDirect(ByVal noterima As String, _
                          Optional ByVal SQL As String = "select noterima, tipe, nokw as nomor, " & vbCrLf & _
                          "tgl_jatuhtempo, tgl_bayar, tagihan, 0 as total from t_terima_t1 t2 " & vbCrLf & _
                          "where @noterima and @syarat  " & vbCrLf & _
                          "union all " & vbCrLf & _
                          "select t2.noterima, t2.tipe, nomor, t1.tgl_jatuhtempo, t1.tgl_bayar, 0 as tagihan, " & vbCrLf & _
                          "grandtotal as total " & vbCrLf & _
                          "from t_terima_t2 t2 " & vbCrLf & _
                          "left join t_terima_t1 t1 on t2.noterima=t1.noterima and t2.nokw=t1.nokw " & vbCrLf & _
                          "where @noterima and @syarat and oke=1  ", _
                          Optional ByVal syarat As String = " (0=0) ")
        If noterima = "" Then Exit Sub
        Dim dst1 As DataSet

        SQL = Replace(SQL, "@syarat", syarat)
        SQL = Replace(SQL, "@noterima", " t2.noterima='" & noterima & "' ")
        'Dbg(SQL)
        dst1 = QueryToDataset(SQL)
        dgDirect.AutoGenerateColumns = False
        dgDirect.DataSource = dst1.Tables(0)
        NavD1.DataSource = dst1.Tables(0)
        NavD1.Filter = " (0=0) "
        FormatColumnGrid(dgDirect, 4, "number", 2)
        FormatColumnGrid(dgDirect, 5, "number", 2)
        FormatColumnGrid(dgDirect, 2, "date")
        FormatColumnGrid(dgDirect, 3, "date")

        dgDirect.RowsDefaultCellStyle.BackColor = Color.Bisque
        dgDirect.AlternatingRowsDefaultCellStyle.BackColor = Color.White
        showSummaryD1()
    End Sub
    Sub showSummaryHeader()
        'Dim dss As DataSet
        'Dim totaltagihan As Double
        'totaltagihan = 0
        'dss = QueryToDataset(SQL)
        'If dss.Tables(0).Rows.Count > 0 Then
        '    If Not IsDBNull(dss.Tables(0).Rows(0).Item("totaltagihan")) Then
        '        totaltagihan = CDbl(dss.Tables(0).Rows(0).Item("totaltagihan").ToString.Trim)
        '    End If
        'End If
        'txtTotalTagihan.Text = FormatNumber(totaltagihan, 2)
        'clearDataSet(dss)

        'Dim sql As String
        'Sql = "select sum(totaltagihan) as totaltagihan from t_terima th where @syarat and @filtertgl and @navfilter"
        'Sql = Replace(Sql, "@syarat", syarat)
        'sql = Replace(sql, "@filtertgl", filtertgl)
        'sql = Replace(sql, "@navfilter", navfilter)
        'txtTotalTagihan.Text = FormatNumber(getDoubleFromDB(Sql), 2)

        Dim x As Integer
        Dim totalTagihan, sisatagihan, potongan, jmlbayar As Double
        totalTagihan = 0 : sisatagihan = 0 : potongan = 0 : jmlbayar = 0
        For x = 0 To dg.RowCount - 1
            totalTagihan = totalTagihan + Convert.ToDouble(dg.Rows(x).Cells("totaltagihan").Value)
            sisatagihan = sisatagihan + Convert.ToDouble(dg.Rows(x).Cells("sisatagihan").Value)
            potongan = potongan + Convert.ToDouble(dg.Rows(x).Cells("potongan").Value)
            jmlbayar = jmlbayar + Convert.ToDouble(dg.Rows(x).Cells("jumlahbayar").Value)
        Next
        txtTotalTagihan.Text = FormatNumber(totalTagihan, 2)
        txtSisaTagihan.Text = FormatNumber(sisatagihan, 2)
        txtPotongan.Text = FormatNumber(potongan, 2)
        txtJmlBayar.Text = FormatNumber(jmlbayar, 2)

        txtTotalDataH.Text = "Total Data : " & dg.RowCount
    End Sub
    Sub showSummaryD1()
        Dim x As Integer
        Dim totalTagihan As Double
        totalTagihan = 0
        For x = 0 To dgDirect.RowCount - 1
            totalTagihan = totalTagihan + Convert.ToDouble(dgDirect.Item(4, x).Value)
        Next
        txtTotalTagihanD1.Text = FormatNumber(totalTagihan, 2)
        txtTotalDataD1.Text = "Total Data : " & dgDirect.RowCount
    End Sub
    Sub showSummaryD2()
        Dim x As Integer
        Dim totalTagihan As Double
        totalTagihan = 0
        For x = 0 To dgConsignment.RowCount - 1
            totalTagihan = totalTagihan + Convert.ToDouble(dgConsignment.Item(3, x).Value)
        Next
        TxtTotaltagihanD2.Text = FormatNumber(totalTagihan, 2)
        txtTotalDataD2.Text = "Total Data : " & dgConsignment.RowCount
    End Sub
    Sub editData()
        'TerimaForm2.dtJatuhTempo.Checked = False
        TerimaFormOK.txtNoTerima.Text = getDataGrid(dg, "noterima").ToString.Trim
        TerimaFormOK.lblTipe.Text = "update"
        TerimaFormOK.ShowDialog()
        'TerimaFormOK.Show()
        reloadClick()
    End Sub
    Sub addData()
        'TerimaFormOK.clearALL()
        'TerimaForm.lblTipe.Text = "update"
        'TerimaForm2.txtNoTerima.Text = "TRH001-062016-00004"
        Dim s As String
        s = newTerimaNumber()
        'TerimaFormOK.txtNoTerima.Text = newTerimaNumber()
        ExecQuery(String.Format("insert into t_terima (noterima) values ('{0}') ", s))
        TerimaFormOK.lblTipe.Text = "new"
        TerimaFormOK.txtTerima.Text = UserLogin
        TerimaFormOK.lblTambahKW.Enabled = True
        TerimaFormOK.lblTambahDK.Enabled = True
        'TerimaFormOK.rbtConsignment.Checked = False
        'TerimaFormOK.rbtDirect.Checked = True
        TerimaFormOK.txtNoTerima.Text = s
        TerimaFormOK.ShowDialog()
        reloadClick()
    End Sub
    Sub DeleteData()
        'MsgBox("Delete")

        If MsgConfirm("Anda Yakin Ingin Hapus Data " & dg.SelectedRows.Count & " Record ?") = MsgBoxResult.Yes Then
            For Each row As DataGridViewRow In dg.SelectedRows
                ExecQuery("delete from t_terima_t2 where noterima= '" & row.Cells("noterima").Value & "' ")
                ExecQuery("delete from t_terima_t1 where noterima= '" & row.Cells("noterima").Value & "' ")
                ExecQuery("delete from t_terima_c where noterima= '" & row.Cells("noterima").Value & "' ")
                ExecQuery("delete from t_terima where noterima= '" & row.Cells("noterima").Value & "' ")
            Next
            reloadClick()
        End If
    End Sub
#End Region
#Region "button date"
    Private Sub BtnFirstToNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFirstToNow.Click
        startdate = DateTime.Parse(Year(dtStartdate.Value) & "-01-01")
        enddate = Now
        dtStartdate.Value = startdate
        dtEnddate.Value = enddate
        BtnReload_Click(sender, e)
    End Sub
    Private Sub BtnOneMonth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOneMonth.Click
        startdate = DateTime.Parse(Year(dtStartdate.Value) & "-" & Month(dtStartdate.Value) & "-01")
        enddate = startdate.AddMonths(1).AddDays(-1)
        dtStartdate.Value = startdate
        dtEnddate.Value = enddate
        BtnReload_Click(sender, e)
    End Sub
    Private Sub BtnNextMonth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNextMonth.Click
        startdate = DateTime.Parse(Year(dtStartdate.Value) & "-" & Month(dtStartdate.Value) & "-01")
        startdate = startdate.AddMonths(1)
        enddate = startdate.AddMonths(1).AddDays(-1)
        dtStartdate.Value = startdate
        dtEnddate.Value = enddate
        BtnReload_Click(sender, e)
    End Sub
    Private Sub BtnPrevMonth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevMonth.Click
        startdate = DateTime.Parse(Year(dtStartdate.Value) & "-" & Month(dtStartdate.Value) & "-01")
        startdate = startdate.AddMonths(-1)
        enddate = startdate.AddMonths(1).AddDays(-1)
        dtStartdate.Value = startdate
        dtEnddate.Value = enddate
        BtnReload_Click(sender, e)
    End Sub
    Private Sub BtnOneWeek_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOneWeek.Click
        Dim x As Integer
        If Weekday(dtStartdate.Value) = 1 Then
            x = -6
        Else
            x = FirstDayOfWeek.Monday - Weekday(dtStartdate.Value)
        End If
        startdate = dtStartdate.Value.AddDays(x)
        enddate = startdate.AddDays(6)
        dtStartdate.Value = startdate
        dtEnddate.Value = enddate
        BtnReload_Click(sender, e)
    End Sub
    Private Sub BtnNextWeek_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNextWeek.Click
        Dim x As Integer
        If Weekday(dtStartdate.Value) = 1 Then
            x = -6
        Else
            x = FirstDayOfWeek.Monday - Weekday(dtStartdate.Value)
        End If
        startdate = dtStartdate.Value.AddDays(x)
        startdate = startdate.AddDays(7)
        enddate = startdate.AddDays(6)
        dtStartdate.Value = startdate
        dtEnddate.Value = enddate
        BtnReload_Click(sender, e)
    End Sub
    Private Sub BtnPrevWeek_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevWeek.Click
        Dim x As Integer
        If Weekday(dtStartdate.Value) = 1 Then
            x = -6
        Else
            x = FirstDayOfWeek.Monday - Weekday(dtStartdate.Value)
        End If
        startdate = dtStartdate.Value.AddDays(x)
        startdate = startdate.AddDays(-7)
        enddate = startdate.AddDays(6)
        dtStartdate.Value = startdate
        dtEnddate.Value = enddate
        BtnReload_Click(sender, e)
    End Sub
    Private Sub BtnOneYear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOneYear.Click
        startdate = DateTime.Parse(Year(dtStartdate.Value) & "-01-01")
        enddate = DateTime.Parse(Year(dtStartdate.Value) & "-12-31")
        dtStartdate.Value = startdate
        dtEnddate.Value = enddate
        BtnReload_Click(sender, e)
    End Sub
    Private Sub BtnOneDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOneDay.Click
        startdate = dtStartdate.Value
        enddate = dtStartdate.Value
        dtStartdate.Value = startdate
        dtEnddate.Value = enddate
        BtnReload_Click(sender, e)
    End Sub
    Private Sub BtnToday_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnToday.Click
        startdate = Now
        enddate = Now
        dtStartdate.Value = startdate
        dtEnddate.Value = enddate
        BtnReload_Click(sender, e)
    End Sub
#End Region
#Region "security"
    Private Sub ShowDateTemplate(Optional ByVal Tipe As Boolean = True)
        'BtnDateTemplate.Visible = Tipe
        'PanelDate.Visible = Tipe
        'BtnReload.Visible = Tipe
        'PanelReload.Visible = Tipe
        PanelDateTemplate.Visible = Tipe
    End Sub
    Private Sub validasiButton()
        Dim lengthPanelKanan As Integer = 0
        'MsgBox(cmsMenu.Items.Count)
        BtnAdd.Visible = True
        BtnEdit.Visible = True
        BtnDelete.Visible = True
        BtnPrint.Visible = True
        BtnMenu.Visible = True
        If cmsMenu.Items.Count <= 0 Then BtnMenu.Visible = False
        If cmsPrint.Items.Count <= 0 Then BtnPrint.Visible = False
        ShowDateTemplate()

        'lengthPanelKanan = PanelReload.Width + PanelDate.Width + PanelClose.Width + BtnReload.Width + BtnDateTemplate.Width + BtnClose.Width
        If BtnAdd.Visible Then lengthPanelKanan = lengthPanelKanan + BtnAdd.Width
        If BtnEdit.Visible Then lengthPanelKanan = lengthPanelKanan + BtnEdit.Width
        If BtnDelete.Visible Then lengthPanelKanan = lengthPanelKanan + BtnDelete.Width
        If BtnPrint.Visible Then lengthPanelKanan = lengthPanelKanan + BtnPrint.Width
        If BtnMenu.Visible Then lengthPanelKanan = lengthPanelKanan + BtnMenu.Width
        lengthPanelKanan = lengthPanelKanan + BtnClose.Width + 10
        PanelKanan.Width = lengthPanelKanan
    End Sub
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
        BtnDateTemplate.Image = Image.FromFile(FolderImage & "date16.png")
        BtnPrint.Image = Image.FromFile(FolderImage & "32print.png")
        BtnMenu.Image = Image.FromFile(FolderImage & "32menu.png")
        BtnAdd.Image = Image.FromFile(FolderImage & "32add.png")
        BtnEdit.Image = Image.FromFile(FolderImage & "32edit.png")
        BtnDelete.Image = Image.FromFile(FolderImage & "32delete.png")
        BtnClose.Image = Image.FromFile(FolderImage & "32close.png")
    End Sub
#End Region
#Region "form"

    Private Sub TerimaTableOK_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        OpenDBSupplier()
    End Sub
    Private Sub EmployeeTable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Decrypt()
        OpenDBSupplier()
        LoadImage()
        PanelFilterH.Visible = False
        PanelFilterD1.Visible = False
        PanelFilterD2.Visible = False
        Label1.Text = Me.Text
        validasiButton()
        dtStartdate.Value = Now
        dtEnddate.Value = Now
        reloadClick()
        dgConsignment.Font = lblFont.Font
    End Sub
#End Region
#Region "button"
    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        cmsPrint.Show(BtnPrint, 0, BtnPrint.Height)
    End Sub
    Private Sub BtnMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMenu.Click
        cmsMenu.Show(BtnMenu, 0, BtnMenu.Height)
    End Sub
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Close()
    End Sub
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        addData()
        'cmsAdd.Show(BtnAdd, 0, BtnAdd.Height)
    End Sub
    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        editData()
    End Sub
    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        DeleteData()
    End Sub
    Private Sub BtnDateTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDateTemplate.Click
        cmsDate.Show(BtnDateTemplate, 0, BtnDateTemplate.Height)
    End Sub
    Private Sub BtnConsignment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsignment.Click
        TampilDirect("xx")
        TampilConsingment("xx")
        TampilTable(" (th.isdirect=0) ")
    End Sub
    Private Sub BtnReload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReload.Click
        TampilDirect("xx")
        TampilConsingment("xx")
        TampilTable(" (th.isdirect=1) ")
    End Sub
    Sub reloadClick(Optional ByVal isdirect As String = " (th.isdirect=1) ")
        Dim x As Integer
        x = getDoubleFromDB("select isdirect from s_user where username='" & UserLogin & "' ")
        If x = 99 Then
            isdirect = " (0=0) "
        Else
            isdirect = " (th.isdirect=" & x & ") "
        End If
        TampilTable(isdirect)
    End Sub
#End Region

#Region "datagridview"
    Private Sub dg_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg.CellContentClick

    End Sub
    Private Sub dg_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg.CellDoubleClick
        editData()
    End Sub
    Private Sub dg_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dg.CellBeginEdit
        'Try
        '    If dg.Focused And dg.CurrentCell.ColumnIndex = 1 Then
        '        'MsgBox(dg.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False).Location.X)
        '        'MsgBox(dg.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False).Location.Y)
        '        'dtpTdate.Location = dg.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False).Location
        '        dtpTdate.Left = dg.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False).Location.X
        '        dtpTdate.Top = dg.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False).Location.Y + Panel1.Height
        '        dtpTdate.Visible = True
        '        If Not IsDBNull(dg.CurrentCell.Value) Then
        '            dtpTdate.Value = DateTime.Parse(dg.CurrentCell.Value)
        '        Else
        '            dtpTdate.Value = DateTime.Today
        '        End If
        '    Else
        '        dtpTdate.Visible = False
        '    End If
        'Catch ex As Exception
        '    MsgError(ex.Message)
        'End Try
    End Sub
    Private Sub dg_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg.CellEndEdit
        'Try
        '    If dg.Focused And dg.CurrentCell.ColumnIndex = 1 Then
        '        dg.CurrentCell.Value = dtpTdate.Value.Date
        '    Else
        '    End If
        'Catch ex As Exception
        '    MsgError(ex.Message)
        'End Try
    End Sub
    Private Sub dtpTdate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTdate.ValueChanged
        'dg.CurrentCell.Value = dtpTdate.Text
    End Sub
    Private Sub dg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dg.KeyDown
        If e.KeyCode = 46 Then
            DeleteData()
        End If
    End Sub
    Private Sub dg_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg.CellLeave
        'Try
        '    If dg.Focused And dg.CurrentCell.ColumnIndex = 1 Then
        '        dtpTdate.Visible = False
        '    Else
        '    End If
        'Catch ex As Exception
        '    MsgError(ex.Message)
        'End Try
    End Sub
    Private Sub dg_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg.RowEnter
        'TampilDetail(dg.Item(0, e.RowIndex).Value.ToString)
        TampilDirect(dg.Item(0, e.RowIndex).Value.ToString)
        TampilConsingment(dg.Item(0, e.RowIndex).Value.ToString)
    End Sub
    Private Sub dg_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dg.MouseClick
        Dim rowClicked, colClicked As Integer
        If e.Button = Windows.Forms.MouseButtons.Right Then

            rowClicked = dg.HitTest(e.Location.X, e.Location.Y).RowIndex
            colClicked = dg.HitTest(e.Location.X, e.Location.Y).ColumnIndex
            If colClicked = -1 = False And rowClicked = -1 = False Then
                'MsgBox(rowClicked)
                'MsgBox(colClicked)
                dg.CurrentCell = dg(colClicked, rowClicked)
                'If dg.SelectedRows.Count <= 1 Then dg.CurrentCell = dg(0, rowClicked)
                cmsHeader.Show(dg, e.Location)
            End If
        End If
    End Sub

#End Region

#Region "ContextMenuStrip"
    Private Sub FindToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindToolStripMenuItem.Click
        'Convert( tgl, 'System.String') LIKE '%5/20/2016%'
        Dim strFilter, colName, colHeader, txtfilter, title As String
        colName = dg.Columns(dg.CurrentCell.ColumnIndex).DataPropertyName
        colHeader = dg.Columns(dg.CurrentCell.ColumnIndex).HeaderText
        title = "Cari " & colHeader
        If LCase(colName) = "tgl" Or LCase(colName) = "tgl_jatuhtempo" Then title = "Cari " & colHeader & "(MM/dd/yyyy)"
        txtfilter = InputBox(title, "Filter")
        If LCase(colName) = "tgl" Or LCase(colName) = "totaltagihan" Or LCase(colName) = "sisatagihan" _
           Or LCase(colName) = "tgl_jatuhtempo" Or LCase(colName) = "issudahbayar" _
           Or LCase(colName) = "isdirect" Then
            strFilter = lblFilterH.Text & _
                         String.Format(" and (convert({0}, 'System.String') Like '%{1}%') ", _
                         colName, txtfilter)
        Else
            strFilter = lblFilterH.Text & String.Format(" and ({0} like '%{1}%') ", colName, txtfilter)
        End If
        NavSource1.Filter = strFilter
        lblFilterH.Text = strFilter
        PanelFilterH.Visible = True
        showSummaryHeader()
    End Sub
    Private Sub FindToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindToolStripMenuItem1.Click

    End Sub
#End Region
    Private Sub lblClearFilterH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClearFilterH.Click
        PanelFilterH.Visible = False
        lblFilterH.Text = " (0=0) "
        NavSource1.Filter = lblFilterH.Text
        showSummaryHeader()
    End Sub
    
    
    
    Private Sub cmsPrint_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsPrint.Opening

    End Sub

    Private Sub DirectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DirectToolStripMenuItem.Click
        addData()
    End Sub
    Private Sub ConsignmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsignmentToolStripMenuItem.Click

    End Sub
    Private Sub dtEnddate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtEnddate.KeyDown
        If e.KeyCode = 13 Then
            reloadClick()
        End If
    End Sub
    Private Sub dtEnddate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtEnddate.ValueChanged

    End Sub
    Private Sub dtStartdate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtStartdate.KeyDown
        If e.KeyCode = 13 Then
            dtEnddate.Focus()
            'reloadClick()
        End If
    End Sub
    Private Sub dtStartdate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtStartdate.ValueChanged

    End Sub

    Private Sub dgConsignment_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgConsignment.CellContentClick

    End Sub

    Private Sub dgDirect_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDirect.CellContentClick

    End Sub

    Private Sub dgDirect_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDirect.CellContentDoubleClick
        editData()
    End Sub

    Private Sub dgConsignment_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgConsignment.CellContentDoubleClick
        editData()
    End Sub
    Sub ReportNotPaid(Optional ByVal periode As String = "", _
                      Optional ByVal isDirect As Integer = 1)
        Dim SQL, ss, s As String

        If isDirect = 1 Then
            ss = "select th.noterima, th.cardcode as vendor_id, v.cardname as Vendor_Name, th.isdirect, " & vbCrLf & _
                    "'' as whscode, t1.whsstr as store, t1.nokw, t1.tgl_jatuhtempo, t1.tgl_bayar, t1.tagihan, th.remarks as noteheader, " & vbCrLf & _
                    "t1.nogiro, t1.nobk, th.tgl, 'Belum' as tipe, " & vbCrLf & _
                    "case " & vbCrLf & _
                    "when datediff(day, GETDATE(), t1.tgl_jatuhtempo ) < 0 then 'Lewat Jatuh Tempo' " & vbCrLf & _
                    "when datediff(day, GETDATE(), t1.tgl_jatuhtempo ) = 0 then 'Hari Ini' " & vbCrLf & _
                    "when datediff(day, GETDATE(), t1.tgl_jatuhtempo ) > 0  and datediff(day, GETDATE(), t1.tgl_jatuhtempo ) <= 14 then '1 - 14 Hari' " & vbCrLf & _
                    "when datediff(day, GETDATE(), t1.tgl_jatuhtempo ) > 14 and datediff(day, GETDATE(), t1.tgl_jatuhtempo ) <= 30 then '15 - 30 Hari' " & vbCrLf & _
                    "ELSE 'Bulan Depan' " & vbCrLf & _
                    "End as jarak, " & vbCrLf & _
                    "case " & vbCrLf & _
                    "when datediff(day, GETDATE(), t1.tgl_jatuhtempo ) < 0 then 1 " & vbCrLf & _
                    "when datediff(day, GETDATE(), t1.tgl_jatuhtempo ) = 0 then 2 " & vbCrLf & _
                    "when datediff(day, GETDATE(), t1.tgl_jatuhtempo ) > 0  and datediff(day, GETDATE(), t1.tgl_jatuhtempo ) <= 14 then 3 " & vbCrLf & _
                    "when datediff(day, GETDATE(), t1.tgl_jatuhtempo ) > 14 and datediff(day, GETDATE(), t1.tgl_jatuhtempo ) <= 30 then 4 " & vbCrLf & _
                    "ELSE 5 " & vbCrLf & _
                    "End as jr, th.potongan, th.jumlahbayar " & vbCrLf & _
                    "from t_terima_t1 t1 " & vbCrLf & _
                    "left join t_terima th on t1.noterima=th.noterima " & vbCrLf & _
                    "left join m_vendor v on th.cardcode = v.cardcode " & vbCrLf & _
                    "where t1.tgl_bayar Is null and (t1.nogiro='' or t1.nogiro is null) and t1.isrevisi=0 and " & periode & " "
        Else
            ss = "select th.noterima, th.cardcode as vendor_id, v.cardname as Vendor_Name, th.isdirect, " & vbCrLf & _
                    "tc.whscode, s.whsstr as store, '' as nokw, tc.tgl_jatuhtempo, tc.tgl_bayar, tc.tagihan, th.remarks as noteheader, " & vbCrLf & _
                    "'' as nogiro, '' as nobk, th.tgl, 'Belum' as tipe, " & vbCrLf & _
                    "case " & vbCrLf & _
                    "when datediff(day, GETDATE(), tc.tgl_jatuhtempo ) < 0 then 'Lewat Jatuh Tempo' " & vbCrLf & _
                    "when datediff(day, GETDATE(), tc.tgl_jatuhtempo ) = 0 then 'Hari Ini' " & vbCrLf & _
                    "when datediff(day, GETDATE(), tc.tgl_jatuhtempo ) > 0  and datediff(day, GETDATE(), tc.tgl_jatuhtempo ) <= 14 then '1 - 14 Hari' " & vbCrLf & _
                    "when datediff(day, GETDATE(), tc.tgl_jatuhtempo ) > 14 and datediff(day, GETDATE(), tc.tgl_jatuhtempo ) <= 30 then '15 - 30 Hari' " & vbCrLf & _
                    "ELSE 'Bulan Depan' " & vbCrLf & _
                    "End as jarak, " & vbCrLf & _
                    "case " & vbCrLf & _
                    "when datediff(day, GETDATE(), tc.tgl_jatuhtempo ) < 0 then 1 " & vbCrLf & _
                    "when datediff(day, GETDATE(), tc.tgl_jatuhtempo ) = 0 then 2 " & vbCrLf & _
                    "when datediff(day, GETDATE(), tc.tgl_jatuhtempo ) > 0  and datediff(day, GETDATE(), tc.tgl_jatuhtempo ) <= 14 then 3 " & vbCrLf & _
                    "when datediff(day, GETDATE(), tc.tgl_jatuhtempo ) > 14 and datediff(day, GETDATE(), tc.tgl_jatuhtempo ) <= 30 then 4 " & vbCrLf & _
                    "ELSE 5 " & vbCrLf & _
                    "End as jr, th.potongan, th.jumlahbayar " & vbCrLf & _
                    "from t_terima_c tc " & vbCrLf & _
                    "left join t_terima th on tc.noterima=th.noterima " & vbCrLf & _
                    "left join m_vendor v on th.cardcode = v.cardcode " & vbCrLf & _
                    "left join store s on tc.whscode = s.whscode " & vbCrLf & _
                    "where tc.tgl_bayar Is null and tc.isrevisi=0 and " & periode & " "
        End If

        ExecQuery("IF OBJECT_ID('tmp_notpaid', 'U') IS NOT NULL DROP TABLE tmp_notpaid")
        s = "select * into tmp_notpaid from ( " & vbCrLf & _
                    ss & vbCrLf & _
                 ") a order by isdirect desc, vendor_name, noterima, whscode"
        'Dbg(s)
        ExecQuery(s)
        SQL = "select * from tmp_notpaid order by isdirect desc, jr, vendor_name, noterima, whscode"
        ShowReport("REPORTNOTPAID", "\REPORT\RptNotPaid.rpt", SQL)
    End Sub
    Sub ReportPaid(Optional ByVal periode As String = "", _
                   Optional ByVal isDirect As Integer = 1)
        Dim SQL, ss, s As String

        If isDirect = 1 Then
            ss = "select th.noterima, th.cardcode as vendor_id, v.cardname as Vendor_Name, th.isdirect, " & vbCrLf & _
                     "'' as whscode, t1.whsstr as store, " & vbCrLf & _
                     "rank() OVER (Partition by th.noterima Order by th.noterima, t1.nokw) as rank, " & vbCrLf & _
                     "t1.nokw, t1.tgl_jatuhtempo, t1.tgl_bayar, t1.tagihan, th.remarks as noteheader, " & vbCrLf & _
                     "t1.nogiro, t1.nobk, th.tgl, 'Sudah' as tipe, '' as jarak, 0 as jr, 0 as potongan, t1.tagihan as jumlahbayar " & vbCrLf & _
                     "from t_terima_t1 t1 " & vbCrLf & _
                     "left join t_terima th on t1.noterima=th.noterima " & vbCrLf & _
                     "left join m_vendor v on th.cardcode = v.cardcode " & vbCrLf & _
                     "where t1.tgl_bayar Is not null and (t1.nogiro<>'' or t1.nogiro is not null) and t1.isrevisi=0 and " & periode & " "
        Else
            ss = "select th.noterima, th.cardcode as vendor_id, v.cardname as Vendor_Name, th.isdirect, " & vbCrLf & _
                     "tc.whscode, s.whsstr as store, " & vbCrLf & _
                     "rank() OVER (Partition by th.noterima Order by th.noterima, tc.whscode) as rank, " & vbCrLf & _
                     "'' as nokw, tc.tgl_jatuhtempo, tc.tgl_bayar, tc.tagihan, th.remarks as noteheader, " & vbCrLf & _
                     "'' as nogiro, '' as nobk, th.tgl, 'Belum' as tipe, '' as jarak, 0 as jr, 0 as potongan, tc.tagihan as jumlahbayar " & vbCrLf & _
                     "from t_terima_c tc " & vbCrLf & _
                     "left join t_terima th on tc.noterima=th.noterima " & vbCrLf & _
                     "left join m_vendor v on th.cardcode = v.cardcode " & vbCrLf & _
                     "left join store s on tc.whscode = s.whscode " & vbCrLf & _
                     "where tc.tgl_bayar Is not null and tc.isrevisi=0 and " & periode & " "
        End If

        ExecQuery("IF OBJECT_ID('tmp_notpaid', 'U') IS NOT NULL DROP TABLE tmp_notpaid")
        s = "select * into tmp_notpaid from ( " & vbCrLf & _
                      ss & vbCrLf & _
                  ") a order by isdirect desc, vendor_name, noterima, whscode"
        'Dbg(s)
        ExecQuery(s)
        s = "update a " & vbCrLf & _
            "set a.potongan=b.potongan " & vbCrLf & _
            "from tmp_notpaid a " & vbCrLf & _
            "inner join ( select noterima, '1' as rank, potongan from t_terima where potongan<>0 ) b " & vbCrLf & _
            "on a.noterima=b.noterima and a.rank=b.rank"
        ExecQuery(s)
        ExecQuery("update tmp_notpaid set jumlahbayar=tagihan-potongan")
        SQL = "select * from tmp_notpaid order by isdirect desc, jr, vendor_name, noterima, whscode"
        ShowReport("REPORTPAID", "\REPORT\RptPaid.rpt", SQL)
    End Sub
    Private Sub LaporanBelumBayarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaporanBelumBayarToolStripMenuItem.Click

    End Sub
    Private Sub LaporanSudahBayarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaporanSudahBayarToolStripMenuItem.Click

    End Sub

    Private Sub InputTglBayarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InputTglBayarToolStripMenuItem.Click
        If MsgConfirm("Anda ingin isi Tgl Bayar Untuk " & dg.SelectedRows.Count & " ?") <> vbYes Then Exit Sub
        Dim no As String = ""
        Dim x As Integer = 0
        Dim isdirect As Boolean = False
        Dim isError As Integer = 0
        Dim tagihan As Double = 0
        Dim dst As DataSet
        Dim tablename As String = "t_terima_t1"

        isiComboFromString(FrmTglBayar.CboTipeBayar, getStringFromDB("select description from parameters where code='TIPEBAYAR'"), ";")
        For Each ro As DataGridViewRow In dg.SelectedRows
            no += "'" & ro.Cells("noterima").Value.ToString.Trim & "',"
            tagihan += ro.Cells("totaltagihan").Value.ToString.Trim
            'x += CInt(ro.Cells("isdirect").Value)
            If CInt(ro.Cells("isdirect").Value) = 1 Then : tablename = "t_terima_t1" : Else : tablename = "t_terima_c" : End If
            If x = 0 Then
                dst = Query("select top 1 * from " & tablename & " where noterima='" & ro.Cells("noterima").Value.ToString.Trim & "' ")
                If GetDSRecordCount(dst) > 0 Then
                    If Not IsDSNull(dst, "tgl_bayar") Then
                        'MsgOK(dst.Tables(0).Rows(0).Item("tgl_bayar"))
                        FrmTglBayar.DtTglBayar.Value = dst.Tables(0).Rows(0).Item("tgl_bayar")
                    Else
                        FrmTglBayar.DtTglBayar.Value = Now
                    End If
                    FrmTglBayar.CboTipeBayar.Text = dst.Tables(0).Rows(0).Item("tipebayar").ToString
                    FrmTglBayar.txtNoteBayar.Text = dst.Tables(0).Rows(0).Item("notebayar").ToString
                    FrmTglBayar.txtNoBK.Text = dst.Tables(0).Rows(0).Item("nobk").ToString
                    FrmTglBayar.txtNoGiro.Text = dst.Tables(0).Rows(0).Item("nogiro").ToString
                    FrmTglBayar.txtbkid.Text = dst.Tables(0).Rows(0).Item("bk_id").ToString
                    FrmTglBayar.cbRevisi.Checked = False
                    If CInt(dst.Tables(0).Rows(0).Item("isrevisi").ToString) = 1 Then
                        FrmTglBayar.cbRevisi.Checked = True
                    End If

                    'isrevisi, remarks, potongan
                Else
                    FrmTglBayar.DtTglBayar.Value = Now
                    FrmTglBayar.CboTipeBayar.Text = ""
                    FrmTglBayar.txtNoteBayar.Text = ""
                    FrmTglBayar.txtNoBK.Text = ""
                    FrmTglBayar.txtNoGiro.Text = ""
                    FrmTglBayar.txtbkid.Text = "0"
                    FrmTglBayar.cbRevisi.Checked = False
                End If
                FrmTglBayar.RbtBK.Checked = False
                FrmTglBayar.RbtGiro1.Checked = False
                FrmTglBayar.RbtGiro2.Checked = False
                FrmTglBayar.RbtGiro3.Checked = False
                FrmTglBayar.RbtLain.Checked = False
                FrmTglBayar.txtRemarksKW.Text = ""
                FrmTglBayar.txtPotongan.Text = ""

                Dim remarks As String = ""
                dst = Query("select noterima, remarks, potongan from t_terima where noterima='" & ro.Cells("noterima").Value.ToString.Trim & "' ")
                If GetDSRecordCount(dst) > 0 Then
                    remarks = dst.Tables(0).Rows(0).Item("remarks").ToString
                    If LCase(remarks) = "proses bk" Then
                        FrmTglBayar.RbtBK.Checked = True
                        FrmTglBayar.txtRemarksKW.Enabled = False
                        FrmTglBayar.txtRemarksKW.Text = remarks
                    ElseIf LCase(remarks) = "proses giro" Then
                        FrmTglBayar.RbtGiro1.Checked = True
                        FrmTglBayar.txtRemarksKW.Enabled = False
                        FrmTglBayar.txtRemarksKW.Text = remarks
                    ElseIf LCase(remarks) = "giro sudah siap" Then
                        FrmTglBayar.RbtGiro2.Checked = True
                        FrmTglBayar.txtRemarksKW.Enabled = False
                        FrmTglBayar.txtRemarksKW.Text = remarks
                    ElseIf LCase(remarks) = "giro belum dicairkan" Then
                        FrmTglBayar.RbtGiro3.Checked = True
                        FrmTglBayar.txtRemarksKW.Enabled = False
                        FrmTglBayar.txtRemarksKW.Text = remarks
                    Else
                        FrmTglBayar.RbtLain.Checked = True
                        FrmTglBayar.txtRemarksKW.Enabled = True
                        FrmTglBayar.txtRemarksKW.Text = remarks
                    End If
                    FrmTglBayar.txtPotongan.Text = dst.Tables(0).Rows(0).Item("potongan").ToString
                End If
                If CInt(ro.Cells("isdirect").Value) = 1 Then : isdirect = True : Else : isdirect = False : End If
                If isdirect Then
                    FrmTglBayar.cbxIsDirect.Checked = True
                Else
                    FrmTglBayar.cbxIsDirect.Checked = False
                End If
            Else
                If isdirect Then
                    If CInt(ro.Cells("isdirect").Value) = 0 Then isError += 1
                Else
                    If CInt(ro.Cells("isdirect").Value) = 1 Then isError += 1
                End If

            End If

            x += 1
        Next
        If isError > 0 Then
            MsgError("Tanda Terima yang dipilih tidak sama Direct / Consignment")
            Exit Sub
        End If
        If isdirect = False Then
            'MsgError("Isi Tgl Bayar Untuk Consignment Belum Diperbaiki, Mohon Menunggu")
            'Exit Sub
        End If

        no = "(" & Mid(no, 1, Len(no) - 1) & ")"
        'MsgOK(no)
        'MsgOK(x)
        FrmTglBayar.txtNoTerima.Text = no
        FrmTglBayar.txtVendorID.Text = dg.Item(2, dg.CurrentCell.RowIndex).Value.ToString
        FrmTglBayar.txtVendor.Text = dg.Item(3, dg.CurrentCell.RowIndex).Value.ToString
        FrmTglBayar.txtTotalTagihan.Text = tagihan
        FrmTglBayar.cbxIsDirect.Checked = isdirect
        'FrmTglBayar.txtPotongan.Text = "0"
        FrmTglBayar.ShowDialog()
        reloadClick()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If InStr("MKG, SMB, SMS", "MKG") Then
            MsgOK("tes")
        End If
    End Sub

    Private Sub PrintPreviewDialog1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dlgPrintPreview.Load

    End Sub
   
    Sub teszxxzx()
        'g.DrawString("2No Tanda Terima", ft1, Brushes.Black, 570, 5)
        'g.DrawString("Nama Vendor", ft1, Brushes.Black, 90, 49)
        'g.DrawString("Periode", ft1, Brushes.Black, 630, 49)

        'g.DrawString("123456789012345678901234567890", ft, Brushes.Black, 6, 108) '30
        'g.DrawString("1tipe", ft, Brushes.Black, 6, 123)

        'g.DrawString("2tipe", ft, Brushes.Black, 6, 140)
        'g.DrawString("2tipe", ft, Brushes.Black, 6, 155)

        'g.DrawString("3tipe", ft, Brushes.Black, 6, 174)
        'g.DrawString("3tipe", ft, Brushes.Black, 6, 189)

        'g.DrawString("4tipe", ft, Brushes.Black, 6, 206)
        'g.DrawString("4tipe", ft, Brushes.Black, 6, 221)

        'g.DrawString("5tipe", ft, Brushes.Black, 6, 238)
        'g.DrawString("5tipe", ft, Brushes.Black, 6, 253)

        'g.DrawString("6tipe", ft, Brushes.Black, 6, 270)
        'g.DrawString("6tipe", ft, Brushes.Black, 6, 285)

        'g.DrawString("123456789012345678901234567890123456789012345", ft, Brushes.Black, 200, 108)
        'g.DrawString("1no", ft, Brushes.Black, 200, 123)

        'g.DrawString("2no", ft, Brushes.Black, 200, 140)
        'g.DrawString("2no", ft, Brushes.Black, 200, 155)

        'g.DrawString("3no", ft, Brushes.Black, 200, 174)
        'g.DrawString("3no", ft, Brushes.Black, 200, 189)

        'g.DrawString("123456789012345678901234567890123456789012345", ft, Brushes.Black, 200, 206) '45
        'g.DrawString("4no", ft, Brushes.Black, 200, 221)

        'g.DrawString("5no", ft, Brushes.Black, 200, 238)
        'g.DrawString("5no", ft, Brushes.Black, 200, 253)

        'g.DrawString("6no", ft, Brushes.Black, 200, 270)
        'g.DrawString("6no", ft, Brushes.Black, 200, 285)

        'g.DrawString("1MKG, SMS, SMB", ft, Brushes.Black, 482, 108)
        'g.DrawString("1MKG, SMS, SMB", ft, Brushes.Black, 482, 123)

        'g.DrawString("2MKG, SMS, SMB", ft, Brushes.Black, 482, 140)
        'g.DrawString("2MKG, SMS, SMB", ft, Brushes.Black, 482, 155)

        'g.DrawString("3MKG, SMS, SMB", ft, Brushes.Black, 482, 174)
        'g.DrawString("3MKG, SMS, SMB", ft, Brushes.Black, 482, 189)

        'g.DrawString("4MKG, SMS, SMB", ft, Brushes.Black, 482, 206)
        'g.DrawString("4MKG, SMS, SMB", ft, Brushes.Black, 482, 221)

        'g.DrawString("5MKG, SMS, SMB", ft, Brushes.Black, 482, 238)
        'g.DrawString("5MKG, SMS, SMB", ft, Brushes.Black, 482, 253)

        'g.DrawString("6MKG, SMS, SMB", ft, Brushes.Black, 482, 270)
        'g.DrawString("6MKG, SMS, SMB", ft, Brushes.Black, 482, 285)

        'g.DrawString("Rp. 12,256,352,568.25", ft1, Brushes.Black, 570, 112) '10
        'g.DrawString("Rp. 22,256,352,568.25", ft1, Brushes.Black, 570, 145)
        'g.DrawString("Rp. 32,256,352,568.25", ft1, Brushes.Black, 570, 178)
        'g.DrawString("Rp. 42,256,352,568.25", ft1, Brushes.Black, 570, 210)
        'g.DrawString("Rp. 52,256,352,568.25", ft1, Brushes.Black, 570, 242)
        'g.DrawString("Rp. 62,256,352,568.25", ft1, Brushes.Black, 570, 274)

        'g.DrawString("Rp. 72,256,352,568.25", ft2, Brushes.Black, 570, 307)

        'g.DrawString("Catatan 1", ft, Brushes.Black, 75, 310)
        'g.DrawString("Catatan 2", ft, Brushes.Black, 75, 325)
        'g.DrawString("Catatan 3", ft, Brushes.Black, 75, 340)

        'g.DrawString("3Tgl", ft1, Brushes.Black, 590, 356)
        'g.DrawString("2Terima Oleh", ft1, Brushes.Black, 600, 480)
        'g.DrawString("2Serah Oleh", ft1, Brushes.Black, 72, 480)


        'xxxxxxxxxxxxxxxxxxxxxxx
        'g.DrawString("4No Tanda Terima", ft1, Brushes.Black, 570, 554)
        'g.DrawString("4Nama Vendor", ft1, Brushes.Black, 90, 598)
        'g.DrawString("4Periode", ft1, Brushes.Black, 630, 598)

        'g.DrawString("1tipe", ft, Brushes.Black, 6, 657)
        'g.DrawString("1tipe", ft, Brushes.Black, 6, 672)
        'g.DrawString("2tipe", ft, Brushes.Black, 6, 689)
        'g.DrawString("2tipe", ft, Brushes.Black, 6, 704)
        'g.DrawString("3tipe", ft, Brushes.Black, 6, 721)
        'g.DrawString("3tipe", ft, Brushes.Black, 6, 736)
        'g.DrawString("4tipe", ft, Brushes.Black, 6, 753)
        'g.DrawString("4tipe", ft, Brushes.Black, 6, 768)
        'g.DrawString("5tipe", ft, Brushes.Black, 6, 785)
        'g.DrawString("5tipe", ft, Brushes.Black, 6, 800)
        'g.DrawString("6tipe", ft, Brushes.Black, 6, 817)
        'g.DrawString("6tipe", ft, Brushes.Black, 6, 832)

        'g.DrawString("1no", ft, Brushes.Black, 200, 657)
        'g.DrawString("1no", ft, Brushes.Black, 200, 672)
        'g.DrawString("2no", ft, Brushes.Black, 200, 689)
        'g.DrawString("2no", ft, Brushes.Black, 200, 704)
        'g.DrawString("3no", ft, Brushes.Black, 200, 721)
        'g.DrawString("3no", ft, Brushes.Black, 200, 736)
        'g.DrawString("4no", ft, Brushes.Black, 200, 753)
        'g.DrawString("4no", ft, Brushes.Black, 200, 768)
        'g.DrawString("5no", ft, Brushes.Black, 200, 785)
        'g.DrawString("5no", ft, Brushes.Black, 200, 800)
        'g.DrawString("6no", ft, Brushes.Black, 200, 817)
        'g.DrawString("6no", ft, Brushes.Black, 200, 832)

        'g.DrawString("1MKG, SMS, SMB", ft, Brushes.Black, 482, 657)
        'g.DrawString("1MKG, SMS, SMB", ft, Brushes.Black, 482, 672)
        'g.DrawString("2MKG, SMS, SMB", ft, Brushes.Black, 482, 689)
        'g.DrawString("2MKG, SMS, SMB", ft, Brushes.Black, 482, 704)
        'g.DrawString("3MKG, SMS, SMB", ft, Brushes.Black, 482, 721)
        'g.DrawString("3MKG, SMS, SMB", ft, Brushes.Black, 482, 736)
        'g.DrawString("4MKG, SMS, SMB", ft, Brushes.Black, 482, 753)
        'g.DrawString("4MKG, SMS, SMB", ft, Brushes.Black, 482, 768)
        'g.DrawString("5MKG, SMS, SMB", ft, Brushes.Black, 482, 785)
        'g.DrawString("5MKG, SMS, SMB", ft, Brushes.Black, 482, 800)
        'g.DrawString("6MKG, SMS, SMB", ft, Brushes.Black, 482, 817)
        'g.DrawString("6MKG, SMS, SMB", ft, Brushes.Black, 482, 832)

        'g.DrawString("Rp. 12,256,352,568.25", ft1, Brushes.Black, 570, 661)
        'g.DrawString("Rp. 12,256,352,568.25", ft1, Brushes.Black, 570, 693)
        'g.DrawString("Rp. 12,256,352,568.25", ft1, Brushes.Black, 570, 725)
        'g.DrawString("Rp. 12,256,352,568.25", ft1, Brushes.Black, 570, 757)
        'g.DrawString("Rp. 12,256,352,568.25", ft1, Brushes.Black, 570, 789)
        'g.DrawString("Rp. 12,256,352,568.25", ft1, Brushes.Black, 570, 821)

        'g.DrawString("Rp. 12,256,352,568.25", ft2, Brushes.Black, 570, 854)

        'g.DrawString("Catatan 1", ft, Brushes.Black, 75, 857)
        'g.DrawString("Catatan 2", ft, Brushes.Black, 75, 872)
        'g.DrawString("Catatan 3", ft, Brushes.Black, 75, 887)

        'g.DrawString("3Tgl", ft1, Brushes.Black, 590, 903)
        'g.DrawString("2Terima Oleh", ft1, Brushes.Black, 600, 1027)
        'g.DrawString("2Serah Oleh", ft1, Brushes.Black, 72, 1027)
    End Sub
    Sub isiVariablePosisi()
        'axnoterima = getArray(getParamValue("0posisinoterima"), ";", 0)
        'aynoterima = getArray(getParamValue("0posisinoterima"), ";", 1)
        'axvendor = getArray(getParamValue("0posisivendor"), ";", 0)
        'ayvendor = getArray(getParamValue("0posisivendor"), ";", 1)
        'axperiode = getArray(getParamValue("0posisiperiode"), ";", 0)
        'ayperiode = getArray(getParamValue("0posisiperiode"), ";", 1)
        'axtipe = getArray(getParamValue("0posisitipe"), ";", 0)
        'aytipe = getArray(getParamValue("0posisitipe"), ";", 1)
        'axnodokumen = getArray(getParamValue("0posisinodokumen"), ";", 0)
        'aynodokumen = getArray(getParamValue("0posisinodokumen"), ";", 1)
        'axstore = getArray(getParamValue("0posisistore"), ";", 0)
        'aystore = getArray(getParamValue("0posisistore"), ";", 1)
        'axnominal = getArray(getParamValue("0posisinominal"), ";", 0)
        'aynominal = getArray(getParamValue("0posisinominal"), ";", 1)
        'axtotal = getArray(getParamValue("0posisitotal"), ";", 0)
        'aytotal = getArray(getParamValue("0posisitotal"), ";", 1)
        'axcatatan = getArray(getParamValue("0posisicatatan"), ";", 0)
        'aycatatan = getArray(getParamValue("0posisicatatan"), ";", 1)
        'axtgl = getArray(getParamValue("0posisitgl"), ";", 0)
        'aytgl = getArray(getParamValue("0posisitgl"), ";", 1)
        'axserah = getArray(getParamValue("0posisiserah"), ";", 0)
        'ayserah = getArray(getParamValue("0posisiserah"), ";", 1)
        'axterima = getArray(getParamValue("0posisiterima"), ";", 0)
        'ayterima = getArray(getParamValue("0posisiterima"), ";", 1)

        'bxnoterima = getArray(getParamValue("1posisinoterima"), ";", 0)
        'bynoterima = getArray(getParamValue("1posisinoterima"), ";", 1)
        'bxvendor = getArray(getParamValue("1posisivendor"), ";", 0)
        'byvendor = getArray(getParamValue("1posisivendor"), ";", 1)
        'bxperiode = getArray(getParamValue("1posisiperiode"), ";", 0)
        'byperiode = getArray(getParamValue("1posisiperiode"), ";", 1)
        'bxtipe = getArray(getParamValue("1posisitipe"), ";", 0)
        'bytipe = getArray(getParamValue("1posisitipe"), ";", 1)
        'bxnodokumen = getArray(getParamValue("1posisinodokumen"), ";", 0)
        'bynodokumen = getArray(getParamValue("1posisinodokumen"), ";", 1)
        'bxstore = getArray(getParamValue("1posisistore"), ";", 0)
        'bystore = getArray(getParamValue("1posisistore"), ";", 1)
        'bxnominal = getArray(getParamValue("1posisinominal"), ";", 0)
        'bynominal = getArray(getParamValue("1posisinominal"), ";", 1)
        'bxtotal = getArray(getParamValue("1posisitotal"), ";", 0)
        'bytotal = getArray(getParamValue("1posisitotal"), ";", 1)
        'bxcatatan = getArray(getParamValue("1posisicatatan"), ";", 0)
        'bycatatan = getArray(getParamValue("1posisicatatan"), ";", 1)
        'bxtgl = getArray(getParamValue("1posisitgl"), ";", 0)
        'bytgl = getArray(getParamValue("1posisitgl"), ";", 1)
        'bxserah = getArray(getParamValue("1posisiserah"), ";", 0)
        'byserah = getArray(getParamValue("1posisiserah"), ";", 1)
        'bxterima = getArray(getParamValue("1posisiterima"), ";", 0)
        'byterima = getArray(getParamValue("1posisiterima"), ";", 1)
        xnoterima(0) = getArray(getParamValue("0posisinoterima"), ";", 0)
        ynoterima(0) = getArray(getParamValue("0posisinoterima"), ";", 1)
        xvendor(0) = getArray(getParamValue("0posisivendor"), ";", 0)
        yvendor(0) = getArray(getParamValue("0posisivendor"), ";", 1)
        xperiode(0) = getArray(getParamValue("0posisiperiode"), ";", 0)
        yperiode(0) = getArray(getParamValue("0posisiperiode"), ";", 1)
        xtipe(0) = getArray(getParamValue("0posisitipe"), ";", 0)
        ytipe(0) = getArray(getParamValue("0posisitipe"), ";", 1)
        xnodokumen(0) = getArray(getParamValue("0posisinodokumen"), ";", 0)
        ynodokumen(0) = getArray(getParamValue("0posisinodokumen"), ";", 1)
        xstore(0) = getArray(getParamValue("0posisistore"), ";", 0)
        ystore(0) = getArray(getParamValue("0posisistore"), ";", 1)
        xnominal(0) = getArray(getParamValue("0posisinominal"), ";", 0)
        ynominal(0) = getArray(getParamValue("0posisinominal"), ";", 1)
        xtotal(0) = getArray(getParamValue("0posisitotal"), ";", 0)
        ytotal(0) = getArray(getParamValue("0posisitotal"), ";", 1)
        xcatatan(0) = getArray(getParamValue("0posisicatatan"), ";", 0)
        ycatatan(0) = getArray(getParamValue("0posisicatatan"), ";", 1)
        xtgl(0) = getArray(getParamValue("0posisitgl"), ";", 0)
        ytgl(0) = getArray(getParamValue("0posisitgl"), ";", 1)
        xserah(0) = getArray(getParamValue("0posisiserah"), ";", 0)
        yserah(0) = getArray(getParamValue("0posisiserah"), ";", 1)
        xterima(0) = getArray(getParamValue("0posisiterima"), ";", 0)
        yterima(0) = getArray(getParamValue("0posisiterima"), ";", 1)

        xnoterima(1) = getArray(getParamValue("1posisinoterima"), ";", 0)
        ynoterima(1) = getArray(getParamValue("1posisinoterima"), ";", 1)
        xvendor(1) = getArray(getParamValue("1posisivendor"), ";", 0)
        yvendor(1) = getArray(getParamValue("1posisivendor"), ";", 1)
        xperiode(1) = getArray(getParamValue("1posisiperiode"), ";", 0)
        yperiode(1) = getArray(getParamValue("1posisiperiode"), ";", 1)
        xtipe(1) = getArray(getParamValue("1posisitipe"), ";", 0)
        ytipe(1) = getArray(getParamValue("1posisitipe"), ";", 1)
        xnodokumen(1) = getArray(getParamValue("1posisinodokumen"), ";", 0)
        ynodokumen(1) = getArray(getParamValue("1posisinodokumen"), ";", 1)
        xstore(1) = getArray(getParamValue("1posisistore"), ";", 0)
        ystore(1) = getArray(getParamValue("1posisistore"), ";", 1)
        xnominal(1) = getArray(getParamValue("1posisinominal"), ";", 0)
        ynominal(1) = getArray(getParamValue("1posisinominal"), ";", 1)
        xtotal(1) = getArray(getParamValue("1posisitotal"), ";", 0)
        ytotal(1) = getArray(getParamValue("1posisitotal"), ";", 1)
        xcatatan(1) = getArray(getParamValue("1posisicatatan"), ";", 0)
        ycatatan(1) = getArray(getParamValue("1posisicatatan"), ";", 1)
        xtgl(1) = getArray(getParamValue("1posisitgl"), ";", 0)
        ytgl(1) = getArray(getParamValue("1posisitgl"), ";", 1)
        xserah(1) = getArray(getParamValue("1posisiserah"), ";", 0)
        yserah(1) = getArray(getParamValue("1posisiserah"), ";", 1)
        xterima(1) = getArray(getParamValue("1posisiterima"), ";", 0)
        yterima(1) = getArray(getParamValue("1posisiterima"), ";", 1)
    End Sub
    Private Sub PrintTandaTerimaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintTandaTerimaToolStripMenuItem.Click
        Dim s As String
        s = ""
        ExecQuery("truncate table tmp_terima2")
        ExecQuery("truncate table tmp_terima3")
        For Each row As DataGridViewRow In dg.SelectedRows
            's = s & "'" & row.Cells("noterima").Value.ToString.Trim & "',"
            s = row.Cells("noterima").Value.ToString.Trim
            'Dbg(s)
            RptTerimaDirect(s)
        Next
        isiVariablePosisi()
        PageNumber = 1
        awal = 1
        akhir = 2
        totalRecord = CDbl(getStringFromDB("select count(*) from tmp_terima3"))
        totalPage = CDbl(getStringFromDB("select convert(int, count(*)/2) as a from tmp_terima3"))
        totalPage += (totalRecord Mod 2)

        ''MsgOK("total page : " & totalPage)
        ''dlgPrintPreview.Document = PreparePrintDocument()

        'dlgPrintPreview.Document = PrintDocument1
        'dlgPrintPreview.WindowState = FormWindowState.Maximized
        'dlgPrintPreview.ShowDialog()

        PrintDocument1.Print()
    End Sub

    Private Function PreparePrintDocument() As PrintDocument
        Dim print_document As New PrintDocument
        AddHandler print_document.PrintPage, AddressOf LoopingPrint
        Return print_document
    End Function
    Sub LoopingPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim dsR As DataSet
        Dim no As Integer = 0
        Dim bawah As Integer = 0
        dsR = Query("select * from (" & vbCrLf & _
                    "	select ROW_NUMBER() OVER ( ORDER BY noterima, _order ) AS RowNum, " & vbCrLf & _
                    "	* from tmp_terima3 " & vbCrLf & _
                    ") a where rownum >= '" & awal & "' and rownum <= '" & akhir & "' ")
        'MsgOK(dsR.Tables(0).Rows.Count)
        For Each ro As DataRow In dsR.Tables(0).Rows
            If no Mod 2 = 0 Then
                bawah = 0
            Else
                bawah = 1
            End If
            Print_PrintPage(sender, e, bawah, ro)
            'e.Graphics.DrawString(ro("noterima"), New Font("TAHOMA", 8, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, 10, 100 * (bawah + 1))
            'MsgBox("No terima : " & ro("noterima") & vbCrLf & _
            '        "no : " & no & vbCrLf & _
            '        "bawah : " & bawah & vbCrLf & _
            '        "pagenumber : " & PageNumber & vbCrLf & _
            '        "")
            no += 1
        Next
        clearDataSet(dsR)
        e.HasMorePages = True
        If PageNumber >= totalPage Then e.HasMorePages = False
        PageNumber += 1
        awal += 2 : akhir += 2
    End Sub
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        LoopingPrint(sender, e)
    End Sub
    Private Sub Print_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs, _
                               ByVal bawah As Integer, ByVal ro As DataRow)
        Dim g As Graphics = e.Graphics
        Dim ft As New Font("TAHOMA", 8, FontStyle.Regular, GraphicsUnit.Point)
        Dim ft1 As New Font("TAHOMA", 10, FontStyle.Bold, GraphicsUnit.Point)
        Dim ft2 As New Font("TAHOMA", 11, FontStyle.Bold, GraphicsUnit.Point)
        Dim ft3 As New Font("TAHOMA", 11, FontStyle.Regular, GraphicsUnit.Point)
        Dim xx, yy As Integer

        g.DrawString(ro("noterima"), ft1, Brushes.Black, xnoterima(bawah), ynoterima(bawah))
        g.DrawString(ro("cardname"), ft1, Brushes.Black, xvendor(bawah), yvendor(bawah))
        g.DrawString(Format(Date.Parse(ro("periode")), "MMM yyyy"), ft1, Brushes.Black, xperiode(bawah), yperiode(bawah))

        xx = CInt(xtipe(bawah))
        yy = CInt(ytipe(bawah))
        g.DrawString(Mid(ro("tipe1"), 1, 30), ft, Brushes.Black, xx, yy) : yy += 15 '30
        g.DrawString(Mid(ro("tipe1"), 31, 30), ft, Brushes.Black, xx, yy) : yy += 17

        g.DrawString(Mid(ro("tipe2"), 1, 30), ft, Brushes.Black, xx, yy) : yy += 15
        g.DrawString(Mid(ro("tipe2"), 31, 30), ft, Brushes.Black, xx, yy) : yy += 17

        g.DrawString(Mid(ro("tipe3"), 1, 30), ft, Brushes.Black, xx, yy) : yy += 15
        g.DrawString(Mid(ro("tipe3"), 31, 30), ft, Brushes.Black, xx, yy) : yy += 17

        g.DrawString(Mid(ro("tipe4"), 1, 30), ft, Brushes.Black, xx, yy) : yy += 15
        g.DrawString(Mid(ro("tipe4"), 31, 30), ft, Brushes.Black, xx, yy) : yy += 17

        g.DrawString(Mid(ro("tipe5"), 1, 30), ft, Brushes.Black, xx, yy) : yy += 15
        g.DrawString(Mid(ro("tipe5"), 31, 30), ft, Brushes.Black, xx, yy) : yy += 17

        g.DrawString(Mid(ro("tipe6"), 1, 30), ft, Brushes.Black, xx, yy) : yy += 15
        g.DrawString(Mid(ro("tipe6"), 31, 30), ft, Brushes.Black, xx, yy)

        xx = CInt(xnodokumen(bawah))
        yy = CInt(ynodokumen(bawah))
        g.DrawString(Mid(ro("nokw1"), 1, 30), ft, Brushes.Black, xx, yy) : yy += 15
        g.DrawString(Mid(ro("nokw1"), 31, 30), ft, Brushes.Black, xx, yy) : yy += 17

        g.DrawString(Mid(ro("nokw2"), 1, 30), ft, Brushes.Black, xx, yy) : yy += 15
        g.DrawString(Mid(ro("nokw2"), 31, 30), ft, Brushes.Black, xx, yy) : yy += 17

        g.DrawString(Mid(ro("nokw3"), 1, 30), ft, Brushes.Black, xx, yy) : yy += 15
        g.DrawString(Mid(ro("nokw3"), 31, 30), ft, Brushes.Black, xx, yy) : yy += 17

        g.DrawString(Mid(ro("nokw4"), 1, 30), ft, Brushes.Black, xx, yy) : yy += 15 '43
        g.DrawString(Mid(ro("nokw4"), 31, 30), ft, Brushes.Black, xx, yy) : yy += 17

        g.DrawString(Mid(ro("nokw5"), 1, 30), ft, Brushes.Black, xx, yy) : yy += 15
        g.DrawString(Mid(ro("nokw5"), 31, 30), ft, Brushes.Black, xx, yy) : yy += 17

        g.DrawString(Mid(ro("nokw6"), 1, 30), ft, Brushes.Black, xx, yy) : yy += 15
        g.DrawString(Mid(ro("nokw6"), 31, 30), ft, Brushes.Black, xx, yy)

        xx = CInt(xstore(bawah))
        yy = CInt(ystore(bawah))
        g.DrawString(Mid(ro("whsstr1"), 1, 30), ft, Brushes.Black, xx, yy) : yy += 15
        g.DrawString(Mid(ro("whsstr1"), 31, 30), ft, Brushes.Black, xx, yy) : yy += 17

        g.DrawString(Mid(ro("whsstr2"), 1, 30), ft, Brushes.Black, xx, yy) : yy += 15
        g.DrawString(Mid(ro("whsstr2"), 31, 30), ft, Brushes.Black, xx, yy) : yy += 17

        g.DrawString(Mid(ro("whsstr3"), 1, 30), ft, Brushes.Black, xx, yy) : yy += 15
        g.DrawString(Mid(ro("whsstr3"), 31, 30), ft, Brushes.Black, xx, yy) : yy += 17

        g.DrawString(Mid(ro("whsstr4"), 1, 30), ft, Brushes.Black, xx, yy) : yy += 15
        g.DrawString(Mid(ro("whsstr4"), 31, 30), ft, Brushes.Black, xx, yy) : yy += 17

        g.DrawString(Mid(ro("whsstr5"), 1, 30), ft, Brushes.Black, xx, yy) : yy += 15
        g.DrawString(Mid(ro("whsstr5"), 31, 30), ft, Brushes.Black, xx, yy) : yy += 17

        g.DrawString(Mid(ro("whsstr6"), 1, 30), ft, Brushes.Black, xx, yy) : yy += 15
        g.DrawString(Mid(ro("whsstr6"), 31, 30), ft, Brushes.Black, xx, yy)

        Dim no1, no2, no3, no4, no5, no6, total As Double
        no1 = 0 : no2 = 0 : no3 = 0 : no4 = 0 : no5 = 0 : no6 = 0
        If CDbl(ro("tagihan1")) <> 0 Then no1 = CDbl(ro("tagihan1"))
        If CDbl(ro("tagihan2")) <> 0 Then no2 = CDbl(ro("tagihan2"))
        If CDbl(ro("tagihan3")) <> 0 Then no3 = CDbl(ro("tagihan3"))
        If CDbl(ro("tagihan4")) <> 0 Then no4 = CDbl(ro("tagihan4"))
        If CDbl(ro("tagihan5")) <> 0 Then no5 = CDbl(ro("tagihan5"))
        If CDbl(ro("tagihan6")) <> 0 Then no6 = CDbl(ro("tagihan6"))
        total = no1 + no2 + no3 + no4 + no5 + no6

        xx = CInt(xnominal(bawah))
        yy = CInt(ynominal(bawah))
        If no1 <> 0 Then g.DrawString(CDec(no1).ToString("N0"), ft1, Brushes.Black, xx, yy)
        yy += 33 '10
        If no2 <> 0 Then g.DrawString(CDec(no2).ToString("N0"), ft1, Brushes.Black, xx, yy)
        yy += 33
        If no3 <> 0 Then g.DrawString(CDec(no3).ToString("N0"), ft1, Brushes.Black, xx, yy)
        yy += 33
        If no4 <> 0 Then g.DrawString(CDec(no4).ToString("N0"), ft1, Brushes.Black, xx, yy)
        yy += 33
        If no5 <> 0 Then g.DrawString(CDec(no5).ToString("N0"), ft1, Brushes.Black, xx, yy)
        yy += 33
        If no6 <> 0 Then g.DrawString(CDec(no6).ToString("N0"), ft1, Brushes.Black, xx, yy)


        xx = CInt(xtotal(bawah))
        yy = CInt(ytotal(bawah))
        If total <> 0 Then g.DrawString(CDec(total).ToString("N0"), ft2, Brushes.Black, xx, yy)

        Dim hari As String = "14"
        hari = getStringFromDB("select paramvalue from tbl_param where paramname='hariinvoice-" & ro("cardcode").ToString.Trim & "' ")
        If hari = "" Then hari = "14"
        If CInt(ro("isdirect").ToString.Trim) = 1 Then
            g.DrawString("Pembayaran akan dibayarkan " & hari & " hari kerja setelah invoice dan", ft, Brushes.Black, xvendor(bawah) - 8, yy)
            g.DrawString("semua dokumen diterima lengkap & benar.", ft, Brushes.Black, xvendor(bawah) - 8, yy + 15)
            g.DrawString("Tukar faktur hanya pada hari Senin, Rabu, Jumat (08:30-15:30).", ft, Brushes.Black, xvendor(bawah) - 8, yy + 30)
        Else
            g.DrawString("Diluar tgl 5 sampai 10, tukar faktur tidak diterima.", ft3, Brushes.Black, xvendor(bawah) - 8, yy)
            'g.DrawString("Diluar tgl tersebut tidak diterima.", ft, Brushes.Black, xvendor(bawah), yy + 15)
        End If
        xx = CInt(xcatatan(bawah))
        yy = CInt(ycatatan(bawah))
        'g.DrawString("", ft, Brushes.Black, xx, yy) : yy += 15
        'g.DrawString("Catatan 2", ft, Brushes.Black, xx, yy) : yy += 15
        'g.DrawString("Catatan 3", ft, Brushes.Black, xx, yy) : yy += 15


        g.DrawString(Format(Date.Parse(ro("tgl")), "dd MMMM yyyy"), ft1, Brushes.Black, xtgl(bawah), ytgl(bawah))
        g.DrawString(ro("terima"), ft1, Brushes.Black, xterima(bawah), yterima(bawah))
        g.DrawString(ro("serah"), ft1, Brushes.Black, xserah(bawah), yserah(bawah))
        'e.HasMorePages = True
    End Sub
    Private Sub CreateTandaTerimaConsignmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateTandaTerimaConsignmentToolStripMenuItem.Click
        Dim periode As DateTime
        periode = dtStartdate.Value.AddMonths(-1)
        If MsgConfirm("Anda Ingin Proses Tanda Terima Periode " & Format(periode, "MMM yyyy") & " ? ") <> vbYes Then Exit Sub
        Dim ds1 As DataSet

        Dim s As String
        ExecQuery("truncate table tmp_settlement", StrConSUP)
        s = "select cardkode, account, ref_date, whscode, sum(jumlah) as jumlah " & vbCrLf & _
            "from ( " & vbCrLf & _
                  "select apinv.docnum,T0.refDate as 'Ref_Date', t3.Cardcode as CardKode, " & vbCrLf & _
                  "Account=(CASE WHEN T2.AcctName IS NULL THEN  t3.cardname else  T2.AcctName end ), " & vbCrLf & _
                  "SUM(T1.Credit-T1.Debit)*-1 as Jumlah, apinv.whscode " & vbCrLf & _
                  "from [192.168.1.6].star.dbo.OJDT T0 " & vbCrLf & _
                  "inner join [192.168.1.6].star.dbo.JDT1 T1 on T0.TransId =T1.TransId " & vbCrLf & _
                  "left outer Join [192.168.1.6].star.dbo.OACT T2 ON T2.AcctCode=T1.ContraAct " & vbCrLf & _
                  "left outer join [192.168.1.6].star.dbo.OCRD t3 on t3.CardCode=T1.ContraAct " & vbCrLf & _
                  "inner Join ( ( SELECT PCH1.WhsCode, SUM(PCH1.LineTotal) AS JumLine, PCH1.TaxStatus, OPCH.DocNum  " & vbCrLf & _
                  "               FROM [192.168.1.6].star.dbo.PCH1 PCH1 " & vbCrLf & _
                  "               INNER JOIN [192.168.1.6].star.dbo.OPCH OPCH ON PCH1.DocEntry = OPCH.DocEntry  " & vbCrLf & _
                  "               GROUP BY PCH1.WhsCode, PCH1.TaxStatus, OPCH.DocNum " & vbCrLf & _
                  "               union " & vbCrLf & _
                  "               SELECT RPC1.WhsCode, SUM(RPC1.LineTotal) AS JumLine, RPC1.TaxStatus, ORPC.DocNum " & vbCrLf & _
                  "               FROM [192.168.1.6].star.dbo.RPC1 RPC1 " & vbCrLf & _
                  "               INNER JOIN [192.168.1.6].star.dbo.ORPC ORPC ON RPC1.DocEntry = ORPC.DocEntry " & vbCrLf & _
                  "               GROUP BY RPC1.WhsCode, RPC1.TaxStatus, ORPC.DocNum " & vbCrLf & _
                  "           ) ) apinv ON T0.BaseRef=apinv.DocNum " & vbCrLf & _
                  "Where Month(T0.refDate)='" & Format(periode, "MM") & "' and " & vbCrLf & _
                  "Year(T0.refDate)='" & Format(periode, "yyyy") & "' " & vbCrLf & _
                  "and T3.[cardcode] like '25%' and groupcode='102' " & vbCrLf & _
                  "group by T0.RefDate, t3.CardCode, T2.AcctName, t3.cardname, apinv.whscode,apinv.docnum " & vbCrLf & _
            "     ) a " & vbCrLf & _
            "group by cardkode, account, ref_date, whscode " & vbCrLf & _
            "order by cardkode, account, ref_date, whscode"
        '"and (T3.[cardcode] between '25000'  and '25520') " & vbCrLf & _
        'Dbg(s)
        ds1 = Query(s, StrConSAP)
        For Each ro As DataRow In ds1.Tables(0).Rows
            ExecQuery("insert into tmp_settlement values (" & vbCrLf & _
                      "'" & ro("ref_date") & "', " & vbCrLf & _
                      "'" & ro("cardkode") & "', " & vbCrLf & _
                      "'" & ro("account") & "', " & vbCrLf & _
                      "'" & ro("jumlah") & "', " & vbCrLf & _
                      "'" & ro("whscode") & "' " & vbCrLf & _
                      ")", StrConSUP)
        Next

        'MsgOK("xx")

        ds1 = Query("select cardkode as cardcode from tmp_settlement group by cardkode order by cardkode", StrConSUP)
        For Each ro As DataRow In ds1.Tables(0).Rows
            createConsignment(ro("cardcode"), periode, dtStartdate.Value)
        Next
        clearDataSet(ds1)
        MsgOK("Finished")
    End Sub
    Sub createConsignment(ByVal cardcode As String, ByVal periode As DateTime, ByVal dt As DateTime)
        OpenDBSupplier()
        Dim dsh As DataSet
        Dim totaltagihan As Double
        Dim noterima As String
        totaltagihan = CDbl(getStringFromDB("select sum(jumlah) as jumlah from tmp_settlement where cardkode='" & cardcode & "' group by cardkode"))
        noterima = newTerimaNumber()
        dsh = Query("select noterima from t_terima where month(tgl)='" & Format(dt, "MM") & "' and " & vbCrLf & _
                    "year(tgl)='" & Format(dt, "yyyy") & "' and cardcode='" & cardcode & "' ")
        If GetDSRecordCount(dsh) > 0 Then
            'ExecQuery("update t_terima")
        Else
            ExecQuery("insert into t_terima (noterima, cardcode, tgl, tgl_jatuhtempo, totaltagihan, sisatagihan," & vbCrLf & _
                      "potongan, jumlahbayar, serah, terima, remarks, issudahbayar, istrade, isdirect, issave," & vbCrLf & _
                      "useradded, dateadded) values ( " & vbCrLf & _
                      "'" & noterima & "', " & vbCrLf & _
                      "'" & cardcode & "', " & vbCrLf & _
                      "'" & Format(dt, "yyyy-MM-dd") & "', " & vbCrLf & _
                      "'" & Format(dt.AddDays(14), "yyyy-MM-dd") & "', " & vbCrLf & _
                      "'" & totaltagihan & "', '" & totaltagihan & "', 0, '" & totaltagihan & "', '', '" & UserLogin & "', '', '0', '1', '0', '1', " & vbCrLf & _
                      "'" & UserLogin & "', '" & Format(Now, "yyyy-MM-dd hh:mm:ss") & "') " & vbCrLf & _
                      "")
        End If
        insertConsignment(noterima, cardcode, dt.AddDays(14), periode)
        clearDataSet(dsh)
    End Sub
    Sub insertConsignment(ByVal noterima As String, ByVal cardcode As String, ByVal jatuhtempo As DateTime, ByVal periode As DateTime)
        Dim dstr, dsst As DataSet
        Dim st As String
        Dim tagihan As Double = 0
        dstr = QueryToDataset("select store.*, WhsName + ' - ' + WhsCode as whs  from Store where whscode<>'HO01' Order by WhsCode")
        dsst = QueryToDataset("select store.*, WhsName + ' - ' + WhsCode as whs  from Store where whscode<>'HO01' Order by WhsCode")
        For Each rs As DataRow In dsst.Tables(0).Rows
            st = rs("whscode").ToString.Trim
            tagihan = stringToDouble(getStringFromDB("select sum(jumlah) as jumlah from tmp_settlement where " & vbCrLf & _
                                           "cardkode='" & cardcode & "' and whscode='" & st & "' group by cardkode, whscode "))
            dstr = QueryToDataset("select * from t_terima_c where noterima='" & noterima & "' and whscode='" & st & "'")
            If dstr.Tables(0).Rows.Count = 0 Then
                ExecQuery("insert into t_terima_c (noterima, whscode, whsname, whs, tagihan, dokumen, " & vbCrLf & _
                          "tgl_jatuhtempo, tgl_bayar, isrevisi, useradded, dateadded, periode) values ( '" & noterima & "', '" & st & "', " & vbCrLf & _
                          "'" & rs("whsname").ToString.Trim & "', '" & rs("whs").ToString.Trim & "', " & vbCrLf & _
                          "'" & tagihan & "', '', '" & Format(jatuhtempo, "yyyy-MM-dd") & "', null, 0, " & vbCrLf & _
                          "'" & UserLogin & "', '" & Format(Now, "yyyy-MM-dd hh:mm:ss") & "', '" & Format(periode, "yyyy-MM-dd") & "' ) ")
            End If
        Next
        clearDataSet(dsst)
        clearDataSet(dstr)
    End Sub

    Private Sub XxToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XxToolStripMenuItem.Click
        'dlgPrintPreview.Document = PrintDocument2
        'dlgPrintPreview.WindowState = FormWindowState.Maximized
        'dlgPrintPreview.ShowDialog()

        'PrintDocument1.Print()
    End Sub

    Private Sub PrintDocument2_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument2.PrintPage
        
    End Sub

    Private Sub DirectToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DirectToolStripMenuItem1.Click
        ReportNotPaid(" th.tgl>=" & dt2sql(dtStartdate.Value) & " and th.tgl<=" & dt2sql(dtEnddate.Value) & " ", 1)
    End Sub
    Private Sub ConsignmentToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsignmentToolStripMenuItem1.Click
        ReportNotPaid(" th.tgl>=" & dt2sql(dtStartdate.Value) & " and th.tgl<=" & dt2sql(dtEnddate.Value) & " ", 0)
    End Sub

    Private Sub DirectToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DirectToolStripMenuItem2.Click
        ReportPaid(" th.tgl>=" & dt2sql(dtStartdate.Value) & " and th.tgl<=" & dt2sql(dtEnddate.Value) & " ", 1)
    End Sub

    Private Sub ConsignmentToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsignmentToolStripMenuItem2.Click
        ReportPaid(" th.tgl>=" & dt2sql(dtStartdate.Value) & " and th.tgl<=" & dt2sql(dtEnddate.Value) & " ", 0)
    End Sub
End Class