<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LeaveForm
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
        Me.lblTipe = New System.Windows.Forms.Label
        Me.txtEmployeeID = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtNIP = New System.Windows.Forms.TextBox
        Me.txtNama = New System.Windows.Forms.TextBox
        Me.lblJudul = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cbxCutiTahunan = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.dtStartdate = New System.Windows.Forms.DateTimePicker
        Me.dtEnddate = New System.Windows.Forms.DateTimePicker
        Me.txtStatus = New System.Windows.Forms.TextBox
        Me.dtLeaveSource = New System.Windows.Forms.DateTimePicker
        Me.txtTakenLeave = New System.Windows.Forms.TextBox
        Me.txtAvailableLeave = New System.Windows.Forms.TextBox
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.txtDept = New System.Windows.Forms.TextBox
        Me.txtBagian = New System.Windows.Forms.TextBox
        Me.txtJabatan = New System.Windows.Forms.TextBox
        Me.txtLeaveType = New System.Windows.Forms.ComboBox
        Me.BtnCariLeave = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.BtnCariNIP = New System.Windows.Forms.Button
        Me.gbPilih = New System.Windows.Forms.GroupBox
        Me.dgKar = New System.Windows.Forms.DataGridView
        Me.spg_barcode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.spg_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nm_dept = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nm_bagian = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colEmployeeID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtCari = New System.Windows.Forms.TextBox
        Me.NavSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtEmployeeCutiID = New System.Windows.Forms.Label
        Me.txtLeaveTypeID = New System.Windows.Forms.Label
        Me.txtTCutiID = New System.Windows.Forms.Label
        Me.gbPilih.SuspendLayout()
        CType(Me.dgKar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NavSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTipe
        '
        Me.lblTipe.AutoSize = True
        Me.lblTipe.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipe.Location = New System.Drawing.Point(352, 189)
        Me.lblTipe.Name = "lblTipe"
        Me.lblTipe.Size = New System.Drawing.Size(35, 13)
        Me.lblTipe.TabIndex = 202
        Me.lblTipe.Text = "lbltipe"
        '
        'txtEmployeeID
        '
        Me.txtEmployeeID.AutoSize = True
        Me.txtEmployeeID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmployeeID.Location = New System.Drawing.Point(352, 216)
        Me.txtEmployeeID.Name = "txtEmployeeID"
        Me.txtEmployeeID.Size = New System.Drawing.Size(78, 13)
        Me.txtEmployeeID.TabIndex = 201
        Me.txtEmployeeID.Text = "txtEmployeeID"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(13, 57)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(24, 13)
        Me.Label16.TabIndex = 197
        Me.Label16.Text = "&NIP"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(13, 84)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(85, 13)
        Me.Label13.TabIndex = 199
        Me.Label13.Text = "N&ama Karyawan"
        '
        'txtNIP
        '
        Me.txtNIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNIP.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNIP.Location = New System.Drawing.Point(113, 55)
        Me.txtNIP.MaxLength = 20
        Me.txtNIP.Name = "txtNIP"
        Me.txtNIP.Size = New System.Drawing.Size(163, 21)
        Me.txtNIP.TabIndex = 198
        '
        'txtNama
        '
        Me.txtNama.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNama.Enabled = False
        Me.txtNama.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNama.Location = New System.Drawing.Point(113, 82)
        Me.txtNama.MaxLength = 30
        Me.txtNama.Name = "txtNama"
        Me.txtNama.Size = New System.Drawing.Size(198, 21)
        Me.txtNama.TabIndex = 200
        '
        'lblJudul
        '
        Me.lblJudul.BackColor = System.Drawing.Color.Red
        Me.lblJudul.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblJudul.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJudul.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblJudul.Location = New System.Drawing.Point(0, 0)
        Me.lblJudul.Name = "lblJudul"
        Me.lblJudul.Size = New System.Drawing.Size(650, 50)
        Me.lblJudul.TabIndex = 203
        Me.lblJudul.Text = "Generate Absensi"
        Me.lblJudul.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(347, 138)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 204
        Me.Label1.Text = "&Status"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 205
        Me.Label2.Text = "Startdate"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 140)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 206
        Me.Label3.Text = "Enddate"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 192)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 208
        Me.Label4.Text = "Leave Type"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 169)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 207
        Me.Label5.Text = "Leave Source"
        '
        'cbxCutiTahunan
        '
        Me.cbxCutiTahunan.AutoSize = True
        Me.cbxCutiTahunan.Location = New System.Drawing.Point(530, 193)
        Me.cbxCutiTahunan.Name = "cbxCutiTahunan"
        Me.cbxCutiTahunan.Size = New System.Drawing.Size(90, 17)
        Me.cbxCutiTahunan.TabIndex = 209
        Me.cbxCutiTahunan.Text = "Cuti Tahunan"
        Me.cbxCutiTahunan.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(347, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 214
        Me.Label6.Text = "Nama Bagian"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(347, 57)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 213
        Me.Label7.Text = "Nama Dept"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(347, 165)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 13)
        Me.Label8.TabIndex = 212
        Me.Label8.Text = "Available Leave"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(13, 218)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 13)
        Me.Label9.TabIndex = 211
        Me.Label9.Text = "Taken Leave"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(13, 245)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 13)
        Me.Label10.TabIndex = 210
        Me.Label10.Text = "Description"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(347, 113)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(76, 13)
        Me.Label11.TabIndex = 215
        Me.Label11.Text = "Nama Jabatan"
        '
        'dtStartdate
        '
        Me.dtStartdate.CustomFormat = "dd-MMMM-yyyy"
        Me.dtStartdate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtStartdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtStartdate.Location = New System.Drawing.Point(113, 109)
        Me.dtStartdate.Name = "dtStartdate"
        Me.dtStartdate.ShowCheckBox = True
        Me.dtStartdate.Size = New System.Drawing.Size(198, 21)
        Me.dtStartdate.TabIndex = 216
        '
        'dtEnddate
        '
        Me.dtEnddate.CustomFormat = "dd-MMMM-yyyy"
        Me.dtEnddate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtEnddate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtEnddate.Location = New System.Drawing.Point(113, 136)
        Me.dtEnddate.Name = "dtEnddate"
        Me.dtEnddate.ShowCheckBox = True
        Me.dtEnddate.Size = New System.Drawing.Size(198, 21)
        Me.dtEnddate.TabIndex = 217
        '
        'txtStatus
        '
        Me.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStatus.Enabled = False
        Me.txtStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(435, 136)
        Me.txtStatus.MaxLength = 30
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(185, 21)
        Me.txtStatus.TabIndex = 218
        '
        'dtLeaveSource
        '
        Me.dtLeaveSource.CustomFormat = "dd-MMMM-yyyy"
        Me.dtLeaveSource.Enabled = False
        Me.dtLeaveSource.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtLeaveSource.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtLeaveSource.Location = New System.Drawing.Point(113, 163)
        Me.dtLeaveSource.Name = "dtLeaveSource"
        Me.dtLeaveSource.ShowCheckBox = True
        Me.dtLeaveSource.Size = New System.Drawing.Size(163, 21)
        Me.dtLeaveSource.TabIndex = 219
        '
        'txtTakenLeave
        '
        Me.txtTakenLeave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTakenLeave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTakenLeave.Location = New System.Drawing.Point(113, 216)
        Me.txtTakenLeave.MaxLength = 20
        Me.txtTakenLeave.Name = "txtTakenLeave"
        Me.txtTakenLeave.Size = New System.Drawing.Size(198, 21)
        Me.txtTakenLeave.TabIndex = 221
        '
        'txtAvailableLeave
        '
        Me.txtAvailableLeave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAvailableLeave.Enabled = False
        Me.txtAvailableLeave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAvailableLeave.Location = New System.Drawing.Point(435, 163)
        Me.txtAvailableLeave.MaxLength = 20
        Me.txtAvailableLeave.Name = "txtAvailableLeave"
        Me.txtAvailableLeave.Size = New System.Drawing.Size(185, 21)
        Me.txtAvailableLeave.TabIndex = 222
        '
        'txtDescription
        '
        Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(113, 243)
        Me.txtDescription.MaxLength = 20
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(198, 83)
        Me.txtDescription.TabIndex = 223
        '
        'txtDept
        '
        Me.txtDept.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDept.Enabled = False
        Me.txtDept.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDept.Location = New System.Drawing.Point(435, 55)
        Me.txtDept.MaxLength = 30
        Me.txtDept.Name = "txtDept"
        Me.txtDept.Size = New System.Drawing.Size(185, 21)
        Me.txtDept.TabIndex = 224
        '
        'txtBagian
        '
        Me.txtBagian.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBagian.Enabled = False
        Me.txtBagian.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBagian.Location = New System.Drawing.Point(435, 82)
        Me.txtBagian.MaxLength = 30
        Me.txtBagian.Name = "txtBagian"
        Me.txtBagian.Size = New System.Drawing.Size(185, 21)
        Me.txtBagian.TabIndex = 225
        '
        'txtJabatan
        '
        Me.txtJabatan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJabatan.Enabled = False
        Me.txtJabatan.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJabatan.Location = New System.Drawing.Point(435, 109)
        Me.txtJabatan.MaxLength = 30
        Me.txtJabatan.Name = "txtJabatan"
        Me.txtJabatan.Size = New System.Drawing.Size(185, 21)
        Me.txtJabatan.TabIndex = 226
        '
        'txtLeaveType
        '
        Me.txtLeaveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtLeaveType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLeaveType.FormattingEnabled = True
        Me.txtLeaveType.Location = New System.Drawing.Point(113, 189)
        Me.txtLeaveType.Name = "txtLeaveType"
        Me.txtLeaveType.Size = New System.Drawing.Size(198, 21)
        Me.txtLeaveType.TabIndex = 227
        '
        'BtnCariLeave
        '
        Me.BtnCariLeave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCariLeave.Location = New System.Drawing.Point(282, 163)
        Me.BtnCariLeave.Name = "BtnCariLeave"
        Me.BtnCariLeave.Size = New System.Drawing.Size(29, 23)
        Me.BtnCariLeave.TabIndex = 228
        Me.BtnCariLeave.Text = "..."
        Me.BtnCariLeave.UseVisualStyleBackColor = True
        Me.BtnCariLeave.Visible = False
        '
        'BtnSave
        '
        Me.BtnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.Color.Red
        Me.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSave.Location = New System.Drawing.Point(560, 216)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(60, 30)
        Me.BtnSave.TabIndex = 229
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'BtnCariNIP
        '
        Me.BtnCariNIP.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCariNIP.Location = New System.Drawing.Point(282, 53)
        Me.BtnCariNIP.Name = "BtnCariNIP"
        Me.BtnCariNIP.Size = New System.Drawing.Size(29, 23)
        Me.BtnCariNIP.TabIndex = 230
        Me.BtnCariNIP.Text = "..."
        Me.BtnCariNIP.UseVisualStyleBackColor = True
        '
        'gbPilih
        '
        Me.gbPilih.Controls.Add(Me.dgKar)
        Me.gbPilih.Controls.Add(Me.Label12)
        Me.gbPilih.Controls.Add(Me.txtCari)
        Me.gbPilih.Location = New System.Drawing.Point(113, 332)
        Me.gbPilih.Name = "gbPilih"
        Me.gbPilih.Size = New System.Drawing.Size(525, 244)
        Me.gbPilih.TabIndex = 231
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
        Me.dgKar.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.spg_barcode, Me.spg_name, Me.nm_dept, Me.nm_bagian, Me.colEmployeeID})
        Me.dgKar.Location = New System.Drawing.Point(9, 44)
        Me.dgKar.Margin = New System.Windows.Forms.Padding(100)
        Me.dgKar.Name = "dgKar"
        Me.dgKar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgKar.Size = New System.Drawing.Size(508, 191)
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
        'colEmployeeID
        '
        Me.colEmployeeID.DataPropertyName = "employee_id"
        Me.colEmployeeID.Frozen = True
        Me.colEmployeeID.HeaderText = "Employee ID"
        Me.colEmployeeID.Name = "colEmployeeID"
        Me.colEmployeeID.ReadOnly = True
        Me.colEmployeeID.Width = 85
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(34, 13)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "Nama"
        '
        'txtCari
        '
        Me.txtCari.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCari.Location = New System.Drawing.Point(47, 16)
        Me.txtCari.Name = "txtCari"
        Me.txtCari.Size = New System.Drawing.Size(470, 21)
        Me.txtCari.TabIndex = 25
        '
        'txtEmployeeCutiID
        '
        Me.txtEmployeeCutiID.AutoSize = True
        Me.txtEmployeeCutiID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmployeeCutiID.Location = New System.Drawing.Point(352, 245)
        Me.txtEmployeeCutiID.Name = "txtEmployeeCutiID"
        Me.txtEmployeeCutiID.Size = New System.Drawing.Size(97, 13)
        Me.txtEmployeeCutiID.TabIndex = 232
        Me.txtEmployeeCutiID.Text = "txtEmployeeCutiID"
        '
        'txtLeaveTypeID
        '
        Me.txtLeaveTypeID.AutoSize = True
        Me.txtLeaveTypeID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLeaveTypeID.Location = New System.Drawing.Point(352, 273)
        Me.txtLeaveTypeID.Name = "txtLeaveTypeID"
        Me.txtLeaveTypeID.Size = New System.Drawing.Size(85, 13)
        Me.txtLeaveTypeID.TabIndex = 233
        Me.txtLeaveTypeID.Text = "txtLeaveTypeID"
        '
        'txtTCutiID
        '
        Me.txtTCutiID.AutoSize = True
        Me.txtTCutiID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTCutiID.Location = New System.Drawing.Point(352, 296)
        Me.txtTCutiID.Name = "txtTCutiID"
        Me.txtTCutiID.Size = New System.Drawing.Size(57, 13)
        Me.txtTCutiID.TabIndex = 234
        Me.txtTCutiID.Text = "txtTCutiID"
        '
        'LeaveForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PowderBlue
        Me.ClientSize = New System.Drawing.Size(650, 345)
        Me.Controls.Add(Me.txtTCutiID)
        Me.Controls.Add(Me.txtLeaveTypeID)
        Me.Controls.Add(Me.txtEmployeeCutiID)
        Me.Controls.Add(Me.gbPilih)
        Me.Controls.Add(Me.BtnCariNIP)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnCariLeave)
        Me.Controls.Add(Me.txtLeaveType)
        Me.Controls.Add(Me.txtJabatan)
        Me.Controls.Add(Me.txtBagian)
        Me.Controls.Add(Me.txtDept)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.txtAvailableLeave)
        Me.Controls.Add(Me.txtTakenLeave)
        Me.Controls.Add(Me.dtLeaveSource)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.dtEnddate)
        Me.Controls.Add(Me.dtStartdate)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cbxCutiTahunan)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblJudul)
        Me.Controls.Add(Me.lblTipe)
        Me.Controls.Add(Me.txtEmployeeID)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtNIP)
        Me.Controls.Add(Me.txtNama)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LeaveForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Leave Form"
        Me.gbPilih.ResumeLayout(False)
        Me.gbPilih.PerformLayout()
        CType(Me.dgKar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NavSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTipe As System.Windows.Forms.Label
    Friend WithEvents txtEmployeeID As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtNIP As System.Windows.Forms.TextBox
    Friend WithEvents txtNama As System.Windows.Forms.TextBox
    Friend WithEvents lblJudul As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbxCutiTahunan As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtStartdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtEnddate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents dtLeaveSource As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtTakenLeave As System.Windows.Forms.TextBox
    Friend WithEvents txtAvailableLeave As System.Windows.Forms.TextBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtDept As System.Windows.Forms.TextBox
    Friend WithEvents txtBagian As System.Windows.Forms.TextBox
    Friend WithEvents txtJabatan As System.Windows.Forms.TextBox
    Friend WithEvents txtLeaveType As System.Windows.Forms.ComboBox
    Friend WithEvents BtnCariLeave As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnCariNIP As System.Windows.Forms.Button
    Friend WithEvents gbPilih As System.Windows.Forms.GroupBox
    Friend WithEvents dgKar As System.Windows.Forms.DataGridView
    Friend WithEvents spg_barcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents spg_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nm_dept As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nm_bagian As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEmployeeID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCari As System.Windows.Forms.TextBox
    Friend WithEvents NavSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents txtEmployeeCutiID As System.Windows.Forms.Label
    Friend WithEvents txtLeaveTypeID As System.Windows.Forms.Label
    Friend WithEvents txtTCutiID As System.Windows.Forms.Label
End Class
