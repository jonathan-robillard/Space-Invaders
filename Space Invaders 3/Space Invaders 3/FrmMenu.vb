Public Class FrmMenu

    Public vitesseDeplacementCotesAliens As Integer
    Public vitesseDescenteAliens As Integer

    Private Sub FrmMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        vitesseDeplacementCotesAliens = 5
        vitesseDescenteAliens = 1
    End Sub

    Private Sub BtnJouer_Click(sender As Object, e As EventArgs) Handles BtnJouer.Click
        Me.Hide()
        FrmJeu.Show()
    End Sub

    Private Sub BtnReglages_Click(sender As Object, e As EventArgs) Handles BtnReglages.Click
        Me.Hide()
        FrmReglages.Show()
    End Sub

    Private Sub BtnQuitter_Click(sender As Object, e As EventArgs) Handles BtnQuitter.Click
        Me.Dispose()
    End Sub
End Class
