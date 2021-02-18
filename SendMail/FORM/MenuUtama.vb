Imports System.Windows.Forms

Public Class MenuUtama

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        Dim ChildForm As New System.Windows.Forms.Form
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Global.System.Windows.Forms.Application.Exit()
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticleToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer = 0

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmKPI.MdiParent = Me
        frmKPI.Show()
    End Sub

    Private Sub MenuUtama_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("Yakin Keluar dari Aplikasi?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            End
        Else
            e.Cancel = 1
        End If
    End Sub

    Private Sub MenuUtama_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ConnectServer()
        m_Sqlconn2 = "Provider=SQLOLEDB;" & _
        "Data Source=" & m_ServerName & _
        ";Initial Catalog=" & m_DBName & _
        ";User Id=" & m_UserName & _
        ";Password=" & m_Password
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmTarget.MdiParent = Me
        FrmTarget.Show()
    End Sub

    Private Sub tsKPI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsKPI.Click
        frmKPI.MdiParent = Me
        frmKPI.Show()
    End Sub

    Private Sub tsTarget_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsTarget.Click
        FrmTarget.MdiParent = Me
        FrmTarget.Show()
    End Sub

    Private Sub tsExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CServer.Close()
        End
    End Sub

    Private Sub tsCount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsCount.Click
        frmCount.MdiParent = Me
        frmCount.Show()
    End Sub

    Private Sub tsstorenobrand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsstorenobrand.Click
        ceknobrand.MdiParent = Me
        ceknobrand.Show()
    End Sub
End Class
