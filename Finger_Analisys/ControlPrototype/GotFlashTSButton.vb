Public Class GotFlashTSButton
    Public ControlStripButton As ToolStripButton
    Private _tmrFlasherToolStrip As Timer

    Private _NumberOfFlashes As Integer
    Private _FlashColor As Color
    Private _Msg As String
    Private _FlashCycleDuration As Integer

    Private _numberOfFlashesFinished As Integer
    Private _initialControlBackColor As Color
    Private _strInitialControlText As String
    Private _IsInfinite As Boolean = False

    Public Property NumberOfFlashes() As Integer
        Get
            Return _NumberOfFlashes
        End Get
        Set(ByVal value As Integer)
            _NumberOfFlashes = value
        End Set
    End Property

    Public Property FlashColor() As Color
        Get
            Return _flashColor
        End Get
        Set(ByVal value As Color)
            _FlashColor = value
        End Set
    End Property

    Public Property Msg() As String
        Get
            Return _msg
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

    Private Sub InitializeToStart(ByVal mControlStripButton As ToolStripButton, ByVal mNumberOfFlashes As Integer, ByVal mFlashCycleDuration As Integer, ByVal mFlashColor As Color, ByVal mStrMessage As String)

        If _tmrFlasherToolStrip Is Nothing Then
            _tmrFlasherToolStrip = New Timer
            AddHandler _tmrFlasherToolStrip.Tick, AddressOf tmrFlasherToolStrip_Tick
            _tmrFlasherToolStrip.Interval = 10
            ' Initialize the flasher data
            ControlStripButton = mControlStripButton
            NumberOfFlashes = mNumberOfFlashes
            FlashCycleDuration = mFlashCycleDuration
            FlashColor = mFlashColor
            Msg = mStrMessage
            ' reset the flasher
            _numberOfFlashesFinished = 0
            _initialControlBackColor = ControlStripButton.BackColor
            _strInitialControlText = ControlStripButton.Text
        End If
    End Sub

    Public Sub Start(ByVal mControlStripButton As ToolStripButton, ByVal mNumberOfFlashes As Integer, ByVal mFlashCycleDuration As Integer, ByVal mFlashColor As Color, ByVal mStrMessage As String)
        InitializeToStart(mControlStripButton, mNumberOfFlashes, mFlashCycleDuration, mFlashColor, mStrMessage)
        StartToolStrip()
    End Sub

    Public Sub StartInfinite(ByVal mControlStripButton As ToolStripButton, ByVal mFlashCycleDuration As Integer, ByVal mFlashColor As Color, ByVal mStrMessage As String)
        _IsInfinite = True
        InitializeToStart(mControlStripButton, 2, mFlashCycleDuration, mFlashColor, mStrMessage)
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
        ControlStripButton.BackColor = (IIf((ControlStripButton.BackColor = _initialControlBackColor), FlashColor, _initialControlBackColor))
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
                ControlStripButton.BackColor = _initialControlBackColor
                ControlStripButton.Text = _strInitialControlText

                ' No more flashing
                _tmrFlasherToolStrip = Nothing
                Return
            End If
        End If

        FlashToolStrip()
    End Sub

End Class
