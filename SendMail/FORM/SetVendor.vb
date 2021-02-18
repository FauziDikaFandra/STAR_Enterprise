Option Explicit On
Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports System.IO
Imports System.Text.RegularExpressions
Public Class SetVendor
    Dim dsVendor, DsUsers, DsComplete, DsBrand, DsCari, DsContact, DsBrandLocal, DsDepartment, DsVendorSvr, DsSbu, DsAutoNo As New DataSet
    Dim lvl, status, AddOrCancel As Integer
    Dim cekdata As String = "xxxxx"
    Dim cekdata2 As String = "xxxxx"
    Dim CmbIsSales, CmbIsAbsensi As String
    Dim cek As Boolean
    Dim IDContact As String
    Dim Auto As String

#Region "Parameter"
    Sub Tampil(ByVal Nama As String)
        strSQL = "select * From vendor"
        Read(strSQL)
        DR = cmd.ExecuteReader
        ComboBox5.Items.Clear()
        Do While DR.Read
            ComboBox5.Items.Add(DR("vendor_name") & " - " & DR("vendor_id"))
        Loop
        DR.Close() : DR = Nothing
        ComboBox5.SelectedIndex = 0
    End Sub
    'Private Sub cek()
    '    Dim find1, find2 As String
    '    Dim i As Integer
    '    Dim isi As New ComboBox
    '    find1 = Replace(ComboBox5.Text, "'", "")
    '    ComboBox5.Text = find1
    '    If find1 = "" Then
    '        ComboBox5.Focus()
    '        Exit Sub
    '    End If
    '    find2 = find1 + "%"
    '    strSQL = "select * from vendor where vendor_name like '" & find2 & "'"
    '    Read(strSQL)
    '    DR = cmd.ExecuteReader
    '    If DR.RecordsAffected Then
    '        ComboBox5.Items.Clear()
    '        While DR.Read
    '            ComboBox5.Items.Add(DR("vendor_id") & " - " & DR("Vendor_name"))
    '            i += 1
    '        End While

    '    End If
    '    ComboBox5.Focus()
    'End Sub
#End Region

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Bersih()
            ComboBox5.Focus()
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Cekvendor As String
        ComboBox5.Focus()
        Button5.Text = "UPDATE"
        'Button5.Enabled = False
        DsUsers = getSqldb2("select * from users where user_id ='" & UsrID & "'")
        lvl = DsUsers.Tables(0).Rows(0).Item("security_level")
        MySBU = DsUsers.Tables(0).Rows(0).Item("sbu")
        If lvl = 0 Then
            dsVendor = getSqldb2("select * From vendor order by vendor_id asc")
            DsBrand = getSqldb2("select distinct(Brand ) from CentralPos.dbo.Item_Master order by brand asc")
        Else
            dsVendor = getSqldb2("select * From vendor where sbu in (select sbu from users where user_id ='" & UsrID & "')")
            DsBrand = getSqldb2("select distinct(Brand ) from CentralPos.dbo.Item_Master where dp2 in (select  sbu from users where user_id ='" & UsrID & "') order by Brand asc")
        End If
        cek = False
        Cekvendor = "xxxxxx"
        If dsVendor.Tables(0).Rows.Count > 0 Then
            For Each ro As DataRow In dsVendor.Tables(0).Rows
                If Cekvendor = ro("vendor_id") Then
                Else
                    ComboBox5.Items.Add(ro("vendor_name") & " - " & ro("vendor_id"))
                    Cekvendor = ro("vendor_id")
                    ComboBox5.SelectedIndex = -1
                    viewdg()
                End If

            Next
        End If
        Dim CekBrand As String = "xxxxxx"
        ComboBox2.Items.Clear()
        For Each ro As DataRow In DsBrand.Tables(0).Rows
            If CekBrand = ro("brand") Then
            Else
                ComboBox2.Items.Add(ro("brand"))
                CekBrand = ro("brand")
            End If
        Next


    End Sub

    Sub viewdg()
        If lvl = 0 Then
            'DsComplete = getSqldb2("select * From Vendor a inner join Brand b " & _
            '                 "on a.Vendor_Id =b.Vendor_Id inner join Contact c " & _
            '                 "on b.vendor_id=c.vendor_id where a.vendor_id ='" & Microsoft.VisualBasic.Right(ComboBox5.Text, 5) & "'")
            'If DsComplete.Tables(0).Rows.Count > 0 Then
            '    DataGridView1.DataSource = DsComplete.Tables(0)
            '    DataGridView1.Columns("deleted").Visible = False
            '    DataGridView1.Columns("upd_date").Visible = False
            '    DataGridView1.Columns("vendor_id1").Visible = False
            '    DataGridView1.Columns("deleted1").Visible = False
            '    DataGridView1.Columns("upd_date1").Visible = False
            '    DataGridView1.Columns("vendor_id2").Visible = False
            '    DataGridView1.Columns("flag").Visible = False
            '    DataGridView1.Columns("deleted2").Visible = False
            '    DataGridView1.Columns("upd_date2").Visible = False
            'End If

        Else
            'DsComplete = getSqldb2("select * From Vendor a inner join Brand b " & _
            '                "on a.Vendor_Id =b.Vendor_Id inner join Contact c " & _
            '                "on b.vendor_id=c.vendor_id where a.vendor_id ='" & Microsoft.VisualBasic.Right(ComboBox5.Text, 5) & "'" & _
            '                "and a.sbu in (select sbu from users where user_id ='123')")
            'If DsComplete.Tables(0).Rows.Count > 0 Then
            '    DataGridView1.DataSource = DsComplete.Tables(0)
            '    DataGridView1.Columns("deleted").Visible = False
            '    DataGridView1.Columns("upd_date").Visible = False
            '    DataGridView1.Columns("vendor_id1").Visible = False
            '    DataGridView1.Columns("deleted1").Visible = False
            '    DataGridView1.Columns("upd_date1").Visible = False
            '    DataGridView1.Columns("vendor_id2").Visible = False
            '    DataGridView1.Columns("flag").Visible = False
            '    DataGridView1.Columns("deleted2").Visible = False
            '    DataGridView1.Columns("upd_date2").Visible = False
            'End If
        End If
    End Sub

    Sub viewdg2(ByVal vendorid As String)
        If lvl = 0 Then
            DsContact = getSqldb2("Select * from contact  where vendor_id ='" & vendorid & "' and deleted ='0'")
        Else
            DsContact = getSqldb2("Select * from contact  where vendor_id ='" & vendorid & "' and deleted ='0'")
        End If

        If DsContact.Tables(0).Rows.Count > 0 Then
            DataGridView1.DataSource = DsContact.Tables(0)
            DataGridView1.Columns("Contact_id").Visible = False
            DataGridView1.Columns("Vendor_id").Visible = False
            'DataGridView1.Columns("Vendor_Name").Visible = False
            DataGridView1.Columns("upd_date").Visible = False
            DataGridView1.Columns("flag").Visible = False
            DataGridView1.Columns("Deleted").Visible = False
        End If

    End Sub


    Sub AutoNumber()
        'Dim ambilNO As String
        'Dim Panjang As String
        Dim urutan As String
        'Dim crDate As String

        Dim m, Y As String

        'crDate = DateTime.Now.ToString("dd-mm-yyyy")
        'd = Trim(CStr(LTrim(crDate, 2)))

        m = Format(Now, "MM")
        Y = Format(Now, "yyyy")
        'Y = Trim(CStr(Right(crDate, 4)))
        'mx = Y & m

        'rs = New ADODB.Recordset

        DsAutoNo = getSqldb2("select * from contact order by contact_id desc")

        'rs.Open(Sql, ConS, adOpenDynamic, adLockPessimistic)
        With DsAutoNo
            If .Tables(0).Rows.Count = 0 Then
                Auto = Y & m & "-" & "001"
            Else
                If Microsoft.VisualBasic.Left(DsAutoNo.Tables(0).Rows(0).Item("contact_id"), 6) = Y & m Then
                    urutan = Microsoft.VisualBasic.Right(DsAutoNo.Tables(0).Rows(0).Item("contact_id"), 3) + 1
                    'ambilNO = Right(rs("no_angsuran"), 3)
                    'Panjang = ambilNO + 1
                    Select Case Len(urutan)
                        Case 1 : urutan = "00" & urutan
                        Case 2 : urutan = "0" & urutan
                        Case 3 : urutan = urutan
                    End Select
                    Auto = Y & m & "-" & urutan
                Else
                    Auto = Y & m & "-" & "001"
                End If
            End If
        End With
    End Sub
    Private Shared Function SingleEmailValid(ByVal EmailAddress As _
        String) As String
        Dim regex As Regex = New Regex("([a-zA-Z0-9_\-\.]+)@" & _
                             "((\[[0-9]{1,3}\.[0-9]{1,3}\." & _
                             "[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+" & _
                             "\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})", _
                             RegexOptions.IgnoreCase _
                             Or RegexOptions.CultureInvariant _
                             Or RegexOptions.IgnorePatternWhitespace _
                             Or RegexOptions.Compiled _
                             )
        If EmailAddress.Trim.Length = 0 Then
            Return "Email Address must be filled."
        ElseIf regex.IsMatch(EmailAddress) And _
               EmailAddress.Equals(regex.Match(EmailAddress).ToString) _
               Then
            Return ""
        Else
            Return "Invalid email Address."
        End If
    End Function
    Sub ViewData(ByVal a As Integer)
        If DataGridView1.Rows.Count > 0 Then
            Try
                Dim i As Integer = a
                Dim Cekvendor As String
                Cekvendor = "xxxxxx"
                If dsVendor.Tables(0).Rows.Count > 0 Then
                    For Each ro As DataRow In dsVendor.Tables(0).Rows
                        If Cekvendor = ro("vendor_id") Then
                        Else
                            ComboBox5.Items.Add(ro("vendor_name") & " - " & ro("vendor_id"))
                            Cekvendor = ro("vendor_id")
                            'ComboBox5.SelectedIndex = -1
                            viewdg()
                        End If

                    Next
                End If
                'ComboBox5.SelectedIndex = -1
                TextBox3.Text = DataGridView1.Rows(i).Cells(2).Value
                TextBox4.Text = DataGridView1.Rows(i).Cells(3).Value
                TextBox5.Text = DataGridView1.Rows(i).Cells(4).Value
                TextBox6.Text = DataGridView1.Rows(i).Cells(6).Value
                IDContact = DataGridView1.Rows(i).Cells(1).Value
                If DataGridView1.Rows(i).Cells(7).Value = 1 And DataGridView1.Rows(i).Cells(8).Value = 0 Then
                    ComboBox3.Text = "Absensi"
                ElseIf DataGridView1.Rows(i).Cells(8).Value = 1 And DataGridView1.Rows(i).Cells(7).Value = 0 Then
                    ComboBox3.Text = "Sales"
                Else
                    ComboBox3.Text = "Absensi & Sales"
                End If
                If DataGridView1.Rows(i).Cells(5).Value = "M" Then
                    ComboBox4.Text = "Male"
                Else
                    ComboBox4.Text = "Female"
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Sub Bersih()
        ComboBox1.Items.Clear() : ComboBox2.Text = "" : ComboBox6.Items.Clear() : TextBox3.Text = "" : TextBox4.Text = "" : TextBox5.Text = "" : TextBox6.Text = "" : ComboBox3.SelectedIndex = 0 : ComboBox4.SelectedIndex = 0
    End Sub
    Sub Bersih_Contact()
        TextBox3.Text = "" : TextBox4.Text = "" : TextBox5.Text = "" : TextBox6.Text = "" : ComboBox3.Text = "" : ComboBox4.Text = "" : TextBox3.Focus()
    End Sub
    Private Sub ComboBox5_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox5.SelectedIndexChanged
        cekdata = "xxxxxx"
        ComboBox1.Items.Clear()
        ComboBox2.Items.Clear()
        ComboBox6.Items.Clear()
        For Each ro As DataRow In dsVendor.Tables(0).Rows
            'If ro("vendor_id") = Microsoft.VisualBasic.Right(ComboBox5.Text, 5) Then
            If cekdata = ro("sbu") Then
            Else
                ComboBox1.Items.Add(ro("sbu"))
                cekdata = ro("sbu")
            End If
            ' End If

        Next
        Try
            ComboBox1.SelectedIndex = 0
        Catch ex As Exception

        End Try

        cekdata = "xxxxxx"
        cekdata2 = "xxxxxx"
        viewdg2(Microsoft.VisualBasic.Right(ComboBox5.Text, 5))
        If DsContact.Tables(0).Rows.Count > 0 Then
            ViewData(0)
            If AddOrCancel = 1 Then
                Bersih_Contact()
            End If
        End If
        DsBrandLocal = getSqldb2("select distinct Brand,Department from Brand Where Vendor_id = '" & Microsoft.VisualBasic.Right(ComboBox5.Text, 5) & "' and Brand in (select distinct Brand from centralpos.dbo.item_master " & _
                                        "where Supplier_Code ='" & Microsoft.VisualBasic.Right(ComboBox5.Text, 5) & "' and DP2 in (select sbu from Supplier_Contact.dbo.Users where USER_ID ='" & UsrID & "'))")

        If cek = True Then
            Dim CekBrand As String = "xxxxxx"
            ComboBox2.Items.Clear()
            For Each ro As DataRow In DsBrand.Tables(0).Rows
                If CekBrand = ro("brand") Then
                Else
                    ComboBox2.Items.Add(ro("brand"))
                    CekBrand = ro("brand")
                End If
            Next
        Else
            If DsBrandLocal.Tables(0).Rows.Count > 0 Then
                ComboBox6.Items.Clear()
                For Each ro As DataRow In DsBrandLocal.Tables(0).Rows
                    If cekdata = ro("Brand") Then
                    Else
                        ComboBox2.Items.Add(ro("Brand"))
                        cekdata = ro("Brand")
                    End If
                    If cekdata2 = ro("Department") Then
                    Else
                        ComboBox6.Items.Add(ro("Department"))
                        cekdata2 = ro("Department")
                    End If
                Next
                ComboBox2.SelectedIndex = 0
                ComboBox6.SelectedIndex = 0
            End If
        End If



    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Button4.Text = "ADD" Then
            'AutoNumber()
            AddOrCancel = 1
            cek = True
            Button5.Text = "SAVE"
            'Button5.Enabled = True
            'DsUsers = getSqldb2("select * from users where user_id ='123'")
            'lvl = DsUsers.Tables(0).Rows(0).Item("security_level")
            If lvl = 0 Then
                DsVendorSvr = getSqldb2("select distinct a.CardCode ,LEFT(c.U_profit_ctr,2) As SBU,b.CardName From [192.168.1.6].star.dbo.oitm a inner join [192.168.1.6].star.dbo.OCRD b " & _
                                        "on a.CardCode  =b.CardCode inner join [192.168.1.6].star.dbo.OITW c on c.ItemCode=a.ItemCode")
                'DsSbu = getSqldb2("select distinct(dp2),Supplier_Code  From Item_Master where Supplier_Code ='" & Microsoft.VisualBasic.Right(ComboBox5.Text, 5) & "'")
            Else
                DsVendorSvr = getSqldb2("select distinct a.CardCode ,LEFT(c.U_profit_ctr,2)  As SBU,b.CardName From [192.168.1.6].star.dbo.oitm a inner join [192.168.1.6].star.dbo.OCRD b " & _
                                        "on a.CardCode  =b.CardCode inner join [192.168.1.6].star.dbo.OITW c on c.ItemCode=a.ItemCode where LEFT(c.U_profit_ctr,2) = '" & MySBU & "'")
                'DsSbu = getSqldb2("select distinct(Brand ) from centralpos.dbo.Item_Master where dp2 in (select  sbu from users where user_id ='123') order by Brand asc")
            End If


            Dim Cekvendor As String

            Bersih()
            ComboBox1.SelectedText = MySBU
            'ComboBox1.SelectedIndex = 0
            Try
                ComboBox2.Text = ""
                ComboBox6.SelectedIndex = 0
            Catch ex As Exception

            End Try
            Button4.Text = "CANCEL"
            DataGridView1.DataSource = Nothing
            Cekvendor = "xxxxxx"
            If DsVendorSvr.Tables(0).Rows.Count > 0 Then
                For Each ro As DataRow In DsVendorSvr.Tables(0).Rows
                    If Cekvendor = ro("CardCode") Then
                    Else
                        ComboBox5.Items.Add(ro("CardName") & " - " & ro("CardCode"))
                        Cekvendor = ro("CardCode")
                        'ComboBox5.SelectedIndex = -1
                        'viewdg()
                    End If

                Next
            End If
            cekdata = "XXXXXX"
            For Each ro As DataRow In DsVendorSvr.Tables(0).Rows

                If cekdata = ro("sbu") Then
                Else
                    ComboBox1.Items.Add(ro("sbu"))
                    cekdata = ro("sbu")
                End If


            Next
            ComboBox5.Text = ""
            ComboBox5.Focus()
            DataGridView1.Enabled = False
        Else
            cek = False
            ComboBox5.Items.Clear()
            Button5.Text = "UPDATE"
            Dim Cekvendor As String
            Cekvendor = "xxxxxx"
            If dsVendor.Tables(0).Rows.Count > 0 Then
                For Each ro As DataRow In dsVendor.Tables(0).Rows
                    If Cekvendor = ro("Vendor_Id") Then
                    Else
                        ComboBox5.Items.Add(ro("Vendor_Name") & " - " & ro("Vendor_Id"))
                        Cekvendor = ro("Vendor_Id")
                        ComboBox5.SelectedIndex = -1
                        viewdg()
                    End If

                Next
            End If
            ComboBox1.Items.Clear()
            cekdata = "XXXXXX"
            For Each ro As DataRow In dsVendor.Tables(0).Rows

                If cekdata = ro("sbu") Then
                Else
                    ComboBox1.Items.Add(ro("sbu"))
                    cekdata = ro("sbu")
                End If


            Next
            'Button5.Enabled = False
            AddOrCancel = 0
            Bersih()
            Button4.Text = "ADD"
            ComboBox5.Text = ""
            ComboBox5.Focus()
            DataGridView1.Enabled = True
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then ComboBox1.Focus()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Me.Close()
    End Sub

    Private Sub DataGridView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Click
        ViewData(DataGridView1.CurrentRow.Index)
    End Sub



    Private Sub Combobox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then TextBox3.Focus()
    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If Not Char.IsLetter(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Space) And Not e.KeyChar = Chr(Keys.Enter) Then
            e.Handled = True
        End If
        If e.KeyChar = Chr(13) Then TextBox4.Focus()
    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If e.KeyChar = Chr(13) Then TextBox5.Focus()
    End Sub

    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        If e.KeyChar = Chr(13) Then TextBox6.Focus()
    End Sub

    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled() = True
        If e.KeyChar = Chr(13) Then ComboBox3.Focus()
    End Sub

    Private Sub ComboBox3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox3.KeyDown
        If e.KeyData = Keys.Enter Then ComboBox4.Focus()
    End Sub

    Private Sub ComboBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox3.KeyPress
        If e.KeyChar = Chr(13) Then ComboBox4.Focus()
    End Sub

    Private Sub ComboBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox1.KeyDown
        If e.KeyData = Keys.Enter Then ComboBox2.Focus()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim Gender As String
        If TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Then
            MsgBox("Data Masih ada yang kosong !!!", MsgBoxStyle.Exclamation)
            TextBox3.Focus()
            Exit Sub
        End If
        If TextBox4.Text <> "" Then
            Me.ErrorProvider1.SetError(Me.TextBox4, SingleEmailValid(Me.TextBox4.Text))
            TextBox4.Focus()
        End If
        If ComboBox3.SelectedIndex = 0 Then
            CmbIsAbsensi = 1
            CmbIsSales = 0
        ElseIf ComboBox3.SelectedIndex = 1 Then
            CmbIsSales = 1
            CmbIsAbsensi = 0
        Else
            CmbIsAbsensi = 1
            CmbIsSales = 1
        End If

        If ComboBox4.SelectedIndex = 0 Then
            Gender = "M"
        Else
            Gender = "F"
        End If
        If Button5.Text = "SAVE" Then
            AutoNumber()
            dsVendor = getSqldb2("select * from vendor where vendor_id ='" & Microsoft.VisualBasic.Right(ComboBox5.Text, 5) & "' And SBU = '" & ComboBox1.Text & "'")
            If Not dsVendor.Tables(0).Rows.Count > 0 Then
                getSqldb2("insert into Vendor (Vendor_Id ,Vendor_Name ,SBU ,OSDay, Deleted ,Upd_Date ) Values ('" & Microsoft.VisualBasic.Right(ComboBox5.Text, 5) & "','" & Microsoft.VisualBasic.Left(ComboBox5.Text, ComboBox5.Text.Length - 7) & "','" & ComboBox1.Text & "','0','0',GETDATE())")
            Else
                'getSqldb2("update vendor set vendor_id ='" & Microsoft.VisualBasic.Right(ComboBox5.Text, 5) & "',vendor_name ='" & Microsoft.VisualBasic.Left(ComboBox5.Text, ComboBox5.Text.Length - 7) & "',SBU='" & ComboBox1.Text & "',Upd_date = Getdate() where vendor_id ='" & Microsoft.VisualBasic.Right(ComboBox5.Text, 5) & "'")
            End If
            DsBrandLocal = getSqldb2("select * from brand where brand ='" & ComboBox2.Text & "'  and vendor_id ='" & Microsoft.VisualBasic.Right(ComboBox5.Text, 5) & "'")
            If Not DsBrandLocal.Tables(0).Rows.Count > 0 Then
                getSqldb2("insert into Brand (Brand ,Vendor_Id,Department ,Deleted, upd_date) Values ('" & ComboBox2.Text & "','" & Microsoft.VisualBasic.Right(ComboBox5.Text, 5) & "','" & ComboBox6.Text & "','0',GETDATE ())")
            Else
                'getSqldb2("update brand set Brand ='" & ComboBox2.Text & "',Vendor_id ='" & Microsoft.VisualBasic.Right(ComboBox5.Text, 5) & "',Department ='" & ComboBox6.Text & "',upd_date = Getdate() where brand ='" & ComboBox2.Text & "' and Department ='" & ComboBox6.Text & "' and vendor_id ='" & Microsoft.VisualBasic.Right(ComboBox5.Text, 5) & "'")

            End If

            DsContact = getSqldb2("Select * From Contact where  Contact_id ='" & Auto & "' and vendor_id ='" & Microsoft.VisualBasic.Right(ComboBox5.Text, 5) & "' and deleted = '0'")
            'If TextBox3.Text Then
            If Not DsContact.Tables(0).Rows.Count > 0 Then
                'Dim ro As DataRow In DsContact.Tables(0).Rows
                'If cekdata = ro("Contact_name") =  Then
                getSqldb2("insert into Contact (Vendor_Id ,Contact_id,Contact_Name ,Email ,Position ,Gender ,Phone,Is_Absensi ,Is_Sales ,Flag ,Deleted ,Upd_Date)" & _
                        "values('" & Microsoft.VisualBasic.Right(ComboBox5.Text, 5) & "','" & Auto & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & Gender & "','" & TextBox6.Text & "','" & CmbIsAbsensi & "','" & CmbIsSales & "','0','0',GETDATE ())")
            Else
                'getSqldb2("update contact set vendor_id='" & Microsoft.VisualBasic.Right(ComboBox5.Text, 5) & "',contact_name='" & TextBox3.Text & "',Email ='" & TextBox4.Text & "',Position ='" & TextBox5.Text & "',Gender ='" & ComboBox4.Text & "',Phone='" & TextBox6.Text & "',is_absensi ='" & CmbIsAbsensi & "',is_sales ='" & CmbIsSales & "',Upd_date =Getdate() Where contact_name ='" & TextBox3.Text & "' and vendor_id ='" & Microsoft.VisualBasic.Right(ComboBox5.Text, 5) & "'")

            End If
        Else
            'dsVendor = getSqldb2("select * from vendor where vendor_id ='" & Microsoft.VisualBasic.Right(ComboBox5.Text, 5) & "'")
            'If Not dsVendor.Tables(0).Rows.Count > 0 Then
            '    'getSqldb2("insert into Vendor (Vendor_Id ,Vendor_Name ,SBU ,Deleted ,Upd_Date ) Values ('" & Microsoft.VisualBasic.Right(ComboBox5.Text, 5) & "','" & Microsoft.VisualBasic.Left(ComboBox5.Text, ComboBox5.Text.Length - 7) & "','" & ComboBox1.Text & "','0',GETDATE())")
            'Else
            '    'getSqldb2("update vendor set vendor_id ='" & Microsoft.VisualBasic.Right(ComboBox5.Text, 5) & "',vendor_name ='" & Microsoft.VisualBasic.Left(ComboBox5.Text, ComboBox5.Text.Length - 7) & "',SBU='" & ComboBox1.Text & "',Upd_date = Getdate() where vendor_id ='" & Microsoft.VisualBasic.Right(ComboBox5.Text, 5) & "'")
            'End If

            'DsBrandLocal = getSqldb2("select * from brand where brand ='" & ComboBox2.Text & "' and Department ='" & ComboBox6.Text & "' and vendor_id ='" & Microsoft.VisualBasic.Right(ComboBox5.Text, 5) & "'")
            'If Not DsBrandLocal.Tables(0).Rows.Count > 0 Then
            '    'getSqldb2("insert into Brand (Brand ,Vendor_Id,Department ,Deleted, upd_date) Values ('" & ComboBox2.Text & "','" & Microsoft.VisualBasic.Right(ComboBox5.Text, 5) & "','" & ComboBox6.Text & "','0',GETDATE ())")
            'Else
            '    getSqldb2("update brand set Brand ='" & ComboBox2.Text & "',Vendor_id ='" & Microsoft.VisualBasic.Right(ComboBox5.Text, 5) & "',Department ='" & ComboBox6.Text & "',upd_date = Getdate() where brand ='" & ComboBox2.Text & "' and Department ='" & ComboBox6.Text & "' and vendor_id ='" & Microsoft.VisualBasic.Right(ComboBox5.Text, 5) & "'")

            'End If

            DsContact = getSqldb2("Select * From Contact where vendor_id ='" & Microsoft.VisualBasic.Right(ComboBox5.Text, 5) & "' and deleted = '0'")
            'If TextBox3.Text Then
            If Not DsContact.Tables(0).Rows.Count > 0 Then
                'Dim ro As DataRow In DsContact.Tables(0).Rows
                'If cekdata = ro("Contact_name") =  Then
                'getSqldb2("insert into Contact (Vendor_Id ,Contact_Name ,Email ,Position ,Gender ,Phone,Is_Absensi ,Is_Sales ,Flag ,Deleted ,Upd_Date)" & _
                '"values('" & Microsoft.VisualBasic.Right(ComboBox5.Text, 5) & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & ComboBox4.Text & "','" & TextBox6.Text & "','" & CmbIsAbsensi & "','" & CmbIsSales & "','0','0',GETDATE ())")
            Else
                getSqldb2("update contact set contact_name='" & TextBox3.Text & "',Email ='" & TextBox4.Text & "',Position ='" & TextBox5.Text & "',Gender ='" & Gender & "',Phone='" & TextBox6.Text & "',is_absensi ='" & CmbIsAbsensi & "',is_sales ='" & CmbIsSales & "',Upd_date =Getdate() Where Contact_id ='" & IDContact & "' and vendor_id ='" & Microsoft.VisualBasic.Right(ComboBox5.Text, 5) & "' and deleted = '0'")

            End If
        End If



        MsgBox("Data Berhasil diSimpan", MsgBoxStyle.OkOnly)
        Button4.Text = "ADD"
        Button5.Text = "UPDATE"
        Bersih()
        TextBox3.Focus()
        DataGridView1.Enabled = True
        viewdg2(Microsoft.VisualBasic.Right(ComboBox5.Text, 5))
    End Sub

    Private Sub ComboBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox2.KeyDown
        If e.KeyData = Keys.Enter Then ComboBox6.Focus()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        ComboBox6.Items.Clear()
        cekdata = "xxxxx"
        DsDepartment = getSqldb2("select distinct(SUBSTRING(burui,2,2)) as DP from CentralPos.dbo.item_master where Brand ='" & ComboBox2.Text & "' and dp2 = '" & ComboBox1.Text & "'")
        If DsDepartment.Tables(0).Rows.Count > 0 Then
            For Each ro As DataRow In DsDepartment.Tables(0).Rows
                If cekdata = ro("Dp") Then
                Else
                    ComboBox6.Items.Add(ro("Dp"))
                    'cekdata = ro("Brand")
                End If
            Next
        End If

    End Sub

    Private Sub ComboBox4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox4.KeyDown
        If e.KeyData = Keys.Enter Then Button5.Focus()
    End Sub

    Private Sub TextBox4_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox4.Leave
        If TextBox4.Text <> "" Then
            Me.ErrorProvider1.SetError(Me.TextBox4, SingleEmailValid(Me.TextBox4.Text))
        End If
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        'Me.ErrorProvider1.SetError(Me.TextBox4, SingleEmailValid(Me.TextBox4.Text))
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        getSqldb2("Update contact set deleted ='1' Where Contact_id ='" & IDContact & "' and vendor_id ='" & Microsoft.VisualBasic.Right(ComboBox5.Text, 5) & "'")
        MsgBox("Data Berhasil diDelete...", MsgBoxStyle.Information)
        viewdg2(Microsoft.VisualBasic.Right(ComboBox5.Text, 5))
    End Sub
End Class
