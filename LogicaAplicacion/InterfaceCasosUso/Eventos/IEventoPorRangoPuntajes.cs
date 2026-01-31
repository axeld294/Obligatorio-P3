using Compartido.DTOs.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCasosUso.Eventos
{
    public interface IEventoPorRangoPuntajes
    {
        IEnumerable<EventoDTO> Ejecutar(decimal pmin, decimal pmax);
    }
}
