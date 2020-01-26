Module Item_Quantité

    Public Sub S_Item_Information_Modifie_Quantité(ByVal Index As Integer, ByVal Information As String)

        With Comptes(Index)

            ' OQ 307978387 | 60
            ' OQ ID Unique | Quantité

            ' Je prend les informations après le "OQ"
            Information = Mid(Information, 3)

            ' Puis je sépare les informations via ce signe "|"
            Dim Separation As String() = Split(Information, "|")

            For Each Pair As DataGridViewRow In .V_User.DataGridView_Inventaire.Rows

                If Pair.Cells(3).Value = Separation(0) Then

                    'Je change la quantité
                    Pair.Cells(4).Value = Separation(1)

                    Return

                End If

            Next

        End With

    End Sub

End Module
