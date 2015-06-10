Public Class Objet
    Inherits Panel

    ' La classe Objet hérite de la classe Panel et est la classe mère des classes Alien et Vaisseau

    Public Sub New(image As Image) ' Le contructeur prend en parametre une image 
        Me.BackgroundImage = image
        Me.Width = image.Width 'On regle la taille du panel en fonction de la taille de l'image 
        Me.Height = image.Height
        Me.BorderStyle = Windows.Forms.BorderStyle.None
    End Sub

    Public Sub New()

    End Sub

    Public Sub deplacerGauche(val As Integer)
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
End Class
