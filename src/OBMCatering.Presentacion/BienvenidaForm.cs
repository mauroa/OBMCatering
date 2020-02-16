using System.Windows.Forms;

namespace OBMCatering.Presentacion
{
    /// <summary>
    /// Representa la primer pantalla que se mostrara al inicial el sistema
    /// </summary>
    public partial class BienvenidaForm : Form
    {
        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="BienvenidaForm"/>
        /// </summary>
        public BienvenidaForm()
        {
            InitializeComponent();

            Load += BienvenidaForm_Load;
        }

        void BienvenidaForm_Load(object sender, System.EventArgs e)
        {
            //Dispara la inicializacion de los contextos y de los datos
            ContextoPresentacion contexto = ContextoPresentacion.Instancia;

            //Esperamos 3 segundos para que la pantalla de presentacion se quede un instante
            Timer temporizador = new Timer
            {
                Interval = 3000
            };
            temporizador.Tick += Temporizador_Tick;
            temporizador.Start();
        }

        void Temporizador_Tick(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
