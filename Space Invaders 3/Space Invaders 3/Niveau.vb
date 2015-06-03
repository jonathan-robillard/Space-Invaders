Public Class Niveau

    Dim nbObstacles As New Integer
    Dim aliens
    Dim vaisseau


    Public Sub New(aliens As Aliens, nbObstacles As Integer, forme As Form)

        Me.aliens = aliens
        forme.Controls.Add(aliens)
        vaisseau = New Vaisseau(Image.FromFile("../../Images/vaisseau.jpg"), forme)
        forme.Controls.Add(vaisseau)



    End Sub

End Class
