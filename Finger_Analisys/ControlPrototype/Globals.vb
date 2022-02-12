Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.InteropServices

Public Class Globals

    Public Shared Function GetStackInfo(ByVal ex As Exception, ByVal WithCurrentMessage As Boolean) As String
        WriteLog("Error Message: " + ex.Message + vbCrLf, True)
        Dim Trace As System.Diagnostics.StackTrace = New System.Diagnostics.StackTrace(ex, True)
        Dim msg As String = vbCrLf + New String("-", 50)
        For i As Integer = 0 To Trace.FrameCount - 1
            If Trace.GetFrame(i).GetMethod().Name <> "GetStackInfo" And Trace.GetFrame(i).GetMethod().Module.Name <> "System.Data.dll" Then
                msg += vbCrLf + "ModuleName" & vbTab & ": " + Trace.GetFrame(i).GetMethod().Module.Name
                msg += vbCrLf + "MethodName" & vbTab & ": " + Trace.GetFrame(i).GetMethod().Name
                msg += vbCrLf + "LineNumber" & vbTab & ": " + Trace.GetFrame(i).GetFileLineNumber().ToString()
                msg += vbCrLf + "ColumnNumber" & vbTab & ": " + Trace.GetFrame(i).GetFileColumnNumber().ToString() + vbCrLf
                'msg += vbCrLf + "All Info" + vbCrLf + Trace.ToString()
                WriteLog(msg + vbCrLf, False)
                msg = ""
            End If
        Next
        WriteLog(vbCrLf + "All Info" + vbCrLf + Trace.ToString() + vbCrLf, False)
        Return msg

    End Function

    Public Shared Function GetStackInfo(ByVal ex As Exception, ByVal NewMessage As String) As String
        Dim trace As System.Diagnostics.StackTrace = New System.Diagnostics.StackTrace(ex, True)
        Dim msg As String = vbCrLf + New String("-", 50)
        For i As Integer = 0 To trace.FrameCount - 1
            If trace.GetFrame(i).GetMethod().Name <> "GetStackInfo" And trace.GetFrame(i).GetMethod().Module.Name <> "System.Data.dll" Then
                msg += vbCrLf + "ModuleName" & vbTab & ": " + trace.GetFrame(i).GetMethod().Module.Name
                msg += vbCrLf + "MethodName" & vbTab & ": " + trace.GetFrame(i).GetMethod().Name
                msg += vbCrLf + "LineNumber" & vbTab & ": " + trace.GetFrame(i).GetFileLineNumber().ToString()
                msg += vbCrLf + "ColumnNumber" & vbTab & ": " + trace.GetFrame(i).GetFileColumnNumber().ToString() + vbCrLf
            End If
        Next

        Return NewMessage + msg

    End Function

    Private Shared Sub WriteLog(ByVal contents As String, ByVal WithDateTime As Boolean)
        If WithDateTime = True Then contents = vbCrLf + "Create on: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + contents
        System.IO.File.AppendAllText(Application.StartupPath + "\emap_iao_error.log", contents)
    End Sub
End Class
