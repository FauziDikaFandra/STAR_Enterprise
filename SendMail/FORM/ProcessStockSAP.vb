Public Class ProcessStockSAP
    Dim idProses, vtglopstr As String
    Dim wrkend As Boolean
    Dim vtglop As Date
    Dim Prg As Integer

    Private Delegate Sub setLabelTxtInvoker(ByVal text As String, ByVal lbl As Label)
    Private Sub setLabelTxt(ByVal text As String, ByVal lbl As Label)
        If lbl.InvokeRequired Then
            lbl.Invoke(New setLabelTxtInvoker(AddressOf setLabelTxt), text, lbl)
        Else
            lbl.Text = text
        End If
    End Sub
    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ConnectServer()
        m_Sqlconn = "Data Source=" & m_ServerName & ";" & "Initial Catalog=" & m_DBName & ";" & "User ID=" & m_UserName & ";" & "Password=" & m_Password & ";"
        m_Sqlconn2 = "Data Source=" & m_ServerName2 & ";" & "Initial Catalog=" & m_DBName2 & ";" & "User ID=" & m_UserName2 & ";" & "Password=" & m_Password2 & ";"
        CheckForIllegalCrossThreadCalls = False

        cmb(ComboBox1, "select WhsName as Code, WhsName + ' - ' + WhsCode as WhsName  from OWHS Where WhsCode <>'01' and WhsCode not in ('DC01','HO01') Order by WhsCode", "Code", "WhsName", 1)
        'cmb(ComboBox2, "select Name,U_Description from dbo.[@PRODUCT_CATEGORY] where  not isnumeric(Name) = 1 Order By name", "Name", "U_Description", 1)
        'cmb_jenis()
        DateTimePicker1.Value = Now
        Label5.Text = ""
    End Sub
    Sub cmb_jenis()
        Dim FILE_NAME As String = "Jenis.txt"
        Dim objReader As New System.IO.StreamReader(FILE_NAME)
        Dim LineOfText As String = Nothing
        Dim Aryline(1) As String
        Dim FirstList As String
        Dim SecondList As String
        Dim c As New ArrayList
        'read line by line
        Do While objReader.Peek() <> -1
            LineOfText = objReader.ReadLine() & vbNewLine

            ' split line of text at "=" sign
            Aryline = LineOfText.Split(",")

            'Assign the parts to a variable
            FirstList = Aryline(0)
            SecondList = Aryline(1)

            ' sent split Lists to listboxes
            c.Add(New CCombo(FirstList, SecondList))


        Loop
        With ComboBox2
            .DataSource = c
            .DisplayMember = "Number_Name"
            .ValueMember = "ID"
        End With
        'Close the Reader
        objReader.Close()
    End Sub
    Sub StockSAP()         'jalanin query atau stock_sys di SO --> tempsap(stok SAP) di SAP
        Dim dI, dS As DataSet
        Dim stok As Double = 0
        Dim lbl As String
        Dim no As Integer = 0
        ExecSO("delete stock_sys where branch_id = '" & StoreCode() & "' " & vbCrLf & _
               "and convert( varchar(10), tgl_so, 20) = '" & vtglopstr & "' ")

        dS = QuerySO("Select top 1 * from stock_sys")
        dI = QuerySO("select distinct branch_id, jenis, nomor, plu, article, sbu, description, price, qty, jml, stock " & vbCrLf & _
                      "from tempitem " & vbCrLf & _
                      "order by branch_id, jenis, nomor")
        '"where substring(idproses, 1, 8) = '" & Replace(vtglopstr, "-", "") & "' " & vbCrLf & _

        'MsgOK(dI.Tables(0).Rows.Count)
        For Each ro As DataRow In dI.Tables(0).Rows
            lbl = "Process Stock SAP, PLU : " & ro("plu").ToString.Trim
            Try : setLabelTxt(lbl, Label5) : Catch ex As Exception : End Try
            Prg = CInt((no * 100) / dI.Tables(0).Rows.Count)
            BackgroundWorker2.ReportProgress(Prg)

            dS = QuerySAP("SELECT T0.ItemCode AS 'article', T1.ItemName AS 'description', T0.WhsCode AS 'whs', " & vbCrLf & _
                          "T0.OnHand AS 'whsqty', T1.OnHand AS 'compqty' " & vbCrLf & _
                          "FROM OITW T0 " & vbCrLf & _
                          "LEFT OUTER JOIN OITM T1 ON T0.ItemCode = T1.ItemCode " & vbCrLf & _
                          "WHERE T0.ItemCode = '" & ro("article").ToString.Trim & "' AND " & vbCrLf & _
                          "T0.WhsCode = '" & ro("branch_id").ToString.Trim & "'")
            stok = 0
            If dS.Tables(0).Rows.Count > 0 Then
                stok = CDbl(dS.Tables(0).Rows(0).Item("whsqty").ToString.Trim)
            End If

            Try
                ExecSO("insert into stock_sys values ('" & Trim(ro("branch_id")) & "', " & vbCrLf & _
                       "'" & vtglopstr & "', '" & Trim(ro("jenis")) & "', '" & Trim(ro("plu")) & "', " & vbCrLf & _
                       "'" & Trim(ro("article")) & "','" & Trim(ro("sbu")) & "', " & vbCrLf & _
                       "'" & Replace(Trim(ro("Description")), "'", "") & "', '" & stok & "')")
            Catch ex As Exception
                MsgError("Error Process Stock SAP, PLU : " & ro("plu"))
                wrkend = True
                dI.Dispose()
                dS.Dispose()
                BackgroundWorker2.CancelAsync()
                Exit Sub
            End Try
            no += 1
        Next
        dI.Dispose()
        dS.Dispose()
    End Sub
    Function BranchCode() As String
        Dim hasil As String = ""
        If ComboBox1.SelectedIndex = 0 Then
            hasil = "MKG"
        ElseIf ComboBox1.SelectedIndex = 1 Then
            hasil = "SMS"
        ElseIf ComboBox1.SelectedIndex = 2 Then
            hasil = "SMB"
        ElseIf ComboBox1.SelectedIndex = 3 Then
            hasil = "BALI"
        End If
        Return hasil
    End Function
    Function StoreCode() As String
        Dim hasil As String = ""
        hasil = Microsoft.VisualBasic.Right(ComboBox1.Text.Trim, 4)
        Return hasil
    End Function
    Function JenisCode() As String
        Dim hasil As String = ""
        If ComboBox2.SelectedIndex = 0 Then
            hasil = "CO"
        ElseIf ComboBox2.SelectedIndex = 1 Then
            hasil = "TO"
        ElseIf ComboBox2.SelectedIndex = 2 Then
            hasil = "FA"
        ElseIf ComboBox2.SelectedIndex = 3 Then
            hasil = "OT"
        End If
        Return hasil
    End Function
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        vtglop = DateTimePicker1.Value.AddDays(-1)
        vtglopstr = Format(vtglop, "yyyy-MM-dd")

        ProgressBar1.Value = 0
        ProgressBar1.Visible = True
        GroupBox2.Enabled = False
        GroupBox1.Enabled = False
        BackgroundWorker2.WorkerReportsProgress = True
        BackgroundWorker2.WorkerSupportsCancellation = True
        BackgroundWorker2.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        ProgressBar1.Value = 0
        Prg = 0
        wrkend = False
        StockSAP()
    End Sub

    Private Sub BackgroundWorker2_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker2.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker2_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        If wrkend = True Then
            Label5.Text = "Problem During Proccessed!!!"
        Else
            Label5.Text = "Done !!! "
        End If
        wrkend = False
        GroupBox1.Enabled = True
        GroupBox2.Enabled = True
        ProgressBar1.Visible = False
        Prg = 0
        If wrkend = False Then MsgOK("Finished")
    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub
End Class