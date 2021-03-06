﻿ using OBMCatering.Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using OBMCatering.Presentacion.Properties;

namespace OBMCatering.Presentacion
{
    /// <summary>
    /// Representa el formulario de ordenes de venta del sistema
    /// </summary>
    public partial class OrdenesVentaForm : Form
    {
        ContextoPresentacion contexto;
        LocalidadesBL localidadesBL;
        ClientesBL clientesBL;
        IngredientesBL ingredientesBL;
        PreciosIngredientesBL precioIngredientesBL;
        RecetasBL recetasBL;
        OrdenesVentaBL ordenesVentaBL;
        FacturasBL facturasBL;
        OrdenesCompraBL ordenesCompraBL;
        OrdenVentaPresentacion ordenVentaSeleccionada;

        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="OrdenesVentaForm"/>
        /// </summary>
        public OrdenesVentaForm()
        {
            this.CargarLenguaje();
            InitializeComponent();

            Text = Resources.OrdenesVentaForm_Titulo;
            lblCliente.Text = Resources.OrdenesVentaForm_Datos_Cliente;
            lblFechaInicio.Text = Resources.OrdenesVentaForm_Datos_Desde;
            lblFechaFin.Text = Resources.OrdenesVentaForm_Datos_Hasta;
            lblComensales.Text = Resources.OrdenesVentaForm_Datos_Comensales;
            chkAprobada.Text = Resources.OrdenesVentaForm_Datos_Aprobada;
            lblRecetas.Text = Resources.OrdenesVentaForm_Datos_Recetas;
            lblPrecio.Text = Resources.OrdenesVentaForm_Datos_Precio;
            btnCalcularPrecio.Text = Resources.OrdenesVentaForm_Datos_Calcular;
            btnGuardar.Text = Resources.OrdenesVentaForm_Datos_Guardar;

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            HelpButton = true;
            HelpRequested += OrdenesVentaForm_HelpRequested;
        }

        void OrdenesVentaForm_Load(object sender, EventArgs e)
        {
            AcceptButton = btnGuardar;

            contexto = ContextoPresentacion.Instancia;
            localidadesBL = new LocalidadesBL(contexto.Negocio);
            clientesBL = new ClientesBL(contexto.Negocio, localidadesBL);
            ingredientesBL = new IngredientesBL(contexto.Negocio);
            precioIngredientesBL = new PreciosIngredientesBL(contexto.Negocio);
            recetasBL = new RecetasBL(contexto.Negocio, precioIngredientesBL);
            ordenesVentaBL = new OrdenesVentaBL(contexto.Negocio, recetasBL, clientesBL);
            facturasBL = new FacturasBL(contexto.Negocio, ordenesVentaBL);
            ordenesCompraBL = new OrdenesCompraBL(contexto.Negocio, ordenesVentaBL, ingredientesBL);

            btnGuardar.Click += BtnGuardar_Click;
            btnCalcularPrecio.Click += BtnCalcularPrecio_Click;
            grvPedidos.SelectionChanged += GrvPedidos_SelectionChanged;
            grvPedidos.CellEnter += GrvPedidos_CellEnter;
            CargarClientes();
            CargarRecetas();
            CargarOrdenesVenta();
            LimpiarFormulario();

            contexto.RegistrarEvento(Resources.OrdenesVentaForm_Ingreso);
        }

        void OrdenesVentaForm_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Form ayudaForm = new AyudaForm()
            {
                MensajeAyuda = Resources.OrdenesVentaForm_Help_Mensaje
            };

            ayudaForm.ShowDialog();
        }

        void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                bool existeOrdenVenta = false;
                OrdenVenta ordenVenta;

                if (ordenVentaSeleccionada != null)
                {
                    existeOrdenVenta = ordenesVentaBL.Existe(ordenVentaSeleccionada.ObtenerId());
                }

                if (existeOrdenVenta)
                {
                    ordenVenta = ordenesVentaBL.Obtener(ordenVentaSeleccionada.ObtenerId());
                    SetearOrdenVenta(ordenVenta);
                    ordenesVentaBL.Actualizar(ordenVenta);

                    contexto.RegistrarEvento(Resources.OrdenesVentaForm_OrdenVentaActualizada, ordenVenta.Cliente.Nombre);
                }
                else
                {
                    ordenVenta = Crear();
                    ordenesVentaBL.Crear(ordenVenta);

                    contexto.RegistrarEvento(Resources.OrdenesVentaForm_OrdenVentaCreada, ordenVenta.Cliente.Nombre);
                }

                if ((!existeOrdenVenta || !ordenVentaSeleccionada.Aprobada) && ordenVenta.Aprobada)
                {
                    CrearFactura();
                    CrearOrdenCompra();
                }

                CargarOrdenesVenta();
                LimpiarFormulario();
            }
            catch(Exception ex)
            {
                contexto.RegistrarError(ex);
            }
        }

        void BtnCalcularPrecio_Click(object sender, EventArgs e)
        {
            try
            {
                OrdenVenta ordenVenta = Crear();
                decimal precio = ordenesVentaBL.CalcularPrecio(ordenVenta);

                lblPrecioCalculado.Text = precio.ToString("N2");
            }
            catch (Exception ex)
            {
                contexto.RegistrarError(ex);
            }
        }

        void GrvPedidos_SelectionChanged(object sender, EventArgs e)
        {
            int filasSeleccionadas = grvPedidos.SelectedRows.Count;

            if (filasSeleccionadas == 0 || filasSeleccionadas > 1) return;

            DataGridViewRow filaSeleccionada = grvPedidos.CurrentRow;
            OrdenVentaPresentacion ordenVentaSeleccionada = (OrdenVentaPresentacion)filaSeleccionada.DataBoundItem;

            CargarOrdenVentaSeleccionada(ordenVentaSeleccionada);
        }

        void GrvPedidos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow filaSeleccionada = grvPedidos.Rows[e.RowIndex];

            filaSeleccionada.Selected = true;

            OrdenVentaPresentacion ordenVentaSeleccionada = (OrdenVentaPresentacion)filaSeleccionada.DataBoundItem;

            CargarOrdenVentaSeleccionada(ordenVentaSeleccionada);
        }

        void CargarClientes()
        {
            try
            {
                IEnumerable<Cliente> clientes = clientesBL.ObtenerActivos();

                foreach (Cliente cliente in clientes)
                {
                    cboClientes.Items.Add(cliente.Nombre);
                }
            }
            catch (Exception ex)
            {
                contexto.RegistrarError(ex);
            }
        }

        void CargarRecetas()
        {
            try
            {
                IEnumerable<Receta> recetas = recetasBL.Obtener(EstadoReceta.Activa);

                foreach (Receta receta in recetas)
                {
                    lstRecetas.Items.Add(receta.Nombre);
                }
            }
            catch (Exception ex)
            {
                contexto.RegistrarError(ex);
            }
        }

        void CargarOrdenesVenta()
        {
            try
            {
                IEnumerable<OrdenVenta> ordenesVenta = ordenesVentaBL.Obtener();

                grvPedidos.DataSource = ObtenerOrdenesVentaPresentacion(ordenesVenta);
            }
            catch (Exception ex)
            {
                contexto.RegistrarError(ex);
            }
        }

        IEnumerable<OrdenVentaPresentacion> ObtenerOrdenesVentaPresentacion(IEnumerable<OrdenVenta> ordenesVenta)
        {
            List<OrdenVentaPresentacion> ordenesVentaPresentacion = new List<OrdenVentaPresentacion>();

            foreach (OrdenVenta ordenVenta in ordenesVenta)
            {
                ordenesVentaPresentacion.Add(new OrdenVentaPresentacion(ordenVenta));
            }

            return ordenesVentaPresentacion;
        }

        OrdenVenta Crear()
        {
            Cliente cliente = clientesBL.ObtenerPorNombre(cboClientes.SelectedItem.ToString());
            OrdenVenta ordenVenta = new OrdenVenta();

            ordenVenta.Cliente = cliente;
            SetearOrdenVenta(ordenVenta);

            return ordenVenta;
        }

        void SetearOrdenVenta(OrdenVenta ordenVenta)
        {
            ordenVenta.FechaInicio = dtpFechaInicio.Value;
            ordenVenta.FechaFin = dtpFechaFin.Value;
            ordenVenta.Comensales = int.Parse(txtComensales.Text);
            ordenVenta.Aprobada = chkAprobada.Checked;

            foreach (Receta receta in ordenVenta.Recetas.ToList())
            {
                if (!lstRecetas.Items.Contains(receta.Nombre))
                {
                    ordenVenta.Recetas.Remove(receta);
                }
            }

            foreach (object item in lstRecetas.SelectedItems)
            {
                bool existeReceta = false;

                foreach (Receta receta in ordenVenta.Recetas)
                {
                    if (receta.Nombre == item.ToString())
                    {
                        existeReceta = true;
                        break;
                    }
                }

                if (!existeReceta)
                {
                    Receta receta = recetasBL.Obtener(item.ToString());

                    ordenVenta.Recetas.Add(receta);
                }
            }

            if (string.IsNullOrEmpty(lblPrecioCalculado.Text))
            {
                decimal precio = ordenesVentaBL.CalcularPrecio(ordenVenta);

                ordenVenta.Precio = precio;
            }
            else
            {
                ordenVenta.Precio = decimal.Parse(lblPrecioCalculado.Text);
            }
        }

        void CargarOrdenVentaSeleccionada(OrdenVentaPresentacion ordenVentaPresentacion)
        {
            cboClientes.SelectedItem = ordenVentaPresentacion.Cliente;
            dtpFechaInicio.Value = ordenVentaPresentacion.FechaInicio;
            dtpFechaFin.Value = ordenVentaPresentacion.FechaFin;
            txtComensales.Text = ordenVentaPresentacion.Comensales;
            chkAprobada.Checked = ordenVentaPresentacion.Aprobada;

            lstRecetas.ClearSelected();

            for(int i = 0; i < lstRecetas.Items.Count; i++)
            {
                string receta = lstRecetas.Items[i].ToString();

                IEnumerable<string> recetas = ordenVentaPresentacion.ObtenerRecetas();

                if (recetas.Contains(receta))
                {
                    lstRecetas.SetSelected(i, true);
                }
            }

            lblPrecioCalculado.Text = ordenVentaPresentacion.Precio;
            ordenVentaSeleccionada = ordenVentaPresentacion;
        }

        void CrearFactura()
        {
            OrdenVenta ordenVenta = ordenesVentaBL.Obtener(ordenVentaSeleccionada.ObtenerId());
            Factura factura = new Factura
            {
                OrdenVenta = ordenVenta,
                Fecha = DateTime.Now
            };

            facturasBL.Crear(factura);
            contexto.MostrarEvento(Resources.OrdenesVentaForm_FacturaCreada, ordenVenta.Cliente.Nombre);
        }

        void CrearOrdenCompra()
        {
            OrdenVenta ordenVenta = ordenesVentaBL.Obtener(ordenVentaSeleccionada.ObtenerId());

            ordenesCompraBL.Crear(ordenVenta);
            contexto.MostrarEvento(Resources.OrdenesVentaForm_OrdenCompraCreada, ordenVenta.Cliente.Nombre);
        }

        void LimpiarFormulario()
        {
            cboClientes.SelectedItem = null;
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;
            txtComensales.Text = string.Empty;
            chkAprobada.Checked = false;
            lstRecetas.ClearSelected();
            lblPrecioCalculado.Text = string.Empty;
            grvPedidos.ClearSelection();
            ordenVentaSeleccionada = null;
        }
    }
}
