Module Tchat


    Public Sub Envoie_Tchat(ByVal Index As Integer, ByVal Canal As String, ByVal Message As String)

        With Comptes(Index)

            Try

                If ._Connecté Then

                    If Message = "" Then

                        MsgBox("Veuillez mettre un message avant d'appuyer sur ""entrée ou envoyer""")

                        'Je vérifie que le bot n'est n'y en déplacement, n'y envoyé déjà un message et attend la réception.
                    ElseIf False = (._En_Déplacement AndAlso ._En_Tchat) Then

                        'Je trouve le canal et je vérifie s'il est bien activé avant d'envoyer le message
                        Select Case Canal

                            Case "Défaut"

                                If ._User.CheckBox_Canal_Communs_1.Checked Then
                                    .Socket.Envoyer("BM*|" & Message & "|")
                                    ._En_Tchat = True
                                End If

                            Case "Equipe"

                                If ._User.CheckBox_Canal_Groupe_2.Checked Then
                                    .Socket.Envoyer("BM#|" & Message & "|")
                                    ._En_Tchat = True
                                End If

                            Case "Message Privée"

                                'Je prend le premier mot avant le premier espace, car il s'agit du nom du joueur.
                                Dim Joueur As String = Split(Message, " ")(0)

                                'Puis je prend toutes la phrase qui se trouve après le nom du joueur, je rajoute 2 pour 
                                'enlever l'espace entre le nom du joueur et la phrase à dire.
                                If ._User.CheckBox_Canal_Groupe_2.Checked Then
                                    .Socket.Envoyer("BM" & Joueur & "|" & Mid(Message, Joueur.Count + 2, Message.Length) & "|")
                                    ._En_Tchat = True
                                End If

                            Case "Groupe"

                                If ._User.CheckBox_Canal_Groupe_2.Checked Then
                                    .Socket.Envoyer("BM$|" & Message & "|")
                                    ._En_Tchat = True
                                End If

                            Case "Guilde"

                                If ._User.CheckBox_Canal_Guilde_3.Checked Then
                                    .Socket.Envoyer("BM%|" & Message & "|")
                                    ._En_Tchat = True
                                End If

                            Case "Alignement"

                                If ._User.CheckBox_Canal_Alignement_4.Checked Then
                                    .Socket.Envoyer("BM!|" & Message & "|")
                                    ._En_Tchat = True
                                End If

                            Case "Recrutement"

                                If ._User.CheckBox_Canal_Recrutement_5.Checked Then
                                    .Socket.Envoyer("BM?|" & Message & "|")
                                    ._En_Tchat = True
                                End If

                            Case "Commerce"

                                If ._User.CheckBox_Canal_Commerce_6.Checked Then
                                    .Socket.Envoyer("BM:|" & Message & "|")
                                    ._En_Tchat = True
                                End If

                        End Select

                    End If


                End If


            Catch ex As Exception

                Erreur_Fichier(Index, "Envoie_Tchat", ex.Message)

            End Try

        End With

    End Sub

End Module
