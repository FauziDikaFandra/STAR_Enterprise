'<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmanalyzer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    '<System.Diagnostics.DebuggerNonUserCode()>
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
    '<System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.st = New System.Windows.Forms.StatusStrip()
        Me.ts1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ts2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ts3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ts4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ts5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.cm = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PerTanggalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PerJamToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GrandTotalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbstatuscard = New System.Windows.Forms.GroupBox()
        Me.rdbuton3 = New System.Windows.Forms.RadioButton()
        Me.rdbuton2 = New System.Windows.Forms.RadioButton()
        Me.rdbuton = New System.Windows.Forms.RadioButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.gbsales = New System.Windows.Forms.GroupBox()
        Me.rdsalescustom = New System.Windows.Forms.RadioButton()
        Me.rdallsales = New System.Windows.Forms.RadioButton()
        Me.txtvalue1 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.gbsbu = New System.Windows.Forms.GroupBox()
        Me.chksupportcenter = New System.Windows.Forms.CheckBox()
        Me.chkmens = New System.Windows.Forms.CheckBox()
        Me.chkladies2 = New System.Windows.Forms.CheckBox()
        Me.chkladies1 = New System.Windows.Forms.CheckBox()
        Me.chkhome = New System.Windows.Forms.CheckBox()
        Me.chkchildrend = New System.Windows.Forms.CheckBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.gbstatuskelipatan = New System.Windows.Forms.GroupBox()
        Me.chkkelipatan = New System.Windows.Forms.CheckBox()
        Me.chknonkelipatan = New System.Windows.Forms.CheckBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.gbcategory = New System.Windows.Forms.GroupBox()
        Me.chklistcategory = New System.Windows.Forms.CheckedListBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.gbbrand = New System.Windows.Forms.GroupBox()
        Me.chklistbrand = New System.Windows.Forms.CheckedListBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.gbdays = New System.Windows.Forms.GroupBox()
        Me.chkkhamis = New System.Windows.Forms.CheckBox()
        Me.chkminggu = New System.Windows.Forms.CheckBox()
        Me.chksabtu = New System.Windows.Forms.CheckBox()
        Me.chkjumat = New System.Windows.Forms.CheckBox()
        Me.chkrabu = New System.Windows.Forms.CheckBox()
        Me.chkselasa = New System.Windows.Forms.CheckBox()
        Me.chksenin = New System.Windows.Forms.CheckBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.gbpersentase = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtpercentage3 = New System.Windows.Forms.TextBox()
        Me.txtpercentage2 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtpercentage1 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.gbstore = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chks003 = New System.Windows.Forms.CheckBox()
        Me.chks002 = New System.Windows.Forms.CheckBox()
        Me.chks001 = New System.Windows.Forms.CheckBox()
        Me.gbperjam = New System.Windows.Forms.GroupBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.gbtanggal = New System.Windows.Forms.GroupBox()
        Me.dtpdate4 = New System.Windows.Forms.DateTimePicker()
        Me.dtpdate3 = New System.Windows.Forms.DateTimePicker()
        Me.dtpdate2 = New System.Windows.Forms.DateTimePicker()
        Me.dtpdate1 = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnprocess = New System.Windows.Forms.Button()
        Me.tm1 = New System.Windows.Forms.Timer(Me.components)
        Me.st.SuspendLayout()
        Me.cm.SuspendLayout()
        Me.gbstatuscard.SuspendLayout()
        Me.gbsales.SuspendLayout()
        Me.gbsbu.SuspendLayout()
        Me.gbstatuskelipatan.SuspendLayout()
        Me.gbcategory.SuspendLayout()
        Me.gbbrand.SuspendLayout()
        Me.gbdays.SuspendLayout()
        Me.gbpersentase.SuspendLayout()
        Me.gbstore.SuspendLayout()
        Me.gbperjam.SuspendLayout()
        Me.gbtanggal.SuspendLayout()
        Me.SuspendLayout()
        '
        'st
        '
        Me.st.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts1, Me.ts2, Me.ts3, Me.ts4, Me.ts5})
        Me.st.Location = New System.Drawing.Point(0, 392)
        Me.st.Name = "st"
        Me.st.Size = New System.Drawing.Size(804, 22)
        Me.st.TabIndex = 0
        Me.st.Text = "StatusStrip1"
        '
        'ts1
        '
        Me.ts1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ts1.Name = "ts1"
        Me.ts1.Size = New System.Drawing.Size(17, 17)
        Me.ts1.Text = "--"
        '
        'ts2
        '
        Me.ts2.BackColor = System.Drawing.Color.DimGray
        Me.ts2.Name = "ts2"
        Me.ts2.Size = New System.Drawing.Size(17, 17)
        Me.ts2.Text = "--"
        '
        'ts3
        '
        Me.ts3.BackColor = System.Drawing.Color.Khaki
        Me.ts3.Name = "ts3"
        Me.ts3.Size = New System.Drawing.Size(17, 17)
        Me.ts3.Text = "--"
        '
        'ts4
        '
        Me.ts4.BackColor = System.Drawing.Color.Cyan
        Me.ts4.Name = "ts4"
        Me.ts4.Size = New System.Drawing.Size(17, 17)
        Me.ts4.Text = "--"
        '
        'ts5
        '
        Me.ts5.Name = "ts5"
        Me.ts5.Size = New System.Drawing.Size(17, 17)
        Me.ts5.Text = "--"
        '
        'cm
        '
        Me.cm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PerTanggalToolStripMenuItem, Me.PerJamToolStripMenuItem, Me.GrandTotalToolStripMenuItem})
        Me.cm.Name = "cm"
        Me.cm.Size = New System.Drawing.Size(144, 70)
        '
        'PerTanggalToolStripMenuItem
        '
        Me.PerTanggalToolStripMenuItem.BackColor = System.Drawing.Color.SteelBlue
        Me.PerTanggalToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PerTanggalToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PerTanggalToolStripMenuItem.Name = "PerTanggalToolStripMenuItem"
        Me.PerTanggalToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.PerTanggalToolStripMenuItem.Text = "Per Tanggal"
        '
        'PerJamToolStripMenuItem
        '
        Me.PerJamToolStripMenuItem.BackColor = System.Drawing.Color.SteelBlue
        Me.PerJamToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PerJamToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PerJamToolStripMenuItem.Name = "PerJamToolStripMenuItem"
        Me.PerJamToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.PerJamToolStripMenuItem.Text = "Per Jam"
        '
        'GrandTotalToolStripMenuItem
        '
        Me.GrandTotalToolStripMenuItem.BackColor = System.Drawing.Color.SteelBlue
        Me.GrandTotalToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrandTotalToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GrandTotalToolStripMenuItem.Name = "GrandTotalToolStripMenuItem"
        Me.GrandTotalToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.GrandTotalToolStripMenuItem.Text = "Grand Total"
        '
        'gbstatuscard
        '
        Me.gbstatuscard.Controls.Add(Me.rdbuton3)
        Me.gbstatuscard.Controls.Add(Me.rdbuton2)
        Me.gbstatuscard.Controls.Add(Me.rdbuton)
        Me.gbstatuscard.Controls.Add(Me.Label8)
        Me.gbstatuscard.Location = New System.Drawing.Point(356, 55)
        Me.gbstatuscard.Name = "gbstatuscard"
        Me.gbstatuscard.Size = New System.Drawing.Size(200, 86)
        Me.gbstatuscard.TabIndex = 67
        Me.gbstatuscard.TabStop = False
        '
        'rdbuton3
        '
        Me.rdbuton3.AutoSize = True
        Me.rdbuton3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbuton3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rdbuton3.Location = New System.Drawing.Point(80, 55)
        Me.rdbuton3.Name = "rdbuton3"
        Me.rdbuton3.Size = New System.Drawing.Size(39, 17)
        Me.rdbuton3.TabIndex = 63
        Me.rdbuton3.TabStop = True
        Me.rdbuton3.Text = "All"
        Me.rdbuton3.UseVisualStyleBackColor = True
        '
        'rdbuton2
        '
        Me.rdbuton2.AutoSize = True
        Me.rdbuton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbuton2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rdbuton2.Location = New System.Drawing.Point(80, 33)
        Me.rdbuton2.Name = "rdbuton2"
        Me.rdbuton2.Size = New System.Drawing.Size(96, 17)
        Me.rdbuton2.TabIndex = 62
        Me.rdbuton2.TabStop = True
        Me.rdbuton2.Text = "Non Member"
        Me.rdbuton2.UseVisualStyleBackColor = True
        '
        'rdbuton
        '
        Me.rdbuton.AutoSize = True
        Me.rdbuton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbuton.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rdbuton.Location = New System.Drawing.Point(80, 10)
        Me.rdbuton.Name = "rdbuton"
        Me.rdbuton.Size = New System.Drawing.Size(69, 17)
        Me.rdbuton.TabIndex = 61
        Me.rdbuton.TabStop = True
        Me.rdbuton.Text = "Member"
        Me.rdbuton.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkKhaki
        Me.Label8.Location = New System.Drawing.Point(5, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 13)
        Me.Label8.TabIndex = 60
        Me.Label8.Text = "Status Card :"
        '
        'gbsales
        '
        Me.gbsales.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.gbsales.Controls.Add(Me.rdsalescustom)
        Me.gbsales.Controls.Add(Me.rdallsales)
        Me.gbsales.Controls.Add(Me.txtvalue1)
        Me.gbsales.Controls.Add(Me.Label6)
        Me.gbsales.Location = New System.Drawing.Point(7, 309)
        Me.gbsales.Name = "gbsales"
        Me.gbsales.Size = New System.Drawing.Size(195, 73)
        Me.gbsales.TabIndex = 68
        Me.gbsales.TabStop = False
        '
        'rdsalescustom
        '
        Me.rdsalescustom.AutoSize = True
        Me.rdsalescustom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdsalescustom.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rdsalescustom.Location = New System.Drawing.Point(98, 11)
        Me.rdsalescustom.Name = "rdsalescustom"
        Me.rdsalescustom.Size = New System.Drawing.Size(66, 17)
        Me.rdsalescustom.TabIndex = 72
        Me.rdsalescustom.TabStop = True
        Me.rdsalescustom.Text = "Custom"
        Me.rdsalescustom.UseVisualStyleBackColor = True
        '
        'rdallsales
        '
        Me.rdallsales.AutoSize = True
        Me.rdallsales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdallsales.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rdallsales.Location = New System.Drawing.Point(53, 12)
        Me.rdallsales.Name = "rdallsales"
        Me.rdallsales.Size = New System.Drawing.Size(39, 17)
        Me.rdallsales.TabIndex = 71
        Me.rdallsales.TabStop = True
        Me.rdallsales.Text = "All"
        Me.rdallsales.UseVisualStyleBackColor = True
        '
        'txtvalue1
        '
        Me.txtvalue1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtvalue1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtvalue1.ForeColor = System.Drawing.SystemColors.MenuText
        Me.txtvalue1.Location = New System.Drawing.Point(98, 36)
        Me.txtvalue1.Name = "txtvalue1"
        Me.txtvalue1.Size = New System.Drawing.Size(83, 20)
        Me.txtvalue1.TabIndex = 68
        Me.txtvalue1.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkKhaki
        Me.Label6.Location = New System.Drawing.Point(6, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 67
        Me.Label6.Text = "Sales :"
        '
        'gbsbu
        '
        Me.gbsbu.Controls.Add(Me.chksupportcenter)
        Me.gbsbu.Controls.Add(Me.chkmens)
        Me.gbsbu.Controls.Add(Me.chkladies2)
        Me.gbsbu.Controls.Add(Me.chkladies1)
        Me.gbsbu.Controls.Add(Me.chkhome)
        Me.gbsbu.Controls.Add(Me.chkchildrend)
        Me.gbsbu.Controls.Add(Me.Label16)
        Me.gbsbu.Location = New System.Drawing.Point(7, 229)
        Me.gbsbu.Name = "gbsbu"
        Me.gbsbu.Size = New System.Drawing.Size(343, 82)
        Me.gbsbu.TabIndex = 69
        Me.gbsbu.TabStop = False
        '
        'chksupportcenter
        '
        Me.chksupportcenter.AutoSize = True
        Me.chksupportcenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chksupportcenter.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.chksupportcenter.Location = New System.Drawing.Point(172, 60)
        Me.chksupportcenter.Name = "chksupportcenter"
        Me.chksupportcenter.Size = New System.Drawing.Size(111, 17)
        Me.chksupportcenter.TabIndex = 67
        Me.chksupportcenter.Text = "Support Center"
        Me.chksupportcenter.UseVisualStyleBackColor = True
        '
        'chkmens
        '
        Me.chkmens.AutoSize = True
        Me.chkmens.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkmens.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.chkmens.Location = New System.Drawing.Point(173, 38)
        Me.chkmens.Name = "chkmens"
        Me.chkmens.Size = New System.Drawing.Size(56, 17)
        Me.chkmens.TabIndex = 66
        Me.chkmens.Text = "Mens"
        Me.chkmens.UseVisualStyleBackColor = True
        '
        'chkladies2
        '
        Me.chkladies2.AutoSize = True
        Me.chkladies2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkladies2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.chkladies2.Location = New System.Drawing.Point(173, 14)
        Me.chkladies2.Name = "chkladies2"
        Me.chkladies2.Size = New System.Drawing.Size(74, 17)
        Me.chkladies2.TabIndex = 65
        Me.chkladies2.Text = "Ladies 2"
        Me.chkladies2.UseVisualStyleBackColor = True
        '
        'chkladies1
        '
        Me.chkladies1.AutoSize = True
        Me.chkladies1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkladies1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.chkladies1.Location = New System.Drawing.Point(48, 60)
        Me.chkladies1.Name = "chkladies1"
        Me.chkladies1.Size = New System.Drawing.Size(74, 17)
        Me.chkladies1.TabIndex = 64
        Me.chkladies1.Text = "Ladies 1"
        Me.chkladies1.UseVisualStyleBackColor = True
        '
        'chkhome
        '
        Me.chkhome.AutoSize = True
        Me.chkhome.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkhome.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.chkhome.Location = New System.Drawing.Point(48, 38)
        Me.chkhome.Name = "chkhome"
        Me.chkhome.Size = New System.Drawing.Size(58, 17)
        Me.chkhome.TabIndex = 63
        Me.chkhome.Text = "Home"
        Me.chkhome.UseVisualStyleBackColor = True
        '
        'chkchildrend
        '
        Me.chkchildrend.AutoSize = True
        Me.chkchildrend.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkchildrend.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.chkchildrend.Location = New System.Drawing.Point(48, 13)
        Me.chkchildrend.Name = "chkchildrend"
        Me.chkchildrend.Size = New System.Drawing.Size(79, 17)
        Me.chkchildrend.TabIndex = 62
        Me.chkchildrend.Text = "Childrend"
        Me.chkchildrend.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DarkKhaki
        Me.Label16.Location = New System.Drawing.Point(9, 13)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(40, 13)
        Me.Label16.TabIndex = 61
        Me.Label16.Text = "SBU :"
        '
        'gbstatuskelipatan
        '
        Me.gbstatuskelipatan.Controls.Add(Me.chkkelipatan)
        Me.gbstatuskelipatan.Controls.Add(Me.chknonkelipatan)
        Me.gbstatuskelipatan.Controls.Add(Me.Label19)
        Me.gbstatuskelipatan.Location = New System.Drawing.Point(8, 184)
        Me.gbstatuskelipatan.Name = "gbstatuskelipatan"
        Me.gbstatuskelipatan.Size = New System.Drawing.Size(342, 45)
        Me.gbstatuskelipatan.TabIndex = 70
        Me.gbstatuskelipatan.TabStop = False
        '
        'chkkelipatan
        '
        Me.chkkelipatan.AutoSize = True
        Me.chkkelipatan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkkelipatan.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.chkkelipatan.Location = New System.Drawing.Point(185, 16)
        Me.chkkelipatan.Name = "chkkelipatan"
        Me.chkkelipatan.Size = New System.Drawing.Size(115, 17)
        Me.chkkelipatan.TabIndex = 47
        Me.chkkelipatan.Text = "Tidak Kelipatan"
        Me.chkkelipatan.UseVisualStyleBackColor = True
        '
        'chknonkelipatan
        '
        Me.chknonkelipatan.AutoSize = True
        Me.chknonkelipatan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chknonkelipatan.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.chknonkelipatan.Location = New System.Drawing.Point(102, 15)
        Me.chknonkelipatan.Name = "chknonkelipatan"
        Me.chknonkelipatan.Size = New System.Drawing.Size(79, 17)
        Me.chknonkelipatan.TabIndex = 46
        Me.chknonkelipatan.Text = "Kelipatan"
        Me.chknonkelipatan.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.DarkKhaki
        Me.Label19.Location = New System.Drawing.Point(4, 16)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(108, 13)
        Me.Label19.TabIndex = 45
        Me.Label19.Text = "Status Kelipatan :"
        '
        'gbcategory
        '
        Me.gbcategory.Controls.Add(Me.chklistcategory)
        Me.gbcategory.Controls.Add(Me.Label17)
        Me.gbcategory.Location = New System.Drawing.Point(562, 142)
        Me.gbcategory.Name = "gbcategory"
        Me.gbcategory.Size = New System.Drawing.Size(233, 135)
        Me.gbcategory.TabIndex = 71
        Me.gbcategory.TabStop = False
        '
        'chklistcategory
        '
        Me.chklistcategory.BackColor = System.Drawing.Color.Moccasin
        Me.chklistcategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklistcategory.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.chklistcategory.FormattingEnabled = True
        Me.chklistcategory.Location = New System.Drawing.Point(74, 13)
        Me.chklistcategory.Name = "chklistcategory"
        Me.chklistcategory.Size = New System.Drawing.Size(153, 109)
        Me.chklistcategory.TabIndex = 79
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.DarkKhaki
        Me.Label17.Location = New System.Drawing.Point(6, 14)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(65, 13)
        Me.Label17.TabIndex = 65
        Me.Label17.Text = "Category :"
        '
        'gbbrand
        '
        Me.gbbrand.Controls.Add(Me.chklistbrand)
        Me.gbbrand.Controls.Add(Me.Label18)
        Me.gbbrand.Location = New System.Drawing.Point(562, 12)
        Me.gbbrand.Name = "gbbrand"
        Me.gbbrand.Size = New System.Drawing.Size(234, 130)
        Me.gbbrand.TabIndex = 72
        Me.gbbrand.TabStop = False
        '
        'chklistbrand
        '
        Me.chklistbrand.BackColor = System.Drawing.Color.Moccasin
        Me.chklistbrand.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklistbrand.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.chklistbrand.FormattingEnabled = True
        Me.chklistbrand.Location = New System.Drawing.Point(74, 10)
        Me.chklistbrand.Name = "chklistbrand"
        Me.chklistbrand.Size = New System.Drawing.Size(154, 109)
        Me.chklistbrand.TabIndex = 79
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DarkKhaki
        Me.Label18.Location = New System.Drawing.Point(7, 9)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(48, 13)
        Me.Label18.TabIndex = 62
        Me.Label18.Text = "Brand :"
        '
        'gbdays
        '
        Me.gbdays.Controls.Add(Me.chkkhamis)
        Me.gbdays.Controls.Add(Me.chkminggu)
        Me.gbdays.Controls.Add(Me.chksabtu)
        Me.gbdays.Controls.Add(Me.chkjumat)
        Me.gbdays.Controls.Add(Me.chkrabu)
        Me.gbdays.Controls.Add(Me.chkselasa)
        Me.gbdays.Controls.Add(Me.chksenin)
        Me.gbdays.Controls.Add(Me.Label20)
        Me.gbdays.Location = New System.Drawing.Point(357, 229)
        Me.gbdays.Name = "gbdays"
        Me.gbdays.Size = New System.Drawing.Size(200, 83)
        Me.gbdays.TabIndex = 73
        Me.gbdays.TabStop = False
        '
        'chkkhamis
        '
        Me.chkkhamis.AutoSize = True
        Me.chkkhamis.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkkhamis.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.chkkhamis.Location = New System.Drawing.Point(62, 62)
        Me.chkkhamis.Name = "chkkhamis"
        Me.chkkhamis.Size = New System.Drawing.Size(66, 17)
        Me.chkkhamis.TabIndex = 60
        Me.chkkhamis.Text = "Khamis"
        Me.chkkhamis.UseVisualStyleBackColor = True
        '
        'chkminggu
        '
        Me.chkminggu.AutoSize = True
        Me.chkminggu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkminggu.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.chkminggu.Location = New System.Drawing.Point(120, 45)
        Me.chkminggu.Name = "chkminggu"
        Me.chkminggu.Size = New System.Drawing.Size(67, 17)
        Me.chkminggu.TabIndex = 59
        Me.chkminggu.Text = "Minggu"
        Me.chkminggu.UseVisualStyleBackColor = True
        '
        'chksabtu
        '
        Me.chksabtu.AutoSize = True
        Me.chksabtu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chksabtu.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.chksabtu.Location = New System.Drawing.Point(120, 29)
        Me.chksabtu.Name = "chksabtu"
        Me.chksabtu.Size = New System.Drawing.Size(59, 17)
        Me.chksabtu.TabIndex = 58
        Me.chksabtu.Text = "Sabtu"
        Me.chksabtu.UseVisualStyleBackColor = True
        '
        'chkjumat
        '
        Me.chkjumat.AutoSize = True
        Me.chkjumat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkjumat.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.chkjumat.Location = New System.Drawing.Point(120, 11)
        Me.chkjumat.Name = "chkjumat"
        Me.chkjumat.Size = New System.Drawing.Size(59, 17)
        Me.chkjumat.TabIndex = 57
        Me.chkjumat.Text = "Jumat"
        Me.chkjumat.UseVisualStyleBackColor = True
        '
        'chkrabu
        '
        Me.chkrabu.AutoSize = True
        Me.chkrabu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkrabu.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.chkrabu.Location = New System.Drawing.Point(62, 46)
        Me.chkrabu.Name = "chkrabu"
        Me.chkrabu.Size = New System.Drawing.Size(56, 17)
        Me.chkrabu.TabIndex = 56
        Me.chkrabu.Text = "Rabu"
        Me.chkrabu.UseVisualStyleBackColor = True
        '
        'chkselasa
        '
        Me.chkselasa.AutoSize = True
        Me.chkselasa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkselasa.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.chkselasa.Location = New System.Drawing.Point(62, 29)
        Me.chkselasa.Name = "chkselasa"
        Me.chkselasa.Size = New System.Drawing.Size(64, 17)
        Me.chkselasa.TabIndex = 55
        Me.chkselasa.Text = "Selasa"
        Me.chkselasa.UseVisualStyleBackColor = True
        '
        'chksenin
        '
        Me.chksenin.AutoSize = True
        Me.chksenin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chksenin.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.chksenin.Location = New System.Drawing.Point(62, 11)
        Me.chksenin.Name = "chksenin"
        Me.chksenin.Size = New System.Drawing.Size(58, 17)
        Me.chksenin.TabIndex = 54
        Me.chksenin.Text = "Senin"
        Me.chksenin.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.DarkKhaki
        Me.Label20.Location = New System.Drawing.Point(6, 11)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(61, 13)
        Me.Label20.TabIndex = 53
        Me.Label20.Text = "Per Hari :"
        '
        'gbpersentase
        '
        Me.gbpersentase.Controls.Add(Me.Label15)
        Me.gbpersentase.Controls.Add(Me.Label14)
        Me.gbpersentase.Controls.Add(Me.Label13)
        Me.gbpersentase.Controls.Add(Me.Label12)
        Me.gbpersentase.Controls.Add(Me.txtpercentage3)
        Me.gbpersentase.Controls.Add(Me.txtpercentage2)
        Me.gbpersentase.Controls.Add(Me.Label11)
        Me.gbpersentase.Controls.Add(Me.Label10)
        Me.gbpersentase.Controls.Add(Me.txtpercentage1)
        Me.gbpersentase.Controls.Add(Me.Label9)
        Me.gbpersentase.Location = New System.Drawing.Point(357, 142)
        Me.gbpersentase.Name = "gbpersentase"
        Me.gbpersentase.Size = New System.Drawing.Size(200, 88)
        Me.gbpersentase.TabIndex = 74
        Me.gbpersentase.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label15.Location = New System.Drawing.Point(177, 65)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(16, 13)
        Me.Label15.TabIndex = 41
        Me.Label15.Text = "%"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label14.Location = New System.Drawing.Point(177, 39)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(16, 13)
        Me.Label14.TabIndex = 40
        Me.Label14.Text = "%"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label13.Location = New System.Drawing.Point(177, 13)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(16, 13)
        Me.Label13.TabIndex = 39
        Me.Label13.Text = "%"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label12.Location = New System.Drawing.Point(113, 65)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 13)
        Me.Label12.TabIndex = 38
        Me.Label12.Text = "S003"
        '
        'txtpercentage3
        '
        Me.txtpercentage3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtpercentage3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpercentage3.ForeColor = System.Drawing.SystemColors.MenuText
        Me.txtpercentage3.Location = New System.Drawing.Point(149, 63)
        Me.txtpercentage3.Name = "txtpercentage3"
        Me.txtpercentage3.Size = New System.Drawing.Size(22, 20)
        Me.txtpercentage3.TabIndex = 37
        Me.txtpercentage3.Text = "0"
        '
        'txtpercentage2
        '
        Me.txtpercentage2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtpercentage2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpercentage2.ForeColor = System.Drawing.SystemColors.MenuText
        Me.txtpercentage2.Location = New System.Drawing.Point(149, 37)
        Me.txtpercentage2.Name = "txtpercentage2"
        Me.txtpercentage2.Size = New System.Drawing.Size(22, 20)
        Me.txtpercentage2.TabIndex = 36
        Me.txtpercentage2.Text = "0"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label11.Location = New System.Drawing.Point(113, 39)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 13)
        Me.Label11.TabIndex = 35
        Me.Label11.Text = "S002"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label10.Location = New System.Drawing.Point(114, 13)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 13)
        Me.Label10.TabIndex = 34
        Me.Label10.Text = "S001"
        '
        'txtpercentage1
        '
        Me.txtpercentage1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtpercentage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpercentage1.ForeColor = System.Drawing.SystemColors.MenuText
        Me.txtpercentage1.Location = New System.Drawing.Point(149, 11)
        Me.txtpercentage1.Name = "txtpercentage1"
        Me.txtpercentage1.Size = New System.Drawing.Size(22, 20)
        Me.txtpercentage1.TabIndex = 33
        Me.txtpercentage1.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkKhaki
        Me.Label9.Location = New System.Drawing.Point(2, 13)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(122, 13)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "Persentase Growth :"
        '
        'gbstore
        '
        Me.gbstore.Controls.Add(Me.Label5)
        Me.gbstore.Controls.Add(Me.chks003)
        Me.gbstore.Controls.Add(Me.chks002)
        Me.gbstore.Controls.Add(Me.chks001)
        Me.gbstore.Location = New System.Drawing.Point(9, 142)
        Me.gbstore.Name = "gbstore"
        Me.gbstore.Size = New System.Drawing.Size(342, 42)
        Me.gbstore.TabIndex = 75
        Me.gbstore.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkKhaki
        Me.Label5.Location = New System.Drawing.Point(6, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Toko :"
        '
        'chks003
        '
        Me.chks003.AutoSize = True
        Me.chks003.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chks003.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.chks003.Location = New System.Drawing.Point(153, 15)
        Me.chks003.Name = "chks003"
        Me.chks003.Size = New System.Drawing.Size(55, 17)
        Me.chks003.TabIndex = 15
        Me.chks003.Text = "S003"
        Me.chks003.UseVisualStyleBackColor = True
        '
        'chks002
        '
        Me.chks002.AutoSize = True
        Me.chks002.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chks002.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.chks002.Location = New System.Drawing.Point(104, 15)
        Me.chks002.Name = "chks002"
        Me.chks002.Size = New System.Drawing.Size(55, 17)
        Me.chks002.TabIndex = 14
        Me.chks002.Text = "S002"
        Me.chks002.UseVisualStyleBackColor = True
        '
        'chks001
        '
        Me.chks001.AutoSize = True
        Me.chks001.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chks001.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.chks001.Location = New System.Drawing.Point(57, 15)
        Me.chks001.Name = "chks001"
        Me.chks001.Size = New System.Drawing.Size(55, 17)
        Me.chks001.TabIndex = 13
        Me.chks001.Text = "S001"
        Me.chks001.UseVisualStyleBackColor = True
        '
        'gbperjam
        '
        Me.gbperjam.Controls.Add(Me.TextBox2)
        Me.gbperjam.Controls.Add(Me.Label22)
        Me.gbperjam.Controls.Add(Me.TextBox1)
        Me.gbperjam.Controls.Add(Me.Label21)
        Me.gbperjam.Location = New System.Drawing.Point(356, 12)
        Me.gbperjam.Name = "gbperjam"
        Me.gbperjam.Size = New System.Drawing.Size(201, 46)
        Me.gbperjam.TabIndex = 76
        Me.gbperjam.TabStop = False
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.ForeColor = System.Drawing.SystemColors.MenuText
        Me.TextBox2.Location = New System.Drawing.Point(139, 16)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(42, 20)
        Me.TextBox2.TabIndex = 60
        Me.TextBox2.Text = "0"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label22.Location = New System.Drawing.Point(118, 18)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(18, 13)
        Me.Label22.TabIndex = 59
        Me.Label22.Text = "to"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.SystemColors.MenuText
        Me.TextBox1.Location = New System.Drawing.Point(72, 16)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(41, 20)
        Me.TextBox1.TabIndex = 58
        Me.TextBox1.Text = "0"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DarkKhaki
        Me.Label21.Location = New System.Drawing.Point(6, 16)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(60, 13)
        Me.Label21.TabIndex = 57
        Me.Label21.Text = "Per Jam :"
        '
        'gbtanggal
        '
        Me.gbtanggal.Controls.Add(Me.dtpdate4)
        Me.gbtanggal.Controls.Add(Me.dtpdate3)
        Me.gbtanggal.Controls.Add(Me.dtpdate2)
        Me.gbtanggal.Controls.Add(Me.dtpdate1)
        Me.gbtanggal.Controls.Add(Me.Label4)
        Me.gbtanggal.Controls.Add(Me.Label3)
        Me.gbtanggal.Controls.Add(Me.Label2)
        Me.gbtanggal.Controls.Add(Me.Label1)
        Me.gbtanggal.Location = New System.Drawing.Point(10, 12)
        Me.gbtanggal.Name = "gbtanggal"
        Me.gbtanggal.Size = New System.Drawing.Size(340, 130)
        Me.gbtanggal.TabIndex = 77
        Me.gbtanggal.TabStop = False
        '
        'dtpdate4
        '
        Me.dtpdate4.Location = New System.Drawing.Point(120, 100)
        Me.dtpdate4.Name = "dtpdate4"
        Me.dtpdate4.ShowCheckBox = True
        Me.dtpdate4.Size = New System.Drawing.Size(200, 20)
        Me.dtpdate4.TabIndex = 16
        '
        'dtpdate3
        '
        Me.dtpdate3.Location = New System.Drawing.Point(120, 72)
        Me.dtpdate3.Name = "dtpdate3"
        Me.dtpdate3.ShowCheckBox = True
        Me.dtpdate3.Size = New System.Drawing.Size(200, 20)
        Me.dtpdate3.TabIndex = 15
        '
        'dtpdate2
        '
        Me.dtpdate2.Location = New System.Drawing.Point(120, 44)
        Me.dtpdate2.Name = "dtpdate2"
        Me.dtpdate2.Size = New System.Drawing.Size(200, 20)
        Me.dtpdate2.TabIndex = 14
        '
        'dtpdate1
        '
        Me.dtpdate1.Location = New System.Drawing.Point(120, 16)
        Me.dtpdate1.Name = "dtpdate1"
        Me.dtpdate1.Size = New System.Drawing.Size(200, 20)
        Me.dtpdate1.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkKhaki
        Me.Label4.Location = New System.Drawing.Point(6, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "LY Tanggal Akhir :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkKhaki
        Me.Label3.Location = New System.Drawing.Point(6, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "LY Tanggal Awal :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkKhaki
        Me.Label2.Location = New System.Drawing.Point(6, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Tanggal akhir :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkKhaki
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Tanggal Awal :"
        '
        'btnprocess
        '
        Me.btnprocess.BackColor = System.Drawing.Color.DarkSlateGray
        Me.btnprocess.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnprocess.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        'Me.btnprocess.Image = Global.Marketing.My.Resources.Resources._1downarrow1
        Me.btnprocess.Location = New System.Drawing.Point(560, 278)
        Me.btnprocess.Name = "btnprocess"
        Me.btnprocess.Size = New System.Drawing.Size(235, 68)
        Me.btnprocess.TabIndex = 21
        Me.btnprocess.Text = "Process"
        Me.btnprocess.UseVisualStyleBackColor = False
        '
        'tm1
        '
        Me.tm1.Enabled = True
        Me.tm1.Interval = 1000
        '
        'frmanalyzer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(804, 414)
        Me.Controls.Add(Me.gbtanggal)
        Me.Controls.Add(Me.gbperjam)
        Me.Controls.Add(Me.gbstore)
        Me.Controls.Add(Me.gbpersentase)
        Me.Controls.Add(Me.gbdays)
        Me.Controls.Add(Me.gbbrand)
        Me.Controls.Add(Me.gbcategory)
        Me.Controls.Add(Me.gbstatuskelipatan)
        Me.Controls.Add(Me.gbsbu)
        Me.Controls.Add(Me.gbsales)
        Me.Controls.Add(Me.gbstatuscard)
        Me.Controls.Add(Me.btnprocess)
        Me.Controls.Add(Me.st)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmanalyzer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.st.ResumeLayout(False)
        Me.st.PerformLayout()
        Me.cm.ResumeLayout(False)
        Me.gbstatuscard.ResumeLayout(False)
        Me.gbstatuscard.PerformLayout()
        Me.gbsales.ResumeLayout(False)
        Me.gbsales.PerformLayout()
        Me.gbsbu.ResumeLayout(False)
        Me.gbsbu.PerformLayout()
        Me.gbstatuskelipatan.ResumeLayout(False)
        Me.gbstatuskelipatan.PerformLayout()
        Me.gbcategory.ResumeLayout(False)
        Me.gbcategory.PerformLayout()
        Me.gbbrand.ResumeLayout(False)
        Me.gbbrand.PerformLayout()
        Me.gbdays.ResumeLayout(False)
        Me.gbdays.PerformLayout()
        Me.gbpersentase.ResumeLayout(False)
        Me.gbpersentase.PerformLayout()
        Me.gbstore.ResumeLayout(False)
        Me.gbstore.PerformLayout()
        Me.gbperjam.ResumeLayout(False)
        Me.gbperjam.PerformLayout()
        Me.gbtanggal.ResumeLayout(False)
        Me.gbtanggal.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents st As StatusStrip
    Friend WithEvents ts1 As ToolStripStatusLabel
    Friend WithEvents ts2 As ToolStripStatusLabel
    Friend WithEvents ts3 As ToolStripStatusLabel
    Friend WithEvents ts4 As ToolStripStatusLabel
    Friend WithEvents btnprocess As Button
    Friend WithEvents cm As ContextMenuStrip
    Friend WithEvents PerTanggalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PerJamToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GrandTotalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents gbstatuscard As GroupBox
    Friend WithEvents rdbuton3 As RadioButton
    Friend WithEvents rdbuton2 As RadioButton
    Friend WithEvents rdbuton As RadioButton
    Friend WithEvents Label8 As Label
    Friend WithEvents gbsales As GroupBox
    Friend WithEvents rdsalescustom As RadioButton
    Friend WithEvents rdallsales As RadioButton
    Friend WithEvents txtvalue1 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents gbsbu As GroupBox
    Friend WithEvents chksupportcenter As CheckBox
    Friend WithEvents chkmens As CheckBox
    Friend WithEvents chkladies2 As CheckBox
    Friend WithEvents chkladies1 As CheckBox
    Friend WithEvents chkhome As CheckBox
    Friend WithEvents chkchildrend As CheckBox
    Friend WithEvents Label16 As Label
    Friend WithEvents gbstatuskelipatan As GroupBox
    Friend WithEvents Label19 As Label
    Friend WithEvents gbcategory As GroupBox
    Friend WithEvents Label17 As Label
    Friend WithEvents gbbrand As GroupBox
    Friend WithEvents Label18 As Label
    Friend WithEvents gbdays As GroupBox
    Friend WithEvents chkkhamis As CheckBox
    Friend WithEvents chkminggu As CheckBox
    Friend WithEvents chksabtu As CheckBox
    Friend WithEvents chkjumat As CheckBox
    Friend WithEvents chkrabu As CheckBox
    Friend WithEvents chkselasa As CheckBox
    Friend WithEvents chksenin As CheckBox
    Friend WithEvents Label20 As Label
    Friend WithEvents gbpersentase As GroupBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtpercentage3 As TextBox
    Friend WithEvents txtpercentage2 As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtpercentage1 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents gbstore As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents chks003 As CheckBox
    Friend WithEvents chks002 As CheckBox
    Friend WithEvents chks001 As CheckBox
    Friend WithEvents gbperjam As GroupBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents gbtanggal As GroupBox
    Friend WithEvents dtpdate4 As DateTimePicker
    Friend WithEvents dtpdate3 As DateTimePicker
    Friend WithEvents dtpdate2 As DateTimePicker
    Friend WithEvents dtpdate1 As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents chklistcategory As CheckedListBox
    Friend WithEvents chklistbrand As CheckedListBox
    Friend WithEvents ts5 As ToolStripStatusLabel
    Friend WithEvents tm1 As Timer
    Friend WithEvents chkkelipatan As CheckBox
    Friend WithEvents chknonkelipatan As CheckBox
End Class
