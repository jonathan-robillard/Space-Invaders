Public Class FrmJeu

    Dim niveau1

    Private Sub FrmJeu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        niveau1 = New Niveau(New Aliens(New Alien(Image.FromFile("../../Images/alien.jpg"), New Arme(Me)), 60, Me), 0, New Arme(Me), Me, 5)
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        niveau1.KeyDown(e.KeyValue)
    End Sub


End Class