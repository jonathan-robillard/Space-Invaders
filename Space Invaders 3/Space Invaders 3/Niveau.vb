Public Class Niveau

    Dim nbObstacles As New Integer
    Dim aliens





    Public Sub New(aliens As Aliens, nbObstacles As Integer)

        Dim alien As Alien(Image.FromFile("C:\mon_image.jpg"))

        Me.aliens = aliens


    End Sub

End Class
