<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Métiers_Control
    Inherits System.Windows.Forms.UserControl

    'UserControl remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Métiers_Control))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label_Nom_Du_Métier = New Linabot.RedemptionLabel()
        Me.Label_Niveau_Du_Métier = New Linabot.RedemptionLabel()
        Me.RedemptionLabel1 = New Linabot.RedemptionLabel()
        Me.ProgressBar_Expérience = New Linabot.RedemptionProgressBar()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage_Caractéristique = New System.Windows.Forms.TabPage()
        Me.TabPage_Recettes = New System.Windows.Forms.TabPage()
        Me.TabPage_Options = New System.Windows.Forms.TabPage()
        Me.RedemptionLabel2 = New Linabot.RedemptionLabel()
        Me.ListView_Inventaire_Affiche_Caractéristique = New System.Windows.Forms.ListView()
        Me.RedemptionLabel3 = New Linabot.RedemptionLabel()
        Me.Label_Nom_Item_Métier = New Linabot.RedemptionLabel()
        Me.Label_Niveau_Arme = New Linabot.RedemptionLabel()
        Me.TextBox_Définition = New Linabot.RedemptionTextBox()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage_Effets = New System.Windows.Forms.TabPage()
        Me.TabPage_Conditions = New System.Windows.Forms.TabPage()
        Me.TabPage_Caractéristiques = New System.Windows.Forms.TabPage()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.ListView3 = New System.Windows.Forms.ListView()
        Me.FlowLayoutPanel_Recette = New System.Windows.Forms.FlowLayoutPanel()
        Me.CheckBox_8 = New Linabot.RedemptionCheckBox()
        Me.CheckBox_1 = New Linabot.RedemptionCheckBox()
        Me.CheckBox_2 = New Linabot.RedemptionCheckBox()
        Me.CheckBox_3 = New Linabot.RedemptionCheckBox()
        Me.CheckBox_4 = New Linabot.RedemptionCheckBox()
        Me.CheckBox_5 = New Linabot.RedemptionCheckBox()
        Me.CheckBox_6 = New Linabot.RedemptionCheckBox()
        Me.CheckBox_7 = New Linabot.RedemptionCheckBox()
        Me.RedemptionLabel4 = New Linabot.RedemptionLabel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.RedemptionLabel5 = New Linabot.RedemptionLabel()
        Me.CheckBox_Payant = New Linabot.RedemptionCheckBox()
        Me.CheckBox_Fournit_Ressource = New Linabot.RedemptionCheckBox()
        Me.CheckBox_Gratuit = New Linabot.RedemptionCheckBox()
        Me.RedemptionLabel6 = New Linabot.RedemptionLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.NumericUpDown_Nombre_Ingrédient = New Linabot.RedemptionNumericUpDown()
        Me.Button_Sauvegarder = New Linabot.RedemptionButton()
        Me.Label_Mode_Public = New Linabot.RedemptionLabel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Button_Mode_Public = New Linabot.RedemptionButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage_Caractéristique.SuspendLayout()
        Me.TabPage_Recettes.SuspendLayout()
        Me.TabPage_Options.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage_Effets.SuspendLayout()
        Me.TabPage_Conditions.SuspendLayout()
        Me.TabPage_Caractéristiques.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.TabControl1)
        Me.GroupBox1.Controls.Add(Me.ProgressBar_Expérience)
        Me.GroupBox1.Controls.Add(Me.RedemptionLabel1)
        Me.GroupBox1.Controls.Add(Me.Label_Niveau_Du_Métier)
        Me.GroupBox1.Controls.Add(Me.Label_Nom_Du_Métier)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(623, 644)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label_Nom_Du_Métier
        '
        Me.Label_Nom_Du_Métier.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label_Nom_Du_Métier.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label_Nom_Du_Métier.ForeColor = System.Drawing.Color.White
        Me.Label_Nom_Du_Métier.Location = New System.Drawing.Point(122, 12)
        Me.Label_Nom_Du_Métier.Name = "Label_Nom_Du_Métier"
        Me.Label_Nom_Du_Métier.Size = New System.Drawing.Size(495, 30)
        Me.Label_Nom_Du_Métier.TabIndex = 1
        Me.Label_Nom_Du_Métier.Text = "Nom du métier"
        '
        'Label_Niveau_Du_Métier
        '
        Me.Label_Niveau_Du_Métier.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label_Niveau_Du_Métier.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label_Niveau_Du_Métier.ForeColor = System.Drawing.Color.White
        Me.Label_Niveau_Du_Métier.Location = New System.Drawing.Point(530, 12)
        Me.Label_Niveau_Du_Métier.Name = "Label_Niveau_Du_Métier"
        Me.Label_Niveau_Du_Métier.Size = New System.Drawing.Size(72, 30)
        Me.Label_Niveau_Du_Métier.TabIndex = 1
        Me.Label_Niveau_Du_Métier.Text = "Niveau 100"
        '
        'RedemptionLabel1
        '
        Me.RedemptionLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.RedemptionLabel1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RedemptionLabel1.ForeColor = System.Drawing.Color.White
        Me.RedemptionLabel1.Location = New System.Drawing.Point(122, 69)
        Me.RedemptionLabel1.Name = "RedemptionLabel1"
        Me.RedemptionLabel1.Size = New System.Drawing.Size(72, 23)
        Me.RedemptionLabel1.TabIndex = 2
        Me.RedemptionLabel1.Text = "Expérience"
        '
        'ProgressBar_Expérience
        '
        Me.ProgressBar_Expérience.BackColor = System.Drawing.Color.Transparent
        Me.ProgressBar_Expérience.Location = New System.Drawing.Point(200, 69)
        Me.ProgressBar_Expérience.Maximum = 100
        Me.ProgressBar_Expérience.Name = "ProgressBar_Expérience"
        Me.ProgressBar_Expérience.Size = New System.Drawing.Size(417, 23)
        Me.ProgressBar_Expérience.TabIndex = 3
        Me.ProgressBar_Expérience.Text = "RedemptionProgressBar1"
        Me.ProgressBar_Expérience.Value = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage_Caractéristique)
        Me.TabControl1.Controls.Add(Me.TabPage_Recettes)
        Me.TabControl1.Controls.Add(Me.TabPage_Options)
        Me.TabControl1.Location = New System.Drawing.Point(6, 125)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(611, 513)
        Me.TabControl1.TabIndex = 4
        '
        'TabPage_Caractéristique
        '
        Me.TabPage_Caractéristique.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TabPage_Caractéristique.Controls.Add(Me.TabControl2)
        Me.TabPage_Caractéristique.Controls.Add(Me.TextBox_Définition)
        Me.TabPage_Caractéristique.Controls.Add(Me.Label_Niveau_Arme)
        Me.TabPage_Caractéristique.Controls.Add(Me.Label_Nom_Item_Métier)
        Me.TabPage_Caractéristique.Controls.Add(Me.PictureBox2)
        Me.TabPage_Caractéristique.Controls.Add(Me.RedemptionLabel3)
        Me.TabPage_Caractéristique.Controls.Add(Me.ListView_Inventaire_Affiche_Caractéristique)
        Me.TabPage_Caractéristique.Controls.Add(Me.RedemptionLabel2)
        Me.TabPage_Caractéristique.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Caractéristique.Name = "TabPage_Caractéristique"
        Me.TabPage_Caractéristique.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Caractéristique.Size = New System.Drawing.Size(603, 487)
        Me.TabPage_Caractéristique.TabIndex = 0
        Me.TabPage_Caractéristique.Text = "Caractéristiques"
        '
        'TabPage_Recettes
        '
        Me.TabPage_Recettes.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TabPage_Recettes.Controls.Add(Me.RedemptionLabel4)
        Me.TabPage_Recettes.Controls.Add(Me.CheckBox_1)
        Me.TabPage_Recettes.Controls.Add(Me.CheckBox_2)
        Me.TabPage_Recettes.Controls.Add(Me.CheckBox_8)
        Me.TabPage_Recettes.Controls.Add(Me.CheckBox_3)
        Me.TabPage_Recettes.Controls.Add(Me.FlowLayoutPanel_Recette)
        Me.TabPage_Recettes.Controls.Add(Me.CheckBox_4)
        Me.TabPage_Recettes.Controls.Add(Me.CheckBox_7)
        Me.TabPage_Recettes.Controls.Add(Me.CheckBox_5)
        Me.TabPage_Recettes.Controls.Add(Me.CheckBox_6)
        Me.TabPage_Recettes.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Recettes.Name = "TabPage_Recettes"
        Me.TabPage_Recettes.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Recettes.Size = New System.Drawing.Size(603, 487)
        Me.TabPage_Recettes.TabIndex = 1
        Me.TabPage_Recettes.Text = "Recettes"
        '
        'TabPage_Options
        '
        Me.TabPage_Options.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TabPage_Options.Controls.Add(Me.Label1)
        Me.TabPage_Options.Controls.Add(Me.Button_Mode_Public)
        Me.TabPage_Options.Controls.Add(Me.PictureBox3)
        Me.TabPage_Options.Controls.Add(Me.Label_Mode_Public)
        Me.TabPage_Options.Controls.Add(Me.Button_Sauvegarder)
        Me.TabPage_Options.Controls.Add(Me.NumericUpDown_Nombre_Ingrédient)
        Me.TabPage_Options.Controls.Add(Me.RedemptionLabel6)
        Me.TabPage_Options.Controls.Add(Me.CheckBox_Gratuit)
        Me.TabPage_Options.Controls.Add(Me.CheckBox_Fournit_Ressource)
        Me.TabPage_Options.Controls.Add(Me.CheckBox_Payant)
        Me.TabPage_Options.Controls.Add(Me.RedemptionLabel5)
        Me.TabPage_Options.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Options.Name = "TabPage_Options"
        Me.TabPage_Options.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Options.Size = New System.Drawing.Size(603, 487)
        Me.TabPage_Options.TabIndex = 2
        Me.TabPage_Options.Text = "Options"
        '
        'RedemptionLabel2
        '
        Me.RedemptionLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.RedemptionLabel2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RedemptionLabel2.ForeColor = System.Drawing.Color.White
        Me.RedemptionLabel2.Location = New System.Drawing.Point(22, 3)
        Me.RedemptionLabel2.Name = "RedemptionLabel2"
        Me.RedemptionLabel2.Size = New System.Drawing.Size(581, 29)
        Me.RedemptionLabel2.TabIndex = 2
        Me.RedemptionLabel2.Text = "Compétences"
        '
        'ListView_Inventaire_Affiche_Caractéristique
        '
        Me.ListView_Inventaire_Affiche_Caractéristique.BackColor = System.Drawing.Color.Silver
        Me.ListView_Inventaire_Affiche_Caractéristique.FullRowSelect = True
        Me.ListView_Inventaire_Affiche_Caractéristique.GridLines = True
        Me.ListView_Inventaire_Affiche_Caractéristique.Location = New System.Drawing.Point(6, 35)
        Me.ListView_Inventaire_Affiche_Caractéristique.Name = "ListView_Inventaire_Affiche_Caractéristique"
        Me.ListView_Inventaire_Affiche_Caractéristique.Size = New System.Drawing.Size(591, 152)
        Me.ListView_Inventaire_Affiche_Caractéristique.TabIndex = 3
        Me.ListView_Inventaire_Affiche_Caractéristique.UseCompatibleStateImageBehavior = False
        Me.ListView_Inventaire_Affiche_Caractéristique.View = System.Windows.Forms.View.List
        '
        'RedemptionLabel3
        '
        Me.RedemptionLabel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.RedemptionLabel3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RedemptionLabel3.ForeColor = System.Drawing.Color.White
        Me.RedemptionLabel3.Location = New System.Drawing.Point(22, 193)
        Me.RedemptionLabel3.Name = "RedemptionLabel3"
        Me.RedemptionLabel3.Size = New System.Drawing.Size(581, 29)
        Me.RedemptionLabel3.TabIndex = 4
        Me.RedemptionLabel3.Text = "Outil"
        '
        'Label_Nom_Item_Métier
        '
        Me.Label_Nom_Item_Métier.BackColor = System.Drawing.Color.DimGray
        Me.Label_Nom_Item_Métier.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Nom_Item_Métier.ForeColor = System.Drawing.Color.White
        Me.Label_Nom_Item_Métier.Location = New System.Drawing.Point(6, 223)
        Me.Label_Nom_Item_Métier.Name = "Label_Nom_Item_Métier"
        Me.Label_Nom_Item_Métier.Size = New System.Drawing.Size(591, 29)
        Me.Label_Nom_Item_Métier.TabIndex = 6
        Me.Label_Nom_Item_Métier.Text = "Nom de l'item pour le métier"
        '
        'Label_Niveau_Arme
        '
        Me.Label_Niveau_Arme.BackColor = System.Drawing.Color.DimGray
        Me.Label_Niveau_Arme.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Niveau_Arme.ForeColor = System.Drawing.Color.White
        Me.Label_Niveau_Arme.Location = New System.Drawing.Point(496, 223)
        Me.Label_Niveau_Arme.Name = "Label_Niveau_Arme"
        Me.Label_Niveau_Arme.Size = New System.Drawing.Size(96, 29)
        Me.Label_Niveau_Arme.TabIndex = 7
        Me.Label_Niveau_Arme.Text = "Niveau 100"
        '
        'TextBox_Définition
        '
        Me.TextBox_Définition.BackColor = System.Drawing.Color.Transparent
        Me.TextBox_Définition.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TextBox_Définition.ForeColor = System.Drawing.Color.White
        Me.TextBox_Définition.Location = New System.Drawing.Point(6, 414)
        Me.TextBox_Définition.MaxLength = 32767
        Me.TextBox_Définition.MultiLine = True
        Me.TextBox_Définition.Name = "TextBox_Définition"
        Me.TextBox_Définition.Size = New System.Drawing.Size(591, 67)
        Me.TextBox_Définition.TabIndex = 8
        Me.TextBox_Définition.Text = "Définition de l'item"
        Me.TextBox_Définition.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.TextBox_Définition.UseSystemPasswordChar = False
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage_Effets)
        Me.TabControl2.Controls.Add(Me.TabPage_Conditions)
        Me.TabControl2.Controls.Add(Me.TabPage_Caractéristiques)
        Me.TabControl2.Location = New System.Drawing.Point(162, 258)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(435, 150)
        Me.TabControl2.TabIndex = 9
        '
        'TabPage_Effets
        '
        Me.TabPage_Effets.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TabPage_Effets.Controls.Add(Me.ListView1)
        Me.TabPage_Effets.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Effets.Name = "TabPage_Effets"
        Me.TabPage_Effets.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Effets.Size = New System.Drawing.Size(427, 124)
        Me.TabPage_Effets.TabIndex = 0
        Me.TabPage_Effets.Text = "Effets"
        '
        'TabPage_Conditions
        '
        Me.TabPage_Conditions.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TabPage_Conditions.Controls.Add(Me.ListView2)
        Me.TabPage_Conditions.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Conditions.Name = "TabPage_Conditions"
        Me.TabPage_Conditions.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Conditions.Size = New System.Drawing.Size(427, 124)
        Me.TabPage_Conditions.TabIndex = 1
        Me.TabPage_Conditions.Text = "Conditions"
        '
        'TabPage_Caractéristiques
        '
        Me.TabPage_Caractéristiques.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TabPage_Caractéristiques.Controls.Add(Me.ListView3)
        Me.TabPage_Caractéristiques.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Caractéristiques.Name = "TabPage_Caractéristiques"
        Me.TabPage_Caractéristiques.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Caractéristiques.Size = New System.Drawing.Size(427, 124)
        Me.TabPage_Caractéristiques.TabIndex = 2
        Me.TabPage_Caractéristiques.Text = "Caractéristiques"
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.Color.Silver
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(6, 6)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(415, 112)
        Me.ListView1.TabIndex = 4
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.List
        '
        'ListView2
        '
        Me.ListView2.BackColor = System.Drawing.Color.Silver
        Me.ListView2.FullRowSelect = True
        Me.ListView2.GridLines = True
        Me.ListView2.Location = New System.Drawing.Point(6, 6)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(415, 112)
        Me.ListView2.TabIndex = 5
        Me.ListView2.UseCompatibleStateImageBehavior = False
        Me.ListView2.View = System.Windows.Forms.View.List
        '
        'ListView3
        '
        Me.ListView3.BackColor = System.Drawing.Color.Silver
        Me.ListView3.FullRowSelect = True
        Me.ListView3.GridLines = True
        Me.ListView3.Location = New System.Drawing.Point(6, 6)
        Me.ListView3.Name = "ListView3"
        Me.ListView3.Size = New System.Drawing.Size(415, 112)
        Me.ListView3.TabIndex = 5
        Me.ListView3.UseCompatibleStateImageBehavior = False
        Me.ListView3.View = System.Windows.Forms.View.List
        '
        'FlowLayoutPanel_Recette
        '
        Me.FlowLayoutPanel_Recette.AutoScroll = True
        Me.FlowLayoutPanel_Recette.Location = New System.Drawing.Point(6, 32)
        Me.FlowLayoutPanel_Recette.Name = "FlowLayoutPanel_Recette"
        Me.FlowLayoutPanel_Recette.Size = New System.Drawing.Size(591, 449)
        Me.FlowLayoutPanel_Recette.TabIndex = 0
        '
        'CheckBox_8
        '
        Me.CheckBox_8.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox_8.Checked = False
        Me.CheckBox_8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CheckBox_8.ForeColor = System.Drawing.Color.White
        Me.CheckBox_8.Location = New System.Drawing.Point(577, 6)
        Me.CheckBox_8.Name = "CheckBox_8"
        Me.CheckBox_8.Size = New System.Drawing.Size(20, 19)
        Me.CheckBox_8.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.CheckBox_8, "Affiche/Cache les recettes à 8 ingrédient(s)")
        '
        'CheckBox_1
        '
        Me.CheckBox_1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox_1.Checked = False
        Me.CheckBox_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CheckBox_1.ForeColor = System.Drawing.Color.White
        Me.CheckBox_1.Location = New System.Drawing.Point(395, 6)
        Me.CheckBox_1.Name = "CheckBox_1"
        Me.CheckBox_1.Size = New System.Drawing.Size(20, 19)
        Me.CheckBox_1.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.CheckBox_1, "Affiche/Cache les recettes à 1 ingrédient(s)")
        '
        'CheckBox_2
        '
        Me.CheckBox_2.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox_2.Checked = False
        Me.CheckBox_2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CheckBox_2.ForeColor = System.Drawing.Color.White
        Me.CheckBox_2.Location = New System.Drawing.Point(421, 6)
        Me.CheckBox_2.Name = "CheckBox_2"
        Me.CheckBox_2.Size = New System.Drawing.Size(20, 19)
        Me.CheckBox_2.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.CheckBox_2, "Affiche/Cache les recettes à 2 ingrédient(s)")
        '
        'CheckBox_3
        '
        Me.CheckBox_3.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox_3.Checked = False
        Me.CheckBox_3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CheckBox_3.ForeColor = System.Drawing.Color.White
        Me.CheckBox_3.Location = New System.Drawing.Point(447, 6)
        Me.CheckBox_3.Name = "CheckBox_3"
        Me.CheckBox_3.Size = New System.Drawing.Size(20, 19)
        Me.CheckBox_3.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.CheckBox_3, "Affiche/Cache les recettes à 3 ingrédient(s)")
        '
        'CheckBox_4
        '
        Me.CheckBox_4.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox_4.Checked = False
        Me.CheckBox_4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CheckBox_4.ForeColor = System.Drawing.Color.White
        Me.CheckBox_4.Location = New System.Drawing.Point(473, 6)
        Me.CheckBox_4.Name = "CheckBox_4"
        Me.CheckBox_4.Size = New System.Drawing.Size(20, 19)
        Me.CheckBox_4.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.CheckBox_4, "Affiche/Cache les recettes à 4 ingrédient(s)")
        '
        'CheckBox_5
        '
        Me.CheckBox_5.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox_5.Checked = False
        Me.CheckBox_5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CheckBox_5.ForeColor = System.Drawing.Color.White
        Me.CheckBox_5.Location = New System.Drawing.Point(499, 6)
        Me.CheckBox_5.Name = "CheckBox_5"
        Me.CheckBox_5.Size = New System.Drawing.Size(20, 19)
        Me.CheckBox_5.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.CheckBox_5, "Affiche/Cache les recettes à 5 ingrédient(s)")
        '
        'CheckBox_6
        '
        Me.CheckBox_6.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox_6.Checked = False
        Me.CheckBox_6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CheckBox_6.ForeColor = System.Drawing.Color.White
        Me.CheckBox_6.Location = New System.Drawing.Point(525, 6)
        Me.CheckBox_6.Name = "CheckBox_6"
        Me.CheckBox_6.Size = New System.Drawing.Size(20, 19)
        Me.CheckBox_6.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.CheckBox_6, "Affiche/Cache les recettes à 6 ingrédient(s)")
        '
        'CheckBox_7
        '
        Me.CheckBox_7.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox_7.Checked = False
        Me.CheckBox_7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CheckBox_7.ForeColor = System.Drawing.Color.White
        Me.CheckBox_7.Location = New System.Drawing.Point(551, 6)
        Me.CheckBox_7.Name = "CheckBox_7"
        Me.CheckBox_7.Size = New System.Drawing.Size(20, 19)
        Me.CheckBox_7.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.CheckBox_7, "Affiche/Cache les recettes à 7 ingrédient(s)")
        '
        'RedemptionLabel4
        '
        Me.RedemptionLabel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.RedemptionLabel4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RedemptionLabel4.ForeColor = System.Drawing.Color.White
        Me.RedemptionLabel4.Location = New System.Drawing.Point(6, 3)
        Me.RedemptionLabel4.Name = "RedemptionLabel4"
        Me.RedemptionLabel4.Size = New System.Drawing.Size(377, 26)
        Me.RedemptionLabel4.TabIndex = 8
        Me.RedemptionLabel4.Text = "Recettes                                                                         " &
    "                    Filtre"
        '
        'RedemptionLabel5
        '
        Me.RedemptionLabel5.BackColor = System.Drawing.Color.DimGray
        Me.RedemptionLabel5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RedemptionLabel5.ForeColor = System.Drawing.Color.White
        Me.RedemptionLabel5.Location = New System.Drawing.Point(6, 6)
        Me.RedemptionLabel5.Name = "RedemptionLabel5"
        Me.RedemptionLabel5.Size = New System.Drawing.Size(591, 29)
        Me.RedemptionLabel5.TabIndex = 7
        Me.RedemptionLabel5.Text = "Option de référencement"
        '
        'CheckBox_Payant
        '
        Me.CheckBox_Payant.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox_Payant.Checked = False
        Me.CheckBox_Payant.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CheckBox_Payant.ForeColor = System.Drawing.Color.White
        Me.CheckBox_Payant.Location = New System.Drawing.Point(17, 41)
        Me.CheckBox_Payant.Name = "CheckBox_Payant"
        Me.CheckBox_Payant.Size = New System.Drawing.Size(66, 19)
        Me.CheckBox_Payant.TabIndex = 8
        Me.CheckBox_Payant.Text = "Payant"
        '
        'CheckBox_Fournit_Ressource
        '
        Me.CheckBox_Fournit_Ressource.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox_Fournit_Ressource.Checked = False
        Me.CheckBox_Fournit_Ressource.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CheckBox_Fournit_Ressource.ForeColor = System.Drawing.Color.White
        Me.CheckBox_Fournit_Ressource.Location = New System.Drawing.Point(17, 104)
        Me.CheckBox_Fournit_Ressource.Name = "CheckBox_Fournit_Ressource"
        Me.CheckBox_Fournit_Ressource.Size = New System.Drawing.Size(182, 19)
        Me.CheckBox_Fournit_Ressource.TabIndex = 9
        Me.CheckBox_Fournit_Ressource.Text = "Ne fournit aucune ressource"
        '
        'CheckBox_Gratuit
        '
        Me.CheckBox_Gratuit.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox_Gratuit.Checked = False
        Me.CheckBox_Gratuit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CheckBox_Gratuit.ForeColor = System.Drawing.Color.White
        Me.CheckBox_Gratuit.Location = New System.Drawing.Point(28, 71)
        Me.CheckBox_Gratuit.Name = "CheckBox_Gratuit"
        Me.CheckBox_Gratuit.Size = New System.Drawing.Size(122, 19)
        Me.CheckBox_Gratuit.TabIndex = 10
        Me.CheckBox_Gratuit.Text = "Gratuit sur échec"
        '
        'RedemptionLabel6
        '
        Me.RedemptionLabel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.RedemptionLabel6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RedemptionLabel6.ForeColor = System.Drawing.Color.White
        Me.RedemptionLabel6.Location = New System.Drawing.Point(6, 142)
        Me.RedemptionLabel6.Name = "RedemptionLabel6"
        Me.RedemptionLabel6.Size = New System.Drawing.Size(280, 23)
        Me.RedemptionLabel6.TabIndex = 11
        Me.RedemptionLabel6.Text = "Nombre minimum d'ingrédients                    Cases"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Linabot.My.Resources.Resources.Question
        Me.PictureBox1.Location = New System.Drawing.Point(16, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 100)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Linabot.My.Resources.Resources.Question
        Me.PictureBox2.Location = New System.Drawing.Point(6, 258)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(150, 150)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 5
        Me.PictureBox2.TabStop = False
        '
        'NumericUpDown_Nombre_Ingrédient
        '
        Me.NumericUpDown_Nombre_Ingrédient.BackColor = System.Drawing.Color.Transparent
        Me.NumericUpDown_Nombre_Ingrédient.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.NumericUpDown_Nombre_Ingrédient.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.NumericUpDown_Nombre_Ingrédient.ForeColor = System.Drawing.Color.White
        Me.NumericUpDown_Nombre_Ingrédient.Location = New System.Drawing.Point(190, 141)
        Me.NumericUpDown_Nombre_Ingrédient.Maximum = CType(8, Long)
        Me.NumericUpDown_Nombre_Ingrédient.Minimum = CType(2, Long)
        Me.NumericUpDown_Nombre_Ingrédient.Name = "NumericUpDown_Nombre_Ingrédient"
        Me.NumericUpDown_Nombre_Ingrédient.Size = New System.Drawing.Size(43, 26)
        Me.NumericUpDown_Nombre_Ingrédient.TabIndex = 12
        Me.NumericUpDown_Nombre_Ingrédient.Text = "RedemptionNumericUpDown1"
        Me.NumericUpDown_Nombre_Ingrédient.Value = CType(2, Long)
        '
        'Button_Sauvegarder
        '
        Me.Button_Sauvegarder.BackColor = System.Drawing.Color.Transparent
        Me.Button_Sauvegarder.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Button_Sauvegarder.Location = New System.Drawing.Point(207, 190)
        Me.Button_Sauvegarder.Name = "Button_Sauvegarder"
        Me.Button_Sauvegarder.Size = New System.Drawing.Size(182, 32)
        Me.Button_Sauvegarder.TabIndex = 13
        Me.Button_Sauvegarder.Text = "Sauvegarder"
        Me.Button_Sauvegarder.TextAlign = Linabot.RedemptionButton.HorizontalAlignment.Center
        '
        'Label_Mode_Public
        '
        Me.Label_Mode_Public.BackColor = System.Drawing.Color.DimGray
        Me.Label_Mode_Public.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Mode_Public.ForeColor = System.Drawing.Color.White
        Me.Label_Mode_Public.Location = New System.Drawing.Point(6, 238)
        Me.Label_Mode_Public.Name = "Label_Mode_Public"
        Me.Label_Mode_Public.Size = New System.Drawing.Size(591, 29)
        Me.Label_Mode_Public.TabIndex = 14
        Me.Label_Mode_Public.Text = "Mode public (Inactif)"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.DimGray
        Me.PictureBox3.Image = Global.Linabot.My.Resources.Resources.moins
        Me.PictureBox3.Location = New System.Drawing.Point(563, 238)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(34, 29)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 15
        Me.PictureBox3.TabStop = False
        '
        'Button_Mode_Public
        '
        Me.Button_Mode_Public.BackColor = System.Drawing.Color.Transparent
        Me.Button_Mode_Public.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Button_Mode_Public.Location = New System.Drawing.Point(207, 449)
        Me.Button_Mode_Public.Name = "Button_Mode_Public"
        Me.Button_Mode_Public.Size = New System.Drawing.Size(182, 32)
        Me.Button_Mode_Public.TabIndex = 16
        Me.Button_Mode_Public.Text = "Activer"
        Me.Button_Mode_Public.TextAlign = Linabot.RedemptionButton.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.Button_Mode_Public, "Activer le ""Mode public""")
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 279)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(591, 167)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'Métiers_Control
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Métiers_Control"
        Me.Size = New System.Drawing.Size(630, 650)
        Me.GroupBox1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage_Caractéristique.ResumeLayout(False)
        Me.TabPage_Recettes.ResumeLayout(False)
        Me.TabPage_Options.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage_Effets.ResumeLayout(False)
        Me.TabPage_Conditions.ResumeLayout(False)
        Me.TabPage_Caractéristiques.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label_Nom_Du_Métier As RedemptionLabel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage_Caractéristique As TabPage
    Friend WithEvents TabPage_Recettes As TabPage
    Friend WithEvents TabPage_Options As TabPage
    Friend WithEvents ProgressBar_Expérience As RedemptionProgressBar
    Friend WithEvents RedemptionLabel1 As RedemptionLabel
    Friend WithEvents Label_Niveau_Du_Métier As RedemptionLabel
    Friend WithEvents RedemptionLabel2 As RedemptionLabel
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents TabPage_Effets As TabPage
    Friend WithEvents ListView1 As ListView
    Friend WithEvents TabPage_Conditions As TabPage
    Friend WithEvents ListView2 As ListView
    Friend WithEvents TabPage_Caractéristiques As TabPage
    Friend WithEvents ListView3 As ListView
    Friend WithEvents TextBox_Définition As RedemptionTextBox
    Friend WithEvents Label_Niveau_Arme As RedemptionLabel
    Friend WithEvents Label_Nom_Item_Métier As RedemptionLabel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents RedemptionLabel3 As RedemptionLabel
    Friend WithEvents ListView_Inventaire_Affiche_Caractéristique As ListView
    Friend WithEvents FlowLayoutPanel_Recette As FlowLayoutPanel
    Friend WithEvents RedemptionLabel4 As RedemptionLabel
    Friend WithEvents CheckBox_1 As RedemptionCheckBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents CheckBox_2 As RedemptionCheckBox
    Friend WithEvents CheckBox_8 As RedemptionCheckBox
    Friend WithEvents CheckBox_3 As RedemptionCheckBox
    Friend WithEvents CheckBox_4 As RedemptionCheckBox
    Friend WithEvents CheckBox_7 As RedemptionCheckBox
    Friend WithEvents CheckBox_5 As RedemptionCheckBox
    Friend WithEvents CheckBox_6 As RedemptionCheckBox
    Friend WithEvents RedemptionLabel6 As RedemptionLabel
    Friend WithEvents CheckBox_Gratuit As RedemptionCheckBox
    Friend WithEvents CheckBox_Fournit_Ressource As RedemptionCheckBox
    Friend WithEvents CheckBox_Payant As RedemptionCheckBox
    Friend WithEvents RedemptionLabel5 As RedemptionLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents Button_Mode_Public As RedemptionButton
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Label_Mode_Public As RedemptionLabel
    Friend WithEvents Button_Sauvegarder As RedemptionButton
    Friend WithEvents NumericUpDown_Nombre_Ingrédient As RedemptionNumericUpDown
End Class
