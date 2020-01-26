Module Régénération

#Region "Information"

    Public Sub S_Régénération_Information_Temps(ByVal Index As Integer, ByVal Information As String)

        With Comptes(Index).V_User

            ' ILS 2000
            ' ILS Milliseconde entre chaque point de vie récupéré.

            'Je prend les informations qui se trouve après "ILS"
            Information = Mid(Information, 4)

            EcritureMessage(Index, "(Dofus)", "Votre personnage récupére 1 point de vie toutes les " & Information & " seconde(s).", Color.Green)

            .Timer_Régénération.Enabled = False
            .Timer_Régénération.Interval = CInt(Information)
            .Timer_Régénération.Enabled = True


        End With

    End Sub

#End Region

End Module
