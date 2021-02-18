Imports System.Data
Imports System.Data.OleDb

Public Class frmListKPI

#Region "umum"
    Private Sub Tampil()
        If Label1.Text = "Find - KPI" Then
            strSQL = "select u_revno,convert(varchar(11),U_CreateDate,100)  tgl,u_store,u_revdate,U_RevName from [@st_kpih] order by convert(int,u_revno)"
            cmd = New OleDbCommand(strSQL, CServer)
            DRlKPI = cmd.ExecuteReader
            LV.Items.Clear()
            Do While DRlKPI.Read
                Lis = New ListViewItem(DRlKPI("u_revno").ToString)
                Lis.SubItems.Add(DRlKPI("tgl").ToString)
                Lis.SubItems.Add(DRlKPI("u_store").ToString)
                Lis.SubItems.Add(DRlKPI("U_RevName").ToString)
                LV.Items.Add(Lis)
            Loop
        End If

        If Label1.Text = "Find - Sales Target" Then
            strSQL = "select u_revno,convert(varchar(11),U_CreateDate,100)  tgl,u_store,u_revdate,U_RevName from [@ST_STARGETH]  order by convert(int,u_revno)"
            cmd = New OleDbCommand(strSQL, CServer)
            DRlKPI = cmd.ExecuteReader
            LV.Items.Clear()
            Do While DRlKPI.Read
                Lis = New ListViewItem(DRlKPI("u_revno").ToString)
                Lis.SubItems.Add(DRlKPI("tgl").ToString)
                Lis.SubItems.Add(DRlKPI("u_store").ToString)
                Lis.SubItems.Add(DRlKPI("U_RevName").ToString)
                LV.Items.Add(Lis)
            Loop
        End If
    End Sub

    Private Sub setLV()
        With LV
            .Columns.Add("No", 40)
            .Columns.Add("Date", 80)
            .Columns.Add("Site", 70)
            .Columns.Add("Rev Name", 200)
        End With
    End Sub

    Private Sub Choose()
        Try
            If Label1.Text = "Find - KPI" Then
                If LV.Items.Count > 0 Then
                    strSQL = "select Code,Name,U_RevNo,U_LineNo,U_SBU,U_Dep,U_Brn,LEFT(U_Sqm, 5) as sql,LEFT(U_Sqmgross, 5) as sql2,u_floor from [@st_kpid] where U_RevNo ='" & LV.FocusedItem.Text & "'"
                    cmd = New OleDbCommand(strSQL, CServer)
                    DRKPI = cmd.ExecuteReader
                    frmKPI.DG.Rows.Clear()
                    Do While DRKPI.Read
                        frmKPI.DG.Rows.Add(DRKPI("U_LineNo"), DRKPI("U_SBU"), DRKPI("U_Dep"), DRKPI("U_Brn"), DRKPI("sql"), DRKPI("sql2"), DRKPI("u_floor"), DRKPI("Code"))
                    Loop
                    DRKPI.Close()
                End If
            Else
                strSQL = "SELECT Code, Name, U_RevNo, U_LineNo, U_SBU, U_Dep, U_Brn, U_Jan, U_Feb, U_Mar, U_Apr, U_May, U_Jun, U_Jul, U_Aug, U_Sep, U_Oct, U_Nov, U_Dec FROm [@ST_STARGETD] where U_RevNo ='" & LV.FocusedItem.Text & "'"
                cmd = New OleDbCommand(strSQL, CServer)
                DRKPI = cmd.ExecuteReader
                FrmTarget.DG.Rows.Clear()
                Do While DRKPI.Read
                    FrmTarget.DG.Rows.Add(DRKPI("U_LineNo"), DRKPI("U_SBU"), DRKPI("U_Dep"), DRKPI("U_Brn"), DRKPI("U_Jan"), DRKPI("U_Feb"), DRKPI("U_Mar"), DRKPI("U_Apr"), DRKPI("U_May"), DRKPI("U_Jun"), DRKPI("U_Jul"), DRKPI("U_Aug"), DRKPI("U_Sep"), DRKPI("U_Oct"), DRKPI("U_Nov"), DRKPI("U_Dec"))
                Loop
                FrmTarget.Label10.Text = FrmTarget.DG.RowCount
            End If
        Catch ex As Exception

        End Try
        Me.Close()
    End Sub
#End Region

    Private Sub frmListKPI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        setLV()
        Tampil()
    End Sub

    Private Sub btnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoose.Click
        Choose()
        'If frmKPI.DG.Rows.Count = 0 Then
        '    frmKPI.btnCopy.Enabled = False
        'Else
        '    frmKPI.btnCopy.Enabled = True
        'End If
    End Sub

    Private Sub btnColse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColse.Click
        Me.Close()
    End Sub
End Class

