using System;
using System.Windows.Forms;

namespace OBMCatering.Presentacion
{
    /// <summary>
    /// Representa el formulario de ayuda de cualquier pantalla en la que se requiera ayuda
    /// </summary>
    public partial class AyudaForm : Form
    {
        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="AyudaForm"/>
        /// </summary>
        public AyudaForm()
        {
            InitializeComponent();

            Load += AyudaForm_Load;
        }

        /// <summary>
        /// Representa el mensaje de ayuda a mostrar en el dialogo
        /// </summary>
        public string MensajeAyuda { get; set; }

        void AyudaForm_Load(object sender, EventArgs e)
        {
            lblMensaje.Text = MensajeAyuda;
            btnOk.Click += BtnOk_Click;
        }

        void BtnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
