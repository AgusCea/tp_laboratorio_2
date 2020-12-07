using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ProductoException : Exception
    {
        public ProductoException()
            : base("Los datos ingresados son invalidos.")
        {

        }

        public ProductoException(Exception innerException)
            : base("Los datos ingresados son invalidos.", innerException)
        {

        }
    }
}
