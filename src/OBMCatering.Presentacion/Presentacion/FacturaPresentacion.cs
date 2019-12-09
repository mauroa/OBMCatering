﻿using OBMCatering.Negocio;
using System;

namespace OBMCatering.Presentacion
{
    public class FacturaPresentacion
    {
        int id;
        OrdenVentaPresentacion ordenVenta;

        public FacturaPresentacion(Factura factura)
        {
            Fecha = factura.Fecha;
            Cobrada = factura.Cobrada;
            id = factura.Id;
            ordenVenta = new OrdenVentaPresentacion(factura.OrdenVenta);
        }

        public DateTime Fecha { get; set; }

        public bool Cobrada { get; set; }

        public string Cliente
        {
            get
            {
                return ordenVenta.Cliente;
            }
        }

        public DateTime FechaInicio
        {
            get
            {
                return ordenVenta.FechaInicio;
            }
        }

        public DateTime FechaFin
        {
            get
            {
                return ordenVenta.FechaFin;
            }
        }

        public string Comensales
        {
            get
            {
                return ordenVenta.Comensales;
            }
        }

        public string Precio
        {
            get
            {
                return ordenVenta.Precio;
            }
        }

        public string Recetas
        {
            get
            {
                return ordenVenta.Recetas;
            }
        }

        public int ObtenerId()
        {
            return id;
        }
    }
}
