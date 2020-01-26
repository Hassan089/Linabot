Module Map_Information

    Public Sub S_Map_Information_Ajoute_Entité(ByVal Index As Integer, ByVal Information As String)

        With Comptes(Index)

            Try
                'GM|+ 36      ; 1 ; 0 ; 13564897  ; Linaculer ; 9       ; 90    ^100  ; 0           ;0,0,0,13574895 ; -1       ; -1       ; -1       ; 254 , 1bea                       , 1b52 ,          ,          ;0;;;;;0;;|+Suivant 
                'GM|+ 61      ; 1 ; 0 ; -9        ; 1u,65     ; -6      ; 6000  ^91   ; 5           ;Linaculer      ; 1,3hkam,2n,9y908
                'GM|+ Cellule ; ? ; ? ; ID Unique ; Nom       ; ID Race ; Classe^Sexe ; Les niveaux ;               ; Couleur1 ; Couleur2 ; Couleur3 ; Cac , Coiffe (ID Objet~Lv~Forme) , Cape , Familier , Bouclier ;

                Dim Separation As String() = Split(Information, "|+")

                For i = 1 To Separation.Count - 1

                    Dim Separation_Information As String() = Split(Separation(i), ";")

                    If Présent(Index, Separation_Information(3), .V_User.DataGridView_Map) = False Then

                        With .V_User.DataGridView_Map

                            'Image (classe)
                            Select Case Separation_Information(5)

                                Case -3, -2, -1 ' Mobs 'ou faire comme les personnages
                                    If IO.File.Exists(Application.StartupPath & "\Image\Mobs\bouftou-dofus.png") Then
                                        .Rows.Add(New Bitmap(Application.StartupPath & "\Image\Mobs\bouftou-dofus.png"))
                                    Else
                                        .Rows.Add(My.Resources.Question)
                                    End If

                                Case -4 ' PNJ
                                    If IO.File.Exists(Application.StartupPath & "\Image\PNJ\" & V_Dico_Liste_PNJ.Keys(Separation_Information(4)) & ".png") Then
                                        .Rows.Add(New Bitmap(Application.StartupPath & "\Image\PNJ\" & V_Dico_Liste_PNJ.Keys(Separation_Information(4)) & ".png"))
                                    Else
                                        .Rows.Add(My.Resources.Question)
                                    End If

                                Case -5 ' Joueur Mode Marchand
                                    If IO.File.Exists(Application.StartupPath & "\Image\Personnage\" & Separation_Information(6).Split("^")(0) & ".png") Then
                                        .Rows.Add(New Bitmap(Application.StartupPath & "\Image\Personnage\" & Separation_Information(6).Split("^")(0) & ".png"))
                                    Else
                                        .Rows.Add(My.Resources.Question)
                                    End If

                                Case -6 ' Percepteur
                                    If IO.File.Exists(Application.StartupPath & "\Image\Divers\" & Separation_Information(6).Split("^")(0) & ".png") Then
                                        .Rows.Add(New Bitmap(Application.StartupPath & "\Image\Divers\" & Separation_Information(6).Split("^")(0) & ".png"))
                                    Else
                                        .Rows.Add(My.Resources.Question)
                                    End If

                                Case -10 ' Prisme
                                    If IO.File.Exists(Application.StartupPath & "\Image\Divers\" & Separation_Information(6).Split("^")(0) & ".png") Then
                                        .Rows.Add(New Bitmap(Application.StartupPath & "\Image\Divers\" & Separation_Information(6).Split("^")(0) & ".png"))
                                    Else
                                        .Rows.Add(My.Resources.Question)
                                    End If

                                Case Else ' Joueur
                                    If IO.File.Exists(Application.StartupPath & "\Image\Personnage\" & Separation_Information(6).Split("^")(0) & ".png") Then
                                        .Rows.Add(New Bitmap(Application.StartupPath & "\Image\Personnage\" & Separation_Information(6).Split("^")(0) & ".png"))
                                    Else
                                        .Rows.Add(My.Resources.Question)
                                    End If

                            End Select

                            With .Rows(.Rows.Count - 1)

                                'Cellule
                                .Cells(1).Value = Separation_Information(0)

                                'ID Unique
                                .Cells(2).Value = Separation_Information(3)

                                'Nom
                                Select Case Separation_Information(5)

                                    Case -3, -2, -1 ' Mobs

                                        .Cells(3).Value = Name_Mobs(Separation_Information(4)) 'Nom

                                    Case -4 ' PNJ

                                        .Cells(3).Value = V_Dico_Liste_PNJ(Separation_Information(4)) 'Nom

                                    Case -5 ' Joueur mode marchand

                                        .Cells(3).Value = Separation_Information(4)

                                    Case -6 ' Percepteur

                                        .Cells(3).Value = "Percepteur" 'Nom

                                    Case -10 ' Prisme

                                        .Cells(3).Value = "Prisme" 'Prisme (info non fini = "255;1;0;-3;1112;-10;8100^90;2;4;2")

                                    Case Else ' Joueur

                                        .Cells(3).Value = Separation_Information(4) 'Nom

                                End Select

                                Dim Calcul() As String = Split(Separation_Information(8), ",")
                                If Calcul.Length <= 1 Then Calcul = Split(Separation_Information(9), ",")

                                'Niveau
                                Select Case Separation_Information(5)

                                    Case -3 ' Mobs (Hors combat)

                                        .Cells(4).Value &= "Niveau : " & Level_Mobs(Separation_Information(7)) & vbCrLf

                                    Case -2, -1 ' Mobs (En combat)

                                        .Cells(4).Value &= "Niveau : " & Liste_Des_Mobs(Separation_Information(4))(Separation_Information(7)).GetValue(1) & vbCrLf

                                    Case -4, -5 ' PNJ + Joueur mode marchand

                                        .Cells(4).Value &= "Niveau : 1" & vbCrLf

                                    Case -6 ' Percepteur

                                        .Cells(4).Value &= "Niveau : " & Separation_Information(7) & vbCrLf

                                    Case Else ' Joueur

                                        .Cells(4).Value &= "Niveau : " &
                                            If(Calcul.Length <= 1, Separation_Information(8), CInt(Calcul(3)) - CInt(Separation_Information(3))) & vbCrLf

                                End Select

                                'Race
                                Select Case Separation_Information(5)

                                    Case -3, -2, -1 ' Mobs

                                        .Cells(4).Value &= "Race : " & Separation_Information(4) & vbCrLf

                                    Case -4 ' PNJ

                                        .Cells(4).Value &= "Race : PNJ" & vbCrLf

                                    Case -5 ' Joueur mode marchand

                                        .Cells(4).Value &= "Mode Marchand"

                                    Case -6 ' Percepteur

                                        .Cells(4).Value &= "Race : Percepteur" & vbCrLf

                                    Case Else ' Joueur

                                        .Cells(4).Value &= "Race : " & Classe_Joueur(Separation_Information(6)) & vbCrLf

                                End Select

                                'Vitalité
                                Select Case Separation_Information(5)

                                    Case -2, -1 ' Mobs

                                        .Cells(4).Value &= "Vitalité : " & Separation_Information(12) & vbCrLf

                                    Case Else ' Joueur

                                        .Cells(4).Value &= "Vitalité : 0" & vbCrLf

                                End Select

                                ' Autres
                                Select Case Separation_Information(5)

                                    Case -1, -2 ' Mobs

                                        .Cells(4).Value &= "Résistance Neutre : " & Liste_Des_Mobs(Separation_Information(4))(Separation_Information(7)).GetValue(2) & vbCrLf &
                                                           "Résistance Terre : " & Liste_Des_Mobs(Separation_Information(4))(Separation_Information(7)).GetValue(3) & vbCrLf &
                                                           "Résistance Feu : " & Liste_Des_Mobs(Separation_Information(4))(Separation_Information(7)).GetValue(4) & vbCrLf &
                                                           "Résistance Eau : " & Liste_Des_Mobs(Separation_Information(4))(Separation_Information(7)).GetValue(5) & vbCrLf &
                                                           "Résistance Air : " & Liste_Des_Mobs(Separation_Information(4))(Separation_Information(7)).GetValue(6) & vbCrLf &
                                                           "Esquive PA : " & Liste_Des_Mobs(Separation_Information(4))(Separation_Information(7)).GetValue(7) & vbCrLf &
                                                           "Esquive PM : " & Liste_Des_Mobs(Separation_Information(4))(Separation_Information(7)).GetValue(8) & vbCrLf &
                                                           "PA : 0" & vbCrLf &
                                                           "PM : 0" & vbCrLf &
                                                           "PO : 0"

                                    Case Else ' Joueur

                                        .Cells(4).Value &= "Résistance Neutre : 0" & vbCrLf &
                                                           "Résistance Terre : 0" & vbCrLf &
                                                           "Résistance Feu : 0" & vbCrLf &
                                                           "Résistance Eau : 0" & vbCrLf &
                                                           "Résistance Air : 0" & vbCrLf &
                                                           "Esquive PA : 0" & vbCrLf &
                                                           "Esquive PM : 0" & vbCrLf &
                                                           "PA : 0" & vbCrLf &
                                                           "PM : 0" & vbCrLf &
                                                           "PO : 0" & vbCrLf &
                                                           "Sexe : " & Sexe_Joueur(Separation_Information(6)) & vbCrLf

                                End Select

                                'Alignement
                                If CInt(Separation_Information(5)) > 0 Then

                                    If IO.File.Exists(Application.StartupPath & "\Image\Alignement\" & Alignement_Joueur(Calcul(0)) & ".png") Then

                                        .Cells(5).Value = New Bitmap(Application.StartupPath & "\Image\Alignement\" & Alignement_Joueur(Calcul(0)) & ".png")

                                    Else

                                        .Cells(5).Value = New Bitmap(My.Resources.Question)

                                    End If

                                End If

                                'Autres
                                Select Case Separation_Information(5)

                                    Case -1, -2, -3, -4, -6 ' Mobs , Percepteur , PNJ

                                        .Cells(4).Value &= "Guilde : " & If(Separation_Information(5) = -6, Separation_Information(8), "Aucune") & vbCrLf &
                                                           "Mode Marchand : Non" & vbCrLf

                                    Case -5 ' Joueur mode marchand

                                        .Cells(4).Value &= "Guilde : " & Separation_Information(11) & vbCrLf &
                                                           "Mode Marchand : Oui" & vbCrLf

                                    Case Else ' Joueur

                                        .Cells(4).Value &= "Guilde : " & If(Calcul.Length <= 1, "", Separation_Information(16)) & vbCrLf &
                                                           "Mode Marchand : Non" & vbCrLf
                                End Select

                                Select Case Separation_Information(5)

                                    Case -1, -2, -3 ' Mobs

                                        .DefaultCellStyle.BackColor = Color.Red

                                    Case -4 ' PNJ

                                        .DefaultCellStyle.BackColor = Color.Pink

                                    Case -5 ' Mode Marchand

                                        .DefaultCellStyle.BackColor = Color.Blue

                                    Case -6 ' Percepteur

                                        .DefaultCellStyle.BackColor = Color.Orange

                                    Case Else ' Joueur

                                        .DefaultCellStyle.BackColor = Color.Cyan

                                End Select

                                'Si je suis en combat.
                                If Comptes(Index).V_En_Combat OrElse Comptes(Index).V_En_Combat_Placement Then

                                    .DefaultCellStyle.BackColor = If(Comptes(Index).V_Combat_Equipe <> Separation_Information(7), Color.Red, Color.Blue)

                                End If

                            End With

                        End With

                        ' S'il s'agit de mon ID, je donne ma case actuelle et j'indique que je suis plus en déplacement.
                        If Separation_Information(3) = Comptes(Index).V_ID_Unique Then
                            .V_Case_Actuelle = Separation_Information(0)
                            .V_En_Déplacement = False
                        End If

                    End If

                    If (Separation_Information(4) = "251" OrElse Separation_Information(3) = "251") AndAlso .V_Groupe.V_Anti_Crocoburio Then

                        EcritureMessage(Index, "[Crocoburio]", "Crocoburio sur la map ! Déconnexion pour éviter l'agression." & vbCrLf &
                                               "Reconnexion dans 1 minute.", Color.Red)

                        .V_Crocoburio = True

                        Task.Run(Sub() Connexion_Déconnexion_Joueur(Index, "DECONNEXION", 60000))

                    ElseIf Separation_Information(4).StartsWith("[") AndAlso .V_Groupe.V_Anti_Modérateur Then

                        S_Modérateur_Information_Connecté(Index, Separation_Information(4))

                    End If

                Next

                .V_User.DataGridView_Map.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .V_User.DataGridView_Map.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True

            Catch ex As Exception

                Erreur_Fichier(Index, "Map_Ajout_Joueur_Mobs", Information & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

    Public Sub S_Map_Information_Déplacement_Entité(ByVal Index As Integer, ByVal Information As String)
        With Comptes(Index)
            Try

                'GA0 ; 1 ; 03215678 ; a6z5e4r
                'GA0 ; ? ; ID_Cible ; Path 

                Dim Separation As String() = Split(Information, ";")

                For Each Line As DataGridViewRow In .V_User.DataGridView_Map.Rows

                    If Line.Cells(2).Value = Separation(2) Then

                        Line.Cells(1).Value = Initialize_Cellules_Fin_Déplacement(Mid(Separation(3), Separation(3).Length - 1, 2))

                        If Separation(2) = .V_ID_Unique Then

                            'Je suis bien en déplacement.
                            .V_En_Déplacement = 1
                            .V_Case_Actuelle = Line.Cells(1).Value

                            .V_User.Label_Statut.Text = "En Déplacement"
                            .V_User.Label_Statut.ForeColor = Color.Cyan

                            Dim Thread_Déplacement As Threading.Thread = New Threading.Thread(Sub() S_Map_Moi_Déplacement_Pause_Fin(Index, Line.Cells(1).Value)) With {.IsBackground = True}
                            Thread_Déplacement.Start()

                        End If

                        Return

                    End If

                Next

            Catch ex As Exception

                Erreur_Fichier(Index, "S_Map_Information_Déplacement_Entité", vbCrLf & ex.Message)

            End Try

        End With

    End Sub 'FINI

    Private Sub S_Map_Moi_Déplacement_Pause_Fin(ByVal Index As Integer, ByVal Cellule_Final As Integer)

        With Comptes(Index)

            Try

                If .V_Send <> "" Then
                    .Socket.Envoyer(.V_Send)
                    .V_Send = ""
                End If

                'J'attend que le bot fini de se déplacer.
                Task.Delay(If(.V_Path_Final < 9, .V_Path_Final * 160, .V_Path_Final * 65)).Wait() '180 / 95

                'Puis j'envoie au serveur la fin du déplacement.
                .Socket.Envoyer("GKK0")
                .V_En_Déplacement = False

            Catch ex As Exception

                Erreur_Fichier(Index, "S_Map_Moi_Déplacement_Pause_Fin", ex.Message)

            End Try

        End With

    End Sub

    Public Sub S_Map_Information_Retire_Entité(ByVal Index As Integer, ByVal Information As String)

        With Comptes(Index)

            Try
                'GM|- 1234567    
                'GM|- ID Unique

                ' Je prend les informations après le "GM|-"
                Information = Mid(Information, 5)

                For Each Line As DataGridViewRow In .V_User.DataGridView_Map.Rows

                    If Line.Cells(1).Value = Information Then

                        .V_User.DataGridView_Map.Rows.RemoveAt(Line.Index)

                        Return

                    End If

                Next

            Catch ex As Exception

                Erreur_Fichier(Index, "S_Map_Information_Retire_Entité", Information & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

    Public Sub S_Map_Information_Déplacement_Joueur_Escalié(ByVal Index As Integer, ByVal Information As String)

        With Comptes(Index)

            Try

                'GA1 ; 4 ; 01234567  ; 76543210 , 342
                'GA1 ; ? ; ID Joueur ; ID_Cible , Cellule

                ' Je sépare les informations via ce signe ";"
                Dim Separation As String() = Split(Information, ";")

                ' Je sépare les informations via ce signe ","
                Dim Separation_Information As String() = Split(Separation(3), ",")

                For Each Line As DataGridViewRow In .V_User.DataGridView_Map.Rows

                    If Line.Cells(2).Value = Separation_Information(0) Then

                        Line.Cells(1).Value = Separation_Information(1)

                        If Separation_Information(0) = .V_ID_Unique Then

                            .V_Case_Actuelle = Separation_Information(1)
                            .Socket.Envoyer("GKK1")
                            .V_En_Déplacement = False

                        End If

                        Return

                    End If

                Next

            Catch ex As Exception

                Erreur_Fichier(Index, "S_Map_Information_Déplacement_Joueur_Escalié", vbCrLf & ex.Message)

            End Try

        End With

    End Sub 'Sufokia > escalié

    Public Sub S_Map_Information_Modifie_Entité_Dragodinde(ByVal Index As Integer, ByVal Information As String)

        With Comptes(Index)

            ' GM|~ 103    ; 7 ; 0 ; 2626955   ; Synergyy   ; 6       ; 60    ^100  ; 0           ;1,0,5,2627155   ; 0        ; 15df     ; 8c8c8d   ;239d , 2412~16~1                  , 22ac , 8000     ,2346      ; 2 ;   ;   ; Awesomes   ; c,77f73,1m,5w3r4; 0 ;    ;
            ' GM|~ 511    ; 3 ; 0 ; 01234567  ; Linaculer  ; 8       ; 81    ^100  ; 1           ;0,0,0,01234567  ; -1       ; -1       ; -1       ;     , 986                        , 6ab  , 8000     ,          ; 0 ;   ;   ;            ;                 ; 0 ; 21 ;
            ' GM|~ CellID ; ? ; ? ; ID Unique ; Nom Joueur ; ID Race ; Classe^Sexe ; Les niveaux ; ?    ID Unique ; Couleur1 ; Couleur2 ; Couleur3 ; Cac , Coiffe (ID Objet~Lv~Forme) , Cape , Familier , Bouclier ; ? ; ? ; ? ; Nom Guilde ; ?               ; ? ; ?  ; ?      

            ' Je prend toutes les informations qui se trouve après le "GM|~"

            Information = Mid(Information, 5)

            ' Puis je sépare les informations via ce signe ";"
            Dim Separation As String() = Split(Information, ";")

            For Each Pair As DataGridViewRow In .V_User.DataGridView_Map.Rows

                If Pair.Cells(2).Value = Separation(3) Then

                    Pair.Cells(1).Value = Separation(1)

                    Return

                End If

            Next

        End With

    End Sub

    Public Sub S_Map_Information_Sprite_Item_Joueur(ByVal Index As Integer, ByVal Information As String)

        With Comptes(Index)

            ' Oa 01234567  | 239d , 2412~16~1                  , 22ac , 1d60     , 2346
            ' Oa ID Unique | Cac  , Coiffe (ID Objet~Lv~Forme) , Cape , Familier , Bouclier 

            'Je m'occupe pas de ça, inutile pour le bot.

        End With

    End Sub

#Region "Function"

    Private Function Présent(ByVal Index As Integer, ByVal ID As Integer, ByVal Datagrid_View As DataGridView) As Boolean

        With Comptes(Index)

            Try

                For Each Line As DataGridViewRow In Datagrid_View.Rows

                    If ID = Line.Cells(2).Value Then Return True

                Next

            Catch ex As Exception

                Erreur_Fichier(Index, "Présent", ex.Message)

            End Try

            Return False

        End With

    End Function

    Private Function Level_Mobs(ByVal Information As String) As Integer
        Dim Level_Total As Integer
        Try
            Dim Level() As String = Split(Information, ",")
            For i = 0 To Level.Count - 1
                Level_Total += Level(i)
            Next
        Catch ex As Exception
        End Try
        Return Level_Total
    End Function

    Private Function Name_Mobs(ByVal Information As String) As String

        Dim Résultat As String = ""

        Try

            Dim ID_Mobs() As String = Split(Information, ",")

            For i = 0 To ID_Mobs.Count - 1
                Résultat &= Liste_Des_Mobs(ID_Mobs(i))(0).GetValue(0) & vbCrLf
            Next

            ' Résultat = Mid(Résultat, 1, Len(Résultat) - 2) 'Je retire le ", " à la fin.

        Catch ex As Exception
        End Try

        Return Résultat

    End Function

    Private Function Classe_Joueur(ByVal Information As String) As String

        Try

            Dim Classe() As String = {"Feca", "Osamodas", "Enutrof", "Sram", "Xelor", "Ecaflip", "Eniripsa", "Iop", "Crâ", "Sadida", "Sacrieur", "Pandawa"}
            Dim Separation() As String = Split(Information, "^")
            Dim Résultat As Integer = Mid(Separation(0), 1, Len(Separation(0)) - 1)

            Return Classe(Résultat - 1)

        Catch ex As Exception
        End Try

        Return "Inconnu"

    End Function

    Private Function Sexe_Joueur(ByVal Information As String) As String

        Try

            Dim Sexe() As String = {"Homme", "Femme"}
            Dim Separation() As String = Split(Information, "^")

            Return Sexe(Mid(Separation(0), Len(Separation(0)), Len(Separation(0)) - 1))

        Catch ex As Exception
        End Try

        Return "Inconnu"

    End Function

    Private Function Alignement_Joueur(ByVal Information As String) As Integer

        Try

            Select Case Information

                Case 0 ' Neutre
                    Return 73
                Case 1 ' Ange
                    Return 46
                Case 2 ' Démon
                    Return 47
            End Select

        Catch ex As Exception

        End Try

        Return 0

    End Function

#End Region


End Module
