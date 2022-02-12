Imports System.Windows.Forms
Imports Renderers


Public Class ToolStripV
    Inherits ToolStrip

    Private _colorNorthBackground As Color
    Private _colorSouthBackground As Color
    Private _colorGlow As Color

    Private _colorCheckedButtonFillHot As Color
    Private _colorCheckedButtonFill As Color
    Private _colorCheckedGlow As Color

    Private _ct As Renderers.WindowsVistaColorTable = New Renderers.WindowsVistaColorTable
    Private _cr As Renderers.WindowsVistaRenderer = New Renderers.WindowsVistaRenderer

    Public Property ColorNorthBackground() As Color
        Get
            Return _colorNorthBackground
        End Get
        Set(ByVal value As Color)
            _colorNorthBackground = value
            _ct.BackgroundNorth = value
            _cr.ColorTable = _ct
            ColorCheckedButtonFill = value
            ColorCheckedButtonFillHot = value
        End Set
    End Property

    Public Property ColorSouthBackground() As Color
        Get
            Return _colorSouthBackground
        End Get
        Set(ByVal value As Color)
            _colorSouthBackground = value
            _ct.BackgroundSouth = value
            _cr.ColorTable = _ct
        End Set
    End Property

    Public Property ColorGlow() As Color
        Get
            Return _colorGlow
        End Get
        Set(ByVal value As Color)
            _colorGlow = value
            _ct.Glow = value
            _cr.ColorTable = _ct
            ColorCheckedGlow = value
        End Set
    End Property

    Private Property ColorCheckedButtonFillHot() As Color
        Get
            Return _colorCheckedButtonFillHot
        End Get
        Set(ByVal value As Color)
            _colorCheckedButtonFillHot = value
            _ct.CheckedButtonFillHot = value
            _cr.ColorTable = _ct
        End Set
    End Property

    Private Property ColorCheckedButtonFill() As Color
        Get
            Return _colorCheckedButtonFill
        End Get
        Set(ByVal value As Color)
            _colorCheckedButtonFill = value
            _ct.CheckedButtonFill = value
            _cr.ColorTable = _ct
        End Set
    End Property

    Private Property ColorCheckedGlow() As Color
        Get
            Return _colorCheckedGlow
        End Get
        Set(ByVal value As Color)
            _colorCheckedGlow = value
            _ct.CheckedGlow = value
            _cr.ColorTable = _ct
        End Set
    End Property

    Private Sub ToolStripV_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter
        Me.Focus()
    End Sub
End Class
