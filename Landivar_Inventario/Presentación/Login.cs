using System;
using System.Windows.Forms;
using Landivar_Inventario.Datos;

namespace Landivar_Inventario.Presentación
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioBtnAdmin.Checked == true)
            {
                Inventario inventario = new Inventario();
                inventario.Inicio_Admin(rjTextUsuario.Texts, rjTextContraseña.Texts);
                this.Hide();
            }
            if (radioBtnUsuario.Checked == true)
            {
                radioBtnAdmin.Checked = false;
                Inventario inventario = new Inventario();
                inventario.Inicio_Usuario(rjTextUsuario.Texts, rjTextContraseña.Texts);
                this.Hide();
            }
            else if (radioBtnAdmin.Checked == false && radioBtnUsuario.Checked == false)
            {
                MessageBox.Show("Selecciona las credenciales correctas");
            }

        }

        private void rjTextUsuario_Load(object sender, EventArgs e)
        {

        }

        private void btn_ConfigUsuario_Click(object sender, EventArgs e)
        {
            this.Hide();
            Confirmacion confirmacion = new Confirmacion();
            confirmacion.Show();
        }

        private void btn_desarrolladora_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Inventario desarrollado por practicantes del departamento de Servicios Tecnologicos Académicos (SERTEC) \n \n - Carlos Alvarado Lima \n - Ana Valeria Tzoc", "Información", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
