Module Co_Déco_Reco

    Public Async Sub Connexion_Déconnexion_Joueur(ByVal Index As Integer, ByVal Connexion_Déconnexion As String, Optional ByVal Temps_Reconnexion As Integer = 5000)

        With comptes(Index)

            Select Case Connexion_Déconnexion.ToUpper

                Case "CONNEXION"

                    If ._En_Connexion = False AndAlso .V_Connecté = False Then

                        EcritureMessage(Index, "[Bot]", "Le bot va connecter le compte.", Color.Green)

                        .Create_Socket_Authentification()

                    ElseIf .V_Connecté Then

                        EcritureMessage(Index, "[Bot]", "Le bot est déjà connecté.", Color.Green)

                    Else '._En_Connexion = True

                        EcritureMessage(Index, "[Bot]", "Le bot est déjà en connexion.", Color.Green)

                    End If

                Case "DECONNEXION", "DÉCONNEXION"

                    If .V_Connecté Then

                        .Socket.Connexion_Game(False)

                        EcritureMessage(Index, "[Bot]", "Le bot se déconnecte.", Color.Green)

                    ElseIf ._En_Connexion Then

                        .Socket_Authentification.Connexion_Game(False)

                        EcritureMessage(Index, "[Bot]", "Le bot se déconnecte du serveur d'authentification.", Color.Green)

                    Else

                        EcritureMessage(Index, "[Bot]", "Le bot est déjà déconnecté.", Color.Green)

                    End If

                Case "RECONNEXION"

                    Connexion_Déconnexion_Joueur(Index, "DECONNEXION")

                    Await Task.Delay(Temps_Reconnexion)

                    Connexion_Déconnexion_Joueur(Index, "CONNEXION")

            End Select

        End With

    End Sub


End Module
