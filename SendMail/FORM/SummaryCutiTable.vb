Public Class SummaryCutiTable
    Dim startdate, enddate As Date
#Region "procedure"
    Sub TampilTable(Optional ByVal syarat As String = " (0=0) ", _
                    Optional ByVal active As String = " (isactive='YES') ", _
                    Optional ByVal SQL As String = "select top 1 * " & vbCrLf & _
                    "from v_scuti " & vbCrLf & _
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

        dg.RowsDefaultCellStyle.BackColor = Color.Bisque
        dg.AlternatingRowsDefaultCellStyle.BackColor = Color.White

        setColumnGrid(dg, "v_scuti")
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
    Sub TampilD1(Optional ByVal syarat As String = " (0=0) ", _
                    Optional ByVal active As String = " (isactive='YES') ", _
                    Optional ByVal SQL As String = "select top 1 employee_cuti_id, employee_id, nip, startdate, enddate, " & vbCrLf & _
                    "totalleave, takenleave, expiredleave, availableleave, case expired when '1' then 'YES' else 'NO' end as expired " & vbCrLf & _
                    "from m_employee_cuti " & vbCrLf & _
                    "where @syarat " & vbCrLf & _
                    "order by startdate desc ")
        Cursor = Cursors.WaitCursor
        Dim dstable As DataSet
        SQL = Replace(SQL, "@syarat", syarat)
        'Dbg(SQL)

        dstable = QueryToDataset(SQL, StrConHRD)
        dg1.Columns.Clear()
        dg1.DataSource = dstable.Tables(0)
        NavD1.DataSource = dstable.Tables(0)
        NavD1.Filter = " (0=0) "

        dg1.RowsDefaultCellStyle.BackColor = Color.Bisque
        dg1.AlternatingRowsDefaultCellStyle.BackColor = Color.White

        setColumnGrid(dg1, "v_scuti1")
        SQL = Replace(SQL, "top 1", "")

        dstable = QueryToDataset(SQL, StrConHRD)
        dg1.DataSource = dstable.Tables(0)
        NavD1.DataSource = dstable.Tables(0)
        NavD1.Filter = " (0=0) "
        'showSummaryHeader()
        Cursor = Cursors.Default
        dg1.Focus()
    End Sub
    Sub TampilD2(Optional ByVal syarat As String = " (0=0) ", _
                    Optional ByVal active As String = " (isactive='YES') ", _
                    Optional ByVal SQL As String = "select top 1 * " & vbCrLf & _
                    "from t_cuti " & vbCrLf & _
                    "where @syarat " & vbCrLf & _
                    "order by startdate desc ")
        Cursor = Cursors.WaitCursor
        Dim dstable As DataSet
        SQL = Replace(SQL, "@syarat", syarat)
        'Dbg(SQL)

        dstable = QueryToDataset(SQL, StrConHRD)
        dg2.Columns.Clear()
        dg2.DataSource = dstable.Tables(0)
        NavD2.DataSource = dstable.Tables(0)
        NavD2.Filter = " (0=0) "

        dg2.RowsDefaultCellStyle.BackColor = Color.Bisque
        dg2.AlternatingRowsDefaultCellStyle.BackColor = Color.White

        setColumnGrid(dg2, "v_scuti2")
        SQL = Replace(SQL, "top 1", "")

        dstable = QueryToDataset(SQL, StrConHRD)
        dg2.DataSource = dstable.Tables(0)
        NavD2.DataSource = dstable.Tables(0)
        NavD2.Filter = " (0=0) "

        'showSummaryHeader()
        Cursor = Cursors.Default
        dg2.Focus()
    End Sub
    Sub showSummaryHeader()
        txtTotalDataH.Text = "Total Data : " & dg.RowCount
    End Sub
    Sub showSummaryD1()
        'Dim x As Integer
        'Dim totalTagihan As Double
        'totalTagihan = 0
        'For x = 0 To dgDirect.RowCount - 1
        '    totalTagihan = totalTagihan + Convert.ToDouble(dgDirect.Item(4, x).Value)
        'Next
        'txtTotalTagihanD1.Text = FormatNumber(totalTagihan, 2)
        'txtTotalDataD1.Text = "Total Data : " & dgDirect.RowCount
    End Sub
    Sub showSummaryD2()
        'Dim x As Integer
        'Dim totalTagihan As Double
        'totalTagihan = 0
        'For x = 0 To dgConsignment.RowCount - 1
        '    totalTagihan = totalTagihan + Convert.ToDouble(dgConsignment.Item(3, x).Value)
        'Next
        'TxtTotaltagihanD2.Text = FormatNumber(totalTagihan, 2)
        'txtTotalDataD2.Text = "Total Data : " & dgConsignment.RowCount
    End Sub
    Sub editData()
        ''TerimaForm2.dtJatuhTempo.Checked = False
        'TerimaFormOK.txtNoTerima.Text = getDataGrid(dg, "noterima").ToString.Trim
        'TerimaFormOK.lblTipe.Text = "update"
        'TerimaFormOK.ShowDialog()
        ''TerimaFormOK.Show()
        'reloadClick()
    End Sub
    Sub addData()
        ''TerimaFormOK.clearALL()
        ''TerimaForm.lblTipe.Text = "update"
        ''TerimaForm2.txtNoTerima.Text = "TRH001-062016-00004"
        'Dim s As String
        's = newTerimaNumber()
        ''TerimaFormOK.txtNoTerima.Text = newTerimaNumber()
        'ExecQuery(String.Format("insert into t_terima (noterima) values ('{0}') ", s))
        'TerimaFormOK.lblTipe.Text = "new"
        'TerimaFormOK.txtTerima.Text = UserLogin
        'TerimaFormOK.lblTambahKW.Enabled = True
        'TerimaFormOK.lblTambahDK.Enabled = True
        ''TerimaFormOK.rbtConsignment.Checked = False
        ''TerimaFormOK.rbtDirect.Checked = True
        'TerimaFormOK.txtNoTerima.Text = s
        'TerimaFormOK.ShowDialog()
        'reloadClick()
    End Sub
    Sub DeleteData()
        'MsgBox("Delete")

        'If MsgConfirm("Anda Yakin Ingin Hapus Data " & dg.SelectedRows.Count & " Record ?") = MsgBoxResult.Yes Then
        '    For Each row As DataGridViewRow In dg.SelectedRows
        '        ExecQuery("delete from t_terima_t2 where noterima= '" & row.Cells("noterima").Value & "' ")
        '        ExecQuery("delete from t_terima_t1 where noterima= '" & row.Cells("noterima").Value & "' ")
        '        ExecQuery("delete from t_terima_c where noterima= '" & row.Cells("noterima").Value & "' ")
        '        ExecQuery("delete from t_terima where noterima= '" & row.Cells("noterima").Value & "' ")
        '    Next
        '    reloadClick()
        'End If
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

        BtnAdd.Visible = False
        BtnEdit.Visible = False
        BtnDelete.Visible = False

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

    Private Sub SummaryCutiTable_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        CloseDBALL()
    End Sub
    Private Sub EmployeeTable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OpenDBHRD()
        LoadImage()
        PanelFilterH.Visible = False
        PanelFilterD1.Visible = False
        PanelFilterD2.Visible = False
        Label1.Text = Me.Text
        validasiButton()
        dtStartdate.Value = Now
        dtEnddate.Value = Now
        reloadClick()
        dg2.Font = lblFont.Font

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
        TampilD1(" (employee_id='" & dg.Item(0, e.RowIndex).Value.ToString.Trim & "') ")
        TampilD2(" (employee_id='" & dg.Item(0, e.RowIndex).Value.ToString.Trim & "') ")
        'Dim x As Integer = 0
        'For Each row As DataGridViewRow In dg.SelectedRows
        '    'ExecQuery("delete from t_terima_t2 where noterima= '" & row.Cells("noterima").Value & "' ")
        '    TampilD1(" (employee_id='" & row.Cells("employee_id").Value.ToString & "') ")
        '    TampilD2(" (employee_id='" & row.Cells("employee_id").Value.ToString & "') ")
        '    If x > 0 Then Exit For
        '    x += 1
        'Next
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
        txtSPG_Barcode.Clear()
        showSummaryHeader()
        txtSPG_Barcode.Focus()
    End Sub
    Private Sub PrintTandaTerimaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

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

    Private Sub dgConsignment_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg2.CellContentClick

    End Sub

    Private Sub dgDirect_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellContentClick

    End Sub

    Private Sub dgDirect_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellContentDoubleClick
        editData()
    End Sub

    Private Sub dgConsignment_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg2.CellContentDoubleClick
        editData()
    End Sub

    Private Sub LaporanBelumBayarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub LaporanSudahBayarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub InputTglBayarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GenerateCutiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerateCutiToolStripMenuItem.Click
        'isiMasterCuti("10")
        PG1.Value = 0
        PG1.Visible = True
        Me.Enabled = False
        BW1.WorkerReportsProgress = True
        BW1.WorkerSupportsCancellation = True
        BW1.RunWorkerAsync()
    End Sub

    Private Sub BW1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BW1.DoWork
        Dim total, no, Prg As Integer
        total = dg.Rows.Count
        no = 0
        For Each row As DataGridViewRow In dg.Rows
            'MsgOK(no)
            Prg = CInt((no * 100) / total)
            BW1.ReportProgress(Prg)
            isiMasterCuti(row.Cells("employee_id").Value.ToString)
            no += 1
        Next
    End Sub

    Private Sub BW1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BW1.ProgressChanged
        PG1.Value = e.ProgressPercentage
    End Sub

    Private Sub BW1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BW1.RunWorkerCompleted
        PG1.Value = 0
        PG1.Visible = False
        Me.Enabled = True
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

    Private Sub SummaryCutiTable_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txtSPG_Barcode.Focus()
    End Sub

    Private Sub txtSPG_Barcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSPG_Barcode.TextChanged
        FilterTextDefault()
    End Sub
End Class