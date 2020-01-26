Module Item_Utilise

    Public Sub S_Item_Utilise(ByVal Index As Integer, ByVal ID_Name As String, Optional ByVal Caractéristique As String = "")

        With Comptes(Index)

            For Each Pair As DataGridViewRow In Copy_DatagridView(Index, .V_User.DataGridView_Inventaire).Rows

                'Je vérifie avoir le bon nom ou ID de l'item voulu
                If Pair.Cells(1).Value.ToString.ToUpper.Replace(" ", "") = ID_Name.ToUpper.Replace(" ", "") OrElse Pair.Cells(2).Value = ID_Name OrElse Pair.Cells(3).Value.ToString = ID_Name Then

                    'Je vérifie que les caractéristique correspond à ceux voulu
                    If Caractéristique = "" OrElse Comparateur_Caractéristique_Objets(Caractéristique, Pair.Cells(5).Value) Then

                        .Socket.Envoyer("OU" & Pair.Cells(3).Value & "|")

                        Return

                    End If

                End If

            Next

        End With

    End Sub

End Module
