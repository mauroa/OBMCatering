using OBMCatering.Negocio.Properties;
using System.Collections.Generic;

namespace OBMCatering.Negocio
{
    /// <summary>
    /// Reponsable de manejar los ingredientes del sistema dentro de la capa de negocio del mismo
    /// </summary>
    public class IngredientesBL
    {
        Datos.OBMCateringDAL dal;

        /// <summary>
        /// Crea una nueva instancia de <see cref="IngredientesBL"/>
        /// </summary>
        /// <param name="contexto">Contexto de negocio</param>
        public IngredientesBL(ContextoNegocio contexto)
        {
            dal = contexto.ObtenerDatos();
        }

        /// <summary>
        /// Obtiene el listado completo de ingredientes existentes en el sistema
        /// </summary>
        /// <returns>Listado de ingredientes</returns>
        public IEnumerable<Ingrediente> Obtener()
        {
            Datos.IngredientesDAL dalIngredientes = dal.ObtenerIngredientesDAL();
            IEnumerable<Datos.Ingrediente> ingredientesDAL = dalIngredientes.Obtener();
            List<Ingrediente> ingredientes = new List<Ingrediente>();

            foreach (Datos.Ingrediente ingredienteDAL in ingredientesDAL)
            {
                Ingrediente ingrediente = Obtener(ingredienteDAL);

                ingredientes.Add(ingrediente);
            }

            return ingredientes;
        }

        /// <summary>
        /// Obtiene un ingrediente segun su nombre
        /// </summary>
        /// <param name="nombre">Nombre del ingrediente</param>
        /// <returns>Ingrediente encontrado</returns>
        public Ingrediente Obtener(string nombre)
        {
            if(string.IsNullOrEmpty(nombre))
            {
                throw new OBMCateringException(Resources.IngredientesBL_Validaciones_NombreIngredienteNull);
            }

            Datos.IngredientesDAL dalIngredientes = dal.ObtenerIngredientesDAL();
            Datos.Ingrediente ingredienteDAL = dalIngredientes.Obtener(nombre);

            return Obtener(ingredienteDAL);
        }

        internal Ingrediente Obtener(Datos.Ingrediente ingredienteDAL)
        {
            return new Ingrediente
            {
                Id = ingredienteDAL.ID,
                Nombre = ingredienteDAL.Nombre,
                Descripcion = ingredienteDAL.Descripcion
            };
        }
    }
}
