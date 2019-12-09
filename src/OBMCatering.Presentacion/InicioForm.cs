using System;
using System.Windows.Forms;

namespace OBMCatering.Presentacion
{
    public partial class InicioForm : Form
    {
        public InicioForm()
        {
            InitializeComponent();
        }

        void InicioForm_Load(object sender, EventArgs e)
        {
            tsiClientes.Click += TsiClientes_Click;
            tsiProveedores.Click += TsiProveedores_Click;
            tsiEmpleados.Click += TsiEmpleados_Click;
            tsiRecetas.Click += TsiRecetas_Click;
            tsiPrecios.Click += TsiPrecios_Click;
            tsiPedidos.Click += TsiPedidos_Click;
            tsiFacturas.Click += TsiFacturas_Click;
            tsiOrdenesCompra.Click += TsiOrdenesCompra_Click;
        }

        void TsiClientes_Click(object sender, EventArgs e)
        {
            ClientesForm form = new ClientesForm();

            form.Show();
        }

        void TsiProveedores_Click(object sender, EventArgs e)
        {
            ProveedoresForm form = new ProveedoresForm();

            form.Show();
        }

        void TsiEmpleados_Click(object sender, EventArgs e)
        {
            EmpleadosForm form = new EmpleadosForm();

            form.Show();
        }

        void TsiRecetas_Click(object sender, EventArgs e)
        {
            RecetasForm form = new RecetasForm();

            form.Show();
        }

        void TsiPrecios_Click(object sender, EventArgs e)
        {
            PreciosForm form = new PreciosForm();

            form.Show();
        }

        void TsiPedidos_Click(object sender, EventArgs e)
        {
            OrdenesVentaForm form = new OrdenesVentaForm();

            form.Show();
        }

        void TsiFacturas_Click(object sender, EventArgs e)
        {
            FacturasForm form = new FacturasForm();

            form.Show();
        }

        void TsiOrdenesCompra_Click(object sender, EventArgs e)
        {
            OrdenesCompraForm form = new OrdenesCompraForm();

            form.Show();
        }
    }
}
