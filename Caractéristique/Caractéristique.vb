Module Caractéristique

    Public Sub Caractéristique_Up(ByVal Index As Integer)

        With Comptes(Index)

            'Je vérifie être connecté ET que je ne suis pas en combat ou en phase de placement.
            If ._Connecté AndAlso False = (._En_Combat AndAlso ._En_Combat_Placement) Then

                'Puis je créer une boucle, qui va me permettre de faire toutes les caractéristiques.
                For i = 1 To 6

                    Tcheck_Control_NuméricUpDown(Index, i)

                Next

            End If

        End With

    End Sub

    Private Sub Tcheck_Control_NuméricUpDown(ByVal Index As Integer, ByVal Priorité As Integer)

        With Comptes(Index)

            'Je vérifie dans ma groupbox les controles qu'il contient
            For Each Le_Control As Control In ._User.GroupBox_Caractéristique_Automatique.Controls

                'S'il s'agit d'un numéricUpDown
                If TypeOf Le_Control Is RedemptionNumericUpDown Then

                    'Je le mets dans une variable pour y avoir toutes les infos.
                    Dim Numéric_Up_Down As RedemptionNumericUpDown = DirectCast(Le_Control, RedemptionNumericUpDown)

                    'Puis je regarde si la valeur de "Numéric_Up_Down" correspond à la priorité
                    If Numéric_Up_Down.Value = Priorité Then

                        'Je récupère alors la base de la caractéristique
                        Dim Caractéristique_Base As Integer = Récupèré_Base_Caractéristique_ListView(Index, Numéric_Up_Down.Text)

                        'J'obtient la liste des textboxs
                        Dim Text_Box() As RedemptionTextBox = {
                                                                ._User.TextBox_Caractéristique_Vitalité_Minimum_0,
                                                                ._User.TextBox_Caractéristique_Sagesse_Minimum_1,
                                                                ._User.TextBox_Caractéristique_Force_Minimum_2,
                                                                ._User.TextBox_Caractéristique_Intelligence_Minimum_3,
                                                                ._User.TextBox_Caractéristique_Chance_Minimum_4,
                                                                ._User.TextBox_Caractéristique_Agilité_Minimum_5
                                                              }

                        'J'obtient le minimum à atteindre pour la caractéristique
                        Dim Minimum_A_Atteindre As Integer = Text_Box(Mid(Numéric_Up_Down.Name, Len(Numéric_Up_Down.Name))).Text

                        'Je vérifie que la caractéristique de base soit inférieur au minimum à atteindre
                        If Caractéristique_Base < Minimum_A_Atteindre Then

                            Tcheck_Dico_Coût_Pour_Up(Index, Numéric_Up_Down.Text, Caractéristique_Base)

                        End If

                    End If

                End If

            Next

        End With

    End Sub

    Private Function Récupèré_Base_Caractéristique_ListView(ByVal Index As Integer, ByVal La_Caractéristique As String) As Integer

        With Comptes(Index)

            For i = 0 To ._User.ListView_Caractéristique.Items.Count - 1

                'Si la caractéristique correspond à celle voulu
                If ._User.ListView_Caractéristique.Items(i).SubItems(0).Text = La_Caractéristique Then

                    Return ._User.ListView_Caractéristique.Items(i).SubItems(1).Text

                End If

            Next

        End With

    End Function

    Private Sub Tcheck_Dico_Coût_Pour_Up(ByVal Index As Integer, ByVal La_Caractéristique As String, ByVal Caractéristique_Base As Integer)

        With Comptes(Index)

            'J'ouvre mon Dico_Caractéristique pour faire la comparaison
            For Each Pair As KeyValuePair(Of String, String()) In Dico_Caractéristique(._Classe)

                'Je regarde si le nom de la caractéristique correspond à celle voulu
                If Pair.Key = La_Caractéristique Then

                    For i = 0 To Pair.Value.Count - 1

                        'Puis je sépare les informations pour comparait.
                        Dim Separation() As String = Split(Pair.Value(i), ">")

                        'Je vérifie que la caractéristique actuel soit supérieur au minimum et inférieur au maximum selon le dico.
                        If Caractéristique_Base > CInt(Separation(0)) AndAlso Caractéristique_Base < CInt(Separation(1)) Then

                            'Je récupère d'abord le nombre de point de caractéristique qu'il me reste.
                            Dim Point_Capital As Integer = Split(._User.Label_Caractéristique_Capital.Text, " : ")(1)

                            'Je regarde ensuite si j'ai asse de point pour Up la caractéristique
                            If Point_Capital >= CInt(Separation(2)) Then

                                Up_De_La_Caractéristique(Index, La_Caractéristique)

                            End If

                            Return

                        End If

                    Next

                End If

            Next

        End With

    End Sub

    Private Sub Up_De_La_Caractéristique(ByVal Index As Integer, ByVal La_Caractéristique As String)

        With Comptes(Index)

            'Alors j'up la caractéristique
            Select Case La_Caractéristique
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

        End With

    End Sub

















    'A REFAIRE EN SIMPLIFIANT, Teste des controls
    Public Sub Caractéristique_Up1(ByVal Index As Integer)

        With Comptes(Index)

            'Je vérifie d'abord être connecté.
            If ._Connecté Then

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
