using OBMCatering.Negocio.Properties;
using System.Collections.Generic;

namespace OBMCatering.Negocio
{
    /// <summary>
    /// Reponsable de manejar los empleados del sistema dentro de la capa de negocio del mismo
    /// </summary>
    public class EmpleadosBL
    {
        Datos.OBMCateringDAL dal;
        LocalidadesBL localidadesBL;

        /// <summary>
        /// Crea una nueva instancia de <see cref="EmpleadosBL"/>
        /// </summary>
        /// <param name="contexto">Contexto de negocio</param>
        /// <param name="localidadesBL">Capa de negocio de localidades</param>
        public EmpleadosBL(ContextoNegocio contexto, LocalidadesBL localidadesBL)
        {
            dal = contexto.ObtenerDatos();
            this.localidadesBL = localidadesBL;
        }

        /// <summary>
        /// Crea un nuevo empleado en el sistema
        /// </summary>
        /// <param name="empleado">Empleado a crear</param>
        public void Crear(Empleado empleado)
        {
            ValidarEmpleado(empleado);

            Datos.LocalidadesDAL dalLocalidades = dal.ObtenerLocalidadesDAL();
            Datos.Localidad localidadDAL = dalLocalidades.Obtener(empleado.Localidad.Id);

            if (localidadDAL == null)
            {
                throw new OBMCateringException(string.Format(Resources.BL_Validaciones_LocalidadInvalida, empleado.Localidad.Nombre));
            }

            Datos.Empleado empleadoDAL = new Datos.Empleado
            {
                CUIT = empleado.CUIT,
                Nombre = empleado.Nombre,
                FechaNacimiento = empleado.FechaNacimiento,
                Domicilio = empleado.Domicilio,
                Localidad = localidadDAL,
                CodigoPostal = empleado.CodigoPostal,
                Telefono = empleado.Telefono,
                Email = empleado.Email,
                FechaAlta = empleado.FechaAlta,
                FechaBaja = empleado.FechaBaja
            };

            Datos.EmpleadosDAL dalEmpleados = dal.ObtenerEmpleadosDAL();

            dalEmpleados.Crear(empleadoDAL);
            dal.Guardar();
        }

        /// <summary>
        /// Actualiza los datos de un determinado empleado del sistema
        /// </summary>
        /// <param name="empleado">Empleado a actualizar</param>
        public void Actualizar(Empleado empleado)
        {
            ValidarEmpleado(empleado);

            Datos.EmpleadosDAL dalEmpleados = dal.ObtenerEmpleadosDAL();
            Datos.Empleado empleadoDAL = dalEmpleados.Obtener(empleado.CUIT);

            if (empleadoDAL == null)
            {
                throw new OBMCateringException(string.Format(Resources.EmpleadosBL_Validaciones_CUITInvalido, empleado.CUIT));
            }

            Datos.LocalidadesDAL dalLocalidades = dal.ObtenerLocalidadesDAL();
            Datos.Localidad localidadDAL = dalLocalidades.Obtener(empleado.Localidad.Id);

            if (localidadDAL == null)
            {
                throw new OBMCateringException(string.Format(Resources.BL_Validaciones_LocalidadInvalida, empleado.Localidad.Nombre));
            }

            empleadoDAL.Domicilio = empleado.Domicilio;
            empleadoDAL.Localidad = localidadDAL;
            empleadoDAL.CodigoPostal = empleado.CodigoPostal;
            empleadoDAL.Telefono = empleado.Telefono;
            empleadoDAL.Email = empleado.Email;
            empleadoDAL.FechaBaja = empleado.FechaBaja;

            dalEmpleados.Actualizar(empleadoDAL);
            dal.Guardar();
        }

        /// <summary>
        /// Obtiene la lista completa de empleados del sistema
        /// </summary>
        /// <returns>Listado de empleados</returns>
        public IEnumerable<Empleado> Obtener()
        {
            Datos.EmpleadosDAL dalEmpleados = dal.ObtenerEmpleadosDAL();
            IEnumerable<Datos.Empleado> empleadosDAL = dalEmpleados.Obtener();

            return Obtener(empleadosDAL);
        }

        /// <summary>
        /// Obtiene la lista de empleados activos en el sistema
        /// </summary>
        /// <returns>Listado de empleados</returns>
        public IEnumerable<Empleado> ObtenerActivos()
        {
            Datos.EmpleadosDAL dalEmpleados = dal.ObtenerEmpleadosDAL();
            IEnumerable<Datos.Empleado> empleadosDAL = dalEmpleados.ObtenerActivos();

            return Obtener(empleadosDAL);
        }

        /// <summary>
        /// Verifica si un cliente empleado, segun su numero CUIT
        /// </summary>
        /// <param name="cuit">CUIT del empleado a consultar</param>
        /// <returns>Valor que determina si el empleado existe o no</returns>
        public bool Existe(string cuit)
        {
            if (string.IsNullOrEmpty(cuit))
            {
                throw new OBMCateringException(Resources.BL_Validaciones_CUITNull);
            }

            Datos.EmpleadosDAL dalEmpleados = dal.ObtenerEmpleadosDAL();
            Datos.Empleado empleadoDAL = dalEmpleados.Obtener(cuit);

            return empleadoDAL != null;
        }

        /// <summary>
        /// Obtiene un empleado especifico segun su numero de CUIT
        /// </summary>
        /// <param name="cuit">CUIT del empleado a consultar</param>
        /// <returns>Empleado encontrado</returns>
        public Empleado Obtener(string cuit)
        {
            if (string.IsNullOrEmpty(cuit))
            {
                throw new OBMCateringException(Resources.BL_Validaciones_CUITNull);
            }

            Datos.EmpleadosDAL dalEmpleados = dal.ObtenerEmpleadosDAL();
            Datos.Empleado empleadoDAL = dalEmpleados.Obtener(cuit);

            return Obtener(empleadoDAL);
        }

        IEnumerable<Empleado> Obtener(IEnumerable<Datos.Empleado> empleadosDAL)
        {
            List<Empleado> empleados = new List<Empleado>();

            foreach (Datos.Empleado empleadoDAL in empleadosDAL)
            {
                Empleado empleado = Obtener(empleadoDAL);

                empleados.Add(empleado);
            }

            return empleados;
        }

        void ValidarEmpleado(Empleado empleado)
        {
            if (empleado == null)
            {
                throw new OBMCateringException(Resources.EmpleadosBL_Validaciones_EmpleadoNull);
            }

            if (string.IsNullOrEmpty(empleado.CUIT))
            {
                throw new OBMCateringException(Resources.BL_Validaciones_CUITNull);
            }

            if (string.IsNullOrEmpty(empleado.Nombre))
            {
                throw new OBMCateringException(Resources.EmpleadosBL_Validaciones_NombreNull);
            }

            if (string.IsNullOrEmpty(empleado.Domicilio))
            {
                throw new OBMCateringException(Resources.BL_Validaciones_DomicilioNull);
            }

            if (empleado.Localidad == null)
            {
                throw new OBMCateringException(Resources.BL_Validaciones_LocalidadNull);
            }

            if (string.IsNullOrEmpty(empleado.CodigoPostal))
            {
                throw new OBMCateringException(Resources.BL_Validaciones_CPNull);
            }

            if (string.IsNullOrEmpty(empleado.Telefono))
            {
                throw new OBMCateringException(Resources.BL_Validaciones_TelefonoNull);
            }

            if (string.IsNullOrEmpty(empleado.Email))
            {
                throw new OBMCateringException(Resources.BL_Validaciones_EmailNull);
            }
        }

        Empleado Obtener(Datos.Empleado empleadoDAL)
        {
            Localidad localidad = localidadesBL.ObtenerLocalidad(empleadoDAL.Localidad);

            return new Empleado
            {
                CUIT = empleadoDAL.CUIT,
                Nombre = empleadoDAL.Nombre,
                FechaNacimiento = empleadoDAL.FechaNacimiento,
                Domicilio = empleadoDAL.Domicilio,
                Localidad = localidad,
                CodigoPostal = empleadoDAL.CodigoPostal,
                Telefono = empleadoDAL.Telefono,
                Email = empleadoDAL.Email,
                FechaAlta = empleadoDAL.FechaAlta,
                FechaBaja = empleadoDAL.FechaBaja
            };
        }
    }
}
