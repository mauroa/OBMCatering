﻿using OBMCatering.Negocio.Properties;
using System.Collections.Generic;

namespace OBMCatering.Negocio
{
    public class OrdenesPagoBL
    {
        Datos.OBMCateringDAL dal;
        ProveedoresBL proveedoresBL;
        OrdenesCompraBL ordenesCompraBL;

        public OrdenesPagoBL(ContextoNegocio contexto, ProveedoresBL proveedoresBL, OrdenesCompraBL ordenesCompraBL)
        {
            dal = contexto.ObtenerDatos();
            this.proveedoresBL = proveedoresBL;
            this.ordenesCompraBL = ordenesCompraBL;
        }

        public void Crear(OrdenPago ordenPago)
        {
            ValidarOrdenPago(ordenPago);

            Datos.ProveedoresDAL dalProveedores = dal.ObtenerProveedoresDAL();
            Datos.Proveedor proveedorDAL = dalProveedores.Obtener(ordenPago.Proveedor.CUIT);

            if (proveedorDAL == null)
            {
                throw new OBMCateringException(string.Format(Resources.BL_Validaciones_ProveedorInvalido, ordenPago.Proveedor.CUIT));
            }

            Datos.OrdenesCompraDAL dalOrdenesCompra = dal.ObtenerOrdenesCompraDAL();
            List<Datos.ItemOrdenPago> itemsOrdenesPagoDAL = new List<Datos.ItemOrdenPago>();

            foreach(ItemOrdenPago itemOrdenPago in ordenPago.Items)
            {
                Datos.ItemOrdenCompra itemOrdenCompraDAL = dalOrdenesCompra.ObtenerItem(itemOrdenPago.ItemOrdenCompra.Id);

                if (itemOrdenCompraDAL == null)
                {
                    throw new OBMCateringException(Resources.OrdenesPagoBL_Validaciones_ItemOrdenCompraInvalido);
                }

                Datos.ItemOrdenPago itemOrdenPagoDAL = new Datos.ItemOrdenPago
                {
                    ItemOrdenCompra = itemOrdenCompraDAL,
                    Precio = itemOrdenPago.Precio
                };

                itemsOrdenesPagoDAL.Add(itemOrdenPagoDAL);
            }

            Datos.OrdenPago ordenPagoDAL = new Datos.OrdenPago
            {
                Fecha = ordenPago.Fecha,
                Pagada = ordenPago.Pagada,
                Proveedor = proveedorDAL,
                ItemsOrdenesPago = itemsOrdenesPagoDAL
            };

            Datos.OrdenesPagoDAL dalOrdenesPago = dal.ObtenerOrdenesPagoDAL();

            dalOrdenesPago.Crear(ordenPagoDAL);
            dal.Guardar();
        }

        public void Actualizar(OrdenPago ordenPago)
        {
            ValidarOrdenPago(ordenPago);

            Datos.OrdenesPagoDAL dalOrdenesPago = dal.ObtenerOrdenesPagoDAL();
            Datos.OrdenPago ordenPagoDAL = dalOrdenesPago.Obtener(ordenPago.Id);

            if (ordenPagoDAL == null)
            {
                throw new OBMCateringException(Resources.BL_Validaciones_OrdenPagoInvalida);
            }

            foreach (Datos.ItemOrdenPago itemDAL in ordenPagoDAL.ItemsOrdenesPago)
            {
                ItemOrdenPago itemOrdenPago = null;

                foreach (ItemOrdenPago item in ordenPago.Items)
                {
                    if (item.ItemOrdenCompra.Ingrediente.Nombre == itemDAL.ItemOrdenCompra.Ingrediente.Nombre)
                    {
                        itemOrdenPago = item;
                        break;
                    }
                }

                if (itemOrdenPago != null)
                {
                    itemDAL.Precio = itemOrdenPago.Precio;
                }
            }

            ordenPagoDAL.Pagada = ordenPago.Pagada;

            dalOrdenesPago.Actualizar(ordenPagoDAL);
            dal.Guardar();
        }

        public IEnumerable<OrdenPago> Obtener()
        {
            Datos.OrdenesPagoDAL dalOrdenesPago = dal.ObtenerOrdenesPagoDAL();
            IEnumerable<Datos.OrdenPago> ordenesPagoDAL = dalOrdenesPago.Obtener();

            return Obtener(ordenesPagoDAL);
        }

        public IEnumerable<OrdenPago> Obtener(bool pagadas)
        {
            Datos.OrdenesPagoDAL dalOrdenesPago = dal.ObtenerOrdenesPagoDAL();
            IEnumerable<Datos.OrdenPago> ordenesPagoDAL = dalOrdenesPago.Obtener(pagadas);

            return Obtener(ordenesPagoDAL);
        }

        public IEnumerable<OrdenPago> Obtener(Proveedor proveedor)
        {
            if (proveedor == null)
            {
                throw new OBMCateringException(Resources.BL_Validaciones_ProveedorNull);
            }

            Datos.ProveedoresDAL dalProveedores = dal.ObtenerProveedoresDAL();
            Datos.Proveedor proveedorDAL = dalProveedores.Obtener(proveedor.CUIT);

            if (proveedorDAL == null)
            {
                throw new OBMCateringException(string.Format(Resources.BL_Validaciones_ProveedorInvalido, proveedor.CUIT));
            }

            Datos.OrdenesPagoDAL dalOrdenesPago = dal.ObtenerOrdenesPagoDAL();
            IEnumerable<Datos.OrdenPago> ordenesPagoDAL = dalOrdenesPago.Obtener(proveedorDAL);

            return Obtener(ordenesPagoDAL);
        }

        public OrdenPago Obtener(int id)
        {
            Datos.OrdenesPagoDAL dalOrdenesPago = dal.ObtenerOrdenesPagoDAL();
            Datos.OrdenPago ordenPagoDAL = dalOrdenesPago.Obtener(id);

            return Obtener(ordenPagoDAL);
        }

        void ValidarOrdenPago(OrdenPago ordenPago)
        {
            if (ordenPago == null)
            {
                throw new OBMCateringException(Resources.BL_Validaciones_OrdenPagoNull);
            }

            if (ordenPago.Proveedor == null)
            {
                throw new OBMCateringException(Resources.BL_Validaciones_ProveedorNull);
            }

            if (ordenPago.Items == null || ordenPago.Items.Count == 0)
            {
                throw new OBMCateringException(Resources.OrdenesPagoBL_Validaciones_OrdenPagoSinItems);
            }
        }

        IEnumerable<OrdenPago> Obtener(IEnumerable<Datos.OrdenPago> ordenesPagoDAL)
        {
            List<OrdenPago> ordenesPago = new List<OrdenPago>();

            foreach (Datos.OrdenPago ordenPagoDAL in ordenesPagoDAL)
            {
                OrdenPago ordenPago = Obtener(ordenPagoDAL);

                ordenesPago.Add(ordenPago);
            }

            return ordenesPago;
        }

        OrdenPago Obtener(Datos.OrdenPago ordenPagoDAL)
        {
            List<ItemOrdenPago> items = new List<ItemOrdenPago>();

            foreach (Datos.ItemOrdenPago itemDAL in ordenPagoDAL.ItemsOrdenesPago)
            {
                ItemOrdenCompra itemOrdenCompra = ordenesCompraBL.ObtenerItem(itemDAL.ItemOrdenCompra);
                ItemOrdenPago item = new ItemOrdenPago
                {
                    Id = itemDAL.ID,
                    ItemOrdenCompra = itemOrdenCompra,
                    Precio = itemDAL.Precio
                };

                items.Add(item);
            }

            Proveedor proveedor = proveedoresBL.Obtener(ordenPagoDAL.Proveedor);

            return new OrdenPago
            {
               Id = ordenPagoDAL.ID,
               Fecha = ordenPagoDAL.Fecha,
               Pagada = ordenPagoDAL.Pagada,
               Proveedor = proveedor,
               Items = items
            };
        }
    }
}
