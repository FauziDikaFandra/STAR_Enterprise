Public Class SPGSalesForm
    Public ByBrand As Boolean
    Dim ByBrandStr As String

    Dim ds, ds2 As New DataSet
    Dim tglawal, vtgl As String
    Dim TotItm, TotSales, vtotal, tmout As Decimal
    Dim vspg, strSearch, vsql, varsbu, brandP As String
    Dim varx, X, logOrMain As Integer
    Dim ket As Boolean

    Declare Function GetScrollInfo Lib "user32" Alias "GetScrollInfo" _
                    (ByVal hWnd As IntPtr, ByVal n As Integer, ByRef lpScrollInfo As SCROLLINFO) As Integer
    Declare Function SetScrollInfo Lib "user32" Alias "SetScrollInfo" _
                    (ByVal hWnd As IntPtr, ByVal n As Integer, _
    ByRef lpcScrollInfo As SCROLLINFO, ByVal bool As Boolean) As Integer
    Structure SCROLLINFO
        Dim cbSize As Integer
        Dim fMask As Integer
        Dim nMin As Integer
        Dim nMax As Integer
        Dim nPage As Integer
        Dim nPos As Integer
        Dim nTrackPos As Integer
    End Structure
    Private Const SB_HORZ = 0
    Private Const SB_VERT = 1
    Private Const SIF_RANGE = &H1
    Private Const SIF_PAGE = &H2
    Private Const SIF_POS = &H4
    Private Const SIF_ALL = (SIF_RANGE Or SIF_PAGE Or SIF_POS)
    Dim si As SCROLLINFO
    Private Structure LASTINPUTINFO
        Dim cbSize As Int32
        Dim dwTime As Int32
    End Structure
    Private Declare Function GetTickCount Lib "kernel32" () As Int32
    Private Declare Function GetLastInputInfo Lib "user32" (ByRef plii As LASTINPUTINFO) As Boolean
    Private Sub tim_Tick(ByVal sender As Object, ByVal e As EventArgs)
        Dim lii As LASTINPUTINFO
        lii.cbSize = Len(lii)
        GetLastInputInfo(lii)
        If ((GetTickCount() - lii.dwTime) / 1000.0) > 60 Then
            logOrMain = 1
            Me.Close()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        LblTGL.Text = UCase(Format(Now, "ddd, dd MMM yyyy"))
        LblJam.Text = Format(Now, "HH:mm:ss")
    End Sub
    Private Sub SPG_Sales_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        KiosInformasiFORM.Show()
        KiosInformasiFORM.GroupBox1.Focus()
        KiosInformasiFORM.TextBox1.Focus()
    End Sub
    Private Sub SPG_Sales_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub SPG_Sales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button3.Image = Image.FromFile(FolderImage & "go.ico")
        Dim ico As New System.Drawing.Icon(FolderImage & "star.ico") : Me.Icon = ico

        tmout = 0
        Timer1.Enabled = True
        si.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(si)
        si.fMask = SIF_ALL
        Dim x As Integer = GetScrollInfo(ListView1.Handle, SB_VERT, si)
        si.nPos = si.nMax
        x = SetScrollInfo(ListView1.Handle, SB_VERT, si, True)

        SetLv2()
        Label3.Text = UsrID & " - " & UsrName
        Label12.Text = ""

        DateTimePicker1.Value = Format(Now, "yyyy-MM-01")
        DateTimePicker2.Value = Now

        Dim tim As New Timer
        tim.Interval = 2000
        AddHandler tim.Tick, AddressOf tim_Tick
        tim.Start()

        If ByBrand = True Then
            ByBrandStr = " And z.Brand in (select DISTINCT Brand From SPG_Dtl Where spg_id = '" & UsrID & "') "
            Label11.Text = "Ranking Brand Pertanggal"
            Label1.Text = "KIOS INFORMASI RANKING BRAND DEPARTEMEN"
            CheckBox1.Visible = False
        Else
            ByBrandStr = ""
            Label11.Text = "Ranking Penjualan Pertanggal"
            Label1.Text = "KIOS INFORMASI SPG, SPB DAN BA"
            CheckBox1.Visible = True
        End If
        CheckForIllegalCrossThreadCalls = False
        Button3_Click(sender, e)
    End Sub
    Sub SetLv2()
        ListView1.Columns.Add("Ranking", 80, HorizontalAlignment.Center)
        If Bybrand = False Then
            ListView1.Columns.Add("ID", 100, HorizontalAlignment.Right)
            ListView1.Columns.Add("Nama", 220, HorizontalAlignment.Left)
        End If
        ListView1.Columns.Add("Brand", 180, HorizontalAlignment.Left)
        ListView1.Columns.Add("SBU", 170, HorizontalAlignment.Left)
    End Sub
    Sub SetLv()
        ListView1.Columns.Add("Tgl Transaksi", 100, HorizontalAlignment.Center)
        ListView1.Columns.Add("Item", 180, HorizontalAlignment.Left)
        ListView1.Columns.Add("Qty", 40, HorizontalAlignment.Left)
        ListView1.Columns.Add("Harga", 80, HorizontalAlignment.Left)
        ListView1.Columns.Add("Disc %", 70, HorizontalAlignment.Left)
        ListView1.Columns.Add("X Disc", 70, HorizontalAlignment.Left)
        ListView1.Columns.Add("Total", 80, HorizontalAlignment.Left)
        ListView1.Columns.Add("Nomor Struk", 200, HorizontalAlignment.Left)
        ListView2.Columns.Add("Brand", 160, HorizontalAlignment.Left)
        ListView2.Columns.Add("Qty", 40, HorizontalAlignment.Left)
        ListView2.Columns.Add("Total", 100, HorizontalAlignment.Left)
    End Sub
    Sub settgl()
        tglawal = Format(DateTimePicker1.Value, "yyyy-MM-dd")
        vtgl = Format(DateTimePicker2.Value, "yyyy-MM-dd")
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'showranking()
        If ByBrand = True Then
            Label11.Text = "Ranking Brand Per-Departemen Periode (" + Format(DateTimePicker1.Value, "dd MMM yyyy") + " s.d " + Format(DateTimePicker2.Value, "dd MMM yyyy") + ")"
            Label12.Text = ""
        Else
            Label11.Text = "Ranking SPG, SPB Dan BA Periode (" + Format(DateTimePicker1.Value, "dd MMM yyyy") + " s.d " + Format(DateTimePicker2.Value, "dd MMM yyyy") + ")"
        End If

        Label9.Visible = True
        ProgressBar1.Value = 0
        ProgressBar1.Visible = True
        ListView1.Items.Clear()
        ListView2.Items.Clear()
        ListView1.Clear()
        Button3.Enabled = False
        GroupBox1.Enabled = False
        BackgroundWorker1.WorkerReportsProgress = True
        BackgroundWorker1.WorkerSupportsCancellation = True
        BackgroundWorker1.RunWorkerAsync()
    End Sub
    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        showranking()
    End Sub
    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Button3.Enabled = True
        GroupBox1.Enabled = True
        ProgressBar1.Visible = False
        Label9.Visible = False
    End Sub
    Sub showranking()
        ListView1.Items.Clear()
        ListView2.Items.Clear()
        ListView1.Clear()
        settgl()
        SetLv2()
        Dim fil As String
        fil = " And z.sbu='" & SbuCode & "' "
        If ByBrand = False Then
            If CheckBox1.Checked = True Then
                ByBrandStr = ""
            Else
                ByBrandStr = " And z.Brand in " & vbCrLf & _
                             "  (   Select distinct brand from item_master where substring(burui,2,2) in " & vbCrLf & _
                             "      (   select distinct substring(burui,2,2) from item_master where " & vbCrLf & _
                             "          dp2 In (select DISTINCT SBU From pos_server.dbo.SPG_Dtl Where spg_id='" & UsrID & "') and " & vbCrLf & _
                             "          Brand in (select DISTINCT Brand From pos_server.dbo.SPG_Dtl Where spg_id='" & UsrID & "') " & vbCrLf & _
                             "      ) And dp2 In (select DISTINCT SBU From pos_server.dbo.SPG_Dtl Where spg_id='" & UsrID & "') " & vbCrLf & _
                             "  ) "
            End If
        Else
            ByBrandStr = ""
        End If

        ket = True
        vsql = IsiQuery(fil)
        'Dbg("satu : " & vsql)
        If ByBrand = True Then
            Setdata2(vsql)
        Else
            Setdata(vsql)
        End If

        ket = False
        vsql = IsiQuery(fil)
        'Dbg("dua : " & vsql)
        If ByBrand = True Then
            Setdata2(vsql)
        Else
            Setdata(vsql)
        End If

        Dim endlist As Integer
        If ByBrand = False Then
            ListView2.Visible = False
            For Each itm In ListView1.Items ' search for all list item on listview
                If itm.Text <> "" Then
                    endlist = itm.Text
                    If itm.Text = strSearch Then ' assign if item = strsearch
                        X = itm.Index ' get the index of founded item
                        itm.ForeColor = System.Drawing.Color.DarkRed
                        itm.Font = New System.Drawing.Font("Tahoma", 11.25, System.Drawing.FontStyle.Bold)
                        ListView1.Focus() ' set focus on listview
                    End If
                End If
            Next
        Else
            Dim qq As New VQuery
            ListView2.Visible = False
            brandP = ""
            qq.Query("Select * from SPG_dtl where spg_id = '" & UsrID & "' order by brand", _
                     "spg_id,brand", DB_POS)
            'MsgOK(qq.RecordCount)
            For Each itm As ListViewItem In ListView1.Items ' search for all list item on listview
                If itm.Text <> "" Then
                    endlist = itm.Text
                    'MsgOK("index " & itm.Index + 1 & ", " & LCase(itm.SubItems(1).Text))
                    'MsgOK(qq.RecordCount)
                    'MsgOK(qq.SQL)
                    qq.FirstRecord()
                    While Not qq.EOF
                        'MsgOK("tes : " & LCase(qq.GetField("brand")))
                        If LCase(itm.SubItems(1).Text.Trim) = LCase(qq.GetField("brand")) Then
                            'MsgOK("1")
                            X = itm.Index + 1
                            itm.ForeColor = System.Drawing.Color.DarkRed
                            itm.Font = New System.Drawing.Font("Tahoma", 11.25, System.Drawing.FontStyle.Bold)
                            ListView1.Focus()
                            If brandP <> "" Then
                                brandP &= " dan " & X
                            Else
                                brandP = X
                            End If
                        End If
                        qq.NextRecord()
                    End While
                    qq.FirstRecord()
                    strSearch = X
                End If
            Next
            Label8.Text = brandP
        End If

        ListView1.FullRowSelect = True ' full row selected
        If strSearch <> "" Then
            If ByBrand = True Then
                If brandP <> "" Then
                    Label12.Text = "Brand kamu saat ini di peringkat ke"
                Else
                    'Label12.Text = "Brand kamu belum mempunyai transaksi pada periode ini"
                    Label12.Text = "Brand kamu belum mempunyai transaksi"
                End If
            Else
                Label12.Text = "Saat ini kamu ada di peringkat ke "
                Label8.Text = strSearch & " dari " & endlist
            End If

            If CInt(strSearch) > 10 Then
                PictureBox1.ImageLocation = FolderImage & "aaa.jpg"
            Else
                PictureBox1.ImageLocation = FolderImage & "BBB.jpg"
            End If
        Else
            Label12.Text = "Kamu belum mempunyai transaksi penjualan"
            PictureBox1.ImageLocation = FolderImage & "aaa.jpg"
        End If
        Label8.Left = Label12.Left + Label12.Width
    End Sub
    Sub showsales()
        Label11.Text = "Penjualan Per-Tanggal (" + Format(DateTimePicker1.Value, "dd MMM yy") + " s.d " + Format(DateTimePicker2.Value, "dd MMM yy") + ")"
        'Label12.Text = "Per-Brand (" + Format(DateTimePicker1.Value, "dd MMM yy") + " s.d " + Format(DateTimePicker2.Value, "dd MMM yy") + ")"
        TotItm = 0
        TotSales = 0
        ListView2.Visible = True
        ListView1.Items.Clear()
        ListView2.Items.Clear()
        ListView1.Clear()
        ListView2.Clear()
        SetLv()
        settgl()
        ds = getSqldb("select * from (select b.transaction_date, a.item_description, isnull(sum(a.qty),0) as qty, a.price, a.discount_percentage, a.extradisc_amt, isnull(sum(a.net_price),0) as net_price, a.transaction_number " & _
            "from pos_server_history.dbo.sales_transaction_details a inner join pos_server_history.dbo.sales_transactions b on a.transaction_number = b.transaction_number " & _
            "inner join pos_server.dbo.spg c on a.flag_paket_discount = c.spg_id inner join item_master d on a.plu = d.plu where d.branch_id = left(b.transaction_number,4) and a.flag_paket_discount = '" & UsrID & "' " & _
            "and transaction_date >= '" & tglawal & "' and transaction_date <= '" & vtgl & "' and d.class <> 'zzz' " & _
            "and b.status = '00' group by d.brand, b.transaction_date, a.transaction_number, a.item_description, a.price, a.discount_percentage, a.extradisc_amt, a.qty, a.net_price " & _
            "Union select b.transaction_date, a.item_description, isnull(sum(a.qty),0) as qty, isnull(sum(a.net_price),0) as net_price , a.price, a.discount_percentage, a.extradisc_amt, a.transaction_number " & _
            "from pos_server.dbo.sales_transaction_details a inner join pos_server.dbo.sales_transactions b on a.transaction_number = b.transaction_number " & _
            "inner join pos_server.dbo.spg c on a.flag_paket_discount = c.spg_id inner join item_master d on a.plu = d.plu " & _
            "where d.branch_id = left(b.transaction_number,4) and a.flag_paket_discount = '" & UsrID & "' and transaction_date >= '" & tglawal & "' and transaction_date <= '" & vtgl & "'  and d.class <> 'zzz' " & _
            "and b.status = '00' group by b.transaction_date, a.transaction_number, a.item_description, a.price, a.discount_percentage, a.extradisc_amt, a.qty, a.net_price ) a where net_price > 0 order by transaction_date, transaction_number")
        ListView1.Items.Clear()
        ListView2.Items.Clear()
        If ds.Tables(0).Rows.Count > 0 Then
            For Each ro As DataRow In ds.Tables(0).Rows
                Dim str(7) As String
                Dim itm As ListViewItem
                str(0) = Format(CDate(ro(0)), "dd MMM yyyy")
                str(1) = ro(1)
                TotItm += ro(2)
                str(2) = CDec(ro(2)).ToString("N0")
                str(3) = CDec(ro(3)).ToString("N0")
                str(4) = CDec(ro(4)).ToString("N0")
                str(5) = CDec(ro(5)).ToString("N0")
                str(6) = CDec(ro(6)).ToString("N0")
                TotSales += ro(6)
                str(7) = ro(7)
                itm = New ListViewItem(str)
                ListView1.Items.Add(itm)
            Next
        End If
        ds2 = getSqldb("select brand,class,sum(qty) as qty,sum(net_price) as total from (select d.brand,d.class,b.transaction_date, a.item_description, isnull(sum(a.qty),0) as qty, a.price, a.discount_percentage, a.extradisc_amt, isnull(sum(a.net_price),0) as net_price, a.transaction_number " & _
            "from pos_server_history.dbo.sales_transaction_details a inner join pos_server_history.dbo.sales_transactions b on a.transaction_number = b.transaction_number " & _
            "inner join pos_server.dbo.spg c on a.flag_paket_discount = c.spg_id inner join item_master d on a.plu = d.plu where d.branch_id = left(b.transaction_number,4) and a.flag_paket_discount = '" & UsrID & "' " & _
            "and transaction_date >= '" & tglawal & "' and transaction_date <= '" & vtgl & "' and d.class <> 'zzz' " & _
            "and b.status = '00' group by d.brand, b.transaction_date, a.transaction_number, a.item_description, a.price, a.discount_percentage, a.extradisc_amt, a.qty, a.net_price, d.brand,d.class " & _
            "Union select d.brand,d.class,b.transaction_date, a.item_description, isnull(sum(a.qty),0) as qty, isnull(sum(a.net_price),0) as net_price , a.price, a.discount_percentage, a.extradisc_amt, a.transaction_number " & _
            "from pos_server.dbo.sales_transaction_details a inner join pos_server.dbo.sales_transactions b on a.transaction_number = b.transaction_number " & _
            "inner join pos_server.dbo.spg c on a.flag_paket_discount = c.spg_id inner join item_master d on a.plu = d.plu " & _
            "where d.branch_id = left(b.transaction_number,4) and a.flag_paket_discount = '" & UsrID & "' and transaction_date >= '" & tglawal & "' and transaction_date <= '" & vtgl & "'  and d.class <> 'zzz' " & _
            "and b.status = '00' group by b.transaction_date, a.transaction_number, a.item_description, a.price, a.discount_percentage, a.extradisc_amt, a.qty, a.net_price,d.brand,d.class ) a where net_price > 0 group by brand, class order by brand")
        If ds2.Tables(0).Rows.Count > 0 Then
            For Each ro As DataRow In ds2.Tables(0).Rows
                Dim str(3) As String
                Dim itm As ListViewItem
                str(0) = ro(0)
                str(1) = CDec(ro(2)).ToString("N0")
                str(2) = CDec(ro(3)).ToString("N0")
                itm = New ListViewItem(str)
                ListView2.Items.Add(itm)
            Next
        End If
        'Label8.Text = "Total Item : " & TotItm.ToString("N0")
        'Label9.Text = "Total Sales : " & TotSales.ToString("N0")
    End Sub

    

    Function IsiQuery(ByVal prm As String) As String
        Dim hasil As String = ""
        If ByBrand = True Then
            hasil = "select sum(a.gtotal) as Total,a.brand,a.sbu " & vbCrLf & _
                   "from ( " & vbCrLf & _
                   "        select z.brand, z.sbu, " & vbCrLf & _
                   "        (   select isnull(sum(a.net_price),0) as total " & vbCrLf & _
                   "            from pos_server_history.dbo.sales_transaction_details a " & vbCrLf & _
                   "            inner join pos_server_history.dbo.sales_transactions b on a.transaction_number = b.transaction_number " & vbCrLf & _
                   "            inner join pos_server.dbo.spg c on a.flag_paket_discount = c.spg_id " & vbCrLf & _
                   "            where b.status = '00' and convert(varchar(10), transaction_date, 20) " & vbCrLf & _
                   "            between '" & tglawal & "' and '" & vtgl & "' and c.spg_id = d.spg_id " & vbCrLf & _
                   "        )  as gtotal " & vbCrLf & _
                   "        from pos_server.dbo.spg d " & vbCrLf & _
                   "        inner join pos_server.dbo.spg_dtl z on d.spg_id = z.spg_id " & vbCrLf & _
                   "        where d.spg_id <> '0' and d.spg_name not like '%promo%' And z.Brand in " & vbCrLf & _
                   "        (   Select distinct brand from item_master where substring(burui,2,2) in " & vbCrLf & _
                   "            ( select distinct substring(burui,2,2) from item_master where dp2 In " & vbCrLf & _
                   "                (select DISTINCT SBU From pos_server.dbo.SPG_Dtl Where spg_id='" & UsrID & "') and " & vbCrLf & _
                   "              Brand in (select DISTINCT Brand From pos_server.dbo.SPG_Dtl Where spg_id='" & UsrID & "')" & vbCrLf & _
                   "            ) And dp2 In (select DISTINCT SBU From pos_server.dbo.SPG_Dtl Where spg_id='" & UsrID & "')" & vbCrLf & _
                   "        ) " & prm & ByBrandStr & " " & vbCrLf & _
                   "        group by d.spg_id,z.brand,z.sbu " & vbCrLf & _
                   "     ) as a " & vbCrLf & _
                   "group by a.brand,a.sbu order by Total desc"
            'Dbg(hasil)
            Return hasil
            Exit Function
        End If
        If ket = True Then
            hasil = "select a.spg_id, a.spg_name, z.sbu, z.class, z.brand, a.gtotal as total from " & vbCrLf & _
                   "(   select d.spg_id, d.spg_name, " & vbCrLf & _
                   "    (   select isnull(sum(a.net_price),0) as total " & vbCrLf & _
                   "        from pos_server_history.dbo.sales_transaction_details a " & vbCrLf & _
                   "        inner join pos_server_history.dbo.sales_transactions b on a.transaction_number = b.transaction_number " & vbCrLf & _
                   "        inner join pos_server.dbo.spg c on a.flag_paket_discount = c.spg_id " & vbCrLf & _
                   "        where b.status = '00' and " & vbCrLf & _
                   "        convert(varchar(10), transaction_date,20) between '" & tglawal & "' and '" & vtgl & "' " & vbCrLf & _
                   "        and c.spg_id = d.spg_id " & vbCrLf & _
                   "    ) " & vbCrLf & _
                   "    + " & vbCrLf & _
                   "    (   select isnull(sum(a.net_price),0) as total " & vbCrLf & _
                   "        from pos_server.dbo.sales_transaction_details a " & vbCrLf & _
                   "        inner join pos_server.dbo.sales_transactions b on a.transaction_number = b.transaction_number " & vbCrLf & _
                   "        inner join pos_server.dbo.spg c on a.flag_paket_discount = c.spg_id " & vbCrLf & _
                   "        where b.status = '00' and " & vbCrLf & _
                   "        convert(varchar(10), transaction_date, 20)='" & vtgl & "' and c.spg_id = d.spg_id " & vbCrLf & _
                   "    ) as gtotal " & vbCrLf & _
                   "    from pos_server.dbo.spg d where d.spg_id <> '0' and d.spg_name not like '%promo%' " & vbCrLf & _
                   "    group by d.spg_id, d.spg_name " & vbCrLf & _
                   ") a inner join pos_server.dbo.spg_dtl z on a.spg_id = z.spg_id " & vbCrLf & _
                   "where a.gtotal > 0 " & prm & ByBrandStr & " " & vbCrLf & _
                   "order by a.gtotal desc"
        Else
            hasil = "select a.spg_id, a.spg_name, z.sbu, z.class, z.brand, a.gtotal as total " & vbCrLf & _
                   "from ( " & vbCrLf & _
                   "        select d.spg_id, d.spg_name, " & vbCrLf & _
                   "        (   select isnull(sum(a.net_price),0) as total " & vbCrLf & _
                   "            from pos_server_history.dbo.sales_transaction_details a " & vbCrLf & _
                   "            inner join pos_server_history.dbo.sales_transactions b on a.transaction_number = b.transaction_number " & vbCrLf & _
                   "            inner join pos_server.dbo.spg c on a.flag_paket_discount = c.spg_id " & vbCrLf & _
                   "            where b.status = '00' and " & vbCrLf & _
                   "            convert(varchar(10), transaction_date, 20) between '" & tglawal & "' and '" & vtgl & "' " & vbCrLf & _
                   "            and c.spg_id = d.spg_id " & vbCrLf & _
                   "        ) " & vbCrLf & _
                   "        + " & vbCrLf & _
                   "        (   select isnull(sum(a.net_price),0) as total " & vbCrLf & _
                   "            from pos_server.dbo.sales_transaction_details a " & vbCrLf & _
                   "            inner join pos_server.dbo.sales_transactions b on a.transaction_number = b.transaction_number " & vbCrLf & _
                   "            inner join pos_server.dbo.spg c on a.flag_paket_discount = c.spg_id " & vbCrLf & _
                   "            where b.status = '00' and " & vbCrLf & _
                   "            convert(varchar(10), transaction_date, 20)='" & vtgl & "' " & vbCrLf & _
                   "            and c.spg_id = d.spg_id " & vbCrLf & _
                   "        ) as gtotal " & vbCrLf & _
                   "        from pos_server.dbo.spg d where d.spg_id <> '0' and d.spg_name not like '%promo%' " & vbCrLf & _
                   "        group by d.spg_id, d.spg_name " & vbCrLf & _
                   "    ) a " & vbCrLf & _
                   "inner join pos_server.dbo.spg_dtl z on a.spg_id = z.spg_id " & vbCrLf & _
                   "where a.gtotal > 0 " & prm & ByBrandStr & " " & vbCrLf & _
                   "order by a.gtotal desc"
        End If
        Return hasil
    End Function


    Sub Setdata(ByVal SQL As String)
        Dim i As Integer
        Dim vq As New VQuery
        Dim Prg As Decimal
        vq.Query(SQL, "spg_id", DB_POSH)
        'hasil = "select a.spg_id, a.spg_name, z.sbu, z.class, z.brand, a.gtotal " & vbCrLf & _
        varx = 0
        If ket = True Then
            If vq.RecordCount > 0 Then
                vspg = ""
                i = 0
                X = 0
                strSearch = ""
                While Not vq.EOF
                    X += 1
                    If CDbl(vq.GetField("total")) <> 0 Then
                        If vspg = vq.GetField("spg_id") Then
                            If vq.GetField("spg_id") = UsrID Then
                                If strSearch = "" Then strSearch = i
                                vtotal = vtotal + vq.GetField("total")
                            End If

                        Else
                            i = i + 1
                            If vq.GetField("spg_id") = UsrID Then
                                If strSearch = "" Then strSearch = i
                                vtotal = vtotal + vq.GetField("total")
                            End If
                            If i = 100 Then varx = X
                        End If
                        vspg = vq.GetField("spg_id")
                    End If

                    Prg += 100 / vq.RecordCount
                    BackgroundWorker1.ReportProgress(Int(Prg))

                    vq.NextRecord()
                End While
            End If
        Else
            If vq.RecordCount > 0 Then
                vspg = ""
                i = 0
                X = 0
                vtotal = 0
                While Not vq.EOF
                    X += 1
                    Dim str(5) As String
                    Dim itm As ListViewItem
                    If vq.GetField("total") <> 0 Then
                        If vspg = vq.GetField("spg_id") Then
                            'vq.GetField("")
                            str(0) = ""
                            str(1) = ""
                            str(2) = ""
                            str(3) = vq.GetField("brand")
                            If UCase(Trim(vq.GetField("sbu"))) = "HH" Then varsbu = "Home"
                            If UCase(Trim(vq.GetField("sbu"))) = "MD" Then varsbu = "Men's Wear"
                            If UCase(Trim(vq.GetField("sbu"))) = "LD" Then varsbu = "Ladies Wear"
                            If UCase(Trim(vq.GetField("sbu"))) = "LA" Then varsbu = "Ladies Sundries"
                            If UCase(Trim(vq.GetField("sbu"))) = "SC" Then varsbu = "Sports Center"
                            If UCase(Trim(vq.GetField("sbu"))) = "CH" Then varsbu = "Children"
                            str(4) = varsbu

                            If vq.GetField("spg_id") = UsrID Then
                                vtotal = vtotal + vq.GetField("total")
                            End If
                            itm = New ListViewItem(str)
                            ListView1.Items.Add(itm)
                        Else
                            i = i + 1
                            str(0) = i
                            str(1) = vq.GetField("spg_id")
                            str(2) = vq.GetField("spg_name")
                            str(3) = vq.GetField("brand")

                            If UCase(Trim(vq.GetField("sbu"))) = "HH" Then varsbu = "Home"
                            If UCase(Trim(vq.GetField("sbu"))) = "MD" Then varsbu = "Men's Wear"
                            If UCase(Trim(vq.GetField("sbu"))) = "LD" Then varsbu = "Ladies Wear"
                            If UCase(Trim(vq.GetField("sbu"))) = "LA" Then varsbu = "Ladies Sundries"
                            If UCase(Trim(vq.GetField("sbu"))) = "SC" Then varsbu = "Sports Center"
                            If UCase(Trim(vq.GetField("sbu"))) = "CH" Then varsbu = "Children"
                            str(4) = varsbu
                            If vq.GetField("spg_id") = UsrID Then
                                vtotal = vtotal + vq.GetField("total")
                            End If
                            itm = New ListViewItem(str)
                            ListView1.Items.Add(itm)
                            If vq.GetField("spg_id") = UsrID Then
                                vtotal = vtotal + vq.GetField("total")
                            End If
                        End If
                        vspg = vq.GetField("spg_id")

                    End If

                    Prg += 100 / vq.RecordCount
                    BackgroundWorker1.ReportProgress(Int(Prg))

                    vq.NextRecord()
                End While
            End If
        End If

    End Sub

    Sub Setdata2(ByVal SQL As String)
        Dim i As Integer
        Dim Prg As Decimal
        varx = 0
        If ket = True Then

        Else
            Dim vq As New VQuery
            vq.Query(SQL, "brand", DB_POSH)
            If vq.RecordCount > 0 Then
                'vspg = ""
                i = 0
                X = 0
                vtotal = 0
                While Not vq.EOF
                    X += 1
                    Dim str(3) As String
                    Dim itm As ListViewItem
                    If CInt(vq.GetField("total")) <> 0 Then
                        i = i + 1
                        str(0) = i
                        str(1) = vq.GetField("brand")
                        str(2) = vq.GetField("sbu")

                        If UCase(Trim(vq.GetField("sbu"))) = "HH" Then varsbu = "Home"
                        If UCase(Trim(vq.GetField("sbu"))) = "MD" Then varsbu = "Men's Wear"
                        If UCase(Trim(vq.GetField("sbu"))) = "LD" Then varsbu = "Ladies Wear"
                        If UCase(Trim(vq.GetField("sbu"))) = "LA" Then varsbu = "Ladies Sundries"
                        If UCase(Trim(vq.GetField("sbu"))) = "SC" Then varsbu = "Sports Center"
                        If UCase(Trim(vq.GetField("sbu"))) = "CH" Then varsbu = "Children"
                        str(2) = varsbu

                        itm = New ListViewItem(str)
                        ListView1.Items.Add(itm)
                        'vspg = rs(0)
                    End If

                    Prg += 100 / vq.RecordCount
                    BackgroundWorker1.ReportProgress(Int(Prg))

                    vq.NextRecord()
                End While
            End If
            vq.Dispose()
        End If
    End Sub

End Class