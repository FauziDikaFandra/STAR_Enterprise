<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ceknobrand
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
        Me.gb1 = New System.Windows.Forms.GroupBox
        Me.txtkpi = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnstore = New System.Windows.Forms.Button
        Me.cboyear = New System.Windows.Forms.ComboBox
        Me.cbomonth = New System.Windows.Forms.ComboBox
        Me.txtStore = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnreload3 = New System.Windows.Forms.Button
        Me.btnreload = New System.Windows.Forms.Button
        Me.dg1 = New System.Windows.Forms.DataGridView
        Me.btnprocess = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnexit = New System.Windows.Forms.Button
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Label10 = New System.Windows.Forms.Label
        Me.bg1 = New System.ComponentModel.BackgroundWorker
        Me.lbllastkpi = New System.Windows.Forms.Label
        Me.gb1.SuspendLayout()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gb1
        '
        Me.gb1.Controls.Add(Me.txtkpi)
        Me.gb1.Controls.Add(Me.Label5)
        Me.gb1.Controls.Add(Me.btnstore)
        Me.gb1.Controls.Add(Me.cboyear)
        Me.gb1.Controls.Add(Me.cbomonth)
        Me.gb1.Controls.Add(Me.txtStore)
        Me.gb1.Controls.Add(Me.Label3)
        Me.gb1.Controls.Add(Me.Label2)
        Me.gb1.Controls.Add(Me.Label1)
        Me.gb1.Controls.Add(Me.btnreload3)
        Me.gb1.Controls.Add(Me.btnreload)
        Me.gb1.Location = New System.Drawing.Point(14, 52)
        Me.gb1.Name = "gb1"
        Me.gb1.Size = New System.Drawing.Size(506, 108)
        Me.gb1.TabIndex = 0
        Me.gb1.TabStop = False
        Me.gb1.Text = "Menu"
        '
        'txtkpi
        '
        Me.txtkpi.Location = New System.Drawing.Point(260, 24)
        Me.txtkpi.Name = "txtkpi"
        Me.txtkpi.Size = New System.Drawing.Size(57, 20)
        Me.txtkpi.TabIndex = 49
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(213, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 48
        Me.Label5.Text = "No KPI"
        '
        'btnstore
        '
        Me.btnstore.Location = New System.Drawing.Point(174, 21)
        Me.btnstore.Name = "btnstore"
        Me.btnstore.Size = New System.Drawing.Size(33, 23)
        Me.btnstore.TabIndex = 47
        Me.btnstore.Text = "..."
        Me.btnstore.UseVisualStyleBackColor = True
        '
        'cboyear
        '
        Me.cboyear.FormattingEnabled = True
        Me.cboyear.Location = New System.Drawing.Point(68, 72)
        Me.cboyear.Name = "cboyear"
        Me.cboyear.Size = New System.Drawing.Size(100, 21)
        Me.cboyear.TabIndex = 46
        '
        'cbomonth
        '
        Me.cbomonth.FormattingEnabled = True
        Me.cbomonth.Location = New System.Drawing.Point(68, 47)
        Me.cbomonth.Name = "cbomonth"
        Me.cbomonth.Size = New System.Drawing.Size(100, 21)
        Me.cbomonth.TabIndex = 45
        '
        'txtStore
        '
        Me.txtStore.Location = New System.Drawing.Point(68, 23)
        Me.txtStore.Name = "txtStore"
        Me.txtStore.Size = New System.Drawing.Size(100, 20)
        Me.txtStore.TabIndex = 44
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "Year"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Month"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Store"
        '
        'btnreload3
        '
        Me.btnreload3.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnreload3.Location = New System.Drawing.Point(338, 61)
        Me.btnreload3.Name = "btnreload3"
        Me.btnreload3.Size = New System.Drawing.Size(148, 32)
        Me.btnreload3.TabIndex = 40
        Me.btnreload3.Text = "&Cek Sales No KPI"
        Me.btnreload3.UseVisualStyleBackColor = False
        '
        'btnreload
        '
        Me.btnreload.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnreload.Location = New System.Drawing.Point(338, 21)
        Me.btnreload.Name = "btnreload"
        Me.btnreload.Size = New System.Drawing.Size(148, 34)
        Me.btnreload.TabIndex = 20
        Me.btnreload.Text = "&Cek Sales No Target"
        Me.btnreload.UseVisualStyleBackColor = False
        '
        'dg1
        '
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg1.Location = New System.Drawing.Point(14, 166)
        Me.dg1.Name = "dg1"
        Me.dg1.Size = New System.Drawing.Size(909, 187)
        Me.dg1.TabIndex = 0
        '
        'btnprocess
        '
        Me.btnprocess.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnprocess.Location = New System.Drawing.Point(745, 378)
        Me.btnprocess.Name = "btnprocess"
        Me.btnprocess.Size = New System.Drawing.Size(93, 31)
        Me.btnprocess.TabIndex = 2
        Me.btnprocess.Text = "&Transfer Data"
        Me.btnprocess.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(12, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(909, 30)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Check Target and SQM for Sales"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnexit
        '
        Me.btnexit.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnexit.Location = New System.Drawing.Point(844, 378)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(79, 31)
        Me.btnexit.TabIndex = 6
        Me.btnexit.Text = "&Exit"
        Me.btnexit.UseVisualStyleBackColor = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(13, 382)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(726, 23)
        Me.ProgressBar1.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(765, 362)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Label10"
        '
        'bg1
        '
        '
        'lbllastkpi
        '
        Me.lbllastkpi.AutoSize = True
        Me.lbllastkpi.Location = New System.Drawing.Point(10, 362)
        Me.lbllastkpi.Name = "lbllastkpi"
        Me.lbllastkpi.Size = New System.Drawing.Size(45, 13)
        Me.lbllastkpi.TabIndex = 9
        Me.lbllastkpi.Text = "Label11"
        '
        'ceknobrand
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ClientSize = New System.Drawing.Size(933, 422)
        Me.Controls.Add(Me.lbllastkpi)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btnexit)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnprocess)
        Me.Controls.Add(Me.dg1)
        Me.Controls.Add(Me.gb1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ceknobrand"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ceknobrand"
        Me.gb1.ResumeLayout(False)
        Me.gb1.PerformLayout()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gb1 As System.Windows.Forms.GroupBox
    Friend WithEvents dg1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnprocess As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnexit As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents bg1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents lbllastkpi As System.Windows.Forms.Label
    Friend WithEvents txtkpi As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnstore As System.Windows.Forms.Button
    Friend WithEvents cboyear As System.Windows.Forms.ComboBox
    Friend WithEvents cbomonth As System.Windows.Forms.ComboBox
    Friend WithEvents txtStore As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnreload3 As System.Windows.Forms.Button
    Friend WithEvents btnreload As System.Windows.Forms.Button
End Class
