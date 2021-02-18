Imports System.Text
Imports System.Text.RegularExpressions
Public Class LookupForm

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Close()
    End Sub
    Sub LoadImage()
        Dim ico As New System.Drawing.Icon(FolderImage & "star.ico") : Me.Icon = ico
        'BtnSave.Image = Image.FromFile(FolderImage & "save16.png")
        'BtnReload.Image = Image.FromFile(FolderImage & "reload16.png")
        'BtnDateTemplate.Image = Image.FromFile(FolderImage & "date16.png")
        'BtnPrint.Image = Image.FromFile(FolderImage & "print16.png")
        'BtnMenu.Image = Image.FromFile(FolderImage & "menu16.png")
        'BtnAdd.Image = Image.FromFile(FolderImage & "add16.png")
        'BtnEdit.Image = Image.FromFile(FolderImage & "edit16.png")
        Button1.Image = Image.FromFile(FolderImage & "ok16.png")
        BtnClose.Image = Image.FromFile(FolderImage & "close16.png")
    End Sub
    Private Sub LookupForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadImage()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        dg.Item("choose", dg.CurrentRow.Index).Value = 1
    End Sub

    Private Sub LookupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If txtisi.Text.Trim = "" Then Exit Sub
        Dim nama As String = ""
        Dim words As String()
        Dim word As String
        'MsgBox(txtisi.Text)
        words = SplitWords(Replace(txtisi.Text, "'", ""), ";")
        For x = 0 To dg.Rows.Count - 1
            dg.Item("choose", x).Value = 0
            nama = LCase(dg.Item(1, x).Value.ToString.Trim)
            For Each word In words
                word = LCase(word)
                'Dbg("word : " & word & vbCrLf & _
                '    "nama : " & nama)
                If word = nama Then
                    dg.Item("choose", x).Value = 1
                End If
            Next
        Next

        Cursor = Cursors.Default
    End Sub

    Private Sub dg_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub dg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        
    End Sub
    Private Sub RefreshGrid(Optional ByVal syarat As String = "")
        'Dim ds As DataSet
        'Dim sql As String
        'sql = txtSQL.Text
        'ReplaceString(txtSQL.Text, "$syarat", syarat)
        'ds = getSqldb(sql)
        'With dg
        '    .DataSource = Nothing
        '    .DataSource = ds
        '    .Refresh()
        'End With
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Dim s As String
        s = String.Format(dg.Columns(2).Name & " Like '%" & TextBox1.Text) & "%'"
        BindingSource1.Filter = s
    End Sub

    Private Sub dg_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg.CellContentClick
        If CInt(dg.Item(0, dg.CurrentRow.Index).Value) = 1 Then
            dg.Item(0, dg.CurrentRow.Index).Value = 0
        Else
            dg.Item(0, dg.CurrentRow.Index).Value = 1
        End If
    End Sub

    Private Sub dg_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg.CellContentDoubleClick
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub dg_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dg.KeyDown
        If e.KeyCode = Keys.Enter Then
            DialogResult = Windows.Forms.DialogResult.OK
        End If
        If e.KeyCode = Keys.Escape Then
            DialogResult = Windows.Forms.DialogResult.Cancel
        End If
    End Sub
End Class