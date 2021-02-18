<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListKPI
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
        Me.LV = New System.Windows.Forms.ListView
        Me.btnChoose = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnColse = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'LV
        '
        Me.LV.FullRowSelect = True
        Me.LV.GridLines = True
        Me.LV.Location = New System.Drawing.Point(12, 37)
        Me.LV.Name = "LV"
        Me.LV.Size = New System.Drawing.Size(359, 410)
        Me.LV.TabIndex = 0
        Me.LV.UseCompatibleStateImageBehavior = False
        Me.LV.View = System.Windows.Forms.View.Details
        '
        'btnChoose
        '
        Me.btnChoose.Location = New System.Drawing.Point(18, 455)
        Me.btnChoose.Name = "btnChoose"
        Me.btnChoose.Size = New System.Drawing.Size(74, 32)
        Me.btnChoose.TabIndex = 1
        Me.btnChoose.Text = "Choose"
        Me.btnChoose.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Maroon
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(358, 29)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Find - KPI"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnColse
        '
        Me.btnColse.Location = New System.Drawing.Point(93, 455)
        Me.btnColse.Name = "btnColse"
        Me.btnColse.Size = New System.Drawing.Size(74, 32)
        Me.btnColse.TabIndex = 3
        Me.btnColse.Text = "Close"
        Me.btnColse.UseVisualStyleBackColor = True
        '
        'frmListKPI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(378, 492)
        Me.Controls.Add(Me.btnColse)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnChoose)
        Me.Controls.Add(Me.LV)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmListKPI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmListKPI"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LV As System.Windows.Forms.ListView
    Friend WithEvents btnChoose As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnColse As System.Windows.Forms.Button
End Class
