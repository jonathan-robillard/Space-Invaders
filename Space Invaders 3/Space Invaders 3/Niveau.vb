Public Class Niveau

    Dim nbObstacles As New Integer
    Dim aliens As Aliens
    Dim vaisseau As Vaisseau
    Dim timerAliensDeplacementsCotes As New Timer ' le timer qui gere les depacements de cote
    Dim timerAliensDeplacementsBas As New Timer ' timer qui gere le deplacement vers le bas
    Dim timerTir As New Timer ' timer qui gere le deplacement des tirs
    Dim directionAliens As Boolean ' false pour gauche et true pour droite
    Dim enTir As Boolean
    Dim armesVaisseau(10) As Arme 'Liste d'armes du vaisseau
    Dim armeEffectiveVaisseau As Integer ' permet de savoir quelle arme ont doit utiliser

    Dim DistanceFormePanelAliensGauche As New Integer
    Dim DistanceFormePanelAliensHaut As New Integer

    Dim vitesseAliens As Integer

    Dim armeAlien As Arme

    Dim AffichageVies As New FlowLayoutPanel
    Dim panelsVies(5) As Vaisseau
    Dim viesRestantes As Integer


    Public Sub New(aliens As Aliens, nbObstacles As Integer, arme As Arme, vitesseAliens As Integer)
        Me.vitesseAliens = vitesseAliens
        Me.aliens = aliens
        armeEffectiveVaisseau = 0
        armesVaisseau(armeEffectiveVaisseau) = arme
        armesVaisseau(armeEffectiveVaisseau).Hide()
        armeAlien = New Arme()
        directionAliens = False ' false pour gauche et true pour droite

        FrmJeu.Controls.Add(aliens)
        aliens.Hide()

        viesRestantes = 3

        vaisseau = New Vaisseau(Image.FromFile("../../Images/vaisseau.jpg"))
        FrmJeu.Controls.Add(vaisseau)
        vaisseau.Hide()

        timerAliensDeplacementsCotes.Interval = 10 ' 10 ms
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

        For i = 0 To viesRestantes - 1
            panelsVies(i) = New Vaisseau(Image.FromFile("../../Images/vaisseau.jpg"))
            AffichageVies.Controls.Add(panelsVies(i))
        Next


        AffichageVies.Height = panelsVies(0).Height
        AffichageVies.Width = (panelsVies(0).Width * viesRestantes) + (panelsVies(0).Margin.Left * (viesRestantes) * 2)
        'AffichageVies.BackColor = Color.Green
        AffichageVies.Location = New Point(FrmJeu.Width - AffichageVies.Width - 100, 0)
        FrmJeu.Controls.Add(AffichageVies)

    End Sub

    Public Sub initialisation()

        vaisseau.Show()
        aliens.Show()
        DistanceFormePanelAliensGauche = aliens.Location.X
        DistanceFormePanelAliensHaut = aliens.Location.Y
        enTir = False
    End Sub

    Public Sub effaceurNiveau()
        FrmJeu.Controls.Remove(aliens)
        FrmJeu.Controls.Remove(vaisseau)
    End Sub

    Public Sub keyDown(keycode As Integer)
        If keycode = 37 Then ' si la touche est fleche gauche
            vaisseau.deplacerGauche(25)
        ElseIf keycode = 39 Then ' si la touche est fleche droite
            vaisseau.deplacerDroite(25)
        ElseIf keycode = 27 Then
            Console.WriteLine("niv suivant")
            effaceurNiveau()
            FrmJeu.niveauSuivant()



        ElseIf keycode = 32 And enTir = False Then ' si la touche est barre espace
            enTir = True
            timerTir.Start()
            armesVaisseau(armeEffectiveVaisseau).initialiser(vaisseau)
            timerAliensDeplacementsCotes.Start()
            timerAliensDeplacementsBas.Start()
        End If
    End Sub

    '   PROCEDURES DES TIMERS
    Private Sub TimerAliens_Tick_Cotes(sender As Object, e As EventArgs)
        If (directionAliens = False) Then
            aliens.deplacerGauche(vitesseAliens)
            If (aliens.Location.X <= 0) Then
                directionAliens = True
            End If
        ElseIf (directionAliens = True) Then
            aliens.deplacerDroite(vitesseAliens)
            If (aliens.Location.X + aliens.Width >= FrmJeu.Width) Then
                directionAliens = False
            End If
        End If
        DistanceFormePanelAliensGauche = aliens.Location.X
        DistanceFormePanelAliensHaut = aliens.Location.Y

    End Sub

    Private Sub TimerAliens_Tick_Bas(sender As Object, e As EventArgs)
        aliens.deplacerBas(5)
        vaisseau.bringToFront() 'remet le vaisseau au premier plan pour ne pas etre caché par le flowlayoutpanel des Aliens
    End Sub

    Private Sub TimerTir_Tick(sender As Object, e As EventArgs)
        armesVaisseau(armeEffectiveVaisseau).deplacerHaut(20)
        testerCollision(0, timerTir)


    End Sub

    Public Sub testerCollision(y As Integer, timer As Timer)
       
        Dim position As New Point
        position = armesVaisseau(armeEffectiveVaisseau).Location
        If position.Y <= y Then
            timer.Stop()
            armesVaisseau(armeEffectiveVaisseau).Hide()
            enTir = False
        ElseIf aliens.testerColision(position, DistanceFormePanelAliensGauche, DistanceFormePanelAliensHaut) = True Then
            timer.Stop()
            armesVaisseau(armeEffectiveVaisseau).Hide()
            enTir = False
        End If

        If aliens.getNbAliensEnVie() = 0 Then
            gagner()
        End If

    End Sub

    Public Sub gagner()
        timerAliensDeplacementsCotes.Stop()
        timerAliensDeplacementsBas.Stop()
        effaceurNiveau()
        Dim msgBoxGagner As DialogResult = MessageBox.Show("Vous avez gagné ! Voulez vous passer au niveau suivant ?", "Niveau réussi", MessageBoxButtons.YesNo)
        If msgBoxGagner = Windows.Forms.DialogResult.Yes Then
            Console.WriteLine("continuer")
            FrmJeu.niveauSuivant()
        ElseIf msgBoxGagner = Windows.Forms.DialogResult.No Then
            Console.WriteLine("quitter")
        End If

    End Sub

End Class
