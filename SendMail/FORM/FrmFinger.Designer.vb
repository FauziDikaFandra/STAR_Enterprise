<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFinger
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label14 = New System.Windows.Forms.Label
        Me.CboFinger1 = New System.Windows.Forms.ComboBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.pBar = New System.Windows.Forms.ProgressBar
        Me.Button2 = New System.Windows.Forms.Button
        Me.cbxHilang = New System.Windows.Forms.CheckBox
        Me.cbxPilih = New System.Windows.Forms.CheckBox
        Me.BtnUpdateName = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.BtnSinkron = New System.Windows.Forms.Button
        Me.dg1 = New System.Windows.Forms.DataGridView
        Me.choose = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column16 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.BtnNonActive = New System.Windows.Forms.Button
        Me.BtnActive = New System.Windows.Forms.Button
        Me.BtnDelete = New System.Windows.Forms.Button
        Me.Lbl1 = New System.Windows.Forms.Label
        Me.BtnLihat1 = New System.Windows.Forms.Button
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.NavFinger = New System.Windows.Forms.BindingSource(Me.components)
        Me.BwDelete = New System.ComponentModel.BackgroundWorker
        Me.BtnClose = New System.Windows.Forms.Button
        Me.GroupBox5.SuspendLayout()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NavFinger, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(9, 23)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(58, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Pilih &Finger"
        '
        'CboFinger1
        '
        Me.CboFinger1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboFinger1.Enabled = False
        Me.CboFinger1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboFinger1.FormattingEnabled = True
        Me.CboFinger1.Location = New System.Drawing.Point(79, 20)
        Me.CboFinger1.Name = "CboFinger1"
        Me.CboFinger1.Size = New System.Drawing.Size(307, 21)
        Me.CboFinger1.TabIndex = 1
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.BtnClose)
        Me.GroupBox5.Controls.Add(Me.Button3)
        Me.GroupBox5.Controls.Add(Me.pBar)
        Me.GroupBox5.Controls.Add(Me.Button2)
        Me.GroupBox5.Controls.Add(Me.cbxHilang)
        Me.GroupBox5.Controls.Add(Me.cbxPilih)
        Me.GroupBox5.Controls.Add(Me.BtnUpdateName)
        Me.GroupBox5.Controls.Add(Me.Button1)
        Me.GroupBox5.Controls.Add(Me.BtnSinkron)
        Me.GroupBox5.Controls.Add(Me.dg1)
        Me.GroupBox5.Controls.Add(Me.txtName)
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.BtnNonActive)
        Me.GroupBox5.Controls.Add(Me.BtnActive)
        Me.GroupBox5.Controls.Add(Me.BtnDelete)
        Me.GroupBox5.Controls.Add(Me.Lbl1)
        Me.GroupBox5.Controls.Add(Me.BtnLihat1)
        Me.GroupBox5.Controls.Add(Me.CboFinger1)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(621, 365)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Finger 1"
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(214, 311)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(101, 21)
        Me.Button3.TabIndex = 27
        Me.Button3.Text = "&Update Nama"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'pBar
        '
        Me.pBar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pBar.Location = New System.Drawing.Point(93, 341)
        Me.pBar.Name = "pBar"
        Me.pBar.Size = New System.Drawing.Size(516, 18)
        Me.pBar.TabIndex = 26
        Me.pBar.Visible = False
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(429, 49)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 21)
        Me.Button2.TabIndex = 23
        Me.Button2.Text = "&Delete"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'cbxHilang
        '
        Me.cbxHilang.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbxHilang.AutoSize = True
        Me.cbxHilang.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxHilang.Location = New System.Drawing.Point(502, 319)
        Me.cbxHilang.Name = "cbxHilang"
        Me.cbxHilang.Size = New System.Drawing.Size(107, 17)
        Me.cbxHilang.TabIndex = 25
        Me.cbxHilang.Text = "&Hilangkan Semua"
        Me.cbxHilang.UseVisualStyleBackColor = True
        '
        'cbxPilih
        '
        Me.cbxPilih.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbxPilih.AutoSize = True
        Me.cbxPilih.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxPilih.Location = New System.Drawing.Point(417, 319)
        Me.cbxPilih.Name = "cbxPilih"
        Me.cbxPilih.Size = New System.Drawing.Size(79, 17)
        Me.cbxPilih.TabIndex = 24
        Me.cbxPilih.Text = "Pilih &Semua"
        Me.cbxPilih.UseVisualStyleBackColor = True
        '
        'BtnUpdateName
        '
        Me.BtnUpdateName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnUpdateName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdateName.Location = New System.Drawing.Point(244, 338)
        Me.BtnUpdateName.Name = "BtnUpdateName"
        Me.BtnUpdateName.Size = New System.Drawing.Size(101, 21)
        Me.BtnUpdateName.TabIndex = 23
        Me.BtnUpdateName.Text = "&Update Nama"
        Me.BtnUpdateName.UseVisualStyleBackColor = True
        Me.BtnUpdateName.Visible = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(392, 338)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 21)
        Me.Button1.TabIndex = 22
        Me.Button1.Text = "&Delete"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'BtnSinkron
        '
        Me.BtnSinkron.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnSinkron.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSinkron.Location = New System.Drawing.Point(285, 338)
        Me.BtnSinkron.Name = "BtnSinkron"
        Me.BtnSinkron.Size = New System.Drawing.Size(101, 21)
        Me.BtnSinkron.TabIndex = 21
        Me.BtnSinkron.Text = "&Sinkron Finger"
        Me.BtnSinkron.UseVisualStyleBackColor = True
        Me.BtnSinkron.Visible = False
        '
        'dg1
        '
        Me.dg1.AllowUserToAddRows = False
        Me.dg1.AllowUserToDeleteRows = False
        Me.dg1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dg1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dg1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.choose, Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column14, Me.Column15, Me.Column16, Me.Column17})
        Me.dg1.Location = New System.Drawing.Point(12, 77)
        Me.dg1.Margin = New System.Windows.Forms.Padding(100)
        Me.dg1.Name = "dg1"
        Me.dg1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dg1.Size = New System.Drawing.Size(597, 231)
        Me.dg1.TabIndex = 20
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
        Me.choose.Width = 31
        '
        'Column10
        '
        Me.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column10.DataPropertyName = "fingercode"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column10.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column10.HeaderText = "User ID"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Width = 68
        '
        'Column11
        '
        Me.Column11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column11.DataPropertyName = "name"
        Me.Column11.HeaderText = "Nama"
        Me.Column11.Name = "Column11"
        Me.Column11.Width = 59
        '
        'Column12
        '
        Me.Column12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column12.DataPropertyName = "fingerindex"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column12.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column12.HeaderText = "Finger Index"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        Me.Column12.Width = 60
        '
        'Column13
        '
        Me.Column13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column13.DataPropertyName = "tmp"
        Me.Column13.HeaderText = "TMP Data"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        Me.Column13.Width = 72
        '
        'Column14
        '
        Me.Column14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column14.DataPropertyName = "privilege"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column14.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column14.HeaderText = "Privilege"
        Me.Column14.Name = "Column14"
        Me.Column14.Width = 72
        '
        'Column15
        '
        Me.Column15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column15.DataPropertyName = "pass"
        Me.Column15.HeaderText = "Pass"
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        Me.Column15.Width = 54
        '
        'Column16
        '
        Me.Column16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column16.DataPropertyName = "enabled"
        Me.Column16.FalseValue = "0"
        Me.Column16.HeaderText = "Enabled"
        Me.Column16.Name = "Column16"
        Me.Column16.ReadOnly = True
        Me.Column16.TrueValue = "1"
        Me.Column16.Width = 51
        '
        'Column17
        '
        Me.Column17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column17.DataPropertyName = "flag"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column17.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column17.HeaderText = "Flag"
        Me.Column17.Name = "Column17"
        Me.Column17.ReadOnly = True
        Me.Column17.Width = 52
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(79, 46)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(307, 21)
        Me.txtName.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Cari Nama"
        '
        'BtnNonActive
        '
        Me.BtnNonActive.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnNonActive.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNonActive.Location = New System.Drawing.Point(429, 315)
        Me.BtnNonActive.Name = "BtnNonActive"
        Me.BtnNonActive.Size = New System.Drawing.Size(75, 21)
        Me.BtnNonActive.TabIndex = 8
        Me.BtnNonActive.Text = "&Non Aktif"
        Me.BtnNonActive.UseVisualStyleBackColor = True
        Me.BtnNonActive.Visible = False
        '
        'BtnActive
        '
        Me.BtnActive.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnActive.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnActive.Location = New System.Drawing.Point(348, 315)
        Me.BtnActive.Name = "BtnActive"
        Me.BtnActive.Size = New System.Drawing.Size(75, 21)
        Me.BtnActive.TabIndex = 7
        Me.BtnActive.Text = "&Aktif"
        Me.BtnActive.UseVisualStyleBackColor = True
        Me.BtnActive.Visible = False
        '
        'BtnDelete
        '
        Me.BtnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnDelete.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDelete.Location = New System.Drawing.Point(12, 316)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(75, 21)
        Me.BtnDelete.TabIndex = 6
        Me.BtnDelete.Text = "&Delete"
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'Lbl1
        '
        Me.Lbl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lbl1.AutoSize = True
        Me.Lbl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl1.Location = New System.Drawing.Point(9, 342)
        Me.Lbl1.Name = "Lbl1"
        Me.Lbl1.Size = New System.Drawing.Size(82, 13)
        Me.Lbl1.TabIndex = 9
        Me.Lbl1.Text = "Total Data : 0"
        '
        'BtnLihat1
        '
        Me.BtnLihat1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLihat1.Location = New System.Drawing.Point(401, 20)
        Me.BtnLihat1.Name = "BtnLihat1"
        Me.BtnLihat1.Size = New System.Drawing.Size(103, 21)
        Me.BtnLihat1.TabIndex = 2
        Me.BtnLihat1.Text = "&Lihat Data Finger"
        Me.BtnLihat1.UseVisualStyleBackColor = True
        '
        'BackgroundWorker1
        '
        '
        'BwDelete
        '
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.Location = New System.Drawing.Point(93, 316)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(75, 21)
        Me.BtnClose.TabIndex = 28
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'FrmFinger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PowderBlue
        Me.ClientSize = New System.Drawing.Size(645, 389)
        Me.Controls.Add(Me.GroupBox5)
        Me.Name = "FrmFinger"
        Me.Text = "Data Finger"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NavFinger, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CboFinger1 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnLihat1 As System.Windows.Forms.Button
    Friend WithEvents Lbl1 As System.Windows.Forms.Label
    Friend WithEvents BtnNonActive As System.Windows.Forms.Button
    Friend WithEvents BtnActive As System.Windows.Forms.Button
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents dg1 As System.Windows.Forms.DataGridView
    Friend WithEvents BtnSinkron As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents BtnUpdateName As System.Windows.Forms.Button
    Friend WithEvents cbxHilang As System.Windows.Forms.CheckBox
    Friend WithEvents cbxPilih As System.Windows.Forms.CheckBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents pBar As System.Windows.Forms.ProgressBar
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents NavFinger As System.Windows.Forms.BindingSource
    Friend WithEvents choose As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column16 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BwDelete As System.ComponentModel.BackgroundWorker
    Friend WithEvents BtnClose As System.Windows.Forms.Button
End Class
