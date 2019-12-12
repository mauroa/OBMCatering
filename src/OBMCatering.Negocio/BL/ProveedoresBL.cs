using System.Collections.Generic;

namespace OBMCatering.Negocio
{
    public class ProveedoresBL
    {
        Datos.OBMCateringDAL dal;
        LocalidadesBL localidadesBL;

        public ProveedoresBL(ContextoNegocio contexto, LocalidadesBL localidadesBL)
        {
            dal = contexto.ObtenerDatos();
            this.localidadesBL = localidadesBL;
        }

        public void Crear(Proveedor proveedor)
        {
            ValidarProveedor(proveedor);

            Datos.LocalidadesDAL dalLocalidades = dal.ObtenerLocalidadesDAL();
            Datos.Localidad localidadDAL = dalLocalidades.Obtener(proveedor.Localidad.Id);

            if (localidadDAL == null)
            {
                throw new OBMCateringException(string.Format("La localidad '{0}' es incorrecta o no es valida en el sistema", proveedor.Localidad.Nombre));
            }

            Datos.Proveedor proveedorDAL = new Datos.Proveedor
            {
                CUIT = proveedor.CUIT,
                Nombre = proveedor.Nombre,
                Domicilio = proveedor.Domicilio,
                Localidad = localidadDAL,
                CodigoPostal = proveedor.CodigoPostal,
                Telefono = proveedor.Telefono,
                Email = proveedor.Email,
                FechaAlta = proveedor.FechaAlta,
                FechaBaja = proveedor.FechaBaja
            };

            Datos.ProveedoresDAL dalProveedores = dal.ObtenerProveedoresDAL();

            dalProveedores.Crear(proveedorDAL);
            dal.Guardar();
        }

        public void Actualizar(Proveedor proveedor)
        {
            ValidarProveedor(proveedor);

            Datos.ProveedoresDAL dalProveedores = dal.ObtenerProveedoresDAL();
            Datos.Proveedor proveedorDAL = dalProveedores.Obtener(proveedor.CUIT);

            if (proveedorDAL == null)
            {
                throw new OBMCateringException(string.Format("El proveedor con CUIT '{0}' no existe", proveedor.CUIT));
            }

            Datos.LocalidadesDAL dalLocalidades = dal.ObtenerLocalidadesDAL();
            Datos.Localidad localidadDAL = dalLocalidades.Obtener(proveedor.Localidad.Id);

            if (localidadDAL == null)
            {
                throw new OBMCateringException(string.Format("La localidad '{0}' es incorrecta o no es valida en el sistema", proveedor.Localidad.Nombre));
            }

            proveedorDAL.Domicilio = proveedor.Domicilio;
            proveedorDAL.Localidad = localidadDAL;
            proveedorDAL.CodigoPostal = proveedor.CodigoPostal;
            proveedorDAL.Telefono = proveedor.Telefono;
            proveedorDAL.Email = proveedor.Email;
            proveedorDAL.FechaBaja = proveedor.FechaBaja;

            dalProveedores.Actualizar(proveedorDAL);
            dal.Guardar();
        }

        public void Eliminar(Proveedor proveedor)
        {
            ValidarProveedor(proveedor);

            Datos.ProveedoresDAL dalProveedores = dal.ObtenerProveedoresDAL();
            Datos.Proveedor proveedorDAL = dalProveedores.Obtener(proveedor.CUIT);

            if (proveedorDAL == null)
            {
                throw new OBMCateringException(string.Format("El proveedor con CUIT '{0}' no existe", proveedor.CUIT));
            }

            dalProveedores.Eliminar(proveedorDAL);
            dal.Guardar();
        }

        public IEnumerable<Proveedor> Obtener()
        {
            Datos.ProveedoresDAL dalProveedores = dal.ObtenerProveedoresDAL();
            IEnumerable<Datos.Proveedor> proveedoresDAL = dalProveedores.Obtener();

            return Obtener(proveedoresDAL);
        }

        public bool Existe(string cuit)
        {
            if (string.IsNullOrEmpty(cuit))
            {
                throw new OBMCateringException("El CUIT del proveedor no puede ser nulo o vacio");
            }

            Datos.ProveedoresDAL dalProveedores = dal.ObtenerProveedoresDAL();
            Datos.Proveedor proveedorDAL = dalProveedores.Obtener(cuit);

            return proveedorDAL != null;
        }

        public IEnumerable<Proveedor> ObtenerActivos()
        {
            Datos.ProveedoresDAL dalProveedores = dal.ObtenerProveedoresDAL();
            IEnumerable<Datos.Proveedor> proveedoresDAL = dalProveedores.ObtenerActivos();

            return Obtener(proveedoresDAL);
        }

        public Proveedor ObtenerPorCUIT(string cuit)
        {
            if (string.IsNullOrEmpty(cuit))
            {
                throw new OBMCateringException("El CUIT del proveedor no puede ser nulo o vacio");
            }

            Datos.ProveedoresDAL dalProveedores = dal.ObtenerProveedoresDAL();
            Datos.Proveedor proveedorDAL = dalProveedores.Obtener(cuit);

            return Obtener(proveedorDAL);
        }

        public Proveedor ObtenerPorNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new OBMCateringException("El nombre del proveedor no puede ser nulo o vacio");
            }

            Datos.ProveedoresDAL dalProveedores = dal.ObtenerProveedoresDAL();
            Datos.Proveedor proveedorDAL = dalProveedores.ObtenerPorNombre(nombre);

            return Obtener(proveedorDAL);
        }

        internal Proveedor Obtener(Datos.Proveedor proveedorDAL)
        {
            Localidad localidad = localidadesBL.ObtenerLocalidad(proveedorDAL.Localidad);

            return new Proveedor
            {
                CUIT = proveedorDAL.CUIT,
                Nombre = proveedorDAL.Nombre,
                Domicilio = proveedorDAL.Domicilio,
                Localidad = localidad,
                CodigoPostal = proveedorDAL.CodigoPostal,
                Telefono = proveedorDAL.Telefono,
                Email = proveedorDAL.Email,
                FechaAlta = proveedorDAL.FechaAlta,
                FechaBaja = proveedorDAL.FechaBaja
            };
        }

        void ValidarProveedor(Proveedor proveedor)
        {
            if(proveedor == null)
            {
                throw new OBMCateringException("El proveedor no puede ser nulo");
            }

            if (string.IsNullOrEmpty(proveedor.CUIT))
            {
                throw new OBMCateringException("El CUIT del proveedor no puede ser nulo o vacio");
            }

            if (string.IsNullOrEmpty(proveedor.Nombre))
            {
                throw new OBMCateringException("El Nombre del proveedor no puede ser nulo o vacio");
            }

            if (string.IsNullOrEmpty(proveedor.Domicilio))
            {
                throw new OBMCateringException("El Domicilio del proveedor no puede ser nulo o vacio");
            }

            if (proveedor.Localidad == null)
            {
                throw new OBMCateringException("La Localidad del proveedor no puede ser nula");
            }

            if (string.IsNullOrEmpty(proveedor.CodigoPostal))
            {
                throw new OBMCateringException("El Codigo Postal del proveedor no puede ser nulo o vacio");
            }

            if (string.IsNullOrEmpty(proveedor.Telefono))
            {
                throw new OBMCateringException("El Telefono del proveedor no puede ser nulo o vacio");
            }

            if (string.IsNullOrEmpty(proveedor.Email))
            {
                throw new OBMCateringException("El Email del proveedor no puede ser nulo o vacio");
            }
        }

        IEnumerable<Proveedor> Obtener(IEnumerable<Datos.Proveedor> proveedoresDAL)
        {
            List<Proveedor> proveedores = new List<Proveedor>();

            foreach (Datos.Proveedor proveedorDAL in proveedoresDAL)
            {
                Proveedor proveedor = Obtener(proveedorDAL);

                proveedores.Add(proveedor);
            }

            return proveedores;
        }
    }
}
