Imports System.Text

Public Class DftrPlgForm

    Private Sub cmdKodeAlamat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdKodeAlamat.Click
        Dim pForm As New EntriAlamatForm
        If pForm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then

        End If
    End Sub

    Private Sub DrawFG()
        Dim dt As New DataTable
        Dim sb As New StringBuilder
        sb.Append(" SELECT  ID_PELANGGAN, NAMA_PLG, ALAMAT  ")
        sb.Append(" FROM SPELANGGAN_TR  ")
        sb.Append(" where NO_TIANG_TRTM LIKE '%2121%'  ")
        sb.Append(" 	  AND ALAMAT LIKE '%Kompleks H.Kalla 3%' ")
        sb.Append(" 	  and rownum between 1 and 10 ")

        GlobalClassV2.Globals.Instance.ExecuteQuery(sb.ToString)

        fg.DataSource = dt
        StyleFG()
    End Sub

    Private Sub StyleFG()
        With fg
            .Cols(1).Caption = "IDPel" : .Cols(2).Caption = "Nama" : .Cols(3).Caption = "Alamat"
        End With
    End Sub

    Private Sub DftrPlgForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DrawFG()
    End Sub
End Class