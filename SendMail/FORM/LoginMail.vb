Public Class LoginMail
    Dim ds As New DataSet
    Dim dsParam As New DataSet
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Me.Close()
        Application.Exit()
    End Sub

    Private Sub LoginMail_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub LoginMail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ConnectServer()
        m_Sqlconn = "Data Source=" & m_ServerName & ";" & "Initial Catalog=" & m_DBName & ";" & "User ID=" & m_UserName & ";" & "Password=" & m_Password & ";"
        m_Sqlconn2 = "Data Source=" & m_ServerName2 & ";" & "Initial Catalog=" & m_DBName2 & ";" & "User ID=" & m_UserName2 & ";" & "Password=" & m_Password2 & ";"
        'm_Sqlconn3 = "Data Source=" & m_ServerName3 & ";" & "Initial Catalog=" & m_DBName3 & ";" & "User ID=" & m_UserName3 & ";" & "Password=" & m_Password3 & ";"

        isiVariableGlobal()
        'TextBox1.Text = Encrypt("star")

        'TextBox1.Text = "admin"
        'TextBox2.Text = "123"

        'TextBox1.Text = "9010"
        'TextBox2.Text = "0205"

        TextBox1.Text = "2024"
        TextBox2.Text = "3009"

        TextBox1.Text = "1150"
        TextBox2.Text = "4589"

        TextBox1.Clear()
        TextBox2.Clear()


        ConnectServer()
        m_Sqlconn = "Data Source=" & m_ServerName & ";" & "Initial Catalog=" & m_DBName & ";" & "User ID=" & m_UserName & ";" & "Password=" & m_Password & ";"
        m_Sqlconn2 = "Data Source=" & m_ServerName2 & ";" & "Initial Catalog=" & m_DBName2 & ";" & "User ID=" & m_UserName2 & ";" & "Password=" & m_Password2 & ";"
        'm_Sqlconn3 = "Data Source=" & m_ServerName3 & ";" & "Initial Catalog=" & m_DBName3 & ";" & "User ID=" & m_UserName3 & ";" & "Password=" & m_Password3 & ";"
        
        isiVariableGlobal()
        'TextBox1.Text = "admin"
        'TextBox2.Text = "123"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If (Not System.IO.Directory.Exists(m_Path & "DataMail")) Then
            System.IO.Directory.CreateDirectory(m_Path & "DataMail")
        End If
        If (Not System.IO.Directory.Exists(m_Path & "DataMail\BackUp")) Then
            System.IO.Directory.CreateDirectory(m_Path & "DataMail\BackUp")
        End If
        If TextBox1.Text = "" Then
            MsgBox("Insert UserId First!!")
            Exit Sub
            TextBox1.Focus()
        End If

        Dim xx As String
        xx = LCase(ReadIni("SETTING_BARCODE", "WHSCODE"))
        If LCase(ReadIni("SETTING_BARCODE", "PROGRAMBARCODE")) = "yes" Then
            If xx = "s001" Then
                OpenDB_POSSERVERHISTORY_S001()
            ElseIf xx = "s002" Then
                OpenDB_POSSERVERHISTORY_S002()
            ElseIf xx = "s003" Then
                OpenDB_POSSERVERHISTORY_S003()
            End If
            ds = Query("select * from users where user_id='" & TextBox1.Text & "' and password='" & TextBox2.Text & "' ")
            If ds.Tables(0).Rows.Count > 0 Then
                UsrID = ds.Tables(0).Rows(0).Item("User_ID").ToString.Trim
                UsrName = ds.Tables(0).Rows(0).Item("User_Name").ToString.Trim
                UserLogin = UsrName
                'SbuCode = ds.Tables(0).Rows(0).Item("Sbu").ToString.Trim
                'GrpId = ds.Tables(0).Rows(0).Item("Group_ID").ToString.Trim
                'MyEmail = ds.Tables(0).Rows(0).Item("Email").ToString.Trim
                Sec_Lev = ds.Tables(0).Rows(0).Item("Security_Level").ToString.Trim
                dsForm = getSqldb2("select * from Group_Users where GroupID = '8'")
                TextBox2.Clear()
                Me.Hide()
                FormMain.Show()
                BarcodeForm.MdiParent = FormMain
                BarcodeForm.Show()
                FormMain.Visible = False
                FormMain.Visible = True
            Else
                MsgBox("UserID Failed!!", MsgBoxStyle.Exclamation, "Attention")
                TextBox1.Focus()
                Exit Sub
            End If
        Else
            ds = getSqldb2("Select User_ID,Password,User_Name,Sbu,Group_ID,Email,Security_Level " & vbCrLf & _
                       "from Users Where User_ID = '" & TextBox1.Text & "' And Deleted = '0'")
            If ds.Tables(0).Rows.Count > 0 Then
                If Decrypt(ds.Tables(0).Rows(0).Item("Password").ToString.Trim) = TextBox2.Text Then
                    UsrID = ds.Tables(0).Rows(0).Item("User_ID").ToString.Trim
                    UsrName = ds.Tables(0).Rows(0).Item("User_Name").ToString.Trim
                    UserLogin = UsrName
                    SbuCode = ds.Tables(0).Rows(0).Item("Sbu").ToString.Trim
                    GrpId = ds.Tables(0).Rows(0).Item("Group_ID").ToString.Trim
                    MyEmail = ds.Tables(0).Rows(0).Item("Email").ToString.Trim
                    Sec_Lev = ds.Tables(0).Rows(0).Item("Security_Level").ToString.Trim
                    dsForm = getSqldb2("select * from Group_Users where GroupID = '" & GrpId & "'")
                    TextBox2.Clear()
                    Me.Hide()
                    FormMain.Show()
                Else
                    MsgBox("Password Failed!!", MsgBoxStyle.Exclamation, "Attention")
                    TextBox2.Focus()
                    Exit Sub
                End If
            Else
                MsgBox("Username / Password Not Found!!", MsgBoxStyle.Exclamation, "Attention")
                TextBox2.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Change_Password.Show()
        If TextBox1.Text <> "" Then
            Change_Password.TextBox1.Text = TextBox1.Text
            Change_Password.TextBox2.Focus()
        End If

    End Sub

    Private Sub Label1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.MouseHover
        Label1.Font = New Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
    End Sub

    Private Sub Label1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.MouseLeave
        Label1.Font = New Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Italic)
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
    Dim TextToBePrinted As String
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        prt("tes", "EPSON LQ-310 ESC/P2")
    End Sub
    Public Sub prt(ByVal text As String, ByVal printer As String)
        TextToBePrinted = text
        Dim prn As New Printing.PrintDocument
        Using (prn)
            prn.PrinterSettings.PrinterName = printer
            AddHandler prn.PrintPage, _
               AddressOf Me.PrintPageHandler
            prn.Print()
            RemoveHandler prn.PrintPage, _
               AddressOf Me.PrintPageHandler
        End Using
    End Sub

    Private Sub PrintPageHandler(ByVal sender As Object, _
       ByVal args As Printing.PrintPageEventArgs)
        Dim myFont As New Font("Courier New", 9)
        args.Graphics.DrawString(TextToBePrinted, _
           New Font(myFont, FontStyle.Regular), _
           Brushes.Black, 50, 50)
    End Sub
End Class