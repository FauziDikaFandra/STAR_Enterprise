<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KiosInformasiFORM
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Rbt1 = New System.Windows.Forms.RadioButton
        Me.Rbt2 = New System.Windows.Forms.RadioButton
        Me.Rbt3 = New System.Windows.Forms.RadioButton
        Me.Rbt5 = New System.Windows.Forms.RadioButton
        Me.Rbt4 = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Red
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(488, 43)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "KIOS INFORMASI"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Rbt1
        '
        Me.Rbt1.AutoSize = True
        Me.Rbt1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rbt1.ForeColor = System.Drawing.Color.White
        Me.Rbt1.Location = New System.Drawing.Point(12, 53)
        Me.Rbt1.Name = "Rbt1"
        Me.Rbt1.Size = New System.Drawing.Size(79, 20)
        Me.Rbt1.TabIndex = 1
        Me.Rbt1.TabStop = True
        Me.Rbt1.Text = "F1. Sales"
        Me.Rbt1.UseVisualStyleBackColor = True
        '
        'Rbt2
        '
        Me.Rbt2.AutoSize = True
        Me.Rbt2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rbt2.ForeColor = System.Drawing.Color.White
        Me.Rbt2.Location = New System.Drawing.Point(12, 79)
        Me.Rbt2.Name = "Rbt2"
        Me.Rbt2.Size = New System.Drawing.Size(130, 20)
        Me.Rbt2.TabIndex = 2
        Me.Rbt2.TabStop = True
        Me.Rbt2.Text = "F2. Ranking By SA"
        Me.Rbt2.UseVisualStyleBackColor = True
        '
        'Rbt3
        '
        Me.Rbt3.AutoSize = True
        Me.Rbt3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rbt3.ForeColor = System.Drawing.Color.White
        Me.Rbt3.Location = New System.Drawing.Point(12, 105)
        Me.Rbt3.Name = "Rbt3"
        Me.Rbt3.Size = New System.Drawing.Size(147, 20)
        Me.Rbt3.TabIndex = 3
        Me.Rbt3.TabStop = True
        Me.Rbt3.Text = "F3. Ranking By Brand"
        Me.Rbt3.UseVisualStyleBackColor = True
        '
        'Rbt5
        '
        Me.Rbt5.AutoSize = True
        Me.Rbt5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rbt5.ForeColor = System.Drawing.Color.White
        Me.Rbt5.Location = New System.Drawing.Point(332, 79)
        Me.Rbt5.Name = "Rbt5"
        Me.Rbt5.Size = New System.Drawing.Size(130, 20)
        Me.Rbt5.TabIndex = 5
        Me.Rbt5.TabStop = True
        Me.Rbt5.Text = "F5. Check Absensi"
        Me.Rbt5.UseVisualStyleBackColor = True
        '
        'Rbt4
        '
        Me.Rbt4.AutoSize = True
        Me.Rbt4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rbt4.ForeColor = System.Drawing.Color.White
        Me.Rbt4.Location = New System.Drawing.Point(332, 53)
        Me.Rbt4.Name = "Rbt4"
        Me.Rbt4.Size = New System.Drawing.Size(145, 20)
        Me.Rbt4.TabIndex = 4
        Me.Rbt4.TabStop = True
        Me.Rbt4.Text = "F4. Own Cross Sales"
        Me.Rbt4.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(97, 152)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(380, 78)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Cooper Black", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(10, 35)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(46)
        Me.TextBox1.Size = New System.Drawing.Size(359, 35)
        Me.TextBox1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(6, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(142, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Scan ID Barcode"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 2000
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(12, 158)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(79, 72)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'KiosInformasiFORM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSlateGray
        Me.ClientSize = New System.Drawing.Size(488, 244)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Rbt5)
        Me.Controls.Add(Me.Rbt4)
        Me.Controls.Add(Me.Rbt3)
        Me.Controls.Add(Me.Rbt2)
        Me.Controls.Add(Me.Rbt1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "KiosInformasiFORM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Rbt1 As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt2 As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt3 As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt5 As System.Windows.Forms.RadioButton
    Friend WithEvents Rbt4 As System.Windows.Forms.RadioButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
