using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ProductoException : Exception
    {
        #region "Constructores"
        public ProductoException()
            : base("Los datos del producto no son validos.")
        {
        }

        public ProductoException(Exception innerException)
            : base("Los datos del producto no son validos.", innerException)
        {
        }
        #endregion
    }
}
