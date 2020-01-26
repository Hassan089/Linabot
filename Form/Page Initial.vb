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
            If .V_Connecté Then

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

#End Region

#Region "Caractéristique"

    Private Sub PictureBox_Caractéristique_Vitalité_Click(sender As Object, e As EventArgs) Handles PictureBox_Caractéristique_Vitalité.Click, PictureBox_Caractéristique_Sagesse.Click, PictureBox_Caractéristique_Intelligence.Click, PictureBox_Caractéristique_Force.Click, PictureBox_Caractéristique_Chance.Click, PictureBox_Caractéristique_Agilité.Click

        Up_De_La_Caractéristique(Index, Split(sender.Name, "_")(2))

    End Sub

#End Region

#Region "Inventaire"

    Private Sub EquipéToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EquipéToolStripMenuItem.Click

        S_Equipe_Item(Index, DataGridView_Inventaire.CurrentRow.Cells(3).Value)

    End Sub

    Private Sub DéséquipperToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DéséquipperToolStripMenuItem.Click

        S_Déséquipe_Item(Index, DataGridView_Inventaire.CurrentRow.Cells(3).Value)

    End Sub

    Private Sub UtiliserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UtiliserToolStripMenuItem.Click

        S_Item_Utilise(Index, DataGridView_Inventaire.CurrentRow.Cells(3).Value)

    End Sub

    Private Sub SupprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem.Click

        Dim Quantité As String = InputBox("Veuillez indiquer la quantité à supprimer (Minimum 1)", "Quantité", "1")
        S_Item_Supprimé(Index, DataGridView_Inventaire.CurrentRow.Cells(3).Value, If(CInt(Quantité < 1), 1, Quantité))

    End Sub

    Private Sub JeterAuSolToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JeterAuSolToolStripMenuItem.Click

        Dim Quantité As String = InputBox("Veuillez indiquer la quantité à jeter au sol (Minimum 1)", "Quantité", "1")
        S_Item_Jette_Sol(Index, DataGridView_Inventaire.CurrentRow.Cells(3).Value, If(CInt(Quantité < 1), 1, Quantité))

    End Sub

    Private Sub Canal_CheckedChanged(sender As Object, e As MouseEventArgs) Handles CheckBox_Canal_Recrutement_5.MouseDown, CheckBox_Canal_Information_0.MouseDown, CheckBox_Canal_Guilde_3.MouseDown, CheckBox_Canal_Groupe_2.MouseDown, CheckBox_Canal_Communs_1.MouseDown, CheckBox_Canal_Commerce_6.MouseDown, CheckBox_Canal_Alignement_4.MouseDown

    End Sub


    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        S_Map_Information_Affichage(Index, "GDM|952|0901071600|7d395f45373957533b562f426d7d706d4a567a74397d205954325134477d3a453e5f47282a7521607e693f434a76583a504b73673e4b4d5c2e686074724d4c3060324d433a3f21364f5954273c3c374a714830675c69375a64692631607b575272593c612630733e273751777b684b3566504a7f2866382d6e3223603d6026747f472f74472962542532427f33474829")


        Return

        S_Map_Information_Ajoute_Entité(Index, "GM|+396;5;0;3013731;Braguin;4;40^100;0;0,0,0,3013890;a0900;d6ff02;40304;,1951,2057,1d5f,;1;;;Leegendary;3,9zldr,7,1wz;0;;|+35;3;0;2292186;Shadow-Law;9;90^100;0;0,0,0,2292386;303030;ac0000;505050;1d45,2412~16~1,22ac,2a32,;2;1;;Lost Saga;3,0,25,ze1h;0;;|+204;0;0;2161806;Drago-firee;8;80^100;0;0,0,0,2161995;dc0606;db0707;0;23b1,2412~16~1,23b5,,;1;;;Dragon Knights;1,3jk72,1h,mk1v;0;50;|+36;1;0;2071753;Tintin-sbh;8;80^100;0;1,56,0,2071953;ff0c0c;-1;0;1f3,2412~16~19,6a8,1ed3,250c;2;1;;L'etoile Du Nord;3,0,1m,3d1wh;0;;|+249;1;0;2730779;Haskay;9;90^100;0;2,0,0,2730978;0;2c2c2c;c5926b;2292,2412~16~1,2272,1ee7,;1;;;Awesomes;c,77f73,1m,5w3r4;0;;|+118;1;0;2850719;Madrigal;9;90^100;0;0,0,0,2850919;ffffff;802323;fbf9ba;22e3,1be7,22ac,1e19,;2;;;La Brigade-Fantome;1,2yry8,1t,0;0;;|+106;7;0;1541533;Reptilew;9;90^100;0;0,0,0,1541733;0;0;0;b4,2412~16~1,22ac,,;2;1;;Chernobil;f,9zldr,x,6k26u;0;;|+179;1;0;2815461;Killpop;12;121^100;1;2,0,0,2815661;d700d0;0;e100e1;239d,2412~16~1,22ac,1ed3,;2;;;Perco's Go;f,0,2w,9ljqo;0;;|+204;1;0;2619891;Gouge-arcane;9;90^100;0;0,0,0,2619990;-1;-1;-1;241,1bea,6ab,1f40,;0;;;;;0;;")
        S_Map_Information_Ajoute_Entité(Index, "GM|+243;7;0;-1;492,493,236;-3;1212^100,1212^100,1212^100;5,4,1;e689d9,ebbfe5,-1;0,0,0,0;f2c40c,bda64d,-1;0,0,0,0;a55ee0,ef9f4f,-1;0,0,0,0;")
        S_Map_Information_Ajoute_Entité(Index, "GM|+238;2;0;-17;Man-Devil;-5;40^100;a0a42;0;70f2c;,a51,3b9,1d60,;;;1|+163;1;0;-21;Gros-Genereux;-5;30^100;ffffff;26f7e8;ffffff;20e3,2412~16~16,205e,1a3c,;Annihilation Project;8,0,2i,2e93b;0|+367;3;0;-6;Ecknial;-5;111^100;b9baf8;607b7a;bb924b;,,6ab,,;;;0|+280;2;0;-19;Vickou;-5;30^100;3c4249;ffffff;-1;,21be,1965,1a3c,;;;1|+369;1;0;-4;Puissance-Deux;-5;90^100;0;0;ffffff;47f,1a9d,1965,1f40,;Cape Town;3,ptrg,1m,8vz0u;0|+311;2;0;-23;Kapuyop;-5;80^100;5b2f05;9e3f00;e46006;,2412~16~2,,,1bb9;;;2")

    End Sub

    Private Sub Timer_Régénération_Tick(sender As Object, e As EventArgs) Handles Timer_Régénération.Tick

        With Comptes(Index)

            If .V_Connecté AndAlso .V_En_Combat = False AndAlso .V_En_Combat_Placement = False AndAlso .V_En_Défi = False Then

                If ProgressBar_Vitalité.Value < ProgressBar_Vitalité.Maximum Then ProgressBar_Vitalité.Value += 1

            End If

        End With

    End Sub

#End Region

End Class
