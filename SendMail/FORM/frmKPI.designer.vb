<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKPI
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKPI))
        Me.DG = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.btnFind = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtBrand = New System.Windows.Forms.TextBox
        Me.txtDept = New System.Windows.Forms.TextBox
        Me.txtSbu = New System.Windows.Forms.TextBox
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnCopy = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnSite = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtNoRev = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.DT = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtSite = New System.Windows.Forms.TextBox
        Me.txtKet = New System.Windows.Forms.TextBox
        Me.lblKet = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsFirst = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsPrev = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsNext = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.tsLast = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.tsFind = New System.Windows.Forms.ToolStripButton
        Me.pg1 = New System.Windows.Forms.ProgressBar
        Me.bg1 = New System.ComponentModel.BackgroundWorker
        Me.tmcek2 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DG
        '
        Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG.Location = New System.Drawing.Point(12, 139)
        Me.DG.Name = "DG"
        Me.DG.Size = New System.Drawing.Size(412, 372)
        Me.DG.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.btnFind)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtBrand)
        Me.GroupBox1.Controls.Add(Me.txtDept)
        Me.GroupBox1.Controls.Add(Me.txtSbu)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 514)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(402, 38)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(281, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 13)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "Label9"
        '
        'btnFind
        '
        Me.btnFind.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnFind.Location = New System.Drawing.Point(226, 12)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(52, 20)
        Me.btnFind.TabIndex = 18
        Me.btnFind.Text = "Find"
        Me.btnFind.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(146, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Brand"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(76, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Dept"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(2, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "SBU"
        '
        'txtBrand
        '
        Me.txtBrand.Location = New System.Drawing.Point(183, 13)
        Me.txtBrand.Name = "txtBrand"
        Me.txtBrand.Size = New System.Drawing.Size(39, 20)
        Me.txtBrand.TabIndex = 14
        '
        'txtDept
        '
        Me.txtDept.Location = New System.Drawing.Point(107, 13)
        Me.txtDept.Name = "txtDept"
        Me.txtDept.Size = New System.Drawing.Size(39, 20)
        Me.txtDept.TabIndex = 13
        '
        'txtSbu
        '
        Me.txtSbu.Location = New System.Drawing.Point(36, 13)
        Me.txtSbu.Name = "txtSbu"
        Me.txtSbu.Size = New System.Drawing.Size(39, 20)
        Me.txtSbu.TabIndex = 12
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnSave.Location = New System.Drawing.Point(352, 555)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(64, 27)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Text = "Add"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnExit.Location = New System.Drawing.Point(283, 555)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(64, 27)
        Me.btnExit.TabIndex = 14
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnCopy
        '
        Me.btnCopy.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnCopy.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopy.Location = New System.Drawing.Point(168, 553)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(94, 39)
        Me.btnCopy.TabIndex = 15
        Me.btnCopy.Text = "Copy File SQM From"
        Me.btnCopy.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.btnSite)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtNoRev)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.DT)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtSite)
        Me.GroupBox2.Controls.Add(Me.txtKet)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 41)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(412, 92)
        Me.GroupBox2.TabIndex = 21
        Me.GroupBox2.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(155, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 13)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Nama Revisi"
        '
        'btnSite
        '
        Me.btnSite.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnSite.Location = New System.Drawing.Point(150, 59)
        Me.btnSite.Name = "btnSite"
        Me.btnSite.Size = New System.Drawing.Size(29, 18)
        Me.btnSite.TabIndex = 28
        Me.btnSite.Text = ":::"
        Me.btnSite.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "No Revisi"
        '
        'txtNoRev
        '
        Me.txtNoRev.Location = New System.Drawing.Point(61, 17)
        Me.txtNoRev.Name = "txtNoRev"
        Me.txtNoRev.Size = New System.Drawing.Size(63, 20)
        Me.txtNoRev.TabIndex = 26
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Date"
        '
        'DT
        '
        Me.DT.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DT.Location = New System.Drawing.Point(61, 38)
        Me.DT.Name = "DT"
        Me.DT.Size = New System.Drawing.Size(83, 20)
        Me.DT.TabIndex = 24
        Me.DT.Value = New Date(2016, 9, 1, 0, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Site"
        '
        'txtSite
        '
        Me.txtSite.Location = New System.Drawing.Point(61, 59)
        Me.txtSite.Name = "txtSite"
        Me.txtSite.Size = New System.Drawing.Size(83, 20)
        Me.txtSite.TabIndex = 22
        '
        'txtKet
        '
        Me.txtKet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtKet.Location = New System.Drawing.Point(225, 17)
        Me.txtKet.Multiline = True
        Me.txtKet.Name = "txtKet"
        Me.txtKet.Size = New System.Drawing.Size(181, 62)
        Me.txtKet.TabIndex = 21
        '
        'lblKet
        '
        Me.lblKet.AutoSize = True
        Me.lblKet.Font = New System.Drawing.Font("Nirmala UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKet.Location = New System.Drawing.Point(12, 580)
        Me.lblKet.Name = "lblKet"
        Me.lblKet.Size = New System.Drawing.Size(0, 15)
        Me.lblKet.TabIndex = 24
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(9, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(414, 26)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Key Performance Indicator"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsFirst, Me.ToolStripSeparator1, Me.tsPrev, Me.ToolStripSeparator2, Me.tsNext, Me.ToolStripSeparator3, Me.tsLast, Me.ToolStripSeparator4, Me.tsFind})
        Me.ToolStrip1.Location = New System.Drawing.Point(14, 555)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(151, 25)
        Me.ToolStrip1.TabIndex = 30
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsFirst
        '
        Me.tsFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsFirst.Image = CType(resources.GetObject("tsFirst.Image"), System.Drawing.Image)
        Me.tsFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsFirst.Name = "tsFirst"
        Me.tsFirst.Size = New System.Drawing.Size(23, 22)
        Me.tsFirst.Text = "First"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsPrev
        '
        Me.tsPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsPrev.Image = CType(resources.GetObject("tsPrev.Image"), System.Drawing.Image)
        Me.tsPrev.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsPrev.Name = "tsPrev"
        Me.tsPrev.Size = New System.Drawing.Size(23, 22)
        Me.tsPrev.Text = "Prev"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsNext
        '
        Me.tsNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsNext.Image = CType(resources.GetObject("tsNext.Image"), System.Drawing.Image)
        Me.tsNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsNext.Name = "tsNext"
        Me.tsNext.Size = New System.Drawing.Size(23, 22)
        Me.tsNext.Text = "Next"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tsLast
        '
        Me.tsLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsLast.Image = CType(resources.GetObject("tsLast.Image"), System.Drawing.Image)
        Me.tsLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsLast.Name = "tsLast"
        Me.tsLast.Size = New System.Drawing.Size(23, 22)
        Me.tsLast.Text = "Last"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'tsFind
        '
        Me.tsFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsFind.Image = CType(resources.GetObject("tsFind.Image"), System.Drawing.Image)
        Me.tsFind.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsFind.Name = "tsFind"
        Me.tsFind.Size = New System.Drawing.Size(23, 22)
        Me.tsFind.Text = "Find"
        '
        'pg1
        '
        Me.pg1.Location = New System.Drawing.Point(14, 598)
        Me.pg1.Name = "pg1"
        Me.pg1.Size = New System.Drawing.Size(404, 14)
        Me.pg1.TabIndex = 31
        '
        'bg1
        '
        '
        'tmcek2
        '
        Me.tmcek2.Enabled = True
        Me.tmcek2.Interval = 2000
        '
        'frmKPI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ClientSize = New System.Drawing.Size(429, 624)
        Me.Controls.Add(Me.pg1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblKet)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DG)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmKPI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Key Performance Indicator"
        CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DG As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtBrand As System.Windows.Forms.TextBox
    Friend WithEvents txtDept As System.Windows.Forms.TextBox
    Friend WithEvents txtSbu As System.Windows.Forms.TextBox
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnCopy As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnSite As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNoRev As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DT As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSite As System.Windows.Forms.TextBox
    Friend WithEvents txtKet As System.Windows.Forms.TextBox
    Friend WithEvents lblKet As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsPrev As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsFind As System.Windows.Forms.ToolStripButton
    Friend WithEvents pg1 As System.Windows.Forms.ProgressBar
    Friend WithEvents bg1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents tmcek2 As System.Windows.Forms.Timer
    Friend WithEvents Label9 As System.Windows.Forms.Label

End Class
