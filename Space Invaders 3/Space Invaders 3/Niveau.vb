Public Class Niveau

    Dim nbObstacles As New Integer
    Dim aliens


    Public Sub New(aliens As Aliens, nbObstacles As Integer, forme As Form)

        Me.aliens = aliens
        forme.Controls.Add(aliens)


    End Sub

End Class
