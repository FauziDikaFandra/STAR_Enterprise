Imports System.Data
Imports System.Data.OleDb
Imports System.Configuration

Public Class ceknobrand
    Dim x As String
    Dim Sql, Users, la1, la2, md, ch, hh As String

    Private Sub setTime()
        Dim y As String
        Dim bln() As String = {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"}
        Dim month As Integer = Now.Month - 1
        Dim Month2 As Integer = Now.Month
        cbomonth.Text = Month2 & " - " & bln(month)
        y = Now.Year

        For i As Integer = y - 2 To y
            cboyear.Items.Add(i)
        Next

        With cbomonth.Items
            .Add("1 - January")
            .Add("2 - February")
            .Add("3 - March")
            .Add("4 - April")
            .Add("5 - May")
            .Add("6 - June")
            .Add("7 - July")
            .Add("8 - August")
            .Add("9 - September")
            .Add("10 - October")
            .Add("11 - November")
            .Add("12 - December")
        End With

    End Sub
    Sub grid1()
        With dg1
            .Columns.Clear()
            .Columns.Add("SBU", "SBU") : .Columns(0).Width = 50 : .Columns(0).ReadOnly = True
            .Columns.Add("Dept", "Dept") : .Columns(1).Width = 50 : .Columns(0).ReadOnly = True
            .Columns.Add("Brand", "Brand") : .Columns(2).Width = 50 : .Columns(0).ReadOnly = True
            .Columns.Add("Jan", "Jan") : .Columns(3).Width = 50 : .Columns(3).DefaultCellStyle.Format = "#,##0"
            .Columns.Add("Feb", "Feb") : .Columns(4).Width = 50 : .Columns(4).DefaultCellStyle.Format = "#,##0"
            .Columns.Add("Mar", "Mar") : .Columns(5).Width = 50 : .Columns(5).DefaultCellStyle.Format = "#,##0"
            .Columns.Add("Apr", "Apr") : .Columns(6).Width = 50 : .Columns(6).DefaultCellStyle.Format = "#,##0"
            .Columns.Add("May", "May") : .Columns(7).Width = 50 : .Columns(7).DefaultCellStyle.Format = "#,##0"
            .Columns.Add("Jun", "Jun") : .Columns(8).Width = 50 : .Columns(8).DefaultCellStyle.Format = "#,##0"
            .Columns.Add("Jul", "Jul") : .Columns(9).Width = 50 : .Columns(9).DefaultCellStyle.Format = "#,##0"
            .Columns.Add("Aug", "Aug") : .Columns(10).Width = 50 : .Columns(10).DefaultCellStyle.Format = "#,##0"
            .Columns.Add("Sep", "Sep") : .Columns(11).Width = 50 : .Columns(11).DefaultCellStyle.Format = "#,##0"
            .Columns.Add("Oct", "Oct") : .Columns(12).Width = 50 : .Columns(12).DefaultCellStyle.Format = "#,##0"
            .Columns.Add("Nov", "Nov") : .Columns(13).Width = 50 : .Columns(13).DefaultCellStyle.Format = "#,##0"
            .Columns.Add("Des", "Des") : .Columns(14).Width = 50 : .Columns(14).DefaultCellStyle.Format = "#,##0"
        End With
    End Sub

    Sub grid2()
        With dg1
            .Columns.Clear()
            .Columns.Add("SBU", "SBU") : .Columns(0).Width = 50 : .Columns(0).ReadOnly = True
            .Columns.Add("Dept", "Dept") : .Columns(1).Width = 50 : .Columns(0).ReadOnly = True
            .Columns.Add("Brand", "Brand") : .Columns(2).Width = 50 : .Columns(0).ReadOnly = True
            .Columns.Add("SQM", "SQM") : .Columns(2).Width = 50
            .Columns.Add("Floor", "Floor") : .Columns(2).Width = 50
        End With
    End Sub
    Sub bersih()
        txtkpi.Enabled = False
        txtStore.Enabled = False
        Label10.Text = ""
        lbllastkpi.Text = ""
        txtStore.Text = ""
        txtkpi.Text = ""
        cbomonth.Text = ""
        cboyear.Text = ""
    End Sub
    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub ceknobrand_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        setTime()
        bersih()
        CheckConnection2()
        ConnectServer()
    End Sub


    Private Sub btnstore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnstore.Click
        frmStore.lblList.Text = "List of Warehouses - Store Cek Brand"
        frmStore.ShowDialog()
    End Sub

    Private Sub btnreload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreload.Click
        Sql = ""
        Users = UsrID
        la1 = "LA"
        la2 = "LD"
        md = "MD"
        ch = "CH"
        hh = "HH"
        If Users = "ika" Then
            Sql = Sql + "in ('" & la1 & "')"
        ElseIf Users = "adit" Then
            Sql = Sql + "in ('" & ch & "','" & hh & "')"
        ElseIf Users = "rositah" Then
            Sql = Sql + "in ('" & la2 & "','" & md & "')"
        ElseIf Users = "it" Or Users = "it2" Then
            Sql = Sql + "in ('" & la1 & "','" & la2 & "','" & md & "','" & ch & "','" & hh & "')"
        End If
        If txtStore.Text = "" And cbomonth.Text = "" And cboyear.Text = "" Then
            MsgBox("Pilih Dahulu Toko, bulan dan tahun yang akan diproses.", MsgBoxStyle.Critical)
        Else
            Call grid1()
            strSQL1 = "select left(c.OcrCode,2) as sbu, SUBSTRING(c.OcrCode,3,2) as dept, substring(ItmsGrpNam,6,3)  as brand, '0' as u_jan, '0' as u_feb, '0' as u_mar, " & _
                  "'0' as u_apr,'0' as u_may,'0' as u_jun,'0' as u_jul,'0' as u_aug,'0' as u_sep,'0' as u_oct,'0' as u_nov,'0' as u_des from OITM a " & _
                  "inner join  OITB b on a.itmsgrpcod=b.itmsgrpcod " & _
                  "inner join INV1 c on c.ItemCode=a.ItemCode " & _
                  "where month(DocDate) = '" & Microsoft.VisualBasic.Left(cbomonth.Text, 1) & "' and year(docdate)='" & cboyear.Text & "' and c.WhsCode  ='" & txtStore.Text & "' " & _
                  "and left(c.OcrCode,2)+SUBSTRING(c.OcrCode,3,2) +substring(ItmsGrpNam,6,3) not in (select U_SBU+U_Dep+U_Brn from [@ST_STARGETD] " & _
                  "where U_RevNo='" & txtkpi.Text & "') and  left(c.OcrCode,2) " & Sql & "" & _
                  "group by left(c.OcrCode,2), SUBSTRING(c.OcrCode,3,2),substring(ItmsGrpNam,6,3) " & _
                  "order by left(c.OcrCode,2), SUBSTRING(c.OcrCode,3,2),substring(ItmsGrpNam,6,3)"
            dsCek = getSqldb(strSQL1)
            If dsCek.Tables(0).Rows.Count = 0 Then
                MsgBox("SBU/DEPT/MC sales Tidak Ditemukan.", MsgBoxStyle.Information)
                txtkpi.Enabled = False
                txtStore.Enabled = False
                Label10.Text = ""
                lbllastkpi.Text = ""
                txtStore.Text = ""
                txtkpi.Text = ""
                cbomonth.Text = ""
                cboyear.Text = ""
                Call ceklastkpi()
            Else
                For i As Integer = 0 To dsCek.Tables(0).Rows.Count - 1
                    dg1.Rows.Add(dsCek.Tables(0).Rows(i).Item("sbu"), dsCek.Tables(0).Rows(i).Item("dept"), dsCek.Tables(0).Rows(i).Item("brand"), dsCek.Tables(0).Rows(i).Item("u_jan"), dsCek.Tables(0).Rows(i).Item("u_feb"), dsCek.Tables(0).Rows(i).Item("u_mar"), dsCek.Tables(0).Rows(i).Item("u_apr"), dsCek.Tables(0).Rows(i).Item("u_may"), dsCek.Tables(0).Rows(i).Item("u_jun"), dsCek.Tables(0).Rows(i).Item("u_jul"), dsCek.Tables(0).Rows(i).Item("u_aug"), dsCek.Tables(0).Rows(i).Item("u_sep"), dsCek.Tables(0).Rows(i).Item("u_oct"), dsCek.Tables(0).Rows(i).Item("u_nov"), dsCek.Tables(0).Rows(i).Item("u_des"))
                Next
                Label10.Text = "SNT Total : " & dg1.Rows.Count.ToString
            End If
        End If
    End Sub


    Private Sub btnreload3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreload3.Click
        Sql = ""
        Users = UsrID
        la1 = "LA"
        la2 = "LD"
        md = "MD"
        ch = "CH"
        hh = "HH"
        If Users = "ika" Then
            Sql = Sql + "in ('" & la1 & "')"
        ElseIf Users = "adit" Then
            Sql = Sql + "in ('" & ch & "','" & hh & "')"
        ElseIf Users = "rositah" Then
            Sql = Sql + "in ('" & la2 & "','" & md & "')"
        ElseIf Users = "it" Or Users = "it2" Then
            Sql = Sql + "in ('" & la1 & "','" & la2 & "','" & md & "','" & ch & "','" & hh & "')"
        End If
        If txtStore.Text = "" And cbomonth.Text = "" And cboyear.Text = "" Then
            MsgBox("Pilih Dahulu Toko, bulan dan tahun yang akan diproses.", MsgBoxStyle.Critical)
        Else
            grid2()
            strSQL1 = "select left(c.OcrCode,2) as sbu, SUBSTRING(c.OcrCode,3,2) as dept, substring(ItmsGrpNam,6,3)  as brand, '0' as sqm, '0' as floor from OITM a " & _
                        "inner join  OITB b on a.itmsgrpcod=b.itmsgrpcod " & _
                        "inner join INV1 c on c.ItemCode=a.ItemCode " & _
                        "where month(DocDate) = '" & Microsoft.VisualBasic.Left(cbomonth.Text, 2) & "' and year(docdate)='" & cboyear.Text & "' and c.WhsCode  ='" & txtStore.Text & "' " & _
                        "and left(c.OcrCode,2)+SUBSTRING(c.OcrCode,3,2) +substring(ItmsGrpNam,6,3)  " & _
                        " not in (select U_SBU+U_Dep+U_Brn from [@ST_KPID] " & _
                        " where U_RevNo='" & txtkpi.Text & "') and  left(c.OcrCode,2) " & Sql & "" & _
                        "group by left(c.OcrCode,2), SUBSTRING(c.OcrCode,3,2),substring(ItmsGrpNam,6,3) " & _
                        "order by left(c.OcrCode,2), SUBSTRING(c.OcrCode,3,2),substring(ItmsGrpNam,6,3)"
            dsCek = getSqldb(strSQL1)
            If dsCek.Tables(0).Rows.Count = 0 Then
                MsgBox("SBU/DEPT/MC sales Tidak Ditemukan.", MsgBoxStyle.Information)
                txtkpi.Enabled = False
                txtStore.Enabled = False
                Label10.Text = ""
                lbllastkpi.Text = ""
                txtStore.Text = ""
                txtkpi.Text = ""
                cbomonth.Text = ""
                cboyear.Text = ""
                Call ceklastkpi()
            Else
                For i As Integer = 0 To dsCek.Tables(0).Rows.Count - 1
                    dg1.Rows.Add(dsCek.Tables(0).Rows(i).Item("sbu"), dsCek.Tables(0).Rows(i).Item("dept"), dsCek.Tables(0).Rows(i).Item("brand"), dsCek.Tables(0).Rows(i).Item("sqm"), dsCek.Tables(0).Rows(i).Item("floor"))
                Next
                Label10.Text = "SNK Total : " & dg1.Rows.Count.ToString
            End If
        End If
    End Sub

    Private Sub cboyear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboyear.SelectedIndexChanged
        If txtStore.Text = "" Then
            MsgBox("Pilih site/store terlebih dahulu.", MsgBoxStyle.Information)
        Else
            strSQL = "select top 1 u_revno from [@ST_KPIH] where u_store='" & txtStore.Text & "' and month(u_revdate)='" & Microsoft.VisualBasic.Left(cbomonth.Text, 2) & "' and year(u_revdate)='" & cboyear.Text & "' order by code desc"
            dsCek = getSqldb(strSQL)

            If dsCek.Tables(0).Rows.Count = 0 Then
                MsgBox("Untuk Key Revisi Belum Dibuat.", MsgBoxStyle.Information)
                Call bersih()
                cbomonth.Focus()
            Else
                txtkpi.Text = dsCek.Tables(0).Rows(0).Item("u_revno")
                ceklastkpi()
                lbllastkpi.Text = "Last KPI : " & dsCek.Tables(0).Rows(0).Item("u_revno")
            End If
        End If
    End Sub


    Sub ceklastkpi()
        strSQL1 = "select top 1 u_revno from [@ST_KPIH] where u_store in ('s001','s002','s003') and (month(u_revdate)='" & Microsoft.VisualBasic.Left(cbomonth.Text, 1) & "' or month(u_revdate)='" & Microsoft.VisualBasic.Left(cbomonth.Text, 1) & "') and (year(u_revdate)='" & cboyear.Text & "' or year(u_revdate)='" & cboyear.Text & "') order by code desc"
        dsCek = getSqldb(strSQL)
        If dsCek.Tables(0).Rows.Count = 0 Then
            lbllastkpi.Text = "Last KPI tidak Ditemukan"
        Else
            lbllastkpi.Text = "Last KPI : " & dsCek.Tables(0).Rows(0).Item("u_revno")
        End If
    End Sub

    Private Sub btnprocess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnprocess.Click
        If dg1.Rows.Count > 0 Then
            dg1.AllowUserToAddRows = False
            bg1.WorkerReportsProgress = True
            bg1.WorkerSupportsCancellation = True
            bg1.RunWorkerAsync()
            btnprocess.Enabled = False
        Else
            MsgBox("Data yang akan ditransfer tidak ditemui.", MsgBoxStyle.Critical)
            Exit Sub
        End If
    End Sub

    Private Sub ElementSsave()
        strSQL = "select  isnull(max(Code)+1,1) code from [@st_kpid]"
        cmd = New OleDbCommand(strSQL, CServer)
        DRNRd = cmd.ExecuteReader
        DRNRd.Read()
        Kode = DRNRd("Code")
        DRNRd.Close()
    End Sub

    Private Sub DG1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dg1.EditingControlShowing
        If TypeOf e.Control Is TextBox Then
            DirectCast(e.Control, TextBox).CharacterCasing = CharacterCasing.Upper
        End If
    End Sub

    Private Sub dg1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellEndEdit
    End Sub

    Private Sub bg1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bg1.DoWork
        Dim Process As Decimal
        Dim seqnumber, code, seqnumberx As Integer

        If dg1.Rows.Count > 0 Then
            If Trim(Microsoft.VisualBasic.Left(Label10.Text, 3)) = "SNT" Then

                strSQL1 = "select  isnull(max(Code)+1,1) code from [@st_kpid]"
                cmd = New OleDbCommand(strSQL1, CServer)
                DRCEK = cmd.ExecuteReader
                If DRCEK.Read Then
                    code = DRCEK!code
                ElseIf Not DRCEK.Read Then
                    code = 1
                End If

                strSQL1 = "select count(U_LineNo) as u_linex from [@ST_STARGETD] where u_revno='" & txtkpi.Text & "' "
                cmd = New OleDbCommand(strSQL1, CServer)
                DRCEK = cmd.ExecuteReader
                If DRCEK.Read Then
                    seqnumber = DRCEK!u_linex
                ElseIf Not DRCEK.Read Then
                    seqnumber = 1
                End If


                For i As Integer = 0 To dg1.Rows.Count - 1

                    Process += 100 / dg1.Rows.Count
                    seqnumberx = seqnumber + i
                    code = code + i
                    strSQL = "insert into [@ST_STARGETD] (Code, Name, U_RevNo, U_LineNo, U_SBU, U_Dep, U_Brn, u_jan, u_feb,u_mar,u_apr,u_may,u_jun,u_jul,u_aug,u_sep,u_oct,u_nov,u_dec) " & _
                             " values ('" & code & "','" & code & "','" & txtkpi.Text & "'," & seqnumberx & ",'" & dg1.Rows(i).Cells(0).Value & "','" & dg1.Rows(i).Cells(1).Value & "','" & dg1.Rows(i).Cells(2).Value & "'," & dg1.Rows(i).Cells(3).Value & "," & dg1.Rows(i).Cells(4).Value & ", " & _
                             "" & dg1.Rows(i).Cells(5).Value & "," & dg1.Rows(i).Cells(6).Value & "," & dg1.Rows(i).Cells(7).Value & "," & dg1.Rows(i).Cells(8).Value & "," & dg1.Rows(i).Cells(9).Value & "," & dg1.Rows(i).Cells(10).Value & "," & dg1.Rows(i).Cells(11).Value & "," & dg1.Rows(i).Cells(12).Value & ", " & _
                             "" & dg1.Rows(i).Cells(13).Value & "," & dg1.Rows(i).Cells(14).Value & ")"
                    ExecQuery(strSQL)
                    bg1.ReportProgress(Process)
                Next
            ElseIf Trim(Microsoft.VisualBasic.Left(Label10.Text, 3)) = "KNV" Then

                For i As Integer = 0 To dg1.Rows.Count - 1
                    strSQL1 = "select code from [@st_kpiD] where U_SBU+U_Dep+U_Brn='" & dg1.Rows(i).Cells(0).Value & "'+'" & dg1.Rows(i).Cells(1).Value & "'+'" & dg1.Rows(i).Cells(2).Value & "' and u_revno='" & txtkpi.Text & "' and U_Sqm='0' order by code desc"
                    cmd = New OleDbCommand(strSQL1, CServer)
                    DRCEK = cmd.ExecuteReader
                    If DRCEK.Read Then
                        code = DRCEK!code
                    End If

                    Process += 100 / dg1.Rows.Count
                    strSQL = "update [@st_kpiD] set U_SBU='" & dg1.Rows(i).Cells(0).Value & "', U_Dep='" & dg1.Rows(i).Cells(1).Value & "', U_Brn='" & dg1.Rows(i).Cells(2).Value & "',U_Sqm='" & dg1.Rows(i).Cells(3).Value & "', U_Floor='" & dg1.Rows(i).Cells(4).Value & "' " & _
                        " where U_SBU+U_Dep+U_Brn='" & dg1.Rows(i).Cells(0).Value & "'+'" & dg1.Rows(i).Cells(1).Value & "'+'" & dg1.Rows(i).Cells(2).Value & "' and u_revno='" & txtkpi.Text & "' and code='" & DRCEK!code & "' "
                    ExecQuery(strSQL)
                    bg1.ReportProgress(Process)
                Next

            ElseIf Trim(Microsoft.VisualBasic.Left(Label10.Text, 3)) = "SNK" Then

                strSQL1 = "select  isnull(max(Code)+1,1) code from [@st_kpid]"
                cmd = New OleDbCommand(strSQL1, CServer)
                DRCEK = cmd.ExecuteReader
                If DRCEK.Read Then
                    code = DRCEK!code
                ElseIf Not DRCEK.Read Then
                    code = 1
                End If

                strSQL1 = "select count(U_LineNo) as u_linex from [@ST_STARGETD] where u_revno='" & txtkpi.Text & "' "
                cmd = New OleDbCommand(strSQL1, CServer)
                DRCEK = cmd.ExecuteReader
                If DRCEK.Read Then
                    seqnumber = DRCEK!u_linex
                ElseIf Not DRCEK.Read Then
                    seqnumber = 1
                End If

                For i As Integer = 0 To dg1.Rows.Count - 1
                    Process += 100 / dg1.Rows.Count
                    seqnumberx = seqnumber + i
                    code = code + i
                    strSQL = "insert into [@ST_KPID] (Code, Name, U_RevNo, U_LineNo, U_SBU, U_Dep, U_Brn, U_Sqm, U_Sqmgross, U_Floor) " & _
                             " values ('" & code & "','" & code & "','" & txtkpi.Text & "'," & seqnumberx & ",'" & dg1.Rows(i).Cells(0).Value & "','" & dg1.Rows(i).Cells(1).Value & "','" & dg1.Rows(i).Cells(2).Value & "'," & dg1.Rows(i).Cells(3).Value & ",0," & dg1.Rows(i).Cells(4).Value & ")"
                    ExecQuery(strSQL)
                    bg1.ReportProgress(Process)
                Next
            End If
        End If
    End Sub

    Private Sub bg1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bg1.ProgressChanged
        Me.ProgressBar1.Value = e.ProgressPercentage
        Me.ProgressBar1.Update()
    End Sub

    Private Sub bg1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bg1.RunWorkerCompleted
        MsgBox("Data telah selesai Ditransfer", MsgBoxStyle.Information)
        ProgressBar1.Value = 0
        ProgressBar1.Minimum = 0
        dg1.Rows.Clear() : dg1.Columns.Clear() : dg1.AllowUserToAddRows = True
        btnprocess.Enabled = True
        bersih()
    End Sub


End Class