Module Item_Caractéristique

    Public Sub S_Item_Information_Modifie_Caractéristique(ByVal Index As Integer, ByVal Information As String)

        With Comptes(Index)

            ' OCO 2e291f2   ~ 1d5f     ~ 1        ~ 8          ~ 320#5#48#8,328#288#327#5e5,326#2#0#3,327#0#0#1d71,7c#19#0#0#0d0+25 ;
            ' OCO ID Unique ~ ID Objet ~ Quantité ~ Equipement ~ Caractéristique                                                    ; Next

            ' Je prend toutes les informations après "OCO"
            Information = Mid(Information, 4)

                'Puis je sépare les informations via ce signe ";"
                Dim Separation As String() = Split(Information, ";")

                For i = 0 To Separation.Count - 1

                    Dim Separation_Info As String() = Split(Separation(i), "~")

                    Separation_Info(0) = Convert.ToInt64(Separation_Info(0), 16) 'ID Unique
                    Separation_Info(1) = Convert.ToInt64(Separation_Info(1), 16) 'ID Objet
                    Separation_Info(2) = Convert.ToInt64(Separation_Info(2), 16) 'Quantité

                    For Each Pair As DataGridViewRow In .V_User.DataGridView_Inventaire.Rows

                        If Pair.Cells(3).Value = Separation_Info(0) Then 'ID_Unique

                            Pair.Cells(4).Value = Separation_Info(2) 'Quantité

                            Pair.Cells(5).Value = Objet_Caractéristiques(Separation_Info(1), Separation_Info(4))

                            Pair.DefaultCellStyle.BackColor = If(Separation_Info(3) <> Nothing, Color.Lime, Color.White) 'Si équipé

                            If Separation_Info(3) <> Nothing Then S_Equipement_Information_Equipé(Index, Separation_Info(1), Separation_Info(0), Separation_Info(3))

                            Exit For

                        End If

                    Next

                Next

        End With

    End Sub

    Public Function Objet_Caractéristiques(ByVal ID_Objet As String, ByVal Caractéristique As String) As String

        Try
            '76 #a             #0     #0                                      ,Next
            '7b #1             #0     #0     #0d0+1
            'ID #Divers        #Divers#Divers#Divers (surtout cac pour dégâts)

            If Caractéristique <> "" Then

                Dim Separation() As String = Split(Caractéristique.Replace("0d0+", ""), ",")

                Caractéristique = ""

                For i = 0 To Separation.Count - 1

                    Dim Separation_Info() As String = Split(Separation(i), "#")

                    Select Case Separation_Info(0)


                        Case "76" 'Force +

                            Caractéristique &= "+" & Convert.ToInt64(Separation_Info(1), 16) & " Force" & vbCrLf

                        Case "9d" 'Force -

                            Caractéristique &= "-" & Convert.ToInt64(Separation_Info(1), 16) & " Force" & vbCrLf

                        Case "7d" 'Vitalité +

                            Caractéristique &= "+" & Convert.ToInt64(Separation_Info(1), 16) & " Vitalité" & vbCrLf

                        Case "99" 'Vitalité -

                            Caractéristique &= "-" & Convert.ToInt64(Separation_Info(1), 16) & " Vitalité" & vbCrLf

                        Case "7c" 'Sagesse +

                            Caractéristique &= "+" & Convert.ToInt64(Separation_Info(1), 16) & " Sagesse" & vbCrLf

                        Case "9c" 'Sagesse -

                            Caractéristique &= "-" & Convert.ToInt64(Separation_Info(1), 16) & " Sagesse" & vbCrLf

                        Case "7e" 'Intelligence +

                            Caractéristique &= "+" & Convert.ToInt64(Separation_Info(1), 16) & " Intelligence" & vbCrLf

                        Case "9b" 'Intelligence -

                            Caractéristique &= "-" & Convert.ToInt64(Separation_Info(1), 16) & " Intelligence" & vbCrLf

                        Case "7b" 'Chance +

                            Caractéristique &= "+" & Convert.ToInt64(Separation_Info(1), 16) & " Chance" & vbCrLf

                        Case "98" 'Chance -

                            Caractéristique &= "-" & Convert.ToInt64(Separation_Info(1), 16) & " Chance" & vbCrLf

                        Case "77" 'Agilité +

                            Caractéristique &= "+" & Convert.ToInt64(Separation_Info(1), 16) & " Agilité" & vbCrLf

                        Case "9a" 'Agilité -

                            Caractéristique &= "-" & Convert.ToInt64(Separation_Info(1), 16) & " Agilité" & vbCrLf

                        Case "6f" 'PA +

                            Caractéristique &= "+" & Convert.ToInt64(Separation_Info(1), 16) & " PA" & vbCrLf

                        Case "65" 'PA -

                            Caractéristique &= "-" & Convert.ToInt64(Separation_Info(1), 16) & " PA" & vbCrLf

                        Case "80" 'PM +

                            Caractéristique &= "+" & Convert.ToInt64(Separation_Info(1), 16) & " PM" & vbCrLf

                        Case "7f" 'PM -

                            Caractéristique &= "-" & Convert.ToInt64(Separation_Info(1), 16) & " PM" & vbCrLf

                        Case "75" 'PO +

                            Caractéristique &= "+" & Convert.ToInt64(Separation_Info(1), 16) & " PO" & vbCrLf

                        Case "74" 'PO -

                            Caractéristique &= "-" & Convert.ToInt64(Separation_Info(1), 16) & " PO" & vbCrLf



                            'MANQUANT A FINIR

                        Case "b6" 'Invocation +

                            Caractéristique &= "+" & Convert.ToInt64(Separation_Info(1), 16) & " Invocation" & vbCrLf

                        Case "ae" 'Initiative +

                            Caractéristique &= "+" & Convert.ToInt64(Separation_Info(1), 16) & " Initiative" & vbCrLf

                        Case "b0" 'Prospection +

                            Caractéristique &= "+" & Convert.ToInt64(Separation_Info(1), 16) & " Prospection" & vbCrLf

                        Case "9e" 'Pods +

                            Caractéristique &= "+" & Convert.ToInt64(Separation_Info(1), 16) & " Pods" & vbCrLf

                        Case "73" 'Coups Critiques +

                            Caractéristique &= "+" & Convert.ToInt64(Separation_Info(1), 16) & " Coups Critiques" & vbCrLf

                        Case "70" 'Dommage +

                            Caractéristique &= "+" & Convert.ToInt64(Separation_Info(1), 16) & " Dommage" & vbCrLf

                        Case "e1" 'Dommage Piège +

                            Caractéristique &= "+" & Convert.ToInt64(Separation_Info(1), 16) & " Dommage Piège" & vbCrLf

                        Case "8a" '%Dommage +

                            Caractéristique &= "+" & Convert.ToInt64(Separation_Info(1), 16) & " %Dommage" & vbCrLf

                        Case "b2" 'Soin +

                            Caractéristique &= "+" & Convert.ToInt64(Separation_Info(1), 16) & " Soin" & vbCrLf

                        Case "6e" 'Régénération +

                            Caractéristique &= "+" & Convert.ToInt64(Separation_Info(1), 16) & " Régénération" & vbCrLf

                        Case "f0" 'Résistance Terre +

                            Caractéristique &= "+" & Convert.ToInt64(Separation_Info(1), 16) & " Résistance Terre" & vbCrLf

                        Case "f1" 'Résistance Eau +

                            Caractéristique &= "+" & Convert.ToInt64(Separation_Info(1), 16) & " Résistance Eau" & vbCrLf

                        Case "f2" 'Résistance Air +

                            Caractéristique &= "+" & Convert.ToInt64(Separation_Info(1), 16) & " Résistance Air" & vbCrLf

                        Case "f3" 'Résistance Feu +

                            Caractéristique &= "+" & Convert.ToInt64(Separation_Info(1), 16) & " Résistance Feu" & vbCrLf

                        Case "f4" 'Résistance Neutre +

                            Caractéristique &= "+" & Convert.ToInt64(Separation_Info(1), 16) & " Résistance Neutre" & vbCrLf

                        Case "d2" '%Résistance Terre +

                            Caractéristique &= "+" & Convert.ToInt64(Separation_Info(1), 16) & " %Résistance Terre" & vbCrLf

                        Case "d7" '%Résistance Terre -

                            Caractéristique &= "-" & Convert.ToInt64(Separation_Info(1), 16) & " %Résistance Terre" & vbCrLf

                        Case "d3" '%Résistance Eau +

                            Caractéristique &= "+" & Convert.ToInt64(Separation_Info(1), 16) & " %Résistance Eau" & vbCrLf

                        Case "d8" '%Résistance Eau -

                            Caractéristique &= "-" & Convert.ToInt64(Separation_Info(1), 16) & " %Résistance Eau" & vbCrLf

                        Case "d4" '%Résistance Air  +

                            Caractéristique &= "+" & Convert.ToInt64(Separation_Info(1), 16) & " %Résistance Air" & vbCrLf

                        Case "d9" '%Résistance Air  -

                            Caractéristique &= "-" & Convert.ToInt64(Separation_Info(1), 16) & " %Résistance Air" & vbCrLf

                        Case "d5" '%Résistance Feu +

                            Caractéristique &= "+" & Convert.ToInt64(Separation_Info(1), 16) & " %Résistance Feu" & vbCrLf

                        Case "da" '%Résistance Feu -

                            Caractéristique &= "-" & Convert.ToInt64(Separation_Info(1), 16) & " %Résistance Feu" & vbCrLf

                        Case "d6" '%Résistance Neutre +

                            Caractéristique &= "+" & Convert.ToInt64(Separation_Info(1), 16) & " %Résistance Neutre" & vbCrLf

                        Case "db" '%Résistance Neutre -

                            Caractéristique &= "-" & Convert.ToInt64(Separation_Info(1), 16) & " %Résistance Neutre" & vbCrLf

                        Case "64" 'Corps à Corps +

                            Caractéristique &= "+" & Separation_Info(4) & " Corps à Corps" & vbCrLf

                        Case "320" 'Point de vie +

                            '320#5      #48     #7
                            'pdv#Inconnu#Inconnu#Point de vie
                            Caractéristique &= "+" & Convert.ToInt64(Separation_Info(1), 16) & " Point de vie" & vbCrLf

                        Case "32" 'Inconnu

                            'Familier

                        Case "326" 'Repas et Corpulence 

                            '326#1      #0            #64
                            '   #Inconnu#Repas en trop#Repas Manquant   

                            Separation_Info(3) = Convert.ToInt64(Separation_Info(3), 16) 'Repas
                            Separation_Info(2) = Convert.ToInt64(Separation_Info(2), 16) 'Corpulence

                            If CInt(Separation_Info(3)) >= 7 Then

                                Caractéristique &= "-" & Separation_Info(3) & " Repas" & vbCrLf
                                Caractéristique &= "Corpulence : Maigrichon" & vbCrLf

                            ElseIf CInt(Separation_Info(2)) >= 7 Then

                                Caractéristique &= "+" & Separation_Info(3) & " Repas" & vbCrLf
                                Caractéristique &= "Corpulence : Obése" & vbCrLf

                            Else

                                Caractéristique &= "Corpulence : Normal" & vbCrLf

                            End If


                        Case "327" ' Dernier Repas (objet utilisé)

                            Select Case Separation_Info(3)

                                Case "842"

                                    Caractéristique &= "Dernier repas : Aliment Inconnu" & vbCrLf

                                Case "0"

                                    Caractéristique &= "Dernier repas : Aucun" & vbCrLf

                                Case Else

                                    Caractéristique &= "Dernier repas : " & Liste_Des_Objets(Convert.ToInt64(Separation_Info(3), 16)).GetValue(1) & vbCrLf

                            End Select

                        Case "328" 'Date / Heure  
                            '328#288          #396             #475 
                            '   #Année + 1370 #Mois +1 et Jour #Heure + Minute

                            Dim Année As Integer = Convert.ToInt64(Separation_Info(1), 16) + 1370
                            Dim Mois As String = Convert.ToInt64(Separation_Info(2), 16)
                            Dim Jour As Integer
                            Dim Heure As String = Convert.ToInt64(Separation_Info(3), 16)

                            Select Case Mois.Length
                                Case 1
                                    Jour = "0" & Mois
                                    Mois = "01"
                                Case 2
                                    Mois = "01"
                                Case 3
                                    Jour = Mois.Substring(1, 2)
                                    Mois = CInt(Mois.Substring(0, 1)) + 1
                                Case 4
                                    Jour = Mois.Substring(2, 2)
                                    Mois = CInt(Mois.Substring(0, 2)) + 1
                            End Select

                            If Mois.Length = 1 Then Mois = "0" & Mois

                            Caractéristique &= "Date : " & Jour & "/" & Mois & "/" & Année & vbCrLf

                            Select Case Heure.Length

                                Case 0, 1

                                    Caractéristique &= "Heure : 00:0" & Heure & vbCrLf

                                Case 2

                                    Caractéristique &= "Heure : 00" & Heure.Insert(0, ":") & vbCrLf

                                Case 3

                                    Caractéristique &= "Heure : 0" & Heure.Insert(1, ":") & vbCrLf

                                Case 4

                                    Caractéristique &= "Heure : " & Heure.Insert(2, ":") & vbCrLf

                            End Select

                        Case "3ac" 'Capacité accrue Familier

                            Caractéristique &= "Capacité accrue : Oui" & vbCrLf

                            'Dragodinde
                        Case "3e3" ' ID de la dragodinde pour avoir les caractéristiques (quand elle se trouve dans l'inventaire)

                            Caractéristique &= "ID Dragodinde : " & Convert.ToInt64(Separation_Info(1), 16) & "|" & Convert.ToInt64(Separation_Info(2), 16) & vbCrLf

                            If Separation.Length < 4 Then

                                Caractéristique &= "Nom Dragodinde : Inconnu" & vbCrLf

                            End If

                        Case "3e4" 'Nom du joueur qui posséde la dragodinde.

                            Caractéristique &= "Dragodinde (Possesseur) : " & Separation_Info(4) & vbCrLf

                        Case "3e5" 'Nom de la dragodinde

                            Caractéristique &= "Nom Dragodinde : " & Separation_Info(4) & vbCrLf

                        Case "3e6" ' Jour/ heure / minute restant.

                            Caractéristique &= "Dragodinde Validité : " & Convert.ToInt64(Separation_Info(1), 16) & "j" & Convert.ToInt64(Separation_Info(2), 16) & "h" & Convert.ToInt64(Separation_Info(3), 16) & "m" & vbCrLf

                        Case "325" 'Divers

                            Caractéristique &= "Certificat Dopeul" & vbCrLf

                        Case "26f" 'Pierre d'âme 

                            Caractéristique &= "Pierre d'âme : " & Liste_Des_Mobs(Convert.ToInt64(Separation_Info(3), 16))(0).GetValue(0) & vbCrLf

                    End Select

                    ' If Liste_Familier_ID.Contains(ID_Objet) Then Calcul_Jour_Restant_Familier(Convert.ToInt64(Separation_Info(1), 16), ID_Objet)

                Next

            End If

        Catch ex As Exception

            Erreur_Fichier(0, "Caractéristiques_Objet", Caractéristique & vbCrLf & ex.Message)

        End Try

        Return Caractéristique

    End Function

    Private Function Calcul_Jour_Restant_Familier(ByVal Caractéristique As Integer, ByVal ID_Objet As String) As String

        Dim Repas As Integer

        'Les calculs se base sur des familiers avec les stats qui coûte le plus chère à la revente du familier.

        If Caractéristique > 0 Then

            'Calcul du nombre de caractéristique manquante avant d'être full (sans la capacité accrue)
            Select Case ID_Objet

                Case 7414, 8000

                    Caractéristique = If(ID_Objet = 7414, 800, 1000) - Caractéristique
                    Caractéristique = Caractéristique / If(ID_Objet = 7414, 5, 10)

                Case 7520

                    Caractéristique = 20 - Caractéristique

                Case 9623, 7519, 7704, 9617, 7705, 8211, 7892, 8561, 7911, 7524, 7522, 7415

                    Caractéristique = 50 - Caractéristique

                Case 6978

                    Caractéristique = 400 - Caractéristique

                Case 7708, 7709, 7711, 7712, 7891, 1728, 2074, 2075, 2076, 2077, 1748, 6716

                    Caractéristique = 80 - Caractéristique

                Case 7518

                    Caractéristique = 150 - Caractéristique

                Case 7703

                    Caractéristique = 40 - Caractéristique

                Case 7710, 7713, 7706, 8677, 7714

                    Caractéristique = 10 - Caractéristique

            End Select

            'Calcul du repas
            Repas = Caractéristique * 3

            'Calcul de la caractéristique "Jour(s) restant" avant d'être full.
            Select Case ID_Objet
                Case 6978
                    Caractéristique = 3 * 3 * Caractéristique
                Case 7710, 7414, 8000, 7713, 7706, 8677, 7714, 7703, 7518, 7520, 7708, 7709, 7711, 7712, 7891, 1728, 9623, 7519, 7704, 9617, 7705, 8211,
                     7892, 8561, 7911, 7524, 7522
                    Caractéristique = 5 * 3 * Caractéristique
                Case 7415, 2074, 2075, 2076, 2077
                    Caractéristique = 11 * 3 * Caractéristique
                Case 1748, 6716
                    Caractéristique = 24 * 3 * Caractéristique
            End Select

        End If

        Return "Jour(s) : " & If(Caractéristique > 0, Caractéristique / 24 / 1.3, "0") & vbCrLf & "Repas Total Nécessaire : " & Repas

    End Function

    Public Function Comparateur_Caractéristique_Objets(ByVal Caractéristique_A_Trouver As String, ByVal Caractéristique_Item As String)

        Dim Compteur As Integer

        'Je compare les caractéristiques
        Dim Separation() As String = Split(Caractéristique_Item, vbCrLf)

        Dim Caractéristique_A_Trouver_1 As String() = Split(Caractéristique_A_Trouver, "|")

        'Je cherche via les caractéristiques voulu
        For i = 0 To Caractéristique_A_Trouver_1.Count - 1

            Dim Separation_Caractéristique_Search() As String = Split(Caractéristique_A_Trouver_1(i), " : ")

            For a = 0 To Separation.Count - 1

                Dim Separation_Caractéristiques_Item() As String = Split(Separation(a), " : ")

                'Si les caractéristiques sont les mêmes
                If Separation_Caractéristiques_Item(0).ToUpper.Replace(" ", "") = Separation_Caractéristique_Search(0).ToUpper.Replace(" ", "") Then

                    'Je regarde s'il s'agit d'un chiffre supérieur ou inférieur pour l'item recherché.
                    If CInt(Separation_Caractéristique_Search(1)) >= 0 Then

                        'Si la caract de l'item de inférieur à se que demande l'utilisateur
                        If CInt(Separation_Caractéristiques_Item(1) < Separation_Caractéristique_Search(1)) Then Return False

                        Compteur += 1

                    Else

                        'Si la caract de l'item est supérieur à se que demande l'utilisateur
                        If CInt(Separation_Caractéristiques_Item(1) > Separation_Caractéristique_Search(1)) Then Return False

                        Compteur += 1

                    End If

                End If

            Next

        Next

        If Compteur >= Caractéristique_A_Trouver.Count - 1 Then
            Return True
        Else
            Return False
        End If

    End Function
End Module
