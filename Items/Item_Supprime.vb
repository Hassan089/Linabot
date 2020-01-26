Module Item_Supprime

#Region "Action"
    Public Sub S_Item_Supprimé(ByVal Index As Integer, ByVal ID_Name_Unique As String, ByVal Quantité As Integer, Optional ByVal Caractéristique As String = "")

        With Comptes(Index)

            For Each Pair As DataGridViewRow In Copy_DatagridView(Index, .V_User.DataGridView_Inventaire).Rows

                ' Je vérifie s'il s'agit du bonne ID/ID unique ou du bon nom.
                If Pair.Cells(1).Value.ToString = ID_Name_Unique OrElse Pair.Cells(2).Value = ID_Name_Unique OrElse Pair.Cells(3).Value = ID_Name_Unique Then

                    'Je vérifie ensuite s'il y a des caractéristique spécial à avoir.
                    If Caractéristique = "" OrElse Comparateur_Caractéristique_Objets(Caractéristique, Pair.Cells(5).Value) Then

                        'Je vérifie que l'utilisateur souhaite pas supprimé plus de quantité qu'il posséde.
                        If Quantité > CInt(Pair.Cells(4).Value) Then
                            Quantité = CInt(Pair.Cells(4).Value)
                        End If

                        .Socket.Envoyer("Od" & Pair.Cells(3).Value & "|" & Quantité)

                        Return

                    End If

                End If

            Next

        End With

    End Sub

#End Region

#Region "Information"
    Public Sub S_Item_Information_Supprimé(ByVal Index As Integer, ByVal Information As String)

        With Comptes(Index)

            ' Je prend les informations qui se trouve après le "OR"
            Information = Mid(Information, 3)

            For Each Pair As DataGridViewRow In .V_User.DataGridView_Inventaire.Rows

                If Pair.Cells(3).Value = Information Then

                    EcritureMessage(Index, "[Suppression]", "L'item '" & Pair.Cells(1).Value & "' a été supprimé.", Color.Red)

                    .V_User.DataGridView_Inventaire.Rows.RemoveAt(Pair.Index)

                    Return

                End If

            Next

        End With

    End Sub
#End Region

End Module
