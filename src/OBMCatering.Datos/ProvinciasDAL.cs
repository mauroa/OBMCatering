using System.Collections.Generic;
using System.Linq;

namespace OBMCatering.Datos
{
    /// <summary>
    /// Responsable de manejar las provincias dentro de la capa de acceso a datos del sistema
    /// </summary>
    public class ProvinciasDAL
    {
        OBMCateringEntities modelo;

        public ProvinciasDAL(OBMCateringEntities modelo)
        {
            this.modelo = modelo;
        }

        public IEnumerable<Provincia> Obtener()
        {
            return modelo.Provincias.OrderBy(provincia => provincia.Nombre).ToList();
        }

        public Provincia Obtener(int id)
        {
            return modelo.Provincias.Find(id);
        }

        public Provincia Obtener(string nombre)
        {
            Provincia resultado = null;

            foreach (Provincia provincia in modelo.Provincias)
            {
                if(provincia.Nombre == nombre)
                {
                    resultado = provincia;
                    break;
                }
            }

            return resultado;
        }
    }
}
