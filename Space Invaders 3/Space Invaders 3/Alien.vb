Public Class Alien
    Inherits Objet

    Public Sub New(image As Image)
        MyBase.New(image)
    End Sub

    Public Sub New()

    End Sub


End Class



Public Class Aliens
    Inherits FlowLayoutPanel

    Dim nbAliens As Integer
    Dim aliens(100) As Alien

    Dim aliensEnVie(100) As Integer

    Public Sub New(alien As Alien, nbAliens As Integer, forme As Form)
        MyBase.New()

        Me.nbAliens = nbAliens
        For i = 0 To nbAliens - 1
            aliens(i) = New Alien(Image.FromFile("../../Images/alien.jpg"))
            Me.Controls.Add(aliens(i))
            aliensEnVie(i) = 1
        Next

        Me.Width = 800
        Me.Height = 500
        Me.Location = New Point((forme.Width - Me.Width) / 2, 20)

        '  DistanceFormePanelAliens = (forme.Width - Me.Width) / 2

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

    Public Function testerColision(position As Point, DistanceFormePanelAliensGauche As Integer, DistanceFormePanelAliensDroite As Integer)
        Dim detruit As Boolean = False

        For i = 0 To nbAliens - 1
            If (position.Y >= aliens(i).Location.Y And position.Y <= aliens(i).Location.Y + aliens(i).Height) And (position.X - DistanceFormePanelAliensGauche >= aliens(i).Location.X And position.X - DistanceFormePanelAliensDroite <= aliens(i).Location.X + aliens(i).Width) And detruit = False And aliensEnVie(i) = 1 Then
                detruit = True
                'aliens(i).Hide()
                aliens(i).BackgroundImage = Nothing
                aliensEnVie(i) = 0
            End If
        Next
        Return detruit


    End Function


End Class
