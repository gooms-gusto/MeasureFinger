

Imports System
Imports System.IO
Imports System.Text
Imports System.Runtime.Serialization


''' <summary>
''' This class is used to measure the execution time of arbitrary methods.
''' </summary>
''' <remarks>This class can be used in several ways. The simplest use is
''' to call the <c>static</c> <see cref="TimeBlock"/> method in a
''' C# <c>using statement.</c> (This can be accomplished in other
''' languanges by calling the <see cref="Dispose"/> method manually.)
''' <br/>
''' The second way to use this class is to instantiate it and call
''' its methods directly to measure the execution time for a given
''' method. Every time the same timer is started and stopped, statistics
''' for the series are updated. These statistics can be cleared by calling
''' <see cref="ClearRunHistory"/>.
''' <br/>
''' The third way is to specify a <see cref="TimedMethod"/> object
''' which contains a method to measure, number of times to run it,
''' and (optionally) set-up and tear-down methods.
''' <br/>
''' With the second and third methods, relatively fine-grained control
''' is given to the caller for how and where the output is written. This
''' control is exercised through the <see cref="BeginDelim"/>,
''' <see cref="EndDelim"/>, <see cref="SeriesBeginDelim"/>, and
''' <see cref="SeriesEndDelim"/> string properties, the <see cref="BeginPrintString"/>,
''' <see cref="EndPrintString"/>, <see cref="SeriesBeginPrintString"/>,
''' <see cref="SeriesEndPrintString"/> <see cref="PrintString"/> delegate
''' properties, and the <see cref="ResultsPrinting"/>, <see cref="ResultsPrinted"/>,
''' <see cref="SeriesResultsPrinting"/>, and <see cref="SeriesResultsPrinted"/>
''' events.</remarks>
''' <example>
''' The following example shows all three uses.
''' <code>
''' public class Example
''' {
''' public static void Main()
''' {
''' Example example = new Example();
''' example.TimeMethods();
''' }
'''
''' // This is the method we'll be timing
''' private void TakeOneSecond()
''' {
''' System.Threading.Thread.Sleep(1000);
''' }
'''
''' private void TimeMethods()
''' {
''' // Time it using the using statement with the TimeBlock method.
''' using(ExecutionTimer.TimeBlock("Method 1"))
''' {
''' TakeOneSecond();
''' }
'''
''' // Time it by instantiating an ExecutionTimer object and
''' // calling its methods.
''' ExecutionTimer timer = new ExecutionTimer("Method 2");
'''
''' // Set the string to be printed before the results are printed.
''' timer.BeginPrintString = "------------";
'''
''' timer.Start();
'''
''' // Run the method being timed.
''' TakeOneSecond();
'''
''' timer.Stop();
'''
''' // If timer.AutoTrace were set to true, this would
''' // have been called automatically when the timer was stopped.
''' timer.Write();
'''
''' // Add a few more runs to the same timer
''' for(int i = 0; i &lt; 3; i++)
''' {
''' timer.Start();
'''
''' TakeOneSecond();
'''
''' timer.Stop();
''' }
'''
''' // Now write the results for the series
''' timer.WriteSeries();
'''
'''
''' // Time it by passing delegates targeting the method to time
''' // as well as customize the output a bit
''' TimeMethodsWithDelegates();
''' }
'''
''' private string GetOutputHeader(string timerName)
''' {
''' string output = "Executing " + timerName + " on ";
'''
''' output += DateTime.Now.ToLongDateString();
'''
''' output += " at ";
'''
''' outout += DateTime.Now.ToLongTimeString();
'''
''' return output;
''' }
'''
''' private void BeforeOutputWritten(object sender, ExecutionTimerEventArgs e)
''' {
''' // I'd like to handle the output for different timers differently.
'''
''' ExecutionTimer timer = (ExecutionTimer)sender;
'''
''' if(e.TimerName.StartsWith("Test"))
''' timer.Out = Console.Out;
''' else
''' timer.Out = writer; // writer is a TextWriter defined elsewhere
''' }
'''
''' private void AfterOutputWritten(object sender, ExecutionTimerEventArgs e)
''' {
''' // We need to clean up if our TextWriter was used
'''
''' if(e.TimerName.StartsWith("Test") &amp;&amp;
''' writer != null)
''' writer.Close();
''' }
'''
''' private void TimeMethodsWithDelegates()
''' {
''' // This method of using ExecutionTimer is geared towards automated
''' // suites and the like where you can set up methods to run from
''' // configuration files or other sources. It is usually used
''' // in conjuction with an ExecutionTimerManager object instead of
''' // directly, but it can be used alone as shown here.
'''
''' ExecutionTimer timer = new ExecutionTimer("Method 3");
'''
''' // Print out the results of each run automatically
''' timer.AutoTrace = true;
'''
''' timer.BeginPrintString = new PrintString(GetOutputHeader);
'''
''' // Hook up our event handlers
''' timer.ResultsPrinting += new ExecutionTimerEventHandler(BeforeOutputWritten);
'''
''' timer.ResultsPrinted += new ExecutionTimerEventHandler(AfterOutputWritten);
'''
''' // Specify the delegates to be run
'''
''' TimedMethod timedMethod = new TimedMethod();
'''
''' timedMethod.Method = new MethodInvoker(TakeOneSecond);
'''
''' timedMethod.Iterations = 3;
'''
''' // If the timed method needs arguments, we can pass them
''' // here. Also, if the timed method changes the state of an
''' // object, we can specify set-up and tear-down methods to restore
''' // the state for each run. Those methods can also have arguments
''' /// specified.
'''
''' timer.TimedMethod = timedMethod;
'''
''' timer.RunTimedMethod();
''' }
''' }
'''
''' Here is the output produced by the preceding code:
'''
''' 
''' Execution time for "Method 1" (Run 1): 1000 ms.
'''
''' ------------
''' Execution time for "Method 2" (Run 1): 1000 ms.
'''
''' 
''' Stats for "Method 2":
''' - Number of runs completed: 4
''' - Average execution time per run: 1000 ms.
''' - Shortest run: 1000 ms.
''' - Longest run: 1000 ms.
'''
''' Executing Method 3 on Friday, October 22, 2004 at 4:18:35 PM
''' Execution time for "Method 3" (Run 1): 1000 ms.
'''
''' Executing Method 3 on Friday, October 22, 2004 at 4:18:36 PM
''' Execution time for "Method 3" (Run 2): 1000 ms.
'''
''' Executing Method 3 on Friday, October 22, 2004 at 4:18:37 PM
''' Execution time for "Method 3" (Run 3): 1000 ms.
'''
''' 
''' Stats for "Method 3":
''' - Number of runs completed: 3
''' - Average execution time per run: 1000 ms.
''' - Shortest run: 1000 ms.
''' - Longest run: 1000 ms.
''' </code>
''' </example>
Public Class ExecutionTimer
    Implements IDisposable

#Region "Private Fields"

    Private _beginDelim As String
    Private _endDelim As String
    Private _seriesBeginDelim As String
    Private _seriesEndDelim As String
    Private _name As String
    Private _start As Long
    Private _end As Long
    Private _totalExecutionTime As Long
    Private _numberOfRuns As Integer
    Private _autoTrace As Boolean
    Private _running As Boolean
    Private _out As TextWriter
    Private _longestRun As TimeSpan
    Private _shortestRun As TimeSpan
    Private _beginPrintString As PrintString
    Private _endPrintString As PrintString
    Private _seriesBeginPrintString As PrintString
    Private _seriesEndPrintString As PrintString
    Private _timedMethod As TimedMethod
    Private _messageB As MessageBox


#End Region

#Region "Constructors"

    ''' <summary>
    ''' Initializes a new instance of the ExecutionTimer class.
    ''' </summary>
    Public Sub New()
        _name = String.Empty
        _endDelim = String.Empty
        _seriesEndDelim = String.Empty
        _end = 0
        _start = 0
        _numberOfRuns = 0
        _totalExecutionTime = 0
        _running = False
        _autoTrace = False
        _timedMethod = Nothing
        _endPrintString = Nothing
        _beginPrintString = Nothing
        _seriesEndPrintString = Nothing
        _seriesBeginPrintString = Nothing
        _out = Console.Out
        _longestRun = TimeSpan.Zero
        _shortestRun = TimeSpan.Zero
        _beginDelim = ""
        _seriesBeginDelim = ""
     

    End Sub

    Private Sub myThread_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)

    End Sub






    ''' <summary>
    ''' Initializes a new instance of the ExecutionTimer class.
    ''' </summary>
    ''' <param name="name">Name (or description) of the timer instance.</param>
    Public Sub New(ByVal name As String)
        Me.New()
        _name = name
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the ExecutionTimer class.
    ''' </summary>
    ''' <param name="name">Name (or description) of the timer instance.</param>
    ''' <param name="autoTrace">If true, Write and WriteSeries will be called automatically when Stop and
    ''' RunTimedMethod, respectively, are called.</param>
    Public Sub New(ByVal name As String, ByVal autoTrace As Boolean)
        Me.New(name)
        _autoTrace = autoTrace
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the ExecutionTimer class.
    ''' </summary>
    ''' <param name="name">Name (or description) of the timer instance.</param>
    ''' <param name="timedMethod">The delegate targeting the method to execute when
    ''' RunTimedMethod is called.</param>
    Public Sub New(ByVal name As String, ByVal timedMethod__1 As TimedMethod)
        Me.New(name)
        _timedMethod = TimedMethod
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the ExecutionTimer class.
    ''' </summary>
    ''' <param name="name">Name (or description) of the timer instance.</param>
    ''' <param name="timedMethod">The delegate targeting the method to execute when
    ''' RunTimedMethod is called.</param>
    ''' <param name="autoTrace">If true, Write and WriteSeries will be called automatically when Stop and
    ''' RunTimedMethod, respectively, are called.</param>
    Public Sub New(ByVal name As String, ByVal timedMethod As TimedMethod, ByVal autoTrace As Boolean)
        Me.New(name, timedMethod)
        _autoTrace = autoTrace
    End Sub

#End Region

#Region "Properties"

    ''' <summary>
    ''' Gets or sets the the TextWriter the output will be written to. Default is set to System.Console.Out
    ''' </summary>
    Public Property Out() As TextWriter
        Get
            Return _out
        End Get
        Set(ByVal value As TextWriter)
            _out = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the string to be printed before the output for each run.
    ''' </summary>
    Public Property BeginDelim() As String
        Get
            Return _beginDelim
        End Get
        Set(ByVal value As String)
            _beginDelim = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the string to be printed after the output for each run.
    ''' </summary>
    Public Property EndDelim() As String
        Get
            Return _endDelim
        End Get
        Set(ByVal value As String)
            _endDelim = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the string to be printed before series stats are output.
    ''' </summary>
    Public Property SeriesBeginDelim() As String
        Get
            Return _seriesBeginDelim
        End Get
        Set(ByVal value As String)
            _seriesBeginDelim = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the string to be printed after series stats are output.
    ''' </summary>
    Public Property SeriesEndDelim() As String
        Get
            Return _seriesEndDelim
        End Get
        Set(ByVal value As String)
            _seriesEndDelim = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the PrintString delegate to be executed before the output for each run is written.
    '''
    ''' If not null, the return value from this delegate is used in place of the string
    ''' contained in the BeginDelim property. If this delegate targets more then one method, only the
    ''' first will be called.
    ''' </summary>
    Public Property BeginPrintString() As PrintString
        Get
            Return _beginPrintString
        End Get
        Set(ByVal value As PrintString)
            _beginPrintString = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the PrintString delegate to be executed after the output for each run is written.
    '''
    ''' If not null, the return value from this delegate is used in place of the string
    ''' contained in the EndDelim property. If this delegate targets more then one method, only the
    ''' first will be called.
    ''' </summary>
    Public Property EndPrintString() As PrintString
        Get
            Return _endPrintString
        End Get
        Set(ByVal value As PrintString)
            _endPrintString = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the PrintString delegate to be executed before the series stats are written.
    '''
    ''' If not null, the return value from this delegate is used in place of the string
    ''' contained in the SeriesBeginDelim property. If this delegate targets more then one method,
    ''' only the first will be called.
    ''' </summary>
    Public Property SeriesBeginPrintString() As PrintString
        Get
            Return _seriesBeginPrintString
        End Get
        Set(ByVal value As PrintString)
            _seriesBeginPrintString = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the PrintString delegate to be executed after the series stats are written.
    '''
    ''' If not null, the return value from this delegate is used in place of the string
    ''' contained in the SeriesEndDelim property. If this delegate targets more then one method,
    ''' only the first will be called.
    ''' </summary>
    Public Property SeriesEndPrintString() As PrintString
        Get
            Return _seriesEndPrintString
        End Get
        Set(ByVal value As PrintString)
            _seriesEndPrintString = value
        End Set
    End Property

    ''' <summary>
    ''' Gets the name for (or description) of this instance. This is included in any output.
    ''' </summary>
    Public ReadOnly Property Name() As String
        Get
            Return _name
        End Get
    End Property

    ''' <summary>
    ''' Gets the TimeSpan representing execution time of the longest run in the series.
    ''' </summary>
    Public ReadOnly Property LongestRun() As TimeSpan
        Get
            Return _longestRun
        End Get
    End Property

    ''' <summary>
    ''' Gets the TimeSpan representing execution time of the shortest run in the series.
    ''' </summary>
    Public ReadOnly Property ShortestRun() As TimeSpan
        Get
            Return _shortestRun
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets the value indicating whether to automatically call the Write method when
    ''' the timer is stopped and WriteSeries after all iterations have been completed in
    ''' RunTimedMethod.
    ''' </summary>
    Public Property AutoTrace() As Boolean
        Get
            Return _autoTrace
        End Get
        Set(ByVal value As Boolean)
            _autoTrace = value
        End Set
    End Property

    ''' <summary>
    ''' Gets the number of times this instance has been started and stopped.
    ''' </summary>
    Public ReadOnly Property RunCount() As Integer
        Get
            Return _numberOfRuns
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets the <see cref="TimedMethod"/> object whcih specifies
    ''' the method to be timed.
    ''' </summary>
    Public Property TimedMethod() As TimedMethod
        Get
            Return _timedMethod
        End Get
        Set(ByVal value As TimedMethod)
            _timedMethod = value
        End Set
    End Property

    Private _writeStringOutput As String

    ''' <summary>
    ''' Gets the <see cref="WriteStringOutput"/> which return
    ''' output string
    ''' </summary>
    Public ReadOnly Property WriteStringOutput() As String
        Get
            Return _writeStringOutput
        End Get
    End Property

    ''' <summary>
    ''' Gets the <see cref="Running"/> which return
    ''' output bool
    ''' </summary>
    Public ReadOnly Property IsRunning() As Boolean
        Get
            Return _running
        End Get
    End Property

#End Region

#Region "Events"

    ''' <summary>
    ''' Occurs when the timer is about to be started.
    ''' </summary>
    Public Event TimerStarting As ExecutionTimerEventHandler

    ''' <summary>
    ''' Occurs when the timer has been recorded.
    ''' </summary>
    ''' <remarks>This event is fired after the timer's stop time
    ''' has been recorded and all statistics have been updated, but before
    ''' any output has been written (if AutoTrace is set to true).</remarks>
    Public Event TimerStopped As ExecutionTimerStoppedEventHandler

    ''' <summary>
    ''' Occurs when results for a run are about to be printed.
    ''' </summary>
    ''' <remarks>This event is fired before any output is
    ''' written for the run.</remarks>
    Public Event ResultsPrinting As ExecutionTimerEventHandler

    ''' <summary>
    ''' Occurs after results for a run are printed.
    ''' </summary>
    ''' <remarks>This event is fired after all output is
    ''' written for the run.</remarks>
    Public Event ResultsPrinted As ExecutionTimerEventHandler

    ''' <summary>
    ''' Occurs when results for a series are about to be printed.
    ''' </summary>
    ''' <remarks>This event is fired before any output is
    ''' written for the series.</remarks>
    Public Event SeriesResultsPrinting As ExecutionTimerEventHandler

    ''' <summary>
    ''' Occurs after results for a series are printed.
    ''' </summary>
    ''' <remarks>This event is fired after all output is
    ''' written for the series.</remarks>
    Public Event SeriesResultsPrinted As ExecutionTimerEventHandler

#End Region

#Region "Public Instance Methods"

    ''' <summary>
    ''' Resets RunCount, LongestRun, ShortestRun to their initial values.
    ''' </summary>
    Public Sub ClearRunHistory()
        _running = False
        _start = 0
        _end = 0
        _numberOfRuns = 0
        _totalExecutionTime = 0
        _longestRun = TimeSpan.Zero
        _shortestRun = TimeSpan.Zero
    End Sub

    ''' <summary>
    ''' Runs the method targeted by the TimedMethod delegate with no arguments for the
    ''' specified number of iterations.
    ''' </summary>
    ''' <exception cref="SeriesAbortedException">One of the methods specified
    ''' by the set-up timed method, or tear-down
    ''' delegates failed. This could be caused by the method not being found,
    ''' the target method throwing an exception, the caller not haing the
    ''' required permissions to call the method, or the incorrect aruments being
    ''' passed to the delegate method.</exception>
    Public Sub RunTimedMethod()
        RunTimedMethod(_timedMethod.Iterations)
    End Sub

    ''' <summary>
    ''' Runs the methods targeted by the delegates specified in the
    ''' TimedMethod object with the specified arguments.
    ''' </summary>
    ''' <param name="timedMethod">TimedMethod containing the delegates
    ''' targeting the methods to be executed, along with any arguments to
    ''' pe passed to those methods. The TimedMethod property will
    ''' be set to the value of this argument.</param>
    ''' <exception cref="SeriesAbortedException">One of the methods specified
    ''' by the set-up timed method, or tear-down
    ''' delegates failed. This could be caused by the method not being found,
    ''' the target method throwing an exception, the caller not haing the
    ''' required permissions to call the method, or the incorrect aruments being
    ''' passed to the delegate method.</exception>
    Public Sub RunTimedMethod(ByVal timedMethod As TimedMethod)
        If _timedMethod IsNot timedMethod Then
            _timedMethod = timedMethod
        End If

        RunTimedMethod(_timedMethod.Iterations)
    End Sub

    ''' <summary>
    ''' Runs the methods targeted by the delegates specified in the
    ''' TimedMethod object with the specified arguments for the
    ''' specified number of iterations.
    ''' </summary>
    ''' <param name="timedMethod">TimedMethod containing the delegates
    ''' targeting the methods to be executed, along with any arguments to
    ''' pe passed to those methods. The TimedMethod property will
    ''' be set to the value of this argument.</param>
    ''' <param name="iterations">The number of times to run the timed method.
    ''' This will not set the Iterations property of the TimedMethod object.</param>
    ''' <exception cref="SeriesAbortedException">One of the methods specified
    ''' by the set-up timed method, or tear-down
    ''' delegates failed. This could be caused by the method not being found,
    ''' the target method throwing an exception, the caller not haing the
    ''' required permissions to call the method, or the incorrect aruments being
    ''' passed to the delegate method.</exception>
    Public Sub RunTimedMethod(ByVal timedMethod As TimedMethod, ByVal iterations As Integer)

        If _timedMethod IsNot timedMethod Then
            _timedMethod = timedMethod
        End If

        RunTimedMethod(iterations)
    End Sub

    ''' <summary>
    ''' Runs the method targeted by the TimedMethod delegate with no arguments for the
    ''' specified number of iterations.
    ''' </summary>
    ''' <param name="iterations">The number of times to run the timed method. This will not
    ''' set the Iterations property of the TimedMethod object.</param>
    ''' <exception cref="SeriesAbortedException">One of the methods specified
    ''' by the set-up timed method, or tear-down
    ''' delegates failed. This could be caused by the method not being found,
    ''' the target method throwing an exception, the caller not haing the
    ''' required permissions to call the method, or the incorrect aruments being
    ''' passed to the delegate method.</exception>
    Public Sub RunTimedMethod(ByVal iterations As Integer)
        ' Note: The actual implementation of this method is in an overload of RunTimedMethod
        ' that accepts an int parameter so that the number of iterations to perform
        ' are settable at the method level without having to alter the Iterations property
        ' of the TimedMethod being run. I thought it may be helpful to do so in certain
        ' situations.

        ' These exist because I don't want to alter the input parameters
        Dim localArgs As Object()
        Dim localSetUpArgs As Object()
        Dim localTearDownArgs As Object()

        ' validate arguments
        If _timedMethod Is Nothing Then
            Throw New InvalidOperationException("_timedMethod cannot be null")
        End If

        'If any of the args are null, create an empty object array.
        localArgs = IIf(_timedMethod.Args Is Nothing, New Object() {}, _timedMethod.Args)

        localSetUpArgs = IIf(_timedMethod.SetUpArgs Is Nothing, New Object() {}, _timedMethod.SetUpArgs)

        localTearDownArgs = IIf(_timedMethod.TearDownArgs Is Nothing, New Object() {}, _timedMethod.TearDownArgs)

        ' Need at least one iteration to execute.
        If iterations < 1 Then
            Throw New ArgumentOutOfRangeException("iterations", iterations, "Value must be greater than or equal to 1")
        End If

        For i As Integer = 0 To iterations - 1
            If _timedMethod.SetUp IsNot Nothing Then
                ' A set-up method has been specified. Try to run it.
                Try
                    _timedMethod.SetUp.GetInvocationList()(0).DynamicInvoke(localSetUpArgs)
                Catch ex As ArgumentException
                    ClearRunHistory()
                    Throw New SeriesAbortedException("Series aborted at TimedMethod.SetUp. Run history cleared.", _name, ex)
                Catch ex As MemberAccessException
                    ClearRunHistory()
                    Throw New SeriesAbortedException("Series aborted at TimedMethod.SetUp. Run history cleared.", _name, ex)
                Catch ex As System.Reflection.TargetException
                    ClearRunHistory()
                    Throw New SeriesAbortedException("Series aborted at TimedMethod.SetUp. Run history cleared.", _name, ex)
                Catch ex As System.Reflection.TargetInvocationException
                    ClearRunHistory()
                    Throw New SeriesAbortedException("Series aborted at TimedMethod.SetUp. Run history cleared.", _name, ex)
                End Try
            End If

            ' The timer is only run after the set-up method has completed.
            Start(False)

            Try
                ' Run the main method to be timed.
                _timedMethod.Method.GetInvocationList()(0).DynamicInvoke(localArgs)

                ' Stop the timer before running the tear-down method.
                [Stop](False)

                If _timedMethod.TearDown IsNot Nothing Then
                    ' A tear-down method has been specified. Try to run it.
                    Try
                        _timedMethod.TearDown.GetInvocationList()(0).DynamicInvoke(localTearDownArgs)
                    Catch ex As ArgumentException
                        ClearRunHistory()
                        Throw New SeriesAbortedException("Series aborted at TimedMethod.TearDown. Run history cleared.", _name, ex)
                    Catch ex As MemberAccessException
                        ClearRunHistory()
                        Throw New SeriesAbortedException("Series aborted at TimedMethod.TearDown. Run history cleared.", _name, ex)
                    Catch ex As System.Reflection.TargetException
                        ClearRunHistory()
                        Throw New SeriesAbortedException("Series aborted at TimedMethod.TearDown. Run history cleared.", _name, ex)
                    Catch ex As System.Reflection.TargetInvocationException
                        ClearRunHistory()
                        Throw New SeriesAbortedException("Series aborted at TimedMethod.TearDown. Run history cleared.", _name, ex)
                    End Try
                End If
            Catch ex As ArgumentException
                ClearRunHistory()
                Throw New SeriesAbortedException("Series aborted at TimedMethod.Method. Run history cleared.", _name, ex)
            Catch ex As MemberAccessException
                ClearRunHistory()
                Throw New SeriesAbortedException("Series aborted at TimedMethod.Method. Run history cleared.", _name, ex)
            Catch ex As System.Reflection.TargetException
                ClearRunHistory()
                Throw New SeriesAbortedException("Series aborted at TimedMethod.Method. Run history cleared.", _name, ex)
            Catch ex As System.Reflection.TargetInvocationException
                ClearRunHistory()
                Throw New SeriesAbortedException("Series aborted at TimedMethod.Method. Run history cleared.", _name, ex)
            End Try
        Next

        If _autoTrace Then
            WriteSeries()
        End If
    End Sub

    ''' <summary>
    ''' Returns the execution time of the last run.
    ''' </summary>
    ''' <returns>TimeSpan</returns>
    ''' <exception cref="InvalidOperationException">The timer is
    ''' currently running.</exception>
    Public Function GetExecutionTime() As TimeSpan
        ' _end - _start will return a negative value if the timer
        ' is running, which doesn't make much sense.
        'if(_running)
        ' throw new InvalidOperationException("Cannot get execution time "
        ' + "while timer is running.");
        _end = DateTime.Now.Ticks
        Dim ticks As Long = _end - _start

        Return New TimeSpan(ticks)
    End Function

    ''' <summary>
    ''' Returns the average execution time for all runs.
    ''' </summary>
    ''' <returns>TimeSpan</returns>
    Public Function GetSeriesAverageExecutionTime() As TimeSpan
        ' Just return a zero length TimeSpan if no runs have been completed.
        ' Also guards against potential divide-by-zero exception on the next line.
        If _numberOfRuns = 0 Then
            Return TimeSpan.Zero
        End If

        Dim averageRun As Long = _totalExecutionTime / _numberOfRuns

        Return New TimeSpan(averageRun)
    End Function



    ''' <summary>
    ''' Starts the timer.
    ''' </summary>
    Public Sub Start(ByVal IsShowMessageBox As Boolean)
        ' Take no action if the timer is already running
        If _running Then
            Exit Sub
        End If

        _running = True

        OnTimerStarting(New ExecutionTimerEventArgs(Name))

        ' Record start time just before returning
        _start = DateTime.Now.Ticks

        If IsShowMessageBox Then
            Dim frm As New frmTimer(Me)

            frm.Show()
        End If
        'frm.initialize(this);
        'frm.Show();
        'myThread.RunWorkerAsync();
    End Sub


    Private Sub myThread_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)

    End Sub

    ''' <summary>
    ''' Stops the timer. If AutoTrace is set to true, calls Write after timer is stopped.
    ''' </summary>
    Public Sub [Stop](ByVal IsShowMessageBox As Boolean)
        ' I'm using a temporary variable because I want to recod
        ' the end time right away so the execution time isn't
        ' being extended by this class' execution and I don't want to
        ' stomp any preexisting value if the timer is not actually running
        Dim tmpEnd As Long = DateTime.Now.Ticks

        ' Take no action if Stop is called on a stopped timer
        If Not _running Then
            Exit Sub
        End If

        _running = False

        _end = tmpEnd

        _numberOfRuns += 1

        Dim thisRun As TimeSpan = GetExecutionTime()

        _totalExecutionTime += thisRun.Ticks

        If _numberOfRuns = 1 Then
            ' The first run will always be the longest and shortest.
            _shortestRun = thisRun
            _longestRun = thisRun
        Else
            ' See if this run was shorter or longer than any other.
            _shortestRun = IIf(thisRun < _shortestRun, thisRun, _shortestRun)
            _longestRun = IIf(thisRun > _longestRun, thisRun, _longestRun)
        End If

        ' Raise the TimerStopped event.
        OnTimerStopped(New ExecutionTimerDetailedEventArgs(Name, thisRun, _numberOfRuns, New TimeSpan(_totalExecutionTime), _shortestRun, _longestRun))

        ' If _autoTrace Then
        Write()
        'End If
        Dim frm As New frmTimer(Me)
        If IsShowMessageBox Then frm.Show()
    End Sub

    ''' <summary>
    ''' Writes the timer's Name and total execution time (in milliseconds) to the
    ''' TextWriter specified in the Out property.
    ''' </summary>
    Public Sub Write()
        If _running Then
            Throw New InvalidOperationException("Write called on a running timer")
        End If

        ' Raise the OnResultsPrinting event.
        OnResultsPrinting(New ExecutionTimerEventArgs(Name))

        Dim newLine As String = Environment.NewLine

        ' Get the execution time for the most recent run.
        Dim execTime As TimeSpan = GetExecutionTime()

        Dim output As New StringBuilder()

        ' Build the output.

        'output.Append(GetBeginDelimString());
        'output.Append(newLine);

        If _numberOfRuns = 0 Then
            output.Append("""")
            output.Append(IIf(_name = String.Empty, "<ExecutionTimer>", _name))
            output.Append(""" belum selesai berjalan.")
        Else
            output.Append("Waktu eksekusi untuk ")
            output.Append("""")
            output.Append(IIf(_name = String.Empty, "<ExecutionTimer>", _name))
            output.Append(""" (Run ")
            output.Append(_numberOfRuns.ToString())
            output.Append("): ")
            output.Append(execTime.TotalSeconds.ToString())
            output.Append(" ms.")
        End If

        'output.Append(newLine);
        output.Append(GetEndDelimString())

        _writeStringOutput = output.ToString()
        ' Write the output to the TextWriter specified in the Out poperty.
        _out.WriteLine(output.ToString())

        ' Raise the OnResultsPrinted event.
        OnResultsPrinted(New ExecutionTimerEventArgs(Name))
    End Sub

    ''' <summary>
    ''' Writes the timer's Name, RunCount, LongestRun, ShortestRun, and average execution time
    ''' to the TextWriter specified in the Out property. All times are output in milliseconds.
    ''' </summary>
    Public Sub WriteSeries()
        If _running Then
            Throw New InvalidOperationException("WriteSeries called on a running timer")
        End If

        ' Raise the SeriesResultsPrinting event.
        OnSeriesResultsPrinting(New ExecutionTimerEventArgs(Name))

        Dim newLine As String = Environment.NewLine

        Dim output As New StringBuilder()

        ' Build the output.

        output.Append(GetSeriesBeginDelimString())
        output.Append(newLine)

        If _numberOfRuns = 0 Then
            output.Append(IIf(_name = String.Empty, "<ExecutionTimer>", _name))
            output.Append(""" has not yet completed a run.")
        Else
            output.Append("Stats for """)
            output.Append(IIf(_name = String.Empty, "<ExecutionTimer>", _name))
            output.Append(""":")
            output.Append(newLine)
            output.Append(" - Number of runs completed: ")
            output.Append(_numberOfRuns.ToString())
            output.Append(newLine)
            output.Append(" - Average execution time per run: ")
            output.Append(GetSeriesAverageExecutionTime().TotalMilliseconds.ToString())
            output.Append(" ms.")
            output.Append(newLine)
            output.Append(" - Shortest run: ")
            output.Append(_shortestRun.TotalMilliseconds.ToString())
            output.Append(" ms.")
            output.Append(newLine)
            output.Append(" - Longest run: ")
            output.Append(_longestRun.TotalMilliseconds.ToString())
            output.Append(" ms.")
        End If

        output.Append(newLine)
        output.Append(GetSeriesEndDelimString())

        _out.WriteLine(output.ToString())

        ' Raise the SeriesResultsPrinted event.
        OnSeriesResultsPrinted(New ExecutionTimerEventArgs(Name))
    End Sub

    ''' <summary>
    ''' Overrides object.ToString
    ''' </summary>
    ''' <returns>string</returns>
    Public Overloads Overrides Function ToString() As String
        Return "ExecutionTimer: <" & _name & ">"
    End Function

#End Region

#Region "Public Static Methods"

    ''' <summary>
    ''' This method exists to facilitate this class' use in the
    ''' C# 'using' statement.
    ''' </summary>
    ''' <param name="description">Description of the timer to be printed.</param>
    ''' <returns>IDisposable</returns>
    Public Shared Function TimeBlock(ByVal description As String) As IDisposable
        Dim timer As New ExecutionTimer(description)

        timer.AutoTrace = True

        timer.Start(False)

        Return TryCast(timer, IDisposable)
    End Function

#End Region

#Region "Private Helper Methods"

    ' Returns a string retrieved either from the delegate contained
    ' in the BeginPrintString property or string contained in the
    ' BeginDelim property if no delegate is specified.
    Private Function GetBeginDelimString() As String
        If _beginPrintString IsNot Nothing Then
            Return DirectCast(_beginPrintString.GetInvocationList()(0).DynamicInvoke(New Object() {Name}), String)
        Else
            Return _beginDelim
        End If
    End Function

    ' Returns a string retrieved either from the delegate contained
    ' in the SeriesBeginPrintString property or string contained in the
    ' SeriesBeginDelim property if no delegate is specified.
    Private Function GetSeriesBeginDelimString() As String
        If _seriesBeginPrintString IsNot Nothing Then
            Return DirectCast(_seriesBeginPrintString.GetInvocationList()(0).DynamicInvoke(New Object() {Name}), String)
        Else
            Return _seriesBeginDelim
        End If
    End Function

    ' Returns a string retrieved either from the delegate contained
    ' in the EndPrintString property or string contained in the
    ' EndDelim property if no delegate is specified.
    Private Function GetEndDelimString() As String
        If _endPrintString IsNot Nothing Then
            Return DirectCast(_endPrintString.GetInvocationList()(0).DynamicInvoke(New Object() {Name}), String)
        Else
            Return _endDelim
        End If
    End Function

    ' Returns a string retrieved either from the delegate contained
    ' in the SeriesEndPrintString property or string contained in the
    ' SeriesEndDelim property if no delegate is specified.
    Private Function GetSeriesEndDelimString() As String
        If _seriesEndPrintString IsNot Nothing Then
            Return DirectCast(_seriesEndPrintString.GetInvocationList()(0).DynamicInvoke(New Object() {Name}), String)
        Else
            Return _seriesEndDelim
        End If
    End Function

#End Region

#Region "Protected Methods"

    ''' <summary>
    ''' Raises the TimerStarting event.
    ''' </summary>
    ''' <param name="e"><see cref="ExecutionTimerEventArgs"/> object containing
    ''' the name of the <see cref="ExecutionTimer"/> firing this event.</param>
    Protected Overridable Sub OnTimerStarting(ByVal e As ExecutionTimerEventArgs)
        Dim handler As ExecutionTimerEventHandler

        RaiseEvent TimerStarting(Me, e)

    End Sub

    ''' <summary>
    ''' Raises the TimerStopped event.
    ''' </summary>
    ''' <param name="e"><see cref="ExecutionTimerDetailedEventArgs"/> object containing
    ''' the name of the <see cref="ExecutionTimer"/> firing this event.</param>
    Protected Overridable Sub OnTimerStopped(ByVal e As ExecutionTimerDetailedEventArgs)
        Dim handler As ExecutionTimerStoppedEventHandler

        RaiseEvent TimerStopped(Me, e)

        'frm.Close();
        'myThread.ReportProgress(100);

        ' frm.bw.ReportProgress(100)
    End Sub

    ''' <summary>
    ''' Raises the ResultsPrinting event.
    ''' </summary>
    ''' <param name="e"><see cref="ExecutionTimerEventArgs"/> object containing
    ''' the name of the <see cref="ExecutionTimer"/> firing this event.</param>
    Protected Overridable Sub OnResultsPrinting(ByVal e As ExecutionTimerEventArgs)
        Dim handler As ExecutionTimerEventHandler

        RaiseEvent ResultsPrinting(Me, e)
    End Sub

    ''' <summary>
    ''' Raises the ResultsPrinted event.
    ''' </summary>
    ''' <param name="e"><see cref="ExecutionTimerEventArgs"/> object containing
    ''' the name of the <see cref="ExecutionTimer"/> firing this event.</param>
    Protected Overridable Sub OnResultsPrinted(ByVal e As ExecutionTimerEventArgs)
        Dim handler As ExecutionTimerEventHandler

        RaiseEvent ResultsPrinted(Me, e)
    End Sub

    ''' <summary>
    ''' Raises the SeriesResultsPrinting event.
    ''' </summary>
    ''' <param name="e"><see cref="ExecutionTimerEventArgs"/> object containing
    ''' the name of the <see cref="ExecutionTimer"/> firing this event.</param>
    Protected Overridable Sub OnSeriesResultsPrinting(ByVal e As ExecutionTimerEventArgs)
        Dim handler As ExecutionTimerEventHandler

        RaiseEvent SeriesResultsPrinting(Me, e)
    End Sub

    ''' <summary>
    ''' Raises the SeriesResultsPrinted event.
    ''' </summary>
    ''' <param name="e"><see cref="ExecutionTimerEventArgs"/> object containing
    ''' the name of the <see cref="ExecutionTimer"/> firing this event.</param>
    Protected Overridable Sub OnSeriesResultsPrinted(ByVal e As ExecutionTimerEventArgs)
        Dim handler As ExecutionTimerEventHandler

        RaiseEvent SeriesResultsPrinted(Me, e)
    End Sub

#End Region

#Region "IDisposable Members"
    Public Sub Dispose() Implements System.IDisposable.Dispose
        [Stop](False)
    End Sub
#End Region

    ''' <summary>
    ''' Causes Stop to be called.
    ''' </summary>
    ''' <remarks>Note: This method is not intended to be called from an
    ''' instance of ExecutionTimer, although doing so will not cause any
    ''' harm.</remarks>



End Class

#Region "Delegates"

''' <summary>
''' Represents the method called when output is being written.
''' </summary>
Public Delegate Function PrintString(ByVal timerName As String) As String

''' <summary>
''' Represents the method that handles the <see cref="ExecutionTimer.TimerStarting"/>,
''' <see cref="ExecutionTimer.ResultsPrinting"/>,
''' <see cref="ExecutionTimer.ResultsPrinted"/>, <see cref="ExecutionTimer.SeriesResultsPrinting"/>,
''' <see cref="ExecutionTimer.SeriesResultsPrinted"/> events of an <see cref="ExecutionTimer"/>
''' object.
''' </summary>
Public Delegate Sub ExecutionTimerEventHandler(ByVal sender As Object, ByVal e As ExecutionTimerEventArgs)

''' <summary>
''' Represents the methods that handles the <see cref="ExecutionTimer.TimerStopped"/>
''' event of a <see cref="ExecutionTimer"/> object.
''' </summary>
Public Delegate Sub ExecutionTimerStoppedEventHandler(ByVal sender As Object, ByVal e As ExecutionTimerDetailedEventArgs)

#End Region

#Region "EventArgs-derived classes"


''' <summary>
''' Provides data for the <see cref="ExecutionTimer.TimerStarting"/>
''' , <see cref="ExecutionTimer.ResultsPrinting"/>, <see cref="ExecutionTimer.ResultsPrinted"/>,
''' <see cref="ExecutionTimer.SeriesResultsPrinting"/>, <see cref="ExecutionTimer.SeriesResultsPrinted"/>
''' events.
''' </summary>
Public Class ExecutionTimerEventArgs
    Inherits EventArgs
    Private _timerName As String

    ''' <summary>
    ''' Initializes a new instance of the ExecutionTimerEventArgs class.
    ''' </summary>
    ''' <param name="timerName">The name of the <see cref="ExecutionTimer"/> that
    ''' fired this event.</param>
    Public Sub New(ByVal timerName As String)
        _timerName = timerName
    End Sub

    ''' <summary>
    ''' Gets the name of the <see cref="ExecutionTimer"/> that fired this event.
    ''' </summary>
    Public ReadOnly Property TimerName() As String
        Get
            Return _timerName
        End Get
    End Property
End Class

''' <summary>
''' Provides data for the <see cref="ExecutionTimer.TimerStopped"/> event.
''' </summary>
Public Class ExecutionTimerDetailedEventArgs
    Inherits ExecutionTimerEventArgs
    Private _thisRun As TimeSpan
    Private _totalSeries As TimeSpan
    Private _shortestRun As TimeSpan
    Private _longestRun As TimeSpan
    Private _runCount As Integer

    ''' <summary>
    ''' Initializes a new instance of the <see cref="ExecutionTimerDetailedEventArgs"/>
    ''' class with the specified timer name and run information.
    ''' </summary>
    ''' <param name="timerName">The name of the <see cref="ExecutionTimer"/>
    ''' that fired this event.</param>
    ''' <param name="thisRun">The execution time for this run.</param>
    ''' <param name="runCount">The total number of runs in the series.</param>
    ''' <param name="totalSeries">The total execution time for the series.</param>
    ''' <param name="shortestRun">The execution time for the shortest run in the series.</param>
    ''' <param name="longestRun">The execution time for the longest run in the series.</param>
    Public Sub New(ByVal timerName As String, ByVal thisRun As TimeSpan, ByVal runCount As Integer, ByVal totalSeries As TimeSpan, ByVal shortestRun As TimeSpan, ByVal longestRun As TimeSpan)
        MyBase.New(timerName)
        _thisRun = thisRun
        _runCount = runCount
        _totalSeries = totalSeries
        _shortestRun = shortestRun
        _longestRun = longestRun
    End Sub

    ''' <summary>
    ''' Get the execution time for this run.
    ''' </summary>
    Public ReadOnly Property ThisRun() As TimeSpan
        Get
            Return _thisRun
        End Get
    End Property

    ''' <summary>
    ''' Gets the execution time for the entire series.
    ''' </summary>
    Public ReadOnly Property TotalSeries() As TimeSpan
        Get
            Return _totalSeries
        End Get
    End Property

    ''' <summary>
    ''' Gets the execution time for the shortest run in the series.
    ''' </summary>
    Public ReadOnly Property ShortestRun() As TimeSpan
        Get
            Return _shortestRun
        End Get
    End Property

    ''' <summary>
    ''' Gets the execution time for the longest run in the series.
    ''' </summary>
    Public ReadOnly Property LongestRun() As TimeSpan
        Get
            Return _longestRun
        End Get
    End Property

    ''' <summary>
    ''' Getst the number of runs executed in this series.
    ''' </summary>
    Public ReadOnly Property RunCount() As Integer
        Get
            Return RunCount
        End Get
    End Property
End Class


#End Region




Public Class TimedMethod
    Private _method As [Delegate]
    Private _setUp As [Delegate]
    Private _tearDown As [Delegate]
    Private _args As Object()
    Private _setUpArgs As Object()
    Private _tearDownArgs As Object()
    Private _iterations As Integer
    Private _displayName As String

    ''' <summary>
    ''' Initializes a new instance of the <see cref="TimedMethod"/> class.
    ''' </summary>
    Public Sub New()
        _method = Nothing
        _setUp = Nothing
        _tearDown = Nothing
        _args = Nothing
        _setUpArgs = Nothing
        _tearDownArgs = Nothing
        _iterations = 0
        _displayName = String.Empty
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the <see cref="TimedMethod"/> class with the
    ''' specified method.
    ''' </summary>
    ''' <param name="method">The main method to be timed.</param>
    Public Sub New(ByVal method As [Delegate])
        Me.New()
        _method = method
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the <see cref="TimedMethod"/> class with the
    ''' specified method and iterations.
    ''' </summary>
    ''' <param name="method">The main method to be timed.</param>
    ''' <param name="iterations">The number of iterations to run the method.</param>
    Public Sub New(ByVal method As [Delegate], ByVal iterations As Integer)
        Me.New(method)
        _iterations = iterations
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the <see cref="TimedMethod"/> class with the
    ''' specified method and arguments.
    ''' </summary>
    ''' <param name="method">The main method to be timed.</param>
    ''' <param name="args"></param>
    Public Sub New(ByVal method As [Delegate], ByVal args As Object())
        Me.New(method)
        _args = args
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the <see cref="TimedMethod"/> class with the
    ''' specified method, arguments, and iterations.
    ''' </summary>
    ''' <param name="method">The main method to be timed.</param>
    ''' <param name="args">The arguemtns to be supplied to the timed method.</param>
    ''' <param name="iterations">The number of iterations to run the method.</param>
    Public Sub New(ByVal method As [Delegate], ByVal args As Object(), ByVal iterations As Integer)
        Me.New(method, iterations)
        _args = args
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the <see cref="TimedMethod"/> class with the
    ''' specified methodm set-up, and tear-down.
    ''' </summary>
    ''' <param name="method">The main method to be timed.</param>
    ''' <param name="setUp"></param>
    ''' <param name="tearDown"></param>
    Public Sub New(ByVal method As [Delegate], ByVal setUp As [Delegate], ByVal tearDown As [Delegate])
        Me.New(method)
        _setUp = setUp
        _tearDown = tearDown
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the <see cref="TimedMethod"/> class with the
    ''' specified method, set-up, teard-down, and iterations.
    ''' </summary>
    ''' <param name="method">The main method to be timed.</param>
    ''' <param name="setUp"></param>
    ''' <param name="tearDown"></param>
    ''' <param name="iterations">The number of iterations to run the method.</param>
    Public Sub New(ByVal method As [Delegate], ByVal setUp As [Delegate], ByVal tearDown As [Delegate], ByVal iterations As Integer)
        Me.New(method, setUp, tearDown)
        _iterations = iterations
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the <see cref="TimedMethod"/> class with the
    ''' specified method, arguments, set-up, set-up arguments, tear-down,
    ''' and tear-down arguments.
    ''' </summary>
    ''' <param name="method">The main method to be timed.</param>
    ''' <param name="args">The arguemtns to be supplied to the timed method.</param>
    ''' <param name="setUp">The method to be run before the method being timed.</param>
    ''' <param name="setUpArgs">The arguemtns to be supplied to the set-up method.</param>
    ''' <param name="tearDown">The method to be run after the method being timed.</param>
    ''' <param name="tearDownArgs">The arguemtns to be supplied to the tear-down method.</param>
    Public Sub New(ByVal method As [Delegate], ByVal args As Object(), ByVal setUp As [Delegate], ByVal setUpArgs As Object(), ByVal tearDown As [Delegate], ByVal tearDownArgs As Object())
        Me.New(method, setUp, tearDown)
        _args = args
        _setUpArgs = setUpArgs
        _tearDownArgs = tearDownArgs
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the <see cref="TimedMethod"/> class with the
    ''' specified method, arguments, set-up, set-up arguments, tear-down,
    ''' tear-down arguments, and iterations.
    ''' </summary>
    ''' <param name="method">The main method to be timed.</param>
    ''' <param name="args">The arguemtns to be supplied to the timed method.</param>
    ''' <param name="setUp">The method to be run before the method being timed.</param>
    ''' <param name="setUpArgs">The arguemtns to be supplied to the set-up method.</param>
    ''' <param name="tearDown">The method to be run after the method being timed.</param>
    ''' <param name="tearDownArgs">The arguemtns to be supplied to the tear-down method.</param>
    ''' <param name="iterations">The number of iterations to run the method.</param>
    Public Sub New(ByVal method As [Delegate], ByVal args As Object(), ByVal setUp As [Delegate], ByVal setUpArgs As Object(), ByVal tearDown As [Delegate], ByVal tearDownArgs As Object(), _
    ByVal iterations As Integer)
        Me.New(method, args, setUp, setUpArgs, tearDown, tearDownArgs)
        _iterations = iterations
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the <see cref="TimedMethod"/> class with the
    ''' specified display name and method.
    ''' </summary>
    ''' <param name="displayName">The name to be used when displaying execution results.</param>
    ''' <param name="method">The main method to be timed.</param>
    Public Sub New(ByVal displayName As String, ByVal method As [Delegate])
        Me.New(method)
        _displayName = displayName
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the <see cref="TimedMethod"/> class with the
    ''' specified display name, method, and iterations.
    ''' </summary>
    ''' <param name="displayName">The name to be used when displaying execution results.</param>
    ''' <param name="method">The main method to be timed.</param>
    ''' <param name="iterations">The number of iterations to run the method.</param>
    Public Sub New(ByVal displayName As String, ByVal method As [Delegate], ByVal iterations As Integer)
        Me.New(method, iterations)
        _displayName = displayName
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the <see cref="TimedMethod"/> class with the
    ''' specified display name, method, arguments.
    ''' </summary>
    ''' <param name="displayName">The name to be used when displaying execution results.</param>
    ''' <param name="method">The main method to be timed.</param>
    ''' <param name="args">The arguemtns to be supplied to the timed method.</param>
    Public Sub New(ByVal displayName As String, ByVal method As [Delegate], ByVal args As Object())
        Me.New(method, args)
        _displayName = displayName
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the <see cref="TimedMethod"/> class with the
    ''' specified display name, method, arguments, and iterations.
    ''' </summary>
    ''' <param name="displayName">The name to be used when displaying execution results.</param>
    ''' <param name="method">The main method to be timed.</param>
    ''' <param name="args">The arguemtns to be supplied to the timed method.</param>
    ''' <param name="iterations">The number of iterations to run the method.</param>
    Public Sub New(ByVal displayName As String, ByVal method As [Delegate], ByVal args As Object(), ByVal iterations As Integer)
        Me.New(method, args, iterations)
        _displayName = displayName
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the <see cref="TimedMethod"/> class with the
    ''' specified display name, method, set-up, and tear-down.
    ''' </summary>
    ''' <param name="displayName">The name to be used when displaying execution results.</param>
    ''' <param name="method">The main method to be timed.</param>
    ''' <param name="setUp">The method to be run before the method being timed.</param>
    ''' <param name="tearDown">The method to be run after the method being timed.</param>
    Public Sub New(ByVal displayName As String, ByVal method As [Delegate], ByVal setUp As [Delegate], ByVal tearDown As [Delegate])
        Me.New(method, setUp, tearDown)
        _displayName = displayName
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the <see cref="TimedMethod"/> class with the
    ''' specified display name, method, set-up, tear-down, and iterations.
    ''' </summary>
    ''' <param name="displayName">The name to be used when displaying execution results.</param>
    ''' <param name="method">The main method to be timed.</param>
    ''' <param name="setUp">The method to be run before the method being timed.</param>
    ''' <param name="tearDown">The method to be run after the method being timed.</param>
    ''' <param name="iterations">The number of iterations to run the method.</param>
    Public Sub New(ByVal displayName As String, ByVal method As [Delegate], ByVal setUp As [Delegate], ByVal tearDown As [Delegate], ByVal iterations As Integer)
        Me.New(method, setUp, tearDown, iterations)
        _displayName = displayName
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the <see cref="TimedMethod"/> class with the
    ''' specified display name, method, arguments, set-up, set-up arguments, tear-down,
    ''' and tear-down arguments.
    ''' </summary>
    ''' <param name="displayName">The name to be used when displaying execution results.</param>
    ''' <param name="method">The main method to be timed.</param>
    ''' <param name="args">The arguemtns to be supplied to the timed method.</param>
    ''' <param name="setUp">The method to be run before the method being timed.</param>
    ''' <param name="setUpArgs">The arguemtns to be supplied to the set-up method.</param>
    ''' <param name="tearDown">The method to be run after the method being timed.</param>
    ''' <param name="tearDownArgs">The arguemtns to be supplied to the tear-down method.</param>
    Public Sub New(ByVal displayName As String, ByVal method As [Delegate], ByVal args As Object(), ByVal setUp As [Delegate], ByVal setUpArgs As Object(), ByVal tearDown As [Delegate], _
    ByVal tearDownArgs As Object())
        Me.New(method, args, setUp, setUpArgs, tearDown, tearDownArgs)
        _displayName = displayName
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the <see cref="TimedMethod"/> class with the
    ''' specified display name, method, arguments, set-up, set-up arguments, tear-down,
    ''' tear-down arguments, and iterations.
    ''' </summary>
    ''' <param name="displayName">The name to be used when displaying execution results.</param>
    ''' <param name="method">The main method to be timed.</param>
    ''' <param name="args">The arguemtns to be supplied to the timed method.</param>
    ''' <param name="setUp">The method to be run before the method being timed.</param>
    ''' <param name="setUpArgs">The arguemtns to be supplied to the set-up method.</param>
    ''' <param name="tearDown">The method to be run after the method being timed.</param>
    ''' <param name="tearDownArgs">The arguemtns to be supplied to the tear-down method.</param>
    ''' <param name="iterations">The number of iterations to run the method.</param>
    Public Sub New(ByVal displayName As String, ByVal method As [Delegate], ByVal args As Object(), ByVal setUp As [Delegate], ByVal setUpArgs As Object(), ByVal tearDown As [Delegate], _
    ByVal tearDownArgs As Object(), ByVal iterations As Integer)
        Me.New(method, args, setUp, setUpArgs, tearDown, tearDownArgs, _
        iterations)
        _displayName = displayName
    End Sub

    ''' <summary>
    ''' Gets or sets the arguments to be passed to the timed delegate
    ''' </summary>
    Public Property Args() As Object()
        Get
            Return _args
        End Get
        Set(ByVal value As Object())
            _args = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the arguments to be passed to the set-up delegate
    ''' </summary>
    Public Property SetUpArgs() As Object()
        Get
            Return _setUpArgs
        End Get
        Set(ByVal value As Object())
            _setUpArgs = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the arguments to be passed to the tear-down delegate
    ''' </summary>
    Public Property TearDownArgs() As Object()
        Get
            Return _tearDownArgs
        End Get
        Set(ByVal value As Object())
            _tearDownArgs = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the delegate targeting the main method to be timed when RunTimedMethod is called.
    ''' </summary>
    ''' <remarks>If this delegate targets more then one method, only the first will be called.</remarks>
    Public Property Method() As [Delegate]
        Get
            Return _method
        End Get
        Set(ByVal value As [Delegate])
            _method = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the delegate targeting the method run before each iteration of the timed method
    ''' when RunTimedMethod is called. Execution time for this delegate is not included in the
    ''' run.
    ''' </summary>
    ''' <remarks>If this delegate targets more then one method, only the first will be called.</remarks>
    Public Property SetUp() As [Delegate]
        Get
            Return _setUp
        End Get
        Set(ByVal value As [Delegate])
            _setUp = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the delegate targeting the method run after each iteration of the timed method
    ''' when RunTimedMethod is called. Execution time for this delegate is not included in the
    ''' run.
    ''' </summary>
    ''' <remarks>If this delegate targets more then one method, only the first will be called.</remarks>
    Public Property TearDown() As [Delegate]
        Get
            Return _tearDown
        End Get
        Set(ByVal value As [Delegate])
            _tearDown = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the number of times the method targeted by
    ''' the Method property should be executed.
    ''' </summary>
    Public Property Iterations() As Integer
        Get
            Return _iterations
        End Get
        Set(ByVal value As Integer)
            _iterations = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the name to be displayed when the
    ''' method execution statistics are displayed.
    ''' </summary>
    Public Property DisplayName() As String
        Get
            Return _displayName
        End Get
        Set(ByVal value As String)
            _displayName = value
        End Set
    End Property
End Class




''' <summary>
''' The exception thrown when a series could not be run for a specific <see cref="TimedMethod"/> object.
''' </summary>
<Serializable()> _
Public NotInheritable Class SeriesAbortedException
    Inherits ApplicationException
    Implements ISerializable
    Private _seriesName As String = String.Empty

    ''' <summary>
    ''' Initializes a new instance of the <see cref="SeriesAbortedException"/> class.
    ''' </summary>
    Public Sub New()
        MyBase.New()
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the <see cref="SeriesAbortedException"/> class
    ''' with the specified message.
    ''' </summary>
    ''' <param name="message">The message explaining why the series was aborted.</param>
    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the <see cref="SeriesAbortedException"/> class
    ''' with the specified message and inner exception.
    ''' </summary>
    ''' <param name="message">The message explaining why the series was aborted.</param>
    ''' <param name="innerException">The exception that caused this exception.</param>
    Public Sub New(ByVal message As String, ByVal innerException As Exception)
        MyBase.New(message, innerException)
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the <see cref="SeriesAbortedException"/> class
    ''' with the specified message and series name.
    ''' </summary>
    ''' <param name="message">The message explaining why the series was aborted.</param>
    ''' <param name="seriesName">The name of the series being aborted.</param>
    Public Sub New(ByVal message As String, ByVal seriesName As String)
        Me.New(message, seriesName, Nothing)
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the <see cref="SeriesAbortedException"/> class
    ''' with the specified message, series name, and inner exception.
    ''' </summary>
    ''' <param name="message">The message explaining why the series was aborted.</param>
    ''' <param name="seriesName">The name of the series being aborted.</param>
    ''' <param name="innerException">The exception that caused this exception.</param>
    Public Sub New(ByVal message As String, ByVal seriesName As String, ByVal innerException As Exception)
        MyBase.New(message, innerException)
        _seriesName = seriesName
    End Sub


    ' Constructor needed for deserialization.
    Private Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        MyBase.New(info, context)
        _seriesName = info.GetString("SeriesName")
    End Sub

    ''' <summary>
    ''' Gets the name of the series being aborted.
    ''' </summary>
    Public ReadOnly Property SeriesName() As String
        Get
            Return _seriesName
        End Get
    End Property

#Region "ISerializable Members"
    ''' <summary>
    ''' Implements the <see cref="ISerializable"/> interface and sets the
    ''' data needed to serialize the <see cref="NameExistsException"/> object.
    ''' </summary>
    ''' <param name="info">A <see cref="SerializationInfo"/> object that contains the
    ''' information required to serialize the <see cref="SeriesAbortedException"/> instance.
    ''' </param>
    ''' <param name="context">A <see cref="StreamingContext"/> object that
    ''' contains the source and destination of the serialized stream
    ''' associated with the <see cref="SeriesAbortedException"/> instance.</param>
    Public Overloads Overrides Sub GetObjectData(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        info.AddValue("SeriesName", _seriesName, GetType(String))

        MyBase.GetObjectData(info, context)
    End Sub
#End Region


End Class









