Public Class FrmJeu

    Const NBNIVEAUXMAX = 10
    Dim niveaux(NBNIVEAUXMAX) As Niveau
    Dim niveauEnCours As Integer
    Dim nbNiveaux As Integer

    Private Sub FrmJeu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'niveau1 = New Niveau(New Aliens(New Alien(Image.FromFile("../../Images/alien.jpg"), New Arme(Me)), 60, Me), 0, New Arme(Me), Me, 5)

        niveauEnCours = 0
        niveaux(0) = New Niveau(New Aliens(New Alien(Image.FromFile("../../Images/alien.jpg"), New Arme()), 10, 3), 0, New Arme(), 5)
        niveaux(1) = New Niveau(New Aliens(New Alien(Image.FromFile("../../Images/alien.jpg"), New Arme()), 12, 4), 0, New Arme(), 5)
        niveaux(2) = New Niveau(New Aliens(New Alien(Image.FromFile("../../Images/alien.jpg"), New Arme()), 15, 5), 0, New Arme(), 6)
        niveaux(3) = New Niveau(New Aliens(New Alien(Image.FromFile("../../Images/alien.jpg"), New Arme()), 15, 6), 0, New Arme(), 6)

        nbNiveaux = 4

        niveaux(niveauEnCours).initialisation()

    End Sub

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        niveaux(niveauEnCours).keyDown(e.KeyValue)

        If e.KeyCode = Keys.Escape Then

        End If
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


End Class