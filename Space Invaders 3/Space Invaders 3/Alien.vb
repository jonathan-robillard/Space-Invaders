Public Class Alien
    Inherits Objet ' classe qui hérite de Objet

    Dim arme As Arme

    Public Sub New(image As Image, arme As Arme)
        MyBase.New(image)
        Me.arme = arme

        'FrmJeu.Controls.Add(arme)
        'arme.Hide()

    End Sub

    Public Sub New()

    End Sub

    'Public Sub tirer(timer As Timer) ' Methodes qui devaient servir au aliens pour tirer sur le vaisseau, cette fonctionnalité n'est pas finie
    '    timer.Start()
    'End Sub

    'Public Sub deplacertirBas(val As Integer)
    '    arme.deplacerBas(val)
    'End Sub

    'Public Sub initialiserTir()
    '    arme.initialiser(Me)
    'End Sub
End Class

Public Class Aliens
    Inherits FlowLayoutPanel ' Pour représenter un groupe d'aliens, on utilise un FlowLayoutPanel qui nous permet de ranger facilement et d'aligner les aliens

    Dim nbAliens As Integer ' Le nombre d'aliens présents dans le flowLayoutPanel
    Dim aliens(300) As Alien ' Un tableau d'aliens
    Dim aliensEnVie(300) As Integer ' Un tableau de integer qui nous permet de savoir si un alien est en vie ou non. La valeur de la case du tableau vaut 1 si il est vivant et 0 si non.
    Dim nbAliensEnVie As Integer ' Integer qui nous permet de savoir combien il reste d'aliens en vie

    Public Sub New(alien As Alien, nbAliensLarge As Integer, nbAliensHaut As Integer) ' le constructeur prends en parametres un alien qui sert de "modèle" à tous les aliens du groupe
        MyBase.New()                                                                  '  On indique également le nombre d'aliens que l'on veut en hauteur et en largeur

        Me.nbAliens = nbAliensLarge * nbAliensHaut  ' Le nombre d'aliens total est donc le résultat du nombre d'aliens en hauteurs * le nombre d'aliens en largeur
        nbAliensEnVie = nbAliensLarge * nbAliensHaut

        For i = 0 To nbAliens - 1 ' Chaque alien du tableau (pas jusqu'au max mais jusqu'au nb d'aliens) prends la forme de l'alien "modèle"
            aliens(i) = New Alien(Image.FromFile("../../Images/alien.jpg"), New Arme())
            Me.Controls.Add(aliens(i)) ' On ajoute chaque alien au FlowLayoutPanel
            aliensEnVie(i) = 1 ' on indique que l'alien est en vie
        Next

        Me.Width = (nbAliensLarge * aliens(0).Width) + ((nbAliensLarge) * aliens(0).Margin.Left) * 2
        'On règle la largeur du FlowLayoutPanel qui est égale au nombre d'aliens * la largeur d'un alien + la marge multipliée par 2 de chaque alien
        Me.Height = (nbAliensHaut * aliens(0).Height) + ((nbAliensHaut) * aliens(0).Margin.Top) * 2
        ' On fait la même chose pour la hauteur du FlowLAyoutPanel mais avec les hauteurs des aliens
        Me.Location = New Point((FrmJeu.Width - Me.Width) / 2, 50) ' On définit la position du FlowLayoutPanel, on le met au centre de la fenetre et 50 px en dessous de la limite haute de celle ci
    End Sub


    Public Sub deplacerGauche(val As Integer) ' Création des méthodes por gérer le déplacement du FlowLayoutPanel
        Me.Location = New Point(Me.Location.X - val, Me.Location.Y)
    End Sub

    Public Sub deplacerDroite(val As Integer)
        Me.Location = New Point(Me.Location.X + val, Me.Location.Y)
    End Sub

    Public Sub deplacerHaut(val As Integer)
        Me.Location = New Point(Me.Location.X, Me.Location.Y - val)
    End Sub

    Public Sub deplacerBas(val As Integer)
        Me.Location = New Point(Me.Location.X, Me.Location.Y + val)
    End Sub

    Public Function testerCollision(position As Point, DistanceFormePanelAliensGauche As Integer, DistanceFormePanelAliensHaut As Integer) ' fonction de test de collision
        Dim detruit As Boolean = False ' A chaque fois que l'on appelle cette fonction, on teste si la position du tir est environ égale à celle d'un des aliens du groupe
        For i = 0 To nbAliens - 1
            If (position.Y - DistanceFormePanelAliensHaut >= aliens(i).Location.Y And position.Y - DistanceFormePanelAliensHaut <= aliens(i).Location.Y + aliens(i).Height) And (position.X - DistanceFormePanelAliensGauche >= aliens(i).Location.X And position.X - DistanceFormePanelAliensGauche <= aliens(i).Location.X + aliens(i).Width) And detruit = False And aliensEnVie(i) = 1 Then
                ' on utilise un integer DistanceFormePanelAliensGauche qui sert a savoir la distance qu'il y a entre 

                detruit = True ' Si c'est le cas, on modifie la valeur du boleen detruit 
                aliens(i).BackgroundImage = Nothing ' on supprime l'image de fond de l'alien ce qui le rend invisible. On aurait pu utiliser la methode Hide() mais cela entrainait des problemes
                aliensEnVie(i) = 0 'on indique que l'alien est mort
                nbAliensEnVie -= 1
                FrmJeu.Score += 10 ' augmentation du score de la partie
                FrmJeu.lblScore.Text = FrmJeu.Score
            End If
        Next
        Return detruit 'on retourne le booleen
    End Function

    Public Function getNbAliensEnVie() ' retourne le nombre d'aliens encore en vie
        Return nbAliensEnVie
    End Function

    Public Sub reinitialiser() ' cette methode sert à reinitialiser les caracteristiques de base du groupe d'aliens, c'est à dire la position, les images de fond. Tous les aliens ressuscitent 
        For i = 0 To nbAliens - 1
            aliensEnVie(i) = 1
            aliens(i).BackgroundImage = Image.FromFile("../../Images/alien.jpg")
            nbAliensEnVie = nbAliens
        Next
        Me.Location = New Point((FrmJeu.Width - Me.Width) / 2, 50)
    End Sub

    'Public Function randomAlien() ' renvoie l'indice d'un alien au hasard. fonction inutile, elle etait destinée à la fonctionnalité du tir par les aliens
    '    Dim random As New Random(), aliensSelectionne As Integer
    '    aliensSelectionne = random.Next(0, nbAliens - 1)
    '    Return aliensSelectionne
    'End Function

    'Public Sub deplacerTirBas(val As Integer, num As Integer)
    '    'aliens(num).deplacertirBas(val)
    'End Sub

    'Public Sub initialiserTirAlien(num As Integer)
    '    ' aliens(num).initialiserTir()
    'End Sub


End Class
