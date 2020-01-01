Module PNJ_Information

    Public Sub PNJ_Information_Avec_Qui_Je_Parle(ByVal Index As Integer, ByVal Information As String)

        With Comptes(Index)

            'DCK -2  
            'DCK ID sur la map

            ._En_Dialogue = True

            ._User.Label_Statut.Text = "En Dialogue"
            ._User.Label_Statut.ForeColor = Color.Orange

            'J'affiche le nom du PNJ auquel je parle.

            Dim ID_Unique As String = Mid(Information, 4)

            For Each Row_Index As DataGridViewRow In ._User.DataGridView_Map.Rows

                'Je regarde si l'ID Unique correspond à l'information, je prend se qui se trouve après "DCK"
                If Row_Index.Cells(2).Value = ID_Unique Then

                    EcritureMessage(Index, "[PNJ - Dialogue]", "Je parle actuellement avec le PNJ '" & Row_Index.Cells(3).Value & "'.", Color.Green)

                    Exit For

                End If

            Next

        End With

    End Sub

    Public Sub PNJ_Information_Dialogue_Reçu(ByVal Index As Integer, ByVal Information As String)

        With Comptes(Index)

            'DQ 318                                ; 449                                   |   259     ;    329    ;
            'DQ ID Réponse (Dialogue de base)      ; Information à mettre dans le dialogue | Réponse 1 ; Réponse 2 ; etc....

            'Si l'information contient ce signe "|" ça indique que des réponses sont possible.

            If Information.Contains("|") Then

                'Je sépare les information qui se trouve après "DQ" via le signe "|"
                Dim Separation() As String = Split(Mid(Information, 3), "|")

                'Si y'a d'autres infos dans la parti ID Réponse (exemple avec le dialogue du PNJ de la banque qui indique les kamas nécessaire à l'ouverture du coffre.)
                If Separation(0).Contains(";") Then

                    'Je donne alors la première ID de réponse. (318 et non 449)
                    ._Dialogue_ID_Réponse = Split(Separation(0), ";")(0)

                Else
                    'Je donne la réponse de base, exemple "318"
                    ._Dialogue_ID_Réponse = Separation(0)

                End If

                'Puis je sépare les réponses pouvant être donnée.
                Separation = Split(Separation(1), ";")

                For i = 0 To Separation.Count - 1

                    'J'ajoute la réponse possible à la liste des réponses.
                    ._Dialogue_Réponses_Possible.Add(Separation(i))

                    EcritureMessage(Index, "[Réponse]", i + 1 & ") " & liste_Des_Réponses_PNJs(Separation(i)), Color.Cyan)

                Next


            Else 'Sinon c'est la fin du dialogue

                EcritureMessage(Index, "[PNJ - Dialogue]", "Plus aucune réponse disponible, le bot arréte le dialogue avec le pnj.", Color.Green)
                .Socket.Envoyer("DV")

            End If

        End With

    End Sub

End Module
