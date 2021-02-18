<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmreport
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
        Me.crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'crv1
        '
        Me.crv1.ActiveViewIndex = -1
        Me.crv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crv1.DisplayGroupTree = False
        Me.crv1.Location = New System.Drawing.Point(12, 12)
        Me.crv1.Name = "crv1"
        Me.crv1.SelectionFormula = ""
        Me.crv1.Size = New System.Drawing.Size(1021, 722)
        Me.crv1.TabIndex = 6
        Me.crv1.ViewTimeSelectionFormula = ""
        '
        'frmreport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Teal
        Me.ClientSize = New System.Drawing.Size(1054, 746)
        Me.Controls.Add(Me.crv1)
        Me.Name = "frmreport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmreport"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
