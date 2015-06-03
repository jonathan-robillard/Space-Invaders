Public Class FrmReglages


    Dim pixels(1000) As Panel 'Tableau de panels pour l'editeur d objet
    Dim pixelsVisua(1000) As Panel 'Tableau de panels pour la visualisation a la bonne echelle de l'objet
    Dim pixelsSelect(1000) As Integer ' Tableau de integer permettant de savoir quels pixels sont colories
    Dim panelEditeur As New FlowLayoutPanel
    Dim panelVisua As New FlowLayoutPanel
    Dim largeur As New Integer
    Dim hauteur As New Integer


    Private Sub FrmReglages_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        largeur = 11
        hauteur = 11

        For i = 0 To largeur * hauteur - 1
            pixelsSelect(i) = 0
            pixels(i) = New Panel
            pixels(i).Width = 40
            pixels(i).Height = 40
            pixels(i).BackColor = Color.White
            pixels(i).Margin = New Padding(1)
            pixels(i).Enabled = True
            pixels(i).Tag = i
            AddHandler pixels(i).Click, AddressOf pixel_click
            panelEditeur.Controls.Add(pixels(i))

            pixelsVisua(i) = New Panel
            pixelsVisua(i).Width = 4
            pixelsVisua(i).Height = 4
            pixelsVisua(i).BackColor = Color.DimGray
            pixelsVisua(i).Margin = New Padding(0)
            pixelsVisua(i).Enabled = True
            pixelsVisua(i).Tag = i
            panelVisua.Controls.Add(pixelsVisua(i))
        Next

        panelVisua.Location = New Point(550, 10)
        panelVisua.Height = hauteur * pixelsVisua(0).Height + 2
        panelVisua.Width = largeur * pixelsVisua(0).Width + 2
        panelVisua.BorderStyle = BorderStyle.FixedSingle
        panelVisua.BackColor = Color.DimGray
        Me.Controls.Add(panelVisua)

        panelEditeur.Height = hauteur * pixels(0).Height + hauteur * 2 + 2
        panelEditeur.Width = largeur * pixels(0).Width + largeur * 2 + 2
        panelEditeur.BorderStyle = BorderStyle.FixedSingle
        Me.Controls.Add(panelEditeur)

    End Sub

    Private Sub pixel_click(ByVal sender As Panel, ByVal e As System.EventArgs)
        sender.BackColor = Color.Black
        pixelsSelect(sender.Tag) = 1
        Console.WriteLine(sender.Tag)
        pixelsVisua(sender.Tag).BackColor = Color.Black

    End Sub

    Private Sub BtnEnregistrerVisua_Click(sender As Object, e As EventArgs) Handles BtnEnregistrerVisua.Click
        Dim image As New Bitmap(panelVisua.Width, panelVisua.Height)
        panelVisua.DrawToBitmap(image, panelVisua.ClientRectangle)
        'PictureBox1.BackgroundImage = bmp
        image.Save("../../Images/" + TextBox1.Text)
    End Sub

    Private Sub BtnQuitter_Click(sender As Object, e As EventArgs) Handles BtnQuitter.Click
        Me.Dispose()
    End Sub

    
    Private Sub BtnEnregistrer_Click(sender As Object, e As EventArgs) Handles BtnEnregistrer.Click

    End Sub

    Private Sub BtnEffacer_Click(sender As Object, e As EventArgs) Handles BtnEffacer.Click
        For i = 0 To largeur * hauteur - 1
            pixels(i).BackColor = Color.White
            pixelsSelect(i) = 0
            pixelsVisua(i).BackColor = Color.DimGray
        Next
    End Sub
End Class