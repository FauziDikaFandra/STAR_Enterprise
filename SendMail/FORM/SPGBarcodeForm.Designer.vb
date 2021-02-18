<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SPGBarcodeForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SPGBarcodeForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label6 = New System.Windows.Forms.Label
        Me.dg = New System.Windows.Forms.DataGridView
        Me.colChoose = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtPLU = New System.Windows.Forms.TextBox
        Me.dgSPG = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnPrint = New System.Windows.Forms.Button
        Me.BtnClear = New System.Windows.Forms.Button
        Me.LblStore = New System.Windows.Forms.Label
        Me.LblFont = New System.Windows.Forms.Label
        Me.PrintKPT = New System.Drawing.Printing.PrintDocument
        Me.dlgPrintPreview2 = New System.Windows.Forms.PrintPreviewDialog
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FocusPLUToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FocusGridToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FocusFindToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FocusPriceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FocusQtyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.dgKPT = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Button1 = New System.Windows.Forms.Button
        Me.dgKPL = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrintKPL = New System.Drawing.Printing.PrintDocument
        CType(Me.dg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgSPG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgKPT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgKPL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(235, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(10, 13)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = ":"
        '
        'dg
        '
        Me.dg.AllowUserToAddRows = False
        Me.dg.AllowUserToDeleteRows = False
        Me.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colChoose, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column12})
        Me.dg.Location = New System.Drawing.Point(11, 245)
        Me.dg.Name = "dg"
        Me.dg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dg.Size = New System.Drawing.Size(748, 180)
        Me.dg.TabIndex = 4
        '
        'colChoose
        '
        Me.colChoose.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colChoose.DataPropertyName = "choose"
        Me.colChoose.FalseValue = "0"
        Me.colChoose.HeaderText = "Choose"
        Me.colChoose.Name = "colChoose"
        Me.colChoose.TrueValue = "1"
        Me.colChoose.Width = 50
        '
        'Column8
        '
        Me.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column8.DataPropertyName = "spg_id"
        Me.Column8.HeaderText = "SPG ID"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 70
        '
        'Column9
        '
        Me.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column9.DataPropertyName = "spg_barcode"
        Me.Column9.HeaderText = "SPG Barcode"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column10
        '
        Me.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column10.DataPropertyName = "spg_name"
        Me.Column10.HeaderText = "SPG Name"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Width = 150
        '
        'Column11
        '
        Me.Column11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column11.DataPropertyName = "qty"
        Me.Column11.HeaderText = "Qty"
        Me.Column11.Name = "Column11"
        Me.Column11.Width = 80
        '
        'Column12
        '
        Me.Column12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column12.DataPropertyName = "isi"
        Me.Column12.HeaderText = "Isi"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(11, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(218, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "&Cari Barcode / Nama / Brand (Alt + P)"
        '
        'txtPLU
        '
        Me.txtPLU.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtPLU.Location = New System.Drawing.Point(251, 12)
        Me.txtPLU.Name = "txtPLU"
        Me.txtPLU.Size = New System.Drawing.Size(506, 20)
        Me.txtPLU.TabIndex = 1
        '
        'dgSPG
        '
        Me.dgSPG.AllowUserToAddRows = False
        Me.dgSPG.AllowUserToDeleteRows = False
        Me.dgSPG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSPG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7})
        Me.dgSPG.Location = New System.Drawing.Point(11, 38)
        Me.dgSPG.Name = "dgSPG"
        Me.dgSPG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgSPG.Size = New System.Drawing.Size(748, 172)
        Me.dgSPG.TabIndex = 2
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column1.DataPropertyName = "spg_id"
        Me.Column1.HeaderText = "SPG ID"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 70
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column2.DataPropertyName = "spg_barcode"
        Me.Column2.HeaderText = "SPG Barcode"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column3.DataPropertyName = "spg_name"
        Me.Column3.HeaderText = "SPG Name"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 150
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column4.DataPropertyName = "bagian"
        Me.Column4.HeaderText = "Bagian"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column5.DataPropertyName = "sbu"
        Me.Column5.HeaderText = "SBU"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 50
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column6.DataPropertyName = "dept"
        Me.Column6.HeaderText = "Dept"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column7.DataPropertyName = "brand"
        Me.Column7.HeaderText = "Brand"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(11, 229)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Print Barcode (Alt + G)"
        '
        'BtnPrint
        '
        Me.BtnPrint.BackColor = System.Drawing.Color.Blue
        Me.BtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPrint.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.ForeColor = System.Drawing.Color.Transparent
        Me.BtnPrint.Location = New System.Drawing.Point(548, 431)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(212, 35)
        Me.BtnPrint.TabIndex = 5
        Me.BtnPrint.Text = "Print Barcode KP&T (Alt + T)"
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'BtnClear
        '
        Me.BtnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClear.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClear.ForeColor = System.Drawing.Color.Transparent
        Me.BtnClear.Location = New System.Drawing.Point(14, 431)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(112, 35)
        Me.BtnClear.TabIndex = 6
        Me.BtnClear.Text = "&Clear (Alt + C)"
        Me.BtnClear.UseVisualStyleBackColor = True
        '
        'LblStore
        '
        Me.LblStore.AutoSize = True
        Me.LblStore.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStore.Location = New System.Drawing.Point(298, 213)
        Me.LblStore.Name = "LblStore"
        Me.LblStore.Size = New System.Drawing.Size(34, 13)
        Me.LblStore.TabIndex = 49
        Me.LblStore.Text = "s003"
        Me.LblStore.Visible = False
        '
        'LblFont
        '
        Me.LblFont.AutoSize = True
        Me.LblFont.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFont.Location = New System.Drawing.Point(422, 213)
        Me.LblFont.Name = "LblFont"
        Me.LblFont.Size = New System.Drawing.Size(42, 13)
        Me.LblFont.TabIndex = 48
        Me.LblFont.Text = "Review"
        Me.LblFont.Visible = False
        '
        'PrintKPT
        '
        '
        'dlgPrintPreview2
        '
        Me.dlgPrintPreview2.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.dlgPrintPreview2.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.dlgPrintPreview2.ClientSize = New System.Drawing.Size(400, 300)
        Me.dlgPrintPreview2.Enabled = True
        Me.dlgPrintPreview2.Icon = CType(resources.GetObject("dlgPrintPreview2.Icon"), System.Drawing.Icon)
        Me.dlgPrintPreview2.Name = "dlgPrintPreview"
        Me.dlgPrintPreview2.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(769, 24)
        Me.MenuStrip1.TabIndex = 60
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FocusPLUToolStripMenuItem, Me.FocusGridToolStripMenuItem, Me.FocusFindToolStripMenuItem, Me.FocusPriceToolStripMenuItem, Me.FocusQtyToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.FileToolStripMenuItem.Text = "Focus"
        '
        'FocusPLUToolStripMenuItem
        '
        Me.FocusPLUToolStripMenuItem.Name = "FocusPLUToolStripMenuItem"
        Me.FocusPLUToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.FocusPLUToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.FocusPLUToolStripMenuItem.Text = "focus PLU"
        '
        'FocusGridToolStripMenuItem
        '
        Me.FocusGridToolStripMenuItem.Name = "FocusGridToolStripMenuItem"
        Me.FocusGridToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.FocusGridToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.FocusGridToolStripMenuItem.Text = "focus grid"
        '
        'FocusFindToolStripMenuItem
        '
        Me.FocusFindToolStripMenuItem.Name = "FocusFindToolStripMenuItem"
        Me.FocusFindToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.FocusFindToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.FocusFindToolStripMenuItem.Text = "focus find"
        '
        'FocusPriceToolStripMenuItem
        '
        Me.FocusPriceToolStripMenuItem.Name = "FocusPriceToolStripMenuItem"
        Me.FocusPriceToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.FocusPriceToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.FocusPriceToolStripMenuItem.Text = "focus price"
        '
        'FocusQtyToolStripMenuItem
        '
        Me.FocusQtyToolStripMenuItem.Name = "FocusQtyToolStripMenuItem"
        Me.FocusQtyToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.FocusQtyToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.FocusQtyToolStripMenuItem.Text = "focus qty"
        '
        'dgKPT
        '
        Me.dgKPT.AllowUserToAddRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgKPT.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgKPT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgKPT.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgKPT.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgKPT.Location = New System.Drawing.Point(104, 343)
        Me.dgKPT.Name = "dgKPT"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgKPT.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgKPT.Size = New System.Drawing.Size(386, 284)
        Me.dgKPT.TabIndex = 61
        Me.dgKPT.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Col 1"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Col 2"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Transparent
        Me.Button1.Location = New System.Drawing.Point(330, 431)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(212, 35)
        Me.Button1.TabIndex = 62
        Me.Button1.Text = "Print Barcode KP&L (Alt + L)"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'dgKPL
        '
        Me.dgKPL.AllowUserToAddRows = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgKPL.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgKPL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgKPL.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgKPL.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgKPL.Location = New System.Drawing.Point(132, 307)
        Me.dgKPL.Name = "dgKPL"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgKPL.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgKPL.Size = New System.Drawing.Size(386, 284)
        Me.dgKPL.TabIndex = 63
        Me.dgKPL.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Col 1"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Col 2"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Col 3"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'PrintKPL
        '
        '
        'SPGBarcodeForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(769, 478)
        Me.Controls.Add(Me.dgKPL)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dgKPT)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.LblStore)
        Me.Controls.Add(Me.LblFont)
        Me.Controls.Add(Me.BtnClear)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgSPG)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dg)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtPLU)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "SPGBarcodeForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Print SPG Barcode"
        CType(Me.dg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgSPG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgKPT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgKPL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dg As System.Windows.Forms.DataGridView
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPLU As System.Windows.Forms.TextBox
    Friend WithEvents dgSPG As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents BtnClear As System.Windows.Forms.Button
    Friend WithEvents LblStore As System.Windows.Forms.Label
    Friend WithEvents LblFont As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrintKPT As System.Drawing.Printing.PrintDocument
    Friend WithEvents dlgPrintPreview2 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FocusPLUToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FocusGridToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FocusFindToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FocusPriceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FocusQtyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgKPT As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents colChoose As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgKPL As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrintKPL As System.Drawing.Printing.PrintDocument
End Class
