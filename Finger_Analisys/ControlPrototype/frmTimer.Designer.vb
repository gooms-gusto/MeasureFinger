<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTimer
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
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.txt = New System.Windows.Forms.Label
        Me.Grouper1 = New CodeVendor.Controls.Grouper
        Me.cmdOK = New EMap.VistaButton
        Me.Grouper1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer
        '
        '
        'txt
        '
        Me.txt.Location = New System.Drawing.Point(7, 19)
        Me.txt.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txt.Name = "txt"
        Me.txt.Size = New System.Drawing.Size(384, 52)
        Me.txt.TabIndex = 1
        '
        'Grouper1
        '
        Me.Grouper1.BackgroundColor = System.Drawing.Color.LightCyan
        Me.Grouper1.BackgroundGradientColor = System.Drawing.Color.CadetBlue
        Me.Grouper1.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.ForwardDiagonal
        Me.Grouper1.BorderColor = System.Drawing.Color.Black
        Me.Grouper1.BorderThickness = 1.0!
        Me.Grouper1.Controls.Add(Me.cmdOK)
        Me.Grouper1.Controls.Add(Me.txt)
        Me.Grouper1.CustomGroupBoxColor = System.Drawing.Color.White
        Me.Grouper1.GroupImage = Nothing
        Me.Grouper1.GroupTitle = ""
        Me.Grouper1.Location = New System.Drawing.Point(2, -8)
        Me.Grouper1.Name = "Grouper1"
        Me.Grouper1.Padding = New System.Windows.Forms.Padding(18, 19, 18, 19)
        Me.Grouper1.PaintGroupBox = False
        Me.Grouper1.RoundCorners = 10
        Me.Grouper1.ShadowColor = System.Drawing.Color.DarkGray
        Me.Grouper1.ShadowControl = False
        Me.Grouper1.ShadowThickness = 3
        Me.Grouper1.Size = New System.Drawing.Size(401, 104)
        Me.Grouper1.TabIndex = 2
        '
        'cmdOK
        '
        Me.cmdOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOK.BackColor = System.Drawing.Color.Transparent
        Me.cmdOK.BackImage = Nothing
        Me.cmdOK.BaseColor = System.Drawing.Color.Aqua
        Me.cmdOK.ButtonText = "OK"
        Me.cmdOK.CornerRadius = 0
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdOK.GlowColor = System.Drawing.Color.PaleTurquoise
        Me.cmdOK.Image = Nothing
        Me.cmdOK.Location = New System.Drawing.Point(164, 74)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(76, 25)
        Me.cmdOK.TabIndex = 2
        '
        'frmTimer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(406, 98)
        Me.Controls.Add(Me.Grouper1)
        Me.Font = New System.Drawing.Font("Minima SSi", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTimer"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Timer"
        Me.Grouper1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer As System.Windows.Forms.Timer
    Friend WithEvents txt As System.Windows.Forms.Label
    Friend WithEvents Grouper1 As CodeVendor.Controls.Grouper
    Friend WithEvents cmdOK As EMap.VistaButton
End Class
