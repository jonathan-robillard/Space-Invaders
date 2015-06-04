Public Class Arme
    Inherits Panel

    Dim porteeDegats As Integer ' la portee des degats correspond aux nombre d'aliens detruits autour du "tir"
    Dim forme As Form


    Public Sub New(porteeDegats As Integer, hauteur As Integer, largeur As Integer, couleur As Color, forme As Form)
        MyBase.New()

        Me.forme = forme
        Me.porteeDegats = porteeDegats
        Me.Height = hauteur
        Me.Width = largeur
        Me.BackColor = couleur
        forme.Controls.Add(Me)


    End Sub

    Public Sub New(forme As Form)  ' constructeur de base qui créé une arme simple
        MyBase.New()

        Me.forme = forme
        porteeDegats = 1
        Me.Height = 10
        Me.Width = 4
        Me.BackColor = Color.YellowGreen
        forme.Controls.Add(Me)
        
    End Sub

    Public Sub deplacerHaut(val As Integer)
        Me.Location = New Point(Me.Location.X, Me.Location.Y - val)
    End Sub

    Public Sub deplacerBas(val As Integer)
        Me.Location = New Point(Me.Location.X, Me.Location.Y + val)
    End Sub

    Public Sub initialiser(objet As Objet)
        Me.Location = New Point(objet.Location.X + objet.Width / 2, objet.Location.Y) 'initialise la position du "missile" à celle du vaisseau
        objet.BringToFront()
        Me.Show()
    End Sub

 


End Class
