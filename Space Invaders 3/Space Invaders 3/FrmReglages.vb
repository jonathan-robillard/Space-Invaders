Public Class FrmReglages


    Dim pixels(1000) As Panel 'Tableau de panels pour l'editeur d objet
    Dim pixelsVisua(1000) As Panel 'Tableau de panels pour la visualisation a la bonne echelle de l'objet
    Dim pixelsSelect(1000) As Integer ' Tableau de integer permettant de savoir quels pixels sont colories
    Dim panelEditeur As New FlowLayoutPanel
    Dim panelVisua As New FlowLayoutPanel
    Dim largeur As New Integer
    Dim hauteur As New Integer
    Dim choixColor As Color = Color.Black
    Dim img As Bitmap

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

        panelEditeur.Location = New Point(20, 20)
        panelEditeur.Height = hauteur * pixels(0).Height + hauteur * 2 + 2
        panelEditeur.Width = largeur * pixels(0).Width + largeur * 2 + 2
        panelEditeur.BorderStyle = BorderStyle.FixedSingle
        Me.Controls.Add(panelEditeur)

        ComboBoxDifficulte.SelectedText = "Facile"
        

    End Sub

    Private Sub pixel_click(ByVal sender As Panel, ByVal e As System.EventArgs)
        sender.BackColor = choixColor
        pixelsSelect(sender.Tag) = 1
        Console.WriteLine(sender.Tag)
        pixelsVisua(sender.Tag).BackColor = choixColor
    End Sub

    Private Sub BtnEnregistrerVisua_Click(sender As Object, e As EventArgs) Handles BtnEnregistrerVisua.Click
        Dim image As New Bitmap(panelVisua.Width, panelVisua.Height)
        panelVisua.DrawToBitmap(image, panelVisua.ClientRectangle)
        'PictureBox1.BackgroundImage = bmp
        image.Save("../../Images/" + TextBox1.Text)
    End Sub

    Private Sub BtnQuitter_Click(sender As Object, e As EventArgs) Handles BtnQuitter.Click
        Me.Dispose()
        FrmMenu.Show()
    End Sub

    
    Private Sub BtnEnregistrer_Click(sender As Object, e As EventArgs) Handles BtnEnregistrer.Click

        If ComboBoxDifficulte.SelectedItem = "Facile" Then
            FrmMenu.vitesseDeplacementCotesAliens = 5
            FrmMenu.vitesseDescenteAliens = 1
        ElseIf ComboBoxDifficulte.SelectedItem = "Medium" Then
            FrmMenu.vitesseDeplacementCotesAliens = 6
            FrmMenu.vitesseDescenteAliens = 2
        ElseIf ComboBoxDifficulte.SelectedItem = "Difficile" Then
            FrmMenu.vitesseDeplacementCotesAliens = 8
            FrmMenu.vitesseDescenteAliens = 3
        End If

        Console.WriteLine(ComboBoxDifficulte.SelectedItem)

        MsgBox("Paramètres enregistrés !")

    End Sub

    Private Sub BtnEffacer_Click(sender As Object, e As EventArgs) Handles BtnEffacer.Click
        For i = 0 To largeur * hauteur - 1
            pixels(i).BackColor = Color.White
            pixelsSelect(i) = 0
            pixelsVisua(i).BackColor = Color.DimGray
        Next
    End Sub

    Private Sub btnCouleur_Click(sender As Object, e As EventArgs) Handles btnCouleur.Click
        Dim cDialog As New ColorDialog()
        If (cDialog.ShowDialog() = DialogResult.OK) Then
            choixColor = cDialog.Color
        End If
    End Sub

    Private Sub btnImporter_Click(sender As Object, e As EventArgs) Handles btnImporter.Click
        Dim dlg As New OpenFileDialog()
        dlg.FileName = "Document"
        dlg.DefaultExt = ".jpg"
        dlg.Filter = "Images 11x11 (.jpg)|*.jpg"
        Dim result? As Boolean = dlg.ShowDialog()
        Dim cheminImage As String
        If result = True Then
            cheminImage = dlg.FileName
        End If
        Console.WriteLine(cheminImage)
        '' Dim img As Image(Image.FromFile(cheminImage))
        img = New Bitmap(cheminImage, True)
        Dim i As Integer
        Dim j As Integer
        'If img.GetPixel(x) = 11 Or img.GetWidth() = 11 Then
        For i = 0 To 11
            For j = 0 To 11
                img.GetPixel(i, j)
            Next
        Next
        'Else
        'MsgBox("L'image ne fait pas le bon format. Choisissez une image de 11x11.")
        'End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles lblDifficulté.Click

    End Sub
End Class