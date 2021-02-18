Public Class FormMain
    Dim dsGrpPromo As New DataSet
    Dim dsParam As New DataSet
    Private Sub FormMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        LoginMail.Show()
        LoginMail.TextBox2.Focus()
    End Sub


    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub FormMain_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        Refresh()
    End Sub

    Private Sub FormMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For Each mnuitem As ToolStripMenuItem In MenuStrip1.Items
            mnuitem.Visible = False
        Next

        dsParam = getSqldb2("Select * from Parameters")
        If dsParam.Tables(0).Rows.Count > 0 Then
            For Each ro As DataRow In dsParam.Tables(0).Rows
                Select Case ro("Code")
                    Case Is = "SMTP"
                        P_SMTP = ro("Description")
                    Case Is = "FROM"
                        P_FROM = ro("Description")
                    Case Is = "PASS"
                        P_PASS = ro("Description")
                    Case Is = "MYEMA"
                        P_MYEMA = ro("Description")
                End Select
            Next
        End If

        If dsForm.Tables(0).Rows.Count > 0 Then
            For Each ro As DataRow In dsForm.Tables(0).Rows
                For Each mnuitem As ToolStripMenuItem In MenuStrip1.Items
                    If mnuitem.Name = ro("FormDetail").ToString Then
                        mnuitem.Visible = True
                        'Else
                        '    mnuitem.Visible = False
                        '    'GoTo 1
                    End If
                    'For Each mnuitemdetail As ToolStripMenuItem In mnuitem.DropDownItems
                    '    If mnuitemdetail.Name = ro("FormDetail").ToString Then
                    '        mnuitemdetail.Visible = False
                    '        GoTo 2
                    '    End If
                    'Next
                    '2:
                Next
                '1:
            Next
        End If
        ToolStripMenuItem1.Visible = True
        ToolStripStatusLabel2.Spring = True
        ToolStripStatusLabel1.Text = "User : " & UsrName
        Timer1.Enabled = True
        getSqldb("IF OBJECT_ID('dbo.VendorDirect_" & SbuCode & "', 'U') IS NOT NULL DROP TABLE dbo.VendorDirect_" & SbuCode & "")
        getSqldb("CREATE TABLE VendorDirect_" & SbuCode & " (V_Co varchar(15),V_Name varchar(80),V_Ex Integer,V_Sbu varchar(2))")
        VendorList2()
        PromoGrpUsr = ""
        If GrpId = "6" Then
            dsGrpPromo = getSqldb2("select * from Group_Parameters where ID = '" & UsrID & "'")
            If dsGrpPromo.Tables(0).Rows.Count > 0 Then
                For Each ro As DataRow In dsGrpPromo.Tables(0).Rows
                    PromoGrpUsr &= "'" & ro("Value") & "',"
                Next
                PromoGrpUsr = Mid(PromoGrpUsr, 1, PromoGrpUsr.Length - 1)
            End If
        End If
    End Sub

    Sub VendorList2()
        Dim dsv As New DataSet
        dsv = getSqldb2("Select Vendor_Id From Vendor Where SBU = '" & SbuCode & "'  And OSDay > 0")
        For Each ro As DataRow In dsv.Tables(0).Rows
            Try
                getSqldb("Insert Into VendorDirect_" & SbuCode & " (V_Co) Values ('" & ro("Vendor_Id") & "')")
            Catch ex As Exception

            End Try
        Next
    End Sub
    Sub VendorList()
        Dim FILE_NAME As String = "VendorDirect.txt"
        Dim objReader As New System.IO.StreamReader(FILE_NAME)
        Dim LineOfText As String = Nothing
        Dim Aryline(1) As String
        Dim c As New ArrayList
        Do While objReader.Peek() <> -1
            LineOfText = objReader.ReadLine() & vbNewLine
            Aryline = LineOfText.Split(",")
            Try
                getSqldb2("Insert Into VendorDirect_PO2 Values ('" & Microsoft.VisualBasic.Left(Aryline(0), 15) & "','" & Replace(Microsoft.VisualBasic.Left(Aryline(1), 80), "'", "") & "','" & Microsoft.VisualBasic.Left(Aryline(2), 15).ToString.Trim & "','" & Microsoft.VisualBasic.Left(Aryline(3), 2).ToString.Trim & "')")
            Catch ex As Exception

            End Try
        Loop
        objReader.Close()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel3.Text = Now.ToString
    End Sub

    Private Sub SendMailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SendMailForm.MdiParent = Me
        SendMailForm.Show()
    End Sub

    Private Sub LogMailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Log_Mail.MdiParent = Me
        Log_Mail.Show()
    End Sub

    Private Sub UserSettingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        UserForm.MdiParent = Me
        UserForm.Show()
    End Sub

    Private Sub VendorSettingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SettingVendor.MdiParent = Me
        SettingVendor.Show()
    End Sub

    Private Sub POOutStandingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        OutStandingPO.MdiParent = Me
        OutStandingPO.Show()
    End Sub

    Private Sub SettingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingToolStripMenuItem.Click

    End Sub

    Private Sub SendMailToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SendToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendToolStripMenuItem.Click
        SendMailForm.MdiParent = Me
        SendMailForm.Show()
    End Sub

    Private Sub LogToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogToolStripMenuItem.Click
        Log_Mail.MdiParent = Me
        Log_Mail.Show()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        OutStandingPO.MdiParent = Me
        OutStandingPO.Show()
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        SettingVendor.MdiParent = Me
        SettingVendor.Show()
    End Sub

    Private Sub SAPToPDTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAPToPDTToolStripMenuItem.Click
        SAPToPDT.MdiParent = Me
        SAPToPDT.Show()
    End Sub

    Private Sub ProcessStockSAPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcessStockSAPToolStripMenuItem.Click
        ProcessStockSAP.MdiParent = Me
        ProcessStockSAP.Show()
    End Sub

    Private Sub CompareSOPDTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompareSOPDTToolStripMenuItem.Click
        CompareSOSAP.MdiParent = Me
        CompareSOSAP.Show()
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click

    End Sub

    Private Sub TransakToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransakToolStripMenuItem.Click
        TerimaTableOK.MdiParent = Me
        TerimaTableOK.Show()
        MenuStrip1.Visible = False
        MenuStrip1.Visible = True
    End Sub

    Private Sub CheckVoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckVoucherToolStripMenuItem.Click
        frmcekvoucher.MdiParent = Me
        frmcekvoucher.Show()
    End Sub

    Private Sub AnalyzerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnalyzerToolStripMenuItem.Click
        analyzer.MdiParent = Me
        analyzer.Show()
    End Sub

    Private Sub KPIToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmKPI.MdiParent = Me
        frmKPI.Show()
    End Sub

    Private Sub TargetToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmTarget.MdiParent = Me
        FrmTarget.Show()
    End Sub

    Private Sub CheckKPIForSalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ceknobrand.MdiParent = Me
        ceknobrand.Show()
    End Sub

    Private Sub CountToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmCount.MdiParent = Me
        frmCount.Show()
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        
    End Sub

    Private Sub MnEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnEmployee.Click
        EmployeeTable.MdiParent = Me
        EmployeeTable.Show()
        MenuStrip1.Visible = False
        MenuStrip1.Visible = True
    End Sub

    Private Sub MnLeaveS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnLeaveS.Click
        SummaryCutiTable.MdiParent = Me
        SummaryCutiTable.Show()
        MenuStrip1.Visible = False
        MenuStrip1.Visible = True
    End Sub

    Private Sub MnLeaveT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnLeaveT.Click
        LeaveTable.MdiParent = Me
        LeaveTable.Show()
        MenuStrip1.Visible = False
        MenuStrip1.Visible = True
    End Sub

    Private Sub MnAttendanceG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnAttendanceG.Click
        'GenerateForm.MdiParent = Me
        'GenerateForm.Show()
        MenuStrip1.Visible = False
        MenuStrip1.Visible = True
    End Sub

    Private Sub MnAttendanceC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnAttendanceC.Click
        CorrectionAbsenForm.MdiParent = Me
        CorrectionAbsenForm.Show()
        MenuStrip1.Visible = False
        MenuStrip1.Visible = True
    End Sub

    Private Sub MnAttendanceS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnAttendanceS.Click
        AbsenSummary.MdiParent = Me
        AbsenSummary.Show()
        MenuStrip1.Visible = False
        MenuStrip1.Visible = True
    End Sub

    Private Sub BKToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BKToolStripMenuItem.Click
        BKForm.MdiParent = Me
        BKForm.Show()
        MenuStrip1.Visible = False
        MenuStrip1.Visible = True
    End Sub

    Private Sub FingerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FingerToolStripMenuItem.Click
        'FrmFinger.MdiParent = Me
        'FrmFinger.Show()
        MenuStrip1.Visible = False
        MenuStrip1.Visible = True
    End Sub

    Private Sub HistoryPromoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HistoryPromoToolStripMenuItem.Click
        History_Promo.MdiParent = Me
        History_Promo.Show()
    End Sub

    Private Sub InputPromoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InputPromoToolStripMenuItem.Click
        Promo_Form.MdiParent = Me
        Promo_Form.Show()
    End Sub

    Private Sub ToolStripMenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem10.Click
        frmKPI.MdiParent = Me
        frmKPI.Show()
    End Sub

    Private Sub ToolStripMenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem11.Click
        FrmTarget.MdiParent = Me
        FrmTarget.Show()
    End Sub

    Private Sub ToolStripMenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem12.Click
        frmListKPI.MdiParent = Me
        frmListKPI.Show()
    End Sub

    Private Sub ToolStripMenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem13.Click
        frmCount.MdiParent = Me
        frmCount.Show()
    End Sub
End Class