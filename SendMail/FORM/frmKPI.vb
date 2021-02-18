Imports System.Data
Imports System.Data.OleDb

Public Class frmKPI
    Private flag_cell_edited As Boolean
    Private currentRow As Integer
    Private currentColumn, x1 As Integer
    Dim strCode As String
    Dim Process As Decimal
    Dim numberx As Integer
    Dim bs As New BindingSource
    Dim md1a, md1b, md1ax, Users As String
    Dim listzero As New List(Of Integer)
    Dim flshQ As Boolean = False
    Dim toFlashOrNot As Boolean = False
    Dim curBack As Color

    Private Sub frmKPI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckConnection2()
        ConnectServer()
        setDG()
        Bersih()
        Tglrev = Format(Now, "yyyy-MM-dd")
        ViewData()
        Label9.Text = ""
        lblKet.Text = ""
        CheckForIllegalCrossThreadCalls = False
    End Sub


#Region "Umum"
    Private Sub setDG()
        With DG
            .Columns.Clear()
            .Columns.Add("No", "No")
            .Columns(0).Width = 50
            .Columns(0).ReadOnly = True
            .Columns.Add("SBU", "SBU")
            .Columns(1).Width = 50
            .Columns.Add("Dept", "Dept")
            .Columns(2).Width = 50
            .Columns.Add("Brand", "Brand")
            .Columns(3).Width = 50
            .Columns.Add("SQM", "SQM")
            .Columns(4).Width = 50 : .Columns(4).DefaultCellStyle.Format = "#,##0.##0"
            .Columns.Add("SQM GROSS", "SQM GROSS")
            .Columns(5).Width = 50 : .Columns(5).DefaultCellStyle.Format = "#,##0.##0"
            .Columns(5).ReadOnly = True
            .Columns.Add("Floor", "Floor")
            .Columns(6).Width = 50 : .Columns(6).DefaultCellStyle.Format = "#,##0"
            .Columns.Add("Code", "Code")
            .Columns(7).Width = 50
            .Columns(7).Visible = False
        End With
        txtNoRev.ReadOnly = True
    End Sub

    Private Sub no_rev()
        strSQL = " SELECT  isnull(max(Code)+1,1) as code,max(convert(int,[U_RevNo]))+1  as no FROM [@ST_KPIH]"
        cmd = New OleDbCommand(strSQL, CServer)
        DRNRh = cmd.ExecuteReader
        If DRNRh.Read Then
            txtNoRev.Text = DRNRh("no")
            strCode = DRNRh("CODE")
        End If
        DRNRh.Close()
    End Sub

    Private Sub Bersih()
        txtNoRev.Text = "" : txtSite.Text = "" : txtKet.Text = "" : lblKet.Text = ""
        DG.Rows.Clear()
    End Sub

    Private Sub ViewData()
        ds = New DataSet
        strSQL = "select Code, Name, U_RevNo, U_RevName, U_RevDate, U_Store, U_CreateBy, U_CreateDate  AS u_createdate  from  [@ST_KPIH] order by convert(int,U_RevNo)"
        da = New OleDbDataAdapter(strSQL, CServer)
        da.Fill(ds, "kpih")
    End Sub

    Private Sub ListRecord()
        txtNoRev.Text = ds.Tables("kpih").Rows(PosisiRecord)("U_revno").ToString
        DT.Value = ds.Tables("kpih").Rows(PosisiRecord)("u_createdate")
        txtSite.Text = ds.Tables("kpih").Rows(PosisiRecord)("u_store").ToString
        txtKet.Text = ds.Tables("kpih").Rows(PosisiRecord)("u_revname").ToString
        txtNoRev.ReadOnly = True
    End Sub


    Private Sub FindGrid(ByVal No As String)

        Users = UsrID
            If Users = "ika" Then
                md1a = "LA"
                strSQL = "select Code,Name,U_RevNo,U_LineNo,U_SBU,U_Dep,U_Brn,U_Sqm as sql,U_Sqmgross as sql2,u_floor from [@st_kpid] where U_RevNo ='" & No & "' and U_SBU in ('" & md1a & "') "
                cmd = New OleDbCommand(strSQL, CServer)
                DRKPI = cmd.ExecuteReader
                DG.Rows.Clear()
                Do While DRKPI.Read
                    DG.Rows.Add(DRKPI("U_LineNo").ToString, DRKPI("U_SBU").ToString, DRKPI("U_Dep").ToString, DRKPI("U_Brn").ToString, DRKPI("sql").ToString, DRKPI("sql2").ToString, DRKPI("u_floor").ToString, DRKPI("Code").ToString)
                Loop
                DG.AllowUserToAddRows = False
                DRKPI.Close()
                btnSave.Text = "OK"

            ElseIf Users = "rositah" Then
                md1a = "MD"
                md1ax = "LD"
                strSQL = "select Code,Name,U_RevNo,U_LineNo,U_SBU,U_Dep,U_Brn,U_Sqm as sql,U_Sqmgross as sql2,u_floor from [@st_kpid] where U_RevNo ='" & No & "' and U_SBU in ('" & md1a & "','" & md1ax & "') "
                cmd = New OleDbCommand(strSQL, CServer)
                DRKPI = cmd.ExecuteReader
                DG.Rows.Clear()
                Do While DRKPI.Read
                    DG.Rows.Add(DRKPI("U_LineNo").ToString, DRKPI("U_SBU").ToString, DRKPI("U_Dep").ToString, DRKPI("U_Brn").ToString, DRKPI("sql").ToString, DRKPI("sql2").ToString, DRKPI("u_floor").ToString, DRKPI("Code").ToString)
                Loop
                DG.AllowUserToAddRows = False
                DRKPI.Close()
                btnSave.Text = "OK"


            ElseIf Users = "adit" Then
                md1a = "CH"
                md1b = "HH"
                strSQL = "select Code,Name,U_RevNo,U_LineNo,U_SBU,U_Dep,U_Brn,U_Sqm as sql,U_Sqmgross as sql2,u_floor from [@st_kpid] where U_RevNo ='" & No & "' and U_SBU in ('" & md1a & "','" & md1b & "') "
                cmd = New OleDbCommand(strSQL, CServer)
                DRKPI = cmd.ExecuteReader
                DG.Rows.Clear()
                Do While DRKPI.Read
                    DG.Rows.Add(DRKPI("U_LineNo").ToString, DRKPI("U_SBU").ToString, DRKPI("U_Dep").ToString, DRKPI("U_Brn").ToString, DRKPI("sql").ToString, DRKPI("sql2").ToString, DRKPI("u_floor").ToString, DRKPI("Code").ToString)
                Loop
                DG.AllowUserToAddRows = False
                DRKPI.Close()
                btnSave.Text = "OK"

            ElseIf (Users <> "adit") And (Users <> "Rositah") And (Users <> "ika") Then
                strSQL = "select Code,Name,U_RevNo,U_LineNo,U_SBU,U_Dep,U_Brn,U_Sqm as sql,U_Sqmgross as sql2,u_floor from [@st_kpid] where U_RevNo ='" & No & "' "
                cmd = New OleDbCommand(strSQL, CServer)
                DRKPI = cmd.ExecuteReader
                DG.Rows.Clear()
                Do While DRKPI.Read
                    DG.Rows.Add(DRKPI("U_LineNo").ToString, DRKPI("U_SBU").ToString, DRKPI("U_Dep").ToString, DRKPI("U_Brn").ToString, DRKPI("sql").ToString, DRKPI("sql2").ToString, DRKPI("u_floor").ToString, DRKPI("Code").ToString)
                Loop
                DG.AllowUserToAddRows = False
                DRKPI.Close()
                btnSave.Text = "OK"
            End If

    End Sub
#End Region

#Region "Navigator"

    Private Sub tsFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsFirst.Click
        PosisiRecord = 0
        Me.ListRecord()
        FindGrid(txtNoRev.Text)
    End Sub

    Private Sub tsPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsPrev.Click
        If PosisiRecord = 0 Then
            MsgBox("Record sudah paling Atas...!", MsgBoxStyle.Information, "Navigasi record")
        Else
            PosisiRecord -= 1
            Me.ListRecord()
            FindGrid(txtNoRev.Text)
        End If
    End Sub

    Private Sub tsNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsNext.Click
        If PosisiRecord = ds.Tables("kpih").Rows.Count - 1 Then
            MsgBox("Record sudah paling akhir...!", MsgBoxStyle.Information, "Navigasi record")
        Else
            PosisiRecord += 1
            Me.ListRecord()
            FindGrid(txtNoRev.Text)
        End If
    End Sub

    Private Sub tsLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsLast.Click
        PosisiRecord = ds.Tables("kpih").Rows.Count - 1
        Me.ListRecord()
        FindGrid(txtNoRev.Text)
    End Sub

    Private Sub tsFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsFind.Click
        txtNoRev.ReadOnly = False
        txtNoRev.Focus()
    End Sub

#End Region

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        If btnExit.Text = "Cancel" Then
            MsgBox("Proses Belum Selesai Tidak Bisa Di Cancel.", MsgBoxStyle.Critical)
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        frmListKPI.Label1.Text = "Find - KPI"
        frmListKPI.ShowDialog()
    End Sub

    Private Sub btnSite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSite.Click
        frmStore.lblList.Text = "List Of Warehouses - KPI"
        frmStore.ShowDialog()
    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Try
            If DG.Enabled = False Then
                MessageBox.Show("Tidak bisa melakukan pencarian SBU!! Save terlebih dahulu!!", "oops")
                btnSave.Focus()
            End If
            For I As Integer = 0 To DG.Rows.Count - 1
                If DG.Rows(I).Cells(1).Value.ToString = Trim(txtSbu.Text) And DG.Rows(I).Cells(2).Value.ToString = Trim(txtDept.Text) And DG.Rows(I).Cells(3).Value.ToString = Trim(txtBrand.Text) Then
                    DG.Rows(I).Selected = True
                    DG.CurrentCell = DG.Item(1, I)
                    Exit For
                End If
            Next
            lblKet.Text = ""
        Catch ex As Exception
            lblKet.Text = "Data Not Found"
        End Try
    End Sub

    Private Sub ElementSsave()
        strSQL = "select  isnull(max(Code)+1,1) code from [@st_kpid]"
        cmd = New OleDbCommand(strSQL, CServer)
        DRNRd = cmd.ExecuteReader
        DRNRd.Read()
        Kode = DRNRd("Code")
        DRNRd.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtSite.Text = "" Then
            MessageBox.Show("Site harus diisi")
            txtSite.Focus() : Exit Sub
        End If
        If txtKet.Text = "" Then
            MessageBox.Show("Nama Revisi harus diisi")
            txtKet.Focus() : Exit Sub
        End If
        pg1.Value = 0
        If btnSave.Text = "Update" Then
            Try
                DG.AllowUserToAddRows = False
                bg1.WorkerReportsProgress = True
                bg1.WorkerSupportsCancellation = True
                bg1.RunWorkerAsync()
                btnSave.Enabled = False
                btnExit.Text = "Cancel"
            Catch ex As Exception
                MsgBox(ex.Message, "Error")
            End Try
        ElseIf btnSave.Text = "Add" Then
            btnSave.Text = "Update"
            no_rev()
            txtSite.Focus()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub txtSbu_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSbu.LostFocus
        txtSbu.Text = UCase(txtSbu.Text)
    End Sub

    Private Sub txtDept_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDept.LostFocus
        txtDept.Text = UCase(txtDept.Text)
    End Sub

    Private Sub txtBrand_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBrand.LostFocus
        txtBrand.Text = UCase(txtBrand.Text)
    End Sub

    Private Sub DG_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DG.CellBeginEdit
        Try
            For i As Integer = 0 To DG.Rows.Count - 1
                btnSave.Text = "Update"
                btnSave.Enabled = False
                If e.ColumnIndex = 1 Then
                    DG.AllowUserToAddRows = False
                    If System.Convert.ToString(DG.Rows(e.RowIndex).Cells(0).Value) = "" Then
                        DG.CurrentCell = DG.Rows(DG.Rows.Count - 1).Cells(2)
                        DG.Rows(e.RowIndex).Cells(4).Value = 0
                        DG.Rows(e.RowIndex).Cells(5).Value = 0
                        DG.Rows(e.RowIndex).Cells(0).Value = e.RowIndex + 1
                    Else
                    End If

                ElseIf e.ColumnIndex = 2 Then
                    If System.Convert.ToString(DG.Rows(i).Cells(0).Value) = "" Then
                        DG.AllowUserToAddRows = False
                        DG.CurrentCell = DG.Rows(DG.Rows.Count - 1).Cells(3)
                    Else
                    End If

                ElseIf e.ColumnIndex = 3 Then
                    If System.Convert.ToString(DG.Rows(e.RowIndex).Cells(0).Value) = "" Then
                        DG.AllowUserToAddRows = False
                        DG.CurrentCell = DG.Rows(DG.Rows.Count - 1).Cells(4)
                    End If

                ElseIf e.ColumnIndex = 4 Then
                    If System.Convert.ToString(DG.Rows(e.RowIndex).Cells(0).Value) = "" Then
                        DG.AllowUserToAddRows = False
                        DG.CurrentCell = DG.Rows(DG.Rows.Count - 1).Cells(5)
                    End If

                ElseIf e.ColumnIndex = 5 Then
                    DG.AllowUserToAddRows = True
                    DG.CurrentCell = DG.Item(1, i + 1)
                    DG.Enabled = False
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DG_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellEndEdit
        btnSave.Enabled = True
    End Sub

    Private Sub DG_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DG.EditingControlShowing
        If TypeOf e.Control Is TextBox Then
            DirectCast(e.Control, TextBox).CharacterCasing = CharacterCasing.Upper
        End If
    End Sub

    Private Sub txtKet_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKet.TextChanged
        If btnSave.Text = "OK" Then
            btnSave.Text = "Update"
        End If
    End Sub

    Private Sub txtNoRev_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNoRev.KeyDown
        If e.KeyCode = Keys.Enter Then
            strSQL = "SELECT Code, Name, U_RevNo, U_RevName, U_RevDate, U_Store, U_CreateBy, U_CreateDate FROM [@ST_KPIH] where U_RevNo ='" & txtNoRev.Text & "'"
            cmd = New OleDbCommand(strSQL, CServer)
            DRNRh = cmd.ExecuteReader
            If DRNRh.Read Then
                txtNoRev.Text = DRNRh("U_RevNo")
                DT.Value = DRNRh("U_CreateDate")
                txtSite.Text = DRNRh("U_Store")
                txtKet.Text = DRNRh("U_RevName")
            Else
                MessageBox.Show("No Revisi '" & txtNoRev.Text & "' tidak ada", "Oops")
                Exit Sub
            End If
            FindGrid(txtNoRev.Text)
            btnSave.Text = "Update"
            txtNoRev.ReadOnly = True
        End If
    End Sub
    Sub proces()

        'KPI H
        strSQL = "select * from [@st_kpih] where U_RevNo ='" & txtNoRev.Text & "' "
        cmd = New OleDbCommand(strSQL, CServer)
        DRNRh = cmd.ExecuteReader
        If DRNRh.Read Then
            strSQL = "update [@st_kpih] set u_revname='" & txtKet.Text & "' " & _
            "where U_RevNo ='" & txtNoRev.Text & "' "
            ExecQuery(strSQL)
        Else
            strSQL = "insert into [@st_kpih] (Code, Name, U_RevNo, U_RevName, U_RevDate, U_Store, U_CreateBy, U_CreateDate)" & _
                " VALUES ('" & txtNoRev.Text & "','" & txtNoRev.Text & "','" & txtNoRev.Text & "','" & txtKet.Text & "','" & Format(DT.Value, "yyyy-MM-dd") & "','" & txtSite.Text & "','" & VUser & "','" & Tglrev & "')"
            ExecQuery(strSQL)
        End If

        'KPI D
        If DG.Rows.Count <> 0 Then

            For i As Integer = 0 To DG.Rows.Count - 1
                Try
                    Process += 100 / DG.Rows.Count
                    bg1.ReportProgress(Int(Process))
                    strSQL = "select u_revno,u_sbu,u_dep,u_brn,U_LineNo from [@ST_KPID] where u_revno = '" & txtNoRev.Text & "' and " & _
                             "u_sbu='" & DG.Rows(i).Cells(1).Value & "' and u_dep='" & DG.Rows(i).Cells(2).Value & "' and " & _
                             "u_brn='" & DG.Rows(i).Cells(3).Value & "' and U_LineNo='" & DG.Rows(i).Cells(0).Value & "'"
                    dsCek = getSqldb(strSQL)
                    If dsCek.Tables(0).Rows.Count = 0 Then
                        ElementSsave()
                        NoLine = DG.Rows(i).Cells(0).Value
                        NoRev = txtNoRev.Text
                        SBU = DG.Rows(i).Cells(1).Value
                        Dept = DG.Rows(i).Cells(2).Value
                        Brand = DG.Rows(i).Cells(3).Value
                        If IsDBNull(DG.Rows(i).Cells(4).Value) = True Or DG.Rows(i).Cells(4).Value = "" Then
                            SQM = "0"
                        Else
                            SQM = DG.Rows(i).Cells(4).Value
                        End If

                        If IsDBNull(DG.Rows(i).Cells(5).Value) = True Or DG.Rows(i).Cells(5).Value = "" Then
                            SQMNET = "0"
                        Else
                            SQMNET = DG.Rows(i).Cells(5).Value
                        End If

                        Floor = DG.Rows(i).Cells(6).Value

                        strSQL1 = "insert into [@st_kpiD] (Code, Name, U_RevNo, U_LineNo, U_SBU, U_Dep, U_Brn, U_Sqm,U_Sqmgross, U_Floor) " & _
                                            " values ('" & Kode & "','" & Kode & "','" & NoRev & "','" & NoLine & "','" & SBU & "','" & Dept & "','" & Brand & "','" & SQM & "','" & SQMNET & "','" & Floor & "')"
                        getSqldb(strSQL1)
                    Else
                        ElementSsave()
                        NoLine = dsCek.Tables(0).Rows(0).Item("U_LineNo")
                        NoRev = txtNoRev.Text
                        SBU = DG.Rows(i).Cells(1).Value
                        Dept = DG.Rows(i).Cells(2).Value
                        Brand = DG.Rows(i).Cells(3).Value
                        If IsDBNull(DG.Rows(i).Cells(4).Value) = True Or DG.Rows(i).Cells(4).Value = "" Then
                            SQM = "0"
                        Else
                            SQM = DG.Rows(i).Cells(4).Value
                        End If

                        If IsDBNull(DG.Rows(i).Cells(5).Value) = True Or DG.Rows(i).Cells(5).Value = "" Then
                            SQMNET = "0"
                        Else
                            SQMNET = DG.Rows(i).Cells(5).Value
                        End If

                        Floor = DG.Rows(i).Cells(6).Value
                        StrSQL2 = "update [@st_kpiD] set U_SBU='" & SBU & "',U_Dep='" & Dept & "',U_Brn='" & Brand & "',U_Sqm=" & SQM & ",U_Sqmgross='" & SQMNET & "',U_Floor='" & Floor & "' " & _
                             " where U_SBU+U_Dep+U_Brn='" & SBU & "'+'" & Dept & "'+'" & Brand & "' and u_revno='" & NoRev & "' and U_LineNo='" & NoLine & "' "
                        getSqldb(StrSQL2)
                    End If
                    Label9.Text = i.ToString & "-" & NoLine & "-" & SBU & "-" & Dept & "-" & Brand
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Next
        End If
    End Sub

    Private Sub bg1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bg1.DoWork
        Process = 0
        pg1.Value = 0
        proces()
    End Sub

    Private Sub bg1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bg1.ProgressChanged
        Me.pg1.Value = e.ProgressPercentage
    End Sub

    Private Sub bg1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bg1.RunWorkerCompleted
        MessageBox.Show("Data berhasil disimpan")
        ViewData()
        FindGrid(txtNoRev.Text)
        DG.AllowUserToAddRows = False
        pg1.Value = 0
        pg1.Minimum = 0
        Process = 0
        btnSave.Enabled = True
        Bersih()
        btnExit.Text = "Exit"
        btnSave.Text = "Add"
        Label9.Text = ""
    End Sub

End Class
