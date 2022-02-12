Imports C1.Win.C1FlexGrid

Public Class BaseCheckGridForm
    Private m_DataTable As DataTable
    Private m_HeightperRow As Double
    Private m_Control As IAOCheckGrid

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal pControl As IAOCheckGrid)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        m_Control = pControl
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub DrawGrid()
        With fg
            Dim cr As CellRange
            If m_DataTable Is Nothing Then
                Me.Height = 22
                .Rows.Count = 0
            Else
                .DataSource = m_DataTable
                If m_DataTable.Rows.Count > 0 Then
                    cr = .GetCellRange(0, 0, .Rows.Count - 1, 0) : cr.Checkbox = CheckEnum.Unchecked
                    If Trim(Me.OwnerControl.Text) <> "" Then
                        Dim id As ArrayList = GetID()
                        For i As Integer = 0 To .Rows.Count - 1
                            If id.Contains(Trim(.GetData(i, 1))) Then
                                .SetCellCheck(i, 0, CheckEnum.Checked)
                            End If
                        Next
                    End If
                    .AllowEditing = True
                    .Cols(0).Width = 15
                    .Cols(1).Visible = False
                    .Cols(2).AllowEditing = False
                End If
            End If
            If Me.Tag = "1Row" Then .Cols(0).Width = 0
            .ExtendLastCol = True
        End With
    End Sub

    Private Function GetID() As ArrayList
        GetID = New ArrayList
        Dim listEmp As Object = Nothing
        If Me.OwnerControl.Text.Contains(":") Then
            Dim listAllEmp As Object = Split(Me.OwnerControl.Text, ":")
            If UBound(listAllEmp) > 0 Then
                For i As Integer = 0 To UBound(listAllEmp)
                    listEmp = listAllEmp(i)
                    listEmp = Split(listEmp, "-") : listEmp = Trim(listEmp(0))
                    GetID.Add(listEmp)
                Next
            End If
        Else
            listEmp = Split(Me.OwnerControl.Text, "-") : listEmp = Trim(listEmp(0))
            GetID.Add(listEmp)
        End If

        Return GetID
    End Function

    Private Sub Initialize()
        m_Control = Me.OwnerControl
        m_DataTable = m_Control.Data
        m_Control.Flex = Me.fg
        m_HeightperRow = Me.Height / 10
        Me.Width = Me.OwnerControl.Width

        If m_DataTable Is Nothing Then Exit Sub
        Dim pRowNum As Long = m_DataTable.Rows.Count
        If pRowNum = 0 Then
            Me.Height = m_HeightperRow
        ElseIf pRowNum <= 15 Then
            Me.Height = pRowNum * m_HeightperRow
        ElseIf pRowNum > 15 Then
            Me.Height = 15 * m_HeightperRow
        End If
    End Sub

    Private Sub BaseCheckGridForm_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        FillText()
        Me.CloseDropDown()
    End Sub

    Private Sub FillText()
        Try
            If m_DataTable.Rows.Count > 0 Then
                Dim str As String = ""
                Dim first As Boolean = True
                With fg
                    For i As Integer = 0 To .Rows.Count - 1
                        If .GetCellCheck(i, 0) = CheckEnum.Checked Then
                            If first Then
                                str = Trim(.GetData(i, 1)) & "-" & Trim(.GetData(i, 2))
                                first = False
                            Else
                                str = str & ":" & Trim(.GetData(i, 1)) & "-" & Trim(.GetData(i, 2))
                            End If
                        End If
                    Next
                End With
                Me.OwnerControl.Text = str
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BaseCheckGridForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then FillText() : Me.CloseDropDown()
    End Sub

    Private Sub BaseCheckGridForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Initialize()
        DrawGrid()
    End Sub
End Class