using System;
using System.IO;
using System.Threading.Tasks;

namespace OBMCatering.Datos
{
    public class InicializadorDatos
    {
        OBMCateringEntities modelo;

        public InicializadorDatos(OBMCateringEntities modelo)
        {
            this.modelo = modelo;
        }

        public event EventHandler DatosInicializados;

        public bool EstaInicializando { get; private set; }

        public void Inicializar()
        {
            EstaInicializando = true;

            bool necesitaDatosIniciales = !modelo.Database.Exists();

            modelo.Database.CreateIfNotExists();

            if(necesitaDatosIniciales)
            {
                modelo.EstadosOrdenesCompra.Add(new EstadoOrdenCompra { Estado = "Generada" });
                modelo.EstadosOrdenesCompra.Add(new EstadoOrdenCompra { Estado = "Aprobada" });
                modelo.EstadosOrdenesCompra.Add(new EstadoOrdenCompra { Estado = "Realizada" });

                modelo.EstadosRecetas.Add(new EstadoReceta { Estado = "Activa" });
                modelo.EstadosRecetas.Add(new EstadoReceta { Estado = "Inactiva" });
                modelo.EstadosRecetas.Add(new EstadoReceta { Estado = "SinPrecio" });
                modelo.EstadosRecetas.Add(new EstadoReceta { Estado = "SinIngredientes" });

                modelo.PerfilesUsuario.Add(new PerfilUsuario { Nombre = "Admin" });
                modelo.PerfilesUsuario.Add(new PerfilUsuario { Nombre = "Cocina" });
                modelo.PerfilesUsuario.Add(new PerfilUsuario { Nombre = "Ventas" });
                modelo.PerfilesUsuario.Add(new PerfilUsuario { Nombre = "Compras" });

                modelo.TiposClientes.Add(new TipoCliente { Tipo = "Persona" });
                modelo.TiposClientes.Add(new TipoCliente { Tipo = "Empresa" });

                modelo.TiposMensajesBitacora.Add(new TipoMensajeBitacora { Tipo = "Informacion" });
                modelo.TiposMensajesBitacora.Add(new TipoMensajeBitacora { Tipo = "Alerta" });
                modelo.TiposMensajesBitacora.Add(new TipoMensajeBitacora { Tipo = "Error" });

                modelo.UnidadesMedida.Add(new UnidadMedida { Unidad = "gr" });
                modelo.UnidadesMedida.Add(new UnidadMedida { Unidad = "ml" });
                modelo.UnidadesMedida.Add(new UnidadMedida { Unidad = "u" });

                modelo.Usuarios.Add(new Usuario
                {
                    Nick = "admin",
                    Nombre = "Administrador",
                    Email = "admin@obm.com",
                    Password = "admin",
                    CambiarPassword = true, //Se requerira cambiar el password en el primer login
                    IDPerfil = 1 //Admin
                });

                modelo.SaveChanges();

                //Inicializo Provincias y Localidades en otro hilo para que no tarde en cargar el sistema la primera vez
                //Al finalizar la carga se notifica con un evento para que los que esten observando puedan saberlo
                Task.Run(() =>
                {
                    //Se debe crear otra instancia del modelo para poder ejecutar las operaciones en Base de Datos en otro hilo distinto al que se hizo antes
                    //Se encontro la solucion aqui: https://stackoverflow.com/questions/6126616/is-dbcontext-thread-safe
                    OBMCateringEntities modeloNuevoHilo = new OBMCateringEntities();

                    InicializarProvincias(modeloNuevoHilo);
                    InicializarLocalidades(modeloNuevoHilo);

                    if (DatosInicializados != null)
                    {
                        DatosInicializados(this, EventArgs.Empty);
                    }

                    EstaInicializando = false;
                });
            }
        }

        void InicializarProvincias(OBMCateringEntities modelo)
        {
            foreach(string linea in File.ReadAllLines(@"Resources\provincias.txt"))
            {
                string[] campos = linea.Split('#');
                int id = int.Parse(campos[0]);
                string nombre = campos[1];

                modelo.Provincias.Add(new Provincia { ID = id, Nombre = nombre });
            }

            modelo.SaveChanges();
        }

        void InicializarLocalidades(OBMCateringEntities modelo)
        {
            int loteCargadas = 0;

            foreach (string linea in File.ReadAllLines(@"Resources\localidades.txt"))
            {
                string[] campos = linea.Split('#');
                int id = int.Parse(campos[0]);
                string nombre = campos[1];
                int idProvincia = int.Parse(campos[2]);

                modelo.Localidades.Add(new Localidad { ID = id, Nombre = nombre, IDProvincia = idProvincia });
                loteCargadas += 1;

                if(loteCargadas == 20)
                {
                    modelo.SaveChanges();
                }
            }

            modelo.SaveChanges();
        }
    }
}
