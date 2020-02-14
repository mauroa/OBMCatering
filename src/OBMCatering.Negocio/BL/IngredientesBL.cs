using OBMCatering.Negocio.Properties;
using System.Collections.Generic;

namespace OBMCatering.Negocio
{
    public class IngredientesBL
    {
        Datos.OBMCateringDAL dal;

        public IngredientesBL(ContextoNegocio contexto)
        {
            dal = contexto.ObtenerDatos();
        }

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
