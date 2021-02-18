Public Class FrmPesan

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Clipboard.Clear()
        Clipboard.SetText(txtPesan.Text)
        MsgOK("Copied to Clipboard")
    End Sub

    Private Sub txtPesan_Invalidated(ByVal sender As Object, ByVal e As System.Windows.Forms.InvalidateEventArgs) Handles txtPesan.Invalidated

    End Sub

    Private Sub txtPesan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPesan.KeyDown
        If e.KeyCode = 13 Then
            Close()
        End If
    End Sub

    Private Sub txtPesan_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPesan.TextChanged

    End Sub

    Private Sub FrmPesan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim ico As New System.Drawing.Icon(LokasiICOFile) : Me.Icon = ico
        'Button1.Image = Image.FromFile(FolderImage & "ok16.png")
        'Button2.Image = Image.FromFile(FolderImage & "copy16.png")
        'PictureBox1.Image = Image.FromFile(FolderImage & "information100.png")

    End Sub
End Class