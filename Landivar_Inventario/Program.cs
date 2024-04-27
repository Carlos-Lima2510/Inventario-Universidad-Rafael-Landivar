using Landivar_Inventario.Presentación;
using System;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace Landivar_Inventario
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
    