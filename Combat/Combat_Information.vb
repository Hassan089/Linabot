Module Combat_Information

    Public Sub S_Combat_Information_Lancé_Map_Ajoute(ByVal Index As Integer, ByVal Information As String)

        With Comptes(Index)

            ' Gc+ 3046748    ; 4 | 3046748   ; 205          ; 0 ; -1 | -1          ; 190            ; 1 ; -1 
            ' Gc+ ID_Lanceur ; ? | ID_Joueur ; Cellule Epée ; ? ; ?  | ID Map Mobs ; Cellule Mobs   ; ? ; ? 

            ' Je sépare les informations vie ce signe "|"
            Dim Separation As String() = Split(Information, "|")

            'Je sépare les informations "Gc+3046748;4" via ce signe ";"
            Dim Separation_Information As String() = Split(Separation(0), ";")

            'J'obtient l'ID du lanceur en prenant l'information après le "Gc+"
            Dim ID_Lanceur As Integer = Mid(Separation_Information(0), 4)

            For i = 1 To Separation.Count - 1

                Separation_Information = Split(Separation(i), ";")

                'Utile uniquement pour rejoindre un combat voulu.
                'Mettre à jour quand la mapviewer sera faite ! 

            Next

        End With

    End Sub

    Public Sub S_Combat_Information_Lancé_Map_Retire(ByVal Index As Integer, ByVal Information As String)

        With Comptes(Index)

            'Gc- 1878729
            'Gc- ID Lanceur

            'Mettre ici quand la map viewer sera faite, pour retiré la possibilité de rejoindre un combat.


        End With

    End Sub

    Public Sub S_Combat_Information_Epée_Rejoint_Quitte(ByVal Index As Integer, ByVal Information As String)

        With Comptes(Index)

            ' Gt 01234567   | +      01234567 ; Linaculer ; 194    |
            ' Gt ID Lanceur | Ajoute ID       ; Nom ou ID ; Niveau |Suivant
            '+ = ajoute et - = retire

            ' Je sépare les informations via ce signe "|"
            Dim Separation As String() = Split(Information, "|")

            ' J'obtient l'ID du lancer selon le joueur ou le mobs
            Dim ID_Lanceur As Integer = Mid(Separation(0), 3)

            'Alors j'ajoute moi même l'épée.
            If F_Epée_ID_Existe(Index, ID_Lanceur) = False Then



            End If

        End With

    End Sub

    Private Function F_Epée_ID_Existe(ByVal Index As Integer, ByVal ID_Epée As Integer) As Boolean

        'Créer la boucle pour vérifier si l'ID de l'épée existe.

        Return False

    End Function

End Module
