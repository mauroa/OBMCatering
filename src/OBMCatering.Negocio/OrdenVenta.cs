using System;
using System.Collections.Generic;

namespace OBMCatering.Negocio
{
    /// <summary>
    /// Representa un pedido u orden de venta dentro del sistema
    /// Son los pedidos de comida que realizan los clientes
    /// </summary>
    public class OrdenVenta
    {
        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="OrdenVenta"/>
        /// </summary>
        public OrdenVenta()
        {
            Recetas = new List<Receta>();
        }

        /// <summary>
        /// Identificador de la orden de venta
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Fecha desde la cual se comenzaran a entregar los pedidos
        /// </summary>
        public DateTime FechaInicio { get; set; }

        /// <summary>
        /// Fecha hasta la cual se entregaran los pedidos
        /// </summary>
        public DateTime FechaFin { get; set; }

        /// <summary>
        /// Cantidad de comensales para del rango de fechas especificado
        /// Se asume que cada dia habra la misma cantidad de comensales
        /// </summary>
        public int Comensales { get; set; }

        /// <summary>
        /// Precio total de la orden
        /// </summary>
        public decimal Precio { get; set; }

        /// <summary>
        /// Indica si la orden esta aprobada, es decir si esta lista para facturar y para generar la orden de compra de los ingredientes necesarios
        /// </summary>
        public bool Aprobada { get; set; }

        /// <summary>
        /// Cliente que ha realizado la orden
        /// </summary>
        public Cliente Cliente { get; set; }

        /// <summary>
        /// Recetas asociadas, es decir lo que se cocinara para los dias que abarque la orden
        /// </summary>
        public ICollection<Receta> Recetas { get; set; }
    }
}
