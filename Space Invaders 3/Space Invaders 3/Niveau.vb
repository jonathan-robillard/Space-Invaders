Public Class Niveau

    Dim nbObstacles As New Integer
    Dim aliens As Aliens
    Dim vaisseau As Vaisseau
    Dim timerAliensDeplacementsCotes As New Timer ' le timer qui gere les depacements de cote
    Dim timerAliensDeplacementsBas As New Timer ' timer qui gere le deplacement vers le bas
    Dim timerTir As New Timer ' timer qui gere le deplacement des tirs
    Dim forme As Form
    Dim directionAliens As Boolean ' false pour gauche et true pour droite
    Dim enTir As Boolean
    Dim armes(10) As Arme 'Liste d'armes
    Dim armeEffective As Integer ' permet de savoir quelle arme ont doit utiliser

    Dim DistanceFormePanelAliensGauche As New Integer
    Dim DistanceFormePanelAliensDroite As New Integer


    Public Sub New(aliens As Aliens, nbObstacles As Integer, arme As Arme, forme As Form)
        Me.forme = forme
        Me.aliens = aliens
        armeEffective = 0
        armes(armeEffective) = arme
        armes(armeEffective).Hide()

        directionAliens = False ' false pour gauche et true pour droite

        forme.Controls.Add(aliens)
        vaisseau = New Vaisseau(Image.FromFile("../../Images/vaisseau.jpg"), forme)
        forme.Controls.Add(vaisseau)

        timerAliensDeplacementsCotes.Interval = 1000 ' 10 ms
        timerAliensDeplacementsCotes.Enabled = True
        timerAliensDeplacementsCotes.Stop()
        AddHandler timerAliensDeplacementsCotes.Tick, AddressOf TimerAliens_Tick_Cotes 'association du timerAlien a la procedure TimerAlien_tick

        timerAliensDeplacementsBas.Interval = 1000 ' interval de 1 seconde
        timerAliensDeplacementsBas.Enabled = True
        timerAliensDeplacementsBas.Stop()
        AddHandler timerAliensDeplacementsBas.Tick, AddressOf TimerAliens_Tick_Bas 'association du timerAlien a la procedure TimerAlien_tick

        timerTir.Interval = 1 ' interval de 1 seconde
        timerTir.Enabled = True
        timerTir.Stop()
        AddHandler timerTir.Tick, AddressOf TimerTir_Tick 'association du timerAlien a la procedure TimerAlien_tick

        initialisation()


    End Sub

    Public Sub initialisation()
        'DistanceFormePanelAliensGauche = (forme.Width - aliens.Width) / 2
        DistanceFormePanelAliensGauche = aliens.Location.X
        DistanceFormePanelAliensDroite = forme.Width - (aliens.Location.X + aliens.Width)
        enTir = False
    End Sub

    Public Sub keyDown(keycode As Integer)
        If keycode = 37 Then ' si la touche est fleche gauche
            vaisseau.deplacerGauche(25)
            timerAliensDeplacementsCotes.Stop()

        ElseIf keycode = 39 Then ' si la touche est fleche droite
            vaisseau.deplacerDroite(25)

        ElseIf keycode = 32 And enTir = False Then ' si la touche est barre espace
            enTir = True
            timerTir.Start()
            armes(armeEffective).initialiser(vaisseau)
            timerAliensDeplacementsCotes.Start()
            timerAliensDeplacementsBas.Start()
        End If
    End Sub

    '   PROCEDURES DES TIMERS
    Private Sub TimerAliens_Tick_Cotes(sender As Object, e As EventArgs)
        If (directionAliens = False) Then
            aliens.deplacerGauche(1)
            If (aliens.location.x = 0) Then
                directionAliens = True
            End If
        ElseIf (directionAliens = True) Then
            aliens.deplacerDroite(1)
            If (aliens.location.x + aliens.width = forme.width) Then
                directionAliens = False
            End If
        End If
        DistanceFormePanelAliensGauche = aliens.Location.X
        DistanceFormePanelAliensDroite = forme.Width - (aliens.Location.X + aliens.Width)

        Console.WriteLine(aliens(0).location)
    End Sub

    Private Sub TimerAliens_Tick_Bas(sender As Object, e As EventArgs)
        aliens.deplacerBas(1)
        vaisseau.bringToFront() 'remet le vaisseau au premier plan pour ne pas etre caché par le flowlayoutpanel des Aliens
    End Sub

    Private Sub TimerTir_Tick(sender As Object, e As EventArgs)
        armes(armeEffective).deplacerHaut(20)
        testerCollision(0, timerTir)
    End Sub

    Public Sub testerCollision(y As Integer, timer As Timer)
        'DistanceFormePanelAliensGauche = aliens.Location.X
        ' DistanceFormePanelAliensDroite = forme.Width - (aliens.Location.X + aliens.Width)
        Dim position As New Point
        position = armes(armeEffective).Location
        If position.Y <= y Then
            Console.WriteLine("supression tir")
            timer.Stop()
            armes(armeEffective).Hide()
            enTir = False
        ElseIf aliens.testerColision(position, DistanceFormePanelAliensGauche, DistanceFormePanelAliensDroite) = True Then
            Console.WriteLine("supression tir")
            timer.Stop()
            armes(armeEffective).Hide()
            enTir = False
        End If
    End Sub

End Class
