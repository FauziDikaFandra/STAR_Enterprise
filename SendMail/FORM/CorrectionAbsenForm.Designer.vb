<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CorrectionAbsenForm
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.lblJudul = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtEmployeeID = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDept = New System.Windows.Forms.TextBox
        Me.dtPeriode = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.BtnCari = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtBagian = New System.Windows.Forms.TextBox
        Me.txtFingerCode = New System.Windows.Forms.TextBox
        Me.txtName = New System.Windows.Forms.TextBox
        Me.txtNIP = New System.Windows.Forms.TextBox
        Me.BtnReload = New System.Windows.Forms.Button
        Me.txtJabatan = New System.Windows.Forms.TextBox
        Me.dg = New System.Windows.Forms.DataGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnBatal = New System.Windows.Forms.Button
        Me.btnTutup = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.gbPilih = New System.Windows.Forms.GroupBox
        Me.dgKar = New System.Windows.Forms.DataGridView
        Me.spg_barcode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.spg_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nm_dept = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nm_bagian = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.brand = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nm_sbu = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colEmployeeID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtCari = New System.Windows.Forms.TextBox
        Me.NavSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.jam_masuk = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1.SuspendLayout()
        CType(Me.dg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.gbPilih.SuspendLayout()
        CType(Me.dgKar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NavSource1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblJudul.Size = New System.Drawing.Size(908, 43)
        Me.lblJudul.TabIndex = 2
        Me.lblJudul.Text = "Attendance Correction"
        Me.lblJudul.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtEmployeeID)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtDept)
        Me.Panel1.Controls.Add(Me.dtPeriode)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.BtnCari)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtBagian)
        Me.Panel1.Controls.Add(Me.txtFingerCode)
        Me.Panel1.Controls.Add(Me.txtName)
        Me.Panel1.Controls.Add(Me.txtNIP)
        Me.Panel1.Controls.Add(Me.BtnReload)
        Me.Panel1.Controls.Add(Me.txtJabatan)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 43)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(908, 100)
        Me.Panel1.TabIndex = 28
        '
        'txtEmployeeID
        '
        Me.txtEmployeeID.AutoSize = True
        Me.txtEmployeeID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmployeeID.Location = New System.Drawing.Point(371, 16)
        Me.txtEmployeeID.Name = "txtEmployeeID"
        Me.txtEmployeeID.Size = New System.Drawing.Size(67, 13)
        Me.txtEmployeeID.TabIndex = 16
        Me.txtEmployeeID.Text = "Employee ID"
        Me.txtEmployeeID.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(582, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Department"
        '
        'txtDept
        '
        Me.txtDept.Enabled = False
        Me.txtDept.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDept.Location = New System.Drawing.Point(652, 13)
        Me.txtDept.Name = "txtDept"
        Me.txtDept.Size = New System.Drawing.Size(211, 21)
        Me.txtDept.TabIndex = 11
        Me.txtDept.TabStop = False
        '
        'dtPeriode
        '
        Me.dtPeriode.CustomFormat = "MMMM-yyyy"
        Me.dtPeriode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtPeriode.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPeriode.Location = New System.Drawing.Point(72, 13)
        Me.dtPeriode.Name = "dtPeriode"
        Me.dtPeriode.ShowUpDown = True
        Me.dtPeriode.Size = New System.Drawing.Size(211, 21)
        Me.dtPeriode.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(582, 70)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Jabatan"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "&NIP"
        '
        'BtnCari
        '
        Me.BtnCari.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCari.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnCari.Location = New System.Drawing.Point(401, 33)
        Me.BtnCari.Name = "BtnCari"
        Me.BtnCari.Size = New System.Drawing.Size(65, 55)
        Me.BtnCari.TabIndex = 6
        Me.BtnCari.Text = "&Cari"
        Me.BtnCari.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnCari.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Periode"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(582, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Bagian"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(225, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Finger Code"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Nama"
        '
        'txtBagian
        '
        Me.txtBagian.Enabled = False
        Me.txtBagian.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBagian.Location = New System.Drawing.Point(652, 40)
        Me.txtBagian.Name = "txtBagian"
        Me.txtBagian.Size = New System.Drawing.Size(211, 21)
        Me.txtBagian.TabIndex = 13
        Me.txtBagian.TabStop = False
        '
        'txtFingerCode
        '
        Me.txtFingerCode.Enabled = False
        Me.txtFingerCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFingerCode.Location = New System.Drawing.Point(296, 40)
        Me.txtFingerCode.Name = "txtFingerCode"
        Me.txtFingerCode.Size = New System.Drawing.Size(99, 21)
        Me.txtFingerCode.TabIndex = 5
        Me.txtFingerCode.TabStop = False
        '
        'txtName
        '
        Me.txtName.Enabled = False
        Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(72, 67)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(323, 21)
        Me.txtName.TabIndex = 9
        Me.txtName.TabStop = False
        '
        'txtNIP
        '
        Me.txtNIP.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNIP.Location = New System.Drawing.Point(72, 40)
        Me.txtNIP.Name = "txtNIP"
        Me.txtNIP.Size = New System.Drawing.Size(135, 21)
        Me.txtNIP.TabIndex = 3
        '
        'BtnReload
        '
        Me.BtnReload.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReload.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnReload.Location = New System.Drawing.Point(472, 33)
        Me.BtnReload.Name = "BtnReload"
        Me.BtnReload.Size = New System.Drawing.Size(65, 55)
        Me.BtnReload.TabIndex = 7
        Me.BtnReload.Text = "&Reload"
        Me.BtnReload.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnReload.UseVisualStyleBackColor = True
        '
        'txtJabatan
        '
        Me.txtJabatan.Enabled = False
        Me.txtJabatan.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJabatan.Location = New System.Drawing.Point(652, 67)
        Me.txtJabatan.Name = "txtJabatan"
        Me.txtJabatan.Size = New System.Drawing.Size(211, 21)
        Me.txtJabatan.TabIndex = 15
        Me.txtJabatan.TabStop = False
        '
        'dg
        '
        Me.dg.AllowUserToAddRows = False
        Me.dg.AllowUserToDeleteRows = False
        Me.dg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dg.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dg.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column9, Me.jam_masuk, Me.Column5, Me.Column7, Me.Column6, Me.Column8, Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column14, Me.Column4, Me.Column15, Me.Column16, Me.Column17, Me.Column18, Me.Column19})
        Me.dg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg.Location = New System.Drawing.Point(0, 143)
        Me.dg.Margin = New System.Windows.Forms.Padding(100)
        Me.dg.Name = "dg"
        Me.dg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dg.Size = New System.Drawing.Size(908, 277)
        Me.dg.TabIndex = 29
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnBatal)
        Me.GroupBox2.Controls.Add(Me.btnTutup)
        Me.GroupBox2.Controls.Add(Me.btnSave)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(0, 420)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(908, 72)
        Me.GroupBox2.TabIndex = 30
        Me.GroupBox2.TabStop = False
        '
        'btnBatal
        '
        Me.btnBatal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBatal.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBatal.Location = New System.Drawing.Point(77, 11)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(65, 55)
        Me.btnBatal.TabIndex = 1
        Me.btnBatal.Text = "&Batal"
        Me.btnBatal.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBatal.UseVisualStyleBackColor = True
        '
        'btnTutup
        '
        Me.btnTutup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTutup.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnTutup.Location = New System.Drawing.Point(148, 11)
        Me.btnTutup.Name = "btnTutup"
        Me.btnTutup.Size = New System.Drawing.Size(65, 55)
        Me.btnTutup.TabIndex = 2
        Me.btnTutup.Text = "T&utup"
        Me.btnTutup.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnTutup.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSave.Location = New System.Drawing.Point(6, 11)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(65, 55)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Simpan"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'gbPilih
        '
        Me.gbPilih.Controls.Add(Me.dgKar)
        Me.gbPilih.Controls.Add(Me.Label8)
        Me.gbPilih.Controls.Add(Me.txtCari)
        Me.gbPilih.Location = New System.Drawing.Point(163, 189)
        Me.gbPilih.Name = "gbPilih"
        Me.gbPilih.Size = New System.Drawing.Size(733, 322)
        Me.gbPilih.TabIndex = 31
        Me.gbPilih.TabStop = False
        Me.gbPilih.Visible = False
        '
        'dgKar
        '
        Me.dgKar.AllowUserToAddRows = False
        Me.dgKar.AllowUserToDeleteRows = False
        Me.dgKar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgKar.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgKar.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgKar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgKar.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.spg_barcode, Me.spg_name, Me.nm_dept, Me.nm_bagian, Me.brand, Me.nm_sbu, Me.colEmployeeID})
        Me.dgKar.Location = New System.Drawing.Point(9, 44)
        Me.dgKar.Margin = New System.Windows.Forms.Padding(100)
        Me.dgKar.Name = "dgKar"
        Me.dgKar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgKar.Size = New System.Drawing.Size(714, 272)
        Me.dgKar.TabIndex = 27
        '
        'spg_barcode
        '
        Me.spg_barcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.spg_barcode.DataPropertyName = "nip"
        Me.spg_barcode.Frozen = True
        Me.spg_barcode.HeaderText = "NIP"
        Me.spg_barcode.Name = "spg_barcode"
        Me.spg_barcode.ReadOnly = True
        Me.spg_barcode.Width = 80
        '
        'spg_name
        '
        Me.spg_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.spg_name.DataPropertyName = "name"
        Me.spg_name.Frozen = True
        Me.spg_name.HeaderText = "Nama Karyawan"
        Me.spg_name.Name = "spg_name"
        Me.spg_name.ReadOnly = True
        Me.spg_name.Width = 200
        '
        'nm_dept
        '
        Me.nm_dept.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.nm_dept.DataPropertyName = "departmentname"
        Me.nm_dept.Frozen = True
        Me.nm_dept.HeaderText = "Dept"
        Me.nm_dept.Name = "nm_dept"
        Me.nm_dept.ReadOnly = True
        '
        'nm_bagian
        '
        Me.nm_bagian.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.nm_bagian.DataPropertyName = "bagianname"
        Me.nm_bagian.Frozen = True
        Me.nm_bagian.HeaderText = "Bagian"
        Me.nm_bagian.Name = "nm_bagian"
        Me.nm_bagian.ReadOnly = True
        '
        'brand
        '
        Me.brand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.brand.DataPropertyName = "jabatanname"
        Me.brand.Frozen = True
        Me.brand.HeaderText = "Jabatan"
        Me.brand.Name = "brand"
        Me.brand.ReadOnly = True
        '
        'nm_sbu
        '
        Me.nm_sbu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.nm_sbu.DataPropertyName = "unitname"
        Me.nm_sbu.Frozen = True
        Me.nm_sbu.HeaderText = "Unit"
        Me.nm_sbu.Name = "nm_sbu"
        Me.nm_sbu.ReadOnly = True
        '
        'colEmployeeID
        '
        Me.colEmployeeID.DataPropertyName = "employee_id"
        Me.colEmployeeID.Frozen = True
        Me.colEmployeeID.HeaderText = "Employee ID"
        Me.colEmployeeID.Name = "colEmployeeID"
        Me.colEmployeeID.ReadOnly = True
        Me.colEmployeeID.Width = 85
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 13)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Nama"
        '
        'txtCari
        '
        Me.txtCari.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCari.Location = New System.Drawing.Point(47, 16)
        Me.txtCari.Name = "txtCari"
        Me.txtCari.Size = New System.Drawing.Size(676, 21)
        Me.txtCari.TabIndex = 25
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column1.DataPropertyName = "hari"
        Me.Column1.HeaderText = "Hari"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 60
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column2.DataPropertyName = "tgl"
        DataGridViewCellStyle1.Format = "dd-MM-yyyy"
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column2.HeaderText = "Tanggal"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 70
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column3.DataPropertyName = "masukroster"
        Me.Column3.HeaderText = "Masuk Roster"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 50
        '
        'Column9
        '
        Me.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column9.DataPropertyName = "pulangroster"
        Me.Column9.HeaderText = "Pulang Roster"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 50
        '
        'jam_masuk
        '
        Me.jam_masuk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.jam_masuk.DataPropertyName = "jammasuk"
        Me.jam_masuk.HeaderText = "Jam Masuk"
        Me.jam_masuk.Name = "jam_masuk"
        Me.jam_masuk.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.jam_masuk.Width = 50
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column5.DataPropertyName = "jampulang"
        Me.Column5.HeaderText = "Jam Pulang"
        Me.Column5.Name = "Column5"
        Me.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column5.Width = 50
        '
        'Column7
        '
        Me.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column7.DataPropertyName = "status"
        Me.Column7.HeaderText = "Status"
        Me.Column7.Items.AddRange(New Object() {"Alpa", "Cuti", "Izin", "Lembur", "Latenight", "Masuk", "Off", "Ro", "Sakit", "Terlambat"})
        Me.Column7.Name = "Column7"
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column6.DataPropertyName = "keterangan"
        Me.Column6.HeaderText = "Keterangan"
        Me.Column6.Name = "Column6"
        Me.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column6.Width = 200
        '
        'Column8
        '
        Me.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column8.DataPropertyName = "lemburmasuk"
        Me.Column8.HeaderText = "Masuk Lembur"
        Me.Column8.Name = "Column8"
        Me.Column8.Width = 70
        '
        'Column10
        '
        Me.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column10.DataPropertyName = "lemburpulang"
        Me.Column10.HeaderText = "Pulang Lembur"
        Me.Column10.Name = "Column10"
        Me.Column10.Width = 70
        '
        'Column11
        '
        Me.Column11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column11.DataPropertyName = "dateadded"
        DataGridViewCellStyle2.Format = "yyyy-MM-dd HH:mm:ss.fff"
        Me.Column11.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column11.HeaderText = "Tanggal Add"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Width = 140
        '
        'Column12
        '
        Me.Column12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column12.DataPropertyName = "useradded"
        Me.Column12.HeaderText = "User Add"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        '
        'Column13
        '
        Me.Column13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column13.DataPropertyName = "dateedited"
        DataGridViewCellStyle3.Format = "yyyy-MM-dd HH:mm:ss.fff"
        Me.Column13.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column13.HeaderText = "Tanggal Update"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        Me.Column13.Width = 140
        '
        'Column14
        '
        Me.Column14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column14.DataPropertyName = "useredited"
        Me.Column14.HeaderText = "User Update"
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "jammasuk1"
        Me.Column4.HeaderText = "jammasuk1"
        Me.Column4.Name = "Column4"
        Me.Column4.Visible = False
        Me.Column4.Width = 85
        '
        'Column15
        '
        Me.Column15.DataPropertyName = "jampulang1"
        Me.Column15.HeaderText = "jampulang1"
        Me.Column15.Name = "Column15"
        Me.Column15.Visible = False
        Me.Column15.Width = 86
        '
        'Column16
        '
        Me.Column16.DataPropertyName = "keterangan1"
        Me.Column16.HeaderText = "keterangan1"
        Me.Column16.Name = "Column16"
        Me.Column16.Visible = False
        Me.Column16.Width = 92
        '
        'Column17
        '
        Me.Column17.DataPropertyName = "lemburmasuk1"
        Me.Column17.HeaderText = "lemburmasuk1"
        Me.Column17.Name = "Column17"
        Me.Column17.Visible = False
        '
        'Column18
        '
        Me.Column18.DataPropertyName = "lemburpulang1"
        Me.Column18.HeaderText = "lemburpulang1"
        Me.Column18.Name = "Column18"
        Me.Column18.Visible = False
        Me.Column18.Width = 101
        '
        'Column19
        '
        Me.Column19.DataPropertyName = "status1"
        Me.Column19.HeaderText = "status1"
        Me.Column19.Name = "Column19"
        Me.Column19.Visible = False
        Me.Column19.Width = 66
        '
        'CorrectionAbsenForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PowderBlue
        Me.ClientSize = New System.Drawing.Size(908, 492)
        Me.Controls.Add(Me.gbPilih)
        Me.Controls.Add(Me.dg)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblJudul)
        Me.Name = "CorrectionAbsenForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CorrectionAbsenForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.gbPilih.ResumeLayout(False)
        Me.gbPilih.PerformLayout()
        CType(Me.dgKar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NavSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblJudul As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dtPeriode As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BtnCari As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBagian As System.Windows.Forms.TextBox
    Friend WithEvents txtFingerCode As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtNIP As System.Windows.Forms.TextBox
    Friend WithEvents BtnReload As System.Windows.Forms.Button
    Friend WithEvents txtJabatan As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDept As System.Windows.Forms.TextBox
    Friend WithEvents dg As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBatal As System.Windows.Forms.Button
    Friend WithEvents btnTutup As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents gbPilih As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCari As System.Windows.Forms.TextBox
    Friend WithEvents dgKar As System.Windows.Forms.DataGridView
    Friend WithEvents NavSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents txtEmployeeID As System.Windows.Forms.Label
    Friend WithEvents spg_barcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents spg_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nm_dept As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nm_bagian As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents brand As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nm_sbu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEmployeeID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents jam_masuk As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column19 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
