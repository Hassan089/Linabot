Imports System.IO

Module Equipement

#Region "Action"

    Public Sub S_Equipe_Item(ByVal Index As Integer, ByVal ID_Name_Unique As String, Optional ByVal Caractéristique As String = "")

        With Comptes(Index)

            For Each Pair As DataGridViewRow In Copy_DatagridView(Index, .V_User.DataGridView_Inventaire).Rows

                ' Je vérifie s'il s'agit du bonne ID/ID unique ou du bon nom.
                If Pair.Cells(1).Value.ToString = ID_Name_Unique OrElse Pair.Cells(2).Value = ID_Name_Unique OrElse Pair.Cells(3).Value = ID_Name_Unique Then

                    'Je vérifie ensuite s'il y a des caractéristique spécial à avoir.
                    If Caractéristique = "" OrElse Comparateur_Caractéristique_Objets(Caractéristique, Pair.Cells(5).Value) Then

                        'Si l'objet est déjà équipé ou non.
                        If Pair.DefaultCellStyle.BackColor <> Color.Lime Then

                            Select Case Liste_Des_Objets(Pair.Cells(2).Value).GetValue(2)

                                Case 1 'Amulette

                                    If Not IsNumeric(.V_User.PictureBox_Amulette.Name) Then
                                        .Socket.Envoyer("OM" & Pair.Cells(3).Value & "|0")
                                    Else
                                        EcritureMessage(Index, "[Equipement]", "Il n'est pas possible d'équiper l'ameulette, une amulette est déjà équipé, veuillez la retiré avant d'équiper une autre amulette.", Color.Red)
                                    End If

                                Case 5, 19, 8, 22, 7, 3, 4, 6, 20, 83 'Arme

                                    If Not IsNumeric(.V_User.PictureBox_Amulette.Name) Then
                                        .Socket.Envoyer("OM" & Pair.Cells(3).Value & "|1")
                                    Else
                                        EcritureMessage(Index, "[Equipement]", "Il n'est pas possible d'équiper l'arme, une arme est déjà équipé, veuillez la retiré avant d'équiper une autre arme.", Color.Red)
                                    End If

                                Case 18 'Familier 

                                    If Not IsNumeric(.V_User.PictureBox_Amulette.Name) Then
                                        .Socket.Envoyer("OM" & Pair.Cells(3).Value & "|8")
                                    Else
                                        EcritureMessage(Index, "[Equipement]", "Il n'est pas possible d'équiper le familier, un familier est déjà équipé, veuillez le retiré avant d'équiper un autre familier.", Color.Red)
                                    End If

                                Case 10 'Ceinture 

                                    If Not IsNumeric(.V_User.PictureBox_Amulette.Name) Then
                                        .Socket.Envoyer("OM" & Pair.Cells(3).Value & "|3")
                                    Else
                                        EcritureMessage(Index, "[Equipement]", "Il n'est pas possible d'équiper la ceinture, une ceinture est déjà équipé, veuillez la retiré avant d'équiper une autre ceinture.", Color.Red)
                                    End If

                                Case 11 'Botte  

                                    If Not IsNumeric(.V_User.PictureBox_Amulette.Name) Then
                                        .Socket.Envoyer("OM" & Pair.Cells(3).Value & "|5")
                                    Else
                                        EcritureMessage(Index, "[Equipement]", "Il n'est pas possible d'équiper les bottes, les bottes son déjà équipé, veuillez les retiré avant d'équiper une autre paire de bottes.", Color.Red)
                                    End If

                                Case 16 'Coiffe 

                                    If Not IsNumeric(.V_User.PictureBox_Amulette.Name) Then
                                        .Socket.Envoyer("OM" & Pair.Cells(3).Value & "|6")
                                    Else
                                        EcritureMessage(Index, "[Equipement]", "Il n'est pas possible d'équiper la coiffe, une coiffe est déjà équipé, veuillez la retiré avant d'équiper une autre coiffe.", Color.Red)
                                    End If

                                Case 17, 81 'Cape/Sac

                                    If Not IsNumeric(.V_User.PictureBox_Amulette.Name) Then
                                        .Socket.Envoyer("OM" & Pair.Cells(3).Value & "|7")
                                    Else
                                        EcritureMessage(Index, "[Equipement]", "Il n'est pas possible d'équiper la cape/sac, une cape/sac est déjà équipé, veuillez la retiré avant d'équiper une autre cape/sac.", Color.Red)
                                    End If

                                Case 9 'Anneaux

                                    If Not IsNumeric(.V_User.PictureBox_Anneaux_1.Name) Then

                                        .Socket.Envoyer("OM" & Pair.Cells(3).Value & "|2")

                                    ElseIf Not IsNumeric(.V_User.PictureBox_Anneaux_2.Name) Then

                                        .Socket.Envoyer("OM" & Pair.Cells(3).Value & "|4")

                                    Else

                                        EcritureMessage(Index, "[Equipement]", "Il n'est pas possible d'équiper un anneau, un anneau est déjà équipé, veuillez le retiré avant d'équiper un autre anneau.", Color.Red)

                                    End If

                                Case 23 'Dofus

                                    With .V_User

                                        Dim Picture() As PictureBox = { .PictureBox_Dofus_1, .PictureBox_Dofus_2,
                                                                        .PictureBox_Dofus_3, .PictureBox_Dofus_4,
                                                                        .PictureBox_Dofus_5, .PictureBox_Dofus_6}

                                        For i = 9 To 14

                                            If Not IsNumeric(Picture(i - 9).Name) Then

                                                Comptes(Index).Socket.Envoyer("OM" & Pair.Cells(3).Value & "|" & i)

                                                Return

                                            End If

                                        Next

                                        EcritureMessage(Index, "[Equipement]", "Il n'est pas possible d'équiper le dofus, un dofus est déjà équipé, veuillez le retiré avant d'équiper un autre dofus.", Color.Red)

                                    End With

                            End Select

                        End If

                    End If

                End If

            Next

        End With

    End Sub

    Public Sub S_Déséquipe_Item(ByVal Index As Integer, ByVal ID_Name_Unique As String, Optional ByVal Caractéristique As String = "")

        With Comptes(Index)

            For Each Pair As DataGridViewRow In Copy_DatagridView(Index, .V_User.DataGridView_Inventaire).Rows

                ' Je vérifie s'il s'agit du bonne ID/ID unique ou du bon nom.
                If Pair.Cells(1).Value.ToString = ID_Name_Unique OrElse Pair.Cells(2).Value = ID_Name_Unique OrElse Pair.Cells(3).Value = ID_Name_Unique Then

                    'Je vérifie ensuite s'il y a des caractéristique spécial à avoir.
                    If Caractéristique = "" OrElse Comparateur_Caractéristique_Objets(Caractéristique, Pair.Cells(5).Value) Then

                        'Si l'objet est déjà équipé ou non.
                        If Pair.DefaultCellStyle.BackColor = Color.Lime Then

                            .Socket.Envoyer("OM" & Pair.Cells(3).Value & "|-1")

                        Else

                            EcritureMessage(Index, "[Déséquipement]", "L'objet '" & Pair.Cells(1).Value & " est déjà déséquipé.", Color.Red)

                        End If

                    End If

                End If

            Next

        End With

    End Sub

    Public Sub S_Item_Placement_Barre(ByVal Index As Integer, ByVal ID_Name_Unique As String, ByVal Quantité As Integer, ByVal Numéro_Place As Integer)

        With Comptes(Index)

            For Each Pair As DataGridViewRow In .V_User.DataGridView_Inventaire.Rows

                If Pair.Cells(1).Value.ToString = ID_Name_Unique OrElse Pair.Cells(2).Value = ID_Name_Unique OrElse Pair.Cells(3).Value = ID_Name_Unique Then

                    .Socket.Envoyer("OM" & Pair.Cells(3).Value & "|" & Numéro_Place & "|" & Quantité)

                    Return

                End If

            Next

        End With

    End Sub

#End Region

#Region "Information"

    Public Sub S_Equipement_Information_Equipé_Déséquipé(ByVal Index As Integer, ByVal Information As String)

        With Comptes(Index)

            ' OM 10500554  | 1
            ' OM ID Unique | Catégorie de l'item

            'Je prend les informations que si trouve après le "OM"
            Information = Mid(Information, 3)

            ' Je sépare les informations vie ce signe "|"
            Dim Separation As String() = Split(Information, "|")

            ' Je cherche dans ma datagridview l'item qui a l'ID unique
            For Each Pair As DataGridViewRow In .V_User.DataGridView_Inventaire.Rows

                If Pair.Cells(3).Value = Separation(0) Then

                    ' Je regarde s'il s'agit d'un item qui est équipé.
                    If Separation(1) <> Nothing Then

                        Pair.DefaultCellStyle.BackColor = Color.Lime

                        S_Equipement_Information_Equipé(Index, Pair.Cells(2).Value, Separation(0), Separation(1))

                    Else ' Sinon il est déséquipé

                        Pair.DefaultCellStyle.BackColor = Color.White

                        S_Equipement_Information_Déséquipé(Index, Pair.Cells(2).Value, Separation(0))

                    End If

                End If

            Next

        End With

    End Sub

    Public Sub S_Equipement_Information_Déséquipé(ByVal Index As Integer, ByVal ID_Objet As Integer, ByVal ID_Unique As Integer)

        With Comptes(Index).V_User

            Try

                ' Je cherche à quel catégorie l'item appartient.
                Select Case Liste_Des_Objets(ID_Objet).GetValue(2)

                    Case 16 'Coiffe 

                        If File.Exists(Application.StartupPath & "\Image\Chapeau Gris.png") Then

                            .PictureBox_Coiffe.Load(Application.StartupPath & "\Image\Chapeau Gris.png")

                        Else

                            .PictureBox_Coiffe.Image = My.Resources.Question

                        End If

                        .PictureBox_Coiffe.Name = "PictureBox_Coiffe"

                    Case 17 'Cape

                        If File.Exists(Application.StartupPath & "\Image\Cape Gris.png") Then

                            .PictureBox_Cape.Load(Application.StartupPath & "\Image\Cape Gris.png")

                        Else

                            .PictureBox_Cape.Image = My.Resources.Question

                        End If

                        .PictureBox_Cape.Name = "PictureBox_Cape"

                    Case 9 'Anneaux

                        If .PictureBox_Anneaux_1.Name = ID_Unique Then

                            If File.Exists(Application.StartupPath & "\Image\Anneau Gris.png") Then

                                .PictureBox_Anneaux_1.Load(Application.StartupPath & "\Image\Anneau Gris.png")

                            Else

                                .PictureBox_Anneaux_1.Image = My.Resources.Question

                            End If

                            .PictureBox_Anneaux_1.Name = "PictureBox_Anneaux_1"

                        Else

                            If File.Exists(Application.StartupPath & "\Image\Anneau Gris.png") Then

                                .PictureBox_Anneaux_2.Load(Application.StartupPath & "\Image\Anneau Gris.png")

                            Else

                                .PictureBox_Anneaux_2.Image = My.Resources.Question

                            End If

                            .PictureBox_Anneaux_2.Name = "PictureBox_Anneaux_2"

                        End If

                    Case 1 'Amulette

                        If File.Exists(Application.StartupPath & "\Image\Amulette Gris.png") Then

                            .PictureBox_Amulette.Load(Application.StartupPath & "\Image\Amulette Gris.png")

                        Else

                            .PictureBox_Amulette.Image = My.Resources.Question

                        End If

                        .PictureBox_Amulette.Name = "PictureBox_Amulette"

                    Case 11 'Botte

                        If File.Exists(Application.StartupPath & "\Image\Botte Gris.png") Then

                            .PictureBox_Bottes.Load(Application.StartupPath & "\Image\Botte Gris.png")

                        Else

                            .PictureBox_Bottes.Image = My.Resources.Question

                        End If

                        .PictureBox_Bottes.Name = "PictureBox_Bottes"

                    Case 10 'Ceinture    

                        If File.Exists(Application.StartupPath & "\Image\Ceinture Gris.png") Then

                            .PictureBox_Ceinture.Load(Application.StartupPath & "\Image\Ceinture Gris.png")

                        Else

                            .PictureBox_Ceinture.Image = My.Resources.Question

                        End If

                        .PictureBox_Ceinture.Name = "PictureBox_Ceinture"

                    Case 5, 19, 8, 22, 7, 3, 4, 6, 20, 83 'Arme

                        If File.Exists(Application.StartupPath & "\Image\Cac Gris.png") Then

                            .PictureBox_CaC.Load(Application.StartupPath & "\Image\Cac Gris.png")

                        Else

                            .PictureBox_CaC.Image = My.Resources.Question

                        End If

                        .PictureBox_CaC.Name = "PictureBox_CaC"

                    Case 18 'Familier 

                        If File.Exists(Application.StartupPath & "\Image\Familier Gris.png") Then

                            .PictureBox_Familier.Load(Application.StartupPath & "\Image\Familier Gris.png")

                        Else

                            .PictureBox_Familier.Image = My.Resources.Question

                        End If

                        .PictureBox_Familier.Name = "PictureBox_Familier"

                    Case 23 'Dofus 9,10,11,12,13,14

                        Dim Picture() As PictureBox = { .PictureBox_Dofus_1, .PictureBox_Dofus_2,
                                            .PictureBox_Dofus_3, .PictureBox_Dofus_4,
                                            .PictureBox_Dofus_5, .PictureBox_Dofus_6}

                        For i = 9 To 14

                            If Picture(i - 9).Name = ID_Unique Then

                                If File.Exists(Application.StartupPath & "\Image\Dofus Gris.png") Then

                                    Picture(i - 9).Load(Application.StartupPath & "\Image\Dofus Gris.png")

                                Else

                                    Picture(i - 9).Image = My.Resources.Question

                                End If

                                Picture(i - 9).Name = "PictureBox_Dofus_" & i - 1

                            End If

                        Next

                End Select

            Catch ex As Exception

                Erreur_Fichier(0, "S_Equipement_Information_Déséquipé", ex.Message)

            End Try

        End With

    End Sub 'FINI

    Public Sub S_Equipement_Information_Equipé(ByVal Index As Integer, ByVal ID_Objet As Integer, ByVal ID_Unique As Integer, ByVal Catégorie As String)

        With Comptes(Index).V_User

            Try

                Select Case Liste_Des_Objets(ID_Objet).GetValue(2)

                    Case 16 'Coiffe 

                        If File.Exists(Application.StartupPath & "\Image\" & Liste_Des_Objets(ID_Objet).GetValue(2) & "/" & ID_Objet & ".png") Then

                            .PictureBox_Coiffe.Load(Application.StartupPath & "\Image\" & Liste_Des_Objets(ID_Objet).GetValue(2) & "/" & ID_Objet & ".png")

                        Else

                            .PictureBox_Coiffe.Image = My.Resources.Question

                        End If

                        .PictureBox_Coiffe.Name = ID_Unique

                    Case 17 'Cape

                        If File.Exists(Application.StartupPath & "\Image\" & Liste_Des_Objets(ID_Objet).GetValue(2) & "/" & ID_Objet & ".png") Then

                            .PictureBox_Cape.Load(Application.StartupPath & "\Image\" & Liste_Des_Objets(ID_Objet).GetValue(2) & "/" & ID_Objet & ".png")

                        Else

                            .PictureBox_Cape.Image = My.Resources.Question

                        End If

                        .PictureBox_Cape.Name = ID_Unique

                    Case 9 'Anneaux

                        If Catégorie = 2 Then

                            If File.Exists(Application.StartupPath & "\Image\" & Liste_Des_Objets(ID_Objet).GetValue(2) & "/" & ID_Objet & ".png") Then

                                .PictureBox_Anneaux_1.Load(Application.StartupPath & "\Image\" & Liste_Des_Objets(ID_Objet).GetValue(2) & "/" & ID_Objet & ".png")

                            Else

                                .PictureBox_Anneaux_1.Image = My.Resources.Question

                            End If

                            .PictureBox_Anneaux_1.Name = ID_Unique

                        Else

                            If File.Exists(Application.StartupPath & "\Image\" & Liste_Des_Objets(ID_Objet).GetValue(2) & "/" & ID_Objet & ".png") Then

                                .PictureBox_Anneaux_2.Load(Application.StartupPath & "\Image\" & Liste_Des_Objets(ID_Objet).GetValue(2) & "/" & ID_Objet & ".png")

                            Else

                                .PictureBox_Anneaux_2.Image = My.Resources.Question

                            End If

                            .PictureBox_Anneaux_2.Name = ID_Unique

                        End If

                    Case 1 'Amulette

                        If File.Exists(Application.StartupPath & "\Image\" & Liste_Des_Objets(ID_Objet).GetValue(2) & "/" & ID_Objet & ".png") Then

                            .PictureBox_Amulette.Load(Application.StartupPath & "\Image\" & Liste_Des_Objets(ID_Objet).GetValue(2) & "/" & ID_Objet & ".png")

                        Else

                            .PictureBox_Amulette.Image = My.Resources.Question

                        End If

                        .PictureBox_Amulette.Name = ID_Unique

                    Case 11 'Botte  

                        If File.Exists(Application.StartupPath & "\Image\" & Liste_Des_Objets(ID_Objet).GetValue(2) & "/" & ID_Objet & ".png") Then

                            .PictureBox_Bottes.Load(Application.StartupPath & "\Image\" & Liste_Des_Objets(ID_Objet).GetValue(2) & "/" & ID_Objet & ".png")

                        Else

                            .PictureBox_Bottes.Image = My.Resources.Question

                        End If

                        .PictureBox_Bottes.Name = ID_Unique

                    Case 10 'Ceinture   

                        If File.Exists(Application.StartupPath & "\Image\" & Liste_Des_Objets(ID_Objet).GetValue(2) & "/" & ID_Objet & ".png") Then

                            .PictureBox_Ceinture.Load(Application.StartupPath & "\Image\" & Liste_Des_Objets(ID_Objet).GetValue(2) & "/" & ID_Objet & ".png")

                        Else

                            .PictureBox_Ceinture.Image = My.Resources.Question

                        End If

                        .PictureBox_Ceinture.Name = ID_Unique

                    Case 5, 19, 8, 22, 7, 3, 4, 6, 20, 83 'Arme

                        If File.Exists(Application.StartupPath & "\Image\" & Liste_Des_Objets(ID_Objet).GetValue(2) & "/" & ID_Objet & ".png") Then

                            .PictureBox_CaC.Load(Application.StartupPath & "\Image\" & Liste_Des_Objets(ID_Objet).GetValue(2) & "/" & ID_Objet & ".png")

                        Else

                            .PictureBox_CaC.Image = My.Resources.Question

                        End If

                        .PictureBox_CaC.Name = ID_Unique

                    Case 18 'Familier 

                        If File.Exists(Application.StartupPath & "\Image\" & Liste_Des_Objets(ID_Objet).GetValue(2) & "/" & ID_Objet & ".png") Then

                            .PictureBox_Familier.Load(Application.StartupPath & "\Image\" & Liste_Des_Objets(ID_Objet).GetValue(2) & "/" & ID_Objet & ".png")


                        Else

                            .PictureBox_Familier.Image = My.Resources.Question

                        End If

                        .PictureBox_Familier.Name = ID_Unique

                    Case 23 'Dofus 9,10,11,12,13,14

                        Dim Picture() As PictureBox = { .PictureBox_Dofus_1, .PictureBox_Dofus_2,
                                                        .PictureBox_Dofus_3, .PictureBox_Dofus_4,
                                                        .PictureBox_Dofus_5, .PictureBox_Dofus_6}

                        For i = 9 To 14

                            If i = Catégorie Then

                                If File.Exists(Application.StartupPath & "\Image\" & Liste_Des_Objets(ID_Objet).GetValue(2) & "/" & ID_Objet & ".png") Then

                                    Picture(i - 9).Load(Application.StartupPath & "\Image\" & Liste_Des_Objets(ID_Objet).GetValue(2) & "/" & ID_Objet & ".png")

                                Else

                                    Picture(i - 9).Image = My.Resources.Question

                                End If

                                Picture(i - 9).Name = ID_Unique

                            End If

                        Next

                End Select

            Catch ex As Exception

                Erreur_Fichier(0, "S_Equipement_Information_Equipé", ex.Message)

            End Try

        End With

    End Sub 'FINI

    Public Sub S_Equipement_Information_Bonus_Ajoute(ByVal Index As Integer, ByVal Information As String)

        With Comptes(Index)

            ' OS+ 5               | 2476     ; 2478    | 76#a#0#0,7d#a#0#0,77#a#0#0,7b#a#0#0,7c#a#0#0,7e#a#0#0
            ' OS+ Numéro_Panoplie | ID_Objet ; ID_Objet| Caractéristique

            ' Je prend toutes les informations après le "OS+"
            Information = Mid(Information, 4)

            ' Puis je sépare les informations via ce signe "|"
            Dim Separation() As String = Split(Information, "|")

            Dim Separation_Information() As String = Split(Separation(1), ";")

            ' Je met les noms directement dans la separation.
            For i = 0 To Separation_Information.Count - 1
                Separation(1) &= Liste_Des_Objets(Separation_Information(i)).GetValue(1) & vbCrLf
            Next

            'Puis j'affiche tout ça dans ma datagridview
            With .V_User.DataGridView_Equipement_Bonus

                'Je mets le numéro de la panoplie.
                .Rows.Add(Separation(0))

                With .Rows(.Rows.Count - 1)

                    'Puis j'ajoute tous les noms directement dans la 2 cellule.
                    .Cells(1).Value = Objet_Caractéristiques(Information(1), Information(2))

                    'Puis les bonus donnée par la panoplie.
                    .Cells(2).Value = Objet_Caractéristiques(Information(1), Information(2))

                End With

            End With

            .V_User.DataGridView_Equipement_Bonus.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .V_User.DataGridView_Equipement_Bonus.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True

        End With

    End Sub

    Public Sub S_Equipement_Information_Bonus_Retire(ByVal Index As Integer, ByVal Information As String)

        With Comptes(Index)

            ' OS- 5               
            ' OS- Numéro_Panoplie 

            ' Je prend toutes les informations après le "OS-"
            Information = Mid(Information, 4)

            For Each Pair As DataGridViewRow In .V_User.DataGridView_Equipement_Bonus.Rows

                If Pair.Cells(0).Value = Information Then

                    .V_User.DataGridView_Equipement_Bonus.Rows.RemoveAt(Pair.Index)

                    Return

                End If

            Next

        End With

    End Sub

#End Region

End Module
