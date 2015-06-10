Public Class FrmJeu

    Const NBNIVEAUXMAX = 10
    Dim niveaux(NBNIVEAUXMAX) As Niveau
    Dim niveauEnCours As Integer
    Dim nbNiveaux As Integer
    Public Score As Integer

    Private Sub FrmJeu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'niveau1 = New Niveau(New Aliens(New Alien(Image.FromFile("../../Images/alien.jpg"), New Arme(Me)), 60, Me), 0, New Arme(Me), Me, 5)

        Score = 0
        niveauEnCours = 0
        niveaux(0) = New Niveau(New Aliens(New Alien(Image.FromFile("../../Images/alien.jpg"), New Arme()), 10, 3), 0, New Arme(), FrmMenu.vitesseDeplacementCotesAliens)
        niveaux(1) = New Niveau(New Aliens(New Alien(Image.FromFile("../../Images/alien.jpg"), New Arme()), 12, 4), 0, New Arme(), FrmMenu.vitesseDeplacementCotesAliens)
        niveaux(2) = New Niveau(New Aliens(New Alien(Image.FromFile("../../Images/alien.jpg"), New Arme()), 15, 5), 0, New Arme(), FrmMenu.vitesseDeplacementCotesAliens + 1)
        niveaux(3) = New Niveau(New Aliens(New Alien(Image.FromFile("../../Images/alien.jpg"), New Arme()), 15, 6), 0, New Arme(), FrmMenu.vitesseDeplacementCotesAliens + 1)

        nbNiveaux = 4

        niveaux(niveauEnCours).initialisation()


    End Sub

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        niveaux(niveauEnCours).keyDown(e.KeyValue)
    End Sub

    Public Sub niveauSuivant()
        If niveauEnCours < nbNiveaux - 1 Then
            niveauEnCours += 1
            niveaux(niveauEnCours).initialisation()
        Else
            MsgBox("Vous avez réussis tous les niveaux, bravo !")
            Me.Dispose()
            FrmMenu.Show()
        End If

    End Sub

    Public Sub recommencerNiveau()
        niveaux(niveauEnCours).reinitialiser()
    End Sub

    Public Sub recommencerAuDebut()
        niveauEnCours = 0
        niveaux(niveauEnCours).reinitialiser()
    End Sub


    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class