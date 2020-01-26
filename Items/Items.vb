Module Items

    Dim Dico_Caractéristique As New Dictionary(Of String, String) From
        {
        {"76", "Force : "},
        {"9d", "Force : -"},
        {"7d", "Vitalité : "},
        {"99", "Vitalité : -"},
        {"7c", "Sagesse : "},
        {"9c", "Sagesse : -"},
        {"7e", "Intelligence : "},
        {"9b", "Intelligence : -"},
        {"7b", "Chance : "},
        {"98", "Chance : -"},
        {"77", "Agilité : "},
        {"9a", "Agilité : -"},
        {"6f", "PA : "},
        {"65", "PA : -"},
        {"80", "PM : "},
        {"7f", "PM : -"},
        {"75", "PO : "},
        {"74", "PO : -"},
        {"b6", "Invocation : "},
        {"ae", "Initiative : "},
        {"b0", "Prospection : "},
        {"9e", "Pods : "},
        {"73", "Coups Critiques : "},
        {"70", "Dommage : "},
        {"e1", "Dommage Piège : "},
        {"8a", "%Dommage : "},
        {"b2", "Soin : "},
        {"6e", "Régénération : "},
        {"f0", "Résistance Terre : "},
        {"f1", "Résistance Eau : "},
        {"f2", "Résistance Air : "},
        {"f3", "Résistance Feu : "},
        {"f4", "Résistance Neutre : "},
        {"d2", "%Résistance Terre : "},
        {"d7", "%Résistance Terre : -"},
        {"d3", "%Résistance Eau : "},
        {"d8", "%Résistance Eau : -"},
        {"d4", "%Résistance Air : "},
        {"d9", "%Résistance Air : -"},
        {"d5", "%Résistance Feu : "},
        {"da", "%Résistance Feu : -"},
        {"d6", "%Résistance Neutre : "},
        {"db", "%Résistance Neutre : -"},
        {"64", "Corps à Corps : "},
        {"320", "Point de vie : "},
        {"", ""}
        }

    Public Sub Items_Ajoute_DatagridView(ByVal Index As Integer, ByVal Information() As String, ByVal Datagrid_View As DataGridView)

        With Comptes(Index)

            If Information(0) <> "" Then

                For i = 0 To Information.Count - 2

                    ' a30d2a    ~ 1fd6     ~ 1        ~ 0          ~ 7d#63#0#0#0d0+99
                    ' ID Unique ~ ID Objet ~ Quantité ~ Equipement ~ Caractéristique
                    Dim Separation_Information() As String = Split(Information(i), "~")

                    Separation_Information(0) = Convert.ToInt64(Separation_Information(0), 16) ' ID_Unique
                    Separation_Information(1) = Convert.ToInt64(Separation_Information(1), 16) ' ID Objet
                    Separation_Information(2) = Convert.ToInt64(Separation_Information(2), 16) ' Quantité

                    With Datagrid_View

                        'Je mets l'image, mais je vérifie si elle existe ou non.
                        If IO.File.Exists(Application.StartupPath & "\Image\" & Liste_Des_Objets(Separation_Information(1)).GetValue(2) & "\" & Separation_Information(1) & ".png") Then
                            .Rows.Add(New Bitmap(Application.StartupPath & "\Image\" & Liste_Des_Objets(Separation_Information(1)).GetValue(2).ToString & "\" & Separation_Information(1) & ".png"))
                        Else
                            .Rows.Add(My.Resources.Question)
                        End If

                        With .Rows(.Rows.Count - 1)

                            'Nom
                            .Cells(1).Value = Liste_Des_Objets(Separation_Information(1)).GetValue(1)

                            'ID Objet
                            .Cells(2).Value = Separation_Information(1)

                            'ID Unique
                            .Cells(3).Value = Separation_Information(0)

                            'Quantité
                            .Cells(4).Value = Separation_Information(2)

                            'Information
                            .Cells(5).Value = Objet_Caractéristiques(.Cells(2).Value, Separation_Information(4))

                            'Je colorie l'arrière plan si l'item est équipé.
                            If Separation_Information(3) <> Nothing Then
                                .DefaultCellStyle.BackColor = Color.Lime
                            End If

                        End With

                    End With


                    'S'il s'agit d'un Item équipé sur moi.
                    If Separation_Information(3) <> Nothing Then

                        'Information
                        S_Equipement_Information_Equipé(Index, Separation_Information(1), Separation_Information(0), Convert.ToInt64(Separation_Information(3), 16))

                    End If

                Next

                Datagrid_View.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Datagrid_View.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True

            End If

        End With

    End Sub

    Public Sub Item_Ajoute_Banque_Coffre(ByVal Index As Integer, ByVal Information As String, ByVal Datagrid_View As DataGridView)

        With Comptes(Index)

            ' EsKO+ 1101223   | 602      | 289      | 7d#63#0#0#0d0+99
            ' EsKO+ ID Unique | Quantité | ID Objet | Caractéristique

            ' Je prend les informations après le "EsKO+"
            Information = Mid(Information, 6)

            ' Je sépare les informations via ce signe "|"
            Dim Separation As String() = Split(Information, "|")

            ' Je vérifie d'abord que l'item ne se trouve pas dans ma DatagridView
            If F_Vérification_Item_Existe(Index, Separation(0), Separation(1), Datagrid_View) = False Then

                ' J'ajoute moi même l'item.
                With Datagrid_View

                    'Je mets l'image, mais je vérifie si elle existe ou non.
                    If IO.File.Exists(Application.StartupPath & "\Image\" & Liste_Des_Objets(Separation(2)).GetValue(2) & "\" & Separation(2) & ".png") Then
                        .Rows.Add(New Bitmap(Application.StartupPath & "\Image\" & Liste_Des_Objets(Separation(2)).GetValue(2).ToString & "\" & Separation(2) & ".png"))
                    Else
                        .Rows.Add(My.Resources.Question)
                    End If

                    With .Rows(.Rows.Count - 1)

                        'Nom
                        .Cells(1).Value = Liste_Des_Objets(Separation(2)).GetValue(1)

                        'ID Objet
                        .Cells(2).Value = Separation(2)

                        'ID Unique
                        .Cells(3).Value = Separation(0)

                        'Quantité
                        .Cells(4).Value = Separation(1)

                        'Information
                        .Cells(5).Value = If(Separation(3) <> Nothing, Objet_Caractéristiques(Separation(2), Separation(3)), "")

                    End With

                End With

            End If

        End With

    End Sub

    Private Function F_Vérification_Item_Existe(ByVal Index As Integer, ByVal ID_Unique As String, ByVal Quantité As Integer, ByVal Datagrid_View As DataGridView) As Boolean

        With Comptes(Index)

            For Each Pair As DataGridViewRow In Datagrid_View.Rows

                If Pair.Cells(3).Value = ID_Unique Then

                    Pair.Cells(4).Value = Quantité

                    Return True

                End If

            Next

            Return False

        End With

    End Function

    Public Sub Item_Retire_Banque_Coffre(ByVal Index As Integer, ByVal Information As String, ByVal Datagrid_View As DataGridView)

        With Comptes(Index)

            'EsKO- 1101223   
            'EsKO- ID Unique 

            Dim Separation() As String = Split(Mid(Information, 6), "|")

            'Je vérifie d'abord que l'item ne se trouve pas dans ma DatagridView
            For Each Pair As DataGridViewRow In Datagrid_View.Rows

                If Pair.Cells(3).Value = Separation(0) Then

                    Datagrid_View.Rows.RemoveAt(Pair.Index)

                    Return

                End If

            Next

        End With

    End Sub


End Module
