using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OBMCatering.Datos
{
    /// <summary>
    /// Responsable de manejar los empleados dentro de la capa de acceso a datos del sistema
    /// </summary>
    public class EmpleadosDAL
    {
        OBMCateringEntities modelo;

        public EmpleadosDAL(OBMCateringEntities modelo)
        {
            this.modelo = modelo;
        }

        public void Crear(Empleado empleado)
        {
            modelo.Empleados.Add(empleado);
        }

        public void Actualizar(Empleado empleado)
        {
            modelo.Empleados.Attach(empleado);
            modelo.Entry(empleado).State = EntityState.Modified;
        }

        public void Eliminar(Empleado empleado)
        {
            modelo.Empleados.Remove(empleado);
        }

        public IEnumerable<Empleado> Obtener()
        {
            return modelo.Empleados.ToList();
        }

        public IEnumerable<Empleado> ObtenerActivos()
        {
            List<Empleado> empleados = new List<Empleado>();

            foreach(Empleado empleado in modelo.Empleados)
            {
                if(empleado.FechaBaja == null)
                {
                    empleados.Add(empleado);
                }
            }

            return empleados;
        }

        public Empleado Obtener(string cuit)
        {
            return modelo.Empleados.Find(cuit);
        }
    }
}
