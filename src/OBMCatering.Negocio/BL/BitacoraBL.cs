using OBMCatering.Negocio.Properties;
using System;
using System.Collections.Generic;

namespace OBMCatering.Negocio
{
    public class BitacoraBL
    {
        ContextoNegocio contexto;
        Datos.OBMCateringDAL dal;
        UsuariosBL usuariosBL;

        public BitacoraBL(ContextoNegocio contexto, UsuariosBL usuariosBL)
        {
            this.contexto = contexto;
            dal = contexto.ObtenerDatos();
            this.usuariosBL = usuariosBL;
        }

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

        public IEnumerable<Bitacora> Obtener()
        {
            Datos.BitacoraDAL dalBitacoras = dal.ObtenerBitacoraDAL();
            IEnumerable<Datos.Bitacora> bitacorasDAL = dalBitacoras.Obtener();

            return Obtener(bitacorasDAL);
        }

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
