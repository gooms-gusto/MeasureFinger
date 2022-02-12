Imports System.Text

Public Class EntriPemohonForm

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

    Public Property Nama() As String
        Get
            Return _Nama
        End Get
        Set(ByVal value As String)
            _Nama = value
        End Set
    End Property

    Public Property KTP() As String
        Get
            Return _KTP
        End Get
        Set(ByVal value As String)
            _KTP = value
        End Set
    End Property

    Public Property Telp() As String
        Get
            Return _Telp
        End Get
        Set(ByVal value As String)
            _Telp = value
        End Set
    End Property

    Public Property Alamat() As String
        Get
            Return _Alamat
        End Get
        Set(ByVal value As String)
            _Alamat = value
        End Set
    End Property

    Public Property Bangunan() As String
        Get
            Return _Bangunan
        End Get
        Set(ByVal value As String)
            _Bangunan = value
        End Set
    End Property

    Public Property RT() As String
        Get
            Return _RT
        End Get
        Set(ByVal value As String)
            _RT = value
        End Set
    End Property

    Public Property RW() As String
        Get
            Return _RW
        End Get
        Set(ByVal value As String)
            _RW = value
        End Set
    End Property


    Public Property NoDlmRT1() As String
        Get
            Return _NoDlmRT1
        End Get
        Set(ByVal value As String)
            _NoDlmRT1 = value
        End Set
    End Property

    Public Property NoDlmRT2() As String
        Get
            Return _NoDlmRT2
        End Get
        Set(ByVal value As String)
            _NoDlmRT2 = value
        End Set
    End Property


    Private _Propinsi As String = ""
    Private _Kab As String = ""
    Private _Kec As String = ""
    Private _Kel As String = ""
    Private _Lingk As String = ""
    Private _KodePos As String = ""
    Private _Jln As String = ""

    Private _Nama As String = ""
    Private _KTP As String = ""
    Private _Telp As String = ""
    Private _Alamat As String = ""
    Private _Bangunan As String = ""
    Private _RT As String = ""
    Private _RW As String = ""
    Private _NoDlmRT1 As String = ""
    Private _NoDlmRT2 As String = ""

    Private Sub cmdTutup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTutup.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cmdDtlAlamat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDtlAlamat.Click
        Dim pFrmAlamat As New EntriAlamatForm

        With pFrmAlamat
            .ddProp.Text = Propinsi
            .ddKab.Text = Kab
            .ddKec.Text = Kec
            .ddKel.Text = Kel
            .ddLingk.Text = Lingk
            .ddJln.Text = Jln

            If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                txtAlamat.Text = .strAlamat
                Propinsi = .Propinsi
                Kab = .Kab
                Kec = .Kec
                Kel = .Kel
                KodePos = .KodePos
                Lingk = .Lingk
                Jln = .Jln
            End If
        End With
    End Sub

    Private Sub cmdOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub

    Private Sub EntriPemohonForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Nama = Trim(txtNama.Text)
        KTP = Trim(txtKTP.Text)
        Telp = Trim(txtTelp.Text)
        Alamat = Trim(txtAlamat.Text)
        Bangunan = Trim(txtBangunan.Text)
        RT = Trim(txtRT.Text)
        RW = Trim(txtRW.Text)
        NoDlmRT1 = txtNoDlmRT1.Text
        NoDlmRT2 = txtNoDlmRT2.Text
    End Sub

    Private Sub EntriPemohonForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtNama.Text = _Nama
        txtAlamat.Text = _Alamat
        txtKTP.Text = _KTP
        txtTelp.Text = _Telp
        txtBangunan.Text = _Bangunan
        txtRT.Text = _RT
        txtRW.Text = _RW
        txtNoDlmRT1.Text = _NoDlmRT1
        txtNoDlmRT2.Text = _NoDlmRT2
    End Sub

    Private Function getAlamat() As String
        Dim sb As New StringBuilder
        Dim obj As String()
        Dim sNama As String = ""

        'Plan : give DD, Kode Property, so we don't use split anymore.
        obj = Split(Jln, "-") : If obj.Length > 1 Then sNama = obj.GetValue(1)
        If Not sNama = "" Then sb.Append(sNama)

        If txtBangunan.Text <> "" Then sb.Append(" No. " & txtBangunan.Text)

        sNama = ""
        obj = Split(Lingk, "-") : If obj.Length > 1 Then sNama = obj.GetValue(1)
        If Not sNama = "" Then sb.Append(" " & sNama)

        sNama = ""
        obj = Split(Kel, "-") : If obj.Length > 1 Then sNama = obj.GetValue(1)
        If Not sNama = "" Then sb.Append(" Kel. " & sNama)

        If txtRT.Text <> "" Then sb.Append(" Rt. " & txtRT.Text)
        If txtRW.Text <> "" Then sb.Append(" Rw. " & txtRW.Text)

        sNama = ""
        obj = Split(Kec, "-") : If obj.Length > 1 Then sNama = obj.GetValue(1)
        If Not sNama = "" Then sb.Append(" Kec. " & sNama)

        sNama = ""
        obj = Split(Kab, "-") : If obj.Length > 1 Then sNama = obj.GetValue(1)
        If Not sNama = "" Then sb.Append(" Kab. " & sNama)

        obj = Split(Propinsi, "-") : If obj.Length > 1 Then sNama = obj.GetValue(1)
        If Not sNama = "" Then sb.Append(" Pr " & sNama)

        Return Trim(sb.ToString)
    End Function

    Private Sub txtBangunan_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBangunan.TextChanged
        txtAlamat.Text = getAlamat()
    End Sub

    Private Sub txtRT_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRT.TextChanged
        txtAlamat.Text = getAlamat()
    End Sub

    Private Sub txtRW_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRW.TextChanged
        txtAlamat.Text = getAlamat()
    End Sub
End Class