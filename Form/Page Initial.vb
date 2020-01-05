Public Class Page_Initial

    Public Index As Integer

    Private Sub Page_Initial_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Label_Caractéristique_Capital.TextChanged, Sub() Caractéristique_Up(Index)

    End Sub

    Private Sub Toggle_Connexion_CheckedChanged(sender As Object) Handles Toggle_Connexion.CheckedChanged

        Select Case Toggle_Connexion.Checked

            Case True

                Connexion_Déconnexion_Joueur(Index, "Connexion")

            Case False

                Connexion_Déconnexion_Joueur(Index, "Déconnexion")

        End Select

    End Sub

#Region "Tchat"

    Private Sub Canal_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_Canal_Information_0.MouseDown, CheckBox_Canal_Communs_1.MouseDown, CheckBox_Canal_Groupe_2.MouseDown, CheckBox_Canal_Guilde_3.MouseDown, CheckBox_Canal_Alignement_4.MouseDown, CheckBox_Canal_Recrutement_5.MouseDown, CheckBox_Canal_Commerce_6.MouseDown

        'MouseDown = Evite de changer la case "Checked" en "true" ou "false", tant que le bot n'a pas reçu l'information 
        'comme quoi l'action de la personne est bien pris en compte par le jeu..

        With Comptes(Index)

            'Je vérifie être connecté avant.
            If ._Connecté Then

                'J'enregistre les informations selon le canal dans une variable qui sera un tableau.
                Dim Canaux() As String = {
                                          "i", 'Information
                                          "*", 'Défaut
                                          "#$p", 'Groupe/Equipe/Message privée
                                          "%", 'Guilde
                                          "!", 'Alignement
                                          "?", 'Recrutement
                                          ":" 'Commerce
                                         }

                'Je vérifie si la personne active le canal ou non.
                If sender.checked Then

                    'Puis j'envoie l'information, pour ça j'envoie l'information qui se trouve dans la variable "Canaux".
                    'Pour avoir le canal, je prend alors le chiffre qui se trouve à la fin du "Name" du canal actuellement sélectionné.
                    .Socket.Envoyer("cC+" & Canaux(Mid(sender.Name, Len(sender.Name), 1)))

                Else

                    .Socket.Envoyer("cC-" & Canaux(Mid(sender.Name, Len(sender.Name), 1)))

                End If

                'Réduction du code.
                '.Socket.Envoyer("cC" & If(sender.checked, "+", "-") & Canaux(Mid(sender.Name, Len(sender.Name), 1)))

            End If

        End With

    End Sub 'FINI

    Private Sub Button_Tchat_Envoyer_Click(sender As Object, e As EventArgs) Handles Button_Tchat_Envoyer.Click

        Envoie_Tchat(Index, ComboBox_Tchat.Text, TextBox_Tchat.Text)

    End Sub

    Private Sub PictureBox_Smiley_1_Click(sender As Object, e As EventArgs) Handles PictureBox_Smiley_1.Click, PictureBox_Smiley_2.Click, PictureBox_Smiley_3.Click, PictureBox_Smiley_4.Click, PictureBox_Smiley_5.Click, PictureBox_Smiley_6.Click, PictureBox_Smiley_7.Click, PictureBox_Smiley_8.Click, PictureBox_Smiley_9.Click, PictureBox_Smiley_10.Click, PictureBox_Smiley_11.Click, PictureBox_Smiley_12.Click, PictureBox_Smiley_13.Click, PictureBox_Smiley_14.Click, PictureBox_Smiley_15.Click

        With Comptes(Index)

            .Socket.Envoyer("BS" & Mid(sender.Name, Len(sender.Name)))

        End With

    End Sub

    Private Sub Canal_CheckedChanged(sender As Object, e As MouseEventArgs) Handles CheckBox_Canal_Recrutement_5.MouseDown, CheckBox_Canal_Information_0.MouseDown, CheckBox_Canal_Guilde_3.MouseDown, CheckBox_Canal_Groupe_2.MouseDown, CheckBox_Canal_Communs_1.MouseDown, CheckBox_Canal_Commerce_6.MouseDown, CheckBox_Canal_Alignement_4.MouseDown

    End Sub


#End Region


End Class
