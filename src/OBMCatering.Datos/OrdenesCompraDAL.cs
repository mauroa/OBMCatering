﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OBMCatering.Datos
{
    public class OrdenesCompraDAL
    {
        OBMCateringEntities modelo;

        public OrdenesCompraDAL(OBMCateringEntities modelo)
        {
            this.modelo = modelo;
        }

        public void Crear(OrdenCompra ordenCompra)
        {
            modelo.OrdenesCompra.Add(ordenCompra);
        }

        public void Actualizar(OrdenCompra ordenCompra)
        {
            modelo.OrdenesCompra.Attach(ordenCompra);
            modelo.Entry(ordenCompra).State = EntityState.Modified;
        }

        public void Eliminar(OrdenCompra ordenCompra)
        {
            modelo.OrdenesCompra.Remove(ordenCompra);
        }

        public IEnumerable<OrdenCompra> Obtener()
        {
            return modelo.OrdenesCompra.ToList();
        }

        public IEnumerable<OrdenCompra> Obtener(bool ejecutadas)
        {
            List<OrdenCompra> ordenesCompra = new List<OrdenCompra>();

            foreach(OrdenCompra ordenCompra in modelo.OrdenesCompra)
            {
                if(ordenCompra.Ejecutada == ejecutadas)
                {
                    ordenesCompra.Add(ordenCompra);
                }
            }

            return ordenesCompra;
        }

        public OrdenCompra Obtener(int id)
        {
            return modelo.OrdenesCompra.Find(id);
        }

        public ItemOrdenCompra ObtenerItem(int id)
        {
            ItemOrdenCompra resultado = null;

            foreach (ItemOrdenCompra itemOrdenCompra in modelo.ItemsOrdenesCompra)
            {
                if(itemOrdenCompra.ID == id)
                {
                    resultado = itemOrdenCompra;
                    break;
                }
            }

            return resultado;
        }
    }
}
