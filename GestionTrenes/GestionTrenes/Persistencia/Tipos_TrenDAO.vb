Imports System.Data.OleDb

Public Class Tipos_TrenDAO
    Private _Tipos_trenes As Collection
    Private _listaConsulta2 As Collection

    Public Sub New()
        Me._Tipos_trenes = New Collection
        Me._listaConsulta2 = New Collection
    End Sub
    Public ReadOnly Property listaTipoTrenes As Collection
        Get
            Return _Tipos_trenes
        End Get
    End Property
    Public ReadOnly Property listaConsulta2 As Collection
        Get
            Return _listaConsulta2
        End Get
    End Property
    Public Sub LeerTodas()
        Dim lista As OleDbDataReader = AgenteBD.ObtenerAgente.Leer("SELECT * FROM TIPOS_TREN ORDER BY IdTipoTren")
        Dim t As Tipos_Tren

        While lista.Read
            t = New Tipos_Tren(lista(0), lista(1), lista(2))
            Me.listaTipoTrenes.Add(t)
        End While
    End Sub

    Public Sub consultaListaTipoTren(ByRef t As Tipos_Tren, ByRef fecha1 As Date, ByRef fecha2 As Date)
        Dim lista As OleDbDataReader = AgenteBD.ObtenerAgente.Leer("SELECT TRENES.TipoTren, COUNT(*) FROM TRENES , VIAJES WHERE TRENES.Matricula = VIAJES.Tren AND VIAJES.FechaViaje BETWEEN #" & Format(fecha1, "yyyy/MM/dd") & "# AND #" & Format(fecha2, "yyyy/MM/dd") & "# GROUP BY TRENES.TipoTren ORDER BY COUNT(*) DESC;")
        Dim tiptren As Integer
        Dim viajes As Integer
        While lista.Read
            tiptren = CInt(lista(0))
            viajes = CInt(lista(1))
            Me.listaConsulta2.Add(" IDTipoTren: " & tiptren & " - NºViajes: " & viajes)
        End While
    End Sub
    Public Sub Leer(ByRef ttren As Tipos_Tren)
        Dim lista As OleDbDataReader = AgenteBD.ObtenerAgente().Leer("SELECT * FROM TIPOS_TREN WHERE IdTipoTren = " & ttren.idttren & ";")
        If lista.Read Then
            ttren.destren = lista(1)
            ttren.capmax = lista(2)
        End If
    End Sub
    Public Sub readID(ByRef ttren As Tipos_Tren)
        Dim lista As OleDbDataReader
        lista = AgenteBD.ObtenerAgente.Leer("SELECT * FROM TIPOS_TREN WHERE IdTipoTren = (SELECT MAX(IdTipoTren) from TIPOS_TREN);")
        If lista.Read() Then
            ttren.idttren = lista(0)
        End If
    End Sub

    Public Sub Insertar(ByVal e As Tipos_Tren)
        AgenteBD.ObtenerAgente.modificar("INSERT INTO TIPOS_TREN ([DescTipoTren],[CapacidadMax]) VALUES ('" & e.destren & "'," & e.capmax & ");")
    End Sub

    Public Function Actualizar(ByVal e As Tipos_Tren) As Integer
        Return AgenteBD.ObtenerAgente.modificar("UPDATE TIPOS_TREN SET DescTipoTren='" & e.destren & "',CapacidadMax=" & e.capmax & " WHERE IdTipoTren=" & e.idttren & ";")
    End Function

    Public Sub Borrar(ByVal e As Tipos_Tren)
        AgenteBD.ObtenerAgente.modificar("DELETE FROM TIPOS_TREN WHERE IdTipoTren=" & e.idttren & ";")
    End Sub

End Class
