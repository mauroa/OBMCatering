using System.Windows.Forms;

namespace OBMCatering.Presentacion
{
    public partial class BienvenidaForm : Form
    {
        ContextoPresentacion contexto;

        public BienvenidaForm()
        {
            InitializeComponent();

            Load += BienvenidaForm_Load;
        }

        void BienvenidaForm_Load(object sender, System.EventArgs e)
        {
            //Dispara la inicializacion de los contextos y de los datos
            contexto = ContextoPresentacion.Instancia;

            //Esperamos 3 segundos para que la pantalla de presentacion se quede un instante
            Timer temporizador = new Timer();

            temporizador.Interval = 3000;
            temporizador.Tick += Temporizador_Tick;
            temporizador.Start();
        }

        void Temporizador_Tick(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
