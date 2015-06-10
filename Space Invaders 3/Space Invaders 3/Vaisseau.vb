Public Class Vaisseau
    Inherits Objet

    Dim image As Image

    Public Sub New(image As Image)
        MyBase.New(image)
        Me.Location = New Point((FrmJeu.Width / 2) - (Me.Width / 2), FrmJeu.Height - 100)
    End Sub

    Public Sub reinitialiser()
        Me.Location = New Point((FrmJeu.Width / 2) - (Me.Width / 2), FrmJeu.Height - 100)
    End Sub



End Class
