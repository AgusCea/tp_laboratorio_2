using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class VideoJuego : Producto
    {
        #region "Atributos"
        private string nombre;
        #endregion

        #region "Propiedades"
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        #endregion

        #region "Constructores"
        public VideoJuego()
            : base()
        {

        }

        public VideoJuego(string marca, float precio, int stock, string nombre)
            : base(marca, precio, stock)
        {
            this.nombre = nombre;
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Devuelve los datos del juego.
        /// </summary>
        /// <returns></returns>
        protected override string ProductoToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Videojuego de nombre... ");
            sb.AppendFormat("{0}\n", this.nombre);
            sb.AppendLine(base.ProductoToString());

            return sb.ToString();
        }
        #endregion
    }
}
