Public Class Niveau

    Dim nbObstacles As New Integer
    Dim aliens
    Dim vaisseau
    Dim timerAliens As New Timer
    Dim forme
    Dim directionAliens As Boolean


    Public Sub New(aliens As Aliens, nbObstacles As Integer, forme As Form)
        Me.forme = forme
        Me.aliens = aliens

        directionAliens = False ' false pour gauche et true pour droite

        forme.Controls.Add(aliens)
        vaisseau = New Vaisseau(Image.FromFile("../../Images/vaisseau.jpg"), forme)
        forme.Controls.Add(vaisseau)

        timerAliens.Interval = 10 ' interval de 1 seconde
        timerAliens.Enabled = True
        timerAliens.Start()
        AddHandler timerAliens.Tick, AddressOf TimerAliens_Tick 'association du timerAlien a la procedure TimerAlien_tick

        initialisation()

    End Sub

    Public Sub initialisation()

    End Sub

    Public Sub keyDown(keycode As Integer)
        If keycode = 37 Then ' si la touche est fleche gauche
            vaisseau.deplacerGauche(25)
        ElseIf keycode = 39 Then ' si la touche est fleche droite
            vaisseau.deplacerDroite(25)
        ElseIf keycode = 32 Then ' si la touche est barre espace

        End If
    End Sub

    '   PROCEDURES DES TIMERS
    Private Sub TimerAliens_Tick(sender As Object, e As EventArgs)
        aliens.deplacerBas(1)

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

        Console.WriteLine(directionAliens)

        vaisseau.bringToFront() 'remet le vaisseau au premier plan pour ne pas etre caché par le flowlayoutpanel des Aliens
    End Sub

End Class
