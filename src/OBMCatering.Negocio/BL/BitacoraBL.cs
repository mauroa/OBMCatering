using OBMCatering.Negocio.Properties;
using System;
using System.Collections.Generic;

namespace OBMCatering.Negocio
{
    /// <summary>
    /// Reponsable de manejar los eventos del sistema dentro de la capa de negocio del mismo
    /// </summary>
    public class BitacoraBL
    {
        ContextoNegocio contexto;
        Datos.OBMCateringDAL dal;
        UsuariosBL usuariosBL;

        /// <summary>
        /// Crea una nueva instancia de <see cref="BitacoraBL"/>
        /// </summary>
        /// <param name="contexto">Contexto de negocio</param>
        /// <param name="usuariosBL">Capa de negocio de usuarios</param>
        public BitacoraBL(ContextoNegocio contexto, UsuariosBL usuariosBL)
        {
            this.contexto = contexto;
            dal = contexto.ObtenerDatos();
            this.usuariosBL = usuariosBL;
        }

        /// <summary>
        /// Registra un nuevo evento en el sistema
        /// </summary>
        /// <param name="mensaje">Mensaje del evento</param>
        /// <param name="tipo">Tipo de evento</param>
        public void Registrar(string mensaje, TipoMensajeBitacora tipo)
        {
            if(string.IsNullOrEmpty(mensaje))
            {
                throw new OBMCateringException(Resources.BitacoraBL_Validaciones_MensajeNull);
            }

            Datos.BitacoraDAL dalBitacoras = dal.ObtenerBitacoraDAL();
            Datos.TipoMensajeBitacora tipoMensajeDAL = dalBitacoras.ObtenerTipo(tipo.ToString());

            if (tipoMensajeDAL == null)
            {
                throw new OBMCateringException(string.Format(Resources.BitacoraBL_Validaciones_TipoInvalido, tipo));
            }

            Usuario usuarioAutenticado = contexto.ObtenerUsuarioAutenticado();
            Datos.Usuario usuarioDAL = null;

            if (usuarioAutenticado != null)
            {
                Datos.UsuariosDAL dalUsuarios = dal.ObtenerUsuariosDAL();

                usuarioDAL = dalUsuarios.Obtener(usuarioAutenticado.Nick);
            }

            Datos.Bitacora bitacoraDAL = new Datos.Bitacora
            {
                Fecha = DateTime.Now,
                Mensaje = mensaje,
                Tipo = tipoMensajeDAL,
                Usuario = usuarioDAL
            };

            dalBitacoras.Crear(bitacoraDAL);
            dal.Guardar();
        }

        /// <summary>
        /// Obtiene todos los eventos registrados en el sistema
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Bitacora> Obtener()
        {
            Datos.BitacoraDAL dalBitacoras = dal.ObtenerBitacoraDAL();
            IEnumerable<Datos.Bitacora> bitacorasDAL = dalBitacoras.Obtener();

            return Obtener(bitacorasDAL);
        }

        /// <summary>
        /// Obtiene los eventos registrados en el sistema para un usuario especifico
        /// </summary>
        /// <param name="usuario">Usuario para el cual se quieren obtener los eventos</param>
        /// <returns>Eventos encontrados</returns>
        public IEnumerable<Bitacora> Obtener(Usuario usuario)
        {
            if(usuario == null)
            {
                throw new OBMCateringException(Resources.BitacoraBL_Validaciones_UsuarioNull);
            }

            Datos.UsuariosDAL dalUsuarios = dal.ObtenerUsuariosDAL();
            Datos.Usuario usuarioDAL = dalUsuarios.Obtener(usuario.Nick);

            if(usuarioDAL == null)
            {
                throw new OBMCateringException(string.Format(Resources.BitacoraBL_Validaciones_UsuarioInvalido, usuario.Nick));
            }

            Datos.BitacoraDAL dalBitacoras = dal.ObtenerBitacoraDAL();
            IEnumerable<Datos.Bitacora> bitacorasDAL = dalBitacoras.Obtener(usuarioDAL);

            return Obtener(bitacorasDAL);
        }

        /// <summary>
        /// Obtiene los eventos registrados en el sistema para un determinado tipo
        /// </summary>
        /// <param name="tipo">Tipo de evento para filtrar el resultado</param>
        /// <returns>Eventos encontrados</returns>
        public IEnumerable<Bitacora> Obtener(TipoMensajeBitacora tipo)
        {
            Datos.BitacoraDAL dalBitacoras = dal.ObtenerBitacoraDAL();
            Datos.TipoMensajeBitacora tipoMensajeDAL = dalBitacoras.ObtenerTipo(tipo.ToString());

            if (tipoMensajeDAL == null)
            {
                throw new OBMCateringException(string.Format(Resources.BitacoraBL_Validaciones_TipoInvalido, tipo));
            }

            IEnumerable<Datos.Bitacora> bitacorasDAL = dalBitacoras.Obtener(tipoMensajeDAL);

            return Obtener(bitacorasDAL);
        }

        IEnumerable<Bitacora> Obtener(IEnumerable<Datos.Bitacora> bitacorasDAL)
        {
            List<Bitacora> bitacoras = new List<Bitacora>();

            foreach (Datos.Bitacora bitacoraDAL in bitacorasDAL)
            {
                Bitacora bitacora = Obtener(bitacoraDAL);

                bitacoras.Add(bitacora);
            }

            return bitacoras;
        }

        Bitacora Obtener(Datos.Bitacora bitacoraDAL)
        {
            TipoMensajeBitacora tipo = (TipoMensajeBitacora)Enum.Parse(typeof(TipoMensajeBitacora), bitacoraDAL.Tipo.Tipo);
            Usuario usuario = null;

            if(bitacoraDAL.Usuario != null)
            {
                usuario = usuariosBL.Obtener(bitacoraDAL.Usuario);
            }

            return new Bitacora
            {
                Id = bitacoraDAL.ID,
                Fecha = bitacoraDAL.Fecha,
                Mensaje = bitacoraDAL.Mensaje,
                Tipo = tipo,
                Usuario = usuario
            };
        }
    }
}
