Imports System.Data
Imports System.Data.OleDb

Public Class frmanalyzer

    Dim ds As DataSet
    Private Sub btnprocess_Click(sender As Object, e As EventArgs) Handles btnprocess.Click
        cm.Show(btnprocess, 0, btnprocess.Height)
    End Sub

    Private Sub functionparam()
        Dim ch, la, ld, md, hh, sc, kelipatan, kelipatan2, customsales1, salesall As String
        Dim senin, selasa, rabu, khamis, jumat, sabtu, minggu As String
        Dim member, nonmember, all As String
        'Dim sqlparam1, sqlparam2, sqlparam3, sqlparam4, sqlparam5 As String
        Dim sqlparam1, sqlparam2 As String
        Dim mkg, sms, smb As String

        'store
        If chks001.Checked = True Then mkg = m_ServerName3
        If chks002.Checked = True Then sms = m_ServerName4
        If chks003.Checked = True Then smb = m_ServerName5

        'SBU
        If chkchildrend.Checked = True Then ch = "CH" Else ch = ""
        If chkladies1.Checked = True Then la = "LA" Else la = ""
        If chkladies2.Checked = True Then ld = "LD" Else ld = ""
        If chkmens.Checked = True Then md = "MD" Else md = ""
        If chkhome.Checked = True Then hh = "HH" Else hh = ""
        If chksupportcenter.Checked = True Then sc = "SC" Else sc = ""

        'hari
        If chksenin.Checked = True Then senin = "monday" Else senin = ""
        If chkselasa.Checked = True Then selasa = "Thursday" Else selasa = ""
        If chkrabu.Checked = True Then rabu = "Wednesday" Else rabu = ""
        If chkkhamis.Checked = True Then khamis = "Thursday" Else khamis = ""
        If chkjumat.Checked = True Then jumat = "Friday" Else jumat = ""
        If chksabtu.Checked = True Then sabtu = "Saturday" Else sabtu = ""
        If chkminggu.Checked = True Then minggu = "Sunday" Else minggu = ""

        If rdsalescustom.Checked Then
            customsales1 = txtvalue1.Text
        Else
            customsales1 = ""
        End If
        If rdallsales.Checked Then
            salesall = ">"
        End If

        'kelipatan
        If chkkelipatan.Checked = True Then
            kelipatan = ",floor(sum(paid_amount) / " & txtvalue1.Text & ")"
            kelipatan2 = "HAVING (sum(paid_amount) >= " & txtvalue1.Text & "))"
        ElseIf chknonkelipatan.Checked = True Then
            kelipatan = ""
            kelipatan2 = ""
        ElseIf chkkelipatan.Checked = False Then
            kelipatan = ""
            kelipatan2 = ""
        End If

        'card
        If rdbuton.Checked Then member = " st.card_number <>'CM000-00000'" Else member = ""
        If rdbuton2.Checked Then nonmember = "st.card_number ='CM000-00000'" Else nonmember = ""
        If rdbuton3.Checked Then
            all = "st.card_number <>'CM000-00000' or st.card_number ='CM000-00000'"
        Else
            all = ""
        End If

        sqlparam1 = " in (" & ch & ", " & la & "," & md & "," & hh & "," & ld & "," & sc & ")"
        sqlparam2 = "{fn dayname(custtrans_date)} in (" & senin & ", " & selasa & "," & rabu & "," & khamis & "," & jumat & "," & sabtu & "," & minggu & ")"

        If rdbuton.Checked Then

            Dim sqlrun As String = "Select 'S001','Member',st.transaction_date, COUNT (distinct st.transaction_number) " & _
                                          " From [" & m_ServerName3 & "].[pos_server_history].dbo.sales_transactions As st, [" & m_ServerName3 & "].[pos_server_history].dbo.sales_transaction_details As sd, [" & m_ServerName3 & "].[pos_server].dbo.item_master As im " & _
                                           "Where st.transaction_number = sd.transaction_number And im.PLU = sd.PLU " & _
                                           "And  CONVERT(char(10), st.transaction_date,126) between '" & Format(dtpdate1.Value, "yyyy-MM-dd") & "' and '" & Format(dtpdate2.Value, "yyyy-MM-dd") & "' " & _
                                           " And status='00'  " & _
                                           " And st.Net_Price >='" & customsales1 & "'" & _
                                           " And " & member & " " & _
                                           " GROUP BY st.transaction_date "
            MsgBox(sqlrun)
        End If

        If rdbuton2.Checked Then
            Dim sqlrun As String = "Select 'S001','Non Member',st.transaction_date, COUNT (distinct st.transaction_number) " & _
                                       "From [" & m_ServerName3 & "].[pos_server_history].dbo.sales_transactions As st, [" & m_ServerName3 & "].[pos_server_history].dbo.sales_transaction_details As sd, [" & m_ServerName3 & "].[pos_server].dbo.item_master As im " & _
                                       "Where st.transaction_number = sd.transaction_number And im.PLU = sd.PLU " & _
                                       "And  CONVERT(char(10), st.transaction_date,126) between '" & Format(dtpdate1.Value, "yyyy-MM-dd") & "' and '" & Format(dtpdate2.Value, "yyyy-MM-dd") & "' " & _
                                       " And status='00' " & _
                                       " And st.Net_Price >='" & customsales1 & "'" & _
                                       " And " & nonmember & " " & _
                                       " GROUP BY st.transaction_date " & _
                                       " ORDER BY st.transaction_date "
            MsgBox(sqlrun)
        End If

        If rdbuton3.Checked Then
            Dim sqlrun As String = "Select 'S001',st.transaction_date, COUNT (distinct st.transaction_number) " & _
                                                "From [" & m_ServerName3 & "].[pos_server_history].dbo.sales_transactions As st, [" & m_ServerName3 & "].[pos_server_history].dbo.sales_transaction_details As sd, [" & m_ServerName3 & "].[pos_server].dbo.item_master As im " & _
                                                "Where st.transaction_number = sd.transaction_number And im.PLU = sd.PLU " & _
                                                "And  CONVERT(char(10), st.transaction_date,126) between '" & Format(dtpdate1.Value, "yyyy-MM-dd") & "' and '" & Format(dtpdate2.Value, "yyyy-MM-dd") & "' " & _
                                                " And status='00' " & _
                                                " And st.Net_Price >='" & customsales1 & "'" & _
                                                " And " & all & " " & _
                                                " GROUP BY st.transaction_date " & _
                                                " ORDER BY st.transaction_date "
            MsgBox(sqlrun)
        End If

        'ds = subgetSqldb(sqlrun)
        'If ds.Tables(0).Rows.Count > 0 Then
        '    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
        '        MsgBox(ds.Tables(0).Rows(i).Item("transaction_date"))
        '    Next
        'End If

    End Sub


    Private Sub frmanalyzer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If MsgBox("Yakin Keluar dari Aplikasi?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            End
        Else
            e.Cancel = 1
        End If
    End Sub



    Private Sub PerTanggalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PerTanggalToolStripMenuItem.Click
        Call functionparam()
    End Sub

    Sub defaults()

    End Sub

    Private Sub rdallsales_CheckedChanged(sender As Object, e As EventArgs) Handles rdallsales.CheckedChanged
        If rdallsales.Checked Then
            txtvalue1.Enabled = False
        End If
    End Sub

    Private Sub frmanalyzer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call defaults()
    End Sub

    Private Sub tm1_Tick(sender As Object, e As EventArgs) Handles tm1.Tick
        ts1.Text = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt")
        ts2.Text = "| " & m_ServerName
        ts3.Text = "| " & m_ServerName3
        ts4.Text = "| " & m_ServerName4
        ts5.Text = "| " & m_ServerName5
    End Sub

    Private Sub rdsalescustom_CheckedChanged(sender As Object, e As EventArgs) Handles rdsalescustom.CheckedChanged
        If rdsalescustom.Checked Then
            txtvalue1.Enabled = True
        End If
    End Sub
End Class