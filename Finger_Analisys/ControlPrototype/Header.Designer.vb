<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Header
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Header))
        Me.NotifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.Info = New System.Windows.Forms.Label()
        Me.PictureBox = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NotifyIcon
        '
        Me.NotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NotifyIcon.BalloonTipText = "My Info"
        Me.NotifyIcon.BalloonTipTitle = "My Title"
        Me.NotifyIcon.Text = "NotifyIcon"
        Me.NotifyIcon.Visible = True
        '
        'Info
        '
        Me.Info.AutoSize = True
        Me.Info.BackColor = System.Drawing.Color.Transparent
        Me.Info.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Info.Dock = System.Windows.Forms.DockStyle.Right
        Me.Info.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Info.ForeColor = System.Drawing.Color.White
        Me.Info.Location = New System.Drawing.Point(791, 0)
        Me.Info.Name = "Info"
        Me.Info.Size = New System.Drawing.Size(10, 12)
        Me.Info.TabIndex = 1
        Me.Info.Text = "?"
        '
        'PictureBox
        '
        Me.PictureBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.PictureBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox.Image = CType(resources.GetObject("PictureBox.Image"), System.Drawing.Image)
        Me.PictureBox.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox.Name = "PictureBox"
        Me.PictureBox.Size = New System.Drawing.Size(801, 51)
        Me.PictureBox.TabIndex = 0
        Me.PictureBox.TabStop = False
        '
        'Header
        '
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(164, Byte), Integer))
        Me.Controls.Add(Me.Info)
        Me.Controls.Add(Me.PictureBox)
        Me.Name = "Header"
        Me.Size = New System.Drawing.Size(801, 51)
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public Sub New()
        ' Set the value of the double-buffering style bits to true.
        Me.SetStyle(Windows.Forms.ControlStyles.OptimizedDoubleBuffer _
          Or Windows.Forms.ControlStyles.UserPaint _
          Or Windows.Forms.ControlStyles.AllPaintingInWmPaint, _
          True)
        Me.UpdateStyles()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        DrawGraphics()
        Me.Dock = DockStyle.Top
    End Sub


    Friend WithEvents PictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents NotifyIcon As System.Windows.Forms.NotifyIcon
    Public WithEvents Info As System.Windows.Forms.Label
End Class