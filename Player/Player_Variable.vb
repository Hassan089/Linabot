Partial Public Class Player

    Public compteur As Integer



    'Information du compte
    Public _Nom_De_Compte, _Mot_De_Passe, _Nom_Du_Personnage, _Serveur, _Classe, _Ticket, V_ID_Unique As String

    'Index
    Public V_Index As Integer

    'Le groupe
    Public V_Groupe As New Groupe

    'La page initial + le tab_personnage pour le groupe
    Public V_User As New Page_Initial
    Dim Tab_Perso As New TabPage

    'Connexion
    Public _En_Connexion, V_Connecté As New Boolean

    'Les Sockets
    Public Socket_Authentification, Socket As All_CallBack

    'Pods
    Public _Pods As Integer

    'Régénération
    Public _Régénération As Integer

    'Autorisation de base
    Public _Autorisation_Echange As Boolean
    Public _Autorisation_Défi As Boolean
    Public _Autorisation_Agression As Boolean
    Public _Autorisation_Interraction As Boolean
    Public _Autorisation_Attaquer_Mobs As Boolean

    'Vivant ou mort
    Public _Fantôme As Boolean

    'Dialogue (PNJ)
    Public _En_Dialogue As Boolean
    Public _Dialogue_ID_Réponse As Integer
    Public _Dialogue_Réponses_Possible As New List(Of String)

    'Craft
    Public _En_Craft As Boolean
    Public _En_Atelier As Boolean
    Public _Craft_Combiner_Moi, _Craft_Combiner_Lui As Boolean

    'Echange
    Public _En_Echange As Boolean

    'Hôtel de vente
    Public _En_Hôtel_De_Vente As Boolean

    'Achat/Vente
    Public _En_Achat_Vente As Boolean

    'Banque ou Coffre
    Public _En_Banque_Coffre As Boolean

    'Enclos
    Public _En_Enclos As Boolean

    'Déplacement
    Public V_En_Déplacement As Boolean
    Public V_Case_Actuelle As Integer

    'En Tchat
    Public _En_Tchat As Boolean

    'Combat
    Public _Combat_Spectateur_Bloqué, _Combat_Groupe_Bloqué, _Combat_Cadenas_Bloqué, V_En_Combat, V_En_Combat_Placement As Boolean
    Public V_Combat_Equipe As Integer

    'Défi
    Public V_En_Défi As Boolean

    'Map
    Public V_Map_ID As Integer
    Public V_Map_Bas,
           V_Map_Haut,
           V_Map_Gauche,
           V_Map_Droite As Integer
    Public V_Map_Largeur,
           V_Map_Hauteur As Integer
    Public V_Map_Data_Actuel(1280) As Cell
    Public V_Path_Final As String

    Public V_Modérateur,
           V_Crocoburio As Boolean

    Public V_Send As String

#Region "Initialise"

    Public Sub Initialiser(ByVal Form_Groupe As Groupe, ByVal Compteur As Integer, ByVal Image As String)

        'Je nomme le Tab_Page par le nom du personnage.
        Tab_Perso.Text = _Nom_Du_Personnage

        'J'ajoute à la form "groupe", dans le tabcontrol, le tab_page.
        Form_Groupe.TabControl1.Controls.Add(Tab_Perso)

        'Dans le Tab_Page j'ajoute "Page_Initial"
        Tab_Perso.Controls.Add(V_User)

        'Je donne l'index aussi dans le Panel_utilisateur
        V_User.Index = Compteur

        'Puis je donne le groupe auquel il appartient.
        V_Groupe = Form_Groupe

        'Je met l'image associé
        Tab_Perso.ImageKey = Image & ".png"

    End Sub


#End Region

End Class
