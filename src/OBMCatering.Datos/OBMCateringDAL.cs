using System.Data.Entity;

namespace OBMCatering.Datos
{
    public class OBMCateringDAL
    {
        OBMCateringEntities modelo;
        EmpleadosDAL empleados;
        ClientesDAL clientes;
        ProveedoresDAL proveedores;
        RecetasDAL recetas;
        IngredientesDAL ingredientes;
        PreciosIngredientesDAL preciosIngredientes;
        OrdenesVentaDAL ordenesVenta;
        FacturasDAL facturas;
        OrdenesCompraDAL ordenesCompra;
        OrdenesPagoDAL ordenesPago;
        ProvinciasDAL provincias;
        LocalidadesDAL localidades;
        UsuariosDAL usuarios;
        BitacoraDAL bitacora;

        public OBMCateringDAL(OBMCateringEntities modelo)
        {
            this.modelo = modelo;
            empleados = new EmpleadosDAL(modelo);
            clientes = new ClientesDAL(modelo);
            proveedores = new ProveedoresDAL(modelo);
            recetas = new RecetasDAL(modelo);
            ingredientes = new IngredientesDAL(modelo);
            preciosIngredientes = new PreciosIngredientesDAL(modelo);
            ordenesVenta = new OrdenesVentaDAL(modelo);
            facturas = new FacturasDAL(modelo);
            ordenesCompra = new OrdenesCompraDAL(modelo);
            ordenesPago = new OrdenesPagoDAL(modelo);
            provincias = new ProvinciasDAL(modelo);
            localidades = new LocalidadesDAL(modelo);
            usuarios = new UsuariosDAL(modelo);
            bitacora = new BitacoraDAL(modelo);
        }

        public EmpleadosDAL ObtenerEmpleadosDAL()
        {
            return empleados;
        }

        public ClientesDAL ObtenerClientesDAL()
        {
            return clientes;
        }

        public ProveedoresDAL ObtenerProveedoresDAL()
        {
            return proveedores;
        }

        public RecetasDAL ObtenerRecetasDAL()
        {
            return recetas;
        }

        public IngredientesDAL ObtenerIngredientesDAL()
        {
            return ingredientes;
        }

        public PreciosIngredientesDAL ObtenerPreciosIngredientesDAL()
        {
            return preciosIngredientes;
        }

        public OrdenesVentaDAL ObtenerOrdenesVentaDAL()
        {
            return ordenesVenta;
        }

        public FacturasDAL ObtenerFacturasDAL()
        {
            return facturas;
        }

        public OrdenesCompraDAL ObtenerOrdenesCompraDAL()
        {
            return ordenesCompra;
        }

        public OrdenesPagoDAL ObtenerOrdenesPagoDAL()
        {
            return ordenesPago;
        }

        public ProvinciasDAL ObtenerProvinciasDAL()
        {
            return provincias;
        }

        public LocalidadesDAL ObtenerLocalidadesDAL()
        {
            return localidades;
        }

        public UsuariosDAL ObtenerUsuariosDAL()
        {
            return usuarios;
        }

        public BitacoraDAL ObtenerBitacoraDAL()
        {
            return bitacora;
        }

        public void Restaurar(string nombreArchivo)
        {
            string nombreBD = modelo.Database.Connection.Database;
            string script = @"RESTORE DATABASE [{0}] FROM DISK = N'{1}'";

            script = string.Format(script, nombreBD, nombreArchivo);
            modelo.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, script);
        }

        public void Backup(string nombreArchivo)
        {
            string nombreBD = modelo.Database.Connection.Database;
            string script = @"BACKUP DATABASE [{0}] TO DISK = N'{1}'";

            script = string.Format(script, nombreBD, nombreArchivo);
            modelo.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, script);
        }

        public void Guardar()
        {
            modelo.SaveChanges();
        }
    }
}
