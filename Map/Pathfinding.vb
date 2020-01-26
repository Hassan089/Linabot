Public Class Pathfinding

    Private openlist As New ArrayList
    Private closelist As New ArrayList
    Private Plist(1025) As Integer
    Private Flist(1025) As Integer
    Private Glist(1025) As Integer
    Private Hlist(1025) As Integer
    Private fight As Boolean
    Private nombreDePM As Integer
    Private Map_Largeur As Integer
    Private Delegate Sub D_Path()

    Private Liste_Mobs_Agro As New Dictionary(Of Integer, Integer) From
        {
        {233, 2},
        {2796, 2},
        {459, 3},
        {155, 2},
        {2300, 3}
        }

    Private Sub Load_Sprites(ByVal MapHandler() As Cell, ByVal Index As Integer, ByVal Cell_Fin As Integer, ByVal Evite_Changeur As Boolean, ByVal Anti_Agro As Boolean, ByVal Data_Grid As DataGridView)

        Dim Liste As New List(Of Integer)

        'Si je suis pas en combat et que l'utilisateur veut éviter les agros.
        If fight = False AndAlso Anti_Agro Then

            For Each Pair As DataGridViewRow In Data_Grid.Rows

                'Je regarde si le mobs et dans le dictionnaire
                'Dim Separation() As String = Split(Split(Split(Pair.Cells(4).Value, "Race : ")(1), " : ")(0), ",")
                Dim Separation() As String = Split(Pair.Cells(4).Value, "Race : ")
                Separation = Split(Separation(1), vbCrLf)
                Separation = Split(Separation(0), ",")
                For i = 0 To Separation.Count - 1

                    If IsNumeric(Separation(i)) AndAlso Liste_Mobs_Agro.ContainsKey(Separation(i)) Then

                        'Je rajoute toutes les cellules à éviter autour du mobs.
                        '  For Each Line As String In Liste_Cellule_Porté(V_Index, Pair.Cells(1).Value, 0, Liste_Mobs_Agro(Separation(i)))
                        '  If Not Liste.Contains(Line) Then Liste.Add(Line)
                        ' Next

                    End If

                Next

            Next

        End If

        If fight Then

            For Each Pair As DataGridViewRow In Data_Grid.Rows

                '  If Not Liste.Contains(Pair.Cells(1).Value) AndAlso Pair.Cells(1).Value <> Comptes(V_Index).Case_Actuelle Then Liste.Add(Pair.Cells(1).Value)

            Next

        End If


        For i As Integer = 1 To 1000

            If MapHandler(i).active AndAlso MapHandler(i).movement > 1 Then

                'Je suis en combat et la cellule est utilisé par un Mobs/Joueur
                If fight AndAlso Liste.Contains(i) Then
                    closelist.Add(i)

                    'Je suis pas en combat, je souhaite éviter les mobs.
                ElseIf fight = False AndAlso Anti_Agro AndAlso Liste.Contains(i) Then
                    closelist.Add(i)

                    'Pas de Ligne de vue.
                ElseIf MapHandler(i).lineOfSight = False Then
                    closelist.Add(i)

                    'Je suis pas en combat.
                ElseIf fight = False Then

                    'S'il s'agit d'une case avec des soleils pour changer de map
                    If (MapHandler(i).layerObject1Num = 1030) OrElse (MapHandler(i).layerObject2Num = 1030) Then

                        'Je vérifie qu'il s'agit d'une case autre de celle que je souhaite.
                        If i <> Cell_Fin Then

                            'Si je dois éviter les changeurs de map ou non.
                            If Evite_Changeur Then
                                closelist.Add(i)
                            Else
                                'A voir avec les cellules de soleil bugé
                            End If

                        End If

                    End If

                End If

            Else

                closelist.Add(i)

            End If

        Next

    End Sub

    Private Sub loadCell()
        For i = 0 To 1024
            Plist(i) = 0
            Flist(i) = 0
            Glist(i) = 0
            Hlist(i) = 0
        Next
    End Sub

    Public Function pathing(ByVal Index As Integer, ByVal mapHandler() As Cell, ByVal nCellBegin As Integer, ByVal nCellEnd As Integer, ByVal La_Map_Largeur As Integer,
                            Optional ByVal isfight As Boolean = False, Optional ByVal numberPM As Integer = 9999,
                            Optional ByVal Evite_Changeur As Boolean = True, Optional ByVal Anti_Agro As Boolean = False)

        Try

            If nCellEnd <= 0 Then
                '     Comptes(V_Index).Path_Final = ""
                Return ""
            End If

            fight = isfight
            nombreDePM = numberPM
            Map_Largeur = La_Map_Largeur
            loadCell()
            '  Load_Sprites(mapHandler, V_Index, nCellEnd, Evite_Changeur, Anti_Agro, Comptes(V_Index).Tab_Personnage.DataGridView_Map)
            closelist.Remove(nCellEnd)

            Dim returnPath As String = Findpath(nCellBegin, nCellEnd)
            '  Comptes(V_Index).Path_Final = returnPath.Length

            Return cleanPath(returnPath)

        Catch ex As Exception
        End Try

        Return ""

    End Function

    Private Function Findpath(ByVal cell1 As Integer, ByVal cell2 As Integer) As String
        Dim current As Integer
        Dim i As Integer = 0

        openlist.Add(cell1)

        Do Until openlist.Contains(cell2)
            i += 1
            If i > 1000 Then Return ""

            current = getFpoint()
            If current = cell2 Then Exit Do

            closelist.Add(current)
            openlist.Remove(current)

            For Each cell As Integer In getChild(current)

                If closelist.Contains(cell) = False Then

                    If openlist.Contains(cell) Then

                        If Glist(current) + 5 < Glist(cell) Then
                            Plist(cell) = current
                            Glist(cell) = Glist(current) + 5
                            Hlist(cell) = goalDistance("X", cell, cell2)
                            Flist(cell) = Glist(cell) + Hlist(cell)
                        End If

                    Else
                        openlist.Add(cell)
                        openlist.Item(openlist.Count - 1) = cell
                        Glist(cell) = Glist(current) + 5
                        Hlist(cell) = goalDistance("X", cell, cell2)
                        Flist(cell) = Glist(cell) + Hlist(cell)
                        Plist(cell) = current
                    End If

                End If

            Next
        Loop

        Return (GetParent(cell1, cell2))

    End Function

    Private Function GetParent(ByVal cell1 As Integer, ByVal cell2 As Integer)
        Dim current As Integer = cell2
        Dim pathCell As New ArrayList
        pathCell.Add(current)
        InitializeCells()
        Do Until current = cell1
            pathCell.Add(Plist(current))
            current = Plist(current)
            If current = 0 Then Exit Do
        Loop
        Return getPath(pathCell)
    End Function

    Private Sub InitializeCells()
        Dim Number As Integer = 0
        Dim hash() As String = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "-", "_"}
        Dim hash2() As String = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"}
        Dim i As Integer = 0
        For i = 0 To hash2.Length - 1
            Dim j As Integer = 0
            For j = 0 To hash.Length - 1
                cases(Number) = hash2(i) & hash(j)
                Number = Number + 1
            Next
        Next i
    End Sub

    Private Function getPath(ByVal pathCell As ArrayList)
        pathCell.Reverse()
        Dim pathing As String = ""
        Dim current
        Dim child
        Dim PMUsed As Integer = 0

        For i = 0 To pathCell.Count - 2
            PMUsed += 1
            If (PMUsed > nombreDePM) Then Return pathing
            current = pathCell(i)
            child = pathCell(i + 1)
            pathing &= getOrientation(current, child, Map_Largeur) & cases(child)
        Next
        Return pathing
    End Function

    Private Function getChild(ByVal cell As Integer)

        Dim x = getCaseCoordonneeX("X", cell)
        Dim y = getCaseCoordonneeY("X", cell)
        Dim children As New ArrayList
        Dim temp
        Dim locx, locy

        If fight = False Then

            temp = cell - (Map_Largeur * 2 - 1)
            locx = getCaseCoordonneeX("X", temp)
            locy = getCaseCoordonneeY("X", temp)
            If temp > 1 And temp < 1024 And locx = x - 1 And locy = y - 1 And closelist.Contains(temp) = False Then
                children.Add(temp)
            End If

            temp = cell + (Map_Largeur * 2 - 1)
            locx = getCaseCoordonneeX("X", temp)
            locy = getCaseCoordonneeY("X", temp)
            If temp > 1 And temp < 1024 And locx = x + 1 And locy = y + 1 And closelist.Contains(temp) = False Then
                children.Add(temp)
            End If

        End If

        temp = cell - Map_Largeur
        locx = getCaseCoordonneeX("X", temp)
        locy = getCaseCoordonneeY("X", temp)
        If temp > 1 And temp < 1024 And locx = x - 1 And locy = y And closelist.Contains(temp) = False Then
            children.Add(temp)
        End If

        temp = cell + Map_Largeur
        locx = getCaseCoordonneeX("X", temp)
        locy = getCaseCoordonneeY("X", temp)
        If temp > 1 And temp < 1024 And locx = x + 1 And locy = y And closelist.Contains(temp) = False Then
            children.Add(temp)
        End If

        temp = cell - (Map_Largeur - 1)
        locx = getCaseCoordonneeX("X", temp)
        locy = getCaseCoordonneeY("X", temp)
        If temp > 1 And temp < 1024 And locx = x And locy = y - 1 And closelist.Contains(temp) = False Then
            children.Add(temp)
        End If

        temp = cell + (Map_Largeur - 1)
        locx = getCaseCoordonneeX("X", temp)
        locy = getCaseCoordonneeY("X", temp)
        If temp > 1 And temp < 1024 And locx = x And locy = y + 1 And closelist.Contains(temp) = False Then
            children.Add(temp)
        End If

        If fight = False Then

            temp = cell - 1
            locx = getCaseCoordonneeX("X", temp)
            locy = getCaseCoordonneeY("X", temp)
            If temp > 1 And temp < 1024 And locx = x - 1 And locy = y + 1 And closelist.Contains(temp) = False Then
                children.Add(temp)
            End If

            temp = cell + 1
            locx = getCaseCoordonneeX("X", temp)
            locy = getCaseCoordonneeY("X", temp)
            If temp > 1 And temp < 1024 And locx = x + 1 And locy = y - 1 And closelist.Contains(temp) = False Then
                children.Add(temp)
            End If

        End If

        Return children

    End Function

    Private Function getFpoint()

        Dim x As Integer = 9999
        Dim cell As Integer

        For Each item As Integer In openlist
            If closelist.Contains(item) = False Then
                If Flist(item) < x Then
                    x = Flist(item)
                    cell = item
                End If
            End If
        Next

        Return cell
    End Function

    Public Class loc8
        Public y As Integer = 0
        Public x As Integer = 0
    End Class

    Private Function getCaseCoordonneeX(ByVal mapHandler As String, ByVal nNum As Integer) As Integer
        Dim _loc4 = Map_Largeur
        Dim _loc5 = Math.Floor(nNum / (_loc4 * 2 - 1))
        Dim _loc6 = nNum - _loc5 * (_loc4 * 2 - 1)
        Dim _loc7 = _loc6 Mod _loc4
        Dim _loc8 As New loc8

        Dim y As Integer = _loc5 - _loc7
        Dim x As Integer = (nNum - (_loc4 - 1) * y) / _loc4
        Return x
    End Function

    Private Function getCaseCoordonneeY(ByVal mapHandler As String, ByVal nNum As Integer) As Integer
        Dim _loc4 = Map_Largeur
        Dim _loc5 = Math.Floor(nNum / (_loc4 * 2 - 1))
        Dim _loc6 = nNum - _loc5 * (_loc4 * 2 - 1)
        Dim _loc7 = _loc6 Mod _loc4
        Dim _loc8 As New loc8

        Dim y As Integer = _loc5 - _loc7
        Dim x As Integer = (nNum - (_loc4 - 1) * y) / _loc4
        Return y
    End Function

    Private Function goalDistance(ByVal mapHandler As String, ByVal nCell1 As Integer, ByVal nCell2 As Integer)
        Dim _loc5x = getCaseCoordonneeX(mapHandler, nCell1)
        Dim _loc5y = getCaseCoordonneeY(mapHandler, nCell1)
        Dim _loc6x = getCaseCoordonneeX(mapHandler, nCell2)
        Dim _loc6y = getCaseCoordonneeY(mapHandler, nCell2)
        Dim _loc7 = Math.Abs(_loc5x - _loc6x)
        Dim _loc8 = Math.Abs(_loc5y - _loc6y)
        Return (_loc7 + _loc8)
    End Function

    Private Shared Function getOrientation(ByVal cell1 As Integer, ByVal cell2 As Integer, ByVal Map_Largeur As Integer) As Object

        Dim obj As Object

        Dim num As Integer = cell2 - cell1

        Select Case num
            Case 0 - (Map_Largeur * 2 - 1), -29
                obj = "g"
            Case Map_Largeur * 2 - 1, 29
                obj = "c"
            Case -1
                obj = "e"
            Case 1
                obj = "a"
            Case CShort(-Map_Largeur)
                obj = "f"
            Case Map_Largeur
                obj = "b"
            Case <> 0 - (Map_Largeur - 1)
                obj = If(num <> Map_Largeur - 1, "a", "d")
            Case Else
                obj = "h"
        End Select

        Return obj

    End Function

    Private Function cleanPath(ByVal path As String) As String

        Dim cleanedPath As String = ""

        If (path.Length > 3) Then
            For i As Integer = 1 To path.Length Step 3
                If (Mid(path, i, 1) <> Mid(path, i + 3, 1)) Then cleanedPath &= Mid(path, i, 3)
            Next
        Else
            cleanedPath = path
        End If
        Return cleanedPath

    End Function

End Class
