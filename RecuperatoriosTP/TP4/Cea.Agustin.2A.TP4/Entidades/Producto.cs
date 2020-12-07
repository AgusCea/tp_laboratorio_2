using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Entidades
{
    public abstract class Producto
    {
        #region "Atributos"
        private string marca;
        private float precio;
        private int stock;
        #endregion

        #region "Propiedades"
        public string Marca
        {
            get { return this.marca; }
            set { this.marca = value; }
        }

        public float Precio
        {
            get { return this.precio; }
            set { this.precio = this.ValidarPrecio(value); }
        }

        public int Stock
        {
            get { return this.stock; }
            set { this.stock = this.ValidarStock(value); }
        }
        #endregion

        #region "Constructores"
        public Producto()
        {

        }

        public Producto(string marca, float precio, int stock)
        {
            this.marca = marca;
            this.Precio = precio;
            this.Stock = stock;
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Devuelve los datos del producto.
        /// </summary>
        /// <returns></returns>
        protected virtual string ProductoToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("MARCA: {0}\n", this.marca);
            sb.AppendFormat("PRECIO: {0} - STOCK: {1}",this.precio, this.stock);

            return sb.ToString();
        }

        /// <summary>
        /// Valida que el precio ingresado sea mayor a 0.
        /// </summary>
        /// <param name="precio"></param>
        /// <returns></returns>
        private float ValidarPrecio(float precio)
        {
            if (precio <= 0)
                throw new ProductoException();

            return precio;
        }

        /// <summary>
        /// Valida que el stock ingresado sea mayor a 0.
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        private int ValidarStock(int stock)
        {
            if (stock < 1)
                throw new ProductoException();

            return stock;
        }

        public override string ToString()
        {
            return this.ProductoToString();
        }
        #endregion
    }
}
