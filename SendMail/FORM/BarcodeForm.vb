Imports System.IO
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices
Imports System.Configuration
Imports System.Drawing.Drawing2D

Public Class BarcodeForm
    Dim pageNumber As Integer
    Dim WhsCode As String
    Dim acceptableKey As Boolean = False
    Private Sub BarcodeForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FormLoad()
    End Sub
    Sub FormLoad()
        LblStore.Text = "POSSERVER_" & ReadIni("SETTING_BARCODE", "WHSCODE")
        If LCase(LblStore.Text) = "posserver_s001" Then
            OpenDB_POSSERVERHISTORY_S001()
        ElseIf LCase(LblStore.Text) = "posserver_s002" Then
            OpenDB_POSSERVERHISTORY_S002()
        ElseIf LCase(LblStore.Text) = "posserver_s003" Then
            OpenDB_POSSERVERHISTORY_S003()
        End If
        WhsCode = ReadIni(LblStore.Text, "WHSCODE")

        dg.RowsDefaultCellStyle.BackColor = Color.White
        dg.AlternatingRowsDefaultCellStyle.BackColor = Color.Bisque
        dgharga.RowsDefaultCellStyle.BackColor = Color.White
        dgharga.AlternatingRowsDefaultCellStyle.BackColor = Color.Bisque
        dgArticle.RowsDefaultCellStyle.BackColor = Color.White
        dgArticle.AlternatingRowsDefaultCellStyle.BackColor = Color.Bisque

        dg.DefaultCellStyle.ForeColor = Color.Black
        dg.DefaultCellStyle.Font = LblFont.Font
        dg.ColumnHeadersDefaultCellStyle.Font = LblFont2.Font
        dgArticle.DefaultCellStyle.ForeColor = Color.Black
        dgArticle.DefaultCellStyle.Font = LblFont.Font
        dgArticle.ColumnHeadersDefaultCellStyle.Font = LblFont2.Font
        dgharga.DefaultCellStyle.ForeColor = Color.Black
        dgharga.DefaultCellStyle.Font = LblFont.Font
        dgharga.ColumnHeadersDefaultCellStyle.Font = LblFont2.Font

        dgKPT.Rows.Clear()
        dgKPT.Rows.Add("2 5 0 0 6   -   0 6 7;Art Fashion Brooch;;LACBOARF1 - LA0806;1000000000009;1 0 0 0 0 0 0 0 0 0 0 0 9;2700035230004;2 7 0 0 0 3 5 2 3 0 0 0 4;Rp. 3,523,000,-;0", _
                       "2 5 0 0 6   -   0 6 7;Art Fashion Brooch;;LACBOARF1 - LA0806;1000000000009;1 0 0 0 0 0 0 0 0 0 0 0 9;2700035230004;2 7 0 0 0 3 5 2 3 0 0 0 4;Rp. 3,523,000,-;0")
        dgKPT.Rows.Add("2 5 0 1 0   -   0 6 7;Ballin Brooch;;LACBOBLN1 - LA2106;1000000400007;1 0 0 0 0 0 0 4 0 0 0 0 7;2700032653363;2 7 0 0 0 3 2 6 5 3 3 6 3;Rp. 3,265,336,-;", _
                       "2 5 0 1 0   -   0 6 7;Ballin Brooch;;LACBOBLN1 - LA2106;1000000400007;1 0 0 0 0 0 0 4 0 0 0 0 7;2700032653363;2 7 0 0 0 3 2 6 5 3 3 6 3;Rp. 3,265,336,-;1")
        dgKPT.Rows.Add("0 0 0 2 9   -   0 6 7;NYX CHEEK CONTOUR DU;O PAL CHEEK ON CHEEK;LCOBCNYX0 - LA2106;800897011994;8 0 0 8 9 7 0 1 1 9 9 4;2700002200009;2 7 0 0 0 0 2 2 0 0 0 0 9;Rp. 220,000,-;0", _
                       "0 0 0 2 9   -   0 6 7;NYX CHEEK CONTOUR DU;O PAL CHEEK ON CHEEK;LCOBCNYX0 - LA2106;800897011994;8 0 0 8 9 7 0 1 1 9 9 4;2700002200009;2 7 0 0 0 0 2 2 0 0 0 0 9;Rp. 220,000,-;0")
        dgKPT.Rows.Add("0 0 0 0 5   -   0 6 7;Lego Friend Value Se;t;CTOGTLGO0 - CH2106;4000169200002;4 0 0 0 1 6 9 2 0 0 0 0 2;2700000899007;2 7 0 0 0 0 0 8 9 9 0 0 7;Rp. 89,900,-;0", _
                       "0 0 0 0 5   -   0 6 7;Lego Friend Value Se;t;CTOGTLGO0 - CH2106;4000169200002;4 0 0 0 1 6 9 2 0 0 0 0 2;2700000899007;2 7 0 0 0 0 0 8 9 9 0 0 7;Rp. 89,900,-;0")

        dgKPL.Rows.Clear()
        dgKPL.Rows.Add("2 5 0 0 6   -   0 6 7;Art Fashion Brooch;;LACBOARF1 - LA0806;1000000000009;1 0 0 0 0 0 0 0 0 0 0 0 9;2700035230004;2 7 0 0 0 3 5 2 3 0 0 0 4;Rp. 3,523,000,-;0", _
                       "2 5 0 0 6   -   0 6 7;Art Fashion Brooch;;LACBOARF1 - LA0806;1000000000009;1 0 0 0 0 0 0 0 0 0 0 0 9;2700035230004;2 7 0 0 0 3 5 2 3 0 0 0 4;Rp. 3,523,000,-;0", _
                       "2 5 0 0 6   -   0 6 7;Art Fashion Brooch;;LACBOARF1 - LA0806;1000000000009;1 0 0 0 0 0 0 0 0 0 0 0 9;2700035230004;2 7 0 0 0 3 5 2 3 0 0 0 4;Rp. 3,523,000,-;0")
        dgKPL.Rows.Add("2 5 0 1 0   -   0 6 7;Ballin Brooch;;LACBOBLN1 - LA2106;1000000400007;1 0 0 0 0 0 0 4 0 0 0 0 7;2700032653363;2 7 0 0 0 3 2 6 5 3 3 6 3;Rp. 3,265,336,-;", _
                       "2 5 0 1 0   -   0 6 7;Ballin Brooch;;LACBOBLN1 - LA2106;1000000400007;1 0 0 0 0 0 0 4 0 0 0 0 7;2700032653363;2 7 0 0 0 3 2 6 5 3 3 6 3;Rp. 3,265,336,-;", _
                       "2 5 0 1 0   -   0 6 7;Ballin Brooch;;LACBOBLN1 - LA2106;1000000400007;1 0 0 0 0 0 0 4 0 0 0 0 7;2700032653363;2 7 0 0 0 3 2 6 5 3 3 6 3;Rp. 3,265,336,-;1")
        dgKPL.Rows.Add("0 0 0 2 9   -   0 6 7;NYX CHEEK CONTOUR DU;O PAL CHEEK ON CHEEK;LCOBCNYX0 - LA2106;800897011994;8 0 0 8 9 7 0 1 1 9 9 4;2700002200009;2 7 0 0 0 0 2 2 0 0 0 0 9;Rp. 220,000,-;0", _
                       "0 0 0 2 9   -   0 6 7;NYX CHEEK CONTOUR DU;O PAL CHEEK ON CHEEK;LCOBCNYX0 - LA2106;800897011994;8 0 0 8 9 7 0 1 1 9 9 4;2700002200009;2 7 0 0 0 0 2 2 0 0 0 0 9;Rp. 220,000,-;0", _
                       "0 0 0 2 9   -   0 6 7;NYX CHEEK CONTOUR DU;O PAL CHEEK ON CHEEK;LCOBCNYX0 - LA2106;800897011994;8 0 0 8 9 7 0 1 1 9 9 4;2700002200009;2 7 0 0 0 0 2 2 0 0 0 0 9;Rp. 220,000,-;0")
        dgKPL.Rows.Add("0 0 0 0 5   -   0 6 7;Lego Friend Value Se;t;CTOGTLGO0 - CH2106;4000169200002;4 0 0 0 1 6 9 2 0 0 0 0 2;2700000899007;2 7 0 0 0 0 0 8 9 9 0 0 7;Rp. 89,900,-;0", _
                       "0 0 0 0 5   -   0 6 7;Lego Friend Value Se;t;CTOGTLGO0 - CH2106;4000169200002;4 0 0 0 1 6 9 2 0 0 0 0 2;2700000899007;2 7 0 0 0 0 0 8 9 9 0 0 7;Rp. 89,900,-;0", _
                       "0 0 0 0 5   -   0 6 7;Lego Friend Value Se;t;CTOGTLGO0 - CH2106;4000169200002;4 0 0 0 1 6 9 2 0 0 0 0 2;2700000899007;2 7 0 0 0 0 0 8 9 9 0 0 7;Rp. 89,900,-;0")


        'dgArticle.Rows.Clear()
        'dgArticle.DataSource = Nothing
        dgKPT.Rows.Clear()
        dgKPT.Rows.Add("70", "60")
        'dgKPT.Rows.Add("50", "45")

        rbGR.Checked = False
        rbPLU.Checked = True
        enableGR(False)
        enablePLU(True)
    End Sub
#Region "SUB GLOBAL"

    Public Function checksum_ean13(ByVal data As String) As Integer
        Dim digit, cs, i As Integer
        cs = 0 'checksum
        For i = 1 To 12
            digit = Mid(data, i, 1) - "0"  'get the next digit from bar code text
            If i Mod 2 = 0 Then
                cs = cs + digit * 3 'multiply each bar code digit by it's weight, 1 or 3
            Else
                cs = cs + digit * 1
            End If
        Next i
        cs = (10 - (cs Mod 10)) Mod 10 'which digit must be added to cs to make it divisible by 10
        Return cs
    End Function
    'Function PriceToBarcode(ByVal price As Double) As String
    '    Return Format(price, "27000000000#") & checksum_ean13(Format(price, "27000000000#"))
    'End Function
    Function LineSpacing(ByVal txt As String)
        Dim hasil As String = ""
        For x = 1 To Len(txt)
            hasil += Mid(txt, x, 1) & " "
        Next
        hasil = Mid(hasil, 1, Len(hasil) - 1)
        Return hasil
    End Function
    Sub FillColIsiGrid()
        'Exit Sub
        Dim s As String = ""
        Dim periode As String
        Dim price As Double = 0
        Dim tgl As DateTime
        For x As Integer = 0 To dg.RowCount - 1
            FillCellGrid(dg, "isi", "", x)
            If CInt(getColumnGrid(dg, "choose", x)) = 1 Then
                s = ""
                's += LineSpacing(getColumnGrid(dg, "supplier_code", x) & " - " & _
                '     Mid(getColumnGrid(dg, "date", x), 4, 2) & _
                '     Mid(getColumnGrid(dg, "date", x), 10, 1)) & ";"
                tgl = Date.Parse(Mid(getColumnGrid(dg, "date", x), 7, 4) & "-" & _
                                 Mid(getColumnGrid(dg, "date", x), 4, 2) & "-" & _
                                 Mid(getColumnGrid(dg, "date", x), 1, 2))
                periode = getPeriodeHuruf(tgl)
                s += LineSpacing(getColumnGrid(dg, "supplier_code", x)) & "-" & periode & ";"
                s += getColumnGrid(dg, "desc1", x) & ";"
                s += getColumnGrid(dg, "desc2", x) & ";"
                s += getColumnGrid(dg, "burui", x) & " - " & _
                     getColumnGrid(dg, "sbu", x) & _
                     Mid(getColumnGrid(dg, "date", x), 1, 2) & _
                     Mid(getColumnGrid(dg, "date", x), 4, 2) & ";"
                s += getColumnGrid(dg, "plu", x) & ";"
                s += LineSpacing(getColumnGrid(dg, "plu", x)) & ";"
                's += "2700002563203" & ";" 'barcodeharga
                If getColumnGrid(dg, "price", x) = "" Then
                    price = 0
                Else
                    price = CDbl(getColumnGrid(dg, "price", x))
                End If
                s += PriceToBarcode(price) & ";" 'barcodeharga
                s += LineSpacing(PriceToBarcode(price)) & ";" 'labelharga
                s += "Rp. " & CDec(price).ToString("N0") & ";"
                'If price <> 0 Then
                '    s += "Rp. " & CDec(price).ToString("N0") & ";"
                'Else
                '    s += ";"
                'End If
                s += getColumnGrid(dg, "flag", x) + ";"
                s += LCase(getColumnGrid(dg, "perishable", x))
                's = Mid(s, 1, Len(s) - 1)
                'MsgBox(s)
                FillCellGrid(dg, "isi", s, x)
            End If
        Next
    End Sub
    Public Sub TampilTable(ByVal dg As DataGridView, ByVal SQL As String, Optional ByVal syarat As String = " (0=0) ", _
                           Optional ByVal strCon As String = "")
        'Cursor = Cursors.WaitCursor
        Dim dstable As DataSet
        SQL = Replace(SQL, "@syarat", syarat)
        'Dbg(SQL)
        dstable = QueryToDataset(SQL, strCon)
        'dg.Rows.Clear()
        dg.DataSource = dstable.Tables(0)
        dg.Focus()
        'FormatColumnGrid(dg, 4, "number", 2)
        'dg.RowsDefaultCellStyle.BackColor = Color.Bisque
        'dg.AlternatingRowsDefaultCellStyle.BackColor = Color.White
    End Sub
    Sub insertHarga()
        If txtharga.Text = "" Then
            MsgBox("input harga yang dahulu!", MsgBoxStyle.Exclamation)
            Exit Sub
        ElseIf txtqty2.Text = "" Then
            MsgBox("Input Qty yang dahulu!", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim isi, harga As String
        Dim sudah As Boolean
        'harga = "Rp. " & Replace(txtharga.Text, ",", ".") & ",-"
        'harga = "Rp. " & txtharga.Text & ",-"
        harga = "Rp. " & txtharga.Text
        isi = ""
        With dgharga
            .Rows.Add(harga, txtqty2.Text)
        End With

        sudah = False
        If dg1.RowCount = 0 Then
            dg1.Rows.Add("", "", "")
            'Else
        End If

        Dim q As Integer
        q = 1

        Do
            sudah = False
            For x As Integer = 0 To 2
                isi = dg1.Rows(dg1.RowCount - 1).Cells(x).Value.ToString.Trim
                'MsgBox(isi)
                If isi = "" Then
                    If q > CInt(txtqty2.Text) Then Exit Do
                    dg1.Rows(dg1.RowCount - 1).Cells(x).Value = harga
                    q += 1
                    sudah = True
                    'Continue For
                End If
            Next
            If sudah = False Then
                If q > CInt(txtqty2.Text) Then Exit Do
                dg1.Rows.Add(harga, "", "")
                q += 1
                sudah = True
            End If

        Loop Until q > CInt(txtqty2.Text)

        'End If
        txtharga.Text = ""
        txtqty2.Text = ""
        txtharga.Focus()
    End Sub
    Sub SaveLogHeader(ByVal TypeBc As String)
        Dim seq, tgl, LogType, Log_Number, s As String
        tgl = Format(Now(), "ddMMyyyy")
        BarcodeID = ReadIni("SETTING_BARCODE", "BarcodeID")
        ds = Query("select log_number from log_print where " & vbCrLf & _
                   "substring(log_number,1,6)='" & WhsCode & BarcodeID & "' " & vbCrLf & _
                   "and substring(log_number,8,8)='" & Format(Now, "ddMMyyyy") & "' " & vbCrLf & _
                   "order by log_number desc")
        If ds.Tables(0).Rows.Count > 0 Then
            seq = RightStr(CStr("0000" & CInt(RightStr(ds.Tables(0).Rows(0).Item(0).ToString.Trim, 4) + 1)), 4)
        Else
            seq = "0001"
        End If

        Log_Number = WhsCode & BarcodeID & "-" & tgl & "-" & seq
        LogType = "1"
        'log type : 1 find plu, 2 find gr, 3, find fa
        'grnum = -
        'flag = 0
        'typepaperbc = 0 tag, 1 label
        'UserLogin
        s = "insert into log_print values ('" & Log_Number & "', '" & LogType & "', 'Test', '0', " & vbCrLf & _
                  "'" & TypeBc & "', '" & UsrID & "', '" & Format(Now, "yyyy-MM-dd") & "', " & vbCrLf & _
                  "'" & Format(Now, "HH:mm") & "', '" & Format(Now, "yyyy-MM-dd") & "', '') "
        'Dbg(s)
        ExecQuery(s)
        SaveLogDetail(Log_Number)
    End Sub
    Sub SaveLogDetail(ByVal Log_Number As String)
        Dim s As String
        ExecQuery("delete from log_print_details where log_number='" & Log_Number & "' ")
        For x As Integer = 0 To dg.RowCount - 1
            If CInt(getColumnGrid(dg, "choose", x)) = 1 Then
                s = "insert into log_print_details (log_number, seq, plu, article_code, " & vbCrLf & _
                          "supplier_code, description, agedate, efdate, price, pqty) values (" & vbCrLf & _
                          "'" & Log_Number & "', '" & x + 1 & "', '" & getColumnGrid(dg, "plu", x) & "', " & vbCrLf & _
                          "'" & getColumnGrid(dg, "article_code", x) & "', " & vbCrLf & _
                          "'" & getColumnGrid(dg, "supplier_code", x) & "', " & vbCrLf & _
                          "'" & getColumnGrid(dg, "description", x) & "', " & vbCrLf & _
                          "'" & Format(Now, "yyyy-MM-dd") & "', '" & Format(Now, "yyyy-MM-dd") & "', " & vbCrLf & _
                          "'" & getColumnGrid(dg, "price", x) & "', '" & getColumnGrid(dg, "qty", x) & "' ) "
                'Dbg(s)
                ExecQuery(s)
            End If
        Next

    End Sub
    Sub enableGR(Optional ByVal tipe As Boolean = True)
        Label16.Enabled = tipe
        TxtGR.Enabled = tipe
        TxtGR.Clear()
        TxtGR.Focus()
    End Sub
    Sub enablePLU(Optional ByVal tipe As Boolean = True)
        Label14.Enabled = tipe
        Label9.Enabled = tipe
        txtPLU.Enabled = tipe
        txtQty.Enabled = tipe
        txtPLU.Clear()
        txtQty.Clear()
        txtPLU.Focus()
    End Sub
    Private Sub rbPLU_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPLU.CheckedChanged
        enablePLU(rbPLU.Checked)
    End Sub
    Private Sub rbGR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbGR.CheckedChanged
        enableGR(rbGR.Checked)
    End Sub
    Function getItemPrice(ByVal plu As String) As Double
        Dim dsx As DataSet
        Dim harga As Double = 0
        dsx = Query("select top 1 branch_id, plu, effective_date, " & vbCrLf & _
                        "convert(float, round(new_price,0)) as price from Trx_PAS where branch_id='" & WhsCode & "' " & vbCrLf & _
                        "and plu='" & plu & "' and effective_date <= getdate() " & vbCrLf & _
                        "order by effective_date desc")
        If dsx.Tables(0).Rows.Count > 0 Then
            harga = CDbl(dsx.Tables(0).Rows(0).Item("price").ToString.Trim)
        Else
            dsx = Query("select convert(float, round(current_price,0)) as price from Item_Master " & vbCrLf & _
                        "where branch_id='" & WhsCode & "' " & vbCrLf & _
                        "and plu='" & plu & "' ")
            If dsx.Tables(0).Rows.Count > 0 Then
                harga = CDbl(dsx.Tables(0).Rows(0).Item("price").ToString.Trim)
            Else
                harga = 0
            End If
        End If
        Return harga
    End Function
    Sub insertPLU()
        Dim harga As Double = 0
        Dim ds1 As New DataSet
        ds1 = Query("select top 1 branch_id from item_master")
        If CInt(getColumnGrid(dgArticle, "flag")) = 0 Then 'direct
            harga = getItemPrice(getColumnGrid(dgArticle, "plu"))
        End If
        clearDataSet(ds1)
        dg.Rows.Add("1", getColumnGrid(dgArticle, "plu"), getColumnGrid(dgArticle, "description"), harga, "", _
                        Format(Now, "dd-MM-yyyy"), getColumnGrid(dgArticle, "sbu"), _
                        getColumnGrid(dgArticle, "supplier_code"), getColumnGrid(dgArticle, "burui"), _
                        getColumnGrid(dgArticle, "desc1"), getColumnGrid(dgArticle, "desc2"), "", _
                        getColumnGrid(dgArticle, "flag"), getColumnGrid(dgArticle, "perishable"))
        'txtPLU.Clear()
        'txtPLU.Focus()
        'FormatColumnGrid(dg, 3, "number")
    End Sub
#End Region
#Region "DATAGRID"
    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        'dgArticle.Rows.Clear()
        gb_article.Visible = False
    End Sub
    Private Sub dg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dg.KeyDown
        If e.KeyCode = 46 Then
            Dim selRow As New DataGridViewRow
            selRow = dg.Rows.Item(dg.CurrentRow.Index)
            dg.Rows.Remove(selRow)
        End If
    End Sub
    Private Sub dgArticle_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgArticle.CellDoubleClick
        If e.RowIndex >= 0 Then
            insertPLU()
        End If
    End Sub
    Private Sub dgArticle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgArticle.KeyDown
        If e.KeyCode = Keys.Escape Then
            Label4_Click(sender, e)
        ElseIf e.KeyCode = 13 Then
            insertPLU()
        End If
    End Sub
    Private Sub gb_article_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gb_article.Enter

    End Sub
#End Region
#Region "PLU KPL"
    Sub FillGridKPL()
        dgKPL.Rows.Clear()

        Dim sudah As Boolean
        Dim q, qty As Integer
        Dim isi, value As String


        If dgKPL.RowCount = 0 Then dgKPL.Rows.Add("", "", "")
        For br As Integer = 0 To dg.RowCount - 1
            value = getColumnGrid(dg, "isi", br)
            If getColumnGrid(dg, "qty", br) = "" Then
                qty = 0
            Else
                qty = CInt(getColumnGrid(dg, "qty", br))
            End If

            sudah = False
            q = 1
            Do
                sudah = False
                For x As Integer = 0 To 2
                    isi = dgKPL.Rows(dgKPL.RowCount - 1).Cells(x).Value.ToString.Trim
                    'MsgBox(isi)
                    If isi = "" Then
                        If q > qty Then Exit Do
                        dgKPL.Rows(dgKPL.RowCount - 1).Cells(x).Value = value
                        q += 1
                        sudah = True
                        'Continue For
                    End If
                Next
                If sudah = False Then
                    If q > qty Then Exit Do
                    dgKPL.Rows.Add(value, "", "")
                    q += 1
                    sudah = True
                End If

            Loop Until q > qty
        Next
    End Sub
    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        If dg.Rows.Count <= 0 Then Exit Sub
        FillColIsiGrid()
        FillGridKPL()
        If LCase(ReadIni("SETTING_BARCODE", "SAVELOG")) = "yes" Then SaveLogHeader("1")
        If LCase(ReadIni("SETTING_BARCODE", "PREVIEWPRINT")) = "yes" Then
            dlgPrintPreview2.Document = PrintKPL
            dlgPrintPreview2.WindowState = FormWindowState.Maximized
            dlgPrintPreview2.ShowDialog()
        Else
            PrintKPL.Print()
        End If
        BtnClear_Click(sender, e)
    End Sub

    Private Sub PrintKPL_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintKPL.BeginPrint
        pageNumber = 1
    End Sub

    Private Sub PrintKPL_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintKPL.PrintPage
        Dim fontStr As String
        fontStr = "Tahoma"
        Dim g As Graphics = e.Graphics
        Dim ft As New Font(fontStr, 11, FontStyle.Bold, GraphicsUnit.Point)
        Dim ft1 As New Font(fontStr, 5, FontStyle.Regular, GraphicsUnit.Point)
        Dim rect As New RectangleF

        Dim isi As String
        Dim datapart() As String
        Dim rowgrid As Integer
        Dim Param As String
        Dim xx, yy, LeftMargin, TopMargin As Integer

        Param = getStringFromDB("select param from m_settingbarcode where tipe='KPL'")
        LeftMargin = getValueFromString("leftmargin", Param)
        TopMargin = getValueFromString("topmargin", Param)
        xx = getValueFromString("x", Param)
        yy = getValueFromString("y", Param)

        Dim myP As New Point(xx, yy)

        rowgrid = pageNumber - 1
        For x As Integer = 0 To 2
            isi = dgKPL.Rows(rowgrid).Cells(x).Value.ToString.Trim
            If isi <> "" Then
                datapart = Split(isi, ";")
                'g.DrawRectangle(Pens.Black, LeftMargin, xx - 5, 94, 40)
                g.TranslateTransform(myP.X + 7, myP.Y + 65)
                g.RotateTransform(180)
                g.DrawRectangle(Pens.Black, 0, 0, 94, 40)
                g.ResetTransform()

                PrintSupplierCode(g, myP, Trim(getArray(datapart(0).ToString.Trim, "-", 0)), _
                                  Trim(getArray(datapart(0).ToString.Trim, "-", 1)))
                PrintDesc1(g, myP, datapart(1).ToString.Trim)
                PrintDesc2(g, myP, datapart(2).ToString.Trim)
                'PrintBurui(g, myP, LeftMargin, datapart(3).ToString.Trim)

                PrintBurui(g, myP, LeftMargin, Trim(getArray(datapart(3).ToString.Trim, "-", 0)), LCase(datapart(10).ToString.Trim))

                PrintBarcodePLU(g, LeftMargin - 10, datapart(4).ToString.Trim, TopMargin + 50)
                PrintLabelPLU(g, myP, datapart(5).ToString.Trim)
                If datapart(9).ToString.Trim = "1" Then
                    PrintBarcodePrice(g, LeftMargin - 2, datapart(6).ToString.Trim, TopMargin + 45)
                    PrintLabelPrice(g, myP, datapart(7).ToString.Trim)
                End If
                PrintPrice(g, myP, datapart(8).ToString.Trim)
                myP.X = myP.X + 126
                LeftMargin = LeftMargin + 126
            End If
        Next

        pageNumber += 1
        e.HasMorePages = (pageNumber <= dgKPL.RowCount)
    End Sub
    Sub PrintSupplierCode(ByVal g As Graphics, ByVal myP As Point, ByVal txt As String, _
                          ByVal PeriodeHarga As String)
        Dim ft As New Font("TAHOMA", 5, FontStyle.Regular, GraphicsUnit.Point)
        g.TranslateTransform(myP.X + 7, myP.Y + 65)
        g.RotateTransform(180)
        g.DrawString(txt, ft, Brushes.Black, 0, 0)
        g.ResetTransform()

        g.TranslateTransform(myP.X - 70, myP.Y + 65)
        g.RotateTransform(180)
        g.DrawString(PeriodeHarga, ft, Brushes.Black, 0, 0)
        g.ResetTransform()
    End Sub
    Sub PrintDesc1(ByVal g As Graphics, ByVal myP As Point, ByVal txt As String)
        Dim ft As New Font("TAHOMA", 5, FontStyle.Bold, GraphicsUnit.Point)
        g.TranslateTransform(myP.X + 7, myP.Y + 55)
        g.RotateTransform(180)
        g.DrawString(txt, ft, Brushes.Black, 0, 0)
        g.ResetTransform()
    End Sub
    Sub PrintDesc2(ByVal g As Graphics, ByVal myP As Point, ByVal txt As String)
        Dim ft As New Font("TAHOMA", 5, FontStyle.Bold, GraphicsUnit.Point)
        g.TranslateTransform(myP.X + 7, myP.Y + 45)
        g.RotateTransform(180)
        g.DrawString(txt, ft, Brushes.Black, 0, 0)
        g.ResetTransform()
    End Sub
    Sub PrintBurui(ByVal g As Graphics, ByVal myP As Point, ByVal LeftMargin As Integer, _
                   ByVal txt As String, ByVal promo As String)
        Dim ft As New Font("TAHOMA", 5, FontStyle.Bold, GraphicsUnit.Point)
        Dim ft1 As New Font("TAHOMA", 6, FontStyle.Bold, GraphicsUnit.Point)
        'Dim rect = New RectangleF(LeftMargin + 3, myP.Y + 28, 88, 8)
        If LCase(promo) = "p" Then
            g.TranslateTransform(myP.X + 5, myP.Y + 36)
            g.RotateTransform(180)
            g.FillRectangle(Brushes.Black, 0, 0, 88, 8)
            g.ResetTransform()

            g.TranslateTransform(myP.X + 5, myP.Y + 36)
            g.RotateTransform(180)
            g.DrawString(txt, ft, Brushes.White, 0, 0)
            g.ResetTransform()
        Else
            g.TranslateTransform(myP.X + 5, myP.Y + 36)
            g.RotateTransform(180)
            g.DrawString(txt, ft1, Brushes.Black, 0, 0)
            g.ResetTransform()
        End If

    End Sub
    Sub PrintBarcodePLU(ByVal g As Graphics, ByVal LeftMargin As Integer, ByVal txt As String, ByVal TopMargin As Integer)
        'If datapart(4).ToString.Trim.Length <> 13 Then
        '    g.DrawImage(TextToBarcode(datapart(4).ToString.Trim, False, "code 128"), LeftMargin + 12, TopMargin + 48)    'print barcode plu
        'ElseIf LeftStr(datapart(4).ToString.Trim, 5) = "71249" Then
        '    g.DrawImage(TextToBarcode(datapart(4).ToString.Trim, False, "code 128"), LeftMargin + 12, TopMargin + 48, 180, 20)    'print barcode plu
        'Else
        '    'MsgOK("b")
        '    g.DrawImage(TextToBarcode(datapart(4).ToString.Trim, False), LeftMargin + 22, TopMargin + 48, 90, 20)    'print barcode plu
        'End If

        If txt.Trim.Length <> 13 Then
            'Dim CropRect As New Rectangle(0, 0, 100, 20)
            'g.DrawImage(TextToBarcode(txt, True, "code 128", 2), New Rectangle(LeftMargin, TopMargin, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
            g.DrawImage(TextToBarcode(txt.Trim, False, "code 128"), LeftMargin + 10, TopMargin, 180, 20)    'print barcode plu
            g.ResetTransform()
        ElseIf LeftStr(txt.Trim, 5) = "71249" Then
            'Dim CropRect As New Rectangle(0, 0, 150, 20)+10
            'g.DrawImage(TextToBarcode(txt, True, "code 128", 2), New Rectangle(LeftMargin, TopMargin, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
            g.DrawImage(TextToBarcode(txt.Trim, False, "code 128"), LeftMargin + 10, TopMargin, 150, 20)    'print barcode plu

            g.ResetTransform()
        Else
            g.DrawImage(TextToBarcode(txt), LeftMargin + 10, TopMargin, 90, 20)
        End If
    End Sub
    Sub PrintLabelPLU(ByVal g As Graphics, ByVal myP As Point, ByVal txt As String)
        Dim ft As New Font("TAHOMA", 6, FontStyle.Regular, GraphicsUnit.Point)
        g.TranslateTransform(myP.X + 6, myP.Y)
        g.RotateTransform(180)
        g.DrawString(txt, ft, Brushes.Black, 0, 0)
        g.ResetTransform()
    End Sub
    Function PriceToBarcode(ByVal price As Double) As String
        Return Format(price, "27000000000#") & checksum_ean13(Format(price, "27000000000#"))
    End Function
    Sub PrintBarcodePrice(ByVal g As Graphics, ByVal LeftMargin As Integer, ByVal txt As String, _
                          ByVal TopMargin As Integer)
        g.DrawImage(TextToBarcode(txt), LeftMargin + 2, TopMargin - 35, 90, 20)
    End Sub
    Sub PrintLabelPrice(ByVal g As Graphics, ByVal myP As Point, ByVal txt As String)
        Dim ft As New Font("TAHOMA", 6, FontStyle.Regular, GraphicsUnit.Point)
        g.TranslateTransform(myP.X + 6, myP.Y - 40)
        g.RotateTransform(180)
        g.DrawString(txt, ft, Brushes.Black, 0, 0)
        g.ResetTransform()
    End Sub
    Sub PrintPrice(ByVal g As Graphics, ByVal myP As Point, ByVal txt As String)
        Dim ft As New Font("Times New Roman", 11, FontStyle.Bold, GraphicsUnit.Point)
        Dim xx, yy As Integer
        xx = myP.X - 12
        yy = myP.Y - 55

        If txt.Trim.Length = 15 Then
            xx = myP.X + 13
        ElseIf txt.Trim.Length = 13 Then
            xx = myP.X + 6
        ElseIf txt.Trim.Length = 12 Then
            xx = myP.X + 5
        ElseIf txt.Trim.Length = 11 Then
            xx = myP.X + 1
        ElseIf txt.Trim.Length = 9 Then
            xx = myP.X - 3
        ElseIf txt.Trim.Length = 5 Then
            xx = myP.X - 15
        End If

        g.TranslateTransform(xx, yy)
        g.RotateTransform(180)
        g.DrawString(txt, ft, Brushes.Black, 0, 0)
        g.ResetTransform()
    End Sub
    Function TextToImage(ByVal Text As String) As Image
        'Dim Text As String = "Rp. " & CDec(99925630).ToString("N0") & ",-"

        Dim FontColor As Color = Color.Black
        Dim BackColor As Color = Color.White
        Dim FontName As String = "Tahoma"
        Dim FontSize As Integer = 19
        Dim Height As Integer = 35
        Dim Width As Integer = 200
        Dim FileName As String = "MyImage"
        Dim objBitmap As New Bitmap(Width, Height)
        Dim objGraphics As Graphics = Graphics.FromImage(objBitmap)
        Dim objFont As New Font(FontName, FontSize)
        Dim objPoint As New PointF(0.0F, 0.0F)
        Dim objBrushForeColor As New SolidBrush(FontColor)
        Dim objBrushBackColor As New SolidBrush(BackColor)
        objGraphics.FillRectangle(objBrushBackColor, 0, 0, Width, Height)
        objGraphics.DrawString(Text, objFont, objBrushForeColor, objPoint)
        Dim ms As New MemoryStream
        objBitmap.Save(ms, ImageFormat.Png)
        Return Image.FromStream(ms)
        'objBitmap.Save(Application.StartupPath & FileName & ".PNG", ImageFormat.Png)
    End Function
#End Region
#Region "PLU KPT"
    Sub FillGridKPT()
        dgKPT.Rows.Clear()

        Dim sudah As Boolean
        Dim q, qty As Integer
        Dim isi, value As String


        If dgKPT.RowCount = 0 Then dgKPT.Rows.Add("", "", "")
        For br As Integer = 0 To dg.RowCount - 1
            value = getColumnGrid(dg, "isi", br)
            If value <> "" Then
                If getColumnGrid(dg, "qty", br) = "" Then
                    qty = 0
                Else
                    qty = CInt(getColumnGrid(dg, "qty", br))
                End If

                sudah = False
                q = 1
                Do
                    sudah = False
                    For x As Integer = 0 To 1
                        isi = dgKPT.Rows(dgKPT.RowCount - 1).Cells(x).Value.ToString.Trim
                        'MsgBox(isi)
                        If isi = "" Then
                            If q > qty Then Exit Do
                            dgKPT.Rows(dgKPT.RowCount - 1).Cells(x).Value = value
                            q += 1
                            sudah = True
                            'Continue For
                        End If
                    Next
                    If sudah = False Then
                        If q > qty Then Exit Do
                        dgKPT.Rows.Add(value, "", "")
                        q += 1
                        sudah = True
                    End If

                Loop Until q > qty
            End If
        Next
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If dg.Rows.Count <= 0 Then Exit Sub
        FillColIsiGrid()
        FillGridKPT()
        If LCase(ReadIni("SETTING_BARCODE", "SAVELOG")) = "yes" Then SaveLogHeader("0")
        If LCase(ReadIni("SETTING_BARCODE", "PREVIEWPRINT")) = "yes" Then
            dlgPrintPreview2.Document = PrintKPT
            dlgPrintPreview2.WindowState = FormWindowState.Maximized
            dlgPrintPreview2.ShowDialog()
        Else
            PrintKPT.Print()
        End If
        BtnClear_Click(sender, e)
    End Sub

    Private Sub PrintKPT_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintKPT.BeginPrint
        pageNumber = 1
    End Sub

    Private Sub PrintKPT_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintKPT.PrintPage
        Dim fontStr As String
        fontStr = "Times New Roman"
        Dim g As Graphics = e.Graphics
        Dim ft As New Font(fontStr, 12, FontStyle.Bold, GraphicsUnit.Point)
        Dim ft1 As New Font(fontStr, 6, FontStyle.Bold, GraphicsUnit.Point)
        Dim ft2 As New Font(fontStr, 8, FontStyle.Bold, GraphicsUnit.Point)
        Dim rect As New RectangleF

        Dim param, isi As String
        Dim datapart() As String
        Dim rowgrid, TopMargin, LeftMargin As Integer

        param = getStringFromDB("select param from m_settingbarcode where tipe='KPT'")
        LeftMargin = getValueFromString("leftmargin", param)
        TopMargin = getValueFromString("topmargin", param)

        rowgrid = pageNumber - 1
        For x As Integer = 0 To 1
            isi = dgKPT.Rows(rowgrid).Cells(x).Value.ToString.Trim
            If isi <> "" Then
                datapart = Split(isi, ";")

                'If CInt(Len(datapart(8).ToString.Trim)) = 15 Then
                '    g.TranslateTransform(LeftMargin, TopMargin)
                'ElseIf CInt(Len(datapart(8).ToString.Trim)) = 13 Then
                '    g.TranslateTransform(LeftMargin, TopMargin + 5)
                'ElseIf CInt(Len(datapart(8).ToString.Trim)) = 12 Then
                '    g.TranslateTransform(LeftMargin, TopMargin + 5)
                'Else
                '    g.TranslateTransform(LeftMargin, TopMargin + 15)
                'End If

                If CInt(Len(datapart(8).ToString.Trim)) = 15 Then
                    g.TranslateTransform(LeftMargin, TopMargin)
                ElseIf CInt(Len(datapart(8).ToString.Trim)) = 13 Then
                    g.TranslateTransform(LeftMargin, TopMargin + 3)
                ElseIf CInt(Len(datapart(8).ToString.Trim)) = 11 Then
                    g.TranslateTransform(LeftMargin, TopMargin + 10)
                ElseIf CInt(Len(datapart(8).ToString.Trim)) = 5 Then
                    g.TranslateTransform(LeftMargin, TopMargin + 35)
                Else
                    g.TranslateTransform(LeftMargin, TopMargin + 15)
                End If
                If CInt(Len(datapart(8).ToString.Trim)) > 15 Then g.TranslateTransform(LeftMargin, TopMargin)
                g.RotateTransform(90)
                g.DrawString(datapart(8).ToString.Trim, ft, Brushes.Black, 0, 0)
                g.ResetTransform()

                g.DrawRectangle(Pens.Black, LeftMargin + 8, TopMargin + 3, 117, 40)                         'print kotak
                'g.DrawString(datapart(0).ToString.Trim, ft1, Brushes.Black, LeftMargin + 10, TopMargin + 4)  'print kode vendor - MMy
                g.DrawString(Trim(getArray(datapart(0).ToString.Trim, "-", 0)), ft1, Brushes.Black, LeftMargin + 10, TopMargin + 4)  'print kode vendor - MMy
                g.DrawString(Trim(getArray(datapart(0).ToString.Trim, "-", 1)), ft1, Brushes.Black, LeftMargin + 107, TopMargin + 4)  'print kode vendor - MMy

                g.DrawString(datapart(1).ToString.Trim, ft1, Brushes.Black, LeftMargin + 10, TopMargin + 12) 'print longdesc 20 digit awal
                g.DrawString(datapart(2).ToString.Trim, ft1, Brushes.Black, LeftMargin + 10, TopMargin + 20) 'print longdesc 20 digit akhir

                rect.X = LeftMargin + 11
                rect.Y = TopMargin + 31
                rect.Width = 111
                rect.Height = 10
                If LCase(datapart(10).ToString.Trim) = "p" Then 'jika barang promo
                    g.FillRectangle(Brushes.Black, rect)
                    g.DrawString(Trim(getArray(datapart(3).ToString.Trim, "-", 0)), ft1, Brushes.White, LeftMargin + 12, TopMargin + 31)             'print burui -SBUDDMM
                Else
                    g.DrawString(Trim(getArray(datapart(3).ToString.Trim, "-", 0)), ft2, Brushes.Black, LeftMargin + 10, TopMargin + 31)             'print burui -SBUDDMM
                    'PrintBurui(g, myP, LeftMargin, Trim(getArray(datapart(3).ToString.Trim, "-", 0)))
                End If

                'MsgOK(datapart(4).ToString.Trim)
                If datapart(4).ToString.Trim.Length <> 13 Then
                    g.DrawImage(TextToBarcode(datapart(4).ToString.Trim, False, "code 128"), LeftMargin + 12, TopMargin + 48)    'print barcode plu
                ElseIf LeftStr(datapart(4).ToString.Trim, 5) = "71249" Then
                    g.DrawImage(TextToBarcode(datapart(4).ToString.Trim, False, "code 128"), LeftMargin + 12, TopMargin + 48, 170, 20)    'print barcode plu
                Else
                    'MsgOK("b")
                    g.DrawImage(TextToBarcode(datapart(4).ToString.Trim, False), LeftMargin + 22, TopMargin + 48, 90, 20)    'print barcode plu
                End If
                g.DrawString(datapart(5).ToString.Trim, ft1, Brushes.Black, LeftMargin + 25, TopMargin + 68)             'print label plu

                If datapart(9).ToString.Trim = "1" Then
                    g.DrawImage(TextToBarcode(datapart(6).ToString.Trim, False), LeftMargin + 22, TopMargin + 82, 90, 20)    'print barcode harga
                    g.DrawString(datapart(7).ToString.Trim, ft1, Brushes.Black, LeftMargin + 25, TopMargin + 102)            'print label harga
                End If
            End If
            LeftMargin = LeftMargin + 188
        Next

        pageNumber += 1
        e.HasMorePages = (pageNumber <= dgKPT.RowCount)
    End Sub
#End Region
#Region "HARGA"
    Private Sub BtnPrintPrice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrintPrice.Click
        If dg1.Rows.Count <= 0 Then Exit Sub
        If LCase(ReadIni("SETTING_BARCODE", "PREVIEWPRINT")) = "yes" Then
            dlgPrintPreview2.Document = PrintHarga
            dlgPrintPreview2.WindowState = FormWindowState.Maximized
            dlgPrintPreview2.ShowDialog()
        Else
            PrintHarga.Print()
        End If
        BtnClearPrice_Click(sender, e)
    End Sub
    Private Sub PrintHarga_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintHarga.BeginPrint
        pageNumber = 1
    End Sub
    Private Sub PrintHarga_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintHarga.PrintPage
        Dim leftorright, bottomortop, size, topmargin, leftmargin, _
            rectanglewidth, rectangleheight, textwidth, textheight, space As Integer
        Dim param, font As String

        font = "Times New Roman"
        leftorright = 382 : bottomortop = 55 : size = 11
        rectanglewidth = 280 : rectangleheight = 15 : textwidth = 209 : textheight = 146 : space = 130

        param = getStringFromDB("select param from m_settingbarcode where tipe='PRICE'")
        leftmargin = getValueFromString("leftmargin", param)
        topmargin = getValueFromString("topmargin", param)
        space = getValueFromString("space", param)

        Dim rowgrid As Integer
        Dim isi, periode As String
        Dim ft As New Font(font, size, FontStyle.Bold, GraphicsUnit.Point)
        Dim ft1 As New Font(font, 6, FontStyle.Bold, GraphicsUnit.Point)
        Dim sf As New StringFormat
        sf.LineAlignment = StringAlignment.Near

        periode = getPeriodeHarga()
        rowgrid = pageNumber - 1
        For x As Integer = 0 To 2
            isi = dg1.Rows(rowgrid).Cells(x).Value.ToString.Trim
            If isi <> "" Then
                Dim drawRect As New Rectangle(leftmargin, topmargin, textwidth, textheight)
                e.Graphics.TranslateTransform(leftorright, bottomortop)
                e.Graphics.RotateTransform(180)
                e.Graphics.DrawString(isi, ft, Brushes.Black, drawRect, sf)
                e.Graphics.ResetTransform()

                e.Graphics.TranslateTransform(leftorright - 87, bottomortop + 10)
                e.Graphics.RotateTransform(180)
                e.Graphics.DrawString(periode, ft1, Brushes.Black, drawRect, sf)
                e.Graphics.ResetTransform()
                leftmargin += space 'space
            End If
        Next

        pageNumber += 1
        e.HasMorePages = (pageNumber <= dg1.RowCount)
    End Sub
    Function getPeriodeHarga() As String
        'Dim arrBulan(), arrTahun() As String
        Dim arrTahun(100), arrBulan(12) As String
        Dim bulan, tahun As Integer
        Dim hasil As String = ""
        arrBulan(0) = "A" : arrBulan(1) = "B" : arrBulan(2) = "C" : arrBulan(3) = "D" : arrBulan(4) = "E" : arrBulan(5) = "F"
        arrBulan(6) = "G" : arrBulan(7) = "H" : arrBulan(8) = "I" : arrBulan(9) = "J" : arrBulan(10) = "K" : arrBulan(11) = "L"

        arrTahun(0) = "G" : arrTahun(1) = "H" : arrTahun(2) = "I" : arrTahun(3) = "J" : arrTahun(4) = "K" : arrTahun(5) = "L"
        arrTahun(6) = "M" : arrTahun(7) = "N" : arrTahun(8) = "O" : arrTahun(9) = "P" : arrTahun(10) = "Q" : arrTahun(11) = "R"
        arrTahun(12) = "S" : arrTahun(13) = "T" : arrTahun(14) = "U" : arrTahun(15) = "V" : arrTahun(16) = "W" : arrTahun(17) = "X"
        arrTahun(18) = "Y" : arrTahun(19) = "Z"

        bulan = Month(Now()) : tahun = Year(Now())
        hasil = arrBulan(bulan - 1) & arrTahun(tahun - 2017)

        Return hasil
    End Function
    Function getPeriodeHuruf(ByVal tgl As DateTime) As String
        'Dim arrBulan(), arrTahun() As String
        Dim arrTahun(100), arrBulan(12) As String
        Dim bulan, tahun As Integer
        Dim hasil As String = ""
        arrBulan(0) = "A" : arrBulan(1) = "B" : arrBulan(2) = "C" : arrBulan(3) = "D" : arrBulan(4) = "E" : arrBulan(5) = "F"
        arrBulan(6) = "G" : arrBulan(7) = "H" : arrBulan(8) = "I" : arrBulan(9) = "J" : arrBulan(10) = "K" : arrBulan(11) = "L"

        arrTahun(0) = "G" : arrTahun(1) = "H" : arrTahun(2) = "I" : arrTahun(3) = "J" : arrTahun(4) = "K" : arrTahun(5) = "L"
        arrTahun(6) = "M" : arrTahun(7) = "N" : arrTahun(8) = "O" : arrTahun(9) = "P" : arrTahun(10) = "Q" : arrTahun(11) = "R"
        arrTahun(12) = "S" : arrTahun(13) = "T" : arrTahun(14) = "U" : arrTahun(15) = "V" : arrTahun(16) = "W" : arrTahun(17) = "X"
        arrTahun(18) = "Y" : arrTahun(19) = "Z"

        bulan = Month(tgl) : tahun = Year(tgl)
        hasil = arrBulan(bulan - 1) & arrTahun(tahun - 2017)

        Return hasil
    End Function
#End Region
#Region "Discount KPL"
    Sub FillDiscKPL()
        dgKPL.Rows.Clear()

        Dim sudah As Boolean
        Dim q, qty As Integer
        Dim isi, value As String


        If dgKPL.RowCount = 0 Then dgKPL.Rows.Add("", "", "")
        For br As Integer = 0 To dgharga.RowCount - 1
            value = getColumnGrid(dgharga, "price", br)
            value = ReplacePetik(value)
            value = Replace(value, "Rp. ", "")
            value = Replace(value, ".", "")
            value = Replace(value, ",", "")
            value = Replace(value, "-", "")
            If getColumnGrid(dgharga, "qty", br) = "" Then
                qty = 0
            Else
                qty = CInt(getColumnGrid(dgharga, "qty", br))
            End If

            sudah = False
            q = 1
            Do
                sudah = False
                For x As Integer = 0 To 2
                    isi = dgKPL.Rows(dgKPL.RowCount - 1).Cells(x).Value.ToString.Trim
                    'MsgBox(isi)
                    If isi = "" Then
                        If q > qty Then Exit Do
                        dgKPL.Rows(dgKPL.RowCount - 1).Cells(x).Value = value
                        q += 1
                        sudah = True
                        'Continue For
                    End If
                Next
                If sudah = False Then
                    If q > qty Then Exit Do
                    dgKPL.Rows.Add(value, "", "")
                    q += 1
                    sudah = True
                End If

            Loop Until q > qty
        Next
    End Sub
    Private Sub BtnDiscKPL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDiscKPL.Click
        If dgharga.Rows.Count <= 0 Then Exit Sub
        FillDiscKPL()

        If LCase(ReadIni("SETTING_BARCODE", "PREVIEWPRINT")) = "yes" Then
            dlgPrintPreview2.Document = PrintDiscKPL
            dlgPrintPreview2.WindowState = FormWindowState.Maximized
            dlgPrintPreview2.ShowDialog()
        Else
            PrintDiscKPL.Print()
        End If
        BtnClearPrice_Click(sender, e)
    End Sub
    Private Sub PrintDiscKPL_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDiscKPL.BeginPrint
        pageNumber = 1
    End Sub
    Private Sub PrintDiscKPL_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDiscKPL.PrintPage
        Dim fontStr As String
        fontStr = "Times New Roman"
        Dim g As Graphics = e.Graphics

        Dim param, isi As String
        Dim xx, yy, fontsize, rowgrid, TopMargin, LeftMargin As Integer

        param = getStringFromDB("select param from m_settingbarcode where tipe='DISCOUNTKPL'")
        LeftMargin = getValueFromString("leftmargin", param)
        TopMargin = getValueFromString("topmargin", param)
        fontsize = CInt(getValueFromString("fontsize", param))
        xx = getValueFromString("x", param)
        yy = getValueFromString("y", param)

        Dim myP As New Point(xx, yy)

        Dim ft As New Font(fontStr, fontsize, FontStyle.Bold, GraphicsUnit.Point)
        Dim ft1 As New Font(fontStr, 20, FontStyle.Bold, GraphicsUnit.Point)
        rowgrid = pageNumber - 1
        For x As Integer = 0 To 2
            isi = dgKPL.Rows(rowgrid).Cells(x).Value.ToString.Trim
            'MsgOK(isi)
            If isi <> "" Then
                Dim ft3 As New Font("TAHOMA", 5, FontStyle.Regular, GraphicsUnit.Point)
                g.TranslateTransform(myP.X, myP.Y)
                g.RotateTransform(180)
                g.DrawString(isi, ft, Brushes.Black, 0, 0)
                g.ResetTransform()

                'g.TranslateTransform(LeftMargin - 45, TopMargin + 60)

                g.TranslateTransform(myP.X - 90, myP.Y - 46)
                g.RotateTransform(180)
                g.DrawString("%", ft1, Brushes.Black, 0, 0)
                g.ResetTransform()

                'g.TranslateTransform(LeftMargin - 45, TopMargin + 90)
                'g.RotateTransform(180)
                'g.DrawString("%", ft1, Brushes.Black, 0, 0)
                'g.ResetTransform()
            End If
            myP.X = myP.X + 126
            LeftMargin = LeftMargin + 126
        Next

        pageNumber += 1
        e.HasMorePages = (pageNumber <= dgKPL.RowCount)
    End Sub
#End Region
#Region "Discount KPT"
    Sub FillDiscKPT()
        dgKPT.Rows.Clear()

        Dim sudah As Boolean
        Dim q, qty As Integer
        Dim isi, value As String


        If dgKPT.RowCount = 0 Then dgKPT.Rows.Add("", "", "")
        For br As Integer = 0 To dgharga.RowCount - 1
            value = getColumnGrid(dgharga, "price", br)
            'MsgOK(value)
            value = ReplacePetik(value)
            value = Replace(value, "Rp. ", "")
            value = Replace(value, ".", "")
            value = Replace(value, ",", "")
            value = Replace(value, "-", "")
            'MsgOK(value)
            If value <> "" Then
                If getColumnGrid(dgharga, "qty", br) = "" Then
                    qty = 0
                Else
                    qty = CInt(getColumnGrid(dgharga, "qty", br))
                End If
                'MsgOK(qty)

                sudah = False
                q = 1
                Do
                    sudah = False
                    For x As Integer = 0 To 1
                        isi = dgKPT.Rows(dgKPT.RowCount - 1).Cells(x).Value.ToString.Trim
                        'MsgBox(isi)
                        If isi = "" Then
                            If q > qty Then Exit Do
                            dgKPT.Rows(dgKPT.RowCount - 1).Cells(x).Value = value
                            q += 1
                            sudah = True
                            'Continue For
                        End If
                    Next
                    If sudah = False Then
                        If q > qty Then Exit Do
                        dgKPT.Rows.Add(value, "", "")
                        q += 1
                        sudah = True
                    End If

                Loop Until q > qty
            End If
        Next
    End Sub
    Private Sub BtnDiscount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDiscount.Click
        If dgharga.Rows.Count <= 0 Then Exit Sub
        FillDiscKPT()

        If LCase(ReadIni("SETTING_BARCODE", "PREVIEWPRINT")) = "yes" Then
            dlgPrintPreview2.Document = PrintDiscKPT
            dlgPrintPreview2.WindowState = FormWindowState.Maximized
            dlgPrintPreview2.ShowDialog()
        Else
            PrintDiscKPT.Print()
        End If
        BtnClearPrice_Click(sender, e)
    End Sub
    Private Sub PrintDisc_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDiscKPT.BeginPrint
        pageNumber = 1
    End Sub
    Private Sub PrintDisc_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDiscKPT.PrintPage
        Dim fontStr As String
        fontStr = "Times New Roman"
        Dim g As Graphics = e.Graphics

        Dim param, isi As String
        Dim fontsize, rowgrid, TopMargin, LeftMargin As Integer

        param = getStringFromDB("select param from m_settingbarcode where tipe='DISCOUNTKPT'")
        LeftMargin = getValueFromString("leftmargin", param)
        TopMargin = getValueFromString("topmargin", param)
        fontsize = CInt(getValueFromString("fontsize", param))

        Dim ft As New Font(fontStr, fontsize, FontStyle.Bold, GraphicsUnit.Point)
        Dim ft1 As New Font(fontStr, 20, FontStyle.Bold, GraphicsUnit.Point)
        rowgrid = pageNumber - 1
        For x As Integer = 0 To 1
            isi = dgKPT.Rows(rowgrid).Cells(x).Value.ToString.Trim
            If isi <> "" Then
                g.TranslateTransform(LeftMargin, TopMargin)
                g.RotateTransform(90)
                g.DrawString(isi, ft, Brushes.Black, 0, 0)
                g.ResetTransform()

                g.TranslateTransform(LeftMargin - 45, TopMargin + 90)
                g.RotateTransform(90)
                g.DrawString("%", ft1, Brushes.Black, 0, 0)
                g.ResetTransform()
            End If
            LeftMargin = LeftMargin + 188
        Next

        pageNumber += 1
        e.HasMorePages = (pageNumber <= dgKPT.RowCount)
    End Sub
#End Region
#Region "Text Object"
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub
    Private Sub txtPLU_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPLU.KeyDown
        Dim s As String = ""
        If e.KeyCode = 13 Then
            gb_article.Visible = True
            s = "select top 30 im.plu, im.long_description as description, im.brand, im.supplier_code, im.burui, im.dp2 as sbu, " & vbCrLf & _
                "substring(im.long_description, 1, 20) as desc1, substring(im.long_description, 21, 20) as desc2, im.flag, " & vbCrLf & _
                "im.perishable from item_master im " & vbCrLf & _
                "where description<>'TIDAK AKTIF' and plu like '" & txtPLU.Text.Trim & "%' " & vbCrLf & _
                "ORDER BY plu"
            'Dbg(s)
            TampilTable(dgArticle, s)
            If dgArticle.Rows.Count = 1 Then
                insertPLU()
                txtPLU.Clear()
                txtPLU.Focus()
            End If
        End If
    End Sub
    Private Sub txtharga_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtharga.KeyDown
        If (e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9) OrElse (e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9) OrElse e.KeyCode = Keys.Back Then
            acceptableKey = True
        Else
            acceptableKey = False
        End If

        If e.KeyCode = 13 Then
            txtqty2.Focus()
        End If
    End Sub
    Private Sub txtharga_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtharga.TextChanged
        If txtharga.Text <> "" Then
            txtharga.Text = CDec(txtharga.Text).ToString("N0")
            txtharga.Select(txtharga.Text.Length, 0)
        End If
    End Sub
    Private Sub txtqty2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtqty2.KeyDown
        If e.KeyCode = 13 Then
            insertHarga()
        End If
    End Sub
    Private Sub txtqty2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtqty2.TextChanged

    End Sub
    Private Sub txtQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQty.KeyDown
        If e.KeyCode = 13 Then
            For x As Integer = 0 To dg.RowCount - 1
                FillCellGrid(dg, "qty", txtQty.Text, x)
            Next
            txtQty.Clear()
        End If
    End Sub
    Private Sub txtQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQty.TextChanged

    End Sub
#End Region
#Region "Button"
    Private Sub BtnInsertHarga_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInsertHarga.Click
        insertHarga()
    End Sub
    Private Sub BtnClearPrice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClearPrice.Click
        txtharga.Clear()
        txtqty2.Clear()
        dgharga.Rows.Clear()
        dgKPL.Rows.Clear()
        dgKPT.Rows.Clear()
        dg1.Rows.Clear()
        txtharga.Focus()
    End Sub
    Private Sub BtnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClear.Click
        txtPLU.Clear()
        dg.Rows.Clear()
        dgKPL.Rows.Clear()
        dgKPT.Rows.Clear()
        gb_article.Visible = False
        txtPLU.Focus()
    End Sub
#End Region
#Region "Menu Focus"
    Private Sub FocusPLUToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FocusPLUToolStripMenuItem.Click
        rbGR.Checked = False
        enableGR(False)
        rbPLU.Checked = True
        enablePLU(True)
    End Sub
    Private Sub FocusGRToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FocusGRToolStripMenuItem.Click
        rbGR.Checked = True
        enableGR(True)
        rbPLU.Checked = False
        enablePLU(False)
    End Sub
    Private Sub FocusGridToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FocusGridToolStripMenuItem.Click
        dg.Focus()
        dg.CurrentCell = dg.Rows(0).Cells(3)
    End Sub
    Private Sub FocusFindToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FocusFindToolStripMenuItem.Click
        If dgArticle.RowCount = 1 Then
            insertPLU()
        Else
            dgArticle.Focus()
        End If
    End Sub
    Private Sub FocusPriceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FocusPriceToolStripMenuItem.Click
        txtharga.Clear()
        txtharga.Focus()
    End Sub
    Private Sub FocusQtyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FocusQtyToolStripMenuItem.Click
        txtqty2.Clear()
        txtqty2.Focus()
    End Sub
    Private Sub FocusQtyPluToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FocusQtyPluToolStripMenuItem.Click
        txtQty.Clear()
        txtQty.Focus()
    End Sub
#End Region

    Private Sub TxtGR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtGR.KeyDown
        If e.KeyCode = 13 Then
            Dim dsa As DataSet
            Dim sSQL, docEntry, docNum As String
            docNum = TxtGR.Text.Trim
            docEntry = ""
            sSQL = "select docentry, docnum, cardcode, cardname " & vbCrLf & _
                    "from OPDN " & vbCrLf & _
                    "where cardcode in ( select cardcode from ocrd where cardcode like '0%' and groupcode=101 ) " & vbCrLf & _
                    "and docnum='" & docNum & "' " & vbCrLf & _
                    ""
            dsa = QueryToDataset2(sSQL, StrConSAP)
            If dsa.Tables(0).Rows.Count <= 0 Then
                MsgError("No. GR Tidak Ditemukan / Bukan Direct MD")
                clearDataSet(dsa)
                Exit Sub
            End If
            docEntry = getDSString(dsa, 0, "docentry")
            clearDataSet(dsa)
            If MsgConfirm("Process Barcode / Harga ?" & vbCrLf & _
                          "[YES] Process Barcode" & vbCrLf & _
                          "[NO]  Process Harga") = vbYes Then
                processPLUFromGR(docEntry, docNum)
            Else
                processPriceFromGR(docEntry, docNum)
            End If
        End If
    End Sub
    Sub processPLUFromGR(ByVal docEntry As String, ByVal docNum As String)
        Dim plu, s As String
        Dim x As Integer = 0
        Dim harga As Double
        Dim dsp, dsi As New DataSet

        dg.Rows.Clear()
        gb_article.Visible = True
        plu = ""
        s = "select a.docentry, a.docnum, b.itemcode, b.quantity " & vbCrLf & _
                              "from OPDN a " & vbCrLf & _
                              "left join PDN1 b on a.docentry=b.docentry " & vbCrLf & _
                              "inner join OITM c on b.itemcode=c.itemcode " & vbCrLf & _
                              "where a.docentry='" & docEntry & "' and  " & vbCrLf & _
                              "a.docnum='" & docNum & "' and c.sellitem='Y' " & vbCrLf & _
                              "order by linenum"
        dsp = QueryToDataset2(s, StrConSAP)
        For x = 0 To dsp.Tables(0).Rows.Count - 1
            s = "select im.plu, im.long_description as description, im.brand, im.supplier_code, im.burui, im.dp2 as sbu, " & vbCrLf & _
                "substring(im.long_description, 1, 20) as desc1, substring(im.long_description, 21, 20) as desc2, im.flag, " & vbCrLf & _
                "im.perishable, '" & dsp.Tables(0).Rows(x).Item("quantity").ToString & "' as qty from item_master im " & vbCrLf & _
                "where description<>'TIDAK AKTIF' and " & vbCrLf & _
                "article_code='" & dsp.Tables(0).Rows(x).Item("itemcode").ToString & "' " & vbCrLf & _
                "ORDER BY plu"
            dsi = QueryToDataset(s)
            If dsi.Tables(0).Rows.Count > 0 Then
                harga = 0
                If CInt(getDSString(dsi, 0, "flag")) = 0 Then harga = getItemPrice(getDSString(dsi, 0, "plu")) 'direct
                dg.Rows.Add("1", getDSString(dsi, 0, "plu"), getDSString(dsi, 0, "description"), harga, _
                            CInt(getDSString(dsi, 0, "qty")), Format(Now, "dd-MM-yyyy"), getDSString(dsi, 0, "sbu"), _
                            getDSString(dsi, 0, "supplier_code"), getDSString(dsi, 0, "burui"), _
                            getDSString(dsi, 0, "desc1"), getDSString(dsi, 0, "desc2"), "", _
                            getDSString(dsi, 0, "flag"), getDSString(dsi, 0, "perishable"))
            End If
        Next
        clearDataSet(dsp)
        clearDataSet(dsi)
        TxtGR.Clear()
        dg.Focus()
    End Sub
    Sub processPriceFromGR(ByVal docEntry As String, ByVal docNum As String)
        Dim s As String
        Dim dsp, dsi As New DataSet
        Dim harga As Double
        Dim qty As Integer
        s = "select a.docentry, a.docnum, b.itemcode, b.quantity " & vbCrLf & _
                              "from OPDN a " & vbCrLf & _
                              "left join PDN1 b on a.docentry=b.docentry " & vbCrLf & _
                              "inner join OITM c on b.itemcode=c.itemcode " & vbCrLf & _
                              "where a.docentry='" & docEntry & "' and  " & vbCrLf & _
                              "a.docnum='" & docNum & "' and c.sellitem='Y' " & vbCrLf & _
                              "order by linenum"
        dsp = QueryToDataset2(s, StrConSAP)
        For x = 0 To dsp.Tables(0).Rows.Count - 1
            s = "select im.plu, im.long_description as description, im.brand, im.supplier_code, im.burui, im.dp2 as sbu, " & vbCrLf & _
                "substring(im.long_description, 1, 20) as desc1, substring(im.long_description, 21, 20) as desc2, im.flag, " & vbCrLf & _
                "im.perishable, '" & dsp.Tables(0).Rows(x).Item("quantity").ToString & "' as qty from item_master im " & vbCrLf & _
                "where description<>'TIDAK AKTIF' and " & vbCrLf & _
                "article_code='" & dsp.Tables(0).Rows(x).Item("itemcode").ToString & "' " & vbCrLf & _
                "ORDER BY plu"
            dsi = QueryToDataset(s)
            If dsi.Tables(0).Rows.Count > 0 Then
                harga = 0
                If CInt(getDSString(dsi, 0, "flag")) = 0 Then harga = getItemPrice(getDSString(dsi, 0, "plu")) 'direct
                qty = CInt(getDSString(dsi, 0, "qty"))
                createDatagridHarga(harga, qty)                
            End If
        Next
        clearDataSet(dsp)
        clearDataSet(dsi)
        TxtGR.Clear()
        dgharga.Focus()
    End Sub
    Sub createDatagridHarga(ByVal harga As Double, ByVal qty As Integer)
        Dim isi, hargastr As String
        Dim sudah As Boolean

        hargastr = "Rp. " & CDec(harga).ToString("N0")
        isi = ""
        With dgharga
            .Rows.Add(hargastr, qty)
        End With

        sudah = False
        If dg1.RowCount = 0 Then
            dg1.Rows.Add("", "", "")
            'Else
        End If

        Dim q As Integer
        q = 1

        Do
            sudah = False
            For x As Integer = 0 To 2
                isi = dg1.Rows(dg1.RowCount - 1).Cells(x).Value.ToString.Trim
                'MsgBox(isi)
                If isi = "" Then
                    If q > CInt(qty) Then Exit Do
                    dg1.Rows(dg1.RowCount - 1).Cells(x).Value = hargastr
                    q += 1
                    sudah = True
                    'Continue For
                End If
            Next
            If sudah = False Then
                If q > CInt(qty) Then Exit Do
                dg1.Rows.Add(hargastr, "", "")
                q += 1
                sudah = True
            End If

        Loop Until q > CInt(qty)

        'txtharga.Focus()
    End Sub
  
    Private Sub TxtGR_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtGR.TextChanged

    End Sub

    Private Sub txtPLU_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPLU.TextChanged

    End Sub

    Private Sub dgArticle_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgArticle.CellContentClick

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SPGBarcodeForm.ShowDialog()
        FormLoad()
    End Sub
End Class
