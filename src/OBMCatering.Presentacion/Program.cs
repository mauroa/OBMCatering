using System;
using System.Windows.Forms;

namespace OBMCatering.Presentacion
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DialogResult resultado;

            using (var loginForm = new LoginForm())
            {
                resultado = loginForm.ShowDialog();
            }
                
            if (resultado == DialogResult.OK)
            {
                Application.Run(new InicioForm());
            }
        }
    }
}
