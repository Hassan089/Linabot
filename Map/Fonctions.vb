Module Fonctions

#Region "Je le touche"

    Private Function HD_BG_Touche(ByVal X1_Moi As Double, ByVal Y1_Moi As Double, ByVal X1_Cible As Double, ByVal Y1_Cible As Double, ByVal B As Bitmap) As Boolean
        While X1_Moi > X1_Cible AndAlso Y1_Moi < Y1_Cible
            Select Case B.GetPixel(X1_Moi, Y1_Moi).Name
                Case "ff808080", "ffff0000", "ff0000ff", "ff000000", "ffffc0cb", "ff00ffff" '"ffa9a9a9" = DarkGray (Ldv = false) / Red (Ennemi) / Blue (Alliée) / Black (Obstacle total) / Pink (Pnj) / Cyan (Percepteur)
                    Return False
                Case "ff8b0000" 'DarkRed (Cible visée)
                    Return True
                Case "ffee82ee" 'Violet (Ligne tracé)
                    Y1_Moi += 0.1
                Case Else
                    X1_Moi -= 0.1
            End Select
        End While
        Return False
    End Function

    Private Function HG_BD_Touche(ByVal X1_Moi As Double, ByVal Y1_Moi As Double, ByVal X1_Cible As Double, ByVal Y1_Cible As Double, ByVal B As Bitmap) As Boolean
        While X1_Moi < X1_Cible AndAlso Y1_Moi < Y1_Cible
            Select Case B.GetPixel(X1_Moi, Y1_Moi).Name
                Case "ffa9a9a9", "ffff0000", "ff0000ff", "ff000000", "ffffc0cb", "ff00ffff" 'DarkGray (Ldv = false) / Red (Ennemi) / Blue (Alliée) / Black (Obstacle total) / Pink (Pnj) / Cyan (Percepteur)
                    Return False
                Case "ff8b0000"  'DarkRed (Cible visée)
                    Return True
                Case "ffee82ee" 'Violet (Ligne tracé)
                    X1_Moi += 0.1
                Case Else
                    Y1_Moi += 0.1
            End Select
        End While
        Return False
    End Function

    Private Function BD_HG_Touche(ByVal X1_Moi As Double, ByVal Y1_Moi As Double, ByVal X1_Cible As Double, ByVal Y1_Cible As Double, ByVal B As Bitmap) As Boolean
        While X1_Moi > X1_Cible AndAlso Y1_Moi > Y1_Cible
            Select Case B.GetPixel(X1_Moi, Y1_Moi).Name
                Case "ffa9a9a9", "ffff0000", "ff0000ff", "ff000000", "ffffc0cb", "ff00ffff" 'DarkGray (Ldv = false) / Red (Ennemi) / Blue (Alliée) / Black (Obstacle total) / Pink (Pnj) / Cyan (Percepteur)
                    Return False
                Case "ff8b0000"  'DarkRed (Cible visée)
                    Return True
                Case "ffee82ee" 'Violet (Ligne tracé)
                    X1_Moi -= 0.1
                Case Else
                    Y1_Moi -= 0.1
            End Select
        End While
        Return False
    End Function

    Private Function BG_HD_Touche(ByVal X1_Moi As Double, ByVal Y1_Moi As Double, ByVal X1_Cible As Double, ByVal Y1_Cible As Double, ByVal B As Bitmap) As Boolean
        While X1_Moi < X1_Cible AndAlso Y1_Moi > Y1_Cible
            Select Case B.GetPixel(X1_Moi, Y1_Moi).Name
                Case "ffa9a9a9", "ffff0000", "ff0000ff", "ff000000", "ffffc0cb", "ff00ffff" 'DarkGray (Ldv = false) / Red (Ennemi) / Blue (Alliée) / Black (Obstacle total) / Pink (Pnj) / Cyan (Percepteur)
                    Return False
                Case "ff8b0000"  'DarkRed (Cible visée)
                    Return True
                Case "ffee82ee" 'Violet (Ligne tracé)
                    X1_Moi += 0.1
                Case Else
                    Y1_Moi -= 0.1
            End Select
        End While
        Return False
    End Function

    Private Function Ligne_Droite_Touche(ByVal X1_Moi As Double, ByVal Y1_Moi As Double, ByVal X1_Cible As Double, ByVal Y1_Cible As Double, ByVal B As Bitmap, ByVal g As Graphics) As Boolean
        While X1_Moi <= X1_Cible AndAlso Y1_Moi = Y1_Cible
            Select Case B.GetPixel(X1_Moi, Y1_Moi + 2).Name
                Case "ffa9a9a9", "ffff0000", "ff0000ff", "ff000000", "ffffc0cb", "ff00ffff" 'DarkGray (Ldv = false) / Red (Ennemi) / Blue (Alliée) / Black (Obstacle total) / Pink (Pnj) / Cyan (Percepteur)
                    Return False
                Case "ff8b0000"  'DarkRed (Cible visée)
                    Return True
                Case Else
                    X1_Moi += 40
            End Select
        End While
        Return False
    End Function

    Private Function Ligne_Gauche_Touche(ByVal X1_Moi As Double, ByVal Y1_Moi As Double, ByVal X1_Cible As Double, ByVal Y1_Cible As Double, ByVal B As Bitmap, ByVal g As Graphics) As Boolean
        While X1_Moi >= X1_Cible AndAlso Y1_Moi = Y1_Cible
            Select Case B.GetPixel(X1_Moi, Y1_Moi + 2).Name
                Case "ffa9a9a9", "ffff0000", "ff0000ff", "ff000000", "ffffc0cb", "ff00ffff" 'DarkGray (Ldv = false) / Red (Ennemi) / Blue (Alliée) / Black (Obstacle total) / Pink (Pnj) / Cyan (Percepteur)
                    Return False
                Case "ff8b0000"  'DarkRed (Cible visée)
                    Return True
                Case Else
                    X1_Moi -= 40
            End Select
        End While
        Return False
    End Function

    Private Function Ligne_Haut_Touche(ByVal X1_Moi As Double, ByVal Y1_Moi As Double, ByVal X1_Cible As Double, ByVal Y1_Cible As Double, ByVal B As Bitmap, ByVal g As Graphics) As Boolean
        While X1_Moi = X1_Cible AndAlso Y1_Moi >= Y1_Cible
            Select Case B.GetPixel(X1_Moi + 2, Y1_Moi).Name
                Case "ffa9a9a9", "ffff0000", "ff0000ff", "ff000000", "ffffc0cb", "ff00ffff" 'DarkGray (Ldv = false) / Red (Ennemi) / Blue (Alliée) / Black (Obstacle total) / Pink (Pnj) / Cyan (Percepteur)
                    Return False
                Case "ff8b0000"  'DarkRed (Cible visée)
                    Return True
                Case Else
                    Y1_Moi -= 20
            End Select
        End While
        Return False
    End Function

    Private Function Ligne_Bas_Touche(ByVal X1_Moi As Double, ByVal Y1_Moi As Double, ByVal X1_Cible As Double, ByVal Y1_Cible As Double, ByVal B As Bitmap, ByVal g As Graphics) As Boolean
        While X1_Moi = X1_Cible AndAlso Y1_Moi <= Y1_Cible
            Select Case B.GetPixel(X1_Moi + 2, Y1_Moi).Name
                Case "ffa9a9a9", "ffff0000", "ff0000ff", "ff000000", "ffffc0cb", "ff00ffff" 'DarkGray (Ldv = false) / Red (Ennemi) / Blue (Alliée) / Black (Obstacle total) / Pink (Pnj) / Cyan (Percepteur)
                    Return False
                Case "ff8b0000"  'DarkRed (Cible visée)
                    Return True
                Case Else
                    Y1_Moi += 20
            End Select
        End While
        Return False
    End Function

#End Region


    Public Function Distance(ByVal pos1 As Integer, ByVal pos2 As Integer, ByVal Index As Integer) As Double
        With Comptes(Index)
            Dim num4 As Decimal = Decimal.op_Decrement(Math.Ceiling(CDec(pos1 / ((.V_Map_Largeur * 2) - 1))))
            Dim num12 As Decimal = Decimal.op_Decrement(Math.Ceiling(CDec(pos2 / ((15 * 2) - 1))))
            Dim num15 As Decimal = num12 - Decimal.op_Modulus(pos2 - (num12 * ((15 * 2) - 1)), 15)
            Return Math.Sqrt(Math.Pow(Convert.ToDouble(pos2 - ((15 - 1) * num15 / 15) - (pos1 - ((.V_Map_Largeur - 1) * (num4 - Decimal.op_Modulus(pos1 - (num4 * ((.V_Map_Largeur * 2) - 1)), .V_Map_Largeur)))) / .V_Map_Largeur), 2) + Math.Pow(Convert.ToDouble(num15 - (num4 - Decimal.op_Modulus(pos1 - (num4 * ((.V_Map_Largeur * 2) - 1)), .V_Map_Largeur))), 2))
        End With

    End Function


    Public Function Distance2(ByVal pos1 As Integer, ByVal pos2 As Integer, ByVal Index As Integer) As Double
        Dim num18 As Double
        Dim num As Integer = pos1
        Dim num2 As Integer = Comptes(Index).V_Map_Largeur
        Dim d As Decimal = num / ((num2 * 2) - 1)
        Dim num4 As Decimal = Decimal.op_Decrement(Math.Ceiling(d))
        Dim num5 As Decimal = num - (num4 * ((num2 * 2) - 1))
        Dim num6 As Decimal = Decimal.op_Modulus(num5, num2)
        Dim num7 As Decimal = num4 - num6
        Dim num8 As Decimal = (num - ((num2 - 1) * num7)) / num2
        Dim num9 As Integer = pos2
        Dim num10 As Integer = 15
        Dim num11 As Decimal = num9 / ((num10 * 2) - 1)
        Dim num12 As Decimal = Decimal.op_Decrement(Math.Ceiling(num11))
        Dim num13 As Decimal = num9 - (num12 * ((num10 * 2) - 1))
        Dim num14 As Decimal = Decimal.op_Modulus(num13, num10)
        Dim num15 As Decimal = num12 - num14
        Dim num16 As Decimal = (num9 - ((num10 - 1) * num15)) / num10
        num18 = Math.Sqrt(Math.Pow(Convert.ToDouble(num16 - num8), 2) + Math.Pow(Convert.ToDouble(num15 - num7), 2))
        Return num18
    End Function


    Private Class loc8
        Public y As Integer = 0
        Public x As Integer = 0
    End Class

    Public Function getX(ByVal laCase As Integer, ByVal Index As Integer)
        Try
            Dim _loc4 = Comptes(Index).V_Map_Largeur 'mapHandler.Length()
            Dim _loc5 = Math.Floor(laCase / (_loc4 * 2 - 1))
            Dim _loc6 = laCase - _loc5 * (_loc4 * 2 - 1)
            Dim _loc7 = _loc6 Mod _loc4
            Dim _loc8 As New loc8

            Dim y As Integer = _loc5 - _loc7
            Dim x As Integer = (laCase - (_loc4 - 1) * y) / _loc4
            Return x
        Catch ex As Exception

        End Try
        Return 0
    End Function

    Public Function getY(ByVal laCase As Integer, ByVal Index As Integer)
        Try
            Dim _loc4 = Comptes(Index).V_Map_Largeur 'mapHandler.Length()
            Dim _loc5 = Math.Floor(laCase / (_loc4 * 2 - 1))
            Dim _loc6 = laCase - _loc5 * (_loc4 * 2 - 1)
            Dim _loc7 = _loc6 Mod _loc4
            Dim _loc8 As New loc8
            Dim y As Integer = _loc5 - _loc7
            Dim x As Integer = (laCase - (_loc4 - 1) * y) / _loc4
            Return y
        Catch ex As Exception

        End Try
        Return 0
    End Function

    Public Function goalDistance(ByVal pos1 As Integer, ByVal pos2 As Integer, ByVal Index As Integer) As Integer
        Dim _loc7 = Math.Abs(getX(pos1, Index) - getX(pos2, Index))
        Dim _loc8 = Math.Abs(getY(pos1, Index) - getY(pos2, Index))
        Return _loc7 + _loc8
    End Function
End Module
