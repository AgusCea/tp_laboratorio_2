using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T> where T : class
    {
        #region "Métodos"
        /// <summary>
        /// Serializa los datos a formato XML.
        /// </summary>
        /// <param name="archivos">Ruta del archivo.</param>
        /// <param name="datos">Datos a serializar.</param>
        /// <returns>true si se pudo serializar, caso contrario false.</returns>
        public bool Guardar(string archivos, T datos)
        {
            bool aux = false;
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivos, Encoding.UTF8))
                {
                    writer.Formatting = Formatting.Indented;
                    XmlSerializer serializaer = new XmlSerializer(typeof(T));
                    serializaer.Serialize(writer, datos);
                    aux = true;
                }
                return aux;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
        }

        /// <summary>
        /// Deserializa los datos de un archivo XML.
        /// </summary>
        /// <param name="archivos">Ruta del archivo.</param>
        /// <param name="datos">Datos deserializados.</param>
        /// <returns>true si se pudo deserializar, caso contrario false.</returns>
        public bool Leer(string archivos, out T datos)
        {
            bool aux = false;
            datos = default;
            try
            {
                if (File.Exists(archivos))
                {
                    using (XmlTextReader reader = new XmlTextReader(archivos))
                    {
                        XmlSerializer serializaer = new XmlSerializer(typeof(T));
                        if (serializaer.CanDeserialize(reader))
                        {
                            datos = (T)serializaer.Deserialize(reader);
                            aux = true;
                        }
                    }
                }
                return aux;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
        }
        #endregion
    }
}
