using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Entidades
{
    public static class Extension
    {
        /// <summary>
        /// Devuelve motivo de la excepcion producida al trabajar con archivos.
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string RazonException(this ArchivosException ex)
        {
            return ex.Message;
        }
    }
}
