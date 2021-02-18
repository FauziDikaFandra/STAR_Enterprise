<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GenerateForm
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.LblProses = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbxChoose = New System.Windows.Forms.CheckBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.pBar = New System.Windows.Forms.ProgressBar
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtgen2 = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtgen = New System.Windows.Forms.DateTimePicker
        Me.btnProses = New System.Windows.Forms.Button
        Me.BackgroundWorker = New System.ComponentModel.BackgroundWorker
        Me.GbPilih = New System.Windows.Forms.GroupBox
        Me.txtCari = New System.Windows.Forms.TextBox
        Me.cbxHilang = New System.Windows.Forms.CheckBox
        Me.dg = New System.Windows.Forms.DataGridView
        Me.choose = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.spg_barcode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.spg_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nm_dept = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nm_bagian = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.brand = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nm_sbu = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colEmployeeID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmbBagianx = New PresentationControls.CheckBoxComboBox
        Me.cbxPilih = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.cmbDeptx = New PresentationControls.CheckBoxComboBox
        Me.NavSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GbPilih.SuspendLayout()
        CType(Me.dg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NavSource1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.LblProses)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cbxChoose)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.pBar)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dtgen2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.dtgen)
        Me.GroupBox1.Controls.Add(Me.btnProses)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(712, 81)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter Date"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(289, 33)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
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
        'pBar
        '
        Me.pBar.Location = New System.Drawing.Point(10, 59)
        Me.pBar.Name = "pBar"
        Me.pBar.Size = New System.Drawing.Size(692, 18)
        Me.pBar.TabIndex = 7
        Me.pBar.Visible = False
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
        'btnProses
        '
        Me.btnProses.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProses.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProses.Location = New System.Drawing.Point(617, 11)
        Me.btnProses.Name = "btnProses"
        Me.btnProses.Size = New System.Drawing.Size(85, 31)
        Me.btnProses.TabIndex = 6
        Me.btnProses.Text = "&Generate"
        Me.btnProses.UseVisualStyleBackColor = True
        '
        'BackgroundWorker
        '
        '
        'GbPilih
        '
        Me.GbPilih.Controls.Add(Me.txtCari)
        Me.GbPilih.Controls.Add(Me.cbxHilang)
        Me.GbPilih.Controls.Add(Me.dg)
        Me.GbPilih.Controls.Add(Me.cmbBagianx)
        Me.GbPilih.Controls.Add(Me.cbxPilih)
        Me.GbPilih.Controls.Add(Me.Label2)
        Me.GbPilih.Controls.Add(Me.Button2)
        Me.GbPilih.Controls.Add(Me.Button3)
        Me.GbPilih.Controls.Add(Me.cmbDeptx)
        Me.GbPilih.Location = New System.Drawing.Point(12, 97)
        Me.GbPilih.Name = "GbPilih"
        Me.GbPilih.Size = New System.Drawing.Size(712, 310)
        Me.GbPilih.TabIndex = 1
        Me.GbPilih.TabStop = False
        Me.GbPilih.Text = "Pilih Karyawan"
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
        Me.cbxHilang.Location = New System.Drawing.Point(95, 291)
        Me.cbxHilang.Name = "cbxHilang"
        Me.cbxHilang.Size = New System.Drawing.Size(107, 17)
        Me.cbxHilang.TabIndex = 4
        Me.cbxHilang.Text = "&Hilangkan Semua"
        Me.cbxHilang.UseVisualStyleBackColor = True
        '
        'dg
        '
        Me.dg.AllowUserToAddRows = False
        Me.dg.AllowUserToDeleteRows = False
        Me.dg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dg.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dg.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.choose, Me.spg_barcode, Me.spg_name, Me.nm_dept, Me.nm_bagian, Me.brand, Me.nm_sbu, Me.colEmployeeID})
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
        Me.colEmployeeID.Visible = False
        Me.colEmployeeID.Width = 92
        '
        'cmbBagianx
        '
        CheckBoxProperties1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbBagianx.CheckBoxProperties = CheckBoxProperties1
        Me.cmbBagianx.DisplayMemberSingleItem = ""
        Me.cmbBagianx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBagianx.FormattingEnabled = True
        Me.cmbBagianx.Location = New System.Drawing.Point(49, 235)
        Me.cmbBagianx.Name = "cmbBagianx"
        Me.cmbBagianx.Size = New System.Drawing.Size(142, 21)
        Me.cmbBagianx.TabIndex = 91
        Me.cmbBagianx.TabStop = False
        Me.cmbBagianx.Visible = False
        '
        'cbxPilih
        '
        Me.cbxPilih.AutoSize = True
        Me.cbxPilih.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxPilih.Location = New System.Drawing.Point(10, 291)
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
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(49, 177)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 16
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(49, 206)
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
        Me.cmbDeptx.Location = New System.Drawing.Point(49, 260)
        Me.cmbDeptx.Name = "cmbDeptx"
        Me.cmbDeptx.Size = New System.Drawing.Size(142, 21)
        Me.cmbDeptx.TabIndex = 131
        Me.cmbDeptx.TabStop = False
        Me.cmbDeptx.Visible = False
        '
        'GenerateForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PowderBlue
        Me.ClientSize = New System.Drawing.Size(736, 417)
        Me.Controls.Add(Me.GbPilih)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GenerateForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generate Absensi"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GbPilih.ResumeLayout(False)
        Me.GbPilih.PerformLayout()
        CType(Me.dg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NavSource1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents btnProses As System.Windows.Forms.Button
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
    Friend WithEvents choose As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents spg_barcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents spg_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nm_dept As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nm_bagian As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents brand As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nm_sbu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEmployeeID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LblProses As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
