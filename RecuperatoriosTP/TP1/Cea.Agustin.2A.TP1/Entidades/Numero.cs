using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Entidades
{
    public class Numero
    {
        #region "Atributos"
        private double numero;
        #endregion

        #region "Propiedades"
        public string SetNumero
        {
            set { this.numero = ValidarNumero(value); }
        }
        #endregion

        #region "Constructores"
        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Valida si un string se puede parsear a double.
        /// </summary>
        /// <param name="strNumero">El string a parsear.</param>
        /// <returns>Cero en caso de error, sino el numero parseado.</returns>
        private double ValidarNumero(string strNumero)
        {
            double doubleNumero = 0;

            if(double.TryParse(strNumero, out doubleNumero))
            {
                doubleNumero = double.Parse(strNumero);
            }

            return doubleNumero;
        }

        /// <summary>
        /// Verifica si un string contiene solo ceros y unos.
        /// </summary>
        /// <param name="numero">El numero a verificar.</param>
        /// <returns>true si es un string de numero binario; caso contrario false.</returns>
        private bool EsBinario(string binario)
        {
            Regex regex = new Regex("[0-1]");

            return (regex.IsMatch(binario) && !binario.Contains(","));
        }

        /// <summary>
        /// Convierte un numero binario a decimal.
        /// </summary>
        /// <param name="binario">El numero binario a convertir.</param>
        /// <returns>numero decimal de ser posible, sino un mensaje de error.</returns>
        public string BinarioDecimal(string binario)
        {
            string strBinario = "Valor invalido";

            if(EsBinario(binario))
            {
                strBinario = Convert.ToInt32(binario, 2).ToString();
            }

            return strBinario;
        }

        /// <summary>
        /// Convierte a numero binario la parte entera de un numero flotante.
        /// </summary>
        /// <param name="numero">El numero a convertir.</param>
        /// <returns>El numero binario de ser posible, sino un mensaje de error.</returns>
        public string DecimalBinario(double numero)
        {
            int aux;
            string retorno = "Valor Invalido";

            if(!Double.IsNaN(numero))
            {
                aux = (int)Math.Abs(numero);
                retorno = Convert.ToString(aux, 2);
            }
            return retorno;
        }

        /// <summary>
        /// Convierte a numero binario un string.
        /// </summary>
        /// <param name="strNumero">El numero a convertir.</param>
        /// <returns>El numero binario de ser posible, sino un mensaje de error.</returns>
        public string DecimalBinario(string strNumero)
        {
            double aux;
            string retorno = "Valor Invalido";
            if(Double.TryParse(strNumero, out aux))
            {
                retorno = DecimalBinario(aux);
            }
            return retorno;
        }
        #endregion

        #region Sobrecarga de Operadores
        public static double operator +(Numero num1, Numero num2)
        {
            return num1.numero + num2.numero;
        }
        public static double operator -(Numero num1, Numero num2)
        {
            return num1.numero - num2.numero;
        }

        public static double operator *(Numero num1, Numero num2)
        {
            return num1.numero * num2.numero;
        }

        public static double operator /(Numero num1, Numero num2)
        {
            double aux = double.MinValue;

            if(num1.numero != 0 && num2.numero != 0)
            {
                aux = num1.numero / num2.numero;
            }
            return aux;
        }
        #endregion
    }
}
