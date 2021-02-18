Imports System.Data
Imports System.Data.OleDb
Imports System.Linq
Imports System.IO
Public Class AbsenSummary
    Dim Process As Decimal
    Dim strProcess As String

#Region "Background Worker"
    Private Sub BackgroundWorker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker.DoWork

    End Sub
    Private Sub BackgroundWorker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker.ProgressChanged
        'pBar.Value = e.ProgressPercentage
        'LblProses.Text = strProcess
        ''Label1.Text = "Percentage Progress = " & pBar.Value.ToString & "%"
    End Sub
    Private Sub BackgroundWorker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker.RunWorkerCompleted

    End Sub
#End Region

#Region "FORM"
    Private Sub FrmGenerate_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'BackgroundWorker.CancelAsync()
        CloseDBALL()
        'setColumnGrid()
    End Sub
    Private Sub FrmGenerate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OpenDBHRD()
        'Dim ico As New System.Drawing.Icon(LokasiICOFile) : Me.Icon = ico
        'btnProses.Image = Image.FromFile(FolderImage & "reload.png")
        'Me.Height = 127
        GbPilih.Visible = False
        dtgen.Value = Now
        dtgen2.Value = Now
        cbxChoose.Checked = False
        pBar.Visible = False
        pBar.Value = 0

        cboDept.Enabled = False
        cboBagian.Enabled = False
        CboJabatan.Enabled = False

        Dim dt As DateTime
        'dt = Now.AddMonths(-1)
        dt = Now
        dtgen.Value = DateTime.Parse(dt.Year & "-" & dt.Month & "-01")
        dtgen2.Value = DateTime.Parse(dt.Year & "-" & dt.Month & "-01").AddMonths(1).AddDays(-1)

        GbPilih.Visible = True
        txtCari.Clear()
        TampilKaryawan(txtCari.Text.Trim)
        txtCari.Focus()
    End Sub
#End Region
#Region "Tampil Karyawan"
    Private Sub cbxHilang_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxHilang.CheckedChanged
        If cbxHilang.Checked Then
            cbxPilih.Checked = False
            isiChooseALL(0)
        Else
            cbxPilih.Checked = True
            isiChooseALL(1)
        End If
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
    Sub isiChooseALL(ByVal pilih As Integer)
        If dg.RowCount = 0 Then Exit Sub
        Dim x As Integer
        For x = 0 To dg.RowCount - 1
            dg.Item(0, x).Value = pilih
        Next
    End Sub
    Private Sub cbxChoose_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxChoose.CheckedChanged
        If cbxChoose.Checked Then
            txtCari.Clear()
            TampilKaryawan(txtCari.Text.Trim)
            Me.Height = 445
            GbPilih.Visible = True
            txtCari.Focus()
        Else
            Me.Height = 127
            GbPilih.Visible = False
        End If
    End Sub

    Private Sub txtCari_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCari.KeyDown
        If e.KeyCode = Keys.Down Then
            dg.Focus()
        End If
    End Sub
    Private Sub txtCari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCari.TextChanged
        'NavSource1.Filter = " (name like '%" & txtCari.Text.Trim & "%') or (nip like '%" & txtCari.Text.Trim & "%') "
        NavSource1.Filter = getFilterKaryawan()
    End Sub
    Sub TampilKaryawan(ByVal txt As String)
        Dim SQL As String
        Dim dsKar As New DataSet

        SQL = "select 1 as choose, employee_id, nip, name, departmentname, bagianname, jabatanname, unitname, " & vbCrLf & _
              "departmentcode, bagiancode, jabatancode from v_employee " & vbCrLf & _
              "where " & vbCrLf & _
              "unitcode='S000' and isdelete=0 and " & vbCrLf & _
              " isactive='YES' and (nip like '%" & txtCari.Text.Trim & "%' or name like '%" & txtCari.Text.Trim & "%') " & vbCrLf & _
              "order by name"
        'Dbg(SQL)
        cbxHilang.Checked = False
        dsKar = Query(SQL, StrConHRD)
        dg.DataSource = dsKar.Tables(0)
        NavSource1.DataSource = dsKar.Tables(0)
        'Dim code As String
        ''cboDept.Text = "B01-IT"
        'code = getCodeFromCheckboxCombo(Replace("B01-IT", "'", "''"), ",", "-")
        'NavSource1.Filter = " (departmentcode in (" & code & ") ) "
        If dsKar.Tables(0).Rows.Count > 0 Then
            dg.Refresh()
        Else
            MsgError("No Data")
        End If
        cbxPilih.Checked = True
    End Sub

    Sub isiDept()
        cboDept.Items.Clear()
        cboDept.Text = ""
        If cbxDept.Checked Then
            isiComboboxFromSQL(cboDept, "select ltrim(rtrim(code))+'-'+ltrim(rtrim(name)) as aa " & vbCrLf & _
                               "from m_department order by ltrim(rtrim(code))+'-'+ltrim(rtrim(name)) ")
        End If
    End Sub
    Sub isiBagian()
        cboBagian.Items.Clear()
        cboBagian.Text = ""
        If cbxBagian.Checked Then
            isiComboboxFromSQL(cboBagian, "select ltrim(rtrim(code))+'-'+ltrim(rtrim(name)) as aa " & vbCrLf & _
                               "from m_bagian order by ltrim(rtrim(code))+'-'+ltrim(rtrim(name)) ")
        End If
    End Sub
    Sub isiJabatan()
        CboJabatan.Items.Clear()
        CboJabatan.Text = ""
        If cbxJabatan.Checked Then
            isiComboboxFromSQL(CboJabatan, "select ltrim(rtrim(code))+'-'+ltrim(rtrim(name)) as aa " & vbCrLf & _
                               "from m_jabatan order by ltrim(rtrim(code))+'-'+ltrim(rtrim(name)) ")
        End If
    End Sub
    Private Sub cbxDept_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxDept.CheckedChanged
        If cbxDept.Checked Then
            cboDept.Enabled = True
            isiDept()
        Else
            cboDept.Items.Clear()
            cboDept.Enabled = False
        End If
        NavSource1.Filter = getFilterKaryawan()
    End Sub

    Private Sub cbxBagian_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxBagian.CheckedChanged
        If cbxBagian.Checked Then
            cboBagian.Enabled = True
            isiBagian()
        Else
            cboBagian.Items.Clear()
            cboBagian.Enabled = False
        End If
        NavSource1.Filter = getFilterKaryawan()
    End Sub

    Private Sub cbxJabatan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxJabatan.CheckedChanged
        If cbxJabatan.Checked Then
            CboJabatan.Enabled = True
            isiJabatan()
        Else
            CboJabatan.Items.Clear()
            CboJabatan.Enabled = False
        End If
        NavSource1.Filter = getFilterKaryawan()
    End Sub
    Function getFilterKaryawan() As String
        Dim hasil As String = ""
        Dim code As String = ""
        hasil = " (0=0) "
        'hasil = " (name like '%" & txtCari.Text.Trim & "%' or nip like '%" & txtCari.Text.Trim & "%') "

        If cbxDept.Checked Then
            If cboDept.Text.Trim <> "" Then
                code = getCodeFromCheckboxCombo(Replace(cboDept.Text.Trim, "'", "''"), ",", "-")
                'MsgOK(code)
                hasil = hasil & " and (departmentcode in (" & code & ")) "
            End If
        End If

        If cbxBagian.Checked Then
            If cboBagian.Text.Trim <> "" Then
                code = getCodeFromCheckboxCombo(Replace(cboBagian.Text.Trim, "'", "''"), ",", "-")
                hasil = hasil & " and (bagiancode in (" & code & ")) "
            End If
        End If

        If cbxJabatan.Checked Then
            If CboJabatan.Text.Trim <> "" Then
                code = getCodeFromCheckboxCombo(Replace(CboJabatan.Text.Trim, "'", "''"), ",", "-")
                hasil = hasil & " and (jabatancode in (" & code & ")) "
            End If
        End If

        Dim emp As String = ""

        For x As Integer = 0 To dg.RowCount - 1
            If CInt(dg.Item(0, x).Value) = 1 Then
                emp = emp & "'" & dg.Item(8, x).Value & "',"
            End If
        Next
        If emp <> "" Then
            'hasil = hasil & " and ( e ) " & emp
        End If

        TextBox1.Text = hasil
        'MsgOK(hasil)
        Return hasil
    End Function
    Private Sub cboDept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDept.SelectedIndexChanged
        'Dim code As String
        'code = getCodeFromCheckboxCombo(Replace(cboDept.Text.Trim, "'", "''"), ",", "-")
        'NavSource1.Filter = NavSource1.Filter & " and (departmentcode in ('" & code & "')) "
        NavSource1.Filter = getFilterKaryawan()
    End Sub

    Private Sub cboBagian_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBagian.SelectedIndexChanged
        'Dim code As String
        'code = getCodeFromCheckboxCombo(Replace(cboBagian.Text.Trim, "'", "''"), ",", "-")
        'NavSource1.Filter = NavSource1.Filter & " and (bagiancode in ('" & code & "')) "
        NavSource1.Filter = getFilterKaryawan()
    End Sub

    Private Sub CboJabatan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboJabatan.SelectedIndexChanged
        'Dim code As String
        'code = getCodeFromCheckboxCombo(Replace(CboJabatan.Text.Trim, "'", "''"), ",", "-")
        'NavSource1.Filter = NavSource1.Filter & " and (jabatancode in ('" & code & "')) "
        NavSource1.Filter = getFilterKaryawan()
    End Sub
#End Region

#Region "Report"
    Sub isiTmpAbsen(ByVal Group As String)
        Dim SQL As String
        SQL = "select " & Group & " '" & Format(dtgen.Value, "yyyy-MM-dd") & "' as startdate, " & vbCrLf & _
              "'" & Format(dtgen2.Value, "yyyy-MM-dd") & "' as enddate, v.* " & vbCrLf & _
              "into tmp_absen from v_reportAbsen v " & vbCrLf & _
              "where convert(varchar(10), v.tgl, 20) >= '" & Format(dtgen.Value, "yyyy-MM-dd") & "' " & vbCrLf & _
              "and convert(varchar(10), v.tgl, 20) <= '" & Format(dtgen2.Value, "yyyy-MM-dd") & "' " & vbCrLf & _
              "and " & getFilterKaryawan() & " "
        'Dbg(SQL)
        ExecQuery("IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[tmp_absen]') " & vbCrLf & _
                  "AND OBJECTPROPERTY(id, N'IsUserTable') = 1) " & vbCrLf & _
                  "DROP TABLE [dbo].[tmp_absen]")
        ExecQuery(SQL)
        'MsgOK("Finished")
    End Sub
    Sub isiTmpAbsen2()
        Dim s As String
        ExecQuery("IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[tmp_absen2]') " & vbCrLf & _
                  "AND OBJECTPROPERTY(id, N'IsUserTable') = 1) " & vbCrLf & _
                  "DROP TABLE [dbo].[tmp_absen2]")
        s = "select kode as kd_group, nama as nm_group, tipe, startdate, enddate, employee_id as spg_id, " & vbCrLf & _
            "nip as spg_barcode, fingercode, name as spg_name, department_id, departmentcode as kd_dept, " & vbCrLf & _
            "departmentname as nm_dept, bagian_id, bagiancode as kd_kagian, '' as brand, " & vbCrLf & _
            "bagianname as nm_bagian, jabatan_id, jabatancode as kd_sbu, jabatanname as nm_sbu, " & vbCrLf & _
            "[alpa], [cuti], [izin], [latenight], [lembur], [off], [ro], [sakit], [terlambat], " & vbCrLf & _
            "([latenight]+[lembur]+[masuk]+terlambat) as totalhadir " & vbCrLf & _
            "into tmp_absen2" & vbCrLf & _
            "from " & vbCrLf & _
            "( " & vbCrLf & _
            "   select kode, nama, tipe, startdate, enddate, employee_id, nip, fingercode, name, " & vbCrLf & _
            "   department_id, departmentcode, departmentname, bagian_id, bagiancode, bagianname, " & vbCrLf & _
            "   jabatan_id, jabatancode, jabatanname, status from tmp_absen " & vbCrLf & _
            ") a " & vbCrLf & _
            "PIVOT " & vbCrLf & _
            "( " & vbCrLf & _
            "count(status) for status in " & vbCrLf & _
            "( [alpa], [cuti], [izin], [latenight], [lembur], [masuk], [off], [ro], [sakit], [terlambat] ) " & vbCrLf & _
            ") as pvt " & vbCrLf & _
            "order by kode, name"
        'Dbg(s)
        ExecQuery(s)
    End Sub
    Sub isiTmpAbsenMonthly()
        Dim s As String
        s = "select convert(varchar(5), 'HO') as store, kd_group, nm_group, " & vbCrLf & _
            "spg_barcode, spg_name, " & vbCrLf & _
            "nm_bagian, nm_sbu, nm_dept, brand, " & vbCrLf & _
            "spg_id, kd_bagian, kd_sbu, kd_dept, startdate, enddate, " & vbCrLf & _
            "[1], [2], [3], [4], [5], [6], [7], [8], [9], [10], " & vbCrLf & _
            "[11], [12], [13], [14], [15], [16], [17], [18], [19], [20], " & vbCrLf & _
            "[21], [22], [23], [24], [25], [26], [27], [28], [29], [30], [31], " & vbCrLf & _
            "coalesce([S], 0) as S, coalesce([I], 0) as I, coalesce([A], 0) as A, " & vbCrLf & _
            "coalesce([C], 0) as C, coalesce([O], 0) as O, coalesce([R], 0) as R, coalesce([T], 0) as T, " & vbCrLf & _
            "coalesce([TM], 0) as TM, coalesce([M],0)+coalesce([T],0)+coalesce([LM],0)+coalesce([LN],0) as TH " & vbCrLf & _
            "into tmp_absen_monthly " & vbCrLf & _
            "from " & vbCrLf & _
            "( " & vbCrLf & _
            "   select kode as kd_group, nama as nm_group, nip as spg_barcode, name as spg_name, " & vbCrLf & _
            "   bagianname as nm_bagian, jabatanname as nm_sbu, departmentname as nm_dept, '' as brand, " & vbCrLf & _
            "   employee_id as spg_id, bagiancode as kd_bagian, jabatancode as kd_sbu, departmentcode as kd_dept, " & vbCrLf & _
            "   startdate, enddate, convert(varchar(5), datepart(dd, tgl)) as tgl, ss " & vbCrLf & _
            "   from tmp_absen ta " & vbCrLf & _
            "   union all " & vbCrLf & _
            "   select kode as kd_group, nama as nm_group, nip as spg_barcode, name as spg_name, " & vbCrLf & _
            "   bagianname as nm_bagian, jabatanname as nm_sbu, departmentname as nm_dept, '' as brand, " & vbCrLf & _
            "   employee_id as spg_id, bagiancode as kd_bagian, jabatancode as kd_sbu, departmentcode as kd_dept, " & vbCrLf & _
            "   startdate, enddate, st as tgl, convert(varchar(20), count(st)) as ss " & vbCrLf & _
            "   from tmp_absen ta " & vbCrLf & _
            "   group by kode, nama, nip, name, bagianname, jabatanname, departmentname, " & vbCrLf & _
            "   employee_id, bagiancode, jabatancode, departmentcode, startdate, enddate, st " & vbCrLf & _
            "   union ALL " & vbCrLf & _
            "   select kode as kd_group, nama as nm_group, nip as spg_barcode, name as spg_name, " & vbCrLf & _
            "   bagianname as nm_bagian, jabatanname as nm_sbu, departmentname as nm_dept, '' as brand, " & vbCrLf & _
            "   employee_id as spg_id, bagiancode as kd_bagian, jabatancode as kd_sbu, departmentcode as kd_dept, " & vbCrLf & _
            "   startdate, enddate, 'TM' as tgl, convert(varchar(20), SUM(lateminutes)) as ss " & vbCrLf & _
            "   from tmp_absen ta " & vbCrLf & _
            "   group by kode, nama, nip, name, bagianname, jabatanname, departmentname, " & vbCrLf & _
            "   employee_id, bagiancode, jabatancode, departmentcode, startdate, enddate " & vbCrLf & _
            ") d " & vbCrLf & _
            "pivot " & vbCrLf & _
            "( " & vbCrLf & _
            "   max(ss) " & vbCrLf & _
            "   for tgl in " & vbCrLf & _
            "   ( " & vbCrLf & _
            "       [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], " & vbCrLf & _
            "       [11], [12], [13], [14], [15], [16], [17], [18], [19], [20], " & vbCrLf & _
            "       [21], [22], [23], [24], [25], [26], [27], [28], [29], [30], [31], " & vbCrLf & _
            "       [s], [i], [C], [A], [O], [R], [M], [T], [LM], [LN], [TM] " & vbCrLf & _
            "   ) " & vbCrLf & _
            ") piv " & vbCrLf & _
            "order by store, kd_group, spg_name"
        'Dbg(s)
        ExecQuery("IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[tmp_absen_monthly]') " & vbCrLf & _
                  "AND OBJECTPROPERTY(id, N'IsUserTable') = 1) " & vbCrLf & _
                  "DROP TABLE [dbo].[tmp_absen_monthly]")
        ExecQuery(s)       
    End Sub
    Sub ProcessKehadiran()
        'Exit Sub
        Dim sh, pathName, sd, ed, periode, branch, f11, f12, f21, f22, f31, f32, f41, f42 As String
        Dim dsk As DataSet
        dsk = Query("SELECT top 1  'PERIODE ' + upper(replace( convert(varchar(11), convert(datetime, startdate, 20), 106), ' ', '-')) " & vbCrLf & _
                    "+ ' s/d ' + upper(replace( convert(varchar(11), convert(datetime, enddate, 20), 106), ' ', '-')) as periode, " & vbCrLf & _
                    "replace( convert(varchar(50), startdate, 6), '-', '') as startdate, " & vbCrLf & _
                    "replace( convert(varchar(10), enddate, 20), '-', '') as enddate " & vbCrLf & _
                    "from tmp_absen2 ")
        If GetDSRecordCount(dsk) = 0 Then
            clearDataSet(dsk)
            MsgError("No Data")
            Exit Sub
        End If

        'sd = GetDSString(dsk, "startdate")
        'ed = GetDSString(dsk, "enddate")
        'periode = GetDSString(dsk, "periode")
        'branch = getStringDB("select top 1 code from tbl_branches")

        sd = dsk.Tables(0).Rows(0).Item("startdate").ToString
        ed = dsk.Tables(0).Rows(0).Item("enddate").ToString
        periode = dsk.Tables(0).Rows(0).Item("periode").ToString
        'branch = getStringFromDB("select top 1 code from tbl_branches")
        branch = "HO"

        f11 = getStringFromDB("select top 1 paramvalue from tbl_param where paramname='dibuat 1'")
        f12 = getStringFromDB("select top 1 paramvalue from tbl_param where paramname='dibuat 2'")
        f21 = getStringFromDB("select top 1 paramvalue from tbl_param where paramname='diketahui 1'")
        f22 = getStringFromDB("select top 1 paramvalue from tbl_param where paramname='diketahui 2'")
        f31 = getStringFromDB("select top 1 paramvalue from tbl_param where paramname='diperiksa 1'")
        f32 = getStringFromDB("select top 1 paramvalue from tbl_param where paramname='diperiksa 2'")
        f41 = getStringFromDB("select top 1 paramvalue from tbl_param where paramname='disetujui 1'")
        f42 = getStringFromDB("select top 1 paramvalue from tbl_param where paramname='disetujui 2'")

        sh = "sheetname=LaporanKehadiran;"
        pathName = Application.StartupPath & "\LaporanKehadiran" & "-" & _
                   sd & "-" & ed & ".xls"
        PrepareExcel(sh, pathName)
        xlWorkSheet(0).Activate()
        'MsgOK("3")
        CellFormat(xlWorkSheet(0), "range=A1;fontname=tahoma;fontsize=12;fontstyle=bold;" & vbCrLf & _
                   "verticalalignment=center;horizontalalignment=center", "PT. STAR MAJU SENTOSA")
        CellFormat(xlWorkSheet(0), "range=A2;fontname=tahoma;fontsize=12;fontstyle=bold;" & vbCrLf & _
                   "verticalalignment=center;horizontalalignment=center", "LAPORAN KEHADIRAN KARYAWAN")
        CellFormat(xlWorkSheet(0), "range=A3;fontname=tahoma;fontsize=12;fontstyle=bold;" & vbCrLf & _
                   "verticalalignment=center;horizontalalignment=center", periode)
        CellFormat(xlWorkSheet(0), "range=A4;fontname=tahoma;fontsize=12;fontstyle=bold;" & vbCrLf & _
                   "verticalalignment=center;horizontalalignment=center", "HEAD OFFICE")

        CellFormat(xlWorkSheet(0), "range=A1:H1;merge=true")
        CellFormat(xlWorkSheet(0), "range=A2:H2;merge=true")
        CellFormat(xlWorkSheet(0), "range=A3:H3;merge=true")
        CellFormat(xlWorkSheet(0), "range=A4:H4;merge=true")

        CellFormat(xlWorkSheet(0), "range=A5;fontname=tahoma;fontsize=10;fontstyle=bold;isborder=true;" & vbCrLf & _
                   "verticalalignment=center;horizontalalignment=center;backcolor=0,255,255;wrap=true", "NO.")
        CellFormat(xlWorkSheet(0), "range=B5;fontname=tahoma;fontsize=10;fontstyle=bold;isborder=true;" & vbCrLf & _
                   "verticalalignment=center;horizontalalignment=center;backcolor=0,255,255;wrap=true", "NAMA")
        CellFormat(xlWorkSheet(0), "range=C5;fontname=tahoma;fontsize=10;fontstyle=bold;isborder=true;" & vbCrLf & _
                   "verticalalignment=center;horizontalalignment=center;backcolor=0,255,255;wrap=true", "JABATAN")
        CellFormat(xlWorkSheet(0), "range=D5;fontname=tahoma;fontsize=10;fontstyle=bold;isborder=true;" & vbCrLf & _
                   "verticalalignment=center;horizontalalignment=center;backcolor=0,255,255;wrap=true", "HADIR")
        CellFormat(xlWorkSheet(0), "range=E5;fontname=tahoma;fontsize=10;fontstyle=bold;isborder=true;" & vbCrLf & _
                   "verticalalignment=center;horizontalalignment=center;backcolor=0,255,255;wrap=true", "UANG KEHADIRAN")
        CellFormat(xlWorkSheet(0), "range=F5;fontname=tahoma;fontsize=10;fontstyle=bold;isborder=true;" & vbCrLf & _
                   "verticalalignment=center;horizontalalignment=center;backcolor=0,255,255;wrap=true", "TOTAL")
        CellFormat(xlWorkSheet(0), "range=G5;fontname=tahoma;fontsize=10;fontstyle=bold;isborder=true;" & vbCrLf & _
                   "verticalalignment=center;horizontalalignment=center;backcolor=0,255,255;wrap=true", "KETERANGAN")
        CellFormat(xlWorkSheet(0), "range=H5;fontname=tahoma;fontsize=10;fontstyle=bold;isborder=true;" & vbCrLf & _
                   "verticalalignment=center;horizontalalignment=center;backcolor=0,255,255;wrap=true", "TTD")
        xlWorkSheet(0).Rows("5").rowheight = 32
        'CellFormat(xlWorkSheet(0), "range=A5:A6;merge=true;backcolor=0,255,255")
        'CellFormat(xlWorkSheet(0), "range=B5:B6;merge=true;backcolor=0,255,255")
        'CellFormat(xlWorkSheet(0), "range=C5:C6;merge=true;backcolor=0,255,255")
        'CellFormat(xlWorkSheet(0), "range=D5:D6;merge=true;backcolor=0,255,255")
        'CellFormat(xlWorkSheet(0), "range=E5:E6;merge=true;backcolor=0,255,255")
        'CellFormat(xlWorkSheet(0), "range=F5:F6;merge=true;backcolor=0,255,255")
        'CellFormat(xlWorkSheet(0), "range=G5:G6;merge=true;backcolor=0,255,255")
        'CellFormat(xlWorkSheet(0), "range=H5:H6;merge=true;backcolor=0,255,255")

        Dim dsb As DataSet
        Dim row As Integer = 6
        Dim no As Integer = 1
        Dim totalhadir As Integer = 0
        Dim kol1, kol2 As Integer
        'MsgOK("header")
        dsb = Query("select coalesce(kd_group, '') as kd_group, coalesce(nm_group, '') as nm_group from tmp_absen2 group by kd_group, nm_group order by nm_group")
        For Each rb As DataRow In dsb.Tables(0).Rows
            'isi group
            CellFormat(xlWorkSheet(0), "range=A" & row & ":H" & row & ";merge=true;isborder=true")
            CellFormat(xlWorkSheet(0), "range=A" & row & ";backcolor=192,192,192;fontname=Tahoma;" & vbCrLf & _
                       "fontsize=10;fontstyle=bold;verticalalignment=center;horizontalalignment=left", _
                       rb("nm_group").ToString.Trim)
            'MsgOK("a")
            dsk = Query("select kd_group, nm_group, spg_id, spg_barcode, spg_name, brand, totalhadir " & vbCrLf & _
                        "from tmp_absen2 " & vbCrLf & _
                        "where coalesce(kd_group, '')='" & rb("kd_group").ToString.Trim & "' " & vbCrLf & _
                        "order by nm_group, spg_name")
            row += 1
            kol1 = row
            For Each rk As DataRow In dsk.Tables(0).Rows
                'MsgOK("b")
                CellFormat(xlWorkSheet(0), "range=A" & row & ";fontname=Tahoma;isborder=true;" & vbCrLf & _
                       "fontsize=10;verticalalignment=center;horizontalalignment=center", _
                       no)
                'MsgOK("c")
                CellFormat(xlWorkSheet(0), "range=B" & row & ";fontname=Tahoma;isborder=true;" & vbCrLf & _
                       "fontsize=10;verticalalignment=center", _
                       rk("spg_name").ToString.Trim)
                'MsgOK("d")
                CellFormat(xlWorkSheet(0), "range=C" & row & ";fontname=Tahoma;isborder=true;" & vbCrLf & _
                       "fontsize=10;verticalalignment=center;horizontalalignment=center", _
                       rk("brand").ToString.Trim)
                'MsgOK("e")
                '{tmp_absen2.latenight}+{tmp_absen2.lembur}+{tmp_absen2.masuk}+{tmp_absen2.terlambat}
                totalhadir = CInt(rk("totalhadir"))
                CellFormat(xlWorkSheet(0), "range=D" & row & ";fontname=Tahoma;isborder=true;" & vbCrLf & _
                       "fontsize=10;verticalalignment=center;horizontalalignment=center", _
                       totalhadir)
                'MsgOK("f")
                CellFormat(xlWorkSheet(0), "range=E" & row & ";fontname=Tahoma;isborder=true;" & vbCrLf & _
                       "fontsize=10;verticalalignment=center;horizontalalignment=right", _
                       "")
                CellFormat(xlWorkSheet(0), "range=F" & row & ";fontname=Tahoma;isborder=true;" & vbCrLf & _
                       "fontsize=10;verticalalignment=center;horizontalalignment=right", _
                       "=E" & row & "*D" & row & "")
                CellFormat(xlWorkSheet(0), "range=G" & row & ";fontname=Tahoma;isborder=true;" & vbCrLf & _
                       "fontsize=10;verticalalignment=center;horizontalalignment=left", _
                       "")
                CellFormat(xlWorkSheet(0), "range=H" & row & ";fontname=Tahoma;isborder=true;" & vbCrLf & _
                       "fontsize=10;verticalalignment=center;horizontalalignment=left", _
                       "")
                'CellFormat(xlWorkSheet(0), "range=E:" & row & ";numberformat=#,##0;" & vbCrLf & _
                '           "verticalalignment=center;horizontalalignment=right", "")
                'MsgOK("g")
                'CellFormat(xlWorkSheet(0), "range=F:" & row & ";numberformat=#,##0;" & vbCrLf & _
                '           "verticalalignment=center;horizontalalignment=right", "=E" & row & "*D" & row & "")
                'MsgOK("h")
                'xxxxx()
                kol2 = row
                row += 1
                no += 1

            Next
            CellFormat(xlWorkSheet(0), "range=A" & row & ";backcolor=192,192,192;fontname=Tahoma;isborder=true;" & vbCrLf & _
                       "fontsize=10;fontstyle=bold;verticalalignment=center;horizontalalignment=left", _
                       "Subtotal " & rb("nm_group").ToString.Trim)
            CellFormat(xlWorkSheet(0), "range=A" & row & ":E" & row & ";merge=true;isborder=true")
            'CellFormat(xlWorkSheet(0), "range=A" & row & ";E" & row & ";merge=true;backcolor=0,255,255")
            CellFormat(xlWorkSheet(0), "range=F" & row & ";fontname=Tahoma;backcolor=192,192,192;isborder=true;" & vbCrLf & _
                       "fontsize=10;verticalalignment=center;horizontalalignment=right", _
                       "=sum(F" & kol1 & ":F" & kol2 & ")")
            CellFormat(xlWorkSheet(0), "range=G" & row & ";fontname=Tahoma;backcolor=192,192,192;isborder=true;" & vbCrLf & _
                       "fontsize=10;verticalalignment=center", _
                       "")
            CellFormat(xlWorkSheet(0), "range=H" & row & ";fontname=Tahoma;backcolor=192,192,192;isborder=true;" & vbCrLf & _
                       "fontsize=10;verticalalignment=center", _
                       "")
            row += 2
        Next
        'MsgOK("isi")
        row += 2
        CellFormat(xlWorkSheet(0), "range=B" & row & ";fontname=Tahoma;" & vbCrLf & _
                       "fontsize=10;verticalalignment=center;horizontalalignment=center", _
                       "Dibuat Oleh,")
        CellFormat(xlWorkSheet(0), "range=C" & row & ";fontname=Tahoma;" & vbCrLf & _
                       "fontsize=10;verticalalignment=center;horizontalalignment=center", _
                       "Diketahui Oleh,")
        'CellFormat(xlWorkSheet(0), "range=E" & row & ";fontname=Tahoma;" & vbCrLf & _
        '               "fontsize=10;verticalalignment=center;horizontalalignment=center", _
        '               "Diperiksa Oleh,")
        CellFormat(xlWorkSheet(0), "range=G" & row & ";fontname=Tahoma;" & vbCrLf & _
                               "fontsize=10;verticalalignment=center;horizontalalignment=center", _
                               "Disetujui Oleh,")
        row += 4
        CellFormat(xlWorkSheet(0), "range=B" & row & ";fontname=Tahoma;fontstyle=bold,underline;" & vbCrLf & _
                       "fontsize=10;verticalalignment=center;horizontalalignment=center", _
                       f11)
        CellFormat(xlWorkSheet(0), "range=C" & row & ";fontname=Tahoma;fontstyle=bold,underline;" & vbCrLf & _
                       "fontsize=10;verticalalignment=center;horizontalalignment=center", _
                       f21)
        CellFormat(xlWorkSheet(0), "range=E" & row & ";fontname=Tahoma;fontstyle=bold,underline;" & vbCrLf & _
                       "fontsize=10;verticalalignment=center;horizontalalignment=center", _
                       f31)
        CellFormat(xlWorkSheet(0), "range=G" & row & ";fontname=Tahoma;fontstyle=bold,underline;" & vbCrLf & _
                               "fontsize=10;verticalalignment=center;horizontalalignment=center", _
                               f41)

        row += 1
        CellFormat(xlWorkSheet(0), "range=B" & row & ";fontname=Tahoma;" & vbCrLf & _
                       "fontsize=10;verticalalignment=center;horizontalalignment=center", _
                       f12)
        CellFormat(xlWorkSheet(0), "range=C" & row & ";fontname=Tahoma;" & vbCrLf & _
                       "fontsize=10;verticalalignment=center;horizontalalignment=center", _
                       f22)
        CellFormat(xlWorkSheet(0), "range=E" & row & ";fontname=Tahoma;" & vbCrLf & _
                       "fontsize=10;verticalalignment=center;horizontalalignment=center", _
                       f32)
        CellFormat(xlWorkSheet(0), "range=G" & row & ";fontname=Tahoma;" & vbCrLf & _
                               "fontsize=10;verticalalignment=center;horizontalalignment=center", _
                               f42)

        CellFormat(xlWorkSheet(0), "range=A:A;columnwidth=4")
        CellFormat(xlWorkSheet(0), "range=B:B;columnwidth=27")
        CellFormat(xlWorkSheet(0), "range=C:C;columnwidth=15")
        CellFormat(xlWorkSheet(0), "range=D:D;columnwidth=6")
        CellFormat(xlWorkSheet(0), "range=E:E;columnwidth=13")
        CellFormat(xlWorkSheet(0), "range=F:F;columnwidth=13")
        CellFormat(xlWorkSheet(0), "range=G:G;columnwidth=27")
        CellFormat(xlWorkSheet(0), "range=H:H;columnwidth=15")

        CellFormat(xlWorkSheet(0), "range=1:1;rowheight=25")
        CellFormat(xlWorkSheet(0), "range=2:2;rowheight=25")
        CellFormat(xlWorkSheet(0), "range=3:3;rowheight=25")
        CellFormat(xlWorkSheet(0), "range=4:4;rowheight=25")
        'MsgOK("footer")
        'JudulExcelPDT(xlWorkSheet(0))
        'QueryPasteToExcel(xlWorkSheet(0), s, "A6")
        'totalLine = File.ReadAllLines("temptxt.txt").Length
        ''MsgOK("5")
        ''disini
        's1 = "=" : s2 = "="
        'For x As Integer = 1 To totalLoc
        '    s1 += colExcel(5 + x) & "7+"
        'Next

        'xlWorkSheet(0).Range("D6").Select()
        'xlApp.ActiveWindow.FreezePanes = True

        'CellFormat(xlWorkSheet(0), "range=A:A;columnwidth=17")
        'CellFormat(xlWorkSheet(0), "range=B:B;columnwidth=12")
        'CellFormat(xlWorkSheet(0), "range=C:E;columnwidth=clear")
        'CellFormat(xlWorkSheet(0), "range=F:" & colExcel(totalKolom - 2) & ";columnwidth=8.20")
        'CellFormat(xlWorkSheet(0), "range=" & colExcel(totalKolom - 1) & ":" & colExcel(totalKolom) & ";columnwidth=clear")

        'CellFormat(xlWorkSheet(0), "range=A6:" & colExcel(totalKolom) & totalLine + 5 & ";fontsize=8;fontname=Tahoma;isborder=true")
        'CellFormat(xlWorkSheet(0), "range=A5:" & colExcel(totalKolom) & "5;backcolor=192,192,192;isborder=true;wrap=true;rowheight=30")
        'CellFormat(xlWorkSheet(0), "range=A" & totalLine + 8 & ":" & colExcel(totalKolom) & totalLine + 8 & ";backcolor=192,192,192;isborder=true")

        'CellFormat(xlWorkSheet(0), "range=A:E;columnwidth=clear")

        CellFormat(xlWorkSheet(0), "paper=A4;orientation=potrait;topmargin=20;bottommargin=20;" & _
                       "leftmargin=10;rightmargin=10;titlerow=$1:$6")
        'xlWorkSheet(0).PageSetup.FitToPagesTall = 1
        'xlWorkSheet(0).PageSetup.FitToPagesWide = 1
        SaveExcel()
        DestroyExcel()

        MsgOK("File Disimpan " & pathName)
        OpenExcel(pathName)
    End Sub
    Private Sub btnProses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        cmsPrint.Show(btnPrint, 0, btnPrint.Height)
    End Sub
    Private Sub ReportByDeptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportByDeptToolStripMenuItem.Click
        'MsgOK("1")
        isiTmpAbsen("v.departmentcode as kode, v.departmentname as nama, 'DEPARTMENT' as tipe, ")
        'MsgOK("2")
        ShowReport("ABSENDETAIL", "\Report\ReportAbsenD.rpt", _
                   "select * from tmp_absen order by nama, name, tgl")
        'MsgOK("3")
    End Sub
    Private Sub ReportByBagianToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportByBagianToolStripMenuItem.Click
        isiTmpAbsen("v.bagiancode as kode, v.bagianname as nama, 'BAGIAN' as tipe, ")
        ShowReport("ABSENDETAIL", "\Report\ReportAbsenD.rpt", _
                   "select * from tmp_absen order by nama, name, tgl")
    End Sub

    Private Sub ReportBySBUToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportBySBUToolStripMenuItem.Click
        isiTmpAbsen("v.jabatancode as kode, v.jabatanname as nama, 'JABATAN' as tipe, ")
        ShowReport("ABSENDETAIL", "\Report\ReportAbsenD.rpt", _
                   "select * from tmp_absen order by nama, name, tgl")
    End Sub
#End Region

    
    
    Private Sub SummaryByDeptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SummaryByDeptToolStripMenuItem.Click
        isiTmpAbsen("v.departmentcode as kode, v.departmentname as nama, 'DEPARTMENT' as tipe, ")
        isiTmpAbsenMonthly()
        ShowReport("ABSENSUMMARY", "\Report\ReportAbsens.rpt", _
                   "select * from tmp_absen_monthly order by store, nm_group, spg_name")
    End Sub

    Private Sub SummaryByBagianToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SummaryByBagianToolStripMenuItem.Click
        isiTmpAbsen("v.bagiancode as kode, v.bagianname as nama, 'BAGIAN' as tipe, ")
        isiTmpAbsenMonthly()
        ShowReport("ABSENSUMMARY", "\Report\ReportAbsens.rpt", _
                   "select * from tmp_absen_monthly order by store, nm_group, spg_name")
    End Sub

    Private Sub SummaryBySBUToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SummaryBySBUToolStripMenuItem.Click
        isiTmpAbsen("v.jabatancode as kode, v.jabatanname as nama, 'JABATAN' as tipe, ")
        isiTmpAbsenMonthly()
        ShowReport("ABSENSUMMARY", "\Report\ReportAbsens.rpt", _
                   "select * from tmp_absen_monthly order by store, nm_group, spg_name")
    End Sub

    Private Sub ReportByDeptToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportByDeptToolStripMenuItem2.Click
        isiTmpAbsen("v.departmentcode as kode, v.departmentname as nama, 'DEPARTMENT' as tipe, ")
        isiTmpAbsen2()
        ProcessKehadiran()
    End Sub

    Private Sub ReportByBagianToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportByBagianToolStripMenuItem2.Click
        isiTmpAbsen("v.bagiancode as kode, v.bagianname as nama, 'BAGIAN' as tipe, ")
        isiTmpAbsen2()
        ProcessKehadiran()
    End Sub

    Private Sub ReportBySBUToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportBySBUToolStripMenuItem2.Click
        isiTmpAbsen("v.jabatancode as kode, v.jabatanname as nama, 'JABATAN' as tipe, ")
        isiTmpAbsen2()
        ProcessKehadiran()
    End Sub

    Private Sub ReportTotalKaryawanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportTotalKaryawanToolStripMenuItem.Click
        Dim sd, ed As Date
        sd = dtgen.Value
        ed = dtgen2.Value
        AbsenTotalKaryawan.dt1.Value = sd
        AbsenTotalKaryawan.dt2.Value = ed
        AbsenTotalKaryawan.lblPeriode.Text = "Periode " & Format(sd, "dd-MMM-yyyy") & " s/d " & Format(ed, "dd-MMM-yyyy") & ""
        AbsenTotalKaryawan.ShowDialog()
    End Sub
End Class