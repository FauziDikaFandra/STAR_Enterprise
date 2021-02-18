Public Class SettingVendor
    Dim dsVendor, dsCon, dsBrand, DsAutoNo As New DataSet
    Dim t_load As Boolean = False
    Dim T_Edit As Integer
    Dim d_edit As Boolean
    Dim Auto, Gender, CmbIsSales, CmbIsAbsensi As String
    Private Sub SettingVendor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load   

        d_edit = False
        T_Edit = 0
        cmb2(ComboBox4, "select Vendor_Id,Vendor_Name From vendor where sbu in (select sbu from users where user_id ='" & UsrID & "') Order By Vendor_Name", "Vendor_Id", "Vendor_Name", 1)
        cmb2(ComboBox3, "select Distinct a.Brand from brand a inner join vendor b on a.vendor_id =  b.vendor_id where b.sbu in (select sbu from users where user_id ='" & UsrID & "') And Brand <> '' And a.vendor_id = '" & ComboBox4.SelectedValue & "' Order By Brand", "Brand", "Brand", 1)
        cmb2(ComboBox2, "select DISTINCT Department from brand where Department <> '' And Brand = '" & ComboBox3.SelectedValue & "' Order By Department", "Department", "Department", 1)
        cmb2(ComboBox1, "select sbu from users where user_id ='" & UsrID & "' Order By sbu", "sbu", "sbu", 1)
        cmb2(ComboBox7, "Select Contact_Id,Contact_name From Contact where vendor_id = '" & ComboBox4.SelectedValue & "' Order By Contact_name", "Contact_Id", "Contact_name", 1)
        dsCon = getSqldb2("Select * from COntact where Contact_Id = '" & ComboBox7.SelectedValue & "'")
        If dsCon.Tables(0).Rows.Count > 0 Then
            TextBox4.Text = dsCon.Tables(0).Rows(0).Item("Email")
            TextBox5.Text = dsCon.Tables(0).Rows(0).Item("Position")
            TextBox6.Text = dsCon.Tables(0).Rows(0).Item("Phone")
            If dsCon.Tables(0).Rows(0).Item("Is_Absensi") = 1 And dsCon.Tables(0).Rows(0).Item("Is_Sales") = 1 Then
                ComboBox6.SelectedIndex = 2
            ElseIf dsCon.Tables(0).Rows(0).Item("Is_Absensi") = 0 And dsCon.Tables(0).Rows(0).Item("Is_Sales") = 1 Then
                ComboBox6.SelectedIndex = 1
            Else
                ComboBox6.SelectedIndex = 0
            End If
            If dsCon.Tables(0).Rows(0).Item("Gender") = "M" Then
                ComboBox5.SelectedIndex = 0
            Else
                ComboBox5.SelectedIndex = 1
            End If
        End If
        Button4.Enabled = True
        Button5.Enabled = True
        Button6.Enabled = True
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        ComboBox7.Visible = True
        t_load = True
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        If t_load = True Then
            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.Clear()
            If d_edit = True Then
                cmb2(ComboBox3, "select distinct TH2.CardCode,TH4.CardName,TH8.u_description,Substring(TH3.ItmsGrpNam,6,3) as Brand " & _
             " from [star01].STAR.dbo.OITB TH3 inner join [star01].STAR.dbo.OITM TH2 on th2.Itmsgrpcod = TH3.Itmsgrpcod inner join [star01].STAR.dbo.OCRD TH4 on TH4.CardCode = TH2.CardCode inner " & _
             " join [star01].STAR.dbo.[@PRODUCT_BRAND] TH8 on TH8.name = Substring(TH3.ItmsGrpNam,6,3) inner join [star01].STAR.dbo.OITW TH5 On TH5.ItemCode = TH2.ItemCode where " & _
             "TH2.CardCode = '" & ComboBox4.SelectedValue & "'  order by TH8.u_description", "u_description", "u_description", 1)

            Else
                cmb2(ComboBox3, "select Distinct a.Brand from brand a inner join vendor b on a.vendor_id =  b.vendor_id where b.sbu in (select sbu from users where user_id ='" & UsrID & "') And Brand <> '' And a.vendor_id = '" & ComboBox4.SelectedValue & "' Order By Brand", "Brand", "Brand", 1)
                cmb2(ComboBox7, "Select Contact_Id,Contact_name From Contact where vendor_id = '" & ComboBox4.SelectedValue & "' Order By Contact_name", "Contact_Id", "Contact_name", 1)
            End If

        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        If t_load = True Then
            cmb2(ComboBox2, "select DISTINCT Department from brand where Department <> '' And Brand = '" & Replace(ComboBox3.SelectedValue, "'", "''") & "' Order By Department", "Department", "Department", 1)
        End If
    End Sub

    Private Sub ComboBox7_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox7.SelectedValueChanged
        If t_load = True Then
            dsCon = getSqldb2("Select * from COntact where Contact_Id = '" & ComboBox7.SelectedValue & "'")
            If dsCon.Tables(0).Rows.Count > 0 Then
                TextBox4.Text = dsCon.Tables(0).Rows(0).Item("Email")
                TextBox5.Text = dsCon.Tables(0).Rows(0).Item("Position")
                TextBox6.Text = dsCon.Tables(0).Rows(0).Item("Phone")
                If dsCon.Tables(0).Rows(0).Item("Is_Absensi") = 1 And dsCon.Tables(0).Rows(0).Item("Is_Sales") = 1 Then
                    ComboBox6.SelectedIndex = 2
                ElseIf dsCon.Tables(0).Rows(0).Item("Is_Absensi") = 0 And dsCon.Tables(0).Rows(0).Item("Is_Sales") = 1 Then
                    ComboBox6.SelectedIndex = 1
                Else
                    ComboBox6.SelectedIndex = 0
                End If
                If dsCon.Tables(0).Rows(0).Item("Gender") = "M" Then
                    ComboBox5.SelectedIndex = 0
                Else
                    ComboBox5.SelectedIndex = 1
                End If
            Else
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox6.Text = ""
                ComboBox6.SelectedIndex = 0
                ComboBox5.SelectedIndex = 0
            End If
        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Button4.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        d_edit = True
        T_Edit = 0
        ComboBox7.Visible = False
        cmb2(ComboBox4, "select distinct a.CardCode ,b.CardName From star01.star.dbo.oitm a inner join star01.star.dbo.OCRD b " & _
"on a.CardCode  = b.CardCode inner join star01.star.dbo.OITW c on c.ItemCode=a.ItemCode where b.cardCode not in (Select Distinct Vendor_Id From Vendor Where SBU in (select sbu from users where user_id ='" & UsrID & "')) " & _
" Order By b.CardName", "CardCode", "CardName", 1)
        cmb2(ComboBox3, "select distinct TH2.CardCode,TH4.CardName,TH8.u_description,Substring(TH3.ItmsGrpNam,6,3) as Brand, Left(TH5.U_PROFIT_CTR,2) " & _
             " As Sbu from [star01].STAR.dbo.OITB TH3 inner join [star01].STAR.dbo.OITM TH2 on th2.Itmsgrpcod = TH3.Itmsgrpcod inner join [star01].STAR.dbo.OCRD TH4 on TH4.CardCode = TH2.CardCode inner " & _
             " join [star01].STAR.dbo.[@PRODUCT_BRAND] TH8 on TH8.name = Substring(TH3.ItmsGrpNam,6,3) inner join [star01].STAR.dbo.OITW TH5 On TH5.ItemCode = TH2.ItemCode where " & _
             "TH2.CardCode = '" & ComboBox4.SelectedValue & "' and Left(TH5.U_PROFIT_CTR,2) in (select sbu collate SQL_Latin1_General_CP850_CI_AS from users where user_id ='" & UsrID & "') order by TH8.u_description", "u_description", "u_description", 1)
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        ComboBox6.SelectedIndex = 0
        ComboBox5.SelectedIndex = 0
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Button6.Enabled = False
        Button4.Enabled = True
        Button5.Enabled = True

        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = False
        d_edit = True
        T_Edit = 0
        ComboBox7.Visible = False
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        ComboBox6.SelectedIndex = 0
        ComboBox5.SelectedIndex = 0
        TextBox3.Focus()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Button5.Enabled = False
        Button6.Enabled = True
        Button4.Enabled = True
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = True
        d_edit = True
        T_Edit = 1
        ComboBox7.Visible = True
        cmb2(ComboBox3, "select distinct TH2.CardCode,TH4.CardName,TH8.u_description,Substring(TH3.ItmsGrpNam,6,3) as Brand, Left(TH5.U_PROFIT_CTR,2) " & _
            " As Sbu from [star01].STAR.dbo.OITB TH3 inner join [star01].STAR.dbo.OITM TH2 on th2.Itmsgrpcod = TH3.Itmsgrpcod inner join [star01].STAR.dbo.OCRD TH4 on TH4.CardCode = TH2.CardCode inner " & _
            " join [star01].STAR.dbo.[@PRODUCT_BRAND] TH8 on TH8.name = Substring(TH3.ItmsGrpNam,6,3) inner join [star01].STAR.dbo.OITW TH5 On TH5.ItemCode = TH2.ItemCode where " & _
            " Left(TH5.U_PROFIT_CTR,2) in (select sbu collate SQL_Latin1_General_CP850_CI_AS from users where user_id ='" & UsrID & "') order by TH8.u_description", "u_description", "u_description", 1)
        cmb2(ComboBox2, "select DISTINCT Department from brand where Department <> ''  Order By Department", "Department", "Department", 1)
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        SettingVendor_Load(sender, e)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("Delete This Vendor ??", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.Yes Then
            getSqldb2("delete from vendor where Vendor_Id = '" & ComboBox4.SelectedValue & "'")
            getSqldb2("delete from Contact where Vendor_Id = '" & ComboBox4.SelectedValue & "'")
            getSqldb2("delete from Brand where Vendor_Id = '" & ComboBox4.SelectedValue & "'")

            MsgBox("Deleted !!!")
            SettingVendor_Load(sender, e)
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MsgBox("Delete This Brand ??", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.Yes Then
            getSqldb2("delete from Brand where Vendor_Id = '" & ComboBox4.SelectedValue & "' And Brand = '" & ComboBox3.SelectedValue & "'")
            MsgBox("Deleted !!!")
            SettingVendor_Load(sender, e)
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If MsgBox("Delete This Contact ??", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.Yes Then
            getSqldb2("delete from Contact where Vendor_Id = '" & ComboBox4.SelectedValue & "' And Contact_Id = '" & ComboBox7.SelectedValue & "'")
            MsgBox("Deleted !!!")
            SettingVendor_Load(sender, e)
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If MsgBox("Save This Data ??", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.Yes Then
            AutoNumber()
            If ComboBox5.SelectedIndex = 0 Then
                Gender = "M"
            Else
                Gender = "F"
            End If
            If ComboBox6.SelectedIndex = 0 Then
                CmbIsAbsensi = 1
                CmbIsSales = 0
            ElseIf ComboBox6.SelectedIndex = 1 Then
                CmbIsSales = 1
                CmbIsAbsensi = 0
            Else
                CmbIsAbsensi = 1
                CmbIsSales = 1
            End If

            Select Case T_Edit
                Case 0
                    If ComboBox7.Visible = False Then
                        If TextBox3.Text = "" Then
                            MsgBox("Contact Name Is Null !!!")
                            Exit Sub
                        End If
                    End If
                    'If TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Then
                    '    If MsgBox("Data Contact is Not Complete, Keep Process ?!!!", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    '        TextBox4.Focus()
                    '        Exit Sub
                    '    End If
                    'End If
                    dsVendor = getSqldb2("select * from vendor where vendor_id ='" & ComboBox4.SelectedValue & "' And SBU = '" & ComboBox1.Text & "'")
                    If Not dsVendor.Tables(0).Rows.Count > 0 Then
                        getSqldb2("insert into Vendor (Vendor_Id ,Vendor_Name ,SBU ,OSDay, Deleted ,Upd_Date ) Values ('" & ComboBox4.SelectedValue & "','" & ComboBox4.Text & "','" & ComboBox1.Text & "','0','0',GETDATE())")
                    Else
                        'MsgBox("Vendor Is Already Exist !!!")
                        'Exit Sub
                    End If

                    dsBrand = getSqldb2("select * from brand where brand ='" & ComboBox3.SelectedValue & "'  and vendor_id ='" & ComboBox4.SelectedValue & "'")
                    If Not dsBrand.Tables(0).Rows.Count > 0 Then
                        getSqldb2("insert into Brand (Brand ,Vendor_Id,Department ,Deleted, upd_date) Values ('" & ComboBox3.SelectedValue & "','" & ComboBox4.SelectedValue & "','" & ComboBox2.Text & "','0',GETDATE ())")
                    Else
                        'MsgBox("Brand Is Already Exist For Vendor " & ComboBox3.SelectedValue & " !!!")
                    End If

                    If TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Then
                        If MsgBox("Data Contact is Not Complete ?!!!", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            TextBox4.Focus()
                            Exit Sub
                        End If
                    End If
                    If ComboBox7.Visible = False Then
                        getSqldb2("insert into Contact (Vendor_Id ,Contact_id,Contact_Name ,Email ,Position ,Gender ,Phone,Is_Absensi ,Is_Sales ,Flag ,Deleted ,Upd_Date)" & _
       "values('" & ComboBox4.SelectedValue & "','" & Auto & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & Gender & "','" & TextBox6.Text & "','" & CmbIsAbsensi & "','" & CmbIsSales & "','0','0',GETDATE ())")
                    Else
                        getSqldb2("Update Contact set Contact_Name = '" & ComboBox7.Text & "', Email = '" & TextBox4.Text & "',Position " & _
                                  " = '" & TextBox5.Text & "', Gender = '" & Gender & "',Phone = '" & TextBox6.Text & "', " & _
                                  "Is_Absensi = '" & CmbIsAbsensi & "', Is_Sales = '" & CmbIsSales & "',Upd_Date = '" & Now & "' Where Vendor_Id = '" & ComboBox4.SelectedValue & "' And Contact_id = '" & ComboBox7.SelectedValue & "'")
                    End If
                Case 1
                    dsBrand = getSqldb2("select * from brand where brand ='" & ComboBox3.SelectedValue & "'  and vendor_id ='" & ComboBox4.SelectedValue & "'")
                    If Not dsBrand.Tables(0).Rows.Count > 0 Then
                        getSqldb2("insert into Brand (Brand ,Vendor_Id,Department ,Deleted, upd_date) Values ('" & ComboBox3.SelectedValue & "','" & ComboBox4.SelectedValue & "','" & ComboBox2.Text & "','0',GETDATE ())")
                    Else
                        MsgBox("Brand Is Already Exist For Vendor " & ComboBox3.SelectedValue & " !!!")
                    End If
                Case 2
                    If TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Then
                        If MsgBox("Data Contact is Not Complete ?!!!", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            TextBox3.Focus()
                            Exit Sub
                        End If
                    End If
                    getSqldb2("insert into Contact (Vendor_Id ,Contact_id,Contact_Name ,Email ,Position ,Gender ,Phone,Is_Absensi ,Is_Sales ,Flag ,Deleted ,Upd_Date)" & _
        "values('" & ComboBox4.SelectedValue & "','" & Auto & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & Gender & "','" & TextBox6.Text & "','" & CmbIsAbsensi & "','" & CmbIsSales & "','0','0',GETDATE ())")
            End Select
            MsgBox("Saved !!!")
            SettingVendor_Load(sender, e)
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

End Class