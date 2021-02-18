Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.Shared
Public Class frmcekvoucher
    Dim dsCek, dscek2, dscek3 As DataSet
    Dim strvalue, strvalue2, tempstore, store As String
    Private Sub txtscan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtscan.KeyDown
        If e.KeyCode = Keys.Enter Then
            cek()
        End If
    End Sub
    Sub setgrid()
        With dg1
            .RowsDefaultCellStyle.BackColor = Color.LightCyan
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Tomato

            .Columns.Add("KODE", "KODE")
            .Columns(0).Width = Me.Width / 9
            .Columns(0).ReadOnly = True

            .Columns.Add("NOMOR VOUCHER", "NOMOR VOUCHER")
            .Columns(1).Width = Me.Width / 5
            .Columns(1).ReadOnly = True

            .Columns.Add("USER", "USER")
            .Columns(2).Width = Me.Width / 8
            .Columns(2).ReadOnly = True

            .Columns.Add("TANGGAL SCAN", "TANGGAL SCAN")
            .Columns(3).Width = Me.Width / 5
            .Columns(3).ReadOnly = True

            .Columns.Add("TOKO", "TOKO")
            .Columns(4).Width = Me.Width / 4
            .Columns(4).ReadOnly = True

        End With

        With cboStore
            .Items.Clear()
            .Items.Add("S001")
            .Items.Add("S002")
            .Items.Add("S003")
            .SelectedIndex = 0
        End With

    End Sub


    Sub cek()
        If rbS001.Checked Then
            strvalue = "S001"
        ElseIf rbS002.Checked Then
            strvalue = "S002"
        ElseIf rbS003.Checked Then
            strvalue = "S003"
        ElseIf (rbS001.Checked = False Or rbS002.Checked = False Or rbS003.Checked = False) Then
            MsgBox("Pilih Dahulu untuk Tempat Redem Toko.", MsgBoxStyle.Information)
        End If

        strSQL = "select v_code,v_no,v_add_user from NewVoc where v_no='" & Microsoft.VisualBasic.Replace((txtscan.Text), "'", "") & "' "
        getSqldbOLE2(strSQL)
        If sqlDT.Rows.Count > 0 Then
            'dsCek = subgetSqldb("select v_no from voc where v_no='" & sqlDT.Rows(0)("v_no") & "' and CONVERT(char(10), v_add_date,126)='" & Format(dtp1.Value, "yyyy-MM-dd") & "' ")
            dsCek = subgetSqldb("select v_no from voc where v_no='" & sqlDT.Rows(0)("v_no") & "' ")
            If dsCek.Tables(0).Rows.Count = 0 Then
                strSQL1 = "insert voc(v_code,v_no,v_add_user,v_add_date,v_store)" & _
                                "values('" & sqlDT.Rows(0)("v_code") & "','" & sqlDT.Rows(0)("v_no") & "','" & ts5.Text & "','" & Format(dtp1.Value, "yyyy-MM-dd hh:mm:ss") & "','" & strvalue & "')"
                subgetSqldb(strSQL1)
                Call refreshgrid()
            Else
                MsgBox("Voucher Telah Discan Sebelumnya.", MsgBoxStyle.Critical)
            End If
        ElseIf sqlDT.Rows.Count = 0 Then
            MsgBox("voucher tidak ditemui!, Coba Scan Kembali!", MsgBoxStyle.Critical)
        End If
        tm2.Enabled = True
    End Sub
    Sub bersih()
        txtscan.Clear()
        txtscan.Focus()
    End Sub

    Private Sub tm2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tm2.Tick
        bersih()
        tm2.Enabled = False
    End Sub

    Sub refreshgrid()
        dg1.Rows.Clear()
        strSQL = "select v_code,v_no,v_add_user,v_add_date,v_store from voc where " & _
                 "CONVERT(char(10), v_add_date,126)>='" & Format(dtp2.Value, "yyyy-MM-dd") & "' " & _
                 "and CONVERT(char(10), v_add_date,126)<='" & Format(dtp3.Value, "yyyy-MM-dd") & "' and v_code in ('" & strvalue & "') order by v_add_date"
        getSqldbOLE(strSQL)
        If sqlDT.Rows.Count > 0 Then
            For Each rows As DataRow In sqlDT.Rows
                dg1.Rows.Add(rows(0).ToString, rows(1).ToString, rows(2).ToString, Format(rows(3), "yyyy-MM-dd hh:mm:ss").ToString)
            Next
        End If
    End Sub

    Private Sub tm1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tm1.Tick
        ts1.Text = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt")
        ts2.Text = "| " & m_ServerName
        ts3.Text = "| " & m_DBName
        ts4.Text = "| " & "ONLINE"
        'ts5.Text = " " & frmlogin.txtusername.Text
    End Sub

    Private Sub chk1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk1.CheckedChanged
        If chk1.Checked = False Then
            txtscan.Enabled = False
        Else
            txtscan.Enabled = True
        End If
    End Sub

    Private Sub frmcekvoucher_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'if MsgBox("Yakin Keluar dari Aplikasi?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
        'LoginMail.Show()
        'End If
    End Sub

    Private Sub frmcekvoucher_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ConnectServer()

        m_Sqlconn = "Provider=SQLOLEDB;" & _
                "Data Source=" & m_ServerNameOLE & _
                ";Initial Catalog=" & m_DBNameOLE & _
                ";User Id=" & m_UserNameOLE & _
                ";Password=" & m_PasswordOLE

        m_Sqlconn2 = "Provider=SQLOLEDB;" & _
            "Data Source=" & m_ServerNameOLE2 & _
            ";Initial Catalog=" & m_DBNameOLE2 & _
            ";User Id=" & m_UserNameOLE2 & _
            ";Password=" & m_PasswordOLE2


        m_sqlstoremkg = "Provider=SQLOLEDB;" & _
            "Data Source=" & m_ServerName3 & _
            ";Initial Catalog=" & m_DBName3 & _
            ";User Id=" & m_UserName3 & _
            ";Password=" & m_Password3


        m_sqlstoresms = "Provider=SQLOLEDB;" & _
            "Data Source=" & m_ServerName4 & _
            ";Initial Catalog=" & m_DBName4 & _
            ";User Id=" & m_UserName4 & _
            ";Password=" & m_Password4


        m_sqlstoresmb = "Provider=SQLOLEDB;" & _
            "Data Source=" & m_ServerName5 & _
            ";Initial Catalog=" & m_DBName5 & _
            ";User Id=" & m_UserName5 & _
            ";Password=" & m_Password5

        txtscan.Enabled = False
        Call setgrid()
        Call refreshgrid()
        lbltotal.Text = dg1.Rows.Count
        ts5.Text = UsrID
    End Sub

    Private Sub chk1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk1.Click
        txtscan.Focus()
    End Sub

    Private Sub btnreload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreload.Click
        dg1.Rows.Clear()

        If rb1.Checked Then
            strvalue = "A"
        ElseIf rb2.Checked Then
            strvalue = "B"
        ElseIf rb3.Checked Then
            strvalue = "C"
        ElseIf rb4.Checked Then
            strvalue = "A','B','C"
        ElseIf (rb1.Checked = False Or rb2.Checked = False Or rb3.Checked = False Or rb3.Checked = False) Then
            MsgBox("Pilih Dahulu untuk tipe Code Voucher.", MsgBoxStyle.Information)
        End If

        If cboStore.Text = "ALL" Then
            strSQL = "select v_code,v_no,v_add_user,v_add_date,v_store from voc where " & _
                     "CONVERT(char(10), v_add_date,126)>='" & Format(dtp2.Value, "yyyy-MM-dd") & "' and CONVERT(char(10), v_add_date,126)<='" & Format(dtp3.Value, "yyyy-MM-dd") & "' " & _
                     "and v_code in ('" & strvalue & "') and v_store in ('S001','S002','S003') order by v_add_date"
            getSqldbOLE(strSQL)
            If sqlDT.Rows.Count > 0 Then
                For Each rows As DataRow In sqlDT.Rows
                    dg1.Rows.Add(rows(0).ToString, rows(1).ToString, rows(2).ToString, Format(rows(3), "yyyy-MM-dd hh:mm:ss").ToString, rows(4).ToString)
                Next
            Else
                MsgBox("Data Tidak Ditemukan.", MsgBoxStyle.Information)
            End If
            lbltotal.Text = dg1.Rows.Count
        Else
            strSQL = "select v_code,v_no,v_add_user,v_add_date,v_store from voc where " & _
                     "CONVERT(char(10), v_add_date,126)>='" & Format(dtp2.Value, "yyyy-MM-dd") & "' and CONVERT(char(10), v_add_date,126)<='" & Format(dtp3.Value, "yyyy-MM-dd") & "' " & _
                     "and v_code in ('" & strvalue & "') and v_store='" & cboStore.Text & "' order by v_add_date"
            getSqldbOLE(strSQL)
            If sqlDT.Rows.Count > 0 Then
                For Each rows As DataRow In sqlDT.Rows
                    dg1.Rows.Add(rows(0).ToString, rows(1).ToString, rows(2).ToString, Format(rows(3), "yyyy-MM-dd hh:mm:ss").ToString, rows(4).ToString)
                Next
            Else
                MsgBox("Data Tidak Ditemukan.", MsgBoxStyle.Information)
            End If
            lbltotal.Text = dg1.Rows.Count
        End If
        
    End Sub

    Private Sub btnreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreport.Click
        cm1.Show(btnreport, 0, btnreport.Height)
    End Sub

    Private Sub ByDetailToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ByDetailToolStripMenuItem1.Click

        strSQL = "IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[tmp_sp_voucherreport]')" & _
                 "AND OBJECTPROPERTY(id, N'IsUserTable') = 1)" & _
                 "DROP TABLE [dbo].[tmp_sp_voucherreport]"
        getSqldbOLE(strSQL)

        If rb1.Checked Then
            strvalue = "A"
        ElseIf rb2.Checked Then
            strvalue = "B"
        ElseIf rb3.Checked Then
            strvalue = "C"
        ElseIf rb4.Checked Then
            strvalue = "A','B','C"
        Else
            strvalue = "Null"
        End If
        Dim ds As New DataSet

        strSQL1 = "select a.V_CODE,a.V_NO,b.V_AMT,b.v_Desc,b.v_sell,a.V_ADD_USER,a.V_ADD_DATE,a.v_store,'" & Format(dtp2.Value, "yyyy-MM-dd") & "' as startdate,'" & Format(dtp3.Value, "yyyy-MM-dd") & "' as enddate into tmp_sp_voucherreport from Voc a" & _
                  " inner join [Voucher].dbo.NewVoc b on a.V_NO=b.v_no" & _
                  " where a.V_STORE in ('" & cboStore.Text & "') and a.V_CODE in ('" & strvalue & "') and CONVERT(char(10), a.v_add_date,126)>='" & Format(dtp2.Value, "yyyy-MM-dd") & "' " & _
                  " and CONVERT(char(10), a.v_add_date,126)<='" & Format(dtp3.Value, "yyyy-MM-dd") & "'"
        subgetSqldb(strSQL1)


        ds = subgetSqldb("Select * from tmp_sp_voucherreport")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim rpd As New ReportDocument
            rpd = New voucherreport
            rpd.SetDataSource(ds.Tables(0))
            SetDBLogonForReport(rpd)
            frmreport.crv1.ReportSource = rpd
            frmreport.ShowDialog()
        Else
            MsgBox("Data tidak ditemukan.", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub ByDetailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ByDetailToolStripMenuItem.Click

        strSQL = "IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[tmp_voucherreport_cntcomparedtl]')" & _
                 "AND OBJECTPROPERTY(id, N'IsUserTable') = 1)" & _
                 "DROP TABLE [dbo].[tmp_voucherreport_cntcomparedtl]"
        getSqldbOLE(strSQL)

        If rb1.Checked Then
            strvalue = "A"
        ElseIf rb2.Checked Then
            strvalue = "B"
        ElseIf rb3.Checked Then
            strvalue = "C"
        ElseIf rb4.Checked Then
            strvalue = "A','B','C"
        Else
            strvalue = "Null"
        End If

        If cboStore.Text = "S001" Then
            store = m_ServerName3
        ElseIf cboStore.Text = "S002" Then
            store = m_ServerName4
        ElseIf cboStore.Text = "S003" Then
            store = m_ServerName5
        End If
        Dim ds As New DataSet
        strSQL1 = " select a.v_no as novocscan,a.v_store as scanstore,c.credit_card_no as novocpaid,left(c.transaction_number,4) as toko,substring(c.transaction_number,5,3) as register," & _
                    " '" & Format(dtp2.Value, "yyyy-MM-dd") & "' as startdate,'" & Format(dtp3.Value, "yyyy-MM-dd") & "' as enddate into tmp_voucherreport_cntcomparedtl from Voc a " & _
                    " left join [" & store & "].[pos_server_history].dbo.Paid c on a.V_NO=c.credit_card_no " & _
                    " where a.V_CODE in ('" & strvalue & "') and " & _
                    " a.V_STORE in ('" & cboStore.Text & "') " & _
                    " and CONVERT(char(10), a.v_add_date,126)>='" & Format(dtp2.Value, "yyyy-MM-dd") & "'" & _
                    " and CONVERT(char(10), a.v_add_date,126)<='" & Format(dtp3.Value, "yyyy-MM-dd") & "'"
        subgetSqldb(strSQL1)

        ds = subgetSqldb("Select * from tmp_voucherreport_cntcomparedtl")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim rpd As New ReportDocument
            rpd = New vocreportcomparedtl
            rpd.SetDataSource(ds.Tables(0))
            SetDBLogonForReport(rpd)
            frmreport.crv1.ReportSource = rpd
            frmreport.ShowDialog()
        Else
            MsgBox("Data tidak ditemukan.", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub ByDetailRedeemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ByDetailRedeemToolStripMenuItem.Click

        strSQL = "IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[tmp_voucherreport_cntcomparedtl_v2]')" & _
                 "AND OBJECTPROPERTY(id, N'IsUserTable') = 1)" & _
                 "DROP TABLE [dbo].[tmp_voucherreport_cntcomparedtl_v2]"
        getSqldbOLE(strSQL)

        If rb1.Checked Then
            strvalue = "A"
        ElseIf rb2.Checked Then
            strvalue = "B"
        ElseIf rb3.Checked Then
            strvalue = "C"
        ElseIf rb4.Checked Then
            strvalue = "A','B','C"
        Else
            strvalue = "Null"
        End If


        If cboStore.Text = "S001" Then
            store = m_ServerName3
        ElseIf cboStore.Text = "S002" Then
            store = m_ServerName4
        ElseIf cboStore.Text = "S003" Then
            store = m_ServerName5
        End If

        Dim ds As New DataSet

        strSQL1 = "select a.V_CODE,a.V_NO,c.credit_card_no,b.v_Desc,b.v_sell,a.V_ADD_USER,a.V_ADD_DATE,a.V_STORE, " & _
                  "'" & Format(dtp2.Value, "yyyy-MM-dd") & "' as startdate,'" & Format(dtp3.Value, "yyyy-MM-dd") & "' as enddate into tmp_voucherreport_cntcomparedtl_v2 from Voc a" & _
                  " inner join [" & store & "].[pos_server_history].dbo.NewVoc b on a.V_NO=b.v_no" & _
                  " left join [" & store & "].[pos_server_history].dbo.Paid c on a.V_NO=c.credit_card_no" & _
                  " where b.v_flag='R' and a.V_CODE in ('" & strvalue & "') " & _
                  " and a.V_STORE in ('" & cboStore.Text & "') and CONVERT(char(10), a.v_add_date,126)>='" & Format(dtp2.Value, "yyyy-MM-dd") & "' " & _
                  " and CONVERT(char(10), a.v_add_date,126)<='" & Format(dtp3.Value, "yyyy-MM-dd") & "' and a.V_NO=c.credit_card_no"
        subgetSqldb(strSQL1)

        ds = subgetSqldb("Select * from tmp_voucherreport_cntcomparedtl_v2")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim rpd As New ReportDocument
            rpd = New vocreportcompare_v2
            rpd.SetDataSource(ds.Tables(0))
            SetDBLogonForReport(rpd)
            frmreport.crv1.ReportSource = rpd
            frmreport.ShowDialog()
        Else
            MsgBox("Data tidak ditemukan.", MsgBoxStyle.Information)
        End If

    End Sub


    Private Sub ByTotalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ByTotalToolStripMenuItem.Click

        strSQL = "IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[tmp_voucherreport_total]')" & _
                 "AND OBJECTPROPERTY(id, N'IsUserTable') = 1)" & _
                 "DROP TABLE [dbo].[tmp_voucherreport_total]"
        getSqldbOLE(strSQL)

        If rb1.Checked Then
            strvalue = "A"
        ElseIf rb2.Checked Then
            strvalue = "B"
        ElseIf rb3.Checked Then
            strvalue = "C"
        ElseIf rb4.Checked Then
            strvalue = "A','B','C"
        Else
            strvalue = "Null"
        End If


        If cboStore.Text = "S001" Then
            store = m_ServerName3
        ElseIf cboStore.Text = "S002" Then
            store = m_ServerName4
        ElseIf cboStore.Text = "S003" Then
            store = m_ServerName5
        End If

        Dim ds As New DataSet

        strSQL1 = "select '" & cboStore.Text & "' as toko,'" & Format(dtp2.Value, "yyyy-MM-dd") & "' as startdate,'" & Format(dtp3.Value, "yyyy-MM-dd") & "' as enddate, " & _
                  "(select count(*) from Voc where CONVERT(char(10), v_add_date,126)>='" & Format(dtp2.Value, "yyyy-MM-dd") & "' and CONVERT(char(10), v_add_date,126)<='" & Format(dtp3.Value, "yyyy-MM-dd") & "' and V_STORE='" & cboStore.Text & "') as totalscan," & _
                  "(select count(b.payment_types) from [" & store & "].[pos_server_history].dbo.Sales_Transactions a " & _
                  "inner join [" & store & "].[pos_server_history].dbo.Paid b on a.Transaction_Number=b.Transaction_Number " & _
                  "where a.Status='00' and b.Payment_Types='8' and CONVERT(char(10), Transaction_Date,126)>='" & Format(dtp2.Value, "yyyy-MM-dd") & "' and CONVERT(char(10), Transaction_Date,126)<='" & Format(dtp3.Value, "yyyy-MM-dd") & "') as totalpaid into tmp_voucherreport_total"
        'Dbg(strSQL1)
        subgetSqldb(strSQL1)
        ds = subgetSqldb("Select * from tmp_voucherreport_total")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim rpd As New ReportDocument
            rpd = New totaldetail
            rpd.SetDataSource(ds.Tables(0))
            SetDBLogonForReport(rpd)
            frmreport.crv1.ReportSource = rpd
            frmreport.ShowDialog()
        Else
            MsgBox("Data tidak ditemukan.", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub ByPaidToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ByPaidToolStripMenuItem.Click
        strSQL = "IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[tmp_voucherreport_cntcomparedtl_v3]')" & _
                 "AND OBJECTPROPERTY(id, N'IsUserTable') = 1)" & _
                 "DROP TABLE [dbo].[tmp_voucherreport_cntcomparedtl_v3]"
        getSqldbOLE(strSQL)

        If rb1.Checked Then
            strvalue = "A"
        ElseIf rb2.Checked Then
            strvalue = "B"
        ElseIf rb3.Checked Then
            strvalue = "C"
        ElseIf rb4.Checked Then
            strvalue = "A','B','C"
        Else
            strvalue = "Null"
        End If


        If cboStore.Text = "S001" Then
            store = m_ServerName3
        ElseIf cboStore.Text = "S002" Then
            store = m_ServerName4
        ElseIf cboStore.Text = "S003" Then
            store = m_ServerName5
        End If

        Dim ds As New DataSet

        strSQL1 = "select '" & cboStore.Text & "' as toko,'" & Format(dtp2.Value, "yyyy-MM-dd") & "' as startdate,'" & Format(dtp3.Value, "yyyy-MM-dd") & "' as enddate, " & _
                  "a.v_no as [scan voucher],LTRIM(RTRIM(b.credit_card_no)) as [payment voucher] into tmp_voucherreport_cntcomparedtl_v3 from voc a" & _
                  " left join [" & store & "].[pos_server_history].dbo.Paid b on LTRIM(RTRIM(b.credit_card_no))=a.v_no" & _
                  " where convert(char(10),a.v_add_date,126)>='" & Format(dtp2.Value, "yyyy-MM-dd") & "' and convert(char(10),a.v_add_date,126)<='" & Format(dtp3.Value, "yyyy-MM-dd") & "' " & _
                  " and a.V_STORE in ('" & cboStore.Text & "') and b.payment_types='8'" & _
                  " order by b.credit_card_no"
        subgetSqldb(strSQL1)

        ds = subgetSqldb("Select * from tmp_voucherreport_cntcomparedtl_v3")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim rpd As New ReportDocument
            rpd = New vocreportcompare_v3
            rpd.SetDataSource(ds.Tables(0))
            SetDBLogonForReport(rpd)
            frmreport.crv1.ReportSource = rpd
            frmreport.ShowDialog()
        Else
            MsgBox("Data tidak ditemukan.", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub CheckToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckToolStripMenuItem.Click
        strSQL = "IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[tmp_check1]')" & _
                "AND OBJECTPROPERTY(id, N'IsUserTable') = 1)" & _
                "DROP TABLE [dbo].[tmp_check1]"
        getSqldbOLE(strSQL)

        strSQL = "IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[tmp_check2]')" & _
                        "AND OBJECTPROPERTY(id, N'IsUserTable') = 1)" & _
                        "DROP TABLE [dbo].[tmp_check2]"
        getSqldbOLE(strSQL)

        strSQL = "truncate table tmp_checkresult"
        getSqldbOLE(strSQL)

        If rb1.Checked Then
            strvalue = "A"
        ElseIf rb2.Checked Then
            strvalue = "B"
        ElseIf rb3.Checked Then
            strvalue = "C"
        ElseIf rb4.Checked Then
            strvalue = "A','B','C"
        Else
            strvalue = "Null"
        End If


        If cboStore.Text = "S001" Then
            store = m_ServerName3
        ElseIf cboStore.Text = "S002" Then
            store = m_ServerName4
        ElseIf cboStore.Text = "S003" Then
            store = m_ServerName5
        End If

        strSQL1 = "select '" & cboStore.Text & "' as toko,'" & Format(dtp2.Value, "yyyy-MM-dd") & "' as startdate,'" & Format(dtp3.Value, "yyyy-MM-dd") & "' as enddate,credit_card_no into tmp_check1 from [" & store & "].[pos_server_history].dbo.paid where LTRIM(RTRIM(credit_card_no)) not in (" & _
                  "select v_no from voc where convert(char(10),V_ADD_DATE,126)>='" & Format(dtp2.Value, "yyyy-MM-dd") & "' and convert(char(10),V_ADD_DATE,126)<='" & Format(dtp3.Value, "yyyy-MM-dd") & "' and v_store in ('" & cboStore.Text & "')) " & _
                  "and transaction_number in ( " & _
                  "select transaction_number from [" & store & "].[pos_server_history].dbo.sales_Transactions where " & _
                  "convert(char(10),transaction_Date,126)>='" & Format(dtp2.Value, "yyyy-MM-dd") & "' and convert(char(10),transaction_Date,126) <='" & Format(dtp3.Value, "yyyy-MM-dd") & "') and payment_types='8'"
        'Dbg(strSQL1)
        subgetSqldb(strSQL1)
       
        StrSQL2 = "select '" & cboStore.Text & "' as toko,'" & Format(dtp2.Value, "yyyy-MM-dd") & "' as startdate,'" & Format(dtp3.Value, "yyyy-MM-dd") & "' as enddate,v_no into tmp_check2 from voc where v_no not in ( " & _
                  "select credit_card_no from [" & store & "].[pos_server_history].dbo.paid " & _
                  "where transaction_number in ( " & _
                  "select transaction_number from [" & store & "].[pos_server_history].dbo.sales_transactions where " & _
                  "convert(char(10),transaction_Date,126)>='" & Format(dtp2.Value, "yyyy-MM-dd") & "' and convert(char(10),transaction_Date,126)<='" & Format(dtp3.Value, "yyyy-MM-dd") & "') and payment_types='8') and " & _
                  "convert(char(10),V_ADD_DATE,126)>='" & Format(dtp2.Value, "yyyy-MM-dd") & "' and convert(char(10),V_ADD_DATE,126)<='" & Format(dtp3.Value, "yyyy-MM-dd") & "' and v_store in ('" & cboStore.Text & "')"
        'Dbg(StrSQL2)
        subgetSqldb(StrSQL2)

        strSQL = "select * from tmp_check1"
        dsCek = subgetSqldb(strSQL)
        If dsCek.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To dsCek.Tables(0).Rows.Count - 1
                strSQL1 = "insert into tmp_checkresult(idno,toko_a,startdate_a,enddate_a,paidvoucher) " & _
                                 "values('" & i & "','" & dsCek.Tables(0).Rows(i).Item("toko") & "','" & dsCek.Tables(0).Rows(i).Item("startdate") & "','" & dsCek.Tables(0).Rows(i).Item("enddate") & "','" & dsCek.Tables(0).Rows(i).Item("credit_card_no") & "')"
                getSqldbOLE(strSQL1)
            Next
        End If

        strSQL1 = "select * from tmp_check2"
        dscek2 = subgetSqldb(strSQL1)
        If dscek2.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To dscek2.Tables(0).Rows.Count - 1
                strSQL = "update tmp_checkresult set toko_b='" & dscek2.Tables(0).Rows(i).Item("toko") & "'," & _
                         "startdate_b='" & dscek2.Tables(0).Rows(i).Item("startdate") & "',enddate_b='" & dscek2.Tables(0).Rows(i).Item("enddate") & "',scanvoucher='" & dscek2.Tables(0).Rows(i).Item("v_no") & "' where idno='" & i & "' "
                getSqldbOLE(strSQL)
            Next
        End If

        dscek3 = subgetSqldb("Select * from tmp_checkresult")
        If dscek3.Tables(0).Rows.Count > 0 Then
            Dim rpd As New ReportDocument
            rpd = New vocreportcheck
            rpd.SetDataSource(dscek3.Tables(0))
            SetDBLogonForReport(rpd)
            frmreport.crv1.ReportSource = rpd
            frmreport.ShowDialog()
        Else
            MsgBox("Data tidak ditemukan.", MsgBoxStyle.Information)
        End If


    End Sub


    Private Sub SetDBLogonForReport(ByVal myReportDocument As ReportDocument)
        Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()
        myConnectionInfo.DatabaseName = m_DBName
        myConnectionInfo.UserID = m_UserName
        myConnectionInfo.Password = m_Password
        myConnectionInfo.ServerName = m_ServerName
        myConnectionInfo.IntegratedSecurity = "false"
        Dim myTables As Tables = myReportDocument.Database.Tables
        For Each myTable As CrystalDecisions.CrystalReports.Engine.Table In myTables
            Dim myTableLogonInfo As TableLogOnInfo = myTable.LogOnInfo
            myTableLogonInfo.ConnectionInfo = myConnectionInfo
            myTable.ApplyLogOnInfo(myTableLogonInfo)
        Next
    End Sub


    Private Sub txtscan_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtscan.TextChanged

    End Sub

    Private Sub RepairScanDateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepairScanDateToolStripMenuItem.Click
        'Cursor = Cursors.WaitCursor
        strCon_Global = StrConSUP()
        Dim codevoucher As String
        If rb1.Checked Then
            codevoucher = " ( 'A' )"
        ElseIf rb2.Checked Then
            codevoucher = " ( 'B' )"
        ElseIf rb3.Checked Then
            codevoucher = " ( 'C' )"
        ElseIf rb4.Checked Then
            codevoucher = "( 'A','B','C' ) "
        Else
            MsgError("Belum Pilih Code Voucher" & vbCrLf & _
                     "Pilih Dahulu A / B / C / ALL")
            Exit Sub
        End If


        If cboStore.Text = "S001" Then
            store = m_ServerName3
        ElseIf cboStore.Text = "S002" Then
            store = m_ServerName4
        ElseIf cboStore.Text = "S003" Then
            store = m_ServerName5
        End If
        If MsgConfirm("Anda Ingin Perbaiki Salah Scan Untuk " & vbCrLf & _
                      "Periode : " & _
                      Format(dtp2.Value, "dd MMM yyyy") & " s/d " & _
                      Format(dtp3.Value, "dd MMM yyyy") & vbCrLf & _
                      "Code Voucher : " & codevoucher & vbCrLf & _
                      "Store : " & cboStore.Text & " ?") <> vbYes Then Exit Sub

        strSQL = "IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[tmp_check2]')" & _
                        "AND OBJECTPROPERTY(id, N'IsUserTable') = 1)" & _
                        "DROP TABLE [dbo].[tmp_check2]"
        ExecQuery(strSQL, StrConSUP)

        StrSQL2 = "select '" & cboStore.Text & "' as toko, " & vbCrLf & _
                  "'" & Format(dtp2.Value, "yyyy-MM-dd") & "' as startdate, " & vbCrLf & _
                  "'" & Format(dtp3.Value, "yyyy-MM-dd") & "' as enddate, v_no " & vbCrLf & _
                  "into tmp_check2 " & vbCrLf & _
                  "from voc where v_no not in " & vbCrLf & _
                  "  ( " & vbCrLf & _
                  "     select credit_card_no " & vbCrLf & _
                  "     from [" & store & "].[pos_server_history].dbo.paid " & vbCrLf & _
                  "     where transaction_number in " & vbCrLf & _
                  "        ( " & vbCrLf & _
                  "             select transaction_number " & vbCrLf & _
                  "             from [" & store & "].[pos_server_history].dbo.sales_transactions " & vbCrLf & _
                  "             where convert(char(10),transaction_Date,126)>='" & Format(dtp2.Value, "yyyy-MM-dd") & "' " & vbCrLf & _
                  "             and convert(char(10),transaction_Date,126)<='" & Format(dtp3.Value, "yyyy-MM-dd") & "' " & vbCrLf & _
                  "        ) " & vbCrLf & _
                  "  and payment_types='8' " & vbCrLf & _
                  "  ) " & vbCrLf & _
                  "and convert(char(10),V_ADD_DATE,126)>='" & Format(dtp2.Value, "yyyy-MM-dd") & "' " & vbCrLf & _
                  "and convert(char(10),V_ADD_DATE,126)<='" & Format(dtp3.Value, "yyyy-MM-dd") & "' " & vbCrLf & _
                  "and v_store in ('" & cboStore.Text & "')"
        'Dbg(StrSQL2)
        ExecQuery(StrSQL2, StrConSUP)
        Dim dsc As DataSet
        dsc = Query("select * from tmp_check2", StrConSUP)
        If dsc.Tables(0).Rows.Count <= 0 Then
            MsgError("Tidak Ada Data Scan Yang Harus Diperbaiki")
            clearDataSet(dsc)
            Exit Sub
        End If

        If MsgConfirm("Data Yang Akan Diperbaiki Sebanyak " & dsc.Tables(0).Rows.Count & " Data" & vbCrLf & _
                      "Ingin Tetap Diperbaiki ?") <> vbYes Then
            clearDataSet(dsc)
            Exit Sub
        End If
        
        ExecQuery("delete from voc_error where v_no in (select v_no from tmp_check2) ", StrConSUP)
        'MsgOK("1")
        strSQL = "insert into voc_error (v_code, v_no, v_add_user, v_add_date, v_store, redeem_store) " & vbCrLf & _
                 "( " & vbCrLf & _
                 "   select *, 'xxx' from voc where " & vbCrLf & _
                 "   v_code in " & codevoucher & " and v_store='" & cboStore.Text & "' " & vbCrLf & _
                 "   and convert(varchar(10), v_add_date, 20) >= '" & dtsql(dtp2.Value) & "' " & vbCrLf & _
                 "   and convert(varchar(10), v_add_date, 20) <= '" & dtsql(dtp3.Value) & "' " & vbCrLf & _
                 "   and v_no not in " & vbCrLf & _
                 "   ( " & vbCrLf & _
                 "      Select credit_card_no " & vbCrLf & _
                 "      from [" & store & "].[pos_server_history].dbo.paid " & vbCrLf & _
                 "      where transaction_number in " & vbCrLf & _
                 "      ( " & vbCrLf & _
                 "          select transaction_number " & vbCrLf & _
                 "          from [" & store & "].[pos_server_history].dbo.sales_transactions " & vbCrLf & _
                 "          where convert(char(10),transaction_Date,126)>='" & dtsql(dtp2.Value) & "' " & vbCrLf & _
                 "          and convert(char(10),transaction_Date,126)<='" & dtsql(dtp3.Value) & "' " & vbCrLf & _
                 "      ) " & vbCrLf & _
                 "      and payment_types='8' " & vbCrLf & _
                 "   ) " & vbCrLf & _
                 ")"
        ExecQuery(strSQL, StrConSUP)
        'MsgOK("2")
        strSQL = "update a " & vbCrLf & _
                 "set a.redeem_date=b.redeem_date, a.redeem_store=b.redeem_store " & vbCrLf & _
                 "from ( select * from voc_error where redeem_store='xxx' ) a " & vbCrLf & _
                 "inner join " & vbCrLf & _
                 "( " & vbCrLf & _
                 "	select b.credit_card_no as v_no, a.transaction_date as redeem_date," & vbCrLf & _
                 "	substring(b.transaction_number, 1, 4) as redeem_store " & vbCrLf & _
                 "	from [" & store & "].[pos_server_history].dbo.paid b " & vbCrLf & _
                 "	inner join [" & store & "].[pos_server_history].dbo.sales_transactions a " & vbCrLf & _
                 "		on a.transaction_number=b.transaction_number " & vbCrLf & _
                 "	where b.credit_card_no in ( select v_no from voc_error where redeem_store='xxx' ) " & vbCrLf & _
                 ") b on a.v_no=b.v_no " & vbCrLf & _
                 "where a.v_no=b.v_no " & vbCrLf & _
                 ""
        ExecQuery(strSQL, StrConSUP)
        'MsgOK("3")
        strSQL = "update a " & vbCrLf & _
                 "set a.v_add_date = b.redeem_date, a.v_store=b.redeem_store " & vbCrLf & _
                 "from ( select * from voc where v_no in (select v_no from voc_error where isrepair=0) ) a " & vbCrLf & _
                 "inner join ( select * from voc_error where isrepair=0 ) b on a.v_no=b.v_no " & vbCrLf & _
                 "where a.v_no=b.v_no " & vbCrLf & _
                 ""
        ExecQuery(strSQL, StrConSUP)
        'MsgOK("4")
        strSQL = "update voc_error " & vbCrLf & _
                 "set isrepair=1 where isrepair=0 " & vbCrLf & _
                 ""
        ExecQuery(strSQL, StrConSUP)
        MsgOK("Success")


    End Sub
End Class
