Public Class FrmMenu ' Menu principal

    Public vitesseDeplacementCotesAliens As Integer ' On créé des viariables publiques qui seront lues dans toutes les Formes du projet. Elles serviront à regler les vitesses de deplacement des aliens en fonction de la diffulté choisie
    Public vitesseDescenteAliens As Integer

    Private Sub FrmMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        vitesseDeplacementCotesAliens = 5 ' on donne une valeur de base pour ces variables, Ce sont les valeurs pour le mode facile
        vitesseDescenteAliens = 1
    End Sub

    Private Sub BtnJouer_Click(sender As Object, e As EventArgs) Handles BtnJouer.Click ' Procedure affectée au bouton "jouer", on cache le menu et on affiche la Forme de jeu
        Me.Hide()
        FrmJeu.Show()
    End Sub

    Private Sub BtnReglages_Click(sender As Object, e As EventArgs) Handles BtnReglages.Click ' Procedure affectée au bouton "reglages", on cache le menu et on affiche la fenetre de reglages
        Me.Hide()
        FrmReglages.Show()
    End Sub

    Private Sub BtnQuitter_Click(sender As Object, e As EventArgs) Handles BtnQuitter.Click ' Pour quitter l'application
        Me.Dispose()
    End Sub
End Class
