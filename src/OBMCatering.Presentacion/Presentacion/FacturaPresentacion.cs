using OBMCatering.Negocio;
using System;

namespace OBMCatering.Presentacion
{
    /// <summary>
    /// Representacion de la clase <see cref="Factura"/> en la capa de presentacion
    /// La idea es aplanar los datos y sus tipos, de manera de poder consultarlos mejor 
    /// y tambien mostrarlos de manera mas simple en una grilla 
    /// </summary>
    public class FacturaPresentacion
    {
        Factura factura;
        int id;
        OrdenVentaPresentacion ordenVenta;

        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="FacturaPresentacion"/>
        /// </summary>
        /// <param name="factura">Factura del sistema</param>
        public FacturaPresentacion(Factura factura)
        {
            this.factura = factura;
            id = factura.Id;
            ordenVenta = new OrdenVentaPresentacion(factura.OrdenVenta);

            Fecha = factura.Fecha;
            Cobrada = factura.Cobrada;
        }

        /// <summary>
        /// Fecha de facturacion
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Indica si la factura fue cobrada o no
        /// </summary>
        public bool Cobrada { get; set; }

        /// <summary>
        /// Cliente asociado a la factura
        /// </summary>
        public string Cliente
        {
            get
            {
                return ordenVenta.Cliente;
            }
        }

        /// <summary>
        /// Fecha de inicio del pedido asociado a la factura
        /// </summary>
        public DateTime FechaInicio
        {
            get
            {
                return ordenVenta.FechaInicio;
            }
        }

        /// <summary>
        /// Fecha de finalizacion del pedido asociado a la factura
        /// </summary>
        public DateTime FechaFin
        {
            get
            {
                return ordenVenta.FechaFin;
            }
        }

        /// <summary>
        /// Cantidad de comensales del pedido asociado a la factura
        /// </summary>
        public string Comensales
        {
            get
            {
                return ordenVenta.Comensales;
            }
        }

        /// <summary>
        /// Precio total del pedido asociado a la factura
        /// </summary>
        public string Precio
        {
            get
            {
                return ordenVenta.Precio;
            }
        }

        /// <summary>
        /// Listado de recetas separadas por coma, del pedido asociado a la factura
        /// </summary>
        public string Recetas
        {
            get
            {
                return ordenVenta.Recetas;
            }
        }

        /// <summary>
        /// Obtiene el identificador de la factura
        /// </summary>
        /// <returns></returns>
        public int ObtenerId()
        {
            return id;
        }

        /// <summary>
        /// Obtiene la instancia de <see cref="Factura"/> de la capa de negocio asociada
        /// </summary>
        /// <returns>Factura asociada</returns>
        public Factura ObtenerFactura()
        {
            return factura;
        }
    }
}
