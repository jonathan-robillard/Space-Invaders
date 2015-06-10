Public Class Alien
    Inherits Objet

    Dim arme As Arme

    Public Sub New(image As Image, arme As Arme)
        MyBase.New(image)

        Me.arme = arme

    End Sub

    Public Sub New()

    End Sub

    Public Sub tirer(timer As Timer)
        timer.Start()
    End Sub


End Class



Public Class Aliens
    Inherits FlowLayoutPanel

    Dim nbAliens As Integer
    Dim aliens(300) As Alien
    Dim aliensEnVie(300) As Integer
    Dim nbAliensEnVie As Integer

    Public Sub New(alien As Alien, nbAliensLarge As Integer, nbAliensHaut As Integer)
        MyBase.New()


        Me.nbAliens = nbAliensLarge * nbAliensHaut
        nbAliensEnVie = nbAliensLarge * nbAliensHaut

        For i = 0 To nbAliens - 1
            aliens(i) = New Alien(Image.FromFile("../../Images/alien.jpg"), New Arme())
            Me.Controls.Add(aliens(i))
            aliensEnVie(i) = 1
        Next

        Me.BackColor = Color.Green
        
        Me.Width = (nbAliensLarge * aliens(0).Width) + (Me.Padding.Left * 2) + ((nbAliensLarge) * aliens(0).Margin.Left) * 2
        Me.Height = (nbAliensHaut * aliens(0).Height) + (Me.Padding.Top * 2) + ((nbAliensHaut) * aliens(0).Margin.Top) * 2
        Me.Location = New Point((FrmJeu.Width - Me.Width) / 2, 50)
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

    Public Function testerColision(position As Point, DistanceFormePanelAliensGauche As Integer, DistanceFormePanelAliensHaut As Integer)
        Dim detruit As Boolean = False

        For i = 0 To nbAliens - 1
            If (position.Y - DistanceFormePanelAliensHaut >= aliens(i).Location.Y And position.Y - DistanceFormePanelAliensHaut <= aliens(i).Location.Y + aliens(i).Height) And (position.X - DistanceFormePanelAliensGauche >= aliens(i).Location.X And position.X - DistanceFormePanelAliensGauche <= aliens(i).Location.X + aliens(i).Width) And detruit = False And aliensEnVie(i) = 1 Then
                detruit = True
                aliens(i).BackgroundImage = Nothing
                aliensEnVie(i) = 0
                nbAliensEnVie -= 1
            End If
        Next
        Return detruit
    End Function

    Public Function getNbAliensEnVie()
        Return nbAliensEnVie
    End Function





End Class
