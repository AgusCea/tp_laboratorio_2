using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Clases_Instanciables.Universidad;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        #region "Atributos"
        private List<Alumno> alumnos;
        private EClases clase;
        private Profesor instructor;
        #endregion

        #region "Propiedades"
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }

        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }
        #endregion

        #region "Constructores"
        public Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(EClases clase, Profesor instructor)
            : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region "Métodos"
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CLASE DE {0} POR ", this.clase);
            sb.AppendLine(this.instructor.ToString());
            sb.AppendLine("ALUMNOS:");
            foreach(Alumno item in this.alumnos)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Guarda la jornada en un archivo de texto.
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>true si se pudo guardar, caso contrario false.</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();

            return texto.Guardar("Jornada.txt", jornada.ToString()); ;
        }

        /// <summary>
        /// Lee la jornada desde un archivo de texto.
        /// </summary>
        /// <returns>true si se pudo leer, caso contrario false.</returns>
        public static string Leer()
        {
            string datosJornada = string.Empty;
            Texto texto = new Texto();

            texto.Leer("Jornada.txt", out datosJornada);
            return datosJornada;
        }
        #endregion

        #region "Sobrecarga de operadores"
        /// <summary>
        /// Verifica que el alumno participa de la jornada.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return (a == j.clase);
        }

        /// <summary>
        /// Verifica que el alumno NO participa de la jornada.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un alumno a la jornada si antes no formaba parte de ella.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j != a)
            {
                j.alumnos.Add(a);
            }
            return j;
        }
        #endregion
    }
}
