Imports System.Data
Imports System.Data.OleDb

Public Class frmCount

    Private Sub frmCount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetDG()
        setTime()
        Tglrev = Format(Now, "yyyy-MM-dd")
    End Sub

#Region "umum"
    Private Sub SetDG()
        With DG
            .Columns.Add("Floor", "Floor") : .Columns(0).Width = 50
            .Columns.Add("Trx_Count", "Trx_Count") : .Columns(1).Width = 100
            .Columns.Add("Code", "Code") : .Columns(2).Width = 50 : .Columns(2).Visible = False
        End With
    End Sub

    Private Sub setTime()
        Dim y As String
        Dim bln() As String = {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"}
        Dim month As Integer = Now.Month - 1
        Dim Month2 As Integer = Now.Month
        cmbMonth.Text = Month2 & " - " & bln(month)
        y = Now.Year

        For i As Integer = y - 1 To y
            cmbYear.Items.Add(i)
        Next

        With cmbMonth.Items
            .Add("1 - January")
            .Add("2 - February")
            .Add("3 - March")
            .Add("4 -April")
            .Add("5 - May")
            .Add("6 - June")
            .Add("7 - July")
            .Add("8 - August")
            .Add("9 - September")
            .Add("10 - October")
            .Add("11 - November")
            .Add("12 - December")
        End With
    End Sub

    Private Sub ElementSsave()
        strSQL = "select  isnull(max(convert(int,code ))+1,1) code from [@ST_TRANS]"
        cmd = New OleDbCommand(strSQL, CServer)
        DRNRd = cmd.ExecuteReader
        DRNRd.Read()
        Kode = DRNRd("Code")
        DRNRd.Close()

        sFloor = DG.Rows(i).Cells(0).Value
        sCount = DG.Rows(i).Cells(1).Value
    End Sub

    Private Sub Bersih()
        txtSite.Text = "" : DG.Rows.Clear()
    End Sub
#End Region

    Private Sub brnSite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles brnSite.Click
        frmStore.lblList.Text = "List Of Warehouses - Store Transaction Count"
        frmStore.ShowDialog()
    End Sub

    Private Sub DG_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellEndEdit
        For i As Integer = 0 To DG.Rows.Count - 1
            If e.ColumnIndex = 0 Then
                DG.AllowUserToAddRows = False
                DG.CurrentCell = DG.Rows(DG.Rows.Count - 1).Cells(1)
                DG.Rows(e.RowIndex).Cells(1).Value = "0"
            ElseIf e.ColumnIndex = 1 Then
                DG.AllowUserToAddRows = True
                DG.CurrentCell = DG.Item(0, i + 1)
            End If
        Next
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If txtSite.Text = "" Then MessageBox.Show("Site harus diisi", "Oops") : txtSite.Focus() : Exit Sub
        If cmbMonth.Text = "" Then MessageBox.Show("Bulan harus diisi", "Oops") : cmbMonth.Focus() : Exit Sub
        If cmbYear.Text = "" Then MessageBox.Show("Tahun harus diisi", "Oops") : cmbYear.Focus() : Exit Sub
        DG.AllowUserToAddRows = False
        For i As Integer = 0 To DG.Rows.Count - 1

            strSQL = "SELECT Code, Name, U_Store, U_TRMonth, U_TRYear, U_TRFloor, U_TRCount, U_CreateBy, U_CreateDate FROM [@ST_TRANS] where u_store='" & txtSite.Text & "' and U_TRYear ='" & cmbYear.Text & "' and U_TRMonth='" & Microsoft.VisualBasic.Left(cmbMonth.Text, 2) & "' and U_TRFloor ='" & DG.Rows(i).Cells(0).Value & "'"
            cmd = New OleDbCommand(strSQL, CServer)
            DRTran = cmd.ExecuteReader
            ElementSsave()
            If DRTran.Read Then
                strSQL = "update[@ST_TRANS]  set U_TRFloor='" & sFloor & "', U_TRCount='" & sCount & "' where  u_store='" & txtSite.Text & "' and U_TRYear ='" & cmbYear.Text & "' and U_TRMonth='" & Microsoft.VisualBasic.Left(cmbMonth.Text, 2) & "' and U_TRFloor ='" & DG.Rows(i).Cells(0).Value & "' "
                ExecQuery(strSQL)
            Else

                strSQL = "insert into [@ST_TRANS]( Code, Name, U_Store, U_TRMonth, U_TRYear, U_TRFloor, U_TRCount, U_CreateBy, U_CreateDate)" & _
                    " values('" & Kode & "','" & Kode & "','" & txtSite.Text & "','" & Microsoft.VisualBasic.Left(cmbMonth.Text, 2) & "','" & cmbYear.Text & "', " & _
                    " '" & sFloor & "','" & sCount & "', '" & "cdm1" & "','" & Tglrev & "')"
                ExecQuery(strSQL)
            End If
            DRTran.Close()
        Next
        MessageBox.Show("Data sudah disimpan", "oops")
        Bersih()
        DG.AllowUserToAddRows = True
    End Sub
End Class