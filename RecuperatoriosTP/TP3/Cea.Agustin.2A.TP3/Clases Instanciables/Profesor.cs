using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using static Clases_Instanciables.Universidad;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        #region "Atributos"
        private Queue<EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region "Constructores"
        public Profesor()
        {
        }

        static Profesor()
        {
            Profesor.random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<EClases>();
            this._randomClases();
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Asigna al profesor dos clases aleatoriamente.
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                int clase = random.Next(0, 3);
                this.clasesDelDia.Enqueue((EClases)clase);
            }
        }

        /// <summary>
        /// Devuelve los datos del profesor.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.Append(ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Devuelve las clases que da el profesor.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DIA: ");
            foreach (EClases item in this.clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region "Sobrecarga de operadores"
        /// <summary>
        /// Verifica que el profesor da la clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, EClases clase)
        {
            bool aux = false;

            foreach(EClases item in i.clasesDelDia)
            {
                if (item == clase)
                {
                    aux = true;
                    break;
                }
            }

            return aux;
        }

        /// <summary>
        /// Verifica que el profesor NO da la clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}
