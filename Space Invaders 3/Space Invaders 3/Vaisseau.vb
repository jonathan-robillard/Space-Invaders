Public Class Vaisseau
    Inherits Objet

    Dim image As Image

    Public Sub New(image As Image, forme As Form)
        MyBase.New(image)
        Me.Location = New Point((forme.Width / 2) - (Me.Width / 2), forme.Height - 100)
    End Sub

    Public Sub tirer()

    End Sub


End Class
