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
            Datos.LocalidadesDAL dalLocalidades = dal.ObtenerLocalidadesDAL();
            Datos.Localidad localidadDAL = dalLocalidades.Obtener(empleado.Localidad.Id);
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
            Datos.EmpleadosDAL dalEmpleados = dal.ObtenerEmpleadosDAL();
            Datos.Empleado empleadoDAL = dalEmpleados.Obtener(empleado.CUIT);
            Datos.LocalidadesDAL dalLocalidades = dal.ObtenerLocalidadesDAL();
            Datos.Localidad localidadDAL = dalLocalidades.Obtener(empleado.Localidad.Id);

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
            Datos.EmpleadosDAL dalEmpleados = dal.ObtenerEmpleadosDAL();
            Datos.Empleado empleadoDAL = dalEmpleados.Obtener(empleado.CUIT);

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

        public Empleado Obtener(string cuit)
        {
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

        public bool Existe(string cuit)
        {
            Datos.EmpleadosDAL dalEmpleados = dal.ObtenerEmpleadosDAL();
            Datos.Empleado empleadoDAL = dalEmpleados.Obtener(cuit);

            return empleadoDAL != null;
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
