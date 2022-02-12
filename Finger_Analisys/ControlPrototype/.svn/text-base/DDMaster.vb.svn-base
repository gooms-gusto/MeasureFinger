Imports C1.Win.C1FlexGrid
Imports EMap.DL_EMap
Imports System.ComponentModel

Public Class DDMaster

    Public Event Selected()
    Public Flex As C1FlexGrid
    Private _SQLInput As String
    Private _SQLValidation As String
    Private _ID As String = ""
    Private _Row As Integer
    Private _isIDFilter As Boolean
    Private _CanValidate As Boolean
    Private _DataRow As DataRow
    Private _UseColNameValueToValidated As String = ""
    Friend IsFind As Boolean = True
    Public pFilter As Object
    Public pFilterValue As Object

    Public Property ID() As String
        Get
            If _ID Is Nothing Then Return ""
            Return _ID
        End Get
        Set(ByVal value As String)
            _ID = value
        End Set
    End Property

    Public Property UseColNameValueToValidated() As String
        Get
            Return _UseColNameValueToValidated
        End Get
        Set(ByVal value As String)
            _UseColNameValueToValidated = value
        End Set
    End Property

    Public Property SelectedRow() As Integer
        Get
            Return _Row
        End Get
        Set(ByVal value As Integer)
            _Row = value
        End Set
    End Property

    Public Property DataRow() As DataRow
        Get
            Return _DataRow
        End Get
        Set(ByVal value As DataRow)
            _DataRow = value
        End Set
    End Property

    Public Property IsIDFilter() As Boolean
        Get
            Return _isIDFilter
        End Get
        Set(ByVal value As Boolean)
            _isIDFilter = value
        End Set
    End Property

    Private _m_DataTable As DataTable

    Public Property M_DataTable() As DataTable
        Get
            Return _m_DataTable
        End Get
        Set(ByVal value As DataTable)
            _m_DataTable = value
        End Set
    End Property

    Public WriteOnly Property SQLInput() As String
        Set(ByVal value As String)
            _SQLInput = value
        End Set
    End Property

    Public WriteOnly Property SQLValidation() As String
        Set(ByVal value As String)
            _SQLValidation = value
        End Set
    End Property

    Public Property CanValidate() As Boolean
        Get
            Return _CanValidate
        End Get
        Set(ByVal value As Boolean)
            _CanValidate = value
            If _CanValidate = False Then
                RemoveHandler Me.Validated, AddressOf DDMaster_Validated
            Else
                AddHandler Me.Validated, AddressOf DDMaster_Validated
            End If
        End Set
    End Property

    Friend Sub Flex_DoubleClick()
        RaiseEvent Selected()
    End Sub

    Public Sub DownArrow()
        Dim pForm As New BaseLookUpForm
        Try
            LoadData()
            If Not Me.DropDownForm Is Nothing Then
                Me.DropDownForm = Nothing
            End If
            Me.DropDownForm = pForm
            Me.OpenDropDown()
            pForm.fg.Focus()
        Catch ex As Exception
            pForm.Dispose()
            MsgBox(Globals.GetStackInfo(ex, True), MsgBoxStyle.Exclamation, "Konfirmasi")
        End Try
    End Sub

    Private Sub LoadData()
        pFilter = Split(Trim(Me.Text), "-")

        If IsIDFilter Then
            pFilter = Trim(pFilter(0))
        Else
            Dim id As String = ""
            If UBound(pFilter) > 0 Then
                id = Trim(pFilter(1))
                pFilter = id : pFilterValue = id
            Else
                id = Trim(pFilter(0))
                pFilter = id : pFilterValue = id
            End If
        End If

        If IsFind = False Then pFilter = ""
        LoadData(pFilter)
    End Sub

    Private Sub LoadData(ByVal pFilter As String)
        Me.Cursor = Cursors.WaitCursor
        If Not _SQLInput = "" Then M_DataTable = DLSelect.CustomLoadMaster(pFilter, _SQLInput)
        Me.Cursor = Cursors.IBeam
    End Sub

    Private Sub DDMaster_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Not Me.DropDownForm Is Nothing Then Me.DropDownForm.Dispose()
    End Sub

    Private Sub DDOtherMaster_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Down And Me.ReadOnly = False And Me.Enabled = True Then
            DownArrow()
        End If
    End Sub

    ''' <summary>
    ''' Mengisi DD sesuai input SQL Validation
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <remarks></remarks>
    Public Sub FillMe(ByVal ID As String)
        Me.Text = ID : ValidateInput(ID)
    End Sub

    Private Sub ValidateInput(ByVal pFilter As String)
        If Trim(Me.Text) = "" Then Exit Sub
        If _SQLValidation Is Nothing Then Exit Sub

        If _SQLValidation.Contains("SELECT2") Then pFilter = Trim(Split(pFilter, "-").GetValue(0))

        Dim dt As New DataTable
        Try
            Try
                'Cari hasil validasi berdasarkan ID
                dt = DLSelect.CustomLoadMaster(pFilter, _SQLValidation)
                'Jika tdak ada hasil validasi berdasarkan ID maka cari berdasarkan nama
                If dt.Rows.Count = 0 Then dt = DLSelect.CustomLoadMaster(pFilter, _SQLInput)
            Catch ex As Exception
                Try
                    'Jika error berdasarkan ID (biasanya karena pFilter adalah char, sementara ID biasanya number),
                    ' coba cari berdasarkan nama
                    dt = DLSelect.CustomLoadMaster(pFilter, _SQLInput)
                Catch ex2 As Exception
                End Try
            End Try
            If dt.Rows.Count = 0 Then
                Me.Text = ""
                _ID = ""
                _Row = -1
                DataRow = Nothing
                RaiseEvent Selected()
            Else
                Try
                    Me.Text = Trim(dt.Rows(0)!SELECT1) & " - " & Trim(dt.Rows(0)!SELECT2)
                    _ID = Trim(dt.Rows(0)!SELECT1)
                Catch ex As Exception
                    Try
                        Me.Text = Trim(dt.Rows(0)!SELECT1)
                        _ID = Trim(dt.Rows(0)!SELECT1)
                    Catch ex2 As Exception
                        'Default : Isi Me.Text dengan Rows(0) kolom(0) - kolom (1)
                        If dt.Columns.Count > 1 Then
                            Me.Text = Trim(dt.Rows(0)(0)) & " - " & Trim(dt.Rows(0)(1))
                        ElseIf dt.Columns.Count = 1 Then
                            'Jika hanya punya 1 kolom
                            Me.Text = Trim(dt.Rows(0)(0))
                        End If
                    End Try
                End Try
                _Row = 0
                DataRow = dt.Rows(0)
                RaiseEvent Selected()
            End If
        Catch ex As Exception
            Me.Text = ""
        End Try

    End Sub

    ''' <summary>
    ''' Mendapatkan value datarow sesuai nama kolom yang diinginkan
    ''' </summary>
    ''' <param name="ColumnName"></param>
    ''' <remarks></remarks>
    Public Function DataRowValue(ByVal ColumnName As String) As String
        Try
            Return GlobalClassV2.Globals.GiveNullAValue(Me.DataRow.Item(ColumnName))
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub DDMaster_Selected() Handles Me.Selected
        IsFind = False
    End Sub

    Private Sub DDMaster_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.TextChanged
        IsFind = True
        If Me.Text = "" Then ID = "" : Me.DataRow = Nothing
        Dim idBase As String = Trim(Split(Me.Text, "-").GetValue(0))
        ID = idBase
    End Sub

    Private Sub DDMaster_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        If UseColNameValueToValidated = "" Then
            ValidateInput(Me.Text)
        Else
            ValidateInput(DataRowValue(UseColNameValueToValidated))
        End If
    End Sub


End Class
