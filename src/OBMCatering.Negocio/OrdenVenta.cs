using System;
using System.Collections.Generic;

namespace OBMCatering.Negocio
{
    public class OrdenVenta
    {
        public OrdenVenta()
        {
            Recetas = new List<Receta>();
        }

        public int Id { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public int Comensales { get; set; }

        public decimal Precio { get; set; }

        public bool Aprobada { get; set; }

        public Cliente Cliente { get; set; }

        public ICollection<Receta> Recetas { get; set; }
    }
}
