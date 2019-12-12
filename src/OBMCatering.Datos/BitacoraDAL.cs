using System.Collections.Generic;
using System.Linq;

namespace OBMCatering.Datos
{
    public class BitacoraDAL
    {
        OBMCateringEntities modelo;

        public BitacoraDAL(OBMCateringEntities modelo)
        {
            this.modelo = modelo;
        }

        public void Crear(Bitacora bitacora)
        {
            modelo.Bitacora.Add(bitacora);
        }

        public IEnumerable<Bitacora> Obtener()
        {
            return modelo.Bitacora.ToList();
        }

        public IEnumerable<Bitacora> Obtener(Usuario usuario)
        {
            List<Bitacora> bitacoras = new List<Bitacora>();

            foreach(Bitacora bitacora in modelo.Bitacora)
            {
                if(bitacora.Usuario != null && bitacora.Usuario.Nick == usuario.Nick)
                {
                    bitacoras.Add(bitacora);
                }
            }

            return bitacoras;
        }

        public IEnumerable<Bitacora> Obtener(TipoMensajeBitacora tipo)
        {
            List<Bitacora> bitacoras = new List<Bitacora>();

            foreach (Bitacora bitacora in modelo.Bitacora)
            {
                if (bitacora.Tipo.Tipo == tipo.Tipo)
                {
                    bitacoras.Add(bitacora);
                }
            }

            return bitacoras;
        }

        public TipoMensajeBitacora ObtenerTipo(string tipo)
        {
            TipoMensajeBitacora resultado = null;

            foreach(TipoMensajeBitacora tipoMensajeBitacora in modelo.TiposMensajesBitacora)
            {
                if(tipoMensajeBitacora.Tipo == tipo)
                {
                    resultado = tipoMensajeBitacora;
                    break;
                }
            }

            return resultado;
        }
    }
}
