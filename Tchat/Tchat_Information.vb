Imports System.IO

Module Tchat_Information

    Public Sub Canaux_Dofus(ByVal Index As Integer, ByVal Message As String)

        With Comptes(Index)._User   'cC+*#%!$:?pi^

            Try

                'Le "+" ou le "-" indique si les canaux suivant l'opérateur sont activé ou non.
                Dim Checked As Boolean = If(Mid(Message, 3, 1) = "+", True, False)

                'Puis je tcheck lettre par lettre les infos après le "+" ou le "-".
                For i = 3 To Message.Length - 1

                    Select Case Message(i)

                        Case "i" 'Information

                            .CheckBox_Canal_Information_0.Checked = Checked

                        Case "*" 'Communs/Défaut

                            .CheckBox_Canal_Communs_1.Checked = Checked

                        Case "#" ', "$", "p" 'groupe/privée/équipe

                            .CheckBox_Canal_Groupe_2.Checked = Checked

                        Case "%" 'guilde

                            .CheckBox_Canal_Guilde_3.Checked = Checked

                        Case "!" 'alignement

                            .CheckBox_Canal_Alignement_4.Checked = Checked

                        Case "?" 'recrutement

                            .CheckBox_Canal_Recrutement_5.Checked = Checked

                        Case ":" 'Commerce

                            .CheckBox_Canal_Commerce_6.Checked = Checked

                    End Select

                Next

            Catch ex As Exception

                Erreur_Fichier(Index, "Gestion_Canaux_Dofus", Message)

            End Try

        End With

    End Sub

    Public Sub Tchat_Dofus_InGame(ByVal Index As Integer, ByVal Message() As String)

        With Comptes(Index)

            Try 'cMK%|ID_Joueur|Nom_Personnage|Message|

                Message(3) = AsciiDecoder(Message(3))

                Select Case Message(0)

                    Case "cMK"

                        EcritureMessage(Index, "[General]", "[" & Message(1) & "] " & Message(2) & " : " & Message(3), Color.White)  'General

                    Case "cMK$"

                        EcritureMessage(Index, "[Groupe]", "[" & Message(1) & "] " & Message(2) & " : " & Message(3), Color.Cyan)  'Groupe

                    Case "cMK#"

                        EcritureMessage(Index, "[Equipe]", "[" & Message(1) & "] " & Message(2) & " : " & Message(3), Color.Cyan)  'Equipe

                    Case "cMKF"

                        EcritureMessage(Index, "[Privée de]", "[" & Message(1) & "] " & Message(2) & " : " & Message(3), Color.Cyan) 'Privée de 
                        Enregistre_MP_Reçu(Index, Message(2), Message(3))

                    Case "cMKT"

                        EcritureMessage(Index, "[Privée à]", "[" & Message(1) & "] " & Message(2) & " : " & Message(3), Color.Cyan)  'Privée à
                        Enregistre_MP_Reçu(Index, Message(2), Message(3))

                    Case "cMK%"

                        EcritureMessage(Index, "[Guilde]", "[" & Message(1) & "] " & Message(2) & " : " & Message(3), Color.DarkViolet) 'Guilde

                    Case "cMK!"

                        EcritureMessage(Index, "[Alignement]", "[" & Message(1) & "] " & Message(2) & " : " & Message(3), Color.DarkOrange)  'Alignement

                    Case "cMK?"

                        EcritureMessage(Index, "[Recrutement]", "[" & Message(1) & "] " & Message(2) & " : " & Message(3), Color.Gray)  'Recrutement

                    Case "cMK:"

                        EcritureMessage(Index, "[Commerce]", "[" & Message(1) & "] " & Message(2) & " : " & Message(3), Color.Brown)  'Commerce

                End Select

                If Message(1) = ._ID_Unique Then ._En_Tchat = False

            Catch ex As Exception

                Erreur_Fichier(Index, "Tchat_Dofus_InGame", ex.Message)

            End Try

        End With

    End Sub

    Private Sub Enregistre_MP_Reçu(ByVal Index As Integer, ByVal Joueur As String, ByVal Information As String)

        With Comptes(Index)

            'Si le dossier "Message" n'existe pas, je le créer        
            If Not Directory.Exists("Message") Then Directory.CreateDirectory("Message")

            'Je vérifie que le fichier "Message.txt" existe, sinon je le créer
            If Not File.Exists("Comptes/Message.txt") Then File.Create("Comptes/Message.txt").Close()

            'Je lis le fichier.
            Dim Sw_Lecture As New StreamReader(Application.StartupPath + "\Message/Message.txt")
            Dim ligne As String = Sw_Lecture.ReadToEnd

            'Puis je ferme le fichier.
            Sw_Lecture.Close()

            'J'ouvre le fichier pour y écrire se que je souhaite
            Dim Sw_Ecriture As New StreamWriter(Application.StartupPath + "\Message/Message.txt")

            ligne &= Joueur & "|" & Information & vbCrLf

            'J'écris dedans avant de le fermer.
            Sw_Ecriture.WriteLine(ligne)
            Sw_Ecriture.Close()

        End With

    End Sub

End Module
