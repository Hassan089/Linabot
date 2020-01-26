Module Métiers_Information

    Public Sub Métiers_Information_Up(ByVal Index As Integer, ByVal Information As String)

        With Comptes(Index)

            'JN 28        | 73
            'JN ID Métier | Level

            'Je prend tout se qui se trouve après le "JN"
            Information = Mid(Information, 3)

            'Je sépare les informations via ce signe "|"
            Dim Separation As String() = Split(Information, "|")

            EcritureMessage(Index, "(Dofus)", "Ton métier " & Dico_Métiers.Keys(Separation(0)) & " passe niveau " & Separation(1) & ".", Color.Green)

        End With

    End Sub

    ' Quand je reçoit les métiers à la co 


    Public Sub Métiers_Information_Métiers_Reçu(ByVal Index As Integer, ByVal Information As String)

        With Comptes(Index)

            ' JS|ID_Métier;ID_Atelier~Nbr_Case~0~0~%_Réussite,ID_Atelier~Nbr_Case~0~0~%_Réussite|Next information 

            Return


            Dim Separation As String() = Split(Information, "|")

            For i = 1 To Separation.Count - 1

                Dim Separation_Info As String() = Split(Separation(i), ";")

                Dim ID_Métier As Integer = Separation_Info(0)

                Separation_Info = Split(Separation_Info(1), ",")



            Next


        End With

    End Sub

    Dim Le_Métier As New Métiers_Control

    Public Sub testeur(ByVal Index As Integer, ByVal Information As String)

        With Comptes(Index)

            Dim Separation As String() = Split(Information, "|")
            ' JS|ID_Métier;ID_Atelier~Nbr_Case~0~0~%_Réussite,ID_Atelier~Nbr_Case~0~0~%_Réussite|Next information 
            For i = 1 To Separation.Count - 1

                Dim Separation_Info As String() = Split(Separation(i), ";")

                Dim ID_Métier As Integer = Separation_Info(0)

                Separation_Info = Split(Separation_Info(1), ",")

                For a = 0 To Separation_Info.Count - 1

                    Dim Separation_Final As String() = Split(Separation_Info(a), ",")

                    With Le_Métier

                        .PictureBox1.Image = My.Resources.Blessé

                        .Label_Nom_Du_Métier.Text = Dico_Métiers(2).GetValue(1)

                        Exit For

                    End With

                Next

                Exit For

            Next

            If Not .V_User.TabPage_Métiers.Controls.Contains(Le_Métier) Then
                .V_User.TabPage_Métiers.Controls.Add(Le_Métier)
            End If
            '.V_User.TabPage7.Controls.Add(Le_Métier)
        End With

    End Sub

End Module
