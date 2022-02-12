Imports System
Imports System.Data.OleDb
Imports System.Configuration
Imports System.Data.OracleClient
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
'Imports SecmanUtil2
'Imports IAORDP2
Imports System.Globalization
Imports System.Drawing
Imports System.Security.Cryptography
Imports System.Data.Odbc
Imports XmlHelper
Imports System.Collections.Generic
Imports C1.C1Excel
Imports System.IO

Public Class Win32
    Public Declare Auto Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)
    Public Declare Ansi Function SetWindowLong Lib "user32" Alias "SetWindowLongA" (ByVal hwnd As Integer, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer
    Public Declare Ansi Function SetForegroundWindow Lib "user32" (ByVal hwnd As Integer) As Integer
    Public Declare Function DestroyWindow Lib "user32" Alias "DestroyWindow" (ByVal hwnd As Long) As Long
    Public Declare Function ShowWindow Lib "user32" (ByVal hWnd As IntPtr, ByVal nCmdShow As Integer) As Integer

    <DllImport("user32.dll")> _
    Private Shared Function EnumChildWindows(ByVal WindowHandle As IntPtr, ByVal CallBack As EnumWindowProcess, _
    ByVal IParam As IntPtr) As Boolean
    End Function

    Public Delegate Function EnumWindowProcess(ByVal Handle As IntPtr, ByVal Parameter As IntPtr) As Boolean

    Public Shared Function GetChildWindows(ByVal ParentHandle As IntPtr) As IntPtr()
        Dim ChildrenList As New List(Of IntPtr)
        Dim ListHandle As GCHandle = GCHandle.Alloc(ChildrenList)
        Try
            EnumChildWindows(ParentHandle, AddressOf EnumWindow, GCHandle.ToIntPtr(ListHandle))
        Finally
            If ListHandle.IsAllocated Then ListHandle.Free()
        End Try
        Return ChildrenList.ToArray
    End Function

    Private Shared Function EnumWindow(ByVal Handle As IntPtr, ByVal Parameter As IntPtr) As Boolean
        Dim ChildrenList As List(Of IntPtr) = GCHandle.FromIntPtr(Parameter).Target
        If ChildrenList Is Nothing Then Throw New Exception
        ChildrenList.Add(Handle)
        Return True
    End Function

    'API CONSTANT
    Public Const GWL_HWNDPARENT As Integer = (-8)
    Public Const SW_MAXIMIZE As Integer = 3
    Public Const SW_RESTORE As Integer = 9
    Public Const SW_NORMAL As Integer = 1
    Public Const SW_SHOW As Integer = 5
    Public Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Public Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer

    '*****************************************************
    '* MIniFile.bas                                      *
    '* By: Maman dan Djainul                             *
    '*****************************************************

    '-------------------------------------------
    'For getting Value from specified *.ini file
    '-------------------------------------------
    Public Shared Function GetIniValue(ByVal IniFile As String, ByVal Section As String, ByVal Key As String) As String
        Dim handler As Integer
        Dim List As String
        '    Dim List

        List = New String(" ", 255)
        GetIniValue = ""
        '    handler = GetPrivateProfileString(Section, Key, "0", List, Len(List), App.Path & "\IniFiles\" & IniFile)'APP.path hanya perlu jika path exe = path ini file
        handler = GetPrivateProfileString(Section, Key, " ", List, Len(List), IniFile)
        If handler > 0 Then
            GetIniValue = Left(List, InStr(List, vbNullChar) - 1)
        End If
    End Function

    '---------------------------------------------------------
    'For setting Value from specified *.ini file
    '---------------------------------------------------------
    Public Shared Function SetIniValue(ByVal IniFile As String, ByVal Section As String, ByVal Key As String, ByVal Value As Object) As Integer
        'UPGRADE_WARNING: Couldn't resolve default property of object Value. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        SetIniValue = WritePrivateProfileString(Section, Key, Value, IniFile)
    End Function

    Public Const c_rijndaelkey = "9ae168e5533f318ebf6fc4aa25fa1457d623e8d8a6a43e6992ae4346afa922f4"
    Public Const c_unEditedPassword = "**********"

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class

Public Class Globals
    Public Enum DrawCalonPlgOptions
        OnlyCalonPlg
        CalonPlgAndSambunganCalonPlg
    End Enum

    Public Enum RBMBaru
        plgRBMPerencanaan
        PlgRBMSample
    End Enum

    Public Enum JnsUsulanPlgTgk
        Usulan601
        Usulan603
    End Enum

    Public Enum JnsTracing
        Upstream
        Downstream
    End Enum

    Public Enum JnsPelangganPB
        PelangganSR
        PelangganTR
        PelangganTM
    End Enum

    Public m_DrawCalonPlgOptions As DrawCalonPlgOptions
    Public gForm, gFormDetil As Object
    Public gCubeGI, gCubeGD, gCubeJTM, gCubeJTR, gCubeTTM, gCubeTTR, gCubeUSRTM, gCubeUSRTR As Object
    Public gConnection As OleDbConnection
    Public gSpatialConnection As OleDbConnection
    Public gOraConnection As OracleConnection
    Public gTransaction As OleDbTransaction
    Public PetugasEntry As String
    Public ConnString As String
    Private Shared [global] As Globals
    Public gNoAgenda As String
    Public gDaya As Long
    Public gFlagStopEdit As String
    Public gIsTextualEdited As Boolean = False
    Public gJnsTracing As JnsTracing
    Public dil_Ready, bea_Ready, tgk_Ready As Boolean
    Public gMonKontrak, gPenyambungan, gParentRealisasi As Form
    Public isDrawCalonPelanggan As Boolean = False
    Public IsBuatRencanaRBM As Boolean = False
    Public isGenerateRBM As Boolean = False
    Public gIDPerencanaan As Object
    Public gArrRBM As ArrayList
    Public gIsCreateRBM As Boolean
    Public gIsCreateCalonPlg As Boolean
    Public gRBMBaru As RBMBaru
    'flag utk pelanggan tunggakan
    Public gIsBuatUsulanPlgTgk As Boolean = False
    Public gJnsUsulanPlgTgk As JnsUsulanPlgTgk
    Public gIDUsulanPlgTgk As Object
    'Public gNoAgendaPB As String
    'Public gNoAgendaMultiguna As String
    Public gJenisPelangganPB As JnsPelangganPB
    Public gPosisi As String
    Public gBATASDAYA_AJ As Integer
    Public gUnableStartEdit As Boolean = False
    Public gCurrentActiveWindow As Object
    Public isPJUMeter As Boolean = True
    Public isEntryJenisLampu As Boolean = False
    Public gIsIntegrasiSIMTUL As Boolean = True
    Public gIsIntegrasiPDOB As Boolean = False

    'flag utk insert ke log data suspect
    Public gSQL_INSERT_LOG As String

    Public AppVersions As String = ""

    'variabel untuk menyimpak caption Area/APJ dan Rayon/UPJ
    Public gLabelAPJ As String
    Public gLabelUPJ As String

    'flag enable menu customized mode
    Public gEnableMenuCustomizedMode As Boolean = True

    Public Shared ReadOnly Property Instance() As Globals
        Get
            If [global] Is Nothing Then
                [global] = New Globals
            End If
            Return [global]
        End Get
    End Property

    Private Function GetConnOracle(ByVal ConnString As String) As String
        Dim a As String()
        a = Split(ConnString, ";")
        Dim ConnOracle As String = ""
        For i As Integer = 1 To a.Length - 2
            ConnOracle = ConnOracle & Trim(a(i)) & ";"
        Next
        ConnOracle = ConnOracle.Substring(0, ConnOracle.Length - 1)
        Return ConnOracle
    End Function

    'Public Sub New()
    '    Try
    '        Dim objLog As New IAORDP2.Log
    '        objLog.Login("ADMIN", "MANAGER", "EMAP")
    '        ConnString = objLog.CreateSystemConnection.ConnectionString
    '        Dim ConnOracle As String = GetConnOracle(ConnString)

    '        'Dim ConnOracle As String = System.Configuration.ConfigurationManager.AppSettings.Item("OracleConnection")
    '        'ConnString = System.Configuration.ConfigurationManager.AppSettings.Item("Connection")

    '        'instantiate OLEDB Connection for textual
    '        If gConnection Is Nothing Then
    '            gConnection = New OleDbConnection(ConnString)
    '            If Not gConnection.State = ConnectionState.Open Then
    '                gConnection.Open()
    '            End If
    '        End If

    '        'instantiate OLEDB Connection for spatial
    '        If gSpatialConnection Is Nothing Then
    '            gSpatialConnection = New OleDbConnection(ConnString)
    '            If Not gSpatialConnection.State = ConnectionState.Open Then
    '                gSpatialConnection.Open()
    '            End If
    '        End If

    '        'instantiate Oracle Connection
    '        If gOraConnection Is Nothing Then
    '            gOraConnection = New OracleConnection(ConnOracle)
    '            If Not gOraConnection.State = ConnectionState.Open Then
    '                gOraConnection.Open()
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    'End Sub

    Public Sub New()
        'Try
        '    Dim rdpFiles As String
        '    Dim RJNDAEL As New RIJNDAEL.clsRijndael

        '    rdpFiles = GetConfig("SECMAN")
        '    If rdpFiles = "" Then
        '        AddConfig("SECMAN", "C:\Program Files\IAO\E-Map - All")
        '        rdpFiles = "C:\Program Files\IAO\E-Map - All"
        '    End If
        '    Dim sUSER, sPASS, sDATASOURCE As String

        '    sUSER = Win32.GetIniValue(rdpFiles & "\RDP.ini", "SECMAN", "user")
        '    sPASS = Win32.GetIniValue(rdpFiles & "\RDP.ini", "SECMAN", "password")
        '    sPASS = RJNDAEL.DecryptHexToString(sPASS, Win32.c_rijndaelkey)
        '    sDATASOURCE = Win32.GetIniValue(rdpFiles & "\RDP.ini", "SECMAN", "datasource")

        '    ConnString = "Provider=OraOLEDB.Oracle.1;Password=" & sPASS & ";Persist Security Info=True;User ID=" & sUSER & ";Data Source=" & sDATASOURCE & ""

        '    Dim ConnOracle As String = GetConnOracle(ConnString) & ";Data Source=" & sDATASOURCE

        '    'instantiate OLEDB Connection for textual
        '    If gConnection Is Nothing Then
        '        gConnection = New OleDbConnection(ConnString)
        '        If Not gConnection.State = ConnectionState.Open Then
        '            gConnection.Open()
        '        End If
        '    End If

        '    'instantiate OLEDB Connection for spatial
        '    If gSpatialConnection Is Nothing Then
        '        gSpatialConnection = New OleDbConnection(ConnString)
        '        If Not gSpatialConnection.State = ConnectionState.Open Then
        '            gSpatialConnection.Open()
        '        End If
        '    End If

        '    'instantiate Oracle Connection
        '    If gOraConnection Is Nothing Then
        '        gOraConnection = New OracleConnection(ConnOracle)
        '        If Not gOraConnection.State = ConnectionState.Open Then
        '            gOraConnection.Open()
        '        End If
        '    End If
        'Catch ex As Exception
        '    MsgBox(Globals.GetStackInfo(ex, True), MsgBoxStyle.Exclamation, "Konfirmasi")
        'End Try
    End Sub

    Public Function ExecuteQuery(ByVal SQL As String) As DataTable
        Dim pCommand As OleDbCommand

        If gTransaction Is Nothing Then
            pCommand = New OleDbCommand(SQL, gSpatialConnection)
        Else
            pCommand = New OleDbCommand(SQL, gSpatialConnection, gTransaction)
        End If

        Dim da As New OleDbDataAdapter(pCommand)
        Dim dt As New DataTable
        da.Fill(dt)
        Return dt
    End Function

    Public Function ExecuteQueryScalar(ByVal SQL As String) As String
        Return ExecuteQueryScalar(SQL, gSpatialConnection, gTransaction)
    End Function

    Public Shared Function ExecuteQueryScalar(ByVal SQL As String, ByVal Conn As OleDbConnection, _
                    ByVal pTrans As OleDbTransaction) As String
        Dim pCommand As OleDbCommand
        Try
            If pTrans Is Nothing Then
                pCommand = New OleDbCommand(SQL, Conn)
            Else
                pCommand = New OleDbCommand(SQL, Conn, pTrans)
            End If
            If pCommand.ExecuteScalar() Is Nothing Then
                Return ""
            Else
                Return pCommand.ExecuteScalar().ToString
            End If
        Catch ex As Exception
            ErrorHandler(ex)
        End Try
        Return ""
    End Function

    Public Function ExecuteQuery(ByVal pSQL As String, ByVal pTrans As OleDbTransaction) As Boolean
        Try
            Dim pComand As OleDbCommand
            If pTrans Is Nothing Then
                pComand = New OleDbCommand(pSQL, gSpatialConnection)
            Else
                pComand = New OleDbCommand(pSQL, gSpatialConnection, pTrans)
            End If
            pComand.ExecuteNonQuery()
            pComand.Dispose()
            GlobalClassV2.Globals.Instance.gIsTextualEdited = True
        Catch ed As Exception
            ErrorHandler(ed)
            Return False
        End Try
        Return True
    End Function

    Public Function ExecuteQueryTrans(ByVal pSQL As String, ByVal pTrans As OleDbTransaction) As Boolean
        Try
            Dim pComand As OleDbCommand
            If pTrans Is Nothing Then
                pComand = New OleDbCommand(pSQL, gSpatialConnection)
            Else
                pComand = New OleDbCommand(pSQL, gSpatialConnection, pTrans)
            End If
            pComand.ExecuteNonQuery()
            pComand.Dispose()
            gIsTextualEdited = True
        Catch ed As Exception
            ErrorHandler(ed)
            Return False
        End Try
        Return True
    End Function

    Public Function ExecuteQueryNonError(ByVal pSQL As String, ByVal pTrans As OleDbTransaction) As Boolean
        Try
            Dim pComand As OleDbCommand
            If pTrans Is Nothing Then
                pComand = New OleDbCommand(pSQL, gSpatialConnection)
            Else
                pComand = New OleDbCommand(pSQL, gSpatialConnection, pTrans)
            End If
            pComand.ExecuteNonQuery()
        Catch ex As Exception
            ErrorHandlerNonError(ex)
            Return False
        End Try
        Return True
    End Function

    Public Function ExecuteQueryNonError(ByVal pSQL As String) As Boolean
        Try
            Dim pComand As OleDbCommand
            If gTransaction Is Nothing Then
                pComand = New OleDbCommand(pSQL, gSpatialConnection)
            Else
                pComand = New OleDbCommand(pSQL, gSpatialConnection, gTransaction)
            End If
            pComand.ExecuteNonQuery()
            pComand.Dispose()
        Catch ed As Exception
            ErrorHandlerNonError(ed)
            Return False
        End Try
        Return True
    End Function

    Public Function ExecuteQueryUpdate(ByVal pSQL As String, ByRef pERR As String) As Integer
        Try
            pERR = ""
            Dim pComand As OleDbCommand
            If gTransaction Is Nothing Then
                pComand = New OleDbCommand(pSQL, gSpatialConnection)
            Else
                pComand = New OleDbCommand(pSQL, gSpatialConnection, gTransaction)
            End If
            Return pComand.ExecuteNonQuery()
        Catch ex As Exception
            pERR = Globals.GetStackInfo(ex, True)
            Return -1
        End Try
    End Function

    Public Function ExecuteQuery2(ByVal pSQL As String) As Boolean
        Try
            Dim pComand As OleDbCommand
            If gTransaction Is Nothing Then
                pComand = New OleDbCommand(pSQL, gSpatialConnection)
            Else
                pComand = New OleDbCommand(pSQL, gSpatialConnection, gTransaction)
            End If
            pComand.ExecuteNonQuery()
            pComand.Dispose()
        Catch ed As Exception
            ErrorHandler(ed)
            Return False
        End Try
        Return True
    End Function

    Public Function ExecuteQuery2(ByVal pSQL As String, ByVal pPakeMsg As Boolean) As Boolean
        Try
            Dim pComand As OleDbCommand
            If gTransaction Is Nothing Then
                pComand = New OleDbCommand(pSQL, gSpatialConnection)
            Else
                pComand = New OleDbCommand(pSQL, gSpatialConnection, gTransaction)
            End If
            pComand.ExecuteNonQuery()
            pComand.Dispose()
        Catch ed As Exception
            If pPakeMsg Then
                ErrorHandler(ed)
            Else
                ErrorHandlerNonError(ed)
            End If
            Return False
        End Try
        Return True
    End Function

    Public Function ExecuteQueryMessage(ByVal pSQL As String, ByRef pMessage As String) As DataTable
        Dim pCommand As OleDbCommand
        Dim dt As New DataTable

        Try
            If gTransaction Is Nothing Then
                pCommand = New OleDbCommand(pSQL, gSpatialConnection)
            Else
                pCommand = New OleDbCommand(pSQL, gSpatialConnection, gTransaction)
            End If

            Dim da As New OleDbDataAdapter(pCommand)
            da.Fill(dt)
        Catch ex As Exception
            pMessage = Globals.GetStackInfo(ex, True)
            Return Nothing
        End Try

        Return dt
    End Function

    Public Function ExecuteQueryWithMessage(ByVal pSQL As String, ByRef pMessage As String) As Boolean
        Try
            Dim pComand As OleDbCommand
            If gTransaction Is Nothing Then
                pComand = New OleDbCommand(pSQL, gSpatialConnection)
            Else
                pComand = New OleDbCommand(pSQL, gSpatialConnection, gTransaction)
            End If
            pComand.ExecuteNonQuery()
            pComand.Dispose()
        Catch ed As Exception
            pMessage = ed.Message
            Return False
        End Try

        Return True
    End Function

    Public Function ExecuteQueryImports(ByVal pSQL As String, ByRef ErrMsg As String) As Boolean
        Try
            Dim pComand As OleDbCommand
            If gTransaction Is Nothing Then
                pComand = New OleDbCommand(pSQL, gSpatialConnection)
            Else
                pComand = New OleDbCommand(pSQL, gSpatialConnection, gTransaction)
            End If
            pComand.ExecuteNonQuery()
            pComand.Dispose()
        Catch ed As Exception
            ErrMsg = ed.Message
            Return False
        End Try
        Return True
    End Function


    Public Function ExecuteQueryOracle(ByVal SQL As String) As DataTable
        'Dim pCommand As OracleCommand

        'pCommand = New OracleCommand(SQL, gOraConnection)

        'Dim da As New OracleDataAdapter(pCommand)
        'Dim dt As New DataTable
        'da.Fill(dt)
        Return ExecuteQuery(SQL)
    End Function

    Public Function ExecuteQuery3(ByVal pSQL As String) As Object
        Dim pComand As OleDbCommand
        pComand = New OleDbCommand(pSQL, Globals.Instance.gSpatialConnection)
        pComand.ExecuteNonQuery()
        pComand.Dispose()

        Return Nothing
    End Function

    Public Function ExecuteQueryOracle2(ByVal SQL As String) As Boolean
        'Try
        '    Dim pComand As OracleCommand
        '    pComand = New OracleCommand(SQL, gOraConnection)
        '    pComand.ExecuteNonQuery()
        'Catch ed As Exception
        '    ErrorHandler(ed)
        '    Return False
        'End Try
        Return ExecuteQuery2(SQL)
    End Function

    'Public Sub RollbackTransaction()
    '    gTransaction.Rollback()
    '    gTransaction = Nothing
    'End Sub

    'Public Sub CommitTransaction()
    '    gTransaction.Commit()
    '    gTransaction = Nothing
    'End Sub

    Private Shared Sub ErrorHandler(ByVal ed As Exception)
        If InStr(ed.Message, "ORA-01400") > 0 Then
            MessageBox.Show("Entrian tidak lengkap. Periksa kembali hasil isian Anda." & vbCrLf & ed.Message, "Konfirmasi")
        ElseIf InStr(ed.Message, "ORA-00001") > 0 Then
            MessageBox.Show("ID record telah ada. Gunakan kode yang lainnya." & vbCrLf & ed.Message, "Konfirmasi")
        ElseIf InStr(ed.Message, "ORA-02292") > 0 Then
            MessageBox.Show("Record tidak bisa dihapus karena masih digunakan oleh data lainnya." & vbCrLf & ed.Message, "Konfirmasi")
        Else
            MessageBox.Show(Globals.GetStackInfo(ed, True), "Konfirmasi")
        End If
    End Sub

    Private Sub ErrorHandlerNonError(ByVal ed As Exception)
        WriteLogProcess(Globals.GetStackInfo(ed, True), False)
    End Sub

    Public Function ValForCSharp(ByVal pValue As String) As Double
        Return Val(pValue)
    End Function

    Public Function SplitForCSharp(ByVal pValue As String, ByVal pDelimiter As String) As ArrayList
        Dim pTemp() As String = Split(pValue, pDelimiter)
        Dim pArrayList As New ArrayList

        For i As Integer = 0 To pTemp.Length - 1
            pArrayList.Add(pTemp(i))
        Next

        Return pArrayList
    End Function

    Public Function GetPrefixTableByIDValue(ByVal pIDValue As Object) As String
        Dim pStrIDValue As String
        Dim pFirstDigit As Int16

        'Format ID adalah 15 digit
        pStrIDValue = Format(Val(CheckNull(pIDValue)), "000000000000000")
        pFirstDigit = Convert.ToInt16(pStrIDValue.Trim.Substring(0, 1))

        Select Case pFirstDigit
            Case 0 To 3
                Return "A"
            Case 4 To 6
                Return "R"
            Case 7 To 9
                Return "L"
        End Select
    End Function

    Public Function CekKonfigurasiEntri(ByVal ConfigCode As String) As String
        Dim SQL As String
        SQL = " SELECT NVL(TRIM(VALUE),' ') AS VALUE FROM APP_CONFIG "
        SQL = SQL & " where CONFIG_CODE = '" & ConfigCode & "' "
        Dim dt As DataTable
        dt = ExecuteQuery(SQL)
        If dt.Rows.Count > 0 Then
            Return Trim(dt.Rows(0)(0))
        End If
        Return String.Empty
    End Function

    Public Function SubstringForCSharp(ByVal pValue As String, ByVal pStart As Integer, ByVal pLength As Integer) As String
        Return Mid(pValue, pStart, pLength)
    End Function

    Public Function isPelByRectangle() As Boolean
        Dim SQL, pValue As String
        SQL = "select VALUE from APP_CONFIG where CONFIG_CODE = 'PemilihanPelanggan' "
        Dim dt As DataTable
        dt = ExecuteQuery(SQL)
        pValue = Trim(dt.Rows(0)(0))
        If pValue = "Rectangle" Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function GiveNullAValue(ByVal value As Object) As Object
        If IsDBNull(value) Then Return "" Else Return value
    End Function

    Public Shared Function GiveNothingAValue(ByVal value As Object) As Object
        If value Is Nothing Then
            Return ""
        Else
            Return GiveNullAValue(value)
        End If
    End Function

    Public Function CheckNull(ByVal pValue As Object) As Object
        If pValue Is DBNull.Value Then
            CheckNull = ""
        Else
            CheckNull = pValue
        End If
    End Function

    Public Function CheckNullTrim(ByVal pValue As Object) As String
        Return Trim(CheckNull(pValue))
    End Function

    Public Function CheckNullInt(ByVal pValue As Object) As Long
        If pValue Is DBNull.Value Then
            CheckNullInt = 0
        Else
            CheckNullInt = Val(pValue)
        End If
    End Function

    Public Function CheckNullNum(ByVal pValue As Object) As Double
        If pValue Is DBNull.Value Then
            CheckNullNum = 0
        Else
            CheckNullNum = Val(pValue)
        End If
    End Function

    Public Function CheckNullDouble(ByVal pValue As Object) As String
        If pValue Is DBNull.Value Then
            CheckNullDouble = 0
        ElseIf pValue Is Nothing Then
            CheckNullDouble = 0
        Else
            CheckNullDouble = Val(pValue)
        End If
    End Function

    Public Enum JenisObjek
        Perencanaan
        BlokRencana
        BlokRealisasi
        Realisasi
        RencanaManuver
    End Enum

    Public Function GetMaxValueID(ByVal TableName As String, ByVal PrimaryField As String, _
                    Optional ByVal StartValue As String = "1") As String
        Dim SQL As String
        SQL = "  select NVL(MAX(" & PrimaryField & "),0) + 1 + TRIM(to_char(sysdate, 'hh24miss')) Ms"
        SQL = SQL & "  from " & TableName

        Dim dt As New DataTable
        dt = GlobalClassV2.Globals.Instance.ExecuteQuery(SQL)
        Dim pID As Long = Convert.ToInt64(dt.Rows(0)("Ms")) + Now.Millisecond

        Return pID.ToString
    End Function

    Public Function GenerateIDTekstual(ByVal pJenisObyek As JenisObjek) As String
        Dim pTable As String = ""
        Dim pIDColumn As String = ""

        Select Case pJenisObyek
            Case JenisObjek.Perencanaan
                pTable = "REN_JAR" : pIDColumn = "ID_RENCANA"
            Case JenisObjek.BlokRencana
                pTable = "BLOK_GBRRENCANA" : pIDColumn = "ID_BLOKGBR"
            Case JenisObjek.BlokRealisasi
                pTable = "BLOK_GBRREALISASI" : pIDColumn = "ID_BLOKGBR_REALISASI"
            Case JenisObjek.Realisasi
                pTable = "REALISASI_RENCANA" : pIDColumn = "ID_REALISASI_RENCANA"
            Case JenisObjek.RencanaManuver
                pTable = "RENCANA_MANUVER" : pIDColumn = "ID_RENMANUVER"

        End Select

        Dim SQL As String
        SQL = "  select NVL(MAX(" & pIDColumn & "),0) + 1 + TRIM(to_char(sysdate, 'hh24miss')) Ms"
        SQL = SQL & "  from " & pTable

        Dim dt As New DataTable
        dt = GlobalClassV2.Globals.Instance.ExecuteQuery(SQL)
        Dim pID As Long = Convert.ToInt64(dt.Rows(0)("Ms")) + Now.Millisecond

        Return pID.ToString
    End Function

    Public Function GenerateID(ByVal pTable As String, ByVal pIDColumn As String) As String
        Dim SQL As String
        SQL = "  select NVL(MAX(" & pIDColumn & "),0) + 1 + TRIM(to_char(sysdate, 'hh24miss')) Ms"
        SQL = SQL & "  from " & pTable

        Dim dt As New DataTable
        dt = GlobalClassV2.Globals.Instance.ExecuteQuery(SQL)
        Dim pID As Long = Convert.ToInt64(dt.Rows(0)("Ms")) + Now.Millisecond

        Return pID.ToString
    End Function

    Public Function GeteMapVersion() As String
        Dim SQL As String
        SQL = "  select Versi From EMAP_VERSIONS"
        Return GlobalClassV2.Globals.Instance.ExecuteQueryScalar(SQL)
    End Function

    Public Function GenerateIDForPKLebihDariSatu(ByVal pTable As String, ByVal pIDColumn As String, _
                                                 ByVal pPK As String, ByVal pPKValue As String) As String
        Dim SQL As String
        SQL = "  select NVL(MAX(" & pIDColumn & "),0) + 1 + TRIM(to_char(sysdate, 'hh24miss')) Ms"
        SQL = SQL & "  from " & pTable
        SQL = SQL & " where " & pPK & "='" & pPKValue & "'"

        Dim dt As New DataTable
        dt = GlobalClassV2.Globals.Instance.ExecuteQuery(SQL)
        Dim pID As Long = Convert.ToInt64(dt.Rows(0)("Ms")) + Now.Millisecond

        Return pID.ToString
    End Function

    Public Shared Function StringToDateTime(ByVal strDate As String) As Date
        If Trim(strDate) = "" Then Return Nothing
        Dim a As Object = Split(strDate.Replace("-", "/"), "/")
        Dim b, c As Object
        c = Trim(a(2)) : b = Trim(a(1)) : a = Trim(a(0))
        Return DateTime.Parse(b & "/" & a & "/" & c)
    End Function

    Public Shared Function StringToDateTime2(ByVal strDate As String) As Date
        If Trim(strDate) = "" Then Return Nothing
        Dim a As Object = Split(strDate, "/")
        Dim b, c As Object
        c = Trim(a(2)) : b = Trim(a(1)) : a = Trim(a(0))
        Return DateTime.Parse(b & "/" & a & "/" & c)
    End Function

    Public Shared Function DbTimeToIndTime(ByVal strDate As String) As String
        If strDate = "" Then Return ""
        Dim a As Object = Split(strDate, "/")
        Dim b, c As Object
        c = Trim(a(2)) : b = Trim(a(1)) : a = Trim(a(0))
        Return b & "-" & a & "-" & c
    End Function

    Public Shared Function GridCaption(ByVal caption As String) As String
        Dim mTextInfo As TextInfo = Threading.Thread.CurrentThread.CurrentCulture.TextInfo
        caption = caption.ToLower
        caption = caption.Replace("_", " ")
        Return mTextInfo.ToTitleCase(caption)
    End Function

    Public Shared Function Encrypt(ByVal strText As String, ByVal strEncrKey As String) As String
        Dim IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
        Try
            Dim bykey() As Byte = System.Text.Encoding.UTF8.GetBytes(Left(strEncrKey, 8))
            Dim InputByteArray() As Byte = System.Text.Encoding.UTF8.GetBytes(strText)
            Dim des As New DESCryptoServiceProvider
            Dim ms As New System.IO.MemoryStream
            Dim cs As New CryptoStream(ms, des.CreateEncryptor(bykey, IV), CryptoStreamMode.Write)
            cs.Write(InputByteArray, 0, InputByteArray.Length)
            cs.FlushFinalBlock()
            Return Convert.ToBase64String(ms.ToArray())
        Catch ex As Exception
            Return Globals.GetStackInfo(ex, True)
        End Try
    End Function

    Public Shared Function Decrypt(ByVal strText As String, ByVal sDecrKey As String) As String
        Dim IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
        Dim inputByteArray(strText.Length) As Byte
        Try
            Dim byKey() As Byte = System.Text.Encoding.UTF8.GetBytes(Left(sDecrKey, 8))
            Dim des As New DESCryptoServiceProvider
            inputByteArray = Convert.FromBase64String(strText)
            Dim ms As New System.IO.MemoryStream
            Dim cs As New CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Dim encoding As System.Text.Encoding = System.Text.Encoding.UTF8
            Return encoding.GetString(ms.ToArray())
        Catch ex As Exception
            'Return ex.Message
        End Try
    End Function

    ' Mendapatkan Nilai dari ArcMap.exe.config
    'Public Function GetConfig(ByVal key As String) As String
    '    Dim ArcMapPath As String
    '    '** get templatefile from database '
    '    Reg.HKey = RegistryClass.ssiHKey.HKEY_LOCAL_MACHINE
    '    Reg.QueryValue("Software\ESRI\ArcGIS", "InstallDir", ArcMapPath)

    '    ArcMapPath = ArcMapPath & "Bin"

    '    Dim m_ConfigHelper As ConfigFileHelper
    '    m_ConfigHelper = New ConfigFileHelper(ArcMapPath & "\ArcMap.exe.config")
    '    'Return m_ConfigHelper.GetAppSetting(pKet)


    '    'Dim m_ConfigHelper As ConfigFileHelper
    '    'm_ConfigHelper = New ConfigFileHelper(Application.StartupPath & "\ArcMap.exe.config")

    '    Try
    '        Return m_ConfigHelper.GetAppSetting(key)
    '    Catch ex As Exception
    '        m_ConfigHelper.AddAppSetting(key, "")
    '        Return ""
    '    End Try
    'End Function

    ' Mendapatkan Nilai dari APP_CONFIG
    Public Function GetAppConfig(ByVal Key As String) As String

        Dim SQL As String

        SQL = "SELECT VALUE FROM APP_CONFIG WHERE ID_APPLICATION = '4' AND CONFIG_CODE = '" & Key & "'"
        Dim dt As DataTable = GlobalClassV2.Globals.Instance.ExecuteQuery(SQL)

        If dt.Rows.Count = 0 Then
            Return ""
        Else
            Return dt.Rows(0)!VALUE.ToString().Trim()
        End If

    End Function

    ' Mendapatkan Nilai dari APP_CONFIG
    Public Function GetAppConfig(ByVal Key As String, ByVal Value As String) As String

        Dim SQL As String

        SQL = "SELECT VALUE FROM APP_CONFIG WHERE ID_APPLICATION = '4' AND CONFIG_CODE = '" & Key & "'"
        Dim dt As DataTable = GlobalClassV2.Globals.Instance.ExecuteQuery(SQL)

        If dt.Rows.Count = 0 Then
            If Value <> "" Then
                SQL = "INSERT INTO APP_CONFIG (ID_APPLICATION, CONFIG_CODE, VALUE) VALUES (4, '" & Key & "', '" & Value & "')"
                GlobalClassV2.Globals.Instance.ExecuteQuery2(SQL)
                Return Value
            Else
                Return ""
            End If
        Else
            Return dt.Rows(0)!VALUE.ToString().Trim()
        End If

    End Function

    ' Mengupdate Nilai dari APP_CONFIG
    Public Function SetAppConfig(ByVal Key As String, ByVal Value As String) As String

        Dim SQL As String

        SQL = "SELECT VALUE FROM APP_CONFIG WHERE ID_APPLICATION = '4' AND CONFIG_CODE = '" & Key & "'"
        Dim dt As DataTable = GlobalClassV2.Globals.Instance.ExecuteQuery(SQL)

        If dt.Rows.Count = 0 Then
            SQL = "INSERT INTO APP_CONFIG (ID_APPLICATION, CONFIG_CODE, VALUE) VALUES (4, '" & key & "', '" & value & "')"
            GlobalClassV2.Globals.Instance.ExecuteQuery2(SQL)
            Return Value
        Else
            SQL = "UPDATE APP_CONFIG SET VALUE='" & Value & "' WHERE ID_APPLICATION = '4' AND CONFIG_CODE='" & Key & "'"
            GlobalClassV2.Globals.Instance.ExecuteQuery2(SQL)
            Return Value
        End If

    End Function

    'Public Function GetConfig(ByVal key As String, ByVal value As String) As String
    '    Dim ArcMapPath As String
    '    '** get templatefile from database '
    '    Reg.HKey = RegistryClass.ssiHKey.HKEY_LOCAL_MACHINE
    '    Reg.QueryValue("Software\ESRI\ArcGIS", "InstallDir", ArcMapPath)

    '    ArcMapPath = ArcMapPath & "Bin"

    '    Dim m_ConfigHelper As ConfigFileHelper
    '    m_ConfigHelper = New ConfigFileHelper(ArcMapPath & "\ArcMap.exe.config")
    '    'Return m_ConfigHelper.GetAppSetting(pKet)


    '    'Dim m_ConfigHelper As ConfigFileHelper
    '    'm_ConfigHelper = New ConfigFileHelper(Application.StartupPath & "\ArcMap.exe.config")

    '    Try
    '        Return m_ConfigHelper.GetAppSetting(key)
    '    Catch ex As Exception
    '        m_ConfigHelper.AddAppSetting(key, value)
    '        Return value
    '    End Try
    'End Function

    ' Mendapatkan Nilai dari ArcMap.exe.config
    Public Sub AddConfig(ByVal key As String, ByVal pVALUE As String)
        Dim m_ConfigHelper As ConfigFileHelper
        m_ConfigHelper = New ConfigFileHelper(Application.StartupPath & "\ArcMap.exe.config")

        Try
            m_ConfigHelper.AddAppSetting(key, pVALUE)
        Catch ex As Exception
            m_ConfigHelper.ChangeAppSetting(key, pVALUE)
        End Try
    End Sub

    Public Function cekDayaAJ(ByVal pDaya As Integer) As Boolean
        If gPosisi = "AJ" Then
            If pDaya <= gBATASDAYA_AJ Then
                MsgBox("Pelanggan dengan daya " & pDaya & " hanya bisa di proses di UJ", MsgBoxStyle.Information)
                Return False
            Else
                Return True
            End If
        ElseIf gPosisi = "AJUJ" Then
            Return True
        Else
            If pDaya > gBATASDAYA_AJ Then
                MsgBox("Pelanggan dengan daya " & pDaya & " hanya bisa di proses di AJ", MsgBoxStyle.Information)
                Return False
            Else
                Return True
            End If
        End If
    End Function

    Public Shared Sub MaximizeArcMap(ByVal id As Integer)
        Try
            Dim p As Process = Process.GetProcessById(id)
            Dim hwnd As IntPtr = p.MainWindowHandle

            Call Win32.ShowWindow(hwnd, Win32.SW_MAXIMIZE)
            Win32.SetForegroundWindow(hwnd)
        Catch ex As Exception
            Console.WriteLine(Globals.GetStackInfo(ex, True))
        End Try
    End Sub

    'Private Shared Reg As New RegistryClass.RegistryClass

    'Public Shared Function ReadConfig(ByVal pKet As String) As String
    '    Return Instance.GetConfig(pKet)

    '    ''Dim ArcMapPath As String
    '    '''** get templatefile from database '
    '    ''Reg.HKey = RegistryClass.ssiHKey.HKEY_LOCAL_MACHINE
    '    ''Reg.QueryValue("Software\ESRI\ArcGIS", "InstallDir", ArcMapPath)

    '    ''ArcMapPath = ArcMapPath & "Bin"

    '    ''Dim m_ConfigHelper As ConfigFileHelper
    '    ''m_ConfigHelper = New ConfigFileHelper(ArcMapPath & "\ArcMap.exe.config")
    '    ''Return m_ConfigHelper.GetAppSetting(pKet)
    'End Function

    Public Sub setLogReport(ByVal pReportText As String)

        Dim pCurrText As String = ""

        'Check if the logfile is exist
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\" & "emap_iao_process.log") = False Then
            Dim file As System.IO.FileStream
            file = System.IO.File.Create(Application.StartupPath & "\" & "emap_iao_process.log")
            file.Close()
        End If

        'Write log message
        'My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\" & "emap_iao_process.log", "log proses " & Format(Now, "yyyyMMdd HH:mm:ss") & vbCrLf, True)

        Dim Hdr As String = Strings.StrDup(50, "-") & vbCrLf
        Hdr = Hdr & "eMAP " & AppVersions.Trim() & " log proses " & DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
        Hdr = Hdr & vbCrLf & Strings.StrDup(50, "-") & vbCrLf
        My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\" & "emap_iao_process.log", Hdr, True)

        If pReportText = "" Then
            My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\" & "emap_iao_process.log", "Sukses" & vbCrLf, True)
        Else
            My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\" & "emap_iao_process.log", pReportText & vbCrLf, True)
        End If

    End Sub

    Function CenterString(ByVal Data As String, ByVal MaxChar As Integer) As String

        Dim PjgCharSisa As Integer

        If Len(Data) > MaxChar Then
            MaxChar = 100
        End If

        PjgCharSisa = GetSisa(Data, MaxChar)
        CenterString = Space$(PjgCharSisa) & Trim$(Data) & Space$(PjgCharSisa)

    End Function

    Private Function GetSisa(ByVal Data As String, ByVal MaxChar As Integer) As Integer

        Dim Pjg As Integer

        Pjg = Len(Trim$(Data))
        GetSisa = Math.Round((MaxChar - Pjg) / 2, 0)

    End Function

    Public Sub StartEditTextual(ByRef isStart As Boolean)
        If Not gTransaction Is Nothing Then
            gTransaction.Commit()
            gTransaction = Nothing
            isStart = True
        Else
            isStart = False
        End If
        gTransaction = gSpatialConnection.BeginTransaction()
    End Sub

    Public Sub StopEditTextual(ByVal isStart As Boolean, ByVal isCommit As Boolean)
        If gTransaction Is Nothing Then Exit Sub
        If isCommit Then
            gTransaction.Commit()
        Else
            gTransaction.Rollback()
        End If
        gTransaction = Nothing

        If gSQL_INSERT_LOG <> "" Then
            ExecuteQuery2(gSQL_INSERT_LOG)
            gSQL_INSERT_LOG = ""
        End If

        If isStart Then
            gTransaction = gSpatialConnection.BeginTransaction()
        End If
    End Sub

    Public Function EncodeDate(ByVal tgl As Object) As String
        Dim strTgl As String
        If tgl Is DBNull.Value Then
            Return "NULL"
        Else
            strTgl = Format(CDate(tgl), "dd/MM/yyyy")
            Return "TO_DATE('" & strTgl & "','DD/MM/YYYY')"
        End If
    End Function

    Public Function EncodeDateTime(ByVal datetime As Object) As String
        Dim strTgl As String
        If datetime Is DBNull.Value Then
            Return "''"
        Else
            strTgl = Format(CDate(datetime), "dd/MM/yyyy HH:mm:ss")
            Return "TO_DATE('" & strTgl & "','DD/MM/YYYY HH24:MI:SS')"
        End If
    End Function

    Public Function CheckNullSpasi(ByVal pValue As Object) As Object
        If pValue Is DBNull.Value Then
            CheckNullSpasi = " "
        ElseIf Trim(pValue) = "" Then
            CheckNullSpasi = " "
        Else
            CheckNullSpasi = Trim(pValue)
        End If
    End Function

    Public Function CheckNullKeterangan(ByVal pValue As Object, ByVal pJnsAgenda As String) As Object
        If pValue Is DBNull.Value Then
            CheckNullKeterangan = ""
        ElseIf Trim(pValue) = "" Then
            CheckNullKeterangan = ""
        Else
            CheckNullKeterangan = Trim(pValue)
        End If
        If CheckNullKeterangan = "" Then
            Select Case pJnsAgenda
                Case 23
                    CheckNullKeterangan = "Permohonan Reposisi APP"
                Case 24
                    CheckNullKeterangan = "Permohonan Tera Meter"
                Case 25
                    CheckNullKeterangan = "Permohonan Geser Tiang"
                Case 26
                    CheckNullKeterangan = "Permohonan Penggantian SR"
                Case 27
                    CheckNullKeterangan = "Permohonan Pemeriksaan APP"
                Case 8
                    CheckNullKeterangan = "Pelayanan Perubahan APP Meter"
                Case 14
                    CheckNullKeterangan = "Perubahan Faktor Kali"
            End Select
        End If
    End Function

    'Public Function GetHeaderCetakPeta() As String
    '    If gPosisi = "AJ" Then
    '        Return "AREA JARINGAN " & GetConfig("NamaAP")
    '    ElseIf GlobalClassV2.Globals.Instance.gPosisi = "AJUJ" Then
    '        Return "AREA JARINGAN " & GetConfig("NamaAP")
    '    Else
    '        Return "UNIT JARINGAN " & GetConfig("NamaAP")
    '    End If
    'End Function

    Public Function ConvertDateTimeSqlServer(ByVal pValue As Object) As Object
        If pValue Is DBNull.Value Then
            ConvertDateTimeSqlServer = "NULL"
        Else
            ConvertDateTimeSqlServer = "CONVERT(DATETIME,'" & Format(pValue, "yyyyMMdd") & "',101)"
        End If
    End Function

    Public Function ConvertArahJurusanKeAbjad(ByVal pValue As Object) As String
        If pValue Is Nothing Then Return "-"
        If pValue Is DBNull.Value Then Return "-"
        Select Case pValue
            Case "U" : ConvertArahJurusanKeAbjad = "A"
            Case "T" : ConvertArahJurusanKeAbjad = "B"
            Case "S" : ConvertArahJurusanKeAbjad = "C"
            Case "B" : ConvertArahJurusanKeAbjad = "D"
        End Select
    End Function

    Public Function getKodePembedaTarifP3(ByVal pValue As Object) As String
        If pValue Is Nothing Then Return "1"
        If pValue Is DBNull.Value Then Return "1"
        Select Case pValue
            Case "2" : getKodePembedaTarifP3 = "2"
            Case "3" : getKodePembedaTarifP3 = "3"
            Case Else : getKodePembedaTarifP3 = "1"
        End Select
    End Function

    Public Function NamaTabelAktifByIDJnsObyek(ByVal IDJnsObyek As String) As String
        Select Case IDJnsObyek
            Case "100"
                Return "AGARDU_INDUK"
            Case "101"
                Return "ATRAFO_GI"
            Case "102" 'KODE_AJ AMBIL DARI GI
                Return "ABUSBAR_GI"
            Case "103"
                Return "AFEEDER"
            Case "104"
                Return "AGARDU_INDUK"
            Case "105"
                Return "AGARDU_DISTRIBUSI"
            Case "106"
                Return "AGARDU_BANGUNAN"
            Case "107"
                Return "AGARDU_HUBUNG"
            Case "108"
                Return "AJURUSAN" 'KODE_AJ AMBIL DARI ATRAFO_GD -> GD
            Case "110"
                Return "ASUTM"
            Case "115"
                Return "ASUTR"
            Case "116"
                Return "ASAMBUNGAN_RUMAH"
            Case "120"
                Return "ATIANG_TM"
            Case "125"
                Return "ATIANG_TR"
            Case "130"
                Return "APELANGGAN_TM"
            Case "140"
                Return "APELANGGAN_TR"
            Case "159"
                Return "ACUBICLE_GI" 'KODE_AJ AMBIL DARI BUSBAR->GI
            Case "295"
                Return "ATRAFO_GD" 'KODE_AJ AMBIL DARI GD
            Case "300"
                Return "ASKTM"
            Case "304"
                Return "ASKTR"
        End Select
    End Function

    'Function GenerateTNS_AMR() As Boolean
    '    Dim sIP_AMR, sSERVICE_AMR As String
    '    sIP_AMR = GlobalClassV2.Globals.Instance.GetAppConfig("IP_AMR", "10.25.0.69")
    '    sSERVICE_AMR = GlobalClassV2.Globals.Instance.GetAppConfig("SERVICE_NAME_AMR", "o10bali2")
    '    Try
    '        'check file ora
    '        Dim path As String
    '        path = ReadOraHome()
    '        If My.Computer.FileSystem.FileExists(path) = False Then
    '            MsgBox("File TnsNames.ora tidak ditemukan!", MsgBoxStyle.Critical)
    '            Return False
    '        End If
    '        Dim ISI As String
    '        ISI = My.Computer.FileSystem.ReadAllText(path)
    '        Dim sFILE As FileStream = New FileStream(path, FileMode.Open, FileAccess.Write)
    '        Dim sSTREAM As StreamWriter = New StreamWriter(sFILE)
    '        If InStr(ISI, "AMR =") < 1 Then
    '            Dim SQL As String
    '            SQL = vbCrLf & "AMR = " & vbCrLf
    '            SQL = SQL & "  (DESCRIPTION = " & vbCrLf
    '            SQL = SQL & "    (ADDRESS_LIST = " & vbCrLf
    '            SQL = SQL & "      (ADDRESS = " & vbCrLf
    '            SQL = SQL & "        (PROTOCOL = TCP) " & vbCrLf
    '            SQL = SQL & "        (HOST = " & sIP_AMR & ") " & vbCrLf
    '            SQL = SQL & "        (PORT = 1521) " & vbCrLf
    '            SQL = SQL & "      ) " & vbCrLf
    '            SQL = SQL & "    ) " & vbCrLf
    '            SQL = SQL & "    (CONNECT_DATA = " & vbCrLf
    '            SQL = SQL & "      (SERVICE_NAME = " & sSERVICE_AMR & ") " & vbCrLf
    '            SQL = SQL & "    ) " & vbCrLf
    '            SQL = SQL & "  ) " & vbCrLf
    '            sSTREAM.BaseStream.Seek(0, SeekOrigin.End)
    '            sSTREAM.WriteLine(SQL)
    '            sSTREAM.Flush()
    '            sSTREAM.Close()
    '        End If
    '        Return True
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function

    'Function ReadOraHome() As String
    '    Dim m_ConfigHelper As ConfigFileHelper
    '    Dim OraPath As String
    '    '** get templatefile from database '
    '    Reg.HKey = RegistryClass.ssiHKey.HKEY_LOCAL_MACHINE
    '    'KEY_OraClient10g_home1
    '    Reg.QueryValue("SOFTWARE\ORACLE\KEY_OraClient10g_home1", "ORACLE_HOME", OraPath)
    '    If CheckNullTrim(OraPath) = "" Then
    '        Reg.QueryValue("SOFTWARE\ORACLE\KEY_OraDb10g_home1", "ORACLE_HOME", OraPath)
    '    End If
    '    OraPath = OraPath & "\network\admin\tnsnames.ora"
    '    Return OraPath
    'End Function

    Public Function GenerateNoGardu(ByVal pNoGardu As Object) As String
        pNoGardu = CheckNull(pNoGardu)
        If pNoGardu.Length > 2 Then
            Dim s1, s2, s3 As String
            s1 = pNoGardu.Substring(0, 2)
            s3 = pNoGardu.Substring(2).Trim
            If s3.Length < 4 Then
                For i As Integer = 1 To 4 - s3.Length
                    s2 &= "0"
                Next
            Else
                s2 = ""
            End If
            Return s1 & s2 & s3
        Else
            Return pNoGardu
        End If
    End Function

    Public Shared Function GetStackInfo(ByVal ex As Exception, ByVal WithCurrentMessage As Boolean) As String
        Dim Trace As System.Diagnostics.StackTrace = New System.Diagnostics.StackTrace(ex, True)
        Dim msg As String = vbCrLf + New String("-", 50)
        For i As Integer = 0 To Trace.FrameCount - 1
            If Trace.GetFrame(i).GetMethod().Name <> "GetStackInfo" _
            And Trace.GetFrame(i).GetMethod().Module.Name <> "System.Data.dll" _
            And Trace.GetFrame(i).GetMethod().Module.Name <> "mscorlib.dll" Then
                msg += vbCrLf + "ModuleName" & vbTab & ": " + Trace.GetFrame(i).GetMethod().Module.Name
                msg += vbCrLf + "MethodName" & vbTab & ": " + Trace.GetFrame(i).GetMethod().Name
                msg += vbCrLf + "LineNumber" & vbTab & ": " + Trace.GetFrame(i).GetFileLineNumber().ToString()
                msg += vbCrLf + "ColumnNumber" & vbTab & ": " + Trace.GetFrame(i).GetFileColumnNumber().ToString() + vbCrLf
                Globals.Instance.WriteLogError(msg + vbCrLf, False)
                msg = ""
            End If
        Next
		
        Globals.Instance.WriteLogError(vbCrLf & "All Info" + vbCrLf + Trace.ToString() + vbCrLf + New String("-", 50) + vbCrLf, False)

        If WithCurrentMessage Then msg = ex.Message + msg 
        Return ex.Message

    End Function


    Public Shared Function GetStackInfo(ByVal ex As Exception, ByVal NewMessage As String) As String
        Dim trace As System.Diagnostics.StackTrace = New System.Diagnostics.StackTrace(ex, True)
        Dim msg As String = "\r\n" + New String("-", 50)
        For i As Integer = 0 To trace.FrameCount - 1
            If trace.GetFrame(i).GetMethod().Name <> "GetStackInfo" _
            And trace.GetFrame(i).GetMethod().Module.Name <> "System.Data.dll" _
            And trace.GetFrame(i).GetMethod().Module.Name <> "mscorlib.dll" Then
                msg += vbCrLf + "ModuleName" & vbTab & ": " + trace.GetFrame(i).GetMethod().Module.Name
                msg += vbCrLf + "MethodName" & vbTab & ": " + trace.GetFrame(i).GetMethod().Name
                msg += vbCrLf + "LineNumber" & vbTab & ": " + trace.GetFrame(i).GetFileLineNumber().ToString()
                msg += vbCrLf + "ColumnNumber" & vbTab & ": " + trace.GetFrame(i).GetFileColumnNumber().ToString() + vbCrLf
                Globals.Instance.WriteLogError(msg + "\r\n", False)
                msg = ""
            End If
        Next
		
        Globals.Instance.WriteLogError(vbCrLf & "All Info" + vbCrLf + trace.ToString() + vbCrLf + New String("-", 50) + vbCrLf, False)
			
        Return ex.Message

    End Function


    Public Sub WriteLogError(ByVal message As String, ByVal WithHeader As Boolean)
        Dim msg As String = New String("-", 50)
        msg += vbCrLf + "eMAP " + AppVersions.Trim() + " " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
        msg += vbCrLf + message + vbCrLf + New String("-", 50) + vbCrLf
        If WithHeader Then message = msg
        System.IO.File.AppendAllText(Application.StartupPath + "\emap_iao_error.log", message)
    End Sub

    Public Sub WriteLogProcess(ByVal message As String, ByVal WithHeader As Boolean)
        Dim msg As String = New String("-", 50)
        msg += vbCrLf + "eMAP " + AppVersions.Trim() + " " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
        msg += vbCrLf + message + vbCrLf + New String("-", 50) + vbCrLf
        If WithHeader Then message = msg
        System.IO.File.AppendAllText(Application.StartupPath + "\emap_iao_process.log", message)
    End Sub

End Class

Public Class MyExcel
    Private Conn As OleDbConnection

    Friend WithEvents _book As C1.C1Excel.C1XLBook
    Private _path As String = ""

    Public Property Path() As String
        Get
            Return _path
        End Get
        Set(ByVal value As String)
            _path = value
        End Set
    End Property

    Sub New(ByVal path As String)
        OpenMyEx(path)
    End Sub

    Sub New()
        _book = New C1XLBook
    End Sub

    Private Sub OpenMyEx(ByVal path As String)
        Try
            Dim ConnString As String
            ConnString = "Provider=Microsoft.Jet.OLEDB.4.0;" _
                    & " Data Source=" & path & ";Extended Properties=Excel 8.0;"
            Dim objConn As New OleDbConnection(ConnString)
            objConn.Open()
            Conn = objConn
        Catch ex As Exception
            MessageBox.Show(Globals.GetStackInfo(ex, True), "Konfirmasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    ''' <summary>
    ''' You must define the name of your Excel range first. This name use to query. 
    ''' QueryRange example : Select * From mRange
    ''' </summary>
    ''' <param name="QueryRange"></param>
    ''' <returns>System.Data.DataTable </returns>
    ''' <remarks></remarks>
    Public Function dtRangeEx(ByVal QueryRange As String) As DataTable
        Dim dtResult As New DataTable
        Try
            If Not Conn Is Nothing Then
                ' The code to follow uses a SQL SELECT command to display the data from the worksheet.

                ' Create new OleDbCommand to return data from worksheet.
                Dim objCmdSelect As New OleDbCommand(QueryRange, Conn)

                ' Create new OleDbDataAdapter that is used to build a DataSet 
                ' based on the preceding SQL SELECT statement.
                Dim objAdapter1 As New OleDbDataAdapter()

                ' Pass the Select command to the adapter.
                objAdapter1.SelectCommand = objCmdSelect

                ' Create new DataSet to hold information from the worksheet.
                Dim objDataset1 As New DataSet()

                ' Fill the DataSet with the information from the worksheet.
                objAdapter1.Fill(objDataset1, "XLData")
                ' Clean up objects.
                Conn.Close()

                Return objDataset1.Tables(0)
            End If
        Catch ex As Exception
            MessageBox.Show(Globals.GetStackInfo(ex, True), "Konfirmasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        Return dtResult
    End Function

    Public Function GetExcelDataSet() As DataSet
        ' clear everything
        _book.Clear()
        Try
            ' load book
            _book.Load(Path)
        Catch ex As Exception
            MessageBox.Show("Stop membaca Excel. Detail error : " & vbCrLf & Globals.GetStackInfo(ex, True), "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return New DataSet
        End Try

        Dim sheet As XLSheet
        Dim cell As XLCell
        Dim ds As New DataSet
        Dim dtResult As DataTable
        Dim dr As DataRow

        For Each sheet In _book.Sheets
            Dim row As Integer, col As Integer
            'jika excel tidak mempunyai data 
            If sheet.Rows.Count = 1 Then Return ds

            'tambah table 
            dtResult = New DataTable()

            For row = 1 To sheet.Rows.Count - 1
                dr = dtResult.NewRow
                For col = 0 To sheet.Columns.Count - 1
                    'jika telah mencapai akhir kolom
                    If sheet.GetCell(0, col) Is Nothing Then Exit For
                    If sheet.GetCell(0, col).Value Is Nothing Then Exit For

                    'tambah kolom ke dtResult JIKA row = 1
                    If row = 1 Then dtResult.Columns.Add(sheet.GetCell(0, col).Value.ToString)

                    cell = sheet.GetCell(row, col)
                    If (cell Is Nothing) Then Continue For

                    'jika type cell adalah date
                    If cell.Style.Format.ToUpper.Contains("YY") Then
                        'isi cell dtResult
                        Try
                            dr(sheet.GetCell(0, col).Value.ToString) = Date.FromOADate(cell.Value) ', "dd-MM-yyyy")
                        Catch ex As Exception
                            dr(sheet.GetCell(0, col).Value.ToString) = cell.Value
                        End Try
                    ElseIf cell.Style.Format.ToUpper.Contains(":SS") Then
                        'isi cell dtResult
                        Try
                            dr(sheet.GetCell(0, col).Value.ToString) = Format(Date.FromOADate(cell.Value), "HH:mm")
                        Catch ex As Exception
                            dr(sheet.GetCell(0, col).Value.ToString) = cell.Value
                        End Try
                    Else
                        'isi cell dtResult
                        dr(sheet.GetCell(0, col).Value.ToString) = cell.Value
                    End If
                Next
                'tambah baris
                dtResult.Rows.Add(dr)
            Next
            ds.Tables.Add(dtResult)
        Next
        Return ds
    End Function

End Class

Public Class SQLServerV2

    Private Shared [global] As SQLServerV2

    Public Shared ReadOnly Property Instance() As SQLServerV2
        Get
            If [global] Is Nothing Then
                [global] = New SQLServerV2
            End If
            Return [global]
        End Get
    End Property

    'Private Function readSetDB(ByVal pSetDB As String) As String

    '    Dim ArcMapPath As String
    '    Dim Reg As New RegistryClass.RegistryClass

    '    '** get templatefile from database '
    '    Reg.HKey = RegistryClass.ssiHKey.HKEY_LOCAL_MACHINE
    '    Reg.QueryValue("Software\ESRI\ArcGIS", "InstallDir", ArcMapPath)

    '    ArcMapPath = ArcMapPath & "Bin"

    '    Dim m_ConfigHelper As ConfigFileHelper
    '    Dim getConfig As String
    '    m_ConfigHelper = New ConfigFileHelper(ArcMapPath & "\ArcMap.exe.config")
    '    getConfig = m_ConfigHelper.GetAppSetting(pSetDB)

    '    Return GlobalClassV2.Globals.Instance.Decrypt(getConfig, "&%#@?,:*")

    'End Function

    'Dim server As String = readSetDB("ServerDBSimtul")
    'Dim database As String = readSetDB("NamaDBSimtul")
    'Dim uid As String = readSetDB("UserDBSimtul")
    'Dim pwd As String = readSetDB("PassDBSimtul")

    'Dim connectionString As String = "Driver={SQL Server};Server=" & server & _
    '                                 ";Database=" & database & _
    '                                 ";Uid=" & uid & ";Pwd=" & pwd & ";"

    'Dim conn As New OdbcConnection(connectionString)
    'Dim reader As OdbcDataReader

    '''--------------------
    ''Dim server2 As String = readSetDB("ServerDBDataCenter")
    ''Dim database2 As String = readSetDB("NamaDBDataCenter")
    ''Dim uid2 As String = readSetDB("UserDBDataCenter")
    ''Dim pwd2 As String = readSetDB("PassDBDataCenter")

    ''Dim connectionString2 As String = "Driver={SQL Server};Server=" & server2 & _
    ''                                 ";Database=" & database2 & _
    ''                                 ";Uid=" & uid2 & ";Pwd=" & pwd2 & ";"

    ''Dim conn2 As New OdbcConnection(connectionString2)
    '''--------------------

    'Public Function TesKoneksi() As Boolean

    '    Try
    '        conn.Close()
    '        conn.Open()

    '        Return True

    '    Catch ex As Exception
    '        MsgBox(Globals.GetStackInfo(ex, True), MsgBoxStyle.Exclamation, "Konfirmasi")
    '        Return False
    '    End Try

    'End Function

    Public Function TestConnectDB(ByVal pServer As String, ByVal pDatabase As String, ByVal pUID As String, ByVal pPWD As String) As Boolean
        Try
            Dim gConnString As String = "Driver={SQL Server};Server=" & pServer & _
                                             ";Database=" & pDatabase & _
                                             ";Uid=" & pUID & ";Pwd=" & pPWD & ";"

            'instantiate OLEDB Connection for textual
            Dim tConnection As New OdbcConnection(gConnString)
            tConnection.Open()
            tConnection.Close()
            tConnection = Nothing
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    'Public Function ExecuteQuery(ByVal SQL As String, Optional ByVal pUJ As String = "") As DataTable

    '    Dim dtResult As New DataTable

    '    'jika disetting tidak pakai integrasi simtul, maka di return true
    '    If Globals.Instance.gIsIntegrasiSIMTUL = False Then Return dtResult

    '    Try
    '        If pUJ <> "" Then
    '            Dim SQLORA As String
    '            Dim dtKONEKSI As DataTable

    '            If pUJ.Substring(0, 1) = "8" Then
    '                pUJ = "800"
    '            End If

    '            SQLORA = " SELECT KODE_UJ, SERVER, DATABASE, USERDB, PASSWORD FROM KONEKSI_INTEGRASI_SISTEM WHERE SUBSTR(KODE_UJ,3,3)='" & Globals.Instance.CheckNullTrim(pUJ) & "'"
    '            dtKONEKSI = Globals.Instance.ExecuteQuery(SQLORA)
    '            If dtKONEKSI.Rows.Count > 0 Then
    '                server = dtKONEKSI.Rows(0)!SERVER.ToString.Trim
    '                database = dtKONEKSI.Rows(0)!DATABASE
    '                uid = dtKONEKSI.Rows(0)!USERDB
    '                pwd = Globals.Instance.Decrypt(dtKONEKSI.Rows(0)!PASSWORD, "&%#@?,:*")
    '            Else
    '                server = readSetDB("ServerDBSimtul")
    '                database = readSetDB("NamaDBSimtul")
    '                uid = readSetDB("UserDBSimtul")
    '                pwd = readSetDB("PassDBSimtul")
    '            End If
    '        Else
    '            server = readSetDB("ServerDBSimtul")
    '            database = readSetDB("NamaDBSimtul")
    '            uid = readSetDB("UserDBSimtul")
    '            pwd = readSetDB("PassDBSimtul")
    '        End If

    '        connectionString = "Driver={SQL Server};Server=" & server & _
    '                                         ";Database=" & database & _
    '                                         ";Uid=" & uid & ";Pwd=" & pwd & ";"

    '        conn = New OdbcConnection(connectionString)
    '        conn.Close()
    '        conn.ConnectionTimeout = 300
    '        conn.Open()

    '        Dim cmd As OdbcCommand = New OdbcCommand(SQL, conn)
    '        Dim adapter = New OdbcDataAdapter(cmd)

    '        adapter.Fill(dtResult)

    '        Return dtResult

    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Exclamation)
    '    Finally
    '        conn.Close()
    '    End Try

    'End Function

    'Public Function ExecuteQueryScada(ByVal SQL As String) As DataTable

    '    Dim dtResult As New DataTable

    '    Try
    '        server = GlobalClassV2.Globals.Instance.GetConfig("ServerSCADA", "")
    '        database = GlobalClassV2.Globals.Instance.GetConfig("DBSCADA", "")
    '        uid = GlobalClassV2.Globals.Instance.GetConfig("UserSCADA", "")
    '        pwd = GlobalClassV2.Globals.Instance.Decrypt(GlobalClassV2.Globals.Instance.GetConfig("PwdSCADA", ""), "&%#@?,:*")

    '        connectionString = "Driver={SQL Server};Server=" & server & _
    '                                         ";Database=" & database & _
    '                                         ";Uid=" & uid & ";Pwd=" & pwd & ";"

    '        conn = New OdbcConnection(connectionString)
    '        conn.Close()
    '        conn.ConnectionTimeout = 300
    '        conn.Open()

    '        Dim cmd As OdbcCommand = New OdbcCommand(SQL, conn)
    '        Dim adapter = New OdbcDataAdapter(cmd)

    '        adapter.Fill(dtResult)

    '        Return dtResult

    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Exclamation)
    '    Finally
    '        conn.Close()
    '    End Try

    'End Function

    'Public Function ExecuteQueryTidakError(ByVal SQL As String, Optional ByVal pUJ As String = "") As DataTable

    '    Dim dtResult As New DataTable

    '    'jika disetting tidak pakai integrasi simtul, maka di return true
    '    If Globals.Instance.gIsIntegrasiSIMTUL = False Then Return dtResult

    '    Try
    '        If pUJ <> "" Then
    '            Dim SQLORA As String
    '            Dim dtKONEKSI As DataTable

    '            If pUJ.Substring(0, 1) = "8" Then
    '                pUJ = "800"
    '            End If

    '            SQLORA = " SELECT KODE_UJ, SERVER, DATABASE, USERDB, PASSWORD FROM KONEKSI_INTEGRASI_SISTEM WHERE SUBSTR(KODE_UJ,3,3)='" & Globals.Instance.CheckNullTrim(pUJ) & "'"
    '            dtKONEKSI = Globals.Instance.ExecuteQuery(SQLORA)
    '            If dtKONEKSI.Rows.Count > 0 Then
    '                server = dtKONEKSI.Rows(0)!SERVER.ToString.Trim
    '                database = dtKONEKSI.Rows(0)!DATABASE
    '                uid = dtKONEKSI.Rows(0)!USERDB
    '                pwd = Globals.Instance.Decrypt(dtKONEKSI.Rows(0)!PASSWORD, "&%#@?,:*")
    '            Else
    '                server = readSetDB("ServerDBSimtul")
    '                database = readSetDB("NamaDBSimtul")
    '                uid = readSetDB("UserDBSimtul")
    '                pwd = readSetDB("PassDBSimtul")
    '            End If
    '        Else
    '            server = readSetDB("ServerDBSimtul")
    '            database = readSetDB("NamaDBSimtul")
    '            uid = readSetDB("UserDBSimtul")
    '            pwd = readSetDB("PassDBSimtul")
    '        End If

    '        connectionString = "Driver={SQL Server};Server=" & server & _
    '                                         ";Database=" & database & _
    '                                         ";Uid=" & uid & ";Pwd=" & pwd & ";"

    '        conn = New OdbcConnection(connectionString)
    '        conn.Close()
    '        conn.ConnectionTimeout = 300
    '        conn.Open()

    '        Dim cmd As OdbcCommand = New OdbcCommand(SQL, conn)
    '        Dim adapter = New OdbcDataAdapter(cmd)

    '        adapter.Fill(dtResult)

    '        Return dtResult

    '    Catch ex As Exception
    '        Return Nothing
    '    Finally
    '        conn.Close()
    '    End Try

    'End Function

    'Public Function ExecuteQueryUserSIMTUL(ByVal SQL As String, ByVal pUJ As String) As DataTable

    '    Dim dtResult As New DataTable

    '    'jika disetting tidak pakai integrasi simtul, maka di return true
    '    If Globals.Instance.gIsIntegrasiSIMTUL = False Then Return dtResult

    '    Dim sUserTUL As String

    '    Try
    '        If pUJ <> "" Then
    '            Dim SQLORA As String
    '            Dim dtKONEKSI As DataTable

    '            If pUJ.Substring(0, 1) = "8" Then
    '                pUJ = "800"
    '            End If
    '            SQLORA = " SELECT KODE_UJ, SERVER, DATABASE, USERDB, PASSWORD, USERTUL FROM KONEKSI_INTEGRASI_SISTEM WHERE SUBSTR(KODE_UJ,3,3)='" & Globals.Instance.CheckNullTrim(pUJ) & "'"
    '            dtKONEKSI = Globals.Instance.ExecuteQuery(SQLORA)
    '            If dtKONEKSI.Rows.Count > 0 Then
    '                server = dtKONEKSI.Rows(0)!SERVER.ToString.Trim
    '                database = dtKONEKSI.Rows(0)!DATABASE
    '                uid = dtKONEKSI.Rows(0)!USERDB
    '                pwd = Globals.Instance.Decrypt(dtKONEKSI.Rows(0)!PASSWORD, "&%#@?,:*")
    '                sUserTUL = dtKONEKSI.Rows(0)!USERTUL
    '            Else
    '                server = readSetDB("ServerDBSimtul")
    '                database = readSetDB("NamaDBSimtul")
    '                uid = readSetDB("UserDBSimtul")
    '                pwd = readSetDB("PassDBSimtul")
    '                sUserTUL = ""
    '            End If
    '        Else
    '            server = readSetDB("ServerDBSimtul")
    '            database = readSetDB("NamaDBSimtul")
    '            uid = readSetDB("UserDBSimtul")
    '            pwd = readSetDB("PassDBSimtul")
    '            sUserTUL = ""
    '        End If

    '        connectionString = "Driver={SQL Server};Server=" & server & _
    '                                         ";Database=" & database & _
    '                                         ";Uid=" & uid & ";Pwd=" & pwd & ";"

    '        conn = New OdbcConnection(connectionString)
    '        conn.ConnectionTimeout = 300
    '        conn.Close()
    '        conn.Open()

    '        'REPLACE KATA SIMTUL..
    '        SQL = SQL.Replace("SIMTUL..", sUserTUL & "..")

    '        Dim cmd As OdbcCommand = New OdbcCommand(SQL, conn)
    '        Dim adapter = New OdbcDataAdapter(cmd)

    '        adapter.Fill(dtResult)

    '        Return dtResult

    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Exclamation)
    '        Return Nothing
    '    Finally
    '        conn.Close()
    '    End Try

    'End Function

    '    Public Function ExecuteQuery2(ByVal SQL As String, ByVal pUJ As String, ByRef pKETERANGAN As String, ByRef pERR As String) As Boolean

    '        'jika disetting tidak pakai integrasi simtul, maka di return true
    '        If Globals.Instance.gIsIntegrasiSIMTUL = False Then Return True

    '        Dim dtResult As New DataTable
    '        Dim isErrKoneksi As Boolean = True
    '        Dim frmKonfirm As New FrmKonfirmasi
    '        Dim sCaption As String

    '        pKETERANGAN = "" : pERR = ""

    'Lagi:
    '        Try
    '            Dim SQLORA As String
    '            Dim dtKONEKSI As DataTable

    '            If pUJ <> "" Then
    '                If pUJ.Substring(0, 1) = "8" Then
    '                    pUJ = "800"
    '                End If
    '            End If

    '            SQLORA = " SELECT KODE_UJ, SERVER, DATABASE, USERDB, PASSWORD FROM KONEKSI_INTEGRASI_SISTEM WHERE SUBSTR(KODE_UJ,3,3)='" & Globals.Instance.CheckNullTrim(pUJ) & "'"
    '            dtKONEKSI = Globals.Instance.ExecuteQuery(SQLORA)
    '            If dtKONEKSI.Rows.Count > 0 Then
    '                server = dtKONEKSI.Rows(0)!SERVER.ToString.Trim
    '                database = dtKONEKSI.Rows(0)!DATABASE
    '                uid = dtKONEKSI.Rows(0)!USERDB
    '                pwd = Globals.Instance.Decrypt(dtKONEKSI.Rows(0)!PASSWORD, "&%#@?,:*")
    '            Else
    '                server = readSetDB("ServerDBSimtul")
    '                database = readSetDB("NamaDBSimtul")
    '                uid = readSetDB("UserDBSimtul")
    '                pwd = readSetDB("PassDBSimtul")
    '            End If

    '            connectionString = "Driver={SQL Server};Server=" & server & _
    '                                             ";Database=" & database & _
    '                                             ";Uid=" & uid & ";Pwd=" & pwd & ";"

    '            conn = New OdbcConnection(connectionString)

    '            conn.Close()
    '            conn.ConnectionTimeout = 60
    '            conn.Open()

    '            isErrKoneksi = False
    '            Dim cmd As OdbcCommand = New OdbcCommand(SQL, conn)
    '            reader = cmd.ExecuteReader
    '            If reader.RecordsAffected Then
    '                Return True
    '            Else
    '                sCaption = "Data tidak ditemukan di Database SIMTUL : " & server & " untuk UJ : " & pUJ & vbCrLf & _
    '                           "Transaksi gagal terupdate ke SIMTUL."
    '                frmKonfirm.Initialize(sCaption)
    '                frmKonfirm.ShowDialog()
    '                If frmKonfirm.m_JenisAction = FrmKonfirmasi.JenisKonfirmasi.CobaLagi Then
    '                    GoTo Lagi
    '                ElseIf frmKonfirm.m_JenisAction = FrmKonfirmasi.JenisKonfirmasi.SimpanLog Then
    '                    pKETERANGAN = "Data tidak ditemukan di Database SIMTUL : " & server & " untuk UJ : " & pUJ
    '                    Return False
    '                End If
    '            End If

    '        Catch ex As Exception
    '            If isErrKoneksi Then
    '                sCaption = "Gagal koneksi ke Database SIMTUL : " & server & " untuk UJ : " & pUJ & vbCrLf & _
    '                           "Transaksi gagal terupdate ke SIMTUL."
    '                frmKonfirm.Initialize(sCaption)
    '                frmKonfirm.ShowDialog()
    '                If frmKonfirm.m_JenisAction = FrmKonfirmasi.JenisKonfirmasi.CobaLagi Then
    '                    GoTo Lagi
    '                ElseIf frmKonfirm.m_JenisAction = FrmKonfirmasi.JenisKonfirmasi.SimpanLog Then
    '                    pKETERANGAN = "Gagal koneksi ke Database SIMTUL : " & server & " untuk UJ : " & pUJ
    '                    Return False
    '                End If
    '            Else
    '                sCaption = "Gagal update ke Database SIMTUL : " & server & " untuk UJ : " & pUJ & vbCrLf & _
    '                           "Transaksi gagal terupdate ke SIMTUL."
    '                frmKonfirm.Initialize(sCaption)
    '                frmKonfirm.ShowDialog()
    '                If frmKonfirm.m_JenisAction = FrmKonfirmasi.JenisKonfirmasi.CobaLagi Then
    '                    GoTo Lagi
    '                ElseIf frmKonfirm.m_JenisAction = FrmKonfirmasi.JenisKonfirmasi.SimpanLog Then
    '                    pERR = ex.Message & " : " & SQL
    '                    pKETERANGAN = "Gagal update ke Database SIMTUL : " & server & " untuk UJ : " & pUJ
    '                    Return False
    '                End If
    '            End If
    '        Finally
    '            conn.Close()
    '        End Try

    '    End Function

    'Public Function ExecuteQueryNoError(ByVal SQL As String, ByVal pUJ As String) As Boolean

    '    'jika disetting tidak pakai integrasi simtul, maka di return true
    '    If Globals.Instance.gIsIntegrasiSIMTUL = False Then Return True

    '    Dim dtResult As New DataTable
    '    Dim isErrKoneksi As Boolean = True

    '    Try
    '        Dim SQLORA As String
    '        Dim dtKONEKSI As DataTable

    '        If pUJ <> "" Then
    '            If pUJ.Substring(0, 1) = "8" Then
    '                pUJ = "800"
    '            End If
    '        End If
    '        SQLORA = " SELECT KODE_UJ, SERVER, DATABASE, USERDB, PASSWORD FROM KONEKSI_INTEGRASI_SISTEM WHERE SUBSTR(KODE_UJ,3,3)='" & pUJ.Trim & "'"
    '        dtKONEKSI = Globals.Instance.ExecuteQuery(SQLORA)
    '        If dtKONEKSI.Rows.Count > 0 Then
    '            server = dtKONEKSI.Rows(0)!SERVER
    '            database = dtKONEKSI.Rows(0)!DATABASE
    '            uid = dtKONEKSI.Rows(0)!USERDB
    '            pwd = Globals.Instance.Decrypt(dtKONEKSI.Rows(0)!PASSWORD, "&%#@?,:*")
    '        Else
    '            server = readSetDB("ServerDBSimtul")
    '            database = readSetDB("NamaDBSimtul")
    '            uid = readSetDB("UserDBSimtul")
    '            pwd = readSetDB("PassDBSimtul")
    '        End If

    '        connectionString = "Driver={SQL Server};Server=" & server & _
    '                                         ";Database=" & database & _
    '                                         ";Uid=" & uid & ";Pwd=" & pwd & ";"

    '        conn = New OdbcConnection(connectionString)

    '        conn.Close()
    '        conn.ConnectionTimeout = 60
    '        conn.Open()

    '        isErrKoneksi = False
    '        Dim cmd As OdbcCommand = New OdbcCommand(SQL, conn)
    '        reader = cmd.ExecuteReader
    '        If reader.RecordsAffected Then
    '            Return True
    '        End If

    '    Catch ex As Exception
    '        Return False
    '    Finally
    '        conn.Close()
    '    End Try

    'End Function

    'Public Function ExecuteQueryTestKoneksi(ByVal SQL As String) As Boolean

    '    'jika disetting tidak pakai integrasi simtul, maka di return true
    '    If Globals.Instance.gIsIntegrasiSIMTUL = False Then Return True

    '    Dim dtResult As New DataTable

    '    Try
    '        server = readSetDB("ServerDBSimtul")
    '        database = readSetDB("NamaDBSimtul")
    '        uid = readSetDB("UserDBSimtul")
    '        pwd = readSetDB("PassDBSimtul")

    '        connectionString = "Driver={SQL Server};Server=" & server & _
    '                                         ";Database=" & database & _
    '                                         ";Uid=" & uid & ";Pwd=" & pwd & ";"

    '        conn = New OdbcConnection(connectionString)

    '        conn.Close()
    '        conn.Open()

    '        Dim cmd As OdbcCommand = New OdbcCommand(SQL, conn)
    '        reader = cmd.ExecuteReader
    '        Return True

    '    Catch ex As Exception
    '        Return False
    '    Finally
    '        conn.Close()
    '    End Try

    'End Function

End Class

Public Class ReadCSV
    Public gConnectionCSV As OleDbConnection
    Private _namaFile As String
    Private _schemaIniValue As String

    Sub New()

    End Sub


    Sub New(ByVal csvPath As String)
        CreateCSVConnection(csvPath)
        _namaFile = GetNamaFile(csvPath)
        _schemaIniValue = "[" & _namaFile & "]" & vbNewLine & "Format=CSVDelimited"
        SchemaIni(csvPath)
    End Sub


    Public Sub CreateCSVConnection(ByVal pCSVPath As String)
        Dim pConnString As String
        Try
            pConnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & _
                          GetFolderPath(pCSVPath) & ";Extended Properties='text;HDR=Yes;FMT=CSVDelimited'"
            gConnectionCSV = New OleDbConnection(pConnString)
            gConnectionCSV.Open()
        Catch ex As Exception
            MessageBox.Show(Globals.GetStackInfo(ex, True), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function ExecuteQueryCSV() As DataTable
        Dim pCommand As OleDbCommand
        Dim SQL As String
        Dim da As OleDbDataAdapter
        Dim dt As DataTable
        Try
            SQL = "SELECT * FROM " & _namaFile
            pCommand = New OleDbCommand(SQL, gConnectionCSV)
            da = New OleDbDataAdapter(pCommand)

            dt = New DataTable
            da.Fill(dt)
        Catch ex As Exception
            MessageBox.Show(Globals.GetStackInfo(ex, True), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
        Return dt
    End Function

    Public Function ExecuteQueryCSV(ByVal pCSVPath As String) As DataTable
        Dim pCommand As OleDbCommand
        Dim SQL As String
        Dim da As OleDbDataAdapter
        Dim dt As DataTable
        Try
            SQL = "SELECT * FROM " & GetNamaFile(pCSVPath)
            pCommand = New OleDbCommand(SQL, gConnectionCSV)
            da = New OleDbDataAdapter(pCommand)

            dt = New DataTable
            da.Fill(dt)
        Catch ex As Exception
            MessageBox.Show(Globals.GetStackInfo(ex, True), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
        Return dt
    End Function

    Private Function GetNamaFile(ByVal Path As String) As String
        If Path.Length = 0 Then Return ""
        Dim i As Integer
        For i = Path.Length To 1 Step -1
            If Mid(Path, i, 1) = "\" Then Exit For
        Next
        GetNamaFile = Mid(Path, i + 1, Path.Length - i)
    End Function

    Private Function GetFolderPath(ByVal Path As String) As String
        If Path.Length = 0 Then Return ""
        Dim i As Integer
        For i = Path.Length To 1 Step -1
            If Mid(Path, i, 1) = "\" Then Exit For
        Next
        GetFolderPath = Mid(Path, 1, i)
    End Function

    Private Function SchemaIni(ByVal csvPath As String) As Boolean
        Dim fs As FileStream
        Dim csvDir As String = My.Computer.FileSystem.GetFileInfo(csvPath).DirectoryName
        Dim schemaIniPath As String = csvDir & "\" & "Schema.ini"

        If Not File.Exists(schemaIniPath) Then
            fs = File.Create(schemaIniPath)
            fs.Close()
        Else
            File.Delete(csvDir & "\" & "Schema.ini")
        End If
        Using sw As StreamWriter = New StreamWriter(schemaIniPath)
            sw.Write(_schemaIniValue)
        End Using
    End Function

End Class

Public Class ImportXLS_NEW
    Private Conn As OleDbConnection
    Sub New(ByVal path As String)
        OpenMyEx(path)
    End Sub

    Private Sub OpenMyEx(ByVal path As String)
        Try
            Dim ConnString As String
            ConnString = "Provider=Microsoft.Jet.OLEDB.4.0;" _
                    & " Data Source=" & path & ";Extended Properties=Excel 8.0;"
            Dim objConn As New OleDbConnection(ConnString)
            objConn.Open()
            Conn = objConn
        Catch ex As Exception
            MessageBox.Show(Globals.GetStackInfo(ex, True), "Konfirmasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Public Function FillDataXLS(ByVal QueryRange As String) As DataTable
        Dim dtResult As New DataTable
        Try
            If Not Conn Is Nothing Then
                Dim objCmdSelect As New OleDbCommand(QueryRange, Conn)
                Dim objAdapter1 As New OleDbDataAdapter()
                objAdapter1.SelectCommand = objCmdSelect
                Dim objDataset1 As New DataSet()
                objAdapter1.Fill(objDataset1)
                Conn.Close()
                Return objDataset1.Tables(0)
            End If
        Catch ex As Exception
            MessageBox.Show(Globals.GetStackInfo(ex, True), "Konfirmasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        Return dtResult
    End Function
End Class

Public Class EnumTools
#Region " Methods "
#Region " ... EnumInstanceFromName "
    Public Function EnumInstanceFromName(ByVal MyEnum As [Enum], _
                                         ByVal EnumName As String) As Object
        '---------------------------------------------------------------------------------
        ' Return an enum instance derived from the passed enum name
        '---------------------------------------------------------------------------------
        Return [Enum].Parse(MyEnum.GetType, EnumName)

    End Function
#End Region
#Region " ... EnumInstanceFromValue "
    Public Function EnumInstanceFromValue(ByVal MyEnum As [Enum], _
                                          ByVal EnumValue As Integer) As Object
        '---------------------------------------------------------------------------------
        ' Return an enum instance derived from the passed enum value
        '---------------------------------------------------------------------------------

        '---------------------------------------------------------------------------------
        ' Get the name for the enum instance using the passed integer value
        '---------------------------------------------------------------------------------
        Dim enumName As String = Me.EnumNameFromValue(MyEnum, EnumValue)

        '---------------------------------------------------------------------------------
        ' Get the enum instance using the enum name
        '---------------------------------------------------------------------------------
        Return Me.EnumInstanceFromName(MyEnum, enumName)

    End Function
#End Region
#Region " ... EnumNameFromValue "
    Public Function EnumNameFromValue( _
                    ByVal MyEnum As [Enum], _
                    ByVal EnumValue As Integer, _
                    Optional ByVal AddSpaces As Boolean = False) As String
        '---------------------------------------------------------------------------------
        ' Return the string value equivalent for the passed enum integer value
        '---------------------------------------------------------------------------------

        '---------------------------------------------------------------------------------
        ' Get the name from the enum instance with the passed integer value
        '---------------------------------------------------------------------------------
        Dim enumName As String = [Enum].GetName(MyEnum.GetType, CType(EnumValue, Object))

        '---------------------------------------------------------------------------------
        ' If requested, insert spaces in front of all capital letters except the first letter
        '---------------------------------------------------------------------------------
        If AddSpaces Then
            enumName = InsertSpacesInEnumName(enumName)
        End If

        '---------------------------------------------------------------------------------
        ' Return the enum instance name
        '---------------------------------------------------------------------------------
        Return enumName

    End Function
#End Region
#Region " ... EnumNames "
    Public Function EnumNames(ByVal MyEnum As [Enum], _
                              Optional ByVal AddSpaces As Boolean = False) As String()
        '---------------------------------------------------------------------------------
        ' Return an array containing the names in the passed enum in value sequence
        '---------------------------------------------------------------------------------

        '---------------------------------------------------------------------------------
        ' Place all enum names in an array
        '---------------------------------------------------------------------------------
        Dim nameArray() As String = [Enum].GetNames(MyEnum.GetType)

        '---------------------------------------------------------------------------------
        ' If requested, insert a space in each name just before all capital letters
        ' except the first letter
        '---------------------------------------------------------------------------------
        If AddSpaces Then
            For i As Integer = 0 To nameArray.GetUpperBound(0)
                nameArray(i) = InsertSpacesInEnumName(nameArray(i))
            Next
        End If

        '---------------------------------------------------------------------------------
        ' Return the array of enum names
        '---------------------------------------------------------------------------------
        Return nameArray

    End Function
#End Region
#Region " ... EnumValueFromName "
    Public Function EnumValueFromName(ByVal MyEnum As [Enum], _
                                      ByVal EnumName As String) As Integer
        '---------------------------------------------------------------------------------
        ' Return the enum integer value for the passed enum name
        '---------------------------------------------------------------------------------
        Return CType([Enum].Parse(MyEnum.GetType, EnumName), Integer)

    End Function
#End Region
#Region " ... EnumValues "
    Public Function EnumValues(ByVal MyEnum As [Enum]) As Integer()
        '---------------------------------------------------------------------------------
        ' Return an array of the integer values in the passed enum in instance sequence
        '---------------------------------------------------------------------------------

        '---------------------------------------------------------------------------------
        ' Get the size of the enum values array
        '---------------------------------------------------------------------------------
        Dim enumUpperBound As Integer = [Enum].GetValues(MyEnum.GetType).GetUpperBound(0)

        '---------------------------------------------------------------------------------
        ' Copy the enum values to an integer array
        '---------------------------------------------------------------------------------
        Dim valuesArray(enumUpperBound) As Integer
        System.Array.Copy([Enum].GetValues(MyEnum.GetType), _
                          valuesArray, _
                          enumUpperBound)

        '---------------------------------------------------------------------------------
        ' Return the integer array of enum values
        '---------------------------------------------------------------------------------
        Return valuesArray

    End Function
#End Region
#End Region
#Region " Procedures "
#Region " ... InsertSpacesInEnumName "
    Private Function InsertSpacesInEnumName(ByVal EnumName As String) As String
        '---------------------------------------------------------------------------------
        ' Insert a space in the passed enum name just before all capital letters (except
        ' the first letter)
        '---------------------------------------------------------------------------------

        '---------------------------------------------------------------------------------
        ' Default to an empty enum name
        '---------------------------------------------------------------------------------
        Dim spacedName As String = ""

        '---------------------------------------------------------------------------------
        ' If the name is one or more characters in length ...
        '---------------------------------------------------------------------------------
        If EnumName.Length > 0 Then

            '** Do nothing with the first character in the name
            spacedName = EnumName.Substring(0, 1)

            '** look at each character in the name starting with the 2nd
            '** character, and ...
            Dim nextChar As String = ""
            For j As Integer = 1 To EnumName.Length - 1

                '** looking at each character one at a time ...
                nextChar = EnumName.Substring(j, 1)

                '** if a character is a capital letter ...
                Select Case Convert.ToInt16(CType(nextChar, Char))
                    Case 65 To 90           ' Capital letters
                        '** insert a space before the capital letter and then ...
                        spacedName &= " "
                End Select

                '** append the character just looked at to the output string.
                spacedName &= nextChar

            Next

        End If

        '---------------------------------------------------------------------------------
        ' Return the possibly modified enum name
        '---------------------------------------------------------------------------------
        Return spacedName

    End Function
#End Region
#End Region
End Class
