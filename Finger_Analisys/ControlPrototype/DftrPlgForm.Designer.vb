<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DftrPlgForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DftrPlgForm))
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbIDPel = New System.Windows.Forms.ComboBox
        Me.txtIDPel = New System.Windows.Forms.TextBox
        Me.txtNama = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtAlamat = New System.Windows.Forms.TextBox
        Me.cmdKodeAlamat = New PinkieControls.ButtonXP
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.cmdOK = New System.Windows.Forms.ToolStripButton
        Me.cmdTutup = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.cmdFirst = New System.Windows.Forms.ToolStripButton
        Me.cmdPrex = New System.Windows.Forms.ToolStripButton
        Me.cmdNext = New System.Windows.Forms.ToolStripButton
        Me.cmdLast = New System.Windows.Forms.ToolStripButton
        Me.cmdCari = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'fg
        '
        Me.fg.AllowEditing = False
        Me.fg.BackColor = System.Drawing.SystemColors.Window
        Me.fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fg.ColumnInfo = resources.GetString("fg.ColumnInfo")
        Me.fg.ExtendLastCol = True
        Me.fg.ForeColor = System.Drawing.SystemColors.WindowText
        Me.fg.Location = New System.Drawing.Point(2, 28)
        Me.fg.Name = "fg"
        Me.fg.Rows.Count = 1
        Me.fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fg.Size = New System.Drawing.Size(472, 212)
        Me.fg.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fg.Styles"))
        Me.fg.TabIndex = 1061
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtNama)
        Me.GroupBox1.Controls.Add(Me.txtIDPel)
        Me.GroupBox1.Controls.Add(Me.cmbIDPel)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 238)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(246, 57)
        Me.GroupBox1.TabIndex = 1062
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 1063
        Me.Label1.Text = "ID Pel"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 1064
        Me.Label2.Text = "Nama"
        '
        'cmbIDPel
        '
        Me.cmbIDPel.FormattingEnabled = True
        Me.cmbIDPel.Location = New System.Drawing.Point(48, 11)
        Me.cmbIDPel.Name = "cmbIDPel"
        Me.cmbIDPel.Size = New System.Drawing.Size(67, 21)
        Me.cmbIDPel.TabIndex = 1063
        '
        'txtIDPel
        '
        Me.txtIDPel.Location = New System.Drawing.Point(116, 11)
        Me.txtIDPel.Name = "txtIDPel"
        Me.txtIDPel.Size = New System.Drawing.Size(124, 20)
        Me.txtIDPel.TabIndex = 1063
        '
        'txtNama
        '
        Me.txtNama.Location = New System.Drawing.Point(48, 32)
        Me.txtNama.Name = "txtNama"
        Me.txtNama.Size = New System.Drawing.Size(192, 20)
        Me.txtNama.TabIndex = 1065
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdKodeAlamat)
        Me.GroupBox2.Controls.Add(Me.txtAlamat)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 295)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(469, 43)
        Me.GroupBox2.TabIndex = 1063
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Alamat"
        '
        'txtAlamat
        '
        Me.txtAlamat.Location = New System.Drawing.Point(4, 15)
        Me.txtAlamat.Name = "txtAlamat"
        Me.txtAlamat.Size = New System.Drawing.Size(384, 20)
        Me.txtAlamat.TabIndex = 1066
        '
        'cmdKodeAlamat
        '
        Me.cmdKodeAlamat.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.cmdKodeAlamat.DefaultScheme = True
        Me.cmdKodeAlamat.DialogResult = System.Windows.Forms.DialogResult.None
        Me.cmdKodeAlamat.Hint = ""
        Me.cmdKodeAlamat.Location = New System.Drawing.Point(391, 13)
        Me.cmdKodeAlamat.Name = "cmdKodeAlamat"
        Me.cmdKodeAlamat.Scheme = PinkieControls.ButtonXP.Schemes.Silver
        Me.cmdKodeAlamat.Size = New System.Drawing.Size(72, 23)
        Me.cmdKodeAlamat.TabIndex = 1067
        Me.cmdKodeAlamat.Text = "&Kode Alamat"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdCari, Me.ToolStripSeparator2, Me.cmdFirst, Me.cmdPrex, Me.cmdNext, Me.cmdLast, Me.ToolStripSeparator1, Me.cmdOK, Me.cmdTutup})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(476, 25)
        Me.ToolStrip1.TabIndex = 1064
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'cmdOK
        '
        Me.cmdOK.Image = CType(resources.GetObject("cmdOK.Image"), System.Drawing.Image)
        Me.cmdOK.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(42, 22)
        Me.cmdOK.Text = "&OK"
        '
        'cmdTutup
        '
        Me.cmdTutup.Image = CType(resources.GetObject("cmdTutup.Image"), System.Drawing.Image)
        Me.cmdTutup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdTutup.Name = "cmdTutup"
        Me.cmdTutup.Size = New System.Drawing.Size(54, 22)
        Me.cmdTutup.Text = "&Tutup"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'cmdFirst
        '
        Me.cmdFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdFirst.Image = Global.EMap.My.Resources.Resources.awal2
        Me.cmdFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdFirst.Name = "cmdFirst"
        Me.cmdFirst.Size = New System.Drawing.Size(23, 22)
        Me.cmdFirst.Text = "ToolStripButton1"
        '
        'cmdPrex
        '
        Me.cmdPrex.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdPrex.Image = Global.EMap.My.Resources.Resources.atas1
        Me.cmdPrex.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdPrex.Name = "cmdPrex"
        Me.cmdPrex.Size = New System.Drawing.Size(23, 22)
        Me.cmdPrex.Text = "ToolStripButton2"
        '
        'cmdNext
        '
        Me.cmdNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdNext.Image = Global.EMap.My.Resources.Resources.BAWAH2
        Me.cmdNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(23, 22)
        Me.cmdNext.Text = "ToolStripButton3"
        '
        'cmdLast
        '
        Me.cmdLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdLast.Image = Global.EMap.My.Resources.Resources.akhir1
        Me.cmdLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(23, 22)
        Me.cmdLast.Text = "ToolStripButton4"
        '
        'cmdCari
        '
        Me.cmdCari.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.cmdCari.Image = CType(resources.GetObject("cmdCari.Image"), System.Drawing.Image)
        Me.cmdCari.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdCari.Name = "cmdCari"
        Me.cmdCari.Size = New System.Drawing.Size(30, 22)
        Me.cmdCari.Text = "&Cari"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'DftrPlgForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(476, 343)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.fg)
        Me.Controls.Add(Me.GroupBox1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "DftrPlgForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Daftar Pelanggan"
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNama As System.Windows.Forms.TextBox
    Friend WithEvents txtIDPel As System.Windows.Forms.TextBox
    Friend WithEvents cmbIDPel As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtAlamat As System.Windows.Forms.TextBox
    Friend WithEvents cmdKodeAlamat As PinkieControls.ButtonXP
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdCari As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdPrex As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdOK As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdTutup As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
End Class
