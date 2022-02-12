Imports C1.Win.C1FlexGrid

Public Class IAOCheckGrid
    Private SQLInputVal As String
    Public Flex As C1FlexGrid
    Public m_DataTable As DataTable

    Public WriteOnly Property SQLInput() As String
        Set(ByVal value As String)
            SQLInputVal = value
        End Set
    End Property

    Public ReadOnly Property Data() As DataTable
        Get
            Return m_DataTable
        End Get
    End Property

    Public Sub DownArrow()
        LoadData()
        If Not Me.DropDownForm Is Nothing Then Me.DropDownForm = Nothing
        Dim pForm As New BaseCheckGridForm(Me)
        Me.DropDownForm = pForm
        Me.OpenDropDown()
        pForm.fg.Focus()
    End Sub

    Private Sub LoadData()
        m_DataTable = GlobalClassV2.Globals.Instance.ExecuteQuery(SQLInputVal)
    End Sub

    Private Sub Me_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Down Then DownArrow()
    End Sub

End Class
