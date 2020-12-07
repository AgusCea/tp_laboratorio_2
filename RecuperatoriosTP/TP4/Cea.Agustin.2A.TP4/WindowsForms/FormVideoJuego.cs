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
using Excepciones;

namespace WindowsForms
{
    public partial class FormVideoJuego : Form
    {
        #region "Atributos"
        protected VideoJuego v;
        #endregion

        #region "Propiedades"
        public VideoJuego VideoJuego
        {
            get { return this.v; }
        }
        #endregion

        #region "Constructores"
        public FormVideoJuego()
        {
            InitializeComponent();
        }

        public FormVideoJuego(VideoJuego v)
            : this()
        {
            this.v = v;

            this.txtNombre.Text = v.Nombre.ToString();
            this.txtMarca.Text = v.Marca;
            this.txtPrecio.Text = v.Precio.ToString();
            this.txtStock.Text = v.Stock.ToString();
        }
        #endregion

        #region "Manejadores de Eventos"
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string strPrecio = this.txtPrecio.Text;
            string strStock = this.txtStock.Text;

            try
            {
                this.v = new VideoJuego(this.txtMarca.Text, float.Parse(strPrecio), int.Parse(strStock), this.txtNombre.Text);

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch(ProductoException ex)
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
