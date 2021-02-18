<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmcekvoucher
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmcekvoucher))
        Me.dg1 = New System.Windows.Forms.DataGridView
        Me.gb1 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboStore = New System.Windows.Forms.ComboBox
        Me.rb4 = New System.Windows.Forms.RadioButton
        Me.rb3 = New System.Windows.Forms.RadioButton
        Me.rb2 = New System.Windows.Forms.RadioButton
        Me.rb1 = New System.Windows.Forms.RadioButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtp2 = New System.Windows.Forms.DateTimePicker
        Me.dtp3 = New System.Windows.Forms.DateTimePicker
        Me.btnreload = New System.Windows.Forms.Button
        Me.gb2 = New System.Windows.Forms.GroupBox
        Me.rbS003 = New System.Windows.Forms.RadioButton
        Me.rbS002 = New System.Windows.Forms.RadioButton
        Me.rbS001 = New System.Windows.Forms.RadioButton
        Me.chk1 = New System.Windows.Forms.CheckBox
        Me.txtscan = New System.Windows.Forms.TextBox
        Me.dtp1 = New System.Windows.Forms.DateTimePicker
        Me.tm1 = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip = New System.Windows.Forms.StatusStrip
        Me.ts1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ts2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ts3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ts4 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ts5 = New System.Windows.Forms.ToolStripStatusLabel
        Me.cm1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Report1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ByDetailToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.Report2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ByDetailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ByDetailRedeemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ByTotalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ByPaidToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CheckToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tm2 = New System.Windows.Forms.Timer(Me.components)
        Me.btnreport = New System.Windows.Forms.Button
        Me.lbltotal = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.RepairScanDateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb1.SuspendLayout()
        Me.gb2.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.cm1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dg1
        '
        Me.dg1.AllowUserToAddRows = False
        Me.dg1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dg1.BackgroundColor = System.Drawing.SystemColors.Info
        Me.dg1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg1.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dg1.Location = New System.Drawing.Point(14, 301)
        Me.dg1.Name = "dg1"
        Me.dg1.Size = New System.Drawing.Size(487, 192)
        Me.dg1.TabIndex = 0
        '
        'gb1
        '
        Me.gb1.Controls.Add(Me.Label5)
        Me.gb1.Controls.Add(Me.cboStore)
        Me.gb1.Controls.Add(Me.rb4)
        Me.gb1.Controls.Add(Me.rb3)
        Me.gb1.Controls.Add(Me.rb2)
        Me.gb1.Controls.Add(Me.rb1)
        Me.gb1.Controls.Add(Me.Label4)
        Me.gb1.Controls.Add(Me.Label2)
        Me.gb1.Controls.Add(Me.Label1)
        Me.gb1.Controls.Add(Me.dtp2)
        Me.gb1.Controls.Add(Me.dtp3)
        Me.gb1.Controls.Add(Me.btnreload)
        Me.gb1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gb1.Location = New System.Drawing.Point(10, 147)
        Me.gb1.Name = "gb1"
        Me.gb1.Size = New System.Drawing.Size(489, 122)
        Me.gb1.TabIndex = 3
        Me.gb1.TabStop = False
        Me.gb1.Text = "Option"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 16)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Store"
        '
        'cboStore
        '
        Me.cboStore.FormattingEnabled = True
        Me.cboStore.Location = New System.Drawing.Point(81, 92)
        Me.cboStore.Name = "cboStore"
        Me.cboStore.Size = New System.Drawing.Size(121, 24)
        Me.cboStore.TabIndex = 19
        '
        'rb4
        '
        Me.rb4.AutoSize = True
        Me.rb4.Location = New System.Drawing.Point(207, 74)
        Me.rb4.Name = "rb4"
        Me.rb4.Size = New System.Drawing.Size(52, 20)
        Me.rb4.TabIndex = 18
        Me.rb4.TabStop = True
        Me.rb4.Text = "ALL"
        Me.rb4.UseVisualStyleBackColor = True
        '
        'rb3
        '
        Me.rb3.AutoSize = True
        Me.rb3.Location = New System.Drawing.Point(165, 74)
        Me.rb3.Name = "rb3"
        Me.rb3.Size = New System.Drawing.Size(36, 20)
        Me.rb3.TabIndex = 17
        Me.rb3.TabStop = True
        Me.rb3.Text = "C"
        Me.rb3.UseVisualStyleBackColor = True
        '
        'rb2
        '
        Me.rb2.AutoSize = True
        Me.rb2.Location = New System.Drawing.Point(123, 74)
        Me.rb2.Name = "rb2"
        Me.rb2.Size = New System.Drawing.Size(36, 20)
        Me.rb2.TabIndex = 16
        Me.rb2.TabStop = True
        Me.rb2.Text = "B"
        Me.rb2.UseVisualStyleBackColor = True
        '
        'rb1
        '
        Me.rb1.AutoSize = True
        Me.rb1.Location = New System.Drawing.Point(81, 74)
        Me.rb1.Name = "rb1"
        Me.rb1.Size = New System.Drawing.Size(36, 20)
        Me.rb1.TabIndex = 15
        Me.rb1.TabStop = True
        Me.rb1.Text = "A"
        Me.rb1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label2.Location = New System.Drawing.Point(3, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "End Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(3, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 16)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Start Date"
        '
        'dtp2
        '
        Me.dtp2.Location = New System.Drawing.Point(81, 22)
        Me.dtp2.Name = "dtp2"
        Me.dtp2.Size = New System.Drawing.Size(273, 22)
        Me.dtp2.TabIndex = 8
        '
        'dtp3
        '
        Me.dtp3.Location = New System.Drawing.Point(80, 49)
        Me.dtp3.Name = "dtp3"
        Me.dtp3.Size = New System.Drawing.Size(273, 22)
        Me.dtp3.TabIndex = 7
        '
        'btnreload
        '
        Me.btnreload.BackColor = System.Drawing.Color.Tomato
        Me.btnreload.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnreload.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnreload.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnreload.Location = New System.Drawing.Point(357, 21)
        Me.btnreload.Name = "btnreload"
        Me.btnreload.Size = New System.Drawing.Size(126, 54)
        Me.btnreload.TabIndex = 6
        Me.btnreload.Text = "Reload"
        Me.btnreload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnreload.UseVisualStyleBackColor = False
        '
        'gb2
        '
        Me.gb2.Controls.Add(Me.rbS003)
        Me.gb2.Controls.Add(Me.rbS002)
        Me.gb2.Controls.Add(Me.rbS001)
        Me.gb2.Controls.Add(Me.chk1)
        Me.gb2.Controls.Add(Me.txtscan)
        Me.gb2.Controls.Add(Me.dtp1)
        Me.gb2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gb2.Location = New System.Drawing.Point(12, 0)
        Me.gb2.Name = "gb2"
        Me.gb2.Size = New System.Drawing.Size(390, 148)
        Me.gb2.TabIndex = 4
        Me.gb2.TabStop = False
        Me.gb2.Text = "Menu Scan"
        '
        'rbS003
        '
        Me.rbS003.AutoSize = True
        Me.rbS003.Location = New System.Drawing.Point(139, 47)
        Me.rbS003.Name = "rbS003"
        Me.rbS003.Size = New System.Drawing.Size(60, 20)
        Me.rbS003.TabIndex = 7
        Me.rbS003.TabStop = True
        Me.rbS003.Text = "S003"
        Me.rbS003.UseVisualStyleBackColor = True
        '
        'rbS002
        '
        Me.rbS002.AutoSize = True
        Me.rbS002.Location = New System.Drawing.Point(73, 47)
        Me.rbS002.Name = "rbS002"
        Me.rbS002.Size = New System.Drawing.Size(60, 20)
        Me.rbS002.TabIndex = 6
        Me.rbS002.TabStop = True
        Me.rbS002.Text = "S002"
        Me.rbS002.UseVisualStyleBackColor = True
        '
        'rbS001
        '
        Me.rbS001.AutoSize = True
        Me.rbS001.Location = New System.Drawing.Point(7, 47)
        Me.rbS001.Name = "rbS001"
        Me.rbS001.Size = New System.Drawing.Size(60, 20)
        Me.rbS001.TabIndex = 5
        Me.rbS001.TabStop = True
        Me.rbS001.Text = "S001"
        Me.rbS001.UseVisualStyleBackColor = True
        '
        'chk1
        '
        Me.chk1.AutoSize = True
        Me.chk1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.chk1.Location = New System.Drawing.Point(275, 21)
        Me.chk1.Name = "chk1"
        Me.chk1.Size = New System.Drawing.Size(109, 20)
        Me.chk1.TabIndex = 4
        Me.chk1.Text = "Active Scan"
        Me.chk1.UseVisualStyleBackColor = True
        '
        'txtscan
        '
        Me.txtscan.BackColor = System.Drawing.Color.Gainsboro
        Me.txtscan.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtscan.Location = New System.Drawing.Point(7, 69)
        Me.txtscan.Multiline = True
        Me.txtscan.Name = "txtscan"
        Me.txtscan.Size = New System.Drawing.Size(377, 69)
        Me.txtscan.TabIndex = 3
        '
        'dtp1
        '
        Me.dtp1.Location = New System.Drawing.Point(7, 19)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(265, 22)
        Me.dtp1.TabIndex = 2
        '
        'tm1
        '
        Me.tm1.Enabled = True
        Me.tm1.Interval = 1000
        '
        'StatusStrip
        '
        Me.StatusStrip.BackColor = System.Drawing.Color.Tomato
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts1, Me.ts2, Me.ts3, Me.ts4, Me.ts5})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 512)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(516, 22)
        Me.StatusStrip.TabIndex = 6
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ts1
        '
        Me.ts1.Name = "ts1"
        Me.ts1.Size = New System.Drawing.Size(22, 17)
        Me.ts1.Text = "ts1"
        '
        'ts2
        '
        Me.ts2.Name = "ts2"
        Me.ts2.Size = New System.Drawing.Size(22, 17)
        Me.ts2.Text = "ts2"
        '
        'ts3
        '
        Me.ts3.Name = "ts3"
        Me.ts3.Size = New System.Drawing.Size(22, 17)
        Me.ts3.Text = "ts3"
        '
        'ts4
        '
        Me.ts4.Name = "ts4"
        Me.ts4.Size = New System.Drawing.Size(22, 17)
        Me.ts4.Text = "ts4"
        '
        'ts5
        '
        Me.ts5.Name = "ts5"
        Me.ts5.Size = New System.Drawing.Size(22, 17)
        Me.ts5.Text = "ts5"
        '
        'cm1
        '
        Me.cm1.BackColor = System.Drawing.Color.Tomato
        Me.cm1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cm1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Report1ToolStripMenuItem, Me.Report2ToolStripMenuItem, Me.RepairScanDateToolStripMenuItem})
        Me.cm1.Name = "cm1"
        Me.cm1.Size = New System.Drawing.Size(200, 92)
        '
        'Report1ToolStripMenuItem
        '
        Me.Report1ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ByDetailToolStripMenuItem1})
        Me.Report1ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Report1ToolStripMenuItem.Name = "Report1ToolStripMenuItem"
        Me.Report1ToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.Report1ToolStripMenuItem.Text = "&Voucher Report"
        '
        'ByDetailToolStripMenuItem1
        '
        Me.ByDetailToolStripMenuItem1.BackColor = System.Drawing.Color.Tomato
        Me.ByDetailToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ByDetailToolStripMenuItem1.Name = "ByDetailToolStripMenuItem1"
        Me.ByDetailToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.ByDetailToolStripMenuItem1.Text = "By Detail"
        '
        'Report2ToolStripMenuItem
        '
        Me.Report2ToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        Me.Report2ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ByDetailToolStripMenuItem, Me.ByDetailRedeemToolStripMenuItem, Me.ByTotalToolStripMenuItem, Me.ByPaidToolStripMenuItem, Me.CheckToolStripMenuItem})
        Me.Report2ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Report2ToolStripMenuItem.Name = "Report2ToolStripMenuItem"
        Me.Report2ToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.Report2ToolStripMenuItem.Text = "&Compare Paid"
        '
        'ByDetailToolStripMenuItem
        '
        Me.ByDetailToolStripMenuItem.BackColor = System.Drawing.Color.Tomato
        Me.ByDetailToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ByDetailToolStripMenuItem.Name = "ByDetailToolStripMenuItem"
        Me.ByDetailToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.ByDetailToolStripMenuItem.Text = "By Detail Register"
        '
        'ByDetailRedeemToolStripMenuItem
        '
        Me.ByDetailRedeemToolStripMenuItem.BackColor = System.Drawing.Color.Tomato
        Me.ByDetailRedeemToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ByDetailRedeemToolStripMenuItem.Name = "ByDetailRedeemToolStripMenuItem"
        Me.ByDetailRedeemToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.ByDetailRedeemToolStripMenuItem.Text = "By Detail Redeem"
        '
        'ByTotalToolStripMenuItem
        '
        Me.ByTotalToolStripMenuItem.BackColor = System.Drawing.Color.Tomato
        Me.ByTotalToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ByTotalToolStripMenuItem.Name = "ByTotalToolStripMenuItem"
        Me.ByTotalToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.ByTotalToolStripMenuItem.Text = "By Total"
        '
        'ByPaidToolStripMenuItem
        '
        Me.ByPaidToolStripMenuItem.BackColor = System.Drawing.Color.Tomato
        Me.ByPaidToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ByPaidToolStripMenuItem.Name = "ByPaidToolStripMenuItem"
        Me.ByPaidToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.ByPaidToolStripMenuItem.Text = "By Paid"
        '
        'CheckToolStripMenuItem
        '
        Me.CheckToolStripMenuItem.BackColor = System.Drawing.Color.Tomato
        Me.CheckToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CheckToolStripMenuItem.Name = "CheckToolStripMenuItem"
        Me.CheckToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.CheckToolStripMenuItem.Text = "Check"
        '
        'tm2
        '
        Me.tm2.Enabled = True
        Me.tm2.Interval = 1700
        '
        'btnreport
        '
        Me.btnreport.BackColor = System.Drawing.Color.Tomato
        Me.btnreport.ContextMenuStrip = Me.cm1
        Me.btnreport.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnreport.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnreport.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnreport.Location = New System.Drawing.Point(409, 7)
        Me.btnreport.Name = "btnreport"
        Me.btnreport.Size = New System.Drawing.Size(93, 90)
        Me.btnreport.TabIndex = 2
        Me.btnreport.Text = "Preview Report"
        Me.btnreport.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnreport.UseVisualStyleBackColor = False
        '
        'lbltotal
        '
        Me.lbltotal.AutoSize = True
        Me.lbltotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lbltotal.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lbltotal.Location = New System.Drawing.Point(60, 282)
        Me.lbltotal.Name = "lbltotal"
        Me.lbltotal.Size = New System.Drawing.Size(16, 16)
        Me.lbltotal.TabIndex = 10
        Me.lbltotal.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label3.Location = New System.Drawing.Point(13, 282)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 16)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Total :"
        '
        'RepairScanDateToolStripMenuItem
        '
        Me.RepairScanDateToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.RepairScanDateToolStripMenuItem.Name = "RepairScanDateToolStripMenuItem"
        Me.RepairScanDateToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.RepairScanDateToolStripMenuItem.Text = "&Repair Scan Date"
        '
        'frmcekvoucher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Teal
        Me.ClientSize = New System.Drawing.Size(516, 534)
        Me.Controls.Add(Me.lbltotal)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.gb2)
        Me.Controls.Add(Me.gb1)
        Me.Controls.Add(Me.dg1)
        Me.Controls.Add(Me.btnreport)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmcekvoucher"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cek Voucher"
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb1.ResumeLayout(False)
        Me.gb1.PerformLayout()
        Me.gb2.ResumeLayout(False)
        Me.gb2.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.cm1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dg1 As System.Windows.Forms.DataGridView
    Friend WithEvents gb1 As System.Windows.Forms.GroupBox
    Friend WithEvents gb2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtscan As System.Windows.Forms.TextBox
    Friend WithEvents dtp1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnreload As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtp2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents tm1 As System.Windows.Forms.Timer
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ts1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ts2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ts3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ts4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents chk1 As System.Windows.Forms.CheckBox
    Friend WithEvents ts5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents rb4 As System.Windows.Forms.RadioButton
    Friend WithEvents rb3 As System.Windows.Forms.RadioButton
    Friend WithEvents rb2 As System.Windows.Forms.RadioButton
    Friend WithEvents rb1 As System.Windows.Forms.RadioButton
    Friend WithEvents tm2 As System.Windows.Forms.Timer
    Friend WithEvents cboStore As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rbS003 As System.Windows.Forms.RadioButton
    Friend WithEvents rbS002 As System.Windows.Forms.RadioButton
    Friend WithEvents rbS001 As System.Windows.Forms.RadioButton
    Friend WithEvents cm1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Report1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Report2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ByDetailToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ByDetailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnreport As System.Windows.Forms.Button
    Friend WithEvents ByDetailRedeemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lbltotal As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ByTotalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ByPaidToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RepairScanDateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
