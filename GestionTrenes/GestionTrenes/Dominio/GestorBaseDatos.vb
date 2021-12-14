Public Class GestorBaseDatos
    Public Sub New()
        comprobarbbdd()

    End Sub

    Public Sub comprobarbbdd()
        leerViajes()
        leerTrenes()
        leerProductos()
        leerTiposTren()
        leerCotizaciones()
    End Sub

    Public Sub leerViajes()
        AgenteBD.ObtenerAgente().Leer("SELECT * FROM VIAJES")
    End Sub

    Public Sub leerTrenes()
        AgenteBD.ObtenerAgente().Leer("SELECT * FROM TRENES")
    End Sub
    Public Sub leerProductos()
        AgenteBD.ObtenerAgente().Leer("SELECT * FROM PRODUCTOS")
    End Sub

    Public Sub leerTiposTren()
        AgenteBD.ObtenerAgente().Leer("SELECT * FROM TIPOS_TREN")
    End Sub

    Public Sub leerCotizaciones()
        AgenteBD.ObtenerAgente().Leer("SELECT * FROM COTIZACIONES")
    End Sub
End Class
