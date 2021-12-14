Imports System.Data.OleDb
Public Class TrenesDAO
    Private _trenes As Collection
    Private _listaConsulta1 As Collection
    Private _numViajes As Collection

    Public Sub New()
        Me._trenes = New Collection
        Me._listaConsulta1 = New Collection
        Me._numViajes = New Collection
    End Sub

    Public ReadOnly Property numViajes As Collection
        Get
            Return _numViajes
        End Get
    End Property
    Public ReadOnly Property listatrenes As Collection
        Get
            Return _trenes
        End Get
    End Property
    Public ReadOnly Property listaConsulta1 As Collection
        Get
            Return _listaConsulta1
        End Get
    End Property
    'consulta 1
    Public Sub consultaNumViajes(ByRef t As Tren, ByRef fecha1 As Date, ByRef fecha2 As Date)

        Dim lista As OleDbDataReader = AgenteBD.ObtenerAgente.Leer("SELECT COUNT(Tren) FROM VIAJES WHERE Tren='" & t.matricula & "' AND FechaViaje BETWEEN #" & Format(fecha1, "yyyy/MM/dd") & "# AND #" & Format(fecha2, "yyyy/MM/dd") & "# GROUP BY VIAJES.Tren;")
        Dim num As Integer
        While lista.Read()
            num = CInt(lista(0))
            Me.numViajes.Add(num)
        End While
    End Sub

    'consulta 1
    Public Sub consulta1ListaProductos(ByRef t As Tren, ByRef fecha1 As Date, ByRef fecha2 As Date)
        Dim lista As OleDbDataReader = AgenteBD.ObtenerAgente.Leer("SELECT VIAJES.Producto, PRODUCTOS.DescripProducto FROM VIAJES, PRODUCTOS  WHERE  VIAJES.Producto=PRODUCTOS.IdProducto AND VIAJES.FechaViaje BETWEEN #" & Format(fecha1, "yyyy/MM/dd") & "# AND #" & Format(fecha2, "yyyy/MM/dd") & "# AND VIAJES.Tren = '" & t.matricula & "' GROUP BY VIAJES.Producto , PRODUCTOS.DescripProducto;")
        Dim producto As String
        Dim desc As String
        While lista.Read
            producto = CStr(lista(0))
            desc = CStr(lista(1))
            Me.listaConsulta1.Add(" IDProducto: " & producto & " - Desc: " & desc)
        End While
    End Sub

    Public Sub LeerTodas()
        Dim lista As OleDbDataReader = AgenteBD.ObtenerAgente.Leer("SELECT * FROM TRENES ORDER BY Matricula")
        Dim t As Tren

        While lista.Read
            Dim tipo As Tipos_Tren
            tipo = New Tipos_Tren()

            tipo.idttren = lista(1)
            tipo.LeerTip_tren()

            t = New Tren(lista(0), tipo)
            Me.listatrenes.Add(t)
        End While
    End Sub
    Public Sub Leer(ByRef t As Tren)
        Dim lista As OleDbDataReader = AgenteBD.ObtenerAgente().Leer("SELECT * FROM TRENES WHERE Matricula='" & t.matricula & "';")
        If lista.Read Then
            Dim tipo As Tipos_Tren
            tipo = New Tipos_Tren()
            tipo.idttren = lista(1)

            tipo.LeerTip_tren()
            t.tipotren = tipo
        End If
    End Sub
    Public Sub readmatricula(ByRef t As Tren)
        Dim lista As OleDbDataReader
        lista = AgenteBD.ObtenerAgente.Leer("SELECT * FROM TRENES WHERE Matricula = (SELECT MAX(Matricula) from TRENES);")
        If lista.Read() Then
            t.matricula = lista(0)
        End If
    End Sub

    Public Function Insertar(ByVal t As Tren) As Integer
        Return AgenteBD.ObtenerAgente.modificar("INSERT INTO TRENES ([Matricula],[TipoTren]) VALUES ('" & t.matricula & "'," & t.tipotren.idttren & ");")
    End Function

    Public Function Actualizar(ByVal t As Tren) As Integer
        Return AgenteBD.ObtenerAgente.modificar("UPDATE TRENES SET TipoTren=" & t.tipotren.idttren & " WHERE Matricula='" & t.matricula & "';")
    End Function

    Public Function Borrar(ByVal t As Tren) As Integer
        Return AgenteBD.ObtenerAgente.modificar("DELETE FROM TRENES WHERE Matricula='" & t.matricula & "';")
    End Function
End Class
