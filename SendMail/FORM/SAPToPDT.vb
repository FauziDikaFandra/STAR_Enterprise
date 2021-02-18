Imports System.Data.SQLite
Imports System.IO
Public Class SAPToPDT
    Dim vtglopstr, vawal, vakhir, vprev, vtgl, vnamafile As String
    Dim vtglop As Date
    Dim ds, ds2 As New DataSet
    Dim Prg As Decimal = 0

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ConnectServer()
        m_Sqlconn = "Data Source=" & m_ServerName & ";" & "Initial Catalog=" & m_DBName & ";" & "User ID=" & m_UserName & ";" & "Password=" & m_Password & ";"
        m_Sqlconn2 = "Data Source=" & m_ServerName2 & ";" & "Initial Catalog=" & m_DBName2 & ";" & "User ID=" & m_UserName2 & ";" & "Password=" & m_Password2 & ";"
        CheckForIllegalCrossThreadCalls = False
        cmb(ComboBox1, "select WhsName as Code, WhsName + ' - ' + WhsCode as WhsName  from OWHS Where WhsCode <>'01' and WhsCode not in ('DC01','HO01') Order by WhsCode", "Code", "WhsName", 1)
        'cmb(ComboBox2, "select Name,U_Description from dbo.[@PRODUCT_CATEGORY] where  not isnumeric(Name) = 1 Order By name", "Name", "U_Description", 1)
        'cmb_jenis()
        isiCboBrand()
        Try
            If Directory.Exists(masterFile) = False Then Directory.CreateDirectory(masterFile)
            If Directory.Exists(ScanFile) = False Then Directory.CreateDirectory(ScanFile)
            If Directory.Exists(ExcelFile) = False Then Directory.CreateDirectory(ExcelFile)
        Catch ex As Exception
        End Try

        DateTimePicker1.Value = Now

        lblCOM.Text = "COM Port : "
        For i As Integer = 0 To My.Computer.Ports.SerialPortNames.Count - 1
            lblCOM.Text = lblCOM.Text & My.Computer.Ports.SerialPortNames(i) & ", "
            'CboCOM.Items.Add(My.Computer.Ports.SerialPortNames(i))
        Next
        lblCOM.Text = Mid(lblCOM.Text, 1, Len(lblCOM.Text) - 2)

        GbBrand.Visible = False
        dg1.Font = LblFont.Font
        dg2.Font = LblFont.Font
        isiDatagrid()
    End Sub
    Sub isiDatagrid()
        Dim dss1, dss2 As DataSet
        dss1 = QueryLITE("select sbu as brand, count(*) as qty from m_item group by sbu order by sbu")
        dg1.AutoGenerateColumns = False
        dg1.DataSource = dss1.Tables(0)

        dss2 = QueryLITE("select * from m_item order by sbu, plu")
        dg2.AutoGenerateColumns = False
        dg2.DataSource = dss2.Tables(0)
        NavSource2.DataSource = dss2.Tables(0)
        NavSource2.Filter = ""
        'MsgOK(dss1.Tables(0).Rows.Count)
        'MsgOK(dss2.Tables(0).Rows.Count)
        'clearDataSet(dss1)
        'clearDataSet(dss2)
        FormatColumnGrid(dg2, 4, "number")
        dg1.RowsDefaultCellStyle.BackColor = Color.White
        dg1.AlternatingRowsDefaultCellStyle.BackColor = Color.Bisque
        dg2.RowsDefaultCellStyle.BackColor = Color.White
        dg2.AlternatingRowsDefaultCellStyle.BackColor = Color.Bisque
    End Sub
    Sub isiCboBrand()
        CboBrand.Items.Clear()
        Dim dsc As DataSet
        dsc = QuerySO("select 0 as choose, brand from brand order by brand")
        For Each ro As DataRow In dsc.Tables(0).Rows
            CboBrand.Items.Add(ro(0).ToString.Trim)
        Next

        dgBrand.AutoGenerateColumns = False
        dgBrand.DataSource = dsc.Tables(0)
        NavBrand.DataSource = dsc.Tables(0)
        NavBrand.Filter = ""
        'dsc.Dispose()
    End Sub
    Sub cmbjenis()
        Dim LineOfText As String
        Dim i As Integer
        Dim aryTextFile() As String

        LineOfText = "kode, desc"

        aryTextFile = LineOfText.Split(",")

        For i = 0 To UBound(aryTextFile)

            MsgBox(aryTextFile(i))

        Next

    End Sub

    Sub cmb_jenis()
        Dim FILE_NAME As String = "Jenis.txt"
        Dim objReader As New System.IO.StreamReader(FILE_NAME)
        Dim LineOfText As String = Nothing
        Dim Aryline(1) As String
        Dim FirstList As String
        Dim SecondList As String
        Dim c As New ArrayList
        'read line by line
        Do While objReader.Peek() <> -1
            LineOfText = objReader.ReadLine() & vbNewLine

            ' split line of text at "=" sign
            Aryline = LineOfText.Split(",")

            'Assign the parts to a variable
            FirstList = Aryline(0)
            SecondList = Aryline(1)

            ' sent split Lists to listboxes
            c.Add(New CCombo(FirstList, SecondList))


        Loop
        With ComboBox2
            .DataSource = c
            .DisplayMember = "Number_Name"
            .ValueMember = "ID"
        End With
        'Close the Reader
        objReader.Close()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgConfirm("Data Master Akan Dibuat Ulang" & vbCrLf & _
                      "Ingin Tetap Lanjutkan") <> vbYes Then Exit Sub

        vtglop = DateTimePicker1.Value.AddDays(-1)
        vtglopstr = Format(vtglop, "yyyy-MM-dd")
        vnamafile = masterFile & Microsoft.VisualBasic.Right(ComboBox1.Text, 4) & "_" & Format(vtglop, "yyyyMMdd") + ".txt"

        If File.Exists(vnamafile) Then
            Try : File.Delete(vnamafile)
            Catch ex As Exception : End Try
        End If

        Label3.Text = "Total Item : -"
        ProgressBar1.Value = 0
        ProgressBar1.Visible = True
        GroupBox1.Enabled = False
        BackgroundWorker1.WorkerReportsProgress = True
        BackgroundWorker1.WorkerSupportsCancellation = True
        BackgroundWorker1.RunWorkerAsync()
    End Sub
    Private Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        ''MsgOK("1")
        QueryX()
        ''MsgOK("2")
        isiTempItem()
        ''MsgOK("3")
        isiAwalStockToko()

        ''MsgOK("4")
        'File.Copy(dbSOFile, masterFile & "\dbSO.db", True)
        isiDatagrid()
        ''MsgOK("5")
    End Sub
    Sub QueryX()
        BackgroundWorker1.ReportProgress(0)
        Dim branchCode, s As String
        branchCode = Microsoft.VisualBasic.Right(ComboBox1.Text, 4)
        BackgroundWorker1.ReportProgress(10)

        ExecSAP("truncate table tempitem")
        ExecSO("truncate table tempitem")
        ExecSO("truncate table tempoutput")
        ExecSO("truncate table tempoutput2")

        ExecLITE("delete from m_item")
        ExecLITE("delete from t_scanitem")
        ExecLITE("Update s_setting set value='" & branchCode & "' where name='Branch' ")

        s = " t3.u_description in ( 'Twang Two', 'Tutu Nail', 'Sleep Wear Direct', " & vbCrLf & _
            "      'Belle Ivy', 'Kemala', 'Lovely Jars', 'Queen N Cat', 'Red Fox', 'Tekuni Keramik',  " & vbCrLf & _
            "      'Loreal', 'Maybelline', 'Misslyn', 'Youngstyle', 'Levis', 'Wrangler', " & vbCrLf & _
            "      'Barbie', 'Hotwheels', 'Lego', 'Newboy', 'Alkaline', 'Wrapping Corner', 'Emway', 'Hasbro', 'Thomas & Friends' ) "
        's = " t3.u_description in ( 'Lego', 'Hasbro', 'Hotwheels', 'Emway', 'Thomas & Friends', 'Barbie', 'Youngstyle' ) "
        s = " t3.u_description in ( 'Loreal', 'Maybelline', 'Sleep Wear Direct', 'Levis' ) "
        s = " t3.u_description in ( " & txtBrand.Text.Trim & " ) "

        BackgroundWorker1.ReportProgress(30)
        s = "insert into tempitem " & vbCrLf & _
                "select rank() OVER (ORDER BY t3.U_description, t1.codebars) as nomor, " & vbCrLf & _
                "rtrim(ltrim(t1.codebars)) as plu, rtrim(ltrim(t1.itemcode)) as article, " & vbCrLf & _
                "rtrim(ltrim(replace(replace(t3.U_description,'''',''), ',', ''))) as sbu, " & vbCrLf & _
                "rtrim(ltrim(replace(replace(t1.frgnname,'''',''), ',', ''))) as description,  " & vbCrLf & _
                "t4.price as price, '0' as qty, '0' as jml, '0' as stock, '" & vtglopstr & "' as idproses, " & vbCrLf & _
                "'" & branchCode & "' as branch_id, '' as jenis " & vbCrLf & _
                "from OITM t1 " & vbCrLf & _
                "left join OITB t2 on t1.ItmsGrpCod=t2.ItmsGrpCod " & vbCrLf & _
                "left join [@PRODUCT_BRAND] t3 on Substring(t2.ItmsGrpNam,6,3)=t3.name " & vbCrLf & _
                "left join ( " & vbCrLf & _
                "   select a.article, max(a.tdate) as tdate, max(b.u_sellprc) as price " & vbCrLf & _
                "   from ( select u_itemcode as article, max(u_validdt_from) as tdate from [@SELL_PRICE] where u_validdt_from<='" & vtglopstr & "' group by u_itemcode ) a " & vbCrLf & _
                "   inner join [@SELL_PRICE] b on a.article=b.u_itemcode and a.tdate=b.u_validdt_from " & vbCrLf & _
                "   group by a.article " & vbCrLf & _
                ") t4 on t1.itemcode=t4.article " & vbCrLf & _
                "where " & s & " and " & vbCrLf & _
                "t1.codebars<>'' and t1.codebars is not null " & vbCrLf & _
                "order by t3.U_description, t1.codebars"
        '"len(t1.codebars)=13 and " & vbCrLf & _
        'Dbg(s)
        BackgroundWorker1.ReportProgress(60)
        ExecSAP(s)
        BackgroundWorker1.ReportProgress(100)
        ExecSAP("update tempitem set price=0 where price is null")
        ExecSAP("update tempitem set plu='' where plu is null")
    End Sub
    Sub isiTempItem()
        Dim bawah, atas, x, total, NoUrut As Integer
        Dim s, ssql, slite As String
        Dim branchCode As String = Microsoft.VisualBasic.Right(ComboBox1.Text, 4)
        'tambahin insert ke dbso
        ds = QuerySAP("select * from tempitem where tgl_so='" & vtglopstr & "' order by nomor") 'ccc
        total = ds.Tables(0).Rows.Count + 1
        If total > 0 Then
            If File.Exists(vnamafile) Then File.Delete(vnamafile)
            NoUrut = 0
            Dim sw As New IO.StreamWriter(vnamafile, True)
            'ds = QuerySAP("SELECT distinct sbu FROM tempitem where tgl_so='" & vtglopstr & "' order by sbu")
            bawah = 1
            atas = 1000
            For x = 1 To (total Mod 1000) + 1
                'For Each rs As DataRow In ds.Tables(0).Rows
                s = "select * from tempitem where " & vbCrLf & _
                               "tgl_so='" & vtglopstr & "' and nomor>=" & bawah & " " & vbCrLf & _
                               "and nomor<=" & atas & " order by nomor"
                ds2 = QuerySAP(s)
                'Dbg(s)
                slite = "INSERT INTO m_item VALUES " & vbCrLf
                ssql = "INSERT INTO tempitem VALUES " & vbCrLf
                For Each ro As DataRow In ds2.Tables(0).Rows
                    NoUrut += 1
                    Prg = CInt((NoUrut * 100) / total)
                    BackgroundWorker1.ReportProgress(Prg)

                    sw.Write(ro("Nomor") & "," & ro("PLU") & "," & ro("article") & "," & _
                             ro("SBU") & "," & LeftStr(Trim(ro("Description")), 30) & "," & _
                             CDbl(ro("Price")) & "," & ro("Qty") & "," & ro("Jml") & vbNewLine)
                    ssql = ssql & String.Format("('{0}', '{1}', '{2}', '{3}', '{4}', {5}, {6}, {7}, {8}, '{9}', '{10}', '{11}')," & vbCrLf, _
                                       Trim(ro("nomor")), Trim(ro("PLU")), Trim(ro("article")), _
                                       Trim(ro("SBU")), Trim(ro("Description")), CDbl(ro("Price")), ro("Qty"), ro("Jml"), "0", _
                                       Trim(ro("tgl_so")), Trim(branchCode), "")
                    'ExecSO(ss)

                    'ss = String.Format("insert into m_item values ( '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}' ) ", _
                    '                   Trim(branchCode), "", Trim(ro("nomor")), Trim(ro("PLU")), Trim(ro("article")), _
                    '                   Trim(ro("SBU")), Trim(ro("Description")), CDbl(ro("Price")), ro("Qty"), ro("Jml"))
                    'ExecLITE(ss)
                    slite = slite & "(" & "'" & Trim(branchCode) & "', '', " & "'" & Trim(ro("nomor")) & "', " & _
                            "'" & Trim(ro("plu")) & "', " & "'" & Trim(ro("article")) & "', " & _
                            "'" & Trim(ro("sbu")) & "', " & "'" & Trim(ro("description")) & "', " & _
                            "'" & CDbl(ro("price")) & "', " & "'" & ro("qty") & "', " & _
                            "'" & ro("jml") & "')," & vbCrLf
                Next
                If ds2.Tables(0).Rows.Count > 0 Then
                    ssql = Mid(ssql, 1, Len(ssql) - 3) & ";"
                    ExecSO(ssql)

                    slite = Mid(slite, 1, Len(slite) - 3) & ";"
                    ExecLITE(slite)
                End If
                bawah += 1000
                atas += 1000
            Next
            sw.Close()
            sw.Dispose()
            Label3.Text = "Total Article : " & CDec(total).ToString("N0")
        Else
            MsgBox("Data Item Tidak Ditemukan !!!")
            Label3.Text = ""
        End If
    End Sub
    Sub isiAwalStockToko()
        If ds.Tables(0).Rows.Count <= 0 Then Exit Sub
        Dim s As String
        s = "delete stock_toko where branch_id = '" & Microsoft.VisualBasic.Right(ComboBox1.Text, 4) & "' " & vbCrLf & _
               "and convert(varchar(10), tgl_so,20) = '" & vtglopstr & "' "
        ExecSO(s)
        s = "insert into stock_toko " & vbCrLf & _
               "    select '" & Microsoft.VisualBasic.Right(ComboBox1.Text, 4) & "', " & vbCrLf & _
               "    '" & vtglopstr & "', '', plu, article, sbu, description, qty " & vbCrLf & _
               "    from tempitem " & vbCrLf & _
               "    order by nomor "
        'Dbg(s)
        ExecSO(s)
    End Sub
    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        GroupBox1.Enabled = True
        ProgressBar1.Visible = False
        Prg = 0

        'Dim x As Integer = 0
        'Dim s As String = vnamafile + vbNewLine
        'Using reader As StreamReader = New StreamReader("Lookup.ini")
        '    Dim line As String = reader.ReadLine 'perbaris
        '    Do While (Not line Is Nothing)
        '        If x > 0 Then
        '            s += line + vbNewLine
        '        End If
        '        x += 1
        '        line = reader.ReadLine
        '    Loop
        'End Using
        'MsgOK(s)
        'My.Computer.FileSystem.WriteAllText("Lookup.ini", s, False)

        'If ds.Tables(0).Rows.Count > 0 Then
        '    Try
        '        'File.Copy(vnamafile, Replace(vnamafile, ".txt", ".csv"))
        '    Catch ex As Exception

        '    End Try
        '    DataGridView1.DataSource = ds.Tables(0)
        '    DataGridView1.Columns("Price").DefaultCellStyle.Format = "N0"
        '    DataGridView1.Columns("Stock").Visible = False
        '    'DataGridView1.Refresh()
        'End If
        'Clipboard.SetText(vnamafile)
        MsgOK("File Tersimpan di : " & vnamafile)
        ShowDLookup(vnamafile)
        'Process.Start("DLookup.exe")
    End Sub
    Sub Query()
        Dim vSBU, s As String

        Dim vperiode As String
        vperiode = Format(Now, "yyyyMM")
        vawal = Microsoft.VisualBasic.Left(vperiode, 4) + "-" + Microsoft.VisualBasic.Right(vperiode, 2) + "-" + "01" + " 00:00:00"
        If Microsoft.VisualBasic.Right(vperiode, 2) = "12" Then
            vakhir = CStr(CDate(CStr(Int(Microsoft.VisualBasic.Left(vperiode, 4)) + 1) + "-" + "01" + "-" + "01").AddDays(-1))
        Else
            vakhir = CDate(Microsoft.VisualBasic.Left(vperiode, 4) + "-" + CStr(CInt(Microsoft.VisualBasic.Right(vperiode, 2)) + 1) + "-" + "01").AddDays(-1)
        End If
        vakhir = Format(CDate(vakhir), "yyyy-MM-dd") + " 00:00:00"
        vprev = CStr(CDate(vawal).AddDays(-1))
        vprev = Format(CDate(vprev), "yyyy-MM-dd") + " 00:00:00"

        vSBU = ""
        If ComboBox2.SelectedValue = "co" Then
            vSBU = "COSMETICS"
        ElseIf ComboBox2.SelectedValue = "to" Then
            vSBU = "TOYS"
        ElseIf ComboBox2.SelectedValue = "fa" Then
            vSBU = "FASHION"
        ElseIf ComboBox2.SelectedValue = "ot" Then
            vSBU = "OTHER"
        End If

        vtgl = Format(Now, "yyyy-MM-dd") + " 00:00:00"
        'MsgBox("vperiode : " & vperiode & vbCrLf & _
        '       "vawal : " & vawal & vbCrLf & _
        '       "vakhir : " & vakhir & vbCrLf & _
        '       "vprev : " & vprev & vbCrLf & _
        '       "vsbu : " & vSBU & vbCrLf & _
        '       "vtgl : " & vtgl)
        Prg += 6
        BackgroundWorker1.ReportProgress(Int(Prg))
        getSqldb("IF OBJECT_ID('dbo.TOTItem', 'U') IS NOT NULL DROP TABLE dbo.TOTItem")
        s = "CREATE TABLE TOTItem (Toko varchar(20) ,CardCode varchar(10), " & vbCrLf & _
            "CardName varchar(100),MC varchar(100),Brand varchar(100) ,SBU varchar(50), " & vbCrLf & _
            "Article varchar(50),PLU varchar(50),Dscription varchar(100) ,TotInQtyAwal Dec(25,2), " & vbCrLf & _
            "TotOutQtyAwal Dec(25,2), Date_Purch smalldatetime,Purch_Price Dec(25,3), " & vbCrLf & _
            "Price Dec(25,3),AvgPrice Dec(25,3),InQty Dec(25,3),OutQty Dec(25,3), " & vbCrLf & _
            "BeginQty Dec(25,3),BeginCost Dec(25,3), ReturnCost Dec(25,3),ReturnPrice Dec(25,3), " & vbCrLf & _
            "QtyReturn Dec(25,3),Stock dec(25,3),U_Description varchar(100)) "
        'Dbg(s)
        getSqldb(s) 'buat table master item
        Prg += 6
        BackgroundWorker1.ReportProgress(Int(Prg))
        s = "insert into TOTItem " & vbCrLf & _
            "  select T3.WhsCode [Toko],T0.CardCode ,T5.CardFName,t1.ItmsGrpNam [MC], " & vbCrLf & _
            "  LEFT(T3.U_profit_ctr,2)[BRAND] ,T2.U_description [SBU], T0.ItemCode [Article], " & vbCrLf & _
            "  T0.CodeBars [PLU],T0.ItemName,0,0,null,0,0,0,0,0,0,0,0,0,0,0,T4.U_description " & vbCrLf & _
            "  from OITM T0 " & vbCrLf & _
            "  inner join  OITB T1 on T0 .ItmsGrpCod=T1.ItmsGrpCod " & vbCrLf & _
            "  inner  join [@product_brand] T2 On substring(T1.ItmsGrpNam,6,3) = T2.Name " & vbCrLf & _
            "  INNER JOIN OITW T3 ON T0.ItemCode=T3.ItemCode " & vbCrLf & _
            "  LEFT JOIN [@PRODUCT_CATEGORY] T4 ON substring(T1.itmsGrpNam,4,2)=T4.Name " & vbCrLf & _
            "  inner join OCRD T5 on T0.CardCode =T5.CardCode " & vbCrLf & _
            "  where RIGHT(t1.ItmsGrpNam,1)<>'1' and " & vbCrLf & _
            "  T3.WhsCode='" & Microsoft.VisualBasic.Right(ComboBox1.Text, 4) & "' " & vbCrLf & _
            "  and T2.U_description in ('Barbie','Hotwheels','Lego','Loreal','Maybelline','Newboy'," & vbCrLf & _
            "  'Alkaline','Youngstyle','Levis','Wrapping Corner','Emway','Hasbro'," & vbCrLf & _
            "  'Thomas & Friends','Twang Two','Tutu Nail','Belle Ivy','Kemala','Lovely Jars'," & vbCrLf & _
            "  'Queen N Cat','Red Fox','Tekuni Keramik') "
        'Dbg(s)
        getSqldb(s) 'isi ke table master item
        Prg += 6
        BackgroundWorker1.ReportProgress(Int(Prg))
        getSqldb("IF OBJECT_ID('dbo.Stock', 'U') IS NOT NULL DROP TABLE dbo.Stock")
        s = "create table Stock(Toko varchar(20) COLLATE SQL_Latin1_General_CP850_CI_AS, " & vbCrLf & _
                 "ItemCode varchar(50)COLLATE SQL_Latin1_General_CP850_CI_AS,TotInQtyAwal Dec(25,2)," & vbCrLf & _
                 "TotOutQtyAwal Dec(25,2)) " & vbCrLf & _
                 "  insert into Stock " & vbCrLf & _
                 "    select T0.Warehouse,T0.ItemCode,SUM(T0.InQty) ,SUM(T0.OutQty) " & vbCrLf & _
                 "    from OINM T0 " & vbCrLf & _
                 "    INNER JOIN OITM T1 ON T0.ItemCode =T1.ItemCode " & vbCrLf & _
                 "    LEFT Join OITB T3 On T1.ItmsGrpCod = T3.ItmsGrpCod " & vbCrLf & _
                 "    LEFT Join [@product_brand] T4 On substring(T3.ItmsGrpNam,6,3) = T4.Name " & vbCrLf & _
                 "    WHERE T0.DocDate <='" & vprev & "' AND T4.U_description in ('Barbie','Hotwheels'," & vbCrLf & _
                 "      'Lego','Loreal','Maybelline','Newboy','Alkaline','Youngstyle','Levis'," & vbCrLf & _
                 "      'Wrapping Corner','Emway','Hasbro','Thomas & Friends','Twang Two','Tutu Nail'," & vbCrLf & _
                 "      'Belle Ivy','Kemala','Lovely Jars','Queen N Cat','Red Fox','Tekuni Keramik') " & vbCrLf & _
                 "    AND T0.Warehouse ='" & Microsoft.VisualBasic.Right(ComboBox1.Text, 4) & "' " & vbCrLf & _
                 "    GROUP BY T0.Warehouse,T0.ItemCode "
        'Dbg(s) 
        getSqldb(s) 'isi table stok, ada totalin, totalout
        Prg += 6
        BackgroundWorker1.ReportProgress(Int(Prg))
        s = "update TOTItem set TotInQtyAwal=T1.TotInQtyAwal ,TotOutQtyAwal=T1.TotOutQtyAwal " & vbCrLf & _
            "from TOTItem T0 " & vbCrLf & _
            "inner join Stock T1 on T0.Article =T1.ItemCode and T0.Toko=T1.Toko "
        'Dbg(s)
        getSqldb(s) 'update total in dan out
        Prg += 6
        BackgroundWorker1.ReportProgress(Int(Prg))
        getSqldb("IF OBJECT_ID('dbo.tItemPrice', 'U') IS NOT NULL DROP TABLE dbo.tItemPrice")
        s = "Create Table tItemPrice(U_ItemCode varchar(50),U_SellPrcid varchar(50),U_SellPrc varchar(50))"
        'Dbg(s)
        getSqldb(s)
        Prg += 6
        BackgroundWorker1.ReportProgress(Int(Prg))
        s = "Insert Into tItemPrice " & vbCrLf & _
            "  SELECT U_ItemCode,U_SellPrcid, " & vbCrLf & _
            "   Cast(U_SellPrc as Dec(25,2)) as U_SellPrc " & vbCrLf & _
            "   FROM [@SELL_PRICE] " & vbCrLf & _
            "   WHERE dbo.fcGetSellingPriceIdnew(U_ItemCode,'" & vtgl & "') = U_SellPrcid "
        'Dbg(s)
        getSqldb(s) 'update sell price
        Prg += 6
        BackgroundWorker1.ReportProgress(Int(Prg))
        getSqldb("IF OBJECT_ID('dbo.tempPurch', 'U') IS NOT NULL DROP TABLE dbo.tempPurch")
        s = "SELECT U_ItemCode,max(U_PurchPrcid)as U_PurchPrcid,max(U_PurchPrc) as [U_PurchPrc], " & vbCrLf & _
            "max(U_validdt_from) as U_validdt_from " & vbCrLf & _
            "INTO tempPurch " & vbCrLf & _
            "FROM [@Purch_PRICE] " & vbCrLf & _
            "where getdate() between U_validdt_from and U_validdt_to " & vbCrLf & _
            "group by U_ItemCode "
        'Dbg(s)
        getSqldb(s) 'item purchase price
        Prg += 6
        BackgroundWorker1.ReportProgress(Int(Prg))
        s = "UPDATE TOTItem " & vbCrLf & _
            "SET price= T1.U_SellPrc,date_purch=T2.U_validdt_from,purch_price=T2.U_PurchPrc " & vbCrLf & _
            "FROM TOTItem T0 " & vbCrLf & _
            "INNER JOIN tItemPrice T1 ON T1.U_ItemCode = T0.Article " & vbCrLf & _
            "inner join tempPurch T2 on T1.U_ItemCode=T2.U_ItemCode"
        'Dbg(s)
        getSqldb(s) 'update sell dan purchase price di master item
        Prg += 6
        BackgroundWorker1.ReportProgress(Int(Prg))
        getSqldb("IF OBJECT_ID('dbo.tReturnqty', 'U') IS NOT NULL DROP TABLE dbo.tReturnqty")
        s = "Create Table tReturnqty " & vbCrLf & _
            "(ItemCode varchar(50),DocDate smalldatetime,WhsCode varchar(50),InQty Dec(25,2), " & vbCrLf & _
            "OutQty Dec(25,2)) " & vbCrLf & _
            "  Insert Into  tReturnqty " & vbCrLf & _
            "    Select T0.ItemCode ,T0.DocDate,T1.WhsCode,Sum(T0.InQty),Sum(T0.OutQty) " & vbCrLf & _
            "      From OINM T0 " & vbCrLf & _
            "      Inner Join OWHS T1 On T0.Warehouse = T1.WhsCode " & vbCrLf & _
            "      Inner join OITM T2 On T0.ItemCode = T2.ItemCode " & vbCrLf & _
            "      Inner Join OITB T3 On T2.ItmsGrpCod = T3.ItmsGrpCod " & vbCrLf & _
            "      Inner Join [@product_brand] T4 On substring(T3.ItmsGrpNam,6,3) = T4.Name " & vbCrLf & _
            "      Where T0.DocDate Between '" & vawal & "' And '" & vakhir & "' And T0.Transtype In(19,21) " & vbCrLf & _
            "      Group by T0.ItemCode,T0.DocDate,T1.WhsCode,T0.Price "
        'Dbg(s)
        getSqldb(s) 'qty item yang di return
        Prg += 6
        BackgroundWorker1.ReportProgress(Int(Prg))
        s = "UPDATE  TOTItem set ReturnCost=AvgPrice*(isnull(T1.OutQty,0)-isnull(T1.InQty,0)), " & vbCrLf & _
            "ReturnPrice=isnull(price,0)*(isnull(T1.OutQty,0)-isnull(T1.InQty,0)), " & vbCrLf & _
            "QtyReturn = (IsNull(T1.OutQty, 0) - IsNull(T1.InQty, 0)) " & vbCrLf & _
            "from TOTItem T0 inner join tReturnqty T1 on T1.ItemCode=T0.Article collate database_default " & vbCrLf & _
            "and T1.WhsCode=T0.Toko collate database_default "
        'Dbg(s)
        getSqldb(s) 'update return cost
        Prg += 6
        BackgroundWorker1.ReportProgress(Int(Prg))
        getSqldb("IF OBJECT_ID('dbo.tInv', 'U') IS NOT NULL DROP TABLE dbo.tInv")
        s = "Create table tInv " & vbCrLf & _
            "(ItemCode varchar(50),WareHouse Varchar(20),InQty Dec(25,3),OutQty Dec(25,3)) " & vbCrLf & _
            "  insert into tInv " & vbCrLf & _
            "    select T0.ItemCode,T0.WareHouse,sum(T0.InQty) as InQty,sum(T0.OutQty) as OutQty " & vbCrLf & _
            "    from OINM T0 " & vbCrLf & _
            "    where T0.DocDate Between '" & vawal & "' And '" & vakhir & "' and " & vbCrLf & _
            "    T0.Transtype In (13,14,15,16,18,20,58,59,60,67,162) " & vbCrLf & _
            "    group by T0.ItemCode,T0.WareHouse "
        'Dbg(s)
        getSqldb(s) 'qty in dan out di warehouse
        Prg += 6
        BackgroundWorker1.ReportProgress(Int(Prg))
        s = "update TOTItem set InQty=isnull(T1.InQty,0), OutQty=isnull(T1.OutQty,0) " & vbCrLf & _
            "from TOTItem T0 " & vbCrLf & _
            "inner join tInv T1 on T1.ItemCode=T0.Article collate database_default and " & vbCrLf & _
            "T1.WareHouse=T0.Toko collate database_default "
        'Dbg(s)
        getSqldb(s)
        Prg += 6
        BackgroundWorker1.ReportProgress(Int(Prg))
        s = "update TOTItem set BeginQty=isnull((TotInQtyAwal-TotOutQtyAwal),0), " & vbCrLf & _
            "stock=(TotInQtyAwal-TotOutQtyAwal)+(InQty-OutQty), " & vbCrLf & _
            "BeginCost = AvgPrice * IsNull((TotInQtyAwal - TotOutQtyAwal), 0) "
        'Dbg(s)
        getSqldb(s)
        Prg += 6
        BackgroundWorker1.ReportProgress(Int(Prg))
        'getSqldb("IF OBJECT_ID('dbo.tempsap', 'U') IS NOT NULL DROP TABLE dbo.tempsap")

        'getSqldb("Drop Table tempsap")
        Prg += 6
        BackgroundWorker1.ReportProgress(Int(Prg))
        's = "CREATE TABLE tempsap (Nomor int,PLU varchar(20), Article varchar(15),SBU varchar(30), " & vbCrLf & _
        '    "Description varchar(50), Price money,Qty int,Jml int, Stock int, idproses varchar(30) ) " & vbCrLf & _
        getSqldb("delete from tempitem where substring(idproses,1,8) <= '" & Format(DateAdd(DateInterval.Day, -5, Now), "yyyyMMdd") & "' ")

        s = "  if '" & vSBU & "'='TOYS' " & vbCrLf & _
            "  begin " & vbCrLf & _
            "    insert into tempitem " & vbCrLf & _
            "      select rank() OVER (ORDER BY sbu ,article,rtrim(T1.PLU))NO ,rtrim(T1.PLU) PLU, " & vbCrLf & _
            "      article,sbu, Replace(rtrim(T1.Dscription),',',' ') Description, " & vbCrLf & _
            "      rtrim(convert(int,T1.Price)) Price,'0' as Qty,'0','0', '" & vtglopstr & "', " & vbCrLf & _
            "      '" & Microsoft.VisualBasic.Right(ComboBox1.Text, 4) & "', '" & vSBU & "'  " & vbCrLf & _
            "      from TOTItem T1 " & vbCrLf & _
            "      where T1.price<>0 and LEN(T1.PLU)=13 and sbu in ('Barbie','Hotwheels','Lego'," & vbCrLf & _
            "      'Newboy','Alkaline','Wrapping Corner','Emway','Hasbro','Thomas & Friends') " & vbCrLf & _
            "      group by T1.PLU, T1.Article, T1.Dscription,sbu,T1.Price,T1.Stock " & vbCrLf & _
            "      order by sbu, article,rtrim(T1.PLU) " & vbCrLf & _
            "  End else if '" & vSBU & "'='COSMETICS' begin " & vbCrLf & _
            "    insert into tempitem " & vbCrLf & _
            "      select rank() OVER (ORDER BY sbu ,article,rtrim(T1.PLU))NO ,rtrim(T1.PLU) PLU, " & vbCrLf & _
            "      article,sbu, Replace(rtrim(T1.Dscription),',',' ') Description, " & vbCrLf & _
            "      rtrim(convert(int,T1.Price)) Price,'0' as Qty,'0','0', '" & vtglopstr & "', " & vbCrLf & _
            "      '" & Microsoft.VisualBasic.Right(ComboBox1.Text, 4) & "', '" & vSBU & "'  " & vbCrLf & _
            "      from TOTItem T1 where T1.price<>0 and LEN(T1.PLU)=13 and sbu in('Loreal','Maybelline') " & vbCrLf & _
            "      group by T1.PLU,T1.Article  ,T1.Dscription ,sbu,T1.Price ,T1.Stock " & vbCrLf & _
            "      order by sbu ,article,rtrim(T1.PLU) " & vbCrLf & _
            "  End else if '" & vSBU & "'='FASHION' " & vbCrLf & _
            "  begin " & vbCrLf & _
            "    insert into tempitem " & vbCrLf & _
            "      select rank() OVER (ORDER BY sbu ,article,rtrim(T1.PLU))NO ,rtrim(T1.PLU) PLU, " & vbCrLf & _
            "      article, sbu, Replace(rtrim(T1.Dscription),',',' ')Description, " & vbCrLf & _
            "      rtrim(convert(int,T1.Price)) Price,'0' as Qty,'0','0', '" & vtglopstr & "', " & vbCrLf & _
            "      '" & Microsoft.VisualBasic.Right(ComboBox1.Text, 4) & "', '" & vSBU & "'  " & vbCrLf & _
            "      from TOTItem T1 " & vbCrLf & _
            "      where T1.price<>0 and LEN(T1.PLU)=13 and sbu in('Youngstyle','Levis') " & vbCrLf & _
            "      group by T1.PLU,T1.Article  ,T1.Dscription ,sbu,T1.Price ,T1.Stock " & vbCrLf & _
            "      order by sbu ,article,rtrim(T1.PLU) " & vbCrLf & _
            "  End else if '" & vSBU & "'='OTHER' " & vbCrLf & _
            "  begin " & vbCrLf & _
            "    insert into tempitem " & vbCrLf & _
            "      select rank() OVER (ORDER BY sbu ,article,rtrim(T1.PLU))NO ,rtrim(T1.PLU) PLU, " & vbCrLf & _
            "      article,sbu, Replace(rtrim(T1.Dscription),',',' ')Description, " & vbCrLf & _
            "      rtrim(convert(int,T1.Price)) Price,'0' as Qty,'0','0', '" & vtglopstr & "', " & vbCrLf & _
            "      '" & Microsoft.VisualBasic.Right(ComboBox1.Text, 4) & "', '" & vSBU & "'  " & vbCrLf & _
            "      from TOTItem T1 " & vbCrLf & _
            "      where T1.price<>0 and LEN(T1.PLU)=13 and sbu in('Twang Two','Tutu Nail'," & vbCrLf & _
            "      'Belle Ivy','Kemala','Lovely Jars','Queen N Cat','Red Fox','Tekuni Keramik') " & vbCrLf & _
            "      group by T1.PLU,T1.Article  ,T1.Dscription ,sbu,T1.Price ,T1.Stock " & vbCrLf & _
            "      order by sbu ,article,rtrim(T1.PLU) " & vbCrLf & _
            "End"
        'Dbg(s)
        getSqldb(s)
        'Dim dI As DataSet
        'dI = QuerySAP("select * from tempitem where idproses='" & idProses & "' order by nomor ")

        Prg += 5
        BackgroundWorker1.ReportProgress(Int(Prg))
        s = "drop table TOTItem drop table Stock drop table tReturnqty drop table tInv drop table tItemPrice drop table tempPurch"
        'Dbg(s)
        getSqldb(s)
        Prg += 5
        BackgroundWorker1.ReportProgress(Int(Prg))
    End Sub
    Sub query2()
        Dim vSBU As String

        Dim vperiode As String
        vperiode = Format(Now, "yyyyMM")
        vawal = Microsoft.VisualBasic.Left(vperiode, 4) + "-" + Microsoft.VisualBasic.Right(vperiode, 2) + "-" + "01" + " 00:00:00"
        If Microsoft.VisualBasic.Right(vperiode, 2) = "12" Then
            vakhir = CStr(CDate(CStr(Int(Microsoft.VisualBasic.Left(vperiode, 4)) + 1) + "-" + "01" + "-" + "01").AddDays(-1))
        Else
            vakhir = CDate(Microsoft.VisualBasic.Left(vperiode, 4) + "-" + CStr(CInt(Microsoft.VisualBasic.Right(vperiode, 2)) + 1) + "-" + "01").AddDays(-1)
        End If
        vakhir = Format(CDate(vakhir), "yyyy-MM-dd") + " 00:00:00"
        vprev = CStr(CDate(vawal).AddDays(-1))
        vprev = Format(CDate(vprev), "yyyy-MM-dd") + " 00:00:00"
        vSBU = ""
        If ComboBox2.SelectedValue = "co" Then
            vSBU = "COSMETICS"
        ElseIf ComboBox2.SelectedValue = "to" Then
            vSBU = "TOYS"
        ElseIf ComboBox2.SelectedValue = "fa" Then
            vSBU = "FASHION"
        ElseIf ComboBox2.SelectedValue = "ot" Then
            vSBU = "OTHER"
        End If

        vtgl = Format(Now, "yyyy-MM-dd") + " 00:00:00"

        Value(1) = Microsoft.VisualBasic.Right(ComboBox1.Text, 4)
        'Value(2) = vprev
        'Value(3) = vtgl
        'Value(4) = vawal
        'Value(5) = vakhir
        'Value(6) = vSBU
        Param(1) = "@WhsCode"
        'Param(2) = "@DocDate"
        'Param(3) = "@vtgl"
        'Param(4) = "@vawal"
        'Param(5) = "@vakhir"
        'Param(6) = "@vSBU"
        SelProc("uspSO", 1)
    End Sub

    Private Const SW_SHOWDEFAULT As System.Int32 = 10
    '<System.Runtime.InteropServices.DllImport("user32.dll")>
    Public Shared Function ShowWindow(<System.Runtime.InteropServices.In()> ByVal hWnd As System.IntPtr, <System.Runtime.InteropServices.In()> ByVal nCmdShow As System.Int32) As System.Boolean
    End Function
    '<System.Runtime.InteropServices.DllImport("user32.dll")>
    Public Shared Function SetForegroundWindow(<System.Runtime.InteropServices.In()> ByVal hWnd As System.IntPtr) As System.Boolean
    End Function
    Sub ShowDLookup(Optional ByVal FileName As String = "C:\SO\")
        Dim Process As System.Diagnostics.Process = System.Diagnostics.Process.Start("DLookup.exe")
        System.Threading.Thread.Sleep(100)
        ShowWindow(Process.MainWindowHandle, SW_SHOWDEFAULT)
        SetForegroundWindow(Process.MainWindowHandle)
        System.Threading.Thread.Sleep(100)
        System.Windows.Forms.SendKeys.SendWait(FileName)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ShowDLookup()
        'Process.Start("DLookup.exe")
    End Sub
    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub
    'Sub export()
    '    If ComboBox2.SelectedIndex = 1 Then
    '        If ComboBox1.SelectedIndex = 1 Then cek("1", 0)
    '        If ComboBox1.SelectedIndex = 2 Then cek("2", 0)
    '        If ComboBox1.SelectedIndex = 3 Then cek("3", 0)
    '    ElseIf ComboBox2.SelectedIndex = 2 Then
    '        If ComboBox1.SelectedIndex = 1 Then cek("1", 1)
    '        If ComboBox1.SelectedIndex = 2 Then cek("2", 1)
    '        If ComboBox1.SelectedIndex = 3 Then cek("3", 1)
    '    ElseIf ComboBox2.SelectedIndex = 3 Then
    '        If ComboBox1.SelectedIndex = 1 Then cek("1", 2)
    '        If ComboBox1.SelectedIndex = 2 Then cek("2", 2)
    '        If ComboBox1.SelectedIndex = 3 Then cek("3", 2)
    '    End If
    'End Sub
    Private Sub Form1_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move

    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        MsgBox(Asc(e.KeyChar))
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub CboBrand_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboBrand.Click
        GbBrand.Left = 361
        GbBrand.Top = 32
        GbBrand.Visible = True
    End Sub

    Private Sub CboBrand_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboBrand.SelectedIndexChanged
        'If CboBrand.Text.Trim = "" Then
        '    txtBrand.Text = ""
        'Else
        '    Dim words As String() = Split(CboBrand.Text, ",")
        '    Dim s As String = ""
        '    For Each word As String In words
        '        word = Trim(word)
        '        s += " '" & word & "',"
        '    Next
        '    s = Mid(s, 1, Len(s) - 1) & " "
        '    txtBrand.Text = s
        'End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click
        'My.Computer.FileSystem.SpecialDirectories.
        Dim s As String
        s = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer) & "\Honeywell Dolphin 60s\\\Program Files\SO_STAR"
        's = "\Honeywell Dolphin 60s\\\Program Files\SO_STAR"
        MsgOK(s)
        If Directory.Exists(s) Then
            MsgOK("ada")
        Else
            MsgOK("tidak ada")
        End If
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCari.TextChanged
        NavSource2.Filter = " (description like '%" & txtCari.Text.Trim & "%' or plu like '%" & txtCari.Text.Trim & "%') "
    End Sub

    Private Sub txtCariBrand_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCariBrand.Click
        dgBrand.CurrentCell = dgBrand.Item(1, dgBrand.CurrentRow.Index)
        txtCariBrand.Clear()
        NavBrand.Filter = ""
    End Sub

    Private Sub txtCariBrand_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCariBrand.KeyDown
        If e.KeyCode = Keys.Down Then
            'MsgOK("1")
            dgBrand.Focus()
            dgBrand.CurrentCell = dgBrand.Item(0, 0)
        End If
    End Sub

    Private Sub TextBox2_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCariBrand.TextChanged
        NavBrand.Filter = " (brand like '%" & txtCariBrand.Text.Trim & "%') "
    End Sub

    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click
        dgBrand.CurrentCell = dgBrand.Item(1, dgBrand.CurrentRow.Index)

        txtCariBrand.Clear()
        NavBrand.Filter = ""
        GbBrand.Visible = False

        'If dgBrand.IsCurrentCellInEditMode Then
        '    MsgOK("1")
        '    dgBrand.CurrentCell = dgBrand.Item(0, dgBrand.CurrentRow.Index + 1)
        '    'dgBrand.CommitEdit(
        'Else
        '    MsgOK("2")
        'End If



        'If dgBrand.RowCount > dgBrand.CurrentRow.Index + 1 Then
        'dgBrand.CurrentCell = dgBrand.Item(0, dgBrand.CurrentRow.Index + 1)
        'End If

        Dim s As String = ""

        For x As Integer = 0 To dgBrand.RowCount - 1
            If CInt(dgBrand.Rows(x).Cells(0).Value.ToString) = 1 Then
                s += " '" & dgBrand.Rows(x).Cells(1).Value.ToString & "',"
            End If
        Next
        If Len(s) > 0 Then
            s = Mid(s, 1, Len(s) - 1) & " "
            txtBrand.Text = s
        End If

        
    End Sub

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click
        GbBrand.Left = 361
        GbBrand.Top = 32
        GbBrand.Visible = True
        txtCariBrand.Focus()
    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click
        txtBrand.Clear()
        For x As Integer = 0 To dgBrand.RowCount - 1
            dgBrand.Item(0, x).Value = 0
        Next
    End Sub
End Class
