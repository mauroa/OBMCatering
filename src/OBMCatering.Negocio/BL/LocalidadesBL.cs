using OBMCatering.Negocio.Properties;
using System.Collections.Generic;

namespace OBMCatering.Negocio
{
    /// <summary>
    /// Reponsable de manejar las localidades y provincias del sistema dentro de la capa de negocio del mismo
    /// </summary>
    public class LocalidadesBL
    {
        Datos.OBMCateringDAL dal;

        /// <summary>
        /// Crea una nueva instancia de <see cref="LocalidadesBL"/>
        /// </summary>
        /// <param name="contexto">Contexto de negocio</param>
        public LocalidadesBL(ContextoNegocio contexto)
        {
            dal = contexto.ObtenerDatos();
        }

        /// <summary>
        /// Obtiene el listado completo de provincias del sistema
        /// </summary>
        /// <returns>Listado de provincias</returns>
        public IEnumerable<Provincia> ObtenerProvincias()
        {
            Datos.ProvinciasDAL dalProvincias = dal.ObtenerProvinciasDAL();
            IEnumerable<Datos.Provincia> provinciasDAL = dalProvincias.Obtener();
            List<Provincia> provincias = new List<Provincia>();

            foreach(Datos.Provincia provinciaDAL in provinciasDAL)
            {
                provincias.Add(new Provincia
                {
                    Id = provinciaDAL.ID,
                    Nombre = provinciaDAL.Nombre
                });
            }

            return provincias;
        }

        /// <summary>
        /// Obtiene una provincia determinada segun su identificador
        /// </summary>
        /// <param name="id">Identificador de la provincia a buscar</param>
        /// <returns>Provincia encontrada</returns>
        public Provincia ObtenerProvincia(int id)
        {
            Datos.ProvinciasDAL dalProvincias = dal.ObtenerProvinciasDAL();
            Datos.Provincia provinciaDAL = dalProvincias.Obtener(id);

            return ObtenerProvincia(provinciaDAL);
        }

        /// <summary>
        /// Obtiene una provincia determinada segun su nombre
        /// </summary>
        /// <param name="nombre">Nombre de la provincia a buscar</param>
        /// <returns>Provincia encontrada</returns>
        public Provincia ObtenerProvincia(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new OBMCateringException(Resources.BL_Validaciones_ProvinciaNull);
            }

            Datos.ProvinciasDAL dalProvincias = dal.ObtenerProvinciasDAL();
            Datos.Provincia provinciaDAL = dalProvincias.Obtener(nombre);

            return ObtenerProvincia(provinciaDAL);

        }

        /// <summary>
        /// Obtiene el listado de localidades de una provincia determinada
        /// </summary>
        /// <param name="provincia">Provincia para obtener sus localidades</param>
        /// <returns>Listado de localidades</returns>
        public IEnumerable<Localidad> ObtenerLocalidades(Provincia provincia)
        {
            if(provincia == null)
            {
                throw new OBMCateringException(Resources.BL_Validaciones_ProvinciaNull);
            }

            Datos.ProvinciasDAL dalProvincias = dal.ObtenerProvinciasDAL();
            Datos.Provincia provinciaDAL = dalProvincias.Obtener(provincia.Id);

            if (provinciaDAL == null)
            {
                throw new OBMCateringException(Resources.BL_Validaciones_ProvinciaInvalida);
            }

            Datos.LocalidadesDAL dalLocalidades = dal.ObtenerLocalidadesDAL();
            IEnumerable<Datos.Localidad> localidadesDAL = dalLocalidades.Obtener(provinciaDAL);
            List<Localidad> localidades = new List<Localidad>();

            foreach(Datos.Localidad localidadDAL in localidadesDAL)
            {
                localidades.Add(new Localidad
                {
                    Id = localidadDAL.ID,
                    Nombre = localidadDAL.Nombre,
                    Provincia = provincia
                });
            }

            return localidades;
        }

        /// <summary>
        /// Obtiene una localidad determinada segun su identificador
        /// </summary>
        /// <param name="id">Identificador de la localidad a buscar</param>
        /// <returns>Localidad encontrada</returns>
        public Localidad ObtenerLocalidad(int id)
        {
            Datos.LocalidadesDAL dalLocalidades = dal.ObtenerLocalidadesDAL();
            Datos.Localidad localidadDAL = dalLocalidades.Obtener(id);

            return ObtenerLocalidad(localidadDAL);
        }

        /// <summary>
        /// Obtiene una localidad determinada segun su nombre
        /// </summary>
        /// <param name="nombre">Nombre de la localidad a buscar</param>
        /// <returns>Localidad encontrada</returns>
        public Localidad ObtenerLocalidad(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new OBMCateringException(Resources.BL_Validaciones_LocalidadNull);
            }

            Datos.LocalidadesDAL dalLocalidades = dal.ObtenerLocalidadesDAL();
            Datos.Localidad localidadDAL = dalLocalidades.Obtener(nombre);

            return ObtenerLocalidad(localidadDAL);
        }

        internal Provincia ObtenerProvincia(Datos.Provincia provinciaDAL)
        {
            return new Provincia
            {
                Id = provinciaDAL.ID,
                Nombre = provinciaDAL.Nombre
            };
        }

        internal Localidad ObtenerLocalidad(Datos.Localidad localidadDAL)
        {
            Provincia provincia = ObtenerProvincia(localidadDAL.Provincia);

            return new Localidad
            {
                Id = localidadDAL.ID,
                Nombre = localidadDAL.Nombre,
                Provincia = provincia
            };
        }
    }
}
