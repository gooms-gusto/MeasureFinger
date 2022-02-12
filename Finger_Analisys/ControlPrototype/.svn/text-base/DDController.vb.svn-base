Imports EMap.DL_EMap

Public Class DDAddressController

    Private WithEvents _ddKab As DDMaster
    Private WithEvents _ddKec As DDMaster
    Private WithEvents _ddKel As DDMaster
    Private WithEvents _ddLingk As DDMaster

    Sub New(ByVal ddKab As DDMaster, ByVal ddKec As DDMaster, _
                    ByVal ddKel As DDMaster, ByVal ddLingk As DDMaster)
        _ddKab = ddKab
        _ddKec = ddKec
        _ddKel = ddKel
        _ddLingk = ddLingk

        _ddKab.SQLInput = DLSelect.QueryKabupaten(False, "", "", "", "", "")
        _ddKab.SQLValidation = DLSelect.QueryKabupaten(True, "", "", "", "", "")
        _ddKec.SQLInput = DLSelect.QueryKecamatan(False, "", "", "", "", "")
        _ddKec.SQLValidation = DLSelect.QueryKecamatan(True, "", "", "", "", "")
        _ddKel.SQLInput = DLSelect.QueryKelurahan(False, "", "", "", "", "")
        _ddKel.SQLValidation = DLSelect.QueryKelurahan(True, "", "", "", "", "")
        _ddLingk.SQLInput = DLSelect.QueryLingkungan(False, "", "", "", "")
        _ddLingk.SQLValidation = DLSelect.QueryLingkungan(True, "", "", "", "")
    End Sub

    Private Sub _ddKab_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddKab.TextChanged
        If _ddKab.Text = "" Then
            _ddKab.SQLInput = DLSelect.QueryKabupaten(False, "", "", "", "", "")
            _ddKab.SQLValidation = DLSelect.QueryKabupaten(True, "", "", "", "", "")
            _ddKec.ID = ""
            _ddKec.Text = ""
            _ddKel.ID = ""
            _ddKel.Text = ""
            _ddLingk.ID = ""
            _ddLingk.Text = ""
        End If
        _ddKec.SQLInput = DLSelect.QueryKecamatan(False, "", _ddKab.ID, _ddKel.ID, _ddLingk.ID, "")
        _ddKec.SQLValidation = DLSelect.QueryKecamatan(True, "", _ddKab.ID, _ddKel.ID, _ddLingk.ID, "")
        _ddKel.SQLInput = DLSelect.QueryKelurahan(False, "", _ddKab.ID, _ddKec.ID, _ddLingk.ID, "")
        _ddKel.SQLValidation = DLSelect.QueryKelurahan(True, "", _ddKab.ID, _ddKec.ID, _ddLingk.ID, "")
        _ddLingk.SQLInput = DLSelect.QueryLingkungan(False, "", _ddKab.ID, _ddKec.ID, _ddKel.ID)
        _ddLingk.SQLValidation = DLSelect.QueryLingkungan(True, "", _ddKab.ID, _ddKec.ID, _ddKel.ID)
    End Sub

    Private Sub _ddKec_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddKec.TextChanged
        If _ddKec.Text = "" Then
            _ddKel.ID = ""
            _ddKel.Text = ""
            _ddLingk.ID = ""
            _ddLingk.Text = ""
        End If
        _ddKab.SQLInput = DLSelect.QueryKabupaten(False, "", _ddKec.ID, _ddKel.ID, _ddLingk.ID, "")
        _ddKab.SQLValidation = DLSelect.QueryKabupaten(True, "", _ddKec.ID, _ddKel.ID, _ddLingk.ID, "")
        _ddKel.SQLInput = DLSelect.QueryKelurahan(False, "", _ddKab.ID, _ddKec.ID, _ddLingk.ID, "")
        _ddKel.SQLValidation = DLSelect.QueryKelurahan(True, "", _ddKab.ID, _ddKec.ID, _ddLingk.ID, "")
        _ddLingk.SQLInput = DLSelect.QueryLingkungan(False, "", _ddKab.ID, _ddKec.ID, _ddKel.ID)
        _ddLingk.SQLValidation = DLSelect.QueryLingkungan(True, "", _ddKab.ID, _ddKec.ID, _ddKel.ID)
    End Sub

    Private Sub _ddKel_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddKel.TextChanged
        If _ddKel.Text = "" Then
            _ddLingk.ID = ""
            _ddLingk.Text = ""
        End If
        _ddKab.SQLInput = DLSelect.QueryKabupaten(False, "", _ddKec.ID, _ddKel.ID, _ddLingk.ID, "")
        _ddKab.SQLValidation = DLSelect.QueryKabupaten(True, "", _ddKec.ID, _ddKel.ID, _ddLingk.ID, "")
        _ddKec.SQLInput = DLSelect.QueryKecamatan(False, "", _ddKab.ID, _ddKel.ID, _ddLingk.ID, "")
        _ddKec.SQLValidation = DLSelect.QueryKecamatan(True, "", _ddKab.ID, _ddKel.ID, _ddLingk.ID, "")
        _ddLingk.SQLInput = DLSelect.QueryLingkungan(False, "", _ddKab.ID, _ddKec.ID, _ddKel.ID)
        _ddLingk.SQLValidation = DLSelect.QueryLingkungan(True, "", _ddKab.ID, _ddKec.ID, _ddKel.ID)
    End Sub

    Private Sub _ddLingk_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddLingk.TextChanged
        _ddKab.SQLInput = DLSelect.QueryKabupaten(False, "", _ddKec.ID, _ddKel.ID, _ddLingk.ID, "")
        _ddKab.SQLValidation = DLSelect.QueryKabupaten(True, "", _ddKec.ID, _ddKel.ID, _ddLingk.ID, "")
        _ddKec.SQLInput = DLSelect.QueryKecamatan(False, "", _ddKab.ID, _ddKel.ID, _ddLingk.ID, "")
        _ddKec.SQLValidation = DLSelect.QueryKecamatan(True, "", _ddKab.ID, _ddKel.ID, _ddLingk.ID, "")
        _ddKel.SQLInput = DLSelect.QueryKelurahan(False, "", _ddKab.ID, _ddKec.ID, _ddLingk.ID, "")
        _ddKel.SQLValidation = DLSelect.QueryKelurahan(True, "", _ddKab.ID, _ddKec.ID, _ddLingk.ID, "")
    End Sub

    Private Sub _ddKec_Selected() Handles _ddKec.Selected
        If _ddKec.Text = "" Then
            _ddKab.Text = ""
            Exit Sub
        End If
        _ddKab.Text = DLSelect.FindKab(_ddKec.ID)
    End Sub

    Private Sub _ddKel_Selected() Handles _ddKel.Selected
        If _ddKel.Text = "" Then
            _ddKab.Text = "" : _ddKec.Text = ""
            Exit Sub
        End If
        _ddKec.Text = DLSelect.FindKec(_ddKel.ID)
        _ddKab.Text = DLSelect.FindKab(_ddKec.ID)
    End Sub

    Private Sub _ddLingk_Selected() Handles _ddLingk.Selected
        If _ddLingk.Text = "" Then
            _ddKab.Text = "" : _ddKec.Text = "" : _ddKel.Text = ""
            Exit Sub
        End If
        _ddKel.Text = DLSelect.FindKel(True, _ddLingk.ID, "")
        _ddKec.Text = DLSelect.FindKec(_ddKel.ID)
        _ddKab.Text = DLSelect.FindKab(_ddKec.ID)
    End Sub

End Class

Public Class DDUPIAPUPController
    Private WithEvents _ddUPI As DDMaster
    Private WithEvents _ddAP As DDMaster
    Private WithEvents _ddUP As DDMaster

    Sub New(ByVal ddUPI As DDMaster, ByVal ddAP As DDMaster, ByVal ddUP As DDMaster)
        _ddUPI = ddUPI
        _ddAP = ddAP
        _ddUP = ddUP

        _ddUPI.SQLInput = DLSelect.QueryUPI(False, "", "", "", "", "")
        _ddUPI.SQLValidation = DLSelect.QueryUPI(True, "", "", "", "", "")
        _ddAP.SQLInput = DLSelect.QueryAP(False, "", "", "", "", "")
        _ddAP.SQLValidation = DLSelect.QueryAP(True, "", "", "", "", "")
        _ddUP.SQLInput = DLSelect.QueryUP(False, "", "", "", "", "")
        _ddUP.SQLValidation = DLSelect.QueryUP(True, "", "", "", "", "")
    End Sub

    Private Sub _ddUPI_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddUPI.TextChanged
        If _ddUPI.Text = "" Then
            _ddUPI.SQLInput = DLSelect.QueryUPI(False, "", "", "", "", "")
            _ddUPI.SQLValidation = DLSelect.QueryUPI(True, "", "", "", "", "")
            _ddAP.ID = ""
            _ddAP.Text = ""
            _ddUP.ID = ""
            _ddUP.Text = ""
        End If
        _ddAP.SQLInput = DLSelect.QueryAP(False, _ddUPI.ID, _ddUP.ID, "", "", "")
        _ddAP.SQLValidation = DLSelect.QueryAP(True, _ddUPI.ID, _ddUP.ID, "", "", "")

        _ddUP.SQLInput = DLSelect.QueryUP(False, _ddUPI.ID, _ddAP.ID, "", "", "")
        _ddUP.SQLValidation = DLSelect.QueryUP(True, _ddUPI.ID, _ddAP.ID, "", "", "")
    End Sub

    Private Sub _ddAP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddAP.TextChanged
        If _ddAP.Text = "" Then
            _ddUP.ID = ""
            _ddUP.Text = ""
        End If
        _ddUPI.SQLInput = DLSelect.QueryUPI(False, _ddAP.ID, _ddUP.ID, "", "", "")
        _ddUPI.SQLValidation = DLSelect.QueryUPI(True, _ddAP.ID, _ddUP.ID, "", "", "")
        _ddUP.SQLInput = DLSelect.QueryUP(False, _ddUPI.ID, _ddAP.ID, "", "", "")
        _ddUP.SQLValidation = DLSelect.QueryUP(True, _ddUPI.ID, _ddAP.ID, "", "", "")
    End Sub

    Private Sub _ddUP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddUP.TextChanged
        _ddUPI.SQLInput = DLSelect.QueryUPI(False, _ddAP.ID, _ddUP.ID, "", "", "")
        _ddUPI.SQLValidation = DLSelect.QueryUPI(True, _ddAP.ID, _ddUP.ID, "", "", "")
        _ddAP.SQLInput = DLSelect.QueryAP(False, _ddUPI.ID, _ddUP.ID, "", "", "")
        _ddAP.SQLValidation = DLSelect.QueryAP(True, _ddUPI.ID, _ddUP.ID, "", "", "")
    End Sub

    Private Sub _ddAP_Selected() Handles _ddAP.Selected
        If _ddAP.Text = "" Then
            _ddUPI.Text = ""
            Exit Sub
        End If
        _ddUPI.Text = DLSelect.FindUPI(_ddAP.ID)
    End Sub

    Private Sub _ddUP_Selected() Handles _ddUP.Selected
        If _ddUP.Text = "" Then
            _ddAP.Text = "" : _ddUPI.Text = "" : Exit Sub
        End If
        _ddAP.Text = DLSelect.FindAP(_ddUP.ID)
        _ddUPI.Text = DLSelect.FindUPI(_ddAP.ID)
    End Sub
End Class

Public Class DDUnitController
    Private WithEvents _ddUPI As DDMaster
    Private WithEvents _ddAP As DDMaster
    Private WithEvents _ddUP As DDMaster
    Private WithEvents _ddSubUP As DDMaster

    Private WithEvents _ddAJ As DDMaster
    Private WithEvents _ddUJ As DDMaster

    Sub New(ByVal ddUPI As DDMaster, ByVal ddAP As DDMaster, ByVal ddUP As DDMaster, _
                  ByVal ddSubUP As DDMaster, ByVal ddAJ As DDMaster, ByVal ddUJ As DDMaster)
        _ddUPI = ddUPI
        _ddAP = ddAP
        _ddUP = ddUP
        _ddSubUP = ddSubUP

        _ddAJ = ddAJ
        _ddUJ = ddUJ

        _ddUPI.SQLInput = DLSelect.QueryUPI(False, "", "", "", "", "")
        _ddUPI.SQLValidation = DLSelect.QueryUPI(True, "", "", "", "", "")
        _ddAP.SQLInput = DLSelect.QueryAP(False, "", "", "", "", "")
        _ddAP.SQLValidation = DLSelect.QueryAP(True, "", "", "", "", "")
        _ddUP.SQLInput = DLSelect.QueryUP(False, "", "", "", "", "")
        _ddUP.SQLValidation = DLSelect.QueryUP(True, "", "", "", "", "")
        _ddSubUP.SQLInput = DLSelect.QuerySubUP(False, "", "", "", "", "")
        _ddSubUP.SQLValidation = DLSelect.QuerySubUP(True, "", "", "", "", "")

        _ddAJ.SQLInput = DLSelect.QueryAJ(False, "", "")
        _ddAJ.SQLValidation = DLSelect.QueryAJ(True, "", "")
        _ddUJ.SQLInput = DLSelect.QueryUJ(False, "", "")
        _ddUJ.SQLValidation = DLSelect.QueryUJ(True, "", "")
    End Sub

    Private Sub _ddUPI_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddUPI.TextChanged
        _ddAP.SQLInput = DLSelect.QueryAP(False, _ddUPI.ID, _ddUP.ID, _ddSubUP.ID, _ddAJ.ID, _ddUJ.ID)
        _ddAP.SQLValidation = DLSelect.QueryAP(True, _ddUPI.ID, _ddUP.ID, _ddSubUP.ID, _ddAJ.ID, _ddUJ.ID)

        _ddUP.SQLInput = DLSelect.QueryUP(False, _ddUPI.ID, _ddAP.ID, _ddSubUP.ID, _ddAJ.ID, _ddUJ.ID)
        _ddUP.SQLValidation = DLSelect.QueryUP(True, _ddUPI.ID, _ddAP.ID, _ddSubUP.ID, _ddAJ.ID, _ddUJ.ID)
        _ddSubUP.SQLInput = DLSelect.QuerySubUP(False, _ddUPI.ID, _ddAP.ID, _ddUP.ID, _ddAJ.ID, _ddUJ.ID)
        _ddSubUP.SQLValidation = DLSelect.QuerySubUP(True, _ddUPI.ID, _ddAP.ID, _ddUP.ID, _ddAJ.ID, _ddUJ.ID)


        _ddAJ.SQLInput = DLSelect.QueryAJ(False, _ddUPI.ID, _ddUJ.ID)
        _ddAJ.SQLValidation = DLSelect.QueryAJ(True, _ddUPI.ID, _ddUJ.ID)
        _ddUJ.SQLInput = DLSelect.QueryUJ(False, _ddUPI.ID, _ddAJ.ID)
        _ddUJ.SQLValidation = DLSelect.QueryUJ(True, _ddUPI.ID, _ddAJ.ID)
    End Sub

    Private Sub _ddAP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddAP.TextChanged
        _ddUPI.SQLInput = DLSelect.QueryUPI(False, _ddAP.ID, _ddUP.ID, _ddSubUP.ID, _ddAJ.ID, _ddUJ.ID)
        _ddUPI.SQLValidation = DLSelect.QueryUPI(True, _ddAP.ID, _ddUP.ID, _ddSubUP.ID, _ddAJ.ID, _ddUJ.ID)
        _ddUP.SQLInput = DLSelect.QueryUP(False, _ddUPI.ID, _ddAP.ID, _ddSubUP.ID, _ddAJ.ID, _ddUJ.ID)
        _ddUP.SQLValidation = DLSelect.QueryUP(True, _ddUPI.ID, _ddAP.ID, _ddSubUP.ID, _ddAJ.ID, _ddUJ.ID)


        _ddSubUP.SQLInput = DLSelect.QuerySubUP(False, _ddUPI.ID, _ddAP.ID, _ddUP.ID, _ddAJ.ID, _ddUJ.ID)
        _ddSubUP.SQLValidation = DLSelect.QuerySubUP(True, _ddUPI.ID, _ddAP.ID, _ddUP.ID, _ddAJ.ID, _ddUJ.ID)
    End Sub

    Private Sub _ddUP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddUP.TextChanged
        _ddUPI.SQLInput = DLSelect.QueryUPI(False, _ddAP.ID, _ddUP.ID, _ddSubUP.ID, _ddAJ.ID, _ddUJ.ID)
        _ddUPI.SQLValidation = DLSelect.QueryUPI(True, _ddAP.ID, _ddUP.ID, _ddSubUP.ID, _ddAJ.ID, _ddUJ.ID)
        _ddAP.SQLInput = DLSelect.QueryAP(False, _ddUPI.ID, _ddUP.ID, _ddSubUP.ID, _ddAJ.ID, _ddUJ.ID)
        _ddAP.SQLValidation = DLSelect.QueryAP(True, _ddUPI.ID, _ddUP.ID, _ddSubUP.ID, _ddAJ.ID, _ddUJ.ID)
        _ddSubUP.SQLInput = DLSelect.QuerySubUP(False, _ddUPI.ID, _ddAP.ID, _ddUP.ID, _ddAJ.ID, _ddUJ.ID)
        _ddSubUP.SQLValidation = DLSelect.QuerySubUP(True, _ddUPI.ID, _ddAP.ID, _ddUP.ID, _ddAJ.ID, _ddUJ.ID)
    End Sub

    Private Sub _ddSubUP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddSubUP.TextChanged
        _ddUPI.SQLInput = DLSelect.QueryUPI(False, _ddAP.ID, _ddUP.ID, _ddSubUP.ID, _ddAJ.ID, _ddUJ.ID)
        _ddUPI.SQLValidation = DLSelect.QueryUPI(True, _ddAP.ID, _ddUP.ID, _ddSubUP.ID, _ddAJ.ID, _ddUJ.ID)
        _ddAP.SQLInput = DLSelect.QueryAP(False, _ddUPI.ID, _ddUP.ID, _ddSubUP.ID, _ddAJ.ID, _ddUJ.ID)
        _ddAP.SQLValidation = DLSelect.QueryAP(True, _ddUPI.ID, _ddUP.ID, _ddSubUP.ID, _ddAJ.ID, _ddUJ.ID)
        _ddUP.SQLInput = DLSelect.QueryUP(False, _ddUPI.ID, _ddAP.ID, _ddSubUP.ID, _ddAJ.ID, _ddUJ.ID)
        _ddUP.SQLValidation = DLSelect.QueryUP(True, _ddUPI.ID, _ddAP.ID, _ddSubUP.ID, _ddAJ.ID, _ddUJ.ID)
    End Sub

    Private Sub _ddAJ_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddAJ.TextChanged
        _ddUPI.SQLInput = DLSelect.QueryUPI(False, _ddAP.ID, _ddUP.ID, _ddSubUP.ID, _ddAJ.ID, _ddUJ.ID)
        _ddUPI.SQLValidation = DLSelect.QueryUPI(True, _ddAP.ID, _ddUP.ID, _ddSubUP.ID, _ddAJ.ID, _ddUJ.ID)
        _ddUJ.SQLInput = DLSelect.QueryUJ(False, _ddUPI.ID, _ddAJ.ID)
        _ddUJ.SQLValidation = DLSelect.QueryUJ(True, _ddUPI.ID, _ddAJ.ID)
    End Sub

    Private Sub _ddUJ_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddUJ.TextChanged
        _ddUPI.SQLInput = DLSelect.QueryUPI(False, _ddAP.ID, _ddUP.ID, _ddSubUP.ID, _ddAJ.ID, _ddUJ.ID)
        _ddUPI.SQLValidation = DLSelect.QueryUPI(True, _ddAP.ID, _ddUP.ID, _ddSubUP.ID, _ddAJ.ID, _ddUJ.ID)
        _ddAJ.SQLInput = DLSelect.QueryAJ(False, _ddUPI.ID, _ddUJ.ID)
        _ddAJ.SQLValidation = DLSelect.QueryAJ(True, _ddUPI.ID, _ddUJ.ID)
    End Sub

    Private Sub _ddAP_Selected() Handles _ddAP.Selected
        If _ddAP.Text = "" Then
            _ddUPI.Text = ""
            Exit Sub
        End If
        _ddUPI.Text = DLSelect.FindUPI(_ddAP.ID)
    End Sub

    Private Sub _ddUP_Selected() Handles _ddUP.Selected
        If _ddUP.Text = "" Then
            _ddAP.Text = "" : _ddUPI.Text = "" : Exit Sub
        End If
        _ddAP.Text = DLSelect.FindAP(_ddUP.ID)
        _ddUPI.Text = DLSelect.FindUPI(_ddAP.ID)
    End Sub

    Private Sub _ddSubUP_Selected() Handles _ddSubUP.Selected
        If _ddSubUP.Text = "" Then
            _ddUP.Text = "" : _ddAP.Text = "" : _ddUPI.Text = "" : Exit Sub
        End If
        _ddUP.Text = DLSelect.FindUP(_ddSubUP.ID)
        _ddAP.Text = DLSelect.FindAP(_ddUP.ID)
        _ddUPI.Text = DLSelect.FindUPI(_ddAP.ID)
    End Sub

    Private Sub _ddUJ_Selected() Handles _ddUJ.Selected
        If _ddUJ.Text = "" Then _ddAJ.Text = ""
        _ddAJ.Text = DLSelect.FindAJ(_ddUJ.ID)
    End Sub

   
End Class


Public Class DDUPIAPAJController
    Private WithEvents _ddUPI As DDMaster
    Private WithEvents _ddAP As DDMaster
    Private WithEvents _ddAJ As DDMaster

    Sub New(ByVal ddUPI As DDMaster, ByVal ddAP As DDMaster, _
                 ByVal ddAJ As DDMaster)
        _ddUPI = ddUPI
        _ddAP = ddAP

        _ddAJ = ddAJ

        _ddUPI.SQLInput = DLSelect.QueryUPI(False, "", "", "", "", "")
        _ddUPI.SQLValidation = DLSelect.QueryUPI(True, "", "", "", "", "")
        _ddAP.SQLInput = DLSelect.QueryAP(False, "", "", "", "", "")
        _ddAP.SQLValidation = DLSelect.QueryAP(True, "", "", "", "", "")

        _ddAJ.SQLInput = DLSelect.QueryAJ(False, "", "")
        _ddAJ.SQLValidation = DLSelect.QueryAJ(True, "", "")
    End Sub

    Private Sub _ddUPI_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddUPI.TextChanged
        _ddAP.SQLInput = DLSelect.QueryAP(False, _ddUPI.ID, "", "", _ddAJ.ID, "")
        _ddAP.SQLValidation = DLSelect.QueryAP(True, _ddUPI.ID, "", "", _ddAJ.ID, "")

        _ddAJ.SQLInput = DLSelect.QueryAJ(False, _ddUPI.ID, "")
        _ddAJ.SQLValidation = DLSelect.QueryAJ(True, _ddUPI.ID, "")
    End Sub

    Private Sub _ddAP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddAP.TextChanged
        _ddUPI.SQLInput = DLSelect.QueryUPI(False, _ddAP.ID, "", "", _ddAJ.ID, "")
        _ddUPI.SQLValidation = DLSelect.QueryUPI(True, _ddAP.ID, "", "", _ddAJ.ID, "")
    End Sub

    Private Sub _ddAJ_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddAJ.TextChanged
        _ddUPI.SQLInput = DLSelect.QueryUPI(False, _ddAP.ID, "", "", _ddAJ.ID, "")
        _ddUPI.SQLValidation = DLSelect.QueryUPI(True, _ddAP.ID, "", "", _ddAJ.ID, "")
    End Sub

    Private Sub _ddAP_Selected() Handles _ddAP.Selected
        If _ddAP.Text = "" Then
            _ddUPI.Text = ""
            Exit Sub
        End If
        _ddUPI.Text = DLSelect.FindUPI(_ddAP.ID)
    End Sub

End Class

Public Class DDAJAPUPController

    Private WithEvents _ddAJ As DDMaster
    Private WithEvents _ddAP As DDMaster
    Private WithEvents _ddUP As DDMaster

    Sub New(ByVal ddAJ As DDMaster, ByVal ddAP As DDMaster, _
                 ByVal ddUP As DDMaster)
        _ddAJ = ddAJ
        _ddAP = ddAP
        _ddUP = ddUP

        _ddAJ.SQLInput = "SELECT TRIM(AJ.KODE_AJ) KODE_AJ, TRIM(AJ.NAMA_AJ) FROM  AJ ORDER BY KODE_AJ"
        _ddAJ.SQLValidation = "SELECT TRIM(AJ.KODE_AJ) SELECT1, TRIM(AJ.NAMA_AJ) SELECT2 FROM  AJ WHERE UPPER(AJ.KODE_AJ) LIKE UPPER('%myFilter%') ORDER BY KODE_AJ"
        _ddAP.SQLInput = "SELECT TRIM(AP.KODE_AP) KODE_AP, TRIM(AP.NAMAAP) FROM AP ORDER BY KODE_AP"
        _ddAP.SQLValidation = "SELECT TRIM(AP.KODE_AP) SELECT1, TRIM(AP.NAMAAP) SELECT2 FROM AP WHERE UPPER(AP.KODE_AP) LIKE UPPER('%myFilter%') ORDER BY KODE_AP"
        _ddUP.SQLInput = "SELECT TRIM(UP.KODE_UP) KODE_UP, TRIM(UP.NAMAUP) FROM UP ORDER BY KODE_UP"
        _ddUP.SQLValidation = "SELECT TRIM(UP.KODE_UP) SELECT1, TRIM(UP.NAMAUP) SELECT2 FROM UP WHERE UPPER(UP.KODE_UP) LIKE UPPER('%myFilter%') ORDER BY KODE_UP"
    End Sub

    Private Sub _ddAJ_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddAJ.TextChanged
        If _ddAJ.ID <> "" Then
            _ddAP.SQLInput = "SELECT TRIM(AP.KODE_AP) KODE_AP, TRIM(AP.NAMAAP) FROM AP WHERE KODE_AJ='" & _ddAJ.ID & "' ORDER BY KODE_AP"
            _ddAP.SQLValidation = "SELECT TRIM(AP.KODE_AP) SELECT1, TRIM(AP.NAMAAP) SELECT2 FROM AP WHERE KODE_AJ='" & _ddAJ.ID & "' AND UPPER(AP.KODE_AP) LIKE UPPER('%myFilter%') ORDER BY KODE_AP"
            _ddUP.SQLInput = "SELECT TRIM(UP.KODE_UP) KODE_UP, TRIM(UP.NAMAUP) FROM UP WHERE UP.KODE_AP IN (SELECT KODE_AP FROM AP WHERE KODE_AJ='" & _ddAJ.ID & "') ORDER BY KODE_UP"
            _ddUP.SQLValidation = "SELECT TRIM(UP.KODE_UP) SELECT1, TRIM(UP.NAMAUP) SELECT2 FROM UP WHERE UP.KODE_AP IN (SELECT KODE_AP FROM AP WHERE KODE_AJ='" & _ddAJ.ID & "') AND UPPER(UP.KODE_UP) LIKE UPPER('%myFilter%') ORDER BY KODE_UP"
        Else
            _ddAP.SQLInput = "SELECT TRIM(AP.KODE_AP) KODE_AP, TRIM(AP.NAMAAP) FROM AP ORDER BY KODE_AP"
            _ddAP.SQLValidation = "SELECT TRIM(AP.KODE_AP) SELECT1, TRIM(AP.NAMAAP) SELECT2 FROM AP WHERE UPPER(AP.KODE_AP) LIKE UPPER('%myFilter%') ORDER BY KODE_AP"
            _ddUP.SQLInput = "SELECT TRIM(UP.KODE_UP) KODE_UP, TRIM(UP.NAMAUP) FROM UP ORDER BY KODE_UP"
            _ddUP.SQLValidation = "SELECT TRIM(UP.KODE_UP) SELECT1, TRIM(UP.NAMAUP) SELECT2 FROM UP WHERE UPPER(UP.KODE_UP) LIKE UPPER('%myFilter%') ORDER BY KODE_UP"
        End If
    End Sub

    Private Sub _ddAP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddAP.TextChanged
        If _ddAP.ID <> "" Then
            _ddAJ.SQLInput = "SELECT TRIM(AJ.KODE_AJ) KODE_AJ, TRIM(AJ.NAMA_AJ) FROM AJ WHERE KODE_AJ IN (SELECT KODE_AJ FROM AP WHERE KODE_AP='" & _ddAP.ID & "') ORDER BY KODE_AJ"
            _ddAJ.SQLValidation = "SELECT TRIM(AJ.KODE_AJ) SELECT1, TRIM(AJ.NAMA_AJ) SELECT2 FROM  AJ WHERE KODE_AJ IN (SELECT KODE_AJ FROM AP WHERE KODE_AP='" & _ddAP.ID & "') AND UPPER(AJ.KODE_AJ) LIKE UPPER('%myFilter%') ORDER BY KODE_AJ"
            _ddUP.SQLInput = "SELECT TRIM(UP.KODE_UP) KODE_UP, TRIM(UP.NAMAUP) FROM UP WHERE UP.KODE_AP='" & _ddAP.ID & "' ORDER BY KODE_UP"
            _ddUP.SQLValidation = "SELECT TRIM(UP.KODE_UP) SELECT1, TRIM(UP.NAMAUP) SELECT2 FROM UP WHERE UP.KODE_AP='" & _ddAP.ID & "' AND UPPER(UP.KODE_UP) LIKE UPPER('%myFilter%') ORDER BY KODE_UP"
        Else
            _ddAJ.SQLInput = "SELECT TRIM(AJ.KODE_AJ) KODE_AJ, TRIM(AJ.NAMA_AJ) FROM  AJ ORDER BY KODE_AJ"
            _ddAJ.SQLValidation = "SELECT TRIM(AJ.KODE_AJ) SELECT1, TRIM(AJ.NAMA_AJ) SELECT2 FROM  AJ WHERE UPPER(AJ.KODE_AJ) LIKE UPPER('%myFilter%') ORDER BY KODE_AJ"
            If _ddAJ.ID <> "" Then
                _ddUP.SQLInput = "SELECT TRIM(UP.KODE_UP) KODE_UP, TRIM(UP.NAMAUP) FROM UP WHERE UP.KODE_AP IN (SELECT KODE_AP FROM AP WHERE KODE_AJ='" & _ddAJ.ID & "') ORDER BY KODE_UP"
                _ddUP.SQLValidation = "SELECT TRIM(UP.KODE_UP) SELECT1, TRIM(UP.NAMAUP) SELECT2 FROM UP WHERE UP.KODE_AP IN (SELECT KODE_AP FROM AP WHERE KODE_AJ='" & _ddAJ.ID & "') AND UPPER(UP.KODE_UP) LIKE UPPER('%myFilter%') ORDER BY KODE_UP"
            Else
                _ddUP.SQLInput = "SELECT TRIM(UP.KODE_UP) KODE_UP, TRIM(UP.NAMAUP) FROM UP ORDER BY KODE_UP"
                _ddUP.SQLValidation = "SELECT TRIM(UP.KODE_UP) SELECT1, TRIM(UP.NAMAUP) SELECT2 FROM UP WHERE UPPER(UP.KODE_UP) LIKE UPPER('%myFilter%') ORDER BY KODE_UP"
            End If
        End If
    End Sub

    Private Sub _ddUP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddUP.TextChanged
        If _ddUP.ID <> "" Then
            _ddAJ.SQLInput = "SELECT TRIM(AJ.KODE_AJ) KODE_AJ, TRIM(AJ.NAMA_AJ) FROM AJ WHERE KODE_AJ IN (SELECT AP.KODE_AJ FROM AP, UP WHERE AP.KODE_AP=UP.KODE_UP AND UP.KODE_UP='" & _ddUP.ID & "') ORDER BY KODE_AJ"
            _ddAJ.SQLValidation = "SELECT TRIM(AJ.KODE_AJ) SELECT1, TRIM(AJ.NAMA_AJ) SELECT2 FROM  AJ WHERE KODE_AJ IN (SELECT AP.KODE_AJ FROM AP, UP WHERE AP.KODE_AP=UP.KODE_UP AND UP.KODE_UP='" & _ddUP.ID & "') AND UPPER(AJ.KODE_AJ) LIKE UPPER('%myFilter%') ORDER BY KODE_AJ"
            _ddAP.SQLInput = "SELECT TRIM(AP.KODE_AP) KODE_AP, TRIM(AP.NAMAAP) FROM AP WHERE KODE_AP=(SELECT KODE_AP FROM UP WHERE KODE_UP='" & _ddUP.ID & "') ORDER BY KODE_AP"
            _ddAP.SQLValidation = "SELECT TRIM(AP.KODE_AP) SELECT1, TRIM(AP.NAMAAP) SELECT2 FROM AP WHERE KODE_AP=(SELECT KODE_AP FROM UP WHERE KODE_UP='" & _ddUP.ID & "') AND UPPER(AP.KODE_AP) LIKE UPPER('%myFilter%') ORDER BY KODE_AP"
        End If
    End Sub

    Private Sub _ddAP_Selected() Handles _ddAP.Selected
        _ddAJ.FillMe(DLSelect.FindKodeAJByAP(_ddAP.ID))
    End Sub

    Private Sub _ddUP_Selected() Handles _ddUP.Selected
        _ddAP.FillMe(DLSelect.FindKodeAP(_ddUP.ID))
    End Sub

End Class

Public Class DDGIFeederController
    Private WithEvents _ddGI As DDMaster
    Private WithEvents _ddFeeder As DDMaster

    Sub New(ByVal ddGI As DDMaster, ByVal ddFeeder As DDMaster)
        _ddGI = ddGI : _ddFeeder = ddFeeder

        _ddGI.SQLInput = DLSelect.QueryGI(False, "", "")
        _ddGI.SQLValidation = DLSelect.QueryGI(True, "", "")
        _ddFeeder.SQLInput = DLSelect.QueryFeeder(False, "", "")
        _ddFeeder.SQLValidation = DLSelect.QueryFeeder(True, "", "")
    End Sub

    Private Sub _ddGI_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddGI.TextChanged
        _ddFeeder.SQLInput = DLSelect.QueryFeeder(False, _ddGI.ID, "")
        _ddFeeder.SQLValidation = DLSelect.QueryFeeder(True, _ddGI.ID, "")
    End Sub

    Private Sub _ddFeeder_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddFeeder.TextChanged
        _ddGI.SQLInput = DLSelect.QueryGI(False, _ddFeeder.ID, "")
        _ddGI.SQLValidation = DLSelect.QueryGI(True, _ddFeeder.ID, "")
    End Sub

    Private Sub _ddFeeder_Selected() Handles _ddFeeder.Selected
        If _ddFeeder.Text = "" Then _ddGI.Text = "" : Exit Sub
        _ddGI.FillMe(DLSelect.FindGI(_ddFeeder.ID))
    End Sub

End Class

Public Class DDSectionZoneController
    Private WithEvents _ddSection As DDMaster
    Private WithEvents _ddZone As DDMaster

    Sub New(ByVal ddSection As DDMaster, ByVal ddZone As DDMaster, Optional ByVal IDFeeder As String = "")
        _ddSection = ddSection
        _ddZone = ddZone

        _ddSection.SQLInput = DLSelect.Query_Section(False, IDFeeder)
        _ddSection.SQLValidation = DLSelect.Query_Section(True, IDFeeder)
        _ddZone.SQLInput = DLSelect.Query_Zone(False, "", IDFeeder)
        _ddZone.SQLValidation = DLSelect.Query_Zone(True, "", IDFeeder)
    End Sub

    Private Sub _ddSection_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddSection.TextChanged
        _ddZone.SQLInput = DLSelect.Query_Zone(False, _ddSection.ID, "")
        _ddZone.SQLValidation = DLSelect.Query_Zone(True, _ddSection.ID, "")
    End Sub

    Private Sub _ddZone_Selected() Handles _ddZone.Selected
        If _ddZone.Text = "" Then _ddSection.Text = "" : Exit Sub
        _ddSection.FillMe(_ddZone.DataRow(2).ToString)
    End Sub

End Class

Public Class DDSectionZoneController2
    Private WithEvents _ddSection As DDMaster
    Private WithEvents _ddZone As DDMaster

    Sub New(ByVal ddSection As DDMaster, ByVal ddZone As DDMaster)
        _ddSection = ddSection
        _ddZone = ddZone

        _ddSection.SQLInput = DLSelect.QuerySection(False, "")
        _ddSection.SQLValidation = DLSelect.QuerySection(True, "")
        _ddZone.SQLInput = DLSelect.QueryZone(False, "")
        _ddZone.SQLValidation = DLSelect.QueryZone(True, "")
    End Sub

    Private Sub _ddSection_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddSection.TextChanged
        _ddZone.SQLInput = DLSelect.QueryZone(False, _ddSection.ID)
        _ddZone.SQLValidation = DLSelect.QueryZone(True, _ddSection.ID)
    End Sub

    Private Sub _ddZone_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddZone.TextChanged
        _ddSection.SQLInput = DLSelect.QuerySection(False, _ddZone.ID)
        _ddSection.SQLValidation = DLSelect.QuerySection(True, _ddZone.ID)
    End Sub

    Private Sub _ddZone_Selected() Handles _ddZone.Selected
        _ddSection.Text = DLSelect.FindSection(_ddZone.DataRowValue("ID_ZONE"))
    End Sub

End Class

Public Class DDGITrafoFeederController
    Private WithEvents _ddGI As DDMaster
    Private WithEvents _ddFeeder As DDMaster
    Private WithEvents _ddTrafo As DDMaster


    Sub New(ByVal ddGI As DDMaster, ByVal ddFeeder As DDMaster, ByVal ddTrafo As DDMaster)
        _ddGI = ddGI
        _ddFeeder = ddFeeder
        _ddTrafo = ddTrafo
        _ddGI.SQLInput = DLSelect.QueryGI(False, "", "")
        _ddGI.SQLValidation = DLSelect.QueryGI(True, "", "")
        _ddFeeder.SQLInput = DLSelect.QueryFeeder(False, "", "")
        _ddFeeder.SQLValidation = DLSelect.QueryFeeder(True, "", "")
        _ddTrafo.SQLInput = DLSelect.QueryTrafo(False, "", "")
        _ddTrafo.SQLValidation = DLSelect.QueryTrafo(True, "", "")
    End Sub

    Private Sub _ddGI_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddGI.TextChanged
        If _ddGI.Text = "" Then
            _ddGI.SQLInput = DLSelect.QueryGI(False, "", "")
            _ddGI.SQLValidation = DLSelect.QueryGI(True, "", "")
        End If
        _ddTrafo.SQLInput = DLSelect.QueryTrafo(False, _ddGI.ID, "")
        _ddTrafo.SQLValidation = DLSelect.QueryTrafo(True, _ddGI.ID, "")
        _ddFeeder.SQLInput = DLSelect.QueryFeeder(False, _ddGI.ID, "")
        _ddFeeder.SQLValidation = DLSelect.QueryFeeder(True, _ddGI.ID, "")
    End Sub

    Private Sub _ddFeeder_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddFeeder.TextChanged
        _ddTrafo.SQLInput = DLSelect.QueryTrafo(False, "", _ddFeeder.ID)
        _ddTrafo.SQLValidation = DLSelect.QueryTrafo(True, "", _ddFeeder.ID)
        _ddGI.SQLInput = DLSelect.QueryGI(False, _ddFeeder.ID, "")
        _ddGI.SQLValidation = DLSelect.QueryGI(True, _ddFeeder.ID, "")
    End Sub
    Private Sub _ddTrafo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddTrafo.TextChanged
        If _ddTrafo.Text = "" Then
        End If
        _ddGI.SQLInput = DLSelect.QueryTrafoGIFeeder(False, DLSelect.FlagTrafoGIFeeder.GI, _ddTrafo.ID)
        _ddGI.SQLValidation = DLSelect.QueryTrafoGIFeeder(True, DLSelect.FlagTrafoGIFeeder.GI, _ddTrafo.ID)
        _ddFeeder.SQLInput = DLSelect.QueryTrafoGIFeeder(False, DLSelect.FlagTrafoGIFeeder.Feeder, _ddTrafo.ID)
        _ddFeeder.SQLValidation = DLSelect.QueryTrafoGIFeeder(True, DLSelect.FlagTrafoGIFeeder.Feeder, _ddTrafo.ID)
    End Sub

    Private Sub _ddFeeder_Selected() Handles _ddFeeder.Selected
        If _ddFeeder.Text = "" Then _ddTrafo.Text = "" : Exit Sub
        _ddTrafo.FillMe(DLSelect.FindTrafoGI(_ddFeeder.ID))
        _ddGI.FillMe(DLSelect.FindGI(_ddFeeder.ID))
    End Sub
    Private Sub _ddTrafo_Selected() Handles _ddTrafo.Selected
        If _ddTrafo.Text = "" Then _ddGI.Text = "" : Exit Sub
        _ddGI.FillMe(DLSelect.FindGIByTrafo(_ddTrafo.ID))
    End Sub
End Class

Public Class DDGDJurusanController
    Private WithEvents _ddGD As DDMaster
    Private WithEvents _ddJurusan As DDMaster

    Sub New(ByVal ddGD As DDMaster, ByVal ddJurusan As DDMaster)
        _ddGD = ddGD : _ddJurusan = ddJurusan

        _ddGD.SQLInput = DLSelect.QueryGDJurusan(False, "")
        _ddGD.SQLValidation = DLSelect.QueryGDJurusan(True, "")
        _ddJurusan.SQLInput = DLSelect.QueryJurusanGD(False, "")
        _ddJurusan.SQLValidation = DLSelect.QueryJurusanGD(True, "")
    End Sub

    Private Sub _ddGD_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddGD.TextChanged
        _ddJurusan.SQLInput = DLSelect.QueryJurusanGD(False, _ddGD.ID)
        _ddJurusan.SQLValidation = DLSelect.QueryJurusanGD(True, _ddGD.ID)
    End Sub

    Private Sub _ddJurusan_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddJurusan.TextChanged
        _ddGD.SQLInput = DLSelect.QueryGDJurusan(False, _ddJurusan.ID)
        _ddGD.SQLValidation = DLSelect.QueryGDJurusan(True, _ddJurusan.ID)
    End Sub

    Private Sub _ddJurusan_Selected() Handles _ddJurusan.Selected
        If _ddJurusan.Text = "" Then _ddGD.Text = "" : Exit Sub
        _ddGD.FillMe(DLSelect.FindGD(_ddJurusan.ID))
    End Sub

End Class

Public Class DDGiGdController
    Private WithEvents _ddGI As DDMaster
    Private WithEvents _ddFeeder As DDMaster
    Private WithEvents _ddGD As DDMaster

    Sub New(ByVal ddGI As DDMaster, ByVal ddFeeder As DDMaster, ByVal ddGD As DDMaster)
        _ddGI = ddGI : _ddFeeder = ddFeeder : _ddGD = ddGD

        _ddGI.SQLInput = DLSelect.QueryGI(False, "", "")
        _ddGI.SQLValidation = DLSelect.QueryGI(True, "", "")
        _ddFeeder.SQLInput = DLSelect.QueryFeeder(False, "", "")
        _ddFeeder.SQLValidation = DLSelect.QueryFeeder(True, "", "")
        _ddGD.SQLInput = DLSelect.QueryGD(False, "", "")
        _ddGD.SQLValidation = DLSelect.QueryGD(True, "", "")
    End Sub

    Private Sub _ddGI_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddGI.TextChanged
        If _ddGI.Text = "" Then
            _ddGI.SQLInput = DLSelect.QueryGI(False, "", "")
            _ddGI.SQLValidation = DLSelect.QueryGI(True, "", "")
            _ddFeeder.ID = ""
            _ddFeeder.Text = ""
            _ddGD.ID = ""
            _ddGD.Text = ""
        End If
        _ddFeeder.SQLInput = DLSelect.QueryFeeder(False, _ddGI.ID, _ddGD.ID)
        _ddFeeder.SQLValidation = DLSelect.QueryFeeder(True, _ddGI.ID, _ddGD.ID)
        _ddGD.SQLInput = DLSelect.QueryGD(False, _ddGI.ID, _ddFeeder.ID)
        _ddGD.SQLValidation = DLSelect.QueryGD(True, _ddGI.ID, _ddFeeder.ID)
    End Sub

    Private Sub _ddFeeder_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddFeeder.TextChanged
        If _ddFeeder.Text = "" Then
            _ddGD.ID = ""
            _ddGD.Text = ""
        End If
        _ddGI.SQLInput = DLSelect.QueryGI(False, _ddFeeder.ID, _ddGD.ID)
        _ddGI.SQLValidation = DLSelect.QueryGI(True, _ddFeeder.ID, _ddGD.ID)
        _ddGD.SQLInput = DLSelect.QueryGD(False, _ddGI.ID, _ddFeeder.ID)
        _ddGD.SQLValidation = DLSelect.QueryGD(True, _ddGI.ID, _ddFeeder.ID)
    End Sub

    Private Sub _ddGD_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddGD.TextChanged

        _ddFeeder.SQLInput = DLSelect.QueryFeeder(False, _ddGI.ID, _ddGD.ID)
        _ddFeeder.SQLValidation = DLSelect.QueryFeeder(True, _ddGI.ID, _ddGD.ID)
        _ddGI.SQLInput = DLSelect.QueryGI(False, _ddFeeder.ID, _ddGD.ID)
        _ddGI.SQLValidation = DLSelect.QueryGI(True, _ddFeeder.ID, _ddGD.ID)
    End Sub

    Private Sub _ddFeeder_Selected() Handles _ddFeeder.Selected
        If _ddFeeder.Text = "" Then _ddGI.Text = "" : Exit Sub
        _ddGI.FillMe(DLSelect.FindGI(_ddFeeder.ID))
    End Sub

    Private Sub _ddGD_Selected() Handles _ddGD.Selected
        If _ddGD.Text = "" Then _ddFeeder.Text = "" : _ddGI.Text = "" : Exit Sub
        _ddFeeder.FillMe(DLSelect.FindFeeder(_ddGD.ID))
        _ddGI.FillMe(DLSelect.FindGI(_ddFeeder.ID))
    End Sub

End Class

Public Class DDGiJurusanController
    Private WithEvents _ddGI As DDMaster
    Private WithEvents _ddFeeder As DDMaster
    Private WithEvents _ddGD As DDMaster
    Private WithEvents _ddJurusan As DDMaster

    Sub New(ByVal ddGI As DDMaster, ByVal ddFeeder As DDMaster, ByVal ddGD As DDMaster, ByVal ddJurusan As DDMaster)
        _ddGI = ddGI : _ddFeeder = ddFeeder : _ddGD = ddGD : _ddJurusan = ddJurusan

        _ddGI.SQLInput = DLSelect.QueryGIJur(False, "", "", "")
        _ddGI.SQLValidation = DLSelect.QueryGIJur(True, "", "", "")
        _ddFeeder.SQLInput = DLSelect.QueryFeederJur(False, "", "", "")
        _ddFeeder.SQLValidation = DLSelect.QueryFeederJur(True, "", "", "")
        _ddGD.SQLInput = DLSelect.QueryGDJur(False, "", "", "")
        _ddGD.SQLValidation = DLSelect.QueryGDJur(True, "", "", "")
        _ddJurusan.SQLInput = DLSelect.QueryJurusanGI(False, "", "", "")
        _ddJurusan.SQLValidation = DLSelect.QueryJurusanGI(True, "", "", "")
    End Sub

    Private Sub _ddGI_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddGI.TextChanged
        If _ddGI.Text = "" Then
            _ddGI.SQLInput = DLSelect.QueryGIJur(False, "", "", "")
            _ddGI.SQLValidation = DLSelect.QueryGIJur(True, "", "", "")
            _ddFeeder.ID = ""
            _ddFeeder.Text = ""
            _ddGD.ID = ""
            _ddGD.Text = ""
            _ddJurusan.ID = ""
            _ddJurusan.Text = ""
        End If
        _ddFeeder.SQLInput = DLSelect.QueryFeederJur(False, _ddGI.ID, _ddGD.ID, _ddJurusan.ID)
        _ddFeeder.SQLValidation = DLSelect.QueryFeederJur(True, _ddGI.ID, _ddGD.ID, _ddJurusan.ID)
        _ddGD.SQLInput = DLSelect.QueryGDJur(False, _ddGI.ID, _ddFeeder.ID, _ddJurusan.ID)
        _ddGD.SQLValidation = DLSelect.QueryGDJur(True, _ddGI.ID, _ddFeeder.ID, _ddJurusan.ID)
        _ddJurusan.SQLInput = DLSelect.QueryJurusanGI(False, _ddGI.ID, _ddFeeder.ID, _ddGD.ID)
        _ddJurusan.SQLValidation = DLSelect.QueryJurusanGI(True, _ddGI.ID, _ddFeeder.ID, _ddGD.ID)
    End Sub

    Private Sub _ddFeeder_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddFeeder.TextChanged
        If _ddFeeder.Text = "" Then
            _ddGD.ID = ""
            _ddGD.Text = ""
            _ddJurusan.ID = ""
            _ddJurusan.Text = ""
        End If
        _ddGI.SQLInput = DLSelect.QueryGIJur(False, _ddFeeder.ID, _ddGD.ID, _ddJurusan.ID)
        _ddGI.SQLValidation = DLSelect.QueryGIJur(True, _ddFeeder.ID, _ddGD.ID, _ddJurusan.ID)
        _ddGD.SQLInput = DLSelect.QueryGDJur(False, _ddGI.ID, _ddFeeder.ID, _ddJurusan.ID)
        _ddGD.SQLValidation = DLSelect.QueryGDJur(True, _ddGI.ID, _ddFeeder.ID, _ddJurusan.ID)
        _ddJurusan.SQLInput = DLSelect.QueryJurusanGI(False, _ddGI.ID, _ddFeeder.ID, _ddGD.ID)
        _ddJurusan.SQLValidation = DLSelect.QueryJurusanGI(True, _ddGI.ID, _ddFeeder.ID, _ddGD.ID)
    End Sub

    Private Sub _ddGD_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddGD.TextChanged
        If _ddGD.Text = "" Then
            _ddGD.ID = ""
            _ddGD.Text = ""
            _ddJurusan.ID = ""
            _ddJurusan.Text = ""
        End If
        _ddGI.SQLInput = DLSelect.QueryGIJur(False, _ddFeeder.ID, _ddGD.ID, _ddJurusan.ID)
        _ddGI.SQLValidation = DLSelect.QueryGIJur(True, _ddFeeder.ID, _ddGD.ID, _ddJurusan.ID)
        _ddFeeder.SQLInput = DLSelect.QueryFeederJur(False, _ddGI.ID, _ddGD.ID, _ddJurusan.ID)
        _ddFeeder.SQLValidation = DLSelect.QueryFeederJur(True, _ddGI.ID, _ddGD.ID, _ddJurusan.ID)
        _ddJurusan.SQLInput = DLSelect.QueryJurusanGI(False, _ddGI.ID, _ddFeeder.ID, _ddGD.ID)
        _ddJurusan.SQLValidation = DLSelect.QueryJurusanGI(True, _ddGI.ID, _ddFeeder.ID, _ddGD.ID)
    End Sub

    Private Sub _ddJurusan_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddJurusan.TextChanged
        _ddGI.SQLInput = DLSelect.QueryGIJur(False, _ddFeeder.ID, _ddGD.ID, _ddJurusan.ID)
        _ddGI.SQLValidation = DLSelect.QueryGIJur(True, _ddFeeder.ID, _ddGD.ID, _ddJurusan.ID)
        _ddFeeder.SQLInput = DLSelect.QueryFeederJur(False, _ddGI.ID, _ddGD.ID, _ddJurusan.ID)
        _ddFeeder.SQLValidation = DLSelect.QueryFeederJur(True, _ddGI.ID, _ddGD.ID, _ddJurusan.ID)
        _ddGD.SQLInput = DLSelect.QueryGDJur(False, _ddGI.ID, _ddFeeder.ID, _ddJurusan.ID)
        _ddGD.SQLValidation = DLSelect.QueryGDJur(True, _ddGI.ID, _ddFeeder.ID, _ddJurusan.ID)
    End Sub

    Private Sub _ddFeeder_Selected() Handles _ddFeeder.Selected
        If _ddFeeder.Text = "" Then _ddGI.Text = "" : Exit Sub
        _ddGI.FillMe(DLSelect.FindGI(_ddFeeder.ID))
    End Sub

    Private Sub _ddGD_Selected() Handles _ddGD.Selected
        If _ddGD.Text = "" Then _ddFeeder.Text = "" : _ddGI.Text = "" : Exit Sub
        _ddFeeder.FillMe(DLSelect.FindFeeder(_ddGD.ID))
        _ddGI.FillMe(DLSelect.FindGI(_ddFeeder.ID))
    End Sub

    Private Sub _ddJurusan_Selected() Handles _ddJurusan.Selected
        If _ddJurusan.Text = "" Then _ddJurusan.Text = "" : _ddFeeder.Text = "" : _ddGI.Text = "" : Exit Sub
        _ddGD.FillMe(DLSelect.FindGD(_ddJurusan.ID))
        _ddFeeder.FillMe(DLSelect.FindFeeder(_ddGD.ID))
        _ddGI.FillMe(DLSelect.FindGI(_ddFeeder.ID))
    End Sub

End Class

Public Class DDAJUJController
    Private WithEvents _ddAJ As DDMaster
    Private WithEvents _ddUJ As DDMaster

    Sub New(ByVal ddAJ As DDMaster, ByVal ddUJ As DDMaster)
        _ddAJ = ddAJ
        _ddUJ = ddUJ

        _ddAJ.SQLInput = DLSelect.QueryAJ(False, "", "")
        _ddAJ.SQLValidation = DLSelect.QueryAJ(True, "", "")
        _ddUJ.SQLInput = DLSelect.QueryUJ(False, "", "")
        _ddUJ.SQLValidation = DLSelect.QueryUJ(True, "", "")
    End Sub

    Private Sub _ddAJ_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddAJ.TextChanged
        If _ddAJ.Text = "" Then
            _ddUJ.ID = ""
            _ddUJ.Text = ""
        End If
        _ddUJ.SQLInput = DLSelect.QueryUJ(False, "", _ddAJ.ID)
        _ddUJ.SQLValidation = DLSelect.QueryUJ(True, "", _ddAJ.ID)
    End Sub

    Private Sub _ddUJ_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddUJ.TextChanged
        _ddAJ.SQLInput = DLSelect.QueryAJ(False, "", _ddUJ.ID)
        _ddAJ.SQLValidation = DLSelect.QueryAJ(True, "", _ddUJ.ID)
    End Sub

    Private Sub _ddUJ_Selected() Handles _ddUJ.Selected
        If _ddUJ.Text = "" Then _ddAJ.Text = ""
        _ddAJ.Text = DLSelect.FindAJ(_ddUJ.ID)
    End Sub

End Class

Public Class DDTarifDayaController
    Private WithEvents _ddTarif As DDMaster
    Private WithEvents _ddDaya As DDMaster

    Sub New(ByVal ddTarif As DDMaster, ByVal ddDaya As DDMaster)
        _ddTarif = ddTarif
        _ddDaya = ddDaya

        _ddTarif.SQLInput = DLSelect.QueryTarif(False, "")
        _ddTarif.SQLValidation = DLSelect.QueryTarif(True, "")
        _ddDaya.SQLInput = DLSelect.QueryDaya(False, "")
        _ddDaya.SQLValidation = DLSelect.QueryDaya(True, "")
    End Sub

    Private Sub _ddTarif_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddTarif.TextChanged
        If _ddTarif.Text = "" Then
            _ddDaya.ID = "" : _ddDaya.Text = ""
        End If
        _ddDaya.SQLInput = DLSelect.QueryDaya(False, _ddTarif.ID)
        _ddDaya.SQLValidation = DLSelect.QueryDaya(True, _ddTarif.ID)
    End Sub

    Private Sub _ddDaya_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddDaya.TextChanged
        _ddTarif.SQLInput = DLSelect.QueryTarif(False, _ddDaya.ID)
        _ddTarif.SQLValidation = DLSelect.QueryTarif(True, _ddDaya.ID)
    End Sub

    Private Sub _ddDaya_Selected() Handles _ddDaya.Selected
        If _ddDaya.Text = "" Then _ddTarif.Text = ""
        _ddTarif.Text = DLSelect.FindTarif(_ddDaya.ID)
    End Sub

End Class

Public Class DD4TiangEntriUkurGDController
    Private WithEvents _ddTiangA As DDMaster
    Private WithEvents _ddTiangB As DDMaster
    Private WithEvents _ddTiangC As DDMaster
    Private WithEvents _ddTiangD As DDMaster

    Sub New(ByVal ddJurA As DDMaster, ByVal ddJurB As DDMaster, _
            ByVal ddJurC As DDMaster, ByVal ddJurD As DDMaster)
        _ddTiangA = ddJurA
        _ddTiangB = ddJurB
        _ddTiangC = ddJurC
        _ddTiangD = ddJurD

        _ddTiangA.SQLInput = DLSelect.QueryTiangUkur(False, "", "", "", "")
        _ddTiangA.SQLValidation = DLSelect.QueryTiangUkur(True, "", "", "", "")
        _ddTiangB.SQLInput = DLSelect.QueryTiangUkur(False, "", "", "", "")
        _ddTiangB.SQLValidation = DLSelect.QueryTiangUkur(True, "", "", "", "")
        _ddTiangC.SQLInput = DLSelect.QueryTiangUkur(False, "", "", "", "")
        _ddTiangC.SQLValidation = DLSelect.QueryTiangUkur(True, "", "", "", "")
        _ddTiangD.SQLInput = DLSelect.QueryTiangUkur(False, "", "", "", "")
        _ddTiangD.SQLValidation = DLSelect.QueryTiangUkur(True, "", "", "", "")
    End Sub


    Private Sub _ddJurA_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddTiangA.TextChanged
        _ddTiangB.SQLInput = DLSelect.QueryTiangUkur(False, _ddTiangA.ID, "", _ddTiangC.ID, _ddTiangD.ID)
        _ddTiangB.SQLValidation = DLSelect.QueryTiangUkur(True, _ddTiangA.ID, _ddTiangB.ID, _ddTiangC.ID, _ddTiangD.ID)
        _ddTiangC.SQLInput = DLSelect.QueryTiangUkur(False, _ddTiangA.ID, _ddTiangB.ID, "", _ddTiangD.ID)
        _ddTiangC.SQLValidation = DLSelect.QueryTiangUkur(True, _ddTiangA.ID, _ddTiangB.ID, _ddTiangC.ID, _ddTiangD.ID)
        _ddTiangD.SQLInput = DLSelect.QueryTiangUkur(False, _ddTiangA.ID, _ddTiangB.ID, _ddTiangC.ID, "")
        _ddTiangD.SQLValidation = DLSelect.QueryTiangUkur(True, _ddTiangA.ID, _ddTiangB.ID, _ddTiangC.ID, _ddTiangD.ID)
    End Sub

    Private Sub _ddJurB_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddTiangB.TextChanged
        _ddTiangA.SQLInput = DLSelect.QueryTiangUkur(False, "", _ddTiangB.ID, _ddTiangC.ID, _ddTiangD.ID)
        _ddTiangA.SQLValidation = DLSelect.QueryTiangUkur(True, "", _ddTiangB.ID, _ddTiangC.ID, _ddTiangD.ID)
        _ddTiangC.SQLInput = DLSelect.QueryTiangUkur(False, _ddTiangA.ID, _ddTiangB.ID, "", _ddTiangD.ID)
        _ddTiangC.SQLValidation = DLSelect.QueryTiangUkur(True, _ddTiangA.ID, _ddTiangB.ID, "", _ddTiangD.ID)
        _ddTiangD.SQLInput = DLSelect.QueryTiangUkur(False, _ddTiangA.ID, _ddTiangB.ID, _ddTiangC.ID, "")
        _ddTiangD.SQLValidation = DLSelect.QueryTiangUkur(True, _ddTiangA.ID, _ddTiangB.ID, _ddTiangC.ID, "")
    End Sub

    Private Sub _ddJurC_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddTiangC.TextChanged
        _ddTiangB.SQLInput = DLSelect.QueryTiangUkur(False, _ddTiangA.ID, "", _ddTiangC.ID, _ddTiangD.ID)
        _ddTiangB.SQLValidation = DLSelect.QueryTiangUkur(True, _ddTiangA.ID, "", _ddTiangC.ID, _ddTiangD.ID)
        _ddTiangA.SQLInput = DLSelect.QueryTiangUkur(False, "", _ddTiangB.ID, _ddTiangC.ID, _ddTiangD.ID)
        _ddTiangA.SQLValidation = DLSelect.QueryTiangUkur(True, "", _ddTiangB.ID, _ddTiangC.ID, _ddTiangD.ID)
        _ddTiangD.SQLInput = DLSelect.QueryTiangUkur(False, _ddTiangA.ID, _ddTiangB.ID, _ddTiangC.ID, "")
        _ddTiangD.SQLValidation = DLSelect.QueryTiangUkur(True, _ddTiangA.ID, _ddTiangB.ID, _ddTiangC.ID, "")
    End Sub

    Private Sub _ddJurD_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddTiangD.TextChanged
        _ddTiangB.SQLInput = DLSelect.QueryTiangUkur(False, _ddTiangA.ID, "", _ddTiangC.ID, _ddTiangD.ID)
        _ddTiangB.SQLValidation = DLSelect.QueryTiangUkur(True, _ddTiangA.ID, "", _ddTiangC.ID, _ddTiangD.ID)
        _ddTiangC.SQLInput = DLSelect.QueryTiangUkur(False, _ddTiangA.ID, _ddTiangB.ID, "", _ddTiangD.ID)
        _ddTiangC.SQLValidation = DLSelect.QueryTiangUkur(True, _ddTiangA.ID, _ddTiangB.ID, "", _ddTiangD.ID)
        _ddTiangA.SQLInput = DLSelect.QueryTiangUkur(False, "", _ddTiangB.ID, _ddTiangC.ID, _ddTiangD.ID)
        _ddTiangA.SQLValidation = DLSelect.QueryTiangUkur(True, "", _ddTiangB.ID, _ddTiangC.ID, _ddTiangD.ID)
    End Sub

End Class


Public Class DDPtgController
    Private WithEvents _ddPtg1 As DDMaster
    Private WithEvents _ddPtg2 As DDMaster

    Sub New(ByVal ddPtg1 As DDMaster, ByVal ddPtg2 As DDMaster)
        _ddPtg1 = ddPtg1
        _ddPtg2 = ddPtg2

        _ddPtg1.SQLInput = DLSelect.QueryPtgUkur(False, "", "")
        _ddPtg1.SQLValidation = DLSelect.QueryPtgUkur(True, "", "")
        _ddPtg2.SQLInput = DLSelect.QueryPtgUkur(False, "", "")
        _ddPtg2.SQLValidation = DLSelect.QueryPtgUkur(True, "", "")
    End Sub


    Private Sub _ddPtg1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddPtg1.TextChanged
        _ddPtg2.SQLInput = DLSelect.QueryPtgUkur(False, _ddPtg1.ID, "")
        _ddPtg2.SQLValidation = DLSelect.QueryPtgUkur(True, _ddPtg1.ID, "")
    End Sub

    Private Sub _ddPtg2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddPtg2.TextChanged
        _ddPtg1.SQLInput = DLSelect.QueryPtgUkur(False, "", _ddPtg2.ID)
        _ddPtg1.SQLValidation = DLSelect.QueryPtgUkur(True, "", _ddPtg2.ID)
    End Sub
End Class

Public Class DDIDNamaGangguanController
    Private WithEvents _ddGG1 As DDMaster
    Sub New(ByVal ddGG1 As DDMaster)
        _ddGG1 = ddGG1
        _ddGG1.SQLInput = DLSelect.QueryGangguan(False)
        _ddGG1.SQLValidation = DLSelect.QueryGangguan(True)
    End Sub
End Class

Public Class DDUPAJUJController
    Private WithEvents _ddUP As DDMaster
    Private WithEvents _ddAJ As DDMaster
    Private WithEvents _ddUJ As DDMaster

    Sub New(ByVal ddUP As DDMaster, ByVal ddAJ As DDMaster, ByVal ddUJ As DDMaster)
        _ddAJ = ddAJ
        _ddUJ = ddUJ
        _ddUP = ddUP

        _ddAJ.SQLInput = DLSelect.QueryAJ(False, "", "")
        _ddAJ.SQLValidation = DLSelect.QueryAJ(True, "", "")
        _ddUJ.SQLInput = DLSelect.QueryUJ(False, "", "")
        _ddUJ.SQLValidation = DLSelect.QueryUJ(True, "", "")
        _ddUP.SQLInput = DLSelect.QueryUPI(False, "", "", "", "", "")
        _ddUP.SQLValidation = DLSelect.QueryUPI(True, "", "", "", "", "")
    End Sub

    Private Sub _ddAJ_Selected() Handles _ddAJ.Selected
        If _ddAJ.Text = "" Then
            _ddUJ.ID = ""
            _ddUJ.Text = ""
            _ddUP.ID = ""
            _ddUP.Text = ""
        End If
        _ddUJ.SQLInput = DLSelect.QueryUJ(False, "", _ddAJ.ID)
        _ddUJ.SQLValidation = DLSelect.QueryUJ(True, "", _ddAJ.ID)
        _ddUP.SQLInput = DLSelect.QueryUPI(False, "", "", "", _ddAJ.ID, "")
        _ddUP.SQLValidation = DLSelect.QueryUPI(True, "", "", "", _ddAJ.ID, "")
    End Sub

    Private Sub _ddAJ_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddAJ.TextChanged
        If _ddAJ.Text = "" Then
            _ddUJ.ID = ""
            _ddUJ.Text = ""
            _ddUP.ID = ""
            _ddUP.Text = ""
        End If
        _ddUJ.SQLInput = DLSelect.QueryUJ(False, "", _ddAJ.ID)
        _ddUJ.SQLValidation = DLSelect.QueryUJ(True, "", _ddAJ.ID)
        _ddUP.SQLInput = DLSelect.QueryUPI(False, "", "", "", _ddAJ.ID, "")
        _ddUP.SQLValidation = DLSelect.QueryUPI(True, "", "", "", _ddAJ.ID, "")
    End Sub

    Private Sub _ddUJ_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddUJ.TextChanged
        _ddAJ.SQLInput = DLSelect.QueryAJ(False, "", _ddUJ.ID)
        _ddAJ.SQLValidation = DLSelect.QueryAJ(True, "", _ddUJ.ID)
        _ddUP.SQLInput = DLSelect.QueryUPI(False, "", "", "", "", _ddUJ.ID)
        _ddUP.SQLValidation = DLSelect.QueryUPI(True, "", "", "", "", _ddUJ.ID)
    End Sub

    Private Sub _ddUJ_Selected() Handles _ddUJ.Selected
        If _ddUJ.Text = "" Then _ddAJ.Text = ""
        _ddAJ.Text = DLSelect.FindAJ(_ddUJ.ID)
        _ddAJ.SQLInput = DLSelect.QueryAJ(False, "", _ddUJ.ID)
        _ddAJ.SQLValidation = DLSelect.QueryAJ(True, "", _ddUJ.ID)
        _ddUP.SQLInput = DLSelect.QueryUPI(False, "", "", "", "", _ddUJ.ID)
        _ddUP.SQLValidation = DLSelect.QueryUPI(True, "", "", "", "", _ddUJ.ID)
    End Sub

    Private Sub _ddUP_Selected() Handles _ddUP.Selected
        _ddAJ.SQLInput = DLSelect.QueryAJ(False, _ddUP.ID, "")
        _ddAJ.SQLValidation = DLSelect.QueryAJ(True, _ddUP.ID, "")
        _ddUJ.SQLInput = DLSelect.QueryUJ(False, _ddUP.ID, "")
        _ddUJ.SQLValidation = DLSelect.QueryUJ(True, _ddUP.ID, "")
    End Sub

End Class

Public Class DDKategori_SubKategoriController
    Private WithEvents _ddKategori As DDMaster
    Private WithEvents _ddSubKategori As DDMaster

    Sub New(ByVal pddKategori As DDMaster, ByVal pddSubKategori As DDMaster)
        _ddKategori = pddKategori
        _ddSubKategori = pddSubKategori

        _ddKategori.SQLInput = DLSelect.SQL_KategoriDok(False)
        _ddKategori.SQLValidation = DLSelect.SQL_KategoriDok(True)
        _ddSubKategori.SQLInput = DLSelect.SQL_SubKategoriDok(False)
        _ddSubKategori.SQLValidation = DLSelect.SQL_SubKategoriDok(True)
    End Sub

    Private Sub _ddKategori_Selected() Handles _ddKategori.Selected
        If _ddKategori.ID = "" Then
            _ddSubKategori.ID = ""
            _ddSubKategori.Text = ""
        End If
        _ddSubKategori.SQLInput = DLSelect.SQL_SubKategoriDok(False, _ddKategori.ID)
        _ddSubKategori.SQLValidation = DLSelect.SQL_SubKategoriDok(True, _ddKategori.ID)
    End Sub

    Private Sub _ddKategori_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddKategori.TextChanged
        If _ddKategori.ID = "" Then
            _ddSubKategori.ID = ""
            _ddSubKategori.Text = ""
        End If
        _ddSubKategori.SQLInput = DLSelect.SQL_SubKategoriDok(False, _ddKategori.ID)
        _ddSubKategori.SQLValidation = DLSelect.SQL_SubKategoriDok(True, _ddKategori.ID)
    End Sub

    Private Sub _ddSubKategori_Selected() Handles _ddSubKategori.Selected
        _ddKategori.SQLInput = DLSelect.SQL_KategoriDok(False, _ddSubKategori.ID)
        _ddKategori.SQLValidation = DLSelect.SQL_KategoriDok(True, _ddSubKategori.ID)
        _ddKategori.Text = DLSelect.FindKategoriBySubKategori(_ddSubKategori.ID)
    End Sub

    Private Sub _ddSubKategori_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ddSubKategori.TextChanged
        _ddKategori.SQLInput = DLSelect.SQL_KategoriDok(False, _ddSubKategori.ID)
        _ddKategori.SQLValidation = DLSelect.SQL_KategoriDok(True, _ddSubKategori.ID)
    End Sub
End Class

'Public Class DDPtg_Feeder_GD_4EntriInspeksiGD
'    Private WithEvents _ddPtg As DDMaster
'    Private WithEvents _ddFeeder As DDMaster
'    Private WithEvents _ddGD As DDMaster

'    Public Sub New(ByVal ddPtg As DDMaster, ByVal ddFeeder As DDMaster, ByVal ddGD As DDMaster)
'        _ddPtg = ddPtg
'        _ddFeeder = ddFeeder
'        _ddGD = ddGD

'    End Sub
'End Class