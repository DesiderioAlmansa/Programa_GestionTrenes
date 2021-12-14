<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cuadro_Conexión
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cuadro_Conexión))
        Me.LabelEstado = New System.Windows.Forms.Label()
        Me.BotonSiguiente = New System.Windows.Forms.Button()
        Me.TextBoxRuta = New System.Windows.Forms.TextBox()
        Me.botonconectarBD = New System.Windows.Forms.Button()
        Me.BotonRuta = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LabelEstado
        '
        Me.LabelEstado.AutoSize = True
        Me.LabelEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelEstado.Location = New System.Drawing.Point(442, 195)
        Me.LabelEstado.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelEstado.Name = "LabelEstado"
        Me.LabelEstado.Size = New System.Drawing.Size(0, 24)
        Me.LabelEstado.TabIndex = 22
        '
        'BotonSiguiente
        '
        Me.BotonSiguiente.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.BotonSiguiente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BotonSiguiente.Enabled = False
        Me.BotonSiguiente.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BotonSiguiente.FlatAppearance.BorderSize = 2
        Me.BotonSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BotonSiguiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BotonSiguiente.Location = New System.Drawing.Point(409, 114)
        Me.BotonSiguiente.Margin = New System.Windows.Forms.Padding(2)
        Me.BotonSiguiente.Name = "BotonSiguiente"
        Me.BotonSiguiente.Size = New System.Drawing.Size(97, 47)
        Me.BotonSiguiente.TabIndex = 21
        Me.BotonSiguiente.Text = "Siguiente"
        Me.BotonSiguiente.UseVisualStyleBackColor = False
        '
        'TextBoxRuta
        '
        Me.TextBoxRuta.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.TextBoxRuta.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxRuta.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBoxRuta.Location = New System.Drawing.Point(168, 13)
        Me.TextBoxRuta.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBoxRuta.Multiline = True
        Me.TextBoxRuta.Name = "TextBoxRuta"
        Me.TextBoxRuta.Size = New System.Drawing.Size(338, 94)
        Me.TextBoxRuta.TabIndex = 20
        '
        'botonconectarBD
        '
        Me.botonconectarBD.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.botonconectarBD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.botonconectarBD.Enabled = False
        Me.botonconectarBD.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.botonconectarBD.FlatAppearance.BorderSize = 2
        Me.botonconectarBD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.botonconectarBD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.botonconectarBD.Location = New System.Drawing.Point(26, 114)
        Me.botonconectarBD.Margin = New System.Windows.Forms.Padding(2)
        Me.botonconectarBD.Name = "botonconectarBD"
        Me.botonconectarBD.Size = New System.Drawing.Size(97, 47)
        Me.botonconectarBD.TabIndex = 19
        Me.botonconectarBD.Text = "Conectar"
        Me.botonconectarBD.UseVisualStyleBackColor = False
        '
        'BotonRuta
        '
        Me.BotonRuta.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.BotonRuta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BotonRuta.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BotonRuta.FlatAppearance.BorderSize = 2
        Me.BotonRuta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BotonRuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte), True)
        Me.BotonRuta.Location = New System.Drawing.Point(26, 13)
        Me.BotonRuta.Margin = New System.Windows.Forms.Padding(2)
        Me.BotonRuta.Name = "BotonRuta"
        Me.BotonRuta.Size = New System.Drawing.Size(97, 46)
        Me.BotonRuta.TabIndex = 18
        Me.BotonRuta.Text = "BotonRuta"
        Me.BotonRuta.UseVisualStyleBackColor = False
        '
        'Cuadro_Conexión
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImage = Global.GestionTrenes.My.Resources.Resources.minimalism_train_vehicle_wallpaper_preview
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(527, 228)
        Me.Controls.Add(Me.LabelEstado)
        Me.Controls.Add(Me.BotonSiguiente)
        Me.Controls.Add(Me.TextBoxRuta)
        Me.Controls.Add(Me.botonconectarBD)
        Me.Controls.Add(Me.BotonRuta)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Cuadro_Conexión"
        Me.Text = "CONEXIÓN A BBDD BAMPS"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BotonSiguiente As Button
    Friend WithEvents TextBoxRuta As TextBox
    Friend WithEvents botonconectarBD As Button
    Friend WithEvents BotonRuta As Button
    Friend WithEvents LabelEstado As Label
End Class
