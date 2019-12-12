using System.Collections.Generic;

namespace OBMCatering.Negocio
{
    public class LocalidadesBL
    {
        Datos.OBMCateringDAL dal;

        public LocalidadesBL(ContextoNegocio contexto)
        {
            dal = contexto.ObtenerDatos();
        }

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

        public Provincia ObtenerProvincia(int id)
        {
            Datos.ProvinciasDAL dalProvincias = dal.ObtenerProvinciasDAL();
            Datos.Provincia provinciaDAL = dalProvincias.Obtener(id);

            return ObtenerProvincia(provinciaDAL);
        }

        public Provincia ObtenerProvincia(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new OBMCateringException("El nombre de la provincia no puede ser nulo");
            }

            Datos.ProvinciasDAL dalProvincias = dal.ObtenerProvinciasDAL();
            Datos.Provincia provinciaDAL = dalProvincias.Obtener(nombre);

            return ObtenerProvincia(provinciaDAL);

        }
        public IEnumerable<Localidad> ObtenerLocalidades(Provincia provincia)
        {
            if(provincia == null)
            {
                throw new OBMCateringException("La provincia no puede ser nula");
            }

            Datos.ProvinciasDAL dalProvincias = dal.ObtenerProvinciasDAL();
            Datos.Provincia provinciaDAL = dalProvincias.Obtener(provincia.Id);

            if (provinciaDAL == null)
            {
                throw new OBMCateringException("La provincia es incorrecta o no es valida en el sistema");
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

        public Localidad ObtenerLocalidad(int id)
        {
            Datos.LocalidadesDAL dalLocalidades = dal.ObtenerLocalidadesDAL();
            Datos.Localidad localidadDAL = dalLocalidades.Obtener(id);

            return ObtenerLocalidad(localidadDAL);
        }

        public Localidad ObtenerLocalidad(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new OBMCateringException("El nombre de la localidad no puede ser nulo");
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
