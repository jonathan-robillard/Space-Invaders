<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReglages
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.BtnEnregistrerVisua = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.BtnQuitter = New System.Windows.Forms.Button()
        Me.BtnEnregistrer = New System.Windows.Forms.Button()
        Me.BtnEffacer = New System.Windows.Forms.Button()
        Me.btnCouleur = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BtnEnregistrerVisua
        '
        Me.BtnEnregistrerVisua.Location = New System.Drawing.Point(524, 122)
        Me.BtnEnregistrerVisua.Name = "BtnEnregistrerVisua"
        Me.BtnEnregistrerVisua.Size = New System.Drawing.Size(100, 23)
        Me.BtnEnregistrerVisua.TabIndex = 0
        Me.BtnEnregistrerVisua.Text = "Sauvegarder"
        Me.BtnEnregistrerVisua.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(524, 67)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 1
        '
        'BtnQuitter
        '
        Me.BtnQuitter.Location = New System.Drawing.Point(527, 462)
        Me.BtnQuitter.Name = "BtnQuitter"
        Me.BtnQuitter.Size = New System.Drawing.Size(100, 23)
        Me.BtnQuitter.TabIndex = 3
        Me.BtnQuitter.Text = "Quitter"
        Me.BtnQuitter.UseVisualStyleBackColor = True
        '
        'BtnEnregistrer
        '
        Me.BtnEnregistrer.Location = New System.Drawing.Point(527, 433)
        Me.BtnEnregistrer.Name = "BtnEnregistrer"
        Me.BtnEnregistrer.Size = New System.Drawing.Size(100, 23)
        Me.BtnEnregistrer.TabIndex = 4
        Me.BtnEnregistrer.Text = "Enregistrer"
        Me.BtnEnregistrer.UseVisualStyleBackColor = True
        '
        'BtnEffacer
        '
        Me.BtnEffacer.Location = New System.Drawing.Point(524, 151)
        Me.BtnEffacer.Name = "BtnEffacer"
        Me.BtnEffacer.Size = New System.Drawing.Size(100, 23)
        Me.BtnEffacer.TabIndex = 5
        Me.BtnEffacer.Text = "Effacer"
        Me.BtnEffacer.UseVisualStyleBackColor = True
        '
        'btnCouleur
        '
        Me.btnCouleur.Location = New System.Drawing.Point(524, 93)
        Me.btnCouleur.Name = "btnCouleur"
        Me.btnCouleur.Size = New System.Drawing.Size(100, 23)
        Me.btnCouleur.TabIndex = 6
        Me.btnCouleur.Text = "Couleur"
        Me.btnCouleur.UseVisualStyleBackColor = True
        '
        'FrmReglages
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 497)
        Me.Controls.Add(Me.btnCouleur)
        Me.Controls.Add(Me.BtnEffacer)
        Me.Controls.Add(Me.BtnEnregistrer)
        Me.Controls.Add(Me.BtnQuitter)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.BtnEnregistrerVisua)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "FrmReglages"
        Me.Text = "Reglages"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnEnregistrerVisua As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents BtnQuitter As System.Windows.Forms.Button
    Friend WithEvents BtnEnregistrer As System.Windows.Forms.Button
    Friend WithEvents BtnEffacer As System.Windows.Forms.Button
    Friend WithEvents btnCouleur As System.Windows.Forms.Button
End Class
