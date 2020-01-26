Module Item_Sol

#Region "Action"

    Public Sub S_Item_Jette_Sol(ByVal Index As Integer, ByVal ID_Name As String, ByVal Quantité As Integer, Optional ByVal Caractéristique As String = "")

        With Comptes(Index)

            For Each Pair As DataGridViewRow In Copy_DatagridView(Index, .V_User.DataGridView_Inventaire).Rows

                'Je vérifie avoir le bon nom ou ID de l'item voulu
                If Pair.Cells(1).Value.ToString.ToUpper.Replace(" ", "") = ID_Name.ToUpper.Replace(" ", "") OrElse Pair.Cells(2).Value = ID_Name OrElse Pair.Cells(3).Value.ToString = ID_Name Then

                    'Je vérifie que les caractéristique correspond à ceux voulu
                    If Caractéristique = "" OrElse Comparateur_Caractéristique_Objets(Caractéristique, Pair.Cells(5).Value) Then

                        Quantité = If(Quantité > CInt(Pair.Cells(4).Value), Pair.Cells(4).Value, Quantité)

                        .Socket.Envoyer("OD" & Pair.Cells(3).Value & "|" & Quantité)

                        Exit For

                    End If

                End If

            Next

        End With

    End Sub

#End Region

#Region "Information"

    Public Sub S_Item_Information_Ajoute_Sol(ByVal Index As Integer, ByVal Information As String)

        With Comptes(Index)

            'GDO+ 194     ; 526      ; 0
            'GDO+ Cellule ; ID_Objet ; Ramasser

            'GDO+ 344     ; 7694     ; 1      ; 2623             ; 9000           |374;7694;1;2893;9000
            'GDO+ Cellule ; ID Objet ; Retiré ; Résistnce actuel ; Résistance Max |Next 

            ' Je prend les informations après le "GDO+"
            Information = Mid(Information, 5)

            ' Je sépare les informations via ce signe "|"
            Dim Separation As String() = Split(Information, "|")

            For i = 0 To Separation.Count - 1

                ' Je sépare les informations via ce signe ";"
                Dim Separation_Information As String() = Split(Separation(i), ";")

                With .V_User.DataGridView_Map_Sol

                    'Je mets l'image, mais je vérifie si elle existe ou non.
                    If IO.File.Exists(Application.StartupPath & "\Image\" & Liste_Des_Objets(Separation_Information(1)).GetValue(2) & "\" & Separation_Information(1) & ".png") Then
                        .Rows.Add(New Bitmap(Application.StartupPath & "\Image\" & Liste_Des_Objets(Separation_Information(1)).GetValue(2).ToString & "\" & Separation_Information(1) & ".png"))
                    Else
                        .Rows.Add(My.Resources.Question)
                    End If

                    With .Rows(.Rows.Count - 1)

                        'Cellule
                        .Cells(2).Value = Separation_Information(0)

                        'Nom
                        .Cells(2).Value = Liste_Des_Objets(Separation_Information(1)).GetValue(1)

                        'ID Objet
                        .Cells(3).Value = Separation_Information(1)

                        If Separation_Information.Count > 2 Then

                            Select Case Separation_Information(2)

                                Case "1" 'Indique qu'il peut être ramasser

                                    .Cells(4).Value = "Retiré : " & Liste_Des_Objets(Separation_Information(1)).GetValue(1) & vbCrLf & ' Ro & Separation(0) (permet d'enlever l'item dans l'enclos.)
                                                      "Résistance : " & Separation_Information(3) & "/" & Separation_Information(4)

                                Case Else

                                    .Cells(4).Value = "Ramasser : " & Liste_Des_Objets(Separation_Information(1)).GetValue(1) & vbCrLf & ' Se déplacer sur la cellule
                                                      "Au sol"

                            End Select

                        End If

                    End With

                    .RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True

                End With

            Next

        End With

    End Sub

    Public Sub S_Item_Information_Retire_Sol(ByVal Index As Integer, ByVal Information As String)

        With Comptes(Index)

            'GDO- 194 
            'GDO- Cellule

            'Je prend les informations après le "GDO-"
            Information = Mid(Information, 5)

            For Each Pair As DataGridViewRow In .V_User.DataGridView_Map_Sol.Rows

                If Pair.Cells(1).Value = Information Then

                    .V_User.DataGridView_Map_Sol.Rows.RemoveAt(Pair.Index)

                    Return

                End If

            Next

        End With

    End Sub

#End Region

End Module
