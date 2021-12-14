Imports System.Data.OleDb
Public Class CotizaciónDAO
    Private _listacotizaciones As Collection

    Sub New()
        Me._listacotizaciones = New Collection
    End Sub
    Public ReadOnly Property listacotizaciones As Collection
        Get
            Return _listacotizaciones
        End Get
    End Property
    Public Sub LeerTodas()
        Dim lista As OleDbDataReader = AgenteBD.ObtenerAgente.Leer("SELECT * FROM COTIZACIONES ORDER BY Producto, Fecha")
        Dim c As Cotización

        While lista.Read
            Dim prod As Producto
            prod = New Producto()

            prod.id_producto = lista(0)
            prod.Leerproducto()

            c = New Cotización(prod, lista(1), lista(2))
            Me.listacotizaciones.Add(c)
        End While
    End Sub
    Public Sub Leer(ByVal c As Cotización)
        Dim lista As OleDbDataReader = AgenteBD.ObtenerAgente().Leer("SELECT * FROM COTIZACIONES WHERE Producto=" & c.producto.id_producto & " AND Fecha=#" & Format(c.fecha, "yyyy/MM/dd") & "#;")
        If lista.Read Then
            c.eur_ton = lista(2)
        End If
    End Sub

    Public Function Insertar(ByVal c As Cotización) As Integer
        Return AgenteBD.ObtenerAgente.modificar("INSERT INTO COTIZACIONES ([Producto],[Fecha],[EurosPorTonelada]) VALUES (" & c.producto.id_producto & " ,#" & Format(c.fecha, "yyyy/MM/dd") & "#," & c.eur_ton & " );")
    End Function

    Public Function Actualizar(ByVal c As Cotización) As Integer
        Return AgenteBD.ObtenerAgente.modificar("UPDATE COTIZACIONES SET EurosPorTonelada=" & c.eur_ton & " WHERE Producto=" & c.producto.id_producto & "AND Fecha=#" & Format(c.fecha, "yyyy/MM/dd") & "#;")
    End Function

    Public Function Borrar(ByVal c As Cotización) As Integer
        Return AgenteBD.ObtenerAgente.modificar("DELETE FROM COTIZACIONES WHERE Producto=" & c.producto.id_producto & "AND Fecha=#" & Format(c.fecha, "yyyy/MM/dd") & "#;")
    End Function

End Class
