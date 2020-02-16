using System;
using System.Data.Entity;

namespace OBMCatering.Datos
{
    /// <summary>
    /// Representa la capa de acceso a datos del sistema, centralizando cada clase de acceso a datos (DAL)
    /// para poder accederla desde un lugar comun
    /// </summary>
    public class OBMCateringDAL
    {
        OBMCateringEntities modelo;
        InicializadorDatos inicializador;
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

            inicializador = new InicializadorDatos(modelo);
            inicializador.DatosInicializados += Inicializador_DatosInicializados;
            inicializador.Inicializar();
        }

        /// <summary>
        /// Evento que sirve para notificar cuando la carga inicial de datos ha sido finalizada
        /// </summary>
        public event EventHandler DatosInicializados;

        /// <summary>
        /// Valor que indica si el sistema esta inicializando sus datos por primera vez o no
        /// </summary>
        public bool EstaInicializando
        {
            get
            {
                return inicializador.EstaInicializando;
            }
        }

        /// <summary>
        /// Devuelve al responsable de manejar los empleados dentro de la capa de acceso a datos del sistema
        /// </summary>
        /// <returns>La DAL de empleados</returns>
        public EmpleadosDAL ObtenerEmpleadosDAL()
        {
            return empleados;
        }

        /// <summary>
        /// Devuelve al responsable de manejar los clientes dentro de la capa de acceso a datos del sistema
        /// </summary>
        /// <returns>La DAL de clientes</returns>
        public ClientesDAL ObtenerClientesDAL()
        {
            return clientes;
        }

        /// <summary>
        /// Devuelve al responsable de manejar los proveedores dentro de la capa de acceso a datos del sistema
        /// </summary>
        /// <returns>La DAL de proveedores</returns>
        public ProveedoresDAL ObtenerProveedoresDAL()
        {
            return proveedores;
        }

        /// <summary>
        /// Devuelve al responsable de manejar las recetas dentro de la capa de acceso a datos del sistema
        /// </summary>
        /// <returns>La DAL de recetas</returns>
        public RecetasDAL ObtenerRecetasDAL()
        {
            return recetas;
        }

        /// <summary>
        /// Devuelve al responsable de manejar los ingredientes dentro de la capa de acceso a datos del sistema
        /// </summary>
        /// <returns>La DAL de ingredientes</returns>
        public IngredientesDAL ObtenerIngredientesDAL()
        {
            return ingredientes;
        }

        /// <summary>
        /// Devuelve al responsable de manejar los precios de los ingredientes dentro de la capa de acceso a datos del sistema
        /// </summary>
        /// <returns>La DAL de precios de ingredientes</returns>
        public PreciosIngredientesDAL ObtenerPreciosIngredientesDAL()
        {
            return preciosIngredientes;
        }

        /// <summary>
        /// Devuelve al responsable de manejar las ordenes de venta dentro de la capa de acceso a datos del sistema
        /// </summary>
        /// <returns>La DAL de ordenes de venta</returns>
        public OrdenesVentaDAL ObtenerOrdenesVentaDAL()
        {
            return ordenesVenta;
        }

        /// <summary>
        /// Devuelve al responsable de manejar las facturas dentro de la capa de acceso a datos del sistema
        /// </summary>
        /// <returns>La DAL de facturas</returns>
        public FacturasDAL ObtenerFacturasDAL()
        {
            return facturas;
        }

        /// <summary>
        /// Devuelve al responsable de manejar las ordenes de compra dentro de la capa de acceso a datos del sistema
        /// </summary>
        /// <returns>La DAL de ordenes de compra</returns>
        public OrdenesCompraDAL ObtenerOrdenesCompraDAL()
        {
            return ordenesCompra;
        }

        /// <summary>
        /// Devuelve al responsable de manejar las ordenes de pago dentro de la capa de acceso a datos del sistema
        /// </summary>
        /// <returns>La DAL de ordenes de pago</returns>
        public OrdenesPagoDAL ObtenerOrdenesPagoDAL()
        {
            return ordenesPago;
        }

        /// <summary>
        /// Devuelve al responsable de manejar las provincias dentro de la capa de acceso a datos del sistema
        /// </summary>
        /// <returns>La DAL de provincias</returns>
        public ProvinciasDAL ObtenerProvinciasDAL()
        {
            return provincias;
        }

        /// <summary>
        /// Devuelve al responsable de manejar las localidades dentro de la capa de acceso a datos del sistema
        /// </summary>
        /// <returns>La DAL de localidades</returns>
        public LocalidadesDAL ObtenerLocalidadesDAL()
        {
            return localidades;
        }

        /// <summary>
        /// Devuelve al responsable de manejar los usuarios dentro de la capa de acceso a datos del sistema
        /// </summary>
        /// <returns>La DAL de usuarios</returns>
        public UsuariosDAL ObtenerUsuariosDAL()
        {
            return usuarios;
        }

        /// <summary>
        /// Devuelve al responsable de manejar la bitacora dentro de la capa de acceso a datos del sistema
        /// </summary>
        /// <returns>La DAL de bitacora</returns>
        public BitacoraDAL ObtenerBitacoraDAL()
        {
            return bitacora;
        }

        /// <summary>
        /// Permite restaurar la base de datos desde un archivo dado
        /// </summary>
        /// <param name="nombreArchivo">Archivo para restaurar la base de datos</param>
        public void Restaurar(string nombreArchivo)
        {
            string nombreBD = modelo.Database.Connection.Database;
            string script = @"RESTORE DATABASE [{0}] FROM DISK = N'{1}'";

            script = string.Format(script, nombreBD, nombreArchivo);
            modelo.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, script);
        }

        /// <summary>
        /// Permite hacer backup de la base de datos a un archivo dado
        /// </summary>
        /// <param name="nombreArchivo">Archivo para crear el backup</param>
        public void Backup(string nombreArchivo)
        {
            string nombreBD = modelo.Database.Connection.Database;
            string script = @"BACKUP DATABASE [{0}] TO DISK = N'{1}'";

            script = string.Format(script, nombreBD, nombreArchivo);
            modelo.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, script);
        }

        /// <summary>
        /// Guarda los cambios realizados en la capa de acceso a datos
        /// Esto implica que todos los cambios relaizados seran guardados en la base de datos asociada
        /// </summary>
        public void Guardar()
        {
            modelo.SaveChanges();
        }

        void Inicializador_DatosInicializados(object sender, EventArgs e)
        {
            if (DatosInicializados != null)
            {
                DatosInicializados(this, EventArgs.Empty);
            }
        }
    }
}
