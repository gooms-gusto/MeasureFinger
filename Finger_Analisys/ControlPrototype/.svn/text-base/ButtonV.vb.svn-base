Imports System
Imports System.Data
Imports System.Drawing
Imports System.Collections
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing.Drawing2D


''' <summary>
''' A replacement for the Windows Button Control.
''' </summary>
<DefaultEvent("Click")> _
Public Class VistaButton
    Inherits System.Windows.Forms.UserControl

#Region "- Designer -"

    Private components As System.ComponentModel.Container = Nothing

    ''' <summary>
    ''' Initialize the component with it's
    ''' default settings.
    ''' </summary>
    Public Sub New()
        InitializeComponent()

        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.Selectable, True)
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.BackColor = Color.Transparent
        mFadeIn.Interval = 30
        mFadeOut.Interval = 30
        Me.Cursor = Cursors.Hand
    End Sub

    ''' <summary>
    ''' Release resources used by the control.
    ''' </summary>
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If components IsNot Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "- Component Designer generated code -"

    Private Sub InitializeComponent()
        '
        ' VistaButton
        '
        Me.Name = "VistaButton"
        Me.Size = New System.Drawing.Size(100, 32)
        AddHandler Me.Paint, AddressOf VistaButton_Paint
        AddHandler Me.KeyUp, AddressOf VistaButton_KeyUp
        AddHandler Me.KeyDown, AddressOf VistaButton_KeyDown
        AddHandler Me.MouseEnter, AddressOf VistaButton_MouseEnter
        AddHandler Me.MouseLeave, AddressOf VistaButton_MouseLeave
        AddHandler Me.MouseUp, AddressOf VistaButton_MouseUp
        AddHandler Me.MouseDown, AddressOf VistaButton_MouseDown
        AddHandler Me.GotFocus, AddressOf VistaButton_MouseEnter
        AddHandler Me.LostFocus, AddressOf VistaButton_MouseLeave
        AddHandler Me.mFadeIn.Tick, AddressOf mFadeIn_Tick
        AddHandler Me.mFadeOut.Tick, AddressOf mFadeOut_Tick
        AddHandler Me.Resize, AddressOf VistaButton_Resize
    End Sub

#End Region

#End Region

#Region "- Enums -"

    ''' <summary>
    ''' A private enumeration that determines
    ''' the mouse state in relation to the
    ''' current instance of the control.
    ''' </summary>
    Private Enum State
        None
        Hover
        Pressed
    End Enum

    ''' <summary>
    ''' A public enumeration that determines whether
    ''' the button background is painted when the
    ''' mouse is not inside the ClientArea.
    ''' </summary>
    Public Enum Style
        ''' <summary>
        ''' Draw the button as normal
        ''' </summary>
        [Default]
        ''' <summary>
        ''' Only draw the background on mouse over.
        ''' </summary>
        Flat
    End Enum

#End Region

#Region "- Properties -"

#Region "- Private Variables -"

    Private calledbykey As Boolean = False
    Private mButtonState As State = State.None
    Private mFadeIn As New Timer()
    Private mFadeOut As New Timer()
    Private mGlowAlpha As Integer = 0

#End Region

#Region "- Text -"

    Private mText As String
    ''' <summary>
    ''' The text that is displayed on the button.
    ''' </summary>
    <Category("Text"), Description("The text that is displayed on the button.")> _
    Public Property ButtonText() As String
        Get
            Return mText
        End Get
        Set(ByVal value As String)
            mText = value
            Me.Invalidate()
        End Set
    End Property

    Private mForeColor As Color = Color.White
    ''' <summary>
    ''' The color with which the text is drawn.
    ''' </summary>
    <Category("Text"), Browsable(True), DefaultValue(GetType(Color), "White"), Description("The color with which the text is drawn.")> _
    Public Overloads Overrides Property ForeColor() As Color
        Get
            Return mForeColor
        End Get
        Set(ByVal value As Color)
            mForeColor = value
            Me.Invalidate()
        End Set
    End Property

    Private mTextAlign As ContentAlignment = ContentAlignment.MiddleCenter
    ''' <summary>
    ''' The alignment of the button text
    ''' that is displayed on the control.
    ''' </summary>
    <Category("Text"), DefaultValue(GetType(ContentAlignment), "MiddleCenter"), Description("The alignment of the button text " + "that is displayed on the control.")> _
    Public Property TextAlign() As ContentAlignment
        Get
            Return mTextAlign
        End Get
        Set(ByVal value As ContentAlignment)
            mTextAlign = value
            Me.Invalidate()
        End Set
    End Property
#End Region

#Region "- Image -"

    Private mImage As Image
    ''' <summary>
    ''' The image displayed on the button that
    ''' is used to help the user identify
    ''' it's function if the text is ambiguous.
    ''' </summary>
    <Category("Image"), DefaultValue(False), Description("The image displayed on the button that " + "is used to help the user identify" + "it's function if the text is ambiguous.")> _
    Public Property Image() As Image
        Get
            Return mImage
        End Get
        Set(ByVal value As Image)
            mImage = value
            Me.Invalidate()
        End Set
    End Property

    Private mImageAlign As ContentAlignment = ContentAlignment.MiddleLeft
    ''' <summary>
    ''' The alignment of the image
    ''' in relation to the button.
    ''' </summary>
    <Category("Image"), DefaultValue(GetType(ContentAlignment), "MiddleLeft"), Description("The alignment of the image " + "in relation to the button.")> _
    Public Property ImageAlign() As ContentAlignment
        Get
            Return mImageAlign
        End Get
        Set(ByVal value As ContentAlignment)
            mImageAlign = value
            Me.Invalidate()
        End Set
    End Property

    Private mImageSize As New Size(24, 24)
    ''' <summary>
    ''' The size of the image to be displayed on the
    ''' button. This property defaults to 24x24.
    ''' </summary>
    <Category("Image"), DefaultValue(GetType(Size), "24, 24"), Description("The size of the image to be displayed on the" + "button. This property defaults to 24x24.")> _
    Public Property ImageSize() As Size
        Get
            Return mImageSize
        End Get
        Set(ByVal value As Size)
            mImageSize = value
            Me.Invalidate()
        End Set
    End Property

#End Region

#Region "- Appearance -"

    Private mButtonStyle As Style = Style.[Default]
    ''' <summary>
    ''' Sets whether the button background is drawn
    ''' while the mouse is outside of the client area.
    ''' </summary>
    <Category("Appearance"), DefaultValue(GetType(Style), "Default"), Description("Sets whether the button background is drawn " + "while the mouse is outside of the client area.")> _
    Public Property ButtonStyle() As Style
        Get
            Return mButtonStyle
        End Get
        Set(ByVal value As Style)
            mButtonStyle = value
            Me.Invalidate()
        End Set
    End Property

    Private mCornerRadius As Integer = 8
    ''' <summary>
    ''' The radius for the button corners. The
    ''' greater this value is, the more 'smooth'
    ''' the corners are. This property should
    ''' not be greater than half of the
    ''' controls height.
    ''' </summary>
    <Category("Appearance"), DefaultValue(8), Description("The radius for the button corners. The " + "greater this value is, the more 'smooth' " + "the corners are. This property should " + "not be greater than half of the " + "controls height.")> _
    Public Property CornerRadius() As Integer
        Get
            Return mCornerRadius
        End Get
        Set(ByVal value As Integer)
            mCornerRadius = value
            Me.Invalidate()
        End Set
    End Property

    Private mHighlightColor As Color = Color.White
    ''' <summary>
    ''' The colour of the highlight on the top of the button.
    ''' </summary>
    <Category("Appearance"), DefaultValue(GetType(Color), "White"), Description("The colour of the highlight on the top of the button.")> _
    Public Property HighlightColor() As Color
        Get
            Return mHighlightColor
        End Get
        Set(ByVal value As Color)
            mHighlightColor = value
            Me.Invalidate()
        End Set
    End Property

    Private mButtonColor As Color = Color.Black
    Private _disabledButtonColor As Color = Color.Silver
    ''' <summary>
    ''' The bottom color of the button that
    ''' will be drawn over the base color.
    ''' </summary>
    <Category("Appearance"), DefaultValue(GetType(Color), "Black"), Description("The bottom color of the button that " + "will be drawn over the base color.")> _
    Public Property ButtonColor() As Color
        Get
            Return mButtonColor
        End Get
        Set(ByVal value As Color)
            mButtonColor = value
            Me.Invalidate()
        End Set
    End Property

    Private mGlowColor As Color = Color.FromArgb(141, 189, 255)
    ''' <summary>
    ''' The colour that the button glows when
    ''' the mouse is inside the client area.
    ''' </summary>
    <Category("Appearance"), DefaultValue(GetType(Color), "141,189,255"), Description("The colour that the button glows when " + "the mouse is inside the client area.")> _
    Public Property GlowColor() As Color
        Get
            Return mGlowColor
        End Get
        Set(ByVal value As Color)
            mGlowColor = value
            Me.Invalidate()
        End Set
    End Property

    Private mBackImage As Image
    ''' <summary>
    ''' The background image for the button,
    ''' this image is drawn over the base
    ''' color of the button.
    ''' </summary>
    <Category("Appearance"), DefaultValue(False), Description("The background image for the button, " + "this image is drawn over the base " + "color of the button.")> _
    Public Property BackImage() As Image
        Get
            Return mBackImage
        End Get
        Set(ByVal value As Image)
            mBackImage = value
            Me.Invalidate()
        End Set
    End Property

    Private mBaseColor As Color = Color.Black
    ''' <summary>
    ''' The backing color that the rest of
    ''' the button is drawn. For a glassier
    ''' effect set this property to Transparent.
    ''' </summary>
    <Category("Appearance"), DefaultValue(GetType(Color), "Black"), Description("The backing color that the rest of" + "the button is drawn. For a glassier " + "effect set this property to Transparent.")> _
    Public Property BaseColor() As Color
        Get
            Return mBaseColor
        End Get
        Set(ByVal value As Color)
            mBaseColor = value
            Me.Invalidate()
        End Set
    End Property

#End Region


#End Region

#Region "- Functions -"

    Private Function RoundRect(ByVal r As RectangleF, ByVal r1 As Single, ByVal r2 As Single, ByVal r3 As Single, ByVal r4 As Single) As GraphicsPath
        Dim x As Single = r.X, y As Single = r.Y, w As Single = r.Width, h As Single = r.Height
        Dim rr As New GraphicsPath()
        rr.AddBezier(x, y + r1, x, y, x + r1, y, _
        x + r1, y)
        rr.AddLine(x + r1, y, x + w - r2, y)
        rr.AddBezier(x + w - r2, y, x + w, y, x + w, y + r2, _
        x + w, y + r2)
        rr.AddLine(x + w, y + r2, x + w, y + h - r3)
        rr.AddBezier(x + w, y + h - r3, x + w, y + h, x + w - r3, y + h, _
        x + w - r3, y + h)
        rr.AddLine(x + w - r3, y + h, x + r4, y + h)
        rr.AddBezier(x + r4, y + h, x, y + h, x, y + h - r4, _
        x, y + h - r4)
        rr.AddLine(x, y + h - r4, x, y + r1)
        Return rr
    End Function

    Private Function StringFormatAlignment(ByVal textalign As ContentAlignment) As StringFormat
        Dim sf As New StringFormat()
        Select Case textalign
            Case ContentAlignment.TopLeft, ContentAlignment.TopCenter, ContentAlignment.TopRight
                sf.LineAlignment = StringAlignment.Near
                Exit Select
            Case ContentAlignment.MiddleLeft, ContentAlignment.MiddleCenter, ContentAlignment.MiddleRight
                sf.LineAlignment = StringAlignment.Center
                Exit Select
            Case ContentAlignment.BottomLeft, ContentAlignment.BottomCenter, ContentAlignment.BottomRight
                sf.LineAlignment = StringAlignment.Far
                Exit Select
        End Select
        Select Case textalign
            Case ContentAlignment.TopLeft, ContentAlignment.MiddleLeft, ContentAlignment.BottomLeft
                sf.Alignment = StringAlignment.Near
                Exit Select
            Case ContentAlignment.TopCenter, ContentAlignment.MiddleCenter, ContentAlignment.BottomCenter
                sf.Alignment = StringAlignment.Center
                Exit Select
            Case ContentAlignment.TopRight, ContentAlignment.MiddleRight, ContentAlignment.BottomRight
                sf.Alignment = StringAlignment.Far
                Exit Select
        End Select
        Return sf
    End Function

#End Region

#Region "- Drawing -"

    ''' <summary>
    ''' Draws the outer border for the control
    ''' using the ButtonColor property.
    ''' </summary>
    ''' <param name="g">The graphics object used in the paint event.</param>
    Private Sub DrawOuterStroke(ByVal g As Graphics)
        If Me.ButtonStyle = Style.Flat AndAlso Me.mButtonState = State.None Then
            Return
        End If
        Dim r As Rectangle = Me.ClientRectangle
        r.Width -= 1
        r.Height -= 1
        Using rr As GraphicsPath = RoundRect(r, CornerRadius, CornerRadius, CornerRadius, CornerRadius)
            Dim col As Color
            If MyBase.Enabled Then col = ButtonColor Else col = _disabledButtonColor
            Using p As New Pen(col)
                g.DrawPath(p, rr)
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Draws the inner border for the control
    ''' using the HighlightColor property.
    ''' </summary>
    ''' <param name="g">The graphics object used in the paint event.</param>
    Private Sub DrawInnerStroke(ByVal g As Graphics)
        If Me.ButtonStyle = Style.Flat AndAlso Me.mButtonState = State.None Then
            Return
        End If
        Dim r As Rectangle = Me.ClientRectangle
        r.X += 1
        r.Y += 1
        r.Width -= 3
        r.Height -= 3
        Using rr As GraphicsPath = RoundRect(r, CornerRadius, CornerRadius, CornerRadius, CornerRadius)
            Using p As New Pen(Me.HighlightColor)
                g.DrawPath(p, rr)
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Draws the background for the control
    ''' using the background image and the
    ''' BaseColor.
    ''' </summary>
    ''' <param name="g">The graphics object used in the paint event.</param>
    Private Sub DrawBackground(ByVal g As Graphics)
        If Me.ButtonStyle = Style.Flat AndAlso Me.mButtonState = State.None Then
            Return
        End If
        Dim alpha As Integer = IIf((mButtonState = State.Pressed), 204, 127)
        Dim r As Rectangle = Me.ClientRectangle
        r.Width -= 1
        r.Height -= 1
        Using rr As GraphicsPath = RoundRect(r, CornerRadius, CornerRadius, CornerRadius, CornerRadius)
            Dim baseCol As Color, buttCol As Color
            If MyBase.Enabled Then
                baseCol = BaseColor
                buttCol = ButtonColor
            Else
                baseCol = _disabledButtonColor
                buttCol = _disabledButtonColor
            End If

            Using sb As New SolidBrush(baseCol)
                g.FillPath(sb, rr)
            End Using
            SetClip(g)
            If Me.BackImage IsNot Nothing Then
                g.DrawImage(Me.BackImage, Me.ClientRectangle)
            End If
            g.ResetClip()
            Using sb As New SolidBrush(Color.FromArgb(alpha, buttCol))
                g.FillPath(sb, rr)
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Draws the Highlight over the top of the
    ''' control using the HightlightColor.
    ''' </summary>
    ''' <param name="g">The graphics object used in the paint event.</param>
    Private Sub DrawHighlight(ByVal g As Graphics)
        If Me.ButtonStyle = Style.Flat AndAlso Me.mButtonState = State.None Then
            Return
        End If
        Dim alpha As Integer = IIf((mButtonState = State.Pressed), 60, 150)
        Dim rect As New Rectangle(0, 0, Me.Width, Me.Height / 2)
        Using r As GraphicsPath = RoundRect(rect, CornerRadius, CornerRadius, 0, 0)
            Using lg As New LinearGradientBrush(r.GetBounds(), Color.FromArgb(alpha, Me.HighlightColor), Color.FromArgb(alpha / 3, Me.HighlightColor), LinearGradientMode.Vertical)
                g.FillPath(lg, r)
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Draws the glow for the button when the
    ''' mouse is inside the client area using
    ''' the GlowColor property.
    ''' </summary>
    ''' <param name="g">The graphics object used in the paint event.</param>
    Private Sub DrawGlow(ByVal g As Graphics)
        If Me.mButtonState = State.Pressed Then
            Return
        End If
        SetClip(g)
        Using glow As New GraphicsPath()
            glow.AddEllipse(-5, Convert.ToInt32(Me.Height / 2 - 10), Me.Width + 11, Me.Height + 11)
            Using gl As New PathGradientBrush(glow)
                gl.CenterColor = Color.FromArgb(mGlowAlpha, Me.GlowColor)
                gl.SurroundColors = New Color() {Color.FromArgb(0, Me.GlowColor)}
                g.FillPath(gl, glow)
            End Using
        End Using
        g.ResetClip()
    End Sub

    ''' <summary>
    ''' Draws the text for the button.
    ''' </summary>
    ''' <param name="g">The graphics object used in the paint event.</param>
    Private Sub DrawText(ByVal g As Graphics)
        Dim sf As StringFormat = StringFormatAlignment(Me.TextAlign)
        Dim r As New Rectangle(8, 8, Me.Width - 17, Me.Height - 17)
        g.DrawString(Me.ButtonText, Me.Font, New SolidBrush(Me.ForeColor), r, sf)
    End Sub

    ''' <summary>
    ''' Draws the image for the button
    ''' </summary>
    ''' <param name="g">The graphics object used in the paint event.</param>
    Private Sub DrawImage(ByVal g As Graphics)
        If Me.Image Is Nothing Then
            Return
        End If
        Dim r As New Rectangle(8, 8, Me.ImageSize.Width, Me.ImageSize.Height)
        Select Case Me.ImageAlign
            Case ContentAlignment.TopCenter
                r = New Rectangle(Me.Width / 2 - Me.ImageSize.Width / 2, 8, Me.ImageSize.Width, Me.ImageSize.Height)
                Exit Select
            Case ContentAlignment.TopRight
                r = New Rectangle(Me.Width - 8 - Me.ImageSize.Width, 8, Me.ImageSize.Width, Me.ImageSize.Height)
                Exit Select
            Case ContentAlignment.MiddleLeft
                r = New Rectangle(8, Me.Height / 2 - Me.ImageSize.Height / 2, Me.ImageSize.Width, Me.ImageSize.Height)
                Exit Select
            Case ContentAlignment.MiddleCenter
                r = New Rectangle(Me.Width / 2 - Me.ImageSize.Width / 2, Me.Height / 2 - Me.ImageSize.Height / 2, Me.ImageSize.Width, Me.ImageSize.Height)
                Exit Select
            Case ContentAlignment.MiddleRight
                r = New Rectangle(Me.Width - 8 - Me.ImageSize.Width, Me.Height / 2 - Me.ImageSize.Height / 2, Me.ImageSize.Width, Me.ImageSize.Height)
                Exit Select
            Case ContentAlignment.BottomLeft
                r = New Rectangle(8, Me.Height - 8 - Me.ImageSize.Height, Me.ImageSize.Width, Me.ImageSize.Height)
                Exit Select
            Case ContentAlignment.BottomCenter
                r = New Rectangle(Me.Width / 2 - Me.ImageSize.Width / 2, Me.Height - 8 - Me.ImageSize.Height, Me.ImageSize.Width, Me.ImageSize.Height)
                Exit Select
            Case ContentAlignment.BottomRight
                r = New Rectangle(Me.Width - 8 - Me.ImageSize.Width, Me.Height - 8 - Me.ImageSize.Height, Me.ImageSize.Width, Me.ImageSize.Height)
                Exit Select
        End Select
        g.DrawImage(Me.Image, r)
    End Sub

    Private Sub SetClip(ByVal g As Graphics)
        Dim r As Rectangle = Me.ClientRectangle
        r.X += 1
        r.Y += 1
        r.Width -= 3
        r.Height -= 3
        Using rr As GraphicsPath = RoundRect(r, CornerRadius, CornerRadius, CornerRadius, CornerRadius)
            g.SetClip(rr)
        End Using
    End Sub

#End Region

#Region "- Private Subs -"

    Private Sub VistaButton_Paint(ByVal sender As Object, ByVal e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic
        DrawBackground(e.Graphics)
        DrawHighlight(e.Graphics)
        DrawImage(e.Graphics)
        DrawText(e.Graphics)
        DrawGlow(e.Graphics)
        DrawOuterStroke(e.Graphics)
        DrawInnerStroke(e.Graphics)
    End Sub

    Private Sub VistaButton_Resize(ByVal sender As Object, ByVal e As EventArgs)
        Dim r As Rectangle = Me.ClientRectangle
        r.X -= 1
        r.Y -= 1
        r.Width += 2
        r.Height += 2
        Using rr As GraphicsPath = RoundRect(r, CornerRadius, CornerRadius, CornerRadius, CornerRadius)
            Me.Region = New Region(rr)
        End Using
    End Sub

#Region "- Mouse and Keyboard Events -"

    Private Sub VistaButton_MouseEnter(ByVal sender As Object, ByVal e As EventArgs)
        mButtonState = State.Hover
        mFadeOut.[Stop]()
        mFadeIn.Start()
    End Sub
    Private Sub VistaButton_MouseLeave(ByVal sender As Object, ByVal e As EventArgs)
        mButtonState = State.None
        If Me.mButtonStyle = Style.Flat Then
            mGlowAlpha = 0
        End If
        mFadeIn.[Stop]()
        mFadeOut.Start()
    End Sub

    Private Sub VistaButton_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            mButtonState = State.Pressed
            If Me.mButtonStyle <> Style.Flat Then
                mGlowAlpha = 255
            End If
            mFadeIn.[Stop]()
            mFadeOut.[Stop]()
            Me.Invalidate()
        End If
    End Sub

    Private Sub mFadeIn_Tick(ByVal sender As Object, ByVal e As EventArgs)
        If Me.ButtonStyle = Style.Flat Then
            mGlowAlpha = 0
        End If
        If mGlowAlpha + 30 >= 255 Then
            mGlowAlpha = 255
            mFadeIn.[Stop]()
        Else
            mGlowAlpha += 30
        End If
        Me.Invalidate()
    End Sub

    Private Sub mFadeOut_Tick(ByVal sender As Object, ByVal e As EventArgs)
        If Me.ButtonStyle = Style.Flat Then
            mGlowAlpha = 0
        End If
        If mGlowAlpha - 30 <= 0 Then
            mGlowAlpha = 0
            mFadeOut.[Stop]()
        Else
            mGlowAlpha -= 30
        End If
        Me.Invalidate()
    End Sub

    Private Sub VistaButton_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Space Then
            Dim m As New MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0)
            VistaButton_MouseDown(sender, m)
        End If
    End Sub

    Private Sub VistaButton_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Space Then
            Dim m As New MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0)
            calledbykey = True
            VistaButton_MouseUp(sender, m)
        End If
    End Sub

    Private Sub VistaButton_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            mButtonState = State.Hover
            mFadeIn.[Stop]()
            mFadeOut.[Stop]()
            Me.Invalidate()
            If calledbykey = True Then
                Me.OnClick(EventArgs.Empty)
                calledbykey = False
            End If
        End If
    End Sub

#End Region

#End Region

End Class

