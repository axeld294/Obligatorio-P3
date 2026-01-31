using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.ExcepcionesEntidades.Atleta
{
    public class AtletaException : Exception
    {
        public AtletaException() { }
        public AtletaException(string message) : base(message) { }
        public AtletaException(string message, Exception innerException) : base(message, innerException) { }
    }
}