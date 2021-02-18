<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CompareSOSAP
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CompareSOSAP))
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.BtnEditSelisih = New System.Windows.Forms.Button
        Me.BtnUploadScan = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.BtnBrowse = New System.Windows.Forms.Button
        Me.BtnDataFinal = New System.Windows.Forms.Button
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PrintSelisihPDTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintFinalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BtnComparePDT = New System.Windows.Forms.Button
        Me.BtnDataRead = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtIDCompare = New System.Windows.Forms.TextBox
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.GroupBox2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(122, 83)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(262, 22)
        Me.TextBox1.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 14)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "&Branches"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(122, 53)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(262, 22)
        Me.ComboBox1.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BtnEditSelisih)
        Me.GroupBox2.Controls.Add(Me.BtnUploadScan)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.BtnBrowse)
        Me.GroupBox2.Controls.Add(Me.BtnDataFinal)
        Me.GroupBox2.Controls.Add(Me.BtnComparePDT)
        Me.GroupBox2.Controls.Add(Me.BtnDataRead)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.ComboBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(531, 165)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'BtnEditSelisih
        '
        Me.BtnEditSelisih.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEditSelisih.Image = CType(resources.GetObject("BtnEditSelisih.Image"), System.Drawing.Image)
        Me.BtnEditSelisih.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEditSelisih.Location = New System.Drawing.Point(254, 111)
        Me.BtnEditSelisih.Name = "BtnEditSelisih"
        Me.BtnEditSelisih.Size = New System.Drawing.Size(130, 30)
        Me.BtnEditSelisih.TabIndex = 20
        Me.BtnEditSelisih.Text = "&Edit Selisih"
        Me.BtnEditSelisih.UseVisualStyleBackColor = True
        '
        'BtnUploadScan
        '
        Me.BtnUploadScan.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUploadScan.Image = CType(resources.GetObject("BtnUploadScan.Image"), System.Drawing.Image)
        Me.BtnUploadScan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnUploadScan.Location = New System.Drawing.Point(122, 111)
        Me.BtnUploadScan.Name = "BtnUploadScan"
        Me.BtnUploadScan.Size = New System.Drawing.Size(126, 30)
        Me.BtnUploadScan.TabIndex = 9
        Me.BtnUploadScan.Text = "&Upload Text Files"
        Me.BtnUploadScan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnUploadScan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnUploadScan.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 146)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 13)
        Me.Label5.TabIndex = 19
        '
        'BtnBrowse
        '
        Me.BtnBrowse.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBrowse.Image = CType(resources.GetObject("BtnBrowse.Image"), System.Drawing.Image)
        Me.BtnBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBrowse.Location = New System.Drawing.Point(390, 81)
        Me.BtnBrowse.Name = "BtnBrowse"
        Me.BtnBrowse.Size = New System.Drawing.Size(126, 25)
        Me.BtnBrowse.TabIndex = 8
        Me.BtnBrowse.Text = "B&rowse"
        Me.BtnBrowse.UseVisualStyleBackColor = True
        '
        'BtnDataFinal
        '
        Me.BtnDataFinal.ContextMenuStrip = Me.ContextMenuStrip1
        Me.BtnDataFinal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDataFinal.Image = CType(resources.GetObject("BtnDataFinal.Image"), System.Drawing.Image)
        Me.BtnDataFinal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDataFinal.Location = New System.Drawing.Point(390, 111)
        Me.BtnDataFinal.Name = "BtnDataFinal"
        Me.BtnDataFinal.Size = New System.Drawing.Size(126, 30)
        Me.BtnDataFinal.TabIndex = 11
        Me.BtnDataFinal.Text = "&Print Report"
        Me.BtnDataFinal.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintSelisihPDTToolStripMenuItem, Me.PrintFinalToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(170, 48)
        '
        'PrintSelisihPDTToolStripMenuItem
        '
        Me.PrintSelisihPDTToolStripMenuItem.Name = "PrintSelisihPDTToolStripMenuItem"
        Me.PrintSelisihPDTToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.PrintSelisihPDTToolStripMenuItem.Text = "&1 Print Selisih PDT"
        '
        'PrintFinalToolStripMenuItem
        '
        Me.PrintFinalToolStripMenuItem.Name = "PrintFinalToolStripMenuItem"
        Me.PrintFinalToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.PrintFinalToolStripMenuItem.Text = "&2 Print Final"
        '
        'BtnComparePDT
        '
        Me.BtnComparePDT.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnComparePDT.Image = CType(resources.GetObject("BtnComparePDT.Image"), System.Drawing.Image)
        Me.BtnComparePDT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnComparePDT.Location = New System.Drawing.Point(6, 111)
        Me.BtnComparePDT.Name = "BtnComparePDT"
        Me.BtnComparePDT.Size = New System.Drawing.Size(153, 30)
        Me.BtnComparePDT.TabIndex = 10
        Me.BtnComparePDT.Text = "Upload &Compare PDT"
        Me.BtnComparePDT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnComparePDT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnComparePDT.UseVisualStyleBackColor = True
        Me.BtnComparePDT.Visible = False
        '
        'BtnDataRead
        '
        Me.BtnDataRead.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDataRead.Image = CType(resources.GetObject("BtnDataRead.Image"), System.Drawing.Image)
        Me.BtnDataRead.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDataRead.Location = New System.Drawing.Point(390, 25)
        Me.BtnDataRead.Name = "BtnDataRead"
        Me.BtnDataRead.Size = New System.Drawing.Size(126, 50)
        Me.BtnDataRead.TabIndex = 12
        Me.BtnDataRead.Text = "&Data Read.exe"
        Me.BtnDataRead.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnDataRead.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(105, 86)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(11, 14)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = ":"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(10, 86)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 14)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "P&ath Text File"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(105, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(11, 14)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = ":"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(105, 31)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(11, 14)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = ":"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "dd MMMM yyyy"
        Me.DateTimePicker1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(122, 25)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.ShowUpDown = True
        Me.DateTimePicker1.Size = New System.Drawing.Size(262, 22)
        Me.DateTimePicker1.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 14)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "&Tgl SO"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(177, 219)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(11, 14)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = ":"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(82, 219)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 14)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "&ID Compare"
        '
        'txtIDCompare
        '
        Me.txtIDCompare.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIDCompare.Location = New System.Drawing.Point(194, 216)
        Me.txtIDCompare.Name = "txtIDCompare"
        Me.txtIDCompare.Size = New System.Drawing.Size(262, 22)
        Me.txtIDCompare.TabIndex = 5
        Me.txtIDCompare.Text = "a"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(10, 176)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(531, 11)
        Me.ProgressBar1.TabIndex = 3
        Me.ProgressBar1.Visible = False
        '
        'BackgroundWorker2
        '
        '
        'BackgroundWorker1
        '
        '
        'CompareSOSAP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(558, 197)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtIDCompare)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CompareSOSAP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Compare Data SO Dengan SAP"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents BtnUploadScan As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnDataRead As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents BtnComparePDT As System.Windows.Forms.Button
    Friend WithEvents BtnBrowse As System.Windows.Forms.Button
    Friend WithEvents BtnDataFinal As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtIDCompare As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnEditSelisih As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PrintSelisihPDTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintFinalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
