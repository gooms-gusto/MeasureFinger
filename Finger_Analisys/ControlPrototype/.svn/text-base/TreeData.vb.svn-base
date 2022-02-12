Imports C1.Win.C1FlexGrid

Public Class TreeData
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

    Public Sub AddNode(ByVal key As String, ByVal ket As String, ByVal ket2 As String, ByVal ket3 As String, _
            ByVal LEVEL As Integer, Optional ByVal FGstyle As FGLevel = FGLevel.Header)
        Dim CR As CellRange
        fg.AddItem("")
        If key <> "" Then
            CR = fg.GetCellRange(fg.Rows.Count - 1, 0, fg.Rows.Count - 1, 2)
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

        If ket2 <> "" Then
            rng = fg.GetCellRange(fg.Rows.Count - 1, 1)
            rng.Data = ket2
        End If

        If ket3 <> "" Then
            rng = fg.GetCellRange(fg.Rows.Count - 1, 2)
            rng.Data = ket3
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

    Public Sub InsertRowsNode(ByVal key As String, ByVal pParentName As String, ByVal pLevel As Integer, ByVal Ket As String, ByVal Ket2 As String, ByVal Ket3 As String)
        Dim rng As CellRange
        Dim pIndex As Integer
        If key <> "" Or fg.FindRow(pParentName, 1, 0, False, True, True) < 1 Then
            pIndex = 1
        Else
            pIndex = GetIndexParent(pParentName)
        End If
        If pIndex = fg.Rows.Count - 1 Then
            AddNode("", Ket, Ket2, Ket3, 1, FGLevel.Child)
        Else
            With fg
                .Rows.InsertNode(pIndex, pLevel)
                If key <> "" Then
                    Dim CR As CellRange
                    CR = fg.GetCellRange(pIndex, 0, pIndex, 2)
                    CR.Data = key
                    fg.Rows(pIndex).AllowMerging = True
                End If
                If Ket <> "" Then
                    rng = fg.GetCellRange(pIndex, 0)
                    rng.Data = Ket
                End If
                If Ket2 <> "" Then
                    rng = fg.GetCellRange(pIndex, 1)
                    rng.Data = Ket2
                End If
                If Ket3 <> "" Then
                    rng = fg.GetCellRange(pIndex, 2)
                    rng.Data = Ket3
                End If
            End With
        End If
    End Sub

    Private Function GetIndexParent(ByVal pNamaParent As String) As Integer
        For i As Integer = 1 To fg.Rows.Count - 1
            If fg.GetData(i, 1) = pNamaParent Then
                If i = fg.Rows.Count - 1 Then
                    Return i
                Else
                    For j As Integer = i + 1 To fg.Rows.Count - 1
                        If fg.Rows(j).Node.Level = 0 Or j = fg.Rows.Count - 1 Then
                            Return j
                        End If
                    Next
                End If
            End If
        Next
    End Function

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
            .Rows.Fixed = 1
            .Tree.Column = 0
            .Tree.Style = TreeStyleFlags.Simple
            .Cols.Count = 3
            .Cols(0).Width = 190
            .Cols(1).Width = 190
            .AllowMerging = AllowMergingEnum.Free
            .Tree.Show(0)
            .ExtendLastCol = True
        End With
    End Sub

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        StyleFG()
        CreateCustomStyle()
    End Sub


    Public Event Tree_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    Private Sub fg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles fg.Click
        RaiseEvent Tree_Click(sender, e)
    End Sub

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
