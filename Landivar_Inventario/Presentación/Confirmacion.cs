using Landivar_Inventario.Datos;
using System;
using System.Windows.Forms;

namespace Landivar_Inventario.Presentación
{
    public partial class Confirmacion : Form
    {
        public Confirmacion()
        {
            InitializeComponent();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (rjTextUsuario.Texts == "" || rjTextContraseña.Texts == "")
            {
                MessageBox.Show("Ingresa una credencial en TODOS los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Inventario inventario = new Inventario();
                    inventario.Inicio_AdminConfiguracion(rjTextUsuario.Texts, rjTextContraseña.Texts);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener detalles: " + ex.Message, "Error");
                }
            }
            this.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
    }
}
