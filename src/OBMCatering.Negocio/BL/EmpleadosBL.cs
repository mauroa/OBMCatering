using System.Collections.Generic;

namespace OBMCatering.Negocio
{
    public class EmpleadosBL
    {
        Datos.OBMCateringDAL dal;
        LocalidadesBL localidadesBL;

        public EmpleadosBL(ContextoNegocio contexto, LocalidadesBL localidadesBL)
        {
            dal = contexto.ObtenerDatos();
            this.localidadesBL = localidadesBL;
        }

        public void Crear(Empleado empleado)
        {
            ValidarEmpleado(empleado);

            Datos.LocalidadesDAL dalLocalidades = dal.ObtenerLocalidadesDAL();
            Datos.Localidad localidadDAL = dalLocalidades.Obtener(empleado.Localidad.Id);

            if (localidadDAL == null)
            {
                throw new OBMCateringException(string.Format("La localidad '{0}' es incorrecta o no es valida en el sistema", empleado.Localidad.Nombre));
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

        public void Actualizar(Empleado empleado)
        {
            ValidarEmpleado(empleado);

            Datos.EmpleadosDAL dalEmpleados = dal.ObtenerEmpleadosDAL();
            Datos.Empleado empleadoDAL = dalEmpleados.Obtener(empleado.CUIT);

            if (empleadoDAL == null)
            {
                throw new OBMCateringException(string.Format("El empleado con CUIT '{0}' no existe", empleado.CUIT));
            }

            Datos.LocalidadesDAL dalLocalidades = dal.ObtenerLocalidadesDAL();
            Datos.Localidad localidadDAL = dalLocalidades.Obtener(empleado.Localidad.Id);

            if (localidadDAL == null)
            {
                throw new OBMCateringException(string.Format("La localidad '{0}' es incorrecta o no es valida en el sistema", empleado.Localidad.Nombre));
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

        public void Eliminar(Empleado empleado)
        {
            ValidarEmpleado(empleado);

            Datos.EmpleadosDAL dalEmpleados = dal.ObtenerEmpleadosDAL();
            Datos.Empleado empleadoDAL = dalEmpleados.Obtener(empleado.CUIT);

            if (empleadoDAL == null)
            {
                throw new OBMCateringException(string.Format("El empleado con CUIT '{0}' no existe", empleado.CUIT));
            }

            dalEmpleados.Eliminar(empleadoDAL);
            dal.Guardar();
        }

        public IEnumerable<Empleado> Obtener()
        {
            Datos.EmpleadosDAL dalEmpleados = dal.ObtenerEmpleadosDAL();
            IEnumerable<Datos.Empleado> empleadosDAL = dalEmpleados.Obtener();

            return Obtener(empleadosDAL);
        }

        public IEnumerable<Empleado> ObtenerActivos()
        {
            Datos.EmpleadosDAL dalEmpleados = dal.ObtenerEmpleadosDAL();
            IEnumerable<Datos.Empleado> empleadosDAL = dalEmpleados.ObtenerActivos();

            return Obtener(empleadosDAL);
        }

        public bool Existe(string cuit)
        {
            if (string.IsNullOrEmpty(cuit))
            {
                throw new OBMCateringException("El CUIT del empleado no puede ser nulo o vacio");
            }

            Datos.EmpleadosDAL dalEmpleados = dal.ObtenerEmpleadosDAL();
            Datos.Empleado empleadoDAL = dalEmpleados.Obtener(cuit);

            return empleadoDAL != null;
        }

        public Empleado Obtener(string cuit)
        {
            if (string.IsNullOrEmpty(cuit))
            {
                throw new OBMCateringException("El CUIT del empleado no puede ser nulo o vacio");
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
                throw new OBMCateringException("El empleado no puede ser nulo");
            }

            if (string.IsNullOrEmpty(empleado.CUIT))
            {
                throw new OBMCateringException("El CUIT del empleado no puede ser nulo o vacio");
            }

            if (string.IsNullOrEmpty(empleado.Nombre))
            {
                throw new OBMCateringException("El nombre del empleado no puede ser nulo o vacio");
            }

            if (string.IsNullOrEmpty(empleado.Domicilio))
            {
                throw new OBMCateringException("El domicilio del empleado no puede ser nulo o vacio");
            }

            if (empleado.Localidad == null)
            {
                throw new OBMCateringException("La localidad del empleado no puede ser nula");
            }

            if (string.IsNullOrEmpty(empleado.CodigoPostal))
            {
                throw new OBMCateringException("El codigo postal del empleado no puede ser nulo o vacio");
            }

            if (string.IsNullOrEmpty(empleado.Telefono))
            {
                throw new OBMCateringException("El telefono del empleado no puede ser nulo o vacio");
            }

            if (string.IsNullOrEmpty(empleado.Email))
            {
                throw new OBMCateringException("El email del empleado no puede ser nulo o vacio");
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
