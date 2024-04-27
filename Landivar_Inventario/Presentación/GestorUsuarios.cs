using Landivar_Inventario.Datos;
using System;
using System.Data.SqlClient;
using System.Net;
using System.Reflection.Emit;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Landivar_Inventario.Presentación
{
    public partial class GestorUsuarios : Form
    {
        static string server = Dns.GetHostName();
        private string connectionString = "Server= " + server + "; DataBase=Landivar; Integrated Security=true";
        public GestorUsuarios()
        {
            InitializeComponent();
            MostrarUsuarios();
        }

        private void MostrarUsuarios()
        {
            Usuarios usuarios = new Usuarios();
            dataGridViewUsuarios.DataSource = usuarios.VistaUsuarios();
            dataGridViewUsuariosCrear.DataSource = usuarios.VistaUsuarios();
            dataGridView1.DataSource = usuarios.VistaUsuarios();
        }
        private void InsertarUsuarios()
        {
            Usuarios usuarios = new Usuarios();
            usuarios.Insertar(
                text_Nombre.Text, textCredencial.Text, textContraseña.Text, Convert.ToInt32(IDRol.Text)
                );
        }
        private void ActualizarUsuarios()
        {
            Usuarios usuarios = new Usuarios();
            usuarios.Actualizar(
                textNombreACT.Text, textcredencialACT.Text, textContraseñaACT.Text, Convert.ToInt32(IDRolACT.Text), Convert.ToInt32(IDUsuarios.Text)
                );
        }
        private void EliminarUsuarios()
        {
            Usuarios usuarios = new Usuarios();
            usuarios.Eliminar(
                Convert.ToInt32(IDUsuarios.Text)
                );
        }

        private void btn_Ingresar_Click(object sender, EventArgs e)
        {
            try
            {
                InsertarUsuarios();
                MostrarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void comboRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboRol.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Roles WHERE Nombre_Rol = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Roles"].ToString();

                        IDRol.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void GestorUsuarios_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Roles";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        comboRol.Items.Add(reader["Nombre_Rol"].ToString());
                        comboRolACT.Items.Add(reader["Nombre_Rol"].ToString());

                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                    MessageBox.Show("Error al cargar los datos: " + ex.Message);
                }
            }

        }

        private void comboRolACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboRolACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Roles WHERE Nombre_Rol = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Roles"].ToString();

                        IDRolACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IDUsuarios.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textNombreACT.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textcredencialACT.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textContraseñaACT.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboRolACT.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewColumn columnanombre = dataGridView1.Columns["Id_Usuario"];
            columnanombre.Visible = false;
        }

        private void dataGridViewUsuariosCrear_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewColumn columnanombre = dataGridViewUsuariosCrear.Columns["Id_Usuario"];
            columnanombre.Visible = false;
        }

        private void dataGridViewUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewUsuarios_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewColumn columnanombre = dataGridViewUsuarios.Columns["Id_Usuario"];
            columnanombre.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ActualizarUsuarios();
                MostrarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                EliminarUsuarios();
                MostrarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void btn_Minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
    }
}
