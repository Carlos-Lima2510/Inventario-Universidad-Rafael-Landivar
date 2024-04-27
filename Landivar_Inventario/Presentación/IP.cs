using Landivar_Inventario.Datos;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Net;

namespace Landivar_Inventario.Presentación
{
    public partial class IP : Form
    {
        static string server = Dns.GetHostName();
        private string connectionString = "Server= "+ server +"; DataBase=Landivar; Integrated Security=true";
        public IP()
        {
            InitializeComponent();
            try
            {
                MostrarIPs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }
        private void MostrarIPs()
        {
            IPs ps = new IPs();
            dataGridViewA103IPMostrar.DataSource = ps.ControlIPCentralA103M();
            dataGridViewC103IPMostrar.DataSource = ps.ControlIPCentralC103M();
            dataGridViewB103IPMostrar.DataSource = ps.ControlIPAnexoB103M();
            dataGridViewB204IPMostrar.DataSource = ps.ControlIPAnexoB204M();
            dataGridViewB206IPMostrar.DataSource = ps.ControlIPAnexoB206M();
            dataGridViewA103IPCrear.DataSource = ps.ControlIPCentralA103M();
            dataGridViewB103IPCrear.DataSource = ps.ControlIPAnexoB103M();
            dataGridViewB204IPCrear.DataSource = ps.ControlIPAnexoB204M();
            dataGridViewB206IPCrear.DataSource = ps.ControlIPAnexoB206M();
            dataGridViewC103IPCrear.DataSource = ps.ControlIPCentralC103M();
            dataGridViewA103IPACT.DataSource = ps.ControlIPCentralA103();
            dataGridViewB103IPACT.DataSource = ps.ControlIPAnexoB103();
            dataGridViewB204IPACT.DataSource = ps.ControlIPAnexoB204();
            dataGridViewB206IPACT.DataSource = ps.ControlIPAnexoB206();
            dataGridViewC103IPACT.DataSource = ps.ControlIPCentralC103();

        }
        private void InsertarIPA103()
        {
            IPs ps = new IPs();
            ps.InsertaIPA103(
                comboNumA103Crear.Text, textIPA103Crear.Text, Convert.ToInt32(ComboIDMascaraA103.Text), Convert.ToInt32(ComboIDPEnlaceA103.Text), Convert.ToInt32(ComboIDNS1A103.Text), Convert.ToInt32(ComboIDNS2A103.Text)
                );
        }
        private void InsertarIPB103()
        {
            IPs ps = new IPs();
            ps.InsertaIPB103(
                comboNumB103Crear.Text, textIPB103Crear.Text, Convert.ToInt32(ComboIDMascaraB103.Text), Convert.ToInt32(ComboIDPEnlaceB103.Text), Convert.ToInt32(ComboIDNS1B103.Text), Convert.ToInt32(ComboIDNS2B103.Text)
                );
        }
        private void InsertarIPB204()
        {
            IPs ps = new IPs();
            ps.InsertaIPB204(
                comboNumB204Crear.Text, textIPB204Crear.Text, Convert.ToInt32(ComboIDMascaraB204.Text), Convert.ToInt32(ComboIDPEnlaceB204.Text), Convert.ToInt32(ComboIDNS1B204.Text), Convert.ToInt32(ComboIDNS2B204.Text)
                );
        }
        private void InsertarIPB206()
        {
            IPs ps = new IPs();
            ps.InsertaIPB206(
                comboNumB206Crear.Text, textIPB206Crear.Text, Convert.ToInt32(ComboIDMascaraB206.Text), Convert.ToInt32(ComboIDPEnlaceB206.Text), Convert.ToInt32(ComboIDNS1B206.Text), Convert.ToInt32(ComboIDNS2B206.Text)
                );
        }
        private void InsertarIPC103()
        {
            IPs ps = new IPs();
            ps.InsertaIPC103(
                comboNumC103Crear.Text, textIPC103Crear.Text, Convert.ToInt32(ComboIDMascaraC103.Text), Convert.ToInt32(ComboIDPEnlaceC103.Text), Convert.ToInt32(ComboIDNS1C103.Text), Convert.ToInt32(ComboIDNS2C103.Text)
                );
        }
        private void panel2_Paint(object sender, PaintEventArgs e)  
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "LAB A - 103")
            {
                dataGridViewA103IPMostrar.Show();
                btn_ExcelA103IP.Show();
            }
            else
            {
                dataGridViewA103IPMostrar.Hide();
                btn_ExcelA103IP.Hide();

            }
            if (comboBox1.Text == "LAB B - 103")
            {
                dataGridViewB103IPMostrar.Show();
                btn_ExcelB103IP.Show();

            }
            else
            {
                dataGridViewB103IPMostrar.Hide();
                btn_ExcelB103IP.Hide();
            }
            if (comboBox1.Text == "LAB C - 103")
            {
                dataGridViewC103IPMostrar.Show();
                btn_ExcelC103IP.Show();
            }
            else
            {
                dataGridViewC103IPMostrar.Hide();
                btn_ExcelC103IP.Hide();
            }
            if (comboBox1.Text == "LAB B - 204")
            {
                dataGridViewB204IPMostrar.Show();
                btn_ExcelB204IP.Show();
            }
            else
            {
                dataGridViewB204IPMostrar.Hide();
                btn_ExcelB204IP.Hide();
            }
            if (comboBox1.Text == "LAB B - 206")
            {
                dataGridViewB206IPMostrar.Show();
                btn_ExcelB206IP.Show();
            }
            else
            {
                dataGridViewB206IPMostrar.Hide();
                btn_ExcelB206IP.Hide();
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void IP_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Mascara";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        comboMascaraA103Crear.Items.Add(reader["Mascara"].ToString());
                        comboMascaraB103Crear.Items.Add(reader["Mascara"].ToString());
                        comboMascaraB204Crear.Items.Add(reader["Mascara"].ToString());
                        comboMascaraB206Crear.Items.Add(reader["Mascara"].ToString());
                        comboMascaraC103Crear.Items.Add(reader["Mascara"].ToString());
                        comboMascaraA103ACT.Items.Add(reader["Mascara"].ToString());
                        comboMascaraB103ACT.Items.Add(reader["Mascara"].ToString());
                        comboMascaraB204ACT.Items.Add(reader["Mascara"].ToString());
                        comboMascaraB206ACT.Items.Add(reader["Mascara"].ToString());
                        comboMascaraC103ACT.Items.Add(reader["Mascara"].ToString());
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                    MessageBox.Show("Error al cargar los datos: " + ex.Message);
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Puerta_Enlace";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        comboPEnlaceA103Crear.Items.Add(reader["Puerta_Enlace"].ToString());
                        comboPEnlaceB103Crear.Items.Add(reader["Puerta_Enlace"].ToString());
                        comboPEnlaceB204Crear.Items.Add(reader["Puerta_Enlace"].ToString());
                        comboPEnlaceB206Crear.Items.Add(reader["Puerta_Enlace"].ToString());
                        comboPEnlaceC103Crear.Items.Add(reader["Puerta_Enlace"].ToString());
                        comboPEnlaceA103ACT.Items.Add(reader["Puerta_Enlace"].ToString());
                        comboPEnlaceB103ACT.Items.Add(reader["Puerta_Enlace"].ToString());
                        comboPEnlaceB204ACT.Items.Add(reader["Puerta_Enlace"].ToString());
                        comboPEnlaceB206ACT.Items.Add(reader["Puerta_Enlace"].ToString());
                        comboPEnlaceC103ACT.Items.Add(reader["Puerta_Enlace"].ToString());
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                    MessageBox.Show("Error al cargar los datos: " + ex.Message);
                }
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from DNS";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        comboDNS1A103Crear.Items.Add(reader["DNS"].ToString());
                        comboDNS1B103Crear.Items.Add(reader["DNS"].ToString());
                        comboDNS1B204Crear.Items.Add(reader["DNS"].ToString());
                        comboDNS1B206Crear.Items.Add(reader["DNS"].ToString());
                        comboDNS1C103Crear.Items.Add(reader["DNS"].ToString());
                        comboDNS1A103ACT.Items.Add(reader["DNS"].ToString());
                        comboDNS1B103ACT.Items.Add(reader["DNS"].ToString());
                        comboDNS1B204ACT.Items.Add(reader["DNS"].ToString());
                        comboDNS1B206ACT.Items.Add(reader["DNS"].ToString());
                        comboDNS1C103ACT.Items.Add(reader["DNS"].ToString());

                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                    MessageBox.Show("Error al cargar los datos: " + ex.Message);
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from DNS2";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        comboDNS2A103Crear.Items.Add(reader["DNS2"].ToString());
                        comboDNS2B103Crear.Items.Add(reader["DNS2"].ToString());
                        comboDNS2B204Crear.Items.Add(reader["DNS2"].ToString());
                        comboDNS2B206Crear.Items.Add(reader["DNS2"].ToString());
                        comboDNS2C103Crear.Items.Add(reader["DNS2"].ToString());
                        comboDNS2A103ACT.Items.Add(reader["DNS2"].ToString());
                        comboDNS2B103ACT.Items.Add(reader["DNS2"].ToString());
                        comboDNS2B204ACT.Items.Add(reader["DNS2"].ToString());
                        comboDNS2B206ACT.Items.Add(reader["DNS2"].ToString());
                        comboDNS2C103ACT.Items.Add(reader["DNS2"].ToString());

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

        private void btn_Ingresar_Click(object sender, EventArgs e)
        {
            try
            {
                InsertarIPA103();
                MostrarIPs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboDNS1A103Crear.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from DNS WHERE DNS = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_DNS"].ToString();

                        ComboIDNS1A103.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboMascaraA103Crear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboMascaraA103Crear.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Mascara WHERE Mascara = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_mascara"].ToString();

                        ComboIDMascaraA103.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboPEnlaceA103Crear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboPEnlaceA103Crear.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Puerta_Enlace WHERE Puerta_Enlace = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_puerta"].ToString();

                        ComboIDPEnlaceA103.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboDNS2A103Crear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboDNS2A103Crear.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from DNS2 WHERE DNS2 = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_DNS2"].ToString();

                        ComboIDNS2A103.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboMascaraB103Crear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboMascaraB103Crear.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Mascara WHERE Mascara = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_mascara"].ToString();

                        ComboIDMascaraB103.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }
        }

        private void comboPEnlaceB103Crear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboPEnlaceB103Crear.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Puerta_Enlace WHERE Puerta_Enlace = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_puerta"].ToString();

                        ComboIDPEnlaceB103.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }
        }

        private void comboDNS1B103Crear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboDNS1B103Crear.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from DNS WHERE DNS = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_DNS"].ToString();

                        ComboIDNS1B103.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboDNS2B103Crear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboDNS2B103Crear.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from DNS2 WHERE DNS2 = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_DNS2"].ToString();

                        ComboIDNS2B103.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void btn_IngresarB103_Click(object sender, EventArgs e)
        {
            try
            {
                InsertarIPB103();
                MostrarIPs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void comboMascaraB204Crear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboMascaraB204Crear.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Mascara WHERE Mascara = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_mascara"].ToString();

                        ComboIDMascaraB204.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }
        }

        private void comboPEnlaceB204Crear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboPEnlaceB204Crear.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Puerta_Enlace WHERE Puerta_Enlace = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_puerta"].ToString();

                        ComboIDPEnlaceB204.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboDNS1B204Crear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboDNS1B204Crear.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from DNS WHERE DNS = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_DNS"].ToString();

                        ComboIDNS1B204.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboDNS2B204Crear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboDNS2B204Crear.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from DNS2 WHERE DNS2 = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_DNS2"].ToString();

                        ComboIDNS2B204.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void btn_IngresarB204_Click(object sender, EventArgs e)
        {
            try
            {
                InsertarIPB204();
                MostrarIPs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void dataGridViewA103IPCrear_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void dataGridViewA103IPMostrar_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void dataGridViewB103IPCrear_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void dataGridViewB103IPMostrar_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void dataGridViewB204IPCrear_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void dataGridViewB204IPMostrar_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {


        }

        private void dataGridViewB206IPMostrar_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {


        }

        private void dataGridViewC103IPMostrar_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void comboMascaraB206Crear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboMascaraB206Crear.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Mascara WHERE Mascara = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_mascara"].ToString();

                        ComboIDMascaraB206.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboPEnlaceB206Crear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboPEnlaceB206Crear.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Puerta_Enlace WHERE Puerta_Enlace = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Puerta"].ToString();

                        ComboIDPEnlaceB206.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboDNS1B206Crear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboDNS1B206Crear.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from DNS WHERE DNS = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_DNS"].ToString();

                        ComboIDNS1B206.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboDNS2B206Crear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboDNS2B206Crear.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from DNS2 WHERE DNS2 = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_DNS2"].ToString();

                        ComboIDNS2B206.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void btn_IngresarB206_Click(object sender, EventArgs e)
        {
            try
            {
                InsertarIPB206();
                MostrarIPs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void dataGridViewB206IPCrear_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }
        private void exportarExcel(DataGridView tabla)
        {

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            excel.Application.Workbooks.Add(true);
            int indiceColumna = 0;

            foreach (DataGridViewColumn col in tabla.Columns) // columnas
            {
                indiceColumna++;
                excel.Cells[1, indiceColumna] = col.Name;
            }

            int indiceFila = 0;

            foreach (DataGridViewRow row in tabla.Rows) //fila
            {
                indiceFila++;
                indiceColumna = 0;
                foreach (DataGridViewColumn col in tabla.Columns)
                {
                    indiceColumna++;
                    excel.Cells[indiceFila + 1, indiceColumna] = row.Cells[col.Name].Value;
                }
            }

            excel.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                exportarExcel(dataGridViewA103IPMostrar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }

        }

        private void btn_ExcelB103IP_Click(object sender, EventArgs e)
        {
            try
            {
                exportarExcel(dataGridViewB103IPMostrar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void btn_ExcelC103IP_Click(object sender, EventArgs e)
        {
            try
            {
                exportarExcel(dataGridViewC103IPMostrar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void btn_ExcelB204IP_Click(object sender, EventArgs e)
        {
            try
            {
                exportarExcel(dataGridViewB204IPMostrar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btn_ExcelB206IP_Click(object sender, EventArgs e)
        {
            try
            {
                exportarExcel(dataGridViewB206IPMostrar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void comboMascaraC103Crear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboMascaraC103Crear.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Mascara WHERE Mascara = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_mascara"].ToString();

                        ComboIDMascaraC103.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboPEnlaceC103Crear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboPEnlaceC103Crear.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Puerta_Enlace WHERE Puerta_Enlace = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_puerta"].ToString();

                        ComboIDPEnlaceC103.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboDNS1C103Crear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboDNS1C103Crear.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from DNS WHERE DNS = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_DNS"].ToString();

                        ComboIDNS1C103.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboDNS2C103Crear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboDNS2C103Crear.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from DNS2 WHERE DNS2 = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_DNS2"].ToString();

                        ComboIDNS2C103.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void btn_IngresarC103_Click(object sender, EventArgs e)
        {
            try
            {
                InsertarIPC103();
                MostrarIPs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void comboLocacionCrear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboLocacionCrear.Text == "LAB A - 103")
            {
                panelA103Crear.Show();
                dataGridViewA103IPCrear.Show();
            }
            else
            {
                panelA103Crear.Hide();
                dataGridViewA103IPCrear.Hide();
            }
            if (comboLocacionCrear.Text == "LAB B - 103")
            {
                panelB103Crear.Show();
                dataGridViewB103IPCrear.Show();
            }
            else
            {
                panelB103Crear.Hide();
                dataGridViewB103IPCrear.Hide();
            }
            if (comboLocacionCrear.Text == "LAB C - 103")
            {
                panelC103Crear.Show();
                dataGridViewC103IPCrear.Show();
            }
            else
            {
                panelC103Crear.Hide();
                dataGridViewC103IPCrear.Hide();
            }
            if (comboLocacionCrear.Text == "LAB B - 204")
            {
                panelB204Crear.Show();
                dataGridViewB204IPCrear.Show();
            }
            else
            {
                panelB204Crear.Hide();
                dataGridViewB204IPCrear.Hide();
            }
            if (comboLocacionCrear.Text == "LAB B - 206")
            {
                panelB206Crear.Show();
                dataGridViewB206IPCrear.Show();
            }
            else
            {
                panelB206Crear.Hide();
                dataGridViewB206IPCrear.Hide();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Inicio inicio = new Inicio();
            inicio.Show();
        }

        private void comboMascaraA103ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboMascaraA103ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Mascara WHERE Mascara = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Mascara"].ToString();

                        ComboIDMascaraA103ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }
        }

        private void comboDNS1A103ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboDNS1A103ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from DNS WHERE DNS = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_DNS"].ToString();

                        ComboIDDNS1A103ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }
        }

        private void comboDNS2A103ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboDNS2A103ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from DNS2 WHERE DNS2 = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_DNS2"].ToString();

                        ComboIDDNS2A103ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }
        }

        private void comboPEnlaceA103ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboPEnlaceA103ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Puerta_Enlace WHERE Puerta_Enlace = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Puerta"].ToString();

                        ComboIDPEnlaceA103ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }
        }
        private void EliminarA103()
        {
            IPs ips = new IPs();
            ips.Eliminar(Convert.ToInt32(IDIPBA103.Text));
            MessageBox.Show("Se elimino correctamente");
        }
        private void EliminarB103()
        {
            IPs iP = new IPs();
            iP.Eliminar(Convert.ToInt32(IDIPB103.Text));
            MessageBox.Show("Se elimino correctamente");
        }
        private void EliminarB204()
        {
            IPs iP = new IPs();
            iP.Eliminar(Convert.ToInt32(IDIPB204.Text));
            MessageBox.Show("Se elimino correctamente");
        }
        private void EliminarB206()
        {
            IPs iP = new IPs();
            iP.Eliminar(Convert.ToInt32(IDIPB206ACT.Text));
            MessageBox.Show("Se elimino correctamente");
        }
        private void EliminarC103()
        {
            IPs iP = new IPs();
            iP.Eliminar(Convert.ToInt32(IDIPC103.Text));
            MessageBox.Show("Se elimino correctamente");
        }
        private void IDIPA103_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewA103IPACT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IDIPBA103.Text = dataGridViewA103IPACT.Rows[e.RowIndex].Cells[0].Value.ToString();
                comboNumA103ACT.Text = dataGridViewA103IPACT.Rows[e.RowIndex].Cells[1].Value.ToString();
                textIPA103ACT.Text = dataGridViewA103IPACT.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboPEnlaceA103ACT.Text = dataGridViewA103IPACT.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboDNS1A103ACT.Text = dataGridViewA103IPACT.Rows[e.RowIndex].Cells[4].Value.ToString();
                comboDNS2A103ACT.Text = dataGridViewA103IPACT.Rows[e.RowIndex].Cells[5].Value.ToString();
                comboMascaraA103ACT.Text = dataGridViewA103IPACT.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                EliminarA103();
                MostrarIPs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }
       private void ActualizarIPA103()
        {
            IPs ip = new IPs();
            ip.ActualizarA103(
                comboNumA103ACT.Text, textIPA103ACT.Text, Convert.ToInt32(ComboIDMascaraA103ACT.Text), Convert.ToInt32(ComboIDPEnlaceA103ACT.Text), Convert.ToInt32(ComboIDDNS1A103ACT.Text), Convert.ToInt32(ComboIDDNS2A103ACT.Text), Convert.ToInt32(IDIPBA103.Text)
                );
            MessageBox.Show("Se actualizo correctamente");
        }
        private void btn_ACTA103_Click(object sender, EventArgs e)
        {
            try
            {
                ActualizarIPA103();
                MostrarIPs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void dataGridViewC103IPCrear_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboNumA103ACT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textIPA103ACT_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboMascaraB103ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboMascaraB103ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Mascara WHERE Mascara = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Mascara"].ToString();

                        ComboIDMascaraB103ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }
        }

        private void comboPEnlaceB103ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboPEnlaceB103ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Puerta_Enlace WHERE Puerta_Enlace = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Puerta"].ToString();

                        ComboIDPEnlaceB103ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }
        }

        private void comboDNS1B103ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboDNS1B103ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from DNS WHERE DNS = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_DNS"].ToString();

                        ComboIDDNS1B103ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }
        }

        private void comboDNS2B103ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboDNS2B103ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from DNS2 WHERE DNS2 = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_DNS2"].ToString();

                        ComboIDDNS2B103ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }
        }

        private void ActualizarIPB103()
        {
            IPs ip = new IPs();
            ip.ActualizarB103(
                comboNumB103ACT.Text, textIPB103ACT.Text, Convert.ToInt32(ComboIDMascaraB103ACT.Text), Convert.ToInt32(ComboIDPEnlaceB103ACT.Text), Convert.ToInt32(ComboIDDNS1B103ACT.Text), Convert.ToInt32(ComboIDDNS2B103ACT.Text), Convert.ToInt32(IDIPB103.Text)
                );
            MessageBox.Show("Se actualizo correctamente");
        }
        private void ActualizarIPB204()
        {
            IPs ip = new IPs();
            ip.ActualizarB204(
                comboNumB204ACT.Text, textIPB204ACT.Text, Convert.ToInt32(ComboIDMascaraB204ACT.Text), Convert.ToInt32(ComboIDPEnlaceB204ACT.Text), Convert.ToInt32(ComboIDDNS1B204ACT.Text), Convert.ToInt32(ComboIDDNS2B204ACT.Text), Convert.ToInt32(IDIPB204.Text)
                );
            MessageBox.Show("Se actualizo correctamente");
        }
        private void ActualizarIPB206()
        {
            IPs ip = new IPs();
            ip.ActualizarB206(
                comboNumB206ACT.Text, textIPB206ACT.Text, Convert.ToInt32(ComboIDMascaraB206ACT.Text), Convert.ToInt32(ComboIDPEnlaceB206ACT.Text), Convert.ToInt32(ComboIDNS1B206ACT.Text), Convert.ToInt32(ComboIDNS2B206ACT.Text), Convert.ToInt32(IDIPB206ACT.Text)
                );
            MessageBox.Show("Se actualizo correctamente");
        }
        private void ActualizarIPC103()
        {
            IPs ip = new IPs();
            ip.ActualizarC103(
                comboNumC103ACT.Text, textIPC103ACT.Text, Convert.ToInt32(ComboIDMascaraC103ACT.Text), Convert.ToInt32(ComboIDPEnlaceC103ACT.Text), Convert.ToInt32(ComboIDNS1C103ACT.Text), Convert.ToInt32(ComboIDNS2C103ACT.Text), Convert.ToInt32(IDIPC103.Text)
                );
            MessageBox.Show("Se actualizo correctamente");
        }

        private void btn_ACTB103_Click(object sender, EventArgs e)
        {
            try
            {
                ActualizarIPB103();
                MostrarIPs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void btn_EliminarC103_Click(object sender, EventArgs e)
        {
        }

        private void dataGridViewC103IPACT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IDIPB103.Text = dataGridViewB103IPACT.Rows[e.RowIndex].Cells[0].Value.ToString();
                comboNumB103ACT.Text = dataGridViewB103IPACT.Rows[e.RowIndex].Cells[1].Value.ToString();
                textIPB103ACT.Text = dataGridViewB103IPACT.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboPEnlaceB103ACT.Text = dataGridViewB103IPACT.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboDNS1B103ACT.Text = dataGridViewB103IPACT.Rows[e.RowIndex].Cells[4].Value.ToString();
                comboDNS2B103ACT.Text = dataGridViewB103IPACT.Rows[e.RowIndex].Cells[5].Value.ToString();
                comboMascaraB103ACT.Text = dataGridViewB103IPACT.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }

        }

        private void btn_EliminarB103_Click(object sender, EventArgs e)
        {
            try
            {
                EliminarB103();
                MostrarIPs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void comboMascaraB204ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboMascaraB204ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Mascara WHERE Mascara = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Mascara"].ToString();

                        ComboIDMascaraB204ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboPEnlaceB204ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboPEnlaceB204ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Puerta_Enlace WHERE Puerta_Enlace = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Puerta"].ToString();

                        ComboIDPEnlaceB204ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboDNS1B204ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboDNS1B204ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from DNS WHERE DNS = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_DNS"].ToString();

                        ComboIDDNS1B204ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboDNS2B204ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboDNS2B204ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from DNS2 WHERE DNS2 = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_DNS2"].ToString();

                        ComboIDDNS2B204ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void dataGridViewB204IPACT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IDIPB204.Text = dataGridViewB204IPACT.Rows[e.RowIndex].Cells[0].Value.ToString();
                comboNumB204ACT.Text = dataGridViewB204IPACT.Rows[e.RowIndex].Cells[1].Value.ToString();
                textIPB204ACT.Text = dataGridViewB204IPACT.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboPEnlaceB204ACT.Text = dataGridViewB204IPACT.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboDNS1B204ACT.Text = dataGridViewB204IPACT.Rows[e.RowIndex].Cells[4].Value.ToString();
                comboDNS2B204ACT.Text = dataGridViewB204IPACT.Rows[e.RowIndex].Cells[5].Value.ToString();
                comboMascaraB204ACT.Text = dataGridViewB204IPACT.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }

        }

        private void btn_ActualizarB204_Click(object sender, EventArgs e)
        {
            try
            {
                ActualizarIPB204();
                MostrarIPs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }

        }

        private void comboNumB206ACT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboMascaraB206ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboMascaraB206ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Mascara WHERE Mascara = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Mascara"].ToString();

                        ComboIDMascaraB206ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboPEnlaceB206ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboPEnlaceB206ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Puerta_Enlace WHERE Puerta_Enlace = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Puerta"].ToString();

                        ComboIDPEnlaceB206ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboDNS1B206ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboDNS1B206ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from DNS WHERE DNS = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_DNS"].ToString();

                        ComboIDNS1B206ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }
        }

        private void comboDNS2B206ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboDNS2B206ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from DNS2 WHERE DNS2 = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_DNS2"].ToString();

                        ComboIDNS2B206ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void dataGridViewB206IPACT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IDIPB206ACT.Text = dataGridViewB206IPACT.Rows[e.RowIndex].Cells[0].Value.ToString();
                comboNumB206ACT.Text = dataGridViewB206IPACT.Rows[e.RowIndex].Cells[1].Value.ToString();
                textIPB206ACT.Text = dataGridViewB206IPACT.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboPEnlaceB206ACT.Text = dataGridViewB206IPACT.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboDNS1B206ACT.Text = dataGridViewB206IPACT.Rows[e.RowIndex].Cells[4].Value.ToString();
                comboDNS2B206ACT.Text = dataGridViewB206IPACT.Rows[e.RowIndex].Cells[5].Value.ToString();
                comboMascaraB206ACT.Text = dataGridViewB206IPACT.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }

        }

        private void btn_ActualizarB206_Click(object sender, EventArgs e)
        {
            try
            {
                ActualizarIPB206();
                MostrarIPs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void btn_EliminarB206_Click(object sender, EventArgs e)
        {
            try
            {
                EliminarB206();
                MostrarIPs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void btn_EliminarB204_Click(object sender, EventArgs e)
        {
            try
            {
                EliminarB204();
                MostrarIPs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox2.Text == "LAB A - 103")
            {
                panelA103ACT.Show();
                dataGridViewA103IPACT.Show();
            }
            else
            {
                panelA103ACT.Hide();
                dataGridViewA103IPACT.Hide();
            }
            if (comboBox2.Text == "LAB B - 103")
            {
                panelB103ACT.Show();
                dataGridViewB103IPACT.Show();
            }
            else
            {
                panelB103ACT.Hide();
                dataGridViewB103IPACT.Hide();
            }
            if (comboBox2.Text == "LAB C - 103")
            {
                panelC103ACT.Show();
                dataGridViewC103IPACT.Show();
            }
            else
            {
                panelC103ACT.Hide();
                dataGridViewC103IPACT.Hide();
            }
            if (comboBox2.Text == "LAB B - 204")
            {
                panelB204ACT.Show();
                dataGridViewB204IPACT.Show();
            }
            else
            {
                panelB204ACT.Hide();
                dataGridViewB204IPACT.Hide();

            }
            if (comboBox2.Text == "LAB B - 206")
            {
                panelB206ACT.Show();
                dataGridViewB206IPACT.Show();
            }
            else
            {
                panelB206ACT.Hide();
                dataGridViewB206IPACT.Hide();
            }

        }

        private void dataGridViewC103IPACT_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IDIPC103.Text = dataGridViewC103IPACT.Rows[e.RowIndex].Cells[0].Value.ToString();
                comboNumC103ACT.Text = dataGridViewC103IPACT.Rows[e.RowIndex].Cells[1].Value.ToString();
                textIPC103ACT.Text = dataGridViewC103IPACT.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboPEnlaceC103ACT.Text = dataGridViewC103IPACT.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboDNS1C103ACT.Text = dataGridViewC103IPACT.Rows[e.RowIndex].Cells[4].Value.ToString();
                comboDNS2C103ACT.Text = dataGridViewC103IPACT.Rows[e.RowIndex].Cells[5].Value.ToString();
                comboMascaraC103ACT.Text = dataGridViewC103IPACT.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void comboMascaraC103ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboMascaraC103ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Mascara WHERE Mascara = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Mascara"].ToString();

                        ComboIDMascaraC103ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboPEnlaceC103ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboPEnlaceC103ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Puerta_Enlace WHERE Puerta_Enlace = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Puerta"].ToString();

                        ComboIDPEnlaceC103ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }
        }

        private void comboDNS1C103ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboDNS1C103ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from DNS WHERE DNS = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_DNS"].ToString();

                        ComboIDNS1C103ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboDNS2C103ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboDNS2C103ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from DNS2 WHERE DNS2 = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_DNS2"].ToString();

                        ComboIDNS2C103ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void btn_ActualizarC103_Click(object sender, EventArgs e)
        {
            try
            {
                ActualizarIPC103();
                MostrarIPs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }

        }

        private void btn_EliminarC103_Click_1(object sender, EventArgs e)
        {
            try
            {
                EliminarC103();
                MostrarIPs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void btn_ConfigRed_Click(object sender, EventArgs e)
        {
            this.Hide();
            Redes redes = new Redes();
            redes.Show();
        }

        private void dataGridViewA103IPACT_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewColumn columnanombre = dataGridViewA103IPACT.Columns["Id_IP"];
            columnanombre.Visible = false;
        }

        private void dataGridViewB103IPACT_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewColumn columnanombre = dataGridViewB103IPACT.Columns["Id_IP"];
            columnanombre.Visible = false;
        }

        private void dataGridViewB204IPACT_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewColumn columnanombre = dataGridViewB204IPACT.Columns["Id_IP"];
            columnanombre.Visible = false;
        }

        private void dataGridViewB206IPACT_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewColumn columnanombre = dataGridViewB206IPACT.Columns["Id_IP"];
            columnanombre.Visible = false;
        }

        private void dataGridViewC103IPACT_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewColumn columnanombre = dataGridViewC103IPACT.Columns["Id_IP"];
            columnanombre.Visible = false;
        }
    }
}
