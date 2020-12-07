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
using static Entidades.Pelota;
using Excepciones;

namespace WindowsForms
{
    public partial class FormPelota : Form
    {
        #region "Atributos"
        protected Pelota p;
        #endregion

        #region "Propiedades"
        public Pelota Pelota
        {
            get { return this.p; }
        }
        #endregion

        #region "Constructores"
        public FormPelota()
        {
            InitializeComponent();
        }

        public FormPelota(Pelota p) 
            : this()
        {
            this.p = p;

            this.txtDeporte.Text = p.Deporte.ToString();
            this.txtMarca.Text = p.Marca;
            this.txtPrecio.Text = p.Precio.ToString();
            this.txtStock.Text = p.Stock.ToString();
        }
        #endregion

        #region "Mandejadores de Eventos"
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string strPrecio = this.txtPrecio.Text;
            string strStock = this.txtStock.Text;
            string strDeporte = this.txtDeporte.Text;
            EDeporte auxDeporte;

            try
            {
                if (Enum.TryParse<EDeporte>(strDeporte, out auxDeporte))
                {
                    throw new ProductoException();
                }

                this.p = new Pelota(this.txtMarca.Text, float.Parse(strPrecio), int.Parse(strStock), (EDeporte)Enum.Parse(typeof(EDeporte), strDeporte, true));

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (ProductoException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        #endregion
    }
}
