<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserFingerForm
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
        Me.txtStore = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtIP = New System.Windows.Forms.ComboBox
        Me.BtnLihat1 = New System.Windows.Forms.Button
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.pBar = New System.Windows.Forms.ProgressBar
        Me.Lbl1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker
        Me.Button2 = New System.Windows.Forms.Button
        Me.BackgroundWorker3 = New System.ComponentModel.BackgroundWorker
        Me.Button3 = New System.Windows.Forms.Button
        Me.BackgroundWorker4 = New System.ComponentModel.BackgroundWorker
        Me.SuspendLayout()
        '
        'txtStore
        '
        Me.txtStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtStore.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStore.FormattingEnabled = True
        Me.txtStore.Location = New System.Drawing.Point(65, 12)
        Me.txtStore.Name = "txtStore"
        Me.txtStore.Size = New System.Drawing.Size(185, 21)
        Me.txtStore.TabIndex = 32
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(12, 15)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(33, 13)
        Me.Label16.TabIndex = 33
        Me.Label16.Text = "&Store"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(295, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 13)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "&IP"
        '
        'txtIP
        '
        Me.txtIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtIP.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIP.FormattingEnabled = True
        Me.txtIP.Location = New System.Drawing.Point(318, 12)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.Size = New System.Drawing.Size(185, 21)
        Me.txtIP.TabIndex = 34
        '
        'BtnLihat1
        '
        Me.BtnLihat1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLihat1.Location = New System.Drawing.Point(518, 11)
        Me.BtnLihat1.Name = "BtnLihat1"
        Me.BtnLihat1.Size = New System.Drawing.Size(103, 21)
        Me.BtnLihat1.TabIndex = 36
        Me.BtnLihat1.Text = "&Lihat Data Finger"
        Me.BtnLihat1.UseVisualStyleBackColor = True
        '
        'BackgroundWorker1
        '
        '
        'pBar
        '
        Me.pBar.Location = New System.Drawing.Point(15, 39)
        Me.pBar.Name = "pBar"
        Me.pBar.Size = New System.Drawing.Size(606, 18)
        Me.pBar.TabIndex = 37
        '
        'Lbl1
        '
        Me.Lbl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lbl1.AutoSize = True
        Me.Lbl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl1.Location = New System.Drawing.Point(12, 327)
        Me.Lbl1.Name = "Lbl1"
        Me.Lbl1.Size = New System.Drawing.Size(82, 13)
        Me.Lbl1.TabIndex = 38
        Me.Lbl1.Text = "Total Data : 0"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(408, 88)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(213, 21)
        Me.Button1.TabIndex = 39
        Me.Button1.Text = "&Upload Data Finger"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BackgroundWorker2
        '
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(251, 164)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(127, 55)
        Me.Button2.TabIndex = 40
        Me.Button2.Text = "U&pload"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'BackgroundWorker3
        '
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(105, 164)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(127, 55)
        Me.Button3.TabIndex = 41
        Me.Button3.Text = "&Download"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'BackgroundWorker4
        '
        '
        'UserFingerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PowderBlue
        Me.ClientSize = New System.Drawing.Size(702, 349)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Lbl1)
        Me.Controls.Add(Me.pBar)
        Me.Controls.Add(Me.BtnLihat1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtIP)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtStore)
        Me.MaximizeBox = False
        Me.Name = "UserFingerForm"
        Me.Text = "User Finger"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtStore As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtIP As System.Windows.Forms.ComboBox
    Friend WithEvents BtnLihat1 As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents pBar As System.Windows.Forms.ProgressBar
    Friend WithEvents Lbl1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker3 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker4 As System.ComponentModel.BackgroundWorker
End Class
