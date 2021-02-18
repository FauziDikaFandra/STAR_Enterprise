Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.Shared
Imports Microsoft.Office.Interop
Imports System.Data.SqlClient
Public Class Promo_Form
    Dim DocNo, Promo_ID, c_limit, c_voucher, c_kelipatan, c_layar, c_struk, branch, txt1ID, txt2ID, txt3ID, txt4ID, c_allItem, c_Rafaksi, c_allItemklik As String
    Dim DsPromo, DsHeader, DsDetail, DsCekTransfer As DataSet
    Dim cryRpt As New ReportDocument
    Dim t_Load As Boolean = False
    Dim p_Edit, p_Lakon As Boolean
    Dim myStream As Stream = Nothing
    Dim openFileDialog1 As New OpenFileDialog()
    Dim ds_CheckMaster As New DataSet
    Dim sbu, dept, brand As String
    Dim TotArt As Integer = 0
    Dim Prg As Decimal = 0
    Dim Ecount As Integer = 0
    Dim prid As String = ""
    Dim totalart, totalinc As Integer
    Private Sub Promo_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m_SqlconnPromo = "Data Source=" & m_ServerNamePromo & ";" & "Initial Catalog=" & m_DBNamePromo & ";" & "User ID=" & m_UserNamePromo & ";" & "Password=" & m_PasswordPromo & ";"
        cmbPromo(CmbTipe, "select Promo_ID,promo_name from promo_master where status = 1 order by Convert(INT,Promo_ID)", "Promo_ID", "promo_name", 1)
        cmbBank(cbBank1, "select Distinct RTRIM(Code) as Code from Bin_Kartu where Keterangan = 'Kartu Kredit' Order by Code", "Code", "Code", 1)
        cmbBank(cbBank2, "select Distinct RTRIM(Code) as Code from Bin_Kartu where Keterangan = 'Kartu Debit' Order by Code", "Code", "Code", 1)
        t_Load = True

        cbGender.Items.Add("M")
        cbGender.Items.Add("F")
        cbGender.SelectedIndex = 0
        'CmbTipe.SelectedValue = "02"
        CmbTipe.SelectedIndex = 1
        CmbTipe.SelectedIndex = 0
        If SbuCode = "MD" Then
            ToolStripMenuItem10.Visible = False
        End If
        CekDocNo()
        If GrpId = "6" And PromoGrpUsr <> "" Then
            ToolStripMenuItem1.Visible = False
            ToolStripMenuItem4.Visible = False
            ToolStripMenuItem6.Visible = False
            ToolStripMenuItem7.Visible = False
            ToolStripMenuItem8.Visible = False
            ToolStripMenuItem9.Visible = False
            ToolStripMenuItem10.Visible = False
            DsHeader = getSqldbPromo("Select a.*,b.total_artikel,b.total_inc from promo_hdr a left join Other_Detail b on a.branch_id = b.branch_id and a.doc_no = b.doc_no where updBy in (" & PromoGrpUsr & ") Order by UpdDt desc")
        ElseIf GrpId = "0" Then
            DsHeader = getSqldbPromo("Select a.*,b.total_artikel,b.total_inc from promo_hdr a left join Other_Detail b on a.branch_id = b.branch_id and a.doc_no = b.doc_no Order by UpdDt desc")
        Else
            DsHeader = getSqldbPromo("Select a.*,b.total_artikel,b.total_inc from promo_hdr a left join Other_Detail b on a.branch_id = b.branch_id and a.doc_no = b.doc_no where updBy = '" & UsrID & "' Order by UpdDt desc")
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
        If Sec_Lev = "0" Then
            Approved2ToolStripMenuItem.Visible = True
        Else
            Approved2ToolStripMenuItem.Visible = False
        End If
        CheckForIllegalCrossThreadCalls = False
        txtDesc.Focus()
        p_Edit = False
        ToolStripMenuItem8.Enabled = False
        ToolStripMenuItem9.Enabled = False
        Clear()
        ToolStripMenuItem8.Enabled = False
        ToolStripMenuItem10.Enabled = False
       
    End Sub

    Private Sub txtdisc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
    txtLimit.KeyPress, txtMinPurcMem.KeyPress, txtMinPurcNon.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Sub CekDocNo()
        Promo_ID = ""
        DocNo = ""
        For i As Int16 = Convert.ToInt16("A"c) To Convert.ToInt16("Z"c)
            DsPromo = getSqldbPromo("select * from promo_hdr where promo_id = '" & CmbTipe.SelectedValue & Convert.ToChar(i) & "' union all select * from promo_hdr_history where promo_id = '" & CmbTipe.SelectedValue & Convert.ToChar(i) & "' and end_date > getdate()")
            If DsPromo.Tables(0).Rows.Count = 0 Then
                Promo_ID = CmbTipe.SelectedValue & Convert.ToChar(i)
                DocNo = Format(Now, "yyyyMMdd" & "_" & CmbTipe.SelectedValue & Convert.ToChar(i))
                Exit For
            End If
        Next
        If DocNo = "" Then
            CekDocNoAngka(CInt(CmbTipe.SelectedValue))
        End If
        If DocNo = "" Then
            CekDocNoAngka2(CInt(CmbTipe.SelectedValue))
        End If
        If DocNo = "" Then
            CekDocNoAngka3(CInt(CmbTipe.SelectedValue))
        End If
        If DocNo = "" Then
            CekDocNoHurufTengah(CInt(CmbTipe.SelectedValue))
        End If
        txtDocNo.Text = DocNo
    End Sub

    Sub CekDocNoAngka(ByVal Nomor As Integer)
        For i As Int16 = Convert.ToInt16("A"c) To Convert.ToInt16("Z"c)
            DsPromo = getSqldbPromo("select * from promo_hdr where promo_id = '" & Convert.ToChar(i) & CmbTipe.SelectedValue & "' union all select * from promo_hdr_history where promo_id = '" & Convert.ToChar(i) & CmbTipe.SelectedValue & "' and end_date > getdate()")
            If DsPromo.Tables(0).Rows.Count = 0 Then
                Promo_ID = Convert.ToChar(i) & CmbTipe.SelectedValue
                DocNo = Format(Now, "yyyyMMdd" & "_" & Convert.ToChar(i) & CmbTipe.SelectedValue)
                Exit For
            End If
        Next
    End Sub

    Sub CekDocNoAngka2(ByVal Nomor As Integer)
        For i As Integer = 0 To 9
            DsPromo = getSqldbPromo("select * from promo_hdr where promo_id = '" & i & CmbTipe.SelectedValue & "' union all select * from promo_hdr_history where promo_id = '" & i & CmbTipe.SelectedValue & "' and end_date > getdate()")
            If DsPromo.Tables(0).Rows.Count = 0 Then
                Promo_ID = i & CmbTipe.SelectedValue
                DocNo = Format(Now, "yyyyMMdd" & "_" & i & CmbTipe.SelectedValue)
                Exit For
            End If
        Next
    End Sub

    Sub CekDocNoAngka3(ByVal Nomor As Integer)
        For i As Integer = 0 To 9
            DsPromo = getSqldbPromo("select * from promo_hdr where promo_id = '" & CmbTipe.SelectedValue & i & "' union all select * from promo_hdr_history where promo_id = '" & CmbTipe.SelectedValue & i & "' and end_date > getdate()")
            If DsPromo.Tables(0).Rows.Count = 0 Then
                Promo_ID = CmbTipe.SelectedValue & i
                DocNo = Format(Now, "yyyyMMdd" & "_" & CmbTipe.SelectedValue & i)
                Exit For
            End If
        Next
    End Sub

    Sub CekDocNoHurufTengah(ByVal Nomor As Integer)
        For i As Int16 = Convert.ToInt16("A"c) To Convert.ToInt16("Z"c)
            DsPromo = getSqldbPromo("select * from promo_hdr where promo_id = '" & Microsoft.VisualBasic.Left(CmbTipe.SelectedValue, 1) & Convert.ToChar(i) & Microsoft.VisualBasic.Right(CmbTipe.SelectedValue, 1) & "' union all select * from promo_hdr_history where promo_id = '" & Microsoft.VisualBasic.Left(CmbTipe.SelectedValue, 1) & Convert.ToChar(i) & Microsoft.VisualBasic.Right(CmbTipe.SelectedValue, 1) & "' and end_date > getdate()")
            If DsPromo.Tables(0).Rows.Count = 0 Then
                Promo_ID = Microsoft.VisualBasic.Left(CmbTipe.SelectedValue, 1) & Convert.ToChar(i) & Microsoft.VisualBasic.Right(CmbTipe.SelectedValue, 1)
                DocNo = Format(Now, "yyyyMMdd" & "_" & Microsoft.VisualBasic.Left(CmbTipe.SelectedValue, 1) & Convert.ToChar(i) & Microsoft.VisualBasic.Right(CmbTipe.SelectedValue, 1))
                Exit For
            End If
        Next
    End Sub

    Private Sub CmbTipe_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbTipe.SelectedIndexChanged
        If t_Load = True Then
            If p_Edit = True Then
                Exit Sub
            End If
            cbLimit.Text = "Limit (Qty)"
            Select Case CInt(CmbTipe.SelectedValue)
                Case 2, 3, 6, 11, 26
                    OnOffCtrl(True, False, False, False, False, False, False, False, False, False)
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
                    OnOffCtrl(True, True, False, False, False, False, False, False, False, False)
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
                Case 4
                    OnOffCtrl(True, True, False, False, False, False, False, False, False, False)
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
                Case 8
                    OnOffCtrl(True, True, False, False, True, False, False, False, False, False)
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
                Case 15
                    OnOffCtrl(True, True, False, False, True, False, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Disc Non"
                    cbDisc2.Text = "Disc Promo"
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
                    OnOffCtrl(True, True, False, False, True, False, False, False, False, False)
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
                    OnOffCtrl(True, True, False, False, True, False, False, False, False, False)
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
                    OnOffCtrl(True, True, False, False, True, False, False, False, False, False)
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
                Case 22
                    OnOffCtrl(True, True, True, False, True, False, False, False, False, False)
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
                    cbLimit.Text = "Disc Buy3"
                Case 29
                    OnOffCtrl(True, True, False, False, True, False, False, False, False, False)
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
                Case 7
                    OnOffCtrl(True, True, False, False, True, False, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Disc Emp"
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
                    OnOffCtrl(False, False, True, False, False, True, True, True, True, False)
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
                    OnOffCtrl(False, False, True, False, False, True, True, True, True, False)
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
                    OnOffCtrl(True, True, True, False, False, True, True, True, True, False)
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
                    OnOffCtrl(True, False, False, False, False, False, False, False, False, False)
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
                    OnOffCtrl(True, True, False, True, True, False, False, False, False, False)
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
                    OnOffCtrl(True, True, False, True, True, False, False, False, False, False)
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
                Case 75
                    OnOffCtrl(True, True, False, True, True, False, False, False, False, True)
                    If p_Edit = False Then
                        For a = 1 To DataGridView1.Rows.Count
                            DataGridView1.Rows.RemoveAt(0)
                        Next
                        DataGridView1.Rows.Add(1)
                        DataGridView1.Item(1, DataGridView1.CurrentRow.Index).Selected = True
                        DataGridView1.BeginEdit(True)
                    End If
            End Select
            CekDocNo()
        End If
    End Sub


    'Private Sub CmbTipe_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbTipe.TabIndexChanged
    '    If t_Load = True Then
    '        Select Case CInt(CmbTipe.SelectedValue)
    '            Case 2, 3, 6, 11, 23, 26, 27
    '                OnOffCtrl(True, False, False, True, False, False, False, False, False)
    '            Case 7, 8, 15, 17, 18, 29
    '                OnOffCtrl(True, True, False, True, True, False, False, False, False)
    '            Case 31, 37, 40, 50
    '                OnOffCtrl(False, False, True, False, False, True, True, True, True)
    '        End Select
    '        CekDocNo()
    '    End If
    'End Sub

    Sub OnOffCtrl(ByVal disc1 As Boolean, ByVal disc2 As Boolean, ByVal limit As Boolean, ByVal disc1txt As Boolean, _
                  ByVal disc2txt As Boolean, ByVal limittxt As Boolean, ByVal layar As Boolean, ByVal struk As Boolean, ByVal layartxt As Boolean, ByVal TujuhLima As Boolean)
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
        GroupBox6.Visible = TujuhLima
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Dim textBoxes = Me.Controls.OfType(Of TextBox)()

        Dim t As Control
        For Each t In Me.Controls
            If TypeOf t Is TextBox Then
                If t.Text = "" Then
                    MsgBox("Please Input " & t.Tag & " !!!")
                    t.Focus()
                    Exit Sub
                End If
            End If
            If TypeOf t Is GroupBox Then
                Dim tt As Control
                For Each tt In t.Controls
                    If TypeOf tt Is TextBox Then
                        If (Microsoft.VisualBasic.Left(tt.Name, 8) <> "txtLayar") And (tt.Name <> "txtKet") Then
                            If tt.Text = "" Then
                                If CmbTipe.SelectedValue <> "50" Then
                                    MsgBox("Please Input " & tt.Tag & " !!!")
                                    tt.Focus()
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If
                Next
            End If
        Next
        If cbLimit.Checked = True Then
            c_limit = 1
        Else
            c_limit = 0
        End If
        If cbPembVoucher.Checked = True Then
            c_voucher = 1
        Else
            c_voucher = 0
        End If
        If cbKelipatan.Checked = True Then
            c_kelipatan = 1
        Else
            c_kelipatan = 0
        End If
        If CbAllItem.Checked = True Then
            c_allItem = 1
        Else
            c_allItem = 0
        End If
        If cbRafaksi.Checked = True Then
            c_Rafaksi = 1
        Else
            c_Rafaksi = 0
        End If
        If cbMsgLayar.Checked = True Then
            If txtLayar1.Text = "" Or txtLayar1.Text = "" Then
                MsgBox("Please Input The Cash Register Information !!!")
                txtLayar1.Focus()
                Exit Sub
            End If
            c_layar = 1
        Else
            c_layar = 0
        End If
        If cbStruk.Checked = True Then
            If txtLayar1.Text = "" Or txtLayar1.Text = "" Then
                MsgBox("Please Input The Cash Register Information !!!")
                txtLayar1.Focus()
                Exit Sub
            End If
            c_struk = 1
        Else
            c_struk = 0
        End If

        If clbStore.CheckedItems.Count = 0 Then
            MsgBox("Please Checked Any Store !!!")
            Exit Sub
        End If

        p_Lakon = False
        Dim indexChecked As Object
        For Each indexChecked In clbStore.CheckedItems
            If Microsoft.VisualBasic.Left(indexChecked.ToString(), 4) = "S012" Then
                p_Lakon = True
            End If
        Next

        If p_Lakon = True Then
            If CInt(CmbTipe.SelectedValue) <> 2 Then
                If CInt(CmbTipe.SelectedValue) <> 31 Then
                    MsgBox("S012 is only for types 2 and 31 !!!")
                    Exit Sub
                End If
            End If
        End If

        Select Case CInt(CmbTipe.SelectedValue)
            Case 2, 3, 6, 11, 19, 26
                If cbDisc.Checked = False Or txtDisc.Text = 0 Then
                    MsgBox("Promo Type Must Use Discount of More Than '0'!!!")
                    cbDisc.Checked = True
                    txtDisc.Focus()
                    Exit Sub
                End If
                If p_Edit = False Then
                    CekDocNo()
                    For Each checkBox In clbStore.Items
                        If clbStore.GetItemCheckState(clbStore.Items.IndexOf(checkBox)) Then
                            'If (checkBox.Checked = True) Then
                            'Dim cc As String = checkBox.ToString

                            getSqldbPromo("Insert Into Promo_Hdr ([Branch_ID],[doc_no],[promo_id],[promo_name],[start_date],[end_date]" & _
                                          ",[min_purchase],[disc],[tipe],[voucher],[lipat],[ismsg],[isprn],[islimit],[qtylimit]," & _
                                          "[qtyout],[aktif],[min_member],[txt1],[txt2],[txt3],[txt4],[updby],[StatusH],[StatusD],[StatusO],[transfer],[UpdDt],[AllItemFlag],[Rafaksi]) values ('" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "', " & _
                                          " '" & txtDocNo.Text.Trim & "', '" & Promo_ID & "','" & txtDesc.Text.Trim & "','" & Format(dtpForm.Value, "yyyy-MM-dd ") & Format(dtpFromtime.Value, "HH:mm:ss") & "' " & _
                                          " ,'" & Format(dtpTo.Value, "yyyy-MM-dd ") & Format(dtpTotime.Value, "HH:mm:ss") & "','" & CDec(txtMinPurcNon.Text.Trim) & "' " & _
                                          " ,'" & txtDisc.Text & "', '" & CInt(CmbTipe.SelectedValue) & "', '" & c_voucher & "', '" & c_kelipatan & "', " & _
                                          " '0','0','0','0','0','1', '" & CDec(txtMinPurcMem.Text.Trim) & "', " & _
                                          " '','','','','" & UsrID & "','1','0','0','0',getdate(), '" & c_allItem & "', '" & c_Rafaksi & "') ")
                            getSqldbPromo("Insert Into Other_Detail ([branch_id],[doc_no],[sbu],[dept],[brand],[total_artikel],[total_inc]) Values ('" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "','" & txtDocNo.Text.Trim & "','','','',0,0) ")
                        End If
                    Next

                Else
                    For Each checkBox In clbStore.Items
                        If clbStore.GetItemCheckState(clbStore.Items.IndexOf(checkBox)) Then
                            'If (checkBox.Checked = True) Then
                            'Dim cc As String = checkBox.ToString
                            getSqldbPromo("Update Promo_Hdr set " & _
                                          "doc_no = '" & txtDocNo.Text.Trim & "',promo_name = '" & txtDesc.Text.Trim & "', start_date = '" & Format(dtpForm.Value.Date, "yyyy-MM-dd ") & Format(dtpFromtime.Value, "HH:mm:ss") & "', " & _
                                          "end_date = '" & Format(dtpTo.Value.Date, "yyyy-MM-dd ") & Format(dtpTotime.Value, "HH:mm:ss") & "', min_purchase = '" & CDec(txtMinPurcNon.Text.Trim) & "', " & _
                                          "disc = '" & txtDisc.Text & "',tipe = '" & CInt(CmbTipe.SelectedValue) & "',voucher =  '" & c_voucher & "', " & _
                                          "lipat = '" & c_kelipatan & "',[AllItemFlag] =  '" & c_allItem & "',[Rafaksi] =  '" & c_Rafaksi & "'," & _
                                          "min_member = '" & CDec(txtMinPurcMem.Text.Trim) & "',updby='" & UsrID & "',UpdDt = getdate() where Branch_ID = '" & branch & "' and doc_no  = '" & DocNo & "'")
                            Exit For
                        End If
                    Next


                End If
            Case 27
                If cbDisc.Checked = False Or txtDisc.Text = 0 Then
                    MsgBox("Promo Type Must Use Discount of More Than '0'!!!")
                    cbDisc.Checked = True
                    txtDisc.Focus()
                    Exit Sub
                End If
                If p_Edit = False Then
                    CekDocNo()
                    For Each checkBox In clbStore.Items
                        If clbStore.GetItemCheckState(clbStore.Items.IndexOf(checkBox)) Then
                            'If (checkBox.Checked = True) Then
                            'Dim cc As String = checkBox.ToString

                            getSqldbPromo("Insert Into Promo_Hdr ([Branch_ID],[doc_no],[promo_id],[promo_name],[start_date],[end_date]" & _
                                          ",[min_purchase],[disc],[tipe],[voucher],[lipat],[ismsg],[isprn],[islimit],[qtylimit]," & _
                                          "[qtyout],[aktif],[min_member],[txt1],[txt2],[txt3],[txt4],[updby],[StatusH],[StatusD],[StatusO],[transfer],[UpdDt],[AllItemFlag],[Rafaksi]) values ('" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "', " & _
                                          " '" & txtDocNo.Text.Trim & "', '" & Promo_ID & "','" & txtDesc.Text.Trim & "','" & Format(dtpForm.Value, "yyyy-MM-dd ") & Format(dtpFromtime.Value, "HH:mm:ss") & "' " & _
                                          " ,'" & Format(dtpTo.Value, "yyyy-MM-dd ") & Format(dtpTotime.Value, "HH:mm:ss") & "','" & CDec(txtMinPurcNon.Text.Trim) & "' " & _
                                          " ,'" & txtDisc.Text & "', '" & CInt(CmbTipe.SelectedValue) & "', '" & c_voucher & "', '" & c_kelipatan & "', " & _
                                          " '0','0','0','0','0','1', '" & CDec(txtMinPurcMem.Text.Trim) & "', " & _
                                          " '" & txtDisc2.Text & "','','','','" & UsrID & "','1','0','0','0',getdate(), '" & c_allItem & "', '" & c_Rafaksi & "') ")
                            getSqldbPromo("Insert Into Other_Detail ([branch_id],[doc_no],[sbu],[dept],[brand],[total_artikel],[total_inc]) Values ('" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "','" & txtDocNo.Text.Trim & "','','','',0,0) ")
                        End If
                    Next

                Else
                    For Each checkBox In clbStore.Items
                        If clbStore.GetItemCheckState(clbStore.Items.IndexOf(checkBox)) Then
                            'If (checkBox.Checked = True) Then
                            'Dim cc As String = checkBox.ToString
                            getSqldbPromo("Update Promo_Hdr set " & _
                                          "doc_no = '" & txtDocNo.Text.Trim & "',promo_name = '" & txtDesc.Text.Trim & "', start_date = '" & Format(dtpForm.Value.Date, "yyyy-MM-dd ") & Format(dtpFromtime.Value, "HH:mm:ss") & "', " & _
                                          "end_date = '" & Format(dtpTo.Value.Date, "yyyy-MM-dd ") & Format(dtpTotime.Value, "HH:mm:ss") & "', min_purchase = '" & CDec(txtMinPurcNon.Text.Trim) & "', " & _
                                          "disc = '" & txtDisc.Text & "',tipe = '" & CInt(CmbTipe.SelectedValue) & "',voucher =  '" & c_voucher & "', " & _
                                          "lipat = '" & c_kelipatan & "',[AllItemFlag] =  '" & c_allItem & "',[Rafaksi] =  '" & c_Rafaksi & "',txt1 = '" & txtDisc2.Text & "'" & _
                                          "min_member = '" & CDec(txtMinPurcMem.Text.Trim) & "',updby='" & UsrID & "',UpdDt = getdate() where Branch_ID = '" & branch & "' and doc_no  = '" & DocNo & "'")
                            Exit For
                        End If
                    Next


                End If
            Case 29
                If cbDisc.Checked = False Or txtDisc.Text = 0 Then
                    MsgBox("Promo Type Must Use Discount of More Than '0'!!!")
                    cbDisc.Checked = True
                    txtDisc.Focus()
                    Exit Sub
                End If
                If p_Edit = False Then
                    For Each checkBox In clbStore.Items
                        If clbStore.GetItemCheckState(clbStore.Items.IndexOf(checkBox)) Then
                            'If (checkBox.Checked = True) Then
                            'Dim cc As String = checkBox.ToString
                            getSqldbPromo("Insert Into Promo_Hdr ([Branch_ID],[doc_no],[promo_id],[promo_name],[start_date],[end_date]" & _
                                         ",[min_purchase],[disc],[tipe],[voucher],[lipat],[ismsg],[isprn],[islimit],[qtylimit]," & _
                                         "[qtyout],[aktif],[min_member],[txt1],[txt2],[txt3],[txt4],[updby],[StatusH],[StatusD],[StatusO],[transfer],[UpdDt],[AllItemFlag],[Rafaksi]) values ('" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "', " & _
                                         " '" & txtDocNo.Text.Trim & "', '" & Promo_ID & "','" & txtDesc.Text.Trim & "','" & Format(dtpForm.Value.Date, "yyyy-MM-dd ") & Format(dtpFromtime.Value, "HH:mm:ss") & "' " & _
                                         " ,'" & Format(dtpTo.Value.Date, "yyyy-MM-dd ") & Format(dtpTotime.Value, "HH:mm:ss") & "','" & CDec(txtMinPurcNon.Text.Trim) & "' " & _
                                         " ,'" & txtDisc.Text & "', '" & CInt(CmbTipe.SelectedValue) & "', '" & c_voucher & "', '" & c_kelipatan & "', " & _
                                         " '0','0','0','0','0','1', '" & CDec(txtMinPurcMem.Text.Trim) & "', " & _
                                         " '" & txtDisc2.Text & "','','','','" & UsrID & "','1','0','0','0',Getdate(), '" & c_allItem & "', '" & c_Rafaksi & "') ")
                            getSqldbPromo("Insert Into Other_Detail ([branch_id],[doc_no],[sbu],[dept],[brand],[total_artikel],[total_inc]) Values ('" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "','" & txtDocNo.Text.Trim & "','','','',0,0) ")
                        End If
                    Next

                Else
                    For Each checkBox In clbStore.Items
                        If clbStore.GetItemCheckState(clbStore.Items.IndexOf(checkBox)) Then
                            'If (checkBox.Checked = True) Then
                            'Dim cc As String = checkBox.ToString
                            getSqldbPromo("Update Promo_Hdr set " & _
                                          "doc_no = '" & txtDocNo.Text.Trim & "',promo_name = '" & txtDesc.Text.Trim & "', start_date = '" & Format(dtpForm.Value.Date, "yyyy-MM-dd ") & Format(dtpFromtime.Value, "HH:mm:ss") & "', " & _
                                          "end_date = '" & Format(dtpTo.Value.Date, "yyyy-MM-dd ") & Format(dtpTotime.Value, "HH:mm:ss") & "', min_purchase = '" & CDec(txtMinPurcNon.Text.Trim) & "', " & _
                                          "disc = '" & txtDisc.Text & "',tipe = '" & CInt(CmbTipe.SelectedValue) & "',voucher =  '" & c_voucher & "', " & _
                                          "lipat = '" & c_kelipatan & "', txt1 = '" & txtDisc2.Text & "',[AllItemFlag] = '" & c_allItem & "',[Rafaksi] =  '" & c_Rafaksi & "', " & _
                                          "min_member = '" & CDec(txtMinPurcMem.Text.Trim) & "',updby='" & UsrID & "',UpdDt = Getdate() where Branch_ID = '" & branch & "' and doc_no  = '" & DocNo & "'")
                            Exit For
                        End If
                    Next


                End If
            Case 4
                If cbDisc2.Checked = False Or txtDisc2.Text = 0 Then
                    MsgBox("Promo Type Must Use Discount of More Than '0'!!!")
                    cbDisc2.Checked = True
                    txtDisc2.Focus()
                    Exit Sub
                End If
                If p_Edit = False Then
                    For Each checkBox In clbStore.Items
                        If clbStore.GetItemCheckState(clbStore.Items.IndexOf(checkBox)) Then
                            'If (checkBox.Checked = True) Then
                            'Dim cc As String = checkBox.ToString
                            getSqldbPromo("Insert Into Promo_Hdr ([Branch_ID],[doc_no],[promo_id],[promo_name],[start_date],[end_date]" & _
                                         ",[min_purchase],[disc],[tipe],[voucher],[lipat],[ismsg],[isprn],[islimit],[qtylimit]," & _
                                         "[qtyout],[aktif],[min_member],[txt1],[txt2],[txt3],[txt4],[updby],[StatusH],[StatusD],[StatusO],[transfer],[UpdDt],[AllItemFlag],[Rafaksi]) values ('" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "', " & _
                                         " '" & txtDocNo.Text.Trim & "', '" & Promo_ID & "','" & txtDesc.Text.Trim & "','" & Format(dtpForm.Value.Date, "yyyy-MM-dd ") & Format(dtpFromtime.Value, "HH:mm:ss") & "' " & _
                                         " ,'" & Format(dtpTo.Value.Date, "yyyy-MM-dd ") & Format(dtpTotime.Value, "HH:mm:ss") & "','" & CDec(txtMinPurcNon.Text.Trim) & "' " & _
                                         " ,'" & txtDisc.Text & "', '" & CInt(CmbTipe.SelectedValue) & "', '" & c_voucher & "', '" & c_kelipatan & "', " & _
                                         " '0','0','0','0','0','1', '" & CDec(txtMinPurcMem.Text.Trim) & "', " & _
                                         " '" & txtDisc2.Text & "','','','','" & UsrID & "','1','0','0','0',Getdate(), '" & c_allItem & "', '" & c_Rafaksi & "') ")
                            getSqldbPromo("Insert Into Other_Detail ([branch_id],[doc_no],[sbu],[dept],[brand],[total_artikel],[total_inc]) Values ('" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "','" & txtDocNo.Text.Trim & "','','','',0,0) ")
                        End If
                    Next

                Else
                    For Each checkBox In clbStore.Items
                        If clbStore.GetItemCheckState(clbStore.Items.IndexOf(checkBox)) Then
                            'If (checkBox.Checked = True) Then
                            'Dim cc As String = checkBox.ToString
                            getSqldbPromo("Update Promo_Hdr set " & _
                                          "doc_no = '" & txtDocNo.Text.Trim & "',promo_name = '" & txtDesc.Text.Trim & "', start_date = '" & Format(dtpForm.Value.Date, "yyyy-MM-dd ") & Format(dtpFromtime.Value, "HH:mm:ss") & "', " & _
                                          "end_date = '" & Format(dtpTo.Value.Date, "yyyy-MM-dd ") & Format(dtpTotime.Value, "HH:mm:ss") & "', min_purchase = '" & CDec(txtMinPurcNon.Text.Trim) & "', " & _
                                          "disc = '" & txtDisc.Text & "',tipe = '" & CInt(CmbTipe.SelectedValue) & "',voucher =  '" & c_voucher & "', " & _
                                          "lipat = '" & c_kelipatan & "', txt1 = '" & txtDisc2.Text & "',[AllItemFlag] = '" & c_allItem & "',[Rafaksi] =  '" & c_Rafaksi & "', " & _
                                          "min_member = '" & CDec(txtMinPurcMem.Text.Trim) & "',updby='" & UsrID & "',UpdDt = Getdate() where Branch_ID = '" & branch & "' and doc_no  = '" & DocNo & "'")
                            Exit For
                        End If
                    Next


                End If
            Case 7, 8, 15
                If cbDisc.Checked = False Or txtDisc.Text = 0 Then
                    MsgBox("Promo Type Must Use Discount of More Than '0'!!!")
                    cbDisc.Checked = True
                    txtDisc.Focus()
                    Exit Sub
                End If
                If cbDisc2.Checked = False Or txtDisc2.Text = 0 Then
                    MsgBox("Promo Type Must Use Discount of More Than '0'!!!")
                    cbDisc2.Checked = True
                    txtDisc2.Focus()
                    Exit Sub
                End If
                If p_Edit = False Then
                    For Each checkBox In clbStore.Items
                        If clbStore.GetItemCheckState(clbStore.Items.IndexOf(checkBox)) Then
                            'If (checkBox.Checked = True) Then
                            'Dim cc As String = checkBox.ToString
                            getSqldbPromo("Insert Into Promo_Hdr ([Branch_ID],[doc_no],[promo_id],[promo_name],[start_date],[end_date]" & _
                                         ",[min_purchase],[disc],[tipe],[voucher],[lipat],[ismsg],[isprn],[islimit],[qtylimit]," & _
                                         "[qtyout],[aktif],[min_member],[txt1],[txt2],[txt3],[txt4],[updby],[StatusH],[StatusD],[StatusO],[transfer],[UpdDt],[AllItemFlag],[Rafaksi]) values ('" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "', " & _
                                         " '" & txtDocNo.Text.Trim & "', '" & Promo_ID & "','" & txtDesc.Text.Trim & "','" & Format(dtpForm.Value.Date, "yyyy-MM-dd ") & Format(dtpFromtime.Value, "HH:mm:ss") & "' " & _
                                         " ,'" & Format(dtpTo.Value.Date, "yyyy-MM-dd ") & Format(dtpTotime.Value, "HH:mm:ss") & "','" & CDec(txtMinPurcNon.Text.Trim) & "' " & _
                                         " ,'" & txtDisc.Text & "', '" & CInt(CmbTipe.SelectedValue) & "', '" & c_voucher & "', '" & c_kelipatan & "', " & _
                                         " '0','0','0','0','0','1', '" & CDec(txtMinPurcMem.Text.Trim) & "', " & _
                                         " '" & txtDisc2.Text & "','','','','" & UsrID & "','1','0','0','0',Getdate(), '" & c_allItem & "', '" & c_Rafaksi & "') ")
                            getSqldbPromo("Insert Into Other_Detail ([branch_id],[doc_no],[sbu],[dept],[brand],[total_artikel],[total_inc]) Values ('" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "','" & txtDocNo.Text.Trim & "','','','',0,0) ")
                        End If
                    Next

                Else
                    For Each checkBox In clbStore.Items
                        If clbStore.GetItemCheckState(clbStore.Items.IndexOf(checkBox)) Then
                            'If (checkBox.Checked = True) Then
                            'Dim cc As String = checkBox.ToString
                            getSqldbPromo("Update Promo_Hdr set " & _
                                          "doc_no = '" & txtDocNo.Text.Trim & "',promo_name = '" & txtDesc.Text.Trim & "', start_date = '" & Format(dtpForm.Value.Date, "yyyy-MM-dd ") & Format(dtpFromtime.Value, "HH:mm:ss") & "', " & _
                                          "end_date = '" & Format(dtpTo.Value.Date, "yyyy-MM-dd ") & Format(dtpTotime.Value, "HH:mm:ss") & "', min_purchase = '" & CDec(txtMinPurcNon.Text.Trim) & "', " & _
                                          "disc = '" & txtDisc.Text & "',tipe = '" & CInt(CmbTipe.SelectedValue) & "',voucher =  '" & c_voucher & "', " & _
                                          "lipat = '" & c_kelipatan & "', txt1 = '" & txtDisc2.Text & "',[AllItemFlag] = '" & c_allItem & "',[Rafaksi] =  '" & c_Rafaksi & "', " & _
                                          "min_member = '" & CDec(txtMinPurcMem.Text.Trim) & "',updby='" & UsrID & "',UpdDt = Getdate() where Branch_ID = '" & branch & "' and doc_no  = '" & DocNo & "'")
                            Exit For
                        End If
                    Next


                End If
            Case 17, 18
                'If cbDisc.Checked = False Or txtDisc.Text = 0 Then
                '    MsgBox("Promo Type Must Use Discount of More Than '0'!!!")
                '    cbDisc.Checked = True
                '    txtDisc.Focus()
                '    Exit Sub
                'End If
                'If cbDisc2.Checked = False Or txtDisc2.Text = 0 Then
                '    MsgBox("Promo Type Must Use Discount of More Than '0'!!!")
                '    cbDisc2.Checked = True
                '    txtDisc2.Focus()
                '    Exit Sub
                'End If
                If p_Edit = False Then
                    For Each checkBox In clbStore.Items
                        If clbStore.GetItemCheckState(clbStore.Items.IndexOf(checkBox)) Then
                            'If (checkBox.Checked = True) Then
                            'Dim cc As String = checkBox.ToString
                            getSqldbPromo("Insert Into Promo_Hdr ([Branch_ID],[doc_no],[promo_id],[promo_name],[start_date],[end_date]" & _
                                         ",[min_purchase],[disc],[tipe],[voucher],[lipat],[ismsg],[isprn],[islimit],[qtylimit]," & _
                                         "[qtyout],[aktif],[min_member],[txt1],[txt2],[txt3],[txt4],[updby],[StatusH],[StatusD],[StatusO],[transfer],[UpdDt],[AllItemFlag],[Rafaksi]) values ('" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "', " & _
                                         " '" & txtDocNo.Text.Trim & "', '" & Promo_ID & "','" & txtDesc.Text.Trim & "','" & Format(dtpForm.Value.Date, "yyyy-MM-dd ") & Format(dtpFromtime.Value, "HH:mm:ss") & "' " & _
                                         " ,'" & Format(dtpTo.Value.Date, "yyyy-MM-dd ") & Format(dtpTotime.Value, "HH:mm:ss") & "','" & CDec(txtMinPurcNon.Text.Trim) & "' " & _
                                         " ,'" & txtDisc.Text & "', '" & CInt(CmbTipe.SelectedValue) & "', '" & c_voucher & "', '" & c_kelipatan & "', " & _
                                         " '0','0','0','0','0','1', '" & CDec(txtMinPurcMem.Text.Trim) & "', " & _
                                         " '" & txtDisc2.Text & "','','','','" & UsrID & "','1','0','0','0',Getdate(), '" & c_allItem & "', '" & c_Rafaksi & "') ")
                            getSqldbPromo("Insert Into Other_Detail ([branch_id],[doc_no],[sbu],[dept],[brand],[total_artikel],[total_inc]) Values ('" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "','" & txtDocNo.Text.Trim & "','','','',0,0) ")
                        End If
                    Next

                Else
                    For Each checkBox In clbStore.Items
                        If clbStore.GetItemCheckState(clbStore.Items.IndexOf(checkBox)) Then
                            'If (checkBox.Checked = True) Then
                            'Dim cc As String = checkBox.ToString
                            getSqldbPromo("Update Promo_Hdr set " & _
                                          "doc_no = '" & txtDocNo.Text.Trim & "',promo_name = '" & txtDesc.Text.Trim & "', start_date = '" & Format(dtpForm.Value.Date, "yyyy-MM-dd ") & Format(dtpFromtime.Value, "HH:mm:ss") & "', " & _
                                          "end_date = '" & Format(dtpTo.Value.Date, "yyyy-MM-dd ") & Format(dtpTotime.Value, "HH:mm:ss") & "', min_purchase = '" & CDec(txtMinPurcNon.Text.Trim) & "', " & _
                                          "disc = '" & txtDisc.Text & "',tipe = '" & CInt(CmbTipe.SelectedValue) & "',voucher =  '" & c_voucher & "', " & _
                                          "lipat = '" & c_kelipatan & "', txt1 = '" & txtDisc2.Text & "',[AllItemFlag] = '" & c_allItem & "',[Rafaksi] =  '" & c_Rafaksi & "', " & _
                                          "min_member = '" & CDec(txtMinPurcMem.Text.Trim) & "',updby='" & UsrID & "',UpdDt = Getdate() where Branch_ID = '" & branch & "' and doc_no  = '" & DocNo & "'")
                            Exit For
                        End If
                    Next


                End If
            Case 22
                'If cbDisc.Checked = False Or txtDisc.Text = 0 Then
                '    MsgBox("Promo Type Must Use Discount of More Than '0'!!!")
                '    cbDisc.Checked = True
                '    txtDisc.Focus()
                '    Exit Sub
                'End If
                'If cbDisc2.Checked = False Or txtDisc2.Text = 0 Then
                '    MsgBox("Promo Type Must Use Discount of More Than '0'!!!")
                '    cbDisc2.Checked = True
                '    txtDisc2.Focus()
                '    Exit Sub
                'End If
                If p_Edit = False Then
                    For Each checkBox In clbStore.Items
                        If clbStore.GetItemCheckState(clbStore.Items.IndexOf(checkBox)) Then
                            'If (checkBox.Checked = True) Then
                            'Dim cc As String = checkBox.ToString
                            getSqldbPromo("Insert Into Promo_Hdr ([Branch_ID],[doc_no],[promo_id],[promo_name],[start_date],[end_date]" & _
                                         ",[min_purchase],[disc],[tipe],[voucher],[lipat],[ismsg],[isprn],[islimit],[qtylimit]," & _
                                         "[qtyout],[aktif],[min_member],[txt1],[txt2],[txt3],[txt4],[updby],[StatusH],[StatusD],[StatusO],[transfer],[UpdDt],[AllItemFlag],[Rafaksi]) values ('" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "', " & _
                                         " '" & txtDocNo.Text.Trim & "', '" & Promo_ID & "','" & txtDesc.Text.Trim & "','" & Format(dtpForm.Value.Date, "yyyy-MM-dd ") & Format(dtpFromtime.Value, "HH:mm:ss") & "' " & _
                                         " ,'" & Format(dtpTo.Value.Date, "yyyy-MM-dd ") & Format(dtpTotime.Value, "HH:mm:ss") & "','" & CDec(txtMinPurcNon.Text.Trim) & "' " & _
                                         " ,'" & txtDisc.Text & "', '" & CInt(CmbTipe.SelectedValue) & "', '" & c_voucher & "', '" & c_kelipatan & "', " & _
                                         " '0','0','0','0','0','1', '" & CDec(txtMinPurcMem.Text.Trim) & "', " & _
                                         " '" & txtDisc2.Text & "','" & txtLimit.Text & "','','','" & UsrID & "','1','0','0','0',Getdate(), '" & c_allItem & "', '" & c_Rafaksi & "') ")
                            getSqldbPromo("Insert Into Other_Detail ([branch_id],[doc_no],[sbu],[dept],[brand],[total_artikel],[total_inc]) Values ('" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "','" & txtDocNo.Text.Trim & "','','','',0,0) ")
                        End If
                    Next

                Else
                    For Each checkBox In clbStore.Items
                        If clbStore.GetItemCheckState(clbStore.Items.IndexOf(checkBox)) Then
                            'If (checkBox.Checked = True) Then
                            'Dim cc As String = checkBox.ToString
                            getSqldbPromo("Update Promo_Hdr set " & _
                                          "doc_no = '" & txtDocNo.Text.Trim & "',promo_name = '" & txtDesc.Text.Trim & "', start_date = '" & Format(dtpForm.Value.Date, "yyyy-MM-dd ") & Format(dtpFromtime.Value, "HH:mm:ss") & "', " & _
                                          "end_date = '" & Format(dtpTo.Value.Date, "yyyy-MM-dd ") & Format(dtpTotime.Value, "HH:mm:ss") & "', min_purchase = '" & CDec(txtMinPurcNon.Text.Trim) & "', " & _
                                          "disc = '" & txtDisc.Text & "',tipe = '" & CInt(CmbTipe.SelectedValue) & "',voucher =  '" & c_voucher & "', " & _
                                          "lipat = '" & c_kelipatan & "', txt1 = '" & txtDisc2.Text & "',[AllItemFlag] = '" & c_allItem & "',[Rafaksi] =  '" & c_Rafaksi & "', " & _
                                          "min_member = '" & CDec(txtMinPurcMem.Text.Trim) & "',updby='" & UsrID & "',UpdDt = Getdate() where Branch_ID = '" & branch & "' and doc_no  = '" & DocNo & "'")
                            Exit For
                        End If
                    Next


                End If
            Case 23
                If cbDisc.Checked = False Then
                    txtDisc.Text = 0
                End If
                If cbDisc2.Checked = False Then
                    txtDisc2.Text = 0
                End If
                If p_Edit = False Then
                    For Each checkBox In clbStore.Items
                        If clbStore.GetItemCheckState(clbStore.Items.IndexOf(checkBox)) Then
                            'If (checkBox.Checked = True) Then
                            'Dim cc As String = checkBox.ToString
                            getSqldbPromo("Insert Into Promo_Hdr ([Branch_ID],[doc_no],[promo_id],[promo_name],[start_date],[end_date]" & _
                                         ",[min_purchase],[disc],[tipe],[voucher],[lipat],[ismsg],[isprn],[islimit],[qtylimit]," & _
                                         "[qtyout],[aktif],[min_member],[txt1],[txt2],[txt3],[txt4],[updby],[StatusH],[StatusD],[StatusO],[transfer],[UpdDt],[AllItemFlag],[Rafaksi]) values ('" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "', " & _
                                         " '" & txtDocNo.Text.Trim & "', '" & Promo_ID & "','" & txtDesc.Text.Trim & "','" & Format(dtpForm.Value.Date, "yyyy-MM-dd ") & Format(dtpFromtime.Value, "HH:mm:ss") & "' " & _
                                         " ,'" & Format(dtpTo.Value.Date, "yyyy-MM-dd ") & Format(dtpTotime.Value, "HH:mm:ss") & "','" & CDec(txtMinPurcNon.Text.Trim) & "' " & _
                                         " ,'" & txtDisc.Text & "', '" & CInt(CmbTipe.SelectedValue) & "', '" & c_voucher & "', '" & c_kelipatan & "', " & _
                                         " '0','0','0','0','0','1', '" & CDec(txtMinPurcMem.Text.Trim) & "', " & _
                                         " '" & txtDisc2.Text & "','','','','" & UsrID & "','1','0','0','0',Getdate(), '" & c_allItem & "', '" & c_Rafaksi & "') ")
                            getSqldbPromo("Insert Into Other_Detail ([branch_id],[doc_no],[sbu],[dept],[brand],[total_artikel],[total_inc]) Values ('" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "','" & txtDocNo.Text.Trim & "','','','',0,0) ")
                        End If
                    Next
                Else
                    For Each checkBox In clbStore.Items
                        If clbStore.GetItemCheckState(clbStore.Items.IndexOf(checkBox)) Then
                            'If (checkBox.Checked = True) Then
                            'Dim cc As String = checkBox.ToString
                            getSqldbPromo("Update Promo_Hdr set " & _
                                          "doc_no = '" & txtDocNo.Text.Trim & "',promo_name = '" & txtDesc.Text.Trim & "', start_date = '" & Format(dtpForm.Value.Date, "yyyy-MM-dd ") & Format(dtpFromtime.Value, "HH:mm:ss") & "', " & _
                                          "end_date = '" & Format(dtpTo.Value.Date, "yyyy-MM-dd ") & Format(dtpTotime.Value, "HH:mm:ss") & "', min_purchase = '" & CDec(txtMinPurcNon.Text.Trim) & "', " & _
                                          "disc = '" & txtDisc.Text & "',tipe = '" & CInt(CmbTipe.SelectedValue) & "',voucher =  '" & c_voucher & "', " & _
                                          "lipat = '" & c_kelipatan & "', txt1 = '" & txtDisc2.Text & "',[AllItemFlag] = '" & c_allItem & "',[Rafaksi] =  '" & c_Rafaksi & "', " & _
                                          "min_member = '" & CDec(txtMinPurcMem.Text.Trim) & "',updby='" & UsrID & "',UpdDt = Getdate() where Branch_ID = '" & branch & "' and doc_no  = '" & DocNo & "'")
                            Exit For
                        End If
                    Next
                End If
            Case 20, 21
                Dim txt1insert As String
                Dim txtdiscstr As Integer = 0
                If CInt(CmbTipe.SelectedValue) = 20 Then
                    txtdiscstr = 100
                Else
                    txtdiscstr = txtDisc.Text
                End If
                If cbDisc.Checked = False Or txtDisc.Text = 0 Then
                    MsgBox("Promo Type Must Use Buy of More Than '0'!!!")
                    cbDisc.Checked = True
                    txtDisc.Focus()
                    Exit Sub
                End If
                If CmbTipe.SelectedValue = "21" Then
                    txt1insert = cbGender.Text
                    If cbDisc2.Checked = False Then
                        MsgBox("Promo Type Must Use Gender of 'M' or 'L'!!!")
                        cbDisc2.Checked = True
                        Exit Sub
                    End If
                Else
                    txt1insert = txtDisc.Text & txtDisc2.Text
                    If (cbDisc2.Checked = False Or txtDisc2.Text = 0) And CInt(CmbTipe.SelectedValue) <> 21 Then
                        MsgBox("Promo Type Must Use Get of More Than '0'!!!")
                        cbDisc2.Checked = True
                        txtDisc2.Focus()
                        Exit Sub
                    End If
                End If

                If p_Edit = False Then
                    For Each checkBox In clbStore.Items
                        If clbStore.GetItemCheckState(clbStore.Items.IndexOf(checkBox)) Then
                            'If (checkBox.Checked = True) Then
                            'Dim cc As String = checkBox.ToString
                            getSqldbPromo("Insert Into Promo_Hdr ([Branch_ID],[doc_no],[promo_id],[promo_name],[start_date],[end_date]" & _
                                         ",[min_purchase],[disc],[tipe],[voucher],[lipat],[ismsg],[isprn],[islimit],[qtylimit]," & _
                                         "[qtyout],[aktif],[min_member],[txt1],[txt2],[txt3],[txt4],[updby],[StatusH],[StatusD],[StatusO],[transfer],[UpdDt],[AllItemFlag],[Rafaksi]) values ('" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "', " & _
                                         " '" & txtDocNo.Text.Trim & "', '" & Promo_ID & "','" & txtDesc.Text.Trim & "','" & Format(dtpForm.Value.Date, "yyyy-MM-dd ") & Format(dtpFromtime.Value, "HH:mm:ss") & "' " & _
                                         " ,'" & Format(dtpTo.Value.Date, "yyyy-MM-dd ") & Format(dtpTotime.Value, "HH:mm:ss") & "','" & CDec(txtMinPurcNon.Text.Trim) & "' " & _
                                         " ,'" & txtdiscstr & "', '" & CInt(CmbTipe.SelectedValue) & "', '" & c_voucher & "', '" & c_kelipatan & "', " & _
                                         " '0','0','0','0','0','1', '" & CDec(txtMinPurcMem.Text.Trim) & "', " & _
                                         " '" & txt1insert & "','','','','" & UsrID & "','1','0','0','0',GetDate(), '" & c_allItem & "', '" & c_Rafaksi & "') ")
                            getSqldbPromo("Insert Into Other_Detail ([branch_id],[doc_no],[sbu],[dept],[brand],[total_artikel],[total_inc]) Values ('" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "','" & txtDocNo.Text.Trim & "','','','',0,0) ")
                        End If
                    Next


                Else
                    For Each checkBox In clbStore.Items
                        If clbStore.GetItemCheckState(clbStore.Items.IndexOf(checkBox)) Then
                            'If (checkBox.Checked = True) Then
                            'Dim cc As String = checkBox.ToString
                            getSqldbPromo("Update Promo_Hdr set " & _
                                          "doc_no = '" & txtDocNo.Text.Trim & "',promo_name = '" & txtDesc.Text.Trim & "', start_date = '" & Format(dtpForm.Value.Date, "yyyy-MM-dd ") & Format(dtpFromtime.Value, "HH:mm:ss") & "', " & _
                                          "end_date = '" & Format(dtpTo.Value.Date, "yyyy-MM-dd ") & Format(dtpTotime.Value, "HH:mm:ss") & "', min_purchase = '" & CDec(txtMinPurcNon.Text.Trim) & "', " & _
                                          "tipe = '" & CInt(CmbTipe.SelectedValue) & "',voucher =  '" & c_voucher & "',disc = '" & txtdiscstr & "', " & _
                                          "lipat = '" & c_kelipatan & "', txt1 = '" & txt1insert & "'," & _
                                          "min_member = '" & CDec(txtMinPurcMem.Text.Trim) & "',updby='" & UsrID & "',UpdDt = GetDate(),[AllItemFlag] = '" & c_allItem & "',[Rafaksi] =  '" & c_Rafaksi & "' where Branch_ID = '" & branch & "' and doc_no  = '" & DocNo & "'")
                            Exit For
                        End If
                    Next


                End If
            Case 31, 35, 37, 40
                If txtLayar1.Text = "" And txtLayar2.Text = "" Then
                    MsgBox("Please Input The Information !!!!!!")
                    txtLayar1.Focus()
                    Exit Sub
                End If
                If txtLayar1.Text = "" And txtLayar2.Text = "" Then
                    MsgBox("Please Input The Information !!!!!!")
                    txtLayar1.Focus()
                    Exit Sub
                End If
                If p_Edit = False Then
                    For Each checkBox In clbStore.Items
                        If clbStore.GetItemCheckState(clbStore.Items.IndexOf(checkBox)) Then
                            'If (checkBox.Checked = True) Then
                            'Dim cc As String = checkBox.ToString
                            getSqldbPromo("Insert Into Promo_Hdr ([Branch_ID],[doc_no],[promo_id],[promo_name],[start_date],[end_date]" & _
                                         ",[min_purchase],[disc],[tipe],[voucher],[lipat],[ismsg],[isprn],[islimit],[qtylimit]," & _
                                         "[qtyout],[aktif],[min_member],[txt1],[txt2],[txt3],[txt4],[updby],[StatusH],[StatusD],[StatusO],[transfer],[UpdDt],[AllItemFlag],[Rafaksi]) values ('" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "', " & _
                                         " '" & txtDocNo.Text.Trim & "', '" & Promo_ID & "','" & txtDesc.Text.Trim & "','" & Format(dtpForm.Value.Date, "yyyy-MM-dd ") & Format(dtpFromtime.Value, "HH:mm:ss") & "' " & _
                                         " ,'" & Format(dtpTo.Value.Date, "yyyy-MM-dd ") & Format(dtpTotime.Value, "HH:mm:ss") & "','" & CDec(txtMinPurcNon.Text.Trim) & "' " & _
                                         " ,'0', '" & CInt(CmbTipe.SelectedValue) & "', '" & c_voucher & "', '" & c_kelipatan & "', " & _
                                         " '" & c_layar & "','" & c_struk & "','" & c_limit & "','" & CDec(txtLimit.Text.Trim) & "','0','1', '" & CDec(txtMinPurcMem.Text.Trim) & "', " & _
                                         " '" & txtLayar1.Text & "','" & txtLayar2.Text & "','','','" & UsrID & "','1','0','0','0',GetDate(),'" & c_allItem & "', '" & c_Rafaksi & "') ")
                            getSqldbPromo("Insert Into Other_Detail ([branch_id],[doc_no],[sbu],[dept],[brand],[total_artikel],[total_inc]) Values ('" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "','" & txtDocNo.Text.Trim & "','','','',0,0) ")
                        End If
                        If CInt(CmbTipe.SelectedValue) = 50 Then
                            dsCek = getSqldbPromo("select * from CC_Master where Branch_ID = '" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "' And CC_Master = '" & Promo_ID & "'")
                            If dsCek.Tables(0).Rows.Count > 0 Then
                                If MsgBox("Bin card already exists !!!, delete the old data ??", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.No Then
                                    Exit Sub
                                End If
                                getSqldbPromo("delete from CC_Master where Branch_ID = '" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "' And CC_Master = '" & Promo_ID & "'")
                            End If
                            If cbDisc.Checked = True Then
                                getSqldbPromo("Insert into CC_Master select '" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "','" & Promo_ID & "',BIN,'' from Bin_Kartu where Bank = '" & cbBank1.SelectedValue & "' And Keterangan = 'Kartu Kredit'")
                            End If
                            If cbDisc2.Checked = True Then
                                getSqldbPromo("Insert into CC_Master select '" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "','" & Promo_ID & "',BIN,'' from Bin_Kartu where Bank = '" & cbBank2.SelectedValue & "' And Keterangan = 'Kartu Debit'")
                            End If
                        End If
                    Next

                Else
                    For Each checkBox In clbStore.Items
                        If clbStore.GetItemCheckState(clbStore.Items.IndexOf(checkBox)) Then
                            'If (checkBox.Checked = True) Then
                            'Dim cc As String = checkBox.ToString
                            getSqldbPromo("Update Promo_Hdr set " & _
                                          "doc_no = '" & txtDocNo.Text.Trim & "',promo_name = '" & txtDesc.Text.Trim & "', start_date = '" & Format(dtpForm.Value.Date, "yyyy-MM-dd ") & Format(dtpFromtime.Value, "HH:mm:ss") & "', " & _
                                          "end_date = '" & Format(dtpTo.Value.Date, "yyyy-MM-dd ") & Format(dtpTotime.Value, "HH:mm:ss") & "', min_purchase = '" & CDec(txtMinPurcNon.Text.Trim) & "', " & _
                                          "disc = '" & txtDisc.Text & "',tipe = '" & CInt(CmbTipe.SelectedValue) & "',voucher =  '" & c_voucher & "', " & _
                                          "lipat = '" & c_kelipatan & "',ismsg='" & c_layar & "',isprn='" & c_struk & "',islimit='" & c_limit & "',qtylimit='" & CDec(txtLimit.Text.Trim) & "', " & _
                                          "txt1 = '" & txtLayar1.Text & "',txt2 = '" & txtLayar2.Text & "', min_member = '" & CDec(txtMinPurcMem.Text.Trim) & "',updby='" & UsrID & "',UpdDt = GetDate(),[AllItemFlag] = '" & c_allItem & "',[Rafaksi] =  '" & c_Rafaksi & "' where Branch_ID = '" & branch & "' and doc_no  = '" & DocNo & "'")
                            Exit For
                        End If
                    Next


                End If
            Case 50
                If txtLayar1.Text = "" And txtLayar2.Text = "" Then
                    MsgBox("Please Input The Information !!!!!!")
                    txtLayar1.Focus()
                    Exit Sub
                End If
                If cbDisc.Checked = False And cbDisc2.Checked = False Then
                    MsgBox("Please Choose BIN card promo first !!!!!!")
                    cbDisc.Checked = True
                    Exit Sub
                End If
                If p_Edit = False Then
                    For Each checkBox In clbStore.Items
                        If clbStore.GetItemCheckState(clbStore.Items.IndexOf(checkBox)) Then
                            'If (checkBox.Checked = True) Then
                            'Dim cc As String = checkBox.ToString
                            getSqldbPromo("Insert Into Promo_Hdr ([Branch_ID],[doc_no],[promo_id],[promo_name],[start_date],[end_date]" & _
                                         ",[min_purchase],[disc],[tipe],[voucher],[lipat],[ismsg],[isprn],[islimit],[qtylimit]," & _
                                         "[qtyout],[aktif],[min_member],[txt1],[txt2],[txt3],[txt4],[updby],[StatusH],[StatusD],[StatusO],[transfer],[UpdDt],[AllItemFlag],[Rafaksi]) values ('" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "', " & _
                                         " '" & txtDocNo.Text.Trim & "', '" & Promo_ID & "','" & txtDesc.Text.Trim & "','" & Format(dtpForm.Value.Date, "yyyy-MM-dd ") & Format(dtpFromtime.Value, "HH:mm:ss") & "' " & _
                                         " ,'" & Format(dtpTo.Value.Date, "yyyy-MM-dd ") & Format(dtpTotime.Value, "HH:mm:ss") & "','" & CDec(txtMinPurcNon.Text.Trim) & "' " & _
                                         " ,'0', '" & CInt(CmbTipe.SelectedValue) & "', '" & c_voucher & "', '" & c_kelipatan & "', " & _
                                         " '" & c_layar & "','" & c_struk & "','" & c_limit & "','" & CDec(txtLimit.Text.Trim) & "','0','1', '" & CDec(txtMinPurcMem.Text.Trim) & "', " & _
                                         " '" & txtLayar1.Text & "','" & txtLayar2.Text & "','','','" & UsrID & "','1','0','0','0',GetDate(),'" & c_allItem & "', '" & c_Rafaksi & "') ")
                            If CInt(CmbTipe.SelectedValue) = 50 Then
                                dsCek = getSqldbPromo("select * from CC_Master where Branch_ID = '" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "' And CC_Master = '" & Promo_ID & "'")
                                If dsCek.Tables(0).Rows.Count > 0 Then
                                    If MsgBox("Bin card already exists !!!, delete the old data ??", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.No Then
                                        Exit Sub
                                    End If
                                    getSqldbPromo("delete from CC_Master where Branch_ID = '" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "' And CC_Master = '" & Promo_ID & "'")
                                    getSqldbPromo("Update Promo_Hdr set txt3 = '',txt4 = '' where Branch_ID = '" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "' And promo_id = '" & Promo_ID & "'")
                                End If
                                If cbDisc.Checked = True Then
                                    getSqldbPromo("Insert into CC_Master select distinct '" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "','" & Promo_ID & "',BIN,'' from Bin_Kartu where Bank = '" & cbBank1.SelectedValue & "' And Keterangan = 'Kartu Kredit'")
                                    getSqldbPromo("Update Promo_Hdr set txt3 = '1" & cbBank1.SelectedValue & "' where Branch_ID = '" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "' And promo_id = '" & Promo_ID & "'")
                                End If
                                If cbDisc2.Checked = True Then
                                    getSqldbPromo("Insert into CC_Master select distinct '" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "','" & Promo_ID & "',BIN,'' from Bin_Kartu where Bank = '" & cbBank2.SelectedValue & "' And Keterangan = 'Kartu Debit'")
                                    getSqldbPromo("Update Promo_Hdr set txt4 = '1" & cbBank2.SelectedValue & "' where Branch_ID = '" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "' And promo_id = '" & Promo_ID & "'")
                                End If
                            End If
                            getSqldbPromo("Insert Into Other_Detail ([branch_id],[doc_no],[sbu],[dept],[brand],[total_artikel],[total_inc]) Values ('" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "','" & txtDocNo.Text.Trim & "','','','',0,0) ")
                        End If

                    Next
                Else
                    For Each checkBox In clbStore.Items
                        If clbStore.GetItemCheckState(clbStore.Items.IndexOf(checkBox)) Then
                            'If (checkBox.Checked = True) Then
                            'Dim cc As String = checkBox.ToString
                            getSqldbPromo("Update Promo_Hdr set " & _
                                          "doc_no = '" & txtDocNo.Text.Trim & "',promo_name = '" & txtDesc.Text.Trim & "', start_date = '" & Format(dtpForm.Value.Date, "yyyy-MM-dd ") & Format(dtpFromtime.Value, "HH:mm:ss") & "', " & _
                                          "end_date = '" & Format(dtpTo.Value.Date, "yyyy-MM-dd ") & Format(dtpTotime.Value, "HH:mm:ss") & "', min_purchase = '" & CDec(txtMinPurcNon.Text.Trim) & "', " & _
                                          "disc = '" & txtDisc.Text & "',tipe = '" & CInt(CmbTipe.SelectedValue) & "',voucher =  '" & c_voucher & "', " & _
                                          "lipat = '" & c_kelipatan & "',ismsg='" & c_layar & "',isprn='" & c_struk & "',islimit='" & c_limit & "',qtylimit='" & CDec(txtLimit.Text.Trim) & "', " & _
                                          "txt1 = '" & txtLayar1.Text & "',txt2 = '" & txtLayar2.Text & "', min_member = '" & CDec(txtMinPurcMem.Text.Trim) & "',updby='" & UsrID & "',UpdDt = GetDate(),[AllItemFlag] = '" & c_allItem & "',[Rafaksi] =  '" & c_Rafaksi & "' where Branch_ID = '" & branch & "' and doc_no  = '" & DocNo & "'")
                            If CInt(CmbTipe.SelectedValue) = 50 Then
                                dsCek = getSqldbPromo("select * from CC_Master where Branch_ID = '" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "' And CC_Master = '" & Promo_ID & "'")
                                If dsCek.Tables(0).Rows.Count > 0 Then
                                    getSqldbPromo("delete from CC_Master where Branch_ID = '" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "' And CC_Master = '" & Promo_ID & "'")
                                    getSqldbPromo("Update Promo_Hdr set txt3 = '',txt4 = '' where Branch_ID = '" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "' And promo_id = '" & Promo_ID & "'")
                                End If
                                If cbDisc.Checked = True Then
                                    getSqldbPromo("Insert into CC_Master select distinct '" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "','" & Promo_ID & "',BIN,'' from Bin_Kartu where Bank = '" & cbBank1.SelectedValue & "' And Keterangan = 'Kartu Kredit'")
                                    getSqldbPromo("Update Promo_Hdr set txt3 = '1" & cbBank1.SelectedValue & "' where Branch_ID = '" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "' And promo_id = '" & Promo_ID & "'")
                                End If
                                If cbDisc2.Checked = True Then
                                    getSqldbPromo("Insert into CC_Master select distinct '" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "','" & Promo_ID & "',BIN,'' from Bin_Kartu where Bank = '" & cbBank2.SelectedValue & "' And Keterangan = 'Kartu Debit'")
                                    getSqldbPromo("Update Promo_Hdr set txt4 = '1" & cbBank2.SelectedValue & "' where Branch_ID = '" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "' And promo_id = '" & Promo_ID & "'")
                                End If
                            End If
                            'Exit For
                        End If

                    Next


                End If
            Case 75
                Dim txt3, txt4 As String
                Dim cnt, cnt2 As Integer

                If DataGridView1.RowCount = 0 Then
                    MsgBox("Please Insert Condition Promo On DataGrid !!!")
                    DataGridView1.Item(1, DataGridView1.CurrentRow.Index).Selected = True
                    DataGridView1.BeginEdit(True)
                    Exit Sub
                End If

                If p_Edit = False Then
                    For Each checkBox In clbStore.Items
                        cnt = 0 : cnt2 = 0 : txt3 = "" : txt4 = ""
                        If clbStore.GetItemCheckState(clbStore.Items.IndexOf(checkBox)) Then
                            For x = 0 To DataGridView1.RowCount - 1
                                If DataGridView1(1, x).Value <> Nothing Then
                                    txt3 &= DataGridView1(1, x).Value / 1000 & ","
                                    cnt += 1
                                End If
                            Next

                            For i As Integer = 100 To 999
                                DsPromo = getSqldbPromo("Select * from Promo_Dtl where Promo_id = '" & i & "' and branch_id = '" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "'")
                                If DsPromo.Tables(0).Rows.Count = 0 Then
                                    txt4 &= i & ","
                                    getSqldbPromo("Insert into promo_dtl ([Branch_ID],[promo_id],[PLU],[Description]) " & _
                                                  " Values ('" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "','" & i & "','','" & DataGridView1(2, cnt2).Value & "')")
                                    cnt2 += 1
                                End If
                                If cnt = cnt2 Then
                                    Exit For
                                End If
                            Next
                            txt3 = Mid(txt3, 1, txt3.Length - 1)
                            txt4 = Mid(txt4, 1, txt4.Length - 1)
                            getSqldbPromo("Insert Into Promo_Hdr ([Branch_ID],[doc_no],[promo_id],[promo_name],[start_date],[end_date]" & _
                                         ",[min_purchase],[disc],[tipe],[voucher],[lipat],[ismsg],[isprn],[islimit],[qtylimit]," & _
                                         "[qtyout],[aktif],[min_member],[txt1],[txt2],[txt3],[txt4],[updby],[StatusH],[StatusD],[StatusO],[transfer],[UpdDt],[AllItemFlag],[Rafaksi]) values ('" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "', " & _
                                         " '" & txtDocNo.Text.Trim & "', '" & Promo_ID & "','" & txtDesc.Text.Trim & "','" & Format(dtpForm.Value.Date, "yyyy-MM-dd ") & Format(dtpFromtime.Value, "HH:mm:ss") & "' " & _
                                         " ,'" & Format(dtpTo.Value.Date, "yyyy-MM-dd ") & Format(dtpTotime.Value, "HH:mm:ss") & "','" & CDec(txtMinPurcNon.Text.Trim) & "' " & _
                                         " ,'0', '" & CInt(CmbTipe.SelectedValue) & "', '" & c_voucher & "', '" & c_kelipatan & "', " & _
                                         " '0','0','0','0','0','1', '" & CDec(txtMinPurcMem.Text.Trim) & "', " & _
                                         " '','','" & txt3 & "','" & txt4 & "','" & UsrID & "','1','0','0','0',GetDate(), '" & c_allItem & "', '" & c_Rafaksi & "') ")
                            getSqldbPromo("Insert Into Other_Detail ([branch_id],[doc_no],[sbu],[dept],[brand],[total_artikel],[total_inc]) Values ('" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "','" & txtDocNo.Text.Trim & "','','','',0,0) ")
                        End If
                    Next
                Else
                    For Each checkBox In clbStore.Items
                        cnt = 0 : cnt2 = 0 : txt3 = "" : txt4 = ""
                        If clbStore.GetItemCheckState(clbStore.Items.IndexOf(checkBox)) Then
                            Dim parts2() As String = txt4ID.ToString.Trim().Split(","c)
                            Dim txt4str As String = ""
                            For x As Integer = 0 To parts2.Length - 1
                                If parts2(x) <> "" Then
                                    txt4str &= "'" & parts2(x) & "',"
                                End If
                            Next
                            txt4str = Mid(txt4str, 1, txt4str.Length - 1)
                            getSqldbPromo("delete from promo_dtl where Branch_ID = '" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "' and promo_id in (" & txt4str & ")")
                            For x = 0 To DataGridView1.RowCount - 1
                                If DataGridView1(1, x).Value <> Nothing Then
                                    txt3 &= DataGridView1(1, x).Value / 1000 & ","
                                    cnt += 1
                                End If
                            Next
                            For i As Integer = 100 To 999
                                DsPromo = getSqldbPromo("Select * from Promo_Dtl where Promo_id = '" & i & "'  and branch_id = '" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "'")
                                If DsPromo.Tables(0).Rows.Count = 0 Then
                                    txt4 &= i & ","
                                    getSqldbPromo("Insert into promo_dtl ([Branch_ID],[promo_id],[PLU],[Description]) " & _
                                                  " Values ('" & Microsoft.VisualBasic.Left(checkBox.ToString, 4) & "','" & i & "','','" & DataGridView1(2, cnt2).Value & "')")
                                    cnt2 += 1
                                End If
                                If cnt = cnt2 Then
                                    Exit For
                                End If
                            Next
                            txt3 = Mid(txt3, 1, txt3.Length - 1)
                            txt4 = Mid(txt4, 1, txt4.Length - 1)
                            getSqldbPromo("Update Promo_Hdr set " & _
                                          "doc_no = '" & txtDocNo.Text.Trim & "',promo_name = '" & txtDesc.Text.Trim & "', start_date = '" & Format(dtpForm.Value.Date, "yyyy-MM-dd ") & Format(dtpFromtime.Value, "HH:mm:ss") & "', " & _
                                          "end_date = '" & Format(dtpTo.Value.Date, "yyyy-MM-dd ") & Format(dtpTotime.Value, "HH:mm:ss") & "', min_purchase = '" & CDec(txtMinPurcNon.Text.Trim) & "', " & _
                                          "tipe = '" & CInt(CmbTipe.SelectedValue) & "',voucher =  '" & c_voucher & "', " & _
                                          "lipat = '" & c_kelipatan & "',txt3 = '" & txt3 & "',txt4 = '" & txt4 & "', " & _
                                          "min_member = '" & CDec(txtMinPurcMem.Text.Trim) & "',updby='" & UsrID & "',UpdDt = GetDate(),[AllItemFlag] = '" & c_allItem & "',[Rafaksi] =  '" & c_Rafaksi & "' where Branch_ID = '" & branch & "' and doc_no  = '" & DocNo & "'")
                            Exit For
                        End If
                    Next


                End If
        End Select
        MsgBox("Successfull !!!")
        Ulang()
        ToolStripMenuItem8.Enabled = False
        ToolStripMenuItem10.Enabled = False
    End Sub

    Sub Ulang()
        Try
            dgvPromo.DataSource = Nothing
            If GrpId = "6" And PromoGrpUsr <> "" Then
                DsHeader = getSqldbPromo("Select a.*,b.total_artikel,b.total_inc from promo_hdr a left join Other_Detail b on a.branch_id = b.branch_id and a.doc_no = b.doc_no where updBy in (" & PromoGrpUsr & ") Order by UpdDt desc")
            ElseIf GrpId = "0" Then
                DsHeader = getSqldbPromo("Select a.*,b.total_artikel,b.total_inc from promo_hdr a left join Other_Detail b on a.branch_id = b.branch_id and a.doc_no = b.doc_no Order by UpdDt desc")
            Else
                DsHeader = getSqldbPromo("Select a.*,b.total_artikel,b.total_inc from promo_hdr a left join Other_Detail b on a.branch_id = b.branch_id and a.doc_no = b.doc_no where updBy = '" & UsrID & "' Order by UpdDt desc")
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
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

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

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        txtDocNo.Enabled = True
        txtDocNo.Text = ""
        txtDocNo.Focus()
        ClearFind()
        p_Edit = True
        ToolStripMenuItem8.Enabled = True
        ToolStripMenuItem9.Enabled = True
    End Sub

    Sub ClearFind()
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
        ToolStripMenuItem1.Enabled = True
        ToolStripMenuItem4.Enabled = True
        ToolStripMenuItem7.Enabled = True
        ToolStripMenuItem8.Enabled = True
        txtDesc.Enabled = True
        'GroupBox4.Enabled = True
        txtLayar1.Clear()
        txtLayar2.Clear()
        txtDocNo.Focus()
    End Sub

    Private Sub txtDocNo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDocNo.KeyUp
        'If e.KeyCode = Keys.Enter Then
        '    DsHeader = getSqldbPromo("select * from promo_hdr where doc_no = '" & txtDocNo.Text & "'")
        '    If DsHeader.Tables(0).Rows.Count > 0 Then
        '        If DsHeader.Tables(0).Rows(0).Item("updBy").ToString.Trim <> UsrID Then
        '            MsgBox("User Tidak Punya Otorisasi !!!")
        '            Exit Sub
        '        End If
        '        txtDocNo.Enabled = False
        '        clbStore.Enabled = False
        '        For Each checkBox In clbStore.Items
        '            clbStore.SetItemChecked(clbStore.Items.IndexOf(checkBox), False)
        '            If DsHeader.Tables(0).Rows(0).Item("Branch_ID") = Microsoft.VisualBasic.Left(checkBox.ToString, 4) Then
        '                clbStore.SetItemChecked(clbStore.Items.IndexOf(checkBox), True)
        '            Else
        '                clbStore.SetItemChecked(clbStore.Items.IndexOf(checkBox), False)
        '            End If
        '        Next
        '        branch = DsHeader.Tables(0).Rows(0).Item("Branch_ID")
        '        txtDesc.Text = DsHeader.Tables(0).Rows(0).Item("promo_name")
        '        Promo_ID = DsHeader.Tables(0).Rows(0).Item("promo_id")
        '        dtpForm.Value = CDate(DsHeader.Tables(0).Rows(0).Item("start_date"))
        '        dtpFromtime.Value = CDate(DsHeader.Tables(0).Rows(0).Item("start_date"))
        '        dtpTo.Value = CDate(DsHeader.Tables(0).Rows(0).Item("end_date"))
        '        dtpTotime.Value = CDate(DsHeader.Tables(0).Rows(0).Item("end_date"))
        '        If DsHeader.Tables(0).Rows(0).Item("promo_id").ToString.Length = 1 Then
        '            CmbTipe.SelectedValue = "0" & DsHeader.Tables(0).Rows(0).Item("promo_id").ToString.Trim
        '        Else
        '            CmbTipe.SelectedValue = DsHeader.Tables(0).Rows(0).Item("promo_id").ToString.Trim()
        '        End If
        '        If DsHeader.Tables(0).Rows(0).Item("disc") = "0" Then
        '            txtDisc.Text = 0
        '            cbDisc.Checked = False
        '        Else
        '            txtDisc.Text = DsHeader.Tables(0).Rows(0).Item("disc")
        '            cbDisc.Checked = True
        '        End If
        '        If DsHeader.Tables(0).Rows(0).Item("islimit") = "0" Then
        '            txtLimit.Text = 0
        '            cbLimit.Checked = False
        '        Else
        '            txtLimit.Text = DsHeader.Tables(0).Rows(0).Item("islimit")
        '            cbLimit.Checked = True
        '        End If
        '        If DsHeader.Tables(0).Rows(0).Item("voucher") = "0" Then
        '            cbPembVoucher.Checked = False
        '        Else
        '            cbPembVoucher.Checked = True
        '        End If
        '        If DsHeader.Tables(0).Rows(0).Item("min_purchase") = "10000" Then
        '            txtMinPurcNon.Text = 10000
        '            cbMinPurcNon.Checked = False
        '        Else
        '            txtMinPurcNon.Text = DsHeader.Tables(0).Rows(0).Item("min_purchase")
        '            cbMinPurcNon.Checked = True
        '        End If
        '        If DsHeader.Tables(0).Rows(0).Item("min_member") = "10000" Then
        '            txtMinPurcMem.Text = 10000
        '            cbMinPurcMem.Checked = False
        '        Else
        '            txtMinPurcMem.Text = DsHeader.Tables(0).Rows(0).Item("min_member")
        '            cbMinPurcMem.Checked = True
        '        End If
        '        If DsHeader.Tables(0).Rows(0).Item("lipat") = "0" Then
        '            cbKelipatan.Checked = False
        '        Else
        '            cbKelipatan.Checked = True
        '        End If
        '        If DsHeader.Tables(0).Rows(0).Item("ismsg") = "0" Then
        '            cbMsgLayar.Checked = False
        '        Else
        '            cbMsgLayar.Checked = True
        '            txtLayar.Text = DsHeader.Tables(0).Rows(0).Item("txt1") & " " & DsHeader.Tables(0).Rows(0).Item("txt2")
        '        End If
        '        If DsHeader.Tables(0).Rows(0).Item("isprn") = "0" Then
        '            cbStruk.Checked = False
        '        Else
        '            cbStruk.Checked = True
        '            txtLayar.Text = DsHeader.Tables(0).Rows(0).Item("txt1") & " " & DsHeader.Tables(0).Rows(0).Item("txt2")
        '        End If
        '    End If
        'End If

        'DsHeader = getSqldbPromo("Select * from promo_hdr where updBy = '" & UsrID & "' And doc_no = '" & txtDocNo.Text & "' Order By UpdDt desc")
        'If DsHeader.Tables(0).Rows.Count > 0 Then
        '    dgvPromo.DataSource = DsHeader.Tables(0)
        '    dgvPromo.Refresh()
        '    dgvPromo_CellClick(dgvPromo, New DataGridViewCellEventArgs(0, 0))
        '    txtDesc.Focus()
        'End If

    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        If MsgBox("Promo Id Will be Deleted ??", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.Yes Then
            For Each rw As DataGridViewRow In dgvPromo.SelectedRows
                getSqldbPromo("Delete from promo_hdr where Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "' and doc_no  = '" & rw.Cells("doc_no").Value.ToString & "'")
                getSqldbPromo("Delete from promo_dtl where Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "' and promo_id = '" & rw.Cells("promo_id").Value.ToString & "'")
                getSqldbPromo("Delete from promo_dtl where Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "' and promo_id = '" & rw.Cells("promo_id").Value.ToString & "'")

                If PromoTypex = "75" Then
                    Dim parts2() As String = txt4ID.ToString.Trim().Split(","c)
                    Dim txt4str As String = ""
                    For x As Integer = 0 To parts2.Length - 1
                        If parts2(x) <> "" Then
                            txt4str &= "'" & parts2(x) & "',"
                        End If
                    Next
                    txt4str = Mid(txt4str, 1, txt4str.Length - 1)
                    getSqldbPromo("delete from promo_dtl where Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "' and promo_id in (" & txt4str & ")")
                End If


                dsCek = getSqldbPromo("select * from  promo_hdr where Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "' and doc_no  = '" & rw.Cells("doc_no").Value.ToString & "' Order By UpdDt desc")
                If dsCek.Tables(0).Rows.Count = 0 Then
                    getSqldbPromo("Delete from Other_Detail where doc_no  = '" & rw.Cells("doc_no").Value.ToString & "' and Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "'")
                End If
            Next



            p_Edit = False
            ToolStripMenuItem8.Enabled = False
            ToolStripMenuItem9.Enabled = False
            Clear()
            Ulang()
            ToolStripMenuItem8.Enabled = False
            ToolStripMenuItem10.Enabled = False
        End If
    End Sub

    Private Sub Checker2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

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


    'Private Sub clbStore_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles clbStore.Click
    '    clbStore.CheckOnClick = True
    'End Sub

    Private Sub clbStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clbStore.Click
        clbStore.CheckOnClick = True
    End Sub

    Private Sub dgvPromo_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPromo.CellClick
        Try
            p_Edit = True
            ToolStripMenuItem8.Enabled = True
            ToolStripMenuItem9.Enabled = True
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
            c_allItemklik = dgvPromo.Item("AllItemFlag", e.RowIndex).Value
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

            If dgvPromo.Item("tipe", e.RowIndex).Value.ToString = "75" Then
                txt3ID = dgvPromo.Item("txt3", e.RowIndex).Value
                txt4ID = dgvPromo.Item("txt4", e.RowIndex).Value
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
                    'cbDisc.Text = "Disc 2"
                    'cbDisc2.Text = "Disc 3"
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
                Case "75"
                    For a = 1 To DataGridView1.Rows.Count
                        DataGridView1.Rows.RemoveAt(0)
                    Next
                    Dim parts() As String = dgvPromo.Item("txt3", e.RowIndex).Value.ToString.Trim().Split(","c)
                    Dim parts2() As String = dgvPromo.Item("txt4", e.RowIndex).Value.ToString.Trim().Split(","c)

                    For x As Integer = 0 To parts.Length - 1
                        If parts(x) <> "" Then
                            DataGridView1.Rows.Add(1)
                            DataGridView1.Item(1, DataGridView1.Rows.Count - 1).Value = CDec(parts(x) * 1000).ToString("N0")
                        End If
                    Next
                    Dim dsView As New DataSet
                    For x As Integer = 0 To DataGridView1.Rows.Count - 1
                        dsView = getSqldbPromo("Select * from promo_dtl where Branch_id = '" & branch & "' and promo_id = '" & parts2(x) & "' ")
                        If dsView.Tables(0).Rows.Count > 0 Then
                            DataGridView1.Item(2, x).Value = dsView.Tables(0).Rows(0).Item("Description")
                            DataGridView1.Item(0, x).Value = dsView.Tables(0).Rows(0).Item("Promo_Id")
                        End If
                    Next
                    'DataGridView1.Rows.Add(1)
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
                ToolStripMenuItem1.Enabled = True
                ToolStripMenuItem4.Enabled = True
                ToolStripMenuItem7.Enabled = True
                ToolStripMenuItem8.Enabled = True
                ToolStripMenuItem9.Enabled = True
                txtDesc.Enabled = True
                'GroupBox4.Enabled = True
            Else
                GroupBox1.Enabled = False
                ToolStripMenuItem1.Enabled = False
                ToolStripMenuItem4.Enabled = False
                ToolStripMenuItem7.Enabled = False
                ToolStripMenuItem8.Enabled = False
                ToolStripMenuItem9.Enabled = False
                txtDesc.Enabled = False
                'GroupBox4.Enabled = False
            End If
            totalart = dgvPromo.Item("total_artikel", e.RowIndex).Value.ToString.Trim()
            totalinc = dgvPromo.Item("total_inc", e.RowIndex).Value.ToString.Trim()
            ToolStripMenuItem9.Enabled = False
            Select Case CmbTipe.SelectedValue
                Case "19", "23", "35"
                    ToolStripMenuItem9.Enabled = True
            End Select
            ToolStripMenuItem8.Enabled = True
            ToolStripMenuItem10.Enabled = True
            txtDesc.Select()
            txtDesc.Focus()

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        p_Edit = False
        txtDocNo.Enabled = False
        ToolStripMenuItem8.Enabled = False
        ToolStripMenuItem9.Enabled = False
        Clear()
        ToolStripMenuItem8.Enabled = False
        ToolStripMenuItem10.Enabled = False
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
        CekDocNo()
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
        ToolStripMenuItem1.Enabled = True
        ToolStripMenuItem4.Enabled = True
        ToolStripMenuItem7.Enabled = True
        ToolStripMenuItem8.Enabled = True
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

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        Try
            Dim dsF As New DataSet
            Dim dsFx As New DataSet
            Dim dsS As New DataSet
            Dim str As String
            Dim MoreData As Boolean
            Dim strDocNo As String = ""
            If dgvPromo.SelectedRows.Count > 1 Then
                If MsgBox("Print Selected Promo ??", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.Yes Then

                    For Each rw As DataGridViewRow In dgvPromo.SelectedRows
                        strDocNo &= "'" & rw.Cells("doc_no").Value.ToString & "',"
                    Next
                    strDocNo = Microsoft.VisualBasic.Left(strDocNo, strDocNo.Length - 1)
                    dsFx = getSqldbPromo("Select * from v_Formulir3 where doc_no in (" & strDocNo & ")")
                    cryRpt = New SelectedReportPromo2
                    If dsFx.Tables(0).Rows.Count > 1 Then
                        cryRpt.SetDataSource(dsFx.Tables(0))
                    End If

                    cryRpt.SetDatabaseLogon("sa", "star")
                    cryRpt.SetParameterValue("User", UserLogin)
                    'If GrpId = "6" Then
                    '    cryRpt.SetParameterValue("WhoPrint", "RePrint")
                    'Else
                    '    cryRpt.SetParameterValue("WhoPrint", "")
                    'End If

                    Report.CrystalReportViewer1.ReportSource = cryRpt
                    Report.ShowDialog()
                    Report.TopMost = True
                    Exit Sub
                End If
            End If



            If PromoTypex = "75" Then
                dsF = getSqldbPromo("Select * from v_Formulir1 where doc_no = '" & DocNo & "'")
                cryRpt = New PromoReportver2
            Else
                dsF = getSqldbPromo("Select * from v_Formulir where doc_no = '" & DocNo & "'")
                cryRpt = New PromoReport
            End If

            If c_allItemklik = "1" Then
                dsF = getSqldbPromo("Select * from v_Formulir1 where doc_no = '" & DocNo & "'")
                cryRpt = New PromoReportAll
            End If


            If dsF.Tables(0).Rows.Count > 0 Then
                If dsF.Tables(0).Rows.Count > 1 Then
                    MoreData = True
                Else
                    MoreData = False
                End If
                If MoreData = True Then
                    dsFx = getSqldbPromo("Select * from v_Formulir2 where doc_no = '" & DocNo & "'")
                    If dsFx.Tables(0).Rows.Count > 1 Then

                        cryRpt.SetDataSource(dsFx.Tables(0))
                        str = ""
                        dsS = getSqldbPromo("Select * from Promo_Hdr where doc_no = '" & DocNo & "' And Branch_ID = 'HO01'")
                        If dsS.Tables(0).Rows.Count > 0 Then
                            str &= "1"
                        Else
                            str &= "0"
                        End If
                        dsS = getSqldbPromo("Select * from Promo_Hdr where doc_no = '" & DocNo & "' And Branch_ID = 'S001'")
                        If dsS.Tables(0).Rows.Count > 0 Then
                            str &= "1"
                        Else
                            str &= "0"
                        End If
                        dsS = getSqldbPromo("Select * from Promo_Hdr where doc_no = '" & DocNo & "' And Branch_ID = 'S002'")
                        If dsS.Tables(0).Rows.Count > 0 Then
                            str &= "1"
                        Else
                            str &= "0"
                        End If
                        dsS = getSqldbPromo("Select * from Promo_Hdr where doc_no = '" & DocNo & "' And Branch_ID = 'S003'")
                        If dsS.Tables(0).Rows.Count > 0 Then
                            str &= "1"
                        Else
                            str &= "0"
                        End If

                        cryRpt.SetParameterValue("Store", str)
                        cryRpt.SetParameterValue("MoreData", MoreData)
                        cryRpt.SetParameterValue("User", UserLogin)
                        If GrpId = "6" Then
                            cryRpt.SetParameterValue("WhoPrint", "RePrint")
                        Else
                            cryRpt.SetParameterValue("WhoPrint", "")
                        End If

                        Report.CrystalReportViewer1.ReportSource = cryRpt
                        Report.ShowDialog()
                        Report.TopMost = True
                    End If
                Else
                    cryRpt.SetDataSource(dsF.Tables(0))
                    str = ""
                    dsS = getSqldbPromo("Select * from Promo_Hdr where doc_no = '" & DocNo & "' And Branch_ID = 'HO01'")
                    If dsS.Tables(0).Rows.Count > 0 Then
                        str &= "1"
                    Else
                        str &= "0"
                    End If
                    dsS = getSqldbPromo("Select * from Promo_Hdr where doc_no = '" & DocNo & "' And Branch_ID = 'S001'")
                    If dsS.Tables(0).Rows.Count > 0 Then
                        str &= "1"
                    Else
                        str &= "0"
                    End If
                    dsS = getSqldbPromo("Select * from Promo_Hdr where doc_no = '" & DocNo & "' And Branch_ID = 'S002'")
                    If dsS.Tables(0).Rows.Count > 0 Then
                        str &= "1"
                    Else
                        str &= "0"
                    End If
                    dsS = getSqldbPromo("Select * from Promo_Hdr where doc_no = '" & DocNo & "' And Branch_ID = 'S003'")
                    If dsS.Tables(0).Rows.Count > 0 Then
                        str &= "1"
                    Else
                        str &= "0"
                    End If

                    cryRpt.SetParameterValue("Store", str)
                    cryRpt.SetParameterValue("MoreData", MoreData)
                    cryRpt.SetParameterValue("User", UserLogin)
                    If GrpId = "6" Then
                        cryRpt.SetParameterValue("WhoPrint", "RePrint")
                    Else
                        cryRpt.SetParameterValue("WhoPrint", "")
                    End If
                    Report.CrystalReportViewer1.ReportSource = cryRpt
                    Report.ShowDialog()
                    Report.TopMost = True
                End If

            Else
                MsgBox("No Result!!!", MsgBoxStyle.Information, "Information")
                'CheckBox1.Visible = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem7.Click
        Download_Master.MdiParent = FormMain
        Download_Master.Show()
    End Sub

    Private Sub ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem8.Click

        Label10.Visible = True
        ProgressBar1.Visible = True
        
        openFileDialog1.DefaultExt = "xlsx"
        openFileDialog1.FileName = ""
        openFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        openFileDialog1.Filter = "Excel 97-2003 Template (*.xls)|*.xls|Excel Workbook (*.xlsx*)|*.xlsx*"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            myStream = openFileDialog1.OpenFile()
            MenuStrip1.Enabled = False
            dgvPromo.Enabled = False
            BackgroundWorker1.WorkerReportsProgress = True
            BackgroundWorker1.WorkerSupportsCancellation = True
            BackgroundWorker1.RunWorkerAsync()
            'UploadDetailExcel()
        End If


    End Sub



    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Me.Close()
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
            'If p_Edit = True Then
            '    Exit Sub
            'End If
            cbLimit.Text = "Limit (Qty)"
            Select Case CInt(CmbTipe.SelectedValue)
                Case 2, 3, 6, 11, 26
                    OnOffCtrl(True, False, False, False, False, False, False, False, False, False)
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
                    OnOffCtrl(True, True, False, False, False, False, False, False, False, False)
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
                Case 4
                    OnOffCtrl(True, True, False, False, False, False, False, False, False, False)
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
                Case 8
                    OnOffCtrl(True, True, False, False, True, False, False, False, False, False)
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
                Case 15
                    OnOffCtrl(True, True, False, False, True, False, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Disc Non"
                    cbDisc2.Text = "Disc Promo"
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
                    OnOffCtrl(True, True, False, False, True, False, False, False, False, False)
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
                    OnOffCtrl(True, True, False, False, True, False, False, False, False, False)
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
                Case 22
                    OnOffCtrl(True, True, True, False, True, False, False, False, False, False)
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
                    cbLimit.Text = "Disc Buy3"
                Case 18
                    OnOffCtrl(True, True, False, False, True, False, False, False, False, False)
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
                Case 29
                    OnOffCtrl(True, True, False, False, True, False, False, False, False, False)
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
                Case 7
                    OnOffCtrl(True, True, False, False, True, False, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Disc Emp"
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
                    OnOffCtrl(False, False, True, False, False, True, True, True, True, False)
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
                    OnOffCtrl(False, False, True, False, False, True, True, True, True, False)
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
                    OnOffCtrl(True, True, True, False, False, True, True, True, True, False)
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
                    OnOffCtrl(True, False, False, False, False, False, False, False, False, False)
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
                    OnOffCtrl(True, True, False, True, True, False, False, False, False, False)
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
                    OnOffCtrl(True, True, False, True, True, False, False, False, False, False)
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
                Case 75
                    OnOffCtrl(True, True, False, True, True, False, False, False, False, True)
                    If p_Edit = False Then
                        For a = 1 To DataGridView1.Rows.Count
                            DataGridView1.Rows.RemoveAt(0)
                        Next
                        DataGridView1.Rows.Add(1)
                        DataGridView1.Item(1, DataGridView1.CurrentRow.Index).Selected = True
                        DataGridView1.BeginEdit(True)
                    End If
            End Select
            CekDocNo()
        End If
    End Sub

    Private Sub CmbTipe_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbTipe.TabIndexChanged
        If t_Load = True Then
            If p_Edit = True Then
                Exit Sub
            End If
            cbLimit.Text = "Limit (Qty)"
            Select Case CInt(CmbTipe.SelectedValue)
                Case 2, 3, 6, 11, 26
                    OnOffCtrl(True, False, False, False, False, False, False, False, False, False)
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
                    OnOffCtrl(True, True, False, False, False, False, False, False, False, False)
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
                Case 4
                    OnOffCtrl(True, True, False, False, False, False, False, False, False, False)
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
                Case 8
                    OnOffCtrl(True, True, False, False, True, False, False, False, False, False)
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
                Case 15
                    OnOffCtrl(True, True, False, False, True, False, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Disc Non"
                    cbDisc2.Text = "Disc Promo"
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
                    OnOffCtrl(True, True, False, False, True, False, False, False, False, False)
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
                    OnOffCtrl(True, True, False, False, True, False, False, False, False, False)
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
                Case 22
                    OnOffCtrl(True, True, True, False, True, False, False, False, False, False)
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
                    cbLimit.Text = "Disc Buy3"
                Case 18
                    OnOffCtrl(True, True, False, False, True, False, False, False, False, False)
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
                Case 29
                    OnOffCtrl(True, True, False, False, True, False, False, False, False, False)
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
                Case 7
                    OnOffCtrl(True, True, False, False, True, False, False, False, False, False)
                    'ToolStripMenuItem9.Visible = False
                    cbDisc.Text = "Disc Emp"
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
                    OnOffCtrl(False, False, True, False, False, True, True, True, True, False)
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
                    OnOffCtrl(False, False, True, False, False, True, True, True, True, False)
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
                    OnOffCtrl(True, True, True, False, False, True, True, True, True, False)
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
                    OnOffCtrl(True, False, False, False, False, False, False, False, False, False)
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
                    OnOffCtrl(True, True, False, True, True, False, False, False, False, False)
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
                    OnOffCtrl(True, True, False, True, True, False, False, False, False, False)
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
                Case 75
                    OnOffCtrl(True, True, False, True, True, False, False, False, False, True)
                    If p_Edit = False Then
                        For a = 1 To DataGridView1.Rows.Count
                            DataGridView1.Rows.RemoveAt(0)
                        Next
                        DataGridView1.Rows.Add(1)
                        DataGridView1.Item(1, DataGridView1.CurrentRow.Index).Selected = True
                        DataGridView1.BeginEdit(True)
                    End If
            End Select
            CekDocNo()
        End If
    End Sub

    Private Sub ToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem9.Click
        'UploadOtherNotepad()
        ProgressBar1.Value = 0
        ProgressBar1.Visible = True
        Dim dsDetail As DataSet
        TotArt = 0
        Prg = 0
        Ecount = 0
        prid = ""
        For i As Integer = 100 To 999

            If PromoTypex = "35" Then
                prid = "666"
            Else
                prid = i
            End If
            DsPromo = getSqldbPromo("Select * from Promo_Dtl where Promo_id = '" & prid & "' and branch_id = '" & branch & "'")
            If DsPromo.Tables(0).Rows.Count = 0 Then
                If PromoTypex = "23" Then
                    dsDetail = getSqldbPromo("select txt2 as PromoInc from PROMO_hdr a inner join promo_dtl b on a.txt2 = b.promo_id where a.Branch_ID = '" & branch & "' and a.promo_id = '" & Promo_ID & "'")
                Else
                    dsDetail = getSqldbPromo("select txt1 as PromoInc from PROMO_hdr a inner join promo_dtl b on a.txt1 = b.promo_id where a.Branch_ID = '" & branch & "' and a.promo_id = '" & Promo_ID & "'")
                End If

                If dsDetail.Tables(0).Rows.Count > 0 Then
                    If MsgBox("The data already exists !!!, delete the old data ??", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.No Then
                        Exit Sub
                    End If
                    getSqldbPromo("delete from Promo_Dtl where promo_id = '" & dsDetail.Tables(0).Rows(0).Item("PromoInc") & "' and Branch_ID = '" & branch & "'")
                    getSqldbPromo("update Other_Detail set total_inc = 0 where doc_no = '" & DocNo & "' and Branch_ID = '" & branch & "' ")
                End If
1:
                openFileDialog1.DefaultExt = "xlsx"
                openFileDialog1.FileName = ""
                openFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                openFileDialog1.Filter = "Excel 97-2003 Template (*.xls)|*.xls|Excel Workbook (*.xlsx*)|*.xlsx*"
                openFileDialog1.FilterIndex = 2
                openFileDialog1.RestoreDirectory = True

                If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    myStream = openFileDialog1.OpenFile()
                    MenuStrip1.Enabled = False
                    BackgroundWorker2.WorkerReportsProgress = True
                    BackgroundWorker2.WorkerSupportsCancellation = True
                    BackgroundWorker2.RunWorkerAsync()
                End If
                Exit For
            Else
                If PromoTypex = "35" Then
                    If MsgBox("The data already exists !!!, delete the old data ??", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.No Then
                        Exit Sub
                    End If
                    getSqldbPromo("delete from Promo_Dtl where promo_id = '" & prid & "' and Branch_ID = '" & branch & "'")
                    getSqldbPromo("update Other_Detail set total_inc = 0 where doc_no = '" & DocNo & "'  and Branch_ID = '" & branch & "'")
                    GoTo 1
                End If
            End If
        Next

    End Sub

    Private Sub dgvPromo_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPromo.CellDoubleClick
        Dim sFileName As String
        Dim txtFileNew As String = Now.Year & Now.Month
        Dim PLUStr As String = ""
        Dim loopgb1 As Integer = 0
        Dim line As String = ""
        Dim dsFile As DataSet
        If File.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\PromoDetail.xlsx") Then
            Try
                File.Delete(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\PromoDetail.xlsx")
            Catch ex As Exception
                MsgBox("File is Being Opened !!!")
                Exit Sub
            End Try

        End If
        
        sFileName = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\PromoDetail.xlsx"
        dsFile = getSqldbPromo("Select b.dp2,substring(b.burui,2,2),b.brand, a.PLU,a.Description from Promo_dtl a inner join [HODBASE01].CentralPOS.dbo.item_master b on a.plu = b.plu where a.branch_id = '" & dgvPromo.Item(0, e.RowIndex).Value & "' And a.Promo_id  = '" & dgvPromo.Item(2, e.RowIndex).Value & "' and b.branch_id = '" & dgvPromo.Item(0, e.RowIndex).Value & "'")
        If dsFile.Tables(0).Rows.Count > 0 Then
            Dim chartRange As Excel.Range
            Dim xl As Object
            Dim xlWorkBook As Object
            Dim xlWorksheet As Object
            Dim dsExcel As New DataSet
            Dim Opt As String = ""
            xl = CreateObject("Excel.Application")
            If Dir(sFileName) = "" Then
                xlWorkBook = xl.Workbooks.Add  'File doesnt exist - add a new workbook
            Else
                xlWorkBook = xl.Workbooks.Open(sFileName)  'File exists - load it
            End If
            xlWorksheet = xlWorkBook.Worksheets(1)  'Work with the first worksheet
            'xl.Visible = True
            xlWorksheet.UsedRange.Clear()
            chartRange = xlWorksheet.Range("a3", "e3")
            chartRange.BorderAround(Excel.XlLineStyle.xlDouble, _
            Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex. _
            xlColorIndexAutomatic)
            xl.cells(1, 1) = ("Master Data")
            'xlWorksheet.Range("A3:F3").EntireColumn.AutoFit()
            'xlWorksheet.Range("a1", "a1").Font.Name = "Arial"
            xlWorksheet.Range("a1", "a1").Font.Size = 12
            xlWorksheet.Range("a1", "a1").Font.Bold = True
            xlWorksheet.Range("a3", "e3").Font.Size = 12
            xlWorksheet.Range("a3", "e3").Font.Bold = True
            xlWorksheet.Range("d4", "d" & dsFile.Tables(0).Rows.Count + 3).numberformat = "00"
            xl.cells(3, 1) = "SBU"
            xl.cells(3, 2) = "Dept"
            xl.cells(3, 3) = "Brand"
            xl.cells(3, 4) = "PLU"
            xl.cells(3, 5) = "Description"

            Dim x As Integer = 0
            For Each ro As DataRow In dsFile.Tables(0).Rows

                For y As Integer = 1 To 5
                    If y = 4 Then
                        xl.cells(x + 4, y) = "'" & ro(y - 1).ToString
                    Else
                        xl.cells(x + 4, y) = ro(y - 1).ToString
                    End If
                Next
                x += 1
            Next

            xlWorksheet.Columns("A:E").AutoFit()
            Try
                xlWorkBook.SaveAs(sFileName)
            Catch ex As Exception

            End Try
            'Save (and disconnect from) the Workbook
            xlWorkBook.Close(SaveChanges:=True)

            xlWorkBook = Nothing
            xl.Quit()                                'Close (and disconnect from) Excel
            xl = Nothing
            'make sure you clean up Excel, and SQL objects

            Process.Start(sFileName)
        End If

        sFileName = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Promo.xlsx"
        If dgvPromo.Item(8, e.RowIndex).Value = "19" Or dgvPromo.Item(8, e.RowIndex).Value = "35" Then
            line = ""
            If File.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Promo.xlsx") Then
                Try
                    File.Delete(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Promo.xlsx")
                Catch ex As Exception
                    MsgBox("File is Being Opened !!!")
                    Exit Sub
                End Try

            End If

            If dgvPromo.Item(8, e.RowIndex).Value = "19" Then
                dsFile = getSqldbPromo("Select b.dp2,substring(b.burui,2,2),b.brand, a.PLU,a.Description from Promo_dtl a inner join [HODBASE01].CentralPOS.dbo.item_master b on a.plu = b.plu where a.branch_id = '" & dgvPromo.Item(0, e.RowIndex).Value & "' And a.Promo_id  = '" & dgvPromo.Item(18, e.RowIndex).Value & "' and b.branch_id = '" & dgvPromo.Item(0, e.RowIndex).Value & "' ")
            Else
                dsFile = getSqldbPromo("Select b.dp2,substring(b.burui,2,2),b.brand, a.PLU,a.Description from Promo_dtl a inner join [HODBASE01].CentralPOS.dbo.item_master b on a.plu = b.plu where a.branch_id = '" & dgvPromo.Item(0, e.RowIndex).Value & "' And a.Promo_id  = '" & dgvPromo.Item(20, e.RowIndex).Value & "' and b.branch_id = '" & dgvPromo.Item(0, e.RowIndex).Value & "' ")
            End If

            If dsFile.Tables(0).Rows.Count > 0 Then
                Dim chartRange As Excel.Range
                Dim xl As Object
                Dim xlWorkBook As Object
                Dim xlWorksheet As Object
                Dim dsExcel As New DataSet
                Dim Opt As String = ""
                xl = CreateObject("Excel.Application")
                If Dir(sFileName) = "" Then
                    xlWorkBook = xl.Workbooks.Add  'File doesnt exist - add a new workbook
                Else
                    xlWorkBook = xl.Workbooks.Open(sFileName)  'File exists - load it
                End If
                xlWorksheet = xlWorkBook.Worksheets(1)  'Work with the first worksheet
                'xl.Visible = True
                xlWorksheet.UsedRange.Clear()
                chartRange = xlWorksheet.Range("a3", "e3")
                chartRange.BorderAround(Excel.XlLineStyle.xlDouble, _
                Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex. _
                xlColorIndexAutomatic)
                xl.cells(1, 1) = ("Master Data Include")
                'xlWorksheet.Range("A3:F3").EntireColumn.AutoFit()
                'xlWorksheet.Range("a1", "a1").Font.Name = "Arial"
                xlWorksheet.Range("a1", "a1").Font.Size = 12
                xlWorksheet.Range("a1", "a1").Font.Bold = True
                xlWorksheet.Range("a3", "e3").Font.Size = 12
                xlWorksheet.Range("a3", "e3").Font.Bold = True
                xlWorksheet.Range("d4", "d" & dsFile.Tables(0).Rows.Count + 3).numberformat = "00"
                xl.cells(3, 1) = "SBU"
                xl.cells(3, 2) = "Dept"
                xl.cells(3, 3) = "Brand"
                xl.cells(3, 4) = "PLU"
                xl.cells(3, 5) = "Description"

                Dim x As Integer = 0
                For Each ro As DataRow In dsFile.Tables(0).Rows
                    For y As Integer = 1 To 5
                        xl.cells(x + 4, y) = ro(y - 1).ToString
                    Next
                    x += 1
                Next

                xlWorksheet.Columns("A:E").AutoFit()
                Try
                    xlWorkBook.SaveAs(sFileName)
                Catch ex As Exception

                End Try
                'Save (and disconnect from) the Workbook
                xlWorkBook.Close(SaveChanges:=True)

                xlWorkBook = Nothing
                xl.Quit()                                'Close (and disconnect from) Excel
                xl = Nothing
                'make sure you clean up Excel, and SQL objects

                Process.Start(sFileName)
            End If
        End If
    End Sub

    Private Sub Approved2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Approved2ToolStripMenuItem.Click
        Dim dsCekActPromo As New DataSet
        dsCekActPromo = getSqldbPromo("select * from [192.168.5.3].POS_SERVER.dbo.Promo_Hdr where convert(varchar(10),end_date,112) < convert(varchar(10),getdate(),112)")
        If dsCekActPromo.Tables(0).Rows.Count > 0 Then
            MsgBox("There's promo that have expired !!Please Delete it first (MKG)")
            If MsgBox("Delete All that expired promo (MKG)", MsgBoxStyle.YesNo, "Attentions!!!") = MsgBoxResult.Yes Then
                MenuStrip1.Enabled = False
                getSqldbPromo("delete from [192.168.5.3].POS_SERVER.dbo.promo_dtl where promo_id in (select distinct promo_id from [192.168.5.3].POS_SERVER.dbo.Promo_Hdr where convert(varchar(10),end_date,112) < convert(varchar(10),getdate(),112))")
                getSqldbPromo("delete from [192.168.5.3].POS_SERVER.dbo.promo_hdr where promo_id in (select distinct promo_id from [192.168.5.3].POS_SERVER.dbo.Promo_Hdr where convert(varchar(10),end_date,112) < convert(varchar(10),getdate(),112))")
                MsgBox("Deleted Success!!!")
                MenuStrip1.Enabled = True
            End If
            Exit Sub
        End If
        dsCekActPromo.Clear()
        dsCekActPromo = getSqldbPromo("select * from [192.168.2.220].POS_SERVER.dbo.Promo_Hdr where convert(varchar(10),end_date,112) < convert(varchar(10),getdate(),112)")
        If dsCekActPromo.Tables(0).Rows.Count > 0 Then
            MsgBox("There's promo that have expired !!Please remove it first (SMS)")
            If MsgBox("Delete All that expired promo (SMS)", MsgBoxStyle.YesNo, "Attentions!!!") = MsgBoxResult.Yes Then
                MenuStrip1.Enabled = False
                getSqldbPromo("delete from [192.168.2.220].POS_SERVER.dbo.promo_dtl where promo_id in (select distinct promo_id from [192.168.2.220].POS_SERVER.dbo.Promo_Hdr where convert(varchar(10),end_date,112) < convert(varchar(10),getdate(),112))")
                getSqldbPromo("delete from [192.168.2.220].POS_SERVER.dbo.promo_hdr where promo_id in (select distinct promo_id from [192.168.2.220].POS_SERVER.dbo.Promo_Hdr where convert(varchar(10),end_date,112) < convert(varchar(10),getdate(),112))")
                MsgBox("Deleted Success!!!")
                MenuStrip1.Enabled = True
            End If
            Exit Sub
        End If
        dsCekActPromo.Clear()
        dsCekActPromo = getSqldbPromo("select * from [192.168.3.11].POS_SERVER.dbo.Promo_Hdr where convert(varchar(10),end_date,112) < convert(varchar(10),getdate(),112)")
        If dsCekActPromo.Tables(0).Rows.Count > 0 Then
            MsgBox("There's promo that have expired !!Please remove it first (SMB)")
            If MsgBox("Delete All that expired promo (SMB)", MsgBoxStyle.YesNo, "Attentions!!!") = MsgBoxResult.Yes Then
                MenuStrip1.Enabled = False
                getSqldbPromo("delete from [192.168.3.11].POS_SERVER.dbo.promo_dtl where promo_id in (select distinct promo_id from [192.168.3.11].POS_SERVER.dbo.Promo_Hdr where convert(varchar(10),end_date,112) < convert(varchar(10),getdate(),112))")
                getSqldbPromo("delete from [192.168.3.11].POS_SERVER.dbo.promo_hdr where promo_id in (select distinct promo_id from [192.168.3.11].POS_SERVER.dbo.Promo_Hdr where convert(varchar(10),end_date,112) < convert(varchar(10),getdate(),112))")
                MsgBox("Deleted Success!!!")
                MenuStrip1.Enabled = True

            End If
            Exit Sub
        End If

        dsCekActPromo.Clear()
        dsCekActPromo = getSqldbPromo("select * from [192.168.6.10].POS_SERVER.dbo.Promo_Hdr where convert(varchar(10),end_date,112) < convert(varchar(10),getdate(),112)")
        If dsCekActPromo.Tables(0).Rows.Count > 0 Then
            MsgBox("There's promo that have expired !!Please remove it first (SMB)")
            If MsgBox("Delete All that expired promo (LAKON)", MsgBoxStyle.YesNo, "Attentions!!!") = MsgBoxResult.Yes Then
                MenuStrip1.Enabled = False
                getSqldbPromo("delete from [192.168.6.10].POS_SERVER.dbo.promo_dtl where promo_id in (select distinct promo_id from [192.168.6.10].POS_SERVER.dbo.Promo_Hdr where convert(varchar(10),end_date,112) < convert(varchar(10),getdate(),112))")
                getSqldbPromo("delete from [192.168.6.10].POS_SERVER.dbo.promo_hdr where promo_id in (select distinct promo_id from [192.168.6.10].POS_SERVER.dbo.Promo_Hdr where convert(varchar(10),end_date,112) < convert(varchar(10),getdate(),112))")
                MsgBox("Deleted Success!!!")
                MenuStrip1.Enabled = True

            End If
            Exit Sub
        End If

        'Query Delete promo expired
        'delete from promo_dtl where promo_id in (select distinct promo_id from Promo_Hdr where convert(varchar(10),end_date,112) < convert(varchar(10),getdate(),112))
        'delete from promo_hdr where promo_id in (select distinct promo_id from Promo_Hdr where convert(varchar(10),end_date,112) < convert(varchar(10),getdate(),112))


        ProgressBar1.Visible = True
        Label10.Visible = True
        Prg = 0
        Ecount = 0

        MenuStrip1.Enabled = False
        BackgroundWorker3.WorkerReportsProgress = True
        BackgroundWorker3.WorkerSupportsCancellation = True
        BackgroundWorker3.RunWorkerAsync()



    End Sub

    Sub UploadDetailExcel()
        Dim dsDetail As DataSet
        Dim myStream As Stream = Nothing
        Dim openFileDialog1 As New OpenFileDialog()
        Dim ds_CheckMaster As New DataSet
        Dim sbu, dept, brand As String
        Dim TotArt As Integer = 0
        If Promo_ID = "" Then
            MsgBox("Please Choose Promo First !!!")
            Exit Sub
        End If
        dsDetail = getSqldbPromo("Select * from promo_dtl where promo_id = '" & Promo_ID & "' and Branch_ID = '" & branch & "'")
        If dsDetail.Tables(0).Rows.Count > 0 Then
            If MsgBox("The data already exists !!!, delete the old data ??", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.No Then
                Exit Sub
            End If
            getSqldbPromo("delete from Promo_Dtl where promo_id = '" & Promo_ID & "' and Branch_ID = '" & branch & "'")
            getSqldbPromo("update Other_Detail set sbu = '',dept = '',brand = '',total_artikel = 0 where doc_no = '" & DocNo & "' and Branch_ID = '" & branch & "'")
        End If

        sbu = ""
        dept = ""
        brand = ""
        openFileDialog1.DefaultExt = "xlsx"
        openFileDialog1.FileName = "PromoDetail"
        openFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        openFileDialog1.Filter = "Excel 97-2003 Template (*.xls)|*.xls|Excel Workbook (*.xlsx*)|*.xlsx*"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                myStream = openFileDialog1.OpenFile()
                If (myStream IsNot Nothing) Then
                    Dim xlApp As Excel.Application
                    Dim xlWorkBook As Excel.Workbook
                    Dim xlWorkSheet As Excel.Worksheet
                    Dim range As Excel.Range
                    Dim rCnt As Integer
                    Dim cCnt As Integer
                    Dim Obj As Object
                    xlApp = New Excel.ApplicationClass
                    xlWorkBook = xlApp.Workbooks.Open(openFileDialog1.FileName)
                    xlWorkSheet = xlWorkBook.Worksheets("sheet1")
                    range = xlWorkSheet.UsedRange
                    'display the cells value B2
                    Dim str As String = ""
                    Dim articleImp As String = ""

                    For rCnt = 4 To range.Rows.Count
                        str = "Insert Into Promo_Dtl Values ('" & branch & "','" & Promo_ID & "',"
                        For cCnt = 0 To range.Columns.Count - 1
                            Obj = CType(range.Cells(rCnt, cCnt + 1), Excel.Range)

                            Select Case cCnt
                                Case 0
                                    If sbu = "" Then
                                        sbu = Replace(Obj.value.ToString.Trim, "'", "''")
                                    End If
                                    If sbu <> Replace(Obj.value.ToString.Trim, "'", "''") Then
                                        sbu = "Specific SBU"
                                    End If
                                Case 1
                                    If dept = "" Then
                                        dept = Replace(Obj.value.ToString.Trim, "'", "''")
                                    End If
                                    If dept <> Replace(Obj.value.ToString.Trim, "'", "''") Then
                                        dept = "Specific Dept"
                                    End If
                                Case 2
                                    If brand = "" Then
                                        brand = Replace(Obj.value.ToString.Trim, "'", "''")
                                    End If
                                    If brand <> Replace(Obj.value.ToString.Trim, "'", "''") Then
                                        brand = "Specific Brand"
                                    End If
                                Case 3
                                    'str &= "'" & Replace(Obj.value.ToString.Trim, "'", "''") & "'"
                                    'If brand = "" Then
                                    '    brand = Replace(Obj.value.ToString.Trim, "'", "''")
                                    'End If
                                    'If brand <> Replace(Obj.value.ToString.Trim, "'", "''") Then
                                    '    brand = "Specific SBU"
                                    'End If
                                Case Else
                                    str &= ",'" & Replace(Obj.value.ToString.Trim, "'", "''") & "'"
                            End Select
                        Next
                        str = Replace(str, "Values (,", "Values (")
                        str &= ")"
                        getSqldbPromo(str)
                        Obj = CType(range.Cells(rCnt, 1), Excel.Range)
                        TotArt += 1
                    Next
                    getSqldbPromo("update Promo_hdr set statusD = 1,UpdDt = GetDate() where promo_id = '" & Promo_ID & "' and Branch_ID = '" & branch & "'")
                    getSqldbPromo("update Other_Detail set sbu = '" & sbu & "',dept = '" & dept & "',brand = '" & brand & "',total_artikel = '" & TotArt & "' where doc_no = '" & DocNo & "'  and Branch_ID = '" & branch & "'")
                    xlWorkBook.Close()
                    xlApp.Quit()

                    releaseObject(xlApp)
                    releaseObject(xlWorkBook)
                    releaseObject(xlWorkSheet)
                    MsgBox("Successfull !!!")
                    Ulang()
                End If
            Catch Ex As Exception
                MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open.
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try
        End If
    End Sub

    Sub UploadDetailNotepad()
        Dim dsDetail As DataSet
        If Promo_ID = "" Then
            MsgBox("Please Choose Promo First !!!")
            Exit Sub
        End If
        dsDetail = getSqldbPromo("Select * from promo_dtl where promo_id = '" & Promo_ID & "' and Branch_ID = '" & branch & "'")
        If dsDetail.Tables(0).Rows.Count > 0 Then
            If MsgBox("The data already exists !!!, delete the old data ??", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.No Then
                Exit Sub
            End If
            getSqldbPromo("delete from Promo_Dtl where promo_id = '" & Promo_ID & "' and Branch_ID = '" & branch & "'")
            getSqldbPromo("update Other_Detail set sbu = '',dept = '',brand = '',total_artikel = 0 where doc_no = '" & DocNo & "'  and Branch_ID = '" & branch & "'")
        End If
        Dim ofd As OpenFileDialog = New OpenFileDialog
        ofd.DefaultExt = "txt"
        ofd.FileName = "PromoDetail"
        ofd.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        ofd.Filter = "Text Files|*.txt"
        ofd.Title = "Select file"
        If ofd.ShowDialog() <> DialogResult.Cancel Then
            'MsgBox(ofd.FileName)
            Dim sbu, dept, brand As String
            Dim TotArt As Integer = 0
            sbu = ""
            dept = ""
            brand = ""
            Dim lines() As String = File.ReadAllLines(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Promo.txt")
            Try
                For i As Integer = 0 To lines.Length - 1
                    Dim parts() As String = lines(i).Split("	"c)
                    If sbu = "" Then
                        sbu = parts(0).Trim
                        dept = parts(1).Trim
                        brand = parts(2).Trim
                    End If
                    If sbu <> parts(0).Trim Then
                        sbu = "Specific SBU"
                    End If
                    If dept <> parts(1).Trim Then
                        dept = "Specific Dept"
                    End If
                    If brand <> parts(2).Trim Then
                        brand = "Specific Brand"
                    End If
                    TotArt += 1
                    getSqldbPromo("Insert Into Promo_Dtl values ('" & branch & "','" & Promo_ID & "','" & parts(3) & "','" & Replace(parts(4), "'", "''") & "')")
                Next
                getSqldbPromo("update Promo_hdr set statusD = 1,UpdDt = GetDate() where promo_id = '" & Promo_ID & "' and Branch_ID = '" & branch & "'")
                getSqldbPromo("update Other_Detail set sbu = '" & sbu & "',dept = '" & dept & "',brand = '" & brand & "',total_artikel = '" & TotArt & "' where doc_no = '" & DocNo & "'  and Branch_ID = '" & branch & "'")
                MsgBox("Successfull !!!")
                Ulang()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub

    Sub UploadOtherNotepad()
        Dim dsDetail As DataSet
        Dim prid As String = ""
        If PromoTypex = "" Then
            MsgBox("Please Click List Promo First !!!")
            Exit Sub
        End If
        For i As Integer = 100 To 999

            If PromoTypex = "35" Then
                prid = "666"
            Else
                prid = i
            End If
            DsPromo = getSqldbPromo("Select * from Promo_Dtl where Promo_id = '" & prid & "'")
            If DsPromo.Tables(0).Rows.Count = 0 Then
                dsDetail = getSqldbPromo("Select * from promo_dtl where promo_id = '" & prid & "' and Branch_ID = '" & branch & "'")
                If dsDetail.Tables(0).Rows.Count > 0 Then
                    If MsgBox("The data already exists !!!, delete the old data ??", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.No Then
                        Exit Sub
                    End If
                    getSqldbPromo("delete from Promo_Dtl where promo_id = '" & prid & "' and Branch_ID = '" & branch & "'")
                    getSqldbPromo("update Other_Detail set total_inc = 0 where doc_no = '" & DocNo & "'  and Branch_ID = '" & branch & "'")
                End If
                Dim ofd As OpenFileDialog = New OpenFileDialog
                ofd.DefaultExt = "txt"
                ofd.FileName = "Promo"
                ofd.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                ofd.Filter = "Text Files|*.txt"
                ofd.Title = "Select file"

                If ofd.ShowDialog() <> DialogResult.Cancel Then
                    'MsgBox(ofd.FileName)
                    Dim TotArt As Integer = 0
                    Dim lines() As String = File.ReadAllLines(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Promo.txt")
                    Try
                        For ii As Integer = 0 To lines.Length - 1
                            Dim parts() As String = lines(ii).Split("	"c)
                            TotArt += 1


                            getSqldbPromo("Insert Into Promo_Dtl values ('" & branch & "','" & prid & "','" & parts(3) & "','" & parts(4) & "')")


                        Next
                        getSqldbPromo("update Promo_hdr set statusO = 1,txt3 = '" & prid & "',UpdDt = GetDate() where promo_id = '" & Promo_ID & "' and Branch_ID = '" & branch & "'")
                        getSqldbPromo("update Other_Detail set total_inc = '" & TotArt & "' where doc_no = '" & DocNo & "'  and Branch_ID = '" & branch & "'")
                        MsgBox("Successfull !!!")
                        Ulang()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try

                End If
                Exit For
            Else
                If PromoTypex = "35" Then
                    If MsgBox("The data already exists !!!, delete the old data ??", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.No Then
                        Exit Sub
                    End If
                    getSqldbPromo("delete from Promo_Dtl where promo_id = '" & prid & "' and Branch_ID = '" & branch & "'")
                    getSqldbPromo("update Other_Detail set total_inc = 0 where doc_no = '" & DocNo & "'  and Branch_ID = '" & branch & "'")
                    Exit Sub
                End If
            End If
        Next
    End Sub

    Sub UploadOtherExcel()
        Dim dsDetail As DataSet
        Dim myStream As Stream = Nothing
        Dim prid As String = ""
        Dim TotArt As Integer = 0
        Dim openFileDialog1 As New OpenFileDialog()
        If PromoTypex = "" Then
            MsgBox("Please Click List Promo First !!!")
            Exit Sub
        End If
        For i As Integer = 100 To 999

            If PromoTypex = "35" Then
                prid = "666"
            Else
                prid = i
            End If
            DsPromo = getSqldbPromo("Select * from Promo_Dtl where Promo_id = '" & prid & "'")
            If DsPromo.Tables(0).Rows.Count = 0 Then
                dsDetail = getSqldbPromo("Select * from promo_dtl where promo_id = '" & prid & "' and Branch_ID = '" & branch & "'")
                If dsDetail.Tables(0).Rows.Count > 0 Then
                    If MsgBox("The data already exists !!!, delete the old data ??", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.No Then
                        Exit Sub
                    End If
                    getSqldbPromo("delete from Promo_Dtl where promo_id = '" & prid & "' and Branch_ID = '" & branch & "'")
                    getSqldbPromo("update Other_Detail set total_inc = 0 where doc_no = '" & DocNo & "' and Branch_ID = '" & branch & "' ")
                End If
1:
                openFileDialog1.DefaultExt = "xlsx"
                openFileDialog1.FileName = "Promo"
                openFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                openFileDialog1.Filter = "Excel 97-2003 Template (*.xls)|*.xls|Excel Workbook (*.xlsx*)|*.xlsx*"
                openFileDialog1.FilterIndex = 2
                openFileDialog1.RestoreDirectory = True

                If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    Try
                        myStream = openFileDialog1.OpenFile()
                        If (myStream IsNot Nothing) Then
                            Dim xlApp As Excel.Application
                            Dim xlWorkBook As Excel.Workbook
                            Dim xlWorkSheet As Excel.Worksheet
                            Dim range As Excel.Range
                            Dim rCnt As Integer
                            Dim cCnt As Integer
                            Dim Obj As Object
                            xlApp = New Excel.ApplicationClass
                            xlWorkBook = xlApp.Workbooks.Open(openFileDialog1.FileName)
                            xlWorkSheet = xlWorkBook.Worksheets("sheet1")
                            range = xlWorkSheet.UsedRange
                            'display the cells value B2
                            Dim str As String = ""
                            Dim articleImp As String = ""

                            For rCnt = 4 To range.Rows.Count
                                str = "Insert Into Promo_Dtl Values ('" & branch & "','" & prid & "',"
                                For cCnt = 0 To range.Columns.Count - 1
                                    Obj = CType(range.Cells(rCnt, cCnt + 1), Excel.Range)

                                    Select Case cCnt
                                        Case 0

                                        Case 1

                                        Case 2

                                        Case 3
                                            str &= "'" & Replace(Obj.value.ToString.Trim, "'", "''") & "'"
                                            If brand = "" Then
                                                brand = Replace(Obj.value.ToString.Trim, "'", "''")
                                            End If
                                            If brand <> Replace(Obj.value.ToString.Trim, "'", "''") Then
                                                brand = "Specific SBU"
                                            End If
                                        Case Else
                                            str &= ",'" & Replace(Obj.value.ToString.Trim, "'", "''") & "'"
                                    End Select

                                Next
                                str = Replace(str, "Values (,", "Values (")
                                str &= ")"
                                getSqldbPromo(str)
                                Obj = CType(range.Cells(rCnt, 1), Excel.Range)
                                TotArt += 1
                            Next
                            If PromoTypex > 30 Then
                                getSqldbPromo("update Promo_hdr set statusO = 1,txt3 = '" & prid & "',UpdDt = GetDate() where promo_id = '" & Promo_ID & "' and Branch_ID = '" & branch & "'")
                            Else
                                getSqldbPromo("update Promo_hdr set statusO = 1,txt1 = '" & prid & "',UpdDt = GetDate() where promo_id = '" & Promo_ID & "' and Branch_ID = '" & branch & "'")
                            End If

                            getSqldbPromo("update Other_Detail set total_inc = '" & TotArt & "' where doc_no = '" & DocNo & "'  and Branch_ID = '" & branch & "'")
                            xlWorkBook.Close()
                            xlApp.Quit()

                            releaseObject(xlApp)
                            releaseObject(xlWorkBook)
                            releaseObject(xlWorkSheet)
                            MsgBox("Successfull !!!")
                            Ulang()
                        End If
                    Catch Ex As Exception
                        MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
                    Finally
                        ' Check this again, since we need to make sure we didn't throw an exception on open.
                        If (myStream IsNot Nothing) Then
                            myStream.Close()
                        End If
                    End Try
                End If

                Exit For
            Else
                If PromoTypex = "35" Then
                    If MsgBox("The data already exists !!!, delete the old data ??", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.No Then
                        Exit Sub
                    End If
                    getSqldbPromo("delete from Promo_Dtl where promo_id = '" & prid & "' and Branch_ID = '" & branch & "'")
                    getSqldbPromo("update Other_Detail set total_inc = 0 where doc_no = '" & DocNo & "'  and Branch_ID = '" & branch & "'")
                    GoTo 1
                End If
            End If
        Next
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Try
            Dim dsDetail As DataSet
            For Each rw As DataGridViewRow In dgvPromo.SelectedRows
                ProgressBar1.Value = 0


                TotArt = 0
                Prg = 0
                Ecount = 0
                dsDetail = getSqldbPromo("Select * from promo_dtl where promo_id = '" & rw.Cells("promo_id").Value.ToString & "' and Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "'")
                If dsDetail.Tables(0).Rows.Count > 0 Then
                    If MsgBox("The data " & rw.Cells("promo_id").Value.ToString & " in " & rw.Cells("Branch_ID").Value.ToString & " already exists !!!, delete the old data ??", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.No Then
                        Continue For
                    End If
                    getSqldbPromo("delete from Promo_Dtl where promo_id = '" & rw.Cells("promo_id").Value.ToString & "' and Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "'")
                    getSqldbPromo("update Other_Detail set sbu = '',dept = '',brand = '',total_artikel = 0 where doc_no = '" & rw.Cells("doc_no").Value.ToString & "' and Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "'")
                End If

                sbu = ""
                dept = ""
                brand = ""
                If (myStream IsNot Nothing) Then
                    Dim xlApp As Excel.Application
                    Dim xlWorkBook As Excel.Workbook
                    Dim xlWorkSheet As Excel.Worksheet
                    Dim range As Excel.Range
                    Dim rCnt As Integer
                    Dim cCnt As Integer
                    Dim Obj As Object
                    xlApp = New Excel.ApplicationClass
                    xlWorkBook = xlApp.Workbooks.Open(openFileDialog1.FileName)
                    xlWorkSheet = xlWorkBook.Worksheets("sheet1")
                    range = xlWorkSheet.UsedRange
                    'display the cells value B2
                    Dim str As String = ""
                    Dim articleImp As String = ""
                    'Ecount = range.Rows.Count - 3
                    Ecount = 4
                    While (xlWorkSheet.Cells(Ecount, 1).Value IsNot Nothing)
                        Ecount = Ecount + 1
                    End While
                    Ecount = Ecount - 4
                    For rCnt = 4 To Ecount + 3
                        Prg += 100 / Ecount
                        'If rCnt = 34 Then
                        '    MsgBox("")
                        'End If
                        str = "Insert Into Promo_Dtl Values ('" & rw.Cells("Branch_ID").Value.ToString & "','" & rw.Cells("promo_id").Value.ToString & "',"
                        For cCnt = 0 To range.Columns.Count - 1
                            Obj = CType(range.Cells(rCnt, cCnt + 1), Excel.Range)
                            Select Case cCnt
                                Case 0
                                    If sbu = "" Then
                                        sbu = Replace(Replace(Obj.value.ToString.Trim, "'", "''"), ",", "")
                                    End If
                                    If sbu <> Replace(Replace(Obj.value.ToString.Trim, "'", "''"), ",", "") Then
                                        sbu = "Specific SBU"
                                    End If
                                Case 1
                                    If dept = "" Then
                                        dept = Replace(Replace(Obj.value.ToString.Trim, "'", "''"), ",", "")
                                    End If
                                    If dept <> Replace(Replace(Obj.value.ToString.Trim, "'", "''"), ",", "") Then
                                        dept = "Specific Dept"
                                    End If
                                Case 2
                                    If brand = "" Then
                                        brand = Replace(Replace(Obj.value.ToString.Trim, "'", "''"), ",", "")
                                    End If
                                    If brand <> Replace(Replace(Obj.value.ToString.Trim, "'", "''"), ",", "") Then
                                        brand = "Specific Brand"
                                    End If
                                Case 3
                                    str &= "'" & Replace(Obj.value.ToString.Trim, "'", "''") & "'"
                                    'If brand = "" Then
                                    '    brand = Replace(Replace(Obj.value.ToString.Trim, "'", "''"), ",", "")
                                    'End If
                                    'If brand <> Replace(Replace(Obj.value.ToString.Trim, "'", "''"), ",", "") Then
                                    '    brand = "Specific SBU"
                                    'End If
                                Case Else
                                    str &= ",'" & Replace(Replace(Obj.value.ToString.Trim, "'", "''"), ",", "") & "'"
                            End Select

                        Next
                        str &= ")"
                        Try
                            getSqldbPromo(str)
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try

                        Obj = CType(range.Cells(rCnt, 1), Excel.Range)
                        TotArt += 1
                        Label10.Text = "Upload Detail : " & rw.Cells("Branch_ID").Value.ToString & " Total : " & CDec(TotArt).ToString("N0")
                        BackgroundWorker1.ReportProgress(Int(Prg))
                    Next
2:
                    getSqldbPromo("update Promo_hdr set statusD = 1,UpdDt = GetDate(),AllItemFlag = 0 where promo_id = '" & rw.Cells("promo_id").Value.ToString & "' and Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "'")
                    getSqldbPromo("update Other_Detail set sbu = '" & sbu & "',dept = '" & dept & "',brand = '" & brand & "',total_artikel = '" & TotArt & "' where doc_no = '" & rw.Cells("doc_no").Value.ToString & "'  and Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "'")
                    xlWorkBook.Close()
                    xlApp.Quit()

                    releaseObject(xlApp)
                    releaseObject(xlWorkBook)
                    releaseObject(xlWorkSheet)

                End If
            Next



        Catch Ex As Exception
            MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
            Ulang()
            ProgressBar1.Visible = False
        Finally
            ' Check this again, since we need to make sure we didn't throw an exception on open.
            If (myStream IsNot Nothing) Then
                myStream.Close()
            End If
        End Try
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        MsgBox("Successfully Uploaded " & CDec(TotArt).ToString("N0") & " Articles !!!")
        Ulang()
        Label10.Visible = False
        MenuStrip1.Enabled = True
        dgvPromo.Enabled = True
        ProgressBar1.Visible = False
    End Sub

    Private Sub BackgroundWorker2_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork

        Try
            ProgressBar1.Value = 0
            If (myStream IsNot Nothing) Then
                Dim xlApp As Excel.Application
                Dim xlWorkBook As Excel.Workbook
                Dim xlWorkSheet As Excel.Worksheet
                Dim range As Excel.Range
                Dim rCnt As Integer
                Dim cCnt As Integer
                Dim Obj As Object
                xlApp = New Excel.ApplicationClass
                xlWorkBook = xlApp.Workbooks.Open(openFileDialog1.FileName)
                xlWorkSheet = xlWorkBook.Worksheets("sheet1")
                range = xlWorkSheet.UsedRange
                'display the cells value B2
                Dim str As String = ""
                Dim articleImp As String = ""
                Ecount = 4
                While (xlWorkSheet.Cells(Ecount, 1).Value IsNot Nothing)
                    Ecount = Ecount + 1
                End While
                Ecount = Ecount - 4
                'Ecount = range.Rows.Count - 3
                For rCnt = 4 To Ecount + 3
                    Prg += 100 / Ecount
                    str = "Insert Into Promo_Dtl Values ('" & branch & "','" & prid & "',"
                    For cCnt = 0 To range.Columns.Count - 1
                        Obj = CType(range.Cells(rCnt, cCnt + 1), Excel.Range)

                        Select Case cCnt
                            Case 0

                            Case 1

                            Case 2

                            Case 3
                                str &= "'" & Replace(Replace(Obj.value.ToString.Trim, "'", "''"), ",", "") & "'"
                                If brand = "" Then
                                    brand = Replace(Replace(Obj.value.ToString.Trim, "'", "''"), ",", "")
                                End If
                                If brand <> Replace(Replace(Obj.value.ToString.Trim, "'", "''"), ",", "") Then
                                    brand = "Specific SBU"
                                End If
                            Case Else
                                str &= ",'" & Replace(Replace(Obj.value.ToString.Trim, "'", "''"), ",", "") & "'"
                        End Select

                    Next
                    str &= ")"
                    getSqldbPromo(str)
                    Obj = CType(range.Cells(rCnt, 1), Excel.Range)
                    TotArt += 1
                    BackgroundWorker2.ReportProgress(Int(Prg))
                Next
                If PromoTypex > 30 Then
                    getSqldbPromo("update Promo_hdr set statusO = 1,txt3 = '" & prid & "',UpdDt = GetDate() where promo_id = '" & Promo_ID & "' and Branch_ID = '" & branch & "'")
                ElseIf PromoTypex = 23 Then
                    getSqldbPromo("update Promo_hdr set statusO = 1,txt2 = '" & prid & "',UpdDt = GetDate() where promo_id = '" & Promo_ID & "' and Branch_ID = '" & branch & "'")
                Else
                    getSqldbPromo("update Promo_hdr set statusO = 1,txt1 = '" & prid & "',UpdDt = GetDate() where promo_id = '" & Promo_ID & "' and Branch_ID = '" & branch & "'")
                End If

                getSqldbPromo("update Other_Detail set total_inc = '" & TotArt & "' where doc_no = '" & DocNo & "'  and Branch_ID = '" & branch & "'")
                xlWorkBook.Close()
                xlApp.Quit()

                releaseObject(xlApp)
                releaseObject(xlWorkBook)
                releaseObject(xlWorkSheet)

            End If
        Catch Ex As Exception
            MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
        Finally
            ' Check this again, since we need to make sure we didn't throw an exception on open.
            If (myStream IsNot Nothing) Then
                myStream.Close()
            End If
        End Try

    End Sub

    Private Sub BackgroundWorker2_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker2.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker2_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        MsgBox("Successfull !!!")
        Ulang()
        MenuStrip1.Enabled = True
        ProgressBar1.Visible = False
    End Sub

    Private Sub BackgroundWorker3_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker3.DoWork

        Try
            For Each rw As DataGridViewRow In dgvPromo.SelectedRows
                DsCekTransfer = getSqldbPromo("select * from Promo_dtl where promo_id = '" & rw.Cells("promo_id").Value.ToString & "'")
                If DsCekTransfer.Tables(0).Rows.Count = 0 Then
                    MsgBox("Please Upload Detail First !!!")
                    Exit Sub
                End If
                Select Case CInt(CmbTipe.SelectedValue)
                    Case 19
                        DsCekTransfer.Clear()
                        DsCekTransfer = getSqldbPromo("select * from Promo_dtl where promo_id = '" & rw.Cells("txt1").Value.ToString & "'")
                        If DsCekTransfer.Tables(0).Rows.Count = 0 Then
                            MsgBox("Please Upload Include First !!!")
                            Exit Sub
                        End If
                    Case 23
                        DsCekTransfer.Clear()
                        DsCekTransfer = getSqldbPromo("select * from Promo_dtl where promo_id = '" & rw.Cells("txt2").Value.ToString & "'")
                        If DsCekTransfer.Tables(0).Rows.Count = 0 Then
                            MsgBox("Please Upload Include First !!!")
                            Exit Sub
                        End If
                End Select
                'If CDate(dgvPromo.Item("start_date", dgvPromo.CurrentRow.Index).Value).Date.AddDays(AtlsDay) < Now.Date Then
                '    MsgBox("Promo date of at least " & AtlsDay * -1 & " days after today !!! (H" & AtlsDay & ")")
                '    Exit Sub
                'End If
                Prg = 0
                Dim dsProcess As New DataSet
                Dim PromoInclude As String = ""
                ProgressBar1.Value = 0
                Select Case rw.Cells("Branch_ID").Value.ToString
                    Case "S001"

                        BackgroundWorker3.ReportProgress(0)
                        Label10.Text = "Process Header : " & Promo_ID
                        Try
                            getSqldbPromo("insert into [192.168.5.3].POS_SERVER.dbo.Promo_Hdr SELECT [promo_id],[promo_name],[start_date],[end_date]," & _
                                                                                 "[min_purchase],[disc],[tipe],[voucher],[lipat],[ismsg],[isprn],[islimit],[qtylimit],[qtyout],'1',[min_member]," & _
                                                                                 "[txt1],[txt2],[txt3],[txt4],0 FROM Promo_Hdr where promo_id = '" & rw.Cells("promo_id").Value.ToString & "' And Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "'")
                        Catch ex As Exception
                            MsgBox("Error Connections 'MKG'")
                            GoTo 1
                        End Try

                        BackgroundWorker3.ReportProgress(100)
                        Try
                            dsProcess = getSqldbPromo("SELECT [promo_id],[PLU],[description] FROM  Promo_Dtl where promo_id = '" & rw.Cells("promo_id").Value.ToString & "' And Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "'")
                            Label10.Text = "Process Detail : "

                            If dsProcess.Tables(0).Rows.Count > 0 Then
                                BackgroundWorker3.ReportProgress(0)
                                For Each ro As DataRow In dsProcess.Tables(0).Rows
                                    Prg += 100 / dsProcess.Tables(0).Rows.Count
                                    getSqldbPromo("insert into [192.168.5.3].POS_SERVER.dbo.Promo_Dtl Values ('" & ro("promo_id") & "','" & ro("PLU") & "','" & Replace(ro("description"), "'", "''") & "') ")
                                    Label10.Text = "Process Detail : " & rw.Cells("Branch_ID").Value.ToString & " " & ro("PLU") & " " & ro("description")
                                    If Int(Prg) < 100 Then
                                        BackgroundWorker3.ReportProgress(Int(Prg))
                                    End If
                                Next
                            End If
                        Catch ex As Exception
                            MsgBox("Error Transfer Promo_Dtl 'MKG'")
                            getSqldbPromo("delete  [192.168.5.3].POS_SERVER.dbo.Promo_Hdr where promo_id = '" & rw.Cells("promo_id").Value.ToString & "'")
                            getSqldbPromo("delete  [192.168.5.3].POS_SERVER.dbo.Promo_Dtl where promo_id = '" & rw.Cells("promo_id").Value.ToString & "'")
                            GoTo 1
                        End Try
                        Try
                            dsProcess.Clear()
                            If PromoTypex = "23" Then
                                dsProcess = getSqldbPromo("select b.* from PROMO_hdr a inner join promo_dtl b on a.txt2 = b.promo_id where b.Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "' and a.promo_id = '" & rw.Cells("promo_id").Value.ToString & "'")
                            ElseIf PromoTypex = "75" Then
                                Dim parts2() As String = txt4ID.ToString.Trim().Split(","c)
                                Dim txt4str As String = ""
                                For x As Integer = 0 To parts2.Length - 1
                                    If parts2(x) <> "" Then
                                        txt4str &= "'" & parts2(x) & "',"
                                    End If
                                Next
                                txt4str = Mid(txt4str, 1, txt4str.Length - 1)
                                dsProcess = getSqldbPromo("select * from promo_dtl where Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "' and promo_id in (" & txt4str & ")")
                            Else
                                dsProcess = getSqldbPromo("select b.* from PROMO_hdr a inner join promo_dtl b on a.txt1 = b.promo_id where b.Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "' and a.promo_id = '" & rw.Cells("promo_id").Value.ToString & "'")
                            End If

                            Label10.Text = "Process Include : "

                            If dsProcess.Tables(0).Rows.Count > 0 Then
                                BackgroundWorker3.ReportProgress(0)
                                For Each ro As DataRow In dsProcess.Tables(0).Rows
                                    Prg += 100 / dsProcess.Tables(0).Rows.Count
                                    PromoInclude = ro("promo_id")
                                    getSqldbPromo("insert into [192.168.5.3].POS_SERVER.dbo.Promo_Dtl Values ('" & ro("promo_id") & "','" & ro("PLU") & "','" & Replace(ro("description"), "'", "''") & "') ")
                                    Label10.Text = "Process Include : " & rw.Cells("Branch_ID").Value.ToString & " " & ro("PLU") & " " & ro("description")
                                    If Int(Prg) < 100 Then
                                        BackgroundWorker3.ReportProgress(Int(Prg))
                                    End If
                                Next
                            End If
                        Catch ex As Exception
                            MsgBox("Error Transfer Include 'MKG'")
                            getSqldbPromo("delete  [192.168.5.3].POS_SERVER.dbo.Promo_Hdr where promo_id = '" & rw.Cells("promo_id").Value.ToString & "'")
                            getSqldbPromo("delete  [192.168.5.3].POS_SERVER.dbo.Promo_dtl where promo_id = '" & rw.Cells("promo_id").Value.ToString & "'")
                            getSqldbPromo("delete  [192.168.5.3].POS_SERVER.dbo.Promo_dtl where promo_id = '" & PromoInclude & "'")
                            GoTo 1
                        End Try

                        'getSqldbPromo("insert into [192.168.5.3].POS_SERVER.dbo.Promo_Dtl SELECT [promo_id],[PLU],[description] FROM  Promo_Dtl where promo_id = '" & Promo_ID & "' And Branch_ID = '" & branch & "'")
                        'BackgroundWorker3.ReportProgress(20)
                        Label10.Text = "Process Flag All Item : "
                        BackgroundWorker3.ReportProgress(10)
                        getSqldbPromo("insert into [192.168.5.3].POS_SERVER.dbo.FlagAllItem_Promo SELECT [promo_id],[start_date],[end_date],[AllItemFlag] FROM  Promo_Hdr where doc_no = '" & rw.Cells("doc_no").Value.ToString & "' And Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "'")
                        Label10.Text = "Process M_TransGwp : "
                        BackgroundWorker3.ReportProgress(20)
                        getSqldbPromo("insert into [192.168.5.3].POS_SERVER.dbo.M_TransGwp SELECT [promo_id],[promo_name],[end_date] FROM  Promo_Hdr where doc_no = '" & rw.Cells("doc_no").Value.ToString & "' And Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "' and tipe > 30")
                        BackgroundWorker3.ReportProgress(30)


                    Case "S002"
                        BackgroundWorker3.ReportProgress(0)
                        Label10.Text = "Process Header : " & Promo_ID
                        Try
                            getSqldbPromo("insert into [192.168.2.220].POS_SERVER.dbo.Promo_Hdr SELECT [promo_id],[promo_name],[start_date],[end_date]," & _
                                                        "[min_purchase],[disc],[tipe],[voucher],[lipat],[ismsg],[isprn],[islimit],[qtylimit],[qtyout],'1',[min_member]," & _
                                                        "[txt1],[txt2],[txt3],[txt4],0 FROM  Promo_Hdr where promo_id = '" & rw.Cells("promo_id").Value.ToString & "' And Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "'")
                        Catch ex As Exception
                            MsgBox("Error Connections 'SMS'")
                            GoTo 1
                        End Try

                        BackgroundWorker3.ReportProgress(100)
                        Try
                            dsProcess = getSqldbPromo("SELECT [promo_id],[PLU],[description] FROM  Promo_Dtl where promo_id = '" & rw.Cells("promo_id").Value.ToString & "' And Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "'")
                            Label10.Text = "Process Detail : "

                            If dsProcess.Tables(0).Rows.Count > 0 Then
                                BackgroundWorker3.ReportProgress(0)
                                For Each ro As DataRow In dsProcess.Tables(0).Rows
                                    Prg += 100 / dsProcess.Tables(0).Rows.Count
                                    getSqldbPromo("insert into [192.168.2.220].POS_SERVER.dbo.Promo_Dtl Values ('" & ro("promo_id") & "','" & ro("PLU") & "','" & Replace(ro("description"), "'", "''") & "') ")
                                    Label10.Text = "Process Detail : " & rw.Cells("Branch_ID").Value.ToString & " " & ro("PLU") & " " & ro("description")
                                    If Int(Prg) < 100 Then
                                        BackgroundWorker3.ReportProgress(Int(Prg))
                                    End If
                                Next
                            End If
                        Catch ex As Exception
                            MsgBox("Error Transfer Promo_Dtl 'SMS'")
                            getSqldbPromo("delete [192.168.2.220].POS_SERVER.dbo.Promo_Hdr where promo_id = '" & rw.Cells("promo_id").Value.ToString & "'")
                            GoTo 1
                        End Try
                        Prg = 0
                        Try
                            dsProcess.Clear()
                            If PromoTypex = "23" Then
                                dsProcess = getSqldbPromo("select b.* from PROMO_hdr a inner join promo_dtl b on a.txt2 = b.promo_id where b.Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "' and a.promo_id = '" & rw.Cells("promo_id").Value.ToString & "'")
                            ElseIf PromoTypex = "75" Then
                                Dim parts2() As String = txt4ID.ToString.Trim().Split(","c)
                                Dim txt4str As String = ""
                                For x As Integer = 0 To parts2.Length - 1
                                    If parts2(x) <> "" Then
                                        txt4str &= "'" & parts2(x) & "',"
                                    End If
                                Next
                                txt4str = Mid(txt4str, 1, txt4str.Length - 1)
                                dsProcess = getSqldbPromo("select * from promo_dtl where Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "' and promo_id in (" & txt4str & ")")
                            Else
                                dsProcess = getSqldbPromo("select b.* from PROMO_hdr a inner join promo_dtl b on a.txt1 = b.promo_id where b.Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "' and a.promo_id = '" & rw.Cells("promo_id").Value.ToString & "'")
                            End If

                            Label10.Text = "Process Include : "

                            If dsProcess.Tables(0).Rows.Count > 0 Then
                                BackgroundWorker3.ReportProgress(0)
                                For Each ro As DataRow In dsProcess.Tables(0).Rows
                                    Prg += 100 / dsProcess.Tables(0).Rows.Count
                                    PromoInclude = ro("promo_id")
                                    getSqldbPromo("insert into [192.168.2.220].POS_SERVER.dbo.Promo_Dtl Values ('" & ro("promo_id") & "','" & ro("PLU") & "','" & Replace(ro("description"), "'", "''") & "') ")
                                    Label10.Text = "Process Include : " & rw.Cells("Branch_ID").Value.ToString & " " & ro("PLU") & " " & ro("description")
                                    If Int(Prg) < 100 Then
                                        BackgroundWorker3.ReportProgress(Int(Prg))
                                    End If
                                Next
                            End If
                        Catch ex As Exception
                            MsgBox("Error Transfer Include 'SMS'")
                            getSqldbPromo("delete  [192.168.2.220].POS_SERVER.dbo.Promo_Hdr where promo_id = '" & rw.Cells("promo_id").Value.ToString & "'")
                            getSqldbPromo("delete  [192.168.2.220].POS_SERVER.dbo.Promo_dtl where promo_id = '" & rw.Cells("promo_id").Value.ToString & "'")
                            getSqldbPromo("delete  [192.168.2.220].POS_SERVER.dbo.Promo_dtl where promo_id = '" & PromoInclude & "'")
                            GoTo 1
                        End Try
                        'BackgroundWorker3.ReportProgress(10)
                        'getSqldbPromo("insert into [192.168.2.220].POS_SERVER.dbo.Promo_Dtl SELECT [promo_id],[PLU],[description] FROM  Promo_Dtl where promo_id = '" & Promo_ID & "' And Branch_ID = '" & branch & "'")
                        Label10.Text = "Process Flag All Item : "
                        BackgroundWorker3.ReportProgress(20)
                        getSqldbPromo("insert into [192.168.2.220].POS_SERVER.dbo.FlagAllItem_Promo SELECT [promo_id],[start_date],[end_date],[AllItemFlag] FROM  Promo_Hdr where doc_no = '" & rw.Cells("doc_no").Value.ToString & "' And Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "'")
                        Label10.Text = "Process M_TransGwp : "
                        BackgroundWorker3.ReportProgress(30)
                        getSqldbPromo("insert into [192.168.2.220].POS_SERVER.dbo.M_TransGwp SELECT [promo_id],[promo_name],[end_date] FROM  Promo_Hdr where doc_no = '" & rw.Cells("doc_no").Value.ToString & "' And Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "'  and tipe > 30")
                        BackgroundWorker3.ReportProgress(40)


                    Case "S003"
                        BackgroundWorker3.ReportProgress(0)
                        Label10.Text = "Process Header : " & Promo_ID
                        Try
                            getSqldbPromo("insert into [192.168.3.11].POS_SERVER.dbo.Promo_Hdr  SELECT [promo_id],[promo_name],[start_date],[end_date]," & _
                                                            "[min_purchase],[disc],[tipe],[voucher],[lipat],[ismsg],[isprn],[islimit],[qtylimit],[qtyout],'1',[min_member]," & _
                                                            "[txt1],[txt2],[txt3],[txt4],0 FROM Promo_Hdr where promo_id = '" & rw.Cells("promo_id").Value.ToString & "' And Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "'")
                        Catch ex As Exception
                            MsgBox("Error Connections 'SMB'")
                            GoTo 1
                        End Try

                        BackgroundWorker3.ReportProgress(100)
                        Try
                            dsProcess = getSqldbPromo("SELECT [promo_id],[PLU],[description] FROM  Promo_Dtl where promo_id = '" & rw.Cells("promo_id").Value.ToString & "' And Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "'")
                            Label10.Text = "Process Detail : "

                            If dsProcess.Tables(0).Rows.Count > 0 Then
                                BackgroundWorker3.ReportProgress(0)
                                For Each ro As DataRow In dsProcess.Tables(0).Rows
                                    Prg += 100 / dsProcess.Tables(0).Rows.Count
                                    getSqldbPromo("insert into [192.168.3.11].POS_SERVER.dbo.Promo_Dtl Values ('" & ro("promo_id") & "','" & ro("PLU") & "','" & Replace(ro("description"), "'", "''") & "') ")
                                    Label10.Text = "Process Detail : " & rw.Cells("Branch_ID").Value.ToString & " " & ro("PLU") & " " & ro("description")
                                    If Int(Prg) < 100 Then
                                        BackgroundWorker3.ReportProgress(Int(Prg))
                                    End If
                                Next
                            End If
                        Catch ex As Exception
                            MsgBox("Error Transfer Promo_Dtl 'SMB'")
                            getSqldbPromo("delete [192.168.3.11].POS_SERVER.dbo.Promo_Hdr where promo_id = '" & rw.Cells("promo_id").Value.ToString & "'")
                            GoTo 1
                        End Try
                        Prg = 0
                        Try
                            dsProcess.Clear()
                            If PromoTypex = "23" Then
                                dsProcess = getSqldbPromo("select DISTINCT b.* from PROMO_hdr a inner join promo_dtl b on a.txt2 = b.promo_id where b.Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "' and a.promo_id = '" & rw.Cells("promo_id").Value.ToString & "'")
                            ElseIf PromoTypex = "75" Then
                                Dim parts2() As String = txt4ID.ToString.Trim().Split(","c)
                                Dim txt4str As String = ""
                                For x As Integer = 0 To parts2.Length - 1
                                    If parts2(x) <> "" Then
                                        txt4str &= "'" & parts2(x) & "',"
                                    End If
                                Next
                                txt4str = Mid(txt4str, 1, txt4str.Length - 1)
                                dsProcess = getSqldbPromo("select * from promo_dtl where Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "' and promo_id in (" & txt4str & ")")
                            Else
                                dsProcess = getSqldbPromo("select b.* from PROMO_hdr a inner join promo_dtl b on a.txt1 = b.promo_id where b.Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "' and a.promo_id = '" & rw.Cells("promo_id").Value.ToString & "'")
                            End If

                            Label10.Text = "Process Include : "

                            If dsProcess.Tables(0).Rows.Count > 0 Then
                                BackgroundWorker3.ReportProgress(0)
                                For Each ro As DataRow In dsProcess.Tables(0).Rows
                                    Prg += 100 / dsProcess.Tables(0).Rows.Count
                                    PromoInclude = ro("promo_id")
                                    getSqldbPromo("insert into [192.168.3.11].POS_SERVER.dbo.Promo_Dtl Values ('" & ro("promo_id") & "','" & ro("PLU") & "','" & Replace(ro("description"), "'", "''") & "') ")
                                    Label10.Text = "Process Include : " & rw.Cells("Branch_ID").Value.ToString & " " & ro("PLU") & " " & ro("description")
                                    If Int(Prg) < 100 Then
                                        BackgroundWorker3.ReportProgress(Int(Prg))
                                    End If
                                Next
                            End If
                        Catch ex As Exception
                            MsgBox("Error Transfer Include 'SMB'")
                            getSqldbPromo("delete  [192.168.3.11].POS_SERVER.dbo.Promo_Hdr where promo_id = '" & rw.Cells("promo_id").Value.ToString & "'")
                            getSqldbPromo("delete  [192.168.3.11].POS_SERVER.dbo.Promo_dtl where promo_id = '" & rw.Cells("promo_id").Value.ToString & "'")
                            getSqldbPromo("delete  [192.168.3.11].POS_SERVER.dbo.Promo_dtl where promo_id = '" & PromoInclude & "'")
                            GoTo 1
                        End Try

                        'BackgroundWorker3.ReportProgress(10)
                        'getSqldbPromo("insert into [192.168.3.11].POS_SERVER.dbo.Promo_Dtl SELECT [promo_id],[PLU],[description] FROM  Promo_Dtl where promo_id = '" & Promo_ID & "' And Branch_ID = '" & branch & "'")
                        Label10.Text = "Process Flag All Item : "
                        BackgroundWorker3.ReportProgress(20)
                        getSqldbPromo("insert into [192.168.3.11].POS_SERVER.dbo.FlagAllItem_Promo SELECT [promo_id],[start_date],[end_date],[AllItemFlag] FROM  Promo_Hdr where doc_no = '" & rw.Cells("doc_no").Value.ToString & "' And Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "'")
                        Label10.Text = "Process M_TransGwp : "
                        BackgroundWorker3.ReportProgress(30)
                        getSqldbPromo("insert into [192.168.3.11].POS_SERVER.dbo.M_TransGwp SELECT [promo_id],[promo_name],[end_date] FROM  Promo_Hdr where doc_no = '" & rw.Cells("doc_no").Value.ToString & "' And Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "'  and tipe > 30")
                        BackgroundWorker3.ReportProgress(40)


                    Case "S011"

                        BackgroundWorker3.ReportProgress(0)
                        Label10.Text = "Process Header : " & Promo_ID
                        Try
                            getSqldbPromo("insert into [10.81.234.6].POS_SERVER.dbo.Promo_Hdr  SELECT [promo_id],[promo_name],[start_date],[end_date]," & _
                                                                                      "[min_purchase],[disc],[tipe],[voucher],[lipat],[ismsg],[isprn],[islimit],[qtylimit],[qtyout],'1',[min_member]," & _
                                                                                      "[txt1],[txt2],[txt3],[txt4],0 FROM Promo_Hdr where promo_id = '" & rw.Cells("promo_id").Value.ToString & "' And Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "'")
                        Catch ex As Exception
                            MsgBox("Error Connections 'BALI'")
                            GoTo 1
                        End Try

                        BackgroundWorker3.ReportProgress(100)
                        Try
                            dsProcess = getSqldbPromo("SELECT [promo_id],[PLU],[description] FROM  Promo_Dtl where promo_id = '" & rw.Cells("promo_id").Value.ToString & "' And Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "'")
                            Label10.Text = "Process Detail : "

                            If dsProcess.Tables(0).Rows.Count > 0 Then
                                BackgroundWorker3.ReportProgress(0)
                                For Each ro As DataRow In dsProcess.Tables(0).Rows
                                    Prg += 100 / dsProcess.Tables(0).Rows.Count
                                    getSqldbPromo("insert into [10.81.234.6].POS_SERVER.dbo.Promo_Dtl Values ('" & ro("promo_id") & "','" & ro("PLU") & "','" & Replace(ro("description"), "'", "''") & "') ")
                                    Label10.Text = "Process Detail : " & rw.Cells("Branch_ID").Value.ToString & " " & ro("PLU") & " " & ro("description")
                                    If Int(Prg) < 100 Then
                                        BackgroundWorker3.ReportProgress(Int(Prg))
                                    End If
                                Next
                            End If
                        Catch ex As Exception
                            MsgBox("Error Transfer Promo_Dtl 'BALI'")
                            getSqldbPromo("delete [10.81.234.6].POS_SERVER.dbo.Promo_Hdr where promo_id = '" & rw.Cells("promo_id").Value.ToString & "'")
                            GoTo 1
                        End Try
                        Prg = 0
                        Try
                            dsProcess.Clear()
                            If PromoTypex = "23" Then
                                dsProcess = getSqldbPromo("select b.* from PROMO_hdr a inner join promo_dtl b on a.txt2 = b.promo_id where b.Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "' and a.promo_id = '" & rw.Cells("promo_id").Value.ToString & "'")
                            ElseIf PromoTypex = "75" Then
                                Dim parts2() As String = txt4ID.ToString.Trim().Split(","c)
                                Dim txt4str As String = ""
                                For x As Integer = 0 To parts2.Length - 1
                                    If parts2(x) <> "" Then
                                        txt4str &= "'" & parts2(x) & "',"
                                    End If
                                Next
                                txt4str = Mid(txt4str, 1, txt4str.Length - 1)
                                dsProcess = getSqldbPromo("select * from promo_dtl where Branch_ID = '" & branch & "' and promo_id in (" & txt4str & ")")
                            Else
                                dsProcess = getSqldbPromo("select b.* from PROMO_hdr a inner join promo_dtl b on a.txt1 = b.promo_id where b.Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "' and a.promo_id = '" & rw.Cells("promo_id").Value.ToString & "'")
                            End If

                            Label10.Text = "Process Include : "

                            If dsProcess.Tables(0).Rows.Count > 0 Then
                                BackgroundWorker3.ReportProgress(0)
                                For Each ro As DataRow In dsProcess.Tables(0).Rows
                                    Prg += 100 / dsProcess.Tables(0).Rows.Count
                                    PromoInclude = ro("promo_id")
                                    getSqldbPromo("insert into [10.81.234.6].POS_SERVER.dbo.Promo_Dtl Values ('" & ro("promo_id") & "','" & ro("PLU") & "','" & Replace(ro("description"), "'", "''") & "') ")
                                    Label10.Text = "Process Include : " & rw.Cells("Branch_ID").Value.ToString & " " & ro("PLU") & " " & ro("description")
                                    If Int(Prg) < 100 Then
                                        BackgroundWorker3.ReportProgress(Int(Prg))
                                    End If
                                Next
                            End If
                        Catch ex As Exception
                            MsgBox("Error Transfer Include 'BALI'")
                            getSqldbPromo("delete  [10.81.234.6].POS_SERVER.dbo.Promo_Hdr where promo_id = '" & rw.Cells("promo_id").Value.ToString & "'")
                            getSqldbPromo("delete  [10.81.234.6].POS_SERVER.dbo.Promo_dtl where promo_id = '" & rw.Cells("promo_id").Value.ToString & "'")
                            getSqldbPromo("delete  [10.81.234.6].POS_SERVER.dbo.Promo_dtl where promo_id = '" & PromoInclude & "'")
                            GoTo 1
                        End Try

                        'BackgroundWorker3.ReportProgress(10)
                        'getSqldbPromo("insert into [192.168.1.231].POS_SERVER.dbo.Promo_Dtl SELECT [promo_id],[PLU],[description] FROM  Promo_Dtl where promo_id = '" & Promo_ID & "' And Branch_ID = '" & branch & "'")
                        Label10.Text = "Process Flag All Item : "
                        BackgroundWorker3.ReportProgress(20)
                        getSqldbPromo("insert into [10.81.234.6].POS_SERVER.dbo.FlagAllItem_Promo SELECT [promo_id],[start_date],[end_date],[AllItemFlag] FROM  Promo_Hdr where doc_no = '" & rw.Cells("doc_no").Value.ToString & "' And Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "'")
                        Label10.Text = "Process M_TransGwp : "
                        BackgroundWorker3.ReportProgress(30)
                        getSqldbPromo("insert into [10.81.234.6].POS_SERVER.dbo.M_TransGwp SELECT [promo_id],[promo_name],[end_date] FROM  Promo_Hdr where doc_no = '" & rw.Cells("doc_no").Value.ToString & "' And Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "'  and tipe > 30")
                        BackgroundWorker3.ReportProgress(40)

                    Case "S012"

                        BackgroundWorker3.ReportProgress(0)
                        Label10.Text = "Process Header : " & Promo_ID
                        Try
                            getSqldbPromo("insert into [192.168.6.10].POS_SERVER.dbo.Promo_Hdr  SELECT [promo_id],[promo_name],[start_date],[end_date]," & _
                                                                                      "[min_purchase],[disc],[tipe],[voucher],[lipat],[ismsg],[isprn],[islimit],[qtylimit],[qtyout],'1',[min_member]," & _
                                                                                      "[txt1],[txt2],[txt3],[txt4] FROM Promo_Hdr where promo_id = '" & rw.Cells("promo_id").Value.ToString & "' And Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "'")
                        Catch ex As Exception
                            MsgBox("Error Connections 'LAKON'")
                            GoTo 1
                        End Try

                        BackgroundWorker3.ReportProgress(100)
                        Try
                            dsProcess = getSqldbPromo("SELECT [promo_id],[PLU],[description] FROM  Promo_Dtl where promo_id = '" & rw.Cells("promo_id").Value.ToString & "' And Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "'")
                            Label10.Text = "Process Detail : "

                            If dsProcess.Tables(0).Rows.Count > 0 Then
                                BackgroundWorker3.ReportProgress(0)
                                For Each ro As DataRow In dsProcess.Tables(0).Rows
                                    Prg += 100 / dsProcess.Tables(0).Rows.Count
                                    getSqldbPromo("insert into [192.168.6.10].POS_SERVER.dbo.Promo_Dtl Values ('" & ro("promo_id") & "','" & ro("PLU") & "','" & Replace(ro("description"), "'", "''") & "') ")
                                    Label10.Text = "Process Detail : " & rw.Cells("Branch_ID").Value.ToString & " " & ro("PLU") & " " & ro("description")
                                    If Int(Prg) < 100 Then
                                        BackgroundWorker3.ReportProgress(Int(Prg))
                                    End If
                                Next
                            End If
                        Catch ex As Exception
                            MsgBox("Error Transfer Promo_Dtl 'LAKON'")
                            getSqldbPromo("delete [192.168.6.10].POS_SERVER.dbo.Promo_Hdr where promo_id = '" & rw.Cells("promo_id").Value.ToString & "'")
                            GoTo 1
                        End Try
                        Prg = 0
                        Try
                            dsProcess.Clear()
                            If PromoTypex = "23" Then
                                dsProcess = getSqldbPromo("select b.* from PROMO_hdr a inner join promo_dtl b on a.txt2 = b.promo_id where b.Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "' and a.promo_id = '" & rw.Cells("promo_id").Value.ToString & "'")
                            ElseIf PromoTypex = "75" Then
                                Dim parts2() As String = txt4ID.ToString.Trim().Split(","c)
                                Dim txt4str As String = ""
                                For x As Integer = 0 To parts2.Length - 1
                                    If parts2(x) <> "" Then
                                        txt4str &= "'" & parts2(x) & "',"
                                    End If
                                Next
                                txt4str = Mid(txt4str, 1, txt4str.Length - 1)
                                dsProcess = getSqldbPromo("select * from promo_dtl where Branch_ID = '" & branch & "' and promo_id in (" & txt4str & ")")
                            Else
                                dsProcess = getSqldbPromo("select b.* from PROMO_hdr a inner join promo_dtl b on a.txt1 = b.promo_id where b.Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "' and a.promo_id = '" & rw.Cells("promo_id").Value.ToString & "'")
                            End If

                            Label10.Text = "Process Include : "

                            If dsProcess.Tables(0).Rows.Count > 0 Then
                                BackgroundWorker3.ReportProgress(0)
                                For Each ro As DataRow In dsProcess.Tables(0).Rows
                                    Prg += 100 / dsProcess.Tables(0).Rows.Count
                                    PromoInclude = ro("promo_id")
                                    getSqldbPromo("insert into [192.168.6.10].POS_SERVER.dbo.Promo_Dtl Values ('" & ro("promo_id") & "','" & ro("PLU") & "','" & Replace(ro("description"), "'", "''") & "') ")
                                    Label10.Text = "Process Include : " & rw.Cells("Branch_ID").Value.ToString & " " & ro("PLU") & " " & ro("description")
                                    If Int(Prg) < 100 Then
                                        BackgroundWorker3.ReportProgress(Int(Prg))
                                    End If
                                Next
                            End If
                        Catch ex As Exception
                            MsgBox("Error Transfer Include 'LAKON'")
                            getSqldbPromo("delete  [192.168.6.10].POS_SERVER.dbo.Promo_Hdr where promo_id = '" & rw.Cells("promo_id").Value.ToString & "'")
                            getSqldbPromo("delete  [192.168.6.10].POS_SERVER.dbo.Promo_dtl where promo_id = '" & rw.Cells("promo_id").Value.ToString & "'")
                            getSqldbPromo("delete  [192.168.6.10].POS_SERVER.dbo.Promo_dtl where promo_id = '" & PromoInclude & "'")
                            GoTo 1
                        End Try

                        'BackgroundWorker3.ReportProgress(10)
                        'getSqldbPromo("insert into [192.168.1.231].POS_SERVER.dbo.Promo_Dtl SELECT [promo_id],[PLU],[description] FROM  Promo_Dtl where promo_id = '" & Promo_ID & "' And Branch_ID = '" & branch & "'")
                        Label10.Text = "Process Flag All Item : "
                        BackgroundWorker3.ReportProgress(20)
                        getSqldbPromo("insert into [192.168.6.10].POS_SERVER.dbo.FlagAllItem_Promo SELECT [promo_id],[start_date],[end_date],[AllItemFlag] FROM  Promo_Hdr where doc_no = '" & rw.Cells("doc_no").Value.ToString & "' And Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "'")
                        Label10.Text = "Process M_TransGwp : "
                        BackgroundWorker3.ReportProgress(30)
                        getSqldbPromo("insert into [192.168.6.10].POS_SERVER.dbo.M_TransGwp SELECT [promo_id],[promo_name],[end_date] FROM  Promo_Hdr where doc_no = '" & rw.Cells("doc_no").Value.ToString & "' And Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "'  and tipe > 30")
                        BackgroundWorker3.ReportProgress(40)

                End Select
                Label10.Text = "Process Update Promo_Hdr : "
                getSqldbPromo("Update Promo_Hdr set transfer = 1,UpdDt = GetDate() where promo_id = '" & rw.Cells("promo_id").Value.ToString & "' And Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "'")
                BackgroundWorker3.ReportProgress(40)
                Label10.Text = "Process insert Promo_Hdr_History : "
                getSqldbPromo("insert into Promo_Hdr_History select * from Promo_Hdr where promo_id = '" & rw.Cells("promo_id").Value.ToString & "' And Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "'")
                BackgroundWorker3.ReportProgress(50)
                Label10.Text = "Process insert Other_Detail_History : "
                getSqldbPromo("insert into Other_Detail_History select * from Other_Detail where doc_no = '" & rw.Cells("doc_no").Value.ToString & "' And Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "'")
                BackgroundWorker3.ReportProgress(60)
                Label10.Text = "Process delete Other_Detail : "
                getSqldbPromo("delete from Other_Detail where doc_no = '" & DocNo & "' And Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "'")
                BackgroundWorker3.ReportProgress(70)
                Label10.Text = "Process delete Promo_Hdr : "
                getSqldbPromo("delete from Promo_Hdr where promo_id = '" & rw.Cells("promo_id").Value.ToString & "' And Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "'")
                BackgroundWorker3.ReportProgress(90)
                Label10.Text = "Process delete Promo_dtl : "
                getSqldbPromo("delete from Promo_dtl where promo_id = '" & rw.Cells("promo_id").Value.ToString & "' And Branch_ID = '" & rw.Cells("Branch_ID").Value.ToString & "'")
                BackgroundWorker3.ReportProgress(100)
1:
            Next
        Catch ex As Exception
            p_Edit = False
            Clear()
            MenuStrip1.Enabled = True
            ProgressBar1.Visible = False
            ToolStripMenuItem8.Enabled = False
            ToolStripMenuItem9.Enabled = False
            MsgBox(ex.Message)
            Ulang()
        End Try
    End Sub

    Private Sub ExecuteSqlTransaction(ByVal connectionString As String)
        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Dim command As SqlCommand = connection.CreateCommand()
            Dim transaction As SqlTransaction

            ' Start a local transaction
            transaction = connection.BeginTransaction("SampleTransaction")

            ' Must assign both transaction object and connection
            ' to Command object for a pending local transaction.
            command.Connection = connection
            command.Transaction = transaction

            Try
                command.CommandText = _
                  "Insert into Region (RegionID, RegionDescription) VALUES (100, 'Description')"
                command.ExecuteNonQuery()
                command.CommandText = _
                  "Insert into Region (RegionID, RegionDescription) VALUES (101, 'Description')"

                command.ExecuteNonQuery()

                ' Attempt to commit the transaction.
                transaction.Commit()
                Console.WriteLine("Both records are written to database.")

            Catch ex As Exception
                Console.WriteLine("Commit Exception Type: {0}", ex.GetType())
                Console.WriteLine("  Message: {0}", ex.Message)

                ' Attempt to roll back the transaction.
                Try
                    transaction.Rollback()

                Catch ex2 As Exception
                    ' This catch block will handle any errors that may have occurred
                    ' on the server that would cause the rollback to fail, such as
                    ' a closed connection.
                    Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType())
                    Console.WriteLine("  Message: {0}", ex2.Message)
                End Try
            End Try
        End Using
    End Sub

    Private Sub BackgroundWorker3_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker3.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker3_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker3.RunWorkerCompleted
        p_Edit = False
        Clear()
        MenuStrip1.Enabled = True
        Label10.Visible = False
        ProgressBar1.Visible = False
        ToolStripMenuItem8.Enabled = False
        ToolStripMenuItem9.Enabled = False
        MsgBox("Successfull !!!")
        Ulang()
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

    Private Sub ToolStripMenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem10.Click
        Dim dsAll As New DataSet
        ProgressBar1.Visible = True
        ProgressBar1.Value = 0
        If Promo_ID = "" Then
            MsgBox("Please Choose Promo First !!!")
            Exit Sub
        End If
        DsDetail = getSqldbPromo("Select * from promo_dtl where promo_id = '" & Promo_ID & "' and Branch_ID = '" & branch & "'")
        If DsDetail.Tables(0).Rows.Count > 0 Then
            If MsgBox("The data already exists !!!, delete the old data ??", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.No Then
                Exit Sub
            End If
            getSqldbPromo("delete from Promo_Dtl where promo_id = '" & Promo_ID & "' and Branch_ID = '" & branch & "'")
            getSqldbPromo("update Other_Detail set sbu = '',dept = '',brand = '',total_artikel = 0 where doc_no = '" & DocNo & "' and Branch_ID = '" & branch & "'")
        End If
        ProgressBar1.Value = 25
        dsAll = getSqldbPromo("Select distinct '" & branch & "','" & Promo_ID & "', PLU,Description from [HODBASE01].CentralPOS.dbo.item_master where " & _
                      "branch_id = '" & branch & "' And Description <> 'TIDAK AKTIF' and burui not in ('NMD92ZZZ9','NMD98ZZZ9') " & _
                      "and  PLU NOT IN('9000013100002', '9000063900003','9000012800002','9000012900009', '9000013900008'," & _
                      "'9000014000004','9000039000003','9000059600009', '9000059000007','9000059100004', '9000059200001'," & _
                      "'9000059300008','9000059400005', '9000063400008','9000063500005','9000036500005') ")
        ProgressBar1.Value = 50
        getSqldbPromo("Insert Into Promo_dtl Select distinct '" & branch & "','" & Promo_ID & "', PLU,Description from [HODBASE01].CentralPOS.dbo.item_master where " & _
                      "branch_id = 'S001' And Description <> 'TIDAK AKTIF' and burui not in ('NMD92ZZZ9','NMD98ZZZ9') " & _
                      "and  PLU NOT IN('9000013100002', '9000063900003','9000012800002','9000012900009', '9000013900008'," & _
                      "'9000014000004','9000039000003','9000059600009', '9000059000007','9000059100004', '9000059200001'," & _
                      "'9000059300008','9000059400005', '9000063400008','9000063500005','9000036500005') ")
        ProgressBar1.Value = 75
        getSqldbPromo("update Promo_hdr set statusD = 1,UpdDt = GetDate(),AllItemFlag = 1 where promo_id = '" & Promo_ID & "' and Branch_ID = '" & branch & "'")
        ProgressBar1.Value = 100
        getSqldbPromo("update Other_Detail set sbu = 'ALL SBU',dept = 'ALL DEPT',brand = 'ALL BRAND',total_artikel = '" & dsAll.Tables(0).Rows.Count & "' where doc_no = '" & DocNo & "'  and Branch_ID = '" & branch & "'")
        ProgressBar1.Visible = False
        MsgBox("Successfull")
        Ulang()
    End Sub

    Private Sub dtpForm_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpForm.TextChanged
        If dtpForm.Value.Date.AddDays(AtlsDay) < Now.Date Then
            MsgBox("Promo date of at least " & AtlsDay * -1 & " days after today !!! (H" & AtlsDay & ")")
            dtpForm.Value = Now.Date.AddDays(AtlsDay * -1)
        End If
        If dtpForm.Value > dtpTo.Value Then
            dtpTo.Value = dtpForm.Value
        End If
    End Sub

    Private Sub dtpTo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpTo.TextChanged
        If dtpForm.Value > dtpTo.Value Then
            dtpTo.Value = dtpForm.Value
        End If
    End Sub

    Private Sub DataGridView1_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DataGridView1.CellValidating
        If e.ColumnIndex = 1 Then
            If e.FormattedValue.ToString = "" Then
                Exit Sub
            End If
            If Not IsNumeric(e.FormattedValue) Then
                DataGridView1.Rows(e.RowIndex).ErrorText = _
                   "Qty must be a numeric value."
                e.Cancel = True
            Else
                DataGridView1.Rows(e.RowIndex).ErrorText = ""
                e.Cancel = False
            End If
        End If

    End Sub

    Private Sub DataGridView1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyUp
        If e.KeyCode = Keys.Enter Then
            If DataGridView1.Item(1, DataGridView1.CurrentRow.Index).Selected = True Then
                DataGridView1.Item(1, DataGridView1.CurrentRow.Index).Value = CDec(DataGridView1.Item(1, DataGridView1.CurrentRow.Index).Value).ToString("N0")
                SendKeys.Send("{right}")
                SendKeys.Send("{F2}")
            ElseIf DataGridView1.Item(2, DataGridView1.CurrentRow.Index).Selected = True Then
                DataGridView1.Rows.Add(1)
                SendKeys.Send("{down}")
                SendKeys.Send("{left}")
                SendKeys.Send("{F2}")
            End If
        End If
    End Sub

End Class
