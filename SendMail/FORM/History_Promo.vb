Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.Shared
Imports Microsoft.Office.Interop
Imports System.Data.SqlClient
Public Class History_Promo
    Dim DocNo, Promo_ID, c_limit, c_voucher, c_kelipatan, c_layar, c_struk, branch, txt1ID, txt2ID, c_allItem, c_Rafaksi As String
    Dim DsPromo, DsHeader, DsDetail, DsCekTransfer As DataSet
    Dim cryRpt As New ReportDocument
    Dim t_Load As Boolean = False
    Dim p_Edit As Boolean
    Dim myStream As Stream = Nothing
    Dim openFileDialog1 As New OpenFileDialog()
    Dim ds_CheckMaster As New DataSet
    Dim sbu, dept, brand As String
    Dim TotArt As Integer = 0
    Dim Prg As Decimal = 0
    Dim Ecount As Integer = 0
    Dim prid As String = ""
    Dim totalart, totalinc As Integer
    Private Sub History_Promo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m_SqlconnPromo = "Data Source=" & m_ServerNamePromo & ";" & "Initial Catalog=" & m_DBNamePromo & ";" & "User ID=" & m_UserNamePromo & ";" & "Password=" & m_PasswordPromo & ";"
        cmbPromo(CmbTipe, "select Promo_ID,promo_name from promo_master where status = 1 order by Convert(INT,Promo_ID)", "Promo_ID", "promo_name", 1)
        cmbBank(cbBank1, "select Distinct RTRIM(Code) as Code from Bin_Kartu where Keterangan = 'Kartu Kredit' Order by Code", "Code", "Code", 1)
        cmbBank(cbBank2, "select Distinct RTRIM(Code) as Code from Bin_Kartu where Keterangan = 'Kartu Debit' Order by Code", "Code", "Code", 1)
        t_Load = True

        cbGender.Items.Add("M")
        cbGender.Items.Add("F")
        cbGender.SelectedIndex = 0
        CmbTipe.SelectedValue = "02"
        DateTimePicker1.Value = Month(DateTimePicker1.Value) & "/01/" & Year(DateTimePicker1.Value)
        If GrpId = "6" And PromoGrpUsr <> "" Then
            DsHeader = getSqldbPromo("Select a.*,b.total_artikel,b.total_inc from promo_hdr_history a left join Other_Detail_history b on a.branch_id = b.branch_id and a.doc_no = b.doc_no where start_date between '" & DateTimePicker1.Value & "' and '" & DateTimePicker2.Value & "' and updBy in (" & PromoGrpUsr & ") Order by UpdDt desc")
        ElseIf GrpId = "0" Then
            DsHeader = getSqldbPromo("Select a.*,b.total_artikel,b.total_inc from promo_hdr_history a left join Other_Detail_history b on a.branch_id = b.branch_id and a.doc_no = b.doc_no where start_date between '" & DateTimePicker1.Value & "' and '" & DateTimePicker2.Value & "' Order by UpdDt desc")
        Else
            DsHeader = getSqldbPromo("Select a.*,b.total_artikel,b.total_inc from promo_hdr_history a left join Other_Detail_history b on a.branch_id = b.branch_id and a.doc_no = b.doc_no where start_date between '" & DateTimePicker1.Value & "' and '" & DateTimePicker2.Value & "' and  updBy = '" & UsrID & "' Order by UpdDt desc")
        End If

        If DsHeader.Tables(0).Rows.Count > 0 Then
            dgvPromo.DataSource = DsHeader.Tables(0)
            dgvPromo.Columns("total_artikel").Visible = False
            dgvPromo.Columns("total_inc").Visible = False
            dgvPromo.Columns("voucher").Visible = False
            dgvPromo.Columns("lipat").Visible = False
            dgvPromo.Columns("ismsg").Visible = False
            dgvPromo.Columns("isprn").Visible = False
            dgvPromo.Columns("islimit").Visible = False
            dgvPromo.Columns("qtylimit").Visible = False
            dgvPromo.Columns("qtyout").Visible = False
            dgvPromo.Columns("txt1").Visible = False
            dgvPromo.Columns("txt2").Visible = False
            dgvPromo.Columns("txt3").Visible = False
            dgvPromo.Columns("txt4").Visible = False
            If GrpId = "6" Or GrpId = "0" Then
            Else
                dgvPromo.Columns("updby").Visible = False
            End If
            dgvPromo.Columns("statusH").Visible = False
            dgvPromo.Columns("statusD").Visible = False
            dgvPromo.Columns("statusO").Visible = False
            dgvPromo.Columns("transfer").Visible = False
            dgvPromo.Columns("AllItemFlag").Visible = False
            dgvPromo.Columns("UpdDt").Visible = False
            dgvPromo.Columns("aktif").Visible = False
            dgvPromo.Columns("Rafaksi").Visible = False
            dgvPromo.Columns("doc_no").Visible = False
            dgvPromo.Columns("Branch_ID").HeaderText = "Store "
            dgvPromo.Columns("promo_id").HeaderText = "Promo ID "
            dgvPromo.Columns("promo_name").HeaderText = "Promo Name "
            dgvPromo.Columns("start_date").HeaderText = "Start Date "
            dgvPromo.Columns("end_date").HeaderText = "End Date "
            dgvPromo.Columns("min_purchase").HeaderText = "Min Non Member "
            dgvPromo.Columns("min_purchase").HeaderText = "Min Member "
            dgvPromo.Columns("disc").HeaderText = "Disc "
            dgvPromo.Columns("tipe").HeaderText = "Tipe Promo "
            dgvPromo.Columns("start_date").DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss"
            dgvPromo.Columns("end_date").DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss"
            dgvPromo.Columns("min_purchase").DefaultCellStyle.Format = "N0"
            dgvPromo.Columns("min_member").DefaultCellStyle.Format = "N0"
            dgvPromo.Refresh()
            dgvPromo_CellClick(dgvPromo, New DataGridViewCellEventArgs(0, 0))
        End If

        CheckForIllegalCrossThreadCalls = False
        txtDesc.Focus()
        p_Edit = False
        Clear()
    End Sub

    Private Sub txtdisc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
    txtLimit.KeyPress, txtMinPurcMem.KeyPress, txtMinPurcNon.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub


    Private Sub CmbTipe_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbTipe.SelectedIndexChanged
        If t_Load = True Then
            If p_Edit = True Then
                Exit Sub
            End If
            Select Case CInt(CmbTipe.SelectedValue)
                Case 2, 3, 6, 11, 26
                    OnOffCtrl(True, False, False, False, False, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Discount"
                    cbDisc2.Text = "Disc Add"
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    txtDisc2.Text = 0
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                Case 27
                    OnOffCtrl(True, False, False, False, False, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Discount"
                    cbDisc2.Text = "Disc Add"
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    txtDisc2.Text = 17
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                Case 4
                    OnOffCtrl(True, True, False, False, False, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Discount"
                    cbDisc2.Text = "Add MSC"
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    'txtMinPurcNon.Text = 999999999
                    'txtDisc2.Text = 10
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                Case 8, 15
                    OnOffCtrl(True, True, False, False, True, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Discount"
                    cbDisc2.Text = "Disc Add"
                    cbDisc2.Checked = True
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    txtDisc2.Text = 0
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                Case 17
                    OnOffCtrl(True, True, False, False, True, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Disc Buy2"
                    cbDisc2.Text = "Disc Buy3"
                    cbDisc2.Checked = True
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    txtDisc2.Text = 0
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                Case 23
                    OnOffCtrl(True, True, False, False, True, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Disc Buy2"
                    cbDisc2.Text = "Disc Buy3"
                    cbDisc2.Checked = True
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    txtDisc2.Text = 0
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                Case 18
                    OnOffCtrl(True, True, False, False, True, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Disc Buy1"
                    cbDisc2.Text = "Disc Buy2"
                    cbDisc2.Checked = True
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    txtDisc2.Text = 0
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                Case 7, 29
                    OnOffCtrl(True, True, False, False, True, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Disc MSC"
                    cbDisc2.Text = "Disc Non"
                    cbDisc2.Checked = True
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    txtDisc2.Text = 0
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                Case 31, 35, 37
                    OnOffCtrl(False, False, True, False, False, True, True, True, True)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Discount"
                    cbDisc2.Text = "Disc Add"
                    cbDisc2.Checked = False
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    txtLayar1.Enabled = False
                    txtLayar2.Enabled = False
                    txtDisc2.Text = 0
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                Case 40
                    OnOffCtrl(False, False, True, False, False, True, True, True, True)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Discount"
                    cbDisc2.Text = "Disc Add"
                    cbDisc2.Checked = False
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    txtMinPurcNon.Text = 999999999
                    txtLayar1.Enabled = False
                    txtLayar2.Enabled = False
                    txtDisc2.Text = 0
                    cbMinPurcNon.Enabled = False
                Case 50
                    OnOffCtrl(True, True, True, False, False, True, True, True, True)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Credit"
                    cbDisc2.Text = "Debit"
                    cbDisc2.Checked = False
                    cbDisc.Checked = False
                    cbGender.Visible = False
                    cbBank1.Visible = True
                    cbBank2.Visible = True
                    cbBank1.Enabled = False
                    cbBank2.Enabled = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    txtLayar1.Enabled = False
                    txtLayar2.Enabled = False
                    txtDisc2.Text = 0
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                Case 19
                    OnOffCtrl(True, False, False, False, False, False, False, False, False)
                    'ToolStripMenuItem9.Visible = True
                    cbDisc.Text = "Discount"
                    cbDisc2.Text = "Disc Add"
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    txtDisc2.Text = 0
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                Case 20
                    OnOffCtrl(True, True, False, True, True, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Buy "
                    cbDisc2.Text = "Get "
                    cbDisc.Checked = True
                    cbDisc2.Checked = True
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    txtDisc2.Text = 0
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                    txtDisc.Focus()
                Case 21
                    OnOffCtrl(True, True, False, True, True, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Discount "
                    cbDisc2.Text = "Gender "
                    cbDisc.Checked = True
                    cbDisc2.Checked = True
                    cbGender.Visible = True
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    txtDisc2.Text = 0
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                    txtDisc.Focus()
            End Select
        End If
    End Sub

    Sub OnOffCtrl(ByVal disc1 As Boolean, ByVal disc2 As Boolean, ByVal limit As Boolean, ByVal disc1txt As Boolean, _
                  ByVal disc2txt As Boolean, ByVal limittxt As Boolean, ByVal layar As Boolean, ByVal struk As Boolean, ByVal layartxt As Boolean)
        cbDisc.Enabled = disc1
        cbDisc2.Enabled = disc2
        cbLimit.Enabled = limit
        txtDisc.Enabled = disc1txt
        txtDisc2.Enabled = disc2txt
        txtLimit.Enabled = limittxt
        cbMsgLayar.Enabled = layar
        cbStruk.Enabled = struk
        txtLayar1.Enabled = layartxt
        txtLayar2.Enabled = layartxt
    End Sub

    

    Sub Ulang()
        dgvPromo.DataSource = Nothing
        If GrpId = "6" And PromoGrpUsr <> "" Then
            DsHeader = getSqldbPromo("Select a.*,b.total_artikel,b.total_inc from promo_hdr_history a left join Other_Detail_history b on a.branch_id = b.branch_id and a.doc_no = b.doc_no where start_date between '" & DateTimePicker1.Value & "' and '" & DateTimePicker2.Value & "' and updBy in (" & PromoGrpUsr & ") Order by UpdDt desc")
        ElseIf GrpId = "0" Then
            DsHeader = getSqldbPromo("Select a.*,b.total_artikel,b.total_inc from promo_hdr_history a left join Other_Detail_history b on a.branch_id = b.branch_id and a.doc_no = b.doc_no where start_date between '" & DateTimePicker1.Value & "' and '" & DateTimePicker2.Value & "' Order by UpdDt desc")
        Else
            DsHeader = getSqldbPromo("Select a.*,b.total_artikel,b.total_inc from promo_hdr_history a left join Other_Detail_history b on a.branch_id = b.branch_id and a.doc_no = b.doc_no where start_date between '" & DateTimePicker1.Value & "' and '" & DateTimePicker2.Value & "' and  updBy = '" & UsrID & "' Order by UpdDt desc")
        End If
        If DsHeader.Tables(0).Rows.Count > 0 Then
            dgvPromo.DataSource = DsHeader.Tables(0)
            dgvPromo.Columns("total_artikel").Visible = False
            dgvPromo.Columns("total_inc").Visible = False
            dgvPromo.Columns("voucher").Visible = False
            dgvPromo.Columns("lipat").Visible = False
            dgvPromo.Columns("ismsg").Visible = False
            dgvPromo.Columns("isprn").Visible = False
            dgvPromo.Columns("islimit").Visible = False
            dgvPromo.Columns("qtylimit").Visible = False
            dgvPromo.Columns("qtyout").Visible = False
            dgvPromo.Columns("txt1").Visible = False
            dgvPromo.Columns("txt2").Visible = False
            dgvPromo.Columns("txt3").Visible = False
            dgvPromo.Columns("txt4").Visible = False
            If GrpId = "6" Or GrpId = "0" Then
            Else
                dgvPromo.Columns("updby").Visible = False
            End If
            dgvPromo.Columns("statusH").Visible = False
            dgvPromo.Columns("statusD").Visible = False
            dgvPromo.Columns("statusO").Visible = False
            dgvPromo.Columns("transfer").Visible = False
            dgvPromo.Columns("AllItemFlag").Visible = False
            dgvPromo.Columns("UpdDt").Visible = False
            dgvPromo.Columns("aktif").Visible = False
            dgvPromo.Columns("Rafaksi").Visible = False
            dgvPromo.Columns("doc_no").Visible = False
            dgvPromo.Columns("Branch_ID").HeaderText = "Store "
            dgvPromo.Columns("promo_id").HeaderText = "Promo ID "
            dgvPromo.Columns("promo_name").HeaderText = "Promo Name "
            dgvPromo.Columns("start_date").HeaderText = "Start Date "
            dgvPromo.Columns("end_date").HeaderText = "End Date "
            dgvPromo.Columns("min_purchase").HeaderText = "Min Non Member "
            dgvPromo.Columns("min_purchase").HeaderText = "Min Member "
            dgvPromo.Columns("disc").HeaderText = "Disc "
            dgvPromo.Columns("tipe").HeaderText = "Tipe Promo "
            dgvPromo.Columns("start_date").DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss"
            dgvPromo.Columns("end_date").DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss"
            dgvPromo.Refresh()
            dgvPromo_CellClick(dgvPromo, New DataGridViewCellEventArgs(0, 0))
        End If
        txtDesc.Focus()
    End Sub

    Private Sub cbDisc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDisc.CheckedChanged
        If cbDisc.Checked = True Then
            txtDisc.Enabled = True
            cbBank1.Enabled = True
            txtDisc.Clear()
            txtDisc.Focus()
        Else
            txtDisc.Enabled = False
            cbBank1.Enabled = False
            txtDisc.Text = 0
        End If
    End Sub

    Private Sub cbLimit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLimit.CheckedChanged
        If cbLimit.Checked = True Then
            txtLimit.Enabled = True
            txtLimit.Clear()
            txtLimit.Focus()
        Else
            txtLimit.Enabled = False
            txtLimit.Text = 0
        End If
    End Sub

    Private Sub cbMinPurcNon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMinPurcNon.CheckedChanged
        If cbMinPurcNon.Checked = True Then
            txtMinPurcNon.Enabled = True
            txtMinPurcNon.Clear()
            txtMinPurcNon.Focus()
        Else
            txtMinPurcNon.Enabled = False
            txtMinPurcNon.Text = 10000
        End If
    End Sub

    Private Sub cbMinPurcMem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMinPurcMem.CheckedChanged
        If cbMinPurcMem.Checked = True Then
            txtMinPurcMem.Enabled = True
            txtMinPurcMem.Clear()
            txtMinPurcMem.Focus()
        Else
            txtMinPurcMem.Enabled = False
            txtMinPurcMem.Text = 10000
        End If
    End Sub

    Private Sub txtDisc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDisc.TextChanged
        If txtDisc.Text <> "" Then
            txtDisc.Text = CDec(txtDisc.Text).ToString("N0")
            txtDisc.SelectionStart = txtDisc.TextLength
        End If
    End Sub

    Private Sub txtLimit_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLimit.TextChanged
        If txtLimit.Text <> "" Then
            txtLimit.Text = CDec(txtLimit.Text).ToString("N0")
            txtLimit.SelectionStart = txtLimit.TextLength
        End If
    End Sub

    Private Sub txtMinPurcMem_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMinPurcMem.TextChanged
        If txtMinPurcMem.Text <> "" Then
            txtMinPurcMem.Text = CDec(txtMinPurcMem.Text).ToString("N0")
            txtMinPurcMem.SelectionStart = txtMinPurcMem.TextLength
        End If
    End Sub

    Private Sub txtMinPurcNon_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMinPurcNon.TextChanged
        If txtMinPurcNon.Text <> "" Then
            txtMinPurcNon.Text = CDec(txtMinPurcNon.Text).ToString("N0")
            txtMinPurcNon.SelectionStart = txtMinPurcNon.TextLength
        End If
    End Sub

    Private Sub clbStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clbStore.Click
        clbStore.CheckOnClick = True
    End Sub

    Private Sub dgvPromo_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPromo.CellClick
        Try
            p_Edit = True
            txtDocNo.Enabled = False
            clbStore.Enabled = False
            CmbTipe.Enabled = False
            txtLayar1.Clear()
            txtLayar2.Clear()

            For idx As Integer = 0 To clbStore.Items.Count - 1
                Me.clbStore.SetItemCheckState(idx, CheckState.Unchecked)
            Next
            For Each checkBox In clbStore.Items
                If dgvPromo.Item(0, e.RowIndex).Value = Microsoft.VisualBasic.Left(checkBox.ToString, 4) Then
                    clbStore.SetItemChecked(clbStore.Items.IndexOf(checkBox), CheckState.Checked)
                    Exit For
                End If
            Next

            If dgvPromo.Item("tipe", e.RowIndex).Value.ToString.Length = 1 Then
                CmbTipe.SelectedValue = "0" & dgvPromo.Item("tipe", e.RowIndex).Value.ToString.Trim
            Else
                CmbTipe.SelectedValue = dgvPromo.Item("tipe", e.RowIndex).Value.ToString.Trim()
            End If

            CmbTipe_SelectedValueChanged(sender, e)

            branch = dgvPromo.Item("Branch_ID", e.RowIndex).Value
            txtDocNo.Text = dgvPromo.Item("doc_no", e.RowIndex).Value
            DocNo = txtDocNo.Text
            txtDesc.Text = dgvPromo.Item("promo_name", e.RowIndex).Value
            Promo_ID = dgvPromo.Item("promo_id", e.RowIndex).Value
            PromoTypex = dgvPromo.Item("tipe", e.RowIndex).Value
            If dgvPromo.Item("tipe", e.RowIndex).Value.ToString <> "21" Then
                If dgvPromo.Item("txt1", e.RowIndex).Value.ToString = "" Then
                    txt1ID = ""
                Else
                    If CInt(dgvPromo.Item("tipe", e.RowIndex).Value.ToString) < 30 Then
                        txt1ID = dgvPromo.Item("txt1", e.RowIndex).Value
                    Else
                        txt1ID = ""
                    End If
                End If
            End If

            If dgvPromo.Item("tipe", e.RowIndex).Value.ToString = "23" Then
                txt2ID = dgvPromo.Item("txt2", e.RowIndex).Value
            End If



            dtpForm.Value = CDate(dgvPromo.Item("start_date", e.RowIndex).Value)
            dtpFromtime.Value = CDate(dgvPromo.Item("start_date", e.RowIndex).Value)
            dtpTo.Value = CDate(dgvPromo.Item("end_date", e.RowIndex).Value)
            dtpTotime.Value = CDate(dgvPromo.Item("end_date", e.RowIndex).Value)
            If dgvPromo.Item("disc", e.RowIndex).Value.ToString.Trim() = "0" Then
                cbDisc.Checked = False
                txtDisc.Text = 0
            Else
                cbDisc.Checked = True
                txtDisc.Text = dgvPromo.Item("disc", e.RowIndex).Value.ToString.Trim()
            End If

            If dgvPromo.Item("AllItemFlag", e.RowIndex).Value.ToString.Trim() = "0" Then
                CbAllItem.Checked = False
            Else
                CbAllItem.Checked = True
            End If

            If dgvPromo.Item("Rafaksi", e.RowIndex).Value.ToString.Trim() = "0" Then
                cbRafaksi.Checked = False
            Else
                cbRafaksi.Checked = True
            End If

            Select Case CmbTipe.SelectedValue
                Case "04", "07", "08", "15", "17", "18", "29", "23"
                    cbDisc2.Enabled = True
                    cbDisc2.Checked = True
                    txtDisc2.Text = dgvPromo.Item("txt1", e.RowIndex).Value.ToString.Trim()
                Case "20"
                    cbDisc.Checked = True
                    cbDisc2.Checked = True
                    txtDisc.Text = Microsoft.VisualBasic.Left(dgvPromo.Item("txt1", e.RowIndex).Value.ToString.Trim(), 1)
                    txtDisc2.Text = Microsoft.VisualBasic.Right(dgvPromo.Item("txt1", e.RowIndex).Value.ToString.Trim(), 1)
                Case "21"
                    cbDisc.Checked = True
                    cbDisc2.Checked = True
                    txtDisc.Text = dgvPromo.Item("disc", e.RowIndex).Value.ToString.Trim()
                    cbGender.SelectedText = dgvPromo.Item("txt1", e.RowIndex).Value.ToString.Trim()
                Case "50"
                    cbDisc.Text = "Credit"
                    cbDisc2.Text = "Debit"
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    cbDisc.Enabled = True
                    cbDisc2.Enabled = True
                    cbBank1.Enabled = False
                    cbBank2.Enabled = False
                    If Microsoft.VisualBasic.Left(dgvPromo.Item("txt3", e.RowIndex).Value.ToString.Trim(), 1) = "1" Then
                        cbDisc.Checked = True
                        cbBank1.SelectedValue = Microsoft.VisualBasic.Mid(dgvPromo.Item("txt3", e.RowIndex).Value.ToString.Trim(), 2, 5).ToString.Trim()
                    End If
                    If Microsoft.VisualBasic.Left(dgvPromo.Item("txt4", e.RowIndex).Value.ToString.Trim(), 1) = "1" Then
                        cbDisc2.Checked = True
                        cbBank2.SelectedValue = Microsoft.VisualBasic.Mid(dgvPromo.Item("txt4", e.RowIndex).Value.ToString.Trim(), 2, 5).ToString.Trim()
                    End If
            End Select
            If dgvPromo.Item("islimit", e.RowIndex).Value.ToString.Trim() = "0" Then
                cbLimit.Checked = False
                txtLimit.Text = 0
            Else
                cbLimit.Checked = True
                txtLimit.Text = dgvPromo.Item("islimit", e.RowIndex).Value.ToString.Trim()
            End If
            If dgvPromo.Item("voucher", e.RowIndex).Value.ToString.Trim() = "0" Then
                cbPembVoucher.Checked = False
            Else
                cbPembVoucher.Checked = True
            End If
            If dgvPromo.Item("min_purchase", e.RowIndex).Value.ToString.Trim() = "10000" Then
                cbMinPurcNon.Checked = False
                txtMinPurcNon.Text = 10000
            Else
                cbMinPurcNon.Checked = True
                txtMinPurcNon.Text = dgvPromo.Item("min_purchase", e.RowIndex).Value.ToString.Trim()
            End If
            If dgvPromo.Item("min_member", e.RowIndex).Value.ToString.Trim() = "10000" Then
                cbMinPurcMem.Checked = False
                txtMinPurcMem.Text = 10000
            Else
                cbMinPurcMem.Checked = True
                txtMinPurcMem.Text = dgvPromo.Item("min_member", e.RowIndex).Value.ToString.Trim()
            End If
            If dgvPromo.Item("lipat", e.RowIndex).Value.ToString.Trim() = "0" Then
                cbKelipatan.Checked = False
            Else
                cbKelipatan.Checked = True
            End If
            If dgvPromo.Item("ismsg", e.RowIndex).Value.ToString.Trim() = "0" Then
                cbMsgLayar.Checked = False
            Else
                cbMsgLayar.Checked = True
                txtLayar1.Text = dgvPromo.Item("txt1", e.RowIndex).Value.ToString.Trim()
                txtLayar2.Text = dgvPromo.Item("txt2", e.RowIndex).Value.ToString.Trim()
            End If
            If dgvPromo.Item("isprn", e.RowIndex).Value.ToString.Trim() = "0" Then
                cbStruk.Checked = False
            Else
                cbStruk.Checked = True
                txtLayar1.Text = dgvPromo.Item("txt1", e.RowIndex).Value.ToString.Trim()
                txtLayar2.Text = dgvPromo.Item("txt2", e.RowIndex).Value.ToString.Trim()
            End If
            If dgvPromo.Item("statusH", e.RowIndex).Value.ToString.Trim() = "1" Then
                cbH.Checked = True
            Else
                cbH.Checked = False
            End If
            If dgvPromo.Item("statusD", e.RowIndex).Value.ToString.Trim() = "1" Then
                cbD.Checked = True
            Else
                cbD.Checked = False
            End If
            If dgvPromo.Item("statusO", e.RowIndex).Value.ToString.Trim() = "1" Then
                cbO.Checked = True
            Else
                cbO.Checked = False
            End If
            If dgvPromo.Item("transfer", e.RowIndex).Value.ToString.Trim() = "0" Then
                GroupBox1.Enabled = True

                txtDesc.Enabled = True
                'GroupBox4.Enabled = True
            Else
                GroupBox1.Enabled = False

                txtDesc.Enabled = False
                'GroupBox4.Enabled = False
            End If
            totalart = dgvPromo.Item("total_artikel", e.RowIndex).Value.ToString.Trim()
            totalinc = dgvPromo.Item("total_inc", e.RowIndex).Value.ToString.Trim()
            txtDesc.Select()
            txtDesc.Focus()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub


    Sub Clear()
        For idx As Integer = 0 To clbStore.Items.Count - 1
            Me.clbStore.SetItemCheckState(idx, CheckState.Unchecked)
        Next
        clbStore.Enabled = True
        cbH.Checked = False
        cbD.Checked = False
        cbO.Checked = False
        CbAllItem.Checked = False
        cbRafaksi.Checked = False
        CmbTipe.Enabled = True
        CmbTipe.SelectedValue = "02"
        txtDesc.Clear()
        dtpForm.Value = Now.Date.AddDays(AtlsDay * -1)
        dtpFromtime.Value = Now.Date & " 10:00:00"
        dtpTo.Value = Now.Date.AddDays(AtlsDay * -1)
        dtpTotime.Value = Now.Date & " 23:59:59"
        cbDisc.Checked = False
        cbDisc2.Checked = False
        'ToolStripMenuItem9.Visible = False
        cbDisc.Text = "Discount"
        cbDisc2.Text = "Disc Add"
        cbGender.Visible = False
        cbKelipatan.Checked = False
        cbLimit.Checked = False
        cbMinPurcMem.Checked = False
        cbMinPurcNon.Checked = False
        cbMsgLayar.Checked = False
        cbPembVoucher.Checked = False
        cbStruk.Checked = False
        GroupBox1.Enabled = True
        txtDesc.Enabled = True
        'GroupBox4.Enabled = True
        txtLayar1.Clear()
        txtLayar2.Clear()
        txtDesc.Focus()
    End Sub

    Sub Clear2()
        For idx As Integer = 0 To clbStore.Items.Count - 1
            Me.clbStore.SetItemCheckState(idx, CheckState.Unchecked)
        Next
        cbH.Checked = False
        cbD.Checked = False
        cbO.Checked = False
        CmbTipe.Enabled = True
        txtDesc.Clear()
        txtDocNo.Clear()
        dtpForm.Value = Now.Date
        dtpFromtime.Value = Now.Date
        dtpTo.Value = Now.Date
        dtpTotime.Value = Now.Date
        cbDisc.Checked = False
        cbDisc2.Checked = False
        'ToolStripMenuItem9.Visible = False
        cbDisc.Text = "Discount"
        cbDisc2.Text = "Disc Add"
        cbGender.Visible = False
        cbKelipatan.Checked = False
        cbLimit.Checked = False
        cbMinPurcMem.Checked = False
        cbMinPurcNon.Checked = False
        cbMsgLayar.Checked = False
        cbPembVoucher.Checked = False
        cbStruk.Checked = False
        txtLayar1.Clear()
        txtLayar2.Clear()
        txtDocNo.Enabled = True
        txtDocNo.Focus()
    End Sub

    
    Private Sub cbDisc2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDisc2.CheckedChanged
        If cbDisc2.Checked = True Then
            txtDisc2.Enabled = True
            cbBank2.Enabled = True
            txtDisc2.Clear()
            txtDisc2.Focus()
        Else
            txtDisc2.Enabled = False
            cbBank2.Enabled = False
            txtDisc2.Text = 0
        End If
    End Sub

    Private Sub CmbTipe_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbTipe.SelectedValueChanged
        If t_Load = True Then
            If p_Edit = True Then
                Exit Sub
            End If
            Select Case CInt(CmbTipe.SelectedValue)
                Case 2, 3, 6, 11, 26
                    OnOffCtrl(True, False, False, False, False, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Discount"
                    cbDisc2.Text = "Disc Add"
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    txtDisc2.Text = 0
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                Case 27
                    OnOffCtrl(True, False, False, False, False, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Discount"
                    cbDisc2.Text = "Disc Add"
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    txtDisc2.Text = 17
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                Case 4
                    OnOffCtrl(True, True, False, False, False, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Discount"
                    cbDisc2.Text = "Add MSC"
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    'txtMinPurcNon.Text = 999999999
                    'txtDisc2.Text = 10
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                Case 8, 15
                    OnOffCtrl(True, True, False, False, True, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Discount"
                    cbDisc2.Text = "Disc Add"
                    cbDisc2.Checked = True
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    txtDisc2.Text = 0
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                Case 17
                    OnOffCtrl(True, True, False, False, True, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Disc Buy2"
                    cbDisc2.Text = "Disc Buy3"
                    cbDisc2.Checked = True
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    txtDisc2.Text = 0
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                Case 23
                    OnOffCtrl(True, True, False, False, True, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Disc Buy2"
                    cbDisc2.Text = "Disc Buy3"
                    cbDisc2.Checked = True
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    txtDisc2.Text = 0
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                Case 18
                    OnOffCtrl(True, True, False, False, True, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Disc Buy1"
                    cbDisc2.Text = "Disc Buy2"
                    cbDisc2.Checked = True
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    txtDisc2.Text = 0
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                Case 7, 29
                    OnOffCtrl(True, True, False, False, True, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Disc MSC"
                    cbDisc2.Text = "Disc Non"
                    cbDisc2.Checked = True
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    txtDisc2.Text = 0
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                Case 31, 35, 37
                    OnOffCtrl(False, False, True, False, False, True, True, True, True)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Discount"
                    cbDisc2.Text = "Disc Add"
                    cbDisc2.Checked = False
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    txtLayar1.Enabled = False
                    txtLayar2.Enabled = False
                    txtDisc2.Text = 0
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                Case 40
                    OnOffCtrl(False, False, True, False, False, True, True, True, True)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Discount"
                    cbDisc2.Text = "Disc Add"
                    cbDisc2.Checked = False
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    txtMinPurcNon.Text = 999999999
                    txtLayar1.Enabled = False
                    txtLayar2.Enabled = False
                    txtDisc2.Text = 0
                    cbMinPurcNon.Enabled = False
                Case 50
                    OnOffCtrl(True, True, True, False, False, True, True, True, True)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Credit"
                    cbDisc2.Text = "Debit"
                    cbDisc2.Checked = False
                    cbDisc.Checked = False
                    cbGender.Visible = False
                    cbBank1.Visible = True
                    cbBank2.Visible = True
                    cbBank1.Enabled = False
                    cbBank2.Enabled = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    txtLayar1.Enabled = False
                    txtLayar2.Enabled = False
                    txtDisc2.Text = 0
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                Case 19
                    OnOffCtrl(True, False, False, False, False, False, False, False, False)
                    'ToolStripMenuItem9.Visible = True
                    cbDisc.Text = "Discount"
                    cbDisc2.Text = "Disc Add"
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    txtDisc2.Text = 0
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                Case 20
                    OnOffCtrl(True, True, False, True, True, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Buy "
                    cbDisc2.Text = "Get "
                    cbDisc.Checked = True
                    cbDisc2.Checked = True
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    txtDisc2.Text = 0
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                    txtDisc.Focus()
                Case 21
                    OnOffCtrl(True, True, False, True, True, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Discount "
                    cbDisc2.Text = "Gender "
                    cbDisc.Checked = True
                    cbDisc2.Checked = True
                    cbGender.Visible = True
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    txtDisc2.Text = 0
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                    txtDisc.Focus()
            End Select
        End If
    End Sub

    Private Sub CmbTipe_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbTipe.TabIndexChanged
        If t_Load = True Then
            If p_Edit = True Then
                Exit Sub
            End If
            Select Case CInt(CmbTipe.SelectedValue)
                Case 2, 3, 6, 11, 26
                    OnOffCtrl(True, False, False, False, False, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Discount"
                    cbDisc2.Text = "Disc Add"
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    txtDisc2.Text = 0
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                Case 27
                    OnOffCtrl(True, False, False, False, False, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Discount"
                    cbDisc2.Text = "Disc Add"
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    txtDisc2.Text = 17
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                Case 4
                    OnOffCtrl(True, True, False, False, False, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Discount"
                    cbDisc2.Text = "Add MSC"
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    'txtMinPurcNon.Text = 999999999
                    'txtDisc2.Text = 10
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                Case 8, 15
                    OnOffCtrl(True, True, False, False, True, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Discount"
                    cbDisc2.Text = "Disc Add"
                    cbDisc2.Checked = True
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    txtDisc2.Text = 0
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                Case 17
                    OnOffCtrl(True, True, False, False, True, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Disc Buy2"
                    cbDisc2.Text = "Disc Buy3"
                    cbDisc2.Checked = True
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    txtDisc2.Text = 0
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                Case 23
                    OnOffCtrl(True, True, False, False, True, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Disc Buy2"
                    cbDisc2.Text = "Disc Buy3"
                    cbDisc2.Checked = True
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    txtDisc2.Text = 0
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                Case 18
                    OnOffCtrl(True, True, False, False, True, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Disc Buy1"
                    cbDisc2.Text = "Disc Buy2"
                    cbDisc2.Checked = True
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    txtDisc2.Text = 0
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                Case 7, 29
                    OnOffCtrl(True, True, False, False, True, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Disc MSC"
                    cbDisc2.Text = "Disc Non"
                    cbDisc2.Checked = True
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    txtDisc2.Text = 0
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                Case 31, 35, 37
                    OnOffCtrl(False, False, True, False, False, True, True, True, True)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Discount"
                    cbDisc2.Text = "Disc Add"
                    cbDisc2.Checked = False
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    txtLayar1.Enabled = False
                    txtLayar2.Enabled = False
                    txtDisc2.Text = 0
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                Case 40
                    OnOffCtrl(False, False, True, False, False, True, True, True, True)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Discount"
                    cbDisc2.Text = "Disc Add"
                    cbDisc2.Checked = False
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    txtMinPurcNon.Text = 999999999
                    txtLayar1.Enabled = False
                    txtLayar2.Enabled = False
                    txtDisc2.Text = 0
                    cbMinPurcNon.Enabled = False
                Case 50
                    OnOffCtrl(True, True, True, False, False, True, True, True, True)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Credit"
                    cbDisc2.Text = "Debit"
                    cbDisc2.Checked = False
                    cbDisc.Checked = False
                    cbGender.Visible = False
                    cbBank1.Visible = True
                    cbBank2.Visible = True
                    cbBank1.Enabled = False
                    cbBank2.Enabled = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    txtLayar1.Enabled = False
                    txtLayar2.Enabled = False
                    txtDisc2.Text = 0
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                Case 19
                    OnOffCtrl(True, False, False, False, False, False, False, False, False)
                    'ToolStripMenuItem9.Visible = True
                    cbDisc.Text = "Discount"
                    cbDisc2.Text = "Disc Add"
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    cbDisc.Checked = False
                    cbDisc2.Checked = False
                    txtDisc2.Text = 0
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                Case 20
                    OnOffCtrl(True, True, False, True, True, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Buy "
                    cbDisc2.Text = "Get "
                    cbDisc.Checked = True
                    cbDisc2.Checked = True
                    cbGender.Visible = False
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    txtDisc2.Text = 0
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                    txtDisc.Focus()
                Case 21
                    OnOffCtrl(True, True, False, True, True, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Discount "
                    cbDisc2.Text = "Gender "
                    cbDisc.Checked = True
                    cbDisc2.Checked = True
                    cbGender.Visible = True
                    cbBank1.Visible = False
                    cbBank2.Visible = False
                    txtDisc2.Text = 0
                    txtMinPurcNon.Text = 10000
                    cbMinPurcNon.Enabled = True
                    txtDisc.Focus()
            End Select
        End If
    End Sub

    Private Sub cbD_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbD.MouseHover
        ToolTip1.ToolTipTitle = "Detail"
        ToolTip1.Show("Total " & totalart, cbD)
    End Sub

    Private Sub cbH_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbH.MouseHover
        ToolTip1.ToolTipTitle = "Header"
        ToolTip1.Show("Total 1 ", cbH)
    End Sub

    Private Sub cbO_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbO.MouseHover
        ToolTip1.Show("Total " & totalinc, cbO)
        ToolTip1.ToolTipTitle = "Include"
    End Sub

    Private Sub cbMsgLayar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMsgLayar.CheckedChanged
        If cbMsgLayar.Checked = True Then
            txtLayar1.Enabled = True
            txtLayar2.Enabled = True
        Else
            txtLayar1.Enabled = False
            txtLayar2.Enabled = False
        End If
    End Sub

    Private Sub cbStruk_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbStruk.CheckedChanged
        If cbMsgLayar.Checked = True Then
            txtLayar1.Enabled = True
            txtLayar2.Enabled = True
        Else
            txtLayar1.Enabled = False
            txtLayar2.Enabled = False
        End If
    End Sub

    

    'Private Sub dtpForm_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpForm.TextChanged
    '    If dtpForm.Value.Date.AddDays(AtlsDay) < Now.Date Then
    '        MsgBox("Promo date of at least " & AtlsDay * -1 & " days after today !!! (H" & AtlsDay & ")")
    '        dtpForm.Value = Now.Date.AddDays(AtlsDay * -1)
    '    End If
    '    If dtpForm.Value > dtpTo.Value Then
    '        dtpTo.Value = dtpForm.Value
    '    End If
    'End Sub

    'Private Sub dtpTo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpTo.TextChanged
    '    If dtpForm.Value > dtpTo.Value Then
    '        dtpTo.Value = dtpForm.Value
    '    End If
    'End Sub

    'Private Sub DateTimePicker1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker1.TextChanged
    '    Ulang()
    'End Sub

    'Private Sub DateTimePicker2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker2.TextChanged
    '    Ulang()
    'End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Ulang()
    End Sub
End Class