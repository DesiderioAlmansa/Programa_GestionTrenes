Imports System.Data.OleDb
Public Class ventanaPrincipal
    Private tren As Tren
    Private trenedi As Tren
    Private tipotren As Tipos_Tren
    Private tipotrenedi As Tipos_Tren
    Private producto As Producto
    Private productoedi As Producto
    Private cotizacion As Cotización
    Private cotiedi As Cotización
    Private viaje As Viaje
    Private viajeedi As Viaje

    Private estadotipotrenes As Integer
    Private estadotrenes As Integer
    Private estadopro As Integer
    Private estadocot As Integer
    Private estadoviaje As Integer

    Private Sub ventanaPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        estadotipotrenes = 0
        estadotrenes = 0
        Dim tipotren As Tipos_Tren
        tipotren = New Tipos_Tren
        Dim tren As Tren
        tren = New Tren
        Dim producto As Producto
        producto = New Producto
        Dim cotizacion As Cotización
        cotizacion = New Cotización
        Dim viaje As Viaje
        viaje = New Viaje

        cotizacion.LeerTodasCotizaciones()
        producto.LeerTodosProductos()
        tren.LeerTodosTrenes()
        tipotren.LeerTodosTip_trenes()
        viaje.LeerTodosViajes()

        For Each tiptren As Tipos_Tren In tipotren.t_trenDAO.listaTipoTrenes
            ListBoxTipTren.Items.Add(tiptren.idttren & " " & tiptren.destren)
            CBTipoTren.Items.Add(tiptren.idttren)
        Next

        For Each t As Tren In tren.trenDAO.listatrenes
            ListBoxTren.Items.Add(t.matricula)
            CBTrenes.Items.Add(t.matricula)
            ComBoxEligeTren.Items.Add(t.matricula)
        Next

        For Each c As Cotización In cotizacion.CotizacionDAO.listacotizaciones
            ListBoxCotizaciones.Items.Add(c.producto.id_producto & " " & c.fecha)
        Next

        For Each v As Viaje In viaje.viajesDAO.listaviajes
            ListBoxViajes.Items.Add(v.fecha_viaje & " " & v.tren.matricula & " " & v.producto.id_producto)
        Next

        For Each pro As Producto In producto.productosDAO.listaproductos
            CBProductos.Items.Add(pro.id_producto)
            ComboProductos.Items.Add(pro.id_producto)
            ListBoxProductos.Items.Add(pro.id_producto & " " & pro.des_pro)
        Next

    End Sub


    Function comprobarNombre(ByVal Nombre As String) As Boolean
        Dim valido As Boolean
        valido = True

        For i = 0 To Nombre.Length - 1
            If Not (Char.IsLetter(Nombre(i)) Or Char.IsSeparator(Nombre(i))) Then
                valido = False
                Exit For
            End If
        Next

        Return valido
    End Function
    Private Sub generarFichaTipoTren(t As Tipos_Tren)
        CajaDesTipTren.Text = t.destren
        CajaCapacidadMaxima.Text = t.capmax
    End Sub
    Private Sub ListBoxTipTren_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxTipTren.SelectedIndexChanged
        If ListBoxTipTren.SelectedItem IsNot Nothing Then
            BotonBorrarViaje.Enabled = True
            BotonInsViaje.Enabled = True
            BotonModViaje.Enabled = True

            Dim split As String() = ListBoxTipTren.SelectedItem.ToString().Split(New [Char]() {" "c})
            Dim id As Integer
            id = CInt(split(0))

            Me.tipotren = New Tipos_Tren()

            Me.tipotren.idttren = id
            Me.tipotren.LeerTip_tren()

            Me.tipotren = tipotren
            Me.tipotrenedi = tipotren
            generarFichaTipoTren(tipotren)
        Else
            BotonBorrarViaje.Enabled = False
            BotonModViaje.Enabled = False
        End If
        Me.BotonModViaje.Enabled = True
        Me.BotonBorrarViaje.Enabled = True
    End Sub

    Private Sub ButtonInsertar_Click(sender As Object, e As EventArgs) Handles ButtonInsertar.Click
        Me.estadotipotrenes = 0
        Dim tipotren As Tipos_Tren
        tipotren = New Tipos_Tren
        tipotren.LeerTodosTip_trenes()
        GBAñadirTipoTren.Enabled = True
        CajaDesTipTren.Text = " "
        CajaCapacidadMaxima.Text = " "

        ButtonInsertar.Enabled = False
        ButtonModificar.Enabled = False
        Buttonborrar.Enabled = False
    End Sub

    Private Sub ButtonModificar_Click(sender As Object, e As EventArgs) Handles ButtonModificar.Click
        If ListBoxTipTren.SelectedItem Is Nothing Then
            MsgBox("ERROR.No has seleccionado ningun Tipo de Tren.")
        Else
            Me.estadotipotrenes = 1
            CajaDesTipTren.Text = Me.tipotren.destren
            CajaCapacidadMaxima.Text = Me.tipotren.capmax
            GBAñadirTipoTren.Enabled = True
            ButtonInsertar.Enabled = False
            ButtonModificar.Enabled = False
            Buttonborrar.Enabled = False
        End If
    End Sub

    Private Sub LimpiarTextoFormularioGeneral(gb As GroupBox)
        For Each c As Control In gb.Controls
            If TypeOf (c) Is TextBox Then
                c.Text = ""
            ElseIf (TypeOf (c) Is ComboBox) Then
                c.ResetText()
            End If
        Next
    End Sub
    Private Sub Buttonborrar_Click(sender As Object, e As EventArgs) Handles Buttonborrar.Click
        If ListBoxTipTren.SelectedItem Is Nothing Then
            MsgBox("ERROR.No has seleccionado ningun Tipo de Tren.")
        Else
            Try

                Dim borrar As Integer
                borrar = MsgBox("¿Esta seguro de que desea eliminar el  tren seleccionado? ", +vbYesNo + vbDefaultButton2, "Eliminar tren.")
                If (borrar = vbYes) Then
                    Me.tipotren.BorrarTip_tren()
                    ListBoxTipTren.Items.RemoveAt(ListBoxTipTren.SelectedIndex)
                    CajaDesTipTren.Text = ""
                    CajaCapacidadMaxima.Text = ""
                    CBTipoTren.Items.Remove(Me.tipotren.idttren)
                    MessageBox.Show("Ha borrado el tipo de tren correctamente.")
                End If

            Catch ex As OleDbException
                MessageBox.Show("Error. No se puede borrar el Tipo de Tren ya que existen registros de el en otra tablas. ")
            End Try
            LimpiarTextoFormularioGeneral(GBAñadirTipoTren)
        End If
    End Sub

    Private Sub BotonCancelarTiposTrenes_Click(sender As Object, e As EventArgs) Handles BotonCancelarTiposTrenes.Click
        Me.estadotipotrenes = -1
        Buttonborrar.Enabled = True
        ButtonModificar.Enabled = True
        ButtonInsertar.Enabled = True
        GBAñadirTipoTren.Enabled = False
        LimpiarTextoFormularioGeneral(GBAñadirTipoTren)
    End Sub

    Private Sub BotonGuardarTipoTren_Click(sender As Object, e As EventArgs) Handles BotonGuardarTipoTren.Click
        If (CajaDesTipTren.Text.Trim = "" Or CajaCapacidadMaxima.Text.Trim = "") Then
            MsgBox("Debe de rellenar todos los campos.", vbExclamation)
        Else
            If Not (comprobarNombre(CajaDesTipTren.Text)) Then
                MsgBox("La descripción solo puede contener letras y espacios.", vbExclamation)

            Else
                Dim descTren As String
                Dim capmax As String
                Dim tren As Tipos_Tren
                descTren = CajaDesTipTren.Text().Trim()
                descTren = descTren.Substring(0, 1).ToUpper + descTren.Substring(1, descTren.Length - 1).ToLower
                capmax = CajaCapacidadMaxima.Text()

                tren = New Tipos_Tren(descTren, capmax)

                If Me.estadotipotrenes = 0 Then 'Añadir un nuevo tipo de tren'
                    tren.InsertarTip_tren()
                    tren.leerID()
                    ListBoxTipTren.Items.Add(tren.idttren & "  " & tren.destren)
                    CBTipoTren.Items.Add(tren.idttren)
                    MessageBox.Show("Ha insertado el tipo de tren con éxito.")

                ElseIf Me.estadotipotrenes = 1 Then 'Editar un tipo de tren ya existente'
                    Dim indice As Integer
                    Try
                        Dim actualizar As Integer
                        Me.tipotrenedi.destren = descTren
                        Me.tipotrenedi.capmax = capmax
                        actualizar = tipotrenedi.ActualizarTip_tren
                        If (actualizar = 0) Then
                            MessageBox.Show("Error. No se pudo modificar ")
                        Else
                            MessageBox.Show("Tipo de Tren modificado con éxito.")
                            indice = ListBoxTipTren.SelectedIndex
                            ListBoxTipTren.Items.RemoveAt(indice)
                            ListBoxTipTren.Items.Insert(indice, Me.tipotrenedi.idttren & "  " & Me.tipotrenedi.destren)

                        End If
                    Catch

                    End Try
                End If

                GBAñadirTipoTren.Enabled = False
                ButtonModificar.Enabled = True
                Buttonborrar.Enabled = True
                ButtonInsertar.Enabled = True
                CajaDesTipTren.Text = ""
                CajaCapacidadMaxima.Text = ""
                ListBoxTipTren.SelectedItem = Nothing
            End If
        End If
    End Sub

    Private Sub botonLimpiarTiposTrenes_Click(sender As Object, e As EventArgs) Handles botonLimpiarTiposTrenes.Click
        LimpiarTextoFormularioGeneral(GBAñadirTipoTren)
    End Sub

    Private Sub BtAñadirTren_Click(sender As Object, e As EventArgs) Handles BtInsertarTren.Click
        Me.estadotrenes = 0

        Dim tren As Tren
        tren = New Tren
        Dim tipotren As Tipos_Tren
        tipotren = New Tipos_Tren
        tipotren.LeerTodosTip_trenes()
        tren.LeerTodosTrenes()

        GBAñadirTren.Enabled = True
        GBTren.Enabled = True
        CajaMatricula.Enabled = True
        CajaMatricula.Text = " "
        BtInsertarTren.Enabled = False
        BtModificarTren.Enabled = False
        BtBorrarTren.Enabled = False
    End Sub

    Private Sub BtModificarTren_Click(sender As Object, e As EventArgs) Handles BtModificarTren.Click
        If ListBoxTren.SelectedItem Is Nothing Then
            MsgBox("ERROR.No has seleccionado ningun Tren.")
        Else
            Me.estadotrenes = 1
            CajaMatricula.Text = Me.trenedi.matricula
            GBAñadirTren.Enabled = True
            GBTren.Enabled = True
            BtInsertarTren.Enabled = False
            BtModificarTren.Enabled = False
            BtBorrarTren.Enabled = False
            BtModificarTren.Enabled = False
            CajaMatricula.Enabled = False
        End If
    End Sub

    Private Sub BtBorrarTren_Click(sender As Object, e As EventArgs) Handles BtBorrarTren.Click
        If ListBoxTren.SelectedItem Is Nothing Then
            MsgBox("ERROR.No has seleccionado ningun Tren.")
        Else
            Try
                Dim borrar As Integer
                borrar = MsgBox("¿Esta seguro de que desea eliminar el  tren seleccionado? ", +vbYesNo + vbDefaultButton2, "Eliminar tren.")
                If (borrar = vbYes) Then
                    Me.tren.BorrarTren()
                    ListBoxTren.Items.RemoveAt(ListBoxTren.SelectedIndex)
                    CajaMatricula.Text = ""
                    CBTrenes.Items.Remove(Me.tren.matricula)
                    ComBoxEligeTren.Items.Remove(Me.tren.matricula)
                    MessageBox.Show("El tren ha sido borrado con éxito.")

                End If
            Catch ex As OleDbException
                MessageBox.Show("Error. No se puede borrar el Tren ya que existen registros de el en otra tablas. ")
            End Try
            LimpiarTextoFormularioGeneral(GBTren)
        End If
    End Sub

    Private Sub BtCancelarTren_Click(sender As Object, e As EventArgs) Handles BtCancelarTren.Click
        Me.estadotipotrenes = -1
        CajaMatricula.Text = ""
        BtInsertarTren.Enabled = True
        BtModificarTren.Enabled = True
        BtBorrarTren.Enabled = True
        GBAñadirTren.Enabled = False
        GBTren.Enabled = False
        LimpiarTextoFormularioGeneral(GBTren)
    End Sub

    Private Sub BtLimpiarTren_Click(sender As Object, e As EventArgs) Handles BtLimpiarTren.Click
        LimpiarTextoFormularioGeneral(GBTren)
    End Sub

    Private Sub BtGuardarTren_Click(sender As Object, e As EventArgs) Handles BtGuardarTren.Click

        If (CajaMatricula.Text.Trim = "" Or CBTipoTren.SelectedItem Is Nothing) Then 'hacer para cuando estan vacias las cajas y le das a guardar que no se pueda
            MsgBox("Debe rellenar todos los campos.", vbExclamation)
        Else
            If (CajaMatricula.Text = "") Then
                MsgBox("ERROR.Debe rellenar todos los campos.", vbExclamation)

            Else
                Dim tipTren As Tipos_Tren
                tipTren = New Tipos_Tren()
                Dim matTren As String
                Dim tr As Tren
                matTren = CajaMatricula.Text.ToUpper.Trim()
                tipTren.idttren = CBTipoTren.SelectedItem
                tipTren.LeerTip_tren()
                tr = New Tren(matTren, tipTren)
                Dim vale As Boolean
                vale = True

                If Me.estadotrenes = 0 Then 'Añadir un nuevo tren'
                    tren = New Tren
                    tren.LeerTodosTrenes()

                    For Each t As Tren In tren.trenDAO.listatrenes
                        If (tr.matricula = t.matricula) Then
                            vale = False
                        End If
                    Next
                    If vale = True Then
                        tr.InsertarTren()
                        ListBoxTren.Items.Add(tr.matricula)
                        CBTrenes.Items.Add(tr.matricula)
                        ComBoxEligeTren.Items.Add(tr.matricula)
                        MessageBox.Show("El tren se ha insertado correctamente.")
                    End If

                    If vale = False Then
                        MsgBox("No puedes añadir este tren, ya existe uno con esa matricula.")
                    End If

                ElseIf Me.estadotrenes = 1 Then 'Editar un tren ya existente'
                    Dim indice As Integer
                    Try
                        Dim actualizar As Integer
                        Me.trenedi.tipotren = tipTren
                        Me.trenedi.matricula = matTren
                        actualizar = trenedi.ActualizarTren
                        If (actualizar = 0) Then
                            MessageBox.Show("Error. No se pudo modificar. ")
                        Else
                            MessageBox.Show("Tren modificado con exito. ")
                            indice = ListBoxTren.SelectedIndex
                            ListBoxTren.Items.RemoveAt(indice)
                            ListBoxTren.Items.Insert(indice, Me.trenedi.matricula)

                        End If
                    Catch

                    End Try
                End If

                GBAñadirTren.Enabled = False
                GBTren.Enabled = False
                BtInsertarTren.Enabled = True
                BtModificarTren.Enabled = True
                BtBorrarTren.Enabled = True
                CajaMatricula.Text = ""
                ListBoxTren.SelectedItem = Nothing

            End If
        End If

    End Sub
    Private Sub generarFichaTren(t As Tren)
        CajaMatricula.Text = t.matricula
        CBTipoTren.Text = t.tipotren.idttren
    End Sub
    Private Sub ListBoxTren_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxTren.SelectedIndexChanged
        If ListBoxTren.SelectedItem IsNot Nothing Then
            BtBorrarTren.Enabled = True
            BtModificarTren.Enabled = True
            BtInsertarTren.Enabled = True


            Dim matricula As String = ListBoxTren.SelectedItem
            Dim tren As Tren
            tren = New Tren()

            tren.matricula = matricula
            tren.LeerTren()

            Me.tren = tren
            Me.trenedi = tren
            generarFichaTren(tren)



        Else
            BtBorrarTren.Enabled = False
            BtModificarTren.Enabled = False
        End If
        BtBorrarTren.Enabled = True
        BtModificarTren.Enabled = True
    End Sub

    Private Sub BtInsPro_Click(sender As Object, e As EventArgs) Handles BtInsPro.Click
        Me.estadopro = 0
        Dim pro As Producto
        pro = New Producto
        pro.LeerTodosProductos()
        GBAñadirPro.Enabled = True
        GBProducto.Enabled = True
        CajaDesPro.Text = " "
        BtInsPro.Enabled = False
        BtModPro.Enabled = False
        BtBorrarPro.Enabled = False
    End Sub

    Private Sub BtModPro_Click(sender As Object, e As EventArgs) Handles BtModPro.Click
        If ListBoxProductos.SelectedItem Is Nothing Then
            MsgBox("ERROR.No has seleccionado ningun Producto.")
        Else
            Me.estadopro = 1
            CajaDesPro.Text = Me.producto.des_pro
            GBAñadirPro.Enabled = True
            GBProducto.Enabled = True
            BtInsPro.Enabled = False
            BtModPro.Enabled = False
            BtBorrarPro.Enabled = False
        End If
    End Sub

    Private Sub BtBorrarPro_Click(sender As Object, e As EventArgs) Handles BtBorrarPro.Click
        If ListBoxProductos.SelectedItem Is Nothing Then
            MsgBox("ERROR.No has seleccionado ningun Producto.")
        Else
            Try
                Dim borrar As Integer
                borrar = MsgBox("¿Esta seguro de que desea eliminar el producto seleccionado? ", +vbYesNo + vbDefaultButton2, "Eliminar Producto.")
                If (borrar = vbYes) Then
                    Me.producto.BorrarProducto()
                    ListBoxProductos.Items.RemoveAt(ListBoxProductos.SelectedIndex)

                    CajaDesPro.Text = ""
                    ComboProductos.Items.Remove(Me.producto.id_producto)
                    CBProductos.Items.Remove(Me.producto.id_producto)
                    MessageBox.Show("El producto ha sido borrado con éxito.")
                End If
            Catch ex As OleDbException
                MessageBox.Show("Error. No se puede borrar el Producto ya que existen registros de el en otra tablas. ")
            End Try
            LimpiarTextoFormularioGeneral(GBProducto)
        End If
    End Sub

    Private Sub BtCancelarPro_Click(sender As Object, e As EventArgs) Handles BtCancelarPro.Click
        Me.estadopro = -1
        CajaDesPro.Text = ""
        BtInsPro.Enabled = True
        BtModPro.Enabled = True
        BtBorrarPro.Enabled = True
        GBAñadirPro.Enabled = False
        GBProducto.Enabled = False
        LimpiarTextoFormularioGeneral(GBProducto)
    End Sub

    Private Sub BtLimpiarPro_Click(sender As Object, e As EventArgs) Handles BtLimpiarPro.Click
        LimpiarTextoFormularioGeneral(GBProducto)
    End Sub

    Private Sub BtGuardarPro_Click(sender As Object, e As EventArgs) Handles BtGuardarPro.Click
        If CajaDesPro.Text.Trim = "" Then
            MsgBox("Debe de introducir la descripcion del producto.", vbExclamation)
        ElseIf Not (comprobarNombre(CajaDesTipTren.Text)) Then
            MsgBox("La descripción solo puede contener letras y espacios.", vbExclamation)

        Else
            Dim descPro As String
            Dim p As Producto
            descPro = CajaDesPro.Text().Trim()
            descPro = descPro.Substring(0, 1).ToUpper + descPro.Substring(1, descPro.Length - 1).ToLower

            p = New Producto(descPro)

            If Me.estadopro = 0 Then 'Añadir un nuevo producto'
                p.InsertarProducto()
                p.LeerID()
                ListBoxProductos.Items.Add(p.id_producto & " " & p.des_pro)
                ComboProductos.Items.Add(p.id_producto)
                CBProductos.Items.Add(p.id_producto)
                MessageBox.Show("El producto ha sido insertado con éxito.")

            ElseIf Me.estadopro = 1 Then 'Editar un producto ya existente'
                Dim indice As Integer
                Try
                    Dim actualizar As Integer
                    Me.productoedi.des_pro = descPro
                    actualizar = productoedi.ActualizarProducto
                    If (actualizar = 0) Then
                        MessageBox.Show("Error. No se pudo modificar. ")
                    Else
                        MessageBox.Show("Producto modificado con exito. ")
                        indice = ListBoxProductos.SelectedIndex
                        ListBoxProductos.Items.RemoveAt(indice)
                        ListBoxProductos.Items.Insert(indice, Me.productoedi.id_producto & " " & Me.productoedi.des_pro)

                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, ex.Source)
                End Try
            End If

            GBAñadirPro.Enabled = False
            GBProducto.Enabled = False
            BtInsPro.Enabled = True
            CajaDesPro.Text = ""
            ListBoxProductos.SelectedItem = Nothing

        End If
    End Sub
    Private Sub generarFichaProducto(p As Producto)
        CajaDesPro.Text = p.des_pro

    End Sub
    Private Sub ListBoxProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxProductos.SelectedIndexChanged
        If ListBoxProductos.SelectedItem IsNot Nothing Then
            BtInsPro.Enabled = True
            BtModPro.Enabled = True
            BtBorrarPro.Enabled = True

            Dim split As String() = ListBoxProductos.SelectedItem.ToString().Split(New [Char]() {" "c})
            Dim id As Integer
            id = CInt(split(0))

            Dim p As Producto
            p = New Producto()

            p.id_producto = id
            p.Leerproducto()

            Me.producto = p
            Me.productoedi = p
            generarFichaProducto(p)



        Else
            BtModPro.Enabled = False
            BtBorrarPro.Enabled = False
        End If
        BtModPro.Enabled = True
        BtBorrarPro.Enabled = True
    End Sub

    Private Sub BtInsCot_Click(sender As Object, e As EventArgs) Handles BtInsCot.Click
        CBProductos.ResetText()
        Me.estadocot = 0
        Dim c As Cotización
        c = New Cotización
        c.LeerTodasCotizaciones()
        GBAñadirCot.Enabled = True
        GBCotización.Enabled = True
        CBProductos.Enabled = True
        DateTimePickerCot.Enabled = True
        CajaEurTon.Text = ""
        BtInsCot.Enabled = False
        BtModCot.Enabled = False
        BtBorrarCot.Enabled = False
    End Sub

    Private Sub BtModCot_Click(sender As Object, e As EventArgs) Handles BtModCot.Click
        If ListBoxCotizaciones.SelectedItem Is Nothing Then
            MsgBox("ERROR.No has seleccionado ninguna Cotización.")
        Else
            Me.estadocot = 1
            DateTimePickerCot.Text = Me.cotizacion.fecha
            CajaEurTon.Text = Me.cotizacion.eur_ton
            GBAñadirCot.Enabled = True
            GBCotización.Enabled = True
            BtInsCot.Enabled = False
            BtModCot.Enabled = False
            BtBorrarCot.Enabled = False
            CBProductos.Enabled = False
            DateTimePickerCot.Enabled = False
        End If
    End Sub

    Private Sub BtBorrarCot_Click(sender As Object, e As EventArgs) Handles BtBorrarCot.Click
        If ListBoxCotizaciones.SelectedItem Is Nothing Then
            MsgBox("ERROR.No has seleccionado ninguna Cotización.")
        Else
            Dim borrar As Integer
            borrar = MsgBox("¿Esta seguro de que desea eliminar la cotizacion seleccionada? ", +vbYesNo + vbDefaultButton2, "Eliminar cotizacion.")
            If (borrar = vbYes) Then
                Me.cotizacion.BorrarCotizacion()
                ListBoxCotizaciones.Items.RemoveAt(ListBoxCotizaciones.SelectedIndex)
                CajaEurTon.Text = ""
                DateTimePickerCot.Text = ""
                MessageBox.Show("Cotización borrada con éxito.")
            End If
            LimpiarTextoFormularioGeneral(GBCotización)
        End If
    End Sub

    Private Sub BtCancelarCot_Click(sender As Object, e As EventArgs) Handles BtCancelarCot.Click
        Me.estadocot = -1
        CajaEurTon.Text = ""
        BtInsCot.Enabled = True
        BtModCot.Enabled = True
        BtBorrarCot.Enabled = True
        GBAñadirCot.Enabled = False
        GBCotización.Enabled = False
        LimpiarTextoFormularioGeneral(GBCotización)
    End Sub

    Private Sub BtLimpiarCot_Click(sender As Object, e As EventArgs) Handles BtLimpiarCot.Click
        LimpiarTextoFormularioGeneral(GBCotización)
    End Sub

    Private Sub BtGuardarCot_Click(sender As Object, e As EventArgs) Handles BtGuardarCot.Click
        If DateTimePickerCot.Text = "" Or CajaEurTon.Text.Trim = "" Or CBProductos.SelectedItem Is Nothing Then
            MsgBox("Introduzca la fecha y euros por tonelada del producto", vbExclamation)

        Else
            Dim eurton As Double
            Dim fecha As Date
            Dim pro As Producto
            pro = New Producto()
            Dim cot As Cotización
            eurton = CajaEurTon.Text
            fecha = DateTimePickerCot.Text
            pro.id_producto = CBProductos.SelectedItem
            pro.Leerproducto()

            cot = New Cotización(pro, fecha, eurton)


            Dim vale As Boolean
            vale = True

            If Me.estadocot = 0 Then 'Añadir una cotizacion nueva
                cotizacion = New Cotización()
                cotizacion.LeerTodasCotizaciones()
                For Each c As Cotización In cotizacion.CotizacionDAO.listacotizaciones
                    If (cot.producto.id_producto = c.producto.id_producto And cot.fecha = c.fecha) Then
                        vale = False
                    End If
                Next
                If vale = True Then
                    cot.InsertarCotizacion()
                    ListBoxCotizaciones.Items.Add(cot.producto.id_producto & " " & cot.fecha)
                    MessageBox.Show("Ha insertado la cotización correctamente. ")
                End If

                If vale = False Then
                    MessageBox.Show("No puedes añadir esta cotización, ya existe una para el producto seleccionado para la misma fecha.")
                End If

            ElseIf Me.estadocot = 1 Then 'Editar una cotizacion ya existente'

                Dim indice As Integer
                Try
                    Dim actualizar As Integer

                    Me.cotiedi.eur_ton = eurton

                    actualizar = cotiedi.ActualizarCotizacion
                    If (actualizar = 0) Then
                        MessageBox.Show("Error. No se pudo modificar. ")
                    Else
                        MessageBox.Show("Cotizacion modificada con exito. ")
                        indice = ListBoxCotizaciones.SelectedIndex
                            ListBoxCotizaciones.Items.RemoveAt(indice)
                        ListBoxCotizaciones.Items.Insert(indice, Me.cotiedi.producto.id_producto & " " & Me.cotiedi.fecha)
                    End If

                Catch

                End Try
            End If

            GBAñadirCot.Enabled = False
            GBCotización.Enabled = False
            BtInsCot.Enabled = True
            BtModCot.Enabled = True
            BtBorrarCot.Enabled = True
            CajaEurTon.Text = ""
            ListBoxCotizaciones.SelectedItem = Nothing

        End If
    End Sub
    Private Sub generarFichaCot(c As Cotización)
        CBProductos.Text = c.producto.id_producto
        DateTimePickerCot.Text = c.fecha
        CajaEurTon.Text = c.eur_ton

    End Sub
    Private Sub ListBoxCotizaciones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxCotizaciones.SelectedIndexChanged
        If ListBoxCotizaciones.SelectedItem IsNot Nothing Then
            BtInsCot.Enabled = True
            BtModCot.Enabled = True
            BtBorrarCot.Enabled = True

            Dim split As String() = ListBoxCotizaciones.SelectedItem.ToString().Split(New [Char]() {" "c})

            Dim producto As Producto
            producto = New Producto()

            Dim fecha As Date

            producto.id_producto = CInt(split(0))
            fecha = CDate(split(1))

            producto.Leerproducto()

            Dim cot As Cotización
            cot = New Cotización()

            cot.producto = producto
            cot.fecha = fecha
            cot.LeerCotizacion()

            Me.cotizacion = cot
            Me.cotiedi = cot
            generarFichaCot(cot)



        Else
            BtModCot.Enabled = False
            BtBorrarCot.Enabled = False
        End If
        BtModCot.Enabled = True
        BtBorrarCot.Enabled = True
    End Sub

    Private Sub BotonInsertar_Click(sender As Object, e As EventArgs) Handles BotonInsViaje.Click
        Me.estadoviaje = 0
        Dim v As Viaje
        v = New Viaje
        v.LeerTodosViajes()
        GBAñadirViajes.Enabled = True
        GBViajes.Enabled = True
        DateTimePickerViaje.Enabled = True
        CBTrenes.Enabled = True
        ComboProductos.Enabled = True
        CajaToneladasViaje.Text = ""
        BotonInsViaje.Enabled = False
        BotonBorrarViaje.Enabled = False
        BotonModViaje.Enabled = False
    End Sub

    Private Sub BotonModViaje_Click(sender As Object, e As EventArgs) Handles BotonModViaje.Click
        If ListBoxViajes.SelectedItem Is Nothing Then
            MessageBox.Show("ERROR.No has seleccionado ningun Viaje.")
        Else
            Me.estadoviaje = 1
            CajaToneladasViaje.Text = Me.viaje.cantidad
            GBAñadirViajes.Enabled = True
            GBViajes.Enabled = True
            BotonInsViaje.Enabled = False
            BotonModViaje.Enabled = False
            BotonBorrarViaje.Enabled = False
            DateTimePickerViaje.Enabled = False
            CBTrenes.Enabled = False
            ComboProductos.Enabled = False
        End If
    End Sub

    Private Sub BotonBorrarViaje_Click(sender As Object, e As EventArgs) Handles BotonBorrarViaje.Click
        If ListBoxViajes.SelectedItem Is Nothing Then
            MsgBox("ERROR.No has seleccionado ningun Viaje.")
        Else
            Dim borrar As Integer
            borrar = MsgBox("¿Esta seguro de que desea eliminar el viaje seleccionado? ", +vbYesNo + vbDefaultButton2, "Eliminar viaje.")
            If (borrar = vbYes) Then
                Me.viaje.BorrarViaje()
                ListBoxViajes.Items.RemoveAt(ListBoxViajes.SelectedIndex)
                CajaToneladasViaje.Text = ""
                DateTimePickerViaje.Text = ""
                MessageBox.Show("Viaje boorado con éxito.")
            End If
            LimpiarTextoFormularioGeneral(GBViajes)
        End If
    End Sub
    Private Sub generarFichaViaje(v As Viaje)
        CBTrenes.Text = v.tren.matricula
        ComboProductos.Text = v.producto.id_producto
        DateTimePickerViaje.Text = v.fecha_viaje
        CajaToneladasViaje.Text = v.cantidad
    End Sub

    Private Sub ListBoxViajes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxViajes.SelectedIndexChanged
        If ListBoxViajes.SelectedItem IsNot Nothing Then
            BotonInsViaje.Enabled = True
            BotonModViaje.Enabled = True
            BotonBorrarViaje.Enabled = True

            Dim split As String() = ListBoxViajes.SelectedItem.ToString().Split(New [Char]() {" "c})
            Dim producto As Producto
            Dim fecha As Date
            Dim tren As Tren

            producto = New Producto()
            tren = New Tren()

            fecha = CDate(split(0))
            tren.matricula = CStr(split(1)).Trim()
            producto.id_producto = CInt(split(2))



            Dim v As Viaje
            v = New Viaje()

            v.fecha_viaje = fecha
            v.tren = tren
            v.producto = producto
            v.LeerViaje()

            Me.viaje = v
            Me.viajeedi = v
            generarFichaViaje(v)



        Else
            BotonModViaje.Enabled = False
            BotonBorrarViaje.Enabled = False
        End If
        BotonModViaje.Enabled = True
        BotonBorrarViaje.Enabled = True
    End Sub

    Private Sub BtCancelarViaje_Click(sender As Object, e As EventArgs) Handles BtCancelarViaje.Click
        Me.estadoviaje = -1
        CajaToneladasViaje.Text = ""
        BotonInsViaje.Enabled = True
        BotonModViaje.Enabled = True
        BotonBorrarViaje.Enabled = True
        GBAñadirViajes.Enabled = False
        GBViajes.Enabled = False
        ListBoxViajes.SelectedItem = Nothing
        LimpiarTextoFormularioGeneral(GBViajes)
    End Sub

    Private Sub BtLimpiarViaje_Click(sender As Object, e As EventArgs) Handles BtLimpiarViaje.Click
        LimpiarTextoFormularioGeneral(GBViajes)
    End Sub

    Private Sub BtGuardarViaje_Click(sender As Object, e As EventArgs) Handles BtGuardarViaje.Click
        If DateTimePickerViaje.Text = "" Or CajaToneladasViaje.Text.Trim = "" Or ComboProductos.SelectedItem Is Nothing Or CBTrenes.SelectedItem Is Nothing Then
            MessageBox.Show("Debe de rellenar todos los campos. ")

        Else
            Dim toneladas As Integer
            Dim fecha As Date
            Dim pro As Producto
            Dim tren As Tren
            Dim v As Viaje
            Dim o As Tipos_Tren 'tipo de tren que realiza el viaje

            pro = New Producto()
            tren = New Tren()

            toneladas = CajaToneladasViaje.Text
            fecha = DateTimePickerViaje.Text.Trim
            pro.id_producto = ComboProductos.SelectedItem
            tren.matricula = CBTrenes.SelectedItem

            tren.LeerTren()
            pro.Leerproducto()


            o = New Tipos_Tren()
            o.idttren = tren.tipotren.idttren
            o.LeerTip_tren() 'leemos el tipo de tren que es 



            v = New Viaje("#" & fecha.Day & "/" & fecha.Month & "/" & fecha.Year & "#", tren, pro, toneladas)

            Dim vale As Boolean 'esta variable la usaremos para ver si se puede insertar el nuevo viaje
            vale = True

            If Me.estadoviaje = 0 Then 'se ha pulsado la opcion de Añadir un nuevo viaje'
                viaje = New Viaje
                viaje.LeerTodosViajes() 'obtenemos todos los viajes para comparar en el siguiente for
                For Each via As Viaje In viaje.viajesDAO.listaviajes 'este for recorrera todos los viajes leidos
                    If (v.tren.matricula = via.tren.matricula And v.fecha_viaje = via.fecha_viaje) Then 'y comparamos si existe un viaje con el mismo tren y fecha
                        vale = False 'si se hay un viaje con mismo tren y fecha, no podremos añadir el nuevo viaje, vale=false
                        MessageBox.Show("No se puede añadir este viaje, el tren ya tiene uno asignado para esa fecha.")
                    End If
                Next

                If (v.cantidad > o.capmax) Then 'comparamos tambien si la candidad de toneladas del viaje no supera la capacidad maxima del tren
                    vale = False 'si supera la capacidad maxima del tren, no se podra añadir, vale = false
                    MessageBox.Show("No puedes introducir una carga mayor de la que el tren puede transportar.")
                End If

                If (vale = True) Then 'si vale = true, quiere decir que el viaje se puede insertar
                    v.InsertarViaje()
                    ListBoxViajes.Items.Add(v.fecha_viaje & " " & v.tren.matricula & " " & v.producto.id_producto)
                    MessageBox.Show("El viaje ha sido insertado con éxito.")
                End If

            ElseIf Me.estadoviaje = 1 Then 'se ha pulsado la opcion de Editar un viaje ya existente'
                Dim indice As Integer
                Try
                    Dim actualizar As Integer
                    Me.viajeedi.producto = pro
                    Me.viajeedi.tren = tren
                    Me.viajeedi.cantidad = toneladas
                    Me.viaje.fecha_viaje = fecha

                    If (v.cantidad > o.capmax) Then 'comparamos tambien si la candidad de toneladas del viaje no supera la capacidad maxima del tren
                        vale = False
                        MessageBox.Show("No se puede modificar. No puedes introducir una carga mayor de la que el tren puede transportar.")
                        'si la supera, mostrara un mensaje de que no puede modificarse.'
                    End If

                    If (vale = True) Then 'si no supera la capacidad maxima, si se puede modificar
                        actualizar = viajeedi.ActualizarViaje
                        If (actualizar = 0) Then
                            MessageBox.Show("Error. No se pudo modificar.")
                        Else
                            MessageBox.Show("Viaje modificado con exito. ")
                            indice = ListBoxViajes.SelectedIndex
                            ListBoxViajes.Items.RemoveAt(indice)
                            ListBoxViajes.Items.Insert(indice, Me.viaje.fecha_viaje & " " & Me.viajeedi.tren.matricula & " " & Me.viajeedi.producto.id_producto)
                        End If
                    End If

                Catch

                End Try
            End If

            GBAñadirViajes.Enabled = False
            GBViajes.Enabled = False
            BotonInsViaje.Enabled = True
            CajaToneladasViaje.Text = ""
            ListBoxViajes.SelectedItem = Nothing
        End If
    End Sub


    Private Sub BotonConsulta1_Click(sender As Object, e As EventArgs) Handles BotonConsulta1.Click
        ListBoxConsulta1.Items.Clear()
        TextBoxNumViajes.Text = ""
        If ComBoxEligeTren.SelectedItem Is Nothing Then
            MsgBox("ERROR.No has seleccionado ningún Tren.")
        Else
            Dim matricula As String = ComBoxEligeTren.SelectedItem
            Dim fecha1 As Date = DateTimePickerFecha1.Text()
            Dim fecha2 As Date = DateTimePickerFecha2.Text()

            If (fecha1 >= fecha2) Then
                MsgBox("La fecha inicial debe ser menor a la fecha final.")
            Else
                tren = New Tren()

                tren.matricula = matricula
                tren.LeerTren()

                tren.ConsultaListaProductos(fecha1, fecha2)
                tren.ConsultaNumViajes(fecha1, fecha2)




                For Each a As String In tren.trenDAO.listaConsulta1()
                    ListBoxConsulta1.Items.Add(a)
                Next



                For Each a As Integer In tren.trenDAO.numViajes
                    TextBoxNumViajes.Text = a
                Next

            End If
        End If
    End Sub

    Private Sub BotonConsulta2_Click(sender As Object, e As EventArgs) Handles BotonConsulta2.Click
        ListBoxConsulta2.Items.Clear()

        Dim fecha1 As Date = DatTimPickfech1.Text
        Dim fecha2 As Date = DatTimPickfech2.Text

        If (fecha1 >= fecha2) Then
            MsgBox("La fecha inicial debe ser menor a la fecha final.")
        Else
            tipotren = New Tipos_Tren()
            tipotren.LeerTodosTip_trenes()

            tipotren.ConsultaRankingTrenes(fecha1, fecha2)

            For Each b As String In tipotren.t_trenDAO.listaConsulta2
                ListBoxConsulta2.Items.Add(b)
            Next

        End If

    End Sub

    Private Sub BotonConsulta3_Click(sender As Object, e As EventArgs) Handles BotonConsulta3.Click
        ListBoxConsulta3.Items.Clear()

        Dim fecha1 As Date = DateTimPicker1.Text
        Dim fecha2 As Date = DateTimPicker2.Text

        If (fecha1 >= fecha2) Then
            MsgBox("La fecha inicial debe ser menor a la fecha final.")
        Else
            producto = New Producto()
            producto.LeerTodosProductos()
            producto.ConsultaRankingProductos(fecha1, fecha2)


            For Each b As String In producto.productosDAO.listaConsulta3
                ListBoxConsulta3.Items.Add(b)
            Next

        End If
    End Sub

    Private Sub BotonConsulta4_Click(sender As Object, e As EventArgs) Handles BotonConsulta4.Click


        viaje = New Viaje()
        viaje.LeerTodosViajes()
        viaje.consulta4()

        For Each b As String In viaje.viajesDAO.viajeMaxBeneficio
            Dim split As String() = b.Split(New [Char]() {" "c})
            tbfecha.Text = split(0)
            tbtren.Text = split(1)
            tbtipotren.Text = split(2)
            tbproducto.Text = split(3)
            tbtoneladas.Text = split(4)
            tbeurostoneladas.Text = (split(5) & " €/T")
            tbbeneficio.Text = (split(6) & " €")
        Next
    End Sub

    Private Sub CajaToneladasViaje_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CajaToneladasViaje.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
        If Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            MsgBox("Solo puedes escribir numeros")
        End If
    End Sub

    Private Sub CajaCapacidadMaxima_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CajaCapacidadMaxima.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
        If Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            MsgBox("Solo puedes escribir numeros")
        End If
    End Sub

    Private Sub CajaEurTon_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CajaEurTon.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
        If Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            MsgBox("Solo puedes escribir numeros")
        End If
    End Sub
End Class