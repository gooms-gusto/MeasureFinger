Imports C1.Win.C1Input

Public Class FilterEntry
    Private _text As String
    Private _checked As Boolean
    Private WithEvents cmb As ComboBox
    Private WithEvents tb As TextBox
    Private WithEvents rtb As RichTextBox
    Public Event cb_checkedchanged()

    Public Property TextLabel() As String
        Get
            Return _text
        End Get
        Set(ByVal value As String)
            _text = value
            Label.Text = value
        End Set
    End Property

    Public Property Checked() As Boolean
        Get
            Return _checked
        End Get
        Set(ByVal value As Boolean)
            _checked = value
            cb.Checked = value
            ControlFactory()
        End Set
    End Property

    Private Sub cb_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cb.Click
        ControlFactory()
        RaiseEvent cb_checkedchanged()
    End Sub

    Private Sub ControlFactory()
        _checked = cb.Checked
        Dim tabIndex As Integer = 0

        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is TextBox Then
                tb = ctrl
                tb.ReadOnly = Not cb.Checked
                If tabIndex = 0 Then tabIndex = 1
                If tabIndex = 1 Then tb.Focus() : tabIndex = 1
            ElseIf TypeOf ctrl Is ComboBox Then
                cmb = ctrl : cmb.DropDownStyle = ComboBoxStyle.DropDownList
                cmb.Enabled = cb.Checked
                If tabIndex = 0 Then tabIndex = 1
                If tabIndex = 1 Then cmb.Focus() : tabIndex = 1
            ElseIf TypeOf ctrl Is RichTextBox Then
                rtb = ctrl
                rtb.ReadOnly = Not cb.Checked
                If cb.Checked Then rtb.BackColor = SystemColors.Window Else rtb.BackColor = SystemColors.Control
                If tabIndex = 0 Then tabIndex = 1
                If tabIndex = 1 Then rtb.Focus() : tabIndex = 1
            End If
        Next
    End Sub

    Private Sub FilterEntry_ControlAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles Me.ControlAdded
        ControlFactory()
    End Sub

End Class
