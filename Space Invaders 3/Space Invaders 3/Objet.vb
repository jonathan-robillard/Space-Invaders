Public Class Objet
    Inherits Panel



    Public Sub New(image As Image)

        'Dim image As Image = image.FromFile(CheminImage)
        Me.BackgroundImage = image
        Me.Width = image.Width
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
