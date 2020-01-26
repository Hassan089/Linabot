Imports System.IO

Module Map

#Region "Chargement Map"

    Private Sub S_Load_Map(ByVal Index As Integer, ByVal idMap As String, ByVal indice As String, ByVal clef As String)
        With Comptes(Index)
            ' Try

            .V_Map_Bas = Nothing
                .V_Map_Droite = Nothing
                .V_Map_Gauche = Nothing
                .V_Map_Haut = Nothing

                'Si le dossier map n'existe pas, alors je le créer
                If Not Directory.Exists("Maps") Then Directory.CreateDirectory("Maps")

                'Si le fichier de la map n'existe pas alors je le créer et ajoute les infos dedans.
                If Not File.Exists("Maps/" & idMap & "_" & indice & "X.txt") Then
                    Dim Unpacker As New SwfUnpacker
                    Unpacker.SwfUnpack(idMap & "_" & indice & "X.swf")
                End If

                'Je lis le fichier voulu.
                Dim mapReader As New StreamReader("Maps/" & idMap & "_" & indice & "X.txt")
                Dim mapData() As String = Split(mapReader.ReadLine, "|")
                mapReader.Close()

                .V_Map_Largeur = mapData(2)
                .V_Map_Hauteur = mapData(3)

                'Je prépare le nécessaire pour décrypt la map et connaitre se qu'il se trouve dessus.
                Dim preparedKey As String = prepareKey(clef)
                .V_Map_Data_Actuel = uncompressMap(decypherData(mapData(1), preparedKey, Convert.ToInt64(checksum(preparedKey), 16) * 2))
                .V_User.Label_Position.Text = V_liste_Des_Maps(idMap) & " (" & idMap & ")"
                Dim count As Integer = .V_Map_Data_Actuel.Count - 1
                Dim num As Integer = 0

                'J'obtient les cellules qui me permet de changer de map via les soleils.
                For i As Integer = 1 To .V_Map_Data_Actuel.Length - 1
                    If (.V_Map_Data_Actuel(i).movement > 0) Then
                        If (.V_Map_Data_Actuel(i).layerObject1Num = 1030) OrElse (.V_Map_Data_Actuel(i).layerObject2Num = 1030) Then
                            Dim x As Integer = getX(i, Index)
                            Dim y As Integer = getY(i, Index)
                            If If(x - 1 = y, True, x - 2 = y) Then
                                If .V_Map_Gauche = Nothing Then .V_Map_Gauche = i 'Gauche
                            ElseIf If(x - (.V_Map_Largeur + .V_Map_Hauteur) + 5 = y, True, x - (.V_Map_Largeur + .V_Map_Hauteur) + 5 = y - 1) Then
                                If .V_Map_Droite = Nothing Then .V_Map_Droite = i 'Droite
                            ElseIf If(y + x = (.V_Map_Largeur + .V_Map_Hauteur) - 1, True, y + x = (.V_Map_Largeur + .V_Map_Hauteur) - 2) OrElse (y + x = (.V_Map_Largeur + .V_Map_Hauteur)) Then
                                If .V_Map_Bas = Nothing Then .V_Map_Bas = i 'Bas
                            ElseIf y < 0 Then
                                y = Math.Abs(y)
                                If x - y < 3 Then If .V_Map_Haut = Nothing Then .V_Map_Haut = i 'Haut
                            End If
                        End If
                    End If
                Next

            ' Catch ex As Exception

            'Erreur_Fichier(Index, "S_Load_Map", ex.Message)

            'End Try

            LoadRessources(Index, .V_Map_Data_Actuel)
            LoadDivers(Index, .V_Map_Data_Actuel)

        End With
    End Sub

    Private Sub LoadRessources(ByVal Index As Integer, ByVal spritesHandler() As Cell)

        With Comptes(Index)

            '   Try

            ' id sprite | nom action | nom item , id action

            For i As Integer = 1 To 1000

                    If Dico_Divers.ContainsKey(spritesHandler(i).layerObject2Num) Then

                        With .V_User.DataGridView_Récolte

                            If File.Exists(Application.StartupPath & "\Image\Divers\" & spritesHandler(i).layerObject2Num & ".png") Then
                                .Rows.Add(New Bitmap(Application.StartupPath & "\Image\Divers\" & spritesHandler(i).layerObject2Num & ".png"))
                            Else
                                .Rows.Add(My.Resources.Question)
                            End If

                            With .Rows(.Rows.Count - 1)

                            ' Cellule
                            .Cells(1).Value = i.ToString

                            ' Nom
                            .Cells(2).Value = Dico_Divers(spritesHandler(i).layerObject2Num).Values(0).GetValue(0)

                            ' Nom action
                            .Cells(3).Value = Dico_Divers(spritesHandler(i).layerObject2Num).Keys(0)

                        End With

                        End With

                    End If
                Next

            .V_User.DataGridView_Récolte.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .V_User.DataGridView_Récolte.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True

            ' Catch ex As Exception

            'Erreur_Fichier(Index, "LoadRessources", ex.Message)

            'End Try

        End With

    End Sub

    Private Sub LoadDivers(ByVal Index As Integer, ByVal spritesHandler() As Cell)

        With Comptes(Index)

            '  Try

            ' id sprite | nom action | nom item , id action

            For i As Integer = 1 To 1000

                If Dico_Divers.ContainsKey(spritesHandler(i).layerObject2Num) Then

                    With .V_User.DataGridView_Divers

                        If File.Exists(Application.StartupPath & "\Image\Divers\" & spritesHandler(i).layerObject2Num & ".png") Then
                            .Rows.Add(New Bitmap(Application.StartupPath & "\Image\Divers\" & spritesHandler(i).layerObject2Num & ".png"))
                        Else
                            .Rows.Add(My.Resources.Question)
                        End If

                        With .Rows(.Rows.Count - 1)

                            ' Cellule
                            .Cells(1).Value = i.ToString

                            ' Nom
                            .Cells(2).Value = Dico_Divers(spritesHandler(i).layerObject2Num).Values(0).GetValue(0)

                            ' Nom action
                            .Cells(3).Value = Dico_Divers(spritesHandler(i).layerObject2Num).Keys(0)

                        End With

                    End With

                End If
            Next

            .V_User.DataGridView_Divers.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .V_User.DataGridView_Divers.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
            ' Catch ex As Exception

            'Erreur_Fichier(Index, "LoadRessources", ex.Message)

            'End Try

        End With

    End Sub

    Public Sub S_Map_Information_Affichage(ByVal Index As Integer, ByVal Information As String)

        With Comptes(Index)

            ' Try

            'GDM | 534    | 0706131721 | 755220465939692F276671264132675c756345246c4b463b43427a3a4d38556e3c722a356362224e343d3423333e722c3f3a7a4e23553555672c733d602062454e3d474b20633c6335763e63682c43554937222f79333f253235346863387a287039474d4070302532357d586327675668752a3b6a24622962426e78787373512c5853515626536239367320643c53 
            'GDM | ID Map | Indice     | Clef

            With .V_User
                    .DataGridView_Map.Rows.Clear()
                    .DataGridView_Récolte.Rows.Clear()
                    .DataGridView_Divers.Rows.Clear()
                    .DataGridView_Map_Sol.Rows.Clear()
                End With

                Dim Separation As String() = Split(Information, "|")

                ' Je donne l'ID de la map.
                .V_Map_ID = Separation(1)

                S_Load_Map(Index, Separation(1), Separation(2), Separation(3))

                .Socket.Envoyer("GI")

            '  Catch ex As Exception

            '  Erreur_Fichier(Index, "S_Map_Information_Affichage", Information & vbCrLf & ex.Message)

            '  End Try

        End With

    End Sub

#End Region

End Module
