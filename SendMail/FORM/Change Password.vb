Public Class Change_Password
    Dim ds As New DataSet

    Private Sub Change_Password_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            LoginMail.Show()
            LoginMail.TextBox1.Focus()
        End If
    End Sub
    Private Sub Change_Password_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Insert UserId First!!")
            TextBox1.Focus()
            Exit Sub
        End If

        If TextBox2.Text = "" Then
            MsgBox("Insert Old Password!!")
            TextBox2.Focus()
            Exit Sub
        End If

        If TextBox3.Text = "" Then
            MsgBox("Insert New Password!!")
            TextBox3.Focus()
            Exit Sub
        End If

        ds = getSqldb2("Select User_ID,Password,User_Name,Sbu,Group_ID,Email from Users  Where User_ID = '" & TextBox1.Text & "' And Deleted = '0'")
        If ds.Tables(0).Rows.Count > 0 Then
            If Decrypt(ds.Tables(0).Rows(0).Item("Password").ToString.Trim) = TextBox2.Text Then
                getSqldb2("Update Users Set Password = '" & Encrypt(TextBox3.Text) & "' Where User_Id = '" & TextBox1.Text & "'")
                LoginMail.TextBox1.Text = TextBox1.Text
                LoginMail.TextBox2.Text = TextBox3.Text
                Me.Close()
                LoginMail.Show()
                LoginMail.TextBox1.Focus()
            Else
                MsgBox("Wrong Password!!")
                TextBox2.Clear()
                TextBox2.Focus()
                Exit Sub
            End If
        End If
    End Sub
End Class