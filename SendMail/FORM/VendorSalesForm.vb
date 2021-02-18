'Option Explicit On
'Option Strict On
Imports System.Runtime.InteropServices.Marshal
Public Class VendorSalesForm
    Inherits System.Windows.Forms.Form
    Dim SAS As Boolean
    Dim queryPLU As String
    Dim tgl, brand, plu, Dept As String
    Dim totqty, totnet, totdisc, totgross, totqty2, totnet2, totdisc2, totgross2 As Decimal
    Dim ds, dscek As New DataSet
    Dim p_load As Boolean = False
    Dim param(1) As String
    Dim value(1) As String
    Dim si As New SCROLLINFO()


    Private Sub DateTimePicker1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker1.TextChanged
        If DateTimePicker1.Checked = True Then
            DateTimePicker2.Checked = True
        Else
            DateTimePicker2.Checked = False
        End If
    End Sub
    Private Sub DateTimePicker2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker2.TextChanged
        If DateTimePicker2.Checked = True Then
            DateTimePicker1.Checked = True
        Else
            DateTimePicker1.Checked = False
        End If
    End Sub
    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        If DateTimePicker1.Value > DateTimePicker2.Value Then
            DateTimePicker1.Value = DateTimePicker2.Value
        End If
    End Sub
    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        If DateTimePicker2.Value < DateTimePicker1.Value Then
            DateTimePicker2.Value = DateTimePicker1.Value
        End If
    End Sub
    Private Sub VendorSales_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub VendorSales_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        KiosInformasiFORM.Show()
        KiosInformasiFORM.GroupBox1.Focus()
        KiosInformasiFORM.TextBox1.Focus()
    End Sub
    Private Sub VendorSales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button3.Image = Image.FromFile(FolderImage & "go.ico")
        Dim ico As New System.Drawing.Icon(FolderImage & "star.ico") : Me.Icon = ico

        Dim vq As New VQuery
        SAS = False
        Label7.Text = UsrID & " - " & UsrName
        lv()
        'MsgOK("1")
        vq.Query("select DISTINCT Brand From SPG_Dtl Where spg_id = '" & UsrID & "' Order by Brand", _
                 "spg_id,brand", DB_POS)
        'Dbg(vq.SQL)
        'MsgOK("2")
        ComboBox1.Items.Clear()
        'If vq.RecordCount >= 2 Then ComboBox1.Items.Add("***ALL***")
        'MsgOK("3")
        ComboBox1.Items.Add("***ALL***")
        While Not vq.EOF
            'Dbg(vq.GetField("brand"))
            'MsgOK(vq.GetField("brand"))
            ComboBox1.Items.Add(vq.GetField("brand"))

            vq.NextRecord()
        End While
        'MsgOK("4")
        vq.Query("select brand from spg_dtl where spg_id='" & UsrID & "' and brand in ('SAS', 'CSR') ", _
                "spg_id,brand", DB_POS)
        If vq.RecordCount > 0 Then
            'MsgOK("5")
            SAS = True
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
        Else
            'MsgOK("6")
            SAS = False
            ComboBox1.Enabled = True
            ComboBox2.Enabled = True
        End If
        'MsgOK("7")
        vq.Query("select '***ALL***' as plu union select DISTINCT plu From Item_Master Where Brand in " & vbCrLf & _
                 "(select DISTINCT Brand From SPG_Dtl Where spg_id = '" & UsrID & "') Order by PLU", "plu", DB_POS)
        'Dbg(vq.SQL)
        'ComboBox2.Items.Clear()
        ComboBox2.DataSource = Nothing
        If SAS = False Then
            'MsgOK("sas false")
            'Dbg(vq.SQL)
            'MsgOK("8")
            If vq.RecordCount = 0 Then
                MsgError("Tidak ada list PLU untuk user_id " & UsrID & " !!!, Hub Administrator!!")
                GoTo 1
            End If
            'If vq.RecordCount >= 2 Then ComboBox2.Items.Add("***ALL***")
            'Dbg(vq.SQL)
            ComboBox2.DataSource = vq.Tables(0)
            ComboBox2.ValueMember = "plu"
            ComboBox2.DisplayMember = "plu"
            ComboBox2.SelectedValue = "***ALL***"
            'MsgOK("9")
        End If
        'MsgOK("1")
        ComboBox1.SelectedIndex = 0
        'MsgOK(ComboBox1.Text)
        If ComboBox2.Items.Count > 0 Then ComboBox2.SelectedIndex = 0
        'MsgOK("10")
1:
        DateTimePicker1.Value = Format(Now, "yyyy-MM-01")
        CheckForIllegalCrossThreadCalls = False
        'MsgOK("11")
        Dim tim As New Timer
        tim.Interval = 2000
        AddHandler tim.Tick, AddressOf tim_Tick
        tim.Start()
        'MsgOK("12")
        p_load = True
        DateTimePicker1.Checked = False
        DateTimePicker1.Checked = True
        CheckBox1.Checked = True
        Button3_Click(sender, e)
        'MsgOK("13")
    End Sub
    Sub lv()
        ListView1.Columns.Add("Date", 115, HorizontalAlignment.Left)
        ListView1.Columns.Add("EAN/PLU", 170, HorizontalAlignment.Left)
        ListView1.Columns.Add("Description", 290, HorizontalAlignment.Left)
        ListView1.Columns.Add("Qty", 60, HorizontalAlignment.Right)
        ListView1.Columns.Add("Price", 100, HorizontalAlignment.Right)
        ListView1.Columns.Add("Net Sales", 130, HorizontalAlignment.Right)
        ListView1.Columns.Add("Discount", 120, HorizontalAlignment.Right)
        ListView1.Columns.Add("Gross Sales", 130, HorizontalAlignment.Right)
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If p_load = True Then
            Dim vq As New VQuery
            Dim dsc As New DataSet

            If LCase(ComboBox1.Text) = "***all***" Then
                vq.Query("select '***ALL***' as plu union select DISTINCT plu From Item_Master Where Brand in " & vbCrLf & _
                         "(select DISTINCT Brand From SPG_Dtl Where spg_id = '" & UsrID & "') Order by PLU", "plu", DB_POS)
                ComboBox2.DataSource = vq.Tables(0)
                ComboBox2.ValueMember = "plu"
                ComboBox2.DisplayMember = "plu"
                ComboBox2.SelectedValue = "***ALL***"
            Else
                If SAS = False Then
                    vq.Query("select '***ALL***' as plu union select DISTINCT plu From Item_Master Where Brand in " & vbCrLf & _
                             "(select DISTINCT Brand From SPG_Dtl Where spg_id = '" & UsrID & "' And " & vbCrLf & _
                             "Brand = '" & ComboBox1.Text.Replace("'", "''") & "') Order by PLU", "plu", DB_POS)
                    ComboBox2.DataSource = vq.Tables(0)
                    ComboBox2.ValueMember = "plu"
                    ComboBox2.DisplayMember = "plu"
                    ComboBox2.SelectedValue = "***ALL***"
                End If
            End If
            If ComboBox2.Items.Count > 0 Then ComboBox2.SelectedIndex = 0
            'vq.Dispose()
        End If
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
        showLv()
    End Sub
    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        'ProgressBar1.Value = e.ProgressPercentage
        Button3.Enabled = True
        GroupBox1.Enabled = True
        ProgressBar1.Visible = False
        Label9.Visible = False
    End Sub

    Sub showLv()
        Dim vq As New VQuery
        Dim q As New VQuery

        Dim dsdept, dsbrand As New DataSet
        Dim deptstr As String = ""
        Dim Prg As Decimal
        Dim RBrand As String = ""
        totqty = 0
        totdisc = 0
        totgross = 0
        totnet = 0
        totqty2 = 0
        totdisc2 = 0
        totgross2 = 0
        totnet2 = 0
        If DateTimePicker1.Checked = True Then
            tgl = " and convert(varchar(10), transaction_date, 20) between " & dt2sql(DateTimePicker1.Value) & _
                  " and " & dt2sql(DateTimePicker2.Value) & " "
        Else
            tgl = ""
        End If

        If SAS = True Then
            vq.Query("select convert(varchar(10), a.transaction_date, 20) as transaction_date, " & vbCrLf & _
                     "b.plu, c.Long_Description, sum(b.qty) as QTY, " & vbCrLf & _
                     "b.price, sum(b.net_price) as [Net Price], sum(b.Discount_Amount) as discount, " & vbCrLf & _
                     "(sum(b.Net_Price)+sum(b.Discount_Amount)) as Gross " & vbCrLf & _
                     "from sales_transactions a " & vbCrLf & _
                     "inner join sales_transaction_details b on a.transaction_number=b.transaction_number " & vbCrLf & _
                     "left join item_master c on b.plu=c.plu " & vbCrLf & _
                     "where a.status='00' " & tgl & " and b.flag_paket_discount='" & UsrID & "' And  " & vbCrLf & _
                     "c.burui not in ('NMD90ZZZ9','NMD31ZZZ9','NMD92ZZZ9') " & vbCrLf & _
                     "group by a.transaction_date, b.plu, c.Long_Description, b.plu, b.price, b.flag_paket_discount " & vbCrLf & _
                     "order by a.transaction_date,b.PLU asc", "transaction_number", DB_POSH)
            GoTo v
        End If

        If LCase(ComboBox1.Text) = "***all***" Then
            q.Query("select DISTINCT Brand From SPG_Dtl Where spg_id='" & UsrID & "'", "spg_id,brand", DB_POS)
            If q.RecordCount > 0 Then
                While Not q.EOF
                    If RBrand.ToString.ToString.Length > 0 Then
                        RBrand += ","
                    End If
                    RBrand += "'" & ReplacePetik(q.GetField("Brand")) & "'"
                    q.NextRecord()
                End While
                brand = " and c.brand in (" & RBrand & ") "
            Else
                brand = ""
            End If
        Else
            RBrand = ReplacePetik(ComboBox1.Text)
            brand = " and c.brand in ('" & RBrand & "') "
        End If

        If LCase(ComboBox1.Text) = "***all***" Then
            q.Query("select DISTINCT Class From SPG_Dtl Where spg_id='" & UsrID & "' ", "spg_id,brand", DB_POS)
        Else
            q.Query("select DISTINCT Class From SPG_Dtl Where spg_id='" & UsrID & "' " & _
                    "And Brand='" & ReplacePetik(ComboBox1.Text) & "'", "spg_id,brand", DB_POS)
        End If

        If q.RecordCount > 0 Then
            While Not q.EOF
                If deptstr.ToString.ToString.Length > 0 Then
                    deptstr += ","
                End If
                deptstr += "'" & q.GetField("Class") & "'"
                q.NextRecord()
            End While
            Dept = " and c.class in (" & deptstr & ") "
        Else
            deptstr = ""
            Dept = ""
        End If

        plu = ""
        If LCase(ComboBox2.Text) <> "***all***" Then plu = " and b.plu in ('" & ComboBox2.Text & "') "
        'If ComboBox2.SelectedValue <> "*" Then plu = " and b.plu in ('" & ComboBox2.SelectedValue & "') "
        If ComboBox2.Items.Count = 0 Then plu = ""

        If CheckBox1.Checked = True Then
            vq.Query("select convert(varchar(10), a.transaction_date, 20) as transaction_date, " & vbCrLf & _
                     "b.plu, c.Long_Description, sum(b.qty) as QTY, b.price, " & vbCrLf & _
                     "sum(b.net_price) as [Net Price], sum(b.Discount_Amount) as discount, " & vbCrLf & _
                     "(sum(b.Net_Price)+ sum(b.Discount_Amount)) as Gross " & vbCrLf & _
                     "from sales_transactions a join sales_transaction_details b on a.transaction_number=b.transaction_number " & vbCrLf & _
                     "left join item_master c on b.plu=c.plu " & vbCrLf & _
                     "where a.status='00' " & vbCrLf & _
                     tgl & _
                     brand & _
                     Dept & _
                     plu & _
                     " And c.dp2 in ('" & SbuCode & "') And  c.burui not in ('NMD90ZZZ9','NMD31ZZZ9','NMD92ZZZ9') " & vbCrLf & _
                     "group by a.transaction_date,b.plu,c.Long_Description ,b.plu,b.price " & vbCrLf & _
                     "order by a.transaction_date,b.PLU asc", "transaction_number", DB_POSH)
        Else
            vq.Query("select convert(varchar(10), a.transaction_date, 20) as transaction_date, " & vbCrLf & _
                     "b.plu, c.Long_Description, sum(b.qty) as QTY, b.price, " & vbCrLf & _
                     "sum(b.net_price) as [Net Price], sum(b.Discount_Amount) as discount, " & vbCrLf & _
                     "(sum(b.Net_Price)+sum(b.Discount_Amount)) as Gross " & vbCrLf & _
                     "from sales_transactions a join sales_transaction_details b on a.transaction_number=b.transaction_number " & vbCrLf & _
                     "left join item_master c on b.plu=c.plu " & vbCrLf & _
                     "where a.status='00' " & vbCrLf & _
                     tgl & _
                     brand & _
                     Dept & _
                     plu & _
                     " And b.flag_paket_discount = '" & UsrID & "' And c.dp2 in ('" & SbuCode & "') And  " & vbCrLf & _
                     "c.burui not in ('NMD90ZZZ9','NMD31ZZZ9','NMD92ZZZ9') " & vbCrLf & _
                     " group by a.transaction_date,b.plu,c.Long_Description ,b.plu,b.price,b.flag_paket_discount " & vbCrLf & _
                     "order by a.transaction_date,b.PLU asc", "transaction_number", DB_POSH)
        End If
v:
        ListView1.Items.Clear()
        Dim day As Integer = 0
        Dim mth As Integer = 0
        Dbg(vq.SQL.Trim)
        If vq.RecordCount > 0 Then
            While Not vq.EOF
                Prg += 100 / vq.RecordCount
                If day <> CInt(Format(Date.Parse(vq.GetField("transaction_date")), "dd")) Then
                    If day <> 0 Then
                        Dim stra(7) As String
                        Dim itma As ListViewItem
                        stra(0) = "========"
                        stra(1) = "==========="
                        stra(2) = "====================="
                        stra(3) = "=="
                        stra(4) = "======="
                        stra(5) = "======="
                        stra(6) = "======="
                        stra(7) = "======="
                        itma = New ListViewItem(stra)
                        ListView1.Items.Add(itma)

                        Dim strb(7) As String
                        Dim itmb As ListViewItem
                        strb(0) = "Per " & day & "-" & Format(Date.Parse(vq.GetField("transaction_date")), "MMM")
                        strb(3) = CDec(totqty2).ToString("N0")
                        strb(5) = CDec(totnet2).ToString("N0")
                        strb(6) = CDec(totdisc2).ToString("N0")
                        strb(7) = CDec(totgross2).ToString("N0")
                        itmb = New ListViewItem(strb)
                        itmb.Font = New System.Drawing.Font("Tahoma", 11.25, System.Drawing.FontStyle.Bold)
                        ListView1.Items.Add(itmb)

                        Dim strc(7) As String
                        Dim itmc As ListViewItem
                        strc(0) = ""
                        itmc = New ListViewItem(strc)
                        ListView1.Items.Add(itmc)
                        totqty2 = 0
                        totnet2 = 0
                        totgross2 = 0
                        totdisc2 = 0
                    End If
                End If

                '"select a.transaction_date, b.plu, c.Long_Description, sum(b.qty) as QTY, b.price, " & vbCrLf & _
                '     "sum(b.net_price) as [Net Price], sum(b.Discount_Amount) as discount, " & vbCrLf & _
                '     "(sum(b.Net_Price)+ sum(b.Discount_Amount)) as Gross " & vbCrLf & _

                Dim str(7) As String
                Dim itm As ListViewItem
                str(0) = Format(Date.Parse(vq.GetField("transaction_date")), "dd MMM yyyy")
                str(1) = vq.GetField("plu")
                str(2) = vq.GetField("long_description")
                str(3) = CDec(vq.GetField("qty")).ToString("N0")
                totqty += vq.GetField("qty")
                totqty2 += vq.GetField("qty")
                str(4) = CDec(vq.GetField("price")).ToString("N0")
                str(5) = CDec(vq.GetField("net price")).ToString("N0")
                totnet += vq.GetField("net price")
                totnet2 += vq.GetField("net price")
                str(6) = CDec(vq.GetField("discount")).ToString("N0")
                totdisc += vq.GetField("discount")
                totdisc2 += vq.GetField("discount")
                str(7) = CDec(vq.GetField("gross")).ToString("N0")
                totgross += vq.GetField("gross")
                totgross2 += vq.GetField("gross")
                itm = New ListViewItem(str)
                ListView1.Items.Add(itm)
                day = Date.Parse(vq.GetField("transaction_date")).Day
                mth = Date.Parse(vq.GetField("transaction_date")).Month
                BackgroundWorker1.ReportProgress(Int(Prg))

                vq.NextRecord()
            End While

            Dim strd(7) As String
            Dim itmd As ListViewItem
            strd(0) = "========"
            strd(1) = "==========="
            strd(2) = "====================="
            strd(3) = "=="
            strd(4) = "======="
            strd(5) = "======="
            strd(6) = "======="
            strd(7) = "======="
            itmd = New ListViewItem(strd)
            ListView1.Items.Add(itmd)

            Dim stre(7) As String
            Dim itme As ListViewItem
            stre(0) = "Per " & day & "-" & Format(Date.Parse(DateTimePicker2.Value.Year & "-" & mth & "-" & day), "MMM")
            'stre(0) = "Per " & day & "-" & Format(CDate(mth & "/" & day & "/" & DateTimePicker2.Value.Year), "MMM")
            stre(3) = CDec(totqty2).ToString("N0")
            stre(5) = CDec(totnet2).ToString("N0")
            stre(6) = CDec(totdisc2).ToString("N0")
            stre(7) = CDec(totgross2).ToString("N0")
            itme = New ListViewItem(stre)
            itme.Font = New System.Drawing.Font("Tahoma", 11.25, System.Drawing.FontStyle.Bold)
            ListView1.Items.Add(itme)

            'Total
            Dim stri(7) As String
            Dim itmi As ListViewItem
            stri(0) = "========"
            stri(1) = "==========="
            stri(2) = "====================="
            stri(3) = "=="
            stri(4) = "======="
            stri(5) = "======="
            stri(6) = "======="
            stri(7) = "======="
            itmi = New ListViewItem(stri)
            ListView1.Items.Add(itmi)

            Dim strt(7) As String
            Dim itmt As ListViewItem
            strt(0) = "Grand Total :"
            strt(3) = CDec(totqty).ToString("N0")
            strt(5) = CDec(totnet).ToString("N0")
            strt(6) = CDec(totdisc).ToString("N0")
            strt(7) = CDec(totgross).ToString("N0")
            itmt = New ListViewItem(strt)
            itmt.Font = New System.Drawing.Font("Tahoma", 11.25, System.Drawing.FontStyle.Bold)
            ListView1.Items.Add(itmt)
        Else
            Button3.Enabled = True
            GroupBox1.Enabled = True
            ProgressBar1.Visible = False
            MsgError("Data Tidak Ditemukan")
            BackgroundWorker1.CancelAsync()
        End If
    End Sub

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
    Declare Function GetScrollInfo Lib "user32" Alias "GetScrollInfo" _
    (ByVal hWnd As IntPtr, ByVal n As Integer, ByRef lpScrollInfo As SCROLLINFO) As Integer

    Declare Function SetScrollInfo Lib "user32" Alias "SetScrollInfo" _
    (ByVal hWnd As IntPtr, ByVal n As Integer, _
    ByRef lpcScrollInfo As SCROLLINFO, ByVal bool As Boolean) As Integer

    Public Structure SCROLLINFO
        Public cbSize As Integer
        Public fMask As Integer
        Public nMin As Integer
        Public nMax As Integer
        Public nPage As Integer
        Public nPos As Integer
        Public nTrackPos As Integer
    End Structure

    Private Const SB_HORZ As Integer = 0
    Private Const SB_VERT As Integer = 1

    Private Const SIF_RANGE As Integer = &H1
    Private Const SIF_PAGE As Integer = &H2
    Private Const SIF_POS As Integer = &H4
    Private Const SIF_TRACKPOS As Integer = &H10
    Private Const SIF_ALL As Integer = SIF_RANGE Or SIF_PAGE Or SIF_POS Or SIF_TRACKPOS


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        LblTGL.Text = UCase(Format(Now, "ddd, dd MMM yyyy"))
        LblJam.Text = Format(Now, "HH:mm:ss")
    End Sub
    Sub disableObject()
        Label9.Visible = True
        ProgressBar1.Value = 0
        ProgressBar1.Visible = True
        ListView1.Items.Clear()
        Button3.Enabled = False
        GroupBox1.Enabled = False
    End Sub
    Private Sub BW_PLU_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BW_PLU.DoWork
        addPLU()
    End Sub

    Private Sub BW_PLU_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BW_PLU.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub BW_PLU_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BW_PLU.RunWorkerCompleted
        Button3.Enabled = True
        GroupBox1.Enabled = True
        ProgressBar1.Visible = False
        Label9.Visible = False
    End Sub
    Sub addPLU()
        Dim vp As New VQuery
        Dim prg As Integer
        'MsgOK(strCon_Global)
        'Dbg(queryPLU)
        vp.Query(queryPLU, "plu", DB_POS)
        vp.FirstRecord()
        While Not vp.EOF
            prg = CInt((vp.RecNo * 100) / vp.RecordCount)
            BW_PLU.ReportProgress(Int(Prg))
            ComboBox2.Items.Add(vp.GetField("plu"))
            vp.NextRecord()
        End While

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub
End Class