Public Class CrossSalesFORM
    Dim ds, ds2, ds3 As New DataSet
    Dim totsales, totAllsales As Decimal
    Dim CatValName, CatStr, CatValStr As String
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
            Me.Close()
        End If
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        LblTGL.Text = UCase(Format(Now, "ddd, dd MMM yyyy"))
        LblJam.Text = Format(Now, "HH:mm:ss")
    End Sub

    Private Sub Form2_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        KiosInformasiFORM.Show()
        KiosInformasiFORM.GroupBox1.Focus()
        KiosInformasiFORM.TextBox1.Focus()
    End Sub
    Private Sub CrossSalesFORM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button3.Image = Image.FromFile(FolderImage & "go.ico")
        Dim ico As New System.Drawing.Icon(FolderImage & "star.ico") : Me.Icon = ico
        Timer1.Enabled = True
        Dim vq As New VQuery
        vq.Query("Select * from SPG_INSENT where SPG_ID = '" & UsrID & "'", "spg_id", DB_POS)
        If vq.RecordCount > 0 Then
            CatStr = vq.GetField("CATEGORY")
            CatValStr = vq.GetField("BRAND")
        Else
            MsgError("Data Insentif SPG untuk ID tersebut tidak ada !!!")
            vq.Dispose()
            Close()
            Exit Sub
        End If

        vq.Dispose()

        lv()
        Label7.Text = UsrID & " - " & UsrName
        CheckForIllegalCrossThreadCalls = False

        ComboBox1.Items.Clear()
        For x = 1 To 9 : ComboBox1.Items.Add(Now.Year & ".0" & x) : Next
        For x = 10 To 12 : ComboBox1.Items.Add(Now.Year & "." & x) : Next

        Select Case Microsoft.VisualBasic.Len(Now.Month.ToString)
            Case Is = 1 : ComboBox1.Text = Now.Year & ".0" & Now.Month
            Case Else : ComboBox1.Text = Now.Year & "." & Now.Month
        End Select

        Dim tim As New Timer
        tim.Interval = 2000
        AddHandler tim.Tick, AddressOf tim_Tick
        tim.Start()

        Button3_Click(sender, e)
    End Sub

    Sub lv()
        ListView1.Columns.Add("Periode", 150, HorizontalAlignment.Left)
        ListView1.Columns.Add("SBU", 100, HorizontalAlignment.Left)
        ListView1.Columns.Add("Brand", 400, HorizontalAlignment.Left)
        ListView1.Columns.Add("Net Sales", 150, HorizontalAlignment.Right)
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Label9.Visible = True
        ProgressBar1.Value = 0
        ProgressBar1.Visible = True
        ListView1.Items.Clear()
        Button3.Enabled = False
        GroupBox1.Enabled = False
        BackgroundWorker1.WorkerReportsProgress = True
        BackgroundWorker1.WorkerSupportsCancellation = True
        BackgroundWorker1.RunWorkerAsync()
    End Sub
    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        totsales = 0
        View(CatStr, UsrID, CatValStr)
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

    Sub View(ByVal Cat As String, ByVal SPG_ID As String, ByVal CatVal As String)
        Dim Prg As Decimal
        Dim SQL1, SQL2 As String
        totsales = 0
        totAllsales = 0
        CatValName = CatValDesc(CatVal)
        TextBox1.Text = Cat & " - " & CatValName

        SQL1 = "SELECT convert(varchar(7),transaction_date,102) as periode, item_master.dp2, item_master.brand, " & vbCrLf & _
               "Sales_Transaction_Details.Flag_Paket_Discount, spg.spg_name, " & vbCrLf & _
               "SUM(Sales_Transaction_Details.Net_Price) AS sales " & vbCrLf & _
               "FROM Sales_Transaction_Details " & vbCrLf & _
               "INNER JOIN Sales_Transactions ON " & vbCrLf & _
               "    Sales_Transaction_Details.Transaction_Number = Sales_Transactions.Transaction_Number " & vbCrLf & _
               "INNER JOIN item_master on Sales_transaction_details.plu=item_master.plu " & vbCrLf & _
               "INNER JOIN pos_server.dbo.spg on spg.spg_id=Sales_Transaction_Details.Flag_Paket_Discount " & vbCrLf & _
               "WHERE(Sales_Transaction_Details.Net_Price <> 0) " & vbCrLf & _
               "AND (Sales_Transactions.Status='00') " & vbCrLf & _
               "AND Sales_Transaction_Details.Flag_Paket_Discount in " & vbCrLf & _
               "(SELECT spg_id from pos_server.dbo.SPG_DTL WHERE spg_id='" & SPG_ID & "' and (BRAND = 'sas')) " & vbCrLf & _
               "And item_master.dp2='" & CatVal & "' " & vbCrLf & _
               "GROUP BY convert(varchar(7),transaction_date,102), item_master.dp2, item_master.brand, " & vbCrLf & _
               "  Sales_Transaction_Details.Flag_Paket_Discount, spg.spg_name " & vbCrLf & _
               "Having convert(varchar(7),transaction_date,102)='" & ComboBox1.Text & "' " & vbCrLf & _
               "order by item_master.dp2,item_master.brand "

        SQL2 = "SELECT convert(varchar(7), transaction_date,102) as periode, item_master.dp2, item_master.brand, " & vbCrLf & _
               "Sales_Transaction_Details.Flag_Paket_Discount, spg.spg_name, " & vbCrLf & _
               "SUM(Sales_Transaction_Details.Net_Price) AS sales " & vbCrLf & _
               "FROM Sales_Transaction_Details " & vbCrLf & _
               "INNER JOIN Sales_Transactions ON " & vbCrLf & _
               "    Sales_Transaction_Details.Transaction_Number = Sales_Transactions.Transaction_Number " & vbCrLf & _
               "INNER JOIN item_master on Sales_transaction_details.plu=item_master.plu " & vbCrLf & _
               "INNER JOIN pos_server.dbo.spg on spg.spg_id=Sales_Transaction_Details.Flag_Paket_Discount " & vbCrLf & _
               "WHERE(Sales_Transaction_Details.Net_Price <> 0) " & vbCrLf & _
               "AND (Sales_Transactions.Status = '00') " & vbCrLf & _
               "AND Sales_Transaction_Details.Flag_Paket_Discount in " & vbCrLf & _
               "(SELECT spg_id from pos_server.dbo.SPG_DTL WHERE spg_id= '" & SPG_ID & "' and (BRAND = 'sas')) " & vbCrLf & _
               "And item_master.dp2<>'" & CatVal & "' " & vbCrLf & _
               "GROUP BY convert(varchar(7),transaction_date,102), item_master.dp2, item_master.brand, " & vbCrLf & _
               "  Sales_Transaction_Details.Flag_Paket_Discount, spg.spg_name " & vbCrLf & _
               "Having convert(varchar(7),transaction_date,102)='" & ComboBox1.Text & "' " & vbCrLf & _
               "order by item_master.dp2,item_master.brand "

        Select Case Cat
            Case "SBU"
                SQL1 = "SELECT convert(varchar(7),transaction_date,102) as periode, item_master.dp2, item_master.brand, " & vbCrLf & _
                       "Sales_Transaction_Details.Flag_Paket_Discount, spg.spg_name, " & vbCrLf & _
                       "SUM(Sales_Transaction_Details.Net_Price) AS sales " & vbCrLf & _
                       "FROM Sales_Transaction_Details " & vbCrLf & _
                       "INNER JOIN Sales_Transactions ON " & vbCrLf & _
                       "    Sales_Transaction_Details.Transaction_Number = Sales_Transactions.Transaction_Number " & vbCrLf & _
                       "INNER JOIN item_master on Sales_transaction_details.plu=item_master.plu " & vbCrLf & _
                       "INNER JOIN pos_server.dbo.spg on spg.spg_id=Sales_Transaction_Details.Flag_Paket_Discount " & vbCrLf & _
                       "WHERE(Sales_Transaction_Details.Net_Price <> 0) " & vbCrLf & _
                       "AND (Sales_Transactions.Status='00') " & vbCrLf & _
                       "AND Sales_Transaction_Details.Flag_Paket_Discount in " & vbCrLf & _
                       "(SELECT spg_id from pos_server.dbo.SPG_DTL WHERE spg_id='" & SPG_ID & "' and (BRAND = 'sas')) " & vbCrLf & _
                       "And item_master.dp2='" & CatVal & "' " & vbCrLf & _
                       "GROUP BY convert(varchar(7),transaction_date,102), item_master.dp2, item_master.brand, " & vbCrLf & _
                       "  Sales_Transaction_Details.Flag_Paket_Discount, spg.spg_name " & vbCrLf & _
                       "Having convert(varchar(7),transaction_date,102)='" & ComboBox1.Text & "' " & vbCrLf & _
                       "order by item_master.dp2,item_master.brand "

                SQL2 = "SELECT convert(varchar(7), transaction_date,102) as periode, item_master.dp2, item_master.brand, " & vbCrLf & _
                       "Sales_Transaction_Details.Flag_Paket_Discount, spg.spg_name, " & vbCrLf & _
                       "SUM(Sales_Transaction_Details.Net_Price) AS sales " & vbCrLf & _
                       "FROM Sales_Transaction_Details " & vbCrLf & _
                       "INNER JOIN Sales_Transactions ON " & vbCrLf & _
                       "    Sales_Transaction_Details.Transaction_Number = Sales_Transactions.Transaction_Number " & vbCrLf & _
                       "INNER JOIN item_master on Sales_transaction_details.plu=item_master.plu " & vbCrLf & _
                       "INNER JOIN pos_server.dbo.spg on spg.spg_id=Sales_Transaction_Details.Flag_Paket_Discount " & vbCrLf & _
                       "WHERE(Sales_Transaction_Details.Net_Price <> 0) " & vbCrLf & _
                       "AND (Sales_Transactions.Status = '00') " & vbCrLf & _
                       "AND Sales_Transaction_Details.Flag_Paket_Discount in " & vbCrLf & _
                       "(SELECT spg_id from pos_server.dbo.SPG_DTL WHERE spg_id= '" & SPG_ID & "' and (BRAND = 'sas')) " & vbCrLf & _
                       "And item_master.dp2<>'" & CatVal & "' " & vbCrLf & _
                       "GROUP BY convert(varchar(7),transaction_date,102), item_master.dp2, item_master.brand, " & vbCrLf & _
                       "  Sales_Transaction_Details.Flag_Paket_Discount, spg.spg_name " & vbCrLf & _
                       "Having convert(varchar(7),transaction_date,102)='" & ComboBox1.Text & "' " & vbCrLf & _
                       "order by item_master.dp2,item_master.brand "
            Case "BRAND"
                SQL1 = "SELECT convert(varchar(7),transaction_date,102) as periode, item_master.dp2, item_master.brand, " & vbCrLf & _
                       "Sales_Transaction_Details.Flag_Paket_Discount, spg.spg_name, " & vbCrLf & _
                       "SUM(Sales_Transaction_Details.Net_Price) AS sales " & vbCrLf & _
                       "FROM Sales_Transaction_Details " & vbCrLf & _
                       "INNER Join Sales_Transactions ON " & vbCrLf & _
                       "    Sales_Transaction_Details.Transaction_Number = Sales_Transactions.Transaction_Number " & vbCrLf & _
                       "INNER JOIN item_master on Sales_transaction_details.plu=item_master.plu " & vbCrLf & _
                       "INNER JOIN pos_server.dbo.spg on spg.spg_id=Sales_Transaction_Details.Flag_Paket_Discount " & vbCrLf & _
                       "WHERE(Sales_Transaction_Details.Net_Price <> 0) " & vbCrLf & _
                       "AND (Sales_Transactions.Status = '00') " & vbCrLf & _
                       "AND Sales_Transaction_Details.Flag_Paket_Discount in " & vbCrLf & _
                       "    (SELECT spg_id from pos_server.dbo.SPG_DTL WHERE spg_id= '" & SPG_ID & "') " & vbCrLf & _
                       "And item_master.brand= '" & CatVal & "' " & vbCrLf & _
                       "GROUP BY convert(varchar(7),transaction_date,102), item_master.dp2, item_master.brand, " & vbCrLf & _
                       "  Sales_Transaction_Details.Flag_Paket_Discount, spg.spg_name " & vbCrLf & _
                       "Having convert(varchar(7),transaction_date,102)='" & ComboBox1.Text & "' " & vbCrLf & _
                       "order by item_master.dp2,item_master.brand "

                SQL2 = "SELECT convert(varchar(7), transaction_date,102) as periode, item_master.dp2, item_master.brand, " & vbCrLf & _
                       "Sales_Transaction_Details.Flag_Paket_Discount, spg.spg_name, " & vbCrLf & _
                       "SUM(Sales_Transaction_Details.Net_Price) AS sales " & vbCrLf & _
                       "FROM Sales_Transaction_Details " & vbCrLf & _
                       "INNER JOIN Sales_Transactions ON " & vbCrLf & _
                       "    Sales_Transaction_Details.Transaction_Number = Sales_Transactions.Transaction_Number " & vbCrLf & _
                       "INNER JOIN item_master on Sales_transaction_details.plu=item_master.plu " & vbCrLf & _
                       "INNER JOIN pos_server.dbo.spg on spg.spg_id=Sales_Transaction_Details.Flag_Paket_Discount " & vbCrLf & _
                       "WHERE(Sales_Transaction_Details.Net_Price <> 0) " & vbCrLf & _
                       "AND (Sales_Transactions.Status = '00') " & vbCrLf & _
                       "AND Sales_Transaction_Details.Flag_Paket_Discount in " & vbCrLf & _
                       "(SELECT spg_id from pos_server.dbo.SPG_DTL WHERE spg_id= '" & SPG_ID & "') " & vbCrLf & _
                       "And item_master.brand<>'" & CatVal & "' " & vbCrLf & _
                       "GROUP BY convert(varchar(7),transaction_date,102), item_master.dp2, item_master.brand, " & vbCrLf & _
                       "  Sales_Transaction_Details.Flag_Paket_Discount, spg.spg_name " & vbCrLf & _
                      "Having convert(varchar(7), transaction_date,102)='" & ComboBox1.Text & "' " & vbCrLf & _
                      "order by item_master.dp2,item_master.brand "
            Case "TOYS"
                SQL1 = "SELECT convert(varchar(7), transaction_date,102) as periode, item_master.dp2, item_master.brand, " & vbCrLf & _
                       "Sales_Transaction_Details.Flag_Paket_Discount, spg.spg_name, " & vbCrLf & _
                       "SUM(Sales_Transaction_Details.Net_Price) AS sales " & vbCrLf & _
                       "FROM Sales_Transaction_Details " & vbCrLf & _
                       "INNER JOIN Sales_Transactions ON " & vbCrLf & _
                       "    Sales_Transaction_Details.Transaction_Number = Sales_Transactions.Transaction_Number " & vbCrLf & _
                       "INNER JOIN item_master on Sales_transaction_details.plu=item_master.plu " & vbCrLf & _
                       "INNER JOIN pos_server.dbo.spg on spg.spg_id=Sales_Transaction_Details.Flag_Paket_Discount " & vbCrLf & _
                       "WHERE( Sales_Transaction_Details.Net_Price <> 0) " & vbCrLf & _
                       "AND (Sales_Transactions.Status = '00') " & vbCrLf & _
                       "AND Sales_Transaction_Details.Flag_Paket_Discount in " & vbCrLf & _
                       "(SELECT spg_id from pos_server.dbo.SPG_DTL WHERE spg_id= '" & SPG_ID & "') " & vbCrLf & _
                       "and left(burui,3)='CTO' " & vbCrLf & _
                       "GROUP BY convert(varchar(7),transaction_date,102), item_master.dp2, item_master.brand, " & vbCrLf & _
                       "  Sales_Transaction_Details.Flag_Paket_Discount, spg.spg_name " & vbCrLf & _
                       "Having convert(varchar(7),transaction_date,102)='" & ComboBox1.Text & "' " & vbCrLf & _
                      "order by item_master.dp2,item_master.brand "

                SQL2 = "SELECT convert(varchar(7), transaction_date,102) as periode, item_master.dp2, item_master.brand, " & vbCrLf & _
                       "Sales_Transaction_Details.Flag_Paket_Discount, spg.spg_name, " & vbCrLf & _
                       "SUM(Sales_Transaction_Details.Net_Price) AS sales " & vbCrLf & _
                       "FROM Sales_Transaction_Details " & vbCrLf & _
                       "INNER JOIN Sales_Transactions ON " & vbCrLf & _
                       "    Sales_Transaction_Details.Transaction_Number = Sales_Transactions.Transaction_Number " & vbCrLf & _
                       "INNER JOIN item_master on Sales_transaction_details.plu=item_master.plu " & vbCrLf & _
                       "INNER JOIN pos_server.dbo.spg on spg.spg_id=Sales_Transaction_Details.Flag_Paket_Discount " & vbCrLf & _
                       "WHERE (Sales_Transaction_Details.Net_Price <> 0) " & vbCrLf & _
                       "AND (Sales_Transactions.Status = '00') " & vbCrLf & _
                       "AND Sales_Transaction_Details.Flag_Paket_Discount in " & vbCrLf & _
                       "(SELECT spg_id from pos_server.dbo.SPG_DTL WHERE spg_id= '" & SPG_ID & "') " & vbCrLf & _
                       "and left(burui,3)<>'CTO' " & vbCrLf & _
                       "GROUP BY convert(varchar(7),transaction_date,102), item_master.dp2, item_master.brand, " & vbCrLf & _
                       "Sales_Transaction_Details.Flag_Paket_Discount, spg.spg_name " & vbCrLf & _
                       "Having convert(varchar(7),transaction_date,102)='" & ComboBox1.Text & "' " & vbCrLf & _
                       "order by item_master.dp2,item_master.brand "
        End Select

        ListView1.Items.Clear()
        Dim vq1 As New VQuery
        vq1.Query(SQL1, "periode,brand", DB_POSH)
        If vq1.RecordCount <= 0 Then
            vq1.Dispose()
            Exit Sub
        End If

        If vq1.RecordCount > 0 Then
            'judul own brand
            Dim str0(5) As String : Dim itm0 As ListViewItem : str0(0) = "Own Brand" : itm0 = New ListViewItem(str0)
            itm0.Font = New System.Drawing.Font("Tahoma", 11.25, System.Drawing.FontStyle.Bold) : ListView1.Items.Add(itm0)

            Dim str(5) As String
            Dim itm As ListViewItem
            Prg = 0

            vq1.FirstRecord()
            While Not vq1.EOF
                Prg += 100 / vq1.RecordCount
                str(0) = vq1.GetField("periode")
                str(1) = vq1.GetField("dp2")
                str(2) = vq1.GetField("brand")
                str(3) = CDec(vq1.GetField("sales")).ToString("N0")
                totsales += CDbl(vq1.GetField("sales"))
                itm = New ListViewItem(str)
                ListView1.Items.Add(itm)
                BackgroundWorker1.ReportProgress(Int(Prg))

                vq1.NextRecord()
            End While

            'garis own brand
            Dim str2(5) As String : Dim itm2 As ListViewItem
            str2(0) = "========" : str2(1) = "===" : str2(2) = "=====================" : str2(3) = "======="
            itm2 = New ListViewItem(str2) : ListView1.Items.Add(itm2)

            'total own brand
            Dim str3(5) As String
            Dim itm3 As ListViewItem
            str3(0) = "Total Own"
            str3(3) = CDec(totsales).ToString("N0")
            itm3 = New ListViewItem(str3)
            itm3.Font = New System.Drawing.Font("Tahoma", 11.25, System.Drawing.FontStyle.Bold)
            ListView1.Items.Add(itm3)

            'baris kosong
            Dim str4(5) As String : Dim itm4 As ListViewItem : str2(0) = "" : itm4 = New ListViewItem(str4) : ListView1.Items.Add(itm4)
        End If

        totAllsales = totsales
        totsales = 0
        Dim vq2 As New VQuery
        vq2.Query(SQL2, "periode,brand", DB_POSH)
        If vq2.RecordCount > 0 Then
            'judul cross brand
            Dim str0(5) As String : Dim itm0 As ListViewItem : str0(0) = "Cross Brand" : itm0 = New ListViewItem(str0)
            itm0.Font = New System.Drawing.Font("Tahoma", 11.25, System.Drawing.FontStyle.Bold) : ListView1.Items.Add(itm0)

            Dim str(5) As String
            Dim itm As ListViewItem
            Prg = 0
            vq2.FirstRecord()
            While Not vq2.EOF
                Prg += 100 / vq2.RecordCount
                str(0) = vq2.GetField("periode")
                str(1) = vq2.GetField("dp2")
                str(2) = vq2.GetField("brand")
                str(3) = CDec(vq2.GetField("sales")).ToString("N0")
                totsales += vq2.GetField("sales")
                itm = New ListViewItem(str)
                ListView1.Items.Add(itm)
                BackgroundWorker1.ReportProgress(Int(Prg))

                vq2.NextRecord()
            End While

            'garis cross brand
            Dim str2(5) As String : Dim itm2 As ListViewItem
            str2(0) = "========" : str2(1) = "===" : str2(2) = "=====================" : str2(3) = "======="
            itm2 = New ListViewItem(str2) : ListView1.Items.Add(itm2)

            'total own brand
            Dim str3(5) As String : Dim itm3 As ListViewItem
            str3(0) = "Total Cross" : str3(3) = CDec(totsales).ToString("N0") : itm3 = New ListViewItem(str3)
            itm3.Font = New System.Drawing.Font("Tahoma", 11.25, System.Drawing.FontStyle.Bold) : ListView1.Items.Add(itm3)
        End If

        totAllsales += totsales

        'garis grandtotal
        Dim str6(5) As String : Dim itm6 As ListViewItem
        str6(0) = "========" : str6(1) = "===" : str6(2) = "=====================" : str6(3) = "======="
        itm6 = New ListViewItem(str6) : ListView1.Items.Add(itm6)

        'grandtotal
        Dim str5(5) As String : Dim itm5 As ListViewItem
        str5(0) = "Grand Total " : str5(3) = CDec(totAllsales).ToString("N0")
        itm5 = New ListViewItem(str5) : itm5.Font = New System.Drawing.Font("Tahoma", 11.25, System.Drawing.FontStyle.Bold)
        ListView1.Items.Add(itm5)

        vq1.Dispose()
        vq2.Dispose()
    End Sub
    Function CatValDesc(ByVal CatVal As String)
        Dim hasil As String
        Select Case CatVal
            Case "LD" : hasil = "Ladies 2"
            Case "LA" : hasil = "Ladies 1"
            Case "MD" : hasil = "Mens"
            Case "CH" : hasil = "Children"
            Case "HH" : hasil = "Home"
            Case "SC" : hasil = "Support Center"
            Case "Toys" : hasil = "Toys"
            Case Else : hasil = CatVal
        End Select
        Return hasil
    End Function
    

    
End Class