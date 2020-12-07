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

namespace MiClaculadora
{
    public partial class FormCalculadora : Form
    {
        #region "Constructores"
        public FormCalculadora()
        {
            InitializeComponent();

            List<object> operadores = new List<object>()
            {
                new {Operador='+' },
                new {Operador='/' },
                new {Operador='*' },
                new {Operador='-' },
            };
            cmbOperador.DataSource = operadores;
            cmbOperador.ValueMember = "Operador";
            cmbOperador.DisplayMember = "Operador";
        }
        #endregion

        #region "Manejadores de Eventos"
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string num1 = txtNumero1.Text;
            string num2 = txtNumero2.Text;
            string operador = cmbOperador.Text;

            if (!string.IsNullOrEmpty(num1) && !string.IsNullOrEmpty(num2) && !string.IsNullOrEmpty(cmbOperador.Text))
            {
                lblResultado.Text = Operar(num1, num2, operador).ToString();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblResultado.Text))
            {
                Numero auxResultado = new Numero(lblResultado.Text);
                lblResultado.Text = auxResultado.DecimalBinario(lblResultado.Text);
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblResultado.Text))
            {
                Numero auxResultado = new Numero(lblResultado.Text);
                lblResultado.Text = auxResultado.BinarioDecimal(lblResultado.Text); ;
            }
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Realiza la operación dada entre los dos números y devuelve el resultado.
        /// </summary>
        /// <param name="numeroUno">Primer numero</param>
        /// <param name="numeroDos">Segundo numero</param>
        /// <param name="operador">Operación a realizar.</param>
        /// <returns>El resultado de la operación entre los dos números.</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            return Calculadora.Operar(new Numero(numero1), new Numero(numero2), Convert.ToChar(operador));
        }

        /// <summary>
        /// Limpia los cuadros de texto, el label del resultado y deja el combobox con el primer operador.
        /// </summary>
        private void Limpiar()
        {
            this.lblResultado.Text = "";
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.Text = "";
        }
        #endregion
    }
}
