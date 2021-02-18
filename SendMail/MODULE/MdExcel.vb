Imports Microsoft.Office.Interop
Module MdExcel
    Public xlApp As Excel.Application
    Public xlWorkBook As Excel.Workbook
    Public xlWorkSheet As List(Of Excel.Worksheet)
    Public misValue As Object = System.Reflection.Missing.Value
    Public isNewFileExcel As Boolean
    Public PathFileExcel As String
    Public colExcel As Array
    Public Sub isiColExcel()
        Dim s As String = "A,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,AA,AB,AC,AD,AE,AF,AG,AH,AI,AJ,AK,AL,AM,AN,AO,AP,AQ,AR,AS,AT,AU,AV,AW,AX,AY,AZ," & _
                          "BA,BB,BC,BD,BE,BF,BG,BH,BI,BJ,BK,BL,BM,BN,BO,BP,BQ,BR,BS,BT,BU,BV,BW,BX,BY,BZ," & _
                          "CA,CB,CC,CD,CE,CF,CG,CH,CI,CJ,CK,CL,CM,CN,CO,CP,CQ,CR,CS,CT,CU,CV,CW,CX,CY,CZ," & _
                          "DA,DB,DC,DD,DE,DF,DG,DH,DI,DJ,DK,DL,DM,DN,DO,DP,DQ,DR,DS,DT,DU,DV,DW,DX,DY,DZ," & _
                          "EA,EB,EC,ED,EE,EF,EG,EH,EI,EJ,EK,EL,EM,EN,EO,EP,EQ,ER,ES,ET,EU,EV,EW,EX,EY,EZ," & _
                          "FA,FB,FC,FD,FE,FF,FG,FH,FI,FJ,FK,FL,FM,FN,FO,FP,FQ,FR,FS,FT,FU,FV,FW,FX,FY,FZ," & _
                          "GA,GB,GC,GD,GE,GF,GG,GH,GI,GJ,GK,GL,GM,GN,GO,GP,GQ,GR,GS,GT,GU,GV,GW,GX,GY,GZ," & _
                          "HA,HB,HC,HD,HE,HF,HG,HH,HI,HJ,HK,HL,HM,HN,HO,HP,HQ,HR,HS,HT,HU,HV,HW,HX,HY,HZ"
        colExcel = Split(s, ",")
        'Dim x As Integer = 0
        'Dim words As String() = Split(s, ",")
        'For Each word As String In words
        '    word = UCase(word)
        '    colExcel(x) = word
        '    x += 1
        'Next
    End Sub
    Public Sub OpenExcel(ByVal pathName As String)
        If System.IO.File.Exists(pathName) = False Then Exit Sub
        Try
            Process.Start("EXCEL.EXE", """" & pathName & """")
        Catch ex As Exception
            MsgError("Can't Open Excel File : " & ex.Message)
        End Try
    End Sub
    Public Function PrepareExcel(Optional ByVal Properties As String = "", _
                                 Optional ByVal OpenPathFile As String = "", _
                                 Optional ByVal newFile As Boolean = True) As Boolean
        '"sheetname=StockOpname,sheet1, sheet2, sheet3;"
        isiColExcel()
        isNewFileExcel = newFile
        PathFileExcel = OpenPathFile

        Dim hasil As Boolean = True
        Dim x As Integer

        xlApp = New Microsoft.Office.Interop.Excel.Application()
        xlWorkSheet = New List(Of Excel.Worksheet)
        xlWorkSheet.Clear()
        If xlApp Is Nothing Then
            MsgError("Excel is not properly installed!!")
            xlApp = Nothing
            Return False
            Exit Function
        End If

        Dim sheetName As String = getValueFromString("sheetname", Properties)
        Dim words As String() = Split(sheetName, ",")

        If isNewFileExcel Then
            xlWorkBook = xlApp.Workbooks.Add(misValue)
            x = 1
            For Each sht In xlWorkBook.Worksheets
                If x >= 2 Then sht.delete()
                x += 1
            Next
            x = 0
            MsgOK(words.Count)
            For Each word As String In words 'pengulangan sheet
                MsgOK("x : " & x)
                If x = 0 Then
                    xlWorkSheet.Add(xlWorkBook.Sheets("Sheet1"))
                    If word.Trim <> "" Then xlWorkSheet(0).Name = word.Trim
                Else
                    'MsgOK(word)
                    If word.Trim <> "" Then
                        MsgOK("x : " & x & vbCrLf & _
                              "word : " & word)
                        xlWorkSheet.Add(CType(xlApp.Worksheets.Add(, xlApp.Sheets(xlApp.Sheets.Count), ), Excel.Worksheet))
                        xlWorkSheet(x).Name = word.Trim
                    End If
                End If
                x += 1
            Next
        Else
            xlWorkBook = xlApp.Workbooks.Open(OpenPathFile)
            x = 1
            For Each word As String In words 'pengulangan sheet
                If word.Trim <> "" Then
                    For Each sht In xlWorkBook.Worksheets
                        If LCase(word) = LCase(sht.name) Then sht.delete()
                    Next
                    xlWorkSheet.Add(CType(xlApp.Worksheets.Add(, xlApp.Sheets(xlApp.Sheets.Count), ), Excel.Worksheet))
                    xlWorkSheet(x - 1).Name = word.Trim
                End If
                x += 1
            Next
        End If
        Return hasil
    End Function
    Public Sub SaveExcel(Optional ByVal SaveAsPath As String = "", Optional ByVal Properties As String = "")
        If isNewFileExcel Then
            xlApp.DisplayAlerts = False
            xlWorkBook.SaveAs(PathFileExcel, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, _
                              Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue)
            xlApp.DisplayAlerts = True
        Else
            If SaveAsPath = "" Then
                xlWorkBook.Save()
            Else
                xlApp.DisplayAlerts = False
                xlWorkBook.SaveAs(SaveAsPath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, _
                                  Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue)
                xlApp.DisplayAlerts = True
            End If
        End If
        xlWorkBook.Close(True, misValue, misValue)
        xlApp.Quit()
    End Sub
    Public Sub DestroyExcel()
        releaseObject(xlWorkSheet)
        releaseObject(xlWorkBook)
        releaseObject(xlApp)
        xlApp = Nothing
        xlWorkBook = Nothing
        xlWorkSheet = Nothing
    End Sub
    Public Sub CellFormat(ByVal sh As Excel.Worksheet, Optional ByVal Properties As String = "", _
                          Optional ByVal Fill As String = "")
        'merge=;fontname=;fontsize=;fontstyle=;fontcolor=;backcolor=;columnwidth=;rowheight=;verticalalignment=;horizontalalignment=;
        Properties = LCase(Properties)
        Dim Range As String
        Range = getValueFromString("range", Properties)
        CellValue(sh, Range, Fill)
        CellFontName(sh, Range, getValueFromString("fontname", Properties))
        CellFontSize(sh, Range, getValueFromString("fontsize", Properties))
        CellFontStyle(sh, Range, getValueFromString("fontstyle", Properties))
        CellFontColor(sh, Range, getValueFromString("fontcolor", Properties))
        CellBackColor(sh, Range, getValueFromString("backcolor", Properties))
        CellColumnWidth(sh, Range, getValueFromString("columnwidth", Properties))
        CellRowHeight(sh, Range, getValueFromString("rowheight", Properties))
        CellVerticalAlignment(sh, Range, getValueFromString("verticalalignment", Properties))
        CellHorizontalAlignment(sh, Range, getValueFromString("horizontalalignment", Properties))
        CellMerge(sh, Range, getValueFromString("merge", Properties))
        CellWrap(sh, Range, getValueFromString("wrap", Properties))
        CellNumberFormat(sh, Range, getValueFromString("numberformat", Properties))
        CellBorder(sh, Range, getValueFromString("isborder", Properties))

        CellPaper(sh, Range, getValueFromString("paper", Properties))
        CellOrientation(sh, Range, getValueFromString("orientation", Properties))

        CellTopMargin(sh, Range, getValueFromString("topmargin", Properties))
        CellBottomMargin(sh, Range, getValueFromString("bottommargin", Properties))
        CellLeftMargin(sh, Range, getValueFromString("leftmargin", Properties))
        CellRightMargin(sh, Range, getValueFromString("rightmargin", Properties))

        'CellHeaderMargin(sh, Range, getValueFromString("headermargin", Properties))
        'CellFooterMargin(sh, Range, getValueFromString("footermargin", Properties))

        cellTitleRow(sh, Range, getValueFromString("titlerow", Properties))
    End Sub
    Public Sub CellValue(ByVal sh As Excel.Worksheet, ByVal Range As String, Optional ByVal Fill As String = "")
        If Fill.Trim = "" Then Exit Sub
        If LCase(Fill) = "clear" Then : sh.Range(Range).Value = "" : Exit Sub : End If
        sh.Range(Range).Value = Fill
    End Sub
    Public Sub CellFontName(ByVal sh As Excel.Worksheet, ByVal Range As String, Optional ByVal Fill As String = "Tahoma")
        If Fill.Trim = "" Then Exit Sub
        If LCase(Fill) = "clear" Or LCase(Fill) = "" Then : sh.Range(Range).Font.Name = "Tahoma" : Exit Sub : End If
        sh.Range(Range).Font.Name = Fill
    End Sub
    Public Sub CellFontSize(ByVal sh As Excel.Worksheet, ByVal Range As String, Optional ByVal Fill As String = "10")
        If Fill.Trim = "" Then Exit Sub
        If LCase(Fill) = "clear" Then : sh.Range(Range).Font.Size = 10 : Exit Sub : End If
        sh.Range(Range).Font.Size = Fill
    End Sub
    Public Sub CellFontStyle(ByVal sh As Excel.Worksheet, ByVal Range As String, Optional ByVal Fill As String = "clear")
        If Fill.Trim = "" Then Exit Sub
        If Fill = "clear" Then
            sh.Range(Range).Font.Italic = False
            sh.Range(Range).Font.Bold = False
            sh.Range(Range).Font.Underline = False
            Exit Sub
        End If
        sh.Range(Range).Font.Italic = False
        sh.Range(Range).Font.Bold = False
        sh.Range(Range).Font.Underline = False
        Fill = LCase(Fill)
        Dim words As String() = Split(Fill, ",")
        For Each word As String In words
            word = LCase(word)
            If word = "bold" Then sh.Range(Range).Font.Bold = True
            If word = "italic" Then sh.Range(Range).Font.Italic = True
            If word = "underline" Then sh.Range(Range).Font.Underline = True
        Next
    End Sub
    Public Sub CellFontColor(ByVal sh As Excel.Worksheet, ByVal Range As String, Optional ByVal Fill As String = "clear")
        If Fill.Trim = "" Then Exit Sub
        If LCase(Fill) = "clear" Then : sh.Range(Range).Font.Color = RGB(0, 0, 0) : Exit Sub : End If
        sh.Range(Range).Font.Color = RGB(0, 0, 0)
        Dim words As String() = Split(Fill, ",")
        If words.Count = 3 Then
            sh.Range(Range).Font.Color = RGB(CInt(words(0).ToString.Trim), CInt(words(1).ToString.Trim), CInt(words(2).ToString.Trim))
        End If
    End Sub
    Public Sub CellBackColor(ByVal sh As Excel.Worksheet, ByVal Range As String, Optional ByVal Fill As String = "clear")
        If Fill.Trim = "" Then Exit Sub
        If LCase(Fill) = "clear" Then
            'sh.Range(Range).Interior.ColorIndex = -4142
            sh.Range(Range).Interior.ColorIndex = 0
            Exit Sub
        End If
        'sh.Range(Range).Interior.ColorIndex = 0
        Dim words As String() = Split(Fill, ",")
        If words.Count = 3 Then
            'MsgOK(Range)
            'MsgOK(words(0).ToString.Trim)
            'MsgOK(words(1).ToString.Trim)
            'MsgOK(words(2).ToString.Trim)
            sh.Range(Range).Interior.Color = RGB(CInt(words(0).ToString.Trim), CInt(words(1).ToString.Trim), CInt(words(2).ToString.Trim))
        End If
    End Sub
    Public Sub CellColumnWidth(ByVal sh As Excel.Worksheet, ByVal Range As String, Optional ByVal Fill As String = "clear")
        If LCase(Fill) = "" Then : Exit Sub : End If
        If LCase(Fill) = "clear" Then : sh.Range(Range).EntireColumn.AutoFit() : Exit Sub : End If
        sh.Range(Range).ColumnWidth = CInt(Fill)
    End Sub
    Public Sub CellRowHeight(ByVal sh As Excel.Worksheet, ByVal Range As String, Optional ByVal Fill As String = "clear")
        If LCase(Fill) = "" Then : Exit Sub : End If
        If LCase(Fill) = "clear" Then : sh.Range(Range).EntireRow.AutoFit() : Exit Sub : End If
        sh.Range(Range).RowHeight = CInt(Fill)
    End Sub
    Public Sub CellVerticalAlignment(ByVal sh As Excel.Worksheet, ByVal Range As String, Optional ByVal Fill As String = "clear")
        If Fill.Trim = "" Then Exit Sub
        If LCase(Fill) = "clear" Then : sh.Range(Range).VerticalAlignment = Excel.Constants.xlCenter : Exit Sub : End If
        Fill = LCase(Fill)
        If Fill = "center" Then sh.Range(Range).VerticalAlignment = Excel.Constants.xlCenter
        If Fill = "top" Then sh.Range(Range).VerticalAlignment = Excel.Constants.xlTop
        If Fill = "bottom" Then sh.Range(Range).VerticalAlignment = Excel.Constants.xlBottom
    End Sub
    Public Sub CellHorizontalAlignment(ByVal sh As Excel.Worksheet, ByVal Range As String, Optional ByVal Fill As String = "clear")
        If Fill.Trim = "" Then Exit Sub
        If LCase(Fill) = "clear" Then : sh.Range(Range).HorizontalAlignment = Excel.Constants.xlLeft : Exit Sub : End If
        Fill = LCase(Fill)
        If Fill = "center" Then sh.Range(Range).HorizontalAlignment = Excel.Constants.xlCenter
        If Fill = "left" Then sh.Range(Range).HorizontalAlignment = Excel.Constants.xlLeft
        If Fill = "right" Then sh.Range(Range).HorizontalAlignment = Excel.Constants.xlRight
    End Sub
    Public Sub CellMerge(ByVal sh As Excel.Worksheet, ByVal Range As String, Optional ByVal Fill As String = "false")
        'If LCase(Fill) = "clear" Or LCase(Fill) = "" Then : sh.Range(Range).MergeCells = False : Exit Sub : End If
        If LCase(Fill) = "clear" Or LCase(Fill) = "" Then : Exit Sub : End If
        If LCase(Fill) = "true" Then
            sh.Range(Range).MergeCells = True
        ElseIf LCase(Fill) = "false" Then
            sh.Range(Range).MergeCells = False
        End If
    End Sub
    Public Sub CellWrap(ByVal sh As Excel.Worksheet, ByVal Range As String, Optional ByVal Fill As String = "false")
        'If LCase(Fill) = "clear" Or LCase(Fill) = "" Then : sh.Range(Range).MergeCells = False : Exit Sub : End If
        If LCase(Fill) = "clear" Or LCase(Fill) = "" Then : Exit Sub : End If
        If LCase(Fill) = "true" Then
            'MsgOK("true")
            sh.Range(Range).WrapText = True
        ElseIf LCase(Fill) = "false" Then
            'MsgOK("false")
            sh.Range(Range).WrapText = False
        End If
    End Sub
    Public Sub CellNumberFormat(ByVal sh As Excel.Worksheet, ByVal Range As String, Optional ByVal Fill As String = "@")
        If Fill.Trim = "" Then Exit Sub
        If LCase(Fill) = "clear" Then : sh.Range(Range).NumberFormat = "@" : Exit Sub : End If
        sh.Range(Range).NumberFormat = Fill
    End Sub
    Public Sub CellBorder(ByVal sh As Excel.Worksheet, ByVal Range As String, Optional ByVal Fill As String = "clear")
        If Fill.Trim = "" Then Exit Sub
        If LCase(Fill) = "clear" Then : sh.Range(Range).Borders.LineStyle = Excel.XlLineStyle.xlLineStyleNone : Exit Sub : End If
        If LCase(Fill) = "true" Then : sh.Range(Range).Borders.LineStyle = Excel.XlLineStyle.xlContinuous : Exit Sub : End If
    End Sub
    Public Sub CellPaper(ByVal sh As Excel.Worksheet, ByVal Range As String, Optional ByVal Fill As String = "clear")
        Fill = LCase(Fill)
        If Fill.Trim = "" Then Exit Sub
        If Fill = "clear" Then : sh.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4 : Exit Sub : End If
        If Fill = "a4" Then : sh.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4 : Exit Sub : End If
        If Fill = "legal" Then : sh.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperLegal : Exit Sub : End If
        If Fill = "letter" Then : sh.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperLetter : Exit Sub : End If
    End Sub
    Public Sub CellOrientation(ByVal sh As Excel.Worksheet, ByVal Range As String, Optional ByVal Fill As String = "clear")
        Fill = LCase(Fill)
        If Fill.Trim = "" Then Exit Sub
        If Fill = "clear" Then : sh.PageSetup.Orientation = Excel.XlPageOrientation.xlPortrait : Exit Sub : End If
        If Fill = "portrait" Then : sh.PageSetup.Orientation = Excel.XlPageOrientation.xlPortrait : Exit Sub : End If
        If Fill = "landscape" Then : sh.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape : Exit Sub : End If
    End Sub
    Public Sub CellTopMargin(ByVal sh As Excel.Worksheet, ByVal Range As String, Optional ByVal Fill As String = "1")
        Fill = LCase(Fill)
        If Fill.Trim = "" Then Exit Sub
        If Fill = "clear" Then : sh.PageSetup.TopMargin = 1 : Exit Sub : End If
        sh.PageSetup.TopMargin = Fill
    End Sub
    Public Sub CellBottomMargin(ByVal sh As Excel.Worksheet, ByVal Range As String, Optional ByVal Fill As String = "1")
        Fill = LCase(Fill)
        If Fill.Trim = "" Then Exit Sub
        If Fill = "clear" Then : sh.PageSetup.BottomMargin = 1 : Exit Sub : End If
        sh.PageSetup.BottomMargin = Fill
    End Sub
    Public Sub CellLeftMargin(ByVal sh As Excel.Worksheet, ByVal Range As String, Optional ByVal Fill As String = "1")
        Fill = LCase(Fill)
        If Fill.Trim = "" Then Exit Sub
        If Fill = "clear" Then : sh.PageSetup.LeftMargin = 1 : Exit Sub : End If
        sh.PageSetup.LeftMargin = Fill
    End Sub
    Public Sub CellRightMargin(ByVal sh As Excel.Worksheet, ByVal Range As String, Optional ByVal Fill As String = "1")
        Fill = LCase(Fill)
        If Fill.Trim = "" Then Exit Sub
        If Fill = "clear" Then : sh.PageSetup.RightMargin = 1 : Exit Sub : End If
        sh.PageSetup.RightMargin = Fill
    End Sub
    Public Sub CellHeaderMargin(ByVal sh As Excel.Worksheet, ByVal Range As String, Optional ByVal Fill As String = "1")
        Fill = LCase(Fill)
        If Fill.Trim = "" Then Exit Sub
        If Fill = "clear" Then : sh.PageSetup.HeaderMarginInch = 0.1 : Exit Sub : End If
        sh.PageSetup.HeaderMarginInch = Fill
    End Sub
    Public Sub CellFooterMargin(ByVal sh As Excel.Worksheet, ByVal Range As String, Optional ByVal Fill As String = "1")
        Fill = LCase(Fill)
        If Fill.Trim = "" Then Exit Sub
        If Fill = "clear" Then : sh.PageSetup.FooterMarginInch = 1 : Exit Sub : End If
        sh.PageSetup.FooterMarginInch = Fill
    End Sub
    Public Sub CellTitleRow(ByVal sh As Excel.Worksheet, ByVal Range As String, Optional ByVal Fill As String = "$1:$3")
        Fill = LCase(Fill)
        If Fill.Trim = "" Then Exit Sub
        sh.PageSetup.PrintTitleRows = Fill
    End Sub
    'xlWorkSheet.Add(xlWorkBook.Sheets("Sheet1"))
    'xlWorkSheet(0).Name = "Stock_Opname"
    'xlWorkSheet.Add(CType(xlApp.Worksheets.Add(, xlApp.Sheets(xlApp.Sheets.Count), ), Excel.Worksheet))
    'xlWorkSheet(1).Name = "Stock_Opname1"
    'xlWorkSheet = xlWorkBook.Worksheets
    'xlSheet(0) = DirectCast(xlWorkSheet.Add(xlWorkSheet(1), Type.Missing, Type.Missing, Type.Missing), Excel.Worksheet)
    'xlSheet(0) = CType(xlWorkBook.Worksheets.Add(), Excel.Worksheet)
    'xlSheet(0).Name = "Stock_Opname"
    'xlWorkSheet(0) = xlWorkBook.Sheets.Add(, xlWorkBook.Sheets(xlWorkBook.Sheets.Count))
    'xlWorkSheet(0).Name = "Stock_Opname"
    'xlWorkSheet(0) = New Excel.Worksheet
    'xlWorkSheet(0) = xlWorkBook.Sheets.Add(, xlWorkBook.Sheets(xlWorkBook.Sheets.Count))
    'xlWorkBook.Application.DisplayAlerts = False
    'xlWorkBook.Sheets("Sheet1").Delete()
    'xlWorkBook.Application.DisplayAlerts = True
    'xlWorkSheet.Add(CType(xlApp.Worksheets.Add(, xlApp.Sheets(xlApp.Sheets.Count), ), Excel.Worksheet))
    'xlWorkBook.Sheets.Add()
    'xlWorkBook.Sheets(0).name = "tes"
    'MsgOK("TotalSheet : " & xlWorkBook.Sheets.Count)

    'xlWorkSheet(0).Cells(1, 2) = "Sheet 1 Content"
    'xlWorkSheet(0).Range("B1").EntireColumn.AutoFit()
    'xlWorkSheet(0).Range("A2").Value = "Ahmad Setiadi"
    'xlWorkSheet(0).Range("A2").Font.Name = "Tahoma"
    'xlWorkSheet(0).Range("A2").Font.Size = 18
    'xlWorkSheet(0).Range("A2").Font.Italic = True
    'xlWorkSheet(0).Range("A2").Font.Bold = True
    'xlWorkSheet(0).Range("A2").Font.Underline = True
    'xlWorkSheet(0).Range("A2").Interior.Color = RGB(255, 255, 0)
    'xlWorkSheet(0).Range("A2").Font.Color = RGB(255, 0, 0)
    'xlWorkSheet(0).Range("A2").EntireColumn.AutoFit()
    'xlWorkSheet(0).Range("A2").ColumnWidth = 30
    'xlWorkSheet(0).Range("A2").RowHeight = 15
    'xlWorkSheet(0).Range("A2").EntireRow.AutoFit()
    'xlWorkSheet(0).Range("A2").VerticalAlignment = Excel.Constants.xlCenter
    'xlWorkSheet(0).Range("A2").HorizontalAlignment = Excel.Constants.xlCenter
End Module
