using System.Data.SqlClient;
using System.Data;

namespace Landivar_Inventario.Datos
{
    class Usuarios
    {
        private Conexion conexion = new Conexion();
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader Leerfilas;

        public DataTable VistaUsuarios()
        {
            DataTable tabla = new DataTable();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SELECT u.Id_Usuario, u.Nombre, u.Nombre_Usuario as 'Credencial de Usuario', u.Contraseña, r.Nombre_Rol as 'Rol del Usuario' from Usuarios u INNER JOIN Roles r ON r.Id_Roles = u.Id_Rol";
            Leerfilas = Comando.ExecuteReader();
            tabla.Load(Leerfilas);
            Leerfilas.Close();
            conexion.CerrarConexion();
            return tabla;
        }
        public void Insertar(string nombre, string credencial, string contraseña, int rol)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "insert into Usuarios (Nombre_Usuario, Contraseña, Id_Rol, Nombre)" +
                " values ('" + credencial + "', '" + contraseña + "', '" + rol + "', '" + nombre + "')";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Comando.Connection = conexion.CerrarConexion();
        }
        public void Actualizar(string nombre, string credencial, string contraseña, int rol, int ID)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "UPDATE Usuarios SET Nombre_Usuario='" + credencial + "', Contraseña='" + contraseña + "', Id_Rol='" + rol + "', Nombre='" + nombre + "' WHERE Id_Usuario = " + ID + "";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Comando.Connection = conexion.CerrarConexion();
        }
        public void Eliminar(int Id)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "Delete from Usuarios WHERE Id_Usuario = " + Id + " ";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Comando.Connection = conexion.CerrarConexion();
        }
    }
}
