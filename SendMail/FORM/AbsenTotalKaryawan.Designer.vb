<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AbsenTotalKaryawan
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
        Me.lket = New System.Windows.Forms.Label
        Me.lblPeriode = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.cmbColumn = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbRow = New System.Windows.Forms.ComboBox
        Me.BtnPrint = New System.Windows.Forms.Button
        Me.dt2 = New System.Windows.Forms.DateTimePicker
        Me.dt1 = New System.Windows.Forms.DateTimePicker
        Me.SuspendLayout()
        '
        'lket
        '
        Me.lket.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lket.Dock = System.Windows.Forms.DockStyle.Top
        Me.lket.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lket.ForeColor = System.Drawing.Color.White
        Me.lket.Location = New System.Drawing.Point(0, 0)
        Me.lket.Name = "lket"
        Me.lket.Size = New System.Drawing.Size(400, 30)
        Me.lket.TabIndex = 2
        Me.lket.Text = "Setting Report Total Karyawan"
        Me.lket.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPeriode
        '
        Me.lblPeriode.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblPeriode.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeriode.Location = New System.Drawing.Point(0, 30)
        Me.lblPeriode.Name = "lblPeriode"
        Me.lblPeriode.Size = New System.Drawing.Size(400, 35)
        Me.lblPeriode.TabIndex = 3
        Me.lblPeriode.Text = "Periode"
        Me.lblPeriode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(24, 71)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(67, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Field &Column"
        '
        'cmbColumn
        '
        Me.cmbColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbColumn.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbColumn.FormattingEnabled = True
        Me.cmbColumn.Location = New System.Drawing.Point(116, 68)
        Me.cmbColumn.Name = "cmbColumn"
        Me.cmbColumn.Size = New System.Drawing.Size(254, 21)
        Me.cmbColumn.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Field &Row"
        '
        'cmbRow
        '
        Me.cmbRow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRow.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRow.FormattingEnabled = True
        Me.cmbRow.Location = New System.Drawing.Point(116, 95)
        Me.cmbRow.Name = "cmbRow"
        Me.cmbRow.Size = New System.Drawing.Size(254, 21)
        Me.cmbRow.TabIndex = 3
        '
        'BtnPrint
        '
        Me.BtnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPrint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPrint.Location = New System.Drawing.Point(312, 122)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(58, 30)
        Me.BtnPrint.TabIndex = 4
        Me.BtnPrint.Text = "&Print"
        Me.BtnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'dt2
        '
        Me.dt2.CustomFormat = "dd-MMM-yyyy"
        Me.dt2.Enabled = False
        Me.dt2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt2.Location = New System.Drawing.Point(27, 149)
        Me.dt2.Name = "dt2"
        Me.dt2.Size = New System.Drawing.Size(142, 20)
        Me.dt2.TabIndex = 135
        Me.dt2.Visible = False
        '
        'dt1
        '
        Me.dt1.CustomFormat = "dd-MMM-yyyy"
        Me.dt1.Enabled = False
        Me.dt1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt1.Location = New System.Drawing.Point(27, 124)
        Me.dt1.Name = "dt1"
        Me.dt1.Size = New System.Drawing.Size(142, 20)
        Me.dt1.TabIndex = 134
        Me.dt1.Visible = False
        '
        'AbsenTotalKaryawan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 169)
        Me.Controls.Add(Me.dt2)
        Me.Controls.Add(Me.dt1)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbRow)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.cmbColumn)
        Me.Controls.Add(Me.lblPeriode)
        Me.Controls.Add(Me.lket)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AbsenTotalKaryawan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Setting Report Total Karyawan"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lket As System.Windows.Forms.Label
    Friend WithEvents lblPeriode As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbColumn As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbRow As System.Windows.Forms.ComboBox
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents dt2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt1 As System.Windows.Forms.DateTimePicker
End Class
