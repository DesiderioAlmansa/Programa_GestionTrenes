Public Class Viaje
    Private _Fecha_viaje As Date
    Private _Tren As Tren
    Private _Producto As Producto
    Private _Cantidad As Integer

    Private _ViajeDAO As ViajesDAO
    Private _trenes As Collection
    Private _productos As Collection

    Private _viajeMaxBeneficio As Collection

    Sub New()
        Me._ViajeDAO = New ViajesDAO
        Me._trenes = New Collection
        Me._productos = New Collection
        Me._viajeMaxBeneficio = New Collection
    End Sub
    Sub New(f_viaje As Date, tren As Tren, pro As Producto, can As Integer)
        Me._Fecha_viaje = f_viaje
        Me._Tren = tren
        Me._Producto = pro
        Me._Cantidad = can
        Me._ViajeDAO = New ViajesDAO
        Me._trenes = New Collection
        Me._productos = New Collection
        Me._viajeMaxBeneficio = New Collection

    End Sub
    Sub New(can As Integer)
        Me._Cantidad = can
        Me._ViajeDAO = New ViajesDAO
        Me._trenes = New Collection
        Me._productos = New Collection
        Me._viajeMaxBeneficio = New Collection

    End Sub

    Public Sub consulta4()
        Me.viajesDAO.consulta4ViajeMaxBeneficio()
    End Sub
    Public Sub LeerTodosViajes()
        Me._ViajeDAO.LeerTodas()
    End Sub


    Public Sub LeerViaje()
        Me._ViajeDAO.Leer(Me)
    End Sub

    Public Function InsertarViaje() As Integer
        Return Me._ViajeDAO.Insertar(Me)
    End Function

    Public Function ActualizarViaje() As Integer
        Return Me._ViajeDAO.Actualizar(Me)
    End Function

    Public Function BorrarViaje() As Integer
        Return Me._ViajeDAO.Borrar(Me)
    End Function

    Public Property viajeMaxBeneficio As Collection
        Get
            Return Me._viajeMaxBeneficio
        End Get
        Set(value As Collection)

        End Set
    End Property
    Public Property productos As Collection
        Get
            Return Me._productos
        End Get
        Set(value As Collection)

        End Set
    End Property
    Public Property trenes As Collection
        Get
            Return Me._trenes
        End Get
        Set(value As Collection)

        End Set
    End Property
    Public Property viajesDAO As ViajesDAO
        Get
            Return Me._ViajeDAO
        End Get
        Set(value As ViajesDAO)

        End Set
    End Property
    Public Property tren As Tren
        Get
            Return Me._Tren
        End Get
        Set(value As Tren)
            Me._Tren = value
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
    Public Property fecha_viaje As Date
        Get
            Return Me._Fecha_viaje
        End Get
        Set(value As Date)
            Me._Fecha_viaje = value
        End Set
    End Property
    Public Property cantidad As Integer
        Get
            Return Me._Cantidad
        End Get
        Set(value As Integer)
            Me._Cantidad = value
        End Set
    End Property
End Class
