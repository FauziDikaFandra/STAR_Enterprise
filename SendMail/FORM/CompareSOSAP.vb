Imports System.IO
'Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop
Imports System.Threading
Public Class CompareSOSAP
    Dim startth As Thread
    Dim isiText, vawal, vakhir, vprev, vtgl, b, c, d, e, f, g, h, vtglopstr, csvpath, Branch, txtstr As String
    Dim lineCount As Integer
    Dim dsstok, ds As New DataSet
    Dim vtglop As Date
    Dim strPesan, pathName, idCompare, tipeOutput As String
    Dim Prg As Decimal = 0
    Dim wrkend As Boolean = False
    Private Sub Form2_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    End Sub
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ConnectServer()
        m_Sqlconn = "Data Source=" & m_ServerName & ";" & "Initial Catalog=" & m_DBName & ";" & "User ID=" & m_UserName & ";" & "Password=" & m_Password & ";"
        m_Sqlconn2 = "Data Source=" & m_ServerName2 & ";" & "Initial Catalog=" & m_DBName2 & ";" & "User ID=" & m_UserName2 & ";" & "Password=" & m_Password2 & ";"
        CheckForIllegalCrossThreadCalls = False
        cmb(ComboBox1, "select WhsName as Code, WhsName + ' - ' + WhsCode as WhsName  from OWHS Where WhsCode <>'01' and WhsCode not in ('DC01','HO01') Order by WhsCode", "Code", "WhsName", 1)
        CheckForIllegalCrossThreadCalls = False
        Try
            If Directory.Exists(masterFile) = False Then Directory.CreateDirectory(masterFile)
            If Directory.Exists(ScanFile) = False Then Directory.CreateDirectory(ScanFile)
            If Directory.Exists(ExcelFile) = False Then Directory.CreateDirectory(ExcelFile)
        Catch ex As Exception
        End Try
        'ComboBox1.Items.Clear()
        'ComboBox1.Items.Add("Mal Kelapa Gading - S001")
        'ComboBox1.Items.Add("Mal Serpong - S002")
        'ComboBox1.Items.Add("Mal Bekasi - S003")
        'ComboBox1.Text = "Mal Serpong - S002"
        DateTimePicker1.Value = Now
        TextBox1.Text = ScanFile
        'ComboBox1.Text = "tes"
    End Sub

    Private Sub setLabelTxt(ByVal text As String, ByVal lbl As Label)
        If lbl.InvokeRequired Then
            lbl.Invoke(New setLabelTxtInvoker(AddressOf setLabelTxt), text, lbl)
        Else
            lbl.Text = text
        End If
    End Sub
    Private Delegate Sub setLabelTxtInvoker(ByVal text As String, ByVal lbl As Label)

#Region "Procedure"
    Function BranchCode() As String
        Dim hasil As String = ""
        hasil = Microsoft.VisualBasic.Right(ComboBox1.Text, 4)

        'If ComboBox1.SelectedIndex = 0 Then
        '    hasil = "MKG"
        'ElseIf ComboBox1.SelectedIndex = 1 Then
        '    hasil = "SMS"
        'ElseIf ComboBox1.SelectedIndex = 2 Then
        '    hasil = "SMB"
        'End If
        Return hasil
    End Function
    Function BranchCodeFile(ByVal fname As String) As String
        Return Microsoft.VisualBasic.Mid(fname, 4, 4)
    End Function
    Function TipeFile(ByVal FName As String) As String
        Return Microsoft.VisualBasic.Mid(FName, 1, 2)
    End Function
    Function cekFileName() As Boolean
        Dim di As New IO.DirectoryInfo(TextBox1.Text.Trim)
        Dim diar1 As IO.FileInfo() = di.GetFiles("*.txt")
        Dim dra As IO.FileInfo
        Dim fn As String
        Dim hasil As Boolean = True
        For Each dra In diar1
            fn = Path.GetFileName(dra.FullName)
            If BranchCodeFile(fn) <> BranchCode() Then
                MsgError("File : " & fn & vbCrLf & _
                         "Branches Yang Di Pilih Bukan '" & BranchCode() & "' !!!")
                hasil = False
            End If
        Next
        Return hasil
    End Function
    Sub ProcessTextFile()
        Dim di As New IO.DirectoryInfo(TextBox1.Text.Trim)
        Dim diar1 As IO.FileInfo() = di.GetFiles("*.txt")
        Dim dra As IO.FileInfo
        Dim fn, line As String
        Dim CekLookup, total, no As Integer
        Dim datapart As Array
        CekLookup = 0 : total = 0 : no = 0
        For Each dra In diar1
            fn = Path.GetFileName(dra.FullName)
            total += File.ReadAllLines(dra.FullName).Length
        Next
        'ExecSO("delete from tempoutput where convert(varchar(10), tgl_so, 20)<'" & vtglopstr & "' or idcompare<>'" & idCompare & "' ")
        ExecSO("delete from tempoutput")
        For Each dra In diar1
            fn = Path.GetFileName(dra.FullName)
            Using reader As StreamReader = New StreamReader(dra.FullName)
                line = reader.ReadLine 'perbaris
                Do While (Not line Is Nothing)
                    Prg = CInt((no * 100) / total)
                    BackgroundWorker2.ReportProgress(Prg)
                    datapart = Split(line, ",")
                    If datapart(0).ToString.Trim.Length < 5 Then 'proses data master text file --> tempcsv SO

                    ElseIf datapart(0).ToString.Trim.Length >= 5 Then 'proses hasil scan text file --> tempoutput SO
                        Text2TempOutPut(datapart, dra.FullName)
                    End If
                    no += 1
                    line = reader.ReadLine
                Loop
            End Using
        Next

        ExecSO("update a " & vbCrLf & _
               "set a.qty = b.qty " & vbCrLf & _
               "from tempitem a " & vbCrLf & _
               "inner join ( select plu, sum(jml) as qty from tempOutPut group by plu ) b on a.plu=b.plu ")
    End Sub
    Sub Text2TempOutPut(ByVal DataPart As Array, ByVal PathFile As String)
        Dim lbl, fn, qty, plu As String
        fn = Path.GetFileName(PathFile)
        qty = "0"
        If DataPart(2).ToString.Trim = "0" Then : qty = "0"
        ElseIf DataPart(2).ToString.Trim <> "0" Then : qty = DataPart(2).ToString.Trim
        ElseIf DataPart(2).ToString.Trim = "" Then : qty = "0"
        End If

        If IsNumeric(DataPart(1).ToString.Trim) Then : plu = CDbl(DataPart(1).ToString.Trim)
        Else : plu = DataPart(1).ToString.Trim : End If

        lbl = "Result Scan, " & fn & ", PLU : " & plu
        Try : setLabelTxt(lbl, Label5) : Catch ex As Exception : End Try

        Try
            ExecSO("Insert Into tempOutPut values('" & TipeFile(fn) & "', " & vbCrLf & _
                   "'" & DataPart(0).ToString.Trim & "', '" & plu & "', '" & qty & "', '" & vtglopstr & "', " & vbCrLf & _
                   "'" & idCompare & "', '" & tipeOutput & "') ")
        Catch ex As Exception
            MsgError("Error Insert TempOutput : " & fn & ", " & plu)
            wrkend = True
            BackgroundWorker2.CancelAsync()
            Exit Sub
        End Try
    End Sub
    Sub StockToko()
        ExecSO("update a " & vbCrLf & _
               "set a.stock = b.qty " & vbCrLf & _
               "from stock_toko a " & vbCrLf & _
               "inner join tempitem b on a.plu=b.plu " & vbCrLf & _
               "where a.tgl_so='" & vtglopstr & "' ")
    End Sub
    Sub isiTempExcel()
        BackgroundWorker2.ReportProgress(0)
        Dim dsL As DataSet
        Dim namatable2, namatable As String
        namatable = "tempexcel_" & Replace(idCompare, " ", "")
        namatable2 = "tempexcel2_" & Replace(idCompare, " ", "")
        Dim lbl, s, set1, set2, select1, select2, for1, for2, plus1, plus2 As String
        set1 = "" : set2 = "" : select1 = "" : select2 = "" : for1 = "" : for2 = "" : plus1 = "" : plus2 = ""

        ExecSO("IF OBJECT_ID('" & namatable & "', 'U') IS NOT NULL DROP TABLE " & namatable & ";")
        ExecSO("IF OBJECT_ID('" & namatable2 & "', 'U') IS NOT NULL DROP TABLE " & namatable2 & ";")

        lbl = "Process Stock Toko"
        Try : setLabelTxt(lbl, Label5) : Catch ex As Exception : End Try
        BackgroundWorker2.ReportProgress(50)
        's = "create table " & namatable & " ( " & vbCrLf & _
        '    "plu varchar(30), article varchar(30), sbu varchar(100), description varchar(200), price float, " & vbCrLf
        s = "plu varchar(30), article varchar(30), sbu varchar(100), description varchar(200), price float, " & vbCrLf
        dsL = QuerySO("select distinct location from tempoutput order by location")
        For Each rL As DataRow In dsL.Tables(0).Rows
            s += rL("location").ToString.Trim & "_checker int default 0, " & rL("location").ToString.Trim & "_counter int default 0, " & vbCrLf
            set1 += vbCrLf & " a." & rL("location").ToString.Trim & "_checker=b." & rL("location").ToString.Trim & "_checker,"
            set2 += vbCrLf & " a." & rL("location").ToString.Trim & "_counter=b." & rL("location").ToString.Trim & "_counter,"
            select1 += vbCrLf & " coalesce([" & rL("location").ToString.Trim & "],0) as " & rL("location").ToString.ToLower.Trim & "_checker,"
            select2 += vbCrLf & " coalesce([" & rL("location").ToString.Trim & "],0) as " & rL("location").ToString.ToLower.Trim & "_counter,"
            for1 += vbCrLf & " [" & rL("location").ToString.Trim & "],"
            for2 += vbCrLf & " [" & rL("location").ToString.Trim & "],"
            plus1 += rL("location").ToString.Trim & "_checker+"
            plus2 += rL("location").ToString.Trim & "_counter+"
        Next
        s += "stock_checker int default 0, stock_counter int default 0, cek_pdt int default 0, " & vbCrLf & _
             "stock_sap int default 0, selisih_qty int default 0, selisih_price int default 0 " & vbCrLf & _
             ")"
        'Dbg(s)
        ExecSO("create table " & namatable & " ( " & vbCrLf & s) 'create tempexcel
        ExecSO("create table " & namatable2 & " ( " & vbCrLf & s) 'create tempexcel
        BackgroundWorker2.ReportProgress(80)
        'isi tempexcel, data awal
        ExecSO("insert into " & namatable & " (plu, article, sbu, description, price) " & vbCrLf & _
               "select plu, article, sbu, description, price from tempitem order by sbu, plu")
        BackgroundWorker2.ReportProgress(50)
        set1 = Mid(set1, 1, Len(set1) - 1)
        set2 = Mid(set2, 1, Len(set2) - 1)
        select1 = Mid(select1, 1, Len(select1) - 1)
        select2 = Mid(select2, 1, Len(select2) - 1)
        for1 = Mid(for1, 1, Len(for1) - 1)
        for2 = Mid(for2, 1, Len(for2) - 1)
        plus1 = Mid(plus1, 1, Len(plus1) - 1)
        plus2 = Mid(plus2, 1, Len(plus2) - 1)

        'update qty ho
        s = "update a " & vbCrLf & _
            "set " & set1 & " " & vbCrLf & _
            "from " & namatable & " a " & vbCrLf & _
            "INNER JOIN " & vbCrLf & _
            "( " & vbCrLf & _
                "select plu, " & vbCrLf & _
                select1 & vbCrLf & _
                "from " & vbCrLf & _
                "( " & vbCrLf & _
                    "select location, plu, sum(jml) as qty " & vbCrLf & _
                    "from tempOutPut where tipe='HO' " & vbCrLf & _
                    "group by tipe, location, plu " & vbCrLf & _
                ") src " & vbCrLf & _
                "pivot " & vbCrLf & _
                "( " & vbCrLf & _
                    "sum(qty) " & vbCrLf & _
                    "for location in ( " & for1 & " ) " & vbCrLf & _
                ") piv " & vbCrLf & _
            ") b on a.plu=b.plu"
        'Dbg(s)
        ExecSO(s)
        BackgroundWorker2.ReportProgress(100)

        'update qty toko
        s = "update a " & vbCrLf & _
            "set " & set2 & " " & vbCrLf & _
            "from " & namatable & " a " & vbCrLf & _
            "INNER JOIN " & vbCrLf & _
            "( " & vbCrLf & _
                "select plu, " & vbCrLf & _
                select2 & vbCrLf & _
                "from " & vbCrLf & _
                "( " & vbCrLf & _
                    "select location, plu, sum(jml) as qty " & vbCrLf & _
                    "from tempOutPut where tipe='TK' " & vbCrLf & _
                    "group by tipe, location, plu " & vbCrLf & _
                ") src " & vbCrLf & _
                "pivot " & vbCrLf & _
                "( " & vbCrLf & _
                    "sum(qty) " & vbCrLf & _
                    "for location in ( " & for2 & " ) " & vbCrLf & _
                ") piv " & vbCrLf & _
            ") b on a.plu=b.plu"
        'Dbg(s)
        BackgroundWorker2.ReportProgress(100)
        ExecSO(s)

        s = "update " & namatable & " set stock_checker=" & plus1
        ExecSO(s)
        s = "update " & namatable & " set stock_counter=" & plus2
        ExecSO(s)
        s = "update " & namatable & " set cek_pdt=stock_checker-stock_counter"

        ExecSO("update b " & vbCrLf & _
               "set b.stock_sap=a.stock " & vbCrLf & _
               "from " & namatable & " b " & vbCrLf & _
               "inner join stock_sys a on a.plu=b.plu " & vbCrLf & _
               "where a.tgl_so='" & vtglopstr & "' ")

        ExecSO(s)
        s = "update " & namatable & " set selisih_qty=stock_counter-stock_sap"
        ExecSO(s)
        s = "update " & namatable & " set selisih_price=selisih_qty*price"
        ExecSO(s)

        ExecSO("insert into " & namatable2 & " select * from " & namatable & " ")
        dsL.Dispose()
    End Sub
    Sub CreateSelisihPDT()
        Dim s1, s2, s, namatable2, sh As String
        Dim totalKolom, totalLine, totalLoc As Integer
        Dim dsL As DataSet
        'MsgOK("1")
        namatable2 = "tempexcel_" & txtIDCompare.Text
        dsL = QuerySO("select distinct location from tempoutput order by location")
        totalLoc = dsL.Tables(0).Rows.Count
        s = ""
        For Each rL As DataRow In dsL.Tables(0).Rows
            s += " " & rL("location").ToString.Trim & "_checker<>" & rL("location").ToString.Trim & "_counter or"
        Next
        s = Mid(s, 1, Len(s) - 2)
        s = "select * from " & namatable2 & " where " & vbCrLf & _
                      s & vbCrLf & _
                      "order by sbu, plu"
        'Dbg(s)
        dsL = QuerySO(s)
        If dsL.Tables(0).Rows.Count <= 0 Then
            MsgOK("Selamat, Tidak Ada Data Selisih PDT")
            dsL.Dispose()
            Exit Sub
        End If
        dsL = QuerySO("select top 1 * from " & namatable2)
        totalkolom = dsL.Tables(0).Columns.Count
        'MsgOK("2")
        sh = "sheetname=Selisih_PDT;"
        pathName = ExcelFile & Microsoft.VisualBasic.Right(ComboBox1.Text, 4) & "-" & _
                   Replace(vtglopstr, "-", "") & "-PDT.xls"
        PrepareExcel(sh, pathName)
        xlWorkSheet(0).Activate()
        'MsgOK("3")
        CellFormat(xlWorkSheet(0), "range=A:D;numberformat=@")
        CellFormat(xlWorkSheet(0), "range=E:" & colExcel(totalKolom) & ";numberformat=#,##0")
        CellFormat(xlWorkSheet(0), "range=A5:" & colExcel(totalKolom) & "6;wrap=true")

        'For x As Integer = 3 To totalKolom
        '    xlWorkSheet(0).Range(colExcel(totalKolom) & ":" & colExcel(totalKolom)).Columns.AutoFit()
        'Next
        'MsgOK("4")
        CellFormat(xlWorkSheet(0), "range=a1;fontname=Tahoma;fontsize=12;fontstyle=bold", _
                   "Report Selisih Stock Opname " & Microsoft.VisualBasic.Right(ComboBox1.Text, 4))
        'CellFormat(xlWorkSheet(0), "range=a2;fontname=Tahoma;fontsize=12;fontstyle=bold", _
        '           "Periode : " & Format(Date.Parse(vtglopstr), "dd-MMMM-yyyy") & "")
        CellFormat(xlWorkSheet(0), "range=a2;fontname=Tahoma;fontsize=12;fontstyle=bold", _
                   "Periode : " & Format(vtglop.AddDays(1), "dd-MMMM-yyyy") & "")
        CellFormat(xlWorkSheet(0), "range=a4;fontname=Tahoma;fontsize=9;fontstyle=bold", _
                   "Selisih PDT")

        CellFormat(xlWorkSheet(0), "range=A1:J1;merge=true")
        CellFormat(xlWorkSheet(0), "range=A2:J2;merge=true")

        JudulExcelPDT(xlWorkSheet(0))
        QueryPasteToExcel(xlWorkSheet(0), s, "A6")
        totalLine = File.ReadAllLines("temptxt.txt").Length
        'MsgOK("5")
        'disini
        s1 = "=" : s2 = "="
        For x As Integer = 1 To totalLoc
            s1 += colExcel(5 + x) & "7+"
        Next

        'CellFormat(xlWorkSheet(0), "range=" & colExcel(totalKolom - 5) & "7", "=F7+")

        xlWorkSheet(0).Range("D6").Select()
        xlApp.ActiveWindow.FreezePanes = True
        'MsgOK("6")
        CellFormat(xlWorkSheet(0), "range=A:A;columnwidth=17")
        CellFormat(xlWorkSheet(0), "range=B:B;columnwidth=12")
        CellFormat(xlWorkSheet(0), "range=C:E;columnwidth=clear")
        CellFormat(xlWorkSheet(0), "range=F:" & colExcel(totalKolom - 2) & ";columnwidth=8.20")
        CellFormat(xlWorkSheet(0), "range=" & colExcel(totalKolom - 1) & ":" & colExcel(totalKolom) & ";columnwidth=clear")

        'ConditionPDT(xlWorkSheet(0))
        ConditionFormat(xlWorkSheet(0), "temptxt.txt")

        CellFormat(xlWorkSheet(0), "range=A6:" & colExcel(totalKolom) & totalLine + 5 & ";fontsize=8;fontname=Tahoma;isborder=true")
        CellFormat(xlWorkSheet(0), "range=A5:" & colExcel(totalKolom) & "5;backcolor=192,192,192;isborder=true;wrap=true;rowheight=30")
        CellFormat(xlWorkSheet(0), "range=A" & totalLine + 8 & ":" & colExcel(totalKolom) & totalLine + 8 & ";backcolor=192,192,192;isborder=true")

        CellFormat(xlWorkSheet(0), "range=A:E;columnwidth=clear")

        CellFormat(xlWorkSheet(0), "paper=A4;orientation=landscape;topmargin=30;bottommargin=30;" & _
                       "leftmargin=20;rightmargin=20;titlerow=$1:$3")
        'MsgOK("7")
        SaveExcel()
        DestroyExcel()
        'MsgOK("8")
        dsL.Dispose()
    End Sub
    Sub ConditionPDT(ByVal xlSheet As Excel.Worksheet)
        Dim col, kolAw, kolAk, totalLine, totalLoc As Integer
        Dim dsL As DataSet
        Dim rng, frm As String
        dsL = QuerySO("select distinct location from tempoutput order by location")
        totalLoc = dsL.Tables(0).Rows.Count
        totalLine = File.ReadAllLines("temptxt.txt").Length

        kolAw = 7
        kolAk = 6 + totalLine
        col = 5
        For x As Integer = 1 To totalLoc
            rng = colExcel(col + x) & kolAw & ":" & colExcel(col + 1 + x) & kolAk & ""
            frm = "=$" & colExcel(col + x) & kolAw & "<>$" & colExcel(col + 1 + x) & kolAw
            ConditionFormatExcel(xlSheet, rng, frm)
            col += 1
        Next

        dsL.Dispose()
        'ConditionFormatExcel(xlSheet, "F7:G78", "=$F7<>$G7")
        'ConditionFormatExcel(xlSheet, "H7:I78", "=$H7<>$I7")
        'ConditionFormatExcel(xlSheet, "J7:K78", "=$J7<>$K7")

        'Dim rng As Excel.Range = xlSheet.Range("F7:G78")
        'Dim efc As Excel.FormatCondition

        'With rng.FormatConditions
        '    .Delete()
        '    .Add(Excel.XlFormatConditionType.xlExpression, , "=$F7<>$G7")
        'End With
        'efc = rng.FormatConditions(1)
        'efc.Interior.Color = RGB(255, 255, 0)

        'rng = xlSheet.Range("H7:I78")
        'With rng.FormatConditions
        '    .Delete()
        '    .Add(Excel.XlFormatConditionType.xlExpression, , "=$H7<>$I7")
        'End With
        'efc = rng.FormatConditions(1)
        'efc.Interior.Color = RGB(255, 255, 0)
    End Sub
    Sub ConditionFormat(ByVal xlSheet As Excel.Worksheet, ByVal Fn As String, _
                        Optional ByVal kolAw As Integer = 6, _
                        Optional ByVal kolTotal As Integer = 3)
        Dim col, kolAk, totalLine, totalLoc As Integer
        Dim dsL As DataSet
        Dim rng, frm As String
        dsL = QuerySO("select distinct location from tempoutput order by location")
        totalLoc = dsL.Tables(0).Rows.Count
        totalLine = File.ReadAllLines(Fn).Length

        col = 5
        kolAk = kolAw - 1 + totalLine

        For x As Integer = 1 To totalLoc + 3
            If x <= totalLoc Then
                rng = colExcel(col + x) & kolAw & ":" & colExcel(col + 1 + x) & kolAk & ""
                frm = "=$" & colExcel(col + x) & kolAw & "<>$" & colExcel(col + 1 + x) & kolAw
                ConditionFormatExcel(xlSheet, rng, frm)
            End If
            CellFormat(xlSheet, "range=" & colExcel(col + x) & kolAk + kolTotal & ";fontname=Tahoma;fontsize=9;fontstyle=bold;" & _
                   "verticalalignment=center;horizontalalignment=center", _
                   "=sum(" & colExcel(col + x) & kolAw & ":" & colExcel(col + x) & kolAk & "" & ")")

            CellFormat(xlSheet, "range=" & colExcel(col + 1 + x) & kolAk + kolTotal & ";fontname=Tahoma;fontsize=9;fontstyle=bold;" & _
                   "verticalalignment=center;horizontalalignment=center", _
                   "=sum(" & colExcel(col + 1 + x) & kolAw & ":" & colExcel(col + 1 + x) & kolAk & "" & ")")

            col += 1
        Next

        CellFormat(xlSheet, "range=a" & kolAk + kolTotal & ";fontname=Tahoma;fontsize=9;fontstyle=bold;" & _
                   "verticalalignment=center;horizontalalignment=center", _
                   "Total")
        CellFormat(xlSheet, "range=A" & kolAk + kolTotal & ":E" & kolAk + kolTotal & ";merge=true;")

        dsL.Dispose()
    End Sub
    Sub ConditionFormatExcel(ByVal xlSheet As Excel.Worksheet, ByVal range As String, ByVal Formula As String)
        Dim rng As Excel.Range = xlSheet.Range(range)
        Dim efc As Excel.FormatCondition
        With rng.FormatConditions
            .Delete()
            .Add(Excel.XlFormatConditionType.xlExpression, , Formula)
        End With
        efc = rng.FormatConditions(1)
        efc.Interior.Color = RGB(255, 255, 0)
    End Sub
    Sub QueryPasteToExcel(ByVal xlsheet As Excel.Worksheet, ByVal SQL As String, ByVal range As String)
        Dim dq As DataSet
        Dim fn As String
        dq = QuerySO(SQL)
        fn = "temptxt.txt"
        DatasetToTxtFiles(dq, fn)
        isiText = File.ReadAllText(fn)
        startth = New Thread(AddressOf MYTHREAD)
        startth.SetApartmentState(ApartmentState.STA)
        startth.Start()
        'MsgOK("Proses " & fn)
        xlsheet.Range(range).Select()
        xlsheet.Range(range).PasteSpecial()
    End Sub
    Sub TextPasteToExcel(ByVal xlsheet As Excel.Worksheet, ByVal fn As String, ByVal range As String)
        isiText = File.ReadAllText(fn)
        'Dbg(isiText)
        startth = New Thread(AddressOf MYTHREAD)
        startth.SetApartmentState(ApartmentState.STA)
        startth.Start()
        MsgOK("Proses " & fn)
        'MsgOK(strPesan)
        Thread.Sleep(50)
        xlsheet.Range(range).Select()
        xlsheet.Range(range).PasteSpecial()
    End Sub
    Sub DatasetToTxtFiles(ByVal dd As DataSet, ByVal fn As String)
        Dim sw As New IO.StreamWriter(fn)
        Dim s As String = ""
        For Each ro As DataRow In dd.Tables(0).Rows
            s = ""
            For x As Integer = 0 To dd.Tables(0).Columns.Count - 1
                s += ro(x).ToString.Trim & vbTab
            Next
            sw.Write(s & vbNewLine)
        Next
        sw.Close()
        sw.Dispose()
    End Sub
    Sub JudulExcelPDT(ByVal xlSheet As Excel.Worksheet, Optional ByVal row As Integer = 5)

        CellFormat(xlSheet, "range=a" & row & ";fontname=Tahoma;fontsize=9;fontstyle=bold;" & _
                   "verticalalignment=center;horizontalalignment=center;wrap=true", _
                   "PLU")

        CellFormat(xlSheet, "range=b" & row & ";fontname=Tahoma;fontsize=9;fontstyle=bold;" & _
                  "verticalalignment=center;horizontalalignment=center;wrap=true", _
                  "Article Code")

        CellFormat(xlSheet, "range=C" & row & ";fontname=Tahoma;fontsize=9;fontstyle=bold;" & _
                  "verticalalignment=center;horizontalalignment=center;wrap=true", _
                  "SBU")

        CellFormat(xlSheet, "range=D" & row & ";fontname=Tahoma;fontsize=9;fontstyle=bold;" & _
                  "verticalalignment=center;horizontalalignment=center;wrap=true", _
                  "Description")

        CellFormat(xlSheet, "range=E" & row & ";fontname=Tahoma;fontsize=9;fontstyle=bold;" & _
                  "verticalalignment=center;horizontalalignment=center;wrap=true", _
                  "Price")

        Dim dsL As DataSet
        Dim x As Integer = 6
        Dim namatable2, nk As String

        namatable2 = "tempexcel2_" & txtIDCompare.Text
        dsL = QuerySO("select top 1 * from " & namatable2)
        For k As Integer = 0 To dsL.Tables(0).Columns.Count
            If k < 5 Then
            ElseIf k >= 5 And k <= dsL.Tables(0).Columns.Count - 7 Then
                nk = dsL.Tables(0).Columns(k).ColumnName
                nk = Replace(nk, "_", " ")
                nk = StrConv(nk, VbStrConv.ProperCase)
                CellFormat(xlSheet, "range=" & colExcel(k + 1) & "" & row & ";fontname=Tahoma;fontsize=9;fontstyle=bold;" & _
                  "verticalalignment=center;horizontalalignment=center;wrap=true", _
                  nk)
                x += 1
            End If

        Next

        CellFormat(xlSheet, "range=" & colExcel(x) & "" & row & ";fontname=Tahoma;fontsize=9;fontstyle=bold;" & _
                   "verticalalignment=center;horizontalalignment=center;wrap=true", _
                   "Stock Checker")

        x += 1
        CellFormat(xlSheet, "range=" & colExcel(x) & "" & row & ";fontname=Tahoma;fontsize=9;fontstyle=bold;" & _
                   "verticalalignment=center;horizontalalignment=center;wrap=true", _
                   "Stock Counter")

        x += 1
        CellFormat(xlSheet, "range=" & colExcel(x) & "" & row & ";fontname=Tahoma;fontsize=9;fontstyle=bold;" & _
                   "verticalalignment=center;horizontalalignment=center;wrap=true", _
                   "Check PDT")

        x += 1
        CellFormat(xlSheet, "range=" & colExcel(x) & "" & row & ";fontname=Tahoma;fontsize=9;fontstyle=bold;" & _
                   "verticalalignment=center;horizontalalignment=center;wrap=true", _
                   "Stock SAP")

        x += 1
        CellFormat(xlSheet, "range=" & colExcel(x) & "" & row & ";fontname=Tahoma;fontsize=9;fontstyle=bold;" & _
                   "verticalalignment=center;horizontalalignment=center;wrap=true", _
                   "Selisih Qty")

        x += 1
        CellFormat(xlSheet, "range=" & colExcel(x) & "" & row & ";fontname=Tahoma;fontsize=9;fontstyle=bold;" & _
                   "verticalalignment=center;horizontalalignment=center;wrap=true", _
                   "Selisih Price")

        dsL.Dispose()
    End Sub

    Sub CreateTempTxt()
        Dim dsS, dsE As DataSet
        Dim namatable, lbl As String
        Dim s As String = ""
        Dim total, rw As Integer
        total = 0 : rw = 0
        namatable = "tempexcel_" & Replace(idCompare, " ", "")
        dsE = QuerySO("Select count(*) from " & namatable & " ")
        total = CInt(dsE.Tables(0).Rows(0).Item(0).ToString.Trim)
        dsS = QuerySO("select sbu from tempitem where plu in (select plu from tempoutput) group by sbu order by sbu")

        rw = 0
        For Each rs As DataRow In dsS.Tables(0).Rows
            dsE = QuerySO("Select * from " & namatable & " where sbu in ('" & rs("sbu").ToString.Trim & "') order by sbu, plu")
            'Using sw As StreamWriter = New StreamWriter("temp" & rs("sbu").ToString.Trim & ".txt")
            Dim sw As New IO.StreamWriter("temp" & rs("sbu").ToString.Trim & ".txt")
            For Each ro As DataRow In dsE.Tables(0).Rows
                s = "" : rw += 1
                lbl = "Create Temp " & rs("sbu").ToString.Trim & " Txt, PLU : " & ro("plu").ToString.Trim
                Try : setLabelTxt(lbl, Label5) : Catch ex As Exception : End Try
                Prg = CInt((rw * 100) / total)
                BackgroundWorker2.ReportProgress(Prg)
                For x As Integer = 0 To dsE.Tables(0).Columns.Count - 1
                    s += ro(x).ToString.Trim & vbTab
                Next
                sw.Write(s & vbNewLine)
            Next
            sw.Close()
            sw.Dispose()
        Next

        dsE.Dispose()
        dsS.Dispose()
    End Sub
    Sub CreateExcel()
        Dim pathName, sh, lbl As String
        Dim dsS As DataSet
        dsS = QuerySO("select sbu from tempitem where plu in (select plu from tempoutput) group by sbu order by sbu")
        sh = "sheetname="
        For Each rs As DataRow In dsS.Tables(0).Rows
            sh += rs("sbu").ToString.Trim & ","
        Next
        sh = Mid(sh, 1, Len(sh) - 1) & ";"
        pathName = TextBox1.Text & Microsoft.VisualBasic.Right(ComboBox1.Text, 4) & "-" & _
                   Replace(vtglopstr, "-", "") & ".xls"
        PrepareExcel(sh, pathName)

        Dim x As Integer = 1
        For Each rs As DataRow In dsS.Tables(0).Rows
            lbl = "Process Excel, Brand : " & rs("sbu").ToString.Trim
            Try : setLabelTxt(lbl, Label5) : Catch ex As Exception : End Try
            Prg = CInt((x * 100) / dsS.Tables(0).Rows.Count)
            BackgroundWorker2.ReportProgress(Prg)

            JudulExcel(xlWorkSheet(x - 1), rs("sbu").ToString.Trim)
            ProcessExcel(xlWorkSheet(x - 1), rs("sbu").ToString.Trim)
            'tes(xlWorkSheet(x - 1), rs("sbu").ToString.Trim)
            x += 1
        Next

        SaveExcel()
        DestroyExcel()
        dsS.Dispose()
    End Sub
    Sub tes(ByVal xlSheet As Excel.Worksheet, ByVal Brand As String)
        With xlSheet.Range("F6:G6").FormatConditions.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlGreater, ">10")
            With .Borders
                '.LineStyle = xlContinuous
                '.Weight = xlThin
                .ColorIndex = 6
            End With
            With .Font
                .Bold = True
                .ColorIndex = 3
            End With
        End With

        'With Worksheets(1).Range("e1:e10").FormatConditions.Add(xlCellValue, xlGreater, "=$a$1")
        '    With .Borders
        '        .LineStyle = xlContinuous
        '        .Weight = xlThin
        '        .ColorIndex = 6
        '    End With
        '    With .Font
        '        .Bold = True
        '        .ColorIndex = 3
        '    End With
        'End With
    End Sub
    Sub JudulExcel(ByVal xlSheet As Excel.Worksheet, ByVal Brand As String)
        CellFormat(xlSheet, "range=a1;fontname=Tahoma;fontsize=12;fontstyle=bold", _
                   "Report Selisih Stock Opname " & Microsoft.VisualBasic.Right(ComboBox1.Text, 4) & " (" & Brand & ") ")

        CellFormat(xlSheet, "range=a2;fontname=Tahoma;fontsize=12;fontstyle=bold", _
                   "Periode : " & Format(Date.Parse(vtglopstr), "dd-MMMM-yyyy") & "")
        CellFormat(xlSheet, "range=a4;fontname=Tahoma;fontsize=10;fontstyle=bold;" & _
                   "verticalalignment=center;horizontalalignment=center;columnwidth=14", _
                   "PLU")
        CellFormat(xlSheet, "range=A4:A5;merge=true;")

        CellFormat(xlSheet, "range=b4;fontname=Tahoma;fontsize=10;fontstyle=bold;" & _
                   "verticalalignment=center;horizontalalignment=center;columnwidth=14", _
                   "Article Code")
        CellFormat(xlSheet, "range=B4:B5;merge=true;")

        CellFormat(xlSheet, "range=c4;fontname=Tahoma;fontsize=10;fontstyle=bold;" & _
                   "verticalalignment=center;horizontalalignment=center;columnwidth=14", _
                   "SBU")
        CellFormat(xlSheet, "range=C4:C5;merge=true;")

        CellFormat(xlSheet, "range=d4;fontname=Tahoma;fontsize=10;fontstyle=bold;" & _
                   "verticalalignment=center;horizontalalignment=center;columnwidth=46", _
                   "Description")
        CellFormat(xlSheet, "range=D4:D5;merge=true;")

        CellFormat(xlSheet, "range=e4;fontname=Tahoma;fontsize=10;fontstyle=bold;" & _
                   "verticalalignment=center;horizontalalignment=center;columnwidth=10", _
                   "Price")
        CellFormat(xlSheet, "range=E4:E5;merge=true;")

        Dim dsL As DataSet
        Dim x As Integer = 6
        dsL = QuerySO("select distinct location from tempoutput order by location")
        For Each ro As DataRow In dsL.Tables(0).Rows
            CellFormat(xlSheet, "range=" & colExcel(x) & "4;fontname=Tahoma;fontsize=10;fontstyle=bold;" & _
                   "verticalalignment=center;horizontalalignment=center;columnwidth=8.43;wrap=true;", _
                   "Loc" & Replace(ro("location").ToString.Trim, "Location", "") & " Checker")
            CellFormat(xlSheet, "range=" & colExcel(x) & "4:" & colExcel(x) & "5;merge=true;")
            x += 1
            CellFormat(xlSheet, "range=" & colExcel(x) & "4;fontname=Tahoma;fontsize=10;fontstyle=bold;" & _
                       "verticalalignment=center;horizontalalignment=center;columnwidth=8.43;wrap=true;", _
                       "Loc" & Replace(ro("location").ToString.Trim, "Location", "") & " Counter")
            CellFormat(xlSheet, "range=" & colExcel(x) & "4:" & colExcel(x) & "5;merge=true;")
            x += 1
        Next

        CellFormat(xlSheet, "range=" & colExcel(x) & "4;fontname=Tahoma;fontsize=10;fontstyle=bold;" & _
                   "verticalalignment=center;horizontalalignment=center;columnwidth=8.43;wrap=true;", _
                   "Stock Checker")
        CellFormat(xlSheet, "range=" & colExcel(x) & "4:" & colExcel(x) & "5;merge=true;")
        x += 1
        CellFormat(xlSheet, "range=" & colExcel(x) & "4;fontname=Tahoma;fontsize=10;fontstyle=bold;" & _
                   "verticalalignment=center;horizontalalignment=center;columnwidth=8.43;wrap=true;", _
                   "Stock Counter")
        CellFormat(xlSheet, "range=" & colExcel(x) & "4:" & colExcel(x) & "5;merge=true;")
        x += 1
        CellFormat(xlSheet, "range=" & colExcel(x) & "4;fontname=Tahoma;fontsize=10;fontstyle=bold;" & _
                   "verticalalignment=center;horizontalalignment=center;columnwidth=8.43;wrap=true;", _
                   "Cek PDT")
        CellFormat(xlSheet, "range=" & colExcel(x) & "4:" & colExcel(x) & "5;merge=true;")
        x += 1
        CellFormat(xlSheet, "range=" & colExcel(x) & "4;fontname=Tahoma;fontsize=10;fontstyle=bold;" & _
                   "verticalalignment=center;horizontalalignment=center;columnwidth=8.43;wrap=true;", _
                   "Stock SAP")
        CellFormat(xlSheet, "range=" & colExcel(x) & "4:" & colExcel(x) & "5;merge=true;")
        x += 1
        CellFormat(xlSheet, "range=" & colExcel(x) & "4;fontname=Tahoma;fontsize=10;fontstyle=bold;" & _
                   "verticalalignment=center;horizontalalignment=center;columnwidth=8.43;wrap=true;", _
                   "Selisih")
        CellFormat(xlSheet, "range=" & colExcel(x) & "4:" & colExcel(x + 1) & "4;merge=true;")

        CellFormat(xlSheet, "range=" & colExcel(x) & "5;fontname=Tahoma;fontsize=10;fontstyle=bold;" & _
                   "verticalalignment=center;horizontalalignment=center;columnwidth=8.43;", _
                   "Qty")
        x += 1
        CellFormat(xlSheet, "range=" & colExcel(x) & "5;fontname=Tahoma;fontsize=10;fontstyle=bold;" & _
                   "verticalalignment=center;horizontalalignment=center;columnwidth=8.43;", _
                   "Price")

        CellFormat(xlSheet, "range=A:A;numberformat=@")
        CellFormat(xlSheet, "range=B:B;numberformat=@")
        For i As Integer = 5 To x
            CellFormat(xlSheet, "range=" & colExcel(i) & ":" & colExcel(i) & ";numberformat=#,##0")
        Next

        dsL.Dispose()
    End Sub
    Sub ProcessExcel(ByVal xlSheet As Excel.Worksheet, ByVal Brand As String)
        Dim fn, namacell, isicell As String
        Dim totalLine As Integer
        Dim dsE As DataSet
        fn = "temp" & Brand & ".txt"
        isiText = File.ReadAllText(fn)
        totalLine = File.ReadAllLines(fn).Length

        startth = New Thread(AddressOf MYTHREAD)
        startth.SetApartmentState(ApartmentState.STA)
        startth.Start()
        xlSheet.Activate()
        xlSheet.Range("C6").Select()
        xlApp.ActiveWindow.FreezePanes = True

        xlSheet.Range("A6").PasteSpecial()
        Dim namatable As String
        namatable = "tempexcel_" & Replace(idCompare, " ", "")
        dsE = QuerySO("select top 1 * from " & namatable & " ")
        For x As Integer = 6 To dsE.Tables(0).Columns.Count
            namacell = colExcel(x) & 6 + totalLine
            isicell = "=sum(" & colExcel(x) & "6:" & colExcel(x) & 5 + totalLine & ")"
            'Dbg("namacell : " & namacell & vbCrLf & _
            '    "isicell : " & isicell)
            CellFormat(xlSheet, "range=" & namacell & "", isicell)
        Next
        'CellFormat(xlSheet, "range=F" & 6 + totalLine & "", "=sum(F6:F" & 5 + totalLine & ")")
        'CellFormat(xlSheet, "range=G" & 6 + totalLine & "", "=sum(G6:G" & 5 + totalLine & ")")

        'xlSheet.Range("A6").PasteSpecial()

        'xlWorkSheet(0).Range("A4:" & colExcel(colLast) & rowLast).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
        'xlSheet.Range("C6").Application.ActiveWindow.FreezePanes = True
        'xlApp.ActiveWindow.FreezePanes = True
        'xlSheet.Range("A6").Select()
        'xlSheet.Paste()
    End Sub
    Private Sub MYTHREAD()
        'AppActivate("Untitled - Notepad")
        My.Computer.Clipboard.SetText(isiText)
        'SendKeys.SendWait("^(v) {Enter}")
        'My.Computer.Clipboard.SetText(TextBox2.Text)
        'SendKeys.SendWait("^(v) {Enter}")
    End Sub
    Sub ProcessExcelx1(ByVal xlSheet As Excel.Worksheet, ByVal Brand As String)
        Dim dsI, dsL, dsS As DataSet
        Dim s As String
        s = "SELECT a.plu as plu, a.article as article_code, a.sbu, a.description, a.price, " & vbCrLf & _
                      "b.stock as stock_sap " & vbCrLf & _
                      "FROM tempitem a " & vbCrLf & _
                      "left join stock_sys b on a.plu=b.plu and a.sbu=b.sbu " & vbCrLf & _
                      "where convert(varchar(10), b.Tgl_SO, 20) = '" & vtglopstr & "' and a.sbu='" & Brand & "' " & vbCrLf & _
                      "order by a.sbu, a.plu "
        'Dbg(s)
        dsI = QuerySO(s)
        dsL = QuerySO("select distinct location from tempoutput order by location")
        dsS = QuerySO("select top 1 * from tempoutput")

        Dim rw, co, ho, tk As Integer
        Dim lbl, colHO, colTK, colLast, rowLast As String
        colLast = 5 + (dsL.Tables(0).Rows.Count * 2) + 3
        rw = 5
        For Each rI As DataRow In dsI.Tables(0).Rows
            rw += 1
            lbl = "Create Excel, PLU : " & rI("plu").ToString.Trim
            Try : setLabelTxt(lbl, Label5) : Catch ex As Exception : End Try
            Prg = CInt(((rw - 5) * 100) / dsI.Tables(0).Rows.Count)
            BackgroundWorker2.ReportProgress(Prg)
            '#,##0.00
            CellFormat(xlSheet, "range=A" & rw & ";fontname=Tahoma;fontsize=9;" & _
                       "verticalalignment=center;horizontalalignment=right;numberformat=###", _
                       rI("plu").ToString.Trim)
            CellFormat(xlSheet, "range=B" & rw & ";fontname=Tahoma;fontsize=9;" & _
                       "verticalalignment=center;horizontalalignment=right;numberformat=###", _
                       rI("article_code").ToString.Trim)
            CellFormat(xlSheet, "range=C" & rw & ";fontname=Tahoma;fontsize=9;" & _
                       "verticalalignment=center;horizontalalignment=right;numberformat=@", _
                       rI("sbu").ToString.Trim)
            CellFormat(xlSheet, "range=D" & rw & ";fontname=Tahoma;fontsize=9;" & _
                       "verticalalignment=center;horizontalalignment=right;numberformat@", _
                       rI("description").ToString.Trim)
            CellFormat(xlSheet, "range=E" & rw & ";fontname=Tahoma;fontsize=9;" & _
                       "verticalalignment=center;horizontalalignment=right;numberformat=#,##0", _
                       rI("price").ToString.Trim)
            co = 6
            For Each rL As DataRow In dsL.Tables(0).Rows
                dsS = QuerySO("select sum(jml) as jml from tempoutput where tipe='HO' " & vbCrLf & _
                              "and location='" & rL("location").ToString.Trim & "' and plu='" & rI("plu").ToString.Trim & "' ")
                If dsS.Tables(0).Rows.Count > 0 Then
                    If Not IsDBNull(dsS.Tables(0).Rows(0).Item("jml")) Then
                        ho = CInt(dsS.Tables(0).Rows(0).Item("jml").ToString.Trim) : Else : ho = 0
                    End If
                Else
                    ho = 0
                End If
                colHO = colExcel(co) & rw
                CellFormat(xlSheet, "range=" & colHO & ";fontname=Tahoma;fontsize=9;" & _
                            "verticalalignment=center;horizontalalignment=right;numberformat=#,##0", _
                            ho)

                co += 1 'set column
                dsS = QuerySO("select sum(jml) as jml from tempoutput where tipe='TK' " & vbCrLf & _
                              "and location='" & rL("location").ToString.Trim & "' and plu='" & rI("plu").ToString.Trim & "' ")
                If dsS.Tables(0).Rows.Count > 0 Then
                    If Not IsDBNull(dsS.Tables(0).Rows(0).Item("jml")) Then
                        tk = CInt(dsS.Tables(0).Rows(0).Item("jml").ToString.Trim) : Else : tk = 0
                    End If
                Else
                    tk = 0
                End If
                colTK = colExcel(co) & rw
                CellFormat(xlWorkSheet(0), "range=" & colTK & ";fontname=Tahoma;fontsize=9;" & _
                                "verticalalignment=center;horizontalalignment=right;numberformat=#,##0", _
                                tk)

                If ho <> tk Then
                    CellFormat(xlWorkSheet(0), "range=" & colHO & ";backcolor=255,255,0")
                    CellFormat(xlWorkSheet(0), "range=" & colTK & ";backcolor=255,255,0")
                    CellFormat(xlWorkSheet(0), "range=A" & rw & ";backcolor=255,255,0")
                End If
                co += 1
            Next

            'CellFormat(xlWorkSheet(0), "range=" & colExcel(co) & rw & ";fontname=Tahoma;fontsize=9;" & _
            '                            "verticalalignment=center;horizontalalignment=right;numberformat=#,##0", _
            '                            rI("stock_so").ToString.Trim)
            co += 3 'set column
            CellFormat(xlWorkSheet(0), "range=" & colExcel(co) & rw & ";fontname=Tahoma;fontsize=9;" & _
                                    "verticalalignment=center;horizontalalignment=right;numberformat=#,##0", _
                                    rI("stock_sap").ToString.Trim)
            'co += 1 'set column
            'CellFormat(xlWorkSheet(0), "range=" & colExcel(co) & rw & ";fontname=Tahoma;fontsize=9;" & _
            '                        "verticalalignment=center;horizontalalignment=right;numberformat=#,##0", _
            '                        rI("selisih").ToString.Trim)
        Next
        rowLast = rw - 1
        dsI.Dispose()
        dsS.Dispose()
        dsL.Dispose()
    End Sub
    Sub ProcessExcelx()
        Dim dsI, dsL, dss As DataSet
        'perbaiki disini
        dsI = QuerySAP("select * from " & vbCrLf & _
                       "( " & vbCrLf & _
                       "   select a.plu as PLU, a.article as Article_Code, b.brand as SBU, " & vbCrLf & _
                       "       a.description as Description, b.price as Price, " & vbCrLf & _
                       "       b.qty as Stock_SO, a.stock as Stock_SAP, (b.qty - a.stock) as Selisih " & vbCrLf & _
                       "   from tempsap a " & vbCrLf & _
                       "   inner join tempso b on a.article = b.article_code " & vbCrLf & _
                       "   group by a.plu, a.article, b.brand, a.description, b.price, b.qty, a.stock " & vbCrLf & _
                       ") a order by plu")
        dsI = QuerySO("select * from tempcsv")
        dsL = QuerySO("select distinct location from tempoutput order by location")
        dss = QuerySO("select distinct location from tempoutput order by location")
        Dim rw, co, ho, tk As Integer
        Dim lbl, colHO, colTK, colLast, rowLast As String

        colLast = 5 + (dsL.Tables(0).Rows.Count * 2) + 3
        rw = 5
        For Each rI As DataRow In dsI.Tables(0).Rows
            lbl = "Create Excel, PLU : " & rI("plu").ToString.Trim
            Try : setLabelTxt(lbl, Label5) : Catch ex As Exception : End Try
            Prg = CInt(((rw - 5) * 100) / dsI.Tables(0).Rows.Count)
            BackgroundWorker2.ReportProgress(Prg)
            '#,##0.00
            CellFormat(xlWorkSheet(0), "range=A" & rw & ";fontname=Tahoma;fontsize=9;" & _
                       "verticalalignment=center;horizontalalignment=right;numberformat=###", _
                       rI("plu").ToString.Trim)
            CellFormat(xlWorkSheet(0), "range=B" & rw & ";fontname=Tahoma;fontsize=9;" & _
                       "verticalalignment=center;horizontalalignment=right;numberformat=###", _
                       rI("article_code").ToString.Trim)
            CellFormat(xlWorkSheet(0), "range=C" & rw & ";fontname=Tahoma;fontsize=9;" & _
                       "verticalalignment=center;horizontalalignment=right;numberformat=@", _
                       rI("sbu").ToString.Trim)
            CellFormat(xlWorkSheet(0), "range=D" & rw & ";fontname=Tahoma;fontsize=9;" & _
                       "verticalalignment=center;horizontalalignment=right;numberformat@", _
                       rI("description").ToString.Trim)
            CellFormat(xlWorkSheet(0), "range=E" & rw & ";fontname=Tahoma;fontsize=9;" & _
                       "verticalalignment=center;horizontalalignment=right;numberformat=#,##0", _
                       rI("price").ToString.Trim)
            'location
            co = 6 'set column
            For Each rL As DataRow In dsL.Tables(0).Rows
                dss = QuerySO("select sum(jml) as jml from tempoutput where tipe='HO' " & vbCrLf & _
                              "and location='" & rL("location").ToString.Trim & "' and plu='" & rI("plu").ToString.Trim & "' ")
                If dss.Tables(0).Rows.Count > 0 Then
                    If Not IsDBNull(dss.Tables(0).Rows(0).Item("jml")) Then
                        ho = CInt(dss.Tables(0).Rows(0).Item("jml").ToString.Trim) : Else : ho = 0
                    End If
                Else
                    ho = 0
                End If
                colHO = colExcel(co) & rw
                CellFormat(xlWorkSheet(0), "range=" & colHO & ";fontname=Tahoma;fontsize=9;" & _
                            "verticalalignment=center;horizontalalignment=right;numberformat=#,##0", _
                            ho)

                co += 1 'set column
                dss = QuerySO("select sum(jml) as jml from tempoutput where tipe='TK' " & vbCrLf & _
                              "and location='" & rL("location").ToString.Trim & "' and plu='" & rI("plu").ToString.Trim & "' ")
                If dss.Tables(0).Rows.Count > 0 Then
                    If Not IsDBNull(dss.Tables(0).Rows(0).Item("jml")) Then
                        tk = CInt(dss.Tables(0).Rows(0).Item("jml").ToString.Trim) : Else : tk = 0
                    End If
                Else
                    tk = 0
                End If
                colTK = colExcel(co) & rw
                CellFormat(xlWorkSheet(0), "range=" & colTK & ";fontname=Tahoma;fontsize=9;" & _
                                "verticalalignment=center;horizontalalignment=right;numberformat=#,##0", _
                                tk)

                If ho <> tk Then
                    CellFormat(xlWorkSheet(0), "range=" & colHO & ";backcolor=255,255,0")
                    CellFormat(xlWorkSheet(0), "range=" & colTK & ";backcolor=255,255,0")
                    CellFormat(xlWorkSheet(0), "range=A" & rw & ";backcolor=255,255,0")
                End If
                co += 1
            Next

            'selisih
            CellFormat(xlWorkSheet(0), "range=" & colExcel(co) & rw & ";fontname=Tahoma;fontsize=9;" & _
                                    "verticalalignment=center;horizontalalignment=right;numberformat=#,##0", _
                                    rI("stock_so").ToString.Trim)
            co += 1 'set column
            CellFormat(xlWorkSheet(0), "range=" & colExcel(co) & rw & ";fontname=Tahoma;fontsize=9;" & _
                                    "verticalalignment=center;horizontalalignment=right;numberformat=#,##0", _
                                    rI("stock_sap").ToString.Trim)
            co += 1 'set column
            CellFormat(xlWorkSheet(0), "range=" & colExcel(co) & rw & ";fontname=Tahoma;fontsize=9;" & _
                                    "verticalalignment=center;horizontalalignment=right;numberformat=#,##0", _
                                    rI("selisih").ToString.Trim)
            If CInt(rI("selisih").ToString.Trim) <> 0 Then
                CellFormat(xlWorkSheet(0), "range=A" & rw & ";backcolor=255,255,0")
                CellFormat(xlWorkSheet(0), "range=" & colExcel(co) & rw & ";backcolor=255,255,0")
            End If
            rw += 1
        Next
        rowLast = rw - 1
        'MsgOK("A4:" & colExcel(colLast) & rowLast)
        xlWorkSheet(0).Range("A4:" & colExcel(colLast) & rowLast).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
        xlWorkSheet(0).Range("C5").Select()
        xlApp.ActiveWindow.FreezePanes = True
        dsI.Dispose()
        dsL.Dispose()
    End Sub
#End Region
    Private Sub BackgroundWorker2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        wrkend = False
        'MsgOK("1")
        ProcessTextFile()
        'MsgOK("2")
        StockToko()
        'MsgOK("3")
        isiTempExcel()
        'MsgOK("4")
        CreateTempTxt()
        MsgOK("Proses Selisih PDT" & vbCrLf & _
              "Klik OK Untuk melanjutkan")
        CreateSelisihPDT()
        'MsgOK("6")


        ''CreateExcel()
        ''MsgOK("4")
        ''Excel2()
    End Sub

    Sub Excel2()
        Dim pathName, sh As String
        sh = "sheetname=stok;"
        pathName = TextBox1.Text & Microsoft.VisualBasic.Right(ComboBox1.Text, 4) & "-" & _
                   Replace(vtglopstr, "-", "") & ".xls"
        PrepareExcel(sh, pathName)
        CellFormat(xlWorkSheet(0), "range=a1", "10")
        CellFormat(xlWorkSheet(0), "range=b1", "12")
        CellFormat(xlWorkSheet(0), "range=a2", "1")
        CellFormat(xlWorkSheet(0), "range=b2", "2")
        CellFormat(xlWorkSheet(0), "range=a3", "5")
        CellFormat(xlWorkSheet(0), "range=b3", "8")

        Dim rng As Excel.Range = xlWorkSheet(0).Range("A1:B3")
        Dim efc As Excel.FormatCondition

        With rng.FormatConditions
            .Delete()
            .Add(Excel.XlFormatConditionType.xlExpression, , "=$A1<>$B1")
        End With

        efc = rng.FormatConditions(1)
        efc.Interior.ColorIndex = 34


        'Range("A1:A11").Select()
        'Selection.FormatConditions.Add(Type:=xlExpression, Formula1:="=LEN(TRIM(A1))=0")
        'Selection.FormatConditions(Selection.FormatConditions.Count).SetFirstPriority()
        'With Selection.FormatConditions(1).Interior
        '    .PatternColorIndex = xlAutomatic
        '    .ThemeColor = xlThemeColorDark1
        '    .TintAndShade = -0.249946592608417
        'End With
        'Selection.FormatConditions(1).StopIfTrue = False

        SaveExcel()
        DestroyExcel()
    End Sub
    Private Sub BackgroundWorker2_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker2.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
    End Sub
    Private Sub BackgroundWorker2_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        If wrkend = True Then
            Label5.Text = "Problem During Proccessed!!!"
        Else
            Label5.Text = "Done !!! "
        End If
        wrkend = False
        GroupBox2.Enabled = True
        ProgressBar1.Visible = False
        Prg = 0
        If wrkend = False Then MsgOK("Finished")

        OpenExcel(pathName)
    End Sub
    Private Sub BtnDataRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDataRead.Click
        Process.Start("Data_Read.exe")
    End Sub
    Private Sub BtnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowse.Click
        With FolderBrowserDialog1
            .SelectedPath = ScanFile
            .Description = _
            "Select the directory that you want to use As the default."
        End With
        Dim OP As Integer = FolderBrowserDialog1.ShowDialog()
        If OP = DialogResult.OK Then
            TextBox1.Text = FolderBrowserDialog1.SelectedPath.ToString & "\"
        Else
            TextBox1.Text = ScanFile
        End If
    End Sub
    Private Sub BtnUploadScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUploadScan.Click
        vtglop = DateTimePicker1.Value.AddDays(-1)
        vtglopstr = Format(vtglop, "yyyy-MM-dd")
        tipeOutput = "scan"
        idCompare = txtIDCompare.Text

        ds.Clear()
        ds = QuerySO("select top 1 * from stock_sys where branch_id = '" & Microsoft.VisualBasic.Right(ComboBox1.Text.Trim, 4) & "' " & vbCrLf & _
               "and convert( varchar(10), tgl_so, 20) = '" & vtglopstr & "' ")
        If ds.Tables(0).Rows.Count = 0 Then
            If MsgConfirm("Proses Stock SAP Untuk SO TGL " & vtglopstr & " Belum Dilakukan" & vbCrLf & _
                          "Jika Dilanjutkan Stock SAP = 0" & vbCrLf & _
                          "Ingin Tetap Dilanjutkan ?") <> vbYes Then
                ds.Clear()
                Exit Sub
            End If
        End If

        If cekFileName() = False Then Exit Sub
        CheckForIllegalCrossThreadCalls = False
        ProgressBar1.Value = 0
        ProgressBar1.Visible = True
        GroupBox2.Enabled = False
        BackgroundWorker2.WorkerReportsProgress = True
        BackgroundWorker2.WorkerSupportsCancellation = True
        BackgroundWorker2.RunWorkerAsync()
    End Sub
    Private Sub BtnComparePDT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnComparePDT.Click

    End Sub

    Private Sub BtnDataFinal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDataFinal.Click
        ContextMenuStrip1.Show(BtnDataFinal, 0, BtnDataFinal.Height)
    End Sub


    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

    End Sub

    Private Sub BtnEditSelisih_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditSelisih.Click
        FrmSelisihPDT.txtTglSO.Text = Format(Now.AddDays(-1), "yyyy-MM-dd")
        FrmSelisihPDT.txtIDCompare.Text = txtIDCompare.Text
        FrmSelisihPDT.ShowDialog()
    End Sub

    Private Sub PrintSelisihPDTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintSelisihPDTToolStripMenuItem.Click
        vtglop = DateTimePicker1.Value.AddDays(-1)
        vtglopstr = Format(vtglop, "yyyy-MM-dd")
        idCompare = txtIDCompare.Text
        pathName = ExcelFile & Microsoft.VisualBasic.Right(ComboBox1.Text, 4) & "-" & _
                   Replace(vtglopstr, "-", "") & "-PDT.xls"
        CreateSelisihPDT()
        MsgOK("Finished")
        OpenExcel(pathName)
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub PrintFinalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintFinalToolStripMenuItem.Click
        vtglop = DateTimePicker1.Value.AddDays(-1)
        vtglopstr = Format(vtglop, "yyyy-MM-dd")
        tipeOutput = "scan"
        idCompare = txtIDCompare.Text

        ds.Clear()
        ds = QuerySO("select top 1 * from stock_sys where branch_id = '" & Microsoft.VisualBasic.Right(ComboBox1.Text.Trim, 4) & "' " & vbCrLf & _
               "and convert( varchar(10), tgl_so, 20) = '" & vtglopstr & "' ")
        If ds.Tables(0).Rows.Count = 0 Then
            If MsgConfirm("Proses Stock SAP Untuk SO TGL " & vtglopstr & " Belum Dilakukan" & vbCrLf & _
                          "Jika Dilanjutkan Stock SAP = 0" & vbCrLf & _
                          "Ingin Tetap Dilanjutkan ?") <> vbYes Then
                ds.Clear()
                Exit Sub
            End If
        End If
        CheckForIllegalCrossThreadCalls = False
        ProgressBar1.Value = 0
        ProgressBar1.Visible = True
        GroupBox2.Enabled = False
        BackgroundWorker1.WorkerReportsProgress = True
        BackgroundWorker1.WorkerSupportsCancellation = True
        BackgroundWorker1.RunWorkerAsync()
    End Sub
    Sub isiTempExcel2()
        BackgroundWorker1.ReportProgress(0)
        Dim dsL As DataSet
        Dim s, plus1, plus2, loc As String
        Dim namatable2 As String
        namatable2 = "tempexcel2_" & Replace(idCompare, " ", "")
        plus1 = "" : plus2 = ""

        dsL = QuerySO("select distinct location from tempoutput order by location")
        For Each rL As DataRow In dsL.Tables(0).Rows
            loc = rL("location").ToString.Trim
            s = "update a set a." & loc & "_counter=b." & loc & "_counter " & vbCrLf & _
                "from tempexcel2_a a inner join " & vbCrLf & _
                "( " & vbCrLf & _
                "     select plu, [" & loc & "] as " & loc & "_counter " & vbCrLf & _
                "     from ( select location, plu, sum(jml) as qty from tempOutPut2 " & vbCrLf & _
                "            where tipe='TK' group by tipe, location, plu ) src " & vbCrLf & _
                "     pivot ( sum(qty) for location in ( [" & loc & "] ) ) piv " & vbCrLf & _
                "     where [" & loc & "] Is Not null " & vbCrLf & _
                ") b on a.plu=b.plu"
            If LCase(loc) = "loc07" Or LCase(loc) = "loc08" Then
                'Dbg("tes tk : " & s)
            End If

            ExecSO(s)

            s = "update a set a." & loc & "_checker=b." & loc & "_checker " & vbCrLf & _
                "from tempexcel2_a a inner join " & vbCrLf & _
                "( " & vbCrLf & _
                "     select plu, [" & loc & "] as " & loc & "_checker " & vbCrLf & _
                "     from ( select location, plu, sum(jml) as qty from tempOutPut2 " & vbCrLf & _
                "            where tipe='HO' group by tipe, location, plu ) src " & vbCrLf & _
                "     pivot ( sum(qty) for location in ( [" & loc & "] ) ) piv " & vbCrLf & _
                "     where [" & loc & "] Is Not null " & vbCrLf & _
                ") b on a.plu=b.plu"
            If LCase(loc) = "loc07" Or LCase(loc) = "loc08" Then
                'Dbg("tes HO : " & s)
            End If
            ExecSO(s)

            plus1 += rL("location").ToString.Trim & "_checker+"
            plus2 += rL("location").ToString.Trim & "_counter+"
        Next


        'BackgroundWorker1.ReportProgress(70)
        SetProgress1("Process Final Excel ", 70)
        plus1 = Mid(plus1, 1, Len(plus1) - 1)
        plus2 = Mid(plus2, 1, Len(plus2) - 1)

        s = "update " & namatable2 & " set stock_checker=" & plus1
        ExecSO(s)
        s = "update " & namatable2 & " set stock_counter=" & plus2
        ExecSO(s)
        s = "update " & namatable2 & " set cek_pdt=stock_checker-stock_counter"

        ExecSO("update b " & vbCrLf & _
               "set b.stock_sap=a.stock " & vbCrLf & _
               "from " & namatable2 & " b " & vbCrLf & _
               "inner join stock_sys a on a.plu=b.plu " & vbCrLf & _
               "where a.tgl_so='" & vtglopstr & "' ")
        'BackgroundWorker1.ReportProgress(100)
        SetProgress1("Process Final Excel ", 100)
        ExecSO(s)
        s = "update " & namatable2 & " set selisih_qty=stock_counter-stock_sap"
        ExecSO(s)
        s = "update " & namatable2 & " set selisih_price=selisih_qty*price"
        ExecSO(s)

        dsL.Dispose()
    End Sub

    Sub CreateTempTxt2()
        Dim namatable2, namatable, sql As String
        namatable = "tempexcel_" & Replace(idCompare, " ", "")
        namatable2 = "tempexcel2_" & Replace(idCompare, " ", "")
        sql = "select * from " & namatable & " order by sbu, plu "
        'Dbg(sql)
        QueryToTextFile(sql, "tempmaster.txt")

        sql = "select * from " & namatable2 & " order by sbu, plu "
        'Dbg(sql)
        QueryToTextFile(sql, "temprevision.txt")

        Dim dsL As DataSet
        Dim totalLoc As Integer
        Dim s As String
        dsL = QuerySO("select distinct location from tempoutput order by location")
        totalLoc = dsL.Tables(0).Rows.Count
        s = ""
        For Each rL As DataRow In dsL.Tables(0).Rows
            s += " " & rL("location").ToString.Trim & "_checker<>" & rL("location").ToString.Trim & "_counter or"
        Next
        s = Mid(s, 1, Len(s) - 2)
        s = "select * from " & namatable & " where " & vbCrLf & _
                      s & vbCrLf & _
                      "order by sbu, plu"
        sql = s
        'Dbg(sql)
        'dsL = QuerySO(s)
        'If dsL.Tables(0).Rows.Count > 0 Then
        QueryToTextFile(s, "temppdt.txt")
        'End If

        sql = "select * from " & namatable2 & " where selisih_qty<>0 order by sbu, plu "
        'Dbg(sql)
        'dsL = QuerySO(sql)
        'If dsL.Tables(0).Rows.Count > 0 Then
        QueryToTextFile(sql, "tempsap.txt")
        'End If

        dsL.Dispose()
    End Sub
    Sub SetProgress1(ByVal Title As String, ByVal pct As Integer)
        Try : setLabelTxt(Title, Label5) : Catch ex As Exception : End Try
        BackgroundWorker1.ReportProgress(pct)
    End Sub
    Sub SetProgress2(ByVal Title As String, ByVal pct As Integer)
        Try : setLabelTxt(Title, Label5) : Catch ex As Exception : End Try
        BackgroundWorker2.ReportProgress(pct)
    End Sub
    Sub CreateFinalExcel2()
        Dim totalLinePDT, totalLineSAP As Integer
        totalLinePDT = File.ReadAllLines("temppdt.txt").Length
        totalLineSAP = File.ReadAllLines("tempsap.txt").Length

        pathName = ExcelFile & Microsoft.VisualBasic.Right(ComboBox1.Text, 4) & "-" & _
           Replace(vtglopstr, "-", "") & "-Final.xls"

        SetProgress1("Process Final Excel", 0)
        Dim sh As String
        sh = "sheetname=Source,Revision,Final;"
        PrepareExcel(sh, pathName)

        ProcessSourceRevision(xlWorkSheet(0), "tempmaster.txt")
        ProcessSourceRevision(xlWorkSheet(1), "temprevision.txt")
        'If totalLinePDT > 0 Then
        ProcessSourceRevision(xlWorkSheet(2), "temppdt.txt")
        'End If

        xlWorkSheet(2).Activate()
        CellFormat(xlWorkSheet(2), "range=a4;fontname=Tahoma;fontsize=9;fontstyle=bold", _
                   "Selisih PDT")

        CellFormat(xlWorkSheet(2), "range=a" & 6 + totalLinePDT + 5 & ";fontname=Tahoma;fontsize=9;fontstyle=bold", _
                   "Selisih SAP")
        JudulExcelPDT(xlWorkSheet(2), totalLinePDT + 12)
        If totalLineSAP > 0 Then
            TextPasteToExcel(xlWorkSheet(2), "tempsap.txt", "A" & totalLinePDT + 14)
        End If
        ConditionFormat(xlWorkSheet(2), "tempsap.txt", totalLinePDT + 14)
        SaveExcel()
        DestroyExcel()
    End Sub
    Sub CreateFinalExcel()
        Dim s, sh, namatable, namatable2 As String
        Dim ds1 As DataSet
        Dim x, prg, no As Integer

        SetProgress1("Process Final Excel", 0)
        namatable = "tempexcel_" & Replace(idCompare, " ", "")
        namatable2 = "tempexcel2_" & Replace(idCompare, " ", "")
        pathName = ExcelFile & Microsoft.VisualBasic.Right(ComboBox1.Text, 4) & "-" & _
           Replace(vtglopstr, "-", "") & "-Final.xls"
        's = "" : sh = "sheetname=Source,Revision,SummarySource,SummaryRevision"
        s = "" : sh = "sheetname=Source,Revision"

        ds1 = QuerySO("select i.sbu from tempOutPut t " & vbCrLf & _
                      "left join tempitem i on t.plu=i.plu " & vbCrLf & _
                      "group by i.sbu order by i.sbu")
        For Each ro As DataRow In ds1.Tables(0).Rows
            s = Replace(ro("sbu").ToString.Trim, ",", "")
            sh += "," & s
        Next
        sh += ";"
        'MsgOK(sh)
        PrepareExcel(sh, pathName)
        SetProgress1("Process Final Excel Source", 50)
        strPesan = "Process Source ( 1/" & ds1.Tables(0).Rows.Count + 2 & " )"
        ProcessSourceRevision(xlWorkSheet(0), "select * from " & namatable & " order by sbu, plu ")
        SetProgress1("Process Final Excel Revision", 100)
        strPesan = "Process Revision ( 2/" & ds1.Tables(0).Rows.Count + 2 & " )"
        ProcessSourceRevision(xlWorkSheet(1), "select * from " & namatable2 & " order by sbu, plu ")

        'ProcessSummary(xlWorkSheet(2), "Source")

        'x = 4
        x = 2
        no = 1
        For Each ro As DataRow In ds1.Tables(0).Rows
            s = ro("sbu").ToString.Trim
            prg = CInt((no * 100) / ds1.Tables(0).Rows.Count)
            SetProgress1("Process Final Excel " & s, prg)
            strPesan = "Process " & s & " ( " & x + 1 & "/" & ds1.Tables(0).Rows.Count + 2 & " )"
            ProcessBrandPDT(xlWorkSheet(x), s)
            ProcessBrandSAP(xlWorkSheet(x), s)
            CellFormat(xlWorkSheet(x), "range=A:E;columnwidth=clear")
            CellFormat(xlWorkSheet(x), "paper=A4;orientation=landscape;topmargin=30;bottommargin=30;" & _
                       "leftmargin=20;rightmargin=20;titlerow=$1:$3")
            x += 1
            no += 1
        Next
        SetProgress1("Finished", 100)
        SaveExcel()
        DestroyExcel()
        ds1.Dispose()
    End Sub
    Sub ProcessSummary(ByVal xlSheet As Excel.Worksheet, ByVal nmSheet As String)

    End Sub
    Sub ProcessBrandSAP(ByVal xlSheet As Excel.Worksheet, ByVal brand As String)
        Dim ds1 As DataSet
        Dim totalPDT, totalKolom, totalLine, kolAw, kolAk As Integer
        Dim fn, namatable, namatable2, s As String

        fn = "temptxt.txt"
        totalPDT = File.ReadAllLines(fn).Length
        namatable = "tempexcel_" & Replace(idCompare, " ", "")
        namatable2 = "tempexcel2_" & Replace(idCompare, " ", "")
        s = "select * from " & namatable2 & " where selisih_qty<>0 and sbu='" & brand & "' order by sbu, plu "
        QueryToTextFile(s, fn)

        ds1 = QuerySO("select top 1 * from " & namatable2)
        totalKolom = ds1.Tables(0).Columns.Count
        totalLine = File.ReadAllLines(fn).Length

        If totalPDT = 0 Then : kolAw = totalPDT + 6 : Else : kolAw = totalPDT + 10 : End If
        kolAk = kolAw + totalLine - 1
        xlSheet.Activate()

        If totalLine > 0 Then
            CellFormat(xlSheet, "range=A" & kolAw - 2 & ";fontname=Tahoma;fontsize=9;fontstyle=bold", "Selisih SAP")
            JudulExcelPDT(xlSheet, kolAw - 1)
            TextPasteToExcel(xlSheet, fn, "A" & kolAw)
            CellFormat(xlSheet, "range=A" & kolAw - 1 & ":" & colExcel(totalKolom) & kolAk & ";fontsize=8;fontname=Tahoma;isborder=true")
            CellFormat(xlSheet, "range=A" & kolAw - 1 & ":" & colExcel(totalKolom) & kolAw - 1 & ";backcolor=192,192,192;isborder=true;wrap=true;rowheight=30")
            CellFormat(xlSheet, "range=A" & kolAk + 1 & ":" & colExcel(totalKolom) & kolAk + 1 & ";backcolor=192,192,192;isborder=true")
            ConditionFormat(xlSheet, fn, kolAw, 1)
        End If
    End Sub

    Sub ProcessBrandPDT(ByVal xlSheet As Excel.Worksheet, ByVal brand As String)
        Dim ds1 As DataSet
        Dim totalLoc, totalKolom, totalLine As Integer
        Dim fn, namatable, namatable2, s As String

        fn = "temptxt.txt"
        namatable = "tempexcel_" & Replace(idCompare, " ", "")
        namatable2 = "tempexcel2_" & Replace(idCompare, " ", "")

        ds1 = QuerySO("select distinct location from tempoutput order by location")
        totalLoc = ds1.Tables(0).Rows.Count
        s = ""
        For Each rL As DataRow In ds1.Tables(0).Rows
            s += " " & rL("location").ToString.Trim & "_checker<>" & rL("location").ToString.Trim & "_counter or"
        Next
        s = " ( " & Mid(s, 1, Len(s) - 2) & " ) "
        s = "select * from " & namatable & " where sbu='" & brand & "' and " & vbCrLf & _
                      s & vbCrLf & _
                      "order by sbu, plu"
        QueryToTextFile(s, fn)

        ds1 = QuerySO("select top 1 * from " & namatable)
        totalKolom = ds1.Tables(0).Columns.Count
        totalLine = File.ReadAllLines(fn).Length

        xlSheet.Activate()
        CellFormat(xlSheet, "range=A:D;columnwidth=clear;numberformat=@")
        CellFormat(xlSheet, "range=E:E;columnwidth=clear;numberformat=#,##0")
        CellFormat(xlSheet, "range=F:" & colExcel(totalKolom - 2) & ";columnwidth=8.20;numberformat=#,##0")
        CellFormat(xlSheet, "range=" & colExcel(totalKolom - 1) & ":" & colExcel(totalKolom) & ";columnwidth=clear;numberformat=#,##0")



        CellFormat(xlSheet, "range=a1;fontname=Tahoma;fontsize=12;fontstyle=bold", _
                   "Report Selisih Stock Opname " & Microsoft.VisualBasic.Right(ComboBox1.Text, 4) & " ( " & UCase(brand) & " ) ")
        'CellFormat(xlSheet, "range=a2;fontname=Tahoma;fontsize=12;fontstyle=bold", _
        '           "Periode : " & Format(Date.Parse(vtglopstr), "dd-MMMM-yyyy") & "")
        CellFormat(xlSheet, "range=a2;fontname=Tahoma;fontsize=12;fontstyle=bold", _
                   "Periode : " & Format(vtglop.AddDays(1), "dd-MMMM-yyyy") & "")
        CellFormat(xlSheet, "range=A1:J1;merge=true")
        CellFormat(xlSheet, "range=A2:J2;merge=true")

        If totalLine > 0 Then
            CellFormat(xlSheet, "range=A4;fontname=Tahoma;fontsize=9;fontstyle=bold", "Selisih PDT")
            JudulExcelPDT(xlSheet)
            TextPasteToExcel(xlSheet, fn, "A6")
            CellFormat(xlSheet, "range=A6:" & colExcel(totalKolom) & totalLine + 5 & ";fontsize=8;fontname=Tahoma;isborder=true")
            CellFormat(xlSheet, "range=A5:" & colExcel(totalKolom) & "5;backcolor=192,192,192;isborder=true;wrap=true;rowheight=30")
            CellFormat(xlSheet, "range=A" & totalLine + 6 & ":" & colExcel(totalKolom) & totalLine + 6 & ";backcolor=192,192,192;isborder=true")
            ConditionFormat(xlSheet, fn, 6, 1)
        End If

        xlSheet.Range("D6").Select()
        xlApp.ActiveWindow.FreezePanes = True
        ds1.Dispose()

    End Sub
    Sub ProcessSourceRevision(ByVal xlsheet As Excel.Worksheet, ByVal SQL As String)
        Dim dsL As DataSet
        Dim totalKolom, totalLine As Integer
        Dim namatable, namatable2, fn As String

        fn = "temptxt.txt"
        namatable = "tempexcel_" & Replace(idCompare, " ", "")
        namatable2 = "tempexcel2_" & Replace(idCompare, " ", "")

        QueryToTextFile(SQL, Fn)

        dsL = QuerySO("select top 1 * from " & namatable)
        totalKolom = dsL.Tables(0).Columns.Count
        totalLine = File.ReadAllLines(fn).Length

        xlsheet.Activate()
        CellFormat(xlsheet, "range=A:D;columnwidth=clear;numberformat=@")
        CellFormat(xlsheet, "range=E:E;columnwidth=clear;numberformat=#,##0")
        CellFormat(xlsheet, "range=F:" & colExcel(totalKolom - 2) & ";columnwidth=8.20;numberformat=#,##0")
        CellFormat(xlsheet, "range=" & colExcel(totalKolom - 1) & ":" & colExcel(totalKolom) & ";columnwidth=clear;numberformat=#,##0")

        CellFormat(xlsheet, "range=A6:" & colExcel(totalKolom) & totalLine + 5 & ";fontsize=8;fontname=Tahoma;isborder=true")
        CellFormat(xlsheet, "range=A5:" & colExcel(totalKolom) & "5;backcolor=192,192,192;isborder=true;wrap=true;rowheight=30")
        CellFormat(xlsheet, "range=A" & totalLine + 8 & ":" & colExcel(totalKolom) & totalLine + 8 & ";backcolor=192,192,192;isborder=true")

        CellFormat(xlsheet, "range=a1;fontname=Tahoma;fontsize=12;fontstyle=bold", _
                   "Report Selisih Stock Opname " & Microsoft.VisualBasic.Right(ComboBox1.Text, 4))
        'CellFormat(xlsheet, "range=a2;fontname=Tahoma;fontsize=12;fontstyle=bold", _
        '           "Periode : " & Format(Date.Parse(vtglopstr), "dd-MMMM-yyyy") & "")
        CellFormat(xlsheet, "range=a2;fontname=Tahoma;fontsize=12;fontstyle=bold", _
                   "Periode : " & Format(vtglop.AddDays(1), "dd-MMMM-yyyy") & "")
        CellFormat(xlsheet, "range=A1:J1;merge=true")
        CellFormat(xlsheet, "range=A2:J2;merge=true")

        JudulExcelPDT(xlsheet)
        If totalLine > 0 Then
            TextPasteToExcel(xlsheet, fn, "A6")
        End If

        xlsheet.Range("D6").Select()
        xlApp.ActiveWindow.FreezePanes = True
        ConditionFormat(xlsheet, fn)

        CellFormat(xlsheet, "range=A:E;columnwidth=clear")
    End Sub
    Sub QueryToTextFile(ByVal SQL As String, ByVal Fn As String)
        Dim dsS As DataSet
        Dim s As String = ""
        'Dim lbl As String
        Dim total, rw As Integer
        total = 0 : rw = 0
        dsS = QuerySO(SQL)
        total = CInt(dsS.Tables(0).Rows.Count)
        Dim sw As New IO.StreamWriter(Fn)
        For Each rs As DataRow In dsS.Tables(0).Rows
            s = "" : rw += 1
            'lbl = "Create " & UCase(Replace(Fn, ".txt", "")) & ", PLU : " & rs("plu").ToString.Trim
            'Try : setLabelTxt(lbl, Label5) : Catch ex As Exception : End Try
            'Prg = CInt((rw * 100) / total)
            'BackgroundWorker1.ReportProgress(Prg)
            For x As Integer = 0 To dsS.Tables(0).Columns.Count - 1
                s += rs(x).ToString.Trim & vbTab
            Next
            sw.Write(s & vbNewLine)
        Next
        sw.Close()
        sw.Dispose()
        dsS.Dispose()
    End Sub
    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        isiTempExcel2()
        CreateFinalExcel()


        'CreateTempTxt2()
        'CreateFinalExcel2()
    End Sub
    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Label5.Text = "Done !!! "
        GroupBox2.Enabled = True
        ProgressBar1.Visible = False
        Prg = 0
        MsgOK("Finished")
        OpenExcel(pathName)
    End Sub
End Class

#Region "error"
''Dim sr As StreamReader = New StreamReader(dra.FullName)
''Do While sr.Peek() <> -1
''    line = sr.ReadLine()
''    datapart = Split(line, ",")
''    lbl = "Text To CSV SO, PLU : " & CDbl(datapart(1)).ToString
''    Try : setLabelTxt(lbl, Label5) : Catch ex As Exception : End Try
''    Prg = CInt((no * 100) / total)
''    'MsgOK(no)
''    'BackgroundWorker2.ReportProgress(Prg)
''    no += 1
''    'MsgOK(line)
''Loop
''sr.Close()
''sr.Dispose()
#End Region