using OBMCatering.Negocio;
using System;
using System.Collections.Generic;

namespace OBMCatering.Presentacion
{
    public class OrdenVentaPresentacion
    {
        OrdenVenta ordenVenta;
        int id;
        ICollection<string> recetas;

        public OrdenVentaPresentacion(OrdenVenta ordenVenta)
        {
            this.ordenVenta = ordenVenta;
            id = ordenVenta.Id;
            recetas = new List<string>();

            foreach (Receta receta in ordenVenta.Recetas)
            {
                recetas.Add(receta.Nombre);
            }

            Cliente = ordenVenta.Cliente.Nombre;
            FechaInicio = ordenVenta.FechaInicio;
            FechaFin = ordenVenta.FechaFin;
            Comensales = ordenVenta.Comensales.ToString();
            Precio = ordenVenta.Precio.ToString();
            Aprobada = ordenVenta.Aprobada;
        }

        public string Cliente { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public string Comensales { get; set; }

        public string Precio { get; set; }

        public bool Aprobada { get; set; }

        public string Recetas
        {
            get
            {
                return string.Join(", ", recetas);
            }
        }

        public int ObtenerId()
        {
            return id;
        }

        public IEnumerable<string> ObtenerRecetas()
        {
            return recetas;
        }

        public OrdenVenta ObtenerOrdenVenta()
        {
            return ordenVenta;
        }
    }
}
