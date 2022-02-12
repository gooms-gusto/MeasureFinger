<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FilterEntry
    Inherits System.Windows.Forms.Panel

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
        Me.Label = New System.Windows.Forms.Label
        Me.cb = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'Label
        '
        Me.Label.AutoSize = True
        Me.Label.Location = New System.Drawing.Point(21, 5)
        Me.Label.Name = "Label"
        Me.Label.Size = New System.Drawing.Size(33, 13)
        Me.Label.TabIndex = 0
        Me.Label.Text = "Label"
        '
        'cb
        '
        Me.cb.AutoSize = True
        Me.cb.Checked = True
        Me.cb.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cb.Location = New System.Drawing.Point(3, 5)
        Me.cb.Name = "cb"
        Me.cb.Size = New System.Drawing.Size(15, 14)
        Me.cb.TabIndex = 1
        Me.cb.UseVisualStyleBackColor = True
        '
        'FilterEntry
        '
        Me.Controls.Add(Me.cb)
        Me.Controls.Add(Me.Label)
        Me.Size = New System.Drawing.Size(241, 25)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label As System.Windows.Forms.Label
    Friend WithEvents cb As System.Windows.Forms.CheckBox

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Checked = True
    End Sub
End Class
