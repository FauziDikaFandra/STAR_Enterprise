Imports System.Data
Imports System.Data.OleDb

Public Class FrmTarget

    Private Sub FrmTarget_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dt.Value = Format(Now, "yyyy-MM-dd hh:mm:ss")
        SetDG()
        Year()
        ViewData()
        Tglrev = Format(Now, "yyyy-MM-dd")
        Bersih()
    End Sub

#Region "Umum"
    Private Sub SetDG()
        With DG
            .Columns.Add("No", "No") : .Columns(0).Width = 50 : .Columns(0).ReadOnly = True
            .Columns.Add("SBU", "SBU") : .Columns(1).Width = 50
            .Columns.Add("Dept", "Dept") : .Columns(2).Width = 50
            .Columns.Add("Brand", "Brand") : .Columns(3).Width = 50
            .Columns.Add("Jan", "Jan") : .Columns(4).Width = 80 : .Columns(4).DefaultCellStyle.Format = "#,##0"
            .Columns.Add("Feb", "Feb") : .Columns(5).Width = 80 : .Columns(5).DefaultCellStyle.Format = "#,##0"
            .Columns.Add("Mar", "Mar") : .Columns(6).Width = 80 : .Columns(6).DefaultCellStyle.Format = "#,##0"
            .Columns.Add("Apr", "Apr") : .Columns(7).Width = 80 : .Columns(7).DefaultCellStyle.Format = "#,##0"
            .Columns.Add("May", "May") : .Columns(8).Width = 80 : .Columns(8).DefaultCellStyle.Format = "#,##0"
            .Columns.Add("Jun", "Jun") : .Columns(9).Width = 80 : .Columns(9).DefaultCellStyle.Format = "#,##0"
            .Columns.Add("Jul", "Jul") : .Columns(10).Width = 80 : .Columns(10).DefaultCellStyle.Format = "#,##0"
            .Columns.Add("Aug", "Aug") : .Columns(11).Width = 80 : .Columns(11).DefaultCellStyle.Format = "#,##0"
            .Columns.Add("Sep", "Sep") : .Columns(12).Width = 80 : .Columns(12).DefaultCellStyle.Format = "#,##0"
            .Columns.Add("Oct", "Oct") : .Columns(13).Width = 80 : .Columns(13).DefaultCellStyle.Format = "#,##0"
            .Columns.Add("Nov", "Nov") : .Columns(14).Width = 80 : .Columns(14).DefaultCellStyle.Format = "#,##0"
            .Columns.Add("Dec", "Dec") : .Columns(15).Width = 80 : .Columns(15).DefaultCellStyle.Format = "#,##0"
            .Columns.Add("Code", "Code") : .Columns(16).Width = 50
            .Columns(16).Visible = False
        End With

        txtNorev.ReadOnly = True : dt.Enabled = False
    End Sub

    Private Sub Bersih()
        txtNoRev.Text = "" : txtSite.Text = "" : txtKet.Text = ""
        DG.Rows.Clear()
        lblKet.Text = ""
    End Sub

    Private Sub Year()
        Dim T As Integer
        Dim c As String
        c = Now.Year
        cmbYear.Text = c
        For T = c - 1 To c
            cmbYear.Items.Add(T)
        Next
    End Sub

    Private Sub no_rev()
        strSQL = " select isnull(max(Code)+1,1) as code,max(convert(int,[U_RevNo]))+1  as no FROM [@ST_STARGETh]"
        cmd = New OleDbCommand(strSQL, CServer)
        DRNRh = cmd.ExecuteReader
        If DRNRh.Read Then
            txtNoRev.Text = DRNRh("no")
        End If
        DRNRh.Close()
    End Sub

    Private Sub ViewData()
        ds = New DataSet
        strSQL = "SELECT   Code, Name, U_RevNo, U_RevName, U_RevDate, U_Store, U_TYear, U_CreateBy,LEFT(U_CreateDate, 10) AS u_createdate" & _
                " FROM [@ST_STARGETH] order by convert(int,U_RevNo )"
        da = New OleDbDataAdapter(strSQL, CServer)
        da.Fill(ds, "STARGETh")
    End Sub

    Private Sub ListRecord()
        txtNorev.Text = ds.Tables("STARGETh").Rows(PosisiRecord)("U_revno").ToString
        dt.Value = ds.Tables("STARGETh").Rows(PosisiRecord)("u_createdate").ToString
        txtSite.Text = ds.Tables("STARGETh").Rows(PosisiRecord)("u_store").ToString
        cmbYear.Text = ds.Tables("STARGETh").Rows(PosisiRecord)("u_tyear").ToString
        txtKet.Text = ds.Tables("STARGETh").Rows(PosisiRecord)("u_revname").ToString
    End Sub

    Private Sub ElementSsave()
        strSQL = "select  isnull(max(Code)+1,1) code from [@st_stargetd]"
        cmd = New OleDbCommand(strSQL, CServer)
        DRNRd = cmd.ExecuteReader
        DRNRd.Read()
        Kode = DRNRd("Code")
        DRNRd.Close()

        NoLine = DG.Rows(i).Cells(0).Value
        'NoLine = System.Convert.ToString(DG.Rows(e.RowIndex).Cells(0).Value)
        NoRev = txtNorev.Text
        SBU = DG.Rows(i).Cells(1).Value
        Dept = DG.Rows(i).Cells(2).Value
        Brand = DG.Rows(i).Cells(3).Value

        If Not IsDBNull(DG.Rows(i).Cells(4).Value) Then
            Jan = DG.Rows(i).Cells(4).Value
        Else
            jan = "0"
        End If

        If Not IsDBNull(DG.Rows(i).Cells(5).Value) Then
            feb = DG.Rows(i).Cells(5).Value
        Else
            feb = "0"
        End If

        If Not IsDBNull(DG.Rows(i).Cells(6).Value) Then
            mar = DG.Rows(i).Cells(6).Value
        Else
            mar = "0"
        End If

        If Not IsDBNull(DG.Rows(i).Cells(7).Value) Then
            apr = DG.Rows(i).Cells(7).Value
        Else
            apr = "0"
        End If

        If Not IsDBNull(DG.Rows(i).Cells(8).Value) Then
            may = DG.Rows(i).Cells(8).Value
        Else
            may = "0"
        End If

        If Not IsDBNull(DG.Rows(i).Cells(9).Value) Then
            jun = DG.Rows(i).Cells(9).Value
        Else
            jun = "0"
        End If

        If Not IsDBNull(DG.Rows(i).Cells(10).Value) Then
            jul = DG.Rows(i).Cells(10).Value
        Else
            jul = "0"
        End If

        If Not IsDBNull(DG.Rows(i).Cells(11).Value) Then
            aug = DG.Rows(i).Cells(11).Value
        Else
            aug = "0"
        End If

        If Not IsDBNull(DG.Rows(i).Cells(12).Value) Then
            sep = DG.Rows(i).Cells(12).Value
        Else
            sep = "0"
        End If

        If Not IsDBNull(DG.Rows(i).Cells(13).Value) Then
            Oct = DG.Rows(i).Cells(13).Value
        Else
            Oct = "0"
        End If

        If Not IsDBNull(DG.Rows(i).Cells(14).Value) Then
            nov = DG.Rows(i).Cells(14).Value
        Else
            nov = "0"
        End If

        If Not IsDBNull(DG.Rows(i).Cells(15).Value) Then
            dec = DG.Rows(i).Cells(15).Value
        Else
            dec = "0"
        End If


    End Sub

    Private Sub FindGrid(ByVal No As String)
        'strSQL = "select Code,Name,U_RevNo,U_LineNo,U_SBU,U_Dep,U_Brn,LEFT(U_Sqm, 5) as sql,u_floor from [@st_kpid] where U_RevNo ='" & No & "'"
        strSQL = "SELECT     Code, Name, U_RevNo, U_LineNo, U_SBU, U_Dep, U_Brn, U_Jan, U_Feb, U_Mar, U_Apr, U_May, U_Jun, U_Jul, U_Aug, U_Sep, U_Oct, U_Nov, U_Dec FROm [@ST_STARGETD] where U_RevNo ='" & No & "'"
        cmd = New OleDbCommand(strSQL, CServer)
        DRKPI = cmd.ExecuteReader
        DG.Rows.Clear()
        Do While DRKPI.Read
            DG.Rows.Add(DRKPI("U_LineNo"), DRKPI("U_SBU"), DRKPI("U_Dep"), DRKPI("U_Brn"), DRKPI("U_Jan"), DRKPI("U_Feb"), DRKPI("U_Mar"), DRKPI("U_Apr"), DRKPI("U_May"), DRKPI("U_Jun"), DRKPI("U_Jul"), DRKPI("U_Aug"), DRKPI("U_Sep"), DRKPI("U_Oct"), DRKPI("U_Nov"), DRKPI("U_Dec"), DRKPI("code"))
        Loop
        DRKPI.Close()
        btnSave.Text = "OK"
    End Sub
#End Region

#Region "Navigator"
    Private Sub tsFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsFirst.Click
        PosisiRecord = 0
        ListRecord()
        FindGrid(txtNorev.Text)
    End Sub

    Private Sub tsPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsPrev.Click
        If PosisiRecord = 0 Then
            MessageBox.Show("Ini Record Terakhir", "Oops")
        Else
            PosisiRecord -= 1
        End If
        ListRecord()
        FindGrid(txtNorev.Text)
    End Sub

    Private Sub tsNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsNext.Click
        If PosisiRecord = ds.Tables("stargeth").Rows.Count - 1 Then
            MessageBox.Show("Ini Record Terakhir", "Oops")
        Else
            PosisiRecord += 1
        End If
        ListRecord()
        FindGrid(txtNorev.Text)
    End Sub

    Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PosisiRecord = 0
        ListRecord()
        FindGrid(txtNorev.Text)
    End Sub

    Private Sub tsLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsLast.Click
        PosisiRecord = ds.Tables("stargeth").Rows.Count - 1
        ListRecord()
        FindGrid(txtNorev.Text)
    End Sub

    Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        frmListKPI.Label1.Text = "Find - Sales Target"
        frmListKPI.ShowDialog()
    End Sub
#End Region

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
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

    Private Sub btnSite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSite.Click
        frmStore.lblList.Text = "List Of Warehouses - Sales Target"
        frmStore.ShowDialog()
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
        If btnSave.Text = "Update" Then
            ' btnSave.Text = "Add"

            strSQL = "select * from [@ST_STARGETH] where U_RevNo ='" & txtNorev.Text & "' "
            cmd = New OleDbCommand(strSQL, CServer)
            DRNRh = cmd.ExecuteReader
            If DRNRh.Read Then
                strSQL = "update [@ST_STARGETH] set u_revname='" & txtKet.Text & "' where U_RevNo ='" & txtNorev.Text & "' "
                ExecQuery(strSQL)
            Else
                strSQL = "insert into [@ST_STARGETH] (Code, Name, U_RevNo, U_RevName, U_RevDate, U_Store, u_tyear,U_CreateBy, U_CreateDate)" & _
                    " VALUES ('" & txtNorev.Text & "','" & txtNorev.Text & "','" & txtNorev.Text & "','" & txtKet.Text & "','" & Tglrev & "','" & txtSite.Text & "','" & cmbYear.Text & "','" & VUser & "','" & Microsoft.VisualBasic.Left(dt.Value, 19) & "')"
                ExecQuery(strSQL)
            End If

            If DG.Rows.Count <> 0 Then
                DG.AllowUserToAddRows = False
                For i As Integer = 0 To DG.Rows.Count - 1
                    If DG.Rows(i).Cells(1).Value = "" Or DG.Rows(i).Cells(2).Value = "" Or DG.Rows(i).Cells(3).Value = "" Then
                    Else
                        ElementSsave()
                        If DG.Rows(i).Cells(16).Value = "" Then
                            strSQL = "insert into [@ST_STARGETd] (Code, Name, U_RevNo, U_LineNo, U_SBU, U_Dep, U_Brn, U_Jan, U_Feb, U_Mar, U_Apr, U_May, U_Jun, U_Jul, U_Aug, U_Sep, U_Oct, U_Nov, U_Dec)  " & _
                                    " values ('" & Kode & "','" & Kode & "','" & NoRev & "','" & NoLine & "','" & SBU & "','" & Dept & "','" & Brand & "','" & Jan & "','" & Feb & "','" & Mar & "','" & Apr & "' " & _
                                    " ,'" & May & "','" & Jun & "','" & Jul & "','" & Aug & "','" & Sep & "','" & Oct & "','" & Nov & "','" & Dec & "')"
                            ExecQuery(strSQL)
                        Else
                            strSQL = "update [@ST_STARGETd] set U_SBU='" & SBU & "', U_Dep='" & Dept & "', U_Brn='" & Brand & "', U_Jan='" & Jan & "', U_Feb='" & Feb & "', U_Mar='" & Mar & "', U_Apr='" & Apr & "' , U_May='" & May & "' " & _
                                     " , U_Jun='" & Jun & "', U_Jul='" & Jul & "', U_Aug='" & Aug & "', U_Sep='" & Sep & "', U_Oct='" & Oct & "', U_Nov='" & Nov & "', U_Dec='" & Dec & "' " & _
                                     " where U_SBU+U_Dep+U_Brn='" & SBU & "'+'" & Dept & "'+'" & Brand & "' and u_revno='" & NoRev & "' and code='" & DG.Rows(i).Cells(16).Value & "' "
                            ExecQuery(strSQL)
                        End If
                    End If

                Next
                MessageBox.Show("Data berhasil disimpan")
                ViewData()
                FindGrid(txtNorev.Text)
                DG.AllowUserToAddRows = True
            End If
        ElseIf btnSave.Text = "Add" Then
            btnSave.Text = "Update"
            no_rev()
            txtSite.Focus()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Try
            For I As Integer = 0 To DG.Rows.Count - 1
                If DG.Rows(I).Cells(1).Value.ToString = Trim(txtSbu.Text) And DG.Rows(I).Cells(2).Value.ToString = Trim(txtDept.Text) And DG.Rows(I).Cells(3).Value.ToString = Trim(txtBrand.Text) Then
                    DG.Rows(I).Selected = True
                    DG.CurrentCell = DG.Item(1, I)
                    Exit For
                End If
            Next
            lblket.Text = ""
        Catch ex As Exception
            lblket.Text = "Data Not Found"
        End Try
    End Sub

    Private Sub DG_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellEndEdit
        Try
            For i As Integer = 0 To DG.Rows.Count - 1
                btnSave.Text = "Update"
                'If System.Convert.ToString(DG.Rows(i).Cells(0).Value) = "" Then
                If e.ColumnIndex = 1 Then
                    DG.AllowUserToAddRows = False
                    If System.Convert.ToString(DG.Rows(e.RowIndex).Cells(0).Value) = "" Then
                        DG.CurrentCell = DG.Rows(DG.Rows.Count - 1).Cells(2)
                        DG.Rows(e.RowIndex).Cells(4).Value = 0
                        DG.Rows(e.RowIndex).Cells(5).Value = 0
                        DG.Rows(e.RowIndex).Cells(6).Value = 0
                        DG.Rows(e.RowIndex).Cells(7).Value = 0
                        DG.Rows(e.RowIndex).Cells(8).Value = 0
                        DG.Rows(e.RowIndex).Cells(9).Value = 0
                        DG.Rows(e.RowIndex).Cells(10).Value = 0
                        DG.Rows(e.RowIndex).Cells(11).Value = 0
                        DG.Rows(e.RowIndex).Cells(12).Value = 0
                        DG.Rows(e.RowIndex).Cells(13).Value = 0
                        DG.Rows(e.RowIndex).Cells(14).Value = 0
                        DG.Rows(e.RowIndex).Cells(15).Value = 0
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
                    'If System.Convert.ToString(DG.Rows(e.RowIndex).Cells(0).Value) = "" Then
                    '    DG.AllowUserToAddRows = False
                    '    DG.CurrentCell = DG.Rows(DG.Rows.Count - 1).Cells(5)
                    'End If
                    DG.AllowUserToAddRows = True
                    DG.CurrentCell = DG.Item(1, i + 1)

                ElseIf e.ColumnIndex = 5 Then
                    DG.AllowUserToAddRows = True
                    DG.CurrentCell = DG.Item(1, i + 1)
                    '   DG.Rows(e.RowIndex).Cells(0).Value = i
                ElseIf e.ColumnIndex = 6 Then
                    DG.AllowUserToAddRows = True
                    DG.CurrentCell = DG.Item(1, i + 1)
                ElseIf e.ColumnIndex = 7 Then
                    DG.AllowUserToAddRows = True
                    DG.CurrentCell = DG.Item(1, i + 1)
                ElseIf e.ColumnIndex = 8 Then
                    DG.AllowUserToAddRows = True
                    DG.CurrentCell = DG.Item(1, i + 1)
                ElseIf e.ColumnIndex = 9 Then
                    DG.AllowUserToAddRows = True
                    DG.CurrentCell = DG.Item(1, i + 1)
                ElseIf e.ColumnIndex = 10 Then
                    DG.AllowUserToAddRows = True
                    DG.CurrentCell = DG.Item(1, i + 1)
                ElseIf e.ColumnIndex = 11 Then
                    DG.AllowUserToAddRows = True
                    DG.CurrentCell = DG.Item(1, i + 1)
                ElseIf e.ColumnIndex = 12 Then
                    DG.AllowUserToAddRows = True
                    DG.CurrentCell = DG.Item(1, i + 1)
                ElseIf e.ColumnIndex = 13 Then
                    DG.AllowUserToAddRows = True
                    DG.CurrentCell = DG.Item(1, i + 1)
                ElseIf e.ColumnIndex = 14 Then
                    DG.AllowUserToAddRows = True
                    DG.CurrentCell = DG.Item(1, i + 1)
                ElseIf e.ColumnIndex = 15 Then
                    DG.AllowUserToAddRows = True
                    DG.CurrentCell = DG.Item(1, i + 1)
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtKet_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKet.TextChanged
        If btnSave.Text = "OK" Then
            btnSave.Text = "Update"
        End If
    End Sub

    Private Sub DG_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DG.EditingControlShowing
        If TypeOf e.Control Is TextBox Then
            DirectCast(e.Control, TextBox).CharacterCasing = CharacterCasing.Upper
        End If
    End Sub





End Class