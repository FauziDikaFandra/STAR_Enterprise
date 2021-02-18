Public Class AbsenTotalKaryawan

    Private Sub FrmRptTotal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim ico As New System.Drawing.Icon(LokasiICOFile) : Me.Icon = ico
        BtnPrint.Image = Image.FromFile(FolderImage & "print16.png")

        cmbColumn.Items.Clear()
        cmbColumn.Items.Add("Department")
        cmbColumn.Items.Add("Bagian")
        cmbColumn.Items.Add("Jabatan")
        cmbColumn.Items.Add("Jenis Kelamin")
        'cmbColumn.Items.Add("Status Karyawan")
        cmbColumn.Items.Add("Tahun Masuk")
        cmbColumn.Items.Add("Bulan Masuk")
        cmbColumn.Items.Add("Tahun Keluar")
        cmbColumn.Items.Add("Bulan Keluar")

        cmbRow.Items.Clear()
        cmbRow.Items.Add("Department")
        cmbRow.Items.Add("Bagian")
        cmbRow.Items.Add("Jabatan")
        cmbRow.Items.Add("Jenis Kelamin")
        'cmbRow.Items.Add("Status Karyawan")
        cmbRow.Items.Add("Tahun Masuk")
        cmbRow.Items.Add("Bulan Masuk")
        cmbRow.Items.Add("Tahun Keluar")
        cmbRow.Items.Add("Bulan Keluar")
    End Sub
    Sub isiTmpTotal()
        Dim group1, group2, s, kode1, nama1, kode2, nama2, kol, bar As String
        kol = LCase(cmbColumn.Text.Trim)
        bar = LCase(cmbRow.Text.Trim)
        kode1 = "a.kd_bagian"
        nama1 = "b.nm_bagian"
        kode2 = "a.tipe"
        nama2 = "a.tipe"
        group1 = "a.kd_bagian, b.nm_bagian, "
        group2 = "a.tipe"
        Select Case kol
            Case "department"
                kode1 = "coalesce(d.code, '')"
                nama1 = "coalesce(d.name, '')"
                group1 = "d.code, d.name, "
            Case "bagian"
                kode1 = "coalesce(b.code, '')"
                nama1 = "coalesce(b.name, '')"
                group1 = "b.code, b.name, "
            Case "jabatan"
                kode1 = "coalesce(j.code, '')"
                nama1 = "coalesce(j.name, '')"
                group1 = "j.code, j.name, "
            Case "jenis kelamin"
                kode1 = "case a.gender when 'Laki-Laki' then 'L' when 'Perempuan' THEN 'P' ELSE '' end"
                nama1 = "coalesce(a.gender, '')"
                group1 = "a.gender, "
            Case "tahun masuk"
                kode1 = "case when year(joindate) <= 2006 then 0 else year(joindate) end"
                nama1 = "case when year(joindate) <= 2006 then 0 else year(joindate) end"
                group1 = "case when year(joindate) <= 2006 then 0 else year(joindate) end, "
            Case "tahun keluar"
                kode1 = "case when year(resigndate) <= 2006 then 0 else year(resigndate) end"
                nama1 = "case when year(resigndate) <= 2006 then 0 else year(resigndate) end"
                group1 = "case when year(resigndate) <= 2006 then 0 else year(resigndate) end, "
            Case "bulan masuk"
                kode1 = "case when coalesce(convert(varchar(7), joindate, 102), '') <= '2006.12' then '' " & vbCrLf & _
                        "ELSE coalesce(convert(varchar(7), joindate, 102), '') end"
                nama1 = kode1
                group1 = kode1 & ", "
            Case "bulan keluar"
                kode1 = "case when coalesce(convert(varchar(7), resigndate, 102), '') <= '2006.12' then '' " & vbCrLf & _
                        "ELSE coalesce(convert(varchar(7), resigndate, 102), '') end"
                nama1 = kode1
                group1 = kode1 & ", "
        End Select
        Select Case bar
            Case "department"
                kode2 = "coalesce(d.code, '')"
                nama2 = "coalesce(d.name, '')"
                group2 = "d.code, d.name "
            Case "bagian"
                kode2 = "coalesce(b.code, '')"
                nama2 = "coalesce(b.name, '')"
                group2 = "b.code, b.name "
            Case "jabatan"
                kode2 = "coalesce(j.code, '')"
                nama2 = "coalesce(j.name, '')"
                group2 = "j.code, j.name "
            Case "jenis kelamin"
                kode2 = "case a.gender when 'Laki-Laki' then 'L' when 'Perempuan' THEN 'P' ELSE '' end"
                nama2 = "coalesce(a.gender, '')"
                group2 = "a.gender, "
            Case "tahun masuk"
                kode2 = "case when year(joindate) <= 2006 then 0 else year(joindate) end"
                nama2 = "case when year(joindate) <= 2006 then 0 else year(joindate) end"
                group2 = "case when year(joindate) <= 2006 then 0 else year(joindate) end "
            Case "tahun keluar"
                kode2 = "case when year(resigndate) <= 2006 then 0 else year(resigndate) end"
                nama2 = "case when year(resigndate) <= 2006 then 0 else year(resigndate) end"
                group2 = "case when year(resigndate) <= 2006 then 0 else year(resigndate) end "
            Case "bulan masuk"
                kode2 = "case when coalesce(convert(varchar(7), joindate, 102), '') <= '2006.12' then '' " & vbCrLf & _
                        "ELSE coalesce(convert(varchar(7), joindate, 102), '') end"
                nama2 = kode2
                group2 = kode2 & " "
            Case "bulan keluar"
                kode2 = "case when coalesce(convert(varchar(7), resigndate, 102), '') <= '2006.12' then '' " & vbCrLf & _
                        "ELSE coalesce(convert(varchar(7), resigndate, 102), '') end"
                nama2 = kode2
                group2 = kode2 & " "
        End Select

        ExecQuery("IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[tmp_total]') " & vbCrLf & _
                  "AND OBJECTPROPERTY(id, N'IsUserTable') = 1) " & vbCrLf & _
                  "DROP TABLE [dbo].[tmp_total]")
        s = "select " & kode1 & " as kode1, " & nama1 & " as nama1, " & vbCrLf & _
            " " & kode2 & " as kode2, " & nama2 & " as nama2, " & vbCrLf & _
            " count(a.employee_id) as total, '" & Format(dt1.Value, "yyyy-MM-dd") & "' as startdate, " & vbCrLf & _
            " '" & Format(dt2.Value, "yyyy-MM-dd") & "' as enddate " & vbCrLf & _
            "into tmp_total " & vbCrLf & _
            "from m_employee a " & vbCrLf & _
            "left join m_department d on a.department_id=d.department_id " & vbCrLf & _
            "left join m_bagian b on a.bagian_id=b.bagian_id " & vbCrLf & _
            "left join m_jabatan j on a.jabatan_id=j.jabatan_id " & vbCrLf & _
            "where a.employee_id in " & vbCrLf & _
            "( " & vbCrLf & _
            "   select employee_id from t_finger " & vbCrLf & _
            "   where tgl>='" & Format(dt1.Value, "yyyy-MM-dd") & "' and " & vbCrLf & _
            "   tgl<='" & Format(dt2.Value, "yyyy-MM-dd") & "' " & vbCrLf & _
            "    group by employee_id " & vbCrLf & _
            ") " & vbCrLf & _
            "group by " & group1 & group2
        Dbg(s)
        ExecQuery(s)
        ''MsgOK("1")
        'ExecQuery("update a " & vbCrLf & _
        '          "set a.kode1 = b.kode " & vbCrLf & _
        '          "from tmp_total a inner join ( select * from tbl_kode where tipe='" & kol & "' ) b " & vbCrLf & _
        '          "on a.nama1=b.nama")
        ''MsgOK("2")
        'ExecQuery("update a " & vbCrLf & _
        '          "set a.kode2 = b.kode " & vbCrLf & _
        '          "from tmp_total a inner join ( select * from tbl_kode where tipe='" & bar & "' ) b " & vbCrLf & _
        '          "on a.nama2=b.nama")
        ''MsgOK("3")
    End Sub
    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        isiTmpTotal()
        showReport("REPORTTOTAL", "\REPORT\SUMTOTAL.rpt", _
                   "select * from tmp_total order by kode1, kode2")
    End Sub
End Class