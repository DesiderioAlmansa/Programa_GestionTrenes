Imports System.Data.OleDb
Public Class ProductosDAO
    Private _Productos As Collection
    Private _listaConsulta3 As Collection

    Sub New()
        Me._Productos = New Collection
        Me._listaConsulta3 = New Collection
    End Sub
    Public ReadOnly Property listaproductos As Collection
        Get
            Return _Productos
        End Get
    End Property
    Public ReadOnly Property listaConsulta3 As Collection
        Get
            Return _listaConsulta3
        End Get
    End Property

    Public Sub LeerTodas()
        Dim lista As OleDbDataReader = AgenteBD.ObtenerAgente.Leer("SELECT * FROM PRODUCTOS ORDER BY IdProducto")
        Dim p As Producto
        While lista.Read
            p = New Producto(lista(0), lista(1))
            Me._Productos.Add(p)
        End While
    End Sub
    Public Sub Leer(ByVal p As Producto)
        Dim lista As OleDbDataReader = AgenteBD.ObtenerAgente().Leer("SELECT * FROM PRODUCTOS WHERE IdProducto = " & p.id_producto & ";")
        If lista.Read Then
            p.des_pro = lista(1)
        End If
    End Sub

    Public Sub consultaListaProductos(ByRef p As Producto, ByRef fecha1 As Date, ByRef fecha2 As Date)
        Dim lista As OleDbDataReader = AgenteBD.ObtenerAgente.Leer("SELECT VIAJES.Producto , PRODUCTOS.DescripProducto , COUNT(*) FROM VIAJES, PRODUCTOS WHERE VIAJES.Producto = PRODUCTOS.IdProducto And VIAJES.FechaViaje BETWEEN #" & Format(fecha1, "yyyy/MM/dd") & "# AND #" & Format(fecha2, "yyyy/MM/dd") & "# GROUP BY VIAJES.Producto, PRODUCTOs.DescripProducto ORDER BY COUNT(*)DESC;")
        Dim producto As Integer
        Dim descripcion As String
        Dim viajes As Integer
        While lista.Read
            producto = CInt(lista(0))
            descripcion = CStr(lista(1))
            viajes = CInt(lista(2))
            Me.listaConsulta3.Add(" IDPro: " & producto & " - Des: " & descripcion & " - NºViajes: " & viajes)
        End While
    End Sub
    Public Sub readID(ByRef P As Producto)
        Dim lista As OleDbDataReader
        lista = AgenteBD.ObtenerAgente().Leer("SELECT * FROM PRODUCTOS WHERE IdProducto = (SELECT MAX(IdProducto) from PRODUCTOS);")
        If lista.Read() Then
            P.id_producto = lista(0)
        End If
    End Sub

    Public Function Insertar(ByVal p As Producto) As Integer
        Return AgenteBD.ObtenerAgente.modificar("INSERT INTO PRODUCTOS ([DescripProducto]) VALUES ('" & p.des_pro & "');")
    End Function
    Public Function Actualizar(ByVal p As Producto) As Integer
        Return AgenteBD.ObtenerAgente.modificar("UPDATE PRODUCTOS SET DescripProducto='" & p.des_pro & "' WHERE IdProducto=" & p.id_producto & ";")
    End Function
    Public Function Borrar(ByVal p As Producto) As Integer
        Return AgenteBD.ObtenerAgente.modificar("DELETE FROM PRODUCTOS WHERE IdProducto=" & p.id_producto & ";")
    End Function
    Public Sub readViajes(ByRef p As Producto)
        Dim lista As OleDbDataReader
        lista = AgenteBD.ObtenerAgente.Leer("SELECT FechaViaje, Tren FROM VIAJES WHERE Producto =" & p.id_producto & ";")
        Dim v As New Viaje
        While lista.Read()
            v = New Viaje
            v.fecha_viaje = lista(0)
            v.tren = lista(1)
            v.LeerViaje()
            p.viajes.Add(v)
        End While
    End Sub
    Public Sub readCotizaciones(ByRef p As Producto)
        Dim lista As OleDbDataReader
        lista = AgenteBD.ObtenerAgente.Leer("SELECT Fecha FROM COTIZACIONES WHERE Producto =" & p.id_producto & ";")
        Dim cot As New Cotización
        While lista.Read()
            cot = New Cotización
            cot.fecha = lista(0)
            cot.LeerCotizacion()
            p.Cotizaciones.Add(cot)
        End While
    End Sub

    Public Sub insertCotizaciones(ByRef cot As Cotización, ByRef p As Producto)
        AgenteBD.ObtenerAgente().modificar("INSERT INTO COTIZACIONES ([Producto],[Fecha],[EurosPorTon]) VALUES (" & p.id_producto & "," & cot.fecha & "," & cot.eur_ton & ");")
    End Sub

    Public Sub deleteCotizaciones(ByRef cot As Cotización, ByRef p As Producto)
        AgenteBD.ObtenerAgente().modificar("DELETE * FROM COTIZACIONES WHERE Producto=" & p.id_producto & ", Fecha=" & cot.fecha & ";")
    End Sub
End Class
