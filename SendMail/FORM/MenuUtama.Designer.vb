<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuUtama
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MenuUtama))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip
        Me.StatusStrip = New System.Windows.Forms.StatusStrip
        Me.tsUser = New System.Windows.Forms.ToolStripStatusLabel
        Me.Panel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.BottomToolStripPanel = New System.Windows.Forms.ToolStripPanel
        Me.TopToolStripPanel = New System.Windows.Forms.ToolStripPanel
        Me.RightToolStripPanel = New System.Windows.Forms.ToolStripPanel
        Me.LeftToolStripPanel = New System.Windows.Forms.ToolStripPanel
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsKPI = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsTarget = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsstorenobrand = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.tsCount = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.StatusStrip.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(801, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsUser, Me.Panel1})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 724)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(801, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'tsUser
        '
        Me.tsUser.Image = Global.KPI.My.Resources.Resources.user
        Me.tsUser.Name = "tsUser"
        Me.tsUser.Size = New System.Drawing.Size(55, 17)
        Me.tsUser.Text = "User : "
        Me.tsUser.ToolTipText = "User "
        '
        'Panel1
        '
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(0, 17)
        '
        'BottomToolStripPanel
        '
        Me.BottomToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.BottomToolStripPanel.Name = "BottomToolStripPanel"
        Me.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.BottomToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.BottomToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'TopToolStripPanel
        '
        Me.TopToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.TopToolStripPanel.Name = "TopToolStripPanel"
        Me.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.TopToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.TopToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'RightToolStripPanel
        '
        Me.RightToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.RightToolStripPanel.Name = "RightToolStripPanel"
        Me.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.RightToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.RightToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'LeftToolStripPanel
        '
        Me.LeftToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.LeftToolStripPanel.Name = "LeftToolStripPanel"
        Me.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.LeftToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LeftToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsKPI, Me.ToolStripSeparator1, Me.tsTarget, Me.ToolStripSeparator2, Me.tsstorenobrand, Me.ToolStripSeparator4, Me.tsCount, Me.ToolStripSeparator3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(801, 25)
        Me.ToolStrip1.TabIndex = 12
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsKPI
        '
        Me.tsKPI.BackColor = System.Drawing.Color.Maroon
        Me.tsKPI.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsKPI.ForeColor = System.Drawing.Color.White
        Me.tsKPI.Image = CType(resources.GetObject("tsKPI.Image"), System.Drawing.Image)
        Me.tsKPI.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsKPI.Name = "tsKPI"
        Me.tsKPI.Size = New System.Drawing.Size(48, 22)
        Me.tsKPI.Text = "KPI"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsTarget
        '
        Me.tsTarget.BackColor = System.Drawing.Color.Maroon
        Me.tsTarget.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsTarget.ForeColor = System.Drawing.Color.White
        Me.tsTarget.Image = CType(resources.GetObject("tsTarget.Image"), System.Drawing.Image)
        Me.tsTarget.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsTarget.Name = "tsTarget"
        Me.tsTarget.Size = New System.Drawing.Size(68, 22)
        Me.tsTarget.Text = "Target"
        Me.tsTarget.ToolTipText = "Sales Target"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsstorenobrand
        '
        Me.tsstorenobrand.BackColor = System.Drawing.Color.Maroon
        Me.tsstorenobrand.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.tsstorenobrand.ForeColor = System.Drawing.Color.White
        Me.tsstorenobrand.Image = CType(resources.GetObject("tsstorenobrand.Image"), System.Drawing.Image)
        Me.tsstorenobrand.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsstorenobrand.Name = "tsstorenobrand"
        Me.tsstorenobrand.Size = New System.Drawing.Size(225, 22)
        Me.tsstorenobrand.Text = "Check Target and SQM for Sales"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'tsCount
        '
        Me.tsCount.BackColor = System.Drawing.Color.Maroon
        Me.tsCount.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsCount.ForeColor = System.Drawing.Color.White
        Me.tsCount.Image = CType(resources.GetObject("tsCount.Image"), System.Drawing.Image)
        Me.tsCount.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsCount.Name = "tsCount"
        Me.tsCount.Size = New System.Drawing.Size(65, 22)
        Me.tsCount.Text = "Count"
        Me.tsCount.ToolTipText = "Store Count Transaction"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'MenuUtama
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(801, 746)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "MenuUtama"
        Me.Text = "STAR Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents BottomToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents TopToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents RightToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents LeftToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsKPI As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsTarget As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsCount As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsUser As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Panel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsstorenobrand As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator

End Class
