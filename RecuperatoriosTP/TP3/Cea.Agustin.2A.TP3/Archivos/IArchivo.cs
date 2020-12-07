using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T>
    {
        #region Metodos
        bool Guardar(string archivos, T datos);
        bool Leer(string archivos, out T datos);
        #endregion
    }
}
