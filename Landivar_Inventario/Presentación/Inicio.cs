using System;
using System.Windows.Forms;

namespace Landivar_Inventario.Presentación
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btn_InventarioEquipos_Click(object sender, EventArgs e)
        {
            this.Hide();
            F_Inventario f_Inventario = new F_Inventario();
            f_Inventario.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            IP iP = new IP();
            iP.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Modelos modelos = new Modelos();
            modelos.Show(); 
        }
    }
}
