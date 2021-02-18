Public Class FrmSelisihPDT

    Private Sub FrmSelisihPDT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        isiCboLocation()
        showTable(False)
        TampilTable2()
    End Sub
    Sub showTable(Optional ByVal tipe As Boolean = True, Optional ByVal plu As String = " (0=0) ")
        dg.Visible = tipe
        If tipe Then
            TampilTable(plu)
            dg.BringToFront()
        Else
            dg.DataSource = Nothing
        End If
    End Sub
    Sub isiCboLocation()
        CboLocation.Items.Clear()
        Dim dsc As DataSet
        dsc = QuerySO("select distinct location from tempoutput order by location")
        For Each ro As DataRow In dsc.Tables(0).Rows
            CboLocation.Items.Add(ro("location").ToString.Trim)
        Next
        dsc.Dispose()
    End Sub
    Sub TampilTable(Optional ByVal plu As String = " (0=0) ")
        Dim dsg As DataSet
        dsg = QuerySO("select plu, description, price from tempitem where (" & plu & ") order by plu")
        dg.AutoGenerateColumns = False
        dg.DataSource = dsg.Tables(0)
        dg.Columns(2).DefaultCellStyle.Format = "n" & CStr(0)
        dg.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub
    Sub TampilTable2()
        Dim dsg2 As DataSet
        dsg2 = QuerySO("select location, plu, max(jml) as qty from tempoutput2 group by location, plu order by location, plu")
        dg2.AutoGenerateColumns = False
        dg2.DataSource = dsg2.Tables(0)
        dg2.Columns(2).DefaultCellStyle.Format = "n" & CStr(0)
        dg2.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub
    Sub tampilDesc()
        Dim dss As DataSet
        dss = QuerySO("select plu, description, price, article, sbu from tempitem where plu='" & txtPLU.Text & "' ")
        If dss.Tables(0).Rows.Count > 0 Then
            txtDesc.Text = dss.Tables(0).Rows(0).Item("description").ToString.Trim
            txtPrice.Text = FormatNumber(dss.Tables(0).Rows(0).Item("price").ToString.Trim, 0)
            txtArticle.Text = dss.Tables(0).Rows(0).Item("article").ToString.Trim
            txtSBU.Text = dss.Tables(0).Rows(0).Item("sbu").ToString.Trim
            If dg.Visible Then dg.Focus()
        Else
            txtDesc.Clear()
            txtPrice.Clear()
            txtArticle.Clear()
            txtSBU.Clear()
        End If
        dss.Dispose()
    End Sub
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        SaveData()
    End Sub
    Sub SaveData()
        ExecSO("delete from tempoutput2 where location='" & CboLocation.Text.Trim & "' and plu='" & txtPLU.Text & "' ")
        ExecSO("insert into tempoutput2 values ('HO', '" & CboLocation.Text.Trim & "', '" & txtPLU.Text.Trim & "', '" & txtQty.Text.Trim & "', '" & txtTglSO.Text.Trim & "', '" & txtIDCompare.Text.Trim & "', 'Selisih')")
        ExecSO("insert into tempoutput2 values ('TK', '" & CboLocation.Text.Trim & "', '" & txtPLU.Text.Trim & "', '" & txtQty.Text.Trim & "', '" & txtTglSO.Text.Trim & "', '" & txtIDCompare.Text.Trim & "', 'Selisih')")
        TampilTable2()
        txtArticle.Clear()
        txtSBU.Clear()
        txtPLU.Clear()
        txtDesc.Clear()
        txtPrice.Clear()
        txtQty.Clear()
        txtPLU.Focus()
    End Sub
    Private Sub CboLocation_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboLocation.KeyDown
        If e.KeyCode = 13 Then
            txtPLU.Focus()
        End If
    End Sub

    Private Sub CboLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboLocation.SelectedIndexChanged

    End Sub

    Private Sub txtPLU_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPLU.KeyDown
        If e.KeyCode = 13 Then
            If dg.Visible Then
                txtPLU.Text = dg.Item(0, 0).Value.ToString.Trim
                showTable(False)
                txtQty.Focus()
            Else
                txtQty.Focus()
            End If
        ElseIf e.KeyCode = 27 Then
            showTable(False)
        ElseIf e.KeyCode = Keys.Down Then
            If dg.Visible Then
                dg.Focus()
            End If
        End If
    End Sub

    Private Sub txtPLU_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPLU.TextChanged
        If txtPLU.Text.Trim = "" Then
            showTable(False)
        Else
            showTable(True, " plu like '%" & txtPLU.Text & "%' ")
            tampilDesc()
        End If
    End Sub

    Private Sub txtQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQty.KeyDown
        If e.KeyCode = 13 Then
            SaveData()
        End If
    End Sub

    Private Sub txtQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQty.TextChanged

    End Sub

    Private Sub dg_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg.CellContentClick

    End Sub

    Private Sub dg_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg.CellContentDoubleClick
        txtPLU.Text = dg.Item(0, e.RowIndex).Value.ToString.Trim
        showTable(False)
        txtQty.Focus()
    End Sub

    Private Sub dg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dg.KeyDown
        If e.KeyCode = 13 Then
            txtPLU.Text = dg.Item(0, dg.CurrentRow.Index).Value.ToString.Trim
            showTable(False)
            txtQty.Focus()
        ElseIf e.KeyCode = 27 Then
            showTable(False)
            txtPLU.Focus()
        End If
    End Sub

    Private Sub dg2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg2.CellContentClick

    End Sub

    Private Sub dg2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dg2.KeyDown
        If e.KeyCode = 46 Then
            ExecSO("delete from tempoutput2 where location='" & dg2.Item(0, dg2.CurrentRow.Index).Value & "' and plu='" & dg2.Item(1, dg2.CurrentRow.Index).Value & "' ")
            TampilTable2()
        End If
    End Sub
    Sub deleteGrid()

    End Sub
End Class