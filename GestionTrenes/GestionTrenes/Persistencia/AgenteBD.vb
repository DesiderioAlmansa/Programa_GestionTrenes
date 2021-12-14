Imports System.Data.OleDb
Imports System.Data
Public Class AgenteBD

    Private Shared _instancia As AgenteBD
    Private Shared conexion As OleDbConnection
    Private Shared cadenaConexionBase As String = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source="
    Private Shared cadenaConexion As String
    Private Sub New() 'Lo ponemos privado para que nadie pueda crear la conexión y no puedan utilizarla varias personas
        AgenteBD.conexion = New OleDbConnection(AgenteBD.cadenaConexion)
        AgenteBD.conexion.Open()
    End Sub
    Public Shared Function ObtenerAgente(ByVal ruta As String) As AgenteBD
        AgenteBD.cadenaConexion = AgenteBD.cadenaConexionBase & ruta
        Return AgenteBD.ObtenerAgente
    End Function


    Public Shared Function ObtenerAgente() As AgenteBD
        If AgenteBD._instancia Is Nothing Then
            AgenteBD._instancia = New AgenteBD
        End If
        Return AgenteBD._instancia
    End Function

    Public Function Leer(sql As String) As OleDbDataReader ''los metodos leer y leertodos
        Dim com As New OleDbCommand(sql, conexion)
        Return com.ExecuteReader()
    End Function



    Public Function modificar(ByVal sql As String) As Integer ''los metodos insertar,borrar y actualizar
        Dim com As New OleDbCommand(sql, conexion)
        Return com.ExecuteNonQuery()
    End Function

    Public Sub destructor()
        _instancia = Nothing
    End Sub


End Class
