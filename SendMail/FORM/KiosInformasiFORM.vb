Public Class KiosInformasiFORM
    Sub LoadImage()
        Dim ico As New System.Drawing.Icon(FolderImage & "star.ico") : Me.Icon = ico
        PictureBox1.Image = Image.FromFile(FolderImage & "logon.png")
    End Sub

    Private Sub KiosInformasiFORM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        KeyDownMenu(e)
    End Sub
    Private Sub KiosInformasiFORM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        isiVariableGlobal()
        LoadImage()
        Rbt1.Checked = True
        Timer1.Enabled = True
        GroupBox1.Focus()
        TextBox1.Focus()
    End Sub
    Sub KeyDownMenu(ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.F1 Then
            Rbt1.Checked = True
        ElseIf e.KeyCode = Keys.F2 Then
            Rbt2.Checked = True
        ElseIf e.KeyCode = Keys.F3 Then
            Rbt3.Checked = True
        ElseIf e.KeyCode = Keys.F4 Then
            Rbt4.Checked = True
        ElseIf e.KeyCode = Keys.F5 Then
            Rbt5.Checked = True
        End If
        TextBox1.Focus()
    End Sub
    Sub ProcessLogin()
        If TextBox1.Text = "" Then
            MsgError("Insert SPG Id First!!")
            TextBox1.Focus()
            Exit Sub
        End If
        Dim barcode As String
        barcode = TextBox1.Text

        Dim xPOS, xPOSH, xSAP, xABS As String
        xPOS = LCase(ReadIni("SETTING_KIOSINFORMASI", "POS"))
        xPOSH = LCase(ReadIni("SETTING_KIOSINFORMASI", "POSH"))
        xABS = LCase(ReadIni("SETTING_KIOSINFORMASI", "ABS"))
        xSAP = LCase(ReadIni("SETTING_KIOSINFORMASI", "SAP"))
        DB_SAP = StrConX(xSAP)
        If xPOS = "posserver_s001" Then : DB_POS = StrConX("POSSERVER_S001")
        ElseIf xPOS = "posserver_s002" Then : DB_POS = StrConX("POSSERVER_S002")
        ElseIf xPOS = "posserver_s003" Then : DB_POS = StrConX("POSSERVER_S003") : End If
        If xPOSH = "posserverhistory_s001" Then : DB_POSH = StrConX("POSSERVERHISTORY_S001")
        ElseIf xPOSH = "posserverhistory_s002" Then : DB_POSH = StrConX("POSSERVERHISTORY_S002")
        ElseIf xPOSH = "posserverhistory_s003" Then : DB_POSH = StrConX("POSSERVERHISTORY_S003") : End If
        If xABS = "abs_s001" Then : DB_ABS = StrConX("ABS_S001")
        ElseIf xABS = "abs_s002" Then : DB_ABS = StrConX("ABS_S002")
        ElseIf xABS = "abs_s003" Then : DB_ABS = StrConX("ABS_S003") : End If

        strCon_Global = DB_POSH
        Dim vq As New VQuery
        vq.Query("select * from branches", "branch_id", DB_POSH)
        Whs = ""
        If vq.RecordCount > 0 Then Whs = vq.GetField("branch_id")
        vq.Query("select * from SPG where spg_barcode= '" & barcode & "'", "spg_id", DB_POS)
        If vq.RecordCount > 0 Then
            UsrID = vq.GetField("spg_id")
            UsrName = vq.GetField("spg_name")
            vq.Query("Select * from SPG_dtl where spg_id = '" & UsrID & "'", _
                     "spg_id,brand", DB_POS)
            SbuCode = ""
            If vq.RecordCount > 0 Then SbuCode = vq.GetField("sbu")
            TextBox1.Clear()
            Me.Hide()
            If Rbt1.Checked Then
                VendorSalesForm.Show()
            ElseIf Rbt2.Checked Then
                SPGSalesForm.ByBrand = False
                SPGSalesForm.Show()
            ElseIf Rbt3.Checked Then
                SPGSalesForm.ByBrand = True
                SPGSalesForm.Show()
            ElseIf Rbt4.Checked Then
                CrossSalesFORM.Show()
            ElseIf Rbt5.Checked Then
                CheckAbsensiSPGFORM.Show()
            End If
        Else
            MsgError("Barcode Tidak Terdaftar")
            TextBox1.Clear()
            TextBox1.Focus()
            vq.Dispose()
            Exit Sub
        End If
        vq.Dispose()
    End Sub
    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        KeyDownMenu(e)
        If e.KeyCode = 13 Then
            ProcessLogin()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub GroupBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GroupBox1.KeyDown
        KeyDownMenu(e)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        TextBox1.Clear()
    End Sub

    Private Sub Rbt1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rbt1.CheckedChanged
        TextBox1.Focus()
    End Sub
    Private Sub Rbt2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rbt2.CheckedChanged
        TextBox1.Focus()
    End Sub
    Private Sub Rbt3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rbt3.CheckedChanged
        TextBox1.Focus()
    End Sub
    Private Sub Rbt4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rbt4.CheckedChanged
        TextBox1.Focus()
    End Sub
    Private Sub Rbt5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rbt5.CheckedChanged
        TextBox1.Focus()
    End Sub
End Class