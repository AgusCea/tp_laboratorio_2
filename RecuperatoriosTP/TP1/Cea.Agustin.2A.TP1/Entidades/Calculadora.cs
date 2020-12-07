using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        #region "Métodos"
        /// <summary>
        /// Verifica que el operador ingresado sea un operador valido.
        /// </summary>
        /// <param name="operador">El operador a validar</param>
        /// <returns>El operador de suma en caso de error, o el operador en si.</returns>
        private static string ValidarOperador(char operador)
        {
            string auxOperador = "+";

            if(operador == '+' || operador == '-' || operador == '/' || operador == '*')
            {
                auxOperador = Convert.ToString(operador);
            }

            return auxOperador;
        }

        /// <summary>
        /// Realiza la operacion entre dos numeros.
        /// </summary>
        /// <param name="numeroUno">El primer operando.</param>
        /// <param name="numeroDos">El segundo operando.</param>
        /// <param name="operador">El operador a ejecutar.</param>
        /// <returns>El resultado de la operacion.</returns>
        public static double Operar(Numero num1, Numero num2, char operador)
        {
            double resultado = double.MinValue;

            switch (ValidarOperador(operador))
            {
                case "+":
                    resultado = num1 + num2;
                    break;

                case "-":
                    resultado = num1 - num2;
                    break;

                case "*":
                    resultado = num1 * num2;
                    break;

                case "/":
                    resultado = num1 / num2;
                    break;
            }

            return resultado;
        }
        #endregion
    }
}
