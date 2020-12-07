using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region "Enumerados"
        public enum ENacionalidad
        { 
            Argentino, Extranjero 
        }
        #endregion

        #region "Atributos"
        private string apellido;
        private string nombre;
        private int dni;
        ENacionalidad nacionalidad;
        #endregion

        #region "Propiedades"

        public string Nombre
        {
            set { this.nombre = Persona.ValidarNombreApellido(value); }
            get { return this.nombre; }
        }

        public string Apellido
        {
            set { this.apellido = Persona.ValidarNombreApellido(value); }
            get { return this.apellido; }
        }

        public int DNI
        {
            set { this.dni = Persona.ValidarDni(this.Nacionalidad, value); }
            get { return this.dni; }
        }

        public ENacionalidad Nacionalidad
        {
            set { this.nacionalidad = value; }
            get { return this.nacionalidad; }
        }

        public string StringToDNI
        {
            set { this.dni = Persona.ValidarDni(this.Nacionalidad, value); }
        }
        #endregion

        #region "Constructores"
        public Persona()
        {
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Devuelve los datos de una persona.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.apellido, this.nombre);
            sb.AppendFormat("NACIONALIDAD: {0}\n", this.nacionalidad);

            return sb.ToString();
        }

        /// <summary>
        /// Valida el DNI en base a la nacionalidad.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private static int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 89999999)
                        throw new NacionalidadInvalidaException();
                    break;
                case ENacionalidad.Extranjero:
                    if (dato < 90000000 || dato > 99999999)
                        throw new NacionalidadInvalidaException();
                    break;
            }
            return dato;
        }

        /// <summary>
        /// Valida el DNI en base a la nacionalidad.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private static int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            dato = dato.Replace(".", "");

            if (dato.Length < 1 || dato.Length > 8)
                throw new DniInvalidoException();

            int auxDni;
            try
            {
                auxDni = Int32.Parse(dato);
            }
            catch (Exception e)
            {
                throw new DniInvalidoException(e);
            }

            return Persona.ValidarDni(nacionalidad, auxDni);
        }

        /// <summary>
        /// Valida el nombre.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private static string ValidarNombreApellido(string dato)
        {
            Regex regex = new Regex("[a-zA-Z]{2,20}");
            string auxNombre = string.Empty;

            if (!string.IsNullOrEmpty(dato) && regex.IsMatch(dato))
                auxNombre = dato;

            return auxNombre;
        }
        #endregion
    }
}
