using Compartido.DTOs.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCasosUso.Eventos
{
    public interface IEventoPorNombreParcial
    {
        IEnumerable<EventoDTO> Ejecutar(string nombre);
    }
}
