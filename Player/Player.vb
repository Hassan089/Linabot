Imports System.Threading

Public Class Player

#Region "Création de la socket"

    Public Sub Create_Socket_Authentification()

        Socket_Authentification = New All_CallBack(Dico_Serveur("Authentification").GetValue(1), Dico_Serveur("Authentification").GetValue(2))
        AddHandler Socket_Authentification.Connexion, AddressOf e_Connexion
        AddHandler Socket_Authentification.Deconnexion, AddressOf e_Deconnexion
        AddHandler Socket_Authentification.Envoie, AddressOf e_Envoi
        AddHandler Socket_Authentification.Reception, AddressOf E_Reception

    End Sub

    Public Sub Create_Socket_Serveur_Jeu(ByVal IP As String, ByVal Port As String)

        Socket = New All_CallBack(IP, Port)
        AddHandler Socket.Deconnexion, AddressOf e_Deconnexion
        AddHandler Socket.Envoie, AddressOf e_Envoi
        AddHandler Socket.Reception, AddressOf E_Reception

    End Sub

#End Region

#Region "Gestion des évenements"

    Public Sub e_Connexion(ByVal Sender As Object, ByVal e As Socket_EventArgs)

        ' Si on est connecté au serveur Login
        Try

            With V_User

                If .InvokeRequired Then

                    .Invoke(New All_CallBack.D_All_CallBack(AddressOf e_Connexion), Sender, e)

                Else

                    'Button Connexion
                    .Toggle_Connexion.Checked = True

                    'Label indiquant le statut.
                    .Label_Statut.Text = "En Connexion"
                    .Label_Statut.ForeColor = Color.Orange

                    'Information
                    EcritureMessage(V_Index, "[Bot]", "En connexion.", Color.Green)

                End If

            End With

        Catch ex As Exception

            Erreur_Fichier(V_Index, "e_Connexion", ex.Message)

        End Try

    End Sub 'FINI

    Public Sub e_Deconnexion(ByVal Sender As Object, ByVal e As Socket_EventArgs)

        Try

            With V_User

                ' Si on est déconnnecté
                If .InvokeRequired Then

                    .Invoke(New All_CallBack.D_All_CallBack(AddressOf e_Deconnexion), Sender, e)

                Else

                    'Button Connexion/Déconnexion
                    .Toggle_Connexion.Checked = False

                    'Statut
                    .Label_Statut.Text = "Déconnecté"
                    .Label_Statut.ForeColor = Color.Red

                    'Information
                    EcritureMessage(V_Index, "[Bot]", "Déconnecté.", Color.Red)

                    'Appelle du sub qui reset les variables etc...
                    Reset_Variables()

                End If

            End With

        Catch ex As Exception

            Erreur_Fichier(V_Index, "e_Deconnexion", ex.Message)

        End Try

    End Sub 'FINI

    Private Sub Reset_Variables()

        'Connexion
        V_Connecté = 0
        _En_Connexion = 0

        'Classe
        _Classe = "Crâ"

        'Caractéristique
        _Régénération = 0
        _Pods = 0

        'Autorisation
        _Autorisation_Echange = False
        _Autorisation_Défi = False
        _Autorisation_Agression = False
        _Autorisation_Interraction = False
        _Autorisation_Attaquer_Mobs = False

        'Mort
        _Fantôme = False

        'Dialogue
        _En_Dialogue = False
        _Dialogue_ID_Réponse = 0
        _Dialogue_Réponses_Possible.Clear()

        'Craft
        _En_Craft = False
        _En_Atelier = False
        _Craft_Combiner_Moi = False
        _Craft_Combiner_Lui = False

        With V_User

            .PictureBox_Emoticône_2.Visible = False
            .PictureBox_Emoticône_3.Visible = False
            .PictureBox_Emoticône_4.Visible = False
            .PictureBox_Emoticône_5.Visible = False
            .PictureBox_Emoticône_6.Visible = False
            .PictureBox_Emoticône_7.Visible = False
            .PictureBox_Emoticône_8.Visible = False
            .PictureBox_Emoticône_9.Visible = False
            .PictureBox_Emoticône_10.Visible = False
            .PictureBox_Emoticône_11.Visible = False
            .PictureBox_Emoticône_12.Visible = False
            .PictureBox_Emoticône_13.Visible = False
            .PictureBox_Emoticône_14.Visible = False
            .PictureBox_Emoticône_15.Visible = False
            .PictureBox_Emoticône_19.Visible = False
            .PictureBox_Emoticône_21.Visible = False

            '.DataGridView_Craft_Recette.Rows.Clear()
            '.DataGridView_Craft_Paiement.Rows.Clear()
            '.DataGridView_Craft_Prime_Si_Réussite.Rows.Clear()
            '.RedemptionTextBox_Craft_Paiement.Text = "0"
            '.RedemptionTextBox_Craft_Paiement_Si_Réussite.Text = "0"
            '.RedemptionTextBox_Craft_Quantité.Text = "0"

        End With

        'Echange
        _En_Echange = False

        'Hotel de vente
        _En_Hôtel_De_Vente = False

        'Achat_Vente
        _En_Achat_Vente = False

        'Banque ou Coffre
        _En_Banque_Coffre = False

        'Enclo
        _En_Enclos = False

        'Déplacement
        V_En_Déplacement = False

        'Tchat
        _En_Tchat = False

        'Combat
        _Combat_Cadenas_Bloqué = False
        _Combat_Groupe_Bloqué = False
        _Combat_Spectateur_Bloqué = False
        V_En_Combat = False
        V_En_Combat_Placement = False

        'Map
        V_Map_ID = 0
        V_Map_Bas = 0
        V_Map_Haut = 0
        V_Map_Gauche = 0
        V_Map_Droite = 0
        V_Map_Hauteur = 0
        V_Map_Largeur = 0
    End Sub

    Public Sub e_Envoi(ByVal Sender As Object, ByVal e As Socket_EventArgs)

        ' Si on envoie quelque chose
        Try

            With V_User

                If .InvokeRequired Then

                    .Invoke(New All_CallBack.D_All_CallBack(AddressOf e_Envoi), Sender, e)

                Else  'Loger

                    .RichTextBox_Socket.SelectionColor = Color.Red
                    .RichTextBox_Socket.AppendText("[" & TimeOfDay & "] " & "Send : " & e.Message.Replace(Chr(10), "").Replace(Chr(0), "") & vbCrLf)
                    .RichTextBox_Socket.ScrollToCaret()

                End If

            End With

        Catch ex As Exception

            Erreur_Fichier(V_Index, "e_Envoi", ex.Message)

        End Try

    End Sub

    Public Sub E_Reception(ByVal Message As Object, ByVal e As Socket_EventArgs)

        If e.Message <> Nothing Then

            '  Try

            If V_User.InvokeRequired Then

                V_User.Invoke(New All_CallBack.D_All_CallBack(AddressOf E_Reception), Message, e)

            Else

                'Loger
                V_User.RichTextBox_Socket.SelectionColor = Color.Blue
                V_User.RichTextBox_Socket.AppendText("[" & TimeOfDay & "] " & "Recv : " & e.Message & vbCrLf)
                V_User.RichTextBox_Socket.ScrollToCaret()

                'Selection des infos
                Select Case Mid(e.Message, 1, 1)
                    Case "A"

                        Select Case Mid(e.Message, 2, 1)

                            Case "B" 'AB

                                Select Case Mid(e.Message, 3, 1)

                                    Case "E" 'ABE

                                        'Indique que je n'est pas asse de point pour continuer de up la caractéristique voulu.
                                        EcritureMessage(V_Index, "[Caractéristique]", "Impossible de up la caractéristique.", Color.Red)

                                    Case Else

                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                End Select

                            Case "c" 'Ac

                                Select Case Mid(e.Message, 3, 1)

                                    Case 2, 0 'Ac2

                                    Case Else

                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                End Select

                            Case "d" 'Ad

                                'Ad Linaculer
                                'Ad Pseudo du compte.

                                EcritureMessage(V_Index, "(Dofus)", "Pseudo : " & Mid(e.Message, 3), Color.Green)

                            Case "f" 'Af

                                Select Case Mid(e.Message, 3, 1)

                                    Case 2 ' Af2|3|0||-1

                                    Case 1 ' Af1|2|0||-1  

                                    Case 0 ' Af0|0|0|1|601

                                    Case Else

                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                End Select

                            Case "g" 'Ag

                                Select Case Mid(e.Message, 3, 1)

                                    Case 1 'Ag1

                                        'Ag1|316746659|Pousse+de+Tanfouguite|L%27existence+de+cette+plante+est+aussi+myst%C3%A9rieuse+et+improbable+que+son+nom.+A+la+fois+ici+et+ici%2C+mais+pas+maintenant%2C+heureusement+qu%27elle+n%27est+pas+ailleurs%2C+on+n%27y+comprendrait+plus+rien.+Amenez-la+au+temple+Xelor+d%27Amakna+%28coordonn%C3%A9es+3%2C1%29+%2C+seuls+des+illumin%C3%A9s+comme+eux+peuvent+tenter+d%27y+comprendre+quelque+chose.||13ce1     ~ 2596     ~ 1        ~   ~ 3d7#258#1#64    ; 
                                        'Ag1|ID Unique| Nom Item            |Description                                                                                                                                                                                                                                                                                                                                                               ||ID_Unique ~ ID Objet ~ Quantité ~ ? ~ Caractéristique ;? (id_unique à la fin indique le contenue visible quand on voit les personnages et qu'on atribut les cadeaux)

                                        Dim Separation() As String = Split(e.Message, "|")

                                        'Créer le sub pour ajouter le contenue à un personnage.

                                        'Je remplace les "+" par des espaces.
                                        EcritureMessage(V_Index, "(Dofus)", "Contenue : " & Separation(2).Replace("+", " ") & ". Description : " & AsciiDecoder(Separation(3).Replace("+", " ")), Color.Green)

                                    Case Else

                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                End Select

                            Case "H" 'AH

                                Select Case Mid(e.Message, 3, 1)

                                    Case "6" 'AH601;1;75;1|605;1;75;1|609;1;75;1|604;1;75;1|608;1;75;1|603;1;75;1|607;1;75;1|611;1;75;1|602;1;75;1|606;1;75;1|610;1;75;1

                                        'AH 601       ;1           ;75     ;1      |602;1;75;1
                                        'AH ID_Serveur;Etat_Serveur;Inconnu;Inconnu|Serveur suivant

                                        Packet_Serveur(V_Index, e.Message)

                                    Case Else

                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                End Select

                            Case "L" 'AL

                                Select Case Mid(e.Message, 3, 1)

                                    Case "K" 'ALK

                                        'ALK 25487456210     |4             |1234567      ;Linaculer     ;101   ;90    ;-1      ;-1      ;-1      ;48a,1bea  ,1b0f,1f40    , ;0;601       ; ; ; |Next personnage
                                        'ALK Abonnement_Dofus|Nbr_Personnage|ID_Personnage;Nom_Personnage;Niveau;Classe;Couleur1;Couleur2;Couleur3;Cac,Coiffe,Cape,Familier,?;?;ID_Serveur;?;?;?|Next

                                        Dim Separation() As String = Split(e.Message, "|")

                                        EcritureMessage(V_Index, "(Info)", "Réception des personnages. (" & Separation(1) & ")", Color.Green)

                                        For i = 2 To Separation.Count - 1

                                            Dim Separation_Info() As String = Split(Separation(i), ";")

                                            'Je regarde si le nom du personnage correspond à celui voulu par l'utilisateur. (Je mets en majuscule par sécurité, si la personne oublie une majuscule ou autre)
                                            If Separation_Info(1).ToUpper = _Nom_Du_Personnage.ToUpper Then

                                                'Si oui, je prend alors l'ID unique du personnage.
                                                V_ID_Unique = Separation_Info(0)

                                                EcritureMessage(V_Index, "(Info)", "Connexion au personnage : " & Separation_Info(1) &
                                                  " (Classe = " & Dico_Personnage(Separation_Info(3)).GetValue(1) & " - " & Dico_Personnage(Separation_Info(3)).GetValue(2) & ") (Niveau = " & Separation_Info(2) & ").", Color.Green)

                                                'J'envoie l'ID du personnage sur lequel je souhaite me connecter.
                                                Socket.Envoyer("AS" & V_ID_Unique)
                                                Socket.Envoyer("Af")

                                                Exit For

                                            End If

                                        Next

                                    Case Else

                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                End Select

                            Case "l" 'Al

                                Select Case Mid(e.Message, 3, 1)

                                    Case "E" 'AlE

                                        'Je déconnecte le bot.
                                        Socket_Authentification.Connexion_Game(False)

                                        Select Case Mid(e.Message, 4, 1)

                                            Case "a" 'AlEa
                                                EcritureMessage(V_Index, "[Dofus]", "Déjà en connexion.", Color.Red)

                                            Case "b" 'AlEb
                                                EcritureMessage(V_Index, "[Dofus]", "Votre compte à été banni.", Color.Red)

                                            Case "c" 'AlEc
                                                EcritureMessage(V_Index, "[Dofus]", "Vous êtes déjà connécté au serveur du jeu.", Color.Red)

                                            Case "d" 'AlEd
                                                EcritureMessage(V_Index, "[Dofus]", "Vous avez déconnecté une personne utilisant le compte.", Color.Red)

                                            Case "f" 'AlEf
                                                EcritureMessage(V_Index, "[Dofus]", "Mauvais mot de passe.", Color.Red)

                                            Case "k" 'AlEk
                                                'AlEk Jour | Heure | Minute

                                                Dim Separation() As String = Split(Mid(e.Message, 5), "|")

                                                'Le like me permet de regarde si le résultat correspond à chaque séparation.
                                                If "1" = Separation(0) Like (Separation(1) Like Separation(2)) Then
                                                    EcritureMessage(V_Index, "[Dofus]", "Compte invalide, si vous avez 1j 1h 1m, il s'agît d'une IP bannie définitivement" & vbCrLf & "il vous suffit de changer d'IP pour régler le problème.", Color.Red)
                                                Else
                                                    EcritureMessage(V_Index, "[Dofus]", "Ton compte est invalide pendant " & Separation(0) & " Jour(s) " & Separation(1) & " Heure(s) " & Separation(2) & " Minute(s)'.", Color.Red)
                                                End If

                                            Case "n" 'AlEn
                                                EcritureMessage(V_Index, "[Dofus]", "La connexion ne sait pas faite corréctement.", Color.Red)

                                            Case "p" 'AlEp
                                                EcritureMessage(V_Index, "[Dofus]", "Votre compte n'est pas valide.", Color.Red)

                                            Case "s" 'AlEs
                                                EcritureMessage(V_Index, "[Dofus]", "Le Pseudo est déjà utilisé, veuillez en choisir un autre.", Color.Red)

                                            Case "v" 'AlEv1.30.1

                                                EcritureMessage(V_Index, "[Dofus]", "La version de DOFUS installée est invalide pour ce serveur. Pour accéder au jeu, la version '" & Mid(e.Message, 5) & "' est nécessaire.", Color.Red)

#Region "Mise à jours de la version"
                                                'Mise à jour de la version automatiquement (celui du fichier)
                                                Dim SW_Lecture As New IO.StreamReader(Application.StartupPath & "\Data/Serveur.txt")
                                                Dim ligne As String = SW_Lecture.ReadToEnd

                                                'Puis je ferme le fichier.
                                                SW_Lecture.Close()

                                                'Je remplace la version actuel par la nouvelle.
                                                ligne = ligne.Replace(Dico_Serveur("Authentification").GetValue(3), Mid(e.Message, 5))

                                                'Je met aussi à jour le dico.
                                                Dico_Serveur("Authentification").SetValue(Mid(e.Message, 5), 3)

                                                'J'ouvre le fichier pour y écrire se que je souhaite
                                                Dim Sw_Ecriture As New IO.StreamWriter(Application.StartupPath + "\Data/Serveur.txt")

                                                'J'écris dedans avant de le fermer.
                                                Sw_Ecriture.WriteLine(ligne)

                                                'Puis je le ferme.
                                                Sw_Ecriture.Close()

#End Region

                                            Case "w" 'AlEw
                                                EcritureMessage(V_Index, "[Dofus]", "Le serveur est complet. (Vous n'étes donc plus abonnée)", Color.Red)

                                            Case Else
                                                Information_Inconnu(V_Index, "Unknow", e.Message)

                                        End Select

                                    Case "K" 'AlK

                                        Select Case Mid(e.Message, 4, 1)

                                            Case 0 'AlK0

                                                Socket_Authentification.Envoyer("Ax")

                                            Case Else

                                                Information_Inconnu(V_Index, "Unknow", e.Message)

                                        End Select

                                    Case Else

                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                End Select

                            Case "N" 'AN

                                'AN 2
                                'AN Level = Up d'un level, je passe niveau 2

                                Niveau_Up(V_Index, Mid(e.Message, 3))

                            Case "Q" 'AQ Question secréte

                                'Exemple : 
                                'AQ Quel+est+mon+mod%C3%A8le+de+voiture+pr%C3%A9f%C3%A9r%C3%A9+%3F
                                'AQ Question secréte

                                'Je remplace les "+" par un espace.
                                If e.Message.Length > 2 Then
                                    EcritureMessage(V_Index, "(Dofus)", "Question secréte : " & AsciiDecoder(Mid(e.Message.Replace("+", " "), 3)), Color.Green)
                                End If

                            Case "q" 'Aq

                                'Aq 1
                                'Aq Position dans la queu.

                                EcritureMessage(V_Index, "(Dofus)", "Connexion au serveur... ( Position dans la file d'attente : " & Mid(e.Message, 3) & " )", Color.Green)

                                'Si la file d'attente est supérieur à 1, je refresh la file d'attente. toutes les 5 secondes.
                                If CInt(Mid(e.Message, 3)) > 1 Then File_Attente_Refresh(V_Index)

                            Case "R" 'AR

                                'AR 6bk 
                                'AR 6bk (ou autre) = les droits du personnage, genre échanger, défi, agresser etc.
                                'Utile pour connaître les droits en fantôme/transformation etc.
                                '(NON FINI)
                                Statut_Information_Peronnage_Autorisation(V_Index, Base36ToDec(Mid(e.Message, 3)))

                            Case "S" 'AS


                                Select Case Mid(e.Message, 3, 1)

                                    Case "K" 'ASK

                                        'ASK|01234567 |Linaculer     |99     9|0|90    |-1      |-1      |-1      |a4dc564       ~1fd6   ~1       ~0                ~7d#63#0#0#0d0+99,7c#16#0#0#0d0+22;
                                        'ASK|ID_Joueur|Nom_Personnage|Niveau|?|?|Classe|Couleur1|Couleur2|Couleur3|ID_Unique_Item~ID_Item~Quantité~Numéro_Equipement~Caractéristiques,Caractéristiques;Item Suivant

                                        If V_Connecté = 0 Then

                                            'Je vide tout mon inventaire
                                            V_User.DataGridView_Inventaire.Rows.Clear()

                                            Dim Separation() As String = Split(e.Message, "|")

                                            V_User.Label_Niveau.Text = "Niveaux : " & Separation(3)

                                            EcritureMessage(V_Index, "(Info)", "Connecté au personnage : " & Separation(2) &
                                                               " (Classe = " & Dico_Personnage(Separation(6)).GetValue(2) & ") (Niveaux = " & Separation(3) & ").", Color.Green)

                                            _Classe = Dico_Personnage(Separation(6)).GetValue(1)

                                            EcritureMessage(V_Index, "[Inventaire]", "Réception de l'inventaire.", Color.Green)

                                            Separation = Split(Separation(10), ";")

                                            'Puis j'ajoute les Items.
                                            Items_Ajoute_DatagridView(V_Index, Separation, V_User.DataGridView_Inventaire)

                                            EcritureMessage(V_Index, "[Inventaire]", "Fin de la réception de l'inventaire.", Color.Green)

                                            'J'envoie la donnée pour être sur la carte et indiqué que je suis correctement connecté.
                                            Socket.Envoyer("GC1")

                                            'Je change la valeur des variables.
                                            V_Connecté = True
                                            _En_Connexion = False

                                            EcritureMessage(V_Index, "(Info)", "Connecté !.", Color.Green)

                                            'Statut
                                            V_User.Label_Statut.Text = "En Attente"
                                            V_User.Label_Statut.ForeColor = Color.White

                                        End If

                                    Case Else

                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                End Select

                            Case "s" 'As

                                Caractéristiques_Joueur(V_Index, e.Message)

                            Case "T" 'AT

                                Select Case Mid(e.Message, 3, 1)

                                    Case "E" 'ATE  co trop lente

                                        'Je déconnecte le bot.
                                        Socket_Authentification.Connexion_Game(False)
                                        EcritureMessage(V_Index, "(Dofus)", "Connexion interrompue avec le serveur." & vbCrLf &
                                                                               "Votre connexion est trop lente ou instable.", Color.Red)

                                    Case "K" 'ATK

                                        Select Case Mid(e.Message, 4, 1)

                                            Case "0" 'ATK0

                                                Socket.Envoyer("Ak0")
                                                Socket.Envoyer("AV")

                                            Case Else

                                                Information_Inconnu(V_Index, "Unknow", e.Message)

                                        End Select

                                    Case Else

                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                End Select

                            Case "V" 'AV    '-----

                                Select Case Mid(e.Message, 3, 1)

                                    Case "0" 'AV0

                                        Socket.Envoyer("Agfr")
                                        'Socket.Envoyer("AiCode") = ?
                                        Socket.Envoyer("AL")
                                        Socket.Envoyer("Af")

                                    Case Else

                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                End Select

                            Case "X" 'AX

                                Select Case Mid(e.Message, 3, 1)

                                    Case "E" 'AXE

                                        'Je déconnecte le bot.
                                        Socket_Authentification.Connexion_Game(False)
                                        EcritureMessage(V_Index, "[Dofus]", "Serveur en sauvegarde.", Color.Red)

                                    Case "K" 'AXK

                                        'AXK 98752:98 gr5   32tr9f
                                        'AXK IP       Port  Ticket 

                                        '98752:98 = IP 
                                        'gr5 = Port

                                        EcritureMessage(V_Index, "(Info)", "Récuperation du Ticket.", Color.Green)

                                        'J'obtient le ticket pour me connecté au serveur de jeu.
                                        _Ticket = Mid(e.Message, 15) 'Ticket

                                        EcritureMessage(V_Index, "(Info)", "Récuperation de l'IP et du port du serveur.", Color.Green)

                                        'Je me connecte au serveur de jeu.
                                        Create_Socket_Serveur_Jeu(Décrypt_IP(Mid(e.Message, 4, 8)), Décrypt_Port(Mid(e.Message, 12, 3)))

                                    Case Else

                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                End Select

                            Case "x" 'Ax

                                Select Case Mid(e.Message, 3, 1)

                                    Case "K" 'AxK

                                        'AxK 197766872       |601    ,4        |
                                        'AxK Abonnement en MS|Serveur,Nbr_Perso|Etc...

                                        'J'obtient le temps d'abonnement restant en milliseconde ainsi que le nombre de personnage sur X serveur.
                                        Dim Separation() As String = Split(e.Message, "|")

                                        Dim _Chiffre As String = Mid(Separation(0), 4, Separation(0).Length)

                                        Dim _Date As Date = DateAdd("s", _Chiffre \ 1000, Date.Now) 's = seconde

                                        'J'ajoute à la date actuel le nbr de seconde d'abonnemenbt restant indiqué par dofus. (Vu qu'il s'agit de milliseconde, je divise par 1000 pour l'avoir en seconde.)
                                        V_User.Label_Abonnement_Dofus.Text = "Abonné jusqu'au : " & _Date

                                        For i = 1 To Separation.Count - 1

                                            Dim Separation_Info() As String = Split(Separation(i), ",")

                                            For Each Pair In Dico_Serveur

                                                'Je regarde si le code du serveur correspond à celui de la separation.
                                                If Pair.Value(3) = Separation_Info(0) Then

                                                    EcritureMessage(V_Index, "(Dofus)", Pair.Key & " = " & Separation_Info(1) & " personnage(s).", Color.Green)

                                                    Exit For

                                                End If

                                            Next

                                        Next

                                        EcritureMessage(V_Index, "(Info)", "Connexion au serveur : " & _Serveur, Color.Green)

                                        'J'envoie l'information sur le serveur où je souhaite me connecter (Il s'agit du code de connexion).
                                        Socket_Authentification.Envoyer("AX" & Dico_Serveur(_Serveur).GetValue(3))

                                End Select

                            Case "Y" 'AY

                                Select Case Mid(e.Message, 3, 1)

                                    Case "K" 'AYK

                                        MsgBox(e.Message) 'Je met un msg pour savoir quand je le reçoit, Tcheck log socket à ce moment.
                                        ' Create_Socket_Serveur_Jeu()

                                    Case Else

                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                End Select

                            Case Else

                                Information_Inconnu(V_Index, "Unknow", e.Message)

                        End Select

                    Case "a"

                        Select Case Mid(e.Message, 2, 1)

                            Case "l" 'al

                                'al|270;0|49;1|319;0|98;0|147;0|466;2|245;0| = Inconnu

                            Case Else

                                Information_Inconnu(V_Index, "Unknow", e.Message)

                        End Select

                    Case "B"

                        Select Case Mid(e.Message, 2, 1)

                            Case "T" 'BT1555752084620  = 'Inconnu 

                            Case "D" ' BD649|5|27  = Année 649 + 1370 = 2019 | 5 = le mois, faut rajouter +1 pour 6 = juin | 27 = le jour actuel

                            Case "p" 'Bp = Inconnu

                            Case "N" 'BN

                            Case "X"

                                Select Case Mid(e.Message, 3, 1)

                                    Case "|"

                                        Select Case Mid(e.Message, 4, 1)


                                            Case "+" 'BX|+Cellule;?;?;ID_Joueur;Nom_Personnage;Level;Classe;?;?,?,?,ID_Autre_Joueur;Couleur1;Couleur2;Couleur3;Cac,Coiffe,Cape,Familier,?;?;?;?;?;?;?;?;

                                            Case "-" 'BX|-ID_Joueur

                                            Case Else

                                                Information_Inconnu(V_Index, "Unknow", e.Message)

                                        End Select

                                    Case "0" 'BX0;1;ID_Joueur;Path

                                    Case "1" 'BX1 ID_Joueur

                                    Case ";"

                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                    Case Else

                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                End Select

                            Case "Z"

                                Select Case Mid(e.Message, 3, 1)

                                    Case "|"

                                        Select Case Mid(e.Message, 4, 1)

                                            Case "+" 'BZ|+Cellule;?;?;ID_Joueur;Nom_Personnage;Level;Classe;?;?,?,?,ID_Autre_Joueur;Couleur1;Couleur2;Couleur3;Cac,Coiffe,Cape,Familier,?;?;?;?;?;?;?;?;

                                            Case "-" 'BZ|-ID_Joueur

                                            Case Else

                                                Information_Inconnu(V_Index, "Unknow", e.Message)

                                        End Select

                                    Case "0" 'BZ0;1;ID_Joueur;Path

                                        Select Case Mid(e.Message, 4, 1)

                                            Case "1" 'BZ0188;Nom_Personnage

                                            Case Else

                                                Information_Inconnu(V_Index, "Unknow", e.Message)

                                        End Select

                                    Case "K" 'BZK|1|Nom_Personnage

                                    Case ";"

                                        Select Case Mid(e.Message, 4, 1)

                                            Case "9" 'BZ;903;ID_Joueur;t

                                            Case Else

                                                Information_Inconnu(V_Index, "Unknow", e.Message)

                                        End Select

                                    Case Else

                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                End Select

                            Case "S" 'BS4

                                Socket.Envoyer("cS" & V_ID_Unique & "|" & Mid(e.Message, 3, 1))

                            Case Else

                                Information_Inconnu(V_Index, "Unknow", e.Message)

                        End Select

                    Case "b"

                        Information_Inconnu(V_Index, "Unknow", e.Message)

                    Case "C"

                        Information_Inconnu(V_Index, "Unknow", e.Message)

                    Case "c"

                        Select Case Mid(e.Message, 2, 1)

                            Case "M" 'cM

                                Select Case Mid(e.Message, 3, 1)

                                    Case "K" 'cMK%|ID_Joueur|Nom_Personnage|Message|

                                        Tchat_Dofus_InGame(V_Index, Split(e.Message, "|"))

                                    Case Else

                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                End Select

                            Case "C" 'cC+*#%!$:?pi^

                                'Permet de savoir les canaux ouvert ou fermé sur dofus.
                                Canaux_Dofus(V_Index, e.Message)

                            Case "S" 'cS

                                Smiley(V_Index, e.Message)

                            Case Else

                                Information_Inconnu(V_Index, "Unknow", e.Message)

                        End Select

                    Case "D"

                        Select Case Mid(e.Message, 2, 1)

                            Case "C" 'DC

                                Select Case Mid(e.Message, 3, 1)

                                    Case "E" 'DCE 

                                        'DCE = Indique que c'est la fin du dialogue, il faut donc envoyer "DV" indiquant que vous avez fini de parler avec le pnj.
                                        Socket.Envoyer("DV")

                                    Case "K" 'DCK   

                                        PNJ_Information_Avec_Qui_Je_Parle(V_Index, e.Message)

                                    Case Else

                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                End Select

                            Case "Q" 'DQ

                                PNJ_Information_Dialogue_Reçu(V_Index, e.Message)

                            Case "E" 'DE

                                'Indique que je suis déjà en dialogue.
                                EcritureMessage(V_Index, "[Dialogue PNJ]", "Impossible de parler au PNJ, je suis déjà en dialogue.", Color.Green)

                            Case "V" 'DV

                                _En_Dialogue = 0
                                _Dialogue_ID_Réponse = 0
                                _Dialogue_Réponses_Possible.Clear()

                                EcritureMessage(V_Index, "[Dialogue PNJ]", "J'ai fini de parler au PNJ.", Color.Green)

                                V_User.Label_Statut.Text = "En Attente"
                                V_User.Label_Statut.ForeColor = Color.White

                            Case Else

                                Information_Inconnu(V_Index, "Unknow", e.Message)

                        End Select

                    Case "d"

                        Information_Inconnu(V_Index, "Unknow", e.Message)

                    Case "E"

                        Select Case Mid(e.Message, 2, 1)

                            Case "A" 'EA

                                'EA 15
                                'EA Quantité restante.

                                EcritureMessage(V_Index, "[Craft]", "Craft Restant : " & Mid(e.Message, 3), Color.YellowGreen)

                            Case "a" 'Ea

                                    'Craft_Information_Fin_Du_Craft(V_Index, e.Message)

                            Case "b" 'Eb

                                Select Case Mid(e.Message, 3, 1)

                                        'Anti bot ?

                                    Case "0" 'Eb0 

                                        Dim Separation() As String = Split(e.Message, ";")

                                        Select Case Mid(e.Message, 4, 1)

                                            Case ";"  'Eb0;1;ID_Joueur;Path 

                                                Socket.Envoyer("Eb" & CInt(Separation(2)) - 352)

                                            Case "1" 'Eb0188;Nom_Personnage

                                                Socket.Envoyer("Eb" & V_ID_Unique)

                                        End Select

                                    Case "|"

                                        Select Case Mid(e.Message, 4, 1)

                                            Case "+" 'Eb|+Cellule;?;?;ID_Joueur;Nom_Personnage;Level;Classe;?;?,?,?,ID_Autre_Joueur;Couleur1;Couleur2;Couleur3;Cac,Coiffe,Cape,Familier,?;?;?;?;?;?;?;?;

                                            Case "-" 'Eb|-ID_Joueur

                                            Case Else

                                                Information_Inconnu(V_Index, "Unknow", e.Message)

                                        End Select

                                    Case Else

                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                End Select

                            Case "C" 'EC

                                Select Case Mid(e.Message, 3, 1)

                                    Case "K" 'ECK

                                        'Interraction_Information_Action_En_Jeu(V_Index, e.Message)

                                    Case Else

                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                End Select

                            Case "c" 'Ec

                                _En_Craft = True

                                Select Case Mid(e.Message, 3, 1)

                                    Case "K" 'EcK

                                            'Craft_Information_Craft_Réussi(V_Index, e.Message)

                                    Case "E" 'EcE

                                        Select Case Mid(e.Message, 4, 1)

                                            Case "I" 'EcEI

                                                EcritureMessage(V_Index, "[Craft]", "Cette recette ne donne rien !", Color.Red)

                                            Case "F" 'EcEF

                                                EcritureMessage(V_Index, "[Craft]", "La recette est bonne mais a échoué !", Color.Red)

                                            Case Else

                                                Information_Inconnu(V_Index, "Unknow", e.Message)

                                        End Select

                                    Case Else

                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                End Select

                                'Vu que les Objets on disparue, je vide toutes les pictureboxs dans le craft.
                                Dim Groupe_Box() As GroupBox '= {V_User.GroupBox_Craft_Combiner_Moi, V_User.GroupBox_Craft_Combiner_Lui}

                                For i = 0 To 1

                                    'Je vais regarder dans les 2 groupboxs, les controls qu'il contient.
                                    For Each Objet As Control In Groupe_Box(i).Controls

                                        'S'il s'agit d'une Picturebox alors je continue.
                                        If TypeOf Objet Is PictureBox Then

                                            'Je donne le control à ma variable qui sera une picturebox, ainsi j'ai accès à toutes les options d'une picturebox.
                                            Dim Objet_PictureBox As PictureBox = Objet 'Point d'Interrogation.png

                                            'Puis je charge l'image indiquant un point d'interrogation, indiquant à l'utilisateur que le bot n'a aucun item dans la zone.
                                            Objet_PictureBox.Load(Application.StartupPath & "\Image/Point d'Interrogation.png")

                                        End If

                                    Next

                                Next

                                   ' V_User.PictureBox_Craft_Combiner.Load(Application.StartupPath & "\Image/Point d'Interrogation.png")

                            Case "e" 'Ee

                                'Etable

                                Select Case Mid(e.Message, 3, 1)

                                    Case "+" 'Ee+

                                           ' Dragodinde_Information_All(V_Index, e.Message.Replace("Ee+", ""), V_User.DataGridView_Dragodinde_Etable)

                                    Case "-" 'Ee-

                                           ' Dragodinde_Information_Retire_Etable_Enclo(V_Index, Mid(e.Message, 4), V_User.DataGridView_Dragodinde_Etable)

                                    Case "~" 'Ee~

                                          '  Dragodinde_Information_All(V_Index, e.Message.Replace("Ee~", ""), V_User.DataGridView_Dragodinde_Etable)

                                    Case "E" 'EeE

                                        EcritureMessage(V_Index, "[Dragodinde]", "Impossible de déposer la monture en etable", Color.Red)

                                    Case Else

                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                End Select

                            Case "f"
                                'Enclo
                                Select Case Mid(e.Message, 3, 1)
                                    Case "+"
                                            'Dragodinde_Information_All(ID_Tab, e.Message, "Enclo")
                                    Case "-"
                                        ' Dragodinde_Retire(Mon_ID, Mid(e.Message, 4))
                                    Case Else
                                        Information_Inconnu(V_Index, "Unknow", e.Message)
                                End Select
                            Case "H"
                                Select Case Mid(e.Message, 3, 1)
                                    Case "l" 'EHlID_Objet|ID_Unique;Caractéristique;Prix*1;Prix*10;Prix*100|Next Item
                                          '  HDV_Information_Item_Achat(ID_Tab, Split(Mid(e.Message, 4), "|"))
                                    Case "L" 'EHL26|ID_Objet;ID_Objet;ID_Objet;ID_Objet; etc... 
                                           ' HDV_Information_Catégorie(ID_Tab, Split(Split(e.Message, "|")(1), ";"))
                                    Case "P" 'EHPID_Objet|Prix Moyen 

                                        Dim Separation() As String = Split(e.Message, "|")

                                            '  EcritureMessage(V_Index, "[Hôtel de vente]", "Item actuellement sélectionné : " & Liste_Des_Objets(Mid(Separation(0), 4)).GetValue(1), Color.Green)
                                          '  EcritureMessage(V_Index, "[Hôtel de vente]", "Prix moyen constaté dans cet hôtel : " & Separation(1) & " kamas/u.", Color.Green)
                                            ' HDV_Prix_Moyen = Separation(1)

                                            'Bloque_Thread.Set()

                                    Case "m"
                                        Select Case Mid(e.Message, 4, 1)
                                            Case "+" 'EHm+207814|304||25|497|1400
                                                 '   Ajoute_Item(ID_Tab, Split(e.Message, "|"), "[HDV - Achat]")
                                            Case "-" 'EHm-207814
                                                ' Item_Supprime(ID_Tab, Mid(e.Message, 5))
                                            Case Else
                                                Information_Inconnu(V_Index, "Unknow", e.Message)
                                        End Select
                                    Case "M" 'EHM-2588

                                    Case "S"
                                        Select Case Mid(e.Message, 4, 1)
                                            Case "E" 'EHSE
                                                'TabUtilisateur.ListView_Hotel_De_Vente.Items.Clear()
                                                'Bloque_Thread.Set()
                                                EcritureMessage(V_Index, "[Hotel de vente]", "L'objet recherché n'est pas en vente dans cet hôtel des ventes.", Color.Red)
                                            Case "K" 'EHSK  y'a l'objet voulu
                                            Case Else
                                                Information_Inconnu(V_Index, "Unknow", e.Message)
                                        End Select
                                    Case Else
                                        Information_Inconnu(V_Index, "Unknow", e.Message)
                                End Select

                            Case "K" 'EK

                                Select Case Mid(e.Message, 3, 1)

                                    Case 0 'EK0

                                           ' Craft_Information_Active_Désactive_Button_Combiner(V_Index, e.Message)

                                    Case 1 'EK1

                                        'Craft_Information_Active_Désactive_Button_Combiner(V_Index, e.Message)

                                    Case Else

                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                End Select

                            Case "k"
                                Select Case Mid(e.Message, 3, 1)
                                    Case "0" 'Ek0;1;2619891;aaKbbrcdIde2
                                        Dim Separation() As String = Split(e.Message, ";")
                                        Select Case Mid(e.Message, 4, 1)
                                            Case ";" 'Ek0;1;2619891;aaKbbrcdIde2
                                                Socket.Envoyer("Ek" & CInt(Separation(2)) * 2)
                                            Case "1" 'Ek0188;Riot-ama
                                                Socket.Envoyer("Ek" & V_ID_Unique)
                                        End Select
                                    Case "|"
                                        Select Case Mid(e.Message, 4, 1)
                                            Case "+" 'Ek|+132;1;0;2806232;Riot-Imi;9;91^100;1;0,0,0,2806279;-1;-1;-1;551,3d0,3b9,,;0;;;;;0;;
                                            Case "-" 'Ek|-2806232
                                            Case Else
                                                Information_Inconnu(V_Index, "Unknow", e.Message)
                                        End Select
                                    Case "R" 'EkR2806226
                                    Case "6" 'Ek649|3|20 Bp 
                                        Socket.Envoyer("Ek" & V_ID_Unique)
                                    Case Else

                                        Information_Inconnu(V_Index, "Unknow", e.Message)
                                End Select
                            Case "L"

                                    '   Item_Ajoute_DatagridView(V_Index, e.Message.Replace("EL", "").Replace("O", ""), If(En_Banque = 1, Tab_Personnage.DataGridView_Banque_Coffre, "AUTRE"), "Banque")

                    '  If En_Banque = 1 Then
                    ' Bloque_Thread.Set()
                'End If

                            Case "M"
                                Select Case Mid(e.Message, 3, 1)
                                    Case "K"
                                        Select Case Mid(e.Message, 4, 1)
                                            Case "O"
                                                Select Case Mid(e.Message, 5, 1)
                                                    Case "+" 'EMKO+ID_Unique|Quantité
                                                            'If En_Echange = 1 Then
                                                            'Echange_Information_Dépose_Moi(V_Index, e.Message)
                                                            'End If

                                                    Case "-" 'EMKO-ID_Unique
                                                        '  If En_Echange = 1 Then
                                                        '  Echange_Information_Retire_Moi(V_Index, e.Message)
                                                        ' End If

                                                    Case Else
                                                        Information_Inconnu(V_Index, "Unknow", e.Message)
                                                End Select
                                            Case "G" 'EMKG80000 
                                                ' Echange_Kamas_Moi_Lui(0) = Mid(e.Message, 5)
                                            Case Else
                                                Information_Inconnu(V_Index, "Unknow", e.Message)
                                        End Select
                                    Case Else
                                        Information_Inconnu(V_Index, "Unknow", e.Message)
                                End Select
                            Case "m"
                                Select Case Mid(e.Message, 3, 1)
                                    Case "K"
                                        Select Case Mid(e.Message, 4, 1)
                                            Case "O"
                                                'tout se que l'AUTRE pose.
                                                Select Case Mid(e.Message, 5, 1)
                                                    Case "+"  'EmKO+ID_Unique|Quantité|ID_Objet|Caractéristique 
                                                            ' If En_Echange = 1 Then
                    'Echange_Information_Dépose_Lui(V_Index, e.Message)
                'End If
                                                    Case "-" 'EmKO-ID_Unique
                                                        'If En_Echange = 1 Then
                                                        'Echange_Information_Retire_Lui(V_Index, e.Message)
                                                        'End If
                                                    Case Else
                                                        Information_Inconnu(V_Index, "Unknow", e.Message)
                                                End Select
                                            Case "G" 'EmKG80000
                                                   ' Echange_Kamas_Moi_Lui(1) = Mid(e.Message, 5)

                                            Case "+" 'EmK+ID_Unique|Quantité|ID_Objet|Caractéristiques|Prix|Heure

                                                    ' Ajoute_Item(ID_Tab, Split(e.Message, "|"), "[Hotel de Vente] - [Vente]")
                                                   ' If Bloque_HDV = 1 Then HDV_Nbr_Item_Max = HDV_Nbr_Item_Max - 1

                                            Case "-" 'EmK-425398400
                                                ' Item_Supprime(ID_Tab, Mid(e.Message, 5))
                                            Case Else
                                                Information_Inconnu(V_Index, "Unknow", e.Message)
                                        End Select
                                    Case Else
                                        Information_Inconnu(V_Index, "Unknow", e.Message)
                                End Select

                            Case "p" 'Ep

                                Select Case Mid(e.Message, 3, 1)

                                    Case 1 'Ep1

                                        Select Case Mid(e.Message, 4, 1)

                                            Case "K" 'Ep1K

                                                Select Case Mid(e.Message, 5, 1)

                                                    Case "G" 'Ep1KG

                                                           ' Craft_Information_Argent_Mis_Dans_Le_Paiement(V_Index, e.Message)

                                                    Case "O" 'Ep1KO

                                                        '  Craft_Information_Item_Déposer_Retire_Dans_Paiement(V_Index, e.Message)

                                                    Case Else

                                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                                End Select

                                            Case Else

                                                Information_Inconnu(V_Index, "Unknow", e.Message)

                                        End Select

                                    Case 2 'Ep2

                                        Select Case Mid(e.Message, 4, 1)

                                            Case "K" 'Ep2K

                                                Select Case Mid(e.Message, 5, 1)

                                                    Case "G" 'Ep2KG

                                                            'Craft_Information_Argent_Mis_Dans_Le_Paiement(V_Index, e.Message)

                                                    Case "O" 'Ep2KO

                                                        ' Craft_Information_Item_Déposer_Retire_Dans_Paiement(V_Index, e.Message)

                                                    Case Else

                                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                                End Select

                                            Case Else

                                                Information_Inconnu(V_Index, "Unknow", e.Message)

                                        End Select

                                    Case Else

                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                End Select

                            Case "R"
                                Select Case Mid(e.Message, 3, 1)
                                    Case "E"
                                        EcritureMessage(V_Index, "[Echange]", "Impossible d'échanger avec ce joueur.", Color.Red)
                                            '  Bloque_Echange = 0
                                          '  Bloque_Thread_Echange.Set()
                                    Case "K" 'ERK123467|7654321|1
                                        '  Echange_Reçoit_Demande(V_Index, e.Message)
                                    Case Else
                                        Information_Inconnu(V_Index, "Unknow", e.Message)
                                End Select

                            Case "r" 'Er

                                Select Case Mid(e.Message, 3, 1)

                                    Case "K" 'ErK

                                        Select Case Mid(e.Message, 4, 1)

                                            Case "O" 'ErKO

                                                'Craft_Information_Item_Crafté_Via_Invitation(V_Index, e.Message)


                                        End Select

                                End Select

                            Case "S"
                                Select Case Mid(e.Message, 3, 1)
                                    Case "K"
                                        ' If Bloque_PNJ_Acheter_Vendre = 1 Then
                                        'Bloque_Thread.Set()
                                        EcritureMessage(V_Index, "[PNJ - Vente]", "Vente effectuée", Color.Green)
                                        '  End If
                                    Case Else
                                        Information_Inconnu(V_Index, "Unknow", e.Message)
                                End Select
                            Case "s"
                                Select Case Mid(e.Message, 3, 1)
                                    Case "K"
                                        Select Case Mid(e.Message, 4, 1)
                                            Case "O"
                                                Select Case Mid(e.Message, 5, 1)
                                                    Case "+" 'EsKO+ID_Unique|Quantité|ID_Objet|Caractéristique.
                                                        If _En_Banque_Coffre Then
                                                            Item_Ajoute_Banque_Coffre(V_Index, e.Message, V_User.DatagridView_Banque)
                                                        End If
                                                    Case "-" 'EsKO-ID_Unique 
                                                        If _En_Banque_Coffre Then
                                                            Item_Retire_Banque_Coffre(V_Index, e.Message, V_User.DatagridView_Banque)
                                                        End If
                                                    Case Else
                                                        Information_Inconnu(V_Index, "Unknow", e.Message)
                                                End Select

                                                    ' If En_Banque = 1 Then
                    ' Bloque_Thread.Set()
                '

                                            Case "G"
                                                EcritureMessage(V_Index, "[Banque]", "Kamas en banque : " & Mid(e.Message, 5), Color.Green)
                                                ' Bloque_Thread.Set()
                                            Case Else
                                                Information_Inconnu(V_Index, "Unknow", e.Message)
                                        End Select
                                    Case Else
                                        Information_Inconnu(V_Index, "Unknow", e.Message)
                                End Select
                            Case "V" 'VE ou EVa

                                'Craft
                                _En_Craft = False
                                _En_Atelier = False
                                _Craft_Combiner_Moi = False
                                _Craft_Combiner_Lui = False

                                With V_User

                                    '.DataGridView_Craft_Recette.Rows.Clear()
                                    '.DataGridView_Craft_Paiement.Rows.Clear()
                                    '.DataGridView_Craft_Prime_Si_Réussite.Rows.Clear()
                                    '.RedemptionTextBox_Craft_Paiement.Text = "0"
                                    '.RedemptionTextBox_Craft_Paiement_Si_Réussite.Text = "0"
                                    '.RedemptionTextBox_Craft_Quantité.Text = "0"

                                End With

                                If e.Message.Length = 3 Then

                                    EcritureMessage(V_Index, "[Echange]", "Echange effectué", Color.Blue)
                                    'Bloque_Echange = 0
                                    'En_Echange = 0
                                    'Echange_Moi_Lui_Accepte(0) = 0
                                    'Echange_Moi_Lui_Accepte(1) = 0
                                    'Bloque_Thread_Echange.Set()

                                Else

                                    'If Bloque_Echange = 1 OrElse En_Echange = 1 Then
                                    'Echange_Refuse_Echange(V_Index, e.Message)
                                    'End If

                                    'Bloque_Banque = 0
                                    'En_Banque = 0

                                    'Bloque_Thread.Set()

                                End If
                            Case "v"
                                Select Case Mid(e.Message, 3, 1)
                                    Case "|"
                                        Select Case Mid(e.Message, 4, 1)
                                            Case "+" 'Ev|+132;1;0;2806232;Riot-Imi;9;91^100;1;0,0,0,2806279;-1;-1;-1;551,3d0,3b9,,;0;;;;;0;;
                                            Case "-" 'Ev|-2806232
                                            Case Else
                                                Information_Inconnu(V_Index, "Unknow", e.Message)
                                        End Select
                                    Case ";" 'Ev;1;-2;aeJfeu 
                                        Socket.Envoyer("Ev" & V_ID_Unique)
                                    Case "0"
                                        Socket.Envoyer("Ev" & (V_ID_Unique + 1))
                                    Case Else
                                        Information_Inconnu(V_Index, "Unknow", e.Message)
                                End Select
                            Case "W"
                                Select Case Mid(e.Message, 3, 1)
                                    Case "+"
                                        'EW+1234567|
                                        'Reçoit toujours après le gdk qui lui vient après le gdm
                                        'Inconnu
                                    Case Else
                                        Information_Inconnu(V_Index, "Unknow", e.Message)
                                End Select
                            Case Else
                                Information_Inconnu(V_Index, "Unknow", e.Message)
                        End Select

                    Case "e"

                        Select Case Mid(e.Message, 2, 1)

                            Case "U" 'eU

                                Select Case Mid(e.Message, 3, 1)

                                    Case "K" 'eUK

                                        S_Emoticône(V_Index, e.Message)

                                    Case "E" 'eUE

                                        EcritureMessage(V_Index, "[Dofus]", "Votre personnage ne connaît pas cette attitude !", Color.Red)

                                    Case Else

                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                End Select

                            Case "L" 'eL

                                Emoticône_Actuel(V_Index, e.Message)

                            Case "A" 'eA

                                Emoticône_Obtenue(V_Index, e.Message)

                            Case Else

                                Information_Inconnu(V_Index, "Unknow", e.Message)

                        End Select

                    Case "F"
                    Case "f"

                    Case "G"

                        Select Case Mid(e.Message, 2, 1)

                            Case "A" ' GA

                                Select Case Mid(e.Message, 3, 1)

                                    Case "0" ' GA0

                                        S_Map_Information_Déplacement_Entité(V_Index, e.Message)

                                    Case "1" ' GA1

                                        Select Case Mid(e.Message, 4, 1)

                                            Case ";" ' GA1;

                                                Select Case Mid(e.Message, 5, 1)

                                                    Case "4" ' GA1;4

                                                        S_Map_Information_Déplacement_Joueur_Escalié(V_Index, e.Message)

                                                End Select

                                            Case Else

                                        End Select


                                End Select

                            Case "C" ' GC

                                Select Case Mid(e.Message, 3, 1)

                                    Case "K" ' GCK

                                        Select Case Mid(e.Message, 4, 1)

                                            Case "|" ' GCK|

                                                Select Case Mid(e.Message, 5, 1)

                                                    Case "1" ' GCK|1

                                                        'Inconnu = GCK|1|Linaculer

                                                    Case Else

                                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                                End Select

                                            Case Else

                                                Information_Inconnu(V_Index, "Unknow", e.Message)

                                        End Select

                                    Case Else

                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                End Select

                            Case "c" ' Gc

                                Select Case Mid(e.Message, 3, 1)

                                    Case "+" ' Gc+

                                        S_Combat_Information_Lancé_Map_Ajoute(V_Index, e.Message)

                                    Case "-" ' Gc-

                                        S_Combat_Information_Lancé_Map_Retire(V_Index, e.Message)

                                    Case Else

                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                End Select

                            Case "D" ' GD

                                Select Case Mid(e.Message, 3, 1)

                                    Case "M" ' GDM

                                        S_Map_Information_Affichage(V_Index, e.Message)

                                    Case "O" ' GDO

                                        Select Case Mid(e.Message, 4, 1)

                                            Case "+" ' GDO+

                                                S_Item_Information_Ajoute_Sol(V_Index, e.Message)

                                            Case "-" ' GDO-

                                                S_Item_Information_Retire_Sol(V_Index, e.Message)

                                            Case Else

                                                Information_Inconnu(V_Index, "Unknow", e.Message)

                                        End Select

                                    Case "K" ' GDK

                                        'Inconnu
                                        If e.Message.Length > 3 Then
                                            Information_Inconnu(V_Index, "Unknow", e.Message)
                                        End If

                                    Case Else

                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                End Select

                            Case "M" ' GM

                                Select Case Mid(e.Message, 3, 1)

                                    Case "|" ' GM|

                                        Select Case Mid(e.Message, 4, 1)

                                            Case "+" ' GM|+

                                                S_Map_Information_Ajoute_Entité(V_Index, e.Message)

                                            Case "-" ' GM|-

                                                S_Map_Information_Retire_Entité(V_Index, e.Message)

                                            Case "~" ' GM|~

                                                S_Map_Information_Modifie_Entité_Dragodinde(V_Index, e.Message)

                                            Case Else

                                                Information_Inconnu(V_Index, "Unknow", e.Message)

                                        End Select

                                    Case Else

                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                End Select


                            Case Else

                                Information_Inconnu(V_Index, "Unknow", e.Message)

                        End Select

                    Case "g"

                    Case "H"

                        Select Case Mid(e.Message, 2, 1)

                            Case "C" 'HC
                                'HC trkzqijwpzvunfezdxdhhlmmgxxgsbqm 
                                '   Clef Crypt Mdp  

                                _En_Connexion = True
                                EcritureMessage(V_Index, "(Info)", "Connecté au serveur d'authentification.", Color.Green)

                                'J'indique la version actuel du jeu dofus.
                                Socket_Authentification.Envoyer(Dico_Serveur("Authentification").GetValue(3))
                                Socket_Authentification.Envoyer(_Nom_De_Compte & Chr(10) & PassEnc(_Mot_De_Passe, Mid(e.Message, 3)))
                                Socket_Authentification.Envoyer("Af")

                            Case "G" 'HG

                                EcritureMessage(V_Index, "(Dofus)", "Connecté au serveur de jeu, envoie du ticket.", Color.Green)
                                Socket.Envoyer("AT" & _Ticket)

                            Case Else

                                Information_Inconnu(V_Index, "Unknow", e.Message)

                        End Select

                    Case "h"

                    Case "I"

                        Select Case Mid(e.Message, 2, 1)

                            Case "m" 'Im

                                Dofus_Information_InGame(V_Index, e.Message)

                            Case "L"

                                Select Case Mid(e.Message, 3, 1)

                                    Case "S" ' ILS



                                    Case Else

                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                End Select


                            Case Else

                                Information_Inconnu(V_Index, "Unknow", e.Message)

                        End Select

                    Case "i"


                    Case "J"

                        Select Case Mid(e.Message, 2, 1)
                            Case "N" ' JN

                                Métiers_Information_Up(V_Index, e.Message)

                        End Select

                    Case "j"

                    Case "K"
                    Case "k"

                    Case "L"
                    Case "l"

                    Case "M"
                    Case "m"

                    Case "N"
                    Case "n"

                    Case "O"

                        Select Case Mid(e.Message, 2, 1)

                            Case "a" ' Oa

                                S_Map_Information_Sprite_Item_Joueur(V_Index, e.Message)

                            Case "C" ' OC

                                Select Case Mid(e.Message, 3, 1)

                                    Case "O" ' OCO

                                        S_Item_Information_Modifie_Caractéristique(V_Index, e.Message)

                                    Case Else

                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                End Select

                            Case "M" ' OM

                                S_Equipement_Information_Equipé_Déséquipé(V_Index, e.Message)

                            Case "Q" ' OQ

                                S_Item_Information_Modifie_Quantité(V_Index, e.Message)

                            Case "R" ' OR

                                S_Item_Information_Supprimé(V_Index, e.Message)

                            Case "S" ' OS

                                Select Case Mid(e.Message, 3, 1)

                                    Case "+" ' OS+

                                        S_Equipement_Information_Bonus_Ajoute(V_Index, e.Message)

                                    Case "-" ' OS-

                                        S_Equipement_Information_Bonus_Retire(V_Index, e.Message)

                                    Case Else

                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                End Select

                            Case "T" ' OT

                                Select Case Mid(e.Message, 3, 1)

                                    Case 28 ' OT28

                                        ' Inconnu

                                    Case Else

                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                End Select

                            Case "w" ' Ow

                                S_Pods_Information(V_Index, e.Message)

                            Case Else

                                Information_Inconnu(V_Index, "Unknow", e.Message)

                        End Select

                    Case "o"

                    Case "P"
                    Case "p"

                    Case "Q"
                    Case "q"

                    Case "R"
                    Case "r"

                    Case "S"

                        Select Case Mid(e.Message, 2, 1)

                            Case "L" 'SL

                                Select Case Mid(e.Message, 2, 1)

                                    Case "o" 'SLo

                                    Case > 0 'SL4etc....



                                        Sort_Information_Sorts_Actuel(V_Index, e.Message)

                                    Case Else

                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                End Select

                            Case "U" 'SU

                                Select Case Mid(e.Message, 3, 1)

                                    Case "K" 'SUK

                                        Sort_Information_Sort_Up(V_Index, e.Message)

                                    Case Else

                                        Information_Inconnu(V_Index, "Unknow", e.Message)

                                End Select

                            Case Else

                                Information_Inconnu(V_Index, "Unknow", e.Message)

                        End Select

                    Case "s"

                    Case "T"
                    Case "t"

                    Case "U"
                    Case "u"

                    Case "V"
                    Case "v"

                    Case "W"
                    Case "w"

                    Case "X"
                    Case "x"

                    Case "Y"
                    Case "y"

                    Case "Z"
                    Case "z"
                End Select

            End If

            ' Catch ex As Exception

            ' Erreur_Fichier(V_Index, "E_Reception", e.Message & vbCrLf & ex.Message)

            ' End Try

        End If

    End Sub

#End Region



End Class
