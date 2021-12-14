Public Class Cuadro_Conexión
    Private Sub BotonRuta_Click(sender As Object, e As EventArgs) Handles BotonRuta.Click
        Try
            Dim ruta_archivo As New OpenFileDialog
            ruta_archivo.InitialDirectory = "c:\"
            ruta_archivo.Filter = "Ficheros de bases de datos (*.accdb)|*.accdb|All files(*.*)|*.*"
            If (ruta_archivo.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
                TextBoxRuta.Text = ruta_archivo.FileName()
                botonconectarBD.Enabled = True



            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source)

        End Try
    End Sub

    Private Sub botonconectarBD_Click(sender As Object, e As EventArgs) Handles botonconectarBD.Click

        Try
            Dim agente As AgenteBD
            agente = AgenteBD.ObtenerAgente(TextBoxRuta.Text)

            Try
                BotonSiguiente.Enabled = True
                LabelEstado.ForeColor = Color.Green
                LabelEstado.Text = "OK!!"
                botonconectarBD.Enabled = False
                BotonRuta.Enabled = False

                Dim comprobarBaseDatos As GestorBaseDatos
                comprobarBaseDatos = New GestorBaseDatos

            Catch ex As Exception
                LabelEstado.Text = "ERROR"
                LabelEstado.ForeColor = Color.Red
                BotonSiguiente.Enabled = False
                BotonRuta.Enabled = True
                botonconectarBD.Enabled = True
                MessageBox.Show("Debe selecionar la base de datos Trenes valida")
                agente.destructor()
            End Try

        Catch
            MessageBox.Show("Elija un archivo de base de datos de ACCESS")
        End Try

    End Sub

    Private Sub BotonSiguiente_Click(sender As Object, e As EventArgs) Handles BotonSiguiente.Click
        ventanaPrincipal.ShowDialog()
        Me.Close()
    End Sub

    Private Sub Cuadro_Conexión_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
