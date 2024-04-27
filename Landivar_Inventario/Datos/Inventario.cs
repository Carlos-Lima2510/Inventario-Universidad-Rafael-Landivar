using DocumentFormat.OpenXml.Office2010.Excel;
using Landivar_Inventario.Presentación;
using Landivar_Inventario.Recursos;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Landivar_Inventario.Datos
{
    class Inventario
    {
        private Conexion conexion = new Conexion();
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader Leerfilas;

        public DataTable ListarComputadorasCentralA103()
        {
            DataTable tabla = new DataTable();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SELECT i.Id, i.Codigo_URL as 'Codigo de Inventario', Mc.Nombre_Marca as 'Nombre de la Marca', p.Nombre_Procesador as 'Nombre del Procesador', Md.Nombre_Modelo as 'Nombre del Modelo', M.Modelo_Monitor as 'Modelo del Monitor', i.Codigo_Monitor as 'Codigo de Inventario del Monitor', i.Monitor_TAG as 'Service Tag del Monitor', g.Nombre_Generacion as 'Generación', i.ServiceTag as 'Service Tag', d.Cantidad_Almacenamiento as 'Cantidad de Almacenamiento', i.Tarjeta_Video as 'Tarjeta de Video', r.Cantidad_RAM as 'Cantidad de RAM', i.Observaciones as 'Observaciones' from Inventario i INNER JOIN Marca Mc ON i.Id_Marca = Mc.Id_Marca INNER JOIN Modelo Md ON i.Id_Modelo = Md.Id_Modelo INNER JOIN Procesador p ON i.Id_Procesador = p.Id_Procesador INNER JOIN Generacion g ON g.Id_Generacion = i.Id_Generacion INNER JOIN Disco_Duro d ON d.Id_DiscoDuro = i.Id_DiscoDuro INNER JOIN RAM r ON r.Id_RAM = i.Id_RAM INNER JOIN Monitor M ON M.Id_Monitor = i.Id_Monitor WHERE Ubicacion = 'A-103'\r\n";
            Leerfilas = Comando.ExecuteReader();
            tabla.Load(Leerfilas);
            Leerfilas.Close();
            conexion.CerrarConexion();
            return tabla;
        }
        public DataTable ListarComputadorasCentralC103()
        {
            DataTable tabla = new DataTable();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SELECT i.Id, i.Codigo_URL as 'Codigo de Inventario', Mc.Nombre_Marca as 'Nombre de la Marca', p.Nombre_Procesador as 'Nombre del Procesador', Md.Nombre_Modelo as 'Nombre del Modelo', M.Modelo_Monitor as 'Modelo del Monitor', i.Codigo_Monitor as 'Codigo de Inventario del Monitor', i.Monitor_TAG as 'Service Tag del Monitor', g.Nombre_Generacion as 'Generación', i.ServiceTag as 'Service Tag', d.Cantidad_Almacenamiento as 'Cantidad de Almacenamiento', i.Tarjeta_Video as 'Tarjeta de Video', r.Cantidad_RAM as 'Cantidad de RAM', i.Observaciones as 'Observaciones' from Inventario i INNER JOIN Marca Mc ON i.Id_Marca = Mc.Id_Marca INNER JOIN Modelo Md ON i.Id_Modelo = Md.Id_Modelo INNER JOIN Procesador p ON i.Id_Procesador = p.Id_Procesador INNER JOIN Generacion g ON g.Id_Generacion = i.Id_Generacion INNER JOIN Disco_Duro d ON d.Id_DiscoDuro = i.Id_DiscoDuro INNER JOIN RAM r ON r.Id_RAM = i.Id_RAM INNER JOIN Monitor M ON M.Id_Monitor = i.Id_Monitor WHERE Ubicacion = 'C-103'\r\n";
            Leerfilas = Comando.ExecuteReader();
            tabla.Load(Leerfilas);
            Leerfilas.Close();
            conexion.CerrarConexion();
            return tabla;
        }
        public DataTable ListarComputadorasAnexo103()
        {
            DataTable tabla = new DataTable();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SELECT i.Id, i.Codigo_URL as 'Codigo de Inventario', Mc.Nombre_Marca as 'Nombre de la Marca', p.Nombre_Procesador as 'Nombre del Procesador', Md.Nombre_Modelo as 'Nombre del Modelo', M.Modelo_Monitor as 'Modelo del Monitor', i.Codigo_Monitor as 'Codigo de Inventario del Monitor', i.Monitor_TAG as 'Service Tag del Monitor', g.Nombre_Generacion as 'Generación', i.ServiceTag as 'Service Tag', d.Cantidad_Almacenamiento as 'Cantidad de Almacenamiento', i.Tarjeta_Video as 'Tarjeta de Video', r.Cantidad_RAM as 'Cantidad de RAM', i.Observaciones as 'Observaciones' from Inventario i INNER JOIN Marca Mc ON i.Id_Marca = Mc.Id_Marca INNER JOIN Modelo Md ON i.Id_Modelo = Md.Id_Modelo INNER JOIN Procesador p ON i.Id_Procesador = p.Id_Procesador INNER JOIN Generacion g ON g.Id_Generacion = i.Id_Generacion INNER JOIN Disco_Duro d ON d.Id_DiscoDuro = i.Id_DiscoDuro INNER JOIN RAM r ON r.Id_RAM = i.Id_RAM INNER JOIN Monitor M ON M.Id_Monitor = i.Id_Monitor WHERE Ubicacion = 'B-103'\r\n";
            Leerfilas = Comando.ExecuteReader();
            tabla.Load(Leerfilas);
            Leerfilas.Close();
            conexion.CerrarConexion();
            return tabla;
        }
        public DataTable ListarComputadorasAnexo204()
        {
            DataTable tabla = new DataTable();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SELECT i.Id, i.Codigo_URL as 'Codigo de Inventario', Mc.Nombre_Marca as 'Nombre de la Marca', p.Nombre_Procesador as 'Nombre del Procesador', Md.Nombre_Modelo as 'Nombre del Modelo', M.Modelo_Monitor as 'Modelo del Monitor', i.Codigo_Monitor as 'Codigo de Inventario del Monitor', i.Monitor_TAG as 'Service Tag del Monitor', g.Nombre_Generacion as 'Generación', i.ServiceTag as 'Service Tag', d.Cantidad_Almacenamiento as 'Cantidad de Almacenamiento', i.Tarjeta_Video as 'Tarjeta de Video', r.Cantidad_RAM as 'Cantidad de RAM', i.Observaciones as 'Observaciones' from Inventario i INNER JOIN Marca Mc ON i.Id_Marca = Mc.Id_Marca INNER JOIN Modelo Md ON i.Id_Modelo = Md.Id_Modelo INNER JOIN Procesador p ON i.Id_Procesador = p.Id_Procesador INNER JOIN Generacion g ON g.Id_Generacion = i.Id_Generacion INNER JOIN Disco_Duro d ON d.Id_DiscoDuro = i.Id_DiscoDuro INNER JOIN RAM r ON r.Id_RAM = i.Id_RAM INNER JOIN Monitor M ON M.Id_Monitor = i.Id_Monitor WHERE Ubicacion = 'B-204'\r\n";
            Leerfilas = Comando.ExecuteReader();
            tabla.Load(Leerfilas);
            Leerfilas.Close();
            conexion.CerrarConexion();
            return tabla;
        }
        public DataTable ListarComputadorasAnexo206()
        {
            DataTable tabla = new DataTable();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SELECT i.Id, i.Codigo_URL as 'Codigo de Inventario', Mc.Nombre_Marca as 'Nombre de la Marca', p.Nombre_Procesador as 'Nombre del Procesador', Md.Nombre_Modelo as 'Nombre del Modelo', M.Modelo_Monitor as 'Modelo del Monitor', i.Codigo_Monitor as 'Codigo de Inventario del Monitor', i.Monitor_TAG as 'Service Tag del Monitor', g.Nombre_Generacion as 'Generación', i.ServiceTag as 'Service Tag', d.Cantidad_Almacenamiento as 'Cantidad de Almacenamiento', i.Tarjeta_Video as 'Tarjeta de Video', r.Cantidad_RAM as 'Cantidad de RAM', i.Observaciones as 'Observaciones' from Inventario i INNER JOIN Marca Mc ON i.Id_Marca = Mc.Id_Marca INNER JOIN Modelo Md ON i.Id_Modelo = Md.Id_Modelo INNER JOIN Procesador p ON i.Id_Procesador = p.Id_Procesador INNER JOIN Generacion g ON g.Id_Generacion = i.Id_Generacion INNER JOIN Disco_Duro d ON d.Id_DiscoDuro = i.Id_DiscoDuro INNER JOIN RAM r ON r.Id_RAM = i.Id_RAM INNER JOIN Monitor M ON M.Id_Monitor = i.Id_Monitor WHERE Ubicacion = 'B-206'\r\n";
            Leerfilas = Comando.ExecuteReader();
            tabla.Load(Leerfilas);
            Leerfilas.Close();
            conexion.CerrarConexion();
            return tabla;
        }
        public DataTable ListarComputadorasCentralA103M()
        {
            DataTable tabla = new DataTable();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SELECT i.Codigo_URL as 'Codigo de Inventario', Mc.Nombre_Marca as 'Nombre de la Marca', p.Nombre_Procesador as 'Nombre del Procesador', Md.Nombre_Modelo as 'Nombre del Modelo', M.Modelo_Monitor as 'Modelo del Monitor', i.Codigo_Monitor as 'Codigo de Inventario del Monitor', i.Monitor_TAG as 'Service Tag del Monitor', g.Nombre_Generacion as 'Generación', i.ServiceTag as 'Service Tag', d.Cantidad_Almacenamiento as 'Cantidad de Almacenamiento', i.Tarjeta_Video as 'Tarjeta de Video', r.Cantidad_RAM as 'Cantidad de RAM', i.Observaciones as 'Observaciones' from Inventario i INNER JOIN Marca Mc ON i.Id_Marca = Mc.Id_Marca INNER JOIN Modelo Md ON i.Id_Modelo = Md.Id_Modelo INNER JOIN Procesador p ON i.Id_Procesador = p.Id_Procesador INNER JOIN Generacion g ON g.Id_Generacion = i.Id_Generacion INNER JOIN Disco_Duro d ON d.Id_DiscoDuro = i.Id_DiscoDuro INNER JOIN RAM r ON r.Id_RAM = i.Id_RAM INNER JOIN Monitor M ON M.Id_Monitor = i.Id_Monitor WHERE Ubicacion = 'A-103'";
            Leerfilas = Comando.ExecuteReader();
            tabla.Load(Leerfilas);  
            Leerfilas.Close();
            conexion.CerrarConexion();
            return tabla;
        }
        public DataTable ListarComputadorasCentralC103M()
        {
            DataTable tabla = new DataTable();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SELECT i.Codigo_URL as 'Codigo de Inventario', Mc.Nombre_Marca as 'Nombre de la Marca', p.Nombre_Procesador as 'Nombre del Procesador', Md.Nombre_Modelo as 'Nombre del Modelo', M.Modelo_Monitor as 'Modelo del Monitor', i.Codigo_Monitor as 'Codigo de Inventario del Monitor', i.Monitor_TAG as 'Service Tag del Monitor', g.Nombre_Generacion as 'Generación', i.ServiceTag as 'Service Tag', d.Cantidad_Almacenamiento as 'Cantidad de Almacenamiento', i.Tarjeta_Video as 'Tarjeta de Video', r.Cantidad_RAM as 'Cantidad de RAM', i.Observaciones as 'Observaciones' from Inventario i INNER JOIN Marca Mc ON i.Id_Marca = Mc.Id_Marca INNER JOIN Modelo Md ON i.Id_Modelo = Md.Id_Modelo INNER JOIN Procesador p ON i.Id_Procesador = p.Id_Procesador INNER JOIN Generacion g ON g.Id_Generacion = i.Id_Generacion INNER JOIN Disco_Duro d ON d.Id_DiscoDuro = i.Id_DiscoDuro INNER JOIN RAM r ON r.Id_RAM = i.Id_RAM INNER JOIN Monitor M ON M.Id_Monitor = i.Id_Monitor WHERE Ubicacion = 'C-103'\r\n";
            Leerfilas = Comando.ExecuteReader();
            tabla.Load(Leerfilas);
            Leerfilas.Close();
            conexion.CerrarConexion();
            return tabla;
        }
        public DataTable ListarComputadorasAnexo103M()
        {
            DataTable tabla = new DataTable();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SELECT i.Codigo_URL as 'Codigo de Inventario', Mc.Nombre_Marca as 'Nombre de la Marca', p.Nombre_Procesador as 'Nombre del Procesador', Md.Nombre_Modelo as 'Nombre del Modelo', M.Modelo_Monitor as 'Modelo del Monitor', i.Codigo_Monitor as 'Codigo de Inventario del Monitor', i.Monitor_TAG as 'Service Tag del Monitor', g.Nombre_Generacion as 'Generación', i.ServiceTag as 'Service Tag', d.Cantidad_Almacenamiento as 'Cantidad de Almacenamiento', i.Tarjeta_Video as 'Tarjeta de Video', r.Cantidad_RAM as 'Cantidad de RAM', i.Observaciones as 'Observaciones' from Inventario i INNER JOIN Marca Mc ON i.Id_Marca = Mc.Id_Marca INNER JOIN Modelo Md ON i.Id_Modelo = Md.Id_Modelo INNER JOIN Procesador p ON i.Id_Procesador = p.Id_Procesador INNER JOIN Generacion g ON g.Id_Generacion = i.Id_Generacion INNER JOIN Disco_Duro d ON d.Id_DiscoDuro = i.Id_DiscoDuro INNER JOIN RAM r ON r.Id_RAM = i.Id_RAM INNER JOIN Monitor M ON M.Id_Monitor = i.Id_Monitor WHERE Ubicacion = 'B-103'\r\n";
            Leerfilas = Comando.ExecuteReader();
            tabla.Load(Leerfilas);
            Leerfilas.Close();
            conexion.CerrarConexion();
            return tabla;
        }
        public DataTable ListarComputadorasAnexo204M()
        {
            DataTable tabla = new DataTable();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SELECT i.Codigo_URL as 'Codigo de Inventario', Mc.Nombre_Marca as 'Nombre de la Marca', p.Nombre_Procesador as 'Nombre del Procesador', Md.Nombre_Modelo as 'Nombre del Modelo', M.Modelo_Monitor as 'Modelo del Monitor', i.Codigo_Monitor as 'Codigo de Inventario del Monitor', i.Monitor_TAG as 'Service Tag del Monitor', g.Nombre_Generacion as 'Generación', i.ServiceTag as 'Service Tag', d.Cantidad_Almacenamiento as 'Cantidad de Almacenamiento', i.Tarjeta_Video as 'Tarjeta de Video', r.Cantidad_RAM as 'Cantidad de RAM', i.Observaciones as 'Observaciones' from Inventario i INNER JOIN Marca Mc ON i.Id_Marca = Mc.Id_Marca INNER JOIN Modelo Md ON i.Id_Modelo = Md.Id_Modelo INNER JOIN Procesador p ON i.Id_Procesador = p.Id_Procesador INNER JOIN Generacion g ON g.Id_Generacion = i.Id_Generacion INNER JOIN Disco_Duro d ON d.Id_DiscoDuro = i.Id_DiscoDuro INNER JOIN RAM r ON r.Id_RAM = i.Id_RAM INNER JOIN Monitor M ON M.Id_Monitor = i.Id_Monitor WHERE Ubicacion = 'B-204'";
            Leerfilas = Comando.ExecuteReader();
            tabla.Load(Leerfilas);
            Leerfilas.Close();
            conexion.CerrarConexion();
            return tabla;
        }
        public DataTable ListarComputadorasAnexo206M()
        {
            DataTable tabla = new DataTable();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SELECT i.Codigo_URL as 'Codigo de Inventario', Mc.Nombre_Marca as 'Nombre de la Marca', p.Nombre_Procesador as 'Nombre del Procesador', Md.Nombre_Modelo as 'Nombre del Modelo', M.Modelo_Monitor as 'Modelo del Monitor', i.Codigo_Monitor as 'Codigo de Inventario del Monitor', i.Monitor_TAG as 'Service Tag del Monitor', g.Nombre_Generacion as 'Generación', i.ServiceTag as 'Service Tag', d.Cantidad_Almacenamiento as 'Cantidad de Almacenamiento', i.Tarjeta_Video as 'Tarjeta de Video', r.Cantidad_RAM as 'Cantidad de RAM', i.Observaciones as 'Observaciones' from Inventario i INNER JOIN Marca Mc ON i.Id_Marca = Mc.Id_Marca INNER JOIN Modelo Md ON i.Id_Modelo = Md.Id_Modelo INNER JOIN Procesador p ON i.Id_Procesador = p.Id_Procesador INNER JOIN Generacion g ON g.Id_Generacion = i.Id_Generacion INNER JOIN Disco_Duro d ON d.Id_DiscoDuro = i.Id_DiscoDuro INNER JOIN RAM r ON r.Id_RAM = i.Id_RAM INNER JOIN Monitor M ON M.Id_Monitor = i.Id_Monitor WHERE Ubicacion = 'B-206'\r\n";
            Leerfilas = Comando.ExecuteReader();
            tabla.Load(Leerfilas);
            Leerfilas.Close();
            conexion.CerrarConexion();
            return tabla;
        }
        public void InsertarCentralA103(string codigo, int marca, int modelo, int procesador, int generacion, string tag, int disco, string tarjeta, int ram, string observaciones, int monitor, string codmonitor, string tagmonitor)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "insert into Inventario (Codigo_URL, Id_Marca, Id_Modelo, Id_Procesador, Id_Generacion, ServiceTag, Id_DiscoDuro, Tarjeta_Video, Id_RAM, Observaciones, Id_Monitor, Ubicacion, Codigo_Monitor, Monitor_TAG)" +
                " values ('" + codigo + "', '" + marca + "', '" + modelo + "', '" + procesador + "', '" + generacion + "', '" + tag + "' , '" + disco + "' , '" + tarjeta + "' , '" + ram + "' , '" + observaciones + "' , '" + monitor + "' , 'A-103', '" + codmonitor + "', '" + tagmonitor + "')";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Comando.Connection = conexion.CerrarConexion();
        }
        public void InsertarCentralC103(string codigo, int marca, int modelo, int procesador, int generacion, string tag, int disco, string tarjeta, int ram, string observaciones, int monitor, string codmonitor, string tagmonitor)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "insert into Inventario (Codigo_URL, Id_Marca, Id_Modelo, Id_Procesador, Id_Generacion, ServiceTag, Id_DiscoDuro, Tarjeta_Video, Id_RAM, Observaciones, Id_Monitor, Ubicacion, Codigo_Monitor, Monitor_TAG)" +
                " values ('" + codigo + "', '" + marca + "', '" + modelo + "', '" + procesador + "', '" + generacion + "', '" + tag + "' , '" + disco + "' , '" + tarjeta + "' , '" + ram + "' , '" + observaciones + "' , '" + monitor + "' , 'C-103', '" + codmonitor + "', '" + tagmonitor + "')";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Comando.Connection = conexion.CerrarConexion();
        }
        public void InsertarAnexoB103(string codigo, int marca, int modelo, int procesador, int generacion, string tag, int disco, string tarjeta, int ram, string observaciones, int monitor, string codmonitor, string tagmonitor)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "insert into Inventario (Codigo_URL, Id_Marca, Id_Modelo, Id_Procesador, Id_Generacion, ServiceTag, Id_DiscoDuro, Tarjeta_Video, Id_RAM, Observaciones, Id_Monitor, Ubicacion, Codigo_Monitor, Monitor_TAG)" +
                " values ('" + codigo + "', '" + marca + "', '" + modelo + "', '" + procesador + "', '" + generacion + "', '" + tag + "' , '" + disco + "' , '" + tarjeta + "' , '" + ram + "' , '" + observaciones + "' , '" + monitor + "' , 'B-103', '" + codmonitor + "', '" + tagmonitor + "')";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Comando.Connection = conexion.CerrarConexion();
        }
        public void InsertarAnexoB204(string codigo, int marca, int modelo, int procesador, int generacion, string tag, int disco, string tarjeta, int ram, string observaciones, int monitor, string codmonitor, string tagmonitor)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "insert into Inventario (Codigo_URL, Id_Marca, Id_Modelo, Id_Procesador, Id_Generacion, ServiceTag, Id_DiscoDuro, Tarjeta_Video, Id_RAM, Observaciones, Id_Monitor, Ubicacion, Codigo_Monitor, Monitor_TAG)" +
                " values ('" + codigo + "', '" + marca + "', '" + modelo + "', '" + procesador + "', '" + generacion + "', '" + tag + "' , '" + disco + "' , '" + tarjeta + "' , '" + ram + "' , '" + observaciones + "' , '" + monitor + "' , 'B-204', '" + codmonitor + "', '" + tagmonitor + "')";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Comando.Connection = conexion.CerrarConexion();
        }
        public void InsertarAnexoB206(string codigo, int marca, int modelo, int procesador, int generacion, string tag, int disco, string tarjeta, int ram, string observaciones, int monitor, string codmonitor, string tagmonitor)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "insert into Inventario (Codigo_URL, Id_Marca, Id_Modelo, Id_Procesador, Id_Generacion, ServiceTag, Id_DiscoDuro, Tarjeta_Video, Id_RAM, Observaciones, Id_Monitor, Ubicacion, Codigo_Monitor, Monitor_TAG)" +
                " values ('" + codigo + "', '" + marca + "', '" + modelo + "', '" + procesador + "', '" + generacion + "', '" + tag + "' , '" + disco + "' , '" + tarjeta + "' , '" + ram + "' , '" + observaciones + "' , '" + monitor + "' , 'B-206', '" + codmonitor + "', '" + tagmonitor + "')";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Comando.Connection = conexion.CerrarConexion();
        }
        public void Actualizar(string codigo, int marca, int modelo, int procesador, int generacion, string tag, int disco, string tarjeta, int ram, string observaciones, int monitor, string codmonitor, string tagmonitor, int ID)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "UPDATE Inventario SET Codigo_URL='" + codigo + "', Id_Marca='" + marca + "', Id_Modelo='" + modelo + "', Id_Procesador='" + procesador + "', Id_Generacion='" + generacion + "', ServiceTag='" + tag + "', Id_DiscoDuro='" + disco + "', Tarjeta_Video='" + tarjeta + "', Id_RAM='" + ram + "', Observaciones='" + observaciones + "', Id_Monitor='" + monitor + "', Codigo_Monitor='" + codmonitor + "', Monitor_TAG='" + tagmonitor + "'  WHERE Id = " + ID + "";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }
        public void Eliminar(int Id)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "Delete from Inventario WHERE Id = " + Id + " ";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Comando.Connection = conexion.CerrarConexion();
        }
        public void Inicio_Admin(string NomUsuario, string contrasena)
        {
            try
            {
                Comando.Connection = conexion.AbrirConexion();
                Comando.CommandText = "Select * from Usuarios WHERE Contraseña = '" + contrasena + "' and Nombre_Usuario = '" + NomUsuario + "' and Id_Rol = 1";
                int a = Convert.ToInt32(Comando.ExecuteScalar()); //mira cuantos valores retorna
                Comando.Parameters.Clear();
                if (a == 0)
                {
                    MessageBox.Show("Usuario o contraseña invalidos");
                    Login login = new Login();
                    login.Show();

                }
                else
                {
                    Inicio inicio = new Inicio();
                    inicio.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }
        public void Inicio_AdminConfiguracion(string NomUsuario, string contrasena)
        {
            try
            {
                Comando.Connection = conexion.AbrirConexion();
                Comando.CommandText = "Select * from Usuarios WHERE Contraseña = '" + contrasena + "' and Nombre_Usuario = '" + NomUsuario + "' and Id_Rol = 1";
                int a = Convert.ToInt32(Comando.ExecuteScalar()); //mira cuantos valores retorna
                Comando.Parameters.Clear();
                if (a == 0)
                {
                    MessageBox.Show("Usuario o contraseña invalidos \n \n Se necesita un permiso de ADMINISTRADOR", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Confirmacion confirmacion = new Confirmacion();
                    confirmacion.Show();
                }
                else
                {
                    GestorUsuarios usuarios = new GestorUsuarios();
                    usuarios.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }
        public void Inicio_Usuario(string NomUsuario, string contrasena)
        {
            try
            {
                Comando.Connection = conexion.AbrirConexion();
                Comando.CommandText = "Select * from Usuarios WHERE Contraseña = '" + contrasena + "' and Nombre_Usuario = '" + NomUsuario + "' and Id_Rol = 2 ";
                int a = Convert.ToInt32(Comando.ExecuteScalar()); //mira cuantos valores retorna
                Comando.Parameters.Clear();
                if (a == 0)
                {
                    MessageBox.Show("Usuario o contraseña invalidos");
                    Login login = new Login();
                    login.Show();

                }
                else
                {
                    Inicio inicio = new Inicio();
                    inicio.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }
        public DataTable ListarModeloCase()
        {
            DataTable tabla = new DataTable();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SELECT Id_Modelo, Nombre_Modelo as 'Nombre del Modelo' FROM Modelo";
            Leerfilas = Comando.ExecuteReader();
            tabla.Load(Leerfilas);
            Leerfilas.Close();
            conexion.CerrarConexion();
            return tabla;
        }
        public void InsertarModeloCase(string modelo)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "insert into Modelo (Nombre_Modelo)" +
                " values ('" + modelo + "')";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Comando.Connection = conexion.CerrarConexion();
        }
        public void InsertarModeloMonitor(string monitor)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "insert into Monitor (Modelo_Monitor)" +
                " values ('" + monitor + "')";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Comando.Connection = conexion.CerrarConexion();
        }
        public void ActualizarModeloCase(string modelo, int ID)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "UPDATE Modelo SET Nombre_Modelo='" + modelo + "' WHERE Id_Modelo = " + ID + "";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Comando.Connection = conexion.CerrarConexion();
        }
        public void ActualizarModeloMonitor(string modelo, int ID)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "UPDATE Monitor SET Modelo_Monitor='" + modelo + "' WHERE Id_Monitor = " + ID + "";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Comando.Connection = conexion.CerrarConexion();
        }
        public DataTable ListarModeloMonitor()
        {
            DataTable tabla = new DataTable();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SELECT Id_Monitor, Modelo_Monitor as 'Modelo del Monitor' FROM Monitor";
            Leerfilas = Comando.ExecuteReader();
            tabla.Load(Leerfilas);
            Leerfilas.Close();
            conexion.CerrarConexion();
            return tabla;
        }
        public void EliminarModelo(int Id)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "Delete from Modelo WHERE Id_Modelo = " + Id + " ";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Comando.Connection = conexion.CerrarConexion();
        }
        public void EliminarMonitor(int Id)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "Delete from Monitor WHERE Id_Monitor = " + Id + " ";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Comando.Connection = conexion.CerrarConexion();
        }
    }
}
