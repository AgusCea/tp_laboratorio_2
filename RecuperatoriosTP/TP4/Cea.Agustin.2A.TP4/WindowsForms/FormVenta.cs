using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace WindowsForms
{
    public partial class FormVenta<T> : Form
        where T: Producto
    {
        #region "Atributos"
        protected T producto;
        protected Venta<T> venta;
        #endregion

        #region "Propiedades"
        public T Producto
        {
            get { return this.producto; }
        }

        public Venta<T> Venta
        {
            get { return this.venta; }
        }
        #endregion

        #region "Constructores"
        public FormVenta(T producto)
        {
            InitializeComponent();
            this.producto = producto;
        }
        #endregion

        #region "Manejadores de eventos"
        private void FormVenta_Load(object sender, EventArgs e)
        {
            this.lblDescripcion.Text = producto.ToString();
            this.ActualizarPrecio();
        }

        private void numericUpDownCantidad_ValueChanged(object sender, EventArgs e)
        {
            ActualizarPrecio();
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            int cantidadSeleccionada = Convert.ToInt32(this.numericUpDownCantidad.Value);

            if (producto.Stock >= cantidadSeleccionada)
            {
                this.venta = new Venta<T>(this.producto, cantidadSeleccionada);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("La cantidad indicada supera el stock disponible. Por favor, disminuya la cantidad.", "Stock Superado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region "Métodos privados"
        private void ActualizarPrecio()
        {
            int cantidadSeleccionada = Convert.ToInt32(this.numericUpDownCantidad.Value);
            double nuevoPrecioFinal = Venta<T>.CalcularPrecioFinal(this.producto.Precio, cantidadSeleccionada);
            this.lblPrecioFinal.Text = String.Format("Precio Final: ${0:0.00}", nuevoPrecioFinal);
        }
        #endregion


    }
}
