Imports System.Data
Imports System.Data.OleDb

Public Class frmStore

    Private Sub frmStore_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        setLV()
        Tampil()
    End Sub

#Region "umum"

    Private Sub setLV()
        With LV.Columns
            .Add("Branch ID", 100)
            .Add("Branch Name", 300)
        End With
    End Sub

    Private Sub Tampil()
        strSQL = "select CardCode,CardName  from ocrd where left(cardcode,1)='S'"
        cmd = New OleDbCommand(strSQL, CServer)
        DRBranch = cmd.ExecuteReader
        LV.Items.Clear()
        Do While DRBranch.Read
            Lis = New ListViewItem(DRBranch("cardcode").ToString)
            Lis.SubItems.Add(DRBranch("cardname").ToString)
            LV.Items.Add(Lis)
        Loop
    End Sub

    Private Sub Choose()
        Try
            If LV.Items.Count > 0 Then
                If lblList.Text = "List Of Warehouses - KPI" Then
                    frmKPI.txtSite.Text = LV.FocusedItem.Text
                End If

                If lblList.Text = "List Of Warehouses - Sales Target" Then
                    FrmTarget.txtSite.Text = LV.FocusedItem.Text
                End If

                If lblList.Text = "List Of Warehouses - Store Transaction Count" Then
                    frmCount.txtSite.Text = LV.FocusedItem.Text
                End If

                If lblList.Text = "List of Warehouses - Store Cek Brand" Then
                    ceknobrand.txtStore.Text = LV.FocusedItem.Text
                End If
            End If
        Catch ex As Exception

        End Try
        Me.Close()
    End Sub

#End Region

#Region "Navigasi"
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoose.Click
        Choose()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
#End Region


    Private Sub LV_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LV.SelectedIndexChanged

    End Sub
End Class