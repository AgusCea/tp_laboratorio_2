using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Universidad
    {
        #region "Enumerados"
        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }
        #endregion

        #region "Atributos"
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region "Propiedades"
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }

        public Jornada this[int i]
        {
            get { return this.jornada[i]; }
            set { this.jornada[i] = value; }
        }
        #endregion

        #region "Constructores"
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Devuelve los datos de una universidad.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA: ");
            foreach (Jornada item in uni.Jornadas)
            {
                sb.Append(item.ToString());
                sb.AppendLine("<------------------------------------------------------>\n");
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Serializa los datos de la universidad en formato XML
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();

            return xml.Guardar("Universidad.xml", uni);
        }

        /// <summary>
        /// Deserializa los datos de la universidad desde formato XML.
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            Universidad aux;

            xml.Leer("Universidad.xml", out aux);

            return aux;
        }
        #endregion

        #region "Sobrecarga de operadores"
        /// <summary>
        /// Verifica que el alumno esta en la universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool aux = false;

            foreach (Alumno item in g.alumnos)
            {
                if (item == a)
                {
                    aux = true;
                    break;
                }
            }
            return aux;
        }

        /// <summary>
        /// Verifica que el profesor esta en la universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool aux = false;

            foreach (Profesor item in g.Instructores)
            {
                if (item == i)
                {
                    aux = true;
                    break;
                }
            }
            return aux;
        }

        /// <summary>
        /// Devuelve el primer profesor en la universidad capaz de dar la clase.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor auxProfesor = null;
            bool flag = false;

            foreach (Profesor item in u.profesores)
            {
                if (item == clase)
                {
                    auxProfesor = item;
                    flag = true;
                    break;
                }
            }
            if (flag == false)
                throw new SinProfesorException();

            return auxProfesor;
        }

        /// <summary>
        /// Verifica que el alumno NO esta en la universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Verifica que el profesor NO esta en la universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Devuelve el primer profesor en la universidad que NO pueda dar la clase.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor auxProfesor = null;

            foreach (Profesor item in u.profesores)
            {
                if (item != clase)
                {
                    auxProfesor = item;
                    break;
                }
            }
            return auxProfesor;
        }

        /// <summary>
        /// Agrega una nueva jornada con la clase, un profesor capaz de dar dicha clase y los alumnos que la toman.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor profesor = g == clase;
            Jornada jornada = new Jornada(clase, profesor);

            foreach (Alumno item in g.alumnos)
            {
                if (item == clase)
                {
                    jornada.Alumnos.Add(item);
                }
            }

            g.jornada.Add(jornada);
            return g;
        }

        /// <summary>
        /// Agrega un alumno a la universidad.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if(u != a)
            {
                u.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return u;
        }

        /// <summary>
        /// Agrega un profesor a la universidad.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.profesores.Add(i);
            }
            return u;
        }
        #endregion
    }
}
