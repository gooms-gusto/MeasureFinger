Public Class FrmKonfirmasi

    Private m_Caption As String
    Public Enum JenisKonfirmasi
        CobaLagi = 1
        SimpanLog = 2
    End Enum
    Public m_JenisAction As JenisKonfirmasi

    Public Sub Initialize(ByVal pCaption As String)
        m_Caption = pCaption
    End Sub

    Private Sub FrmKonfirmasi_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label1.Text = m_Caption
        m_JenisAction = JenisKonfirmasi.CobaLagi
    End Sub

    Private Sub cmdCobaLagi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCobaLagi.Click
        m_JenisAction = JenisKonfirmasi.CobaLagi
        Me.Close()
    End Sub

    Private Sub cmdSimpanLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSimpanLog.Click
        m_JenisAction = JenisKonfirmasi.SimpanLog
        Me.Close()
    End Sub

End Class