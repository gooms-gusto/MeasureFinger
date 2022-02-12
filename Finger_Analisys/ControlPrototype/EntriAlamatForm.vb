Imports System.Text
Imports EMap.DL_EMap

Public Class EntriAlamatForm

    Public Property Propinsi() As String
        Get
            Return _Propinsi
        End Get
        Set(ByVal value As String)
            _Propinsi = value
        End Set
    End Property

    Public Property Kab() As String
        Get
            Return _Kab
        End Get
        Set(ByVal value As String)
            _Kab = value
        End Set
    End Property

    Public Property Kec() As String
        Get
            Return _Kec
        End Get
        Set(ByVal value As String)
            _Kec = value
        End Set
    End Property

    Public Property Kel() As String
        Get
            Return _Kel
        End Get
        Set(ByVal value As String)
            _Kel = value
        End Set
    End Property

    Public Property Lingk() As String
        Get
            Return _Lingk
        End Get
        Set(ByVal value As String)
            _Lingk = value
        End Set
    End Property

    Public Property KodePos() As String
        Get
            Return _KodePos
        End Get
        Set(ByVal value As String)
            _KodePos = value
        End Set
    End Property

    Public Property Jln() As String
        Get
            Return _Jln
        End Get
        Set(ByVal value As String)
            _Jln = value
        End Set
    End Property

    Public ReadOnly Property strAlamat() As String
        Get
            Return _strAlamat
        End Get
    End Property

    Private _Propinsi As String
    Private _Kab As String
    Private _Kec As String
    Private _Kel As String
    Private _Lingk As String
    Private _KodePos As String
    Private _Jln As String
    Private _strAlamat As String = ""

    Private Sub cmdTutup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTutup.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cmdOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        DialogResult = Windows.Forms.DialogResult.OK
        _strAlamat = Alamat()
    End Sub

    Private Function Alamat() As String
        Dim sb As New StringBuilder
        Dim obj As String()

        'Plan : give DD, Kode Property, so we don't use split anymore.
        obj = Split(ddJln.Text, "-") : If obj.Length > 1 Then Jln = obj.GetValue(1)
        If Not Jln = "" Then sb.Append(Jln)

        obj = Split(ddLingk.Text, "-") : If obj.Length > 1 Then Lingk = obj.GetValue(1)
        If Not Lingk = "" Then sb.Append(" " & Lingk)

        obj = Split(ddKel.Text, "-") : If obj.Length > 1 Then Kel = obj.GetValue(1)
        If Not Kel = "" Then sb.Append(" Kel. " & Kel)

        obj = Split(ddKec.Text, "-") : If obj.Length > 1 Then Kec = obj.GetValue(1)
        If Not Kec = "" Then sb.Append(" Kec. " & Kec)

        obj = Split(ddKab.Text, "-") : If obj.Length > 1 Then Kab = obj.GetValue(1)
        If Not Kab = "" Then sb.Append(" Kab. " & Kab)

        obj = Split(ddProp.Text, "-") : If obj.Length > 1 Then Propinsi = obj.GetValue(1)
        If Not Propinsi = "" Then sb.Append(" Pr " & Propinsi)

        Return Trim(sb.ToString)
    End Function

    Private Sub EntriAlamatForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Propinsi = Trim(ddProp.Text)
        Kab = Trim(ddKab.Text)
        Kec = Trim(ddKec.Text)
        Kel = Trim(ddKel.Text)
        Lingk = Trim(ddLingk.Text)
        Jln = Trim(ddJln.Text)
    End Sub

    Private Sub EntriAlamatForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ddProp.SQLInput = DLSelect.QueryPropinsi(False, "", "", "", "", "")
        ddProp.SQLValidation = DLSelect.QueryPropinsi(True, "", "", "", "", "")
        ddKab.SQLInput = DLSelect.QueryKabupaten(False, "", "", "", "", "")
        ddKab.SQLValidation = DLSelect.QueryKabupaten(True, "", "", "", "", "")
        ddKec.SQLInput = DLSelect.QueryKecamatan(False, "", "", "", "", "")
        ddKec.SQLValidation = DLSelect.QueryKecamatan(True, "", "", "", "", "")
        ddKel.SQLInput = DLSelect.QueryKelurahan(False, "", "", "", "", "")
        ddKel.SQLValidation = DLSelect.QueryKelurahan(True, "", "", "", "", "")
        ddLingk.SQLInput = DLSelect.QueryLingkungan(False, "", "", "", "")
        ddLingk.SQLValidation = DLSelect.QueryLingkungan(True, "", "", "", "")
        ddJln.SQLInput = DLSelect.QueryJalan(False, "", "", "", "")
        ddJln.SQLValidation = DLSelect.QueryJalan(True, "", "", "", "")
    End Sub

    Private Sub ddProp_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddProp.TextChanged
        ddKab.SQLInput = DLSelect.QueryKabupaten(False, ddProp.ID, ddKec.ID, ddKel.ID, ddLingk.ID, ddJln.ID)
        ddKab.SQLValidation = DLSelect.QueryKabupaten(True, ddProp.ID, ddKec.ID, ddKel.ID, ddLingk.ID, ddJln.ID)
        ddKec.SQLInput = DLSelect.QueryKecamatan(False, ddProp.ID, ddKab.ID, ddKel.ID, ddLingk.ID, ddJln.ID)
        ddKec.SQLValidation = DLSelect.QueryKecamatan(True, ddProp.ID, ddKab.ID, ddKel.ID, ddLingk.ID, ddJln.ID)
        ddKel.SQLInput = DLSelect.QueryKelurahan(False, ddProp.ID, ddKab.ID, ddKec.ID, ddLingk.ID, ddJln.ID)
        ddKel.SQLValidation = DLSelect.QueryKelurahan(True, ddProp.ID, ddKab.ID, ddKec.ID, ddLingk.ID, ddJln.ID)
        ddLingk.SQLInput = DLSelect.QueryLingkungan(False, ddProp.ID, ddKab.ID, ddKec.ID, ddKel.ID)
        ddLingk.SQLValidation = DLSelect.QueryLingkungan(True, ddProp.ID, ddKab.ID, ddKec.ID, ddKel.ID)
        ddJln.SQLInput = DLSelect.QueryJalan(False, ddProp.ID, ddKab.ID, ddKec.ID, ddKel.ID)
        ddJln.SQLValidation = DLSelect.QueryJalan(True, ddProp.ID, ddKab.ID, ddKec.ID, ddKel.ID)
    End Sub

    Private Sub ddKab_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddKab.TextChanged
        ddProp.SQLInput = DLSelect.QueryPropinsi(False, ddKab.ID, ddKec.ID, ddKel.ID, ddLingk.ID, ddJln.ID)
        ddProp.SQLValidation = DLSelect.QueryPropinsi(True, ddKab.ID, ddKec.ID, ddKel.ID, ddLingk.ID, ddJln.ID)
        ddKec.SQLInput = DLSelect.QueryKecamatan(False, ddProp.ID, ddKab.ID, ddKel.ID, ddLingk.ID, ddJln.ID)
        ddKec.SQLValidation = DLSelect.QueryKecamatan(True, ddProp.ID, ddKab.ID, ddKel.ID, ddLingk.ID, ddJln.ID)
        ddKel.SQLInput = DLSelect.QueryKelurahan(False, ddProp.ID, ddKab.ID, ddKec.ID, ddLingk.ID, ddJln.ID)
        ddKel.SQLValidation = DLSelect.QueryKelurahan(True, ddProp.ID, ddKab.ID, ddKec.ID, ddLingk.ID, ddJln.ID)
        ddLingk.SQLInput = DLSelect.QueryLingkungan(False, ddProp.ID, ddKab.ID, ddKec.ID, ddKel.ID)
        ddLingk.SQLValidation = DLSelect.QueryLingkungan(True, ddProp.ID, ddKab.ID, ddKec.ID, ddKel.ID)
        ddJln.SQLInput = DLSelect.QueryJalan(False, ddProp.ID, ddKab.ID, ddKec.ID, ddKel.ID)
        ddJln.SQLValidation = DLSelect.QueryJalan(True, ddProp.ID, ddKab.ID, ddKec.ID, ddKel.ID)
    End Sub

    Private Sub ddKec_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddKec.TextChanged
        ddProp.SQLInput = DLSelect.QueryPropinsi(False, ddKab.ID, ddKec.ID, ddKel.ID, ddLingk.ID, ddJln.ID)
        ddProp.SQLValidation = DLSelect.QueryPropinsi(True, ddKab.ID, ddKec.ID, ddKel.ID, ddLingk.ID, ddJln.ID)
        ddKab.SQLInput = DLSelect.QueryKabupaten(False, ddProp.ID, ddKec.ID, ddKel.ID, ddLingk.ID, ddJln.ID)
        ddKab.SQLValidation = DLSelect.QueryKabupaten(True, ddProp.ID, ddKec.ID, ddKel.ID, ddLingk.ID, ddJln.ID)
        ddKel.SQLInput = DLSelect.QueryKelurahan(False, ddProp.ID, ddKab.ID, ddKec.ID, ddLingk.ID, ddJln.ID)
        ddKel.SQLValidation = DLSelect.QueryKelurahan(True, ddProp.ID, ddKab.ID, ddKec.ID, ddLingk.ID, ddJln.ID)
        ddLingk.SQLInput = DLSelect.QueryLingkungan(False, ddProp.ID, ddKab.ID, ddKec.ID, ddKel.ID)
        ddLingk.SQLValidation = DLSelect.QueryLingkungan(True, ddProp.ID, ddKab.ID, ddKec.ID, ddKel.ID)
        ddJln.SQLInput = DLSelect.QueryJalan(False, ddProp.ID, ddKab.ID, ddKec.ID, ddKel.ID)
        ddJln.SQLValidation = DLSelect.QueryJalan(True, ddProp.ID, ddKab.ID, ddKec.ID, ddKel.ID)
    End Sub

    Private Sub ddKel_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddKel.TextChanged
        ddProp.SQLInput = DLSelect.QueryPropinsi(False, ddKab.ID, ddKec.ID, ddKel.ID, ddLingk.ID, ddJln.ID)
        ddProp.SQLValidation = DLSelect.QueryPropinsi(True, ddKab.ID, ddKec.ID, ddKel.ID, ddLingk.ID, ddJln.ID)
        ddKab.SQLInput = DLSelect.QueryKabupaten(False, ddProp.ID, ddKec.ID, ddKel.ID, ddLingk.ID, ddJln.ID)
        ddKab.SQLValidation = DLSelect.QueryKabupaten(True, ddProp.ID, ddKec.ID, ddKel.ID, ddLingk.ID, ddJln.ID)
        ddKec.SQLInput = DLSelect.QueryKecamatan(False, ddProp.ID, ddKab.ID, ddKel.ID, ddLingk.ID, ddJln.ID)
        ddKec.SQLValidation = DLSelect.QueryKecamatan(True, ddProp.ID, ddKab.ID, ddKel.ID, ddLingk.ID, ddJln.ID)
        ddLingk.SQLInput = DLSelect.QueryLingkungan(False, ddProp.ID, ddKab.ID, ddKec.ID, ddKel.ID)
        ddLingk.SQLValidation = DLSelect.QueryLingkungan(True, ddProp.ID, ddKab.ID, ddKec.ID, ddKel.ID)
        ddJln.SQLInput = DLSelect.QueryJalan(False, ddProp.ID, ddKab.ID, ddKec.ID, ddKel.ID)
        ddJln.SQLValidation = DLSelect.QueryJalan(True, ddProp.ID, ddKab.ID, ddKec.ID, ddKel.ID)
    End Sub

    Private Sub ddLingk_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddLingk.TextChanged
        ddProp.SQLInput = DLSelect.QueryPropinsi(False, ddKab.ID, ddKec.ID, ddKel.ID, ddLingk.ID, ddJln.ID)
        ddProp.SQLValidation = DLSelect.QueryPropinsi(True, ddKab.ID, ddKec.ID, ddKel.ID, ddLingk.ID, ddJln.ID)
        ddKab.SQLInput = DLSelect.QueryKabupaten(False, ddProp.ID, ddKec.ID, ddKel.ID, ddLingk.ID, ddJln.ID)
        ddKab.SQLValidation = DLSelect.QueryKabupaten(True, ddProp.ID, ddKec.ID, ddKel.ID, ddLingk.ID, ddJln.ID)
        ddKec.SQLInput = DLSelect.QueryKecamatan(False, ddProp.ID, ddKab.ID, ddKel.ID, ddLingk.ID, ddJln.ID)
        ddKec.SQLValidation = DLSelect.QueryKecamatan(True, ddProp.ID, ddKab.ID, ddKel.ID, ddLingk.ID, ddJln.ID)
        ddKel.SQLInput = DLSelect.QueryKelurahan(False, ddProp.ID, ddKab.ID, ddKec.ID, ddLingk.ID, ddJln.ID)
        ddKel.SQLValidation = DLSelect.QueryKelurahan(True, ddProp.ID, ddKab.ID, ddKec.ID, ddLingk.ID, ddJln.ID)
    End Sub

    Private Sub ddJln_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddJln.TextChanged
        ddProp.SQLInput = DLSelect.QueryPropinsi(False, ddKab.ID, ddKec.ID, ddKel.ID, ddLingk.ID, ddJln.ID)
        ddProp.SQLValidation = DLSelect.QueryPropinsi(True, ddKab.ID, ddKec.ID, ddKel.ID, ddLingk.ID, ddJln.ID)
        ddKab.SQLInput = DLSelect.QueryKabupaten(False, ddProp.ID, ddKec.ID, ddKel.ID, ddLingk.ID, ddJln.ID)
        ddKab.SQLValidation = DLSelect.QueryKabupaten(True, ddProp.ID, ddKec.ID, ddKel.ID, ddLingk.ID, ddJln.ID)
        ddKec.SQLInput = DLSelect.QueryKecamatan(False, ddProp.ID, ddKab.ID, ddKel.ID, ddLingk.ID, ddJln.ID)
        ddKec.SQLValidation = DLSelect.QueryKecamatan(True, ddProp.ID, ddKab.ID, ddKel.ID, ddLingk.ID, ddJln.ID)
        ddKel.SQLInput = DLSelect.QueryKelurahan(False, ddProp.ID, ddKab.ID, ddKec.ID, ddLingk.ID, ddJln.ID)
        ddKel.SQLValidation = DLSelect.QueryKelurahan(True, ddProp.ID, ddKab.ID, ddKec.ID, ddLingk.ID, ddJln.ID)
    End Sub

    Private Sub ddKab_Selected() Handles ddKab.Selected
        If ddKab.Text = "" Then
            ddProp.Text = ""
            Exit Sub
        End If
        ddProp.Text = DLSelect.FindProp(ddKab.ID)
    End Sub

    Private Sub ddKec_Selected() Handles ddKec.Selected
        If ddKec.Text = "" Then
            ddProp.Text = "" : ddKab.Text = ""
            Exit Sub
        End If
        ddKab.Text = DLSelect.FindKab(ddKec.ID)
        ddProp.Text = DLSelect.FindProp(ddKab.ID)
    End Sub

    Private Sub ddKel_Selected() Handles ddKel.Selected
        If ddKel.Text = "" Then
            ddProp.Text = "" : ddKab.Text = "" : ddKec.Text = ""
            Exit Sub
        End If
        ddKec.Text = DLSelect.FindKec(ddKel.ID)
        ddKab.Text = DLSelect.FindKab(ddKec.ID)
        ddProp.Text = DLSelect.FindProp(ddKab.ID)
    End Sub

    Private Sub ddLingk_Selected() Handles ddLingk.Selected
        If ddLingk.Text = "" Then
            ddProp.Text = "" : ddKab.Text = "" : ddKec.Text = "" : ddKel.Text = ""
            Exit Sub
        End If
        ddKel.Text = DLSelect.FindKel(True, ddLingk.ID, "")
        ddKec.Text = DLSelect.FindKec(ddKel.ID)
        ddKab.Text = DLSelect.FindKab(ddKec.ID)
        ddProp.Text = DLSelect.FindProp(ddKab.ID)
    End Sub

    Private Sub ddJln_Selected() Handles ddJln.Selected
        If ddJln.Text = "" Then
            ddProp.Text = "" : ddKab.Text = "" : ddKec.Text = "" : ddKel.Text = ""
            Exit Sub
        End If
        ddKel.Text = DLSelect.FindKel(False, "", ddJln.ID)
        ddKec.Text = DLSelect.FindKec(ddKel.ID)
        ddKab.Text = DLSelect.FindKab(ddKec.ID)
        ddProp.Text = DLSelect.FindProp(ddKab.ID)
    End Sub

End Class