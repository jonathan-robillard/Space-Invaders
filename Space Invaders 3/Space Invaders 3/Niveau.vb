Public Class Niveau

    Dim nbObstacles As New Integer
    Dim aliens As Aliens
    Dim vaisseau As Vaisseau
    Dim timerAliensDeplacementsCotes As New Timer ' le timer qui gere les depacements de cote
    Dim timerAliensDeplacementsBas As New Timer ' timer qui gere le deplacement vers le bas
    Dim forme As Form
    Dim directionAliens As Boolean ' false pour gauche et true pour droite

    Dim armes(10) As Arme 'Liste d'armes
    Dim armeEffective As Integer ' permet de savoir quelle arme ont doit utiliser



    Public Sub New(aliens As Aliens, nbObstacles As Integer, arme As Arme, forme As Form)
        Me.forme = forme
        Me.aliens = aliens
        armeEffective = 0
        armes(armeEffective) = arme

        'armes(armeEffective) = arme

        directionAliens = False ' false pour gauche et true pour droite

        forme.Controls.Add(aliens)
        vaisseau = New Vaisseau(Image.FromFile("../../Images/vaisseau.jpg"), forme)
        forme.Controls.Add(vaisseau)

        timerAliensDeplacementsCotes.Interval = 10 ' interval de 1 seconde
        timerAliensDeplacementsCotes.Enabled = True
        timerAliensDeplacementsCotes.Stop()
        AddHandler timerAliensDeplacementsCotes.Tick, AddressOf TimerAliens_Tick_Cotes 'association du timerAlien a la procedure TimerAlien_tick

        timerAliensDeplacementsBas.Interval = 1000 ' interval de 1 seconde
        timerAliensDeplacementsBas.Enabled = True
        timerAliensDeplacementsBas.Stop()
        AddHandler timerAliensDeplacementsBas.Tick, AddressOf TimerAliens_Tick_Bas 'association du timerAlien a la procedure TimerAlien_tick

        initialisation()

    End Sub

    Public Sub initialisation()
        armes(armeEffective).initialiser(vaisseau)
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
    End Sub

    Private Sub TimerAliens_Tick_Bas(sender As Object, e As EventArgs)
        aliens.deplacerBas(1)
        vaisseau.bringToFront() 'remet le vaisseau au premier plan pour ne pas etre caché par le flowlayoutpanel des Aliens
    End Sub

End Class
