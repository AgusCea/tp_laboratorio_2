using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public sealed class Venta<T> 
        where T: Producto
    {
        #region "Atributos"
        private static int porcentajeIva;
        private DateTime fecha;
        private T producto;
        private float precioFinal;
        private int cantidad;
        #endregion

        #region "Propiedades"
        public static int PorcentajeIva
        {
            get { return Venta<T>.PorcentajeIva; }
            set { Venta<T>.PorcentajeIva = porcentajeIva; }
        }

        public int Cantidad
        {
            get { return this.cantidad; }
            set { this.cantidad = value; }
        }

        public T Producto
        {
            get { return this.producto; }
            set { this.producto = value; }
        }

        public DateTime Fecha
        {
            get { return this.fecha; }
            set { this.fecha = value; }
        }

        public float PrecioFinal
        {
            get { return this.precioFinal; }
            set { this.precioFinal = value; }
        }
        #endregion

        #region "Constructores"
        static Venta()
        {
            Venta<T>.porcentajeIva = 21;
        }

        public Venta()
        {

        }

        public Venta(T producto, int cantidad)
        {
            this.producto = producto;
            this.cantidad = cantidad;
            this.Vender();
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Asigna precio total y hora de venta, tambien actualiza el stock del producto.
        /// </summary>
        public void Vender()
        {
            producto.Stock -= this.cantidad;
            this.fecha = DateTime.Now;
            this.precioFinal = Venta<T>.CalcularPrecioFinal(this.producto.Precio, this.cantidad);
        }

        /// <summary>
        /// Devuelve precio total conciderando la cantidad de unidades y porcentaje de iva.
        /// </summary>
        /// <param name="precioUnidad"></param>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        public static float CalcularPrecioFinal(float precioUnidad, int cantidad)
        {
            float precioSinIva = precioUnidad * cantidad;
            return precioSinIva + precioSinIva * Venta<T>.porcentajeIva / 100;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("FECHA: {0}\n", this.fecha.ToString());
            sb.Append(this.producto.ToString());
            sb.AppendFormat("CANTIDAD VENDIDA: {0} - ", this.cantidad);
            sb.AppendFormat("PRECIO FINAL: {0}\n", this.precioFinal);

            return sb.ToString();
        }
        #endregion
    }
}
