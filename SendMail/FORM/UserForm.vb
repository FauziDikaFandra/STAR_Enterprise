Imports System.Text.RegularExpressions
Public Class UserForm
    Dim dsUser As New DataSet
    Dim stt As Boolean = True
    Dim sl As Integer
    Private Sub UserForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmb1()
        cmb2()
        cmb(ComboBox4, "select name as Code,Cast(descriptio as varchar(50))as Description  from OHTM  Order by name", "Code", "Description", 1)
        showdg()
        TextBox1.Focus()
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
    Sub showdg()
        dsUser = getSqldb2("select USER_ID,User_Name,SBU,Password,case when Security_Level = 0 Then 'Administrator' Else 'User' End As Security_Level,case when Group_ID = 0 Then 'Administrator' Else 'User' End As Group_ID,Email from Users Where Deleted = '0'")
        If dsUser.Tables(0).Rows.Count > 0 Then
            DataGridView1.DataSource = dsUser.Tables(0)
            DataGridView1.Columns("User_Id").Visible = False
            DataGridView1.Columns("Password").Visible = False
            'DataGridView1.Refresh()
        End If
    End Sub
    Sub cmb1()
        Dim c As New ArrayList
        c.Add(New CCombo("0", "Administrator"))
        c.Add(New CCombo("1", "User"))

        With ComboBox1
            .DataSource = c
            .DisplayMember = "Number_Name"
            .ValueMember = "ID"
        End With
    End Sub

    Sub cmb2()
        Dim c As New ArrayList
        c.Add(New CCombo("0", "Administrator"))
        c.Add(New CCombo("1", "User"))

        With ComboBox2
            .DataSource = c
            .DisplayMember = "Number_Name"
            .ValueMember = "ID"
        End With
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            stt = False
            TextBox1.Text = DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value.ToString.Trim
            TextBox2.Text = DataGridView1.Item(1, DataGridView1.CurrentRow.Index).Value.ToString.Trim
            TextBox3.Text = Decrypt(DataGridView1.Item(3, DataGridView1.CurrentRow.Index).Value)
            ComboBox4.SelectedValue = DataGridView1.Item(2, DataGridView1.CurrentRow.Index).Value
            Cek(DataGridView1.Item(4, DataGridView1.CurrentRow.Index).Value)
            ComboBox1.SelectedValue = sl.ToString
            Cek(DataGridView1.Item(5, DataGridView1.CurrentRow.Index).Value)
            ComboBox2.SelectedValue = sl.ToString
            TextBox1.Enabled = False
            TextBox4.Text = DataGridView1.Item(6, DataGridView1.CurrentRow.Index).Value
            TextBox2.Focus()
        Catch ex As Exception
            TextBox1.Focus()
        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        clear()
    End Sub

    Sub Cek(ByVal ck As String)
        If ck = "Administrator" Then
            sl = 0
        Else
            sl = 1
        End If
    End Sub

    Sub clear()
        stt = True
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        ComboBox1.SelectedValue = "0"
        ComboBox2.SelectedValue = "0"
        ComboBox4.SelectedValue = "1"
        TextBox1.Enabled = True
        TextBox1.Focus()
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text = "" Then
                MsgBox("Insert User Id !!!!")
                TextBox1.Focus()
                Exit Sub
            End If

            If TextBox2.Text = "" Then
                MsgBox("Insert User Name!!!!")
                TextBox2.Focus()
                Exit Sub
            End If

            If TextBox3.Text = "" Then
                MsgBox("Insert Password!!!!")
                TextBox3.Focus()
                Exit Sub
            End If

            If TextBox4.Text = "" Then
                MsgBox("Insert Email Address!!!!")
                TextBox4.Focus()
                Exit Sub
            End If

            If stt = True Then
                getSqldb2("Insert Into Users Values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & Encrypt(TextBox3.Text) & "','" & TextBox4.Text & "','" & ComboBox4.SelectedValue & "','" & ComboBox1.SelectedValue & "','" & ComboBox2.SelectedValue & "',0)")
            Else
                getSqldb2("Update Users Set User_Name = '" & TextBox2.Text & "',Password = '" & Encrypt(TextBox3.Text) & "',Email = '" & TextBox4.Text & "',SBU = '" & ComboBox4.SelectedValue & "',Security_Level = '" & ComboBox1.SelectedValue & "',Group_Id = '" & ComboBox2.SelectedValue & "' Where User_Id = '" & TextBox1.Text & "'")
            End If
            MsgBox("Successfull")
            clear()
            showdg()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        If TextBox2.Text <> "" Then
            Me.ErrorProvider1.SetError(Me.TextBox4, _
               SingleEmailValid(Me.TextBox4.Text))
        End If

    End Sub
End Class