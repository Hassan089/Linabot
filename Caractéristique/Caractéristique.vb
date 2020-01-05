Module Caractéristique


    'A REFAIRE EN SIMPLIFIANT, Teste des controls
    Public Sub Caractéristique_Up(ByVal Index As Integer)

        With Comptes(Index)

            'Je vérifie d'abord être connecté.
            If ._Connecté = 1 Then

                'Je vérifie ensuite que je ne suis pas en combat ou en phase de placement.
                If False = (._En_Combat AndAlso ._En_Combat_Placement) Then

                    'Ici je créer ma boucle pour faire chaque control selon la priorité
                    For i = 1 To 6

                        'Je regarde si "i" correspond à l'une des priorités voulu
                        For Each Le_Control As Control In ._User.GroupBox_Caractéristique_Automatique.Controls

                            'Si le control est belle est bien un numéricupdown
                            If TypeOf Le_Control Is RedemptionNumericUpDown Then

                                'Je le mets dans une variable pour y avoir toutes les infos.
                                Dim Numéric_Up_Down As RedemptionNumericUpDown = DirectCast(Le_Control, RedemptionNumericUpDown)

                                'Je regarde se la valeur et égal à la priorité.
                                If Numéric_Up_Down.Value = i Then

                                    'Alors j'obtient la liste des textboxs
                                    Dim Text_Box() As RedemptionTextBox = { ._User.TextBox_Caractéristique_Vitalité_Minimum_0,
                                                                            ._User.TextBox_Caractéristique_Sagesse_Minimum_1,
                                                                            ._User.TextBox_Caractéristique_Force_Minimum_2,
                                                                            ._User.TextBox_Caractéristique_Intelligence_Minimum_3,
                                                                            ._User.TextBox_Caractéristique_Chance_Minimum_4,
                                                                            ._User.TextBox_Caractéristique_Agilité_Minimum_5
                                                                          }

                                    'J'obtient ensuite la caractéristique de base dans ma listview
                                    For e = 0 To ._User.ListView_Caractéristique.Items.Count - 1

                                        'Je trouve d'abord la caractéristique qui correspond à la caractéristiue à up
                                        If ._User.ListView_Caractéristique.Items(e).SubItems(0).Text = Numéric_Up_Down.Text Then

                                            Dim Minimum_A_Atteindre As Integer = Text_Box(Mid(Numéric_Up_Down.Name, Len(Numéric_Up_Down.Name))).Text
                                            Dim Caractéristique_Actuel As Integer = ._User.ListView_Caractéristique.Items(e).SubItems(1).Text

                                            'Je regarde avant si le minimum a été atteint ou non.
                                            If Caractéristique_Actuel < Minimum_A_Atteindre Then

                                                'J'ouvre mon Dico_Caractéristique pour faire la comparaison
                                                For Each Pair As KeyValuePair(Of String, String()) In Dico_Caractéristique(._Classe)

                                                    'Je regarde si le nom de la caractéristique correspond à celle voulu
                                                    If Pair.Key = Numéric_Up_Down.Text Then

                                                        For a = 0 To Pair.Value.Count - 1

                                                            'Puis je sépare les informations pour comparait.
                                                            Dim Separation() As String = Split(Pair.Value(a), ">")

                                                            'Je vérifie que la caractéristique actuel soit supérieur au minimum et inférieur au maximum selon le dico.
                                                            If Caractéristique_Actuel > CInt(Separation(0)) AndAlso Caractéristique_Actuel < CInt(Separation(1)) Then

                                                                'Je regarde ensuite si j'ai asse de point pour Up la caractéristique
                                                                If CInt(Split(._User.Label_Caractéristique_Capital.Text, " : ")(1)) >= CInt(Separation(2)) Then

                                                                    'Alors j'up la caractéristique
                                                                    Select Case Numéric_Up_Down.Text
                                                                        Case "Vitalité"
                                                                            .Socket.Envoyer("AB11")
                                                                        Case "Sagesse"
                                                                            .Socket.Envoyer("AB12")
                                                                        Case "Force"
                                                                            .Socket.Envoyer("AB10")
                                                                        Case "Intelligence"
                                                                            .Socket.Envoyer("AB15")
                                                                        Case "Chance"
                                                                            .Socket.Envoyer("AB13")
                                                                        Case "Agilité"
                                                                            .Socket.Envoyer("AB14")
                                                                    End Select

                                                                    Return

                                                                Else

                                                                    Exit For

                                                                End If

                                                            End If

                                                        Next

                                                    End If

                                                Next


                                            End If


                                        End If

                                    Next

                                End If

                            End If

                        Next

                    Next

                End If

            End If

        End With

    End Sub



End Module
