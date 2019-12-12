﻿using OBMCatering.Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace OBMCatering.Presentacion
{
    public partial class BitacoraForm : Form
    {
        ContextoPresentacion contexto;
        UsuariosBL usuariosBL;
        BitacoraBL bitacoraBL;

        public BitacoraForm()
        {
            InitializeComponent();
        }

        void BitacoraForm_Load(object sender, EventArgs e)
        {
            contexto = ContextoPresentacion.Instancia;
            usuariosBL = new UsuariosBL(ContextoNegocio.Instancia);
            bitacoraBL = new BitacoraBL(ContextoNegocio.Instancia, usuariosBL);

            btnFiltrar.Click += BtnFiltrar_Click;
            CargarTipos();
            CargarUsuarios();
            CargarBitacora();
            LimpiarFormulario();

            contexto.RegistrarEvento("Ingreso a la pantalla de bitacora");
        }

        void BtnFiltrar_Click(object sender, EventArgs e)
        {
            FiltrarBitacora();
        }

        void CargarTipos()
        {
            cboTipos.Items.Add("");
            cboTipos.Items.Add(TipoMensajeBitacora.Informacion.ToString());
            cboTipos.Items.Add(TipoMensajeBitacora.Alerta.ToString());
            cboTipos.Items.Add(TipoMensajeBitacora.Error.ToString());
        }

        void CargarUsuarios()
        {
            cboUsuarios.Items.Add("");

            IEnumerable<Usuario> usuarios = usuariosBL.Obtener();

            foreach(Usuario usuario in usuarios)
            {
                cboUsuarios.Items.Add(usuario.Nick);
            }
        }

        void CargarBitacora()
        {
            try
            {
                IEnumerable<Bitacora> bitacoras = bitacoraBL.Obtener();

                CargarBitacora(bitacoras);
            }
            catch (Exception ex)
            {
                contexto.RegistrarError(ex);
            }
        }

        void FiltrarBitacora()
        {
            try
            {
                IEnumerable<Bitacora> bitacoras;

                if(cboUsuarios.SelectedItem != null && cboUsuarios.SelectedItem.ToString() != "")
                {
                    Usuario usuario = usuariosBL.Obtener(cboUsuarios.SelectedItem.ToString());

                    bitacoras = bitacoraBL.Obtener(usuario);
                }
                else
                {
                    bitacoras = bitacoraBL.Obtener();
                }

                if (dtpDesde.Value > dtpDesde.MinDate)
                {
                    bitacoras = bitacoras.Where(bitacora => bitacora.Fecha >= dtpDesde.Value);
                }

                if (dtpHasta.Value > dtpHasta.MinDate)
                {
                    bitacoras = bitacoras.Where(bitacora => bitacora.Fecha <= dtpHasta.Value);
                }

                string tipo = null;

                if (cboTipos.SelectedItem != null)
                {
                    tipo = cboTipos.SelectedItem.ToString();
                }

                if (!string.IsNullOrEmpty(tipo))
                {
                    bitacoras = bitacoras.Where(bitacora => bitacora.Tipo.ToString() == tipo);
                }

                CargarBitacora(bitacoras);
            }
            catch (Exception ex)
            {
                contexto.RegistrarError(ex);
            }
        }

        void CargarBitacora(IEnumerable<Bitacora> bitacoras)
        {
            IEnumerable<BitacoraPresentacion> bitacorasPresentacion = ObtenerBitacorasPresentacion(bitacoras);

            grvBitacora.DataSource = bitacorasPresentacion;
        }

        IEnumerable<BitacoraPresentacion> ObtenerBitacorasPresentacion(IEnumerable<Bitacora> bitacoras)
        {
            List<BitacoraPresentacion> bitacorasPresentacion = new List<BitacoraPresentacion>();

            foreach (Bitacora bitacora in bitacoras)
            {
                bitacorasPresentacion.Add(new BitacoraPresentacion(bitacora));
            }

            return bitacorasPresentacion;
        }

        void LimpiarFormulario()
        {
            dtpDesde.Value = dtpDesde.MinDate;
            dtpHasta.Value = dtpDesde.MinDate;
            cboTipos.SelectedItem = "";
            cboUsuarios.SelectedItem = "";
            grvBitacora.ClearSelection();
        }
    }
}