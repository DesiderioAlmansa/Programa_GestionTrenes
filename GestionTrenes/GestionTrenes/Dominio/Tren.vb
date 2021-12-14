Public Class Tren
    Private _matricula As String
    Private _t_tren As Tipos_Tren

    Private _TrenDAO As TrenesDAO
    Private _viajes As Collection
    Private _consulta1 As Collection
    Private _numViajes As Collection


    Sub New(ttren As Tipos_Tren)
        Me._t_tren = ttren
        Me._TrenDAO = New TrenesDAO
        Me._viajes = New Collection
        Me._numViajes = New Collection
    End Sub
    Sub New(mat As String, ttren As Tipos_Tren)
        Me._matricula = mat
        Me._t_tren = ttren
        Me._TrenDAO = New TrenesDAO
        Me._viajes = New Collection
        Me._consulta1 = New Collection
        Me._numViajes = New Collection
    End Sub
    Sub New()
        Me._TrenDAO = New TrenesDAO
        Me._viajes = New Collection
        Me._consulta1 = New Collection
        Me._numViajes = New Collection
    End Sub
    Public Property matricula As String
        Get
            Return Me._matricula
        End Get
        Set(value As String)
            Me._matricula = value
        End Set
    End Property

    Public Property numViajes As Collection
        Get
            Return Me._numViajes
        End Get
        Set(value As Collection)

        End Set
    End Property
    Public Property listaConsulta1 As Collection
        Get
            Return Me._consulta1
        End Get
        Set(value As Collection)

        End Set
    End Property
    Public Property tipotren As Tipos_Tren
        Get
            Return Me._t_tren
        End Get
        Set(value As Tipos_Tren)
            Me._t_tren = value
        End Set
    End Property
    Public Property trenDAO As TrenesDAO
        Get
            Return Me._TrenDAO
        End Get
        Set(value As TrenesDAO)

        End Set
    End Property
    Public Property viajes As Collection
        Get
            Return Me._viajes
        End Get
        Set(value As Collection)

        End Set
    End Property
    Public Sub ConsultaListaProductos(ByRef fecha1 As Date, ByRef fecha2 As Date)
        Me._TrenDAO.consulta1ListaProductos(Me, fecha1, fecha2)
    End Sub

    Public Sub ConsultaNumViajes(ByRef fecha1 As Date, ByRef fecha2 As Date)
        Me._TrenDAO.consultaNumViajes(Me, fecha1, fecha2)
    End Sub

  

    Public Sub LeerTodosTrenes()
        Me._TrenDAO.LeerTodas()
    End Sub

    Public Sub LeerTren()
        Me._TrenDAO.Leer(Me)

    End Sub
    Public Sub leerMatricula()
        Me._TrenDAO.readmatricula(Me)
    End Sub

    Public Function InsertarTren() As Integer
        Return Me._TrenDAO.Insertar(Me)
    End Function

    Public Function ActualizarTren() As Integer
        Return Me._TrenDAO.Actualizar(Me)
    End Function

    Public Function BorrarTren() As Integer
        Return Me._TrenDAO.Borrar(Me)
    End Function
End Class
