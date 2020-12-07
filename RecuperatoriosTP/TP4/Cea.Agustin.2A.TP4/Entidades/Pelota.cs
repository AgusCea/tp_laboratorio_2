using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pelota : Producto
    {
        #region "Enumerados"
        public enum EDeporte
        {
            Futbol, Basquet, Rugby, Voley
        }
        #endregion

        #region "Atributos"
        private EDeporte deporte;
        #endregion

        #region "Propiedades"
        public EDeporte Deporte
        {
            get { return this.deporte; }
            set { this.deporte = value; }
        }
        #endregion

        #region "Constructores"
        public Pelota()
            : base()
        {

        }

        public Pelota(string marca, float precio, int stock, EDeporte deporte)
            : base(marca, precio, stock)
        {
            this.deporte = deporte;
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Devuelve los datos de la Pelota.
        /// </summary>
        /// <returns></returns>
        protected override string ProductoToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Pelota de {0} ", this.deporte);
            sb.AppendLine(base.ProductoToString());

            return sb.ToString();
        }
        #endregion
    }
}
