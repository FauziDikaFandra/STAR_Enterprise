<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmployeeForm
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
        Me.lblJudul = New System.Windows.Forms.Label
        Me.txtStatusNikah = New System.Windows.Forms.ComboBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.txtTempatLahir = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtPendidikan = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtNoKTP = New System.Windows.Forms.TextBox
        Me.txtAgama = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtJenisKelamin = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtResigndate = New System.Windows.Forms.DateTimePicker
        Me.dtJoindate = New System.Windows.Forms.DateTimePicker
        Me.dtDOB = New System.Windows.Forms.DateTimePicker
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtEmail = New System.Windows.Forms.TextBox
        Me.txtAlamat = New System.Windows.Forms.TextBox
        Me.txtNIP = New System.Windows.Forms.TextBox
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.txtNama = New System.Windows.Forms.TextBox
        Me.txtDept = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtBagian = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtUnit = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtJabatan = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtGolDarah = New System.Windows.Forms.ComboBox
        Me.txtNoTelp = New System.Windows.Forms.TextBox
        Me.txtHP = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.BtnSave = New System.Windows.Forms.Button
        Me.foto = New System.Windows.Forms.PictureBox
        Me.BtnPilihFoto = New System.Windows.Forms.Button
        Me.txtEmployeeID = New System.Windows.Forms.Label
        Me.lblTipe = New System.Windows.Forms.Label
        Me.dtc1 = New System.Windows.Forms.DateTimePicker
        Me.Label15 = New System.Windows.Forms.Label
        Me.dtc2 = New System.Windows.Forms.DateTimePicker
        Me.Label19 = New System.Windows.Forms.Label
        Me.dtc4 = New System.Windows.Forms.DateTimePicker
        Me.Label23 = New System.Windows.Forms.Label
        Me.dtc3 = New System.Windows.Forms.DateTimePicker
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.txtKdFinger = New System.Windows.Forms.TextBox
        CType(Me.foto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblJudul
        '
        Me.lblJudul.BackColor = System.Drawing.Color.Red
        Me.lblJudul.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblJudul.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJudul.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblJudul.Location = New System.Drawing.Point(0, 0)
        Me.lblJudul.Name = "lblJudul"
        Me.lblJudul.Size = New System.Drawing.Size(941, 43)
        Me.lblJudul.TabIndex = 1
        Me.lblJudul.Text = "Karyawan"
        Me.lblJudul.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtStatusNikah
        '
        Me.txtStatusNikah.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtStatusNikah.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatusNikah.FormattingEnabled = True
        Me.txtStatusNikah.Location = New System.Drawing.Point(438, 213)
        Me.txtStatusNikah.Name = "txtStatusNikah"
        Me.txtStatusNikah.Size = New System.Drawing.Size(185, 21)
        Me.txtStatusNikah.TabIndex = 33
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(335, 297)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(54, 13)
        Me.Label24.TabIndex = 38
        Me.Label24.Text = "G&ol Darah"
        '
        'txtTempatLahir
        '
        Me.txtTempatLahir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTempatLahir.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTempatLahir.Location = New System.Drawing.Point(113, 269)
        Me.txtTempatLahir.Name = "txtTempatLahir"
        Me.txtTempatLahir.Size = New System.Drawing.Size(185, 21)
        Me.txtTempatLahir.TabIndex = 17
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(335, 214)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(94, 13)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "Status Pe&rnikahan"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(335, 83)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "No T&elp"
        '
        'txtPendidikan
        '
        Me.txtPendidikan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtPendidikan.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPendidikan.FormattingEnabled = True
        Me.txtPendidikan.Location = New System.Drawing.Point(438, 186)
        Me.txtPendidikan.Name = "txtPendidikan"
        Me.txtPendidikan.Size = New System.Drawing.Size(185, 21)
        Me.txtPendidikan.TabIndex = 31
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(335, 189)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "Pen&didikan"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(15, 271)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "&Tempat Lahir"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(335, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "No &KTP"
        '
        'txtNoKTP
        '
        Me.txtNoKTP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNoKTP.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoKTP.Location = New System.Drawing.Point(438, 51)
        Me.txtNoKTP.Name = "txtNoKTP"
        Me.txtNoKTP.Size = New System.Drawing.Size(185, 21)
        Me.txtNoKTP.TabIndex = 21
        '
        'txtAgama
        '
        Me.txtAgama.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtAgama.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAgama.FormattingEnabled = True
        Me.txtAgama.Location = New System.Drawing.Point(438, 267)
        Me.txtAgama.Name = "txtAgama"
        Me.txtAgama.Size = New System.Drawing.Size(185, 21)
        Me.txtAgama.TabIndex = 37
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(335, 271)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Aga&ma"
        '
        'txtJenisKelamin
        '
        Me.txtJenisKelamin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtJenisKelamin.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJenisKelamin.FormattingEnabled = True
        Me.txtJenisKelamin.Location = New System.Drawing.Point(438, 240)
        Me.txtJenisKelamin.Name = "txtJenisKelamin"
        Me.txtJenisKelamin.Size = New System.Drawing.Size(185, 21)
        Me.txtJenisKelamin.TabIndex = 35
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(335, 243)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Jen&is Kelamin"
        '
        'dtResigndate
        '
        Me.dtResigndate.Checked = False
        Me.dtResigndate.CustomFormat = "dd-MMMM-yyyy"
        Me.dtResigndate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtResigndate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtResigndate.Location = New System.Drawing.Point(115, 242)
        Me.dtResigndate.Name = "dtResigndate"
        Me.dtResigndate.ShowCheckBox = True
        Me.dtResigndate.Size = New System.Drawing.Size(183, 21)
        Me.dtResigndate.TabIndex = 15
        '
        'dtJoindate
        '
        Me.dtJoindate.CustomFormat = "dd-MMMM-yyyy"
        Me.dtJoindate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtJoindate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtJoindate.Location = New System.Drawing.Point(115, 213)
        Me.dtJoindate.Name = "dtJoindate"
        Me.dtJoindate.ShowCheckBox = True
        Me.dtJoindate.Size = New System.Drawing.Size(183, 21)
        Me.dtJoindate.TabIndex = 13
        '
        'dtDOB
        '
        Me.dtDOB.Checked = False
        Me.dtDOB.CustomFormat = "dd-MMMM-yyyy"
        Me.dtDOB.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtDOB.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtDOB.Location = New System.Drawing.Point(115, 294)
        Me.dtDOB.Name = "dtDOB"
        Me.dtDOB.ShowCheckBox = True
        Me.dtDOB.Size = New System.Drawing.Size(183, 21)
        Me.dtDOB.TabIndex = 19
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(15, 243)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(61, 13)
        Me.Label22.TabIndex = 14
        Me.Label22.Text = "&Resigndate"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(15, 219)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(48, 13)
        Me.Label21.TabIndex = 12
        Me.Label21.Text = "J&oindate"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(15, 300)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(71, 13)
        Me.Label20.TabIndex = 18
        Me.Label20.Text = "Tan&ggal Lahir"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(335, 136)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(31, 13)
        Me.Label18.TabIndex = 26
        Me.Label18.Text = "Emai&l"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(654, 53)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(40, 13)
        Me.Label17.TabIndex = 40
        Me.Label17.Text = "&Alamat"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(15, 53)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(24, 13)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "&NIP"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(335, 161)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(81, 13)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "&Password Login"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(15, 80)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(85, 13)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "N&ama Karyawan"
        '
        'txtEmail
        '
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(438, 132)
        Me.txtEmail.MaxLength = 30
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(185, 21)
        Me.txtEmail.TabIndex = 27
        '
        'txtAlamat
        '
        Me.txtAlamat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAlamat.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlamat.Location = New System.Drawing.Point(745, 51)
        Me.txtAlamat.MaxLength = 200
        Me.txtAlamat.Multiline = True
        Me.txtAlamat.Name = "txtAlamat"
        Me.txtAlamat.Size = New System.Drawing.Size(183, 102)
        Me.txtAlamat.TabIndex = 41
        '
        'txtNIP
        '
        Me.txtNIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNIP.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNIP.Location = New System.Drawing.Point(115, 51)
        Me.txtNIP.MaxLength = 20
        Me.txtNIP.Name = "txtNIP"
        Me.txtNIP.Size = New System.Drawing.Size(185, 21)
        Me.txtNIP.TabIndex = 1
        '
        'txtPassword
        '
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(438, 159)
        Me.txtPassword.MaxLength = 100
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(185, 21)
        Me.txtPassword.TabIndex = 29
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'txtNama
        '
        Me.txtNama.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNama.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNama.Location = New System.Drawing.Point(115, 78)
        Me.txtNama.MaxLength = 30
        Me.txtNama.Name = "txtNama"
        Me.txtNama.Size = New System.Drawing.Size(185, 21)
        Me.txtNama.TabIndex = 3
        '
        'txtDept
        '
        Me.txtDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtDept.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDept.FormattingEnabled = True
        Me.txtDept.Location = New System.Drawing.Point(115, 105)
        Me.txtDept.Name = "txtDept"
        Me.txtDept.Size = New System.Drawing.Size(185, 21)
        Me.txtDept.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "&Department"
        '
        'txtBagian
        '
        Me.txtBagian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtBagian.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBagian.FormattingEnabled = True
        Me.txtBagian.Location = New System.Drawing.Point(115, 132)
        Me.txtBagian.Name = "txtBagian"
        Me.txtBagian.Size = New System.Drawing.Size(185, 21)
        Me.txtBagian.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 135)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "&Bagian"
        '
        'txtUnit
        '
        Me.txtUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnit.FormattingEnabled = True
        Me.txtUnit.Location = New System.Drawing.Point(115, 186)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Size = New System.Drawing.Size(185, 21)
        Me.txtUnit.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 189)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "&Unit"
        '
        'txtJabatan
        '
        Me.txtJabatan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtJabatan.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJabatan.FormattingEnabled = True
        Me.txtJabatan.Location = New System.Drawing.Point(115, 159)
        Me.txtJabatan.Name = "txtJabatan"
        Me.txtJabatan.Size = New System.Drawing.Size(185, 21)
        Me.txtJabatan.TabIndex = 9
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(15, 162)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 13)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "&Jabatan"
        '
        'txtGolDarah
        '
        Me.txtGolDarah.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtGolDarah.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGolDarah.FormattingEnabled = True
        Me.txtGolDarah.Location = New System.Drawing.Point(438, 294)
        Me.txtGolDarah.Name = "txtGolDarah"
        Me.txtGolDarah.Size = New System.Drawing.Size(185, 21)
        Me.txtGolDarah.TabIndex = 39
        '
        'txtNoTelp
        '
        Me.txtNoTelp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNoTelp.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoTelp.Location = New System.Drawing.Point(438, 78)
        Me.txtNoTelp.MaxLength = 30
        Me.txtNoTelp.Name = "txtNoTelp"
        Me.txtNoTelp.Size = New System.Drawing.Size(185, 21)
        Me.txtNoTelp.TabIndex = 23
        '
        'txtHP
        '
        Me.txtHP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHP.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHP.Location = New System.Drawing.Point(438, 105)
        Me.txtHP.MaxLength = 30
        Me.txtHP.Name = "txtHP"
        Me.txtHP.Size = New System.Drawing.Size(185, 21)
        Me.txtHP.TabIndex = 25
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(335, 110)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(20, 13)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "&HP"
        '
        'BtnSave
        '
        Me.BtnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.Color.Red
        Me.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSave.Location = New System.Drawing.Point(866, 296)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(63, 30)
        Me.BtnSave.TabIndex = 42
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'foto
        '
        Me.foto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.foto.ErrorImage = Nothing
        Me.foto.Location = New System.Drawing.Point(642, 311)
        Me.foto.Name = "foto"
        Me.foto.Size = New System.Drawing.Size(127, 129)
        Me.foto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.foto.TabIndex = 194
        Me.foto.TabStop = False
        Me.foto.Visible = False
        '
        'BtnPilihFoto
        '
        Me.BtnPilihFoto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPilihFoto.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPilihFoto.ForeColor = System.Drawing.Color.Red
        Me.BtnPilihFoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPilihFoto.Location = New System.Drawing.Point(827, 294)
        Me.BtnPilihFoto.Name = "BtnPilihFoto"
        Me.BtnPilihFoto.Size = New System.Drawing.Size(101, 30)
        Me.BtnPilihFoto.TabIndex = 43
        Me.BtnPilihFoto.Text = "Pilih Foto"
        Me.BtnPilihFoto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnPilihFoto.UseVisualStyleBackColor = True
        Me.BtnPilihFoto.Visible = False
        '
        'txtEmployeeID
        '
        Me.txtEmployeeID.AutoSize = True
        Me.txtEmployeeID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmployeeID.Location = New System.Drawing.Point(630, 108)
        Me.txtEmployeeID.Name = "txtEmployeeID"
        Me.txtEmployeeID.Size = New System.Drawing.Size(64, 13)
        Me.txtEmployeeID.TabIndex = 195
        Me.txtEmployeeID.Text = "EmployeeID"
        '
        'lblTipe
        '
        Me.lblTipe.AutoSize = True
        Me.lblTipe.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipe.Location = New System.Drawing.Point(630, 81)
        Me.lblTipe.Name = "lblTipe"
        Me.lblTipe.Size = New System.Drawing.Size(35, 13)
        Me.lblTipe.TabIndex = 196
        Me.lblTipe.Text = "lbltipe"
        '
        'dtc1
        '
        Me.dtc1.Checked = False
        Me.dtc1.CustomFormat = "dd-MMMM-yyyy"
        Me.dtc1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtc1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtc1.Location = New System.Drawing.Point(745, 186)
        Me.dtc1.Name = "dtc1"
        Me.dtc1.ShowCheckBox = True
        Me.dtc1.Size = New System.Drawing.Size(183, 21)
        Me.dtc1.TabIndex = 198
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(654, 188)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(85, 13)
        Me.Label15.TabIndex = 197
        Me.Label15.Text = "Start Contract 1"
        '
        'dtc2
        '
        Me.dtc2.Checked = False
        Me.dtc2.CustomFormat = "dd-MMMM-yyyy"
        Me.dtc2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtc2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtc2.Location = New System.Drawing.Point(745, 213)
        Me.dtc2.Name = "dtc2"
        Me.dtc2.ShowCheckBox = True
        Me.dtc2.Size = New System.Drawing.Size(183, 21)
        Me.dtc2.TabIndex = 200
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(654, 215)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(79, 13)
        Me.Label19.TabIndex = 199
        Me.Label19.Text = "End Contract 1"
        '
        'dtc4
        '
        Me.dtc4.Checked = False
        Me.dtc4.CustomFormat = "dd-MMMM-yyyy"
        Me.dtc4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtc4.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtc4.Location = New System.Drawing.Point(745, 269)
        Me.dtc4.Name = "dtc4"
        Me.dtc4.ShowCheckBox = True
        Me.dtc4.Size = New System.Drawing.Size(183, 21)
        Me.dtc4.TabIndex = 204
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(654, 271)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(85, 13)
        Me.Label23.TabIndex = 203
        Me.Label23.Text = "Start Contract 2"
        '
        'dtc3
        '
        Me.dtc3.Checked = False
        Me.dtc3.CustomFormat = "dd-MMMM-yyyy"
        Me.dtc3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtc3.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtc3.Location = New System.Drawing.Point(745, 242)
        Me.dtc3.Name = "dtc3"
        Me.dtc3.ShowCheckBox = True
        Me.dtc3.Size = New System.Drawing.Size(183, 21)
        Me.dtc3.TabIndex = 202
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(654, 244)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(85, 13)
        Me.Label25.TabIndex = 201
        Me.Label25.Text = "Start Contract 2"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(654, 161)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(64, 13)
        Me.Label26.TabIndex = 205
        Me.Label26.Text = "Kode &Finger"
        '
        'txtKdFinger
        '
        Me.txtKdFinger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKdFinger.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKdFinger.Location = New System.Drawing.Point(745, 159)
        Me.txtKdFinger.Name = "txtKdFinger"
        Me.txtKdFinger.Size = New System.Drawing.Size(183, 21)
        Me.txtKdFinger.TabIndex = 206
        '
        'EmployeeForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PowderBlue
        Me.ClientSize = New System.Drawing.Size(941, 327)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.txtKdFinger)
        Me.Controls.Add(Me.dtc4)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.dtc3)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.dtc2)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.dtc1)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.lblTipe)
        Me.Controls.Add(Me.txtEmployeeID)
        Me.Controls.Add(Me.BtnPilihFoto)
        Me.Controls.Add(Me.foto)
        Me.Controls.Add(Me.txtHP)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtNoTelp)
        Me.Controls.Add(Me.txtGolDarah)
        Me.Controls.Add(Me.txtUnit)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtJabatan)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtBagian)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDept)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtStatusNikah)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.txtTempatLahir)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtPendidikan)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtNoKTP)
        Me.Controls.Add(Me.txtAgama)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtJenisKelamin)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtResigndate)
        Me.Controls.Add(Me.dtJoindate)
        Me.Controls.Add(Me.dtDOB)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtAlamat)
        Me.Controls.Add(Me.txtNIP)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtNama)
        Me.Controls.Add(Me.lblJudul)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EmployeeForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Employee Form"
        CType(Me.foto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblJudul As System.Windows.Forms.Label
    Friend WithEvents txtStatusNikah As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtTempatLahir As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPendidikan As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNoKTP As System.Windows.Forms.TextBox
    Friend WithEvents txtAgama As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtJenisKelamin As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtResigndate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtJoindate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtDOB As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtAlamat As System.Windows.Forms.TextBox
    Friend WithEvents txtNIP As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtNama As System.Windows.Forms.TextBox
    Friend WithEvents txtDept As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBagian As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUnit As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtJabatan As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtGolDarah As System.Windows.Forms.ComboBox
    Friend WithEvents txtNoTelp As System.Windows.Forms.TextBox
    Friend WithEvents txtHP As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents foto As System.Windows.Forms.PictureBox
    Friend WithEvents BtnPilihFoto As System.Windows.Forms.Button
    Friend WithEvents txtEmployeeID As System.Windows.Forms.Label
    Friend WithEvents lblTipe As System.Windows.Forms.Label
    Friend WithEvents dtc1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents dtc2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents dtc4 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents dtc3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtKdFinger As System.Windows.Forms.TextBox
End Class
