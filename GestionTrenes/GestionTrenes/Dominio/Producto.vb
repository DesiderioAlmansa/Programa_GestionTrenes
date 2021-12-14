Public Class Producto
    Private _IDProducto As Integer
    Private _DesPro As String

    Private _ProductoDAO As ProductosDAO
    Private _cotizaciones As Collection
    Private _viajes As Collection
    Private _consulta3 As Collection

    Sub New(id_pro As String, despro As String)
        Me._IDProducto = id_pro
        Me._DesPro = despro
        Me._ProductoDAO = New ProductosDAO
        Me._cotizaciones = New Collection
        Me._viajes = New Collection
        Me._consulta3 = New Collection
    End Sub
    Sub New(despro As String)
        Me._DesPro = despro
        Me._ProductoDAO = New ProductosDAO
        Me._cotizaciones = New Collection
        Me._viajes = New Collection
        Me._consulta3 = New Collection
    End Sub
    Sub New()
        Me._ProductoDAO = New ProductosDAO
        Me._cotizaciones = New Collection
        Me._viajes = New Collection
        Me._consulta3 = New Collection
    End Sub
    Public Property Cotizaciones As Collection
        Get
            Return Me._cotizaciones
        End Get
        Set(value As Collection)

        End Set
    End Property
    Public Property listaConsulta3 As Collection
        Get
            Return Me._consulta3
        End Get
        Set(value As Collection)

        End Set
    End Property
    Public Property viajes As Collection
        Get
            Return Me._viajes
        End Get
        Set(value As Collection)

        End Set
    End Property
    Public Property productosDAO As ProductosDAO
        Get
            Return Me._ProductoDAO
        End Get
        Set(value As ProductosDAO)

        End Set
    End Property
    Public Property id_producto As Integer
        Get
            Return Me._IDProducto
        End Get
        Set(value As Integer)
            Me._IDProducto = value
        End Set
    End Property
    Public Property des_pro As String
        Get
            Return Me._DesPro
        End Get
        Set(value As String)
            Me._DesPro = value
        End Set
    End Property

    Public Sub LeerTodosProductos()
        Me._ProductoDAO.LeerTodas()
    End Sub

    Public Sub Leerproducto()
        Me._ProductoDAO.Leer(Me)

    End Sub
    Public Sub LeerID()
        Me._ProductoDAO.readID(Me)

    End Sub
    Public Sub ConsultaRankingProductos(ByRef fecha1 As Date, ByRef fecha2 As Date)
        Me._ProductoDAO.consultaListaProductos(Me, fecha1, fecha2)
    End Sub

    Public Function InsertarProducto() As Integer
        Return Me._ProductoDAO.Insertar(Me)
    End Function

    Public Function ActualizarProducto() As Integer
        Return Me._ProductoDAO.Actualizar(Me)
    End Function

    Public Function BorrarProducto() As Integer
        Return Me._ProductoDAO.Borrar(Me)
    End Function


End Class
