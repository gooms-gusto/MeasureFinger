Public Class GotFlashTSVButton
    Public ControlStripButton As ToolStripButton
    Private _tmrFlasherToolStrip As Timer

    Private _NumberOfFlashes As Integer
    Private _Msg As String
    Private _FlashCycleDuration As Integer

    Private _numberOfFlashesFinished As Integer
    Private _strInitialControlText As String
    Private _IsInfinite As Boolean = False

    Private _initialControlFontColor As Color
    Private _flashFontColor As Color

    Public Property FlashFontColor() As Color
        Get
            Return _flashFontColor
        End Get
        Set(ByVal value As Color)
            _flashFontColor = value
        End Set
    End Property

    Public Property NumberOfFlashes() As Integer
        Get
            Return _NumberOfFlashes
        End Get
        Set(ByVal value As Integer)
            _NumberOfFlashes = value
        End Set
    End Property

    Public Property Msg() As String
        Get
            Return _Msg
        End Get
        Set(ByVal value As String)
            _Msg = value
        End Set
    End Property

    Public Property FlashCycleDuration() As Integer
        Get
            Return _flashCycleDuration
        End Get
        Set(ByVal value As Integer)
            _FlashCycleDuration = value
        End Set
    End Property

    Private Sub InitializeToStart(ByVal mControlStripButton As ToolStripButton, ByVal mNumberOfFlashes As Integer, _
        ByVal mFlashCycleDuration As Integer, ByVal mFlashFontColor As Color, ByVal mStrMessage As String)

        If _tmrFlasherToolStrip Is Nothing Then
            _tmrFlasherToolStrip = New Timer
            AddHandler _tmrFlasherToolStrip.Tick, AddressOf tmrFlasherToolStrip_Tick
            _tmrFlasherToolStrip.Interval = 10
            ' Initialize the flasher data
            ControlStripButton = mControlStripButton
            NumberOfFlashes = mNumberOfFlashes
            FlashCycleDuration = mFlashCycleDuration
            Msg = mStrMessage
            ' reset the flasher
            _numberOfFlashesFinished = 0
            FlashFontColor = mFlashFontColor
            _initialControlFontColor = ControlStripButton.ForeColor
            _strInitialControlText = ControlStripButton.Text
        End If
    End Sub

    Public Sub Start(ByVal mControlStripButton As ToolStripButton, ByVal mNumberOfFlashes As Integer, _
        ByVal mFlashCycleDuration As Integer, ByVal mFlashFontColor As Color, ByVal mStrMessage As String)
        InitializeToStart(mControlStripButton, mNumberOfFlashes, mFlashCycleDuration, mFlashFontColor, mStrMessage)
        StartToolStrip()
    End Sub

    Public Sub StartInfinite(ByVal mControlStripButton As ToolStripButton, ByVal mFlashCycleDuration As Integer, _
           ByVal mFlashFontColor As Color, ByVal mStrMessage As String)
        _IsInfinite = True
        InitializeToStart(mControlStripButton, 2, mFlashCycleDuration, mFlashFontColor, mStrMessage)
        StartToolStrip()
    End Sub

    Public Sub StopMe()
        _IsInfinite = False
        _numberOfFlashesFinished = NumberOfFlashes + 1
    End Sub

    Private Sub StartToolStrip()
        ' Start the flash timer
        _tmrFlasherToolStrip.Start()
    End Sub

    Private Sub FlashToolStrip()
        If ControlStripButton.CheckState = CheckState.Unchecked Then
            ControlStripButton.CheckState = CheckState.Checked
            ControlStripButton.ForeColor = FlashFontColor
        Else
            ControlStripButton.CheckState = CheckState.Unchecked
            ControlStripButton.ForeColor = _initialControlFontColor
        End If
        ControlStripButton.Text = Msg
    End Sub


    Private Sub tmrFlasherToolStrip_Tick(ByVal sender As Object, ByVal e As EventArgs)
        ' Set the timer interval (timer fine tuning)
        _tmrFlasherToolStrip.Interval = FlashCycleDuration

        ' Check if we are finished
        If Not _IsInfinite Then
            If System.Threading.Interlocked.Increment(_numberOfFlashesFinished) > NumberOfFlashes Then
                ' Our work is finished
                _tmrFlasherToolStrip.Stop()

                ' Set the control back color back to the way it was before
                ControlStripButton.CheckState = CheckState.Unchecked
                ControlStripButton.ForeColor = _initialControlFontColor
                ControlStripButton.Text = _strInitialControlText

                ' No more flashing
                _tmrFlasherToolStrip = Nothing
                Return
            End If
        End If

        FlashToolStrip()
    End Sub

End Class
