Public Class FrmJeu

    Const NBNIVEAUXMAX = 10 ' On créé une constante pour indiquer le nombre maximum de niveaux que oeut avoir une partie
    Dim niveaux(NBNIVEAUXMAX) As Niveau 'On créé un tableau de niveaux
    Dim niveauEnCours As Integer ' Un index qui sert à savoir dans quel niveau on se trouve
    Dim nbNiveaux As Integer ' Le nombre de niveaux effectifs
    Public Score As Integer ' Le score qui sera affiché dans la fenetre

    Private Sub FrmJeu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Score = 0 ' On commence avec un score a 0
        niveauEnCours = 0 'Le niveau en cours est égal au niveau de la premiere case du tableau de niveaux
        niveaux(0) = New Niveau(New Aliens(New Alien(Image.FromFile("../../Images/alien.jpg"), New Arme()), 10, 3), 0, New Arme(), FrmMenu.vitesseDeplacementCotesAliens) ' Creation de 4 instances de niveaux
        niveaux(1) = New Niveau(New Aliens(New Alien(Image.FromFile("../../Images/alien.jpg"), New Arme()), 12, 4), 0, New Arme(), FrmMenu.vitesseDeplacementCotesAliens)
        niveaux(2) = New Niveau(New Aliens(New Alien(Image.FromFile("../../Images/alien.jpg"), New Arme()), 15, 5), 0, New Arme(), FrmMenu.vitesseDeplacementCotesAliens + 1)
        niveaux(3) = New Niveau(New Aliens(New Alien(Image.FromFile("../../Images/alien.jpg"), New Arme()), 15, 6), 0, New Arme(), FrmMenu.vitesseDeplacementCotesAliens + 1)

        nbNiveaux = 4
        niveaux(niveauEnCours).initialisation() ' On utilise la methode initialisation() du niveau en cours pour afficher correctement tous les controles


    End Sub

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        niveaux(niveauEnCours).keyDown(e.KeyValue) ' transmission de la valeur de la touche avec une methode de la classe niveau
    End Sub

    Public Sub niveauSuivant() ' Pour passer au niveau suivant
        If niveauEnCours < nbNiveaux - 1 Then ' Si il y a encore au moins un  niveau à jouer ...
            niveauEnCours += 1
            niveaux(niveauEnCours).initialisation()
        Else
            MsgBox("Vous avez réussis tous les niveaux, bravo !") 'Si tous les niveaux on été gagnés, on quitte le FrmJeu et on affiche le menu
            Me.Dispose()
            FrmMenu.Show()
        End If

    End Sub

    Public Sub recommencerNiveau() ' Pour recommencer un niveau en cas d'echec
        niveaux(niveauEnCours).reinitialiser()
    End Sub

    Public Sub recommencerAuDebut() 'Pour recommencer au premier niveau
        niveauEnCours = 0
        niveaux(niveauEnCours).reinitialiser()
    End Sub
End Class