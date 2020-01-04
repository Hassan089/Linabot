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

    Public Sub Smiley(ByVal Index As Integer, ByVal Information As String)

        With Comptes(Index)._User

            'cS 01234567  | 1
            'cS ID Joueur | Numéro smiley

            'Je sépare les informations
            Dim Separation() As String = Split(Information, "|")

            'Je donne à la première séparation, l'ID du joueur, je prend donc tout se qui se trouve après le "cS"
            Separation(0) = Mid(Separation(0), 3, Separation(0).Length)

            'J'indique que le tchat n'est plus en lecture seul.
            .RichTextBox_Tchat.ReadOnly = False

            'Je récupère se qui se trouve dans le presse papier avant de changer les infos.
            Dim _Audio, _FileDrop, _Image, _Text As New Object

            'Je copie se qui se trouve dans le presse papier, dans mes variables.
            If Clipboard.ContainsAudio Then _Audio = Clipboard.GetAudioStream
            If Clipboard.ContainsFileDropList Then _FileDrop = Clipboard.GetFileDropList
            If Clipboard.ContainsImage Then _Image = Clipboard.GetImage
            If Clipboard.ContainsText Then _Text = Clipboard.GetText

            'Je cherche l'image associé au numéro.
            Dim Picture_Box() As PictureBox = { .PictureBox_Smiley_1, .PictureBox_Smiley_2, .PictureBox_Smiley_3,
                                                .PictureBox_Smiley_4, .PictureBox_Smiley_5, .PictureBox_Smiley_6,
                                                .PictureBox_Smiley_7, .PictureBox_Smiley_8, .PictureBox_Smiley_9,
                                                .PictureBox_Smiley_10, .PictureBox_Smiley_11, .PictureBox_Smiley_12,
                                                .PictureBox_Smiley_13, .PictureBox_Smiley_14, .PictureBox_Smiley_15}

            Dim img As Image = Picture_Box(Separation(1)).Image

            'Je copie l'image dans le presse papier.
            Clipboard.SetImage(img)

            'Je cherche juste avant le nom du personnage via son ID
            For Each Pair As DataGridViewRow In .DataGridView_Map.Rows

                If Pair.Cells(2).Value = Separation(0) Then

                    'Je change la couleur
                    .RichTextBox_Tchat.SelectionColor = Color.White

                    'Je mets les infos de base (nom, id etc....)
                    .RichTextBox_Tchat.AppendText("[" & TimeOfDay & "] [" & Separation(0) & "] " & Pair.Cells(3).Value & " : ")

                    'Je colle l'image dans la richtextbox
                    .RichTextBox_Tchat.Paste()

                    'Je saute une ligne.
                    .RichTextBox_Tchat.AppendText(vbCrLf)

                    'Je baisse le scroll au max.
                    .RichTextBox_Tchat.ScrollToCaret()

                    Exit For

                End If

            Next

            'Je redonne ensuite dans le presse papier les infos que l'utilisateur avait.
            If _Audio <> Nothing Then Clipboard.SetAudio(_Audio)
            If _FileDrop <> Nothing Then Clipboard.SetFileDropList(_FileDrop)
            If _Image <> Nothing Then Clipboard.SetImage(_Image)
            If _Text <> Nothing Then Clipboard.SetText(_Text)

            'Je passe la richtextbox en lecture uniquement.
            .RichTextBox_Tchat.ReadOnly = True

        End With

    End Sub

    Public Sub Emoticône(ByVal Index As Integer, ByVal Information As String)

        With Comptes(Index)._User

            'eUK 01234567  | 8
            'eUK ID Joueur | Numéro Emoticône

            'Je sépare les informations
            Dim Separation() As String = Split(Information, "|")

            'Je donne à la première séparation, l'ID du joueur, je prend donc tout se qui se trouve après le "eUK"
            Separation(0) = Mid(Separation(0), 4, Separation(0).Length)

            'J'indique que le tchat n'est plus en lecture seul.
            .RichTextBox_Tchat.ReadOnly = False

            'Je récupère se qui se trouve dans le presse papier avant de changer les infos.
            Dim _Audio, _FileDrop, _Image, _Text As New Object

            'Je copie se qui se trouve dans le presse papier, dans mes variables.
            If Clipboard.ContainsAudio Then _Audio = Clipboard.GetAudioStream
            If Clipboard.ContainsFileDropList Then _FileDrop = Clipboard.GetFileDropList
            If Clipboard.ContainsImage Then _Image = Clipboard.GetImage
            If Clipboard.ContainsText Then _Text = Clipboard.GetText

            'Je cherche l'image associé au numéro.
            Dim Picture_Box() As PictureBox = { .PictureBox_Emoticône_1, .PictureBox_Emoticône_2, .PictureBox_Emoticône_3,
                                                .PictureBox_Emoticône_4, .PictureBox_Emoticône_5, .PictureBox_Emoticône_6,
                                                .PictureBox_Emoticône_7, .PictureBox_Emoticône_8, .PictureBox_Emoticône_9,
                                                .PictureBox_Emoticône_10, .PictureBox_Emoticône_11, .PictureBox_Emoticône_12,
                                                .PictureBox_Emoticône_13, .PictureBox_Emoticône_14, .PictureBox_Emoticône_15,
                                                .PictureBox_Emoticône_19, .PictureBox_Emoticône_21}

            Dim img As Image = Picture_Box(Separation(1)).Image

            'Je copie l'image dans le presse papier.
            Clipboard.SetImage(img)

            'Je cherche juste avant le nom du personnage via son ID
            For Each Pair As DataGridViewRow In .DataGridView_Map.Rows

                If Pair.Cells(2).Value = Separation(0) Then

                    'Je mets les infos de base (nom, id etc....)
                    .RichTextBox_Tchat.AppendText("[" & TimeOfDay & "] [" & Separation(0) & "] " & Pair.Cells(3).Value & " : ")

                    'Je colle l'image dans la richtextbox
                    .RichTextBox_Tchat.Paste()

                    'Je saute une ligne.
                    .RichTextBox_Tchat.AppendText(vbCrLf)

                    'Je baisse le scroll au max.
                    .RichTextBox_Tchat.ScrollToCaret()

                    Exit For

                End If

            Next

            'Je redonne ensuite dans le presse papier les infos que l'utilisateur avait.
            If _Audio <> Nothing Then Clipboard.SetAudio(_Audio)
            If _FileDrop <> Nothing Then Clipboard.SetFileDropList(_FileDrop)
            If _Image <> Nothing Then Clipboard.SetImage(_Image)
            If _Text <> Nothing Then Clipboard.SetText(_Text)

            'Je passe la richtextbox en lecture uniquement.
            .RichTextBox_Tchat.ReadOnly = True

        End With

    End Sub

    Public Sub Emoticône_Actuel(ByVal Index As Integer, ByVal Information As String)

        With Comptes(Index)._User

            'eL 1664                                                           | 0 
            'eL Chiffre indiquant toutes les emoticône actuellement disponible | ?

            'Je prend uniquement se qui se trouve après le "eL"
            Information = Mid(Information, 3)

            'Puis je sépare les informations via "|"
            Dim Separation() As String = Split(Information, "|")

            'Je fais ensuite les soustraction nécessaire pour obtenir les méoticône actuelleent disponible pour le personnage.
            While CInt(Separation(0)) > 0

                Select Case CInt(Separation(0))

                    Case >= 1078576 'Attitude du champion

                        'Je retire 1078576 à separation(0)
                        Separation(0) = CInt(Separation(0)) - 1078576
                        .PictureBox_Emoticône_21.Visible = True

                    Case >= 524288

                        'Je retire 524288 à separation(0)
                        Separation(0) = CInt(Separation(0)) - 524288
                        MsgBox("Merci de contacter 'Linaculer' en lui indiqué l'émote qui n'est pas pris en charge par le bot : " & 524288)
                        ' .PictureBox_Emoticône_19.Visible = True

                    Case >= 262144 'S'allonger

                        'Je retire 262144 à separation(0)
                        Separation(0) = CInt(Separation(0)) - 262144
                        .PictureBox_Emoticône_19.Visible = True

                    Case >= 131072

                        'Je retire 131072 à separation(0)
                        Separation(0) = CInt(Separation(0)) - 131072
                        MsgBox("Merci de contacter 'Linaculer' en lui indiqué l'émote qui n'est pas pris en charge par le bot : " & 131072)
                       ' .PictureBox_Emoticône_19.Visible = True

                    Case >= 65536

                        'Je retire 65536 à separation(0)
                        Separation(0) = CInt(Separation(0)) - 65536
                        MsgBox("Merci de contacter 'Linaculer' en lui indiqué l'émote qui n'est pas pris en charge par le bot : " & 65536)
                        ' .PictureBox_Emoticône_19.Visible = True

                    Case >= 32768

                        'Je retire 32768 à separation(0)
                        Separation(0) = CInt(Separation(0)) - 32768
                        MsgBox("Merci de contacter 'Linaculer' en lui indiqué l'émote qui n'est pas pris en charge par le bot : " & 32768)
                       ' .PictureBox_Emoticône_19.Visible = True

                    Case >= 16384 'Montrer du doigt 

                        'Je retire 16384 à separation(0)
                        Separation(0) = CInt(Separation(0)) - 16384
                        .PictureBox_Emoticône_15.Visible = True

                    Case >= 8192 'Croiser les bras 

                        'Je retire 8192 à separation(0)
                        Separation(0) = CInt(Separation(0)) - 8192
                        .PictureBox_Emoticône_14.Visible = True

                    Case >= 4096 'Ciseaux

                        'Je retire 4096 à separation(0)
                        Separation(0) = CInt(Separation(0)) - 4096
                        .PictureBox_Emoticône_13.Visible = True

                    Case >= 2048 'Feuille

                        'Je retire 2048 à separation(0)
                        Separation(0) = CInt(Separation(0)) - 2048
                        .PictureBox_Emoticône_12.Visible = True

                    Case >= 1024 'Pierre

                        'Je retire 1024 à separation(0)
                        Separation(0) = CInt(Separation(0)) - 1024
                        .PictureBox_Emoticône_11.Visible = True

                    Case >= 512 'Envoyer un baiser 

                        'Je retire 512 à separation(0)
                        Separation(0) = CInt(Separation(0)) - 512
                        .PictureBox_Emoticône_10.Visible = True

                    Case >= 256 'Saluer

                        'Je retire 256 à separation(0)
                        Separation(0) = CInt(Separation(0)) - 256
                        .PictureBox_Emoticône_9.Visible = True

                    Case >= 128 'Vent de panique

                        'Je retire 128 à separation(0)
                        Separation(0) = CInt(Separation(0)) - 128
                        .PictureBox_Emoticône_8.Visible = True

                    Case >= 64 'Jouer de la flûte

                        'Je retire 64 à separation(0)
                        Separation(0) = CInt(Separation(0)) - 64
                        .PictureBox_Emoticône_7.Visible = True

                    Case >= 32 'Montrer son arme

                        'Je retire 32 à separation(0)
                        Separation(0) = CInt(Separation(0)) - 32
                        .PictureBox_Emoticône_6.Visible = True

                    Case >= 16 'Montrer sa peur 

                        'Je retire 16 à separation(0)
                        Separation(0) = CInt(Separation(0)) - 16
                        .PictureBox_Emoticône_5.Visible = True

                    Case >= 8 'Colère

                        'Je retire 8 à separation(0)
                        Separation(0) = CInt(Separation(0)) - 8
                        .PictureBox_Emoticône_4.Visible = True

                    Case >= 4 'Applaudir 

                        'Je retire 4 à separation(0)
                        Separation(0) = CInt(Separation(0)) - 4
                        .PictureBox_Emoticône_3.Visible = True

                    Case >= 2 'Faire un signe de la main

                        'Je retire 2 à separation(0)
                        Separation(0) = CInt(Separation(0)) - 2
                        .PictureBox_Emoticône_2.Visible = True

                    Case >= 1 'Sasseoir (Inutile, car activé par défaut)


                End Select

            End While

        End With

    End Sub

    Public Sub Emoticône_Obtenue(ByVal Index As Integer, ByVal Information As String)

        With Comptes(Index)._User

            'eA 13
            'eA Numéro de l'émoticône

            Dim Picture_Box() As PictureBox = { .PictureBox_Emoticône_1, .PictureBox_Emoticône_2, .PictureBox_Emoticône_3,
                                                .PictureBox_Emoticône_4, .PictureBox_Emoticône_5, .PictureBox_Emoticône_6,
                                                .PictureBox_Emoticône_7, .PictureBox_Emoticône_8, .PictureBox_Emoticône_9,
                                                .PictureBox_Emoticône_10, .PictureBox_Emoticône_11, .PictureBox_Emoticône_12,
                                                .PictureBox_Emoticône_13, .PictureBox_Emoticône_14, .PictureBox_Emoticône_15,
                                                .PictureBox_Emoticône_19, .PictureBox_Emoticône_21}

            'Je rend la picturebox de base visible.
            Picture_Box(Mid(Information, 3)).Visible = True

            EcritureMessage(Index, "[Dofus - Emoticône] - ", "Fécilitation, vous avez débloqué une nouvelle émote ! " & .ToolTip1.GetToolTip(Picture_Box(Mid(Information, 3))), Color.Green)

            '.ToolTip1.GetToolTip(Name_Control) = Récupère les infos dans l'infobulle du control que je souhaite, ou passe t'a souris sur "GetToolTip" pour avoir des infos ^^

        End With

    End Sub

    'A REFAIRE
    Public Sub Dofus_Information_InGame(ByVal Index As Integer, ByVal Information As String)
        With Comptes(Index)
            Try
                'Im1165
                Dim Separation() As String

                Select Case Mid(Information, 3, 4)
                    Case "1202" 'Im1201;[Seydlex] 
                        Separation = Split(Information, ";")
                        EcritureMessage(Index, "[Modérateur]", "Vous allez être banni par le modérateur " & Separation(1) & ".", Color.Red)
                       ' Modérateur_Ban(Index)
                    Case "1184"
                        Separation = Split(Information, ";")
                        EcritureMessage(Index, "[Combat]", Separation(1) & " vient de se reconnecter en combat.", Color.Red)
                       ' .En_Combat = 1
                    Case "1183"
                        EcritureMessage(Index, "[Dofus]", "La zone 'Incarnam' fonctionne sur plusieurs instances, pour éviter qu'un trop grand nombre de joueurs soient présent dans cette zone de petite taille. Ceci signifie qu'il existe plusieurs 'Incarnam' en parallèle, afin qu'il n'y ait pas plus d'un certain nombre de joueurs dans la même instance. Vous pouvez donc ne pas être dans le même 'Incarnam' que vos amis, pour les rejoindre, vous pouvez utiliser la liste d'amis, et vous retrouver instantanément à leurs côtés, à conditions qu'ils soient eux aussi dans Incarnam en dehors des grottes et donjons.", Color.Red)
                    Case "1182"
                    Case "1177"
                        EcritureMessage(Index, "[Dofus]", "Vous avez trop d'objets dans votre inventaire, vous ne pouvez pas les voir tous. (1000 objets maximum)", Color.Red)
                    Case "1175"
                        EcritureMessage(Index, "[Combat]", "Impossible de lancer ce sort actuellement.", Color.Red)
                    Case "1174"
                        EcritureMessage(Index, "[Combat]", "Un obstacle géne le passage.", Color.Red)
                    Case "1170" 'Im1170;0~4
                        Separation = Split(Information, ";")
                        Separation = Split(Separation(1), "~")
                        EcritureMessage(Index, "[Combat]", "Vous avez '" & Separation(0) & "' PA, hors il vous en faut minimum '" & Separation(1) & "' PA pour lancer ce sort.", Color.Red)
                    Case "1168"
                        EcritureMessage(Index, "[Dofus]", "Vous ne pouvez pas poser plus de " & Mid(Information, 8) & " percepteur(s) par zone.", Color.Red)
                    Case "1167"
                        EcritureMessage(Index, "[Dofus]", "Vous ne pouvez pas poser de percepteur ici avant " & Mid(Information, 8) & " minutes.", Color.Red)
                    Case "1165"
                        EcritureMessage(Index, "[Dofus]", "La sauvegarde du serveur est terminée. L'accès au serveur est de nouveau possible. Merci de votre compréhension.", Color.Red)
                    Case "1164"
                        EcritureMessage(Index, "[Dofus]", "Une sauvegarde du serveur est en cours... Vous pouvez continuer de jouer, mais l'accès au serveur est temporairement bloqué. La connexion sera de nouveau possible d'ici quelques instants. Merci de votre patience.", Color.Red)
                    Case "1159"
                        EcritureMessage(Index, "[Dofus]", "Vous êtes à court de potion d'enclos de guilde.", Color.Red)
                        'Percepteur
                    Case "1139"
                        EcritureMessage(Index, "[Percepteur]", "Attention, la fenêtre d'échange se fermera automatiquement dans " & Mid(Information, 8, Information.Length) & " minutes.", Color.Red)
                    Case "1120"
                        EcritureMessage(Index, "[Dofus]", "Impossible d'interagir avec votre percepteur sur la carte même où vous vous êtes connecté.", Color.Red)
                        'Dragodinde
                    Case "1117"
                        EcritureMessage(Index, "[Dofus]", "Impossible d'être sur une monture à l'intérieur d'une maison.", Color.Red)
                    Case "1111"
                        EcritureMessage(Index, "[Dragodinde]", "A peine entrée dans l'étable, votre monture s'accroupit et commence à mettre bas. Après quelques instants, vous pouvez constater que tout s'est bien passé. Vous voilà responsable de " & Mid(Information, 8, Information.Length) & " nouvelle(s) monture(s).", Color.Violet)
                    Case "1105"
                        EcritureMessage(Index, "[Dragodinde]", "L'étable est pleine. Vous ne pouvez conserver que 100 montures maximum.", Color.Violet)
                    Case "1104"
                        EcritureMessage(Index, "[Dragodinde]", "Monture désignée invalide, trop de monture dans l'étable", Color.Violet)
                    Case "1102"
                        EcritureMessage(Index, "[Dragodinde]", "Cellule cible invalide", Color.Violet)
                    Case "0194"
                        EcritureMessage(Index, "[Forgemagie]", "La magie n'a pas parfaitement fonctionné, une des caractéristiques de l'objet a baissé en puissance.", Color.Red)
                    Case "0188" '"Im0188;player"
                    Case "0183"
                        EcritureMessage(Index, "[Forgemagie]", "Malgré vos talents, la magie n'opère pas et vous sentez l'échec de la transformation.", Color.Red)
                    Case "0153"
                        EcritureMessage(Index, "[Dofus]", "Votre adresse IP actuelle est : " & Mid(Information, 8) & ".", Color.Green)
                    Case "0152" 'Im0152;2019~06~27~7~19~xx.xxx.xx.xx
                        Separation = Split(Split(Information, ";")(1), "~")
                        EcritureMessage(Index, "[Dofus]", "Précédente connexion sur votre compte effectuée le : " &
                                        Separation(2) & "/" & Separation(1) & "/" & Separation(0) & " à " & Separation(3) & ":" & Separation(4) &
                                        " via l'adresse IP  : " & Separation(5), Color.Green)
                    Case "0143"
                        Separation = Split(Information, """>")
                        Separation = Split(Separation(1), "</")
                        EcritureMessage(Index, "[Dofus]", "Le joueur : " & Separation(0) & " vient de se connecter.", Color.Green)
                    Case "0118"
                        EcritureMessage(Index, "[Craft]", "Vous n'arrivez pas à assembler correctement les ingrédients, et vous n'arrivez pas à concevoir quoi que ce soit d'utilisable cette fois.", Color.Red)
                    Case "0117"
                        EcritureMessage(Index, "[Forgemagie]", "Malgré vos talents, la magie n'opère pas et vous sentez l'échec de la transformation, ainsi que la diminution de la puissance de l'objet..", Color.Red)
                    Case Else

                        Select Case Mid(Information, 3, 3)
                            Case "189"
                                EcritureMessage(Index, "[Dofus]", "Bienvenue sur Dofus, dans le Monde des douze !" & vbCrLf &
                                "Rappel : prenez garde, il est interdit de transmettre votre identifiant de connexion ainsi que votre mot de passe.", Color.Red)
                            Case "172"
                                EcritureMessage(Index, "[Hôtel de Vente]", "Cet objet n'est plus disponible à ce prix. Quelqu'un a été plus rapide...", Color.Red)
                            Case "167"
                                EcritureMessage(Index, "[Hôtel de Vente]", "Vous ne pouvez pas mettre plus d'objets en vente actuellement...", Color.Red)
                            Case "165"
                                EcritureMessage(Index, "[Hôtel de vente]", "Vous ne disposez pas d'assez de kamas pour acquitter la taxe de mise en vente...", Color.Red)
                            Case "128"
                                EcritureMessage(Index, "[Combat]", "En attente du joueur " & Mid(Information, 7, Information.Length) & "...", Color.Red)
                            Case "120"
                                EcritureMessage(Index, "[Maison]", "Cet emplacement de stockage est déjà utilisé.", Color.Red)

                            Case "118" 'Im188

                                EcritureMessage(Index, "[Dofus]", "Votre familier ne peut vous suivre tant que vous êtes sur votre monture...", Color.Red)


                            Case "116" 'Im116;[Seydlex]~Bot Joueur
                                Separation = Split(Information, ";")
                                Separation = Split(Separation(1), "~")
                                EcritureMessage(Index, "[Modérateur]", "Vous avez été banni par " & Separation(0) & ". Motif : " & Separation(2), Color.Red)
                                EcritureMessage(Index, "[Modérateur]", "Il y a de forte chance que se soit un report, de ce fait le bot n'a pas pu détecter le modérateur.", Color.Red)
                               ' Modérateur_Ban(Index)
                            Case "115"
                                EcritureMessage(Index, "(Dofus)", "Pour des raisons de maintenances, le serveur va être redémarré dans " & Split(Information, ";")(1), Color.Red)
                            Case "112"
                                EcritureMessage(Index, "[Dofus]", "Vous êtes trop chargé. Jetez quelques objets afin de pouvoir bouger.", Color.Red)
                            Case "095"
                                ' .Bloque_Cadenas = 1
                                EcritureMessage(Index, "[Combat]", "L'équipe n'accepte plus de personnages supplémentaires.", Color.Red)
                            Case "093"
                                ' .Bloque_Combat_Groupe = 1
                                EcritureMessage(Index, "[Combat]", "Léquipe n'accepte désormais que les membres du groupe du personnage principal.", Color.Red)
                            Case "092"
                                EcritureMessage(Index, "[Dofus]", "Vous avez récupéré " & Mid(Information, 7, Information.Length) & " points d'énergie en vous reposant.", Color.Green)
                            Case "073"
                            Case "068"
                                EcritureMessage(Index, "[Dofus]", "Lot acheté.", Color.Green)
                            Case "065" 'Im065;300~2598~2598~1
                                Separation = Split(Information, ";")
                                Separation = Split(Separation(1), "~")
                                EcritureMessage(Index, "[Dofus]", "Votre compte en banque a été crédité de " & Separation(0) & " kamas suite à la vente de '" & Liste_Des_Objets(Separation(1)).GetValue(1) & "' (x " & Separation(3) & ").", Color.Green)
                            Case "053"
                                EcritureMessage(Index, "[Groupe]", Split(Information, ";")(1) & " ne suit plus votre déplacement.", Color.Green)
                            Case "052" 'Im052;Linaculer
                                EcritureMessage(Index, "[Groupe]", Split(Information, ";")(1) & " suit votre déplacement.", Color.Green)
                            Case "040"
                                ' .Bloque_Spectateur = 1
                                EcritureMessage(Index, "[Combat]", "Le mode 'Spectateur' est désactivé.", Color.Red)
                            Case "037"
                                EcritureMessage(Index, "[Dofus]", "Vous êtes désormais considéré comme absent.", Color.Red) '/away
                            Case "036" 'Im036;Linaculer
                                EcritureMessage(Index, "[Dofus]", Mid(Information, 7, Information.Length) & " vient de rejoindre le combat en spectateur.", Color.Green) '/away
                            Case "034" 'Im034;60 
                                ' .Mort = 1
                                EcritureMessage(Index, "[Familier]", "Tu as perdu " & Split(Information, ";")(1) & " points d'énergie.", Color.Red)
                                'FAMILIER
                            Case "032"
                                EcritureMessage(Index, "[Familier]", "Votre familier apprécie le repas.", Color.Green)
                            Case "031"
                                EcritureMessage(Index, "[Familier]", "Vous donnez à manger à votre familier famélique qui traînait comme un zombi. Il se force à manger mais la nourriture qu'il avale fait 3 fois son estomac et il se tord de douleur. Au moins il a mangé.", Color.Red)
                            Case "029"
                                EcritureMessage(Index, "[Familier]", "Vous donnez à manger à votre familier. Il semble qu'il avait très faim.", Color.Green)
                            Case "027"
                                EcritureMessage(Index, "[Familier]", "Vous donnez à manger à répétition à votre familier déjà obèse. Il avale quand même la ressource et fait une indigestion.", Color.Red)
                            Case "026"
                                EcritureMessage(Index, "[Familier]", "Vous donnez à manger à votre familier alors qu'il n'avait plus faim. Il se force pour vous faire plaisir.", Color.Red)
                            Case "025"
                                EcritureMessage(Index, "[Familier]", "Votre familier vous fait la fête !", Color.Green)
                            Case "153"
                                EcritureMessage(Index, "[Familier]", "Votre familier prend la ressource, la renifle un peu, ne semble pas convaincu et vous la rend.", Color.Red)
                            Case "024"
                                EcritureMessage(Index, "[Dofus]", "Tu viens de mémoriser un nouveau zaap.", Color.Green)
                            Case "022" 'Im022;1~1568
                                Separation = Split(Information, ";")
                                Separation = Split(Separation(1), "~")
                                EcritureMessage(Index, "[Dofus]", "Tu as perdu " & Separation(0) & " '" & Liste_Des_Objets(Separation(1)).GetValue(1) & "'.", Color.Red)
                            Case Else
                                Select Case Mid(Information, 3, 2)
                                    Case "08" 'Im08;17293
                                        EcritureMessage(Index, "[Dofus]", "Tu as gagné " & Mid(Information, 6, Information.Length) & " points d'expérience.", Color.Green)
                                    Case "06"
                                        EcritureMessage(Index, "[Dofus]", "Position sauvegardée.", Color.Green)
                                    Case "01" 'Im01;100
                                        EcritureMessage(Index, "[Dofus]", "Tu as récupéré " & Mid(Information, 6, Information.Length) & " points de vie.", Color.Green)
                                End Select
                        End Select
                End Select
            Catch ex As Exception
                Erreur_Fichier(Index, "Dofus_Information_InGame", Information)
            End Try
        End With

    End Sub


End Module
