Public Class CheckAbsensiSPGFORM
    'Dim ds, ds2, ds3 As New DataSet
    'Dim totsales, totAllsales As Decimal
    'Dim CatValName, CatStr, CatValStr As String

    'Declare Function GetScrollInfo Lib "user32" Alias "GetScrollInfo" _
    '                (ByVal hWnd As IntPtr, ByVal n As Integer, ByRef lpScrollInfo As SCROLLINFO) As Integer
    'Declare Function SetScrollInfo Lib "user32" Alias "SetScrollInfo" _
    '                (ByVal hWnd As IntPtr, ByVal n As Integer, _
    'ByRef lpcScrollInfo As SCROLLINFO, ByVal bool As Boolean) As Integer
    'Structure SCROLLINFO
    '    Dim cbSize As Integer
    '    Dim fMask As Integer
    '    Dim nMin As Integer
    '    Dim nMax As Integer
    '    Dim nPage As Integer
    '    Dim nPos As Integer
    '    Dim nTrackPos As Integer
    'End Structure
    'Private Const SB_HORZ = 0
    'Private Const SB_VERT = 1
    'Private Const SIF_RANGE = &H1
    'Private Const SIF_PAGE = &H2
    'Private Const SIF_POS = &H4
    'Private Const SIF_ALL = (SIF_RANGE Or SIF_PAGE Or SIF_POS)
    'Dim si As SCROLLINFO
    'Private Structure LASTINPUTINFO
    '    Dim cbSize As Int32
    '    Dim dwTime As Int32
    'End Structure
    'Private Declare Function GetTickCount Lib "kernel32" () As Int32
    'Private Declare Function GetLastInputInfo Lib "user32" (ByRef plii As LASTINPUTINFO) As Boolean
    'Private Sub tim_Tick(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim lii As LASTINPUTINFO
    '    lii.cbSize = Len(lii)
    '    GetLastInputInfo(lii)
    '    If ((GetTickCount() - lii.dwTime) / 1000.0) > 60 Then
    '        'logOrMain = 1
    '        Me.Close()
    '    End If
    'End Sub

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
        CheckForIllegalCrossThreadCalls = False
        Timer1.Enabled = True
        DateTimePicker1.Value = Format(Now, "yyyy-MM-01")
        DateTimePicker2.Value = Now
        dg.Font = LblFont.Font
        Label3.Text = UsrID & " - " & UsrName
        dg.RowsDefaultCellStyle.BackColor = Color.White
        dg.AlternatingRowsDefaultCellStyle.BackColor = Color.Bisque
        Button3_Click(sender, e)
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Label9.Visible = True
        ProgressBar1.Value = 0
        ProgressBar1.Visible = True
        Button3.Enabled = False
        GroupBox1.Enabled = False

        TampilAbsen2()

        Button3.Enabled = True
        GroupBox1.Enabled = True
        ProgressBar1.Visible = False
        Label9.Visible = False

        'dg.ScrollBars = ScrollBars.None
        'BackgroundWorker1.WorkerReportsProgress = True
        'BackgroundWorker1.WorkerSupportsCancellation = True
        'BackgroundWorker1.RunWorkerAsync()
    End Sub
    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        TampilAbsen()
        'TampilAbsen2()
    End Sub
    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Button3.Enabled = True
        GroupBox1.Enabled = True
        ProgressBar1.Visible = False
        Label9.Visible = False
        dg.ScrollBars = ScrollBars.Both
    End Sub
    Sub TampilAbsen()
        Dim vq As New VQuery
        Dim Prg As Decimal = 0
        vq.Query("SELECT a.spg_id, a.spg_barcode, k.spg_name, a.tanggal, " & vbCrLf & _
                 "SUBSTRING(r.jam_masuk, 1,2)+':'+SUBSTRING(r.jam_masuk, 3,2) as masuk_roster, " & vbCrLf & _
                 "SUBSTRING(r.jam_pulang , 1,2)+':'+SUBSTRING(r.jam_pulang , 3,2) as pulang_roster, " & vbCrLf & _
                 "SUBSTRING(a.jam_masuk, 1,2)+':'+SUBSTRING(a.jam_masuk, 3,2) as jam_masuk, " & vbCrLf & _
                 "SUBSTRING(a.jam_pulang , 1,2)+':'+SUBSTRING(a.jam_pulang, 3,2) as jam_pulang, " & vbCrLf & _
                 "s.keterangan as status, a.keterangan, " & vbCrLf & _
                 "SUBSTRING(a.jam2, 1,2)+':'+SUBSTRING(a.jam2, 3,2) as masuk_lembur, " & vbCrLf & _
                 "SUBSTRING(a.jam3 , 1,2)+':'+SUBSTRING(a.jam3, 3,2) as pulang_lembur " & vbCrLf & _
                 "FROM TRN_ABSEN a " & vbCrLf & _
                 "LEFT JOIN TBL_KARYAWAN k on a.spg_id=k.spg_id " & vbCrLf & _
                 "LEFT JOIN TBL_STATUS s on a.status=s.status " & vbCrLf & _
                 "LEFT JOIN TRN_ROSTER r on a.spg_id=r.spg_id and a.tanggal=r.tanggal " & vbCrLf & _
                 "where a.spg_id='" & UsrID & "' and " & vbCrLf & _
                 "convert(varchar(10), a.tanggal, 20) between '" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' " & _
                 "and '" & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "' " & vbCrLf & _
                 "order by a.spg_barcode, a.tanggal", "spg_id,tanggal", DB_ABS)
        vq.FirstRecord()
        If dg.RowCount > 0 Then dg.Rows.Clear()
        While Not vq.EOF
            Prg += 100 / vq.RecordCount
            BackgroundWorker1.ReportProgress(Int(Prg))
            dg.Rows.Add(vq.GetField("spg_barcode"), vq.GetField("spg_name"), Format(Date.Parse(vq.GetField("tanggal")), "dd MMM yyyy"), _
                        vq.GetField("masuk_roster"), vq.GetField("pulang_roster"), vq.GetField("jam_masuk"), vq.GetField("jam_pulang"), _
                        vq.GetField("status"), vq.GetField("keterangan"), vq.GetField("masuk_lembur"), vq.GetField("pulang_lembur"))
            vq.NextRecord()
        End While
        vq.Dispose()
    End Sub
    Sub TampilAbsen2()

        Dim dsa As New DataSet
        Dim SQL As String
        SQL = "SELECT a.spg_id, a.spg_barcode, k.spg_name, a.tanggal, " & vbCrLf & _
                 "SUBSTRING(r.jam_masuk, 1,2)+':'+SUBSTRING(r.jam_masuk, 3,2) as masuk_roster, " & vbCrLf & _
                 "SUBSTRING(r.jam_pulang , 1,2)+':'+SUBSTRING(r.jam_pulang , 3,2) as pulang_roster, " & vbCrLf & _
                 "SUBSTRING(a.jam_masuk, 1,2)+':'+SUBSTRING(a.jam_masuk, 3,2) as jam_masuk, " & vbCrLf & _
                 "SUBSTRING(a.jam_pulang , 1,2)+':'+SUBSTRING(a.jam_pulang, 3,2) as jam_pulang, " & vbCrLf & _
                 "s.keterangan as status, a.keterangan, " & vbCrLf & _
                 "SUBSTRING(a.jam2, 1,2)+':'+SUBSTRING(a.jam2, 3,2) as masuk_lembur, " & vbCrLf & _
                 "SUBSTRING(a.jam3 , 1,2)+':'+SUBSTRING(a.jam3, 3,2) as pulang_lembur " & vbCrLf & _
                 "FROM TRN_ABSEN a " & vbCrLf & _
                 "LEFT JOIN TBL_KARYAWAN k on a.spg_id=k.spg_id " & vbCrLf & _
                 "LEFT JOIN TBL_STATUS s on a.status=s.status " & vbCrLf & _
                 "LEFT JOIN TRN_ROSTER r on a.spg_id=r.spg_id and a.tanggal=r.tanggal " & vbCrLf & _
                 "where a.spg_id='" & UsrID & "' and " & vbCrLf & _
                 "convert(varchar(10), a.tanggal, 20) between '" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' " & _
                 "and '" & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "' " & vbCrLf & _
                 "order by a.spg_barcode, a.tanggal"
        dsa = QueryToDataset2(SQL, DB_ABS)
        dg.AutoGenerateColumns = False
        dg.DataSource = dsa.Tables(0)
        
    End Sub
    Private Sub dg_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg.CellContentClick

    End Sub
End Class