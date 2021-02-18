<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AbsenSummary
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
        Dim CheckBoxProperties1 As PresentationControls.CheckBoxProperties = New PresentationControls.CheckBoxProperties
        Dim CheckBoxProperties2 As PresentationControls.CheckBoxProperties = New PresentationControls.CheckBoxProperties
        Dim CheckBoxProperties3 As PresentationControls.CheckBoxProperties = New PresentationControls.CheckBoxProperties
        Dim CheckBoxProperties4 As PresentationControls.CheckBoxProperties = New PresentationControls.CheckBoxProperties
        Dim CheckBoxProperties5 As PresentationControls.CheckBoxProperties = New PresentationControls.CheckBoxProperties
        Dim CheckBoxProperties6 As PresentationControls.CheckBoxProperties = New PresentationControls.CheckBoxProperties
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LblProses = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbxChoose = New System.Windows.Forms.CheckBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtgen2 = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtgen = New System.Windows.Forms.DateTimePicker
        Me.Button1 = New System.Windows.Forms.Button
        Me.pBar = New System.Windows.Forms.ProgressBar
        Me.btnPrint = New System.Windows.Forms.Button
        Me.BackgroundWorker = New System.ComponentModel.BackgroundWorker
        Me.GbPilih = New System.Windows.Forms.GroupBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.txtCari = New System.Windows.Forms.TextBox
        Me.cbxHilang = New System.Windows.Forms.CheckBox
        Me.cbxPilih = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.dg = New System.Windows.Forms.DataGridView
        Me.choose = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.spg_barcode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.spg_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.departmentcode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nm_dept = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nm_bagian = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.brand = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nm_sbu = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colEmployeeID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bagiancode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.jabatancode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cbxBrand = New System.Windows.Forms.CheckBox
        Me.cmbBagianx = New PresentationControls.CheckBoxComboBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.cmbDeptx = New PresentationControls.CheckBoxComboBox
        Me.NavSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cboDept = New PresentationControls.CheckBoxComboBox
        Me.cboBagian = New PresentationControls.CheckBoxComboBox
        Me.CboJabatan = New PresentationControls.CheckBoxComboBox
        Me.cbxDept = New System.Windows.Forms.CheckBox
        Me.cbxJabatan = New System.Windows.Forms.CheckBox
        Me.cbxBagian = New System.Windows.Forms.CheckBox
        Me.cmbBrand = New PresentationControls.CheckBoxComboBox
        Me.cmsPrint = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ReportAttendanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportByDeptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportByBagianToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportBySBUToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SummaryAttendanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SummaryByDeptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SummaryByBagianToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SummaryBySBUToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportByDeptToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportByBagianToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportBySBUToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportTotalKaryawanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1.SuspendLayout()
        Me.GbPilih.SuspendLayout()
        CType(Me.dg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NavSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.cmsPrint.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(72, 167)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 19
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblProses)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cbxChoose)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dtgen2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.dtgen)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(712, 47)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter Date"
        '
        'LblProses
        '
        Me.LblProses.AutoSize = True
        Me.LblProses.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProses.Location = New System.Drawing.Point(7, 40)
        Me.LblProses.Name = "LblProses"
        Me.LblProses.Size = New System.Drawing.Size(0, 13)
        Me.LblProses.TabIndex = 17
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(245, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(22, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "s/d"
        '
        'cbxChoose
        '
        Me.cbxChoose.AutoSize = True
        Me.cbxChoose.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxChoose.Location = New System.Drawing.Point(506, 18)
        Me.cbxChoose.Name = "cbxChoose"
        Me.cbxChoose.Size = New System.Drawing.Size(95, 17)
        Me.cbxChoose.TabIndex = 5
        Me.cbxChoose.Text = "&Pilih Karyawan"
        Me.cbxChoose.UseVisualStyleBackColor = True
        Me.cbxChoose.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(22, -19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(161, 20)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Tarik Data Absensi"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(277, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Tanggal Akhir"
        '
        'dtgen2
        '
        Me.dtgen2.CustomFormat = "dd-MMM-yyyy"
        Me.dtgen2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgen2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtgen2.Location = New System.Drawing.Point(355, 13)
        Me.dtgen2.Name = "dtgen2"
        Me.dtgen2.Size = New System.Drawing.Size(145, 21)
        Me.dtgen2.TabIndex = 4
        Me.dtgen2.Value = New Date(2015, 4, 8, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Tanggal Awal"
        '
        'dtgen
        '
        Me.dtgen.CustomFormat = "dd-MMM-yyyy"
        Me.dtgen.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgen.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtgen.Location = New System.Drawing.Point(85, 14)
        Me.dtgen.Name = "dtgen"
        Me.dtgen.Size = New System.Drawing.Size(145, 21)
        Me.dtgen.TabIndex = 1
        Me.dtgen.Value = New Date(2015, 4, 8, 0, 0, 0, 0)
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(570, 489)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'pBar
        '
        Me.pBar.Location = New System.Drawing.Point(32, 502)
        Me.pBar.Name = "pBar"
        Me.pBar.Size = New System.Drawing.Size(692, 18)
        Me.pBar.TabIndex = 7
        Me.pBar.Visible = False
        '
        'btnPrint
        '
        Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrint.Location = New System.Drawing.Point(617, 294)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(85, 31)
        Me.btnPrint.TabIndex = 6
        Me.btnPrint.Text = "&Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'BackgroundWorker
        '
        '
        'GbPilih
        '
        Me.GbPilih.Controls.Add(Me.TextBox1)
        Me.GbPilih.Controls.Add(Me.btnPrint)
        Me.GbPilih.Controls.Add(Me.txtCari)
        Me.GbPilih.Controls.Add(Me.cbxHilang)
        Me.GbPilih.Controls.Add(Me.cbxPilih)
        Me.GbPilih.Controls.Add(Me.Label2)
        Me.GbPilih.Controls.Add(Me.dg)
        Me.GbPilih.Controls.Add(Me.cbxBrand)
        Me.GbPilih.Location = New System.Drawing.Point(12, 111)
        Me.GbPilih.Name = "GbPilih"
        Me.GbPilih.Size = New System.Drawing.Size(712, 331)
        Me.GbPilih.TabIndex = 1
        Me.GbPilih.TabStop = False
        Me.GbPilih.Text = "Pilih Karyawan"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(216, 154)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(432, 90)
        Me.TextBox1.TabIndex = 15
        Me.TextBox1.Visible = False
        '
        'txtCari
        '
        Me.txtCari.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCari.Location = New System.Drawing.Point(95, 12)
        Me.txtCari.Name = "txtCari"
        Me.txtCari.Size = New System.Drawing.Size(607, 22)
        Me.txtCari.TabIndex = 1
        '
        'cbxHilang
        '
        Me.cbxHilang.AutoSize = True
        Me.cbxHilang.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxHilang.Location = New System.Drawing.Point(95, 302)
        Me.cbxHilang.Name = "cbxHilang"
        Me.cbxHilang.Size = New System.Drawing.Size(107, 17)
        Me.cbxHilang.TabIndex = 4
        Me.cbxHilang.Text = "&Hilangkan Semua"
        Me.cbxHilang.UseVisualStyleBackColor = True
        '
        'cbxPilih
        '
        Me.cbxPilih.AutoSize = True
        Me.cbxPilih.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxPilih.Location = New System.Drawing.Point(10, 302)
        Me.cbxPilih.Name = "cbxPilih"
        Me.cbxPilih.Size = New System.Drawing.Size(79, 17)
        Me.cbxPilih.TabIndex = 3
        Me.cbxPilih.Text = "&Pilih Semua"
        Me.cbxPilih.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "C&ari NIP / Nama"
        '
        'dg
        '
        Me.dg.AllowUserToAddRows = False
        Me.dg.AllowUserToDeleteRows = False
        Me.dg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dg.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dg.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.choose, Me.spg_barcode, Me.spg_name, Me.departmentcode, Me.nm_dept, Me.nm_bagian, Me.brand, Me.nm_sbu, Me.colEmployeeID, Me.bagiancode, Me.jabatancode})
        Me.dg.Location = New System.Drawing.Point(10, 38)
        Me.dg.Margin = New System.Windows.Forms.Padding(100)
        Me.dg.Name = "dg"
        Me.dg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dg.Size = New System.Drawing.Size(692, 250)
        Me.dg.TabIndex = 2
        '
        'choose
        '
        Me.choose.DataPropertyName = "choose"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.NullValue = "0"
        Me.choose.DefaultCellStyle = DataGridViewCellStyle1
        Me.choose.FalseValue = "0"
        Me.choose.Frozen = True
        Me.choose.HeaderText = "Pilih"
        Me.choose.Name = "choose"
        Me.choose.TrueValue = "1"
        Me.choose.Width = 32
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
        Me.spg_name.Width = 130
        '
        'departmentcode
        '
        Me.departmentcode.DataPropertyName = "departmentcode"
        Me.departmentcode.HeaderText = "departmentcode"
        Me.departmentcode.Name = "departmentcode"
        Me.departmentcode.Visible = False
        Me.departmentcode.Width = 109
        '
        'nm_dept
        '
        Me.nm_dept.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.nm_dept.DataPropertyName = "departmentname"
        Me.nm_dept.HeaderText = "Dept"
        Me.nm_dept.Name = "nm_dept"
        Me.nm_dept.ReadOnly = True
        '
        'nm_bagian
        '
        Me.nm_bagian.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.nm_bagian.DataPropertyName = "bagianname"
        Me.nm_bagian.HeaderText = "Bagian"
        Me.nm_bagian.Name = "nm_bagian"
        Me.nm_bagian.ReadOnly = True
        '
        'brand
        '
        Me.brand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.brand.DataPropertyName = "jabatanname"
        Me.brand.HeaderText = "Jabatan"
        Me.brand.Name = "brand"
        Me.brand.ReadOnly = True
        '
        'nm_sbu
        '
        Me.nm_sbu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.nm_sbu.DataPropertyName = "unitname"
        Me.nm_sbu.HeaderText = "Unit"
        Me.nm_sbu.Name = "nm_sbu"
        Me.nm_sbu.ReadOnly = True
        '
        'colEmployeeID
        '
        Me.colEmployeeID.DataPropertyName = "employee_id"
        Me.colEmployeeID.HeaderText = "Employee ID"
        Me.colEmployeeID.Name = "colEmployeeID"
        Me.colEmployeeID.Visible = False
        Me.colEmployeeID.Width = 92
        '
        'bagiancode
        '
        Me.bagiancode.DataPropertyName = "bagiancode"
        Me.bagiancode.HeaderText = "bagiancode"
        Me.bagiancode.Name = "bagiancode"
        Me.bagiancode.Visible = False
        Me.bagiancode.Width = 88
        '
        'jabatancode
        '
        Me.jabatancode.DataPropertyName = "jabatancode"
        Me.jabatancode.HeaderText = "jabatancode"
        Me.jabatancode.Name = "jabatancode"
        Me.jabatancode.Visible = False
        Me.jabatancode.Width = 91
        '
        'cbxBrand
        '
        Me.cbxBrand.AutoSize = True
        Me.cbxBrand.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxBrand.Location = New System.Drawing.Point(257, 227)
        Me.cbxBrand.Name = "cbxBrand"
        Me.cbxBrand.Size = New System.Drawing.Size(54, 17)
        Me.cbxBrand.TabIndex = 14
        Me.cbxBrand.Text = "B&rand"
        Me.cbxBrand.UseVisualStyleBackColor = True
        '
        'cmbBagianx
        '
        CheckBoxProperties1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbBagianx.CheckBoxProperties = CheckBoxProperties1
        Me.cmbBagianx.DisplayMemberSingleItem = ""
        Me.cmbBagianx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBagianx.FormattingEnabled = True
        Me.cmbBagianx.Location = New System.Drawing.Point(250, 513)
        Me.cmbBagianx.Name = "cmbBagianx"
        Me.cmbBagianx.Size = New System.Drawing.Size(142, 21)
        Me.cmbBagianx.TabIndex = 91
        Me.cmbBagianx.TabStop = False
        Me.cmbBagianx.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(250, 497)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 16
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(250, 491)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 17
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'cmbDeptx
        '
        CheckBoxProperties2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbDeptx.CheckBoxProperties = CheckBoxProperties2
        Me.cmbDeptx.DisplayMemberSingleItem = ""
        Me.cmbDeptx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDeptx.FormattingEnabled = True
        Me.cmbDeptx.Location = New System.Drawing.Point(250, 489)
        Me.cmbDeptx.Name = "cmbDeptx"
        Me.cmbDeptx.Size = New System.Drawing.Size(142, 21)
        Me.cmbDeptx.TabIndex = 131
        Me.cmbDeptx.TabStop = False
        Me.cmbDeptx.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboDept)
        Me.GroupBox2.Controls.Add(Me.cboBagian)
        Me.GroupBox2.Controls.Add(Me.CboJabatan)
        Me.GroupBox2.Controls.Add(Me.cbxDept)
        Me.GroupBox2.Controls.Add(Me.cbxJabatan)
        Me.GroupBox2.Controls.Add(Me.cbxBagian)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 63)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(712, 47)
        Me.GroupBox2.TabIndex = 132
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Struktur"
        '
        'cboDept
        '
        CheckBoxProperties3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cboDept.CheckBoxProperties = CheckBoxProperties3
        Me.cboDept.DisplayMemberSingleItem = ""
        Me.cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDept.FormattingEnabled = True
        Me.cboDept.Location = New System.Drawing.Point(85, 17)
        Me.cboDept.Name = "cboDept"
        Me.cboDept.Size = New System.Drawing.Size(142, 21)
        Me.cboDept.TabIndex = 116
        '
        'cboBagian
        '
        CheckBoxProperties4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cboBagian.CheckBoxProperties = CheckBoxProperties4
        Me.cboBagian.DisplayMemberSingleItem = ""
        Me.cboBagian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBagian.FormattingEnabled = True
        Me.cboBagian.Location = New System.Drawing.Point(315, 17)
        Me.cboBagian.Name = "cboBagian"
        Me.cboBagian.Size = New System.Drawing.Size(142, 21)
        Me.cboBagian.TabIndex = 115
        '
        'CboJabatan
        '
        CheckBoxProperties5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CboJabatan.CheckBoxProperties = CheckBoxProperties5
        Me.CboJabatan.DisplayMemberSingleItem = ""
        Me.CboJabatan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboJabatan.FormattingEnabled = True
        Me.CboJabatan.Location = New System.Drawing.Point(558, 17)
        Me.CboJabatan.Name = "CboJabatan"
        Me.CboJabatan.Size = New System.Drawing.Size(142, 21)
        Me.CboJabatan.TabIndex = 114
        '
        'cbxDept
        '
        Me.cbxDept.AutoSize = True
        Me.cbxDept.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxDept.Location = New System.Drawing.Point(13, 20)
        Me.cbxDept.Name = "cbxDept"
        Me.cbxDept.Size = New System.Drawing.Size(49, 17)
        Me.cbxDept.TabIndex = 8
        Me.cbxDept.Text = "&Dept"
        Me.cbxDept.UseVisualStyleBackColor = True
        '
        'cbxJabatan
        '
        Me.cbxJabatan.AutoSize = True
        Me.cbxJabatan.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxJabatan.Location = New System.Drawing.Point(496, 19)
        Me.cbxJabatan.Name = "cbxJabatan"
        Me.cbxJabatan.Size = New System.Drawing.Size(65, 17)
        Me.cbxJabatan.TabIndex = 12
        Me.cbxJabatan.Text = "&Jabatan"
        Me.cbxJabatan.UseVisualStyleBackColor = True
        '
        'cbxBagian
        '
        Me.cbxBagian.AutoSize = True
        Me.cbxBagian.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxBagian.Location = New System.Drawing.Point(257, 19)
        Me.cbxBagian.Name = "cbxBagian"
        Me.cbxBagian.Size = New System.Drawing.Size(58, 17)
        Me.cbxBagian.TabIndex = 10
        Me.cbxBagian.Text = "&Bagian"
        Me.cbxBagian.UseVisualStyleBackColor = True
        '
        'cmbBrand
        '
        CheckBoxProperties6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbBrand.CheckBoxProperties = CheckBoxProperties6
        Me.cmbBrand.DisplayMemberSingleItem = ""
        Me.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBrand.FormattingEnabled = True
        Me.cmbBrand.Location = New System.Drawing.Point(370, 497)
        Me.cmbBrand.Name = "cmbBrand"
        Me.cmbBrand.Size = New System.Drawing.Size(142, 21)
        Me.cmbBrand.TabIndex = 15
        '
        'cmsPrint
        '
        Me.cmsPrint.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReportAttendanceToolStripMenuItem, Me.SummaryAttendanceToolStripMenuItem, Me.ToolStripMenuItem2, Me.ReportTotalKaryawanToolStripMenuItem})
        Me.cmsPrint.Name = "cmsPrint"
        Me.cmsPrint.Size = New System.Drawing.Size(204, 114)
        '
        'ReportAttendanceToolStripMenuItem
        '
        Me.ReportAttendanceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReportByDeptToolStripMenuItem, Me.ReportByBagianToolStripMenuItem, Me.ReportBySBUToolStripMenuItem})
        Me.ReportAttendanceToolStripMenuItem.Name = "ReportAttendanceToolStripMenuItem"
        Me.ReportAttendanceToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.ReportAttendanceToolStripMenuItem.Text = "&1 Report Detail"
        '
        'ReportByDeptToolStripMenuItem
        '
        Me.ReportByDeptToolStripMenuItem.Name = "ReportByDeptToolStripMenuItem"
        Me.ReportByDeptToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.ReportByDeptToolStripMenuItem.Text = "&1 Report By Dept"
        '
        'ReportByBagianToolStripMenuItem
        '
        Me.ReportByBagianToolStripMenuItem.Name = "ReportByBagianToolStripMenuItem"
        Me.ReportByBagianToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.ReportByBagianToolStripMenuItem.Text = "&2 Report By Bagian"
        '
        'ReportBySBUToolStripMenuItem
        '
        Me.ReportBySBUToolStripMenuItem.Name = "ReportBySBUToolStripMenuItem"
        Me.ReportBySBUToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.ReportBySBUToolStripMenuItem.Text = "&3 Report By Jabatan"
        '
        'SummaryAttendanceToolStripMenuItem
        '
        Me.SummaryAttendanceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SummaryByDeptToolStripMenuItem, Me.SummaryByBagianToolStripMenuItem, Me.SummaryBySBUToolStripMenuItem})
        Me.SummaryAttendanceToolStripMenuItem.Name = "SummaryAttendanceToolStripMenuItem"
        Me.SummaryAttendanceToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.SummaryAttendanceToolStripMenuItem.Text = "&2 Report Summary"
        '
        'SummaryByDeptToolStripMenuItem
        '
        Me.SummaryByDeptToolStripMenuItem.Name = "SummaryByDeptToolStripMenuItem"
        Me.SummaryByDeptToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.SummaryByDeptToolStripMenuItem.Text = "&1 Report By Dept"
        '
        'SummaryByBagianToolStripMenuItem
        '
        Me.SummaryByBagianToolStripMenuItem.Name = "SummaryByBagianToolStripMenuItem"
        Me.SummaryByBagianToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.SummaryByBagianToolStripMenuItem.Text = "&2 Report By Bagian"
        '
        'SummaryBySBUToolStripMenuItem
        '
        Me.SummaryBySBUToolStripMenuItem.Name = "SummaryBySBUToolStripMenuItem"
        Me.SummaryBySBUToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.SummaryBySBUToolStripMenuItem.Text = "&3 Report By Jabatan"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReportByDeptToolStripMenuItem2, Me.ReportByBagianToolStripMenuItem2, Me.ReportBySBUToolStripMenuItem2})
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(203, 22)
        Me.ToolStripMenuItem2.Text = "&3 Report Kehadiran Excel"
        '
        'ReportByDeptToolStripMenuItem2
        '
        Me.ReportByDeptToolStripMenuItem2.Name = "ReportByDeptToolStripMenuItem2"
        Me.ReportByDeptToolStripMenuItem2.Size = New System.Drawing.Size(177, 22)
        Me.ReportByDeptToolStripMenuItem2.Text = "&1 Report By Dept"
        '
        'ReportByBagianToolStripMenuItem2
        '
        Me.ReportByBagianToolStripMenuItem2.Name = "ReportByBagianToolStripMenuItem2"
        Me.ReportByBagianToolStripMenuItem2.Size = New System.Drawing.Size(177, 22)
        Me.ReportByBagianToolStripMenuItem2.Text = "&2 Report By Bagian"
        '
        'ReportBySBUToolStripMenuItem2
        '
        Me.ReportBySBUToolStripMenuItem2.Name = "ReportBySBUToolStripMenuItem2"
        Me.ReportBySBUToolStripMenuItem2.Size = New System.Drawing.Size(177, 22)
        Me.ReportBySBUToolStripMenuItem2.Text = "&3 Report By Jabatan"
        '
        'ReportTotalKaryawanToolStripMenuItem
        '
        Me.ReportTotalKaryawanToolStripMenuItem.Name = "ReportTotalKaryawanToolStripMenuItem"
        Me.ReportTotalKaryawanToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.ReportTotalKaryawanToolStripMenuItem.Text = "&4 Report Total Karyawan"
        '
        'AbsenSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PowderBlue
        Me.ClientSize = New System.Drawing.Size(736, 449)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmbBrand)
        Me.Controls.Add(Me.GbPilih)
        Me.Controls.Add(Me.cmbBagianx)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pBar)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.cmbDeptx)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AbsenSummary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Summary Absensi"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GbPilih.ResumeLayout(False)
        Me.GbPilih.PerformLayout()
        CType(Me.dg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NavSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.cmsPrint.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtgen2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtgen As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents pBar As System.Windows.Forms.ProgressBar
    Friend WithEvents BackgroundWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents GbPilih As System.Windows.Forms.GroupBox
    Friend WithEvents txtCari As System.Windows.Forms.TextBox
    Friend WithEvents cbxHilang As System.Windows.Forms.CheckBox
    Friend WithEvents dg As System.Windows.Forms.DataGridView
    Friend WithEvents cmbBagianx As PresentationControls.CheckBoxComboBox
    Friend WithEvents cbxPilih As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents cmbDeptx As PresentationControls.CheckBoxComboBox
    Friend WithEvents NavSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents cbxChoose As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LblProses As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboDept As PresentationControls.CheckBoxComboBox
    Friend WithEvents cboBagian As PresentationControls.CheckBoxComboBox
    Friend WithEvents CboJabatan As PresentationControls.CheckBoxComboBox
    Friend WithEvents cmbBrand As PresentationControls.CheckBoxComboBox
    Friend WithEvents cbxDept As System.Windows.Forms.CheckBox
    Friend WithEvents cbxJabatan As System.Windows.Forms.CheckBox
    Friend WithEvents cbxBagian As System.Windows.Forms.CheckBox
    Friend WithEvents cbxBrand As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents choose As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents spg_barcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents spg_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents departmentcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nm_dept As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nm_bagian As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents brand As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nm_sbu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEmployeeID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bagiancode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents jabatancode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmsPrint As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ReportAttendanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportByBagianToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportBySBUToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportByDeptToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SummaryAttendanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SummaryByBagianToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SummaryBySBUToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SummaryByDeptToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportByBagianToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportBySBUToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportByDeptToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportTotalKaryawanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
