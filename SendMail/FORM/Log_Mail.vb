Imports System.Data.SqlClient
Imports System.Globalization
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.Shared
Imports System.IO
Imports STAR_Enterprise
Imports System
Imports System.Net
Imports System.Net.Mail
'Imports System.Web.Mail
Imports System.Data
Imports System.Threading
Imports System.Runtime.InteropServices
Public Class Log_Mail
    Dim ds, dsfromvendor, dscek, dsLoopLv As New DataSet
    Dim cryRpt As New ReportDocument
    Dim Fload As Boolean = False
    Dim Cnt As Integer = 0
    Dim lp As Integer = 0
    Dim a As Integer
    Dim siteV, SiteCode As String

    Private Sub Log_Mail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m_Sqlconn = "Data Source=" & m_ServerName & ";" & "Initial Catalog=" & m_DBName & ";" & "User ID=" & m_UserName & ";" & "Password=" & m_Password & ";"
        m_Sqlconn2 = "Data Source=" & m_ServerName2 & ";" & "Initial Catalog=" & m_DBName2 & ";" & "User ID=" & m_UserName2 & ";" & "Password=" & m_Password2 & ";"
        Me.Show()
        dscek = getSqldb("select name as Code,Cast(descriptio as varchar(50))as Description  from OHTM where name in('" & SbuCode & "') Order by name")
        If dscek.Tables(0).Rows.Count > 1 Then
            a = 0
        Else
            a = 1
        End If
        If Sec_Lev = 0 Then
            cmb(ComboBox4, "select name as Code,Cast(descriptio as varchar(50))as Description  from OHTM  Order by name", "Code", "Description", 0)
        Else
            cmb(ComboBox4, "select name as Code,Cast(descriptio as varchar(50))as Description  from OHTM where name in('" & SbuCode & "') Order by name", "Code", "Description", a)
        End If
        ComboBox1.Items.Add("Vendor")
        ComboBox1.Items.Add("Date")
        If Sec_Lev = 0 Then
            ComboBox1.Items.Add("SBU")
        End If
        dscek.Clear()
        dscek = getSqldb("select WhsName as WhsCode, WhsName + ' - ' +WhsCode as WhsName from OWHS Where WhsCode <>'01' and WhsCode not in ('DC01','HO01') Order by WhsName")
        If dscek.Tables(0).Rows.Count > 1 Then
            a = 0
        Else
            a = 1
        End If

        'cmb(ComboBox3, "select WhsName as Code, WhsName + ' - ' +WhsCode as WhsName  from OWHS Where WhsCode <>'01' and WhsCode not in ('DC01','HO01') Order by WhsCode", "Code", "WhsName", a)
        'cmb(ComboBox1, "select DISTINCT  replace(TH4.CardName,'''','''''')as CardCode,TH4.CardName  +' - ' + TH4.CardCode as CardName from OCRD TH4 Inner Join OITM TH2 On TH4.CardCode = TH2.CardCode inner join OITW TH5 On TH5.ItemCode = TH2.ItemCode  Where Left(TH5.U_PROFIT_CTR,2) = '" & ComboBox4.SelectedValue & "'", "CardCode", "CardName")
        'cmb(ComboBox2, "select DISTINCT  replace(TH4.CardName,'''','''''')as CardCode,TH4.CardName  +' - ' + TH4.CardCode as CardName from OCRD TH4 Inner Join OITM TH2 On TH4.CardCode = TH2.CardCode inner join OITW TH5 On TH5.ItemCode = TH2.ItemCode  Where Left(TH5.U_PROFIT_CTR,2) = '" & ComboBox4.SelectedValue & "'", "CardCode", "CardName")
        Fload = True
        SetLv2()
        DateTimePicker1.Value = Format(CDate(DateTimePicker1.Value.Month & "/1/" & DateTimePicker1.Value.Year), "dd  MMM  yyyy")
        CheckForIllegalCrossThreadCalls = False
        ComboBox1.SelectedIndex = 0

        showlv(ComboBox1.SelectedIndex)
    End Sub

    Sub SetLv2()
        ListView1.Columns.Add("Vendor Name", 220, HorizontalAlignment.Center)
        ListView1.Columns.Add("Contact Name", 170, HorizontalAlignment.Left)
        ListView1.Columns.Add("Email", 200, HorizontalAlignment.Left)
        ListView1.Columns.Add("Periode", 170, HorizontalAlignment.Left)
        ListView1.Columns.Add("Store", 140, HorizontalAlignment.Left)
        ListView1.Columns.Add("Status", 100, HorizontalAlignment.Left)
        ListView1.Columns.Add("Send By", 80, HorizontalAlignment.Left)
        ListView1.Columns.Add("Send Date", 180, HorizontalAlignment.Left)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        showlv(ComboBox1.SelectedIndex)
    End Sub

    Sub showlv(ByVal sl As Integer)
        Try
            Dim dsv As New DataSet
            Dim pil, cmbv, usrv As String
            ListView1.Items.Clear()
            If sl = 0 Then
                pil = " Order By VendorName"
            ElseIf sl = 1 Then
                pil = " Order By SendDate"
            Else
                pil = " Order By SBU"
            End If
            If ComboBox4.SelectedValue = "*" Then
                cmbv = " "
            Else
                cmbv = " And SBU = '" & ComboBox4.SelectedValue & "' "
            End If
            If Sec_Lev = 0 Then
                usrv = " "
            Else
                usrv = "  And SendBy = '" & UsrID & "' "
            End If
            dsv = getSqldb2("select VendorName,ContactName,Email,Periode,Status,SendBy,SendDate,FileName from LogMail where SendDate Between '" & DateTimePicker1.Value.Date & "' And '" & DateTimePicker2.Value.Date.AddDays(1) & "' " & usrv & " " & cmbv & "  " & pil & "")
            If dsv.Tables(0).Rows.Count > 0 Then

                For Each ro As DataRow In dsv.Tables(0).Rows
                    Dim str(7) As String
                    Dim itm As ListViewItem
                    str(0) = ro(0).ToString.Trim
                    str(1) = ro(1).ToString.Trim
                    str(2) = ro(2).ToString.Trim
                    str(3) = ro(3).ToString.Trim
                    If Microsoft.VisualBasic.Left(ro(7).ToString.Trim, 4) = "S001" Then
                        str(4) = "SM KELAPA GADING"
                    ElseIf Microsoft.VisualBasic.Left(ro(7).ToString.Trim, 4) = "S002" Then
                        str(4) = "SM SERPONG"
                    ElseIf Microsoft.VisualBasic.Left(ro(7).ToString.Trim, 4) = "S003" Then
                        str(4) = "SM BEKASI"
                    Else
                        str(4) = ""
                    End If
                    'str(4) = Microsoft.VisualBasic.Left(ro(7).ToString.Trim, 4)
                    If ro(4).ToString.Trim = 1 Then
                        str(5) = "Success"
                    Else
                        str(5) = "Failed"
                    End If
                    str(6) = ro(5).ToString.Trim
                    str(7) = ro(6).ToString.Trim
                    itm = New ListViewItem(str)
                    ListView1.Items.Add(itm)
                Next

                For Each itm As ListViewItem In ListView1.Items
                    If itm.SubItems(5).Text = "Failed" Then
                        itm.ForeColor = System.Drawing.Color.DarkRed
                        itm.Font = New System.Drawing.Font _
 ("Tahoma", 9, System.Drawing.FontStyle.Regular)
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
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

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        showlv(ComboBox1.SelectedIndex)
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        If Fload = True Then
            showlv(ComboBox1.SelectedIndex)
        End If
    End Sub
End Class