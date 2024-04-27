using Landivar_Inventario.Datos;
using Landivar_Inventario.Presentación;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Landivar_Inventario
{
    public partial class Redes : Form
    {
        public Redes()
        {
            InitializeComponent();
            Mostrar();
        }
        private void Mostrar()
        {
            IPs ps = new IPs();
            dataGridViewMascara.DataSource = ps.Mascara();
            dataGridViewPEnlace.DataSource = ps.Puerta();
            dataGridViewDNS1.DataSource = ps.DNS1();
            dataGridViewDNS2.DataSource = ps.DNS2();
        }
        private void InsertarMascara()
        {
            IPs ps = new IPs();
            ps.InsertarMascara(
                textMascara.Text
                );
        }
        private void ActualizarMascara()
        {
            IPs ps = new IPs();
            ps.ActualizarMascara(
                textMascara.Text, Convert.ToInt32(IDMascara.Text)
                );
        }
        private void InsertarPEnlace()
        {
            IPs ps = new IPs();
            ps.InsertarPuerta(
                textPEnlace.Text
                );
        }
        private void ActualizarPEnlace()
        {
            IPs ps = new IPs();
            ps.ActualizarPuerta(
                textPEnlace.Text, Convert.ToInt32(IDPEnlace.Text)
                );
        }
        private void InsertarDNS()
        {
            IPs ps = new IPs();
            ps.InsertarDNS(
                textDNS1.Text
                );
        }
        private void InsertarDNS2()
        {
            IPs ps = new IPs();
            ps.InsertarDNS2(
                textDNS2.Text
                );
        }
        private void ActualizarDNS()
        {
            IPs ps = new IPs();
            ps.ActualizarDNS(
                textDNS1.Text, Convert.ToInt32(IDNS1.Text)
                );
        }
        private void ActualizarDNS2()
        {
            IPs ps = new IPs();
            ps.ActualizarDNS2(
                textDNS2.Text, Convert.ToInt32(IDNS2.Text)
                );
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btn_MascaraIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                InsertarMascara();
                Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void dataGridViewMascara_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewColumn columnanombre = dataGridViewMascara.Columns["Id_mascara"];
            columnanombre.Visible = false;
        }

        private void dataGridViewMascara_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IDMascara.Text = dataGridViewMascara.Rows[e.RowIndex].Cells[0].Value.ToString();
                textMascara.Text = dataGridViewMascara.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void btn_MascaraActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                ActualizarMascara();
                Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }
        private void EliminarMascara()
        {
            IPs ips = new IPs();
            ips.EliminarMascara(Convert.ToInt32(IDMascara.Text));
            MessageBox.Show("Se elimino correctamente");
        }
        private void EliminarPEnlace()
        {
            IPs ips = new IPs();
            ips.EliminarPuerta(Convert.ToInt32(IDPEnlace.Text));
            MessageBox.Show("Se elimino correctamente");
        }
        private void EliminarDNS()
        {
            IPs ips = new IPs();
            ips.EliminarDNS(Convert.ToInt32(IDNS1.Text));
            MessageBox.Show("Se elimino correctamente");
        }
        private void EliminarDNS2()
        {
            IPs ips = new IPs();
            ips.EliminarDNS2(Convert.ToInt32(IDNS2.Text));
            MessageBox.Show("Se elimino correctamente");
        }

        private void btn_MascaraEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                EliminarMascara();
                Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            IP iP = new IP();
            iP.Show();
        }

        private void dataGridViewPEnlace_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IDPEnlace.Text = dataGridViewPEnlace.Rows[e.RowIndex].Cells[0].Value.ToString();
                textPEnlace.Text = dataGridViewPEnlace.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void btn_PEnlaceIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                InsertarPEnlace();
                Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void btn_PEnlaceActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                ActualizarPEnlace();
                Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void btn_PEnlaceEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                EliminarPEnlace();
                Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void dataGridViewPEnlace_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewColumn columnanombre = dataGridViewPEnlace.Columns["Id_puerta"];
            columnanombre.Visible = false;
        }

        private void dataGridViewDNS1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IDNS1.Text = dataGridViewDNS1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textDNS1.Text = dataGridViewDNS1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btn_IngresarDNS1_Click(object sender, EventArgs e)
        {
            try
            {
                InsertarDNS();
                Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void btn_ActualizarDNS1_Click(object sender, EventArgs e)
        {
            try
            {
                ActualizarDNS();
                Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void btn_EliminarDNS1_Click(object sender, EventArgs e)
        {
            try
            {
                EliminarDNS();
                Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void dataGridViewDNS1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewColumn columnanombre = dataGridViewDNS1.Columns["Id_DNS"];
            columnanombre.Visible = false;
        }

        private void comboDNS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboDNS.Text == "DNS Preferido")
            {
                panelDNS1.Show();
                dataGridViewDNS1.Show();
            }
            else
            {
                panelDNS1.Hide();
                dataGridViewDNS1.Hide();
            }
            if (comboDNS.Text == "DNS Alternativo")
            {
                panelDNS2.Show();
                dataGridViewDNS2.Show();
            }
            else
            {
                panelDNS2.Hide();
                dataGridViewDNS2.Hide();
            }

        }

        private void dataGridViewDNS2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IDNS2.Text = dataGridViewDNS2.Rows[e.RowIndex].Cells[0].Value.ToString();
                textDNS2.Text = dataGridViewDNS2.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void btn_IngresarDNS2_Click(object sender, EventArgs e)
        {
            try
            {
                InsertarDNS2();
                Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void btn_ActualizarDNS2_Click(object sender, EventArgs e)
        {
            try
            {
                ActualizarDNS2();
                Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void btn_EliminarDNS2_Click(object sender, EventArgs e)
        {
            try
            {
                EliminarDNS2();
                Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
            }
        }

        private void dataGridViewDNS2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewColumn columnanombre = dataGridViewDNS2.Columns["Id_DNS2"];
            columnanombre.Visible = false;
        }
    }
}
