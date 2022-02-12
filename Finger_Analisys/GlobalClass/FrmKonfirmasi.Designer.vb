<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmKonfirmasi
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
        Me.cmdCobaLagi = New System.Windows.Forms.Button
        Me.cmdSimpanLog = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCobaLagi
        '
        Me.cmdCobaLagi.Location = New System.Drawing.Point(115, 51)
        Me.cmdCobaLagi.Name = "cmdCobaLagi"
        Me.cmdCobaLagi.Size = New System.Drawing.Size(105, 30)
        Me.cmdCobaLagi.TabIndex = 0
        Me.cmdCobaLagi.Text = "Coba Lagi"
        Me.cmdCobaLagi.UseVisualStyleBackColor = True
        '
        'cmdSimpanLog
        '
        Me.cmdSimpanLog.Location = New System.Drawing.Point(222, 51)
        Me.cmdSimpanLog.Name = "cmdSimpanLog"
        Me.cmdSimpanLog.Size = New System.Drawing.Size(105, 30)
        Me.cmdSimpanLog.TabIndex = 2
        Me.cmdSimpanLog.Text = "Simpan ke Log"
        Me.cmdSimpanLog.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(65, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(209, 26)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Gagal Koneksi ke Database : 10.25.3.232." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Transaksi gagal terupdate ke SIMTUL." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.GlobalClassV2.My.Resources.Resources.alert
        Me.PictureBox1.Location = New System.Drawing.Point(7, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(52, 45)
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'FrmKonfirmasi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(431, 91)
        Me.ControlBox = False
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdSimpanLog)
        Me.Controls.Add(Me.cmdCobaLagi)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmKonfirmasi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Konfirmasi"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCobaLagi As System.Windows.Forms.Button
    Friend WithEvents cmdSimpanLog As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
