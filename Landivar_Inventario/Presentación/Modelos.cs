using Landivar_Inventario.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Landivar_Inventario.Presentación
{
    public partial class Modelos : Form
    {
        public Modelos()
        {
            InitializeComponent();
            MostrarModelos();
        }
        private void MostrarModelos()
        {
            Inventario inventario = new Inventario();
            dataGridViewModelo.DataSource = inventario.ListarModeloCase();
            dataGridViewMonitor.DataSource = inventario.ListarModeloMonitor();

        }
        private void InsertarModelo()
        {
            Inventario inventario = new Inventario();
            inventario.InsertarModeloCase(
                textModelo.Text
                );
        }
        private void InsertarModeloMonitor()
        {
            Inventario inventario = new Inventario();
            inventario.InsertarModeloMonitor(
                textMonitor.Text
                );
        }
        private void ActualizarModelo()
        {
            Inventario inventario = new Inventario();
            inventario.ActualizarModeloCase(
                textModelo.Text, Convert.ToInt32(IDModelo.Text)
                );
        }
        private void ActualizarModeloMonitor()
        {
            Inventario inventario = new Inventario();
            inventario.ActualizarModeloMonitor(
                textMonitor.Text, Convert.ToInt32(IDMonitor.Text)
                );
        }
        private void EliminarModelo()
        {
            Inventario inventario = new Inventario();
            inventario.EliminarModelo(
                Convert.ToInt32(IDModelo.Text)
                );
        }
        private void EliminarMonitor()
        {
            Inventario inventario = new Inventario();
            inventario.EliminarMonitor(
                Convert.ToInt32(IDMonitor.Text)
                );
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IDModelo.Text = dataGridViewModelo.Rows[e.RowIndex].Cells[0].Value.ToString();
                textModelo.Text = dataGridViewModelo.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {


        }

        private void dataGridViewModelo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewColumn columnanombre = dataGridViewModelo.Columns["Id_Modelo"];
            columnanombre.Visible = false;
        }

        private void dataGridViewMonitor_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewColumn columnanombre = dataGridViewMonitor.Columns["Id_Monitor"];
            columnanombre.Visible = false;
        }

        private void btn_IngresarModelo_Click(object sender, EventArgs e)
        {
            try
            {
                InsertarModelo();
                MostrarModelos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void btn_ActualizarModelo_Click(object sender, EventArgs e)
        {
            try
            {
                ActualizarModelo();
                MostrarModelos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void btn_IngresarMonitor_Click(object sender, EventArgs e)
        {
            try
            {
                InsertarModeloMonitor();
                MostrarModelos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void btn_ActualizarMonitor_Click(object sender, EventArgs e)
        {
            try
            {
                ActualizarModeloMonitor();
                MostrarModelos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void dataGridViewMonitor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IDMonitor.Text = dataGridViewMonitor.Rows[e.RowIndex].Cells[0].Value.ToString();
                textMonitor.Text = dataGridViewMonitor.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void btn_EliminarModelo_Click(object sender, EventArgs e)
        {
            try
            {
                EliminarModelo();
                MostrarModelos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void btn_EliminarMonitor_Click(object sender, EventArgs e)
        {
            try
            {
                EliminarMonitor();
                MostrarModelos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inicio inicio = new Inicio();
            inicio.Show();
        }
    }
}
