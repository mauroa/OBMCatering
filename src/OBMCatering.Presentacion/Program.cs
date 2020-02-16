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

            //Se muestra el formulario de bienvenida por unos segundos
            using (var bienvenidaForm = new BienvenidaForm())
            {
                resultado = bienvenidaForm.ShowDialog();
            }

            //Luego se muestra el formulario de login
            if (resultado == DialogResult.OK)
            {
                using (var loginForm = new LoginForm())
                {
                    resultado = loginForm.ShowDialog();
                }
            }

            //Si el usuario es autenticado se da paso al formulario inicial
            if (resultado == DialogResult.OK)
            {
                Application.Run(new InicioForm());
            }
        }
    }
}
