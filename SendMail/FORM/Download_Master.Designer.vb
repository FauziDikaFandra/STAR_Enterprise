<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Download_Master
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbAll = New System.Windows.Forms.CheckBox
        Me.cbSC = New System.Windows.Forms.CheckBox
        Me.cbMD = New System.Windows.Forms.CheckBox
        Me.cbLD = New System.Windows.Forms.CheckBox
        Me.cbLA = New System.Windows.Forms.CheckBox
        Me.cbHH = New System.Windows.Forms.CheckBox
        Me.cbCH = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.clbBrand = New System.Windows.Forms.CheckedListBox
        Me.txtScr2 = New System.Windows.Forms.TextBox
        Me.cbAllBrand = New System.Windows.Forms.CheckBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtSrc = New System.Windows.Forms.TextBox
        Me.cbAllPLU = New System.Windows.Forms.CheckBox
        Me.clbArticle = New System.Windows.Forms.CheckedListBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.DirectoryEntry1 = New System.DirectoryServices.DirectoryEntry
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.CbStore = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbAll)
        Me.GroupBox1.Controls.Add(Me.cbSC)
        Me.GroupBox1.Controls.Add(Me.cbMD)
        Me.GroupBox1.Controls.Add(Me.cbLD)
        Me.GroupBox1.Controls.Add(Me.cbLA)
        Me.GroupBox1.Controls.Add(Me.cbHH)
        Me.GroupBox1.Controls.Add(Me.cbCH)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(11, 70)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(255, 112)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "-SBU-"
        '
        'cbAll
        '
        Me.cbAll.AutoSize = True
        Me.cbAll.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAll.Location = New System.Drawing.Point(16, 19)
        Me.cbAll.Name = "cbAll"
        Me.cbAll.Size = New System.Drawing.Size(59, 17)
        Me.cbAll.TabIndex = 6
        Me.cbAll.Tag = "All"
        Me.cbAll.Text = "All SBU"
        Me.cbAll.UseVisualStyleBackColor = True
        '
        'cbSC
        '
        Me.cbSC.AutoSize = True
        Me.cbSC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSC.Location = New System.Drawing.Point(124, 86)
        Me.cbSC.Name = "cbSC"
        Me.cbSC.Size = New System.Drawing.Size(100, 17)
        Me.cbSC.TabIndex = 5
        Me.cbSC.Tag = "SC"
        Me.cbSC.Text = "Support Center"
        Me.cbSC.UseVisualStyleBackColor = True
        '
        'cbMD
        '
        Me.cbMD.AutoSize = True
        Me.cbMD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMD.Location = New System.Drawing.Point(124, 64)
        Me.cbMD.Name = "cbMD"
        Me.cbMD.Size = New System.Drawing.Size(46, 17)
        Me.cbMD.TabIndex = 4
        Me.cbMD.Tag = "MD"
        Me.cbMD.Text = "Men"
        Me.cbMD.UseVisualStyleBackColor = True
        '
        'cbLD
        '
        Me.cbLD.AutoSize = True
        Me.cbLD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbLD.Location = New System.Drawing.Point(124, 42)
        Me.cbLD.Name = "cbLD"
        Me.cbLD.Size = New System.Drawing.Size(65, 17)
        Me.cbLD.TabIndex = 3
        Me.cbLD.Tag = "LD"
        Me.cbLD.Text = "Ladies 2"
        Me.cbLD.UseVisualStyleBackColor = True
        '
        'cbLA
        '
        Me.cbLA.AutoSize = True
        Me.cbLA.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbLA.Location = New System.Drawing.Point(16, 86)
        Me.cbLA.Name = "cbLA"
        Me.cbLA.Size = New System.Drawing.Size(65, 17)
        Me.cbLA.TabIndex = 2
        Me.cbLA.Tag = "LA"
        Me.cbLA.Text = "Ladies 1"
        Me.cbLA.UseVisualStyleBackColor = True
        '
        'cbHH
        '
        Me.cbHH.AutoSize = True
        Me.cbHH.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbHH.Location = New System.Drawing.Point(16, 64)
        Me.cbHH.Name = "cbHH"
        Me.cbHH.Size = New System.Drawing.Size(53, 17)
        Me.cbHH.TabIndex = 1
        Me.cbHH.Tag = "HH"
        Me.cbHH.Text = "Home"
        Me.cbHH.UseVisualStyleBackColor = True
        '
        'cbCH
        '
        Me.cbCH.AutoSize = True
        Me.cbCH.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCH.Location = New System.Drawing.Point(16, 42)
        Me.cbCH.Name = "cbCH"
        Me.cbCH.Size = New System.Drawing.Size(65, 17)
        Me.cbCH.TabIndex = 0
        Me.cbCH.Tag = "CH"
        Me.cbCH.Text = "Children"
        Me.cbCH.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.clbBrand)
        Me.GroupBox2.Controls.Add(Me.txtScr2)
        Me.GroupBox2.Controls.Add(Me.cbAllBrand)
        Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(11, 188)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(255, 180)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "-Brand-"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(97, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Search :"
        '
        'clbBrand
        '
        Me.clbBrand.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.clbBrand.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clbBrand.FormattingEnabled = True
        Me.clbBrand.Location = New System.Drawing.Point(5, 43)
        Me.clbBrand.Name = "clbBrand"
        Me.clbBrand.Size = New System.Drawing.Size(244, 132)
        Me.clbBrand.TabIndex = 0
        '
        'txtScr2
        '
        Me.txtScr2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtScr2.Location = New System.Drawing.Point(150, 16)
        Me.txtScr2.Multiline = True
        Me.txtScr2.Name = "txtScr2"
        Me.txtScr2.Size = New System.Drawing.Size(101, 20)
        Me.txtScr2.TabIndex = 13
        '
        'cbAllBrand
        '
        Me.cbAllBrand.AutoSize = True
        Me.cbAllBrand.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAllBrand.Location = New System.Drawing.Point(7, 18)
        Me.cbAllBrand.Name = "cbAllBrand"
        Me.cbAllBrand.Size = New System.Drawing.Size(68, 17)
        Me.cbAllBrand.TabIndex = 7
        Me.cbAllBrand.Tag = "All"
        Me.cbAllBrand.Text = "All Brand"
        Me.cbAllBrand.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txtSrc)
        Me.GroupBox3.Controls.Add(Me.cbAllPLU)
        Me.GroupBox3.Controls.Add(Me.clbArticle)
        Me.GroupBox3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(282, 33)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(323, 335)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "-PLU-"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(141, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Search :"
        '
        'txtSrc
        '
        Me.txtSrc.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSrc.Location = New System.Drawing.Point(194, 15)
        Me.txtSrc.Multiline = True
        Me.txtSrc.Name = "txtSrc"
        Me.txtSrc.Size = New System.Drawing.Size(124, 20)
        Me.txtSrc.TabIndex = 9
        '
        'cbAllPLU
        '
        Me.cbAllPLU.AutoSize = True
        Me.cbAllPLU.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAllPLU.Location = New System.Drawing.Point(8, 19)
        Me.cbAllPLU.Name = "cbAllPLU"
        Me.cbAllPLU.Size = New System.Drawing.Size(58, 17)
        Me.cbAllPLU.TabIndex = 8
        Me.cbAllPLU.Tag = "All"
        Me.cbAllPLU.Text = "All PLU"
        Me.cbAllPLU.UseVisualStyleBackColor = True
        '
        'clbArticle
        '
        Me.clbArticle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.clbArticle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clbArticle.FormattingEnabled = True
        Me.clbArticle.Location = New System.Drawing.Point(5, 41)
        Me.clbArticle.Name = "clbArticle"
        Me.clbArticle.Size = New System.Drawing.Size(313, 276)
        Me.clbArticle.TabIndex = 8
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(10, 383)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(255, 27)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Download Artikel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(282, 383)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(323, 27)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 371)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Total Brand Checked : 0"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(287, 371)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Total PLU Checked : 0"
        '
        'Label14
        '
        Me.Label14.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.BackColor = System.Drawing.Color.DarkBlue
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.Window
        Me.Label14.Location = New System.Drawing.Point(2, 2)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(613, 28)
        Me.Label14.TabIndex = 87
        Me.Label14.Text = "   Download Master "
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CbStore
        '
        Me.CbStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbStore.FormattingEnabled = True
        Me.CbStore.Location = New System.Drawing.Point(68, 40)
        Me.CbStore.Name = "CbStore"
        Me.CbStore.Size = New System.Drawing.Size(198, 21)
        Me.CbStore.TabIndex = 88
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(15, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 89
        Me.Label5.Text = "Store : "
        '
        'Download_Master
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(615, 414)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CbStore)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Download_Master"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Download_Master"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbHH As System.Windows.Forms.CheckBox
    Friend WithEvents cbCH As System.Windows.Forms.CheckBox
    Friend WithEvents cbMD As System.Windows.Forms.CheckBox
    Friend WithEvents cbLD As System.Windows.Forms.CheckBox
    Friend WithEvents cbLA As System.Windows.Forms.CheckBox
    Friend WithEvents cbSC As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents clbBrand As System.Windows.Forms.CheckedListBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cbAll As System.Windows.Forms.CheckBox
    Friend WithEvents DirectoryEntry1 As System.DirectoryServices.DirectoryEntry
    Friend WithEvents cbAllBrand As System.Windows.Forms.CheckBox
    Friend WithEvents cbAllPLU As System.Windows.Forms.CheckBox
    Friend WithEvents clbArticle As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSrc As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtScr2 As System.Windows.Forms.TextBox
    Friend WithEvents CbStore As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
End Class
