Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing

Public Class GotFlashControl
    Public MyControl As Control
    Private _tmrFlasher As Timer

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
            Return _FlashColor
        End Get
        Set(ByVal value As Color)
            _FlashColor = value
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
            Return _FlashCycleDuration
        End Get
        Set(ByVal value As Integer)
            _FlashCycleDuration = value
        End Set
    End Property

    Private Sub InitializeToStart(ByVal mControl As Control, ByVal mNumberOfFlashes As Integer, ByVal mFlashCycleDuration As Integer, ByVal mFlashColor As Color, ByVal mStrMessage As String)
        Try

      
            If _tmrFlasher Is Nothing Then
                _tmrFlasher = New Timer
                AddHandler _tmrFlasher.Tick, AddressOf tmrFlasher_Tick
                _tmrFlasher.Interval = 10
                ' Initialize the flasher data
                MyControl = mControl
                NumberOfFlashes = mNumberOfFlashes
                FlashCycleDuration = mFlashCycleDuration
                FlashColor = mFlashColor
                Msg = mStrMessage
                ' reset the flasher
                _numberOfFlashesFinished = 0
                _initialControlBackColor = mControl.BackColor
                _strInitialControlText = mControl.Text
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Start(ByVal mControl As Control, ByVal mNumberOfFlashes As Integer, ByVal mFlashCycleDuration As Integer, ByVal mFlashColor As Color, ByVal mStrMessage As String)
        InitializeToStart(mControl, mNumberOfFlashes, mFlashCycleDuration, mFlashColor, mStrMessage)
        StartTimer()
    End Sub

    Public Sub StartInfinite(ByVal mControl As Control, ByVal mFlashCycleDuration As Integer, ByVal mFlashColor As Color, ByVal mStrMessage As String)
        _IsInfinite = True
        InitializeToStart(mControl, 2, mFlashCycleDuration, mFlashColor, mStrMessage)
        StartTimer()
    End Sub

    Public Sub StopMe()
        _IsInfinite = False
        _numberOfFlashesFinished = NumberOfFlashes + 1
    End Sub

    Private Sub StartTimer()
        ' Start the flash timer
        _tmrFlasher.Start()
    End Sub

    Private Sub FlashToolStrip()
        MyControl.BackColor = (IIf((MyControl.BackColor = _initialControlBackColor), FlashColor, _initialControlBackColor))
        MyControl.Text = Msg
    End Sub


    Private Sub tmrFlasher_Tick(ByVal sender As Object, ByVal e As EventArgs)
        ' Set the timer interval (timer fine tuning)
        _tmrFlasher.Interval = FlashCycleDuration

        ' Check if we are finished
        If Not _IsInfinite Then
            If System.Threading.Interlocked.Increment(_numberOfFlashesFinished) > NumberOfFlashes Then
                ' Our work is finished
                _tmrFlasher.Stop()

                ' Set the control back color back to the way it was before
                MyControl.BackColor = _initialControlBackColor
                MyControl.Text = _strInitialControlText

                ' No more flashing
                _tmrFlasher = Nothing
                Return
            End If
        End If

        FlashToolStrip()
    End Sub
End Class
