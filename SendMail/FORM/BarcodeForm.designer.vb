<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BarcodeForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BarcodeForm))
        Me.gbharga = New System.Windows.Forms.GroupBox
        Me.BtnDiscKPL = New System.Windows.Forms.Button
        Me.BtnDiscount = New System.Windows.Forms.Button
        Me.BtnPrintPrice = New System.Windows.Forms.Button
        Me.BtnClearPrice = New System.Windows.Forms.Button
        Me.BtnInsertHarga = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.dgharga = New System.Windows.Forms.DataGridView
        Me.colPricePrice = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPriceQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtqty2 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtharga = New System.Windows.Forms.TextBox
        Me.dg1 = New System.Windows.Forms.DataGridView
        Me.col1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LblFont = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbGR = New System.Windows.Forms.RadioButton
        Me.rbPLU = New System.Windows.Forms.RadioButton
        Me.TxtGR = New System.Windows.Forms.TextBox
        Me.txtQty = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.BtnPrint = New System.Windows.Forms.Button
        Me.BtnClear = New System.Windows.Forms.Button
        Me.dg = New System.Windows.Forms.DataGridView
        Me.colChoose = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colPLU = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colFlag = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPerishable = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtPLU = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.LblStore = New System.Windows.Forms.Label
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtheight = New System.Windows.Forms.TextBox
        Me.txtWidth = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtTop = New System.Windows.Forms.TextBox
        Me.txtLeft = New System.Windows.Forms.TextBox
        Me.gb_article = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.dgArticle = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colBrand = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSBU = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colSuppCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colBurui = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDesc1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDesc2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dlgPrintPreview = New System.Windows.Forms.PrintPreviewDialog
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.dgKPL = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrintKPT = New System.Drawing.Printing.PrintDocument
        Me.dlgPrintPreview2 = New System.Windows.Forms.PrintPreviewDialog
        Me.Pd = New System.Windows.Forms.PrintDialog
        Me.dgKPT = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrintKPL = New System.Drawing.Printing.PrintDocument
        Me.LblFont2 = New System.Windows.Forms.Label
        Me.PrintHarga = New System.Drawing.Printing.PrintDocument
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FocusPLUToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FocusGRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FocusGridToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FocusFindToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FocusPriceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FocusQtyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FocusQtyPluToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PrintDiscKPT = New System.Drawing.Printing.PrintDocument
        Me.PrintDiscKPL = New System.Drawing.Printing.PrintDocument
        Me.gbharga.SuspendLayout()
        CType(Me.dgharga, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_article.SuspendLayout()
        CType(Me.dgArticle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgKPL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgKPT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbharga
        '
        Me.gbharga.Controls.Add(Me.BtnDiscKPL)
        Me.gbharga.Controls.Add(Me.BtnDiscount)
        Me.gbharga.Controls.Add(Me.BtnPrintPrice)
        Me.gbharga.Controls.Add(Me.BtnClearPrice)
        Me.gbharga.Controls.Add(Me.BtnInsertHarga)
        Me.gbharga.Controls.Add(Me.Label2)
        Me.gbharga.Controls.Add(Me.Label3)
        Me.gbharga.Controls.Add(Me.dgharga)
        Me.gbharga.Controls.Add(Me.Label7)
        Me.gbharga.Controls.Add(Me.txtqty2)
        Me.gbharga.Controls.Add(Me.Label5)
        Me.gbharga.Controls.Add(Me.txtharga)
        Me.gbharga.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbharga.ForeColor = System.Drawing.Color.White
        Me.gbharga.Location = New System.Drawing.Point(728, 19)
        Me.gbharga.Name = "gbharga"
        Me.gbharga.Size = New System.Drawing.Size(259, 439)
        Me.gbharga.TabIndex = 1
        Me.gbharga.TabStop = False
        Me.gbharga.Text = "&PLU (Alt + P)"
        '
        'BtnDiscKPL
        '
        Me.BtnDiscKPL.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnDiscKPL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDiscKPL.ForeColor = System.Drawing.Color.Transparent
        Me.BtnDiscKPL.Location = New System.Drawing.Point(10, 385)
        Me.BtnDiscKPL.Name = "BtnDiscKPL"
        Me.BtnDiscKPL.Size = New System.Drawing.Size(111, 44)
        Me.BtnDiscKPL.TabIndex = 50
        Me.BtnDiscKPL.Text = "Di&sc KPL (Alt+S)"
        Me.BtnDiscKPL.UseVisualStyleBackColor = False
        '
        'BtnDiscount
        '
        Me.BtnDiscount.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDiscount.ForeColor = System.Drawing.Color.Transparent
        Me.BtnDiscount.Location = New System.Drawing.Point(137, 385)
        Me.BtnDiscount.Name = "BtnDiscount"
        Me.BtnDiscount.Size = New System.Drawing.Size(111, 44)
        Me.BtnDiscount.TabIndex = 49
        Me.BtnDiscount.Text = "&Disc KPT (Alt+D)"
        Me.BtnDiscount.UseVisualStyleBackColor = False
        '
        'BtnPrintPrice
        '
        Me.BtnPrintPrice.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnPrintPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPrintPrice.ForeColor = System.Drawing.Color.Transparent
        Me.BtnPrintPrice.Location = New System.Drawing.Point(137, 346)
        Me.BtnPrintPrice.Name = "BtnPrintPrice"
        Me.BtnPrintPrice.Size = New System.Drawing.Size(112, 35)
        Me.BtnPrintPrice.TabIndex = 48
        Me.BtnPrintPrice.Text = "P&rint (Alt + R)"
        Me.BtnPrintPrice.UseVisualStyleBackColor = False
        '
        'BtnClearPrice
        '
        Me.BtnClearPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClearPrice.ForeColor = System.Drawing.Color.Transparent
        Me.BtnClearPrice.Location = New System.Drawing.Point(9, 346)
        Me.BtnClearPrice.Name = "BtnClearPrice"
        Me.BtnClearPrice.Size = New System.Drawing.Size(112, 35)
        Me.BtnClearPrice.TabIndex = 47
        Me.BtnClearPrice.Text = "Cl&ear (Alt + E)"
        Me.BtnClearPrice.UseVisualStyleBackColor = True
        '
        'BtnInsertHarga
        '
        Me.BtnInsertHarga.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnInsertHarga.ForeColor = System.Drawing.Color.Transparent
        Me.BtnInsertHarga.Location = New System.Drawing.Point(213, 49)
        Me.BtnInsertHarga.Name = "BtnInsertHarga"
        Me.BtnInsertHarga.Size = New System.Drawing.Size(35, 22)
        Me.BtnInsertHarga.TabIndex = 46
        Me.BtnInsertHarga.Text = "+"
        Me.BtnInsertHarga.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(92, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 13)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = ":"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(93, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(10, 13)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = ":"
        '
        'dgharga
        '
        Me.dgharga.AllowUserToAddRows = False
        Me.dgharga.AllowUserToDeleteRows = False
        Me.dgharga.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgharga.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPricePrice, Me.colPriceQty})
        Me.dgharga.Location = New System.Drawing.Point(9, 78)
        Me.dgharga.Name = "dgharga"
        Me.dgharga.ReadOnly = True
        Me.dgharga.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgharga.Size = New System.Drawing.Size(240, 262)
        Me.dgharga.TabIndex = 29
        '
        'colPricePrice
        '
        Me.colPricePrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colPricePrice.DataPropertyName = "price"
        Me.colPricePrice.HeaderText = "Price"
        Me.colPricePrice.Name = "colPricePrice"
        Me.colPricePrice.ReadOnly = True
        Me.colPricePrice.Width = 130
        '
        'colPriceQty
        '
        Me.colPriceQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colPriceQty.DataPropertyName = "qty"
        Me.colPriceQty.HeaderText = "Qty"
        Me.colPriceQty.Name = "colPriceQty"
        Me.colPriceQty.ReadOnly = True
        Me.colPriceQty.Width = 50
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "&Qty (Alt + Q)"
        '
        'txtqty2
        '
        Me.txtqty2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtqty2.Location = New System.Drawing.Point(109, 49)
        Me.txtqty2.Name = "txtqty2"
        Me.txtqty2.Size = New System.Drawing.Size(91, 22)
        Me.txtqty2.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(11, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Pr&ice (Alt + i)"
        '
        'txtharga
        '
        Me.txtharga.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtharga.Location = New System.Drawing.Point(109, 21)
        Me.txtharga.Name = "txtharga"
        Me.txtharga.Size = New System.Drawing.Size(139, 22)
        Me.txtharga.TabIndex = 11
        '
        'dg1
        '
        Me.dg1.AllowUserToAddRows = False
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col1, Me.col2, Me.col3})
        Me.dg1.Location = New System.Drawing.Point(248, 78)
        Me.dg1.Name = "dg1"
        Me.dg1.Size = New System.Drawing.Size(386, 284)
        Me.dg1.TabIndex = 43
        Me.dg1.Visible = False
        '
        'col1
        '
        Me.col1.HeaderText = "Col 1"
        Me.col1.Name = "col1"
        '
        'col2
        '
        Me.col2.HeaderText = "Col 2"
        Me.col2.Name = "col2"
        '
        'col3
        '
        Me.col3.HeaderText = "Col 3"
        Me.col3.Name = "col3"
        '
        'LblFont
        '
        Me.LblFont.AutoSize = True
        Me.LblFont.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFont.Location = New System.Drawing.Point(691, 3)
        Me.LblFont.Name = "LblFont"
        Me.LblFont.Size = New System.Drawing.Size(42, 13)
        Me.LblFont.TabIndex = 45
        Me.LblFont.Text = "Review"
        Me.LblFont.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbGR)
        Me.GroupBox1.Controls.Add(Me.rbPLU)
        Me.GroupBox1.Controls.Add(Me.dg1)
        Me.GroupBox1.Controls.Add(Me.TxtGR)
        Me.GroupBox1.Controls.Add(Me.txtQty)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.BtnPrint)
        Me.GroupBox1.Controls.Add(Me.BtnClear)
        Me.GroupBox1.Controls.Add(Me.dg)
        Me.GroupBox1.Controls.Add(Me.txtPLU)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(12, 19)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(710, 387)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Setting Label / Tag"
        '
        'rbGR
        '
        Me.rbGR.AutoSize = True
        Me.rbGR.Location = New System.Drawing.Point(11, 26)
        Me.rbGR.Name = "rbGR"
        Me.rbGR.Size = New System.Drawing.Size(14, 13)
        Me.rbGR.TabIndex = 47
        Me.rbGR.TabStop = True
        Me.rbGR.UseVisualStyleBackColor = True
        '
        'rbPLU
        '
        Me.rbPLU.AutoSize = True
        Me.rbPLU.Location = New System.Drawing.Point(301, 26)
        Me.rbPLU.Name = "rbPLU"
        Me.rbPLU.Size = New System.Drawing.Size(14, 13)
        Me.rbPLU.TabIndex = 46
        Me.rbPLU.TabStop = True
        Me.rbPLU.UseVisualStyleBackColor = True
        '
        'TxtGR
        '
        Me.TxtGR.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.TxtGR.Location = New System.Drawing.Point(128, 21)
        Me.TxtGR.Name = "TxtGR"
        Me.TxtGR.Size = New System.Drawing.Size(147, 22)
        Me.TxtGR.TabIndex = 44
        '
        'txtQty
        '
        Me.txtQty.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtQty.Location = New System.Drawing.Point(649, 21)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(53, 22)
        Me.txtQty.TabIndex = 40
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Alt + G"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Blue
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ForeColor = System.Drawing.Color.Transparent
        Me.Button3.Location = New System.Drawing.Point(291, 346)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(142, 35)
        Me.Button3.TabIndex = 38
        Me.Button3.Text = "Print KP&T (Alt + T)"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(627, 352)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 37
        Me.Button1.Text = "ID SPG"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BtnPrint
        '
        Me.BtnPrint.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPrint.ForeColor = System.Drawing.Color.Transparent
        Me.BtnPrint.Location = New System.Drawing.Point(137, 346)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(138, 35)
        Me.BtnPrint.TabIndex = 5
        Me.BtnPrint.Text = "Print KP&L (Alt + L)"
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'BtnClear
        '
        Me.BtnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClear.ForeColor = System.Drawing.Color.Transparent
        Me.BtnClear.Location = New System.Drawing.Point(9, 346)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(112, 35)
        Me.BtnClear.TabIndex = 4
        Me.BtnClear.Text = "&Clear (Alt + C)"
        Me.BtnClear.UseVisualStyleBackColor = True
        '
        'dg
        '
        Me.dg.AllowUserToAddRows = False
        Me.dg.AllowUserToDeleteRows = False
        Me.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colChoose, Me.colPLU, Me.colDesc, Me.colPrice, Me.colQty, Me.colDate, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column1, Me.colFlag, Me.colPerishable})
        Me.dg.Location = New System.Drawing.Point(11, 49)
        Me.dg.Name = "dg"
        Me.dg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dg.Size = New System.Drawing.Size(693, 291)
        Me.dg.TabIndex = 3
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
        'colPLU
        '
        Me.colPLU.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colPLU.DataPropertyName = "plu"
        Me.colPLU.HeaderText = "PLU"
        Me.colPLU.Name = "colPLU"
        Me.colPLU.ReadOnly = True
        Me.colPLU.Width = 120
        '
        'colDesc
        '
        Me.colDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colDesc.DataPropertyName = "description"
        Me.colDesc.HeaderText = "Description"
        Me.colDesc.Name = "colDesc"
        Me.colDesc.ReadOnly = True
        Me.colDesc.Width = 200
        '
        'colPrice
        '
        Me.colPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colPrice.DataPropertyName = "price"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.NullValue = Nothing
        Me.colPrice.DefaultCellStyle = DataGridViewCellStyle1
        Me.colPrice.HeaderText = "Price"
        Me.colPrice.Name = "colPrice"
        '
        'colQty
        '
        Me.colQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colQty.DataPropertyName = "qty"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colQty.DefaultCellStyle = DataGridViewCellStyle2
        Me.colQty.HeaderText = "Qty"
        Me.colQty.Name = "colQty"
        Me.colQty.Width = 50
        '
        'colDate
        '
        Me.colDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colDate.DataPropertyName = "date"
        Me.colDate.HeaderText = "Effective Date"
        Me.colDate.Name = "colDate"
        Me.colDate.Width = 120
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "sbu"
        Me.Column3.HeaderText = "sbu"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "supplier_code"
        Me.Column4.HeaderText = "supplier code"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "burui"
        Me.Column5.HeaderText = "burui"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.DataPropertyName = "desc1"
        Me.Column6.HeaderText = "desc1"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.DataPropertyName = "desc2"
        Me.Column7.HeaderText = "desc2"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column1.DataPropertyName = "isi"
        Me.Column1.HeaderText = "Isi"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'colFlag
        '
        Me.colFlag.DataPropertyName = "flag"
        Me.colFlag.HeaderText = "Flag"
        Me.colFlag.Name = "colFlag"
        Me.colFlag.ReadOnly = True
        '
        'colPerishable
        '
        Me.colPerishable.DataPropertyName = "perishable"
        Me.colPerishable.HeaderText = "Perishable"
        Me.colPerishable.Name = "colPerishable"
        Me.colPerishable.ReadOnly = True
        '
        'txtPLU
        '
        Me.txtPLU.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtPLU.Location = New System.Drawing.Point(402, 21)
        Me.txtPLU.Name = "txtPLU"
        Me.txtPLU.Size = New System.Drawing.Size(147, 22)
        Me.txtPLU.TabIndex = 1
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(564, 25)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(87, 13)
        Me.Label14.TabIndex = 41
        Me.Label14.Text = "Qt&y (Alt + Y) : "
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(315, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "&PLU (Alt + P) : "
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(25, 25)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(103, 13)
        Me.Label16.TabIndex = 43
        Me.Label16.Text = "&No. GR (Alt + N) : "
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton1.Location = New System.Drawing.Point(458, 3)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(53, 18)
        Me.RadioButton1.TabIndex = 2
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "La&bel"
        Me.RadioButton1.UseVisualStyleBackColor = True
        Me.RadioButton1.Visible = False
        '
        'LblStore
        '
        Me.LblStore.AutoSize = True
        Me.LblStore.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStore.Location = New System.Drawing.Point(567, 3)
        Me.LblStore.Name = "LblStore"
        Me.LblStore.Size = New System.Drawing.Size(98, 13)
        Me.LblStore.TabIndex = 47
        Me.LblStore.Text = "posserver_s001"
        Me.LblStore.Visible = False
        '
        'Button5
        '
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.ForeColor = System.Drawing.Color.Transparent
        Me.Button5.Location = New System.Drawing.Point(875, 555)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(112, 35)
        Me.Button5.TabIndex = 56
        Me.Button5.Text = "Prin&t"
        Me.Button5.UseVisualStyleBackColor = True
        Me.Button5.Visible = False
        '
        'Button4
        '
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.ForeColor = System.Drawing.Color.Transparent
        Me.Button4.Location = New System.Drawing.Point(757, 555)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(112, 35)
        Me.Button4.TabIndex = 55
        Me.Button4.Text = "Prin&t"
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(594, 714)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 13)
        Me.Label11.TabIndex = 54
        Me.Label11.Text = "Height"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(594, 686)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 13)
        Me.Label12.TabIndex = 53
        Me.Label12.Text = "Width"
        '
        'txtheight
        '
        Me.txtheight.Location = New System.Drawing.Point(642, 710)
        Me.txtheight.Name = "txtheight"
        Me.txtheight.Size = New System.Drawing.Size(100, 20)
        Me.txtheight.TabIndex = 52
        Me.txtheight.Text = "105"
        '
        'txtWidth
        '
        Me.txtWidth.Location = New System.Drawing.Point(644, 682)
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.Size = New System.Drawing.Size(100, 20)
        Me.txtWidth.TabIndex = 51
        Me.txtWidth.Text = "340"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(596, 658)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(28, 13)
        Me.Label10.TabIndex = 50
        Me.Label10.Text = "Top"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(596, 630)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 13)
        Me.Label8.TabIndex = 49
        Me.Label8.Text = "Left"
        Me.Label8.Visible = False
        '
        'txtTop
        '
        Me.txtTop.Location = New System.Drawing.Point(644, 654)
        Me.txtTop.Name = "txtTop"
        Me.txtTop.Size = New System.Drawing.Size(100, 20)
        Me.txtTop.TabIndex = 48
        Me.txtTop.Text = "3"
        '
        'txtLeft
        '
        Me.txtLeft.Location = New System.Drawing.Point(646, 626)
        Me.txtLeft.Name = "txtLeft"
        Me.txtLeft.Size = New System.Drawing.Size(100, 20)
        Me.txtLeft.TabIndex = 47
        Me.txtLeft.Text = "10"
        Me.txtLeft.Visible = False
        '
        'gb_article
        '
        Me.gb_article.Controls.Add(Me.Label4)
        Me.gb_article.Controls.Add(Me.dgArticle)
        Me.gb_article.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_article.ForeColor = System.Drawing.Color.White
        Me.gb_article.Location = New System.Drawing.Point(12, 412)
        Me.gb_article.Name = "gb_article"
        Me.gb_article.Size = New System.Drawing.Size(710, 208)
        Me.gb_article.TabIndex = 6
        Me.gb_article.TabStop = False
        Me.gb_article.Text = "Find Article (Alt + F)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(670, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Hide"
        '
        'dgArticle
        '
        Me.dgArticle.AllowUserToAddRows = False
        Me.dgArticle.AllowUserToDeleteRows = False
        Me.dgArticle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgArticle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.colBrand, Me.colSBU, Me.colSuppCode, Me.colBurui, Me.colDesc1, Me.colDesc2, Me.Column2, Me.Column8, Me.Column9})
        Me.dgArticle.Location = New System.Drawing.Point(9, 30)
        Me.dgArticle.Name = "dgArticle"
        Me.dgArticle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgArticle.Size = New System.Drawing.Size(693, 172)
        Me.dgArticle.TabIndex = 0
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "plu"
        Me.DataGridViewTextBoxColumn1.HeaderText = "PLU"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 130
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "description"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 250
        '
        'colBrand
        '
        Me.colBrand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colBrand.DataPropertyName = "brand"
        Me.colBrand.HeaderText = "Brand"
        Me.colBrand.Name = "colBrand"
        Me.colBrand.ReadOnly = True
        '
        'colSBU
        '
        Me.colSBU.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colSBU.DataPropertyName = "sbu"
        Me.colSBU.HeaderText = "SBU"
        Me.colSBU.Name = "colSBU"
        Me.colSBU.ReadOnly = True
        Me.colSBU.Width = 60
        '
        'colSuppCode
        '
        Me.colSuppCode.DataPropertyName = "supplier_code"
        Me.colSuppCode.HeaderText = "Supplier Code"
        Me.colSuppCode.Name = "colSuppCode"
        Me.colSuppCode.ReadOnly = True
        Me.colSuppCode.Visible = False
        '
        'colBurui
        '
        Me.colBurui.DataPropertyName = "burui"
        Me.colBurui.HeaderText = "Burui"
        Me.colBurui.Name = "colBurui"
        Me.colBurui.ReadOnly = True
        Me.colBurui.Visible = False
        '
        'colDesc1
        '
        Me.colDesc1.DataPropertyName = "desc1"
        Me.colDesc1.HeaderText = "Desc1"
        Me.colDesc1.Name = "colDesc1"
        Me.colDesc1.ReadOnly = True
        Me.colDesc1.Visible = False
        '
        'colDesc2
        '
        Me.colDesc2.DataPropertyName = "desc2"
        Me.colDesc2.HeaderText = "Desc2"
        Me.colDesc2.Name = "colDesc2"
        Me.colDesc2.ReadOnly = True
        Me.colDesc2.Visible = False
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column2.DataPropertyName = "flag"
        Me.Column2.HeaderText = "Flag"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Visible = False
        '
        'Column8
        '
        Me.Column8.DataPropertyName = "price"
        Me.Column8.HeaderText = "Price"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Visible = False
        '
        'Column9
        '
        Me.Column9.DataPropertyName = "perishable"
        Me.Column9.HeaderText = "Perishable"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Visible = False
        '
        'dlgPrintPreview
        '
        Me.dlgPrintPreview.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.dlgPrintPreview.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.dlgPrintPreview.ClientSize = New System.Drawing.Size(400, 300)
        Me.dlgPrintPreview.Enabled = True
        Me.dlgPrintPreview.Icon = CType(resources.GetObject("dlgPrintPreview.Icon"), System.Drawing.Icon)
        Me.dlgPrintPreview.Name = "dlgPrintPreview"
        Me.dlgPrintPreview.Visible = False
        '
        'dgKPL
        '
        Me.dgKPL.AllowUserToAddRows = False
        Me.dgKPL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgKPL.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5})
        Me.dgKPL.Location = New System.Drawing.Point(728, 555)
        Me.dgKPL.Name = "dgKPL"
        Me.dgKPL.Size = New System.Drawing.Size(410, 325)
        Me.dgKPL.TabIndex = 46
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
        'Pd
        '
        Me.Pd.UseEXDialog = True
        '
        'dgKPT
        '
        Me.dgKPT.AllowUserToAddRows = False
        Me.dgKPT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgKPT.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7})
        Me.dgKPT.Location = New System.Drawing.Point(742, 504)
        Me.dgKPT.Name = "dgKPT"
        Me.dgKPT.Size = New System.Drawing.Size(386, 284)
        Me.dgKPT.TabIndex = 57
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
        'PrintKPL
        '
        '
        'LblFont2
        '
        Me.LblFont2.AutoSize = True
        Me.LblFont2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFont2.Location = New System.Drawing.Point(742, 3)
        Me.LblFont2.Name = "LblFont2"
        Me.LblFont2.Size = New System.Drawing.Size(48, 13)
        Me.LblFont2.TabIndex = 58
        Me.LblFont2.Text = "Review"
        Me.LblFont2.Visible = False
        '
        'PrintHarga
        '
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(999, 24)
        Me.MenuStrip1.TabIndex = 59
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FocusPLUToolStripMenuItem, Me.FocusGRToolStripMenuItem, Me.FocusGridToolStripMenuItem, Me.FocusFindToolStripMenuItem, Me.FocusPriceToolStripMenuItem, Me.FocusQtyToolStripMenuItem, Me.FocusQtyPluToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.FileToolStripMenuItem.Text = "Focus"
        '
        'FocusPLUToolStripMenuItem
        '
        Me.FocusPLUToolStripMenuItem.Name = "FocusPLUToolStripMenuItem"
        Me.FocusPLUToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.FocusPLUToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.FocusPLUToolStripMenuItem.Text = "focus PLU"
        '
        'FocusGRToolStripMenuItem
        '
        Me.FocusGRToolStripMenuItem.Name = "FocusGRToolStripMenuItem"
        Me.FocusGRToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.FocusGRToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.FocusGRToolStripMenuItem.Text = "focus GR"
        '
        'FocusGridToolStripMenuItem
        '
        Me.FocusGridToolStripMenuItem.Name = "FocusGridToolStripMenuItem"
        Me.FocusGridToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.FocusGridToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.FocusGridToolStripMenuItem.Text = "focus grid"
        '
        'FocusFindToolStripMenuItem
        '
        Me.FocusFindToolStripMenuItem.Name = "FocusFindToolStripMenuItem"
        Me.FocusFindToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.FocusFindToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.FocusFindToolStripMenuItem.Text = "focus find"
        '
        'FocusPriceToolStripMenuItem
        '
        Me.FocusPriceToolStripMenuItem.Name = "FocusPriceToolStripMenuItem"
        Me.FocusPriceToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.FocusPriceToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.FocusPriceToolStripMenuItem.Text = "focus price"
        '
        'FocusQtyToolStripMenuItem
        '
        Me.FocusQtyToolStripMenuItem.Name = "FocusQtyToolStripMenuItem"
        Me.FocusQtyToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.FocusQtyToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.FocusQtyToolStripMenuItem.Text = "focus qty harga"
        '
        'FocusQtyPluToolStripMenuItem
        '
        Me.FocusQtyPluToolStripMenuItem.Name = "FocusQtyPluToolStripMenuItem"
        Me.FocusQtyPluToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.FocusQtyPluToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.FocusQtyPluToolStripMenuItem.Text = "focus qty plu"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(757, 580)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(285, 237)
        Me.PictureBox1.TabIndex = 36
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'PrintDiscKPT
        '
        '
        'PrintDiscKPL
        '
        '
        'BarcodeForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(999, 637)
        Me.Controls.Add(Me.dgKPT)
        Me.Controls.Add(Me.LblFont2)
        Me.Controls.Add(Me.LblStore)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.gb_article)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.LblFont)
        Me.Controls.Add(Me.txtheight)
        Me.Controls.Add(Me.gbharga)
        Me.Controls.Add(Me.txtWidth)
        Me.Controls.Add(Me.txtTop)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtLeft)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dgKPL)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "BarcodeForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "STAR Barcode [Label, Tag, Price]"
        Me.gbharga.ResumeLayout(False)
        Me.gbharga.PerformLayout()
        CType(Me.dgharga, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_article.ResumeLayout(False)
        Me.gb_article.PerformLayout()
        CType(Me.dgArticle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgKPL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgKPT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbharga As System.Windows.Forms.GroupBox
    Friend WithEvents dgharga As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtqty2 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtharga As System.Windows.Forms.TextBox
    Friend WithEvents dg1 As System.Windows.Forms.DataGridView
    Friend WithEvents col1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LblFont As System.Windows.Forms.Label
    Friend WithEvents BtnInsertHarga As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnClearPrice As System.Windows.Forms.Button
    Friend WithEvents BtnPrintPrice As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents BtnClear As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPLU As System.Windows.Forms.TextBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents gb_article As System.Windows.Forms.GroupBox
    Friend WithEvents dgArticle As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents dlgPrintPreview As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents dgKPL As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents PrintKPT As System.Drawing.Printing.PrintDocument
    Friend WithEvents dlgPrintPreview2 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtheight As System.Windows.Forms.TextBox
    Friend WithEvents txtWidth As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTop As System.Windows.Forms.TextBox
    Friend WithEvents txtLeft As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Pd As System.Windows.Forms.PrintDialog
    Friend WithEvents LblStore As System.Windows.Forms.Label
    Friend WithEvents dgKPT As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrintKPL As System.Drawing.Printing.PrintDocument
    Friend WithEvents LblFont2 As System.Windows.Forms.Label
    Friend WithEvents PrintHarga As System.Drawing.Printing.PrintDocument
    Friend WithEvents dg As System.Windows.Forms.DataGridView
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FocusPLUToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FocusGridToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FocusFindToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FocusPriceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FocusQtyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents FocusQtyPluToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colChoose As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colPLU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFlag As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPerishable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBrand As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSBU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSuppCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBurui As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDesc1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDesc2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtnDiscount As System.Windows.Forms.Button
    Friend WithEvents PrintDiscKPT As System.Drawing.Printing.PrintDocument
    Friend WithEvents colPricePrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPriceQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtnDiscKPL As System.Windows.Forms.Button
    Friend WithEvents PrintDiscKPL As System.Drawing.Printing.PrintDocument
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TxtGR As System.Windows.Forms.TextBox
    Friend WithEvents rbGR As System.Windows.Forms.RadioButton
    Friend WithEvents rbPLU As System.Windows.Forms.RadioButton
    Friend WithEvents FocusGRToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
