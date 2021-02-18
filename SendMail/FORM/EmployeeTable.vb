Public Class EmployeeTable
    Dim startdate, enddate As Date
#Region "procedure"
    Sub TampilTable(Optional ByVal syarat As String = " (0=0) ", _
                    Optional ByVal active As String = " (isactive='YES') ", _
                    Optional ByVal SQL As String = "select top 1 * " & vbCrLf & _
                    "from v_employee " & vbCrLf & _
                    "where @syarat and @filtertgl and @active and isdelete=0 " & vbCrLf & _
                    "order by name ")
        Cursor = Cursors.WaitCursor
        Dim dstable As DataSet
        SQL = Replace(SQL, "@syarat", syarat)
        SQL = Replace(SQL, "@active", active)
        SQL = Replace(SQL, "@filtertgl", " (1=1) ")
        'Dbg(SQL)
        dstable = QueryToDataset(SQL, StrConHRD)

        dg.Columns.Clear()
        dg.DataSource = dstable.Tables(0)
        NavSource1.DataSource = dstable.Tables(0)
        Navigator.BindingSource = NavSource1
        NavSource1.Filter = " (0=0) "

        'FormatColumnGrid(dg, 4, "number", 2)

        dg.RowsDefaultCellStyle.BackColor = Color.Bisque
        dg.AlternatingRowsDefaultCellStyle.BackColor = Color.White


        'Dim ht As String
        'For x As Integer = 0 To dg.ColumnCount - 1
        '    'MsgOK("columnname : " & dg.Columns(x).DataPropertyName & vbCrLf & _
        '    '      "columntype : " & dg.Columns(x).ValueType.ToString)
        '    ht = dg.Columns(x).HeaderText
        '    ht = Replace(ht, "_", " ")
        '    ht = StrConv(ht, VbStrConv.ProperCase)
        '    dg.Columns(x).HeaderText = ht

        '    If LCase(dg.Columns(x).ValueType.ToString) = "system.datetime" Or _
        '        LCase(dg.Columns(x).ValueType.ToString) = "system.date" Then
        '        FormatColumnGrid(dg, x, "date")
        '    End If
        'Next
        setColumnGrid(dg, "employee")
        SQL = Replace(SQL, "top 1", "")
        dstable = QueryToDataset(SQL, StrConHRD)
        dg.DataSource = dstable.Tables(0)
        NavSource1.DataSource = dstable.Tables(0)
        Navigator.BindingSource = NavSource1
        NavSource1.Filter = " (0=0) "
        showSummaryHeader()
        Cursor = Cursors.Default
        dg.Focus()
    End Sub
    Sub showSummaryHeader()
        'Dim x As Integer
        'Dim totalTagihan, sisatagihan, potongan, jmlbayar As Double
        'totalTagihan = 0 : sisatagihan = 0 : potongan = 0 : jmlbayar = 0
        'For x = 0 To dg.RowCount - 1
        '    totalTagihan = totalTagihan + Convert.ToDouble(dg.Rows(x).Cells("totaltagihan").Value)
        '    sisatagihan = sisatagihan + Convert.ToDouble(dg.Rows(x).Cells("sisatagihan").Value)
        '    potongan = potongan + Convert.ToDouble(dg.Rows(x).Cells("potongan").Value)
        '    jmlbayar = jmlbayar + Convert.ToDouble(dg.Rows(x).Cells("jumlahbayar").Value)
        'Next
        'txtTotalTagihan.Text = FormatNumber(totalTagihan, 2)
        'txtSisaTagihan.Text = FormatNumber(sisatagihan, 2)
        'txtPotongan.Text = FormatNumber(potongan, 2)
        'txtJmlBayar.Text = FormatNumber(jmlbayar, 2)

        txtTotalDataH.Text = "Total Data : " & dg.RowCount
    End Sub
    Sub editData()
        EmployeeForm.isiCombo()
        EmployeeForm.txtEmployeeID.Text = getDataGrid(dg, "employee_id").ToString.Trim
        EmployeeForm.txtNIP.Text = getDataGrid(dg, "nip").ToString.Trim
        EmployeeForm.txtNIP.Enabled = False
        EmployeeForm.lblTipe.Text = "update"
        EmployeeForm.ShowDialog()
        OpenDBHRD()
        reloadClick()
        txtSPG_Barcode.Clear()
        txtSPG_Barcode.Focus()
    End Sub
    Sub addData()
        EmployeeForm.isiCombo()
        EmployeeForm.txtEmployeeID.Text = ""
        EmployeeForm.txtNIP.Text = ""
        EmployeeForm.txtNIP.Enabled = True
        EmployeeForm.lblTipe.Text = "new"
        EmployeeForm.ShowDialog()
        reloadClick()
        txtSPG_Barcode.Clear()
        txtSPG_Barcode.Focus()
    End Sub
    Sub DeleteData()
        'MsgBox("Delete")

        If MsgConfirm("Anda Yakin Ingin Hapus Data " & dg.SelectedRows.Count & " Record ?") = MsgBoxResult.Yes Then
            For Each row As DataGridViewRow In dg.SelectedRows
                ExecQuery("update m_employee set isdelete=1 where employee_id= '" & row.Cells("employee_id").Value & "' ", StrConHRD)
            Next
            reloadClick()
        End If
    End Sub
#End Region
#Region "button date"
    Private Sub BtnFirstToNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFirstToNow.Click
        startdate = DateTime.Parse(Year(dtStartdate.Value) & "-01-01")
        enddate = Now
        dtStartdate.Value = startdate
        dtEnddate.Value = enddate
        BtnReload_Click(sender, e)
    End Sub
    Private Sub BtnOneMonth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOneMonth.Click
        startdate = DateTime.Parse(Year(dtStartdate.Value) & "-" & Month(dtStartdate.Value) & "-01")
        enddate = startdate.AddMonths(1).AddDays(-1)
        dtStartdate.Value = startdate
        dtEnddate.Value = enddate
        BtnReload_Click(sender, e)
    End Sub
    Private Sub BtnNextMonth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNextMonth.Click
        startdate = DateTime.Parse(Year(dtStartdate.Value) & "-" & Month(dtStartdate.Value) & "-01")
        startdate = startdate.AddMonths(1)
        enddate = startdate.AddMonths(1).AddDays(-1)
        dtStartdate.Value = startdate
        dtEnddate.Value = enddate
        BtnReload_Click(sender, e)
    End Sub
    Private Sub BtnPrevMonth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevMonth.Click
        startdate = DateTime.Parse(Year(dtStartdate.Value) & "-" & Month(dtStartdate.Value) & "-01")
        startdate = startdate.AddMonths(-1)
        enddate = startdate.AddMonths(1).AddDays(-1)
        dtStartdate.Value = startdate
        dtEnddate.Value = enddate
        BtnReload_Click(sender, e)
    End Sub
    Private Sub BtnOneWeek_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOneWeek.Click
        Dim x As Integer
        If Weekday(dtStartdate.Value) = 1 Then
            x = -6
        Else
            x = FirstDayOfWeek.Monday - Weekday(dtStartdate.Value)
        End If
        startdate = dtStartdate.Value.AddDays(x)
        enddate = startdate.AddDays(6)
        dtStartdate.Value = startdate
        dtEnddate.Value = enddate
        BtnReload_Click(sender, e)
    End Sub
    Private Sub BtnNextWeek_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNextWeek.Click
        Dim x As Integer
        If Weekday(dtStartdate.Value) = 1 Then
            x = -6
        Else
            x = FirstDayOfWeek.Monday - Weekday(dtStartdate.Value)
        End If
        startdate = dtStartdate.Value.AddDays(x)
        startdate = startdate.AddDays(7)
        enddate = startdate.AddDays(6)
        dtStartdate.Value = startdate
        dtEnddate.Value = enddate
        BtnReload_Click(sender, e)
    End Sub
    Private Sub BtnPrevWeek_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevWeek.Click
        Dim x As Integer
        If Weekday(dtStartdate.Value) = 1 Then
            x = -6
        Else
            x = FirstDayOfWeek.Monday - Weekday(dtStartdate.Value)
        End If
        startdate = dtStartdate.Value.AddDays(x)
        startdate = startdate.AddDays(-7)
        enddate = startdate.AddDays(6)
        dtStartdate.Value = startdate
        dtEnddate.Value = enddate
        BtnReload_Click(sender, e)
    End Sub
    Private Sub BtnOneYear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOneYear.Click
        startdate = DateTime.Parse(Year(dtStartdate.Value) & "-01-01")
        enddate = DateTime.Parse(Year(dtStartdate.Value) & "-12-31")
        dtStartdate.Value = startdate
        dtEnddate.Value = enddate
        BtnReload_Click(sender, e)
    End Sub
    Private Sub BtnOneDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOneDay.Click
        startdate = dtStartdate.Value
        enddate = dtStartdate.Value
        dtStartdate.Value = startdate
        dtEnddate.Value = enddate
        BtnReload_Click(sender, e)
    End Sub
    Private Sub BtnToday_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnToday.Click
        startdate = Now
        enddate = Now
        dtStartdate.Value = startdate
        dtEnddate.Value = enddate
        BtnReload_Click(sender, e)
    End Sub
#End Region
#Region "security"
    Private Sub ShowDateTemplate(Optional ByVal Tipe As Boolean = True)
        'BtnDateTemplate.Visible = Tipe
        'PanelDate.Visible = Tipe
        'BtnReload.Visible = Tipe
        'PanelReload.Visible = Tipe
        PanelDateTemplate.Visible = Tipe
    End Sub
    Private Sub validasiButton()
        Dim lengthPanelKanan As Integer = 0
        'MsgBox(cmsMenu.Items.Count)
        BtnAdd.Visible = True
        BtnEdit.Visible = True
        BtnDelete.Visible = True
        BtnPrint.Visible = True
        BtnMenu.Visible = True
        If cmsMenu.Items.Count <= 0 Then BtnMenu.Visible = False
        If cmsPrint.Items.Count <= 0 Then BtnPrint.Visible = False
        ShowDateTemplate(False)

        'lengthPanelKanan = PanelReload.Width + PanelDate.Width + PanelClose.Width + BtnReload.Width + BtnDateTemplate.Width + BtnClose.Width
        If BtnAdd.Visible Then lengthPanelKanan = lengthPanelKanan + BtnAdd.Width
        If BtnEdit.Visible Then lengthPanelKanan = lengthPanelKanan + BtnEdit.Width
        If BtnDelete.Visible Then lengthPanelKanan = lengthPanelKanan + BtnDelete.Width
        If BtnPrint.Visible Then lengthPanelKanan = lengthPanelKanan + BtnPrint.Width
        If BtnMenu.Visible Then lengthPanelKanan = lengthPanelKanan + BtnMenu.Width
        lengthPanelKanan = lengthPanelKanan + BtnClose.Width + 10
        PanelKanan.Width = lengthPanelKanan
    End Sub
    Sub LoadImage()
        'Dim ico As New System.Drawing.Icon(FolderImage & "star.ico") : Me.Icon = ico
        'BtnReload.Image = Image.FromFile(FolderImage & "reload16.png")
        'BtnDateTemplate.Image = Image.FromFile(FolderImage & "date16.png")
        'BtnPrint.Image = Image.FromFile(FolderImage & "print16.png")
        'BtnMenu.Image = Image.FromFile(FolderImage & "menu16.png")
        'BtnAdd.Image = Image.FromFile(FolderImage & "add16.png")
        'BtnEdit.Image = Image.FromFile(FolderImage & "edit16.png")
        'BtnDelete.Image = Image.FromFile(FolderImage & "delete16.png")
        'BtnClose.Image = Image.FromFile(FolderImage & "close16.png")
        Dim ico As New System.Drawing.Icon(FolderImage & "star.ico") : Me.Icon = ico
        'BtnReload.Image = Image.FromFile(FolderImage & "reload16.png")
        BtnDateTemplate.Image = Image.FromFile(FolderImage & "date16.png")
        BtnPrint.Image = Image.FromFile(FolderImage & "32print.png")
        BtnMenu.Image = Image.FromFile(FolderImage & "32menu.png")
        BtnAdd.Image = Image.FromFile(FolderImage & "32add.png")
        BtnEdit.Image = Image.FromFile(FolderImage & "32edit.png")
        BtnDelete.Image = Image.FromFile(FolderImage & "32delete.png")
        BtnClose.Image = Image.FromFile(FolderImage & "32close.png")
    End Sub
#End Region
#Region "form"

    Private Sub EmployeeTable_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        CloseDBALL()
    End Sub
    Private Sub EmployeeTable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OpenDBHRD()
        LoadImage()
        PanelFilterH.Visible = False
        'PanelFilterD1.Visible = False
        'PanelFilterD2.Visible = False
        Label1.Text = Me.Text
        validasiButton()
        dtStartdate.Value = Now
        dtEnddate.Value = Now
        reloadClick()
        'dgConsignment.Font = lblFont.Font
    End Sub
#End Region
#Region "button"
    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        cmsPrint.Show(BtnPrint, 0, BtnPrint.Height)
    End Sub
    Private Sub BtnMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMenu.Click
        cmsMenu.Show(BtnMenu, 0, BtnMenu.Height)
    End Sub
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Close()
    End Sub
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        addData()
        'cmsAdd.Show(BtnAdd, 0, BtnAdd.Height)
    End Sub
    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        editData()
    End Sub
    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        DeleteData()
    End Sub
    Private Sub BtnDateTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDateTemplate.Click
        cmsDate.Show(BtnDateTemplate, 0, BtnDateTemplate.Height)
    End Sub
    Private Sub BtnConsignment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsignment.Click
        'TampilDirect("xx")
        'TampilConsingment("xx")
        'TampilTable(" (th.isdirect=0) ")
    End Sub
    Private Sub BtnReload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReload.Click
        'TampilDirect("xx")
        'TampilConsingment("xx")
        'TampilTable(" (th.isdirect=1) ")
    End Sub
    Sub reloadClick(Optional ByVal isdirect As String = " (th.isdirect=1) ")
        TampilTable()
    End Sub
#End Region

#Region "datagridview"
    Private Sub dg_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg.CellContentClick

    End Sub
    Private Sub dg_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg.CellDoubleClick
        'MsgOK(dg.Item("employee_id", dg.CurrentRow.Index).Value.ToString)
        editData()
    End Sub
    Private Sub dg_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dg.CellBeginEdit
        'Try
        '    If dg.Focused And dg.CurrentCell.ColumnIndex = 1 Then
        '        'MsgBox(dg.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False).Location.X)
        '        'MsgBox(dg.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False).Location.Y)
        '        'dtpTdate.Location = dg.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False).Location
        '        dtpTdate.Left = dg.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False).Location.X
        '        dtpTdate.Top = dg.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False).Location.Y + Panel1.Height
        '        dtpTdate.Visible = True
        '        If Not IsDBNull(dg.CurrentCell.Value) Then
        '            dtpTdate.Value = DateTime.Parse(dg.CurrentCell.Value)
        '        Else
        '            dtpTdate.Value = DateTime.Today
        '        End If
        '    Else
        '        dtpTdate.Visible = False
        '    End If
        'Catch ex As Exception
        '    MsgError(ex.Message)
        'End Try
    End Sub
    Private Sub dg_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg.CellEndEdit
        'Try
        '    If dg.Focused And dg.CurrentCell.ColumnIndex = 1 Then
        '        dg.CurrentCell.Value = dtpTdate.Value.Date
        '    Else
        '    End If
        'Catch ex As Exception
        '    MsgError(ex.Message)
        'End Try
    End Sub
    Private Sub dtpTdate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTdate.ValueChanged
        'dg.CurrentCell.Value = dtpTdate.Text
    End Sub
    Private Sub dg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dg.KeyDown
        If e.KeyCode = 46 Then
            DeleteData()
        End If
    End Sub
    Private Sub dg_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg.CellLeave
        'Try
        '    If dg.Focused And dg.CurrentCell.ColumnIndex = 1 Then
        '        dtpTdate.Visible = False
        '    Else
        '    End If
        'Catch ex As Exception
        '    MsgError(ex.Message)
        'End Try
    End Sub
    Private Sub dg_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg.RowEnter
        'TampilDetail(dg.Item(0, e.RowIndex).Value.ToString)
        'TampilDirect(dg.Item(0, e.RowIndex).Value.ToString)
        'TampilConsingment(dg.Item(0, e.RowIndex).Value.ToString)
    End Sub
    Private Sub dg_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dg.MouseClick
        Dim rowClicked, colClicked As Integer
        If e.Button = Windows.Forms.MouseButtons.Right Then

            rowClicked = dg.HitTest(e.Location.X, e.Location.Y).RowIndex
            colClicked = dg.HitTest(e.Location.X, e.Location.Y).ColumnIndex
            If colClicked = -1 = False And rowClicked = -1 = False Then
                'MsgBox(rowClicked)
                'MsgBox(colClicked)
                dg.CurrentCell = dg(colClicked, rowClicked)
                'If dg.SelectedRows.Count <= 1 Then dg.CurrentCell = dg(0, rowClicked)
                cmsHeader.Show(dg, e.Location)
            End If
        End If
    End Sub

#End Region

#Region "ContextMenuStrip"
    Private Sub FindToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindToolStripMenuItem.Click
        'Convert( tgl, 'System.String') LIKE '%5/20/2016%'
        Dim strFilter, colName, colHeader, txtfilter, title As String
        colName = LCase(dg.Columns(dg.CurrentCell.ColumnIndex).DataPropertyName)
        colHeader = dg.Columns(dg.CurrentCell.ColumnIndex).HeaderText
        title = "Cari " & colHeader
        If isDateColumn(colName) Then title = "Cari " & colHeader & "(MM/dd/yyyy)"
        txtfilter = InputBox(title, "Filter")
        If isDateColumn(colName) Then
            strFilter = lblFilterH.Text & _
                         String.Format(" and (convert({0}, 'System.String') Like '%{1}%') ", _
                         colName, txtfilter)
        Else
            strFilter = lblFilterH.Text & String.Format(" and ({0} like '%{1}%') ", colName, txtfilter)
        End If
        NavSource1.Filter = strFilter
        lblFilterH.Text = strFilter
        PanelFilterH.Visible = True
        showSummaryHeader()
    End Sub
    Private Sub FindToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindToolStripMenuItem1.Click

    End Sub
#End Region
    Private Sub lblClearFilterH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClearFilterH.Click
        PanelFilterH.Visible = False
        lblFilterH.Text = " (0=0) "
        NavSource1.Filter = lblFilterH.Text
        showSummaryHeader()
    End Sub
    Private Sub PrintTandaTerimaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim s As String
        s = ""
        For Each row As DataGridViewRow In dg.SelectedRows
            s = s & "'" & row.Cells("noterima").Value.ToString.Trim & "',"
        Next
        s = " t.noterima in ( " & Mid(s, 1, Len(s) - 1) & " ) "
        If dg.RowCount <= 0 Then Exit Sub
        createReportTandaTerima(s)
    End Sub
    Private Sub cmsPrint_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsPrint.Opening

    End Sub

    Private Sub DirectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DirectToolStripMenuItem.Click
        addData()
    End Sub
    Private Sub ConsignmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsignmentToolStripMenuItem.Click

    End Sub
    Private Sub dtEnddate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtEnddate.KeyDown
        If e.KeyCode = 13 Then
            reloadClick()
        End If
    End Sub
    Private Sub dtEnddate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtEnddate.ValueChanged

    End Sub
    Private Sub dtStartdate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtStartdate.KeyDown
        If e.KeyCode = 13 Then
            reloadClick()
        End If
    End Sub
    Private Sub dtStartdate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtStartdate.ValueChanged

    End Sub

    Private Sub dgConsignment_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub dgDirect_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub dgDirect_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        editData()
    End Sub

    Private Sub dgConsignment_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        editData()
    End Sub

    Private Sub LaporanBelumBayarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub LaporanSudahBayarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub InputTglBayarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtSPG_Barcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSPG_Barcode.TextChanged
        FilterTextDefault()
    End Sub
    Sub FilterTextDefault()
        Dim strFilter As String = ""
        If txtSPG_Barcode.Text.Trim = "" Then
            PanelFilterH.Visible = False
            lblFilterH.Text = " (0=0) "
            NavSource1.Filter = lblFilterH.Text
            txtTotalDataH.Text = "Total Data : " & dg.RowCount
        Else
            strFilter = " convert(employee_id, 'System.String') like '%" & txtSPG_Barcode.Text.Trim & "%' or " & vbCrLf & _
                        "name like '%" & txtSPG_Barcode.Text.Trim & "%' or " & vbCrLf & _
                        "noktp like '%" & txtSPG_Barcode.Text.Trim & "%' or " & vbCrLf & _
                        "nip like '%" & txtSPG_Barcode.Text.Trim & "%' "
            lblFilterH.Text = strFilter
            NavSource1.Filter = strFilter
            txtTotalDataH.Text = "Total Data : " & dg.RowCount
            PanelFilterH.Visible = True
        End If
    End Sub

    Private Sub BtnNonAktif_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNonAktif.Click
        TampilTable(" (0=0) ", _
                    " (isactive='NO') ")
        FilterTextDefault()
        txtSPG_Barcode.Focus()
    End Sub

    Private Sub BtnAktif_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAktif.Click
        TampilTable()
        FilterTextDefault()
        txtSPG_Barcode.Focus()
    End Sub

    Private Sub EmployeeTable_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txtSPG_Barcode.Clear()
        txtSPG_Barcode.Focus()
    End Sub
End Class