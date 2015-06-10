Public Class Arme
    Inherits Panel

    Dim porteeDegats As Integer ' la portee des degats correspond aux nombre d'aliens detruits autour du "tir"

    Public Sub New(porteeDegats As Integer, hauteur As Integer, largeur As Integer, couleur As Color)
        MyBase.New()

        Me.porteeDegats = porteeDegats
        Me.Height = hauteur
        Me.Width = largeur
        Me.BackColor = couleur
        FrmJeu.Controls.Add(Me)


    End Sub

    Public Sub New()  ' constructeur de base qui créé une arme simple
        MyBase.New()

        porteeDegats = 1
        Me.Height = 10
        Me.Width = 4
        Me.BackColor = Color.YellowGreen
        FrmJeu.Controls.Add(Me)

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
