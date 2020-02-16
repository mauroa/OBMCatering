using OBMCatering.Negocio;
using System;
using System.Collections.Generic;

namespace OBMCatering.Presentacion
{
    /// <summary>
    /// Representacion de la clase <see cref="OrdenVenta"/> en la capa de presentacion
    /// La idea es aplanar los datos y sus tipos, de manera de poder consultarlos mejor 
    /// y tambien mostrarlos de manera mas simple en una grilla 
    /// </summary>
    public class OrdenVentaPresentacion
    {
        OrdenVenta ordenVenta;
        int id;
        ICollection<string> recetas;

        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="OrdenVentaPresentacion"/>
        /// </summary>
        /// <param name="ordenVenta">Orden de venta del sistema</param>
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
            Precio = ordenVenta.Precio.ToString("N2");
            Aprobada = ordenVenta.Aprobada;
        }

        /// <summary>
        /// Cliente asociado a la orden de venta, es decir quien ha realizado el pedido
        /// </summary>
        public string Cliente { get; set; }

        /// <summary>
        /// Fecha de inicio del pedido
        /// </summary>
        public DateTime FechaInicio { get; set; }

        /// <summary>
        /// Fecha de finalizacion del pedido
        /// </summary>
        public DateTime FechaFin { get; set; }

        /// <summary>
        /// Cantidad de comensales del pedido
        /// </summary>
        public string Comensales { get; set; }

        /// <summary>
        /// Precio total del pedido
        /// </summary>
        public string Precio { get; set; }

        /// <summary>
        /// Indica si el pedido esta aprobado o no
        /// </summary>
        public bool Aprobada { get; set; }

        /// <summary>
        /// Listado de recetas del pedido, separadas por coma
        /// </summary>
        public string Recetas
        {
            get
            {
                return string.Join(", ", recetas);
            }
        }

        /// <summary>
        /// Obtiene el identificador de la orden de venta
        /// </summary>
        /// <returns>Identificador de la orden de venta</returns>
        public int ObtenerId()
        {
            return id;
        }

        /// <summary>
        /// Obtiene las recetas del pedido, separadas por coma
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ObtenerRecetas()
        {
            return recetas;
        }

        /// <summary>
        /// Obtiene la instancia de <see cref="OrdenVenta"/> de la capa de negocio asociada
        /// </summary>
        /// <returns>Orden de venta asociada</returns>
        public OrdenVenta ObtenerOrdenVenta()
        {
            return ordenVenta;
        }
    }
}
