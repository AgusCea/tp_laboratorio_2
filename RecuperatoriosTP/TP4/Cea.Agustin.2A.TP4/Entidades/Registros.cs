using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public sealed class Registros
    {
        #region "Atributos"
        public List<Venta<Pelota>> pelotasVendidas;
        public List<Venta<VideoJuego>> juegosVendidos;

        //public delegate void DelegadoEventoStock();
        //public event DelegadoEventoStock EventoStockVacio;
        #endregion

        #region "Constructores"
        public Registros()
        {
            this.pelotasVendidas = new List<Venta<Pelota>>();
            this.juegosVendidos = new List<Venta<VideoJuego>>();
        }
        #endregion
    }
}
