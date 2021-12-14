Imports System.Data.OleDb
Public Class ViajesDAO
    Private _viajes As Collection
    Private _viajeMaxBeneficio As Collection
    Sub New()
        Me._viajes = New Collection
        Me._viajeMaxBeneficio = New Collection
    End Sub
    Public ReadOnly Property listaviajes As Collection
        Get
            Return _viajes
        End Get
    End Property

    Public ReadOnly Property viajeMaxBeneficio As Collection
        Get
            Return _viajeMaxBeneficio
        End Get
    End Property

    Public Sub consulta4ViajeMaxBeneficio()
        Dim lista As OleDbDataReader = AgenteBD.ObtenerAgente.Leer("SELECT DISTINCT TOP 1 VIAJES.FechaViaje, VIAJES.Tren, TRENES.TipoTren, VIAJES.Producto, VIAJES.ToneladasTransportadas, COTIZACIONES.EurosPorTonelada, COTIZACIONES.EurosPorTonelada * VIAJES.ToneladasTransportadas
                                                                    FROM TRENES , VIAJES , COTIZACIONES, PRODUCTOS
                                                                    WHERE VIAJES.Producto = COTIZACIONES.Producto AND VIAJES.Tren = TRENES.Matricula AND COTIZACIONES.Fecha <= VIAJES.FechaViaje
                                                                    ORDER BY COTIZACIONES.EurosPorTonelada * VIAJES.ToneladasTransportadas DESC;")
        Dim fecha As Date
        Dim tren As Tren
        Dim producto As Producto
        Dim toneladasTransport As Integer
        Dim eurosTonelada As Double
        Dim beneficioTotal As Double
        Dim tipoTren As Tipos_Tren

        While lista.Read()
            tren = New Tren()
            producto = New Producto()
            tipoTren = New Tipos_Tren()

            fecha = CDate(lista(0))
            tren.matricula = CStr(lista(1))
            tipoTren.idttren = CInt(lista(2))
            producto.id_producto = CInt(lista(3))
            toneladasTransport = CInt(lista(4))
            eurosTonelada = CDbl(lista(5))
            beneficioTotal = CDbl(lista(6))


            Me.viajeMaxBeneficio.Add(fecha & " " & tren.matricula & " " & tipoTren.idttren & " " & producto.id_producto & " " & toneladasTransport & " " & eurosTonelada & " " & beneficioTotal)
        End While
    End Sub

    Public Sub LeerTodas()
        Dim lista As OleDbDataReader = AgenteBD.ObtenerAgente.Leer("SELECT * FROM VIAJES ORDER BY FechaViaje, Tren, Producto")
        Dim v As Viaje
        While lista.Read
            Dim tren As Tren
            tren = New Tren()
            Dim pro As Producto
            pro = New Producto()

            tren.matricula = lista(1)
            pro.id_producto = lista(2)
            v = New Viaje(lista(0), tren, pro, lista(3))
            Me.listaviajes.Add(v)
        End While
    End Sub
    Public Sub Leer(ByVal v As Viaje)
        Dim lista As OleDbDataReader = AgenteBD.ObtenerAgente().Leer("SELECT * FROM VIAJES WHERE FechaViaje = #" & Format(v.fecha_viaje, "yyyy/MM/dd") & "# AND Tren='" & v.tren.matricula & "' AND Producto=" & v.producto.id_producto & ";")
        If lista.Read Then
            v.cantidad = lista(3)
        End If
    End Sub
    Public Function Insertar(ByVal v As Viaje) As Integer
        Return AgenteBD.ObtenerAgente.modificar("INSERT INTO VIAJES ([FechaViaje],[Tren],[Producto],[ToneladasTransportadas]) VALUES (#" & Format(v.fecha_viaje, "yyyy/MM/dd") & "# , '" & v.tren.matricula & "' , " & v.producto.id_producto & " , " & v.cantidad & ");")
    End Function
    Public Function Actualizar(ByVal v As Viaje) As Integer
        Return AgenteBD.ObtenerAgente.modificar("UPDATE VIAJES SET ToneladasTransportadas=" & v.cantidad & " WHERE FechaViaje=#" & Format(v.fecha_viaje, "yyyy/MM/dd") & "# AND Tren ='" & v.tren.matricula & "'AND Producto=" & v.producto.id_producto & ";")
    End Function
    Public Function Borrar(ByVal v As Viaje) As Integer
        Return AgenteBD.ObtenerAgente.modificar("DELETE FROM VIAJES WHERE FechaViaje=#" & Format(v.fecha_viaje, "yyyy/MM/dd") & "# AND Tren ='" & v.tren.matricula & "' AND Producto=" & v.producto.id_producto & ";")
    End Function

End Class

