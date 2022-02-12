Imports System
Imports System.Data
Imports System.Drawing
Imports System.Collections
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Public Class Header

    Private _HeaderText As String
    Private _docInfo As DocInfo

    Public Property HDocInfo() As DocInfo
        Get
            If _docInfo Is Nothing Then Return New DocInfo
            Return _docInfo
        End Get
        Set(ByVal value As DocInfo)
            _docInfo = value
        End Set
    End Property


    ''' <summary>
    ''' Get/Set header text
    ''' </summary>
    Public Property HeaderText() As String
        Get
            Return _HeaderText
        End Get
        Set(ByVal value As String)
            _HeaderText = value
            DrawGraphics()
        End Set
    End Property

    Private _HeaderDetailText As String

    ''' <summary>
    ''' Get/Set header detail text
    ''' </summary>
    Public Property HeaderDetailText() As String
        Get
            Return _HeaderDetailText
        End Get
        Set(ByVal value As String)
            _HeaderDetailText = value
            DrawGraphics()
        End Set
    End Property

    Private _HeaderLoc As Point = New Point(90, 4)

    ''' <summary>
    ''' Get/Set header location
    ''' </summary>
    Public Property HeaderLoc() As Point
        Get
            Return _HeaderLoc
        End Get
        Set(ByVal value As Point)
            _HeaderLoc = value
            DrawGraphics()
        End Set
    End Property

    Private _HeaderDetailLoc As Point = New Point(105, 28)

    ''' <summary>
    ''' Get/Set header detail location
    ''' </summary>
    Public Property HeaderDetailLoc() As Point
        Get
            Return _HeaderDetailLoc
        End Get
        Set(ByVal value As Point)
            _HeaderDetailLoc = value
            DrawGraphics()
        End Set
    End Property

    Private Sub DrawGraphics()
        PictureBox.Image = My.Resources.Header
        Dim GHeader As Graphics = Graphics.FromImage(PictureBox.Image)
        Dim F As Font = New Font("Verdana", 10, FontStyle.Bold)

        GHeader.DrawString(HeaderText, F, Brushes.WhiteSmoke, HeaderLoc)

        Dim GHeaderDetail As Graphics = Graphics.FromImage(PictureBox.Image)
        F = New Font("Verdana", 8, FontStyle.Regular)
        GHeader.DrawString(HeaderDetailText, F, Brushes.Gold, HeaderDetailloc)
    End Sub

    Private Sub Header_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.Size = New Size(Me.Width, 50)
    End Sub

    Private Sub Info_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Info.Click
        HDocInfo.OpenHelpToTopic()
    End Sub
End Class

Public Class DocInfo
    Private _locationFile As String = ""
    Private _fileName As String = ""
    Private _defautLocationFile As String = Application.ExecutablePath & "\docs\"

    ''' <summary>
    ''' File location. Defaultnya ada di Application.ExecutablePath & "\docs\" + namaCHManda.chm
    ''' </summary>
    Public Property LocationFile() As String
        Get
            If _locationFile = "" Then _locationFile = _defautLocationFile
            Return _locationFile
        End Get
        Set(ByVal value As String)
            _locationFile = value
        End Set
    End Property

    ''' <summary>
    ''' Nama File HTML. Ekstensi .html tidak perlu disebutkan.
    ''' </summary>
    Public Property HTMLFileName() As String
        Get
            Return _fileName
        End Get
        Set(ByVal value As String)
            _fileName = value
        End Set
    End Property

    Private Declare Function HTMLHelp_BaseCall _
  Lib "hhctrl.ocx" Alias "HtmlHelpA" _
  (ByVal hWnd As IntPtr, _
  ByVal lpHelpFile As String, _
  ByVal wCommand As Int32, _
  ByVal dwData As Int32) As Int32

    Public Sub OpenHelpToTopic()
        Dim RetVal As Long = HTMLHelp_BaseCall(0, LocationFile & "::" & HTMLFileName & ".html", &H0, 0)
    End Sub

End Class