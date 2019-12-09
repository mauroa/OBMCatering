using System.Collections.Generic;
using System.Linq;

namespace OBMCatering.Datos
{
    public class LocalidadesDAL
    {
        OBMCateringEntities modelo;

        public LocalidadesDAL(OBMCateringEntities modelo)
        {
            this.modelo = modelo;
        }

        public IEnumerable<Localidad> Obtener()
        {
            return modelo.Localidades.OrderBy(localidad => localidad.Nombre).ToList();
        }

        public IEnumerable<Localidad> Obtener(Provincia provincia)
        {
            List<Localidad> localidades = new List<Localidad>();

            foreach (Localidad localidad in modelo.Localidades.OrderBy(localidad => localidad.Nombre))
            {
                if(localidad.Provincia.ID == provincia.ID)
                {
                    localidades.Add(localidad);
                }
            }

            return localidades;
        }

        public Localidad Obtener(int id)
        {
            return modelo.Localidades.Find(id);
        }

        public Localidad Obtener(string nombre)
        {
            Localidad resultado = null;

            foreach (Localidad localidad in modelo.Localidades)
            {
                if (localidad.Nombre == nombre)
                {
                    resultado = localidad;
                    break;
                }
            }

            return resultado;
        }
    }
}
