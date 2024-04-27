using System.Data;
using System.Data.SqlClient;

namespace Landivar_Inventario.Datos
{
    class IPs
    {
        private Conexion conexion = new Conexion();
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader Leerfilas;
        public DataTable ControlIPCentralA103()
        {
            DataTable tabla = new DataTable();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SELECT I.Id_IP, I.Numeracion as 'Numeración', I.IPS as 'Dirección IP', pe.Puerta_Enlace as 'Puerta de Enlace', d.DNS as 'DNS Preferido', d2.DNS2 as 'DNS Alternativo', m.Mascara as 'Máscara de Red' from IPs I INNER JOIN Puerta_Enlace pe ON I.Id_Puerta = pe.Id_puerta INNER JOIN DNS d ON I.Id_DNS = d.Id_DNS INNER JOIN Mascara m ON I.Id_Mascara = m.Id_mascara INNER JOIN DNS2 d2 ON I.Id_DNS2 = d2.Id_DNS2 WHERE Ubicacion = 'A-103'";
            Leerfilas = Comando.ExecuteReader();
            tabla.Load(Leerfilas);
            Leerfilas.Close();
            conexion.CerrarConexion();
            return tabla;
        }
        public DataTable ControlIPCentralC103()
        {
            DataTable tabla = new DataTable();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SELECT I.Id_IP, I.Numeracion as 'Numeración', I.IPS as 'Dirección IP', pe.Puerta_Enlace as 'Puerta de Enlace', d.DNS as 'DNS Preferido', d2.DNS2 as 'DNS Alternativo', m.Mascara as 'Máscara de Red' from IPs I INNER JOIN Puerta_Enlace pe ON I.Id_Puerta = pe.Id_puerta INNER JOIN DNS d ON I.Id_DNS = d.Id_DNS INNER JOIN Mascara m ON I.Id_Mascara = m.Id_mascara INNER JOIN DNS2 d2 ON I.Id_DNS2 = d2.Id_DNS2 WHERE Ubicacion = 'C-103'";
            Leerfilas = Comando.ExecuteReader();
            tabla.Load(Leerfilas);
            Leerfilas.Close();
            conexion.CerrarConexion();
            return tabla;
        }
        public DataTable ControlIPAnexoB103()
        {
            DataTable tabla = new DataTable();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SELECT I.Id_IP, I.Numeracion as 'Numeración', I.IPS as 'Dirección IP', pe.Puerta_Enlace as 'Puerta de Enlace', d.DNS as 'DNS Preferido', d2.DNS2 as 'DNS Alternativo', m.Mascara as 'Máscara de Red' from IPs I INNER JOIN Puerta_Enlace pe ON I.Id_Puerta = pe.Id_puerta INNER JOIN DNS d ON I.Id_DNS = d.Id_DNS INNER JOIN Mascara m ON I.Id_Mascara = m.Id_mascara INNER JOIN DNS2 d2 ON I.Id_DNS2 = d2.Id_DNS2 WHERE Ubicacion = 'B-103'";
            Leerfilas = Comando.ExecuteReader();
            tabla.Load(Leerfilas);
            Leerfilas.Close();
            conexion.CerrarConexion();
            return tabla;
        }
        public DataTable ControlIPAnexoB204()
        {
            DataTable tabla = new DataTable();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SELECT I.Id_IP, I.Numeracion as 'Numeración', I.IPS as 'Dirección IP', pe.Puerta_Enlace as 'Puerta de Enlace', d.DNS as 'DNS Preferido', d2.DNS2 as 'DNS Alternativo', m.Mascara as 'Máscara de Red' from IPs I INNER JOIN Puerta_Enlace pe ON I.Id_Puerta = pe.Id_puerta INNER JOIN DNS d ON I.Id_DNS = d.Id_DNS INNER JOIN Mascara m ON I.Id_Mascara = m.Id_mascara INNER JOIN DNS2 d2 ON I.Id_DNS2 = d2.Id_DNS2 WHERE Ubicacion = 'B-204'";
            Leerfilas = Comando.ExecuteReader();
            tabla.Load(Leerfilas);
            Leerfilas.Close();
            conexion.CerrarConexion();
            return tabla;
        }
        public DataTable ControlIPAnexoB206()
        {
            DataTable tabla = new DataTable();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SELECT I.Id_IP, I.Numeracion as 'Numeración', I.IPS as 'Dirección IP', pe.Puerta_Enlace as 'Puerta de Enlace', d.DNS as 'DNS Preferido', d2.DNS2 as 'DNS Alternativo', m.Mascara as 'Máscara de Red' from IPs I INNER JOIN Puerta_Enlace pe ON I.Id_Puerta = pe.Id_puerta INNER JOIN DNS d ON I.Id_DNS = d.Id_DNS INNER JOIN Mascara m ON I.Id_Mascara = m.Id_mascara INNER JOIN DNS2 d2 ON I.Id_DNS2 = d2.Id_DNS2 WHERE Ubicacion = 'B-206'";
            Leerfilas = Comando.ExecuteReader();
            tabla.Load(Leerfilas);
            Leerfilas.Close();
            conexion.CerrarConexion();
            return tabla;
        }
        public DataTable ControlIPCentralA103M()
        {
            DataTable tabla = new DataTable();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SELECT I.Numeracion as 'Numeración', I.IPS as 'Dirección IP', pe.Puerta_Enlace as 'Puerta de Enlace', d.DNS as 'DNS Preferido', d2.DNS2 as 'DNS Alternativo', m.Mascara as 'Máscara de Red' from IPs I INNER JOIN Puerta_Enlace pe ON I.Id_Puerta = pe.Id_puerta INNER JOIN DNS d ON I.Id_DNS = d.Id_DNS INNER JOIN Mascara m ON I.Id_Mascara = m.Id_mascara INNER JOIN DNS2 d2 ON I.Id_DNS2 = d2.Id_DNS2 WHERE Ubicacion = 'A-103'";
            Leerfilas = Comando.ExecuteReader();
            tabla.Load(Leerfilas);
            Leerfilas.Close();
            conexion.CerrarConexion();
            return tabla;
        }
        public DataTable ControlIPCentralC103M()
        {
            DataTable tabla = new DataTable();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SELECT I.Numeracion as 'Numeración', I.IPS as 'Dirección IP', pe.Puerta_Enlace as 'Puerta de Enlace', d.DNS as 'DNS Preferido', d2.DNS2 as 'DNS Alternativo', m.Mascara as 'Máscara de Red' from IPs I INNER JOIN Puerta_Enlace pe ON I.Id_Puerta = pe.Id_puerta INNER JOIN DNS d ON I.Id_DNS = d.Id_DNS INNER JOIN Mascara m ON I.Id_Mascara = m.Id_mascara INNER JOIN DNS2 d2 ON I.Id_DNS2 = d2.Id_DNS2 WHERE Ubicacion = 'C-103'";
            Leerfilas = Comando.ExecuteReader();
            tabla.Load(Leerfilas);
            Leerfilas.Close();
            conexion.CerrarConexion();
            return tabla;
        }
        public DataTable ControlIPAnexoB103M()
        {
            DataTable tabla = new DataTable();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SELECT I.Numeracion as 'Numeración', I.IPS as 'Dirección IP', pe.Puerta_Enlace as 'Puerta de Enlace', d.DNS as 'DNS Preferido', d2.DNS2 as 'DNS Alternativo', m.Mascara as 'Máscara de Red' from IPs I INNER JOIN Puerta_Enlace pe ON I.Id_Puerta = pe.Id_puerta INNER JOIN DNS d ON I.Id_DNS = d.Id_DNS INNER JOIN Mascara m ON I.Id_Mascara = m.Id_mascara INNER JOIN DNS2 d2 ON I.Id_DNS2 = d2.Id_DNS2 WHERE Ubicacion = 'B-103'";
            Leerfilas = Comando.ExecuteReader();
            tabla.Load(Leerfilas);
            Leerfilas.Close();
            conexion.CerrarConexion();
            return tabla;
        }
        public DataTable ControlIPAnexoB204M()
        {
            DataTable tabla = new DataTable();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SELECT I.Numeracion as 'Numeración', I.IPS as 'Dirección IP', pe.Puerta_Enlace as 'Puerta de Enlace', d.DNS as 'DNS Preferido', d2.DNS2 as 'DNS Alternativo', m.Mascara as 'Máscara de Red' from IPs I INNER JOIN Puerta_Enlace pe ON I.Id_Puerta = pe.Id_puerta INNER JOIN DNS d ON I.Id_DNS = d.Id_DNS INNER JOIN Mascara m ON I.Id_Mascara = m.Id_mascara INNER JOIN DNS2 d2 ON I.Id_DNS2 = d2.Id_DNS2 WHERE Ubicacion = 'B-204'";
            Leerfilas = Comando.ExecuteReader();
            tabla.Load(Leerfilas);
            Leerfilas.Close();
            conexion.CerrarConexion();
            return tabla;
        }
        public DataTable Mascara()
        {
            DataTable tabla = new DataTable();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SELECT Id_mascara, Mascara as 'Máscara' from Mascara";
            Leerfilas = Comando.ExecuteReader();
            tabla.Load(Leerfilas);
            Leerfilas.Close();
            conexion.CerrarConexion();
            return tabla;
        }
        public DataTable Puerta()
        {
            DataTable tabla = new DataTable();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SELECT Id_puerta, Puerta_Enlace as 'Puerta de Enlace' from Puerta_Enlace";
            Leerfilas = Comando.ExecuteReader();
            tabla.Load(Leerfilas);
            Leerfilas.Close();
            conexion.CerrarConexion();
            return tabla;
        }
        public DataTable DNS1()
        {
            DataTable tabla = new DataTable();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SELECT Id_DNS, DNS as 'DNS Preferido' from DNS";
            Leerfilas = Comando.ExecuteReader();
            tabla.Load(Leerfilas);
            Leerfilas.Close();
            conexion.CerrarConexion();
            return tabla;
        }
        public DataTable DNS2()
        {
            DataTable tabla = new DataTable();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SELECT Id_DNS2, DNS2 as 'DNS Alternativo' from DNS2";
            Leerfilas = Comando.ExecuteReader();
            tabla.Load(Leerfilas);
            Leerfilas.Close();
            conexion.CerrarConexion();
            return tabla;
        }
        public DataTable ControlIPAnexoB206M()
        {
            DataTable tabla = new DataTable();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SELECT I.Numeracion as 'Numeración', I.IPS as 'Dirección IP', pe.Puerta_Enlace as 'Puerta de Enlace', d.DNS as 'DNS Preferido', d2.DNS2 as 'DNS Alternativo', m.Mascara as 'Máscara de Red' from IPs I INNER JOIN Puerta_Enlace pe ON I.Id_Puerta = pe.Id_puerta INNER JOIN DNS d ON I.Id_DNS = d.Id_DNS INNER JOIN Mascara m ON I.Id_Mascara = m.Id_mascara INNER JOIN DNS2 d2 ON I.Id_DNS2 = d2.Id_DNS2 WHERE Ubicacion = 'B-206'";
            Leerfilas = Comando.ExecuteReader();
            tabla.Load(Leerfilas);
            Leerfilas.Close();
            conexion.CerrarConexion();
            return tabla;
        }
        public void InsertaIPA103(string numeracion, string ip, int mascara, int puerta, int dns1, int dns2)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "insert into IPs (Numeracion, IPS, Id_Puerta, Id_DNS, Id_DNS2, Id_Mascara, Ubicacion)" +
                " values ('" + numeracion + "', '" + ip + "', '" + puerta + "', '" + dns1 + "', '" + dns2 + "', '" + mascara + "', 'A-103' )";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Comando.Connection = conexion.CerrarConexion();
        }
        public void InsertaIPC103(string numeracion, string ip, int mascara, int puerta, int dns1, int dns2)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "insert into IPs (Numeracion, IPS, Id_Puerta, Id_DNS, Id_DNS2, Id_Mascara, Ubicacion)" +
                " values ('" + numeracion + "', '" + ip + "', '" + puerta + "', '" + dns1 + "', '" + dns2 + "', '" + mascara + "', 'C-103' )";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Comando.Connection = conexion.CerrarConexion();
        }
        public void InsertaIPB103(string numeracion, string ip, int mascara, int puerta, int dns1, int dns2)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "insert into IPs (Numeracion, IPS, Id_Puerta, Id_DNS, Id_DNS2, Id_Mascara, Ubicacion)" +
                " values ('" + numeracion + "', '" + ip + "', '" + puerta + "', '" + dns1 + "', '" + dns2 + "', '" + mascara + "', 'B-103' )";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Comando.Connection = conexion.CerrarConexion();
        }
        public void InsertaIPB204(string numeracion, string ip, int mascara, int puerta, int dns1, int dns2)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "insert into IPs (Numeracion, IPS, Id_Puerta, Id_DNS, Id_DNS2, Id_Mascara, Ubicacion)" +
                " values ('" + numeracion + "', '" + ip + "', '" + puerta + "', '" + dns1 + "', '" + dns2 + "', '" + mascara + "', 'B-204' )";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Comando.Connection = conexion.CerrarConexion();
        }
        public void InsertaIPB206(string numeracion, string ip, int mascara, int puerta, int dns1, int dns2)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "insert into IPs (Numeracion, IPS, Id_Puerta, Id_DNS, Id_DNS2, Id_Mascara, Ubicacion)" +
                " values ('" + numeracion + "', '" + ip + "', '" + puerta + "', '" + dns1 + "', '" + dns2 + "', '" + mascara + "', 'B-206' )";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Comando.Connection = conexion.CerrarConexion();
        }
        public void InsertarMascara(string mascara)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "insert into Mascara (Mascara)" +
                " values ('" + mascara + "')";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Comando.Connection = conexion.CerrarConexion();
        }
        public void InsertarPuerta(string puerta)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "insert into Puerta_Enlace (Puerta_Enlace)" +
                " values ('" + puerta + "')";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Comando.Connection = conexion.CerrarConexion();
        }
        public void InsertarDNS(string dns)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "insert into DNS (DNS)" +
                " values ('" + dns + "')";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Comando.Connection = conexion.CerrarConexion();
        }
        public void InsertarDNS2(string dns)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "insert into DNS2 (DNS2)" +
                " values ('" + dns + "')";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Comando.Connection = conexion.CerrarConexion();
        }
        public void ActualizarA103(string numeracion, string ip, int mascara, int puerta, int dns1, int dns2, int ID)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "UPDATE IPs SET Numeracion='" + numeracion + "', IPS='" + ip + "', Id_Mascara='" + mascara + "', Id_Puerta='" + puerta + "', Id_DNS='" + dns1 + "', Id_DNS2='" + dns2 + "' WHERE Id_IP = " + ID + "";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }
        public void ActualizarB103(string numeracion, string ip, int mascara, int puerta, int dns1, int dns2, int ID)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "UPDATE IPs SET Numeracion='" + numeracion + "', IPS='" + ip + "', Id_Mascara='" + mascara + "', Id_Puerta='" + puerta + "', Id_DNS='" + dns1 + "', Id_DNS2='" + dns2 + "' WHERE Id_IP = " + ID + "";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }
        public void ActualizarB204(string numeracion, string ip, int mascara, int puerta, int dns1, int dns2, int ID)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "UPDATE IPs SET Numeracion='" + numeracion + "', IPS='" + ip + "', Id_Mascara='" + mascara + "', Id_Puerta='" + puerta + "', Id_DNS='" + dns1 + "', Id_DNS2='" + dns2 + "' WHERE Id_IP = " + ID + "";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }
        public void ActualizarB206(string numeracion, string ip, int mascara, int puerta, int dns1, int dns2, int ID)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "UPDATE IPs SET Numeracion='" + numeracion + "', IPS='" + ip + "', Id_Mascara='" + mascara + "', Id_Puerta='" + puerta + "', Id_DNS='" + dns1 + "', Id_DNS2='" + dns2 + "' WHERE Id_IP = " + ID + "";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }
        public void ActualizarC103(string numeracion, string ip, int mascara, int puerta, int dns1, int dns2, int ID)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "UPDATE IPs SET Numeracion='" + numeracion + "', IPS='" + ip + "', Id_Mascara='" + mascara + "', Id_Puerta='" + puerta + "', Id_DNS='" + dns1 + "', Id_DNS2='" + dns2 + "' WHERE Id_IP = " + ID + "";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }
        public void ActualizarMascara(string mascara, int ID)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "UPDATE Mascara SET Mascara='" + mascara + "' WHERE Id_mascara = " + ID + "";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }
        public void ActualizarPuerta(string puerta, int ID)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "UPDATE Puerta_Enlace SET Puerta_Enlace='" + puerta + "' WHERE Id_puerta = " + ID + "";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }
        public void ActualizarDNS(string dns, int ID)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "UPDATE DNS SET DNS='" + dns + "' WHERE Id_DNS = " + ID + "";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }
        public void ActualizarDNS2(string dns, int ID)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "UPDATE DNS2 SET DNS2='" + dns + "' WHERE Id_DNS2 = " + ID + "";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }
        public void Eliminar(int Id)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "Delete from IPs WHERE Id_IP = " + Id + " ";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Comando.Connection = conexion.CerrarConexion();
        }
        public void EliminarMascara(int Id)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "Delete from Mascara WHERE Id_mascara = " + Id + " ";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Comando.Connection = conexion.CerrarConexion();
        }
        public void EliminarPuerta(int Id)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "Delete from Puerta_Enlace WHERE Id_puerta = " + Id + " ";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Comando.Connection = conexion.CerrarConexion();
        }
        public void EliminarDNS(int Id)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "Delete from DNS WHERE Id_DNS = " + Id + " ";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Comando.Connection = conexion.CerrarConexion();
        }
        public void EliminarDNS2(int Id)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "Delete from DNS2 WHERE Id_DNS2 = " + Id + " ";
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            Comando.Connection = conexion.CerrarConexion();
        }
    }
}
