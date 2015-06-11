Public Class Vaisseau
    Inherits Objet '--> Hérite d'Objet

    Dim image As Image

	' Initialisation
    Public Sub New(image As Image)
        MyBase.New(image)
		' On positionne le vaisseau au milieu
        Me.Location = New Point((FrmJeu.Width / 2) - (Me.Width / 2), FrmJeu.Height - 100)
    End Sub
	
	' Remise à zéro
    Public Sub reinitialiser()
	' On positionne le vaisseau au milieu
        Me.Location = New Point((FrmJeu.Width / 2) - (Me.Width / 2), FrmJeu.Height - 100)
    End Sub



End Class
