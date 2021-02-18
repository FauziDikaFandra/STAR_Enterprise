Imports System.IO
Imports Microsoft.Office.Interop
Public Class Download_Master
    Dim dsBrand, dsArticle As DataSet
    Dim Brandtxt As String
    Dim SButxt As String
    Dim loopClick As Integer = 0
    Dim loopClick2 As Integer = 0
    Dim checkedAllBrand As Boolean

    Private Sub cbCH_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCH.CheckedChanged, cbHH.CheckedChanged, cbLA.CheckedChanged, cbLD.CheckedChanged, cbMD.CheckedChanged, cbSC.CheckedChanged
        SButxt = ""
        Brandtxt = ""
        Dim cr As Control
        Dim loopgb1 As Integer = 0
        cbAllBrand.Checked = False
        cbAllPLU.Checked = False
        clbBrand.Items.Clear()
        SButxt &= "And dp2 in ("
        For Each cr In GroupBox1.Controls
            If TypeOf cr Is CheckBox Then
                If CType(cr, CheckBox).Checked = True Then
                    If cr.Tag <> "All" Then
                        loopgb1 += 1
                        If loopgb1 > 1 Then
                            SButxt &= ","
                        End If
                        SButxt &= "'" & cr.Tag & "'"
                    End If

                End If
            End If
        Next
        If SButxt <> "And dp2 in (" Then
            SButxt &= ")"
            dsBrand = getSqldbPromo("Select distinct brand from [HODBASE01].CentralPOS.dbo.item_master where branch_id = '" & CbStore.SelectedValue & "' " & SButxt & " Order By Brand asc")
            If dsBrand.Tables(0).Rows.Count > 0 Then
                For Each ro As DataRow In dsBrand.Tables(0).Rows
                    clbBrand.Items.Add(ro("Brand"))
                Next
            End If
        End If
        txtScr2.Text = ""
        txtScr2.Focus()
    End Sub

    Private Sub clbBrand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clbBrand.Click
        clbBrand.CheckOnClick = True
        cbAllPLU.Checked = False
        loopClick = 1
    End Sub


    Private Sub clbArticle_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        clbBrand.CheckOnClick = True
    End Sub

    Private Sub cbAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAll.CheckedChanged
        Dim loopgb1 As Integer = 0
        cbAllBrand.Checked = False
        cbAllPLU.Checked = False
        If cbAll.Checked = True Then
            cbCH.Checked = True
            cbHH.Checked = True
            cbLA.Checked = True
            cbLD.Checked = True
            cbMD.Checked = True
            cbSC.Checked = True
            clbBrand.Items.Clear()
            SButxt = ""
            dsBrand = getSqldbPromo("Select distinct brand from [HODBASE01].CentralPOS.dbo.item_master where branch_id = '" & CbStore.SelectedValue & "' " & SButxt & " Order By Brand asc")
            If dsBrand.Tables(0).Rows.Count > 0 Then
                For Each ro As DataRow In dsBrand.Tables(0).Rows
                    clbBrand.Items.Add(ro("Brand"))
                Next
            End If

            Exit Sub
        Else
            cbCH.Checked = False
            cbHH.Checked = False
            cbLA.Checked = False
            cbLD.Checked = False
            cbMD.Checked = False
            cbSC.Checked = False
            clbBrand.Items.Clear()
            Exit Sub
        End If
        txtScr2.Text = ""
        txtScr2.Focus()
    End Sub

    Private Sub cbAllBrand_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAllBrand.CheckedChanged
        Dim HitungTotal As Integer = 0
        checkedAllBrand = True
        clbArticle.Items.Clear()
        If cbAllBrand.Checked = True Then
            If clbBrand.Items.Count > 0 Then
                For idx As Integer = 0 To clbBrand.Items.Count - 1
                    Me.clbBrand.SetItemCheckState(idx, CheckState.Checked)
                    HitungTotal += 1
                Next
                Label1.Text = "Total Brand Checked : " & CDec(HitungTotal).ToString("N0")
            End If
            dsBrand = getSqldbPromo("Select distinct PLU,Description from [HODBASE01].CentralPOS.dbo.item_master where branch_id = '" & CbStore.SelectedValue & "' " & SButxt & Brandtxt & " And Description <> 'TIDAK AKTIF' and burui not in ('NMD92ZZZ9','NMD98ZZZ9') and  PLU NOT IN('9000013100002', '9000063900003','9000012800002','9000012900009', '9000013900008','9000014000004','9000039000003','9000059600009', '9000059000007','9000059100004', '9000059200001','9000059300008','9000059400005', '9000063400008','9000063500005','9000036500005') ")
            If dsBrand.Tables(0).Rows.Count > 0 Then
                For Each ro As DataRow In dsBrand.Tables(0).Rows
                    clbArticle.Items.Add(ro("PLU").ToString.Trim & "  " & ro("Description").ToString.Trim)
                Next
            End If
        Else
            For idx As Integer = 0 To clbBrand.Items.Count - 1
                Me.clbBrand.SetItemCheckState(idx, CheckState.Unchecked)
            Next
            Label1.Text = "Total Brand Checked : " & CDec(HitungTotal).ToString("N0")
        End If
        checkedAllBrand = False
        txtSrc.Focus()
    End Sub

    Private Sub clbBrand_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles clbBrand.ItemCheck
        If checkedAllBrand = True Then
            Exit Sub
        End If

        Brandtxt = ""
        If loopClick = 1 Then
            loopClick = 0
            Me.clbBrand.SetItemCheckState(e.Index, e.NewValue)
            Brandtxt = ""
        End If

        Dim loopgb1 As Integer = 0
        clbArticle.Items.Clear()
        Brandtxt &= "And Brand in ("
        For Each cr In clbBrand.CheckedItems
            loopgb1 += 1
            If loopgb1 > 1 Then
                Brandtxt &= ","
            End If
            Brandtxt &= "'" & Replace(cr.ToString.Trim, "'", "''") & "'"
        Next
        Label1.Text = "Total Brand Checked : " & CDec(loopgb1).ToString("N0")
        If Brandtxt <> "And Brand in (" Then
            Brandtxt &= ")"
            dsBrand = getSqldbPromo("Select distinct PLU,Description from [HODBASE01].CentralPOS.dbo.item_master where branch_id = '" & CbStore.SelectedValue & "' " & SButxt & Brandtxt & " And Description <> 'TIDAK AKTIF' and burui not in ('NMD92ZZZ9','NMD98ZZZ9') and  PLU NOT IN('9000013100002', '9000063900003','9000012800002','9000012900009', '9000013900008','9000014000004','9000039000003','9000059600009', '9000059000007','9000059100004', '9000059200001','9000059300008','9000059400005', '9000063400008','9000063500005','9000036500005') ")
            If dsBrand.Tables(0).Rows.Count > 0 Then
                For Each ro As DataRow In dsBrand.Tables(0).Rows
                    clbArticle.Items.Add(ro("PLU").ToString.Trim & "  " & ro("Description").ToString.Trim)
                Next
            End If
        End If
        txtSrc.Focus()
    End Sub

    Private Sub cbAllPLU_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAllPLU.CheckedChanged
        Dim HitungTotal As Integer = 0
        If cbAllPLU.Checked = True Then
            If clbArticle.Items.Count > 0 Then
                For idx As Integer = 0 To clbArticle.Items.Count - 1
                    Me.clbArticle.SetItemCheckState(idx, CheckState.Checked)
                    HitungTotal += 1
                Next
                Label2.Text = "Total PLU Checked : " & CDec(HitungTotal).ToString("N0")
            End If
        Else
            For idx As Integer = 0 To clbArticle.Items.Count - 1
                Me.clbArticle.SetItemCheckState(idx, CheckState.Unchecked)
            Next
            Label2.Text = "Total PLU Checked : " & CDec(HitungTotal).ToString("N0")
        End If
    End Sub

    Private Sub Download_Master_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        checkedAllBrand = False
        Dim c As New ArrayList
        Try

            c.Add(New CCombo("S001", "*** DEFAULT STORE ***"))
            c.Add(New CCombo("S001", "S001 - MALL KELAPA GADING"))
            c.Add(New CCombo("S002", "S002 - STAR MALL SERPONG"))
            c.Add(New CCombo("S003", "S003 - STAR MALL BEKASI"))
            c.Add(New CCombo("S011", "S011 - STAR BY THE BEACH"))
            With CbStore
                .DataSource = c
                .DisplayMember = "Number_Name"
                .ValueMember = "ID"
            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

        Select Case SbuCode
            Case "CH", "HH"
                cbAll.Visible = False
                cbMD.Visible = False
                cbLA.Visible = False
                cbLD.Visible = False
                cbCH.Location = New Point(10, 20)
                cbHH.Location = New Point(80, 20)
                GroupBox1.Height = 45
                GroupBox2.Location = New Point(11, 120)
                GroupBox2.Height = 248
            Case "MD"
                cbAll.Visible = False
                cbCH.Visible = False
                cbHH.Visible = False
                cbLA.Visible = False
                cbLD.Visible = False
                cbMD.Location = New Point(10, 20)
                GroupBox1.Height = 45
                GroupBox2.Location = New Point(11, 120)
                GroupBox2.Height = 248
            Case "LA"
                cbAll.Visible = False
                cbCH.Visible = False
                cbHH.Visible = False
                cbMD.Visible = False
                cbLD.Visible = False
                cbLA.Location = New Point(10, 20)
                GroupBox1.Height = 45
                GroupBox2.Location = New Point(11, 120)
                GroupBox2.Height = 248
            Case "LD"
                cbAll.Visible = False
                cbCH.Visible = False
                cbHH.Visible = False
                cbMD.Visible = False
                cbLA.Visible = False
                cbLD.Location = New Point(10, 20)
                GroupBox1.Height = 45
                GroupBox2.Location = New Point(11, 120)
                GroupBox2.Height = 248
        End Select
    End Sub

    Private Sub clbArticle_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles clbArticle.Click
        clbArticle.CheckOnClick = True
        loopClick2 = 1
    End Sub

    Private Sub clbArticle_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles clbArticle.ItemCheck
        If loopClick2 = 1 Then
            loopClick2 = 0
            Me.clbArticle.SetItemCheckState(e.Index, e.NewValue)
        End If
        Label2.Text = "Total PLU Checked : " & CDec(clbArticle.CheckedItems.Count).ToString("N0")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'DownloadNotepad()
        DownloadExcel()
        Button2_Click(sender, e)
    End Sub

    Sub DownloadNotepad()
        Dim txtFileNew As String = Now.Year & Now.Month
        Dim line As String = ""
        Dim dsFile As DataSet
        Dim PLUStr As String = ""
        Dim loopgb1 As Integer = 0
        PLUStr &= "And PLU in ("
        For Each cr In clbArticle.CheckedItems
            loopgb1 += 1
            If loopgb1 > 1 Then
                PLUStr &= ","
            End If
            PLUStr &= "'" & Microsoft.VisualBasic.Left(cr.ToString, 13).ToString.Trim & "'"
        Next
        PLUStr &= ")"
        If File.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Promo.txt") Then
            Try
                File.Delete(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Promo.txt")
            Catch ex As Exception
                MsgBox("File is Being Opened !!!")
                Exit Sub
            End Try

        End If
        If cbAllPLU.Checked = True Then
            PLUStr = ""
        End If
        Dim sw As New IO.StreamWriter(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Promo.txt")
        sw.Write(line)
        dsFile = getSqldbPromo("Select distinct Dp2 as SBU,substring(burui,2,2) as Dept,brand,PLU,Description from [HODBASE01].CentralPOS.dbo.item_master where branch_id = '" & CbStore.SelectedValue & "' " & SButxt & Brandtxt & PLUStr & " And Description <> 'TIDAK AKTIF' and burui not in ('NMD92ZZZ9','NMD98ZZZ9') and  PLU NOT IN('9000013100002', '9000063900003','9000012800002','9000012900009', '9000013900008','9000014000004','9000039000003','9000059600009', '9000059000007','9000059100004', '9000059200001','9000059300008','9000059400005', '9000063400008','9000063500005','9000036500005') ")

        If dsFile.Tables(0).Rows.Count > 0 Then
            For Each ro As DataRow In dsFile.Tables(0).Rows
                sw.Write(ro(0).ToString.Trim & vbTab & ro(1).ToString.Trim & vbTab & ro(2).ToString.Trim & vbTab & ro(3).ToString.Trim & vbTab & ro(4).ToString.Trim & vbNewLine)
            Next
        End If

        sw.Close()
        sw.Dispose()
        Process.Start(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Promo.txt")
    End Sub

    Sub DownloadExcel()
        If clbArticle.CheckedItems.Count = 0 Then
            MsgBox("Please Checked Any Article First !!!")
            Exit Sub
        End If
        If File.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\PromoDetail.xlsx") Then
            File.Delete(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\PromoDetail.xlsx")
        End If
        If File.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Promo.xlsx") Then
            File.Delete(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Promo.xlsx")
        End If
        Dim sFileName As String
        Dim txtFileNew As String = Now.Year & Now.Month
        Dim line As String = ""
        Dim dsFile As DataSet
        Dim PLUStr As String = ""
        Dim loopgb1 As Integer = 0
        sFileName = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\PromoDetail.xlsx"
        PLUStr &= "And PLU in ("
        For Each cr In clbArticle.CheckedItems
            loopgb1 += 1
            If loopgb1 > 1 Then
                PLUStr &= ","
            End If
            PLUStr &= "'" & Microsoft.VisualBasic.Left(cr.ToString, 14).ToString.Trim & "'"
        Next
        PLUStr &= ")"
        If File.Exists(sFileName) Then
            Try
                File.Delete(sFileName)
            Catch ex As Exception
                MsgBox("File is Being Opened !!!")
                Exit Sub
            End Try

        End If
        If cbAllPLU.Checked = True Then
            PLUStr = ""
        End If

        dsFile = getSqldbPromo("Select distinct Dp2 as SBU,substring(burui,2,2) as Dept,brand,PLU,Description from [HODBASE01].CentralPOS.dbo.item_master where branch_id = '" & CbStore.SelectedValue & "' " & SButxt & Brandtxt & PLUStr & " And Description <> 'TIDAK AKTIF' and burui not in ('NMD92ZZZ9','NMD98ZZZ9') and  PLU NOT IN('9000013100002', '9000063900003','9000012800002','9000012900009', '9000013900008','9000014000004','9000039000003','9000059600009', '9000059000007','9000059100004', '9000059200001','9000059300008','9000059400005', '9000063400008','9000063500005','9000036500005') ")

        If dsFile.Tables(0).Rows.Count > 0 Then

            Dim chartRange As Excel.Range
            Dim xl As Object
            Dim xlWorkBook As Object
            Dim xlWorksheet As Object
            Dim dsExcel As New DataSet
            Dim Opt As String = ""
            xl = CreateObject("Excel.Application")
            Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
            If Dir(sFileName) = "" Then
                xlWorkBook = xl.Workbooks.Add  'File doesnt exist - add a new workbook
                System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
            Else
                xlWorkBook = xl.Workbooks.Open(sFileName)  'File exists - load it
            End If
            xlWorksheet = xlWorkBook.Worksheets(1)  'Work with the first worksheet
            'xl.Visible = True
            xlWorksheet.UsedRange.Clear()
            chartRange = xlWorksheet.Range("a3", "e3")
            chartRange.BorderAround(Excel.XlLineStyle.xlDouble, _
            Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex. _
            xlColorIndexAutomatic)
            xl.cells(1, 1) = ("Master Data")
            'xlWorksheet.Range("A3:F3").EntireColumn.AutoFit()
            'xlWorksheet.Range("a1", "a1").Font.Name = "Arial"
            xlWorksheet.Range("a1", "a1").Font.Size = 12
            xlWorksheet.Range("a1", "a1").Font.Bold = True
            xlWorksheet.Range("a3", "e3").Font.Size = 12
            xlWorksheet.Range("a3", "e3").Font.Bold = True
            xlWorksheet.Range("d4", "d" & dsFile.Tables(0).Rows.Count + 3).numberformat = "00"
            xl.cells(3, 1) = "SBU"
            xl.cells(3, 2) = "Dept"
            xl.cells(3, 3) = "brand"
            xl.cells(3, 4) = "PLU"
            xl.cells(3, 5) = "Description"

            Dim x As Integer = 0
            For Each ro As DataRow In dsFile.Tables(0).Rows
                For y As Integer = 1 To 5
                    If y = 4 Then
                        xl.cells(x + 4, y) = "'" & ro(y - 1).ToString
                    Else
                        xl.cells(x + 4, y) = ro(y - 1).ToString
                    End If

                Next
                x += 1
            Next

            xlWorksheet.Columns("A:AD").AutoFit()
            Try
                With SaveFileDialog1
                    .Title = " Detail Promo"
                    .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                    .DefaultExt = "xlsx"
                    .FileName = ""
                    .Filter = "Excel 97-2003 Template (*.xls)|*.xls|Excel Workbook (*.xlsx*)|*.xlsx*"
                    .FilterIndex = 2
                    If .ShowDialog() = DialogResult.OK Then
                        xlWorkBook.SaveAs(.FileName)
                        sFileName = .FileName
                    Else
                        xlWorkBook.SaveAs(sFileName)
                    End If
                End With
                'xlWorkBook.SaveAs(sFileName)
            Catch ex As Exception

            End Try
            'Save (and disconnect from) the Workbook
            xlWorkBook.Close(SaveChanges:=True)

            xlWorkBook = Nothing
            xl.Quit()                                'Close (and disconnect from) Excel
            xl = Nothing
            'make sure you clean up Excel, and SQL objects

            Process.Start(sFileName)
        End If
    End Sub

    Private Sub txtSrc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSrc.TextChanged


        clbArticle.Items.Clear()

        Label1.Text = "Total Brand Checked : " & CDec(clbBrand.Items.Count).ToString("N0")
        dsBrand = getSqldbPromo("Select distinct PLU,Description from [HODBASE01].CentralPOS.dbo.item_master where branch_id = '" & CbStore.SelectedValue & "' " & SButxt & Brandtxt & " And Description <> 'TIDAK AKTIF' and PLU like '" & txtSrc.Text & "%' and burui not in ('NMD92ZZZ9','NMD98ZZZ9') and  PLU NOT IN('9000013100002', '9000063900003','9000012800002','9000012900009', '9000013900008','9000014000004','9000039000003','9000059600009', '9000059000007','9000059100004', '9000059200001','9000059300008','9000059400005', '9000063400008','9000063500005','9000036500005') ")
        If dsBrand.Tables(0).Rows.Count > 0 Then
            For Each ro As DataRow In dsBrand.Tables(0).Rows
                clbArticle.Items.Add(ro("PLU").ToString.Trim & "  " & ro("Description").ToString.Trim)
            Next
        End If
        txtSrc.Focus()
    End Sub

    Private Sub txtScr2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtScr2.TextChanged
        Try
            Brandtxt = ""
            Dim cr As Control
            Dim loopgb1 As Integer = 0
            cbAllBrand.Checked = False
            cbAllPLU.Checked = False
            clbBrand.Items.Clear()
            SButxt &= "And dp2 in ("
            For Each cr In GroupBox1.Controls
                If TypeOf cr Is CheckBox Then
                    If CType(cr, CheckBox).Checked = True Then
                        If cr.Tag <> "All" Then
                            loopgb1 += 1
                            If loopgb1 > 1 Then
                                SButxt &= ","
                            End If
                            SButxt &= "'" & cr.Tag & "'"
                        End If

                    End If
                End If
            Next
            If SButxt <> "And dp2 in (" Then
                SButxt &= ")"
                dsBrand = getSqldbPromo("Select distinct brand from [HODBASE01].CentralPOS.dbo.item_master where branch_id = '" & CbStore.SelectedValue & "' " & SButxt & " And brand like '" & txtScr2.Text & "%' Order By Brand asc")
                If dsBrand.Tables(0).Rows.Count > 0 Then
                    For Each ro As DataRow In dsBrand.Tables(0).Rows
                        clbBrand.Items.Add(ro("Brand"))
                    Next
                End If
            End If
        Catch ex As Exception
            MsgBox("Checked any brand first !!!")
        End Try

    End Sub
End Class