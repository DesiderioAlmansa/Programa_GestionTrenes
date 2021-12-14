Public Class Tipos_Tren
    Private _IDTipo_Tren As Integer
    Private _Destren As String
    Private _Capmax As Integer

    Private _tiptrenDAO As Tipos_TrenDAO
    Private _trenes As Collection
    Private _consulta2 As Collection
    Sub New()
        Me._tiptrenDAO = New Tipos_TrenDAO
        Me._trenes = New Collection
        Me._consulta2 = New Collection
    End Sub
    Sub New(destren As String, capmax As Integer)
        Me._Destren = destren
        Me._Capmax = capmax
        Me._tiptrenDAO = New Tipos_TrenDAO
        Me._trenes = New Collection
        Me._consulta2 = New Collection
    End Sub
    Sub New(id_tren As Integer, destren As String, capmax As Integer)
        Me._IDTipo_Tren = id_tren
        Me._Destren = destren
        Me._Capmax = capmax
        Me._tiptrenDAO = New Tipos_TrenDAO
        Me._trenes = New Collection
        Me._consulta2 = New Collection
    End Sub
    Public Property listaConsulta2 As Collection
        Get
            Return Me._consulta2
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
    Public Property idttren As Integer
        Get
            Return Me._IDTipo_Tren
        End Get
        Set(value As Integer)
            Me._IDTipo_Tren = value
        End Set
    End Property
    Public Property destren As String
        Get
            Return Me._Destren
        End Get
        Set(value As String)
            Me._Destren = value
        End Set
    End Property
    Public Property capmax As Integer
        Get
            Return Me._Capmax
        End Get
        Set(value As Integer)
            Me._Capmax = value
        End Set
    End Property
    Public Property t_trenDAO As Tipos_TrenDAO
        Get
            Return Me._tiptrenDAO
        End Get
        Set(value As Tipos_TrenDAO)

        End Set
    End Property

    Public Sub LeerTodosTip_trenes()
        Me._tiptrenDAO.LeerTodas()
    End Sub

    Public Sub LeerTip_tren()
        Me._tiptrenDAO.Leer(Me)

    End Sub
    Public Sub leerID()
        Me._tiptrenDAO.readID(Me)
    End Sub

    Public Sub InsertarTip_tren()
        Me._tiptrenDAO.Insertar(Me)
    End Sub
    Public Sub ConsultaRankingTrenes(ByRef fecha1 As Date, ByRef fecha2 As Date)
        Me._tiptrenDAO.consultaListaTipoTren(Me, fecha1, fecha2)
    End Sub

    Public Function ActualizarTip_tren() As Integer
        Return Me._tiptrenDAO.Actualizar(Me)
    End Function

    Public Sub BorrarTip_tren()
        Me._tiptrenDAO.Borrar(Me)
    End Sub
End Class
