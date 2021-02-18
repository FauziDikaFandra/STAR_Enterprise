Public Class Report

    Private Sub Report_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            SendMailForm.Label4.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Report_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class