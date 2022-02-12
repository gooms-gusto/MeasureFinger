'Imports SecmanUtil2
'Imports IAORDP2

Public Class Secman
    Private Shared m_Secman As Secman
    Public gUser, gAppID, gSystemID As String
    Public gJnsAplikasi As String
    Public gIsAdministrator As Boolean = False
    'Private objLog As IAORDP2.Log


    Public Shared ReadOnly Property Instance() As Secman
        Get
            If m_Secman Is Nothing Then
                m_Secman = New Secman
            End If
            Return m_Secman
        End Get
    End Property

    Private Function IsAdministrator(ByVal user As String) As Boolean
        Dim SQL As String
        SQL = " select b.GROUPID from "
        SQL = SQL & "USRTAB a, GRPMEMBER b "
        SQL = SQL & "where a.USERID = b.USERID "
        SQL = SQL & "AND a.USERID = '" & user & "' "
        Dim dt As DataTable = Globals.Instance.ExecuteQuery(SQL)
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                If UCase(Trim(dt.Rows(i)(0))) = "ADMINISTRATORS" Then
                    Return True
                End If
            Next
        End If
        Return False
    End Function

    Public Function LoginUser(ByVal user As String, ByVal psw As String, ByVal appid As String, ByVal systemid As String) As Boolean
        Dim SQL As String
        gUser = user
        gAppID = appid
        gSystemID = systemid

        Try
            If CekLogin(user, psw) Then
                If IsAdministrator(user) Then
                    gIsAdministrator = True
                    Return True
                Else
                    SQL = "  SELECT  ucr.ucrid "
                    SQL = SQL & "     FROM ucr, groupaccess ga, grpmember gm "
                    SQL = SQL & "    WHERE ga.systemid = ucr.systemid "
                    SQL = SQL & "      AND ga.appid = ucr.appid "
                    SQL = SQL & "      AND ga.ucrid = ucr.ucrid "
                    SQL = SQL & "      AND ga.systemid = gm.systemid "
                    SQL = SQL & "      AND ga.groupid = gm.groupid "
                    SQL = SQL & "      AND gm.userid = '" & user & "'"
                    SQL = SQL & "      AND ucr.appid = '" & appid & "'"
                    SQL = SQL & "      AND ucr.systemid = '" & systemid & "'"
                    Dim dtMenuUser As DataTable
                    dtMenuUser = Globals.Instance.ExecuteQuery(SQL)
                    gIsAdministrator = False
                    If dtMenuUser.Rows.Count = 0 Then Return False Else Return True
                End If
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
    End Function

    'mengecek kevalidan login user
    Private Function CekLogin(ByVal user As String, ByVal psw As String) As Boolean
        Dim SQL As String

        Dim md5secman As New MD5Dll.CMD5Class
        Dim dt As DataTable

        Dim strUSR, strDB As String
        SQL = " select PASSW from USRTAB where USERID = '" & UCase(user) & "'"
        dt = Globals.Instance.ExecuteQuery(SQL)
        If dt.Rows.Count > 0 Then
            strDB = dt.Rows(0)(0)
            strUSR = md5secman.MD5(psw)
            If UCase(strDB) = UCase(strUSR) Then
                md5secman = Nothing
                Return True
            End If
        End If
        md5secman = Nothing
        Return False
    End Function

    <CLSCompliant(False)> Public Sub SetLogActivity(ByVal ucrID As String, ByVal pAction As IAORDP2.LogActionTypeEnum, ByVal pDesc As String)
        'objLog.LogActivity(gAppID, UCase(ucrID), pAction, pDesc)
    End Sub

    Public Function IsEnabledMenu(ByVal ucrID As String) As Boolean
        Try
            If gIsAdministrator Then Return True

            Dim SQL As String

            SQL = " SELECT b.userid, a.systemid, a.appid,a.ucrid  "
            SQL = SQL & "FROM   groupaccess a, grpmember b  "
            SQL = SQL & "WHERE  a.groupid = b.groupid  "
            SQL = SQL & "AND a.systemid = b.systemid  "
            SQL = SQL & "AND b.userid = '" & gUser & "' "
            SQL = SQL & "AND a.systemid = '" & gSystemID & "' AND a.appid= '" & gAppID & "'  "
            SQL = SQL & "AND a.ucrid= '" & UCase(ucrID) & "' "
            Dim dt As DataTable = Globals.Instance.ExecuteQuery(SQL)
            If dt.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
            'Return objLog.IsAuthorizedAction(gSystemID, gAppID, UCase(ucrID))
            'Return True
        Catch EX As Exception
            Return True
        End Try
        'Return True
    End Function

    Public Function ChangePassword(ByVal userId As String, ByVal oldPassword As String, _
        ByVal newPassword As String) As Boolean

        Dim md5secman As New MD5Dll.CMD5Class
        Dim RJNDAEL As New Global.RIJNDAEL.clsRijndael
        Dim dt As DataTable
        Dim SQL As String
        Dim passInput, passDB, dbPass As String
        SQL = " select PASSW from USRTAB where USERID = '" & UCase(userId) & "'"
        dt = Globals.Instance.ExecuteQuery(SQL)
        If dt.Rows.Count > 0 Then
            passDB = dt.Rows(0)(0)
            passInput = md5secman.MD5(oldPassword)
            If UCase(passDB) = UCase(passInput) Then
                If newPassword = "" Then
                    dbPass = ""
                Else
                    dbPass = RJNDAEL.EncryptStringToHex(newPassword, Win32.c_rijndaelkey)
                    passInput = md5secman.MD5(newPassword)
                End If
                SQL = "UPDATE USRTAB SET PASSW='" & passInput & "',DBPASSW='" & dbPass & "' WHERE USERID='" & UCase(userId) & "'"
                Return Globals.Instance.ExecuteQuery2(SQL)
            Else
                MsgBox("Password lama anda salah", MsgBoxStyle.Exclamation, "Ubah Password")
                md5secman = Nothing
                RJNDAEL = Nothing
                Return False
            End If
        Else
            MsgBox("User anda tidak terdaftar di database", MsgBoxStyle.Exclamation, "Ubah Password")
            md5secman = Nothing
            RJNDAEL = Nothing
            Return False
        End If
        md5secman = Nothing
        RJNDAEL = Nothing
        Return False
    End Function

End Class
