Public Class OutStandingPO
    Dim dsv, dsv2 As New DataSet
    Dim EntryNo As String
    Private Sub OutStandingPO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetLv2()
        SetLv()
        dsv = getSqldb2("Select * from Vendor where SBU = '" & SbuCode & "' And OSDay > 0 ")
        If dsv.Tables(0).Rows.Count > 0 Then
            ComboBox1.Items.Add("*** All ***")
            ComboBox1.SelectedIndex = 0
            For Each ro As DataRow In dsv.Tables(0).Rows
                ComboBox1.Items.Add(ro("Vendor_Id") & " - " & ro("Vendor_Name"))
            Next
            ComboBox2.Items.Add("Line")
            ComboBox2.Items.Add("Status")
            ComboBox2.SelectedIndex = 0
            showlv(Microsoft.VisualBasic.Left(ComboBox1.Text, 5), dsv.Tables(0).Rows(0).Item("OSDay"))
        Else
            MsgBox("This SBU Don't Have Direct Brand !!!")
            Exit Sub
        End If
    End Sub

    Sub SetLv2()
        ListView1.Columns.Add("No", 60, HorizontalAlignment.Left)
        ListView1.Columns.Add("PO No", 180, HorizontalAlignment.Left)
        ListView1.Columns.Add("Entry", 60, HorizontalAlignment.Left)
        ListView1.Columns.Add("PO Date", 90, HorizontalAlignment.Left)
        ListView1.Columns.Add("Dev Date", 90, HorizontalAlignment.Left)
        ListView1.Columns.Add("R'Day", 50, HorizontalAlignment.Left)
    End Sub

    Sub SetLv()
        ListView2.Columns.Add("Line", 40, HorizontalAlignment.Left)
        ListView2.Columns.Add("Item Code", 90, HorizontalAlignment.Left)
        ListView2.Columns.Add("Description", 380, HorizontalAlignment.Left)
        ListView2.Columns.Add("Qty", 50, HorizontalAlignment.Left)
        ListView2.Columns.Add("Open Qty", 70, HorizontalAlignment.Left)
        ListView2.Columns.Add("Price", 90, HorizontalAlignment.Left)
        ListView2.Columns.Add("Status", 70, HorizontalAlignment.Left)
    End Sub

    Sub showlv(ByVal Vendor As String, ByVal day As Integer)
        Try
            Dim dsv As New DataSet
            Dim vendr As String = "XXXX"
            ListView1.Items.Clear()
            If Vendor = "*** A" Then
                dsv = getSqldb("Select cardCode,CardName,docEntry,DocNum,DocDate,DocDueDate from opor where DocStatus = 'O' And CardCode in (Select V_Co From VendorDirect_" & SbuCode & ")")
            Else
                dsv = getSqldb("Select cardCode,CardName,docEntry,DocNum,DocDate,DocDueDate from opor where DocStatus = 'O' And CardCode =  '" & Vendor & "'")
            End If
            Dim no As Integer = 0
            If dsv.Tables(0).Rows.Count > 0 Then

                For Each ro As DataRow In dsv.Tables(0).Rows

                    Dim str2(6) As String
                    Dim itm2 As ListViewItem
                    If vendr <> ro("cardCode") Then
                        If vendr <> "XXXX" Then
                            Dim str3(1) As String
                            Dim itm3 As ListViewItem
                            str3(0) = ""
                            itm3 = New ListViewItem(str3)
                            ListView1.Items.Add(itm3)
                        End If
                        Dim str(6) As String
                        Dim itm As ListViewItem
                        str(0) = ro("cardCode")
                        str(1) = ro("CardName")
                        itm = New ListViewItem(str)
                        ListView1.Items.Add(itm)
                        vendr = ro("cardCode")
                        itm.Font = New System.Drawing.Font _
 ("Tahoma", 9, System.Drawing.FontStyle.Bold)
                        no = 0
                    End If
                    no += 1
                    str2(0) = no
                    str2(1) = ro(3).ToString.Trim
                    str2(2) = ro(2).ToString.Trim
                    str2(3) = Format(CDate(ro(4).ToString.Trim), "dd MMM yyyy")
                    str2(4) = Format(CDate(ro(5).ToString.Trim), "dd MMM yyyy")
                    str2(5) = DateDiff(DateInterval.Day, Now, CDate(ro(5).ToString.Trim)) + day
                    itm2 = New ListViewItem(str2)
                    If itm2.SubItems(5).Text < 0 Then
                        itm2.ForeColor = System.Drawing.Color.DarkRed
                        itm2.Font = New System.Drawing.Font _
 ("Tahoma", 9, System.Drawing.FontStyle.Regular)
                    End If
                    ListView1.Items.Add(itm2)
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub showlv2(ByVal Entry As String, ByVal OrderBy As String)
        Try
            If ComboBox2.Text = "Line" Then
                OrderBy = " Order By lineNum"
            Else
                OrderBy = " Order By LineStatus"
            End If
            ListView2.Items.Clear()
            dsv2 = getSqldb("Select lineNum,LineStatus,ItemCode,Dscription,Quantity,OpenQty,price from por1 where docEntry = '" & Entry & "' " & OrderBy & "")
            If dsv2.Tables(0).Rows.Count > 0 Then
                Dim QtyTot, OqtyTot, PriceTot As Decimal
                QtyTot = 0
                PriceTot = 0
                For Each ro As DataRow In dsv2.Tables(0).Rows
                    Dim str2(6) As String
                    Dim itm2 As ListViewItem
                    str2(0) = ro(0).ToString.Trim
                    str2(1) = ro(2).ToString.Trim
                    str2(2) = ro(3).ToString.Trim
                    str2(3) = CInt(ro(4).ToString.Trim)
                    QtyTot += CInt(ro(4).ToString.Trim)
                    str2(4) = CInt(ro(5).ToString.Trim)
                    OqtyTot += CInt(ro(5).ToString.Trim)
                    str2(5) = CDec(ro(6).ToString.Trim).ToString("N0")
                    PriceTot += CDec(ro(6).ToString.Trim)
                    str2(6) = ro(1).ToString.Trim
                    itm2 = New ListViewItem(str2)
                    If itm2.SubItems(6).Text = "C" Then
                        'itm2.ForeColor = System.Drawing.Color.DarkGreen
                        itm2.Font = New System.Drawing.Font _
 ("Tahoma", 9, System.Drawing.FontStyle.Bold)
                    End If
                    ListView2.Items.Add(itm2)
                Next
                Dim str4(6) As String
                Dim itm4 As ListViewItem
                str4(4) = ""
                itm4 = New ListViewItem(str4)
                ListView2.Items.Add(itm4)
                Dim str3(6) As String
                Dim itm3 As ListViewItem
                str3(1) = "Total"
                str3(3) = CDec(QtyTot).ToString("N0")
                str3(4) = CDec(OqtyTot).ToString("N0")
                str3(5) = CDec(PriceTot).ToString("N0")
                itm3 = New ListViewItem(str3)
                itm3.Font = New System.Drawing.Font _
("Tahoma", 9, System.Drawing.FontStyle.Bold)
                ListView2.Items.Add(itm3)
                Dim str5(6) As String
                Dim itm5 As ListViewItem
                str5(1) = "Grand Total"
                str5(2) = CDec(QtyTot * PriceTot).ToString("N0")
                'str5(4) = CDec(OqtyTot).ToString("N0")
                'str5(5) = CDec(PriceTot).ToString("N0")
                itm5 = New ListViewItem(str5)
                itm5.Font = New System.Drawing.Font _
("Tahoma", 9, System.Drawing.FontStyle.Bold)
                ListView2.Items.Add(itm5)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        showlv(Microsoft.VisualBasic.Left(ComboBox1.Text, 5), dsv.Tables(0).Rows(0).Item("OSDay"))
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        'Dim objDrawingPoint As Drawing.Point
        'Dim objListViewItem As ListViewItem

        'objDrawingPoint = ListView1.PointToClient(Cursor.Position)

        'If Not IsNothing(objDrawingPoint) Then
        '    With objDrawingPoint
        '        objListViewItem = ListView1.GetItemAt(.X, .Y)
        '    End With

        '    If Not IsNothing(objListViewItem) Then
        '        MsgBox(objListViewItem.Text)
        '    End If
        'End If
        Dim I As Integer
        For I = 0 To ListView1.SelectedItems.Count - 1
            If ListView1.SelectedItems(I).SubItems(2).Text <> "" Then
                showlv2(ListView1.SelectedItems(I).SubItems(2).Text, " Order By " & ComboBox2.Text)
                EntryNo = ListView1.SelectedItems(I).SubItems(2).Text
            End If
            'MsgBox(ListView1.SelectedItems(I).SubItems(2).Text)
        Next

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        showlv2(EntryNo, " Order By " & ComboBox2.Text)
    End Sub
End Class