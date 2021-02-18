<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTglBayar
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
        Me.Label68 = New System.Windows.Forms.Label
        Me.Label71 = New System.Windows.Forms.Label
        Me.txtNoGiro = New System.Windows.Forms.TextBox
        Me.Label75 = New System.Windows.Forms.Label
        Me.Label76 = New System.Windows.Forms.Label
        Me.txtNoteBayar = New System.Windows.Forms.TextBox
        Me.Label72 = New System.Windows.Forms.Label
        Me.Label73 = New System.Windows.Forms.Label
        Me.txtNoBK = New System.Windows.Forms.TextBox
        Me.CboTipeBayar = New System.Windows.Forms.ComboBox
        Me.Label69 = New System.Windows.Forms.Label
        Me.Label70 = New System.Windows.Forms.Label
        Me.cbRevisi = New System.Windows.Forms.CheckBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.DtTglBayar = New System.Windows.Forms.DateTimePicker
        Me.BtnSaveKW = New System.Windows.Forms.Button
        Me.txtNoTerima = New System.Windows.Forms.Label
        Me.lblTambahDK = New System.Windows.Forms.Label
        Me.lblFileName = New System.Windows.Forms.Label
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtRemarksKW = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtPotongan = New System.Windows.Forms.TextBox
        Me.RbtBK = New System.Windows.Forms.RadioButton
        Me.RbtGiro1 = New System.Windows.Forms.RadioButton
        Me.RbtGiro3 = New System.Windows.Forms.RadioButton
        Me.RbtGiro2 = New System.Windows.Forms.RadioButton
        Me.RbtLain = New System.Windows.Forms.RadioButton
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.txtVendorID = New System.Windows.Forms.Label
        Me.txtVendor = New System.Windows.Forms.Label
        Me.txtTotalTagihan = New System.Windows.Forms.Label
        Me.cbxIsDirect = New System.Windows.Forms.CheckBox
        Me.BtnPrintBK = New System.Windows.Forms.Button
        Me.txtbkid = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label68
        '
        Me.Label68.BackColor = System.Drawing.Color.PowderBlue
        Me.Label68.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label68.Location = New System.Drawing.Point(110, 121)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(11, 21)
        Me.Label68.TabIndex = 238
        Me.Label68.Text = ":"
        Me.Label68.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label71
        '
        Me.Label71.BackColor = System.Drawing.Color.PowderBlue
        Me.Label71.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label71.Location = New System.Drawing.Point(8, 121)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(83, 21)
        Me.Label71.TabIndex = 8
        Me.Label71.Text = "No. Giro"
        Me.Label71.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNoGiro
        '
        Me.txtNoGiro.BackColor = System.Drawing.SystemColors.Window
        Me.txtNoGiro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNoGiro.Location = New System.Drawing.Point(138, 121)
        Me.txtNoGiro.MaxLength = 1000
        Me.txtNoGiro.Name = "txtNoGiro"
        Me.txtNoGiro.ReadOnly = True
        Me.txtNoGiro.Size = New System.Drawing.Size(220, 20)
        Me.txtNoGiro.TabIndex = 9
        '
        'Label75
        '
        Me.Label75.BackColor = System.Drawing.Color.PowderBlue
        Me.Label75.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label75.Location = New System.Drawing.Point(110, 64)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(11, 21)
        Me.Label75.TabIndex = 235
        Me.Label75.Text = ":"
        Me.Label75.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label76
        '
        Me.Label76.BackColor = System.Drawing.Color.PowderBlue
        Me.Label76.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label76.Location = New System.Drawing.Point(8, 64)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(83, 21)
        Me.Label76.TabIndex = 4
        Me.Label76.Text = "Note Bayar"
        Me.Label76.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNoteBayar
        '
        Me.txtNoteBayar.BackColor = System.Drawing.SystemColors.Window
        Me.txtNoteBayar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNoteBayar.Location = New System.Drawing.Point(138, 64)
        Me.txtNoteBayar.MaxLength = 1000
        Me.txtNoteBayar.Name = "txtNoteBayar"
        Me.txtNoteBayar.Size = New System.Drawing.Size(220, 20)
        Me.txtNoteBayar.TabIndex = 5
        '
        'Label72
        '
        Me.Label72.BackColor = System.Drawing.Color.PowderBlue
        Me.Label72.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label72.Location = New System.Drawing.Point(110, 92)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(11, 21)
        Me.Label72.TabIndex = 234
        Me.Label72.Text = ":"
        Me.Label72.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label73
        '
        Me.Label73.BackColor = System.Drawing.Color.PowderBlue
        Me.Label73.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label73.Location = New System.Drawing.Point(8, 92)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(83, 21)
        Me.Label73.TabIndex = 6
        Me.Label73.Text = "No. BK"
        Me.Label73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNoBK
        '
        Me.txtNoBK.BackColor = System.Drawing.SystemColors.Window
        Me.txtNoBK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNoBK.Location = New System.Drawing.Point(138, 92)
        Me.txtNoBK.MaxLength = 1000
        Me.txtNoBK.Name = "txtNoBK"
        Me.txtNoBK.ReadOnly = True
        Me.txtNoBK.Size = New System.Drawing.Size(220, 20)
        Me.txtNoBK.TabIndex = 7
        '
        'CboTipeBayar
        '
        Me.CboTipeBayar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CboTipeBayar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CboTipeBayar.FormattingEnabled = True
        Me.CboTipeBayar.Items.AddRange(New Object() {"Invoice", "Surat Jalan", "Faktur Pajak", "Copy Purchase Order", "Copy Good Receipt"})
        Me.CboTipeBayar.Location = New System.Drawing.Point(138, 36)
        Me.CboTipeBayar.Name = "CboTipeBayar"
        Me.CboTipeBayar.Size = New System.Drawing.Size(220, 21)
        Me.CboTipeBayar.TabIndex = 3
        '
        'Label69
        '
        Me.Label69.BackColor = System.Drawing.Color.PowderBlue
        Me.Label69.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label69.Location = New System.Drawing.Point(8, 37)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(86, 21)
        Me.Label69.TabIndex = 2
        Me.Label69.Text = "Tipe Bayar"
        Me.Label69.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label70
        '
        Me.Label70.BackColor = System.Drawing.Color.PowderBlue
        Me.Label70.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label70.Location = New System.Drawing.Point(108, 36)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(15, 21)
        Me.Label70.TabIndex = 233
        Me.Label70.Text = ":"
        Me.Label70.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbRevisi
        '
        Me.cbRevisi.AutoSize = True
        Me.cbRevisi.Location = New System.Drawing.Point(138, 336)
        Me.cbRevisi.Name = "cbRevisi"
        Me.cbRevisi.Size = New System.Drawing.Size(55, 17)
        Me.cbRevisi.TabIndex = 15
        Me.cbRevisi.Text = "Revisi"
        Me.cbRevisi.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.PowderBlue
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(110, 8)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(11, 21)
        Me.Label18.TabIndex = 227
        Me.Label18.Text = ":"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.PowderBlue
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(8, 10)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(83, 21)
        Me.Label24.TabIndex = 0
        Me.Label24.Text = "Tgl Bayar"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DtTglBayar
        '
        Me.DtTglBayar.CustomFormat = "ddd, dd-MMM-yyyy"
        Me.DtTglBayar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtTglBayar.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtTglBayar.Location = New System.Drawing.Point(138, 10)
        Me.DtTglBayar.Name = "DtTglBayar"
        Me.DtTglBayar.ShowCheckBox = True
        Me.DtTglBayar.Size = New System.Drawing.Size(220, 21)
        Me.DtTglBayar.TabIndex = 1
        '
        'BtnSaveKW
        '
        Me.BtnSaveKW.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSaveKW.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSaveKW.ForeColor = System.Drawing.Color.Red
        Me.BtnSaveKW.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSaveKW.Location = New System.Drawing.Point(299, 332)
        Me.BtnSaveKW.Name = "BtnSaveKW"
        Me.BtnSaveKW.Size = New System.Drawing.Size(59, 24)
        Me.BtnSaveKW.TabIndex = 16
        Me.BtnSaveKW.Text = "&Save"
        Me.BtnSaveKW.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSaveKW.UseVisualStyleBackColor = True
        '
        'txtNoTerima
        '
        Me.txtNoTerima.AutoSize = True
        Me.txtNoTerima.BackColor = System.Drawing.Color.PowderBlue
        Me.txtNoTerima.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoTerima.Location = New System.Drawing.Point(12, 359)
        Me.txtNoTerima.Name = "txtNoTerima"
        Me.txtNoTerima.Size = New System.Drawing.Size(64, 13)
        Me.txtNoTerima.TabIndex = 239
        Me.txtNoTerima.Text = "No Terima"
        Me.txtNoTerima.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTambahDK
        '
        Me.lblTambahDK.AutoSize = True
        Me.lblTambahDK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblTambahDK.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTambahDK.ForeColor = System.Drawing.Color.Red
        Me.lblTambahDK.Location = New System.Drawing.Point(8, 337)
        Me.lblTambahDK.Name = "lblTambahDK"
        Me.lblTambahDK.Size = New System.Drawing.Size(72, 13)
        Me.lblTambahDK.TabIndex = 14
        Me.lblTambahDK.Text = "Upload Giro"
        Me.lblTambahDK.Visible = False
        '
        'lblFileName
        '
        Me.lblFileName.BackColor = System.Drawing.Color.PowderBlue
        Me.lblFileName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFileName.Location = New System.Drawing.Point(8, 385)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(83, 21)
        Me.lblFileName.TabIndex = 15
        Me.lblFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblFileName.Visible = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Title = "STAR APP - Open Dialog"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.PowderBlue
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(108, 143)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(11, 21)
        Me.Label15.TabIndex = 244
        Me.Label15.Text = ":"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.PowderBlue
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(8, 143)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(83, 21)
        Me.Label17.TabIndex = 10
        Me.Label17.Text = "Remarks"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRemarksKW
        '
        Me.txtRemarksKW.BackColor = System.Drawing.SystemColors.Window
        Me.txtRemarksKW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemarksKW.Location = New System.Drawing.Point(138, 228)
        Me.txtRemarksKW.MaxLength = 1000
        Me.txtRemarksKW.Multiline = True
        Me.txtRemarksKW.Name = "txtRemarksKW"
        Me.txtRemarksKW.Size = New System.Drawing.Size(220, 73)
        Me.txtRemarksKW.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.PowderBlue
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(110, 307)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 21)
        Me.Label1.TabIndex = 247
        Me.Label1.Text = ":"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.PowderBlue
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 307)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 21)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Potongan"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPotongan
        '
        Me.txtPotongan.BackColor = System.Drawing.SystemColors.Window
        Me.txtPotongan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPotongan.Location = New System.Drawing.Point(138, 307)
        Me.txtPotongan.MaxLength = 1000
        Me.txtPotongan.Name = "txtPotongan"
        Me.txtPotongan.Size = New System.Drawing.Size(220, 20)
        Me.txtPotongan.TabIndex = 13
        '
        'RbtBK
        '
        Me.RbtBK.AutoSize = True
        Me.RbtBK.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbtBK.Location = New System.Drawing.Point(138, 147)
        Me.RbtBK.Name = "RbtBK"
        Me.RbtBK.Size = New System.Drawing.Size(72, 17)
        Me.RbtBK.TabIndex = 248
        Me.RbtBK.TabStop = True
        Me.RbtBK.Text = "Proses BK"
        Me.RbtBK.UseVisualStyleBackColor = True
        '
        'RbtGiro1
        '
        Me.RbtGiro1.AutoSize = True
        Me.RbtGiro1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbtGiro1.Location = New System.Drawing.Point(138, 170)
        Me.RbtGiro1.Name = "RbtGiro1"
        Me.RbtGiro1.Size = New System.Drawing.Size(79, 17)
        Me.RbtGiro1.TabIndex = 249
        Me.RbtGiro1.TabStop = True
        Me.RbtGiro1.Text = "Proses Giro"
        Me.RbtGiro1.UseVisualStyleBackColor = True
        '
        'RbtGiro3
        '
        Me.RbtGiro3.AutoSize = True
        Me.RbtGiro3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbtGiro3.Location = New System.Drawing.Point(239, 170)
        Me.RbtGiro3.Name = "RbtGiro3"
        Me.RbtGiro3.Size = New System.Drawing.Size(121, 17)
        Me.RbtGiro3.TabIndex = 251
        Me.RbtGiro3.TabStop = True
        Me.RbtGiro3.Text = "Giro Belum Dicairkan"
        Me.RbtGiro3.UseVisualStyleBackColor = True
        '
        'RbtGiro2
        '
        Me.RbtGiro2.AutoSize = True
        Me.RbtGiro2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbtGiro2.Location = New System.Drawing.Point(239, 147)
        Me.RbtGiro2.Name = "RbtGiro2"
        Me.RbtGiro2.Size = New System.Drawing.Size(100, 17)
        Me.RbtGiro2.TabIndex = 250
        Me.RbtGiro2.TabStop = True
        Me.RbtGiro2.Text = "Giro Sudah Siap"
        Me.RbtGiro2.UseVisualStyleBackColor = True
        '
        'RbtLain
        '
        Me.RbtLain.AutoSize = True
        Me.RbtLain.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbtLain.Location = New System.Drawing.Point(138, 205)
        Me.RbtLain.Name = "RbtLain"
        Me.RbtLain.Size = New System.Drawing.Size(62, 17)
        Me.RbtLain.TabIndex = 252
        Me.RbtLain.TabStop = True
        Me.RbtLain.Text = "Lainnya"
        Me.RbtLain.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Red
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(11, 170)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(108, 24)
        Me.Button1.TabIndex = 253
        Me.Button1.Text = "&Cari BK / Giro"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Red
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(11, 200)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(108, 24)
        Me.Button2.TabIndex = 254
        Me.Button2.Text = "&Buat BK / Giro"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtVendorID
        '
        Me.txtVendorID.AutoSize = True
        Me.txtVendorID.BackColor = System.Drawing.Color.PowderBlue
        Me.txtVendorID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendorID.Location = New System.Drawing.Point(137, 359)
        Me.txtVendorID.Name = "txtVendorID"
        Me.txtVendorID.Size = New System.Drawing.Size(63, 13)
        Me.txtVendorID.TabIndex = 255
        Me.txtVendorID.Text = "Vendor ID"
        Me.txtVendorID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtVendor
        '
        Me.txtVendor.AutoSize = True
        Me.txtVendor.BackColor = System.Drawing.Color.PowderBlue
        Me.txtVendor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVendor.Location = New System.Drawing.Point(137, 393)
        Me.txtVendor.Name = "txtVendor"
        Me.txtVendor.Size = New System.Drawing.Size(47, 13)
        Me.txtVendor.TabIndex = 256
        Me.txtVendor.Text = "Vendor"
        Me.txtVendor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalTagihan
        '
        Me.txtTotalTagihan.AutoSize = True
        Me.txtTotalTagihan.BackColor = System.Drawing.Color.PowderBlue
        Me.txtTotalTagihan.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalTagihan.Location = New System.Drawing.Point(236, 393)
        Me.txtTotalTagihan.Name = "txtTotalTagihan"
        Me.txtTotalTagihan.Size = New System.Drawing.Size(81, 13)
        Me.txtTotalTagihan.TabIndex = 257
        Me.txtTotalTagihan.Text = "TotalTagihan"
        Me.txtTotalTagihan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbxIsDirect
        '
        Me.cbxIsDirect.AutoSize = True
        Me.cbxIsDirect.Location = New System.Drawing.Point(295, 368)
        Me.cbxIsDirect.Name = "cbxIsDirect"
        Me.cbxIsDirect.Size = New System.Drawing.Size(65, 17)
        Me.cbxIsDirect.TabIndex = 258
        Me.cbxIsDirect.Text = "Is Direct"
        Me.cbxIsDirect.UseVisualStyleBackColor = True
        '
        'BtnPrintBK
        '
        Me.BtnPrintBK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPrintBK.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrintBK.ForeColor = System.Drawing.Color.Red
        Me.BtnPrintBK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPrintBK.Location = New System.Drawing.Point(11, 228)
        Me.BtnPrintBK.Name = "BtnPrintBK"
        Me.BtnPrintBK.Size = New System.Drawing.Size(108, 24)
        Me.BtnPrintBK.TabIndex = 259
        Me.BtnPrintBK.Text = "&Print BK / Giro"
        Me.BtnPrintBK.UseVisualStyleBackColor = True
        '
        'txtbkid
        '
        Me.txtbkid.AutoSize = True
        Me.txtbkid.BackColor = System.Drawing.Color.PowderBlue
        Me.txtbkid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbkid.Location = New System.Drawing.Point(16, 270)
        Me.txtbkid.Name = "txtbkid"
        Me.txtbkid.Size = New System.Drawing.Size(14, 13)
        Me.txtbkid.TabIndex = 260
        Me.txtbkid.Text = "0"
        Me.txtbkid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmTglBayar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PowderBlue
        Me.ClientSize = New System.Drawing.Size(371, 471)
        Me.Controls.Add(Me.txtbkid)
        Me.Controls.Add(Me.BtnPrintBK)
        Me.Controls.Add(Me.lblFileName)
        Me.Controls.Add(Me.cbxIsDirect)
        Me.Controls.Add(Me.txtTotalTagihan)
        Me.Controls.Add(Me.txtVendor)
        Me.Controls.Add(Me.txtVendorID)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.RbtLain)
        Me.Controls.Add(Me.RbtGiro3)
        Me.Controls.Add(Me.RbtGiro2)
        Me.Controls.Add(Me.RbtGiro1)
        Me.Controls.Add(Me.RbtBK)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPotongan)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtRemarksKW)
        Me.Controls.Add(Me.lblTambahDK)
        Me.Controls.Add(Me.txtNoTerima)
        Me.Controls.Add(Me.Label68)
        Me.Controls.Add(Me.Label71)
        Me.Controls.Add(Me.txtNoGiro)
        Me.Controls.Add(Me.Label75)
        Me.Controls.Add(Me.Label76)
        Me.Controls.Add(Me.txtNoteBayar)
        Me.Controls.Add(Me.Label72)
        Me.Controls.Add(Me.Label73)
        Me.Controls.Add(Me.txtNoBK)
        Me.Controls.Add(Me.CboTipeBayar)
        Me.Controls.Add(Me.Label69)
        Me.Controls.Add(Me.Label70)
        Me.Controls.Add(Me.cbRevisi)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.DtTglBayar)
        Me.Controls.Add(Me.BtnSaveKW)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTglBayar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Input Tgl Bayar"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents txtNoGiro As System.Windows.Forms.TextBox
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents txtNoteBayar As System.Windows.Forms.TextBox
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents txtNoBK As System.Windows.Forms.TextBox
    Friend WithEvents CboTipeBayar As System.Windows.Forms.ComboBox
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents cbRevisi As System.Windows.Forms.CheckBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents DtTglBayar As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnSaveKW As System.Windows.Forms.Button
    Friend WithEvents txtNoTerima As System.Windows.Forms.Label
    Friend WithEvents lblTambahDK As System.Windows.Forms.Label
    Friend WithEvents lblFileName As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtRemarksKW As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPotongan As System.Windows.Forms.TextBox
    Friend WithEvents RbtBK As System.Windows.Forms.RadioButton
    Friend WithEvents RbtGiro1 As System.Windows.Forms.RadioButton
    Friend WithEvents RbtGiro3 As System.Windows.Forms.RadioButton
    Friend WithEvents RbtGiro2 As System.Windows.Forms.RadioButton
    Friend WithEvents RbtLain As System.Windows.Forms.RadioButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtVendorID As System.Windows.Forms.Label
    Friend WithEvents txtVendor As System.Windows.Forms.Label
    Friend WithEvents txtTotalTagihan As System.Windows.Forms.Label
    Friend WithEvents cbxIsDirect As System.Windows.Forms.CheckBox
    Friend WithEvents BtnPrintBK As System.Windows.Forms.Button
    Friend WithEvents txtbkid As System.Windows.Forms.Label
End Class
