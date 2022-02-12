Public Class BaseLookUpForm
    Private m_DataTable As DataTable
    Private m_HeightperRow As Double
    Private m_Control As DDMaster


    Private Sub Initialize()
        m_Control = Me.OwnerControl
        m_DataTable = m_Control.M_DataTable
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

    Private Sub DrawGrid()
        With fg
            If m_DataTable Is Nothing Then
                Me.Height = 22
                .Rows.Count = 0
            Else
                .DataSource = m_DataTable
            End If
            If Me.Tag = "1Row" Then .Cols(0).Width = 0
            .AutoSizeCols()
            .ExtendLastCol = True

            If m_Control.IsIDFilter Then
                If m_Control.IsFind = False Then
                    Me.Cursor = Cursors.WaitCursor
                    .Select(.FindRow(m_Control.ID, 0, 0, False, False, True), 0, True)
                    Me.Cursor = Cursors.IBeam
                End If
            Else
                If m_Control.IsFind = False Then
                    Me.Cursor = Cursors.WaitCursor
                    Try
                        .Select(.FindRow(m_Control.pFilterValue, 0, 1, False, False, True), 1, True)
                    Catch ex As Exception
                        .Select(.FindRow(m_Control.ID, 0, 0, False, False, True), 0, True)
                    End Try
                    Me.Cursor = Cursors.IBeam
                End If
            End If

            If .Cols.Count >= 3 Then
                For i As Integer = 2 To .Cols.Count - 1
                    .Cols(i).Visible = False
                Next
            End If
        End With
    End Sub

    Private Sub fg_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fg.DoubleClick
        Dim pData As DataTable = fg.DataSource
        If pData Is Nothing Then Exit Sub
        If pData.Rows.Count = 0 Then
            Me.CloseDropDown()
            Exit Sub
        End If

        Dim pID As String = GlobalClassV2.Globals.Instance.CheckNull(fg.GetData(fg.Row, 0))
        Dim pNama As String = GlobalClassV2.Globals.Instance.CheckNull(fg.GetData(fg.Row, 1))
        Me.OwnerControl.Text = Trim(pID) & " - " & Trim(pNama)
        If pID.Contains("-") Then
            Dim Sid As String = Trim(Split(pID, "-").GetValue(0))
            m_Control.ID = sID
        Else
            m_Control.ID = Trim(pID)
        End If
        m_Control.SelectedRow = fg.Row
        m_Control.DataRow = pData.Rows(fg.Row)

        'SetOutput(pID, pNama)
        If Me.fg.Cols.Count = 1 Then Me.OwnerControl.Text = Trim(pID)
        Me.CloseDropDown()
        m_Control.Flex_DoubleClick()
    End Sub

    Private Sub FormDDMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Initialize()
        DrawGrid()
    End Sub

    Private Sub FormDDMaster_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        Me.CloseDropDown()
    End Sub

    Private Sub fg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles fg.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            fg_DoubleClick(Nothing, Nothing)
        End If
    End Sub

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub
End Class
