Public Class SPGBarcodeForm
    Dim WhsCode As String
    Dim pageNumber As Integer
    Function LineSpacing(ByVal txt As String, _
                         Optional ByVal sps As String = "  ")
        Dim hasil As String = ""
        For x = 1 To Len(txt)
            hasil += Mid(txt, x, 1) & sps
        Next
        hasil = Mid(hasil, 1, Len(hasil) - 1)
        Return hasil
    End Function
    Public Sub TampilTable(ByVal dg As DataGridView, ByVal SQL As String, Optional ByVal syarat As String = " (0=0) ", _
                           Optional ByVal strCon As String = "")
        Dim dstable As DataSet
        SQL = Replace(SQL, "@syarat", syarat)
        dstable = QueryToDataset(SQL, strCon)
        dg.AutoGenerateColumns = False
        dg.DataSource = dstable.Tables(0)
        dg.Focus()
    End Sub
    Sub insertBarcode()
        dg.Rows.Add("1", getColumnGrid(dgSPG, "spg_id"), getColumnGrid(dgSPG, "spg_barcode"), _
                    getColumnGrid(dgSPG, "spg_name"), "6", "")
    End Sub
    Sub FillColIsiGrid()
        'Exit Sub
        Dim s As String = ""
        Dim price As Double = 0
        For x As Integer = 0 To dg.RowCount - 1
            FillCellGrid(dg, "isi", "", x)
            If CInt(getColumnGrid(dg, "choose", x)) = 1 Then
                'MsgOK(getColumnGrid(dg, "spg_id", x))
                s = ""
                s += getColumnGrid(dg, "spg_id", x) & ";"
                s += getColumnGrid(dg, "spg_barcode", x) & ";"
                s += getColumnGrid(dg, "spg_name", x) & ";"
                s += getColumnGrid(dg, "qty", x) & ""
                FillCellGrid(dg, "isi", s, x)
            End If
        Next
    End Sub
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
                    'value = Format(q, "00#") & ";" & value
                    sudah = False
                    For x As Integer = 0 To 1
                        isi = dgKPT.Rows(dgKPT.RowCount - 1).Cells(x).Value.ToString.Trim
                        'MsgBox(isi)
                        If isi = "" Then
                            If q > qty Then Exit Do
                            dgKPT.Rows(dgKPT.RowCount - 1).Cells(x).Value = Format(q, "00#") & ";" & value
                            q += 1
                            sudah = True
                            'Continue For
                        End If
                    Next
                    If sudah = False Then
                        If q > qty Then Exit Do
                        dgKPT.Rows.Add(Format(q, "00#") & ";" & value, "", "")
                        q += 1
                        sudah = True
                    End If

                Loop Until q > qty
            End If
        Next
    End Sub
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
                        dgKPL.Rows(dgKPL.RowCount - 1).Cells(x).Value = Format(q, "00#") & ";" & value
                        q += 1
                        sudah = True
                        'Continue For
                    End If
                Next
                If sudah = False Then
                    If q > qty Then Exit Do
                    dgKPL.Rows.Add(Format(q, "00#") & ";" & value, "", "")
                    q += 1
                    sudah = True
                End If

            Loop Until q > qty
        Next
    End Sub
    Private Sub SPGBarcodeForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dg.Font = LblFont.Font
        dgSPG.Font = LblFont.Font
        dgSPG.RowsDefaultCellStyle.BackColor = Color.White
        dgSPG.AlternatingRowsDefaultCellStyle.BackColor = Color.Bisque
        dg.RowsDefaultCellStyle.BackColor = Color.White
        dg.AlternatingRowsDefaultCellStyle.BackColor = Color.Bisque

        LblStore.Text = ReadIni("SETTING_BARCODE", "WHSCODE")
        If LCase(LblStore.Text) = "s001" Then
            OpenDB_ABS_S001()
        ElseIf LCase(LblStore.Text) = "s002" Then
            OpenDB_ABS_S002()
        ElseIf LCase(LblStore.Text) = "s003" Then
            'MsgOK("oke")
            OpenDB_ABS_S003()
        End If
        WhsCode = LblStore.Text

        dgKPT.Rows.Clear()
        dgKPT.Rows.Add("001;898;2400000008989;HAHMAD AHMAD SANTOSO;3", _
                       "002;898;2400000008989;HAHMAD AHMAD SANTOSO;3")
        dgKPT.Rows.Add("003;8980;2400000089803;ANITA RUSDIANA;6", _
                       "004;8980;2400000089803;ANITA RUSDIANA;6")
        dgKPT.Rows.Add("005;10898;2400000108986;DEWI ANGGRAINI;7", _
                       "006;10898;2400000108986;DEWI ANGGRAINI;7")
    End Sub

    Private Sub txtPLU_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPLU.KeyDown
        Dim s As String = ""
        If e.KeyCode = 13 Then
            s = "select top 30 * " & vbCrLf & _
                "from v_karyawan " & vbCrLf & _
                "where spg_barcode like '%" & txtPLU.Text.Trim & "%' or " & vbCrLf & _
                "spg_name like '%" & txtPLU.Text.Trim & "%' or brand like '%" & txtPLU.Text.Trim & "%' " & vbCrLf & _
                "ORDER BY spg_name"
            TampilTable(dgSPG, s)
            dgSPG.Focus()
        End If
    End Sub

    Private Sub txtPLU_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPLU.TextChanged

    End Sub

    Private Sub dgSPG_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSPG.CellContentClick

    End Sub
    Private Sub BtnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClear.Click
        txtPLU.Clear()
        dg.Rows.Clear()
        dgSPG.Rows.Clear()
        dgKPT.Rows.Clear()
        dgKPL.Rows.Clear()
    End Sub
    Private Sub dgSPG_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSPG.CellDoubleClick
        insertBarcode()
    End Sub

    Private Sub dgSPG_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgSPG.KeyDown
        If e.KeyCode = 13 Then
            insertBarcode()
        End If
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        If dg.RowCount <= 0 Then Exit Sub
        FillColIsiGrid()
        FillGridKPT()
        
        If LCase(ReadIni("SETTING_BARCODE", "PREVIEWPRINT")) = "yes" Then
            dlgPrintPreview2.Document = PrintKPT
            dlgPrintPreview2.WindowState = FormWindowState.Maximized
            dlgPrintPreview2.ShowDialog()
        Else
            PrintKPT.Print()
        End If
    End Sub



    Private Sub PrintSPG_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintKPT.BeginPrint
        pageNumber = 1
    End Sub
    Private Sub PrintSPG_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintKPT.PrintPage
        Dim fontStr As String
        fontStr = "Times New Roman"
        Dim g As Graphics = e.Graphics
        Dim ft As New Font(fontStr, 7, FontStyle.Bold, GraphicsUnit.Point)
        Dim ft1 As New Font(fontStr, 6, FontStyle.Bold, GraphicsUnit.Point)

        Dim rowGrid, LeftMargin, TopMargin As Integer
        Dim param, isi As String
        Dim datapart() As String

        param = getStringFromDB("select param from m_settingbarcode where tipe='SPGBARCODEKPT'")
        LeftMargin = getValueFromString("leftmargin", Param)
        TopMargin = getValueFromString("topmargin", Param)

        rowGrid = pageNumber - 1
        For x As Integer = 0 To 1
            isi = dgKPT.Rows(rowGrid).Cells(x).Value.ToString.Trim
            datapart = Split(isi, ";")
            g.DrawString(datapart(0).ToString.Trim, ft1, Brushes.Black, LeftMargin, TopMargin)  'print kode vendor - MMy
            'g.DrawImage(TextToBarcode(datapart(2).ToString.Trim, False, "code 128", 1, 50), LeftMargin + 1, TopMargin + 26)    'print barcode plu
            g.DrawImage(TextToBarcode(datapart(2).ToString.Trim, False, "ean-13", 1, 50), LeftMargin + 1, TopMargin + 26)    'print barcode plu
            'g.DrawString(LineSpacing(datapart(2).ToString.Trim), ft, Brushes.Black, LeftMargin, TopMargin + 80)
            g.DrawString(LineSpacing(datapart(2).ToString.Trim, " "), ft, Brushes.Black, LeftMargin, TopMargin + 80)
            g.DrawString(LeftStr(datapart(3).ToString.Trim, 25), ft, Brushes.Black, LeftMargin, TopMargin + 91)
            LeftMargin += 188
        Next

        pageNumber += 1
        e.HasMorePages = (pageNumber <= dgKPT.RowCount)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If dg.RowCount <= 0 Then Exit Sub
        FillColIsiGrid()
        FillGridKPL()

        If LCase(ReadIni("SETTING_BARCODE", "PREVIEWPRINT")) = "yes" Then
            dlgPrintPreview2.Document = PrintKPL
            dlgPrintPreview2.WindowState = FormWindowState.Maximized
            dlgPrintPreview2.ShowDialog()
        Else
            PrintKPL.Print()
        End If

        'PrintKPL.Print()
        'dlgPrintPreview2.Document = PrintKPL
        'dlgPrintPreview2.WindowState = FormWindowState.Maximized
        'dlgPrintPreview2.ShowDialog()
    End Sub

    Private Sub PrintKPL_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintKPL.BeginPrint
        pageNumber = 1
    End Sub

    Private Sub PrintKPL_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintKPL.PrintPage
        Dim fontStr As String
        fontStr = "Times New Roman"
        Dim g As Graphics = e.Graphics
        Dim ft As New Font(fontStr, 7, FontStyle.Bold, GraphicsUnit.Point)
        Dim ft1 As New Font(fontStr, 5, FontStyle.Bold, GraphicsUnit.Point)

        Dim xx, yy, rowGrid, LeftMargin, TopMargin As Integer
        Dim param, isi As String
        Dim datapart() As String

        param = getStringFromDB("select param from m_settingbarcode where tipe='SPGBARCODEKPL'")
        'MsgOK(param)
        LeftMargin = getValueFromString("leftmargin", param)
        TopMargin = getValueFromString("topmargin", param)
        xx = getValueFromString("x", param)
        yy = getValueFromString("y", param)
        Dim myP As New Point(xx, yy)
        Dim CropRect As New Rectangle


        rowGrid = pageNumber - 1
        For x As Integer = 0 To 2
            isi = dgKPL.Rows(rowGrid).Cells(x).Value.ToString.Trim
            If isi <> "" Then
                datapart = Split(isi, ";")
                'g.DrawRectangle(Pens.Black, 25, 25, 90, 125)

                g.TranslateTransform(myP.X + 7, myP.Y + 65)
                g.RotateTransform(180)
                g.DrawString(datapart(0).ToString.Trim, ft, Brushes.Black, 0, 0)
                g.ResetTransform()

                'Dim CropRect As New Rectangle(0, 0, 110, 20)
                CropRect.X = 0
                CropRect.Y = 0
                CropRect.Width = 95
                CropRect.Height = 50
                g.DrawImage(TextToBarcode(datapart(2).ToString.Trim, True, "ean-13", 2, 50), New Rectangle(LeftMargin - 5, TopMargin + 40, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
                g.ResetTransform()

                g.TranslateTransform(myP.X + 7, myP.Y - 15)
                g.RotateTransform(180)
                g.DrawString(LineSpacing(datapart(2).ToString.Trim, " "), ft, Brushes.Black, 0, 0)
                g.ResetTransform()

                g.TranslateTransform(myP.X + 7, myP.Y - 25)
                g.RotateTransform(180)
                g.DrawString(LeftStr(datapart(3).ToString.Trim, 25), ft1, Brushes.Black, 0, 0)
                g.ResetTransform()
            End If

            LeftMargin += 126
            myP.X = myP.X + 126
        Next

        pageNumber += 1
        e.HasMorePages = (pageNumber <= dgKPL.RowCount)
    End Sub
End Class