Public Class Cotización
    Private _Producto As Producto
    Private _Fecha As Date
    Private _Eur_ton As Double

    Private _CotizacionDAO As CotizaciónDAO
    Sub New()
        Me._CotizacionDAO = New CotizaciónDAO
    End Sub
    Sub New(pro As Producto, fech As Date, eurton As Double)
        Me._Producto = pro
        Me._Fecha = fech
        Me._Eur_ton = eurton
        Me._CotizacionDAO = New CotizaciónDAO
    End Sub
    Sub New(eurton As Double)
        Me._Eur_ton = eurton
        Me._CotizacionDAO = New CotizaciónDAO
    End Sub
    Public Property CotizacionDAO As CotizaciónDAO
        Get
            Return Me._CotizacionDAO
        End Get
        Set(value As CotizaciónDAO)

        End Set
    End Property

    Public Property producto As Producto
        Get
            Return Me._Producto
        End Get
        Set(value As Producto)
            Me._Producto = value
        End Set
    End Property

    Public Property fecha As Date
        Get
            Return Me._Fecha
        End Get
        Set(value As Date)
            Me._Fecha = value
        End Set
    End Property
    Public Property eur_ton As Double
        Get
            Return Me._Eur_ton
        End Get
        Set(value As Double)
            Me._Eur_ton = value
        End Set
    End Property

    Public Sub LeerTodasCotizaciones()
        Me.CotizacionDAO.LeerTodas()
    End Sub

    Public Sub LeerCotizacion()
        Me.CotizacionDAO.Leer(Me)

    End Sub

    Public Function InsertarCotizacion() As Integer
        Return Me.CotizacionDAO.Insertar(Me)
    End Function

    Public Function ActualizarCotizacion() As Integer
        Return Me.CotizacionDAO.Actualizar(Me)
    End Function

    Public Function BorrarCotizacion() As Integer
        Return Me.CotizacionDAO.Borrar(Me)
    End Function
End Class
