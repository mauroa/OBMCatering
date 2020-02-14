using OBMCatering.Negocio.Properties;
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
                throw new OBMCateringException(string.Format(Resources.BL_Validaciones_LocalidadInvalida, proveedor.Localidad.Nombre));
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
                throw new OBMCateringException(string.Format(Resources.BL_Validaciones_ProveedorInvalido, proveedor.CUIT));
            }

            Datos.LocalidadesDAL dalLocalidades = dal.ObtenerLocalidadesDAL();
            Datos.Localidad localidadDAL = dalLocalidades.Obtener(proveedor.Localidad.Id);

            if (localidadDAL == null)
            {
                throw new OBMCateringException(string.Format(Resources.BL_Validaciones_LocalidadInvalida, proveedor.Localidad.Nombre));
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
                throw new OBMCateringException(string.Format(Resources.BL_Validaciones_ProveedorInvalido, proveedor.CUIT));
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
                throw new OBMCateringException(Resources.BL_Validaciones_CUITNull);
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
                throw new OBMCateringException(Resources.BL_Validaciones_CUITNull);
            }

            Datos.ProveedoresDAL dalProveedores = dal.ObtenerProveedoresDAL();
            Datos.Proveedor proveedorDAL = dalProveedores.Obtener(cuit);

            return Obtener(proveedorDAL);
        }

        public Proveedor ObtenerPorNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new OBMCateringException(Resources.ProveedoresBL_Validaciones_NombreNull);
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
                throw new OBMCateringException(Resources.BL_Validaciones_ProveedorNull);
            }

            if (string.IsNullOrEmpty(proveedor.CUIT))
            {
                throw new OBMCateringException(Resources.BL_Validaciones_CUITNull);
            }

            if (string.IsNullOrEmpty(proveedor.Nombre))
            {
                throw new OBMCateringException(Resources.ProveedoresBL_Validaciones_NombreNull);
            }

            if (string.IsNullOrEmpty(proveedor.Domicilio))
            {
                throw new OBMCateringException(Resources.BL_Validaciones_DomicilioNull);
            }

            if (proveedor.Localidad == null)
            {
                throw new OBMCateringException(Resources.BL_Validaciones_LocalidadNull);
            }

            if (string.IsNullOrEmpty(proveedor.CodigoPostal))
            {
                throw new OBMCateringException(Resources.BL_Validaciones_CPNull);
            }

            if (string.IsNullOrEmpty(proveedor.Telefono))
            {
                throw new OBMCateringException(Resources.BL_Validaciones_TelefonoNull);
            }

            if (string.IsNullOrEmpty(proveedor.Email))
            {
                throw new OBMCateringException(Resources.BL_Validaciones_EmailNull);
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
