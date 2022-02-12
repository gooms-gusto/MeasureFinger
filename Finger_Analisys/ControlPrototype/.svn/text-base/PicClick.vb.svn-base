Public Class PicClick
    Public Property PartnerName() As String
        Get
            Return m_PartnerName
        End Get
        Set(ByVal Value As String)
            m_PartnerName = Value
        End Set
    End Property

    Private m_PartnerName As String

    Private _BorderStyle As BorderStyle

    Public Overloads Property BorderStyle() As BorderStyle
        Get
            Return _BorderStyle
        End Get
        Set(ByVal value As BorderStyle)
            _BorderStyle = value
            PicClick_Resize(Nothing, Nothing)
        End Set
    End Property


    Private Sub PicClick_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If BorderStyle = Windows.Forms.BorderStyle.Fixed3D Then
            Me.Size = New Size(20, 20)
        ElseIf BorderStyle = Windows.Forms.BorderStyle.FixedSingle Then
            Me.Size = New Size(20, 18)
        End If
        VistaButton.Size = Me.Size
    End Sub

    Private Sub VistaButton_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles VistaButton.MouseUp
        Dim pParent As Control = Me.Parent
        Dim pControl As Control
        Dim pTemp As New Control
        Dim pFound As Boolean = False

        For Each pControl In pParent.Controls
            If UCase(pControl.Name) = UCase(m_PartnerName) Then
                pTemp = pControl
                pFound = True
                Exit For
            End If
        Next
        If Not pFound Then Exit Sub

        If TypeOf (pTemp) Is DDMaster Then
            Dim pPartnerLookUpMaster As DDMaster
            pPartnerLookUpMaster = pTemp
            pPartnerLookUpMaster.DownArrow()
        ElseIf TypeOf (pTemp) Is IAOCheckGrid Then
            Dim pPartnerCheckGrid As IAOCheckGrid
            pPartnerCheckGrid = pTemp
            pPartnerCheckGrid.DownArrow()
        End If
    End Sub
End Class
