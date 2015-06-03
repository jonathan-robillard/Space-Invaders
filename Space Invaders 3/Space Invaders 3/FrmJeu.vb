Public Class FrmJeu


    Private Sub FrmJeu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim niveau1 As New Niveau(New Aliens(New Alien(Image.FromFile("../../Images/alien.jpg")), 10), 0, Me)
    End Sub
End Class