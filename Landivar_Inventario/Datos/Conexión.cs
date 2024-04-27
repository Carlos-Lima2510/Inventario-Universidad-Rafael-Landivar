using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace Landivar_Inventario.Datos
{
    class Conexion
    {
        static string server = Dns.GetHostName();
        static private string CadenaConexion = "Server= "+ server +"; DataBase=Landivar; Integrated Security=true";
        private SqlConnection conexion = new SqlConnection(CadenaConexion);
        public SqlConnection AbrirConexion()
        {
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();
            return conexion;
        }
        public SqlConnection CerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
            return conexion;
        }
    }
}
