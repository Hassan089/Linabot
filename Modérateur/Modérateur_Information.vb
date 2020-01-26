Module Modérateur_Information

    Public Sub Modérateur_Delete(ByVal Index As Integer, ByVal Message As String)
        With Comptes(Index)
            Try
                EcritureMessage(Index, "[Modérateur]", "Déjà dans ta liste d'amis (suppression de l'ami en cours...).", Color.Red)
                .Socket.Envoyer("FD*[Nemetacum]" & vbCrLf & "FL" & vbCrLf &
                                "FD*[Sisuphos]" & vbCrLf & "FL" & vbCrLf &
                                "FD*[Seydlex]" & vbCrLf & "FL" & vbCrLf &
                                "FD*[Simeth]" & vbCrLf & "FL" & vbCrLf &
                                "FD*[Toblik]" & vbCrLf & "FL" & vbCrLf &
                                "FD*[Falgoryn]" & vbCrLf & "FL" & vbCrLf &
                                "FD*[Scaarh]" & vbCrLf & "FL" & vbCrLf &
                                "FD*[Leon-Kurosaki]" & vbCrLf & "FL" & vbCrLf &
                                "FD*[Alter-Ego]" & vbCrLf & "FL" & vbCrLf &
                                "FD*[Leona-Lia]" & vbCrLf & "FL" & vbCrLf &
                                "FD*[Leon-Perdido]" & vbCrLf & "FL" & vbCrLf &
                                "FD*[Leona-Casiopea]" & vbCrLf & "FL" & vbCrLf &
                                "FD*[Artand]" & vbCrLf & "FL" & vbCrLf &
                                "FD*[Drokkalfar]" & vbCrLf & "FL" & vbCrLf &
                                "FD*[Xiphiias]" & vbCrLf & "FL" & vbCrLf &
                                "FD*[Justyss]" & vbCrLf & "FL" & vbCrLf &
                                "FD*[Eknelis]" & vbCrLf & "FL" & vbCrLf &
                                "FD*[Genki]" & vbCrLf & "FL" & vbCrLf &
                                "FD*[Ling]" & vbCrLf & "FL")
            Catch ex As Exception
                Erreur_Fichier(Index, "Modérateur_Delete", Message)
            End Try
        End With
    End Sub

    Public Sub S_Modérateur_Information_Connecté(ByVal Index As Integer, ByVal Name_Modérateur As String)

        With Comptes(Index)

            Try

                .V_Modérateur = True
                Modérateur_Delete(Index, Name_Modérateur)

                EcritureMessage(Index, "[Modérateur]", "le Modérateur " & Name_Modérateur & " est connecté ! Le bot va se déconnecter.", Color.Red)
                EcritureMessage(Index, "[Trajet]", "Suite à la connexion du modérateur, le trajet est temporairement suspendu, il reprendra après l'attente demandé que vous avez mis dans le trajet.", Color.Red)

                Task.Run(Sub() Connexion_Déconnexion_Joueur(Index, "DECONNEXION"))

                Task.Run(Sub() Modérateur_Reconnexion(Index))

            Catch ex As Exception

                Erreur_Fichier(Index, "S_Modérateur_Information_Connecté", Name_Modérateur)

            End Try

        End With

    End Sub

    Private Sub Modérateur_Reconnexion(ByVal Index As Integer)

        With Comptes(Index)

            Dim Rand As New Random

            Task.Delay(Rand.Next(60000, 600000)).Wait()

        End With

    End Sub

End Module
