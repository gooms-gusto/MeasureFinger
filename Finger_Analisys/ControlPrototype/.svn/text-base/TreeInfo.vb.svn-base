Imports C1.Win.C1FlexGrid

Public Class TreeInfo

    Public Enum WhatColor
        Normal
        Bold
        Red
        Green
        RedRight
        GreenRight
    End Enum

    Public Enum FGLevel
        Header
        Child
    End Enum

    Public Sub ValRataKiri(ByVal FromRow As Integer, ByVal ToRow As Integer)
        Dim cr As CellRange
        cr = fg.GetCellRange(FromRow, 1, ToRow, 1)
        cr.Style = fg.Styles("Isi")
    End Sub

    Public Sub ColorThis(ByVal wc As WhatColor, ByVal Row As Integer, ByVal Col As Integer)
        Dim cs As CellStyle = fg.Styles.Add("" & wc.ToString & "")
        Dim cr As CellRange

        Select Case wc
            Case WhatColor.Bold
                cs.Font = New Font(Font, FontStyle.Bold)
            Case WhatColor.Green
                cs.ForeColor = Color.Green
                cs.TextAlign = TextAlignEnum.LeftCenter
            Case WhatColor.Red
                cs.ForeColor = Color.Red
                cs.TextAlign = TextAlignEnum.LeftCenter
            Case WhatColor.RedRight
                cs.ForeColor = Color.Red
                cs.TextAlign = TextAlignEnum.RightCenter
            Case WhatColor.GreenRight
                cs.ForeColor = Color.Green
                cs.TextAlign = TextAlignEnum.RightCenter
        End Select

        cr = fg.GetCellRange(Row, Col, Row, Col) : cr.Style = cs
    End Sub

    Public Sub AddNode(ByVal key As String, ByVal ket As String, ByVal ket2 As String, _
            ByVal LEVEL As Integer, Optional ByVal FGstyle As FGLevel = FGLevel.Header, _
            Optional ByVal IsValCheckBox As Boolean = False, Optional ByVal IsValChecked As Boolean = False, _
            Optional ByVal isComboBox As Boolean = False, Optional ByVal CBvalue As String = "", Optional ByVal CBdefaultValue As String = "")
        Dim CR As CellRange
        fg.AddItem("")
        If key <> "" Then
            CR = fg.GetCellRange(fg.Rows.Count - 1, 0, fg.Rows.Count - 1, 1)
            CR.Data = key
            fg.Rows(fg.Rows.Count - 1).AllowMerging = True
        End If

        Dim rng As CellRange
        If ket <> "" Then
            rng = fg.GetCellRange(fg.Rows.Count - 1, 0)
            rng.Data = ket
            CR = fg.GetCellRange(fg.Rows.Count - 1, 0)
            CR.StyleNew.TextAlign = TextAlignEnum.RightCenter
        End If

        If IsValCheckBox Then
            rng = fg.GetCellRange(fg.Rows.Count - 1, 1)
            If IsValChecked Then
                rng.Checkbox = CheckEnum.Checked
            Else
                rng.Checkbox = CheckEnum.Unchecked
            End If
        Else
            If ket2 <> "" Then
                rng = fg.GetCellRange(fg.Rows.Count - 1, 1)
                rng.Data = ket2
            End If
        End If

        If isComboBox Then
            Dim s As CellStyle = fg.Styles.Add("ComboList" & (fg.Rows.Count - 1).ToString)
            s.ComboList = CBvalue
            rng = fg.GetCellRange(fg.Rows.Count - 1, 1)
            rng.Style = s
            fg.SetData(fg.Rows.Count - 1, 1, CBdefaultValue)
        Else
            If ket2 <> "" Then
                rng = fg.GetCellRange(fg.Rows.Count - 1, 1)
                rng.Data = ket2
            End If
        End If

        If FGstyle = FGLevel.Header Then
            fg.Rows(fg.Rows.Count - 1).Style = fg.Styles("Header")
        Else
            CR = fg.GetCellRange(1, 0, fg.Rows.Count - 1, 0)
            Try
                CR.Style = fg.Styles.Add("Kolom0")
            Catch ex As Exception
            End Try

        End If

        Dim row As Row
        row = fg.Rows(fg.Rows.Count - 1)
        row.IsNode = True

        Dim nd As Node
        nd = row.Node
        nd.Level = LEVEL

        fg.Styles.Normal.WordWrap = True
        fg.AutoSizeRows()
    End Sub

    Private Sub CreateCustomStyle()
        'create custom style for section
        Dim cs As CellStyle = fg.Styles.Add("Header")
        cs.Font = New Font(Font, FontStyle.Bold)
        cs.TextAlign = TextAlignEnum.LeftCenter
        cs.BackColor = Color.WhiteSmoke
        cs.Border.Color = Color.Gray

        Dim csisi As CellStyle = fg.Styles.Add("Isi")
        csisi.TextAlign = TextAlignEnum.LeftCenter
        csisi.BackColor = Color.White

        Dim csKol0 As CellStyle = fg.Styles.Add("Kolom0")
        csKol0.TextAlign = TextAlignEnum.LeftCenter
        csKol0.BackColor = Color.WhiteSmoke

    End Sub

    Private Sub StyleFG()
        With fg
            .Tree.Column = 0
            .Tree.Style = TreeStyleFlags.Simple
            .Cols.Count = 2
            .Cols(0).Width = 190
            .AllowMerging = AllowMergingEnum.Free
            .Tree.Show(0)
        End With
    End Sub

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        StyleFG()
        CreateCustomStyle()
    End Sub


#Region "EventHandler"

    Public Event Tree_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event Tree_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event Tree_CellChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event Tree_ComboDropDown(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event Tree_AfterSelChange(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event Tree_CellButtonClick(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event Tree_AfterDragColumn(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event Tree_MouseUp(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event Tree_KeyDown(ByVal sender As Object, ByVal e As System.EventArgs)

    Private Sub fg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles fg.Click
        RaiseEvent Tree_Click(sender, e)
    End Sub

    Private Sub fg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles fg.DoubleClick
        RaiseEvent Tree_DoubleClick(sender, e)
    End Sub

    Private Sub fg_CellChanged(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles fg.CellChanged
        RaiseEvent Tree_CellChanged(sender, e)
    End Sub

    Private Sub fg_ComboDropDown(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles fg.ComboDropDown
        RaiseEvent Tree_ComboDropDown(sender, e)
    End Sub

    Private Sub fg_AfterSelChange(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.RangeEventArgs) Handles fg.AfterSelChange
        RaiseEvent Tree_AfterSelChange(sender, e)
    End Sub

    Private Sub fg_CellButtonClick(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles fg.CellButtonClick
        RaiseEvent Tree_CellButtonClick(sender, e)
    End Sub

    Private Sub fg_AfterDragColumn(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.DragRowColEventArgs) Handles fg.AfterDragColumn
        RaiseEvent Tree_AfterDragColumn(sender, e)
    End Sub

    Private Sub fg_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles fg.MouseUp
        RaiseEvent Tree_MouseUp(sender, e)
    End Sub

    Private Sub fg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles fg.KeyDown
        RaiseEvent Tree_KeyDown(sender, e)
    End Sub
#End Region

    Public Function GetCellCheck(ByVal row As Integer, ByVal col As Integer) As CheckEnum
        Try
            Return fg.GetCellCheck(row, col)
        Catch ex As Exception
            MessageBox.Show(Globals.GetStackInfo(ex, True), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Sub SetCellCheck(ByVal row As Integer, ByVal col As Integer, ByVal checkEnum As CheckEnum)
        Try
            fg.SetCellCheck(row, col, checkEnum)
        Catch ex As Exception
            MessageBox.Show(Globals.GetStackInfo(ex, True), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
