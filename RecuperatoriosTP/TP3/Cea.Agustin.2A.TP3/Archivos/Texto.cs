using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        #region "Métodos"
        /// <summary>
        /// Guarda el string de datos en un archivo de texto.
        /// </summary>
        /// <param name="archivos">Ruta del archivo.</param>
        /// <param name="datos">Datos a guardar.</param>
        /// <returns>true si se pudo guardar, caso contrario false.</returns>
        public bool Guardar(string archivos, string datos)
        {
            bool aux = false;
            try
            {
                using (StreamWriter writer = new StreamWriter(archivos, false, Encoding.UTF8))
                {
                    writer.WriteLine(datos);
                    aux = true;
                }
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
            return aux;
        }

        /// <summary>
        /// Lee desde un archivo de datos.
        /// </summary>
        /// <param name="archivos">Ruta del archivo.</param>
        /// <param name="datos">Datos leidos del archivo.</param>
        /// <returns>true si se pudo leer, caso contrario false</returns>
        public bool Leer(string archivos, out string datos)
        {
            bool aux = false;
            datos = string.Empty;

            try
            {
                if (File.Exists(archivos))
                {
                    using (StreamReader reader = new StreamReader(archivos))
                    {
                        datos = reader.ReadToEnd();
                        aux = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
            return aux;
        }
        #endregion
    }
}
