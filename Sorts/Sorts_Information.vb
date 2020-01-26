Module Sorts_Information

    Public Sub Sort_Information_Sorts_Actuel(ByVal Index As Integer, ByVal Information As String)

        With Comptes(Index)

            'SL 51      ~ 5      ~ b                               ;
            'SL ID Sort ~ Niveau ~ placement dans la Barre de sort ; Sort suivant

            'Je orend les informations après le "SL"
            Information = Mid(Information, 3)

            'Je sépare ensuite les informations via ce signe ";", permettant d'avoir les sorts.
            Dim Separation() As String = Split(Information, ";")

            'Puis je fait une boucle pour chaque sort.
            For i = 0 To Separation.Count - 2

                'J'obtient les informations de chaque sort, via la séparation avec ce signe "~"
                Dim Separation_Information() As String = Split(Separation(i), "~")

                'Je créer l'interface du sort.
                Dim Sort As New Sorts_Control(Index, Separation_Information(0), Separation_Information(1))

                'Puis je l'ajoute au flowlayoutpanel
                .V_User.FlowLayoutPanel_Sort.Controls.Add(Sort)

            Next

        End With

    End Sub

    Public Sub Sort_Information_Sort_Up(ByVal Index As Integer, ByVal Information As String)

        With Comptes(Index)

            'SUK 142     ~ 4      ~ B
            'SUK ID Sort ~ Niveau ~ Placement dans la barre de sort

            'Je prend les informations que se trouve après le "SUK"
            Information = Mid(Information, 4)

            'Puis je sépare les informations via ce signe "~"
            Dim Separation() As String = Split(Information, "~")

            'D'abord je vérifie que le sort existe dans ma liste
            For Each Le_Control As Control In .V_User.FlowLayoutPanel_Sort.Controls

                'Je vérifie que le control actuel et un User control = Sort_Control
                If TypeOf Le_Control Is Sorts_Control Then

                    'Je donne à ma variable toutes les infos du control actuel.
                    Dim _Sorts_Control As Sorts_Control = DirectCast(Le_Control, Sorts_Control)

                    'Puis je regarde si la picturebox qu'il contient à l'ID du sort. 
                    If _Sorts_Control.PictureBox_Sort.Name = Separation(0) Then

                        'Je fais toutes les modifications nécessaire au sort.

                        With _Sorts_Control

                            'Je change le niveau
                            .Label_Niveau.Text = "Niveau " & Separation(1)

                            'Je change les PAs
                            .Label_PA.Text = Dico_Sorts(Separation(0))(Separation(1)).GetValue(4) & " PA"

                            'Je change les POs
                            .Label_PO.Text = Dico_Sorts(Separation(0))(Separation(1)).GetValue(3) & " PO"

                            'Je regarde si je dois désactivé la checkbox et la rendre invisible si le sort et niveau 6
                            If CInt(Separation(1)) > 5 Then
                                .CheckBox_Automatique.Checked = False
                                .CheckBox_Automatique.Visible = False
                            End If

                            'Je change le coût pour le sort, sauf s'il est level 6 je fais comme pour la checkbox
                            If CInt(Separation(1)) > 5 Then
                                .Label_Coût.Visible = False
                            Else
                                .Label_Coût.Text = "Coût du niveau suivant : " & Separation(1)
                            End If

                            'Idem pour le bouton si level 6 je le désactive
                            If CInt(Separation(1)) > 5 Then
                                .Button_Up.Visible = False
                            End If

                        End With

                    End If

                End If

            Next

            'Sinon je l'ajoute moi même.
            'Pour éviter de refaire des lignes, je fais appel a "Sort_Information_Actuel" et changent juste "SUK" par "SL" et j'ajoute à la fin le ";"
            Sort_Information_Sorts_Actuel(Index, "SL" & Mid(Information, 4) & ";")
        End With

    End Sub

    Public Sub Sorts_Information_Sort_Séléctionné(ByVal Index As Integer, ByVal ID_Sort As Integer, ByVal Niveau As Integer)

        With Comptes(Index).V_User

            'Je vérifie que j'ai l'image dans le dossier, si oui, je la charge dans ma picturebox.
            If IO.File.Exists(Application.StartupPath & "\Image\Sorts/" & ID_Sort & ".png") Then .PictureBox_Sort_Image.Load(Application.StartupPath & "\Image\Sorts/" & ID_Sort & ".png")

            'Je mets le nom du sort dans mon label.
            .Label_Sort_Information_Nom_Du_Sort.Text = Dico_Sorts(ID_Sort)(Niveau).GetValue(2)

            'Je mets l'information du niveau requis
            .Label_Sort_Information_Niveau_Requis.Text = "Niveau requis : " & Dico_Sorts(ID_Sort)(Niveau).GetValue(15)

            'Je mets la PO min et max du sort.
            .Label_Sort_Information_PO.Text = Dico_Sorts(ID_Sort)(Niveau).GetValue(3) & " PO"

            'Je mets les PAs du sort.
            .Label_Sort_Information_PA.Text = Dico_Sorts(ID_Sort)(Niveau).GetValue(4) & " PA"

            'Je mets la définition
            .Label_Sort_Information_Définition.Text = Dico_Sorts(ID_Sort)(Niveau).GetValue(17)

            'A FINIR
            'Je mets la probabilité de coup critique
            .Label_Sort_Information_Probabilité_Coup_Critique.Text = "Probabilité de coup critique : "

            'Je mets la Probabilité d'échec 
            .Label_Sort_Information_Lancer_Par_Tour.Text = "Probabilité d'échec : "
            'A FINIR

            'Je mets le nombre de lancers par tour
            .Label_Sort_Information_Lancer_Par_Tour.Text = "Nombre de lancers par tour " & Dico_Sorts(ID_Sort)(Niveau).GetValue(5)

            'Je mets le nombre de lancers par tour par joueur
            .Label_Sort_Information_Lancer_Par_Tour_Par_Joueur.Text = "Nombre de lancers par tour par joueur " & Dico_Sorts(ID_Sort)(Niveau).GetValue(6)

            'Je mets le Nombre de tours entre deux lancers -
            .Label_Sort_Information_Tour_Entre_Deux_Lancers.Text = "Nombre de tours entre deux lancers " & Dico_Sorts(ID_Sort)(Niveau).GetValue(7)

            'Portée modifiable : Non
            .Label_Sort_Information_Portée_Modifiable.Text = "Portée modifiable : " & Dico_Sorts(ID_Sort)(Niveau).GetValue(8)

            'Ligne de vue : Non
            .Label_Sort_Information_Ligne_De_Vue.Text = "Ligne de vue : " & Dico_Sorts(ID_Sort)(Niveau).GetValue(9)

            'Lancer en ligne : Non
            .Label_Sort_Information_Lancer_En_Ligne.Text = "Lancer en ligne : " & Dico_Sorts(ID_Sort)(Niveau).GetValue(10)

            'Cellules libres : Non
            .Label_Sort_Information_Cellules_Libres.Text = "Cellules libres : " & Dico_Sorts(ID_Sort)(Niveau).GetValue(11)

            'Echec fini le tour : Non
            .Label_Sort_Information_Echec_Fini_Tour.Text = "Echec fini le tour : " & Dico_Sorts(ID_Sort)(Niveau).GetValue(12)

            'Je mets à jor les buttons.
            Dim Button_Niveau() As Button = { .Button_Sort_Information_1, .Button_Sort_Information_2, .Button_Sort_Information_3,
                                              .Button_Sort_Information_4, .Button_Sort_Information_5, .Button_Sort_Information_6}

            For i = 0 To 5
                Button_Niveau(i).BackColor = Color.White
            Next

            Button_Niveau(Niveau - 1).BackColor = Color.Lime

            'A FINIR
            'Je mets les Coups critiques actuels 
            .Label_Sort_Information_Coups_Critiques_Actuels.Text = "Coups critiques actuels : "
            'A FINIR


            'IL MANQUE LES EFFETS 
        End With

    End Sub

End Module
