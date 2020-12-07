using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        #region "Constructores"
        public ArchivosException(Exception innerException) 
            : base("Manejo de archivos fallo por las siguientes causas: " + innerException.Message, innerException)
        {
        }
        #endregion
    }
}
