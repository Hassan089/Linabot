Public Class Sorts_Control : Inherits UserControl

    Friend WithEvents Label_PA As Label
    Friend WithEvents Label_Nom As Label
    Friend WithEvents Label_Niveau As Label
    Friend WithEvents Label_PO As Label
    Friend WithEvents Label_Coût As Label
    Friend WithEvents Button_Up As Button
    Friend WithEvents CheckBox_Automatique As CheckBox
    Friend WithEvents PictureBox_Sort As PictureBox

    Sub New(ByVal Index As Integer, ByVal ID_Sort As Integer, ByVal Niveau As Integer)

        Me.PictureBox_Sort = New System.Windows.Forms.PictureBox()
        Me.Label_PA = New System.Windows.Forms.Label()
        Me.Label_Nom = New System.Windows.Forms.Label()
        Me.Label_Niveau = New System.Windows.Forms.Label()
        Me.Label_PO = New System.Windows.Forms.Label()
        Me.Label_Coût = New System.Windows.Forms.Label()
        Me.Button_Up = New System.Windows.Forms.Button()
        Me.CheckBox_Automatique = New System.Windows.Forms.CheckBox()
        CType(Me.PictureBox_Sort, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox_Sort
        '
        If IO.File.Exists(Application.StartupPath & "\Image\Sorts/" & ID_Sort & ".png") Then
            Me.PictureBox_Sort.Load(Application.StartupPath & "\Image\Sorts/" & ID_Sort & ".png")
        Else
            Me.PictureBox_Sort.Image = My.Resources.Question
        End If
        Me.PictureBox_Sort.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox_Sort.Name = ID_Sort '"PictureBox_Sort"
        Me.PictureBox_Sort.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox_Sort.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox_Sort.TabIndex = 0
        Me.PictureBox_Sort.TabStop = False
        AddHandler PictureBox_Sort.Click, Sub() Sorts_Information_Sort_Séléctionné(Index, ID_Sort, Niveau)
        AddHandler PictureBox_Sort.MouseMove, Sub(Sender As Object, E As MouseEventArgs)
                                                  MyBase.BackColor = Color.FromArgb(43, 44, 48)
                                              End Sub

        AddHandler PictureBox_Sort.MouseLeave, Sub(Sender As Object, E As EventArgs)
                                                   MyBase.BackColor = Color.DarkGray
                                               End Sub
        '
        'Label_PA
        '
        Me.Label_PA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_PA.Location = New System.Drawing.Point(59, 32)
        Me.Label_PA.Name = "Label_PA"
        Me.Label_PA.Size = New System.Drawing.Size(39, 25)
        Me.Label_PA.TabIndex = 2
        Me.Label_PA.Text = Dico_Sorts(ID_Sort)(Niveau).GetValue(4) & " PA"
        Me.Label_PA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        AddHandler Label_PA.Click, Sub() Sorts_Information_Sort_Séléctionné(Index, ID_Sort, Niveau)
        AddHandler Label_PA.MouseMove, Sub(Sender As Object, E As MouseEventArgs)
                                           MyBase.BackColor = Color.FromArgb(43, 44, 48)
                                       End Sub

        AddHandler Label_PA.MouseLeave, Sub(Sender As Object, E As EventArgs)
                                            MyBase.BackColor = Color.DarkGray
                                        End Sub
        '
        'Label_Nom
        '
        Me.Label_Nom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Nom.Location = New System.Drawing.Point(59, 3)
        Me.Label_Nom.Name = "Label_Nom"
        Me.Label_Nom.Size = New System.Drawing.Size(322, 27)
        Me.Label_Nom.TabIndex = 3
        Me.Label_Nom.Text = Dico_Sorts(ID_Sort)(Niveau).GetValue(2)
        Me.Label_Nom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        AddHandler Label_Nom.Click, Sub() Sorts_Information_Sort_Séléctionné(Index, ID_Sort, Niveau)
        AddHandler Label_Nom.MouseMove, Sub(Sender As Object, E As MouseEventArgs)
                                            MyBase.BackColor = Color.FromArgb(43, 44, 48)
                                        End Sub

        AddHandler Label_Nom.MouseLeave, Sub(Sender As Object, E As EventArgs)
                                             MyBase.BackColor = Color.DarkGray
                                         End Sub
        '
        'Label_Niveau
        '
        Me.Label_Niveau.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Niveau.Location = New System.Drawing.Point(412, 3)
        Me.Label_Niveau.Name = "Label_Niveau"
        Me.Label_Niveau.Size = New System.Drawing.Size(64, 27)
        Me.Label_Niveau.TabIndex = 4
        Me.Label_Niveau.Text = "Niveau " & Niveau
        Me.Label_Niveau.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        AddHandler Label_Niveau.Click, Sub() Sorts_Information_Sort_Séléctionné(Index, ID_Sort, Niveau)
        AddHandler Label_Niveau.MouseMove, Sub(Sender As Object, E As MouseEventArgs)
                                               MyBase.BackColor = Color.FromArgb(43, 44, 48)
                                           End Sub

        AddHandler Label_Niveau.MouseLeave, Sub(Sender As Object, E As EventArgs)
                                                MyBase.BackColor = Color.DarkGray
                                            End Sub
        '
        'Label_PO
        '
        Me.Label_PO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_PO.Location = New System.Drawing.Point(125, 30)
        Me.Label_PO.Name = "Label_PO"
        Me.Label_PO.Size = New System.Drawing.Size(63, 24)
        Me.Label_PO.TabIndex = 5
        Me.Label_PO.Text = Dico_Sorts(ID_Sort)(Niveau).GetValue(3) & " PO"
        Me.Label_PO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        AddHandler Label_PO.Click, Sub() Sorts_Information_Sort_Séléctionné(Index, ID_Sort, Niveau)
        AddHandler Label_PO.MouseMove, Sub(Sender As Object, E As MouseEventArgs)
                                           MyBase.BackColor = Color.FromArgb(43, 44, 48)
                                       End Sub

        AddHandler Label_PO.MouseLeave, Sub(Sender As Object, E As EventArgs)
                                            MyBase.BackColor = Color.DarkGray
                                        End Sub
        '
        'Label_Coût
        '
        Me.Label_Coût.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Coût.Location = New System.Drawing.Point(292, 30)
        Me.Label_Coût.Name = "Label_Coût"
        Me.Label_Coût.Size = New System.Drawing.Size(161, 27)
        Me.Label_Coût.TabIndex = 6
        Me.Label_Coût.Text = "Coût du niveau suivant : " & Niveau
        Me.Label_Coût.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        AddHandler Label_Coût.Click, Sub() Sorts_Information_Sort_Séléctionné(Index, ID_Sort, Niveau)
        Label_Coût.Visible = If(Niveau < 6, True, False)
        AddHandler Label_Coût.MouseMove, Sub(Sender As Object, E As MouseEventArgs)
                                             MyBase.BackColor = Color.FromArgb(43, 44, 48)
                                         End Sub

        AddHandler Label_Coût.MouseLeave, Sub(Sender As Object, E As EventArgs)
                                              MyBase.BackColor = Color.DarkGray
                                          End Sub
        '
        'Button_Up
        '
        Me.Button_Up.BackgroundImage = Global.Linabot.My.Resources.Resources.plus
        Me.Button_Up.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button_Up.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button_Up.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Up.ForeColor = System.Drawing.Color.White
        Me.Button_Up.Location = New System.Drawing.Point(454, 32)
        Me.Button_Up.Name = "SM" & ID_Sort
        Me.Button_Up.Size = New System.Drawing.Size(22, 22)
        Me.Button_Up.TabIndex = 356
        Me.Button_Up.UseVisualStyleBackColor = True
        Button_Up.Visible = If(Niveau < 6, True, False)
        '
        'CheckBox_Automatique
        '
        Me.CheckBox_Automatique.AutoSize = True
        Me.CheckBox_Automatique.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox_Automatique.Location = New System.Drawing.Point(211, 33)
        Me.CheckBox_Automatique.Name = "CheckBox_Automatique"
        Me.CheckBox_Automatique.Size = New System.Drawing.Size(75, 20)
        Me.CheckBox_Automatique.TabIndex = 357
        Me.CheckBox_Automatique.Text = "Up Auto"
        Me.CheckBox_Automatique.UseVisualStyleBackColor = True
        AddHandler CheckBox_Automatique.MouseMove, Sub(Sender As Object, E As MouseEventArgs)
                                                       MyBase.BackColor = Color.FromArgb(43, 44, 48)
                                                   End Sub

        AddHandler CheckBox_Automatique.MouseLeave, Sub(Sender As Object, E As EventArgs)
                                                        MyBase.BackColor = Color.DarkGray
                                                    End Sub
        '
        'Sorts_Control
        '
        Me.BackColor = System.Drawing.Color.DarkGray
        Me.Controls.Add(Me.CheckBox_Automatique)
        Me.Controls.Add(Me.Button_Up)
        Me.Controls.Add(Me.Label_Coût)
        Me.Controls.Add(Me.Label_PO)
        Me.Controls.Add(Me.Label_Niveau)
        Me.Controls.Add(Me.Label_Nom)
        Me.Controls.Add(Me.Label_PA)
        Me.Controls.Add(Me.PictureBox_Sort)
        Me.Name = "Sorts_Control"
        Me.Size = New System.Drawing.Size(479, 57)
        CType(Me.PictureBox_Sort, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        AddHandler Me.Click, Sub() Sorts_Information_Sort_Séléctionné(Index, ID_Sort, Niveau)
        AddHandler MouseMove, Sub(Sender As Object, E As MouseEventArgs)
                                  BackColor = Color.FromArgb(43, 44, 48)
                              End Sub

        AddHandler MouseLeave, Sub(Sender As Object, E As EventArgs)
                                   BackColor = Color.DarkGray
                               End Sub
    End Sub

    Private Sub InitializeComponent()
        Me.PictureBox_Sort = New System.Windows.Forms.PictureBox()
        Me.Label_PA = New System.Windows.Forms.Label()
        Me.Label_Nom = New System.Windows.Forms.Label()
        Me.Label_Niveau = New System.Windows.Forms.Label()
        Me.Label_PO = New System.Windows.Forms.Label()
        Me.Label_Coût = New System.Windows.Forms.Label()
        Me.Button_Up = New System.Windows.Forms.Button()
        Me.CheckBox_Automatique = New System.Windows.Forms.CheckBox()
        CType(Me.PictureBox_Sort, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox_Sort
        '
        Me.PictureBox_Sort.Image = Global.Linabot.My.Resources.Resources.Question
        Me.PictureBox_Sort.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox_Sort.Name = "PictureBox_Sort"
        Me.PictureBox_Sort.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox_Sort.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox_Sort.TabIndex = 0
        Me.PictureBox_Sort.TabStop = False
        '
        'Label_PA
        '
        Me.Label_PA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_PA.Location = New System.Drawing.Point(59, 32)
        Me.Label_PA.Name = "Label_PA"
        Me.Label_PA.Size = New System.Drawing.Size(39, 25)
        Me.Label_PA.TabIndex = 2
        Me.Label_PA.Text = "8 PA"
        Me.Label_PA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label_Nom
        '
        Me.Label_Nom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Nom.Location = New System.Drawing.Point(59, 3)
        Me.Label_Nom.Name = "Label_Nom"
        Me.Label_Nom.Size = New System.Drawing.Size(322, 27)
        Me.Label_Nom.TabIndex = 3
        Me.Label_Nom.Text = "Flèche d'immobilisation"
        Me.Label_Nom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label_Niveau
        '
        Me.Label_Niveau.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Niveau.Location = New System.Drawing.Point(412, 3)
        Me.Label_Niveau.Name = "Label_Niveau"
        Me.Label_Niveau.Size = New System.Drawing.Size(64, 27)
        Me.Label_Niveau.TabIndex = 4
        Me.Label_Niveau.Text = "Niveau 0"
        Me.Label_Niveau.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label_PO
        '
        Me.Label_PO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_PO.Location = New System.Drawing.Point(117, 30)
        Me.Label_PO.Name = "Label_PO"
        Me.Label_PO.Size = New System.Drawing.Size(63, 24)
        Me.Label_PO.TabIndex = 5
        Me.Label_PO.Text = "99-99 PO"
        Me.Label_PO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label_Coût
        '
        Me.Label_Coût.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Coût.Location = New System.Drawing.Point(292, 30)
        Me.Label_Coût.Name = "Label_Coût"
        Me.Label_Coût.Size = New System.Drawing.Size(161, 27)
        Me.Label_Coût.TabIndex = 6
        Me.Label_Coût.Text = "Coût du niveau suivant : 0"
        Me.Label_Coût.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button_Up
        '
        Me.Button_Up.BackgroundImage = Global.Linabot.My.Resources.Resources.plus
        Me.Button_Up.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button_Up.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button_Up.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Up.ForeColor = System.Drawing.Color.White
        Me.Button_Up.Location = New System.Drawing.Point(454, 32)
        Me.Button_Up.Name = "Button_Up"
        Me.Button_Up.Size = New System.Drawing.Size(22, 22)
        Me.Button_Up.TabIndex = 356
        Me.Button_Up.UseVisualStyleBackColor = True
        '
        'CheckBox_Automatique
        '
        Me.CheckBox_Automatique.AutoSize = True
        Me.CheckBox_Automatique.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox_Automatique.Location = New System.Drawing.Point(211, 32)
        Me.CheckBox_Automatique.Name = "CheckBox_Automatique"
        Me.CheckBox_Automatique.Size = New System.Drawing.Size(75, 20)
        Me.CheckBox_Automatique.TabIndex = 357
        Me.CheckBox_Automatique.Text = "Up Auto"
        Me.CheckBox_Automatique.UseVisualStyleBackColor = True
        '
        'Sorts_Control
        '
        Me.BackColor = System.Drawing.Color.Gray
        Me.Controls.Add(Me.CheckBox_Automatique)
        Me.Controls.Add(Me.Button_Up)
        Me.Controls.Add(Me.Label_Coût)
        Me.Controls.Add(Me.Label_PO)
        Me.Controls.Add(Me.Label_Niveau)
        Me.Controls.Add(Me.Label_Nom)
        Me.Controls.Add(Me.Label_PA)
        Me.Controls.Add(Me.PictureBox_Sort)
        Me.Name = "Sorts_Control"
        Me.Size = New System.Drawing.Size(479, 57)
        CType(Me.PictureBox_Sort, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
End Class
