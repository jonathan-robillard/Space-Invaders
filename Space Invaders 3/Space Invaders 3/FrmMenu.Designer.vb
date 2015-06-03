<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMenu
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
        Me.BtnJouer = New System.Windows.Forms.Button()
        Me.BtnMulti = New System.Windows.Forms.Button()
        Me.BtnReglages = New System.Windows.Forms.Button()
        Me.BtnQuitter = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BtnJouer
        '
        Me.BtnJouer.Location = New System.Drawing.Point(113, 66)
        Me.BtnJouer.Name = "BtnJouer"
        Me.BtnJouer.Size = New System.Drawing.Size(75, 23)
        Me.BtnJouer.TabIndex = 0
        Me.BtnJouer.Text = "Jouer"
        Me.BtnJouer.UseVisualStyleBackColor = True
        '
        'BtnMulti
        '
        Me.BtnMulti.Location = New System.Drawing.Point(113, 117)
        Me.BtnMulti.Name = "BtnMulti"
        Me.BtnMulti.Size = New System.Drawing.Size(75, 23)
        Me.BtnMulti.TabIndex = 1
        Me.BtnMulti.Text = "Multijoueur"
        Me.BtnMulti.UseVisualStyleBackColor = True
        '
        'BtnReglages
        '
        Me.BtnReglages.Location = New System.Drawing.Point(113, 165)
        Me.BtnReglages.Name = "BtnReglages"
        Me.BtnReglages.Size = New System.Drawing.Size(75, 23)
        Me.BtnReglages.TabIndex = 2
        Me.BtnReglages.Text = "Réglages"
        Me.BtnReglages.UseVisualStyleBackColor = True
        '
        'BtnQuitter
        '
        Me.BtnQuitter.Location = New System.Drawing.Point(113, 214)
        Me.BtnQuitter.Name = "BtnQuitter"
        Me.BtnQuitter.Size = New System.Drawing.Size(75, 23)
        Me.BtnQuitter.TabIndex = 3
        Me.BtnQuitter.Text = "Quitter"
        Me.BtnQuitter.UseVisualStyleBackColor = True
        '
        'FrmMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(300, 285)
        Me.Controls.Add(Me.BtnQuitter)
        Me.Controls.Add(Me.BtnReglages)
        Me.Controls.Add(Me.BtnMulti)
        Me.Controls.Add(Me.BtnJouer)
        Me.Name = "FrmMenu"
        Me.Text = "Menu"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnJouer As System.Windows.Forms.Button
    Friend WithEvents BtnMulti As System.Windows.Forms.Button
    Friend WithEvents BtnReglages As System.Windows.Forms.Button
    Friend WithEvents BtnQuitter As System.Windows.Forms.Button

End Class
