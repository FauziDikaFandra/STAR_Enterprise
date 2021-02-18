Imports System.Data.SqlClient
Imports System.Globalization
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.Shared
Imports System.IO
Imports SendMail
Imports System
Imports System.Net
Imports System.Net.Mail
'Imports System.Web.Mail
Imports System.Data
Imports System.Threading
Imports System.Runtime.InteropServices

Public Class SendMailForm
    Dim ds, dsfromvendor, dscek, dsLoopLv, dsAccruedAP As New DataSet
    Dim cryRpt As New ReportDocument
    Dim Fload As Boolean = False
    Dim Cnt As Integer = 0
    Dim lp As Integer = 0
    Dim a As Integer
    Dim AccAp As String = ""
    Dim siteV, SiteCode, AccruedAP, SalesRtlIT, TaxOutPut, BrandAcc As String
    Dim dsParameters As New DataSet
    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'LoginMail.Show()
        'LoginMail.TextBox2.Focus()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ConnectServer()
        Label4.Visible = False
        m_Sqlconn = "Data Source=" & m_ServerName & ";" & "Initial Catalog=" & m_DBName & ";" & "User ID=" & m_UserName & ";" & "Password=" & m_Password & ";"
        m_Sqlconn2 = "Data Source=" & m_ServerName2 & ";" & "Initial Catalog=" & m_DBName2 & ";" & "User ID=" & m_UserName2 & ";" & "Password=" & m_Password2 & ";"
        
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

        dscek.Clear()
        dscek = getSqldb("select WhsName as WhsCode, WhsName + ' - ' + WhsCode as WhsName from OWHS Where WhsCode <>'01' and WhsCode not in ('DC01','HO01') Order by WhsName")
        If dscek.Tables(0).Rows.Count > 1 Then
            a = 0
        Else
            a = 1
        End If
        cmb(ComboBox3, "select WhsName as Code, WhsName + ' - ' + WhsCode as WhsName  from OWHS Where WhsCode <>'01' and WhsCode not in ('DC01','HO01') Order by WhsCode", "Code", "WhsName", a)
        'cmb(ComboBox1, "select DISTINCT  replace(TH4.CardName,'''','''''')as CardCode,TH4.CardName  +' - ' + TH4.CardCode as CardName from OCRD TH4 Inner Join OITM TH2 On TH4.CardCode = TH2.CardCode inner join OITW TH5 On TH5.ItemCode = TH2.ItemCode  Where Left(TH5.U_PROFIT_CTR,2) = '" & ComboBox4.SelectedValue & "'", "CardCode", "CardName")
        'cmb(ComboBox2, "select DISTINCT  replace(TH4.CardName,'''','''''')as CardCode,TH4.CardName  +' - ' + TH4.CardCode as CardName from OCRD TH4 Inner Join OITM TH2 On TH4.CardCode = TH2.CardCode inner join OITW TH5 On TH5.ItemCode = TH2.ItemCode  Where Left(TH5.U_PROFIT_CTR,2) = '" & ComboBox4.SelectedValue & "'", "CardCode", "CardName")
        Fload = True
        SetLv2()
        DateTimePicker1.Value = Format(CDate(DateTimePicker1.Value.Month & "/1/" & DateTimePicker1.Value.Year), "dd  MMM  yyyy")
        showVendor()
        CheckForIllegalCrossThreadCalls = False
        Try
            Dim dsv As New DataSet
            ListView1.Items.Clear()
            dsv = getSqldb2("select Contact_Name,Email,Position,Case When Is_Absensi = 1 and Is_Sales = 0 Then 'Absensi' When Is_Absensi = 0 and Is_Sales = 1 Then 'Sales' Else  'Sales & Absensi' End As Is_,Phone from Contact where Vendor_Id = '" & DataGridView1.Item(1, 0).Value.ToString.Trim & "'  And Deleted = '0'")
            If dsv.Tables(0).Rows.Count > 0 Then
                For Each ro As DataRow In dsv.Tables(0).Rows
                    Dim str(5) As String
                    Dim itm As ListViewItem
                    str(0) = ro(0).ToString.Trim
                    str(1) = ro(1).ToString.Trim
                    str(2) = ro(2).ToString.Trim
                    str(3) = ro(3).ToString.Trim
                    str(4) = ro(4).ToString.Trim
                    itm = New ListViewItem(str)
                    ListView1.Items.Add(itm)
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Declare Auto Function SendMessage Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    Enum ProgressBarColor
        Green = &H1
        Red = &H2
        Yellow = &H3
        'DodgerBlue = &HFF901E
    End Enum
    Private Shared Sub ChangeProgBarColor(ByVal ProgressBar_Name As Windows.Forms.ProgressBar, ByVal ProgressBar_Color As ProgressBarColor)
        SendMessage(ProgressBar_Name.Handle, &H410, ProgressBar_Color, 0)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim byteViewer As Byte() = ReportViewer1.LocalReport.Render("PDF", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        'Dim saveFileDialog1 As New SaveFileDialog()
        'saveFileDialog1.Filter = "*PDF files (*.pdf)|*.pdf"
        'saveFileDialog1.FilterIndex = 2
        'saveFileDialog1.RestoreDirectory = True
        'Dim newFile As New FileStream("D:\Company Reckon Invoice(ExE)\PDF Files\Invoice Due Details" & clientno & ".pdf", FileMode.Create)
        'newFile.Write(byteViewer, 0, byteViewer.Length)
        'newFile.Close()
        '---------------jjjj
        'Dim message As New MailMessage()
        'For Each contact As DataRow In contacts.Rows

        '    Try
        '        Dim Client As New System.Net.Mail.SmtpClient

        '        With Client
        '            If WebConfigurationManager.AppSettings("smtpserver").Length > 0 Then
        '                .DeliveryMethod = Net.Mail.SmtpDeliveryMethod.SpecifiedPickupDirectory 'Net.Mail.SmtpDeliveryMethod.Network
        '                .PickupDirectoryLocation = "c:/outbox/"
        '                .Host = WebConfigurationManager.AppSettings("smtpserver")
        '            Else
        '                .DeliveryMethod = Net.Mail.SmtpDeliveryMethod.PickupDirectoryFromIis
        '            End If

        '            With message
        '                Dim FromAddress As MailAddress = New MailAddress("noreply@mypeoplebiz.com")
        '                .From = FromAddress
        '                .[To].Add(contact.Item("email").ToString())
        '                .Subject = txtSubject.Value
        '                .IsBodyHtml = True
        '                .Priority = MailPriority.Normal
        '                .BodyEncoding = Encoding.Default

        '                If Not String.IsNullOrWhiteSpace(txtHtml.Value) Then
        '                    .Body = txtHtml.Value
        '                End If


        '                If Not String.IsNullOrWhiteSpace(txtText.Value) Then
        '                    .Body = txtText.Value
        '                End If
        '            End With



        '            .Send(message)
        '        End With

        '    Catch Ex As Exception
        '        _error = Ex.Message
        '    End Try


        'Next
        '-------------------------------------------
        'SendMail("ho.it@star-depstore.com", "fauzi.dika@ymail.com", "tes", "testes", "192.168.1.5", "ho.it", "star")

    End Sub

    ' Public Shared Sub SendMail(ByVal from As String, ByVal [to] As String, ByVal subject As String, ByVal body As String, ByVal smtpServer As String, ByVal smtpUsername As String, _
    'ByVal smtpPassword As String, ByVal FileName As String)
    '     Dim attch As New Attachment(m_Path & "DataMail\BackUp\" & FileName & ".pdf")
    '     Dim message As New MailMessage(from, [to], subject, body)
    '     Dim cc As MailAddress = New MailAddress(MyEmail)
    '     message.Bcc.Add(cc)
    '     Dim smtpClient As New SmtpClient(smtpServer)
    '     smtpClient.UseDefaultCredentials = False
    '     Dim credentials As New NetworkCredential(smtpUsername, smtpPassword)
    '     smtpClient.Credentials = credentials
    '     message.Attachments.Add(attch)
    '     smtpClient.Send(message)
    ' End Sub

    Public Shared Sub SendMail(ByVal from As String, ByVal [to] As String, ByVal subject As String, ByVal body As String, ByVal smtpServer As String, ByVal smtpUsername As String, _
   ByVal smtpPassword As String, ByVal FileName As String)
        ''Gmail Testing
        'Dim attch As New Attachment(m_Path & "DataMail\BackUp\" & FileName & ".pdf")
        'Dim message As New MailMessage(from, "fauzi.dika@star-depstore.com", "Testing Mail", "")
        ''Dim cc As MailAddress = New MailAddress(P_MYEMA)
        ''message.Bcc.Add(cc)
        'Dim smtpClient As New SmtpClient("smtp.gmail.com")
        'smtpClient.UseDefaultCredentials = False
        'smtpClient.Port = 587
        'smtpClient.EnableSsl = True
        'Dim credentials As New NetworkCredential(smtpUsername, "31Jul2017")
        'smtpClient.Credentials = credentials
        'message.Attachments.Add(attch)
        'smtpClient.Send(message)


        'Gmail
        Dim attch As New Attachment(m_Path & "DataMail\BackUp\" & FileName & ".pdf")
        Dim message As New MailMessage(from, [to], subject, body)
        'Dim cc As MailAddress = New MailAddress(P_MYEMA)
        'message.Bcc.Add(cc)
        Dim smtpClient As New SmtpClient(smtpServer)
        smtpClient.UseDefaultCredentials = False
        smtpClient.Port = 587
        smtpClient.EnableSsl = True
        Dim credentials As New NetworkCredential(smtpUsername, smtpPassword)
        smtpClient.Credentials = credentials
        message.Attachments.Add(attch)
        smtpClient.Send(message)

        ''sdepstore
        'Dim attch As New Attachment(m_Path & "DataMail\BackUp\" & FileName & ".pdf")
        'Dim message As New MailMessage(from, [to], subject, body)
        ''Dim cc As MailAddress = New MailAddress(P_MYEMA)
        ''message.Bcc.Add(cc)
        'Dim smtpClient As New SmtpClient(P_SMTP)
        'smtpClient.UseDefaultCredentials = False
        'smtpClient.Port = 25
        'smtpClient.EnableSsl = False
        'Dim credentials As New NetworkCredential(from, P_PASS)
        'smtpClient.Credentials = credentials
        'message.Attachments.Add(attch)
        'smtpClient.Send(message)
    End Sub

    Sub showreportandsend(ByVal VendorFrom As String, ByVal VendorTo As String, ByVal sbu As String, ByVal Site As String, ByVal VMail As String, ByVal Ecount As Integer, ByVal Contact As String, ByVal Gender As String)

        Value(1) = DateTimePicker1.Value.Date
        Value(2) = DateTimePicker2.Value.Date
        Value(3) = VendorFrom
        Value(4) = VendorTo
        Value(5) = sbu
        Value(6) = Site
        Param(1) = "@StartInvDate"
        Param(2) = "@EndInvDate"
        Param(3) = "@CardCodeFr"
        Param(4) = "@CardCodeTo"
        Param(5) = "@SBUFr"
        Param(6) = "@WhsCodeFr"
2:
        Try
            Dim gndr As String
            If Gender = "M" Then
                gndr = "Bapak "
            Else
                gndr = "Ibu "
            End If
            ds = SelProc("uspVendorSalesReport", 6)
            If ds.Tables(0).Rows.Count > 0 Then
                cryRpt = New VendorReportSales
                cryRpt.SetDataSource(ds.Tables(0))
                cryRpt.SetParameterValue("FromDate", DateTimePicker1.Value)
                cryRpt.SetParameterValue("ToDate", DateTimePicker2.Value)
                cryRpt.SetParameterValue("Site", Site)
                cryRpt.SetParameterValue("Sbu", sbu)
                'Report.CrystalReportViewer1.ReportSource = cryRpt
                'Report.ShowDialog()
                'Report.TopMost = True
                If File.Exists(m_Path & "DataMail\" & SiteCode & "_" & Format(Now, "yyyyMMdd") & "_" & Ecount & "_" & VendorFrom & ".pdf") Then
                    File.Delete(m_Path & "DataMail\" & SiteCode & "_" & Format(Now, "yyyyMMdd") & "_" & Ecount & "_" & VendorFrom & ".pdf")
                End If
                CreatePdf(SiteCode & "_" & Format(Now, "yyyyMMdd") & "_" & Ecount & "_" & VendorFrom & "")
                If File.Exists(m_Path & "DataMail\BackUp\" & SiteCode & "_" & Format(Now, "yyyyMMdd") & "_" & Ecount & "_" & VendorFrom & ".pdf") Then
                    File.Delete(m_Path & "DataMail\BackUp\" & SiteCode & "_" & Format(Now, "yyyyMMdd") & "_" & Ecount & "_" & VendorFrom & ".pdf")
                End If
                File.Copy(m_Path & "DataMail\" & SiteCode & "_" & Format(Now, "yyyyMMdd") & "_" & Ecount & "_" & VendorFrom & ".pdf", m_Path & "DataMail\BackUp\" & SiteCode & "_" & _
                          Format(Now, "yyyyMMdd") & "_" & Ecount & "_" & VendorFrom & ".pdf")
                If CheckBox2.Checked = True Then
                    dsAccruedAP.Clear()
                    SAccruedAP(VendorFrom)
                    'SAccruedAP2(VendorFrom)
                End If
1:
                Try
                    If CheckBox2.Checked = True Then
                        AccAp = ""
                        Try
                            If dsAccruedAP.Tables(0).Rows.Count > 0 Then
                                AccAp = ""
                                For Each ro As DataRow In dsAccruedAP.Tables(0).Rows
                                    AccAp += " Total For Brand-Dept : " & ro("Brand") & " - " & ro("DeptName") & " : Gross(" & CDec(ro("SalesRtlIT")).ToString("N0") & ") - Nett After Margin(" & CDec(ro("AccruedAP")).ToString("N0") & ")" & vbNewLine
                                    'AccruedAP = dsAccruedAP.Tables(0).Rows(0).Item("AccruedAP") 'nett
                                    'SalesRtlIT = dsAccruedAP.Tables(0).Rows(0).Item("SalesRtlIT") 'gross
                                    'TaxOutPut = dsAccruedAP.Tables(0).Rows(0).Item("TaxOutPut")
                                    'BrandAcc = dsAccruedAP.Tables(0).Rows(0).Item("Brand")
                                Next
                            End If
                        Catch ex As Exception

                        End Try

                    End If
                    'VMail = "fauzi.dika@ymail.com"
                    'SendMail("ho.it@star-depstore.com", VMail, Judul, "Yang Terhormat " & gndr & Contact & vbNewLine & _
                    '                        "Terlampir adalah Report Sales " & VendorFrom & " ,untuk " & Site & " Periode : " & DateTimePicker1.Value.Date & "-" & DateTimePicker2.Value.Date, "192.168.1.5", "ho.it", _
                    '                        "star", SiteCode & "_" & Format(Now, "yyyyMMdd") & "_" & Ecount & "_" & VendorFrom)
                    SendMail(MyEmail, VMail, Judul, "Yang Terhormat " & gndr & Contact & vbNewLine & _
                    "Terlampir adalah Report Sales (" & SbuCode & ")" & VendorFrom & " ,untuk " & Site & " Periode : " & DateTimePicker1.Value.Date & "-" & DateTimePicker2.Value.Date & vbNewLine & vbNewLine & AccAp, "smtp.gmail.com", Replace(MyEmail, "@gmail.com", ""), _
                    "31Jul2017", SiteCode & "_" & Format(Now, "yyyyMMdd") & "_" & Ecount & "_" & VendorFrom)

                    getSqldb2("Insert Into LogMail Values ('" & VendorFrom.ToString.Trim & "','" & sbu.ToString.Trim & "','" & Contact.ToString.Trim & "','" & VMail & "','" & SiteCode & "_" & Format(Now, "yyyyMMdd") & "_" & Ecount.ToString.Trim & "_" & VendorFrom.ToString.Trim & "','" & DateTimePicker1.Value.Date & " - " & DateTimePicker2.Value.Date & "','1','" & UsrID & "','" & Now & "')")
                Catch ex As Exception
                    'If MsgBox(ex.Message, MsgBoxStyle.YesNo, "Information") = MsgBoxResult.Yes Then
                    'If MsgBox("There's Problems, Try Again?", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.Yes Then
                    GoTo 1
                    'Else

                    'End If
                End Try


            Else
                'MsgBox("Data is Not Found", MsgBoxStyle.Information, "Information")
                'DataGridView1.DataSource = ds.Tables(0)
                'DataGridView1.Refresh()
            End If

        Catch ex As Exception
            'If MsgBox(ex.Message, MsgBoxStyle.YesNo, "Information") = MsgBoxResult.Yes Then
            'If MsgBox("There's Problems, Try Again?", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.Yes Then
            GoTo 2
            'Else
            getSqldb2("Insert Into LogMail Values ('" & VendorFrom & "','" & sbu & "','" & Contact & "','" & VMail & "','" & SiteCode & "_" & Format(DateTimePicker1.Value, "yyyyMMdd") & "_" & Ecount & "_" & VendorFrom & "','" & DateTimePicker1.Value.Date & " - " & DateTimePicker2.Value.Date & "','0','" & UsrID & "','" & Now & "')")
            'End If
            'MsgBox(ex.Message)
        End Try

    End Sub


    Sub showVendor()


        Try
            Try
                DataGridView1.Columns.Remove("Column1")
                DataGridView1.DataSource = Nothing
            Catch ex As Exception

            End Try

            'DataGridView1.DataSource = Nothing
            ds.Clear()
            If ComboBox4.SelectedValue = "*" Then
                ds = getSqldb2("Select Vendor_Id,Vendor_Name,Sbu from Vendor Where  Deleted = '0' Order By Vendor_Name Asc")
            Else
                ds = getSqldb2("Select Vendor_Id,Vendor_Name,Sbu from Vendor Where Sbu = '" & ComboBox4.SelectedValue & "'  And Deleted = '0' Order By Vendor_Name Asc")
            End If

            If ds.Tables(0).Rows.Count > 0 Then
                Dim ch As New DataGridViewCheckBoxColumn()
                ch.Name = "Column1"
                ch.HeaderText = ""
                ch.Width = 35
                DataGridView1.Columns.Add(ch)
                DataGridView1.DataSource = ds.Tables(0)
                'DataGridView1.Columns("Column1").Frozen = True
                DataGridView1.Columns("Vendor_Id").Visible = False
                DataGridView1.Columns("Sbu").Visible = False
                DataGridView1.Columns("Vendor_Name").Width = 175
                DataGridView1.Columns("Vendor_Name").ReadOnly = True
                CheckBox1.Visible = True
                DataGridView1.Refresh()
            Else
                MsgBox("No Result!!!", MsgBoxStyle.Information, "Information")
                CheckBox1.Visible = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Sub showreport2(ByVal rVendor As String)

        Value(1) = DateTimePicker1.Value.Date
        Value(2) = DateTimePicker2.Value.Date
        Value(3) = rVendor
        Value(4) = rVendor
        Value(5) = ComboBox4.SelectedValue
        Value(6) = ComboBox3.SelectedValue
        Param(1) = "@StartInvDate"
        Param(2) = "@EndInvDate"
        Param(3) = "@CardCodeFr"
        Param(4) = "@CardCodeTo"
        Param(5) = "@SBUFr"
        Param(6) = "@WhsCodeFr"
        Try
            ds = SelProc("uspVendorSalesReport", 6)
            If ds.Tables(0).Rows.Count > 0 Then
                cryRpt = New VendorReportSales
                cryRpt.SetDataSource(ds.Tables(0))
                cryRpt.SetParameterValue("FromDate", DateTimePicker1.Value)
                cryRpt.SetParameterValue("ToDate", DateTimePicker2.Value)
                cryRpt.SetParameterValue("Site", ComboBox3.SelectedValue)
                cryRpt.SetParameterValue("Sbu", ComboBox4.Text)
                Report.CrystalReportViewer1.ReportSource = cryRpt
                Report.ShowDialog()
                Report.TopMost = True

                'Dim ch As New DataGridViewCheckBoxColumn()
                'ch.Name = "Column1"
                'ch.HeaderText = ""
                'ch.Width = 35
                'DataGridView1.Columns.Add(ch)
                'DataGridView1.DataSource = ds.Tables(0)
                'CheckBox1.Visible = True
                'DataGridView1.Refresh()

                'If File.Exists("D:\" & Format(DateTimePicker1.Value, "yyyyMMdd") & "_Vendor.pdf") Then
                '    File.Delete("D:\" & Format(DateTimePicker1.Value, "yyyyMMdd") & "_Vendor.pdf")
                'End If
                'CreatePdf(Format(DateTimePicker1.Value, "yyyyMMdd") & "_Vendor")
                'SendMail("ho.it@star-depstore.com", "fauzi.dika@ymail.com", "tes", "testes", "192.168.1.5", "ho.it", "star", Format(DateTimePicker1.Value, "yyyyMMdd") & "_Vendor")
                'MsgBox("File Has Been Send!!")
            Else
                MsgBox("No Result!!!", MsgBoxStyle.Information, "Information")
                'CheckBox1.Visible = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub CreatePdf(ByVal Name As String)
        Try
            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New  _
            DiskFileDestinationOptions()
            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
            CrDiskFileDestinationOptions.DiskFileName = _
                                        m_Path & "DataMail\" & Name & ".pdf"
            CrExportOptions = cryRpt.ExportOptions
            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .DestinationOptions = CrDiskFileDestinationOptions
                .FormatOptions = CrFormatTypeOptions
            End With
            cryRpt.Export()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub reportDocument1_InitReport(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If MessageBox.Show("You'll Send Report Periode : " & Format(DateTimePicker1.Value.Date, "dd MMMM yyyy") & " - " & Format(DateTimePicker2.Value.Date, "dd MMMM yyyy") & " ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            ProgressBar1.Value = 0
            ProgressBar1.Visible = True
            'ChangeProgBarColor(ProgressBar1, ProgressBarColor.Yellow)
            Button3.Enabled = False
            ButtonV.Enabled = False
            CheckBox2.Enabled = False
            GroupBox2.Enabled = False
            GroupBox1.Enabled = False
            GroupBox3.Enabled = False
            BackgroundWorker1.WorkerReportsProgress = True
            BackgroundWorker1.WorkerSupportsCancellation = True
            BackgroundWorker1.RunWorkerAsync()
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        showVendor()
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

    'Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Fload = True Then
    '        If ComboBox1.SelectedValue = "*" Then
    '            ComboBox2.SelectedValue = ComboBox1.SelectedValue
    '        ElseIf ComboBox2.SelectedValue = "*" Then
    '        Else
    '            If ComboBox1.SelectedValue > ComboBox2.SelectedValue Then
    '                ComboBox1.SelectedValue = ComboBox2.SelectedValue
    '            End If
    '        End If
    '    End If
    'End Sub

    'Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Fload = True Then
    '        If ComboBox1.SelectedValue = "*" Then
    '            ComboBox2.SelectedValue = ComboBox1.SelectedValue
    '        Else
    '            If ComboBox2.SelectedValue < ComboBox1.SelectedValue Then
    '                ComboBox2.SelectedValue = ComboBox1.SelectedValue
    '            End If
    '        End If

    '    End If
    'End Sub



    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            For a As Integer = 0 To DataGridView1.RowCount - 1
                DataGridView1.Item("Column1", a).Value = True
            Next
        Else
            For a As Integer = 0 To DataGridView1.RowCount - 1
                DataGridView1.Item("Column1", a).Value = False
            Next
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        For Each ro As DataGridViewRow In DataGridView1.Rows
            If ro.Cells("Column1").Value = True Then
                Cnt += 1
            End If
        Next
        If Cnt < 1 Then
            MsgBox("Please Checked Any/All Supplier List!!!", MsgBoxStyle.Information, "Attention")
            GroupBox2.Enabled = True
            GroupBox1.Enabled = True
            GroupBox3.Enabled = True
            Button3.Enabled = True
            CheckBox2.Enabled = True
            ButtonV.Enabled = True
        Else
            If ComboBox3.SelectedValue = "*" Then
                'For x As Integer = 1 To ComboBox3.Items.Count - 1
                '    ComboBox3.SelectedIndex = x
                '    siteV = ComboBox3.SelectedValue
                '    SiteCode = Microsoft.VisualBasic.Right(ComboBox3.Text.Trim, 4)
                Dim Prg As Decimal
                Dim Ecount As Integer = 0
                lp = 0
                Prg = 0
                ProgressBar1.Value = 0
                For Each ro As DataGridViewRow In DataGridView1.Rows
                    If ro.Cells("Column1").Value = True Then
                        Prg += 100 / Cnt
                        lp += 1
                        For x As Integer = 1 To ComboBox3.Items.Count - 1
                            ComboBox3.SelectedIndex = x
                            siteV = ComboBox3.SelectedValue
                            SiteCode = Microsoft.VisualBasic.Right(ComboBox3.Text.Trim, 4)

                            Try
                                setLabelTxt(SiteCode & " : " & lp & "/" & Cnt & " " & ro.Cells("Vendor_Name").Value & "-" & SiteCode, Label8)
                            Catch ex As Exception

                            End Try
                            Try
                                dsLoopLv.Clear()
                                dsLoopLv = getSqldb2("Select * from [Contact] Where Vendor_Id = '" & ro.Cells("Vendor_Id").Value & "'  And Deleted = '0'")
                                Ecount = 0
                                If dsLoopLv.Tables(0).Rows.Count > 0 Then
                                    'If CheckBox2.Checked = True Then
                                    '    SAccruedAP(ro.Cells("Vendor_Name").Value)
                                    'End If

                                    For Each re As DataRow In dsLoopLv.Tables(0).Rows
                                        If re("Is_Sales") = 1 Then
                                            Ecount += 1
                                            Dim cc As String = re(2).ToString
                                            'If re("Contact_Name") = "Ojie" Then
                                                showreportandsend(ro.Cells("Vendor_Name").Value, ro.Cells("Vendor_Name").Value, ro.Cells("SBU").Value, siteV, re(3).ToString, Ecount, re(2).ToString, re(5).ToString)
                                                'showreportandsend(ro.Cells("Vendor_Name").Value, ro.Cells("Vendor_Name").Value, ro.Cells("SBU").Value, siteV, MyEmail, Ecount, re(1).ToString, re(4).ToString)
                                            'End If
                                        End If
                                    Next
                                End If


                                'For Each item As ListViewItem In ListView1.Items
                                '    If item.SubItems(3).Text.Contains("Sales") Then
                                '        Ecount += 1
                                '        showreportandsend(ro.Cells("Vendor_Name").Value, ro.Cells("Vendor_Name").Value, ro.Cells("SBU").Value, siteV, item.SubItems(1).Text, Ecount, item.SubItems(0).Text)
                                '    End If
                                'Next
                            Catch ex As Exception
                                MsgBox(ex.Message)
                            End Try

                        Next

                        ComboBox3.SelectedValue = "*"

                        BackgroundWorker1.ReportProgress(Int(Prg))


                        'showreportandsend(ComboBox1.SelectedValue, ComboBox2.SelectedValue, ComboBox4.SelectedValue)
                    End If
                    'Prg = 0

                Next

                ' Next
            Else
                siteV = ComboBox3.SelectedValue
                SiteCode = Microsoft.VisualBasic.Right(ComboBox3.Text.Trim, 4)
                Dim Prg As Decimal
                Dim Ecount As Integer = 0
                lp = 0
                Prg = 0
                ProgressBar1.Value = 0

                For Each ro As DataGridViewRow In DataGridView1.Rows
                    If ro.Cells("Column1").Value = True Then
                        Prg += 100 / Cnt
                        lp += 1

                        Try
                            setLabelTxt(SiteCode & " : " & lp & "/" & Cnt & " " & ro.Cells("Vendor_Name").Value, Label8)
                        Catch ex As Exception

                        End Try
                        BackgroundWorker1.ReportProgress(Int(Prg))
                        Try
                            dsLoopLv.Clear()
                            dsLoopLv = getSqldb2("Select * from Contact Where Vendor_Id = '" & ro.Cells("Vendor_Id").Value & "'  And Deleted = '0'")
                            Ecount = 0
                            If dsLoopLv.Tables(0).Rows.Count > 0 Then
                                'If CheckBox2.Checked = True Then
                                '    SAccruedAP(ro.Cells("Vendor_Name").Value)
                                'End If
                                For Each re As DataRow In dsLoopLv.Tables(0).Rows
                                    If re("Is_Sales") = 1 Then
                                        Ecount += 1
                                        'showreportandsend(ro.Cells("Vendor_Name").Value, ro.Cells("Vendor_Name").Value, ro.Cells("SBU").Value, siteV, re(2).ToString, Ecount, re(1).ToString, re(4).ToString)
                                        showreportandsend(ro.Cells("Vendor_Name").Value, ro.Cells("Vendor_Name").Value, ro.Cells("SBU").Value, siteV, re(3).ToString, Ecount, re(2).ToString, re(5).ToString)
                                    End If
                                Next
                            End If

                            'For Each item As ListViewItem In ListView1.Items
                            '    If item.SubItems(3).Text.Contains("Sales") Then
                            '        Ecount += 1
                            '        showreportandsend(ro.Cells("Vendor_Name").Value, ro.Cells("Vendor_Name").Value, ro.Cells("SBU").Value, siteV, item.SubItems(1).Text, Ecount, item.SubItems(0).Text)
                            '    End If
                            'Next
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try

                        'showreportandsend(ComboBox1.SelectedValue, ComboBox2.SelectedValue, ComboBox4.SelectedValue)
                    End If
                    Prg = 0
                Next
            End If
        End If

    End Sub

    Private Sub setLabelTxt(ByVal text As String, ByVal lbl As Label)
        If lbl.InvokeRequired Then
            lbl.Invoke(New setLabelTxtInvoker(AddressOf setLabelTxt), text, lbl)
        Else
            lbl.Text = text
        End If
    End Sub

    Private Delegate Sub setLabelTxtInvoker(ByVal text As String, ByVal lbl As Label)
    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If Cnt < 1 Then
            setLabelTxt(lp & "/" & Cnt & " No Result!!!", Label8)
            Button3.Enabled = True
            ButtonV.Enabled = True
            CheckBox2.Enabled = True
            ProgressBar1.Visible = False
            Exit Sub
        End If
        setLabelTxt(lp & "/" & Cnt & " Done!!!", Label8)
        Cnt = 0
        lp = 0
        MsgBox("File Has Been Send!!")
        Button3.Enabled = True
        GroupBox2.Enabled = True
        GroupBox1.Enabled = True
        GroupBox3.Enabled = True
        ButtonV.Enabled = True
        CheckBox2.Enabled = True
        ProgressBar1.Visible = False
        Dim delQ() As String = Directory.GetFileSystemEntries(m_Path & "DataMail\", "*.pdf")
        For Each delFile As String In delQ
            If (Not Directory.Exists(delFile)) Then
                Try
                    File.Delete(delFile)
                Catch ex As Exception

                End Try

            End If
        Next
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            showlv(DataGridView1.Item(1, e.RowIndex).Value.ToString.Trim)
        Catch ex As Exception

        End Try

    End Sub

    Sub showlv(ByVal v_id As String)
        Try
            Dim dsv As New DataSet
            ListView1.Items.Clear()
            dsv = getSqldb2("select Contact_Name,Email,Position,Case When Is_Absensi = 1 and Is_Sales = 0 Then 'Absensi' When Is_Absensi = 0 and Is_Sales = 1 Then 'Sales' Else  'Sales & Absensi' End As Is_,Phone from Contact where Vendor_Id = '" & v_id & "'  And Deleted = '0' ")
            If dsv.Tables(0).Rows.Count > 0 Then

                For Each ro As DataRow In dsv.Tables(0).Rows
                    Dim str(5) As String
                    Dim itm As ListViewItem
                    str(0) = ro(0).ToString.Trim
                    str(1) = ro(1).ToString.Trim
                    str(2) = ro(2).ToString.Trim
                    str(3) = ro(3).ToString.Trim
                    str(4) = ro(4).ToString.Trim
                    itm = New ListViewItem(str)
                    'itm.Checked = True
                    ListView1.Items.Add(itm)
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub SetLv2()
        ListView1.Columns.Add("Contact_Name", 150, HorizontalAlignment.Center)
        ListView1.Columns.Add("Email", 180, HorizontalAlignment.Left)
        ListView1.Columns.Add("Position", 120, HorizontalAlignment.Left)
        ListView1.Columns.Add("Is_", 80, HorizontalAlignment.Left)
        ListView1.Columns.Add("Phone", 100, HorizontalAlignment.Left)
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            Label4.Visible = True
            showreport2(DataGridView1.Item("Vendor_Name", e.RowIndex).Value)
        Catch ex As Exception
            Label2.Visible = False
        End Try

    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        If Fload = True Then
            showVendor()
        End If

    End Sub

   

    Private Sub ComboBox4_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox4.TabIndexChanged
        If Fload = True Then
            showVendor()
        End If

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Label4.Visible = True
                showreport2(DataGridView1.Item("Vendor_Name", DataGridView1.CurrentRow.Index).Value)
            End If
        Catch ex As Exception
            Label4.Visible = False
        End Try

    End Sub

    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        showlv(DataGridView1.Item(1, DataGridView1.CurrentRow.Index).Value.ToString.Trim)
    End Sub

    Sub SAccruedAP(ByVal rVendor As String)
        Value(1) = DateTimePicker1.Value.Date
        Value(2) = DateTimePicker2.Value.Date
        Value(3) = ComboBox3.SelectedValue
        Value(4) = ComboBox3.SelectedValue
        Value(5) = "*"
        Value(6) = "*"
        Value(7) = rVendor
        Value(8) = rVendor
        Value(9) = "*"
        Value(10) = "*"
        Value(11) = ComboBox4.SelectedValue
        Value(12) = ComboBox4.SelectedValue
        Value(13) = "*"
        Value(14) = "*"
        Value(15) = "*"
        Value(16) = "*"
        Param(1) = "@StartDate"
        Param(2) = "@EndDate"
        Param(3) = "@WhsCodeFr"
        Param(4) = "@WhsCodeTo"
        Param(5) = "@DeptCodeFr"
        Param(6) = "@DeptCodeTo"
        Param(7) = "@CardCodeFr"
        Param(8) = "@CardCodeTo"
        Param(9) = "@BrNameFr"
        Param(10) = "@BrNameTo"
        Param(11) = "@SBUFr"
        Param(12) = "@SBUTo"
        Param(13) = "@MCFr"
        Param(14) = "@MCTo"
        Param(15) = "@ItemCodeFr"
        Param(16) = "@ItemCodeTo"
3:


        Try
            dsAccruedAP.Clear()
            dsAccruedAP = SelProc("uspAccruedAPReport4SendMail", 16)
            'If dsAccruedAP.Tables(0).Rows.Count > 0 Then
            '    AccruedAP = dsAccruedAP.Tables(0).Rows(0).Item("AccruedAP") 'nett
            '    SalesRtlIT = dsAccruedAP.Tables(0).Rows(0).Item("SalesRtlIT") 'gross
            '    TaxOutPut = dsAccruedAP.Tables(0).Rows(0).Item("TaxOutPut")
            '    BrandAcc = dsAccruedAP.Tables(0).Rows(0).Item("Brand")
            'End If
        Catch ex As Exception
            'If MsgBox("AccruedAP Problems, Try Again?", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.Yes Then
            GoTo 3
            'Else

            'End If
        End Try

    End Sub

    Sub SAccruedAP2(ByVal rVendor As String)
        Value(1) = DateTimePicker1.Value.Date
        Value(2) = DateTimePicker2.Value.Date
        Value(3) = ComboBox3.SelectedValue
        Value(4) = ComboBox3.SelectedValue
        Value(5) = rVendor
        Value(6) = rVendor
        Value(7) = ComboBox4.SelectedValue
        Value(8) = ComboBox4.SelectedValue

        Param(1) = "@StartDate"
        Param(2) = "@EndDate"
        Param(3) = "@WhsCodeFr"
        Param(4) = "@WhsCodeTo"
        Param(5) = "@CardCodeFr"
        Param(6) = "@CardCodeTo"
        Param(7) = "@SBUFr"
        Param(8) = "@SBUTo"
3:


        Try
            dsAccruedAP.Clear()
            dsAccruedAP = SelProc("uspAccruedAPReport4SendMail2", 8)
            If dsAccruedAP.Tables(0).Rows.Count > 0 Then
                AccruedAP = dsAccruedAP.Tables(0).Rows(0).Item("AccruedAP") 'nett
                SalesRtlIT = dsAccruedAP.Tables(0).Rows(0).Item("SalesRtlIT") 'gross
                '    TaxOutPut = dsAccruedAP.Tables(0).Rows(0).Item("TaxOutPut")
                '    BrandAcc = dsAccruedAP.Tables(0).Rows(0).Item("Brand")
            End If
        Catch ex As Exception
            'If MsgBox("AccruedAP Problems, Try Again?", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.Yes Then
            GoTo 3
            'Else

            'End If
        End Try

    End Sub

    Private Sub ButtonV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonV.Click
        SAccruedAP(DataGridView1.Item(2, DataGridView1.CurrentRow.Index).Value.ToString.Trim)
        If dsAccruedAP.Tables(0).Rows.Count > 0 Then
            AccAp = ""
            For Each ro As DataRow In dsAccruedAP.Tables(0).Rows
                AccAp += " Total For Brand-Dept : " & ro("Brand") & " - " & ro("DeptName") & " : G(" & CDec(ro("SalesRtlIT")).ToString("N0") & ") - N(" & CDec(ro("AccruedAP")).ToString("N0") & ")" & vbNewLine
            Next
            MsgBox(AccAp, MsgBoxStyle.Information, "Accured Info")
        Else
            MsgBox("There's No Transactions!!!", MsgBoxStyle.Information, "Accured Info")
        End If

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim attch As New Attachment("C:\Users\Ojie\Downloads\sendgrid.png")
        Dim message As New MailMessage("fauzi.dika@star-depstore.com", "fauzi.dika@star-depstore.com", "Testing Send Grid SMTP", "Testing Send Grid SMTP")
        Dim smtpClient As New SmtpClient("smtp.sendgrid.net")
        smtpClient.UseDefaultCredentials = False
        smtpClient.Port = 587
        smtpClient.EnableSsl = True
        Dim credentials As New NetworkCredential("fauzi.dika@ymail.com", "04Desember")
        smtpClient.Credentials = credentials
        message.Attachments.Add(attch)
        smtpClient.Send(message)
    End Sub

    'Sub SendEmail()
    '    Dim apiKey = "put your api key here ... should start with sg.something"
    '    Dim sg = New SendGridAPIClient(apiKey)

    '    Dim from = New Email("billgates@microsoft.com")
    '    Dim subject = "Hello World from the SendGrid CSharp Library!"
    '    Dim sto = New Email("barakobama@whitehouse.gov")
    '    Dim content = New Content("text/plain", "Hello, Email!")
    '    Dim mail = New Mail(from, subject, sto, content)
    '    Dim response = Await sg.client.mail.send.post(requestBody:=mail.[Get]())
    'End Sub
End Class
