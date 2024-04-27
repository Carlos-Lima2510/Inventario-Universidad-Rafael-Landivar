using Landivar_Inventario.Datos;
using System;
using System.Data.SqlClient;
using System.Net;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using DocumentFormat.OpenXml.Office2019.Drawing.Animation;

namespace Landivar_Inventario.Presentación
{
    public partial class F_Inventario : Form
    {
        static string server = Dns.GetHostName();
        private string connectionString = "Server= "+ server +"; DataBase=Landivar; Integrated Security=true";
        public F_Inventario()
        {
            InitializeComponent();
            MostrarInventario();

        }
        private void MostrarInventario()
        {
            Inventario inventario = new Inventario();
            dataGridViewSJMostrar.DataSource = inventario.ListarComputadorasCentralA103M();
            dataGridViewCMostrar.DataSource = inventario.ListarComputadorasCentralC103M();
            dataGridViewAnexoMostrar.DataSource = inventario.ListarComputadorasAnexo103M();
            dataGridViewMostrarB204.DataSource = inventario.ListarComputadorasAnexo204M();
            dataGridViewMostrarB206.DataSource = inventario.ListarComputadorasAnexo206M();
            dataGridViewSJCrear.DataSource = inventario.ListarComputadorasCentralA103M();
            dataGridViewAnexoCrear.DataSource = inventario.ListarComputadorasAnexo103M();
            dataGridViewCCrear.DataSource = inventario.ListarComputadorasCentralC103M();
            dataGridViewCrearB204.DataSource = inventario.ListarComputadorasAnexo204M();
            dataGridViewCrearB206.DataSource = inventario.ListarComputadorasAnexo206M();
            dataGridViewA103ACT.DataSource = inventario.ListarComputadorasCentralA103();
            dataGridViewB103ACT.DataSource = inventario.ListarComputadorasAnexo103();
            dataGridViewB204ACT.DataSource = inventario.ListarComputadorasAnexo204();
            dataGridViewB206ACT.DataSource = inventario.ListarComputadorasAnexo206();
            dataGridViewC103ACT.DataSource = inventario.ListarComputadorasCentralC103();

            int numberOfCellA103 = dataGridViewSJMostrar.Rows.Count;
            int numberOfCellB103 = dataGridViewAnexoMostrar.Rows.Count;
            int numberOFCellC103 = dataGridViewCMostrar.Rows.Count;
            int numberOFCellB204 = dataGridViewMostrarB204.Rows.Count;
            int numberOFCellB206 = dataGridViewMostrarB206.Rows.Count;

            for (int i = 0; i <= numberOfCellA103 - 1; i++)
            {
                dataGridViewSJMostrar.Rows[i].Cells["NumeraciónA103"].Value = i;
            }
            for (int i = 0; i <= numberOfCellB103 - 1; i++)
            {
                dataGridViewAnexoMostrar.Rows[i].Cells["NumeraciónB103"].Value = i;
            }
            for (int i = 0; i <= numberOFCellC103 - 1; i++)
            {
                dataGridViewCMostrar.Rows[i].Cells["NumeraciónC103"].Value = i;
            }
            for (int i = 0; i <= numberOFCellB204 - 1; i++)
            {
                dataGridViewMostrarB204.Rows[i].Cells["NumeraciónB204"].Value = i;
            }
            for (int i = 0; i <= numberOFCellB206 - 1; i++)
            {
                dataGridViewMostrarB206.Rows[i].Cells["NumeraciónB206"].Value = i;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void combo_Marca_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = combo_Marca.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Marca WHERE Nombre_Marca = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Marca"].ToString();

                        ComboIDMarca.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }
        }

        private void F_Inventario_Load(object sender, EventArgs e)
        {
            int numberOfCellA103 = dataGridViewSJMostrar.Rows.Count;
            int numberOfCellB103 = dataGridViewAnexoMostrar.Rows.Count;
            int numberOFCellC103 = dataGridViewCMostrar.Rows.Count;
            int numberOFCellB204 = dataGridViewMostrarB204.Rows.Count;
            int numberOFCellB206 = dataGridViewMostrarB206.Rows.Count;

            for (int i = 0; i <= numberOfCellA103 - 1; i++)
            {
                dataGridViewSJMostrar.Rows[i].Cells["NumeraciónA103"].Value = i;
            }
            for (int i = 0; i <= numberOfCellB103 - 1; i++)
            {
                dataGridViewAnexoMostrar.Rows[i].Cells["NumeraciónB103"].Value = i;
            }
            for (int i = 0; i <= numberOFCellC103 - 1; i++)
            {
                dataGridViewCMostrar.Rows[i].Cells["NumeraciónC103"].Value = i;
            }
            for (int i = 0; i <= numberOFCellB204 - 1; i++)
            {
                dataGridViewMostrarB204.Rows[i].Cells["NumeraciónB204"].Value = i;
            }
            for (int i = 0; i <= numberOFCellB206 - 1; i++)
            {
                dataGridViewMostrarB206.Rows[i].Cells["NumeraciónB206"].Value = i;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Marca";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        combo_Marca.Items.Add(reader["Nombre_Marca"].ToString());
                        comboMarcaAnexo.Items.Add(reader["Nombre_Marca"].ToString());
                        comboMarcaC.Items.Add(reader["Nombre_Marca"].ToString());
                        comboMarcaB204.Items.Add(reader["Nombre_Marca"].ToString());
                        comboMarcaB206.Items.Add(reader["Nombre_Marca"].ToString());
                        comboMarcaA103ACT.Items.Add(reader["Nombre_Marca"].ToString());
                        comboMarcaB103ACT.Items.Add(reader["Nombre_Marca"].ToString());
                        comboMarcaB204ACT.Items.Add(reader["Nombre_Marca"].ToString());
                        comboMarcaB206ACT.Items.Add(reader["Nombre_Marca"].ToString());
                        comboMarcaC103ACT.Items.Add(reader["Nombre_Marca"].ToString());
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
                string query = "SELECT * from Procesador";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        comboProcesador.Items.Add(reader["Nombre_Procesador"].ToString());
                        comboProcesadorAnexo.Items.Add(reader["Nombre_Procesador"].ToString());
                        comboProcesadorC.Items.Add(reader["Nombre_Procesador"].ToString());
                        comboProcesadorB204.Items.Add(reader["Nombre_Procesador"].ToString());
                        comboProcesadorB206.Items.Add(reader["Nombre_Procesador"].ToString());
                        comboProcesadorA103ACT.Items.Add(reader["Nombre_Procesador"].ToString());
                        comboProcesadorB103ACT.Items.Add(reader["Nombre_Procesador"].ToString());
                        comboProcesadorB204ACT.Items.Add(reader["Nombre_Procesador"].ToString());
                        comboProcesadorB206ACT.Items.Add(reader["Nombre_Procesador"].ToString());
                        comboProcesadorC103ACT.Items.Add(reader["Nombre_Procesador"].ToString());
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos: " + ex.Message);
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Disco_Duro";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        comboDisco.Items.Add(reader["Cantidad_Almacenamiento"].ToString());
                        comboDiscoAnexo.Items.Add(reader["Cantidad_Almacenamiento"].ToString());
                        comboDiscoC.Items.Add(reader["Cantidad_Almacenamiento"].ToString());
                        comboDiscoB204.Items.Add(reader["Cantidad_Almacenamiento"].ToString());
                        comboDiscoB206.Items.Add(reader["Cantidad_Almacenamiento"].ToString());
                        comboDiscoA103ACT.Items.Add(reader["Cantidad_Almacenamiento"].ToString());
                        comboDiscoB103ACT.Items.Add(reader["Cantidad_Almacenamiento"].ToString());
                        comboDiscoB204ACT.Items.Add(reader["Cantidad_Almacenamiento"].ToString());
                        comboDiscoB206ACT.Items.Add(reader["Cantidad_Almacenamiento"].ToString());
                        comboDiscoC103ACT.Items.Add(reader["Cantidad_Almacenamiento"].ToString());

                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos: " + ex.Message);
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Generacion";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        comboGeneracion.Items.Add(reader["Nombre_Generacion"].ToString());
                        comboGeneracionAnexo.Items.Add(reader["Nombre_Generacion"].ToString());
                        comboGeneracionC.Items.Add(reader["Nombre_Generacion"].ToString());
                        comboGeneracionB204.Items.Add(reader["Nombre_Generacion"].ToString());
                        comboGeneracionB206.Items.Add(reader["Nombre_Generacion"].ToString());
                        comboGeneracionA103ACT.Items.Add(reader["Nombre_Generacion"].ToString());
                        comboGeneracionB103ACT.Items.Add(reader["Nombre_Generacion"].ToString());
                        comboGeneracionB204ACT.Items.Add(reader["Nombre_Generacion"].ToString());
                        comboGeneracionB206ACT.Items.Add(reader["Nombre_Generacion"].ToString());
                        comboGeneracionC103ACT.Items.Add(reader["Nombre_Generacion"].ToString());
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos: " + ex.Message);
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Modelo";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        comboModelo.Items.Add(reader["Nombre_Modelo"].ToString());
                        comboModeloAnexo.Items.Add(reader["Nombre_Modelo"].ToString());
                        comboModeloC.Items.Add(reader["Nombre_Modelo"].ToString());
                        comboModeloB204.Items.Add(reader["Nombre_Modelo"].ToString());
                        comboModeloB206.Items.Add(reader["Nombre_Modelo"].ToString());
                        comboModeloA103ACT.Items.Add(reader["Nombre_Modelo"].ToString());
                        comboModeloB103ACT.Items.Add(reader["Nombre_Modelo"].ToString());
                        comboModeloB204ACT.Items.Add(reader["Nombre_Modelo"].ToString());
                        comboModeloB206ACT.Items.Add(reader["Nombre_Modelo"].ToString());
                        comboModeloC103ACT.Items.Add(reader["Nombre_Modelo"].ToString());
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
                string query = "SELECT * from Monitor";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        comboMonitor.Items.Add(reader["Modelo_Monitor"].ToString());
                        comboMonitorAnexo.Items.Add(reader["Modelo_Monitor"].ToString());
                        comboMonitorC.Items.Add(reader["Modelo_Monitor"].ToString());
                        comboMonitorB204.Items.Add(reader["Modelo_Monitor"].ToString());
                        comboMonitorB206.Items.Add(reader["Modelo_Monitor"].ToString());
                        comboMonitorA103ACT.Items.Add(reader["Modelo_Monitor"].ToString());
                        comboMonitorB103ACT.Items.Add(reader["Modelo_Monitor"].ToString());
                        comboMonitorB204ACT.Items.Add(reader["Modelo_Monitor"].ToString());
                        comboMonitorB206ACT.Items.Add(reader["Modelo_Monitor"].ToString());
                        comboMonitorC103ACT.Items.Add(reader["Modelo_Monitor"].ToString());
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

        private void comboProcesador_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboProcesador.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Procesador WHERE Nombre_Procesador = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Procesador"].ToString();

                        ComboIDProcesador.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboLocacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboLocacion.Text == "LAB A - 103")
            {
                panelCentral1.Show();
                dataGridViewSJCrear.Show();
            }
            else
            {
                panelCentral1.Hide();
                dataGridViewSJCrear.Hide();
            }
            if (comboLocacion.Text == "LAB B - 103")
            {
                panelAnexo1.Show();
                dataGridViewAnexoCrear.Show();
            }
            else
            {
                panelAnexo1.Hide();
                dataGridViewAnexoCrear.Hide();
            }
            if (comboLocacion.Text == "LAB C - 103")
            {
                panelC.Show();
                dataGridViewCCrear.Show();
            }
            else
            {
                panelC.Hide();
                dataGridViewCCrear.Hide();
            }
            if (comboLocacion.Text == "LAB B - 204")
            {
                panelB204.Show();
                dataGridViewCrearB204.Show();
            }
            else
            {
                panelB204.Hide();
                dataGridViewCrearB204.Hide();
            }
            if (comboLocacion.Text == "LAB B - 206")
            {
                panelB206.Show();
                dataGridViewCrearB206.Show();
            }
            else
            {
                panelB206.Hide();
                dataGridViewCrearB206.Hide();
            }

        }

        private void comboDiscoAnexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboDiscoAnexo.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Disco_Duro WHERE Cantidad_Almacenamiento = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_DiscoDuro"].ToString();

                        ComboIDDiscoAnexo.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }
        }

        private void comboProcesadorAnexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboProcesadorAnexo.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Procesador WHERE Nombre_Procesador = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Procesador"].ToString();

                        ComboIDProcesadorAnexo.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboDisco_SelectedIndexChanged(object sender, EventArgs e)
        {
                string selectedValue = comboDisco.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Disco_Duro WHERE Cantidad_Almacenamiento = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_DiscoDuro"].ToString();

                        ComboIDDisco.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void panelCentral1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioBtn4GB_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn4GB.Checked == true)
            {
                ComboIDRAM.Text = "1";
            }
            else
            {
                ComboIDRAM.Text= "0";
            }
        }

        private void radioBtn8GB_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn8GB.Checked == true)
            {
                ComboIDRAM.Text = "2";
            }
        }

        private void radioBtn12GB_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn12GB.Checked == true)
            {
                ComboIDRAM.Text = "3";
            }
        }

        private void radioBtn16GB_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn16GB.Checked == true)
            {
                ComboIDRAM.Text = "4";
            }
        }

        private void radioBtn20GB_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn20GB.Checked == true)
            {
                ComboIDRAM.Text = "5";
            }
        }

        private void radioBtn32GB_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn32GB.Checked == true)
            {
                ComboIDRAM.Text = "6";
            }
        }

        private void comboGeneracion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboGeneracion.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Generacion WHERE Nombre_Generacion = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Generacion"].ToString();

                        ComboIDGeneracion.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboMarcaAnexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboMarcaAnexo.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Marca WHERE Nombre_Marca = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Marca"].ToString();

                        ComboIDMarcaAnexo.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboGeneracionAnexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboGeneracionAnexo.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Generacion WHERE Nombre_Generacion = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Generacion"].ToString();

                        ComboIDGeneracionAnexo.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void radioBtn4GBAnexo_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn4GBAnexo.Checked == true)
            {
               IDRamAnexo.Text = "1";
            }
        }

        private void radioBtn8GBAnexo_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn8GBAnexo.Checked == true)
            {
                IDRamAnexo.Text = "2";
            }
        }

        private void radioBtn12GBAnexo_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn12GBAnexo.Checked == true)
            {
                IDRamAnexo.Text = "3";
            }
        }

        private void radioBtn16GBAnexo_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn16GBAnexo.Checked == true)
            {
                IDRamAnexo.Text = "4";
            }
        }

        private void radioBtn20GBAnexo_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn20GBAnexo.Checked == true)
            {
                IDRamAnexo.Text = "5";
            }
        }

        private void radioBtn32GBAnexo_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn32GBAnexo.Checked == true)
            {
                IDRamAnexo.Text = "6";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "LAB A - 103")
            {
                dataGridViewSJMostrar.Show();
                btn_ExcelA103.Show();
            }
            else
            {
                dataGridViewSJMostrar.Hide();
                btn_ExcelA103.Hide();
            }
            if (comboBox1.Text == "LAB B - 103")
            {
                dataGridViewAnexoMostrar.Show();
                btn_ExcelB103.Show();
            }
            else
            {
                dataGridViewAnexoMostrar.Hide();
                btn_ExcelB103.Hide();
            }
            if (comboBox1.Text == "LAB C - 103")
            {
                dataGridViewCMostrar.Show();
                btn_ExcelC103.Show();
            }
            else
            {
                dataGridViewCMostrar.Hide();
                btn_ExcelC103.Hide();
            }
            if (comboBox1.Text == "LAB B - 204")
            {
                dataGridViewMostrarB204.Show();
                btn_ExcelB204.Show();
            }
            else
            {
                dataGridViewMostrarB204.Hide();
                btn_ExcelB204.Hide();

            }
            if (comboBox1.Text == "LAB B - 206")
            {
                dataGridViewMostrarB206.Show();
                btn_ExcelB206.Show();
            }
            else
            {
                dataGridViewMostrarB206.Hide();
                btn_ExcelB206.Hide();
            }
        }

        private void InsertarCentralA103()
        {
            Inventario inventario = new Inventario();
            inventario.InsertarCentralA103(
                Cod_Inventario.Text, Convert.ToInt32(ComboIDMarca.Text), Convert.ToInt32(ComboIDModelo.Text), Convert.ToInt32(ComboIDProcesador.Text), Convert.ToInt32(ComboIDGeneracion.Text), textTAG.Text, Convert.ToInt32(ComboIDDisco.Text), textTarjetaVideo.Text, Convert.ToInt32(ComboIDRAM.Text), richTextObservacion.Text, Convert.ToInt32(ComboIDMonitor.Text), Cod_InvMonitor.Text, textTAGMonitor.Text
                ) ;
            MessageBox.Show("Se ingreso correctamente");
        }
        private void InsertarCentralC103()
        {
            Inventario inventario = new Inventario();
            inventario.InsertarCentralC103(
                Cod_InventarioC.Text, Convert.ToInt32(ComboIDMarcaC.Text), Convert.ToInt32(ComboIDModeloC.Text), Convert.ToInt32(ComboIDProcesadorC.Text), Convert.ToInt32(ComboIDGeneracionC.Text), textTagC.Text, Convert.ToInt32(ComboIDDiscoC.Text), textTarjetaC.Text, Convert.ToInt32(IDRamC.Text), richTextObservacionesC.Text, Convert.ToInt32(ComboIDMonitorC.Text), Cod_invMonitorC.Text, textTAGMonitorC.Text
                );
        }
        private void InsertarAnexoB103()
        {
            Inventario inventario = new Inventario();
            inventario.InsertarAnexoB103(
                Cod_InventarioAnexo.Text, Convert.ToInt32(ComboIDMarcaAnexo.Text), Convert.ToInt32(ComboIDModeloAnexo.Text), Convert.ToInt32(ComboIDProcesadorAnexo.Text), Convert.ToInt32(ComboIDGeneracionAnexo.Text), textTAGAnexo.Text, Convert.ToInt32(ComboIDDiscoAnexo.Text), textTarjetaVideoAnexo.Text, Convert.ToInt32(IDRamAnexo.Text), richTextObservacionAnexo.Text, Convert.ToInt32(ComboIDMonitorAnexo.Text), Cod_InvMonitorAnexo.Text, textTAGMonitorAnexo.Text
                );
        }
        private void InsertarAnexoB204()
        {
            Inventario inventario = new Inventario();
            inventario.InsertarAnexoB204(
                Cod_InventarioB204.Text, Convert.ToInt32(ComboIDMarcaB204.Text), Convert.ToInt32(ComboIDModeloB204.Text), Convert.ToInt32(ComboIDProcesadorB204.Text), Convert.ToInt32(ComboIDGeneracionB204.Text), textTAGB204.Text, Convert.ToInt32(ComboIDDiscoB204.Text), textTarjetaB204.Text, Convert.ToInt32(IDRamB204.Text), richTextObservacionesB204.Text, Convert.ToInt32(ComboIDMonitorB204.Text), Cod_InvMonitorB204.Text, textTAGMonitorB204.Text
                );
        }
        private void InsertarAnexoB206()
        {
            Inventario inventario = new Inventario();
            inventario.InsertarAnexoB206(
                Cod_InventarioB206.Text, Convert.ToInt32(ComboIDMarcaB206.Text), Convert.ToInt32(ComboIDModeloB206.Text), Convert.ToInt32(ComboIDProcesadorB206.Text), Convert.ToInt32(ComboIDGeneracionB206.Text), textTagB206.Text, Convert.ToInt32(ComboIDDiscoB206.Text), textTarjetaB206.Text, Convert.ToInt32(IDRamB206.Text), richTextObservacionesB206.Text, Convert.ToInt32(ComboIDMonitorB206.Text), Cod_InvMonitorB206.Text, textTAGMonitorB206.Text
                );
        }
        private void ActualizarCentralA103()
        {
            Inventario inventario = new Inventario();
            inventario.Actualizar(
                Cod_inventarioA103ACT.Text, Convert.ToInt32(ComboIDMarcaA103ACT.Text), Convert.ToInt32(ComboIDModeloA103ACT.Text), Convert.ToInt32(ComboIDProcesadorA103ACT.Text), Convert.ToInt32(ComboIDGeneracionA103ACT.Text), textTAGA103ACT.Text, Convert.ToInt32(ComboIDDiscoA103ACT.Text), textTarjetaA103ACT.Text, Convert.ToInt32(IDRamA103ACT.Text), richTextObservacionesA103ACT.Text, Convert.ToInt32(ComboIDMonitorA103ACT.Text), Cod_InvMonitorA103ACT.Text, textTAGMonitorA103.Text, Convert.ToInt32(IDInventario.Text)
                );
            MessageBox.Show("Se actualizo correctamente");
        }
        private void ActualizarCentralC103()
        {
            Inventario inventario = new Inventario();
            inventario.Actualizar(
                Cod_InventarioC103ACT.Text, Convert.ToInt32(ComboIDMarcaC103ACT.Text), Convert.ToInt32(ComboIDModeloC103ACT.Text), Convert.ToInt32(ComboIDProcesadorC103ACT.Text), Convert.ToInt32(ComboIDGeneracionC103ACT.Text), textTAGC103ACT.Text, Convert.ToInt32(ComboIDDiscoC103ACT.Text), textTarjetaC103ACT.Text, Convert.ToInt32(IDRamC103ACT.Text), richTextObservacionesC103ACT.Text, Convert.ToInt32(ComboIDMonitorC103ACT.Text), Cod_InvMonitorC103ACT.Text, textTAGMonitorC103.Text, Convert.ToInt32(IDInventarioC103.Text)
                );
            MessageBox.Show("Se actualizo correctamente");
        }
        private void ActualizarAnexoB103()
        {
            Inventario inventario = new Inventario();
            inventario.Actualizar(
                Cod_InventarioB103ACT.Text, Convert.ToInt32(ComboIDMarcaB103ACT.Text), Convert.ToInt32(ComboIDModeloB103ACT.Text), Convert.ToInt32(ComboIDProcesadorB103ACT.Text), Convert.ToInt32(ComboIDGeneracionB103ACT.Text), textTAGB103ACT.Text, Convert.ToInt32(ComboIDDiscoB103ACT.Text), textTarjetaB103ACT.Text, Convert.ToInt32(IDRamB103ACT.Text), richTextObservacionesB103ACT.Text, Convert.ToInt32(ComboIDMonitorB103ACT.Text), Cod_InvMonitorB103ACT.Text, textTAGMonitorB103ACT.Text, Convert.ToInt32(IDInventarioB103.Text)                
                );
            MessageBox.Show("Se actualizo correctamente");
        }
        private void ActualizarAnexoB204()
        {
            Inventario inventario = new Inventario();
            inventario.Actualizar(
                Cod_InventarioB204ACT.Text, Convert.ToInt32(ComboIDMarcaB204ACT.Text), Convert.ToInt32(ComboIDModeloB204ACT.Text), Convert.ToInt32(ComboIDProcesadorB204ACT.Text), Convert.ToInt32(ComboIDGeneracionB204ACT.Text), textTAGB204ACT.Text, Convert.ToInt32(ComboIDDiscoB204ACT.Text), textTarjetaB204ACT.Text, Convert.ToInt32(IDRamB204ACT.Text), richTextObservacionesB204ACT.Text, Convert.ToInt32(ComboIDMonitorB204ACT.Text), Cod_InvMonitorB204ACCT.Text, textTAGB204MonitorACT.Text, Convert.ToInt32(IDInventarioB204.Text)
                );
            MessageBox.Show("Se actualizo correctamente");
        }
        private void ActualizarAnexoB206()
        {
            Inventario inventario = new Inventario();
            inventario.Actualizar(
                Cod_InventarioB206ACT.Text, Convert.ToInt32(ComboIDMarcaB206ACT.Text), Convert.ToInt32(ComboIDModeloB206ACT.Text), Convert.ToInt32(ComboIDProcesadorB206ACT.Text), Convert.ToInt32(ComboIDGeneracionB206ACT.Text), textTagB206ACT.Text, Convert.ToInt32(ComboIDDiscoB206ACT.Text), textTarjetaB206ACT.Text, Convert.ToInt32(IDRamB206ACT.Text), richTextObservacionesB206ACT.Text, Convert.ToInt32(ComboIDMonitorB206ACT.Text), Cod_InvMonitorB206ACT.Text, textTAGMonitorB206ACT.Text, Convert.ToInt32(IDInventarioB206.Text)
                );
            MessageBox.Show("Se actualizo correctamente");
        }
        private void EliminarA103()
        {
            Inventario inventario = new Inventario();
            inventario.Eliminar(Convert.ToInt32(IDInventario.Text));
            MessageBox.Show("Se elimino correctamente");
        }
        private void EliminarC103()
        {
            Inventario inventario = new Inventario();
            inventario.Eliminar(Convert.ToInt32(IDInventarioC103.Text));
            MessageBox.Show("Se elimino correctamente");
        }
        private void EliminarB103()
        {
            Inventario inventario = new Inventario();
            inventario.Eliminar(Convert.ToInt32(IDInventarioB103.Text));
            MessageBox.Show("Se elimino correctamente");
        }
        private void EliminarB204()
        {
            Inventario inventario = new Inventario();
            inventario.Eliminar(Convert.ToInt32(IDInventarioB204.Text));
            MessageBox.Show("Se elimino correctamente");
        }
        private void EliminarB206()
        {
            Inventario inventario = new Inventario();
            inventario.Eliminar(Convert.ToInt32(IDInventarioB206.Text));
            MessageBox.Show("Se elimino correctamente");
        }
       

        private void btn_Ingresar_Click(object sender, EventArgs e)
        {
            try
            {
                InsertarCentralA103();
                MostrarInventario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void comboModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboModelo.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Modelo WHERE Nombre_Modelo = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Modelo"].ToString();

                        ComboIDModelo.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboMonitor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboMonitor.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Monitor WHERE Modelo_Monitor = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Monitor"].ToString();

                        ComboIDMonitor.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboModeloAnexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboModeloAnexo.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Modelo WHERE Nombre_Modelo = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Modelo"].ToString();

                        ComboIDModeloAnexo.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboMonitorAnexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboMonitorAnexo.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Monitor WHERE Modelo_Monitor = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Monitor"].ToString();

                        ComboIDMonitorAnexo.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboMarcaC_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboMarcaC.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Marca WHERE Nombre_Marca = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Marca"].ToString();

                        ComboIDMarcaC.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboModeloC_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboModeloC.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Modelo WHERE Nombre_Modelo = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Modelo"].ToString();

                        ComboIDModeloC.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboProcesadorC_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboProcesadorC.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Procesador WHERE Nombre_Procesador = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Procesador"].ToString();

                        ComboIDProcesadorC.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboDiscoC_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboDiscoC.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Disco_Duro WHERE Cantidad_Almacenamiento = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_DiscoDuro"].ToString();

                        ComboIDDiscoC.Text = detalle1;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboGeneracionC_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboGeneracionC.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Generacion WHERE Nombre_Generacion = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Generacion"].ToString();

                        ComboIDGeneracionC.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboMonitorC_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboMonitorC.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Monitor WHERE Modelo_Monitor = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Monitor"].ToString();

                        ComboIDMonitorC.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void radioBtn4GBC_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn4GBC.Checked == true)
            {
                IDRamC.Text = "1";
            }
        }

        private void radioBtn8GBC_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn8GBC.Checked == true)
            {
                IDRamC.Text = "2";
            }
        }

        private void radioBtn12GBC_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn12GBC.Checked == true)
            {
                IDRamC.Text = "3";
            }
        }

        private void radioBtn16GBC_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn16GBC.Checked == true)
            {
                IDRamC.Text = "4";
            }
        }

        private void radioBtn20GBC_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn20GBC.Checked == true)
            {
                IDRamC.Text = "5";
            }
        }

        private void radioBtn32GBC_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn32GBC.Checked == true)
            {
                IDRamC.Text = "6";
            }
        }

        private void dataGridViewCCrear_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboMarcaB204_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboMarcaB204.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Marca WHERE Nombre_Marca = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Marca"].ToString();

                        ComboIDMarcaB204.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboDiscoB204_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboDiscoB204.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Disco_Duro WHERE Cantidad_Almacenamiento = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_DiscoDuro"].ToString();

                        ComboIDDiscoB204.Text = detalle1;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboModeloB204_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboModeloB204.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Modelo WHERE Nombre_Modelo = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Modelo"].ToString();

                        ComboIDModeloB204.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboProcesadorB204_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboProcesadorB204.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Procesador WHERE Nombre_Procesador = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Procesador"].ToString();

                        ComboIDProcesadorB204.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboGeneracionB204_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboGeneracionB204.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Generacion WHERE Nombre_Generacion = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Generacion"].ToString();

                        ComboIDGeneracionB204.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }
        private void comboMonitorB204_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboMonitorB204.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Monitor WHERE Modelo_Monitor = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Monitor"].ToString();

                        ComboIDMonitorB204.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void radioBtn4GB204_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn4GB204.Checked == true)
            {
                IDRamB204.Text = "1";
            }
        }

        private void radioBtn8GB204_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn8GB204.Checked == true)
            {
                IDRamB204.Text = "2";
            }
        }

        private void radioBtn12GB204_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn12GB204.Checked == true)
            {
                IDRamB204.Text = "3";
            }
        }

        private void radioBtn16GB204_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn16GB204.Checked == true)
            {
                IDRamB204.Text = "4";
            }
        }

        private void radioBtn20GB204_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn20GB204.Checked == true)
            {
                IDRamB204.Text = "5";
            }
        }

        private void radioBtn32GB204_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn32GB204.Checked == true)
            {
                IDRamB204.Text = "6";
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn4GB206.Checked == true)
            {
                IDRamB206.Text = "1";
            }
        }

        private void comboMarcaB206_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboMarcaB206.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Marca WHERE Nombre_Marca = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Marca"].ToString();

                        ComboIDMarcaB206.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboModeloB206_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboModeloB206.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Modelo WHERE Nombre_Modelo = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Modelo"].ToString();

                        ComboIDModeloB206.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboProcesadorB206_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboProcesadorB206.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Procesador WHERE Nombre_Procesador = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Procesador"].ToString();

                        ComboIDProcesadorB206.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboDiscoB206_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboDiscoB206.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Disco_Duro WHERE Cantidad_Almacenamiento = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_DiscoDuro"].ToString();

                        ComboIDDiscoB206.Text = detalle1;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboGeneracionB206_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboGeneracionB206.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Generacion WHERE Nombre_Generacion = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Generacion"].ToString();

                        ComboIDGeneracionB206.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboMonitorB206_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboMonitorB206.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Monitor WHERE Modelo_Monitor = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Monitor"].ToString();

                        ComboIDMonitorB206.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void radioBtn8GB206_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn8GB206.Checked == true)
            {
                IDRamB206.Text = "2";
            }
        }

        private void radioBtn12GB206_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn12GB206.Checked == true)
            {
                IDRamB206.Text = "3";
            }
        }

        private void radioBtn16GB206_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn16GB206.Checked == true)
            {
                IDRamB206.Text = "4";
            }
        }

        private void radioBtn20GB206_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn20GB206.Checked == true)
            {
                IDRamB206.Text = "5";
            }
        }

        private void radioBtn32GB206_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn32GB206.Checked == true)
            {
                IDRamB206.Text = "6";
            }
        }

        private void btnIngresarC_Click(object sender, EventArgs e)
        {
            try
            {
                InsertarCentralC103();
                MostrarInventario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void btnIngresarAnexo_Click(object sender, EventArgs e)
        {
            try
            {
                InsertarAnexoB103();
                MostrarInventario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void btnIngresarB204_Click(object sender, EventArgs e)
        {
            try
            {
                InsertarAnexoB204();
                MostrarInventario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void btn_IngresarB206_Click(object sender, EventArgs e)
        {
            try
            {
                InsertarAnexoB206();
                MostrarInventario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void dataGridViewCrearB206_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnActualizarA103ACT_Click(object sender, EventArgs e)
        {
            try
            {
                ActualizarCentralA103();
                MostrarInventario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void comboMarcaA103ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboMarcaA103ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Marca WHERE Nombre_Marca = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Marca"].ToString();

                        ComboIDMarcaA103ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboModeloA103ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboModeloA103ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Modelo WHERE Nombre_Modelo = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Modelo"].ToString();

                        ComboIDModeloA103ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }
        }

        private void comboProcesadorA103ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboProcesadorA103ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Procesador WHERE Nombre_Procesador = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Procesador"].ToString();

                        ComboIDProcesadorA103ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }
        }

        private void comboDiscoA103ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboDiscoA103ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Disco_Duro WHERE Cantidad_Almacenamiento = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_DiscoDuro"].ToString();

                        ComboIDDiscoA103ACT.Text = detalle1;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }
        }

        private void comboGeneracionA103ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboGeneracionA103ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Generacion WHERE Nombre_Generacion = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Generacion"].ToString();

                        ComboIDGeneracionA103ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }
        }

        private void comboMonitorA103ACT_SelectedIndexChanged(object sender, EventArgs e)
        {

            string selectedValue = comboMonitorA103ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Monitor WHERE Modelo_Monitor = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Monitor"].ToString();

                        ComboIDMonitorA103ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }
        }

        private void Cod_Inventario_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioBtn4gbA103ACT_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn4gbA103ACT.Checked == true)
            {
                IDRamA103ACT.Text = "1";
            }
        }

        private void radioBtn8gbA103ACT_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn8gbA103ACT.Checked == true)
            {
                IDRamA103ACT.Text = "2";
            }
        }

        private void radioBtn12gbA103ACT_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn12gbA103ACT.Checked == true)
            {
                IDRamA103ACT.Text = "3";
            }
        }

        private void radioBtn16gbA103ACT_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn16gbA103ACT.Checked == true)
            {
                IDRamA103ACT.Text = "4";
            }
        }

        private void radioBtn20gbA103ACT_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn20gbA103ACT.Checked == true)
            {
                IDRamA103ACT.Text = "5";
            }
        }

        private void radioBtn32gbA103ACT_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn32gbA103ACT.Checked == true)
            {
                IDRamA103ACT.Text = "6";
            }
        }

        private void dataGridViewA103ACT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IDInventario.Text = dataGridViewA103ACT.Rows[e.RowIndex].Cells[0].Value.ToString();
                Cod_inventarioA103ACT.Text = dataGridViewA103ACT.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboMarcaA103ACT.Text = dataGridViewA103ACT.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboProcesadorA103ACT.Text = dataGridViewA103ACT.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboModeloA103ACT.Text = dataGridViewA103ACT.Rows[e.RowIndex].Cells[4].Value.ToString();
                comboMonitorA103ACT.Text = dataGridViewA103ACT.Rows[e.RowIndex].Cells[5].Value.ToString();
                Cod_InvMonitorA103ACT.Text = dataGridViewA103ACT.Rows[e.RowIndex].Cells[6].Value.ToString();
                textTAGMonitorA103.Text = dataGridViewA103ACT.Rows[e.RowIndex].Cells[7].Value.ToString();
                comboGeneracionA103ACT.Text = dataGridViewA103ACT.Rows[e.RowIndex].Cells[8].Value.ToString();
                textTAGA103ACT.Text = dataGridViewA103ACT.Rows[e.RowIndex].Cells[9].Value.ToString();
                comboDiscoA103ACT.Text = dataGridViewA103ACT.Rows[e.RowIndex].Cells[10].Value.ToString();
                textTarjetaA103ACT.Text = dataGridViewA103ACT.Rows[e.RowIndex].Cells[11].Value.ToString();
                richTextObservacionesA103ACT.Text = dataGridViewA103ACT.Rows[e.RowIndex].Cells[13].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }

        }

        private void dataGridViewA103ACT_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewA103ACT_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewColumn columnanombre = dataGridViewA103ACT.Columns["Id"];
            columnanombre.Visible = false;
        }

        private void btnEliminarA103ACT_Click(object sender, EventArgs e)
        {
            try
            {
                EliminarA103();
                MostrarInventario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void dataGridViewB103ACT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IDInventarioB103.Text = dataGridViewB103ACT.Rows[e.RowIndex].Cells[0].Value.ToString();
                Cod_InventarioB103ACT.Text = dataGridViewB103ACT.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboMarcaB103ACT.Text = dataGridViewB103ACT.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboProcesadorB103ACT.Text = dataGridViewB103ACT.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboModeloB103ACT.Text = dataGridViewB103ACT.Rows[e.RowIndex].Cells[4].Value.ToString();
                comboMonitorB103ACT.Text = dataGridViewB103ACT.Rows[e.RowIndex].Cells[5].Value.ToString();
                Cod_InvMonitorB103ACT.Text = dataGridViewB103ACT.Rows[e.RowIndex].Cells[6].Value.ToString();
                textTAGMonitorB103ACT.Text = dataGridViewB103ACT.Rows[e.RowIndex].Cells[7].Value.ToString();
                comboGeneracionB103ACT.Text = dataGridViewB103ACT.Rows[e.RowIndex].Cells[8].Value.ToString();
                textTAGB103ACT.Text = dataGridViewB103ACT.Rows[e.RowIndex].Cells[9].Value.ToString();
                comboDiscoB103ACT.Text = dataGridViewB103ACT.Rows[e.RowIndex].Cells[10].Value.ToString();
                textTarjetaB103ACT.Text = dataGridViewB103ACT.Rows[e.RowIndex].Cells[11].Value.ToString();
                richTextObservacionesB103ACT.Text = dataGridViewB103ACT.Rows[e.RowIndex].Cells[13].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }

        }

        private void dataGridViewB103ACT_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewColumn columnanombre = dataGridViewB103ACT.Columns["Id"];
            columnanombre.Visible = false;
        }

        private void comboMarcaB103ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboMarcaB103ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Marca WHERE Nombre_Marca = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Marca"].ToString();

                        ComboIDMarcaB103ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboModeloB103ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboModeloB103ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Modelo WHERE Nombre_Modelo = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Modelo"].ToString();

                        ComboIDModeloB103ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboProcesadorB103ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboProcesadorB103ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Procesador WHERE Nombre_Procesador = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Procesador"].ToString();

                        ComboIDProcesadorB103ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboDiscoB103ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboDiscoB103ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Disco_Duro WHERE Cantidad_Almacenamiento = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_DiscoDuro"].ToString();

                        ComboIDDiscoB103ACT.Text = detalle1;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboGeneracionB103ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboGeneracionB103ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Generacion WHERE Nombre_Generacion = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Generacion"].ToString();

                        ComboIDGeneracionB103ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboMonitorB103ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboMonitorB103ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Monitor WHERE Modelo_Monitor = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Monitor"].ToString();

                        ComboIDMonitorB103ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void btn_ActualizarB103_Click(object sender, EventArgs e)
        {
            try
            {
                ActualizarAnexoB103();
                MostrarInventario();
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
                MostrarInventario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void radioBtn4GB103ACT_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn4GB103ACT.Checked == true)
            {
                IDRamB103ACT.Text = "1";
            }
        }

        private void radioBtn8GB103ACT_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn8GB103ACT.Checked == true)
            {
                IDRamB103ACT.Text = "2";
            }
        }

        private void radioBtn12GB103ACT_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn12GB103ACT.Checked == true)
            {
                IDRamB103ACT.Text = "3";
            }
        }

        private void radioBtn16GB103ACT_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn16GB103ACT.Checked == true)
            {
                IDRamB103ACT.Text = "4";
            }
        }

        private void radioBtn20GB103ACT_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn20GB103ACT.Checked == true)
            {
                IDRamB103ACT.Text = "5";
            }
        }

        private void radioBtn32GB103ACT_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn32GB103ACT.Checked == true)
            {
                IDRamB103ACT.Text = "6";
            }
        }

        private void panelB103ACT_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboMarcaB204ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboMarcaB204ACT.SelectedItem.ToString();
 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Marca WHERE Nombre_Marca = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Marca"].ToString();

                        ComboIDMarcaB204ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboModeloB204ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboModeloB204ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Modelo WHERE Nombre_Modelo = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Modelo"].ToString();

                        ComboIDModeloB204ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboProcesadorB204ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboProcesadorB204ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Procesador WHERE Nombre_Procesador = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Procesador"].ToString();

                        ComboIDProcesadorB204ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboDiscoB204ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboDiscoB204ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Disco_Duro WHERE Cantidad_Almacenamiento = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_DiscoDuro"].ToString();

                        ComboIDDiscoB204ACT.Text = detalle1;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboGeneracionB204ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboGeneracionB204ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Generacion WHERE Nombre_Generacion = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Generacion"].ToString();

                        ComboIDGeneracionB204ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void comboMonitorB204ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboMonitorB204ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Monitor WHERE Modelo_Monitor = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Monitor"].ToString();

                        ComboIDMonitorB204ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }

        }

        private void radioBtn4GB204ACT_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn4GB204ACT.Checked == true)
            {
                IDRamB204ACT.Text = "1";
            }
        }

        private void radioBtn8GB204ACT_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn8GB204ACT.Checked == true)
            {
                IDRamB204ACT.Text = "2";
            }
        }

        private void radioBtn12GB204ACT_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn12GB204ACT.Checked == true)
            {
                IDRamB204ACT.Text = "3";
            }
        }

        private void radioBtn16GB204ACT_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn16GB204ACT.Checked == true)
            {
                IDRamB204ACT.Text = "4";
            }
        }

        private void radioBtn20GB204ACT_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn20GB204ACT.Checked == true)
            {
                IDRamB204ACT.Text = "5";
            }
        }

        private void radioBtn32GB204ACT_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn32GB204ACT.Checked == true)
            {
                IDRamB204ACT.Text = "6";
            }
        }

        private void dataGridViewB204ACT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IDInventarioB204.Text = dataGridViewB204ACT.Rows[e.RowIndex].Cells[0].Value.ToString();
                Cod_InventarioB204ACT.Text = dataGridViewB204ACT.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboMarcaB204ACT.Text = dataGridViewB204ACT.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboProcesadorB204ACT.Text = dataGridViewB204ACT.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboModeloB204ACT.Text = dataGridViewB204ACT.Rows[e.RowIndex].Cells[4].Value.ToString();
                comboMonitorB204ACT.Text = dataGridViewB204ACT.Rows[e.RowIndex].Cells[5].Value.ToString();
                Cod_InvMonitorB204ACCT.Text = dataGridViewB204ACT.Rows[e.RowIndex].Cells[6].Value.ToString();
                textTAGB204MonitorACT.Text = dataGridViewB204ACT.Rows[e.RowIndex].Cells[7].Value.ToString();
                comboGeneracionB204ACT.Text = dataGridViewB204ACT.Rows[e.RowIndex].Cells[8].Value.ToString();
                textTAGB204ACT.Text = dataGridViewB204ACT.Rows[e.RowIndex].Cells[9].Value.ToString();
                comboDiscoB204ACT.Text = dataGridViewB204ACT.Rows[e.RowIndex].Cells[10].Value.ToString();
                textTarjetaB204ACT.Text = dataGridViewB204ACT.Rows[e.RowIndex].Cells[11].Value.ToString();
                richTextObservacionesB204ACT.Text = dataGridViewB204ACT.Rows[e.RowIndex].Cells[13].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void dataGridViewB204ACT_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewColumn columnanombre = dataGridViewB204ACT.Columns["Id"];
            columnanombre.Visible = false;
        }

        private void btn_ActualizarB204_Click(object sender, EventArgs e)
        {
            try
            {
                ActualizarAnexoB204();
                MostrarInventario();
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
                MostrarInventario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void comboMarcaB206ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboMarcaB206ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Marca WHERE Nombre_Marca = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Marca"].ToString();

                        ComboIDMarcaB206ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }
        }

        private void radioBtn4gbB206ACT_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn4gbB206ACT.Checked == true)
            {
                IDRamB206ACT.Text = "1";
            }
        }

        private void radioBtn8gbB206ACT_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn8gbB206ACT.Checked == true)
            {
                IDRamB206ACT.Text = "2";
            }
        }

        private void radioBtn12gbB206ACT_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn12gbB206ACT.Checked == true)
            {
                IDRamB206ACT.Text = "3";
            }
        }

        private void radioBtn16gbB206ACT_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn16gbB206ACT.Checked == true)
            {
                IDRamB206ACT.Text = "4";
            }
        }

        private void radioBtn20gbB206ACT_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn20gbB206ACT.Checked == true)
            {
                IDRamB206ACT.Text = "5";
            }
        }

        private void radioBtn32gbB206ACT_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn32gbB206ACT.Checked == true)
            {
                IDRamB206ACT.Text = "6";
            }
        }

        private void comboModeloB206ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboModeloB206ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Modelo WHERE Nombre_Modelo = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Modelo"].ToString();

                        ComboIDModeloB206ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }
        }

        private void comboProcedarorB206ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboProcesadorB206ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Procesador WHERE Nombre_Procesador = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Procesador"].ToString();

                        ComboIDProcesadorB206ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }
        }

        private void comboDiscoB206ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboDiscoB206ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Disco_Duro WHERE Cantidad_Almacenamiento = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_DiscoDuro"].ToString();

                        ComboIDDiscoB206ACT.Text = detalle1;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }
        }

        private void comboGeneracionB206ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboGeneracionB206ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Generacion WHERE Nombre_Generacion = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Generacion"].ToString();

                        ComboIDGeneracionB206ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }
        }

        private void comboMonitorB206ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboMonitorB206ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Monitor WHERE Modelo_Monitor = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Monitor"].ToString();

                        ComboIDMonitorB206ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }
        }

        private void dataGridViewB206ACT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IDInventarioB206.Text = dataGridViewB206ACT.Rows[e.RowIndex].Cells[0].Value.ToString();
                Cod_InventarioB206ACT.Text = dataGridViewB206ACT.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboMarcaB206ACT.Text = dataGridViewB206ACT.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboProcesadorB206ACT.Text = dataGridViewB206ACT.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboModeloB206ACT.Text = dataGridViewB206ACT.Rows[e.RowIndex].Cells[4].Value.ToString();
                comboMonitorB206ACT.Text = dataGridViewB206ACT.Rows[e.RowIndex].Cells[5].Value.ToString();
                Cod_InvMonitorB206ACT.Text = dataGridViewB206ACT.Rows[e.RowIndex].Cells[6].Value.ToString();
                textTAGMonitorB206ACT.Text = dataGridViewB206ACT.Rows[e.RowIndex].Cells[7].Value.ToString();
                comboGeneracionB206ACT.Text = dataGridViewB206ACT.Rows[e.RowIndex].Cells[8].Value.ToString();
                textTagB206ACT.Text = dataGridViewB206ACT.Rows[e.RowIndex].Cells[9].Value.ToString();
                comboDiscoB206ACT.Text = dataGridViewB206ACT.Rows[e.RowIndex].Cells[10].Value.ToString();
                textTarjetaB206ACT.Text = dataGridViewB206ACT.Rows[e.RowIndex].Cells[11].Value.ToString();
                richTextObservacionesB206ACT.Text = dataGridViewB206ACT.Rows[e.RowIndex].Cells[13].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void btn_ActualizarB206ACT_Click(object sender, EventArgs e)
        {
            try
            {
                ActualizarAnexoB206();
                MostrarInventario();
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
                MostrarInventario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void panelB206ACT_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboMarcaC103ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboMarcaC103ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Marca WHERE Nombre_Marca = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Marca"].ToString();

                        ComboIDMarcaC103ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }
        }

        private void comboModeloC103ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboModeloC103ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Modelo WHERE Nombre_Modelo = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Modelo"].ToString();

                        ComboIDModeloC103ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }
        }

        private void comboProcesadorC103ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboProcesadorC103ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Procesador WHERE Nombre_Procesador = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Procesador"].ToString();

                        ComboIDProcesadorC103ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }
        }

        private void comboDiscoC103ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboDiscoC103ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Disco_Duro WHERE Cantidad_Almacenamiento = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_DiscoDuro"].ToString();

                        ComboIDDiscoC103ACT.Text = detalle1;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }
        }

        private void comboGeneracionC103ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboGeneracionC103ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Generacion WHERE Nombre_Generacion = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Generacion"].ToString();

                        ComboIDGeneracionC103ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }
        }

        private void comboMonitorC103ACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboMonitorC103ACT.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Monitor WHERE Modelo_Monitor = @selectedValue;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedValue", selectedValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string detalle1 = reader["Id_Monitor"].ToString();

                        ComboIDMonitorC103ACT.Text = detalle1;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message);
                }
            }
        }

        private void radioBtn4GBC103ACT_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn4GBC103ACT.Checked == true)
            {
                IDRamC103ACT.Text = "1";
            }
        }

        private void radioBtn8GBC103ACT_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn8GBC103ACT.Checked == true)
            {
                IDRamC103ACT.Text = "2";
            }
        }

        private void radioBtn12GBC103ACT_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn12GBC103ACT.Checked == true)
            {
                IDRamC103ACT.Text = "3";
            }
        }

        private void radioBtn16GBC103ACT_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn16GBC103ACT.Checked == true)
            {
                IDRamC103ACT.Text = "4";
            }
        }

        private void radioBtn20GBC103ACT_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn20GBC103ACT.Checked == true)
            {
                IDRamC103ACT.Text = "5";
            }
        }

        private void radioBtn32GBC103ACT_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn32GBC103ACT.Checked == true)
            {
                IDRamC103ACT.Text = "6";
            }
        }

        private void dataGridViewC103ACT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IDInventarioC103.Text = dataGridViewC103ACT.Rows[e.RowIndex].Cells[0].Value.ToString();
                Cod_InventarioC103ACT.Text = dataGridViewC103ACT.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboMarcaC103ACT.Text = dataGridViewC103ACT.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboProcesadorC103ACT.Text = dataGridViewC103ACT.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboModeloC103ACT.Text = dataGridViewC103ACT.Rows[e.RowIndex].Cells[4].Value.ToString();
                comboMonitorC103ACT.Text = dataGridViewC103ACT.Rows[e.RowIndex].Cells[5].Value.ToString();
                Cod_InvMonitorC103ACT.Text = dataGridViewC103ACT.Rows[e.RowIndex].Cells[6].Value.ToString();
                textTAGMonitorC103.Text = dataGridViewC103ACT.Rows[e.RowIndex].Cells[7].Value.ToString();
                comboGeneracionC103ACT.Text = dataGridViewC103ACT.Rows[e.RowIndex].Cells[8].Value.ToString();
                textTAGC103ACT.Text = dataGridViewC103ACT.Rows[e.RowIndex].Cells[9].Value.ToString();
                comboDiscoC103ACT.Text = dataGridViewC103ACT.Rows[e.RowIndex].Cells[10].Value.ToString();
                textTarjetaC103ACT.Text = dataGridViewC103ACT.Rows[e.RowIndex].Cells[11].Value.ToString();
                richTextObservacionesC103ACT.Text = dataGridViewC103ACT.Rows[e.RowIndex].Cells[13].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }

        }

        private void dataGridViewB206ACT_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewColumn columnanombre = dataGridViewB206ACT.Columns["Id"];
            columnanombre.Visible = false;
        }

        private void dataGridViewC103ACT_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewColumn columnanombre = dataGridViewC103ACT.Columns["Id"];
            columnanombre.Visible = false;
        }

        private void comboLocacionACT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboLocacionACT.Text == "LAB A - 103")
            {
                panelA103ACT.Show();
                dataGridViewA103ACT.Show();
            }
            else
            {
                panelA103ACT.Hide();
                dataGridViewA103ACT.Hide();
            }
            if (comboLocacionACT.Text == "LAB B - 103")
            {
                panelB103ACT.Show();
                dataGridViewB103ACT.Show();
            }
            else
            {
                panelB103ACT.Hide();
                dataGridViewB103ACT.Hide();
            }
            if (comboLocacionACT.Text == "LAB C - 103")
            {
                panelC103ACT.Show();
                dataGridViewC103ACT.Show();
            }
            else
            {
                panelC103ACT.Hide();
                dataGridViewC103ACT.Hide();
            }
            if (comboLocacionACT.Text == "LAB B - 204")
            {
                panelB204ACT.Show();
                dataGridViewB204ACT.Show();
            }
            else
            {
                panelB204ACT.Hide();
                dataGridViewB204ACT.Hide();
            }
            if (comboLocacionACT.Text == "LAB B - 206")
            {
                panelB206ACT.Show();
                dataGridViewB206ACT.Show();
            }
            else
            {
                panelB206ACT.Hide();
                dataGridViewB206ACT.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inicio inicio = new Inicio();
            inicio.Show();
        }

        private void dataGridViewCMostrar_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
        }

        private void dataGridViewCCrear_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
        }

        private void dataGridViewMostrarB204_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
        }

        private void dataGridViewMostrarB206_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
        }

        private void dataGridViewSJCrear_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
        }

        private void dataGridViewCrearB206_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
        }

        private void dataGridViewSJMostrar_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
        }

        private void dataGridViewCrearB204_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
        }

        private void dataGridViewAnexoMostrar_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
        }

        private void dataGridViewAnexoCrear_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
        }

        private void btnActualizarC103_Click(object sender, EventArgs e)
        {
            try
            {
                ActualizarCentralC103();
                MostrarInventario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void btnEliminarC103_Click(object sender, EventArgs e)
        {
            try
            {
                EliminarC103();
                MostrarInventario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
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
                exportarExcel(dataGridViewSJMostrar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }
        private void btn_ExcelB103_Click(object sender, EventArgs e)
        {
            try
            {
                exportarExcel(dataGridViewAnexoMostrar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void btn_ExcelB204_Click(object sender, EventArgs e)
        {
            try
            {
                exportarExcel(dataGridViewMostrarB204);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void btn_ExcelB206_Click(object sender, EventArgs e)
        {
            try
            {
                exportarExcel(dataGridViewMostrarB206);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void btn_ExcelC103_Click(object sender, EventArgs e)
        {
            try
            {
                exportarExcel(dataGridViewCMostrar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label85_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewMostrarB206_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewSJMostrar_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
        }

        private void textTAGB204MonitorACT_Click(object sender, EventArgs e)
        {

        }
    }
}
