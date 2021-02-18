<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BKForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label75 = New System.Windows.Forms.Label
        Me.Label76 = New System.Windows.Forms.Label
        Me.txtNoBK = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.DtTglBK = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtVendor = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtTerbilang = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtAmount = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtBank = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.dtTglGiro = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtNoGiro = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.BtnSave = New System.Windows.Forms.Button
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtID = New System.Windows.Forms.TextBox
        Me.BtnCariVendor = New System.Windows.Forms.Button
        Me.txtVendorID = New System.Windows.Forms.Label
        Me.BtnPrint = New System.Windows.Forms.Button
        Me.txtNoTerima = New System.Windows.Forms.Label
        Me.BtnBuat = New System.Windows.Forms.Button
        Me.BtnCari = New System.Windows.Forms.Button
        Me.BtnDelete = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label75
        '
        Me.Label75.BackColor = System.Drawing.Color.PowderBlue
        Me.Label75.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label75.Location = New System.Drawing.Point(617, 10)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(11, 21)
        Me.Label75.TabIndex = 241
        Me.Label75.Text = ":"
        Me.Label75.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label76
        '
        Me.Label76.BackColor = System.Drawing.Color.PowderBlue
        Me.Label76.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label76.Location = New System.Drawing.Point(571, 10)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(57, 21)
        Me.Label76.TabIndex = 238
        Me.Label76.Text = "No. BK"
        Me.Label76.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNoBK
        '
        Me.txtNoBK.BackColor = System.Drawing.SystemColors.Window
        Me.txtNoBK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNoBK.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoBK.Location = New System.Drawing.Point(634, 10)
        Me.txtNoBK.MaxLength = 1000
        Me.txtNoBK.Name = "txtNoBK"
        Me.txtNoBK.Size = New System.Drawing.Size(171, 21)
        Me.txtNoBK.TabIndex = 239
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.PowderBlue
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(617, 34)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(11, 21)
        Me.Label18.TabIndex = 240
        Me.Label18.Text = ":"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.PowderBlue
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(571, 36)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(57, 21)
        Me.Label24.TabIndex = 236
        Me.Label24.Text = "Tgl BK"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DtTglBK
        '
        Me.DtTglBK.CustomFormat = "ddd, dd-MMM-yyyy"
        Me.DtTglBK.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtTglBK.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtTglBK.Location = New System.Drawing.Point(634, 36)
        Me.DtTglBK.Name = "DtTglBK"
        Me.DtTglBK.ShowCheckBox = True
        Me.DtTglBK.Size = New System.Drawing.Size(171, 21)
        Me.DtTglBK.TabIndex = 237
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.PowderBlue
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 21)
        Me.Label1.TabIndex = 242
        Me.Label1.Text = "PT. Star Maju Sentosa"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.PowderBlue
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(743, 21)
        Me.Label2.TabIndex = 243
        Me.Label2.Text = "BANK PAYMENT VOUCHER"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.PowderBlue
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(129, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 21)
        Me.Label3.TabIndex = 246
        Me.Label3.Text = ":"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.PowderBlue
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 21)
        Me.Label4.TabIndex = 244
        Me.Label4.Text = "Payment To"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtVendor
        '
        Me.txtVendor.BackColor = System.Drawing.SystemColors.Window
        Me.txtVendor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendor.Location = New System.Drawing.Point(146, 87)
        Me.txtVendor.MaxLength = 1000
        Me.txtVendor.Name = "txtVendor"
        Me.txtVendor.Size = New System.Drawing.Size(370, 21)
        Me.txtVendor.TabIndex = 245
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.PowderBlue
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 111)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(124, 21)
        Me.Label5.TabIndex = 247
        Me.Label5.Text = "Amount in Words"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.PowderBlue
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(129, 111)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(11, 21)
        Me.Label6.TabIndex = 249
        Me.Label6.Text = ":"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTerbilang
        '
        Me.txtTerbilang.BackColor = System.Drawing.SystemColors.Window
        Me.txtTerbilang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTerbilang.Enabled = False
        Me.txtTerbilang.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTerbilang.Location = New System.Drawing.Point(146, 113)
        Me.txtTerbilang.MaxLength = 1000
        Me.txtTerbilang.Name = "txtTerbilang"
        Me.txtTerbilang.Size = New System.Drawing.Size(659, 21)
        Me.txtTerbilang.TabIndex = 248
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.PowderBlue
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(617, 85)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(11, 21)
        Me.Label7.TabIndex = 252
        Me.Label7.Text = ":"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.PowderBlue
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(561, 85)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 21)
        Me.Label8.TabIndex = 250
        Me.Label8.Text = "Amount"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAmount
        '
        Me.txtAmount.BackColor = System.Drawing.SystemColors.Window
        Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.Location = New System.Drawing.Point(634, 87)
        Me.txtAmount.MaxLength = 1000
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(171, 21)
        Me.txtAmount.TabIndex = 251
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.PowderBlue
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(129, 137)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(11, 21)
        Me.Label9.TabIndex = 255
        Me.Label9.Text = ":"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.PowderBlue
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(14, 137)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 21)
        Me.Label10.TabIndex = 253
        Me.Label10.Text = "Bank"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBank
        '
        Me.txtBank.BackColor = System.Drawing.SystemColors.Window
        Me.txtBank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBank.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBank.Location = New System.Drawing.Point(146, 139)
        Me.txtBank.MaxLength = 1000
        Me.txtBank.Name = "txtBank"
        Me.txtBank.Size = New System.Drawing.Size(172, 21)
        Me.txtBank.TabIndex = 254
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.PowderBlue
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(617, 137)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(11, 21)
        Me.Label11.TabIndex = 258
        Me.Label11.Text = ":"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.PowderBlue
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(561, 139)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 21)
        Me.Label12.TabIndex = 256
        Me.Label12.Text = "Tgl Giro"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtTglGiro
        '
        Me.dtTglGiro.CustomFormat = "ddd, dd-MMM-yyyy"
        Me.dtTglGiro.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtTglGiro.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtTglGiro.Location = New System.Drawing.Point(634, 139)
        Me.dtTglGiro.Name = "dtTglGiro"
        Me.dtTglGiro.ShowCheckBox = True
        Me.dtTglGiro.Size = New System.Drawing.Size(171, 21)
        Me.dtTglGiro.TabIndex = 257
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.PowderBlue
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(370, 137)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(11, 21)
        Me.Label13.TabIndex = 261
        Me.Label13.Text = ":"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.PowderBlue
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(324, 137)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(52, 21)
        Me.Label14.TabIndex = 259
        Me.Label14.Text = "No. Giro"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNoGiro
        '
        Me.txtNoGiro.BackColor = System.Drawing.SystemColors.Window
        Me.txtNoGiro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNoGiro.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoGiro.Location = New System.Drawing.Point(384, 139)
        Me.txtNoGiro.MaxLength = 1000
        Me.txtNoGiro.Name = "txtNoGiro"
        Me.txtNoGiro.Size = New System.Drawing.Size(171, 21)
        Me.txtNoGiro.TabIndex = 260
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.PowderBlue
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(129, 164)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(11, 21)
        Me.Label15.TabIndex = 264
        Me.Label15.Text = ":"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDescription
        '
        Me.txtDescription.BackColor = System.Drawing.SystemColors.Window
        Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(146, 166)
        Me.txtDescription.MaxLength = 1000
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(659, 78)
        Me.txtDescription.TabIndex = 263
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.PowderBlue
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(14, 164)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(124, 21)
        Me.Label16.TabIndex = 262
        Me.Label16.Text = "Description"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnSave
        '
        Me.BtnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.Color.Red
        Me.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSave.Location = New System.Drawing.Point(741, 250)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(64, 24)
        Me.BtnSave.TabIndex = 265
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.PowderBlue
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(39, 34)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(11, 21)
        Me.Label17.TabIndex = 268
        Me.Label17.Text = ":"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.PowderBlue
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(14, 35)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(31, 21)
        Me.Label19.TabIndex = 266
        Me.Label19.Text = "ID"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtID
        '
        Me.txtID.BackColor = System.Drawing.SystemColors.Window
        Me.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtID.Location = New System.Drawing.Point(56, 35)
        Me.txtID.MaxLength = 1000
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(82, 21)
        Me.txtID.TabIndex = 267
        '
        'BtnCariVendor
        '
        Me.BtnCariVendor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCariVendor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCariVendor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCariVendor.ForeColor = System.Drawing.Color.Red
        Me.BtnCariVendor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCariVendor.Location = New System.Drawing.Point(522, 84)
        Me.BtnCariVendor.Name = "BtnCariVendor"
        Me.BtnCariVendor.Size = New System.Drawing.Size(33, 24)
        Me.BtnCariVendor.TabIndex = 269
        Me.BtnCariVendor.Text = "..."
        Me.BtnCariVendor.UseVisualStyleBackColor = True
        '
        'txtVendorID
        '
        Me.txtVendorID.BackColor = System.Drawing.Color.PowderBlue
        Me.txtVendorID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendorID.Location = New System.Drawing.Point(143, 63)
        Me.txtVendorID.Name = "txtVendorID"
        Me.txtVendorID.Size = New System.Drawing.Size(100, 21)
        Me.txtVendorID.TabIndex = 270
        Me.txtVendorID.Text = "Vendor Code"
        Me.txtVendorID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnPrint
        '
        Me.BtnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPrint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.ForeColor = System.Drawing.Color.Red
        Me.BtnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPrint.Location = New System.Drawing.Point(671, 250)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(64, 24)
        Me.BtnPrint.TabIndex = 271
        Me.BtnPrint.Text = "&Print"
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'txtNoTerima
        '
        Me.txtNoTerima.BackColor = System.Drawing.Color.PowderBlue
        Me.txtNoTerima.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoTerima.Location = New System.Drawing.Point(17, 223)
        Me.txtNoTerima.Name = "txtNoTerima"
        Me.txtNoTerima.Size = New System.Drawing.Size(74, 21)
        Me.txtNoTerima.TabIndex = 272
        Me.txtNoTerima.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnBuat
        '
        Me.BtnBuat.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBuat.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBuat.ForeColor = System.Drawing.Color.Red
        Me.BtnBuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuat.Location = New System.Drawing.Point(79, 253)
        Me.BtnBuat.Name = "BtnBuat"
        Me.BtnBuat.Size = New System.Drawing.Size(71, 24)
        Me.BtnBuat.TabIndex = 274
        Me.BtnBuat.Text = "&Create"
        Me.BtnBuat.UseVisualStyleBackColor = True
        '
        'BtnCari
        '
        Me.BtnCari.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCari.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCari.ForeColor = System.Drawing.Color.Red
        Me.BtnCari.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCari.Location = New System.Drawing.Point(17, 253)
        Me.BtnCari.Name = "BtnCari"
        Me.BtnCari.Size = New System.Drawing.Size(56, 24)
        Me.BtnCari.TabIndex = 273
        Me.BtnCari.Text = "&Find"
        Me.BtnCari.UseVisualStyleBackColor = True
        '
        'BtnDelete
        '
        Me.BtnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDelete.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDelete.ForeColor = System.Drawing.Color.Red
        Me.BtnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDelete.Location = New System.Drawing.Point(591, 251)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(74, 24)
        Me.BtnDelete.TabIndex = 275
        Me.BtnDelete.Text = "&Delete"
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'BKForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PowderBlue
        Me.ClientSize = New System.Drawing.Size(817, 285)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.BtnBuat)
        Me.Controls.Add(Me.BtnCari)
        Me.Controls.Add(Me.txtNoTerima)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.txtVendorID)
        Me.Controls.Add(Me.BtnCariVendor)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtNoGiro)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.dtTglGiro)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtBank)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtTerbilang)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtVendor)
        Me.Controls.Add(Me.Label75)
        Me.Controls.Add(Me.Label76)
        Me.Controls.Add(Me.txtNoBK)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.DtTglBK)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BKForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bank Payment Voucher"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents txtNoBK As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents DtTglBK As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtVendor As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTerbilang As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtBank As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dtTglGiro As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtNoGiro As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents BtnCariVendor As System.Windows.Forms.Button
    Friend WithEvents txtVendorID As System.Windows.Forms.Label
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents txtNoTerima As System.Windows.Forms.Label
    Friend WithEvents BtnBuat As System.Windows.Forms.Button
    Friend WithEvents BtnCari As System.Windows.Forms.Button
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
End Class
