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

        public void Crear(string mensaje, TipoMensajeBitacora tipo)
        {
            Usuario usuarioAutenticado = contexto.ObtenerUsuarioAutenticado();
            Datos.UsuariosDAL dalUsuarios = dal.ObtenerUsuariosDAL();
            Datos.Usuario usuarioDAL = dalUsuarios.Obtener(usuarioAutenticado.Nick);
            Datos.BitacoraDAL dalBitacoras = dal.ObtenerBitacoraDAL();
            Datos.TipoMensajeBitacora tipoMensajeDAL = dalBitacoras.ObtenerTipo(tipo.ToString());
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
            Datos.UsuariosDAL dalUsuarios = dal.ObtenerUsuariosDAL();
            Datos.Usuario usuarioDAL = dalUsuarios.Obtener(usuario.Nick);
            Datos.BitacoraDAL dalBitacoras = dal.ObtenerBitacoraDAL();
            IEnumerable<Datos.Bitacora> bitacorasDAL = dalBitacoras.Obtener(usuarioDAL);

            return Obtener(bitacorasDAL);
        }

        public IEnumerable<Bitacora> Obtener(TipoMensajeBitacora tipo)
        {
            Datos.BitacoraDAL dalBitacoras = dal.ObtenerBitacoraDAL();
            Datos.TipoMensajeBitacora tipoMensajeDAL = dalBitacoras.ObtenerTipo(tipo.ToString());
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
            Usuario usuario = usuariosBL.Obtener(bitacoraDAL.Usuario);

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
